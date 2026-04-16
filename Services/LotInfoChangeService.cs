namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN0290 繝ｭ繝・ヨ諠・ｱ螟画峩</summary>
public class LotInfoChangeService(ITfMessageClient mq, ILogger<LotInfoChangeService> logger)
{
    public record ChangeResult(bool IsSuccess, string ErrorMessage = "");

    public async Task<ChangeResult> ChangeAttributeAsync(
        string lotId, string attributeName, string newValue,
        string empId, string lotLastUpdate, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,        "01.00");
            req.AddString(Tags.LotId,         lotId);
            req.AddString("ATTRIBUTE_NAME",   attributeName);
            req.AddString("NEW_VALUE",        newValue);
            req.AddString(Tags.EmpId,         empId);
            req.AddString(Tags.LotLastUpdate, lotLastUpdate);
            var raw = await mq.SendMessageAsync("lot_.chgattribute", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new ChangeResult(false, res.GetErrorInfo().Message)
                : new ChangeResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ChangeAttributeAsync failed.");
            return new ChangeResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }
}
