namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN02M0 GRB繝ｭ繝・ヨ蛻・牡</summary>
public class GrbLotDivideService(ITfMessageClient mq, ILogger<GrbLotDivideService> logger)
{
    public record ChangeGrbClassResult(bool IsSuccess, string ErrorMessage = "", string LotLastUpdate = "");

    public async Task<ChangeGrbClassResult> ChangeGrbClassAsync(
        string lotId, string empId, string grbClass, string lotLastUpdate,
        string msgVer, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,        msgVer);
            req.AddString(Tags.LotId,         lotId);
            req.AddString(Tags.EmpId,         empId);
            req.AddString("GRB_CLASS",        grbClass);
            req.AddString(Tags.LotLastUpdate, lotLastUpdate);
            var raw = await mq.SendMessageAsync("lot_.chggrbclass", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new ChangeGrbClassResult(false, res.GetErrorInfo().Message);
            return new ChangeGrbClassResult(true, "", res.GetString(Tags.LotLastUpdate));
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ChangeGrbClassAsync failed.");
            return new ChangeGrbClassResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }
}
