namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN0150 装置別ロット一覧の API 呼び出しサービス。
/// VBソース basxxMG0150.vb の pubblnLotList_Sel に相当する。
/// </summary>
public sealed class LotListService(SpirytusMqService mq, ILogger<LotListService> logger)
{
    // ──────────────────────────────────────────────────────────────
    // 公開 DTO
    // ──────────────────────────────────────────────────────────────

    public sealed record LotListRequest
    {
        public string MsgVer { get; set; } = "12.01";
        public string SbId { get; set; } = "";
        public string WpId { get; set; } = "";
        public string ClassDivision { get; set; } = "";
    }

    public sealed record LotListResponse(
        bool   IsSuccess,
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
        string LotId,
        string FlowClass,
        string OpId,
        string StepId,
        string Status,          // NOW_ST
        string LotManagerName,
        string WfNum,
        string ChipQuantity,
        string LotCommentsFlag,
        string LotHoldFlag,
        string LotStopFlag,
        string LotPriority,
        string RecipeId,
        string LotLastUpdate,
        string LimitTime,
        string WarnTime,
        string CarrierId,
        string PdId,
        string WfId,
        string LCarrierId,
        string UCarrierId
    );

    // ──────────────────────────────────────────────────────────────
    // 公開メソッド
    // ──────────────────────────────────────────────────────────────

    /// <summary>
    /// ロット一覧を取得する（VB: pubblnLotList_Sel）。
    /// </summary>
    public async Task<LotListResponse> GetLotListAsync(
        LotListRequest req, CancellationToken ct = default)
    {
        // ── リクエスト作成 ──────────────────────────────────────────
        var rMsg = new TfMsg();
        rMsg.AddString(Tags.MsgVer,        req.MsgVer);
        rMsg.AddString(Tags.ClassDivision, req.ClassDivision);
        rMsg.AddString(Tags.SbId,          req.SbId);
        rMsg.AddString(Tags.WpId,          req.WpId);

        // ── 送信 ────────────────────────────────────────────────────
        TfMsg aMsg;
        try
        {
            aMsg = await mq.SendRequestAsync(MsgIds.LotList, rMsg, ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotList SendRequest failed");
            return Fail($"通信エラー: {ex.Message}");
        }

        // ── レスポンス解析 ──────────────────────────────────────────
        var ret = aMsg.GetString(Tags.Ret);
        if (ret != Tags.True)
        {
            var errMsg = aMsg.GetString(Tags.ErrMsg);
            logger.LogWarning("LotList returned FALSE: {Err}", errMsg);
            return Fail(errMsg.Length > 0 ? errMsg : "ロット一覧取得に失敗しました");
        }

        var wpTypeFlag  = aMsg.GetString(Tags.WpTypeFlag);
        var useId       = aMsg.GetString(Tags.UseId);
        var useName     = aMsg.GetString(Tags.UseName);
        var mesModeId   = aMsg.GetString(Tags.MesModeId);
        var wpStopFlag  = aMsg.GetString(Tags.WpStopFlag);
        var wpStatus    = aMsg.GetString(Tags.WpStatusName);
        var mcType      = aMsg.GetString(Tags.McType);

        // ── ロット配列解析 ──────────────────────────────────────────
        var ary     = aMsg.GetMsgAry(Tags.LotList);
        var lotList = new List<LotInfo>(ary.Count);

        foreach (var item in ary)
        {
            lotList.Add(new LotInfo(
                LotId:           item.GetString(Tags.LotId),
                FlowClass:       item.GetString(Tags.FlowClass),
                OpId:            item.GetString(Tags.OpId),
                StepId:          item.GetString(Tags.StepId),
                Status:          item.GetString(Tags.NowSt),
                LotManagerName:  item.GetString(Tags.EngEmpName),
                WfNum:           item.GetString(Tags.WfNum),
                ChipQuantity:    item.GetString(Tags.ChipQuantity),
                LotCommentsFlag: item.GetString(Tags.LotCommentsFlag),
                LotHoldFlag:     item.GetString(Tags.LotHoldFlag),
                LotStopFlag:     item.GetString(Tags.LotStopFlag),
                LotPriority:     item.GetString(Tags.LotPriority),
                RecipeId:        item.GetString(Tags.RecipeId),
                LotLastUpdate:   item.GetString(Tags.LotLastUpdate),
                LimitTime:       item.GetString(Tags.LimitTime),
                WarnTime:        item.GetString(Tags.WarnTime),
                CarrierId:       item.GetString(Tags.CarrierId),
                PdId:            item.GetString(Tags.PdId),
                WfId:            item.GetString(Tags.WfId),
                LCarrierId:      item.GetString(Tags.LCarrierId),
                UCarrierId:      item.GetString(Tags.UCarrierId)
            ));
        }

        return new LotListResponse(
            IsSuccess:   true,
            WpTypeFlag:  wpTypeFlag,
            UseId:       useId,
            UseName:     useName,
            MesModeId:   mesModeId,
            WpStopFlag:  wpStopFlag,
            WpStatusName: wpStatus,
            McType:      mcType,
            LotList:     lotList
        );
    }

    // ──────────────────────────────────────────────────────────────
    // ヘルパー
    // ──────────────────────────────────────────────────────────────

    private static LotListResponse Fail(string message) =>
        new(false, "", "", "", "", "", "", "", [], message);
}
