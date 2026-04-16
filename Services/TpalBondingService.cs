namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN01A0 TPAL貼り合わせ登録 のサービス。
/// ・TFTロット現在状態取得       (lot_.curstate)       VBソース: pubblnLotCurstate_Sel    MsgVer="04.00"
/// ・TPAL使用実績取得            (lot_.tpalcombresult) VBソース: pubblnTpalCombResult_Sel MsgVer="02.00"
/// ・貼り合わせ可能TPAL情報取得  (inv_.combabletpal)   VBソース: pubblnCombableTpal_Sel   MsgVer="01.00"
/// ・TPAL貼り合わせ開始          (lot_.tpalcombstart)  VBソース: pubblnTpalCombStart_Ins  MsgVer="03.00"
/// </summary>
public sealed class TpalBondingService(ITfMessageClient mq, IConfiguration cfg, ILogger<TpalBondingService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    private const string MsgTpalCombResult = "lot_.tpalcombresult";
    private const string MsgCombableTpal   = "inv_.combabletpal";
    private const string MsgTpalCombStart  = "lot_.tpalcombstart";

    private const string VerCurState       = "04.00";
    private const string VerTpalCombResult = "02.00";
    private const string VerCombableTpal   = "01.00";
    private const string VerTpalCombStart  = "03.00";
    private const string CdTpalComb        = "70";   // CLASS_DIVISION: TPAL貼り合わせ

    // ──────── 公開型 ────────────────────────────────────────────

    public sealed record TftLotInfo(
        bool   IsSuccess,
        string LotId          = "",
        string PdId           = "",
        string NowSt          = "",
        string WfNum          = "",
        string LotLastUpdate  = "",
        string ErrorCode      = "",
        string ErrorMessage   = ""
    );

    public sealed record TpalUsageEntry(
        string CarrierId,
        string TpalLotId,
        string CoverNum,
        string OutNum,
        string RestNum,
        string LimitTime
    );

    public sealed record TpalUsageResult(
        bool   IsSuccess,
        IReadOnlyList<TpalUsageEntry>? Items = null,
        string ErrorCode    = "",
        string ErrorMessage = ""
    );

    public sealed record TpalInfo(
        bool   IsSuccess,
        string TpalLotId    = "",
        string RestNum      = "",
        string LimitTime    = "",
        string ErrorCode    = "",
        string ErrorMessage = ""
    );

    public sealed record TpalCombRow(
        string CarrierId,
        string TpalLotId,
        string CoverNum,
        string OutNum
    );

    public sealed record BondingResult(
        bool   IsSuccess,
        string ErrorCode    = "",
        string ErrorMessage = ""
    );

    // ──────── TFTロット現在状態取得 (lot_.curstate) ────────────────────

    /// <summary>
    /// TPAL貼り合わせ用TFTロット現在状態を取得する。
    /// VBソース: pubblnLotCurstate_Sel, MsgVer="04.00", CLASS_DIVISION=CPstrCD70
    /// </summary>
    public async Task<TftLotInfo> GetTftLotAsync(
        string carrierId, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.CarrierId,     carrierId);
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.ClassDivision, CdTpalComb);
        req.AddString(Tags.MsgVer,        VerCurState);
        req.AddString(Tags.LotId,         "");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotCurState, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "TpalBonding/LotCurState failed. CarrierId={CarrierId}", carrierId);
            return new TftLotInfo(false, ErrorMessage: $"通信エラー: {ex.Message}");
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = msg.GetErrorInfo();
            logger.LogWarning("TpalBonding/LotCurState returned FALSE. CarrierId={CarrierId}, Code={Code}",
                carrierId, code);
            return new TftLotInfo(false, ErrorCode: code,
                ErrorMessage: string.IsNullOrEmpty(message) ? "TFTロット照合に失敗しました。" : message);
        }

        return new TftLotInfo(
            IsSuccess:    true,
            LotId:        msg.GetString(Tags.LotId),
            PdId:         msg.GetString(Tags.PdId),
            NowSt:        msg.GetString(Tags.NowSt),
            WfNum:        msg.GetString(Tags.WfNum),
            LotLastUpdate: msg.GetString(Tags.LotLastUpdate)
        );
    }

    // ──────── TPAL使用実績取得 (lot_.tpalcombresult) ──────────────────

    /// <summary>
    /// 指定TFTロットのTPAL使用実績を取得する。
    /// VBソース: pubblnTpalCombResult_Sel, MsgVer="02.00"
    /// </summary>
    public async Task<TpalUsageResult> GetTpalUsageAsync(
        string lotId, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,  lotId);
        req.AddString(Tags.SbId,   _sbId);
        req.AddString(Tags.MsgVer, VerTpalCombResult);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgTpalCombResult, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "TpalCombResult failed. LotId={LotId}", lotId);
            return new TpalUsageResult(false, ErrorMessage: $"通信エラー: {ex.Message}");
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = msg.GetErrorInfo();
            logger.LogWarning("TpalCombResult returned FALSE. LotId={LotId}, Code={Code}", lotId, code);
            return new TpalUsageResult(false, ErrorCode: code,
                ErrorMessage: string.IsNullOrEmpty(message) ? "TPAL使用実績の取得に失敗しました。" : message);
        }

        var ary = msg.GetMsgAry("TPAL_COMB_LIST");
        var items = ary.Select(e => new TpalUsageEntry(
            CarrierId:  e.GetString(Tags.CarrierId),
            TpalLotId:  e.GetString(Tags.TpLotId),
            CoverNum:   e.GetString("COVER_NUM"),
            OutNum:     e.GetString("OUT_NUM"),
            RestNum:    e.GetString("REST_NUM"),
            LimitTime:  e.GetString(Tags.LimitTime)
        )).ToList();

        return new TpalUsageResult(true, Items: items);
    }

    // ──────── 貼り合わせ可能TPAL情報取得 (inv_.combabletpal) ─────────

    /// <summary>
    /// キャリアIDからTPAL情報を取得する。
    /// VBソース: pubblnCombableTpal_Sel, MsgVer="01.00"
    /// </summary>
    public async Task<TpalInfo> GetCombableTpalAsync(
        string tpalCarrierId, string tftLotId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.CarrierId, tpalCarrierId);
        req.AddString(Tags.LotId,     tftLotId);
        req.AddString(Tags.SbId,      _sbId);
        req.AddString(Tags.MsgVer,    VerCombableTpal);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgCombableTpal, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "CombableTpal failed. TpalCarrierId={Id}", tpalCarrierId);
            return new TpalInfo(false, ErrorMessage: $"通信エラー: {ex.Message}");
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = msg.GetErrorInfo();
            logger.LogWarning("CombableTpal returned FALSE. CarrierId={Id}, Code={Code}",
                tpalCarrierId, code);
            return new TpalInfo(false, ErrorCode: code,
                ErrorMessage: string.IsNullOrEmpty(message) ? "TPAL情報の取得に失敗しました。" : message);
        }

        return new TpalInfo(
            IsSuccess: true,
            TpalLotId: msg.GetString(Tags.TpLotId),
            RestNum:   msg.GetString("REST_NUM"),
            LimitTime: msg.GetString(Tags.LimitTime)
        );
    }

    // ──────── TPAL貼り合わせ開始 (lot_.tpalcombstart) ────────────────

    /// <summary>
    /// TPAL貼り合わせを登録する。
    /// VBソース: pubblnTpalCombStart_Ins, MsgVer="03.00"
    /// </summary>
    public async Task<BondingResult> RegisterBondingAsync(
        string tftLotId,
        string empId,
        string lotLastUpdate,
        IReadOnlyList<TpalCombRow> tpalRows,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,         tftLotId);
        req.AddString(Tags.EmpId,          empId);
        req.AddString(Tags.LotLastUpdate,  lotLastUpdate);
        req.AddString(Tags.SbId,           _sbId);
        req.AddString(Tags.MsgVer,         VerTpalCombStart);

        // TPAL_COMB_LIST
        var tpalAry = new TfMsgAry();
        foreach (var row in tpalRows)
        {
            var item = new TfMsg();
            item.AddString(Tags.CarrierId, row.CarrierId);
            item.AddString(Tags.TpLotId,   row.TpalLotId);
            item.AddString("COVER_NUM",    row.CoverNum);
            item.AddString("OUT_NUM",      row.OutNum);
            tpalAry.Add(item);
        }
        req.AddMsgAry("TPAL_COMB_LIST", tpalAry);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgTpalCombStart, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "TpalCombStart failed. LotId={LotId}", tftLotId);
            return new BondingResult(false, ErrorMessage: $"通信エラー: {ex.Message}");
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = msg.GetErrorInfo();
            logger.LogWarning("TpalCombStart returned FALSE. LotId={LotId}, Code={Code}", tftLotId, code);
            return new BondingResult(false, ErrorCode: code,
                ErrorMessage: string.IsNullOrEmpty(message) ? "TPAL貼り合わせの登録に失敗しました。" : message);
        }

        return new BondingResult(true);
    }
}
