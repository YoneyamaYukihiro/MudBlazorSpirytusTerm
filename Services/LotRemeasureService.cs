namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN01B0 ロット再測定 のサービス。
/// VBソース: VB/01B0/CtsfrmxxEN01B0.vb, VB/01B0/CtsbasxxMG01B0.vb
///           VB/COMN/CtsbasxxCM0050.vb (pubblnLotCurstate_Sel)
/// </summary>
public sealed class LotRemeasureService(ITfMessageClient mq, IConfiguration cfg, ILogger<LotRemeasureService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── メッセージIDバージョン ──────────────────────────────────────
    // VBソース: CMstrlot_curstateVer = "04.00"
    private const string LotCurStateVer    = "04.00";
    // VBソース: CMstrlot_steprestartVer = "02.00"
    private const string LotStepRestartVer = "02.00";

    // ──────── CLASS_DIVISION 定数 ─────────────────────────────────────────
    // VBソース: CPstrCD1R = "1R" (ロット再測定)
    private const string ClassDivision1R = "1R";

    // ──────── 公開型 ─────────────────────────────────────────────────────

    public sealed record LotCurStateResult(
        bool IsSuccess,
        string ErrorMessage = "",
        string LotId = "",
        string OpId = "",
        string StepId = "",
        string PdId = "",
        string PdName = "",
        string NowSt = "",
        string WfNum = "",
        string EngEmpName = "",
        string LotLastUpdate = ""
    );

    public sealed record RemeasureResult(
        bool IsSuccess,
        string ErrorMessage = "",
        string GuidMsg = "",
        string GuidMsgCode = ""
    );

    // ──────── ロット現在状態取得 (lot_.curstate) ───────────────────────

    /// <summary>
    /// キャリアIDからロット再測定用のロット情報を取得する。
    /// lot_.curstate MSG_VER="04.00" CLASS_DIVISION="1R"
    /// VBソース: CMstrlot_curstateVer = "04.00", CPstrCD1R = "1R"
    /// </summary>
    public async Task<LotCurStateResult> GetLotInfoAsync(
        string carrierId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.MsgVer,        LotCurStateVer);
        req.AddString(Tags.ClassDivision, ClassDivision1R);
        req.AddString(Tags.CarrierId,     carrierId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotCurState, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotCurState(EN01B0) failed. CarrierId={Id}", carrierId);
            return new LotCurStateResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = TfMsg.ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var err = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            logger.LogWarning("LotCurState(EN01B0) returned FALSE. Err={Err}", err);
            return new LotCurStateResult(false, string.IsNullOrEmpty(err) ? "ロット情報の取得に失敗しました。" : err);
        }

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
            LotLastUpdate: aMsg.GetString(Tags.LotLastUpdate)
        );
    }

    // ──────── ロット再測定登録 (lot_.steprestart) ─────────────────────

    /// <summary>
    /// ロット再測定を登録する。
    /// lot_.steprestart MSG_VER="02.00"
    /// VBソース: CMstrlot_steprestartVer = "02.00"
    ///           pubblnLotStepRestart_Upd(CMstrlot_steprestartVer, ltypLotStepRestart, lstrGuidMsg, lstrGuidMsgCode)
    /// 成功時: GuidMsg (MSG), GuidMsgCode (MSG_CODE) を返す。
    /// </summary>
    public async Task<RemeasureResult> ExecuteRemeasureAsync(
        string lotId,
        string empId,
        string lotLastUpdate,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.MsgVer,        LotStepRestartVer);
        req.AddString(Tags.LotId,         lotId);
        req.AddString(Tags.EmpId,         empId);
        req.AddString(Tags.LotLastUpdate, lotLastUpdate);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotStepRestart, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotStepRestart failed. LotId={Id}", lotId);
            return new RemeasureResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = TfMsg.ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var err = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            logger.LogWarning("LotStepRestart returned FALSE. Err={Err}", err);
            return new RemeasureResult(false, string.IsNullOrEmpty(err) ? "ロット再測定登録に失敗しました。" : err);
        }

        return new RemeasureResult(
            IsSuccess:    true,
            GuidMsg:      aMsg.GetString(Tags.Msg),
            GuidMsgCode:  aMsg.GetString(Tags.MsgCode)
        );
    }

    // ──────── 内部ヘルパー ──────────────────────────────────────────────
}
