namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN02H0 無機対向基板紐仁E蒸着バッチ情報</summary>
public class InorganicSubstrateBondingService(ITfMessageClient mq, ILogger<InorganicSubstrateBondingService> logger)
{
    public record MkLotListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<MkLotItem>? Items = null);
    public record MkLotItem(
        string MkLotId, string CfLotId, string TpLotId,
        string MkCarrierId, string CfCarrierId, string TpCarrierId,
        string BatchId, string Status, string EvapDate);

    public record BatchInfoResult(bool IsSuccess, string ErrorMessage = "",
        string BatchId = "", string WpId = "", string RecipeId = "",
        string StartDate = "", string EndDate = "", string Status = "");

    public async Task<MkLotListResult> GetMkLotListAsync(string carrierId, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,    "01.00");
            req.AddString(Tags.CarrierId, carrierId);
            var raw = await mq.SendMessageAsync("lot_.relationmklotlist", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new MkLotListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("MK_LOT_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new MkLotItem(
                m.GetString("MK_LOT_ID"),
                m.GetString("CF_LOT_ID"),
                m.GetString("TP_LOT_ID"),
                m.GetString("MK_CARRIER_ID"),
                m.GetString("CF_CARRIER_ID"),
                m.GetString("TP_CARRIER_ID"),
                m.GetString(Tags.BatchId),
                m.GetString("STATUS"),
                m.GetString("EVAP_DATE"))).ToList();
            return new MkLotListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetMkLotListAsync failed.");
            return new MkLotListResult(false, $"通信エラー: {ex.Message}");
        }
    }

    public async Task<BatchInfoResult> GetBatchInfoAsync(string batchId, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, "01.00");
            req.AddString(Tags.BatchId, batchId);
            var raw = await mq.SendMessageAsync("lot_.cfrelationjbatchinf", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new BatchInfoResult(false, res.GetErrorInfo().Message);
            return new BatchInfoResult(true, "",
                res.GetString(Tags.BatchId),
                res.GetString(Tags.WpId),
                res.GetString("RECIPE_ID"),
                res.GetString("START_DATE"),
                res.GetString("END_DATE"),
                res.GetString("STATUS"));
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetBatchInfoAsync failed.");
            return new BatchInfoResult(false, $"通信エラー: {ex.Message}");
        }
    }
}
