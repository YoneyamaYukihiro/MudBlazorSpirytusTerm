namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN00J0 装置グループ別ロット一覧 のサービス。
/// VBソース: VB/00J0/CtsbasxxMG00J0.vb, VB/00J0/CtsfrmxxEN00J0.vb
/// </summary>
public sealed class McGroupLotListService(ITfMessageClient mq, IConfiguration cfg, ILogger<McGroupLotListService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    public sealed record LotItem(
        string LotId,
        string CarrierId,
        string FlowClass,
        string OpId,
        string StepId,
        string NowSt,
        string DispatchStartTime,
        string WfNum,
        string ChipQuantity,
        string LotHoldFlag,
        string LotStopFlag,
        string LotPriority,
        string LimitTime,
        string CurrentPositionName,
        string ToOpId,
        string ToStepId,
        string WarnTime,
        string RestrictTypeId,
        string ReworkFlag,
        string ToCarrierId,
        string AltNumber,
        string LcDirection,
        string SendSbId,
        string PdId,
        string PdVersion,
        string JBatchId,
        string CfFlag,
        string LpFlag,
        string VaFlag,
        string TpalClass,
        string SbArea
    );

    public sealed record FetchResult(
        bool IsSuccess,
        string ErrorMessage = "",
        IReadOnlyList<LotItem>? Items = null
    );

    /// <summary>
    /// 装置グループ別ロット一覧を取得する。
    /// lot_.mcalllotlist MSG_VER="05.02"
    /// </summary>
    public async Task<FetchResult> GetLotListAsync(
        string mcGroupId       = "",
        CancellationToken ct   = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.McGroupId, mcGroupId);
        req.AddString(Tags.SbId,      _sbId);
        req.AddString(Tags.MsgVer,    "05.02");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotMcAllLotList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotMcAllLotList send failed");
            return new FetchResult(false, $"通信エラー: {ex.Message}");
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var err = msg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = msg.GetString(Tags.Msg);
            logger.LogWarning("LotMcAllLotList returned FALSE: {Err}", err);
            return new FetchResult(false, string.IsNullOrEmpty(err) ? "データ取得に失敗しました。" : err);
        }

        var ary = msg.GetMsgAry(Tags.LotList);
        var items = ary.Select(e => new LotItem(
            LotId:               e.GetString(Tags.LotId),
            CarrierId:           e.GetString(Tags.CarrierId),
            FlowClass:           e.GetString(Tags.FlowClass),
            OpId:                e.GetString(Tags.OpId),
            StepId:              e.GetString(Tags.StepId),
            NowSt:               e.GetString(Tags.NowSt),
            DispatchStartTime:   e.GetString(Tags.DispatchStartTime),
            WfNum:               e.GetString(Tags.WfNum),
            ChipQuantity:        e.GetString(Tags.ChipQuantity),
            LotHoldFlag:         e.GetString(Tags.LotHoldFlag),
            LotStopFlag:         e.GetString(Tags.LotStopFlag),
            LotPriority:         e.GetString(Tags.LotPriority),
            LimitTime:           e.GetString(Tags.LimitTime),
            CurrentPositionName: e.GetString(Tags.CurrentPositionName),
            ToOpId:              e.GetString(Tags.ToOpId),
            ToStepId:            e.GetString(Tags.ToStepId),
            WarnTime:            e.GetString(Tags.WarnTime),
            RestrictTypeId:      e.GetString(Tags.RestrictTypeId),
            ReworkFlag:          e.GetString(Tags.ReworkFlag),
            ToCarrierId:         e.GetString(Tags.ToCarrierId),
            AltNumber:           e.GetString(Tags.AltNumber),
            LcDirection:         e.GetString(Tags.LcDirection),
            SendSbId:            e.GetString(Tags.SendSbId),
            PdId:                e.GetString(Tags.PdId),
            PdVersion:           e.GetString(Tags.PdVersion),
            JBatchId:            e.GetString(Tags.JBatchId),
            CfFlag:              e.GetString(Tags.CfFlag),
            LpFlag:              e.GetString(Tags.LpFlag),
            VaFlag:              e.GetString(Tags.VaFlag),
            TpalClass:           e.GetString(Tags.TpalClass),
            SbArea:              e.GetString(Tags.SbArea)
        )).ToList();

        return new FetchResult(true, Items: items);
    }

    private static TfMsg ParseOrEmpty(string? raw)
    {
        var text = (raw ?? string.Empty).Trim();
        if (text.StartsWith("(", StringComparison.Ordinal))
        {
            try { return TfMsg.FromTfString(text); } catch { }
        }
        var e = new TfMsg();
        e.AddString(Tags.Ret,    Tags.False);
        e.AddString(Tags.ErrMsg, text.Length > 0 ? text : "空の応答");
        return e;
    }
}
