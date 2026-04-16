namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN00E0 CFKI作業終了 のサービス。
/// ・ロット現在状態取得  (lot_.curstate)   VBソース: pubblnLotCurstate_Sel (CtsbasxxCM0050.vb)
/// ・CFKI作業終了登録   (lot_.cfkiend__)  VBソース: pubblnCfkiEnd_Upd (CtsbasxxEN00E0.vb)
/// </summary>
public sealed class CfkiWorkEndService(ITfMessageClient mq, IConfiguration cfg, ILogger<CfkiWorkEndService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    private const string MsgCfkiEnd    = "lot_.cfkiend__";
    private const string VerCurState   = "04.00";
    private const string VerCfkiEnd    = "01.00";
    private const string CdCfkiWork    = "60";   // CLASS_DIVISION: CFKI作業終了

    // ──────── 公開型 ────────────────────────────────────────────

    public sealed record LotInfo(
        bool   IsSuccess,
        string LotId          = "",
        string PdId           = "",
        string NowSt          = "",
        string OpId           = "",
        string StepId         = "",
        string CfkiClass      = "",   // CF_FLAG: "1"=CF, "0"=KI
        string LotLastUpdate  = "",
        string ErrorCode      = "",
        string ErrorMessage   = ""
    );

    public sealed record WorkEndResult(
        bool   IsSuccess,
        string GuidanceMsg     = "",
        string GuidanceMsgCode = "",
        string ErrorCode       = "",
        string ErrorMessage    = ""
    );

    // ──────── ロット現在状態取得 (lot_.curstate) ────────────────────

    /// <summary>
    /// CFKI用ロット現在状態を取得する。
    /// VBソース: pubblnLotCurstate_Sel, MsgVer="04.00", CLASS_DIVISION=CPstrCD60
    /// </summary>
    public async Task<LotInfo> GetLotInfoAsync(
        string carrierId, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.CarrierId,     carrierId);
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.ClassDivision, CdCfkiWork);
        req.AddString(Tags.MsgVer,        VerCurState);
        req.AddString(Tags.LotId,         "");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotCurState, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "CfkiWorkEnd/LotCurState failed. CarrierId={CarrierId}", carrierId);
            return new LotInfo(false, ErrorMessage: $"通信エラー: {ex.Message}");
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = msg.GetErrorInfo();
            logger.LogWarning("CfkiWorkEnd/LotCurState returned FALSE. CarrierId={CarrierId}, Code={Code}",
                carrierId, code);
            return new LotInfo(false, ErrorCode: code,
                ErrorMessage: string.IsNullOrEmpty(message) ? "ロット照合に失敗しました。" : message);
        }

        // 工程リストから最初の工程を取得
        var stepAry = msg.GetMsgAry(Tags.StepList);
        var opId    = "";
        var stepId  = "";
        if (stepAry.Count > 0)
        {
            opId   = stepAry[0].GetString(Tags.OpId);
            stepId = stepAry[0].GetString(Tags.StepId);
        }

        return new LotInfo(
            IsSuccess:    true,
            LotId:        msg.GetString(Tags.LotId),
            PdId:         msg.GetString(Tags.PdId),
            NowSt:        msg.GetString(Tags.NowSt),
            OpId:         opId,
            StepId:       stepId,
            CfkiClass:    msg.GetString(Tags.CfFlag) == "1" ? "CF" : "KI",
            LotLastUpdate: msg.GetString(Tags.LotLastUpdate)
        );
    }

    // ──────── CFKI作業終了 (lot_.cfkiend__) ─────────────────────────

    /// <summary>
    /// CFKI作業終了を登録する。
    /// VBソース: pubblnCfkiEnd_Upd, MsgVer="01.00"
    /// </summary>
    public async Task<WorkEndResult> WorkEndAsync(
        string lotId,
        string opId,
        string stepId,
        string empId,
        string lotLastUpdate,
        string resultWfNum,
        string comments      = "",
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,         lotId);
        req.AddString(Tags.OpId,          opId);
        req.AddString(Tags.StepId,        stepId);
        req.AddString(Tags.EmpId,         empId);
        req.AddString(Tags.LotLastUpdate, lotLastUpdate);
        req.AddString(Tags.WfNum,         resultWfNum);
        req.AddString(Tags.Comments,      comments);
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.MsgVer,        VerCfkiEnd);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgCfkiEnd, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "CfkiEnd failed. LotId={LotId}", lotId);
            return new WorkEndResult(false, ErrorMessage: $"通信エラー: {ex.Message}");
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = msg.GetErrorInfo();
            logger.LogWarning("CfkiEnd returned FALSE. LotId={LotId}, Code={Code}", lotId, code);
            return new WorkEndResult(false, ErrorCode: code,
                ErrorMessage: string.IsNullOrEmpty(message) ? "CFKI作業終了の登録に失敗しました。" : message);
        }

        return new WorkEndResult(
            IsSuccess:      true,
            GuidanceMsg:    msg.GetString(Tags.Msg),
            GuidanceMsgCode: msg.GetString(Tags.MsgCode)
        );
    }
}
