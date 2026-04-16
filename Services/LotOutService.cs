namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN0170 ロット終了(ロットアウト) のサービス。
/// VBソース: VB/0170/CtsfrmxxEN0170.vb, VB/0170/CtsbasxxMG0170.vb
/// </summary>
public sealed class LotOutService(ITfMessageClient mq, IConfiguration cfg, ILogger<LotOutService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── メッセージID定数 ────────────────────────────────────
    // VBソース: CPstrlot_terminate (CtsbasxxCM0010.vb 262行)
    private const string MsgLotTerminate = "lot_.terminate";

    // ──────── タグ定数 ────────────────────────────────────────────
    // VBソース: CPstrRESPONSIBLE_EMP_ID (CtsbasxxCM0010.vb 1480行)
    private const string TagResponsibleEmpId = "RESPONSIBLE_EMP_ID";

    // ──────── 公開型 ────────────────────────────────────────────

    /// <summary>
    /// ロット現在状態取得結果。
    /// VBソース: CMstrlot_curstateVer = "04.00", CLASS_DIVISION = CPstrCD1E = "1E"
    /// </summary>
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
        string LotLastUpdate = "",
        string FlowClass = ""
    );

    /// <summary>
    /// ロット終了実行結果。
    /// VBソース: pubblnLotTerminate_Upd (CtsbasxxMG0170.vb)
    /// </summary>
    public sealed record LotTerminateResult(
        bool IsSuccess,
        string ErrorMessage = "",
        string MsgCode = ""
    );

    // ──────── 現工程情報取得 (lot_.curstate) ─────────────────────

    /// <summary>
    /// キャリアIDからロットの現工程情報を取得する。
    /// lot_.curstate MSG_VER="04.00" CLASS_DIVISION="1E"
    /// VBソース: CMstrlot_curstateVer = "04.00", CPstrCD1E = "1E"
    /// </summary>
    public async Task<LotCurStateResult> GetLotInfoAsync(
        string carrierId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.MsgVer,        "04.00");
        req.AddString(Tags.ClassDivision, "1E");
        req.AddString(Tags.CarrierId,     carrierId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotCurState, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotCurState(EN0170) failed. CarrierId={Id}", carrierId);
            return new LotCurStateResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var err = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            logger.LogWarning("LotCurState(EN0170) returned FALSE. Err={Err}", err);
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
            LotLastUpdate: aMsg.GetString(Tags.LotLastUpdate),
            FlowClass:     aMsg.GetString(Tags.FlowClass)
        );
    }

    // ──────── ロット終了実行 (lot_.terminate) ─────────────────────

    /// <summary>
    /// ロット終了を実行する。
    /// lot_.terminate MSG_VER="03.01" CLASS_DIVISION="1E"
    /// VBソース: CMstrlot_terminateVer = "03.01", pubblnLotTerminate_Upd
    ///
    /// CLASS (終了区分): "2"=不良(Scrap), "3"=払出(Take), "4"=保留(Hold)
    /// REASON_CODE: 終了理由コードID
    /// RESPONSIBLE_EMP_ID: 終了責任者ID
    /// EMP_ID: 作業者ID
    /// COMMENTS: 作業メモ
    /// LOT_LAST_UPDATE: 最終更新日時
    /// </summary>
    public async Task<LotTerminateResult> ExecuteTerminateAsync(
        string lotId,
        string endClass,        // "2"=不良, "3"=払出, "4"=保留
        string reasonCode,
        string responsibleEmpId,
        string empId,
        string lotLastUpdate,
        string comments = "",
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,           lotId);
        req.AddString(Tags.ClassDivision,   "1E");
        req.AddString(Tags.Class,           endClass);
        req.AddString(Tags.ReasonCode,      reasonCode);
        req.AddString(Tags.Comments,        comments);
        req.AddString(TagResponsibleEmpId,  responsibleEmpId);
        req.AddString(Tags.EmpId,           empId);
        req.AddString(Tags.LotLastUpdate,   lotLastUpdate);
        req.AddString(Tags.SbId,            _sbId);
        req.AddString(Tags.MsgVer,          "03.01");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgLotTerminate, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotTerminate(EN0170) failed. LotId={Id}", lotId);
            return new LotTerminateResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var msgCode = aMsg.GetString(Tags.MsgCode);
            var err     = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            logger.LogWarning("LotTerminate(EN0170) returned FALSE. MsgCode={MsgCode}, Err={Err}", msgCode, err);
            return new LotTerminateResult(false, string.IsNullOrEmpty(err) ? "ロット終了に失敗しました。" : err, msgCode);
        }

        return new LotTerminateResult(true);
    }

    // ──────── 内部ヘルパー ────────────────────────────────────────

    private static TfMsg ParseOrEmpty(string? raw)
    {
        var text = (raw ?? string.Empty).Trim();
        if (text.StartsWith("(", StringComparison.Ordinal))
        {
            try { return TfMsg.FromTfString(text); } catch { }
        }
        var e = new TfMsg();
        e.AddString(Tags.Ret,    Tags.False);
        e.AddString(Tags.ErrMsg, text.Length > 0 ? text : "空の応答");
        return e;
    }
}
