namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN02B0 繝ｭ繝・ヨ諠・ｱ荳諡ｬ螟画峩</summary>
public class BatchLotInfoChangeService(ITfMessageClient mq, ILogger<BatchLotInfoChangeService> logger)
{
    public record OpLotListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<OpLotItem>? Items = null);
    public record OpLotItem(
        string LotId, string CarrierId, string PdId, string PdName,
        string Priority, string FlowClass, string OpId, string StepId,
        string WpId, string WpName, string Status, string MsgVer);

    public record ChangeResult(bool IsSuccess, string ErrorMessage = "");

    public async Task<OpLotListResult> GetOpLotListAsync(
        string opId, string stepId, string wpId,
        CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, "01.00");
            req.AddString(Tags.OpId,   opId);
            req.AddString(Tags.StepId, stepId);
            req.AddString(Tags.WpId,   wpId);
            var raw = await mq.SendMessageAsync("lot_.oplotlist", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new OpLotListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("LOT_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new OpLotItem(
                m.GetString(Tags.LotId),
                m.GetString(Tags.CarrierId),
                m.GetString(Tags.PdId),
                m.GetString("PD_NAME"),
                m.GetString("PRIORITY"),
                m.GetString("FLOW_CLASS"),
                m.GetString(Tags.OpId),
                m.GetString(Tags.StepId),
                m.GetString(Tags.WpId),
                m.GetString("WP_NAME"),
                m.GetString("STATUS"),
                m.GetString(Tags.MsgVer))).ToList();
            return new OpLotListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetOpLotListAsync failed.");
            return new OpLotListResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }

    public async Task<ChangeResult> ChangeAttributesAsync(
        IReadOnlyList<string> lotIds, string attributeName, string newValue,
        string empId, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,      "01.00");
            req.AddString("ATTRIBUTE_NAME", attributeName);
            req.AddString("NEW_VALUE",      newValue);
            req.AddString(Tags.EmpId,       empId);
            var lotAry = new TfMsgAry();
            foreach (var id in lotIds)
            {
                var m = new TfMsg();
                m.AddString(Tags.LotId, id);
                lotAry.Add(m);
            }
            req.AddMsgAry("LOT_LIST", lotAry);
            var raw = await mq.SendMessageAsync("lot_.chgattributes", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new ChangeResult(false, res.GetErrorInfo().Message)
                : new ChangeResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ChangeAttributesAsync failed.");
            return new ChangeResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }
}
