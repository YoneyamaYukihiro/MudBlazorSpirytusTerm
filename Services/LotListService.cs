namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN0150 装置別ロット一覧の API 呼び出しサービス。
/// </summary>
public sealed class LotListService(ITfMessageClient mq, IConfiguration cfg, ILogger<LotListService> logger)
{
    private readonly string _defaultSbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;
    private readonly string _defaultWpId = cfg["Spirytus:DefaultWpId"] ?? string.Empty;

    public string DefaultSbId => _defaultSbId;

    public sealed record LotListRequest
    {
        public string MsgVer { get; set; } = "12.01";
        public string SbId { get; set; } = "";
        public string WpId { get; set; } = "";
        /// <summary>処理区分。装置別ロット一覧は "26" 固定。</summary>
        public string ClassDivision { get; set; } = "26";
    }

    public sealed record LotListResponse(
        bool IsSuccess,
        string WpTypeFlag,
        string UseId,
        string UseName,
        string MesModeId,
        string WpStopFlag,
        string WpStatusName,
        string McType,
        IReadOnlyList<LotInfo> LotList,
        string ErrorMessage = ""
    );

    public sealed record LotInfo(
        // ── 基本情報 ──
        string LotId,
        string FlowClass,
        string OpId,
        string StepId,
        string Status,
        string LotManagerName,
        string WfNum,
        string ChipQuantity,
        string LotCommentsFlag,
        string LotHoldFlag,
        string LotStopFlag,
        string LotPriority,
        string RecipeId,
        string LotLastUpdate,
        // ── 時間制限 ──
        string LimitTime,
        string WarnTime,
        string ToOpId,
        string ToStepId,
        // ── キャリア ──
        string CarrierId,
        string CarrierStatId,
        string CarrierPositionName,
        string ToCarrierId,
        string DestName,
        string LCarrierId,
        string UCarrierId,
        // ── 機種・レシピ ──
        string PdId,
        string WfId,
        string AltNumber,
        // ── フラグ ──
        string ReworkFlag,
        string WfPartialRecipeFlag,
        string AvailableRecipeFlag,
        string FrRecipeFlag,
        // ── 処理開始予実 ──
        string DispatchStartTime,
        // ── 追加フィールド ──
        string GrbClass,
        string CommitFlag,
        string CarrierStatName,
        string ShipDiffDay
    );

    public async Task<LotListResponse> GetLotListAsync(LotListRequest req, CancellationToken ct = default)
    {
        var sbId = string.IsNullOrWhiteSpace(req.SbId) ? _defaultSbId : req.SbId;
        var wpId = string.IsNullOrWhiteSpace(req.WpId) ? _defaultWpId : req.WpId;

        logger.LogInformation("LotList request start. SbId={SbId}, WpId={WpId}, ClassDivision={ClassDivision}",
            sbId, wpId, req.ClassDivision);

        var rMsg = new TfMsg();
        rMsg.AddString(Tags.MsgVer, req.MsgVer);
        rMsg.AddString(Tags.ClassDivision, req.ClassDivision);
        rMsg.AddString(Tags.SbId, sbId);
        rMsg.AddString(Tags.WpId, wpId);

        TfMsg aMsg;
        string primaryRaw = string.Empty;
        try
        {
            primaryRaw = await mq.SendMessageAsync(MsgIds.LotList, rMsg.ToTfString(), ct);
            aMsg = ParseReplyOrError(primaryRaw);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotList primary request failed. Subject={Subject}", MsgIds.LotList);
            aMsg = new TfMsg();
            aMsg.AddString(Tags.Ret, Tags.False);
            aMsg.AddString(Tags.ErrMsg, ex.Message);
        }

        // Fallback: if primary request failed (exception or RET!=TRUE), retry ALD endpoint.
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            try
            {
                var altReplyText = await mq.SendMessageAsync(MsgIds.LotListAld, rMsg.ToTfString(), ct);
                var altMsg = ParseReplyOrError(altReplyText);
                if (altMsg.GetString(Tags.Ret) == Tags.True)
                {
                    logger.LogInformation("LotList fallback succeeded. Subject={Subject}", MsgIds.LotListAld);
                    aMsg = altMsg;
                    primaryRaw = altReplyText;
                }
                else
                {
                    logger.LogWarning("LotList fallback failed. Subject={Subject}, Ret={Ret}, Err={Err}",
                        MsgIds.LotListAld, altMsg.GetString(Tags.Ret), altMsg.GetString(Tags.ErrMsg));
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "LotList fallback request failed. Subject={Subject}", MsgIds.LotListAld);
                return Fail($"通信エラー: {ex.Message}");
            }
        }

        var ret = aMsg.GetString(Tags.Ret);
        if (ret != Tags.True)
        {
            var errMsg = aMsg.GetString(Tags.ErrMsg);
            logger.LogWarning("LotList returned FALSE: {Err}", errMsg);
            if (errMsg.Length > 0)
            {
                return Fail(errMsg);
            }

            var rawSummary = SummarizeRaw(primaryRaw);
            return Fail($"ロット一覧取得に失敗しました (RET={ret}) RAW={rawSummary}");
        }

