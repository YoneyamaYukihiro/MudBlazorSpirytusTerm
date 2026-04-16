namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN0210 部材受入</summary>
public class PartsReceiptService(ITfMessageClient mq, ILogger<PartsReceiptService> logger)
{
    public record AcceptResult(bool IsSuccess, string ErrorMessage = "", string StockLotId = "");

    public async Task<AcceptResult> AcceptAsync(
        string partId, string vendClass, string lotNo, string acceptNum,
        string empId, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,   "01.00");
            req.AddString("PART_ID",     partId);
            req.AddString("VEND_CLASS",  vendClass);
            req.AddString("LOT_NO",      lotNo);
            req.AddString("ACCEPT_NUM",  acceptNum);
            req.AddString(Tags.EmpId,    empId);
            var raw = await mq.SendMessageAsync("inv_.accept__", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new AcceptResult(false, res.GetErrorInfo().Message);
            return new AcceptResult(true, "", res.GetString("STOCK_LOT_ID"));
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "AcceptAsync failed.");
            return new AcceptResult(false, $"通信エラー: {ex.Message}");
        }
    }
}
