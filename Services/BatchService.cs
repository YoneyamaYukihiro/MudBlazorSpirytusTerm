namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// バッチ処理サービス。
/// ・バッチ組ロット情報取得 (bat_.lotlist_)
/// ・バッチ処理開始          (bat_.prcstart)
/// ・バッチ処理終了          (bat_.prcend__)
/// VBソース: pubblnBatLotList_Sel (CtsbasxxCM0050.vb), BatPrcStartEnd 構造体 (CtsbasxxCM0030.vb)
/// </summary>
public sealed class BatchService(ITfMessageClient mq, IConfiguration cfg, ILogger<BatchService> logger)
{
    private readonly string _defaultSbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 公開型 ────────────────────────────────────────────

    /// <summary>バッチ組ロット情報要求。VBソース: BatRequestList 構造体</summary>
    public sealed record BatchLotListRequest(
        string ClassDivision,
        string WpId       = "",
        string McGroupId  = "",
        string CarrierId  = "",
        string MsgVer     = "03.00"
    );

    /// <summary>バッチ内のロット情報。VBソース: BatList 構造体</summary>
    public sealed record BatchLotItem(
        string LotId,
        string CarrierId,
        string FlowClass,
        string OpId,
        string StepId,
        string WfNum,
        string ChipQuantity,
        string LotPriority,
        string LimitTime,
        string WarnTime,
        string ToOpId,
        string ToStepId,
        string ReworkFlag,
        string LotLastUpdate,
        string CurrentStatusName,
        string DispatchStartTime
    );

    /// <summary>バッチ情報。VBソース: BatLot 構造体</summary>
    public sealed record BatchInfo(
        string BatchId,
        string WpId,
        string WpName,
        string RecipeId,
        string EqType,
        string MesModeId,
        IReadOnlyList<BatchLotItem> Lots
    );

    /// <summary>バッチ処理要求ロット。VBソース: BLotList 構造体</summary>
    public sealed record BatchLotRef(
        string LotId,
        string LotLastUpdate,
        string LotKind = ""
    );

    /// <summary>バッチ処理開始/終了要求。VBソース: BatPrcStartEnd 構造体</summary>
    public sealed record BatchProcessRequest(
        string BatchId,
        string EmpId,
        string EqType,
        IReadOnlyList<BatchLotRef> Lots,
        string ClassDivision = "",
        string Comments      = "",
        string MsgVer        = "03.00"
    );

    // ──────── バッチ組ロット情報取得 ─────────────────────────────

