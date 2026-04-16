using MudBlazorSpirytusTerm.Services;

namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN01E0 在庫移輁E/summary>
public class InventoryTransferService(ITfMessageClient mq, ILogger<InventoryTransferService> logger)
{
    public record MoveInfoResult(
        bool IsSuccess, string ErrorMessage = "",
        string LotId = "", string CarrierId = "", string PdId = "", string PdName = "",
        string NowSt = "", string OpId = "", string StepId = "", string WpId = "",
        string FlowClass = "", string LotLastUpdate = "",
        IReadOnlyList<WaferItem>? Wafers = null);

    public record WaferItem(string WfNo, string WfStatus, string WfStatusName);

    public record MoveResult(bool IsSuccess, string ErrorMessage = "");

    public async Task<MoveInfoResult> GetMoveInfoAsync(string carrierId, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,    "01.00");
            req.AddString(Tags.CarrierId, carrierId);
            var raw = await mq.SendMessageAsync("inv_.moveinfo", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new MoveInfoResult(false, res.GetErrorInfo().Message);

            var wfAry = res.GetMsgAry("WF_LIST") ?? new TfMsgAry();
            var wafers = wfAry.Select(m => new WaferItem(
                m.GetString("WF_NO"), m.GetString("WF_STATUS"), m.GetString("WF_STATUS_NAME"))).ToList();

            return new MoveInfoResult(true, "",
                res.GetString(Tags.LotId),
                res.GetString(Tags.CarrierId),
                res.GetString(Tags.PdId),
                res.GetString("PD_NAME"),
                res.GetString("NOW_ST"),
                res.GetString(Tags.OpId),
                res.GetString(Tags.StepId),
                res.GetString(Tags.WpId),
                res.GetString("FLOW_CLASS"),
                res.GetString(Tags.LotLastUpdate),
                wafers);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetMoveInfoAsync failed.");
            return new MoveInfoResult(false, $"通信エラー: {ex.Message}");
        }
    }

    public async Task<MoveResult> MoveAsync(
        string fromCarrierId, string toCarrierId, string empId,
        string lotLastUpdate, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,        "01.00");
            req.AddString(Tags.CarrierId,     fromCarrierId);
            req.AddString("TO_CARRIER_ID",    toCarrierId);
            req.AddString(Tags.EmpId,         empId);
            req.AddString(Tags.LotLastUpdate, lotLastUpdate);
            var raw = await mq.SendMessageAsync("inv_.move____", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new MoveResult(false, res.GetErrorInfo().Message)
                : new MoveResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "MoveAsync failed.");
            return new MoveResult(false, $"通信エラー: {ex.Message}");
        }
    }
}
