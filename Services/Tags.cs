namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// VBソースの CPstr*** 定数（メッセージタグ名）に相当する。
/// CtsbasxxCM0010.vb の宣言を C# 定数に変換したもの。
/// </summary>
public static class Tags
{
    // ──────── 共通 ────────
    public const string Ret            = "RET";
    public const string MsgVer         = "MSG_VER";
    public const string ErrMsg         = "ERR_MSG";
    public const string Msg            = "MSG";
    public const string MsgCode        = "MSG_CODE";
    public const string MsgNull        = "";          // CPstrMsgNull

    // ──────── 戻り値 ────────
    public const string True           = "0";   // CPstrTRUE
    public const string False          = "1";   // CPstrFALSE

    // ──────── 端末・装置 ────────
    public const string SbId           = "SB_ID";
    public const string WpId           = "WP_ID";
    public const string WpTypeFlag     = "WP_TYPE_FLAG";
    public const string WpStopFlag     = "WP_STOP_FLAG";
    public const string WpStatusName   = "WP_STATUS_NAME";
    public const string McType         = "MC_TYPE";
    public const string UseId          = "USE_ID";
    public const string UseName        = "USE_NAME";
    public const string MesModeId      = "MES_MODE_ID";
    public const string ClassDivision  = "CLASS_DIVISION";

    // ──────── ロット ────────
    public const string LotId          = "LOT_ID";
    public const string LotList        = "LOT_LIST";
    public const string LotHoldFlag    = "LOT_HOLD_FLAG";
    public const string LotStopFlag    = "LOT_STOP_FLAG";
    public const string LotPriority    = "LOT_PRIORITY";
    public const string LotComments    = "LOT_COMMENTS";
    public const string LotCommentsFlag= "LOT_COMMENTS_FLAG";
    public const string LotLastUpdate  = "LOT_LAST_UPDATE";
    public const string LotManagerName = "LOT_MANAGER_NAME";
    public const string NowSt          = "NOW_ST";
    public const string FlowClass      = "FLOW_CLASS";

    // ──────── キャリア ────────
    public const string CarrierId      = "CARRIER_ID";
    public const string CarrierPos     = "CARRIER_POS";
    public const string CarrierStatus  = "CARRIER_STATUS";
    public const string LCarrierId     = "L_CARRIER_ID";
    public const string UCarrierId     = "U_CARRIER_ID";
    public const string ACarrierId     = "A_CARRIER_ID";

    // ──────── 工程 ────────
    public const string OpId           = "OP_ID";
    public const string StepId         = "STEP_ID";
    public const string ToOpId         = "TO_OP_ID";
    public const string ToStepId       = "TO_STEP_ID";

    // ──────── 機種・レシピ ────────
    public const string PdId           = "PD_ID";
    public const string PdVersion      = "PD_VERSION";
    public const string RecipeId       = "RECIPE_ID";

    // ──────── WF ────────
    public const string WfId           = "WF_ID";
    public const string WfNum          = "WF_NUM";
    public const string ChipQuantity   = "CHIP_QUANTITY";

    // ──────── 時間制限 ────────
    public const string LimitTime      = "LIMIT_TIME";
    public const string WarnTime       = "WARN_TIME";
    public const string RestrictTypeId = "RESTRICT_TYPE_ID";

    // ──────── 作業者 ────────
    public const string EmpId          = "EMP_ID";
    public const string EngEmpName     = "ENG_EMP_NAME";

    // ──────── その他 ────────
    public const string KindFlag       = "KIND_FLAG";
    public const string AltNumber      = "ALT_NUMBER";
    public const string SendSbId       = "SEND_SB_ID";
    public const string VaFlag         = "VA_FLAG";
    public const string SbArea         = "SB_AREA";
    public const string LcDirection    = "LC_DIRECTION";
}
