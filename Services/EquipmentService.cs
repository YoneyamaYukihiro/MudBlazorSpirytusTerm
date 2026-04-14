namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// 装置グループ一覧 (mas_.mcgrouplist) および
/// エリア/グループ別装置用途情報 (eq__.areacurlist) を取得するサービス。
/// VBソース: pubblnMasMcGroupList_Sel / pubblnEqAreaCurList_Sel (CtsbasxxCM0050.vb)
/// </summary>
public sealed class EquipmentService(ITfMessageClient mq, IConfiguration cfg, ILogger<EquipmentService> logger)
{
    private readonly string _defaultSbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 公開型 ────────────────────────────────────────────

    /// <summary>装置グループ。VBソース: McList 構造体</summary>
    public sealed record McGroup(string Id, string Name, string BatchFlag);

    /// <summary>装置。VBソース: AreaEquipmentList 構造体</summary>
    public sealed record Equipment(
        string WpId,
        string WpName,
        string UseId,
        string UseName,
        string MesModeId,
        string WpStopFlag,
        string WpStatusName,
        string WpTypeFlag,
        string PlaceId,
        string PlaceName,
        string EqType,
        string AldProcessModeId,
        string AldProcessName
    );

    /// <summary>装置状態。VBソース: Eqstate 構造体</summary>
    public sealed record EquipmentState(
        string MesModeId,
        string MesModeType,
        string ModeStatus,
        string UseId,
        string UseName,
        string WpTypeFlag,
        string WpStopFlag,
        string WpStatusName,
        string CollectTypeFlag,
        string RecipeFlowNum,
        string WpCancelCarrierFlag,
        string McType,
        IReadOnlyList<PortInfo> PortList
    );

    /// <summary>ポート情報。VBソース: eqPortList 構造体</summary>
    public sealed record PortInfo(string PortId, string PortStatus);

    /// <summary>ストッカー。VBソース: StockerList 構造体</summary>
    public sealed record Stocker(string StockerId, string StockerName);

    // ──────── 装置グループ取得 ────────────────────────────────────

    /// <summary>
    /// 装置グループ一覧を取得する。
    /// VBソース: MsgVer="01.00", ClassDivision="02"(全件)
    /// </summary>
    public async Task<IReadOnlyList<McGroup>> GetMcGroupListAsync(CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer, "01.00");
        req.AddString(Tags.ClassDivision, "02"); // 全件
        req.AddString(Tags.SbId, _defaultSbId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.MasMcGroupList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "MasMcGroupList request failed");
            return [];
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("MasMcGroupList returned non-TRUE. Raw={Raw}", Summarize(raw));
            return [];
        }

        var ary = msg.GetMsgAry(Tags.McGroupList);
        return ary.Select(item => new McGroup(
            Id:         item.GetString(Tags.McGroupId),
            Name:       item.GetString(Tags.McGroupName),
            BatchFlag:  item.GetString(Tags.BatchFlag)
        )).ToList();
    }

    // ──────── 装置一覧取得 ────────────────────────────────────────

    /// <summary>
    /// 指定装置グループの装置一覧を取得する。
    /// VBソース: MsgVer="02.00", AREA_ID に McGroupID をセット
    /// </summary>
    public async Task<IReadOnlyList<Equipment>> GetEquipmentListAsync(
        string mcGroupId, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.AreaId,        mcGroupId);
        req.AddString(Tags.SbId,          _defaultSbId);
        req.AddString(Tags.MsgVer,        "02.00");
        req.AddString(Tags.McGroupId,     mcGroupId);
        req.AddString(Tags.ClassDivision, Tags.MsgNull);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.EqAreaCurList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "EqAreaCurList request failed. McGroupId={McGroupId}", mcGroupId);
            return [];
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("EqAreaCurList returned non-TRUE. McGroupId={McGroupId}, Raw={Raw}",
                mcGroupId, Summarize(raw));
            return [];
        }

        var ary = msg.GetMsgAry(Tags.AreaEquipmentList);
        return ary.Select(item => new Equipment(
            WpId:            item.GetString(Tags.WpId),
            WpName:          item.GetString(Tags.WpName),
            UseId:           item.GetString(Tags.UseId),
            UseName:         item.GetString(Tags.UseName),
            MesModeId:       item.GetString(Tags.MesModeId),
            WpStopFlag:      item.GetString(Tags.WpStopFlag),
            WpStatusName:    item.GetString(Tags.WpStatusName),
            WpTypeFlag:      item.GetString(Tags.WpTypeFlag),
            PlaceId:         item.GetString(Tags.PlaceId),
            PlaceName:       item.GetString(Tags.PlaceName),
            EqType:          item.GetString(Tags.EqType),
            AldProcessModeId: item.GetString(Tags.AldProcessModeId),
            AldProcessName:  item.GetString(Tags.AldProcessName)
        )).ToList();
    }

    // ──────── 装置状態取得 ────────────────────────────────────────

    /// <summary>
    /// 装置状態を取得する。
    /// VBソース: MsgVer="03.00", CPstreq__state___
    /// </summary>
    public async Task<EquipmentState?> GetEquipmentStateAsync(
        string wpId, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer, "03.00");
        req.AddString(Tags.WpId, wpId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.EqState, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "EqState request failed. WpId={WpId}", wpId);
            return null;
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("EqState returned non-TRUE. WpId={WpId}, Raw={Raw}", wpId, Summarize(raw));
            return null;
        }

        var portAry = msg.GetMsgAry(Tags.PortList);
        var ports = portAry.Select(p => new PortInfo(
            PortId:     p.GetString(Tags.PortId),
            PortStatus: p.GetString(Tags.PortStatus)
        )).ToList();

        return new EquipmentState(
            MesModeId:            msg.GetString(Tags.MesModeId),
            MesModeType:          msg.GetString(Tags.MesModeType),
            ModeStatus:           msg.GetString(Tags.ModeStatus),
            UseId:                msg.GetString(Tags.UseId),
            UseName:              msg.GetString(Tags.UseName),
            WpTypeFlag:           msg.GetString(Tags.WpTypeFlag),
            WpStopFlag:           msg.GetString(Tags.WpStopFlag),
            WpStatusName:         msg.GetString(Tags.WpStatusName),
            CollectTypeFlag:      msg.GetString(Tags.CollectTypeFlag),
            RecipeFlowNum:        msg.GetString(Tags.RecipeFlowNum),
            WpCancelCarrierFlag:  msg.GetString(Tags.WpCancelCarrierFlag),
            McType:               msg.GetString(Tags.McType),
            PortList:             ports
        );
    }

    // ──────── ストッカーリスト取得 ────────────────────────────────

    /// <summary>
    /// ストッカーマスタを取得する。
    /// VBソース: MsgVer="01.00", CPstrmas_stockerlist
    /// </summary>
    public async Task<IReadOnlyList<Stocker>> GetStockerListAsync(
        string classDivision = "", CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId, _defaultSbId);
        req.AddString(Tags.ClassDivision, classDivision);
        req.AddString(Tags.MsgVer, "01.00");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.MasStockerList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "MasStockerList request failed");
            return [];
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("MasStockerList returned non-TRUE. Raw={Raw}", Summarize(raw));
            return [];
        }

        var ary = msg.GetMsgAry(Tags.StockerList);
        return ary.Select(item => new Stocker(
            StockerId:   item.GetString(Tags.StockerId),
            StockerName: item.GetString(Tags.StockerName)
        )).ToList();
    }

    // ──────── 内部ヘルパー ────────────────────────────────────────

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
