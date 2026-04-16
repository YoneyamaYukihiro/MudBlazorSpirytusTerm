namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN02R0 繝ｭ繝・ヨ謚募・(ALD)</summary>
public class AldLotThrowInService(ITfMessageClient mq, ILogger<AldLotThrowInService> logger)
{
    public record ThrowInResult(bool IsSuccess, string ErrorMessage = "");

    public async Task<ThrowInResult> ThrowInAsync(
        string batchId, string lotId, string pdId, string lotPriority,
        string comments, string empId, string flowClass, string entryFlag,
        string engEmpId, string classDivision, string orderNum, string entryId,
        string msgVer, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,       msgVer);
            req.AddString(Tags.BatchId,      batchId);
            req.AddString(Tags.LotId,        lotId);
            req.AddString(Tags.PdId,         pdId);
            req.AddString("LOT_PRIORITY",    lotPriority);
            req.AddString("COMMENTS",        comments);
            req.AddString(Tags.EmpId,        empId);
            req.AddString("FLOW_CLASS",      flowClass);
            req.AddString("ENTRY_FLAG",      entryFlag);
            req.AddString("ENG_EMP_ID",      engEmpId);
            req.AddString("CLASS_DIVISION",  classDivision);
            req.AddString("ORDER_NUM",       orderNum);
            req.AddString("ENTRY_ID",        entryId);
            var raw = await mq.SendMessageAsync("lot_.throwinald", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new ThrowInResult(false, res.GetErrorInfo().Message)
                : new ThrowInResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ThrowInAsync failed.");
            return new ThrowInResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }
}
