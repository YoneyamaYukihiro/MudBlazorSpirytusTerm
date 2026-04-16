namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// ロット流動票サービス。
/// ・ロット流動票取得   (lot_.detaillist)
/// ・履歴コメント取得   (lot_.eventcomment)
/// ・レシピ情報取得     (lot_.userecp_)
/// VBソース: CtsbasxxMG01G0.vb
/// </summary>
public sealed class LotDetailListService(ITfMessageClient mq, IConfiguration cfg, ILogger<LotDetailListService> logger)
{
    private readonly string _defaultSbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 公開型 ────────────────────────────────────────────

    /// <summary>流動票一覧の装置使用ポートリスト</summary>
    public sealed record DetailWpItem(
        string WpName,
        string WpId,
        IReadOnlyList<string> PortNames
    );

    /// <summary>流動票の1工程要素</summary>
    public sealed record DetailListItem(
        string SeqNum,
        string CarrierId,
        string OpId,
        string StepId,
        string StartTime,
        string EndTime,
        string CollectionFlag,
        string WfNum,
        string ChipNum,
        string StartEmpName,
        string EndEmpName,
        string CommentFlag,
        string CommentTime,
        string RecipeId,
        string CdenClass,
        string GrbClass,
        IReadOnlyList<DetailWpItem> WpList
    );

    /// <summary>ロット流動票取得の結果。VBソース: LotDetailList 構造体</summary>
    public sealed record LotDetailListResult(
        string LotId,
        string CarrierId,
        string PdId,
        string CurrentSeqNum,
        string OpId,
        string StepId,
        string NowSt,
        string WfNum,
        string HoldFlag,
        string LastSeqNum,
        string LotLastUpdate,
        string StopFlag,
        string SendSbId,
        string SbArea,
        string GrbClass,
        IReadOnlyList<DetailListItem> DetailList
    );

    /// <summary>GetLotDetailListAsync の呼び出し結果ラッパー</summary>
    public sealed record LotDetailListResponse(
        bool IsSuccess,
        LotDetailListResult? Data = null,
        string ErrorCode = "",
        string ErrorMessage = ""
    );

    /// <summary>レシピ本体リストの1要素</summary>
    public sealed record RecipeBodyItem(
        string RecipeValue,
        string RecipeItem,
        string ValueType
    );

    /// <summary>レシピリストの1要素</summary>
    public sealed record RecipeListItem(
        string RecipeId,
        string DefaultFlag,
        string RecipeComments,
        IReadOnlyList<RecipeBodyItem> BodyList
    );

    /// <summary>レシピ情報取得の装置要素</summary>
    public sealed record UseWpItem(
        string WpId,
        string WpName,
        string WfId,
        string HistoryFlag,
        IReadOnlyList<RecipeListItem> RecipeList
    );

    /// <summary>レシピ情報取得の結果。VBソース: UseRecpAns 構造体</summary>
    public sealed record LotUseRecpResult(
        string SelectConditionId,
        IReadOnlyList<UseWpItem> WpList
    );

    // ──────── ロット流動票取得 ───────────────────────────────────

