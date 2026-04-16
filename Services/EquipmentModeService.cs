namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN00C0 運用モード変更/装置状態変更 サービス。
/// ・運用モード変更要求         (eq__.chgmode_)
/// ・運用モード強制変更要求     (eq__.emgchgmode)
/// ・搬送ポート有効・無効変更   (eq__.chgtrnstat)
/// ・装置処理順変更要求         (eq__.chgprocorder)
/// ・キャリア強制搬出要求       (eq__.carunload)
/// ・装置状態マスタ取得         (mas_.wpuselist)
/// ・装置状態変更               (eq__.chguse__)
/// ・装置状態メッセージ取得     (eq__.wpmsglist)
/// ・装置処理部用途取得         (mas_.wpprocessingnamelist)
/// ・装置処理部状態取得         (mas_.chamberuselist)
/// ・装置処理部用途リスト取得   (eq__.wpprocessinguse)
/// ・装置処理部用途変更         (eq__.chgwpprocessinguse)
/// VBソース: CtsbasxxMG00C0.vb / CtsbasxxCM0050.vb
/// </summary>
public sealed class EquipmentModeService(ITfMessageClient mq, IConfiguration cfg, ILogger<EquipmentModeService> logger)
{
    private readonly string _defaultSbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 公開型 ────────────────────────────────────────────

    /// <summary>運用モード変更要求。VBソース: EqChgMode 構造体</summary>
    public sealed record EqChgModeRequest(
        string WpId,
        string MesModeId,
        string EmpId,
        string UseId         = "",
        string OldUseId      = "",
        string WpStopFlag    = "",
        string MessageId     = "",
        string Comments      = "",
        string MsgVer        = "06.00"
    );

    /// <summary>運用モード変更結果</summary>
    public sealed record EqChgModeResult(
        bool IsSuccess,
        string GuidanceMsg      = "",
        string GuidanceMsgCode  = "",
        string EntryTime        = "",
        string ErrorCode        = "",
        string ErrorMessage     = ""
    );

    /// <summary>搬送ポート変更ポート情報。VBソース: trnportList 構造体</summary>
    public sealed record TransportPort(
        string PortId,
        string TransServiceStatus
    );

    /// <summary>搬送ポート有効・無効変更要求。VBソース: ChgtrnstatReq 構造体</summary>
    public sealed record ChangeTrnStatRequest(
        string WpId,
        string EmpId,
        IReadOnlyList<TransportPort> PortList,
        string Comments = "",
        string MsgVer   = "01.00"
    );

    /// <summary>装置処理順変更要求。VBソース: EqChgProcOrderReq 構造体</summary>
    public sealed record ChangeProcOrderRequest(
        string WpId,
        string EmpId,
        string RecipeFlowNum,
        string CollectTypeFlag,
        IReadOnlyList<string> CollectTypeNums,
        string Comments = "",
        string MsgVer   = "03.00"
    );

    /// <summary>装置状態マスタ項目。VBソース: UseList 構造体</summary>
    public sealed record WpUseItem(
        string UseId,
        string UseName,
        string UseEnableMode,
        string UseStopFlag,
        string MessageId,
        string MessageText,
        string NormalStateFlag
    );

    /// <summary>装置状態変更要求。VBソース: Usechange 構造体</summary>
    public sealed record ChangeWpUseRequest(
        string WpId,
        string UseId,
        string EmpId,
        string OldUseId      = "",
        string WpStopFlag    = "",
        string MessageId     = "",
        string Comments      = "",
        string ClassDivision = "",
        string MsgVer        = "05.00"
    );

    /// <summary>装置状態メッセージ。VBソース: MsgList 構造体</summary>
    public sealed record WpMessageItem(
        string MessageId,
        string MessageText
    );

    /// <summary>装置処理部用途。VBソース: ProcessingList 構造体</summary>
    public sealed record ProcessingNameItem(
        string ChamberId,
        string ProcessingName,
        string DispOnFlag
    );

