namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN0140 ロットコメント のサービス。
/// VBソース: VB/COMN/CtsfrmxxCM0030.vb, VB/COMN/CtsbasxxCM0050.vb
/// </summary>
public sealed class LotCommentService(ITfMessageClient mq, IConfiguration cfg, ILogger<LotCommentService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    public sealed record CommentResult(
        bool   IsSuccess,
        string ErrorMessage   = "",
        string LotLastUpdate  = ""
    );

    /// <summary>
    /// ロットコメントを登録/更新する。
    /// lot_.chgcomm_ MSG_VER="01.00"
    /// </summary>
    public async Task<CommentResult> SetCommentAsync(
        string lotId,
        string comments,
        string lotLastUpdate,
        string empId           = "",
        CancellationToken ct   = default)
    {
        logger.LogInformation("LotChgComm start. LotId={LotId}", lotId);

        var req = new TfMsg();
        req.AddString(Tags.LotId,          lotId);
        req.AddString(Tags.EmpId,          empId);
        req.AddString(Tags.Comments,       comments);
        req.AddString(Tags.LotLastUpdate,  lotLastUpdate);
        req.AddString(Tags.SbId,           _sbId);
        req.AddString(Tags.MsgVer,         "01.00");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotChgComm, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotChgComm send failed. LotId={LotId}", lotId);
            return new CommentResult(false, $"通信エラー: {ex.Message}");
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var err = msg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = msg.GetString(Tags.Msg);
            logger.LogWarning("LotChgComm returned FALSE. LotId={LotId}, Err={Err}", lotId, err);
            return new CommentResult(false, string.IsNullOrEmpty(err) ? "処理に失敗しました。" : err);
        }

        return new CommentResult(true, LotLastUpdate: msg.GetString(Tags.LotLastUpdate));
    }

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
