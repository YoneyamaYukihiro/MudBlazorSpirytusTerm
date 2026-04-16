namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN0200 工程別ロット一覧の API 呼び出しサービス。
/// VBソース: VB/0200/CtsfrmxxEN0200.vb, VB/0200/CtsbasxxMG0200.vb
/// </summary>
public sealed class ProcessStepLotListService(ITfMessageClient mq, IConfiguration cfg, ILogger<ProcessStepLotListService> logger)
{
    private readonly string _defaultSbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    public string DefaultSbId => _defaultSbId;

    // ──────── マスタデータ型 ────────

    public sealed record OpItem(string OpId, string ValidFlag);

    public sealed record StepItem(string StepId, string ActionFlag, string ValidFlag);

    public sealed record PdItem(string PdId, string PdName, string LcDirection);

    public sealed record FlowClassItem(string FlowClass, string FlowClassName);

    // ──────── ロット一覧型 ────────

    public sealed record LotListRequest
    {
        /// <summary>処理区分。27=工程別, 02=全工程, 3J=テンプレート</summary>
        public string ClassDivision { get; set; } = "27";
        public string OpId { get; set; } = string.Empty;
        public string StepId { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public IReadOnlyList<string> PdIds { get; set; } = [];
        public IReadOnlyList<string> FlowClasses { get; set; } = [];
    }

    public sealed record LotInfo(
        string LotId,
        string CarrierId,
        string FlowClass,
        string OpId,
        string StepId,
        string NowSt,
        string EngEmpName,
        string WfNum,
        string ChipQuantity,
        string LotHoldFlag,
        string LotStopFlag,
        string LotPriority,
        string CurrentPositionName,
        string LotCommentsFlag,
        string ToCarrierId,
        string AltNumber,
        string LotLastUpdate,
        string ReworkFlag,
        string TemplateSeqNum,
        string LcDirection,
        string PlanShipDate,
        string PdId,
        string PdVersion,
        string JBatchId,
        string CfFlag,
        string LpFlag,
        string VaFlag,
        string TpalClass,
        string SbArea,
        string EditLastUpdate,
        string EditEmpName,
        string ShipDiffDay
    );

    public sealed record LotListResponse(
        bool IsSuccess,
        IReadOnlyList<LotInfo> LotList,
        string ErrorMessage = ""
    );

    // ──────── 大工程一覧取得 (mas_.useoplist) ────────

    public async Task<IReadOnlyList<OpItem>> GetOpListAsync(CancellationToken ct = default)
    {
        var sbId = _defaultSbId;
        var rMsg = new TfMsg();
        rMsg.AddString(Tags.SbId, sbId);
        rMsg.AddString(Tags.MsgVer, "02.00");
        rMsg.AddString(Tags.ClassDivision, "02");
        rMsg.AddString(Tags.OpId, string.Empty);
        rMsg.AddString(Tags.CategoryId, string.Empty);

        try
        {
            var raw = await mq.SendMessageAsync(MsgIds.MasUseOpList, rMsg.ToTfString(), ct);
            var aMsg = ParseReplyOrNull(raw);
            if (aMsg is null || aMsg.GetString(Tags.Ret) != Tags.True) return [];

            var ary = aMsg.GetMsgAry(Tags.OpList);
            var result = new List<OpItem>(ary.Count);
            foreach (var item in ary)
                result.Add(new OpItem(item.GetString(Tags.OpId), item.GetString(Tags.ValidFlag)));
            return result;
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetOpListAsync failed");
            return [];
        }
    }

    // ──────── 小工程一覧取得 (lot_.steplist) ────────

