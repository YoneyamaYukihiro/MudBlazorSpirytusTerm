namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN00O0 投入予定登録(品確・モニター・ダミー) サービス。
/// VBソース: VB/00O0/CtsfrmxxEN00O0.vb
/// メッセージID: lot_.throwrsv  MsgVer="03.00"
///              lot_.approve_  MsgVer="01.04"
/// 機種一覧: mas_.pdlist__  MsgVer="03.00"
/// 種別一覧: mas_.flowlist  MsgVer="04.00"
/// マスタ工順一覧: mas_.pdentrylist  MsgVer="03.00"
/// </summary>
public sealed class LotThrowRsvExtService(ITfMessageClient mq, IConfiguration cfg, ILogger<LotThrowRsvExtService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 型定義 ────────

    public sealed record ProductItem(string PdId, string PdName, string FlowClass, int MaxWfCount);

    public sealed record FlowClassItem(string FlowClassId, string FlowClassName);

    public sealed record EntryItem(string EntryId, string EntryName, string WfNum);

    public sealed record RegisterRequest(
        string PdId,
        string FlowClass,
        string WfNum,
        string PlanThrowinDate,
        string EngEmpId,
        string EmpId,
        string ClassDivision,
        string Comments = ""
    );

    public sealed record RegisterResult(
        bool   IsSuccess,
        string ErrorCode    = "",
        string ErrorMessage = "",
        string LotId        = ""
    );

    // ──────── 機種一覧取得 ────────

    public async Task<IReadOnlyList<ProductItem>> GetProductListAsync(string classDivision = "", CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.ClassDivision, classDivision);
        req.AddString(Tags.MsgVer,        "03.00");
        try
        {
            var raw = await mq.SendMessageAsync(MsgIds.MasPdList, req.ToTfString(), ct);
            var msg = TfMsg.ParseOrEmpty(raw);
            if (msg.GetString(Tags.Ret) != Tags.True) return [];
            return msg.GetMsgAry(Tags.PdList)
                      .Select(e => new ProductItem(
                          e.GetString(Tags.PdId),
                          e.GetString(Tags.PdName),
                          e.GetString(Tags.FlowClass),
                          int.TryParse(e.GetString(Tags.MaxWfCount), out var n) ? n : 25))
                      .ToList();
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetProductList failed");
            return [];
        }
    }

    // ──────── 種別一覧取得 ────────

    public async Task<IReadOnlyList<FlowClassItem>> GetFlowClassListAsync(CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,   _sbId);
        req.AddString(Tags.MsgVer, "04.00");
        try
        {
            var raw = await mq.SendMessageAsync(MsgIds.MasFlowList, req.ToTfString(), ct);
            var msg = TfMsg.ParseOrEmpty(raw);
            if (msg.GetString(Tags.Ret) != Tags.True) return [];
            return msg.GetMsgAry(Tags.FlowClassList)
                      .Select(e => new FlowClassItem(
                          e.GetString(Tags.FlowClassId),
                          e.GetString(Tags.FlowClassName)))
                      .ToList();
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetFlowClassList failed");
            return [];
        }
    }

    // ──────── 投入予定登録 ────────

    /// <summary>
    /// 投入予定登録(品確・モニター・ダミー)を実行する。
    /// VBソース: MsgId=lot_.throwrsv, MsgVer="03.00"
    /// </summary>
    public async Task<RegisterResult> RegisterAsync(RegisterRequest r, CancellationToken ct = default)
    {
        logger.LogInformation("LotThrowRsvExt start. PdId={PdId}, FlowClass={FlowClass}", r.PdId, r.FlowClass);

        var req = new TfMsg();
        req.AddString(Tags.PdId,           r.PdId);
        req.AddString(Tags.FlowClass,      r.FlowClass);
        req.AddString(Tags.WfNum,          r.WfNum);
        req.AddString(Tags.PlanThrowinDate, r.PlanThrowinDate);
        req.AddString(Tags.EngEmpId,       r.EngEmpId);
        req.AddString(Tags.Comments,       r.Comments);
        req.AddString(Tags.ClassDivision,  r.ClassDivision);
        req.AddString(Tags.EmpId,          r.EmpId);
        req.AddString(Tags.SbId,           _sbId);
        req.AddString(Tags.MsgVer,         "03.00");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotThrowRsv, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotThrowRsvExt send failed");
            return new RegisterResult(false, $"通信エラー: {ex.Message}");
        }

        var resp = TfMsg.ParseOrEmpty(raw);
        if (resp.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = resp.GetErrorInfo();
            if (string.IsNullOrEmpty(message)) message = resp.GetString(Tags.Msg);
            logger.LogWarning("LotThrowRsvExt returned FALSE: {Err}", message);
            return new RegisterResult(false, ErrorCode: code, ErrorMessage: string.IsNullOrEmpty(message) ? "投入予定登録に失敗しました。" : message);
        }

        return new RegisterResult(true, LotId: resp.GetString(Tags.LotId));
    }

    // ──────── ヘルパー ────────
}
