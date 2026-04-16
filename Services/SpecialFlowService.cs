namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN00Y0 特殊流動(リワーク・追加・先行) のサービス。
/// ・キャリア現在状態取得    (carr.curstate)     VBソース: pubblnCarrcurstate_Sel  (CtsbasxxCM0050.vb)
/// ・特殊流動設定            (lot_.reworkset_)   VBソース: pubblnReworkSet_Ins     (CtsbasxxEN00Y0.vb)
/// </summary>
public sealed class SpecialFlowService(ITfMessageClient mq, IConfiguration cfg, ILogger<SpecialFlowService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    private const string MsgReworkSet    = "lot_.reworkset_";
    private const string VerCurrState    = "04.00";
    private const string VerReworkSet    = "02.00";
    private const string CdSpecialFlow   = "50";   // CLASS_DIVISION: 特殊流動

    // ──────── 公開型 ────────────────────────────────────────────

    /// <summary>処理区分定数</summary>
    public const string ClassRework  = "RW";   // リワーク
    public const string ClassAdd     = "AD";   // 追加
    public const string ClassPrior   = "PR";   // 先行

    public sealed record LotInfo(
        bool   IsSuccess,
        string LotId          = "",
        string PdId           = "",
        string NowSt          = "",
        string WfNum          = "",
        string LotLastUpdate  = "",
        string ErrorCode      = "",
        string ErrorMessage   = ""
    );

    public sealed record ReworkSetResult(
        bool   IsSuccess,
        string GuidanceMsg     = "",
        string GuidanceMsgCode = "",
        string ErrorCode       = "",
        string ErrorMessage    = ""
    );

    // ──────── キャリア現在状態取得 (carr.curstate) ──────────────────

    /// <summary>
    /// 特殊流動用キャリア現在状態を取得する。
    /// VBソース: pubblnCarrcurstate_Sel, MsgVer="04.00", CLASS_DIVISION=CPstrCD50
    /// </summary>
    public async Task<LotInfo> GetCarrierStateAsync(
        string carrierId, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.ClassDivision, CdSpecialFlow);
        req.AddString(Tags.MsgVer,        VerCurrState);
        req.AddString(Tags.CarrierId,     carrierId);
        req.AddString(Tags.CarrierTypeId, "");
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.LotId,         "");
        req.AddString(Tags.OpId,          "");
        req.AddString(Tags.StepId,        "");
        req.AddString(Tags.AltNumber,     "");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.CarrCurState, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "SpecialFlow/CarrCurState failed. CarrierId={CarrierId}", carrierId);
            return new LotInfo(false, ErrorMessage: $"通信エラー: {ex.Message}");
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = msg.GetErrorInfo();
            logger.LogWarning("SpecialFlow/CarrCurState returned FALSE. CarrierId={CarrierId}, Code={Code}",
                carrierId, code);
            return new LotInfo(false, ErrorCode: code,
                ErrorMessage: string.IsNullOrEmpty(message) ? "キャリア照合に失敗しました。" : message);
        }

        return new LotInfo(
            IsSuccess:    true,
            LotId:        msg.GetString(Tags.LotId),
            PdId:         msg.GetString(Tags.PdId),
            NowSt:        msg.GetString(Tags.NowSt),
            WfNum:        msg.GetString(Tags.WfNum),
            LotLastUpdate: msg.GetString(Tags.LotLastUpdate)
        );
    }

    // ──────── 特殊流動設定 (lot_.reworkset_) ─────────────────────────

    /// <summary>
    /// 特殊流動(リワーク/追加/先行)を登録する。
    /// VBソース: pubblnReworkSet_Ins, MsgVer="02.00"
    /// ClassDivision: "RW"=リワーク, "AD"=追加, "PR"=先行
    /// </summary>
    public async Task<ReworkSetResult> RegisterAsync(
        string lotId,
        string classDivision,
        string toOpId,
        string toStepId,
        string empId,
        string lotLastUpdate,
        string reworkReason    = "",
        string reworkSubReason = "",
        string comments        = "",
        CancellationToken ct   = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,          lotId);
        req.AddString(Tags.ClassDivision,  classDivision);
        req.AddString(Tags.ToOpId,         toOpId);
        req.AddString(Tags.ToStepId,       toStepId);
        req.AddString(Tags.EmpId,          empId);
        req.AddString(Tags.LotLastUpdate,  lotLastUpdate);
        req.AddString("REWORK_REASON",     reworkReason);
        req.AddString("REWORK_SUB_REASON", reworkSubReason);
        req.AddString(Tags.Comments,       comments);
        req.AddString(Tags.SbId,           _sbId);
        req.AddString(Tags.MsgVer,         VerReworkSet);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgReworkSet, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "ReworkSet failed. LotId={LotId} Class={Class}", lotId, classDivision);
            return new ReworkSetResult(false, ErrorMessage: $"通信エラー: {ex.Message}");
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = msg.GetErrorInfo();
            logger.LogWarning("ReworkSet returned FALSE. LotId={LotId}, Code={Code}", lotId, code);
            return new ReworkSetResult(false, ErrorCode: code,
                ErrorMessage: string.IsNullOrEmpty(message) ? "特殊流動の登録に失敗しました。" : message);
        }

        return new ReworkSetResult(
            IsSuccess:      true,
            GuidanceMsg:    msg.GetString(Tags.Msg),
            GuidanceMsgCode: msg.GetString(Tags.MsgCode)
        );
    }
}
