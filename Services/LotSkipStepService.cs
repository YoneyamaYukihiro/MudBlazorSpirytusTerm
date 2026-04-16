namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN0250 工程スキップ のサービス。
/// VBソース: VB/0250/CtsfrmxxEN0250.vb, VB/0250/CtsbasxxMG0250.vb
/// </summary>
public sealed class LotSkipStepService(ITfMessageClient mq, IConfiguration cfg, ILogger<LotSkipStepService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 公開型 ────────────────────────────────────────────

    public sealed record WpEntry(string WpId, string WpName);

    /// <summary>
    /// 現工程の1ステップ。lot_.curstate 応答の STEP_LIST 要素。
    /// VBソース: typLotPrestate 内 StepList
    /// </summary>
    public sealed record CurrentStepEntry(
        string OpId,
        string StepId,
        string StepDivision,   // "1"=デフォルト, "0"=代替
        string AltNumber,
        IReadOnlyList<WpEntry> WpList
    );

    /// <summary>
    /// 次工程の1ステップ。lot_.nextsteplist 応答の NEXT_STEP_LIST 要素。
    /// VBソース: typLotNextStep
    /// </summary>
    public sealed record NextStepEntry(
        string NextOpId,
        string NextStepId,
        string StepDivision,   // "1"=デフォルト, "0"=代替
        IReadOnlyList<WpEntry> WpList
    );

    public sealed record LotCurStateResult(
        bool IsSuccess,
        string ErrorCode = "",
        string ErrorMessage = "",
        string LotId = "",
        string OpId = "",
        string StepId = "",
        string PdId = "",
        string PdName = "",
        string NowSt = "",
        string WfNum = "",
        string EngEmpName = "",
        string LotLastUpdate = "",
        IReadOnlyList<CurrentStepEntry>? StepList = null
    );

    public sealed record NextStepListResult(
        bool IsSuccess,
        string ErrorCode = "",
        string ErrorMessage = "",
        IReadOnlyList<NextStepEntry>? StepList = null
    );

    /// <summary>
    /// スキップ可否チェック結果。
    /// VBソース: CMstrChkSkip0=OK, 1=時間制限, 2=号機記憶制限, 3=両方
    /// </summary>
    public sealed record ChkSkipResult(
        bool IsSuccess,
        string ErrorCode = "",
        string ErrorMessage = "",
        string Result = "",    // "0"=OK, "1"=時間制限, "2"=号機記憶, "3"=両方
        string OpId = "",
        string StepId = ""
    );

    public sealed record GetRestrictResult(
        bool IsSuccess,
        string ErrorCode = "",
        string ErrorMessage = "",
        string RestrictTypeId = "",   // "1"=時間, "2"=号機記憶, "3"=両方
        string LimitTime = "",
        string WarnTime = "",
        string FromOpId = "",
        string FromStepId = "",
        string ToOpId = "",
        string ToStepId = ""
    );

    public sealed record SkipStepResult(
        bool IsSuccess,
        string ErrorCode = "",
        string ErrorMessage = "",
        string MsgCode = "",
        string ActionFlag = "",
        string SendResult = ""   // 空=次工程, "0"=中間在庫, "1"=最終在庫, "2"=組立出庫
    );

    // ──────── 現工程情報取得 (lot_.curstate) ─────────────────────

    /// <summary>
    /// キャリアIDからロットの現工程情報を取得する。
    /// lot_.curstate MSG_VER="04.00" CLASS_DIVISION="1C"
    /// VBソース: CMstrlot_curstateVer = "04.00", CPstrCLASS_DIVISION_1C
    /// </summary>
    public async Task<LotCurStateResult> GetLotInfoAsync(
        string carrierId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.MsgVer,        "04.00");
        req.AddString(Tags.ClassDivision, "1C");
        req.AddString(Tags.CarrierId,     carrierId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotCurState, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotCurState(EN0250) failed. CarrierId={Id}", carrierId);
            return new LotCurStateResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = TfMsg.ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = aMsg.GetErrorInfo();
            logger.LogWarning("LotCurState(EN0250) returned FALSE. Err={Err}", message);
            return new LotCurStateResult(false, code, string.IsNullOrEmpty(message) ? "ロット情報の取得に失敗しました。" : message);
        }

        var stepList = aMsg.GetMsgAry(Tags.StepList)
            .Select(e => new CurrentStepEntry(
                OpId:         e.GetString(Tags.OpId),
                StepId:       e.GetString(Tags.StepId),
                StepDivision: e.GetString(Tags.StepDivision),
                AltNumber:    e.GetString(Tags.AltNumber),
                WpList:       e.GetMsgAry(Tags.WpList)
                               .Select(w => new WpEntry(w.GetString(Tags.WpId), w.GetString(Tags.WpName)))
                               .ToList()
            )).ToList();

        return new LotCurStateResult(
            IsSuccess:     true,
            LotId:         aMsg.GetString(Tags.LotId),
            OpId:          aMsg.GetString(Tags.OpId),
            StepId:        aMsg.GetString(Tags.StepId),
            PdId:          aMsg.GetString(Tags.PdId),
            PdName:        aMsg.GetString(Tags.PdName),
            NowSt:         aMsg.GetString(Tags.NowSt),
            WfNum:         aMsg.GetString(Tags.WfNum),
            EngEmpName:    aMsg.GetString(Tags.EngEmpName),
            LotLastUpdate: aMsg.GetString(Tags.LotLastUpdate),
            StepList:      stepList
        );
    }

    // ──────── 次工程一覧取得 (lot_.nextsteplist) ──────────────────

    /// <summary>
    /// 指定ロット・工程の次工程一覧を取得する。
    /// lot_.nextsteplist MSG_VER="03.01"
    /// VBソース: CMstrlot_nextsteplistVer = "03.01"
    /// </summary>
    public async Task<NextStepListResult> GetNextStepsAsync(
        string lotId,
        string opId,
        string stepId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,   _sbId);
        req.AddString(Tags.MsgVer, "03.01");
        req.AddString(Tags.LotId,  lotId);
        req.AddString(Tags.OpId,   opId);
        req.AddString(Tags.StepId, stepId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotNextStepList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotNextStepList(EN0250) failed. LotId={Id}", lotId);
            return new NextStepListResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = TfMsg.ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = aMsg.GetErrorInfo();
            logger.LogWarning("LotNextStepList(EN0250) returned FALSE. Err={Err}", message);
            return new NextStepListResult(false, code, string.IsNullOrEmpty(message) ? "次工程一覧の取得に失敗しました。" : message);
        }

        var stepList = aMsg.GetMsgAry(Tags.NextStepList)
            .Select(e => new NextStepEntry(
                NextOpId:     e.GetString(Tags.NextOpId),
                NextStepId:   e.GetString(Tags.NextStepId),
                StepDivision: e.GetString(Tags.StepDivision),
                WpList:       e.GetMsgAry(Tags.WpList)
                               .Select(w => new WpEntry(w.GetString(Tags.WpId), w.GetString(Tags.WpName)))
                               .ToList()
            )).ToList();

        return new NextStepListResult(true, StepList: stepList);
    }

    // ──────── スキップ可否チェック (lot_.chkskipstep) ─────────────

    /// <summary>
    /// 指定キャリアの工程スキップ可否を確認する。
    /// lot_.chkskipstep MSG_VER="03.00"
    /// VBソース: CMstrlot_chkskipstepVer = "03.00"
    /// 結果: "0"=OK, "1"=時間制限, "2"=号機記憶制限, "3"=両方
    /// </summary>
    public async Task<ChkSkipResult> CheckSkipAsync(
        string carrierId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,      _sbId);
        req.AddString(Tags.MsgVer,    "03.00");
        req.AddString(Tags.CarrierId, carrierId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotChkSkipStep, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotChkSkipStep failed. CarrierId={Id}", carrierId);
            return new ChkSkipResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = TfMsg.ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = aMsg.GetErrorInfo();
            logger.LogWarning("LotChkSkipStep returned FALSE. Err={Err}", message);
            return new ChkSkipResult(false, code, string.IsNullOrEmpty(message) ? "スキップ可否チェックに失敗しました。" : message);
        }

        return new ChkSkipResult(
            IsSuccess: true,
            Result:    aMsg.GetString(Tags.Result),
            OpId:      aMsg.GetString(Tags.OpId),
            StepId:    aMsg.GetString(Tags.StepId)
        );
    }

    // ──────── 時間制限情報取得 (lot_.getrestrict) ──────────────────

    /// <summary>
    /// ロットの時間制限情報を取得する。
    /// lot_.getrestrict MSG_VER="01.00"
    /// VBソース: CMstrlot_getrestrictVer = "01.00"
    /// 制限タイプなし(空)のときは制限なし。
    /// </summary>
    public async Task<GetRestrictResult> GetRestrictAsync(
        string lotId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,   _sbId);
        req.AddString(Tags.MsgVer, "01.00");
        req.AddString(Tags.LotId,  lotId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotGetRestrict, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotGetRestrict failed. LotId={Id}", lotId);
            return new GetRestrictResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = TfMsg.ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = aMsg.GetErrorInfo();
            logger.LogWarning("LotGetRestrict returned FALSE. Err={Err}", message);
            return new GetRestrictResult(false, code, string.IsNullOrEmpty(message) ? "時間制限情報の取得に失敗しました。" : message);
        }

        return new GetRestrictResult(
            IsSuccess:      true,
            RestrictTypeId: aMsg.GetString(Tags.RestrictTypeId),
            LimitTime:      aMsg.GetString(Tags.LimitTime),
            WarnTime:       aMsg.GetString(Tags.WarnTime),
            FromOpId:       aMsg.GetString(Tags.FromOpId),
            FromStepId:     aMsg.GetString(Tags.FromStepId),
            ToOpId:         aMsg.GetString(Tags.ToOpId),
            ToStepId:       aMsg.GetString(Tags.ToStepId)
        );
    }

    // ──────── 工程スキップ実行 (lot_.skipstep) ────────────────────

    /// <summary>
    /// 工程スキップを実行する。
    /// lot_.skipstep MSG_VER="02.00"
    /// VBソース: CMstrlot_skipstepVer = "02.00"
    /// </summary>
    public async Task<SkipStepResult> ExecuteSkipAsync(
        string lotId,
        string opId,
        string stepId,
        string lotLastUpdate,
        string empId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.MsgVer,        "02.00");
        req.AddString(Tags.LotId,         lotId);
        req.AddString(Tags.OpId,          opId);
        req.AddString(Tags.StepId,        stepId);
        req.AddString(Tags.LotLastUpdate, lotLastUpdate);
        req.AddString(Tags.EmpId,         empId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotSkipStep, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotSkipStep failed. LotId={Id}", lotId);
            return new SkipStepResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = TfMsg.ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = aMsg.GetErrorInfo();
            var msgCode = aMsg.GetString(Tags.MsgCode);
            logger.LogWarning("LotSkipStep returned FALSE. MsgCode={MsgCode}, Err={Err}", msgCode, message);
            return new SkipStepResult(false, code, string.IsNullOrEmpty(message) ? "工程スキップに失敗しました。" : message, msgCode);
        }

        return new SkipStepResult(
            IsSuccess:  true,
            ActionFlag: aMsg.GetString(Tags.ActionFlag),
            SendResult: aMsg.GetString(Tags.SendResult)
        );
    }

    // ──────── 内部ヘルパー ────────────────────────────────────────
}
