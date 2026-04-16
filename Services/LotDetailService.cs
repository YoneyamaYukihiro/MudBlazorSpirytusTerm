namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN01C0 ロット情報詳細の API 呼び出しサービス。
/// VBソース: VB/COMN/CtsfrmxxCM00R0.vb, VB/COMN/CtsbasxxCM0050.vb
/// </summary>
public sealed class LotDetailService(ITfMessageClient mq, IConfiguration cfg, ILogger<LotDetailService> logger)
{
    private readonly string _defaultSbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    private const string MsgVer = "03.00";

    // 処理区分: キャリア指定 or ロット指定 (CPstrCD0K / CPstrCD0L)
    private const string CdCarrier = "0K";
    private const string CdLot     = "0L";

    // ──────── 分割ロット ────────

    public sealed record DivideLotItem(string DivideLotId);

    // ──────── ロット詳細情報 ────────

    public sealed record LotDetailInfo(
        string LotId,
        string CarrierId,
        string PdId,
        string FlowClass,
        string GrbClass,
        string LotPriority,
        string LotPriorityName,
        string WfNum,
        string ChipQuantity,
        string EngEmpName,
        string CurrentPositionName,
        string LastEventName,
        string EntryTime,
        string EmpName,
        string Comments,
        string SpecialFlag,
        string LotHoldFlag,
        string LotStopFlag,
        string NowSt,
        string DispatchStartTime,
        string OpId,
        string StepId,
        string AltFlag,
        string SwapFlag,
        string ReworkFlag,
        string BatchId,
        string WpName,
        string PortName,
        string RecipeId,
        string LoaderCarrierId,
        string UnloaderCarrierId,
        string NextOpId,
        string NextStepId,
        string NextAltFlag,
        string NextSwapFlag,
        string DivideLotId,
        IReadOnlyList<DivideLotItem> DivideLotList,
        string LimitTime,
        string ToOpId,
        string ToStepId,
        string WarnTime,
        string LotLastUpdate,
        string RestrictTypeId,
        string CfFlag,
        string VaFlag,
        string KrfFileName,
        string OdfCarrierId,
        string OdfLotId,
        string LpFlag,
        string LotSendFlag
    );

    public sealed record LotDetailResponse(
        bool IsSuccess,
        LotDetailInfo? Detail,
        string ErrorMessage = ""
    );

    // ──────── キャリアIDで取得 ────────

    public Task<LotDetailResponse> GetByCarrierAsync(string carrierId, CancellationToken ct = default)
        => FetchAsync(CdCarrier, string.Empty, carrierId, ct);

    // ──────── ロットIDで取得 ────────

    public Task<LotDetailResponse> GetByLotAsync(string lotId, CancellationToken ct = default)
        => FetchAsync(CdLot, lotId, string.Empty, ct);

    // ──────── 内部実装 ────────

