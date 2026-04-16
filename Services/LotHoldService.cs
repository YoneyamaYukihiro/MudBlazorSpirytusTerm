namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN0050 ロット保留 / EN00A0 ロット保留解除 のサービス。
/// VBソース: VB/COMN/CtsfrmxxCM0120.vb, VB/COMN/CtsbasxxCM0050.vb
/// </summary>
public sealed class LotHoldService(ITfMessageClient mq, IConfiguration cfg, ILogger<LotHoldService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 型定義 ────────

    public sealed record ReasonItem(string ReasonCode, string ReasonName);

    public sealed record HoldInfoItem(
        string HoldReasonId,
        string HoldReasonName,
        string HoldTime,
        string HoldComments,
        string HoldEmpId,
        string HoldEmpName,
        string HoldTermDate,
        string HoldStayDate,
        string EntryTime
    );

    public sealed record HoldRequest(
        string LotId,
        string HoldReasonId,
        string HoldComments,
        string HoldTermDate,
        string HoldEmpId,
        string EmpId,
        string LotLastUpdate
    );

    public sealed record ReleaseRequest(
        string LotId,
        string HoldComments,
        string EmpId,
        string LotLastUpdate,
        string EntryTime
    );

    public sealed record ActionResult(
        bool IsSuccess,
        string ErrorMessage = "",
        string HoldTime = ""
    );

    // ──────── 保留理由一覧取得 (mas_.reasoncode ClassDivision="2U") ────────

    public async Task<IReadOnlyList<ReasonItem>> GetHoldReasonsAsync(CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,        "02.00");
        req.AddString(Tags.ClassDivision, "2U");

        try
        {
            var raw = await mq.SendMessageAsync(MsgIds.MasReasonCode, req.ToTfString(), ct);
            var msg = TfMsg.ParseOrEmpty(raw);
            if (msg.GetString(Tags.Ret) != Tags.True) return [];

            var ary = msg.GetMsgAry(Tags.LotReasonCodeList);
            return ary.Select(e => new ReasonItem(
                e.GetString(Tags.ReasonCode),
                e.GetString(Tags.ReasonName))).ToList();
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetHoldReasons failed");
            return [];
        }
    }

    // ──────── 保留情報取得 (lot_.holdinfo MSG_VER="03.00") ────────

    public async Task<IReadOnlyList<HoldInfoItem>> GetHoldInfoAsync(
        string lotId, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer, "03.00");
        req.AddString(Tags.SbId,   _sbId);
        req.AddString(Tags.LotId,  lotId);

        try
        {
            var raw = await mq.SendMessageAsync(MsgIds.LotHoldInfo, req.ToTfString(), ct);
            var msg = TfMsg.ParseOrEmpty(raw);
            if (msg.GetString(Tags.Ret) != Tags.True) return [];

            var ary = msg.GetMsgAry(Tags.HoldList);
            return ary.Select(e => new HoldInfoItem(
                HoldReasonId:   e.GetString(Tags.HoldReasonId),
                HoldReasonName: e.GetString(Tags.HoldReasonName),
                HoldTime:       e.GetString(Tags.HoldTime),
                HoldComments:   e.GetString(Tags.HoldComments),
                HoldEmpId:      e.GetString(Tags.HoldEmpId),
                HoldEmpName:    e.GetString(Tags.HoldEmpName),
                HoldTermDate:   e.GetString(Tags.HoldTermDate),
                HoldStayDate:   e.GetString(Tags.HoldStayDate),
                EntryTime:      e.GetString(Tags.EntryTime)
            )).ToList();
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "GetHoldInfo failed. LotId={LotId}", lotId);
            return [];
        }
    }

    // ──────── 保留設定 (lot_.hold____ MSG_VER="02.01") ────────

    public async Task<ActionResult> SetHoldAsync(HoldRequest r, CancellationToken ct = default)
    {
        logger.LogInformation("LotHold start. LotId={LotId}, ReasonId={Rid}", r.LotId, r.HoldReasonId);

        var req = new TfMsg();
        req.AddString(Tags.LotId,          r.LotId);
        req.AddString(Tags.HoldReasonId,   r.HoldReasonId);
        req.AddString(Tags.HoldComments,   r.HoldComments);
        req.AddString(Tags.HoldTermDate,   r.HoldTermDate);
        req.AddString(Tags.HoldEmpId,      r.HoldEmpId);
        req.AddString(Tags.EmpId,          r.EmpId);
        req.AddString(Tags.LotLastUpdate,  r.LotLastUpdate);
        req.AddString(Tags.SbId,           _sbId);
        req.AddString(Tags.MsgVer,         "02.01");

        return await SendAndParseAsync(MsgIds.LotHold, req, ct);
    }

    // ──────── 保留解除 (lot_.releasehold MSG_VER="03.00") ────────

    public async Task<ActionResult> ReleaseHoldAsync(ReleaseRequest r, CancellationToken ct = default)
    {
        logger.LogInformation("LotReleaseHold start. LotId={LotId}", r.LotId);

        var req = new TfMsg();
        req.AddString(Tags.LotId,          r.LotId);
        req.AddString(Tags.HoldComments,   r.HoldComments);
        req.AddString(Tags.EmpId,          r.EmpId);
        req.AddString(Tags.LotLastUpdate,  r.LotLastUpdate);
        req.AddString(Tags.EntryTime,      r.EntryTime);
        req.AddString(Tags.SbId,           _sbId);
        req.AddString(Tags.MsgVer,         "03.00");

        return await SendAndParseAsync(MsgIds.LotReleaseHold, req, ct);
    }

    // ──────── ヘルパー ────────

    private async Task<ActionResult> SendAndParseAsync(
        string msgId, TfMsg req, CancellationToken ct)
    {
        string raw;
        try
        {
            raw = await mq.SendMessageAsync(msgId, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "Send failed. MsgId={MsgId}", msgId);
            return new ActionResult(false, $"通信エラー: {ex.Message}");
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var err = msg.GetString(Tags.ErrMsg);
            if (string.IsNullOrEmpty(err)) err = msg.GetString(Tags.Msg);
            logger.LogWarning("MsgId={MsgId} returned FALSE: {Err}", msgId, err);
            return new ActionResult(false, string.IsNullOrEmpty(err) ? "処理に失敗しました。" : err);
        }

        return new ActionResult(true, HoldTime: msg.GetString(Tags.HoldTime));
    }
}
