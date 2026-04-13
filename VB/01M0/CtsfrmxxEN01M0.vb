'ﾌｧｲﾙ名：xxEN01M0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾚﾁｸﾙﾏﾆｭｱﾙ搬送 ﾒｲﾝﾌｫｰﾑ
'作成日：2005/02/16 (Wed) 11:30:31 N.Kasai
'更新日：2006/02/27 (Mon) 10:45:47 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01M0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01M0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01M0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01M0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01M0)
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
    Private Const CMstrLocalVersion                         As String = "03.01"                 '機能ﾊﾞｰｼﾞｮﾝ

    '@機能名
    Private Const CMstrLocalMenuKey                         As String = CPstrKeyEN01M0

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_wplist__Ver                      As String = "05.01"                 '装置一覧取得
    Private Const CMstrrtcllist____Ver                      As String = "01.05"                 'ﾚﾁｸﾙ情報取得
    Private Const CMstrmas_stockerlistVer                   As String = "01.00"                 'ｽﾄｯｶｰﾏｽﾀ取得
    Private Const CMstrfts_mode____Ver                      As String = "01.00"                 '搬送ﾓｰﾄﾞ取得
    Private Const CMstrcarrlist____Ver                      As String = "07.00"                 'ｷｬﾘｱ一覧
    Private Const CMstrcarrmanuoutportVer                   As String = "01.00"                 'ｷｬﾘｱ手動出庫要求
    Private Const CMstrrtclwpout___Ver                      As String = "01.00"                 'ﾚﾁｸﾙ払出指示
    Private Const CMstrcarrtransferVer                      As String = "01.00"                 'ｽﾄｯｶｰ/装置搬送指示

    '@vsf共通の定数宣言
    Private Const CMlngVsfRowTitle                          As Integer = 0                      'ﾀｲﾄﾙ行（行）
    Private Const CMlngVsfColTitle                          As Integer = 0                      'ﾀｲﾄﾙ行（列）
    Private Const CMlngVsfHFontSize                         As Integer = 12                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                           As Integer = 24 '360                'ﾍｯﾀﾞｰの高さ
    Private Const CMlngVsfHeight                            As Integer = 38 '570                '1ｽﾛｯﾄの高さ

    '@ｸﾞﾘｯﾄﾞのCols宣言
    Private Const CMlngvsfWPCols                            As Integer = 6                      'WPｸﾞﾘｯﾄﾞCol数
    Private Const CMlngvsfSMIFCols                          As Integer = 7                      'SMIFｸﾞﾘｯﾄﾞCol数

    '@vsfWP(装置→ｽﾄｯｶｰ搬送Tab)の定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfWPNo                              As Integer = 0                      '№
    Private Const CMlngvsfWPRtclID                          As Integer = 1                      'ﾚﾁｸﾙID
    Private Const CMlngvsfWPTrStatus                        As Integer = 2                      '搬送ｽﾃｰﾀｽ
    Private Const CMlngvsfWPTrStatusName                    As Integer = 3                      '搬送ｽﾃｰﾀｽ（和名）
    Private Const CMlngvsfWPCurrentPotitionID               As Integer = 4                      '現在位置ID
    Private Const CMlngvsfWPCurrentPotition                 As Integer = 5                      '現在位置

    '@vsfWP(装置→ｽﾄｯｶｰ搬送Tab)の定数宣言(幅)
    Private Const CMlngvsfWColWPNo                          As Integer = 47   '700              '№
    Private Const CMlngvsfWColWPWPRtclID                    As Integer = 267  '4000             'ﾚﾁｸﾙID
    Private Const CMlngvsfWColWPTrStatus                    As Integer = 100  '1500             '搬送ｽﾃｰﾀｽ
    Private Const CMlngvsfWColWPTrStatusName                As Integer = 133  '2000             '搬送ｽﾃｰﾀｽ（和名）
    Private Const CMlngvsfWColWPCurrentPotitionID           As Integer = 67   '1000             '現在位置ID
    Private Const CMlngvsfWColWPCurrentPotition             As Integer = 200  '3000             '現在位置

    '@vsfWP(装置→ｽﾄｯｶｰ搬送Tab)の定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfWPNo                              As String = "№"                    '№
    Private Const CMstrvsfWPRtclID                          As String = "レチクルID"            'ﾚﾁｸﾙID
    Private Const CMstrvsfWPTrStatus                        As String = "ステータスID"          '搬送ｽﾃｰﾀｽ
    Private Const CMstrvsfWPTrStatusName                    As String = "搬送ステータス"        '搬送ｽﾃｰﾀｽ（和名）
    Private Const CMstrvsfWPCurrentPotitionID               As String = "現在位置ID"            '現在位置ID
    Private Const CMstrvsfWPCurrentPotition                 As String = "現在位置"              '現在位置

    '@vsfSMIF(ｽﾄｯｶｰ→装置搬送Tab)の定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfSMIFNo                            As Integer = 0                      '№
    Private Const CMlngvsfSMIFSmif                          As Integer = 1                      'SMIF
    Private Const CMlngvsfSMIFStatID                        As Integer = 2                      'ﾚﾁｸﾙ状態ID
    Private Const CMlngvsfSMIFStatName                      As Integer = 3                      'ﾚﾁｸﾙ状態ID
    Private Const CMlngvsfSMIFRtclID                        As Integer = 4                      'ﾚﾁｸﾙ状態名（和名）
    Private Const CMlngvsfSMIFCurrentPotitionID             As Integer = 5                      '現在位置ID
    Private Const CMlngvsfSMIFCurrentPotition               As Integer = 6                      '現在位置

    '@vsfSMIF(ｽﾄｯｶｰ→装置搬送Tab)の定数宣言(幅)
    Private Const CMlngvsfWColSMIFNo                        As Integer = 47   '700              '№
    Private Const CMlngvsfWColSMIFSmif                      As Integer = 67   '1000             'SMIF
    Private Const CMlngvsfWColSMIFStatID                    As Integer = 67   '1000             'ﾚﾁｸﾙ状態ID
    Private Const CMlngvsfWColSMIFStatName                  As Integer = 67   '1000             'ﾚﾁｸﾙ状態名（和名）
    Private Const CMlngvsfWColSMIFRtclID                    As Integer = 267  '4000             'ﾚﾁｸﾙID
    Private Const CMlngvsfWColSMIFCurrentPotitionID         As Integer = 67   '1000             '現在位置
    Private Const CMlngvsfWColSMIFCurrentPotition           As Integer = 200  '3000             '現在位置

    '@vsfSMIF(ｽﾄｯｶｰ→装置搬送Tab)の定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfSMIFNo                            As String = "№"                    '№
    Private Const CMstrvsfSMIFSmif                          As String = "SMIF"                  'SMIF
    Private Const CMstrvsfSMIFRtclID                        As String = "レチクルID"            'ﾚﾁｸﾙID
    Private Const CMstrvsfSMIFStatID                        As String = "ｷｬﾘｱ状態ID"            'ｷｬﾘｱ状態ID
    Private Const CMstrvsfSMIFStatName                      As String = "状態"                  'ｷｬﾘｱ状態名（和名）
    Private Const CMstrvsfSMIFCurrentPotitionID             As String = "現在位置ID"            '現在位置ID
    Private Const CMstrvsfSMIFCurrentPotition               As String = "現在位置"              '現在位置

    '@ﾚﾁｸﾙ使用装置ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                          As Integer = 16                        'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                      As Integer = 16                        'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols                          As Integer = 1                         'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbValueCol                          As Integer = 1                         'ｸﾞﾘｯﾄﾞ値取得列
    Private Const CMlngCmbGroupCols                         As Integer = 1                         '列方向ｸﾞﾙｰﾌﾟ数
    Private Const CMlngCMbSelectMode                        As Integer = 0                         '選択ﾓｰﾄﾞ
    Private Const CMlngCmbRowHeight                         As Integer = 43   '640                 'ﾘｽﾄ行の高さ
    Private Const CMlngCmbGridCol0                          As Integer = 0                         '選択列数
    Private Const CMlngCmbValueCol1                         As Integer = 1                         '値取得列=1
    Private Const CMlngCmbGetCol0                           As Integer = 0                         'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=0
    Private Const CMlngCmbGetCol1                           As Integer = 1                         'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=1

    '@ｽﾄｯｶｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbGridColName                       As Integer = 0                         '名称列番(ｽﾄｯｶ名）
    Private Const CMlngCmbValueColID                        As Integer = 1                         '装置ID・ｽﾄｯｶｰの取得列数
    Private Const CMlngCmbValueColName                      As Integer = 0                         '装置ID・ｽﾄｯｶｰの名称取得列数

    '@Tabｲﾝﾃﾞｯｸｽ宣言
    Private Const CMlngWpLotTab                             As Integer = 0                         '装置→ｽﾄｯｶｰ搬送ﾀﾌﾞIndex
    Private Const CMlngSmifTab                              As Integer = 1                         'ｽﾄｯｶｰ→装置搬送ﾀﾌﾞIndex

    '@ﾚﾁｸﾙ状態項目ID
    Private Const CMstrTrStatus1                            As String = "1"                     '1:「搬入予定」ﾚﾁｸﾙ現在位置が、ｽﾄｯｶｰ及び、装置以外。
    Private Const CMstrTrStatus2                            As String = "2"                     '2:「搬入可能」ﾚﾁｸﾙ現在位置がｽﾄｯｶｰで、SMIFと紐付いている場合。
    Private Const CMstrTrStatus3                            As String = "3"                     '3:「搬入済」　ﾚﾁｸﾙ現在位置が装置で、SMIFと紐付いていない場合。
    Private Const CMstrTrStatus4                            As String = "4"                     '4:「搬出可能」ﾚﾁｸﾙ現在位置が装置で、SMIFと紐付いている場合。

    '@ｷｬﾘｱ位置
    Private Const CMstrArrow                                As String = "→"                    '矢印（出庫、入庫、搬送中）

    '@搬送ﾓｰﾄﾞ
    Private Const CMstrTtansferID                           As String = "TRANSFER"              '搬送指示可ID

    '@ﾚｽﾎﾟﾝｽ測定用
    Private Const CMstrFormName                             As String = "frmxxEN01M0"               '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                             As String = "Form_Load"                 'ｲﾍﾞﾝﾄ名称（ﾌｫｰﾑﾛｰﾄﾞ）
    Private Const CMstrcmdNowListWpLotClick                 As String = "cmdNowListWpLot_Click"     'ｲﾍﾞﾝﾄ名称（最新取得(wp)）
    Private Const CMstrcmdReticleMoveClick                  As String = "cmdReticleMove_Click"      'ｲﾍﾞﾝﾄ名称（ﾚﾁｸﾙ払出し）
    Private Const CMstrcmdStockerMoveClick                  As String = "cmdStockerMove_Click"      'ｲﾍﾞﾝﾄ名称（ｽﾄｯｶｰへ搬送）
    Private Const CMstrcmdNowListSmifClick                  As String = "cmdNowListSmif_Click"      'ｲﾍﾞﾝﾄ名称（最新取得(smif)）
    Private Const CMstrcmdShipClick                         As String = "cmdShip_Click"             'ｲﾍﾞﾝﾄ名称（出庫指示）
    Private Const CMstrcmdWpMoveClick                       As String = "cmdWpMove_Click"           'ｲﾍﾞﾝﾄ名称（装置へ搬送）
    Private Const CMstrcmbWplistSmifValidate                As String = "cmbWplistSmif_Validate"    'ｲﾍﾞﾝﾄ名称（搬送先ﾚﾁｸﾙ装置変更）

    '@その他
    Private Const CMlngDefaultCnt                           As Integer = 1                         'ﾃﾞﾌｫﾙﾄｶｳﾝﾄ(ﾚﾁｸﾙﾘｽﾄ取得にて装置情報は必ず1件である）

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '@全Tabで使用している共通変数
    Private mlngSortCol                                     As Integer                          'ｿｰﾄ列格納
    Private mlngSortOrder                                   As Integer                          'ｿｰﾄ方法格納
    Private mtypChgSort1                                    As ChgSort                          'ｿｰﾄ保持用(装置→ｽﾄｯｶｰ)
    Private mtypChgSort2                                    As ChgSort                          'ｿｰﾄ保持用(ｽﾄｯｶｰ→装置)
    Private mlngStockerListCnt                              As Integer                          'ｽﾄｯｶﾘｽﾄｶｳﾝﾄ
    Private mstrStockerName                                 As String                           'ｽﾄｯｶ名退避用
    Private mtypStockerList                                 As List(Of StockerList)             'ｽﾄｯｶﾏｽﾀ格納
    Private mstrTransferStatusStatus                        As String                           '搬送ﾓｰﾄﾞID格納
    Private mblnWplistWpLotChangeFlag                       As Boolean                          'ﾚﾁｸﾙ使用装置ｺﾝﾎﾞ変更ﾌﾗｸﾞwp（True:変更あり、False：変更なし）
    Private mblnWplistSmifChangeFlag                        As Boolean                          'ﾚﾁｸﾙ使用装置ｺﾝﾎﾞ変更ﾌﾗｸﾞsmif（True:変更あり、False：変更なし）
    Private mblnFormLoadFlag                                As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ
    Private mlngWpCnt                                       As Integer                          '装置数格納

    Private buttonProcessing                                As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                        As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                                 As Boolean                          'NSYS WindowCloseフラグ
    Private Const flexRDNone                                As Boolean = False                  'Redraw制御用
    Private Const flexRDDirect                              As Boolean = True                   'Redraw制御用
    Private ReadOnly vbWhite                                As Color = Color.white              'NSYS 白色定義

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
        pubVsfMouseWheelManager_Set(vsfSMIF, cmdSmifUP, cmdSmifDown)
        pubVsfMouseWheelManager_Set(vsfWP, cmdWpUp, cmdWpDown)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                                *イベントハンドラの記述*
    '****************************************************************************************
    '========================================Private=========================================

    '@共通処理==========================================================================================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/23 (Wed) 13:44:41 N.Kasai
    '更新日：2005/02/23 (Wed) 13:44:41
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns                     As Boolean      '結果格納
        Dim lstrClassDivision           As String       '処理区分(ｽﾄｯｶｰﾘｽﾄ）

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN01M0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                Call pubMenuExpand_Disp()
                
                '@ﾌｫｰﾑを閉じる
                Call Form_QueryUnload(False, New FormClosingEventArgs(New CloseReason,  False))
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)
            
            '@画面情報の初期化
            Call prvfrmxxEN01M0_Init()
            
            '@初期化
            mblnFormLoadFlag = False
            
            '@装置一覧取得（ﾚﾁｸﾙ装置）
            lblnAns = pubblnWpList_Sel(CMstrmas_wplist__Ver, _
                                       mlngWpCnt, _
                                       pstrSBID, _
                                       CPstrCD2J)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@処理区分の設定
            lstrClassDivision = CPstrCD2J '2J；ﾚﾁｸﾙｽﾄｯｶｰのみ

            '@ｽﾄｯｶﾏｽﾀ取得
            lblnAns = pubblnMasStockerList_Sel(mtypStockerList, _
                                               CMstrmas_stockerlistVer, _
                                               mlngStockerListCnt, _
                                               lstrClassDivision)
            '@戻り値判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                
                '@ｽﾄｯｶｰ（wp/smif)ｺﾝﾎﾞ使用不可
                cmbStockerWpLot.Enabled = False
                cmbStockerSmif.Enabled = False
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)
            
            '@Form_Loadﾌﾗｸﾞ（正常）
            pblnFormLoad = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_Load"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑｱｸﾃｨﾍﾞｲﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/09/28 (Wed) 13:23:09 S.Deguchi
    '更新日：2005/09/28 (Wed) 13:23:09
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理判別(起動時1回のみ)
            If mblnFormLoadFlag = False Then
                '@ﾌﾗｸﾞを立てる
                mblnFormLoadFlag = True
            
                '@ﾚﾁｸﾙｽﾄｯｶｰｾｯﾄ
                Call prvcmbStocker_Disp()
                
                '@ﾚﾁｸﾙ使用装置情報表示(wp)
                Call prvcmbWplistWpLot_Disp(mlngWpCnt)
                
                '@ﾚﾁｸﾙ使用装置情報表示(smif)
                Call prvcmbWplistSmif_Disp(mlngWpCnt)
            
                '@ｽﾄｯｶｰ→装置tabにﾌｫｰｶｽｾｯﾄ
                tabReticle.SelectedIndex = CMlngSmifTab

                vsfSMIF.Row = 0

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_Activate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑのKeyDown
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2005/02/23 (Wed) 13:49:17 N.Kasai
    '更新日：2005/02/23 (Wed) 13:49:17
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If

            '@ﾌｫｰﾑﾛｯｸ中の場合は処理を受け付けない
            If Me.Enabled = False Then
                e.Handled = True
                Exit Sub
            End If
            
            '@ｽｸﾛｰﾙ制御
            Select Case ActiveControl.Name
                Case vsfWp.Name
                '@ﾚﾁｸﾙ登録ﾀﾌﾞ（上下ｽｸﾛｰﾙのみ）
                    '@ｸﾞﾘｯﾄﾞｷｰ制御（ｸﾞﾘｯﾄﾞ共通仕様）
                    Call pubVsf_KeyDown(e, ActiveControl.Name, vsfWp, cmdWpUP, cmdWpDown)

                Case vsfSMIF.Name
                '@装置内ﾚﾁｸﾙ一覧
                    '@ｸﾞﾘｯﾄﾞｷｰ制御（ｸﾞﾘｯﾄﾞ共通仕様）
                    Call pubVsf_KeyDown(e, ActiveControl.Name, vsfSMIF, cmdSmifUP, cmdSmifDown)
            End Select
            
            Select Case e.KeyCode
                '@Enterｷｰの場合
                Case Keys.Return
                    '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙによる処理分岐
                    Select Case ActiveControl.Name
                        '@ﾚﾁｸﾙ使用装置(wplot)
                        Case cmbWplistWpLot.Name
                            '@ｺﾝﾎﾞ設定可否判定
                            If cmbWplistWpLot.Text <> vbNullString Then
                                '@変更処理へ
                                RemoveHandler cmbWplistWpLot.Validating, AddressOf cmbWplistWpLot_Validate
                                Call cmbWplistWpLot_Validate(cmbWplistWpLot, New CancelEventArgs(True))
                                AddHandler cmbWplistWpLot.Validating, AddressOf cmbWplistWpLot_Validate
                            Else
                                '@次項目へｾｯﾄﾌｫｰｶｽ
                                SendKeys.SendWait(CPstrSendKeysTab)
                            End If
                            e.Handled = True
                            
                        '@ﾚﾁｸﾙ使用装置(smif)
                        Case cmbWplistSmif.Name
                            '@ｺﾝﾎﾞ設定可否判定
                            If cmbWplistSmif.Text <> vbNullString Then
                                '@変更処理へ
                                RemoveHandler cmbWplistSmif.Validating, AddressOf cmbWplistSmif_Validate
                                Call cmbWplistSmif_Validate(cmbWplistSmif, New CancelEventArgs(True))
                                RemoveHandler cmbWplistSmif.Validating, AddressOf cmbWplistSmif_Validate
                            Else
                                '@次項目へｾｯﾄﾌｫｰｶｽ
                                SendKeys.SendWait(CPstrSendKeysTab)
                            End If
                            e.Handled = True

                        Case Else
                            '@次項目へｾｯﾄﾌｫｰｶｽ
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                    End Select
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：ﾌﾟﾛｸﾞﾗﾑ終了
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/23 (Wed) 13:50:09 N.Kasai
    '更新日：2005/02/23 (Wed) 13:50:09
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        
        Dim ltypCommonInfo  As CommonInfo   'PG間ﾃﾞｰﾀ受け渡し用格納構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@終了関数を実行する
            Call publngEnd_Proc(CPstrKeyEN01M0, ltypCommonInfo)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClose_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：tabReticle_Click
    '機　能：ﾀﾌﾞｸﾘｯｸ時処理
    '引　数：PreviousTab：使用しない
    '戻り値：なし
    '作成日：2005/02/21 (Mon) 17:33:25 N.Kasai
    '更新日：2005/02/21 (Mon) 17:33:25
    '備　考：
    Private Sub tabReticle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tabReticle.SelectedIndexChanged

        Try
            
            '@[ﾌﾟﾛｼｰｼﾞｬ]の引数ｴﾗｰ回避制御
            Me.Show
            
            '@選択ﾀﾌﾞ別処理
            Select Case tabReticle.SelectedIndex
                '@装置→ｽﾄｯｶｰﾀﾌﾞ
                Case CMlngWpLotTab
                    '@wpﾌﾚｰﾑ使用可
                    fraWpLot.Enabled = True
                    
                    '@最新取得（wp)　常に最新を取得する。
                    Call cmdNowListWpLot_Click(cmdNowListWpLot, New EventArgs)
                    
                    '@ﾌｫｰｶｽの制御
                    If vsfWp.Enabled = True AndAlso vsfWp.Rows.Count > 1 Then
                        '@一覧にｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(vsfWp)
                    Else
                        '@ﾚﾁｸﾙ使用装置ｺﾝﾎﾞにｾｯﾄﾌｫｰｶｽ
                        If cmbWplistWpLot.Enabled = True Then
                            Call pubSetFocus(cmbWplistWpLot)
                        End If
                    End If
                    
                    '@smifﾌﾚｰﾑ使用不可
                    fraSmif.Enabled = False
                
                '@ｽﾄｯｶｰ→装置ﾀﾌﾞ
                Case CMlngSmifTab
                    
                    '@smifﾌﾚｰﾑ使用可
                    fraSmif.Enabled = True
                    
                    '@最新取得（smif)　常に最新を取得する。
                    Call cmdNowListSmif_Click(cmdNowListSmif, New EventArgs)
                    
                    '@ﾌｫｰｶｽの制御
                    If vsfSMIF.Rows.Count = vsfSMIF.Rows.Fixed Then
                        '@ﾚﾁｸﾙ使用装置ｺﾝﾎﾞへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmbWplistSmif)
                    Else
                        If vsfSMIF.Enabled = True AndAlso vsfSMIF.Rows.Count > 1 Then
                            '@smif一覧へﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(vsfSMIF)
                        End If
                    End If
                    
                    '@wpﾌﾚｰﾑ使用不可
                    fraWpLot.Enabled = False
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "tabReticle_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：終了処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2005/02/23 (Wed) 13:52:14 N.Kasai
    '更新日：2005/02/23 (Wed) 13:52:14
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm         As Boolean      '開放結果格納

        Try
            
            '@構造体の初期化
            If mtypChgSort1.typChgSortList Is Nothing Then
                mtypChgSort1.typChgSortList = New List(Of ChgSortList)
            Else
                mtypChgSort1.typChgSortList.Clear
            End If 
            If mtypChgSort2.typChgSortList Is Nothing Then
                mtypChgSort2.typChgSortList = New List(Of ChgSortList)
            Else
                mtypChgSort2.typChgSortList.Clear
            End If 

            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, EventArgs.Empty)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@ActInitﾌﾗｸﾞの判定
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
            
            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_QueryUnload"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@装置→ｽﾄｯｶｰ搬送Tab==========================================================================================================

    '関数名：cmbWplistWpLot_Change
    '機　能：ﾚﾁｸﾙ使用装置ｺﾝﾎﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/23 (Wed) 14:19:29 N.Kasai
    '更新日：2005/02/23 (Wed) 14:19:29
    '備　考：
    Private Sub cmbWplistWpLot_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWplistWpLot.Change

        Try

            '@ｺﾝﾎﾞ変更ﾌﾗｸﾞON
            mblnWplistWpLotChangeFlag = True
            
            '@ｸﾞﾘｯﾄﾞ初期化
            Call prvvsfWP_init()

            '@ｿｰﾄ順の初期化
            With mtypChgSort1
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                Else
                    .typChgSortList.Clear
                End If 

                '@列幅変更ﾌﾗｸﾞ（未変更）
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWplistWpLot_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWplistWpLot_CloseUp
    '機　能：ﾚﾁｸﾙ使用装置ｺﾝﾎﾞ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/17 (Thu) 15:21:47 N.Kasai
    '更新日：2005/02/17 (Thu) 15:21:47
    '備　考：
    Private Sub cmbWplistWpLot_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWplistWpLot.CloseUp

        Try
            
            '@選択結果判定
            If cmbWplistWpLot.Text <> vbNullString Then
                '@ﾚﾁｸﾙ使用装置変更処理
                RemoveHandler cmbWplistWpLot.Validating, AddressOf cmbWplistWpLot_Validate
                Call cmbWplistWpLot_Validate(cmbWplistWpLot, New CancelEventArgs(True))
                AddHandler cmbWplistWpLot.Validating, AddressOf cmbWplistWpLot_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWplistWpLot_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWplistWpLot_Validate
    '機　能：ﾚﾁｸﾙ使用装置変更処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/02/17 (Thu) 15:19:51 N.Kasai
    '更新日：2005/02/17 (Thu) 15:19:51
    '備　考：
    Private Sub cmbWplistWpLot_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbWplistWpLot.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ﾚﾁｸﾙ使用装置が未選択の場合
            If cmbWplistWpLot.Text = vbNullString Then
                Exit Sub
            Else
                '@ｺﾝﾎﾞ変更ﾌﾗｸﾞ判定
                If ActiveControl.Name = cmbWplistWpLot.Name Then
                    If mblnWplistWpLotChangeFlag = False Then
                        '@変更なしの場合はﾌｫｰｶｽ移動のみ
                        If cmbStockerWpLot.Enabled = True Then
                            Call pubSetFocus(cmbStockerWpLot)
                        Else
                            Call pubSetFocus(cmdClose)
                        End If
                        Exit Sub
                    End If
                End If
            
                '@最新ﾎﾞﾀﾝ使用可
                cmdNowListWpLot.Enabled = True

                '@最新情報取得処理へ
                Call cmdNowListWpLot_Click(cmdNowListWpLot, New EventArgs, False)

                If mblnWplistWpLotChangeFlag = True Then
                    If vsfWp.Enabled = True AndAlso vsfWp.Rows.Count > 1 Then
                        Call pubSetFocus(vsfWP)
                    End If
                End If

                '@ﾚﾁｸﾙ使用装置ｺﾝﾎﾞ変更ﾌﾗｸﾞ（True:変更あり、False：変更なし）
                mblnWplistWpLotChangeFlag = False

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWplistWpLot_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbStockerWpLot_Change
    '機　能：ﾚﾁｸﾙｽﾄｯｶｰ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/25 (Fri) 15:33:15 N.Kasai
    '更新日：2005/02/25 (Fri) 15:33:15
    '備　考：
    Private Sub cmbStockerWpLot_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbStockerWpLot.Change

        Try

            '@ｽﾄｯｶｰへ搬送ﾎﾞﾀﾝ使用可否ﾁｪｯｸ
            Call prvblncmdStockerMove_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbStockerWpLot_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbStockerWpLot_CloseUp
    '機　能：ｽﾄｯｶｰのCloseUp
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/17 (Thu) 15:23:41 N.Kasai
    '更新日：2005/02/17 (Thu) 15:23:41
    '備　考：
    Private Sub cmbStockerWpLot_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbStockerWpLot.CloseUp

        Try
            
            '@ｽﾄｯｶｰ選択の有無
            If cmbStockerWpLot.Text <> vbNullString Then
                If vsfWp.Enabled = True  AndAlso vsfWp.Rows.Count > 1 Then
                    '@ﾌｫｰｶｽ設定(ｸﾞﾘｯﾄﾞ）
                    Call pubSetFocus(vsfWp)
                Else
                    '@ﾌｫｰｶｽ設定(閉じる）
                    Call pubSetFocus(cmdClose)
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbStockerWpLot_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfWP_AfterSort
    '機　能：一覧AfterSort処理
    '引　数：Col：ｿｰﾄ列
    '　　　：Order：ｿｰﾄ方法
    '戻り値：なし
    '作成日：2005/02/17 (Thu) 16:20:39 N.Kasai
    '更新日：2005/02/17 (Thu) 16:20:39
    '備　考：
    Private Sub vsfWP_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfWP.AfterSort

        Try

            '@ｿｰﾄ順を格納
            Dim typChgSortListTmp As ChgSortList = New ChgSortList

            With mtypChgSort1
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                '@ｿｰﾄ列番号を格納
                typChgSortListTmp.lngCol = e.Col
                '@並び替え方法を格納（昇順/降順）
                typChgSortListTmp.lngOrder = e.Order
                .typChgSortList.Add(typChgSortListTmp)

            End With

            '@ｿｰﾄされた列を格納
            mlngSortCol = e.Col
            '@ｿｰﾄ方法を格納
            mlngSortOrder = e.Order
            '@ｿｰﾄ後のｶﾚﾝﾄ行設定（ｸﾞﾘｯﾄﾞ、保持列）
            Call pubVsfAfterSort(vsfWp, CMlngVsfRowTitle)

            'BeforeSortで除外していたRowColChangeイベントを復帰
            AddHandler vsfWP.BeforeRowColChange, AddressOf vsfWP_BeforeRowColChange
            AddHandler vsfWP.EnterCell, AddressOf vsfWP_EnterCell

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfWP_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfWP_BeforeRowColChange
    '機　能：変更前処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ
    '戻り値：なし
    '作成日：2005/02/17 (Thu) 16:53:32 N.Kasai
    '更新日：2005/02/17 (Thu) 16:53:32
    '備　考：
    Private Sub vsfWP_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfWP.BeforeRowColChange

        
        Dim OldRow              As Integer      'NSYS 
        Dim NewRow              As Integer

        Try

            OldRow = e.OldRange.r1
            NewRow = e.NewRange.r1

            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If OldRow <> NewRow And NewRow > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納（ﾚﾁｸﾙID）
                mtypChgSort1.strKey = vsfWp.GetData(NewRow, CMlngvsfWPNo)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfWP_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfWP_BeforeSort
    '機　能：ﾚﾁｸﾙ登録TabﾚﾁｸﾙID一覧ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2005/02/17 (Thu) 16:54:49 N.Kasai
    '更新日：2005/02/17 (Thu) 16:54:49
    '備　考：
    Private Sub vsfWP_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfWP.BeforeSort

        Try

            'NSYS 不要なHandler処理を抑止
            RemoveHandler vsfWP.BeforeRowColChange, AddressOf vsfWP_BeforeRowColChange
            RemoveHandler vsfWP.EnterCell, AddressOf vsfWP_EnterCell

            'NSYS データがない場合は処理を抜ける
            If vsfWp.Row <= 0 Then
                Exit Sub
            End If

            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列）
            Call pubVsfBeforeSort(vsfWp, CMlngVsfRowTitle)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfWP_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfWP_EnterCell
    '機　能：ｸﾞﾘｯﾄﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/23 (Wed) 13:30:40 N.Kasai
    '更新日：2005/02/23 (Wed) 13:30:40
    '備　考：
    Private Sub vsfWP_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfWP.EnterCell

        Try

            '@ﾚﾁｸﾙ払出しﾎﾞﾀﾝ使用可否ﾁｪｯｸ
            Call prvblnCmdReticleMove_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfWP_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNowListWpLot_Click
    '機　能：最新取得ﾎﾞﾀﾝ押下処理（装置→ｽﾄｯｶｰ）
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/22 (Tue) 13:31:47 N.Kasai
    '更新日：2005/04/14 (Thu) 10:32:21 N.Kasai
    '備　考：
    '　　　：2005/04/14 (Thu) 10:32:21 N.Kasai  不具合№609　搬送ﾓｰﾄﾞ表示制御追加
    Private Sub cmdNowListWpLot_Click(ByVal sender As Object, ByVal e As EventArgs, Optional ByVal lblnFocusFlg As Boolean = True) Handles cmdNowListWpLot.Click

        Dim lblnAns                     As Boolean           '結果格納
        Dim ltypRtclList2               As RtclList2         'ﾚﾁｸﾙ情報格納変数
        Dim llngWpCnt                   As Integer           '装置件数ｶｳﾝﾄ
        Dim llngCnt                     As Integer           '汎用ｶｳﾝﾀ
        Dim ltypFtsMode                 As FtsMode           '搬送機器状態構造体
        Dim llngMachineStatusListCnt    As Integer           '機器状態ﾘｽﾄのｶｳﾝﾄ
        Dim ltypRtclList                As List(Of RtclList) 'ﾚﾁｸﾙ情報格納変数
        Dim llngRtclListCnt             As Integer           'ﾚﾁｸﾙ情報格納数

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ﾚﾁｸﾙ使用装置空欄の場合
            If cmbWplistWpLot.Text = vbNullString Then
                '@ﾚﾁｸﾙ使用装置にｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(cmbWplistWpLot)
                '@処理を抜ける
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrcmdNowListWpLotClick)

            '@再描画を行わない
            vsfWP.Redraw = flexRDNone

            '@装置搬送一覧の初期化
            Call prvvsfWP_init()
            
            '@配列の初期化
            If ltypRtclList2.typWpList Is Nothing Then
                ltypRtclList2.typWpList = New List(Of WP)
            Else
                ltypRtclList2.typWpList.Clear
            End If
           
            '@ﾚﾁｸﾙ情報格納変数に値をｾｯﾄ
            With ltypRtclList2
                '@ｼｽﾃﾑﾌﾞﾛｯｸｾｯﾄ
                .strSbID = pstrSBID
                '@Msgﾊﾞｰｼﾞｮﾝｾｯﾄ
                .strMsgVer = CMstrrtcllist____Ver
                '@処理区分ｾｯﾄ（WP指定）
                .strClassDivison = CPstrCD26
                '@装置ID
                Dim typWpListTmp As WP = New WP
                typWpListTmp.strWpID = cmbWplistWpLot.Value
                ltypRtclList2.typWpList.Add(typWpListTmp)
                .lngWpListCnt = CMlngDefaultCnt
            End With
            
            '@ﾚﾁｸﾙ情報取得
            lblnAns = pubblnRtclList____Sel(ltypRtclList2, ltypRtclList, llngRtclListCnt)
            '@結果判定
            If lblnAns = True Then
                '@一覧表示
                Call prvvsfWP_Disp(ltypRtclList, llngRtclListCnt, False)
            
                '@最新取得ﾎﾞﾀﾝ活性化
                cmdNowListWpLot.Enabled = True

                If vsfWp.Enabled = True AndAlso vsfWp.Rows.Count > 1 Then
                    '@一覧へｾｯﾄﾌｫｰｶｽ
                    If lblnFocusFlg = True Then
                        Call pubSetFocus(vsfWp)
                    End If
                Else
                    '@取得件数が0件の場合
                    If llngRtclListCnt = 0 Then
                        If cmdNowListWpLot.Enabled = True Then
                            '@最新取得ﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                            Call pubSetFocus(cmdNowListWpLot)
                        End If
                    End If
                End If
                
                '@装置情報最新表示
                If cmbWplistWpLot.Text <> vbNullString Then
                    '@装置一覧取得（ﾚﾁｸﾙ装置）
                    lblnAns = pubblnWpList_Sel(CMstrmas_wplist__Ver, llngWpCnt, pstrSBID, CPstrCD2J)
                    '@結果判定
                    If lblnAns = False Then
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrcmdNowListWpLotClick)

                        '@ﾃﾞｰﾀを画面に直接描画
                        vsfWP.Redraw = flexRDDirect

                        Exit Sub
                    End If
                    '@ｺﾝﾎﾞWP_IDよりﾍｯﾀﾞ情報を取得
                    For llngCnt = 0 To cmbWplistWpLot.ListCount -1
                        With ptypWPList(llngCnt)
                            '@WP_ID判定
                            If cmbWplistWpLot.Value = .strWpID Then
                                '@運用ﾓｰﾄﾞ表示
                                lblModeWpLot.Text = .strMesModeId
                                '@SMIF表示
                                lblSmif.Text = .strCarrierId
                                '@ﾚﾁｸﾙﾎﾟｰﾄ状態表示
                                lblStatusWpLot.Text = .strPortStatus
                                Exit For
                            End If
                        End With
                    Next
                
                    '@搬送ﾓｰﾄﾞ取得
                    lblnAns = pubblnFtsMode_Sel(CMstrfts_mode____Ver, llngMachineStatusListCnt, ltypFtsMode)
            
                    '@戻り値判定
                    If lblnAns = True Then
                        With ltypFtsMode
                            '@搬送ﾓｰﾄﾞの表示
                            lblFtsModeWpLot.Text = .strTransferStatusName                'wp

                            '@smif画面の搬送ﾓｰﾄﾞ表示済みの場合は表示洗い替え
                            If lblFtsModeSmif.Text <> vbNullString Then
                                lblFtsModeSmif.Text = .strTransferStatusName             'smif
                            End If

                            '@搬送ｽﾃｰﾀｽ退避
                            mstrTransferStatusStatus = .strTransferStatus
                        End With
                    Else
                        '@搬送ﾓｰﾄﾞの表示
                        lblFtsModeWpLot.Text = vbNullString                              'wp
                        lblFtsModeSmif.Text = vbNullString                               'smif
                        
                        '@搬送ｽﾃｰﾀｽｸﾘｱ
                        mstrTransferStatusStatus = vbNullString
                        
                        '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrcmdNowListWpLotClick)
                        
                        '@ﾃﾞｰﾀを画面に直接描画
                        vsfWP.Redraw = flexRDDirect

                        Exit Sub
                    End If
                End If

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrcmdNowListWpLotClick)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrcmdNowListWpLotClick)
                
                Exit Sub
            End If
            
            '@ｽﾄｯｶｰへ搬送ﾎﾞﾀﾝ使用可否ﾁｪｯｸ
            Call prvblncmdStockerMove_Chk()

            '@ﾃﾞｰﾀを画面に直接描画
            vsfWP.Redraw = flexRDDirect
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNowListWpLot_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdReticleMove_Click
    '機　能：ﾚﾁｸﾙ払出し
    '引　数：ltypRtclWpout：
    '戻り値：
    '作成日：2005/02/22 (Tue) 09:04:43 N.Kasai
    '更新日：2005/10/03 (Mon) 11:17:11 N.Kasai
    '備　考：
    '　　　：2005/10/03 (Mon) 11:17:11 N.Kasai      確定後のｺﾏﾝﾄﾞﾎﾞﾀﾝ制御追加
    Private Sub cmdReticleMove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdReticleMove.Click

        Dim lblnAns                 As Boolean          '戻り値
        Dim ltypRtclWpout           As RtclWpout        'ﾚﾁｸﾙ払出応答格納構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                '@ﾌｫｰｶｽの設定
                If vsfWp.Enabled = True AndAlso vsfWp.Rows.Count > 1 Then
                    Call pubSetFocus(vsfWp)
                End If
                Exit Sub
            End If
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrcmdReticleMoveClick)
            
            '@ﾚﾁｸﾙ払出指示応答格納
            With ltypRtclWpout
                '@ｼｽﾃﾑﾌﾞﾛｯｯｸ
                .strSbID = pstrSBID
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CMstrrtclwpout___Ver
                '@処理区分（全部）
                .strClassDivision = CPstrCD02
                '@装置ID
                .strWpID = cmbWplistWpLot.Value
                '@ﾚﾁｸﾙID
                .strReticleID = vsfWp.GetData(vsfWp.Row, CMlngvsfWPRtclID)
                '@作業者ID
                .strEmpID = pstrUserID
            End With
            
            '@ﾚﾁｸﾙ払出要求
            lblnAns = pubblnrtclwpout____Upd(ltypRtclWpout)
            
            '@戻り値判定
            If lblnAns = True Then
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrcmdReticleMoveClick)
                
                '@表示ﾒｯｾｰｼﾞ変換（"<TRM4GI>$$レチクル[%1]払出しを受け付けました。"）
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004G, ltypRtclWpout.strReticleID)

                'ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@最新情報取得
                Call cmdNowListWpLot_Click(cmdNowListWpLot, New EventArgs)
                
        '@↓2005/10/03 (Mon) 11:11:18 N.Kasai **************************************************
                '@ﾚﾁｸﾙ払出しﾎﾞﾀﾝ使用不可
                cmdReticleMove.Enabled = False
                
                '@ｸﾞﾘｯﾄﾞのﾌｫｰｶｽ設定有無ﾁｪｯｸ
                If vsfWp.Row >= vsfWp.Rows.Fixed Then
                    '@ﾚﾁｸﾙ払出しﾎﾞﾀﾝ使用可否ﾁｪｯｸ
                    Call prvblnCmdReticleMove_Chk()
                End If
        '@↑2005/10/03 (Mon) 11:11:18 N.Kasai **************************************************
             
                Exit Sub
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrcmdReticleMoveClick)
                
                '@ﾌｫｰｶｽの設定
                If vsfWp.Enabled = True AndAlso vsfWp.Rows.Count > 1 Then
                    Call pubSetFocus(vsfWp)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdReticleMove_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdStockerMove_Click
    '機　能：ｽﾄｯｶｰへ搬送ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/23 (Wed) 09:38:50 N.Kasai
    '更新日：2005/02/23 (Wed) 09:38:50
    '備　考：
    Private Sub cmdStockerMove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdStockerMove.Click

        Dim lblnAns                 As Boolean          '戻り値
        Dim ltypCarrTransfer        As CarrTransfer     'ｽﾄｯｶｰ/装置搬送指示応答格納構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                '@ﾌｫｰｶｽの設定
                If vsfWp.Enabled = True AndAlso vsfWp.Rows.Count > 1 Then
                    Call pubSetFocus(vsfWp)
                End If
                Exit Sub
            End If
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrcmdStockerMoveClick)
            
            '@ｽﾄｯｶｰ/装置搬送指示応答格納
            With ltypCarrTransfer
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CMstrcarrtransferVer
                '@ｷｬﾘｱID(SMIF)
                .strCarrierId = lblSmif.Text
                '@搬送元
                .strCurrentPositionID = cmbWplistWpLot.Value
                '@搬送先
                .strDestPositionID = cmbStockerWpLot.Value
                '@作業者ID
                .strEmpID = pstrUserID
                '@処理区分
                .strClassDivision = CPstrCD02
            End With
            
            '@ﾚﾁｸﾙ払出要求
            lblnAns = pubblncarrtransfer_Upd(ltypCarrTransfer)
            
            '@戻り値判定
            If lblnAns = True Then
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrcmdStockerMoveClick)
                
                '@表示ﾒｯｾｰｼﾞ変換("<TRM4HI>$$[%1]から[%2]への搬送指示を受け付けました。")
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004H, cmbWplistWpLot.Text, cmbStockerWpLot.Text)
                
                '@ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@最新情報取得
                Call cmdNowListWpLot_Click(cmdNowListWpLot, New EventArgs)
                
                Exit Sub
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrcmdStockerMoveClick)
                
                '@ﾌｫｰｶｽの設定
                If vsfWp.Enabled = True AndAlso vsfWp.Rows.Count > 1 Then
                    Call pubSetFocus(vsfWp)
                End If
            End If
            
            '@ｽﾄｯｶｰへ搬送ﾎﾞﾀﾝ使用可否ﾁｪｯｸ
            Call prvblncmdStockerMove_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdStockerMove_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWpUP_Click
    '機　能：前ﾍﾟｰｼﾞﾎﾞﾀﾝ押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/17 (Thu) 17:12:30 N.Kasai
    '更新日：2005/02/17 (Thu) 17:12:30
    '備　考：
    Private Sub cmdWpUP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWpUP.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdUp(vsfWp, cmdWpUP, cmdWpDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWpUP_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWpDown_Click
    '機　能：次ﾍﾟｰｼﾞﾎﾞﾀﾝ押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/17 (Thu) 17:12:42 N.Kasai
    '更新日：2005/02/17 (Thu) 17:12:42
    '備　考：
    Private Sub cmdWpDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWpDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdDown(vsfWp, cmdWpUP, cmdWpDown, False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWpDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@ｽﾄｯｶｰ→装置Tab==========================================================================================================

    '関数名：cmbWplistSmif_Change
    '機　能：ﾁｸﾙ使用装置ｺﾝﾎﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/04/14 (Thu) 10:34:26 N.Kasai
    '更新日：2005/04/14 (Thu) 10:34:26
    '備　考：
    Private Sub cmbWplistSmif_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWplistSmif.Change

        Try
            
            '@ﾚﾁｸﾙ使用装置ｺﾝﾎﾞ変更ﾌﾗｸﾞsmif（True:変更あり、False：変更なし）
            mblnWplistSmifChangeFlag = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWplistSmif_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：cmbWplistSmif_CloseUp
    '機　能：ﾚﾁｸﾙ使用装置ｺﾝﾎﾞ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/17 (Thu) 17:20:42 N.Kasai
    '更新日：2005/02/17 (Thu) 17:20:42
    '備　考：
    Private Sub cmbWplistSmif_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWplistSmif.CloseUp

        Try
           
            '@ﾚﾁｸﾙ使用装置設定判定
            If cmbWplistSmif.Text <> vbNullString Then
                '@ﾚﾁｸﾙ使用装置ｺﾝﾎﾞ変更処理
                RemoveHandler cmbWplistSmif.Validating, AddressOf cmbWplistSmif_Validate
                Call cmbWplistSmif_Validate(cmbWplistSmif, New CancelEventArgs(True))
                AddHandler cmbWplistSmif.Validating, AddressOf cmbWplistSmif_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWplistSmif_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWplistSmif_Validate
    '機　能：ﾚﾁｸﾙ使用装置ｺﾝﾎﾞ変更処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/02/17 (Thu) 17:21:28 N.Kasai
    '更新日：2005/04/14 (Thu) 10:35:12 N.Kasai
    '備　考：
    '　　　：2005/04/14 (Thu) 10:35:12 N.Kasai  不具合№609　搬送ﾓｰﾄﾞ表示条件追加
    Private Sub cmbWplistSmif_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbWplistSmif.Validating
        
        Dim llngCnt As Integer '汎用ｶｳﾝﾀ
        Dim ltypFtsMode                 As FtsMode      '搬送機器状態構造体
        Dim llngMachineStatusListCnt    As Integer      '機器状態ﾘｽﾄのｶｳﾝﾄ
        Dim lblnAns                     As Boolean      '汎用戻り値結果取得(True:正常,False:異常)

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
           '@ｺﾝﾎﾞWP_IDよりﾍｯﾀﾞ情報を取得
            For llngCnt = 0 To cmbWplistSmif.ListCount -1
                With ptypWPList(llngCnt)
                    '@WP_ID判定
                    If cmbWplistSmif.Value = .strWpID Then
                        '@運用ﾓｰﾄﾞ表示
                        lblModeSmif.Text = .strMesModeId
                        '@ﾚﾁｸﾙﾎﾟｰﾄ状態表示
                        lblStatusSmif.Text = .strPortStatus
                        Exit For
                    End If
                End With
            Next
            
            '@ﾌｫｰｶｽ設定
            If ActiveControl.Name = cmbWplistSmif.Name Then
                If vsfSMIF.Enabled = True AndAlso vsfSMIF.Rows.Count > 1 Then
                    Call pubSetFocus(vsfSMIF)
                End If
            End If
            
            '@ｺﾝﾎﾞ変更ﾌﾗｸﾞ判定
            If mblnWplistSmifChangeFlag = False Then
                Exit Sub
            End If
            
            '@ﾚﾁｸﾙ使用装置ｺﾝﾎﾞ変更ﾌﾗｸﾞsmif（True:変更あり、False：変更なし）
            mblnWplistSmifChangeFlag = False
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrcmbWplistSmifValidate)
            
            '@搬送ﾓｰﾄﾞ取得
            lblnAns = pubblnFtsMode_Sel(CMstrfts_mode____Ver, llngMachineStatusListCnt, ltypFtsMode)

            '@戻り値判定
            If lblnAns = True Then
                With ltypFtsMode
                '@搬送ﾓｰﾄﾞの表示
                    '@lot画面の搬送ﾓｰﾄﾞが表示済みの場合表示を洗い替え
                    If lblFtsModeWpLot.Text <> vbNullString Then
                        lblFtsModeWpLot.Text = .strTransferStatusName            'wp
                    End If

                    lblFtsModeSmif.Text = .strTransferStatusName                 'smif
                    '@搬送ｽﾃｰﾀｽ退避
                    mstrTransferStatusStatus = .strTransferStatus
                End With
            Else
                '@搬送ﾓｰﾄﾞの表示
                lblFtsModeWpLot.Text = vbNullString                              'wp
                lblFtsModeSmif.Text = vbNullString                               'smif
                
                '@搬送ｽﾃｰﾀｽｸﾘｱ
                mstrTransferStatusStatus = vbNullString
                
                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrcmbWplistSmifValidate)
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrcmbWplistSmifValidate)
            
            '@出庫指示/装置へ搬送ﾎﾞﾀﾝ使用可否ﾁｪｯｸ
            Call prvblncmdShipWpMove_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWplistSmif_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbStockerSmif_Change
    '機　能：ﾚﾁｸﾙｽﾄｯｶｰｺﾝﾎﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/25 (Fri) 16:15:12 N.Kasai
    '更新日：2005/02/25 (Fri) 16:15:12
    '備　考：
    Private Sub cmbStockerSmif_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbStockerSmif.Change

        Try

            '@出庫指示/装置へ搬送ﾎﾞﾀﾝ使用可否ﾁｪｯｸ
            Call prvblncmdShipWpMove_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbStockerSmif_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbStockerSmif_CloseUp
    '機　能：ｽﾄｯｶｰ選択処理(smif)
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/23 (Wed) 13:23:46 N.Kasai
    '更新日：2005/02/23 (Wed) 13:23:46
    '備　考：
    Private Sub cmbStockerSmif_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbStockerSmif.CloseUp

        Try
            
            '@ｽﾄｯｶｰ選択の有無
            If cmbStockerSmif.Text <> vbNullString Then
                If vsfSMIF.Rows.Count > 1 Then
                    '@ﾌｫｰｶｽ設定（ｸﾞﾘｯﾄﾞ）
                    Call pubSetFocus(vsfSMIF)
                Else
                    '@ﾌｫｰｶｽ設定（閉じる）
                    Call pubSetFocus(cmdClose)
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbStockerSmif_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSMIF_AfterSort
    '機　能：一覧AfterSort処理
    '引　数：Col：ｿｰﾄ列
    '　　　：Order：ｿｰﾄ方法
    '戻り値：なし
    '作成日：2005/02/17 (Thu) 16:20:39 N.Kasai
    '更新日：2005/02/17 (Thu) 16:20:39
    '備　考：
    Private Sub vsfSMIF_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfSMIF.AfterSort

        Try
            '@ｿｰﾄ順を格納
            Dim typChgSortListTmp As ChgSortList = New ChgSortList

            With mtypChgSort2
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                '@ｿｰﾄ列番号を格納
                typChgSortListTmp.lngCol = e.Col
                '@並び替え方法を格納（昇順/降順）
                typChgSortListTmp.lngOrder = e.Order
                .typChgSortList.Add(typChgSortListTmp)
            End With

            '@ｿｰﾄされた列を格納
            mlngSortCol = e.Col
            '@ｿｰﾄ方法を格納
            mlngSortOrder = e.Order

            '@ｿｰﾄ後のｶﾚﾝﾄ行設定（ｸﾞﾘｯﾄﾞ、保持列）
            Call pubVsfAfterSort(vsfSMIF, CMlngVsfRowTitle)

            'BeforeSortで除外していたRowColChangeイベントを復帰
            AddHandler vsfSMIF.BeforeRowColChange, AddressOf vsfSMIF_BeforeRowColChange
            AddHandler vsfSMIF.EnterCell, AddressOf vsfSMIF_EnterCell

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSMIF_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSMIF_BeforeRowColChange
    '機　能：変更前処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ
    '戻り値：なし
    '作成日：2005/02/17 (Thu) 16:53:32 N.Kasai
    '更新日：2005/02/17 (Thu) 16:53:32
    '備　考：
    Private Sub vsfSMIF_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfSMIF.BeforeRowColChange

        Dim OldRow              As Integer      'NSYS 
        Dim NewRow              As Integer

        Try

            OldRow = e.OldRange.r1
            NewRow = e.NewRange.r1

            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If OldRow <> NewRow And NewRow > 0 Then
                '@ｶﾚﾝﾄ行検索用のキーを格納（№）
                mtypChgSort2.strKey = vsfSMIF.GetData(NewRow, CMlngvsfSMIFNo)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSMIF_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSMIF_BeforeSort
    '機　能：ﾚﾁｸﾙ登録TabﾚﾁｸﾙID一覧ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2005/02/17 (Thu) 16:54:49 N.Kasai
    '更新日：2005/02/17 (Thu) 16:54:49
    '備　考：
    Private Sub vsfSMIF_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfSMIF.BeforeSort

        Try

            'NSYS 不要なHandler処理を抑止
            RemoveHandler vsfSMIF.BeforeRowColChange, AddressOf vsfSMIF_BeforeRowColChange
            RemoveHandler vsfSMIF.EnterCell, AddressOf vsfSMIF_EnterCell

            'NSYS データがない場合は処理を抜ける
            If vsfSMIF.Row <= 0 Then
                Exit Sub
            End If

            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列）
            Call pubVsfBeforeSort(vsfSMIF, CMlngVsfRowTitle)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSMIF_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSMIF_EnterCell
    '機　能：SMIF一覧ｸﾞﾘｯﾄﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/23 (Wed) 13:35:04 N.Kasai
    '更新日：2005/02/23 (Wed) 13:35:04
    '備　考：
    Private Sub vsfSMIF_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSMIF.EnterCell

        Try

            '@出庫指示/装置へ搬送ﾎﾞﾀﾝ使用可否ﾁｪｯｸ
            Call prvblncmdShipWpMove_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSMIF_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSmifUP_Click
    '機　能：前ﾍﾟｰｼﾞ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/17 (Thu) 17:26:17 N.Kasai
    '更新日：2005/02/17 (Thu) 17:26:17
    '備　考：
    Private Sub cmdSmifUP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSmifUP.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdUp(vsfSMIF, cmdSmifUP, cmdSmifDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSmifUP_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSmifDown_Click
    '機　能：前ﾍﾟｰｼﾞ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/17 (Thu) 17:26:12 N.Kasai
    '更新日：2005/02/17 (Thu) 17:26:12
    '備　考：
    Private Sub cmdSmifDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSmifDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdDown(vsfSMIF, cmdSmifUP, cmdSmifDown, False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSmifDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNowListSmif_Click
    '機　能：最新取得ﾎﾞﾀﾝ押下処理（ｽﾄｯｶｰ→装置）
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/23 (Wed) 13:20:28 N.Kasai
    '更新日：2006/02/27 (Mon) 10:43:19 N.Kojima
    '備　考：
    '　　　：2005/04/14 (Thu) 10:30:13 N.Kasai      不具合№609　搬送ﾓｰﾄﾞ表示制御追加
    '　　　：2005/10/06 (Thu) 14:37:43 S.Deguchi    不具合№2995の対応でｷｬﾘｱ一覧取得ﾒｯｾｰｼﾞの変更
    '　　　：2006/02/27 (Mon) 10:43:19 N.Kojima     ｷｬﾘｱ一覧取得 要求に「ｶﾃｺﾞﾘID」追加
    Private Sub cmdNowListSmif_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowListSmif.Click

        Dim ltypCarrierList             As CarrList         'ｷｬﾘｱﾘｽﾄ取得結果格納
        Dim lblnAns                     As Boolean          '汎用戻り値結果取得(True:正常,False:異常)
        Dim llngWpCnt                   As Integer          '装置件数ｶｳﾝﾄ
        Dim llngCnt                     As Integer          '汎用ｶｳﾝﾀ
        Dim ltypFtsMode                 As FtsMode          '搬送機器状態構造体
        Dim llngMachineStatusListCnt    As Integer          '機器状態ﾘｽﾄのｶｳﾝﾄ
        Dim ltypCarrierListReq          As CarrierListReq   '要求構造体


        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrcmdNowListSmifClick)
            
            '@SMIF一覧の初期化
            '@再描画を行わない
            vsfSMIF.Redraw = flexRDNone

            Call prvvsfSMIF_Init()

        '@↓2005/10/06 (Thu) 14:39:22 S.Deguchi **************************************************
        '    '@ｷｬﾘｱﾘｽﾄ（要求）格納
        '    lstrCarrType = CPstrCarrTypeSMIF
        '    lstrSBID = pstrSBID

        '    '@ｷｬﾘｱ一覧
        '    lblnAns = pubblnCarrList_Sel(CMstrcarrlist____Ver, _
        '                                        CPstrCD02, _
        '                                        ltypCarrierList, _
        '                                        lstrCarrType, _
        '                                        lstrSBID)
        '@↓2006/02/27 (Mon) 10:40:56 N.Kojima **************************************************

            '@ｷｬﾘｱ一覧取得 要求構造体へ情報を格納
            With ltypCarrierListReq
                .strMsgVer = CMstrcarrlist____Ver                       'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strSbID = pstrSBID                                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strClassDivision = CPstrCD02                           '処理区分：02 全て
                .strRestrictedSBID = vbNullString                       'ｷｬﾘｱ使用可能ｼｽﾃﾑﾌﾞﾛｯｸID
                .strCarrierTypeID = CPstrCarrTypeSMIF                   'ｷｬﾘｱﾀｲﾌﾟ：SMIF
                .strCarrierId = vbNullString                            'ｷｬﾘｱID(ｷｬﾘｱID指定時設定)
                .strCleanCondition = vbNullString                       '洗浄条件
                .strCategoryID = vbNullString                           'ｶﾃｺﾞﾘID
            End With
            
        '@↑2006/02/27 (Mon) 10:40:56 N.Kojima **************************************************
            
            '@ｷｬﾘｱ一覧取得
            lblnAns = pubblnCarrList_Sel(ltypCarrierListReq, ltypCarrierList)
        '@↑2005/10/06 (Thu) 14:39:22 S.Deguchi **************************************************

            '@取得結果確認
            If lblnAns = True Then
                '@ﾘｽﾄｶｳﾝﾄを判定
                If ltypCarrierList.lngCarrierListCnt > 0 Then
                    '@件数ありの場合画面表示
                    Call prvvsfSMIF_Disp(ltypCarrierList)
                End If
                
                '@装置情報最新表示
                If cmbWplistSmif.Text <> vbNullString Then
                    '@装置一覧取得（ﾚﾁｸﾙ装置）
                    lblnAns = pubblnWpList_Sel(CMstrmas_wplist__Ver, llngWpCnt, pstrSBID, CPstrCD2J)
                    '@結果判定
                    If lblnAns = False Then
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrcmdNowListSmifClick)

                        '@ﾃﾞｰﾀを画面に直接描画
                        vsfSMIF.Redraw = flexRDDirect

                        Exit Sub
                    End If
                    '@ｺﾝﾎﾞWP_IDよりﾍｯﾀﾞ情報を取得
                    For llngCnt = 0 To cmbWplistSmif.ListCount -1
                        With ptypWPList(llngCnt)
                            '@WP_ID判定
                            If cmbWplistSmif.Value = .strWpID Then
                                '@運用ﾓｰﾄﾞ表示
                                lblModeSmif.Text = .strMesModeId
                                '@ﾚﾁｸﾙﾎﾟｰﾄ状態表示
                                lblStatusSmif.Text = .strPortStatus
                                Exit For
                            End If
                        End With
                    Next
                
                    '@搬送ﾓｰﾄﾞ取得
                    lblnAns = pubblnFtsMode_Sel(CMstrfts_mode____Ver, llngMachineStatusListCnt, ltypFtsMode)
            
                    '@戻り値判定
                    If lblnAns = True Then
                        With ltypFtsMode
                        '@搬送ﾓｰﾄﾞの表示
                            '@lot画面の搬送ﾓｰﾄﾞが表示済みの場合表示洗い替え
                            If lblFtsModeWpLot.Text <> vbNullString Then
                                lblFtsModeWpLot.Text = .strTransferStatusName            'wp
                            End If
            
                            lblFtsModeSmif.Text = .strTransferStatusName                 'smif
                            '@搬送ｽﾃｰﾀｽ退避
                            mstrTransferStatusStatus = .strTransferStatus
                        End With
                    Else
                        '@搬送ﾓｰﾄﾞの表示
                        lblFtsModeWpLot.Text = vbNullString                              'wp
                        lblFtsModeSmif.Text = vbNullString                               'smif
                        
                        '@搬送ｽﾃｰﾀｽｸﾘｱ
                        mstrTransferStatusStatus = vbNullString
                        
                        '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrcmdNowListSmifClick)
                        
                        '@ﾃﾞｰﾀを画面に直接描画
                        vsfSMIF.Redraw = flexRDDirect

                        Exit Sub
                    End If
                End If

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrcmdNowListSmifClick)
                
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrcmdNowListSmifClick)
            End If

            '@ﾃﾞｰﾀを画面に直接描画
            vsfSMIF.Redraw = flexRDDirect

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNowListSmif_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdShip_Click
    '機　能：出庫指示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/28 (Mon) 08:59:47 N.Kasai
    '更新日：2005/10/03 (Mon) 11:14:28 N.Kasai
    '備　考：
    '　　　：2005/10/03 (Mon) 11:14:28 N.Kasai      確定後のｺﾏﾝﾄﾞﾎﾞﾀﾝ使用可否追加
    Private Sub cmdShip_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdShip.Click
        
        Dim lblnAns                 As Boolean          '戻り値
        Dim lstrCarrierID           As String           'ｷｬﾘｱID
        Dim lstrCarrierPosition     As String           'ｷｬﾘｱ位置
        Dim llngCnt                 As Integer          'ｶｳﾝﾀ

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｽﾄｯｶｰのﾁｪｯｸ
            '@ｽﾄｯｶｰ未設定の場合は中止
            If cmbStockerSmif.Value = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004L)

                '@失敗ﾒｯｾｰｼﾞ表示("<TRM4LW>$$ストッカーが設定されていません。設定を見直してください。")
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@ﾌｫｰｶｽの設定
                If cmbStockerSmif.Enabled = True Then
                    Call pubSetFocus(cmbStockerSmif)
                End If
                
                Exit Sub
            End If
            
            '@ﾃﾞｰﾀﾁｪｯｸ用
            With vsfSMIF
                lstrCarrierID = .GetData(.Row, CMlngvsfSMIFSmif)                          'SMIF
                lstrCarrierPosition = .GetData(.Row, CMlngvsfSMIFCurrentPotition)         '現在位置
            End With

            '@空の項目があれば中止
            '@ｷｬﾘｱIDﾁｪｯｸ
            If lstrCarrierID = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004I)

                '@失敗ﾒｯｾｰｼﾞ表示("ＳＭＩＦが設定されていません。設定を見直してください。")
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@ﾌｫｰｶｽの設定
                If vsfSMIF.Enabled = True AndAlso vsfSMIF.Rows.Count > 1 Then
                    Call pubSetFocus(vsfSMIF)
                End If
                
                Exit Sub
            End If
            
        '@↓2017/02/09 (Thu) S.Otaki **************************************************
            '@ｷｬﾘｱ位置ﾁｪｯｸ
            With vsfSMIF
                For llngCnt = 0 To mlngStockerListCnt -1
                    '@ｽﾄｯｶｰIDと選択現在位置IDが同じか
                    If .GetData(.Row, CMlngvsfSMIFCurrentPotitionID) _
                        = mtypStockerList(llngCnt).strStockerId Then
                    
                        '@出庫指示ﾎﾞﾀﾝを有効に
                        cmdShip.Enabled = True
                        Exit For
                    End If
                Next llngCnt
                
                If cmdShip.Enabled = False Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003O, lstrCarrierID)
                        
                    '@失敗ﾒｯｾｰｼﾞ表示("ＳＭＩＦ[%1]はストッカー内に存在しません。")
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                    '@ﾌｫｰｶｽの設定
                    If vsfSMIF.Enabled = True AndAlso vsfSMIF.Rows.Count > 1 Then
                        Call pubSetFocus(vsfSMIF)
                    End If
                        
                    Exit Sub
                End If
                
            End With
        '@↑2017/02/09 (Thu) S.Otaki **************************************************

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                '@ﾌｫｰｶｽの設定
                If vsfSMIF.Enabled = True AndAlso vsfSMIF.Rows.Count > 1 Then
                    Call pubSetFocus(vsfSMIF)
                End If
                
                Exit Sub
            End If
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrcmdShipClick)
            
            '@ｷｬﾘｱ手動出庫指示要求
            lblnAns = pubblnCarrManuOutPort_Ins(lstrCarrierID, CMstrcarrmanuoutportVer, cmbStockerSmif.Value, pstrUserID)
            '@戻り値判定
            If lblnAns = True Then
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrcmdShipClick)
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003G, lstrCarrierID, cmbStockerSmif.Text)
                
                '@pubVsfInfo_Disp(ﾒｯｾｰｼﾞｺｰﾄﾞ："<TRM3GI>$$ＳＭＩＦ[%1]のストッカー[%2]への出庫指示を受け付けました。")
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@最新情報取得
                Call cmdNowListSmif_Click(cmdNowListSmif, New EventArgs)
                
        '@↓2005/10/03 (Mon) 11:11:18 N.Kasai **************************************************
                '@出庫指示ﾎﾞﾀﾝ使用不可
                cmdShip.Enabled = False
                
                '@ｸﾞﾘｯﾄﾞのﾌｫｰｶｽ設定有無ﾁｪｯｸ
                If vsfSMIF.Row >= vsfSMIF.Rows.Fixed Then
                    '@出庫指示/装置へ搬送ﾎﾞﾀﾝ使用可否ﾁｪｯｸ
                    Call prvblncmdShipWpMove_Chk()
                End If
        '@↑2005/10/03 (Mon) 11:11:18 N.Kasai **************************************************
                
                Exit Sub
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrcmdShipClick)
                
                '@ﾌｫｰｶｽの設定
                If vsfSMIF.Enabled = True AndAlso vsfSMIF.Rows.Count > 1 Then
                    Call pubSetFocus(vsfSMIF)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdShip_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWpMove_Click
    '機　能：装置へ搬送ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/23 (Wed) 09:59:49 N.Kasai
    '更新日：2005/10/03 (Mon) 11:11:27 N.Kasai
    '備　考：
    '　　　：2005/10/03 (Mon) 11:11:27 N.Kasai  確定後のｺﾏﾝﾄﾞﾎﾞﾀﾝ制御追加
    Private Sub cmdWpMove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWpMove.Click

        Dim lblnAns                 As Boolean          '戻り値
        Dim ltypCarrTransfer        As CarrTransfer     'ｽﾄｯｶｰ/装置搬送指示応答格納構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                '@ﾌｫｰｶｽの設定
                If vsfSMIF.Enabled = True AndAlso vsfSMIF.Rows.Count > 1 Then
                    Call pubSetFocus(vsfSMIF)
                End If
                Exit Sub
            End If
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrcmdWpMoveClick)
            
            '@ｽﾄｯｶｰ/装置搬送指示応答格納
            With ltypCarrTransfer
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CMstrcarrtransferVer
                '@ｷｬﾘｱID(SMIF)
                .strCarrierId = vsfSMIF.GetData(vsfSMIF.Row, CMlngvsfSMIFSmif)
                '@搬送元
                .strCurrentPositionID = cmbStockerSmif.Value
                '@搬送先
                .strDestPositionID = cmbWplistSmif.Value
                '@作業者ID
                .strEmpID = pstrUserID
                '@処理区分（全て）
                .strClassDivision = CPstrCD02
            End With
           
            '@ｽﾄｯｶｰ/装置搬送指示要求
            lblnAns = pubblncarrtransfer_Upd(ltypCarrTransfer)
            
            '@戻り値判定
            If lblnAns = True Then
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrcmdWpMoveClick)
                
                '@表示ﾒｯｾｰｼﾞ変換("<TRM4HI>$$[%1]から[%2]への搬送指示を受け付けました。")
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004H, cmbStockerSmif.Text, cmbWplistSmif.Text)
                
                '@ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@最新情報取得
                Call cmdNowListSmif_Click(cmdNowListSmif, New EventArgs)
                
        '@↓2005/10/03 (Mon) 11:11:18 N.Kasai **************************************************
                '@装置へ搬送ﾎﾞﾀﾝ使用不可
                cmdWpMove.Enabled = False
                
                '@ｸﾞﾘｯﾄﾞのﾌｫｰｶｽ設定有無ﾁｪｯｸ
                If vsfSMIF.Row >= vsfSMIF.Rows.Fixed Then
                    '@出庫指示/装置へ搬送ﾎﾞﾀﾝ使用可否ﾁｪｯｸ
                    Call prvblncmdShipWpMove_Chk()
                End If
        '@↑2005/10/03 (Mon) 11:11:18 N.Kasai **************************************************
                
                Exit Sub
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrcmdWpMoveClick)
                
                '@ﾌｫｰｶｽの設定
                If vsfSMIF.Enabled = True AndAlso vsfSMIF.Rows.Count > 1 Then
                    Call pubSetFocus(vsfSMIF)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWpMove_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '関数名：prvfrmxxEN01M0_Init
    '機　能：ﾒｲﾝ画面初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/17 (Thu) 13:41:17 N.Kasai
    '更新日：2005/02/17 (Thu) 13:41:17
    '備　考：
    Private Sub prvfrmxxEN01M0_Init()
        
        Dim lstrFormTitle   As String               'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN01M0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@各Comboﾎﾞｯｸｽの初期化
            cmbWplistWpLot.Clear                        'ﾚﾁｸﾙ使用装置(wp)
            cmbStockerWpLot.Clear                       'ｽﾄｯｶｰ(wp)
            cmbStockerSmif.Clear                        'ｽﾄｯｶｰ(smif)
            cmbWplistSmif.Clear                         'ﾚﾁｸﾙ使用装置(smif)
            cmbStockerWpLot.Enabled = False             'ｽﾄｯｶｰ（wp)
            cmbStockerSmif.Enabled = False              'ｽﾄｯｶｰ(smif)

            '@各ﾗﾍﾞﾙの初期化
            '@wp
            lblModeWpLot.Text = vbNullString         '運用ﾓｰﾄﾞ(wp)
            lblFtsModeWpLot.Text = vbNullString      '搬送ﾓｰﾄﾞ(wp)
            lblNowDateWplot.Text = vbNullString      '情報取得日時(wp)
            lblLotCntWp.Text = vbNullString          '該当件数(wp)
            lblStatusWpLot.Text = vbNullString       'ﾚﾁｸﾙﾎﾟｰﾄ状態（wp)
            lblSmif.Text = vbNullString              '搭載ｷｬﾘｱ（wp)
            '@smif
            lblStatusSmif.Text = vbNullString        'ﾚﾁｸﾙﾎﾟｰﾄ状態(smif)
            lblModeSmif.Text = vbNullString          '運用ﾓｰﾄﾞ（smif)
            lblFtsModeSmif.Text = vbNullString       '搬送ﾓｰﾄﾞ（smif)
            lblNowDateSmif.Text = vbNullString       '情報取得日時（smif)
            lblLotCntSmif.Text = vbNullString        '該当件数(smif)
            
            '@各Commandﾎﾞﾀﾝの初期化
            cmdNowListWpLot.Enabled = False             '最新取得(wp)
            cmdStockerMove.Enabled = False              'ｽﾄｯｶｰへ搬送(wp)
            cmdReticleMove.Enabled = False              'ﾚﾁｸﾙ払い出し(wp)
            cmdShip.Enabled = False                     '出庫指示(smif)
            cmdWpMove.Enabled = False                   '装置へ搬送(smif)
           
            '@各vsfｸﾞﾘｯﾄﾞの初期化
            Call prvvsfWP_init                          '装置別搬送一覧
            Call prvvsfSMIF_Init                        'SMIF搬送一覧
            
            With mtypChgSort1
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                Else
                    .typChgSortList.Clear
                End If
                '@列幅変更ﾌﾗｸﾞ（未変更）
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            With mtypChgSort2
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                Else
                    .typChgSortList.Clear
                End If
                '@列幅変更ﾌﾗｸﾞ（未変更）
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            '@ｽﾄｯｶｰ初期化(wp)
            With cmbStockerWpLot
                .Clear
                .DispCols = CMlngCmbDispCols                                     'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColName                                    'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbValueCol                                     '値取得列
                .DirectInput = False                                             'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = new Font(.Font.FontFamily, CMlngCmbFontSize)             'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = new Font(.GridFont.FontFamily, CMlngCmbGridFontSize) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                   '行の高さ
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter    '左寄中央揃え
                .Enabled = True                                                  '有効
            End With
            
            '@ｽﾄｯｶｰ初期化(smif)
            With cmbStockerSmif
                .Clear
                .DispCols = CMlngCmbDispCols                                     'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColName                                    'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbValueCol                                     '値取得列
                .DirectInput = False                                             'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = new Font(.Font.FontFamily, CMlngCmbFontSize)             'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = new Font(.GridFont.FontFamily, CMlngCmbGridFontSize) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                   '行の高さ
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter    '左寄中央揃え
                .Enabled = True                                                  '有効
            End With
            
            '@ﾚﾁｸﾙ使用装置ｺﾝﾎﾞ変更ﾌﾗｸﾞwp（True:変更あり、False：変更なし）
            mblnWplistWpLotChangeFlag = False
            
            '@ﾚﾁｸﾙ使用装置ｺﾝﾎﾞ変更ﾌﾗｸﾞsmif（True:変更あり、False：変更なし）
            mblnWplistSmifChangeFlag = False

            '@閉じるボタンへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01M0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfWP_Init
    '機　能：装置別搬送一覧ｸﾞﾘｯﾄﾞ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/17 (Thu) 13:42:16 N.Kasai
    '更新日：2005/02/17 (Thu) 13:42:16
    '備　考：
    Private Sub prvvsfWP_init()

        Try
            
            With vsfWp
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear
                '最大列設定
                .Cols.Count = CMlngvsfWPCols
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                .AllowSorting = AllowSortingEnum.SingleColumn
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                '@ｾﾙ選択の設定
                .SelectionMode = SelectionModeEnum.Row
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号（...）を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                
                '@一覧表の表題設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.ForeColor = Color.Yellow                    '文字色
                lFixedStyle.BackColor = Color.Navy                      '背景色
                With .Font                                              'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                    lFixedStyle.Font = New Font(.FontFamily, CMlngVsfHFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                    lFixedStyle.Trimming = StringTrimming.None
                End With

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngvsfWPNo, CMstrvsfWPNo)                                'No.
                .SetData(CMlngVsfRowTitle, CMlngvsfWPRtclID, CMstrvsfWPRtclID)                        'ﾚﾁｸﾙID
                .SetData(CMlngVsfRowTitle, CMlngvsfWPTrStatus, CMstrvsfWPTrStatus)                    '搬送ｽﾃｰﾀｽ
                .SetData(CMlngVsfRowTitle, CMlngvsfWPTrStatusName, CMstrvsfWPTrStatusName)            '搬送ｽﾃｰﾀｽ（和名）
                .SetData(CMlngVsfRowTitle, CMlngvsfWPCurrentPotitionID, CMstrvsfWPCurrentPotitionID)  '現在位置ID
                .SetData(CMlngVsfRowTitle, CMlngvsfWPCurrentPotition, CMstrvsfWPCurrentPotition)      '現在位置

                '@列幅設定
                .Cols(CMlngvsfWPNo).Width = CMlngvsfWColWPNo                                                      'No.
                .Cols(CMlngvsfWPRtclID).Width = CMlngvsfWColWPWPRtclID                                            'ﾚﾁｸﾙID
                .Cols(CMlngvsfWPTrStatus).Width = CMlngvsfWColWPTrStatus                                          '搬送ｽﾃｰﾀｽ状態
                .Cols(CMlngvsfWPTrStatusName).Width = CMlngvsfWColWPTrStatusName                                  '搬送ｽﾃｰﾀｽ状態（和名）
                        .Cols(CMlngvsfWPCurrentPotitionID).Width = CMlngvsfWColWPCurrentPotitionID                '現在位置ID
                .Cols(CMlngvsfWPCurrentPotition).Width = CMlngvsfWColWPCurrentPotition                            '現在位置

                '@非表示Col設定
                .Cols(CMlngvsfWPCurrentPotitionID).Visible = False                                                'ｷｬﾘｱ現在位置ID
                .Cols(CMlngvsfWPTrStatus).Visible = False                                                         '搬送ｽﾃｰﾀｽID

                '@表示位置の設定
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight
                
                '@ﾛｯｸ
                '.Enabled = False
                
                '@行列のﾏｳｽでの変更を不可にする
                .AllowResizing = AllowResizingEnum.None
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light
                
                '@次,前ﾍﾟｰｼﾞﾎﾞﾀﾝ使用不可
                cmdWpUP.Enabled = False
                cmdWpDown.Enabled = False
                
                '@該当件数/取得日時の初期化
                lblNowDateWplot.Text = vbNullString
                lblLotCntWp.Text = vbNullString
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfWP_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSMIF_Init
    '機　能：SMIF搬送一覧ｸﾞﾘｯﾄﾞ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/17 (Thu) 13:45:39 N.Kasai
    '更新日：2005/02/17 (Thu) 13:45:39
    '備　考：
    Private Sub prvvsfSMIF_Init()

        Try
            
            With vsfSMIF
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear(ClearFlags.Content)
                '最大列設定
                .Cols.Count = CMlngvsfSMIFCols
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                .AllowSorting = AllowSortingEnum.SingleColumn
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                '@ｾﾙ選択の設定
                .SelectionMode = SelectionModeEnum.Row
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号（...）を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                
                '@一覧表の表題設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.ForeColor = Color.Yellow                    '文字色
                lFixedStyle.BackColor = Color.Navy                      '背景色
                With .Font                                              'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                    lFixedStyle.Font = New Font(.FontFamily, CMlngVsfHFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                    lFixedStyle.Trimming = StringTrimming.None
                End With

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngvsfSMIFNo, CMstrvsfSMIFNo)                                'No.
                .SetData(CMlngVsfRowTitle, CMlngvsfSMIFRtclID, CMstrvsfSMIFRtclID)                        'ﾚﾁｸﾙID
                .SetData(CMlngVsfRowTitle, CMlngvsfSMIFStatID, CMstrvsfSMIFStatID)                        'ｷｬﾘｱ状態ID
                .SetData(CMlngVsfRowTitle, CMlngvsfSMIFStatName, CMstrvsfSMIFStatName)                    'ｷｬﾘｱ状態
                .SetData(CMlngVsfRowTitle, CMlngvsfSMIFSmif, CMstrvsfSMIFSmif)                            'SMIF
                .SetData(CMlngVsfRowTitle, CMlngvsfSMIFCurrentPotitionID, CMstrvsfSMIFCurrentPotitionID)  '現在位置ID
                .SetData(CMlngVsfRowTitle, CMlngvsfSMIFCurrentPotition, CMstrvsfSMIFCurrentPotition)      '現在位置

                '@列幅設定
                .Cols(CMlngvsfSMIFNo).Width = CMlngvsfWColSMIFNo                                                      'No.
                .Cols(CMlngvsfSMIFRtclID).Width = CMlngvsfWColSMIFRtclID                                              'ﾚﾁｸﾙID
                .Cols(CMlngvsfSMIFStatID).Width = CMlngvsfWColSMIFStatID                                              'ｷｬﾘｱ状態ID
                .Cols(CMlngvsfSMIFStatName).Width = CMlngvsfWColSMIFStatName                                          'ｷｬﾘｱ状態
                .Cols(CMlngvsfSMIFSmif).Width = CMlngvsfWColSMIFSmif                                                  'SMIF
                .Cols(CMlngvsfSMIFCurrentPotitionID).Width = CMlngvsfWColSMIFCurrentPotitionID                        '現在位置ID
                .Cols(CMlngvsfSMIFCurrentPotition).Width = CMlngvsfWColSMIFCurrentPotition                            '現在位置
                
                '@非表示Col設定
                .Cols(CMlngvsfSMIFStatID).Visible = False                                                             'ｷｬﾘｱ状態ID
                .Cols(CMlngvsfSMIFCurrentPotitionID).Visible = False                                                  '現在位置ID
                
                '@表示位置の設定
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight    '高さ
                
                '@ﾛｯｸ
                '.Enabled = False
                
                '@行列のﾏｳｽでの変更を不可にする
                .AllowResizing = AllowResizingEnum.None
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light
                
                '@次,前ﾍﾟｰｼﾞﾎﾞﾀﾝ使用不可
                cmdSmifUP.Enabled = False
                cmdSmifDown.Enabled = False
                
                '@該当件数/取得日時の初期化
                lblNowDateSmif.Text = vbNullString
                lblLotCntSmif.Text = vbNullString
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSMIF_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbWplistWpLot_Disp
    '機　能：ﾚﾁｸﾙ使用装置ｺﾝﾎﾞﾎﾞｯｸｽ作成（wplot)
    '引　数：llngWpCnt:装置数
    '戻り値：なし
    '作成日：2005/02/17 (Thu) 13:47:20 N.Kasai
    '更新日：2005/02/17 (Thu) 13:47:20
    '備　考：
    Private Sub prvcmbWplistWpLot_Disp(ByVal llngWpCnt As Integer)
        
        Dim llngCnt As Integer                                              'ｶｳﾝﾄ

        Try

            '@ﾚﾁｸﾙ使用装置ｺﾝﾎﾞﾘｽﾄ初期化（装置→ｽﾄｯｶｰ）
            With cmbWplistWpLot
                .Clear
                .DirectInput = False                                             '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                 '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                          '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                     'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol                                     'ｸﾞﾘｯﾄﾞ値取得列数
                .GroupCols = CMlngCmbGroupCols                                   '列方向のﾚｺｰﾄﾞ数
                .GroupRows = llngWpCnt                                           '行方向のﾚｺｰﾄﾞ数
                .Font = new Font(.Font.FontFamily, CMlngCmbFontSize)             'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = new Font(.GridFont.FontFamily, CMlngCmbGridFontSize) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                   'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter    '左寄中央揃え
                .Enabled = True
                
                If llngWpCnt > 0 Then
                    For llngCnt = 0 To llngWpCnt -1
                        .AddItem((ptypWPList(llngCnt).strWpName) & vbTab & (ptypWPList(llngCnt).strWpID)) '装置ID/装置名
                    Next
                End If

                '@装置情報が1件の場合
                If llngWpCnt = 1 Then
                    '@1件目表示
                    .ListIndex = 0
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbWplistWpLot_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbWplistSmif_Disp
    '機　能：ﾚﾁｸﾙ使用装置ｺﾝﾎﾞﾎﾞｯｸｽ作成(smif)
    '引　数：llngWpCnt:装置数
    '戻り値：なし
    '作成日：2005/02/17 (Thu) 13:47:43 N.Kasai
    '更新日：2005/02/17 (Thu) 13:47:43
    '備　考：
    Private Sub prvcmbWplistSmif_Disp(ByVal llngWpCnt As Integer)
        
        Dim llngCnt As Integer                                              'ｶｳﾝﾄ

        Try

            '@ﾚﾁｸﾙ使用装置ｺﾝﾎﾞﾘｽﾄ初期化（ｽﾄｯｶｰ→装置）
            With cmbWplistSmif
                .Clear
                .DirectInput = False                                             '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                 '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                          '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                     'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol                                     'ｸﾞﾘｯﾄﾞ値取得列数
                .GroupCols = CMlngCmbGroupCols                                   '列方向のﾚｺｰﾄﾞ数
                .GroupRows = llngWpCnt                                           '行方向のﾚｺｰﾄﾞ数
                .Font = new Font(.Font.FontFamily, CMlngCmbFontSize)             'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = new Font(.GridFont.FontFamily, CMlngCmbGridFontSize) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                   'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter    '左寄中央揃え
                .Enabled = True
                
                If llngWpCnt > 0 Then
                    For llngCnt = 0 To llngWpCnt -1
                        .AddItem((ptypWPList(llngCnt).strWpName) & vbTab & (ptypWPList(llngCnt).strWpID)) '装置ID/装置名
                    Next
                End If

                '@装置情報が1件の場合
                If llngWpCnt = 1 Then
                    '@1件目表示
                    .ListIndex = 0
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbWplistSmif_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfWP_Disp
    '機　能：装置別搬送ｸﾞﾘｯﾄﾞ表示
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/16 (Wed) 17:03:07 N.Kasai
    '更新日：2005/02/16 (Wed) 17:03:07
    '備　考：
    Private Sub prvvsfWP_Disp(ByRef ltypRtclList As List(Of RtclList), ByRef llngRtclListCnt As Integer, Optional ByVal lblnFocusFlg As Boolean = True)

        Dim llngDoCnt       As Integer  'ｶｳﾝﾄ
        Dim llngCnt         As Integer  'ｶｳﾝﾄ

        Dim llngGridDoCnt   As Integer  'NSYS グリッド用カウント
        Dim lstrSortFlg     As Boolean = False

        Try

            With vsfWp
                '@格納ﾃﾞｰﾀがある場合
                If llngRtclListCnt <> 0 Then
                    
                    '@行数設定
                    RemoveHandler vsfWP.BeforeRowColChange, AddressOf vsfWP_BeforeRowColChange
                    RemoveHandler vsfWP.EnterCell, AddressOf vsfWP_EnterCell

                    .Rows.Count = llngRtclListCnt +1
                    
                    '@ｶｳﾝﾀの初期化
                    llngDoCnt = 0
                    
                    '@ﾛｯﾄ一覧表示情報設定
                    Do While ltypRtclList.Count > llngDoCnt

                        llngGridDoCnt = llngDoCnt + 1

                        .SetData(llngGridDoCnt, CMlngvsfWPNo, llngGridDoCnt)                              '№
                        
                        .SetData(llngGridDoCnt, CMlngvsfWPRtclID, _
                                    ltypRtclList(llngDoCnt).lstrReticleID)                                   'ﾚﾁｸﾙID
                        
                        .SetData(llngGridDoCnt, CMlngvsfWPTrStatus, _
                            ltypRtclList(llngDoCnt).strTransferStatus)                                       '搬送ｽﾃｰﾀｽID
                        
                        .SetData(llngGridDoCnt, CMlngvsfWPTrStatusName, _
                            ltypRtclList(llngDoCnt).strTransferStatusName)                                   '搬送ｽﾃｰﾀｽ
                        
                        '@ﾊﾞｯｸｶﾗｰの判定
                        Select Case ltypRtclList(llngDoCnt).strTransferStatus
                            '@搬入済、搬出可能
                            Case CMstrTrStatus3, CMstrTrStatus4
                                '@ﾊﾞｯｸｶﾗの設定（白色）
                                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                                newStyle.BackColor = vbWhite
                                Dim cellRange As CellRange = .GetCellRange(llngGridDoCnt, CMlngvsfWPNo, llngGridDoCnt, .Cols.Count - 1)
                                cellRange.Style = newStyle
                            Case Else
                                '@ﾊﾞｯｸｶﾗの設定（薄灰色）
                                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                                Dim cellRange As CellRange = .GetCellRange(llngGridDoCnt, CMlngvsfWPNo, llngGridDoCnt, .Cols.Count - 1)
                                cellRange.Style = newStyle
                        End Select
                        
                        '@ｷｬﾘｱ状態を判定
                        Select Case ltypRtclList(llngDoCnt).strCarrierStatID
                            '@ｷｬﾘｱ状態（搬送中、出庫中、入庫中）
                            Case CPstrCarrierStatMove, CPstrCarrierStatStkout, CPstrCarrierStatStkin
                                '@搬送中の場合
                                .SetData(llngGridDoCnt, CMlngvsfWPCurrentPotition, _
                                    CMstrArrow & CPstrSpace & ltypRtclList(llngDoCnt).strDestName)           '搬送先
                                '@搬送中の場合位置情報をｸﾘｱしないと出庫指示ﾎﾞﾀﾝの制御判定に不備あり
                                .SetData(llngGridDoCnt, CMlngvsfWPCurrentPotitionID, _
                                    vbNullString)                                                            '位置情報ID(非表示)

                            Case Else
                                '@搬送中ではない場合
                                .SetData(llngGridDoCnt, CMlngvsfWPCurrentPotition, _
                                    ltypRtclList(llngDoCnt).lstrCurrentPositionName)                         '現在位置
                                .SetData(llngGridDoCnt, CMlngvsfWPCurrentPotitionID, _
                                    ltypRtclList(llngDoCnt).lstrCurrentPositionID)                           '位置情報ID(非表示)
                        End Select
                        
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngGridDoCnt).Height = CMlngVsfHeight
                        
                        '@ｶｳﾝﾄｱｯﾌﾟ
                        llngDoCnt = llngDoCnt + 1
                    Loop

                    '@列幅設定
                    '.AutoSizeMode = flexAutoSizeColWidth
                    
                    '@ｵｰﾄｻｲｽﾞ設定
                    .AutoSizeCol(CMlngvsfWPTrStatus, 6)                                                          '搬送ｽﾃｰﾀｽ
                    .AutoSizeCol(CMlngvsfWPTrStatusName, 6)                                                      '搬送ｽﾃｰﾀｽ(和名）
                    .AutoSizeCol(CMlngvsfWPRtclID, 6)                                                            'ﾚﾁｸﾙID
                    .AutoSizeCol(CMlngvsfWPCurrentPotitionID, 6)                                                 '現在位置ID
                    .AutoSizeCol(CMlngvsfWPCurrentPotition, 6)                                                   '現在位置
                    
                    '@書式設定
                    .Cols(CMlngvsfWPNo).TextAlign = TextAlignEnum.RightCenter                                    '右寄せ中央揃え（ｽﾛｯﾄ№）
                    .Cols(CMlngvsfWPTrStatus).TextAlign = TextAlignEnum.LeftCenter                               '左寄せ中央揃え（ｽﾃｰﾀｽ）
                    .Cols(CMlngvsfWPTrStatusName).TextAlign = TextAlignEnum.LeftCenter                           '左寄せ中央揃え（搬送ｽﾃｰﾀｽ（和名））
                    .Cols(CMlngvsfWPRtclID).TextAlign = TextAlignEnum.LeftCenter                                 '左寄せ中央揃え（ﾚﾁｸﾙID）
                    .Cols(CMlngvsfWPCurrentPotitionID).TextAlign = TextAlignEnum.LeftCenter                      '左寄せ中央揃え（現在位置ID)
                    .Cols(CMlngvsfWPCurrentPotition).TextAlign = TextAlignEnum.LeftCenter                        '左寄せ中央揃え（現在位置)
                    
                   '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort1.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort1.lngCnt -1
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSort1.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort1.typChgSortList(llngCnt).lngOrder
                                .Sort(SortFlags.UseColSort, mtypChgSort1.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If

                    AddHandler vsfWP.BeforeRowColChange, AddressOf vsfWP_BeforeRowColChange
                    AddHandler vsfWP.EnterCell, AddressOf vsfWP_EnterCell
                    
                    '@ｿｰﾄ検索用ｷｰ（№）がある場合
                    If mtypChgSort1.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@№が同じ場合
                            If vsfWp.GetData(llngCnt, CMlngvsfWPNo) = mtypChgSort1.strKey Then
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列）
                                Call pubVsfBeforeSort(vsfWp, CMlngvsfWPNo)
                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定（ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁）
                                Call pubVsfAfterSort(vsfWp, CMlngvsfWPNo,Nothing,Nothing,True,True,False)
                                lstrSortFlg = True
                                Exit For
                            End If
                        Next llngCnt
                    Else
                        '@先頭ﾍﾟｰｼﾞ設定
                        .TopRow = CMlngVsfRowTitle

                        '@ﾀｲﾄﾙ行に行設定
                        .Row = CMlngVsfRowTitle
                    End If

                    'NSYS 最新表示時、行が未選択の場合は最上行に戻る
                    If lstrSortFlg = False Then
                        .Row = 0
                        .TopRow = 0
                    End If
                    
                    '@ﾛｯｸ解除
                    .Enabled = True
                    
                    '@有効の場合
                    If .Enabled = True AndAlso .Rows.Count > 1 Then
                        '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                        If lblnFocusFlg = True Then
                            Call pubSetFocus(vsfWp)
                        End If
                    End If
                End If

                '@該当件数
                lblLotCntWp.Text = llngRtclListCnt
            
                '@現在日時表示
                lblNowDateWplot.Text = Format(Now, CPstrDateFormat)
            
                '@前ﾍﾟｰｼﾞ、次ﾍﾟｰｼﾞ、ｽｸﾛｰﾙﾗﾍﾞﾙ表示設定
                If .Rows.Count > 1 Then
                    cmdWpUP.Enabled = True
                    cmdWpDown.Enabled = True

                    '@ｸﾞﾘｯﾄﾞﾎﾞﾀﾝ制御、保持値ｸﾘｱ
                    Call pubVsfDisp(vsfWp, cmdWpUP, cmdWpDown)
                Else
                    cmdWpUP.Enabled = False
                    cmdWpDown.Enabled = False
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfWP_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSMIF_Disp
    '機　能：smif一覧表示
    '引　数：ltypCarrierList：smif一覧応答格納構造体
    '戻り値：なし
    '作成日：2005/02/16 (Wed) 11:22:39 N.Kasai
    '更新日：2005/02/16 (Wed) 11:22:39
    '備　考：
    Private Sub prvvsfSMIF_Disp(ByRef ltypCarrierList As CarrList)
        
        Dim llngDoCnt       As Integer  'ｶｳﾝﾄ
        Dim llngCnt         As Integer  'ｶｳﾝﾄ
        Dim lblnBackColor   As Boolean  'ﾊﾞｯｸｶﾗｰ変更ﾌﾗｸﾞ（True:変更あり　False：変更なし）

        Dim llngGridDoCnt   As Integer  'NSYS グリッド用カウント
        Dim lstrSortFlg     As Boolean = False

        Try
            
            With vsfSMIF
                '@ﾃﾞｰﾀの有無判定
                If ltypCarrierList.lngCarrierListCnt <> 0 Then
                '@格納ﾃﾞｰﾀがある場合
                   
                    '@行数設定
                    RemoveHandler vsfSMIF.BeforeRowColChange, AddressOf vsfSMIF_BeforeRowColChange
                    RemoveHandler vsfSMIF.EnterCell, AddressOf vsfSMIF_EnterCell

                    .Rows.Count = ltypCarrierList.lngCarrierListCnt +1
                   
                    '@ｶｳﾝﾀの初期化
                    llngDoCnt = 0
                    
                    '@一覧表示情報設定
                    Do While ltypCarrierList.typCarrierList.Count > llngDoCnt

                        llngGridDoCnt = llngDoCnt + 1

                        .SetData(llngGridDoCnt, CMlngvsfSMIFNo, llngGridDoCnt)                        '№
                        
                        .SetData(llngGridDoCnt, CMlngvsfSMIFRtclID, _
                                    ltypCarrierList.typCarrierList(llngDoCnt).strReticleID)              'ﾚﾁｸﾙID
                        
                        .SetData(llngGridDoCnt, CMlngvsfSMIFStatID, _
                                    ltypCarrierList.typCarrierList(llngDoCnt).strCarrierStatID)          'ｷｬﾘｱ状態ID
                        
                        .SetData(llngGridDoCnt, CMlngvsfSMIFStatName, _
                                    ltypCarrierList.typCarrierList(llngDoCnt).strCarrierStatName)        'ｷｬﾘｱ状態(和名）
                        
                        .SetData(llngGridDoCnt, CMlngvsfSMIFSmif, _
                                    ltypCarrierList.typCarrierList(llngDoCnt).strCarrierId)              'SMIF

                        '@ｷｬﾘｱ状態を判定
                        Select Case ltypCarrierList.typCarrierList(llngDoCnt).strCarrierStatID
                            '@ｷｬﾘｱ状態（搬送中、出庫中、入庫中）
                            Case CPstrCarrierStatMove, CPstrCarrierStatStkout, CPstrCarrierStatStkin
                                '@搬送中の場合
                                .SetData(llngGridDoCnt, CMlngvsfSMIFCurrentPotition, _
                                    CMstrArrow & CPstrSpace & _
                                    ltypCarrierList.typCarrierList(llngDoCnt).strDestName)               '搬送先
                                '@搬送中の場合位置情報をｸﾘｱしないと出庫指示ﾎﾞﾀﾝの制御判定に不備あり
                                .SetData(llngGridDoCnt, CMlngvsfSMIFCurrentPotitionID, _
                                    vbNullString)                                                        '位置情報ID(非表示)
                            
                            Case Else
                                '@搬送中ではない場合
                                .SetData(llngGridDoCnt, CMlngvsfSMIFCurrentPotition, _
                                    ltypCarrierList.typCarrierList(llngDoCnt).strCurrentPositionName)    '現在位置

                                .SetData(llngGridDoCnt, CMlngvsfSMIFCurrentPotitionID, _
                                    ltypCarrierList.typCarrierList(llngDoCnt).strCurrentPositionID)      '位置情報ID(非表示)
                                    
                        End Select

                        '@ﾊﾞｯｸｶﾗｰ変更ﾌﾗｸﾞ初期化
                        lblnBackColor = True
                        
                        '@現在位置がﾚﾁｸﾙｽﾄｯｶｰの場合はﾊﾞｯｸｶﾗｰ白
                        For llngCnt = 0 To mlngStockerListCnt -1
                           '@ｽﾄｯｶｰIDと選択現在位置IDが同じか
                            If ltypCarrierList.typCarrierList(llngDoCnt).strCurrentPositionID _
                                = mtypStockerList(llngCnt).strStockerId Then
                                '@ﾊﾞｯｸｶﾗの判定(変更なし）
                                lblnBackColor = False
                                
                                Exit For
                           End If
                        Next llngCnt
                        
                        '@ﾊﾞｯｸｶﾗｰ変更ﾌﾗｸﾞ判定
                        If lblnBackColor = False Then
                           '@ﾊﾞｯｸｶﾗの設定（白色）
                           Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                           newStyle.BackColor = vbWhite
                           Dim cellRange As CellRange = .GetCellRange(llngGridDoCnt, CMlngvsfSMIFNo, llngGridDoCnt, .Cols.Count - 1)
                           cellRange.Style = newStyle
                        Else
                           '@ﾊﾞｯｸｶﾗの設定（薄灰色）
                           Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                           newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                           Dim cellRange As CellRange = .GetCellRange(llngGridDoCnt, CMlngvsfSMIFNo, llngGridDoCnt, .Cols.Count - 1)
                           cellRange.Style = newStyle
                        End If
                        
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngGridDoCnt).Height = CMlngVsfHeight
                        
                        '@ｶｳﾝﾄｱｯﾌﾟ
                        llngDoCnt = llngDoCnt + 1
                    Loop

                    '@列幅設定
                    '.AutoSizeMode = flexAutoSizeColWidth
                    
                    '@ｵｰﾄｻｲｽﾞ設定
                    .AutoSizeCol(CMlngvsfSMIFSmif, 6)                                                    'SMIF
                    .AutoSizeCol(CMlngvsfSMIFStatID, 6)                                                  'ｷｬﾘｱ状態ID
                    .AutoSizeCol(CMlngvsfSMIFStatName, 6)                                                'ｷｬﾘｱ状態
                    .AutoSizeCol(CMlngvsfSMIFRtclID, 6)                                                  'ﾚﾁｸﾙID
                    .AutoSizeCol(CMlngvsfSMIFCurrentPotitionID, 6)                                       '現在位置ID
                    .AutoSizeCol(CMlngvsfSMIFCurrentPotition, 6)                                         '現在位置
                    
                    '@書式設定
                    .Cols(CMlngvsfSMIFNo).TextAlign = TextAlignEnum.RightCenter                          '右寄せ中央揃え（ｽﾛｯﾄ№）
                    .Cols(CMlngvsfSMIFSmif).TextAlign = TextAlignEnum.LeftCenter                         '左寄せ中央揃え（SMIF)
                    .Cols(CMlngvsfSMIFStatID).TextAlign = TextAlignEnum.LeftCenter                       '左寄せ中央揃え（ｷｬﾘｱ状態ID)
                    .Cols(CMlngvsfSMIFStatName).TextAlign = TextAlignEnum.LeftCenter                     '左寄せ中央揃え（ｷｬﾘｱ状態)
                    .Cols(CMlngvsfSMIFRtclID).TextAlign = TextAlignEnum.LeftCenter                       '左寄せ中央揃え（ﾚﾁｸﾙID）
                    .Cols(CMlngvsfSMIFCurrentPotitionID).TextAlign = TextAlignEnum.LeftCenter            '左寄せ中央揃え（現在位置ID)
                    .Cols(CMlngvsfSMIFCurrentPotition).TextAlign = TextAlignEnum.LeftCenter              '左寄せ中央揃え（現在位置)
                    
                   '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort2.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort2.lngCnt -1
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSort2.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort2.typChgSortList(llngCnt).lngOrder
                                .Sort(SortFlags.UseColSort, mtypChgSort2.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If
                    
                    '@ｿｰﾄ検索用ｷｰ（№）がある場合
                    If mtypChgSort2.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@ﾚﾁｸﾙIDが同じ場合
                            If vsfSMIF.GetData(llngCnt, CMlngvsfSMIFNo) = mtypChgSort2.strKey Then
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列）
                                Call pubVsfBeforeSort(vsfSMIF, CMlngvsfSMIFNo)
                                '@ソート後のカレント行設定（ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁）
                                Call pubVsfAfterSort(vsfSMIF, CMlngvsfSMIFNo)
                                lstrSortFlg = True
                                Exit For
                            End If
                        Next llngCnt
                    Else
                        '@先頭ﾍﾟｰｼﾞ設定
                        .TopRow = CMlngVsfRowTitle

                        '@ﾀｲﾄﾙ行に行設定
                        .Row = CMlngVsfRowTitle
                    End If

                    'NSYS 出庫指示/装置へ搬送ﾎﾞﾀﾝ使用可否ﾁｪｯｸ
                    Call prvblncmdShipWpMove_Chk()

                    AddHandler vsfSMIF.BeforeRowColChange, AddressOf vsfSMIF_BeforeRowColChange
                    AddHandler vsfSMIF.EnterCell, AddressOf vsfSMIF_EnterCell
                    
                    'NSYS 最新表示時、行が未選択の場合は最上行に戻る
                    If lstrSortFlg = False Then
                        .Row = 0
                        .TopRow = 0
                    End If

                    '@ﾛｯｸ解除
                    .Enabled = True
                    
                    '@有効の場合
                    If .Enabled = True AndAlso .Rows.Count > 1 Then
                        '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfSMIF)
                    End If
                End If

                '@該当件数
                lblLotCntSmif.Text = llngGridDoCnt
            
                '@現在日時表示
                lblNowDateSmif.Text = Format(Now, CPstrDateFormat)
            
                '@前ﾍﾟｰｼﾞ、次ﾍﾟｰｼﾞ、ｽｸﾛｰﾙﾗﾍﾞﾙ表示設定
                If .Rows.Count > 1 Then
                    cmdSmifUP.Enabled = True
                    cmdSmifDown.Enabled = True
                    '@ｸﾞﾘｯﾄﾞﾎﾞﾀﾝ制御、保持値ｸﾘｱ
                    Call pubVsfDisp(vsfSMIF, cmdSmifUP, cmdSmifDown)
                Else
                    cmdSmifUP.Enabled = False
                    cmdSmifDown.Enabled = False
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSMIF_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbStocker_Disp
    '機　能：ｽﾄｯｶｰ表示
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/23 (Wed) 11:35:40 N.Kasai
    '更新日：2005/02/23 (Wed) 11:35:40
    '備　考：
    Private Sub prvcmbStocker_Disp()
        
        Dim llngCnt             As Integer  'ｶｳﾝﾄ

        Try
                
            '@ｽﾄｯｶｰ（wp/smif)ｺﾝﾎﾞ使用可
            cmbStockerWpLot.Enabled = True
            cmbStockerSmif.Enabled = True

            '@ｽﾄｯｶｰｾｯﾄ
            For llngCnt = 0 To mlngStockerListCnt -1
                '@ﾘｽﾄに項目追加(wp)
                cmbStockerWpLot.AddItem(mtypStockerList(llngCnt).strStockerName & _
                                        vbTab & _
                                        mtypStockerList(llngCnt).strStockerId & _
                                        vbTab & _
                                        llngCnt)                                         'ｽﾄｯｶｰ & ｽﾄｯｶID & 現在のｶｳﾝﾄ数
                
                '@ﾘｽﾄに項目追加(smif)
                cmbStockerSmif.AddItem(mtypStockerList(llngCnt).strStockerName & _
                                       vbTab & _
                                       mtypStockerList(llngCnt).strStockerId & _
                                       vbTab & _
                                       llngCnt)                                          'ｽﾄｯｶｰ & ｽﾄｯｶID & 現在のｶｳﾝﾄ数
                
            Next llngCnt
                       
            '@ｽﾄｯｶｰ初期表示(wp)
            With cmbStockerWpLot
                '@表示件数分だけ表示
                .GroupRows = llngCnt '- 1
                
                '@ﾘｽﾄが1件の場合は直接表示
                If .ListCount = 1 Then
                    '@表示
                    .ListIndex = 0
                End If
            End With
                
            '@ｽﾄｯｶｰ初期表示(smif)
            With cmbStockerSmif
                '@表示件数分だけ表示
                .GroupRows = llngCnt '- 1
                
                '@ﾘｽﾄが1件の場合は直接表示
                If .ListCount = 1 Then
                    '@表示
                    .ListIndex = 0
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbStocker_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnCmdMove_Chk
    '機　能：ﾚﾁｸﾙ払出ﾎﾞﾀﾝ使用可否ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/25 (Fri) 15:01:14 N.Kasai
    '更新日：2005/02/25 (Fri) 15:01:14
    '備　考：
    Private Sub prvblnCmdReticleMove_Chk()

    '@ﾎﾞﾀﾝ使用可条件==========================================================@
    '@ﾚﾁｸﾙ払出し                                                              @
    '@運用ﾓｰﾄﾞ=「S1」and 搬送ﾓｰﾄﾞ=「搬送指示可能」and 搬送ｽﾃｰﾀｽ=「搬入済」      @
    '@ﾎﾞﾀﾝ使用可条件==========================================================@

        Dim lstrTrStatus    As String   '搬送ｽﾃｰﾀｽ格納

        Try
           
            '@運用ﾓｰﾄﾞ判定（S1以外は不可）
            If lblModeWpLot.Text <> CPstrS1 Then
                Exit Sub
            End If
            
            '@搬送ﾓｰﾄﾞ判定(Ttansfer以外は不可）
            If mstrTransferStatusStatus <> CMstrTtansferID Then
                Exit Sub
            End If

            'NSYS データがない場合は処理を抜ける
            If vsfWp.Row <= 0 Then
                '@ﾚﾁｸﾙ払い出しﾎﾞﾀﾝ使用不可
                cmdReticleMove.Enabled = False
                Exit Sub
            End If
            
            With vsfWp
                '@搬送ｽﾃｰﾀｽ格納
                lstrTrStatus = .GetData(.Row, CMlngvsfWPTrStatus)
                    
                Select Case lstrTrStatus
                    '@搬入済
                    Case CMstrTrStatus3
                        '@ﾚﾁｸﾙ払い出しﾎﾞﾀﾝ使用可
                        cmdReticleMove.Enabled = True
                        
                    Case Else
                        '@ﾚﾁｸﾙ払い出しﾎﾞﾀﾝ使用不可
                        cmdReticleMove.Enabled = False
                        
                End Select
                    
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnCmdReticleMove_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblncmdStockerMove_Chk
    '機　能：ｽﾄｯｶｰへ搬送ﾎﾞﾀﾝ使用可否ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/25 (Fri) 15:01:14 N.Kasai
    '更新日：2005/02/25 (Fri) 15:11:01 N.Kasai
    '備　考：
    Private Sub prvblncmdStockerMove_Chk()

    '@ﾎﾞﾀﾝ使用可条件===================================================================@
    '@ｽﾄｯｶｰへ搬送                                                                      @
    '@運用ﾓｰﾄﾞ=「S1」 and 搬送ﾓｰﾄﾞ=「搬送指示可能」 and SMIF<>空白 and ｽﾄｯｶｰ　<>　空白   @
    '@ﾎﾞﾀﾝ使用可条件===================================================================@

        Try

               '@SMIFの有無判定
                If lblSmif.Text <> vbNullString Then
                    '@ｽﾄｯｶｰの有無判定
                    If cmbStockerWpLot.Text <> vbNullString Then
                        '@ｽﾄｯｶｰへ搬送ﾎﾞﾀﾝ使用可
                        cmdStockerMove.Enabled = True
                    Else
                        '@ｽﾄｯｶｰへ搬送ﾎﾞﾀﾝ使用不可
                        cmdStockerMove.Enabled = False
                    End If
                Else
                    '@ｽﾄｯｶｰへ搬送ﾎﾞﾀﾝ使用不可
                    cmdStockerMove.Enabled = False
                End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblncmdStockerMove_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblncmdShipWpMove_Chk
    '機　能：出庫指示/装置へ搬送ﾎﾞﾀﾝ使用可否ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/25 (Fri) 16:12:31 N.Kasai
    '更新日：2005/03/01 (Tue) 13:08:46 N.Kasai
    '備　考：
    '　　　：2005/03/01 (Tue) 13:08:46 N.Kasai  装置へ搬送する場合の条件でﾚﾁｸﾙIDが空白でも搬送可
    Private Sub prvblncmdShipWpMove_Chk()

    '@ﾎﾞﾀﾝ使用可条件=========================================================================@
    '@出庫指示ﾎﾞﾀﾝ                                                                           @
    '@SMIF <> 空白 and ｷｬﾘｱ位置 =「ｽﾄｯｶｰ」and ｽﾄｯｶｰｺﾝﾎﾞ <> 空白                               @
    '@                                                                                       @
    '@装置へ搬送ﾎﾞﾀﾝ                                                                          @
    '@運用ﾓｰﾄﾞ=「S1」and 搬送ﾓｰﾄﾞ=「搬送指示可能」and ｷｬﾘｱ位置= ｽﾄｯｶｰ and 搬送先装置 <> 空白    @
    '@ﾚﾁｸﾙIDが空白の場合でも装置への搬送を可能とする（200/03/01）寺下氏、秋本氏確認              @
    '@ﾎﾞﾀﾝ使用可条件=========================================================================@

        Dim llngCnt As Integer  '汎用ｶｳﾝﾀ

        Try
            
            With vsfSMIF
                '@出庫指示ﾎﾞﾀﾝを無効に
                cmdShip.Enabled = False
                
                '@ｽﾄｯｶｰ有無判定
                If cmbStockerSmif.Text <> vbNullString Then
                    'NSYS 行が0の場合は処理を抜ける
                    If .Row < 0 Then
                        '何もしない
                    '@現在位置IDが"NULL"ではないか
                    Else If .GetData(.Row, CMlngvsfSMIFCurrentPotitionID) <> vbNullString Then
                        '@SMIFが"NULL"ではないか
                        If .GetData(.Row, CMlngvsfSMIFSmif) <> vbNullString Then
                            For llngCnt = 0 To mlngStockerListCnt -1
                                '@ｽﾄｯｶｰIDと選択現在位置IDが同じか
                                If .GetData(.Row, CMlngvsfSMIFCurrentPotitionID) _
                                    = mtypStockerList(llngCnt).strStockerId Then
                                    
                                    '@出庫指示ﾎﾞﾀﾝを有効に
                                    cmdShip.Enabled = True
                                    
                                    Exit For
                                End If
                            Next llngCnt
                        End If
                    End If
                End If
            
                '@運用ﾓｰﾄﾞ判定（S1以外は不可）
                If lblModeSmif.Text <> CPstrS1 Then
                    Exit Sub
                End If
                
                '@搬送ﾓｰﾄﾞ判定(Ttansfer以外は不可）
                If mstrTransferStatusStatus <> CMstrTtansferID Then
                    Exit Sub
                End If
            
            
                '@装置へ搬送ﾎﾞﾀﾝ使用不可
                cmdWpMove.Enabled = False
                
                '@搬送先ﾚﾁｸﾙ装置有無判定
                If cmbWplistSmif.Text <> vbNullString Then
                    '@現在位置が装置
                    For llngCnt = 0 To mlngStockerListCnt -1
                        'NSYS 行が0の場合は処理を抜ける
                        If .Row < 0 Then
                            '何もしない
                        '@ｽﾄｯｶｰIDと選択現在位置IDが同じか
                        Else If .GetData(.Row, CMlngvsfSMIFCurrentPotitionID) _
                            = mtypStockerList(llngCnt).strStockerId Then
                            
                            '@出庫指示ﾎﾞﾀﾝを有効に
                            cmdWpMove.Enabled = True
                            
                            Exit For
                        End If
                    Next llngCnt
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblncmdShipWpMove_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


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
