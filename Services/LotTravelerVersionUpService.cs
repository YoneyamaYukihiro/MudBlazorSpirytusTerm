namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// 流動票バージョンアップサービス。
/// ・流動票バージョンアップ対象一覧  (lot_.chgtrvlist)
/// ・流動票バージョンアップ           (lot_.chgtraveler)
/// ・流動票バージョンアップ状態変更   (lot_.chgtrvprohibit)
/// ・CONTエッチャーAPC区間チェック   (lot_.chkContEtApc)
/// VBソース: CtsbasxxMG01K0.vb
/// </summary>
public sealed class LotTravelerVersionUpService(ITfMessageClient mq, IConfiguration cfg, ILogger<LotTravelerVersionUpService> logger)
{
    private readonly string _defaultSbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 公開型 ────────────────────────────────────────────

    /// <summary>流動票バージョンアップ対象一覧の1ロット要素。VBソース: ChgTrvListAns 構造体</summary>
    public sealed record ChgTrvListItem(
        string LotId,
        string CarrierId,
        string FlowClass,
        string OpId,
        string StepId,
        string NowSt,
        string EngEmpName,
        string LotHoldFlag,
        string LotStopFlag,
        string LotPriority,
        string CurrentPositionName,
        string LotCommentsFlag,
        string CommitFlag,
        string LotLastUpdate,
        string ProcChangeFlag,
        string VersionChangeFlag,
        string EntryId,
        string WfRecipeFlag,
        string LotRecipeFlag,
        string PdId,
        string LcDirection,
        string MasEntryId,
        string ReworkFlag,
        string SwapFlag,
        string AltFlag,
        string WfCarryFlag,
        string VerUpProhibitedFlag,
        string ProhibitedEmpName,
        string ProhibitedDeptName,
        string ReworkCount,
        string SamplingFlag,
        string SendSbId,
        string SbArea
    );

    /// <summary>バージョンアップ応答の1ロット要素。VBソース: AnsTravelerList 構造体</summary>
    public sealed record AnsTravelerItem(
        string LotId,
        string OpId,
        string StepId
    );

    /// <summary>バージョンアップ要求の1ロット要素。VBソース: ChgTravelerList 構造体</summary>
    public sealed record ChgTravelerLotItem(
        string LotId,
        string Comments,
        string LotLastUpdate,
        string SamplingFlag = ""
    );

    // ──────── 流動票バージョンアップ対象一覧 ────────────────────

    /// <summary>
    /// 流動票バージョンアップ対象一覧を取得する。
    /// VBソース: pubblnChgTrvlist_Sel, MsgVer="05.01"
    /// </summary>
    public async Task<IReadOnlyList<ChgTrvListItem>?> GetChgTrvListAsync(
        IEnumerable<string> pdIds,
        IEnumerable<string> flowClasses,
        string lotFlowStatusId  = "",
        string lotId            = "",
        CancellationToken ct    = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,             _defaultSbId);
        req.AddString(Tags.MsgVer,           "05.01");

        var pdAry = new TfMsgAry();
        foreach (var pdId in pdIds)
        {
            var e = new TfMsg();
            e.AddString(Tags.PdId, pdId);
            pdAry.Add(e);
        }
        req.AddMsgAry(Tags.PdList, pdAry);

        var flowAry = new TfMsgAry();
        foreach (var fc in flowClasses)
        {
            var e = new TfMsg();
            e.AddString(Tags.FlowClass, fc);
            flowAry.Add(e);
        }
        req.AddMsgAry(Tags.FlowClassList, flowAry);

        req.AddString(Tags.LotFlowStatusId, lotFlowStatusId);
        req.AddString(Tags.LotId,           lotId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotChgTrvList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotChgTrvList request failed.");
            return null;
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("LotChgTrvList returned non-TRUE. Raw={Raw}", Summarize(raw));
            return null;
        }

