namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN02T0 Aキャリア管琁E/summary>
public class ACarrierManagementService(ITfMessageClient mq, ILogger<ACarrierManagementService> logger)
{
    public record ACarrierStatusResult(bool IsSuccess, string ErrorMessage = "",
        string ACarrierId = "", string ACarrierStatId = "", string ACarrierClass = "",
        string EmptyFlag = "", string CleanFlag = "", string CleanCount = "",
        string WashUseNum = "", string WashUseLimit = "", string UseNum = "", string UseLimit = "",
        string TapeStickBatchId = "", string OvenBatchId = "", string AldBatchId = "",
        IReadOnlyList<ATraySlotItem>? ATrayList = null);

    public record ATraySlotItem(
        string ATrayId, string ATrayStatus, string ATrayStatusName,
        string ATrayClass, string TapeStickGroup,
        string WashUseNum, string WashUseLimit, string UseNum, string UseLimit,
        string SlotPosition, string CleanCount);

    public record ChangeATrayResult(bool IsSuccess, string ErrorMessage = "");

    public async Task<ACarrierStatusResult> GetACarrierStatusAsync(
        string aCarrierId, string msgVer = "01.00", CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,     msgVer);
            req.AddString("A_CARRIER_ID",  aCarrierId);
            var raw = await mq.SendMessageAsync("carr.acarstat", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new ACarrierStatusResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("A_TRAY_LIST") ?? new TfMsgAry();
            var trayList = ary.Select(m => new ATraySlotItem(
                m.GetString("A_TRAY_ID"),
                m.GetString("A_TRAY_STATUS"),
                m.GetString("A_TRAY_STATUS_NAME"),
                m.GetString("A_TRAY_CLASS"),
                m.GetString("TAPE_STICK_GROUP"),
                m.GetString("WASH_USE_NUM"),
                m.GetString("WASH_USE_LIMIT"),
                m.GetString("USE_NUM"),
                m.GetString("USE_LIMIT"),
                m.GetString("SLOT_POSITION"),
                m.GetString("CLEAN_COUNT"))).ToList();

            return new ACarrierStatusResult(true, "",
                res.GetString("A_CARRIER_ID"),
                res.GetString("CARRIER_STAT_ID"),
                res.GetString("A_CARRIER_CLASS"),
                res.GetString("EMPTY_FLAG"),
                res.GetString("CLEAN_FLAG"),
                res.GetString("CLEAN_COUNT"),
                res.GetString("WASH_USE_NUM"),
                res.GetString("WASH_USE_LIMIT"),
                res.GetString("USE_NUM"),
                res.GetString("USE_LIMIT"),
                res.GetString("TAPE_STICK_BATCH_ID"),
                res.GetString("OVEN_BATCH_ID"),
                res.GetString("ALD_BATCH_ID"),
                trayList);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetACarrierStatusAsync failed.");
            return new ACarrierStatusResult(false, $"通信エラー: {ex.Message}");
        }
    }

    public async Task<ChangeATrayResult> ChangeATrayAsync(
        string aCarrierId, string aCarrierClass, string empId,
        IReadOnlyList<(string aTrayId, string slotPosition)> trays,
        string msgVer, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,    msgVer);
            req.AddString("A_CARRIER_ID", aCarrierId);
            req.AddString("A_CARRIER_CLASS", aCarrierClass);
            req.AddString(Tags.EmpId,     empId);
            var trayAry = new TfMsgAry();
            foreach (var (aTrayId, slotPosition) in trays)
            {
                var m = new TfMsg();
                m.AddString("A_TRAY_ID",    aTrayId);
                m.AddString("SLOT_POSITION",slotPosition);
                trayAry.Add(m);
            }
            req.AddMsgAry("A_TRAY_LIST", trayAry);
            var raw = await mq.SendMessageAsync("carr.chgatray", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new ChangeATrayResult(false, res.GetErrorInfo().Message)
                : new ChangeATrayResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ChangeATrayAsync failed.");
            return new ChangeATrayResult(false, $"通信エラー: {ex.Message}");
        }
    }
}
