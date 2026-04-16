namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN0150 装置別ロット一覧のロット操作系メッセージサービス。
/// ・処理順号機設定解除 (lot_.chgctlwp)
/// ・ダミーキャリア払出   (dumy.carout__)
/// VBソース: pubblnLotchgctlwp_Upd / pubblnDumyCarOut_Upd (CtsbasxxMG0150.vb)
/// </summary>
public sealed class LotActionService(ITfMessageClient mq, IConfiguration cfg, ILogger<LotActionService> logger)
{
    private readonly string _defaultSbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 公開型 ────────────────────────────────────────────

    /// <summary>処理順号機設定解除要求。VBソース: Chgctlwp 構造体</summary>
    public sealed record ChangeControlWpRequest(
        string WpId,
        string LotId,
        string OpId,
        string StepId,
        /// <summary>設定/解除フラグ (VBソース: CPstrKIND_FLAG)</summary>
        string KindFlag,
        string AltNumber,
        string LotLastUpdate,
        string MsgVer = "03.00"
    );

    /// <summary>処理順号機設定解除結果</summary>
    public sealed record ChangeControlWpResult(
        bool IsSuccess,
        string GuidanceMsg = "",
        string GuidanceMsgCode = "",
        string ErrorCode = "",
        string ErrorMessage = ""
    );

    // ──────── 処理順号機設定解除 ────────────────────────────────

    /// <summary>
    /// 処理順号機設定解除を実行する。
    /// VBソース: CPstrlot_chgctlwp, Ver="03.00"
    /// </summary>
    public async Task<ChangeControlWpResult> ChangeControlWpAsync(
        ChangeControlWpRequest request, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,        request.MsgVer);
        req.AddString(Tags.SbId,          _defaultSbId);
        req.AddString(Tags.WpId,          request.WpId);
        req.AddString(Tags.LotId,         request.LotId);
        req.AddString(Tags.OpId,          request.OpId);
        req.AddString(Tags.StepId,        request.StepId);
        req.AddString(Tags.KindFlag,      request.KindFlag);
        req.AddString(Tags.AltNumber,     request.AltNumber);
        req.AddString(Tags.LotLastUpdate, request.LotLastUpdate);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotChgCtlwp, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotChgCtlwp request failed. LotId={LotId}", request.LotId);
            return new ChangeControlWpResult(false, ErrorMessage: ex.Message);
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        var ret = msg.GetString(Tags.Ret);

        if (ret != Tags.True)
        {
            var (code, message) = msg.GetErrorInfo();
            logger.LogWarning("LotChgCtlwp returned non-TRUE. LotId={LotId}, Err={Err}",
                request.LotId, message);
            return new ChangeControlWpResult(false, ErrorCode: code, ErrorMessage: message);
        }

        return new ChangeControlWpResult(
            IsSuccess:       true,
            GuidanceMsg:     msg.GetString(Tags.Msg),
            GuidanceMsgCode: msg.GetString(Tags.MsgCode)
        );
    }

    // ──────── ダミーキャリア払出 ────────────────────────────────

    /// <summary>
    /// ダミーキャリアの払出要求を送信する。
    /// VBソース: CPstrdumycarout__, Ver="01.00"
    /// </summary>
    public async Task<bool> DummyCarOutAsync(
        string wpId,
        string carrierId,
        string lotLastUpdate,
        string empId = "",
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,        "01.00");
        req.AddString(Tags.WpId,          wpId);
        req.AddString(Tags.CarrierId,     carrierId);
        req.AddString(Tags.EmpId,         empId);
        req.AddString(Tags.LotLastUpdate, lotLastUpdate);
        req.AddString(Tags.SbId,          _defaultSbId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.DumyCarOut, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "DumyCarOut request failed. WpId={WpId}, CarrierId={CarrierId}",
                wpId, carrierId);
            return false;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("DumyCarOut returned non-TRUE. CarrierId={CarrierId}, Raw={Raw}",
                carrierId, Summarize(raw));
            return false;
        }

        return true;
    }

    // ──────── 内部ヘルパー ────────────────────────────────────────
    private static string Summarize(string? raw) =>
        (raw ?? string.Empty) is { Length: > 200 } s ? s[..200] + "..." : raw ?? string.Empty;
}
