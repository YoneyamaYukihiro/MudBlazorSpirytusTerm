namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN02L0 GRB属性設宁E/summary>
public class GrbAttributeService(ITfMessageClient mq, ILogger<GrbAttributeService> logger)
{
    public record SetResult(bool IsSuccess, string ErrorMessage = "", string LotLastUpdate = "");

    public async Task<SetResult> SetGrbAttributeAsync(
        string lotId, string classDivision, string empId, string lotLastUpdate,
        IReadOnlyList<(string wfId, string grbClass)> wafers,
        string msgVer, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,        msgVer);
            req.AddString(Tags.LotId,         lotId);
            req.AddString("CLASS_DIVISION",   classDivision);
            req.AddString(Tags.EmpId,         empId);
            req.AddString(Tags.LotLastUpdate, lotLastUpdate);
            var wfAry = new TfMsgAry();
            foreach (var (wfId, grbClass) in wafers)
            {
                var m = new TfMsg();
                m.AddString("WF_ID",     wfId);
                m.AddString("GRB_CLASS", grbClass);
                wfAry.Add(m);
            }
            req.AddMsgAry("WF_LIST", wfAry);
            var raw = await mq.SendMessageAsync("wf__.grbset__", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new SetResult(false, res.GetErrorInfo().Message);
            return new SetResult(true, "", res.GetString(Tags.LotLastUpdate));
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "SetGrbAttributeAsync failed.");
            return new SetResult(false, $"通信エラー: {ex.Message}");
        }
    }
}
