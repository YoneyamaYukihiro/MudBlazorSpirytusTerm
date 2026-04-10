'ﾌｧｲﾙ名：xxCM0100.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ステータス表示画面
'作成日：2004/04/22 (Thu) 14:13:19 M.Miura
'更新日：2004/04/22 (Thu) 14:13:19
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM0100
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM0100    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM0100
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM0100
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM0100)
            Dim old_inst As Form
            old_inst = _instance
            _instance = value
            If old_inst IsNot Nothing AndAlso Not old_inst.IsDisposed Then
                old_inst.Close()
                old_inst.Dispose()
            End If
        End Set
    End Property 

    '*******************************************************************************
    '　　　　　　　　　　　　　　 　　* 型の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    Private buttonProcessing                    As Boolean              'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean              'NSYS システムコマンドでの画面クローズ
    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 定数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyCM0100          'ﾛｰｶﾙ機能ID

    '@大きいフォームの設定
    Private Const CMlngFrmBigTop                As Integer = 354                     'ﾌｫｰﾑの開始高さ
    Private Const CMlngFrmBigHeight             As Integer = 414                     'ﾌｫｰﾑの高さ
    Private Const CMlngvsfBigHeight             As Integer = 382                     'ｸﾞﾘｯﾄﾞの高さ
    Private Const CMlngcmdBigHeight             As Integer = 49                      'ﾎﾞﾀﾝの高さ

    '@小さいフォームの設定
    Private Const CMlngFrmSmallTop              As Integer = 673                     'ﾌｫｰﾑの開始高さ
    Private Const CMlngFrmSmallHeight           As Integer = 95                      'ﾌｫｰﾑの高さ
    Private Const CMlngvsfSmallHeight           As Integer = 59                      'ｸﾞﾘｯﾄﾞの高さ
    Private Const CMlngcmdSmallHeight           As Integer = 25                      'ﾎﾞﾀﾝの高さ

    Private Const CMlngcmdTopChange             As Integer = 14                      'ﾎﾞﾀﾝの高さ差分
    Private Const CMlnglblSpaceLeftChange       As Integer = 1                       'ﾗﾍﾞﾙの左差分
    Private Const CMlngZero                     As Integer = 0                       '0

    '@ｽﾃｰﾀｽ画面色設定用
    Private ReadOnly CMlngStBackColor           As Color = SystemColors.ControlLight         '背景色（灰色）
    Private ReadOnly CMlngStForeColor           As Color = Color.Black                       '文字色（黒）

    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 変数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '*******************************************************************************
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
    '                            *イベントハンドラの記述*
    '*******************************************************************************
    '====================================Private====================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/22 (Thu) 14:15:46 M.Miura
    '更新日：2004/04/22 (Thu) 14:15:46
    '備　考：
    Private Sub Form_Load()

        Try
            
            With vsfInfo
                '@ｸﾞﾘｯﾄﾞ初期化
                .Rows.Count = .Rows.Fixed
                
                '@ﾎﾞﾀﾝに最大化ｱｲｺﾝ設定
                cmdSize.Image = picMax.Image
                
                '@ｸﾞﾘｯﾄﾞ背景色設定
                .BackColor = CMlngStBackColor
                .ForeColor = CMlngStForeColor
                
                '@ﾛｯｸ
                cmdUP.Enabled = False
                cmdDown.Enabled = False
            End With
            
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

    '関数名：Form_Deactivate
    '機　能：Form_Deactivate処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/18 (Tue) 16:48:21 H.Wajima
    '更新日：2004/05/18 (Tue) 16:48:21
    '備　考：
    Private Sub Form_Deactivate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Deactivate

        'NSYS この関数は、Form_ActivateApp と連動して動作するので、メンテナンス時は合わせて修正すること

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@自画面の判定
            If Form.ActiveForm Is Me Then
                With Me
                    '@ﾌｫｰﾑのｻｲｽﾞを判定する
                    If .Height > CMlngFrmSmallHeight Then
                    '@大きいとき
                        '@ｻｲｽﾞ変更処理を実行する
                        Call cmdSize_Click(sender,e)
                    End If
                End With
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_Deactivate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ｷｰ制御
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ値
    '戻り値：
    '作成日：2004/04/22 (Thu) 16:55:54 M.Miura
    '更新日：2004/04/22 (Thu) 16:55:54
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@ｸﾞﾘｯﾄﾞｷｰ制御(編成元ﾏｯﾌﾟ)
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfInfo, cmdUP, cmdDown)
            
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
    '機　能：ﾌｫｰﾑｸｴﾘｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 09:28:44 H.Wajima
    '更新日：2004/07/28 (Wed) 09:28:44
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Try

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

    '関数名：cmdUp_Click
    '機　能：前頁処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/22 (Thu) 16:50:49 M.Miura
    '更新日：2004/04/22 (Thu) 16:50:49
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
            
            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理
            Call pubVsfCmdUp(vsfInfo, cmdUP, cmdDown)
            
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
    '機　能：次頁処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/22 (Thu) 16:52:23 M.Miura
    '更新日：2004/04/22 (Thu) 16:52:23
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
            
            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理
            Call pubVsfCmdDown(vsfInfo, cmdUP, cmdDown)
            
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

    '関数名：cmdSize_Click
    '機　能：ｻｲｽﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/23 (Fri) 13:08:33 M.Miura
    '更新日：2004/04/23 (Fri) 13:08:33
    '備　考：
    Private Sub cmdSize_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSize.Click
        Dim llngCnt         As Integer  'ｶｳﾝﾄ
        Dim llngPageRows    As Integer  '頁行数
        Dim llngTopRow 		As Integer  '頁先頭行

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With Me
                If .Height <= CMlngFrmSmallHeight Then
                    '@小さいとき
                    '@大きくする
                    .Top = CMlngFrmBigTop
                    .Left = CMlngZero
                    .Height = CMlngFrmBigHeight

                    '@ｸﾞﾘｯﾄﾞ設定
                    With .vsfInfo
                        .Height = CMlngvsfBigHeight
                    End With
                    '@前頁設定
                    With .cmdUP
                        .Top = CMlngZero +2
                        .Left = Me.vsfInfo.Width +2
                        .Height = CMlngcmdBigHeight
                        .Width = CMlngcmdBigHeight
                    End With
                    '@次頁設定
                    With .cmdDown
                        .Top = Me.vsfInfo.Height - CMlngcmdBigHeight +4
                        .Left = Me.vsfInfo.Width +2
                        .Height = CMlngcmdBigHeight
                        .Width = CMlngcmdBigHeight
                    End With
                    '@ｻｲｽﾞ変更設定
                    With .cmdSize
                        .Image = picMin.Image
                        .Top = CMlngcmdTopChange + CMlngFrmBigHeight - CMlngFrmSmallHeight
                    End With
                Else
                    '@大きいとき
                    '@小さくする
                    .Height = CMlngFrmSmallHeight
                    .Top = CMlngFrmSmallTop
                    .Left = CMlngZero
                    
                    '@ｸﾞﾘｯﾄﾞ設定
                    With .vsfInfo
                        .Height = CMlngvsfSmallHeight
                    End With
                    '@前頁設定
                    With .cmdUP
                        .Top = CMlngZero + 2
                        .Left = Me.vsfInfo.Width + 2
                        .Height = CMlngcmdSmallHeight
                        .Width = CMlngcmdBigHeight
                    End With
                    '@次頁設定
                    With .cmdDown
                        .Top = Me.vsfInfo.Height - CMlngcmdSmallHeight + 4
                        .Left = Me.vsfInfo.Width + 2
                        .Height = CMlngcmdSmallHeight
                        .Width = CMlngcmdBigHeight
                    End With
                    '@ｻｲｽﾞ変更設定
                    With .cmdSize
                        .Image = picMax.Image
                        .Top = CMlngcmdTopChange
                    End With
                End If

                '@ﾗﾍﾞﾙ設定
                .lblSpace.Top = .cmdUP.Top + 1
                .lblSpace.Left = .cmdUP.Left - CMlnglblSpaceLeftChange
                .lblSpace.Height = .cmdDown.Top + .cmdDown.Height -11
                .lblSpace.Width = .cmdUP.Width
                
                With .vsfInfo
                    For llngCnt = CMlngZero To .Rows.Count - 1
                        '@表示
                        .Rows(llngCnt).Visible = True
                    Next llngCnt
                    
                    '@ﾒｯｾｰｼﾞがある場合
                    If .Rows.Count > .Rows.Fixed Then
                        '@頁先頭行設定
                        .TopRow = .Rows.Fixed
                    End If
                
                    '@ﾎﾞﾀﾝﾛｯｸ制御

                    '@頁先頭行取得
                    If .TopRow > 0 Then
                        llngTopRow = .TopRow
                    Else
                        llngTopRow = 0
                    End If

                    '@頁行数取得
                    llngPageRows = publngVsfPageRows_Get(vsfInfo)

                    '@頁切替ﾎﾞﾀﾝがある場合
                    If TypeName(cmdUp) <> "Nothing" Then
                        If .Rows.Fixed >= .Rows.Count Then
                            '@ﾛｯｸ
                            cmdUp.Enabled = False
                        Else
                            If .Rows(.Rows.Fixed).Visible = True Then
                                If llngTopRow = .Rows.Fixed Then
                                    '@ﾛｯｸ
                                    cmdUp.Enabled = False
                                Else
                                    '@ﾛｯｸ解除
                                    cmdUp.Enabled = True
                                End If
                            Else
                                '@ﾛｯｸ解除
                                cmdUp.Enabled = True
                            End If
                        End If
                    End If

                    '@頁切替ﾎﾞﾀﾝがある場合
                    If TypeName(cmdDown) <> "Nothing" Then
                        If llngTopRow + llngPageRows >= .Rows.Count Then
                            '@ﾛｯｸ
                            cmdDown.Enabled = False
                        Else
                            '@ﾛｯｸ解除
                            cmdDown.Enabled = True
                        End If
                    End If
                End With
            End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSize_Click"
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

    '関数名：CreateParams
    '機　能：Alt+F4の無効化
    '引　数：なし
    '戻り値：コントロール生成時のパラメーター
    '作成日：2019/06/08 (Sat) 12:00:00 NSYS
    '更新日：
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const CS_NOCLOSE As Integer = &H200

            Dim cParams As System.Windows.Forms.CreateParams = MyBase.CreateParams
            cParams.ClassStyle = cParams.ClassStyle Or CS_NOCLOSE

            Return cParams
        End Get
    End Property

    '関数名：vsfInfo_GotFocus
    '機　能：グリッドフォーカス取得時処理
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/06/19 (Wed) 11:00:00 NSYS
    '更新日：
    Private Sub vsfInfo_GotFocus(ByVal sender As Object, ByVal e As  EventArgs) Handles vsfInfo.GotFocus,vsfInfo.SelChange
        Const CMlngStErrForeColor As Integer = &HFF '赤

        With vsfInfo
            If .Row < 0 Then
                Exit Sub
            End If

            ' ハイライトの前景色設定
            If .GetCellRange(.Row, CMlngZero).StyleDisplay.ForeColor = ColorTranslator.FromWin32(CMlngStErrForeColor) Then
                .Styles.Highlight.ForeColor = ColorTranslator.FromWin32(CMlngStErrForeColor)
            Else
                .Styles.Highlight.ForeColor = CMlngStForeColor
            End If
        End With
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
                lblnWMClose = True

        End Select

        MyBase.WndProc(m)

        If lblnSysCommandScClose = True Then
            'NSYS SC_CLOSE 処理後 WM_CLOSE が発生しないでキャンセルされることもあるため、フラグを戻す
            'NSYS WM_CLOSE が発生していれば、すでにこの時点では画面は閉じている
            mblnCloseFromControlMenu = False
        End If
    End Sub

    '関数名：Form_ActivateApp
    '機　能：WindowsメッセージのWM_ACTIVATEAPPを処理する。Deactivate同等の処理を行う
    '引　数：m：Windowsメッセージ
    '戻り値：なし
    '作成日：2019/06/21 (Fri) 12:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub Form_ActivateApp(m As Message)

        'NSYS この関数は、Form_Deactivate と連動して動作するので、メンテナンス時は合わせて修正すること

        'NSYS wParam: TRUE if the window is being activated; FALSE if the window is being deactivated.
        'NSYS アプリとしてはアクティブ化されたが、アクティブ化したフォームは自分以外の場合、
        '     Deactivate と同じ動作をする (VB6互換)
        If m.WParam.ToInt64 <> 0 AndAlso Form.ActiveForm IsNot Me Then

            With Me
                '@ﾌｫｰﾑのｻｲｽﾞを判定する
                If .Height > CMlngFrmSmallHeight Then
                '@大きいとき
                    '@ｻｲｽﾞ変更処理を実行する
                    Call cmdSize_Click(cmdSize, EventArgs.Empty)
                End If
            End With
        End If
    End Sub
    
End Class
