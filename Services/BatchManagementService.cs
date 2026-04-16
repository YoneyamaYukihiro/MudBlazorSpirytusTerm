namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// バッチ装置管理サービス (EN02N0)。
/// ・装置一覧取得          (mas_.wplist__)        VBソース: pubblnWpList_Sel         (CtsbasxxMG02N0.vb)
/// ・バッチ編成設定取得    (bat_.composestatus)   VBソース: pubblnBatComposeStatus_Sel (CtsbasxxMG02N0.vb)
/// ・バッチレシピ一覧取得  (bat_.recipelist)      VBソース: pubblnBatRecipeList_Sel    (CtsbasxxMG02N0.vb)
/// ・バッチ装置待ちロット  (bat_.waitinglotlist)  VBソース: pubblnBatWaitingLotList_Sel (CtsbasxxMG02N0.vb)
/// ・バッチ編成設定登録    (bat_.composeregist)   VBソース: pubblnBatComposeRegist_Upd  (CtsbasxxMG02N0.vb)
/// </summary>
public sealed class BatchManagementService(ITfMessageClient mq, IConfiguration cfg, ILogger<BatchManagementService> logger)
{
    private readonly string _defaultSbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    // ──────── 公開型 ────────────────────────────────────────────

    /// <summary>装置グループエントリ (mas_.mcgrouplist 応答)</summary>
    public sealed record McGroupEntry(string Id, string Name);

    /// <summary>装置エントリ (mas_.wplist__ 応答)</summary>
    public sealed record WpEntry(
        string WpId,
        string WpName,
        string MesModeId,
        string EqType
    );

    /// <summary>バッチレシピ選択肢 (bat_.recipelist 応答)</summary>
    public sealed record RecipeChoice(
        string RecipeType,
        string RecipeId
    );

    /// <summary>バッチ編成設定内レシピ行 (bat_.composestatus 応答/登録用)</summary>
    public sealed record RecipeRow(
        string SeqNum,
        string RecipeType,       // "1"=製品 "2"=ガスクリーニング "3"=プリコート
        string RecipeId,
        string WfNum,
        string TimeNum,
        string TimeWfNum,
        string EditEmpName       = "",
        string EditTime          = "",
        string EditFlag          = "0"
    );

    /// <summary>バッチ編成設定取得結果</summary>
    public sealed record ComposeStatusResult(
        bool   IsSuccess,
        string WpId              = "",
        string BatchComposeType  = "",   // "1"=自動, それ以外=手動
        string EditEmpName       = "",
        string EditTime          = "",
        IReadOnlyList<RecipeRow>? RecipeList = null,
        string ErrorCode         = "",
        string ErrorMessage      = ""
    );

    /// <summary>バッチレシピ一覧取得結果</summary>
    public sealed record RecipeListResult(
        bool   IsSuccess,
        string WpId              = "",
        string MaxProcessQuantity = "",
        string TimeNumItem        = "",  // カンマ区切り時間候補
        IReadOnlyList<RecipeChoice>? RecipeChoices = null,
        string ErrorCode         = "",
        string ErrorMessage      = ""
    );

    /// <summary>バッチ装置待ちロット</summary>
    public sealed record WaitingLot(
        string LotId,
        string RecipeId,
        string FlowClass,
        string LotPriority,
        string OpId,
        string StepId,
        string CarrierId,
        string WfQuantity,
        string CurrentPositionName,
        string LotStopFlag,
        string LotHoldFlag,
        string WaitTimeH
    );

    /// <summary>バッチ装置待ちロット一覧取得結果</summary>
    public sealed record WaitingLotListResult(
        bool   IsSuccess,
        IReadOnlyList<WaitingLot>? Lots = null,
        string ErrorCode    = "",
        string ErrorMessage = ""
    );

    /// <summary>バッチ編成設定登録要求</summary>
    public sealed record ComposeRegistRequest(
        string WpId,
        string EmpId,
        string BatchComposeType,
        string EditFlag,
        IReadOnlyList<RecipeRow> RecipeList,
        string MsgVer = "01.00"
    );

    /// <summary>バッチ編成設定登録結果</summary>
    public sealed record ComposeRegistResult(
        bool   IsSuccess,
        string ErrorCode    = "",
        string ErrorMessage = ""
    );

    // ──────── バッチ装置グループ取得 (mas_.mcgrouplist / CD=2G) ──

