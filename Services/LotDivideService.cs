namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN0160 ロット分割 サービス。
/// VBソース: VB/0160/CtsbasxxMG0160.vb (pubblnLotDivide_Upd)
/// メッセージID: lot_.divide__  MsgVer="02.00"
/// キャリア状態確認: carr.curstate  MsgVer="05.02"
/// ロット現在状態取得: lot_.curstate  MsgVer="04.00"
/// </summary>
public sealed class LotDivideService(ITfMessageClient mq, IConfiguration cfg, ILogger<LotDivideService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 型定義 ────────

    public sealed record CarrierStateResult(
        bool   IsSuccess,
        string ErrorMessage  = "",
        string LotId         = "",
        string PdId          = "",
        string PdName        = "",
        string NowSt         = "",
        string EngEmpName    = "",
        string WfNum         = "",
        string LotLastUpdate = "",
        string SlotSize      = ""
    );

    public sealed record WfMapItem(
        string WfId,
        string SlotPosition
    );

    public sealed record DivideRequest(
        string LotId,
        string GrbClass,
        string DivideLotId,
        string DivideGrbClass,
        string Comments,
        string EmpId,
        string LotLastUpdate,
        IReadOnlyList<WfMapItem> DivideWfMapList
    );

    public sealed record DivideResult(
        bool   IsSuccess,
        string ErrorCode    = "",
        string ErrorMessage = "",
        string GuidMsg      = "",
        string GuidMsgCode  = ""
    );

    // ──────── キャリア状態取得 ────────

    public async Task<CarrierStateResult> GetCarrierStateAsync(string carrierId, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.CarrierId,     carrierId);
        req.AddString(Tags.ClassDivision, "");
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.MsgVer,        "05.02");

        try
        {
            var raw = await mq.SendMessageAsync(MsgIds.CarrCurState, req.ToTfString(), ct);
            var msg = TfMsg.ParseOrEmpty(raw);
            if (msg.GetString(Tags.Ret) != Tags.True)
            {
                var err = msg.GetString(Tags.ErrMsg);
                return new CarrierStateResult(false, string.IsNullOrEmpty(err) ? "照合に失敗しました。" : err);
            }
            return new CarrierStateResult(
                IsSuccess:     true,
                LotId:         msg.GetString(Tags.LotId),
                PdId:          msg.GetString(Tags.PdId),
                PdName:        msg.GetString(Tags.PdName),
                NowSt:         msg.GetString(Tags.NowSt),
                EngEmpName:    msg.GetString(Tags.EngEmpName),
                WfNum:         msg.GetString(Tags.WfNum),
                LotLastUpdate: msg.GetString(Tags.LotLastUpdate),
                SlotSize:      msg.GetString(Tags.SlotSize));
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetCarrierState failed. CarrierId={CarrierId}", carrierId);
            return new CarrierStateResult(false, $"通信エラー: {ex.Message}");
        }
    }

    // ──────── ロット分割実行 ────────

    /// <summary>
    /// ロット分割を実行する。
    /// VBソース: pubblnLotDivide_Upd, MsgVer="02.00", MsgId=lot_.divide__
    /// </summary>
    public async Task<DivideResult> ExecuteAsync(DivideRequest r, CancellationToken ct = default)
    {
        logger.LogInformation("LotDivide start. LotId={LotId}, DivideLotId={DivideLotId}", r.LotId, r.DivideLotId);

        var req = new TfMsg();
        req.AddString(Tags.MsgVer,      "02.00");
        req.AddString(Tags.LotId,       r.LotId);
        req.AddString(Tags.GrbClass,    r.GrbClass);
        req.AddString("DIVIDE_LOT_ID",  r.DivideLotId);
        req.AddString("DIVIDE_GRB_CLASS", r.DivideGrbClass);
        req.AddString(Tags.Comments,    r.Comments);
        req.AddString(Tags.EmpId,       r.EmpId);
        req.AddString(Tags.LotLastUpdate, r.LotLastUpdate);
        req.AddString(Tags.SbId,        _sbId);

        // DIVIDE_WF_MAP_LIST
        var ary = new TfMsgAry();
        foreach (var wf in r.DivideWfMapList)
        {
            var item = new TfMsg();
            item.AddString(Tags.WfId,         wf.WfId);
            item.AddString(Tags.SlotPosition, wf.SlotPosition);
            ary.Add(item);
        }
        req.AddMsgAry("DIVIDE_WF_MAP_LIST", ary);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync("lot_.divide__", req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "LotDivide send failed");
            return new DivideResult(false, ErrorMessage: $"通信エラー: {ex.Message}");
        }

        var resp = TfMsg.ParseOrEmpty(raw);
        if (resp.GetString(Tags.Ret) != Tags.True)
        {
            var (code, err) = resp.GetErrorInfo();
            if (string.IsNullOrEmpty(err)) err = resp.GetString(Tags.Msg);
            logger.LogWarning("LotDivide returned FALSE: {Err}", err);
            return new DivideResult(false, ErrorCode: code, ErrorMessage: string.IsNullOrEmpty(err) ? "ロット分割に失敗しました。" : err);
        }

        return new DivideResult(
            true,
            GuidMsg:     resp.GetString(Tags.Msg),
            GuidMsgCode: resp.GetString(Tags.MsgCode));
    }

    // ──────── ヘルパー ────────
}
