namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN01X0 繝ｭ繝・ヨ蟾･鬆・､画峩</summary>
public class LotProcessOrderService(ITfMessageClient mq, ILogger<LotProcessOrderService> logger)
{
    public record LotListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<LotItem>? Items = null);
    public record LotItem(
        string LotId, string PdId, string PdName, string FlowClass,
        string CurrentOpId, string CurrentStepId, string WpId, string Status, string MsgVer);

    public record ChangeProcResult(bool IsSuccess, string ErrorMessage = "");

    public async Task<LotListResult> GetLotListAsync(string pdId, string flowClass, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,    "01.00");
            req.AddString(Tags.PdId,      pdId);
            req.AddString("FLOW_CLASS",   flowClass);
            var raw = await mq.SendMessageAsync("proc.list____", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new LotListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("LOT_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new LotItem(
                m.GetString(Tags.LotId),
                m.GetString(Tags.PdId),
                m.GetString("PD_NAME"),
                m.GetString("FLOW_CLASS"),
                m.GetString(Tags.OpId),
                m.GetString(Tags.StepId),
                m.GetString(Tags.WpId),
                m.GetString("STATUS"),
                m.GetString(Tags.MsgVer))).ToList();
            return new LotListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetLotListAsync failed.");
            return new LotListResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }

    public async Task<ChangeProcResult> ChangeProcStatusAsync(
        string lotId, string status, string empId, string msgVer,
        CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, msgVer);
            req.AddString(Tags.LotId,  lotId);
            req.AddString("STATUS",    status);
            req.AddString(Tags.EmpId,  empId);
            var raw = await mq.SendMessageAsync("proc.procchgstatus", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new ChangeProcResult(false, res.GetErrorInfo().Message)
                : new ChangeProcResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ChangeProcStatusAsync failed.");
            return new ChangeProcResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }
}