    /// <summary>
    /// バッチ装置グループ一覧を取得する。
    /// VBソース: publnMasMcGroupList_Sel, MsgVer="01.00", ClassDivision="2G"
    /// </summary>
    public async Task<IReadOnlyList<McGroupEntry>> GetBatchMcGroupListAsync(
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer, "01.00");
        req.AddString(Tags.ClassDivision, "2G");   // CPstrCD2G: バッチ装置グループ
        req.AddString(Tags.SbId, _defaultSbId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.MasMcGroupList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "MasMcGroupList(2G) request failed");
            return [];
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("MasMcGroupList(2G) returned non-TRUE. Raw={Raw}", Summarize(raw));
            return [];
        }

        var ary = msg.GetMsgAry(Tags.McGroupList);
        return ary.Select(item => new McGroupEntry(
            Id:   item.GetString(Tags.McGroupId),
            Name: item.GetString(Tags.McGroupName)
        )).ToList();
    }

    // ──────── 装置一覧取得 (mas_.wplist__) ──────────────────────

    /// <summary>
    /// 装置グループに属する装置一覧を取得する。
    /// VBソース: publnWpList_Sel, MsgVer="05.01", ClassDivision="20"
    /// </summary>
    public async Task<IReadOnlyList<WpEntry>> GetWpListAsync(
        string mcGroupId, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,        "05.01");
        req.AddString(Tags.SbId,          _defaultSbId);
        req.AddString(Tags.ClassDivision, "20");   // CPstrCD20: 装置グループ別
        req.AddString(Tags.McGroupId,     mcGroupId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.MasWpList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "MasWpList request failed. McGroupId={McGroupId}", mcGroupId);
            return [];
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            logger.LogWarning("MasWpList returned non-TRUE. McGroupId={McGroupId}, Raw={Raw}",
                mcGroupId, Summarize(raw));
            return [];
        }

        var ary = msg.GetMsgAry(Tags.WpList);
        return ary.Select(item => new WpEntry(
            WpId:      item.GetString(Tags.WpId),
            WpName:    item.GetString(Tags.WpName),
            MesModeId: item.GetString(Tags.MesModeId),
            EqType:    item.GetString(Tags.EqType)
        )).ToList();
    }

    // ──────── バッチ編成設定取得 (bat_.composestatus) ──────────

    /// <summary>
    /// バッチ編成設定を取得する。
    /// VBソース: pubblnBatComposeStatus_Sel, MsgVer="01.00"
    /// </summary>
    public async Task<ComposeStatusResult> GetComposeStatusAsync(
        string wpId, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer, "01.00");
        req.AddString(Tags.SbId,   _defaultSbId);
        req.AddString(Tags.WpId,   wpId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.BatComposeStatus, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "BatComposeStatus request failed. WpId={WpId}", wpId);
            return new ComposeStatusResult(false, ErrorMessage: ex.Message);
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var errCode = msg.GetString(Tags.ErrCode);
            var errMsg  = msg.GetString(Tags.ErrMsg);
            logger.LogWarning("BatComposeStatus returned non-TRUE. WpId={WpId}, ErrCode={ErrCode}", wpId, errCode);
            return new ComposeStatusResult(false, ErrorCode: errCode, ErrorMessage: errMsg);
        }

        var ary = msg.GetMsgAry(Tags.RecipeList);
        var recipes = ary.Select(item => new RecipeRow(
            SeqNum:      item.GetString(Tags.SeqNum),
            RecipeType:  item.GetString(Tags.BatchRecipeType),
            RecipeId:    item.GetString(Tags.RecipeId),
            WfNum:       item.GetString(Tags.WfNum),
            TimeNum:     item.GetString(Tags.TimeNum),
            TimeWfNum:   item.GetString(Tags.TimeWfNum),
            EditEmpName: item.GetString(Tags.EditEmpName),
            EditTime:    item.GetString(Tags.EditTime),
            EditFlag:    "0"
        )).ToList();

        return new ComposeStatusResult(
            IsSuccess:       true,
            WpId:            msg.GetString(Tags.WpId),
            BatchComposeType: msg.GetString(Tags.BatchComposeType),
            EditEmpName:     msg.GetString(Tags.EditEmpName),
            EditTime:        msg.GetString(Tags.EditTime),
            RecipeList:      recipes
        );
    }

    // ──────── バッチレシピ一覧取得 (bat_.recipelist) ────────────

    /// <summary>
    /// バッチレシピ一覧を取得する。
    /// VBソース: pubblnBatRecipeList_Sel, MsgVer="01.00"
    /// </summary>
    public async Task<RecipeListResult> GetRecipeListAsync(
        string wpId, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer, "01.00");
        req.AddString(Tags.SbId,   _defaultSbId);
        req.AddString(Tags.WpId,   wpId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.BatRecipeList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "BatRecipeList request failed. WpId={WpId}", wpId);
            return new RecipeListResult(false, ErrorMessage: ex.Message);
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var errCode = msg.GetString(Tags.ErrCode);
            var errMsg  = msg.GetString(Tags.ErrMsg);
            logger.LogWarning("BatRecipeList returned non-TRUE. WpId={WpId}, ErrCode={ErrCode}", wpId, errCode);
            return new RecipeListResult(false, ErrorCode: errCode, ErrorMessage: errMsg);
        }

        var ary = msg.GetMsgAry(Tags.RecipeList);
        var choices = ary.Select(item => new RecipeChoice(
            RecipeType: item.GetString(Tags.BatchRecipeType),
            RecipeId:   item.GetString(Tags.RecipeId)
        )).ToList();

        return new RecipeListResult(
            IsSuccess:          true,
            WpId:               msg.GetString(Tags.WpId),
            MaxProcessQuantity: msg.GetString(Tags.MaxProcessQuantity),
            TimeNumItem:        msg.GetString(Tags.TimeNumItem),
            RecipeChoices:      choices
        );
    }

    // ──────── バッチ装置待ちロット一覧取得 (bat_.waitinglotlist) ─

    /// <summary>
    /// バッチ装置待ちロット一覧を取得する。
    /// VBソース: pubblnBatWaitingLotList_Sel, MsgVer="01.00"
    /// </summary>
    public async Task<WaitingLotListResult> GetWaitingLotListAsync(
        string wpId, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer, "01.00");
        req.AddString(Tags.WpId,   wpId);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.BatWaitingLotList, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "BatWaitingLotList request failed. WpId={WpId}", wpId);
            return new WaitingLotListResult(false, ErrorMessage: ex.Message);
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var errCode = msg.GetString(Tags.ErrCode);
            var errMsg  = msg.GetString(Tags.ErrMsg);
            logger.LogWarning("BatWaitingLotList returned non-TRUE. WpId={WpId}, ErrCode={ErrCode}", wpId, errCode);
            return new WaitingLotListResult(false, ErrorCode: errCode, ErrorMessage: errMsg);
        }

        var ary = msg.GetMsgAry(Tags.LotList);
        var lots = ary.Select(item => new WaitingLot(
            LotId:               item.GetString(Tags.LotId),
            RecipeId:            item.GetString(Tags.RecipeId),
            FlowClass:           item.GetString(Tags.FlowClass),
            LotPriority:         item.GetString(Tags.LotPriority),
            OpId:                item.GetString(Tags.OpId),
            StepId:              item.GetString(Tags.StepId),
            CarrierId:           item.GetString(Tags.CarrierId),
            WfQuantity:          item.GetString(Tags.WfQuantity),
            CurrentPositionName: item.GetString(Tags.CurrentPositionName),
            LotStopFlag:         item.GetString(Tags.LotStopFlag),
            LotHoldFlag:         item.GetString(Tags.LotHoldFlag),
            WaitTimeH:           item.GetString(Tags.WaitTimeH)
        )).ToList();

        return new WaitingLotListResult(IsSuccess: true, Lots: lots);
    }

    // ──────── バッチ編成設定登録 (bat_.composeregist) ───────────

    /// <summary>
    /// バッチ編成設定を登録する。
    /// VBソース: pubblnBatComposeRegist_Upd, MsgVer="01.00"
    /// </summary>
    public async Task<ComposeRegistResult> RegisterComposeAsync(
        ComposeRegistRequest request, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.MsgVer,           request.MsgVer);
        req.AddString(Tags.SbId,             _defaultSbId);
        req.AddString(Tags.WpId,             request.WpId);
        req.AddString(Tags.EmpId,            request.EmpId);
        req.AddString(Tags.BatchComposeType, request.BatchComposeType);
        req.AddString(Tags.EditFlag,         request.EditFlag);

        var recipeAry = new TfMsgAry();
        foreach (var row in request.RecipeList)
        {
            var item = new TfMsg();
            item.AddString(Tags.SeqNum,          row.SeqNum);
            item.AddString(Tags.BatchRecipeType, row.RecipeType);
            item.AddString(Tags.RecipeId,        row.RecipeId);
            item.AddString(Tags.WfNum,           row.WfNum);
            item.AddString(Tags.TimeNum,         row.TimeNum);
            item.AddString(Tags.TimeWfNum,       row.TimeWfNum);
            item.AddString(Tags.EditFlag,        row.EditFlag);
            recipeAry.Add(item);
        }
        req.AddMsgAry(Tags.RecipeList, recipeAry);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.BatComposeRegist, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "BatComposeRegist request failed. WpId={WpId}", request.WpId);
            return new ComposeRegistResult(false, ErrorMessage: ex.Message);
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var errCode = msg.GetString(Tags.ErrCode);
            var errMsg  = msg.GetString(Tags.ErrMsg);
            logger.LogWarning("BatComposeRegist returned non-TRUE. WpId={WpId}, ErrCode={ErrCode}", request.WpId, errCode);
            return new ComposeRegistResult(false, ErrorCode: errCode, ErrorMessage: errMsg);
        }

        return new ComposeRegistResult(true);
    }

    // ──────── 内部ヘルパー ────────────────────────────────────────
    private static string Summarize(string? raw) =>
        (raw ?? string.Empty) is { Length: > 200 } s ? s[..200] + "..." : raw ?? string.Empty;
}
