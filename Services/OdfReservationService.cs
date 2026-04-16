namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN02U0 ODF莠育ｴ・amp;陦ｨ髱｢蜃ｦ逅・ｺ育ｴ・/summary>
public class OdfReservationService(ITfMessageClient mq, ILogger<OdfReservationService> logger)
{
    public record TftCfListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<TftCfItem>? Items = null);
    public record TftCfItem(string PdId, string PdVersion, string LcDirection, string CfPdId, string CfPdVersion);

    public record OdfReserveListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<OdfReserveItem>? Items = null);
    public record OdfReserveItem(
        string PdId, string FlowClass, string LotId, string CfFlag,
        string WfId, string SlotPosition, string ReserveFlag, string CarrierId,
        string CurrentStatus, string CurrentStatusName);

    public record OdfReserveRegistResult(bool IsSuccess, string ErrorMessage = "", string HReserveFlag = "");

    public record WfPairItem(
        string WfId, string CfWfId, string LotId, string CfLotId,
        string CarrierId, string CfCarrierId, string SlotPosition);

    public record HReserveListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<HReserveItem>? Items = null);
    public record HReserveItem(
        string WfId, string CfWfId, string LotId, string CfLotId,
        string EditTime, string HReserveEmpName, string HReserveTime, string RecipeId);

    public record HReserveRegistResult(bool IsSuccess, string ErrorMessage = "");

    public async Task<TftCfListResult> GetTftCfListAsync(string msgVer = "01.00", CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, msgVer);
            var raw = await mq.SendMessageAsync("asm_.odftftcflist", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new TftCfListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("PD_ID_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new TftCfItem(
                m.GetString(Tags.PdId),
                m.GetString("PD_VERSION"),
                m.GetString("LC_DIRECTION"),
                m.GetString("CF_PD_ID"),
                m.GetString("CF_PD_VERSION"))).ToList();
            return new TftCfListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetTftCfListAsync failed.");
            return new TftCfListResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }

    public async Task<OdfReserveListResult> GetOdfReserveListAsync(
        string pdId, string cfPdId, string msgVer = "01.00", CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer, msgVer);
            req.AddString(Tags.PdId,   pdId);
            req.AddString("CF_PD_ID",  cfPdId);
            var raw = await mq.SendMessageAsync("asm_.odfreservelist", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new OdfReserveListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("WF_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new OdfReserveItem(
                m.GetString(Tags.PdId),
                m.GetString("FLOW_CLASS"),
                m.GetString(Tags.LotId),
                m.GetString("CF_FLAG"),
                m.GetString("WF_ID"),
                m.GetString("SLOT_POSITION"),
                m.GetString("RESERVE_FLAG"),
                m.GetString(Tags.CarrierId),
                m.GetString("CURRENT_STATUS"),
                m.GetString("CURRENT_STATUS_NAME"))).ToList();
            return new OdfReserveListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetOdfReserveListAsync failed.");
            return new OdfReserveListResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }

    public async Task<OdfReserveRegistResult> RegistOdfReserveAsync(
        string empId, string registType, string lotId, string cfLotId,
        IReadOnlyList<WfPairItem> wfPairs, string msgVer, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,   msgVer);
            req.AddString(Tags.EmpId,    empId);
            req.AddString("REGIST_TYPE", registType);
            req.AddString(Tags.LotId,    lotId);
            req.AddString("CF_LOT_ID",   cfLotId);
            var wfAry = new TfMsgAry();
            foreach (var w in wfPairs)
            {
                var m = new TfMsg();
                m.AddString("WF_ID",       w.WfId);
                m.AddString("CF_WF_ID",    w.CfWfId);
                m.AddString(Tags.LotId,    w.LotId);
                m.AddString("CF_LOT_ID",   w.CfLotId);
                m.AddString(Tags.CarrierId,w.CarrierId);
                m.AddString("CF_CARRIER_ID",w.CfCarrierId);
                m.AddString("SLOT_POSITION",w.SlotPosition);
                wfAry.Add(m);
            }
            req.AddMsgAry("WF_LIST", wfAry);
            var raw = await mq.SendMessageAsync("asm_.odfreserveregist", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new OdfReserveRegistResult(false, res.GetErrorInfo().Message);
            return new OdfReserveRegistResult(true, "", res.GetString("H_RESERVE_FLAG"));
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "RegistOdfReserveAsync failed.");
            return new OdfReserveRegistResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }

    public async Task<HReserveListResult> GetHReserveListAsync(
        string selectOption = "", string msgVer = "01.00", CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,   msgVer);
            req.AddString("SELECT_OPTION", selectOption);
            var raw = await mq.SendMessageAsync("asm_.hreserveinfo", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new HReserveListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("WF_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new HReserveItem(
                m.GetString("WF_ID"),
                m.GetString("CF_WF_ID"),
                m.GetString(Tags.LotId),
                m.GetString("CF_LOT_ID"),
                m.GetString("EDIT_TIME"),
                m.GetString("H_RESERVE_EMP_NAME"),
                m.GetString("H_RESERVE_TIME"),
                m.GetString("RECIPE_ID"))).ToList();
            return new HReserveListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetHReserveListAsync failed.");
            return new HReserveListResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }

    public async Task<HReserveRegistResult> RegistHReserveAsync(
        string empId, string registType,
        IReadOnlyList<(string wfId, string cfWfId, string lotId, string cfLotId)> wfPairs,
        string msgVer, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,   msgVer);
            req.AddString(Tags.EmpId,    empId);
            req.AddString("REGIST_TYPE", registType);
            var wfAry = new TfMsgAry();
            foreach (var (wfId, cfWfId, lotId, cfLotId) in wfPairs)
            {
                var m = new TfMsg();
                m.AddString("WF_ID",     wfId);
                m.AddString("CF_WF_ID",  cfWfId);
                m.AddString(Tags.LotId,  lotId);
                m.AddString("CF_LOT_ID", cfLotId);
                wfAry.Add(m);
            }
            req.AddMsgAry("WF_LIST", wfAry);
            var raw = await mq.SendMessageAsync("asm_.hreserveregist", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new HReserveRegistResult(false, res.GetErrorInfo().Message)
                : new HReserveRegistResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "RegistHReserveAsync failed.");
            return new HReserveRegistResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }
}
