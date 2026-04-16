namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN0260 ロット処理順変更 のサービス。
/// VBソース: VB/COMN/CtsfrmxxCM0110.vb, VB/COMN/CtsbasxxCM0050.vb
/// </summary>
public sealed class LotSeqChangeService(ITfMessageClient mq, IConfiguration cfg, ILogger<LotSeqChangeService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 公開型 ────────────────────────────────────────────

    /// <summary>ロット待ちリストの1行。VBソース: LotListAns.typLotList 構造体</summary>
    public sealed record WaitingLotItem(
        string LotId,
        string CarrierId,
        string FlowClass,
        string LotPriority,
        string OpId,
        string StepId,
        string RecipeId,
        string DispatchStartTime,
        string LotManagerName,
        string NowSt,
        string WfNum,
        string ChipQuantity,
        string CurrentPositionName,
        string CarrierStatId,
        string DestName,
        string LotCommentsFlag,
        string LotLastUpdate,
        string AvailableRecipeFlag,
        string ShipDiffDay,
        string FrRecipeFlag,
        string GrbClass,
        string LotHoldFlag,
        string LotStopFlag,
        string ReworkFlag,
        string LimitTime,
        string LcDirection,
        /// <summary>現処理順№。"999" = 標準（順番なし）</summary>
        string SeqNum
    );

    public sealed record WaitingLotListResult(
        bool IsSuccess,
        string ErrorMessage = "",
        IReadOnlyList<WaitingLotItem>? Items = null,
        string WpTypeFlag = "",
        string McType = ""
    );

    /// <summary>処理順変更1件分の要求データ。</summary>
    public sealed record ChangeItem(
        string LotId,
        string SeqNum,
        string OpId,
        string StepId,
        string LotLastUpdate,
        string AvailableRecipeFlag
    );

    public sealed record ChangeResult(bool IsSuccess, string ErrorMessage = "");

    // ──────── ロット待ちリスト取得 ────────────────────────────────

    /// <summary>
    /// ロット処理順変更用のロット一覧を取得する。
    /// lot_.list____ MSG_VER="12.01" CLASS_DIVISION="25"
    /// VBソース: CMstrlot_list____Ver="12.01", CPstrCD25="25"
    /// </summary>
    public async Task<WaitingLotListResult> GetWaitingLotListAsync(
        string wpId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer, "12.01");
        req.AddString(Tags.ClassDivision, "25");  // CPstrCD25 = ロット処理順変更
        req.AddString(Tags.SbId, _sbId);
        req.AddString(Tags.WpId, wpId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotList(EN0260) send failed. WpId={WpId}", wpId);
            return new WaitingLotListResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = TfMsg.ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var err = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            logger.LogWarning("LotList(EN0260) returned FALSE. WpId={WpId}, Err={Err}", wpId, err);
            return new WaitingLotListResult(false,
                string.IsNullOrEmpty(err) ? "ロット一覧取得に失敗しました。" : err);
        }

        var wpTypeFlag = aMsg.GetString(Tags.WpTypeFlag);
        var mcType     = aMsg.GetString(Tags.McType);
        var ary        = aMsg.GetMsgAry(Tags.LotList);

        var items = ary.Select(e => new WaitingLotItem(
            LotId:               e.GetString(Tags.LotId),
            CarrierId:           e.GetString(Tags.CarrierId),
            FlowClass:           e.GetString(Tags.FlowClass),
            LotPriority:         e.GetString(Tags.LotPriority),
            OpId:                e.GetString(Tags.OpId),
            StepId:              e.GetString(Tags.StepId),
            RecipeId:            e.GetString(Tags.RecipeId),
            DispatchStartTime:   e.GetString(Tags.DispatchStartTime),
            LotManagerName:      e.GetString(Tags.EngEmpName),
            NowSt:               e.GetString(Tags.NowSt),
            WfNum:               e.GetString(Tags.WfNum),
            ChipQuantity:        e.GetString(Tags.ChipQuantity),
            CurrentPositionName: e.GetString(Tags.CurrentPositionName),
            CarrierStatId:       e.GetString(Tags.CarrierStatId),
            DestName:            e.GetString(Tags.DestName),
            LotCommentsFlag:     e.GetString(Tags.LotCommentsFlag),
            LotLastUpdate:       e.GetString(Tags.LotLastUpdate),
            AvailableRecipeFlag: e.GetString(Tags.AvailableRecipeFlag),
            ShipDiffDay:         e.GetString(Tags.ShipDiffDay),
            FrRecipeFlag:        e.GetString(Tags.FrRecipeFlag),
            GrbClass:            e.GetString(Tags.GrbClass),
            LotHoldFlag:         e.GetString(Tags.LotHoldFlag),
            LotStopFlag:         e.GetString(Tags.LotStopFlag),
            ReworkFlag:          e.GetString(Tags.ReworkFlag),
            LimitTime:           e.GetString(Tags.LimitTime),
            LcDirection:         e.GetString(Tags.LcDirection),
            SeqNum:              e.GetString(Tags.SeqNum)
        )).ToList();

        return new WaitingLotListResult(true, Items: items, WpTypeFlag: wpTypeFlag, McType: mcType);
    }

    // ──────── ロット処理順変更 ─────────────────────────────────────

    /// <summary>
    /// ロット処理順を変更する（全解除の場合は items を空にして呼ぶ）。
    /// lot_.chgseqnum MSG_VER="06.00"
    /// VBソース: CMstrlot_chgseqnumVer="06.00"
    /// </summary>
    public async Task<ChangeResult> ChangeSeqNumAsync(
        string wpId,
        IReadOnlyList<ChangeItem> items,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,   _sbId);
        req.AddString(Tags.EmpId,  string.Empty);  // VBソース: pstrUserID (ログインユーザーID)
        req.AddString(Tags.WpId,   wpId);

        var ary = new TfMsgAry();
        foreach (var item in items)
        {
            var t = new TfMsg();
            t.AddString(Tags.LotId,              item.LotId);
            t.AddString(Tags.SeqNum,             item.SeqNum);
            t.AddString(Tags.OpId,               item.OpId);
            t.AddString(Tags.StepId,             item.StepId);
            t.AddString(Tags.LotLastUpdate,      item.LotLastUpdate);
            t.AddString(Tags.AvailableRecipeFlag, item.AvailableRecipeFlag);
            ary.Add(t);
        }
        req.AddMsgAry(Tags.LotList, ary);
        req.AddString(Tags.MsgVer, "06.00");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotChgSeqNum, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotChgSeqNum send failed. WpId={WpId}", wpId);
            return new ChangeResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = TfMsg.ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var err = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            logger.LogWarning("LotChgSeqNum returned FALSE. WpId={WpId}, Err={Err}", wpId, err);
            return new ChangeResult(false,
                string.IsNullOrEmpty(err) ? "処理順変更に失敗しました。" : err);
        }

        return new ChangeResult(true);
    }

    // ──────── 内部ヘルパー ────────────────────────────────────────
}
