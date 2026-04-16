namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN0270 アクション予紁E/summary>
public class ActionReservationService(ITfMessageClient mq, ILogger<ActionReservationService> logger)
{
    public record ActionInfoResult(bool IsSuccess, string ErrorMessage = "",
        string LotId = "", string CarrierId = "", string PdId = "",
        string OpId = "", string StepId = "", string WpId = "",
        string LotLastUpdate = "", IReadOnlyList<ActionItem>? Actions = null);

    public record ActionItem(string ActionId, string ActionName, string ActionClass, string ScheduleDate);

    public record ReserveResult(bool IsSuccess, string ErrorMessage = "");
    public record DeleteResult(bool IsSuccess, string ErrorMessage = "");

    public async Task<ActionInfoResult> GetActionInfoAsync(string carrierId, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,    "01.00");
            req.AddString(Tags.CarrierId, carrierId);
            var raw = await mq.SendMessageAsync("lot_.actinfo_", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new ActionInfoResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("ACTION_LIST") ?? new TfMsgAry();
            var actions = ary.Select(m => new ActionItem(
                m.GetString("ACTION_ID"),
                m.GetString("ACTION_NAME"),
                m.GetString("ACTION_CLASS"),
                m.GetString("SCHEDULE_DATE"))).ToList();

            return new ActionInfoResult(true, "",
                res.GetString(Tags.LotId),
                res.GetString(Tags.CarrierId),
                res.GetString(Tags.PdId),
                res.GetString(Tags.OpId),
                res.GetString(Tags.StepId),
                res.GetString(Tags.WpId),
                res.GetString(Tags.LotLastUpdate),
                actions);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetActionInfoAsync failed.");
            return new ActionInfoResult(false, $"通信エラー: {ex.Message}");
        }
    }

    public async Task<ReserveResult> ReserveAsync(
        string lotId, string actionId, string scheduleDate,
        string empId, string lotLastUpdate, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,        "01.00");
            req.AddString(Tags.LotId,         lotId);
            req.AddString("ACTION_ID",        actionId);
            req.AddString("SCHEDULE_DATE",    scheduleDate);
            req.AddString(Tags.EmpId,         empId);
            req.AddString(Tags.LotLastUpdate, lotLastUpdate);
            var raw = await mq.SendMessageAsync("lot_.actrsv__", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new ReserveResult(false, res.GetErrorInfo().Message)
                : new ReserveResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ReserveAsync failed.");
            return new ReserveResult(false, $"通信エラー: {ex.Message}");
        }
    }

    public async Task<DeleteResult> DeleteAsync(
        string lotId, string actionId, string empId, string lotLastUpdate,
        CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,        "01.00");
            req.AddString(Tags.LotId,         lotId);
            req.AddString("ACTION_ID",        actionId);
            req.AddString(Tags.EmpId,         empId);
            req.AddString(Tags.LotLastUpdate, lotLastUpdate);
            var raw = await mq.SendMessageAsync("lot_.delact__", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new DeleteResult(false, res.GetErrorInfo().Message)
                : new DeleteResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "DeleteAsync failed.");
            return new DeleteResult(false, $"通信エラー: {ex.Message}");
        }
    }
}
