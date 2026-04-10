namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// ロット作業開始・終了、処理開始・終了サービス。
/// ・ロット作業開始 (lot_.wrkstart)
/// ・ロット作業終了 (lot_.wrkend__)
/// ・ロット処理開始 (lot_.prcstart)
/// ・ロット処理終了 (lot_.prcend__)
/// VBソース: pubblnLotStart_Ins (CtsbasxxCM0050.vb), LotwrkEnd / Lotprcstart 構造体 (CtsbasxxCM0030.vb)
/// </summary>
public sealed class WorkService(ITfMessageClient mq, IConfiguration cfg, ILogger<WorkService> logger)
{
    private readonly string _defaultSbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 公開型 ────────────────────────────────────────────

    /// <summary>ロット作業開始要求。VBソース: Lotwrkstart 構造体</summary>
    public sealed record WorkStartRequest(
        string LotId,
        string OpId,
        string StepId,
        string WpId,
        string EmpId,
        string LotLastUpdate,
        string Comments      = "",
        string AltNumber     = "",
        string ToCarrierId   = "",
        string CfCarrierId   = "",
        string ClassDivision = "",
        string MsgVer        = "07.00"
    );

    /// <summary>ロット作業開始結果</summary>
    public sealed record WorkStartResult(
        bool IsSuccess,
        string ActionFlag    = "",
        string ToOpId        = "",
        string ToStepId      = "",
        string LimitTime     = "",
        string WarnTime      = "",
        string LotLastUpdate = "",
        string ErrorMessage  = ""
    );

    /// <summary>ロット作業終了要求。VBソース: LotwrkEnd 構造体</summary>
    public sealed record WorkEndRequest(
        string LotId,
        string OpId,
        string StepId,
        string EmpId,
        string LotLastUpdate,
        string Comments = "",
        string MsgVer   = "05.00"
    );

    /// <summary>ロット処理開始要求。VBソース: Lotprcstart 構造体</summary>
    public sealed record ProcessStartRequest(
        string LotId,
        string OpId,
        string StepId,
        string WpId,
        string EmpId,
        string LotLastUpdate,
        string PortId      = "",
        string Comments    = "",
        string EqFlag      = "",
        string ToCarrierId = "",
        string ToPortId    = "",
        string MsgVer      = "05.00"
    );

    /// <summary>ロット処理終了要求</summary>
    public sealed record ProcessEndRequest(
        string LotId,
        string OpId,
        string StepId,
        string WpId,
        string EmpId,
        string LotLastUpdate,
        string Comments = "",
        string MsgVer   = "04.00"
    );

    // ──────── ロット作業開始 ─────────────────────────────────────

