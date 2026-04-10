namespace MudBlazorSpirytusTerm.Services;

/// <summary>
/// VBソースの CPstr*** メッセージID定数に相当する。
/// CtsbasxxCM0010.vb の宣言を C# 定数に変換したもの。
/// </summary>
public static class MsgIds
{
    // ──────── ロット ────────
    public const string LotList        = "lot.list____";   // CPstrlot_list____
    public const string LotListAld     = "lot.listald_";   // CPstrlot_listald_
    public const string LotChgCtlwp   = "lot.chgctlwp";   // CPstrlot_chgctlwp

    // ──────── 装置・エリア ────────
    public const string EqState        = "eq__.state___";  // CPstreq__state___
    public const string EqAreaCurList  = "eq__.areacurlist"; // CPstreq__areacurlist
    public const string MasMcGroupList = "mas_.McGrouplist"; // CPstrmas_McGrouplist

    // ──────── 作業 ────────
    public const string WrkStart       = "wrk_.start___";
    public const string WrkEnd         = "wrk_.end_____";
    public const string PrcStart       = "prc_.start___";
    public const string PrcEnd         = "prc_.end_____";

    // ──────── キャリア ────────
    public const string CarrList       = "carr.list____"; // CPstrcarrlist____
    public const string CarrCurState   = "carr.curstate"; // CPstrcarrcurstate
    public const string CarrManuOutPort = "carr.manuoutport"; // CPstrcarrmanuoutport

    // ──────── ダミー ────────
    public const string DumyCarOut     = "dumy.carout__"; // CPstrdumycarout__

    // ──────── バッチ ────────
    public const string BatLotList     = "bat_.lotlist_"; // CPstrbat_lotlist_
    public const string BatPrcStart    = "bat_.prcstart"; // CPstrbat_prcstart
    public const string BatPrcEnd      = "bat_.prcend__"; // CPstrbat_prcend__

    // ──────── ユーティリティ ────────
    public const string UtilRefTmInfo  = "util.reftminfo"; // CPstrutilreftminfo
    public const string UtilRegTmInfo  = "util.regtminfo"; // CPstrutilregtminfo
}
