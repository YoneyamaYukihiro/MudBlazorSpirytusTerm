'ﾌｧｲﾙ名：xxCM0050.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：レシピ設定変更画面　メインフォーム
'作成日：2004/02/27 (Fri) 14:08:55 T.Oide
'更新日：2014/11/21 (Fri) 19:20:17 T.Oide
'備　考：2004/09/21 (Tue) 13:56:15 Y.Yamagishi  ﾚﾁｸﾙ列追加(不具合改善№722)
'　　　：2004/12/14 (Tue) 10:42:30 S.Deguchi    単体起動時のﾚｼﾋﾟ設定対応(不具合改善№321)
'　　　：2005/01/26 (Wed) 13:21:17 N.Kasai      CMP対応
'　　　：2005/11/07 (Mon) 13:45:33 S.Deguchi    ｿｰｽ整備
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM0050
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM0050    ' ただ一つのフォームのインスタンスを保持する変数

    '***************************************************************************************
    '                              * Sharedプロパティの記述 *
    '***************************************************************************************
    '======================================Public===========================================
    ' NSYS 追加
    '関数名：Instance
    '機　能：ただ一つのフォームにアクセスするためのプロパティ
    '作成日：2018/12/05 (Wed)
    '更新日：2018/12/05 (Wed)
    '備　考：
    Public Shared Property Instance() As frmxxCM0050
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM0050
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM0050)
            Dim old_inst As Form
            old_inst = _instance
            _instance = value
            If old_inst IsNot Nothing AndAlso Not old_inst.IsDisposed Then
                old_inst.Close()
                old_inst.Dispose()
            End If
        End Set
    End Property

    
    

    '***************************************************************************************
    '                                    *定数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2020/06/05 (Fri) 11:29:20 T.Oide 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion             As String = "08.01"         '機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion             As String = "08.02"         '機能ﾊﾞｰｼﾞｮﾝ
    '@↑2020/06/05 (Fri) 11:29:20 T.Oide 「.Netへ反映未」 **************************************************

    '@Msgﾊﾞｰｼﾞｮﾝ
    'Private Const CMstrlot_curstateVer          As String = "03.04"         'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer          As String = "04.00"         'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 14:21:08 Y.Yoneyama 「.Netへ反映未」 **************************************************
    '@↓2020/07/01 (Wed) 11:39:36 T.Oide 「.Netへ反映未」 **************************************************
    '@Private Const CMstrlot_recplistVer          As String = "02.04"         'ﾛｯﾄﾚｼﾋﾟﾘｽﾄ取得
    Private Const CMstrlot_recplistVer          As String = "02.05"         'ﾛｯﾄﾚｼﾋﾟﾘｽﾄ取得
    '@↑2020/07/01 (Wed) 11:39:36 T.Oide 「.Netへ反映未」 **************************************************
    Private Const CMstrlot_recpchngVer          As String = "05.00"                     'ﾛｯﾄﾚｼﾋﾟﾘｽﾄ変更
    Private Const CMstrlot_waferlistVer         As String = "02.05"                     'ﾛｯﾄWF情報取得(新)
    Private Const CMstrlot_wplist__Ver          As String = "02.05"                     'ﾛｯﾄ装置情報取得
    '@↓2012/04/23 (Mon) 12:42:37 Y.Yoneyama **************************************************
    'Private Const CMstrutilreftminfoVer         As String = "03.00"                    '端末設定情報取得
    Private Const CMstrutilreftminfoVer         As String = "04.00"                     '端末設定情報取得
    '@↑2012/04/23 (Mon) 12:42:37 Y.Yoneyama **************************************************
    Private ReadOnly vbButtonFace               As Color = SystemColors.ControlLight    'NSYS vbButtonFace定義
    Private ReadOnly vbWindowBackground         As Color = SystemColors.Window          'NSYS vbWindowBackground定義
    
    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN00S0  'ﾛｰｶﾙ機能ID

    '@vsfRecpの定数宣言(ｶﾗﾑ)
    '@↓2020/01/07 (Tue) 14:57:16 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMlngvsfRecpNo                As Integer = 0                 '№
    'Private Const CMlngvsfRecpWFID              As Integer = 1                 'WFID
    'Private Const CMlngvsfRecpRecpID            As Integer = 2                 'ﾚｼﾋﾟID
    'Private Const CMlngvsfRecpItem              As Integer = 3                 'ﾚｼﾋﾟｱｲﾃﾑ
    'Private Const CMlngvsfRecpValue             As Integer = 4                 'ﾚﾁｸﾙ列(ﾚｼﾋﾟ値)
    'Private Const CMlngvsfRecpVariable          As Integer = 5                 'ﾚｼﾋﾟ値変更可否(0:不可　1:可)
    'Private Const CMlngvsfRecptype              As Integer = 6                 'ﾃﾞｰﾀﾀｲﾌﾟ　A:文字ﾀｲﾌﾟ N:数字ﾀｲﾌﾟ
    'Private Const CMlngvsfRecpDigit             As Integer = 7                 '小数点以下制御
    'Private Const CMlngvsfRecpEdit              As Integer = 8                 '編集ﾌﾗｸﾞ列(WF良品、不良を判定)
    'Private Const CMlngvsfRecpComment           As Integer = 9                 'ﾚｼﾋﾟｺﾒﾝﾄ
    Private Const CMlngvsfRecpNo                As Integer = 0                 '№
    Private Const CMlngvsfRecpWFID              As Integer = 1                 'WFID
    '@↓2020/05/20 (Wed) 18:02:26 T.Oide 「.Netへ反映未」 **************************************************
    Private Const CMlngvsfRecpGRB               As Integer = 3                 'GRB        緊急対応
    Private Const CMlngvsfRecpRecpID            As Integer = 2                 'ﾚｼﾋﾟID     緊急対応
    '@↑2020/05/20 (Wed) 18:02:26 T.Oide 「.Netへ反映未」 **************************************************
    Private Const CMlngvsfRecpItem              As Integer = 4                 'ﾚｼﾋﾟｱｲﾃﾑ
    Private Const CMlngvsfRecpValue             As Integer = 5                 'ﾚﾁｸﾙ列(ﾚｼﾋﾟ値)
    Private Const CMlngvsfRecpVariable          As Integer = 6                 'ﾚｼﾋﾟ値変更可否(0:不可　1:可)
    Private Const CMlngvsfRecptype              As Integer = 7                 'ﾃﾞｰﾀﾀｲﾌﾟ　A:文字ﾀｲﾌﾟ N:数字ﾀｲﾌﾟ
    Private Const CMlngvsfRecpDigit             As Integer = 8                 '小数点以下制御
    Private Const CMlngvsfRecpEdit              As Integer = 9                 '編集ﾌﾗｸﾞ列(WF良品、不良を判定)
    Private Const CMlngvsfRecpComment           As Integer = 10                'ﾚｼﾋﾟｺﾒﾝﾄ
    '@↑2020/01/07 (Tue) 14:57:16 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@vsfRecpの定数宣言(表示幅)
    Private Const CMlngvsfRecpWNo               As Integer = 47                '№
    Private Const CMlngvsfRecpWWFID             As Integer = 144               'WFID
    '@↓2020/01/07 (Tue) 14:58:15 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngvsfRecpWGRB              As Integer = 50                'GRB
    '@↑2020/01/07 (Tue) 14:58:15 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngvsfRecpWRecpID           As Integer = 144               'ﾚｼﾋﾟID
    Private Const CMlngvsfRecpWItem             As Integer = 144               'ﾚｼﾋﾟｱｲﾃﾑ
    Private Const CMlngvsfRecpWValue            As Integer = 144               'ﾚﾁｸﾙ列(ﾚｼﾋﾟ値)
    Private Const CMlngvsfRecpWVariable         As Integer = 67                'ﾚｼﾋﾟ値変更可否
    Private Const CMlngvsfRecpWtype             As Integer = 67                'ﾃﾞｰﾀﾀｲﾌﾟ
    Private Const CMlngvsfRecpWDigit            As Integer = 67                '小数点以下制御
    Private Const CMlngvsfRecpWEdit             As Integer = 67                '編集ﾌﾗｸﾞ列
    Private Const CMlngvsfRecpWComment          As Integer = 144               'ﾚｼﾋﾟｺﾒﾝﾄ

    '@vsfRecpの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfRecpTNo               As String = "№"
    Private Const CMstrvsfRecpTWFID             As String = "WFID"
    '@↓2020/01/07 (Tue) 14:58:58 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrvsfRecpTGRB              As String = "GRB"
    '@↑2020/01/07 (Tue) 14:58:58 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrvsfRecpTRecipeID         As String = "レシピID"
    Private Const CMstrvsfRecpTItem             As String = "ﾚｼﾋﾟﾊﾟﾗﾒｰﾀ"
    Private Const CMstrvsfRecpTValue            As String = "ﾚｼﾋﾟﾊﾟﾗﾒｰﾀ値"
    Private Const CMstrvsfRecpTVariable         As String = "可否F"
    Private Const CMstrvsfRecpTtype             As String = "入力F"
    Private Const CMstrvsfRecpTDigit            As String = "小数点"
    Private Const CMstrvsfRecpTEdit             As String = "編集F"
    Private Const CMstrvsfRecpTComment          As String = "レシピコメント"

    '@vsfRecpの定数宣言(その他)
    Private Const CMlngvsfTopRow                As Integer = 1                 '画面の一番上の行(WF№25の行)
    Private Const CMlngvsfBottomRow             As Integer = 25                '画面の一番下の行(WF№01の行)
    Private Const CMlngvsfRecpTitle             As Integer = 0                 'ﾀｲﾄﾙ行(Recp)
    '@↓2020/01/07 (Tue) 15:00:47 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMlngvsfRecpCols              As Integer = 10                '列数(Recp)
    Private Const CMlngvsfRecpCols              As Integer = 11                '列数(Recp)
    '@↑2020/01/07 (Tue) 15:00:47 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngvsfRecpPageRows          As Integer = 5                 '1頁の行数(Recp)
    Private Const CMlngvsfRecpRows              As Integer = 26                'ｸﾞﾘｯﾄﾞ行数
    Private Const CMlngvsfRecpCmbWidth          As Integer = 17                'ﾚｼﾋﾟｺﾝﾎﾞの▼幅
    Private Const CMvsfRecpHeight               As Integer = 31                '行高さ(ﾚｼﾋﾟｽﾍﾟｼｬﾙ値)
    Private Const CMvsfRecpComboHeight          As Integer = 21                'NSYS ﾚｼﾋﾟｺﾝﾎﾞの行高さ

    '@vsfWPの定数宣言(ｶﾗﾑ)
    Private Const CMvsfWPColNo                  As Integer = 0                 '№
    Private Const CMvsfWPColOpID                As Integer = 1                 '大工程
    Private Const CMvsfWPColStepID              As Integer = 2                 '小工程
    Private Const CMvsfWPColDefault             As Integer = 3                 'ﾃﾞﾌｫﾙﾄ小工程
    Private Const CMvsfWPColWpName              As Integer = 4                 '装置
    Private Const CMvsfWPColWpID                As Integer = 5                 '装置ID(WPID)
    Private Const CMvsfWPColAltNumber           As Integer = 6                 '代替番号
    Private Const CMvsfWPColEqType              As Integer = 7                 '装置ﾀｲﾌﾟ
    Private Const CMvsfWPColRecpList            As Integer = 8                 'ｺﾝﾎﾞのﾚｼﾋﾟﾘｽﾄ
    Private Const CMvsfWPColRecpListCnt         As Integer = 9                 'ｺﾝﾎﾞのﾚｼﾋﾟﾘｽﾄ件数
    Private Const CMvsfWPColLotRecipeFlag       As Integer = 10                'ﾛｯﾄﾚｼﾋﾟ設定ﾌﾗｸﾞ(0：枚葉可,1：枚葉不可)
    Private Const CMvsfWPColLoaderUnloaderFlag  As Integer = 11                'Loader/Unloaderﾌﾗｸﾞ(0：Uni,1：Loader/Unloader)

    '@vsfWPの定数宣言(表示幅)
    Private Const CMvsfWPColWNo                 As Integer = 33               '№
    Private Const CMvsfWPColWOpID               As Integer = 189              '大工程
    Private Const CMvsfWPColWStepID             As Integer = 189              '小工程
    Private Const CMvsfWPColWDefault            As Integer = 67               'ﾃﾞﾌｫﾙﾄ小工程
    Private Const CMvsfWPColWWpName             As Integer = 189              '装置
    Private Const CMvsfWPColWWpID               As Integer = 33               '装置ID
    Private Const CMvsfWPColWAltNumber          As Integer = 20               '代替番号
    Private Const CMvsfWPColWEqType             As Integer = 20               '装置ﾀｲﾌﾟ
    Private Const CMvsfWPColWRecpList           As Integer = 267              'ｺﾝﾎﾞのﾚｼﾋﾟﾘｽﾄ
    Private Const CMvsfWPColWRecpListCnt        As Integer = 20               'ｺﾝﾎﾞのﾚｼﾋﾟﾘｽﾄ件数
    Private Const CMvsfWPColWLotRecipeFlag      As Integer = 20               'ﾛｯﾄﾚｼﾋﾟ設定ﾌﾗｸﾞ(0：枚葉可,1：枚葉不可)
    Private Const CMvsfWPColWLoaderUnloaderFlag As Integer = 20               'Loader/Unloaderﾌﾗｸﾞ(0：Uni,1：Loader/Unloader)
                                                              
    '@vsfWPの定数宣言(ﾀｲﾄﾙ)
    Private Const CMvsfWPColTNo                 As String = "№"
    Private Const CMvsfWPColTOpID               As String = "大工程"
    Private Const CMvsfWPColTStepID             As String = "小工程"
    Private Const CMvsfWPColTDefault            As String = "ﾃﾞﾌｫﾙﾄ"
    Private Const CMvsfWPColTWpName             As String = "装置名"
    Private Const CMvsfWPColTWpID               As String = "WPID"
    Private Const CMvsfWPColTAltNumber          As String = "代替"
    Private Const CMvsfWPColTEqType             As String = "EQTYPE"
    Private Const CMvsfWPColTRecpList           As String = "ﾚｼﾋﾟﾘｽﾄ"
    Private Const CMvsfWPColTRecpListCnt        As String = "ﾚｼﾋﾟﾘｽﾄｶｳﾝﾄ"
    Private Const CMvsfWPColTLotRecipeFlag      As String = "ﾛｯﾄﾚｼﾋﾟ設定ﾌﾗｸﾞ"
    Private Const CMvsfWPColTLoaderUnloaderFlag As String = "Loader/Unloaderﾌﾗｸﾞ"

    '@vsfWPの定数宣言(その他)
    Private Const CMvsfWPCols                   As Integer = 12                'ｶﾗﾑ数
    Private Const CMvsfWPRows                   As Integer = 3                 '行数
    Private Const CMvsfWPTitleRow               As Integer = 0                 'ﾀｲﾄﾙ行

    '@ﾌﾗｸﾞ関連
    Private Const CMlngEditFlg                  As String = "1"             '編集ﾌﾗｸﾞ(1：編集不可)
    Private Const CMlngVariableFlg              As String = "1"             '入力可否ﾌﾗｸﾞ(1：編集可)
    Private Const CMstrOriginalRecpFlag0        As String = "0"             '0：設定なし(ﾃﾞﾌｫﾙﾄ)
    Private Const CMstrOriginalRecpFlag1        As String = "1"             '1：個別ﾚｼﾋﾟ
    Private Const CMstrStepdivisionDefault      As String = "1"             '工程ﾌﾗｸﾞ(1：ﾃﾞﾌｫﾙﾄ工程)
    Private Const CMlngLotRecp                  As Integer = 0                 'ﾛｯﾄﾚｼﾋﾟ
    Private Const CMlngWFRecp                   As Integer = 1                 '枚葉ﾚｼﾋﾟ
    Private Const CMlngVsfInit                  As Integer = 9                 'ｸﾞﾘｯﾄﾞ初期化

    '@ﾕｰｻﾞｰ選択ﾌﾗｸﾞ比較用(測定条件設定されているとき)
    Private Const CMstrUserSelectFlag0          As String = "0"             'ﾚｼﾋﾟ変更不可
    Private Const CMstrUserSelectFlag1          As String = "1"             'ﾚｼﾋﾟ変更可

    '@工順変更ﾚｼﾋﾟﾌﾗｸﾞ用
    Private Const CMstrProcChangeRecipeFlag0    As String = "0"             '0：ﾚｼﾋﾟ設定可
    Private Const CMstrProcChangeRecipeFlag1    As String = "1"             '1：ﾚｼﾋﾟ設定不可

    '@CMP対応定数(文字ﾌｫｰﾏｯﾄ)
    Private Const CMstrDataTypeA                As String = "A"             '文字ﾃﾞｰﾀﾀｲﾌﾟ
    Private Const CMstrDataTypeN                As String = "N"             '数字ﾃﾞｰﾀﾀｲﾌﾟ
    Private Const CMlngInputNDataMaxByte        As Integer = 10                '文字入力の最大ﾊﾞｲﾄ数(数値)
    Private Const CMlngInputADataMaxByte        As Integer = 40                '文字入力の最大ﾊﾞｲﾄ数(文字)

    '@ｸﾞﾘｯﾄﾞの設定(共通)
    Private Const CMlngvsfTitleRowHeight        As Integer = 27                'ﾀｲﾄﾙ行高さ
    Private Const CMlngvsfRowHeight             As Integer = 45                '1ｽﾛｯﾄの高さ
    Private Const CMlngvsfFontSize              As Single  = 15.75             'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfTitleFontSize         As Integer = 12                'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfTitleBackColor        As Integer = &H800000          'NSYS ﾀｲﾄﾙの背景色
    Private Const CMlngvsfTitleForeColor        As Integer = &HFFFF&           'NSYS ﾀｲﾄﾙの文字色

    '@ﾛｯﾄﾚｼﾋﾟﾘｽﾄ取得用
    Private Const CMlngEqFlag                   As Integer = 0                 '装置ﾌﾗｸﾞ
    Private Const CMlngRecipeCnt                As Integer = 1                 'ﾚｼﾋﾟ件数
    Private Const CMlngDefaultRecipe            As Integer = 1                 'ﾃﾞﾌｫﾙﾄﾚｼﾋﾟ表示用
    Private Const CMstrLotRecipeFlag0           As String = "0"             'ﾛｯﾄﾚｼﾋﾟ設定ﾌﾗｸﾞ(枚葉可能)
    Private Const CMstrLotRecipeFlag1           As String = "1"             'ﾛｯﾄﾚｼﾋﾟ設定ﾌﾗｸﾞ(枚葉不可)

    '@ﾚｼﾋﾟ設定ﾗﾍﾞﾙ用
    Private Const CMstrDefaultRecipe            As String = "デフォルト"
    Private Const CMstrOriginalRecipe           As String = "個別レシピ"
    Private Const CMstrNgChgRecipe              As String = "工順変更設定済み"
    Private Const CMstrNoneRecipe               As String = "レシピ無し"

    '@横ｽｸﾛｰﾙ用
    Private Const CMlngSideScrollOnFlag         As Integer = 1                 '横ｽｸﾛｰﾙ活性化
    Private Const CMlngSideScrollOffFlag        As Integer = 2                 '横ｽｸﾛｰﾙ非活性化
    Private Const CMstrSlotNo10                 As String = "10"            'ｽﾛｯﾄ№10
    Private Const CMstrSlotNo16                 As String = "16"            'ｽﾛｯﾄ№16

    '@ｸﾞﾘｯﾄﾞｺﾝﾎﾞ
    Private Const CMstrLine                     As String = "|"             'ｸﾞﾘｯﾄﾞｺﾝﾎﾞ区切り用
    Private Const CMstrIdChr                    As String = ";"             'ｸﾞﾘｯﾄﾞｺﾝﾎﾞID文字区切り用
    Private Const CMstrNoInputString            As String = "'"             '禁則文字："'"
    Private Const CMstrDefault                  As String = "○"            '小工程ﾃﾞﾌｫﾙﾄﾏｰｸ

    '@ﾚｽﾎﾟﾝｽ関数用
    Private Const CMstrWpRowColChange           As String = "vsfWP_AfterRowColChange"   'ｲﾍﾞﾝﾄ名称(WPｸﾞﾘｯﾄﾞ変更)
    Private Const CMstrCarrierValidate          As String = "txtCarrier_Validate"       'ｲﾍﾞﾝﾄ名称(ｷｬﾘｱ変更)
    Private Const CMstrKakuteiClick             As String = "cmdKakutei_Click"          'ｲﾍﾞﾝﾄ名称(確定ﾎﾞﾀﾝ)
    Private Const CMstrCancelClick              As String = "cmdCancel_Click"           'ｲﾍﾞﾝﾄ名称(個別ﾚｼﾋﾟ取消ﾎﾞﾀﾝ)

    '@ﾃｷｽﾄ
    Private Const CMlngMaxDispRow               As Integer = 3                 'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(WF廃棄)


    '@↓2008/06/30 (Mon) 16:06:13 M.Koni **************************************************
    '@ｶﾗｰ(専属装置以外は青、それ以外は赤)
    Private Const CMlngRedColor                 As Integer = &HFF          '赤色
    '@↑2008/06/30 (Mon) 16:06:13 M.Koni **************************************************


    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mstrLotLastUpdate                   As String               'ﾛｯﾄ最終更新日時
    Private mstrAltNumber                       As String               '代替番号
    Private mlngClassRecp                       As Integer              '初期ﾚｼﾋﾟ(0：ﾛｯﾄﾚｼﾋﾟ、1：枚葉ﾚｼﾋﾟ)
    Private mlngSlotMapRowS                     As Integer              'ｸﾞﾘｯﾄﾞ行数
    Private mblnFirstLoadFlg                    As Boolean              'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True:読込み済み、False:初回)
    Private mstrCarrier                         As String               'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mstrProcChangeRecipeFlag            As String               '工順変更ﾚｼﾋﾟﾌﾗｸﾞ(0：ﾚｼﾋﾟ変更可、1:ﾚｼﾋﾟ変更不可)
    Private mstrChgRecpBefore                   As String               'ﾚｼﾋﾟ変更前格納用
    Private mstrChgRecpAfter                    As String               'ﾚｼﾋﾟ変更後格納用
    Private mlngSideScrollFlag                  As Integer              '横ｽｸﾛｰﾙの使用ﾌﾗｸﾞ(1:発生/2:不要)
    Private mlngLotRecpListCnt                  As Integer              'ﾚｼﾋﾟﾘｽﾄｶｳﾝﾄ
    Private mblnChgRecpFlag                     As Boolean              'ﾚｼﾋﾟ変更ﾌﾗｸﾞ(True：変更可、False：変更不可)
    Private mstrUserSelectFlag                  As String               'ﾕｰｻﾞｰ選択ﾌﾗｸﾞ(0：変更不可、1：変更可)
    Private mtypChgSort                         As ChgSort              'ｿｰﾄ保持用
    Private buttonProcessing                    As Boolean              'NSYS ボタン2度押し対策   
    Private mblnCloseFromControlMenu            As Boolean              'NSYS システムコマンドでの画面クローズ    
    Private mblnWindowClose As Boolean              'NSYS WindowCloseフラグ
    Private EditorFlg As Boolean              'NSYS レシピパラメータ値入力フラグ
    Private EditorText As String  'NSYS 前回入力した値

    '***************************************************************************************
    '                              * コンストラクタの記述 *
    '***************************************************************************************
    '======================================Public===========================================
    ' NSYS 追加
    '関数名：New
    '機　能：コンストラクタ
    '引　数：なし
    '戻り値：なし
    '作成日：2018/12/03 (Mon)
    '更新日：2018/12/03 (Mon)
    '備　考：
    Public Sub New()
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        Form_Load()
        
        'NSYS スクロールバーなしグリッドのマウスホイール対応
        pubVsfMouseWheelManager_Set(vsfRecp, cmdVsfUp, cmdVsfDown,cmdLeft,cmdRight)
        pubVsfMouseWheelManager_Set(vsfWP, cmdUp, cmdDown)
        

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************

    '関数名：Form_Load
    '機　能：画面の初期化、ﾚｼﾋﾟ取得・表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/04 (Thu) 12:44:49 T.Oide
    '更新日：2005/02/18 (Fri) 09:37:14 N.Kasai
    '備　考：
    '　　　：2004/12/14 (Tue) 10:41:42 S.Deguchi    画面初期表示に引数(=False)を設定(単独起動の場合のみ機能ﾊﾞｰｼﾞｮﾝﾁｪｯｸを動かすように修正)
    '　　　：2005/02/18 (Fri) 09:37:14 N.Kasai      作業開始から連動した場合WF情報が未設定でも画面を起動する(№510)
    '　　　：2005/10/25 (Tue) 17:11:59 S.Deguchi    起動処理で引継の場合には,CARRIER_VALIDATEﾌﾗｸﾞ(pblnfrmxxCM0050CVFlag)を処理済の状態とする処理を追加
    Private Sub Form_Load()
        
        Dim lblnAns             As Boolean      '戻り値
        
        Try
            
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
             Me.CancelButton = Nothing 
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN00S0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
        '@↓2005/10/25 (Tue) 17:07:47 S.Deguchi **************************************************
                '@引継起動による処理分岐
                If pblnfrmxxCM0050Kbn = False Then
                    '@特殊処理：起動失敗の場合には,明示的にﾌﾗｸﾞを立てる
                    pblnfrmxxCM0050CVFlag = True
                End If
        '@↑2005/10/25 (Tue) 17:07:47 S.Deguchi **************************************************
                
                Exit Sub
            End If
            
            cmdMemoUp.Enabled = False               '前頁ﾎﾞﾀﾝ
            cmdMemoDown.Enabled = False             '次頁ﾎﾞﾀﾝ
            
            '@ﾒｲﾝﾌｫｰﾑの初期化
            Call frmxxCM0050_Init(False)
            
            '@WPｸﾞﾘｯﾄﾞ初期化
            Call prvvsfWP_init()
            
            '@Recipｸﾞﾘｯﾄﾞ初期化
            Call prvvsfRecp_Init(CMlngVsfInit)
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
            
            '@'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True:読込み済み、False:初回)
            mblnFirstLoadFlg = False

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "Form_Load"              '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑｱｸﾃｨﾌﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/05 (Thu) 14:24:29 M.Miura
    '更新日：2008/07/02 (Wed) 09:49:20 M.Koni
    '備　考：2004/09/26 (Sun) 15:58:33 T.Kitagawa   装置別ﾛｯﾄ一覧にて装置指定した場合にﾚｼﾋﾟにﾌｫｰｶｽ設定(不具合№675)
    '　　　：2008/07/02 (Wed) 08:45:01 M.Koni       ﾃﾞﾌｫﾙﾄ端末外の色変え処理追加<案件No.03006>
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        
        Try

            '@ｴﾗｰ発生箇所の初期化
            ptypOnErrorInfo.strErrPositionDetail = vbNullString

            Dim lstrWP  As String   '大小工程+装置
            Dim llngCnt As Integer  'ｶｳﾝﾄ

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True:読込み済み、False:初回)
            '@FormLoad後、最初の1回しか処理しない
            If mblnFirstLoadFlg = True Then
                '@引継ぎ情報が表示済みの場合
                Exit Sub
            End If
           
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True:読込み済み、False:初回)
            mblnFirstLoadFlg = True
            
            '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
            pblnfrmxxCM0050CVFlag = True

            '@---------------------------------------------------------------------
            '@親画面から起動された場合(作業開始、処理開始連動)
            '@---------------------------------------------------------------------
            If pblnfrmxxCM0050Kbn = True Then
                '@-----------------------------------------------------------------
                '@WP情報判定
                '@測定装置で測定可能なWFがない場合は当画面で設定する。
                '@pblnWpIDNullFlagは作業開始画面より連動するﾌﾗｸﾞ(True:WP_ID=NULL)
                '@作業開始→ﾚｼﾋﾟ変更画面で使用(True:WP_ID=NULL)
                '@-----------------------------------------------------------------
                If pblnWpIDNullFlag = True Then
                    '@ｷｬﾘｱ情報取得
                    Call frmxxCM0050_Disp(pblnWpIDNullFlag)
                    
                    '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ使用不可
                    optRecp0.Enabled = False
                    optRecp1.Enabled = False
                    
                    '@装置情報取得
                    Call prvvsfWP_Disp(ptypLotprestate)
                Else
                    '@ｷｬﾘｱ情報表示
                    Call frmxxCM0050_Disp(false)
                End If
            
                With vsfRecp
                    '@有効な場合
                    If .Enabled = True Then
                        '@ｽﾛｯﾄﾏｯﾌﾟの初期表示位置設定
                        Call prvVsfSlotMapTopRow_Set()
                    End If
                End With
                
                '@WP_IDが１件の場合
                With vsfWp
                    If .Rows.Count = 2 Then
                        '@1行目をｾﾚｸﾄ
                        .Select(1, CMvsfWPColOpID)
                    End If
                End With

        '@↓2008/07/02 (Wed) 09:48:57 M.Koni **************************************************
                '@ﾃﾞﾌｫﾙﾄ端末で無ければ色を変える
                Call prvColorChang_CM0050()
        '@↑2008/07/02 (Wed) 09:48:57 M.Koni **************************************************
            
            Else
                '@------------------------------------------------------------------------
                '@親画面から起動された場合(装置別ロット、装置グループ別、工程別ロット一覧連動)
                '@引数のｷｬﾘｱIDが空白かどうか判定する
                '@------------------------------------------------------------------------
                If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@空白でない場合
                    '@ｷｬﾘｱIDの初期値を設定する
                    txtCarrier.Text = ptypCommonInfo.strCarrierId
                    '@ｷｬﾘｱ情報を取得する
                    RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate 
                    Call txtCarrier_Validate(me,New CancelEventArgs)
                    AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate 
                    
                    With vsfWp
                        '@ﾃﾞｰﾀ行がある場合
                        If .Rows.Count > .Rows.Fixed Then
                            '@装置がなくなるまで
                            For llngCnt = .Rows.Fixed To .Rows.Count - 1
                                '@比較用初期化
                                lstrWP = vbNullString
                                '@比較用退避
                                lstrWP = lstrWP & .GetData(llngCnt, CMvsfWPColOpID)    '大工程
                                lstrWP = lstrWP & .GetData(llngCnt, CMvsfWPColStepID)  '小工程
                                lstrWP = lstrWP & .GetData(llngCnt, CMvsfWPColWpID)    '装置ID
                                '@大小工程+装置IDが同じ場合
                                If lstrWP = ptypCommonInfo.strOpID & ptypCommonInfo.strStepID & ptypCommonInfo.strWpID Then
                                    '@ｶﾚﾝﾄ行設定
                                    .Row = llngCnt
                                    .Col = CMvsfWPColNo
                                    
                                    '@選択した行を表示する
                                    Call pubVsfBeforeSort(vsfWp, CMvsfWPColOpID & vbTab & CMvsfWPColStepID & vbTab & CMvsfWPColWpID)
                                    Call pubVsfAfterSort(vsfWp, CMvsfWPColOpID & vbTab & CMvsfWPColStepID & vbTab & CMvsfWPColWpID, cmdUP, cmdDown)
                                    
                                    '@有効な場合
                                    If vsfRecp.Enabled = True Then
                                        '@----------------------------------------------------------------------------
                                        '@ｾｯﾄﾌｫｰｶｽ対応
                                        '@  通信や描画に負荷が掛かった場合を考慮してﾌｫｰｶｽを当てるﾀｲﾐﾝｸﾞを遅らす。
                                        '@　ﾌｫｰｶｽを当てる場所が複数存在する場合は変数で制御する。(mlngSetFocusFlag)
                                        '@　ｾｯﾄﾌｫｰｶｽはﾀｲﾏｰｲﾍﾞﾝﾄに記述
                                        '@-----------------------------------------------------------------------------
                                        
                                        '@ｴﾗｰ位置詳細情報の設定
                                        ptypOnErrorInfo.strErrPositionDetail = "Form_Activate/vsfRecp"
                                        
                                        '@ﾌｫｰｶｽｾｯﾄ
                                        Call pubSetFocus(vsfRecp)
                                        
                                        '@ｴﾗｰ位置詳細情報のｸﾘｱ
                                        ptypOnErrorInfo.strErrPositionDetail = vbNullString
                                    End If
                                    
                                    Exit For
                                End If
                            Next llngCnt
                        End If
                    End With
                Else
                    '@ｷｬﾘｱID初期化
                    ptypCommonInfo.strCarrierId = vbNullString
                End If
            End If
            
            'NSYS Activate中にpublngMsgBox等で別ウィンドウを表示するとActivateがキャンセルされるため、再Activateする
            'NSYS Activateイベント中にActivate()を呼び出しても作用しないため、遅延で実行する。ラムダ式使用
            Dim lfuncActivate As Action = Sub()
                                              Me.Activate()
                                          End Sub
            Me.BeginInvoke(lfuncActivate)

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = cmdClose  
            
            Exit Sub
            
        Catch ex As Exception
            
            '@Escﾎﾞﾀﾝを無効解除
            Me.CancelButton = cmdClose
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "Form_Activate"          '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：画面を閉じる
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 16:11:26 T.Oide
    '更新日：2007/07/13 (Fri) 13:47:42 N.Kasai
    '備　考：2005/03/07 (Mon) 09:20:47 N.Kojima     戻り先画面の判定を追加(改善№512)
    '　　　：2007/07/13 (Fri) 13:47:42 N.Kasai      親画面引継ぎを共通化
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        
        Dim ltypCommonInfoDummy     As CommonInfo   'ﾀﾞﾐｰ構造体
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
                                
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True:読込み済み、False:初回)
            If mblnFirstLoadFlg = False Then
                Exit Sub
            End If
            
            '@親ﾌｫｰﾑから呼ばれた場合
            If pblnfrmxxCM0050Kbn = True Then
                '@ｻﾌﾞ画面確定ﾌﾗｸﾞ(閉じる)
                pblnSubDecision = False
                
                '@ｱﾝﾛｰﾄﾞ
                Me.Close()
            Else
                '@引継ぎ情報のｷｬﾘｱIDが空白かどうか判定する
                If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@空白でない場合
                    '@親ﾌｫｰﾑから呼ばれた場合
                    '@親画面切り替え引継ぎ制御
                    Call pubChangeScreen_Set(Me)
                Else
                '@空白の場合
                    '@終了関数を実行する
                    Call publngEnd_Proc(CPstrKeyEN00S0, ltypCommonInfoDummy)
                End If
            End If
         
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdClose_Click"         '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
         
        End Try
    End Sub

    '関数名：cmdKakutei_Click
    '機　能：変更したWF毎のﾚｼﾋﾟを送信する
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/05 (Fri) 09:55:53 T.Oide
    '更新日：2007/08/27 (Mon) 19:29:01 N.Kasai
    '備　考：2004/09/22 (Wed) 15:38:44 Y.Yamagishi　ﾚﾁｸﾙ行追加(不具合改善№722)
    '　　　：2005/01/26 (Wed) 15:03:59 N.Kasai      CMP対応(不具合№304)
    '　　　：2005/02/07 (Mon) 17:02:58 N.Kasai      CMP対応(不具合№304)ﾚｼﾋﾟﾊﾟﾗﾒｰﾀ値必須ﾁｪｯｸを追加
    '　　　：2006/11/29 (Wed) 18:33:22 T.Kitagawa　 PR/ESﾛｯﾄの権限(案件№01067)、ﾊﾟｽﾜｰﾄﾞ確認機能追加(案件№01581)
    '　　　：2006/12/12 (Tue) 08:36:39 T.Kitagawa　 PR/ESﾛｯﾄの権限(案件№01067)ﾁｪｯｸについては、ﾕｰｻﾞｰ選択ﾌﾗｸﾞがON("1")以外の場合のみとする
    '　　　：2007/08/27 (Mon) 19:29:01 N.Kasai      №02141
    Private Sub cmdKakutei_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdKakutei.Click

        Dim lblnAns             As Boolean      'ﾚｼﾋﾟ変更結果格納
        Dim llngCnt             As Integer      'ｸﾞﾘｯﾄﾞのｶｳﾝﾀ
        Dim llngListCnt         As Integer      'ﾚｼﾋﾟのｶｳﾝﾀ
        Dim ltypRecpChng        As LotRecpChng  'ﾚｼﾋﾟﾁｪﾝｼﾞﾃﾞｰﾀ格納用
        Dim lstrMsg             As String       '変換後ﾒｯｾｰｼﾞ
        Dim lstrWpId            As String       '装置ID
        Dim lstrAltNumber       As String       '代替番号
        Dim llngCnt2            As Integer      'ｸﾞﾘｯﾄﾞのｶｳﾝﾀ
        Dim lblnFlg             As Boolean      'ﾌﾗｸﾞ
        Dim llngRecpListCnt     As Integer      'ﾚｼﾋﾟﾘｽﾄｶｳﾝﾄ退避(枚葉の場合でﾎﾞﾃﾞｨにﾃﾞｰﾀがある場合に一時退避する)
        Dim llngBodycnt         As Integer      'ﾚｼﾋﾟﾎﾞﾃﾞｨｶｳﾝﾀ(ﾘｽﾄｶｳﾝﾄ)
        Dim llngCnt3            As Integer      '汎用ｶｳﾝﾀ(WFIDの重複ﾁｪｯｸに使用)
        Dim llngCnt4            As Integer      '汎用ｶｳﾝﾀ(ﾚｼﾋﾟﾎﾞﾃﾞｨのｶｳﾝﾀｱｯﾌﾟに使用)
        Dim llngCnt5            As Integer      '汎用ｶｳﾝﾀ(ﾚｼﾋﾟﾎﾞﾃﾞｨの入力ﾁｪｯｸに使用)
        Dim lstrFunctionID      As String       '機能ID
        Dim lstrActionID        As String       'ｱｸｼｮﾝID
        Dim lstrEmpID           As String       '作業者ID
        Dim lstrEmpName         As String       '作業者名
        Dim lstrSBID            As String       'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim lstrRecipeID        As String       'ﾚｼﾋﾟID退避
        Dim lstrWPName          As String       '該当装置名退避

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
           
            
            '@ｴﾗｰ発生箇所の初期化
            ptypOnErrorInfo.strErrPositionDetail = vbNullString
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKeyを受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ﾃﾞｰﾀがある分繰り返し
            llngCnt = 1
            llngListCnt = 0
            
            With vsfWp
                '@装置が選択されている場合
                If .Row >= .Rows.Fixed Then
                    '@装置ID格納
                    lstrWpId = .GetData(.Row, CMvsfWPColWpID)
                    
                    '@代替番号
                    lstrAltNumber = .GetData(.Row, CMvsfWPColAltNumber)
                    
                    '@装置、又は、代替番号が取得できない場合
                    If lstrWpId = vbNullString Or lstrAltNumber = vbNullString Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0016)
                        
                        '@失敗ﾒｯｾｰｼﾞ表示("設定されていない項目があります。設定を見直してください。")
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@装置一覧が有効な場合
                        If .Enabled = True Then
                            '@ｴﾗｰ位置詳細情報の設定
                            ptypOnErrorInfo.strErrPositionDetail = "err1"
                            
                            '@装置一覧にﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(vsfWp)
                            
                            '@ｴﾗｰ位置詳細情報のｸﾘｱ
                            ptypOnErrorInfo.strErrPositionDetail = vbNullString
                        
                        End If
                        
                        Exit Sub
                    End If
                End If
            End With
            
            For llngCnt5 = 1 To vsfRecp.Rows.Count - 1
                '@入力可否ﾌﾗｸﾞの判定(入力可否ﾌﾗｸﾞ(1：編集可))
                If vsfRecp.GetData(llngCnt5, CMlngvsfRecpVariable) = CMlngVariableFlg Then
                    '@ﾚｼﾋﾟﾊﾟﾗﾒｰﾀが設定されていない場合
                    If vsfRecp.GetData(llngCnt5, CMlngvsfRecpValue) = vbNullString Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0016)
                        
                        '@失敗ﾒｯｾｰｼﾞ表示("設定されていない項目があります。設定を見直してください。")
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        With vsfRecp
                            .Col = CMlngvsfRecpValue
                            .Row = llngCnt5
                            .ShowCell(.Row, .Col)
                            .Select(.Row, .Col)
                            
                            '@ｴﾗｰ位置詳細情報の設定
                            ptypOnErrorInfo.strErrPositionDetail = "err2"
                            
                            '@装置一覧にﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(vsfRecp)
                            
                            '@ｴﾗｰ位置詳細情報のｸﾘｱ
                            ptypOnErrorInfo.strErrPositionDetail = vbNullString
                            
                            '@ﾚｼﾋﾟｸﾞﾘｯﾄﾞｷｰ制御(ｽｸﾛｰﾙ機能を動作させる)
                            Call pubVsf_KeyDown(New KeyEventArgs(Keys.Up), vsfRecp.Name, vsfRecp, cmdVsfUP, cmdVsfDown, False)
                            
                            Exit Sub
                        End With
                    End If
                End If
            Next
            
            '@ﾛｯﾄﾚｼﾋﾟの場合
            If optRecp0.Checked  = True Then
                '@ﾚｼﾋﾟIDが設定されていない場合
                If vsfRecp.GetDataDisplay(llngCnt, CMlngvsfRecpRecpID) = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0016)
                    
                    '@失敗ﾒｯｾｰｼﾞ表示("設定されていない項目があります。設定を見直してください。")
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    With vsfRecp
                        .Select(.Rows.Fixed, CMlngvsfRecpRecpID)
                        
                        '@ｴﾗｰ位置詳細情報の設定
                        ptypOnErrorInfo.strErrPositionDetail = "err3"
                        
                        '@装置一覧にﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfRecp)
                        
                        '@ｴﾗｰ位置詳細情報のｸﾘｱ
                        ptypOnErrorInfo.strErrPositionDetail = vbNullString
                        
                        Exit Sub
                    End With
                Else
                    'NSYS 構造体リスト初期化
                    if ltypRecpChng.typRecpList Is Nothing Then
                        ltypRecpChng.typRecpList = New List(Of RecpList)
                    End If
                    
                    '@変更ﾃﾞｰﾀ格納
                    Dim typRecpListtmp As RecpList = New RecpList 

                    With typRecpListtmp
                        .strWfId = vbNullString                                                 'WFID
                        .strRecpID = vsfRecp.GetDataDisplay(llngCnt, CMlngvsfRecpRecpID)      'ﾚｼﾋﾟID
                    End With
                    

                    llngBodycnt = 0
                    '@WFの重複件数をｶｳﾝﾄしてﾚｼﾋﾟﾎﾞﾃﾞｨｶｳﾝﾄを取得する。
                    For llngCnt3 = 1 To vsfRecp.Rows.Count - 1
                        '@ﾚｼﾋﾟｱｲﾃﾑが未設定の場合はｶｳﾝﾄしない。
                        If vsfRecp.GetData(llngCnt3, CMlngvsfRecpItem) <> vbNullString Then
                            llngBodycnt = llngBodycnt + 1
                        End If
                    Next
                    
                    '@ﾚｼﾋﾟﾎﾞﾃﾞｨ件数判定
                    If llngBodycnt = 0 Then
                        '@件数なし
                        typRecpListtmp.lngRecipeBodyList = 0
                    Else
                        '@件数あり
                        typRecpListtmp.lngRecipeBodyList = vsfRecp.Rows.Count - 1
                        
                       If typRecpListtmp.typRecipeBodyList Is Nothing 
                            typRecpListtmp.typRecipeBodyList = New List(Of RecipeBodyList) 
                       End If
                        
                        If vsfRecp.Rows.Count > 1 Then
                            For llngCnt3 = 1 To vsfRecp.Rows.Count - 1
                                Dim typRecipeBodyListtmp As RecipeBodyList = New RecipeBodyList 

                                With typRecipeBodyListtmp
                                    
                                    .strRecipeItem = vsfRecp.GetData(llngCnt3, CMlngvsfRecpItem)                            'ﾚｼﾋﾟｱｲﾃﾑ

                                    '@ﾃﾞｰﾀﾀｲﾌﾟの判定(数値の場合)
                                    If vsfRecp.GetData(llngCnt3, CMlngvsfRecptype) = CMstrDataTypeN Then
                                        If vsfRecp.GetData(llngCnt3, CMlngvsfRecpDigit) >= 1.ToString() And
                                                   vsfRecp.GetData(llngCnt3, CMlngvsfRecpDigit) <= 9.ToString() Then
                                            .strRecipeValue = Double.Parse(vsfRecp.GetData(llngCnt3, CMlngvsfRecpValue)).ToString         'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                        Else
                                            .strRecipeValue = vsfRecp.GetData(llngCnt3, CMlngvsfRecpValue)                                'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                        End If
                                    Else
                                        .strRecipeValue = vsfRecp.GetData(llngCnt3, CMlngvsfRecpValue)                                  'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                    End If
                                End With
                                typRecpListtmp.typRecipeBodyList.Add(typRecipeBodyListtmp)
                            Next
                        End If
                    End If
                    ltypRecpChng.typRecpList.Add(typRecpListtmp)

                    '@ﾚｼﾋﾟ変更ﾃﾞｰﾀがない場合
                    If ltypRecpChng.typRecpList(llngListCnt).strRecpID = vbNullString Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0016)
                        
                        '@失敗ﾒｯｾｰｼﾞ表示("設定されていない項目があります。設定を見直してください。")
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        With vsfRecp
                            '@ｸﾞﾘｯﾄﾞがﾛｯｸ解除されている場合
                            If .Enabled = True Then
                                If .Rows.Count >= .Rows.Fixed Then
                                    '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                                    .Select(.Rows.Fixed, CMlngvsfRecpRecpID)
                                     
                                    '@ｴﾗｰ位置詳細情報の設定
                                    ptypOnErrorInfo.strErrPositionDetail = "err4"
                                    
                                    '@装置一覧にﾌｫｰｶｽｾｯﾄ
                                    Call pubSetFocus(vsfRecp)
                                    
                                    '@ｴﾗｰ位置詳細情報のｸﾘｱ
                                    ptypOnErrorInfo.strErrPositionDetail = vbNullString
                                    
                                    Exit Sub
                                End If
                            End If
                        End With
                    End If
                End If
            End If
                
            '@枚葉ﾚｼﾋﾟの場合
            If optRecp1.Checked = True Then
                '@測定条件が設定されﾕｰｻﾞｰ選択可能な場合はｺﾝﾎﾞに空白を追加
                If mstrUserSelectFlag = CMstrUserSelectFlag1 Then
                    Do While vsfRecp.Rows.Count > llngCnt
                        '@WF、ﾚｼﾋﾟが存在し良品のﾃﾞｰﾀを格納
                        If vsfRecp.GetData(llngCnt, CMlngvsfRecpWFID) <> vbNullString And _
                           vsfRecp.GetData(llngCnt, CMlngvsfRecpEdit) <> CMlngEditFlg Then

                            For llngCnt2 = 0 To llngListCnt - 1
                                '@WFIDが重複していない場合
                                If ltypRecpChng.typRecpList(llngCnt2).strWfId _
                                   = vsfRecp.GetData(llngCnt, CMlngvsfRecpWFID) Then
                                    '@ﾌﾗｸﾞたて
                                    lblnFlg = True

                                    Exit For
                                End If
                            Next

                            If lblnFlg = False Then
                                'NSYS 構造体リスト初期化
                                if ltypRecpChng.typRecpList Is Nothing Then
                                    ltypRecpChng.typRecpList = New List(Of RecpList)
                                End If

                                '@変更ﾃﾞｰﾀ格納
                                Dim typRecpListtmp As RecpList = New RecpList()

                                With typRecpListtmp
                                    .strWfId = vsfRecp.GetData(llngCnt, CMlngvsfRecpWFID)                          'WFID
                                    .strRecpID = vsfRecp.GetDataDisplay(llngCnt, CMlngvsfRecpRecpID)                      'ﾚｼﾋﾟID
                                End With

                                '@ﾚｼﾋﾟﾘｽﾄの配列番号を一時退避(ﾚｼﾋﾟﾎﾞﾃﾞｨに値がある場合に使用)
                                llngRecpListCnt = llngListCnt
                                
                                '@WF重複ﾁｪｯｸｶｳﾝﾀｰの初期化
                                llngBodycnt = 0

                                '@ﾚｼﾋﾟﾎﾞﾃﾞｨｶｳﾝﾀの初期化
                                llngCnt4 = 0

                                '@WFの重複件数をｶｳﾝﾄしてﾚｼﾋﾟﾎﾞﾃﾞｨｶｳﾝﾄを取得する。
                                For llngCnt3 = 1 To vsfRecp.Rows.Count - 1
                                    '@WFIDが重複している場合
                                    If typRecpListtmp.strWfId _
                                       = vsfRecp.GetData(llngCnt3, CMlngvsfRecpWFID) Then
                                        '@ﾚｼﾋﾟｱｲﾃﾑが未設定の場合はｶｳﾝﾄしない。
                                        If vsfRecp.GetData(llngCnt3, CMlngvsfRecpItem) <> vbNullString Then
                                            llngBodycnt = llngBodycnt + 1
                                        End If
                                    End If
                                Next
                                
                                '@ﾚｼﾋﾟﾎﾞﾃﾞｨに件数がある場合(1件以上)
                                If llngBodycnt > 0 Then
                                    '@ﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄｶｳﾝﾄ取得
                                    typRecpListtmp.lngRecipeBodyList = llngBodycnt
                                    
                                    '@ﾚｼﾋﾟﾎﾞﾃﾞｨに値を格納
                                    typRecpListtmp.typRecipeBodyList = New List(Of RecipeBodyList) 
                                    Dim typRecipeBodyListtmp As RecipeBodyList = New RecipeBodyList 

                                    With typRecipeBodyListtmp
                                        .strRecipeItem = vsfRecp.GetData(llngCnt, CMlngvsfRecpItem)                'ﾚｼﾋﾟｱｲﾃﾑ

                                        '@ﾃﾞｰﾀﾀｲﾌﾟの判定(数値の場合)
                                        If vsfRecp.GetData(llngCnt, CMlngvsfRecptype) = CMstrDataTypeN Then
                                            If vsfRecp.GetData(llngCnt, CMlngvsfRecpDigit) >= 1.ToString() And
                                                   vsfRecp.GetData(llngCnt, CMlngvsfRecpDigit) <= 9.ToString() Then
                                                .strRecipeValue = Double.Parse(vsfRecp.GetData(llngCnt, CMlngvsfRecpValue)).ToString        'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                            Else
                                                .strRecipeValue = vsfRecp.GetData(llngCnt, CMlngvsfRecpValue)                                'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                            End If
                                        Else
                                            .strRecipeValue = vsfRecp.GetData(llngCnt, CMlngvsfRecpValue)                                  'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                        End If
                                    End With
                                    typRecpListtmp.typRecipeBodyList.Add(typRecipeBodyListtmp)
                                Else
                                    '@ﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄｶｳﾝﾄ取得(ﾘｽﾄなし)
                                    typRecpListtmp.lngRecipeBodyList = 0
                                End If
                                ltypRecpChng.typRecpList.Add(typRecpListtmp)

                                llngListCnt = llngListCnt + 1
                            Else
                                '@ﾚｼﾋﾟﾎﾞﾃﾞｨの格納(複数ある場合)
                                Dim typRecipeBodyListtmp As RecipeBodyList = New RecipeBodyList()
                                With typRecipeBodyListtmp
                                    .strRecipeItem = vsfRecp.GetData(llngCnt, CMlngvsfRecpItem)                    'ﾚｼﾋﾟｱｲﾃﾑ

                                    '@ﾃﾞｰﾀﾀｲﾌﾟの判定(数値の場合)
                                    If vsfRecp.GetData(llngCnt, CMlngvsfRecptype) = CMstrDataTypeN Then
                                        If vsfRecp.GetData(llngCnt, CMlngvsfRecpDigit) >= 1.ToString() And
                                                   vsfRecp.GetData(llngCnt, CMlngvsfRecpDigit) <= 9.ToString() Then
                                            .strRecipeValue = Double.Parse(vsfRecp.GetData(llngCnt, CMlngvsfRecpValue)).ToString         'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                        Else
                                            .strRecipeValue = vsfRecp.GetData(llngCnt, CMlngvsfRecpValue)                                'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                        End If
                                    Else
                                        .strRecipeValue = vsfRecp.GetData(llngCnt, CMlngvsfRecpValue)                                  'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                    End If
                                End With
                                ltypRecpChng.typRecpList(llngRecpListCnt).typRecipeBodyList.Add(typRecipeBodyListtmp)
                                '@ﾚｼﾋﾟﾎﾞﾃﾞｨｶｳﾝﾀUP
                                llngCnt4 = llngCnt4 + 1
                            End If
                        End If
                        
                        lblnFlg = False
                        llngCnt = llngCnt + 1
                    Loop
                Else
                    Do While vsfRecp.Rows.Count > llngCnt
                        '@WF、ﾚｼﾋﾟが存在し良品のﾃﾞｰﾀを格納
                        If vsfRecp.GetData(llngCnt, CMlngvsfRecpWFID) <> vbNullString And _
                           vsfRecp.GetDataDisplay(llngCnt, CMlngvsfRecpRecpID) <> vbNullString And _
                           vsfRecp.GetData(llngCnt, CMlngvsfRecpEdit) <> CMlngEditFlg Then

                            For llngCnt2 = 0 To llngListCnt - 1
                                '@WFIDが重複していない場合
                                If ltypRecpChng.typRecpList(llngCnt2).strWfId = vsfRecp.GetData(llngCnt, CMlngvsfRecpWFID) Then
                                    lblnFlg = True
                                    Exit For
                                End If
                            Next

                            If lblnFlg = False Then
                                 'NSYS 構造体リスト初期化
                                if ltypRecpChng.typRecpList Is Nothing Then
                                    ltypRecpChng.typRecpList = New List(Of RecpList)
                                End If
                    
                                '@変更ﾃﾞｰﾀ格納
                                Dim typRecpListtmp As RecpList = New RecpList

                                With typRecpListtmp
                                    .strWfId = vsfRecp.GetData(llngCnt, CMlngvsfRecpWFID)                   'WFID
                                    .strRecpID = vsfRecp.GetDataDisplay(llngCnt, CMlngvsfRecpRecpID)               'ﾚｼﾋﾟID
                                End With

                                '@ﾚｼﾋﾟﾘｽﾄの配列番号を一時退避(ﾚｼﾋﾟﾎﾞﾃﾞｨに値がある場合に使用)
                                llngRecpListCnt = llngListCnt
                                '@WF重複ﾁｪｯｸｶｳﾝﾀｰの初期化
                                llngBodycnt = 0
                                '@ﾚｼﾋﾟﾎﾞﾃﾞｨｶｳﾝﾀの初期化
                                llngCnt4 = 0

                                '@WFの重複件数をｶｳﾝﾄしてﾚｼﾋﾟﾎﾞﾃﾞｨｶｳﾝﾄを取得する。
                                For llngCnt3 = 1 To vsfRecp.Rows.Count - 1
                                    '@WFIDが重複している場合
                                    If typRecpListtmp.strWfId = vsfRecp.GetData(llngCnt3, CMlngvsfRecpWFID) Then
                                        '@ﾚｼﾋﾟｱｲﾃﾑが未設定の場合はｶｳﾝﾄしない。
                                        If vsfRecp.GetData(llngCnt3, CMlngvsfRecpItem) <> vbNullString Then
                                            llngBodycnt = llngBodycnt + 1
                                        End If
                                    End If
                                Next

                                '@ﾚｼﾋﾟﾎﾞﾃﾞｨに件数がある場合(1件以上)
                                If llngBodycnt > 0 Then
                                    '@ﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄｶｳﾝﾄ取得
                                    typRecpListtmp.lngRecipeBodyList = llngBodycnt

                                    '@ﾚｼﾋﾟﾎﾞﾃﾞｨに値を格納
                                    typRecpListtmp.typRecipeBodyList = New List(Of RecipeBodyList)
                                    Dim typRecipeBodyListtmp As RecipeBodyList = New RecipeBodyList

                                    With typRecipeBodyListtmp
                                        .strRecipeItem = vsfRecp.GetData(llngCnt, CMlngvsfRecpItem)        'ﾚｼﾋﾟｱｲﾃﾑ

                                        '@ﾃﾞｰﾀﾀｲﾌﾟの判定(数値の場合)
                                        If vsfRecp.GetData(llngCnt, CMlngvsfRecptype) = CMstrDataTypeN Then
                                            If vsfRecp.GetData(llngCnt, CMlngvsfRecpDigit) >= 1.ToString() And
                                                   vsfRecp.GetData(llngCnt, CMlngvsfRecpDigit) <= 9.ToString() Then
                                                .strRecipeValue = Double.Parse(vsfRecp.GetData(llngCnt, CMlngvsfRecpValue)).ToString         'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                            Else
                                                .strRecipeValue = vsfRecp.GetData(llngCnt, CMlngvsfRecpValue)                                'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                            End If
                                        Else
                                            .strRecipeValue = vsfRecp.GetData(llngCnt, CMlngvsfRecpValue)                                    'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                        End If

                                    End With
                                    typRecpListtmp.typRecipeBodyList.Add(typRecipeBodyListtmp)
                                Else
                                    '@ﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄｶｳﾝﾄ取得(ﾘｽﾄなし)
                                    typRecpListtmp.lngRecipeBodyList = 0
                                End If

                                ltypRecpChng.typRecpList.Add(typRecpListtmp)
                                llngListCnt = llngListCnt + 1
                            Else
                                '@ﾚｼﾋﾟﾎﾞﾃﾞｨの格納(複数ある場合)

                                Dim typRecipeBodyListtmp As RecipeBodyList = New RecipeBodyList()

                                With typRecipeBodyListtmp
                                    .strRecipeItem = vsfRecp.GetData(llngCnt, CMlngvsfRecpItem)        'ﾚｼﾋﾟｱｲﾃﾑ

                                    '@ﾃﾞｰﾀﾀｲﾌﾟの判定(数値の場合)
                                    If vsfRecp.GetData(llngCnt, CMlngvsfRecptype) = CMstrDataTypeN Then
                                        If vsfRecp.GetData(llngCnt, CMlngvsfRecpDigit) >= 1.ToString() And
                                                   vsfRecp.GetData(llngCnt, CMlngvsfRecpDigit) <= 9.ToString() Then
                                            .strRecipeValue = Double.Parse(vsfRecp.GetData(llngCnt, CMlngvsfRecpValue)).ToString         'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                        Else
                                            .strRecipeValue = vsfRecp.GetData(llngCnt, CMlngvsfRecpValue)                                'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                        End If
                                    Else
                                        .strRecipeValue = vsfRecp.GetData(llngCnt, CMlngvsfRecpValue)                                    'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                    End If
                                End With
                                ltypRecpChng.typRecpList(llngRecpListCnt).typRecipeBodyList.Add(typRecipeBodyListtmp)
                                '@ﾚｼﾋﾟﾎﾞﾃﾞｨｶｳﾝﾀUP
                                llngCnt4 = llngCnt4 + 1
                            End If
                        End If
                        
                        lblnFlg = False
                        llngCnt = llngCnt + 1
                    Loop
                End If

                '@ﾚｼﾋﾟ変更ﾃﾞｰﾀがない場合
                If llngListCnt = 0 Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0020)

                    '@失敗ﾒｯｾｰｼﾞ表示("レシピ設定変更するWFがありません。")
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                End If

                '@↓2007/08/27 (Mon) 19:28:27 N.Kasai **************************************************
                '@枚葉ﾚｼﾋﾟで対象装置ﾚｼﾋﾟが単一ﾚｼﾋﾟ設定の場合
                With vsfWp
                    If .GetData(.Row, CMvsfWPColLotRecipeFlag) = CPstrWfRecpSiFlag Then
                        
                        '@装置名退避
                        lstrWPName = .GetData(.Row, CMvsfWPColWpName)
                        
                        With vsfRecp
                            For llngCnt = 1 To .Rows.Count - 1
                                '@ﾚｼﾋﾟID退避
                                lstrRecipeID = .GetDataDisplay(llngCnt, CMlngvsfRecpRecpID)
                                
                                '@ﾚｼﾋﾟは空白以外
                                If lstrRecipeID <> vbNullString And lstrRecipeID <> CPstrSpace Then
                                
                                    For llngCnt2 = 1 To .Rows.Count - 1
                                        If .GetDataDisplay(llngCnt2, CMlngvsfRecpRecpID) <> vbNullString _
                                                And .GetDataDisplay(llngCnt2, CMlngvsfRecpRecpID) <> CPstrSpace _
                                                And llngCnt2 <> llngCnt Then
                                                '@ﾚｼﾋﾟID相違
                                                If lstrRecipeID <> .GetDataDisplay(llngCnt2, CMlngvsfRecpRecpID) Then
                                                    '@"<TRM0GW>$$装置[%1]は%2装置です。$異なったレシピの設定はできません。$設定を見直してください。"
                                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000G, lstrWPName, CPstrWFRecipeMSG)
                                                    '@警告ﾒｯｾｰｼﾞ
                                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                                    Exit Sub
                                                End If
                                        End If
                                    Next
                                End If
                            Next
                        End With
                    End If
                End With
        '@↑2007/08/27 (Mon) 19:28:27 N.Kasai **************************************************
            
            End If
            '@PR/ESﾛｯﾄの場合で、ﾕｰｻﾞｰ選択ﾌﾗｸﾞがON以外の場合は権限ﾁｪｯｸを行う
            If (lblFlowClass.Text = CPstrFlowClassPR Or lblFlowClass.Text = CPstrFlowClassES) And _
                (mstrUserSelectFlag <> CMstrUserSelectFlag1) Then
                '@作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力
                frmxxCM0020.Instance.ShowDialog(Me)
                frmxxCM0020.Instance = Nothing
            Else
                '@作業者ｺｰﾄﾞ入力
                frmxxCM0010.Instance.ShowDialog(Me)
                frmxxCM0010.Instance = Nothing
            End If
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, CMstrKakuteiClick)
            
            '@PR/ESﾛｯﾄの場合で、ﾕｰｻﾞｰ選択ﾌﾗｸﾞがON以外の場合は権限ﾁｪｯｸを行う
            If (lblFlowClass.Text = CPstrFlowClassPR Or lblFlowClass.Text = CPstrFlowClassES) And _
                (mstrUserSelectFlag <> CMstrUserSelectFlag1) Then
                '@実行権限の処理を追加
                lstrFunctionID = CPstrKeyEN00S0             '機能ID：EN00S0
                lstrActionID = CPstrPrEsRecipeChange        '処理ID：PR/ESロットレシピ変更
                lstrEmpID = pstrUserID                      'ﾕｰｻﾞｰID
                lstrEmpName = pstrUserName                  'ﾕｰｻﾞｰ名
                lstrSBID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                '@実行権限ﾁｪｯｸ
                lblnAns = pubAuthority_Chk(lstrFunctionID, lstrActionID, lstrEmpID, lstrEmpName, lstrSBID)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, CMstrKakuteiClick)
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, lstrActionID)
                    '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Exit Sub
                End If
            End If
            
            '@変更ﾃﾞｰﾀ格納
            With ltypRecpChng
                .strSbID = pstrSBID                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strClassDivision = CPstrCD06           '処理区分(ﾚｼﾋﾟ変更)
                .strLotID = lblLotID.Text            'ﾛｯﾄID
                .strOpID = lblOpID.Text              '大工程ID
                .strStepID = lblStepID.Text          '小工程ID
                .strWpID = lstrWpId                     '装置ID
                .strComments = txtWorkMemo.Text         '作業ﾒﾓ(ｺﾒﾝﾄ)
                .strEmpID = pstrUserID                  '作業者ID
                .strLotLastUpdate = mstrLotLastUpdate   '最終更新日時
                .strAltNumber = lstrAltNumber           '代替番号
            End With
            
            '@ﾚｼﾋﾟ変更送信
            lblnAns = pubblnLotChgRecp_Upd(CMstrlot_recpchngVer, ltypRecpChng)
            '@結果判定
            If lblnAns = True Then
            '@成功の場合
                '@表示ﾒｯｾｰｼﾞ変換
                lstrMsg = pubstrMsgReplace_Set(CPstrMsgInf0017, txtCarrier.Text, lblLotID.Text)
                
                '@終了してｽﾃｰﾀｽﾊﾞｰ表示
                '@pubVsfInfo_Disp("メッセージコード：C_I17%0$$レシピを変更しました。ｷｬﾘｱ[ %1 ] ロット[ %2 ]")
                Call pubVsfInfo_Disp(lstrMsg)
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, CMstrKakuteiClick)
                
                '@親画面から起動された場合
                If pblnfrmxxCM0050Kbn = True Then
                    '@ｻﾌﾞ画面確定ﾌﾗｸﾞ(確定)
                    pblnSubDecision = True
            
                    Me.Close()
                Else
                '@単独起動の場合
                    '@画面初期表示
                    Call frmxxCM0050_Init()
                    
                    '@ｸﾞﾘｯﾄﾞ表示の初期化
                    Call prvvsfRecp_Init(CMlngVsfInit)
                    
                    '@----------------------------------------------------------------------------
                    '@ｾｯﾄﾌｫｰｶｽ対応
                    '@  通信や描画に負荷が掛かった場合を考慮してﾌｫｰｶｽを当てるﾀｲﾐﾝｸﾞを遅らす。
                    '@　ﾌｫｰｶｽを当てる場所が複数存在する場合は変数で制御する。(mlngSetFocusFlag)
                    '@-----------------------------------------------------------------------------
                    '@ｴﾗｰ位置詳細情報の設定
                    ptypOnErrorInfo.strErrPositionDetail = "cmdKakutei_Click/txtCarrier"
                    
                    '@ﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtCarrier)
                    
                    '@ｴﾗｰ位置詳細情報のｸﾘｱ
                    ptypOnErrorInfo.strErrPositionDetail = vbNullString
                End If
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, CMstrKakuteiClick)
            End If
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdKakutei_Click"       '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdCancel_Click
    '機　能：ﾚｼﾋﾟ取消処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/06 (Mon) 10:58:50 M.Miura
    '更新日：2006/12/12 (Tue) 08:42:19 T.Kitagawa
    '備　考：
    '　　　：2006/11/29 (Wed) 18:05:41 T.Kitagawa　PR/ESﾛｯﾄの権限(案件№01067)、ﾊﾟｽﾜｰﾄﾞ確認機能追加(案件№01581)
    '　　　：2006/12/12 (Tue) 08:42:19 T.Kitagawa　PR/ESﾛｯﾄの権限(案件№01067)ﾁｪｯｸについては、ﾕｰｻﾞｰ選択ﾌﾗｸﾞがON("1")以外の場合のみとする
    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click

        Dim lblnAns             As Boolean      'ﾚｼﾋﾟ変更結果格納
        Dim llngCnt             As Integer      'ｸﾞﾘｯﾄﾞのｶｳﾝﾀ
        Dim llngListCnt         As Integer      'ﾚｼﾋﾟのｶｳﾝﾀ
        Dim ltypRecpChng        As LotRecpChng  'ﾚｼﾋﾟﾁｪﾝｼﾞﾃﾞｰﾀ格納用
        Dim lstrMsg             As String       '変換後ﾒｯｾｰｼﾞ
        Dim lstrWpId            As String       '装置ID
        Dim lstrAltNumber       As String       '代替番号
        Dim lstrFunctionID      As String       '機能ID
        Dim lstrActionID        As String       'ｱｸｼｮﾝID
        Dim lstrEmpID           As String       '作業者ID
        Dim lstrEmpName         As String       '作業者名
        Dim lstrSBID            As String       'ｼｽﾃﾑﾌﾞﾛｯｸ
        
        Try
           
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｴﾗｰ発生箇所の初期化
            ptypOnErrorInfo.strErrPositionDetail = vbNullString
                
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKeyを受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
             
            '@ﾃﾞｰﾀがある分繰り返し
            llngCnt = 1
            llngListCnt = 1
            
            With vsfWp
                '@装置が選択されている場合
                If .Row >= .Rows.Fixed Then
                    '@装置ID格納
                    lstrWpId = .GetData(.Row, CMvsfWPColWpID)
                    lstrAltNumber = .GetData(.Row, CMvsfWPColAltNumber)    '代替番号
                    
                    '@装置が取得できない場合
                    If lstrWpId = vbNullString Or lstrAltNumber = vbNullString Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0016)
                        
                        '@失敗ﾒｯｾｰｼﾞ表示("設定されていない項目があります。設定を見直してください。")
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@装置一覧が有効な場合
                        If .Enabled = True Then
                            '@ｴﾗｰ位置詳細情報の設定
                            ptypOnErrorInfo.strErrPositionDetail = "vsfWP"
                            
                            '@装置一覧にﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(vsfWp)

                            '@ｴﾗｰ位置詳細情報のｸﾘｱ
                            ptypOnErrorInfo.strErrPositionDetail = vbNullString
                        End If
                        
                        Exit Sub
                    End If
                End If
            End With
            
            '@変更ﾃﾞｰﾀ格納
            If ltypRecpChng.typRecpList Is Nothing 
                ltypRecpChng.typRecpList = New List(Of RecpList) 
            Else 
                ltypRecpChng.typRecpList.Clear()
            End If
            Dim typRecpListtmp As RecpList = New RecpList

            With typRecpListtmp
                '@ｷｬﾝｾﾙの場合はNullで送信
                .strWfId = vbNullString     'WFID
                .strRecpID = vbNullString   'ﾚｼﾋﾟID
            End With
            ltypRecpChng.typRecpList.Add(typRecpListtmp)

            '@PR/ESﾛｯﾄの場合で、ﾕｰｻﾞｰ選択ﾌﾗｸﾞがON以外の場合は権限ﾁｪｯｸを行う
            If (lblFlowClass.Text = CPstrFlowClassPR Or lblFlowClass.Text = CPstrFlowClassES) And _
                (mstrUserSelectFlag <> CMstrUserSelectFlag1) Then
                '@作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力
                frmxxCM0020.Instance.ShowDialog(Me)
                frmxxCM0020.Instance = Nothing
            Else
                '@作業者ｺｰﾄﾞ入力
                frmxxCM0010.Instance.ShowDialog(Me)
                frmxxCM0010.Instance = Nothing
            End If
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, CMstrCancelClick)
            
            '@PR/ESﾛｯﾄの場合で、ﾕｰｻﾞｰ選択ﾌﾗｸﾞがON以外の場合は権限ﾁｪｯｸを行う
            If (lblFlowClass.Text = CPstrFlowClassPR Or lblFlowClass.Text = CPstrFlowClassES) And _
                (mstrUserSelectFlag <> CMstrUserSelectFlag1) Then
                '@実行権限の処理を追加
                lstrFunctionID = CPstrKeyEN00S0             '機能ID：EN00S0
                lstrActionID = CPstrPrEsRecipeChange        '処理ID：PR/ESロットレシピ変更
                lstrEmpID = pstrUserID                      'ﾕｰｻﾞｰID
                lstrEmpName = pstrUserName                  'ﾕｰｻﾞｰ名
                lstrSBID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                '@実行権限ﾁｪｯｸ
                lblnAns = pubAuthority_Chk(lstrFunctionID, lstrActionID, lstrEmpID, lstrEmpName, lstrSBID)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, CMstrCancelClick)
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, lstrActionID)
                    '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Exit Sub
                End If
            End If
            
            '@変更ﾃﾞｰﾀ格納
            With ltypRecpChng
                .strSbID = pstrSBID                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strClassDivision = CPstrCD05           '処理区分(個別ﾚｼﾋﾟｷｬﾝｾﾙ)
                .strLotID = lblLotID.Text            'ﾛｯﾄID
                .strOpID = lblOpID.Text              '大工程ID
                .strStepID = lblStepID.Text          '小工程ID
                .strWpID = lstrWpId                     '装置ID
                .strComments = txtWorkMemo.Text         '作業ﾒﾓ(ｺﾒﾝﾄ)
                .strEmpID = pstrUserID                  '作業者ID
                .strLotLastUpdate = mstrLotLastUpdate   '最終更新日時
                .strAltNumber = lstrAltNumber           '代替番号
            End With
            
            '@ﾚｼﾋﾟ変更送信
            lblnAns = pubblnLotChgRecp_Upd(CMstrlot_recpchngVer, ltypRecpChng)
            '@結果判定
            If lblnAns = True Then
            '@成功の場合
                '@表示ﾒｯｾｰｼﾞ変換
                lstrMsg = pubstrMsgReplace_Set(CPstrMsgInf002F, txtCarrier.Text, lblLotID.Text)
                
                '@終了してｽﾃｰﾀｽﾊﾞｰ表示
                '@pubVsfInfo_Disp("<TRM2FI>$$レシピを取消しました。ｷｬﾘｱ[%1] ロット[%2]")
                Call pubVsfInfo_Disp(lstrMsg)
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, CMstrCancelClick)
                
                '@親画面から起動された場合
                If pblnfrmxxCM0050Kbn = True Then
                    '@ｻﾌﾞ画面確定ﾌﾗｸﾞ(確定)
                    pblnSubDecision = True
            
                    Me.Close()
                Else
                '@単独起動の場合
                    '@画面初期表示
                    Call frmxxCM0050_Init()
                    '@ｸﾞﾘｯﾄﾞ表示の初期化
                    Call prvvsfRecp_Init(CMlngVsfInit)
                    
                    '@取消ﾎﾞﾀﾝ無効
                    cmdCancel.Enabled = False
                    
                    '@----------------------------------------------------------------------------
                    '@ｾｯﾄﾌｫｰｶｽ対応
                    '@  通信や描画に負荷が掛かった場合を考慮してﾌｫｰｶｽを当てるﾀｲﾐﾝｸﾞを遅らす。
                    '@　ﾌｫｰｶｽを当てる場所が複数存在する場合は変数で制御する。(mlngSetFocusFlag)
                    '@　ｾｯﾄﾌｫｰｶｽはﾀｲﾏｰｲﾍﾞﾝﾄに記述
                    '@-----------------------------------------------------------------------------
                    
                    '@ｴﾗｰ位置詳細情報の設定
                    ptypOnErrorInfo.strErrPositionDetail = "cmdCancel_Click/txtCarrier"
                    
                    '@ﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtCarrier)
                    
                    '@ｴﾗｰ位置詳細情報のｸﾘｱ
                    ptypOnErrorInfo.strErrPositionDetail = vbNullString
                End If
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, CMstrCancelClick)
            End If

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdCancel_Click"        '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdVsfUp_Click
    '機　能：ﾌﾚｯｸｽｸﾞﾘｯﾄﾞの上方向にﾍﾟｰｼﾞをめくる
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/05 (Fri) 15:15:58 T.Oide
    '更新日：2004/04/13 (Tue) 15:01:42 H.Wajima
    '備　考：ｽﾛｯﾄのMaxが25固定であることから動作は25行が前提で動くものとする
    '　　　　一画面に表示する行数が10なのでｸﾘｯｸするとさらに10上を表示する
    '　　　　現在行より上に10行ない場合は1行目を表示する
    Private Sub cmdVsfUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdVsfUp.Click
        
        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@ｸﾞﾘｯﾄﾞ共通関数の▲ﾎﾞﾀﾝ処理を実行する
            Call pubVsfCmdUp(vsfRecp, cmdVsfUP, cmdVsfDown)
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdVsfUp_Click"         '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdVsfDown_Click
    '機　能：ﾌﾚｯｸｽｸﾞﾘｯﾄﾞの上方向にﾍﾟｰｼﾞをめくる
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/05 (Fri) 15:17:11 T.Oide
    '更新日：2004/04/13 (Tue) 15:01:46 H.Wajima
    '備　考：ｽﾛｯﾄのMaxが25固定であることから動作は25行が前提で動くものとする
    '　　　　一画面に表示する行数が10なのでｸﾘｯｸするとさらに10下を表示する
    '　　　　現在行より下に10行ない場合は1行目を表示する
    Private Sub cmdVsfDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdVsfDown.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@ｸﾞﾘｯﾄﾞ共通関数の▼ﾎﾞﾀﾝ処理を実行する
            Call pubVsfCmdDown(vsfRecp, cmdVsfUP, cmdVsfDown, False)

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdVsfDown_Click"       '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLeft_Click
    '機　能：ｸﾞﾘｯﾄﾞ左一項目移動
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/21 (Tue) 20:47:51 Y.Yamagishi
    '更新日：2007/07/09 (Mon) 11:46:10 N.Kasai
    '備　考：
    '　　　：2007/07/09 (Mon) 11:46:10 N.Kasai  ｸﾞﾘｯﾄﾞ共通化
    Private Sub cmdLeft_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLeft.Click
        
        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@左ｽｸﾛｰﾙ処理
            Call pubVsfCmdLeft(vsfRecp, cmdLeft, cmdRight)

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdLeft_Click"          '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdRight_Click
    '機　能：ｸﾞﾘｯﾄﾞ右一項目移動
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/21 (Tue) 20:48:09 Y.Yamagishi
    '更新日：2007/07/09 (Mon) 11:45:47 N.Kasai
    '備　考：
    '　　　：2007/07/09 (Mon) 11:45:47 N.Kasai  ｸﾞﾘｯﾄﾞ共通化
    Private Sub cmdRight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRight.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@右ｽｸﾛｰﾙ処理
            Call pubVsfCmdRight(vsfRecp, cmdLeft, cmdRight)

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdRight_Click"         '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：↓↑ｷｰが入力された場合のﾌﾚｯｸｽｸﾞﾘｯﾄﾞのｽｸﾛｰﾙをする
    '引　数：KeyCode：入力されたキー
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2004/03/10 (Wed) 10:02:29 T.Oide
    '更新日：2007/07/09 (Mon) 11:47:08 N.Kasai
    '備　考：
    '　　　：2005/01/13 (Thu) 17:27:17 N.Kasai  ﾚｼﾋﾟ表示の際のkye先読み防止(不具合№422)
    '　　　：2005/01/26 (Wed) 14:15:13 N.Kasai  CMP対応(不具合№304)
    '　　　：2007/07/09 (Mon) 11:47:08 N.Kasai  ｸﾞﾘｯﾄﾞ共通化
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Try
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKeyを受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True:読込み済み、False:初回)
            If mblnFirstLoadFlg = False Then
                e.Handled = True
                Exit Sub
            End If
            
            '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙを判定する。(余計な処理を走行させない)
            Select Case ActiveControl.Name
                '@装置ｸﾞﾘｯﾄﾞ
                Case vsfWp.Name
                    '@装置ｸﾞﾘｯﾄﾞｷｰ制御
                    Call pubVsf_KeyDown(e, ActiveControl.Name, vsfWp, cmdUP, cmdDown)

                '@ﾚｼﾋﾟｸﾞﾘｯﾄﾞ
                Case vsfRecp.Name
                    '@ﾚｼﾋﾟｸﾞﾘｯﾄﾞｷｰ制御
                    Call pubVsf_KeyDown(e, ActiveControl.Name, vsfRecp, cmdVsfUP, cmdVsfDown, False)
                    
                    '@ｸﾞﾘｯﾄﾞｷｰ制御(ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、左ﾎﾞﾀﾝ、右ﾎﾞﾀﾝ)
                    Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfRecp, cmdLeft, cmdRight)
            
            End Select

            '@Enterｷｰの場合
            If e.KeyCode = Keys.Return Then
                '@ｺﾝﾄﾛｰﾙ名判定
                Select Case ActiveControl.Name
                    '@ｷｬﾘｱID
                    Case txtCarrier.Name
                        e.Handled = True
                        RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate 
                        Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                        AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate 
                    '@作業ﾒﾓの場合
                    Case txtWorkMemo.Name
                        '@改行する為
                        Exit Sub

                    Case Else
                        If ActiveControl IsNot vsfRecp.Editor Then
                            '@次項目にﾌｫｰｶｽｾｯﾄ
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                        End If
                End Select
            
            End If

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "Form_KeyDown"           '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｸｴﾘｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：ｷｬﾝｾﾙ
    '　　　：UnloadMode：ﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 09:21:56 H.Wajima
    '更新日：2004/11/01 (Mon) 15:00:54 N.Kasai
    '備　考：2004/11/01 (Mon) 15:00:54 N.Kasai  閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      '開放結果格納
        
        Try
                       
            '@ﾌﾗｸﾞ判定(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
            If pblnfrmxxCM0050CVFlag = False Then
                e.Cancel = True
                Exit Sub
            End If
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
               RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@構造体の初期化
            '@ﾏｽﾀﾚｼﾋﾟ初期化
            If ptypRecp02List Is Nothing 
                ptypRecp02List = New List(Of Lotrecplist) 
            Else 
                ptypRecp02List.Clear()
            End If
            '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟ初期化
            If ptypRecp23List Is Nothing 
               ptypRecp23List = New List(Of Lotrecplist) 
            Else 
                ptypRecp23List.Clear()
            End If
            
            '@ﾌｫｰﾑ起動区分の確認
            If pblnfrmxxCM0050Kbn = True Then
                '@ﾌｫｰﾑ起動区分を初期化
                pblnfrmxxCM0050Kbn = False
            Else
                '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
                pblnFormLoad = False
                '@ActInitフラグの判定
                If pblnActInitFlg = True Then
                    '@Actを自前で初期化した場合
                    
                    '@ACTｵﾌﾞｼﾞｪｸﾄの開放
                    lblnAnsTerm = pubblnAct_Term
                    If lblnAnsTerm = True Then
                        '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                    End If
                Else
                    '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                    Call pubMenuExpand_Disp()
                End If
            End If
            
            '@ｿｰﾄ保持用構造体のｸﾘｱ
            If mtypChgSort.typChgSortList Is Nothing 
               mtypChgSort.typChgSortList = New List(Of ChgSortList)  
            Else 
                mtypChgSort.typChgSortList.Clear()
            End If
            
            '@ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄとの関連付けを解除

            '@ﾊﾟﾌﾞﾘｯｸ変数を初期化
            pblnfrmxxCM0050CVFlag = False
            
             'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "Form_QueryUnload"       '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_KeyUp
    '機　能：ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 14:55:01 N.Kasai
    '更新日：2005/11/22 (Tue) 14:55:01
    '備　考：
    Private Sub txtWorkMemo_KeyUp(ByVal sender As Object, ByVal e As keyEventArgs) Handles txtWorkMemo.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtWorkMemo, CMlngMaxDispRow, cmdMemoUp, cmdMemoDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_MouseUp
    '機　能：ﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 14:57:58 N.Kasai
    '更新日：2005/11/22 (Tue) 14:57:58
    '備　考：
    Private Sub txtWorkMemo_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtWorkMemo.MouseUp

        Try
            

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispRow, cmdMemoUp, cmdMemoDown, e.Button)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRecp_BeforeEdit
    '機　能：ﾚｼﾋﾟ情報のみを変更可能とするようにｸﾞﾘｯﾄﾞをｺﾝﾄﾛｰﾙ
    '引　数：Row：選択された行
    '　　　：Col：(未使用)
    '　　　：Cancel：(未使用)
    '戻り値：なし
    '作成日：2004/03/04 (Thu) 18:29:41 T.Oide
    '更新日：2006/08/18 (Fri) 09:48:38 N.Kojima
    '備　考：
    '　　　：2004/09/06 (Mon) 08:59:35 M.Miura　    編集不可設定を追加
    '　　　：2004/09/27 (Mon) 20:42:20 Y.Yamagishi　ﾚｼﾋﾟ設定が「工順変更設定済み」の場合は編集不可
    '　　　：2005/01/26 (Wed) 13:25:37 N.Kasai      CMP対応(不具合№304)
    '　　　：2005/02/24 (Thu) 11:44:56 N.Kasai      ﾕｰｻﾞ変更が可能の場合ｺﾝﾎﾞﾘｽﾄは不可
    '　　　：2005/10/03 (Mon) 15:05:16 N.Kojima     Loader/Unloader装置・枚葉ﾚｼﾋﾟ・ﾕｰｻﾞ選択可の場合も、ﾚｼﾋﾟｺﾝﾎﾞﾘｽﾄにNULLを設定しない。(不具合№3163)
    '　　　：2006/08/18 (Fri) 09:48:38 N.Kojima     ﾚｼﾋﾟﾊﾟﾗﾒｰﾀ(ﾚｼﾋﾟ値)の入力桁数を30byte⇒40byteに拡張(案件№01399)
    Private Sub vsfRecp_BeforeEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfRecp.BeforeEdit
        
        Dim lstrVsfComboList    As SortedList   'ﾚｼﾋﾟﾘｽﾄ
        Dim llngVsfComboListCnt As Integer      'ﾚｼﾋﾟﾘｽﾄ件数
        
        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfRecp.Rows.Count <= vsfRecp.Rows.Fixed Then
                Return
            End If
            
            
            '@ﾃﾞｰﾀ行ではない場合
            If e.Row < vsfRecp.Rows.Fixed Then
                Exit Sub
            End If
            
            '@----------------------
            '@ﾚｼﾋﾟ変更不可の場合
            '@ mblnChgRecpFlag:True:変更可、False:変更不可
            '@----------------------
            If mblnChgRecpFlag = False AndAlso _
                Not (e.Col = CMlngvsfRecpValue AndAlso vsfRecp.GetData(vsfRecp.Row, CMlngvsfRecpVariable) = CMlngVariableFlg) Then
                'NSYS BeforeEdit で AllowEditing を False => True と変更すると再び OnPaint が動きその中で BeforeEdit が呼ばれ無限ループに陥る
                'NSYS AllowEditing を True に戻すケースでは False にしない
                '@編集不可
                vsfRecp.AllowEditing = False
                '@変更可否判定
                If vsfRecp.Col = CMlngvsfRecpRecpID Then
                    '@ﾚｼﾋﾟｺﾝﾎﾞﾘｽﾄ初期化
                    vsfRecp.Cols(CMlngvsfRecpRecpID).ComboList = vbNullString
                End If
                
                '@-------------------------------------------------------------------------------
                '@注意
                '@ Exit Subはしない事!!　ﾃﾞﾌｫﾙﾄﾚｼﾋﾟでもﾚｼﾋﾟﾎﾞﾃﾞｨが入力可能の場合があります。(CMP)
                '@-------------------------------------------------------------------------------
            End If
            
            With vsfRecp
                '@行判定
                Select Case e.Col
                    '@ﾚｼﾋﾟID列の場合
                    Case CMlngvsfRecpRecpID
                        '@----------------------
                        '@ﾚｼﾋﾟ変更不可の場合
                        '@ mblnChgRecpFlag:True:変更可、False:変更不可
                        '@----------------------
                        If mblnChgRecpFlag = True Then
                             '@WPｸﾞﾘｯﾄﾞ選択済みの場合
                             If vsfWp.Row >= vsfWp.Rows.Fixed Then
                                 '@ﾚｼﾋﾟﾘｽﾄ
                                 lstrVsfComboList = vsfWp.GetData(vsfWp.Row, CMvsfWPColRecpList)
                                 If IsNumeric(vsfWp.GetData(vsfWp.Row, CMvsfWPColRecpListCnt)) = True Then
                                     '@ﾚｼﾋﾟﾘｽﾄ件数格納
                                     llngVsfComboListCnt = CLng((vsfWp.GetData(vsfWp.Row, CMvsfWPColRecpListCnt)))
                                 End If
                                 
                                 '@測定条件が設定されﾕｰｻﾞｰ選択可能で枚葉ﾚｼﾋﾟの場合はｺﾝﾎﾞに空白を追加
                                 If mstrUserSelectFlag = CMstrUserSelectFlag1 And optRecp1.Checked = True Then
                                 
                                    '@Uni装置か(Loader/Unloader装置の場合は、ﾚｼﾋﾟｺﾝﾎﾞﾘｽﾄに空白をｾｯﾄしない)
                                    If vsfWp.GetData(vsfWp.Row, CMvsfWPColLoaderUnloaderFlag) = CPstrZero Or _
                                        vsfWp.GetData(vsfWp.Row, CMvsfWPColLoaderUnloaderFlag) = vbNullString Then
                                        
                                        '@ﾚｼﾋﾟｺﾝﾎﾞﾘｽﾄ設定(空白あり)
                                        If lstrVsfComboList.GetKey(0) <> 0 And lstrVsfComboList.Values(0) <> " " Then
                                            lstrVsfComboList.Add(0, CPstrSpace)
                                        End If
                                        .Cols(CMlngvsfRecpRecpID).DataMap = lstrVsfComboList
                                    Else
                                        '@ﾚｼﾋﾟｺﾝﾎﾞﾘｽﾄ設定
                                        .Cols(CMlngvsfRecpRecpID).DataMap = lstrVsfComboList
                                    End If
                                 Else
                                     '@ﾚｼﾋﾟｺﾝﾎﾞﾘｽﾄ設定
                                     .Cols(CMlngvsfRecpRecpID).DataMap = lstrVsfComboList
                                 End If
                             End If
                            
                             '@編集ﾌﾗｸﾞ判定　CMlngEditFlg　編集ﾌﾗｸﾞ(1：編集不可)
                             If .GetData(.Row, CMlngvsfRecpEdit) = CMlngEditFlg Then
                                 '@編集不可
                                 .AllowEditing = False
                             Else
                                 '@ﾚｼﾋﾟIDが複数件ある場合、ﾊﾞｯﾁ装置以外
                                 If llngVsfComboListCnt >= 1 Or _
                                    (mstrUserSelectFlag = CMstrUserSelectFlag1 And _
                                     vsfWp.GetData(vsfWp.Row, CMvsfWPColEqType) <> CPstrEqTypeBatch And _
                                     optRecp1.Checked = True) Then
                                     '@編集可
                                     '.AllowEditing = True
                                 Else
                                     '@編集不可
                                     .AllowEditing = False
                                 End If
                             End If
                        End If
                        
                    '@ﾚｼﾋﾟ値列の場合
                    Case CMlngvsfRecpValue

                        '@入力可否ﾌﾗｸﾞの判定(1:入力可の場合)
                        If .GetData(.Row, CMlngvsfRecpVariable) = CMlngVariableFlg Then
                           '@編集可
                            '.AllowEditing = True
                        Else
                            '@編集不可
                            .AllowEditing = False
                        End If

                        '@↓2006/08/18 (Fri) 09:53:05 N.Kojima **************************************************
                        '@文字ﾀｲﾌﾟの場合は、40byteまで入力可に変更(※元は30byte)

                        '@ﾃﾞｰﾀﾀｲﾌﾟの判定(数値の場合)
                        'If .GetData(.Row, CMlngvsfRecptype) = CMstrDataTypeN Then
                        '    .GetData(.Row, CMlngvsfRecpValue).TextAlign = TextAlignEnum.RightCenter  '右寄せ
                        '    '@10ﾊﾞｲﾄ迄入力可能(MAXｶﾗﾑ：当面ｸﾗｲｱﾝﾄでの入力ﾀｲﾌﾟ制限は数字、英数のみ)
                        '    'CType(.Editor, Object).MaxLength = CMlngInputNDataMaxByte
                        'Else
                        '    .GetData(.Row, CMlngvsfRecpValue).TextAlign = TextAlignEnum.LeftCenter    '左寄せ
                        '    '@40ﾊﾞｲﾄ迄入力可能(MAXｶﾗﾑ：当面ｸﾗｲｱﾝﾄでの入力ﾀｲﾌﾟ制限は数字、英数のみ)
                        '    'CType(.Editor, Object).MaxLength = CMlngInputADataMaxByte
                        'End If
                        '@↑2006/08/18 (Fri) 09:53:05 N.Kojima **************************************************

                    Case Else
                        '@編集不可
                        .AllowEditing = False
                End Select
            End With
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "vsfRecp_BeforeEdit"     '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        Finally

            If Not vsfRecp.AllowEditing OrElse e.Col <> CMlngvsfRecpRecpID Then
                vsfRecp.Rows.DefaultSize = CMvsfRecpHeight
            End If

        End Try
    End Sub

    '関数名：optRecp_Click
    '機　能：ﾚｼﾋﾟ選択処理
    '引　数：Index：ｲﾝﾃﾞｯｸｽ値
    '戻り値：なし
    '作成日：2004/05/26 (Wed) 13:59:41 M.Miura
    '更新日：2007/07/09 (Mon) 12:11:06 N.Kasai
    '備　考：
    '　　　：2004/09/27 (Mon) 21:30:51 Y.Yamagishi　右ｽｸﾛｰﾙ制御処理追加
    '　　　：2004/10/26 (Tue) 18:32:19 M.Miura　    ｽﾛｯﾄﾏｯﾌﾟ初期位置設定追加、Row設定を追加関数に移動
    '　　　：2004/12/14 (Tue) 13:40:35 S.Deguchi    ﾚｼﾋﾟ選択処理のIndexを定数に変更
    '　　　：2005/11/22 (Tue) 15:09:43 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2007/07/09 (Mon) 12:11:06 N.Kasai      ｸﾞﾘｯﾄﾞ共通化
    Private Sub optRecp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optRecp0.CheckedChanged,optRecp1.CheckedChanged
        Dim Index As Integer
        Dim optRecpRadio As RadioButton 'NSYS ラジオボタン
        Try
           
            If sender Is optRecp0 Then
                Index = 0
                optRecpRadio　= optRecp0
            Else
                Index = 1
                optRecpRadio　= optRecp1
            End If
            
            
            '@ｴﾗｰ発生箇所の初期化
            ptypOnErrorInfo.strErrPositionDetail = vbNullString
            
            '@未ﾁｪｯｸの場合は処理なし
            If optRecpRadio.checked = False Then
                Exit Sub
            End If
                        
            '@ﾁｪｯｸ内容を判定しﾚｼﾋﾟｸﾞﾘｯﾄﾞ初期化
            Select Case Index
                '@ﾛｯﾄﾚｼﾋﾟ
                Case CMlngLotRecp
                    '@ｸﾞﾘｯﾄﾞの初期化(ﾛｯﾄﾚｼﾋﾟ)
                    Call prvvsfRecp_Init(CMlngLotRecp)
                '@枚葉ﾚｼﾋﾟ
                Case CMlngWFRecp
                    '@ｸﾞﾘｯﾄﾞの初期化(枚葉ﾚｼﾋﾟ)
                    Call prvvsfRecp_Init(CMlngWFRecp)
            End Select
            
            '@描画なし
            vsfRecp.Redraw = False

            '@ｸﾞﾘｯﾄﾞ表示
            Call vsfRecp_Disp()
            
            '@ｽﾛｯﾄﾏｯﾌﾟの初期表示位置設定
            Call prvVsfSlotMapTopRow_Set()
            vsfRecp.Redraw = True

            With vsfRecp
                '@ﾃﾞｰﾀがある場合
                If .Rows.Count >= .Rows.Fixed Then
                    '@ﾚｼﾋﾟﾁｪｯｸ
                    Call vsfRecp_AfterEdit(vsfRecp, New RowColEventArgs(.Rows.Fixed, .Cols.Fixed))
                    
                    '@変更後ﾚｼﾋﾟを初期化
                    mstrChgRecpAfter = vbNullString
                    
                    '@変更前ﾚｼﾋﾟを格納
                    Call prvRecp_Set(True)
                    
                    '@作業ﾒﾓを有効
                    txtWorkMemo.Enabled = True             '作業ﾒﾓ
                    
                    '@確定ﾎﾞﾀﾝを無効
                    cmdKakutei.Enabled = False
                    
                    '@ﾌｫｰﾑﾛｰﾄﾞが正常な場合
                    If pblnFormLoad = True Then
                        '@有効の場合
                        If .Enabled = True Then
                            '@----------------------------------------------------------------------------
                            '@ｾｯﾄﾌｫｰｶｽ対応
                            '@  通信や描画に負荷が掛かった場合を考慮してﾌｫｰｶｽを当てるﾀｲﾐﾝｸﾞを遅らす。
                            '@　ﾌｫｰｶｽを当てる場所が複数存在する場合は変数で制御する。(mlngSetFocusFlag)
                            '@　ｾｯﾄﾌｫｰｶｽはﾀｲﾏｰｲﾍﾞﾝﾄに記述
                            '@-----------------------------------------------------------------------------
                            '@ｴﾗｰ位置詳細情報の設定
                            ptypOnErrorInfo.strErrPositionDetail = "optRecp_Click/vsfRecp"
                            
                            '@ﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(vsfRecp)
                            
                            '@ｴﾗｰ位置詳細情報のｸﾘｱ
                            ptypOnErrorInfo.strErrPositionDetail = vbNullString
                        End If
                    End If
                    
                End If
            
                .Col = .Cols.Fixed
                .LeftCol = .Cols.Fixed
                
                '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
                Call pubCmdLREnable_Set(vsfRecp, cmdLeft, cmdRight)

            
            End With
            
            '@ｸﾞﾘｯﾄﾞ選択の初期化(ｸﾞﾘｯﾄﾞ共通化関数)
            Call pubVsfDisp(vsfRecp, cmdVsfUP, cmdVsfDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "optRecp_Click"          '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
         
        End Try
    End Sub

    '関数名：vsfRecp_AfterEdit
    '機　能：ﾚｼﾋﾟ変更後処理
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2004/05/26 (Wed) 15:55:37 M.Miura
    '更新日：2005/06/24 (Fri) 15:56:30 N.Kasai
    '備　考：2004/09/26 (Sun) 16:43:34 T.Kitagawa   ﾚｼﾋﾟｺﾝﾎﾞの▼幅を考慮する(不具合№675)
    '　　　：2004/09/27 (Mon) 14:02:46 T.Kitagawa   一度確定ﾎﾞﾀﾝ有効時はもう無効にはしない(不具合№943)
    '　　　：2004/11/01 (Mon) 09:06:33 M.Miura　    ﾚﾁｸﾙ列の表示/非表示制御の追加。ﾚｼﾋﾟ一覧次頁ﾎﾞﾀﾝを有効/無効制御の追加
    '　　　：2005/01/13 (Thu) 17:32:53 N.Kasai      枚葉ﾚｼﾋﾟ選択、№01でﾚﾁｸﾙｺﾝﾎﾞを変更した際の下ﾎﾞﾀﾝ制御追加(不具合№419)
    '　　　：2004/05/26 (Wed) 15:55:37 M.Miura      工順変更ありでﾚｼﾋﾟﾎﾞﾃﾞｨ変更可能な場合確定ﾎﾞﾀﾝの使用可
    Private Sub vsfRecp_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfRecp.AfterEdit
        Dim llngCnt             As Integer  'ｶｳﾝﾄ
        Dim lblnNG              As Boolean  'NGﾌﾗｸﾞ(True：NG、False：OK)
        Dim llngRCnt            As Integer  'ｶｳﾝﾄ
        Dim lstrWFID            As String   'WFID
        Dim lstrRecpID          As String   'ﾚｼﾋﾟID
        Dim lstrRecpEdit        As String   'ﾚｼﾋﾟ編集ﾌﾗｸﾞ
        Dim lblnAns             As String   '戻り値
        Dim lblnReticleHidden   As Boolean  'ﾚﾁｸﾙ列非表示ﾌﾗｸﾞ(Ture：非表示、False：表示)
        
        Try
                       
            '@ｴﾗｰ発生箇所の初期化
            ptypOnErrorInfo.strErrPositionDetail = vbNullString
            
            With vsfRecp
                '@ﾚｼﾋﾟID/ﾚｼﾋﾟ値変更の場合
                If e.Col = CMlngvsfRecpRecpID Or e.Col = CMlngvsfRecpValue Then
                    '@--------------
                    '@ﾛｯﾄﾚｼﾋﾟの場合
                    '@--------------
                    If optRecp0.Checked = True Then
        '                '@ﾚｼﾋﾟIDが選択されていない、又は、ﾚｼﾋﾟIDが変更されていない場合
                       If .GetDataDisplay(.Rows.Fixed, CMlngvsfRecpRecpID) = vbNullString Or _
                            mstrChgRecpBefore = mstrChgRecpAfter Then
                        Else
                            lblnNG = False  'NGﾌﾗｸﾞ初期化（True：NG、False：OK）

                                                
                        '@確定ﾎﾞﾀﾝの制御
                        For llngCnt = 1 To .Rows.Count - 1
                            '@入力可否ﾌﾗｸﾞの判定(入力可否ﾌﾗｸﾞ(1：編集可))
                            If .GetData(llngCnt, CMlngvsfRecpVariable) = CMlngVariableFlg Then
                                '@ﾚｼﾋﾟﾊﾟﾗﾒｰﾀが設定されていない場合
                                If .GetData(llngCnt, CMlngvsfRecpValue) = vbNullString Then
                                    lblnNG = True
                                    Exit For
                                End If
                            End If
                        Next
                       
                        '@確定ﾎﾞﾀﾝ使用可否
                        If lblnNG = True Then
                            '@使用不可
                            cmdKakutei.Enabled = False
                        Else
                            '@使用可
                            cmdKakutei.Enabled = True
                        End If
                        
                       End if 
                    End If
                    
                    '@--------------
                    '@枚葉ﾚｼﾋﾟの場合
                    '@--------------
                    If optRecp1.Checked = True Then
                        '@NGﾌﾗｸﾞ初期化(NG)
                        lblnNG = False
                        
                        llngRCnt = 0
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@WFID格納
                            lstrWFID = .GetData(llngCnt, CMlngvsfRecpWFID)
                            '@ﾚｼﾋﾟID格納
                            lstrRecpID = .GetDataDisplay(llngCnt, CMlngvsfRecpRecpID)
                            '@ﾚｼﾋﾟ編集ﾌﾗｸﾞ
                            lstrRecpEdit = .GetData(llngCnt, CMlngvsfRecpEdit)
                                            
                            '@WFID、ﾚｼﾋﾟIDが設定されていて、良品の場合
                            If lstrWFID <> vbNullString And _
                               lstrRecpID <> vbNullString And _
                               lstrRecpEdit = vbNullString Then
                                llngRCnt = llngRCnt + 1
                            Else
                                '@ﾚｼﾋﾟIDが選択されていなく、良品の場合
                                If lstrWFID <> vbNullString And _
                                   lstrRecpID = vbNullString And _
                                   lstrRecpEdit = vbNullString Then
                                    llngRCnt = llngRCnt + 1
                                Else
                                    '@WFIDが選択されていなく、良品の場合
                                    If lstrWFID = vbNullString And _
                                       lstrRecpID <> vbNullString And _
                                       lstrRecpEdit = vbNullString Then
                                        '@NGﾌﾗｸﾞ(NG)
                                        lblnNG = True
                                    End If
                                End If
                            End If
                        Next llngCnt
                        
                        '@ﾃﾞｰﾀが正常に設定されていて、ﾚｼﾋﾟ/ﾚｼﾋﾟﾊﾟﾗﾒｰﾀが変更されている又は、装置がある場合
                        If llngRCnt > 0 And lblnNG = False And _
                           mstrChgRecpBefore <> mstrChgRecpAfter Or _
                           vsfWp.Rows.Count > .Rows.Fixed Then
                            
                            '@ﾚｼﾋﾟID存在ﾁｪｯｸ
                            lblnAns = prvblnRecp_Chk
                            '@ﾚｼﾋﾟIDがある場合
                            If lblnAns = True Then
                                lblnNG = False  'NGﾌﾗｸﾞ初期化(True：NG、False：OK)
                                
                                '@確定ﾎﾞﾀﾝの制御
                                For llngCnt = 1 To .Rows.Count - 1
                                    '@入力可否ﾌﾗｸﾞの判定(入力可否ﾌﾗｸﾞ(1：編集可))
                                    If .GetData(llngCnt, CMlngvsfRecpVariable) = CMlngVariableFlg Then
                                        '@ﾚｼﾋﾟﾊﾟﾗﾒｰﾀが設定されていない場合
                                        If .GetData(llngCnt, CMlngvsfRecpValue) = vbNullString Then
                                            lblnNG = True
                                            Exit For
                                        End If
                                    End If
                                Next
                            
                                '@確定ﾎﾞﾀﾝ使用可否
                                If lblnNG = True Then
                                    '@使用不可
                                    cmdKakutei.Enabled = False
                                Else
                                    '@使用可
                                    cmdKakutei.Enabled = True
                                End If
                            Else
                                '@確定ﾎﾞﾀﾝ無効
                                cmdKakutei.Enabled = False
                            End If
                        End If
                    End If
                    
                    '@-----------------------------------------------------
                    '@入力可否ﾌﾗｸﾞの判定(1:入力可の場合)
                    '@-----------------------------------------------------
                    If .GetData(.Row, CMlngvsfRecpVariable) = CMlngVariableFlg Then
                        '@ﾃﾞｰﾀﾀｲﾌﾟの判定(数値の場合)
                        If .GetData(.Row, CMlngvsfRecptype) = CMstrDataTypeN Then

                            If EditorFlg = False Then
                                If IsNumeric(.GetData(.Row, CMlngvsfRecpValue)) = True Then
                                    .SetData(.Row, CMlngvsfRecpValue, Format$(CDbl(.GetData(.Row, CMlngvsfRecpValue)),
                                            prvFormatValue_Set(.GetData(.Row, CMlngvsfRecpDigit))))        'ｶﾝﾏ編集
                                End If
                                EditorText = .GetData(.Row, CMlngvsfRecpValue)
                            End If

                        End If

                        '@ｵｰﾄｻｲｽﾞ設定(幅)
                        '@ﾕｰｻﾞによる列幅変更されていない場合
                        If mtypChgSort.blnChgWidth = False Then
                            '.AutoSizeMode = flexAutoSizeColWidth
                            .AutoSizeCol(CMlngvsfRecpValue, 6)             'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                        End If
                    End If
                    
                    '@-----------------------------------------------------
                    '@ﾚｼﾋﾟﾎﾞﾃﾞｨの表示可否
                    '@　ﾚﾁｸﾙ設定が無い場合はﾚﾁｸﾙ列を非表示にする。
                    '@-----------------------------------------------------
                    
                    '@ﾚﾁｸﾙ列の非表示ﾌﾗｸﾞ初期化(False:表示、True:非表示)
                    lblnReticleHidden = True
                    
                    '@ﾃﾞｰﾀ有無検索
                    For llngCnt = 1 To .Rows.Count - 1
                        If .GetData(llngCnt, CMlngvsfRecpItem) <> vbNullString Then
                            '@----------------------------------------------
                            '@ﾚｼﾋﾟﾎﾞﾃﾞｨが１件でも有る場合は表示する
                            '@ﾚﾁｸﾙ列の非表示ﾌﾗｸﾞ(False:表示、True:非表示)
                            '@----------------------------------------------
                            lblnReticleHidden = False
                            Exit For
                        End If
                    Next
                    
                    '@ﾚｼﾋﾟﾎﾞﾃﾞｨ有無結果判定
                    If lblnReticleHidden = True Then
                        '@非表示
                        .Cols(CMlngvsfRecpValue).Visible = false    'ﾚｼﾋﾟ値
                        .Cols(CMlngvsfRecpItem).Visible  = false     'ﾚｼﾋﾟｱｲﾃﾑ
                    Else
                        '@表示
                        .Cols(CMlngvsfRecpValue).Visible  = True   'ﾚｼﾋﾟ値
                        .Cols(CMlngvsfRecpItem).Visible  = True    'ﾚｼﾋﾟｱｲﾃﾑ
                    End If
                    
                    '@-----------------------------------------------------------
                    '@ｽｸﾛｰﾙﾎﾞﾀﾝの制御
                    '@  最終行でﾚｼﾋﾟﾎﾞﾃﾞｨが変更された場合Rowsの値が変更となる。
                    '@  変更となった場合にｽｸﾛｰﾙﾎﾞﾀﾝ、ﾌｫｰｶｽの制御をする必要がある
                    '@-----------------------------------------------------------
                    
                    '@ﾚｼﾋﾟ一覧次頁ﾎﾞﾀﾝが無効な場合
                    If cmdVsfDown.Enabled = False Then
                        '@--------------------------------------------------------------------
                        '@最下段行が表示領域にない場合
                        '@枚葉ﾚｼﾋﾟ選択、№01でﾚﾁｸﾙｺﾝﾎﾞを変更した際の下ﾎﾞﾀﾝ制御
                        '@ﾚﾁｸﾙIDｺﾝﾎﾞ選択でRowsが変更となった場合ﾚﾁｸﾙID(ﾏｰｼﾞｾﾙ)にﾌｫｰｶｽを当てる
                        '@最終行を表示させる。
                        '@--------------------------------------------------------------------
                        
                        If .Cols(CMlngvsfRecpItem).Visible Then
                            .ShowCell(.Rows.Count - 1, CMlngvsfRecpItem) ' ﾏｰｼﾞされないｾﾙを指定
                        Else
                            .ShowCell(.Rows.Count - 1, CMlngvsfRecpRecpID)
                        End If
                        
                        '@----------------------------------------------------------------------------
                        '@ｾｯﾄﾌｫｰｶｽ対応
                        '@  通信や描画に負荷が掛かった場合を考慮してﾌｫｰｶｽを当てるﾀｲﾐﾝｸﾞを遅らす。
                        '@　ﾌｫｰｶｽを当てる場所が複数存在する場合は変数で制御する。(mlngSetFocusFlag)
                        '@　ｾｯﾄﾌｫｰｶｽはﾀｲﾏｰｲﾍﾞﾝﾄに記述
                        '@-----------------------------------------------------------------------------
                        '@ｴﾗｰ位置詳細情報の設定
                        ptypOnErrorInfo.strErrPositionDetail = "vsfRecp_AfterEdit/vsfRecp"

                        '@ﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfRecp)
                        
                        '@ｴﾗｰ位置詳細情報のｸﾘｱ
                        ptypOnErrorInfo.strErrPositionDetail = vbNullString
                        
                        '@ﾎﾞﾀﾝ制御
                        If.Rows.Count - 1 > .BottomRow Then
                            '@ﾚｼﾋﾟ一覧次頁ﾎﾞﾀﾝを有効
                            cmdVsfDown.Enabled = True
                        End If
                    Else
                        '@-----------------------------
                        '@最下段行が表示領域にある場合
                        '@-----------------------------
                        '@ﾎﾞﾀﾝ制御
                        If .Rows.Count - 1 <= .BottomRow Then
                            '@ﾚｼﾋﾟ一覧次頁ﾎﾞﾀﾝを無効
                            cmdVsfDown.Enabled = False
                        End If
                    End If
                
                    '@ﾚｼﾋﾟID列を
                    .AutoSizeCol(CMlngvsfRecpRecpID, 6)
                    
                    '@ﾚｼﾋﾟID列幅変更(▼幅加算)
                    '.Cols(CMlngvsfRecpRecpID).Width = .Cols(CMlngvsfRecpRecpID).Width  + CMlngvsfRecpCmbWidth                     'ﾚｼﾋﾟID
                End If
            End With

        Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "vsfRecp_AfterEdit"      '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_Change
    '機　能：作業メモ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/26 (Wed) 18:12:20 M.Miura
    '更新日：2005/11/22 (Tue) 14:53:42 N.Kasai
    '備　考：
    '　　　：2005/11/22 (Tue) 14:53:42 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change
        
        Dim llngNowByte As Integer 'ﾊﾞｲﾄ数
        
        Try
            
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtWorkMemo.NowByte
            
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispRow, cmdMemoUp, cmdMemoDown)
            
                                 
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "txtWorkMemo_Change"          '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
                                 
        End Try
    End Sub

    '関数名：cmdMemoUp_Click
    '機　能：作業メモの前頁切替
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/27 (Thu) 09:16:03 M.Miura
    '更新日：2005/11/22 (Tue) 13:09:17 N.Kasai
    '備　考：
    '　　　：2005/11/22 (Tue) 13:09:17 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdMemoUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoUp.Click
        
        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispRow, cmdMemoUp, cmdMemoDown)
            
        Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdMemoUp_Click"        '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoDown_Click
    '機　能：作業メモの次頁切替
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/27 (Thu) 09:16:18 M.Miura
    '更新日：2005/11/22 (Tue) 13:11:08 N.Kasai
    '備　考：
    '     ：2005/11/22 (Tue) 13:11:08 N.Kasai   ｽｸﾛｰﾙ連動
    Private Sub cmdMemoDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoDown.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
         
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispRow, cmdMemoUp, cmdMemoDown)

        Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdMemoDown_Click"      '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRecp_ComboCloseUp
    '機　能：ｺﾝﾎﾞ選択時処理
    '引　数：Row：行
    '　　　：Col：列
    '　　　：FinishEdit：True：編集完了、False：編集未
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 15:18:05 M.Miura
    '更新日：2005/05/06 (Fri) 11:27:44 N.Kojima
    '備　考：2004/09/22 (Wed) 15:40:13 Y.Yamagishi　ﾚﾁｸﾙ行追加(不具合改善№722)
    '　　　：2004/09/27 (Mon) 21:30:11 Y.Yamagishi　右ｽｸﾛｰﾙ制御処理追加
    '　　　：2005/01/18 (Tue) 08:51:59 N.Kasai      ﾚｼﾋﾟｺﾒﾝﾄに改行ｺｰﾄﾞをｽﾍﾟｰｽに置き換える(不具合№407)
    '　　　：2005/01/26 (Wed) 14:19:20 N.Kasai      CMP対応(不具合№304)
    '　　　：2005/02/07 (Mon) 09:08:27 N.Kasai      ﾚｼﾋﾟIDのﾕｰｻﾞ変更ﾌﾗｸﾞが設定済みの場合、複数ﾚｼﾋﾟﾎﾞﾃﾞｨをｸﾘｱする。
    '　　　：2005/05/06 (Fri) 11:27:44 N.Kojima     取得ﾚｼﾋﾟ一覧のﾁｪｯｸ処理のﾙｰﾌﾟｶｳﾝﾀを修正。
    Private Sub vsfRecp_ComboCloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles vsfRecp.ComboCloseUp
        
        Dim lstrRecpID                  As String   'ﾚｼﾋﾟID
        Dim lstrNowWFID                 As String   'WFIDを退避
        Dim lblnOK                      As Boolean  'ﾌﾗｸﾞ
        Dim llngCnt                     As Integer  'ｶｳﾝﾄ
        Dim llngClearRowCnt             As Integer  'ｸﾘｱする行数
        Dim llngClearStartRow           As Integer  'ｸﾘｱする開始行
        Dim llngIndex                   As Integer  '構造体読込み対象ｲﾝﾃﾞｯｸｽ
        Dim lstrSlotNo                  As String   'ｽﾛｯﾄ№退避

        Try
           
            'NSYS データ行がない場合は処理を抜ける
            If vsfRecp.Rows.Count <= vsfRecp.Rows.Fixed Then
                Return
            End If
            

            '@ｺﾝﾎﾞﾎﾞｯｸｽ表示
            With vsfRecp
                '@-------------------
                '@ｺﾝﾎﾞ使用可否判定
                '@-------------------
                '@対象行がﾍｯﾀﾞ以外の場合
                If .Row < .Rows.Fixed Then
                    .Rows.DefaultSize = CMvsfRecpHeight
                    Exit Sub
                End If
                '@対象列がﾚｼﾋﾟID以外の場合
                If .Col <> CMlngvsfRecpRecpID Then
                    .Rows.DefaultSize = CMvsfRecpHeight
                    Exit Sub
                End If
                
                '@----------------------
                '@ｺﾝﾎﾞ変更(ﾚｼﾋﾟIDを取得)
                '@----------------------
                Dim cmb As ComboBox = CType(.Editor, ComboBox)
                If cmb.SelectedIndex >= 0 Then
                    '@ﾚｼﾋﾟID格納
                    lstrRecpID = cmb.Items(cmb.SelectedIndex)
                Else
                    '@ﾚｼﾋﾟID格納
                    lstrRecpID = .GetDataDisplay(.Row, CMlngvsfRecpRecpID)
                End If
                 
                '@判定用変数の初期化
                lblnOK = False
                
                
                '@ﾃﾞﾌｫﾙﾄｲﾝﾃﾞｯｸｽの初期化
                llngIndex = -1
                
                '@-------------------------------------------------------------------------------------
                '@↓初期値ﾛｯﾄﾚｼﾋﾟの場合
                '@ﾛｯﾄﾚｼﾋﾟの場合ﾚｼﾋﾟIDは１件の為ﾃﾞﾌｫﾙﾄﾚｼﾋﾟを取得する。
                '@枚葉の場合はﾚｼﾋﾟIDが複数設定できるのでｺﾝﾎﾞで選択されたﾚｼﾋﾟIDの№を取得し、構造体のINDEXと比較する
                '@-------------------------------------------------------------------------------------
                If mlngClassRecp = CMlngLotRecp Then
                    '@ﾃﾞﾌｫﾙﾄｲﾝﾃﾞｯｸｽ設定
                    llngIndex = 0
                Else
                    '@№判定
                    If IsNumeric(.GetData(.Row, CMlngvsfRecpNo)) = True Then
                        '@ｲﾝﾃﾞｯｸｽを取得する。
                        lstrSlotNo = .GetData(.Row, CMlngvsfRecpNo)
                    
                        '@ﾚｼﾋﾟﾘｽﾄがなくなるまで
                        For llngCnt = 0 To ptypRecp23List.Count-1


                            '@↓2020/06/05 (Fri) 11:13:04 T.Oide 「.Netへ反映未」 **************************************************
                            ''@同じﾚｼﾋﾟIDの場合
                            'If ptypRecp23List(llngCnt).strSlotPosition = lstrSlotNo Then
                            '@-------------------------------------------------------------------------------------------------------
                            '@同じｽﾛｯﾄﾎﾟｼﾞｼｮﾝで、同じﾚｼﾋﾟIDの場合
                            If ptypRecp23List(llngCnt).strSlotPosition = lstrSlotNo And _
                                ptypRecp23List(llngCnt).strRecipeId = lstrRecpID Then
                            '@↑2020/06/05 (Fri) 11:13:04 T.Oide 「.Netへ反映未」 **************************************************

                                '@ﾚｼﾋﾟID発見
                                llngIndex = llngCnt
                                Exit For
                            End If
                        Next
                    Else
                        '@ﾃﾞﾌｫﾙﾄｲﾝﾃﾞｯｸｽの初期化
                        llngIndex = -1
                    End If
                End If
                
                '@ﾘｽﾄｲﾝﾃﾞｯｸｽ判定
                If llngIndex = -1 Then
                    '@--------------------------------------
                    '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟに存在しない場合
                    '@選択されたﾚｼﾋﾟIDをﾏｽﾀ構造体より取得する。
                    '@(ｺﾝﾎﾞのｲﾝﾃﾞｯｸｽの値ではNG)
                    '@--------------------------------------
                    '@ﾚｼﾋﾟﾘｽﾄがなくなるまで
                    For llngCnt = 0 To ptypRecp02List.Count-1
                        '@同じﾚｼﾋﾟIDの場合
                        If ptypRecp02List(llngCnt).strRecipeId = lstrRecpID Then
                            '@ﾚｼﾋﾟID発見
                            lblnOK = True
                            Exit For
                        End If
                    Next
                    
                    '@------------------------
                    '@ﾏｽﾀにﾚｼﾋﾟIDが存在した場合
                    '@------------------------
                    If lblnOK = True Then
                        '@ﾏｽﾀ構造体のｲﾝﾃﾞｯｸｽを設定
                        llngIndex = llngCnt
                       '@ｺﾝﾎﾞ変更後ﾚｼﾋﾟ設定
                        Call prvComboChang_Set(ptypRecp02List, llngIndex)
                    Else
                        '@---------------------------------------------------------
                        '@ﾃﾞﾌｫﾙﾄ、ﾏｽﾀ構造体にも存在しない場合
                        '@(測定条件可能でﾕｰｻﾞ変更可の場合 = ｺﾝﾎﾞで空白を選択された場合)
                        '@---------------------------------------------------------
                        
                        llngClearStartRow = 0       'ｸﾘｱ開始行取得
                        llngClearRowCnt = 0         'ｸﾘｱ行数
                        
                        '@現在のWFIDを格納する。
                        lstrNowWFID = .GetData(.Row, CMlngvsfRecpWFID)
                        '@------------------------------------
                        '@表示ｸﾘｱ処理開始
                        '@　ﾚｼﾋﾟﾎﾞﾃﾞｨが複数存在することを考慮する。
                        '@------------------------------------
                        For llngCnt = 1 To .Rows.Count - 1
                            '@現在のWFIDと同一の場合はﾚｼﾋﾟﾎﾞﾃﾞｨ分をｸﾘｱする。
                            If lstrNowWFID = .GetData(llngCnt, CMlngvsfRecpWFID) Then
                                .SetData(llngCnt, CMlngvsfRecpItem, vbNullString)
                                .SetData(llngCnt, CMlngvsfRecpValue, vbNullString)
                                .SetData(llngCnt, CMlngvsfRecpVariable, vbNullString)
                                .SetData(llngCnt, CMlngvsfRecptype, vbNullString)
                                .SetData(llngCnt, CMlngvsfRecpDigit, vbNullString)
                                .SetData(llngCnt, CMlngvsfRecpComment, vbNullString)
                        
                                '@ﾊﾞｯｸｶﾗｰを入力ｶﾗｰに変更
                                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                                Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfRecpValue)
                                cellRange.Style = newStyle
                                llngClearRowCnt = llngClearRowCnt + 1
                                If llngClearStartRow < 1 Then
                                    llngClearStartRow = llngCnt
                                    RemoveHandler vsfRecp.BeforeRowColChange, AddressOf vsfRecp_BeforeRowColChange
                                    .Row = llngCnt
                                    AddHandler vsfRecp.BeforeRowColChange, AddressOf vsfRecp_BeforeRowColChange
                                End If
                            End If
                        Next
                        
                        '@ﾚｼﾋﾟﾎﾞﾃﾞｨ分行削除
                        .Redraw = False 
                        Do While llngClearRowCnt - 1 > 0
                            '@行数を設定(現在のﾚﾁｸﾙ数と異なる数だけ行を削除)                              
                            .RemoveItem(llngClearStartRow + 1)    
                            llngClearRowCnt = llngClearRowCnt - 1
                        Loop
                        .Redraw = True 
                    End If
                Else
                    '@------------------------------------------------------------------
                    '@ﾚｼﾋﾟIDを判定する。
                    '@　ｺﾝﾎﾞ選択されたﾚｼﾋﾟIDがﾃﾞﾌｫﾙﾄ構造体に存在する場合は
                    '@　　ptypRecp23List(ﾃﾞﾌｫﾙﾄ構造体)より取得
                    '@　上記以外の場合は
                    '@　　ptypRecp02List(ﾏｽﾀ構造体)より取得
                    '@------------------------------------------------------------------
                    If ptypRecp23List(llngIndex).strRecipeId = lstrRecpID Then
                        '@ｺﾝﾎﾞ変更後ﾚｼﾋﾟ設定
                        Call prvComboChang_Set(ptypRecp23List, llngIndex)
                    Else
                        '@--------------------------------------
                        '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟに存在しない場合
                        '@選択されたﾚｼﾋﾟIDをﾏｽﾀ構造体より取得する。
                        '@(ｺﾝﾎﾞのｲﾝﾃﾞｯｸｽの値ではNG)
                        '@--------------------------------------
                        '@ﾚｼﾋﾟﾘｽﾄがなくなるまで
                        For llngCnt = 0 To ptypRecp02List.Count-1
                            '@同じﾚｼﾋﾟIDの場合
                            If ptypRecp02List(llngCnt).strRecipeId = lstrRecpID Then
                                '@ﾚｼﾋﾟID発見
                                lblnOK = True
                                Exit For
                            End If
                        Next
                        
                        '@------------------------
                        '@ﾏｽﾀにﾚｼﾋﾟIDが存在した場合
                        '@------------------------
                        If lblnOK = True Then
                            '@ﾏｽﾀ構造体のｲﾝﾃﾞｯｸｽを設定
                            llngIndex = llngCnt
                           '@ｺﾝﾎﾞ変更後ﾚｼﾋﾟ設定
                            Call prvComboChang_Set(ptypRecp02List, llngIndex)
                        Else
                            '@---------------------------------------------------------
                            '@ﾃﾞﾌｫﾙﾄ、ﾏｽﾀ構造体にも存在しない場合
                            '@(測定条件可能でﾕｰｻﾞ変更可の場合 = ｺﾝﾎﾞで空白を選択された場合)
                            '@---------------------------------------------------------
                            
                            llngClearStartRow = 0       'ｸﾘｱ開始行取得
                            llngClearRowCnt = 0         'ｸﾘｱ行数
                            
                            '@現在のWFIDを格納する。
                            lstrNowWFID = .GetData(.Row, CMlngvsfRecpWFID)
                            '@------------------------------------
                            '@表示ｸﾘｱ処理開始
                            '@　ﾚｼﾋﾟﾎﾞﾃﾞｨが複数存在することを考慮する。
                            '@------------------------------------
                            For llngCnt = 1 To .Rows.Count - 1
                                '@現在のWFIDと同一の場合はﾚｼﾋﾟﾎﾞﾃﾞｨ分をｸﾘｱする。
                                If lstrNowWFID = .GetData(llngCnt, CMlngvsfRecpWFID) Then
                                    .SetData(llngCnt, CMlngvsfRecpItem, vbNullString)
                                    .SetData(llngCnt, CMlngvsfRecpValue, vbNullString)
                                    .SetData(llngCnt, CMlngvsfRecpVariable, vbNullString)
                                    .SetData(llngCnt, CMlngvsfRecptype, vbNullString)
                                    .SetData(llngCnt, CMlngvsfRecpDigit, vbNullString)
                                    .SetData(llngCnt, CMlngvsfRecpComment, vbNullString)
                                
                                    '@ﾊﾞｯｸｶﾗｰを入力ｶﾗｰに変更
                                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                                    Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfRecpValue)
                                    cellRange.Style = newStyle
                                    llngClearRowCnt = llngClearRowCnt + 1
                                    If llngClearStartRow < 1 Then
                                        llngClearStartRow = llngCnt
                                        RemoveHandler vsfRecp.BeforeRowColChange, AddressOf vsfRecp_BeforeRowColChange
                                        .Row = llngCnt
                                        AddHandler vsfRecp.BeforeRowColChange, AddressOf vsfRecp_BeforeRowColChange
                                    End If
                                End If
                            Next
                            
                            '@ﾚｼﾋﾟﾎﾞﾃﾞｨ分行削除
                            .Redraw = False
                            Do While llngClearRowCnt - 1 > 0
                                '@行数を設定(現在のﾚﾁｸﾙ数と異なる数だけ行を削除)
                                    
                                .RemoveItem(llngClearStartRow + 1)     
                                llngClearRowCnt = llngClearRowCnt - 1
                            Loop
                            .Redraw = True
                        End If
                    End If
                End If
                
                '@編集完了
                .FinishEditing()

                '@行の高さ指定
                For llngCnt = 1 To .Rows.Count - 1
                    .Rows(llngCnt).Height = CMvsfRecpHeight
                Next llngCnt
                .Rows.DefaultSize = CMvsfRecpHeight
                .Rows(0).Height = CMlngvsfTitleRowHeight
                
                '@変更後ﾚｼﾋﾟを格納
                Call prvRecp_Set(False)
                Call vsfRecp_AfterEdit(vsfRecp, New RowColEventArgs(.Row, CMlngvsfRecpRecpID))

                '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
                Call pubCmdLREnable_Set(vsfRecp, cmdLeft, cmdRight)
                
            End With
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfRecp_ComboCloseUp"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Change
    '機　能：ｷｬﾘｱID変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/04 (Wed) 16:01:56 M.Miura
    '更新日：2008/07/03 (Thu) 09:43:51 M.Koni
    '備　考：
    '　　　：2008/07/03 (Thu) 10:02:45 M.Koni       ﾃﾞﾌｫﾙﾄ端末外の色変え処理追加<案件No.03006>
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change

        Try
            
            '@ﾌｫｰﾑﾛｰﾄﾞ中は使用不可
            If IsNothing(Me.CancelButton) Then
                Exit Sub
            End If
            
            '@ﾛｯﾄ情報の初期化
            Call frmxxCM0050_Init(false)
            
            '@ﾎﾞﾀﾝ状態
            Call prvfrmxxCM0050_CmbInit(False)
            
            '@装置ｸﾞﾘｯﾄﾞ初期化
            Call prvvsfWP_init()
            
            '@ｸﾞﾘｯﾄﾞ表示の初期化
            Call prvvsfRecp_Init(CMlngVsfInit)
            
        '@↓2008/07/03 (Thu) 09:43:46 M.Koni **************************************************
            '@ｺﾝﾄﾛｰﾙの項目欄の色を初期化
            Call prvColor_init()
        '@↑2008/07/03 (Thu) 09:43:46 M.Koni **************************************************

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "txtCarrier_Change"      '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Validate
    '機　能：ｷｬﾘｱID入力ﾁｪｯｸ
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/04 (Wed) 18:10:18 M.Miura
    '更新日：2008/07/02 (Wed) 08:43:34 M.Koni
    '備　考：2004/09/22 (Wed) 10:23:38 Y.Yamagishi  装置ｸﾞﾘｯﾄﾞ情報からﾚｼﾋﾟを取得するため、ここではﾚｼﾋﾟ情報取得は行わない。
    '　　　：2005/11/22 (Tue) 15:11:33 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2008/07/02 (Wed) 08:45:01 M.Koni       自端末の自動選択＆ﾃﾞﾌｫﾙﾄ端末外の色変え処理追加<案件No.03006>
    Private Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim lblnAns                 As Boolean              '戻り値
        Dim llngRowCnt              As Integer              '装置ﾘｽﾄ列位置ｶｳﾝﾀ
        Dim llngRowSetPosition      As Integer              '対象装置の行番号
        Dim llngCnt1                As Integer              '汎用ｶｳﾝﾀ1
        Dim llngCnt2                As Integer              '汎用ｶｳﾝﾀ2
        Dim llngWpCount             As Integer              '端末WP_ID数
        Dim lstrWpNameAtList        As String               '装置ﾘｽﾄ内のWPID
        Dim lstrWpNameByTerminal    As String               'ﾃﾞﾌｫﾙﾄWPID
        Dim lstrCurrentWpID         As String               'ｶﾚﾝﾄのWPID
        Dim lblnWpIDMatch           As Boolean              'WPID一致ﾌﾗｸﾞ
        Dim lblnNextCtrl            As Boolean              'NSYS Focus設定フラグ

        Dim ltypTmInfo              As UtilRefTmInfo        '端末設定情報格納
        
        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            
            '@ｴﾗｰ発生箇所の初期化
            ptypOnErrorInfo.strErrPositionDetail = vbNullString

            
            '@親画面から起動された場合は抜ける
            If pblnfrmxxCM0050Kbn = True Then
                Exit Sub
            End If

            ' NSYS フォーカス設定可能か判定
            If Me.ActiveControl.Name = txtCarrier.Name OrElse Me.ActiveControl.Name = vsfWP.Name Then
                ' 次コントロールがアクティブの場合
                lblnNextCtrl = True
            Else
                ' 次コントロール以外がアクティブの場合
                lblnNextCtrl = False
            End If
            
            '@ｷｬﾘｱIDの空白ﾁｪｯｸ
            If Trim(txtCarrier.Text) = vbNullString Then
                
                '@ｴﾗｰ位置詳細情報の設定
                ptypOnErrorInfo.strErrPositionDetail = "cmdClose"
                
                '@空ENTERの場合はﾌｫｰｶｽ移動
                Call pubSetFocus(cmdClose)
                
                '@ｴﾗｰ位置詳細情報のｸﾘｱ
                ptypOnErrorInfo.strErrPositionDetail = vbNullString
                
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtCarrier.NowByte < txtCarrier.ChrMaxByte Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"ｷｬﾘｱIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                e.Cancel = True
                Exit Sub
            End If
            
            '@前回ｷｬﾘｱIDと同じ場合
            If txtCarrier.Text = mstrCarrier Then
                '@ﾌｫｰｶｽ移動
                If vsfWp.Enabled = True Then
                    '@ｴﾗｰ位置詳細情報の設定
                    ptypOnErrorInfo.strErrPositionDetail = "vsfWP"
                    
                    If lblnNextCtrl Then 
                      '@空ENTERの場合はﾌｫｰｶｽ移動
                       Call pubSetFocus(vsfWp)
                    End If 

                    '@ｴﾗｰ位置詳細情報のｸﾘｱ
                    ptypOnErrorInfo.strErrPositionDetail = vbNullString
                Else
                    '@ｴﾗｰ位置詳細情報の設定
                    ptypOnErrorInfo.strErrPositionDetail = "cmdClose"
                    
                    If lblnNextCtrl Then
                      '@空ENTERの場合はﾌｫｰｶｽ移動
                      Call pubSetFocus(cmdClose)
                    End if
                    '@ｴﾗｰ位置詳細情報のｸﾘｱ
                    ptypOnErrorInfo.strErrPositionDetail = vbNullString
                End If
                
                Exit Sub
            End If
            
            '@ﾌﾗｸﾞ判定開始(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
            pblnfrmxxCM0050CVFlag = False
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, CMstrCarrierValidate)

            '@【ﾛｯﾄ現在状態取得】
            '@CPstrCD1K:ﾛｯﾄ現在状態取得(ﾚｼﾋﾟ設定変更)
            lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, CPstrCD1K, txtCarrier.Text, ptypLotprestate)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, CMstrCarrierValidate)
                
                e.Cancel = True
                
                '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
                pblnfrmxxCM0050CVFlag = True
                
                Exit Sub
            End If
                    
            '@ｷｬﾘｱIDを退避
            pstrCarrierID = txtCarrier.Text
                
            '@pblnWpIDNullFlagは作業開始画面より連動するﾌﾗｸﾞ(True:WP_ID=NULL)
            '@新規で取得する為Null設定
            pblnWpIDNullFlag = True

            '@画面表示処理
            Call frmxxCM0050_Disp(pblnWpIDNullFlag)

            '@装置(WPID)一覧の設定
            lblnAns = prvvsfWP_Disp(ptypLotprestate)
            If lblnAns = False Then
            
                '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                e.Cancel = True
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, CMstrCarrierValidate)
                
                '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
                 pblnfrmxxCM0050CVFlag = True

                Exit Sub
            End If

        '@↓2008/06/26 (Thu) 15:15:08 M.Koni **************************************************

            llngWpCount = 0                     '割り当て装置数のｸﾘｱ
            lstrCurrentWpID = vbNullString      '現在WP_IDのｸﾘｱ
            lblnWpIDMatch = False               '装置ﾘｽﾄ内一致ﾌﾗｸﾞを初期化
            pblnWpSelectFlag = False            '自端末の装置選択ﾌﾗｸﾞを初期化
                
            '@【端末設定情報取得】ﾒｯｾｰｼﾞ送受信処理 "util.reftminfo"
            lblnAns = pubblnUtilRefTmInfo_Sel(pstrSBID, _
                                              CMstrutilreftminfoVer, _
                                              pstrComputerName, _
                                              ltypTmInfo) '

            '@通信結果判定
            If lblnAns = True Then
                '@結果：正常の場合
                    With ltypTmInfo
                        '@端末情報が取得出来たか
                        If .strMcGroupID <> vbNullString Then
                            '@取得したWPIDを変数に格納
                            llngWpCount = .lngWpListCount               '端末に割当られた装置数入手
                            lstrCurrentWpID = .strWpID                  '現設定WP入手
                        End If
                    End With

                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Name, CMstrCarrierValidate)

                    With vsfWp
                        '@行ｶｳﾝﾀ初期化
                        llngRowCnt = 0
                        llngRowSetPosition = 0

                        '@装置ｸﾞﾘｯﾄ読み出し＆WPID比較
                        For llngCnt1 = 1 To .Rows.Count - 1
                            lstrWpNameAtList = .GetData(llngCnt1, CMvsfWPColWpID)
                            llngRowCnt = llngRowCnt + 1

                        For llngCnt2 = 0 To llngWpCount - 1
                            lstrWpNameByTerminal = ltypTmInfo.typWpList(llngCnt2).strDefaultWpID

                            '@装置ﾘｽﾄ内に，自端末のWPIDがあるか？
                            If StrComp(lstrWpNameByTerminal, lstrWpNameAtList, 1) = 0 Then
                                lblnWpIDMatch = True
                                llngRowSetPosition = llngRowCnt                             '行位置格納
                                '@あったらそのWPIDは，現在選択中のWPIDに一致しているか？
                                If StrComp(lstrCurrentWpID, lstrWpNameByTerminal, 1) = 0 Then
                                    pblnWpSelectFlag = True
                                End If
                            End If
                        Next

                        If pblnWpSelectFlag = True Then
                                Exit For
                            End If
                        Next
                    End With

            Else
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, CMstrCarrierValidate)
                
            End If
            
        '@↑2008/06/26 (Thu) 15:15:08 M.Koni **************************************************
            
            '@ｷｬﾘｱID比較用
            mstrCarrier = txtCarrier.Text
            
            '@装置ｸﾞﾘｯﾄﾞ設定
            With vsfWp
                '@装置がある場合
                If .Rows.Count > .Rows.Fixed Then
                    '@装置ｸﾞﾘｯﾄﾞを有効
                    .Enabled = True
                    '@装置が一件の場合
                    If .Rows.Count = .Rows.Fixed + 1 Then
                        '@ｸﾞﾘｯﾄﾞ初期表示
                        .Row = .Rows.Fixed
                    Else

                        '@作業ﾒﾓを有効
                        txtWorkMemo.Enabled = True             '作業ﾒﾓ
                        
                        '@----------------------------------------------------------------------------
                        '@ｾｯﾄﾌｫｰｶｽ対応
                        '@  通信や描画に負荷が掛かった場合を考慮してﾌｫｰｶｽを当てるﾀｲﾐﾝｸﾞを遅らす。
                        '@　ﾌｫｰｶｽを当てる場所が複数存在する場合は変数で制御する。(mlngSetFocusFlag)
                        '@　ｾｯﾄﾌｫｰｶｽはﾀｲﾏｰｲﾍﾞﾝﾄに記述
                        '@-----------------------------------------------------------------------------
                        '@ｴﾗｰ位置詳細情報の設定
                        ptypOnErrorInfo.strErrPositionDetail = "txtCarrier_Validate/vsfWP_1"
                        
                        If ActiveControl.Name = txtCarrier.Name 
                            '@ｾｯﾄﾌｫｰｶｽ
                            Call pubSetFocus(vsfWp)
                        End if
                        
                        '@ｴﾗｰ位置詳細情報のｸﾘｱ
                        ptypOnErrorInfo.strErrPositionDetail = vbNullString

                    End If

        '@↓2008/06/26 (Thu) 15:15:08 M.Koni **************************************************

                    '@装置ﾘｽﾄの自動選択処理
                    '@端末1つに対し複数装置が割り当てられている場合は，自動選択を実施しない。
                    If llngWpCount = 1 Then
                        '@装置ﾘｽﾄ内に自端末の装置があった場合，その行番号にフォーカスする。
                        If lblnWpIDMatch = True Then
                            If llngRowSetPosition > 1 Then
                                vsfWp.TopRow = llngRowSetPosition - 1
                            End If
                            vsfWp.Row = llngRowSetPosition          '自端末の装置を選択(vsfWP_AfterRowColChangeｲﾍﾞﾝﾄ発生)
                            '@装置一覧初期ﾎﾞﾀﾝ設定
                            Call pubVsfDisp(vsfWp, cmdUP, cmdDown)
                        End If
                    End If

        '@↑2008/06/26 (Thu) 15:15:08 M.Koni **************************************************

                Else
                    '@装置ｸﾞﾘｯﾄﾞを有効
                    .Enabled = True

                    '@----------------------------------------------------------------------------
                    '@ｾｯﾄﾌｫｰｶｽ対応
                    '@  通信や描画に負荷が掛かった場合を考慮してﾌｫｰｶｽを当てるﾀｲﾐﾝｸﾞを遅らす。
                    '@　ﾌｫｰｶｽを当てる場所が複数存在する場合は変数で制御する。(mlngSetFocusFlag)
                    '@　ｾｯﾄﾌｫｰｶｽはﾀｲﾏｰｲﾍﾞﾝﾄに記述
                    '@-----------------------------------------------------------------------------
                    
                    '@ｴﾗｰ位置詳細情報の設定
                    ptypOnErrorInfo.strErrPositionDetail = "txtCarrier_Validate/vsfWP_2"
                    
                    If ActiveControl.Name = txtCarrier.name
                        '@ｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(vsfWp)
                    End if

                    '@ｴﾗｰ位置詳細情報のｸﾘｱ
                    ptypOnErrorInfo.strErrPositionDetail = vbNullString
                End If
            End With
                
        '@↓2008/06/30 (Mon) 15:52:35 M.Koni **************************************************
            '@ﾃﾞﾌｫﾙﾄ端末で無ければ色を変える
            Call prvColorChang_CM0050()
        '@↑2008/06/30 (Mon) 15:52:35 M.Koni **************************************************

            '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
            pblnfrmxxCM0050CVFlag = True
            
        Exit Sub

        Catch ex As Exception
            
            '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
            pblnfrmxxCM0050CVFlag = True
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "txtCarrier_Validate"    '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUP_Click
    '機　能：前頁ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/18 (Tue) 13:18:38 M.Miura
    '更新日：2004/05/18 (Tue) 13:18:38
    '備　考：
    Private Sub cmdUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUp.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@前頁処理▲
            Call pubVsfCmdUp(vsfWp, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdUp_Click"            '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown_Click
    '機　能：次頁ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/18 (Tue) 13:21:09 M.Miura
    '更新日：2004/05/18 (Tue) 13:21:09
    '備　考：
    Private Sub cmdDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@次頁処理▼
            Call pubVsfCmdDown(vsfWp, cmdUP, cmdDown)
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdDown_Click"          '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRecp_ComboDropDown
    '機　能：ｺﾝﾎﾞ表示処理
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2007/07/09 (Mon) 11:18:01 N.Kasai
    '更新日：2007/07/09 (Mon) 11:18:01
    '備　考：不具合№02037
    Private Sub vsfRecp_ComboDropDown(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfRecp.ComboDropDown

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfRecp.Rows.Count <= vsfRecp.Rows.Fixed Then
                Return
            End If


            With vsfRecp
                '@ｺﾝﾎﾞを表示した際、先頭行が表示ｴﾘｱ外に存在する場合
                If e.Row > .BottomRow Then
                    '現在行を先頭行に移動する。
                    .TopRow = e.Row
                    '@ｸﾞﾘｯﾄﾞ選択の初期化(ｸﾞﾘｯﾄﾞ共通化関数)
                    Call pubVsfDisp(vsfRecp, cmdVsfUP, cmdVsfDown)
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfRecp_ComboDropDown"      '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：vsfRecp_KeyDown
    '機　能：
    '引　数：KeyCode：
    '　　　：Shift：
    '戻り値：
    '作成日：2005/06/06 (Mon) 08:35:04 N.Kasai
    '更新日：2005/06/06 (Mon) 08:35:04
    '備　考：
    Private Sub vsfRecp_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles vsfRecp.KeyDown

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfRecp.Rows.Count <= vsfRecp.Rows.Fixed Then
                Return
            End If
            
           With vsfRecp
              If e.KeyCode = Keys.Back AndAlso (TypeOf .Editor Is TextBox)
                CType(.Editor, TextBox).Clear()
              End If
              If e.KeyCode = Keys.Back AndAlso (TypeOf .Editor Is ComboBox)
                CType(.Editor, ComboBox).Text = ""              'NSYS 値がリストにない場合
                CType(.Editor, ComboBox).SelectedIndex = -1     'NSYS 値がリストにある場合
              End If
           End With
            
             With vsfRecp
                '@ﾚｼﾋﾟID
                If .Col = CMlngvsfRecpRecpID Then
                    '@Enter、矢印、(Alt+F4)Keyは制御外
                    Select Case e.KeyCode
                           Case Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.Return, Keys.F4
                               Exit Sub
                           Case Else
                               e.Handled = True
                    End Select
                End If

                '@ﾚｼﾋﾟ値のみ
                If .Col = CMlngvsfRecpValue Then
                   '@入力可否ﾌﾗｸﾞの判定(入力可否ﾌﾗｸﾞ(1：編集可))
                   If .GetData(.Row, CMlngvsfRecpVariable) = CMlngVariableFlg Then
                    '@ｸﾞﾘｯﾄﾞを編集可能にする
                        .Styles.Editor.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngInputColor))
                       '@ﾚｼﾋﾟ値のｸﾘｱ処理(DELETE,BACKSPACEの場合)
                       Select Case e.KeyCode
                           '@Delete/BackSpaceｷｰの場合
                           Case Keys.Delete, Keys.Back
                               '@Nullにする

                               '@編集処理
                               .StartEditing()
                                cmdClose.CausesValidation = True
                                If e.KeyCode = Keys.Back AndAlso (TypeOf .Editor Is TextBox)
                                    CType(.Editor, TextBox).Clear()
                                End If
                       End Select
                   End If
                End If
            End With

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "vsfRecp_KeyDown"        '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRecp_ValidateEdit
    '機　能：入力値のﾁｪｯｸ(ﾚｼﾋﾟ値)
    '引　数：Row：行
    '　　　：Col：列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/01/26 (Wed) 14:24:19 N.Kasai
    '更新日：2005/01/26 (Wed) 14:24:19
    '備　考：
    Private Sub vsfRecp_ValidateEdit(ByVal sender As Object, ByVal e As ValidateEditEventArgs) Handles vsfRecp.ValidateEdit
        
        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfRecp.Rows.Count <= vsfRecp.Rows.Fixed Then
                Return
            End If

            'NSYS 前回入力した値と比較 カンマ編集対策
            If vsfRecp.Editor.Text = EditorText Then
                EditorFlg = True
            Else
                EditorText = vsfRecp.Editor.Text
                EditorFlg = False
            End If

            '@入力値のﾁｪｯｸ
            '@固定行の場合はｽｷｯﾌﾟ
            If e.Row < vsfRecp.Rows.Fixed Then
                Exit Sub
            End If

            '@編集項目以外はｽｷｯﾌﾟ
            Select Case e.Col
                '@ﾚｼﾋﾟ値列
                Case CMlngvsfRecpValue
                    '@入力可否ﾌﾗｸﾞの判定(1:入力可の場合)
                    If vsfRecp.GetData(e.Row, CMlngvsfRecpVariable) = CMlngVariableFlg Then
                        '@空白の場合はﾁｪｯｸなし
                        If vsfRecp.Editor.Text = vbNullString Then
                            cmdClose.CausesValidation = false
                            Exit Sub
                        End If
                        
                        '@ﾃﾞｰﾀﾀｲﾌﾟの判定(数値の場合)
                        If vsfRecp.GetData(e.Row, CMlngvsfRecptype) = CMstrDataTypeN Then
                            '@数字型ﾁｪｯｸ
                            If IsNumeric(vsfRecp.Editor.Text) = False Then
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001F)
                                '@"数字を入力してください。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                                e.Cancel = True
                                Dim tb As TextBox = vsfRecp.Editor
                                tb.Text = vsfRecp.GetData(e.Row, e.Col)
                                tb.SelectAll()
                                Exit Sub
                            End If
                            'NSYS 全角数値を半角数値に変換する
                            vsfRecp.Editor.Text = StrConv(vsfRecp.Editor.Text, vbNarrow)
                            cmdClose.CausesValidation = False
                        Else
                            '@入力ﾌｨｰﾙﾄﾞの編集後判定
                            For llngCnt = 1 To Len(vsfRecp.Editor.Text)
                                Select Case Mid(vsfRecp.Editor.Text, llngCnt, 1)
                                    Case CMstrNoInputString
                                        '@禁則文字："'"
                                        e.Cancel = True
                                        
                                        Exit For
                                    Case Else
                                        '@禁則文字以外
                                End Select
                            Next llngCnt
                            If e.Cancel = False Then
                                vsfRecp.Editor.Text = vsfRecp.Editor.Text
                                cmdClose.CausesValidation = false
                            Else
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004V, CMstrNoInputString)
                                '@"文字[%1]は入力できません。設定を見直してください。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                e.Cancel = True
                                Dim tb As TextBox = vsfRecp.Editor
                                tb.Text = vsfRecp.GetData(e.Row, e.Col)
                                tb.SelectAll()
                                Exit Sub
                            End If
                        End If
                    End If
            End Select

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "vsfRecp_ValidateEdit"   '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfWP_Click
    '機　能：装置変更のｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/26 (Sun) 17:06:54 T.Kitagawa
    '更新日：2004/09/26 (Sun) 17:06:54
    '備　考：2004/09/26 (Sun) 17:06:54 T.Kitagawa　装置行を変更しなくてもﾚｼﾋﾟGridへﾌｫｰｶｽ移動させる(不具合№675)
    Private Sub vsfWP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfWP.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfWP.Rows.Count <= vsfWP.Rows.Fixed Then
                Return
            End If
            
            '@ｴﾗｰ発生箇所の初期化
            ptypOnErrorInfo.strErrPositionDetail = vbNullString

             '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKeyを受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            With vsfWp
                '@装置行を変更していなくてもﾚｼﾋﾟGridへﾌｫｰｶｽ設定
                If .Row >= .Rows.Fixed Then
                    If vsfRecp.Enabled = True Then
                        '@----------------------------------------------------------------------------
                        '@ｾｯﾄﾌｫｰｶｽ対応
                        '@  通信や描画に負荷が掛かった場合を考慮してﾌｫｰｶｽを当てるﾀｲﾐﾝｸﾞを遅らす。
                        '@　ﾌｫｰｶｽを当てる場所が複数存在する場合は変数で制御する。(mlngSetFocusFlag)
                        '@　ｾｯﾄﾌｫｰｶｽはﾀｲﾏｰｲﾍﾞﾝﾄに記述
                        '@-----------------------------------------------------------------------------
                        '@ｴﾗｰ位置詳細情報の設定
                        ptypOnErrorInfo.strErrPositionDetail = "vsfWP_Click/vsfRecp"
                        
                        '@ﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfRecp)
                        
                        '@ｴﾗｰ位置詳細情報のｸﾘｱ
                        ptypOnErrorInfo.strErrPositionDetail = vbNullString
                    End If
                End If

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "vsfWP_Click"            '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfWP_AfterRowColChange
    '機　能：装置変更処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '戻り値：なし
    '作成日：2004/08/10 (Tue) 15:24:14 M.Miura
    '更新日：2004/09/28 (Tue) 20:22:31 M.Miura
    '備　考：2004/09/03 (Fri) 14:04:55 M.Miura　    選択した大小工程をﾍｯﾀﾞに表示するように修正(不具合№554)
    '備　考：2004/09/28 (Tue) 20:22:31 M.Miura　    ﾚｼﾋﾟ変更可否によりｺﾝﾄﾛｰﾙの有効/無効制御を追加
    '　　　：2005/06/29 (Wed) 15:35:27 S.Deguchi    不具合№212の対応でﾚｼﾋﾟ設定不可条件にﾛｯﾄﾚｼﾋﾟ設定ﾌﾗｸﾞの判別を追加
    '　　　：2005/07/26 (Tue) 13:19:43 S.Deguchi    ﾛｯﾄﾚｼﾋﾟﾌﾗｸﾞの使用方法を修正    
    Private Sub vsfWP_AfterRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfWP.AfterRowColChange

        Dim lblnAns         As Boolean      '結果格納(True:OK/False:NG)
        Dim lstrRecpID      As String       'ﾚｼﾋﾟID
        Dim llngCmbRecpCnt  As Integer      'ﾚｼﾋﾟﾘｽﾄ件数
        Dim lblnNG          As Boolean      '確定ﾎﾞﾀﾝ判定
        Dim llngCnt         As Integer      'ｶｳﾝﾀ
        Dim NewRow          As Integer      'NSYS 新行
        Dim OldRow          As Integer      'NSYS 旧行

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfWP.Rows.Count <= vsfWP.Rows.Fixed Then
                Return
            End If
            
            NewRow = e.NewRange.r1 'NSYS 新行
            OldRow = e.OldRange.r1 'NSYS 旧行

            With vsfWp
                '@ﾀｲﾄﾙではない場合
                If NewRow >= .Rows.Fixed And OldRow <> NewRow Then
                    '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKeyを受け付けない
                    If Cursor.Current = Cursors.WaitCursor Then
                        Exit Sub
                    End If

                    'NSYS VB6と異なり、グリッドの再描画でBeforeEditが動作するので、抑止する
                    'NSYS DataMapにNothingが設定される場合があり、TextAlignがリセットされるため
                    RemoveHandler vsfRecp.BeforeEdit, AddressOf vsfRecp_BeforeEdit
                    
                    '@--------------------------------------
                    '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝのｸﾘｱ
                    '@ｸﾘｱする事で最新のﾚｼﾋﾟを再読込みする為
                    '@--------------------------------------
                    optRecp0.Checked  = False      'ﾛｯﾄﾚｼﾋﾟ
                    optRecp1.Checked  = False      'WFﾚｼﾋﾟ
                
                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(Me.Name, CMstrWpRowColChange)

                    '@選択した大工程、小工程をﾍｯﾀﾞに表示
                    lblOpID.Text = .GetData(NewRow, CMvsfWPColOpID)
                    lblStepID.Text = .GetData(NewRow, CMvsfWPColStepID)
                    
                    '@ﾚｼﾋﾟ情報取得&表示
                    lblnAns = prvblnWfRecpList_Set
                    '@結果判定
                    If lblnAns = False Then
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, CMstrWpRowColChange)

                        AddHandler vsfRecp.BeforeEdit, AddressOf vsfRecp_BeforeEdit
                        Exit Sub
                    End If

                    '@WF一覧ﾃﾞｰﾀがあり、ﾛｯﾄﾚｼﾋﾟの場合
                    If vsfRecp.Rows.Count > vsfRecp.Rows.Fixed And optRecp0.Checked  = True Then
                        '@ﾚｼﾋﾟIDを格納
                        lstrRecpID = vsfRecp.GetDataDisplay(vsfRecp.Rows.Fixed, CMlngvsfRecpRecpID)
                    End If

                    '@ﾚｼﾋﾟﾘｽﾄ件数が数値の場合
                    If IsNumeric(vsfWp.GetData(vsfWp.Row, CMvsfWPColRecpListCnt)) = True Then
                        '@ﾚｼﾋﾟﾘｽﾄ件数格納
                        llngCmbRecpCnt = CLng((vsfWp.GetData(vsfWp.Row, CMvsfWPColRecpListCnt)))
                    End If

                    '@---------------------------------------------------------
                    '@ﾛｯﾄﾚｼﾋﾟ/WFﾚｼﾋﾟｵﾌﾟｼｮﾝﾎﾞﾀﾝの制御
                    '@　mstrProcChangeRecipeFlag  工順変更ﾚｼﾋﾟﾌﾗｸﾞ(0：ﾚｼﾋﾟ変更可、1:ﾚｼﾋﾟ変更不可)
                    '@　mstrUserSelectFlag        ﾕｰｻﾞｰ選択ﾌﾗｸﾞ(0：変更不可、1：変更可)
                    '@　CPstrEqTypeBatch          EQ_TYPE(1:ﾊﾞｯﾁ装置)
                    '@
                    '@○ﾚｼﾋﾟ変更不可の条件○
                    '@
                    '@　工順変更ﾚｼﾋﾟ設定済み
                    '@　ﾕｰｻﾞ選択不可
                    '@　ﾚｼﾋﾟ無し(ｺﾝﾎﾞﾚｼﾋﾟなし)
                    '@　ﾊﾞｯﾁ装置の場合
                    '@　ﾛｯﾄﾚｼﾋﾟ設定ﾌﾗｸﾞ="1"の場合
                    '@---------------------------------------------------------

                    '@ﾛｯﾄﾚｼﾋﾟﾌﾗｸﾞが"1"の場合の処理を見直し
                    If mstrProcChangeRecipeFlag = CMstrProcChangeRecipeFlag1 Or
                       mstrUserSelectFlag = CMstrUserSelectFlag0 Or
                       llngCmbRecpCnt = 0 Or
                       (mstrUserSelectFlag <> vbNullString _
                        And .GetData(NewRow, CMvsfWPColEqType) = CPstrEqTypeBatch) Then

                        '@ﾚｼﾋﾟ変更ﾌﾗｸﾞ(不可)
                        mblnChgRecpFlag = False
                    Else
                        '@ﾚｼﾋﾟ変更ﾌﾗｸﾞ(可能)
                        mblnChgRecpFlag = True
                    End If
                    
                    '@------------------
                    '@ﾚｼﾋﾟ変更不可の場合
                    '@------------------
                    If mblnChgRecpFlag = False Then
        '                '@取消ﾎﾞﾀﾝを無効
        '                cmdCancel.Enabled = False
                        '@ｺﾝﾄﾛｰﾙ無効
                        optRecp0.Enabled = False       'ﾛｯﾄﾚｼﾋﾟ
                        optRecp1.Enabled = False        'WFﾚｼﾋﾟ
                    Else
                        '@ﾊﾞｯﾁ装置の場合はWFﾚｼﾋﾟ選択不可
                        If .GetData(NewRow, CMvsfWPColEqType) = CPstrEqTypeBatch Then
                            optRecp1.Enabled = False    'WFﾚｼﾋﾟ
                            optRecp1.Checked  = False
                        End If
                        
                        '@ﾛｯﾄﾚｼﾋﾟﾌﾗｸﾞでﾚｼﾋﾟの切替えを制御する
                        If .GetData(NewRow, CMvsfWPColLotRecipeFlag) = CMstrLotRecipeFlag1 Then
                            optRecp1.Enabled = False    'WFﾚｼﾋﾟ
                            optRecp1.Checked  = False
                        End If
                    End If
                    
                    '@---------------------------------------------------------
                    '@確定ﾎﾞﾀﾝの制御
                    '@ CMstrNoneRecipe:"レシピ無し"
                    '@○条件○
                    '@装置が複数あり、ﾚｼﾋﾟ設定変更可でﾚｼﾋﾟがある場合
                    '@---------------------------------------------------------
                    If .Rows.Count >= .Rows.Fixed + 1 And mblnChgRecpFlag = True Then
                        '@ﾚｼﾋﾟ無しでﾛｯﾄﾚｼﾋﾟの場合
                        If (lstrRecpID = vbNullString Or lstrRecpID = CMstrNoneRecipe) And _
                            optRecp0.Checked  = True Then
                        Else
                            '@ﾚｼﾋﾟID存在ﾁｪｯｸ
                            lblnAns = prvblnRecp_Chk
                            '@ﾚｼﾋﾟIDがある場合
                            If lblnAns = True Then
                            
                                lblnNG = False  'NGﾌﾗｸﾞ初期化(True：NG、False：OK)
                                
                                '@確定ﾎﾞﾀﾝの制御
                                For llngCnt = 1 To vsfRecp.Rows.Count - 1
                                    '@入力可否ﾌﾗｸﾞの判定(入力可否ﾌﾗｸﾞ(1：編集可))
                                    If vsfRecp.GetData(llngCnt, CMlngvsfRecpVariable) = CMlngVariableFlg Then
                                        '@ﾚｼﾋﾟﾊﾟﾗﾒｰﾀが設定されていない場合
                                        If vsfRecp.GetData(llngCnt, CMlngvsfRecpValue) = vbNullString Then
                                            lblnNG = True
                                            Exit For
                                        End If
                                    End If
                                Next
                            
                                '@確定ﾎﾞﾀﾝ使用可否
                                If lblnNG = True Then
                                    '@使用不可
                                    cmdKakutei.Enabled = False
                                Else
                                    '@使用可
                                    cmdKakutei.Enabled = True
                                End If
                                
                            Else
                                '@確定ﾎﾞﾀﾝ無効
                                cmdKakutei.Enabled = False
                            End If
                        End If
                    End If

                    AddHandler vsfRecp.BeforeEdit, AddressOf vsfRecp_BeforeEdit
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Name, CMstrWpRowColChange)
                End if
            End With

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfWP_AfterRowColChange"    '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRecp_AfterUserResize
    '機　能：列変更時処理
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2004/09/07 (Tue) 10:15:49 M.Miura
    '更新日：2007/07/09 (Mon) 12:11:59 N.Kasai
    '備　考：
    '　　　：2007/07/09 (Mon) 12:11:59 N.Kasai  ｸﾞﾘｯﾄﾞ共通化
    Private Sub vsfRecp_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfRecp.AfterResizeColumn, vsfRecp.AfterResizeRow
        
        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfRecp.Rows.Count <= vsfRecp.Rows.Fixed Then
                Return
            End If
            
            
            '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
            Call pubCmdLREnable_Set(vsfRecp, cmdLeft, cmdRight)
            
            '@列幅変更ﾌﾗｸﾞ(変更)
            mtypChgSort.blnChgWidth = True
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfRecp_AfterUserResize"    '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：frmxxCM0050_Init
    '機　能：ﾒｲﾝﾌｫｰﾑの初期化
    '引　数：lblnCarrier:True：ｷｬﾘｱID初期化、False：ｷｬﾘｱID保持
    '戻り値：なし
    '作成日：2004/03/04 (Thu) 12:46:52 T.Oide
    '更新日：2008/06/10 (Tue) 16:38:22 N.Kojima
    '備　考：
    '　　　：2004/09/03 (Fri) 16:51:32 M.Miura　    工順変更ﾚｼﾋﾟﾌﾗｸﾞを追加(不具合№270)
    '　　　：2004/10/04 (Mon) 10:20:20 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2008/06/10 (Tue) 16:38:22 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub frmxxCM0050_Init(Optional ByVal lblnCarrier As Boolean = True) 
            
        Dim llngNowByte         As Integer  'ﾊﾞｲﾄ数
        Dim lstrFormTitle       As String   'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        
        Try
                      
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00S0, lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@ｷｬﾘｱIDを初期化する場合
            If lblnCarrier = True Then
                txtCarrier.Text = vbNullString          'ｷｬﾘｱID
            End If
            
            '@---------
            '@画面初期化
            '@---------
            '@ﾗﾍﾞﾙ----------------------------------------------------
            lblLotID.Text = vbNullString             'ﾛｯﾄID
            lblFlowClass.Text = vbNullString         '流動区分
            lblWFNo.Text = vbNullString              'FW枚数
            lblOpID.Text = vbNullString              '大工程ID
            lblStartDayTime.Text = vbNullString      '開始日時
            lblPdID.Text = vbNullString              '機種名
            lblS.Text = vbNullString                 '特殊特性
            lblStatus.Text = vbNullString            '状態
            lblStepID.Text = vbNullString            '小工程ID
            lblLotManager.Text = vbNullString        'ﾛｯﾄ担当者名
            lblTimeLimit.Text = vbNullString         '時間制約
            lblOriginalRecp.Text = vbNullString      'ﾚｼﾋﾟ設定
            '@↓2020/01/11 (Sat) 17:08:18 Y.Yoneyama 「.Netへ反映未」 **************************************************
            lblGRB.Text = vbNullString               'GRB
            '@↑2020/01/11 (Sat) 17:08:18 Y.Yoneyama 「.Netへ反映未」 **************************************************
            
            '@ﾃｷｽﾄ-----------------------------------------------------
            '@ｷｬﾘｱ
            With txtCarrier
                '@親画面から起動された場合
                If pblnfrmxxCM0050Kbn = True Then
                    '@ﾛｯｸ
                    .Locked = True
                    '@ﾀﾌﾞｽﾄｯﾌﾟ(しない)
                    .TabStop = False
                    '@背景色(灰)
                    .BackColor = vbButtonFace
                    .GotBackColor = vbButtonFace
                    '@ﾊｲﾗｲﾄ(しない)
                    .GotHighLight = False
                    
                    '@ｺﾝﾄﾛｰﾙ有効
                    optRecp0.Enabled = True    'ﾛｯﾄﾚｼﾋﾟ
                    optRecp1.Enabled = True     'WFﾚｼﾋﾟ
                    txtWorkMemo.Enabled = True              '作業ﾒﾓ
                Else
                    '@単独起動の場合
                    '@ﾛｯｸ解除
                    .Locked = False
                    '@ﾀﾌﾞｽﾄｯﾌﾟ(する)
                    .TabStop = True
                    '@背景色(白)
                    .BackColor = vbWindowBackground
                    .GotBackColor = vbWindowBackground
                    '@ﾊｲﾗｲﾄ(する)
                    .GotHighLight = True

                    '@ｺﾝﾄﾛｰﾙ無効
                    optRecp0.Enabled = False   'ﾛｯﾄﾚｼﾋﾟ
                    optRecp1.Enabled = False    'WFﾚｼﾋﾟ
                    txtWorkMemo.Enabled = False             '作業ﾒﾓ
                    
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ
                    cmdMemoUp.Enabled = False               '前頁ﾎﾞﾀﾝ
                    cmdMemoDown.Enabled = False             '次頁ﾎﾞﾀﾝ
                    cmdCancel.Enabled = False               '確定ﾎﾞﾀﾝ
                    cmdLeft.Enabled = False                 '左ﾎﾞﾀﾝ
                    cmdRight.Enabled = False                '右ﾎﾞﾀﾝ
                End If
            End With
            
            '@作業ﾒﾓ
            With txtWorkMemo
                .ChrMaxByte = CPlngLotCommentsMaxByte
                .Text = vbNullString
                
                '@ﾊﾞｲﾄ数格納
                llngNowByte = .NowByte
                
                '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            End With
            
            '@---------
            '@変数初期化
            '@---------
            mstrLotLastUpdate = vbNullString            'LOT最終更新日時
            mstrCarrier = vbNullString                  '比較ｷｬﾘｱID
            mstrProcChangeRecipeFlag = vbNullString     '工順変更ﾚｼﾋﾟﾌﾗｸﾞ
            mstrChgRecpBefore = vbNullString            'ﾚｼﾋﾟ変更前
            mstrChgRecpAfter = vbNullString             'ﾚｼﾋﾟ変更後
            mstrUserSelectFlag = vbNullString           'ﾕｰｻﾞｰ選択ﾌﾗｸﾞ
            mblnChgRecpFlag = False                     'ﾚｼﾋﾟ変更ﾌﾗｸﾞ
            
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                If mtypChgSort.typChgSortList Is Nothing 
                   mtypChgSort.typChgSortList = New List(Of ChgSortList)
                Else
                    mtypChgSort.typChgSortList.Clear()
                End If
                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            
            '@閉じるﾎﾞﾀﾝはValidate無効
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "frmxxCM0050_Init"       '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfRecp_Init
    '機　能：ｸﾞﾘｯﾄﾞ初期化
    '引　数：llngRecpMode(0：ﾛｯﾄﾚｼﾋﾟ、1：枚葉ﾚｼﾋﾟ9：ｸﾞﾘｯﾄﾞ初期化)
    '戻り値：なし
    '作成日：2004/05/26 (Wed) 14:13:50 M.Miura
    '更新日：2005/01/26 (Wed) 15:16:39 N.Kasai
    '備　考：2004/09/21 (Tue) 13:56:15 Y.Yamagishi  ﾚﾁｸﾙ列追加(不具合改善№722)
    '　　　：2005/01/26 (Wed) 15:16:39 N.Kasai      CMP対応(不具合№304)
    Private Sub prvvsfRecp_Init(ByVal llngRecpMode As Integer)
        
        Dim llngCnt         As Integer              'Forのｶｳﾝﾄ
        
        Try
            
            '@ｸﾞﾘｯﾄﾞ初期化ではない場合
            If llngRecpMode <> CMlngVsfInit Then
                If llngRecpMode = CMlngLotRecp AndAlso optRecp0.Checked <> True Then
                    '@ﾚｼﾋﾟｵﾌﾟｼｮﾝﾁｪｯｸ
                    optRecp0.Checked = True
                End If

                If llngRecpMode = CMlngWFRecp AndAlso optRecp1.Checked <> True Then
                    '@ﾚｼﾋﾟｵﾌﾟｼｮﾝﾁｪｯｸ
                    optRecp1.Checked = True
                End If

            End If
            
            With vsfRecp
                Select Case llngRecpMode
                    '@ﾛｯﾄﾚｼﾋﾟ
                    Case CMlngLotRecp
                        .Redraw = False
                        '@行数初期化
                        .Rows.Count = .Rows.Fixed
                        '@行数設定
                        .Rows.Count = .Rows.Fixed + 1
                        '@ﾀｲﾄﾙ設定
                        .SetData(.Rows.Fixed, CMlngvsfRecpNo, vbNullString)
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbButtonFace")
                        newStyle.BackColor = vbButtonFace
                        Dim cellRange As CellRange = .GetCellRange(.Rows.Fixed, CMlngvsfRecpNo)
                        cellRange.Style = newStyle    '薄いｸﾞﾚｰ
                        .Cols(CMlngvsfRecpWFID).Visible = False
                        '@↓2020/01/07 (Tue) 15:06:57 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        .Cols(CMlngvsfRecpGRB).Visible = False
                        '@↑2020/01/07 (Tue) 15:06:57 Y.Yoneyama 「.Netへ反映未」 **************************************************

                        '@ｸﾞﾘｯﾄﾞ編集可能
                        .AllowEditing = True
                        .Redraw = True

                        '@有効
                        .Enabled = True
                    
                    '@枚葉ﾚｼﾋﾟ
                    Case CMlngWFRecp
                        .Redraw = False
                        '@行数初期化
                        .Rows.Count = .Rows.Fixed
                        '@行数設定
                        .Rows.Count = CMlngvsfBottomRow + 1
                        '@ﾀｲﾄﾙ設定
                        .Cols(CMlngvsfRecpWFID).Visible = True
                        '@↓2020/01/07 (Tue) 15:02:56 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        '@基板の場合表示
                        If pstrSBID = CPstrSBID1A0 Then
                            .Cols(CMlngvsfRecpGRB).Visible = True
                        Else
                            .Cols(CMlngvsfRecpGRB).Visible = False
                        End If
                        '@↑2020/01/07 (Tue) 15:02:56 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        .Cols(CMlngvsfRecpWFID).Width = CMlngvsfRecpWWFID
                        '@ｸﾞﾘｯﾄﾞ編集可能
                        .AllowEditing = True
                        .Redraw = True
                        '@有効
                        .Enabled = True
                    
                    '@ｸﾞﾘｯﾄﾞ初期化
                    Case CMlngVsfInit
                        '@描画なし
                        .Redraw = false
                        '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                        .Clear
                        '@初期行数設定
                        .Rows.Count = .Rows.Fixed
                        '@列数設定
                        .Cols.Count = CMlngvsfRecpCols
                        '@固定列の設定
                        .Cols.Frozen = .Cols.Fixed +1 
                        '.Cols.Fixed = 0
                        '@行列のﾏｳｽでの変更を可にする
                        .AllowResizing = AllowResizingEnum.Columns
                        '@ﾌﾟﾛﾊﾟﾃｨの設定対象を選択されたｾﾙに設定
                        '.FillStyle = flexFillRepeat
                        '@ﾍｯﾀﾞｸﾘｯｸで全選択不可
                        '.AllowBigSelection = False
                        '@ﾏｳｽでｾﾙ範囲選択不可
                        '.AllowSelection = False
                        '@ｾﾙ選択の設定
                        .SelectionMode = SelectionModeEnum.Cell
                        '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                        '.Ellipsis = flexEllipsisEnd
                        '@ﾊｲﾗｲﾄ表示
                        .HighLight = HighLightEnum.WithFocus
                        '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                        .FocusRect = FocusRectEnum.Light
                        '@列の調整を不可にする
                        '.AutoSizeMode = flexAutoSizeColWidth
                        '@文章の折り返し「なし」
                        .Styles.Normal.WordWrap = False

                        '@ﾌｫﾝﾄの設定
                        .Font = New Font(.Font.FontFamily, CType(CMlngvsfFontSize, Single), .Font.Style, .Font.Unit)
                        Dim newStyle_title As CellStyle = .Styles.Add("CustomStyle_Title")
                        Dim cellRange As CellRange = .GetCellRange(0, 0, .Rows.Fixed - 1, .Cols.Count - 1)
                        newStyle_title.Font = New Font(.Font.FontFamily, CType(CMlngvsfTitleFontSize, Single), .Font.Style, .Font.Unit)
                        '.FillStyle = flexFillSingle

                        '@見出し行の色設定
                        newStyle_title.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CMlngvsfTitleBackColor))
                        newStyle_title.ForeColor = ColorTranslator.FromWin32(Convert.ToInt32(CMlngvsfTitleForeColor))

                        '@見出し行の文字位置設定
                        newStyle_title.TextAlign = TextAlignEnum.CenterCenter
                        newStyle_title.Trimming = StringTrimming.None 'NSYS ﾍｯﾀﾞは省略表示なしに設定
                        cellRange.Style = newStyle_title


                        '@ﾀｲﾄﾙ設定
                        .SetData(CMlngvsfRecpTitle, CMlngvsfRecpNo, CMstrvsfRecpTNo)
                        .SetData(CMlngvsfRecpTitle, CMlngvsfRecpWFID, CMstrvsfRecpTWFID)
                        '@↓2020/01/07 (Tue) 15:01:24 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        .SetData(CMlngvsfRecpTitle, CMlngvsfRecpGRB, CMstrvsfRecpTGRB) 
                        '@↑2020/01/07 (Tue) 15:01:24 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        .SetData(CMlngvsfRecpTitle, CMlngvsfRecpRecpID, CMstrvsfRecpTRecipeID)
                        .SetData(CMlngvsfRecpTitle, CMlngvsfRecpComment, CMstrvsfRecpTComment)
                        .SetData(CMlngvsfRecpTitle, CMlngvsfRecpValue, CMstrvsfRecpTValue)
                        .SetData(CMlngvsfRecpTitle, CMlngvsfRecpItem, CMstrvsfRecpTItem)
                        .SetData(CMlngvsfRecpTitle, CMlngvsfRecpVariable, CMstrvsfRecpTVariable)
                        .SetData(CMlngvsfRecpTitle, CMlngvsfRecptype, CMstrvsfRecpTtype)
                        .SetData(CMlngvsfRecpTitle, CMlngvsfRecpDigit, CMstrvsfRecpTDigit)
                        .SetData(CMlngvsfRecpTitle, CMlngvsfRecpEdit, CMstrvsfRecpTEdit)
                        
                        '@列幅設定
                        .Cols(CMlngvsfRecpNo).Width = CMlngvsfRecpWNo
                        .Cols(CMlngvsfRecpWFID).Width = CMlngvsfRecpWWFID
                        '@↓2020/01/07 (Tue) 15:01:43 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        .Cols(CMlngvsfRecpGRB).Width = CMlngvsfRecpWGRB
                        '@↑2020/01/07 (Tue) 15:01:43 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        .Cols(CMlngvsfRecpRecpID).Width = CMlngvsfRecpWRecpID
                        .Cols(CMlngvsfRecpItem).Width = CMlngvsfRecpWItem
                        .Cols(CMlngvsfRecpValue).Width = CMlngvsfRecpWValue
                        .Cols(CMlngvsfRecpVariable).Width = CMlngvsfRecpWVariable
                        .Cols(CMlngvsfRecptype).Width = CMlngvsfRecpWtype
                        .Cols(CMlngvsfRecpDigit).Width = CMlngvsfRecpWDigit
                        .Cols(CMlngvsfRecpEdit).Width = CMlngvsfRecpWEdit
                        .Cols(CMlngvsfRecpComment).Width = CMlngvsfRecpWComment
                
                        '@ﾘｽﾄの書式設定
        '                .ColAlignment(CMlngvsfRecpNo) = flexAlignRightCenter                      'NO.
                        .Cols(CMlngvsfRecpNo).TextAlign = TextAlignEnum.RightCenter                'NO.
                        .Cols(CMlngvsfRecpWFID).TextAlign = TextAlignEnum.LeftCenter               'WFID
                        '@↓2020/01/07 (Tue) 15:02:14 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        .Cols(CMlngvsfRecpGRB).TextAlign = TextAlignEnum.LeftCenter                'GRB
                        '@↑2020/01/07 (Tue) 15:02:14 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        .Cols(CMlngvsfRecpRecpID).TextAlign = TextAlignEnum.LeftCenter             'ﾚｼﾋﾟID
                        .Cols(CMlngvsfRecpItem).TextAlign = TextAlignEnum.LeftCenter               'ﾚｼﾋﾟｱｲﾃﾑ
                        '.Cols(CMlngvsfRecpValue).TextAlign = TextAlignEnum.LeftCenter              'ﾚｼﾋﾟ値(ﾚﾁｸﾙ)
                        .Cols(CMlngvsfRecpVariable).TextAlign = TextAlignEnum.RightCenter          '入力可否F
                        .Cols(CMlngvsfRecptype).TextAlign = TextAlignEnum.RightCenter              'ﾃﾞｰﾀﾀｲﾌﾟ
                        .Cols(CMlngvsfRecpDigit).TextAlign = TextAlignEnum.RightCenter             '小数点以下制御
                        .Cols(CMlngvsfRecpEdit).TextAlign = TextAlignEnum.RightCenter              '編集ﾌﾗｸﾞ列
                        .Cols(CMlngvsfRecpComment).TextAlign = TextAlignEnum.LeftCenter            'ﾚｼﾋﾟｺﾒﾝﾄ
                        
                        '@非表示列の設定
                        .Cols(CMlngvsfRecpVariable).Visible  = false                             '入力可否F
                        .Cols(CMlngvsfRecptype).Visible  = false                                 'ﾃﾞｰﾀﾀｲﾌﾟ
                        .Cols(CMlngvsfRecpDigit).Visible  = false                                '小数点以下制御
                        .Cols(CMlngvsfRecpEdit).Visible  = false                                 '編集F
                        '@↓2020/01/07 (Tue) 15:02:56 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        '@基板の場合表示
                        If pstrSBID = CPstrSBID1A0 Then
                            .Cols(CMlngvsfRecpGRB).Visible  = True
                        Else
                            .Cols(CMlngvsfRecpGRB).Visible  = false
                        End If
                        '@↑2020/01/07 (Tue) 15:02:56 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        
                         '@ｵｰﾄｻｲｽﾞ設定(幅)
                         '@ﾕｰｻﾞによる列幅変更されていない場合
                        If mtypChgSort.blnChgWidth = False Then
                            '.AutoSizeMode = flexAutoSizeColWidth
                            .AutoSizeCol(CMlngvsfRecpRecpID, 6)     'ﾚｼﾋﾟID
                            .AutoSizeCol(CMlngvsfRecpComment, 6)    'ﾚｼﾋﾟｺﾒﾝﾄ
                            .AutoSizeCol(CMlngvsfRecpValue, 6)      'ﾚﾁｸﾙ
                            .AutoSizeCol(CMlngvsfRecpItem, 6)       'ﾚｼﾋﾟｱｲﾃﾑ
                            '@↓2020/01/07 (Tue) 15:05:33 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .AutoSizeCol(CMlngvsfRecpGRB, 6)        'GRB
                            '@↑2020/01/07 (Tue) 15:05:33 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        End If
                        
                        '@ﾚｼﾋﾟ選択初期化
                        optRecp0.Checked = False
                        optRecp1.Checked = False

                        '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ使用不可
                        optRecp0.Enabled = False
                        optRecp1.Enabled = False

                        '@直接描画
                        .Redraw = True

                        '@無効
                        .Enabled = False
                        
                        '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ
                        cmdVsfUP.Enabled = False    '前頁
                        cmdVsfDown.Enabled = False  '次頁
                        cmdLeft.Enabled = False     '左頁
                        cmdRight.Enabled = False    '右頁
                        cmdCancel.Enabled = False   '取消
                        cmdKakutei.Enabled = False  '確定
                        
                End Select
                
                '@行の高さ指定
                For llngCnt = 1 To .Rows.Count - 1
                    .Rows(llngCnt).Height = CMvsfRecpHeight
                Next llngCnt
                .Rows(0).Height = CMlngvsfTitleRowHeight


            End With
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvvsfRecp_Init"        '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：frmxxCM0050_Disp
    '機　能：ﾛｯﾄ情報の表示
    '引　数：pblnWpIDNullFlag：作業開始→ﾚｼﾋﾟ変更画面で使用(True:WP_ID=NULL)
    '戻り値：なし
    '作成日：2004/03/04 (Thu) 13:55:18 T.Oide
    '更新日：2008/06/10 (Tue) 16:39:14 N.Kojima
    '備　考：この処理を実行する前に構造体にﾃﾞｰﾀが格納されていること
    '　　　　ptypLotprestate：ﾛｯﾄ情報
    '　　　　pstrCarrierID：ｷｬﾘｱID
    '　　　　pstrWPID：WPID
    '　　　　ptypWFRecp:WF毎のﾚｼﾋﾟ
    '　　　：2004/08/25 (Wed) 09:53:58 N.Kasai　    CFﾌﾗｸﾞ判定追加
    '　　　：2004/08/30 (Mon) 10:49:18 M.Miura　    ﾚｼﾋﾟｺﾝﾎﾞ取得関数のCall分削除(不具合改善№408)
    '　　　：2004/09/09 (Thu) 18:46:02 Y.Yamagishi　時間制限表示変更(不具合改善№693)
    '　　　：2004/09/14 (Tue) 10:28:44 N.Kojima　   数量表示(TPALﾛｯﾄ対応)修正(不具合改善№730)
    '　　　：2004/09/24 (Fri) 12:06:10 Y.Yamagishi  制限時間以上の場合文字色を青に変更(不具合改善№825)
    '　　　：2004/09/26 (Sun) 16:46:43 T.Kitagawa   ﾚｼﾋﾟｺﾝﾎﾞの▼幅を考慮する(不具合№675)
    '　　　：2005/02/18 (Fri) 09:46:59 N.Kasai      引数追加(№510)
    '　　　：2005/05/26 (Thu) 13:49:16 N.Kasai      LP_FLAG判定追加
    '　　　：2005/10/04 (Tue) 17:56:30 N.Kojima     Loader/Unloaderﾌﾗｸﾞ格納処理追加。(不具合№3163)
    '　　　：2006/06/08 (Thu) 14:25:54 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2008/06/10 (Tue) 16:39:14 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub frmxxCM0050_Disp(ByVal llngRecpMode As Integer) 
        
        Dim llngRow             As Integer                  '行
        Dim lstrRows            As Integer                  'NSYS 選択行避難用変数 
        Try
           
            
            '@------------
            '@ﾍｯﾀﾞ情報表示
            '@------------
            txtCarrier.Text = pstrCarrierID                     'ｷｬﾘｱ
            
            With ptypLotprestate
                lblLotID.Text = .strLotID                    'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass            '流動区分
                lblOpID.Text = .strOpID                      '大工程ID
                lblPdID.Text = .strPdId                      '機種名
                lblS.Text = .strSpecialFlg                   '特殊特性
                lblStatus.Text = .strNowST                   '状態
                lblStepID.Text = .strStepID                  '小工程ID
                lblLotManager.Text = .strEngEmpName          'ﾛｯﾄ担当者名
                '@↓2020/01/11 (Sat) 17:08:55 Y.Yoneyama 「.Netへ反映未」 **************************************************
                lblGRB.Text = .strGRBClass                   'GRB
                '@GRB背景色
                lblGRB.BackColor = pubGRBBackColor(.strGRBClass, lblLotID.BackColor)
                '@↑2020/01/11 (Sat) 17:08:55 Y.Yoneyama 「.Netへ反映未」 **************************************************                

                '@時間制約有無の表示
                If .strLimitTime <> vbNullString Then
                    '@時間超過判定
                    If CLng(.strLimitTime) >= 0 Then
                        '@----------------------------------------
                        '@時間制約がﾌﾟﾗｽの場合
                        '@----------------------------------------
                        
                        '@制限時間以下or処理時間制限以下の場合
                        '@処理時間制限以下設定の場合、基本的に処理中で処理出来る機能しか関係ないが例外処理として挿入
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@制限時間先大工程+制限時間先小工程+制限時間
                            '@ﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Format(Integer.Parse(.strLimitTime), CPstrDateFormatKanma) & CPstrh
                            '@右寄せ
                            lblTimeLimit.TextAlign = ContentAlignment.TopRight   
                            
                            '@警告時間が設定されている場合
                            If .strWarnTime <> vbNullString Then
                                '@時間制限が警告時間を過ぎている,且つ制限時間がｵｰﾊﾞｰしていない場合
                                If CLng(.strWarnTime) < 0 And CLng(.strLimitTime) >= 0 Then
                                    '@ﾌｫﾝﾄｶﾗｰを紫に変更
                                    lblTimeLimit.ForeColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngVbColorPurple))    '紫色
                                Else
                                     '@ﾌｫﾝﾄｶﾗｰを黒に変更
                                    lblTimeLimit.ForeColor = Color.Black    '黒
                                End If
                            End If
                        End If
                    Else
                        '@----------------------------------------
                        '@制限時間がﾏｲﾅｽの場合
                        '@制限時間先大工程+制限時間先小工程+制限時間
                        '@----------------------------------------
                        '@右寄せ
                        lblTimeLimit.TextAlign = ContentAlignment.TopRight  
                        '@ForColorの変更
                        lblTimeLimit.ForeColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngVbColorRed))    '赤色
                        
                        '@制限時間以下or処理時間制限以下の場合
                        '@処理時間制限以下設定の場合、基本的に処理中で処理出来る機能しか関係ないが例外処理として挿入
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@ﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Format(Integer.Parse(.strLimitTime), CPstrDateFormatKanma) & CPstrh
                        End If
                        
                        '@制限時間以上の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID2 Then
                            '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Replace(Format(Integer.Parse(.strLimitTime), CPstrDateFormatKanma), CPstrReplaceMinus, vbNullString) & CPstrh
                        End If
                    End If
                End If
                    
                '@退避
                mstrLotLastUpdate = .strLotLastUpdate           'LOT最終更新日時
                mstrAltNumber = .strAltNumber                   '代替番号
                
                '@数量表示
                '@親画面から起動された場合
                If pblnfrmxxCM0050Kbn = True Then
                    '@親ﾌｫｰﾑから呼ばれた場合CFﾌﾗｸﾞのﾁｪｯｸは親ﾌｫｰﾑで行う為そのまま表示する。
                    lblWFNo.Text = Format$(Integer.Parse(.strWfNum), CPstrCFKnmaFormat)
                Else
                    '@-----------------------------------------------------------
                    '@数量表示判定(CF_FLAGを判定し、WF枚数とﾁｯﾌﾟ枚数の表示を切替)
                    '@-----------------------------------------------------------
                    '@CF_FLAG判定
                    Select Case .strCfFlag
                        '@CFﾛｯﾄ
                        Case CPstrCF
                            '@-----------------------------------------------------------
                            '@CF_FLAG = 1 and LP_FLAG = 1　の場合は大判の為、WF枚数を表示する。
                            '@-----------------------------------------------------------
                            '@大判ﾌﾗｸﾞ判定(LP_FLAG)
                            If .strLpFlag = CPstrLP Then
                                '@大判の場合
                                lblWFNo.Text = .strWfNum                                         '数量(WF)
                            Else
                                '@小板の場合
                                lblWFNo.Text = Format$(Integer.Parse(.strChipQuantity), CPstrCFKnmaFormat)      '数量(ﾁｯﾌﾟ)
                            End If

                        '@CFﾛｯﾄ以外
                        Case Else
                            '@TPALﾛｯﾄ
                            If Trim(Strings.Left(.strLotID, 2)) = CPstrTpalLot Then
                                lblWFNo.Text = Format$(Integer.Parse(.strChipQuantity), CPstrCFKnmaFormat)      'ﾁｯﾌﾟ枚数
                            Else
                                '@CF,TPALﾛｯﾄ以外
                                lblWFNo.Text = .strWfNum                                         'WF枚数
                            End If
                    End Select
                End If
                '@-----------------------------------------------------------
                '@ﾛｯﾄ状態判定
                '@ﾛｯﾄ状態を判定してﾗﾍﾞﾙのｷｬﾌﾟｼｮﾝ、表示内容を変更する。
                '@作業待ち、前処理の場合は投入予定日
                '@上記以外は処理開始日時
                '@-----------------------------------------------------------
                Select Case .strNowST
                    '@「作業待ち」「前処理」の場合
                    Case CPstrWaitWorkSt, CPstrBeforeProgressSt
                        lblStartTime.Text = CPstrDispatchTime                                           '日付ﾀｲﾄﾙ設定「処理開始予定」
                        If IsDate(.strDispatchStartTime) Then 
                            lblStartDayTime.Text = Format$(CDate(.strDispatchStartTime), CPstrDateFormat)   '投入予定日を表示
                        End If                        
                    '@その他
                    Case Else
                        lblStartTime.Text = CPstrStartTime                                       '日付ﾀｲﾄﾙ設定「処理開始日時」
                        If IsDate(.strStartTime) Then
                            lblStartDayTime.Text = Format$(CDate(.strStartTime), CPstrDateFormat)           '処理開始日時を表示
                        End If                       
                End Select
            End With
            
            '@-----------------------------------------------------------
            '@作業開始より連動し、WF情報がない場合は親画面よりWP情報を取得しない。
            '@測定装置で作業開始時、測定予定のWFが削除された場合作業開始画面では
            '@ﾚｼﾋﾟ情報の取得ができない。その為、ﾏｽﾀよりﾃﾞﾌｫﾙﾄﾚｼﾋﾟを表示して
            '@当画面で設定する。
            '@pblnWpIDNullFlagは作業開始画面より連動するﾌﾗｸﾞ(True:WP_ID=NULL)
            '@-----------------------------------------------------------
            If pblnWpIDNullFlag = False Then
                
                '@装置ｸﾞﾘｯﾄﾞ表示
                With vsfWp
                    .Redraw = False
                    RemoveHandler vsfWP.AfterRowColChange, AddressOf vsfWP_AfterRowColChange
                    lstrRows = .Row 
                    '@行数設定
                    .Rows.Count = .Rows.Fixed + 1
                    'NSYS 避難させた選択行を戻す
                    .Row = lstrRows 
                    '@行設定
                    .Cols.Count = CMvsfWPCols
                    '行設定
                    llngRow = .Rows.Fixed
                    AddHandler vsfWP.AfterRowColChange, AddressOf vsfWP_AfterRowColChange
                    '@装置一覧表示
                    .SetData(llngRow, CMvsfWPColNo, llngRow)                                  '№
                    .SetData(llngRow, CMvsfWPColOpID, lblOpID.Text)                           '大工程
                    .SetData(llngRow, CMvsfWPColStepID, lblStepID.Text)                       '小工程
                    .SetData(llngRow, CMvsfWPColAltNumber, mstrAltNumber)                     '代替番号
                    .SetData(llngRow, CMvsfWPColDefault, pstrDefaultStep)                     'ﾃﾞﾌｫﾙﾄ
                    .SetData(llngRow, CMvsfWPColWpName, pstrWPName)                           '装置
                    .SetData(llngRow, CMvsfWPColWpID, pstrWPID)                               '装置ID
                    .SetData(llngRow, CMvsfWPColEqType, pstrEqType)                           'EQﾀｲﾌﾟ
                    .SetData(llngRow, CMvsfWPColLotRecipeFlag, pstrLotRecipeFlag)             'ﾛｯﾄﾚｼﾋﾟﾌﾗｸﾞ
                    .SetData(llngRow, CMvsfWPColLoaderUnloaderFlag, pstrLoaderUnloaderFlag)   'LoaderUnloaderﾌﾗｸﾞ
                                
                    '@行の高さ設定
                    .Rows(llngRow).Height = CMlngvsfRowHeight
                    '@選択行設定
                    .Row = .Rows.Count - 1

                    .Redraw = True

                    '@装置一覧を有効
                    .Enabled = True
                    
                    lblWpCnt.Text = 1
                End With
                
                With vsfRecp
                    '@ﾃﾞｰﾀがある場合
                    If .Rows.Count >= .Rows.Fixed Then
                        '@ﾚｼﾋﾟﾁｪｯｸ
                        Call vsfRecp_AfterEdit(vsfRecp, New RowColEventArgs(.Rows.Fixed, .Cols.Fixed))
                        
                        '@ﾚｼﾋﾟID列を
                        '@ﾕｰｻﾞによる列幅変更されていない場合
                        If mtypChgSort.blnChgWidth = False Then
                            .AutoSizeCol(CMlngvsfRecpRecpID, 6)
                        End If
                        
                        '@ﾚｼﾋﾟID列幅変更(▼幅加算)
                        .Cols(CMlngvsfRecpRecpID).Width = .Cols(CMlngvsfRecpRecpID).Width + CMlngvsfRecpCmbWidth                     'ﾚｼﾋﾟID
                    End If
                End With
                
                '@ｸﾞﾘｯﾄﾞ選択の初期化(ｸﾞﾘｯﾄﾞ共通化関数)
                Call pubVsfDisp(vsfRecp, cmdVsfUP, cmdVsfDown)
            End If
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "frmxxCM0050_Disp"       '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

            
        End Try
    End Sub

    '関数名：vsfNum_Check
    '機　能：数字ﾁｪｯｸ
    '引　数：varNum：値
    '戻り値：数値
    '作成日：2004/05/19 (Wed) 12:54:55 M.Miura
    '更新日：2004/05/19 (Wed) 12:54:55
    '備　考：数値に変更
    Function vsfNum_Check(ByVal varNum As Object) As Integer
        
        Try

            '@数字ではない場合
            If IsNumeric(varNum) = False Then
                vsfNum_Check = 0
            Else
                '@数字の場合
                vsfNum_Check = CLng(varNum)
            End If
            
            Exit Function

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "vsfNum_Check"           '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：vsfRecp_BeforeRowColChange
    '機　能：ｸﾞﾘｯﾄﾞ編集制御
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/05/19 (Wed) 19:36:56 M.Miura
    '更新日：2005/02/03 (Thu) 15:46:15 N.Kasai
    '備　考：
    '　　　：2004/09/14 (Tue) 09:35:13 N.Kojima　   ﾃﾞｰﾀ行の判定を修正
    '　　　：2005/02/03 (Thu) 15:46:15 N.Kasai      ﾚｼﾋﾟﾊﾟﾗﾒｰﾀの入力判定追加
    Private Sub vsfRecp_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfRecp.BeforeRowColChange
        
        Dim lstrEdit        As String       '編集ﾌﾗｸﾞ
        Dim lstrVariable    As String       '入力可否ﾌﾗｸﾞ        
        Dim NewRow          As Integer      'NSYS 新行
        Dim NewCol As Integer      'NSYS 新列
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfRecp.Rows.Count <= vsfRecp.Rows.Fixed Then
                Return
            End If

            NewRow = e.NewRange.r1 'NSYS 新行
            NewCol = e.NewRange.c1 'NSYS 新列

            '前回選択した行のパラメータ値を取得
            EditorText = vsfRecp.GetData(NewRow, CMlngvsfRecpValue)

            With vsfRecp
                '@ﾃﾞｰﾀ行ではない場合は抜ける
                If NewRow < .Rows.Fixed Then
                    Exit Sub
                End If
                
                '@編集ﾌﾗｸﾞ取得
                lstrEdit = .GetData(NewRow, CMlngvsfRecpEdit)
                '@入力可否ﾌﾗｸﾞ取得
                lstrVariable = .GetData(NewRow, CMlngvsfRecpVariable)
            
            End With


            
            '@変更可否判定
            Select Case NewCol
                '@ﾚｼﾋﾟID
                Case CMlngvsfRecpRecpID
                    '@------------------------------------
                    '@編集制御
                    '@CMlngEditFlg：編集ﾌﾗｸﾞ(1：編集不可)
                    '@------------------------------------
                    If NewCol = CMlngvsfRecpRecpID And lstrEdit <> CMlngEditFlg Then
                        '@ﾚｼﾋﾟのみ変更を可能
                        vsfRecp.Styles.Editor.BackColor = vsfRecp.Styles.Normal.BackColor
                        vsfRecp.AllowEditing = True
                    Else
                        '@ﾚｼﾋﾟﾊﾟﾗﾒｰﾀのみ変更を不可
                        vsfRecp.AllowEditing = False
                    End If
                '@ﾚｼﾋﾟ値
                Case CMlngvsfRecpValue
                    '@------------------------------------
                    '@編集制御
                    '@入力可否ﾌﾗｸﾞ(1：編集可)
                    '@------------------------------------
                    If NewCol = CMlngvsfRecpValue And lstrVariable = CMlngVariableFlg Then
                        '@ﾚｼﾋﾟﾊﾟﾗﾒｰﾀのみ変更を可能
                        vsfRecp.AllowEditing = True
                    Else
                        '@ﾚｼﾋﾟﾊﾟﾗﾒｰﾀのみ変更を不可
                        vsfRecp.AllowEditing = False
                    End If
                Case Else
                    '@上記以外は変更不可
                    vsfRecp.AllowEditing = False
            End Select
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "vsfRecp_BeforeRowColChange"     '処理名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

            
        End Try
    End Sub


    '関数名：prvColorChang_CM0050
    '機　能：ﾚｼﾋﾟ設定変更画面のﾗﾍﾞﾙ&ｸﾞﾘｯﾄﾀｲﾄﾙ行の色変え処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/07/01 (Tur) 11:40:10 M.Koni
    '更新日：
    '備　考：
    '　　　：
    Private Sub prvColorChang_CM0050()

        Try

            '@ﾃﾞﾌｫﾙﾄ装置で，別装置のｷｬﾘｱを選択した場合は，「赤」表示
            If pstrTerminalFlag = CPstrZero Then
                If pblnWpSelectFlag <> True Then
                    '@全てのｺﾝﾄﾛｰﾙのﾀｲﾄﾙを赤にする
                    lblTtl0.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblTtl1.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblTtl2.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblTtl3.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    '@↓2020/01/11 (Sat) 17:13:49 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    lblTtl4.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    '@↑2020/01/11 (Sat) 17:13:49 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    lblTtl5.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblTtl6.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblTtl7.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblTtl8.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblTtl9.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblTtl10.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblTtl15.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
         
                    lblStartTime.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblTitle0.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblTitle1.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblLengthCount.BackColor = ColorTranslator.FromWin32(CMlngRedColor)

                    '@工程，装置名の行の色を変更(0,0-0,4)
                    Dim newStyle As CellStyle = vsfWp.Styles.Add("CustomStyle_BackColor_CMlngRedColor")
                    newStyle.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    newStyle.ForeColor = ColorTranslator.FromWin32(CPlngBatchPair)
                    newStyle.TextAlign = TextAlignEnum.CenterCenter 
                    Dim cellRange As CellRange = vsfWp.GetCellRange(0, 0, 0, 4)
                    cellRange.Style = newStyle

                    '@ﾚｼﾋﾟﾀｲﾄﾙ欄(0,0-0,10)
                     newStyle  = vsfRecp.Styles.Add("CustomStyle_BackColor_CMlngRedColor")
                    newStyle.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    newStyle.ForeColor = ColorTranslator.FromWin32(CPlngBatchPair)
                    newStyle.TextAlign = TextAlignEnum.CenterCenter
                    newStyle.Font = New Font(vsfRecp.Font.FontFamily, CType(CMlngvsfTitleFontSize, Single), vsfRecp.Font.Style, vsfRecp.Font.Unit)
                    cellRange  = vsfRecp.GetCellRange(0, 0, 0, 9)
                    cellRange.Style = newStyle
                End If
            Else
                '@全てのｺﾝﾄﾛｰﾙのﾀｲﾄﾙを赤にする
                    lblTtl0.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblTtl1.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblTtl2.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblTtl3.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    '@↓2020/01/11 (Sat) 17:13:45 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    lblTtl4.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    '@↑2020/01/11 (Sat) 17:13:45 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    lblTtl5.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblTtl6.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblTtl7.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblTtl8.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblTtl9.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblTtl10.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblTtl15.BackColor = ColorTranslator.FromWin32(CMlngRedColor)

                    lblStartTime.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblTitle0.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblTitle1.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    lblLengthCount.BackColor = ColorTranslator.FromWin32(CMlngRedColor)

                    '@工程，装置名の行の色を変更(0,0-0,4)
                    Dim newStyle As CellStyle = vsfWp.Styles.Add("CustomStyle_BackColor_CMlngRedColor")
                    newStyle.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    newStyle.ForeColor = ColorTranslator.FromWin32(CPlngBatchPair)
                    newStyle.TextAlign = TextAlignEnum.CenterCenter
                    Dim cellRange As CellRange = vsfWp.GetCellRange(0, 0, 0, 4)
                    cellRange.Style = newStyle

                    '@ﾚｼﾋﾟﾀｲﾄﾙ欄(0,0-0,10)
                    newStyle  = vsfRecp.Styles.Add("CustomStyle_BackColor_CMlngRedColor")
                    newStyle.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    newStyle.ForeColor = ColorTranslator.FromWin32(CPlngBatchPair)
                    newStyle.TextAlign = TextAlignEnum.CenterCenter
                    newStyle.Font = New Font(vsfRecp.Font.FontFamily, CType(CMlngvsfTitleFontSize, Single), vsfRecp.Font.Style, vsfRecp.Font.Unit)
                    '@↓2020/01/07 (Tue) 15:25:51 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    'cellRange = vsfRecp.GetCellRange(0, 0, 0, 9)
                    cellRange = vsfRecp.GetCellRange(0, 0, 0, 10)
                    '@↑2020/01/07 (Tue) 15:25:51 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    cellRange.Style = newStyle
            End If

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvColorChang_CM0050"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：vsfRecpCmb_Set
    '機　能：ｸﾞﾘｯﾄﾞﾚｼﾋﾟｺﾝﾎﾞ設定
    '引　数：llngRecpCnt：ﾚｼﾋﾟ件数
    '戻り値：なし
    '作成日：2004/05/26 (Wed) 13:59:04 M.Miura
    '更新日：2005/05/06 (Fri) 11:23:39 N.Kojima
    '備　考：True：正常、False：異常
    '　　　：2004/08/25 (Wed) 15:26:51 N.Kojima     該当ﾃﾞｰﾀが1件しかない場合は、ｺﾝﾎﾞを表示せずに
    '                                               直接ﾘｽﾄに表示するように修正(1865～1869行目)。
    '　　　：2004/08/25 (Wed) 19:45:29 N.Kojima     ﾚｼﾋﾟ件数格納処理を追加(1846行目)。
    '　　　：2004/09/03 (Fri) 13:47:29 M.Miura      装置ｸﾞﾘｯﾄﾞ情報からﾚｼﾋﾟを取得するように修正(不具合№554)
    '　　　：2004/10/15 (Fri) 15:01:56 M.Miura      ｺﾝﾎﾞｾｯﾄ用変数の頭に「;」を付け、ﾃﾞｰﾀの「;」以前を表示するように修正(不具合№1096)
    '　　　：2005/02/03 (Thu) 19:06:06 N.Kasai　    ｺﾒﾝﾄｱｳﾄ(vsfRecp_ComboCloseUpより呼ばれた場合にｲﾝﾃﾞｯｸｽｴﾗｰ)
    '　　　：2005/05/06 (Fri) 11:23:39 N.Kojima     ｲﾝﾃﾞｯｸｽｴﾗｰ回避の為、lot_.recplistにて返されたﾘｽﾄｶｳﾝﾄの格納処理追加。
    Private Function vsfRecpCmb_Set(Optional ByRef llngRecpCnt As Integer = 0) As Boolean
        
        Dim llngAnsCnt              As Integer              'ﾚｼﾋﾟｶｳﾝﾄ
        Dim llngCnt                 As Integer              'ｶｳﾝﾄ
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrDefaultRecp         As String               'ﾃﾞﾌｫﾙﾄﾚｼﾋﾟ
        Dim lstrWpId                As String               'WPID
        Dim lstrAltNumber           As String               '代替番号
        Dim lstrOpID                As String               '大工程
        Dim lstrStepID              As String               '小工程
        Dim lstrRecpList            As SortedList           'ﾚｼﾋﾟﾘｽﾄ
        Dim lstrVsfComboList        As SortedList           'ｺﾝﾎﾞﾘｽﾄ
        '@↓2020/07/01 (Wed) 12:24:24 T.Oide 「.Netへ反映未」 **************************************************
        Dim lstrCmpRecipeBodyFlag   As String               'CMPﾚｼﾋﾟﾎﾞﾃﾞｨｰ設定済ﾌﾗｸﾞ
        '@↑2020/07/01 (Wed) 12:24:24 T.Oide 「.Netへ反映未」 **************************************************
        
        Try

            '@----------------------------------------
            '@WPが選択されている場合のみﾚｼﾋﾟを取得する。
            '@----------------------------------------
            With vsfWp
                '@装置が選択されている場合
                If .Row >= .Rows.Fixed Then
                    '@送信情報格納
                    lstrOpID = .GetData(.Row, CMvsfWPColOpID)                  '大工程
                    lstrStepID = .GetData(.Row, CMvsfWPColStepID)              '小工程
                    lstrWpId = .GetData(.Row, CMvsfWPColWpID)                  '装置ID
                    lstrAltNumber = .GetData(.Row, CMvsfWPColAltNumber)        '代替番号
                    lstrRecpList = .GetData(.Row, CMvsfWPColRecpList)          'ﾚｼﾋﾟﾘｽﾄ
                Else
                    Exit Function
                End If
            End With
            
            '@----------------------------------------
            '@要求MSG内容判定
            '@----------------------------------------
            '@ﾛｯﾄID、大工程、小工程、装置ID、代替番号がある場合
            If lblLotID.Text <> vbNullString And _
               lstrOpID <> vbNullString And _
               lstrStepID <> vbNullString And _
               lstrWpId <> vbNullString And _
               lstrAltNumber <> vbNullString Then
                '@処理続行(上記の設定が満たされていない場合はﾚｼﾋﾟ取得不可)
            Else
                Exit Function
            End If
            
            '@ﾏｽﾀﾚｼﾋﾟ初期化
            If ptypRecp02List Is Nothing 
                ptypRecp02List = New List(Of Lotrecplist) 
            Else 
                ptypRecp02List.Clear()
            End If
            
            '@↓2020/07/01 (Wed) 12:12:10 T.Oide 「.Netへ反映未」 **************************************************
            '@【ﾛｯﾄﾚｼﾋﾟﾘｽﾄ取得(CPstrCD02：ﾏｽﾀﾚｼﾋﾟ)】
            'lblnAns = pubblnLotrecplist_Sel(CMstrlot_recplistVer, lblLotID.Text, _
            '                                    lstrOpID, _
            '                                    lstrStepID, _
            '                                    lstrWpId, _
            '                                    CPstrCD02, _
            '                                    CMlngEqFlag, _
            '                                    lstrAltNumber, _
            '                                    llngAnsCnt)
            '@-----------------------------------------------------------------------------------------------------

            '@【ﾛｯﾄﾚｼﾋﾟﾘｽﾄ取得(CPstrCD02：ﾏｽﾀﾚｼﾋﾟ)】
            lblnAns = pubblnLotrecplist_Sel(CMstrlot_recplistVer, lblLotID.Text, _
                                                lstrOpID, _
                                                lstrStepID, _
                                                lstrWpId, _
                                                CPstrCD02, _
                                                CMlngEqFlag, _
                                                lstrAltNumber, _
                                                llngAnsCnt, , , , , _
                                                lstrCmpRecipeBodyFlag)
            '@↑2020/07/01 (Wed) 12:12:10 T.Oide 「.Netへ反映未」 **************************************************

            '@結果判定
            If lblnAns = False Then
                
                vsfRecpCmb_Set = False
            
                Exit Function
            End If
                
            '@ﾏｽﾀﾚｼﾋﾟ格納
             if IsNothing(ptypRecp02List) Then
                ptypRecp02List = New List(Of Lotrecplist)
            End If
            For Each lot As Lotrecplist In ptypLotrecpList
                Dim tmp As Lotrecplist = New Lotrecplist()
                tmp.strSlotPosition   = lot.strSlotPosition
                tmp.strWFID           = lot.strWFID
                tmp.strRecipeId       = lot.strRecipeId
                tmp.strRecipeComment  = lot.strRecipeComment
                tmp.strDefaultFlag    = lot.strDefaultFlag
                tmp.lngRecipeBodyList = lot.lngRecipeBodyList
                If Not IsNothing(lot.typRecipeBodyList) Then
                    tmp.typRecipeBodyList = New List(Of RecipeBodyList)(lot.typRecipeBodyList)
                End If
                ptypRecp02List.Add(tmp)
            Next

            '@ﾏｽﾀﾚｼﾋﾟﾘｽﾄがある場合
            If llngAnsCnt > 0 Then
                
                '@ﾚｼﾋﾟ件数格納
                llngRecpCnt = llngAnsCnt
                
                lstrVsfComboList = New SortedList()
                For llngCnt = 0 To llngAnsCnt-1
                    With ptypRecp02List(llngCnt)
                        '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟの場合
                        If .strDefaultFlag = CPstrDefaultRecpFlag And lstrDefaultRecp = vbNullString Then
                            '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟを格納(「；」以前はID文字と認識され表示されない為、あらかじめ先頭に「；」をつける)
                            lstrDefaultRecp = .strRecipeId
                        Else
                            '@ﾚｼﾋﾟｺﾝﾎﾞﾘｽﾄ格納
                            lstrVsfComboList.Add(llngCnt+2,.strRecipeId)
                        End If
                    End With
                Next llngCnt
                
                '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟがあるの場合
                If lstrDefaultRecp <> vbNullString Then
                    '@ﾚｼﾋﾟが1件以上ある場合
                    If llngAnsCnt > CMlngRecipeCnt Or _
                       (mstrUserSelectFlag = CMstrUserSelectFlag1 And _
                        vsfWp.GetData(vsfWp.Row, CMvsfWPColEqType) <> CPstrEqTypeBatch And _
                        optRecp1.Checked = True) Then
                        With vsfWp
                            '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟを先頭にしてﾚｼﾋﾟｺﾝﾎﾞﾘｽﾄ格納
                            lstrVsfComboList.Add(1,lstrDefaultRecp)
                            .SetData(.Row, CMvsfWPColRecpList, lstrVsfComboList)
                            '@ﾚｼﾋﾟﾘｽﾄ件数
                            .SetData(.Row, CMvsfWPColRecpListCnt, llngAnsCnt)
                        End With
                    End If
                End If

                '@↓2020/07/01 (Wed) 12:14:24 T.Oide 「.Netへ反映未」 **************************************************
                '@CMPﾚｼﾋﾟﾎﾞﾃﾞｨｰ設定済ﾌﾗｸﾞは1か(CMP特融の処理、このﾌﾗｸﾞはCMP以外では常に0となる)
                If lstrCmpRecipeBodyFlag = CPstrOne Then
        
                    '@ｺﾝﾎﾞﾘｽﾄをｸﾘｱして、選択できなくする
                    vsfWp.SetData(vsfWp.Row, CMvsfWPColRecpList, vbNullString)
                    '@ﾚｼﾋﾟﾘｽﾄ件数
                    vsfWp.SetData(vsfWp.Row, CMvsfWPColRecpListCnt, CPlngNumZero)
            
                    '@ メモ：CMPの枚葉APC機能で、ﾚｼﾋﾟが選択可能な場合、ﾚｼﾋﾟを変更する都度、APCの値もｳｪﾊｰ毎計算された値に変更されるが
                    '       「ﾚｼﾋﾟ設定変更」でﾚｼﾋﾟやAPCの値を変更して確定した場合(個別ﾚｼﾋﾟのBodyがある場合)、ここでﾘｽﾄをｸﾘｱしないと
                    '        ﾛｯﾄで計算したAPC値を表示してしまうためｸﾘｱする。
                    '        ※枚葉のﾚｼﾋﾟを再変更するには、｢個別ﾚｼﾋﾟ削除」してから再度ﾚｼﾋﾟを選択するとｳｪﾊｰ毎計算されたAPC値が表示される

                End If
                '@↑2020/07/01 (Wed) 12:14:24 T.Oide 「.Netへ反映未」 **************************************************
            Else
                Exit Function
            End If
            
            vsfRecpCmb_Set = True
            
            Exit Function

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "vsfRecpCmb_Set"         '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()


        End Try
    End Function

    '関数名：frmxxCM0050_CmdInit
    '機　能：ｸﾞﾘｯﾄﾞ表示設定
    '引　数：lblnVisible：(True：表示、False：非表示)
    '戻り値：なし
    '作成日：2004/05/26 (Wed) 15:00:55 M.Miura
    '更新日：2004/09/21 (Tue) 20:37:36 Y.Yamagishi
    '備　考：2004/09/21 (Tue) 20:37:36 Y.Yamagishi 横ｽｸﾛｰﾙ追加
    Private Sub frmxxCM0050_CmdInit(ByVal lblnVisible As Boolean) 
        
        Try
           
            '@表示/非表示設定
            vsfRecp.Visible = lblnVisible
            cmdVsfUP.Visible = lblnVisible
            cmdVsfDown.Visible = lblnVisible
            cmdLeft.Visible = lblnVisible
            cmdRight.Visible = lblnVisible

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "frmxxCM0050_CmdInit"    '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRecp_Disp
    '機　能：ﾚｼﾋﾟ一覧表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/26 (Wed) 15:45:37 M.Miura
    '更新日：2005/10/24 (Mon) 10:32:24 N.Kojima
    '備　考：
    '　　　：2004/09/21 (Tue) 13:56:15 Y.Yamagishi  ﾚﾁｸﾙ列追加(不具合改善№722)
    '　　　：2004/09/26 (Sun) 13:24:16 T.Kitagawa   枚葉ﾚｼﾋﾟの表示ﾊﾞｸﾞ対応(不具合改善№935はﾛｯﾄ工順変更ではなく、ﾚｼﾋﾟ変更画面でした)
    '　　　：2004/09/26 (Sun) 16:18:11 T.Kitagawa   ﾚｼﾋﾟｺﾝﾎﾞの▼幅を考慮する(不具合№675)
    '　　　：2004/09/26 (Sun) 17:58:44 T.Kitagawa   ﾚﾁｸﾙ設定が無い場合はﾚﾁｸﾙ列を非表示にする(不具合№722)
    '　　　：2004/10/27 (Wed) 13:25:01 Y.Yamagishi  最大ｽﾛｯﾄ数以内のWFの存在しないｾﾙのﾊﾞｯｸｶﾗｰを濃い灰色に変更
    '　　　：2005/01/13 (Thu) 10:32:35 N.Kasai      ﾚｼﾋﾟｺﾒﾝﾄに改行ｺｰﾄﾞをｽﾍﾟｰｽに置き換える(不具合№407)
    '　　　：2005/01/28 (Fri) 14:18:55 N.Kasai      CMP対応(№304)　入力可能な場合は背景色を変更する。
    '　　　：2005/02/10 (Thu) 14:53:03 N.Kasai      枚葉レシピでスロット№01がレシピなしの場合を考慮する｡
    '　　　：2005/10/24 (Mon) 10:32:24 N.Kojima     ﾚｼﾋﾟValue=0の場合、画面に"0"が表示されるように修正。(不具合№3045)
    '　　　：2006/08/18 (Fri) 09:48:38 N.Kojima     ﾚｼﾋﾟﾊﾟﾗﾒｰﾀ(ﾚｼﾋﾟ値)の入力桁数を30byte⇒40byteに拡張(案件№01399)
    Private Sub vsfRecp_Disp()  
        
        Dim llngCnt             As Integer                  'Forのｶｳﾝﾄ
        Dim llngRecpCnt         As Integer                  'ﾚｼﾋﾟｶｳﾝﾄ
        Dim llngRow             As Integer                  '行
        Dim lblnAns             As Boolean                  '戻り値
        Dim llngAnsCnt          As Integer                  'ﾃﾞｰﾀ数
        Dim ltypWaferList       As Waferlist                'ﾛｯﾄｳｪﾊ情報格納
        Dim lstrRecp            As String                   'ﾚｼﾋﾟ等
        Dim llngRecipeBpdyCnt   As Integer                  'ﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄ数
        Dim llngNo              As Integer                  'ｽﾛｯﾄ№
        Dim llngRowCnt          As Integer                  'ｽﾛｯﾄｶｳﾝﾄ
        Dim llngRowsCnt         As Integer                  'ｽﾛｯﾄｶｳﾝﾄ
        Dim llngNoCnt           As Integer                  '№ｶｳﾝﾄ
        Dim llngWidthAll        As Integer                  '表示列の全幅
        Dim llngLoopCnt         As Integer                  'ｶｳﾝﾄ
        Dim lstrDefRecpID       As String                   'ﾃﾞﾌｫﾙﾄﾚｼﾋﾟID
        Dim lstrDefRecpComments As String                   'ﾃﾞﾌｫﾙﾄﾚｼﾋﾟｺﾒﾝﾄ
        Dim llngRCnt            As Integer                  'ﾚｼﾋﾟｶｳﾝﾄ
        Dim lblnReticleHidden   As Boolean                  'ﾚﾁｸﾙ列の非表示ﾌﾗｸﾞ(False:表示、True:非表示)
        Dim llngCmbRecpCnt      As Integer                  'ﾚｼﾋﾟﾘｽﾄ件数
        Dim CellRange_          As CellRange 

        Try
            
            '@ﾚｼﾋﾟｺﾝﾎﾞﾘｽﾄﾃﾞﾌｫﾙﾄ値
            llngRecpCnt = 1
            
            With vsfRecp
                
                '@-------------------------------------------------------------------------------------
                '@↓初期値ﾛｯﾄﾚｼﾋﾟの場合 START(初期値によってｸﾞﾘｯﾄﾞの制御が相違します。)
                '@-------------------------------------------------------------------------------------
                If mlngClassRecp = CMlngLotRecp Then
                    '@---------------------------------
                    '@初期値がﾛｯﾄﾚｼﾋﾟでﾛｯﾄﾚｼﾋﾟ選択の場合
                    '@---------------------------------
                    If optRecp0.Checked = True Then
                        '@ｸﾞﾘｯﾄﾞの初期化(ﾛｯﾄﾚｼﾋﾟ)
                        Call prvvsfRecp_Init(CMlngLotRecp)
                        
                        '@ﾚｼﾋﾟﾘｽﾄがなくなるまで
                        For llngRCnt = 0 To ptypRecp23List.Count -1
                            '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟの場合
                            If ptypRecp23List(llngRCnt).strDefaultFlag = CStr(CMlngDefaultRecipe) Then
                                '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟを格納
                                lstrDefRecpID = ptypRecp23List(llngRCnt).strRecipeId
                                lstrDefRecpComments = ptypRecp23List(llngRCnt).strRecipeComment
                                Exit For
                            End If
                        Next llngRCnt
                        
                        '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟが空白の場合
                        If lstrDefRecpID = vbNullString Then
                            '@初期化
                            llngRCnt = 0
                            '@ﾚｼﾋﾟを格納
                            lstrDefRecpID = ptypRecp23List(llngRCnt).strRecipeId
                            lstrDefRecpComments = ptypRecp23List(llngRCnt).strRecipeComment
                        End If
                        
                        '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟのﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄ判定
                        If ptypRecp23List(llngRCnt).lngRecipeBodyList > 0 Then
                            '@-----------------------------------------------------
                            '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟのﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄが1件以上の場合
                            '@-----------------------------------------------------
                            '@行数を設定する
                            .Rows.Count = ptypRecp23List(llngRCnt).lngRecipeBodyList + 1
                            '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟのﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄ件数分ﾙｰﾌﾟ
                            For llngRecipeBpdyCnt = 1 To ptypRecp23List(llngRCnt).lngRecipeBodyList
                                '@格納行設定
                                llngRow = ptypRecp23List(llngRCnt).lngRecipeBodyList - llngRecipeBpdyCnt + 1
                                '@№列にﾏｰｼﾞ用に半角ｽﾍﾟｰｽをｾｯﾄする
                                .SetData(llngRow, CMlngvsfRecpNo, CPstrSpace)
                                .SetData(llngRow, CMlngvsfRecpRecpID, lstrDefRecpID)                            'ﾚｼﾋﾟ
                                '@ﾏｰｼﾞ用にNULLの場合半角ｽﾍﾟｰｽをｾｯﾄする
                                If ptypRecp23List(llngRCnt).strRecipeComment = vbNullString Then
                                    '@半角ｽﾍﾟｰｽをｾｯﾄ
                                    .SetData(llngRow, CMlngvsfRecpComment, CPstrSpace)
                                Else
                                    .SetData(llngRow, CMlngvsfRecpComment, _
                                            Replace(lstrDefRecpComments, vbCrLf, CPstrSpace))                    'ﾚｼﾋﾟｺﾒﾝﾄ
                                End If
                                
                                '@編集ﾌﾗｸﾞ設定(可)
                                .SetData(llngRow, CMlngvsfRecpEdit, vbNullString)                               '編集F
                                '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟに紐づくﾚﾁｸﾙを格納
                                .SetData(llngRow, CMlngvsfRecpItem, _
                                        ptypRecp23List(llngRCnt).typRecipeBodyList(llngRow-1).strRecipeItem)       'ﾚｼﾋﾟｱｲﾃﾑ
                                .SetData(llngRow, CMlngvsfRecpVariable, _
                                        ptypRecp23List(llngRCnt).typRecipeBodyList(llngRow-1).strVariableFlag)     'ﾚｼﾋﾟ値変更可否F
                                .SetData(llngRow, CMlngvsfRecptype, _
                                        ptypRecp23List(llngRCnt).typRecipeBodyList(llngRow-1).strValueType)        'ﾃﾞｰﾀﾀｲﾌﾟ
                                .SetData(llngRow, CMlngvsfRecpDigit, _
                                        ptypRecp23List(llngRCnt).typRecipeBodyList(llngRow-1).strItemValidDigit)   '小数点以下制御
                                        
        '@↓2006/08/18 (Fri) 09:56:28 N.Kojima **************************************************
        '@文字ﾀｲﾌﾟの場合は、40byteまで入力可に変更(※元は30byte)
                                
                                '@ﾃﾞｰﾀﾀｲﾌﾟの判定(数値の場合)
                                If ptypRecp23List(llngRCnt).typRecipeBodyList(llngRow-1).strValueType = CMstrDataTypeN Then
                                    
                                    '@ｶﾝﾏ編集(0表示もOKとする)
                                    If IsNumeric(ptypRecp23List(llngRCnt).typRecipeBodyList(llngRow-1).strRecipeValue) = True Then
                                        .SetData(llngRow, CMlngvsfRecpValue, _
                                                 Format$(Val(ptypRecp23List(llngRCnt).typRecipeBodyList(llngRow-1).strRecipeValue), _
                                                 prvFormatValue_Set(ptypRecp23List(llngRCnt).typRecipeBodyList(llngRow-1).strItemValidDigit)))  'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                        '.GetData(llngRow, CMlngvsfRecpValue).TextAlign = TextAlignEnum.RightCenter                                 '右寄せ
                                    Else
                                        .SetData(llngRow, CMlngvsfRecpValue, ptypRecp23List(llngRCnt).typRecipeBodyList(llngRow-1).strRecipeValue) 'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                    End If
                                    
                                    'CType(vsfRecp.Editor, Object).MaxLength = CMlngInputNDataMaxByte                                                'MAX桁10
                                Else
                                    .SetData(llngRow, CMlngvsfRecpValue, _
                                        ptypRecp23List(llngRCnt).typRecipeBodyList(llngRow-1).strRecipeValue)                                  'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                   '.GetData(llngRow, CMlngvsfRecpValue).TextAlign = TextAlignEnum.LeftCenter                                   '左寄せ
                                    
                                    'CType(vsfRecp.Editor, Object).MaxLength = CMlngInputADataMaxByte                                                'MAX桁40
                                End If
        '@↑2006/08/18 (Fri) 09:56:28 N.Kojima **************************************************
                            
                            Next
                            
                            '@-------------
                            '@ｾﾙのﾏｰｼﾞ処理
                            '@-------------
                            .AllowMerging = AllowMergingEnum.Free                    '行と列のﾏｰｼﾞ
                            .Cols(CMlngvsfRecpNo).AllowMerging = True                '№
                            .Cols(CMlngvsfRecpRecpID).AllowMerging = True            'ﾚｼﾋﾟID
                            .Cols(CMlngvsfRecpEdit).AllowMerging = True              '編集ﾌﾗｸﾞ
                            .Cols(CMlngvsfRecpComment).AllowMerging = True           'ﾚｼﾋﾟｺﾒﾝﾄ
                            .Cols(CMlngvsfRecpValue).AllowMerging = False            'ﾚﾁｸﾙ
                            .Cols(CMlngvsfRecpItem).AllowMerging = False             'ﾚｼﾋﾟｱｲﾃﾑ
                            .Cols(CMlngvsfRecpVariable).AllowMerging = False         'ﾚｼﾋﾟ値変更可否F
                            .Cols(CMlngvsfRecptype).AllowMerging = False             'ﾃﾞｰﾀﾀｲﾌﾟ
                            .Cols(CMlngvsfRecpDigit).AllowMerging = False            '小数点以下制御
                 
                            '@-------------
                            '@列幅変更
                            '@-------------
                            '@ﾕｰｻﾞによる列幅変更されていない場合
                            If mtypChgSort.blnChgWidth = False Then
                                .AutoSizeCol(CMlngvsfRecpRecpID, 6)                  'ﾚｼﾋﾟID
                                .AutoSizeCol(CMlngvsfRecpComment, 6)                 'ﾚｼﾋﾟｺﾒﾝﾄ
                                .AutoSizeCol(CMlngvsfRecpValue, 6)                   'ﾚﾁｸﾙ
                                .AutoSizeCol(CMlngvsfRecpItem, 6)                    'ﾚｼﾋﾟｱｲﾃﾑ
                            End If
                        Else
                            '@-------------------------------------
                            '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟのﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄが0件の場合
                            '@-------------------------------------
                            .SetData(.Rows.Fixed, CMlngvsfRecpRecpID, lstrDefRecpID)                         'ﾚｼﾋﾟ
                            .SetData(.Rows.Fixed, CMlngvsfRecpComment, _
                                        Replace(lstrDefRecpComments, vbCrLf, CPstrSpace))                    'ﾚｼﾋﾟｺﾒﾝﾄ
                            '@編集ﾌﾗｸﾞ設定(可)
                            .SetData(.Rows.Fixed, CMlngvsfRecpEdit, vbNullString)
                        End If
                    End If
                    
                    '@---------------------------------
                    '@初期値がﾛｯﾄﾚｼﾋﾟで枚葉ﾚｼﾋﾟ選択の場合
                    '@---------------------------------
                    If optRecp1.Checked  = True Then
                        '@ﾛｯﾄｳｪﾊ情報取得
                        lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, txtCarrier.Text, CPstrCD0T, ltypWaferList, llngAnsCnt)
                        If lblnAns = False Then
                            '@直接描画
                            '.Redraw = True

                            '@ｸﾞﾘｯﾄﾞの初期化(初期化)
                            Call prvvsfRecp_Init(CMlngVsfInit)
                            
                            Exit Sub
                        End If
                        
                        '@ｽﾛｯﾄｻｲｽﾞを設定する
                        mlngSlotMapRowS = ltypWaferList.strSlotSize + 1
                        
                        '@ｸﾞﾘｯﾄﾞの初期化(枚葉ﾚｼﾋﾟ)
                        Call prvvsfRecp_Init(CMlngWFRecp)
                        
                        '@ﾚｼﾋﾟﾘｽﾄがなくなるまで
                        For llngRCnt = 0 To mlngLotRecpListCnt-1
                            '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟの場合
                            If ptypRecp23List(llngRCnt).strDefaultFlag = CStr(CMlngDefaultRecipe) Then
                                '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟを格納
                                lstrDefRecpID = ptypRecp23List(llngRCnt).strRecipeId
                                lstrDefRecpComments = ptypRecp23List(llngRCnt).strRecipeComment
                                
                                Exit For
                            End If
                        Next llngRCnt
                        
                        '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟが空白の場合
                        If lstrDefRecpID = vbNullString Then
                            '@初期化
                            llngRCnt = 0
                            
                            '@ﾚｼﾋﾟを格納
                            lstrDefRecpID = ptypRecp23List(llngRCnt).strRecipeId
                            lstrDefRecpComments = ptypRecp23List(llngRCnt).strRecipeComment
                        End If
                        
                        '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟのﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄ判定
                        If ptypRecp23List(llngRCnt).lngRecipeBodyList > 0 Then
                            '@---------------------------------------------------
                            '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟのﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄが1以上の場合
                            '@---------------------------------------------------
                            '@(ﾃﾞﾌｫﾙﾄﾚｼﾋﾟのﾚﾁｸﾙ数＊WF枚数)＋(ｽﾛｯﾄﾏｯﾌﾟの最大ｽﾛｯﾄ数-WF枚数)をｷｬﾘｱに応じたｽﾛｯﾄ数に変更
                            .Rows.Count = (ptypRecp23List(llngRCnt).lngRecipeBodyList * llngAnsCnt) + (CLng(ltypWaferList.strSlotSize) - llngAnsCnt) + 1
                            
                            '@設定を選択されたｾﾙに設定
                            '.FillStyle = flexFillRepeat
                            
                            '@格納行設定
                            llngRowCnt = .Rows.Count - 1
                            '@格納するｽﾛｯﾄ№初期化
                            llngNoCnt = 1
                            '@ｶｳﾝﾀ初期化
                            llngCnt = 0
                            '@WF枚数分ﾙｰﾌﾟする
                            Do While llngCnt <= llngAnsCnt-1
                                '@現在WFのｽﾛｯﾄ№格納
                                llngNo = vsfNum_Check(ltypWaferList.typWfList(llngCnt).strSlotPosition)

                                '@現在WFのｽﾛｯﾄ№と格納するｽﾛｯﾄ№が同じ場合
                                If llngNo = llngNoCnt Then
                                    '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟのﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄ数分ﾙｰﾌﾟする
                                    For llngRecipeBpdyCnt = 0 To ptypRecp23List(llngRCnt).lngRecipeBodyList-1
                                        If llngNo <> 0 Then
                                            '@ｳｪﾊが良品以外の場合
                                            If ltypWaferList.typWfList(llngCnt).strClass <> CPstrClass1 Then
                                                '@編集ﾌﾗｸﾞ設定(不可)
                                                .SetData(llngRowCnt, CMlngvsfRecpEdit, CMlngEditFlg)
                                                '.Select(llngRow, CMlngvsfRecpWFID, llngRow, CMlngvsfRecpValue)
                                                '@背景色(ｸﾞﾚｰ)
                                                CellRange_  = .GetCellRange(llngRow, CMlngvsfRecpWFID, llngRow, CMlngvsfRecpValue)
                                                Dim headerstyle As CellStyle = .Styles.Add("headerstyle")
                                                headerstyle.BackColor = vbButtonFace
                                                CellRange_.Style = headerstyle 
                                            Else
                                                '@編集ﾌﾗｸﾞ設定(可)
                                                .SetData(.Rows.Fixed, CMlngvsfRecpEdit, vbNullString)
                                            End If
                                            
                                            .SetData(llngRowCnt, CMlngvsfRecpNo, _
                                                        Format$(llngNo, CPstrSlotNoFormat))                                          '№
                                            .SetData(llngRowCnt, CMlngvsfRecpWFID, _
                                                        ltypWaferList.typWfList(llngCnt).strWfId)                                    'WFID

                                            '@↓2020/01/07 (Tue) 15:09:35 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                            .SetData(llngRowCnt, CMlngvsfRecpGRB, _
                                                        ltypWaferList.typWfList(llngCnt).strGRBClass)                                'GRB
                                            '@↑2020/01/07 (Tue) 15:09:35 Y.Yoneyama 「.Netへ反映未」 **************************************************

                                            .SetData(llngRowCnt, CMlngvsfRecpRecpID, lstrDefRecpID)                                  'ﾃﾞﾌｫﾙﾄﾚｼﾋﾟ
                                            
                                            '@ﾏｰｼﾞ用にNULLの場合半角ｽﾍﾟｰｽをｾｯﾄする
                                            If ptypRecp23List(llngRCnt).strRecipeComment = vbNullString Then
                                                .SetData(llngRowCnt, CMlngvsfRecpComment, CPstrSpace)
                                            Else
                                                .SetData(llngRowCnt, CMlngvsfRecpComment, _
                                                            Replace(lstrDefRecpComments, vbCrLf, CPstrSpace))                        'ﾃﾞﾌｫﾙﾄﾚｼﾋﾟｺﾒﾝﾄ
                                            End If
                                            
                                            '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟに紐づくﾎﾞﾃﾞｨを格納
                                            .SetData(llngRowCnt, CMlngvsfRecpItem, _
                                                ptypRecp23List(llngRCnt).typRecipeBodyList((ptypRecp23List(llngRCnt).lngRecipeBodyList-1) - llngRecipeBpdyCnt).strRecipeItem)        'ﾚｼﾋﾟｱｲﾃﾑ
                                            .SetData(llngRowCnt, CMlngvsfRecpVariable, _
                                                ptypRecp23List(llngRCnt).typRecipeBodyList((ptypRecp23List(llngRCnt).lngRecipeBodyList-1) - llngRecipeBpdyCnt).strVariableFlag)      'ﾚｼﾋﾟ値変更可否F
                                            .SetData(llngRowCnt, CMlngvsfRecptype, _
                                                ptypRecp23List(llngRCnt).typRecipeBodyList((ptypRecp23List(llngRCnt).lngRecipeBodyList-1) - llngRecipeBpdyCnt).strValueType)         'ﾃﾞｰﾀﾀｲﾌﾟ
                                            .SetData(llngRowCnt, CMlngvsfRecpDigit, _
                                                ptypRecp23List(llngRCnt).typRecipeBodyList((ptypRecp23List(llngRCnt).lngRecipeBodyList-1) - llngRecipeBpdyCnt).strItemValidDigit)    '小数点以下制御数
                                            
        '@↓2006/08/18 (Fri) 09:58:23 N.Kojima **************************************************
        '@文字ﾀｲﾌﾟの場合は、40byteまで入力可に変更(※元は30byte)

                                            '@ﾃﾞｰﾀﾀｲﾌﾟの判定(数値の場合)
                                            If ptypRecp23List(llngRCnt).typRecipeBodyList((ptypRecp23List(llngRCnt).lngRecipeBodyList-1) - llngRecipeBpdyCnt).strValueType = CMstrDataTypeN Then        'ﾃﾞｰﾀﾀｲﾌﾟ
                                                
                                                '@ｶﾝﾏ編集(0表示もOKとする)
                                                If IsNumeric(ptypRecp23List(llngRCnt).typRecipeBodyList((ptypRecp23List(llngRCnt).lngRecipeBodyList-1) - llngRecipeBpdyCnt).strRecipeValue) = True Then
                                                    .SetData(llngRowCnt, CMlngvsfRecpValue, _
                                                        Format$(Val(ptypRecp23List(llngRCnt).typRecipeBodyList((ptypRecp23List(llngRCnt).lngRecipeBodyList-1) - llngRecipeBpdyCnt).strRecipeValue), _
                                                        prvFormatValue_Set(ptypRecp23List(llngRCnt).typRecipeBodyList((ptypRecp23List(llngRCnt).lngRecipeBodyList-1) - llngRecipeBpdyCnt).strItemValidDigit)))    'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                                Else
                                                    .SetData(llngRowCnt, CMlngvsfRecpValue, _
                                                        ptypRecp23List(llngRCnt).typRecipeBodyList((ptypRecp23List(llngRCnt).lngRecipeBodyList-1) - llngRecipeBpdyCnt).strRecipeValue)       'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                                End If
                                                '.GetData(llngRowCnt, CMlngvsfRecpValue).TextAlign = TextAlignEnum.RightCenter                                                            '右寄せ
                                                
                                                'CType(.Editor, Object).MaxLength = CMlngInputNDataMaxByte                                                                                'MAX桁10
                                            Else
                                                .SetData(llngRowCnt, CMlngvsfRecpValue, _
                                                    ptypRecp23List(llngRCnt).typRecipeBodyList((ptypRecp23List(llngRCnt).lngRecipeBodyList-1) - llngRecipeBpdyCnt).strRecipeValue)       'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                                '.GetData(llngRowCnt, CMlngvsfRecpValue).TextAlign = TextAlignEnum.LeftCenter                                                             '左寄せ
                                                
                                                'CType(.Editor, Object).MaxLength = CMlngInputADataMaxByte                                                                                'MAX桁40
                                            End If
        '@↑2006/08/18 (Fri) 09:58:23 N.Kojima **************************************************
                                        End If
                                        
                                        '@格納行ｶｳﾝﾄﾀﾞｳﾝ
                                        llngRowCnt = llngRowCnt - 1
                                    Next
                                    
                                    '@WF枚数ｶｳﾝﾀｶｳﾝﾄｱｯﾌﾟ
                                    llngCnt = llngCnt + 1
                                    
                                    '@№ｶｳﾝﾀｶｳﾝﾄｱｯﾌﾟ
                                    llngNoCnt = llngNoCnt + 1
                                Else
                                    '@ｽﾛｯﾄ№設定
                                    .SetData(llngRowCnt, CMlngvsfRecpNo, Format$(llngNoCnt, CPstrSlotNoFormat))
                                    
                                    '@格納行ｶｳﾝﾄﾀﾞｳﾝ
                                    llngRowCnt = llngRowCnt - 1
                                    
                                    '@№ｶｳﾝﾄｱｯﾌﾟ
                                    llngNoCnt = llngNoCnt + 1
                                End If
                            Loop
                            
                            '@残りのｽﾛｯﾄ№を設定
                            For llngCnt = llngRowCnt To 1 Step -1
                                '@ｽﾛｯﾄ№格納
                                llngNo = llngNo + 1
                                '@ｽﾛｯﾄ№設定
                                .SetData(llngCnt, CMlngvsfRecpNo, Format$(llngNo, CPstrSlotNoFormat))
                            Next
                            
                            '@-------------
                            '@ｾﾙのﾏｰｼﾞ処理
                            '@-------------
                            .AllowMerging = AllowMergingEnum.RestrictAll             '行と列のﾏｰｼﾞ
                            .Cols(CMlngvsfRecpNo).AllowMerging = True                '№
                            .Cols(CMlngvsfRecpWFID).AllowMerging = True              'WFID
                            '@↓2020/01/07 (Tue) 15:10:33 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .Cols(CMlngvsfRecpGRB).AllowMerging = True               'GRB
                            '@↑2020/01/07 (Tue) 15:10:33 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .Cols(CMlngvsfRecpRecpID).AllowMerging = True            'ﾚｼﾋﾟID
                            .Cols(CMlngvsfRecpEdit).AllowMerging = True              '編集ﾌﾗｸﾞ
                            .Cols(CMlngvsfRecpComment).AllowMerging = True           'ﾚｼﾋﾟｺﾒﾝﾄ
                            .Cols(CMlngvsfRecpValue).AllowMerging = False            'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                            .Cols(CMlngvsfRecpItem).AllowMerging = False             'ﾚｼﾋﾟｱｲﾃﾑ
                            .Cols(CMlngvsfRecpVariable).AllowMerging = False         'ﾚｼﾋﾟ値変更可否
                            .Cols(CMlngvsfRecptype).AllowMerging = False             'ﾃﾞｰﾀﾀｲﾌﾟ
                            .Cols(CMlngvsfRecpDigit).AllowMerging = False            '小数点以下
                            
                            '@-------------
                            '@列幅変更
                            '@-------------
                            '@ﾕｰｻﾞによる列幅変更されていない場合
                            If mtypChgSort.blnChgWidth = False Then
                                .AutoSizeCol(CMlngvsfRecpWFID, 6)                    'WFID
                                '@↓2020/01/07 (Tue) 15:11:02 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                .AutoSizeCol(CMlngvsfRecpGRB, 6)                    'GRB
                                '@↑2020/01/07 (Tue) 15:11:02 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                .AutoSizeCol(CMlngvsfRecpRecpID, 6)                  'ﾚｼﾋﾟID
                                .AutoSizeCol(CMlngvsfRecpComment, 6)                 'ﾚｼﾋﾟｺﾒﾝﾄ
                                .AutoSizeCol(CMlngvsfRecpValue, 6)                   'ﾚﾁｸﾙ
                                .AutoSizeCol(CMlngvsfRecpItem, 6)                    'ﾚｼﾋﾟｱｲﾃﾑ
                            End If
                        Else
                            '@---------------------------------------------------
                            '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟのﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄが0件の場合
                            '@---------------------------------------------------
                            '@ｽﾛｯﾄﾏｯﾌﾟの最大ｽﾛｯﾄ数をｷｬﾘｱに応じたｽﾛｯﾄ数に変更
                            .Rows.Count = ltypWaferList.strSlotSize + 1
                            '@ｽﾛｯﾄ№を設定
                            llngCnt = 1
                            Do While .Rows.Count > llngCnt
                                .SetData(.Rows.Count - llngCnt, CMlngvsfRecpNo, Format$(llngCnt, CPstrSlotNoFormat))
                                llngCnt = llngCnt + 1
                            Loop
                    
                            '@設定を選択されたｾﾙに設定
                            '.FillStyle = flexFillRepeat
                            For llngCnt = 0 To llngAnsCnt-1
                                '@ｽﾛｯﾄ№格納
                                llngRow = vsfNum_Check(ltypWaferList.typWfList(llngCnt).strSlotPosition)
                                If llngRow <> 0 Then
                                    '@格納行格納
                                    llngRow = mlngSlotMapRowS - llngRow
                                    '@ｳｪﾊが良品以外の場合
                                    If ltypWaferList.typWfList(llngCnt).strClass <> CPstrClass1 Then
                                        '@編集ﾌﾗｸﾞ設定(不可)
                                        .SetData(llngRow, CMlngvsfRecpEdit, CMlngEditFlg)
                                         cellRange_ = .GetCellRange(llngRow, CMlngvsfRecpWFID, llngRow, CMlngvsfRecpComment)
                                        .Select(llngRow, CMlngvsfRecpWFID, llngRow, CMlngvsfRecpComment)
                                        '@背景色(ｸﾞﾚｰ)
                                        Dim headerstyle As CellStyle = .Styles.Add("headerstyle")
                                        headerstyle.BackColor = vbButtonFace
                                        CellRange_.Style = headerstyle 
                                    Else
                                        '@編集ﾌﾗｸﾞ設定(可)
                                        .SetData(.Rows.Fixed, CMlngvsfRecpEdit, vbNullString)
                                    End If
                                    .SetData(llngRow, CMlngvsfRecpWFID, _
                                                ltypWaferList.typWfList(llngCnt).strWfId)           'WFID

                                    '@↓2020/01/07 (Tue) 15:11:52 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                    .SetData(llngRow, CMlngvsfRecpGRB, _
                                                ltypWaferList.typWfList(llngCnt).strGRBClass)       'GRB
                                    '@↑2020/01/07 (Tue) 15:11:52 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                                
                                    .SetData(llngRow, CMlngvsfRecpRecpID, lstrDefRecpID)            'ﾃﾞﾌｫﾙﾄﾚｼﾋﾟ
                                    
                                    .SetData(llngRow, CMlngvsfRecpComment, _
                                                Replace(lstrDefRecpComments, vbCrLf, CPstrSpace))   'ﾃﾞﾌｫﾙﾄﾚｼﾋﾟｺﾒﾝﾄ
                                End If
                            Next llngCnt
                            
                            '@-------------
                            '@ｾﾙのﾏｰｼﾞ処理
                            '@-------------
                            .AllowMerging = AllowMergingEnum.RestrictAll             '行と列のﾏｰｼﾞ
                            .Cols(CMlngvsfRecpNo).AllowMerging = True                '№
                            .Cols(CMlngvsfRecpWFID).AllowMerging = True              'WFID
                            '@↓2020/01/07 (Tue) 15:12:22 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .Cols(CMlngvsfRecpGRB).AllowMerging = False              'GRB
                            '@↑2020/01/07 (Tue) 15:12:22 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .Cols(CMlngvsfRecpRecpID).AllowMerging = True            'ﾚｼﾋﾟID
                            .Cols(CMlngvsfRecpEdit).AllowMerging = True              '編集ﾌﾗｸﾞ
                            .Cols(CMlngvsfRecpComment).AllowMerging = True           'ﾚｼﾋﾟｺﾒﾝﾄ
                            .Cols(CMlngvsfRecpValue).AllowMerging = False            'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                            .Cols(CMlngvsfRecpItem).AllowMerging = False             'ﾚｼﾋﾟｱｲﾃﾑ
                            .Cols(CMlngvsfRecpVariable).AllowMerging = False         'ﾚｼﾋﾟ値変更可否F
                            .Cols(CMlngvsfRecptype).AllowMerging = False             'ﾃﾞｰﾀﾀｲﾌﾟ
                            .Cols(CMlngvsfRecpDigit).AllowMerging = False            '小数点以下制御
                            
                            '@-------------
                            '@列幅変更
                            '@-------------
                            '@ﾕｰｻﾞによる列幅変更されていない場合
                            If mtypChgSort.blnChgWidth = False Then
                                .AutoSizeCol(CMlngvsfRecpWFID, 6)                   'WFID
                                '@↓2020/01/07 (Tue) 15:12:43 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                .AutoSizeCol(CMlngvsfRecpGRB, 6)                    'GRB
                                '@↑2020/01/07 (Tue) 15:12:43 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                .AutoSizeCol(CMlngvsfRecpRecpID, 6)                 'ﾚｼﾋﾟID
                                .AutoSizeCol(CMlngvsfRecpComment, 6)                'ﾚｼﾋﾟｺﾒﾝﾄ
                            End If
                        End If
                    End If
                            
                End If
                '@-------------------------------------------------------------------------------------
                '@↑初期値ﾛｯﾄﾚｼﾋﾟの場合 END(初期値によってｸﾞﾘｯﾄﾞの制御が相違します。)
                '@-------------------------------------------------------------------------------------

        '@初期値ﾛｯﾄ/枚葉処理の境界線--------------------------------------------------------------------------------------------------------------------------------------------------------
                
                '@-------------------------------------------------------------------------------------
                '@↓初期値枚葉ﾚｼﾋﾟの場合 START(初期値によってｸﾞﾘｯﾄﾞの制御が相違します。)
                '@-------------------------------------------------------------------------------------
                If mlngClassRecp = CMlngWFRecp Then
                    '@---------------------------------
                    '@初期値が枚葉ﾚｼﾋﾟでﾛｯﾄﾚｼﾋﾟ選択の場合
                    '@---------------------------------
                    If optRecp0.Checked  = True Then
                        '@ｸﾞﾘｯﾄﾞの初期化(ﾛｯﾄﾚｼﾋﾟ)
                        Call prvvsfRecp_Init(CMlngLotRecp)
                        '@編集ﾌﾗｸﾞ設定(可)
                        .SetData(.Rows.Fixed, CMlngvsfRecpEdit, vbNullString)
                    End If
                    
                    '@---------------------------------
                    '@初期値が枚葉ﾚｼﾋﾟで枚葉ﾚｼﾋﾟ選択の場合
                    '@---------------------------------
                    If optRecp1.Checked  = True Then
                        '@ﾛｯﾄｳｪﾊ情報取得
                        lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, txtCarrier.Text, CPstrCD0T, ltypWaferList, llngAnsCnt)
                        '@結果判定
                        If lblnAns = False Then
                            '@直接描画
                            '.Redraw = True

                            '@ｸﾞﾘｯﾄﾞの初期化(初期化)
                            Call prvvsfRecp_Init(CMlngVsfInit)
                            
                            Exit Sub
                        End If
                        
                        '@ｽﾛｯﾄｻｲｽﾞを設定する
                        mlngSlotMapRowS = ltypWaferList.strSlotSize + 1
                        
                        '@ｸﾞﾘｯﾄﾞの初期化(枚葉ﾚｼﾋﾟ)
                        Call prvvsfRecp_Init(CMlngWFRecp)
                        
                        '@WF枚数分ﾙｰﾌﾟ
                        For llngCnt = 0 To mlngLotRecpListCnt-1
                            '@ﾚｼﾋﾟﾘｽﾄ分のﾎﾞﾃﾞｨﾘｽﾄｶｳﾝﾄ
                            llngRowsCnt = ptypRecp23List((mlngLotRecpListCnt-1) - llngCnt).lngRecipeBodyList + llngRowsCnt
                        Next
                        
                        '@行数設定
                         .Rows.Count = llngRowsCnt + (CLng(ltypWaferList.strSlotSize) - mlngLotRecpListCnt) + 1
                        
                        '@設定を選択されたｾﾙに設定
                        '.FillStyle = flexFillRepeat
                        
                        '@格納するｽﾛｯﾄ№初期化
                        llngNoCnt = 1
                        
                        '@WF枚数ｶｳﾝﾀ初期化
                        llngCnt = 0
                        
                        '@格納行設定
                        llngRowCnt = .Rows.Count - 1
                        
                        '@WF枚数分ﾙｰﾌﾟ
                        Do While llngCnt <= llngAnsCnt-1
                            '@ｽﾛｯﾄ№格納
                            llngNo = vsfNum_Check(ltypWaferList.typWfList(llngCnt).strSlotPosition)
                            '@現在WFのｽﾛｯﾄ№と格納するｽﾛｯﾄ№が同じ場合
                            If llngNo = llngNoCnt Then
                                '@ﾚｼﾋﾟﾘｽﾄ数より小さい場合
                                If llngCnt <= mlngLotRecpListCnt-1 Then
                                    '@ﾎﾞﾃﾞｨﾘｽﾄｶｳﾝﾄ分ﾙｰﾌﾟ
                                    For llngRecipeBpdyCnt = 0 To ptypRecp23List(llngCnt).lngRecipeBodyList-1
                                        If llngNo <> 0 Then
                                            '@ｳｪﾊが良品以外の場合
                                            If ltypWaferList.typWfList(llngCnt).strClass <> CPstrClass1 Then
                                                '@編集ﾌﾗｸﾞ設定(不可)
                                                .SetData(llngRowCnt, CMlngvsfRecpEdit, CMlngEditFlg)
                                                 CellRange_  = .GetCellRange(llngRowCnt, CMlngvsfRecpWFID, llngRowCnt, CMlngvsfRecpComment)
                                                '@背景色(ｸﾞﾚｰ)                                               
                                                 Dim headerstyle As CellStyle = .Styles.Add("headerstyle")
                                                 headerstyle.BackColor = vbButtonFace
                                                 CellRange_.Style = headerstyle 
                                            Else
                                                '@編集ﾌﾗｸﾞ設定(可)
                                                .SetData(.Rows.Fixed, CMlngvsfRecpEdit, vbNullString)
                                            End If
                                            .SetData(llngRowCnt, CMlngvsfRecpNo, Format$(llngNo, CPstrSlotNoFormat))                  '№
                                            .SetData(llngRowCnt, CMlngvsfRecpWFID, ltypWaferList.typWfList(llngCnt).strWfId)          'WFID
                                            '@↓2020/01/07 (Tue) 15:13:17 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                            .SetData(llngRowCnt, CMlngvsfRecpGRB, ltypWaferList.typWfList(llngCnt).strGRBClass)       'GRB
                                            '@↑2020/01/07 (Tue) 15:13:17 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                            .SetData(llngRowCnt, CMlngvsfRecpRecpID, ptypRecp23List(llngCnt).strRecipeId)             'ﾚｼﾋﾟ
                                            '@ﾏｰｼﾞ用にNULLの場合半角ｽﾍﾟｰｽをｾｯﾄする
                                            If ptypRecp23List(llngCnt).strRecipeComment = vbNullString Then
                                                .SetData(llngRowCnt, CMlngvsfRecpComment, CPstrSpace)
                                            Else
                                                .SetData(llngRowCnt, CMlngvsfRecpComment, _
                                                        Replace(ptypRecp23List(llngCnt).strRecipeComment, vbCrLf, CPstrSpace))                   'ﾚｼﾋﾟｺﾒﾝﾄ
                                            End If
                                            
                                            '@ﾚｼﾋﾟに紐づくﾎﾞﾃﾞｨを格納
                                            .SetData(llngRowCnt, CMlngvsfRecpItem, _
                                                ptypRecp23List(llngCnt).typRecipeBodyList((ptypRecp23List(llngCnt).lngRecipeBodyList -1) - llngRecipeBpdyCnt).strRecipeItem)      'ﾚｼﾋﾟｱｲﾃﾑ
                                            .SetData(llngRowCnt, CMlngvsfRecpVariable, _
                                                ptypRecp23List(llngCnt).typRecipeBodyList((ptypRecp23List(llngCnt).lngRecipeBodyList -1) - llngRecipeBpdyCnt).strVariableFlag)    'ﾚｼﾋﾟ値変更可否
                                            .SetData(llngRowCnt, CMlngvsfRecptype, _
                                                ptypRecp23List(llngCnt).typRecipeBodyList((ptypRecp23List(llngCnt).lngRecipeBodyList -1) - llngRecipeBpdyCnt).strValueType)       'ﾃﾞｰﾀﾀｲﾌﾟ
                                            .SetData(llngRowCnt, CMlngvsfRecpDigit, _
                                                ptypRecp23List(llngCnt).typRecipeBodyList((ptypRecp23List(llngCnt).lngRecipeBodyList -1) - llngRecipeBpdyCnt).strItemValidDigit)  '小数点以下制御数
                                        
        '@↓2006/08/18 (Fri) 10:00:23 N.Kojima **************************************************
        '@文字ﾀｲﾌﾟの場合は、40byteまで入力可に変更(※元は30byte)

                                            '@ﾃﾞｰﾀﾀｲﾌﾟの判定(数値の場合)
                                            If ptypRecp23List(llngCnt).typRecipeBodyList((ptypRecp23List(llngCnt).lngRecipeBodyList -1)  - llngRecipeBpdyCnt).strValueType = CMstrDataTypeN Then
                                                
                                                '@ｶﾝﾏ編集(0表示もOKとする)
                                                If IsNumeric(ptypRecp23List(llngCnt).typRecipeBodyList((ptypRecp23List(llngCnt).lngRecipeBodyList -1)  - llngRecipeBpdyCnt).strRecipeValue) = True Then
                                                    .SetData(llngRowCnt, CMlngvsfRecpValue, _
                                                            Format$(Val(ptypRecp23List(llngCnt).typRecipeBodyList((ptypRecp23List(llngCnt).lngRecipeBodyList -1)  - llngRecipeBpdyCnt).strRecipeValue), _
                                                                prvFormatValue_Set(ptypRecp23List(llngCnt).typRecipeBodyList((ptypRecp23List(llngCnt).lngRecipeBodyList -1)  - llngRecipeBpdyCnt).strItemValidDigit)))
                                                Else
                                                    .SetData(llngRowCnt, CMlngvsfRecpValue, _
                                                            ptypRecp23List(llngCnt).typRecipeBodyList((ptypRecp23List(llngCnt).lngRecipeBodyList -1)  - llngRecipeBpdyCnt).strRecipeValue)     'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                                End If
                                                 '.GetData(llngRowCnt, CMlngvsfRecpValue).TextAlign =TextAlignEnum.RightCenter                                                             '右寄せ

                                                 'CType(.Editor, Object).MaxLength = CMlngInputNDataMaxByte                                                                               'MAX桁10
                                            Else
                                                .SetData(llngRowCnt, CMlngvsfRecpValue, _
                                                        ptypRecp23List(llngCnt).typRecipeBodyList((ptypRecp23List(llngCnt).lngRecipeBodyList -1)  - llngRecipeBpdyCnt).strRecipeValue)     'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                                '.GetData(llngRowCnt, CMlngvsfRecpValue).TextAlign =TextAlignEnum.LeftCenter                                                              '左寄せ 
                                                
                                                'CType(.Editor, Object).MaxLength = CMlngInputADataMaxByte                                                                                'MAX桁40
                                            End If
        '@↑2006/08/18 (Fri) 10:00:23 N.Kojima **************************************************
                                        End If
                                        
                                        '@格納行ｾｯﾄ
                                        llngRowCnt = llngRowCnt - 1
                                    Next
                                Else
                                    .SetData(llngRowCnt, CMlngvsfRecpNo, Format$(llngNo, CPstrSlotNoFormat))                '№
                                    .SetData(llngRowCnt, CMlngvsfRecpWFID, ltypWaferList.typWfList(llngCnt).strWfId)        'WFID
                                    '@↓2020/01/07 (Tue) 15:14:00 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                    .SetData(llngRowCnt, CMlngvsfRecpGRB, ltypWaferList.typWfList(llngCnt).strGRBClass)     'GRB
                                    '@↑2020/01/07 (Tue) 15:14:00 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                    '@格納行ｾｯﾄ
                                    llngRowCnt = llngRowCnt - 1
                                End If
                                '@№ｶｳﾝﾄｱｯﾌﾟ
                                llngNoCnt = llngNoCnt + 1
                                '@WFｶｳﾝﾀｶｳﾝﾄｱｯﾌﾟ
                                llngCnt = llngCnt + 1
                            Else
                                '@ｽﾛｯﾄ№設定
                                .SetData(llngRowCnt, CMlngvsfRecpNo, Format$(llngNoCnt, CPstrSlotNoFormat))
                                '@№ｶｳﾝﾄｱｯﾌﾟ
                                llngNoCnt = llngNoCnt + 1
                                '@格納行ｾｯﾄ
                                llngRowCnt = llngRowCnt - 1
                            End If
                        Loop
                        
                        '@残りのｽﾛｯﾄ№を設定
                        For llngCnt = llngRowCnt To 1 Step -1
                            '@ｽﾛｯﾄ№格納
                            llngNo = llngNo + 1
                            '@ｽﾛｯﾄ№設定
                            .SetData(llngCnt, CMlngvsfRecpNo, Format$(llngNo, CPstrSlotNoFormat))
                        Next
                        
                        '@-------------
                        '@ｾﾙのﾏｰｼﾞ処理
                        '@-------------
                        .AllowMerging = AllowMergingEnum.RestrictAll            '行と列のﾏｰｼﾞ
                        .Cols(CMlngvsfRecpNo).AllowMerging = True               '№
                        .Cols(CMlngvsfRecpWFID).AllowMerging = True             'WFID
                        '@↓2020/01/07 (Tue) 15:14:31 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        .Cols(CMlngvsfRecpGRB).AllowMerging = True              'GRB
                        '@↑2020/01/07 (Tue) 15:14:31 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        .Cols(CMlngvsfRecpRecpID).AllowMerging = True           'ﾚｼﾋﾟID
                        .Cols(CMlngvsfRecpEdit).AllowMerging = False            '編集ﾌﾗｸﾞ
                        .Cols(CMlngvsfRecpComment).AllowMerging = False         'ﾚｼﾋﾟｺﾒﾝﾄ
                        .Cols(CMlngvsfRecpValue).AllowMerging = False           'ﾚﾁｸﾙ
                        .Cols(CMlngvsfRecpItem).AllowMerging = False            'ﾚｼﾋﾟｱｲﾃﾑ
                        .Cols(CMlngvsfRecpVariable).AllowMerging = False        'ﾚｼﾋﾟ値変更可否
                        .Cols(CMlngvsfRecptype).AllowMerging = False            'ﾃﾞｰﾀﾀｲﾌﾟ
                        .Cols(CMlngvsfRecpDigit).AllowMerging = False           '小数点以下制御
                            
                      
                        '@-------------
                        '@列幅変更
                        '@-------------
                        '@ﾕｰｻﾞによる列幅変更されていない場合
                        If mtypChgSort.blnChgWidth = False Then
                            .AutoSizeCol(CMlngvsfRecpWFID, 6)                   'WFID
                            '@↓2020/01/07 (Tue) 15:14:49 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .AutoSizeCol(CMlngvsfRecpGRB, 6)                    'GRB
                            '@↑2020/01/07 (Tue) 15:14:49 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .AutoSizeCol(CMlngvsfRecpRecpID, 6)                 'ﾚｼﾋﾟID
                            .AutoSizeCol(CMlngvsfRecpComment, 6)                'ﾚｼﾋﾟｺﾒﾝﾄ
                            .AutoSizeCol(CMlngvsfRecpValue, 6)                  'ﾚﾁｸﾙ
                            .AutoSizeCol(CMlngvsfRecpItem, 6)                   'ﾚｼﾋﾟｱｲﾃﾑ
                        End If
                    End If
                
                End If
                '@-------------------------------------------------------------------------------------
                '@↑初期値枚葉ﾚｼﾋﾟの場合 END(初期値によってｸﾞﾘｯﾄﾞの制御が相違します。)
                '@-------------------------------------------------------------------------------------
                
                '@----------------------------------------------------------------------
                '@ ｸﾞﾘｯﾄ共通処理↓↓
                '@----------------------------------------------------------------------
                
                '@------------------------------------
                '@左右ｽｸﾛｰﾙの制御
                '@------------------------------------
                '@全列数の幅取得(非表示項目は含めない)
                For llngLoopCnt = 0 To .Cols.Count - 1
                    If .Cols(llngLoopCnt).Visible <> True Then
                        llngWidthAll = llngWidthAll + .Cols(llngLoopCnt).Width
                    End If
                Next llngLoopCnt
                    
                '@ｸﾞﾘｯﾄﾞ幅と比較して横ｽｸﾛｰﾙﾎﾞﾀﾝを活性化するか判断
                If .Width - llngWidthAll >= 0 Then
                    '@ｽｸﾛｰﾙﾌﾗｸﾞ(=2:非活性化)
                    mlngSideScrollFlag = CMlngSideScrollOffFlag
                    '@右ｽｸﾛｰﾙ非活性化
                    cmdRight.Enabled = False
                Else
                    '@ｽｸﾛｰﾙﾌﾗｸﾞ(=1:活性化)
                    mlngSideScrollFlag = CMlngSideScrollOnFlag
                    '@右ｽｸﾛｰﾙ活性化
                    cmdRight.Enabled = True
                End If
                
                '@設定を選択されたｾﾙに設定
                '.FillStyle = flexFillRepeat
                
                '@------------------------------------
                '@ﾊﾞｯｸｶﾗｰの制御
                '@------------------------------------
                '@25(ｽﾛｯﾄ)から1まで
                Dim styleGRB As CellStyle
                Dim cellGRB As CellRange
                For llngCnt = .Rows.Count - 1 To CMlngvsfTopRow Step -1
                    '@WFとﾚｼﾋﾟを格納
                    lstrRecp = .GetData(llngCnt, CMlngvsfRecpWFID) & _
                               .GetDataDisplay(llngCnt, CMlngvsfRecpRecpID)
                    
                    '@WFとﾚｼﾋﾟがない又は変更ﾌﾗｸﾞが"1"且つ枚葉の場合
                    If (lstrRecp = vbNullString Or .GetData(llngCnt, CMlngvsfRecpEdit) = CMlngEditFlg) And _
                       optRecp1.Checked  = True Then
                        '@編集ﾌﾗｸﾞ設定(不可)
                        .SetData(llngCnt, CMlngvsfRecpEdit, CMlngEditFlg)
                         CellRange_  = .GetCellRange(llngCnt, CMlngvsfRecpWFID, llngCnt, CMlngvsfRecpComment)
                        '.Select(llngCnt, CMlngvsfRecpWFID, llngCnt, CMlngvsfRecpComment)
                        '@背景色(ｸﾞﾚｰ)
                         Dim headerstyle As CellStyle = .Styles.Add("GrayHeaderStyle")
                         headerstyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                         CellRange_.Style = headerstyle                                                                                               
                                                
                    Else
                        '@編集ﾌﾗｸﾞ設定(可)
                        .SetData(llngCnt, CMlngvsfRecpEdit, vbNullString)
                         CellRange_  = .GetCellRange(llngCnt, CMlngvsfRecpWFID, llngCnt, CMlngvsfRecpComment)
                        '.Select(llngCnt, CMlngvsfRecpWFID, llngCnt, CMlngvsfRecpComment)
                        '@背景色(白)
                        Dim headerstyle As CellStyle = .Styles.Add("WhiteHeaderstyle")
                         headerstyle.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                         CellRange_.Style = headerstyle
                        
                        '@-------------------------------------------
                        '@ﾚｼﾋﾟ値入力可否
                        '@CMlngVariableFlg:入力可否Fの判定(1:入力可)
                        '@-------------------------------------------
                        If .GetData(llngCnt, CMlngvsfRecpVariable) = CMlngVariableFlg Then
                            Dim newStyle_ As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngInputColor")
                            newStyle_.BackColor = ColorTranslator.FromWin32(CPlngInputColor)
                            Dim cellRange__ As CellRange = .GetCellRange(llngCnt, CMlngvsfRecpValue)
                            cellRange__.Style = newStyle_    '入力可(ﾋﾟﾝｸ)
                        Else
                            Dim newStyle_ As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                            newStyle_.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                            Dim cellRange__ As CellRange = .GetCellRange(llngCnt, CMlngvsfRecpValue)
                            cellRange__.Style = newStyle_            '入力不可(白)

                            '@↓2020/01/11 (Sat) 17:00:39 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            '@GRB背景色
                            styleGRB = .Styles.Add("GRBColor" & llngCnt.ToString)
                            styleGRB.BackColor = pubGRBBackColor(.GetData(llngCnt, CMlngvsfRecpGRB))
                            cellGRB = .GetCellRange(llngCnt, CMlngvsfRecpGRB)
                            cellGRB.Style = styleGRB
                            '@↑2020/01/11 (Sat) 17:00:39 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        End If
                    End If

                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_lightgray")
                    newStyle.BackColor = vbButtonFace
                    Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfRecpNo)
                    cellRange.Style = newStyle    '薄いｸﾞﾚｰ

                    .Styles.Normal.Border.Color = ColorTranslator.FromWin32(CPlngGridGray)
                Next llngCnt
                
                
                '@------------------------------------
                '@ﾚｼﾋﾟｺﾝﾎﾞｾｯﾄ
                '@------------------------------------
                lblnAns = vsfRecpCmb_Set(llngRecpCnt)
                
                '@戻り値判定
                If lblnAns = False Then
                    
                    '@-----------------------------------------------
                    '@選択可能なﾚｼﾋﾟ取得に失敗した場合はｸﾞﾘｯﾄﾞｸﾘｱする。
                    '@  ﾚｼﾋﾟ画面表示中に他端末でCMPﾒﾝﾃﾅﾝｽ画面にて
                    '@  CMP装置を使用禁止された場合の対応
                    '@-----------------------------------------------
                    '@ｸﾞﾘｯﾄﾞの初期化(初期化)
                    Call prvvsfRecp_Init(CMlngVsfInit)
                    
                    Exit Sub
                End If
                
                '@ﾚｼﾋﾟﾘｽﾄ件数が数値の場合
                If IsNumeric(vsfWp.GetData(vsfWp.Row, CMvsfWPColRecpListCnt)) = True Then
                    '@ﾚｼﾋﾟﾘｽﾄ件数格納
                    llngCmbRecpCnt = CLng((vsfWp.GetData(vsfWp.Row, CMvsfWPColRecpListCnt)))
                End If
                
                '@枚葉ﾚｼﾋﾟの場合
                If mlngClassRecp = CMlngWFRecp Then
                    '@ﾛｯﾄﾚｼﾋﾟの場合
                    If optRecp0.Checked = True Then
                        '@ﾚｼﾋﾟが1つの場合
                        If llngCmbRecpCnt = 1 Then
                            '@確定ﾎﾞﾀﾝﾛｯｸ解除
                            cmdKakutei.Enabled = True
                        End If
                    End If
                End If
                
                '@-----------------------
                '@ｸﾞﾘｯﾄﾞ幅制御処理
                '@-----------------------
                '@ﾚｼﾋﾟID列
                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    .AutoSizeCol(CMlngvsfRecpRecpID, 6)
                End If
                '@ﾚｼﾋﾟID列幅変更(▼幅加算)
                .Cols(CMlngvsfRecpRecpID).Width = .Cols(CMlngvsfRecpRecpID).Width  + CMlngvsfRecpCmbWidth                     'ﾚｼﾋﾟID
                '@ｶﾚﾝﾄ行設定
                .Row = .Rows.Count - 1
                '@先頭ﾍﾟｰｼﾞ設定
                .TopRow = .Rows.Count - 1
                '@行の高さ指定
                For llngCnt = 1 To .Rows.Count - 1
                    .Rows(llngCnt).Height = CMvsfRecpHeight
                Next
                .Rows.DefaultSize = CMvsfRecpHeight
                .Rows(0).Height = CMlngvsfTitleRowHeight
                       
                       
                '@-----------------------
                '@ﾃﾞｼﾋﾟﾎﾞﾃﾞｨ表示可否制御処理
                '@ﾃﾞｼﾋﾟﾎﾞﾃﾞｨ設定が無い場合は非表示にする
                '@-----------------------
                
                lblnReticleHidden = True        'ﾚﾁｸﾙ列の非表示ﾌﾗｸﾞ(False:表示、True:非表示)
                
                For llngCnt = 1 To .Rows.Count - 1
                    If .GetData(llngCnt, CMlngvsfRecpItem) <> vbNullString Then
                        '@ﾃﾞｼﾋﾟﾎﾞﾃﾞｨが１件でも有る場合は表示する
                        lblnReticleHidden = False
                        Exit For
                    End If
                Next
                
                '@ﾎﾞﾃﾞｨの非表示ﾌﾗｸﾞ判定
                If lblnReticleHidden = True Then
                    .Cols(CMlngvsfRecpValue).Visible = false              '非表示にする
                    .Cols(CMlngvsfRecpItem).Visible  = false              '非表示にする
                Else
                    .Cols(CMlngvsfRecpValue).Visible = True               '表示する
                    .Cols(CMlngvsfRecpItem).Visible  = True               '表示する
                End If

                '@直接描画
                '.Redraw = True

            End With

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "vsfRecp_Disp"           '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()


        End Try
    End Sub

    '関数名：prvfrmxxCM0050_CmbInit
    '機　能：ｺﾝﾄﾛｰﾙ制御
    '引　数：lblnEnable：True:使用可能,False:使用不可
    '戻り値：なし
    '作成日：2004/08/04 (Wed) 16:03:51 M.Miura
    '更新日：2004/08/04 (Wed) 16:03:51
    '備　考：
    Private Sub prvfrmxxCM0050_CmbInit(Optional ByVal lblnEnable As Boolean = False)
        
        Try
            
            '@無効の場合
            If lblnEnable = False Then
                '@ﾛｯﾄﾚｼﾋﾟが選ばれている場合
                If optRecp0.Checked  = True Then
                    '@ﾛｯﾄﾚｼﾋﾟ初期化
                    optRecp0.Checked  = False
                End If
                '@枚葉ﾚｼﾋﾟが選ばれている場合
                If optRecp0.Checked  = True Then
                    '@枚葉ﾚｼﾋﾟ初期化
                    optRecp1.Checked  = False
                End If
            End If

            '@有効無効設定
            cmdKakutei.Enabled = lblnEnable              '確定ﾎﾞﾀﾝ

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxCM0050_CmbInit"     '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()


        End Try
    End Sub

    '関数名：prvblnWfRecpList_Set
    '機　能：ﾚｼﾋﾟ情報取得＆表示
    '引　数：なし
    '戻り値：True：正常、False：異常
    '作成日：2004/08/05 (Thu) 09:05:50 M.Miura
    '更新日：2005/02/10 (Thu) 14:55:01 N.Kasai
    '備　考：
    '　　　：2004/08/25 (Wed) 21:01:46 N.Kojima     該当ﾃﾞｰﾀが1件しかない場合は、ﾚｼﾋﾟ選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝは
    '　　　　　　　　　　　　　　　　　　　　　　　    押すことが出来ないように修正(2299～2305行目)。
    '　　　：2004/09/03 (Fri) 13:35:06 M.Miura      装置ｸﾞﾘｯﾄﾞ情報からﾚｼﾋﾟを取得するように修正(不具合№554)
    '　　　：2005/02/10 (Thu) 14:55:01 N.Kasai      枚葉ﾚｼﾋﾟでｽﾛｯﾄ№01が空白の場合ﾚｼﾋﾟIDが取得できない対応
    '　　　：2005/12/15 (Thu) 08:55:36 S.Deguchi    ﾚｼﾋﾟ情報取得処理で,ClassDivision変更(23⇒42)
    Private Function prvblnWfRecpList_Set() As Boolean
        
        Dim llngCnt                     As Integer              'ｶｳﾝﾄ
        Dim lblnAns                     As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrWFID                    As String               'WFID
        Dim lstrWpId                    As String               'WPID
        Dim lstrAltNumber               As String               '代替番号
        Dim lstrOpID                    As String               '大工程
        Dim lstrStepID                  As String               '小工程
        Dim lstrOriginalRecpFlag        As String               '個別ﾚｼﾋﾟﾌﾗｸﾞ(0：設定なし、1：個別ﾚｼﾋﾟ)
        Dim llngCmbRecpCnt              As Integer              'ﾚｼﾋﾟﾘｽﾄ件数
        
        Try

            '@----------------------------------------
            '@WPが選択されている場合のみﾚｼﾋﾟを取得する。
            '@----------------------------------------
            With vsfWp
                '@装置が選択されている場合
                If .Row >= .Rows.Fixed Then
                    '@送信情報格納
                    lstrOpID = .GetData(.Row, CMvsfWPColOpID)              '大工程
                    lstrStepID = .GetData(.Row, CMvsfWPColStepID)          '小工程
                    lstrWpId = .GetData(.Row, CMvsfWPColWpID)              '装置ID
                    lstrAltNumber = .GetData(.Row, CMvsfWPColAltNumber)    '代替番号
                Else
                    Exit Function
                End If
            End With
            
            '@----------------------------------------
            '@要求MSG内容判定
            '@----------------------------------------
            '@ﾛｯﾄID、大工程、小工程、装置ID、代替番号がある場合
            If lblLotID.Text <> vbNullString And _
               lstrOpID <> vbNullString And _
               lstrStepID <> vbNullString And _
               lstrWpId <> vbNullString And _
               lstrAltNumber <> vbNullString Then
                '@処理続行(上記の設定が満たされていない場合はﾚｼﾋﾟ取得不可)
            Else
                Exit Function
            End If
            
            '@----------------------------------------
            '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟ取得
            '@----------------------------------------
            
            '@ﾚｼﾋﾟ情報取得＆表示
            prvblnWfRecpList_Set = True
            
            '@WFﾄﾗﾝﾚｼﾋﾟ初期化
            If ptypRecp23List Is Nothing Then 
                ptypRecp23List = New List(Of Lotrecplist) 
            Else 
                ptypRecp23List.Clear()
            End If
            
            '@工順変更ﾚｼﾋﾟﾌﾗｸﾞ初期化
            mstrProcChangeRecipeFlag = vbNullString
            '@ﾚｼﾋﾟ設定を初期化
            lblOriginalRecp.Text = vbNullString
            '@ﾚｼﾋﾟﾘｽﾄ件数初期化
            mlngLotRecpListCnt = 0

            'NSYS ハイライト色不具合対応
            vsfWP.Refresh

            '@【ﾛｯﾄﾚｼﾋﾟﾘｽﾄ取得(CPstrCD42：ﾃﾞﾌｫﾙﾄﾚｼﾋﾟ)】
            lblnAns = pubblnLotrecplist_Sel(CMstrlot_recplistVer, _
                                            lblLotID.Text, _
                                            lstrOpID, _
                                            lstrStepID, _
                                            lstrWpId, _
                                            CPstrCD42, _
                                            CMlngEqFlag, _
                                            lstrAltNumber, _
                                            mlngLotRecpListCnt, _
                                            lstrOriginalRecpFlag, _
                                            mstrProcChangeRecipeFlag, _
                                            mstrUserSelectFlag)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｼﾋﾟ情報取得＆表示
                prvblnWfRecpList_Set = False
                Exit Function
            End If
            
            
            '@ﾚｼﾋﾟがある場合
            If mlngLotRecpListCnt > 0 Then
                
                '@--------------------
                '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝの使用制限
                '@工順変更が設定済みの場合は無条件でﾚｼﾋﾟ変更不可
                '@--------------------
                
                '@ﾚｼﾋﾟ設定変更不可(工順変更により設定済み)の場合
                If mstrProcChangeRecipeFlag = CMstrProcChangeRecipeFlag1 Then
                    '@ﾚｼﾋﾟ設定に「工順変更設定済み」をｾｯﾄ
                    lblOriginalRecp.Text = CMstrNgChgRecipe
                    '@取消ﾎﾞﾀﾝを無効
                    cmdCancel.Enabled = False
                    '@ｺﾝﾄﾛｰﾙ無効
                    optRecp0.Enabled = False    'ﾛｯﾄﾚｼﾋﾟ
                    optRecp1.Enabled = False     'WFﾚｼﾋﾟ
                    
                Else
                    '@個別ﾚｼﾋﾟﾌﾗｸﾞ判定
                    Select Case lstrOriginalRecpFlag
                        '@設定なし(ﾃﾞﾌｫﾙﾄ)の場合
                        Case CMstrOriginalRecpFlag0
                            '@ﾚｼﾋﾟ設定に「デフォルト」をｾｯﾄ
                            lblOriginalRecp.Text = CMstrDefaultRecipe
                            '@取消ﾎﾞﾀﾝを無効
                            cmdCancel.Enabled = False
                            '@ｺﾝﾄﾛｰﾙ有効
                            optRecp0.Enabled = True    'ﾛｯﾄﾚｼﾋﾟ
                            optRecp1.Enabled = True     'WFﾚｼﾋﾟ
                            
                        '@個別ﾚｼﾋﾟの場合
                        Case CMstrOriginalRecpFlag1
                            '@ﾚｼﾋﾟ設定に「個別レシピ」をｾｯﾄ
                            lblOriginalRecp.Text = CMstrOriginalRecipe
                            '@取消ﾎﾞﾀﾝを有効
                            cmdCancel.Enabled = True
                            
                             '@ｺﾝﾄﾛｰﾙ無効
                            optRecp0.Enabled = False    'ﾛｯﾄﾚｼﾋﾟ
                            optRecp1.Enabled = False     'WFﾚｼﾋﾟ
                            
                        Case Else
                            '@ﾚｼﾋﾟ設定に「レシピなし」をｾｯﾄ
                            lblOriginalRecp.Text = CMstrNoneRecipe
                            '@取消ﾎﾞﾀﾝを無効
                            cmdCancel.Enabled = False
                            '@ｺﾝﾄﾛｰﾙ有効
                            optRecp0.Enabled = True    'ﾛｯﾄﾚｼﾋﾟ
                            optRecp1.Enabled = True     'WFﾚｼﾋﾟ
                            
                    End Select
                    
                End If
                
                 If ptypRecp23List Is Nothing Then 
                    ptypRecp23List = New List(Of Lotrecplist) 
                Else 
                    ptypRecp23List.Clear()
                End If
                '@WF別ﾄﾗﾝﾚｼﾋﾟ格納
                For Each lot As Lotrecplist In ptypLotrecpList
                    Dim tmp As Lotrecplist = New Lotrecplist()
                    tmp.strSlotPosition   = lot.strSlotPosition
                    tmp.strWFID           = lot.strWFID
                    tmp.strRecipeId       = lot.strRecipeId
                    tmp.strRecipeComment  = lot.strRecipeComment
                    tmp.strDefaultFlag    = lot.strDefaultFlag
                    tmp.lngRecipeBodyList = lot.lngRecipeBodyList
                    If Not IsNothing(lot.typRecipeBodyList) Then
                        tmp.typRecipeBodyList = New List(Of RecipeBodyList)(lot.typRecipeBodyList)
                    End If
                    ptypRecp23List.Add(tmp)
                Next

                '@---------------------------------------------------------
                '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝの表示制御
                '@(ﾛｯﾄﾚｼﾋﾟ/WFﾚｼﾋﾟ)
                '@取得したﾚｼﾋﾟﾎﾞﾃﾞｨにWFIDが設定されている場合はWFﾚｼﾋﾟと判断
                '@---------------------------------------------------------
                '@初期化
                lstrWFID = vbNullString
                '@ﾚｼﾋﾟﾘｽﾄｶｳﾝﾄ分ﾙｰﾌﾟ
                For llngCnt = 0 To mlngLotRecpListCnt-1
                    '@ﾚｼﾋﾟIDが空白以外を判定
                    If ptypLotrecpList(llngCnt).strWfId <> vbNullString Then
                        lstrWFID = ptypLotrecpList(llngCnt).strWfId
                        '@1つでも存在する場合は枚葉ﾚｼﾋﾟと判定
                        Exit For
                    End If
                Next
                
                '@WFIDがない(ﾛｯﾄﾚｼﾋﾟの)場合
                If lstrWFID = vbNullString Then
                    '@初期ﾚｼﾋﾟ(ﾛｯﾄﾚｼﾋﾟ)
                    mlngClassRecp = CMlngLotRecp
                    '@ﾛｯﾄﾚｼﾋﾟにﾁｪｯｸ
                    optRecp0.Checked = True
                Else
                    '@初期ﾚｼﾋﾟ(ﾛｯﾄﾚｼﾋﾟ)
                    mlngClassRecp = CMlngWFRecp
                    '@枚葉ﾚｼﾋﾟにﾁｪｯｸ
                    optRecp1.Checked  = True
                End If
                
                '@ﾚｼﾋﾟﾘｽﾄ件数が数値の場合
                If IsNumeric(vsfWp.GetData(vsfWp.Row, CMvsfWPColRecpListCnt)) = True Then
                    '@ﾚｼﾋﾟﾘｽﾄ件数格納
                    llngCmbRecpCnt = CLng((vsfWp.GetData(vsfWp.Row, CMvsfWPColRecpListCnt)))
                End If
                            
                '@ﾚｼﾋﾟが1件以下の場合でﾕｰｻﾞｰ選択ﾌﾗｸﾞがﾚｼﾋﾟ変更不可の場合
                If llngCmbRecpCnt <= CMlngRecipeCnt _
                    And (mstrUserSelectFlag = CMstrUserSelectFlag0 _
                    Or mstrUserSelectFlag = vbNullString) Then
                    If mblnChgRecpFlag = False Then
                        '@ﾛｯﾄﾚｼﾋﾟを無効に
                        optRecp0.Enabled = False
                        '@枚葉ﾚｼﾋﾟを無効に
                        optRecp1.Enabled = False
                    End If
                End If
            Else
                '@ｺﾝﾄﾛｰﾙ無効
                optRecp0.Enabled = False    'ﾛｯﾄﾚｼﾋﾟ
                optRecp1.Enabled = False     'WFﾚｼﾋﾟ
                '@ﾚｼﾋﾟ設定に「レシピなし」をｾｯﾄ
                lblOriginalRecp.Text = CMstrNoneRecipe
                Exit Function
            End If
            
                Exit Function

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvblnWfRecpList_Set"   '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function


    '関数名：prvColor_init
    '機　能：ｺﾝﾄﾛｰﾙの色の初期化（青色化）
    '引　数：なし
    '戻り値：なし
    '作成日：2008/07/03 (Thu) 09:50:02 M.Koni   <案件No.03006>新規作成
    '更新日：
    '備　考：
    '　　　：
    Private Sub prvColor_init()

        Try

            '@ｺﾝﾄﾛｰﾙのﾀｲﾄﾙを青にする
            lblTtl0.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
            lblTtl1.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
            lblTtl2.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
            lblTtl3.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
            lblTtl5.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
            lblTtl6.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
            lblTtl7.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
            lblTtl8.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
            lblTtl9.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
            lblTtl10.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
            lblTtl15.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
         
            lblStartTime.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
            lblTitle0.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
            lblTitle1.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
            lblLengthCount.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)

            '@工程，装置名の行の色を変更(0,0-0,4)
            Dim newStyle As CellStyle = vsfWp.Styles.Add("CustomStyle_BackColor_CPlngBlueColor")
            newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
            newStyle.ForeColor = ColorTranslator.FromWin32(CPlngBatchPair)
            newStyle.TextAlign = TextAlignEnum.CenterCenter
            Dim cellRange As CellRange = vsfWp.GetCellRange(0, 0, 0, 4)
            cellRange.Style = newStyle
                    
            '@ﾚｼﾋﾟﾀｲﾄﾙ欄(0,0-0,10)
            newStyle  = vsfRecp.Styles.Add("CustomStyle_BackColor_CPlngBlueColor")
            newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
            newStyle.ForeColor = ColorTranslator.FromWin32(CPlngBatchPair)
            newStyle.Font = New Font(vsfRecp.Font.FontFamily, CType(CMlngvsfTitleFontSize, Single), vsfRecp.Font.Style, vsfRecp.Font.Unit)
            newStyle.TextAlign = TextAlignEnum.CenterCenter
            cellRange  = vsfRecp.GetCellRange(0, 0, 0, 9)
            cellRange.Style = newStyle

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvColor_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：prvvsfWP_init
    '機　能：装置一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/10 (Tue) 14:27:27 M.Miura
    '更新日：2005/10/03 (Mon) 14:22:19 N.Kojima
    '備　考：
    '　　　：2005/06/29 (Wed) 15:20:20 S.Deguchi    不具合№212の対応で,ﾛｯﾄﾚｼﾋﾟ設定ﾌﾗｸﾞ欄(隠しCol)を追加
    '　　　：2005/10/03 (Mon) 14:22:19 N.Kojima     Loader/Unloaderﾌﾗｸﾞ欄追加(隠しCol)。(不具合№3163)
    Private Sub prvvsfWP_init()

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfWp
                '@描画なし
                .Redraw = false
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                '@列数設定
                .Cols.Count = CMvsfWPCols
                '@固定列の設定
                .Cols.Frozen = .Cols.Fixed -1
                '@行列のﾏｳｽでの変更を不可にする
                .AllowResizing = AllowResizingEnum.None
                '@ｾﾙ選択の設定
                .SelectionMode = SelectionModeEnum.Row
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                '@ﾊｲﾗｲﾄ表示
                .HighLight = HighLightEnum.Always
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定(なし)
                .FocusRect = FocusRectEnum.Solid
                '@列の調整を不可にする
                '.AutoSizeMode = flexAutoSizeColWidth
                '@文章の折り返しなし
                .Styles.Normal.WordWrap = False
                
                '@一覧表の表題設定
                '.Select(CMvsfWPTitleRow, .Cols.Fixed, CMvsfWPTitleRow, .Cols.Count - 1)
                Dim newStyle_title As CellStyle = .Styles.Add("CustomStyle_Title")
                Dim cellRange As CellRange = .GetCellRange(CMvsfWPTitleRow, .Cols.Fixed, CMvsfWPTitleRow, .Cols.Count - 1)
                newStyle_title.ForeColor = Color.Yellow                  '文字色
                newStyle_title.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))      '背景色
                newStyle_title.Font = New Font(.Font.FontFamily, CType(CMlngvsfTitleFontSize, Single), .Font.Style, .Font.Unit) 'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                newStyle_title.TextAlign = TextAlignEnum.CenterCenter   '中央表示
                newStyle_title.Trimming  = StringTrimming.None 'NSYS ﾍｯﾀﾞは省略表示なしに設定
                cellRange.Style = newStyle_title
                .Rows(CMvsfWPTitleRow).Height = CMlngvsfTitleRowHeight    '高さ
                     
                '@列幅設定
                .Cols(CMvsfWPColNo).Width = CMvsfWPColWNo                                                 '№
                .Cols(CMvsfWPColOpID).Width = CMvsfWPColWOpID                                             '大工程
                .Cols(CMvsfWPColStepID).Width = CMvsfWPColWStepID                                         '小工程
                .Cols(CMvsfWPColDefault).Width = CMvsfWPColWDefault                                       'ﾃﾞﾌｫﾙﾄ
                .Cols(CMvsfWPColWpName).Width = CMvsfWPColWWpName                                         '装置名
                .Cols(CMvsfWPColWpID).Width = CMvsfWPColWWpID                                             '装置ID
                .Cols(CMvsfWPColAltNumber).Width = CMvsfWPColWAltNumber                                   '代替番号
                .Cols(CMvsfWPColEqType).Width = CMvsfWPColWEqType                                         '装置ﾀｲﾌﾟ
                .Cols(CMvsfWPColRecpList).Width = CMvsfWPColWRecpList                                     'ｺﾝﾎﾞのﾚｼﾋﾟﾘｽﾄ
                .Cols(CMvsfWPColRecpListCnt).Width = CMvsfWPColWRecpListCnt                               'ｺﾝﾎﾞのﾚｼﾋﾟﾘｽﾄ件数
                .Cols(CMvsfWPColLotRecipeFlag).Width = CMvsfWPColWLotRecipeFlag                           'ﾛｯﾄﾚｼﾋﾟ設定ﾌﾗｸﾞ
                .Cols(CMvsfWPColLoaderUnloaderFlag).Width = CMvsfWPColWLoaderUnloaderFlag                 'Loader/Unloaderﾌﾗｸﾞ
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMvsfWPTitleRow, CMvsfWPColNo, CMvsfWPColTNo)                        '№
                .SetData(CMvsfWPTitleRow, CMvsfWPColOpID, CMvsfWPColTOpID)                    '大工程
                .SetData(CMvsfWPTitleRow, CMvsfWPColStepID, CMvsfWPColTStepID)                '小工程
                .SetData(CMvsfWPTitleRow, CMvsfWPColDefault, CMvsfWPColTDefault)              'ﾃﾞﾌｫﾙﾄ
                .SetData(CMvsfWPTitleRow, CMvsfWPColWpName, CMvsfWPColTWpName)                '装置名
                .SetData(CMvsfWPTitleRow, CMvsfWPColWpID, CMvsfWPColTWpID)                    '装置ID
                .SetData(CMvsfWPTitleRow, CMvsfWPColAltNumber, CMvsfWPColTAltNumber)          '代替番号
                .SetData(CMvsfWPTitleRow, CMvsfWPColEqType, CMvsfWPColTEqType)                '装置ﾀｲﾌﾟ
                .SetData(CMvsfWPTitleRow, CMvsfWPColRecpList, CMvsfWPColTRecpList)            'ｺﾝﾎﾞのﾚｼﾋﾟﾘｽﾄ
                .SetData(CMvsfWPTitleRow, CMvsfWPColRecpListCnt, CMvsfWPColTRecpListCnt)      'ｺﾝﾎﾞのﾚｼﾋﾟﾘｽﾄ件数
                .SetData(CMvsfWPTitleRow, CMvsfWPColLotRecipeFlag, CMvsfWPColTLotRecipeFlag)  'ﾛｯﾄﾚｼﾋﾟ設定ﾌﾗｸﾞ
                .SetData(CMvsfWPTitleRow, CMvsfWPColLoaderUnloaderFlag, CMvsfWPColTLoaderUnloaderFlag)  'Loader/Unloaderﾌﾗｸﾞ
                
                '@非表示設定
                .Cols(CMvsfWPColNo).Visible = False                                            '№
                .Cols(CMvsfWPColWpID).Visible = False                                          '装置ID
                .Cols(CMvsfWPColAltNumber).Visible = False                                     '代替番号
                .Cols(CMvsfWPColEqType).Visible = False                                        '装置ﾀｲﾌﾟ
                .Cols(CMvsfWPColRecpList).Visible = False                                      'ﾚｼﾋﾟﾘｽﾄ(ｺﾝﾎﾞ)
                .Cols(CMvsfWPColRecpListCnt).Visible = False                                   'ﾚｼﾋﾟﾘｽﾄ件数
                .Cols(CMvsfWPColLotRecipeFlag).Visible = False                                 'ﾛｯﾄﾚｼﾋﾟ設定ﾌﾗｸﾞ
                .Cols(CMvsfWPColLoaderUnloaderFlag).Visible = False                            'Loader/Unloaderﾌﾗｸﾞ
                
                '@列位置の設定
                .Cols(CMvsfWPColNo).TextAlign = TextAlignEnum.RightCenter                      '№(右寄せ中央揃え)
                .Cols(CMvsfWPColOpID).TextAlign = TextAlignEnum.LeftCenter                     '大工程(左寄せ中央揃え)
                .Cols(CMvsfWPColStepID).TextAlign = TextAlignEnum.LeftCenter                   '小工程(左寄せ中央揃え)
                .Cols(CMvsfWPColDefault).TextAlign = TextAlignEnum.LeftCenter                  'ﾃﾞﾌｫﾙﾄ(左寄せ中央揃え)
                .Cols(CMvsfWPColWpName).TextAlign = TextAlignEnum.LeftCenter                   '装置名(左寄せ中央揃え)
                        
                '@ﾛｯｸ
                .Enabled = False
                '@直接描画
                .Redraw = True
                
            End With
                
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ
            cmdUP.Enabled = False       '前頁
            cmdDown.Enabled = False     '次頁
                
            '@装置件数ｸﾘｱ
            lblWpCnt.Text = vbNullString
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvvsfWP_init"          '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvvsfWP_Disp
    '機　能：装置(WPID)一覧の設定
    '引　数：ltypLotWpList：装置情報格納用構造体
    '戻り値：なし
    '作成日：2004/08/10 (Tue) 14:45:21 M.Miura
    '更新日：2005/10/03 (Mon) 14:26:22 N.Kojima
    '備　考：True：正常、False：異常
    '　　　：2005/02/18 (Fri) 09:33:52 N.Kasai      処理区分変更(10→1K)
    '　　　：2005/06/29 (Wed) 15:20:20 S.Deguchi    不具合№212の対応で,ﾛｯﾄﾚｼﾋﾟ設定ﾌﾗｸﾞ欄(隠しCol)を追加
    '　　　：2005/10/03 (Mon) 14:26:22 N.Kojima     Loader/Unloaderﾌﾗｸﾞ欄追加(隠しCol)。(不具合№3163)
    Private Function prvvsfWP_Disp(ByRef ltypLotprestate As Lotprestate) As Boolean
        
        Dim llngCnt             As Integer      'ｶｳﾝﾀ変数
        Dim llngWpCnt           As Integer      '装置ｶｳﾝﾄ
        Dim llngRowCnt          As Integer      'ｶｳﾝﾀ変数
        Dim lstrOpID            As String       '大工程ID
        Dim lstrStepID          As String       '小工程ID
        Dim lstrAltNumber       As String       '代替番号
        Dim lstrLotID           As String       'ﾛｯﾄID
        Dim lblnAns             As Boolean      '戻り値
        Dim ltypLotWpList       As LotWpList    '装置情報構造体
        Dim lstrClassDivision   As String       '処理区分
        
        Try

            '@ﾛｯﾄ状態
            Select Case ltypLotprestate.strNowST
                '@「作業待ち」の場合
                Case CPstrWaitWorkSt
                    '@処理区分「10」
                    lstrClassDivision = CPstrCD1K
                '@「前処理」の場合
                Case CPstrBeforeProgressSt
                    '@処理区分「11」
                    lstrClassDivision = CPstrCD11
                Case Else
                    lstrClassDivision = vbNullString
            End Select
                
            '@装置一覧格納(ptypLotequipmntList)から装置ｸﾞﾘｯﾄﾞへｾｯﾄ
            With vsfWp
                llngCnt = 1
                llngRowCnt = .Rows.Fixed
                
                
                '@ﾛｯｸ解除
                .Enabled = True
                
                .Redraw = false

                '@行数設定
                For llngCnt = 0 To ltypLotprestate.lngStepListCnt-1
                    '@大小工程ID、または、代替番号が変わったら装置取得
                    If lstrOpID <> ltypLotprestate.strSteplist(llngCnt).strOpID Or _
                       lstrStepID <> ltypLotprestate.strSteplist(llngCnt).strStepID Or _
                       lstrAltNumber <> ltypLotprestate.strSteplist(llngCnt).strAltNumber Then
                        '@次回比較用大小工程、代替番号格納
                        lstrOpID = ltypLotprestate.strSteplist(llngCnt).strOpID
                        lstrStepID = ltypLotprestate.strSteplist(llngCnt).strStepID
                        lstrAltNumber = ltypLotprestate.strSteplist(llngCnt).strAltNumber

                        lstrLotID = ltypLotprestate.strLotID
                        
                        '@装置情報取得
                        lblnAns = pubblnLotWplist_Sel(CMstrlot_wplist__Ver, _
                                                      lstrClassDivision, _
                                                      lstrLotID, _
                                                      ltypLotprestate.strSteplist(llngCnt).strOpID, _
                                                      ltypLotprestate.strSteplist(llngCnt).strStepID, _
                                                      lstrAltNumber, _
                                                      ltypLotWpList)

                        '@結果判定
                        If lblnAns = False Then
                            '@直接描画
                            .Redraw = True
                            
                            Exit Function
                        End If
                        
                        '@ﾛｯﾄ情報格納構造体のWP配列の初期化
                        Dim tmpstepList As stepList = ltypLotprestate.strSteplist(llngCnt)
                        tmpstepList.lngWPListCnt = 0
                        If Not IsNothing(tmpstepList.strWPList) Then                          
                            tmpstepList.strWPList = New List(Of WP) 
                        Else 
                            tmpstepList.strWPList.Clear()
                        End If
                        
                        '@装置ｸﾞﾘｯﾄ格納
                        RemoveHandler vsfWP.AfterRowColChange, AddressOf vsfWP_AfterRowColChange
                        For llngWpCnt = 0 To ltypLotWpList.lngWPCnt-1
                            .Rows.Count = .Rows.Count + 1
                            .SetData(llngRowCnt, CMvsfWPColNo, llngRowCnt)                                                              '№
                            .SetData(llngRowCnt, CMvsfWPColOpID, ltypLotprestate.strSteplist(llngCnt).strOpID)                          '大工程
                            .SetData(llngRowCnt, CMvsfWPColStepID, ltypLotprestate.strSteplist(llngCnt).strStepID)                      '小工程
                            .SetData(llngRowCnt, CMvsfWPColAltNumber, ltypLotprestate.strSteplist(llngCnt).strAltNumber)                '代替番号
                            
                            '@工程ﾌﾗｸﾞがﾃﾞﾌｫﾙﾄ工程の場合
                            If ltypLotprestate.strSteplist(llngCnt).strStepDivision = CMstrStepdivisionDefault Then
                                .SetData(llngRowCnt, CMvsfWPColDefault, CMstrDefault)                                                   'ﾃﾞﾌｫﾙﾄに「○」をｾｯﾄ
                            End If
                            .SetData(llngRowCnt, CMvsfWPColWpName, ltypLotWpList.typWpList(llngWpCnt).strWpName)                        '装置
                            .SetData(llngRowCnt, CMvsfWPColWpID, ltypLotWpList.typWpList(llngWpCnt).strWpID)                            '装置ID
                            .SetData(llngRowCnt, CMvsfWPColEqType, ltypLotWpList.typWpList(llngWpCnt).strEqType)                        '装置ﾀｲﾌﾟ
                            
                            .SetData(llngRowCnt, CMvsfWPColLotRecipeFlag, ltypLotWpList.typWPList(llngWpCnt).strLotRecipeFlag)          'ﾛｯﾄﾚｼﾋﾟ設定ﾌﾗｸﾞ
                            
                           .SetData(llngRowCnt, CMvsfWPColLoaderUnloaderFlag, ltypLotWpList.typWPList(llngWpCnt).strLoaderUnloaderFlag) 'Loader/Unloaderﾌﾗｸﾞ
                            
                            '@行の高さ設定
                            .Rows(llngRowCnt).Height = CMlngvsfRowHeight
                            llngRowCnt = llngRowCnt + 1
                                        
                        Next llngWpCnt
                        .Row = 0
                        AddHandler vsfWP.AfterRowColChange, AddressOf vsfWP_AfterRowColChange
                    End If
                Next llngCnt
                
                '@直接描画
                .Redraw = True
            End With
            
            '@装置一覧初期ﾎﾞﾀﾝ設定
            Call pubVsfDisp(vsfWp, cmdUP, cmdDown)
            
            '@装置件数ｾｯﾄ
            lblWpCnt.Text = vsfWp.Rows.Count - 1
            
            prvvsfWP_Disp = True
            
            Exit Function

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvvsfWP_Disp"          '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvRecp_Set
    '機　能：ﾚｼﾋﾟID取得(ﾚｼﾋﾟ変更確認用)
    '引　数：lblnBefore：True：変更前、False：変更後
    '戻り値：なし
    '作成日：2004/09/07 (Tue) 11:56:08 M.Miura
    '更新日：2004/09/07 (Tue) 11:56:08
    '備　考：
    Private Sub prvRecp_Set(ByVal lblnBefore As Boolean)
        
        Dim llngCnt As Integer 'ｶｳﾝﾄ
        
        Try

            '@変更前の場合
            If lblnBefore = True Then
                '@ﾚｼﾋﾟ変更前を初期化
                mstrChgRecpBefore = vbNullString
                
                With vsfRecp
                    '@最下段行になるまで
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@ｽﾛｯﾄ№とﾚｼﾋﾟIDを格納
                        mstrChgRecpBefore = mstrChgRecpBefore & .GetData(llngCnt, CMlngvsfRecpNo) & _
                                                                .GetDataDisplay(llngCnt, CMlngvsfRecpRecpID)

                    Next llngCnt
                End With
                
            Else
                '@変更後の場合
                '@ﾚｼﾋﾟ変更前を初期化
                mstrChgRecpAfter = vbNullString
                
                With vsfRecp
                    '@最下段行になるまで
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@ｽﾛｯﾄ№とﾚｼﾋﾟIDを格納
                        mstrChgRecpAfter = mstrChgRecpAfter & .GetData(llngCnt, CMlngvsfRecpNo) & _
                                                                .GetDataDisplay(llngCnt, CMlngvsfRecpRecpID)
                    Next llngCnt
                End With
            End If

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvRecp_Set"            '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()


        End Try
    End Sub

    '関数名：prvblnRecp_Chk
    '機　能：WFﾚｼﾋﾟID存在ﾁｪｯｸ
    '引　数：なし
    '戻り値：True：正常、False：確定不可
    '作成日：2004/09/30 (Thu) 09:12:46 M.Miura
    '更新日：2004/09/30 (Thu) 09:12:46
    '備　考：
    Private Function prvblnRecp_Chk() As Boolean
        
        Dim llngCnt     As Integer  'ｶｳﾝﾄ
        
        Try

            With vsfRecp
                
                '@ﾃﾞｰﾀがない場合
                If .Rows.Count <= .Rows.Fixed Then
                    Exit Function
                End If
                
                '@枚葉ﾚｼﾋﾟの場合
                If optRecp1.Checked = True Then
                    '@ﾚｼﾋﾟ一覧の最下段まで
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@WFがあり、ﾚｼﾋﾟIDがある場合
                        If .GetDataDisplay(llngCnt, CMlngvsfRecpWFID) <> vbNullString And _
                           .GetDataDisplay(llngCnt, CMlngvsfRecpRecpID) <> CPstrSpace And _
                           .GetDataDisplay(llngCnt, CMlngvsfRecpRecpID) <> vbNullString And _
                           .GetDataDisplay(llngCnt, CMlngvsfRecpRecpID) <> CMstrNoneRecipe Then
                            '@正常
                            prvblnRecp_Chk = True
                            Exit Function
                        End If
                    Next llngCnt
                Else
                    '@ﾛｯﾄﾚｼﾋﾟの場合
                    '@ﾚｼﾋﾟIDがある場合
                    If .GetDataDisplay(.Rows.Fixed, CMlngvsfRecpRecpID) <> vbNullString And _
                       .GetDataDisplay(.Rows.Fixed, CMlngvsfRecpRecpID) <> CMstrNoneRecipe Then
                        '@正常
                        prvblnRecp_Chk = True
                        Exit Function
                    End If
                End If
            End With

            Exit Function

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvblnRecp_Chk"          '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()


        End Try
    End Function

    '関数名：prvvsfSlotMapTopRow_Set
    '機　能：ｽﾛｯﾄﾏｯﾌﾟの初期表示位置設定
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/26 (Tue) 16:26:12 M.Miura
    '更新日：2004/10/26 (Tue) 16:26:12
    '備　考：
    Private Sub prvVsfSlotMapTopRow_Set()

        Dim llngCnt     As Integer  'ｶｳﾝﾄ
        Dim lblnFlag    As Boolean  '行数
         
        Try
         
            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfRecp
                '@最大ｽﾛｯﾄが25より小さい、又はﾛｯﾄﾚｼﾋﾟの場合
                If mlngSlotMapRowS < CMlngvsfRecpRows Or _
                   optRecp0.Checked = True Then
                    '@ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行を最下段に設定
                    .Row = .Rows.Count - 1
                    '@ﾚｼﾋﾟID列に設定
                    .Col = CMlngvsfRecpRecpID
                    Exit Sub
                End If
                
                '@ｽﾛｯﾄ№01～10まで
                For llngCnt = .Rows.Count - 1 To .Rows.Fixed Step -1
                    
                    '@ｽﾛｯﾄ№が10を超えた場合
                    If .GetData(llngCnt, CMlngvsfRecpNo) > CMstrSlotNo10 Then
                        Exit For
                    End If
                    
                    '@WFが存在する場合
                    If .GetData(llngCnt, CMlngvsfRecpWFID) <> vbNullString Then
                        '@WFあり
                        lblnFlag = True
                        Exit For
                    End If
                Next llngCnt
                
                '@ｽﾛｯﾄ№01～10にWFがない場合
                If lblnFlag = False Then
                    '@ｽﾛｯﾄ№25～16まで
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@
                        '@ｽﾛｯﾄ№が16より小さくなった場合
                        If .GetData(llngCnt, CMlngvsfRecpNo) < CMstrSlotNo16 Then
                            Exit For
                        End If
                        '@WFが存在する場合
                        If .GetData(llngCnt, CMlngvsfRecpWFID) <> vbNullString Then
                            '@ｽﾛｯﾄﾏｯﾌﾟの初期表示は上部
                            lblnFlag = True
                            Exit For
                        End If
                    Next llngCnt
                Else
                    '@ｽﾛｯﾄﾏｯﾌﾟの初期表示は下部
                    lblnFlag = False
                End If
                
                '@ｽﾛｯﾄﾏｯﾌﾟ上部表示の場合
                If lblnFlag = True Then
                    '@ｽﾛｯﾄﾏｯﾌﾟの頁先頭行を設定
                    .TopRow = .Rows.Fixed
                    '@ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行を1行目に設定
                    .Row = .Rows.Fixed
                    '@前頁ﾎﾞﾀﾝを無効
                    cmdVsfUP.Enabled = False
                    '@最大ｽﾛｯﾄ数が1頁を超えている場合
                    If .Rows.Count > CMlngvsfRecpPageRows + 1 Then
                        '@次頁ﾎﾞﾀﾝを有効
                        cmdVsfDown.Enabled = True
                    Else
                        '@次頁ﾎﾞﾀﾝを無効
                        cmdVsfDown.Enabled = False
                    End If
                Else
                    '@ｽﾛｯﾄﾏｯﾌﾟの頁先頭行を設定
                    .TopRow = .Rows.Count - 1
                    '@ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行をﾀｲﾄﾙに設定
                    .Row = .Rows.Count - 1
                End If
                '@ﾚｼﾋﾟID列に設定
                .Col = CMlngvsfRecpRecpID
            End With
            
                Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvvsfSlotMapTopRow_Set"    '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvComboChang_Set
    '機　能：ｺﾝﾎﾞﾎﾞｯｸｽ変更後ﾚｼﾋﾟ表示
    '引　数：ltypLotrecplist()：ﾚｼﾋﾟ表示用格納構造体
    '　　　：llngCnt：対象表示INDEX
    '戻り値：なし
    '作成日：2005/06/03 (Fri) 15:51:30 N.Kasai
    '更新日：2006/08/18 (Fri) 09:48:38 N.Kojima
    '備　考：
    '　　　：2005/10/24 (Mon) 10:32:24 N.Kojima     ﾚｼﾋﾟValue=0の場合、画面に"0"が表示されるように修正。(不具合№3045)
    '　　　：2006/08/18 (Fri) 09:48:38 N.Kojima     ﾚｼﾋﾟﾊﾟﾗﾒｰﾀ(ﾚｼﾋﾟ値)の入力桁数を30byte⇒40byteに拡張(案件№01399)
    Private Sub prvComboChang_Set(ByRef ltypLotRecpList As List(of Lotrecplist), ByVal llngCnt As Integer)
        
        Dim llngRecipeBpdyCnt           As Integer  'ｶｳﾝﾄ
        Dim llngRow                     As Integer  '行ｶｳﾝﾄ
        Dim lstrSlotNo                  As String   'ｽﾛｯﾄ№退避用
        Dim lstrWFID                    As String   'WFID退避用
        '@↓2020/01/07 (Tue) 15:20:01 Y.Yoneyama 「.Netへ反映未」 **************************************************
        Dim lstrGRB                     As String   'GRB退避用
        '@↑2020/01/07 (Tue) 15:20:01 Y.Yoneyama 「.Netへ反映未」 **************************************************
        Dim llngSlotNoCnt               As Integer  'ｽﾛｯﾄ№ｶｳﾝﾄ
        Dim llngNum                     As Integer  '行数ｶｳﾝﾄ
        
        Try

            '@ｺﾝﾎﾞﾎﾞｯｸｽ表示
            With vsfRecp
                '@--------------------------------
                '@ﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄが1件以上の場合
                '@--------------------------------
                If ltypLotRecpList(llngCnt).lngRecipeBodyList > 0 Then
                    Select Case True
                        '@----------------------
                        '@ﾛｯﾄﾚｼﾋﾟの場合
                        '@----------------------
                        Case optRecp0.Checked

                            '@ｸﾞﾘｯﾄﾞの初期化(ﾛｯﾄﾚｼﾋﾟ)
                            Call prvvsfRecp_Init(CMlngLotRecp)
                            '@現在のﾚﾁｸﾙ数と異なる場合
                            If .Rows.Count <> ltypLotRecpList(llngCnt).lngRecipeBodyList + 1 Then
                                '@行数の設定
                                .Rows.Count = ltypLotRecpList(llngCnt).lngRecipeBodyList + 1
                            End If
                            
                            '@ﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄ数分ﾙｰﾌﾟ
                            For llngRecipeBpdyCnt = 0 To ltypLotRecpList(llngCnt).lngRecipeBodyList-1
                                '@現在の行がﾀｲﾄﾙ行の場合
                                If .Row = 0 Then
                                    '@1行目に移動
                                    .Row = 1
                                End If
                                llngRow = .Row + llngRecipeBpdyCnt

                                '@ﾏｰｼﾞ用に半角ｽﾍﾟｰｽをｾｯﾄする
                                .SetData(llngRow, CMlngvsfRecpNo, CPstrSpace)                                     '№
                                .SetData(llngRow, CMlngvsfRecpRecpID, ltypLotRecpList(llngCnt).strRecipeId)        'ﾚｼﾋﾟID設定
                                '@ﾚｼﾋﾟｺﾒﾝﾄ設定(改行ｺｰﾄﾞを半角ｽﾍﾟｰｽへ置換)
                                If ltypLotRecpList(llngCnt).strRecipeComment = vbNullString Then
                                    '@ﾏｰｼﾞ用にNULLの場合半角ｽﾍﾟｰｽをｾｯﾄする
                                    .SetData(llngRow, CMlngvsfRecpComment, CPstrSpace)
                                Else
                                    .SetData(llngRow, CMlngvsfRecpComment, _
                                            Replace(ltypLotRecpList(llngCnt).strRecipeComment, vbCrLf, CPstrSpace))           'ﾚｼﾋﾟｺﾒﾝﾄ
                                End If
                                .SetData(llngRow, CMlngvsfRecpItem, _
                                    ltypLotRecpList(llngCnt).typRecipeBodyList(llngRecipeBpdyCnt).strRecipeItem)              'ﾚｼﾋﾟｱｲﾃﾑ
                                .SetData(llngRow, CMlngvsfRecpVariable, _
                                    ltypLotRecpList(llngCnt).typRecipeBodyList(llngRecipeBpdyCnt).strVariableFlag)            '変更可否F
                                .SetData(llngRow, CMlngvsfRecptype, _
                                    ltypLotRecpList(llngCnt).typRecipeBodyList(llngRecipeBpdyCnt).strValueType)               'ﾃﾞｰﾀﾀｲﾌﾟ
                                .SetData(llngRow, CMlngvsfRecpDigit, _
                                    ltypLotRecpList(llngCnt).typRecipeBodyList(llngRecipeBpdyCnt).strItemValidDigit)         '小数点以下制御
                                
        '@↓2006/08/18 (Fri) 10:01:02 N.Kojima **************************************************
        '@文字ﾀｲﾌﾟの場合は、40byteまで入力可に変更(※元は30byte)

                                '@------------------------------------------
                                '@表示位置の設定
                                '@ﾃﾞｰﾀﾀｲﾌﾟの判定を行う。(CMstrDataTypeN:数値)
                                '@------------------------------------------
                                If ltypLotRecpList(llngCnt).typRecipeBodyList(llngRecipeBpdyCnt).strValueType = CMstrDataTypeN Then

                                    If IsNumeric(ltypLotRecpList(llngCnt).typRecipeBodyList(llngRecipeBpdyCnt).strRecipeValue) = True Then
                                        .SetData(llngRow, CMlngvsfRecpValue, _
                                            Format$(Val(ltypLotRecpList(llngCnt).typRecipeBodyList(llngRecipeBpdyCnt).strRecipeValue), _
                                            prvFormatValue_Set(ltypLotRecpList(llngCnt).typRecipeBodyList(llngRecipeBpdyCnt).strItemValidDigit)))    'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                    Else
                                        .SetData(llngRow, CMlngvsfRecpValue, _
                                                ltypLotRecpList(llngCnt).typRecipeBodyList(llngRecipeBpdyCnt).strRecipeValue)    'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                    End If
                                    '.GetData(llngRow, CMlngvsfRecpValue).TextAlign = TextAlignEnum.RightCenter               '右寄せ
                                    
                                     'CType(.Editor, Object).MaxLength = CMlngInputNDataMaxByte                                                 'MAX桁10
                                Else
                                    .SetData(llngRow, CMlngvsfRecpValue, _
                                            ltypLotRecpList(llngCnt).typRecipeBodyList(llngRecipeBpdyCnt).strRecipeValue)    'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                    '.GetData(llngRow, CMlngvsfRecpValue).TextAlign = TextAlignEnum.LeftCenter                '左寄せ
                                    
                                   'CType(.Editor, Object).MaxLength = CMlngInputADataMaxByte                                                 'MAX桁40
                                End If
        '@↑2006/08/18 (Fri) 10:01:02 N.Kojima **************************************************
                                
                                '@------------------------------------------
                                '@ﾊﾞｯｸｶﾗｰの設定
                                '@入力可否Fの判定を行う。(CMlngVariableFlg1:入力可)
                                '@------------------------------------------
                                If .GetData(llngRow, CMlngvsfRecpVariable) = CMlngVariableFlg Then
                                    '@ﾊﾞｯｸｶﾗｰ入力色(ﾋﾟﾝｸ)
                                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngInputColor")
                                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngRColor)
                                    Dim cellRange As CellRange = .GetCellRange(llngRow, CMlngvsfRecpValue)
                                    cellRange.Style = newStyle
                                Else
                                    '@ﾊﾞｯｸｶﾗｰ初期値(白)
                                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor) 
                                    Dim cellRange As CellRange = .GetCellRange(llngRow, CMlngvsfRecpValue)
                                    cellRange.Style = newStyle
                                End If
                            Next
                            
                            '@ｾﾙのﾏｰｼﾞ処理
                            .AllowMerging = AllowMergingEnum.Free                    'ｾﾙのﾏｰｼﾞ
                            .Cols(CMlngvsfRecpNo).AllowMerging = True                '№
                            .Cols(CMlngvsfRecpRecpID).AllowMerging = True            'ﾚｼﾋﾟID
                            .Cols(CMlngvsfRecpEdit).AllowMerging = True              '編集ﾌﾗｸﾞ
                            .Cols(CMlngvsfRecpComment).AllowMerging = True           'ﾚｼﾋﾟｺﾒﾝﾄ
                            .Cols(CMlngvsfRecpValue).AllowMerging = False            'ﾚﾁｸﾙ
                            .Cols(CMlngvsfRecpItem).AllowMerging = False             'ﾚｼﾋﾟｱｲﾃﾑ
                            .Cols(CMlngvsfRecpVariable).AllowMerging = False         '変更可否F
                            .Cols(CMlngvsfRecptype).AllowMerging = False             'ﾃﾞｰﾀﾀｲﾌﾟ
                            .Cols(CMlngvsfRecpDigit).AllowMerging = False            '小数点以下制御
                
                            '@列幅変更
                            '@ﾕｰｻﾞによる列幅変更されていない場合
                            If mtypChgSort.blnChgWidth = False Then
                                .AutoSizeCol(CMlngvsfRecpRecpID, 6)                  'ﾚｼﾋﾟID
                                .AutoSizeCol(CMlngvsfRecpComment, 6)                 'ﾚｼﾋﾟｺﾒﾝﾄ
                                .AutoSizeCol(CMlngvsfRecpValue, 6)                   'ﾚﾁｸﾙ
                                .AutoSizeCol(CMlngvsfRecpItem, 6)                    'ﾚｼﾋﾟｱｲﾃﾑ
                            End If
                        '@----------------------
                        '@枚葉ﾚｼﾋﾟの場合
                        '@----------------------
                        Case optRecp1.Checked 
                            '@現在のｽﾛｯﾄ№退避
                            lstrSlotNo = .GetData(.Row, CMlngvsfRecpNo)
                            '@現在のWFID退避
                            lstrWFID = .GetData(.Row, CMlngvsfRecpWFID)
                            '@↓2020/01/07 (Tue) 15:20:24 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            lstrGRB = .GetData(.Row, CMlngvsfRecpGRB)
                            '@↑2020/01/07 (Tue) 15:20:24 Y.Yoneyama 「.Netへ反映未」 **************************************************

                            '@初期化
                            llngSlotNoCnt = 0
                            Dim slotNoRow As Integer = 0
                            For llngRow = 1 To .Rows.Count - 1
                                '@現在のｽﾛｯﾄ№と同じ場合
                                If lstrSlotNo = .GetData(llngRow, CMlngvsfRecpNo) Then
                                    llngSlotNoCnt = llngSlotNoCnt + 1
                                End If
                                If slotNoRow = 0 AndAlso lstrSlotNo = .GetData(llngRow, CMlngvsfRecpNo) Then
                                    slotNoRow = llngRow
                                End If
                            Next
                            
                            .Redraw = False

                            '@現在のﾚﾁｸﾙ数と異なる場合
                            If llngSlotNoCnt <> ltypLotRecpList(llngCnt).lngRecipeBodyList Then
                                If llngSlotNoCnt > ltypLotRecpList(llngCnt).lngRecipeBodyList Then
                                    llngNum = llngSlotNoCnt - ltypLotRecpList(llngCnt).lngRecipeBodyList
                                    Do While llngNum > 0
                                        '@行数を設定(現在のﾚﾁｸﾙ数と異なる数だけ行を削除)
                                        .RemoveItem(slotNoRow + ltypLotRecpList(llngCnt).lngRecipeBodyList)
                                        llngNum = llngNum - 1
                                    Loop
                                Else
                                    llngNum = ltypLotRecpList(llngCnt).lngRecipeBodyList - llngSlotNoCnt
                                    Do While llngNum > 0
                                        '@行数を設定(現在のﾚﾁｸﾙ数と異なる数だけ行を追加)
                                        .AddItem(vbNullString, slotNoRow + ltypLotRecpList(llngCnt).lngRecipeBodyList - llngNum)
                                        llngNum = llngNum - 1
                                    Loop
                                End If
                            End If

                            '@ﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄ数分ﾙｰﾌﾟ
                            For llngRecipeBpdyCnt = 0 To ltypLotRecpList(llngCnt).lngRecipeBodyList - 1
                                llngRow = slotNoRow + llngRecipeBpdyCnt
                                .SetData(llngRow, CMlngvsfRecpNo, Format$(Integer.Parse(lstrSlotNo), CPstrSlotNoFormat))    '№
                                .SetData(llngRow, CMlngvsfRecpWFID, lstrWFID)                                               'WFID
                                '@↓2020/01/07 (Tue) 15:20:48 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                .SetData(llngRow, CMlngvsfRecpGRB, lstrGRB)                                                 'GRB
                                '@↑2020/01/07 (Tue) 15:20:48 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                .SetData(llngRow, CMlngvsfRecpRecpID, ltypLotRecpList(llngCnt).strRecipeId)                 'ﾚｼﾋﾟID設定

                                '@ﾚｼﾋﾟｺﾒﾝﾄ設定(改行ｺｰﾄﾞを半角ｽﾍﾟｰｽへ置換)
                                If ltypLotRecpList(llngCnt).strRecipeComment = vbNullString Then
                                    '@ﾏｰｼﾞ用にNULLの場合半角ｽﾍﾟｰｽをｾｯﾄする
                                    .SetData(llngRow, CMlngvsfRecpComment, CPstrSpace)
                                Else
                                    .SetData(llngRow, CMlngvsfRecpComment,
                                                Replace(ltypLotRecpList(llngCnt).strRecipeComment, vbCrLf, CPstrSpace))               'ﾚｼﾋﾟｺﾒﾝﾄ設定
                                End If

                                .SetData(llngRow, CMlngvsfRecpItem,
                                    ltypLotRecpList(llngCnt).typRecipeBodyList(llngRecipeBpdyCnt).strRecipeItem)                      'ﾚｼﾋﾟｱｲﾃﾑ
                                .SetData(llngRow, CMlngvsfRecpVariable,
                                    ltypLotRecpList(llngCnt).typRecipeBodyList(llngRecipeBpdyCnt).strVariableFlag)                    '変更可否F
                                .SetData(llngRow, CMlngvsfRecptype,
                                    ltypLotRecpList(llngCnt).typRecipeBodyList(llngRecipeBpdyCnt).strValueType)                       'ﾃﾞｰﾀﾀｲﾌﾟ
                                .SetData(llngRow, CMlngvsfRecpDigit,
                                    ltypLotRecpList(llngCnt).typRecipeBodyList(llngRecipeBpdyCnt).strItemValidDigit)                  '小数点以下制御

                                '@↓2006/08/18 (Fri) 10:02:22 N.Kojima **************************************************
                                '@文字ﾀｲﾌﾟの場合は、40byteまで入力可に変更(※元は30byte)

                                '@------------------------------------------
                                '@表示位置の設定
                                '@ﾃﾞｰﾀﾀｲﾌﾟの判定を行う。(CMstrDataTypeN:数値)
                                '@------------------------------------------
                                If ltypLotRecpList(llngCnt).typRecipeBodyList(llngRecipeBpdyCnt).strValueType = CMstrDataTypeN Then

                                    '@ｶﾝﾏ編集(0表示もOKとする)
                                    If IsNumeric(ltypLotRecpList(llngCnt).typRecipeBodyList(llngRecipeBpdyCnt).strRecipeValue) = True Then
                                        .SetData(llngRow, CMlngvsfRecpValue,
                                            Format$(Val(ltypLotRecpList(llngCnt).typRecipeBodyList(llngRecipeBpdyCnt).strRecipeValue),
                                                    prvFormatValue_Set(ltypLotRecpList(llngCnt).typRecipeBodyList(llngRecipeBpdyCnt).strItemValidDigit)))    'ﾚｼﾋﾟ値/ﾚﾁｸﾙ
                                    Else
                                        .SetData(llngRow, CMlngvsfRecpValue,
                                                ltypLotRecpList(llngCnt).typRecipeBodyList(llngRecipeBpdyCnt).strRecipeValue)    'ﾚｼﾋﾟ値
                                    End If
                                    '.GetData(llngRow, CMlngvsfRecpValue).TextAlign = TextAlignEnum.RightCenter   '右寄せ

                                    'CType(.Editor, Object).MaxLength = CMlngInputNDataMaxByte                                     'MAX桁10
                                Else
                                    .SetData(llngRow, CMlngvsfRecpValue,
                                            ltypLotRecpList(llngCnt).typRecipeBodyList(llngRecipeBpdyCnt).strRecipeValue)    'ﾚｼﾋﾟ値
                                    '.GetData(llngRow, CMlngvsfRecpValue).TextAlign = TextAlignEnum.LeftCenter                '左寄せ

                                    'CType(.Editor, Object).MaxLength = CMlngInputADataMaxByte                                                  'MAX桁40
                                End If
                                '@↑2006/08/18 (Fri) 10:02:22 N.Kojima **************************************************

                                '@------------------------------------------
                                '@ﾊﾞｯｸｶﾗｰの設定
                                '@入力可否Fの判定を行う。(CMlngVariableFlg1:入力可)
                                '@------------------------------------------
                                If .GetData(llngRow, CMlngvsfRecpVariable) = CMlngVariableFlg Then
                                    '@ﾊﾞｯｸｶﾗｰ入力色(ﾋﾟﾝｸ)
                                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngInputColor")
                                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngRColor)
                                    Dim cellRange As CellRange = .GetCellRange(llngRow, CMlngvsfRecpValue)
                                    cellRange.Style = newStyle
                                Else
                                    '@ﾊﾞｯｸｶﾗｰ初期値(白)
                                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                                    Dim cellRange As CellRange = .GetCellRange(llngRow, CMlngvsfRecpValue)
                                    cellRange.Style = newStyle
                                End If
                            Next

                            '@ｾﾙのﾏｰｼﾞ処理
                            .AllowMerging = AllowMergingEnum.RestrictAll             '行と列のﾏｰｼﾞ
                            .Cols(CMlngvsfRecpNo).AllowMerging = True                '№
                            .Cols(CMlngvsfRecpWFID).AllowMerging = True              'WFID
                            '@↓2020/01/07 (Tue) 15:21:17 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .Cols(CMlngvsfRecpGRB).AllowMerging = True               'GRB
                            '@↑2020/01/07 (Tue) 15:21:17 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            .Cols(CMlngvsfRecpRecpID).AllowMerging = True            'ﾚｼﾋﾟID
                            .Cols(CMlngvsfRecpEdit).AllowMerging = True              '編集ﾌﾗｸﾞ
                            .Cols(CMlngvsfRecpComment).AllowMerging = True           'ﾚｼﾋﾟｺﾒﾝﾄ
                            .Cols(CMlngvsfRecpValue).AllowMerging = False            'ﾚﾁｸﾙ
                            .Cols(CMlngvsfRecpItem).AllowMerging = False             'ﾚｼﾋﾟｱｲﾃﾑ
                            .Cols(CMlngvsfRecpVariable).AllowMerging = False         '変更可否F
                            .Cols(CMlngvsfRecptype).AllowMerging = False             'ﾃﾞｰﾀﾀｲﾌﾟ
                            .Cols(CMlngvsfRecpDigit).AllowMerging = False            '小数点以下制御
                
                            '@列幅変更
                            '@ﾕｰｻﾞによる列幅変更されていない場合
                            If mtypChgSort.blnChgWidth = False Then
                                .AutoSizeCol(CMlngvsfRecpWFID, 6)                   'WFID
                                '@↓2020/01/07 (Tue) 15:21:34 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                .AutoSizeCol(CMlngvsfRecpGRB, 6)                    'GRB
                                '@↑2020/01/07 (Tue) 15:21:34 Y.Yoneyama 「.Netへ反映未」 **************************************************
                                .AutoSizeCol(CMlngvsfRecpRecpID, 6)                 'ﾚｼﾋﾟID
                                .AutoSizeCol(CMlngvsfRecpComment, 6)                'ﾚｼﾋﾟｺﾒﾝﾄ
                                .AutoSizeCol(CMlngvsfRecpValue, 6)                  'ﾚﾁｸﾙ
                                .AutoSizeCol(CMlngvsfRecpItem, 6)                   'ﾚｼﾋﾟｱｲﾃﾑ
                            End If

                            .Redraw = True
                    End Select
                Else
                    '@--------------------------------
                    '@ﾚｼﾋﾟﾎﾞﾃﾞｨﾘｽﾄが0件の場合
                    '@--------------------------------
                    
                    '@ﾚｼﾋﾟｺﾒﾝﾄ設定
                    .SetData(.Row, CMlngvsfRecpComment, _
                            Replace(ltypLotRecpList(llngCnt).strRecipeComment, vbCrLf, CPstrSpace)) 'ﾚｼﾋﾟｺﾒﾝﾄ設定
                End If
                            
            End With

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvComboChang_Set"      '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvFormatValue_Set
    '機　能：ﾌｫｰﾏｯﾄ変換
    '引　数：lstrValue：小数点以下制御値
    '戻り値：ﾌｫｰﾏｯﾄ
    '作成日：2006/03/16 (Thu) 11:39:33 N.Kasai
    '更新日：2006/03/29 (Wed) 10:19:00 N.Kasai
    '備　考：
    '　　　：2006/03/29 (Wed) 10:19:00 N.Kasai  桁拡張
    Private Function prvFormatValue_Set(ByVal lstrValue As String) As String
        
        Try
            
            prvFormatValue_Set = vbNullString
                        
            '@小数点以下が設定済みの場合
            '@ﾌｫｰﾏｯﾄ設定
            Select Case lstrValue
                Case "1"
                    prvFormatValue_Set = CPstrDoubleFormat1String
                Case "2"
                    prvFormatValue_Set = CPstrDoubleFormat2String
                Case "3"
                    prvFormatValue_Set = CPstrDoubleFormat3String
                Case "4"
                    prvFormatValue_Set = CPstrDoubleFormat4String
                Case "5"
                    prvFormatValue_Set = CPstrDoubleFormat5String
                Case "6"
                    prvFormatValue_Set = CPstrDoubleFormat6String
                Case "7"
                    prvFormatValue_Set = CPstrDoubleFormat7String
                Case "8"
                    prvFormatValue_Set = CPstrDoubleFormat8String
                Case "9"
                    prvFormatValue_Set = CPstrDoubleFormat9String
                Case Else
                    '@ﾌｫﾄF/B以外の数値は標準ﾌｫｰﾏｯﾄ
                    prvFormatValue_Set = CPstrDateFormatKanma
            End Select
                       
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFormatValue_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function



    '***************************************************************************************
    '                              * NSYS 追加　関数 *
    '***************************************************************************************
    '======================================Private==========================================

    '関数名：Application_Idle
    '機　能：アイドル時に呼び出される
    '引　数：sender：未使用
    '　　　：e  ：未使用
    '戻り値：なし
    '作成日：2018/12/03 (Mon)
    '更新日：2018/12/03 (Mon)
    '備　考：
    Private Sub Application_Idle(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.buttonProcessing = False
    End Sub

    '関数名：WndProc
    '機　能：Windowsメッセージを処理する
    '引　数：m：Windowsメッセージ
    '戻り値：なし
    '作成日：2019/05/29 (Mon) 12:00:00 NSYS
    '更新日：
    '備　考：
    <SecurityPermission(SecurityAction.Demand, Flags:=SecurityPermissionFlag.UnmanagedCode)> _
    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_SYSCOMMAND         As Integer  = &H0112
        Const WM_CLOSE              As Integer  = &H0010
        Const WM_ENDSESSION         As Integer  = &H0016
        Const SC_MOVE               As Long     = &HF010L
        Const SC_CLOSE              As Long     = &HF060L
        Dim lblnSysCommandScClose   As Boolean  = False  'NSYS コントロールメニュー SC_CLOSE処理時 True
        Dim lblnWMClose             As Boolean  = False  'NSYS WM_CLOSE処理時 True

        
        Select Case m.Msg
            Case WM_ENDSESSION
                'OSのシャットダウンで閉じられようとしている場合
                mblnCloseFromControlMenu = True

            Case WM_SYSCOMMAND
                Select Case (m.WParam.ToInt64() And &HFFF0L)
                    Case SC_CLOSE
                        '[×]ボタン、コントロールメニューの「閉じる」、
                        'コントロールボックスのダブルクリック、
                        'Atl+F4などにより閉じられようとしている場合
                        mblnCloseFromControlMenu = True
                        lblnSysCommandScClose = True

                    Case SC_MOVE
                        'フォームの移動を無効化する
                        m.Result = IntPtr.Zero
                        Return
                End Select

            Case WM_CLOSE
                'Application.Exit以外で閉じられようとしている場合
                mblnWindowClose = True
                lblnWMClose = True

        End Select

        MyBase.WndProc(m)

        If lblnSysCommandScClose = True Then
            'NSYS SC_CLOSE 処理後 WM_CLOSE が発生しないでキャンセルされることもあるため、フラグを戻す
            'NSYS WM_CLOSE が発生していれば、すでにこの時点では画面は閉じている
            mblnCloseFromControlMenu = False
        End If
        If lblnWMClose = True Then
            'NSYS WM_CLOSE 処理後 終了がキャンセルされることもあるため、フラグを戻す
            'NSYS 終了処理されれば、すでにこの時点では画面は閉じている
            mblnWindowClose = False
        End If
    End Sub


    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraRecp.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub


    '関数名 list_BeforeDoubleClick
    '機　能：グリッドダブルクリック前処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/01/14 (Mon) 17:00:00 NSYS
    '備　考：
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfRecp.BeforeDoubleClick, vsfWP.BeforeDoubleClick

        ' ObjectをGridに変換
        Dim gridObj As C1FlexGrid
        gridObj = CType(sender, C1FlexGrid)

        Dim colindex As Integer 'ダブルクリックした列番号

        'ダブルクリックした箇所が列の境界線かを判断する
        If gridObj.HitTest(e.X,e.Y).Type = HitTestTypeEnum.ColumnResize Then

            '列の境界線の場合、本来の処理をキャンセル
            e.Cancel = True

            'ダブルクリックした列番号を格納
            colindex = gridObj.HitTest(e.X,e.Y).Column

            'サイズを自動調整
            gridObj.AutoSizeCol(colindex,6)
         ElseIf gridObj.HitTest(e.X,e.Y).Type = HitTestTypeEnum.Cell Then
            '本来の処理をキャンセル
            e.Cancel = True
        End If

    End Sub


    '関数名：flexGrid_KeyDownEdit
    '機　能：←→キーの取り扱い
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/01/28 (Mon) 10:00:00 NSYS
    '更新日：2019/04/05 (Fri) 12:00:00 NSYS
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfRecp.KeyDownEdit, vsfWP.KeyDownEdit

        With CType(sender, C1FlexGrid)
            '@'ｶﾚﾝﾄｾﾙがﾍｯﾀﾞｰ行でない場合
            If e.Row >= .Rows.Fixed Then
                Select Case e.KeyCode
                    Case Keys.Left  '[←]ｷｰ押下
                        Dim editor As Object = CType(.Editor, Object)
                        ' 編集不可のコンボボックスの場合
                        ' または、
                        ' テキストボックスまたは編集可のコンボボックスで、かつ、カーソルが先頭の場合は、
                        '   左隣へ
                        If (TypeOf editor Is ComboBox AndAlso _
                                    CType(editor, ComboBox).DropDownStyle = ComboBoxStyle.DropDownList) _
                            OrElse _
                            ((TypeOf editor Is TextBox OrElse TypeOf editor Is ComboBox) AndAlso _
                                (editor.SelectionStart = 0 AndAlso editor.SelectionLength = 0)) Then
                            If .FinishEditing() = True Then
                                ' 左側で固定行直前まで移動可能なセルを探す
                                For lintCnt As Integer = .Col - 1 To .Cols.Fixed Step -1
                                    If .Cols(lintCnt).Visible Then
                                        .Col = lintCnt
                                        Exit For
                                    End If
                                Next lintCnt
                            End If
                            e.Handled = True
                        End If
                    Case Keys.Right '[→]ｷｰ押下
                        Dim editor As Object = CType(.Editor, Object)
                        ' 編集不可のコンボボックスの場合
                        ' または、
                        ' テキストボックスまたは編集可のコンボボックスで、かつ、カーソルが末尾の場合は、
                        '   右隣へ
                        If (TypeOf editor Is ComboBox AndAlso _
                                CType(editor, ComboBox).DropDownStyle = ComboBoxStyle.DropDownList) _
                            OrElse _
                            ((TypeOf editor Is TextBox OrElse TypeOf editor Is ComboBox) AndAlso _
                                (editor.SelectionStart = editor.Text.Length)) Then
                            If .FinishEditing() = True Then
                                ' 右側でグリッドの最後まで移動可能なセルを探す
                                For lintCnt As Integer = .Col + 1 To .Cols.Count - 1 Step 1
                                    If .Cols(lintCnt).Visible Then
                                        .Col = lintCnt
                                        Exit For
                                    End If
                                Next lintCnt
                            End If
                            e.Handled = True
                        End If
                End Select
            End If
        End With

    End Sub

    '関数名：flex_SetupEditor
    '機　能：グリッド内コンボボックス表示行数調整
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/11/14 (Thu) 12:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub flex_SetupEditor(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfRecp.SetupEditor, vsfWP.SetupEditor

        Try
            If TypeOf sender.Editor Is ComboBox Then
                '行の高さを変更
                Dim editor As ComboBox = CType(sender.Editor, ComboBox)
                'editor.DrawMode = DrawMode.OwnerDrawFixed
                editor.DropDownHeight = 106
                editor.MaxDropDownItems = 12

            End If

        Catch ex As Exception
            '異常終了した場合は何もしない

        End Try

    End Sub

    Private Sub vsfRecp_SetupEditor(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfRecp.SetupEditor

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfRecp.Rows.Count <= vsfRecp.Rows.Fixed Then
                Return
            End If

            '@ﾃﾞｰﾀ行ではない場合
            If e.Row < vsfRecp.Rows.Fixed Then
                Exit Sub
            End If

            With vsfRecp
                '@行判定
                Select Case e.Col
                    '@ﾚｼﾋﾟ値列の場合
                    Case CMlngvsfRecpValue

                        '@↓2006/08/18 (Fri) 09:53:05 N.Kojima **************************************************
                        '@文字ﾀｲﾌﾟの場合は、40byteまで入力可に変更(※元は30byte)

                        '@ﾃﾞｰﾀﾀｲﾌﾟの判定（数値の場合）
                        If .GetData(.Row, CMlngvsfRecptype) = CMstrDataTypeN Then
                            '@10ﾊﾞｲﾄ迄入力可能(MAXｶﾗﾑ：当面ｸﾗｲｱﾝﾄでの入力ﾀｲﾌﾟ制限は数字、英数のみ）
                            CType(.Editor, TextBox).MaxLength = CMlngInputNDataMaxByte

                        Else
                            '@40ﾊﾞｲﾄ迄入力可能(MAXｶﾗﾑ：当面ｸﾗｲｱﾝﾄでの入力ﾀｲﾌﾟ制限は数字、英数のみ）
                            CType(.Editor, TextBox).MaxLength = CMlngInputADataMaxByte

                        End If
        '@↑2006/08/18 (Fri) 09:53:05 N.Kojima **************************************************
                    Case CMlngvsfRecpRecpID
                        Dim editor As ComboBox = CType(.Editor, ComboBox)
                        If Not editor Is Nothing Then
                            .Rows.DefaultSize = CMvsfRecpComboHeight
                        End If
                End Select
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "vsfRecp_SetupEditor"    '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cursor_Enter	
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。	
    '作成日：2019/07/02 NSYS	
    '更新日：	
    '備　考：Handlesは画面で入力できるすべての項目が対象	
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles txtCarrier.Enter,vsfWP.Enter, cmdUp.Enter, cmdDown.Enter, _
        vsfRecp.Enter, cmdVsfUp.Enter, cmdVsfDown.Enter, cmdLeft.Enter, cmdRight.Enter, cmdClose.Enter, cmdKakutei.Enter, cmdCancel.Enter

        '選択されている項目の名前で判定	
        Select sender.Name
            '閉じるボタンの場合は自動Validate = OFF	
            Case "cmdClose"
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
                '上記以外は自動Validate = ON	
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        End Select
    End Sub 

    Private Sub vsfRecp_StartEdit(sender As Object, e As RowColEventArgs) Handles vsfRecp.StartEdit
        Try
            With vsfRecp
                '@行判定
                Select Case e.Col
                    Case CMlngvsfRecpRecpID
                        If .AllowEditing Then
                            .Rows.DefaultSize = CMvsfRecpComboHeight
                        End If
                End Select
            End With
        Catch ex As Exception
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey      '機能ID
                .strProcName = "vsfRecp_StartEdit"   '処理名
                .strErrMessage = vbNullString        'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

End Class
