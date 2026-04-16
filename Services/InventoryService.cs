namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// 在庫管理サービス。
/// ・組立在庫分割予約     (lot_.asmdivide)
/// ・保留在庫ロットリスト (lot_.holdlist)
/// ・送品伝票情報取得     (inv_.getsendorderlist)
/// ・ロット検定表情報取得 (inv_.getlotexaminfo)
/// ・次SB連絡コメント登録 (inv_.chgcomm_)
/// ・CF在庫払出処理       (inv_.cfforward)
/// ・CFロット情報取得     (inv_.cflotinfo)
/// ・CF在庫リワーク登録   (inv_.cfrework)
/// ・ロット送品取消       (lot_.cancelsend)
/// ・ロット送品           (lot_.send____)
/// VBソース: CtsbasxxMG00F0.vb
/// </summary>
public sealed class InventoryService(ITfMessageClient mq, IConfiguration cfg, ILogger<InventoryService> logger)
{
    private readonly string _defaultSbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 公開型 ────────────────────────────────────────────

    /// <summary>WFマップの1要素（分割先スロット）</summary>
    public sealed record WfMapItem(string SlotPosition, string WfId);

    /// <summary>保留在庫ロットリストの1要素。VBソース: InvAcptLot 構造体</summary>
    public sealed record HoldLotItem(
        string CarrierId,
        string LotId,
        string FlowClass,
        string PdId,
        string WfQuantity,
        string ChipQuantity,
        string StayTime,
        string LotHoldFlag,
        string RecordTime,
        string EmpId,
        string EmpName,
        string ReasonCode,
        string ReasonName,
        string Comments,
        string EditTime,
        string LotPriority,
        string OpId,
        string StepId,
        string WpId,
        string HoldStayDate,
        string HoldEmpId,
        string HoldEmpName,
        string WpName,
        string HoldTermDate,
        string EntryId,
        string EngEmpId,
        string EngEmpName,
        string NowSt,
        string LcDirection,
        string SlotSize,
        string SendSbId,
        string SbArea
    );

    /// <summary>送品伝票情報の1ロット要素。VBソース: GetSendOrderListLotList 構造体</summary>
    public sealed record SendOrderItem(
        string SbName,
        string AtlasPoint,
        string SendSbName,
        string SendAtlasPoint,
        string EmpName,
        string SendDate,
        string LotId,
        string BoxNo,
        string FlowClass,
        string WfQuantity,
        string ChipQuantity,
        string PdId,
        string ExtPartCode,
        string AtlasOrderNo,
        string InvComments,
        string SbArea
    );

    /// <summary>ロット検定表のWF要素</summary>
    public sealed record ExamWfItem(string WfId, string ChipQuantity);

    /// <summary>ロット検定表情報取得の結果。VBソース: GetLotExamInfo 構造体</summary>
    public sealed record LotExamInfoResult(
        string LotId,
        string BoxNo,
        string FlowClass,
        string WfQuantity,
        string ChipQuantity,
        string PdId,
        string AtlasOrderNo,
        string SendDate,
        string SendSbName,
        string WfThrowinDate,
        string WfThrowinQuantity,
        string WfFinishDate,
        string WfFinishQuantity,
        string WfOutQuantity,
        string WfIssueQuantity,
        string ChipThrowinQuantity,
        string ChipOutQuantity,
        string GoodChipRatio,
        string InvComments,
        string ExtPartCode,
        IReadOnlyList<ExamWfItem> WfList
    );

    /// <summary>板厚リストの1要素</summary>
    public sealed record ThicknessItem(string ThicknessCode);

    /// <summary>CFロット情報取得の結果。VBソース: InvCFLotInfoList 構造体</summary>
    public sealed record CfLotInfoResult(
        string ReworkCount,
        string RegenerationCount,
        IReadOnlyList<ThicknessItem> ThicknessList
    );

    /// <summary>CFリワーク登録の板厚+チップ数要素</summary>
    public sealed record CfReworkThicknessItem(string ThicknessCode, string ChipNum);

    // ──────── 組立在庫分割予約 ───────────────────────────────────