        return msg.GetMsgAry(Tags.LotList)
            .Select(e => new ChgTrvListItem(
                LotId:               e.GetString(Tags.LotId),
                CarrierId:           e.GetString(Tags.CarrierId),
                FlowClass:           e.GetString(Tags.FlowClass),
                OpId:                e.GetString(Tags.OpId),
                StepId:              e.GetString(Tags.StepId),
                NowSt:               e.GetString(Tags.NowSt),
                EngEmpName:          e.GetString(Tags.EngEmpName),
                LotHoldFlag:         e.GetString(Tags.LotHoldFlag),
                LotStopFlag:         e.GetString(Tags.LotStopFlag),
                LotPriority:         e.GetString(Tags.LotPriority),
                CurrentPositionName: e.GetString(Tags.CurrentPositionName),
                LotCommentsFlag:     e.GetString(Tags.LotCommentsFlag),
                CommitFlag:          e.GetString(Tags.CommitFlag),
                LotLastUpdate:       e.GetString(Tags.LotLastUpdate),
                ProcChangeFlag:      e.GetString(Tags.ProcChangeFlag),
                VersionChangeFlag:   e.GetString(Tags.VersionChangeFlag),
                EntryId:             e.GetString(Tags.EntryId),
                WfRecipeFlag:        e.GetString(Tags.WfRecipeFlag),
                LotRecipeFlag:       e.GetString(Tags.LotRecipeFlag),
                PdId:                e.GetString(Tags.PdId),
                LcDirection:         e.GetString(Tags.LcDirection),
                MasEntryId:          e.GetString(Tags.MasEntryId),
                ReworkFlag:          e.GetString(Tags.ReworkFlag),
                SwapFlag:            e.GetString(Tags.SwapFlag),
                AltFlag:             e.GetString(Tags.AltFlag),
                WfCarryFlag:         e.GetString(Tags.WfCarryFlag),
                VerUpProhibitedFlag: e.GetString(Tags.VerUpProhibitedFlag),
                ProhibitedEmpName:   e.GetString(Tags.ProhibitedEmpName),
                ProhibitedDeptName:  e.GetString(Tags.ProhibitedDeptName),
                ReworkCount:         e.GetString(Tags.ReworkCount),
                SamplingFlag:        e.GetString(Tags.SamplingFlag),
                SendSbId:            e.GetString(Tags.SendSbId),
                SbArea:              e.GetString(Tags.SbArea)))
            .ToList();
    }

    // ──────── 流動票バージョンアップ ─────────────────────────────

    /// <summary>
    /// 流動票をバージョンアップする。
    /// VBソース: pubblnLotChgTraveler_Upd, MsgVer="02.00"
    /// </summary>
    /// <returns>成功した場合、更新結果ロットリスト（空の場合もあり）</returns>
    public async Task<IReadOnlyList<AnsTravelerItem>?> ChgTravelerAsync(
        string empId,
        IEnumerable<ChgTravelerLotItem> lots,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,   _defaultSbId);
        req.AddString(Tags.MsgVer, "02.00");
        req.AddString(Tags.EmpId,  empId);

        var lotAry = new TfMsgAry();
        foreach (var lot in lots)
        {
            var e = new TfMsg();
            e.AddString(Tags.LotId,         lot.LotId);
            e.AddString(Tags.Comments,       lot.Comments);
            e.AddString(Tags.LotLastUpdate,  lot.LotLastUpdate);
            e.AddString(Tags.SamplingFlag,   lot.SamplingFlag);
            lotAry.Add(e);
        }
        req.AddMsgAry(Tags.LotList, lotAry);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotChgTraveler, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotChgTraveler request failed.");
            return null;
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("LotChgTraveler returned non-TRUE. Raw={Raw}", Summarize(raw));
            return null;
        }

        return msg.GetMsgAry(Tags.LotList)
            .Select(e => new AnsTravelerItem(
                LotId:  e.GetString(Tags.LotId),
                OpId:   e.GetString(Tags.OpId),
                StepId: e.GetString(Tags.StepId)))
            .ToList();
    }

    // ──────── 流動票バージョンアップ状態変更 ─────────────────────

    /// <summary>
    /// 流動票バージョンアップの禁止/解除状態を変更する。
    /// VBソース: pubblnLotChgtrvprohibit_Upd, MsgVer="01.00"
    /// </summary>
    public async Task<bool> ChgTrvProhibitAsync(
        string lotId,
        string empId,
        string verUpProhibitedFlag,
        string lotLastUpdate,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,            "01.00");
        req.AddString(Tags.SbId,              _defaultSbId);
        req.AddString(Tags.LotId,             lotId);
        req.AddString(Tags.EmpId,             empId);
        req.AddString(Tags.VerUpProhibitedFlag, verUpProhibitedFlag);
        req.AddString(Tags.LotLastUpdate,     lotLastUpdate);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotChgTrvProhibit, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotChgTrvProhibit request failed. LotId={LotId}", lotId);
            return false;
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("LotChgTrvProhibit returned non-TRUE. LotId={LotId}, Raw={Raw}",
                lotId, Summarize(raw));
            return false;
        }

        return true;
    }

    // ──────── CONTエッチャーAPC区間チェック ──────────────────────

    /// <summary>
    /// CONTエッチャーAPC(2M-1P)区間かチェックする。
    /// VBソース: prvblnContEtApc_Chk, MsgVer="01.00"
    /// </summary>
    /// <returns>RESULT値（0:VerUp OK、1:VerUp NG、9:処理失敗）、通信失敗時null</returns>
    public async Task<string?> ChkContEtApcAsync(
        string lotId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer, "01.00");
        req.AddString(Tags.SbId,   _defaultSbId);
        req.AddString(Tags.LotId,  lotId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotChkContEtApc, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotChkContEtApc request failed. LotId={LotId}", lotId);
            return null;
        }

        var msg = ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("LotChkContEtApc returned non-TRUE. LotId={LotId}, Raw={Raw}",
                lotId, Summarize(raw));
            return null;
        }

        return msg.GetString(Tags.Result);
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
