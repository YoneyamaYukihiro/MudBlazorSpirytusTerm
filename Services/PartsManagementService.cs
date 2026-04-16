namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN0230 部材管琁E/summary>
public class PartsManagementService(ITfMessageClient mq, ILogger<PartsManagementService> logger)
{
    public record PartListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<PartItem>? Items = null);
    public record PartItem(
        string StockLotId, string PartId, string PartName, string VendClass,
        string Status, string StatusName, string StockNum, string AcceptDate, string MsgVer);

    public record ChangeStateResult(bool IsSuccess, string ErrorMessage = "");

    public async Task<PartListResult> GetPartListAsync(string partId, string status, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, "01.00");
            req.AddString("PART_ID",   partId);
            req.AddString("STATUS",    status);
            var raw = await mq.SendMessageAsync("inv_.partlist", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new PartListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("PART_LOT_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new PartItem(
                m.GetString("STOCK_LOT_ID"),
                m.GetString("PART_ID"),
                m.GetString("PART_NAME"),
                m.GetString("VEND_CLASS"),
                m.GetString("STATUS"),
                m.GetString("STATUS_NAME"),
                m.GetString("STOCK_NUM"),
                m.GetString("ACCEPT_DATE"),
                m.GetString(Tags.MsgVer))).ToList();
            return new PartListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetPartListAsync failed.");
            return new PartListResult(false, $"通信エラー: {ex.Message}");
        }
    }

    public async Task<ChangeStateResult> ChangeStateAsync(
        string stockLotId, string newStatus, string reasonCode,
        string empId, string msgVer, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,    msgVer);
            req.AddString("STOCK_LOT_ID", stockLotId);
            req.AddString("NEW_STATUS",   newStatus);
            req.AddString("REASON_CODE",  reasonCode);
            req.AddString(Tags.EmpId,     empId);
            var raw = await mq.SendMessageAsync("inv_.chgstate", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new ChangeStateResult(false, res.GetErrorInfo().Message)
                : new ChangeStateResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ChangeStateAsync failed.");
            return new ChangeStateResult(false, $"通信エラー: {ex.Message}");
        }
    }
}