        var wpTypeFlag = aMsg.GetString(Tags.WpTypeFlag);
        var useId = aMsg.GetString(Tags.UseId);
        var useName = aMsg.GetString(Tags.UseName);
        var mesModeId = aMsg.GetString(Tags.MesModeId);
        var wpStopFlag = aMsg.GetString(Tags.WpStopFlag);
        var wpStatus = aMsg.GetString(Tags.WpStatusName);
        var mcType = aMsg.GetString(Tags.McType);

        var ary = aMsg.GetMsgAry(Tags.LotList);
        var lotList = new List<LotInfo>(ary.Count);

        foreach (var item in ary)
        {
            lotList.Add(new LotInfo(
                LotId: item.GetString(Tags.LotId),
                FlowClass: item.GetString(Tags.FlowClass),
                OpId: item.GetString(Tags.OpId),
                StepId: item.GetString(Tags.StepId),
                Status: item.GetString(Tags.NowSt),
                LotManagerName: item.GetString(Tags.EngEmpName),
                WfNum: item.GetString(Tags.WfNum),
                ChipQuantity: item.GetString(Tags.ChipQuantity),
                LotCommentsFlag: item.GetString(Tags.LotCommentsFlag),
                LotHoldFlag: item.GetString(Tags.LotHoldFlag),
                LotStopFlag: item.GetString(Tags.LotStopFlag),
                LotPriority: item.GetString(Tags.LotPriority),
                RecipeId: item.GetString(Tags.RecipeId),
                LotLastUpdate: item.GetString(Tags.LotLastUpdate),
                LimitTime: item.GetString(Tags.LimitTime),
                WarnTime: item.GetString(Tags.WarnTime),
                ToOpId: item.GetString(Tags.ToOpId),
                ToStepId: item.GetString(Tags.ToStepId),
                CarrierId: item.GetString(Tags.CarrierId),
                CarrierStatId: item.GetString(Tags.CarrierStatId),
                CarrierPositionName: item.GetString(Tags.CurrentPositionName),
                ToCarrierId: item.GetString(Tags.ToCarrierId),
                DestName: item.GetString(Tags.DestName),
                LCarrierId: item.GetString(Tags.LCarrierId),
                UCarrierId: item.GetString(Tags.UCarrierId),
                PdId: item.GetString(Tags.PdId),
                WfId: item.GetString(Tags.WfId),
                AltNumber: item.GetString(Tags.AltNumber),
                ReworkFlag: item.GetString(Tags.ReworkFlag),
                WfPartialRecipeFlag: item.GetString(Tags.WfPartialRecipeFlag),
                AvailableRecipeFlag: item.GetString(Tags.AvailableRecipeFlag),
                FrRecipeFlag: item.GetString(Tags.FrRecipeFlag),
                DispatchStartTime: item.GetString(Tags.DispatchStartTime),
                GrbClass: item.GetString(Tags.GrbClass),
                CommitFlag: item.GetString(Tags.CommitFlag),
                CarrierStatName: item.GetString(Tags.CarrierStatName),
                ShipDiffDay: item.GetString(Tags.ShipDiffDay)
            ));
        }

        return new LotListResponse(
            IsSuccess: true,
            WpTypeFlag: wpTypeFlag,
            UseId: useId,
            UseName: useName,
            MesModeId: mesModeId,
            WpStopFlag: wpStopFlag,
            WpStatusName: wpStatus,
            McType: mcType,
            LotList: lotList
        );
    }

    private static TfMsg ParseReplyOrError(string? replyText)
    {
        var text = (replyText ?? string.Empty).Trim();
        if (text.Length == 0)
        {
            var empty = new TfMsg();
            empty.AddString(Tags.Ret, Tags.False);
            empty.AddString(Tags.ErrMsg, "空の応答を受信しました。");
            return empty;
        }

        if (!text.StartsWith("(", StringComparison.Ordinal))
        {
            var nonTf = new TfMsg();
            nonTf.AddString(Tags.Ret, Tags.False);
            nonTf.AddString(Tags.ErrMsg, text);
            return nonTf;
        }

        try
        {
            return TfMsg.FromTfString(text);
        }
        catch (Exception ex)
        {
            var parseErr = new TfMsg();
            parseErr.AddString(Tags.Ret, Tags.False);
            parseErr.AddString(Tags.ErrMsg, $"応答解析エラー: {ex.Message}");
            return parseErr;
        }
    }

    private static string SummarizeRaw(string? raw)
    {
        var s = (raw ?? string.Empty).Trim();
        if (s.Length == 0)
        {
            return "(empty)";
        }

        if (s.Length > 200)
        {
            return s[..200] + "...";
        }

        return s;
    }

    private static LotListResponse Fail(string message) =>
        new(false, "", "", "", "", "", "", "", [], message);
}