    /// <summary>装置処理部状態。VBソース: ChamberUseList 構造体</summary>
    public sealed record ChamberUseItem(
        string UseId,
        string UseName
    );

    /// <summary>装置処理部用途リスト項目。VBソース: ProcessingUseList 構造体</summary>
    public sealed record ProcessingUseItem(
        string No,
        string ChamberId,
        string ChamberUseId,
        string OldChamberId,
        string OldChamberUseId,
        string EditTime
    );

    /// <summary>装置処理部用途変更要求。VBソース: ChgWpProcessingUseReq 構造体</summary>
    public sealed record ChangeWpProcessingUseRequest(
        string WpId,
        string EmpId,
        IReadOnlyList<ProcessingUseItem> ProcessingUseList,
        string Comments = "",
        string MsgVer   = "01.00"
    );

    // ──────── 運用モード変更 ────────────────────────────────────

    /// <summary>
    /// 運用モード/装置状態変更要求を送信する。
    /// VBソース: pubblnEqChgMode_Upd, MsgVer="06.00"
    /// </summary>
    public async Task<EqChgModeResult> ChangeOperationModeAsync(
        EqChgModeRequest request, CancellationToken ct = default)
        => await SendChgModeAsync(MsgIds.EqChgMode, request, ct);

    // ──────── 運用モード強制変更 ──────────────────────────────────

    /// <summary>
    /// 運用モード強制変更要求を送信する。
    /// VBソース: pubblnEqEmgChgMode_Upd, MsgVer="04.00"
    /// </summary>
    public async Task<EqChgModeResult> ForceChangeOperationModeAsync(
        EqChgModeRequest request, CancellationToken ct = default)
        => await SendChgModeAsync(MsgIds.EqEmgChgMode, request, ct);

