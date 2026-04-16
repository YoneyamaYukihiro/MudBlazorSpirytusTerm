namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN02V0 闥ｸ逹繝槭せ繧ｯ邨・ｫ・/summary>
public class VaporDepositionMaskService(ITfMessageClient mq, ILogger<VaporDepositionMaskService> logger)
{
    public record JigUseCheckResult(bool IsSuccess, string ErrorMessage = "",
        string MsgCode = "", string GuidMsg = "");

    public record MaskSetResult(bool IsSuccess, string ErrorMessage = "");

    public record MaskItem(string GuideId, string MaskId);

    public async Task<JigUseCheckResult> CheckJigUseAsync(
        string jigId, string jJigCategory, string classDivision,
        string msgVer = "01.00", CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,       msgVer);
            req.AddString("JIG_ID",          jigId);
            req.AddString("J_JIG_CATEGORY",  jJigCategory);
            req.AddString("CLASS_DIVISION",  classDivision);
            var raw = await mq.SendMessageAsync("jig_.jusechk", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new JigUseCheckResult(false, res.GetErrorInfo().Message);
            return new JigUseCheckResult(true, "",
                res.GetString("MSG_CODE"),
                res.GetString("MSG"));
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "CheckJigUseAsync failed.");
            return new JigUseCheckResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }

    public async Task<MaskSetResult> SetMaskAsync(
        string empId, string jigStatus, string jigEventId,
        IReadOnlyList<MaskItem> masks, string msgVer, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,   msgVer);
            req.AddString("JIG_STATUS",  jigStatus);
            req.AddString("JIG_EVENT_ID",jigEventId);
            req.AddString(Tags.EmpId,    empId);
            var maskAry = new TfMsgAry();
            foreach (var mask in masks)
            {
                var m = new TfMsg();
                m.AddString("GUIDE_ID", mask.GuideId);
                m.AddString("MASK_ID",  mask.MaskId);
                maskAry.Add(m);
            }
            req.AddMsgAry("J_MASK_SET_LIST", maskAry);
            var raw = await mq.SendMessageAsync("jig_.jmaskset", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new MaskSetResult(false, res.GetErrorInfo().Message)
                : new MaskSetResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "SetMaskAsync failed.");
            return new MaskSetResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }
}