    public async Task<IReadOnlyList<StepItem>> GetStepListAsync(string opId, CancellationToken ct = default)
    {
        var sbId = _defaultSbId;
        var rMsg = new TfMsg();
        rMsg.AddString(Tags.SbId, sbId);
        rMsg.AddString(Tags.MsgVer, "03.00");
        rMsg.AddString(Tags.ClassDivision, "28");
        rMsg.AddString(Tags.OpId, opId);
        // LOT_LIST は空配列で送信
        rMsg.AddMsgAry(Tags.LotList, new TfMsgAry());

        try
        {
            var raw = await mq.SendMessageAsync(MsgIds.LotStepList, rMsg.ToTfString(), ct);
            var aMsg = ParseReplyOrNull(raw);
            if (aMsg is null || aMsg.GetString(Tags.Ret) != Tags.True) return [];

            var ary = aMsg.GetMsgAry(Tags.StepList);
            var result = new List<StepItem>(ary.Count);
            foreach (var item in ary)
                result.Add(new StepItem(
                    item.GetString(Tags.StepId),
                    item.GetString(Tags.ActionFlag),
                    item.GetString(Tags.ValidFlag)));
            return result;
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetStepListAsync failed. OpId={OpId}", opId);
            return [];
        }
    }

    // ──────── 機種一覧取得 (mas_.pdlist__) ────────

    public async Task<IReadOnlyList<PdItem>> GetPdListAsync(CancellationToken ct = default)
    {
        var sbId = _defaultSbId;
        var rMsg = new TfMsg();
        rMsg.AddString(Tags.SbId, sbId);
        // 処理区分 "2A02" = 画面サイズ指定なし + 全て
        rMsg.AddString(Tags.ClassDivision, "2A02");
        rMsg.AddString(Tags.ScreenSizeId, string.Empty);
        rMsg.AddString(Tags.MsgVer, "03.00");

        try
        {
            var raw = await mq.SendMessageAsync(MsgIds.MasPdList, rMsg.ToTfString(), ct);
            var aMsg = ParseReplyOrNull(raw);
            if (aMsg is null || aMsg.GetString(Tags.Ret) != Tags.True) return [];

            var ary = aMsg.GetMsgAry(Tags.PdList);
            var result = new List<PdItem>(ary.Count);
            foreach (var item in ary)
                result.Add(new PdItem(
                    item.GetString(Tags.PdId),
                    item.GetString(Tags.PdName),
                    item.GetString(Tags.LcDirection)));
            return result;
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetPdListAsync failed");
            return [];
        }
    }

    // ──────── 種別一覧取得 (mas_.flowlist) ────────

    public async Task<IReadOnlyList<FlowClassItem>> GetFlowClassListAsync(CancellationToken ct = default)
    {
        var sbId = _defaultSbId;
        var rMsg = new TfMsg();
        rMsg.AddString(Tags.SbId, sbId);
        rMsg.AddString(Tags.MsgVer, "04.00");
        rMsg.AddString(Tags.ClassDivision, "02");
        rMsg.AddString(Tags.PdId, string.Empty);

        try
        {
            var raw = await mq.SendMessageAsync(MsgIds.MasFlowList, rMsg.ToTfString(), ct);
            var aMsg = ParseReplyOrNull(raw);
            if (aMsg is null || aMsg.GetString(Tags.Ret) != Tags.True) return [];

            var ary = aMsg.GetMsgAry(Tags.FlowClassList);
            var result = new List<FlowClassItem>(ary.Count);
            foreach (var item in ary)
                result.Add(new FlowClassItem(
                    item.GetString(Tags.FlowClass),
                    item.GetString(Tags.FlowClassName)));
            return result;
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetFlowClassListAsync failed");
            return [];
        }
    }

    // ──────── 工程別ロット一覧取得 (lot_.oplotlist) ────────