    /// <summary>
    /// 組立在庫分割予約を登録する。
    /// VBソース: pubblnLotAsmdivide_Ins, MsgVer="04.00"
    /// </summary>
    /// <returns>(DivideLotId1, DivideLotId2)、失敗時null</returns>
    public async Task<(string LotId1, string LotId2)?> AsmDivideAsync(
        string lotId,
        string empId,
        string lotLastUpdate,
        IEnumerable<WfMapItem> wfMap1,
        IEnumerable<WfMapItem> wfMap2,
        string toCarrierId1 = "",
        string toCarrierId2 = "",
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,         lotId);

        var ary1 = new TfMsgAry();
        foreach (var w in wfMap1)
        {
            var e = new TfMsg();
            e.AddString(Tags.SlotPosition, w.SlotPosition);
            e.AddString(Tags.WfId,         w.WfId);
            ary1.Add(e);
        }
        req.AddMsgAry(Tags.DivideWfMapList, ary1);

        var ary2 = new TfMsgAry();
        foreach (var w in wfMap2)
        {
            var e = new TfMsg();
            e.AddString(Tags.SlotPosition, w.SlotPosition);
            e.AddString(Tags.WfId,         w.WfId);
            ary2.Add(e);
        }
        req.AddMsgAry(Tags.DivideWfMapList2, ary2);

