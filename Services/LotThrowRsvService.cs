namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// ロット投入予約サービス。
/// ・ロット投入予約   (lot_.throwrsv)
/// ・投入ロット承認   (lot_.approve_)
/// VBソース: CtsbasxxCM0050.vb (pubblnLotThrowrsv_Ins / pubblnLotApprove_Ins)
/// 構造体定義: LotReserve (CtsbasxxCM0030.vb)
/// </summary>
public sealed class LotThrowRsvService(ITfMessageClient mq, IConfiguration cfg, ILogger<LotThrowRsvService> logger)
{
    private readonly string _defaultSbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 公開型 ────────────────────────────────────────────

    /// <summary>投入予約要求。VBソース: LotReserve 構造体</summary>
    public sealed record LotThrowRsvRequest(
        string PdId,
        string FlowClass,
        string WfNum,
        string PlanThrowinDate,
        string EngEmpId,
        string EmpId,
        string ClassDivision,
        string CopySeqLotId     = "",
        string MasPdVersion     = "",
        string DivideLotId      = "",
        string Comments         = "",
        string PrOrderId        = "",
        string LotSendFlag      = ""
    );

    // ──────── ロット投入予約 ─────────────────────────────────────

    /// <summary>
    /// ロット投入予約を登録する。
    /// VBソース: pubblnLotThrowrsv_Ins, MsgVer="03.00"
    /// </summary>
    /// <returns>採番されたロットID、失敗時null</returns>
    public async Task<string?> ThrowRsvAsync(
        LotThrowRsvRequest request,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.PdId,            request.PdId);
        req.AddString(Tags.FlowClass,       request.FlowClass);
        req.AddString(Tags.WfNum,           request.WfNum);
        req.AddString(Tags.PlanThrowinDate, request.PlanThrowinDate);
        req.AddString(Tags.EngEmpId,        request.EngEmpId);
        req.AddString(Tags.CopySeqLotId,    request.CopySeqLotId);
        req.AddString(Tags.MasPdVersion,    request.MasPdVersion);
        req.AddString(Tags.LotId,           request.DivideLotId);
        req.AddString(Tags.Comments,        request.Comments);
        req.AddString(Tags.ClassDivision,   request.ClassDivision);
        req.AddString(Tags.EmpId,           request.EmpId);
        req.AddString(Tags.SbId,            _defaultSbId);
        req.AddString(Tags.PrOrderId,       request.PrOrderId);
        req.AddString(Tags.LotSendFlag,     request.LotSendFlag);
        req.AddString(Tags.MsgVer,          "03.00");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotThrowRsv, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotThrowRsv request failed. PdId={PdId}", request.PdId);
            return null;
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("LotThrowRsv returned non-TRUE. PdId={PdId}, Raw={Raw}",
                request.PdId, Summarize(raw));
            return null;
        }

        return msg.GetString(Tags.LotId);
    }

    // ──────── 投入ロット承認 ─────────────────────────────────────

    /// <summary>
    /// 投入予約ロットを承認する。
    /// VBソース: pubblnLotApprove_Ins, MsgVer="01.04"
    /// </summary>
    public async Task<bool> ApproveAsync(
        string lotId,
        string empId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,  lotId);
        req.AddString(Tags.EmpId,  empId);
        req.AddString(Tags.SbId,   _defaultSbId);
        req.AddString(Tags.MsgVer, "01.04");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotApprove, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotApprove request failed. LotId={LotId}", lotId);
            return false;
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("LotApprove returned non-TRUE. LotId={LotId}, Raw={Raw}",
                lotId, Summarize(raw));
            return false;
        }

        return true;
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

    private static string Summarize(string? raw) =>
        (raw ?? string.Empty) is { Length: > 200 } s ? s[..200] + "..." : raw ?? string.Empty;
}
