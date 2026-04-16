namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN02K0 CONT繧ｨ繝・メ繝｣繝ｼFR菴ｿ逕ｨ螻･豁ｴ</summary>
public class FrUsageHistoryService(ITfMessageClient mq, ILogger<FrUsageHistoryService> logger)
{
    public record HistListResult(bool IsSuccess, string ErrorMessage = "",
        string RfRefValueTime = "", string WarMsgTime = "", string ErrMsgTime = "",
        string WpId = "", string ProcessingId = "",
        IReadOnlyList<HistItem>? Items = null);

    public record HistItem(
        string FrId, string LotId, string RecipeId, string AcceleFactor,
        string CumProcTime, string ProcTime, string CalcCumProcTime,
        string EntryTime, string EmpName);

    public record RegisterResult(bool IsSuccess, string ErrorMessage = "");

    public async Task<HistListResult> GetHistListAsync(
        string wpId, string processingId, string msgVer = "01.00",
        CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,     msgVer);
            req.AddString(Tags.WpId,       wpId);
            req.AddString("PROCESSING_ID", processingId);
            var raw = await mq.SendMessageAsync("fb__.contetfrhist", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new HistListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("FR_HIST_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new HistItem(
                m.GetString("FR_ID"),
                m.GetString(Tags.LotId),
                m.GetString("RECIPE_ID"),
                m.GetString("ACCELE_FACTER"),
                m.GetString("CUMULATIVE_PROCESS_TIME"),
                m.GetString("PROCESS_TIME"),
                m.GetString("CALC_CUMULATIVE_PROCESS_TIME"),
                m.GetString("ENTRY_TIME"),
                m.GetString("EMP_NAME"))).ToList();

            return new HistListResult(true, "",
                res.GetString("FR_REFVAL"),
                res.GetString("WAR_MSG_TIME"),
                res.GetString("ERR_MSG_TIME"),
                res.GetString(Tags.WpId),
                res.GetString("PROCESSING_ID"),
                items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetHistListAsync failed.");
            return new HistListResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }

    public async Task<RegisterResult> RegisterAsync(
        string wpId, string processingId, string lotId, string recipeId,
        string acceleFactor, string cumProcTime, string procTime, string calcCumProcTime,
        string empId, string msgVer, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,              msgVer);
            req.AddString(Tags.WpId,                wpId);
            req.AddString("PROCESSING_ID",          processingId);
            req.AddString(Tags.LotId,               lotId);
            req.AddString("RECIPE_ID",              recipeId);
            req.AddString("ACCELE_FACTER",          acceleFactor);
            req.AddString("CUMULATIVE_PROCESS_TIME",cumProcTime);
            req.AddString("PROCESS_TIME",           procTime);
            req.AddString("CALC_CUMULATIVE_PROCESS_TIME", calcCumProcTime);
            req.AddString(Tags.EmpId,               empId);
            var raw = await mq.SendMessageAsync("fb__.contetfrhistreg", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new RegisterResult(false, res.GetErrorInfo().Message)
                : new RegisterResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "RegisterAsync failed.");
            return new RegisterResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }
}
