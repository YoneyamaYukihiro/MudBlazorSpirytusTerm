namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN01L0 搬送モード管琁E/summary>
public class TransportModeService(ITfMessageClient mq, ILogger<TransportModeService> logger)
{
    public record ModeListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<ModeItem>? Items = null);
    public record ModeItem(string WpId, string WpName, string CurrentMode, string CurrentModeName, string MsgVer);

    public record ChangeModeResult(bool IsSuccess, string ErrorMessage = "");

    public async Task<ModeListResult> GetModeListAsync(CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, "01.00");
            var raw = await mq.SendMessageAsync("fts_.mode____", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new ModeListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("WP_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new ModeItem(
                m.GetString(Tags.WpId),
                m.GetString("WP_NAME"),
                m.GetString("TRANSFER_MODE"),
                m.GetString("TRANSFER_MODE_NAME"),
                m.GetString(Tags.MsgVer))).ToList();
            return new ModeListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetModeListAsync failed.");
            return new ModeListResult(false, $"通信エラー: {ex.Message}");
        }
    }

    public async Task<ChangeModeResult> ChangeModeAsync(
        string wpId, string newMode, string empId, string msgVer,
        CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,     msgVer);
            req.AddString(Tags.WpId,       wpId);
            req.AddString("TRANSFER_MODE", newMode);
            req.AddString(Tags.EmpId,      empId);
            var raw = await mq.SendMessageAsync("fts_.chgmodem", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new ChangeModeResult(false, res.GetErrorInfo().Message)
                : new ChangeModeResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ChangeModeAsync failed.");
            return new ChangeModeResult(false, $"通信エラー: {ex.Message}");
        }
    }
}