    private async Task<LotDetailResponse> FetchAsync(
        string classDivision, string lotId, string carrierId, CancellationToken ct)
    {
        logger.LogInformation(
            "LotDetail request start. SbId={SbId}, CD={CD}, LotId={LotId}, CarrierId={CarrierId}",
            _defaultSbId, classDivision, lotId, carrierId);

        var rMsg = new TfMsg();
        rMsg.AddString(Tags.MsgVer,         MsgVer);
        rMsg.AddString(Tags.SbId,           _defaultSbId);
        rMsg.AddString(Tags.ClassDivision,  classDivision);
        rMsg.AddString(Tags.LotId,          lotId);
        rMsg.AddString(Tags.CarrierId,      carrierId);

        string raw;
        TfMsg aMsg;
        try
        {
            raw  = await mq.SendMessageAsync(MsgIds.LotDetail, rMsg.ToTfString(), ct);
            aMsg = TfMsg.ParseOrEmpty(raw);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotDetail request failed");
            return Fail($"通信エラー: {ex.Message}");
        }

        var ret = aMsg.GetString(Tags.Ret);
        if (ret != Tags.True)
        {
            var errMsg = aMsg.GetString(Tags.ErrMsg);
            logger.LogWarning("LotDetail returned FALSE: {Err}", errMsg);
            return Fail(string.IsNullOrEmpty(errMsg)
                ? $"ロット情報詳細取得に失敗しました (RET={ret})"
                : errMsg);
        }

        // 分割ロットリスト
        var divAry   = aMsg.GetMsgAry(Tags.DivideLotList);
        var divItems = new List<DivideLotItem>(divAry.Count);
        foreach (var d in divAry)
            divItems.Add(new DivideLotItem(d.GetString(Tags.DivideLotId)));

        var detail = new LotDetailInfo(
            LotId:               aMsg.GetString(Tags.LotId),
            CarrierId:           aMsg.GetString(Tags.CarrierId),
            PdId:                aMsg.GetString(Tags.PdId),
            FlowClass:           aMsg.GetString(Tags.FlowClass),
            GrbClass:            aMsg.GetString(Tags.GrbClass),
            LotPriority:         aMsg.GetString(Tags.LotPriority),
            LotPriorityName:     aMsg.GetString(Tags.LotPriorityName),
            WfNum:               aMsg.GetString(Tags.WfNum),
            ChipQuantity:        aMsg.GetString(Tags.ChipQuantity),
            EngEmpName:          aMsg.GetString(Tags.EngEmpName),
            CurrentPositionName: aMsg.GetString(Tags.CurrentPositionName),
            LastEventName:       aMsg.GetString(Tags.LastEventName),
            EntryTime:           aMsg.GetString(Tags.EntryTime),
            EmpName:             aMsg.GetString(Tags.EmpName),
            Comments:            aMsg.GetString(Tags.Comments),
            SpecialFlag:         aMsg.GetString(Tags.SpecialFlag),
            LotHoldFlag:         aMsg.GetString(Tags.LotHoldFlag),
            LotStopFlag:         aMsg.GetString(Tags.LotStopFlag),
            NowSt:               aMsg.GetString(Tags.NowSt),
            DispatchStartTime:   aMsg.GetString(Tags.DispatchStartTime),
            OpId:                aMsg.GetString(Tags.OpId),
            StepId:              aMsg.GetString(Tags.StepId),
            AltFlag:             aMsg.GetString(Tags.AltFlag),
            SwapFlag:            aMsg.GetString(Tags.SwapFlag),
            ReworkFlag:          aMsg.GetString(Tags.ReworkFlag),
            BatchId:             aMsg.GetString(Tags.BatchId),
            WpName:              aMsg.GetString(Tags.WpName),
            PortName:            aMsg.GetString(Tags.PortName),
            RecipeId:            aMsg.GetString(Tags.RecipeId),
            LoaderCarrierId:     aMsg.GetString(Tags.LoaderCarrierId),
            UnloaderCarrierId:   aMsg.GetString(Tags.UnloaderCarrierId),
            NextOpId:            aMsg.GetString(Tags.NextOpId),
            NextStepId:          aMsg.GetString(Tags.NextStepId),
            NextAltFlag:         aMsg.GetString(Tags.NextAltFlag),
            NextSwapFlag:        aMsg.GetString(Tags.NextSwapFlag),
            DivideLotId:         aMsg.GetString(Tags.DivideLotId),
            DivideLotList:       divItems,
            LimitTime:           aMsg.GetString(Tags.LimitTime),
            ToOpId:              aMsg.GetString(Tags.ToOpId),
            ToStepId:            aMsg.GetString(Tags.ToStepId),
            WarnTime:            aMsg.GetString(Tags.WarnTime),
            LotLastUpdate:       aMsg.GetString(Tags.LotLastUpdate),
            RestrictTypeId:      aMsg.GetString(Tags.RestrictTypeId),
            CfFlag:              aMsg.GetString(Tags.CfFlag),
            VaFlag:              aMsg.GetString(Tags.VaFlag),
            KrfFileName:         aMsg.GetString(Tags.KrfFileName),
            OdfCarrierId:        aMsg.GetString(Tags.OdfCarrierId),
            OdfLotId:            aMsg.GetString(Tags.OdfLotId),
            LpFlag:              aMsg.GetString(Tags.LpFlag),
            LotSendFlag:         aMsg.GetString(Tags.LotSendFlag)
        );

        logger.LogInformation("LotDetail success. LotId={LotId}", detail.LotId);
        return new LotDetailResponse(true, detail);
    }

    // ──────── ヘルパー ────────
    private static LotDetailResponse Fail(string message) => new(false, null, message);
}
