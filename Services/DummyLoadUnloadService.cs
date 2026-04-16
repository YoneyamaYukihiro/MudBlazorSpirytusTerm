namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN00R0 ダミー Load/Unload/再投入 のサービス。
/// ・キャリア現在状態取得      (carr.curstate)      VBソース: pubblnCarrcurstate_Sel  (CtsbasxxCM0050.vb)
/// ・ダミーキャリア状態変更    (dumy.chgcarrier)    VBソース: pubblnDumyChgCarrier_Upd (CtsbasxxEN00R0.vb)
/// </summary>
public sealed class DummyLoadUnloadService(ITfMessageClient mq, IConfiguration cfg, ILogger<DummyLoadUnloadService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    private const string MsgDumyChgCarrier = "dumy.chgcarrier";
    private const string VerCurrState      = "04.00";
    private const string VerDumyChgCarrier = "01.01";
    private const string CdDumyCheck       = "30";   // CLASS_DIVISION: ダミー確認

    // ──────── 公開型 ────────────────────────────────────────────

    public sealed record CarrierInfo(
        bool   IsSuccess,
        string LotId            = "",
        string CarrierStateName = "",
        string LotLastUpdate    = "",
        string ErrorCode        = "",
        string ErrorMessage     = ""
    );

    public sealed record ExecuteResult(
        bool   IsSuccess,
        string ErrorCode    = "",
        string ErrorMessage = ""
    );

    // ──────── キャリア現在状態取得 (carr.curstate) ──────────────────

    /// <summary>
    /// ダミーキャリアの現在状態を確認する。
    /// VBソース: pubblnCarrcurstate_Sel, MsgVer="04.00", CLASS_DIVISION=CPstrCD30
    /// </summary>
    public async Task<CarrierInfo> GetCarrierStateAsync(
        string carrierId, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.ClassDivision, CdDumyCheck);
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
            logger.LogError(ex, "DummyLU/CarrCurState failed. CarrierId={CarrierId}", carrierId);
            return new CarrierInfo(false, ErrorMessage: $"通信エラー: {ex.Message}");
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = msg.GetErrorInfo();
            logger.LogWarning("DummyLU/CarrCurState returned FALSE. CarrierId={CarrierId}, Code={Code}",
                carrierId, code);
            return new CarrierInfo(false, ErrorCode: code,
                ErrorMessage: string.IsNullOrEmpty(message) ? "キャリア照合に失敗しました。" : message);
        }

        return new CarrierInfo(
            IsSuccess:       true,
            LotId:           msg.GetString(Tags.LotId),
            CarrierStateName: msg.GetString(Tags.CarrierStatName),
            LotLastUpdate:   msg.GetString(Tags.LotLastUpdate)
        );
    }

    // ──────── ダミーキャリア状態変更 (dumy.chgcarrier) ──────────────

    /// <summary>
    /// ダミーキャリアのロード/アンロード/再投入を実行する。
    /// VBソース: pubblnDumyChgCarrier_Upd, MsgVer="01.01"
    /// OperationMode: "LOAD"=ロード, "UNLOAD"=アンロード, "RETRY"=再投入
    /// </summary>
    public async Task<ExecuteResult> ExecuteAsync(
        string carrierId,
        string operationMode,
        string opId,
        string stepId,
        string wpId,
        string portId,
        string empId,
        string comments      = "",
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.CarrierId,     carrierId);
        req.AddString(Tags.ClassDivision, operationMode);
        req.AddString(Tags.OpId,          opId);
        req.AddString(Tags.StepId,        stepId);
        req.AddString(Tags.WpId,          wpId);
        req.AddString(Tags.PortId,        portId);
        req.AddString(Tags.EmpId,         empId);
        req.AddString(Tags.Comments,      comments);
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.MsgVer,        VerDumyChgCarrier);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgDumyChgCarrier, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "DumyChgCarrier failed. CarrierId={CarrierId} Mode={Mode}",
                carrierId, operationMode);
            return new ExecuteResult(false, ErrorMessage: $"通信エラー: {ex.Message}");
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = msg.GetErrorInfo();
            logger.LogWarning("DumyChgCarrier returned FALSE. CarrierId={CarrierId}, Code={Code}",
                carrierId, code);
            return new ExecuteResult(false, ErrorCode: code,
                ErrorMessage: string.IsNullOrEmpty(message) ? "ダミー操作に失敗しました。" : message);
        }

        return new ExecuteResult(true);
    }
}
