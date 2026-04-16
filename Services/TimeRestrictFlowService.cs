namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN02O0 時間制限流動設定 のサービス。
/// VBソース: VB/02O0/CtsfrmxxEN02O0.vb, VB/02O0/CtsbasxxMG02O0.vb
/// </summary>
public sealed class TimeRestrictFlowService(ITfMessageClient mq, IConfiguration cfg, ILogger<TimeRestrictFlowService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 公開型 ────────────────────────────────────────────

    /// <summary>
    /// フロー制限1件。time.restrictstatus 応答の RESTRICT_FLOW_LIST 要素。
    /// VBソース: typRestrictFlowList
    /// </summary>
    public sealed record FlowItem(
        string FromOpId,
        string FromStepId,
        string ToOpId,
        string ToStepId,
        string LotStopOn,
        string EditEmpName,
        string EditTime
    );

    /// <summary>
    /// 装置制限1件。time.restrictstatus 応答の RESTRICT_WP_LIST 要素。
    /// VBソース: typRestrictWpList
    /// </summary>
    public sealed record WpItem(
        string WpId,
        string WpName,
        string SeqNum,
        string ProcessingName,
        string LotStopOff,
        string WaitLotNum,
        string EditEmpName,
        string EditTime
    );

    public sealed record RestrictStatusResult(
        bool IsSuccess,
        string ErrorMessage = "",
        IReadOnlyList<FlowItem>? FlowItems = null,
        IReadOnlyList<WpItem>? WpItems = null
    );

    /// <summary>
    /// 登録用フロー行。EDIT_FLAG="1" の行のみ変更として扱われる。
    /// </summary>
    public sealed record RegistFlowItem(
        string FromOpId,
        string FromStepId,
        string ToOpId,
        string ToStepId,
        string LotStopOn,
        string EditFlag
    );

    /// <summary>
    /// 登録用装置行。EDIT_FLAG="1" の行のみ変更として扱われる。
    /// </summary>
    public sealed record RegistWpItem(
        string WpId,
        string SeqNum,
        string LotStopOff,
        string WaitLotNum,
        string EditFlag
    );

    public sealed record RegistResult(bool IsSuccess, string ErrorMessage = "", string MsgCode = "");

    // ──────── 取得 (time.restrictstatus) ─────────────────────────

    /// <summary>
    /// 時間制限流動設定情報を取得する。
    /// time.restrictstatus MSG_VER="01.00"
    /// VBソース: pubblnRestrictStatus_Sel, CMstrtimeRestrictstatusVer = "01.00"
    /// </summary>
    public async Task<RestrictStatusResult> GetRestrictStatusAsync(
        string restrictType,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,         _sbId);
        req.AddString(Tags.MsgVer,       "01.00");
        req.AddString(Tags.RestrictType, restrictType);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.TimeRestrictStatus, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "TimeRestrictStatus failed. RestrictType={Type}", restrictType);
            return new RestrictStatusResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var err = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            logger.LogWarning("TimeRestrictStatus returned FALSE. Err={Err}", err);
            return new RestrictStatusResult(false, string.IsNullOrEmpty(err) ? "時間制限流動設定の取得に失敗しました。" : err);
        }

        var flowItems = aMsg.GetMsgAry(Tags.RestrictFlowList)
            .Select(e => new FlowItem(
                FromOpId:    e.GetString(Tags.FromOpId),
                FromStepId:  e.GetString(Tags.FromStepId),
                ToOpId:      e.GetString(Tags.ToOpId),
                ToStepId:    e.GetString(Tags.ToStepId),
                LotStopOn:   e.GetString(Tags.LotStopOn),
                EditEmpName: e.GetString(Tags.EditEmpName),
                EditTime:    e.GetString(Tags.EditTime)
            )).ToList();

        var wpItems = aMsg.GetMsgAry(Tags.RestrictWpList)
            .Select(e => new WpItem(
                WpId:           e.GetString(Tags.WpId),
                WpName:         e.GetString(Tags.WpName),
                SeqNum:         e.GetString(Tags.SeqNum),
                ProcessingName: e.GetString(Tags.ProcessingName),
                LotStopOff:     e.GetString(Tags.LotStopOff),
                WaitLotNum:     e.GetString(Tags.WaitLotNum),
                EditEmpName:    e.GetString(Tags.EditEmpName),
                EditTime:       e.GetString(Tags.EditTime)
            )).ToList();

        return new RestrictStatusResult(true, FlowItems: flowItems, WpItems: wpItems);
    }

    // ──────── 登録 (time.restrictregist) ──────────────────────────

    /// <summary>
    /// 時間制限流動設定を変更する（変更行のみ EDIT_FLAG="1" で送信）。
    /// time.restrictregist MSG_VER="01.00"
    /// VBソース: pubblnRestrictRegist_Upd, CMstrtimeRestrictregistVer = "01.00"
    /// </summary>
    public async Task<RegistResult> RegistRestrictAsync(
        string empId,
        string restrictType,
        IReadOnlyList<RegistFlowItem> flowItems,
        IReadOnlyList<RegistWpItem> wpItems,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,         _sbId);
        req.AddString(Tags.MsgVer,       "01.00");
        req.AddString(Tags.EmpId,        empId);
        req.AddString(Tags.RestrictType, restrictType);

        var flowAry = new TfMsgAry();
        foreach (var item in flowItems)
        {
            var t = new TfMsg();
            t.AddString(Tags.FromOpId,   item.FromOpId);
            t.AddString(Tags.FromStepId, item.FromStepId);
            t.AddString(Tags.ToOpId,     item.ToOpId);
            t.AddString(Tags.ToStepId,   item.ToStepId);
            t.AddString(Tags.LotStopOn,  item.LotStopOn);
            t.AddString(Tags.EditFlag,   item.EditFlag);
            flowAry.Add(t);
        }
        req.AddMsgAry(Tags.RestrictFlowList, flowAry);

        var wpAry = new TfMsgAry();
        foreach (var item in wpItems)
        {
            var t = new TfMsg();
            t.AddString(Tags.WpId,       item.WpId);
            t.AddString(Tags.SeqNum,     item.SeqNum);
            t.AddString(Tags.LotStopOff, item.LotStopOff);
            t.AddString(Tags.WaitLotNum, item.WaitLotNum);
            t.AddString(Tags.EditFlag,   item.EditFlag);
            wpAry.Add(t);
        }
        req.AddMsgAry(Tags.RestrictWpList, wpAry);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.TimeRestrictRegist, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "TimeRestrictRegist failed");
            return new RegistResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var msgCode = aMsg.GetString(Tags.MsgCode);
            var err     = aMsg.GetString(Tags.Msg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.ErrMsg);
            logger.LogWarning("TimeRestrictRegist returned FALSE. MsgCode={MsgCode}, Err={Err}", msgCode, err);
            return new RegistResult(false, string.IsNullOrEmpty(err) ? "時間制限流動設定の変更に失敗しました。" : err, msgCode);
        }

        return new RegistResult(true);
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
