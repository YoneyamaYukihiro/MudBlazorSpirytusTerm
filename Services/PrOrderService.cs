namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN01S0 P/Rオーダー管琁E/summary>
public class PrOrderService(ITfMessageClient mq, ILogger<PrOrderService> logger)
{
    public record OrderListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<OrderItem>? Items = null);
    public record OrderItem(
        string OrderId, string OrderDate, string CostCode, string GlobalDept,
        string PartName, string Qty, string Status, string MsgVer);

    public record ChangeOrderResult(bool IsSuccess, string ErrorMessage = "");

    public async Task<OrderListResult> GetOrderListAsync(string fromDate, string toDate, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,  "01.00");
            req.AddString("FROM_DATE",  fromDate);
            req.AddString("TO_DATE",    toDate);
            var raw = await mq.SendMessageAsync("pr__.orderlist", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new OrderListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("ORDER_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new OrderItem(
                m.GetString("ORDER_ID"),
                m.GetString("ORDER_DATE"),
                m.GetString("COST_CODE"),
                m.GetString("GLOBAL_DEPT"),
                m.GetString("PART_NAME"),
                m.GetString("QTY"),
                m.GetString("STATUS"),
                m.GetString(Tags.MsgVer))).ToList();
            return new OrderListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetOrderListAsync failed.");
            return new OrderListResult(false, $"通信エラー: {ex.Message}");
        }
    }

    public async Task<ChangeOrderResult> ChangeOrderAsync(
        string orderId, string costCode, string globalDept,
        string empId, string msgVer, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,    msgVer);
            req.AddString("ORDER_ID",     orderId);
            req.AddString("COST_CODE",    costCode);
            req.AddString("GLOBAL_DEPT",  globalDept);
            req.AddString(Tags.EmpId,     empId);
            var raw = await mq.SendMessageAsync("pr__.chgorder", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new ChangeOrderResult(false, res.GetErrorInfo().Message)
                : new ChangeOrderResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ChangeOrderAsync failed.");
            return new ChangeOrderResult(false, $"通信エラー: {ex.Message}");
        }
    }
}
