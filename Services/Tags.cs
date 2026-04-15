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
    public const string ErrCode        = "ERR_CODE";
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
    public const string ShipDiffDay          = "SHIP_DIFF_DAY";          // 進捗度 (1A0)

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
    public const string PlaceId              = "PLACE_ID";
    public const string PlaceName            = "PLACE_NAME";
    public const string AldProcessModeId     = "ALD_PROCESS_MODE_ID";
    public const string AldProcessName       = "ALD_PROCESS_NAME";

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

    // ──────── ロット属性 (lot_.attribute / lot_.chgattribute / lot_.cancelplan) ────────
    public const string OrderNum                = "ORDER_NUM";
    public const string GrbClass                = "GRB_CLASS";
    public const string EntryId                 = "ENTRY_ID";
    public const string EntryName               = "ENTRY_NAME";
    public const string SpecialFlag             = "S_FLAG";
    public const string MaxWfCount              = "MAX_WF_COUNT";
    public const string EngEmpId                = "ENG_EMP_ID";
    public const string LotPriorityName         = "LOT_PRIORITY_NAME";
    public const string PrOrderId               = "PR_ORDER_ID";
    public const string LotSendFlag             = "LOT_SEND_FLAG";
    public const string SendSbName              = "SEND_SB_NAME";
    public const string CfFlag                  = "CF_FLAG";
    public const string LpFlag                  = "LP_FLAG";
    public const string DivideFlag              = "DIVIDE_FLAG";
    public const string PlanShipDate            = "PLAN_SHIP_DATE";
    public const string FirstPhotoWpId          = "FIRST_PHOTO_WP_ID";
    public const string FirstPhotoWpName        = "FIRST_PHOTO_WP_NAME";
    public const string PlanThrowinDate         = "PLAN_THROWIN_DATE";
    public const string PlanThrowinQuantity     = "PLAN_THROWIN_QUANTITY";
    public const string PlanAssThrowinDate      = "PLAN_ASSEMBLE_THROWIN_DATE";
    public const string SectionPriorityFlag     = "SECTION_PRIORITY_FLAG";
    public const string AtlasFlowNumber         = "ATLAS_FLOW_NUMBER";
    public const string ScreenSizeId            = "SCREEN_SIZE_ID";
    public const string CfScreenSizeId          = "CF_SCREEN_SIZE_ID";

    // ──────── 装置モード変更 (eq__.chgmode_ / eq__.chguse__ / etc.) ────────
    public const string OldUseId            = "OLD_USE_ID";
    public const string EntryTime           = "ENTRY_TIME";
    public const string MessageId           = "MESSAGE_ID";
    public const string MessageText         = "MESSAGE";           // CPstrMESSAGE
    public const string UseList             = "USE_LIST";
    public const string UseEnableMode       = "USE_ENABLE_MODE";
    public const string UseStopFlag         = "USE_STOP_FLAG";
    public const string NormalStateFlag     = "NORMAL_STATE_FLAG";
    public const string CollectTypeList     = "COLLECT_TYPE_LIST";
    public const string CollectTypeNum      = "COLLECT_TYPE_NUM";
    public const string TransServiceStatus  = "TRANS_SERVICE_STATUS";
    public const string ChamberId           = "CHAMBER_ID";
    public const string ChamberUseId        = "CHAMBER_USE_ID";
    public const string ChamberUseList      = "CHAMBER_USE_LIST";
    public const string ProcessingList      = "PROCESSING_LIST";
    public const string ProcessingName      = "PROCESSING_NAME";
    public const string DispOnFlag          = "DISP_ON_FLAG";
    public const string ProcessingUseList   = "PROCESSING_USE_LIST";
    public const string OldChamberId        = "OLD_CHAMBER_ID";
    public const string OldChamberUseId     = "OLD_CHAMBER_USE_ID";
    public const string EditTime            = "EDIT_TIME";
    public const string MsgList             = "MSG_LIST";
    public const string No                  = "NO";

    // ──────── アクション予約 (mas_.stepusedwplist / lot_.traveler / mas_.pdtraveler / lot_.actinfo_ / lot_.actrsv__ / lot_.delact__) ────────
    public const string WfActionFlag         = "WF_ACTION_FLAG";
    public const string StepList             = "STEP_LIST";
    public const string StepNum              = "STEP_NUM";
    public const string AltStepFlag          = "ALT_STEP_FLAG";
    public const string ReworkStepFlag       = "REWORK_STEP_FLAG";
    public const string ReworkRouteId        = "REWORK_ROUTE_ID";
    public const string SpecialStepFlag      = "SPECIAL_STEP_FLAG";
    public const string SpecialRouteId       = "SPECIAL_ROUTE_ID";
    public const string LotActionTypeId      = "LOT_ACTION_TYPE_ID";
    public const string ItemName             = "ITEM_NAME";
    public const string ActionTrigger        = "ACTION_TRIGGER";
    public const string LotActionId          = "LOT_ACTION_ID";
    public const string WorkDirectionId      = "WORK_DIRECTION_ID";
    public const string StopHoldFlag         = "STOP_HOLD_FLAG";
    public const string HoldReasonId         = "HOLD_REASON_ID";
    public const string EndTime              = "END_TIME";
    public const string HoldComments         = "HOLD_COMMENTS";
    public const string HoldPeriod           = "HOLD_PERIOD";
    public const string HoldEmpId            = "HOLD_EMP_ID";
    public const string HoldEmpName          = "HOLD_EMP_NAME";
    public const string WfList               = "WF_LIST";
    public const string ExecTime             = "EXEC_TIME";

    // ──────── 在庫管理 (lot_.asmdivide / lot_.holdlist / inv_.* / lot_.cancelsend / lot_.send____) ────────
    public const string DivideWfMapList      = "DIVIDE_WF_MAP_LIST";
    public const string DivideWfMapList2     = "DIVIDE_WF_MAP_LIST2";
    public const string SlotPosition         = "SLOT_POSITION";
    public const string DivideLotId1         = "DIVIDE_LOT_ID1";
    public const string DivideLotId2         = "DIVIDE_LOT_ID2";
    public const string ToCarrierId1         = "TO_CARRIER_ID1";
    public const string ToCarrierId2         = "TO_CARRIER_ID2";
    public const string FlowClassId          = "FLOW_CLASS_ID";
    public const string WfQuantity           = "WF_QUANTITY";
    public const string StayTime             = "STAY_TIME";
    public const string RecordTime           = "RECORD_TIME";
    public const string EmpName              = "EMP_NAME";
    public const string ReasonCode           = "REASON_CODE";
    public const string ReasonName           = "REASON_NAME";
    public const string HoldStayDate         = "HOLD_STAY_DATE";
    public const string HoldTermDate         = "HOLD_TERM_DATE";
    public const string SbName               = "SB_NAME";
    public const string AtlasPoint           = "ATLAS_POINT";
    public const string SendAtlasPoint       = "SEND_ATLAS_POINT";
    public const string SendDate             = "SEND_DATE";
    public const string BoxNo                = "BOX_NO";
    public const string ExtPartCode          = "EXT_PART_CODE";
    public const string AtlasOrderNo         = "ATLAS_ORDER_NO";
    public const string InvComments          = "INV_COMMENTS";
    public const string WfThrowinDate        = "WF_THROWIN_DATE";
    public const string WfThrowinQuantity    = "WF_THROWIN_QUANTITY";
    public const string WfFinishDate         = "WF_FINISH_DATE";
    public const string WfFinishQuantity     = "WF_FINISH_QUANTITY";
    public const string WfOutQuantity        = "WF_OUT_QUANTITY";
    public const string WfIssueQuantity      = "WF_ISSUE_QUANTITY";
    public const string ChipThrowinQuantity  = "CHIP_THROWIN_QUANTITY";
    public const string ChipOutQuantity      = "CHIP_OUT_QUANTITY";
    public const string GoodChipRatio        = "GOOD_CHIP_RATIO";
    public const string RegenerationCount    = "REGENERATION_COUNT";
    public const string ThicknessList        = "THICKNESS_LIST";
    public const string ThicknessCode        = "THICKNESS_CODE";
    public const string EventClass           = "EVENT_CLASS";

    // ──────── ロット投入予約 (lot_.throwrsv / lot_.approve_) ────────
    public const string CopySeqLotId         = "COPY_SEQ_LOT_ID";
    public const string MasPdVersion         = "MAS_PD_VERSION";

    // ──────── 流動票バージョンアップ (lot_.chgtrvlist / lot_.chgtraveler / lot_.chgtrvprohibit / lot_.chkContEtApc) ────────
    public const string LotFlowStatusId      = "LOT_FLOW_STATUS_ID";
    public const string PdList               = "PD_LIST";
    public const string FlowClassList        = "FLOW_CLASS_LIST";
    public const string CommitFlag           = "COMMIT_FLAG";
    public const string ProcChangeFlag       = "PROC_CHANGE_FLAG";
    public const string VersionChangeFlag    = "VERSION_CHANGE_FLAG";
    public const string WfRecipeFlag         = "WF_RECIPE_FLAG";
    public const string LotRecipeFlag        = "LOT_RECIPE_FLAG";
    public const string MasEntryId           = "MAS_ENTRY_ID";
    public const string SwapFlag             = "SWAP_FLAG";
    public const string AltFlag              = "ALT_FLAG";
    public const string WfCarryFlag          = "WF_CARRY_FLAG";
    public const string VerUpProhibitedFlag  = "VERUP_PROHIBITED_FLAG";
    public const string ProhibitedEmpName    = "PROHIBITED_EMP_NAME";
    public const string ProhibitedDeptName   = "PROHIBITED_DEPT_NAME";
    public const string ReworkCount          = "REWORK_COUNT";
    public const string SamplingFlag         = "SAMPLING_FLAG";
    public const string Result               = "RESULT";

    // ──────── ロット流動票 (lot_.detaillist / lot_.eventcomment / lot_.userecp_) ────────
    public const string StartSeqNum          = "START_SEQ_NUM";
    public const string BeforeNum            = "BEFORE_NUM";
    public const string AfterNum             = "AFTER_NUM";
    public const string CurrentSeqNum        = "CURRENT_SEQ_NUM";
    public const string HoldFlag             = "HOLD_FLAG";
    public const string LastSeqNum           = "LAST_SEQ_NUM";
    public const string DetailList           = "DETAIL_LIST";
    public const string SeqNum               = "SEQ_NUM";
    public const string CollectionFlag       = "COLLECTION_FLAG";
    public const string ChipNum              = "CHIP_NUM";
    public const string StartEmpName         = "START_EMP_NAME";
    public const string EndEmpName           = "END_EMP_NAME";
    public const string CommentFlag          = "COMMENT_FLAG";
    public const string CommentTime          = "COMMENT_TIME";
    public const string CdenClass            = "CDEN_CLASS";
    public const string PortName             = "PORT_NAME";
    public const string SelectConditionId    = "SELECT_CONDITION_ID";
    public const string HistoryFlag          = "HISTORY_FLAG";
    public const string RecipeList           = "RECIPE_LIST";
    public const string DefaultFlag          = "DEFAULT_FLAG";
    public const string RecipeComments       = "RECIPE_COMMENTS";
    public const string RecipeBodyList       = "RECIPE_BODY_LIST";
    public const string RecipeValue          = "RECIPE_VALUE";
    public const string RecipeItem           = "RECIPE_ITEM";
    public const string ValueType            = "VALUE_TYPE";

    // ──────── バッチ作業開始/終了 ────────
    public const string ResultFlag              = "RESULT_FLAG";

    // ──────── 作業終了/処理開始/処理終了/次工程送出 ────────
    public const string CancelMode              = "CANCEL_MODE";
    public const string DividedCheckFlag        = "DIVIDED_CHECK_FLAG";
    public const string SendResult              = "SEND_RESULT";
    public const string NextStepList            = "NEXT_STEP_LIST";
    public const string NextOpId                = "NEXT_OP_ID";
    public const string NextStepId              = "NEXT_STEP_ID";
    public const string StepDivision            = "STEP_DIVISION";
    public const string ResultReworkState       = "RESULT_REWORK_STATE";
    public const string ElectHoldFlag           = "ELECT_HOLD_FLAG";
    public const string MoveResult              = "MOVE_RESULT";
    public const string TftHoldFlag             = "TFT_HOLD_FLAG";
    public const string ExcpHoldFlag            = "EXCP_HOLD_FLAG";
    public const string NormalHoldFlag          = "NORMAL_HOLD_FLAG";
    public const string TpLotList               = "TP_LOT_LIST";
    public const string TpLotId                 = "TP_LOT_ID";
    public const string PolTime                 = "POL_TIME";
    public const string PlcRecipeCompareResult  = "PLC_RECIPE_COMPARE_RESULT";
    public const string RouteId                 = "ROUTE_ID";

    // ──────── EN0130 処理開始取消（互換） ────────

    // ──────── バッチ ────────
    public const string BatchId              = "BATCH_ID";
    public const string BatchList            = "BATCH_LIST";
    public const string VaConditionId        = "VA_CONDITION_ID";
    public const string VaConditionFlag      = "VA_CONDITION_FLAG";
    public const string BLotList             = "B_LOT_LIST";
    public const string LotKind              = "LOT_KIND";

    // ──────── EN0030 作業開始 (lot_.curstate) ────────
    public const string PdName              = "PD_NAME";
    public const string WorkCondition       = "WORK_CONDITION";
    public const string UnloaderCarrierId   = "UNLOADER_CARRIER_ID";

    // ──────── MN0000 メインメニュー (util.refmenu_ / util.information) ────────
    public const string LoginId             = "LOGIN_ID";
    public const string MenuKind            = "MENU_KIND";
    public const string TakingOverFlag      = "TAKING_OVER_FLAG";
    public const string FavoriteList        = "FAVORITE_LIST";
    public const string FunctionId          = "FUNCTION_ID";
    public const string Information         = "INFORMATION";
    public const string Class               = "CLASS";
}
