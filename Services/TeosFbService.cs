namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN02J0 TEOS F/B螟画峩/蜿ら・</summary>
public class TeosFbService(ITfMessageClient mq, ILogger<TeosFbService> logger)
{
    public record CondListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<CondItem>? Items = null);
    public record CondItem(string WpId, string WpName, string RecipeId, string CondId, string CondName);

    public record FbListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<FbItem>? Items = null);
    public record FbItem(
        string No, string MeasDate, string WpId, string RecipeId,
        string ItemName, string CurrentValue, string NewValue, string MsgVer);

    public record UpdateResult(bool IsSuccess, string ErrorMessage = "");

    public async Task<CondListResult> GetCondListAsync(string wpId, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, "01.00");
            req.AddString(Tags.WpId,   wpId);
            var raw = await mq.SendMessageAsync("fb__.teosresultcondlist", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new CondListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("COND_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new CondItem(
                m.GetString(Tags.WpId),
                m.GetString("WP_NAME"),
                m.GetString("RECIPE_ID"),
                m.GetString("COND_ID"),
                m.GetString("COND_NAME"))).ToList();
            return new CondListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetCondListAsync failed.");
            return new CondListResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }

    public async Task<FbListResult> GetFbListAsync(string wpId, string condId, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, "01.00");
            req.AddString(Tags.WpId,   wpId);
            req.AddString("COND_ID",   condId);
            var raw = await mq.SendMessageAsync("fb__.teosresultlist", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new FbListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("FB_LIST") ?? new TfMsgAry();
            var items = ary.Select((m, i) => new FbItem(
                (i + 1).ToString(),
                m.GetString("MEAS_DATE"),
                m.GetString(Tags.WpId),
                m.GetString("RECIPE_ID"),
                m.GetString("ITEM_NAME"),
                m.GetString("CURRENT_VALUE"),
                m.GetString("NEW_VALUE"),
                m.GetString(Tags.MsgVer))).ToList();
            return new FbListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetFbListAsync failed.");
            return new FbListResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }

    public async Task<UpdateResult> UpdateAsync(
        string wpId, string condId, string itemName, string newValue,
        string empId, string msgVer, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, msgVer);
            req.AddString(Tags.WpId,   wpId);
            req.AddString("COND_ID",   condId);
            req.AddString("ITEM_NAME", itemName);
            req.AddString("NEW_VALUE", newValue);
            req.AddString(Tags.EmpId,  empId);
            var raw = await mq.SendMessageAsync("fb__.teosresultupdate", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new UpdateResult(false, res.GetErrorInfo().Message)
                : new UpdateResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "UpdateAsync failed.");
            return new UpdateResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }
}
