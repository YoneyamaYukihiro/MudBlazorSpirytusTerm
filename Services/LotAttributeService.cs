namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// ロット情報変更/削除サービス。
/// ・ロット情報取得   (lot_.attribute)
/// ・ロット情報変更   (lot_.chgattribute)
/// ・投入予定ロット削除 (lot_.cancelplan)
/// VBソース: pubblnLotAttribute_Sel / pubblnLotChgAttribute_Upd / pubblnLotCancelPlan_Del (CtsbasxxMG0290.vb)
/// 構造体定義: LotAttribute / LotchgAttribute / LotCancelPlan (CtsbasxxCM0030.vb)
/// </summary>
public sealed class LotAttributeService(ITfMessageClient mq, IConfiguration cfg, ILogger<LotAttributeService> logger)
{
    private readonly string _defaultSbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 公開型 ────────────────────────────────────────────

    /// <summary>ロット属性情報。VBソース: LotAttribute 構造体</summary>
    public sealed record LotAttributeInfo(
        string OrderNum,
        string LotId,
        string CarrierId,
        string PdId,
        string FlowClass,
        string GrbClass,
        string NowSt,
        string StartTime,
        string DispatchStartTime,
        string OpId,
        string StepId,
        string LimitTime,
        string WarnTime,
        string RestrictTypeId,
        string EntryId,
        string EntryName,
        string SpecialFlag,
        string WfNum,
        string MaxWfCount,
        string ChipQuantity,
        string EngEmpId,
        string EngEmpName,
        string PlanThrowinDate,
        string LotPriority,
        string LotPriorityName,
        string PrOrderId,
        string LotSendFlag,
        string SendSbId,
        string SendSbName,
        string CfFlag,
        string LpFlag,
        string DivideFlag,
        string LotLastUpdate,
        string PlanShipDate,
        string UseId,
        string FirstPhotoWpId,
        string FirstPhotoWpName,
        string PlanAssThrowinDate,
        string SectionPriorityFlag,
        string AtlasFlowNumber,
        string ScreenSizeId,
        string CfScreenSizeId
    );

    /// <summary>ロット情報変更要求。VBソース: LotchgAttribute 構造体</summary>
    public sealed record LotChgAttributeRequest(
        string LotId,
        string EmpId,
        string LotLastUpdate,
        string PlanThrowinQuantity  = "",
        string PlanThrowinDate      = "",
        string EngEmpId             = "",
        string LotPriority          = "",
        string PrOrderId            = "",
        string SendSbId             = "",
        string LotSendFlag          = "",
        string PlanShipDate         = "",
        string FirstPhotoWpId       = "",
        string PlanAssThrowinDate   = "",
        string Comments             = "",
        string MsgVer               = "04.00"
    );

    // ──────── ロット情報取得 ─────────────────────────────────────

    /// <summary>
    /// ロット属性情報を取得する。
    /// VBソース: pubblnLotAttribute_Sel, MsgVer="05.00"
    /// </summary>
    public async Task<MesResult<LotAttributeInfo>> GetLotAttributeAsync(
        string lotId,
        string carrierId        = "",
        CancellationToken ct    = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,      _defaultSbId);
        req.AddString(Tags.MsgVer,    "05.00");
        req.AddString(Tags.LotId,     lotId);
        req.AddString(Tags.CarrierId, carrierId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotAttribute, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotAttribute request failed. LotId={LotId}", lotId);
            return new MesResult<LotAttributeInfo>(false, ErrorMessage: ex.Message);
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = msg.GetErrorInfo();
            logger.LogWarning("LotAttribute returned non-TRUE. LotId={LotId}, Raw={Raw}",
                lotId, Summarize(raw));
            return new MesResult<LotAttributeInfo>(false, ErrorCode: code, ErrorMessage: message);
        }

