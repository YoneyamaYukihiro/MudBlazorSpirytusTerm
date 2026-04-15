namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// VBソースの CPstr*** メッセージID定数に対応する。
/// </summary>
public static class MsgIds
{
    public const string LotCurState    = "lot_.curstate";
    public const string LotList        = "lot_.list____";
    public const string UtilRefMenu    = "util.refmenu_";
    public const string UtilInformation = "util.information";
    public const string LotListAld = "lot_.listald_";
    public const string LotChgCtlwp = "lot_.chgctlwp";

    public const string EqState = "eq__.state___";
    public const string EqAreaCurList = "eq__.areacurlist";
    public const string MasMcGroupList = "mas_.mcgrouplist";

    public const string WrkStart = "lot_.wrkstart";
    public const string WrkEnd = "lot_.wrkend__";
    public const string PrcStart = "lot_.prcstart";
    public const string PrcEnd = "lot_.prcend__";

    public const string CarrList = "carr.list____";
    public const string CarrCurState = "carr.curstate";
    public const string CarrManuOutPort = "carr.manuoutport";

    public const string DumyCarOut = "dumy.carout__";

    public const string BatLotList = "bat_.lotlist_";
    public const string BatPrcStart = "bat_.prcstart";
    public const string BatPrcEnd = "bat_.prcend__";

    public const string UtilRefTmInfo = "util.reftminfo";
    public const string UtilRegTmInfo = "util.regtminfo";

    public const string MasStockerList = "mas_.stockerlist";

    // ──────── EN0290 ロット情報変更/削除 ────────
    public const string LotAttribute        = "lot_.attribute";
    public const string LotChgAttribute     = "lot_.chgattribute";
    public const string LotCancelPlan       = "lot_.cancelplan";

    // ──────── EN00F0 在庫管理 ────────
    public const string LotAsmDivide         = "lot_.asmdivide";
    public const string LotHoldList          = "lot_.holdlist";
    public const string InvGetSendOrderList  = "inv_.getsendorderlist";
    public const string InvGetLotExamInfo    = "inv_.getlotexaminfo";
    public const string InvChgComm           = "inv_.chgcomm_";
    public const string InvCfForward         = "inv_.cfforward";
    public const string InvCfLotInfo         = "inv_.cflotinfo";
    public const string InvCfRework          = "inv_.cfrework";
    public const string LotCancelSend        = "lot_.cancelsend";
    public const string LotSend              = "lot_.send____";

    // ──────── EN00O0 ロット投入予約 ────────
    public const string LotThrowRsv          = "lot_.throwrsv";
    public const string LotApprove           = "lot_.approve_";

    // ──────── EN01K0 流動票バージョンアップ ────────
    public const string LotChgTrvList        = "lot_.chgtrvlist";
    public const string LotChgTraveler       = "lot_.chgtraveler";
    public const string LotChgTrvProhibit    = "lot_.chgtrvprohibit";
    public const string LotChkContEtApc      = "lot_.chkContEtApc";

    // ──────── EN01C0 ロット情報詳細 ────────
    public const string LotDetail            = "lot_.detail__";

    // ──────── EN01G0 ロット流動票 ────────
    public const string LotDetailList        = "lot_.detaillist";
    public const string LotEventComment      = "lot_.eventcomment";
    public const string LotUseRecp           = "lot_.userecp_";

    // ──────── EN0270 アクション予約 ────────
    public const string MasStepUsedWpList    = "mas_.stepusedwplist";
    public const string LotTraveler          = "lot_.traveler";
    public const string MasPdTraveler        = "mas_.pdtraveler";
    public const string LotActInfo           = "lot_.actinfo_";
    public const string LotActRsv            = "lot_.actrsv__";
    public const string LotDelAct            = "lot_.delact__";

    // ──────── バッチ作業開始/終了 ────────
    public const string BatStartWrk         = "bat_.startwrk";
    public const string BatEndWrk           = "bat_.endwrk__";

    // ──────── 次工程送出/取得 ────────
    public const string LotNextSend         = "lot_.nextsend";
    public const string LotNextStepList     = "lot_.nextsteplist";

    // ──────── EN0200 工程別ロット一覧 ────────
    public const string LotOpList           = "lot_.oplotlist";
    public const string MasUseOpList        = "mas_.useoplist";
    public const string LotStepList         = "lot_.steplist";
    public const string MasPdList           = "mas_.pdlist__";
    public const string MasFlowList         = "mas_.flowlist";

    // ──────── EN0130 処理開始取消 ────────
    public const string LotCnclWrkStart     = "lot_.cnclwrkstart";

    // ──────── EN02N0 バッチ装置管理 ────────
    public const string BatComposeStatus    = "bat_.composestatus";
    public const string BatRecipeList       = "bat_.recipelist";
    public const string BatComposeRegist    = "bat_.composeregist";
    public const string BatWaitingLotList   = "bat_.waitinglotlist";
    public const string MasWpList           = "mas_.wplist__";

    // ──────── EN00C0 装置モード変更 ────────
    public const string EqChgMode           = "eq__.chgmode_";
    public const string EqEmgChgMode        = "eq__.emgchgmode";
    public const string EqChgTrnStat        = "eq__.chgtrnstat";
    public const string EqChgProcOrder      = "eq__.chgprocorder";
    public const string EqCarUnload         = "eq__.carunload";
    public const string EqChgUse            = "eq__.chguse__";
    public const string EqWpMsgList         = "eq__.wpmsglist";
    public const string EqWpProcessingUse   = "eq__.wpprocessinguse";
    public const string EqChgWpProcessingUse = "eq__.chgwpprocessinguse";
    public const string MasWpUseList         = "mas_.wpuselist";
    public const string MasWpProcessingNameList = "mas_.wpprocessingnamelist";
    public const string MasChamberUseList    = "mas_.chamberuselist";
}
