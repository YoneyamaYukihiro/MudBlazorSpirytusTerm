'ﾌｧｲﾙ名：xxMN0002.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：お知らせ画面
'作成日：2004/05/06 (Thu) 15:39:05 H.Wajima
'更新日：2017/03/31 (Fri) 16:04:37 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2017, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxMN0002
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxMN0002    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxMN0002
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxMN0002
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxMN0002)
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
    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 定数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrFormMN0000         'ﾛｰｶﾙ機能ID
    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrutilfuncinfo_Ver             As String = "01.00"                 'ﾒﾆｭｰお知らせ取得
    '@その他
    Private Const CMlngMaxDispRow                   As Integer = 23                     'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数


    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 変数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    Private buttonProcessing                        As Boolean                          'NSYS ボタン2度押し対策
    '*******************************************************************************
    '　　　　　　　　　　　　　      * ＡＰＩの記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 関数の記述 *
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
    '　　　　　　　　　　　　　* イベントハンドラの記述 *
    '*******************************************************************************
    '関数名：Form_Load
    '機　能：Form_Load処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/06 (Thu) 15:40:03 H.Wajima
    '更新日：2005/08/26 (Fri) 10:58:53 N.Kojima
    '備　考：
    '　　　：2004/09/07 (Tue) 21:15:37 H.Wajima     ﾊﾞｰｼﾞｮﾝ番号を画面に復活
    '　　　：2005/08/26 (Fri) 10:58:53 N.Kojima     ﾊﾞｰｼﾞｮﾝ番号の振り方変更(X.XX.XXXX→X.XXX.XX)
    Private Sub Form_Load()

        Try
            
            With Me
                '@ﾌｫｰﾑの初期化を行う
                '@ﾌｫｰﾑの位置を初期化
                .Top = 0
                .Left = 0 - My.Settings.FormOffset
                '@ﾌｫｰﾑの幅を初期化
                .Width = CPlngAppliWideWidth
                '@ﾌｫｰﾑの高さを初期化
                .Height = CPlngAppliHeight
            End With
            
            With txtInfo
                .Locked = True
                .GotHighLight = False
                .MultiLineEx = True
            End With
            
        '@↓2005/08/26 (Fri) 10:57:52 N.Kojima **************************************************
        '@Versionの表記方法変更　X.XX.XXXX→X.XXX.XXに変更
        '    '@ﾊﾞｰｼﾞｮﾝ番号の取得
        '    lblVersion.Caption = CPstrAppVer & App.Major & _
        '                        CPstrAppVerPeriod & Format$(App.Minor, "00") & _
        '                        CPstrAppVerPeriod & Format$(App.Revision, "0000")
            '@ﾊﾞｰｼﾞｮﾝ番号の取得
            lblVersion.Text = CPstrAppVer & CStr(My.Application.Info.Version.Major) & _
                          CPstrAppVerPeriod & Format$(My.Application.Info.Version.Minor, "000") & _
                          CPstrAppVerPeriod & Format$(My.Application.Info.Version.MinorRevision, "00")
        '@↑2005/08/26 (Fri) 10:57:52 N.Kojima **************************************************
            
            '@お知らせの取得
            Call prvInformation_Disp()
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True

            'NSYS ラベルを重ねて表示するため、白ラベルを親にする
            lblTitle.Parent = lblTitle2

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

    '関数名：prvInformation_Disp
    '機　能：お気に入り表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/21 (Wed) 09:38:51 H.Wajima
    '更新日：2008/02/25 (Mon) 16:52:57 M.Koni
    '備　考：
    '　　　：2008/02/25 (Mon) 16:53:14 M.Koni       Environ関数の型変換対応。(不具合No.02510)
    Private Sub prvInformation_Disp()

        Dim lstrFormName                As String           'ﾌｫｰﾑ名
        Dim lstrEventName               As String           'ｲﾍﾞﾝﾄ名
        Dim lblnReturn                  As Boolean          '戻り値領域
        Dim lstrLoginID                 As String           'ﾛｸﾞｲﾝID
        Dim lstrInformation             As String           'お知らせ

        Try
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "prvInformation_Disp"
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@ﾛｸﾞｲﾝﾕｰｻﾞｰ名を取得する
            lstrLoginID = StrConv(Environ(CPstrEnvironUserName), vbLowerCase + vbNarrow)

            '@お知らせ情報の取得
            lblnReturn = pubblnUtilInformation_Sel(CMstrutilfuncinfo_Ver, pstrSBID, pstrTerminalMode, lstrInformation)

            '戻り値の判定
            If lblnReturn = True Then
                '@正常終了した場合
                '@お知らせを画面に表示する
                txtInfo.Text = lstrInformation
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
            Else
                '@異常終了した場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvInformation_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：▲ﾎﾞﾀﾝｸﾘｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/26 (Mon) 09:29:07 H.Wajima
    '更新日：2005/11/21 (Mon) 12:53:20 N.Kasai
    '備　考：
    '　　　：2005/11/21 (Mon) 12:53:20 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/11/21 (Mon) 12:53:13 N.Kasai **************************************************
        '    '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtInfo)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtInfo, CMlngMaxDispRow, cmdUP, cmdDown)
            
        '@↑2005/11/21 (Mon) 12:53:13 N.Kasai **************************************************
            
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
    '機　能：▼ﾎﾞﾀﾝｸﾘｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/26 (Mon) 09:29:13 H.Wajima
    '更新日：2005/11/21 (Mon) 12:55:01 N.Kasai
    '備　考：
    '　　　：2005/11/21 (Mon) 12:55:01 N.Kasai      ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/11/21 (Mon) 12:54:52 N.Kasai **************************************************
        '    '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtInfo)
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtInfo, CMlngMaxDispRow, cmdUP, cmdDown)
            
        '@↑2005/11/21 (Mon) 12:54:52 N.Kasai **************************************************
            
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

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｸｴﾘｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 10:02:58 H.Wajima
    '更新日：2004/07/28 (Wed) 10:02:58
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

    '関数名：txtInfo_Change
    '機　能：ﾃｷｽﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/21 (Mon) 12:57:22 N.Kasai
    '更新日：2005/11/21 (Mon) 12:57:22
    '備　考：
    Private Sub txtInfo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtInfo.Change

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtInfo, CMlngMaxDispRow, cmdUP, cmdDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtInfo_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtInfo_KeyUp
    '機　能：ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2005/11/21 (Mon) 12:58:43 N.Kasai
    '更新日：2005/11/21 (Mon) 12:58:43
    '備　考：
    Private Sub txtInfo_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtInfo.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtInfo, CMlngMaxDispRow, cmdUP, cmdDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtInfo_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtInfo_MouseUp
    '機　能：ﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/21 (Mon) 13:01:03 N.Kasai
    '更新日：2005/11/21 (Mon) 13:01:03
    '備　考：
    Private Sub txtInfo_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtInfo.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtInfo, CMlngMaxDispRow, cmdUP, cmdDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtInfo_MouseUp"
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
    '機　能：画面移動不可
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/06 (Mon) 18:00:00 NSYS
    '更新日：
    '備　考：
    <SecurityPermission(SecurityAction.Demand, 
    Flags:=SecurityPermissionFlag.UnmanagedCode)> _
    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_SYSCOMMAND As Integer = &H112
        Const SC_MOVE As Long = &HF010L

        If m.Msg = WM_SYSCOMMAND AndAlso _
            (m.WParam.ToInt64() And &HFFF0L) = SC_MOVE Then
            m.Result = IntPtr.Zero
            Return
        End If

        MyBase.WndProc(m)
    End Sub

    ' Alt+F4の無効化
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const CS_NOCLOSE As Integer = &H200

            Dim cParams As System.Windows.Forms.CreateParams = MyBase.CreateParams
            cParams.ClassStyle = cParams.ClassStyle Or CS_NOCLOSE

            Return cParams
        End Get
    End Property

End Class
