namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN01U0 繝輔か繝・/B繝・・繧ｿ螟画峩</summary>
public class PhotoFbDataService(ITfMessageClient mq, ILogger<PhotoFbDataService> logger)
{
    public record FbDataListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<FbDataItem>? Items = null);
    public record FbDataItem(
        string WpId, string WpName, string RecipeId, string ItemName,
        string CurrentValue, string NewValue, string Unit, string MsgVer);

    public record ChangeFbDataResult(bool IsSuccess, string ErrorMessage = "");

    public async Task<FbDataListResult> GetFbDataListAsync(string wpId, string recipeId, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,   "01.00");
            req.AddString(Tags.WpId,     wpId);
            req.AddString("RECIPE_ID",   recipeId);
            var raw = await mq.SendMessageAsync("eq__.photofbdatalist", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new FbDataListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("FB_DATA_ITEM_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new FbDataItem(
                m.GetString(Tags.WpId),
                m.GetString("WP_NAME"),
                m.GetString("RECIPE_ID"),
                m.GetString("ITEM_NAME"),
                m.GetString("CURRENT_VALUE"),
                m.GetString("NEW_VALUE"),
                m.GetString("UNIT"),
                m.GetString(Tags.MsgVer))).ToList();
            return new FbDataListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetFbDataListAsync failed.");
            return new FbDataListResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }

    public async Task<ChangeFbDataResult> ChangeFbDataAsync(
        string wpId, string recipeId, string itemName, string newValue,
        string empId, string msgVer, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,  msgVer);
            req.AddString(Tags.WpId,    wpId);
            req.AddString("RECIPE_ID",  recipeId);
            req.AddString("ITEM_NAME",  itemName);
            req.AddString("NEW_VALUE",  newValue);
            req.AddString(Tags.EmpId,   empId);
            var raw = await mq.SendMessageAsync("eq__.photofbdatachg", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new ChangeFbDataResult(false, res.GetErrorInfo().Message)
                : new ChangeFbDataResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ChangeFbDataAsync failed.");
            return new ChangeFbDataResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }
}