    /// <summary>
    /// バッチ組ロット情報を取得する。
    /// VBソース: CPstrbat_lotlist_
    /// </summary>
    public async Task<IReadOnlyList<BatchInfo>> GetBatchLotListAsync(
        BatchLotListRequest request, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,          _defaultSbId);
        req.AddString(Tags.ClassDivision, request.ClassDivision);
        req.AddString(Tags.CarrierId,     request.CarrierId);
        req.AddString(Tags.WpId,          request.WpId);
        req.AddString(Tags.McGroupId,     request.McGroupId);
        req.AddString(Tags.MsgVer,        request.MsgVer);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.BatLotList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "BatLotList request failed. WpId={WpId}", request.WpId);
            return [];
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("BatLotList returned non-TRUE. Raw={Raw}", Summarize(raw));
            return [];
        }

        var batAry = msg.GetMsgAry(Tags.BatchList);
        var result = new List<BatchInfo>(batAry.Count);

        foreach (var batItem in batAry)
        {
            var lotAry = batItem.GetMsgAry(Tags.LotList);
            var lots = lotAry.Select(l => new BatchLotItem(
                LotId:               l.GetString(Tags.LotId),
                CarrierId:           l.GetString(Tags.CarrierId),
                FlowClass:           l.GetString(Tags.FlowClass),
                OpId:                l.GetString(Tags.OpId),
                StepId:              l.GetString(Tags.StepId),
                WfNum:               l.GetString(Tags.WfNum),
                ChipQuantity:        l.GetString(Tags.ChipQuantity),
                LotPriority:         l.GetString(Tags.LotPriority),
                LimitTime:           l.GetString(Tags.LimitTime),
                WarnTime:            l.GetString(Tags.WarnTime),
                ToOpId:              l.GetString(Tags.ToOpId),
                ToStepId:            l.GetString(Tags.ToStepId),
                ReworkFlag:          l.GetString(Tags.ReworkFlag),
                LotLastUpdate:       l.GetString(Tags.LotLastUpdate),
                CurrentStatusName:   l.GetString(Tags.WpStatusName),
                DispatchStartTime:   l.GetString(Tags.DispatchStartTime)
            )).ToList();

            result.Add(new BatchInfo(
                BatchId:  batItem.GetString(Tags.BatchId),
                WpId:     batItem.GetString(Tags.WpId),
                WpName:   batItem.GetString(Tags.WpName),
                RecipeId: batItem.GetString(Tags.RecipeId),
                EqType:   batItem.GetString(Tags.EqType),
                MesModeId: batItem.GetString(Tags.MesModeId),
                Lots:     lots
            ));
        }

        return result;
    }

    // ──────── バッチ処理開始 ─────────────────────────────────────

    /// <summary>
    /// バッチ処理開始を登録する。
    /// VBソース: CPstrbat_prcstart
    /// </summary>
    public async Task<bool> BatchProcessStartAsync(
        BatchProcessRequest request, CancellationToken ct = default)
        => await SendBatchProcessAsync(MsgIds.BatPrcStart, request, ct);

    // ──────── バッチ処理終了 ─────────────────────────────────────

    /// <summary>
    /// バッチ処理終了を登録する。
    /// VBソース: CPstrbat_prcend__
    /// </summary>
    public async Task<bool> BatchProcessEndAsync(
        BatchProcessRequest request, CancellationToken ct = default)
        => await SendBatchProcessAsync(MsgIds.BatPrcEnd, request, ct);

    // ──────── 内部ヘルパー ────────────────────────────────────────

    private async Task<bool> SendBatchProcessAsync(
        string subject, BatchProcessRequest request, CancellationToken ct)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,          _defaultSbId);
        req.AddString(Tags.BatchId,       request.BatchId);
        req.AddString(Tags.Comments,      request.Comments);
        req.AddString(Tags.EmpId,         request.EmpId);
        req.AddString(Tags.MsgVer,        request.MsgVer);
        req.AddString(Tags.ClassDivision, request.ClassDivision);
        req.AddString(Tags.EqType,        request.EqType);

        // ロットリストを配列として追加
        var lotAry = new TfMsgAry();
        foreach (var lot in request.Lots)
        {
            var lotMsg = new TfMsg();
            lotMsg.AddString(Tags.LotId,         lot.LotId);
            lotMsg.AddString(Tags.LotLastUpdate,  lot.LotLastUpdate);
            lotMsg.AddString(Tags.LotKind,        lot.LotKind);
            lotAry.Add(lotMsg);
        }
        req.AddMsgAry(Tags.BLotList, lotAry);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(subject, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "BatchProcess request failed. Subject={Subject}, BatchId={BatchId}",
                subject, request.BatchId);
            return false;
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("BatchProcess returned non-TRUE. Subject={Subject}, BatchId={BatchId}, Raw={Raw}",
                subject, request.BatchId, Summarize(raw));
            return false;
        }

        return true;
    }

    private static TfMsg ParseOrEmpty(string? raw)
    {
        var text = (raw ?? string.Empty).Trim();
        if (text.StartsWith("(", StringComparison.Ordinal))
        {
            try { return TfMsg.FromTfString(text); } catch { }
        }
        var empty = new TfMsg();
        empty.AddString(Tags.Ret, Tags.False);
        empty.AddString(Tags.ErrMsg, text.Length > 0 ? text : "空の応答");
        return empty;
    }

    private static string Summarize(string? raw) =>
        (raw ?? string.Empty) is { Length: > 200 } s ? s[..200] + "..." : raw ?? string.Empty;
}
