namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN02C0 MK繝ｭ繝・ヨ邱ｨ謌・/summary>
public class MkLotCompositionService(ITfMessageClient mq, ILogger<MkLotCompositionService> logger)
{
    public record PartListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<PartItem>? Items = null);
    public record PartItem(string StockLotId, string PartId, string PartName, string StockNum, string Status);

    public record CompositionResult(bool IsSuccess, string ErrorMessage = "", string MkLotId = "");

    public async Task<PartListResult> GetMkPartListAsync(string wpId, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, "01.00");
            req.AddString(Tags.WpId,   wpId);
            var raw = await mq.SendMessageAsync("mas_.mktocfpartlist", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new PartListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("PART_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new PartItem(
                m.GetString("STOCK_LOT_ID"),
                m.GetString("PART_ID"),
                m.GetString("PART_NAME"),
                m.GetString("STOCK_NUM"),
                m.GetString("STATUS"))).ToList();
            return new PartListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetMkPartListAsync failed.");
            return new PartListResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }

    public async Task<CompositionResult> ComposeMkLotAsync(
        string carrierId, string wpId, string empId,
        IReadOnlyList<string> stockLotIds, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,    "01.00");
            req.AddString(Tags.CarrierId, carrierId);
            req.AddString(Tags.WpId,      wpId);
            req.AddString(Tags.EmpId,     empId);
            var ary = new TfMsgAry();
            foreach (var id in stockLotIds)
            {
                var m = new TfMsg();
                m.AddString("STOCK_LOT_ID", id);
                ary.Add(m);
            }
            req.AddMsgAry("PART_LIST", ary);
            var raw = await mq.SendMessageAsync("inv_.mktocfpartlist", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new CompositionResult(false, res.GetErrorInfo().Message);
            return new CompositionResult(true, "", res.GetString(Tags.LotId));
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ComposeMkLotAsync failed.");
            return new CompositionResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }
}
