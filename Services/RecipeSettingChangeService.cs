namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// EN00S0 レシピ設定変更 のサービス。
/// ・ロット現在状態取得      (lot_.curstate)   VBソース: pubblnLotCurstate_Sel (CtsbasxxCM0050.vb)
/// ・使用可能レシピ一覧取得  (lot_.userecp_)   VBソース: pubblnLotUseRecp_Sel  (CtsbasxxEN01G0.vb)
/// ・レシピ変更              (lot_.chgrecp_)   VBソース: pubblnLotChgRecp_Upd  (CtsbasxxEN00S0.vb)
/// </summary>
public sealed class RecipeSettingChangeService(ITfMessageClient mq, IConfiguration cfg, ILogger<RecipeSettingChangeService> logger)
{
    private readonly string _sbId = cfg["Spirytus:DefaultSbId"] ?? string.Empty;

    private const string MsgLotChgRecp = "lot_.chgrecp_";
    private const string VerCurState   = "04.00";
    private const string VerUseRecp    = "01.00";
    private const string VerChgRecp    = "01.00";
    private const string CdRecipeChange = "20";   // CLASS_DIVISION: レシピ変更

    // ──────── 公開型 ────────────────────────────────────────────

    public sealed record LotInfo(
        bool   IsSuccess,
        string LotId          = "",
        string PdId           = "",
        string OpId           = "",
        string StepId         = "",
        string CurrentRecipeId = "",
        string LotLastUpdate  = "",
        string ErrorCode      = "",
        string ErrorMessage   = ""
    );

    public sealed record RecipeItem(
        string RecipeId,
        string RecipeName,
        bool   IsDefault,
        string Comments
    );

    public sealed record RecipeListResult(
        bool   IsSuccess,
        IReadOnlyList<RecipeItem>? Items = null,
        string ErrorCode    = "",
        string ErrorMessage = ""
    );

    public sealed record ChangeResult(
        bool   IsSuccess,
        string ErrorCode    = "",
        string ErrorMessage = ""
    );

    // ──────── ロット現在状態取得 (lot_.curstate) ─────────────────────

    /// <summary>
    /// レシピ変更用ロット現在状態を取得する。
    /// VBソース: pubblnLotCurstate_Sel, MsgVer="04.00", CLASS_DIVISION=CPstrCD20
    /// </summary>
    public async Task<LotInfo> GetLotInfoAsync(
        string carrierId, CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.CarrierId,     carrierId);
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.ClassDivision, CdRecipeChange);
        req.AddString(Tags.MsgVer,        VerCurState);
        req.AddString(Tags.LotId,         "");

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotCurState, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "RecipeChange/LotCurState failed. CarrierId={CarrierId}", carrierId);
            return new LotInfo(false, ErrorMessage: $"通信エラー: {ex.Message}");
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = msg.GetErrorInfo();
            logger.LogWarning("RecipeChange/LotCurState returned FALSE. CarrierId={CarrierId}, Code={Code}",
                carrierId, code);
            return new LotInfo(false, ErrorCode: code,
                ErrorMessage: string.IsNullOrEmpty(message) ? "ロット照合に失敗しました。" : message);
        }

        // 工程リストから最初の工程とレシピIDを取得
        var stepAry = msg.GetMsgAry(Tags.StepList);
        var opId    = "";
        var stepId  = "";
        var recipeId = "";
        if (stepAry.Count > 0)
        {
            opId     = stepAry[0].GetString(Tags.OpId);
            stepId   = stepAry[0].GetString(Tags.StepId);
            recipeId = stepAry[0].GetString(Tags.RecipeId);
        }

        return new LotInfo(
            IsSuccess:       true,
            LotId:           msg.GetString(Tags.LotId),
            PdId:            msg.GetString(Tags.PdId),
            OpId:            opId,
            StepId:          stepId,
            CurrentRecipeId: recipeId,
            LotLastUpdate:   msg.GetString(Tags.LotLastUpdate)
        );
    }

    // ──────── 使用可能レシピ一覧取得 (lot_.userecp_) ──────────────────

    /// <summary>
    /// ロットで使用可能なレシピ一覧を取得する。
    /// VBソース: pubblnLotUseRecp_Sel, MsgVer="01.00"
    /// </summary>
    public async Task<RecipeListResult> GetUsableRecipesAsync(
        string lotId, string opId, string stepId,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,   lotId);
        req.AddString(Tags.OpId,    opId);
        req.AddString(Tags.StepId,  stepId);
        req.AddString(Tags.SbId,    _sbId);
        req.AddString(Tags.MsgVer,  VerUseRecp);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgIds.LotUseRecp, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "RecipeChange/LotUseRecp failed. LotId={LotId}", lotId);
            return new RecipeListResult(false, ErrorMessage: $"通信エラー: {ex.Message}");
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = msg.GetErrorInfo();
            logger.LogWarning("RecipeChange/LotUseRecp returned FALSE. LotId={LotId}, Code={Code}",
                lotId, code);
            return new RecipeListResult(false, ErrorCode: code,
                ErrorMessage: string.IsNullOrEmpty(message) ? "レシピ一覧の取得に失敗しました。" : message);
        }

        var ary = msg.GetMsgAry(Tags.RecipeList);
        var items = ary.Select(e => new RecipeItem(
            RecipeId:   e.GetString(Tags.RecipeId),
            RecipeName: e.GetString("RECIPE_NAME"),
            IsDefault:  e.GetString(Tags.DefaultFlag) == "1",
            Comments:   e.GetString(Tags.RecipeComments)
        )).ToList();

        return new RecipeListResult(true, Items: items);
    }

    // ──────── レシピ変更 (lot_.chgrecp_) ─────────────────────────────

    /// <summary>
    /// ロットのレシピを変更する。
    /// VBソース: pubblnLotChgRecp_Upd, MsgVer="01.00"
    /// </summary>
    public async Task<ChangeResult> ChangeRecipeAsync(
        string lotId,
        string opId,
        string stepId,
        string newRecipeId,
        string empId,
        string changeReason,
        string lotLastUpdate,
        CancellationToken ct = default)
    {
        var req = new TfMsg();
        req.AddString(Tags.LotId,         lotId);
        req.AddString(Tags.OpId,          opId);
        req.AddString(Tags.StepId,        stepId);
        req.AddString(Tags.RecipeId,      newRecipeId);
        req.AddString(Tags.EmpId,         empId);
        req.AddString(Tags.Comments,      changeReason);
        req.AddString(Tags.LotLastUpdate, lotLastUpdate);
        req.AddString(Tags.SbId,          _sbId);
        req.AddString(Tags.MsgVer,        VerChgRecp);

        string raw;
        try
        {
            raw = await mq.SendMessageAsync(MsgLotChgRecp, req.ToTfString(), ct);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "LotChgRecp failed. LotId={LotId}", lotId);
            return new ChangeResult(false, ErrorMessage: $"通信エラー: {ex.Message}");
        }

        var msg = TfMsg.ParseOrEmpty(raw);
        if (msg.GetString(Tags.Ret) != Tags.True)
        {
            var (code, message) = msg.GetErrorInfo();
            logger.LogWarning("LotChgRecp returned FALSE. LotId={LotId}, Code={Code}", lotId, code);
            return new ChangeResult(false, ErrorCode: code,
                ErrorMessage: string.IsNullOrEmpty(message) ? "レシピ変更に失敗しました。" : message);
        }

        return new ChangeResult(true);
    }
}
