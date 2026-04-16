namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN00B0 CFロット編成 のサービス。
/// VBソース: VB/00B0/CtsfrmxxEN00B0.vb, VB/00B0/CtsbasxxMG00B0.vb
/// </summary>
public sealed class CfLotCompositionService(ITfMessageClient mq, IConfiguration cfg, ILogger<CfLotCompositionService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── メッセージID定数 ────────────────────────────────────
    // VBソース: CPstrlot_cfthrowin / CPstrmas_screenlist

    private const string MsgLotCfThrowin  = "lot_.cfthrowin";   // CFロット編成登録
    private const string MsgMasScreenList = "mas_.screenlist";  // 画面サイズマスタ取得

    // ──────── メッセージバージョン定数 ──────────────────────────────
    // VBソース: CMstrlot_cfthrowinVer = "05.00", CMstrmas_screenlistVer = "02.00"

    private const string VerLotCfThrowin  = "05.00";
    private const string VerMasScreenList = "02.00";

    // ──────── CFフラグ定数 ─────────────────────────────────────────
    // VBソース: CMstrCfFlag1 = "1" (CFの時)
    private const string CfFlag1 = "1";

    // ──────── 公開型 ─────────────────────────────────────────────

    /// <summary>
    /// 画面サイズマスタ1件。SCREEN_SIZE_LIST 要素。
    /// VBソース: ScreenList (strScreenSizeID / strChipCount)
    /// </summary>
    public sealed record ScreenSizeEntry(
        string ScreenSizeId,  // SCREEN_SIZE_ID
        string ChipCount      // CHIP_COUNT (基板取個数/詰数)
    );

    public sealed record ScreenSizeListResult(
        bool IsSuccess,
        string ErrorMessage = "",
        IReadOnlyList<ScreenSizeEntry>? Items = null
    );

    /// <summary>
    /// パレットマップ1スロット。PALETTE_MAP_LIST 要素 (送信用)。
    /// VBソース: typPaletteMapList
    /// </summary>
    public sealed record PaletteMapItem(
        string SlotPosition,  // SLOT_POSITION
        string PaletteId,     // PALETTE_ID
        string ChipCount,     // CHIP_COUNT
        string LotId          // LOT_ID
    );

    public sealed record CfThrowinResult(
        bool IsSuccess,
        string ErrorMessage = "",
        string GuidMsg      = "",     // MSG (ガイダンスMsg)
        string GuidMsgCode  = "",     // MSG_CODE (ガイダンスMsgコード)
        string ReturnLotId  = ""      // LOT_ID (投入ロットID)
    );

    // ──────── 画面サイズマスタ取得 (mas_.screenlist) ──────────────

    /// <summary>
    /// CF用画面サイズマスタを取得する。
    /// mas_.screenlist MSG_VER="02.00" CF_FLAG="1"
    /// VBソース: CMstrmas_screenlistVer = "02.00", pubblnMasScreenList_Sel
    /// </summary>
    public async Task<ScreenSizeListResult> GetScreenSizeListAsync(
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer, VerMasScreenList);
        req.AddString(Tags.SbId,   _sbId);
        req.AddString(Tags.CfFlag, CfFlag1);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgMasScreenList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "MasScreenList(EN00B0) failed.");
            return new ScreenSizeListResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = TfMsg.ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var err = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            logger.LogWarning("MasScreenList(EN00B0) returned FALSE. Err={Err}", err);
            return new ScreenSizeListResult(false, string.IsNullOrEmpty(err) ? "画面サイズマスタの取得に失敗しました。" : err);
        }

        var items = aMsg.GetMsgAry("SCREEN_SIZE_LIST")
            .Select(e => new ScreenSizeEntry(
                ScreenSizeId: e.GetString(Tags.ScreenSizeId),
                ChipCount:    e.GetString("CHIP_COUNT")
            ))
            .ToList();

        return new ScreenSizeListResult(true, Items: items);
    }

    // ──────── CFロット編成登録 (lot_.cfthrowin) ──────────────────

    /// <summary>
    /// CFロット編成を登録する。
    /// lot_.cfthrowin MSG_VER="05.00"
    /// VBソース: CMstrlot_cfthrowinVer = "05.00", pubblnLotCfThrowin_Upd
    /// </summary>
    public async Task<CfThrowinResult> RegisterCfLotAsync(
        string carrierId,
        string empId,
        string num,
        string pdId,
        string entryId,
        string engEmpId,
        string wpId,
        IReadOnlyList<PaletteMapItem> paletteMap,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,      _sbId);
        req.AddString(Tags.CarrierId, carrierId);
        req.AddString(Tags.EmpId,     empId);
        req.AddString("NUM",          num);
        req.AddString(Tags.PdId,      pdId);
        req.AddString(Tags.EntryId,   entryId);
        req.AddString(Tags.EngEmpId,  engEmpId);
        req.AddString(Tags.WpId,      wpId);

        // パレットマップリスト構築
        // VBソース: CPstrPALETTE_MAP_LIST / SLOT_POSITION / PALETTE_ID / CHIP_COUNT / LOT_ID
        var ary = new TfMsgAry();
        foreach (var p in paletteMap)
        {
            if (string.IsNullOrEmpty(p.PaletteId)) continue;
            var elem = new TfMsg();
            elem.AddString(Tags.SlotPosition, p.SlotPosition);
            elem.AddString("PALETTE_ID",      p.PaletteId);
            elem.AddString("CHIP_COUNT",      p.ChipCount);
            elem.AddString(Tags.LotId,        p.LotId);
            ary.Add(elem);
        }
        req.AddMsgAry("PALETTE_MAP_LIST", ary);

        req.AddString(Tags.MsgVer, VerLotCfThrowin);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgLotCfThrowin, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotCfThrowin(EN00B0) failed. CarrierId={Id}", carrierId);
            return new CfThrowinResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = TfMsg.ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var err = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            logger.LogWarning("LotCfThrowin(EN00B0) returned FALSE. Err={Err}", err);
            return new CfThrowinResult(false, string.IsNullOrEmpty(err) ? "CFロット編成登録に失敗しました。" : err);
        }

        return new CfThrowinResult(
            IsSuccess:   true,
            GuidMsg:     aMsg.GetString(Tags.Msg),
            GuidMsgCode: aMsg.GetString(Tags.MsgCode),
            ReturnLotId: aMsg.GetString(Tags.LotId)
        );
    }

    // ──────── 内部ヘルパー ─────────────────────────────────────────
}
