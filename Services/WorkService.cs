namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// ロット作業開始・終了、処理開始・終了、次工程送出サービス。
/// ・ロット作業開始     (lot_.wrkstart)  VBソース: pubblnLotStart_Ins    (CtsbasxxCM0050.vb)
/// ・ロット作業終了     (lot_.wrkend__)  VBソース: pubblnLotWrkend_Upd   (CtsbasxxMG0060.vb)
/// ・ロット処理開始     (lot_.prcstart)  VBソース: pubblnLotPrcstart_Ins (CtsbasxxMG0070.vb)
/// ・ロット処理終了     (lot_.prcend__)  VBソース: pubblnLotProcend_Upd  (CtsbasxxMG0080.vb)
/// ・ロット次工程送出   (lot_.nextsend)  VBソース: pubblnLotNextSend_Upd (CtsbasxxCM0050.vb)
/// ・ロット次工程取得   (lot_.nextsteplist) VBソース: pubblnLotNextStepList_Sel (CtsbasxxCM0050.vb)
/// ・作業開始取消       (lot_.cnclwrkstart) VBソース: pubblnCancelStart_Upd (CtsbasxxMG0130.vb)
/// </summary>
public sealed class WorkService(ITfMessageClient mq, IConfiguration cfg, ILogger<WorkService> logger)
{
    private readonly string _defaultSbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 公開型 ────────────────────────────────────────────

    /// <summary>ロット作業開始要求。VBソース: Lotwrkstart 構造体 (CtsbasxxCM0030.vb)</summary>
    public sealed record WorkStartRequest(
        string LotId,
        string OpId,
        string StepId,
        string WpId,
        string EmpId,
        string LotLastUpdate,
        string Comments      = "",
        string AltNumber     = "",
        string ToCarrierId   = "",
        string CfCarrierId   = "",
        string ClassDivision = "",
        string MsgVer        = "07.03"
    );

    /// <summary>ロット作業開始結果</summary>
    public sealed record WorkStartResult(
        bool   IsSuccess,
        string ToOpId        = "",
        string ToStepId      = "",
        string LimitTime     = "",
        string WarnTime      = "",
        string LotLastUpdate = "",
        string ErrorCode     = "",
        string ErrorMessage  = ""
    );

    /// <summary>ロット作業終了要求。VBソース: LotwrkEnd 構造体 (CtsbasxxCM0030.vb)</summary>
    public sealed record WorkEndRequest(
        string LotId,
        string OpId,
        string StepId,
        string EmpId,
        string LotLastUpdate,
        string Comments      = "",
        string ClassDivision = "",
        string MsgVer        = "04.05"
    );

    /// <summary>ロット作業終了結果</summary>
    public sealed record WorkEndResult(
        bool   IsSuccess,
        string LotId             = "",   // 更新後ロットID（特殊最終時に変わる場合あり）
        string LotLastUpdate     = "",
        string ActionFlag        = "",
        string ResultReworkState = "",
        string ElectHoldFlag     = "",
        string MoveResult        = "",
        string ToCarrierId       = "",
        string TftHoldFlag       = "",
        string GuidanceMsg       = "",
        string GuidanceMsgCode   = "",
        string ExcpHoldFlag      = "",
        string NormalHoldFlag    = "",
        IReadOnlyList<TpLot>? TpLotList = null,
        string ErrorCode         = "",
        string ErrorMessage      = ""
    );

    /// <summary>TPALロット。VBソース: TpLotList 構造体 (CtsbasxxCM0030.vb)</summary>
    public sealed record TpLot(string TpLotId, string CarrierId);

    /// <summary>ロット処理開始要求。VBソース: Lotprcstart 構造体 (CtsbasxxCM0030.vb)</summary>
    public sealed record ProcessStartRequest(
        string LotId,
        string OpId,
        string StepId,
        string WpId,
        string EmpId,
        string LotLastUpdate,
        string ClassDivision = "",
        string PortId        = "",
        string Comments      = "",
        string ToPortId      = "",
        string MsgVer        = "07.00"
    );

    /// <summary>ロット処理開始結果</summary>
    public sealed record ProcessStartResult(
        bool   IsSuccess,
        string ToOpId    = "",
        string ToStepId  = "",
        string LimitTime = "",
        string WarnTime  = "",
        string RecipeId  = "",
        string PolTime   = "",
        string PlcResult = "",
        string ErrorCode    = "",
        string ErrorMessage = ""
    );

