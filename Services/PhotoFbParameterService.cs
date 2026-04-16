namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN01T0 フォチE/Bパラメータ変更</summary>
public class PhotoFbParameterService(ITfMessageClient mq, ILogger<PhotoFbParameterService> logger)
{
    public record ParamListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<ParamItem>? Items = null);
    public record ParamItem(
        string WpId, string WpName, string ItemName, string CurrentValue,
        string Unit, string LowerLimit, string UpperLimit, string MsgVer);

    public record ChangeParamResult(bool IsSuccess, string ErrorMessage = "");

    public async Task<ParamListResult> GetParamListAsync(string wpId, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, "01.00");
            req.AddString(Tags.WpId,   wpId);
            var raw = await mq.SendMessageAsync("eq__.photofbeqprmlist", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new ParamListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("EQ_PARAMETER_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new ParamItem(
                m.GetString(Tags.WpId),
                m.GetString("WP_NAME"),
                m.GetString("ITEM_NAME"),
                m.GetString("CURRENT_VALUE"),
                m.GetString("UNIT"),
                m.GetString("LOWER_LIMIT"),
                m.GetString("UPPER_LIMIT"),
                m.GetString(Tags.MsgVer))).ToList();
            return new ParamListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetParamListAsync failed.");
            return new ParamListResult(false, $"通信エラー: {ex.Message}");
        }
    }

    public async Task<ChangeParamResult> ChangeParamAsync(
        string wpId, string itemName, string newValue,
        string empId, string msgVer, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, msgVer);
            req.AddString(Tags.WpId,   wpId);
            req.AddString("ITEM_NAME", itemName);
            req.AddString("NEW_VALUE", newValue);
            req.AddString(Tags.EmpId,  empId);
            var raw = await mq.SendMessageAsync("eq__.photofbeqprmchg", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new ChangeParamResult(false, res.GetErrorInfo().Message)
                : new ChangeParamResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ChangeParamAsync failed.");
            return new ChangeParamResult(false, $"通信エラー: {ex.Message}");
        }
    }
}
