namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// キャリア操作サービス。
/// ・キャリア一覧取得     (carr.list____)
/// ・キャリア状態確認     (carr.curstate)
/// ・キャリア手動出庫要求 (carr.manuoutport)
/// VBソース: pubblnCarrList_Sel / pubblnCarrcurstate_Sel / pubblnCarrManuOutPort_Ins (CtsbasxxCM0050.vb)
/// </summary>
public sealed class CarrierService(ITfMessageClient mq, IConfiguration cfg, ILogger<CarrierService> logger)
{
    private readonly string _defaultSbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 公開型 ────────────────────────────────────────────

    /// <summary>キャリア一覧要求。VBソース: CarrierListReq 構造体</summary>
    public sealed record CarrierListRequest(
        string ClassDivision,
        string MsgVer          = "03.00",
        string CarrierTypeId   = "",
        string CarrierId       = "",
        string RestrictedSbId  = ""
    );

    /// <summary>キャリア情報。VBソース: CarrierIDList 構造体</summary>
    public sealed record CarrierInfo(
        string CarrierId,
        string EmptyFlag,
        string StartTime,
        string CleanFlag,
        string CleanTime,
        string TotalUseCount,
        string CleanCount,
        string AfterCleanUseCount,
        string CarrierStatId
    );

    /// <summary>キャリア状態確認要求。VBソース: CarrCurstate 構造体</summary>
    public sealed record CarrierStateRequest(
        string CarrierId,
        string ClassDivision  = "",
        string MsgVer         = "04.00",
        string CarrierTypeId  = "",
        string LotId          = "",
        string OpId           = "",
        string StepId         = "",
        string AltNumber      = ""
    );

    // ──────── キャリア一覧取得 ────────────────────────────────────

    /// <summary>
    /// キャリア一覧を取得する。
    /// VBソース: CPstrcarrlist____
    /// </summary>
    public async Task<IReadOnlyList<CarrierInfo>> GetCarrierListAsync(
        CarrierListRequest request, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,         request.MsgVer);
        req.AddString(Tags.SbId,           _defaultSbId);
        req.AddString(Tags.ClassDivision,  request.ClassDivision);
        req.AddString(Tags.RestrictedSbId, request.RestrictedSbId);
        req.AddString(Tags.CarrierTypeId,  request.CarrierTypeId);
        req.AddString(Tags.CarrierId,      request.CarrierId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.CarrList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "CarrList request failed");
            return [];
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("CarrList returned non-TRUE. Raw={Raw}", Summarize(raw));
            return [];
        }

        var ary = msg.GetMsgAry(Tags.CarrierList);
        return ary.Select(item => new CarrierInfo(
            CarrierId:           item.GetString(Tags.CarrierId),
            EmptyFlag:           item.GetString(Tags.EmptyFlag),
            StartTime:           item.GetString(Tags.StartTime),
            CleanFlag:           item.GetString(Tags.CleanFlag),
            CleanTime:           item.GetString(Tags.CleanTime),
            TotalUseCount:       item.GetString(Tags.TotalUseCount),
            CleanCount:          item.GetString(Tags.CleanCount),
            AfterCleanUseCount:  item.GetString(Tags.AfterCleanUseCount),
            CarrierStatId:       item.GetString(Tags.CarrierStatId)
        )).ToList();
    }

    // ──────── キャリア状態確認 ────────────────────────────────────

    /// <summary>
    /// キャリア現在状態を確認する。
    /// VBソース: CPstrcarrcurstate
    /// </summary>
    public async Task<bool> CheckCarrierStateAsync(
        CarrierStateRequest request, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.ClassDivision, request.ClassDivision);
        req.AddString(Tags.MsgVer,        request.MsgVer);
        req.AddString(Tags.CarrierId,     request.CarrierId);
        req.AddString(Tags.CarrierTypeId, request.CarrierTypeId);
        req.AddString(Tags.SbId,          _defaultSbId);
        req.AddString(Tags.LotId,         request.LotId);
        req.AddString(Tags.OpId,          request.OpId);
        req.AddString(Tags.StepId,        request.StepId);
        req.AddString(Tags.AltNumber,     request.AltNumber);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.CarrCurState, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "CarrCurState request failed. CarrierId={CarrierId}",
                request.CarrierId);
            return false;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("CarrCurState returned non-TRUE. CarrierId={CarrierId}, Raw={Raw}",
                request.CarrierId, Summarize(raw));
            return false;
        }

        return true;
    }

    // ──────── キャリア手動出庫要求 ────────────────────────────────

    /// <summary>
    /// キャリアのストッカーへの手動出庫を要求する。
    /// VBソース: CPstrcarrmanuoutport
    /// </summary>
    public async Task<bool> ManualCarrierOutAsync(
        string carrierId,
        string stockerId,
        string empId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,       _defaultSbId);
        req.AddString(Tags.MsgVer,     "01.00");
        req.AddString(Tags.CarrierId,  carrierId);
        req.AddString(Tags.StockerId,  stockerId);
        req.AddString(Tags.EmpId,      empId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.CarrManuOutPort, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "CarrManuOutPort request failed. CarrierId={CarrierId}", carrierId);
            return false;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("CarrManuOutPort returned non-TRUE. CarrierId={CarrierId}, Raw={Raw}",
                carrierId, Summarize(raw));
            return false;
        }

        return true;
    }

    // ──────── 内部ヘルパー ────────────────────────────────────────
    private static string Summarize(string? raw) =>
        (raw ?? string.Empty) is { Length: > 200 } s ? s[..200] + "..." : raw ?? string.Empty;
}
