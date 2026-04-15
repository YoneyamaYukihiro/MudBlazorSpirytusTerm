namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// メインメニュー関連サービス。
/// ・メニューお気に入り取得  (util.refmenu_)   VBソース: pubblnUtilRefMenuFavor_Sel (CtsbasxxMG0000.vb)
/// ・メニューお知らせ取得   (util.information) VBソース: pubblnUtilInformation_Sel  (CtsbasxxMG0000.vb)
/// </summary>
public sealed class MenuService(ITfMessageClient mq, IConfiguration cfg, ILogger<MenuService> logger)
{
    private readonly string _defaultSbId     = cfg["Spirytus:DefaultSbId"]     ?? string.Empty;
    /// <summary>流動系タブ LOGIN_ID。VBソース: CMstrMenuIdFlow = "MENUFLOW"</summary>
    private readonly string _menuFlowLoginId = cfg["Spirytus:MenuFlowLoginId"] ?? string.Empty;
    /// <summary>ツール系タブ LOGIN_ID。VBソース: CMstrMenuIdTool = "MENUTOOL"</summary>
    private readonly string _menuToolLoginId = cfg["Spirytus:MenuToolLoginId"] ?? string.Empty;
    /// <summary>MENU_KIND。VBソース: pstrSBID & ";" & pstrTerminalMode (例: "1A0;A")</summary>
    private readonly string _menuKind        = cfg["Spirytus:MenuKind"]        ?? string.Empty;

    // ──────── 公開型 ────────────────────────────────────────────

    /// <summary>お気に入りエントリ。VBソース: FavoriteList 構造体</summary>
    public sealed record FavoriteEntry(string SeqNum, string FunctionId);

    /// <summary>お気に入り取得結果</summary>
    public sealed record FavoritesResult(
        bool   IsSuccess,
        string TakingOverFlag             = "",
        IReadOnlyList<FavoriteEntry>? List = null,
        string ErrorCode                  = "",
        string ErrorMessage               = ""
    );

    /// <summary>お知らせ取得結果</summary>
    public sealed record InformationResult(
        bool   IsSuccess,
        string Text         = "",
        string ErrorCode    = "",
        string ErrorMessage = ""
    );

    // ──────── お気に入り取得 (流動系 / ツール系) ───────────────────

    /// <summary>
    /// 流動系お気に入りリストを取得する。(CPlngMenuTabFlow = 0)
    /// LOGIN_ID = Spirytus:MenuFlowLoginId (例: "MENUFLOW")
    /// </summary>
    public Task<FavoritesResult> GetFlowFavoritesAsync(CancellationToken ct = default)
        => GetFavoritesAsync(_menuFlowLoginId, ct);

    /// <summary>
    /// ツール系お気に入りリストを取得する。(CPlngMenuTabTool = 1)
    /// LOGIN_ID = Spirytus:MenuToolLoginId (例: "MENUTOOL")
    /// </summary>
    public Task<FavoritesResult> GetToolFavoritesAsync(CancellationToken ct = default)
        => GetFavoritesAsync(_menuToolLoginId, ct);

    /// <summary>
    /// お気に入りリストを取得する内部実装。
    /// VBソース: pubblnUtilRefMenuFavor_Sel (CtsbasxxMG0000.vb), MsgVer="01.00"
    /// 送信: LOGIN_ID / MENU_KIND (Spirytus:MenuKind) / MSG_VER
    /// 受信: TAKING_OVER_FLAG / FAVORITE_LIST[SEQ_NUM, FUNCTION_ID]
    /// </summary>
    private async Task<FavoritesResult> GetFavoritesAsync(string loginId, CancellationToken ct)
    {
        var req = new TfMsg();
        req.AddString(Tags.LoginId,  loginId);
        req.AddString(Tags.MenuKind, _menuKind);
        req.AddString(Tags.MsgVer,   "01.00");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.UtilRefMenu, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "UtilRefMenu request failed. LoginId={LoginId}", loginId);
            return new FavoritesResult(false, ErrorMessage: ex.Message);
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var errCode = msg.GetString(Tags.ErrCode);
            var errMsg  = msg.GetString(Tags.ErrMsg);
            logger.LogWarning("UtilRefMenu returned non-TRUE. LoginId={LoginId}, ErrCode={ErrCode}, Err={Err}",
                loginId, errCode, errMsg);
            return new FavoritesResult(false, ErrorCode: errCode, ErrorMessage: errMsg);
        }

        var ary = msg.GetMsgAry(Tags.FavoriteList);
        var list = ary
            .Select(e => new FavoriteEntry(
                SeqNum:     e.GetString(Tags.SeqNum),
                FunctionId: e.GetString(Tags.FunctionId)))
            .Where(e => !string.IsNullOrEmpty(e.FunctionId))
            .OrderBy(e => int.TryParse(e.SeqNum, out var n) ? n : int.MaxValue)
            .ToList();

        return new FavoritesResult(
            IsSuccess:      true,
            TakingOverFlag: msg.GetString(Tags.TakingOverFlag),
            List:           list
        );
    }

    // ──────── お知らせ取得 ───────────────────────────────────────

    /// <summary>
    /// メニューお知らせ文字列を取得する。
    /// VBソース: pubblnUtilInformation_Sel (CtsbasxxMG0000.vb), MsgVer="01.00"
    /// 送信: CLASS / MSG_VER / SB_ID
    /// 受信: INFORMATION (テキスト)
    /// </summary>
    public async Task<InformationResult> GetInformationAsync(CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.Class,  "A");
        req.AddString(Tags.MsgVer, "01.00");
        req.AddString(Tags.SbId,   _defaultSbId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.UtilInformation, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "UtilInformation request failed");
            return new InformationResult(false, ErrorMessage: ex.Message);
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var errCode = msg.GetString(Tags.ErrCode);
            var errMsg  = msg.GetString(Tags.ErrMsg);
            logger.LogWarning("UtilInformation returned non-TRUE. ErrCode={ErrCode}, Err={Err}", errCode, errMsg);
            return new InformationResult(false, ErrorCode: errCode, ErrorMessage: errMsg);
        }

        return new InformationResult(
            IsSuccess: true,
            Text:      msg.GetString(Tags.Information)
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
}