    /// <summary>ロット処理終了要求。VBソース: pubblnLotProcend_Upd (CtsbasxxMG0080.vb)</summary>
    public sealed record ProcessEndRequest(
        string LotId,
        string EmpId,
        string LotLastUpdate,
        string ClassDivision = "",
        string Comments      = "",
        string MsgVer        = "04.00"
    );

    /// <summary>ロット処理終了結果</summary>
    public sealed record ProcessEndResult(
        bool   IsSuccess,
        string GuidanceMsg     = "",
        string GuidanceMsgCode = "",
        string PlcResult       = "",
        string ErrorCode       = "",
        string ErrorMessage    = ""
    );

    /// <summary>次工程送出結果</summary>
    public sealed record NextSendResult(
        bool   IsSuccess,
        string ActionFlag   = "",
        string SendResult   = "",
        string Comments     = "",
        string ErrorCode    = "",
        string ErrorMessage = ""
    );

    /// <summary>次工程取得結果の工程エントリ</summary>
    public sealed record NextStepEntry(
        string NextOpId,
        string NextStepId,
        string StepDivision,
        IReadOnlyList<WpEntry> WpList
    );

    /// <summary>次工程のWP</summary>
    public sealed record WpEntry(string WpId, string WpName);

    /// <summary>作業開始取消要求。VBソース: LotCnclWrkStart 構造体 (CtsbasxxCM0030.vb)</summary>
    public sealed record CancelStartRequest(
        string LotId,
        string EmpId,
        string LotLastUpdate,
        string CancelMode = "",
        string Comments   = ""
    );

    /// <summary>作業開始取消結果</summary>
    public sealed record CancelStartResult(
        bool   IsSuccess,
        string GuidanceMsg     = "",
        string GuidanceMsgCode = "",
        string ErrorCode       = "",
        string ErrorMessage    = ""
    );

    // ──────── ロット現在状態取得 ──────────────────────────────────

    /// <summary>lot_.curstate の工程エントリ</summary>
    public sealed record LotStepInfo(
        string OpId,
        string StepId,
        string StepDivision,
        string AltNumber,
        IReadOnlyList<LotWpInfo> WpList
    );

    /// <summary>lot_.curstate の装置エントリ</summary>
    public sealed record LotWpInfo(string WpId, string WpName);

    /// <summary>ロット現在状態取得結果。VBソース: Lotprestate 構造体 (CtsbasxxCM0030.vb)</summary>
    public sealed record LotCurStateResult(
        bool   IsSuccess,
        string LotId             = "",
        string FlowClass         = "",
        string PdId              = "",
        string PdName            = "",
        string NowSt             = "",
        string WfNum             = "",
        string ChipQuantity      = "",
        string LimitTime         = "",
        string WarnTime          = "",
        string StartTime         = "",
        string Comments          = "",
        string WorkCondition     = "",
        string LotHoldFlag       = "",
        string LotLastUpdate     = "",
        string EngEmpName        = "",
        string CarrierId         = "",
        string CfCarrierId       = "",
        string UnloaderCarrierId = "",
        // デフォルト選択値（工程リストが1件の場合自動セット）
        string DefaultOpId       = "",
        string DefaultStepId     = "",
        string DefaultAltNumber  = "",
        string DefaultWpId       = "",
        string DefaultWpName     = "",
        IReadOnlyList<LotStepInfo>? StepList = null,
        string ErrorCode         = "",
        string ErrorMessage      = ""
    );

