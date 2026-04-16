namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN01I0 部材履歴</summary>
public class PartsHistoryService(ITfMessageClient mq, ILogger<PartsHistoryService> logger)
{
    public record HistoryResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<HistoryItem>? Items = null);
    public record HistoryItem(
        string No, string DateTime, string StockLotId, string ProdLotId, string ShipLotId,
        string EventClass, string EventName, string PartName, string VendClass, string WpId);

    public async Task<HistoryResult> GetHistoryAsync(
        string fromDate, string toDate, string partId,
        CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,   "01.00");
            req.AddString("FROM_DATE",   fromDate);
            req.AddString("TO_DATE",     toDate);
            req.AddString("PART_ID",     partId);
            var raw = await mq.SendMessageAsync("inv_.history_", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new HistoryResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("HISTORY_LIST") ?? new TfMsgAry();
            var items = ary.Select((m, i) => new HistoryItem(
                (i + 1).ToString(),
                m.GetString("EVENT_DATE"),
                m.GetString("STOCK_LOT_ID"),
                m.GetString("PROD_LOT_ID"),
                m.GetString("SHIP_LOT_ID"),
                m.GetString("EVENT_CLASS"),
                m.GetString("EVENT_NAME"),
                m.GetString("PART_NAME"),
                m.GetString("VEND_CLASS"),
                m.GetString(Tags.WpId))).ToList();
            return new HistoryResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetHistoryAsync failed.");
            return new HistoryResult(false, $"通信エラー: {ex.Message}");
        }
    }
}
