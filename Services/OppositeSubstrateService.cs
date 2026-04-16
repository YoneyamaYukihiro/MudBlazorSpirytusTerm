namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN00H0 対向基板処置登録 のサービス。
/// ・キャリア現在状態取得      (carr.curstate)    VBソース: pubblnCarrcurstate_Sel  (CtsbasxxCM0050.vb)
/// ・対向基板処置登録          (opp_.dispose_)    VBソース: pubblnOppDispose_Ins   (CtsbasxxEN00H0.vb)
/// </summary>
public sealed class OppositeSubstrateService(ITfMessageClient mq, IConfiguration cfg, ILogger<OppositeSubstrateService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    private const string MsgOppDispose  = "opp_.dispose_";
    private const string VerCurrState   = "04.00";
    private const string VerOppDispose  = "01.00";
    private const string CdOppDispose   = "10";   // CLASS_DIVISION

    // ──────── 公開型 ────────────────────────────────────────────

    public sealed record LotInfo(
        bool   IsSuccess,
        string LotId         = "",
        string PdId          = "",
        string NowSt         = "",
        string WfNum         = "",
        string LotLastUpdate = "",
        string ErrorCode     = "",
        string ErrorMessage  = ""
    );

    public sealed record DisposeResult(
        bool   IsSuccess,
        string ErrorCode    = "",
        string ErrorMessage = ""
    );

    // ──────── キャリア現在状態取得 (carr.curstate) ──────────────────

    /// <summary>
    /// 対向基板のキャリア現在状態を取得する。
    /// VBソース: pubblnCarrcurstate_Sel, MsgVer="04.00"
    /// </summary>
    public async Task<LotInfo> GetCarrierStateAsync(
        string carrierId, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.ClassDivision, CdOppDispose);
        req.AddString(Tags.MsgVer,        VerCurrState);
        req.AddString(Tags.CarrierId,     carrierId);
        req.AddString(Tags.CarrierTypeId, "");
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.LotId,         "");
        req.AddString(Tags.OpId,          "");
        req.AddString(Tags.StepId,        "");
        req.AddString(Tags.AltNumber,     "");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.CarrCurState, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "OppSubstrate/CarrCurState failed. CarrierId={CarrierId}", carrierId);
            return new LotInfo(false, ErrorMessage: $"通信エラー: {ex.Message}");
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = msg.GetErrorInfo();
            logger.LogWarning("OppSubstrate/CarrCurState returned FALSE. CarrierId={CarrierId}, Code={Code}",
                carrierId, code);
            return new LotInfo(false, ErrorCode: code,
                ErrorMessage: string.IsNullOrEmpty(message) ? "キャリア照合に失敗しました。" : message);
        }

        return new LotInfo(
            IsSuccess:    true,
            LotId:        msg.GetString(Tags.LotId),
            PdId:         msg.GetString(Tags.PdId),
            NowSt:        msg.GetString(Tags.NowSt),
            WfNum:        msg.GetString(Tags.WfNum),
            LotLastUpdate: msg.GetString(Tags.LotLastUpdate)
        );
    }

    // ──────── 対向基板処置登録 (opp_.dispose_) ──────────────────────

    /// <summary>
    /// 対向基板処置を登録する。
    /// VBソース: pubblnOppDispose_Ins, MsgVer="01.00"
    /// DispositionCode: "01"=廃棄, "02"=再利用, "03"=保管, "04"=返却
    /// </summary>
    public async Task<DisposeResult> RegisterAsync(
        string lotId,
        string carrierId,
        string substrateType,
        string dispositionCode,
        string empId,
        string dispositionWfNum,
        string comments         = "",
        string lotLastUpdate    = "",
        CancellationToken ct    = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,           lotId);
        req.AddString(Tags.CarrierId,        carrierId);
        req.AddString("SUBSTRATE_TYPE",      substrateType);
        req.AddString("DISPOSITION_CODE",    dispositionCode);
        req.AddString(Tags.EmpId,            empId);
        req.AddString("DISPOSITION_WF_NUM",  dispositionWfNum);
        req.AddString(Tags.Comments,         comments);
        req.AddString(Tags.LotLastUpdate,    lotLastUpdate);
        req.AddString(Tags.SbId,             _sbId);
        req.AddString(Tags.MsgVer,           VerOppDispose);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgOppDispose, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "OppDispose failed. LotId={LotId}", lotId);
            return new DisposeResult(false, ErrorMessage: $"通信エラー: {ex.Message}");
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = msg.GetErrorInfo();
            logger.LogWarning("OppDispose returned FALSE. LotId={LotId}, Code={Code}", lotId, code);
            return new DisposeResult(false, ErrorCode: code,
                ErrorMessage: string.IsNullOrEmpty(message) ? "対向基板処置の登録に失敗しました。" : message);
        }

        return new DisposeResult(true);
    }
}
