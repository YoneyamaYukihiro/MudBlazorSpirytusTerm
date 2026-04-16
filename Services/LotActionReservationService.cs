namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// アクション予約サービス。
/// ・使用装置ステップ一覧取得   (mas_.stepusedwplist)
/// ・ロットトラベラー取得       (lot_.traveler)
/// ・PDトラベラー取得           (mas_.pdtraveler)
/// ・アクション情報取得         (lot_.actinfo_)
/// ・アクション予約更新         (lot_.actrsv__)
/// ・アクション削除             (lot_.delact__)
/// VBソース: CtsbasxxMG0270.vb
/// 構造体定義: CtsbasxxCM0030.vb
/// </summary>
public sealed class LotActionReservationService(ITfMessageClient mq, IConfiguration cfg, ILogger<LotActionReservationService> logger)
{
    private readonly string _defaultSbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 公開型 ────────────────────────────────────────────

    /// <summary>ステップ一覧の1要素。VBソース: StepUsedWpList 構造体</summary>
    public sealed record StepItem(
        string OpId,
        string StepId,
        string ActionFlag
    );

    /// <summary>使用装置ステップ一覧取得の結果。VBソース: pubblnStepUsedWpList_Sel</summary>
    public sealed record StepUsedWpListResult(
        string WfActionFlag,
        IReadOnlyList<StepItem> Steps
    );

    /// <summary>ロットトラベラーのステップ要素。VBソース: LotTraveler 構造体</summary>
    public sealed record LotTravelerStep(
        string StepNum,
        string OpId,
        string StepId,
        string AltStepFlag,
        string ActionFlag
    );

    /// <summary>ロットトラベラー取得の結果。VBソース: pubblnLotTraveler_Sel</summary>
    public sealed record LotTravelerResult(
        string EngEmpId,
        string EngEmpName,
        string FlowClass,
        IReadOnlyList<LotTravelerStep> Steps
    );

    /// <summary>PDトラベラーのステップ要素。VBソース: MasPdTraveler 構造体</summary>
    public sealed record PdTravelerStep(
        string StepNum,
        string OpId,
        string StepId,
        string AltStepFlag,
        string ReworkStepFlag,
        string ReworkRouteId,
        string SpecialStepFlag,
        string SpecialRouteId,
        string ActionFlag
    );

    /// <summary>アクション情報取得の要求。VBソース: pubblnLotActinfo_Sel パラメータ</summary>
    public sealed record ActInfoRequest(
        string LotActionTypeId,
        string OpId,
        string StepId,
        string ItemName,
        string ActionTrigger = ""
    );

    /// <summary>WFリストの1要素。VBソース: WfList 構造体</summary>
    public sealed record WfListItem(
        string WfId,
        string ExecTime
    );

    /// <summary>アクション情報取得の結果。VBソース: publbnLotActinfo_Sel</summary>
    public sealed record ActInfoResult(
        string LotActionId,
        string Message,
        string WorkDirectionId,
        string EngEmpId,
        string EngEmpName,
        string StopHoldFlag,
        string HoldReasonId,
        string StartTime,
        string EndTime,
        string EditTime,
        string HoldComments,
        string HoldPeriod,
        string HoldEmpId,
        string HoldEmpName,
        IReadOnlyList<WfListItem> WfList
    );

    /// <summary>アクション予約更新の要求。VBソース: pubblnLotactrsv_Upd パラメータ</summary>
    public sealed record ActRsvRequest(
        string LotActionTypeId,
        string OpId,
        string StepId,
        string ItemName,
        string ActionTrigger,
        string Message,
        string WorkDirectionId,
        string EngEmpId,
        string StopHoldFlag,
        string HoldReasonId,
        string EmpId,
        string StartTime,
        string EndTime,
        string EditTime,
        string HoldComments,
        string HoldPeriod,
        string HoldEmpId,
        IReadOnlyList<WfListItem> WfList,
        string MsgVer = "06.01"
    );

    // ──────── 使用装置ステップ一覧取得 ─────────────────────────

