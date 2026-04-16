namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN0120 ロット編成(保留/払出WF) サービス。
/// VBソース: VB/0120/CtsbasxxMG0120.vb (pubblnInvThrowin_Sel)
/// メッセージID: inv_.throwin_  MsgVer="03.00"
/// キャリア状態確認: carr.curstate  MsgVer="05.02"
/// ウェーハ在庫情報取得: inv_.waferlist MsgVer="04.00"
/// </summary>
public sealed class LotCompositionService(ITfMessageClient mq, IConfiguration cfg, ILogger<LotCompositionService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 型定義 ────────

    public sealed record CarrierStateResult(
        bool   IsSuccess,
        string ErrorMessage  = "",
        string LotId         = "",
        string PdId          = "",
        string PdName        = "",
        string NowSt         = "",
        string EngEmpName    = "",
        string WfNum         = "",
        string LotLastUpdate = "",
        string SlotSize      = ""
    );

    public sealed record PriorityItem(string PriorityId, string PriorityName);

    public sealed record CompositionRequest(
        string LotId,
        string CarrierId,
        string EmpId,
        string LotPriority
    );

    public sealed record CompositionResult(
        bool   IsSuccess,
        string ErrorMessage = "",
        string GuidMsg      = "",
        string GuidMsgCode  = ""
    );

    // ──────── キャリア状態取得 ────────

    public async Task<CarrierStateResult> GetCarrierStateAsync(string carrierId, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.CarrierId,     carrierId);
        req.AddString(Tags.ClassDivision, "26");
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.MsgVer,        "05.02");

        try
        {
            var raw = await mq.SendMessageAsync(MsgIds.CarrCurState, req.ToTfString(), ct);
            var msg = ParseOrEmpty(raw);
            if (msg.GetString(Tags.Ret) != Tags.True)
            {
                var err = msg.GetString(Tags.ErrMsg);
                return new CarrierStateResult(false, string.IsNullOrEmpty(err) ? "照合に失敗しました。" : err);
            }
            return new CarrierStateResult(
                IsSuccess:     true,
                LotId:         msg.GetString(Tags.LotId),
                PdId:          msg.GetString(Tags.PdId),
                PdName:        msg.GetString(Tags.PdName),
                NowSt:         msg.GetString(Tags.NowSt),
                EngEmpName:    msg.GetString(Tags.EngEmpName),
                WfNum:         msg.GetString(Tags.WfNum),
                LotLastUpdate: msg.GetString(Tags.LotLastUpdate),
                SlotSize:      msg.GetString(Tags.SlotSize));
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

    // ──────── 在庫ロット投入(ロット編成) ────────

    /// <summary>
    /// 在庫ロット投入(ロット編成)を実行する。
    /// VBソース: pubblnInvThrowin_Sel, MsgVer="03.00", MsgId=inv_.throwin_
    /// </summary>
    public async Task<CompositionResult> ExecuteAsync(CompositionRequest r, CancellationToken ct = default)
    {
        logger.LogInformation("LotComposition start. LotId={LotId}, CarrierId={CarrierId}", r.LotId, r.CarrierId);

        var req = new TfMsg();
        req.AddString(Tags.SbId,        _sbId);
        req.AddString(Tags.MsgVer,      "03.00");
        req.AddString(Tags.LotId,       r.LotId);
        req.AddString(Tags.CarrierId,   r.CarrierId);
        req.AddString(Tags.EmpId,       r.EmpId);
        req.AddString(Tags.LotPriority, r.LotPriority);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync("inv_.throwin_", req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotComposition send failed");
            return new CompositionResult(false, $"通信エラー: {ex.Message}");
        }

        var resp = ParseOrEmpty(raw);
        if (resp.GetString(Tags.Ret) != Tags.True)
        {
            var err = resp.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = resp.GetString(Tags.Msg);
            logger.LogWarning("LotComposition returned FALSE: {Err}", err);
            return new CompositionResult(false, string.IsNullOrEmpty(err) ? "編成処理に失敗しました。" : err);
        }

        return new CompositionResult(
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