    private async Task<EqChgModeResult> SendChgModeAsync(
        string subject, EqChgModeRequest request, CancellationToken ct)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,      request.MsgVer);
        req.AddString(Tags.WpId,        request.WpId);
        req.AddString(Tags.MesModeId,   request.MesModeId);
        req.AddString(Tags.EmpId,       request.EmpId);
        req.AddString(Tags.Comments,    request.Comments);
        req.AddString(Tags.UseId,       request.UseId);
        req.AddString(Tags.OldUseId,    request.OldUseId);
        req.AddString(Tags.WpStopFlag,  request.WpStopFlag);
        req.AddString(Tags.MessageId,   request.MessageId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(subject, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "ChgMode request failed. Subject={Subject}, WpId={WpId}",
                subject, request.WpId);
            return new EqChgModeResult(false, ErrorMessage: ex.Message);
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = msg.GetErrorInfo();
            logger.LogWarning("ChgMode returned non-TRUE. Subject={Subject}, WpId={WpId}, Err={Err}",
                subject, request.WpId, message);
            return new EqChgModeResult(false, ErrorCode: code, ErrorMessage: message);
        }

        return new EqChgModeResult(
            IsSuccess:      true,
            GuidanceMsg:    msg.GetString(Tags.Msg),
            GuidanceMsgCode: msg.GetString(Tags.MsgCode),
            EntryTime:      msg.GetString(Tags.EntryTime)
        );
    }

    // ──────── 搬送ポート有効・無効変更 ──────────────────────────

    /// <summary>
    /// 搬送ポートの有効・無効状態を変更する。
    /// VBソース: pubblnChgtrnstat_Upd, MsgVer="01.00"
    /// </summary>
    public async Task<bool> ChangeTransportStatusAsync(
        ChangeTrnStatRequest request, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,   request.MsgVer);
        req.AddString(Tags.WpId,     request.WpId);
        req.AddString(Tags.EmpId,    request.EmpId);
        req.AddString(Tags.Comments, request.Comments);

        var portAry = new TfMsgAry();
        foreach (var port in request.PortList)
        {
            var portMsg = new TfMsg();
            portMsg.AddString(Tags.PortId,              port.PortId);
            portMsg.AddString(Tags.TransServiceStatus,  port.TransServiceStatus);
            portAry.Add(portMsg);
        }
        req.AddMsgAry(Tags.PortList, portAry);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.EqChgTrnStat, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "EqChgTrnStat request failed. WpId={WpId}", request.WpId);
            return false;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("EqChgTrnStat returned non-TRUE. WpId={WpId}, Raw={Raw}",
                request.WpId, Summarize(raw));
            return false;
        }

        return true;
    }

    // ──────── 装置処理順変更 ─────────────────────────────────────

    /// <summary>
    /// 装置処理順を変更する。
    /// VBソース: pubblnEqChgProcOrder_Upd, MsgVer="03.00"
    /// </summary>
    public async Task<EqChgModeResult> ChangeProcOrderAsync(
        ChangeProcOrderRequest request, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,          request.MsgVer);
        req.AddString(Tags.WpId,            request.WpId);
        req.AddString(Tags.RecipeFlowNum,   request.RecipeFlowNum);
        req.AddString(Tags.Comments,        request.Comments);
        req.AddString(Tags.EmpId,           request.EmpId);
        req.AddString(Tags.CollectTypeFlag, request.CollectTypeFlag);

        var listAry = new TfMsgAry();
        foreach (var num in request.CollectTypeNums)
        {
            var item = new TfMsg();
            item.AddString(Tags.CollectTypeNum, num);
            listAry.Add(item);
        }
        req.AddMsgAry(Tags.CollectTypeList, listAry);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.EqChgProcOrder, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "EqChgProcOrder request failed. WpId={WpId}", request.WpId);
            return new EqChgModeResult(false, ErrorMessage: ex.Message);
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = msg.GetErrorInfo();
            logger.LogWarning("EqChgProcOrder returned non-TRUE. WpId={WpId}, Err={Err}",
                request.WpId, message);
            return new EqChgModeResult(false, ErrorCode: code, ErrorMessage: message);
        }

        return new EqChgModeResult(
            IsSuccess:       true,
            GuidanceMsg:     msg.GetString(Tags.Msg),
            GuidanceMsgCode: msg.GetString(Tags.MsgCode)
        );
    }

    // ──────── キャリア強制搬出 ───────────────────────────────────

    /// <summary>
    /// キャリア強制搬出を要求する。
    /// VBソース: pubblnEqCarUnload_Upd, MsgVer="01.00"
    /// </summary>
    public async Task<bool> CarrierUnloadAsync(
        string wpId,
        string portId,
        string carrierId,
        string empId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,    "01.00");
        req.AddString(Tags.SbId,      _defaultSbId);
        req.AddString(Tags.WpId,      wpId);
        req.AddString(Tags.PortId,    portId);
        req.AddString(Tags.CarrierId, carrierId);
        req.AddString(Tags.EmpId,     empId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.EqCarUnload, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "EqCarUnload request failed. WpId={WpId}, CarrierId={CarrierId}",
                wpId, carrierId);
            return false;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("EqCarUnload returned non-TRUE. WpId={WpId}, Raw={Raw}",
                wpId, Summarize(raw));
            return false;
        }

        return true;
    }

    // ──────── 装置状態マスタ取得 ─────────────────────────────────

    /// <summary>
    /// 装置状態マスタを取得する。
    /// VBソース: pubblnMasWpUseList_Sel, MsgVer="03.00"
    /// </summary>
    public async Task<IReadOnlyList<WpUseItem>> GetWpUseListAsync(CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer, "03.00");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.MasWpUseList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "MasWpUseList request failed");
            return [];
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("MasWpUseList returned non-TRUE. Raw={Raw}", Summarize(raw));
            return [];
        }

        var ary = msg.GetMsgAry(Tags.UseList);
        return ary.Select(item => new WpUseItem(
            UseId:           item.GetString(Tags.UseId),
            UseName:         item.GetString(Tags.UseName),
            UseEnableMode:   item.GetString(Tags.UseEnableMode),
            UseStopFlag:     item.GetString(Tags.UseStopFlag),
            MessageId:       item.GetString(Tags.MessageId),
            MessageText:     item.GetString(Tags.MessageText),
            NormalStateFlag: item.GetString(Tags.NormalStateFlag)
        )).ToList();
    }

    // ──────── 装置状態変更 ───────────────────────────────────────

    /// <summary>
    /// 装置状態を変更する。
    /// VBソース: pubblnEqChguse_Ins, MsgVer="05.00"
    /// </summary>
    public async Task<(bool IsSuccess, string EntryTime, string ErrorMessage)> ChangeWpUseAsync(
        ChangeWpUseRequest request, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.WpId,        request.WpId);
        req.AddString(Tags.UseId,       request.UseId);
        req.AddString(Tags.EmpId,       request.EmpId);
        req.AddString(Tags.Comments,    request.Comments);
        req.AddString(Tags.MsgVer,      request.MsgVer);
        req.AddString(Tags.WpStopFlag,  request.WpStopFlag);
        req.AddString(Tags.OldUseId,    request.OldUseId);
        req.AddString(Tags.MessageId,   request.MessageId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.EqChgUse, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "EqChgUse request failed. WpId={WpId}", request.WpId);
            return (false, string.Empty, ex.Message);
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var err = msg.GetString(Tags.ErrMsg);
            logger.LogWarning("EqChgUse returned non-TRUE. WpId={WpId}, Err={Err}",
                request.WpId, err);
            return (false, string.Empty, err);
        }

        return (true, msg.GetString(Tags.EntryTime), string.Empty);
    }

    // ──────── 装置状態メッセージ取得 ─────────────────────────────

    /// <summary>
    /// 装置状態メッセージリストを取得する。
    /// VBソース: pubblnEqWpMsgList_Sel, MsgVer="01.00"
    /// </summary>
    public async Task<IReadOnlyList<WpMessageItem>> GetWpMsgListAsync(
        string wpId, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer, "01.00");
        req.AddString(Tags.WpId,   wpId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.EqWpMsgList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "EqWpMsgList request failed. WpId={WpId}", wpId);
            return [];
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("EqWpMsgList returned non-TRUE. WpId={WpId}, Raw={Raw}",
                wpId, Summarize(raw));
            return [];
        }

        var ary = msg.GetMsgAry(Tags.MsgList);
        return ary.Select(item => new WpMessageItem(
            MessageId:   item.GetString(Tags.MessageId),
            MessageText: item.GetString(Tags.MessageText)
        )).ToList();
    }

    // ──────── 装置処理部用途取得 ─────────────────────────────────

    /// <summary>
    /// 装置処理部用途マスタを取得する。
    /// VBソース: pubblnMasWpProcessingList_Sel, MsgVer="01.00"
    /// </summary>
    public async Task<IReadOnlyList<ProcessingNameItem>> GetWpProcessingNameListAsync(
        string wpId, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer, "01.00");
        req.AddString(Tags.SbId,   _defaultSbId);
        req.AddString(Tags.WpId,   wpId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.MasWpProcessingNameList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "MasWpProcessingNameList request failed. WpId={WpId}", wpId);
            return [];
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("MasWpProcessingNameList returned non-TRUE. WpId={WpId}, Raw={Raw}",
                wpId, Summarize(raw));
            return [];
        }

        var ary = msg.GetMsgAry(Tags.ProcessingList);
        return ary.Select(item => new ProcessingNameItem(
            ChamberId:      item.GetString(Tags.ChamberId),
            ProcessingName: item.GetString(Tags.ProcessingName),
            DispOnFlag:     item.GetString(Tags.DispOnFlag)
        )).ToList();
    }

    // ──────── 装置処理部状態取得 ─────────────────────────────────

    /// <summary>
    /// 装置処理部状態マスタを取得する。
    /// VBソース: pubblnMasChamberUseList_Sel, MsgVer="01.00"
    /// </summary>
    public async Task<IReadOnlyList<ChamberUseItem>> GetChamberUseListAsync(CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer, "01.00");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.MasChamberUseList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "MasChamberUseList request failed");
            return [];
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("MasChamberUseList returned non-TRUE. Raw={Raw}", Summarize(raw));
            return [];
        }

        var ary = msg.GetMsgAry(Tags.ChamberUseList);
        return ary.Select(item => new ChamberUseItem(
            UseId:   item.GetString(Tags.UseId),
            UseName: item.GetString(Tags.UseName)
        )).ToList();
    }

    // ──────── 装置処理部用途リスト取得 ───────────────────────────

    /// <summary>
    /// 装置の処理部用途リストを取得する。
    /// VBソース: pubblnEqWpProcessingUse_Sel, MsgVer="01.00"
    /// </summary>
    public async Task<IReadOnlyList<ProcessingUseItem>> GetWpProcessingUseListAsync(
        string wpId, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer, "01.00");
        req.AddString(Tags.WpId,   wpId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.EqWpProcessingUse, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "EqWpProcessingUse request failed. WpId={WpId}", wpId);
            return [];
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("EqWpProcessingUse returned non-TRUE. WpId={WpId}, Raw={Raw}",
                wpId, Summarize(raw));
            return [];
        }

        var ary = msg.GetMsgAry(Tags.ProcessingUseList);
        return ary.Select(item => new ProcessingUseItem(
            No:              item.GetString(Tags.No),
            ChamberId:       item.GetString(Tags.ChamberId),
            ChamberUseId:    item.GetString(Tags.ChamberUseId),
            OldChamberId:    item.GetString(Tags.OldChamberId),
            OldChamberUseId: item.GetString(Tags.OldChamberUseId),
            EditTime:        item.GetString(Tags.EditTime)
        )).ToList();
    }

    // ──────── 装置処理部用途変更 ─────────────────────────────────

    /// <summary>
    /// 装置処理部用途を変更する。
    /// VBソース: pubblnChgWpProcessingUse_Upd, MsgVer="01.00"
    /// </summary>
    public async Task<bool> ChangeWpProcessingUseAsync(
        ChangeWpProcessingUseRequest request, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,   request.MsgVer);
        req.AddString(Tags.SbId,     _defaultSbId);
        req.AddString(Tags.WpId,     request.WpId);
        req.AddString(Tags.EmpId,    request.EmpId);
        req.AddString(Tags.Comments, request.Comments);

        var listAry = new TfMsgAry();
        foreach (var item in request.ProcessingUseList)
        {
            var row = new TfMsg();
            row.AddString(Tags.No,              item.No);
            row.AddString(Tags.ChamberId,       item.ChamberId);
            row.AddString(Tags.ChamberUseId,    item.ChamberUseId);
            row.AddString(Tags.OldChamberId,    item.OldChamberId);
            row.AddString(Tags.OldChamberUseId, item.OldChamberUseId);
            row.AddString(Tags.EditTime,        item.EditTime);
            listAry.Add(row);
        }
        req.AddMsgAry(Tags.ProcessingUseList, listAry);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.EqChgWpProcessingUse, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "EqChgWpProcessingUse request failed. WpId={WpId}", request.WpId);
            return false;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("EqChgWpProcessingUse returned non-TRUE. WpId={WpId}, Raw={Raw}",
                request.WpId, Summarize(raw));
            return false;
        }

        return true;
    }

    // ──────── 内部ヘルパー ────────────────────────────────────────
    private static string Summarize(string? raw) =>
        (raw ?? string.Empty) is { Length: > 200 } s ? s[..200] + "..." : raw ?? string.Empty;
}
