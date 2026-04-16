namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN02A0 工程戻し のサービス。
/// VBソース: VB/02A0/CtsfrmxxEN02A0.vb, VB/02A0/CtsbasxxMG02A0.vb
/// </summary>
public sealed class LotStepBackService(ITfMessageClient mq, IConfiguration cfg, ILogger<LotStepBackService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── メッセージID定数 ────────────────────────────────────
    // VBソース: CtsbasxxCM0010.vb 361-363行
    private const string MsgMntOpStepList = "mnt_.opsteplist"; // 流動済工程情報取得
    private const string MsgMntEventHist  = "mnt_.eventhist";  // イベント履歴取得
    private const string MsgMntDelHist    = "mnt_.delhist_";   // イベント履歴削除(工程戻し実行)

    // ──────── タグ定数 ────────────────────────────────────────────
    // VBソース: CtsbasxxCM0010.vb 各行参照
    private const string TagOpList          = "OP_LIST";           // 820行相当 (工程リスト)
    private const string TagEventList       = "EVENT_LIST";        // 820行: CPstrEVENT_LIST
    private const string TagLotEventId      = "LOT_EVENT_ID";     // 1082行: CPstrLOT_EVENT_ID
    private const string TagEventName       = "EVENT_NAME";        // 821行: CPstrEVENT_NAME
    private const string TagDeleteProhibited = "DELETE_PROHIBITED"; // 707行: CPstrDELETE_PROHIBITED

    // ──────── 公開型 ────────────────────────────────────────────

    /// <summary>
    /// ロット現在状態取得結果。
    /// VBソース: CMstrlot_curstateVer = "04.00", CLASS_DIVISION = CPstrCD08 = "08"
    /// </summary>
    public sealed record LotCurStateResult(
        bool IsSuccess,
        string ErrorMessage = "",
        string LotId = "",
        string OpId = "",
        string StepId = "",
        string PdId = "",
        string PdName = "",
        string NowSt = "",
        string WfNum = "",
        string EngEmpName = "",
        string LotLastUpdate = ""
    );

    /// <summary>
    /// 戻し小工程エントリ。
    /// VBソース: RollBackStepList.strStepID
    /// </summary>
    public sealed record StepEntry(string StepId);

    /// <summary>
    /// 戻し大工程エントリ（配下の小工程一覧含む）。
    /// VBソース: RollBackOpList.strOpID, typStepList
    /// </summary>
    public sealed record OpEntry(
        string OpId,
        IReadOnlyList<StepEntry> StepList
    );

    /// <summary>
    /// 流動済工程情報取得結果。
    /// VBソース: pubblnMntOpStepList_Sel (CtsbasxxMG02A0.vb)
    /// </summary>
    public sealed record OpStepListResult(
        bool IsSuccess,
        string ErrorMessage = "",
        IReadOnlyList<OpEntry>? OpList = null
    );

    /// <summary>
    /// イベント履歴1件。
    /// VBソース: EventList (CtsfrmxxEN02A0.vb, vsfEventHistoryList 列定義)
    /// </summary>
    public sealed record EventHistEntry(
        string OpId,
        string StepId,
        string LotEventId,
        string LotEventName,
        string EntryTime,
        string EmpId,
        string EmpName,
        string Comments,
        string DeleteProhibited  // "0"=削除可, "1"=削除不可
    );

    /// <summary>
    /// イベント履歴取得結果。
    /// VBソース: pubblnMntEventHist_Sel (CtsbasxxMG02A0.vb)
    /// </summary>
    public sealed record EventHistResult(
        bool IsSuccess,
        string ErrorMessage = "",
        string LotId = "",
        string LotLastUpdate = "",
        IReadOnlyList<EventHistEntry>? EventList = null
    );

    /// <summary>
    /// 工程戻し実行結果。
    /// VBソース: pubblnMntDelHist__Upd (CtsbasxxMG02A0.vb)
    /// </summary>
    public sealed record StepBackResult(
        bool IsSuccess,
        string ErrorMessage = "",
        string MsgCode = ""
    );

    // ──────── 現工程情報取得 (lot_.curstate) ─────────────────────

    /// <summary>
    /// キャリアIDからロットの現工程情報を取得する。
    /// lot_.curstate MSG_VER="04.00" CLASS_DIVISION="08"
    /// VBソース: CMstrlot_curstateVer = "04.00", CPstrCD08 = "08"
    /// </summary>
    public async Task<LotCurStateResult> GetLotInfoAsync(
        string carrierId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.MsgVer,        "04.00");
        req.AddString(Tags.ClassDivision, "08");
        req.AddString(Tags.CarrierId,     carrierId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotCurState, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotCurState(EN02A0) failed. CarrierId={Id}", carrierId);
            return new LotCurStateResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var err = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            logger.LogWarning("LotCurState(EN02A0) returned FALSE. Err={Err}", err);
            return new LotCurStateResult(false, string.IsNullOrEmpty(err) ? "ロット情報の取得に失敗しました。" : err);
        }

        return new LotCurStateResult(
            IsSuccess:     true,
            LotId:         aMsg.GetString(Tags.LotId),
            OpId:          aMsg.GetString(Tags.OpId),
            StepId:        aMsg.GetString(Tags.StepId),
            PdId:          aMsg.GetString(Tags.PdId),
            PdName:        aMsg.GetString(Tags.PdName),
            NowSt:         aMsg.GetString(Tags.NowSt),
            WfNum:         aMsg.GetString(Tags.WfNum),
            EngEmpName:    aMsg.GetString(Tags.EngEmpName),
            LotLastUpdate: aMsg.GetString(Tags.LotLastUpdate)
        );
    }

    // ──────── 流動済工程情報取得 (mnt_.opsteplist) ────────────────

    /// <summary>
    /// 指定ロットの戻し可能な大工程/小工程一覧を取得する。
    /// mnt_.opsteplist MSG_VER="01.00"
    /// VBソース: CMstrmnt_opsteplistVer = "01.00", pubblnMntOpStepList_Sel
    /// </summary>
    public async Task<OpStepListResult> GetOpStepListAsync(
        string lotId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer, "01.00");
        req.AddString(Tags.SbId,   _sbId);
        req.AddString(Tags.LotId,  lotId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgMntOpStepList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "MntOpStepList(EN02A0) failed. LotId={Id}", lotId);
            return new OpStepListResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var err = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            logger.LogWarning("MntOpStepList(EN02A0) returned FALSE. Err={Err}", err);
            return new OpStepListResult(false, string.IsNullOrEmpty(err) ? "流動済工程情報の取得に失敗しました。" : err);
        }

        var opList = aMsg.GetMsgAry(TagOpList)
            .Select(opMsg => new OpEntry(
                OpId:     opMsg.GetString(Tags.OpId),
                StepList: opMsg.GetMsgAry(Tags.StepList)
                               .Select(s => new StepEntry(s.GetString(Tags.StepId)))
                               .ToList()
            )).ToList();

        return new OpStepListResult(true, OpList: opList);
    }

    // ──────── イベント履歴取得 (mnt_.eventhist) ───────────────────

    /// <summary>
    /// 指定ロット・工程のイベント履歴一覧を取得する。
    /// mnt_.eventhist MSG_VER="01.00"
    /// VBソース: CMstrmnt_eventhistVer = "01.00", pubblnMntEventHist_Sel
    /// </summary>
    public async Task<EventHistResult> GetEventHistAsync(
        string lotId,
        string opId,
        string stepId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,  "01.00");
        req.AddString(Tags.SbId,    _sbId);
        req.AddString(Tags.LotId,   lotId);
        req.AddString(Tags.OpId,    opId);
        req.AddString(Tags.StepId,  stepId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgMntEventHist, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "MntEventHist(EN02A0) failed. LotId={Id}", lotId);
            return new EventHistResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var err = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            logger.LogWarning("MntEventHist(EN02A0) returned FALSE. Err={Err}", err);
            return new EventHistResult(false, string.IsNullOrEmpty(err) ? "イベント履歴の取得に失敗しました。" : err);
        }

        var evList = aMsg.GetMsgAry(TagEventList)
            .Select(e => new EventHistEntry(
                OpId:             e.GetString(Tags.OpId),
                StepId:           e.GetString(Tags.StepId),
                LotEventId:       e.GetString(TagLotEventId),
                LotEventName:     e.GetString(TagEventName),
                EntryTime:        e.GetString(Tags.EntryTime),
                EmpId:            e.GetString(Tags.EmpId),
                EmpName:          e.GetString(Tags.EmpName),
                Comments:         e.GetString(Tags.Comments),
                DeleteProhibited: e.GetString(TagDeleteProhibited)
            )).ToList();

        return new EventHistResult(
            IsSuccess:     true,
            LotId:         aMsg.GetString(Tags.LotId),
            LotLastUpdate: aMsg.GetString(Tags.LotLastUpdate),
            EventList:     evList
        );
    }

    // ──────── 工程戻し実行 (mnt_.delhist_) ───────────────────────

    /// <summary>
    /// 工程戻し（イベント履歴削除）を実行する。
    /// mnt_.delhist_ MSG_VER="01.00"
    /// VBソース: CMstrmnt_delhist_Ver = "01.00", pubblnMntDelHist__Upd
    ///
    /// 送信パラメータ（VBソース prvEventRequestDateSet_Proc ケース"2:ｲﾍﾞﾝﾄ履歴削除"参照）:
    ///   LOT_ID, OP_ID, STEP_ID, EMP_ID, COMMENTS, LOT_LAST_UPDATE
    /// </summary>
    public async Task<StepBackResult> ExecuteStepBackAsync(
        string lotId,
        string opId,
        string stepId,
        string empId,
        string lotLastUpdate,
        string comments = "",
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,          "01.00");
        req.AddString(Tags.SbId,            _sbId);
        req.AddString(Tags.LotId,           lotId);
        req.AddString(Tags.OpId,            opId);
        req.AddString(Tags.StepId,          stepId);
        req.AddString(Tags.EmpId,           empId);
        req.AddString(Tags.Comments,        comments);
        req.AddString(Tags.LotLastUpdate,   lotLastUpdate);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgMntDelHist, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "MntDelHist(EN02A0) failed. LotId={Id}", lotId);
            return new StepBackResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var msgCode = aMsg.GetString(Tags.MsgCode);
            var err     = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            logger.LogWarning("MntDelHist(EN02A0) returned FALSE. MsgCode={MsgCode}, Err={Err}", msgCode, err);
            return new StepBackResult(false, string.IsNullOrEmpty(err) ? "工程戻しに失敗しました。" : err, msgCode);
        }

        return new StepBackResult(true);
    }

    // ──────── 内部ヘルパー ────────────────────────────────────────

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