    /// <summary>
    /// ロット作業開始を登録する。
    /// VBソース: CPstrlot_wrkstart
    /// </summary>
    public async Task<WorkStartResult> WorkStartAsync(
        WorkStartRequest request, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,          request.LotId);
        req.AddString(Tags.OpId,           request.OpId);
        req.AddString(Tags.StepId,         request.StepId);
        req.AddString(Tags.WpId,           request.WpId);
        req.AddString(Tags.EmpId,          request.EmpId);
        req.AddString(Tags.LotLastUpdate,  request.LotLastUpdate);
        req.AddString(Tags.Comments,       request.Comments);
        req.AddString(Tags.AltNumber,      request.AltNumber);
        req.AddString(Tags.ToCarrierId,    request.ToCarrierId);
        req.AddString(Tags.CfCarrierId,    request.CfCarrierId);
        req.AddString(Tags.SbId,           _defaultSbId);
        req.AddString(Tags.MsgVer,         request.MsgVer);
        req.AddString(Tags.ClassDivision,  request.ClassDivision);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.WrkStart, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "WrkStart request failed. LotId={LotId}", request.LotId);
            return new WorkStartResult(false, ErrorMessage: ex.Message);
        }

        var msg = ParseOrEmpty(raw);
        var ret = msg.GetString(Tags.Ret);

        if (ret != Tags.True)
        {
            var errMsg = msg.GetString(Tags.ErrMsg);
            logger.LogWarning("WrkStart returned non-TRUE. LotId={LotId}, Err={Err}",
                request.LotId, errMsg);
            return new WorkStartResult(false, ErrorMessage: errMsg);
        }

        return new WorkStartResult(
            IsSuccess:    true,
            ActionFlag:   msg.GetString(Tags.ActionFlag),
            ToOpId:       msg.GetString(Tags.ToOpId),
            ToStepId:     msg.GetString(Tags.ToStepId),
            LimitTime:    msg.GetString(Tags.LimitTime),
            WarnTime:     msg.GetString(Tags.WarnTime),
            LotLastUpdate: msg.GetString(Tags.LotLastUpdate)
        );
    }

    // ──────── ロット作業終了 ─────────────────────────────────────

    /// <summary>
    /// ロット作業終了を登録する。
    /// VBソース: CPstrlot_wrkend
    /// </summary>
    public async Task<bool> WorkEndAsync(
        WorkEndRequest request, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,         request.LotId);
        req.AddString(Tags.OpId,          request.OpId);
        req.AddString(Tags.StepId,        request.StepId);
        req.AddString(Tags.EmpId,         request.EmpId);
        req.AddString(Tags.Comments,      request.Comments);
        req.AddString(Tags.LotLastUpdate, request.LotLastUpdate);
        req.AddString(Tags.SbId,          _defaultSbId);
        req.AddString(Tags.MsgVer,        request.MsgVer);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.WrkEnd, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "WrkEnd request failed. LotId={LotId}", request.LotId);
            return false;
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("WrkEnd returned non-TRUE. LotId={LotId}, Raw={Raw}",
                request.LotId, Summarize(raw));
            return false;
        }

        return true;
    }

    // ──────── ロット処理開始 ─────────────────────────────────────

    /// <summary>
    /// ロット処理開始を登録する。
    /// VBソース: CPstrlot_prcstart
    /// </summary>
    public async Task<bool> ProcessStartAsync(
        ProcessStartRequest request, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,         request.LotId);
        req.AddString(Tags.OpId,          request.OpId);
        req.AddString(Tags.StepId,        request.StepId);
        req.AddString(Tags.WpId,          request.WpId);
        req.AddString(Tags.PortId,        request.PortId);
        req.AddString(Tags.EmpId,         request.EmpId);
        req.AddString(Tags.LotLastUpdate, request.LotLastUpdate);
        req.AddString(Tags.Comments,      request.Comments);
        req.AddString(Tags.EqFlag,        request.EqFlag);
        req.AddString(Tags.ToCarrierId,   request.ToCarrierId);
        req.AddString(Tags.ToPortId,      request.ToPortId);
        req.AddString(Tags.SbId,          _defaultSbId);
        req.AddString(Tags.MsgVer,        request.MsgVer);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.PrcStart, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "PrcStart request failed. LotId={LotId}", request.LotId);
            return false;
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("PrcStart returned non-TRUE. LotId={LotId}, Raw={Raw}",
                request.LotId, Summarize(raw));
            return false;
        }

        return true;
    }

    // ──────── ロット処理終了 ─────────────────────────────────────

    /// <summary>
    /// ロット処理終了を登録する。
    /// VBソース: CPstrlot_procend_
    /// </summary>
    public async Task<bool> ProcessEndAsync(
        ProcessEndRequest request, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,         request.LotId);
        req.AddString(Tags.OpId,          request.OpId);
        req.AddString(Tags.StepId,        request.StepId);
        req.AddString(Tags.WpId,          request.WpId);
        req.AddString(Tags.EmpId,         request.EmpId);
        req.AddString(Tags.LotLastUpdate, request.LotLastUpdate);
        req.AddString(Tags.Comments,      request.Comments);
        req.AddString(Tags.SbId,          _defaultSbId);
        req.AddString(Tags.MsgVer,        request.MsgVer);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.PrcEnd, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "PrcEnd request failed. LotId={LotId}", request.LotId);
            return false;
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("PrcEnd returned non-TRUE. LotId={LotId}, Raw={Raw}",
                request.LotId, Summarize(raw));
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
