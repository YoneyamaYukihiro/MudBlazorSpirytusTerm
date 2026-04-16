namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN0040 ロット投入(基板) サービス。
/// VBソース: VB/0040/CtsbasxxMG0040.vb (pubblnLotThrowin_Sel)
/// メッセージID: lot_.throwin_  MsgVer="04.00"
/// キャリア状態確認: carr.curstate  MsgVer="05.02"
/// </summary>
public sealed class LotThrowinSubstrateService(ITfMessageClient mq, IConfiguration cfg, ILogger<LotThrowinSubstrateService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 型定義 ────────

    public sealed record WfMapItem(string InvLotId, string SlotPosition);

    public sealed record ThrowinRequest(
        string LotId,
        string CarrierId,
        string EmpId,
        string LotPriority,
        string OnlineFlag,
        string WpId,
        IReadOnlyList<WfMapItem> WfMapList
    );

    public sealed record ThrowinResult(
        bool IsSuccess,
        string ErrorMessage = "",
        string GuidMsg = "",
        string GuidMsgCode = ""
    );

    public sealed record CarrierStateResult(
        bool IsSuccess,
        string ErrorMessage = "",
        string LotId = "",
        string PdId = "",
        string PdName = "",
        string NowSt = "",
        string EngEmpName = "",
        string WfNum = "",
        string LotLastUpdate = "",
        string SlotSize = ""
    );

    public sealed record PriorityItem(string PriorityId, string PriorityName);

    public sealed record WpItem(string WpId, string WpName);

    // ──────── キャリア状態取得 ────────

    public async Task<CarrierStateResult> GetCarrierStateAsync(string carrierId, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.CarrierId,     carrierId);
        req.AddString(Tags.ClassDivision, "26");      // 投入(基板)
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.MsgVer,        "05.02");

        try
        {
            var raw = await mq.SendMessageAsync("carr.curstate", req.ToTfString(), ct);
            var msg = ParseOrEmpty(raw);
            if (msg.GetString(Tags.Ret) != Tags.True)
            {
                var err = msg.GetString(Tags.ErrMsg);
                return new CarrierStateResult(false, string.IsNullOrEmpty(err) ? "キャリア照合に失敗しました。" : err);
            }
            return new CarrierStateResult(
                IsSuccess:    true,
                LotId:        msg.GetString(Tags.LotId),
                PdId:         msg.GetString(Tags.PdId),
                PdName:       msg.GetString(Tags.PdName),
                NowSt:        msg.GetString(Tags.NowSt),
                EngEmpName:   msg.GetString(Tags.EngEmpName),
                WfNum:        msg.GetString(Tags.WfNum),
                LotLastUpdate: msg.GetString(Tags.LotLastUpdate),
                SlotSize:     msg.GetString(Tags.SlotSize));
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetCarrierState failed. CarrierId={CarrierId}", carrierId);
            return new CarrierStateResult(false, $"通信エラー: {ex.Message}");
        }
    }

    // ──────── 優先度一覧取得 ────────

    public async Task<IReadOnlyList<PriorityItem>> GetPriorityListAsync(CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,   _sbId);
        req.AddString(Tags.MsgVer, "01.00");
        try
        {
            var raw = await mq.SendMessageAsync("mas_.priolist", req.ToTfString(), ct);
            var msg = ParseOrEmpty(raw);
            if (msg.GetString(Tags.Ret) != Tags.True) return [];
            return msg.GetMsgAry("PRIORITY_LIST")
                      .Select(e => new PriorityItem(e.GetString("PRIORITY_ID"), e.GetString("PRIORITY_NAME")))
                      .ToList();
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetPriorityList failed");
            return [];
        }
    }

    // ──────── 装置一覧取得 ────────

    public async Task<IReadOnlyList<WpItem>> GetWpListAsync(CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,   _sbId);
        req.AddString(Tags.MsgVer, "05.01");
        try
        {
            var raw = await mq.SendMessageAsync(MsgIds.MasWpList, req.ToTfString(), ct);
            var msg = ParseOrEmpty(raw);
            if (msg.GetString(Tags.Ret) != Tags.True) return [];
            return msg.GetMsgAry(Tags.WpList)
                      .Select(e => new WpItem(e.GetString(Tags.WpId), e.GetString(Tags.WpName)))
                      .ToList();
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetWpList failed");
            return [];
        }
    }

    // ──────── ロット投入実行 ────────

    /// <summary>
    /// ロット投入(基板)を実行する。
    /// VBソース: pubblnLotThrowin_Sel, MsgVer="04.00", MsgId=lot_.throwin_
    /// </summary>
    public async Task<ThrowinResult> ExecuteAsync(ThrowinRequest r, CancellationToken ct = default)
    {
        logger.LogInformation("LotThrowinSubstrate start. LotId={LotId}, CarrierId={CarrierId}", r.LotId, r.CarrierId);

        var req = new TfMsg();
        req.AddString(Tags.LotId,        r.LotId);
        req.AddString(Tags.CarrierId,    r.CarrierId);
        req.AddString(Tags.EmpId,        r.EmpId);
        req.AddString(Tags.SbId,         _sbId);
        req.AddString(Tags.LotPriority,  r.LotPriority);
        req.AddString("ONLINE_FLAG",     r.OnlineFlag);
        req.AddString(Tags.WpId,         r.WpId);
        req.AddString(Tags.MsgVer,       "04.00");

        // WFMAPリスト
        var ary = new TfMsgAry();
        foreach (var wf in r.WfMapList)
        {
            var item = new TfMsg();
            item.AddString("INV_LOT_ID",      wf.InvLotId);
            item.AddString(Tags.SlotPosition, wf.SlotPosition);
            ary.Add(item);
        }
        req.AddMsgAry("WF_MAP_LIST", ary);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync("lot_.throwin_", req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotThrowinSubstrate send failed");
            return new ThrowinResult(false, $"通信エラー: {ex.Message}");
        }

        var resp = ParseOrEmpty(raw);
        if (resp.GetString(Tags.Ret) != Tags.True)
        {
            var err = resp.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = resp.GetString(Tags.Msg);
            logger.LogWarning("LotThrowinSubstrate returned FALSE: {Err}", err);
            return new ThrowinResult(false, string.IsNullOrEmpty(err) ? "投入処理に失敗しました。" : err);
        }

        return new ThrowinResult(
            true,
            GuidMsg:     resp.GetString(Tags.Msg),
            GuidMsgCode: resp.GetString(Tags.MsgCode));
    }

    // ──────── ヘルパー ────────

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
