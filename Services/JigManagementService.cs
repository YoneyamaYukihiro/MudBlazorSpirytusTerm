namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN02D0 蒸着治具管琁E/summary>
public class JigManagementService(ITfMessageClient mq, ILogger<JigManagementService> logger)
{
    public record JycListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<JycItem>? Items = null);
    public record JycItem(
        string JycId, string JycName, string Status, string StatusName,
        string UseCount, string MaxUseCount, string WpId, string MsgVer);

    public record JjigListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<JjigItem>? Items = null);
    public record JjigItem(
        string JjigId, string JjigName, string JycId, string Status,
        string StatusName, string UseCount, string MsgVer);

    public record ChangeResult(bool IsSuccess, string ErrorMessage = "");

    public async Task<JycListResult> GetJycListAsync(string wpId, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, "01.00");
            req.AddString(Tags.WpId,   wpId);
            var raw = await mq.SendMessageAsync("jig_.jyclist_", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new JycListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("JYC_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new JycItem(
                m.GetString("JYC_ID"),
                m.GetString("JYC_NAME"),
                m.GetString("STATUS"),
                m.GetString("STATUS_NAME"),
                m.GetString("USE_COUNT"),
                m.GetString("MAX_USE_COUNT"),
                m.GetString(Tags.WpId),
                m.GetString(Tags.MsgVer))).ToList();
            return new JycListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetJycListAsync failed.");
            return new JycListResult(false, $"通信エラー: {ex.Message}");
        }
    }

    public async Task<JjigListResult> GetJjigListAsync(string jycId, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, "01.00");
            req.AddString("JYC_ID",    jycId);
            var raw = await mq.SendMessageAsync("jig_.jjiglist", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new JjigListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("JJIG_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new JjigItem(
                m.GetString("JJIG_ID"),
                m.GetString("JJIG_NAME"),
                m.GetString("JYC_ID"),
                m.GetString("STATUS"),
                m.GetString("STATUS_NAME"),
                m.GetString("USE_COUNT"),
                m.GetString(Tags.MsgVer))).ToList();
            return new JjigListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetJjigListAsync failed.");
            return new JjigListResult(false, $"通信エラー: {ex.Message}");
        }
    }

    public async Task<ChangeResult> ChangeJycAsync(
        string jycId, string newStatus, string empId, string msgVer,
        CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, msgVer);
            req.AddString("JYC_ID",    jycId);
            req.AddString("STATUS",    newStatus);
            req.AddString(Tags.EmpId,  empId);
            var raw = await mq.SendMessageAsync("jig_.chgjyc__", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new ChangeResult(false, res.GetErrorInfo().Message)
                : new ChangeResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ChangeJycAsync failed.");
            return new ChangeResult(false, $"通信エラー: {ex.Message}");
        }
    }
}
