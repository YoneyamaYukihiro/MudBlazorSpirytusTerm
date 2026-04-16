namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN02I0 区間優先設定 のサービス。
/// VBソース: VB/02I0/CtsfrmxxEN02I0.vb, VB/02I0/CtsbasxxMG02I0.vb
/// </summary>
public sealed class SectionPriorityService(ITfMessageClient mq, IConfiguration cfg, ILogger<SectionPriorityService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 公開型 ────────────────────────────────────────────

    /// <summary>装置一覧の1件。mas_.wplist__ 応答。</summary>
    public sealed record WpEntry(string WpId, string WpName);

    /// <summary>大工程の1件。mas_.useoplist 応答。</summary>
    public sealed record OpEntry(string OpId);

    /// <summary>小工程の1件。lot_.steplist 応答。</summary>
    public sealed record StepEntry(string StepId);

    /// <summary>
    /// 区間優先設定情報1件。lot_.secpriority 応答の SECPRIORITY_LIST 要素。
    /// VBソース: typSecPriorityList
    /// </summary>
    public sealed record SecPriorityItem(
        string LotId,
        string GrbClass,
        string CarrierId,
        string StartOpId,
        string StartStepId,
        string EndOpId,
        string EndStepId,
        string SectionPriority,
        string EmpName,
        string EntryTime,
        string OpId,
        string StepId,
        string LotPriority,
        string LotHoldFlag,
        string LotStopFlag
    );

    public sealed record SecPriorityListResult(
        bool IsSuccess,
        string ErrorMessage = "",
        IReadOnlyList<SecPriorityItem>? Items = null
    );

    /// <summary>ロット検索結果（lot IDのリスト）。</summary>
    public sealed record LotIdListResult(
        bool IsSuccess,
        string ErrorMessage = "",
        IReadOnlyList<string>? LotIds = null
    );

    /// <summary>
    /// 変更登録1件分の要求データ。
    /// VBソース: typChgSecPriList
    /// </summary>
    public sealed record ChangeItem(
        string LotId,
        string StartOpId,
        string StartStepId,
        string EndOpId,
        string EndStepId,
        string SectionPriority,
        string EmpId
    );

    public sealed record ChangeResult(bool IsSuccess, string ErrorMessage = "", string MsgCode = "");

    // ──────── 全装置一覧取得 (mas_.wplist__) ─────────────────────

    /// <summary>
    /// 全装置一覧を取得する。
    /// mas_.wplist__ MSG_VER="05.01" CLASS_DIVISION="02"(全て)
    /// VBソース: pubblnWpList_Sel(CMstrmas_wplist__Ver, ..., pstrSBID, CPstrCD02)
    /// </summary>
    public async Task<IReadOnlyList<WpEntry>> GetAllEquipmentsAsync(CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,        "05.01");
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.ClassDivision, "02");  // CPstrCD02 = 全て

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.MasWpList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "MasWpList(EN02I0) failed");
            return [];
        }

        var aMsg = TfMsg.ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True) return [];

        return aMsg.GetMsgAry(Tags.WpList)
            .Select(e => new WpEntry(e.GetString(Tags.WpId), e.GetString(Tags.WpName)))
            .ToList();
    }

    // ──────── 大工程一覧取得 (mas_.useoplist) ────────────────────

    /// <summary>
    /// 大工程マスタを取得する。
    /// mas_.useoplist MSG_VER="02.00"
    /// VBソース: CMstrmas_useoplist_Ver = "02.00"
    /// </summary>
    public async Task<IReadOnlyList<OpEntry>> GetOpListAsync(CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer, "02.00");
        req.AddString(Tags.SbId,   _sbId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.MasUseOpList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "MasUseOpList(EN02I0) failed");
            return [];
        }

        var aMsg = TfMsg.ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True) return [];

        return aMsg.GetMsgAry(Tags.OpList)
            .Select(e => new OpEntry(e.GetString(Tags.OpId)))
            .ToList();
    }

    // ──────── 小工程一覧取得 (lot_.steplist) ─────────────────────

    /// <summary>
    /// 指定大工程の小工程一覧を取得する。
    /// lot_.steplist MSG_VER="03.00"
    /// VBソース: CMstrlot_steplistVer = "03.00"
    /// </summary>
    public async Task<IReadOnlyList<StepEntry>> GetStepListAsync(string opId, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer, "03.00");
        req.AddString(Tags.SbId,   _sbId);
        req.AddString(Tags.OpId,   opId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotStepList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotStepList(EN02I0) failed. OpId={OpId}", opId);
            return [];
        }

        var aMsg = TfMsg.ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True) return [];

        return aMsg.GetMsgAry(Tags.StepList)
            .Select(e => new StepEntry(e.GetString(Tags.StepId)))
            .ToList();
    }

    // ──────── ロット検索: ロットID (proc.list____) ──────────────

    /// <summary>
    /// ロットIDまたはパターン（10桁未満の場合は末尾に"*"付加）でロットを検索する。
    /// proc.list____ MSG_VER="03.01"
    /// VBソース: CMstrproclist____Ver = "03.01"
    /// </summary>
    public async Task<LotIdListResult> SearchLotsByLotIdAsync(
        string lotIdOrPattern,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,              _sbId);
        req.AddString("ACTION",               "0");               // CPstrACTION=0: 工順変更中ロットを含まない
        req.AddString(Tags.MsgVer,            "03.01");
        req.AddString(Tags.LotFlowStatusId,   "3");               // 3=流動外以外
        req.AddString(Tags.LotId,             lotIdOrPattern);
        req.AddString(Tags.CarrierId,         string.Empty);
        req.AddMsgAry(Tags.PdList,            new TfMsgAry());    // 空(全機種)
        req.AddMsgAry(Tags.FlowClassList,     new TfMsgAry());    // 空(全種別)

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.ProcList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ProcList(EN02I0) failed. Pattern={Pattern}", lotIdOrPattern);
            return new LotIdListResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = TfMsg.ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var err = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            return new LotIdListResult(false, string.IsNullOrEmpty(err) ? "ロット検索に失敗しました。" : err);
        }

        var ids = aMsg.GetMsgAry(Tags.LotList)
            .Select(e => e.GetString(Tags.LotId))
            .Where(id => !string.IsNullOrEmpty(id))
            .ToList();

        return new LotIdListResult(true, LotIds: ids);
    }

    // ──────── ロット検索: 装置名 (lot_.list____) ────────────────

    /// <summary>
    /// 装置IDからロット一覧を検索する。
    /// lot_.list____ MSG_VER="12.01" CLASS_DIVISION="26"
    /// VBソース: CMstrlot_list____Ver = "12.01", CPstrCD26
    /// </summary>
    public async Task<LotIdListResult> SearchLotsByEquipmentAsync(
        string wpId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,        "12.01");
        req.AddString(Tags.ClassDivision, "26");
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.WpId,          wpId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotList(EN02I0 CD26) failed. WpId={WpId}", wpId);
            return new LotIdListResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = TfMsg.ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var err = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            return new LotIdListResult(false, string.IsNullOrEmpty(err) ? "装置別ロット検索に失敗しました。" : err);
        }

        var ids = aMsg.GetMsgAry(Tags.LotList)
            .Select(e => e.GetString(Tags.LotId))
            .Where(id => !string.IsNullOrEmpty(id))
            .ToList();

        return new LotIdListResult(true, LotIds: ids);
    }

    // ──────── ロット検索: 特定工程 (lot_.oplotlist) ─────────────

    /// <summary>
    /// 大工程・小工程からロット一覧を検索する。
    /// lot_.oplotlist MSG_VER="07.00" CLASS_DIVISION="27"
    /// VBソース: CMstrlot_oplotlistVer = "07.00", CPstrCD27
    /// </summary>
    public async Task<LotIdListResult> SearchLotsByProcessAsync(
        string opId,
        string stepId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,        "07.00");
        req.AddString(Tags.ClassDivision, "27");
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.OpId,          opId);
        req.AddString(Tags.StepId,        stepId);
        req.AddMsgAry(Tags.PdList,        new TfMsgAry());     // 全機種
        req.AddMsgAry(Tags.FlowClassList, new TfMsgAry());     // 全種別

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotOpList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotOpList(EN02I0 CD27) failed. OpId={OpId} StepId={StepId}", opId, stepId);
            return new LotIdListResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = TfMsg.ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var err = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            return new LotIdListResult(false, string.IsNullOrEmpty(err) ? "工程別ロット検索に失敗しました。" : err);
        }

        var ids = aMsg.GetMsgAry(Tags.LotList)
            .Select(e => e.GetString(Tags.LotId))
            .Where(id => !string.IsNullOrEmpty(id))
            .ToList();

        return new LotIdListResult(true, LotIds: ids);
    }

    // ──────── 区間優先設定情報取得 (lot_.secpriority) ────────────

    /// <summary>
    /// 区間優先設定情報を取得する。
    /// lot_.secpriority MSG_VER="02.00"
    /// lotIds に "ALL" を含めると区間優先設定ありの全ロットを取得する。
    /// VBソース: pubblnLotSectionPriority_Sel, CMstrlot_secPriorityVer = "02.00"
    /// </summary>
    public async Task<SecPriorityListResult> GetSectionPriorityAsync(
        IReadOnlyList<string> lotIds,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,   _sbId);
        req.AddString(Tags.MsgVer, "02.00");

        var ary = new TfMsgAry();
        foreach (var id in lotIds)
        {
            var t = new TfMsg();
            t.AddString(Tags.LotId, id);
            ary.Add(t);
        }
        req.AddMsgAry(Tags.LotList, ary);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotSecPriority, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotSecPriority failed");
            return new SecPriorityListResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = TfMsg.ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var err = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            logger.LogWarning("LotSecPriority returned FALSE. Err={Err}", err);
            return new SecPriorityListResult(false, string.IsNullOrEmpty(err) ? "区間優先設定情報の取得に失敗しました。" : err);
        }

        var items = aMsg.GetMsgAry(Tags.SecPriorityList)
            .Select(e => new SecPriorityItem(
                LotId:           e.GetString(Tags.LotId),
                GrbClass:        e.GetString(Tags.GrbClass),
                CarrierId:       e.GetString(Tags.CarrierId),
                StartOpId:       e.GetString(Tags.StartOpId),
                StartStepId:     e.GetString(Tags.StartStepId),
                EndOpId:         e.GetString(Tags.EndOpId),
                EndStepId:       e.GetString(Tags.EndStepId),
                SectionPriority: e.GetString(Tags.SectionPriority),
                EmpName:         e.GetString(Tags.EmpName),
                EntryTime:       e.GetString(Tags.EntryTime),
                OpId:            e.GetString(Tags.OpId),
                StepId:          e.GetString(Tags.StepId),
                LotPriority:     e.GetString(Tags.LotPriority),
                LotHoldFlag:     e.GetString(Tags.LotHoldFlag),
                LotStopFlag:     e.GetString(Tags.LotStopFlag)
            )).ToList();

        return new SecPriorityListResult(true, Items: items);
    }

    // ──────── 区間優先設定変更 (lot_.chgsecpriority) ─────────────

    /// <summary>
    /// 区間優先設定を変更する。
    /// lot_.chgsecpriority MSG_VER="01.00"
    /// VBソース: pubblnLotSectionPriority_Reg, CMstrlot_chgSecnPriorityVer = "01.00"
    /// </summary>
    public async Task<ChangeResult> ChangeSectionPriorityAsync(
        IReadOnlyList<ChangeItem> items,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,   _sbId);
        req.AddString(Tags.MsgVer, "01.00");

        var ary = new TfMsgAry();
        foreach (var item in items)
        {
            var t = new TfMsg();
            t.AddString(Tags.LotId,          item.LotId);
            t.AddString(Tags.StartOpId,       item.StartOpId);
            t.AddString(Tags.StartStepId,     item.StartStepId);
            t.AddString(Tags.EndOpId,         item.EndOpId);
            t.AddString(Tags.EndStepId,       item.EndStepId);
            t.AddString(Tags.SectionPriority, item.SectionPriority);
            t.AddString(Tags.EmpId,           item.EmpId);
            ary.Add(t);
        }
        req.AddMsgAry(Tags.SecPriorityList, ary);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotChgSecPriority, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotChgSecPriority failed");
            return new ChangeResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = TfMsg.ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var msgCode = aMsg.GetString(Tags.MsgCode);
            var err     = aMsg.GetString(Tags.Msg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.ErrMsg);
            logger.LogWarning("LotChgSecPriority returned FALSE. MsgCode={MsgCode}, Err={Err}", msgCode, err);
            return new ChangeResult(false, string.IsNullOrEmpty(err) ? "区間優先設定の変更に失敗しました。" : err, msgCode);
        }

        return new ChangeResult(true);
    }

    // ──────── 内部ヘルパー ────────────────────────────────────────
}
