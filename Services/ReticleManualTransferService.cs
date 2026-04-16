namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN01M0 レチクルマニュアル搬送E/summary>
public class ReticleManualTransferService(ITfMessageClient mq, ILogger<ReticleManualTransferService> logger)
{
    public record ReticleListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<ReticleItem>? Items = null);
    public record ReticleItem(string ReticleId, string ReticleName, string StatusName, string Location, string WpId);

    public record WpListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<WpItem>? Items = null);
    public record WpItem(string WpId, string WpName, string PortId);

    public record TransferResult(bool IsSuccess, string ErrorMessage = "");

    public async Task<ReticleListResult> GetReticleListAsync(string stockerId, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,   "01.00");
            req.AddString("STOCKER_ID",  stockerId);
            var raw = await mq.SendMessageAsync("rtcl.list____", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new ReticleListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("RETICLE_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new ReticleItem(
                m.GetString("RETICLE_ID"),
                m.GetString("RETICLE_NAME"),
                m.GetString("STATUS_NAME"),
                m.GetString("LOCATION"),
                m.GetString(Tags.WpId))).ToList();
            return new ReticleListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetReticleListAsync failed.");
            return new ReticleListResult(false, $"通信エラー: {ex.Message}");
        }
    }

    public async Task<TransferResult> ReticleWpOutAsync(
        string reticleId, string fromWpId, string empId,
        CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,   "01.00");
            req.AddString("RETICLE_ID",  reticleId);
            req.AddString(Tags.WpId,     fromWpId);
            req.AddString(Tags.EmpId,    empId);
            var raw = await mq.SendMessageAsync("rtcl.wpout___", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new TransferResult(false, res.GetErrorInfo().Message)
                : new TransferResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ReticleWpOutAsync failed.");
            return new TransferResult(false, $"通信エラー: {ex.Message}");
        }
    }
}