    /// <summary>
    /// ロット流動票情報を取得する。
    /// VBソース: pubblnLotDetailList_Sel, MsgVer="04.00"
    /// </summary>
    public async Task<LotDetailListResponse> GetLotDetailListAsync(
        string lotId,
        string carrierId        = "",
        string startSeqNum      = "",
        string beforeNum        = "",
        string afterNum         = "",
        CancellationToken ct    = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,      "04.00");
        req.AddString(Tags.SbId,        _defaultSbId);
        req.AddString(Tags.LotId,       lotId);
        req.AddString(Tags.CarrierId,   carrierId);
        req.AddString(Tags.StartSeqNum, startSeqNum);
        req.AddString(Tags.BeforeNum,   beforeNum);
        req.AddString(Tags.AfterNum,    afterNum);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotDetailList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotDetailList request failed. LotId={LotId}", lotId);
            return new LotDetailListResponse(false, ErrorMessage: ex.Message);
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var code    = !string.IsNullOrEmpty(msg.GetString(Tags.MsgCode)) ? msg.GetString(Tags.MsgCode) : msg.GetString(Tags.ErrCode);
            var message = !string.IsNullOrEmpty(msg.GetString(Tags.Msg))     ? msg.GetString(Tags.Msg)     : msg.GetString(Tags.ErrMsg);
            logger.LogWarning("LotDetailList returned non-TRUE. LotId={LotId}, Code={Code}, Msg={Msg}",
                lotId, code, message);
            return new LotDetailListResponse(false, ErrorCode: code, ErrorMessage: message);
        }

        var detailAry = msg.GetMsgAry(Tags.DetailList);
        var detailList = detailAry.Select(e1 =>
        {
            var wpAry = e1.GetMsgAry(Tags.WpList);
            var wpList = wpAry.Select(e2 =>
            {
                var portAry = e2.GetMsgAry(Tags.PortList);
                var portNames = portAry.Select(e3 => e3.GetString(Tags.PortName)).ToList();
                return new DetailWpItem(
                    WpName:    e2.GetString(Tags.WpName),
                    WpId:      e2.GetString(Tags.WpId),
                    PortNames: portNames);
            }).ToList();

            return new DetailListItem(
                SeqNum:         e1.GetString(Tags.SeqNum),
                CarrierId:      e1.GetString(Tags.CarrierId),
                OpId:           e1.GetString(Tags.OpId),
                StepId:         e1.GetString(Tags.StepId),
                StartTime:      e1.GetString(Tags.StartTime),
                EndTime:        e1.GetString(Tags.EndTime),
                CollectionFlag: e1.GetString(Tags.CollectionFlag),
                WfNum:          e1.GetString(Tags.WfNum),
                ChipNum:        e1.GetString(Tags.ChipNum),
                StartEmpName:   e1.GetString(Tags.StartEmpName),
                EndEmpName:     e1.GetString(Tags.EndEmpName),
                CommentFlag:    e1.GetString(Tags.CommentFlag),
                CommentTime:    e1.GetString(Tags.CommentTime),
                RecipeId:       e1.GetString(Tags.RecipeId),
                CdenClass:      e1.GetString(Tags.CdenClass),
                GrbClass:       e1.GetString(Tags.GrbClass),
                WpList:         wpList);
        }).ToList();

        return new LotDetailListResponse(true, new LotDetailListResult(
            LotId:          msg.GetString(Tags.LotId),
            CarrierId:      msg.GetString(Tags.CarrierId),
            PdId:           msg.GetString(Tags.PdId),
            CurrentSeqNum:  msg.GetString(Tags.CurrentSeqNum),
            OpId:           msg.GetString(Tags.OpId),
            StepId:         msg.GetString(Tags.StepId),
            NowSt:          msg.GetString(Tags.NowSt),
            WfNum:          msg.GetString(Tags.WfNum),
            HoldFlag:       msg.GetString(Tags.HoldFlag),
            LastSeqNum:     msg.GetString(Tags.LastSeqNum),
            LotLastUpdate:  msg.GetString(Tags.LotLastUpdate),
            StopFlag:       msg.GetString(Tags.LotStopFlag),
            SendSbId:       msg.GetString(Tags.SendSbId),
            SbArea:         msg.GetString(Tags.SbArea),
            GrbClass:       msg.GetString(Tags.GrbClass),
            DetailList:     detailList));
    }

    // ──────── 履歴コメント取得 ───────────────────────────────────

    /// <summary>
    /// 履歴コメントを取得する。
    /// VBソース: pubblnLotEventComment_Sel, MsgVer="01.00"
    /// </summary>
    public async Task<string?> GetEventCommentAsync(
        string lotId,
        string seqNum,
        string entryTime,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,    "01.00");
        req.AddString(Tags.SbId,      _defaultSbId);
        req.AddString(Tags.LotId,     lotId);
        req.AddString(Tags.SeqNum,    seqNum);
        req.AddString(Tags.EntryTime, entryTime);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotEventComment, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotEventComment request failed. LotId={LotId}", lotId);
            return null;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("LotEventComment returned non-TRUE. LotId={LotId}, Raw={Raw}",
                lotId, Summarize(raw));
            return null;
        }

        return msg.GetString(Tags.Comments);
    }

    // ──────── レシピ情報取得 ─────────────────────────────────────

    /// <summary>
    /// レシピ情報を取得する。
    /// VBソース: pubblnLotUseRecp_Sel, MsgVer="01.00"
    /// </summary>
    public async Task<LotUseRecpResult?> GetUseRecpAsync(
        string opId,
        string stepId,
        string lotId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer, "01.00");
        req.AddString(Tags.SbId,   _defaultSbId);
        req.AddString(Tags.OpId,   opId);
        req.AddString(Tags.StepId, stepId);
        req.AddString(Tags.LotId,  lotId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotUseRecp, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotUseRecp request failed. LotId={LotId}", lotId);
            return null;
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("LotUseRecp returned non-TRUE. LotId={LotId}, Raw={Raw}",
                lotId, Summarize(raw));
            return null;
        }

        var wpAry = msg.GetMsgAry(Tags.WpList);
        var wpList = wpAry.Select(e1 =>
        {
            var recipeAry = e1.GetMsgAry(Tags.RecipeList);
            var recipeList = recipeAry.Select(e2 =>
            {
                var bodyAry = e2.GetMsgAry(Tags.RecipeBodyList);
                var bodyList = bodyAry.Select(e3 => new RecipeBodyItem(
                    RecipeValue: e3.GetString(Tags.RecipeValue),
                    RecipeItem:  e3.GetString(Tags.RecipeItem),
                    ValueType:   e3.GetString(Tags.ValueType))).ToList();
                return new RecipeListItem(
                    RecipeId:       e2.GetString(Tags.RecipeId),
                    DefaultFlag:    e2.GetString(Tags.DefaultFlag),
                    RecipeComments: e2.GetString(Tags.RecipeComments),
                    BodyList:       bodyList);
            }).ToList();

            return new UseWpItem(
                WpId:        e1.GetString(Tags.WpId),
                WpName:      e1.GetString(Tags.WpName),
                WfId:        e1.GetString(Tags.WfId),
                HistoryFlag: e1.GetString(Tags.HistoryFlag),
                RecipeList:  recipeList);
        }).ToList();

        return new LotUseRecpResult(
            SelectConditionId: msg.GetString(Tags.SelectConditionId),
            WpList:            wpList);
    }

    // ──────── 内部ヘルパー ────────────────────────────────────────
    private static string Summarize(string? raw) =>
        (raw ?? string.Empty) is { Length: > 200 } s ? s[..200] + "..." : raw ?? string.Empty;
}
