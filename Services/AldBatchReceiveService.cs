namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN02P0 バッチ受入在庫(ALD)</summary>
public class AldBatchReceiveService(ITfMessageClient mq, ILogger<AldBatchReceiveService> logger)
{
    public record BatchRecipeResult(bool IsSuccess, string ErrorMessage = "",
        string PdId = "", string TapeStickRecipe = "", string OvenRecipe = "", string AldRecipe = "");

    public record BatchRegistResult(bool IsSuccess, string ErrorMessage = "");

    public record LotItem(
        string LotId, string PdId, string WfQty, string ChipQty,
        string ACarrierGroup, string TapeStickGroup, string ATrayChipNum,
        string FlowClass, string TapeStickRecipeId, string OvenRecipeId, string AldRecipeId);

    public async Task<BatchRecipeResult> GetBatchRecipeAsync(
        string pdId, string msgVer = "01.00", CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, msgVer);
            req.AddString(Tags.PdId,   pdId);
            var raw = await mq.SendMessageAsync("mas_.aldbatchrecipe", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new BatchRecipeResult(false, res.GetErrorInfo().Message);
            return new BatchRecipeResult(true, "",
                res.GetString(Tags.PdId),
                res.GetString("TAPE_STICK_RECIPE_ID"),
                res.GetString("OVEN_RESCIPE_ID"),
                res.GetString("ALD_RECIPE_ID"));
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetBatchRecipeAsync failed.");
            return new BatchRecipeResult(false, $"通信エラー: {ex.Message}");
        }
    }

    public async Task<BatchRegistResult> RegistBatchAsync(
        string batchId, string classDiv, string planThrowinDate, string batchFlowClass,
        string monitorUseFlag, string empId, IReadOnlyList<LotItem> lots,
        string msgVer, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,        msgVer);
            req.AddString("CLASS_DIVISION",   classDiv);
            req.AddString(Tags.BatchId,       batchId);
            req.AddString("PLAN_THROWIN_DATE",planThrowinDate);
            req.AddString("BATCH_FLOW_CLASS", batchFlowClass);
            req.AddString("MONITOR_USE_FLAG", monitorUseFlag);
            req.AddString(Tags.EmpId,         empId);
            var lotAry = new TfMsgAry();
            foreach (var lot in lots)
            {
                var m = new TfMsg();
                m.AddString(Tags.LotId,            lot.LotId);
                m.AddString(Tags.PdId,             lot.PdId);
                m.AddString("WF_QUANTITY",         lot.WfQty);
                m.AddString("CHIP_QUANTITY",       lot.ChipQty);
                m.AddString("A_CARRIER_GROUP",     lot.ACarrierGroup);
                m.AddString("TAPE_STICK_GROUP",    lot.TapeStickGroup);
                m.AddString("A_TRAY_CHIP_NUM",     lot.ATrayChipNum);
                m.AddString("FLOW_CLASS",          lot.FlowClass);
                m.AddString("TAPE_STICK_RECIPE_ID",lot.TapeStickRecipeId);
                m.AddString("OVEN_RECIPE_ID",      lot.OvenRecipeId);
                m.AddString("ALD_RECIPE_ID",       lot.AldRecipeId);
                lotAry.Add(m);
            }
            req.AddMsgAry(Tags.LotList, lotAry);
            var raw = await mq.SendMessageAsync("bat_.aldbatchregist", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new BatchRegistResult(false, res.GetErrorInfo().Message)
                : new BatchRegistResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "RegistBatchAsync failed.");
            return new BatchRegistResult(false, $"通信エラー: {ex.Message}");
        }
    }
}
