namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN00M0 バッチ管理 のサービス。
/// VBソース: VB/00M0/CtsfrmxxEN00M0.vb, VB/00M0/CtsbasxxMG00M0.vb
/// </summary>
public sealed class BatchLotService(ITfMessageClient mq, IConfiguration cfg, ILogger<BatchLotService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 公開型 ────────────────────────────────────────────

    public sealed record McGroupEntry(string McGroupId, string McGroupName);

    /// <summary>装置エントリ (mas_.wplist__ 応答)。EQ_TYPE: "19"=蒸着, "20"=表面処理</summary>
    public sealed record WpEntry(string WpId, string WpName, string EqType);

    /// <summary>ロット内の装置候補 (WP_LIST 要素)</summary>
    public sealed record LotWpEntry(string WpId, string WpName);

    /// <summary>ロット内のWF情報 (WF_LIST 要素)</summary>
    public sealed record WfEntry(string WfId, string JigId);

    /// <summary>
    /// 在庫ロット1件。lot_.mcgplotlist 応答の LOT_LIST 要素。
    /// VBソース: typMcGpLotList
    /// </summary>
    public sealed record LotEntry(
        string LotId,
        string CarrierId,
        string LotPriority,
        string LimitTime,
        string WarnTime,
        string WfQuantity,
        string OpId,
        string StepId,
        string RecipeId,
        string OptionText,
        string CurrentStatusId,
        string CurrentStatusName,
        string LotLastUpdate,
        string FlowClass,
        string FlowClassName,
        string UseId,
        string DispatchStartTime,
        string CfFlag,
        string LpFlag,
        string PdId,
        string VaFlag,
        string JBatchId,
        string HBatchId,
        string UnloaderCarrierId,
        IReadOnlyList<LotWpEntry> WpList,
        IReadOnlyList<WfEntry> WfList
    );

    public sealed record LotListResult(
        bool IsSuccess,
        string ErrorMessage = "",
        IReadOnlyList<LotEntry>? Lots = null
    );

    /// <summary>bat_.change__ 要求用のロット1件。</summary>
    public sealed record BatchLotItem(
        string SeqNum,
        string CarrierId,
        string JigId,
        string LotId,
        string LotLastUpdate,
        string UnloaderCarrierId,
        string WfId,
        string PanelKind,
        string VaConditionId
    );

    public sealed record BatchChangeResult(
        bool IsSuccess,
        string ErrorMessage = "",
        string MsgCode = "",
        string BatchId = ""
    );

    // ──────── 装置グループ取得 (mas_.mcgrouplist CD=2G) ──────────

    /// <summary>
    /// バッチ装置グループ一覧を取得する。
    /// mas_.mcgrouplist MSG_VER="01.00" CLASS_DIVISION="2G"
    /// VBソース: CPstrCD2G = "2G"
    /// </summary>
    public async Task<IReadOnlyList<McGroupEntry>> GetMcGroupListAsync(CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,        "01.00");
        req.AddString(Tags.ClassDivision, "2G");
        req.AddString(Tags.SbId,          _sbId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.MasMcGroupList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "MasMcGroupList(EN00M0) failed");
            return [];
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True) return [];

        return msg.GetMsgAry(Tags.McGroupList)
            .Select(e => new McGroupEntry(e.GetString(Tags.McGroupId), e.GetString(Tags.McGroupName)))
            .ToList();
    }

    // ──────── 装置一覧取得 (mas_.wplist__ CD=20) ─────────────────

    /// <summary>
    /// 装置グループに属する装置一覧を取得する。
    /// mas_.wplist__ MSG_VER="05.01" CLASS_DIVISION="20"
    /// VBソース: CPstrCD20 = "20"
    /// </summary>
    public async Task<IReadOnlyList<WpEntry>> GetWpListAsync(
        string mcGroupId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,        "05.01");
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.ClassDivision, "20");
        req.AddString(Tags.McGroupId,     mcGroupId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.MasWpList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "MasWpList(EN00M0) failed. McGroupId={Id}", mcGroupId);
            return [];
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True) return [];

        return msg.GetMsgAry(Tags.WpList)
            .Select(e => new WpEntry(
                e.GetString(Tags.WpId),
                e.GetString(Tags.WpName),
                e.GetString(Tags.EqType)
            )).ToList();
    }

    // ──────── 在庫ロット一覧取得 (lot_.mcgplotlist) ──────────────

    /// <summary>
    /// 装置グループの在庫ロット一覧を取得する。
    /// lot_.mcgplotlist MSG_VER="04.00"
    /// classDiv: "2T"=製品ロット, "2Z"=モニタロット
    /// VBソース: CPstrCD2T = "2T", CPstrCD2Z = "2Z"
    /// </summary>
    public async Task<LotListResult> GetLotListAsync(
        string mcGroupId,
        string classDiv,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,        "04.00");
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.McGroupId,     mcGroupId);
        req.AddString(Tags.ClassDivision, classDiv);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotMcGpLotList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotMcGpLotList failed. McGroupId={Id} CD={Cd}", mcGroupId, classDiv);
            return new LotListResult(false, $"通信エラー: {ex.Message}");
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var err = msg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = msg.GetString(Tags.Msg);
            logger.LogWarning("LotMcGpLotList returned FALSE. Err={Err}", err);
            return new LotListResult(false, string.IsNullOrEmpty(err) ? "ロット一覧の取得に失敗しました。" : err);
        }

        var lots = msg.GetMsgAry(Tags.LotList).Select(e =>
        {
            var wpList = e.GetMsgAry(Tags.WpList)
                .Select(w => new LotWpEntry(w.GetString(Tags.WpId), w.GetString(Tags.WpName)))
                .ToList();
            var wfList = e.GetMsgAry(Tags.WfList)
                .Select(w => new WfEntry(w.GetString(Tags.WfId), w.GetString(Tags.JigId)))
                .ToList();

            return new LotEntry(
                LotId:             e.GetString(Tags.LotId),
                CarrierId:         e.GetString(Tags.CarrierId),
                LotPriority:       e.GetString(Tags.LotPriority),
                LimitTime:         e.GetString(Tags.LimitTime),
                WarnTime:          e.GetString(Tags.WarnTime),
                WfQuantity:        e.GetString(Tags.WfQuantity),
                OpId:              e.GetString(Tags.OpId),
                StepId:            e.GetString(Tags.StepId),
                RecipeId:          e.GetString(Tags.RecipeId),
                OptionText:        e.GetString(Tags.OptionText),
                CurrentStatusId:   e.GetString(Tags.CurrentStatusId),
                CurrentStatusName: e.GetString(Tags.CurrentStatusName),
                LotLastUpdate:     e.GetString(Tags.LotLastUpdate),
                FlowClass:         e.GetString(Tags.FlowClass),
                FlowClassName:     e.GetString(Tags.FlowClassName),
                UseId:             e.GetString(Tags.UseId),
                DispatchStartTime: e.GetString(Tags.DispatchStartTime),
                CfFlag:            e.GetString(Tags.CfFlag),
                LpFlag:            e.GetString(Tags.LpFlag),
                PdId:              e.GetString(Tags.PdId),
                VaFlag:            e.GetString(Tags.VaFlag),
                JBatchId:          e.GetString(Tags.JBatchId),
                HBatchId:          e.GetString(Tags.HBatchId),
                UnloaderCarrierId: e.GetString(Tags.UnloaderCarrierId),
                WpList:            wpList,
                WfList:            wfList
            );
        }).ToList();

        return new LotListResult(true, Lots: lots);
    }

    // ──────── バッチ変更 (bat_.change__) ─────────────────────────

    /// <summary>
    /// バッチを新規作成・変更・削除する。
    /// bat_.change__ MSG_VER="03.00"
    /// classDiv: ""=新規, "05"=削除, "06"=変更
    /// VBソース: CPstrCD05 = "05", CPstrCD06 = "06"
    /// </summary>
    public async Task<BatchChangeResult> BatchChangeAsync(
        string classDiv,
        string batchId,
        string wpId,
        string eqType,
        string recipeId,
        string empId,
        IReadOnlyList<BatchLotItem> lots,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,        "03.00");
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.ClassDivision, classDiv);
        req.AddString(Tags.BatchId,       batchId);
        req.AddString(Tags.WpId,          wpId);
        req.AddString(Tags.EqType,        eqType);
        req.AddString(Tags.RecipeId,      recipeId);
        req.AddString(Tags.EmpId,         empId);

        var ary = new TfMsgAry();
        foreach (var lot in lots)
        {
            var t = new TfMsg();
            t.AddString(Tags.SeqNum,           lot.SeqNum);
            t.AddString(Tags.CarrierId,        lot.CarrierId);
            t.AddString(Tags.JigId,            lot.JigId);
            t.AddString(Tags.LotId,            lot.LotId);
            t.AddString(Tags.LotLastUpdate,    lot.LotLastUpdate);
            t.AddString(Tags.UnloaderCarrierId, lot.UnloaderCarrierId);
            t.AddString(Tags.WfId,             lot.WfId);
            t.AddString(Tags.PanelKind,        lot.PanelKind);
            t.AddString(Tags.VaConditionId,    lot.VaConditionId);
            ary.Add(t);
        }
        req.AddMsgAry(Tags.LotList, ary);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.BatChange, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "BatChange failed");
            return new BatchChangeResult(false, $"通信エラー: {ex.Message}");
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var msgCode = msg.GetString(Tags.MsgCode);
            var err     = msg.GetString(Tags.Msg);
            if (string.IsNullOrEmpty(err)) err = msg.GetString(Tags.ErrMsg);
            logger.LogWarning("BatChange returned FALSE. MsgCode={MsgCode}, Err={Err}", msgCode, err);
            return new BatchChangeResult(false, string.IsNullOrEmpty(err) ? "バッチ変更に失敗しました。" : err, msgCode);
        }

        return new BatchChangeResult(true, BatchId: msg.GetString(Tags.BatchId));
    }

    // ──────── 内部ヘルパー ────────────────────────────────────────
}
