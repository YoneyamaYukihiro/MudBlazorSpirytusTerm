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
    public const string LimitTime            = "LIMIT_TIME";
    public const string WarnTime             = "WARN_TIME";
    public const string RestrictTypeId       = "RESTRICT_TYPE_ID";

    // ──────── 作業者 ────────
    public const string EmpId                = "EMP_ID";
    public const string EngEmpName           = "ENG_EMP_NAME";

    // ──────── レシピ制御フラグ ────────
    public const string AvailableRecipeFlag  = "AVAILABLE_RECIPE_FLAG";  // 処理可能レシピフラグ(0:可,1:限定)
    public const string FrRecipeFlag         = "FR_RECIPE_FLAG";          // FRレシピ有無フラグ(0:可,1:不可)
    public const string WfPartialRecipeFlag  = "WF_PARTIAL_RECIPE_FLAG"; // 枚葉レシピフラグ(0:全数,1:部分)

    // ──────── キャリア追加 ────────
    public const string CarrierStatId        = "CARRIER_STAT_ID";
    public const string CarrierStatName      = "CARRIER_STAT_NAME";
    public const string CurrentPositionName  = "CURRENT_POSITION_NAME";
    public const string ToCarrierId          = "TO_CARRIER_ID";          // アンロードキャリアID
    public const string DestName             = "DEST_NAME";              // 搬送先位置名

    // ──────── ロット追加 ────────
    public const string DispatchStartTime    = "DISPATCH_START_TIME";
    public const string ReworkFlag           = "REWORK_FLAG";            // 1:リワーク中, 2:追加流動

    // ──────── 装置グループ ────────
    public const string McGroupId            = "MC_GROUP_ID";
    public const string McGroupName          = "MC_GROUP_NAME";
    public const string McGroupList          = "MC_GROUP_LIST";
    public const string BatchFlag            = "BATCH_FLAG";

    // ──────── エリア/装置一覧 ────────
    public const string AreaId               = "AREA_ID";
    public const string AreaEquipmentList    = "AREA_EQUIPMENT_LIST";
    public const string WpName               = "WP_NAME";
    public const string EqType               = "EQ_TYPE";

    // ──────── その他 ────────
    public const string KindFlag             = "KIND_FLAG";
    public const string AltNumber            = "ALT_NUMBER";
    public const string SendSbId             = "SEND_SB_ID";
    public const string VaFlag               = "VA_FLAG";
    public const string SbArea               = "SB_AREA";
    public const string LcDirection          = "LC_DIRECTION";

    // ──────── 端末設定 ────────
    public const string HostName             = "HOST_NAME";
    public const string CurrentWpId          = "CURRENT_WP_ID";
    public const string CarrierTypeId        = "CARRIER_TYPE_ID";
    public const string WpList               = "WP_LIST";

    // ──────── ストッカー ────────
    public const string StockerId            = "STOCKER_ID";
    public const string StockerName          = "STOCKER_NAME";
    public const string StockerList          = "STOCKER_LIST";

    // ──────── 装置状態 (eq__.state___) ────────
    public const string MesModeType          = "MES_MODE_TYPE";
    public const string ModeStatus           = "MODE_STATUS";
    public const string CollectTypeFlag      = "COLLECT_TYPE_FLAG";
    public const string RecipeFlowNum        = "RECIPE_FLOW_NUM";
    public const string WpCancelCarrierFlag  = "WP_CANCEL_CARRIER_FLAG";
    public const string PortList             = "PORT_LIST";
    public const string PortId               = "PORT_ID";
    public const string PortStatus           = "PORT_STATUS";

    // ──────── 作業・処理 ────────
    public const string Comments             = "COMMENTS";
    public const string CfCarrierId          = "CF_CARRIER_ID";
    public const string EqFlag               = "EQ_FLAG";
    public const string ToPortId             = "TO_PORT_ID";
    public const string ActionFlag           = "ACTION_FLAG";

    // ──────── キャリア一覧 ────────
    public const string CarrierList          = "CARRIER_LIST";
    public const string RestrictedSbId       = "RESTRICTED_SB_ID";
    public const string EmptyFlag            = "EMPTY_FLAG";
    public const string StartTime            = "START_TIME";
    public const string CleanFlag            = "CLEAN_FLAG";
    public const string CleanTime            = "CLEAN_TIME";
    public const string TotalUseCount        = "TOTAL_USE_COUNT";
    public const string CleanCount           = "CLEAN_COUNT";
    public const string AfterCleanUseCount   = "AFTER_CLEAN_USE_COUNT";
    public const string SlotSize             = "SLOT_SIZE";

    // ──────── バッチ ────────
    public const string BatchId              = "BATCH_ID";
    public const string BatchList            = "BATCH_LIST";
    public const string VaConditionId        = "VA_CONDITION_ID";
    public const string VaConditionFlag      = "VA_CONDITION_FLAG";
    public const string BLotList             = "B_LOT_LIST";
    public const string LotKind              = "LOT_KIND";
}
