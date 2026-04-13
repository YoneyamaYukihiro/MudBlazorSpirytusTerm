'ﾌｧｲﾙ名：xxEN01L0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：搬送ﾓｰﾄﾞ管理
'作成日：2004/12/06 (Mon) 11:00:09 N.Kojima
'更新日：2004/12/22 (Wed) 10:00:16 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01L0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01L0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01L0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01L0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01L0)
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
    '======================================Private==========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion                             As String = "01.00"             '機能ﾊﾞｰｼﾞｮﾝ

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrfts_mode____Ver                          As String = "01.00"             '搬送ﾓｰﾄﾞ取得
    Private Const CMstrfts_chgmodemVer                          As String = "01.00"             '搬送ﾓｰﾄﾞ変更指示

    '@機能ID
    Private Const CMstrLocalMenuKey                             As String = CPstrKeyEN01L0      'ﾛｰｶﾙ機能ID

    '@ｸﾞﾘｯﾄ設定
    Private Const CMlngvsfGridTitleRow                          As Integer = 0                  'ﾀｲﾄﾙ行(行)
    Private Const CMlngvsfGridTitleCol                          As Integer = 0                  'ﾀｲﾄﾙ行(列)
    Private Const CMlngvsfGridFontSize                          As Integer = 14                 'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfGridFontSizeH                         As Integer = 12                 'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfGridCols                              As Integer = 7                  'ｶﾗﾑ数
    Private Const CMlngvsfGridHHeight                           As Integer = 27 '400            'ﾍｯﾀﾞｰの高さ
    Private Const CMlngvsfGridHeight                            As Integer = 38 '570            '1ｽﾛｯﾄの高さ
    Private Const CMlngNoSelect                                 As Integer = -1                 'ｸﾞﾘｯﾄ行未選択
    Private Const CMlngvsfGridRows                              As Integer = 10                 '列数
    Private Const CMstrGridFontName                             As String = "ＭＳ ゴシック"     'ｸﾞﾘｯﾄﾞのﾌｫﾝﾄ名

    '@vsfStockerStatusListのｶﾗﾑ定数
    Private Const CMlngvsfMachineStatusListNo                   As Integer = 0                  '№
    Private Const CMlngvsfMachineStatusListMachineName          As Integer = 1                  '機器名
    Private Const CMlngvsfMachineStatusListMachineID            As Integer = 2                  '機器ID
    Private Const CMlngvsfMachineStatusListMachineStatusName    As Integer = 3                  '機器状態名
    Private Const CMlngvsfMachineStatusListMachineStatusID      As Integer = 4                  '機器状態ID
    Private Const CMlngvsfMachineStatusListStockerCapacityName  As Integer = 5                  'ｽﾄｯｶｰ収容状況名
    Private Const CMlngvsfMachineStatusListMachineAlarmID       As Integer = 6                  'ｱﾗｰﾑ

    '@vsfStockerStatusListのｶﾗﾑ幅
    Private Const CMlngvsfMachineStatusListNoW                  As Integer = 40  '600           '№
    Private Const CMlngvsfMachineStatusListMachineNameW         As Integer = 270 '4005          '機器名
    Private Const CMlngvsfMachineStatusListMachineIDW           As Integer = 0                  '機器ID
    Private Const CMlngvsfMachineStatusListMachineStatusNameW   As Integer = 200 '3000          '機器状態名
    Private Const CMlngvsfMachineStatusListMachineStatusIDW     As Integer = 0                  '機器状態ID
    Private Const CMlngvsfMachineStatusListStockerCapacityNameW As Integer = 213 '3195          'ｽﾄｯｶｰ収容状況名
    Private Const CMlngvsfMachineStatusListMachineAlarmIDW      As Integer = 96  '1440          'ｱﾗｰﾑ

    '@vsfStockerStatusListのｶﾗﾑﾀｲﾄﾙ
    Private Const CMstrvsfMachineStatusListNoT                  As String = "№"                '№
    Private Const CMstrvsfMachineStatusListMachineNameT         As String = "機器名"            '機器名
    Private Const CMstrvsfMachineStatusListMachineIDT           As String = "機器ID"            '機器ID
    Private Const CMstrvsfMachineStatusListMachineStatueNameT   As String = "機器状態"          '機器状態名
    Private Const CMstrvsfMachineStatusListMachineStatusIDT     As String = "機器状態ID"        '機器状態ID
    Private Const CMstrvsfMachineStatusListStockerCapacityNameT As String = "ストッカー収容状況" 'ｽﾄｯｶｰ収容状況名
    Private Const CMstrvsfMachineStatusListMachineAlarmIDT      As String = "アラーム"          'ｱﾗｰﾑ

    '@その他定数
    Private Const CMstrCmdNowListClick                          As String = "cmdNowList_Click"  'ｲﾍﾞﾝﾄ名定数
    Private Const CMstrCmdRegistClick                           As String = "cmdRegist_Click"   'ｲﾍﾞﾝﾄ名定数
    Private Const CMstrFormLoad                                 As String = "Form_Load"         'ｲﾍﾞﾝﾄ名定数
    Private Const CMstrTtansferID                               As String = "TRANSFER"          '搬送指示可ID
    Private Const CMstrNoTransferID                             As String = "NOTRANSFER"        '搬送指示不可ID
    Private Const CMstrFtsStatusID                              As String = "PRODUCTIVE"        '運用状態ID
    Private Const CMstrTtansferName                             As String = "搬送指示可"        '搬送指示可
    Private Const CMstrNoTransferIDName                         As String = "搬送指示不可"      '搬送指示不可
    Private Const CMstrAri                                      As String = "あり"              'あり(ｱﾗｰﾑ)
    Private Const CMstrNasi                                     As String = "なし"              'なし(ｱﾗｰﾑ)
    Private Const CMstrNotTarget                                As String = "対象外"            '対象外(ｱﾗｰﾑ)

    '@搬送ﾓｰﾄﾞ選択ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                              As Integer = 14                 'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                          As Integer = 16                 'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngComboRowHeight                           As Integer = 38 '570            '行の高さ
    Private Const CMlngCmbGridColTransferName                   As Integer = 0                  '搬送ﾓｰﾄﾞ名列番
    Private Const CMlngCmbGridColTransferID                     As Integer = 1                  '搬送ﾓｰﾄﾞID列番（非表示項目）
    Private Const CMlngCmbDispCols                              As Integer = 1                  'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbAlignLeftCenter                       As Integer = 1                  'ｸﾞﾘｯﾄﾞ文字表示位置（左中央）

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private===========================================
    Private mtypFtsMode                                         As FtsMode                      '搬送機器状態構造体
    Private mtypChgSort                                         As ChgSort                      'ｿｰﾄ保持用
    Private mlngMachineStatusListCnt                            As Integer                      '機器状態ﾘｽﾄのｶｳﾝﾄ

    Private buttonProcessing                                    As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                            As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                                     As Boolean                      'NSYS WindowCloseフラグ

    Private ReadOnly vbYellow                                   As Color = Color.Yellow         'NSYS vbYellow定義


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
        pubVsfMouseWheelManager_Set(vsfMachineStatusList, cmdUp, cmdDown)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 18:29:16 N.Kojima
    '更新日：2004/12/22 (Wed) 09:26:30 N.Kojima
    '備　考：
    Private Sub Form_Load()
        
        Dim lblnAns                         As Boolean      '搬送ﾓｰﾄﾞ取得戻り値(True/False)
        Dim lstrFormName                    As String       'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName                   As String       'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN01L0, CMstrLocalVersion)
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
            
            '@画面初期化
            Call prvfrmxxEN01L0_Init()
            
            '@ｺﾝﾎﾞﾎﾞｯｸｽ初期化
            Call prvcmbNewMode_Init()
            
            '@機器状態一覧初期化
            Call prvvsfMachineStatusList_Init()
            
            '@搬送ﾓｰﾄﾞをｺﾝﾎﾞへｾｯﾄ
            Call prvFtsMode_Disp()
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = CMstrFormLoad
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@搬送ﾓｰﾄﾞ取得
            lblnAns = pubblnFtsMode_Sel(CMstrfts_mode____Ver, _
                                        mlngMachineStatusListCnt, _
                                        mtypFtsMode)
            '@ｴﾗｰ時は終了
            If lblnAns = True Then
                '@変更後搬送ﾓｰﾄﾞｺﾝﾎﾞを有効に
                cmbNewMode.Enabled = True
                
                '@画面項目表示
                Call prvfrmxxEN01L0_Disp()
                
                '@機器状態一覧表示
                Call prvvsfMachineStatusList_Disp()
            
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            '@Form_Loadﾌﾗｸﾞ（正常）
            pblnFormLoad = True
            
            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose
            
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

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰｶｽ制御
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｷｰｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 18:43:25 N.Kojima
    '更新日：2004/12/06 (Mon) 18:43:25
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            
            '@ｸﾞﾘｯﾄﾞｷｰ制御（ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、前頁ﾎﾞﾀﾝ、次頁ﾎﾞﾀﾝ）
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfMachineStatusList, cmdUP, cmdDown)
            
            Select Case e.KeyCode
                
                '@Enterｷｰの場合
                Case Keys.Return
                    '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙがｸﾞﾘｯﾄﾞの場合
                    If ActiveControl.Name = vsfMachineStatusList.Name Then
                        '@確定ﾎﾞﾀﾝが有効か
                        If cmdRegist.Enabled = True Then
                            '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdRegist)
                        Else
                            '@次項目にﾌｫｰｶｽｾｯﾄ
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                        End If
                    Else
                        '@次項目にﾌｫｰｶｽｾｯﾄ
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                    End If

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

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 18:20:01 N.Kojima
    '更新日：2004/12/06 (Mon) 18:20:01
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化（装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要）
            pblnFormLoad = False
            
            '@構造体のｸﾘｱ
            mtypFtsMode = Nothing
            
            '@ｿｰﾄ保持用構造体のｸﾘｱ
            mtypChgSort = Nothing

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

    '関数名：cmdClose_Click
    '機　能：ﾌﾟﾛｸﾞﾗﾑ終了
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/07 (Tue) 20:06:47 N.Kojima
    '更新日：2004/12/07 (Tue) 20:06:47
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        
        Dim ltypCommonInfo  As CommonInfo   '引継ぎ情報構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@終了関数を実行する
            Call publngEnd_Proc(CPstrKeyEN01L0, ltypCommonInfo)
            
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

    '関数名：cmbNewMode_Change
    '機　能：変更後搬送ﾓｰﾄﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/24 (Fri) 18:54:29 N.Kojima
    '更新日：2004/12/24 (Fri) 18:54:29
    '備　考：
    Private Sub cmbNewMode_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbNewMode.Change
        
        Try
            
            '@運用状態が「正常」の場合
            If mtypFtsMode.strStatus = CMstrFtsStatusID Then
                '@確定ﾎﾞﾀﾝを有効に
                cmdRegist.Enabled = True
            Else
                '@「正常」以外の場合
                '@確定ﾎﾞﾀﾝを無効に
                cmdRegist.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbNewMode_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbNewMode_CloseUp
    '機　能：変更後搬送ﾓｰﾄﾞ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/07 (Tue) 20:15:03 N.Kojima
    '更新日：2004/12/07 (Tue) 20:15:03
    '備　考：
    Private Sub cmbNewMode_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbNewMode.CloseUp

        Try

            '@Validate処理を呼ぶ
            RemoveHandler cmbNewMode.Validating, AddressOf cmbNewMode_Validate
            Call cmbNewMode_Validate(cmbNewMode, New CancelEventArgs(True))
            AddHandler cmbNewMode.Validating, AddressOf cmbNewMode_Validate

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbNewMode_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbNewMode_Validate
    '機　能：変更後搬送ﾓｰﾄﾞ選択Validate処理
    '引　数：Cancel：false
    '戻り値：なし
    '作成日：2004/12/22 (Wed) 10:15:35 N.Kojima
    '更新日：2004/12/22 (Wed) 10:15:35
    '備　考：
    Private Sub cmbNewMode_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbNewMode.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            With cmbNewMode
                '@取得列を変更後搬送ﾓｰﾄﾞに設定
                .ValueCol = 1
                
                '@変更後搬送ﾓｰﾄﾞが選択されている場合かつ、運用状態が"正常(PRODUCTIVE)"の場合
                If cmbNewMode.Text <> vbNullString And mtypFtsMode.strStatus = CMstrFtsStatusID Then
                    '@確定ﾎﾞﾀﾝを有効に
                    cmdRegist.Enabled = True
                End If
                
                '@次項目にﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = cmbNewMode.Name Then
                    If cmdNowList.Enabled = True Then
                        '@最新取得にﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdNowList)
                    End If
                End If 
            
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbNewMode_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/07 (Tue) 20:18:28 N.Kojima
    '更新日：2004/12/24 (Fri) 18:15:22 N.Kojima
    '備　考：2004/12/24 (Fri) 18:15:22 N.Kojima　現在搬送ﾓｰﾄﾞが「搬送指示可」で、変更後搬送ﾓｰﾄﾞが「搬送指示不可」の場合のみﾒｯｾｰｼﾞ表示する判定を追加
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnAns                     As Boolean              '登録戻り値(True/False)
        Dim llngAns                     As Integer              '確認ﾒｯｾｰｼﾞ戻り値
        Dim lstrFormName                As String               'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName               As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrTransferStatus          As String               '変更後搬送ﾓｰﾄﾞ

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@変更後搬送ﾓｰﾄﾞﾁｪｯｸ
            If cmbNewMode.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004M)
                '@<TRM4MW>$$変更後搬送モードが設定されていません。設定を見直してください。ﾒｯｾｰｼﾞ表示
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@変更後搬送ﾓｰﾄﾞへﾌｫｰｶｽを当てる
                Call pubSetFocus(cmbNewMode)
                Exit Sub
            End If
            
            '@現在搬送ﾓｰﾄﾞが「搬送指示可」で、変更後搬送ﾓｰﾄﾞが「搬送指示不可」の場合
            If mtypFtsMode.strTransferStatus = CMstrTtansferID And cmbNewMode.Value = CMstrNoTransferID Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003T)
                '@"<TRM3TI>$$搬送機との接続をオフラインにします。$処理を手動で継続する場合は、装置の運用モードをM1/M2/S1に変更してください。$搬送モード変更を行いますが、よろしいですか？"ﾒｯｾｰｼﾞ表示
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                
                '@確認結果判定
                If llngAns = vbNo Then
                    '@ｷｬﾝｾﾙする
                    Exit Sub
                End If
            End If
            
            '@送信ﾃﾞｰﾀ作成
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
            If pstrUserID = vbNullString Then
                '@未入力の場合、投入中止
                Exit Sub
            End If
            
            '@搬送ﾓｰﾄﾞ変更指示ﾃﾞｰﾀ作成
            lstrTransferStatus = cmbNewMode.Value                                   '変更後搬送ﾓｰﾄﾞ
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = CMstrCmdRegistClick
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@搬送ﾓｰﾄﾞ変更指示
            lblnAns = pubblnFtsChgModem_Upd(CMstrfts_chgmodemVer, lstrTransferStatus)
            
            '@戻り値判定
            If lblnAns = True Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003R, cmbNewMode.Text)
                '@ｽﾃｰﾀｽﾊﾞｰ表示
                '@pubVsfInfo_Disp("<TRM3RI>$$搬送モード[%1]への変更を受け付けました。")
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@変更後搬送ﾓｰﾄﾞをｸﾘｱ
                cmbNewMode.Text = vbNullString
                
                '@確定ﾎﾞﾀﾝ使用不可
                cmdRegist.Enabled = False
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                Exit Sub
            End If
            
            '@最新情報取得
            Call cmdNowList_Click(cmdNowList, New EventArgs)
            
            '@変更後搬送ﾓｰﾄﾞが有効か
            If cmbNewMode.Enabled = True Then
                '@変更後搬送ﾓｰﾄﾞにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmbNewMode)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRegist_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNowList_Click
    '機　能：最新取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/08 (Wed) 13:26:19 N.Kojima
    '更新日：2004/12/27 (Mon) 15:22:05 N.Kasai
    '備　考：
    '　　　：2004/12/27 (Mon) 15:22:05 N.Kasai      確定ﾎﾞﾀﾝ有効無効判定を追加
    '　　　：2005/10/12 (Wed) 13:55:08 S.Deguchi    確定処理で,ComboがNullの場合には確定ﾎﾞﾀﾝは使用不可にする処理を追加
    Private Sub cmdNowList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowList.Click

        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrFormName            As String               'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = CMstrCmdNowListClick
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@搬送ﾓｰﾄﾞ取得
            lblnAns = pubblnFtsMode_Sel(CMstrfts_mode____Ver, _
                                        mlngMachineStatusListCnt, _
                                        mtypFtsMode)
            '@ｴﾗｰ時は終了
            If lblnAns = True Then
                '@変更後搬送ﾓｰﾄﾞｺﾝﾎﾞを有効に
                cmbNewMode.Enabled = True
                
                '@画面項目表示
                Call prvfrmxxEN01L0_Disp()
                
                '@機器状態一覧初期化
                Call prvvsfMachineStatusList_Init()
                
                '@機器状態一覧表示
                Call prvvsfMachineStatusList_Disp()
                
                '@ｸﾞﾘｯﾄﾞ件数が0件の場合
                If ActiveControl.Name = cmdNowList.Name Then
                    If mlngMachineStatusListCnt = 0 Then
                        '@変更後搬送ﾓｰﾄﾞにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmbNewMode)
                    Else
                        '@ｸﾞﾘｯﾄﾞが有効な場合
                        If vsfMachineStatusList.Enabled = True Then
                            '@変更後搬送ﾓｰﾄﾞにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(vsfMachineStatusList)
                        Else
                            '@変更後搬送ﾓｰﾄﾞにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmbNewMode)
                        End If
                    End If
                End If
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                Exit Sub
            End If
            
            '@確定ﾎﾞﾀﾝ有効無効ﾁｪｯｸ
            '@変更後ｺﾝﾎﾞが選択されている場合
            If cmbNewMode.Text <> vbNullString Then
                '@運用状態が「正常」の場合
                If mtypFtsMode.strStatus = CMstrFtsStatusID Then
                    '@確定ﾎﾞﾀﾝを有効に
                    cmdRegist.Enabled = True
                Else
                    '@「正常」以外の場合
                    '@確定ﾎﾞﾀﾝを無効に
                    cmdRegist.Enabled = False
                End If
            Else
        '@↓2005/10/12 (Wed) 13:54:56 S.Deguchi **************************************************
            '@変更後ｺﾝﾎﾞが空欄の場合
                '@確定ﾎﾞﾀﾝを無効に
                cmdRegist.Enabled = False
        '@↑2005/10/12 (Wed) 13:54:56 S.Deguchi **************************************************
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNowList_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：前頁ｽｸﾛｰﾙ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/08 (Wed) 13:57:21 N.Kojima
    '更新日：2004/12/08 (Wed) 13:57:21
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

            '@前頁処理（ｸﾞﾘｯﾄﾞ、前頁、次頁）
            Call pubVsfCmdUp(vsfMachineStatusList, cmdUP, cmdDown)
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：次頁ｽｸﾛｰﾙ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/08 (Wed) 13:57:48 N.Kojima
    '更新日：2004/12/08 (Wed) 13:57:48
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

            '@次頁処理（ｸﾞﾘｯﾄﾞ、前頁、次頁）
            Call pubVsfCmdDown(vsfMachineStatusList, cmdUP, cmdDown)
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMachineStatusList_BeforeSort
    '機　能：ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/12/08 (Wed) 14:02:27 N.Kojima
    '更新日：2004/12/08 (Wed) 14:02:27
    '備　考：
    Private Sub vsfMachineStatusList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfMachineStatusList.BeforeSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfMachineStatusList.Rows.Count <= vsfMachineStatusList.Rows.Fixed Then
                Return
            End If
            
            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、№）
            Call pubVsfBeforeSort(vsfMachineStatusList, CMlngvsfMachineStatusListNo)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMachineStatusList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMachineStatusList_AfterSort
    '機　能：ｿｰﾄ後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/12/08 (Wed) 13:59:18 N.Kojima
    '更新日：2004/12/08 (Wed) 13:59:18
    '備　考：
    Private Sub vsfMachineStatusList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfMachineStatusList.AfterSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfMachineStatusList.Rows.Count <= vsfMachineStatusList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ順を格納
            With mtypChgSort
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                'ReDim Preserve .typChgSortList(.lngCnt)
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                End If

                Dim typChgSortListTmp As ChgSortList = New ChgSortList
                
                '@ｿｰﾄ列番号を格納
                typChgSortListTmp.lngCol = e.Col
                
                '@並び替え方法を格納（昇順/降順）
                typChgSortListTmp.lngOrder = e.Order

                .typChgSortList.Add(typChgSortListTmp)
            End With
            
            '@ｿｰﾄ後のｶﾚﾝﾄ行設定（ｸﾞﾘｯﾄﾞ、№、前頁、次頁）
            Call pubVsfAfterSort(vsfMachineStatusList, CMlngvsfMachineStatusListMachineName, cmdUP, cmdDown)
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMachineStatusList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfAreaEquipment_BeforeRowColChange
    '機　能：機器状態一覧選択変更前処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/12/03 (Fri) 19:11:25 N.Kojima
    '更新日：2004/12/03 (Fri) 19:11:25
    '備　考：
    Private Sub vsfMachineStatusList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfMachineStatusList.BeforeRowColChange
        
        Dim lstrUseName         As String       '用途
        Dim OldRow              As Integer      'NSYS 
        Dim NewRow              As Integer      'NSYS 
        Dim NewCol              As Integer      'NSYS 

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfMachineStatusList.Rows.Count <= vsfMachineStatusList.Rows.Fixed Then
                Return
            End If

            OldRow = e.OldRange.r1
            NewRow = e.NewRange.r1
            NewCol = e.NewRange.c1 
            
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If OldRow <> NewRow And NewRow > 0 Then
                '@新行の用途を格納
                lstrUseName = vsfMachineStatusList.GetData(NewRow, CMlngvsfMachineStatusListNo)
                
                '@ｶﾚﾝﾄ行検索用のｷｰを格納（№、機器名、機器状態名）
                mtypChgSort.strKey = vsfMachineStatusList.GetData(NewRow, CMlngvsfMachineStatusListNo) & _
                                     vsfMachineStatusList.GetData(NewRow, CMlngvsfMachineStatusListMachineName) & _
                                     vsfMachineStatusList.GetData(NewRow, CMlngvsfMachineStatusListMachineStatusName)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMachineStatusList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：prvfrmxxEN01L0_Init
    '機　能：ﾒｲﾝﾌｫｰﾑ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 18:31:51 N.Kojima
    '更新日：2004/12/06 (Mon) 18:31:51
    '備　考：
    Private Sub prvfrmxxEN01L0_Init()

        Dim lstrFormTitle       As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN01L0, lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
              
            With mtypChgSort
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
              
            '@初期値設定
            lblModeMove.Text = vbNullString      'FTS移行可能状態
            lblOldMode.Text = vbNullString       '変更前搬送ﾓｰﾄﾞ
            lblNowDate.Text = vbNullString       '情報取得日時
            lblListCnt.Text = vbNullString       '該当件数
            
            '@ｺﾝﾎﾞ
            cmbNewMode.Text = vbNullString
            cmbNewMode.Enabled = False
            
            '@確定ﾎﾞﾀﾝﾛｯｸ
            cmdRegist.Enabled = False

            '@上下ｽｸﾛｰﾙﾎﾞﾀﾝの制御
            cmdUP.Enabled = False
            cmdDown.Enabled = False
            
            '@終了時にValidateｲﾍﾞﾝﾄを実行しない
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01L0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbNewMode_Init
    '機　能：ｺﾝﾎﾞﾎﾞｯｸｽ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 18:37:44 N.Kojima
    '更新日：2004/12/06 (Mon) 18:37:44
    '備　考：
    Private Sub prvcmbNewMode_Init()

        Try

            '@ｺﾝﾎﾞﾎﾞｯｸｽ設定
            With cmbNewMode
                .Clear
                .DispCols = CMlngCmbDispCols                'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColTransferName       'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColTransferID       '値取得列
                .DirectInput = False                        'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Text = vbNullString                        '初期化
                'ﾌｫﾝﾄｻｲｽﾞ
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)
                'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize,.GridFont.Style, .GridFont.Unit)       
                .RowHeight = CMlngComboRowHeight            'ｸﾞﾘｯﾄﾞの高さ
                .ColAlignment(CMlngCmbGridColTransferName) = CMlngCmbAlignLeftCenter    'ｸﾞﾘｯﾄﾞ表示位置（左中央）
                .BackColor = SystemColors.Window
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbNewMode_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN01L0_Disp
    '機　能：搬送機器状態の表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/07 (Tue) 20:37:45 N.Kojima
    '更新日：2004/12/07 (Tue) 20:37:45
    '備　考：
    Private Sub prvfrmxxEN01L0_Disp()

        Try
            
            '@搬送機器状態の表示
            With mtypFtsMode
                lblModeMove.Text = .strStatusName                            'FTS移行可能状態名
                lblOldMode.Text = .strTransferStatusName                     '搬送可能状態
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01L0_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvFtsMode_Disp
    '機　能：搬送ﾓｰﾄﾞをｺﾝﾎﾞへｾｯﾄ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/07 (Tue) 19:09:21 N.Kojima
    '更新日：2004/12/07 (Tue) 19:09:21
    '備　考：
    Private Sub prvFtsMode_Disp()
        
        Try

            '@搬送ﾓｰﾄﾞｾｯﾄ
            With cmbNewMode
                .Clear
                
                '@2件格納(Trabsfer/NoTransfer)
                .AddItem(CMstrTtansferName _
                       & vbTab _
                       & CMstrTtansferID _
                       & vbTab _
                       & CPstrOne)                   '搬送指示可 & TRANSFER & ｶｳﾝﾄ数
                       
                .AddItem(CMstrNoTransferIDName _
                       & vbTab _
                       & CMstrNoTransferID _
                       & vbTab _
                       & CPstrTwo)                   '搬送指示不可 & NOTRANSFER & ｶｳﾝﾄ数
            End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFtsMode_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfMachineStatusList_Init
    '機　能：搬送機器状態一覧初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/07 (Tue) 20:44:30 N.Kojima
    '更新日：2004/12/22 (Wed) 10:36:52 N.Kojima
    '備　考：
    Private Sub prvvsfMachineStatusList_Init()

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfMachineStatusList
                '@ﾌﾟﾛﾊﾟﾃｨ初期値
                .Clear
                .Cols.Count = CMlngvsfGridCols
                .Rows.Count = .Rows.Fixed
                .SelectionMode = SelectionModeEnum.Default
                .FocusRect = FocusRectEnum.None  'flexFocusNone
                .HighLight = HighLightEnum.Never 'flexHighlightNever
                .Font = New Font(.Font.FontFamily, CMlngvsfGridFontSize, .Font.Style, .Font.Unit)
                '.AutoSizeMode = flexAutoSizeColWidth

                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号（...）を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter

                'NSYS ハイライト、フォーカス時の背景色が設定されないようにする
                .Styles.Focus.Clear
                .Styles.Highlight.Clear

                '@表示位置の設定
                .Cols(CMlngvsfMachineStatusListNo).TextAlign = TextAlignEnum.RightCenter                   '№
                .Cols(CMlngvsfMachineStatusListMachineName).TextAlign = TextAlignEnum.LeftCenter           '機器名
                .Cols(CMlngvsfMachineStatusListMachineID).TextAlign = TextAlignEnum.LeftCenter             '機器ID
                .Cols(CMlngvsfMachineStatusListMachineStatusName).TextAlign = TextAlignEnum.LeftCenter     '機器状態名
                .Cols(CMlngvsfMachineStatusListMachineStatusID).TextAlign = TextAlignEnum.LeftCenter       '機器状態ID
                .Cols(CMlngvsfMachineStatusListStockerCapacityName).TextAlign = TextAlignEnum.LeftCenter   'ｽﾄｯｶｰ収容状況名
                .Cols(CMlngvsfMachineStatusListMachineAlarmID).TextAlign = TextAlignEnum.LeftCenter        'ｱﾗｰﾑ
             

                '@ｸﾞﾘｯﾄﾞの表題設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngBlueColor")
                Dim cellRange As CellRange = .GetCellRange(CMlngvsfGridTitleRow, CMlngvsfMachineStatusListNo, CMlngvsfGridTitleRow, CMlngvsfMachineStatusListMachineAlarmID)
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor) '背景色
                newStyle.ForeColor = vbYellow                                  '文字色
                'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                With .Font                                              
                    newStyle.Font = New Font(.FontFamily, CMlngvsfGridFontSizeH, .Style, .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                newStyle.TextAlign = TextAlignEnum.CenterCenter                '文字位置
                cellRange.Style = newStyle


                '@ﾀｲﾄﾙ設定
                '№
                .SetData(CMlngvsfGridTitleRow, CMlngvsfMachineStatusListNo, CMstrvsfMachineStatusListNoT) 
                '機器名
                .SetData(CMlngvsfGridTitleRow, CMlngvsfMachineStatusListMachineName, CMstrvsfMachineStatusListMachineNameT) 
                '機器ID
                .SetData(CMlngvsfGridTitleRow, CMlngvsfMachineStatusListMachineID, CMstrvsfMachineStatusListMachineIDT)     
                '機器状態名
                .SetData(CMlngvsfGridTitleRow, CMlngvsfMachineStatusListMachineStatusName, CMstrvsfMachineStatusListMachineStatueNameT) 
                '機器状態ID
                .SetData(CMlngvsfGridTitleRow, CMlngvsfMachineStatusListMachineStatusID, CMstrvsfMachineStatusListMachineStatusIDT)     
                'ｽﾄｯｶｰ収容状況名
                .SetData(CMlngvsfGridTitleRow, CMlngvsfMachineStatusListStockerCapacityName, CMstrvsfMachineStatusListStockerCapacityNameT) 
                'ｱﾗｰﾑ
                .SetData(CMlngvsfGridTitleRow, CMlngvsfMachineStatusListMachineAlarmID, CMstrvsfMachineStatusListMachineAlarmIDT)           

                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    '@列幅の設定
                    .Cols(CMlngvsfMachineStatusListNo).Width = CMlngvsfMachineStatusListNoW                                   '№
                    .Cols(CMlngvsfMachineStatusListMachineName).Width = CMlngvsfMachineStatusListMachineNameW                 '機器名
                    .Cols(CMlngvsfMachineStatusListMachineID).Width = CMlngvsfMachineStatusListMachineIDW                     '機器ID
                    .Cols(CMlngvsfMachineStatusListMachineStatusName).Width = CMlngvsfMachineStatusListMachineStatusNameW     '機器状態名
                    .Cols(CMlngvsfMachineStatusListMachineStatusID).Width = CMlngvsfMachineStatusListMachineStatusIDW         '機器状態ID
                    .Cols(CMlngvsfMachineStatusListStockerCapacityName).Width = CMlngvsfMachineStatusListStockerCapacityNameW 'ｽﾄｯｶｰ収容状況名
                    .Cols(CMlngvsfMachineStatusListMachineAlarmID).Width = CMlngvsfMachineStatusListMachineAlarmIDW           'ｱﾗｰﾑ
                End If
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngvsfGridTitleRow).Height = CMlngvsfGridHHeight    '高さ
                
                '@機器ID・機器状態ID列を非表示
                .Cols(CMlngvsfMachineStatusListMachineID).Visible = False
                .Cols(CMlngvsfMachineStatusListMachineStatusID).Visible = False
                
                '@最終colを自動幅設定
                .ExtendLastCol = True
                
                '@該当件数初期化
                lblListCnt.Text = vbNullString
                '@機器状態一覧取得日時初期化
                lblNowDate.Text = vbNullString
                
                '@ﾛｯｸ
                .Enabled = False

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfMachineStatusList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfMachineStatusList_Disp
    '機　能：搬送機器状態一覧表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/07 (Tue) 20:47:04 N.Kojima
    '更新日：2004/12/22 (Wed) 13:55:13 N.Kasai
    '備　考：
    '　　　：2004/12/22 (Wed) 13:55:13 N.Kasai  児島氏確認のもとﾘｻｲｽﾞ機能ｺﾒﾝﾄｱｳﾄ
    '　　　：2004/12/28 (Tue) 11:48:22 N.Kojima　ｱﾗｰﾑIDの判定をNULL or "0"の場合は「なし」を表示するように修正(不具合№387)
    Private Sub prvvsfMachineStatusList_Disp()

        Dim llngCnt                 As Integer      'ｶｳﾝﾄ
        Dim llngCnt2                As Integer      'ｶｳﾝﾄ2
        Dim llngGridCnt             As Integer      'NSYS グリッド用

        Try
            
            With vsfMachineStatusList
                '@行数設定
                .Rows.Count = mlngMachineStatusListCnt + 1
            End With
            
            '@ｶｳﾝﾄ初期化
            llngCnt = 0
            
            
            '@ｽﾄｯｶｰﾘｽﾄ分
            Do While mtypFtsMode.lngStockerListCnt -1 >= llngCnt
                
                llngGridCnt = llngCnt + 1

                With mtypFtsMode.typFtsStockerLIST(llngCnt)
                    vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListNo, llngGridCnt)                       '№
                        
                    vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListMachineName, .strStockerName )     'ｽﾄｯｶｰ名

                    vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListMachineID, .strStockerId)          'ｽﾄｯｶｰID
                        
                    vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListMachineStatusName, .strStatusName) 'ｽﾄｯｶｰ状態名
                        
                    vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListMachineStatusID, .strStatus)       'ｽﾄｯｶｰ状態ID
                        
                    vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListStockerCapacityName, .strStockerCapacityName) 'ｽﾄｯｶｰ収容状況名

                    '@ｱﾗｰﾑIDがNullではない場合
                    If .strAlarmID <> vbNullString Then
                        '@ｱﾗｰﾑIDが"0"ではない場合
                        If .strAlarmID <> CPstrZero Then
                            vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListMachineAlarmID, CMstrAri)           'ｱﾗｰﾑあり
                        Else
                            vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListMachineAlarmID, CMstrNasi)          'ｱﾗｰﾑなし
                        End If
                    Else
                        vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListMachineAlarmID, CMstrNasi)          'ｱﾗｰﾑなし
                    End If
                    
                    '@ｽﾛｯﾄの高さの設定
                    vsfMachineStatusList.Rows(llngGridCnt).Height = CMlngvsfGridHeight
                    
                    llngCnt = llngCnt + 1
                End With
            Loop
            
            '@ｶｳﾝﾄ初期化
            llngCnt2 = 0
            
            '@ﾍﾞｲﾘｽﾄ分
            Do While mtypFtsMode.lngBayListCnt -1 >= llngCnt2

                llngGridCnt = llngCnt + 1

                With mtypFtsMode.typFtsBAYLIST(llngCnt2)
                    vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListNo, llngGridCnt)                        '№
                        
                    vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListMachineName, .strBAYName)           'ﾍﾞｲ名
                        
                    vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListMachineID, .strBAYID)               'ﾍﾞｲID
                        
                    vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListMachineStatusName, .strStatusName)  'ﾍﾞｲ状態名
                        
                    vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListMachineStatusID, .strStatus)        'ﾍﾞｲ状態ID
                        
                    vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListStockerCapacityName, CMstrNotTarget)'ｽﾄｯｶｰ収容状況名

                    '@ｱﾗｰﾑIDがNullではない場合
                    If .strAlarmID <> vbNullString Then
                        '@ｱﾗｰﾑIDが"0"ではない場合
                        If .strAlarmID <> CPstrZero Then
                            vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListMachineAlarmID, CMstrAri)           'ｱﾗｰﾑあり
                        Else
                            vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListMachineAlarmID, CMstrNasi)          'ｱﾗｰﾑなし
                        End If
                    Else
                        vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListMachineAlarmID, CMstrNasi)          'ｱﾗｰﾑなし
                    End If
                    
                    '@ｽﾛｯﾄの高さの設定
                    vsfMachineStatusList.Rows(llngGridCnt).Height = CMlngvsfGridHeight
                    
                    llngCnt = llngCnt + 1
                    llngCnt2 = llngCnt2 + 1
                End With
            Loop
            
            '@ｶｳﾝﾄ初期化
            llngCnt2 = 0
            
            '@ﾋﾞｰｸﾙﾘｽﾄ分
            Do While mtypFtsMode.lngVehicleListCnt -1 >= llngCnt2

                llngGridCnt = llngCnt + 1

                With mtypFtsMode.typFtsVehicleLIST(llngCnt2)
                    vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListNo, llngGridCnt)                           '№
                    vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListMachineName, .strVehicleName)          'ﾋﾞｰｸﾙ名
                    vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListMachineID, .strVehicleID)              'ﾋﾞｰｸﾙID
                    vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListMachineStatusName, .strStatusName)     'ﾋﾞｰｸﾙ状態名
                    vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListMachineStatusID, .strStatus)           'ﾋﾞｰｸﾙ状態ID
                    vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListStockerCapacityName, CMstrNotTarget)   'ｽﾄｯｶｰ収容状況名
                    vsfMachineStatusList.SetData(llngGridCnt, CMlngvsfMachineStatusListMachineAlarmID, CMstrNotTarget)        'ｱﾗｰﾑID
                    
                    '@ｽﾛｯﾄの高さの設定
                    vsfMachineStatusList.Rows(llngGridCnt).Height = CMlngvsfGridHeight
                    
                    llngCnt = llngCnt + 1
                    llngCnt2 = llngCnt2 + 1
                End With
            Loop
            
            With vsfMachineStatusList
                '@ｽﾌﾟﾚｯﾄﾞを初期値へ移動
                .LeftCol = CMlngvsfGridTitleCol         '列
                .TopRow = CMlngvsfGridTitleRow          '行
                .Row = CMlngvsfGridTitleRow             'ｶﾚﾝﾄ行の移動
                
                '@前頁、次頁、ｽｸﾛｰﾙﾗﾍﾞﾙ表示設定
                If .Rows.Count > CMlngvsfGridRows + 1 Then
                    cmdUP.Enabled = True
                    cmdDown.Enabled = True
                Else
                    cmdUP.Enabled = False
                    cmdDown.Enabled = False
                End If
                
                '@ﾕｰｻﾞによりｿｰﾄされている場合
                If mtypChgSort.lngCnt > 0 Then
                    '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                    For llngCnt = 0 To mtypChgSort.lngCnt -1
                        '@該当行をｿｰﾄ
                        .Cols(mtypChgSort.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort.typChgSortList(llngCnt).lngOrder
                        .Sort(SortFlags.UseColSort, mtypChgSort.typChgSortList(llngCnt).lngCol)
                    Next llngCnt
                End If
                
                '@ｿｰﾄ検索用ｷｰがある場合
                If mtypChgSort.strKey <> vbNullString Then
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@機器名、機器状態、ｱﾗｰﾑIDが同じ場合
                        If .GetData(llngCnt, CMlngvsfMachineStatusListMachineName) & _
                           .GetData(llngCnt, CMlngvsfMachineStatusListMachineStatusName) & _
                           .GetData(llngCnt, CMlngvsfMachineStatusListMachineAlarmID) = mtypChgSort.strKey Then
                            .Row = llngCnt
                            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列）
                            Call pubVsfBeforeSort(vsfMachineStatusList, CMlngvsfMachineStatusListNo & _
                                                    vbTab & CMlngvsfMachineStatusListMachineAlarmID)
                            '@ｿｰﾄ後のｶﾚﾝﾄ行設定（ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁）
                            Call pubVsfAfterSort(vsfMachineStatusList, CMlngvsfMachineStatusListNo & _
                                                    vbTab & CMlngvsfMachineStatusListMachineAlarmID, cmdUP, cmdDown)
                            Exit For
                        End If
                    Next llngCnt
                Else
                    '@先頭ﾍﾟｰｼﾞ設定
                    .TopRow = CMlngvsfGridTitleRow
                    
                    '@ﾀｲﾄﾙ行に行設定
                    .Row = CMlngvsfGridTitleRow
                
                End If
                
                '@上(前頁)ｽｸﾛｰﾙﾎﾞﾀﾝ設定
                If .TopRow = .Rows.Fixed Then
                    '@上ｽｸﾛｰﾙを無効に
                    cmdUP.Enabled = False
                Else
                    '@上ｽｸﾛｰﾙを有効に
                    cmdUP.Enabled = True
                End If
                
                '@下(次頁)ｽｸﾛｰﾙﾎﾞﾀﾝ設定
                If .TopRow + CMlngvsfGridRows >= .Rows.Count Then
                    '@下ｽｸﾛｰﾙを無効に
                    cmdDown.Enabled = False
                Else
                    '@上ｽｸﾛｰﾙを有効に
                    cmdDown.Enabled = True
                End If
                
                '@機器名に列設定
                .LeftCol = .Cols.Fixed
                .Col = .Cols.Fixed

                '@ｸﾞﾘｯﾄﾞ表示後処理
                Call pubVsfDisp(vsfMachineStatusList)
                        
                '@該当件数
                lblListCnt.Text = mlngMachineStatusListCnt
            
                '@現在日時表示
                lblNowDate.Text = Format$(Now, CPstrDateFormat)
                
                '@該当件数が1件以上ある場合
                If mlngMachineStatusListCnt > 0 Then
                    '@機器状態一覧を有効に
                    .Enabled = True
                End If
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfMachineStatusList_Disp"
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


    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraFtsMode.Paint, fraMachineList.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub

End Class