    /// <summary>
    /// ロット現在状態を取得する。
    /// VBソース: pubblnLotCurstate_Sel (CtsbasxxCM0050.vb), MsgVer="04.00"
    /// ClassDivision: "10" (CPstrCD10) = 作業開始
    /// フィールド順: CARRIER_ID → SB_ID → CLASS_DIVISION → MSG_VER → LOT_ID
    /// </summary>
    public async Task<LotCurStateResult> GetLotCurStateAsync(
        string carrierId,
        string classDivision = "10",
        string lotId         = "",
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.CarrierId,     carrierId);
        req.AddString(Tags.SbId,          _defaultSbId);
        req.AddString(Tags.ClassDivision, classDivision);
        req.AddString(Tags.MsgVer,        "04.00");
        req.AddString(Tags.LotId,         lotId);  // vbNullString (省略時は空文字)

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotCurState, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotCurState request failed. CarrierId={CarrierId}", carrierId);
            return new LotCurStateResult(false, ErrorMessage: ex.Message);
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var errCode = msg.GetString(Tags.ErrCode);
            var errMsg  = msg.GetString(Tags.ErrMsg);
            logger.LogWarning("LotCurState returned non-TRUE. CarrierId={CarrierId}, ErrCode={ErrCode}, Err={Err}",
                carrierId, errCode, errMsg);
            return new LotCurStateResult(false, ErrorCode: errCode, ErrorMessage: errMsg);
        }

        // 工程リスト（STEP_LIST）解析
        var stepAry = msg.GetMsgAry(Tags.StepList);
        var steps   = new List<LotStepInfo>();
        string defOpId = "", defStepId = "", defAltNumber = "", defWpId = "", defWpName = "";

        foreach (var s in stepAry)
        {
            var opId      = s.GetString(Tags.OpId);
            var stepId    = s.GetString(Tags.StepId);
            var stepDiv   = s.GetString(Tags.StepDivision);
            var altNum    = s.GetString(Tags.AltNumber);

            var wpAry = s.GetMsgAry(Tags.WpList);
            var wps   = wpAry.Select(w => new LotWpInfo(
                WpId:   w.GetString(Tags.WpId),
                WpName: w.GetString(Tags.WpName)
            )).ToList();

            steps.Add(new LotStepInfo(opId, stepId, stepDiv, altNum, wps));

            // デフォルト工程選択（工程フラグ="1": デフォルト、もしくは工程が1件のみ）
            if (defOpId == "" && (stepDiv == "1" || stepAry.Count == 1))
            {
                defOpId      = opId;
                defStepId    = stepId;
                defAltNumber = altNum;
                if (wps.Count == 1)
                {
                    defWpId   = wps[0].WpId;
                    defWpName = wps[0].WpName;
                }
            }
        }

        return new LotCurStateResult(
            IsSuccess:        true,
            LotId:            msg.GetString(Tags.LotId),
            FlowClass:        msg.GetString(Tags.FlowClass),
            PdId:             msg.GetString(Tags.PdId),
            PdName:           msg.GetString(Tags.PdName),
            NowSt:            msg.GetString(Tags.NowSt),
            WfNum:            msg.GetString(Tags.WfNum),
            ChipQuantity:     msg.GetString(Tags.ChipQuantity),
            LimitTime:        msg.GetString(Tags.LimitTime),
            WarnTime:         msg.GetString(Tags.WarnTime),
            StartTime:        msg.GetString(Tags.StartTime),
            Comments:         msg.GetString(Tags.Comments),
            WorkCondition:    msg.GetString(Tags.WorkCondition),
            LotHoldFlag:      msg.GetString(Tags.LotHoldFlag),
            LotLastUpdate:    msg.GetString(Tags.LotLastUpdate),
            EngEmpName:       msg.GetString(Tags.EngEmpName),
            CarrierId:        msg.GetString(Tags.CarrierId),
            CfCarrierId:      msg.GetString(Tags.CfCarrierId),
            UnloaderCarrierId: msg.GetString(Tags.UnloaderCarrierId),
            DefaultOpId:      defOpId,
            DefaultStepId:    defStepId,
            DefaultAltNumber: defAltNumber,
            DefaultWpId:      defWpId,
            DefaultWpName:    defWpName,
            StepList:         steps
        );
    }

    // ──────── ロット作業開始 ─────────────────────────────────────

    /// <summary>
    /// ロット作業開始を登録する。
    /// VBソース: pubblnLotStart_Ins (CtsbasxxCM0050.vb), MsgVer="07.03"
    /// </summary>
    public async Task<WorkStartResult> WorkStartAsync(
        WorkStartRequest request, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,          request.LotId);
        req.AddString(Tags.OpId,           request.OpId);
        req.AddString(Tags.StepId,         request.StepId);
        req.AddString(Tags.WpId,           request.WpId);
        req.AddString(Tags.EmpId,          request.EmpId);
        req.AddString(Tags.LotLastUpdate,  request.LotLastUpdate);
        req.AddString(Tags.Comments,       request.Comments);
        req.AddString(Tags.AltNumber,      request.AltNumber);
        req.AddString(Tags.ToCarrierId,    request.ToCarrierId);
        req.AddString(Tags.CfCarrierId,    request.CfCarrierId);
        req.AddString(Tags.SbId,           _defaultSbId);
        req.AddString(Tags.MsgVer,         request.MsgVer);
        req.AddString(Tags.ClassDivision,  request.ClassDivision);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.WrkStart, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "WrkStart request failed. LotId={LotId}", request.LotId);
            return new WorkStartResult(false, ErrorMessage: ex.Message);
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var errCode = msg.GetString(Tags.ErrCode);
            var errMsg  = msg.GetString(Tags.ErrMsg);
            logger.LogWarning("WrkStart returned non-TRUE. LotId={LotId}, ErrCode={ErrCode}, Err={Err}",
                request.LotId, errCode, errMsg);
            return new WorkStartResult(false, ErrorCode: errCode, ErrorMessage: errMsg);
        }

        return new WorkStartResult(
            IsSuccess:    true,
            ToOpId:       msg.GetString(Tags.ToOpId),
            ToStepId:     msg.GetString(Tags.ToStepId),
            LimitTime:    msg.GetString(Tags.LimitTime),
            WarnTime:     msg.GetString(Tags.WarnTime),
            LotLastUpdate: msg.GetString(Tags.LotLastUpdate)
        );
    }

    // ──────── ロット作業終了 ─────────────────────────────────────

    /// <summary>
    /// ロット作業終了を登録する。
    /// VBソース: pubblnLotWrkend_Upd (CtsbasxxMG0060.vb), MsgVer="04.05"
    /// </summary>
    public async Task<WorkEndResult> WorkEndAsync(
        WorkEndRequest request, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,          request.LotId);
        req.AddString(Tags.OpId,           request.OpId);
        req.AddString(Tags.StepId,         request.StepId);
        req.AddString(Tags.EmpId,          request.EmpId);
        req.AddString(Tags.Comments,       request.Comments);
        req.AddString(Tags.LotLastUpdate,  request.LotLastUpdate);
        req.AddString(Tags.SbId,           _defaultSbId);
        req.AddString(Tags.MsgVer,         request.MsgVer);
        req.AddString(Tags.ClassDivision,  request.ClassDivision);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.WrkEnd, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "WrkEnd request failed. LotId={LotId}", request.LotId);
            return new WorkEndResult(false, ErrorMessage: ex.Message);
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var errCode = msg.GetString(Tags.ErrCode);
            var errMsg  = msg.GetString(Tags.ErrMsg);
            logger.LogWarning("WrkEnd returned non-TRUE. LotId={LotId}, ErrCode={ErrCode}, Err={Err}",
                request.LotId, errCode, errMsg);
            return new WorkEndResult(false, ErrorCode: errCode, ErrorMessage: errMsg);
        }

        var tpAry = msg.GetMsgAry(Tags.TpLotList);
        var tpList = tpAry.Select(t => new TpLot(
            TpLotId:   t.GetString(Tags.TpLotId),
            CarrierId: t.GetString(Tags.CarrierId)
        )).ToList();

        return new WorkEndResult(
            IsSuccess:          true,
            LotId:              msg.GetString(Tags.LotId),
            LotLastUpdate:      msg.GetString(Tags.LotLastUpdate),
            ActionFlag:         msg.GetString(Tags.ActionFlag),
            ResultReworkState:  msg.GetString(Tags.ResultReworkState),
            ElectHoldFlag:      msg.GetString(Tags.ElectHoldFlag),
            MoveResult:         msg.GetString(Tags.MoveResult),
            ToCarrierId:        msg.GetString(Tags.ToCarrierId),
            TftHoldFlag:        msg.GetString(Tags.TftHoldFlag),
            GuidanceMsg:        msg.GetString(Tags.Msg),
            GuidanceMsgCode:    msg.GetString(Tags.MsgCode),
            ExcpHoldFlag:       msg.GetString(Tags.ExcpHoldFlag),
            NormalHoldFlag:     msg.GetString(Tags.NormalHoldFlag),
            TpLotList:          tpList
        );
    }

    // ──────── ロット処理開始 ─────────────────────────────────────

    /// <summary>
    /// ロット処理開始を登録する。
    /// VBソース: pubblnLotPrcstart_Ins (CtsbasxxMG0070.vb), MsgVer="07.00"
    /// </summary>
    public async Task<ProcessStartResult> ProcessStartAsync(
        ProcessStartRequest request, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.ClassDivision, request.ClassDivision);
        req.AddString(Tags.LotId,         request.LotId);
        req.AddString(Tags.OpId,          request.OpId);
        req.AddString(Tags.StepId,        request.StepId);
        req.AddString(Tags.WpId,          request.WpId);
        req.AddString(Tags.PortId,        request.PortId);
        req.AddString(Tags.EmpId,         request.EmpId);
        req.AddString(Tags.LotLastUpdate, request.LotLastUpdate);
        req.AddString(Tags.Comments,      request.Comments);
        req.AddString(Tags.ToPortId,      request.ToPortId);
        req.AddString(Tags.SbId,          _defaultSbId);
        req.AddString(Tags.MsgVer,        request.MsgVer);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.PrcStart, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "PrcStart request failed. LotId={LotId}", request.LotId);
            return new ProcessStartResult(false, ErrorMessage: ex.Message);
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var errCode = msg.GetString(Tags.ErrCode);
            var errMsg  = msg.GetString(Tags.ErrMsg);
            logger.LogWarning("PrcStart returned non-TRUE. LotId={LotId}, ErrCode={ErrCode}, Err={Err}",
                request.LotId, errCode, errMsg);
            return new ProcessStartResult(false, ErrorCode: errCode, ErrorMessage: errMsg);
        }

        return new ProcessStartResult(
            IsSuccess: true,
            ToOpId:    msg.GetString(Tags.ToOpId),
            ToStepId:  msg.GetString(Tags.ToStepId),
            LimitTime: msg.GetString(Tags.LimitTime),
            WarnTime:  msg.GetString(Tags.WarnTime),
            RecipeId:  msg.GetString(Tags.RecipeId),
            PolTime:   msg.GetString(Tags.PolTime),
            PlcResult: msg.GetString(Tags.PlcRecipeCompareResult)
        );
    }

    // ──────── ロット処理終了 ─────────────────────────────────────

    /// <summary>
    /// ロット処理終了を登録する。
    /// VBソース: pubblnLotProcend_Upd (CtsbasxxMG0080.vb), MsgVer="04.00"
    /// </summary>
    public async Task<ProcessEndResult> ProcessEndAsync(
        ProcessEndRequest request, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.ClassDivision, request.ClassDivision);
        req.AddString(Tags.LotId,         request.LotId);
        req.AddString(Tags.EmpId,         request.EmpId);
        req.AddString(Tags.Comments,      request.Comments);
        req.AddString(Tags.LotLastUpdate, request.LotLastUpdate);
        req.AddString(Tags.SbId,          _defaultSbId);
        req.AddString(Tags.MsgVer,        request.MsgVer);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.PrcEnd, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "PrcEnd request failed. LotId={LotId}", request.LotId);
            return new ProcessEndResult(false, ErrorMessage: ex.Message);
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var errCode = msg.GetString(Tags.ErrCode);
            var errMsg  = msg.GetString(Tags.ErrMsg);
            logger.LogWarning("PrcEnd returned non-TRUE. LotId={LotId}, ErrCode={ErrCode}, Err={Err}",
                request.LotId, errCode, errMsg);
            return new ProcessEndResult(false, ErrorCode: errCode, ErrorMessage: errMsg);
        }

        return new ProcessEndResult(
            IsSuccess:      true,
            GuidanceMsg:    msg.GetString(Tags.Msg),
            GuidanceMsgCode: msg.GetString(Tags.MsgCode),
            PlcResult:      msg.GetString(Tags.PlcRecipeCompareResult)
        );
    }

    // ──────── ロット次工程送出 ────────────────────────────────────

    /// <summary>
    /// ロット次工程送出を実行する。
    /// VBソース: pubblnLotNextSend_Upd (CtsbasxxCM0050.vb), MsgVer="03.03"
    /// SendResult: null=次工程送出, "0"=中間在庫, "1"=完成在庫, "2"=組立送品
    /// </summary>
    public async Task<NextSendResult> NextSendAsync(
        string lotId,
        string lotLastUpdate,
        string empId,
        string dividedCheckFlag = "",
        string classDivision    = "",
        string msgVer           = "03.03",
        CancellationToken ct    = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,            lotId);
        req.AddString(Tags.LotLastUpdate,    lotLastUpdate);
        req.AddString(Tags.EmpId,            empId);
        req.AddString(Tags.SbId,             _defaultSbId);
        req.AddString(Tags.MsgVer,           msgVer);
        req.AddString(Tags.ClassDivision,    classDivision);
        req.AddString(Tags.DividedCheckFlag, dividedCheckFlag);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotNextSend, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "NextSend request failed. LotId={LotId}", lotId);
            return new NextSendResult(false, ErrorMessage: ex.Message);
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var errCode = msg.GetString(Tags.ErrCode);
            var errMsg  = msg.GetString(Tags.ErrMsg);
            logger.LogWarning("NextSend returned non-TRUE. LotId={LotId}, ErrCode={ErrCode}, Err={Err}",
                lotId, errCode, errMsg);
            return new NextSendResult(false, ErrorCode: errCode, ErrorMessage: errMsg);
        }

        return new NextSendResult(
            IsSuccess:  true,
            ActionFlag: msg.GetString(Tags.ActionFlag),
            SendResult: msg.GetString(Tags.SendResult),
            Comments:   msg.GetString(Tags.Comments)
        );
    }

    // ──────── ロット次工程取得 ────────────────────────────────────

    /// <summary>
    /// ロット次工程一覧を取得する。
    /// VBソース: pubblnLotNextStepList_Sel (CtsbasxxCM0050.vb), MsgVer="03.01"
    /// NEXT_STEP_LIST → NextOpId/NextStepId/StepDivision/WP_LIST
    /// </summary>
    public async Task<IReadOnlyList<NextStepEntry>> GetNextStepListAsync(
        string lotId,
        string opId,
        string stepId,
        string classDivision = "",
        string routeId       = "",
        string msgVer        = "03.01",
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,         lotId);
        req.AddString(Tags.OpId,          opId);
        req.AddString(Tags.StepId,        stepId);
        req.AddString(Tags.SbId,          _defaultSbId);
        req.AddString(Tags.MsgVer,        msgVer);
        req.AddString(Tags.ClassDivision, classDivision);
        req.AddString(Tags.RouteId,       routeId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotNextStepList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "NextStepList request failed. LotId={LotId}", lotId);
            return [];
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("NextStepList returned non-TRUE. LotId={LotId}, Raw={Raw}",
                lotId, Summarize(raw));
            return [];
        }

        var ary = msg.GetMsgAry(Tags.NextStepList);
        return ary.Select(item =>
        {
            var wpAry = item.GetMsgAry(Tags.WpList);
            var wps = wpAry.Select(w => new WpEntry(
                WpId:   w.GetString(Tags.WpId),
                WpName: w.GetString(Tags.WpName)
            )).ToList();
            return new NextStepEntry(
                NextOpId:      item.GetString(Tags.NextOpId),
                NextStepId:    item.GetString(Tags.NextStepId),
                StepDivision:  item.GetString(Tags.StepDivision),
                WpList:        wps
            );
        }).ToList();
    }

    // ──────── 作業開始取消 ───────────────────────────────────────

    /// <summary>
    /// ロット作業開始取消を登録する。
    /// VBソース: pubblnCancelStart_Upd (CtsbasxxMG0130.vb), MsgVer="03.00"
    /// CancelMode: "0"=作業待ちに戻す, "1"=前処理に戻す
    /// </summary>
    public async Task<CancelStartResult> CancelStartAsync(
        CancelStartRequest request, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,          request.LotId);
        req.AddString(Tags.EmpId,          request.EmpId);
        req.AddString(Tags.CancelMode,     request.CancelMode);
        req.AddString(Tags.Comments,       request.Comments);
        req.AddString(Tags.LotLastUpdate,  request.LotLastUpdate);
        req.AddString(Tags.SbId,           _defaultSbId);
        req.AddString(Tags.MsgVer,         "03.00");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotCnclWrkStart, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "CancelStart request failed. LotId={LotId}", request.LotId);
            return new CancelStartResult(false, ErrorMessage: ex.Message);
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var errCode = msg.GetString(Tags.ErrCode);
            var errMsg  = msg.GetString(Tags.ErrMsg);
            logger.LogWarning("CancelStart returned non-TRUE. LotId={LotId}, ErrCode={ErrCode}, Err={Err}",
                request.LotId, errCode, errMsg);
            return new CancelStartResult(false, ErrorCode: errCode, ErrorMessage: errMsg);
        }

        return new CancelStartResult(
            IsSuccess:        true,
            GuidanceMsg:      msg.GetString(Tags.Msg),
            GuidanceMsgCode:  msg.GetString(Tags.MsgCode)
        );
    }

    // ──────── 内部ヘルパー ────────────────────────────────────────

    private static TfMsg ParseOrEmpty(string? raw)
    {
        var text = (raw ?? string.Empty).Trim();
        if (text.StartsWith("(", StringComparison.Ordinal))
        {
            try { return TfMsg.FromTfString(text); } catch { }
        }
        var empty = new TfMsg();
        empty.AddString(Tags.Ret, Tags.False);
        empty.AddString(Tags.ErrMsg, text.Length > 0 ? text : "空の応答");
        return empty;
    }

    private static string Summarize(string? raw) =>
        (raw ?? string.Empty) is { Length: > 200 } s ? s[..200] + "..." : raw ?? string.Empty;
}
