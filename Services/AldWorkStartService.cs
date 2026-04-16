namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN02Q0 作業開姁E防湿ALD)</summary>
public class AldWorkStartService(ITfMessageClient mq, ILogger<AldWorkStartService> logger)
{
    public record WorkLotListResult(bool IsSuccess, string ErrorMessage = "",
        string LotId = "", string CarrierId = "", string ProcessUnit = "",
        string ProcessNum = "", string ProcessName = "",
        string TapeBatchId = "", string OvenBatchId = "", string AldBatchId = "",
        string MonitorUseFlag = "", string BatchFlowClass = "",
        IReadOnlyList<WorkLotItem>? Items = null);

    public record WorkLotItem(
        string LotId, string CarrierId, string FlowClass,
        string OpId, string StepId, string NowSt,
        string WfNum, string ChipQuantity, string PdId, string PdVersion,
        string ProcessNum, string ProcessName, string Comments, string EditTime);

    public record WpListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<WpItem>? Items = null);
    public record WpItem(string WpId, string WpName, string WpStatusName, string RecipeId,
        string OpId, string StepId, string EqType, string ProcessNum, string ProcessName);

    public record ACarrierSetResult(bool IsSuccess, string ErrorMessage = "");

    public async Task<WorkLotListResult> GetWorkLotListAsync(
        string lotId, string carrierId, string msgVer = "01.00", CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,    msgVer);
            req.AddString(Tags.LotId,     lotId);
            req.AddString(Tags.CarrierId, carrierId);
            var raw = await mq.SendMessageAsync("lot_.workaldlotlist", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new WorkLotListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry(Tags.LotList) ?? new TfMsgAry();
            var items = ary.Select(m => new WorkLotItem(
                m.GetString(Tags.LotId),
                m.GetString(Tags.CarrierId),
                m.GetString("FLOW_CLASS"),
                m.GetString(Tags.OpId),
                m.GetString(Tags.StepId),
                m.GetString("NOW_ST"),
                m.GetString("WF_NUM"),
                m.GetString("CHIP_QUANTITY"),
                m.GetString(Tags.PdId),
                m.GetString("PD_VERSION"),
                m.GetString("ALD_PROCESS_NUM"),
                m.GetString("ALD_PROCESS_NAME"),
                m.GetString("COMMENTS"),
                m.GetString("EDIT_TIME"))).ToList();

            return new WorkLotListResult(true, "",
                res.GetString(Tags.LotId),
                res.GetString(Tags.CarrierId),
                res.GetString("ALD_PROCESS_UNIT"),
                res.GetString("ALD_PROCESS_NUM"),
                res.GetString("ALD_PROCESS_NAME"),
                res.GetString("TAPE_STICK_BATCH_ID"),
                res.GetString("OVEN_BATCH_ID"),
                res.GetString("ALD_BATCH_ID"),
                res.GetString("MONITOR_USE_FLAG"),
                res.GetString("BATCH_FLOW_CLASS"),
                items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetWorkLotListAsync failed.");
            return new WorkLotListResult(false, $"通信エラー: {ex.Message}");
        }
    }

    public async Task<WpListResult> GetWpListAldAsync(
        string lotId, string opId, string stepId, string classDivision,
        string msgVer = "01.00", CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,       msgVer);
            req.AddString("CLASS_DIVISION",  classDivision);
            req.AddString(Tags.LotId,        lotId);
            req.AddString(Tags.OpId,         opId);
            req.AddString(Tags.StepId,       stepId);
            var raw = await mq.SendMessageAsync("lot_.wplistald", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new WpListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("WP_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new WpItem(
                m.GetString(Tags.WpId),
                m.GetString("WP_NAME"),
                m.GetString("WP_STATUS_NAME"),
                m.GetString("RECIPE_ID"),
                m.GetString(Tags.OpId),
                m.GetString(Tags.StepId),
                m.GetString("EQ_TYPE"),
                m.GetString("ALD_PROCESS_NUM"),
                m.GetString("ALD_PROCESS_NAME"))).ToList();
            return new WpListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetWpListAldAsync failed.");
            return new WpListResult(false, $"通信エラー: {ex.Message}");
        }
    }
}
