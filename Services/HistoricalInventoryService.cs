namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN01Y0 過去在庫一覧</summary>
public class HistoricalInventoryService(ITfMessageClient mq, ILogger<HistoricalInventoryService> logger)
{
    public record SnapshotListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<SnapshotItem>? Items = null);
    public record SnapshotItem(
        string LotId, string CarrierId, string PdId, string PdName,
        string FlowClass, string OpId, string StepId, string WpId, string WpName,
        string SnapshotDate, string WfNum, string Status);

    public async Task<SnapshotListResult> GetSnapshotListAsync(
        string fromDate, string toDate, string pdId, string opId,
        CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, "01.00");
            req.AddString("FROM_DATE", fromDate);
            req.AddString("TO_DATE",   toDate);
            req.AddString(Tags.PdId,   pdId);
            req.AddString(Tags.OpId,   opId);
            var raw = await mq.SendMessageAsync("lot_.snapshotlist", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new SnapshotListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("SNAPSHOT_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new SnapshotItem(
                m.GetString(Tags.LotId),
                m.GetString(Tags.CarrierId),
                m.GetString(Tags.PdId),
                m.GetString("PD_NAME"),
                m.GetString("FLOW_CLASS"),
                m.GetString(Tags.OpId),
                m.GetString(Tags.StepId),
                m.GetString(Tags.WpId),
                m.GetString("WP_NAME"),
                m.GetString("SNAPSHOT_DATE"),
                m.GetString("WF_NUM"),
                m.GetString("STATUS"))).ToList();
            return new SnapshotListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetSnapshotListAsync failed.");
            return new SnapshotListResult(false, $"通信エラー: {ex.Message}");
        }
    }
}