    /// <summary>
    /// 使用装置のステップ一覧を取得する。
    /// VBソース: pubblnStepUsedWpList_Sel, MsgVer="03.00"
    /// </summary>
    public async Task<MesResult<StepUsedWpListResult>> GetStepUsedWpListAsync(
        string wpId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,    _defaultSbId);
        req.AddString(Tags.WpId,    wpId);
        req.AddString(Tags.MsgVer,  "03.00");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.MasStepUsedWpList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "MasStepUsedWpList request failed. WpId={WpId}", wpId);
            return new MesResult<StepUsedWpListResult>(false, ErrorMessage: ex.Message);
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = msg.GetErrorInfo();
            logger.LogWarning("MasStepUsedWpList returned non-TRUE. WpId={WpId}, Raw={Raw}",
                wpId, Summarize(raw));
            return new MesResult<StepUsedWpListResult>(false, ErrorCode: code, ErrorMessage: message);
        }

        var wfActionFlag = msg.GetString(Tags.WfActionFlag);
        var stepAry = msg.GetMsgAry(Tags.StepList);
        var steps = stepAry
            .Select(e => new StepItem(
                OpId:       e.GetString(Tags.OpId),
                StepId:     e.GetString(Tags.StepId),
                ActionFlag: e.GetString(Tags.ActionFlag)))
            .ToList();

        return new MesResult<StepUsedWpListResult>(true, new StepUsedWpListResult(wfActionFlag, steps));
    }

    // ──────── ロットトラベラー取得 ───────────────────────────────

    /// <summary>
    /// ロットトラベラー情報を取得する。
    /// VBソース: pubblnLotTraveler_Sel, MsgVer="03.02"
    /// </summary>
    public async Task<MesResult<LotTravelerResult>> GetLotTravelerAsync(
        string lotId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,   _defaultSbId);
        req.AddString(Tags.LotId,  lotId);
        req.AddString(Tags.MsgVer, "03.02");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotTraveler, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotTraveler request failed. LotId={LotId}", lotId);
            return new MesResult<LotTravelerResult>(false, ErrorMessage: ex.Message);
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = msg.GetErrorInfo();
            logger.LogWarning("LotTraveler returned non-TRUE. LotId={LotId}, Raw={Raw}",
                lotId, Summarize(raw));
            return new MesResult<LotTravelerResult>(false, ErrorCode: code, ErrorMessage: message);
        }

        var stepAry = msg.GetMsgAry(Tags.StepList);
        var steps = stepAry
            .Select(e => new LotTravelerStep(
                StepNum:     e.GetString(Tags.StepNum),
                OpId:        e.GetString(Tags.OpId),
                StepId:      e.GetString(Tags.StepId),
                AltStepFlag: e.GetString(Tags.AltStepFlag),
                ActionFlag:  e.GetString(Tags.ActionFlag)))
            .ToList();

        return new MesResult<LotTravelerResult>(true, new LotTravelerResult(
            EngEmpId:   msg.GetString(Tags.EngEmpId),
            EngEmpName: msg.GetString(Tags.EngEmpName),
            FlowClass:  msg.GetString(Tags.FlowClass),
            Steps:      steps));
    }

    // ──────── PDトラベラー取得 ───────────────────────────────────

    /// <summary>
    /// PDトラベラー情報を取得する。
    /// VBソース: pubblnMasPdtraveler_Sel, MsgVer="04.00"
    /// </summary>
    public async Task<MesResult<IReadOnlyList<PdTravelerStep>>> GetPdTravelerAsync(
        string pdId,
        string entryId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,    _defaultSbId);
        req.AddString(Tags.PdId,    pdId);
        req.AddString(Tags.EntryId, entryId);
        req.AddString(Tags.MsgVer,  "04.00");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.MasPdTraveler, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "MasPdTraveler request failed. PdId={PdId}", pdId);
            return new MesResult<IReadOnlyList<PdTravelerStep>>(false, ErrorMessage: ex.Message);
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = msg.GetErrorInfo();
            logger.LogWarning("MasPdTraveler returned non-TRUE. PdId={PdId}, Raw={Raw}",
                pdId, Summarize(raw));
            return new MesResult<IReadOnlyList<PdTravelerStep>>(false, ErrorCode: code, ErrorMessage: message);
        }

        var stepAry = msg.GetMsgAry(Tags.StepList);
        IReadOnlyList<PdTravelerStep> steps = stepAry
            .Select(e => new PdTravelerStep(
                StepNum:        e.GetString(Tags.StepNum),
                OpId:           e.GetString(Tags.OpId),
                StepId:         e.GetString(Tags.StepId),
                AltStepFlag:    e.GetString(Tags.AltStepFlag),
                ReworkStepFlag: e.GetString(Tags.ReworkStepFlag),
                ReworkRouteId:  e.GetString(Tags.ReworkRouteId),
                SpecialStepFlag:e.GetString(Tags.SpecialStepFlag),
                SpecialRouteId: e.GetString(Tags.SpecialRouteId),
                ActionFlag:     e.GetString(Tags.ActionFlag)))
            .ToList();
        return new MesResult<IReadOnlyList<PdTravelerStep>>(true, steps);
    }

    // ──────── アクション情報取得 ─────────────────────────────────

    /// <summary>
    /// アクション情報を取得する。
    /// VBソース: pubblnLotActinfo_Sel, MsgVer="04.01"
    /// </summary>
    public async Task<MesResult<ActInfoResult>> GetActInfoAsync(
        ActInfoRequest request,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,             _defaultSbId);
        req.AddString(Tags.LotActionTypeId,  request.LotActionTypeId);
        req.AddString(Tags.OpId,             request.OpId);
        req.AddString(Tags.StepId,           request.StepId);
        req.AddString(Tags.ItemName,         request.ItemName);
        req.AddString(Tags.MsgVer,           "04.01");
        req.AddString(Tags.ActionTrigger,    request.ActionTrigger);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotActInfo, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotActInfo request failed. LotActionTypeId={Id}", request.LotActionTypeId);
            return new MesResult<ActInfoResult>(false, ErrorMessage: ex.Message);
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = msg.GetErrorInfo();
            logger.LogWarning("LotActInfo returned non-TRUE. LotActionTypeId={Id}, Raw={Raw}",
                request.LotActionTypeId, Summarize(raw));
            return new MesResult<ActInfoResult>(false, ErrorCode: code, ErrorMessage: message);
        }

        var wfAry = msg.GetMsgAry(Tags.WfList);
        var wfList = wfAry
            .Select(e => new WfListItem(
                WfId:     e.GetString(Tags.WfId),
                ExecTime: e.GetString(Tags.ExecTime)))
            .ToList();

        return new MesResult<ActInfoResult>(true, new ActInfoResult(
            LotActionId:    msg.GetString(Tags.LotActionId),
            Message:        msg.GetString(Tags.MessageText),
            WorkDirectionId:msg.GetString(Tags.WorkDirectionId),
            EngEmpId:       msg.GetString(Tags.EngEmpId),
            EngEmpName:     msg.GetString(Tags.EngEmpName),
            StopHoldFlag:   msg.GetString(Tags.StopHoldFlag),
            HoldReasonId:   msg.GetString(Tags.HoldReasonId),
            StartTime:      msg.GetString(Tags.StartTime),
            EndTime:        msg.GetString(Tags.EndTime),
            EditTime:       msg.GetString(Tags.EditTime),
            HoldComments:   msg.GetString(Tags.HoldComments),
            HoldPeriod:     msg.GetString(Tags.HoldPeriod),
            HoldEmpId:      msg.GetString(Tags.HoldEmpId),
            HoldEmpName:    msg.GetString(Tags.HoldEmpName),
            WfList:         wfList));
    }

    // ──────── アクション予約更新 ─────────────────────────────────

    /// <summary>
    /// アクション予約を更新する。
    /// VBソース: pubblnLotactrsv_Upd, MsgVer="06.01"
    /// </summary>
    public async Task<bool> SetActionReservationAsync(
        ActRsvRequest request,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,             _defaultSbId);
        req.AddString(Tags.LotActionTypeId,  request.LotActionTypeId);
        req.AddString(Tags.OpId,             request.OpId);
        req.AddString(Tags.StepId,           request.StepId);
        req.AddString(Tags.ItemName,         request.ItemName);
        req.AddString(Tags.ActionTrigger,    request.ActionTrigger);
        req.AddString(Tags.MessageText,      request.Message);
        req.AddString(Tags.WorkDirectionId,  request.WorkDirectionId);
        req.AddString(Tags.EngEmpId,         request.EngEmpId);
        req.AddString(Tags.StopHoldFlag,     request.StopHoldFlag);
        req.AddString(Tags.HoldReasonId,     request.HoldReasonId);
        req.AddString(Tags.EmpId,            request.EmpId);
        req.AddString(Tags.StartTime,        request.StartTime);
        req.AddString(Tags.EndTime,          request.EndTime);
        req.AddString(Tags.EditTime,         request.EditTime);
        req.AddString(Tags.HoldComments,     request.HoldComments);
        req.AddString(Tags.HoldPeriod,       request.HoldPeriod);
        req.AddString(Tags.HoldEmpId,        request.HoldEmpId);
        req.AddString(Tags.MsgVer,           request.MsgVer);

        var wfAry = new TfMsgAry();
        foreach (var wf in request.WfList)
        {
            var entry = new TfMsg();
            entry.AddString(Tags.WfId,     wf.WfId);
            entry.AddString(Tags.ExecTime, wf.ExecTime);
            wfAry.Add(entry);
        }
        req.AddMsgAry(Tags.WfList, wfAry);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotActRsv, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotActRsv request failed. LotActionTypeId={Id}", request.LotActionTypeId);
            return false;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("LotActRsv returned non-TRUE. LotActionTypeId={Id}, Raw={Raw}",
                request.LotActionTypeId, Summarize(raw));
            return false;
        }

        return true;
    }

    // ──────── アクション削除 ─────────────────────────────────────

    /// <summary>
    /// アクション予約を削除する。
    /// VBソース: pubblnLotDelAct_Upd, MsgVer="02.01"
    /// </summary>
    public async Task<bool> DeleteActionReservationAsync(
        string lotActionId,
        string editTime,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotActionId, lotActionId);
        req.AddString(Tags.EditTime,    editTime);
        req.AddString(Tags.MsgVer,      "02.01");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotDelAct, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotDelAct request failed. LotActionId={Id}", lotActionId);
            return false;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("LotDelAct returned non-TRUE. LotActionId={Id}, Raw={Raw}",
                lotActionId, Summarize(raw));
            return false;
        }

        return true;
    }

    // ──────── 内部ヘルパー ────────────────────────────────────────
    private static string Summarize(string? raw) =>
        (raw ?? string.Empty) is { Length: > 200 } s ? s[..200] + "..." : raw ?? string.Empty;
}
