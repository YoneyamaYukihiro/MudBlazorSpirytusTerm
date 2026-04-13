'ﾌｧｲﾙ名：xxEN01X6.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：APC設定確認
'作成日：2006/03/07 (Tue) 10:28:14 N.Kasai
'更新日：2017/02/20 (Mon) 09:14:27 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2017, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01X6
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01X6    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01X6
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01X6
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01X6)
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
    '                                   * 定数の記述 *
    '***************************************************************************************
    '======================================Public===========================================
    '======================================Private==========================================
    '@機能ID
    Private Const CMstrLocalMenuKey         As String = CPstrKeyEN01X6      'ﾛｰｶﾙ機能ID

    '@ﾌｫｰﾏｯﾄ
    Private Const CMstrNoFormat             As String = "000"               'ｵｰﾀﾞ番号ﾌｫｰﾏｯﾄ
    '@表示用
    Private Const CMstrMeasure              As String = "測定"
    Private Const CMstrProcess              As String = "処理"
    Private Const CMstrFB                   As String = "F/B"
    Private Const CMstrFF                   As String = "F/F"

    '@ｸﾞﾘｯﾄﾞ表示用
    Private Const vsfMeasStepListOpId       As Integer = 0                     '大工程
    Private Const vsfMeasStepListSteppId    As Integer = 1                     '小工程
    '***************************************************************************************
    '                                   * 変数の記述 *
    '***************************************************************************************
    '======================================Public===========================================
    Private mblnFormLoadFlag                As Boolean          'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ
    Private mlngCmbApcIndex                 As Integer          'APCﾀｲﾌﾟｺﾝﾎﾞ変更ｲﾝﾃﾞｯｸｽ退避

    Private buttonProcessing                As Boolean          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu        As Boolean          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                 As Boolean          'NSYS WindowCloseフラグ

    Private ReadOnly vbWhite                As Color = Color.White               'NSYS vbBlack定義
    Private ReadOnly vbButtonFace           As Color = SystemColors.ControlLight 'NSYS vbButtonFace定義


    '======================================Private==========================================
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
    '                              * イベントハンドラの記述 *
    '***************************************************************************************
    '======================================Private==========================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/14 (Tue) 13:29:00 N.Kasai
    '更新日：2006/03/14 (Tue) 13:29:00
    '備　考：
    Private Sub Form_Load()
        
        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化
            mblnFormLoadFlag = False
            
            '@画面表示の初期処理
            Call prvfrmxxEN01X6_Init()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Load"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑｱｸﾃｨﾍﾞｲﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/14 (Tue) 13:29:42 N.Kasai
    '更新日：2006/03/14 (Tue) 13:29:42
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ判定
            If mblnFormLoadFlag = True Then
                '@初回以外は処理しない

                'NSYS Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@APCﾀｲﾌﾟｺﾝﾎﾞの設定
            Call prvCmbApcType_Set()
            
            '@ﾒｲﾝ画面からAPC設定が選択済みの場合関連情報の初期表示を行う。
            If ptypApcOpStepInfo.strApcTypeNow <> vbNullString Then
                
        '        '@ｵｰﾀﾞ番号をｺﾝﾎﾞに設定
        '        cmbNo.Text = ptypApcOpStepInfo.strListOrderNow
                '@関連情報を表示
                RemoveHandler cmbNo.Validating, AddressOf cmbNo_Validate
                Call cmbNo_Validate(cmbNo, New CancelEventArgs)
                AddHandler cmbNo.Validating, AddressOf cmbNo_Validate
            
                '@APCﾀｲﾌﾟ設定（使用不可）
                fraApcType.Enabled = False
                cmbApcType.BackColor = vbButtonFace
                
                '@ｵｰﾀﾞｰ番号設定（使用可）
                fraFbNo.Enabled = True
                cmbNo.BackColor = vbWhite

            Else

                '@APCﾀｲﾌﾟ設定（使用可）
                fraApcType.Enabled = True
                cmbApcType.BackColor = vbWhite

                '@ｵｰﾀﾞｰ番号設定（使用可）
                fraFbNo.Enabled = True
                cmbNo.BackColor = vbWhite
            End If
            
            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose
            
            'NSYS カーソルをハイライト
            If cmbApcType.Enabled = True Then
                Call pubSetFocus(cmbApcType)
            Else
                Call pubSetFocus(cmbNo)
            End If

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞON
            mblnFormLoadFlag = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Activate"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑｷｰﾀﾞｳﾝ制御
    '引　数：KeyCode    ：ｷｰﾀﾞｳﾝ
    '　　　：Shift      ：Shift/Ctrl/Altﾎﾞﾀﾝ有無
    '戻り値：なし
    '作成日：2006/03/14 (Tue) 13:53:52 N.Kasai
    '更新日：2006/03/14 (Tue) 13:53:52
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

            '@ｷｰｺｰﾄﾞ判定
            Select Case e.KeyCode
                Case Keys.Return    '[ENTER]押下
                    '@ﾌｫｰｶｽの移動
                    SendKeys.SendWait(CPstrSendKeysTab)
                    e.Handled = True
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_KeyDown"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑの初期化
    '引　数：Cancel    ：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2006/03/14 (Tue) 13:59:52 N.Kasai
    '更新日：2006/03/14 (Tue) 13:59:52
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim ltypApcOpStepInfo    As ApcOpStepInfo     'APC設定構造体
        
        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If

            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If

            '@構造体のｸﾘｱ
            ptypApcOpStepInfo = ltypApcOpStepInfo
            
            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_QueryUnload"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbApcType_Change
    '機　能：APCﾀｲﾌﾟｺﾝﾎﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/02 (Fri) 10:57:49 N.Kasai
    '更新日：2006/06/02 (Fri) 10:57:49
    '備　考：
    Private Sub cmbApcType_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbApcType.Change

        Try
           
            '@画面の初期化
            Call prvfrmxxEN01X6_Init()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbApcType_Change"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbApcType_CloseUp
    '機　能：APCﾀｲﾌﾟｺﾝﾎﾞCloseUp
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/02 (Fri) 10:57:05 N.Kasai
    '更新日：2006/06/02 (Fri) 10:57:05
    '備　考：
    Private Sub cmbApcType_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbApcType.CloseUp

        Try

            '@Validate
            If cmbApcType.Text <> vbNullString Then
                RemoveHandler cmbApcType.Validating, AddressOf cmbApcType_Validate
                Call cmbApcType_Validate(cmbApcType, New CancelEventArgs)
                AddHandler cmbApcType.Validating, AddressOf cmbApcType_Validate
                SendKeys.SendWait(CPstrSendKeysTab)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbApcType_CloseUp"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbApcType_Validate
    '機　能：APCﾀｲﾌﾟｺﾝﾎﾞ処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/06/02 (Fri) 10:56:21 N.Kasai
    '更新日：2006/06/02 (Fri) 10:56:21
    '備　考：
    Private Sub cmbApcType_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbApcType.Validating

        Dim llngIndex   As Integer  'ｲﾝﾃﾞｯｸｽ(1:ﾌｫﾄ、2:ｺﾝﾀｸﾄｴｯﾁｬｰ）
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
                 
            '@APCﾀｲﾌﾟが空白の場合
            If cmbApcType.ListIndex = -1 Then
                Exit Sub
            End If
            
            '@変更内容比較
            If cmbApcType.ListIndex = mlngCmbApcIndex Then
                '@変更なし
                Exit Sub
            End If
            
            '@変更内容退避
            mlngCmbApcIndex = cmbApcType.ListIndex
            
            With cmbApcType
                
                .ValueCol = 1
                Select Case .Value
                    
                    '@ﾌｫﾄ
                    Case "1"
                        
                        '@ﾀｲﾄﾙ変更
                        .ValueCol = 0
                        lblTitle2.Text = .Value & lblTitle2.Text          'F/B番号
                        lblTitle3.Text = CMstrProcess & lblTitle3.Text    '処理大工程
                        lblTitle4.Text = CMstrProcess & lblTitle4.Text    '処理大工程
                        lblTitle5.Text = CMstrMeasure & lblTitle5.Text    '測定大工程
                        lblTitle6.Text = CMstrMeasure & lblTitle6.Text    '測定大工程
                        '@ｵｰﾀﾞｰ番号ｺﾝﾎﾞ取得用にｲﾝﾃﾞｯｸｽを設定
                        llngIndex = 1
                    
                    '@ｺﾝﾀｸﾄｴｯﾁｬｰ
                    Case "2"
                        
                        '@ﾀｲﾄﾙ変更
                        .ValueCol = 0
                        lblTitle2.Text = .Value & lblTitle2.Text          'F/F番号
                        lblTitle3.Text = CMstrMeasure & lblTitle3.Text    '測定大工程
                        lblTitle4.Text = CMstrMeasure & lblTitle4.Text    '測定大工程
                        lblTitle5.Text = CMstrProcess & lblTitle5.Text    '処理大工程
                        lblTitle6.Text = CMstrProcess & lblTitle6.Text    '処理大工程
                        '@ｵｰﾀﾞｰ番号ｺﾝﾎﾞ取得用にｲﾝﾃﾞｯｸｽを設定
                        llngIndex = 2
                        
                End Select
                
                '@APC対象表示
                .ValueCol = 2
                lblApcTergetEqType.Text = .Value
            
            End With
            
            '@ｵｰﾀﾞｰ番号ｺﾝﾎﾞ設定
            Call prvCmbNo_Set(llngIndex)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbApcType_Validate"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbNo_Change
    '機　能：ｵｰﾀﾞｰ番号の変更時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/14 (Tue) 14:00:13 N.Kasai
    '更新日：2006/03/14 (Tue) 14:00:13
    '備　考：
    Private Sub cmbNo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbNo.Change

        Try

           
            '@制約工程の初期化
            lblFromOpId.Text = vbNullString      'FORM大工程
            lblFromStepId.Text = vbNullString    'FROM小工程
            lblToOpId.Text = vbNullString        'TO大工程
            lblToStepId.Text = vbNullString      'TO小工程
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbNo_Change"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbNo_CloseUp
    '機　能：ｵｰﾀﾞｰ番号 ｸﾛｰｽﾞｱｯﾌﾟ時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/14 (Tue) 14:00:30 N.Kasai
    '更新日：2006/03/14 (Tue) 14:00:30
    '備　考：
    Private Sub cmbNo_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbNo.CloseUp

        Try

            '@Validate
            If cmbNo.Text <> vbNullString Then
                RemoveHandler cmbNo.Validating, AddressOf cmbNo_Validate
                Call cmbNo_Validate(cmbNo, New CancelEventArgs)
                AddHandler cmbNo.Validating, AddressOf cmbNo_Validate
                SendKeys.SendWait(CPstrSendKeysTab)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbNo_CloseUp"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbNo_Validate
    '機　能：ｵｰﾀﾞｰ番号Validate
    '引　数：Cancel：未使用
    '戻り値：なし
    '作成日：2006/03/14 (Tue) 14:01:07 N.Kasai
    '更新日：2017/02/20 (Mon) 09:14:17 T.Oide
    '備　考：
    Private Sub cmbNo_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbNo.Validating

        Dim llngCnt     As Integer'配列ｶｳﾝﾀ
        Dim llngIndex   As Integer
    '@↓2017/02/20 (Mon) 09:18:40 T.Oide **************************************************
        Dim llngRowCnt  As Integer
        Dim tmpOpId     As String
        Dim tmpStepId   As String
    '@↑2017/02/20 (Mon) 09:18:40 T.Oide **************************************************

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
                 
            '@APC設定番号が空白の場合
            If cmbNo.Text = vbNullString Then
                Exit Sub
            End If
            
            '@APCﾀｲﾌﾟｺﾝﾎﾞの内容を取得（1:ﾌｫﾄ、2：ｺﾝﾀｸﾄｴｯﾁｬｰ)
            llngIndex = cmbApcType.ListIndex
            
            '@引継ぎ構造体よりｺﾝﾎﾞ内容を設定
            For llngCnt = 0 To ptypApcOpStepInfo.typApcTypeList(llngIndex).lngApcOpStepListCnt -1
                
                '@ｺﾝﾎﾞ表示のｵｰﾀﾞｰ番号と構造体内のﾃﾞｰﾀを比較し一致した場合はﾃﾞｰﾀ表示
                If cmbNo.Text = ptypApcOpStepInfo.typApcTypeList(llngIndex).typApcOpStepList(llngCnt).strListOrder Then
                    
                    '@ﾃﾞｰﾀ表示
                    With ptypApcOpStepInfo.typApcTypeList(llngIndex).typApcOpStepList(llngCnt)
                    
                        lblFromOpId.Text = .strFromOpId                      'FROM大工程ID
                        lblFromStepId.Text = .strFromStepId                  'FROM小工程ID
                        lblToOpId.Text = .strToOpId                          'TO大工程ID
                        lblToStepId.Text = .strToStepId                      'TO小工程ID
                    
        '@↓2017/02/20 (Mon) 09:14:13 T.Oide **************************************************
                        If .blnPatchFlag = True Then
                            '@ﾊﾟｯﾁ分割用ｸﾞﾘｯﾄﾞ表示
                            vsfMeasStepList.Visible = True
                            
                            '@ｸﾞﾘｯﾄﾞに情報を表示
                            vsfMeasStepList.Rows.Count = .lngPatchDivNum + 1
                            For llngRowCnt = 1 To vsfMeasStepList.Rows.Count - 1
                                
                                '@大工程/小行程を取得
                                Call getPtypApcOpStepListMesureVal(llngCnt, llngRowCnt, tmpOpId, tmpStepId)
                                
                                '@ｸﾞﾘｯﾄﾞ表示
                                vsfMeasStepList.SetData(llngRowCnt, vsfMeasStepListOpId, tmpOpId)
                                vsfMeasStepList.SetData(llngRowCnt, vsfMeasStepListSteppId, tmpStepId)
                                
                            Next
                        Else
                            '@ﾊﾟｯﾁ分割用ｸﾞﾘｯﾄﾞ非表示
                            vsfMeasStepList.Visible = False
                        End If
        '@↑2017/02/20 (Mon) 09:14:13 T.Oide **************************************************
                        
                    End With
                End If
            Next
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbNo_Validate"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/14 (Tue) 14:17:19 N.Kasai
    '更新日：2006/03/14 (Tue) 14:17:19
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

            '@画面を閉じる
            Me.Close()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdClose_Click"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN01X6_Init
    '機　能：初期処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/03/14 (Tue) 13:28:28 N.Kasai
    '更新日：2017/02/15 (Wed) 17:08:58 T.Oide
    '備　考：
    Private Sub prvfrmxxEN01X6_Init()

        Try

            '@制約工程の初期化
            lblFromOpId.Text = vbNullString      'FORM大工程
            lblFromStepId.Text = vbNullString    'FROM小工程
            lblToOpId.Text = vbNullString        'TO大工程
            lblToStepId.Text = vbNullString      'TO小工程
            
            '@APC対象
            lblApcTergetEqType.Text = vbNullString
            
            '@ﾀｲﾄﾙ
            lblTitle2.Text = "番号"
            lblTitle3.Text = "大工程"
            lblTitle4.Text = "小工程"
            lblTitle5.Text = "大工程"
            lblTitle6.Text = "小工程"
            
            '@ｵｰﾀﾞｰ番号初期化
            cmbNo.ListIndex = -1
            
            '@APCｺﾝﾎﾞｲﾝﾃﾞｯｸｽ初期化
            mlngCmbApcIndex = -1
            
        '@↓2017/02/15 (Wed) 17:08:53 T.Oide **************************************************
            '@初期状態ではﾊﾟｯﾁ分割時の測定行程表示用ｸﾞﾘｯﾄﾞは非表示
            vsfMeasStepList.Visible = False
        '@↑2017/02/15 (Wed) 17:08:53 T.Oide **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxEN01X6_Init"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbNo_Set
    '機　能：ｵｰﾀﾞｰ番号ｺﾝﾎﾞの設定
    '引　数：llngIndex(1:ﾌｫﾄ、2:ｺﾝﾀｸﾄｴｯﾁｬｰ)
    '戻り値：なし
    '作成日：2006/03/14 (Tue) 13:32:28 N.Kasai
    '更新日：2006/03/14 (Tue) 13:32:28
    '備　考：
    Private Sub prvCmbNo_Set(ByVal llngIndex As Integer)
        
        Dim llngCnt     As Integer 'ｶｳﾝﾀ
        
        Try
            
            '@ｵｰﾀﾞｰ番号ｺﾝﾎﾞ設定
            With cmbNo
                RemoveHandler cmbNo.Change, AddressOf cmbNo_Change
                .Clear
                .ColAlignment(0) = TextAlignEnum.LeftCenter
                .Sort = 1   '昇順
                
                If ptypApcOpStepInfo.strApcTypeNow <> vbNullString Then
                    '@現在選択中のｵｰﾀﾞ番号を表示
                    For llngCnt = 0 To ptypApcOpStepInfo.strListOrderNow.Count -1
                        .AddItem(ptypApcOpStepInfo.strListOrderNow(llngCnt))
                    Next
                    
                Else
                    '@引継ぎ構造体よりｺﾝﾎﾞ内容を設定
                    For llngCnt = 0 To ptypApcOpStepInfo.typApcTypeList(llngIndex -1).lngApcOpStepListCnt -1
                        '@ｵｰﾀﾞｰ番号ｺﾝﾎﾞのﾘｽﾄに追加
                        .AddItem(ptypApcOpStepInfo.typApcTypeList(llngIndex -1).typApcOpStepList(llngCnt).strListOrder)
                    Next
                End If
                
                
                
                '@件数確認
                If .ListCount = 0 Then
                    .Enabled = False
                Else
                    .Enabled = True
                End If
                
                If .ListCount = 1 Then
                    '@初期表示
                    .ListIndex = 0
                    'Call cmbNo_Validate(True)
                    Call cmbNo_Validate(cmbNo, New CancelEventArgs)
                End If
                AddHandler cmbNo.Change, AddressOf cmbNo_Change
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvCmbNo_Set"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbApcType_Set
    '機　能：APCﾀｲﾌﾟｺﾝﾎﾞ設定
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/02 (Fri) 11:29:33 N.Kasai
    '更新日：2006/06/02 (Fri) 11:29:33
    '備　考：
    Private Sub prvCmbApcType_Set()
        
        Dim llngCnt     As Integer 'ｶｳﾝﾀ
        Dim llngIndex   As Integer
        Dim lblnFB      As Boolean
        Dim lblnFF      As Boolean
        
        Try
            
            llngIndex = -1
            
            lblnFB = False
            lblnFF = False
            
            '@APCﾀｲﾌﾟの設定
             With cmbApcType
                .Clear
                .ColAlignment(0) = TextAlignEnum.LeftCenter
                .DispCols = 1   '表示列
                .ValueCol = 1   '値列
                
                '@APC情報取得
                '@APCﾀｲﾌﾟは複数存在する。作成当初はAPCﾀｲﾌﾟはﾕﾆｰｸだよということを前提だったのに・・
                '@重複ﾚｺｰﾄﾞはｺﾝﾎﾞから除外する。（CLのﾃﾞｰﾀとしてはAPC情報を全部欲しいので）
                For llngCnt = 0 To ptypApcAns.lngApcListCnt -1
                    '@APCﾀｲﾌﾟ判定
                    Select Case ptypApcAns.typApcList(llngCnt).strApcType
                        
                        '@F/B
                        Case "1"
                            If lblnFB = False Then
                                .AddItem(CMstrFB & vbTab & _
                                ptypApcAns.typApcList(llngCnt).strApcType & vbTab & _
                                ptypApcAns.typApcList(llngCnt).strProcessWpName)
                                
                                lblnFB = True
                            End If
                        '@F/F
                        Case "2"
                            If lblnFF = False Then
                                .AddItem(CMstrFF & vbTab & _
                                ptypApcAns.typApcList(llngCnt).strApcType & vbTab & _
                                ptypApcAns.typApcList(llngCnt).strProcessWpName)
                            
                                lblnFF = True
                            End If
                    End Select
                Next
                
                
                '@対象APC設定を指定の場合
                Select Case ptypApcOpStepInfo.strApcTypeNow
                    '@F/Bの場合
                    Case "1"
                        llngIndex = 0
                    '@F/Fの場合
                    Case "2"
                        llngIndex = 1
                End Select
                
                '@対象APC設定を指定の場合
                If llngIndex <> -1 Then
                    .ListIndex = llngIndex
                End If
                
                '@APCﾀｲﾌﾟ使用制限
                Select Case .ListIndex
                    Case -1
                        '@ﾃﾞｰﾀ指定なし
                        fraApcType.Enabled = True
                        .BackColor = vbWhite

                        '@ｵｰﾀﾞ番号ｺﾝﾎﾞ使用不可
                        cmbNo.Enabled = False

                    Case Else
                        '@1件のみ表示
                        fraApcType.Enabled = False
                        .BackColor = vbButtonFace
                End Select
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvCmbNo_Set"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraLimitProcess.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfMeasStepList.BeforeDoubleClick

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
        End If

    End Sub

End Class
