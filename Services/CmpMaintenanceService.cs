namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN01N0 CMP繝｡繝ｳ繝・リ繝ｳ繧ｹ</summary>
public class CmpMaintenanceService(ITfMessageClient mq, ILogger<CmpMaintenanceService> logger)
{
    public record CmpListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<CmpItem>? Items = null);
    public record CmpItem(
        string WpId, string WpName, string HeadNo, string PlatenNo,
        string CurrentRate, string TargetRate, string StatusName, string MsgVer);

    public record ChangeRateResult(bool IsSuccess, string ErrorMessage = "");
    public record ChangeStatResult(bool IsSuccess, string ErrorMessage = "");

    public async Task<CmpListResult> GetCmpListAsync(string wpId, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, "01.00");
            req.AddString(Tags.WpId,   wpId);
            var raw = await mq.SendMessageAsync("eq__.cmplist_", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new CmpListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("CMP_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new CmpItem(
                m.GetString(Tags.WpId),
                m.GetString("WP_NAME"),
                m.GetString("HEAD_NO"),
                m.GetString("PLATEN_NO"),
                m.GetString("CURRENT_RATE"),
                m.GetString("TARGET_RATE"),
                m.GetString("STATUS_NAME"),
                m.GetString(Tags.MsgVer))).ToList();
            return new CmpListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetCmpListAsync failed.");
            return new CmpListResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }

    public async Task<ChangeRateResult> ChangeRateAsync(
        string wpId, string headNo, string platenNo, string newRate,
        string empId, string msgVer, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, msgVer);
            req.AddString(Tags.WpId,   wpId);
            req.AddString("HEAD_NO",   headNo);
            req.AddString("PLATEN_NO", platenNo);
            req.AddString("NEW_RATE",  newRate);
            req.AddString(Tags.EmpId,  empId);
            var raw = await mq.SendMessageAsync("eq__.chgcmprate", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new ChangeRateResult(false, res.GetErrorInfo().Message)
                : new ChangeRateResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ChangeRateAsync failed.");
            return new ChangeRateResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }

    public async Task<ChangeStatResult> ChangeStatAsync(
        string wpId, string headNo, string platenNo, string newStat,
        string empId, string msgVer, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,   msgVer);
            req.AddString(Tags.WpId,     wpId);
            req.AddString("HEAD_NO",     headNo);
            req.AddString("PLATEN_NO",   platenNo);
            req.AddString("NEW_STATUS",  newStat);
            req.AddString(Tags.EmpId,    empId);
            var raw = await mq.SendMessageAsync("eq__.chgcmpstat", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new ChangeStatResult(false, res.GetErrorInfo().Message)
                : new ChangeStatResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ChangeStatAsync failed.");
            return new ChangeStatResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }
}