        req.AddString(Tags.EmpId,          empId);
        req.AddString(Tags.LotLastUpdate,  lotLastUpdate);
        req.AddString(Tags.SbId,           _defaultSbId);
        req.AddString(Tags.MsgVer,         "04.00");
        req.AddString(Tags.ToCarrierId1,   toCarrierId1);
        req.AddString(Tags.ToCarrierId2,   toCarrierId2);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotAsmDivide, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotAsmDivide request failed. LotId={LotId}", lotId);
            return null;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("LotAsmDivide returned non-TRUE. LotId={LotId}, Raw={Raw}",
                lotId, Summarize(raw));
            return null;
        }

        return (msg.GetString(Tags.DivideLotId1), msg.GetString(Tags.DivideLotId2));
    }

    // ──────── 保留在庫ロットリスト ───────────────────────────────

    /// <summary>
    /// 保留在庫ロットリストを取得する。
    /// VBソース: pubblnLotHoldList_Sel, MsgVer="04.01"
    /// </summary>
    public async Task<IReadOnlyList<HoldLotItem>?> GetHoldListAsync(
        string classDivision,
        IEnumerable<string> flowClasses,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.ClassDivision, classDivision);

        var fcAry = new TfMsgAry();
        foreach (var fc in flowClasses)
        {
            var e = new TfMsg();
            e.AddString(Tags.FlowClassId, fc);
            fcAry.Add(e);
        }
        req.AddMsgAry(Tags.FlowClassList, fcAry);
        req.AddString(Tags.SbId,   _defaultSbId);
        req.AddString(Tags.MsgVer, "04.01");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotHoldList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotHoldList request failed.");
            return null;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("LotHoldList returned non-TRUE. Raw={Raw}", Summarize(raw));
            return null;
        }

        return msg.GetMsgAry(Tags.LotList)
            .Select(e => new HoldLotItem(
                CarrierId:    e.GetString(Tags.CarrierId),
                LotId:        e.GetString(Tags.LotId),
                FlowClass:    e.GetString(Tags.FlowClass),
                PdId:         e.GetString(Tags.PdId),
                WfQuantity:   e.GetString(Tags.WfQuantity),
                ChipQuantity: e.GetString(Tags.ChipQuantity),
                StayTime:     e.GetString(Tags.StayTime),
                LotHoldFlag:  e.GetString(Tags.LotHoldFlag),
                RecordTime:   e.GetString(Tags.RecordTime),
                EmpId:        e.GetString(Tags.EmpId),
                EmpName:      e.GetString(Tags.EmpName),
                ReasonCode:   e.GetString(Tags.ReasonCode),
                ReasonName:   e.GetString(Tags.ReasonName),
                Comments:     e.GetString(Tags.Comments),
                EditTime:     e.GetString(Tags.EntryTime),
                LotPriority:  e.GetString(Tags.LotPriority),
                OpId:         e.GetString(Tags.OpId),
                StepId:       e.GetString(Tags.StepId),
                WpId:         e.GetString(Tags.WpId),
                HoldStayDate: e.GetString(Tags.HoldStayDate),
                HoldEmpId:    e.GetString(Tags.HoldEmpId),
                HoldEmpName:  e.GetString(Tags.HoldEmpName),
                WpName:       e.GetString(Tags.WpName),
                HoldTermDate: e.GetString(Tags.HoldTermDate),
                EntryId:      e.GetString(Tags.EntryId),
                EngEmpId:     e.GetString(Tags.EngEmpId),
                EngEmpName:   e.GetString(Tags.EngEmpName),
                NowSt:        e.GetString(Tags.NowSt),
                LcDirection:  e.GetString(Tags.LcDirection),
                SlotSize:     e.GetString(Tags.SlotSize),
                SendSbId:     e.GetString(Tags.SendSbId),
                SbArea:       e.GetString(Tags.SbArea)))
            .ToList();
    }

    // ──────── 送品伝票情報取得 ───────────────────────────────────

    /// <summary>
    /// 送品伝票情報を取得する。
    /// VBソース: pubblnInvGetSendOrderList_Sel, MsgVer="03.01"
    /// </summary>
    public async Task<IReadOnlyList<SendOrderItem>?> GetSendOrderListAsync(
        IEnumerable<string> lotIds,
        CancellationToken ct = default)
    {
        var req = new TfMsg();

        var lotAry = new TfMsgAry();
        foreach (var id in lotIds)
        {
            var e = new TfMsg();
            e.AddString(Tags.LotId, id);
            lotAry.Add(e);
        }
        req.AddMsgAry(Tags.LotList, lotAry);
        req.AddString(Tags.SbId,   _defaultSbId);
        req.AddString(Tags.MsgVer, "03.01");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.InvGetSendOrderList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "InvGetSendOrderList request failed.");
            return null;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("InvGetSendOrderList returned non-TRUE. Raw={Raw}", Summarize(raw));
            return null;
        }

        return msg.GetMsgAry(Tags.LotList)
            .Select(e => new SendOrderItem(
                SbName:           e.GetString(Tags.SbName),
                AtlasPoint:       e.GetString(Tags.AtlasPoint),
                SendSbName:       e.GetString(Tags.SendSbName),
                SendAtlasPoint:   e.GetString(Tags.SendAtlasPoint),
                EmpName:          e.GetString(Tags.EmpName),
                SendDate:         e.GetString(Tags.SendDate),
                LotId:            e.GetString(Tags.LotId),
                BoxNo:            e.GetString(Tags.BoxNo),
                FlowClass:        e.GetString(Tags.FlowClass),
                WfQuantity:       e.GetString(Tags.WfQuantity),
                ChipQuantity:     e.GetString(Tags.ChipQuantity),
                PdId:             e.GetString(Tags.PdId),
                ExtPartCode:      e.GetString(Tags.ExtPartCode),
                AtlasOrderNo:     e.GetString(Tags.AtlasOrderNo),
                InvComments:      e.GetString(Tags.InvComments),
                SbArea:           e.GetString(Tags.SbArea)))
            .ToList();
    }

    // ──────── ロット検定表情報取得 ───────────────────────────────

    /// <summary>
    /// ロット検定表情報を取得する。
    /// VBソース: pubblnInvGetLotExamInfo_Sel, MsgVer="03.00"
    /// </summary>
    public async Task<LotExamInfoResult?> GetLotExamInfoAsync(
        string lotId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,  lotId);
        req.AddString(Tags.SbId,   _defaultSbId);
        req.AddString(Tags.MsgVer, "03.00");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.InvGetLotExamInfo, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "InvGetLotExamInfo request failed. LotId={LotId}", lotId);
            return null;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("InvGetLotExamInfo returned non-TRUE. LotId={LotId}, Raw={Raw}",
                lotId, Summarize(raw));
            return null;
        }

        var wfList = msg.GetMsgAry(Tags.WfList)
            .Select(e => new ExamWfItem(
                WfId:         e.GetString(Tags.WfId),
                ChipQuantity: e.GetString(Tags.ChipQuantity)))
            .ToList();

        return new LotExamInfoResult(
            LotId:               lotId,
            BoxNo:               msg.GetString(Tags.BoxNo),
            FlowClass:           msg.GetString(Tags.FlowClass),
            WfQuantity:          msg.GetString(Tags.WfQuantity),
            ChipQuantity:        msg.GetString(Tags.ChipQuantity),
            PdId:                msg.GetString(Tags.PdId),
            AtlasOrderNo:        msg.GetString(Tags.AtlasOrderNo),
            SendDate:            msg.GetString(Tags.SendDate),
            SendSbName:          msg.GetString(Tags.SendSbName),
            WfThrowinDate:       msg.GetString(Tags.WfThrowinDate),
            WfThrowinQuantity:   msg.GetString(Tags.WfThrowinQuantity),
            WfFinishDate:        msg.GetString(Tags.WfFinishDate),
            WfFinishQuantity:    msg.GetString(Tags.WfFinishQuantity),
            WfOutQuantity:       msg.GetString(Tags.WfOutQuantity),
            WfIssueQuantity:     msg.GetString(Tags.WfIssueQuantity),
            ChipThrowinQuantity: msg.GetString(Tags.ChipThrowinQuantity),
            ChipOutQuantity:     msg.GetString(Tags.ChipOutQuantity),
            GoodChipRatio:       msg.GetString(Tags.GoodChipRatio),
            InvComments:         msg.GetString(Tags.InvComments),
            ExtPartCode:         msg.GetString(Tags.ExtPartCode),
            WfList:              wfList);
    }

    // ──────── 次SB連絡コメント登録 ───────────────────────────────

    /// <summary>
    /// 次SB連絡コメントを登録する。
    /// VBソース: pubblnInvChgComm_Upd, MsgVer="01.00"
    /// </summary>
    /// <returns>更新後のLotLastUpdate、失敗時null</returns>
    public async Task<string?> ChgCommAsync(
        string lotId,
        string empId,
        string invComments,
        string lotLastUpdate,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,        lotId);
        req.AddString(Tags.EmpId,        empId);
        req.AddString(Tags.InvComments,  invComments);
        req.AddString(Tags.LotLastUpdate, lotLastUpdate);
        req.AddString(Tags.SbId,         _defaultSbId);
        req.AddString(Tags.MsgVer,       "01.00");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.InvChgComm, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "InvChgComm request failed. LotId={LotId}", lotId);
            return null;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("InvChgComm returned non-TRUE. LotId={LotId}, Raw={Raw}",
                lotId, Summarize(raw));
            return null;
        }

        return msg.GetString(Tags.LotLastUpdate);
    }

    // ──────── CF在庫払出処理 ─────────────────────────────────────

    /// <summary>
    /// CF在庫払出を処理する。
    /// VBソース: pubblnInvCFForward_Upd, MsgVer は構造体の strMsgVer (通常"02.00")
    /// </summary>
    public async Task<bool> CfForwardAsync(
        string lotId,
        string empId,
        string eventClass,
        string reasonCode,
        string reasonName,
        string chipNum,
        string msgVer = "02.00",
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,      lotId);
        req.AddString(Tags.EmpId,      empId);
        req.AddString(Tags.EventClass, eventClass);
        req.AddString(Tags.ReasonCode, reasonCode);
        req.AddString(Tags.ReasonName, reasonName);
        req.AddString(Tags.ChipNum,    chipNum);
        req.AddString(Tags.SbId,       _defaultSbId);
        req.AddString(Tags.MsgVer,     msgVer);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.InvCfForward, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "InvCfForward request failed. LotId={LotId}", lotId);
            return false;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("InvCfForward returned non-TRUE. LotId={LotId}, Raw={Raw}",
                lotId, Summarize(raw));
            return false;
        }

        return true;
    }

    // ──────── CFロット情報取得 ───────────────────────────────────

    /// <summary>
    /// CFロット情報を取得する。
    /// VBソース: pubblnInvCFLotInfo_Sel, MsgVer="01.00"
    /// </summary>
    public async Task<CfLotInfoResult?> GetCfLotInfoAsync(
        string carrierId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.CarrierId, carrierId);
        req.AddString(Tags.SbId,      _defaultSbId);
        req.AddString(Tags.MsgVer,    "01.00");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.InvCfLotInfo, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "InvCfLotInfo request failed. CarrierId={CarrierId}", carrierId);
            return null;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("InvCfLotInfo returned non-TRUE. CarrierId={CarrierId}, Raw={Raw}",
                carrierId, Summarize(raw));
            return null;
        }

        var thickList = msg.GetMsgAry(Tags.ThicknessList)
            .Select(e => new ThicknessItem(e.GetString(Tags.ThicknessCode)))
            .ToList();

        return new CfLotInfoResult(
            ReworkCount:       msg.GetString(Tags.ReworkCount),
            RegenerationCount: msg.GetString(Tags.RegenerationCount),
            ThicknessList:     thickList);
    }

    // ──────── CF在庫リワーク登録 ─────────────────────────────────

    /// <summary>
    /// CF在庫リワークを登録する。
    /// VBソース: pubblnInvCFRework_Upd, MsgVer="01.00"
    /// </summary>
    public async Task<bool> CfReworkAsync(
        string lotId,
        string empId,
        IEnumerable<CfReworkThicknessItem> thicknessList,
        string msgVer = "01.00",
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,  lotId);
        req.AddString(Tags.EmpId,  empId);
        req.AddString(Tags.SbId,   _defaultSbId);
        req.AddString(Tags.MsgVer, msgVer);

        var thkAry = new TfMsgAry();
        foreach (var t in thicknessList)
        {
            var e = new TfMsg();
            e.AddString(Tags.ThicknessCode, t.ThicknessCode);
            e.AddString(Tags.ChipNum,       t.ChipNum);
            thkAry.Add(e);
        }
        req.AddMsgAry(Tags.ThicknessList, thkAry);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.InvCfRework, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "InvCfRework request failed. LotId={LotId}", lotId);
            return false;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("InvCfRework returned non-TRUE. LotId={LotId}, Raw={Raw}",
                lotId, Summarize(raw));
            return false;
        }

        return true;
    }

    // ──────── ロット送品取消 ─────────────────────────────────────

    /// <summary>
    /// ロット送品を取消する。
    /// VBソース: pubblnlotCancelSend_Upd, MsgVer="02.00"
    /// </summary>
    public async Task<bool> CancelSendAsync(
        string lotId,
        string empId,
        string lotLastUpdate,
        string carrierId = "",
        string msgVer = "02.00",
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,         lotId);
        req.AddString(Tags.LotLastUpdate,  lotLastUpdate);
        req.AddString(Tags.SbId,           _defaultSbId);
        req.AddString(Tags.EmpId,          empId);
        req.AddString(Tags.MsgVer,         msgVer);
        req.AddString(Tags.CarrierId,      carrierId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotCancelSend, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotCancelSend request failed. LotId={LotId}", lotId);
            return false;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("LotCancelSend returned non-TRUE. LotId={LotId}, Raw={Raw}",
                lotId, Summarize(raw));
            return false;
        }

        return true;
    }

    // ──────── ロット送品 ─────────────────────────────────────────

    /// <summary>
    /// ロット送品を実行する。
    /// VBソース: pubblnlotSend_Upd, MsgVer="02.00"
    /// </summary>
    public async Task<bool> SendAsync(
        string lotId,
        string sendSbId,
        string boxNo,
        string empId,
        string lotLastUpdate,
        string msgVer = "02.00",
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,        lotId);
        req.AddString(Tags.SendSbId,     sendSbId);
        req.AddString(Tags.BoxNo,        boxNo);
        req.AddString(Tags.LotLastUpdate, lotLastUpdate);
        req.AddString(Tags.SbId,         _defaultSbId);
        req.AddString(Tags.EmpId,        empId);
        req.AddString(Tags.MsgVer,       msgVer);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotSend, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotSend request failed. LotId={LotId}", lotId);
            return false;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("LotSend returned non-TRUE. LotId={LotId}, Raw={Raw}",
                lotId, Summarize(raw));
            return false;
        }

        return true;
    }

    // ──────── 内部ヘルパー ────────────────────────────────────────
    private static string Summarize(string? raw) =>
        (raw ?? string.Empty) is { Length: > 200 } s ? s[..200] + "..." : raw ?? string.Empty;
}