        return new MesResult<LotAttributeInfo>(true, new LotAttributeInfo(
            OrderNum:           msg.GetString(Tags.OrderNum),
            LotId:              msg.GetString(Tags.LotId),
            CarrierId:          msg.GetString(Tags.CarrierId),
            PdId:               msg.GetString(Tags.PdId),
            FlowClass:          msg.GetString(Tags.FlowClass),
            GrbClass:           msg.GetString(Tags.GrbClass),
            NowSt:              msg.GetString(Tags.NowSt),
            StartTime:          msg.GetString(Tags.StartTime),
            DispatchStartTime:  msg.GetString(Tags.DispatchStartTime),
            OpId:               msg.GetString(Tags.OpId),
            StepId:             msg.GetString(Tags.StepId),
            LimitTime:          msg.GetString(Tags.LimitTime),
            WarnTime:           msg.GetString(Tags.WarnTime),
            RestrictTypeId:     msg.GetString(Tags.RestrictTypeId),
            EntryId:            msg.GetString(Tags.EntryId),
            EntryName:          msg.GetString(Tags.EntryName),
            SpecialFlag:        msg.GetString(Tags.SpecialFlag),
            WfNum:              msg.GetString(Tags.WfNum),
            MaxWfCount:         msg.GetString(Tags.MaxWfCount),
            ChipQuantity:       msg.GetString(Tags.ChipQuantity),
            EngEmpId:           msg.GetString(Tags.EngEmpId),
            EngEmpName:         msg.GetString(Tags.EngEmpName),
            PlanThrowinDate:    msg.GetString(Tags.PlanThrowinDate),
            LotPriority:        msg.GetString(Tags.LotPriority),
            LotPriorityName:    msg.GetString(Tags.LotPriorityName),
            PrOrderId:          msg.GetString(Tags.PrOrderId),
            LotSendFlag:        msg.GetString(Tags.LotSendFlag),
            SendSbId:           msg.GetString(Tags.SendSbId),
            SendSbName:         msg.GetString(Tags.SendSbName),
            CfFlag:             msg.GetString(Tags.CfFlag),
            LpFlag:             msg.GetString(Tags.LpFlag),
            DivideFlag:         msg.GetString(Tags.DivideFlag),
            LotLastUpdate:      msg.GetString(Tags.LotLastUpdate),
            PlanShipDate:       msg.GetString(Tags.PlanShipDate),
            UseId:              msg.GetString(Tags.UseId),
            FirstPhotoWpId:     msg.GetString(Tags.FirstPhotoWpId),
            FirstPhotoWpName:   msg.GetString(Tags.FirstPhotoWpName),
            PlanAssThrowinDate: msg.GetString(Tags.PlanAssThrowinDate),
            SectionPriorityFlag: msg.GetString(Tags.SectionPriorityFlag),
            AtlasFlowNumber:    msg.GetString(Tags.AtlasFlowNumber),
            ScreenSizeId:       msg.GetString(Tags.ScreenSizeId),
            CfScreenSizeId:     msg.GetString(Tags.CfScreenSizeId)
        ));
    }

    // ──────── ロット情報変更 ─────────────────────────────────────

    /// <summary>
    /// ロット情報を変更する。
    /// VBソース: pubblnLotChgAttribute_Upd, MsgVer="04.00"
    /// </summary>
    public async Task<bool> ChangeAttributeAsync(
        LotChgAttributeRequest request, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,              request.MsgVer);
        req.AddString(Tags.SbId,                _defaultSbId);
        req.AddString(Tags.LotId,               request.LotId);
        req.AddString(Tags.PlanThrowinQuantity, request.PlanThrowinQuantity);
        req.AddString(Tags.PlanThrowinDate,     request.PlanThrowinDate);
        req.AddString(Tags.EngEmpId,            request.EngEmpId);
        req.AddString(Tags.LotPriority,         request.LotPriority);
        req.AddString(Tags.PrOrderId,           request.PrOrderId);
        req.AddString(Tags.SendSbId,            request.SendSbId);
        req.AddString(Tags.LotSendFlag,         request.LotSendFlag);
        req.AddString(Tags.PlanShipDate,        request.PlanShipDate);
        req.AddString(Tags.Comments,            request.Comments);
        req.AddString(Tags.LotLastUpdate,       request.LotLastUpdate);
        req.AddString(Tags.EmpId,               request.EmpId);
        req.AddString(Tags.FirstPhotoWpId,      request.FirstPhotoWpId);
        req.AddString(Tags.PlanAssThrowinDate,  request.PlanAssThrowinDate);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotChgAttribute, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotChgAttribute request failed. LotId={LotId}", request.LotId);
            return false;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("LotChgAttribute returned non-TRUE. LotId={LotId}, Raw={Raw}",
                request.LotId, Summarize(raw));
            return false;
        }

        return true;
    }

    // ──────── 投入予定ロット削除 ─────────────────────────────────

    /// <summary>
    /// 投入予定ロットを削除する。
    /// VBソース: pubblnLotCancelPlan_Del, MsgVer="01.00"
    /// </summary>
    public async Task<bool> CancelPlanAsync(
        string lotId,
        string empId,
        string lotLastUpdate,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,        "01.00");
        req.AddString(Tags.LotId,         lotId);
        req.AddString(Tags.SbId,          _defaultSbId);
        req.AddString(Tags.LotLastUpdate, lotLastUpdate);
        req.AddString(Tags.EmpId,         empId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotCancelPlan, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotCancelPlan request failed. LotId={LotId}", lotId);
            return false;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("LotCancelPlan returned non-TRUE. LotId={LotId}, Raw={Raw}",
                lotId, Summarize(raw));
            return false;
        }

        return true;
    }

    // ──────── 内部ヘルパー ────────────────────────────────────────
    private static string Summarize(string? raw) =>
        (raw ?? string.Empty) is { Length: > 200 } s ? s[..200] + "..." : raw ?? string.Empty;
}
