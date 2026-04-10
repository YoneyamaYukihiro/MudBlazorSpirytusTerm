'ﾌｧｲﾙ名：xxCM0040.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：アクション予約メッセージ表示画面
'作成日：2004/02/27 (Fri) 14:08:33 T.Oide
'更新日：2005/11/22 (Tue) 10:58:05 N.Kasai
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM0040
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM0040    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM0040
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM0040
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM0040)
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
    '======================================Private===========================================

    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyCM0040      'ﾛｰｶﾙ機能ID

    '@定数宣言
    Private Const CMlngMaxDispRow               As Integer = 9                  'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '@停止/保留ﾌﾗｸﾞ比較用
    Private Const CMstrStopHoldFlag1            As String = "1"                 '停止
    Private Const CMstrStopHoldFlag2            As String = "2"                 '保留

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mlngActCnt                          As Integer                      'ｱｸｼｮﾝ予約確認件数
    Private buttonProcessing                    As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                      'NSYS WindowCloseフラグ
    Private mblnDoColseButton                   As Boolean                      'NSYS 確定ボタン処理後の自画面完全に閉じるかのフラグ
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
        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************

    '関数名：Form_Load
    '機　能：ｱｸｼｮﾝ予約のﾒｯｾｰｼﾞを表示する
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/08 (Mon) 19:42:29 T.Oide
    '更新日：2004/03/08 (Mon) 19:42:29
    '備　考：ptypLotActionに格納されているﾃﾞｰﾀを表示する
    Private Sub Form_Load()
        
        Try
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@ﾛｯﾄ情報の初期化
            Call prvfrmxxCM0040_Init()
            
            '@ｱｸｼｮﾝ予約ﾃｷｽﾄﾎﾞｯｸｽ初期化
            txtMessageDisp.MultiLineEx = True
            
            '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ表示
            mlngActCnt = 1
            
            With ptypLotAction
                '@ｱｸｼｮﾝ予約ﾘｽﾄがある場合
                If .lnglstCnt >= mlngActCnt Then
                    '@ｱｸｼｮﾝ予約情報をｾｯﾄ
                    lblLotID.Text = .typLotActList(mlngActCnt - 1).strLotID                         'ﾛｯﾄID
                    lblFlowClass.Text = .typLotActList(mlngActCnt - 1).strFlowClass                 '流動区分
                    lblLotActionTypeName.Text = .typLotActList(mlngActCnt - 1).strLotActionTypeName 'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
                    lblActionTrigger.Text = .typLotActList(mlngActCnt - 1).strActionTrigger         'ｱｸｼｮﾝﾄﾘｶﾞｰ
                    lblWorkDirectionID.Text = .typLotActList(mlngActCnt - 1).strWorkDirectionID     '作業指示書№
                    lblPage.Text = mlngActCnt & CPstrSlash & .lnglstCnt                             '予約数
                    lblOpID.Text = .typLotActList(mlngActCnt - 1).strOpID                           '大工程
                    lblStepID.Text = .typLotActList(mlngActCnt - 1).strStepID                       '小工程
                    lblEngEmpName.Text = .typLotActList(mlngActCnt - 1).strEngEmpName               '技術担当者名
                    
                    '@保留/停止ﾌﾗｸﾞ判定
                    Select Case .typLotActList(mlngActCnt - 1).strStopHoldFlag
                        '@停止の場合
                        Case CMstrStopHoldFlag1
                            '@停止に「あり」を設定
                            lblStop.Text = CPstrAriFlg
                            
                        '@保留の場合
                        Case CMstrStopHoldFlag2
                            '@保留に「あり」を設定
                            lblHold.Text = CPstrAriFlg
                    End Select
                    
                    '@ﾒｯｾｰｼﾞ表示
                    txtMessageDisp.Text = .typLotActList(mlngActCnt - 1).strMessage                 'ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ
                End If
            End With
            
            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = Me.cmdClose
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyCM0040
                .strProcName = "Form_Load"
                .strErrMessage = vbNullString
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
    '作成日：2004/07/28 (Wed) 09:20:38 H.Wajima
    '更新日：2004/11/01 (Mon) 14:59:08 N.Kasai
    '備　考：2004/11/01 (Mon) 14:59:08 N.Kasai  閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender,e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If

            'NSYS アクション予約複数件表示中は元画面へ戻らない
            If mblnCloseFromControlMenu = False AndAlso mblnDoColseButton = False Then
                e.Cancel = True
                Exit Sub
            End If
            
            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyCM0040
                .strProcName = "Form_QueryUnload"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：画面を閉じる
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/08 (Mon) 19:52:02 T.Oide
    '更新日：2004/03/08 (Mon) 19:52:02
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｱｸｼｮﾝ予約実行画面の初期化
            Call prvfrmxxCM0040_Init()

            With ptypLotAction
                '@ｱｸｼｮﾝ予約確認ｶｳﾝﾄ
                mlngActCnt = mlngActCnt + 1
                '@表示していないｱｸｼｮﾝ予約がある場合
                If .lnglstCnt >= mlngActCnt Then
                    lblLotID.Text = .typLotActList(mlngActCnt - 1).strLotID                         'ﾛｯﾄID
                    lblFlowClass.Text = .typLotActList(mlngActCnt - 1).strFlowClass                 '流動区分
                    lblLotActionTypeName.Text = .typLotActList(mlngActCnt - 1).strLotActionTypeName 'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
                    lblActionTrigger.Text = .typLotActList(mlngActCnt - 1).strActionTrigger         'ｱｸｼｮﾝﾄﾘｶﾞｰ
                    lblWorkDirectionID.Text = .typLotActList(mlngActCnt - 1).strWorkDirectionID     '作業指示書№
                    lblPage.Text = mlngActCnt & CPstrSlash & .lnglstCnt                             '予約数
                    lblOpID.Text = .typLotActList(mlngActCnt - 1).strOpID                           '大工程
                    lblStepID.Text = .typLotActList(mlngActCnt - 1).strStepID                       '小工程
                    lblEngEmpName.Text = .typLotActList(mlngActCnt - 1).strEngEmpName               '技術担当者名
                    
                    '@保留/停止ﾌﾗｸﾞ判定
                    Select Case .typLotActList(mlngActCnt - 1).strStopHoldFlag
                        '@停止の場合
                        Case CMstrStopHoldFlag1
                            '@停止に「あり」を設定
                            lblStop.Text = CPstrAriFlg
                            
                        '@保留の場合
                        Case CMstrStopHoldFlag2
                            '@保留に「あり」を設定
                            lblHold.Text = CPstrAriFlg
                    End Select
                    
                    '@ﾒｯｾｰｼﾞ表示
                    txtMessageDisp.Text = .typLotActList(mlngActCnt - 1).strMessage                 'ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ
                End If
                
                '@表示していないｱｸｼｮﾝ予約がない場合
                If .lnglstCnt < mlngActCnt Then
                    mblnDoColseButton = True
                Else
                    mblnDoColseButton = False
                End If
            
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyCM0040
                .strProcName = "cmdClose_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTxtUp_Click
    '機　能：ｺﾒﾝﾄの前頁切替処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 10:34:21 Y.Yamagishi
    '更新日：2005/11/22 (Tue) 10:59:34 N.Kasai
    '備　考：
    '　　　：2005/11/22 (Tue) 10:59:34 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdTxtUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtMessageDisp, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyCM0040
                .strProcName = "cmdTxtUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTxtDown_Click
    '機　能：ｺﾒﾝﾄの次頁切替処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 10:34:36 Y.Yamagishi
    '更新日：2005/11/22 (Tue) 11:01:35 N.Kasai
    '備　考：
    '　　　：2005/11/22 (Tue) 11:01:35 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdTxtDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtMessageDisp, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyCM0040
                .strProcName = "cmdTxtDown_Click"
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

    '関数名：prvfrmxxCM0040_Init
    '機　能：ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ画面初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/13 (Mon) 18:30:42 M.Miura
    '更新日：2005/11/22 (Tue) 11:43:30 N.Kasai
    '備　考：
    '　　　：2005/11/22 (Tue) 11:43:30 N.Kasai      ﾊﾞｯｸｶﾗｰをｸﾞﾚｰに変更
    Private Sub prvfrmxxCM0040_Init()

        Try
            '@ｱｸｼｮﾝ予約情報初期化
            lblLotID.Text = vbNullString             'ﾛｯﾄID
            lblFlowClass.Text = vbNullString         '流動区分
            lblLotActionTypeName.Text = vbNullString 'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
            lblActionTrigger.Text = vbNullString     'ｱｸｼｮﾝﾄﾘｶﾞｰ
            lblWorkDirectionID.Text = vbNullString   '作業指示書№
            lblPage.Text = vbNullString              '予約数
            lblOpID.Text = vbNullString              '大工程
            lblStepID.Text = vbNullString            '小工程
            lblEngEmpName.Text = vbNullString        '技術担当者名
            lblStop.Text = vbNullString              '停止
            lblHold.Text = vbNullString              '保留
            
            With txtMessageDisp
                .BackColor = SystemColors.ControlLight    '背景色（灰）
                .GotBackColor = SystemColors.ControlLight 'ﾌｫｰｶｽ取得時背景色（灰）
                .Locked = True
                .Text = vbNullString                      'ﾒｯｾｰｼﾞ
            End With
            
            cmdTxtUp.Enabled = False                    '▲ﾎﾞﾀﾝ
            cmdTxtDown.Enabled = False                  '▼ﾎﾞﾀﾝ
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyCM0040
                .strProcName = "prvfrmxxCM0040_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtMessageDisp_Change
    '機　能：ﾃｷｽﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 11:03:20 N.Kasai
    '更新日：2005/11/22 (Tue) 11:03:20
    '備　考：
    Private Sub txtMessageDisp_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtMessageDisp.Change

        Try
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtMessageDisp, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyCM0040
                .strProcName = "txtMessageDisp_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtMessageDisp_KeyUp
    '機　能：ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 11:04:23 N.Kasai
    '更新日：2005/11/22 (Tue) 11:04:23
    '備　考：
    Private Sub txtMessageDisp_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtMessageDisp.KeyUp

        Try
            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtMessageDisp, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtMessageDisp_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtMessageDisp_MouseUp
    '機　能：ﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 11:06:47 N.Kasai
    '更新日：2005/11/22 (Tue) 11:06:47
    '備　考：
    Private Sub txtMessageDisp_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtMessageDisp.MouseUp

        Try
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtMessageDisp, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown, e.Button)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyCM0040
                .strProcName = "txtMessageDisp_MouseUp"
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Frame1.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub

End Class
