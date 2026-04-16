namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN02E0 MK繝ｭ繝・ヨ邱ｨ謌・CF)</summary>
public class MkLotCompositionCfService(ITfMessageClient mq, ILogger<MkLotCompositionCfService> logger)
{
    public record ChipMoveInfoResult(
        bool IsSuccess, string ErrorMessage = "",
        string LotId = "", string CarrierId = "", string PdId = "",
        string OpId = "", string StepId = "", string WpId = "",
        string LotLastUpdate = "", IReadOnlyList<ChipItem>? Chips = null);

    public record ChipItem(string SlotNo, string WfNo, string ChipNo, string Status, string StatusName);

    public record ChipMoveResult(bool IsSuccess, string ErrorMessage = "");

    public async Task<ChipMoveInfoResult> GetChipMoveInfoAsync(string carrierId, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,    "01.00");
            req.AddString(Tags.CarrierId, carrierId);
            var raw = await mq.SendMessageAsync("lot_.cfchipmoveinfo", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new ChipMoveInfoResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("CHIP_LIST") ?? new TfMsgAry();
            var chips = ary.Select(m => new ChipItem(
                m.GetString("SLOT_NO"),
                m.GetString("WF_NO"),
                m.GetString("CHIP_NO"),
                m.GetString("STATUS"),
                m.GetString("STATUS_NAME"))).ToList();

            return new ChipMoveInfoResult(true, "",
                res.GetString(Tags.LotId),
                res.GetString(Tags.CarrierId),
                res.GetString(Tags.PdId),
                res.GetString(Tags.OpId),
                res.GetString(Tags.StepId),
                res.GetString(Tags.WpId),
                res.GetString(Tags.LotLastUpdate),
                chips);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetChipMoveInfoAsync failed.");
            return new ChipMoveInfoResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }

    public async Task<ChipMoveResult> ChipMoveAsync(
        string lotId, string empId, string lotLastUpdate,
        IReadOnlyList<(string slotNo, string wfNo)> chips,
        CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,        "01.00");
            req.AddString(Tags.LotId,         lotId);
            req.AddString(Tags.EmpId,         empId);
            req.AddString(Tags.LotLastUpdate, lotLastUpdate);
            var chipAry = new TfMsgAry();
            foreach (var (slotNo, wfNo) in chips)
            {
                var m = new TfMsg();
                m.AddString("SLOT_NO", slotNo);
                m.AddString("WF_NO",   wfNo);
                chipAry.Add(m);
            }
            req.AddMsgAry("CHIP_LIST", chipAry);
            var raw = await mq.SendMessageAsync("lot_.cfchipmove", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new ChipMoveResult(false, res.GetErrorInfo().Message)
                : new ChipMoveResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ChipMoveAsync failed.");
            return new ChipMoveResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }
}
