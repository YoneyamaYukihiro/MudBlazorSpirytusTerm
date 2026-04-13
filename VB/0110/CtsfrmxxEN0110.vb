'ﾌｧｲﾙ名：xxEN0110.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：装置状態変更ﾒｲﾝﾌｫｰﾑ
'作成日：2004/03/22 (Mon) 09:57:28 M.Miura
'更新日：2019/02/13 (Wed) 15:08:42 T.Oide
'備　考：2018/07/24 (Tue) 11:10:28 Y.Yoneyama   防湿ALD対応
'Copyright(C) SEIKO EPSON CORPORATION 2003-2019, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN0110
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN0110    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN0110
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN0110
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN0110)
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
    '======================================Public===========================================
    '====================================Private============================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2019/02/13 (Wed) 15:16:30 T.Oide **************************************************
    '@Private Const CMstrLocalVersion                     As String = "08.02"         '機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion                     As String = "08.03"         '機能ﾊﾞｰｼﾞｮﾝ
    '@↑2019/02/13 (Wed) 15:16:30 T.Oide **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN0110  'ﾛｰｶﾙﾒﾆｭｰkey

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstreq__chguse__Ver                  As String = "05.00"         '装置状態変更
    Private Const CMstreq__areacurlistVer               As String = "02.00"         'ｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置状態情報取得
    Private Const CMstrmas_wpuselistVer                 As String = "03.00"         '装置状態ﾏｽﾀ取得
    Private Const CMstrmas_McGrouplistVer               As String = "01.00"         '装置ｸﾞﾙｰﾌﾟ取得
    Private Const CMstreq__wpmsglistVer                 As String = "01.00"         '装置状態ﾒｯｾｰｼﾞ取得
    Private Const CMstrrep_chgrepairreportVer           As String = "03.00"         '故障修理記録票登録/更新
    Private Const CMstrpre_chgpreservereportVer         As String = "01.00"         '保全記録票登録/更新
    '@↓2018/08/03 (Fri) 16:19:29 Y.Yoneyama **************************************************
    Private Const CMstrmas_aldprocesslistVer            As String = "01.00"         '防湿ALD処理ﾏｽﾀ取得
    Private Const CMstreq__aldprocesschangeVer          As String = "01.00"         '防湿ALD処理変更
    Private Const CMstreq__emgchgmodeVer                As String = "04.00"         '運用ﾓｰﾄﾞ強制変更要求
    '@↑2018/08/03 (Fri) 16:19:29 Y.Yoneyama **************************************************

    '@vsfMcGroupEquipmentの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfMcGroupEqColNo                As Integer = 0              '№
    Private Const CMlngvsfMcGroupEqColWpID              As Integer = 1              '装置ID
    Private Const CMlngvsfMcGroupEqColWpName            As Integer = 2              '装置名
    Private Const CMlngvsfMcGroupEqColWpStatus          As Integer = 3              '処理状態
    Private Const CMlngvsfMcGroupEqColUseName           As Integer = 4              '状態
    Private Const CMlngvsfMcGroupEqColUseID             As Integer = 5              '状態ID
    Private Const CMlngvsfMcGroupEqColLotLastUpdate     As Integer = 6              '最終更新日時
    Private Const CMlngvsfMcGroupEqColWpStopFlag        As Integer = 7              'WP停止ﾌﾗｸﾞ
    Private Const CMlngvsfMcGroupEqColMesModeID         As Integer = 8              '運用ﾓｰﾄﾞ
    '@↓2018/07/19 (Thu) 16:37:37 Y.Yoneyama **************************************************
    Private Const CMlngvsfMcGroupEqColALDProcessModeId  As Integer = 9              '防湿ALD処理ﾓｰﾄﾞ
    Private Const CMlngvsfMcGroupEqColALDProcessName    As Integer = 10             '防湿ALD処理名
    Private Const CMlngvsfMcGroupEqColEqType            As Integer = 11             'EQ_TYPE
    '@↑2018/07/19 (Thu) 16:37:37 Y.Yoneyama **************************************************

    '@vsfMcGroupEquipmentの定数宣言(幅)
    Private Const CMlngvsfMcGroupEqColWNo               As Integer = 43             '№
    Private Const CMlngvsfMcGroupEqColWWpID             As Integer = 133            '装置ID
    Private Const CMlngvsfMcGroupEqColWWpName           As Integer = 213            '装置名
    Private Const CMlngvsfMcGroupEqColWWpStatus         As Integer = 93             '処理状態
    Private Const CMlngvsfMcGroupEqColWUseName          As Integer = 93             '状態
    Private Const CMlngvsfMcGroupEqColWUseID            As Integer = 0              '状態ID(非表示項目)
    Private Const CMlngvsfMcGroupEqColWLotLastUpdate    As Integer = 0              '最終更新日時(非表示項目)
    Private Const CMlngvsfMcGroupEqColWWpStopFlag       As Integer = 0              'WP停止ﾌﾗｸﾞ(非表示項目)
    Private Const CMlngvsfMcGroupEqColWMesModeID        As Integer = 93             '運用ﾓｰﾄﾞ
    '@↓2018/07/19 (Thu) 16:37:45 Y.Yoneyama **************************************************
    Private Const CMlngvsfMcGroupEqColWALDProcessModeId As Integer = 0              '防湿ALD処理ﾓｰﾄﾞ
    Private Const CMlngvsfMcGroupEqColWALDProcessName   As Integer = 93             '防湿ALD処理名
    Private Const CMlngvsfMcGroupEqColWEqType           As Integer = 0              'EQ_TYPE
    '@↑2018/07/19 (Thu) 16:37:45 Y.Yoneyama **************************************************

    '@vsfMcGroupEquipmentの定数宣言(ﾀｲﾄﾙ)
    Private Const CMlngvsfMcGroupEqColTNo               As String = " №"
    Private Const CMlngvsfMcGroupEqColTWpID             As String = "装置ID"
    Private Const CMlngvsfMcGroupEqColTWpName           As String = "装置名"
    Private Const CMlngvsfMcGroupEqColTWpStatus         As String = "処理状態"
    Private Const CMlngvsfMcGroupEqColTUseName          As String = "装置状態"
    '@↓2018/07/18 (Wed) 13:26:55 Y.Yoneyama **************************************************
    Private Const CMlngvsfMcGroupEqColTMesMode          As String = "運用モード"
    Private Const CMlngvsfMcGroupEqColTALDProcessName   As String = "防湿ALD処理モード"
    '@↑2018/07/18 (Wed) 13:26:55 Y.Yoneyama **************************************************

    Private Const CMlngvsfMcGroupEqRowTitle             As Integer = 0              'ﾀｲﾄﾙ行
    Private Const CMlngvsfMcGroupEqPageRows             As Integer = 15             '1頁表示行数
    Private Const CMlngvsfMcGroupEqHFontSize            As Integer = 12             'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfMcGroupEqHeightSize           As Integer = 27             'ﾍｯﾀﾞｰの高さ
    Private Const CMlngSlotMapHeight                    As Integer = 38             '1ｽﾛｯﾄの高さ

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                      As Single = 15.75           'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Single = 15.75           'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColName                   As Integer = 0              '名称列番
    Private Const CMlngCmbGridColID                     As Integer = 1              'ID列番1(非表示項目：状態ID)
    Private Const CMlngCmbGridColID2                    As Integer = 2              'ID列番2(非表示項目：運用ﾓｰﾄﾞ)
    Private Const CMlngCmbGridColID3                    As Integer = 3              'ID列番3(非表示項目：停止ﾌﾗｸﾞ)
    Private Const CMlngCmbSortAsc                       As Integer = 1              '昇順(ｿｰﾄ)
    Private Const CMlngCmbDispCols                      As Integer = 1              'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbRowHeight                     As Integer = 43             'ﾘｽﾄ行の高さ
    Private Const CMlngCmbClearListIndex                As Integer = -1             'ﾃｷｽﾄ値初期化

    Private Const CMlngStsBarIndex                      As Integer = 1              'ｽﾃｰﾀｽﾊﾞｰの表示ｲﾝﾃﾞｯｸｽ
    Private Const CMlngvsfMcGroupEqAsc                  As Integer = 0              '昇順
    Private Const CMlngvsfMcGroupEqDes                  As Integer = 1              '降順
    Private Const CMlngMemoDefault                      As Integer = 0              '作業ﾒﾓの初期値(=0)

    '@WP停止ﾌﾗｸﾞ
    Private Const CMstrWpStopFlag0                      As String = "0"             '稼動中
    Private Const CMstrWpStopFlag1                      As String = "1"             '停止中

    '@用途ID
    Private Const CMstrRepairStopWpStpoID               As String = "MCUSE0004"     '故障停止
    Private Const CMstrPlanPreserveWpStpoID             As String = "MCUSE0005"     '計画保全

    '@色の定数
    Private Const CMlngVbColorWhite                     As Integer = &HFFFFFF       '白色

    '@処理区分
    Private Const CMstrClassDivision0                   As String = "0"             '変更要求
    Private Const CMstrClassDivision1                   As String = "1"             '変更予約

    '@成功ﾒｯｾｰｼﾞ
    Private Const CMstrWpMsg0                           As String = "(停止 → 稼動)"
    Private Const CMstrWpMsg1                           As String = "(稼動 → 停止)"
    Private Const CMstrInsertMsg                        As String = "登録"              '登録成功MSG
    Private Const CMstrUpdateMsg                        As String = "更新"              '更新成功MSG
    Private Const CMstrRepairTitle                      As String = "故障修理記録票"    '登録or更新成功MSG
    Private Const CMstrPreserveTitle                    As String = "保全記録票"        '登録or更新成功MSG

    '@装置状態通常ﾌﾗｸﾞ(0:通常以外、1:通常)
    Private Const CMstrNormalStateFlag                  As String = "1"             '装置状態通常ﾌﾗｸﾞ(通常)

    '@運用ﾓｰﾄﾞの定数宣言
    Private Const CMstrModeM1                           As String = "M1"            '運用ﾓｰﾄﾞ：M1
    Private Const CMstrModeS1                           As String = "S1"            '運用ﾓｰﾄﾞ：S1

    '@その他
    Private Const CMstrWpMoveNomal                      As String = "通常"

    '@ﾃｷｽﾄ
    Private Const CMlngMaxDispMemoRow                   As Integer = 3              'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(作業ﾒﾓ)

    '@ﾚｽﾎﾟﾝｽ,引継ぎ用ｲﾍﾞﾝﾄ定数
    Private Const CMstrFormName                         As String = "frmxxEN0110"           '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                         As String = "Form_Load"             'ｲﾍﾞﾝﾄ名(ﾌｫｰﾑﾛｰﾄﾞ)
    Private Const CMstrCmdUseChangeClick                As String = "cmdFix_Click"          'ｲﾍﾞﾝﾄ名(確定ﾎﾞﾀﾝ押下処理)
    Private Const CMstrCmbMcGroupCloseUp                As String = "cmbMcGroup_CloseUp"    'ｲﾍﾞﾝﾄ名(装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ選択処理)
    Private Const CMstrPrvblnWpMsgDisp                  As String = "prvblnWpMsg_Disp"      'ｲﾍﾞﾝﾄ名
    Private Const CMstrCmdExecutionClick                As String = "cmdExecution_Click"    'ｲﾍﾞﾝﾄ名称

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '@通信情報格納用ﾓｼﾞｭｰﾙ変数/構造体
    Private mtypUseList                                 As List(Of UseList)         '装置状態格納
    Private mlngUseListCnt                              As Integer                  '装置状態件数
    Private mtypRepairInfoReq                           As RepairInfo               '故障修理記録票情報取得要求構造体
    Private mtypRepairInfoAns                           As RepairInfoAns            '故障修理記録票情報取得応答構造体
    Private mtypPreserveInfoReq                         As PreserveInfo             '保全記録票情報取得要求構造体
    Private mtypPreserveInfoAns                         As PreserveInfoAns          '保全記録票情報取得応答構造体
    '@↓2018/08/03 (Fri) 15:13:17 Y.Yoneyama **************************************************
    Private mtypALDProcessList                          As List(Of ALDProcessList)  '防湿ALD処理格納
    Private mlngALDProcessListCnt                       As Integer                  '防湿ALD処理件数
    '@↑2018/08/03 (Fri) 15:13:17 Y.Yoneyama **************************************************

    '@各種判定用ﾓｼﾞｭｰﾙ変数
    Private mblnMcGroupChange                           As Boolean                  '装置ｸﾞﾙｰﾌﾟ変更ﾌﾗｸﾞ(True：変更、False：無変更)
    Private mblnCommentChangeFLG                        As Boolean                  '余計なｲﾍﾞﾝﾄのｷｬﾝｾﾙ判定ﾌﾗｸﾞ

    '@各種情報格納用ﾓｼﾞｭｰﾙ変数
    Private mstrComment                                 As String                   'ｺﾒﾝﾄを格納
    Private mstrWpID                                    As String                   '確定後の装置IDにﾌｫｰｶｽｾｯﾄ用
    Private mlngTopRow                                  As Short                    '頁先頭行
    Private mtypChgSort                                 As ChgSort                  'ｿｰﾄ保持用

    '@↓2018/08/06 (Mon) 17:15:43 Y.Yoneyama **************************************************
    Private mblnUseNameUpdate                           As Boolean
    Private mblnALDProcessModeUpdate                    As Boolean
    '@↑2018/08/06 (Mon) 17:15:43 Y.Yoneyama **************************************************
    
    Private buttonProcessing                            As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                  'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                  'NSYS WindowCloseフラグ
    Private mblnFrmInitFlg                              As Boolean                  'NSYS フォーム初期化フラグ


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
        pubVsfMouseWheelManager_Set(vsfMcGroupEquipment, cmdUP, cmdDown)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　ﾛｰﾄﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/22 (Mon) 10:25:43 M.Miura
    '更新日：2008/01/30 (Wed) 12:56:13 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 14:00:07 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2004/10/15 (Fri) 14:04:43 N.Kasai      ｿｰﾄ順保持機能追加
    '　　　：2005/12/02 (Fri) 11:58:49 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2008/01/30 (Wed) 12:56:13 N.Kojima     計画保全対応＆ｿｰｽ整備。(案件№02332)
    Private Sub Form_Load()

        Dim lblnAns                 As Boolean          '結果格納
        Dim ltypMcGroupList         As McGroupList      '装置ｸﾞﾙｰﾌﾟ情報格納
        Dim lstrFormTitle           As String           'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)
            
            '@=======================
            '@　機能ﾊﾞｰｼﾞｮﾝの判定
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN0110, CMstrLocalVersion)
            
            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                
                '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                Call pubMenuExpand_Disp()
                
                '@ﾌｫｰﾑを閉じる
                Call Form_QueryUnload(False, New FormClosingEventArgs(New CloseReason,  False))
                Exit Sub
            End If

            'NSYS 初期値設定
            With Me
                'ﾌｫｰﾑの位置を初期化
                .Top = 0
                .Left = 0 - My.Settings.FormOffset
            End With

            '@=======================
            '@　ﾒﾆｭｰｷｰから機能毎の関連情報取得
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0110, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@=======================
            '@　ﾒｲﾝﾌｫｰﾑの初期化
            '@=======================
            Call prvFrmxxEN0110_Init()
            
            '@=======================
            '@　装置情報ｸﾞﾘｯﾄﾞの初期化
            '@=======================
            Call prvVsfMcGroupEquipment_Init()
            
            '@ｿｰﾄ保持構造体初期化
            With mtypChgSort
                .blnChgWidth = False                        '列幅変更ﾌﾗｸﾞ(未変更)
                .strKey = vbNullString                      'ｶﾚﾝﾄ行検索ｷｰ
                .lngCnt = 0                                 '配列ｶｳﾝﾀ
                .typChgSortList = New List(Of ChgSortList)  '配列
            End With
            
            '@【装置ｸﾞﾙｰﾌﾟ取得(処理区分：全件)
            lblnAns = pubblnMasMcGroupList_Sel(CMstrmas_McGrouplistVer, _
                                               CPstrCD02, _
                                               pstrSBID, _
                                               ltypMcGroupList)
            
            '@通信結果判定
            If lblnAns = False Then
                '@結果：異常の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                Exit Sub
            Else
                '@結果：正常の場合
                
                '@=======================
                '@　装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ設定
                '@=======================
                Call prvCmbMcGroup_Disp(ltypMcGroupList)
            End If
                
            
            '@【装置状態ﾏｽﾀ取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnMasWpUseList_Sel(CMstrmas_wpuselistVer, _
                                             mtypUseList, _
                                             mlngUseListCnt)
                                                    
            '@通信結果判定
            If lblnAns = False Then
                '@結果：異常の場合
               
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                Exit Sub
            End If
            
        '@↓2018/08/03 (Fri) 16:17:30 Y.Yoneyama **************************************************
            '@防湿ALDの場合
            If pstrSBID = CPstrSBID3A0 Then
                '@【防湿ALD処理ﾏｽﾀ取得】ﾒｯｾｰｼﾞ送受信処理
                lblnAns = pubblnMasALDProcessList_Sel(CMstrmas_aldprocesslistVer, _
                                             mtypALDProcessList, _
                                             mlngALDProcessListCnt)
                                             
                '@通信結果判定
                If lblnAns = False Then
                    '@結果：異常の場合
               
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                    Exit Sub
                End If
            End If
        '@↑2018/08/03 (Fri) 16:17:30 Y.Yoneyama **************************************************
                
            '@停止ﾗﾍﾞﾙ
            lblTitleT.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)

            'NSYS 1頁目を選択する。
            vsfMcGroupEquipment.TopRow = vsfMcGroupEquipment.Rows.Fixed
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_Load"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑ　ｷｰﾀﾞｳﾝ時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2004/03/22 (Mon) 18:20:24 M.Miura
    '更新日：2008/01/30 (Wed) 13:17:40 N.Kojima
    '備　考：
    '　　　：2008/01/30 (Wed) 13:17:40 N.Kojima     計画保全対応＆ｿｰｽ整備。(案件№02332)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Try
            
            '@=======================
            '@　ｸﾞﾘｯﾄﾞｷｰ制御(ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、前頁ﾎﾞﾀﾝ、次頁ﾎﾞﾀﾝ)
            '@=======================
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfMcGroupEquipment, cmdUP, cmdDown)
            
            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name
                
                '@〓 装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ 〓
                Case cmbMcGroup.Name
                    
                    If e.KeyCode = Keys.Return Then
                        
                        '@=======================
                        '@　装置ｸﾞﾙｰﾌﾟ装置状態情報の最新表示
                        '@=======================
                        Call cmbMcGroup_CloseUp(cmbMcGroup, New EventArgs)
                        
                        '@装置ｸﾞﾙｰﾌﾟが未選択の場合
                        If cmbMcGroup.Text = vbNullString Then
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                        End If
                            
                        Exit Sub
                    End If
                
                '@〓 作業ﾒﾓﾃｷｽﾄ 〓
                Case txtWorkMemo.Name
                
                    '@ｺﾒﾝﾄ項目でEnterｷｰで改行しないのを回避
                
                '@〓 その他 〓
                Case Else
                    
                    '@Enterの場合
                    If e.KeyCode = Keys.Return Then
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

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑ　ｱﾝﾛｰﾄﾞ時処理
    '引　数：Cancel     ：未使用
    '　　　：UnloadMode ：未使用
    '戻り値：なし
    '作成日：2004/03/22 (Mon) 16:16:48 M.Miura
    '更新日：2018/08/06 (Mon) 10:11:47 Y.Yoneyama
    '備　考：
    '　　　：2004/11/01 (Mon) 16:27:07 T.Kitagawa   閉じるﾎﾞﾀﾝ統合
    '　　　：2018/08/06 (Mon) 10:11:47 Y.Yoneyama   防湿ALD対応
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm                 As Boolean              '開放結果格納
        Dim ltypRepairInfoReq           As RepairInfo           '故障修理記録票情報取得要求構造体初期化用
        Dim ltypRepairInfoAns           As RepairInfoAns        '故障修理記録票情報取得応答構造体初期化用
        Dim ltypPreserveInfoReq         As PreserveInfo         '保全記録票情報取得要求構造体初期化用
        Dim ltypPreserveInfoAns         As PreserveInfoAns      '保全記録票情報取得応答構造体初期化用

        Try
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@ﾌﾟﾗｲﾍﾞｰﾄ変数構造体のｸﾘｱ
            mtypUseList = New List(Of UseList)                  '装置状態格納用配列
            mlngUseListCnt = 0                                  '装置状態ｶｳﾝﾀ
        '@↓2018/08/06 (Mon) 10:10:55 Y.Yoneyama **************************************************
            mtypALDProcessList = New List(Of ALDProcessList)    '防湿ALD処理格納配列
            mlngALDProcessListCnt = 0                           '防湿ALD処理ｶｳﾝﾀ
        '@↑2018/08/06 (Mon) 10:10:55 Y.Yoneyama **************************************************
            mtypRepairInfoReq = ltypRepairInfoReq               '故障修理記録票情報取得要求構造体
            mtypRepairInfoAns = ltypRepairInfoAns               '故障修理記録票情報取得応答構造体
            mtypPreserveInfoReq = ltypPreserveInfoReq           '保全記録票情報取得要求構造体
            mtypPreserveInfoAns = ltypPreserveInfoAns           '保全記録票情報取得応答構造体
            
            '@ｿｰﾄ保持用構造体のｸﾘｱ
            With mtypChgSort
                .typChgSortList = New List(Of ChgSortList)
                .blnChgWidth = False        '列幅変更ﾌﾗｸﾞ(未変更)
                .strKey = vbNullString      'ｶﾚﾝﾄ行検索ｷｰを初期化
                .lngCnt = 0
            End With
            
            '@ActInitﾌﾗｸﾞの判定
            If pblnActInitFlg = True Then
                '@Actを自前で初期化した場合
                
                '@=======================
                '@　ACTｵﾌﾞｼﾞｪｸﾄの開放処理
                '@=======================
                lblnAnsTerm = pubblnAct_Term
                
                If lblnAnsTerm = True Then
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                End If
            Else
                '@=======================
                '@　ﾒｲﾝﾒﾆｭｰ画面を広げる処理
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

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGroup_Change
    '機　能：装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/24 (Wed) 17:18:42 M.Miura
    '更新日：2004/10/15 (Fri) 14:05:40 N.Kasai
    '備　考：
    '　　　：2004/10/15 (Fri) 14:05:40 N.Kasai      ｿｰﾄ順保持機能追加
    Private Sub cmbMcGroup_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGroup.Change

        Try
            
            With vsfMcGroupEquipment
            
                '@装置ｸﾞﾙｰﾌﾟ変更ﾌﾗｸﾞｾｯﾄ(変更)
                mblnMcGroupChange = True
            
                '@装置ｸﾞﾙｰﾌﾟがある場合
                If cmbMcGroup.Value <> vbNullString Then
                    '@最新取得ﾎﾞﾀﾝ(有効)
                    cmdNowList.Enabled = True
                End If
                
                '@装置ｸﾞﾙｰﾌﾟ装置状態ﾃﾞｰﾀが表示されていない場合
                If .Rows.Count = .Rows.Fixed Then
                    '@装置ｸﾞﾙｰﾌﾟ変更ﾌﾗｸﾞｾｯﾄ(変更)
                    mblnMcGroupChange = True
                    Exit Sub
                End If
                
                '@=======================
                '@　ﾒｲﾝﾌｫｰﾑ初期化
                '@=======================
                Call prvFrmxxEN0110_Init()
                
                '@=======================
                '@　装置情報ｸﾞﾘｯﾄﾞ初期化
                '@=======================
                Call prvVsfMcGroupEquipment_Init()
                
                '@退避用装置ID初期化
                mstrWpID = vbNullString
                
            End With
            
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMcGroup_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGroup_CloseUp
    '機　能：装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/24 (Wed) 17:11:52 M.Miura
    '更新日：2005/10/03 (Mon) 13:23:53 N.Kasai
    '備　考：
    '　　　：2004/10/19 (Tue) 09:58:55 Y.Yamagishi　ﾒｯｾｰｼﾞﾎﾞｯｸｽの0件表示をしない(不具合改善対応№87)
    '　　　：2005/10/03 (Mon) 13:23:53 N.Kasai      ON ERR対応で最新日時表示をｺﾒﾝﾄ
    Private Sub cmbMcGroup_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGroup.CloseUp
        
        Dim lblnAns                         As Boolean                      '結果格納
        Dim llngAreaEquipmentCnt            As Integer                      'ｴﾘｱ/ｸﾞﾙｰﾌﾟ別情報ｶｳﾝﾄ
        Dim ltypAreaEquipmentList           As List(Of AreaEquipmentList)   'ｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置情報格納
        
        Try
            
            '@装置ｸﾞﾙｰﾌﾟ無変更の場合
            If mblnMcGroupChange = False Then
                '@最新取得ﾎﾞﾀﾝが有効の場合
                If cmdNowList.Enabled = True Then
                    '@最新取得ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdNowList)
                End If
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmbMcGroupCloseUp)
            
            '@装置ｸﾞﾙｰﾌﾟIDがない場合
            If cmbMcGroup.Value = vbNullString Then
                
                '@=======================
                '@　装置情報ｸﾞﾘｯﾄﾞ初期化
                '@=======================
                Call prvVsfMcGroupEquipment_Init()
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmbMcGroupCloseUp)
                Exit Sub
            End If
            
            '@【ｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置状態情報取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnEqAreaCurList_Sel(CMstreq__areacurlistVer, _
                                              vbNullString, _
                                              pstrSBID, _
                                              ltypAreaEquipmentList, _
                                              llngAreaEquipmentCnt, _
                                              CPstrCD20, _
                                              cmbMcGroup.Value)
            
            '@通信結果判定
            If lblnAns = False Then
                '@結果：異常の場合
            
                '@=======================
                '@　ﾒｲﾝﾌｫｰﾑの初期化
                '@=======================
                Call prvFrmxxEN0110_Init()
                
                '@=======================
                '@　装置情報ｸﾞﾘｯﾄﾞ初期化
                '@=======================
                Call prvVsfMcGroupEquipment_Init()
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmbMcGroupCloseUp)
                Exit Sub
            Else
                '@結果：正常の場合
                
                '@=======================
                '@　装置情報ｸﾞﾘｯﾄﾞ表示処理
                '@=======================
                Call prvVsfMcGroupEquipment_Disp(ltypAreaEquipmentList, llngAreaEquipmentCnt)
            
            End If
            
            '@装置ｸﾞﾙｰﾌﾟ変更ﾌﾗｸﾞｾｯﾄ(無変更)
            mblnMcGroupChange = False
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrCmbMcGroupCloseUp)
                    
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMcGroup_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNowList_Click
    '機　能：最新取得ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/15 (Thu) 17:04:38 M.Miura
    '更新日：2004/07/15 (Thu) 17:04:38
    '備　考：
    Private Sub cmdNowList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowList.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@装置ｸﾞﾙｰﾌﾟ変更ﾌﾗｸﾞ(変更)
            mblnMcGroupChange = True
            
            '@=======================
            '@　装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ選択処理
            '@=======================
            Call cmbMcGroup_CloseUp(cmbMcGroup, New EventArgs)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNowList_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMcGroupEquipment_AfterSort
    '機　能：装置情報ｸﾞﾘｯﾄﾞ　ｿｰﾄ後処理
    '引　数：Col    ：列番号
    '　　　：Order  ：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 11:37:54 M.Miura
    '更新日：2004/10/15 (Fri) 14:06:39 N.Kasai
    '備　考：
    '　　　：2004/10/15 (Fri) 14:06:39 N.Kasai      ｿｰﾄ順保持機能追加
    Private Sub vsfMcGroupEquipment_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfMcGroupEquipment.AfterSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfMcGroupEquipment.Rows.Count <= vsfMcGroupEquipment.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ順を格納
            With mtypChgSort
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                End If
                Do While (.typChgSortList.Count -1 < .lngCnt)
                    .typChgSortList.Add(New ChgSortList)
                Loop
                Dim typChgSortListTmp As ChgSortList = New ChgSortList

                '@ｿｰﾄ列番号を格納
                typChgSortListTmp.lngCol = e.Col
                '@並び替え方法を格納(昇順/降順)
                typChgSortListTmp.lngOrder = e.Order

                .typChgSortList(.lngCnt) = typChgSortListTmp

                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
            End With
            
            '@=======================
            '@　ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
            '@=======================
            Call pubVsfAfterSort(vsfMcGroupEquipment, CMlngvsfMcGroupEqColWpID, cmdUP, cmdDown)
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMcGroupEquipment_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMcGroupEquipment_BeforeRowColChange
    '機　能：装置情報ｸﾞﾘｯﾄﾞ　行/列変更前処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/03/24 (Wed) 09:34:45 M.Miura
    '更新日：2008/01/30 (Wed) 15:47:04 N.Kojima
    '備　考：
    '　　　：2004/10/15 (Fri) 14:37:28 N.Kasai      ｿｰﾄ順保持機能追加
    '　　　：2005/02/21 (Mon) 13:32:37 N.Kojima     稼動状態ｵﾌﾟｼｮﾝﾎﾞﾀﾝ制御削除(改善№524、525)
    '　　　：2008/01/30 (Wed) 15:47:04 N.Kojima     計画保全対応＆ｿｰｽ整備。(案件№02332)
    Private Sub vsfMcGroupEquipment_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfMcGroupEquipment.BeforeRowColChange

        Dim OldRow          As Integer      'NSYS 
        Dim NewRow          As Integer      'NSYS 

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfMcGroupEquipment.Rows.Count <= vsfMcGroupEquipment.Rows.Fixed Then
                Return
            End If

            'NSYS ヘッダ行クリック時は処理を抜ける
            If vsfMcGroupEquipment.MouseRow <= 0 AndAlso vsfMcGroupEquipment.Row <= 0 Then
                Return
            End If

            'NSYS 選択値を設定
            OldRow = e.OldRange.r1
            NewRow = e.NewRange.r1

            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If OldRow <> NewRow And NewRow > 0 Then
                
                With vsfMcGroupEquipment
                
                    '@変更前状態ﾗﾍﾞﾙに選択行装置の「装置状態」を表示
                    lblUseName.Text = .GetData(NewRow, CMlngvsfMcGroupEqColUseName)
                    
                    '@現在の運用ﾓｰﾄﾞﾗﾍﾞﾙに選択行装置の「運用ﾓｰﾄﾞ」を表示
                    lblMesMode.Text = .GetData(NewRow, CMlngvsfMcGroupEqColMesModeID)
                
                    '@=======================
                    '@　変更後(装置状態)ｺﾝﾎﾞの初期化&設定
                    '@=======================
                    Call prvCmbUseName_Disp(lblUseName.Text)
                
                    '@=======================
                    '@　防湿ALD処理ﾓｰﾄﾞｺﾝﾎﾞの初期化&設定
                    '@=======================
                    Call prvCmbALDMode_Disp(.GetData(NewRow, CMlngvsfMcGroupEqColEqType), _
                                            .GetData(NewRow, CMlngvsfMcGroupEqColALDProcessModeId), _
                                            .GetData(NewRow, CMlngvsfMcGroupEqColMesModeID))
                
                
                    '@=======================
                    '@　強制M1ﾎﾞﾀﾝの有効化
                    '@=======================
                    '@防湿ALD
                    If pstrSBID = CPstrSBID3A0 Then
                        '@強制M1ﾎﾞﾀﾝ表示
                        If cmdExecution.Visible = True Then
                            '@M1以外
                            If .GetData(NewRow, CMlngvsfMcGroupEqColMesModeID) <> CMstrModeM1 Then
                                cmdExecution.Enabled = True
                            Else
                                cmdExecution.Enabled = False
                            End If
                        End If
                    End If
                    
                End With
                
                '@ﾒｯｾｰｼﾞ表示ﾁｪｯｸﾎﾞｯｸｽ使用可能
                With chkMessage
                    .Enabled = True
                    .Checked = True
                End With
                
                '@ｺﾒﾝﾄの初期化
                txtWorkMemo.Text = vbNullString
            
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(装置ID)
                mtypChgSort.strKey = vsfMcGroupEquipment.GetData(NewRow, CMlngvsfMcGroupEqColWpID)
            
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMcGroupEquipment_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMcGroupEquipment_BeforeSort
    '機　能：装置情報ｸﾞﾘｯﾄﾞ　ｿｰﾄ前処理
    '引　数：Col：列
    '　　　：Order：未使用
    '戻り値：
    '作成日：2004/04/13 (Tue) 12:33:41 N.Kasai
    '更新日：2004/04/13 (Tue) 12:33:41
    '備　考：
    Private Sub vsfMcGroupEquipment_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfMcGroupEquipment.BeforeSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfMcGroupEquipment.Rows.Count <= vsfMcGroupEquipment.Rows.Fixed Then
                Return
            End If
            
            '@=======================
            '@　ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
            '@=======================
            Call pubVsfBeforeSort(vsfMcGroupEquipment, CMlngvsfMcGroupEqColWpID)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMcGroupEquipment_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUP_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(装置情報ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/22 (Mon) 16:46:40 M.Miura
    '更新日：2004/03/22 (Mon) 16:46:40
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
            '@　前頁処理(ｸﾞﾘｯﾄﾞ、前頁、次頁)
            '@=======================
            Call pubVsfCmdUp(vsfMcGroupEquipment, cmdUP, cmdDown)
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(装置情報ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/22 (Mon) 16:47:00 M.Miura
    '更新日：2004/03/22 (Mon) 16:47:00
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
            '@　次頁処理(ｸﾞﾘｯﾄﾞ、前頁、次頁)
            '@=======================
            Call pubVsfCmdDown(vsfMcGroupEquipment, cmdUP, cmdDown)
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbUseName_CloseUp
    '機　能：変更後(装置状態)ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/29 (Mon) 11:09:00 M.Miura
    '更新日：2006/01/10 (Tue) 17:40:12 N.Kasai
    '備　考：
    '　　　：2005/02/21 (Mon) 13:33:10 N.Kojima　   稼動状態ｵﾌﾟｼｮﾝﾎﾞﾀﾝ制御削除(改善№524、525)
    '　　　：2005/12/02 (Fri) 12:04:24 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2006/01/10 (Tue) 17:40:12 N.Kasai      ﾒｯｾｰｼﾞ表示ﾁｪｯｸﾎﾞｯｸｽ表示制御
    Private Sub cmbUseName_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbUseName.Change

        Try
            '@変更後(装置状態)がNULLか
            If cmbUseName.Text = vbNullString Then
                
                '@作業ﾒﾓを無効にする
                txtWorkMemo.Enabled = False
            Else
            
                '@作業ﾒﾓを有効にする
                txtWorkMemo.Enabled = True
            
                '@=======================
                '@　ﾒｯｾｰｼﾞ表示ﾁｪｯｸﾎﾞｯｸｽ表示制御
                '@=======================
                Call prvChkMessage_Disp()
                
            End If
            
            '@=======================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvblnWpSelect_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbUseName_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbUseName_Validate
    '機　能：変更後(装置状態)ｺﾝﾎﾞ　Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/09/17 (Fri) 15:54:39 S.Deguchi
    '更新日：2004/09/17 (Fri) 15:54:39
    '備　考：
    Private Sub cmbUseName_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbUseName.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@=======================
            '@　確定ﾎﾞﾀﾝの活性化ﾁｪｯｸ
            '@=======================
            Call prvblnWpSelect_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbUseName_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbALDMode_Change()
    '機　能：変更後ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/06 (Mon) 15:42:18 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub cmbALDMode_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbALDMode.Change

        Try
            '@=======================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvblnWpSelect_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbALDMode_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：txtWorkMemo_Change
    '機　能：作業ﾒﾓﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/28 (Wed) 14:02:58 N.Kasai
    '更新日：2005/12/02 (Fri) 11:53:44 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 11:53:44 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change

        Dim llngNowByte As Integer 'ﾊﾞｲﾄ数

        Try
            '@余分に発生するｲﾍﾞﾝﾄをｷｬﾝｾﾙする
            If mblnCommentChangeFLG = True Then
                Exit Sub
            End If
            
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtWorkMemo.NowByte
            
            '@=======================
            '@　現在のﾊﾞｲﾄ数の表示処理(表示ﾒｯｾｰｼﾞ変換処理)
            '@=======================
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            
            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_KeyUp
    '機　能：作業ﾒﾓﾃｷｽﾄ　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:15:19 N.Kasai
    '更新日：2005/11/29 (Tue) 14:15:19
    '備　考：
    Private Sub txtWorkMemo_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtWorkMemo.KeyUp

        Try
            '@=======================
            '@　ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作処理
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotCommnt_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_MouseUp
    '機　能：作業ﾒﾓﾃｷｽﾄ　ﾏｳｽ操作時処理
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
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoUp_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(作業ﾒﾓ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/24 (Wed) 14:37:48 M.Miura
    '更新日：2005/12/02 (Fri) 11:50:55 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 11:50:55 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdMemoUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP処理
            '@=======================
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMemoUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(作業ﾒﾓ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/24 (Wed) 14:38:36 M.Miura
    '更新日：2005/12/02 (Fri) 11:52:48 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 11:52:48 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdMemoDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown処理
            '@=======================
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMemoDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdFix_Click
    '機　能：確定ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/24 (Wed) 11:34:52 M.Miura
    '更新日：2011/06/17 (Fri) 10:37:22 T.Oide
    '備　考：
    '　　　：2004/09/17 (Fri) 12:58:46 N.Kasai      MSG格納追加
    '　　　：2005/12/19 (Mon) 16:14:32 N.Kasai      装置状態ﾒｯｾｰｼﾞ表示追加
    '　　　：2005/12/22 (Thu) 16:11:28 N.Kasai      要求ﾒｯｾｰｼﾞにPORT_LIST追加
    '　　　：2006/01/13 (Fri) 11:38:24 N.Kasai      要求ﾒｯｾｰｼﾞにPORT_LIST削除(仕様変更)
    '　　　：2007/01/29 (Mon) 17:51:49 N.Kojima     故障修理記録票登録処理を追加。(案件№01602)
    '　　　：2007/03/23 (Fri) 09:16:21 N.Kojima     故障修理記録票の登録日時をWP_EVENT_HISTORYのENTRY_TIMEで登録するように修正。(案件№01830)
    '　　　：2008/01/30 (Wed) 15:57:33 N.Kojima     計画保全対応＆ｿｰｽ整備。(案件№02332)
    '　　　：2010/02/02 (Tue) 13:23:23 T.Oide       ﾚｽﾎﾟﾝｽの開始位置良くないので修正
    '　　　：2011/06/17 (Fri) 10:37:22 T.Oide       保全記録表の自動起動中止(REQ-1160)
    Private Sub cmdFix_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFix.Click
        
        Dim lblnAns                 As Boolean      '結果取得(True:正常,False:異常)
        Dim ltypUsechange           As Usechange    '装置状態変更格納(要求)
        Dim lstrcmbUseName          As String       '状態変更名格納(ﾒｯｾｰｼﾞ用)
        Dim lstrlblUseName          As String       '状態変更名格納(ﾒｯｾｰｼﾞ用)
        Dim lstrClassDivision       As String       '処理区分
        Dim lstrWpMsg               As String       'MSG格納
        Dim lstrNormalStateFlag     As String       '装置状態通常ﾌﾗｸﾞ
        Dim lstrMessageID           As String       'ﾒｯｾｰｼﾞID
        Dim lstrRepairNo            As String       '故障修理記録票№
        Dim lstrPreserveNo          As String       '保全記録票№
        Dim lstrBeforeUseID         As String       '変更前装置状態ID
        Dim lstrAfterUseID          As String       '変更後装置状態ID
        Dim lstrEntryTime           As String       '登録日時(WP_EVENT_HISTORYの登録日時)
        Dim lstrEditTime            As String       '更新(登録)日時

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@初期化
            lstrWpMsg = vbNullString        'MSG格納
            
        '@↓2018/08/06 (Mon) 19:30:30 Y.Yoneyama **************************************************
            '@装置状態変更場合
            If mblnUseNameUpdate = True Then
            
                '@=======================
                '@　画面入力ﾁｪｯｸ
                '@=======================
                lblnAns = prvblnUseChangeInput_Chk(ltypUsechange)
                
                '@処理結果判定
                If lblnAns = False Then
                    '@結果：異常の場合
                    Exit Sub
                End If
            
                '@=======================
                '@　装置状態ﾒｯｾｰｼﾞ表示
                '@=======================
                lblnAns = prvblnMessage_Chk(cmbUseName.Value, _
                                        lstrNormalStateFlag, _
                                        lstrMessageID)
            
                '@処理結果判定
                If lblnAns = False Then
                    '@結果：異常の場合
                    Exit Sub
                End If
            End If
        '@↑2018/08/06 (Mon) 19:30:30 Y.Yoneyama **************************************************
                
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
                
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
        '@↓2018/08/06 (Mon) 19:25:26 Y.Yoneyama **************************************************
            '@防湿ALD処理更新の場合
            If mblnALDProcessModeUpdate = True Then
                Call prvALDProcessMode_Update()
            End If
        '@↑2018/08/06 (Mon) 19:25:26 Y.Yoneyama **************************************************
            
            
            '@装置状態変更の場合
            If mblnUseNameUpdate = True Then
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrCmdUseChangeClick)
            
                '@装置状態IDを格納
                With vsfMcGroupEquipment
                    lstrBeforeUseID = .GetData(.Row, CMlngvsfMcGroupEqColUseID)    '変更前
                    lstrAfterUseID = cmbUseName.Value                              '変更後
                End With
                
                With ltypUsechange
                
                    '@****************
                    '@　要求ﾃﾞｰﾀ作成
                    '@****************
                    .strMessageID = lstrMessageID               'ﾒｯｾｰｼﾞID
                    lstrClassDivision = CMstrClassDivision0     '処理区分("0"(変更要求))
                
                    '@画面の使用禁止
                    Me.KeyPreview = False
                    
                    '@【装置状態変更】ﾒｯｾｰｼﾞ送受信処理(最終更新日時は、確定時に返される値を使う。)
                    lblnAns = pubblnEqChguse_Ins(CMstreq__chguse__Ver, _
                                             lstrEntryTime, _
                                             ltypUsechange, _
                                             lstrClassDivision)

                    '@画面の使用禁止解除
                    Me.KeyPreview = True
            
                    '@通信結果判定
                    If lblnAns = True Then
                        '@結果：正常の場合
                
                        '@装置状態名格納
                        lstrcmbUseName = cmbUseName.Text     '変更後
                        lstrlblUseName = lblUseName.Text     '変更前
                        
                        '@"<TRM26I>$$装置状態を変更しました。装置[%1] (%2 → %3)"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0026, .strWpName, lstrlblUseName, lstrcmbUseName)
                        '@ｽﾃｰﾀｽﾊﾞｰ表示
                        Call pubVsfInfo_Disp(pstrDMsg)
                            
                        '@過去にMetaの描画が追いつかず、装置状態IDがNULLで送信されてしまったｹｰｽがあったので、ｴﾗｰﾄﾗｯﾌﾟを仕掛ける
                        If cmbUseName.Value <> vbNullString Then

                            '@=======================
                            '@　① 故障修理記録票登録/更新選択処理
                            '@　② 保全記録票登録/更新選択処理
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
                  
                    Else
                        '@結果：異常の場合
                    
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmdUseChangeClick)
                    End If
                End With
            End If


            '@=======================
            '@　ﾒｲﾝﾌｫｰﾑの初期化
            '@=======================
            mblnFrmInitFlg = True
            Call prvFrmxxEN0110_Init()
            mblnFrmInitFlg = False
                    
            '@確定装置IDにﾌｫｰｶｽｾｯﾄ用
            mstrWpID = vsfMcGroupEquipment.GetData(vsfMcGroupEquipment.Row, CMlngvsfMcGroupEqColWpID)
                    
            '@=======================
            '@　最新の装置情報を取得
            '@=======================
            mblnMcGroupChange = True
            Call cmbMcGroup_CloseUp(cmbMcGroup, New EventArgs)
                
            '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(cmbMcGroup)
                
            Exit Sub

        Catch ex As Exception

            '@画面の使用禁止解除
            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdFix_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/22 (Mon) 16:16:05 M.Miura
    '更新日：2004/03/22 (Mon) 16:16:05
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim llngRet             As Integer
        Dim ltypCommonInfo      As CommonInfo

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@ 終了関数を実行する
            '@=======================
            llngRet = publngEnd_Proc(CPstrKeyEN0110, ltypCommonInfo)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClose_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdExecution_Click
    '機　能：[強制M1変更]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/02/07 (Thu) 09:49:58 Y.Yoneyama
    '更新日：2019/02/07 (Thu) 09:49:58 Y.Yoneyama
    '備　考：
    '　　　：2019/02/07 (Thu) 09:49:58 Y.Yoneyama   運用ﾓｰﾄﾞ変更からの機能ｺﾋﾟｰ
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

                    Exit Sub
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

                Exit Sub
            End If
            
            '@表示ﾒｯｾｰｼﾞ変換
            '@「"<TRM2DW>$$強制的に運用モードを変更します。$$[装置が稼動していない事]、
            '@　[offlineである事]を確認の上、実行して下さい。"」の確認ﾒｯｾｰｼﾞ表示
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002D)
            llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

            '@要求確認
            If llngAns = vbNo Then
                '@処理しない
                Exit Sub
            End If

            '@現在の「変更後装置状態ｺﾝﾎﾞ」の値取得列を退避
            llngUseNameValueCol = cmbUseName.ValueCol




        'Private Const CMlngCmbValueCol1                     As Long = 1                         '値取得個数=1
        'Private Const CMlngCmbValueCol2                     As Long = 2                         'ID列番2(非表示項目：運用ﾓｰﾄﾞ)
        'Private Const CMlngCmbValueCol3                     As Long = 3                         'ID列番3(非表示項目：停止ﾌﾗｸﾞ)

        'Private Const CMlngCmbGridColID                     As Long = 1                 'ID列番1(非表示項目：状態ID)
        'Private Const CMlngCmbGridColID2                    As Long = 2                 'ID列番2(非表示項目：運用ﾓｰﾄﾞ)
        'Private Const CMlngCmbGridColID3                    As Long = 3                 'ID列番3(非表示項目：停止ﾌﾗｸﾞ)






            '@「変更後装置状態ｺﾝﾎﾞ」の値取得列を「状態ID(USE_ID)」列に設定
            cmbUseName.ValueCol = CMlngCmbGridColID
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
            lstrBeforeMode = lblMesMode.Text
            lstrBeforeUseName = lblUseName.Text

            '@変更後運用ﾓｰﾄﾞ(M1)、変更後装置状態
            lstrAfterMode = CMstrModeM1
            lstrAfterUseName = cmbUseName.Text

            '@***********************
            '@ 要求ﾃﾞｰﾀ作成
            '@***********************
            With ltypEqChgMode
                '@Wp_ID
                .strWpID = vsfMcGroupEquipment.GetData(vsfMcGroupEquipment.Row, CMlngvsfMcGroupEqColWpID)
                '@変更前装置状態ID
                .strOldUseID = vsfMcGroupEquipment.GetData(vsfMcGroupEquipment.Row, CMlngvsfMcGroupEqColUseID)
                '@変更前装置状態ID(故障修理記録票登録Function引数用)
                lstrBeforeUseID = vsfMcGroupEquipment.GetData(vsfMcGroupEquipment.Row, CMlngvsfMcGroupEqColUseID)

                cmbUseName.ValueCol = CMlngCmbGridColID3    '変更後装置状態ｺﾝﾎﾞのValueCol値を「停止ﾌﾗｸﾞ」列に設定
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

            ltypEqChgMode.strEmpID = pstrUserID             '作業者ID

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
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004F, vsfMcGroupEquipment.GetData(vsfMcGroupEquipment.Row, CMlngvsfMcGroupEqColWpName), _
                    lstrBeforeMode, lstrAfterMode, lstrBeforeUseName, lstrAfterUseName)
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
                '@　ﾒｲﾝﾌｫｰﾑの初期化
                '@=======================
                mblnFrmInitFlg = True
                Call prvFrmxxEN0110_Init()
                mblnFrmInitFlg = False
                    
                '@確定装置IDにﾌｫｰｶｽｾｯﾄ用
                mstrWpID = vsfMcGroupEquipment.GetData(vsfMcGroupEquipment.Row, CMlngvsfMcGroupEqColWpID)
                    
                '@=======================
                '@　最新の装置情報を取得
                '@=======================
                mblnMcGroupChange = True
                Call cmbMcGroup_CloseUp(cmbMcGroup, New EventArgs)
                
                '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmbMcGroup)

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

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：prvFrmxxEN0110_Init
    '機　能：ﾒｲﾝﾌｫｰﾑの初期化
    '引　数：lblnMcGroup：(True：装置ｸﾞﾙｰﾌﾟ項目初期化、False：装置ｸﾞﾙｰﾌﾟ項目無変更)
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 17:27:28 M.Miura
    '更新日：2005/12/19 (Mon) 15:55:51 N.Kasai
    '備　考：
    '　　　：2005/02/21 (Mon) 13:33:28 N.Kojima　   稼動状態ｵﾌﾟｼｮﾝﾎﾞﾀﾝ制御削除(改善№524、525)
    '　　　：2005/12/02 (Fri) 12:05:24 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2005/12/19 (Mon) 15:55:51 N.Kasai      装置状態ﾒｯｾｰｼﾞ追加
    Private Sub prvFrmxxEN0110_Init(Optional ByVal lblnMcGroup As Boolean = False)
        
        Dim llngNowByte         As Integer              '現在のﾊﾞｲﾄ数格納

        Try

            '@装置ｸﾞﾙｰﾌﾟ項目初期化の場合
            If lblnMcGroup = True Then
                '@初期化
                cmbMcGroup.Clear
            End If
            
            '@初期化
            lblUseName.Text = vbNullString              '変更前状態名
            lblEquipmentCnt.Text = vbNullString         '該当件数
            lblNowDate.Text = vbNullString              '最新取得日時
            lblMesMode.Text = vbNullString              '運用ﾓｰﾄﾞ
            lblMesMode.Visible = False
            
        '@↓2018/08/06 (Mon) 17:17:10 Y.Yoneyama **************************************************
            mblnUseNameUpdate = False                   '装置状態更新
            mblnALDProcessModeUpdate = False            '防湿ALD処理更新
        '@↑2018/08/06 (Mon) 17:17:10 Y.Yoneyama **************************************************

            '@作業ﾒﾓ初期化
            With txtWorkMemo
                .ChrMaxByte = CPlngLotCommentsMaxByte   'ﾊﾞｲﾄ数制限
                .Text = vbNullString                    'ﾃｷｽﾄ
                .MultiLineEx = True                     '複数行表示
                llngNowByte = txtWorkMemo.NowByte       'ﾊﾞｲﾄ数格納
                
                '@=======================
                '@ 現在のﾊﾞｲﾄ数の表示処理(表示ﾒｯｾｰｼﾞ変換処理)
                '@=======================
                lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
                .Enabled = False                        '無効
            End With
            
            '@各種ﾎﾞﾀﾝを無効にする
            cmdUP.Enabled = False                       'ｸﾞﾘｯﾄﾞ前頁ﾎﾞﾀﾝ
            cmdDown.Enabled = False                     'ｸﾞﾘｯﾄﾞ次頁ﾎﾞﾀﾝ
            cmdMemoUp.Enabled = False                   '作業ﾒﾓ前頁ﾎﾞﾀﾝ
            cmdMemoDown.Enabled = False                 '作業ﾒﾓ次頁ﾎﾞﾀﾝ
            cmdFix.Enabled = False                      '確定ﾎﾞﾀﾝ
            If mblnFrmInitFlg = False Then
                cmdNowList.Enabled = False              '最新取得ﾎﾞﾀﾝ
            End If
                
            '@変更後(装置状態)ｺﾝﾎﾞの初期化
            With cmbUseName
                .Clear
                .DispCols = CMlngCmbDispCols                                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColName                                                   'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColID                                                   '値取得列
                .DirectInput = False                                                            'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.Name, CMlngCmbFontSize, .Font.Style)                     'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.Name, CMlngCmbGridFontSize, .GridFont.Style)     'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                                  '行の高さ
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter                   '左中央揃え
                If mblnFrmInitFlg = False Then
                    .Enabled = False                                                            '無効
                End If
            End With
            
        '@↓2018/08/03 (Fri) 14:51:11 Y.Yoneyama **************************************************
            '@変更後(装置状態)ｺﾝﾎﾞの初期化
            If mblnFrmInitFlg = False Then
                With cmbALDMode
                    .Clear
                    .DispCols = CMlngCmbDispCols                                                'ｸﾞﾘｯﾄﾞ表示列数
                    .GetCol = CMlngCmbGridColName                                               'ﾃｷｽﾄ表示列
                    .ValueCol = CMlngCmbGridColID                                               '値取得列
                    .DirectInput = False                                                        'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                    .Font = New Font(.Font.Name, CMlngCmbFontSize, .Font.Style)                 'ﾌｫﾝﾄｻｲｽﾞ
                    .GridFont = New Font(.GridFont.Name, CMlngCmbGridFontSize, .GridFont.Style) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    .RowHeight = CMlngCmbRowHeight                                              '行の高さ
                    .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter               '左中央揃え
                    .Enabled = False                                                            '無効
                End With
            End If
            
            '@防湿ALDの場合
            If pstrSBID = CPstrSBID3A0 Then
                lblALDMode.Visible = True
                cmbALDMode.Visible = True
                cmdExecution.Visible = True
                If mblnFrmInitFlg = False Then
                    cmdExecution.Enabled = False
                End If
            Else
                lblALDMode.Visible = False
                cmbALDMode.Visible = False
                cmdExecution.Visible = False
            End If
        '@↑2018/08/03 (Fri) 14:51:11 Y.Yoneyama **************************************************
            
            '@ﾁｪｯｸﾎﾞｯｸｽの初期化
            If mblnFrmInitFlg = False Then
                With chkMessage
                    .Checked = False
                    .Enabled = False
                End With
            End If
            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN0110_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfMcGroupEquipment_Init
    '機　能：装置状態ｸﾞﾘｯﾄﾞ　初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/22 (Mon) 14:36:36 M.Miura
    '更新日：2005/02/21 (Mon) 12:31:54 N.Kojima
    '備　考：
    '　　　：2004/09/17 (Fri) 13:20:01 S.Deguchi    「処理状態」列の追加
    '　　　：2005/02/21 (Mon) 12:31:54 N.Kojima     「運用ﾓｰﾄﾞ」、「稼動状態」列(非表示)の追加。(改善№524、525)
    '　　　：2018/07/24 (Tue) 11:10:28 Y.Yoneyama   防湿ALD対応
    Private Sub prvVsfMcGroupEquipment_Init()

        Try
            
            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfMcGroupEquipment

                .Clear                             'ｸﾘｱ
                .Rows.Count = .Rows.Fixed          '初期行数設定
                .FocusRect = FocusRectEnum.None    'ｶﾚﾝﾄｾﾙの周囲に描画するﾌｫｰｶｽ枠のｽﾀｲﾙを設定(なし)
                
                '@一覧表の表題設定
                Dim cellRange As CellRange = .GetCellRange(CMlngvsfMcGroupEqRowTitle, CMlngvsfMcGroupEqColNo, _
                                                           CMlngvsfMcGroupEqRowTitle, .Cols.Count - 1)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                         '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)            '背景色
                headerStyle.Font = new Font(.Font.FontFamily, CMlngvsfMcGroupEqHFontSize)    'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerStyle.Trimming = StringTrimming.None                                   'NSYS ﾍｯﾀﾞは省略表示なしに設定
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                           'NSYS 配置
                cellRange.Style = headerStyle
                .Rows(CMlngvsfMcGroupEqRowTitle).Height = CMlngvsfMcGroupEqHeightSize        'ﾍｯﾀﾞの高さ
                '.AutoSizeMode = flexAutoSizeColWidth                                        'ｵｰﾄｻｲｽﾞ(列)

                '@列幅、ﾀｲﾄﾙ設定
                '@№
                .Cols(CMlngvsfMcGroupEqColNo).Width = CMlngvsfMcGroupEqColWNo
                .SetData(CMlngvsfMcGroupEqRowTitle, CMlngvsfMcGroupEqColNo, CMlngvsfMcGroupEqColTNo)
                
                '@装置ID
                .Cols(CMlngvsfMcGroupEqColWpID).Width = CMlngvsfMcGroupEqColWWpID
                .SetData(CMlngvsfMcGroupEqRowTitle, CMlngvsfMcGroupEqColWpID, CMlngvsfMcGroupEqColTWpID)
                
                '@装置名
                .Cols(CMlngvsfMcGroupEqColWpName).Width = CMlngvsfMcGroupEqColWWpName
                .SetData(CMlngvsfMcGroupEqRowTitle, CMlngvsfMcGroupEqColWpName, CMlngvsfMcGroupEqColTWpName)
                
                '@処理状態
                .Cols(CMlngvsfMcGroupEqColWpStatus).Width = CMlngvsfMcGroupEqColWWpStatus
                .SetData(CMlngvsfMcGroupEqRowTitle, CMlngvsfMcGroupEqColWpStatus, CMlngvsfMcGroupEqColTWpStatus)
                
                '@装置状態名
                .Cols(CMlngvsfMcGroupEqColUseName).Width = CMlngvsfMcGroupEqColWUseName
                .SetData(CMlngvsfMcGroupEqRowTitle, CMlngvsfMcGroupEqColUseName, CMlngvsfMcGroupEqColTUseName)
                
                '@装置状態ID
                .Cols(CMlngvsfMcGroupEqColUseID).Width = CMlngvsfMcGroupEqColWUseID
                
                '@最終更新日時
                .Cols(CMlngvsfMcGroupEqColLotLastUpdate).Width = CMlngvsfMcGroupEqColWLotLastUpdate
                
                '@WP停止ﾌﾗｸﾞ
                .Cols(CMlngvsfMcGroupEqColWpStopFlag).Width = CMlngvsfMcGroupEqColWWpStopFlag
                
                '@運用ﾓｰﾄﾞ
                .SetData(CMlngvsfMcGroupEqRowTitle, CMlngvsfMcGroupEqColMesModeID, CMlngvsfMcGroupEqColTMesMode)
                .Cols(CMlngvsfMcGroupEqColMesModeID).Width = CMlngvsfMcGroupEqColWMesModeID
                
                '@防湿ALD処理ﾓｰﾄﾞ
                .Cols(CMlngvsfMcGroupEqColALDProcessModeId).Width = CMlngvsfMcGroupEqColWALDProcessModeId
                
                '@防湿ALD処理名
                .SetData(CMlngvsfMcGroupEqRowTitle, CMlngvsfMcGroupEqColALDProcessName, CMlngvsfMcGroupEqColTALDProcessName)
                .Cols(CMlngvsfMcGroupEqColALDProcessName).Width = CMlngvsfMcGroupEqColWALDProcessName
                
                '@EQ_TYPE
                .Cols(CMlngvsfMcGroupEqColEqType).Width = CMlngvsfMcGroupEqColWEqType
                
        '@↓2018/07/18 (Wed) 15:27:58 Y.Yoneyama **************************************************
                '@表示位置
                .Cols(CMlngvsfMcGroupEqColNo).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngvsfMcGroupEqColWpID).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfMcGroupEqColWpName).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfMcGroupEqColWpStatus).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfMcGroupEqColUseName).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfMcGroupEqColMesModeID).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfMcGroupEqColALDProcessName).TextAlign = TextAlignEnum.LeftCenter
                
                '@非表示
                .Cols(CMlngvsfMcGroupEqColWpID).Visible = False             '装置状態ID
                .Cols(CMlngvsfMcGroupEqColUseID).Visible = False            '装置状態ID
                .Cols(CMlngvsfMcGroupEqColLotLastUpdate).Visible = False    '最終更新日時
                .Cols(CMlngvsfMcGroupEqColWpStopFlag).Visible = False       '装置停止ﾌﾗｸﾞ
                .Cols(CMlngvsfMcGroupEqColALDProcessModeId).Visible = False '防湿ALD処理ﾓｰﾄﾞ
                .Cols(CMlngvsfMcGroupEqColEqType).Visible = False           'EQ_TYPE
        '@↑2018/07/18 (Wed) 15:27:58 Y.Yoneyama **************************************************
                        
        '@↓2018/08/03 (Fri) 14:33:13 Y.Yoneyama **************************************************
                '@防湿ALDの場合
                If pstrSBID = CPstrSBID3A0 Then
                    .Cols(CMlngvsfMcGroupEqColALDProcessName).Visible = True
                Else
                    .Cols(CMlngvsfMcGroupEqColALDProcessName).Visible = False
                End If
        '@↑2018/08/03 (Fri) 14:33:13 Y.Yoneyama **************************************************
                
                '@ﾛｯｸ
                .Enabled = False
                        
            End With
            
            With lblNowDate
                '@最新取得日時設定(初期化)
                .Text = vbNullString
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfMcGroupEquipment_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfMcGroupEquipment_Disp
    '機　能：装置ｸﾞﾙｰﾌﾟ装置状態情報表示
    '引　数：ptypMcGroupEquipmentList   ：格納ﾃﾞｰﾀ
    '　　　：llngMcGroupEqCnt           ：ﾃﾞｰﾀ件数
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 14:58:00 M.Miura
    '更新日：2005/10/03 (Mon) 13:20:44 N.Kasai
    '備　考：
    '　　　：2004/08/10 (Tue) 14:54:34 Y.Yamagishi
    '　　　：2004/10/15 (Fri) 14:38:55 N.Kasai      ｿｰﾄ順保持機能追加
    '　　　：2005/02/21 (Mon) 13:27:51 N.Kojima　   「運用ﾓｰﾄﾞ」、「稼動状態」列(非表示)の追加(改善№524、525)
    '　　　：2018/07/24 (Tue) 11:10:28 Y.Yoneyama   防湿ALD対応
    Private Sub prvVsfMcGroupEquipment_Disp(ByRef ltypAreaEquipmentList As List(Of AreaEquipmentList), ByVal llngAreaEquipmentCnt As Integer)
        
        Dim llngDoCnt   As Integer  'ｶｳﾝﾄ
        Dim llngCnt     As Integer  'ｶｳﾝﾄ

        Try
            
            'NSYS 不要イベント発生抑止
            RemoveHandler vsfMcGroupEquipment.BeforeRowColChange, AddressOf vsfMcGroupEquipment_BeforeRowColChange

            '@装置ｸﾞﾙｰﾌﾟがある場合
            If cmbMcGroup.Value <> vbNullString Then
                '@最新取得ﾎﾞﾀﾝ(有効)
                cmdNowList.Enabled = True
            End If
                
            With vsfMcGroupEquipment
                
                If llngAreaEquipmentCnt = 0 Then
                    '@格納ﾃﾞｰﾀがない場合
                    
                    '@=======================
                    '@　装置ｸﾞﾙｰﾌﾟ装置状態情報初期化処理
                    '@=======================
                    Call prvVsfMcGroupEquipment_Init()
                    
                    '@該当件数設定
                    lblEquipmentCnt.Text = Format$(.Rows.Count - 1, CPstrDateFormatKanma)
                    Exit Sub
                Else
                    '@格納ﾃﾞｰﾀがある場合
                    
                    With lblNowDate
                        '@最新取得日時設定
                        .Text = Format$(Now, CPstrDateFormat)
                    End With
                    
                    '@ﾊﾞｯﾌｧ経由で描画
                    .Redraw = False
                    
                    '@行数設定
                    .Rows.Count = .Rows.Fixed
                    .Rows.Count = llngAreaEquipmentCnt + 1
                    
                    llngDoCnt = 0
                    
                    '@装置情報ｸﾞﾘｯﾄﾞの設定
                    Do While .Rows.Count - 1 > llngDoCnt
                    
                        .SetData(llngDoCnt + 1, CMlngvsfMcGroupEqColWpID, _
                            ltypAreaEquipmentList(llngDoCnt).strWpID)                                'WPID
                            
                        .SetData(llngDoCnt + 1, CMlngvsfMcGroupEqColWpName, _
                            ltypAreaEquipmentList(llngDoCnt).strWpName)                              'WP名
                        
                        .SetData(llngDoCnt + 1, CMlngvsfMcGroupEqColWpStatus, _
                            ltypAreaEquipmentList(llngDoCnt).strWpStatusName)                        '処理状態
                            
                        .SetData(llngDoCnt + 1, CMlngvsfMcGroupEqColUseName, _
                            ltypAreaEquipmentList(llngDoCnt).strUseName)                             '状態名
                        
                        .SetData(llngDoCnt + 1, CMlngvsfMcGroupEqColUseID, _
                            ltypAreaEquipmentList(llngDoCnt).strUseId)                               '状態ID
                        
                        .SetData(llngDoCnt + 1, CMlngvsfMcGroupEqColWpStopFlag, _
                            ltypAreaEquipmentList(llngDoCnt).strWpStopFlag)                          'WP停止ﾌﾗｸﾞ
                            
                        .SetData(llngDoCnt + 1, CMlngvsfMcGroupEqColMesModeID, _
                            ltypAreaEquipmentList(llngDoCnt).strMesModeId)                           '運用ﾓｰﾄﾞ
                            
                        .SetData(llngDoCnt + 1, CMlngvsfMcGroupEqColALDProcessModeId, _
                            ltypAreaEquipmentList(llngDoCnt).strALDProcessModeId)                    '防湿ALD処理ﾓｰﾄﾞ

                        .SetData(llngDoCnt + 1, CMlngvsfMcGroupEqColALDProcessName, _
                            ltypAreaEquipmentList(llngDoCnt).strALDProcessName)                      '防湿ALD処理名

                        .SetData(llngDoCnt + 1, CMlngvsfMcGroupEqColEqType, _
                            ltypAreaEquipmentList(llngDoCnt).strEqType)                              'EQ_TYPE
                            
                        .Rows(llngDoCnt + 1).Height = CMlngSlotMapHeight
                        llngDoCnt = llngDoCnt + 1
                    Loop
                    
                    '@行表示
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        .Rows(llngCnt).Visible = True
                    Next llngCnt
                
                    '@№設定
                    For llngDoCnt = 1 To .Rows.Count - 1
                        
                        .SetData(llngDoCnt, CMlngvsfMcGroupEqColNo, llngDoCnt)
                        
                        '@ﾌﾗｸﾞ判定(WP停止)
                        If .GetData(llngDoCnt, CMlngvsfMcGroupEqColWpStopFlag) = CMstrWpStopFlag1 Then
                            '@ｾﾙ色変更
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                            Dim cellRange As CellRange = .GetCellRange(llngDoCnt, CMlngvsfMcGroupEqColNo, llngDoCnt, CMlngvsfMcGroupEqColALDProcessName)
                            cellRange.Style = newStyle   '保留/停止WPｶﾗｰ
                        Else
                            '@ｾﾙ色変更
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngVbColorWhite")
                            newStyle.BackColor = ColorTranslator.FromWin32(CMlngVbColorWhite)
                            Dim cellRange As CellRange = .GetCellRange(llngDoCnt, CMlngvsfMcGroupEqColNo, llngDoCnt, CMlngvsfMcGroupEqColALDProcessName)
                            cellRange.Style = newStyle   '稼動WPｶﾗｰ
                        End If
                        
                    Next llngDoCnt
                    
                    '@列幅の設定
                    .AutoSizeCols(CMlngvsfMcGroupEqColNo, CMlngvsfMcGroupEqColALDProcessName, 7)
                    
                    '@前頁、次頁、ｽｸﾛｰﾙﾗﾍﾞﾙ表示設定
                    If .Rows.Count > CMlngvsfMcGroupEqPageRows + 1 Then
                        cmdUP.Enabled = True
                        cmdDown.Enabled = True
                    Else
                        cmdUP.Enabled = False
                        cmdDown.Enabled = False
                    End If
                    
                    '@該当件数設定
                    lblEquipmentCnt.Text = Format$(.Rows.Count - 1, CPstrDateFormatKanma)
                    
                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    Dim llngBeforeRow As Integer = 0
                    If mtypChgSort.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort.lngCnt - 1
                            'NSYS ソート前の行を退避(行未選択でソート→最新取得時に1行目が表示される対策)
                            llngBeforeRow = .Row
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSort.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort.typChgSortList(llngCnt).lngOrder
                            .Sort(SortFlags.UseColSort, mtypChgSort.typChgSortList(llngCnt).lngCol)
                            'NSYS 退避した値を復元
                            .Row = llngBeforeRow
                        Next llngCnt
                    End If
                    
                    'NSYS 不要イベント発生抑止
                    AddHandler vsfMcGroupEquipment.BeforeRowColChange, AddressOf vsfMcGroupEquipment_BeforeRowColChange
                    
                    '@ｿｰﾄ検索用ｷｰ(ｷｬﾘｱID)がある場合
                    If mtypChgSort.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@装置IDが同じ場合
                            If .GetData(llngCnt, CMlngvsfMcGroupEqColWpID) = mtypChgSort.strKey Then
                                
                                'NSYS 行選択されていない場合はヘッダ行を選択状態にする
                                If .Row > 0 Then
                                    .Row = llngCnt
                                End If
                                
                                'NSYS 明示的にRowColChangeを呼び出す
                                Dim oldRange As CellRange = .GetCellRange(0, 0, 0, 0)
                                Dim newRange As CellRange = .GetCellRange(.Row, CMlngvsfMcGroupEqColNo, .Row, .Cols.Count - 1)
                                Call vsfMcGroupEquipment_BeforeRowColChange(vsfMcGroupEquipment, New RangeEventArgs(oldRange,newRange))

                                '@=======================
                                '@　ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                                '@=======================
                                Call pubVsfBeforeSort(vsfMcGroupEquipment, CMlngvsfMcGroupEqColNo)
                                
                                '@=======================
                                '@　ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
                                '@=======================
                                Call pubVsfAfterSort(vsfMcGroupEquipment, CMlngvsfMcGroupEqColNo, cmdUP, cmdDown)
                                
                                Exit For
                            End If
                        Next llngCnt

                    Else
                        'NSYS タイトル行に行設定
                        .Row = CMlngvsfMcGroupEqRowTitle
                        .TopRow = 1
                    End If
                    
                    .Redraw = True
                    
                    '@=======================
                    '@　ｽｸﾛｰﾙﾎﾞﾀﾝ制御
                    '@=======================
                    Call pubVsfDisp(vsfMcGroupEquipment, cmdUP, cmdDown)
                    
                    '@ﾛｯｸ解除
                    .Enabled = True
                    
                    '@表にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfMcGroupEquipment)
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfMcGroupEquipment_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbMcGroup_Disp
    '機　能：装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ　設定処理
    '引　数：ltypMcGroupList：装置ｸﾞﾙｰﾌﾟ情報格納ﾃﾞｰﾀ
    '戻り値：
    '作成日：2004/03/23 (Tue) 13:15:53 M.Miura
    '更新日：2004/07/20 (Tue) 16:32:04 Y.Yamagishi
    '備　考：
    Private Sub prvCmbMcGroup_Disp(ByRef ltypMcGroupList As McGroupList)
        
        Dim llngCnt As Integer  'ｶｳﾝﾄ

        Try
            
            '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ初期化
            With cmbMcGroup
                
                .Clear
                .DispCols = CMlngCmbDispCols                                                'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColName                                               'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColID                                               '値取得列
                .DirectInput = False                                                        'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font =  New Font(.Font.Name, CMlngCmbFontSize, .Font.Style)                'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.Name, CMlngCmbGridFontSize, .GridFont.Style) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                              '行の高さ
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter               '左寄中央揃え
                .GroupRows = ltypMcGroupList.lngMcGroupListCnt                              '行数
                
                '@**********************
                '@　装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ作成
                '@**********************
                For llngCnt = 0 To ltypMcGroupList.lngMcGroupListCnt - 1
                    '@装置ｸﾞﾙｰﾌﾟ名/装置ｸﾞﾙｰﾌﾟID
                    .AddItem(ltypMcGroupList.typMcGroupList(llngCnt).strMcGroupName & vbTab & _
                             ltypMcGroupList.typMcGroupList(llngCnt).strMcGroupID)
                Next llngCnt
                
                '@装置ｸﾞﾙｰﾌﾟが1件の場合
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
                .strProcName = "prvCmbMcGroup_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbUseName_Disp
    '機　能：変更後装置状態設定
    '引　数：lstrUseNameNew：装置名(IN)
    '戻り値：なし
    '作成日：2004/03/29 (Mon) 15:32:53 M.Miura
    '更新日：2008/01/30 (Wed) 15:46:12 N.Kojima
    '備　考：
    '　　　：2004/09/17 (Fri) 15:35:53 S.Deguchi    装置状態のﾘｽﾄで判別を削除
    '　　　：2005/02/23 (Wed) 11:27:32 N.Kojima     状態ﾌﾗｸﾞにより、ｺﾝﾎﾞに表示する情報をｾｯﾄ(改善№512)
    '　　　：2008/01/30 (Wed) 15:46:12 N.Kojima     計画保全対応＆ｿｰｽ整備。(案件№02332)
    Private Sub prvCmbUseName_Disp(ByVal lstrUseNameNew As String)
        
        Dim llngCnt             As Integer      'ｶｳﾝﾄ

        Try
            
            '@変更後(装置状態)ｺﾝﾎﾞ
            With cmbUseName
                
                '@初期化
                .Clear
                
                '@変更後(装置状態)ﾃﾞｰﾀが格納されている場合
                If mlngUseListCnt > 0 Then
                    
                    '@★ 現在の運用ﾓｰﾄﾞにより処理分岐 ★
                    Select Case lblMesMode.Text
                    
                        '@〓 "M1" 〓
                        Case CPstrM1
                            
                            For llngCnt = 0 To mlngUseListCnt - 1
                                
                                '@ENABLE_MODEに"M1"が含まれている場合
                                If InStr(1, mtypUseList(llngCnt).strUseEnableMode, CPstrM1) <> 0 Then
                                    
                                    '@*******************
                                    '@　装置状態ｺﾝﾎﾞ作成
                                    '@*******************
                                    '@装置状態名/装置状態ID/装置状態ﾓｰﾄﾞ/装置停止ﾌﾗｸﾞ)
                                    .AddItem(mtypUseList(llngCnt).strUseName & vbTab & _
                                             mtypUseList(llngCnt).strUseId & vbTab & _
                                             mtypUseList(llngCnt).strUseEnableMode & vbTab & _
                                             mtypUseList(llngCnt).strUseStopFlag)
                                End If
                            Next llngCnt
                            
                            '@行数指定
                            .GroupRows = .ListCount
                            
                        
                        '@〓 "S1" 〓
                        Case CPstrS1
                                
                            For llngCnt = 0 To mlngUseListCnt - 1
                                
                                '@ENABLE_MODEに"S1"が含まれている場合
                                If InStr(1, mtypUseList(llngCnt).strUseEnableMode, CPstrS1) <> 0 Then
                                    
                                    '@*******************
                                    '@　装置状態ｺﾝﾎﾞ作成
                                    '@*******************
                                    '@装置状態名/装置状態ID/装置状態ﾓｰﾄﾞ/装置停止ﾌﾗｸﾞ)
                                    .AddItem(mtypUseList(llngCnt).strUseName & vbTab & _
                                             mtypUseList(llngCnt).strUseId & vbTab & _
                                             mtypUseList(llngCnt).strUseEnableMode & vbTab & _
                                             mtypUseList(llngCnt).strUseStopFlag)
                                End If
                            Next llngCnt
                            
                            '@行数指定
                            .GroupRows = .ListCount
                                
                                
                        '@〓 "S2" 〓
                        Case CPstrS2
                                    
                            For llngCnt = 0 To mlngUseListCnt - 1
                                
                                '@ENABLE_MODEに"S2"が含まれている場合
                                If InStr(1, mtypUseList(llngCnt).strUseEnableMode, CPstrS2) <> 0 Then
                                    
                                    '@*******************
                                    '@　装置状態ｺﾝﾎﾞ作成
                                    '@*******************
                                    '@装置状態名/装置状態ID/装置状態ﾓｰﾄﾞ/装置停止ﾌﾗｸﾞ)
                                    .AddItem(mtypUseList(llngCnt).strUseName & vbTab & _
                                             mtypUseList(llngCnt).strUseId & vbTab & _
                                             mtypUseList(llngCnt).strUseEnableMode & vbTab & _
                                             mtypUseList(llngCnt).strUseStopFlag)
                                End If
                            Next llngCnt
                            
                            '@行数指定
                            .GroupRows = .ListCount
                            
                        
                        '@〓 その他("F") 〓
                        Case Else
                        
                            For llngCnt = 0 To mlngUseListCnt - 1
                                
                                '@ENABLE_MODEに"F"が含まれている場合
                                If InStr(1, mtypUseList(llngCnt).strUseEnableMode, CPstrF) <> 0 Then
                                    
                                    '@*******************
                                    '@　装置状態ｺﾝﾎﾞ作成
                                    '@*******************
                                    '@装置状態名/装置状態ID/装置状態ﾓｰﾄﾞ/装置停止ﾌﾗｸﾞ)
                                    .AddItem(mtypUseList(llngCnt).strUseName & vbTab & _
                                             mtypUseList(llngCnt).strUseId & vbTab & _
                                             mtypUseList(llngCnt).strUseEnableMode & vbTab & _
                                             mtypUseList(llngCnt).strUseStopFlag)
                                End If
                            Next llngCnt
                            
                            '@行数指定
                            .GroupRows = .ListCount
            
                    End Select
                End If

                '@装置状態が1件の場合
                If .ListCount = 1 Then
                    '@1件目表示
                    .ListIndex = 0
                End If
                
                '@有効にする
                .Enabled = True
                    
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbUseName_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnUseChangeInput_Chk
    '機　能：確定前入力ﾁｪｯｸ
    '引　数：ltypUsechange  ：格納ﾃﾞｰﾀ
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/29 (Mon) 15:34:29 M.Miura
    '更新日：2008/01/30 (Wed) 16:11:01 N.Kojima
    '備　考：
    '　　　：2005/02/25 (Fri) 11:24:40 N.Kojima     停止ﾌﾗｸﾞの設定処理の変更(改善№524、525)
    '　　　：2008/01/30 (Wed) 16:11:01 N.Kojima     計画保全対応＆ｿｰｽ整備。(案件№02332)
    Private Function prvblnUseChangeInput_Chk(ByRef ltypUsechange As Usechange) As Boolean

        Try
            
            '@戻り値の初期化
            prvblnUseChangeInput_Chk = False
            
            '@****************
            '@　要求ﾃﾞｰﾀ作成
            '@****************
            With vsfMcGroupEquipment
                
                ltypUsechange.strWpID = .GetData(.Row, CMlngvsfMcGroupEqColWpID)           '装置ID
                ltypUsechange.strWpName = .GetData(.Row, CMlngvsfMcGroupEqColWpName)       '装置名
                ltypUsechange.strOldUseID = .GetData(.Row, CMlngvsfMcGroupEqColUseID)      '変更前装置状態ID
                ltypUsechange.strComments = txtWorkMemo.Text                               '作業ﾒﾓ
                
                '@停止ﾌﾗｸﾞ格納
                cmbUseName.ValueCol = CMlngCmbGridColID3            '変更後(装置状態)ｺﾝﾎﾞの値取得列を「停止ﾌﾗｸﾞ」列に設定
                ltypUsechange.strWpStopFlag = cmbUseName.Value      '「停止ﾌﾗｸﾞ」を格納
                cmbUseName.ValueCol = CMlngCmbGridColID             '変更後(装置状態)ｺﾝﾎﾞの値取得列を「装置状態ID」列に戻す
                
                '@WPIDの入力ﾁｪｯｸ
                If ltypUsechange.strWpID = vbNullString Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0034)
                    '@"装置IDが設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                      
                    '@装置情報ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfMcGroupEquipment)
                    
                    Exit Function
                End If
                
                '@変更後(装置状態)が設定されている場合
                If cmbUseName.Text <> vbNullString Then
                    
                    '@変更後(装置状態)IDを格納
                    ltypUsechange.strUseId = cmbUseName.Value
                End If
                
                '@装置状態IDの入力ﾁｪｯｸ
                If ltypUsechange.strUseId = vbNullString Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0035)
                    '@"状態が設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@装置情報ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfMcGroupEquipment)
                    
                    Exit Function
                End If
                
                '@------------------------------------------
                '@　変更前装置状態IDと変更後装置状態IDのﾁｪｯｸ
                '@------------------------------------------
                '@変更前装置状態IDと変更後装置状態IDが同じか
                If ltypUsechange.strUseId = ltypUsechange.strOldUseID Then
                    '@同じ場合
                    
                    '@格納「停止ﾌﾗｸﾞ」と、選択行の「停止ﾌﾗｸﾞ」が同じか
                    If ltypUsechange.strWpStopFlag = .GetData(.Row, CMlngvsfMcGroupEqColWpStopFlag) Then
                        '@同じ場合
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0036)
                        '@"「変更前」と「変更後」の状態が同じです。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@変更後(装置状態)ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmbUseName)
                        
                        Exit Function
                    End If
                End If
                
                '@作業ﾒﾓが2048Byte以上か
                If LenB(txtWorkMemo.Text) > CPlngLotCommentsMaxByte Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0026)
                    '@"最大文字数を超えました。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@作業ﾒﾓﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtWorkMemo)
                    
                    Exit Function
                End If
                
                '@戻り値に"True:ﾁｪｯｸOK"をｾｯﾄ
                prvblnUseChangeInput_Chk = True
            
            End With
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnUseChangeInput_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnWpSelect_Chk
    '機　能：選択した装置の状態を確認して,確定ﾎﾞﾀﾝの活性化処理を行う
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/17 (Fri) 15:41:16 S.Deguchi
    '更新日：2005/10/05 (Wed) 14:10:52 N.Kasai
    '備　考：
    '　　　：2005/02/21 (Mon) 13:31:20 N.Kojima　   稼動状態ｵﾌﾟｼｮﾝﾎﾞﾀﾝ制御削除(改善№524、525)
    '　　　：2005/10/05 (Wed) 14:10:52 N.Kasai      状態が空欄の場合は確定ﾎﾞﾀﾝ使用不可
    Private Sub prvblnWpSelect_Chk()

        Dim lstrYoto            As String       '状態
        Dim lstrALDProcessName  As String       'ALD処理名
        Dim blnEnable           As Boolean

        Try
            
            '@初期化
            blnEnable = False
            mblnUseNameUpdate = False           '装置状態更新
            mblnALDProcessModeUpdate = False    '防湿ALD処理更新

            
            '@選択行の情報を格納
            With vsfMcGroupEquipment
                If .Row <> 0 Then
                    lstrYoto = .GetData(.Row, CMlngvsfMcGroupEqColUseName)
                    lstrALDProcessName = .GetData(.Row, CMlngvsfMcGroupEqColALDProcessName)
                Else
                    cmdFix.Enabled = blnEnable
                    Exit Sub
                End If
            End With
            
            '@------------------------------------------
            '@装置状態のﾁｪｯｸ
            '@------------------------------------------
            If cmbUseName.Text <> vbNullString Then
                '@変更された場合
                If lstrYoto <> cmbUseName.Text Then
                    mblnUseNameUpdate = True
                    blnEnable = True
                End If
            End If

            '@------------------------------------------
            '@ALD処理ﾓｰﾄﾞのﾁｪｯｸ
            '@------------------------------------------
            If cmbALDMode.Enabled = True Then
                If cmbALDMode.Text <> vbNullString Then
                    '@変更された場合
                    If lstrALDProcessName <> cmbALDMode.Text Then
                        mblnALDProcessModeUpdate = True
                        blnEnable = True
                    End If
                End If
            End If
            
            cmdFix.Enabled = blnEnable
            
            '@有効の場合
            If cmdFix.Enabled = True Then
                If ActiveControl.Name = cmbUseName.Name Then
                    '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdFix)
                End If
            End If
            

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnWpSelect_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnWpSelect_Chk_bak
    '機　能：選択した装置の状態を確認して,確定ﾎﾞﾀﾝの活性化処理を行う
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/17 (Fri) 15:41:16 S.Deguchi
    '更新日：2005/10/05 (Wed) 14:10:52 N.Kasai
    '備　考：
    '　　　：2005/02/21 (Mon) 13:31:20 N.Kojima　   稼動状態ｵﾌﾟｼｮﾝﾎﾞﾀﾝ制御削除(改善№524、525)
    '　　　：2005/10/05 (Wed) 14:10:52 N.Kasai      状態が空欄の場合は確定ﾎﾞﾀﾝ使用不可
    Private Sub prvblnWpSelect_Chk_bak()

        Dim lstrYoto        As String       '状態
        Dim lstrStatus      As String       '稼動状態

        Try
            
            '@選択行の情報を格納
            With vsfMcGroupEquipment
                If .Row <> 0 Then
                    lstrYoto = .GetData(.Row, CMlngvsfMcGroupEqColUseName)             '状態
                    lstrStatus = .GetData(.Row, CMlngvsfMcGroupEqColWpStopFlag)        '停止ﾌﾗｸﾞ
                Else
                    Exit Sub
                End If
            End With
            
            '@状態が空欄の場合は確定ﾎﾞﾀﾝ使用不可
            If cmbUseName.Text = vbNullString Then
                Exit Sub
            End If
            
            '@状態と稼動状態のどちらかが変更された場合には,確定ﾎﾞﾀﾝを活性化する
            If lstrYoto <> cmbUseName.Text Then
                '@状態が変更されている場合
                
                '@確定ﾎﾞﾀﾝを有効に
                cmdFix.Enabled = True
                
                '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdFix)
            Else
                '@状態が変更されていない場合
                
                '@確定ﾎﾞﾀﾝを無効に
                cmdFix.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnWpSelect_Chk_bak"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnMessage_Chk
    '機　能：装置状態ﾒｯｾｰｼﾞ表示ﾁｪｯｸ処理
    '引　数：lstrUseID          ：変更後(装置)状態ID
    '　　　：lstrNormalStateFlag：装置状態通常ﾌﾗｸﾞ
    '　　　：lstrMessageID      ：ﾒｯｾｰｼﾞID
    '戻り値：True：成功、False：失敗
    '作成日：2005/12/16 (Fri) 16:23:25 N.Kasai
    '更新日：2005/12/16 (Fri) 16:23:25
    '備　考：
    Private Function prvblnMessage_Chk(ByVal lstrUseID As String, _
                                       ByRef lstrNormalStateFlag As String, _
                                       ByRef lstrMessageID As String) As Boolean
        
        Dim llngCnt     As Integer      '汎用ｶｳﾝﾀ
        Dim lblnAns     As Boolean      '戻り値格納用
        
        Try
            
            '@戻り値の初期化
            prvblnMessage_Chk = False
            
            '@装置状態検索
            For llngCnt = 0 To mlngUseListCnt - 1
                
                '@選択された変更後装置状態IDが装置状態ﾏｽﾀにあるか
                If mtypUseList(llngCnt).strUseId = lstrUseID Then
                    '@ﾃﾞｰﾀ発見!!
                    
                    '@戻り値に"True:あり"をｾｯﾄ
                    prvblnMessage_Chk = True
                    
                    '@ﾃﾞｰﾀ格納
                    lstrNormalStateFlag = mtypUseList(llngCnt).strNormalStateFlag   '装置状態通常ﾌﾗｸﾞの判定(0:通常以外、1:通常)
                    lstrMessageID = mtypUseList(llngCnt).strMessageID               'ﾒｯｾｰｼﾞID
                    
                    '@装置状態通常ﾌﾗｸﾞが"1:通常"か(0:通常以外、1:通常)
                    If mtypUseList(llngCnt).strNormalStateFlag = CMstrNormalStateFlag Then
                        '@"1:通常"の場合
                        
                        '@ﾒｯｾｰｼﾞIDにNULLをｾｯﾄ
                        lstrMessageID = vbNullString
                        
                        '@ﾒｯｾｰｼﾞ表示にﾁｪｯｸがされた場合
                        If chkMessage.Checked = True Then
                            
                            '@=======================
                            '@　ﾒｯｾｰｼﾞ状態取得
                            '@=======================
                            lblnAns = prvblnWpMsg_Disp
                            
                            '@処理結果判定
                            If lblnAns = False Then
                                '@結果：異常の場合
                            
                                '@ﾒｯｾｰｼﾞ表示に失敗
                                prvblnMessage_Chk = False
                            End If
                        End If
                        
                        Exit For
                        
                    Else
                        '@"1:通常"以外の場合
                    
                        '@「ﾒｯｾｰｼﾞ表示」にﾁｪｯｸがされた場合
                        If chkMessage.Checked = True Then
                            
                            '@通常以外を選択
                            If mtypUseList(llngCnt).strMessageID <> vbNullString Then
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0028, mtypUseList(llngCnt).strMessage)
                                '@"<TRM28I>$$アナウンスメッセージ表示を設定します。$状態を[通常]に変更した際に、メッセージが表示されます。$$[メッセージ内容]$%1"
                                Call publngMsgBoxInfo(pstrDMsg, vbInformation, frmxxEN00C0.Instance.Text, True, 16)
                            End If
                        Else
                            '@ﾒｯｾｰｼﾞ非表示の場合(ﾒｯｾｰｼﾞIDは送信しない)
                            lstrMessageID = vbNullString
                        End If
                        Exit For
                    End If
                End If
            Next
            
            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnMessage_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvblnWpMsg_Disp
    '機　能：装置状態ﾒｯｾｰｼﾞ表示
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
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvblnWpMsgDisp)
            
            '@****************
            '@　要求ﾃﾞｰﾀ作成
            '@****************
            With vsfMcGroupEquipment
                ltypEqWpMsgListReq.strMsgVer = CMstreq__wpmsglistVer                   'ﾒｯｾｰｼﾞVer
                ltypEqWpMsgListReq.strWpID = .GetData(.Row, CMlngvsfMcGroupEqColWpID)  '装置ID
            End With
          
            '@【装置状態ﾒｯｾｰｼﾞ取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnEqWpMsgList_Sel(ltypEqWpMsgListReq, _
                                            ltypEqWpMsgListAns)

            '@通信結果判定
            If lblnAns = True Then
                '@結果：正常の場合
                
                '@戻り値に"True:取得成功"をｾｯﾄ
                prvblnWpMsg_Disp = True
                
                '@ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示(件数分ﾒｯｾｰｼﾞﾎﾞｯｸｽを表示します。)
                With ltypEqWpMsgListAns
                    '@取得件数判定
                    If .llngMsgListCnt > 0 Then
                        '@取得ｶｳﾝﾄ分ﾙｰﾌﾟ
                        For llngCnt = 0 To .llngMsgListCnt - 1
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0035, ltypEqWpMsgListAns.typMsgList(llngCnt).strMessage)
                            '@"<TRM35I>$$アナウンスメッセージが設定されています。$$[メッセージ内容]$%1"
                            Call publngMsgBoxInfo(pstrDMsg, vbInformation, frmxxEN00C0.Instance.Text, True, 16)
                        Next
                    End If
                End With
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrPrvblnWpMsgDisp)
                
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
                .strProcName = prvblnWpMsg_Disp
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvchkMessage_Disp
    '機　能：ﾒｯｾｰｼﾞ表示ﾁｪｯｸﾎﾞｯｸｽ表示制御
    '引　数：なし
    '戻り値：なし
    '作成日：2006/01/10 (Tue) 13:57:16 N.Kasai
    '更新日：2006/01/10 (Tue) 13:57:16
    '備　考：ｺﾝﾎﾞChangeとValidateに記述あり
    Private Sub prvChkMessage_Disp()

        Try

            Dim lstrUseID           As String       '装置状態ID格納
            Dim llngCnt             As Integer      'ｶｳﾝﾀ
            Dim lstrNormalStateFlag As String       '装置状態通常ﾌﾗｸﾞ格納(0:通常以外、1:通常)
            
            '@変更後(装置状態)ｺﾝﾎﾞの装置状態IDを取得
            cmbUseName.ValueCol = CMlngCmbGridColID
            lstrUseID = cmbUseName.Value
            
            '@装置状態ﾏｽﾀﾃﾞｰﾀから装置状態検索
            For llngCnt = 0 To mlngUseListCnt - 1
                
                '@選択された変更後装置状態IDが装置状態ﾏｽﾀの装置状態IDと同じか
                If mtypUseList(llngCnt).strUseId = lstrUseID Then
                    '@同じ場合
                    
                    '@装置状態ﾏｽﾀの装置状態ﾌﾗｸﾞを格納
                    lstrNormalStateFlag = mtypUseList(llngCnt).strNormalStateFlag   '装置状態通常ﾌﾗｸﾞの判定(0:通常以外、1:通常)
                    
                    '@装置状態ﾏｽﾀの装置状態通常ﾌﾗｸﾞが"1:通常"か(0:通常以外、1:通常)
                    If lstrNormalStateFlag = CMstrNormalStateFlag Then
                        
                        '@-----------------------------------------
                        '@　ﾒｯｾｰｼﾞﾁｪｯｸﾎﾞｯｸｽ制御
                        '@　　①変更後装置状態が"通常"の場合使用不可
                        '@　　②ﾒｯｾｰｼﾞﾁｪｯｸﾎﾞｯｸｽ(使用不可)
                        '@-----------------------------------------
                        With chkMessage
                            .Checked = True
                            .Enabled = False
                        End With
                    Else
                        '@通常以外で変更前と変更後が同じ場合はﾁｪｯｸﾎﾞｯｸｽの使用は不可
                        If cmbUseName.Text = lblUseName.Text Then
                            '@ﾒｯｾｰｼﾞﾁｪｯｸﾎﾞｯｸｽ(使用不可)
                            With chkMessage
                                .Checked = False
                                .Enabled = False
                            End With
                        Else
                            '@通常以外を選択した場合
                            
                            '@-----------------------------------------
                            '@　ﾒｯｾｰｼﾞﾁｪｯｸﾎﾞｯｸｽ制御
                            '@　　①変更後装置状態が選択済みの場合使用可能
                            '@　　②ﾒｯｾｰｼﾞﾁｪｯｸﾎﾞｯｸｽ(使用可)
                            '@-----------------------------------------
                            With chkMessage
                                .Checked = True
                                .Enabled = True
                            End With
                        End If
                    End If
                    
                    '@一致した場合はﾙｰﾌﾟ抜け
                    Exit For
                End If
            Next
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvchkMessage_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

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
    '更新日：2010/02/01 (Mon) 13:20:47 T.Oide
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
    'メモ：2010/02/01 (Mon) 13:20:47 T.Oide
    '　　　故障修理記録は基本的にOZMAへ運用を移行するため自動作成を中止する
    '　　　但し、機能自体の削除は時期を見て行うため、今回の修正では削除しない
    '　　　また、保全記録は当面現状の運用を継続するため、修正対象としない


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
            
                '@〓 "3:保全記録票登録"or"4:保全記録票更新" 〓
                Case CPstrThree, CPstrFour
                
                    '@=======================
                    '@　保全記録票更新処理
                    '@=======================
                    Call prvPreserveReportInsOrUpd_Proc(lstrBeforeUseID, _
                                                        lstrAfterUseID, _
                                                        lstrEntryTime, _
                                                        lstrEditTime, _
                                                        lstrPreserveNo, _
                                                        lstrTrnDivision, _
                                                        lstrEventID)


                '@〓 "5:故障修理記録登録＆保全記録票更新"or"6:保全記録票登録＆故障修理記録更新" 〓
                Case CPstrFive, CPstrSix
                
                    '@=======================
                    '@　保全記録票登録/更新処理
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

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

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
            '@　★更新処理
            '@　　保全記録票の保全完了日時を登録する。
            '@**************************************************
            
            '@★ 処理区分により処理分岐 ★
            Select Case lstrTrnDivision

                '@〓 "3 or 6:保全記録票登録" 〓
                Case CPstrThree, CPstrSix

                    '@戻り値に"True:成功"をｾｯﾄ(実際は通信はしないが帳尻合わせ)
                    lblnAns = True


                '@〓 "4 or 5:保全記録票更新" 〓
                Case CPstrFour, CPstrFive
            
                    '@****************
                    '@　要求ﾃﾞｰﾀ作成
                    '@****************
                    With mtypPreserveInfoReq
                
                        .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸID
                        .strEmpID = pstrUserID                      '作業者ID(起案者、更新者、発見者)
                        .strEmpName = pstrUserName                  '作業者名(起案者、更新者、発見者)
                        .strMsgVer = CMstrpre_chgpreservereportVer  'ﾒｯｾｰｼﾞVer
                        .strOldUseID = lstrBeforeUseID              '変更前装置状態ID
                        .strUseId = lstrAfterUseID                  '変更後装置状態ID
                        .strWpID = vsfMcGroupEquipment.GetData(vsfMcGroupEquipment.Row, CMlngvsfMcGroupEqColWpID)      '装置ID
                        .strWpName = vsfMcGroupEquipment.GetData(vsfMcGroupEquipment.Row, CMlngvsfMcGroupEqColWpName)  '装置名
                        .strActionID = CPstrThree                   'ｱｸｼｮﾝID(3:終了(予定)日時更新)
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
            
            '@**************************
            '@　引継ぎ構造体に情報をｾｯﾄ
            '@**************************
            With ptypPreserveConnectInfo

                .strSbID = pstrSBID                 'ｼｽﾃﾑﾌﾞﾛｯｸID
                .strMcGroupID = cmbMcGroup.Value    '装置ｸﾞﾙｰﾌﾟID
                .strMcGroupName = cmbMcGroup.Text   '装置ｸﾞﾙｰﾌﾟ名
                .strPreserveNo = lstrPreserveNo     '保全記録票№
                .strEntryTime = lstrEntryTime       '登録日時
                .strEditTime = lstrEditTime         '更新日時
                .strWpID = vsfMcGroupEquipment.GetData(vsfMcGroupEquipment.Row, CMlngvsfMcGroupEqColWpID)      '装置ID
                .strWpName = vsfMcGroupEquipment.GetData(vsfMcGroupEquipment.Row, CMlngvsfMcGroupEqColWpName)  '装置名
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
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006Q, CMstrPreserveTitle, _
                                                        lstrMsg, lstrPreserveNo)
                        '@"<TRM6QI>$$保全記録票を[登録or更新]しました。保全記録票№[PXXXXXXXX]"
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

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbALDMode_Disp
    '機　能：防湿ALD処理ﾓｰﾄﾞ設定
    '引　数：lstrWpId
    '      ：lstrALDModeId
    '      ：lstrMesModeId
    '戻り値：なし
    '作成日：2018/08/03 (Fri) 15:04:33 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvCmbALDMode_Disp(ByVal lstrEqType As String, ByVal lstrALDModeId As String, _
            ByVal lstrMesModeId As String)
        
        Dim llngCnt             As Integer      'ｶｳﾝﾄ
        Dim llngFindIndex       As Integer

        Try
            
            
            With cmbALDMode
                
                '@防湿ALD以外は終了
                If pstrSBID <> CPstrSBID3A0 Then
                    .Enabled = False
                    Exit Sub
                End If
                
                .Clear
                .Enabled = False

                '@ﾃﾞｰﾀが格納されている場合
                If mlngALDProcessListCnt < 0 Then
                    Exit Sub
                End If
                        
                '@初期化
                llngFindIndex = 0
                        
                '@防湿ALD処理ﾓｰﾄﾞ一覧を検索
                For llngCnt = 0 To mlngALDProcessListCnt - 1
                                
                    '@EQ_TYPEが同じ場合
                    If mtypALDProcessList(llngCnt).strEqType = lstrEqType Then
                                    
                        '@*******************
                        '@　防湿ALD処理ﾓｰﾄﾞｺﾝﾎﾞ作成
                        '@*******************
                        .AddItem(mtypALDProcessList(llngCnt).strProcessName & vbTab & _
                                mtypALDProcessList(llngCnt).strModeId)
                                
                        '@現在設定中のIDの場合Indexを記憶
                        If mtypALDProcessList(llngCnt).strModeId = lstrALDModeId Then
                            llngFindIndex = .ListCount - 1
                        End If
                    End If
                Next
                
                '@行数指定
                .GroupRows = .ListCount
                
                '@選択が1つの場合
                If .ListCount <= 1 Then
                    .ListIndex = 0
                    .Enabled = False
                
                Else
                    '@ﾓｰﾄﾞ選択が複数あるが、現在設定されていない場合
                    If lstrALDModeId = vbNullString Then
                        .ListIndex = -1
                    Else
                        .ListIndex = llngFindIndex
                    End If
                    
                    '@運用ﾓｰﾄﾞM1の場合のみ選択可能
                    If lstrMesModeId = CPstrM1 Then
                        .Enabled = True
                    End If
                End If
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbALDMode_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbALDMode_CloseUp
    '機　能：防湿ALD処理ﾓｰﾄﾞ設定
    '引　数：lstrWpId
    '      ：lstrALDModeId
    '戻り値：なし
    '作成日：2018/08/03 (Fri) 15:04:33 Y.Yoneyama
    '更新日：
    '備　考：
    Private Function prvALDProcessMode_Update() As Boolean
        
        Dim lblnAns                 As Boolean
        Dim ltypALDProcessChange    As ALDProcessChange

        Try
            
            
            '@戻り値初期化
            prvALDProcessMode_Update = False
                
            With ltypALDProcessChange
                
                '@****************
                '@ 要求ﾃﾞｰﾀ作成
                '@****************
                .strSbID = pstrSBID
                .strClassDivision = CMstrClassDivision0     '処理区分("0"(変更要求))
                .strWpID = vsfMcGroupEquipment.GetData(vsfMcGroupEquipment.Row, CMlngvsfMcGroupEqColWpID)
                .strALDProcessModeId = cmbALDMode.Value
            
            
                '@画面の使用禁止
                Me.KeyPreview = False
            
                '@ﾒｯｾｰｼﾞ送受信処理
                lblnAns = pubblnEqALDProcessChange_Upd(CMstreq__aldprocesschangeVer, _
                                                       ltypALDProcessChange)

                '@画面の使用禁止解除
                Me.KeyPreview = True
            
                '@通信結果判定
                If lblnAns = True Then
                    '@結果：正常の場合

                    '@"<TRM7PI>$$防湿ALD処理モードを変更しました。装置[%1] (%2 → %3)"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf007P, _
                        vsfMcGroupEquipment.GetData(vsfMcGroupEquipment.Row, CMlngvsfMcGroupEqColWpName), _
                        vsfMcGroupEquipment.GetData(vsfMcGroupEquipment.Row, CMlngvsfMcGroupEqColALDProcessName), _
                        cmbALDMode.Text)
                    '@ｽﾃｰﾀｽﾊﾞｰ表示
                    Call pubVsfInfo_Disp(pstrDMsg)
                                                             
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrCmdUseChangeClick)
                  
                Else
                    '@結果：異常の場合
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdUseChangeClick)
                    Exit Function
                End If
            
            End With
            
            prvALDProcessMode_Update = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbALDMode_CloseUp"
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
    
End Class
