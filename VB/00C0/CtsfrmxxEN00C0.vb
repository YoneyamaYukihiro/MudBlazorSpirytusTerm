'ﾌｧｲﾙ名：xxEN00C0.frm
'説　明：運用モード変更/装置状態変更
'作成日：2004/06/18 (Fri) 16:48:44 S.Deguchi
'更新日：2025/04/18 (Fri) 16:34:52 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2025, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00C0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00C0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00C0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00C0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00C0)
            Dim old_inst As Form
            old_inst = _instance
            _instance = value
            If old_inst IsNot Nothing AndAlso Not old_inst.IsDisposed Then
                old_inst.Close()
                old_inst.Dispose()
            End If
        End Set
    End Property

    '****************************************************************************************
    '                                      *定数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2025/04/18 (Fri) 16:34:52 T.Oide **************************************************
    'Private Const CMstrLocalVersion                     As String = "17.03"
    Private Const CMstrLocalVersion                     As String = "17.04"
    '@↑2025/04/18 (Fri) 16:34:52 T.Oide **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN00C0          'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstreq__chgmode_Ver                  As String = "06.00"                 '運用ﾓｰﾄﾞ/装置状態変更要求
    Private Const CMstreq__emgchgmodeVer                As String = "04.00"                 '運用ﾓｰﾄﾞ強制変更要求
    Private Const CMstreq__state___Ver                  As String = "03.00"                 '装置状態取得
    Private Const CMstreq__areacurlistVer               As String = "02.00"                 'ｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置状態情報取得
    '@↓2012/04/23 (Mon) 12:44:17 Y.Yoneyama **************************************************
    'Private Const CMstrutilregtminfoVer                 As String = "05.00"                 '端末設定情報登録
    Private Const CMstrutilregtminfoVer                 As String = "06.00"                 '端末設定情報登録
    'Private Const CMstrutilreftminfoVer                 As String = "03.00"                 '端末設定情報取得
    Private Const CMstrutilreftminfoVer                 As String = "04.00"                 '端末設定情報取得
    '@↑2012/04/23 (Mon) 12:44:17 Y.Yoneyama **************************************************
    Private Const CMstrmas_McGrouplistVer               As String = "01.00"                 '装置ｸﾞﾙｰﾌﾟ取得
    Private Const CMstrmas_wpuselistVer                 As String = "03.00"                 '装置状態ﾏｽﾀ取得
    Private Const CMstreq__chguse__Ver                  As String = "05.00"                 '装置状態変更
    Private Const CMstreq__wpmsglistVer                 As String = "01.00"                 '装置状態ﾒｯｾｰｼﾞ取得
    Private Const CMstreq__chgtrnstatVer                As String = "01.00"                 '搬送ﾎﾟｰﾄ有効・無効変更要求
    Private Const CMstreq__chgprocorderVer              As String = "03.00"                 '装置処理順変更要求
    Private Const CMstrmas_wpprocessingnamelistVer      As String = "01.00"                 '装置処理部用途取得
    Private Const CMstrmas_chamberuselistVer            As String = "01.00"                 '装置処理部状態取得
    Private Const CMstreq__wpprocessinguseVer           As String = "01.00"                 '装置処理部用途ﾘｽﾄ取得
    Private Const CMstreq__chgwpprocessinguseVer        As String = "01.00"                 '装置処理部用途変更
    Private Const CMstreq__carunloadVer                 As String = "01.00"                 'ｷｬﾘｱ強制搬出要求
    Private Const CMstrrep_chgrepairreportVer           As String = "03.00"                 '故障修理記録票登録/更新
    Private Const CMstrpre_chgpreservereportVer         As String = "01.00"                 '保全記録票登録/更新

    '@vsfPortNoListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfLColNo                        As Integer = 0                      'Port№/№
    Private Const CMlngvsfLColUsage                     As Integer = 1                      '用途(ﾎﾟｰﾄ)
    Private Const CMlngvsfLColStatus                    As Integer = 2                      '状態
    Private Const CMlngvsfLColCarrierID                 As Integer = 3                      'ｷｬﾘｱID
    Private Const CMlngvsfLColTransCarrierID            As Integer = 4                      '搬送予定ｷｬﾘｱID
    Private Const CMlngvsfLColLotID                     As Integer = 5                      'ﾛｯﾄID
    Private Const CMlngvsfLColTransService              As Integer = 6                      '自動搬送ｻｰﾋﾞｽ(ｺﾝﾎﾞ)
    Private Const CMlngvsfLColStatusID                  As Integer = 7                      '状態ID
    Private Const CMlngvsfLColTransServiceID            As Integer = 8                      '自動搬送ｻｰﾋﾞｽID(変更前)
    Private Const CMlngvsfLColCarrierUnload             As Integer = 9                      'ｷｬﾘｱ強制搬出

    '@vsfPortNoListの定数宣言(幅)
    Private Const CMlngvsfLColWPortNo                   As Integer = 64                     'Port№
    Private Const CMlngvsfLColWUsage                    As Integer = 83                     '用途
    Private Const CMlngvsfLColWStatusP                  As Integer = 77                     '状態
    Private Const CMlngvsfLColWCarrierID                As Integer = 120                    'ｷｬﾘｱID
    Private Const CMlngvsfLColWTransCarrierID           As Integer = 120                    '搬送予定ｷｬﾘｱID
    Private Const CMlngvsfLColWLotID                    As Integer = 116                    'ﾛｯﾄID
    Private Const CMlngvsfLColWTransService             As Integer = 73                     '自動搬送ｻｰﾋﾞｽ
    Private Const CMlngvsfLColWStatusID                 As Integer = 88                     '状態ID
    Private Const CMlngvsfLColWTransServiceID           As Integer = 88                     '自動搬送ｻｰﾋﾞｽID
    Private Const CMlngvsfLColWCarrierUnload            As Integer = 76                     'ｷｬﾘｱ強制搬出

    '@vsfPortNoListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfLColPortNo                    As String = "ポート"                'Port№
    Private Const CMstrvsfLColUsage                     As String = "用途"                  '用途
    Private Const CMstrvsfLColStatus                    As String = "状態"                  '状態
    Private Const CMstrvsfLColCarrierID                 As String = "搭載キャリア"          'ｷｬﾘｱID
    Private Const CMstrvsfLColTransCarrierID            As String = "搬送キャリア"          '搬送予定ｷｬﾘｱID
    Private Const CMstrvsfLColLotID                     As String = "ロット"                'ﾛｯﾄID
    Private Const CMstrvsfLColTransService              As String = "搬送"                  '自動搬送ｻｰﾋﾞｽ
    Private Const CMstrvsfLColStatusID                  As String = "状態ID"                '状態ID
    Private Const CMstrvsfLColTransServiceID            As String = "搬送ID"                '自動搬送ｻｰﾋﾞｽID
    Private Const CMstrvsfLColCarrierUnload             As String = "払出"                  'ｷｬﾘｱ強制搬出

    '@vsfChamberListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfCColNo                        As Integer = 0                      '№
    Private Const CMlngvsfCColProcessingName            As Integer = 1                      '処理部用途
    Private Const CMlngvsfCColUseName                   As Integer = 2                      '状態
    Private Const CMlngvsfCColChamberID                 As Integer = 3                      '用途ID(非表示)
    Private Const CMlngvsfCColOldChamberID              As Integer = 4                      '変更前用途ID(非表示)
    Private Const CMlngvsfCColOldProcessingName         As Integer = 5                      '変更前処理部用途(非表示)
    Private Const CMlngvsfCColOldUseID                  As Integer = 6                      '変更前状態ID(非表示)
    Private Const CMlngvsfCColEditTime                  As Integer = 7                      '更新日時(非表示)

    '@vsfChamberListの定数宣言(幅)
    Private Const CMlngvsfCColWNo                       As Integer = 49                     '№
    Private Const CMlngvsfCColWProcessingName           As Integer = 304                    '処理部用途
    Private Const CMlngvsfCColWUseName                  As Integer = 142                    '状態
    Private Const CMlngvsfCColWChamberID                As Integer = 33                     '用途ID
    Private Const CMlngvsfCColWOldChamberID             As Integer = 33                     '変更前用途ID(非表示)
    Private Const CMlngvsfCColWOldProcessingName        As Integer = 33                     '変更前処理部用途(非表示)
    Private Const CMlngvsfCColWOldUseID                 As Integer = 33                     '変更前状態ID(非表示)
    Private Const CMlngvsfCColWEditTime                 As Integer = 33                     '更新日時(非表示)

    '@vsfChamberListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfCColNo                        As String = "№"
    Private Const CMstrvsfCColProcessingName            As String = "処理部用途"
    Private Const CMstrvsfCColUseName                   As String = "状態"
    Private Const CMstrvsfCColChamberID                 As String = "用途ID"
    Private Const CMstrvsfCColOldChamberID              As String = "変更前用途ID"
    Private Const CMstrvsfCColOldProcessingName         As String = "変更前処理部用途"
    Private Const CMstrvsfCColOldUseID                  As String = "変更前状態ID"
    Private Const CMstrvsfCColEditTime                  As String = "更新日時"

    '@vsfModeListの定数宣言
    Private Const CMlngvsfColMode                       As Integer = 0                      '運用
    Private Const CMlngvsfColMesMode                    As Integer = 0                      '変更後運用ﾓｰﾄﾞ

    '@vsf共通の定数宣言
    Private Const CMlngVsfRowTitle                      As Integer = 0                      'ﾀｲﾄﾙ行(行)
    Private Const CMlngVsfColTitle                      As Integer = 0                      'ﾀｲﾄﾙ行(列)
    Private Const CMlngvsfFontSize                      As Integer = 14                     'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHFontSize                     As Integer = 12                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                       As Integer = 27                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngVsfHeight                        As Integer = 38                     '1ｽﾛｯﾄの高さ

    '@装置状態の定数宣言
    Private Const CMstrvsfStatusFuka                    As String = "0"                     '状態：不可(OutOfService)
    Private Const CMstrvsfStatusTohsai                  As String = "1"                     '状態：搭載(TrnsferBlock)
    Private Const CMstrvsfStatusAki                     As String = "2"                     '状態：搬入(ReadyToLoad)
    Private Const CMstrvsfStatusDeru                    As String = "3"                     '状態：搬出(ReadyToUnload)
    Private Const CMstrNow                              As String = " 現在"                 '現在日時表示文字列
    Private Const CMstrProduct                          As String = "PRODUCT"               'ﾓｰﾄﾞ変更可能判別用定数

    '@稼動状態の表示
    Private Const CMstrWpStopFlag0                      As String = "0"
    Private Const CMstrWpStopFlag1                      As String = "1"
    Private Const CMstrWpMoveNomal                      As String = "通常"
    Private Const CMstrWpMoveStop                       As String = "停止中"
    Private Const CMstrWpMoveFlow                       As String = "稼動中"
    Private Const CMstrWpMove                           As String = "移行中"

    '@運用ﾓｰﾄﾞの定数宣言
    Private Const CMstrModeM1                           As String = "M1"                    '運用ﾓｰﾄﾞ：M1
    Private Const CMstrModeM2                           As String = "M2"                    '運用ﾓｰﾄﾞ：M2
    Private Const CMstrModeS1                           As String = "S1"                    '運用ﾓｰﾄﾞ：S1
    Private Const CMstrModeS2                           As String = "S2"                    '運用ﾓｰﾄﾞ：S2
    Private Const CMstrModeF                            As String = "F"                     '運用ﾓｰﾄﾞ：F

    '@運用状態の定数宣言
    Private Const CMstrNormal                           As String = "正常"                  '運用状態：正常
    Private Const CMstrAbnormal                         As String = "異常"                  '運用状態：異常
    Private Const CMstrReserve                          As String = "予約"                  '運用状態：予約

    '@自動搬送ｻｰﾋﾞｽ状態(TRANS_SERVICE_STATUS)
    '@和名はﾏｽﾀ(STATUS)にある。和名に変更はないとのことで
    '@直書きとする。(大滝氏、柏木氏確認済み2005/12/21)
    Private Const CMstrTransServiceStatus               As String = "#0;可能|#1;不可能"     '自動搬送ｻｰﾋﾞｽ状態ｺﾝﾎﾞ内容
    Private Const CMstrTransServiceStatusOK             As String = "0"                     '自動搬送ｻｰﾋﾞｽ状態(可能)
    Private Const CMstrTransServiceStatusNG             As String = "1"                     '自動搬送ｻｰﾋﾞｽ状態(不可能)
    Private Const CMlngBackColorSBlue                   As Integer = &HFFFFC0               '水色(編集色)
    Private Const CMstrFromNgToOk                       As String = "：不可能→可能"        '成功ﾒｯｾｰｼﾞ
    Private Const CMstrFromOkToNg                       As String = "：可能→不可能"        '成功ﾒｯｾｰｼﾞ
    Private Const CMstrPortNo                           As String = "ポート№"              '成功ﾒｯｾｰｼﾞ
    Private Const CMstrWpName                           As String = "装置"                  '成功ﾒｯｾｰｼﾞ

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                      As Single = 15.75                   'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Single = 15.75                   'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbRowHeight                     As Integer = 43                     'ﾘｽﾄ行の高さ
    Private Const CMlngCmbDispCols1                     As Integer = 1                      'ｸﾞﾘｯﾄﾞ表示列数=1
    Private Const CMlngCmbValueCol1                     As Integer = 1                      '値取得個数=1
    Private Const CMlngCmbValueCol2                     As Integer = 2                      'ID列番2(非表示項目：運用ﾓｰﾄﾞ)
    Private Const CMlngCmbValueCol3                     As Integer = 3                      'ID列番3(非表示項目：停止ﾌﾗｸﾞ)
    Private Const CMlngCmbGridCol0                      As Integer = 0                      '名称列番=0
    Private Const CMlngCmbGroupCols                     As Integer = 1                      '列方向ｸﾞﾙｰﾌﾟ数
    Private Const CMlngCmbNotSelectMode                 As Integer = 0                      '選択ﾓｰﾄﾞ(単数選択ﾓｰﾄﾞ=0)
    Private Const CMlngCMbSelectMode                    As Integer = 1                      '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
    Private Const CMstrCmbAddedComment                  As String = " 項目選択"              '表示 文字列
    Private Const CMstrCmbAddedCommentNone              As String = "0 項目選択"             '表示 文字列「選択なし」
    Private Const CMstrCmbCheckOn                       As String = "1"                     'ﾁｪｯｸON
    Private Const CMstrCmbCheckOff                      As String = "0"                     'ﾁｪｯｸOFF

    '@装置状態ﾁｪｯｸﾌﾗｸﾞ
    Private Const CMlngChkModeFlg0                      As Integer = 0                      '装置情報取得時ﾁｪｯｸ
    Private Const CMlngChkModeFlg1                      As Integer = 1                      '運用ﾓｰﾄﾞ変更確定時ﾁｪｯｸ

    '@処理区分
    Private Const CMstrClassDivision0                   As String = "0"                     '変更要求
    Private Const CMstrClassDivision1                   As String = "1"                     '変更予約

    '@装置条件毎連続ﾀｲﾌﾟﾌﾗｸﾞの定数宣言
    Private Const CMstrWpCollectTypeFlag0               As String = "0"                     '指定不可装置        FIFO(到着順)
    Private Const CMstrWpCollectTypeFlag1               As String = "1"                     '条件毎指定可能装置  ﾚｼﾋﾟ(切替)
    Private Const CMstrWpCollectTypeFlag2               As String = "2"                     'ﾚｼﾋﾟｸﾞﾙｰﾌﾟ指定装置 ﾚｼﾋﾟ(固定)
    Private Const CMstrWpCollectTypeFlag3               As String = "3"                     'FIFO(到着順)限定
    Private Const CMstrWpCollectTypeFlag4               As String = "4"                     'ﾚｼﾋﾟ(切替)限定
    Private Const CMstrWpCollectTypeFlag5               As String = "5"                     'ﾚｼﾋﾟ(固定)限定

    '@変更後の処理順指定のFIFO指定の処理ﾛｯﾄ数宣言
    Private Const CMlngRecipeFlowNumFifo                As Integer = 0                      'ｾﾞﾛﾛｯﾄ数(FIFO)

    '@装置ｷｬﾝｾﾙｷｬﾘｱﾌﾗｸﾞの定数宣言
    Private Const CMstrWpCancelCarrierFlag0             As String = "0"                     '不可
    Private Const CMstrWpCancelCarrierFlag1             As String = "1"                     '可能
    Private Const CMstrWpCancelCarrierFlag2             As String = "2"                     '未確認(不可)

    '@変更後の処理順指定の表示ﾒｯｾｰｼﾞ用宣言
    Private Const CMstrMsgRightDirection                As String = " → "
    Private Const CMstrMsgColon                         As String = "："                    'ｺﾛﾝ
    Private Const CMstrMsgLotName                       As String = "ロット"                '処理数ﾛｯﾄ数
    Private Const CMstrMsgRecipeGroupName               As String = "レシピグループ"         'ﾚｼﾋﾟｸﾞﾙｰﾌﾟ
    '@↓2015/11/27 (Fri) 16:14:30 H.Hayashi **************************************************
    '@Private Const CMstrMsgMaxSelectRecipeGroupNum       As String = "30"                    'ﾚｼﾋﾟｸﾞﾙｰﾌﾟの最大選択数
    Private Const CMstrMsgMaxSelectRecipeGroupNum       As String = "40"                    'ﾚｼﾋﾟｸﾞﾙｰﾌﾟの最大選択数
    '@↑2015/11/27 (Fri) 16:14:30 H.Hayashi **************************************************

    '@ﾃｷｽﾄ
    Private Const CMlngMaxDispMemoRow                   As Integer = 3                      'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(作業ﾒﾓ)

    '@装置状態通常ﾌﾗｸﾞ(0:通常以外、1:通常)
    Private Const CMstrNormalStateFlag                  As String = "1"                     '装置状態通常ﾌﾗｸﾞ(通常)

    '@ｶﾗｰ(専属装置以外は青、それ以外は赤)
    Private Const CMlngRedColor                         As Integer = &HFF                   '赤色

    '@故障修理記録票,保全記録票登録/更新表示ﾒｯｾｰｼﾞ
    Private Const CMstrInsertMsg                        As String = "登録"                  '登録成功MSG
    Private Const CMstrUpdateMsg                        As String = "更新"                  '更新成功MSG
    Private Const CMstrRepairTitle                      As String = "故障修理記録票"        '登録or更新成功MSG
    Private Const CMstrPreserveTitle                    As String = "保全記録票"            '登録or更新成功MSG

    '@ｲﾍﾞﾝﾄ名称
    Private Const CMstrFormName                         As String = "frmxxEN00C0"               '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                         As String = "Form_Load"                 'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmbMcGroupValidate               As String = "cmbMcGroup_Validate"       'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmbWpValidate                    As String = "cmbWp_Validate"            'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmdSearchClick                   As String = "cmdSearch_Click"           'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmbUseNameValidate               As String = "cmbUseName_Validate"       'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmdRegistClick                   As String = "cmdRegist_Click"           'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmdUseChangeClick                As String = "cmdUseChange_Click"        'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmdExecutionClick                As String = "cmdExecution_Click"        'ｲﾍﾞﾝﾄ名称
    Private Const CMstrPrvblnCheckPrc                   As String = "prvblnCheck_Proc"           'ｲﾍﾞﾝﾄ名称
    Private Const CMstrPrvcmdSearchUpd                  As String = "prvCmdSearch_Upd"          'ｲﾍﾞﾝﾄ名称
    Private Const CMstrPrvblnUseChangeInputCheck        As String = "prvblnInput_Chk"           'ｲﾍﾞﾝﾄ名称
    Private Const CMstrPrvblnWpMsgDisp                  As String = "prvblnWpMsg_Disp"          'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmdChangeTrnstClick              As String = "cmdChangeTrnst_Click"      'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmdChangeProcOrderClick          As String = "cmdChangeProcOrder_Click"  'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmdCarrierUnloadClick            As String = "cmdCarrierUnload_Click"    'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmdChangeChamberClick            As String = "cmdChangeChamber_Click"    'ｲﾍﾞﾝﾄ名称

    'NSYS VB6のvsfModeListのデータ行リソースデータ 4行7列 (Tab区切り)
    '   運用, モード説明,   装置,   ロット処理, 搬送, 差立, 端末操作
    Private Const CMstrvsfModeListData                  As String = _
        "M1	マニュアル１	Offline	手動	手動	手動	作業開始/終了,処理開始/終了" & vbCrLf & _
        "S1	セミオート１	Online-Remote	自動	手動	手動	作業開始/終了" & vbCrLf & _
        "S2	セミオート２	Online-Remote	自動	自動	手動	不要" & vbCrLf & _
        "F	フルオート	Online-Remote	自動	自動	自動	不要"                       'NSYS vsfModeListのデータ行のデータ

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟ変更ﾁｪｯｸ用構造体
    Private Structure CheckRecipeGroup
        Dim strCollectTypeName                          As String                           'ﾚｼﾋﾟｸﾞﾙｰﾌﾟ名
        Dim strCollectTypeNum                           As String                           'ﾚｼﾋﾟｸﾞﾙｰﾌﾟ番号(ID)
    End Structure
    Private mtypCheckRecipeGroup                        As List(Of CheckRecipeGroup)

    Private mlngSelectRecipeGroupCnt                    As Integer                          'ﾚｼﾋﾟｸﾞﾙｰﾌﾟ選択数格納用
    Private mstrSelectRecipeCnt                         As String                           'ﾚｼﾋﾟｸﾞﾙｰﾌﾟ選択数格納用(文字)
    Private mblnRecipeGroupEditCancelFlag               As Boolean                          'ﾚｼﾋﾟｸﾞﾙｰﾌﾟ編集ｷｬﾝｾﾙﾌﾗｸﾞ(True:編集しない、False:編集する)

    '@各種情報格納用ﾓｼﾞｭｰﾙ変数
    Private mstrMcGroupID                               As String                           '装置ｸﾞﾙｰﾌﾟID格納領域
    Private mstrWpID                                    As String                           '装置ID格納領域
    Private mstrUseName                                 As String                           '現在の装置状態格納
    Private mstrProcess                                 As IDictionary                      '処理部ID・名称格納

    '@通信情報格納用ﾓｼﾞｭｰﾙ変数/構造体
    Private mtypMcGroupList                             As McGroupList                      'ｴﾘｱﾘｽﾄ格納
    Private mtypWpList                                  As List(Of AreaEquipmentList)       '装置ﾘｽﾄ格納
    Private mlngWpListCnt                               As Integer                          '装置ﾘｽﾄ数
    Private mtypEqstate                                 As Eqstate                          '装置状態ﾘｽﾄ格納
    Private mtypUsechange                               As Usechange                        '装置状態変更要求格納構造体
    Private mtypUseList                                 As List(Of UseList)                 '装置状態格納用構造体
    Private mlngUseListCnt                              As Integer                          '装置状態件数
    Private mtypRepairInfoReq                           As RepairInfo                       '故障修理記録情報取得要求構造体
    Private mtypRepairInfoAns                           As RepairInfoAns                    '故障修理記録情報取得応答構造体
    Private mtypPreserveInfoReq                         As PreserveInfo                     '保全記録票情報取得要求構造体
    Private mtypPreserveInfoAns                         As PreserveInfoAns                  '保全記録票情報取得応答構造体

    '@各種判定用ﾓｼﾞｭｰﾙ変数
    Private mblnFormLoad1st                             As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞ初回ﾌﾗｸﾞ(Ture:初回、False:ﾌｫｰﾑﾛｰﾄﾞ済み)
    Private mblnHandWorkFlag                            As Boolean                          'ﾊﾝﾄﾞﾜｰｸﾌﾗｸﾞ(Ture:ﾊﾝﾄﾞﾜｰｸ、False:ﾊﾝﾄﾞﾜｰｸ以外)
    Private buttonProcessing                            As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                          'NSYS WindowCloseフラグ
    Private mblnVsfComboListKeyDownEdit                 As Boolean                          'NSYS コンボ編集中キー操作(True:キーで編集終了、False:それ以外)


    '****************************************************************************************
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
        pubVsfMouseWheelManager_Set(vsfPortNoList, cmdUP, cmdDown)
        pubVsfMouseWheelManager_Set(vsfChamberList, cmdChamberUP, cmdChamberDown)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                                *イベントハンドラの記述*
    '****************************************************************************************
    '========================================Private=========================================
    '関数名：Form_Load
    '機　能：[ﾌｫｰﾑ]　起動時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/21 (Mon) 09:27:50 S.Deguchi
    '更新日：2005/05/19 (Thu) 10:24:16 N.Kojima
    '備　考：
    '　　　：2004/09/28 (Tue) 13:46:51 N.Kasai      端末情報で取得した内容がﾏｽﾀにない場合の対応
    '　　　：2004/10/04 (Mon) 11:59:57 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2004/11/15 (Mon) 11:53:19 H.Wajima     運用ﾓｰﾄﾞﾘｽﾄの表示処理追加(不具合№211)
    '　　　：2004/12/16 (Thu) 10:03:55 S.Deguchi    装置状態ﾁｪｯｸ後にﾓｰﾄﾞ一覧を活性・非活性する処理を追加
    '　　　：2005/05/19 (Thu) 10:24:16 N.Kojima     SetFocus対応(Form_Loadではﾃﾞｰﾀ取得のみとする。ｲﾍﾞﾝﾄ名称の定数化。)
    Private Sub Form_Load()

        Dim lblnAns             As Boolean              '結果格納
        Dim ltypDisp            As UtilRefTmInfo        '端末設定情報格納
        Dim llngCnt             As Integer              'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@=======================
            '@ 機能ﾊﾞｰｼﾞｮﾝの判定
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN00C0, CMstrLocalVersion)

            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)

            '@=======================
            '@ ﾒｲﾝﾌｫｰﾑの初期化
            '@=======================
            Call prvFrmxxEN00C0_Init()

            '@=======================
            '@ ｺﾝﾋﾟｭｰﾀ名(META実行時はWBTのｸﾗｲｱﾝﾄ名)の設定
            '@=======================
            Call pubGetWbtComputerName()

            '@【端末設定情報取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnUtilRefTmInfo_Sel(pstrSBID, _
                                              CMstrutilreftminfoVer, _
                                              pstrComputerName, _
                                              ltypDisp)

            '@通信結果判定
            If lblnAns = True Then
                '@結果：正常の場合

                With ltypDisp

                    '@端末情報が取得出来たか
                    If .strMcGroupID <> vbNullString And .strWpID <> vbNullString Then

                        '@取得した値を変数に格納
                        mstrMcGroupID = .strMcGroupID
                        mstrWpID = .strWpID
                    End If
                End With
            End If

            '@【装置ｸﾞﾙｰﾌﾟ取得】ﾒｯｾｰｼﾞ送受信処理(処理区分：全件)
            lblnAns = pubblnMasMcGroupList_Sel(CMstrmas_McGrouplistVer, _
                                               CPstrCD02, _
                                               pstrSBID, _
                                               mtypMcGroupList)

            '@通信結果判定
            If lblnAns = True Then
                '@結果：正常の場合

                '@=======================
                '@ 装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ作成
                '@=======================
                Call prvcmbMcGroupList_Disp(mtypMcGroupList)
            Else
                '@結果：異常の場合

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                Exit Sub
            End If

            '@********************************************
            '@ 端末設定情報から取得した情報を表示する処理
            '@********************************************
            '@端末情報で取得した装置ｸﾞﾙｰﾌﾟIDと装置IDがNULL以外か
            If mstrMcGroupID <> vbNullString And mstrWpID <> vbNullString Then

                '@取得した装置ｸﾞﾙｰﾌﾟをｾｯﾄ
                For llngCnt = 0 To mtypMcGroupList.lngMcGroupListCnt - 1

                    '@端末情報で取得した装置ｸﾞﾙｰﾌﾟと装置ｸﾞﾙｰﾌﾟ取得で取得した装置ｸﾞﾙｰﾌﾟが一致しているか
                    If mtypMcGroupList.typMcGroupList(llngCnt).strMcGroupID = mstrMcGroupID Then

                        '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞにｾｯﾄ
                        cmbMcGroup.Text = mtypMcGroupList.typMcGroupList(llngCnt).strMcGroupName    '装置ｸﾞﾙｰﾌﾟ名
                    End If
                Next llngCnt

                '@装置ｸﾞﾙｰﾌﾟが表示されているか
                If cmbMcGroup.Text <> vbNullString Then

                    '@=======================
                    '@ 装置情報取得処理
                    '@=======================
                    lblnAns = prvblnWpID_Sel(mstrMcGroupID)

                    '@装置情報取得処理結果判定
                    If lblnAns = True Then
                        '@結果：正常の場合

                        '@=======================
                        '@ 装置ｺﾝﾎﾞ作成
                        '@=======================
                        Call prvcmbWp_Disp(mtypWpList, mlngWpListCnt)

                        '@取得した装置IDをｾｯﾄ
                        For llngCnt = 0 To mlngWpListCnt - 1

                            '@端末情報で取得した装置IDと装置情報取得で取得した装置IDが一致するか
                            If mtypWpList(llngCnt).strWpID = mstrWpID Then

                                '@装置ｺﾝﾎﾞにｾｯﾄ
                                cmbWp.Text = mtypWpList(llngCnt).strWpName        '装置ID
                            End If
                        Next llngCnt

                        '@装置が表示されているか
                        If cmbWp.Text = vbNullString Then

                            '@変数初期化
                            mstrWpID = vbNullString

                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)
                        Else

                            '@=======================
                            '@ 装置状態/処理状態情報の取得処理
                            '@=======================
                            lblnAns = prvblnPortLotList_Sel(mstrWpID)

                            '@装置状態/処理状態情報の取得処理結果判定
                            If lblnAns = False Then
                                '@結果：異常の場合

                                '@Escﾎﾞﾀﾝを有効
                                Me.CancelButton = cmdClose

                                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                                Exit Sub
                            End If

                            '@【装置状態ﾏｽﾀ取得】ﾒｯｾｰｼﾞ送受信処理
                            lblnAns = pubblnMasWpUseList_Sel(CMstrmas_wpuselistVer, _
                                                             mtypUseList, _
                                                             mlngUseListCnt)

                            '@通信結果判定
                            If lblnAns = False Then
                                '@結果：異常の場合

                                '@Escﾎﾞﾀﾝを有効
                                Me.CancelButton = cmdClose

                                '@=======================
                                '@ ﾒｲﾝﾌｫｰﾑの初期化
                                '@=======================
                                Call prvFrmxxEN00C0_Init()

                                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                                Exit Sub
                            Else
                                '@結果：正常の場合

                                '@Escﾎﾞﾀﾝを有効
                                Me.CancelButton = cmdClose

                                '@ﾚｽﾎﾟﾝｽ取得終了
                                Call publngResponseEnd(CMstrFormName, CMstrFormLoad)

                                '@=======================
                                '@ 変更後装置状態ｺﾝﾎﾞ作成
                                '@=======================
                                Call prvCmbUseName_Disp()

                                '@変更後装置状態ｺﾝﾎﾞを有効にする
                                cmbUseName.Enabled = True
                            End If

                            '@=======================
                            '@ 装置処理部用途状態一覧設定
                            '@=======================
                            lblnAns = prvblnChamber_Set()

                            '@装置処理部用途状態一覧設定処理結果判定
                            If lblnAns = False Then
                                '@結果：異常の場合

                                '@=======================
                                '@ ﾒｲﾝﾌｫｰﾑの初期化
                                '@=======================
                                Call prvFrmxxEN00C0_Init()

                                '@Escﾎﾞﾀﾝを有効
                                Me.CancelButton = cmdClose

                                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                                Exit Sub
                            End If
                        End If

                        '@最新取得ﾎﾞﾀﾝを有効にする
                        cmdSearch.Enabled = True
                    Else
                        '@結果：異常の場合

                        '@Escﾎﾞﾀﾝを有効
                        Me.CancelButton = cmdClose

                        '@装置が取得できない場合は装置ｸﾞﾙｰﾌﾟを未選択にする
                        cmbMcGroup.ListIndex = -1

                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                    End If
                Else
                    '@装置ｸﾞﾙｰﾌﾟが表示されていない場合

                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = cmdClose

                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrFormLoad)
                End If
            Else
                '@端末設定情報で取得した装置ｸﾞﾙｰﾌﾟIDと装置IDの何れかがNULLの場合

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrFormLoad)
            End If

            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True

            '@ﾌｫｰﾑﾛｰﾄﾞ初回ﾌﾗｸﾞ(True:初回、False:ﾌｫｰﾑﾛｰﾄﾞ済み)
            mblnFormLoad1st = True

            Exit Sub

        Catch ex As Exception

            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_Load"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_Activate
    '機　能：[ﾌｫｰﾑ]　ｱｸﾃｨﾌﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/19 (Thu) 10:31:10 N.Kojima
    '更新日：2008/02/04 (Mon) 09:18:37 N.Kojima
    '備　考：
    '　　　：2005/11/30 (Wed) 11:47:51 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2006/06/28 (Wed) 13:53:33 N.Kojima     ﾃﾞﾌｫﾙﾄ装置以外の装置の場合、ﾗﾍﾞﾙ&ｸﾞﾘｯﾄﾞﾀｲﾄﾙ行の色変え処理を追加。(ﾕｰｻﾞｰ要望№0192)
    '　　　：2006/10/17 (Tue) 15:51:57 M.Miura      画面のﾗﾍﾞﾙ背景色の(赤/青)ちらつき修正(案件№01570)
    '　　　：2007/02/28 (Wed) 10:12:52 N.Kojima     ﾓｰﾄﾞﾘｽﾄの使用不可処理を「prvblnPortLotList_Chk」内に移動。(案件№01792)
    '　　　：2007/10/17 (Wed) 20:49:19 N.Kojima     mblnFormLoad1stの初期化処理を移動。(案件№02152)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Dim lblnAns     As Boolean      '戻り値

        Try
            '@ﾌｫｰﾑﾛｰﾄﾞ初回ﾌﾗｸﾞ(Ture:初回、False:ﾌｫｰﾑﾛｰﾄﾞ済み)
            '@初回ﾛｰﾄﾞのみ最新ﾛｯﾄ一覧を取得する。
            If mblnFormLoad1st = True Then

                '@Form_Loadﾌﾗｸﾞが正常の場合
                If pblnFormLoad = True Then

                    '@ﾌｫｰﾑﾛｰﾄﾞ初回ﾌﾗｸﾞ(Ture:初回、False:ﾌｫｰﾑﾛｰﾄﾞ済み)
                    mblnFormLoad1st = False

                    '@=======================
                    '@ ﾃﾞﾌｫﾙﾄ装置以外(pstrTerminalFlag="1"orNULL)かにより、
                    '@ ﾗﾍﾞﾙ&ｸﾞﾘｯﾄﾞﾀｲﾄﾙ行の色を変える
                    '@=======================
                    Call prvColorChang_Proc()

                    '@制御をOSに渡す
                    '@ﾌｫｰﾑﾛｰﾄﾞ中の通信に負荷がかかった場合にﾌｫｰﾑに制御を渡す
                    '@ｲﾍﾞﾝﾄを抑止する為、ﾌｫｰﾑをﾛｯｸする。
                    Me.Refresh()

                    '@=======================
                    '@ ﾓｰﾄﾞ一覧表示設定処理
                    '@=======================
                    Call prvVsfModeList_Disp()

                    '@=======================
                    '@ 装置ﾎﾟｰﾄ状態ｸﾞﾘｯﾄﾞ作成
                    '@=======================
                    Call prvVsfPortNoList_Disp()

                    '@=======================
                    '@ 装置状態ﾁｪｯｸ処理
                    '@=======================
                    lblnAns = prvblnPortLotList_Chk(CMlngChkModeFlg0)

                    '@作業ﾒﾓを使用可能に
                    txtWorkMemo.Enabled = True

                    '@運用ﾓｰﾄﾞ変更ｸﾞﾘｯﾄﾞを使用可能状態にする
                    If vsfModeList.Enabled = False Then
                        vsfModeList.Enabled = True
                    End If

                    '@Escﾎﾞﾀﾝを有効
                    '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
                    Me.CancelButton = cmdClose

                    '@装置名が空白ではない場合
                    If cmbWp.Text <> vbNullString Then

                        '@ﾌｫｰｶｽｾｯﾄ
                        If vsfModeList.Enabled = True Then

                            '@ﾓｰﾄﾞﾘｽﾄにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(vsfModeList)
                        Else
                            '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdClose)
                        End If
                    Else
                        '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞが有効か
                        If cmbMcGroup.Enabled = True Then

                            '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmbMcGroup)
                        End If
                    End If

                    'NSYS Activate中にpublngMsgBox等で別ウィンドウを表示するとActivateがキャンセルされるため、再Activateする
                    'NSYS Activateイベント中にActivate()を呼び出しても作用しないため、遅延で実行する。ラムダ式使用
                    Dim lfuncActivate As Action = Sub()
                                                      Me.Activate()
                                                  End Sub
                    Me.BeginInvoke(lfuncActivate)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_Activate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：[ﾌｫｰﾑ]　ｷｰﾀﾞｳﾝ時処理
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/06/22 (Tue) 12:47:37 S.Deguchi
    '更新日：2007/10/15 (Mon) 12:03:23 N.Kojima
    '備　考：
    '　　　：2005/03/02 (Wed) 14:21:36 N.Kojima     変更後装置状態ｺﾝﾎﾞ追加に伴い、KeyDown処理追加(改善№524、525)
    '　　　：2005/05/19 (Thu) 11:43:54 N.Kojima     SetFocus対応(ﾏｳｽﾎﾟｲﾝﾀｰが砂時計、ﾌｫｰﾑﾛｯｸ中は処理を受け付けない)
    '　　　：2005/11/01 (Tue) 16:15:57 N.Kojima     CH使用禁止ｺﾝﾎﾞ追加に伴い、KeyDown処理追加(ﾕｰｻﾞｰ要望№0094)
    '　　　：2006/08/28 (Mon) 13:04:40 T.Kitagawa   ﾌｫﾄのTAT改善に伴う処理順指定追加(案件№01097)
    '　　　：2007/10/15 (Mon) 12:03:23 N.Kojima     ﾚｼﾋﾟｸﾞﾙｰﾌﾟｺﾝﾎﾞ追加に伴い処理追加。(案件№02152)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@以下の条件の場合は、ｷｰｺｰﾄﾞをｸﾘｱ(ｷｰﾎﾞｰﾄﾞ操作無効化)し処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合は処理を受付けない
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                e.Handled = True
                Exit Sub
            End If

            '@=======================
            '@ ｸﾞﾘｯﾄﾞｷｰ制御(ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、前頁ﾎﾞﾀﾝ、次頁ﾎﾞﾀﾝ)
            '@=======================
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfChamberList, cmdChamberUP, cmdChamberDown)

            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name

                '@〓 装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ 〓
                Case cmbMcGroup.Name

                    If e.KeyCode = Keys.Return Then

                        '@=======================
                        '@ 装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞValidate処理
                        '@=======================
                        Call cmbMcGroup_Validate(cmbMcGroup, New CancelEventArgs(True))
                        e.Handled = True
                    End If

                '@〓 装置名ｺﾝﾎﾞ 〓
                Case cmbWp.Name

                    If e.KeyCode = Keys.Return Then

                        '@=======================
                        '@ 装置ｺﾝﾎﾞValidate処理
                        '@=======================
                        Call cmbWp_Validate(cmbWp, New CancelEventArgs(True))
                        e.Handled = True
                    End If

                '@〓 運用ﾓｰﾄﾞ一覧ｸﾞﾘｯﾄﾞ 〓
                Case vsfModeList.Name

                    If e.KeyCode = Keys.Return Then

                        '@次項目へｾｯﾄﾌｫｰｶｽ
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                    End If

                '@〓 変更後装置状態ｺﾝﾎﾞ 〓
                Case cmbUseName.Name

                    If e.KeyCode = Keys.Return Then

                        '@=======================
                        '@ 変更後装置状態Validate処理
                        '@=======================
                        Call cmbUseName_Validate(cmbUseName, New CancelEventArgs(True))
                        e.Handled = True
                    End If

                '@ 〓変更後処理順指定ｺﾝﾎﾞ 〓
                Case cmbRecipeFlow.Name

                    If e.KeyCode = Keys.Return Then

                        '@=======================
                        '@ 変更後処理順変更Validate処理
                        '@=======================
                        Call cmbRecipeFlow_Validate(cmbRecipeFlow, New CancelEventArgs(True))
                        e.Handled = True
                    End If

                '@〓 ﾚｼﾋﾟｸﾞﾙｰﾌﾟｺﾝﾎﾞ 〓
                Case cmbRecipeGroup.Name

                    If e.KeyCode = Keys.Return Then

                        '@=======================
                        '@ ﾚｼﾋﾟｸﾞﾙｰﾌﾟｺﾝﾎﾞValidate処理
                        '@=======================
                        Call cmbRecipeGroup_Validate(cmbRecipeGroup, New CancelEventArgs(True))
                        e.Handled = True
                    End If

                '@〓 作業ﾒﾓﾃｷｽﾄ 〓
                Case txtWorkMemo.Name

                    '@Enterで改行する為、処理を行わない

                '@〓 その他 〓
                Case Else

                    If e.KeyCode = Keys.Return Then

                        '@次項目へｾｯﾄﾌｫｰｶｽ
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                    End If

            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：[ﾌｫｰﾑ]　終了時処理
    '引　数：Cancel     ：未使用
    '　　　：UnloadMode ：未使用
    '戻り値：なし
    '作成日：2004/06/21 (Mon) 09:27:03 S.Deguchi
    '更新日：2007/10/17 (Wed) 09:21:50 N.Kojima
    '備　考：
    '　　　：2004/11/01 (Mon) 15:49:45 N.Kasai      閉じるﾎﾞﾀﾝ統合
    '　　　：2005/05/19 (Thu) 11:41:41 N.Kojima     SetFocus対応(ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey無効)
    '　　　：2005/12/22 (Thu) 14:42:28 N.Kasai      構造体初期化追加
    '　　　：2006/06/28 (Wed) 15:44:58 N.Kojima     変数の初期化処理追加。(ﾕｰｻﾞｰ要望№0192)
    '　　　：2007/10/17 (Wed) 09:21:50 N.Kojima     ﾚｼﾋﾟｸﾞﾙｰﾌﾟ追加に伴い、処理追加。(案件№02152)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納
        Dim ltypEqstate     As Eqstate      '初期化用構造体

        Try

            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, EventArgs.Empty)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If

            '@構造体の解放
            mtypWpList = Nothing                        '装置ﾘｽﾄ格納用
            mtypMcGroupList.typMcGroupList = Nothing    '装置ｸﾞﾙｰﾌﾟ格納用
            mtypUseList = Nothing                       '装置状態格納用
            mtypCheckRecipeGroup = Nothing              '変更ﾁｪｯｸ用構造体
            mtypEqstate = ltypEqstate                   '装置情報構造体

            '@変数の初期化
            pstrTerminalFlag = vbNullString

            '@ActInitﾌﾗｸﾞの判定
            If pblnActInitFlg = True Then
                '@Actを自前で初期化した場合

                '@=======================
                '@ ACTｵﾌﾞｼﾞｪｸﾄの開放処理
                '@=======================
                lblnAnsTerm = pubblnAct_Term

                If lblnAnsTerm = True Then
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                End If
            Else
                '@=======================
                '@ ﾒｲﾝﾒﾆｭｰ画面を広げる処理
                '@=======================
                Call pubMenuExpand_Disp()
            End If

            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_QueryUnload"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGroup_Change
    '機　能：装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/22 (Tue) 09:36:11 S.Deguchi
    '更新日：2007/10/15 (Mon) 12:06:00 N.Kojima
    '備　考：
    '　　　：2004/11/16 (Tue) 09:45:08 H.Wajima     運用ﾓｰﾄﾞ一覧初期化処理追加
    '　　　：2005/02/24 (Thu) 16:16:01 N.Kojima　   稼動状態削除、現在の装置状態追加(改善№524、525)
    '　　　：2005/12/22 (Thu) 15:29:28 N.Kasai      装置状態変更ｺﾝﾎﾞ初期化追加
    '　　　：2006/06/28 (Wed) 18:55:40 N.Kojima     ﾃﾞﾌｫﾙﾄ装置以外の装置の場合、ﾗﾍﾞﾙ&ｸﾞﾘｯﾄﾞﾀｲﾄﾙ行の色変え処理を追加。(ﾕｰｻﾞｰ要望№0192)
    '　　　：2006/08/28 (Mon) 14:49:21 T.Kitagawa   ﾌｫﾄのTAT改善に伴う処理順指定追加(案件№01097)
    '　　　：2006/10/17 (Tue) 15:51:57 M.Miura      画面のﾗﾍﾞﾙ背景色の(赤/青)ちらつき修正(案件№01570)
    '　　　：2007/10/15 (Mon) 12:06:00 N.Kojima     ﾚｼﾋﾟｸﾞﾙｰﾌﾟｺﾝﾎﾞの追加に伴い処理追加。(案件№02152)
    Private Sub cmbMcGroup_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGroup.Change

        Try
            '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞの値取得列を"装置ｸﾞﾙｰﾌﾟID列"に指定
            cmbMcGroup.ValueCol = CMlngCmbValueCol1

            '@装置ｸﾞﾙｰﾌﾟIDが退避領域と異なるか
            If mstrMcGroupID <> cmbMcGroup.Value Then
                '@異なる場合

                '@装置名ｺﾝﾎﾞの初期化
                cmbWp.Clear

                '@=======================
                '@ 各ｸﾞﾘｯﾄﾞの初期化処理
                '@=======================
                Call prvVsfPortNoList_Init      '装置ﾎﾟｰﾄ状態一覧ｸﾞﾘｯﾄﾞ
                Call prvVsfModeList_Init        '運用ﾓｰﾄﾞ一覧ｸﾞﾘｯﾄﾞ
                Call prvVsfChamberList_Init     '装置処理部用途/状態一覧ｸﾞﾘｯﾄﾞ

                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化
                cmdSearch.Enabled = False       '最新取得ﾎﾞﾀﾝ
                cmdExecution.Enabled = False    '強制M1変更ﾎﾞﾀﾝ

                '@作業ﾒﾓの初期化
                txtWorkMemo.Text = vbNullString

                '@退避領域のｸﾘｱ
                mstrMcGroupID = vbNullString
                mstrWpID = vbNullString

                '@Labelの初期化
                lblM1AfterMode.Text = vbNullString                      '運用状態
                lblNowDate.Text = vbNullString                          '情報取得日時
                lblUseName.Text = vbNullString                          '現在の装置状態
                lblWpStatusName.Text = vbNullString                     '処理状態
                lblBeforeMode.Text = vbNullString                       '現在の運用ﾓｰﾄﾞ
                lblBeforeRecipeFlow.Text = vbNullString                 '現在の処理順指定
                lblBeforeRecipeFlowNum.Text = vbNullString              '現在の処理順ﾛｯﾄ数

                '@変更後処理順の初期化
                cmbRecipeFlow.ListIndex = -1
                cmbRecipeFlow.Text = vbNullString
                cmbRecipeFlow.BackColor = SystemColors.ControlLight     '灰色
                cmbRecipeFlow.Enabled = False                           '使用不可

                '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟの初期化
                '@編集ｷｬﾝｾﾙﾌﾗｸﾞをTrue:編集しない(cmbRecipeGroup_Change処理内で使用)
                mblnRecipeGroupEditCancelFlag = True

                cmbRecipeGroup.ListIndex = -1
                cmbRecipeGroup.Text = vbNullString                      'ﾃｷｽﾄ
                cmbRecipeGroup.BackColor = SystemColors.ControlLight    '灰色
                cmbRecipeGroup.Enabled = False                          '使用不可

                '@編集ｷｬﾝｾﾙﾌﾗｸﾞを戻す
                mblnRecipeGroupEditCancelFlag = False

                '@変更後処理ﾛｯﾄ数の初期化
                txtRecipeFlowNum.Text = vbNullString
                txtRecipeFlowNum.BackColor = SystemColors.ControlLight  '灰色
                txtRecipeFlowNum.Enabled = False                        '使用不可

                '@運用ﾓｰﾄﾞ一覧の非活性化(ﾀｲﾄﾙ選択)
                vsfModeList.Select(CMlngVsfRowTitle, CMlngVsfColTitle)
                vsfModeList.Enabled = False

                '@変更後装置状態ｺﾝﾎﾞの初期化
                cmbUseName.ListIndex = -1
                cmbUseName.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMcGroup_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGroup_CloseUp
    '機　能：[装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/22 (Tue) 09:36:14 S.Deguchi
    '更新日：2004/06/22 (Tue) 09:36:14
    '備　考：
    Private Sub cmbMcGroup_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGroup.CloseUp

        Try

            '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞが選択されているか
            If cmbMcGroup.Text <> vbNullString Then

                '@=======================
                '@ 装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞのValidate処理
                '@=======================
                Call cmbMcGroup_Validate(cmbMcGroup, New CancelEventArgs(True))

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMcGroup_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGroup_Validate
    '機　能：[装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ　Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/06/22 (Tue) 09:36:18 S.Deguchi
    '更新日：2006/04/27 (Thu) 11:39:18 N.Kojima
    '備　考：
    '　　　：2005/05/19 (Thu) 12:39:20 N.Kojima     SetFocus対応(OnErr処理追加、ｲﾍﾞﾝﾄ名定数化)
    '　　　：2006/04/27 (Thu) 11:39:18 N.Kojima     Form_Load中の「閉じる」ﾎﾞﾀﾝへのﾌｫｰｶｽｾｯﾄ処理を禁止。(不具合№3501)
    Private Sub cmbMcGroup_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbMcGroup.Validating

        Dim lblnAns     As Boolean      '結果格納
        
        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｴﾗｰ発生箇所の初期化
            ptypOnErrorInfo.strErrPositionDetail = vbNullString

            '@***********************
            '@ 装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞの状態ﾁｪｯｸ
            '@***********************
            With cmbMcGroup

                '@未選択か
                If .Text = vbNullString Then

                    '@Form_Load中は「cmdClose.Cancel=False」でEnabled=Falseなのでﾌｫｰｶｽはｾｯﾄしない
                    If pblnFormLoad <> False Then
                        '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call prvSetFocus(cmdClose, cmbMcGroup)
                    End If

                    Exit Sub
                Else
                    '@装置名ｺﾝﾎﾞを活性化
                    cmbWp.Enabled = True
                End If

                '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞのValueCol値を"装置ｸﾞﾙｰﾌﾟID"列に設定
                .ValueCol = CMlngCmbValueCol1

                '@装置ｸﾞﾙｰﾌﾟIDが退避領域と同じか
                If mstrMcGroupID = .Value Then

                    '@装置名ｺﾝﾎﾞが有効か
                    If cmbWp.Enabled = True Then
                        '@装置名にﾌｫｰｶｽｾｯﾄ
                        Call prvSetFocus(cmbWp, cmbMcGroup)
                    Else
                        '@閉じるにﾌｫｰｶｽｾｯﾄ
                        Call prvSetFocus(cmdClose, cmbMcGroup)
                    End If

                    Exit Sub
                End If

                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrCmbMcGroupValidate)

                '@=======================
                '@ 装置情報取得処理
                '@=======================
                lblnAns = prvblnWpID_Sel(.Value)

                '@処理結果判定
                If lblnAns = True Then
                    '@結果：正常の場合

                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrCmbMcGroupValidate)

                    '@=======================
                    '@ 装置名ｺﾝﾎﾞ作成処理
                    '@=======================
                    Call prvcmbWp_Disp(mtypWpList, mlngWpListCnt)

                    '@装置名ｺﾝﾎﾞが有効か
                    If cmbWp.Enabled = True Then

                        '@装置名ｺﾝﾎﾞが1件か
                        If mlngWpListCnt = 1 Then
                            '@ﾓｰﾄﾞﾘｽﾄにﾌｫｰｶｽｾｯﾄ
                            Call prvSetFocus(vsfModeList, cmbMcGroup)
                        Else
                            '@装置名にﾌｫｰｶｽｾｯﾄ
                            Call prvSetFocus(cmbWp, cmbMcGroup)
                        End If
                    Else
                        '@閉じるにﾌｫｰｶｽｾｯﾄ
                        Call prvSetFocus(cmdClose, cmbMcGroup)
                    End If
                Else
                    '@結果：異常の場合

                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmbMcGroupValidate)

                    '@失敗の場合には,装置名・装置状態変更のｺﾝﾎﾞを使用不可にする
                    cmbWp.Enabled = False

                    '@装置状態変更のｺﾝﾎﾞを使用不可にする
                    cmbUseName.Enabled = False
                    cmbUseName.Text = vbNullString

                    '@ﾒｯｾｰｼﾞﾁｪｯｸﾎﾞｯｸｽ使用不可
                    With chkMessage
                        .Checked = False
                        .Enabled = False
                    End With

                    '@ﾌｫｰｶｽそのまま
                    e.Cancel = True
                    Exit Sub
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = CMstrCmbMcGroupValidate
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWp_Change
    '機　能：装置名ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/22 (Tue) 13:04:57 S.Deguchi
    '更新日：2007/10/15 (Mon) 12:07:34 N.Kojima
    '備　考：
    '　　　：2004/11/16 (Tue) 13:48:48 H.Wajima     運用ﾓｰﾄﾞ一覧初期化処理追加
    '　　　：2005/02/24 (Thu) 16:16:01 N.Kojima　   稼動状態削除、現在の装置状態追加(改善№524、525)
    '　　　：2006/08/28 (Mon) 14:57:07 T.Kitagawa   ﾌｫﾄのTAT改善に伴う処理順指定追加(案件№01097)
    '　　　：2006/10/17 (Tue) 15:51:57 M.Miura      画面のﾗﾍﾞﾙ背景色の(赤/青)ちらつき修正(案件№01570)
    '　　　：2007/10/15 (Mon) 12:07:34 N.Kojima     ﾚｼﾋﾟｸﾞﾙｰﾌﾟｺﾝﾎﾞの追加に伴い処理追加。(案件№02152)
    Private Sub cmbWp_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWp.Change

        Try

            '@装置名ｺﾝﾎﾞのValueCol値を"装置ID"列に設定
            cmbWp.ValueCol = CMlngCmbValueCol1

            '@装置IDが退避領域と異なるか
            If mstrWpID <> cmbWp.Value Then
                '@異なる場合

                '@=======================
                '@ 各ｸﾞﾘｯﾄﾞの初期化処理
                '@=======================
                Call prvVsfPortNoList_Init          '装置ﾎﾟｰﾄ状態一覧ｸﾞﾘｯﾄﾞ
                Call prvVsfModeList_Init            '運用ﾓｰﾄﾞ一覧ｸﾞﾘｯﾄﾞ
                Call prvVsfChamberList_Init         '装置処理部用途/状態一覧ｸﾞﾘｯﾄﾞ

                '@退避情報の初期化
                mstrWpID = vbNullString

                '@最新取得ﾎﾞﾀﾝの初期化
                cmdSearch.Enabled = False

                '@作業ﾒﾓの初期化
                txtWorkMemo.Text = vbNullString

                '@Labelの初期化
                lblM1AfterMode.Text = vbNullString       '運用状態
                lblNowDate.Text = vbNullString           '情報取得日時
                lblUseName.Text = vbNullString           '現在の装置状態
                lblWpStatusName.Text = vbNullString      '処理状態
                lblBeforeMode.Text = vbNullString        '現在の運用ﾓｰﾄﾞ

                lblBeforeRecipeFlow.Text = vbNullString                 '現在の処理順指定
                lblBeforeRecipeFlowNum.Text = vbNullString              '現在の処理順ﾛｯﾄ数

                '@変更後処理順の初期化
                cmbRecipeFlow.ListIndex = -1
                cmbRecipeFlow.Text = vbNullString
                cmbRecipeFlow.BackColor = SystemColors.ControlLight     '灰色
                cmbRecipeFlow.Enabled = False                           '使用不可

                '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟｺﾝﾎﾞの初期化
                '@編集ｷｬﾝｾﾙﾌﾗｸﾞをTrue:編集しない(cmbRecipeGroup_Change処理内で使用)
                mblnRecipeGroupEditCancelFlag = True

                cmbRecipeGroup.ListIndex = -1
                cmbRecipeGroup.Text = vbNullString
                cmbRecipeGroup.BackColor = SystemColors.ControlLight    '灰色
                cmbRecipeGroup.Enabled = False                          '使用不可

                '@編集ｷｬﾝｾﾙﾌﾗｸﾞを戻す
                mblnRecipeGroupEditCancelFlag = False

                '@変更後処理ﾛｯﾄ数の初期化
                txtRecipeFlowNum.Text = vbNullString
                txtRecipeFlowNum.BackColor = SystemColors.ControlLight  '灰色
                txtRecipeFlowNum.Enabled = False                        '使用不可

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWp_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWp_CloseUp
    '機　能：装置名ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/22 (Tue) 13:05:31 S.Deguchi
    '更新日：2004/10/01 (Fri) 14:01:31 H.Wajima
    '備　考：
    '　　　：2004/10/01 (Fri) 14:01:31 H.Wajima     空白ﾁｪｯｸ追加
    Private Sub cmbWp_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWp.CloseUp

        Try

            '@装置名が未選択か
            If cmbWp.Text <> vbNullString Then

                '@=======================
                '@ 装置名ｺﾝﾎﾞのValidate処理
                '@=======================
                Call cmbWp_Validate(cmbWp, New CancelEventArgs(True))

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWp_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWp_Validate
    '機　能：[装置名]ｺﾝﾎﾞ　Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/06/22 (Tue) 13:05:51 S.Deguchi
    '更新日：2008/07/01 (Tue) 17:39:03 M.Koni
    '備　考：
    '　　　：2004/11/15 (Mon) 11:55:04 H.Wajima     運用ﾓｰﾄﾞﾘｽﾄの表示処理追加(不具合№211)
    '　　　：2005/05/24 (Tue) 18:40:09 N.Kojima     SetFocus対応(OnErr処理追加、ｲﾍﾞﾝﾄ名称の定数化、装置状態取得処理追加)
    '　　　：2006/04/27 (Thu) 11:24:10 N.Kojima     Form_Load中の「閉じる」ﾎﾞﾀﾝへのﾌｫｰｶｽｾｯﾄ処理を禁止。(不具合№3501)
    '　　　：2006/06/26 (Mon) 17:03:44 M.Miura      装置が選択状態の場合もForm_Load中の「閉じる」ﾎﾞﾀﾝへのﾌｫｰｶｽｾｯﾄ処理を禁止。(不具合№3542のついでに修正)
    '　　　：2006/06/28 (Wed) 14:02:10 N.Kojima     ﾃﾞﾌｫﾙﾄ装置以外の装置の場合、ﾗﾍﾞﾙ&ｸﾞﾘｯﾄﾞﾀｲﾄﾙ行の色変え処理を追加。(ﾕｰｻﾞｰ要望№0192)
    '　　　：2007/02/28 (Wed) 10:15:51 N.Kojima     ﾓｰﾄﾞﾘｽﾄの使用不可処理を「prvblnPortLotList_Chk」内に移動。(案件№01792)
    '　　　：2008/07/01 (Tue) 17:34:53 M.Koni       "util.regtminfo"応答ﾒｯｾｰｼﾞ変更対応<案件No.03006>
    Private Sub cmbWp_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbWp.Validating

        Dim lblnAns             As Boolean              '結果格納
        Dim ltypUtilRegTmInfo   As UtilRegTmInfo        '端末設定情報格納

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｴﾗｰ発生箇所の初期化
            ptypOnErrorInfo.strErrPositionDetail = vbNullString

            '@装置IDが未選択か
            If cmbWp.Text = vbNullString Then

                '@最新取得ﾎﾞﾀﾝが有効か
                If cmdSearch.Enabled = True Then

                    '@最新取得ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(cmdSearch, cmbWp)
                Else

                    '@Form_Load中は「cmdClose.Cancel=False」でEnabled=Falseなのでﾌｫｰｶｽはｾｯﾄしない
                    If pblnFormLoad <> False Then

                        '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call prvSetFocus(cmdClose, cmbWp)
                    End If
                End If

                Exit Sub
            Else
                '@選択されている場合

                '@退避領域と比較
                cmbMcGroup.ValueCol = CMlngCmbValueCol1
                cmbWp.ValueCol = CMlngCmbValueCol1

                '@退避領域の装置IDと選択装置名の装置IDが同じか
                If mstrWpID = cmbWp.Value Then

                    '@運用ﾓｰﾄﾞ一覧ｸﾞﾘｯﾄﾞが有効か
                    If vsfModeList.Enabled = True Then

                        '@ﾓｰﾄﾞ一覧にﾌｫｰｶｽｾｯﾄ
                        Call prvSetFocus(vsfModeList, cmbWp)
                    Else

                        '@Form_Load中は「cmdClose.Cancel=False」でEnabled=Falseなのでﾌｫｰｶｽはｾｯﾄしない
                        If pblnFormLoad <> False Then

                            '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call prvSetFocus(cmdClose, cmbWp)
                        End If
                    End If

                    Exit Sub
                End If

                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrCmbWpValidate)

                '@=======================
                '@ 装置状態/処理状態情報取得処理
                '@=======================
                lblnAns = prvblnPortLotList_Sel(cmbWp.Value)

                '@処理結果判定
                If lblnAns = False Then
                    '@結果：異常の場合

                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmbWpValidate)

                    '@ﾌｫｰｶｽそのまま
                    e.Cancel = True
                    Exit Sub
                Else
                    '@結果：正常の場合

                    '@=======================
                    '@ 運用ﾓｰﾄﾞ一覧ｸﾞﾘｯﾄﾞ作成処理
                    '@=======================
                    Call prvVsfModeList_Disp()

                    '@=======================
                    '@ 装置ﾎﾟｰﾄ状態一覧ｸﾞﾘｯﾄﾞ作成処理
                    '@=======================
                    Call prvVsfPortNoList_Disp()

                    '@【装置状態ﾏｽﾀ取得】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnMasWpUseList_Sel(CMstrmas_wpuselistVer, _
                                                     mtypUseList, _
                                                     mlngUseListCnt)

                    '@通信結果判定
                    If lblnAns = False Then
                        '@結果：異常の場合

                        '@=======================
                        '@ ﾒｲﾝﾌｫｰﾑの初期化処理
                        '@=======================
                        RemoveHandler cmbWp.Validating, AddressOf cmbWp_Validate
                        Call prvFrmxxEN00C0_Init()
                        AddHandler cmbWp.Validating, AddressOf cmbWp_Validate

                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                        Exit Sub
                    Else
                        '@=======================
                        '@ 変更後装置状態ｺﾝﾎﾞ作成処理
                        '@=======================
                        Call prvCmbUseName_Disp()

                        '@変更後装置状態ｺﾝﾎﾞを有効に
                        cmbUseName.Enabled = True
                    End If

                    '@=======================
                    '@ 装置処理部用途状態一覧ｸﾞﾘｯﾄﾞ作成処理
                    '@=======================
                    lblnAns = prvblnChamber_Set()

                    '@処理結果格納
                    If lblnAns = False Then
                        '@結果：異常の場合

                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmbWpValidate)
                        Exit Sub
                    End If

                    '@【端末設定情報登録】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnUtilRegTmInfo_Upd(pstrSBID, _
                                                      CMstrutilregtminfoVer, _
                                                      CPstrCD26, _
                                                      pstrComputerName, _
                                                      ltypUtilRegTmInfo, _
                                                      cmbWp.Value, , , _
                                                      cmbMcGroup.Value)

                    '@通信結果判定
                    If lblnAns = False Then
                        '@結果：異常の場合

                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmbWpValidate)
                    End If

                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrCmbWpValidate)

                    '@最新取得ﾎﾞﾀﾝを有効にする
                    cmdSearch.Enabled = True

                    '@=======================
                    '@ ﾃﾞﾌｫﾙﾄ装置以外(pstrTerminalFlag="1"orNULL)かにより、
                    '@ ﾗﾍﾞﾙ&ｸﾞﾘｯﾄﾞﾀｲﾄﾙ行の色を変える
                    '@=======================
                    Call prvColorChang_Proc()

                    '@=======================
                    '@ 装置状態ﾁｪｯｸ処理
                    '@=======================
                    lblnAns = prvblnPortLotList_Chk(CMlngChkModeFlg0)

                    '@　運用ﾓｰﾄﾞ一覧を活性化
                    vsfModeList.Enabled = True

                    '@　運用ﾓｰﾄﾞ一覧ｸﾞﾘｯﾄﾞが有効か
                    If vsfModeList.Enabled = True Then

                        '@運用ﾓｰﾄﾞ一覧へﾌｫｰｶｽｾｯﾄ
                        Call prvSetFocus(vsfModeList, cmbWp)
                    Else
                        '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call prvSetFocus(cmdClose, cmbWp)
                    End If
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = CMstrCmbWpValidate
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSearch_Click
    '機　能：[最新取得]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/22 (Tue) 11:19:07 S.Deguchi
    '更新日：2005/11/30 (Wed) 12:16:06 N.Kasai
    '備　考：
    '　　　：2004/10/05 (Tue) 17:15:25 S.Deguchi    一覧の表示後,ﾓｰﾄﾞ一覧の選択状態を解除する処理を追加
    '　　　：2005/05/19 (Thu) 12:53:31 N.Kojima     SetFocus対応(OnErr処理の追加、ｲﾍﾞﾝﾄ名称の定数化)
    '　　　：2005/11/30 (Wed) 12:16:06 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch.Click

        Dim lblnAns             As Boolean              '結果格納

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の条件の場合は、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中の場合は処理を受付けない
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If

            '@ｴﾗｰ発生箇所の初期化
            ptypOnErrorInfo.strErrPositionDetail = vbNullString

            '@=======================
            '@ 最新情報取得処理
            '@=======================
            Call prvCmdSearch_Upd()

            '@=======================
            '@ 装置状態ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnPortLotList_Chk(CMlngChkModeFlg0)

            '@処理結果判定
            If lblnAns = True Then
                '@結果：正常の場合

                '@ﾓｰﾄﾞ一覧が有効か
                If vsfModeList.Enabled = True Then

                    '@ﾓｰﾄﾞ一覧へﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfModeList)
                Else

                    '@装置状態ｺﾝﾎﾞが有効か
                    If cmbUseName.Enabled = True Then

                        '@ﾓｰﾄﾞ一覧へﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmbUseName)
                    Else
                        '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If

            '@作業ﾒﾓを使用可能に
            txtWorkMemo.Enabled = True

            '@変更後装置状態が選択されていない場合
            If cmbUseName.Text = vbNullString Then

                '@----------------------
                '@ ﾒｯｾｰｼﾞﾁｪｯｸﾎﾞｯｸｽ制御
                '@----------------------
                '@変更後装置状態が選択済みの場合使用可能
                '@ﾒｯｾｰｼﾞﾁｪｯｸﾎﾞｯｸｽ(使用可)
                With chkMessage
                    .Checked = False
                    .Enabled = False
                End With
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = CMstrCmdSearchClick
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbUseName_Change
    '機　能：[変更後(装置状態)]ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/21 (Mon) 15:04:04 N.Kojima
    '更新日：2006/01/10 (Tue) 14:00:01 N.Kasai
    '備　考：
    '　　　：2005/03/31 (Thu) 09:53:21 N.Kojima     装置状態変更ﾎﾞﾀﾝ制御を修正(不具合№651)
    '　　　：2006/01/10 (Tue) 14:00:01 N.Kasai      ﾒｯｾｰｼﾞﾁｪｯｸﾎﾞｯｸｽ追加
    Private Sub cmbUseName_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbUseName.Change

        Dim lstrBeforeMode      As String   '現在の運用ﾓｰﾄﾞ
        Dim lstrAfterMode       As String   '変更後運用ﾓｰﾄﾞ

        Try
            '@現在のﾓｰﾄﾞ、変更後のﾓｰﾄﾞを格納
            lstrBeforeMode = lblBeforeMode.Text
            lstrAfterMode = vsfModeList.GetData(vsfModeList.Row, CMlngvsfColMesMode)

            '@変更後ﾓｰﾄﾞのﾊﾞｯｸｶﾗｰが白(変更可)の場合
            If vsfModeList.GetCellRange(vsfModeList.Row, vsfModeList.Col).StyleDisplay.BackColor = Color.White Then

                '@変更後ﾓｰﾄﾞ・変更後装置状態が選択されている場合
                If vsfModeList.Row > 0 And cmbUseName.Text <> vbNullString Then

                    '@現在の運用ﾓｰﾄﾞと変更後運用ﾓｰﾄﾞが異なる場合
                    If lstrBeforeMode <> lstrAfterMode Then

                        '@確定ﾎﾞﾀﾝを有効に
                        cmdRegist.Enabled = True
                    Else
                        '@確定ﾎﾞﾀﾝを無効に
                        cmdRegist.Enabled = False
                    End If
                End If
            Else
                '@確定ﾎﾞﾀﾝを無効に
                cmdRegist.Enabled = False
            End If

            '@変更後装置状態が選択されていない場合
            If cmbUseName.Text = vbNullString Then

                '@各種ﾎﾞﾀﾝをﾛｯｸ
                cmdUseChange.Enabled = False        '装置状態変更ﾎﾞﾀﾝ
                cmdExecution.Enabled = False        '強制M1変更ﾎﾞﾀﾝ

                Exit Sub
            Else

                '@ﾊﾝﾄﾞﾜｰｸ工程用装置ではない場合
                If mblnHandWorkFlag = False Then

                    '@強制M1変更ﾎﾞﾀﾝを活性化
                    cmdExecution.Enabled = True
                Else
                    '@強制M1変更ﾎﾞﾀﾝを無効に
                    cmdExecution.Enabled = False
                End If

                '@=======================
                '@ ﾒｯｾｰｼﾞ表示ﾁｪｯｸﾎﾞｯｸｽ表示制御処理
                '@=======================
                Call prvChkMessage_Disp()

            End If

            '@現在のﾓｰﾄﾞと変更後ﾓｰﾄﾞが同じ場合
            If lstrBeforeMode <> lstrAfterMode Then
                '@装置状態変更ﾎﾞﾀﾝをﾛｯｸ
                cmdUseChange.Enabled = False
            End If

            '@変更前装置状態と変更後装置状態が同じ場合
            If lblUseName.Text = cmbUseName.Text Then

                '@装置状態変更ﾎﾞﾀﾝをﾛｯｸ
                cmdUseChange.Enabled = False
            Else
                '@装置状態変更ﾎﾞﾀﾝのﾛｯｸ解除
                cmdUseChange.Enabled = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbUseName_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbUseName_CloseUp
    '機　能：[変更後(装置状態)]ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/21 (Mon) 15:06:01 N.Kojima
    '更新日：2005/02/21 (Mon) 15:06:01
    '備　考：
    Private Sub cmbUseName_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbUseName.CloseUp

        Try

            '@=======================
            '@ 変更後(装置状態)ｺﾝﾎﾞのValidate処理
            '@=======================
            Call cmbUseName_Validate(cmbUseName, New CancelEventArgs(False))

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbUseName_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbUseName_Validate
    '機　能：[変更後(装置状態)]ｺﾝﾎﾞ　Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/02/21 (Mon) 15:07:43 N.Kojima
    '更新日：2006/01/10 (Tue) 14:00:41 N.Kasai
    '備　考：
    '　　　：2005/05/19 (Thu) 12:57:23 N.Kojima     SetFocus対応(OnErr処理の追加)
    '　　　：2006/01/10 (Tue) 14:00:41 N.Kasai      ﾒｯｾｰｼﾞ表示ﾁｪｯｸﾎﾞｯｸｽ表示制御追加
    Private Sub cmbUseName_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbUseName.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｴﾗｰ発生箇所の初期化
            ptypOnErrorInfo.strErrPositionDetail = vbNullString

            '@変更後ﾓｰﾄﾞが選択され、ﾓｰﾄﾞ移行ﾎﾞﾀﾝが有効、装置状態変更ﾎﾞﾀﾝも有効な場合
            If vsfModeList.Row > 0 And cmdRegist.Enabled = True And _
                cmdUseChange.Enabled = True Then

                '@ﾓｰﾄﾞ移行ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(cmdRegist, cmbUseName)
            Else
                '@装置状態変更ﾎﾞﾀﾝが有効か
                If cmdUseChange.Enabled = True Then

                    '@装置状態変更ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(cmdUseChange, cmbUseName)
                Else
                    '@変更後ﾓｰﾄﾞが選択され、ﾓｰﾄﾞ移行ﾎﾞﾀﾝが有効か
                    If vsfModeList.Row > 0 And cmdRegist.Enabled = True Then

                        '@ﾓｰﾄﾞ移行ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call prvSetFocus(cmdRegist, cmbUseName)
                    Else
                        '@作業ﾒﾓを有効に
                        txtWorkMemo.Enabled = True

                        '@作業ﾒﾓにﾌｫｰｶｽｾｯﾄ
                        Call prvSetFocus(txtWorkMemo, cmbUseName)
                    End If
                End If
            End If

            '@=======================
            '@ ﾒｯｾｰｼﾞ表示ﾁｪｯｸﾎﾞｯｸｽ表示制御処理
            '@=======================
            Call prvChkMessage_Disp()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = CMstrCmbUseNameValidate
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbRecipeFlow_Change
    '機　能：[変更後処理順指定]ｺﾝﾎﾞ　変更時処理
    '引　数：「なし
    '戻り値：なし
    '作成日：2006/08/29 (Tue) 09:43:06 T.Kitagawa
    '更新日：2009/10/20 (Tue) 10:26:59 T.Oide
    '備　考：
    '　　　：2007/10/17 (Wed) 13:43:57 N.Kojima     ﾚｼﾋﾟｸﾞﾙｰﾌﾟｺﾝﾎﾞ追加に伴い、処理追加＆修正。(案件№02152)
    '　　　：2009/10/20 (Tue) 10:26:59 T.Oide       搬送モード追加(案件№03761)
    Private Sub cmbRecipeFlow_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRecipeFlow.Change

        Try

            '@=======================
            '@ 処理順指定変更ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvCmdChangeProcOrderEnable_Set()

            '@★ 選択した変更後処理順指定により処理分岐 ★
            Select Case cmbRecipeFlow.Text

                '@〓 FIFO(到着順) OR FIFO(到着順)限定〓
                Case CPstrRecipeFlowFifo, CPstrRecipeFlowFifoSameNG

                    '@変更後の処理ﾛｯﾄ数の設定
                    With txtRecipeFlowNum
                        .Enabled = False
                        .BackColor = SystemColors.ControlLight
                        .Text = vbNullString
                    End With

                    '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟｺﾝﾎﾞの設定
                    With cmbRecipeGroup

                        '@編集ｷｬﾝｾﾙﾌﾗｸﾞをTrue:編集しない(cmbRecipeGroup_Change処理内で使用)
                        mblnRecipeGroupEditCancelFlag = True

                        .Clear
                        .Text = vbNullString
                        .Enabled = False
                        .BackColor = SystemColors.ControlLight

                        '@編集ｷｬﾝｾﾙﾌﾗｸﾞを戻す
                        mblnRecipeGroupEditCancelFlag = False
                    End With


                '@〓 ﾚｼﾋﾟ(切替) OR ﾚｼﾋﾟ(切替)限定 〓
                Case CPstrRecipeFlowNum, CPstrRecipeFlowNumSameNG

                    '@変更後の処理ﾛｯﾄ数の設定
                    With txtRecipeFlowNum
                        .Enabled = True
                        .BackColor = Color.White
                        .Text = vbNullString
                    End With

                    '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟｺﾝﾎﾞの設定
                    With cmbRecipeGroup

                        '@編集ｷｬﾝｾﾙﾌﾗｸﾞをTrue:編集しない(cmbRecipeGroup_Change処理内で使用)
                        mblnRecipeGroupEditCancelFlag = True

                        .Clear
                        .Text = vbNullString
                        .Enabled = False
                        .BackColor = SystemColors.ControlLight

                        '@編集ｷｬﾝｾﾙﾌﾗｸﾞを戻す
                        mblnRecipeGroupEditCancelFlag = False
                    End With


                '@〓 ﾚｼﾋﾟ(固定) OR ﾚｼﾋﾟ(固定)限定 〓
                Case CPstrRecipeFlowGroup, CPstrRecipeFlowGroupSameNG

                    '@変更後の処理ﾛｯﾄ数の設定
                    With txtRecipeFlowNum
                        .Enabled = False
                        .BackColor = SystemColors.ControlLight
                        .Text = vbNullString
                    End With

                    '@=======================
                    '@ ﾚｼﾋﾟｸﾞﾙｰﾌﾟｺﾝﾎﾞの作成処理
                    '@=======================
                    Call prvCmbRecipeGroup_Disp()

                    With cmbRecipeGroup

                        '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟが存在するか
                        If mtypEqstate.lngCollectTypeListCnt > 0 Then
                            .Enabled = True
                            .BackColor = Color.White
                        Else
                            .Clear
                            .Text = vbNullString
                            .Enabled = False
                            .BackColor = SystemColors.ControlLight
                        End If
                    End With

            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbRecipeFlow_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbRecipeFlow_CloseUp
    '機　能：[変更後処理順指定]ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/29 (Tue) 09:46:08 T.Kitagawa
    '更新日：2006/08/29 (Tue) 09:46:08
    '備　考：
    Private Sub cmbRecipeFlow_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRecipeFlow.CloseUp

        Try
            '@変更後処理順指定ｺﾝﾎﾞが選択されているか
            If cmbRecipeFlow.Text <> vbNullString Then

                '@=======================
                '@ 変更後処理順指定ｺﾝﾎﾞのValidate処理
                '@=======================
                Call cmbRecipeFlow_Validate(cmbRecipeFlow, New CancelEventArgs(False))
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbRecipeFlow_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbRecipeFlow_Validate
    '機　能：[変更後処理順指定]ｺﾝﾎﾞ　Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/08/29 (Tue) 09:46:37 T.Kitagawa
    '更新日：2009/10/20 (Tue) 10:26:59 T.Oide
    '備　考：
    '　　　：2007/10/17 (Wed) 20:59:15 N.Kojima     ﾚｼﾋﾟｸﾞﾙｰﾌﾟｺﾝﾎﾞ追加に伴い、処理追加。(案件№02152)
    '　　　：2009/10/20 (Tue) 10:26:59 T.Oide       搬送モード追加(案件№03761)
    Private Sub cmbRecipeFlow_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbRecipeFlow.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@=======================
            '@ 処理順指定変更ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvCmdChangeProcOrderEnable_Set()

            '@★ 選択した変更後処理順指定により処理分岐 ★
            Select Case cmbRecipeFlow.Text

                '@〓 FIFO(到着順) OR FIFO(到着順)限定 〓
                Case CPstrRecipeFlowFifo, CPstrRecipeFlowFifoSameNG

                    '@処理順指定変更ﾎﾞﾀﾝが有効か
                    If cmdChangeProcOrder.Enabled = True Then

                        '@処理順指定変更ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call prvSetFocus(cmdChangeProcOrder, cmbRecipeFlow)
                    Else
                        '@作業ﾒﾓにﾌｫｰｶｽｾｯﾄ
                        If txtWorkMemo.Enabled = True Then
                            Call prvSetFocus(txtWorkMemo, cmbRecipeFlow)
                        End If
                    End If


                '@〓 ﾚｼﾋﾟ(切替) OR ﾚｼﾋﾟ(切替)限定 〓
                Case CPstrRecipeFlowNum, CPstrRecipeFlowNumSameNG

                    '@処理ﾛｯﾄ数が有効か
                    If txtRecipeFlowNum.Enabled = True Then

                        '@処理ﾛｯﾄ数にﾌｫｰｶｽｾｯﾄ
                        Call prvSetFocus(txtRecipeFlowNum, cmbRecipeFlow)
                    Else
                        '@作業ﾒﾓにﾌｫｰｶｽｾｯﾄ
                        If txtWorkMemo.Enabled = True Then
                            Call prvSetFocus(txtWorkMemo, cmbRecipeFlow)
                        End If
                    End If


                '@〓 ﾚｼﾋﾟ(固定) OR ﾚｼﾋﾟ(固定)限定 〓
                Case CPstrRecipeFlowGroup, CPstrRecipeFlowGroupSameNG

                    '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟが有効か
                    If cmbRecipeGroup.Enabled = True Then

                        '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟにﾌｫｰｶｽｾｯﾄ
                        Call prvSetFocus(cmbRecipeGroup, cmbRecipeFlow)
                    Else
                        '@作業ﾒﾓにﾌｫｰｶｽｾｯﾄ
                        If txtWorkMemo.Enabled = True Then
                            Call prvSetFocus(txtWorkMemo, cmbRecipeFlow)
                        End If
                    End If

            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbRecipeFlow_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbRecipeGroup_Change
    '機　能：[ﾚｼﾋﾟｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/15 (Mon) 12:09:38 N.Kojima
    '更新日：2009/10/20 (Tue) 13:59:11 T.Oide
    '備　考：
    Private Sub cmbRecipeGroup_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRecipeGroup.Change

        Try

            With cmbRecipeGroup

                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False：Load中"、かつ編集ｷｬﾝｾﾙﾌﾗｸﾞが"False：編集する"か
                If mblnFormLoad1st = False And _
                    mblnRecipeGroupEditCancelFlag = False Then

                    '@変更後処理順指定が「ﾚｼﾋﾟ(固定)」以外、かつ「ﾚｼﾋﾟ(固定)限定」以外か
                    If cmbRecipeFlow.Text <> CPstrRecipeFlowGroup And _
                        cmbRecipeFlow.Text <> CPstrRecipeFlowGroupSameNG Then

                        '@ﾃｷｽﾄを戻す
                        .Text = mstrSelectRecipeCnt
                        Exit Sub
                    End If
                End If
            End With

            '@=======================
            '@ 処理順指定変更ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvCmdChangeProcOrderEnable_Set()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbRecipeGroup_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbRecipeGroup_CloseUp
    '機　能：[ﾚｼﾋﾟｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/15 (Mon) 12:11:52 N.Kojima
    '更新日：2007/10/15 (Mon) 12:11:52
    '備　考：
    Private Sub cmbRecipeGroup_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRecipeGroup.CloseUp

        Try
            '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟｺﾝﾎﾞが選択されているか
            If cmbRecipeGroup.Text <> vbNullString Then

                '@=======================
                '@ ﾚｼﾋﾟｸﾞﾙｰﾌﾟｺﾝﾎﾞのValidate処理
                '@=======================
                Call cmbRecipeGroup_Validate(cmbRecipeGroup, New CancelEventArgs(False))
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbRecipeGroup_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbRecipeGroup_Validate
    '機　能：[ﾚｼﾋﾟｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ　Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/10/15 (Mon) 12:11:41 N.Kojima
    '更新日：2007/10/15 (Mon) 12:11:41
    '備　考：
    Private Sub cmbRecipeGroup_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbRecipeGroup.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@=======================
            '@ 処理順指定変更ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvCmdChangeProcOrderEnable_Set()

            '@処理順指定変更ﾎﾞﾀﾝが有効か
            If cmdChangeProcOrder.Enabled = True Then

                '@処理順指定変更ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(cmdChangeProcOrder, cmbRecipeGroup)
            Else
                '@作業ﾒﾓにﾌｫｰｶｽｾｯﾄ
                If txtWorkMemo.Enabled = True Then
                    Call prvSetFocus(txtWorkMemo, cmbRecipeGroup)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbRecipeGroup_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtRecipeFlowNum_Change
    '機　能：[処理ﾛｯﾄ数]ﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/29 (Tue) 10:03:38 T.Kitagawa
    '更新日：2006/08/29 (Tue) 10:03:38
    '備　考：
    Private Sub txtRecipeFlowNum_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtRecipeFlowNum.Change

        Try
            '@=======================
            '@ 処理順指定変更ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvCmdChangeProcOrderEnable_Set()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtRecipeFlowNum_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtRecipeFlowNum_Validate
    '機　能：[処理ﾛｯﾄ数]ﾃｷｽﾄ　Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/08/29 (Tue) 10:07:19 T.Kitagawa
    '更新日：2007/10/17 (Wed) 21:00:14 N.Kojima
    '備　考：
    '　　　：2007/10/17 (Wed) 21:00:14 N.Kojima     ﾌｫｰｶｽ制御を修正。(案件№02152)
    Private Sub txtRecipeFlowNum_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtRecipeFlowNum.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@=======================
            '@ 処理順指定変更ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvCmdChangeProcOrderEnable_Set()

            '@処理順指定変更ﾎﾞﾀﾝが有効か
            If cmdChangeProcOrder.Enabled = True Then

                '@処理順指定変更ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(cmdChangeProcOrder, txtRecipeFlowNum)
            Else
                '@作業ﾒﾓにﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(txtWorkMemo, txtRecipeFlowNum)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtRecipeFlowNum_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfPortNoList_AfterEdit
    '機　能：[装置ﾎﾟｰﾄ状態一覧]ｸﾞﾘｯﾄﾞ　変更後処理
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2005/12/21 (Wed) 15:51:46 N.Kasai
    '更新日：2005/12/21 (Wed) 15:51:46
    '備　考：
    Private Sub vsfPortNoList_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfPortNoList.AfterEdit

        Dim lblnAns     As Boolean      '結果取得(True:正常,False:異常)

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfPortNoList.Rows.Count <= vsfPortNoList.Rows.Fixed Then
                Return
            End If

            With vsfPortNoList

                '@以下の場合は処理終了
                '@ ①対象行がﾍｯﾀﾞ
                '@ ②対象列が"自動搬送ｻｰﾋﾞｽ"列以外
                If .Row < .Rows.Fixed Or .Col <> CMlngvsfLColTransService Then
                    Exit Sub
                End If

                '@変更前自動搬送ｻｰﾋﾞｽ状態と、変更後自動搬送ｻｰﾋﾞｽ状態が同じか
                If .GetData(.Row, CMlngvsfLColTransService) = _
                    .GetData(.Row, CMlngvsfLColTransServiceID) Then

                    '@ﾊﾞｯｸｶﾗｰの変更
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                    newStyle.BackColor = Color.White
                    Dim cellRange As CellRange = .GetCellRange(.Row, CMlngvsfLColTransService)
                    cellRange.Style = newStyle                  '初期値(白)
                Else
                    '@ﾊﾞｯｸｶﾗｰの変更
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorSBlue")
                    newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorSBlue)
                    Dim cellRange As CellRange = .GetCellRange(.Row, CMlngvsfLColTransService)
                    cellRange.Style = newStyle                  '編集中(水色)
                End If

                '@=======================
                '@ 搬送ﾎﾟｰﾄ変更ﾎﾞﾀﾝ使用ﾁｪｯｸ
                '@=======================
                lblnAns = prvblnCmdChangeTrnst_Chk()

                '@処理結果判定
                If lblnAns = False Then
                    '@結果：異常の場合

                    '@搬送ﾎﾟｰﾄ変更ﾎﾞﾀﾝを無効にする
                    cmdChangeTrnst.Enabled = False
                Else
                    '@結果：正常の場合

                    '@搬送ﾎﾟｰﾄ変更ﾎﾞﾀﾝを有効にする
                    cmdChangeTrnst.Enabled = True
                End If

                'NSYS VB6ではComboCloseUpでAfterEditを走行させるために行っていた処理
                If mblnVsfComboListKeyDownEdit = False Then
                    If ActiveControl IsNot vsfPortNoList Then
                        ActiveControl = vsfPortNoList
                    End If
                    'NSYS ﾌｫｰｶｽを移動する。
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfPortNoList_AfterEdit"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfPortNoList_Click
    '機　能：[装置ﾎﾟｰﾄ状態一覧]ｸﾞﾘｯﾄﾞ　Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/21 (Wed) 15:46:39 N.Kasai
    '更新日：2005/12/21 (Wed) 15:46:39
    '備　考：
    Private Sub vsfPortNoList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfPortNoList.Click

        Dim llngDoCnt   As Integer          'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lblnAns     As Boolean          '結果取得(True:正常,False:異常)

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfPortNoList.Rows.Count <= vsfPortNoList.Rows.Fixed Then
                Return
            End If

            With vsfPortNoList

                '@対象行がﾍｯﾀﾞ以外の場合
                If .Row < .Rows.Fixed Then
                    Exit Sub
                End If

                '@★ 対象列により処理分岐 ★
                Select Case .Col

                    '@〓 自動搬送ｻｰﾋﾞｽ 〓
                    Case CMlngvsfLColTransService

                        '@ｸﾞﾘｯﾄﾞを編集可能にする
                        .AllowEditing = True

                    '@〓 ｷｬﾘｱ強制搬出 〓
                    Case CMlngvsfLColCarrierUnload

                        '@=======================
                        '@ ｷｬﾘｱ強制搬出ﾁｪｯｸ
                        '@=======================
                        lblnAns = prvblnCarrierUnloadEnable_Chk(.Row)

                        '@処理結果判定
                        If lblnAns = True Then
                            '@結果：正常の場合

                            '@ｸﾞﾘｯﾄﾞを編集可能にする
                            .AllowEditing = True

                            llngDoCnt = 1
                            Do While .Rows.Count > llngDoCnt

                                '@選択されたｾﾙに対しての処理
                                If llngDoCnt = .Row Then

                                    '@ﾁｪｯｸﾎﾞｯｸｽにﾁｪｯｸが付いているか
                                    If .GetCellCheck(llngDoCnt, CMlngvsfLColCarrierUnload) = CheckEnum.Checked Then
                                        '@ﾁｪｯｸされている場合

                                        '@ﾁｪｯｸﾎﾞｯｸｽをUncheckedにする
                                        .SetCellCheck(llngDoCnt, CMlngvsfLColCarrierUnload, CheckEnum.Unchecked)
                                        'ｷｬﾘｱ強制搬出ﾎﾞﾀﾝは使用不可
                                        cmdCarrierUnload.Enabled = False
                                    Else
                                        '@ﾁｪｯｸされていない場合

                                        '@ﾁｪｯｸﾎﾞｯｸｽをCheckedにする
                                        .SetCellCheck(llngDoCnt, CMlngvsfLColCarrierUnload, CheckEnum.Checked)
                                        'ｷｬﾘｱ強制搬出ﾎﾞﾀﾝは使用可
                                        cmdCarrierUnload.Enabled = True
                                    End If
                                Else
                                    '@ﾁｪｯｸﾎﾞｯｸｽにﾁｪｯｸが付いているか
                                    If .GetCellCheck(llngDoCnt, CMlngvsfLColCarrierUnload) = CheckEnum.Checked Then

                                        '@ﾁｪｯｸﾎﾞｯｸｽをUncheckedにする
                                        .SetCellCheck(llngDoCnt, CMlngvsfLColCarrierUnload, CheckEnum.Unchecked)
                                    End If
                                End If

                                llngDoCnt = llngDoCnt + 1
                            Loop
                        End If

                        '@編集不可
                        .AllowEditing = False

                    '@〓 その他 〓
                    Case Else

                        '@編集不可
                        .AllowEditing = False

                End Select
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfPortNoList_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfPortNoList_ComboCloseUp
    '機　能：[装置ﾎﾟｰﾄ状態一覧]ｸﾞﾘｯﾄﾞ　ｸﾞﾘｯﾄﾞｺﾝﾎﾞ選択時処理
    '引　数：Row：行
    '　　　：Col：列
    '　　　：FinishEdit：編集終了
    '戻り値：なし
    '作成日：2005/12/21 (Wed) 15:43:44 N.Kasai
    '更新日：2005/12/21 (Wed) 15:43:44
    '備　考：
    Private Sub vsfPortNoList_ComboCloseUp(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfPortNoList.ComboCloseUp

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfPortNoList.Rows.Count <= vsfPortNoList.Rows.Fixed Then
                Return
            End If

            With vsfPortNoList

                '@以下の場合は処理終了
                '@ ①対象行がﾍｯﾀﾞ
                '@ ②対象列が"自動搬送ｻｰﾋﾞｽ"列以外
                If .Row < .Rows.Fixed Or .Col <> CMlngvsfLColTransService Then
                    Exit Sub
                End If

                '@注意!!
                '@AfterEditを走行する為、ﾌｫｰｶｽを移動する。
                'NSYS VB.NETでは ComboCloseUp の直後に編集モード終了し AfterEdit も動作する
                'SendKeys.SendWait(CPstrSendKeysTab)

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfPortNoList_ComboCloseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUP_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(装置ﾎﾟｰﾄ状態一覧ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/20 (Mon) 08:47:08 S.Deguchi
    '更新日：2004/09/20 (Mon) 08:47:08
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

            '@=======================
            '@ 上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ共通処理)
            '@=======================
            Call pubVsfCmdUp(vsfPortNoList, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUp_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(装置ﾎﾟｰﾄ状態一覧ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/20 (Mon) 08:47:05 S.Deguchi
    '更新日：2004/09/20 (Mon) 08:47:05
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

            '@=======================
            '@ 下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ共通処理)
            '@=======================
            Call pubVsfCmdDown(vsfPortNoList, cmdUP, cmdDown, False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDown_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfModeList_RowColChange
    '機　能：[運用ﾓｰﾄﾞ一覧]ｸﾞﾘｯﾄﾞ　行/列変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/20 (Mon) 09:14:37 S.Deguchi
    '更新日：2006/06/19 (Mon) 18:28:52 T.Kitagawa
    '備　考：
    '　　　：2004/11/15 (Mon) 11:50:49 H.Wajima     運用ﾓｰﾄﾞﾀｲﾌﾟ判定追加(不具合№211)
    '　　　：2005/02/24 (Thu) 16:42:36 N.Kojima　   変更後装置状態の格納・表示処理追加(改善№524、525)
    '　　　：2005/04/20 (Wed) 17:35:01 N.Kojima     ﾊﾞｯﾁS1運用対応(MES_MODE_TYPE=3(S2不可)の時の処理追加)
    '　　　：2005/05/16 (Mon) 11:34:13 N.Kojima     MES_MODE_TYPE=4(F不可)の時の処理追加(不具合№790)
    '　　　：2005/12/27 (Tue) 14:47:12 N.Kasai      表示ﾁｪｯｸﾎﾞｯｸｽ制御追加
    '　　　：2006/06/19 (Mon) 18:28:52 T.Kitagawa   MES_MODE_TYPE=10～14の追加対応(不具合№3536)
    Private Sub vsfModeList_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfModeList.RowColChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfModeList.Rows.Count <= vsfModeList.Rows.Fixed Then
                Return
            End If

            With vsfModeList

                '@=======================
                '@ 変更後(装置状態)ｺﾝﾎﾞの作成処理
                '@=======================
                Call prvCmbUseName_Disp()

                '@ﾒｯｾｰｼﾞﾁｪｯｸﾎﾞｯｸｽ(使用不可)
                With chkMessage
                    .Checked = False
                    .Enabled = False
                End With

                '@装置名が選択されているか
                If cmbWp.Text <> vbNullString Then

                    '@変更後装置状態を有効に
                    cmbUseName.Enabled = True
                End If

                '@選択行がﾀｲﾄﾙ行以外か
                If .Row <> 0 Then

                    '@変更前運用ﾓｰﾄﾞと、変更後運用ﾓｰﾄﾞが同じか
                    If .GetData(.Row, CMlngvsfColMode) = lblBeforeMode.Text Then
                        '@同じ場合

                        '@確定ﾎﾞﾀﾝを無効にする
                        cmdRegist.Enabled = False
                    Else
                        '@異なる場合

                        '@変更後(装置状態)ｺﾝﾎﾞが選択されているか
                        If cmbUseName.Text <> vbNullString Then
                            '@選択されている場合

                            '@★ 装置状態取得の運用ﾓｰﾄﾞﾀｲﾌﾟにより処理分岐 ★
                            Select Case mtypEqstate.strMesModeType

                                '@〓 通常ﾀｲﾌﾟ(全ﾓｰﾄﾞ移行可能) 〓
                                Case CPstrMesModeType0, CPstrMesModeType10
                                    '@全て可の場合(M1処理中可、M1処理中不可)

                                    '@確定ﾎﾞﾀﾝを有効にする
                                    cmdRegist.Enabled = True


                                '@〓 搬送Manual(S2,F使用不可) 〓
                                Case CPstrMesModeType1, CPstrMesModeType11
                                    '@S2/F不可の場合(M1処理中可、M1処理中不可)

                                    '@★★ 運用ﾓｰﾄﾞにより処理分岐 ★★
                                    Select Case .GetData(.Row, CMlngvsfColMode)

                                        '@〓〓 "S2" or "F" 〓〓
                                        Case CMstrModeS2, CMstrModeF

                                            '@確定ﾎﾞﾀﾝを無効にする
                                            cmdRegist.Enabled = False

                                        '@〓〓 その他 〓〓
                                        Case Else

                                            '@確定ﾎﾞﾀﾝを有効にする
                                            cmdRegist.Enabled = True

                                    End Select


                                '@〓 特殊ﾀｲﾌﾟ(M2使用不可) 〓
                                Case CPstrMesModeType2, CPstrMesModeType12
                                    '@M2不可の場合(M1処理中可、M1処理中不可)

                                    '@確定ﾎﾞﾀﾝを有効にする
                                    cmdRegist.Enabled = True


                                '@〓 特殊ﾀｲﾌﾟ(S2使用不可) 〓
                                Case CPstrMesModeType3, CPstrMesModeType13
                                    '@S2不可の場合(M1処理中可、M1処理中不可)

                                    '@★★ 運用ﾓｰﾄﾞにより処理分岐 ★★
                                    Select Case .GetData(.Row, CMlngvsfColMode)

                                        '@〓〓 "S2" 〓〓
                                        Case CMstrModeS2

                                            '@確定ﾎﾞﾀﾝを無効にする
                                            cmdRegist.Enabled = False

                                        '@〓〓 その他 〓〓
                                        Case Else

                                            '@確定ﾎﾞﾀﾝを有効にする
                                            cmdRegist.Enabled = True

                                    End Select


                                '@〓 特殊ﾀｲﾌﾟ(F使用不可) 〓
                                Case CPstrMesModeType4, CPstrMesModeType14
                                    '@F不可の場合(M1処理中可、M1処理中不可)
                                    
                                    '@★★ 運用ﾓｰﾄﾞにより処理分岐 ★★
                                    Select Case .GetData(.Row, CMlngvsfColMode)

                                        '@〓〓 "F" 〓〓
                                        Case CMstrModeF

                                            '@確定ﾎﾞﾀﾝを無効にする
                                            cmdRegist.Enabled = False

                                        '@〓〓 その他 〓〓
                                        Case Else

                                            '@確定ﾎﾞﾀﾝを有効にする
                                            cmdRegist.Enabled = True

                                    End Select

                            End Select
                        Else
                            '@変更後(装置状態)ｺﾝﾎﾞが選択されていない場合

                            '@確定ﾎﾞﾀﾝを無効にする
                            cmdRegist.Enabled = False
                        End If
                    End If
                Else
                    '@ﾀｲﾄﾙ行選択の場合

                    '@確定ﾎﾞﾀﾝを無効にする
                    cmdRegist.Enabled = False
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfModeList_RowColChange"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfChamberList_AfterEdit
    '機　能：装置処理部用途/状態一覧ｸﾞﾘｯﾄﾞ　変更後処理
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2006/11/21 (Tue) 16:19:10 N.Kasai
    '更新日：2006/11/21 (Tue) 16:19:10
    '備　考：
    Private Sub vsfChamberList_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfChamberList.AfterEdit

        Dim lblnAns         As Boolean      '結果取得(True:正常,False:異常)

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfChamberList.Rows.Count <= vsfChamberList.Rows.Fixed Then
                Return
            End If

            With vsfChamberList

                '@以下の場合は処理終了
                '@ ①対象行がﾍｯﾀﾞ
                '@ ②対象列が"処理部用途"列以外、かつ"状態"列以外
                If .Row < .Rows.Fixed Or _
                    (.Col <> CMlngvsfCColProcessingName And .Col <> CMlngvsfCColUseName) Then

                    Exit Sub
                End If

                '@対象列が"処理部用途"列か
                If .Col = CMlngvsfCColProcessingName Then

                    .SetData(.Row, CMlngvsfCColChamberID, _
                        .GetData(.Row, CMlngvsfCColProcessingName))     '処理部用途
                End If

                '@変更前の処理部用途と、変更後の処理部用途が同じか
                If Trim$(.GetDataDisplay(.Row, CMlngvsfCColProcessingName)) = _
                    Trim$(.GetData(.Row, CMlngvsfCColOldProcessingName)) Then

                    '@ﾊﾞｯｸｶﾗｰの変更
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                    newStyle.BackColor = Color.White
                    Dim cellRange As CellRange = .GetCellRange(.Row, CMlngvsfCColProcessingName)
                    cellRange.Style = newStyle                  '初期値(白)
                Else
                    '@ﾊﾞｯｸｶﾗｰの変更
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorSBlue")
                    newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorSBlue)
                    Dim cellRange As CellRange = .GetCellRange(.Row, CMlngvsfCColProcessingName)
                    cellRange.Style = newStyle                  '編集中(水色)
                End If

                '@変更前の処理部状態と、変更後の処理部状態が同じか
                If .GetData(.Row, CMlngvsfCColUseName) = _
                    .GetData(.Row, CMlngvsfCColOldUseID) Then

                    '@ﾊﾞｯｸｶﾗｰの変更
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                    newStyle.BackColor = Color.White
                    Dim cellRange As CellRange = .GetCellRange(.Row, CMlngvsfCColUseName)
                    cellRange.Style = newStyle                  '初期値(白)
                Else
                    '@ﾊﾞｯｸｶﾗｰの変更
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngBackColorSBlue")
                    newStyle.BackColor = ColorTranslator.FromWin32(CMlngBackColorSBlue)
                    Dim cellRange As CellRange = .GetCellRange(.Row, CMlngvsfCColUseName)
                    cellRange.Style = newStyle                  '編集中(水色)
                End If

                '@=======================
                '@ 処理部用途/状態変更ﾎﾞﾀﾝ使用ﾁｪｯｸ
                '@=======================
                lblnAns = prvblnCmdChangeChamber_Chk()

                '@処理結果判定
                If lblnAns = False Then
                    '@結果：異常の場合

                    '@処理部用途/状態変更ﾎﾞﾀﾝを無効にする
                    cmdChangeChamber.Enabled = False
                Else
                    '@結果：正常の場合

                    '@処理部用途/状態変更ﾎﾞﾀﾝを有効にする
                    cmdChangeChamber.Enabled = True
                End If

                'NSYS VB6ではComboCloseUpでAfterEditを走行させるために行っていた処理
                If mblnVsfComboListKeyDownEdit = False Then
                    If ActiveControl IsNot vsfChamberList Then
                        ActiveControl = vsfChamberList
                    End If
                    'NSYS ﾌｫｰｶｽを移動する。
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfChamberList_AfterEdit"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfChamberList_Click
    '機　能：[装置処理部用途/状態一覧]ｸﾞﾘｯﾄﾞ　Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/11/21 (Tue) 16:20:23 N.Kasai
    '更新日：2006/11/21 (Tue) 16:20:23
    '備　考：
    Private Sub vsfChamberList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfChamberList.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfChamberList.Rows.Count <= vsfChamberList.Rows.Fixed Then
                Return
            End If

            With vsfChamberList

                '@対象行がﾍｯﾀﾞ以外の場合
                If .Row < .Rows.Fixed Then
                    Exit Sub
                End If

                '@★ 対象列により処理分岐 ★
                Select Case .Col

                    '@〓 処理部用途 〓
                    Case CMlngvsfCColProcessingName

                        .Cols(CMlngvsfCColProcessingName).DataMap = mstrProcess
                        '@ｸﾞﾘｯﾄﾞを編集可能にする
                        .AllowEditing = True

                    '@〓 状態 〓
                    Case CMlngvsfCColUseName

                        '@ｸﾞﾘｯﾄﾞを編集可能にする
                        .AllowEditing = True

                    '@〓 その他 〓
                    Case Else

                        '@編集不可
                        .AllowEditing = False

                End Select
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfChamberList_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfChamberList_ComboCloseUp
    '機　能：[装置処理部用途/状態一覧ｸﾞﾘｯﾄﾞ　ｸﾞﾘｯﾄﾞｺﾝﾎﾞ選択時処理
    '引　数：Row：行
    '　　　：Col：列
    '　　　：FinishEdit：編集終了
    '戻り値：なし
    '作成日：2006/11/21 (Tue) 16:21:12 N.Kasai
    '更新日：2006/11/21 (Tue) 16:21:12
    '備　考：
    Private Sub vsfChamberList_ComboCloseUp(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfChamberList.ComboCloseUp

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfChamberList.Rows.Count <= vsfChamberList.Rows.Fixed Then
                Return
            End If

            With vsfChamberList

                '@対象行がﾍｯﾀﾞ以外の場合
                If e.Row < .Rows.Fixed Then
                    Exit Sub
                End If

                '@注意!!
                '@AfterEditを走行する為、ﾌｫｰｶｽを移動する。
                'NSYS VB.NETでは ComboCloseUp の直後に編集モード終了し AfterEdit も動作する
                'SendKeys.SendWait(CPstrSendKeysTab)

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfChamberList_ComboCloseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdChamberUP_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(装置処理部用途/状態一覧ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/11/20 (Mon) 11:31:00 N.Kasai
    '更新日：2006/11/20 (Mon) 11:31:00
    '備　考：
    Private Sub cmdChamberUP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdChamberUP.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@ 上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ共通処理)
            '@=======================
            Call pubVsfCmdUp(vsfChamberList, cmdChamberUP, cmdChamberDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdChamberUP_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdChamberDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(装置処理部用途/状態一覧ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/11/20 (Mon) 11:32:12 N.Kasai
    '更新日：2006/11/20 (Mon) 11:32:12
    '備　考：
    Private Sub cmdChamberDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdChamberDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@ 下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ共通処理)
            '@=======================
            Call pubVsfCmdDown(vsfChamberList, cmdChamberUP, cmdChamberDown, False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdChamberDown_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_Change
    '機　能：[作業ﾒﾓ]ﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/22 (Tue) 14:54:43 S.Deguchi
    '更新日：2005/11/30 (Wed) 11:41:50 N.Kasai
    '備　考：
    '　　　：2005/11/30 (Wed) 11:41:50 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change

        Dim llngNowByte     As Integer  'ﾊﾞｲﾄ数

        Try

            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtWorkMemo.NowByte

            '@=======================
            '@ 現在のﾊﾞｲﾄ数の表示処理(表示ﾒｯｾｰｼﾞ変換処理)
            '@=======================
            lblReleaseLengthCount.Text _
                = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)

            '@=======================
            '@ ﾃｷｽﾄ変更時処理(ﾃｷｽﾄ共通処理)
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdWorkMemoUp, cmdWorkMemoDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_KeyUp
    '機　能：[作業ﾒﾓ]ﾃｷｽﾄ　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:15:19 N.Kasai
    '更新日：2005/11/29 (Tue) 14:15:19
    '備　考：
    Private Sub txtWorkMemo_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtWorkMemo.KeyUp

        Try

            '@=======================
            '@ ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作時処理(ﾃｷｽﾄ共通処理)
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtWorkMemo, CMlngMaxDispMemoRow, cmdWorkMemoUp, cmdWorkMemoDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_MouseUp
    '機　能：[作業ﾒﾓ]ﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:52:24 N.Kasai
    '更新日：2005/11/29 (Tue) 14:52:24
    '備　考：
    Private Sub txtWorkMemo_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtWorkMemo.MouseUp

        Try
            '@=======================
            '@ ﾃｷｽﾄ変更時処理(ﾃｷｽﾄ共通処理)
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdWorkMemoUp, cmdWorkMemoDown, e.Button)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWorkMemoUp_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(作業ﾒﾓ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/16 (Fri) 09:20:24 Y.Yamagishi
    '更新日：2005/11/30 (Wed) 11:47:51 N.Kasai
    '備　考：
    '　　　：2005/11/30 (Wed) 11:47:51 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdWorkMemoUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWorkMemoUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@ 上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ﾃｷｽﾄ共通処理)
            '@=======================
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdWorkMemoUp, cmdWorkMemoDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWorkMemoUp_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWorkMemoDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(作業ﾒﾓ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/16 (Fri) 09:20:29 Y.Yamagishi
    '更新日：2005/11/30 (Wed) 11:48:40 N.Kasai
    '備　考：
    '　　　：2005/11/30 (Wed) 11:48:40 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdWorkMemoDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWorkMemoDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@ 下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ﾃｷｽﾄ共通処理)
            '@=======================
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdWorkMemoUp, cmdWorkMemoDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWorkMemoDown_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：[閉じる]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/18 (Fri) 16:48:44 S.Deguchi
    '更新日：2005/05/19 (Thu) 11:40:18 N.Kojima
    '備　考：
    '　　　：2005/05/19 (Thu) 11:40:18 N.Kojima     SetFocus対応(ﾏｳｽﾎﾟｲﾝﾀｰが砂時計orﾌｫｰﾑﾛｯｸ中は処理を飛ばす)
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim ltypCommonInfo  As CommonInfo

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の条件の場合は、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中の場合は処理を受付けない
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If

            '@=======================
            '@ 終了関数を実行する
            '@=======================
            Call publngEnd_Proc(CPstrKeyEN00C0, ltypCommonInfo)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClose_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：[確定]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/22 (Tue) 15:55:57 S.Deguchi
    '更新日：2011/06/17 (Fri) 10:37:22 T.Oide
    '備　考：
    '　　　：2004/10/05 (Tue) 16:00:27 S.Deguchi    変更確定後,情報をｸﾘｱせずに最新情報を取得し直すように変更
    '　　　：2004/12/14 (Tue) 09:27:11 H.Wajima     装置状態ﾁｪｯｸを追加(№272)
    '　　　：2005/01/08 (Sat) 18:42:42 N.Kojima     搬送予約ｷｬﾘｱがある場合、警告ﾒｯｾｰｼﾞを表示する(№409)
    '　　　：2005/01/21 (Fri) 13:56:57 N.Kojima     F/S2→S1/M2/M1への変更時に上記状態の場合のみ、ﾒｯｾｰｼﾞ出力する(№409)
    '　　　：2005/02/21 (Mon) 15:55:58 N.Kojima     ﾓｰﾄﾞ移行と装置状態変更を同時に行う(改善№524、525)
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2005/05/19 (Thu) 13:00:00 N.Kojima     SetFocus対応(OnErr処理追加、ｲﾍﾞﾝﾄ名称の定数化)
    '　　　：2005/12/19 (Mon) 15:56:41 N.Kojima     値取得列の明確化と送信ﾃﾞｰﾀの整合性ﾁｪｯｸを追加。(運用障害№653)
    '　　　：2006/06/28 (Wed) 14:16:26 N.Kojima     ﾃﾞﾌｫﾙﾄ装置以外の装置の場合、ﾒｯｾｰｼﾞを表示するように改善。(ﾕｰｻﾞｰ要望№0192)
    '　　　：2007/02/01 (Thu) 15:31:43 N.Kojima     故障修理記録票登録処理を追加。(案件№01602)
    '　　　：2007/03/23 (Fri) 10:00:18 N.Kojima     故障修理記録票の登録日時をWP_EVENT_HISTORYのENTRY_TIMEで登録するように修正。(案件№01830)
    '　　　：2008/02/04 (Mon) 09:44:51 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    '　　　：2011/06/17 (Fri) 10:37:22 T.Oide       保全記録表の自動起動中止(REQ-1160)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                     As Boolean              '結果格納
        Dim ltypEqChgMode               As EqChgMode            'ﾓｰﾄﾞ変更構造体
        Dim lstrBeforeMode              As String               '変更前運用ﾓｰﾄﾞ
        Dim lstrAfterMode               As String               '変更後運用ﾓｰﾄﾞ
        Dim lstrBeforeUseID             As String               '変更前装置状態ID
        Dim lstrAfterUseID              As String               '変更後装置状態ID
        Dim lstrBeforeUseName           As String               '変更前装置状態
        Dim lstrAfterUseName            As String               '変更後装置状態
        Dim lstrGuidMsg                 As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode             As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance            As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrNormalStateFlag         As String               '装置状態通常ﾌﾗｸﾞ
        Dim lstrMessageID               As String               'ﾒｯｾｰｼﾞID
        Dim llngWpIDValueCol            As Integer              '退避用装置名ｺﾝﾎﾞ値取得列
        Dim llngUseNameValueCol         As Integer              '退避用変更後ｺﾝﾎﾞ値取得列
        Dim lstrRepairNo                As String               '故障修理記録票№
        Dim lstrPreserveNo              As String               '保全記録票№
        Dim lstrEditTime                As String               '更新(登録)日時
        Dim lstrEntryTime               As String               '登録日時(WP_EVENT_HISTORYの登録日時)

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の条件の場合は、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中の場合は処理を受付けない
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If

            '@ｴﾗｰ発生箇所の初期化
            ptypOnErrorInfo.strErrPositionDetail = vbNullString

            '@=======================
            '@ 装置状態ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnPortLotList_Chk(CMlngChkModeFlg1)

            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                Exit Sub
            End If

            '@=======================
            '@ 確定前ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnCheck_Proc(CMstrCmdRegistClick)

            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                Exit Sub
            End If

            '@変更前運用ﾓｰﾄﾞ、変更前装置状態を格納
            lstrBeforeMode = lblBeforeMode.Text
            lstrBeforeUseName = lblUseName.Text

            '@変更後運用ﾓｰﾄﾞ、変更後装置状態を格納
            lstrAfterMode = vsfModeList.GetData(vsfModeList.Row, CMlngvsfColMode)
            lstrAfterUseName = cmbUseName.Text

            '@現在の「変更後装置状態ｺﾝﾎﾞ」の値取得列を退避
            llngUseNameValueCol = cmbUseName.ValueCol

            '@「変更後装置状態ｺﾝﾎﾞ」の値取得列を「状態ID(USE_ID)」列に設定
            cmbUseName.ValueCol = CMlngCmbValueCol1
            ltypEqChgMode.strUseId = cmbUseName.Value               '変更後装置状態ID
            lstrAfterUseID = cmbUseName.Value                       '変更後装置状態ID(故障修理記録票登録Function引数用)

            '@=======================
            '@ 装置状態ﾒｯｾｰｼﾞ表示
            '@=======================
            lblnAns = prvblnMessage_Chk(ltypEqChgMode.strUseId, _
                                        lstrNormalStateFlag, _
                                        lstrMessageID)

            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                Exit Sub
            End If

            '@***********************
            '@ 要求ﾃﾞｰﾀ作成
            '@***********************
            With ltypEqChgMode

                .strWpID = cmbWp.Value                      '装置ID

                llngWpIDValueCol = cmbWp.ValueCol           '装置名ｺﾝﾎﾞのValueCol値を退避
                cmbWp.ValueCol = CMlngCmbValueCol2          '装置名ｺﾝﾎﾞのValueCol値を"状態ID"列に設定
                .strOldUseID = cmbWp.Value                  '変更前装置状態ID
                lstrBeforeUseID = cmbWp.Value               '変更前装置状態ID(故障修理記録票登録Function引数用)
                cmbWp.ValueCol = llngWpIDValueCol           '装置名ｺﾝﾎﾞのValueCol値を変更前の値に戻す

                cmbUseName.ValueCol = CMlngCmbValueCol3     '変更後装置状態ｺﾝﾎﾞのValueCol値を"停止ﾌﾗｸﾞ"列に設定
                .strWpStopFlag = cmbUseName.Value           '停止ﾌﾗｸﾞ
                cmbUseName.ValueCol = llngUseNameValueCol   '変更後装置状態ｺﾝﾎﾞのValueCol値を変更前の値に戻す

                .strMesModeId = lstrAfterMode               '運用ﾓｰﾄﾞ
                .strComments = txtWorkMemo.Text             '作業ﾒﾓ
                .strMsgVer = CMstreq__chgmode_Ver           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMessageID = lstrMessageID               'ﾒｯｾｰｼﾞID

                '@ｺﾝﾎﾞの値(Value)を取得してMsg送信している項目はﾁｪｯｸする
                '@装置ID,変更前状態ID,変更後状態ID,停止ﾌﾗｸﾞ
                If .strWpID = vbNullString Or .strOldUseID = vbNullString _
                    Or .strUseId = vbNullString Or .strWpStopFlag = vbNullString Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRMY2W>$$軽微なシステムエラーが発生しました。$再度処理を実行し、
                    '@　このエラーメッセージが表示された場合は、$システム担当者に連絡してください。"」を表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar00Y2)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    Exit Sub
                End If
            End With

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
            If pstrUserID = vbNullString Then
                '@未入力の場合、投入中止
                Exit Sub
            End If

            ltypEqChgMode.strEmpID = pstrUserID     '作業者ID

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)


            '@【運用ﾓｰﾄﾞ変更要求】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnEqChgMode_Upd(ltypEqChgMode, _
                                          lstrGuidMsg, _
                                          lstrGuidMsgCode, _
                                          lstrEntryTime)


            '@通信結果判定
            If lblnAns = True Then
                '@結果：正常の場合

                '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞに値が入っているか
                If lstrGuidMsgCode <> vbNullString Then
                    '@入っている場合

                    '@表示ｶﾞｲﾀﾞﾝｽMsgの編集("【警告】" & "$$" & "ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ[CODE]">" & "$$" & ｶﾞｲﾀﾞﾝｽMsg)
                    lstrEditGuidance = CPstrWarMsgCode & CPstrGuidanceMsg & CPstrMsgCrCode & _
                                       CPstrGuidanceCode & CPstrBracketLeft & lstrGuidMsgCode & CPstrBracketRight & _
                                       CPstrMsgCrCode & lstrGuidMsg

                    '@上記の「"編集済みｶﾞｲﾀﾞﾝｽMsg"」をﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(lstrEditGuidance)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                End If

                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM4FI>$$装置[%1]の運用モードを[%2]から[%3]、装置状態を[%4]から[%5]へ変更しました。"」をｽﾃｰﾀｽﾊﾞｰに表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004F, cmbWp.Text, lstrBeforeMode, _
                                                lstrAfterMode, lstrBeforeUseName, lstrAfterUseName)
                Call pubVsfInfo_Disp(pstrDMsg)

                '@過去にMetaの描画が追いつかず、装置状態IDがNULLで送信されてしまったｹｰｽがあったので、ｴﾗｰﾄﾗｯﾌﾟを仕掛ける
                If cmbUseName.Value <> vbNullString Then

                    '@=======================
                    '@ ① 故障修理記録票登録/更新選択処理
                    '@ ② 保全記録票登録/更新選択処理
                    '@=======================
                    Call prvReportTrnJudge_Proc(lstrBeforeUseID, _
                                                lstrAfterUseID, _
                                                lstrEntryTime, _
                                                lstrEditTime, _
                                                lstrRepairNo, _
                                                lstrPreserveNo, _
                                                CMstrCmdRegistClick)

                End If

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)

                '@=======================
                '@ 最新情報取得処理
                '@=======================
                Call prvCmdSearch_Upd()

                '@作業ﾒﾓｸﾘｱ
                txtWorkMemo.Text = vbNullString

                '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmbMcGroup)

        '@↓2011/06/17 (Fri) 10:37:22 T.Oide **************************************************
        '@        '@=======================
        '@        '@ 表示記録票選択＆画面起動処理
        '@        '@=======================
        '@        Call prvDispReportJudge_Proc
        '@↑2011/06/17 (Fri) 10:37:22 T.Oide **************************************************

            Else
                '@結果：異常の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                Exit Sub
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = CMstrCmdRegistClick
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUseChange_Click
    '機　能：[装置状態変更]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/23 (Wed) 17:01:24 N.Kojima
    '更新日：2011/06/17 (Fri) 10:37:22 T.Oide
    '備　考：
    '　　　：2005/05/23 (Mon) 10:54:31 N.Kojima     SetFocus対応(OnErr処理追加、ｲﾍﾞﾝﾄ名称の定数化)
    '　　　：2005/12/19 (Mon) 15:56:41 N.Kojima     値取得列の明確化と送信ﾃﾞｰﾀの整合性ﾁｪｯｸを追加。(運用障害№653)
    '　　　：2005/12/22 (Thu) 11:56:42 N.Kasai      ﾒｯｾｰｼﾞ表示対応&搬送状態変更対応
    '　　　：2005/12/26 (Mon) 17:44:39 N.Kasai      搬送ﾎﾟｰﾄ変更ﾁｪｯｸ追加
    '　　　：2006/06/28 (Wed) 14:18:44 N.Kojima     ﾃﾞﾌｫﾙﾄ装置以外の装置の場合、ﾒｯｾｰｼﾞを表示するように改善。(ﾕｰｻﾞｰ要望№0192)
    '　　　：2007/02/01 (Thu) 15:31:56 N.Kojima     故障修理記録票登録処理を追加。(案件№01602)
    '　　　：2007/03/23 (Fri) 09:23:51 N.Kojima     故障修理記録票の登録日時をWP_EVENT_HISTORYのENTRY_TIMEで登録するように修正。(案件№01830)
    '　　　：2008/02/04 (Mon) 10:42:17 N.Kojima     計画保全対応。(案件№02332)
    '　　　：2011/06/17 (Fri) 10:37:22 T.Oide       保全記録表の自動起動中止(REQ-1160)
    Private Sub cmdUseChange_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUseChange.Click

        Dim lblnAns                     As Boolean          '結果取得(True:正常,False:異常)
        Dim lstrcmbUseName              As String           '状態変更名格納(ﾒｯｾｰｼﾞ用)
        Dim lstrlblUseName              As String           '状態変更名格納(ﾒｯｾｰｼﾞ用)
        Dim lstrClassDivision           As String           '処理区分
        Dim lstrBeforeMode              As String           '変更前運用ﾓｰﾄﾞ
        Dim lstrAfterMode               As String           '変更後運用ﾓｰﾄﾞ
        Dim lstrBeforeUseName           As String           '変更前装置状態
        Dim lstrAfterUseName            As String           '変更後装置状態
        Dim lstrNormalStateFlag         As String           '装置状態通常ﾌﾗｸﾞ
        Dim lstrMessageID               As String           'ﾒｯｾｰｼﾞID
        Dim llngWpIDValueCol            As Integer          '退避用装置名ｺﾝﾎﾞ値取得列
        Dim llngUseNameValueCol         As Integer          '退避用変更後ｺﾝﾎﾞ値取得列
        Dim lstrBeforeUseID             As String           '変更前装置状態ID
        Dim lstrAfterUseID              As String           '変更後装置状態ID
        Dim lstrRepairNo                As String           '故障修理記録票№
        Dim lstrPreserveNo              As String           '保全記録票№
        Dim lstrEditTime                As String           '更新(登録)日時
        Dim lstrEntryTime               As String           '登録日時(WP_EVENT_HISTORYの登録日時)

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の条件の場合は、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中の場合は処理を受付けない
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If

            '@ｴﾗｰ発生箇所の初期化
            ptypOnErrorInfo.strErrPositionDetail = vbNullString

            '@=======================
            '@ 確定前ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnCheck_Proc(CMstrCmdUseChangeClick)

            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                Exit Sub
            End If

            '@変更前運用ﾓｰﾄﾞ、変更前装置状態
            lstrBeforeMode = lblBeforeMode.Text
            lstrBeforeUseName = lblUseName.Text

            '@変更後運用ﾓｰﾄﾞ、変更後装置状態
            lstrAfterMode = vsfModeList.GetData(vsfModeList.Row, CMlngvsfColMode)
            lstrAfterUseName = cmbUseName.Text

            '@現在の「変更後装置状態ｺﾝﾎﾞ」の値取得列を退避
            llngUseNameValueCol = cmbUseName.ValueCol

            '@「変更後装置状態ｺﾝﾎﾞ」の値取得列を「状態ID(USE_ID)」列に設定(戻し処理は装置状態変更構造体へｾｯﾄ時)
            cmbUseName.ValueCol = CMlngCmbValueCol1
            mtypUsechange.strUseId = cmbUseName.Value                '変更後装置状態ID

            '@変更後装置状態IDを格納(故障修理記録票登録Function引数用)
            lstrAfterUseID = cmbUseName.Value

            '@=======================
            '@ 装置状態ﾒｯｾｰｼﾞ表示処理
            '@=======================
            lblnAns = prvblnMessage_Chk(mtypUsechange.strUseId, _
                                        lstrNormalStateFlag, _
                                        lstrMessageID)

            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                Exit Sub
            End If

            '@***********************
            '@ 要求ﾃﾞｰﾀ作成
            '@***********************
            With mtypUsechange

                .strWpID = cmbWp.Value                      '装置ID
                .strWpName = cmbWp.Text                     '装置名
                .strComments = txtWorkMemo.Text             'ｺﾒﾝﾄ

                llngWpIDValueCol = cmbWp.ValueCol           '装置名ｺﾝﾎﾞのValueCol値を退避
                cmbWp.ValueCol = CMlngCmbValueCol2          '装置名ｺﾝﾎﾞのValueCol値を"状態ID"列に設定
                .strOldUseID = cmbWp.Value                  '変更前装置状態ID
                lstrBeforeUseID = cmbWp.Value               '変更前装置状態ID(故障修理記録票登録Function引数用)
                cmbWp.ValueCol = llngWpIDValueCol           '装置名ｺﾝﾎﾞのValueCol値を変更前の値に戻す

                cmbUseName.ValueCol = CMlngCmbValueCol3     '変更後装置状態ｺﾝﾎﾞのValueCol値を"停止ﾌﾗｸﾞ"列に設定
                .strWpStopFlag = cmbUseName.Value           '停止ﾌﾗｸﾞ
                cmbUseName.ValueCol = llngUseNameValueCol   '変更後装置状態ｺﾝﾎﾞのValueCol値を変更前の値に戻す

                '@ｺﾝﾎﾞの値(Value)を取得してMsg送信している項目はﾁｪｯｸする
                '@装置ID,変更前状態ID,変更後状態ID,停止ﾌﾗｸﾞ,装置名
                If .strWpID = vbNullString Or _
                    .strOldUseID = vbNullString Or _
                    .strUseId = vbNullString Or _
                    .strWpStopFlag = vbNullString Or _
                    .strWpName = vbNullString Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRMY2W>$$軽微なシステムエラーが発生しました。$再度処理を実行し、
                    '@　このエラーメッセージが表示された場合は、$システム担当者に連絡してください。"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar00Y2)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    Exit Sub
                End If
            End With

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdUseChangeClick)

            With mtypUsechange

                '@処理区分に"0"(変更要求)ｾｯﾄ
                lstrClassDivision = CMstrClassDivision0

                .strMessageID = lstrMessageID       'ﾒｯｾｰｼﾞID

                '@【装置状態変更登録】ﾒｯｾｰｼﾞ送受信処理(最終更新日時は、確定時に返される値を使う。)
                lblnAns = pubblnEqChguse_Ins(CMstreq__chguse__Ver, _
                                             lstrEntryTime, _
                                             mtypUsechange, _
                                             lstrClassDivision)

                '@通信結果判定
                If lblnAns = True Then
                    '@結果：正常の場合

                    '@装置状態名を格納
                    lstrlblUseName = lblUseName.Text        '変更前
                    lstrcmbUseName = cmbUseName.Text        '変更後

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM26I>$$装置状態を変更しました。装置[%1] (%2 → %3)"」をｽﾃｰﾀｽﾊﾞｰに表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0026, .strWpName, lstrlblUseName, lstrcmbUseName)
                    Call pubVsfInfo_Disp(pstrDMsg)

                    '@過去にMetaの描画が追いつかず、装置状態IDがNULLで送信されてしまったｹｰｽがあったので、ｴﾗｰﾄﾗｯﾌﾟを仕掛ける
                    If cmbUseName.Value <> vbNullString Then

                        '@=======================
                        '@ ① 故障修理記録票登録/更新選択処理
                        '@ ② 保全記録票登録/更新選択処理
                        '@=======================
                        Call prvReportTrnJudge_Proc(lstrBeforeUseID, _
                                                    lstrAfterUseID, _
                                                    lstrEntryTime, _
                                                    lstrEditTime, _
                                                    lstrRepairNo, _
                                                    lstrPreserveNo, _
                                                    CMstrCmdUseChangeClick)

                    End If

                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrCmdUseChangeClick)

                    '@=======================
                    '@ 最新情報取得処理
                    '@=======================
                    Call prvCmdSearch_Upd()

                    '@変更後の装置状態を現在の装置状態に表示
                    lblUseName.Text = mtypEqstate.strUseName

                    '@変更後状態ｺﾝﾎﾞの初期化
                    cmbUseName.ListIndex = -1

                    '@ﾒｯｾｰｼﾞﾁｪｯｸﾎﾞｯｸｽ使用不可
                    With chkMessage
                        .Checked = False
                        .Enabled = False
                    End With

                    '@作業ﾒﾓｸﾘｱ
                    txtWorkMemo.Text = vbNullString

                    '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞにｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmbMcGroup)

        '@↓2011/06/17 (Fri) 10:37:22 T.Oide **************************************************
        '@            '@=======================
        '@            '@ 表示記録票選択＆画面起動処理
        '@            '@=======================
        '@            Call prvDispReportJudge_Proc
        '@↑2011/06/17 (Fri) 10:37:22 T.Oide **************************************************

                Else
                    '@結果：異常の場合

                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdUseChangeClick)
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = CMstrCmdUseChangeClick
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdChangeChamber_Click
    '機　能：[処理部用途/状態変更]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/11/20 (Mon) 14:46:11 N.Kasai
    '更新日：2006/11/20 (Mon) 14:46:11
    '備　考：
    Private Sub cmdChangeChamber_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdChangeChamber.Click

        Dim lblnAns                         As Boolean                  '結果取得(True:正常,False:異常)
        Dim ltypChgWpProcessingUseReq       As ChgWpProcessingUseReq    '要求格納構造体(装置処理部用途変更要求)
        Dim lstrMsgWk                       As String                   '成功ﾒｯｾｰｼﾞ内容を格納
        Dim llngCnt                         As Integer                  'ｶｳﾝﾀ
        Dim llngCmbWPBeforeValueCol         As Integer                  '変更前ValueCol値格納用

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の条件の場合は、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中の場合は処理を受付けない
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If

            '@=======================
            '@ ﾎﾞﾀﾝの使用可否ﾁｪｯｸ
            '@=======================
            lblnAns = prvblnCmdChangeChamber_Chk

            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                Exit Sub
            End If

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If

            '@成功ﾒｯｾｰｼﾞ用変数初期化
            lstrMsgWk = vbNullString
            lstrMsgWk = CMstrWpName & CPstrBracketLeft & cmbWp.Text & CPstrBracketRight   '対象装置名(和名)を格納

            '@要求ﾃﾞｰﾀ格納
            With ltypChgWpProcessingUseReq

                .strMsgVer = CMstreq__wpprocessinguseVer            'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strSbID = pstrSBID                                 '処理区分
                .strComments = txtWorkMemo.Text                     '作業ﾒﾓ
                .strEmpID = pstrUserID                              '作業者ID

                llngCmbWPBeforeValueCol = cmbWp.ValueCol            '装置名ｺﾝﾎﾞのValueCol値を退避
                cmbWp.ValueCol = CMlngCmbValueCol1                  '装置名ｺﾝﾎﾞのValueCol値を"装置ID"列に設定
                .strWpID = cmbWp.Value                              '装置ID
                cmbWp.ValueCol = llngCmbWPBeforeValueCol            '装置名ｺﾝﾎﾞのValueCol値を変更前の値に戻す

                '@ﾘｽﾄｶｳﾝﾄ
                .lngProcessingUseListCnt = vsfChamberList.Rows.Count - 1
                '@ﾃﾞｰﾀ件数のﾁｪｯｸ
                If .lngProcessingUseListCnt > 0 Then

                    '@配列の要素数を設定
                    .typProcessingUseList = New List(Of ProcessingUseList)(.lngProcessingUseListCnt)

                    '@装置処理部用途状態ﾘｽﾄ取得
                    For llngCnt = 1 To .lngProcessingUseListCnt
                        Dim ltypProcessingUseListTmp As New ProcessingUseList

                        '@ﾃﾞｰﾀ格納
                        ltypProcessingUseListTmp.strNo = vsfChamberList.GetData(llngCnt, CMlngvsfCColNo)                     'ﾁｬﾝﾊﾞｰ№
                        ltypProcessingUseListTmp.strChamberId = vsfChamberList.GetData(llngCnt, CMlngvsfCColChamberID)       'ﾁｬﾝﾊﾞｰID
                        ltypProcessingUseListTmp.strChamberUseId = vsfChamberList.GetData(llngCnt, CMlngvsfCColUseName)      'ﾁｬﾝﾊﾞｰ状態
                        ltypProcessingUseListTmp.strOldChamberId = vsfChamberList.GetData(llngCnt, CMlngvsfCColOldChamberID) '変更前ﾁｬﾝﾊﾞｰ状態
                        ltypProcessingUseListTmp.strOldChamberUseId = vsfChamberList.GetData(llngCnt, CMlngvsfCColOldUseID)  '変更前ﾁｬﾝﾊﾞｰID
                        ltypProcessingUseListTmp.strEditTime = vsfChamberList.GetData(llngCnt, CMlngvsfCColEditTime)         '更新日時

                        .typProcessingUseList.Add(ltypProcessingUseListTmp)
                    Next llngCnt
                End If
            End With

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdChangeChamberClick)

            '@【装置処理部用途変更】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnChgWpProcessingUse_Upd(ltypChgWpProcessingUseReq)

            '@通信結果判定
            If lblnAns = True Then
                '@結果：正常の場合

                '@「"<TRM6OI>$$処理部用途／状態変更しました。"」をｽﾃｰﾀｽﾊﾞｰに表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006O, lstrMsgWk)
                Call pubVsfInfo_Disp(pstrDMsg)

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdChangeChamberClick)

                '@=======================
                '@ 最新情報取得処理
                '@=======================
                Call prvCmdSearch_Upd()

                '@変更後の装置状態を現在の装置状態に表示
                lblUseName.Text = mtypEqstate.strUseName

                '@変更後状態ｺﾝﾎﾞの初期化
                cmbUseName.ListIndex = -1

                '@ﾒｯｾｰｼﾞﾁｪｯｸﾎﾞｯｸｽ使用不可
                With chkMessage
                    .Checked = False
                    .Enabled = False
                End With

                '@作業ﾒﾓｸﾘｱ
                txtWorkMemo.Text = vbNullString
            Else
                '@結果：異常の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdChangeChamberClick)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdChangeChamber_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdExecution_Click
    '機　能：[強制M1変更]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 10:19:00 N.Kojima
    '更新日：2011/06/17 (Fri) 10:37:22 T.Oide
    '備　考：
    '　　　：2004/08/26 (Thu) 10:19:00 N.Kojima     強制M1変更ﾎﾞﾀﾝ追加に伴う処理の追加。
    '　　　：2004/09/08 (Wed) 18:34:45 N.Kasai　    ﾒｯｾｰｼﾞBOX表示追加
    '　　　：2004/10/25 (Mon) 11:04:42 S.Deguchi    強制M1実行後の初期化処理を削除し,最新取得処理を追加
    '　　　：2005/02/21 (Mon) 14:55:52 N.Kojima     強制M1移行処理と装置状態変更処理を同時に行う。(改善№524、525)
    '　　　：2005/05/19 (Thu) 13:11:09 N.Kojima     SetFocus対応(OnErr処理追加、ｲﾍﾞﾝﾄ名称の定数化)
    '　　　：2005/12/19 (Mon) 15:56:41 N.Kojima     値取得列の明確化と送信ﾃﾞｰﾀの整合性ﾁｪｯｸを追加。(運用障害№653)
    '　　　：2006/06/28 (Wed) 14:10:36 N.Kojima     ﾃﾞﾌｫﾙﾄ装置以外の装置の場合、ﾒｯｾｰｼﾞを表示するように改善。(ﾕｰｻﾞｰ要望№0192)
    '　　　：2007/02/01 (Thu) 15:30:36 N.Kojima     故障修理記録票登録処理を追加。(案件№01602)
    '　　　：2007/03/23 (Fri) 10:00:59 N.Kojima     故障修理記録票の登録日時をWP_EVENT_HISTORYのENTRY_TIMEで登録するように修正。(案件№01830)
    '　　　：2008/02/07 (Thu) 14:07:16 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    '　　　：2011/06/17 (Fri) 10:37:22 T.Oide       保全記録表の自動起動中止(REQ-1160)
    Private Sub cmdExecution_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdExecution.Click

        Dim lblnAns                     As Boolean              '結果格納
        Dim ltypEqChgMode               As EqChgMode            'ﾓｰﾄﾞ変更構造体
        Dim lstrBeforeMode              As String               '強制M1前運用ﾓｰﾄﾞ
        Dim lstrAfterMode               As String               '変更後運用ﾓｰﾄﾞ
        Dim lstrBeforeUseName           As String               '変更前装置状態
        Dim lstrAfterUseName            As String               '変更後装置状態
        Dim lstrNormalStateFlag         As String               '装置状態通常ﾌﾗｸﾞ
        Dim lstrMessageID               As String               'ﾒｯｾｰｼﾞID
        Dim llngAns                     As Integer              '要求確認
        Dim llngWpIDValueCol            As Integer              '退避用装置名ｺﾝﾎﾞ値取得列
        Dim llngUseNameValueCol         As Integer              '退避用変更後ｺﾝﾎﾞ値取得列
        Dim lstrBeforeUseID             As String               '変更前装置状態ID
        Dim lstrAfterUseID              As String               '変更後装置状態ID
        Dim lstrRepairNo                As String               '故障修理記録票№
        Dim lstrPreserveNo              As String               '保全記録票№
        Dim lstrEditTime                As String               '更新(登録)日時
        Dim lstrEntryTime               As String               '登録日時(WP_EVENT_HISTORYの登録日時)

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の条件の場合は、処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合は処理を受付けない
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If

            '@ｴﾗｰ発生箇所の初期化
            ptypOnErrorInfo.strErrPositionDetail = vbNullString

            '@=======================
            '@ 入力(選択)項目ﾁｪｯｸ
            '@=======================
            lblnAns = prvblnCheck_Proc(CMstrCmdExecutionClick)

            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                Exit Sub
            End If

            '@表示ﾒｯｾｰｼﾞ変換
            '@「"<TRM2DW>$$強制的に運用モードを変更します。$$[装置が稼動していない事]、
            '@　[offlineである事]を確認の上、実行して下さい。"」の確認ﾒｯｾｰｼﾞ表示
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002D, cmbWp.Text, lblBeforeMode.Text, CMstrModeM1)
            llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

            '@要求確認
            If llngAns = vbNo Then
                '@処理しない
                Exit Sub
            End If

            '@現在の「変更後装置状態ｺﾝﾎﾞ」の値取得列を退避
            llngUseNameValueCol = cmbUseName.ValueCol

            '@「変更後装置状態ｺﾝﾎﾞ」の値取得列を「状態ID(USE_ID)」列に設定
            cmbUseName.ValueCol = CMlngCmbValueCol1
            ltypEqChgMode.strUseId = cmbUseName.Value       '変更後装置状態ID
            lstrAfterUseID = cmbUseName.Value               '変更後装置状態ID(故障修理記録票登録Function引数用)

            '@=======================
            '@ 装置状態ﾒｯｾｰｼﾞ表示処理
            '@=======================
            lblnAns = prvblnMessage_Chk(ltypEqChgMode.strUseId, lstrNormalStateFlag, lstrMessageID)

            '@処理結果判定
            If lblnAns = False Then
                '@結果：正常の場合
                Exit Sub
            End If

            '@強制M1前の運用ﾓｰﾄﾞ、変更前装置状態
            lstrBeforeMode = lblBeforeMode.Text
            lstrBeforeUseName = lblUseName.Text

            '@変更後運用ﾓｰﾄﾞ(M1)、変更後装置状態
            lstrAfterMode = CMstrModeM1
            lstrAfterUseName = cmbUseName.Text

            '@***********************
            '@ 要求ﾃﾞｰﾀ作成
            '@***********************
            With ltypEqChgMode

                .strWpID = cmbWp.Value                    'Wp_ID

                llngWpIDValueCol = cmbWp.ValueCol         '装置名ｺﾝﾎﾞのValueCol値を退避
                cmbWp.ValueCol = CMlngCmbValueCol2        '装置名ｺﾝﾎﾞのValueCol値を"状態ID"格納列に変更
                .strOldUseID = cmbWp.Value                '変更前装置状態ID
                lstrBeforeUseID = cmbWp.Value             '変更前装置状態ID(故障修理記録票登録Function引数用)
                cmbWp.ValueCol = llngWpIDValueCol         '装置名ｺﾝﾎﾞのValueCol値を戻す

                cmbUseName.ValueCol = CMlngCmbValueCol3     '変更後装置状態ｺﾝﾎﾞのValueCol値を「停止ﾌﾗｸﾞ」列に設定
                .strWpStopFlag = cmbUseName.Value           '停止ﾌﾗｸﾞ
                cmbUseName.ValueCol = llngUseNameValueCol   '変更後装置状態ｺﾝﾎﾞのValueCol値を変更前の値に戻す

                .strMesModeId = CMstrModeM1                 '変更ﾓｰﾄﾞ(MESﾓｰﾄﾞ："M1"固定)
                .strComments = txtWorkMemo.Text             '作業ﾒﾓ
                .strMsgVer = CMstreq__emgchgmodeVer         'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMessageID = lstrMessageID               'ﾒｯｾｰｼﾞID

                '@ｺﾝﾎﾞの値(Value)を取得してMsg送信している項目はﾁｪｯｸする
                '@装置ID,変更前状態ID,変更後状態ID,停止ﾌﾗｸﾞ
                If .strWpID = vbNullString Or _
                    .strOldUseID = vbNullString Or _
                    .strUseId = vbNullString Or _
                    .strWpStopFlag = vbNullString Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRMY2W>$$軽微なシステムエラーが発生しました。$再度処理を実行し、
                    '@　このエラーメッセージが表示された場合は、$システム担当者に連絡してください。"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar00Y2)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    Exit Sub
                End If
            End With

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
            If pstrUserID = vbNullString Then
                '@未入力の場合、投入中止
                Exit Sub
            End If

            ltypEqChgMode.strEmpID = pstrUserID                      '作業者ID

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdExecutionClick)


            '@【運用モード強制変更要求(強制M1変更)】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnEqEmgChgMode_Upd(ltypEqChgMode, _
                                             lstrEntryTime)


            '@通信結果格納
            If lblnAns = True Then
                '@結果：正常の場合

                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM4FI>$$装置[%1]の運用モードを[%2]から[%3]、装置状態を[%4]から[%5]へ変更しました。"」をｽﾃｰﾀｽﾊﾞｰに表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004F, cmbWp.Text, lstrBeforeMode, lstrAfterMode, lstrBeforeUseName, lstrAfterUseName)
                Call pubVsfInfo_Disp(pstrDMsg)


                '@過去にMetaの描画が追いつかず、装置状態IDがNULLで送信されてしまったｹｰｽがあったので、ｴﾗｰﾄﾗｯﾌﾟを仕掛ける
                If cmbUseName.Value <> vbNullString Then

                    '@=======================
                    '@ ① 故障修理記録票登録/更新選択処理
                    '@ ② 保全記録票登録/更新選択処理
                    '@=======================
                    Call prvReportTrnJudge_Proc(lstrBeforeUseID, _
                                                lstrAfterUseID, _
                                                lstrEntryTime, _
                                                lstrEditTime, _
                                                lstrRepairNo, _
                                                lstrPreserveNo, _
                                                CMstrCmdExecutionClick)

                End If

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdExecutionClick)

                '@=======================
                '@ 最新情報取得処理
                '@=======================
                Call prvCmdSearch_Upd()

                '@作業ﾒﾓｸﾘｱ
                txtWorkMemo.Text = vbNullString

                '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞにｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(cmbMcGroup)

        '@↓2011/06/17 (Fri) 10:37:22 T.Oide **************************************************
        '@        '@=======================
        '@        '@ 表示記録票選択＆画面起動処理
        '@        '@=======================
        '@        Call prvDispReportJudge_Proc
        '@↑2011/06/17 (Fri) 10:37:22 T.Oide **************************************************

            Else
                '@結果：異常の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdExecutionClick)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = CMstrCmdExecutionClick
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdChangeTrnst_Click
    '機　能：[搬送ﾎﾟｰﾄ変更]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/21 (Wed) 16:09:34 N.Kasai
    '更新日：2005/12/21 (Wed) 16:09:34
    '備　考：
    Private Sub cmdChangeTrnst_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdChangeTrnst.Click

        Dim lblnAns                     As Boolean          '結果取得(True:正常,False:異常)
        Dim ltypChgtrnstatReq           As ChgtrnstatReq    '要求格納構造体(搬送ﾎﾟｰﾄ有効・無効変更要求)
        Dim llngCnt                     As Integer          'ｶｳﾝﾀ
        Dim lstrMsgWk                   As String           '成功ﾒｯｾｰｼﾞ内容を格納

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の条件の場合は、処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合は処理を受付けない
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If

            '@=======================
            '@ ﾎﾞﾀﾝの使用可否ﾁｪｯｸ
            '@=======================
            lblnAns = prvblnCmdChangeTrnst_Chk()

            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                Exit Sub
            End If

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If

            '@成功ﾒｯｾｰｼﾞ内容
            lstrMsgWk = vbNullString    '初期化
            lstrMsgWk = CMstrWpName & CPstrBracketLeft & cmbWp.Text & CPstrBracketRight   '対象装置名(和名)を格納

            '@***********************
            '@ 要求ﾃﾞｰﾀ作成
            '@***********************
            With ltypChgtrnstatReq

                .strMsgVer = CMstreq__chgtrnstatVer         'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strComments = txtWorkMemo.Text             '作業ﾒﾓ
                .strEmpID = pstrUserID                      '作業者ID

                cmbWp.ValueCol = CMlngCmbValueCol1        '装置名ｺﾝﾎﾞのValueCol値を"装置ID"列に設定
                .strWpID = cmbWp.Value                    '装置ID

                '@ﾎﾟｰﾄﾘｽﾄｶｳﾝﾄ
                .llngtrnportListCnt = vsfPortNoList.Rows.Count - 1
                '@ﾃﾞｰﾀ件数のﾁｪｯｸ
                If .llngtrnportListCnt > 0 Then

                    '@配列の要素数を設定
                    .typtrnportList = New List(Of trnportList)(.llngtrnportListCnt)

                    '@ﾎﾟｰﾄﾘｽﾄ取得(ﾎﾟｰﾄ№、搬送状態)
                    For llngCnt = 1 To .llngtrnportListCnt
                        Dim ltyptrnportListTmp As New trnportList

                        '@ﾃﾞｰﾀ格納
                        ltyptrnportListTmp.strPortID = vsfPortNoList.GetData(llngCnt, CMlngvsfLColNo)
                        ltyptrnportListTmp.strTransServiceStatus = vsfPortNoList.GetData(llngCnt, CMlngvsfLColTransService)

                        '@成功ﾒｯｾｰｼﾞ内容格納
                        '@変更後(ｺﾝﾎﾞ内容)と変更前の状態を比較する。
                        '@変更された場合は成功ﾒｯｾｰｼﾞに変更内容を表示する為、内容を格納する。
                        If vsfPortNoList.GetData(llngCnt, CMlngvsfLColTransService) <> _
                            vsfPortNoList.GetData(llngCnt, CMlngvsfLColTransServiceID) Then

                            '@★ 自動搬送ｻｰﾋﾞｽ状態により処理分岐 ★
                            Select Case vsfPortNoList.GetData(llngCnt, CMlngvsfLColTransService)

                                '@〓 "0:可能" 〓
                                Case CMstrTransServiceStatusOK

                                    lstrMsgWk = lstrMsgWk & "(" & CMstrPortNo & _
                                        vsfPortNoList.GetData(llngCnt, CMlngvsfLColNo) & CMstrFromNgToOk & ")"

                                '@〓 "1:不可能" 〓
                                Case CMstrTransServiceStatusNG

                                    lstrMsgWk = lstrMsgWk & "(" & CMstrPortNo & _
                                        vsfPortNoList.GetData(llngCnt, CMlngvsfLColNo) & CMstrFromOkToNg & ")"

                            End Select
                        End If

                        .typtrnportList.Add(ltyptrnportListTmp)
                    Next llngCnt
                End If
            End With

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdChangeTrnstClick)

            '@【搬送ﾎﾟｰﾄ有効・無効変更要求】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnChgtrnstat_Upd(ltypChgtrnstatReq)

            '@通信結果判定
            If lblnAns = True Then
                '@結果：正常の場合

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdChangeTrnstClick)

                '@「"<TRM39I>$$搬送ポート状態を変更しました。%1"」をｽﾃｰﾀｽﾊﾞｰに表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0039, lstrMsgWk)
                Call pubVsfInfo_Disp(pstrDMsg)

                '@=======================
                '@ 最新情報取得処理
                '@=======================
                Call prvCmdSearch_Upd()

                '@変更後の装置状態を現在の装置状態に表示
                lblUseName.Text = mtypEqstate.strUseName

                '@変更後状態ｺﾝﾎﾞの初期化
                cmbUseName.ListIndex = -1

                '@ﾒｯｾｰｼﾞﾁｪｯｸﾎﾞｯｸｽ使用不可
                With chkMessage
                    .Checked = False
                    .Enabled = False
                End With

                '@作業ﾒﾓｸﾘｱ
                txtWorkMemo.Text = vbNullString
            Else
                '@結果：異常の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdChangeTrnstClick)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = CMstrCmdChangeTrnstClick
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdChangeProcOrder_Click
    '機　能：[処理順指定変更]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/28 (Mon) 13:13:49 T.Kitagawa
    '更新日：2009/10/22 (Thu) 10:31:03 T.Oide
    '備　考：
    '　　　：2007/10/17 (Wed) 20:53:03 N.Kojima     処理順指定に"ﾚｼﾋﾟ(固定)"が追加になったことに伴い、処理追加。(案件№02152)
    '　　　：2008/02/26 (Tue) 14:32:47 M.Koni       表示ﾒｯｾｰｼﾞの不具合修正。(案件№02655)
    '　　　：2009/10/20 (Tue) 10:26:59 T.Oide       搬送ﾓｰﾄﾞ追加(案件№03761)
    Private Sub cmdChangeProcOrder_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdChangeProcOrder.Click

        Dim lblnAns                     As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypChgProcOrderReq         As EqChgProcOrderReq    '要求格納構造体(処理順変更要求)
        Dim lstrMsgWk                   As String               '成功ﾒｯｾｰｼﾞ内容を格納
        Dim lstrGuidMsg                 As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode             As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance            As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg
        Dim llngCnt                     As Integer              'ｶｳﾝﾀ
        Dim llngSelectCnt               As Integer              'ﾚｼﾋﾟｸﾞﾙｰﾌﾟ選択ｶｳﾝﾀ
        Dim lvrnTemp                    As Object               '一時保管用変数

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の条件の場合は、処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合は処理を受付けない
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If

            '@=======================
            '@ 処理順指定変更ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvCmdChangeProcOrderEnable_Set()

            '@処理順指定の最終確認判定
            If cmdChangeProcOrder.Enabled = False Then
                Exit Sub
            End If


            '@変更後処理順指定が「ﾚｼﾋﾟ(固定)」OR 「ﾚｼﾋﾟ(固定)限定」で、かつﾚｼﾋﾟｸﾞﾙｰﾌﾟが選択されている場合
            If (cmbRecipeFlow.Text = CPstrRecipeFlowGroup Or _
                cmbRecipeFlow.Text = CPstrRecipeFlowGroupSameNG) Then

                '@ﾚｼﾋﾟが1件以上選択されているか
                If Mid$(cmbRecipeGroup.Text, 1, 1) <> CPstrZero Then

                    '@選択ﾚｼﾋﾟｸﾞﾙｰﾌﾟの件数ﾁｪｯｸ
                    With ltypChgProcOrderReq

                        lvrnTemp = Split(cmbRecipeGroup.Value, vbTab)

                        For llngSelectCnt = LBound(lvrnTemp) To UBound(lvrnTemp)
                            '@件数ｶｳﾝﾄの為の空ﾙｰﾌﾟ処理
                        Next llngSelectCnt

                        '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟにﾁｪｯｸが30個以上付いている場合
                        If llngSelectCnt > CMstrMsgMaxSelectRecipeGroupNum Then

                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「"<TRM9HW>$$%1は最大%2までしか選択出来ません。$設定を見直してください。"」のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009H, CMstrMsgRecipeGroupName, CMstrMsgMaxSelectRecipeGroupNum)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟが有効か
                            If cmbRecipeGroup.Enabled = True Then

                                '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟにﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(cmbRecipeGroup)
                            Else
                                '@作業ﾒﾓにﾌｫｰｶｽｾｯﾄ
                                If txtWorkMemo.Enabled = True Then
                                    Call pubSetFocus(txtWorkMemo)
                                End If
                            End If

                            Exit Sub

                        End If
                    End With
                End If
            End If

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If

            '@表示用ﾒｯｾｰｼﾞ作成
            lstrMsgWk = CMstrWpName & CPstrBracketLeft & cmbWp.Text & CPstrBracketRight

            '@★ 現在の処理順指定により処理分岐 ★
            Select Case lblBeforeRecipeFlow.Text

                '@〓 ﾚｼﾋﾟ切替 〓
                Case CPstrRecipeFlowNum

                    '@「ﾚｼﾋﾟ切替」の場合"(レシピ毎：xxロット → "
                    lstrMsgWk = lstrMsgWk & CPstrParenthesisLeft & CPstrRecipeFlowNum & CMstrMsgColon & _
                                Format$(CInt(lblBeforeRecipeFlowNum.Text), CPstrNoKanmaFormat) & CMstrMsgLotName & CMstrMsgRightDirection

                '@〓 ﾚｼﾋﾟ切替(限定) 〓
                Case CPstrRecipeFlowNumSameNG

                    '@「ﾚｼﾋﾟ切替」の場合"(レシピ毎限定：xxロット → "
                    lstrMsgWk = lstrMsgWk & CPstrParenthesisLeft & CPstrRecipeFlowNumSameNG & CMstrMsgColon & _
                                Format$(CInt(lblBeforeRecipeFlowNum.Text), CPstrNoKanmaFormat) & CMstrMsgLotName & CMstrMsgRightDirection

                '@〓 ﾚｼﾋﾟ固定 〓
                Case CPstrRecipeFlowGroup

                    '@「ﾚｼﾋﾟ固定」の場合"(ﾚｼﾋﾟ固定 → "
                    lstrMsgWk = lstrMsgWk & CPstrParenthesisLeft & CPstrRecipeFlowGroup & CMstrMsgRightDirection

                '@〓 ﾚｼﾋﾟ固定(限定) 〓
                Case CPstrRecipeFlowGroupSameNG

                    '@「ﾚｼﾋﾟ固定」の場合"(ﾚｼﾋﾟ固定限定 → "
                    lstrMsgWk = lstrMsgWk & CPstrParenthesisLeft & CPstrRecipeFlowGroupSameNG & CMstrMsgRightDirection

                '@〓 FIFO 〓
                Case CPstrRecipeFlowFifo

                    '@FIFO(到着順)の場合"(FIFO → "
                    lstrMsgWk = lstrMsgWk & CPstrParenthesisLeft & CPstrRecipeFlowFifo & CMstrMsgRightDirection

                '@〓 FIFO(限定) 〓
                Case CPstrRecipeFlowFifoSameNG

                    '@FIFO(到着順)の場合"(FIFO → "
                    lstrMsgWk = lstrMsgWk & CPstrParenthesisLeft & CPstrRecipeFlowFifoSameNG & CMstrMsgRightDirection

            End Select

            '@★ 変更後処理順指定により処理分岐 ★
            Select Case cmbRecipeFlow.Text

                '@〓 ﾚｼﾋﾟ切替 〓
                Case CPstrRecipeFlowNum

                    '@"lstrMsgWk + レシピ毎：NNロット)"
                    lstrMsgWk = lstrMsgWk & CPstrRecipeFlowNum & CMstrMsgColon & _
                                Format$(CInt(txtRecipeFlowNum.Text), CPstrNoKanmaFormat) & CMstrMsgLotName & CPstrParenthesisRight

                '@〓 ﾚｼﾋﾟ切替(限定) 〓
                Case CPstrRecipeFlowNumSameNG

                    '@"lstrMsgWk + レシピ毎：NNロット)"
                    lstrMsgWk = lstrMsgWk & CPstrRecipeFlowNumSameNG & CMstrMsgColon & _
                                Format$(CInt(txtRecipeFlowNum.Text), CPstrNoKanmaFormat) & CMstrMsgLotName & CPstrParenthesisRight

                '@〓 ﾚｼﾋﾟ固定 〓
                Case CPstrRecipeFlowGroup

                    '@"lstrMsgWk + ﾚｼﾋﾟ固定)"
                    lstrMsgWk = lstrMsgWk & CPstrRecipeFlowGroup & CPstrParenthesisRight

                '@〓 ﾚｼﾋﾟ固定(限定) 〓
                Case CPstrRecipeFlowGroupSameNG

                    '@"lstrMsgWk + ﾚｼﾋﾟ固定)"
                    lstrMsgWk = lstrMsgWk & CPstrRecipeFlowGroupSameNG & CPstrParenthesisRight

                '@〓 FIFO 〓
                Case CPstrRecipeFlowFifo

                    '@"lstrMsgWk + FIFO)"
                    lstrMsgWk = lstrMsgWk & CPstrRecipeFlowFifo & CPstrParenthesisRight

                '@〓 FIFO(限定) 〓
                Case CPstrRecipeFlowFifoSameNG

                    '@"lstrMsgWk + FIFO)"
                    lstrMsgWk = lstrMsgWk & CPstrRecipeFlowFifoSameNG & CPstrParenthesisRight

            End Select


            '@***********************
            '@ 要求ﾃﾞｰﾀ作成
            '@***********************
            With ltypChgProcOrderReq

                .strMsgVer = CMstreq__chgprocorderVer       'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                cmbWp.ValueCol = CMlngCmbValueCol1          '装置名ｺﾝﾎﾞのValueCol値を"装置ID"列に設定
                .strWpID = cmbWp.Value                      '装置ID
                .strEmpID = pstrUserID                      '作業者ID
                .strComments = txtWorkMemo.Text             '作業ﾒﾓ
                cmbRecipeFlow.ValueCol = 1
                .strCollectTypeFlg = cmbRecipeFlow.Value    'ｺﾚｸﾄﾀｲﾌﾟﾌﾗｸﾞ

                '@変更後処理順指定が「ﾚｼﾋﾟ(切替)」OR「ﾚｼﾋﾟ(切替)限定」か
                If cmbRecipeFlow.Value = CPlngNumRecipeFlowNum Or _
                    cmbRecipeFlow.Value = CPlngNumRecipeFlowNumSameNG Then
                    '@"ﾚｼﾋﾟ(切替)"の場合

                    '@変更後の処理ﾛｯﾄ数を設定
                    .strRecipeFlowNum = txtRecipeFlowNum.Text
                Else
                    '@「FIFO(到着順)」「FIFO(到着順)限定」、「ﾚｼﾋﾟ(切替)」「ﾚｼﾋﾟ(切替)限定」"の場合

                    '@処理ﾛｯﾄ数をｾﾞﾛ設定
                    .strRecipeFlowNum = CMlngRecipeFlowNumFifo      'ｾﾞﾛ固定
                End If

                '@変更後処理順指定が「ﾚｼﾋﾟ(固定)」OR「ﾚｼﾋﾟ(固定)限定」で、かつﾚｼﾋﾟｸﾞﾙｰﾌﾟが選択されている場合
                If (cmbRecipeFlow.Value = CPlngNumRecipeFlowGroup Or cmbRecipeFlow.Value = CPlngNumRecipeFlowGroupSameNG) And _
                    Mid$(cmbRecipeGroup.Text, 1, 1) <> CPstrZero Then

                    '@-----------------------
                    '@ 選択ﾚｼﾋﾟｸﾞﾙｰﾌﾟ格納
                    '@-----------------------
                    lvrnTemp = Split(cmbRecipeGroup.Value, vbTab)
                    .typCollectTypeList = New List(Of CollectTypeList)(llngSelectCnt)

                    For llngCnt = LBound(lvrnTemp) To UBound(lvrnTemp)
                        Dim ltypCollectTypeListTmp As New CollectTypeList

                        '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟにﾁｪｯｸされている項目を格納
                        ltypCollectTypeListTmp.strCollectTypeNum = lvrnTemp(llngCnt)      'ﾚｼﾋﾟｸﾞﾙｰﾌﾟ番号

                        .typCollectTypeList.Add(ltypCollectTypeListTmp)
                    Next llngCnt
                End If

                cmbRecipeFlow.ValueCol = 0

            End With

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdChangeProcOrderClick)

            '@【処理順指定変更要求】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnEqChgProcOrder_Upd(ltypChgProcOrderReq, _
                                               llngSelectCnt, _
                                               lstrGuidMsg, _
                                               lstrGuidMsgCode)

            '@通信結果判定
            If lblnAns = True Then
                '@結果：正常の場合

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdChangeProcOrderClick)

                '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞに値が入っている場合
                If lstrGuidMsgCode <> vbNullString Then

                    '@表示ｶﾞｲﾀﾞﾝｽMsgの編集("【警告】" & "$$" & "ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ[CODE]">" & "$$" & ｶﾞｲﾀﾞﾝｽMsg)
                    lstrEditGuidance = CPstrWarMsgCode & CPstrGuidanceMsg & CPstrMsgCrCode & _
                                       CPstrGuidanceCode & CPstrBracketLeft & lstrGuidMsgCode & CPstrBracketRight & _
                                       CPstrMsgCrCode & lstrGuidMsg

                    '@「上記の"編集済みｶﾞｲﾀﾞﾝｽMsg"」を表示
                    pstrDMsg = pubstrMsgReplace_Set(lstrEditGuidance)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                End If

                '@「"<TRM5YI>$$処理順指定を変更しました。%1"」をｽﾃｰﾀｽﾊﾞｰに表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf005Y, lstrMsgWk)
                Call pubVsfInfo_Disp(pstrDMsg)

                '@=======================
                '@ 最新情報取得処理
                '@=======================
                Call prvCmdSearch_Upd()

                '@変更後の装置状態を現在の装置状態に表示
                lblUseName.Text = mtypEqstate.strUseName

                '@変更後状態ｺﾝﾎﾞの初期化
                cmbUseName.ListIndex = -1

                '@ﾒｯｾｰｼﾞﾁｪｯｸﾎﾞｯｸｽ使用不可
                With chkMessage
                    .Checked = False
                    .Enabled = False
                End With

                '@作業ﾒﾓｸﾘｱ
                txtWorkMemo.Text = vbNullString

            Else
                '@結果：異常の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdChangeProcOrderClick)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = CMstrCmdChangeProcOrderClick
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCarrierUnload_Click
    '機　能：[ｷｬﾘｱ強制搬出]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/11/27 (Tue) 16:56:28 Y.Yoneyama
    '更新日：2007/11/27 (Tue) 16:56:28
    '備　考：
    Private Sub cmdCarrierUnload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCarrierUnload.Click

        Dim lblnAns                     As Boolean          '結果取得(True:正常,False:異常)
        Dim ltypEqCarUnloadReq          As EqCarUnloadReq   '要求格納構造体(搬送ﾎﾟｰﾄ有効・無効変更要求)
        Dim llngDoCnt                   As Integer          'ｶｳﾝﾀ

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の条件の場合は、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中の場合は処理を受付けない
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If

            '@***********************
            '@ 要求ﾃﾞｰﾀ作成
            '@***********************
            With ltypEqCarUnloadReq

                .strMsgVer = CMstreq__carunloadVer      'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strSbID = pstrSBID                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strEmpID = pstrUserID                  '作業者ID
                cmbWp.ValueCol = CMlngCmbValueCol1      '装置名ｺﾝﾎﾞのValueCol値を"装置ID"列に設定
                .strWpID = cmbWp.Value                  '装置ID

                '@ｶｳﾝﾀの初期化
                llngDoCnt = 1
                '@ﾎﾟｰﾄ分ﾙｰﾌﾟ
                Do While vsfPortNoList.Rows.Count > llngDoCnt

                    '@ｷｬﾘｱ強制搬出対象のﾎﾟｰﾄを見つける
                    If vsfPortNoList.GetCellCheck(llngDoCnt, CMlngvsfLColCarrierUnload) = CheckEnum.Checked Then

                        .strPortID = vsfPortNoList.GetData(llngDoCnt, CMlngvsfLColNo)              'ﾎﾟｰﾄID
                        .strCarrierId = vsfPortNoList.GetData(llngDoCnt, CMlngvsfLColCarrierID)    'ｷｬﾘｱID
                    End If

                    llngDoCnt = llngDoCnt + 1
                Loop
            End With

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdCarrierUnloadClick)


            '@【ｷｬﾘｱ強制搬出要求】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnEqCarUnload_Upd(ltypEqCarUnloadReq)


            '@通信結果判定
            If lblnAns = True Then
                '@結果：正常の場合

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdCarrierUnloadClick)

                '@「"<TRM38I>$$キャリア強制搬出を行いました。装置[%1] ポート[%2]"」をｽﾃｰﾀｽﾊﾞｰに表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0038, cmbWp.Text, ltypEqCarUnloadReq.strPortID)
                Call pubVsfInfo_Disp(pstrDMsg)

                '@=======================
                '@ 最新情報取得処理
                '@=======================
                Call prvCmdSearch_Upd()

                '@変更後の装置状態を現在の装置状態に表示
                lblUseName.Text = mtypEqstate.strUseName

                '@変更後状態ｺﾝﾎﾞの初期化
                cmbUseName.ListIndex = -1

                '@ﾒｯｾｰｼﾞﾁｪｯｸﾎﾞｯｸｽ使用不可
                With chkMessage
                    .Checked = False
                    .Enabled = False
                End With

                '@作業ﾒﾓｸﾘｱ
                txtWorkMemo.Text = vbNullString

            Else
                '@結果：異常の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdCarrierUnloadClick)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = CMstrCmdCarrierUnloadClick
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '関数名：prvFrmxxEN00C0_Init
    '機　能：ﾒｲﾝﾌｫｰﾑの初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/18 (Fri) 16:48:44 S.Deguchi
    '更新日：2007/10/15 (Mon) 11:58:00 N.Kojima
    '備　考：
    '　　　：2004/08/26 (Thu) 16:35:06 N.Kojima     強制M1ﾎﾞﾀﾝの初期化を追加(1129行目)。
    '　　　：2004/09/17 (Fri) 14:07:37 S.Deguchi    処理状態/稼動状態のﾗﾍﾞﾙを追加
    '　　　：2005/02/21 (Mon) 15:18:27 N.Kojima     追加ｺﾝﾄﾛｰﾙ(変更後装置状態等)の初期化を追加(改善№524、525)
    '　　　：2005/11/01 (Tue) 16:23:40 N.Kojima     追加ｺﾝﾄﾛｰﾙ(CH使用禁止ｺﾝﾎﾞ)の初期化を追加(ﾕｰｻﾞｰ要望№0094)
    '　　　：2005/12/16 (Fri) 11:33:23 N.Kasai      ﾒｯｾｰｼﾞﾁｪｯｸﾎﾞｯｸｽ追加
    '　　　：2005/12/21 (Wed) 15:12:03 N.Kasai      搬送ﾎﾟｰﾄ変更ﾎﾞﾀﾝ追加
    '　　　：2006/08/28 (Mon) 13:28:49 T.Kitagawa   ﾌｫﾄのTAT改善に伴う処理順指定追加(案件№01097)
    '　　　：2006/11/20 (Mon) 13:51:52 N.Kasai      処理部用途状態変更機能追加(№01433)
    '　　　：2007/10/15 (Mon) 11:58:00 N.Kojima     ﾚｼﾋﾟｸﾞﾙｰﾌﾟｺﾝﾎﾞの初期化処理追加。(案件№02152)
    Private Sub prvFrmxxEN00C0_Init()

        Dim lstrFormTitle       As String               'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        Dim llngNowByte         As Integer              '現在のﾊﾞｲﾄ数格納

        Try

            '@=======================
            '@ 機能関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00C0, lstrFormTitle)

            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle

            'NSYS コンボボックスの背景色が灰色になるため、白を設定
            cmbMcGroup.BackColor = SystemColors.Window
            cmbRecipeFlow.BackColor = SystemColors.Window
            cmbRecipeGroup.BackColor = SystemColors.Window
            cmbUseName.BackColor = SystemColors.Window
            cmbWp.BackColor = SystemColors.Window

            '@各ｺﾝﾎﾞの初期化
            cmbMcGroup.Clear        '装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ
            cmbWp.Clear             '装置名ｺﾝﾎﾞ
            cmbUseName.Clear        '変更後装置状態ｺﾝﾎﾞ

            '@変更後装置状態ｺﾝﾎﾞの初期化
            With cmbUseName

                .Clear
                .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridCol0                                      'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbValueCol1                                   '値取得列
                .DirectInput = False                                            'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                With .Font                                                      'ﾌｫﾝﾄｻｲｽﾞ
                    cmbUseName.Font = New Font(.FontFamily, CMlngCmbFontSize, .Style, _
                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                With .GridFont                                                  'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    cmbUseName.GridFont = New Font(.FontFamily, CMlngCmbGridFontSize, .Style, _
                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .RowHeight = CMlngCmbRowHeight                                  '行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左中央揃え
            End With

            '@各ｺﾝﾎﾞの無効化
            cmbWp.Enabled = False       '装置名ｺﾝﾎﾞ
            cmbUseName.Enabled = False  '変更後装置状態ｺﾝﾎﾞ

            '@各ﾗﾍﾞﾙの初期化
            lblM1AfterMode.Text = vbNullString           '運用状態
            lblNowDate.Text = vbNullString               '情報取得日時
            lblUseName.Text = vbNullString               '現在の装置状態
            lblWpStatusName.Text = vbNullString          '処理状態
            lblBeforeMode.Text = vbNullString            '現在の運用ﾓｰﾄﾞ
            lblBeforeRecipeFlow.Text = vbNullString      '現在の処理順指定
            lblBeforeRecipeFlowNum.Text = vbNullString   '現在の処理順ﾛｯﾄ数

            '@変更後処理順ｺﾝﾎﾞの初期化
            With cmbRecipeFlow

                .Clear
                .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridCol0                                      'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridCol0                                    '値取得列
                .DirectInput = False                                            'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                With .Font                                                      'ﾌｫﾝﾄｻｲｽﾞ
                    cmbRecipeFlow.Font = New Font(.FontFamily, CMlngCmbFontSize, .Style, _
                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                With .GridFont                                                  'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    cmbRecipeFlow.GridFont = New Font(.FontFamily, CMlngCmbGridFontSize, .Style, _
                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .RowHeight = CMlngCmbRowHeight                                  '行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左中央揃え
                .BackColor = SystemColors.ControlLight                          '灰色
                .Enabled = False                                                '使用不可

                '@初期値設定
                .ListIndex = -1
                .Text = vbNullString
            End With

            '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟｺﾝﾎﾞの初期化
            With cmbRecipeGroup

                .Clear
                .DirectInput = False                                            '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol1                                   'ｸﾞﾘｯﾄﾞ値取得列数
                .GroupCols = CMlngCmbGroupCols                                  '列方向のﾚｺｰﾄﾞ数
                .GroupRows = CMlngCmbGroupCols                                  '行方向のﾚｺｰﾄﾞ数
                .AddedComment = CMstrCmbAddedComment                            '"選択"文字列
                With .Font                                                      'ﾌｫﾝﾄｻｲｽﾞ
                    cmbRecipeGroup.Font = New Font(.FontFamily, CMlngCmbFontSize, .Style, _
                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                With .GridFont                                                  'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    cmbRecipeGroup.GridFont = New Font(.FontFamily, CMlngCmbGridFontSize, .Style, _
                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .BackColor = SystemColors.ControlLight                          '灰色
                .Enabled = False                                                '使用不可
            End With

            '@処理ﾛｯﾄ数ﾃｷｽﾄの初期化
            With txtRecipeFlowNum
                .Text = vbNullString                    'NULL
                .BackColor = SystemColors.ControlLight  '灰色
                .Enabled = False                        '無効
            End With

            '@作業ﾒﾓﾃｷｽﾄの初期化
            With txtWorkMemo

                .ChrMaxByte = CPlngLotCommentsMaxByte   '最大入力文字数
                .Text = vbNullString                    'NULL
                llngNowByte = .NowByte                  '現状のﾊﾞｲﾄ数を格納

                '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                lblReleaseLengthCount.Text _
                    = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
                
                .Enabled = False                        '無効
            End With

            '@作業ﾒﾓﾃｷｽﾄ用、上下ｽｸﾛｰﾙﾎﾞﾀﾝの初期化
            cmdWorkMemoUp.Enabled = False           '上
            cmdWorkMemoDown.Enabled = False         '下

            '@各ﾎﾞﾀﾝの初期化
            cmdSearch.Enabled = False               '最新取得ﾎﾞﾀﾝ
            cmdRegist.Enabled = False               'ﾓｰﾄﾞ移行ﾎﾞﾀﾝ
            cmdExecution.Enabled = False            '強制M1変更ﾎﾞﾀﾝ
            cmdUseChange.Enabled = False            '装置状態変更
            cmdChangeTrnst.Enabled = False          '搬送ﾎﾟｰﾄ変更
            cmdChangeProcOrder.Enabled = False      '処理順指定変更

            '@装置ﾎﾟｰﾄ状態一覧ｸﾞﾘｯﾄﾞ用、上下ｽｸﾛｰﾙﾎﾞﾀﾝの初期化
            cmdUP.Enabled = False                   '上
            cmdDown.Enabled = False                 '下

            '@ﾒｯｾｰｼﾞﾁｪｯｸﾎﾞｯｸｽ(使用不可)
            With chkMessage
                .Checked = False
                .Enabled = False
            End With

            '@各ﾓｼﾞｭｰﾙ変数の初期化
            mstrMcGroupID = vbNullString            '装置ｸﾞﾙｰﾌﾟID退避用
            mstrWpID = vbNullString                 '装置ID退避用
            mlngUseListCnt = 0                      '装置状態ｺﾝﾎﾞｶｳﾝﾄ
            mlngSelectRecipeGroupCnt = 0            'ﾚｼﾋﾟｸﾞﾙｰﾌﾟ選択数格納用
            mstrSelectRecipeCnt = 0                 'ﾚｼﾋﾟｸﾞﾙｰﾌﾟ選択数格納用(文字)
            mblnRecipeGroupEditCancelFlag = False   'ﾚｼﾋﾟｸﾞﾙｰﾌﾟ編集ｷｬﾝｾﾙﾌﾗｸﾞ(True:編集しない、False:編集する)

            '@=======================
            '@ 装置ﾎﾟｰﾄ状態一覧ｸﾞﾘｯﾄﾞの初期化処理
            '@=======================
            Call prvVsfPortNoList_Init()

            '@=======================
            '@ 運用ﾓｰﾄﾞ一覧ｸﾞﾘｯﾄﾞの初期化処理
            '@=======================
            Call prvVsfModeList_Init()

            '@=======================
            '@ 装置処理部用途/状態一覧ｸﾞﾘｯﾄﾞの初期化処理
            '@=======================
            Call prvVsfChamberList_Init()

            '@装置処理部用途/状態一覧ｸﾞﾘｯﾄﾞ用、上下ｽｸﾛｰﾙﾎﾞﾀﾝの初期化
            cmdChamberUP.Enabled = False
            cmdChamberDown.Enabled = False

            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN00C0_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfPortNoList_Init
    '機　能：装置ﾎﾟｰﾄ状態一覧ｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/21 (Mon) 11:25:24 S.Deguchi
    '更新日：2006/10/17 (Tue) 15:51:57 M.Miura
    '備　考：
    '　　　：2004/12/15 (Wed) 16:22:08 S.Deguchi    自動搬送対応
    '　　　：2005/12/22 (Thu) 12:59:07 N.Kasai      搬送ﾎﾟｰﾄ変更ﾎﾞﾀﾝ制御追加
    '　　　：2005/12/26 (Mon) 17:18:00 N.Kasai      描画設定を追加
    '　　　：2006/10/17 (Tue) 15:51:57 M.Miura      画面のﾗﾍﾞﾙ背景色の(赤/青)ちらつき修正(案件№01570)
    Private Sub prvVsfPortNoList_Init()

        Try

            With vsfPortNoList

                .Redraw = False                     '直接描画しない
                .AllowSorting = False               'ｿｰﾄなし
                .Rows.Count = .Rows.Fixed           '初期行数設定
                .SelectionMode = SelectionModeEnum.Cell
                .HighLight = HighLightEnum.Never    'ﾊｲﾗｲﾄ表示なし
                .FocusRect = FocusRectEnum.Light    'ﾌｫｰｶｽ枠のｽﾀｲﾙを設定

                '@ﾎﾟｰﾄ状態IDを非表示設定
                .Cols(CMlngvsfLColStatusID).Visible = False
                .Cols(CMlngvsfLColTransServiceID).Visible = False

                '@一覧表の表題設定
                .Select(CMlngVsfRowTitle, CMlngvsfLColNo, CMlngVsfRowTitle, .Cols.Count - 1)
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.ForeColor = Color.Yellow                       '文字色
                lFixedStyle.BackColor = lblMcGroupNameTitle.BackColor      '背景色(周りの背景色に合せる)
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter
                With .Font                                                 'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                    lFixedStyle.Font = New Font(.FontFamily, CMlngVsfHFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With

                '@列幅、ﾀｲﾄﾙ設定
                .Cols(CMlngvsfLColNo).Width = CMlngvsfLColWPortNo
                .SetData(CMlngVsfRowTitle, CMlngvsfLColNo, CMstrvsfLColPortNo)                        'PortNo.

                .Cols(CMlngvsfLColUsage).Width = CMlngvsfLColWUsage
                .SetData(CMlngVsfRowTitle, CMlngvsfLColUsage, CMstrvsfLColUsage)                      '用途

                .Cols(CMlngvsfLColStatus).Width = CMlngvsfLColWStatusP
                .SetData(CMlngVsfRowTitle, CMlngvsfLColStatus, CMstrvsfLColStatus)                    '状態

                .Cols(CMlngvsfLColCarrierID).Width = CMlngvsfLColWCarrierID
                .SetData(CMlngVsfRowTitle, CMlngvsfLColCarrierID, CMstrvsfLColCarrierID)              'ｷｬﾘｱID

                .Cols(CMlngvsfLColTransCarrierID).Width = CMlngvsfLColWTransCarrierID
                .SetData(CMlngVsfRowTitle, CMlngvsfLColTransCarrierID, CMstrvsfLColTransCarrierID)    '搬送予定ｷｬﾘｱID

                .Cols(CMlngvsfLColLotID).Width = CMlngvsfLColWLotID
                .SetData(CMlngVsfRowTitle, CMlngvsfLColLotID, CMstrvsfLColLotID)                      'ﾛｯﾄID

                .Cols(CMlngvsfLColTransService).Width = CMlngvsfLColWTransService
                .SetData(CMlngVsfRowTitle, CMlngvsfLColTransService, CMstrvsfLColTransService)        '自動搬送ｻｰﾋﾞｽ

                .Cols(CMlngvsfLColStatusID).Width = CMlngvsfLColWStatusID
                .SetData(CMlngVsfRowTitle, CMlngvsfLColStatusID, CMstrvsfLColStatusID)                '状態ID

                .Cols(CMlngvsfLColTransServiceID).Width = CMlngvsfLColWTransServiceID
                .SetData(CMlngVsfRowTitle, CMlngvsfLColTransServiceID, CMstrvsfLColTransServiceID)    '自動搬送ｻｰﾋﾞｽID

                .Cols(CMlngvsfLColCarrierUnload).Width = CMlngvsfLColWCarrierUnload
                .SetData(CMlngVsfRowTitle, CMlngvsfLColCarrierUnload, CMstrvsfLColCarrierUnload)      'ｷｬﾘｱ強制搬出

                '@表示位置の設定
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter

                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight    '高さ

                '@描画する
                .Redraw = True

            End With

            '@各ﾎﾞﾀﾝを無効にする
            cmdChangeTrnst.Enabled = False      '搬送ﾎﾟｰﾄ変更ﾎﾞﾀﾝ
            cmdCarrierUnload.Enabled = False    'ｷｬﾘｱ強制搬出ﾎﾞﾀﾝ

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfPortNoList_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfPortNoList_Disp
    '機　能：装置ﾎﾟｰﾄ状態一覧ｸﾞﾘｯﾄﾞ　作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/22 (Tue) 13:13:39 S.Deguchi
    '更新日：2009/10/20 (Tue) 10:26:59 T.Oide
    '備　考：
    '　　　：2004/08/26 (Thu) 16:32:40 N.Kojima     強制M1変更ﾎﾞﾀﾝの有効・無効設定(1283～1290行目)。
    '　　　：2004/09/24 (Fri) 11:46:15 S.Deguchi    装置状態をeq__.state___で取得するように修正した対応。
    '　　　：2004/11/15 (Mon) 15:27:30 H.Wajima     運用ﾓｰﾄﾞﾀｲﾌﾟによる強制M1ﾎﾞﾀﾝ有効無効判定追加。(不具合№211)
    '　　　：2004/12/15 (Wed) 15:35:55 S.Deguchi    自動搬送対応でｶﾗﾑ追加＆不具合改善№260で強制M1ﾎﾞﾀﾝ制御を追加
    '　　　：2005/02/07 (Mon) 10:07:21 S.Deguchi    不具合№518対応で運用状態が"異常"の場合には,背景色を赤に変更する処理を追加
    '　　　：2005/02/24 (Thu) 16:16:01 N.Kojima     稼動状態削除、現在の装置状態追加(改善№524、525)
    '　　　：2005/05/19 (Thu) 14:52:31 N.Kojima     SetFocus対応(描画形式をNone+Directに、画面描画に時間がかかった際にDoEventsで制御)
    '　　　：2006/08/28 (Mon) 15:43:26 T.Kitagawa   ﾌｫﾄのTAT改善に伴う処理順指定追加(案件№01097)
    '　　　：2007/10/17 (Wed) 21:03:45 N.Kojima     ﾚｼﾋﾟｸﾞﾙｰﾌﾟｺﾝﾎﾞ追加に伴い、処理修正。(案件№02152)
    '　　　：2009/10/20 (Tue) 10:26:59 T.Oide       搬送ﾓｰﾄﾞ追加(案件№03761)
    Private Sub prvVsfPortNoList_Disp()

        Dim llngDoCnt   As Integer          'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lblnAns     As Boolean          '結果取得(True:正常,False:異常)

        Try

            '@装置名が選択されている場合
            If cmbWp.Text <> vbNullString Then
                '@取得日時を表示
                lblNowDate.Text = Format$(Now, CPstrDateFormat)
            End If

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfPortNoList

                '@格納ﾃﾞｰﾀが0件か
                If mtypEqstate.lngPortListCnt = 0 Then
                    '@0件の場合

                    '@各ﾗﾍﾞﾙを初期化
                    lblM1AfterMode.Text = vbNullString       '運用状態
                    lblBeforeMode.Text = vbNullString        '現在のﾓｰﾄﾞ
                    lblWpStatusName.Text = vbNullString      '処理状態
                    lblUseName.Text = vbNullString           '現在の装置状態

                    '@装置ﾎﾟｰﾄ状態一覧ｸﾞﾘｯﾄﾞ用、上下ｽｸﾛｰﾙﾎﾞﾀﾝを使用不可に設定
                    cmdUP.Enabled = False       '上
                    cmdDown.Enabled = False     '下

                    Exit Sub
                Else
                    '@格納ﾃﾞｰﾀがある場合

                    '@*************************
                    '@ ﾗﾍﾞﾙの設定
                    '@*************************
                    '@各ﾗﾍﾞﾙに取得情報をｾｯﾄ
                    lblM1AfterMode.Text = mtypEqstate.strModeStatus      '運用状態
                    lblBeforeMode.Text = mtypEqstate.strMesModeId        '現在のﾓｰﾄﾞ
                    lblWpStatusName.Text = mtypEqstate.strWpStatusName   '処理状態
                    lblUseName.Text = mtypEqstate.strUseName             '現在の装置状態

                    '@★ 運用ﾓｰﾄﾞにより処理分岐(ﾊﾞｯｸｶﾗｰの設定) ★
                    Select Case mtypEqstate.strModeStatus

                        '@〓 正常 〓
                        Case CMstrNormal

                            lblM1AfterMode.BackColor = SystemColors.ControlLight    'ｸﾞﾚｰ

                        '@〓 異常 〓
                        Case CMstrAbnormal

                            lblM1AfterMode.BackColor = Color.Red                    '赤

                        '@〓 その他 〓
                        Case Else

                            lblM1AfterMode.BackColor = SystemColors.ControlLight    'ｸﾞﾚｰ

                    End Select

                    '@変更後装置状態が"M1"の場合、初期化
                    If lblBeforeMode.Text = CPstrM1 Then
                        cmbUseName.Text = vbNullString

                        '@ﾒｯｾｰｼﾞﾁｪｯｸﾎﾞｯｸｽ使用不可
                        With chkMessage
                            .Checked = False
                            .Enabled = False
                        End With
                    End If

                    'NSYS IDictionary化
                    Dim lstrColComboList As New ListDictionary
                    For Each pair As String In Split(CMstrTransServiceStatus, "|")
                        Dim m As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(pair, "#([^;]+);([^|]+)")
                        If m.Success Then
                            lstrColComboList.Add(m.Groups(1).Value, m.Groups(2).Value)
                        End If
                    Next

                    '@*************************
                    '@ 運用ﾓｰﾄﾞ一覧ｸﾞﾘｯﾄﾞの設定
                    '@*************************
                    .Redraw = False                                 '直接描画しない
                    .Rows.Count = mtypEqstate.lngPortListCnt + 1    '行数設定

                    '@ｶｳﾝﾀの初期化
                    llngDoCnt = 1
                    Do While .Rows.Count > llngDoCnt

                        .SetData(llngDoCnt, CMlngvsfLColNo, _
                            mtypEqstate.typPortList(llngDoCnt - 1).strPortID)                    'Port№

                        .SetData(llngDoCnt, CMlngvsfLColUsage, _
                            mtypEqstate.typPortList(llngDoCnt - 1).strUsage)                     '用途

                        .SetData(llngDoCnt, CMlngvsfLColStatus, _
                            mtypEqstate.typPortList(llngDoCnt - 1).strPortStatus)                '状態

                        .SetData(llngDoCnt, CMlngvsfLColCarrierID, _
                            mtypEqstate.typPortList(llngDoCnt - 1).strCarrierId)                 'ｷｬﾘｱID

                        .SetData(llngDoCnt, CMlngvsfLColTransCarrierID, _
                            mtypEqstate.typPortList(llngDoCnt - 1).strTransCarrier)              '搬送予定ｷｬﾘｱID

                        .SetData(llngDoCnt, CMlngvsfLColLotID, _
                            mtypEqstate.typPortList(llngDoCnt - 1).strLotID)                     'ﾛｯﾄID

                        .SetData(llngDoCnt, CMlngvsfLColTransServiceID, _
                            mtypEqstate.typPortList(llngDoCnt - 1).strTransServiceStatus)        '自動搬送ｻｰﾋﾞｽ状態ID(0:可能、1:不可能)

                        '@自動搬送ｻｰﾋﾞｽ状態ｺﾝﾎﾞ作成

                        .Cols(CMlngvsfLColTransService).DataMap = lstrColComboList

                        '@自動搬送ｻｰﾋﾞｽ状態(和名)
                        If mtypEqstate.typPortList(llngDoCnt - 1).strTransServiceStatus = CMstrTransServiceStatusNG Then

                            .SetData(llngDoCnt, CMlngvsfLColTransService, CMstrTransServiceStatusNG)          '不可能
                        Else
                            .SetData(llngDoCnt, CMlngvsfLColTransService, CMstrTransServiceStatusOK)          '可能
                        End If

                        .SetData(llngDoCnt, CMlngvsfLColStatusID, _
                            mtypEqstate.typPortList(llngDoCnt - 1).strPortStatusID)              '状態ID

                        '@=======================
                        '@ ﾁｪｯｸﾎﾞｯｸｽ表示判定処理
                        '@=======================
                        lblnAns = prvblnCarrierUnloadEnable_Chk(llngDoCnt)

                        '@処理結果判定
                        If lblnAns = True Then
                            '@結果：正常の場合

                            '@ﾁｪｯｸﾎﾞｯｸｽを表示してUncheckにする
                            .SetCellCheck(llngDoCnt, CMlngvsfLColCarrierUnload, _
                                CheckEnum.Unchecked)                                             'ｷｬﾘｱ強制搬出

                            '@ｾﾙ個別に配置を設定する(ｾﾙ全体では設定ができなかった為)
                            '.Cols(CMlngvsfLColCarrierUnload).ImageAlign = ImageAlignEnum.CenterCenter

                        Else
                            '@結果：異常の場合

                            '@ﾁｪｯｸﾎﾞｯｸｽを表示しない
                            .SetCellCheck(llngDoCnt, CMlngvsfLColCarrierUnload, _
                                CheckEnum.None)
                            .SetData(llngDoCnt, CMlngvsfLColCarrierUnload, _
                                vbNullString)                                                    'ｷｬﾘｱ強制搬出
                        End If

                        '@ｾﾙ色変更
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite_ForeColor_vbBlack")
                        newStyle.BackColor = Color.White              '白色
                        '@ﾌｫﾝﾄ色変更
                        newStyle.ForeColor = Color.Black              '黒色
                        Dim cellRange As CellRange = .GetCellRange(llngDoCnt, CMlngVsfColTitle, _
                                               llngDoCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle

                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngDoCnt).Height = CMlngVsfHeight

                        llngDoCnt = llngDoCnt + 1
                    Loop

                    '@表示位置設定
                    .Cols(CMlngvsfLColNo).TextAlign = TextAlignEnum.RightCenter                    '右中央
                    .Cols(CMlngvsfLColStatus).TextAlign = TextAlignEnum.LeftCenter                 '左中央
                    .Cols(CMlngvsfLColCarrierID).TextAlign = TextAlignEnum.LeftCenter              '左中央
                    .Cols(CMlngvsfLColLotID).TextAlign = TextAlignEnum.LeftCenter                  '左中央
                    .Cols(CMlngvsfLColUsage).TextAlign = TextAlignEnum.LeftCenter                  '左中央
                    .Cols(CMlngvsfLColCarrierUnload).ImageAlign = ImageAlignEnum.CenterCenter      '左中央

                    '@ﾌｫｰｶｽ位置の初期値設定
                    .LeftCol = CMlngVsfColTitle   '列
                    .TopRow = CMlngVsfRowTitle    '行
                    .Row = CMlngVsfRowTitle       'ｶﾚﾝﾄ行の移動

                    '@ｸﾞﾘｯﾄﾞに描画
                    .Redraw = True

                    '@ﾛｯｸ解除
                    .Enabled = True

                End If
            End With

            '@*************************
            '@ ｽｸﾛｰﾙﾎﾞﾀﾝの設定
            '@*************************
            '@=======================
            '@ ｿｰﾄ前処理(ｸﾞﾘｯﾄﾞ共通処理)
            '@=======================
            Call pubVsfBeforeSort(vsfPortNoList, CMlngvsfLColNo)

            '@=======================
            '@ ｿｰﾄ後処理(ｸﾞﾘｯﾄﾞ共通処理)
            '@=======================
            Call pubVsfAfterSort(vsfPortNoList, CMlngvsfLColNo, cmdUP, cmdDown, False, False)


            '@*************************
            '@ 変更後処理順指定ｺﾝﾎﾞの設定
            '@*************************
            With cmbRecipeFlow

                .Clear      'ｸﾘｱ

                '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟがあるか
                If mtypEqstate.lngCollectTypeListCnt > 0 Then

                    .AddItem(CPstrRecipeFlowFifo & vbTab & CPlngNumRecipeFlowFifo)               'FIFO(到着順)
                    .AddItem(CPstrRecipeFlowNum & vbTab & CPlngNumRecipeFlowNum)                 'ﾚｼﾋﾟ(切替)
                    .AddItem(CPstrRecipeFlowGroup & vbTab & CPlngNumRecipeFlowGroup)             'ﾚｼﾋﾟ(固定)
                    .AddItem(CPstrRecipeFlowFifoSameNG & vbTab & CPlngNumRecipeFlowFifoSameNG)   'FIFO(到着順)限定
                    .AddItem(CPstrRecipeFlowNumSameNG & vbTab & CPlngNumRecipeFlowNumSameNG)     'ﾚｼﾋﾟ(切替)限定
                    .AddItem(CPstrRecipeFlowGroupSameNG & vbTab & CPlngNumRecipeFlowGroupSameNG) 'ﾚｼﾋﾟ(固定)限定

                    .Enabled = True                         '有効
                    .BackColor = Color.White                '白
                    .ListIndex = -1                         'ﾘｽﾄなし
                    .Text = vbNullString                    'ﾃｷｽﾄ=NULL
                Else
                    '@取得ﾃﾞｰﾀにﾚｼﾋﾟｸﾞﾙｰﾌﾟがない場合

                    .AddItem(CPstrRecipeFlowFifo & vbTab & CPlngNumRecipeFlowFifo)               'FIFO(到着順)
                    .Enabled = False                        '無効
                    .BackColor = SystemColors.ControlLight  'ｸﾞﾚｰ
                    .Text = vbNullString                    'ﾃｷｽﾄ=NULL
                End If
            End With


            '@★ 条件毎連続ﾀｲﾌﾟﾌﾗｸﾞにより処理分岐　※(0：指定不可装置、1：条件毎指定可能装置) ★
            Select Case mtypEqstate.strCollectTypeFlag

                '@〓 "0:FIFO"(条件毎ﾚｼﾋﾟ指定不可能装置) OR "0:FIFO限定"(条件毎ﾚｼﾋﾟ指定不可能装置) 〓
                Case CMstrWpCollectTypeFlag0, CMstrWpCollectTypeFlag3

                    '@現在の処理順の設定
                    If mtypEqstate.strCollectTypeFlag = CMstrWpCollectTypeFlag0 Then

                        lblBeforeRecipeFlow.Text = CPstrRecipeFlowFifo             'FIFO(到着順)
                    Else
                        lblBeforeRecipeFlow.Text = CPstrRecipeFlowFifoSameNG       'FIFO(到着順)限定
                    End If

                    lblBeforeRecipeFlowNum.Text = vbNullString                 '処理ﾛｯﾄ数は空白

                    '@変更後の処理ﾛｯﾄ数の設定
                    With txtRecipeFlowNum
                        .Enabled = False                        '無効
                        .BackColor = SystemColors.ControlLight  'ｸﾞﾚｰ
                        .Text = vbNullString                    'ﾃｷｽﾄ=NULL
                    End With

                    '@変更後のﾚｼﾋﾟｸﾞﾙｰﾌﾟの設定
                    With cmbRecipeGroup

                        '@編集ｷｬﾝｾﾙﾌﾗｸﾞをTrue:編集しない(cmbRecipeGroup_Change処理内で使用)
                        mblnRecipeGroupEditCancelFlag = True

                        .Enabled = False                        '無効
                        .BackColor = SystemColors.ControlLight  'ｸﾞﾚｰ
                        .ListIndex = -1                         'ﾘｽﾄなし
                        .Text = vbNullString                    'ﾃｷｽﾄ=NULL

                        '@編集ｷｬﾝｾﾙﾌﾗｸﾞを戻す
                        mblnRecipeGroupEditCancelFlag = False

                    End With


                '@〓 "1:ﾚｼﾋﾟ(切替)"(条件毎ﾚｼﾋﾟ指定可能装置の場合) OR "4:ﾚｼﾋﾟ(切替)限定"(条件毎ﾚｼﾋﾟ指定可能装置の場合)〓
                Case CMstrWpCollectTypeFlag1, CMstrWpCollectTypeFlag4

                    '@ﾚｼﾋﾟ(切替)の設定
                    If mtypEqstate.strCollectTypeFlag = CMstrWpCollectTypeFlag1 Then
                        lblBeforeRecipeFlow.Text = CPstrRecipeFlowNum             'ﾚｼﾋﾟ(切替)
                    Else
                        lblBeforeRecipeFlow.Text = CPstrRecipeFlowNumSameNG       'ﾚｼﾋﾟ(切替)限定
                    End If

                    lblBeforeRecipeFlowNum.Text = mtypEqstate.strRecipeFlowNum   'ﾚｼﾋﾟ毎連続ﾛｯﾄ数

                    '@変更後の処理ﾛｯﾄ数の設定
                    With txtRecipeFlowNum
                        .Enabled = False                        '無効
                        .BackColor = SystemColors.ControlLight  'ｸﾞﾚｰ
                        .Text = vbNullString                    'ﾃｷｽﾄ=NULL
                    End With

                    '@変更後のﾚｼﾋﾟｸﾞﾙｰﾌﾟの設定
                    With cmbRecipeGroup

                        '@編集ｷｬﾝｾﾙﾌﾗｸﾞをTrue:編集しない(cmbRecipeGroup_Change処理内で使用)
                        mblnRecipeGroupEditCancelFlag = True

                        .Enabled = False                        '無効
                        .BackColor = SystemColors.ControlLight  'ｸﾞﾚｰ
                        .ListIndex = -1                         'ﾘｽﾄなし
                        .Text = vbNullString                    'ﾃｷｽﾄ=NULL

                        '@編集ｷｬﾝｾﾙﾌﾗｸﾞを戻す
                        mblnRecipeGroupEditCancelFlag = False

                    End With


                '@〓 "2:ﾚｼﾋﾟ(固定)"(ﾚｼﾋﾟｸﾞﾙｰﾌﾟ指定可能装置の場合) or "5:ﾚｼﾋﾟ(固定)限定"(ﾚｼﾋﾟｸﾞﾙｰﾌﾟ指定可能装置の場合)〓
                Case CMstrWpCollectTypeFlag2, CMstrWpCollectTypeFlag5

                    '@現在の処理順の設定
                    If mtypEqstate.strCollectTypeFlag = CMstrWpCollectTypeFlag2 Then

                        lblBeforeRecipeFlow.Text = CPstrRecipeFlowGroup          'ﾚｼﾋﾟ(固定)
                    Else
                        lblBeforeRecipeFlow.Text = CPstrRecipeFlowGroupSameNG    'ﾚｼﾋﾟ(固定)限定
                    End If

                    lblBeforeRecipeFlowNum.Text = vbNullString           '処理ﾛｯﾄ数は空白

                    '@変更後の処理ﾛｯﾄ数の設定
                    With txtRecipeFlowNum
                        .Enabled = False                        '無効
                        .BackColor = SystemColors.ControlLight  'ｸﾞﾚｰ
                        .Text = vbNullString                    'ﾃｷｽﾄ=NULL
                    End With

                    '@変更後のﾚｼﾋﾟｸﾞﾙｰﾌﾟの設定
                    With cmbRecipeGroup

                        '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟが存在するか
                        If mtypEqstate.lngCollectTypeListCnt > 0 Then

                            '@編集ｷｬﾝｾﾙﾌﾗｸﾞをTrue:編集しない(cmbRecipeGroup_Change処理内で使用)
                            mblnRecipeGroupEditCancelFlag = True

                            '@=======================
                            '@ ﾚｼﾋﾟｸﾞﾙｰﾌﾟｺﾝﾎﾞの作成処理
                            '@=======================
                            Call prvCmbRecipeGroup_Disp()

                            '@編集ｷｬﾝｾﾙﾌﾗｸﾞを戻す
                            mblnRecipeGroupEditCancelFlag = False

                            .Enabled = True                         '有効
                            .BackColor = Color.White                '白
                        Else
                            '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟが存在しない場合

                            .Enabled = False                        '無効
                            .BackColor = SystemColors.ControlLight  'ｸﾞﾚｰ
                            .ListIndex = -1                         'ﾘｽﾄなし
                            .Text = vbNullString                    'ﾃｷｽﾄ=NULL
                        End If
                    End With

            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfPortNoList_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfModeList_Init
    '機　能：運用ﾓｰﾄﾞ一覧ｸﾞﾘｯﾄﾞ(=参照用ｸﾞﾘｯﾄﾞ)初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/22 (Tue) 15:22:27 S.Deguchi
    '更新日：2006/10/17 (Tue) 15:51:57 M.Miura
    '備　考：
    '　　　：2004/08/26 (Thu) 13:46:04 N.Kojima     ﾘｽﾄ拡大につき、1ｽﾛｯﾄの高さを変更(1448～1451行目)。
    '　　　：2004/09/21 (Tue) 14:05:12 S.Deguchi    一覧の初期化に非活性化を追加
    '　　　：2004/11/16 (Tue) 09:45:42 H.Wajima     背景色初期化処理追加
    '　　　：2005/12/26 (Mon) 17:13:34 N.Kasai      描画設定追加
    '　　　：2006/10/17 (Tue) 15:51:57 M.Miura      画面のﾗﾍﾞﾙ背景色の(赤/青)ちらつき修正(案件№01570)
    Private Sub prvVsfModeList_Init()

        Dim llngCnt     As Integer      'ｶｳﾝﾄ
        Dim newStyle    As CellStyle    'NSYS セルスタイル
        Dim cellRange   As CellRange    'NSYS セルレンジ

        Try

            With vsfModeList

                .Redraw = False                                 '直接描画しない

                'NSYS VB6ではデータ行のデータをデザイナーとリソースで指定できるが、VB.NETでは不可のためここで設定
                cellRange = .GetCellRange(.Rows.Fixed, CMlngvsfColMode, .Rows.Count - 1, .Cols.Count - 1)
                cellRange.Clip = CMstrvsfModeListData

                '@一覧表の表題設定
                .Select(CMlngVsfRowTitle, CMlngVsfColTitle, CMlngVsfRowTitle, .Cols.Count - 1)
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.ForeColor = Color.Yellow                       '文字色
                lFixedStyle.BackColor = lblMcGroupNameTitle.BackColor      '周りの背景色に合せる
                With .Font                                                 'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                    lFixedStyle.Font = New Font(.FontFamily, CMlngvsfHFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With

                '@ﾘｽﾄの1ｽﾛｯﾄの高さを設定(ﾍｯﾀﾞｰは除く)
                newStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                newStyle.BackColor = Color.White
                For llngCnt = llngCnt + 1 To .Rows.Count - 1

                    .Rows(llngCnt).Height = CMlngVsfHeight                  '高さ設定
                    cellRange = .GetCellRange(llngCnt, CMlngvsfColMode, llngCnt, .Cols.Count - 1)
                    cellRange.Style = newStyle                              '背景色=白
                Next llngCnt

                .Redraw = True                                              '直接描画

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfModeList_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfChamberList_Init
    '機　能：装置処理部用途/状態一覧ｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/11/20 (Mon) 12:15:55 N.Kasai
    '更新日：2006/11/20 (Mon) 12:15:55
    '備　考：
    Private Sub prvVsfChamberList_Init()

        Try

            With vsfChamberList

                .Redraw = False                     '直接描画しない
                .AllowSorting = False               'ｿｰﾄ不可
                .Rows.Count = .Rows.Fixed           '初期行数設定
                .SelectionMode = SelectionModeEnum.Cell
                .HighLight = HighLightEnum.Never    'ﾊｲﾗｲﾄ表示なし
                .FocusRect = FocusRectEnum.Light    'ﾌｫｰｶｽ枠のｽﾀｲﾙを設定

                '@内部IDを非表示設定
                .Cols(CMlngvsfCColChamberID).Visible = False
                .Cols(CMlngvsfCColOldChamberID).Visible = False
                .Cols(CMlngvsfCColOldProcessingName).Visible = False
                .Cols(CMlngvsfCColOldUseID).Visible = False
                .Cols(CMlngvsfCColEditTime).Visible = False

                '@一覧表の表題設定
                .Select(CMlngVsfRowTitle, CMlngvsfLColNo, CMlngVsfRowTitle, .Cols.Count - 1)
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.ForeColor = Color.Yellow                       '文字色
                lFixedStyle.BackColor = lblMcGroupNameTitle.BackColor      '背景色(周りの背景色に合せる)
                With .Font                                                 'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                    lFixedStyle.Font = New Font(.FontFamily, CMlngVsfHFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With

                '@列幅、ﾀｲﾄﾙ設定
                .Cols(CMlngvsfCColNo).Width = CMlngvsfCColWNo
                .SetData(CMlngVsfRowTitle, CMlngvsfCColNo, CMstrvsfCColNo)                                    'No.

                .Cols(CMlngvsfCColProcessingName).Width = CMlngvsfCColWProcessingName
                .SetData(CMlngVsfRowTitle, CMlngvsfCColProcessingName, CMstrvsfCColProcessingName)            '処理部用途

                .Cols(CMlngvsfCColUseName).Width = CMlngvsfCColWUseName
                .SetData(CMlngVsfRowTitle, CMlngvsfCColUseName, CMstrvsfCColUseName)                          '状態

                .Cols(CMlngvsfCColChamberID).Width = CMlngvsfCColWChamberID
                .SetData(CMlngVsfRowTitle, CMlngvsfCColChamberID, CMstrvsfCColChamberID)                      '用途ID

                .Cols(CMlngvsfCColOldChamberID).Width = CMlngvsfCColWOldChamberID
                .SetData(CMlngVsfRowTitle, CMlngvsfCColOldChamberID, CMstrvsfCColOldChamberID)                '処理部用途ID(非表示)

                .Cols(CMlngvsfCColOldProcessingName).Width = CMlngvsfCColWOldProcessingName
                .SetData(CMlngVsfRowTitle, CMlngvsfCColOldProcessingName, CMstrvsfCColOldProcessingName)      '処理部用途名(非表示)

                .Cols(CMlngvsfCColOldUseID).Width = CMlngvsfCColWOldUseID
                .SetData(CMlngVsfRowTitle, CMlngvsfCColOldUseID, CMstrvsfCColOldUseID)                        '状態ID(非表示)

                .Cols(CMlngvsfCColEditTime).Width = CMlngvsfCColWEditTime
                .SetData(CMlngVsfRowTitle, CMlngvsfCColEditTime, CMstrvsfCColEditTime)                        '更新日時(非表示)

                '@表示位置の設定
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight    '高さ

                '@描画する
                .Redraw = True

                '@ﾛｯｸ
                .Enabled = False

            End With

            '@処理部用途/状態変更ﾎﾞﾀﾝを無効にする
            cmdChangeChamber.Enabled = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfChamberList_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfChamberList_Disp
    '機　能：装置処理部用途/状態一覧ｸﾞﾘｯﾄﾞ　作成処理
    '引　数：ltypWpProcessingUseAns     ：ﾃﾞｰﾀ格納
    '　　　：ltypWpProcessingNameListAns：用途ﾃﾞｰﾀ
    '　　　：lstrChamber                ：状態ｺﾝﾎﾞﾃﾞｰﾀ
    '戻り値：なし
    '作成日：2006/11/21 (Tue) 14:29:04 N.Kasai
    '更新日：2006/11/21 (Tue) 14:29:04
    '備　考：
    Private Sub prvVsfChamberList_Disp(ByRef ltypWpProcessingUseAns As WpProcessingUseAns, _
                                       ByRef ltypWpProcessingNameListAns As WpProcessingNameListAns, _
                                       ByVal lstrChamber As IDictionary)

        Dim llngDoCnt   As Integer      'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngCnt     As Integer      '汎用ｶｳﾝﾀ

        Try

            With vsfChamberList

                '@描画停止
                .Redraw = False

                '@行数設定
                .Row = -1
                .Rows.Count = ltypWpProcessingUseAns.lngProcessingUseListCnt + 1

                '@ｶｳﾝﾀの初期化
                llngDoCnt = 1
                Do While .Rows.Count > llngDoCnt

                    .SetData(llngDoCnt, CMlngvsfCColNo, _
                        ltypWpProcessingUseAns.typProcessingUseList(llngDoCnt - 1).strNo)                    '№

                    '@用途名表示
                    For llngCnt = 0 To ltypWpProcessingNameListAns.lngProcessingListCnt - 1

                        If ltypWpProcessingUseAns.typProcessingUseList(llngDoCnt - 1).strChamberId = _
                            ltypWpProcessingNameListAns.typProcessingList(llngCnt).strChamberId Then

                            .SetData(llngDoCnt, CMlngvsfCColProcessingName, _
                                ltypWpProcessingNameListAns.typProcessingList(llngCnt).strProcessingName)    '処理部用途

                            .SetData(llngDoCnt, CMlngvsfCColOldProcessingName, _
                                ltypWpProcessingNameListAns.typProcessingList(llngCnt).strProcessingName)    '処理部用途(変更前)
                            Exit For
                        End If
                    Next llngCnt

                    .SetData(llngDoCnt, CMlngvsfCColUseName, _
                        ltypWpProcessingUseAns.typProcessingUseList(llngDoCnt - 1).strChamberUseId)          '処理部状態ID

                    .SetData(llngDoCnt, CMlngvsfCColChamberID, _
                        ltypWpProcessingUseAns.typProcessingUseList(llngDoCnt - 1).strChamberId)             '処理部用途ID

                    '@状態ｸﾞﾘｯﾄﾞｺﾝﾎﾞ作成
                    .Cols(CMlngvsfCColUseName).DataMap = lstrChamber

                    .SetData(llngDoCnt, CMlngvsfCColOldChamberID, _
                        ltypWpProcessingUseAns.typProcessingUseList(llngDoCnt - 1).strChamberId)             '処理部用途ID(変更前)

                    .SetData(llngDoCnt, CMlngvsfCColOldUseID, _
                        ltypWpProcessingUseAns.typProcessingUseList(llngDoCnt - 1).strChamberUseId)          '処理部状態ID(変更前)

                    .SetData(llngDoCnt, CMlngvsfCColEditTime, _
                        ltypWpProcessingUseAns.typProcessingUseList(llngDoCnt - 1).strEditTime)              '更新日時


                    '@ｾﾙ色変更
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite_ForeColor_vbBlack")
                    newStyle.BackColor = Color.White              '白色
                    '@ﾌｫﾝﾄ色変更
                    newStyle.ForeColor = Color.Black              '黒色
                    Dim cellRange As CellRange = .GetCellRange(llngDoCnt, CMlngVsfColTitle, _
                                           llngDoCnt, .Cols.Count - 1)
                    cellRange.Style = newStyle

                    '@ｽﾛｯﾄの高さの設定
                    .Rows(llngDoCnt).Height = CMlngVsfHeight

                    llngDoCnt = llngDoCnt + 1
                Loop

                '@表示位置設定
                .Cols(CMlngvsfCColNo).TextAlign = TextAlignEnum.RightCenter                    '右中央
                .Cols(CMlngvsfCColProcessingName).TextAlign = TextAlignEnum.LeftCenter         '左中央
                .Cols(CMlngvsfCColUseName).TextAlign = TextAlignEnum.LeftCenter                '左中央

                .Row = 0

                '@直接表示
                .Redraw = True

                '@ﾛｯｸ解除
                .Enabled = True

            End With

            '@***********************
            '@ ｽｸﾛｰﾙﾎﾞﾀﾝの設定
            '@***********************
            '@=======================
            '@ ｿｰﾄ前処理(ｸﾞﾘｯﾄﾞ共通処理)
            '@=======================
            Call pubVsfBeforeSort(vsfChamberList, CMlngvsfCColNo)

            '@=======================
            '@ ｿｰﾄ後処理(ｸﾞﾘｯﾄﾞ共通処理)
            '@=======================
            Call pubVsfAfterSort(vsfChamberList, CMlngvsfCColNo, cmdChamberUP, cmdChamberDown, False, False, False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfChamberList_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbMcGroupList_Disp
    '機　能：装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ作成処理
    '引　数：mtypAreaList()：ｴﾘｱ情報格納構造体
    '戻り値：なし
    '作成日：2004/06/21 (Mon) 11:41:30 S.Deguchi
    '更新日：2004/11/16 (Tue) 15:14:30 H.Wajima
    '備　考：
    '　　　：2004/11/16 (Tue) 15:14:30 H.Wajima     装置ｸﾞﾙｰﾌﾟが1件の場合、ﾃﾞﾌｫﾙﾄ表示処理を追加
    Private Sub prvcmbMcGroupList_Disp(ByRef ltypMcGroupList As McGroupList)

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ
            With cmbMcGroup

                .Enabled = True                                                 '有効
                .Clear                                                          'ｸﾘｱ
                .DirectInput = False                                            '直接入力不可
                .Height = CMlngCmbRowHeight                                     '高さ
                .RowHeight = CMlngCmbRowHeight                                  '高さ(行)
                .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                With .Font                                                      'ﾌｫﾝﾄｻｲｽﾞ
                    cmbMcGroup.Font = New Font(.FontFamily, CMlngCmbFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                With .GridFont                                                  'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    cmbMcGroup.GridFont = New Font(.FontFamily, CMlngCmbGridFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .ValueCol = CMlngCmbValueCol1                                   '値取得列
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .GroupRows = ltypMcGroupList.lngMcGroupListCnt

                For llngCnt = 0 To ltypMcGroupList.lngMcGroupListCnt - 1

                    '@***********************
                    '@ 装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ作成
                    '@***********************
                    '@装置ｸﾞﾙｰﾌﾟ名/装置ｸﾞﾙｰﾌﾟID
                    .AddItem(ltypMcGroupList.typMcGroupList(llngCnt).strMcGroupName _
                           & vbTab _
                           & ltypMcGroupList.typMcGroupList(llngCnt).strMcGroupID)

                Next llngCnt

                '@装置ｸﾞﾙｰﾌﾟが1件の場合、ﾃﾞﾌｫﾙﾄ表示
                If .ListCount = 1 Then
                    '@1件目表示
                    .ListIndex = 0
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbMcGroupList_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbWp_Disp
    '機　能：装置名ｺﾝﾎﾞ作成処理
    '引　数：mtypWpList()       ：装置情報格納構造体
    '　　　：mlngWpListCnt      ：装置情報格納ｶｳﾝﾄ数
    '　　　：lblnValidate：True ：cmbWp_Validateを行う、False：行わない
    '戻り値：なし
    '作成日：2004/06/22 (Tue) 11:12:18 S.Deguchi
    '更新日：2006/06/27 (Tue) 17:16:49 M.Miura
    '備　考：
    '　　　：2004/11/16 (Tue) 15:12:48 H.Wajima     装置が1件の場合、ﾃﾞﾌｫﾙﾄ表示処理を追加
    '　　　：2004/11/17 (Wed) 09:51:20 H.Wajima     装置が1件の場合、Validate処理の実行を追加
    '　　　：2005/02/28 (Mon) 18:15:57 N.Kojima     装置ﾘｽﾄColに状態IDを保持(改善№524、525)
    '　　　：2005/05/19 (Thu) 10:35:37 N.Kojima     SetFocus対応(Validate処理のｺﾒﾝﾄｱｳﾄ)
    '　　　：2006/06/27 (Tue) 16:50:36 M.Miura      確定、最新取得時の装置ｺﾝﾎﾞValidateをｽｷｯﾌﾟ(不具合№3542)
    Private Sub prvcmbWp_Disp(ByRef mtypWpList As List(Of AreaEquipmentList), _
                              ByVal mlngWpListCnt As Integer, _
                              Optional ByVal lblnValidate As Boolean = True)

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            '@装置名ｺﾝﾎﾞ
            With cmbWp

                .Enabled = True                                                 '有効
                .Clear                                                          'ｸﾘｱ
                .DirectInput = False                                            '直接入力不可
                .Height = CMlngCmbRowHeight                                     '高さ
                .RowHeight = CMlngCmbRowHeight                                  '高さ(行)
                .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                With .Font                                                      'ﾌｫﾝﾄｻｲｽﾞ
                    cmbWp.Font = New Font(.FontFamily, CMlngCmbFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                With .GridFont                                                  'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    cmbWp.GridFont = New Font(.FontFamily, CMlngCmbGridFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .ValueCol = CMlngCmbValueCol1                                   '値取得列
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .GroupRows = mlngWpListCnt

                '@装置名情報ｾｯﾄ
                For llngCnt = 0 To mlngWpListCnt - 1

                    '@装置名/装置ID/装置状態ID
                    .AddItem(mtypWpList(llngCnt).strWpName & vbTab & mtypWpList(llngCnt).strWpID _
                                & vbTab & mtypWpList(llngCnt).strUseId)
                Next llngCnt

                '@装置が1件の場合、ﾃﾞﾌｫﾙﾄ表示
                If .ListCount = 1 Then

                    '@1件目表示
                    .ListIndex = 0
         
                    '@Validate処理を実行する場合(装置ｸﾞﾙｰﾌﾟに1つの装置しかない場合、
                    '@Falseで確定後にｴﾗｰになるのを回避)
                    If lblnValidate = True Then

                        '@=======================
                        '@ 装置名ｺﾝﾎﾞのValidate処理
                        '@=======================
                        Call cmbWp_Validate(cmbWp, New CancelEventArgs(True))
                    End If
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbWp_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnWpID_Sel
    '機　能：ｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置情報取得(装置情報取得)処理
    '引　数：lstrMcGroupID  :装置ｸﾞﾙｰﾌﾟID
    '戻り値：True:成功、False:失敗
    '作成日：2004/06/22 (Tue) 10:50:42 S.Deguchi
    '更新日：2004/07/21 (Wed) 10:29:01 Y.Yamagishi
    '備　考：
    Private Function prvblnWpID_Sel(ByVal lstrMcGroupID As String) As Boolean

        Dim lblnAns     As Boolean      '結果格納

        Try

            '@戻り値の初期化
            prvblnWpID_Sel = False

            '@装置情報格納用構造体初期化
            mtypWpList = New List(Of AreaEquipmentList)

            '@【ｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置状態情報取得(装置情報取得)】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnEqAreaCurList_Sel(CMstreq__areacurlistVer, _
                                              vbNullString, _
                                              pstrSBID, _
                                              mtypWpList, _
                                              mlngWpListCnt, _
                                              CPstrCD20, _
                                              lstrMcGroupID)

            '@通信結果判定
            If lblnAns = False Then
                '@結果：異常の場合

                '@退避領域に設定
                mstrMcGroupID = vbNullString
                Exit Function
            Else
                '@結果：正常の場合

                '@退避領域に設定
                mstrMcGroupID = lstrMcGroupID
            End If

            '@退避領域に設定
            mstrMcGroupID = lstrMcGroupID

            '@戻り値に"True:成功"をｾｯﾄする
            prvblnWpID_Sel = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnWpID_Sel"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnPortLotList_Sel
    '機　能：装置状態取得処理
    '引　数：lstrWpID：装置ID
    '戻り値：True:成功/False:失敗
    '作成日：2004/06/22 (Tue) 11:48:01 S.Deguchi
    '更新日：2004/06/22 (Tue) 11:48:01
    '備　考：
    Private Function prvblnPortLotList_Sel(ByVal lstrWpId As String) As Boolean

        Dim lblnAns     As Boolean      '結果格納

        Try

            '@戻り値の初期化
            prvblnPortLotList_Sel = False

            '@構造体初期化
            mtypEqstate.typPortList = New List(Of eqPortList)

            '@変数格納
            mstrWpID = lstrWpId

            '@【装置状態取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnEqState_Sel(CMstreq__state___Ver, _
                                        lstrWpId, mtypEqstate)

            '@通信結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                Exit Function
            End If

            '@戻り値に"True:正常"をｾｯﾄ
            prvblnPortLotList_Sel = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnPortLotList_Sel"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnPortLotList_Chk
    '機　能：装置状態ﾁｪｯｸ処理
    '引　数：llngChkModeFlg：ﾁｪｯｸﾓｰﾄﾞﾌﾗｸﾞ/0:装置情報取得時、1:運用ﾓｰﾄﾞ変更確定時
    '戻り値：True:OK/False:NG
    '作成日：2004/06/22 (Tue) 16:35:35 S.Deguchi
    '更新日：2007/02/28 (Wed) 10:09:10 N.Kojima
    '備　考：
    '　　　：2004/08/27 (Fri) 19:20:22 N.Kojima　   用途(ﾎﾟｰﾄ)が"DUMMY"又は"RETICLE"の場合("PRODUCT"以外)は、
    '　　　：                                       状態が"搭載"でもモード変更を可能とする。
    '　　　：2004/09/21 (Wed) 19:20:22 S.Deguchi    装置状態ﾁｪｯｸのﾒｯｾｰｼﾞを変更する
    '　　　：2004/10/15 (Fri) 12:53:52 K.Takano     状態IDでの判断処理に変更
    '　　　：2004/11/16 (Tue) 10:38:10 H.Wajima     運用ﾓｰﾄﾞﾀｲﾌﾟの判定処理追加
    '　　　：2004/12/14 (Tue) 09:17:23 H.Wajima     装置ﾃﾞｰﾀ取得時のﾒｯｾｰｼﾞをｽﾃｰﾀｽ表示するように変更(№272)
    '　　　：2004/12/28 (Tue) 11:15:31 H.Wajima     強制M1ﾎﾞﾀﾝが有効にならない不具合を修正
    '　　　：2005/01/17 (Mon) 11:19:02 N.Kojima     運用ﾓｰﾄﾞ変更予約中の場合のﾒｯｾｰｼﾞを修正(SPIRYTUSﾕｰｻﾞ要望管理№0024)
    '　　　：2005/05/24 (Tue) 16:02:21 N.Kojima     ﾊﾝﾄﾞﾜｰｸ工程用の処理、装置が選択されていない場合の処理追加。
    '　　　：2006/06/20 (Tue) 15:49:12 T.Kitagawa   M1からのﾓｰﾄﾞ変更についてはMES_MODE_TYPEにより可能、不可能を判定させる。(不具合№3536)
    '　　　：2007/02/28 (Wed) 10:09:10 N.Kojima     「移行中」ﾁｪｯｸを除き、ﾁｪｯｸNGの場合はﾓｰﾄﾞﾘｽﾄを使用不可にする処理を追加。
    '　　　：                                       ※元々はFunctionを抜けてから、ﾓｰﾄﾞﾘｽﾄを使用可/不可処理を行なっていたのを移動。(案件№01792)
    Private Function prvblnPortLotList_Chk(ByVal llngChkModeFlg As Integer) As Boolean

        Dim llngCnt             As Integer      'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrPortStatus      As String       'ﾎﾟｰﾄ状態
        Dim lstrUsage           As String       '用途(ﾎﾟｰﾄ)

        Try

            '@戻り値の初期化
            prvblnPortLotList_Chk = True

            '@ﾊﾝﾄﾞﾜｰｸﾌﾗｸﾞをOFFに
            mblnHandWorkFlag = False

            '@装置ﾎﾟｰﾄ状態ﾁｪｯｸ
            With vsfPortNoList

                '@装置ﾎﾟｰﾄ状態一覧ｸﾞﾘｯﾄﾞにﾃﾞｰﾀがあるか
                If .Rows.Count <= 1 Then
                    '@ﾃﾞｰﾀがない場合

                    '@装置が選択されていない場合
                    If cmbWp.Text <> vbNullString Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM2UI>$$選択された装置[%1]は、ハンドワーク工程用の仮想装置の為、
                        '@　$運用モード変更を行うことはできません。"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002U, cmbWp.Text)
                        Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                    End If

                    '@現在の装置状態を表示
                    lblUseName.Text = mtypEqstate.strUseName

                    '@運用ﾓｰﾄﾞ変更ｸﾞﾘｯﾄﾞを使用不可能状態にする
                    vsfModeList.Enabled = False

                    '@強制M1変更ﾎﾞﾀﾝを非活性化
                    cmdExecution.Enabled = False

                    '@ﾊﾝﾄﾞﾜｰｸﾌﾗｸﾞをONに
                    mblnHandWorkFlag = True

                    '@戻り値に"False:異常"をｾｯﾄ
                    prvblnPortLotList_Chk = False
                    Exit Function
                Else
                    '@ﾃﾞｰﾀがある場合

                    '@ﾊﾝﾄﾞﾜｰｸ工程以外の場合
                    For llngCnt = 1 To .Rows.Count - 1

                        '@現在の運用ﾓｰﾄﾞが「M1」か
                        If lblBeforeMode.Text = CMstrModeM1 Then

                            lstrPortStatus = .GetData(llngCnt, CMlngvsfLColStatusID)   'ﾎﾟｰﾄ状態格納
                            lstrUsage = .GetData(llngCnt, CMlngvsfLColUsage)           '用途(ﾎﾟｰﾄ)格納

                            '@★ 取得情報の運用ﾓｰﾄﾞﾀｲﾌﾟにより処理分岐 ★
                            Select Case mtypEqstate.strMesModeType

                                '@〓 "処理中不可"のﾓｰﾄﾞﾀｲﾌﾟ 〓
                                Case CPstrMesModeType10, CPstrMesModeType11, _
                                    CPstrMesModeType12, CPstrMesModeType13, CPstrMesModeType14

                                    '@ﾎﾟｰﾄ状態が"搭載中"か
                                    If lstrPortStatus <> CMstrvsfStatusAki And _
                                        lstrPortStatus <> CMstrvsfStatusFuka Then

                                        '@ﾎﾟｰﾄの用途が"PRODUCT(製品)"か
                                        If lstrUsage = CMstrProduct Then

                                            '@表示ﾒｯｾｰｼﾞ変換
                                            '@「"<TRM82W>$$装置[%1]に仕掛(処理)中のキャリアがあるため、
                                            '@　運用モードの変更はできません。"」のﾒｯｾｰｼﾞ表示
                                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0082, cmbWp.Text)

                                            '@★★ ﾁｪｯｸﾓｰﾄﾞﾌﾗｸﾞの値により処理分岐 ★★
                                            Select Case llngChkModeFlg

                                                '@〓〓 装置情報取得時 〓〓
                                                Case CMlngChkModeFlg0

                                                    '@ｽﾃｰﾀｽ表示
                                                    Call pubVsfInfo_Disp(pstrDMsg, True)

                                                '@〓〓 運用ﾓｰﾄﾞ変更確定時 〓〓
                                                Case CMlngChkModeFlg1

                                                    '@ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示
                                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                                                    '@戻り値にFalseを設定
                                                    prvblnPortLotList_Chk = False

                                                    '@運用ﾓｰﾄﾞ変更ｸﾞﾘｯﾄﾞを使用不可能状態にする
                                                    vsfModeList.Enabled = False

                                            End Select
                                        End If

                                        '@★★ ﾁｪｯｸﾓｰﾄﾞﾌﾗｸﾞの値により処理分岐 ★★
                                        Select Case llngChkModeFlg

                                            '@〓〓 装置情報取得時 〓〓
                                            Case CMlngChkModeFlg0

                                                '@ﾙｰﾌﾟを抜ける
                                                Exit For

                                            '@〓〓 運用ﾓｰﾄﾞ変更時 〓〓
                                            Case CMlngChkModeFlg1

                                                '@処理を抜ける
                                                Exit Function

                                        End Select
                                    End If
                            End Select
                        End If
                    Next llngCnt
                End If
            End With

            '@運用ﾓｰﾄﾞﾀｲﾌﾟが"M1のみ"か
            If mtypEqstate.strMesModeType = CPstrMesModeType9 Then
                '@運用ﾓｰﾄﾞﾀｲﾌﾟが常にM1の場合、強制M1不可

                '@強制M1ﾎﾞﾀﾝ無効
                cmdExecution.Enabled = False

                '@戻り値にFalseを設定
                prvblnPortLotList_Chk = False

                '@運用ﾓｰﾄﾞ変更ｸﾞﾘｯﾄﾞを使用不可能状態にする
                vsfModeList.Enabled = False

                Exit Function
            End If

            '@予約状態ﾁｪｯｸ
            If mtypEqstate.strReseerveMesModeID <> vbNullString Then

                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM89W>$$[%1]に運用モードの変更予約がされています。$ 装置故障により、
                '@　運用モードを変更する場合には、$ 強制変更を行ってください。"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0089, mtypEqstate.strReseerveMesModeID)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@戻り値にFalseを設定
                prvblnPortLotList_Chk = False
            End If

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnPortLotList_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnCheck_Proc
    '機　能：ﾁｪｯｸ処理(共通)
    '引　数：lstrCallFunction   ：呼び元Function
    '戻り値：True:ﾁｪｯｸOK、False:ﾁｪｯｸNG
    '作成日：2004/06/22 (Tue) 18:13:51 S.Deguchi
    '更新日：2008/02/04 (Mon) 09:52:03 N.Kojima
    '備　考：
    '　　　：2005/05/19 (Thu) 13:16:09 N.Kojima     SetFocus対応(OnErr処理追加)
    '　　　：2008/02/04 (Mon) 09:52:03 N.Kojima     計画保全対応、ｿｰｽ整備。(案件№02332)
    Private Function prvblnCheck_Proc(ByVal lstrCallFunction As String) As Boolean

        Dim llngAns                 As Integer              '結果格納
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        Dim lstrAfterMode           As String               '変更後ﾓｰﾄﾞ

        Try

            '@ｴﾗｰ発生箇所の初期化
            ptypOnErrorInfo.strErrPositionDetail = vbNullString

            '@戻り値の初期化
            prvblnCheck_Proc = True

            '@変更後ﾓｰﾄﾞを格納
            lstrAfterMode = vsfModeList.GetData(vsfModeList.Row, CMlngvsfColMode)

            '@***********************
            '@ 自端末装置ﾁｪｯｸ
            '@***********************
            '@ﾃﾞﾌｫﾙﾄ装置以外(pstrTerminalFlag="1"orNULL)か
            If pstrTerminalFlag <> CPstrZero Then

                '@表示ﾒｯｾｰｼﾞ変換(確認ﾒｯｾｰｼﾞBOXを表示する)
                '@「"<TRM92W>$$この端末に紐付く装置ではない装置の状態を$変更しようとしています。よろしいですか？"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0092)
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                If llngAns = vbNo Then
                    '@"いいえ"選択の場合、処理ｷｬﾝｾﾙ

                    '@戻り値に"False:ﾁｪｯｸNG"をｾｯﾄ
                    prvblnCheck_Proc = False
                    Exit Function
                End If
            End If

            '@***********************
            '@ 変更後装置状態ﾁｪｯｸ
            '@***********************
            '@変更後装置状態が未選択か
            If cmbUseName.Text = vbNullString Then

                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM5AW>$$変更後装置状態が設定されていません。設定を見直してください。"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005A)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@変更後装置状態へﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmbUseName)

                '@戻り値に"False:ﾁｪｯｸNG"をｾｯﾄ
                prvblnCheck_Proc = False
                Exit Function
            End If

            '@呼び元が「強制M1ﾎﾞﾀﾝ押下処理」以外の場合は、下記のﾁｪｯｸも行なう
            If lstrCallFunction <> CMstrCmdExecutionClick Then

                '@***********************
                '@ ﾓｰﾄﾞ移行状態ﾁｪｯｸ
                '@***********************
                '@運用状態が「ﾓｰﾄﾞ移行中」の場合
                If lblM1AfterMode.Text = CMstrWpMove Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM89W>$$[%1]に運用モードの変更予約がされています。$装置故障により、
                    '@　運用モードを変更する場合には、$強制変更を行ってください。"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0089, mtypEqstate.strReseerveMesModeID)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@戻り値に"False:ﾁｪｯｸNG"をｾｯﾄ
                    prvblnCheck_Proc = False
                    Exit Function
                End If
            End If

            '@呼び元が「確定ﾎﾞﾀﾝ押下処理」の場合は、下記のﾁｪｯｸも行なう
            If lstrCallFunction = CMstrCmdRegistClick Then

                '@***********************
                '@ ﾎﾟｰﾄ状態ﾁｪｯｸ
                '@***********************
                With vsfPortNoList

                    '@現在のﾓｰﾄﾞが「F/S2」の場合
                    If lblBeforeMode.Text = CPstrS2 Or lblBeforeMode.Text = CPstrF Then

                        '@変更後ﾓｰﾄﾞが「S1/M1」の場合
                        If lstrAfterMode = CPstrM1 Or lstrAfterMode = CPstrS1 Then

                            '@ｶｳﾝﾀ初期化
                            llngCnt = 0

                            For llngCnt = 1 To .Rows.Count - 1

                                '@搬送予約ｷｬﾘｱがあるか
                                If .GetData(llngCnt, CMlngvsfLColTransCarrierID) <> vbNullString Then

                                    '@表示ﾒｯｾｰｼﾞ変換
                                    '@「"<TRM3WI>$$搬送予約中のため、キャリアが搬送中の可能性があります。
                                    '@　$運用モード変更後、リカバリーが必要な場合がありますが、よろしいですか？"」のﾒｯｾｰｼﾞ表示
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003W)
                                    llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                                    '@確認結果判定
                                    If llngAns = vbNo Then
                                        '@"いいえ"選択の場合、処理ｷｬﾝｾﾙ

                                        '@戻り値に"False:ﾁｪｯｸNG"をｾｯﾄ
                                        prvblnCheck_Proc = False
                                        Exit Function
                                    Else
                                        '@For文を抜ける
                                        Exit For
                                    End If
                                End If
                            Next llngCnt
                        End If
                    End If
                End With

                '@***********************
                '@ 運用ﾓｰﾄﾞﾁｪｯｸ
                '@***********************
                '@変更前運用ﾓｰﾄﾞが"M1"以外か
                If lblBeforeMode.Text <> CMstrModeM1 Then
                    '@"M1"以外の場合

                    '@変更後運用ﾓｰﾄﾞが"M1"か
                    If lstrAfterMode = CMstrModeM1 Then
                        '@戻り値に"False:ﾁｪｯｸNG"をｾｯﾄ
                        prvblnCheck_Proc = False
                    End If
                End If

                '@上記運用ﾓｰﾄﾞﾁｪｯｸにて"False:ﾁｪｯｸNG"になった場合、ﾜｰﾆﾝｸﾞﾒｯｾｰｼﾞを表示する
                If prvblnCheck_Proc = False Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM84W>$$現在処理中のキャリアに対するプロセス／品質データが、
                    '@　$正しく保存されないことがあります。$作業終了時に確認してください。よろしいですか？"のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0084, lblBeforeMode.Text, lstrAfterMode)
                    llngAns = publngMsgBoxInfo(pstrDMsg, vbQuestion, Me.Text, True, 16)

                    If llngAns = vbNo Then
                        '@"いいえ"選択の場合、処理ｷｬﾝｾﾙ

                        '@運用ﾓｰﾄﾞｸﾞﾘｯﾄﾞへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfModeList)
                    Else
                        '@戻り値に"True:ﾁｪｯｸOK"をｾｯﾄ
                        prvblnCheck_Proc = True
                    End If
                End If
            End If

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = CMstrPrvblnCheckPrc
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvCmdSearch_Upd
    '機　能：確定処理後の情報取得処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/07 (Thu) 14:19:13 S.Deguchi
    '更新日：2008/07/01 (Tue) 17:34:37 M.Koni
    '備　考：
    '　　　：2004/11/15 (Mon) 11:55:23 H.Wajima     運用ﾓｰﾄﾞﾘｽﾄの表示処理追加(不具合№211)
    '　　　：2005/02/28 (Mon) 18:53:46 N.Kojima     装置ｺﾝﾎﾞ再取得処理追加(改善№524、525)
    '　　　：2005/05/19 (Thu) 13:18:21 N.Kojima     SetFocus対応(OnErr処理追加、ｲﾍﾞﾝﾄ名称の定数化)
    '　　　：2006/06/26 (Mon) 17:08:52 M.Miura      確定、最新取得時の装置ｺﾝﾎﾞValidateをｽｷｯﾌﾟ(不具合№3542)
    '　　　：2006/06/28 (Wed) 14:04:26 N.Kojima     ﾃﾞﾌｫﾙﾄ装置以外の装置の場合、ﾗﾍﾞﾙ&ｸﾞﾘｯﾄﾞﾀｲﾄﾙ行の色変え処理を追加。(ﾕｰｻﾞｰ要望№0192)
    '　　　：2008/07/01 (Tue) 17:34:53 M.Koni       "util.regtminfo"応答ﾒｯｾｰｼﾞ変更対応<案件No.03006>
    Private Sub prvCmdSearch_Upd()

        Dim lblnAns             As Boolean              '結果格納
        Dim lstrWPName          As String               '装置名格納
        Dim ltypUtilRegTmInfo   As UtilRegTmInfo        '端末設定情報格納

        Try

            '@ｴﾗｰ発生箇所の初期化
            ptypOnErrorInfo.strErrPositionDetail = vbNullString

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvcmdSearchUpd)
            
            '@装置IDが未選択状態の場合、処理を行わない。
            If cmbWp.Text = vbNullString Then

                '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdClose)
                Exit Sub
            Else
                '@=======================
                '@ 装置状態情報の取得処理
                '@=======================
                cmbWp.ValueCol = CMlngCmbValueCol1
                lblnAns = prvblnPortLotList_Sel(cmbWp.Value)

                '@装置状態情報の取得処理結果判定
                If lblnAns = False Then
                    '@結果：異常の場合

                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrPrvcmdSearchUpd)

                    '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbMcGroup)
                    Exit Sub
                Else
                    '@結果：正常の場合

                    '@装置ｸﾞﾙｰﾌﾟが選択されているか
                    If cmbMcGroup.Text <> vbNullString Then

                        '@装置名退避
                        lstrWPName = cmbWp.Text

                        '@=======================
                        '@ 装置情報取得処理
                        '@=======================
                        lblnAns = prvblnWpID_Sel(mstrMcGroupID)

                        '@装置情報取得処理結果判定
                        If lblnAns = True Then
                            '@結果：正常の場合

                            '@=======================
                            '@ 装置名ｺﾝﾎﾞ作成処理(cmbWp_Validateは実行しない)
                            '@=======================
                            'NSYS ちらつき対策
                            RemoveHandler cmbWp.Change, AddressOf cmbWp_Change
                            Call prvcmbWp_Disp(mtypWpList, mlngWpListCnt, False)

                            '@装置名格納
                            cmbWp.Text = lstrWPName
                            AddHandler cmbWp.Change, AddressOf cmbWp_Change

                            'NSYS cmbWp_Change で行われている活性制御を別途行う
                            '@最新取得ﾎﾞﾀﾝを有効に
                            cmdSearch.Enabled = True

                            '@各ﾎﾞﾀﾝを無効にする
                            cmdChangeTrnst.Enabled = False      '搬送ﾎﾟｰﾄ変更ﾎﾞﾀﾝ
                            cmdCarrierUnload.Enabled = False    'ｷｬﾘｱ強制搬出ﾎﾞﾀﾝ

                            '@処理部用途/状態変更ﾎﾞﾀﾝを無効にする
                            cmdChangeChamber.Enabled = False

                            '@作業ﾒﾓの初期化
                            txtWorkMemo.Text = vbNullString

                            '@=======================
                            '@ 運用ﾓｰﾄﾞ一覧ｸﾞﾘｯﾄﾞ作成処理
                            '@=======================
                            Call prvVsfModeList_Disp()

                            '@運用ﾓｰﾄﾞ一覧を活性化
                            vsfModeList.Enabled = True
                            '@運用ﾓｰﾄﾞの選択状態を解除する
                            vsfModeList.Select(CMlngVsfRowTitle, CMlngVsfColTitle)

                            '@運用ﾓｰﾄﾞ一覧ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(vsfModeList)

                            '@=======================
                            '@ 変更後装置状態ｺﾝﾎﾞ作成処理
                            '@=======================
                            Call prvCmbUseName_Disp()

                            '@変更後装置状態ｺﾝﾎﾞを有効にする
                            cmbUseName.Enabled = True
                        End If
                    End If

                    '@=======================
                    '@ 装置処理部用途状態一覧ｸﾞﾘｯﾄﾞ作成処理
                    '@=======================
                    lblnAns = prvblnChamber_Set()

                    '@装置処理部用途状態一覧ｸﾞﾘｯﾄﾞ作成処理結果判定
                    If lblnAns = False Then
                        '@結果：異常の場合

                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrPrvcmdSearchUpd)
                        Exit Sub
                    End If

                    '@=======================
                    '@ 装置ﾎﾟｰﾄ状態一覧ｸﾞﾘｯﾄﾞ作成処理
                    '@=======================
                    Call prvVsfPortNoList_Disp()

                    '@【端末設定情報登録】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnUtilRegTmInfo_Upd(pstrSBID, _
                                                      CMstrutilregtminfoVer, _
                                                      CPstrCD26, _
                                                      pstrComputerName, _
                                                      ltypUtilRegTmInfo, _
                                                      cmbWp.Value, , , cmbMcGroup.Value)

                    '@通信結果判定
                    If lblnAns = False Then
                        '@結果：異常の場合

                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrPrvcmdSearchUpd)
                    End If

                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrPrvcmdSearchUpd)

                    '@=======================
                    '@ ﾃﾞﾌｫﾙﾄ装置以外(pstrTerminalFlag="1")かにより、ﾗﾍﾞﾙ&ｸﾞﾘｯﾄﾞﾀｲﾄﾙ行の色を変える
                    '@=======================
                    Call prvColorChang_Proc()

                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = CMstrPrvcmdSearchUpd
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfModeList_Disp
    '機　能：運用ﾓｰﾄﾞ一覧ｸﾞﾘｯﾄﾞ　作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/15 (Mon) 11:16:53 H.Wajima
    '更新日：2006/06/19 (Mon) 18:13:22 T.Kitagawa
    '備　考：
    '　　　：2005/04/18 (Mon) 20:24:21 N.Kojima     ﾊﾞｯﾁS1運用対応(MES_MODE_TYPE=3(S2不可)の時の処理追加)
    '　　　：2005/05/16 (Mon) 11:25:12 N.Kojima     MES_MODE_TYPE=4(F不可)の時の処理追加(不具合№790)
    '　　　：2006/06/19 (Mon) 18:13:22 T.Kitagawa   MES_MODE_TYPE=10～14の追加対応(不具合№3536)
    Private Sub prvVsfModeList_Disp()

        Dim llngCnt         As Integer  '汎用ｶｳﾝﾀ

        Try

            With vsfModeList

                '@直接描画しない
                .Redraw = False

                '@ｾﾙの色設定処理
                For llngCnt = .Rows.Fixed To .Rows.Count - 1

                    '@★ 装置状態取得の運用ﾓｰﾄﾞﾀｲﾌﾟにより処理分岐 ★
                    Select Case mtypEqstate.strMesModeType

                        '@〓 "0 or 10:通常ﾀｲﾌﾟ(全て可 or M1処理中可 or M1処理中不可)" 〓
                        Case CPstrMesModeType0, CPstrMesModeType10

                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                            newStyle.BackColor = Color.White
                            Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfColMode, llngCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle                  '白色


                        '@〓 "1 or 11:搬送Manual(S2/F不可 or M1処理中可 or M1処理中不可)" 〓
                        Case CPstrMesModeType1, CPstrMesModeType11

                            '@★★ 選択されている運用ﾓｰﾄﾞにより処理分岐 ★★
                            Select Case .GetData(llngCnt, CMlngvsfColMode)

                                '@〓〓 "S2" or "F" 〓〓
                                Case CMstrModeS2, CMstrModeF

                                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                                    Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfColMode, llngCnt, .Cols.Count - 1)
                                    cellRange.Style = newStyle          'ｸﾞﾚｰ

                                '@〓〓 その他 〓〓
                                Case Else

                                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                                    newStyle.BackColor = Color.White
                                    Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfColMode, llngCnt, .Cols.Count - 1)
                                    cellRange.Style = newStyle          '白色

                            End Select


                        '@〓 "2 or 12:特殊ﾀｲﾌﾟ(M2不可 or M1処理中可 or M1処理中不可)" 〓
                        Case CPstrMesModeType2, CPstrMesModeType12

                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                            newStyle.BackColor = Color.White
                            Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfColMode, llngCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle                  '白色


                        '@〓 "3 or 13:特殊ﾀｲﾌﾟ(S2不可 or M1処理中可 or M1処理中不可)" 〓
                        Case CPstrMesModeType3, CPstrMesModeType13

                            '@★★ 選択されている運用ﾓｰﾄﾞにより処理分岐 ★★
                            Select Case .GetData(llngCnt, CMlngvsfColMode)

                                '@〓〓 "S2" 〓〓
                                Case CMstrModeS2

                                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                                    Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfColMode, llngCnt, .Cols.Count - 1)
                                    cellRange.Style = newStyle          'ｸﾞﾚｰ

                                '@〓〓 その他 〓〓
                                Case Else

                                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                                    newStyle.BackColor = Color.White
                                    Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfColMode, llngCnt, .Cols.Count - 1)
                                    cellRange.Style = newStyle          '白色

                            End Select


                        '@〓 "4 or 14:特殊ﾀｲﾌﾟ(F不可 or M1処理中可 or M1処理中不可)" 〓
                        Case CPstrMesModeType4, CPstrMesModeType14

                            '@★★ 選択されている運用ﾓｰﾄﾞにより処理分岐 ★★
                            Select Case .GetData(llngCnt, CMlngvsfColMode)

                                '@〓〓 "F" 〓〓
                                Case CMstrModeF

                                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                                    Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfColMode, llngCnt, .Cols.Count - 1)
                                    cellRange.Style = newStyle          'ｸﾞﾚｰ

                                '@〓〓 その他 〓〓
                                Case Else

                                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                                    newStyle.BackColor = Color.White
                                    Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfColMode, llngCnt, .Cols.Count - 1)
                                    cellRange.Style = newStyle          '白色

                            End Select


                        '@〓 "9:M1のみ" 〓
                        Case CPstrMesModeType9

                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                            Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfColMode, llngCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle

                    End Select
                Next llngCnt

                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight

                .Select(CMlngVsfRowTitle, CMlngVsfColTitle)

                '@直接描画
                .Redraw = True

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfModeList_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbUseName_Disp
    '機　能：変更後(装置状態)ｺﾝﾎﾞ　作成処理
    '引　数：lstrUseNameNew ：装置名(IN)
    '戻り値：なし
    '作成日：2005/02/21 (Mon) 15:15:25 N.Kojima
    '更新日：2005/12/27 (Tue) 13:56:11 N.Kasai
    '備　考：
    '　　　：2005/12/27 (Tue) 13:56:11 N.Kasai      現在の運用ﾓｰﾄﾞの判定をﾗﾍﾞﾙｷｬﾌﾟｼｮﾝから変数へ変更する。
    Private Sub prvCmbUseName_Disp()

        Dim llngCnt                 As Integer  'ｶｳﾝﾄ
        Dim llngSelectFlag          As Integer  '運用ﾓｰﾄﾞ一覧選択判定ﾌﾗｸﾞ(1:運用ﾓｰﾄﾞ選択(背景白)、2:運用ﾓｰﾄﾞ選択(背景ｸﾞﾚｰ)、3:運用ﾓｰﾄﾞ未選択)
        Dim lstrSelectCondition     As String   'SelectCase文の判定条件格納用
        Dim lstrEnableMode          As String   '変更後(装置状態)ｾｯﾄ時の条件格納用

        Try

            '@変更後(装置状態)ｺﾝﾎﾞ
            With cmbUseName

                .Clear                                                          '初期化
                .Height = CMlngCmbRowHeight                                     '高さ
                .RowHeight = CMlngCmbRowHeight                                  '高さ(行)
                .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                With .Font                                                      'ﾌｫﾝﾄｻｲｽﾞ
                    cmbUseName.Font = New Font(.FontFamily, CMlngCmbFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                With .GridFont                                                  'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    cmbUseName.GridFont = New Font(.FontFamily, CMlngCmbGridFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .ValueCol = CMlngCmbValueCol1                                   '値取得列
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .GroupCols = CMlngCmbDispCols1                                  '行表示方式：1行

                '@変更後(装置状態)ｺﾝﾎﾞのﾃﾞｰﾀが格納されているか
                If mlngUseListCnt < 0 Then
                    Exit Sub
                End If

                '@変更後運用ﾓｰﾄﾞが選択されているか
                If vsfModeList.Row > 0 Then

                    '@変更後運用ﾓｰﾄﾞのﾊﾞｯｸｶﾗｰが白(変更可)か
                    If vsfModeList.GetCellRange(vsfModeList.Row, vsfModeList.Col).StyleDisplay.BackColor = Color.White Then
                        '@ﾓｰﾄﾞ選択、背景白
                        '@ ⇒Select条件として選択運用ﾓｰﾄﾞをｷｰにする(1をｾｯﾄ)
                        llngSelectFlag = CPlngNumOne
                        lstrSelectCondition = vsfModeList.GetData(vsfModeList.Row, 0)
                    Else
                        '@ﾓｰﾄﾞ選択、背景ｸﾞﾚｰ
                        '@ ⇒Select条件として現在の運用ﾓｰﾄﾞをｷｰにする(2をｾｯﾄ)
                        llngSelectFlag = CPlngNumTwo
                        lstrSelectCondition = mtypEqstate.strMesModeId
                    End If
                Else
                    '@変更後運用ﾓｰﾄﾞが未選択の場合
                    '@ ⇒Select条件として現在の運用ﾓｰﾄﾞをｷｰにする(3をｾｯﾄ)
                    llngSelectFlag = CPlngNumThree
                    lstrSelectCondition = mtypEqstate.strMesModeId
                End If


                '@★ ﾓｰﾄﾞ選択・変更可能ﾓｰﾄﾞかにより処理分岐 ★
                Select Case lstrSelectCondition

                    '@〓 変更後(or現在の)運用ﾓｰﾄﾞが"M1" 〓
                    Case CPstrM1

                        '@"M1"を判定条件にする
                        lstrEnableMode = CPstrM1

                    '@〓 変更後(or現在の)運用ﾓｰﾄﾞが"S1" 〓
                    Case CPstrS1

                        '@"S1"を判定条件にする
                        lstrEnableMode = CPstrS1

                    '@〓 変更後(or現在の)運用ﾓｰﾄﾞが"S2" 〓
                    Case CPstrS2

                        '@"S2"を判定条件にする
                        lstrEnableMode = CPstrS2

                    '@〓 変更後(or現在の)運用ﾓｰﾄﾞが"F" 〓
                    Case CPstrF

                        '@"F"を判定条件にする
                        lstrEnableMode = CPstrF

                End Select

                For llngCnt = 0 To mlngUseListCnt - 1

                    '@ENABLE_MODEに"lstrEnableMode"(=判定条件運用ﾓｰﾄﾞ)が含まれているか
                    If InStr(1, mtypUseList(llngCnt).strUseEnableMode, lstrEnableMode) <> 0 Then
                        '@含まれている場合、各運用ﾓｰﾄﾞにて選択可能な装置状態のみ設定

                        '@***************************
                        '@ 変更後(装置状態)ｺﾝﾎﾞ作成
                        '@***************************
                        '@装置状態名/装置状態ID/変更可能ﾓｰﾄﾞ/停止ﾌﾗｸﾞ
                        .AddItem(mtypUseList(llngCnt).strUseName & vbTab & _
                                 mtypUseList(llngCnt).strUseId & vbTab & _
                                 mtypUseList(llngCnt).strUseEnableMode & vbTab & _
                                 mtypUseList(llngCnt).strUseStopFlag)

                    End If
                Next llngCnt

                '@変更後装置状態ｺﾝﾎﾞが1件の場合
                If .ListCount = 1 Then
                    '@1件目表示
                    .ListIndex = 0
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbUseName_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbRecipeGroup_Disp
    '機　能：ﾚｼﾋﾟｸﾞﾙｰﾌﾟｺﾝﾎﾞ作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/10/15 (Mon) 12:00:35 N.Kojima
    '更新日：2010/03/10 (Wed) 18:02:54 N.Kojima
    '備　考：
    '　　　：2010/03/10 (Wed) 18:02:54 N.Kojima     案件№03897対応中にｲﾝﾃﾞｯｸｽｴﾗｰになる件が発覚したので修正。
    Private Sub prvCmbRecipeGroup_Disp()

        Dim llngCnt         As Integer      'ｶｳﾝﾄ
        Dim lstrCheckFlag   As String       'ﾁｪｯｸ制御用変数(0：ﾁｪｯｸOFF、1：ﾁｪｯｸON)

        Try

            '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟ選択数の初期化
            mlngSelectRecipeGroupCnt = 0
            mtypCheckRecipeGroup = New List(Of CheckRecipeGroup)

            '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟｺﾝﾎﾞ
            With cmbRecipeGroup

                .Clear                                                          'ｸﾘｱ
                .DirectInput = False                                            '直接入力(False)
                .AllSelectButton = False                                        '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol1                                   'ｸﾞﾘｯﾄﾞ値取得列数
                .GroupCols = CMlngCmbGroupCols                                  '列方向のﾚｺｰﾄﾞ数
                With .Font                                                      'ﾌｫﾝﾄｻｲｽﾞ
                    cmbRecipeGroup.Font = New Font(.FontFamily, CMlngCmbFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                With .GridFont                                                  'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    cmbRecipeGroup.GridFont = New Font(.FontFamily, CMlngCmbGridFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え

                '@変更後処理順指定が"ﾚｼﾋﾟ(固定)"の場合
                If cmbRecipeFlow.Text = CPstrRecipeFlowGroup Or _
                    cmbRecipeFlow.Text = CPstrRecipeFlowGroupSameNG Then
                     
                    .SelectMode = CMlngCMbSelectMode                            '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                Else
                    .SelectMode = CMlngCmbNotSelectMode                         '選択ﾓｰﾄﾞ(単数選択ﾓｰﾄﾞ=0)
                End If

                If mtypEqstate.lngCollectTypeListCnt > 0 Then

                    For llngCnt = 0 To mtypEqstate.lngCollectTypeListCnt - 1

                        '@変更後処理順指定が「ﾚｼﾋﾟ(固定)」OR「ﾚｼﾋﾟ(固定)限定」か
                        If cmbRecipeFlow.Text = CPstrRecipeFlowGroup Or _
                            cmbRecipeFlow.Text = CPstrRecipeFlowGroupSameNG Then
                            '@変更後処理順指定が「ﾚｼﾋﾟ(固定)」OR「ﾚｼﾋﾟ(固定)限定」の場合

                            '@ﾕｰｻﾞｰ選択項目か
                            If mtypEqstate.typCollectTypeList(llngCnt).strUserSelectFlag = CPstrOne Then
                                '@ﾕｰｻﾞｰ選択項目の場合

                                '@**********************
                                '@ ﾚｼﾋﾟｸﾞﾙｰﾌﾟｺﾝﾎﾞ作成
                                '@**********************
                                '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟ名/ｲﾝﾃﾞｯｸｽ/ﾁｪｯｸON
                                .AddItem(mtypEqstate.typCollectTypeList(llngCnt).strCollectTypeName & vbTab & _
                                         mtypEqstate.typCollectTypeList(llngCnt).strCollectTypeNum & vbTab & _
                                         (llngCnt + 1) & vbTab & _
                                         vbNullString & vbTab & _
                                         CMstrCmbCheckOn)

                                '@ﾁｪｯｸｶｳﾝﾀを+1する
                                mlngSelectRecipeGroupCnt = mlngSelectRecipeGroupCnt + 1

                                '@変更ﾁｪｯｸ用にﾁｪｯｸ項目を格納
                                Dim ltypCheckRecipeGroupTmp As New CheckRecipeGroup
                                ltypCheckRecipeGroupTmp.strCollectTypeName = _
                                    mtypEqstate.typCollectTypeList(llngCnt).strCollectTypeName          'ﾚｼﾋﾟｸﾞﾙｰﾌﾟ名
                                ltypCheckRecipeGroupTmp.strCollectTypeNum = _
                                    mtypEqstate.typCollectTypeList(llngCnt).strCollectTypeNum           'ﾚｼﾋﾟｸﾞﾙｰﾌﾟ番号(ID)

                                mtypCheckRecipeGroup.Add(ltypCheckRecipeGroupTmp)
                            Else
                                '@ﾕｰｻﾞｰ選択項目以外の場合

        '@↓2010/03/10 (Wed) 18:06:06 N.Kojima **************************************************

                                '@**********************
                                '@ ﾚｼﾋﾟｸﾞﾙｰﾌﾟｺﾝﾎﾞ作成
                                '@**********************
                                '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟ数が1件か
                                If mtypEqstate.lngCollectTypeListCnt = 1 Then

                                    '@ﾁｪｯｸ制御ﾌﾗｸﾞに"1：ﾁｪｯｸON"をｾｯﾄ
                                    lstrCheckFlag = CPstrOne
                                Else
                                    '@ﾁｪｯｸ制御ﾌﾗｸﾞに"0：ﾁｪｯｸOFF"をｾｯﾄ
                                    lstrCheckFlag = CPstrZero
                                End If

                                '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟ名/ｲﾝﾃﾞｯｸｽ/ﾁｪｯｸON or OFF
                                .AddItem(mtypEqstate.typCollectTypeList(llngCnt).strCollectTypeName & vbTab & _
                                         mtypEqstate.typCollectTypeList(llngCnt).strCollectTypeNum & vbTab & _
                                         (llngCnt + 1) & vbTab & _
                                         vbNullString & vbTab & _
                                         lstrCheckFlag)

        '@↑2010/03/10 (Wed) 18:06:06 N.Kojima **************************************************

                            End If

                            .GroupRows = llngCnt + 1    '行方向のﾚｺｰﾄﾞ数
                        Else
                            '@変更後処理順指定が「ﾚｼﾋﾟ(固定)」OR「ﾚｼﾋﾟ(固定)限定」以外の場合

                            '@ﾕｰｻﾞｰ選択項目か
                            If mtypEqstate.typCollectTypeList(llngCnt).strUserSelectFlag = CPstrOne Then
                                '@ﾕｰｻﾞｰ選択項目の場合

                                '@**********************
                                '@ ﾚｼﾋﾟｸﾞﾙｰﾌﾟｺﾝﾎﾞ作成
                                '@**********************
                                '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟ名/ｲﾝﾃﾞｯｸｽ/ﾁｪｯｸON
                                .AddItem(mtypEqstate.typCollectTypeList(llngCnt).strCollectTypeName & vbTab & _
                                         mtypEqstate.typCollectTypeList(llngCnt).strCollectTypeNum & vbTab & _
                                         llngCnt & vbTab & _
                                         vbNullString & vbTab & _
                                         CMstrCmbCheckOn)

                                '@ﾁｪｯｸｶｳﾝﾀを+1する
                                mlngSelectRecipeGroupCnt = mlngSelectRecipeGroupCnt + 1

                                '@変更ﾁｪｯｸ用にﾁｪｯｸ項目を格納
                                Dim ltypCheckRecipeGroupTmp As New CheckRecipeGroup
                                ltypCheckRecipeGroupTmp.strCollectTypeName = _
                                    mtypEqstate.typCollectTypeList(llngCnt).strCollectTypeName          'ﾚｼﾋﾟｸﾞﾙｰﾌﾟ名
                                ltypCheckRecipeGroupTmp.strCollectTypeNum = _
                                    mtypEqstate.typCollectTypeList(llngCnt).strCollectTypeNum           'ﾚｼﾋﾟｸﾞﾙｰﾌﾟ番号(ID)

                                mtypCheckRecipeGroup.Add(ltypCheckRecipeGroupTmp)

                                .GroupRows = mlngSelectRecipeGroupCnt    '行方向のﾚｺｰﾄﾞ数
                            End If
                        End If
                    Next llngCnt
                End If

                '@初期表示
                .AddedComment = CMstrCmbAddedComment                            '"XX 項目選択"
                .Text = CStr(mlngSelectRecipeGroupCnt) & CMstrCmbAddedComment   'XX部に項目数を格納

                '@初期の表示件数を覚えておく
                mstrSelectRecipeCnt = .Text

                '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟが1件の場合
                If .ListCount = 1 Then
                    '@1件目表示
                    .ListIndex = 0
                    .Text = CPstrOne & CMstrCmbAddedComment     'XX部に項目数を格納
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbRecipeGroup_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvChkMessage_Disp
    '機　能：ﾒｯｾｰｼﾞ表示ﾁｪｯｸﾎﾞｯｸｽ　表示制御
    '引　数：なし
    '戻り値：なし
    '作成日：2006/01/10 (Tue) 13:57:16 N.Kasai
    '更新日：2006/01/10 (Tue) 13:57:16
    '備　考：ｺﾝﾎﾞChangeとValidateに記述あり
    Private Sub prvChkMessage_Disp()

        Dim llngCnt             As Integer      'ｶｳﾝﾀ
        Dim lstrUseID           As String       '装置状態ID格納
        Dim lstrNormalStateFlag As String       '装置状態通常ﾌﾗｸﾞ格納(0:通常以外、1:通常)

        Try

            '@変更後(装置状態)ｺﾝﾎﾞの装置状態IDを退避
            cmbUseName.ValueCol = CMlngCmbValueCol1
            lstrUseID = cmbUseName.Value

            '@装置状態検索
            For llngCnt = 0 To mlngUseListCnt - 1

                '@取得情報の中から、選択された装置状態IDを検索
                If mtypUseList(llngCnt).strUseId = lstrUseID Then

                    '@装置状態通常ﾌﾗｸﾞの判定用(0:通常以外、1:通常)
                    lstrNormalStateFlag = mtypUseList(llngCnt).strNormalStateFlag

                    '@装置状態通常ﾌﾗｸﾞが"1:通常"か(0:通常以外、1:通常)
                    If lstrNormalStateFlag = CMstrNormalStateFlag Then

                        '@ﾒｯｾｰｼﾞﾁｪｯｸﾎﾞｯｸｽ制御
                        With chkMessage
                            .Checked = True         'ﾁｪｯｸ状態
                            .Enabled = False        '無効
                        End With
                    Else
                        '@"1:通常"以外の場合

                        '@変更前(装置状態)と変更後(装置状態)が同じか
                        If cmbUseName.Text = lblUseName.Text Then

                            '@ﾒｯｾｰｼﾞﾁｪｯｸﾎﾞｯｸｽ制御
                            With chkMessage
                                .Checked = False    '未ﾁｪｯｸ状態
                                .Enabled = False    '無効
                            End With
                        Else
                            '@変更前(装置状態)と変更後(装置状態)が異なる場合

                            '@ﾒｯｾｰｼﾞﾁｪｯｸﾎﾞｯｸｽ制御
                            With chkMessage
                                .Checked = True     'ﾁｪｯｸ状態
                                .Enabled = True     '有効
                            End With
                        End If
                    End If

                    '@一致した場合はﾙｰﾌﾟ抜け
                    Exit For
                End If
            Next llngCnt

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvChkMessage_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnMessage_Chk
    '機　能：装置状態ﾒｯｾｰｼﾞ表示処理
    '引　数：lstrUseID          ：用途ID
    '　　　：lstrNormalStateFlag：装置状態通常ﾌﾗｸﾞ
    '　　　：lstrMessageID      ：ﾒｯｾｰｼﾞID
    '戻り値：True：成功、False：失敗
    '作成日：2005/12/16 (Fri) 16:23:25 N.Kasai
    '更新日：2005/12/16 (Fri) 16:23:25
    '備　考：
    Private Function prvblnMessage_Chk(ByVal lstrUseID As String, _
                                       ByRef lstrNormalStateFlag As String, _
                                       ByRef lstrMessageID As String) As Boolean

        Dim llngCnt     As Integer  'ｶｳﾝﾀ
        Dim lblnAns     As Boolean  '戻り値

        Try

            '@戻り値の初期化
            prvblnMessage_Chk = False

            '@装置状態検索
            For llngCnt = 0 To mlngUseListCnt - 1

                '@取得情報の装置状態IDと選択された装置状態IDが同じか
                If mtypUseList(llngCnt).strUseId = lstrUseID Then
                    '@同じ場合

                    '@戻り値に"True:OK"をｾｯﾄ
                    prvblnMessage_Chk = True

                    '@ﾃﾞｰﾀ格納
                    lstrNormalStateFlag = mtypUseList(llngCnt).strNormalStateFlag   '装置状態通常ﾌﾗｸﾞの判定(0:通常以外、1:通常)
                    lstrMessageID = mtypUseList(llngCnt).strMessageID               'ﾒｯｾｰｼﾞID

                    '@装置状態通常ﾌﾗｸﾞが"1:通常"か(0:通常以外、1:通常)
                    If mtypUseList(llngCnt).strNormalStateFlag = CMstrNormalStateFlag Then

                        '@ﾒｯｾｰｼﾞIDにNULLをｾｯﾄ
                        lstrMessageID = vbNullString

                        '@ﾒｯｾｰｼﾞ表示がﾁｪｯｸ状態か
                        If chkMessage.Checked = True Then

                            '@=======================
                            '@ ﾒｯｾｰｼﾞ状態取得処理
                            '@=======================
                            lblnAns = prvblnWpMsg_Disp()

                            '@通信結果判定
                            If lblnAns = False Then
                                '@結果：異常の場合

                                '@戻り値に"False:NG"をｾｯﾄ
                                prvblnMessage_Chk = False
                            End If
                        End If

                        '@処理抜け
                        Exit For
                    Else
                        '@ﾒｯｾｰｼﾞ表示がﾁｪｯｸ状態か
                        If chkMessage.Checked = True Then

                            '@ﾒｯｾｰｼﾞIDが格納されているか
                            If mtypUseList(llngCnt).strMessageID <> vbNullString Then

                                '@表示ﾒｯｾｰｼﾞ変換
                                '@「"<TRM28I>$$アナウンスメッセージ表示を設定します。$状態を[通常]に変更した際に、
                                '@　メッセージが表示されます。$$[メッセージ内容]$%1"」のﾒｯｾｰｼﾞ表示
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0028, mtypUseList(llngCnt).strMessage)
                                Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                            End If
                        Else
                            '@ﾒｯｾｰｼﾞ表示が未ﾁｪｯｸ状態の場合

                            '@ﾒｯｾｰｼﾞ非表示の場合(ﾒｯｾｰｼﾞIDは送信しない)
                            lstrMessageID = vbNullString
                        End If

                        '@処理抜け
                        Exit For
                    End If
                End If
            Next llngCnt

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnMessage_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnWpMsg_Disp
    '機　能：装置状態ﾒｯｾｰｼﾞ表示処理
    '引　数：なし
    '戻り値：True：成功、False：失敗
    '作成日：2005/12/19 (Mon) 15:14:12 N.Kasai
    '更新日：2005/12/19 (Mon) 15:14:12
    '備　考：装置状態が「通常」&「ﾒｯｾｰｼﾞ表示」を選択された場合のみﾒｯｾｰｼﾞﾎﾞｯｸｽを表示する。
    Private Function prvblnWpMsg_Disp() As Boolean

        Dim lblnAns                 As Boolean              '結果格納
        Dim ltypEqWpMsgListReq      As EqWpMsgListReq       '要求構造体
        Dim ltypEqWpMsgListAns      As EqWpMsgListAns       '応答構造体
        Dim llngCnt                 As Integer              'ｶｳﾝﾄ

        Try

            '@戻り値の初期化
            prvblnWpMsg_Disp = False

            '@***********************
            '@ 要求ﾃﾞｰﾀ作成
            '@***********************
            With ltypEqWpMsgListReq
                .strMsgVer = CMstreq__wpmsglistVer          'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strWpID = cmbWp.Value                      '装置ID
            End With

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvblnWpMsgDisp)

            '@【装置状態ﾒｯｾｰｼﾞ取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnEqWpMsgList_Sel(ltypEqWpMsgListReq, _
                                            ltypEqWpMsgListAns)

            '@通信結果格納
            If lblnAns = True Then
                '@結果：正常の場合

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrPrvblnWpMsgDisp)

                '@戻り値に"True:取得成功"をｾｯﾄ
                prvblnWpMsg_Disp = True

                '@ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示(件数分ﾒｯｾｰｼﾞﾎﾞｯｸｽを表示します。)
                With ltypEqWpMsgListAns

                    '@取得件数判定
                    If .llngMsgListCnt > 0 Then

                        '@取得ｶｳﾝﾄ分ﾙｰﾌﾟ
                        For llngCnt = 0 To .llngMsgListCnt - 1

                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「"<TRM35I>$$アナウンスメッセージが設定されています。$$[メッセージ内容]$%1"」のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0035, ltypEqWpMsgListAns.typMsgList(llngCnt).strMessage)
                            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                        Next llngCnt
                    End If
                End With
            Else
                '@結果：異常の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvblnWpMsgDisp)
            End If

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "CMstrPrvblnWpMsgDisp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnCmdChangeTrnst_Chk
    '機　能：搬送ﾎﾟｰﾄ変更ﾁｪｯｸ
    '引　数：なし
    '戻り値：True：OK、False：NG
    '作成日：2005/12/21 (Wed) 16:02:18 N.Kasai
    '更新日：2005/12/21 (Wed) 16:02:18
    '備　考：
    Private Function prvblnCmdChangeTrnst_Chk() As Boolean

        Dim llngCnt             As Integer  'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngNgCnt           As Integer  '「不可能」ﾎﾟｰﾄ数
        Dim lblnChangeChk       As Boolean  '変更可否ﾁｪｯｸﾌﾗｸﾞ(True:変更あり、False:変更なし)

        Try

            '@戻り値の初期化
            prvblnCmdChangeTrnst_Chk = False

            With vsfPortNoList

                '@ﾎﾟｰﾄがない場合はｴﾗｰ
                If .Rows.Count = .Rows.Fixed Then
                    Exit Function
                End If
            End With

            '@変更可否ﾁｪｯｸﾌﾗｸﾞの初期化
            lblnChangeChk = False

            '@「不可能」ﾎﾟｰﾄ数ｶｳﾝﾀの初期化
            llngNgCnt = 0

            '@装置ﾎﾟｰﾄ一覧ｸﾞﾘｯﾄﾞの搬送ｻｰﾋﾞｽ状態をﾁｪｯｸする
            With vsfPortNoList

                For llngCnt = 1 To .Rows.Count - 1

                    '@搬送ｻｰﾋﾞｽ状態の変更前と変更後が異なるか
                    If .GetData(llngCnt, CMlngvsfLColTransService) <> _
                        .GetData(llngCnt, CMlngvsfLColTransServiceID) Then
                        '@異なる場合

                        '@変更可否ﾁｪｯｸﾌﾗｸﾞに"True:変更あり"をｾｯﾄ
                        lblnChangeChk = True
                    End If

                    '@搬送ｻｰﾋﾞｽ状態が「不可能」であるﾎﾟｰﾄ数をｶｳﾝﾄ
                    If .GetData(llngCnt, CMlngvsfLColTransService) = CMstrTransServiceStatusNG Then
                        llngNgCnt = llngNgCnt + 1
                    End If
                Next llngCnt

                '@変更ありの場合
                If lblnChangeChk = True Then

                    '@全ﾎﾟｰﾄ「不可能」ではないか
                    If llngNgCnt <> .Rows.Count - 1 Then
                        '@1ﾎﾟｰﾄでも変更可能なﾎﾟｰﾄがある場合

                        '@戻り値に"True:OK(使用可能)"をｾｯﾄ
                        prvblnCmdChangeTrnst_Chk = True
                    End If
                End If
            End With

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnCmdChangeTrnst_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnCmdChangeChamber_Chk
    '機　能：処理部用途/状態変更ﾁｪｯｸ
    '引　数：なし
    '戻り値：True：OK、False：NG
    '作成日：2006/11/20 (Mon) 14:54:05 N.Kasai
    '更新日：2006/11/20 (Mon) 14:54:05
    '備　考：
    Private Function prvblnCmdChangeChamber_Chk() As Boolean

        Dim llngCnt             As Integer  'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lblnChangeChk       As Boolean  '変更可否ﾁｪｯｸﾌﾗｸﾞ(True:変更あり、False:変更なし)

        Try

            '@戻り値の初期化
            prvblnCmdChangeChamber_Chk = False

            With vsfChamberList

                '@ﾁｬﾝﾊﾞｰがない場合はｴﾗｰとする。
                If .Rows.Count = .Rows.Fixed Then
                    Exit Function
                End If
            End With

            '@変更可否ﾁｪｯｸﾌﾗｸﾞの初期化
            lblnChangeChk = False

            '@装置処理部用途/状態一覧ｸﾞﾘｯﾄﾞの状態をﾁｪｯｸする
            With vsfChamberList

                For llngCnt = 1 To .Rows.Count - 1

                    '@処理部用途の変更前と変更後が異なるか
                    If Trim$(.GetDataDisplay(llngCnt, CMlngvsfCColProcessingName)) <> _
                        Trim$(.GetData(llngCnt, CMlngvsfCColOldProcessingName)) Then
                        '@異なる場合

                        '@変更可否ﾁｪｯｸﾌﾗｸﾞに"True:変更あり"をｾｯﾄ
                        lblnChangeChk = True
                        Exit For
                    End If

                    '@処理部状態の変更前と変更後が異なるか
                    If .GetData(llngCnt, CMlngvsfCColUseName) <> _
                        .GetData(llngCnt, CMlngvsfCColOldUseID) Then
                        '@異なる場合

                        '@変更可否ﾁｪｯｸﾌﾗｸﾞに"True:変更あり"をｾｯﾄ
                        lblnChangeChk = True
                        Exit For
                    End If
                Next llngCnt
            End With

            '@変更可否ﾁｪｯｸﾌﾗｸﾞが"True:変更あり"か
            If lblnChangeChk = True Then
                '@戻り値に"True:変更あり"をｾｯﾄ
                prvblnCmdChangeChamber_Chk = True
            End If

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnCmdChangeChamber_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvCmdChangeProcOrderEnable_Set
    '機　能：処理順指定変更ﾎﾞﾀﾝ　制御処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/28 (Mon) 16:19:01 T.Kitagawa
    '更新日：2009/10/22 (Thu) 10:40:58 T.Oide
    '備　考：
    '　　　：2007/10/16 (Tue) 10:24:36 N.Kojima     ﾚｼﾋﾟｸﾞﾙｰﾌﾟ追加に伴い、処理追加。(案件№02152)
    '　　　：2009/10/20 (Tue) 10:26:59 T.Oide       搬送モード追加(案件№03761)
    Private Sub prvCmdChangeProcOrderEnable_Set()

        Dim lblntxtRecipeFlowNumChkFlag     As Boolean      '処理ﾛｯﾄ数ﾁｪｯｸ(False:ｴﾗｰ、True：正常)
        Dim lblnCmbRecipeGroupChkFlag       As Boolean      'ﾚｼﾋﾟｸﾞﾙｰﾌﾟﾁｪｯｸ(False:ｴﾗｰ、True：正常)
        Dim llngCnt                         As Integer      '汎用ｶｳﾝﾀ
        Dim llngSelectCnt                   As Integer      'ﾚｼﾋﾟｸﾞﾙｰﾌﾟ選択ｶｳﾝﾀ
        Dim llngMatchCnt                    As Integer      '同一選択項目判定用ｶｳﾝﾀ
        Dim lvrnTemp                        As Object       '一時保管用変数

        Try

            '@ﾁｪｯｸﾌﾗｸﾞの初期化
            lblntxtRecipeFlowNumChkFlag = False     '処理ﾛｯﾄ数ﾁｪｯｸ用ﾌﾗｸﾞ
            lblnCmbRecipeGroupChkFlag = False       'ﾚｼﾋﾟｸﾞﾙｰﾌﾟﾁｪｯｸ用ﾌﾗｸﾞ

            '@変更後処理順指定が選択されているか
            If cmbRecipeFlow.Text <> vbNullString Then

                '@★ 選択された処理順指定により処理分岐 ★
                Select Case cmbRecipeFlow.Text

                    '@〓 FIFO(到着順) OR FIFO(到着順)限定 〓
                    Case CPstrRecipeFlowFifo, CPstrRecipeFlowFifoSameNG

                        '@現在と変更後の処理順ﾙｰﾙが異なるか
                        If cmbRecipeFlow.Text <> lblBeforeRecipeFlow.Text Then
                            '@異なる場合

                            '@処理部用途/状態変更ﾎﾞﾀﾝを有効にする
                            cmdChangeProcOrder.Enabled = True
                        End If


                    '@〓 ﾚｼﾋﾟ(切替) OR ﾚｼﾋﾟ(切替)限定 〓
                    Case CPstrRecipeFlowNum, CPstrRecipeFlowNumSameNG

                        '@処理ﾛｯﾄ数が数値か
                        If IsNumeric(txtRecipeFlowNum.Text) = True Then

                            '@現在と変更後の処理順ﾙｰﾙが異なり、かつ処理ﾛｯﾄ数が1以上か
                            If cmbRecipeFlow.Text <> lblBeforeRecipeFlow.Text And _
                                CLng(txtRecipeFlowNum.Text) > 0 Then

                                '@処理ﾛｯﾄ数ﾁｪｯｸﾌﾗｸﾞに"True:変更あり"をｾｯﾄ
                                lblntxtRecipeFlowNumChkFlag = True
                            Else
                                '@処理順ﾙｰﾙが同じ場合(｢ﾚｼﾋﾟ(固定)→ﾚｼﾋﾟ(固定)｣ または ｢ﾚｼﾋﾟ(固定)限定｣→「ﾚｼﾋﾟ(固定)限定」)

                                '@処理ﾛｯﾄ数が1以上で、かつ変更前と変更後の処置順指定が異なるか
                                If CLng(txtRecipeFlowNum.Text) > 0 And _
                                    txtRecipeFlowNum.Text <> lblBeforeRecipeFlowNum.Text Then

                                    '@処理ﾛｯﾄ数ﾁｪｯｸﾌﾗｸﾞに"True:変更あり"をｾｯﾄ
                                    lblntxtRecipeFlowNumChkFlag = True
                                Else
                                    '@処理ﾛｯﾄ数ﾁｪｯｸﾌﾗｸﾞに"False:変更なし"をｾｯﾄ
                                    lblntxtRecipeFlowNumChkFlag = False
                                End If
                            End If
                        Else
                            '@処理ﾛｯﾄ数ﾁｪｯｸﾌﾗｸﾞに"False:変更なし"をｾｯﾄ
                            lblntxtRecipeFlowNumChkFlag = False
                        End If


                        '@処理ﾛｯﾄ数のﾁｪｯｸﾌﾗｸﾞが"True:変更あり"か
                        If lblntxtRecipeFlowNumChkFlag = True Then

                            '@処理部用途/状態変更ﾎﾞﾀﾝを有効にする
                            cmdChangeProcOrder.Enabled = True
                        Else

                            '@処理部用途/状態変更ﾎﾞﾀﾝを無効にする
                            cmdChangeProcOrder.Enabled = False
                        End If


                    '@〓 ﾚｼﾋﾟ(固定) OR ﾚｼﾋﾟ(固定)限定 〓
                    Case CPstrRecipeFlowGroup, CPstrRecipeFlowGroupSameNG

                        '@"0 項目選択" OR NULL 以外か
                        If cmbRecipeGroup.Text <> CMstrCmbAddedCommentNone And _
                            cmbRecipeGroup.Text <> vbNullString Then

                            '@変更前と変更後の処置順指定が同じか
                            If cmbRecipeFlow.Text = lblBeforeRecipeFlow.Text Then
                                '@同じ場合は、選択ﾚｼﾋﾟｸﾞﾙｰﾌﾟが違っていないかﾁｪｯｸ

                                '@選択ﾚｼﾋﾟｸﾞﾙｰﾌﾟの件数ｶｳﾝﾄ
                                lvrnTemp = Split(cmbRecipeGroup.Value, vbTab)
                                For llngCnt = LBound(lvrnTemp) To UBound(lvrnTemp)
                                    '@空ﾙｰﾌﾟ
                                Next llngCnt

                                '@初期化
                                llngMatchCnt = 0

                                '@同一選択数の場合
                                If llngCnt = mlngSelectRecipeGroupCnt Then
                                    '@現在の選択数分ﾙｰﾌﾟ
                                    For llngCnt = LBound(lvrnTemp) To UBound(lvrnTemp)
                                        '@変更前の選択数分ﾙｰﾌﾟ
                                        For llngSelectCnt = 0 To mlngSelectRecipeGroupCnt - 1
                                            '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟ番号が同じか
                                            If mtypCheckRecipeGroup(llngSelectCnt).strCollectTypeNum = _
                                                lvrnTemp(llngCnt) Then

                                                '@同一選択項目判定用ｶｳﾝﾀを+1
                                                llngMatchCnt = llngMatchCnt + 1
                                            End If
                                        Next llngSelectCnt
                                    Next llngCnt
                                End If

                                '@選択ﾚｼﾋﾟｸﾞﾙｰﾌﾟが同じ場合
                                If llngMatchCnt = mlngSelectRecipeGroupCnt Then
                                    '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟﾁｪｯｸﾌﾗｸﾞに"False:変更なし"をｾｯﾄ
                                    lblnCmbRecipeGroupChkFlag = False
                                Else
                                    '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟﾁｪｯｸﾌﾗｸﾞに"True:変更あり"をｾｯﾄ
                                    lblnCmbRecipeGroupChkFlag = True
                                End If
                            Else
                                '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟﾁｪｯｸﾌﾗｸﾞに"True:変更あり"をｾｯﾄ
                                lblnCmbRecipeGroupChkFlag = True
                            End If
                        Else
                            '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟﾁｪｯｸﾌﾗｸﾞに"False:変更なし"をｾｯﾄ
                            lblnCmbRecipeGroupChkFlag = False
                        End If


                        '@ﾚｼﾋﾟｸﾞﾙｰﾌﾟのﾁｪｯｸﾌﾗｸﾞが"True:変更あり"か
                        If lblnCmbRecipeGroupChkFlag = True Then

                            '@処理部用途/状態変更ﾎﾞﾀﾝを有効にする
                            cmdChangeProcOrder.Enabled = True
                        Else
                            '@処理部用途/状態変更ﾎﾞﾀﾝを無効にする
                            cmdChangeProcOrder.Enabled = False
                        End If

                End Select
            Else
                '@処理部用途/状態変更ﾎﾞﾀﾝを無効にする
                cmdChangeProcOrder.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmdChangeProcOrderEnable_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvColorChang_Proc
    '機　能：ﾗﾍﾞﾙ&ｸﾞﾘｯﾄﾀｲﾄﾙ行の色変え処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/28 (Wed) 13:40:10 N.Kojima
    '更新日：2006/08/28 (Mon) 14:35:05 T.Kitagawa
    '備　考：
    '　　　：2006/08/28 (Mon) 14:35:05 T.Kitagawa   ﾌｫﾄのTAT改善に伴う処理順指定追加(案件№01097)
    Private Sub prvColorChang_Proc()

        Try

            '@ﾃﾞﾌｫﾙﾄ装置以外(pstrTerminalFlag="1"orNULL)か
            If pstrTerminalFlag <> CPstrZero Then

                '@全てのｺﾝﾄﾛｰﾙのﾀｲﾄﾙを赤にする
                lblMcGroupNameTitle.BackColor =  ColorTranslator.FromWin32(CMlngRedColor)       '装置ｸﾞﾙｰﾌﾟ
                lblWpIDTitle.BackColor =  ColorTranslator.FromWin32(CMlngRedColor)              '装置名
                lblNowDateTitle.BackColor =  ColorTranslator.FromWin32(CMlngRedColor)           '情報取得日時
                lblWpStatusNameTitle.BackColor =  ColorTranslator.FromWin32(CMlngRedColor)      '処理状態
                lblM1AfterModeTitle.BackColor =  ColorTranslator.FromWin32(CMlngRedColor)       '運用状態
                lblBeforeModeTitle.BackColor =  ColorTranslator.FromWin32(CMlngRedColor)        '現在の運用ﾓｰﾄﾞ
                lblUseNameTitle.BackColor =  ColorTranslator.FromWin32(CMlngRedColor)           '現在の装置状態
                lblCmbUseNameTitle.BackColor =  ColorTranslator.FromWin32(CMlngRedColor)        '変更後
                lblBeforeRecipeFlowTitle.BackColor =  ColorTranslator.FromWin32(CMlngRedColor)  '現在の処理順指定
                lblAfterRecipeFlowTitle.BackColor =  ColorTranslator.FromWin32(CMlngRedColor)   '変更後の処理順指定
                lblWorkMemoTitle.BackColor =  ColorTranslator.FromWin32(CMlngRedColor)          '作業ﾒﾓ

                '@装置ﾎﾟｰﾄ状態
                With vsfPortNoList
                    '@一覧表の表題設定
                    Dim lFixedStyle As CellStyle
                    lFixedStyle = .Styles.Fixed
                    lFixedStyle.ForeColor = Color.Yellow                                        '文字色
                    lFixedStyle.BackColor = ColorTranslator.FromWin32(CMlngRedColor)            '背景色
                End With

                '@運用ﾓｰﾄﾞ一覧
                With vsfModeList
                    '@一覧表の表題設定
                    Dim lFixedStyle As CellStyle
                    lFixedStyle = .Styles.Fixed
                    lFixedStyle.ForeColor = Color.Yellow                                        '文字色
                    lFixedStyle.BackColor = ColorTranslator.FromWin32(CMlngRedColor)            '背景色
                End With

                '@装置処理部用途/状態一覧
                With vsfChamberList
                    '@一覧表の表題設定
                    Dim lFixedStyle As CellStyle
                    lFixedStyle = .Styles.Fixed
                    lFixedStyle.ForeColor = Color.Yellow                                        '文字色
                    lFixedStyle.BackColor = ColorTranslator.FromWin32(CMlngRedColor)            '背景色
                End With

            Else
                '@ﾃﾞﾌｫﾙﾄ装置(pstrTerminalFlag="0")の場合

                '@全てのｺﾝﾄﾛｰﾙのﾀｲﾄﾙを青にする
                lblMcGroupNameTitle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)       '装置ｸﾞﾙｰﾌﾟ
                lblWpIDTitle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)              '装置名
                lblNowDateTitle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)           '情報取得日時
                lblWpStatusNameTitle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)      '処理状態
                lblM1AfterModeTitle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)       '運用状態
                lblBeforeModeTitle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)        '現在の運用ﾓｰﾄﾞ
                lblUseNameTitle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)           '現在の装置状態
                lblCmbUseNameTitle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)        '変更後
                lblBeforeRecipeFlowTitle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)  '現在の処理順指定
                lblAfterRecipeFlowTitle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)   '変更後の処理順指定
                lblWorkMemoTitle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)          '作業ﾒﾓ

                '@装置ﾎﾟｰﾄ状態
                With vsfPortNoList
                    '@一覧表の表題設定
                    Dim lFixedStyle As CellStyle
                    lFixedStyle = .Styles.Fixed
                    lFixedStyle.ForeColor = Color.Yellow                                        '文字色
                    lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)           '背景色
                End With

                '@運用ﾓｰﾄﾞ一覧
                With vsfModeList
                    '@一覧表の表題設定
                    Dim lFixedStyle As CellStyle
                    lFixedStyle = .Styles.Fixed
                    lFixedStyle.ForeColor = Color.Yellow                                        '文字色
                    lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)           '背景色
                End With

                '@装置処理部用途/状態一覧
                With vsfChamberList
                    '@一覧表の表題設定
                    Dim lFixedStyle As CellStyle
                    lFixedStyle = .Styles.Fixed
                    lFixedStyle.ForeColor = Color.Yellow                                        '文字色
                    lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)           '背景色
                End With

            End If

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvColorChang_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnChamber_Set
    '機　能：処理部用途状態情報取得
    '引　数：なし
    '戻り値：True：OK、False：NG
    '作成日：2006/11/21 (Tue) 14:38:39 N.Kasai
    '更新日：2006/11/21 (Tue) 14:38:39
    '備　考：
    Private Function prvblnChamber_Set() As Boolean

        Dim llngCnt                     As Integer                      'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngDispCnt                 As Integer
        Dim lblnAns                     As Boolean                      '結果格納
        Dim lstrProcess                 As String                       '用途ｺﾝﾎﾞ内容格納
        Dim lstrChamber                 As ListDictionary               '状態ｺﾝﾎﾞ内容格納

        Dim ltypWpProcessingNameListReq As WpProcessingNameListReq      '装置処理部用途取得(要求)用構造体
        Dim ltypWpProcessingNameListAns As WpProcessingNameListAns      '装置処理部用途取得(応答)用構造体
        Dim ltypChamberUseListAns       As ChamberuseListAns            '装置処理部状態取得(応答)用構造体
        Dim ltypWpProcessingUseReq      As WpProcessingUseReq           '装置処理部用途ﾘｽﾄ取得(要求)用構造体
        Dim ltypWpProcessingUseAns      As WpProcessingUseAns           '装置処理部用途ﾘｽﾄ取得(応答)用構造体

        Try

            '@装置ｺﾝﾎﾞ未設定の場合
            If cmbWp.ListIndex = -1 Then

                '@戻り値に"OK"をｾｯﾄ
                prvblnChamber_Set = True
                Exit Function
            End If

            '@戻り値初期化
            prvblnChamber_Set = False

            '@***********************
            '@ 要求ﾃﾞｰﾀ作成
            '@***********************
            With ltypWpProcessingUseReq
                .strMsgVer = CMstreq__wpprocessinguseVer    'ﾒｯｾｰｼﾞVer
                .strWpID = cmbWp.Value                      '装置ID
            End With

            '@【装置処理部用途ﾘｽﾄ取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnEqWpProcessingUse_Sel(ltypWpProcessingUseReq, _
                                                  ltypWpProcessingUseAns)

            '@通信結果格納
            If lblnAns = False Then
                '@結果：異常の場合
                Exit Function
            End If

            '@装置処理部用途ﾘｽﾄが0件か
            If ltypWpProcessingUseAns.lngProcessingUseListCnt = 0 Then
                '@格納ﾃﾞｰﾀがない場合

                vsfChamberList.Redraw = False
                vsfChamberList.Rows.Count = 1       '装置処理部用途/状態一覧はﾀｲﾄﾙのみ
                vsfChamberList.Redraw = True
                cmdChamberUP.Enabled = False        '上ｽｸﾛｰﾙﾎﾞﾀﾝ無効(装置処理部用途/状態一覧用)
                cmdChamberDown.Enabled = False      '下ｽｸﾛｰﾙﾎﾞﾀﾝ無効(装置処理部用途/状態一覧用)

                '@戻り値に"True:成功"を返し、以降のﾃﾞｰﾀ取得は必要なし(ﾁｬﾝﾊﾞｰではない装置)
                prvblnChamber_Set = True
                Exit Function
            Else
                '@装置処理部用途ﾘｽﾄﾃﾞｰﾀがある場合

                '@***********************
                '@ 要求ﾃﾞｰﾀ作成
                '@***********************
                With ltypWpProcessingNameListReq
                    .strMsgVer = CMstrmas_wpprocessingnamelistVer   'ﾒｯｾｰｼﾞVer
                    .strSbID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                    .strWpID = cmbWp.Value                          '装置ID
                End With

                '@【装置処理部用途取得】ﾒｯｾｰｼﾞ送受信処理
                lblnAns = pubblnMasWpProcessingList_Sel(ltypWpProcessingNameListReq, _
                                                        ltypWpProcessingNameListAns)

                '@通信結果格納
                If lblnAns = False Then
                    '@結果：異常の場合
                    Exit Function
                End If

                '@装置処理部用途取得件数が0件か
                If ltypWpProcessingNameListAns.lngProcessingListCnt = 0 Then

                    '@M_WP_PROCESSINGにﾃﾞｰﾀが存在しない場合はNG
                    Exit Function
                Else
                    '@装置処理部用途ﾃﾞｰﾀがある場合

                    '@***********************
                    '@ ｸﾞﾘｯﾄﾞｺﾝﾎﾞ設定
                    '@***********************
                    lstrProcess = vbNullString
                    mstrProcess = New ListDictionary

                    llngDispCnt = 0
                    For llngCnt = 0 To ltypWpProcessingNameListAns.lngProcessingListCnt - 1

                        With ltypWpProcessingNameListAns.typProcessingList(llngCnt)

                            If llngCnt > 0 Then
                                lstrProcess = lstrProcess & CPstrSpace & "|"
                            End If

                            '@処理部用途名を編集する
                            lstrProcess = lstrProcess & "#" & .strChamberId & ";" & .strProcessingName

                            '@表示ﾌﾗｸﾞが"1:表示する"か
                            If .strDispOnFlag = CPstrOne Then

                                mstrProcess.Add(.strChamberId, .strProcessingName)

                            End If

                        End With
                    Next llngCnt
                End If

                '@【装置処理部状態取得】ﾒｯｾｰｼﾞ送受信処理
                lblnAns = pubblnMasChamberUseList_Sel(CMstrmas_chamberuselistVer, _
                                                      ltypChamberUseListAns)

                '@通信結果格納
                If lblnAns = False Then
                    '@結果：異常の場合
                    Exit Function
                End If

                '@装置処理部状態取得ﾃﾞｰﾀが0件か
                If ltypChamberUseListAns.lngChamberUseListCnt = 0 Then

                    '@M_CHAMBER_USEにﾃﾞｰﾀが存在しない場合はNG
                    Exit Function
                Else
                    '@装置処理部状態取得ﾃﾞｰﾀがある場合

                    '@***********************
                    '@ ｸﾞﾘｯﾄﾞｺﾝﾎﾞ設定
                    '@***********************
                    lstrChamber = New ListDictionary()
                    For llngCnt = 0 To ltypChamberUseListAns.lngChamberUseListCnt - 1

                        With ltypChamberUseListAns.typChamberUseList(llngCnt)

                            lstrChamber.Add(.strUseId, .strUseName)

                        End With
                    Next llngCnt
                End If

                '@=======================
                '@ 装置処理部用途/状態一覧表示
                '@=======================
                Call prvVsfChamberList_Disp(ltypWpProcessingUseAns, _
                                            ltypWpProcessingNameListAns, _
                                            lstrChamber)

            End If

            '@戻り値に"True:処理成功"をｾｯﾄ
            prvblnChamber_Set = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnChamber_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnCarrierUnloadEnable_Chk
    '機　能：ｷｬﾘｱ強制搬出条件ﾁｪｯｸ
    '引　数：llngPortCnt    ：ﾎﾟｰﾄ数
    '戻り値：True：OK、False：NG
    '作成日：2007/11/27 (Tue) 14:58:21 Y.Yoneyama
    '更新日：2007/12/03 (Mon) 16:07:41 Y.Yoneyama
    '備　考：
    Private Function prvblnCarrierUnloadEnable_Chk(ByVal llngPortCnt As Integer) As Boolean

        Try

            '@戻り値の初期化
            prvblnCarrierUnloadEnable_Chk = False

            '@ｷｬﾝｾﾙｷｬﾘｱが有効な装置が判定する(ﾌﾗｸﾞ:1以外は不可)
            If mtypEqstate.strWPCancelCarrierFlag <> CMstrWpCancelCarrierFlag1 Then
                Exit Function
            End If

            '@現在の運用ﾓｰﾄﾞが"S1"以外の場合はNG
            If lblBeforeMode.Text <> CPstrS1 Then
                Exit Function
            End If

            '@運用ﾓｰﾄﾞ状態が正常以外の場合はNG
            If lblM1AfterMode.Text <> CMstrNormal Then
                Exit Function
            End If

            '@装置ﾎﾟｰﾄ状態一覧ｸﾞﾘｯﾄﾞ
            With vsfPortNoList

                '@ﾎﾟｰﾄ用途が"PRODUCT"以外か
                If .GetData(llngPortCnt, CMlngvsfLColUsage) <> CMstrProduct Then
                    Exit Function
                End If

                '@ﾎﾟｰﾄ状態が"搭載中"以外か
                If .GetData(llngPortCnt, CMlngvsfLColStatusID) <> CMstrvsfStatusTohsai Then
                    Exit Function
                End If

                '@搭載ｷｬﾘｱIDがNULLか
                If .GetData(llngPortCnt, CMlngvsfLColCarrierID) = vbNullString Then
                    Exit Function
                End If

                '@搬送ｷｬﾘｱIDがあるか
                If .GetData(llngPortCnt, CMlngvsfLColTransCarrierID) <> vbNullString Then
                    Exit Function
                End If

                '@ﾛｯﾄIDがNULLか
                If .GetData(llngPortCnt, CMlngvsfLColLotID) = vbNullString Then
                    Exit Function
                End If

            End With

            '@戻り値
            prvblnCarrierUnloadEnable_Chk = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnCarrierUnloadEnable_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvReportTrnJudge_Proc
    '機　能：① 故障修理記録票登録/更新選択処理
    '　　　：② 保全記録票登録/更新選択処理
    '引　数：lstrBeforeUseID    ：変更前(装置状態)
    '　　　：lstrAfterUseID     ：変更後(装置状態)
    '　　　：lstrEntryTime      ：登録日時
    '　　　：lstrEditTime       ：更新日時
    '　　　：lstrRepairNo       ：故障修理記録票№
    '　　　：lstrPreserveNo     ：保全記録票№
    '　　　：lstrEventID        ：ｲﾍﾞﾝﾄID(呼び元Function)
    '戻り値：なし
    '作成日：2008/02/07 (Thu) 14:33:00 N.Kojima
    '更新日：2010/02/01 (Mon) 13:59:47 T.Oide
    '備　考：2010/02/01 (Mon) 13:20:47 T.Oide   №03930対応、故障修理記録の自動発行停止
    Private Sub prvReportTrnJudge_Proc(ByVal lstrBeforeUseID As String, _
                                       ByVal lstrAfterUseID As String, _
                                       ByVal lstrEntryTime As String, _
                                       ByVal lstrEditTime As String, _
                                       ByRef lstrRepairNo As String, _
                                       ByRef lstrPreserveNo As String, _
                                       ByVal lstrEventID As String)

        Dim lstrTrnDivision     As String       '処理区分(1:故障修理記録票登録、2:故障修理記録票更新、
                                                '　　　　 3:保全記録票登録、4:保全記録票更新、
                                                '　　　　 5:故障修理記録票登録＆保全記録票更新、
                                                '　　　　 6:保全記録票登録＆故障修理記録票更新)

        '@---------------------------------------------------------------------
        '@ﾒﾓ：2010/02/01 (Mon) 13:20:47 T.Oide
        '@　　故障修理記録は基本的にOZMAへ運用を移行するため自動作成を中止する
        '@　　但し、機能自体の削除は時期を見て行うため、今回の修正では削除しない
        '@　　また、保全記録は当面現状の運用を継続するため、修正対象としない
        '@---------------------------------------------------------------------


        Try

            '@★ 変更後(装置状態)により処理分岐 ★
            Select Case lstrAfterUseID

                '@〓 故障停止(=MCUSE0004) 〓
                Case CPstrMcUseIDWpStop

                    '@★★ 変更前(装置状態)により処理分岐 ★★
                    Select Case lstrBeforeUseID

                        '@〓〓 計画保全(=MCUSE0005) 〓〓
                        Case CPstrMcUseIDPlanMnt

                            '@処理区分に"5:故障修理記録登録＆保全記録票更新"をｾｯﾄ
                            lstrTrnDivision = CPstrFive

                        '@〓〓 その他(=MCUSE????) 〓〓
                        Case Else

                            '@処理区分に"1:故障修理記録票登録"をｾｯﾄ
                            lstrTrnDivision = CPstrOne

                    End Select


                '@〓 計画保全(=MCUSE0005) 〓
                Case CPstrMcUseIDPlanMnt

                    '@★★ 変更前(装置状態)により処理分岐 ★★
                    Select Case lstrBeforeUseID

                        '@〓〓 故障停止(=MCUSE0004) 〓〓
                        Case CPstrMcUseIDWpStop

                            '@処理区分に"6:保全記録票登録＆故障修理記録更新"をｾｯﾄ
                            lstrTrnDivision = CPstrSix

                        '@〓〓 その他(=MCUSE????) 〓〓
                        Case Else

                            '@処理区分に"3:保全記録票登録"をｾｯﾄ
                            lstrTrnDivision = CPstrThree

                    End Select
            

                '@〓 その他(=MCUSE????) 〓
                Case Else

                    '@★★ 変更前(装置状態)により処理分岐 ★★
                    Select Case lstrBeforeUseID

                        '@〓〓 故障停止(=MCUSE0004) 〓〓
                        Case CPstrMcUseIDWpStop

                            '@処理区分に"2:故障修理記録票更新"をｾｯﾄ
                            lstrTrnDivision = CPstrTwo

                        '@〓〓 計画保全(=MCUSE0005) 〓〓
                        Case CPstrMcUseIDPlanMnt

                            '@処理区分に"4:保全記録票更新"をｾｯﾄ
                            lstrTrnDivision = CPstrFour

                    End Select

            End Select


            '@★ 処理区分により処理分岐 ★
            Select Case lstrTrnDivision

                '@〓 "1"or"2"(故障修理記録関連処理) 〓
                Case CPstrOne, CPstrTwo

        '@↓2010/02/01 (Mon) 14:00:18 T.Oide **************************************************
        '@            '@=======================
        '@            '@　故障修理記録票登録/更新処理
        '@            '@=======================
        '@            Call prvRepairReportInsOrUpd_Proc(lstrBeforeUseID, _
        '@                                              lstrAfterUseID, _
        '@                                              lstrEntryTime, _
        '@                                              lstrEditTime, _
        '@                                              lstrRepairNo, _
        '@                                              lstrTrnDivision, _
        '@                                              lstrEventID)
        '@↑2010/02/01 (Mon) 14:00:18 T.Oide **************************************************


                '@〓 "3"or"4"(保全記録関連処理) 〓
                Case CPstrThree, CPstrFour

                    '@=======================
                    '@ 保全記録票登録/更新処理
                    '@=======================
                    Call prvPreserveReportInsOrUpd_Proc(lstrBeforeUseID, _
                                                        lstrAfterUseID, _
                                                        lstrEntryTime, _
                                                        lstrEditTime, _
                                                        lstrPreserveNo, _
                                                        lstrTrnDivision, _
                                                        lstrEventID)

                
                '@〓 "5"or"6"(故障修理記録＆保全記録ﾀﾞﾌﾞﾙ処理) 〓
                Case CPstrFive, CPstrSix

        '@↓2010/02/01 (Mon) 14:00:32 T.Oide **************************************************
        '@            '@=======================
        '@            '@　故障修理記録票登録/更新処理
        '@            '@=======================
        '@            Call prvRepairReportInsOrUpd_Proc(lstrBeforeUseID, _
        '@                                              lstrAfterUseID, _
        '@                                              lstrEntryTime, _
        '@                                              lstrEditTime, _
        '@                                              lstrRepairNo, _
        '@                                              lstrTrnDivision, _
        '@                                              lstrEventID)
        '@↑2010/02/01 (Mon) 14:00:32 T.Oide **************************************************

                    '@=======================
                    '@ 保全記録票登録/更新処理
                    '@=======================
                    Call prvPreserveReportInsOrUpd_Proc(lstrBeforeUseID, _
                                                        lstrAfterUseID, _
                                                        lstrEntryTime, _
                                                        lstrEditTime, _
                                                        lstrPreserveNo, _
                                                        lstrTrnDivision, _
                                                        lstrEventID)

            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvReportTrnJudge_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

'未使用機能NSYS ↓
''関数名：prvRepairReportInsOrUpd_Proc
''機　能：故障修理記録票登録/更新処理
''引　数：lstrBeforeUseID    ：変更前装置状態ID
''　　　：lstrAfterUseID     ：変更後装置状態ID
''　　　：lstrEntryTime      ：登録日時
''　　　：lstrEditTime       ：更新日時
''　　　：lstrRepairNo       ：故障修理記録票№
''　　　：lstrTrnDivision    ：処理区分(1:故障修理記録票登録、2:故障修理記録票更新、3:保全記録票登録、4:保全記録票更新)
''　　　：lstrEventID        ：ｲﾍﾞﾝﾄID(呼び元Function)
''戻り値：なし
''作成日：2008/01/31 (Thu) 10:41:28 N.Kojima
''更新日：2008/01/31 (Thu) 10:41:28
''備　考：
'Private Sub prvRepairReportInsOrUpd_Proc(ByVal lstrBeforeUseID As String, _
'                                         ByVal lstrAfterUseID As String, _
'                                         ByVal lstrEntryTime As String, _
'                                         ByVal lstrEditTime As String, _
'                                         ByRef lstrRepairNo As String, _
'                                         ByVal lstrTrnDivision As String, _
'                                         ByVal lstrEventID As String)

'    Dim lblnAns     As Boolean      '通信結果格納用
'    Dim lstrMsg     As String       '表示ﾒｯｾｰｼﾞ格納用

'    On Error GoTo Error_Handler

'    '@**************************************************
'    '@ ★登録処理★
'    '@ 　変更後の装置状態が「故障停止(=MCUSE0004)」の場合
'    '@ 　故障修理記録票を自動で起案する。
'    '@
'    '@ ★更新処理★
'    '@ 　故障修理記録票の修理完了日時を登録する。
'    '@**************************************************

'    '@***********************
'    '@ 要求ﾃﾞｰﾀ作成
'    '@***********************
'    With mtypRepairInfoReq

'        .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸID
'        .strEmpID = pstrUserID                      '作業者ID(起案者、更新者、発見者)
'        .strEmpName = pstrUserName                  '作業者名(起案者、更新者、発見者)
'        .strMsgVer = CMstrrep_chgrepairreportVer    'ﾒｯｾｰｼﾞVer
'        .strOldUseID = lstrBeforeUseID              '変更前装置状態ID
'        .strUseId = lstrAfterUseID                  '変更後装置状態ID
'        .strWpID = cmbWp.Value                      '装置ID
'        .strWpName = cmbWp.Text                     '装置名
'    End With

'    '@★ 処理区分によって処理分岐 ★
'    Select Case lstrTrnDivision

'        '@〓 "1 or 5：故障修理記録票登録" 〓
'        Case CPstrOne, CPstrFive

'            mtypRepairInfoReq.strActionID = CPstrOne                    'ｱｸｼｮﾝID(1:新規登録)
'            mtypRepairInfoReq.strEntryTime = lstrEntryTime              '登録日時(WP_EVENT_HISTORYとの同期)
'            mtypRepairInfoReq.strEntryClass = CPstrOne                  '起票区分(1:自動起票)

'            '@画面の使用禁止
'            frmxxEN00C0.Enabled = False
'            frmxxEN00C0.KeyPreview = False

'            '@【故障修理記録票登録】ﾒｯｾｰｼﾞ送受信処理
'            lblnAns = pubblnRepChgRepairReport_Upd(mtypRepairInfoReq, _
'                                                   lstrEditTime, _
'                                                   lstrRepairNo)

'            '@画面の使用禁止解除
'            frmxxEN00C0.Enabled = True
'            frmxxEN00C0.KeyPreview = True

'            '@処理後ﾒｯｾｰｼﾞ表示用に"登録"を格納
'            lstrMsg = CMstrInsertMsg


'        '@〓 "2 or 6：故障修理記録票更新" 〓
'        Case CPstrTwo, CPstrSix

'            mtypRepairInfoReq.strActionID = CPstrThree                  'ｱｸｼｮﾝID(3:修理完了日時更新)

'            '@画面の使用禁止
'            frmxxEN00C0.Enabled = False
'            frmxxEN00C0.KeyPreview = False

'            '@【故障修理記録票更新】ﾒｯｾｰｼﾞ送受信処理
'            lblnAns = pubblnRepChgRepairReport_Upd(mtypRepairInfoReq, _
'                                                   lstrEditTime, _
'                                                   lstrRepairNo)

'            '@画面の使用禁止解除
'            frmxxEN00C0.Enabled = True
'            frmxxEN00C0.KeyPreview = True

'            '@処理後ﾒｯｾｰｼﾞ表示用に"更新"を格納
'            lstrMsg = CMstrUpdateMsg

'    End Select

'    '@通信結果判定
'    If lblnAns = True Then
'        '@結果：正常の場合

'        '@**************************
'        '@ 引継ぎ構造体に情報をｾｯﾄ
'        '@**************************
'        With ptypRepairInfo

'            .strSbID = pstrSBID             'ｼｽﾃﾑﾌﾞﾛｯｸID
'            .strEmpID = pstrUserID          '作業者ID(起案者、更新者、発見者)
'            .strEmpName = pstrUserName      '作業者名(起案者、更新者、発見者)
'            .strRepairNo = lstrRepairNo     '故障修理記録票№
'            .strEditTime = lstrEditTime     '登録日時(更新日時、故障発生日時)
'            .strWpID = cmbWp.Value          '装置ID
'            .strWpName = cmbWp.Text         '装置名
'        End With

'        '@表示ﾒｯｾｰｼﾞ変換
'        '@「"<TRM6QI>$$故障修理記録票を[登録or更新]しました。故障修理記録票№[RXXXXXXXX]"」のﾒｯｾｰｼﾞ表示
'        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006Q, CMstrRepairTitle, lstrMsg, lstrRepairNo)
'        Call pubVsfInfo_Disp(pstrDMsg)
'    End If

'    Exit Sub

'Error_Handler:

'    '@画面の使用禁止解除
'    frmxxEN00C0.Enabled = True
'    frmxxEN00C0.KeyPreview = True

'    '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
'    With ptypOnErrorInfo
'        .strMenuKey = CMstrLocalMenuKey
'        .strProcName = "prvRepairReportInsOrUpd_Proc"
'        .strErrMessage = vbNullString
'    End With

'    '@=======================
'    '@ 共通ｴﾗｰ処理
'    '@=======================
'    Call pubOnError_Proc

'End Sub
'未使用機能NSYS ↑

    '関数名：prvPreserveReportInsOrUpd_Proc
    '機　能：保全記録票登録/更新処理
    '引　数：lstrBeforeUseID    ：変更前装置状態ID
    '　　　：lstrAfterUseID     ：変更後装置状態ID
    '　　　：lstrEntryTime      ：登録日時
    '　　　：lstrEditTime       ：更新日時
    '　　　：lstrPreserveNo     ：保全記録票№
    '　　　：lstrTrnDivision    ：処理区分(1:故障修理記録票登録、2:故障修理記録票更新、3:保全記録票登録、4:保全記録票更新)
    '　　　：lstrEventID        ：ｲﾍﾞﾝﾄID(呼び元Function)
    '戻り値：なし
    '作成日：2008/01/31 (Thu) 10:41:28 N.Kojima
    '更新日：2008/01/31 (Thu) 10:41:28
    '備　考：
    Private Sub prvPreserveReportInsOrUpd_Proc(ByVal lstrBeforeUseID As String, _
                                               ByVal lstrAfterUseID As String, _
                                               ByVal lstrEntryTime As String, _
                                               ByVal lstrEditTime As String, _
                                               ByRef lstrPreserveNo As String, _
                                               ByVal lstrTrnDivision As String, _
                                               ByVal lstrEventID As String)

        Dim lblnAns                     As Boolean              '通信結果格納用
        Dim lstrMsg                     As String               '表示ﾒｯｾｰｼﾞ格納用
        Dim ltypPreserveConnectInfo     As PreserveConnectInfo  '保全記録票選択画面への引継ぎ用情報格納構造体初期化用

        Try

            '@**************************************************
            '@ ★更新処理
            '@ 　保全記録票の保全完了日時を登録する。
            '@**************************************************

            '@★ 処理区分によって処理分岐 ★
            Select Case lstrTrnDivision

                '@〓 "3 or 6：保全記録票登録" 〓
                Case CPstrThree, CPstrSix

                    '@戻り値に"True:成功"をｾｯﾄ(実際は通信はしないが帳尻合わせ)
                    lblnAns = True


                '@〓 "4 or 5：保全記録票更新" 〓
                Case CPstrFour, CPstrFive

                    '@***********************
                    '@　要求ﾃﾞｰﾀ作成
                    '@***********************
                    With mtypPreserveInfoReq

                        .strSbID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸID
                        .strEmpID = pstrUserID                          '作業者ID(起案者、更新者、発見者)
                        .strEmpName = pstrUserName                      '作業者名(起案者、更新者、発見者)
                        .strMsgVer = CMstrpre_chgpreservereportVer      'ﾒｯｾｰｼﾞVer
                        .strOldUseID = lstrBeforeUseID                  '変更前装置状態ID
                        .strUseId = lstrAfterUseID                      '変更後装置状態ID
                        .strWpID = cmbWp.Value                          '装置ID
                        .strWpName = cmbWp.Text                         '装置名
                        .strActionID = CPstrThree                       'ｱｸｼｮﾝID(3:終了(予定)日時更新)
                    End With

                    '@画面の使用禁止
                    Me.KeyPreview = False

                    '@【保全記録票更新】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnPreChgPreserveReport_Upd(mtypPreserveInfoReq, _
                                                           lstrEditTime, _
                                                           lstrPreserveNo)

                    '@画面の使用禁止解除
                    Me.KeyPreview = True

                    '@処理後ﾒｯｾｰｼﾞ表示用に"更新"を格納
                    lstrMsg = CMstrUpdateMsg
         
            End Select

            '@***********************
            '@ 引継ぎ構造体に情報をｾｯﾄ
            '@***********************
            With ptypPreserveConnectInfo

                .strSbID = pstrSBID                 'ｼｽﾃﾑﾌﾞﾛｯｸID
                .strMcGroupID = cmbMcGroup.Value    '装置ｸﾞﾙｰﾌﾟID
                .strMcGroupName = cmbMcGroup.Text   '装置ｸﾞﾙｰﾌﾟ名
                .strPreserveNo = lstrPreserveNo     '保全記録票№
                .strEntryTime = lstrEntryTime       '登録日時
                .strEditTime = lstrEditTime         '登録日時(更新日時、故障発生日時)
                .strWpID = cmbWp.Value              '装置ID
                .strWpName = cmbWp.Text             '装置名
                .strCategoryID = lstrAfterUseID     'ｶﾃｺﾞﾘID
            End With

            '@通信結果判定
            If lblnAns = True Then
                '@結果：正常の場合

                '@★ 処理区分により処理分岐 ★
                Select Case lstrTrnDivision

                    '@〓 "4 or 5:保全記録票更新" 〓
                    Case CPstrFour, CPstrFive

                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM6QI>$$保全記録票を[登録or更新]しました。保全記録票№[RXXXXXXXX]"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006Q, CMstrPreserveTitle, _
                                                        lstrMsg, lstrPreserveNo)
                        Call pubVsfInfo_Disp(pstrDMsg)

                End Select
            Else
                '@結果：失敗の場合

                '@引継ぎ構造体の初期化
                ptypPreserveConnectInfo = ltypPreserveConnectInfo
            End If

            Exit Sub

        Catch ex As Exception

            '@画面の使用禁止解除
            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvPreserveReportInsOrUpd_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2011/06/17 (Fri) 10:37:22 T.Oide **************************************************
    'メモ：2011/06/17 (Fri) 10:37:22 T.Oide
    '　　　装置保全記録はOZMAに運用が移ったので自動起動は中止
    '@'関数名：prvDispReportJudge_Proc
    '@'機　能：装置状態別起動画面判定処理
    '@'　　　：① 故障停止　⇒　装置ﾒﾝﾃﾅﾝｽ記録票画面起動処理へ
    '@'　　　：② 計画保全　⇒　保全記録票選択画面起動処理へ
    '@'引　数：なし
    '@'戻り値：なし
    '@'作成日：2008/02/07 (Thu) 14:33:00 N.Kojima
    '@'更新日：2010/02/01 (Mon) 14:03:27 T.Oide
    '@'備　考：2010/02/01 (Mon) 13:20:47 T.Oide   №03930対応、故障修理記録の自動発行停止
    '@Private Sub prvDispReportJudge_Proc()
    '@
    '@    Dim lblnAns     As Boolean      '戻り値格納用
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    '@*******************************************************
    '@    '@ ★故障停止★
    '@    '@ 　装置状態が「故障停止」に変更された場合は、故障修理記録票を
    '@    '@ 　自動で起案し、起案後、画面を自動で起動する。
    '@    '@ ★計画保全★
    '@    '@ 　装置状態が「計画保全」に変更された場合は、「保全記録票選択」画面を
    '@    '@ 　起動し、保全記録票を選択する。起票されていない場合は、新規で起票する。
    '@    '@*******************************************************
    '@
    '@    '@★ 変更後の装置状態により処理分岐 ★
    '@    Select Case mtypEqstate.strUseID
    '@
    '@'@↓2010/02/01 (Mon) 14:03:13 T.Oide **************************************************
    '@'ﾒﾓ：2010/02/01 (Mon) 13:20:47 T.Oide
    '@'　　故障修理記録は基本的にOZMAへ運用を移行するため自動作成を中止する
    '@'　　但し、機能自体の削除は時期を見て行うため、今回の修正では削除しない
    '@'　　また、保全記録は当面現状の運用を継続するため、修正対象としない
    '@'--------------------------------------------------------------------------------------
    '@'@        '@〓 故障停止(=MCUSE0004) 〓
    '@'@        Case CPstrMcUseIDWpStop
    '@'@
    '@'@            '@起動区分に"1:故障修理記録票"をｾｯﾄ
    '@'@            plngLoadClass = CPlngNumOne
    '@'@
    '@'@            '@==================================================
    '@'@            '@　変更後の装置状態が「故障停止(=MCUSE0004)」の場合
    '@'@            '@　故障修理記録票画面を起動する為のFunctionをCall
    '@'@            '@==================================================
    '@'@            lblnAns = prvMainteReport_Disp(CMstrLocalMenuKey)
    '@'@
    '@'@            '@処理結果判定
    '@'@            If lblnAns = False Then
    '@'@                '@装置ﾒﾝﾃﾅﾝｽ記録票画面起動に失敗した場合
    '@'@
    '@'@                '@表示ﾒｯｾｰｼﾞ変換
    '@'@                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000M, CPstrSubFormCM00Z0)
    '@'@                '@"<TRM0ME>$$%1画面の自動起動に失敗しました。$装置メンテナンス記録票一覧画面より処理票を選択し編集を行なってください。"
    '@'@                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxEN00C0.Caption, True, 16)
    '@'@            End If
    '@'@↑2010/02/01 (Mon) 14:03:13 T.Oide **************************************************
    '@
    '@
    '@        '@〓 計画保全(=MCUSE0005) 〓
    '@        Case CPstrMcUseIDPlanMnt
    '@
    '@            '@起動区分に"2:保全記録票"をｾｯﾄ
    '@            plngLoadClass = CPlngNumTwo
    '@
    '@            '@==================================================
    '@            '@ 変更後の装置状態が「計画保全(=MCUSE0005)」の場合
    '@            '@ ※保全記録票選択画面を起動する為のFunctionをCall
    '@            '@==================================================
    '@            lblnAns = prvSelectPreserveReport_Disp(CMstrLocalMenuKey)
    '@
    '@            '@処理結果判定
    '@            If lblnAns = False Then
    '@                '@保全記録票選択画面起動に失敗した場合
    '@
    '@                '@表示ﾒｯｾｰｼﾞ変換
    '@                '@「'@"<TRM0ME>$$%1画面の自動起動に失敗しました。$装置メンテナンス記録票一覧画面より
    '@                '@　処理票を選択し編集を行なってください。"」のﾒｯｾｰｼﾞ表示
    '@                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000M, CPstrSubFormCM00Z0)
    '@                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxEN00C0.Caption, True, 16)
    '@            End If
    '@
    '@    End Select
    '@
    '@    '@起動区分の初期化
    '@    plngLoadClass = CPlngNumZero
    '@
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey
    '@        .strProcName = "prvDispReportJudge_Proc"
    '@        .strErrMessage = vbNullString
    '@    End With
    '@
    '@    '@=======================
    '@    '@ 共通ｴﾗｰ処理
    '@    '@=======================
    '@    Call pubOnError_Proc
    '@
    '@End Sub
    '@↑2011/06/17 (Fri) 10:37:22 T.Oide **************************************************

    '@↓2010/02/01 (Mon) 14:05:03 T.Oide **************************************************
    'ﾒﾓ：2010/02/01 (Mon) 13:20:47 T.Oide
    '　　故障修理記録は基本的にOZMAへ運用を移行するため自動作成を中止する
    '　　但し、機能自体の削除は時期を見て行うため、今回の修正では削除しない
    '　　また、保全記録は当面現状の運用を継続するため、修正対象としない
    '--------------------------------------------------------------------------------------
    '@'関数名：prvMainteReport_Disp
    '@'機　能：装置ﾒﾝﾃﾅﾝｽ記録票画面起動処理
    '@'引　数：lstrFunctionKey   ：起動機能ID
    '@'戻り値：True：正常、False：異常
    '@'作成日：2008/01/31 (Thu) 16:25:55 N.Kojima
    '@'更新日：2008/01/31 (Thu) 16:25:55
    '@'備　考：
    '@Public Function prvMainteReport_Disp(ByVal lstrFunctionKey As String) As Boolean
    '@
    '@    Dim ltypRepairInfo          As RepairInfo       '故障修理記録票用構造体初期化用
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    '@戻り値の初期化
    '@    prvMainteReport_Disp = False
    '@
    '@    '@Form_Loadﾌﾗｸﾞ(異常)
    '@    pblnFormLoad = False
    '@
    '@    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
    '@    '@　装置ﾒﾝﾃﾅﾝｽ記録票画面　起動処理
    '@    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
    '@    Call Load(frmxxCM00Z0)
    '@
    '@    '@Form_Loadﾌﾗｸﾞが異常か
    '@    If pblnFormLoad = False Then
    '@
    '@        '@∇∇∇∇∇∇∇∇∇
    '@        '@　ｱﾝﾛｰﾄﾞ処理
    '@        '@∇∇∇∇∇∇∇∇∇
    '@        Call Unload(frmxxCM00Z0)
    '@
    '@        Exit Function
    '@    End If
    '@
    '@    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
    '@    '@　装置ﾒﾝﾃﾅﾝｽ記録票画面　表示処理
    '@    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
    '@    Call frmxxCM00Z0.Show(vbModal)
    '@
    '@    '@使用したﾊﾟﾌﾞﾘｯｸ変数を初期化
    '@    ptypRepairInfo = ltypRepairInfo         '故障修理記録票用構造体
    '@
    '@    '@戻り値にTrue(=正常終了)を設定
    '@    prvMainteReport_Disp = True
    '@
    '@    Exit Function
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey
    '@        .strProcName = "prvMainteReport_Disp"
    '@        .strErrMessage = vbNullString
    '@    End With
    '@
    '@    '@=======================
    '@    '@ 共通ｴﾗｰ処理
    '@    '@=======================
    '@    Call pubOnError_Proc
    '@
    '@End Function
    '@↑2010/02/01 (Mon) 14:05:03 T.Oide **************************************************


    '@↓2011/06/17 (Fri) 10:37:22 T.Oide **************************************************
    'メモ：2011/06/17 (Fri) 10:37:22 T.Oide
    '　　　装置保全記録はOZMAに運用が移ったので自動起動は中止
    '@'関数名：prvSelectPreserveReport_Disp
    '@'機　能：保全記録票選択画面起動処理
    '@'引　数：lstrFunctionKey   ：起動機能ID
    '@'戻り値：True：正常、False：異常
    '@'作成日：2008/01/31 (Thu) 16:25:55 N.Kojima
    '@'更新日：2008/01/31 (Thu) 16:25:55
    '@'備　考：
    '@Private Function prvSelectPreserveReport_Disp(ByVal lstrFunctionKey As String) As Boolean
    '@
    '@    Dim ltypPreserveConnectInfo        As PreserveConnectInfo     '保全記録票用構造体初期化用
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    '@戻り値の初期化
    '@    prvSelectPreserveReport_Disp = False
    '@
    '@    '@Form_Loadﾌﾗｸﾞ(異常)
    '@    pblnFormLoad = False
    '@
    '@    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
    '@    '@ 保全記録票選択画面　起動処理
    '@    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
    '@    Call Load(frmxxCM00Z1)
    '@
    '@    '@Form_Loadﾌﾗｸﾞが異常か
    '@    If pblnFormLoad = False Then
    '@
    '@        '@∇∇∇∇∇∇∇∇∇∇∇
    '@        '@　ｱﾝﾛｰﾄﾞ処理
    '@        '@∇∇∇∇∇∇∇∇∇∇∇
    '@        Call Unload(frmxxCM00Z1)
    '@
    '@        Exit Function
    '@    End If
    '@
    '@    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
    '@    '@ 保全記録票選択画面　表示処理
    '@    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
    '@    Call frmxxCM00Z1.Show(vbModal)
    '@
    '@    '@使用したﾊﾟﾌﾞﾘｯｸ変数を初期化
    '@    ptypPreserveConnectInfo = ltypPreserveConnectInfo     '保全記録票用構造体
    '@
    '@    '@戻り値にTrue(=正常終了)を設定
    '@    prvSelectPreserveReport_Disp = True
    '@
    '@    Exit Function
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey
    '@        .strProcName = "prvSelectPreserveReport_Disp"
    '@        .strErrMessage = vbNullString
    '@    End With
    '@
    '@    '@=======================
    '@    '@ 共通ｴﾗｰ処理
    '@    '@=======================
    '@    Call pubOnError_Proc
    '@
    '@End Function
    '@↑2011/06/17 (Fri) 10:37:22 T.Oide **************************************************


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


    '関数名：prvSetFocus
    '機　能：フォーム専用のフォーカスセット追加処理
    '引　数：lctlNext：フォーカス先コントロールオブジェクト
    '      ：laryCallers：呼出し元コントロールの配列
    '戻り値：なし
    '作成日：2019/07/09 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub prvSetFocus(ByVal lctlNext As Control, ParamArray ByVal laryCallers As Control())

        Dim ldicMatchHandler        As List(Of Tuple(Of Control, CancelEventHandler))
        Dim ldicCtrlToHandler       As Dictionary(Of Control, CancelEventHandler)

        'NSYS コントロールとValidateハンドラーの組み合わせ定義
        ldicCtrlToHandler = New Dictionary(Of Control, CancelEventHandler) From { _
                { cmbMcGroup, AddressOf cmbMcGroup_Validate }, _
                { cmbWp, AddressOf cmbWp_Validate }, _
                { cmbUseName, AddressOf cmbUseName_Validate }, _
                { cmbRecipeFlow, AddressOf cmbRecipeFlow_Validate }, _
                { cmbRecipeGroup, AddressOf cmbRecipeGroup_Validate }, _
                { txtRecipeFlowNum, AddressOf txtRecipeFlowNum_Validate } _
            }
        ldicMatchHandler = New List(Of Tuple(Of Control, CancelEventHandler))

        If ActiveControl IsNot Nothing Then
            Dim lblnMatch As Boolean = False
            ' 呼出し元コントロールの配列に ActiveControlが含まれるか
            For Each lctlCaller As Control In laryCallers
                If ActiveControl Is lctlCaller Then
                    lblnMatch = True
                End If
                ' Validateハンドラーコントロールの判定
                If ldicCtrlToHandler.ContainsKey(lctlCaller) = True Then
                    ldicMatchHandler.Add(Tuple.Create(lctlCaller, ldicCtrlToHandler(lctlCaller)))
                End If
            Next

            If lblnMatch = False Then
                ' ActiveControlが呼び出し元と異なる場合、フォーカス移動しない (VB6互換動作)
                Exit Sub
            End If
        End If

        Try
            ' Validateをハンドリングしているコントロールの場合は、ハンドラーをはずす
            For Each lPair As Tuple(Of Control, CancelEventHandler) In ldicMatchHandler
                RemoveHandler lPair.Item1.Validating, lPair.Item2
            Next
            ' フォーカスセット
            pubSetFocus(lctlNext)
        Finally
            ' Validateハンドラーを戻す
            For Each lPair As Tuple(Of Control, CancelEventHandler) In ldicMatchHandler
                AddHandler lPair.Item1.Validating, lPair.Item2
            Next
        End Try

    End Sub

    '関数名：flexGrid_KeyDown
    '機　能：
    '引　数：KeyCode：
    '　　　：Shift：
    '戻り値：
    '作成日：2019/01/28 (Mon) 10:00:00 NSYS
    '更新日：2019/04/05 (Fri) 12:00:00 NSYS
    '備　考：
    Private Sub flexGrid_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles vsfPortNoList.KeyDown, vsfChamberList.KeyDown

        Try
            'NSYS データ行がない場合は処理を抜ける
            If sender.Rows.Count <= sender.Rows.Fixed Then
                Return
            End If

            With CType(sender, C1FlexGrid)
                'NSYS DataMap対応列の場合
                If .Cols(.Col).DataMap IsNot Nothing Then
                    Select Case e.KeyCode
                        Case Keys.F4
                            'NSYS F4 無効化
                            e.Handled = True

                        Case Keys.F2
                            'NSYS F2 編集開始
                            e.Handled = True
                            .StartEditing()

                        Case Keys.Space
                            'NSYS ｽﾍﾟｰｽ 編集開始し、ドロップダウンを展開する
                            e.Handled = True
                            e.SuppressKeyPress = True
                            .StartEditing()
                            CType(.Editor, ComboBox).DroppedDown = True

                    End Select
                End If

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "flexGrid_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：flexGrid_KeyDownEdit
    '機　能：←→キーの取り扱い
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/01/28 (Mon) 10:00:00 NSYS
    '更新日：2019/04/05 (Fri) 12:00:00 NSYS
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfChamberList.KeyDownEdit, vsfModeList.KeyDownEdit, vsfPortNoList.KeyDownEdit

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
                            ' 編集終了になるキー
                            mblnVsfComboListKeyDownEdit = True
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
                            ' 編集終了になるキー
                            mblnVsfComboListKeyDownEdit = True
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

                    Case Keys.Return, Keys.Tab
                        ' 編集終了になるキー
                        mblnVsfComboListKeyDownEdit = True

                    Case Keys.PageUp, Keys.PageDown
                        ' 無効化
                        e.Handled = True

                        'NSYS [装置ﾎﾟｰﾄ状態一覧]ｸﾞﾘｯﾄﾞの場合
                        If sender Is vsfPortNoList AndAlso TypeOf .Editor Is ComboBox Then
                            Dim cmb As ComboBox = CType(.Editor, ComboBox)

                            If e.KeyCode = Keys.PageUp Then
                                'NSYS PageUp 先頭の要素を選択
                                cmb.SelectedIndex = 0

                            Else If e.KeyCode = Keys.PageDown Then
                                'NSYS PageDown 末尾の要素を選択
                                cmb.SelectedIndex = cmb.Items.Count - 1

                            End If
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
    Private Sub flex_SetupEditor(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfChamberList.SetupEditor, vsfModeList.SetupEditor, vsfPortNoList.SetupEditor

        Try
            If TypeOf sender.Editor Is ComboBox
                '行の高さを変更
                Dim editor As ComboBox = CType(sender.Editor, ComboBox)
                editor.DropDownHeight = 211
                editor.MaxDropDownItems = 11
                CType(sender, C1FlexGrid).Rows.DefaultSize = 19
            End If

            '編集終了になるキー操作フラグを初期化
            mblnVsfComboListKeyDownEdit = False

        Catch ex As Exception
            '異常終了した場合は何もしない

        End Try

    End Sub

    '関数名：flexGrid_Leave
    '機　能：ｸﾞﾘｯﾄﾞﾌｫｰｶｽｱｳﾄ処理
    '引　数：sender：ｲﾍﾞﾝﾄ発生元
    '　　　：e     ：ｲﾍﾞﾝﾄｵﾌﾞｼﾞｪｸﾄ
    '戻り値：なし
    '作成日：2020/04/20 (Mon) 15:00:00 NSYS
    '備　考：
    Private Sub flexGrid_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles vsfPortNoList.Leave, vsfChamberList.Leave

        Try

            With CType(sender, C1FlexGrid)
                .AllowEditing = False
            End With

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "flexGrid_Leave"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try

    End Sub

    '関数名：flexGrid_BeforeDoubleClick
    '機　能：ｸﾞﾘｯﾄﾞ　ダブルクリック時前処理
    '引　数：sender：ｲﾍﾞﾝﾄ発生元
    '　　　：e     ：ｲﾍﾞﾝﾄｵﾌﾞｼﾞｪｸﾄ
    '戻り値：なし
    '作成日：2020/04/20 (Mon) 15:00:00 NSYS
    '備　考：
    Private Sub flexGrid_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfPortNoList.BeforeDoubleClick, vsfChamberList.BeforeDoubleClick

        Try

            With CType(sender, C1FlexGrid)
                'NSYS 対象行が見出し行の場合、または、見出し行ダブルクリック時は抜ける
                If .Row < .Rows.Fixed OrElse .MouseRow < .Rows.Fixed Then
                    Exit Sub
                End If

                'NSYS DataMap対応列以外は抜ける
                If .Cols(.Col).DataMap Is Nothing Then
                    Exit Sub
                End If

                'NSYS DataMap対応列の場合、VB.NETのデフォルトの動作をキャンセルする
                e.Cancel = True

                'NSYS VB6互換で編集を開始し、ドロップダウンを展開する
                .StartEditing()
                CType(.Editor, ComboBox).DroppedDown = True
            End With

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "flexGrid_BeforeDoubleClick"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

End Class