    public async Task<LotListResponse> GetLotListAsync(LotListRequest req, CancellationToken ct = default)
    {
        var sbId = _defaultSbId;
        logger.LogInformation(
            "ProcessStepLotList request start. SbId={SbId}, ClassDivision={CD}, OpId={OpId}, StepId={StepId}",
            sbId, req.ClassDivision, req.OpId, req.StepId);

        var rMsg = new TfMsg();
        rMsg.AddString(Tags.MsgVer, "07.00");
        rMsg.AddString(Tags.SbId, sbId);
        rMsg.AddString(Tags.ClassDivision, req.ClassDivision);
        rMsg.AddString(Tags.OpId, req.OpId);
        rMsg.AddString(Tags.StepId, req.StepId);
        rMsg.AddString(Tags.StartDate, req.StartDate);
        rMsg.AddString(Tags.EndDate, req.EndDate);

        // 機種リスト
        var pdAry = new TfMsgAry();
        foreach (var pdId in req.PdIds)
        {
            var t = new TfMsg();
            t.AddString(Tags.PdId, pdId);
            pdAry.Add(t);
        }
        rMsg.AddMsgAry(Tags.PdList, pdAry);

        // 種別リスト
        var fcAry = new TfMsgAry();
        foreach (var fc in req.FlowClasses)
        {
            var t = new TfMsg();
            t.AddString(Tags.FlowClass, fc);
            fcAry.Add(t);
        }
        rMsg.AddMsgAry(Tags.FlowClassList, fcAry);

        string raw;
        TfMsg aMsg;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotOpList, rMsg.ToTfString(), ct);
            aMsg = TfMsg.ParseOrEmpty(raw);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotOpList request failed");
            return Fail($"通信エラー: {ex.Message}");
        }

        var ret = aMsg.GetString(Tags.Ret);
        if (ret != Tags.True)
        {
            var errMsg = aMsg.GetString(Tags.ErrMsg);
            logger.LogWarning("LotOpList returned FALSE: {Err}", errMsg);
            return Fail(string.IsNullOrEmpty(errMsg) ? $"工程別ロット一覧取得に失敗しました (RET={ret})" : errMsg);
        }

        var ary = aMsg.GetMsgAry(Tags.LotList);
        var lotList = new List<LotInfo>(ary.Count);
        foreach (var item in ary)
        {
            lotList.Add(new LotInfo(
                LotId: item.GetString(Tags.LotId),
                CarrierId: item.GetString(Tags.CarrierId),
                FlowClass: item.GetString(Tags.FlowClass),
                OpId: item.GetString(Tags.OpId),
                StepId: item.GetString(Tags.StepId),
                NowSt: item.GetString(Tags.NowSt),
                EngEmpName: item.GetString(Tags.EngEmpName),
                WfNum: item.GetString(Tags.WfNum),
                ChipQuantity: item.GetString(Tags.ChipQuantity),
                LotHoldFlag: item.GetString(Tags.LotHoldFlag),
                LotStopFlag: item.GetString(Tags.LotStopFlag),
                LotPriority: item.GetString(Tags.LotPriority),
                CurrentPositionName: item.GetString(Tags.CurrentPositionName),
                LotCommentsFlag: item.GetString(Tags.LotCommentsFlag),
                ToCarrierId: item.GetString(Tags.ToCarrierId),
                AltNumber: item.GetString(Tags.AltNumber),
                LotLastUpdate: item.GetString(Tags.LotLastUpdate),
                ReworkFlag: item.GetString(Tags.ReworkFlag),
                TemplateSeqNum: item.GetString(Tags.TemplateSeqNum),
                LcDirection: item.GetString(Tags.LcDirection),
                PlanShipDate: item.GetString(Tags.PlanShipDate),
                PdId: item.GetString(Tags.PdId),
                PdVersion: item.GetString(Tags.PdVersion),
                JBatchId: item.GetString(Tags.JBatchId),
                CfFlag: item.GetString(Tags.CfFlag),
                LpFlag: item.GetString(Tags.LpFlag),
                VaFlag: item.GetString(Tags.VaFlag),
                TpalClass: item.GetString(Tags.TpalClass),
                SbArea: item.GetString(Tags.SbArea),
                EditLastUpdate: item.GetString(Tags.EditLastUpdate),
                EditEmpName: item.GetString(Tags.EditEmpName),
                ShipDiffDay: item.GetString(Tags.ShipDiffDay)
            ));
        }

        logger.LogInformation("LotOpList success. Count={Count}", lotList.Count);
        return new LotListResponse(true, lotList);
    }

    // ──────── ヘルパー ────────

    private static TfMsg? ParseReplyOrNull(string? raw)
    {
        var text = (raw ?? string.Empty).Trim();
        if (text.Length == 0 || !text.StartsWith("(", StringComparison.Ordinal)) return null;
        try { return TfMsg.FromTfString(text); }
        catch { return null; }
    }
    private static LotListResponse Fail(string message) => new(false, [], message);
}
