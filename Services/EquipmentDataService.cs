namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN00T0 装置データ参照/登録 サービス。
/// VBソース: VB/00T0/CtsbasxxMG00T0.vb (pubblnLotCollectParams_Sel)
/// メッセージID: lot_.collectparams  (装置収集項目取得)
/// データ単位: 1=ロット, 2=WF
/// </summary>
public sealed class EquipmentDataService(ITfMessageClient mq, IConfiguration cfg, ILogger<EquipmentDataService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 型定義 ────────

    public sealed record CollectionItem(
        string ItemName,
        string CategoryId,
        string CollectionType,
        string CeidValue,
        string CurrentValue
    );

    public sealed record CollectParamsResult(
        bool   IsSuccess,
        string ErrorMessage           = "",
        string CategoryId             = "",
        string LotDataCollCompFlag    = "",
        IReadOnlyList<CollectionItem>? Items = null
    );

    // ──────── 収集項目取得 ────────

    /// <summary>
    /// 装置収集項目を取得する。
    /// VBソース: pubblnLotCollectParams_Sel, MsgId=lot_.collectparams
    /// </summary>
    public async Task<CollectParamsResult> GetCollectParamsAsync(
        string lotId,
        string opId,
        string stepId,
        string dataUnit = "1",
        string wfId     = "",
        CancellationToken ct = default)
    {
        logger.LogInformation("GetCollectParams start. LotId={LotId}, OpId={OpId}, StepId={StepId}", lotId, opId, stepId);

        var req = new TfMsg();
        req.AddString(Tags.MsgVer,  "01.01");
        req.AddString(Tags.SbId,    _sbId);
        req.AddString(Tags.LotId,   lotId);
        req.AddString(Tags.OpId,    opId);
        req.AddString(Tags.StepId,  stepId);
        req.AddString("DATA_UNIT",  dataUnit);
        req.AddString(Tags.WfId,    wfId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync("lot_.collectparams", req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetCollectParams send failed");
            return new CollectParamsResult(false, $"通信エラー: {ex.Message}");
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var err = msg.GetString(Tags.ErrMsg);
            return new CollectParamsResult(false, string.IsNullOrEmpty(err) ? "装置データ取得に失敗しました。" : err);
        }

        var items = msg.GetMsgAry("COLLECTION_LIST")
                       .Select(e => new CollectionItem(
                           e.GetString(Tags.ItemName),
                           e.GetString(Tags.CategoryId),
                           e.GetString("COLLECTION_TYPE"),
                           e.GetString("CEID"),
                           e.GetString("CURRENT_VALUE")))
                       .ToList();

        return new CollectParamsResult(
            IsSuccess:          true,
            CategoryId:         msg.GetString(Tags.CategoryId),
            LotDataCollCompFlag: msg.GetString("LOT_DATA_COLL_COMP_FLAG"),
            Items:              items);
    }

    // ──────── ヘルパー ────────
}
