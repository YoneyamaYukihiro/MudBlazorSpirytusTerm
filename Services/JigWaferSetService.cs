namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN02F0 豐ｻ蜈ｷ繧ｦ繧ｧ繝上・繧ｻ繝・ヨ</summary>
public class JigWaferSetService(ITfMessageClient mq, ILogger<JigWaferSetService> logger)
{
    public record JjigInfoResult(bool IsSuccess, string ErrorMessage = "",
        string JjigId = "", string JjigName = "", string Status = "",
        IReadOnlyList<SlotItem>? Slots = null);

    public record SlotItem(string SlotNo, string WfNo, string LotId, string Status);

    public record SetResult(bool IsSuccess, string ErrorMessage = "");

    public async Task<JjigInfoResult> GetJjigInfoAsync(string jjigId, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, "01.00");
            req.AddString("JJIG_ID",   jjigId);
            var raw = await mq.SendMessageAsync("jig_.jjigget", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new JjigInfoResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("SLOT_MAP") ?? new TfMsgAry();
            var slots = ary.Select(m => new SlotItem(
                m.GetString("SLOT_NO"),
                m.GetString("WF_NO"),
                m.GetString(Tags.LotId),
                m.GetString("STATUS"))).ToList();

            return new JjigInfoResult(true, "",
                res.GetString("JJIG_ID"),
                res.GetString("JJIG_NAME"),
                res.GetString("STATUS"),
                slots);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetJjigInfoAsync failed.");
            return new JjigInfoResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }

    public async Task<SetResult> SetWaferAsync(
        string jjigId, string lotId, string empId,
        IReadOnlyList<(string slotNo, string wfNo)> wafers,
        CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, "01.00");
            req.AddString("JJIG_ID",   jjigId);
            req.AddString(Tags.LotId,  lotId);
            req.AddString(Tags.EmpId,  empId);
            var waferAry = new TfMsgAry();
            foreach (var (slotNo, wfNo) in wafers)
            {
                var m = new TfMsg();
                m.AddString("SLOT_NO", slotNo);
                m.AddString("WF_NO",   wfNo);
                waferAry.Add(m);
            }
            req.AddMsgAry("WAFER_LIST", waferAry);
            var raw = await mq.SendMessageAsync("wf__.grbset__", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new SetResult(false, res.GetErrorInfo().Message)
                : new SetResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "SetWaferAsync failed.");
            return new SetResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }
}
