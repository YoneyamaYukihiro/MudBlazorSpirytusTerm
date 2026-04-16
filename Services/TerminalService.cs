namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// 端末設定情報の取得・登録サービス。
/// VBソース: pubblnUtilRefTmInfo_Sel / pubblnUtilRegTmInfo_Upd (CtsbasxxCM0050.vb)
/// </summary>
public sealed class TerminalService(ITfMessageClient mq, IConfiguration cfg, ILogger<TerminalService> logger)
{
    private readonly string _defaultSbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 公開型 ────────────────────────────────────────────

    /// <summary>端末設定情報。VBソース: UtilRefTmInfo 構造体</summary>
    public sealed record TerminalInfo(
        string WpId,
        string McGroupId,
        string OpId,
        string StepId,
        string CarrierTypeId
    );

    // ──────── 端末設定情報取得 ────────────────────────────────────

    /// <summary>
    /// 端末設定情報（デフォルト装置IDなど）を取得する。
    /// VBソース: MsgVer="01.00", CPstrutilreftminfo
    /// </summary>
    public async Task<TerminalInfo?> GetTerminalInfoAsync(
        string hostName, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.HostName, hostName);
        req.AddString(Tags.MsgVer, "01.00");
        req.AddString(Tags.SbId, _defaultSbId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.UtilRefTmInfo, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "UtilRefTmInfo request failed. HostName={HostName}", hostName);
            return null;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("UtilRefTmInfo returned non-TRUE. HostName={HostName}, Raw={Raw}",
                hostName, Summarize(raw));
            return null;
        }

        return new TerminalInfo(
            WpId:          msg.GetString(Tags.CurrentWpId),
            McGroupId:     msg.GetString(Tags.McGroupId),
            OpId:          msg.GetString(Tags.OpId),
            StepId:        msg.GetString(Tags.StepId),
            CarrierTypeId: msg.GetString(Tags.CarrierTypeId)
        );
    }

    // ──────── 端末設定情報登録 ────────────────────────────────────

    /// <summary>
    /// 端末設定情報（選択中の装置IDなど）を登録する。
    /// VBソース: MsgVer="01.00", ClassDivision="26"(装置別ロット一覧), CPstrutilregtminfo
    /// </summary>
    public async Task<bool> SaveTerminalInfoAsync(
        string classDivision,
        string hostName,
        string wpId,
        string mcGroupId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId, _defaultSbId);
        req.AddString(Tags.ClassDivision, classDivision);
        req.AddString(Tags.HostName, hostName);
        req.AddString(Tags.WpId, wpId);
        req.AddString(Tags.McGroupId, mcGroupId);
        req.AddString(Tags.MsgVer, "01.00");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.UtilRegTmInfo, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "UtilRegTmInfo request failed. WpId={WpId}", wpId);
            return false;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("UtilRegTmInfo returned non-TRUE. WpId={WpId}, Raw={Raw}",
                wpId, Summarize(raw));
            return false;
        }

        return true;
    }

    // ──────── 内部ヘルパー ────────────────────────────────────────
    private static string Summarize(string? raw) =>
        (raw ?? string.Empty) is { Length: > 200 } s ? s[..200] + "..." : raw ?? string.Empty;
}
