namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN01Z0 陬・ｽｮ繝｡繝ｳ繝・リ繝ｳ繧ｹ險倬鹸逾ｨ荳隕ｧ</summary>
public class MaintenanceRecordService(ITfMessageClient mq, ILogger<MaintenanceRecordService> logger)
{
    public record RecordListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<RecordItem>? Items = null);
    public record RecordItem(
        string RecordId, string WpId, string WpName, string CategoryId, string CategoryName,
        string RecordDate, string EmpId, string EmpName, string Status, string Comments);

    public record RepairListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<RepairItem>? Items = null);
    public record RepairItem(
        string RepairId, string WpId, string WpName, string FailureDate,
        string RepairDate, string EmpId, string EmpName, string FailureContent, string Status);

    public async Task<RecordListResult> GetPreserveListAsync(
        string fromDate, string toDate, string wpId,
        CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, "01.00");
            req.AddString("FROM_DATE", fromDate);
            req.AddString("TO_DATE",   toDate);
            req.AddString(Tags.WpId,   wpId);
            var raw = await mq.SendMessageAsync("pre_.preservelist", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new RecordListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("PRESERVE_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new RecordItem(
                m.GetString("PRESERVE_ID"),
                m.GetString(Tags.WpId),
                m.GetString("WP_NAME"),
                m.GetString("CATEGORY_ID"),
                m.GetString("CATEGORY_NAME"),
                m.GetString("PRESERVE_DATE"),
                m.GetString(Tags.EmpId),
                m.GetString("EMP_NAME"),
                m.GetString("STATUS"),
                m.GetString(Tags.Comments))).ToList();
            return new RecordListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetPreserveListAsync failed.");
            return new RecordListResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }

    public async Task<RepairListResult> GetRepairListAsync(
        string fromDate, string toDate, string wpId,
        CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, "01.00");
            req.AddString("FROM_DATE", fromDate);
            req.AddString("TO_DATE",   toDate);
            req.AddString(Tags.WpId,   wpId);
            var raw = await mq.SendMessageAsync("rep_.repairlist", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new RepairListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("REPAIR_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new RepairItem(
                m.GetString("REPAIR_ID"),
                m.GetString(Tags.WpId),
                m.GetString("WP_NAME"),
                m.GetString("FAILURE_DATE"),
                m.GetString("REPAIR_DATE"),
                m.GetString(Tags.EmpId),
                m.GetString("EMP_NAME"),
                m.GetString("FAILURE_CONTENT"),
                m.GetString("STATUS"))).ToList();
            return new RepairListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetRepairListAsync failed.");
            return new RepairListResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }
}
