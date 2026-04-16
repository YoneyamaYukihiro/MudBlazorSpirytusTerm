namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN00V0 工程異常/不適合品処理票一覧 のサービス。
/// VBソース: VB/00V0/CtsfrmxxEN00V0.vb, VB/00V0/CtsbasxxMG00V0.vb
/// </summary>
public sealed class AbnormalProcessingService(ITfMessageClient mq, IConfiguration cfg, ILogger<AbnormalProcessingService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── メッセージID定数 ────────────────────────────────────
    // VBソース: CPstrexcpreportlist / CPstrexcpapply___ / CPstrexcpcancelapply / CPstrexcpdelete__

    private const string MsgExcpReportList  = "excp.reportlist";    // 工程異常/不適合品処理票一覧取得
    private const string MsgExcpApply       = "excp.apply___";      // 処理票適用(承認)
    private const string MsgExcpCancelApply = "excp.cancelapply";   // 工程異常/不適合品承認取消
    private const string MsgExcpDelete      = "excp.delete__";      // 処理票破棄

    // ──────── メッセージバージョン定数 ──────────────────────────────
    // VBソース: CMstrexcpreportlistVer / CPstrexcpapply__Ver / CPstrexcpcancelapplyVer / CPstrexcpdelete__Ver

    private const string VerReportList  = "02.00";
    private const string VerApply       = "02.00";
    private const string VerCancelApply = "01.00";
    private const string VerDelete      = "02.00";

    // ──────── CLASS_DIVISION定数 ─────────────────────────────────
    // VBソース: CPstrCD02 = "02" (全件), CPstrCD31 = "31" (CFのみ)
    public const string ClassDivisionAll = "02";   // 全件
    public const string ClassDivisionCf  = "31";   // CFのみ

    // ──────── 公開型 ─────────────────────────────────────────────

    /// <summary>
    /// 処理票一覧の1ロット。REPORT_LIST > LOT_LIST 要素。
    /// VBソース: ExcpLotList
    /// </summary>
    public sealed record ExcpLotEntry(string LotId);

    /// <summary>
    /// 処理票一覧の1担当者。REPORT_LIST > TO_EMP_LIST 要素。
    /// VBソース: ExcpEmpList
    /// </summary>
    public sealed record ToEmpEntry(string EmpId, string EmpName);

    /// <summary>
    /// 処理票一覧の1レコード。REPORT_LIST 要素。
    /// VBソース: ReportListAns
    /// 帳票種別: "0"=工程異常処理票, "1"=不適合品処理票
    /// 承認フラグ: "0"=未処置, "1"=処置済, "2"=承認済
    /// </summary>
    public sealed record AbnormalItem(
        string DocClass,            // 帳票種別 DOC_CLASS  "0"=工程異常, "1"=不適合品
        string FindDate,            // 発見日時 FIND_DATE
        string FindEmpId,           // 起案者ID FIND_EMP_ID
        string FindEmpName,         // 起案者名 FIND_EMP_NAME
        string ExcpItemName,        // 工程異常名 EXCP_ITEM_NAME
        string ExcpNo,              // 工程異常№ EXCP_NO
        string ApprovalFlag,        // 承認フラグ APPROVAL_FLAG
        string AllDisposalFlag,     // 全処置フラグ ALL_DISPOSAL_FLAG
        string FindWpId,            // 発見時装置ID FIND_WP_ID
        string FindWpName,          // 発見時装置名 FIND_WP_NAME
        string FromEntryTime,       // 確認依頼日 WORKFLOW_ENTRY_TIME
        string FromEmpId,           // 確認依頼元ID FROM_EMP_ID
        string FromEmpName,         // 確認依頼元名 FROM_EMP_NAME
        string EditTime,            // 更新日時 EDIT_TIME
        string FindOpId,            // 大工程 FIND_OP_ID
        string FindStepId,          // 小工程 FIND_STEP_ID
        string DispoName,           // 処置名 DISPO_NAME
        string DispoWfNum,          // 処置WF数 DISPO_WF_NUM
        string ExcpSitu,            // 工程異常発生状況 EXCP_SITUATION
        IReadOnlyList<ExcpLotEntry> LotList,
        IReadOnlyList<ToEmpEntry>   ToEmpList
    );

    public sealed record ListResult(
        bool IsSuccess,
        string ErrorMessage = "",
        IReadOnlyList<AbnormalItem>? Items = null
    );

    public sealed record ApplyResult(
        bool IsSuccess,
        string ErrorMessage = ""
    );

    // ──────── 処理票一覧取得 (excp.reportlist) ─────────────────────

    /// <summary>
    /// 工程異常/不適合品処理票一覧を取得する。
    /// excp.reportlist MSG_VER="02.00"
    /// VBソース: CMstrexcpreportlistVer = "02.00", prvblnExcpList_Sel
    /// CLASS_DIVISION: "02"=全件
    /// </summary>
    public async Task<ListResult> GetListAsync(
        string startDate,
        string endDate,
        string classDivision  = ClassDivisionAll,
        string findEmpId      = "",
        string toEmpId        = "",
        CancellationToken ct  = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,        VerReportList);
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.ClassDivision, classDivision);
        req.AddString(Tags.StartDate,     startDate);
        req.AddString(Tags.EndDate,       endDate);
        req.AddString("FIND_EMP_ID",      findEmpId);
        req.AddString("FIND_TO_EMP_ID",   toEmpId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgExcpReportList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ExcpReportList(EN00V0) failed.");
            return new ListResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var err = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            logger.LogWarning("ExcpReportList(EN00V0) returned FALSE. Err={Err}", err);
            return new ListResult(false, string.IsNullOrEmpty(err) ? "処理票一覧の取得に失敗しました。" : err);
        }

        var items = aMsg.GetMsgAry("REPORT_LIST")
            .Select(e =>
            {
                var lotList = e.GetMsgAry(Tags.LotList)
                    .Select(l => new ExcpLotEntry(l.GetString(Tags.LotId)))
                    .ToList();

                var toEmpList = e.GetMsgAry("TO_EMP_LIST")
                    .Select(t => new ToEmpEntry(t.GetString(Tags.EmpId), t.GetString("EMP_NAME")))
                    .ToList();

                return new AbnormalItem(
                    DocClass:        e.GetString("DOC_CLASS"),
                    FindDate:        e.GetString("FIND_DATE"),
                    FindEmpId:       e.GetString("FIND_EMP_ID"),
                    FindEmpName:     e.GetString("FIND_EMP_NAME"),
                    ExcpItemName:    e.GetString("EXCP_ITEM_NAME"),
                    ExcpNo:          e.GetString("EXCP_NO"),
                    ApprovalFlag:    e.GetString("APPROVAL_FLAG"),
                    AllDisposalFlag: e.GetString("ALL_DISPOSAL_FLAG"),
                    FindWpId:        e.GetString("FIND_WP_ID"),
                    FindWpName:      e.GetString("FIND_WP_NAME"),
                    FromEntryTime:   e.GetString("WORKFLOW_ENTRY_TIME"),
                    FromEmpId:       e.GetString("FROM_EMP_ID"),
                    FromEmpName:     e.GetString("FROM_EMP_NAME"),
                    EditTime:        e.GetString(Tags.EditTime),
                    FindOpId:        e.GetString("FIND_OP_ID"),
                    FindStepId:      e.GetString("FIND_STEP_ID"),
                    DispoName:       e.GetString("DISPO_NAME"),
                    DispoWfNum:      e.GetString("DISPO_WF_NUM"),
                    ExcpSitu:        e.GetString("EXCP_SITUATION"),
                    LotList:         lotList,
                    ToEmpList:       toEmpList
                );
            })
            .ToList();

        return new ListResult(true, Items: items);
    }

    // ──────── 処理票適用(承認) (excp.apply___) ──────────────────────

    /// <summary>
    /// 処理票を承認する。
    /// excp.apply___ MSG_VER="02.00"
    /// VBソース: CPstrexcpapply__Ver = "02.00", publnExcpApply_Ins
    /// </summary>
    public async Task<ApplyResult> ApplyAsync(
        string excpNo,
        string empId,
        string editTime,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,   VerApply);
        req.AddString(Tags.SbId,     _sbId);
        req.AddString("EXCP_NO",     excpNo);
        req.AddString(Tags.EmpId,    empId);
        req.AddString(Tags.EditTime, editTime);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgExcpApply, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ExcpApply(EN00V0) failed. ExcpNo={No}", excpNo);
            return new ApplyResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var err = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            logger.LogWarning("ExcpApply(EN00V0) returned FALSE. Err={Err}", err);
            return new ApplyResult(false, string.IsNullOrEmpty(err) ? "処理票適用に失敗しました。" : err);
        }

        return new ApplyResult(true);
    }

    // ──────── 承認取消 (excp.cancelapply) ────────────────────────────

    /// <summary>
    /// 工程異常/不適合品の承認を取り消す。
    /// excp.cancelapply MSG_VER="01.00"
    /// VBソース: CPstrexcpcancelapplyVer = "01.00", publnExcpCancelApply_Upd
    /// </summary>
    public async Task<ApplyResult> CancelApplyAsync(
        string excpNo,
        string empId,
        string editTime,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,   VerCancelApply);
        req.AddString(Tags.SbId,     _sbId);
        req.AddString("EXCP_NO",     excpNo);
        req.AddString(Tags.EmpId,    empId);
        req.AddString(Tags.EditTime, editTime);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgExcpCancelApply, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ExcpCancelApply(EN00V0) failed. ExcpNo={No}", excpNo);
            return new ApplyResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var err = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            logger.LogWarning("ExcpCancelApply(EN00V0) returned FALSE. Err={Err}", err);
            return new ApplyResult(false, string.IsNullOrEmpty(err) ? "承認取消に失敗しました。" : err);
        }

        return new ApplyResult(true);
    }

    // ──────── 処理票破棄 (excp.delete__) ─────────────────────────────

    /// <summary>
    /// 処理票を破棄する。
    /// excp.delete__ MSG_VER="02.00"
    /// VBソース: CPstrexcpdelete__Ver = "02.00", publnExcpDelete_Upd
    /// </summary>
    public async Task<ApplyResult> DeleteAsync(
        string excpNo,
        string empId,
        string editTime,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,   VerDelete);
        req.AddString(Tags.SbId,     _sbId);
        req.AddString("EXCP_NO",     excpNo);
        req.AddString(Tags.EmpId,    empId);
        req.AddString(Tags.EditTime, editTime);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgExcpDelete, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "ExcpDelete(EN00V0) failed. ExcpNo={No}", excpNo);
            return new ApplyResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var err = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            logger.LogWarning("ExcpDelete(EN00V0) returned FALSE. Err={Err}", err);
            return new ApplyResult(false, string.IsNullOrEmpty(err) ? "処理票破棄に失敗しました。" : err);
        }

        return new ApplyResult(true);
    }

    // ──────── 内部ヘルパー ─────────────────────────────────────────

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
