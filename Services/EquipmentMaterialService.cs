namespace MudBlazorSpirytusTerm.Services;

/// <summary>EN01V0 陬・ｽｮ菴ｿ逕ｨ驛ｨ譚千ｮ｡逅・/summary>
public class EquipmentMaterialService(ITfMessageClient mq, ILogger<EquipmentMaterialService> logger)
{
    public record MaterialListResult(bool IsSuccess, string ErrorMessage = "", IReadOnlyList<MaterialItem>? Items = null);
    public record MaterialItem(
        string MaterialId, string MaterialName, string MaterialType,
        string WpId, string WpName, string Status, string StatusName,
        string UseStartDate, string UseEndDate, string StockNum, string MsgVer);

    public record ChangeStatResult(bool IsSuccess, string ErrorMessage = "");

    public async Task<MaterialListResult> GetMaterialListAsync(string wpId, string materialType, CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,     "01.00");
            req.AddString(Tags.WpId,       wpId);
            req.AddString("MATERIAL_TYPE", materialType);
            var raw = await mq.SendMessageAsync("mat_.alllist_", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            if (res.GetString(Tags.Ret) != "0") return new MaterialListResult(false, res.GetErrorInfo().Message);

            var ary = res.GetMsgAry("MATERIAL_LIST") ?? new TfMsgAry();
            var items = ary.Select(m => new MaterialItem(
                m.GetString("MATERIAL_ID"),
                m.GetString("MATERIAL_NAME"),
                m.GetString("MATERIAL_TYPE"),
                m.GetString(Tags.WpId),
                m.GetString("WP_NAME"),
                m.GetString("STATUS"),
                m.GetString("STATUS_NAME"),
                m.GetString("USE_START_DATE"),
                m.GetString("USE_END_DATE"),
                m.GetString("STOCK_NUM"),
                m.GetString(Tags.MsgVer))).ToList();
            return new MaterialListResult(true, "", items);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetMaterialListAsync failed.");
            return new MaterialListResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }

    public async Task<ChangeStatResult> ChangeStatAsync(
        string materialId, string newStat, string empId, string msgVer,
        CancellationToken ct = default)
    {
        try
        {
            var req = new TfMsg();
            req.AddString(Tags.MsgVer,    msgVer);
            req.AddString("MATERIAL_ID",  materialId);
            req.AddString("NEW_STATUS",   newStat);
            req.AddString(Tags.EmpId,     empId);
            var raw = await mq.SendMessageAsync("mat_.chgmaterialstat", req.ToTfString(), ct);
            var res = TfMsg.ParseOrEmpty(raw);
            return res.GetString(Tags.Ret) != "0"
                ? new ChangeStatResult(false, res.GetErrorInfo().Message)
                : new ChangeStatResult(true);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ChangeStatAsync failed.");
            return new ChangeStatResult(false, $"騾壻ｿ｡繧ｨ繝ｩ繝ｼ: {ex.Message}");
        }
    }
}
