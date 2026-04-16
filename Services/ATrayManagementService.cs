namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN02S0 Aトレー管琁E/summary>
public class ATrayManagementService(ITfMessageClient mq, ILogger<ATrayManagementService> logger)
{
    public record ATrayListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<ATrayItem>? Items = null);
    public record ATrayItem(
        string ATrayId, string ATrayStatus, string ATrayClass,
        string TapeStickGroup, string StartTime, string CleanTime,
        string WashUseNum, string WashUseLimit, string UseNum, string UseLimit,
        string ACarrierId, string SlotPosition, string EmpName, string EditTime, string Comments);

    public record RegistResult(bool IsSuccess, string ErrorMessage = "");

    public record RegistItem(
        string ATrayId, string ATrayClass, string TapeStickGroup,
        string WashUseLimit, string UseLimit, string Comments);

    public async Task<ATrayListResult> GetATrayListAsync(
        string atrayId = "", string msgVer = "01.00", CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, msgVer);
            req.AddString("A_TRAY_ID", atrayId);
            var raw = await mq.SendMessageAsync("atray.list____", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new ATrayListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("A_TRAY_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new ATrayItem(
                m.GetString("A_TRAY_ID"),
                m.GetString("A_TRAY_STATUS"),
                m.GetString("A_TRAY_CLASS"),
                m.GetString("TAPE_STICK_GROUP"),
                m.GetString("START_TIME"),
                m.GetString("CLEAN_TIME"),
                m.GetString("WASH_USE_NUM"),
                m.GetString("WASH_USE_LIMIT"),
                m.GetString("USE_NUM"),
                m.GetString("USE_LIMIT"),
                m.GetString("A_CARRIER_ID"),
                m.GetString("SLOT_POSITION"),
                m.GetString("EMP_NAME"),
                m.GetString("EDIT_TIME"),
                m.GetString("COMMENTS"))).ToList();
            return new ATrayListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetATrayListAsync failed.");
            return new ATrayListResult(false, $"通信エラー: {ex.Message}");
        }
    }

    public async Task<RegistResult> RegistATrayAsync(
        string classDiv, string empId, IReadOnlyList<RegistItem> trays,
        string msgVer, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,      msgVer);
            req.AddString(Tags.EmpId,       empId);
            req.AddString("CLASS_DIVISION", classDiv);
            var trayAry = new TfMsgAry();
            foreach (var t in trays)
            {
                var m = new TfMsg();
                m.AddString("A_TRAY_ID",        t.ATrayId);
                m.AddString("A_TRAY_CLASS",      t.ATrayClass);
                m.AddString("TAPE_STICK_GROUP",  t.TapeStickGroup);
                m.AddString("WASH_USE_LIMIT",    t.WashUseLimit);
                m.AddString("USE_LIMIT",         t.UseLimit);
                m.AddString("COMMENTS",          t.Comments);
                trayAry.Add(m);
            }
            req.AddMsgAry("A_TRAY_LIST", trayAry);
            var raw = await mq.SendMessageAsync("atray.regist__", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new RegistResult(false, res.GetErrorInfo().Message)
                : new RegistResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "RegistATrayAsync failed.");
            return new RegistResult(false, $"通信エラー: {ex.Message}");
        }
    }
}
