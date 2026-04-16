namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN01H0 謚募・遘ｻ霈我ｸ隕ｧ</summary>
public class ThrowInTransferListService(ITfMessageClient mq, ILogger<ThrowInTransferListService> logger)
{
    public record ListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<TransferItem>? Items = null);
    public record TransferItem(
        string No, string ThrowinDate, string PdId, string PdName,
        string LotId, string CarrierId, string SbId,
        string OpId, string StepId, string WpId, string WpName,
        string FlowClass, string MsgVer);

    public record ForcedMoveResult(bool IsSuccess, string ErrorMessage = "");

    public async Task<ListResult> GetListAsync(string sbId, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, "01.00");
            req.AddString("SB_ID",    sbId);
            var raw = await mq.SendMessageAsync("lot_.uncarrylist", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new ListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("LOT_LIST") ?? new TfMsgAry();
            var items = ary.Select((m, i) => new TransferItem(
                (i + 1).ToString(),
                m.GetString("THROWIN_DATE"),
                m.GetString(Tags.PdId),
                m.GetString("PD_NAME"),
                m.GetString(Tags.LotId),
                m.GetString(Tags.CarrierId),
                m.GetString("SB_ID"),
                m.GetString(Tags.OpId),
                m.GetString(Tags.StepId),
                m.GetString(Tags.WpId),
                m.GetString("WP_NAME"),
                m.GetString("FLOW_CLASS"),
                m.GetString(Tags.MsgVer))).ToList();
            return new ListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetListAsync failed.");
            return new ListResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }

    public async Task<ForcedMoveResult> ForcedMoveAsync(
        string sbId, string lotId, string empId, string wpId, string msgVer,
        CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, msgVer);
            req.AddString("SB_ID",    sbId);
            req.AddString(Tags.LotId, lotId);
            req.AddString(Tags.EmpId, empId);
            req.AddString(Tags.WpId,  wpId);
            var raw = await mq.SendMessageAsync("lot_.forcedmove", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new ForcedMoveResult(false, res.GetErrorInfo().Message)
                : new ForcedMoveResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ForcedMoveAsync failed.");
            return new ForcedMoveResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }
}
