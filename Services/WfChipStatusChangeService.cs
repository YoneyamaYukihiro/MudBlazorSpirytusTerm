namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN0180 WF状態変更登録 / EN0190 チップ状態変更登録 の共用サービス。
/// VBソース: VB/COMN/CtsfrmxxCM0070.vb (EN0180), VB/COMN/CtsfrmxxCM0080.vb (EN0190)
///           VB/COMN/CtsbasxxCM0050.vb (pubblnLotWaferList_Sel, pubblnLotInsprst_Ins, pubblnMasScpList_Sel)
///           VB/COMN/CtsbasxxMG0180.vb (wf__.directscrap)
/// </summary>
public sealed class WfChipStatusChangeService(ITfMessageClient mq, IConfiguration cfg, ILogger<WfChipStatusChangeService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── メッセージIDバージョン ────────────────────────────────────
    // VBソース: CMstrlot_curstateVer = "04.00"
    private const string LotCurStateVer   = "04.00";
    // VBソース: CMstrlot_waferlistVer = "02.05"
    private const string LotWaferListVer  = "02.05";
    // VBソース: CMstrlot_insprst_Ver = "02.01"
    private const string LotInsprstVer    = "02.01";
    // VBソース: CMstrmas_scplist_Ver = "03.00"
    private const string MasScpListVer    = "03.00";

    // ──────── CLASS_DIVISION 定数 ────────────────────────────────────────
    // VBソース: CPstrCD17 = "17" (ロット現在状態取得: WF不良/保留/払出)
    private const string ClassDivisionWf   = "17";
    // VBソース: CPstrCD1T = "1T" (ロット現在状態取得: チップ処置登録)
    private const string ClassDivisionChip = "1T";
    // VBソース: CPstrCD0T = "0T" (有効ウェハ)
    private const string ClassDivision0T   = "0T";

    // ──────── CLASS 区分値 ────────────────────────────────────────────────
    // VBソース: CLASS 1=良品, 2=不良, 3=払出し, 4=保留
    public const string ClassGood    = "1"; // 良品
    public const string ClassBad     = "2"; // 不良
    public const string ClassForward = "3"; // 払出し
    public const string ClassHold    = "4"; // 保留

    // ──────── 公開型 ────────────────────────────────────────────────────

    /// <summary>WFリストの1エントリ（lot_.waferlist 応答の WF_LIST 要素）</summary>
    public sealed record WfEntry(
        string WfId,
        string SlotPosition,
        string GrbClass,
        string Class,           // 1=良品, 2=不良, 3=払出し, 4=保留
        string ClassId,
        string WfStatusName,
        string Result
    );

    /// <summary>不良/払出コードの1エントリ（mas_.scplist_ 応答の SCRAP_LIST 要素）</summary>
    public sealed record ScrapItem(string ItemId, string ItemName, string SeqNum);

    /// <summary>チップの1エントリ（lot_.insprst_ 送信用）</summary>
    public sealed record ChipItem(string ChipId, string Class, string ClassId);

    /// <summary>
    /// WF状態変更登録用のWF入力データ。
    /// lot_.insprst_ 送信時の WF_LIST 要素。
    /// </summary>
    public sealed record WfInputEntry(
        string WfId,
        string SlotPosition,
        string Class,
        string ClassId,
        string ChipOutQuantity,
        string ChipForwardQuantity,
        IReadOnlyList<ChipItem> ChipList
    );

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
        string LotLastUpdate = "",
        string LotScrapSetId = ""
    );

    public sealed record WaferListResult(
        bool IsSuccess,
        string ErrorMessage = "",
        string LotId = "",
        string OpId = "",
        string StepId = "",
        string SbId = "",
        string SlotSize = "",
        string RelatedLotStatus = "",
        IReadOnlyList<WfEntry>? WfList = null
    );

    public sealed record ScpListResult(
        bool IsSuccess,
        string ErrorMessage = "",
        IReadOnlyList<ScrapItem>? Items = null
    );

    public sealed record InsprstResult(
        bool IsSuccess,
        string ErrorMessage = "",
        string Result = "",
        string LotLastUpdate = ""
    );

    // ──────── ロット現在状態取得 (lot_.curstate) ─────────────────────────

    /// <summary>
    /// キャリアIDからロット情報を取得する。
    /// lot_.curstate MSG_VER="04.00"
    /// VBソース: CMstrlot_curstateVer = "04.00"
    /// EN0180: CLASS_DIVISION="17", EN0190: CLASS_DIVISION="1T"
    /// </summary>
    public async Task<LotCurStateResult> GetLotInfoAsync(
        string carrierId,
        bool isChipMode,
        CancellationToken ct = default)
    {
        var classDivision = isChipMode ? ClassDivisionChip : ClassDivisionWf;

        var req = new TfMsg();
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.MsgVer,        LotCurStateVer);
        req.AddString(Tags.ClassDivision, classDivision);
        req.AddString(Tags.CarrierId,     carrierId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotCurState, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotCurState(EN0180/EN0190) failed. CarrierId={Id}", carrierId);
            return new LotCurStateResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var err = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            logger.LogWarning("LotCurState returned FALSE. Err={Err}", err);
            return new LotCurStateResult(false, string.IsNullOrEmpty(err) ? "ロット情報の取得に失敗しました。" : err);
        }

        return new LotCurStateResult(
            IsSuccess:    true,
            LotId:        aMsg.GetString(Tags.LotId),
            OpId:         aMsg.GetString(Tags.OpId),
            StepId:       aMsg.GetString(Tags.StepId),
            PdId:         aMsg.GetString(Tags.PdId),
            PdName:       aMsg.GetString(Tags.PdName),
            NowSt:        aMsg.GetString(Tags.NowSt),
            WfNum:        aMsg.GetString(Tags.WfNum),
            LotLastUpdate: aMsg.GetString(Tags.LotLastUpdate),
            LotScrapSetId: aMsg.GetString(Tags.LotScrapSetId)
        );
    }

    // ──────── ロットWF情報取得 (lot_.waferlist) ────────────────────────

    /// <summary>
    /// キャリアIDからWFリストを取得する。
    /// lot_.waferlist MSG_VER="02.05" CLASS_DIVISION="0T"
    /// VBソース: CMstrlot_waferlistVer = "02.05", CPstrCD0T = "0T"
    /// </summary>
    public async Task<WaferListResult> GetWaferListAsync(
        string carrierId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.MsgVer,        LotWaferListVer);
        req.AddString(Tags.ClassDivision, ClassDivision0T);
        req.AddString(Tags.CarrierId,     carrierId);
        req.AddString(Tags.LotId,         string.Empty);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotWaferList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotWaferList failed. CarrierId={Id}", carrierId);
            return new WaferListResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var err = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            logger.LogWarning("LotWaferList returned FALSE. Err={Err}", err);
            return new WaferListResult(false, string.IsNullOrEmpty(err) ? "WF情報の取得に失敗しました。" : err);
        }

        var wfList = aMsg.GetMsgAry(Tags.WfList)
            .Select(e => new WfEntry(
                WfId:         e.GetString(Tags.WfId),
                SlotPosition: e.GetString(Tags.SlotPosition),
                GrbClass:     e.GetString(Tags.GrbClass),
                Class:        e.GetString(Tags.Class),
                ClassId:      e.GetString(Tags.ClassId),
                WfStatusName: e.GetString(Tags.WfStatusName),
                Result:       e.GetString(Tags.Result)
            )).ToList();

        return new WaferListResult(
            IsSuccess:          true,
            LotId:              aMsg.GetString(Tags.LotId),
            OpId:               aMsg.GetString(Tags.OpId),
            StepId:             aMsg.GetString(Tags.StepId),
            SbId:               aMsg.GetString(Tags.SbId),
            SlotSize:           aMsg.GetString(Tags.SlotSize),
            RelatedLotStatus:   aMsg.GetString(Tags.RelatedLotStatus),
            WfList:             wfList
        );
    }

    // ──────── 不良項目入力項目取得 (mas_.scplist_) ────────────────────

    /// <summary>
    /// 不良/払出コードの一覧を取得する。
    /// mas_.scplist_ MSG_VER="03.00"
    /// VBソース: CMstrmas_scplist_Ver = "03.00"
    /// isChipMode=true の場合は CLASS_DIVISION="1T"（チップ用）、false は "17"（WF用）。
    /// </summary>
    public async Task<ScpListResult> GetScpListAsync(
        string lotScrapSetId,
        bool isChipMode,
        CancellationToken ct = default)
    {
        var classDivision = isChipMode ? ClassDivisionChip : ClassDivisionWf;

        var req = new TfMsg();
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.MsgVer,        MasScpListVer);
        req.AddString(Tags.ClassDivision, classDivision);
        req.AddString(Tags.LotScrapSetId, lotScrapSetId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.MasScpList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "MasScpList failed.", ex);
            return new ScpListResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var err = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            logger.LogWarning("MasScpList returned FALSE. Err={Err}", err);
            return new ScpListResult(false, string.IsNullOrEmpty(err) ? "不良項目一覧の取得に失敗しました。" : err);
        }

        var items = aMsg.GetMsgAry(Tags.ScrapList)
            .Select(e => new ScrapItem(
                ItemId:   e.GetString(Tags.ScrapItemId),
                ItemName: e.GetString(Tags.ScrapItemName),
                SeqNum:   e.GetString(Tags.SeqNum)
            )).ToList();

        return new ScpListResult(true, Items: items);
    }

    // ──────── 不良/保留/払出/傾向登録 (lot_.insprst_) ──────────────────

    /// <summary>
    /// WF/チップ状態変更を登録する。
    /// lot_.insprst_ MSG_VER="02.01"
    /// VBソース: CMstrlot_insprst_Ver = "02.01"
    /// isChipMode=true → CLASS_DIVISION="1T"（チップ処置）、false → "17"（WF処置）。
    /// </summary>
    public async Task<InsprstResult> ExecuteInsprstAsync(
        string lotId,
        bool isChipMode,
        IReadOnlyList<WfInputEntry> wfEntries,
        string empId,
        string lotLastUpdate,
        string responsibleEmpId,
        CancellationToken ct = default)
    {
        var classDivision = isChipMode ? ClassDivisionChip : ClassDivisionWf;

        var req = new TfMsg();
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.MsgVer,        LotInsprstVer);
        req.AddString(Tags.LotId,         lotId);
        req.AddString(Tags.ClassDivision, classDivision);

        // WF_LIST アレイ構築
        var wfAry = new TfMsgAry();
        foreach (var wf in wfEntries)
        {
            var wfMsg = new TfMsg();
            wfMsg.AddString(Tags.WfId,               wf.WfId);
            wfMsg.AddString(Tags.SlotPosition,        wf.SlotPosition);
            wfMsg.AddString(Tags.Class,               wf.Class);
            wfMsg.AddString(Tags.ClassId,             wf.ClassId);
            wfMsg.AddString(Tags.ChipOutQuantity,     wf.ChipOutQuantity);
            wfMsg.AddString(Tags.ChipForwardQuantity, wf.ChipForwardQuantity);
            wfMsg.AddString(Tags.Num,                 "0");

            // CHIP_LIST（良品WFのみチップ情報あり）
            var chipAry = new TfMsgAry();
            if (wf.Class == ClassGood && wf.ChipList.Count > 0)
            {
                foreach (var chip in wf.ChipList)
                {
                    var chipMsg = new TfMsg();
                    chipMsg.AddString(Tags.ChipId,  chip.ChipId);
                    chipMsg.AddString(Tags.Class,   chip.Class);
                    chipMsg.AddString(Tags.ClassId, chip.ClassId);
                    chipAry.Add(chipMsg);
                }
            }
            wfMsg.AddMsgAry(Tags.ChipList, chipAry);
            wfAry.Add(wfMsg);
        }
        req.AddMsgAry(Tags.WfList, wfAry);

        req.AddString(Tags.EmpId,            empId);
        req.AddString(Tags.LotLastUpdate,    lotLastUpdate);
        req.AddString(Tags.ResponsibleEmpId, responsibleEmpId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotInsprst, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotInsprst failed. LotId={Id}", lotId);
            return new InsprstResult(false, $"通信エラー: {ex.Message}");
        }

        var aMsg = ParseOrEmpty(raw);
        if (aMsg.GetString(Tags.Ret) != Tags.True)
        {
            var err = aMsg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = aMsg.GetString(Tags.Msg);
            logger.LogWarning("LotInsprst returned FALSE. Err={Err}", err);
            return new InsprstResult(false, string.IsNullOrEmpty(err) ? "状態変更登録に失敗しました。" : err);
        }

        return new InsprstResult(
            IsSuccess:     true,
            Result:        aMsg.GetString(Tags.Result),
            LotLastUpdate: aMsg.GetString(Tags.LotLastUpdate)
        );
    }

    // ──────── 内部ヘルパー ────────────────────────────────────────────

    private static TfMsg ParseOrEmpty(string? raw)
    {
        var text = (raw ?? string.Empty).Trim();
        if (text.StartsWith("(", StringComparison.Ordinal))
            try { return TfMsg.FromTfString(text); } catch { }
        var e = new TfMsg();
        e.AddString(Tags.Ret,    Tags.False);
        e.AddString(Tags.ErrMsg, text.Length > 0 ? text : "空の応答");
        return e;
    }
}
