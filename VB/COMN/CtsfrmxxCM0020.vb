'ﾌｧｲﾙ名：xxCM0020.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力画面
'作成日：2006/11/28 (Tue) 10:29:35 T.Kitagawa
'更新日：2008/04/22 (Tue) 21:06:36 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM0020
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM0020    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM0020
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM0020
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM0020)
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
    '====================================Private============================================
    '@機能ID
    Private Const CMstrLocalMenuKey             As String = "frmxxCM0020"       'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_empname_Ver           As String = "02.01"             '作業者名取得

    '@ﾊﾟｽﾜｰﾄﾞﾃｷｽﾄBOX
    Private Const CMlngPasswdMaxLength          As Integer = 10                 'ﾊﾟｽﾜｰﾄﾞの最大文字数
    Private Const CMstrPasswdChar               As String = "*"                 'ﾊﾟｽﾜｰﾄﾞの表示文字

    '@ﾊﾟｽﾜｰﾄﾞ文字制限
    Private Const CMlngKeyBackSpace             As Integer = 8                  'ﾊﾞｯｸｽﾍﾟｰｽのｱｽｷｰｺｰﾄﾞ
    Private Const CMlngKeyReturn                As Integer = 13                 'ｴﾝﾀｰｷｰのｱｽｷｰｺｰﾄﾞ
    Private Const CMlngKeyAscSpace              As Integer = 32                 'ｱｽｷｰｺｰﾄﾞ-ｽﾍﾟｰｽ
    Private Const CMlngKeyAsciiLimit            As Integer = 126                'ｱｽｷｰｺｰﾄﾞ半角文字制限(記号可の場合)

    '@ﾊﾟｽﾜｰﾄﾞｴﾗｰﾌﾗｸﾞ
    Private Const CMstrPasswdErrorFlagOK        As String = "0"                 'ﾊﾟｽﾜｰﾄﾞ確認の正常値
    Private Const CMstrPasswdErrorFlagNG        As String = "1"                 'ﾊﾟｽﾜｰﾄﾞ確認の異常値

    '@ﾊﾟｽﾜｰﾄﾞのEncode/Decode化定数
    Private Const CMstrEncode                   As String = "ENC"               'ﾊﾟｽﾜｰﾄﾞ変換(Encode化)
    Private Const CMstrDecode                   As String = "DEC"               'ﾊﾟｽﾜｰﾄﾞ変換(Decode化)

    '@表示ﾒｯｾｰｼﾞ
    Private Const CMstrUserIDTitle              As String = "作業者ID"          '作業者ID表示
    Private Const CMstrPasswdTitle              As String = "パスワード"        'ﾊﾟｽﾜｰﾄﾞ表示

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    Private mblnFormLoadFlag                        As Boolean                  'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True:ﾛｰﾄﾞ中、False:ﾛｰﾄﾞ終了)

    Private buttonProcessing                        As Boolean                  'NSYS ボタン2度押し対策

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
        txtPasswd.Tag = New Hashtable() From {{"OnHighlight", False}, {"MouseDownStart", 0}}
        Form_Load()
        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　Load処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/11/28 (Tue) 10:34:28 T.Kitagawa
    '更新日：2008/04/22 (Tue) 21:06:56 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 21:06:56 N.Kojima     ｿｰｽ整備、所属ｸﾞﾙｰﾌﾟIDの初期化処理追加。(案件№02786)
    Private Sub Form_Load()

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞのON
            mblnFormLoadFlag = True
            
            '@ﾊﾟﾌﾞﾘｯｸ変数の初期化
            pstrUserID = vbNullString               'ﾕｰｻﾞｰID
            pstrUserName = vbNullString             'ﾕｰｻﾞｰ名称
            pstrDeptID = vbNullString               '所属ID
            pstrDeptName = vbNullString             '所属名称
            pstrGroupID = vbNullString              '所属ｸﾞﾙｰﾌﾟID
            
            '@ﾊﾟﾌﾞﾘｯｸ変数：戻り値の初期化
            pblnCancel = True
            
            '@個人ｺｰﾄﾞﾃｷｽﾄﾎﾞｯｸｽのﾌﾟﾛﾊﾟﾃｨｾｯﾄ
            With txtUserID
                .Text = vbNullString                                                'ﾕｰｻﾞｰID入力欄
                .FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num      'ｱﾙﾌｧﾍﾞｯﾄ＆数字
                .ChrMaxByte = CPlngEmpIDLength                                      '最大7桁
                .ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper       '半角大文字
            End With
            
            '@ﾊﾟｽﾜｰﾄﾞﾃｷｽﾄﾎﾞｯｸｽのﾌﾟﾛﾊﾟﾃｨｾｯﾄ
            With txtPasswd
                .Text = vbNullString                'ﾊﾟｽﾜｰﾄﾞ入力欄
                .MaxLength = CMlngPasswdMaxLength   '最大10桁
                .PasswordChar = CMstrPasswdChar     'ﾊﾟｽﾜｰﾄﾞ表示文字："*"
            End With
            
            '@確定ﾎﾞﾀﾝを無効にする
            cmdRegist.Enabled = False
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞのON
            mblnFormLoadFlag = False
            
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
    '機　能：ﾌｫｰﾑ　ｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2006/11/28 (Tue) 11:13:59 T.Kitagawa
    '更新日：2008/04/22 (Tue) 21:11:11 N.Kojima
    '備　考：
    '　　　：2006/12/25 (Mon) 12:09:19 T.Kitagawa　 ﾊﾟｽﾜｰﾄﾞ欄にてEnter時は確定処理とみなす(案件№1691)
    '　　　：2008/04/22 (Tue) 21:11:11 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Try
            
            '@以下の条件の場合、ｷｰｺｰﾄﾞを無効にし処理抜け
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                e.Handled = True
                Exit Sub
            End If

            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name
                
                '@〓 ﾊﾟｽﾜｰﾄﾞ 〓
                Case txtPasswd.Name
                    '@ｷｰｺｰﾄﾞがEnterｷｰか
                    Select Case e.KeyCode
                        '@Enterｷｰ
                        Case Keys.Return
                        
                            '@=======================
                            '@　確定実行処理
                            '@=======================
                            Call cmdRegist_Click(cmdRegist, New EventArgs)
                    End Select
                
                '@〓 その他 〓
                Case Else
                    '@ｷｰｺｰﾄﾞがEnterｷｰか
                    Select Case e.KeyCode
                        '@Enterｷｰ
                        Case Keys.Return
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

    '関数名：Form_KeyPress
    '機　能：ﾌｫｰﾑ　押下ｷｰ処理
    '引　数：KeyAscii   ：ｱｽｷｰｷｰｺｰﾄﾞ
    '戻り値：なし
    '作成日：2006/11/28 (Tue) 11:13:59 T.Kitagawa
    '更新日：2008/04/22 (Tue) 21:16:05 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 21:16:05 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub Form_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles MyBase.KeyPress
        
        Try
            
            '@***************************
            '@　全角の入力を制御(記号可)
            '@***************************
            
            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name
            
                '@〓 ﾊﾟｽﾜｰﾄﾞ 〓
                Case txtPasswd.Name
                    
                    '@ﾊﾟｽﾜｰﾄﾞの場合
                    Select Case Asc(e.KeyChar)
                        '@ｱｽｷｰｷｰｺｰﾄﾞの判定
                        Case CMlngKeyBackSpace To CMlngKeyReturn
                            '@制御文字
                            
                        Case CMlngKeyAscSpace To CMlngKeyAsciiLimit
                            '@[SPACE]-[~]
                        
                        Case Else
                            '@[SPACE]-[~]以外の場合
                            e.Handled = True 'ｷｰ無効
                    End Select
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_KeyPress"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑ　終了時処理
    '引　数：Cancel     ：ｷｬﾝｾﾙ
    '　　　：UnloadMode ：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2006/11/28 (Tue) 13:29:27 T.Kitagawa
    '更新日：2008/04/22 (Tue) 21:18:01 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 21:18:01 N.Kojima     ｿｰｽ整備、所属ｸﾞﾙｰﾌﾟIDの初期化処理追加。(案件№02786)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            
            '@ﾊﾟﾌﾞﾘｯｸ変数の初期化処理
            If pblnCancel = True Then
                pstrUserID = vbNullString           'ﾕｰｻﾞｰID
                pstrUserName = vbNullString         'ﾕｰｻﾞｰ名称
                pstrDeptID = vbNullString           '所属ID
                pstrDeptName = vbNullString         '所属名称
                pstrGroupID = vbNullString          '所属ｸﾞﾙｰﾌﾟID
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

    '関数名：txtUserID_Change
    '機　能：作業者IDﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/11/29 (Wed) 13:17:47 T.Kitagawa
    '更新日：2008/04/22 (Tue) 21:26:07 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 21:26:07 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub txtUserID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtUserID.Change

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞ中は処理中止
            If mblnFormLoadFlag = True Then
                Exit Sub
            End If
            
            '@=======================
            '@　ｺﾏﾝﾄﾞﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvcmdEnable_Set()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtUserID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtPasswd_Change
    '機　能：ﾊﾟｽﾜｰﾄﾞﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/11/29 (Wed) 13:18:58 T.Kitagawa
    '更新日：2008/04/22 (Tue) 21:27:47 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 21:27:47 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub txtPasswd_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtPasswd.TextChanged

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞ中は処理中止
            If mblnFormLoadFlag = True Then
                Exit Sub
            End If
            
            '@=======================
            '@　ｺﾏﾝﾄﾞﾎﾞﾀﾝ制御
            '@=======================
            Call prvcmdEnable_Set()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPasswd_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtPasswd_GotFocus
    '機　能：ﾊﾟｽﾜｰﾄﾞﾃｷｽﾄ　ﾌｫｰｶｽ取得時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/11/29 (Wed) 14:11:04 T.Kitagawa
    '更新日：2008/04/22 (Tue) 21:27:03 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 21:27:03 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub txtPasswd_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtPasswd.Enter
        
        Try
            
            '@=======================
            '@　ﾊｲﾗｲﾄ処理
            '@=======================
            Call pubHighlight(txtPasswd)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPasswd_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：確定ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/11/28 (Tue) 16:46:07 T.Kitagawa
    '更新日：2008/04/22 (Tue) 21:19:28 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 21:19:28 N.Kojima     ｿｰｽ整備、作業者情報取得処理の引数にｸﾞﾙｰﾌﾟID追加。(案件№02786)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnAns                 As Boolean  '戻り値
        Dim lstrPasswdEncode        As String   'ﾊﾟｽﾜｰﾄﾞ(Encode化済)
        Dim lstrPasswdErrorFlag     As String   'ﾊﾟｽﾜｰﾄﾞｴﾗｰﾌﾗｸﾞ
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾕｰｻﾞｰIDをﾊﾟﾌﾞﾘｯｸ変数にｾｯﾄ
            pstrUserID = txtUserID.Text
                
            '@ﾕｰｻﾞIDがNULLか
            If pstrUserID = vbNullString Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0095, CMstrUserIDTitle)
                '@"<TRM95W>$$[作業者ID]を入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@念の為、各Public変数を初期化
                pstrUserName = vbNullString     'ﾕｰｻﾞｰ名
                pstrDeptID = vbNullString       '職場ID
                pstrDeptName = vbNullString     '職場名
                pstrGroupID = vbNullString      '所属ｸﾞﾙｰﾌﾟID
                
                '@作業者IDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtUserID)
                Exit Sub
            End If
            
            '@ﾕｰｻﾞｰID桁ﾁｪｯｸ(7桁)
            If Len(pstrUserID) <> CPlngEmpIDLength Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003K, CMstrUserIDTitle)
                '@"<TRM3KW>$$[作業者ｺｰﾄﾞ]は7桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@念の為、各Public変数を初期化
                pstrUserName = vbNullString     'ﾕｰｻﾞｰ名
                pstrDeptID = vbNullString       '職場ID
                pstrDeptName = vbNullString     '職場名
                pstrGroupID = vbNullString      '所属ｸﾞﾙｰﾌﾟID
                
                '@作業者IDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtUserID)
                Exit Sub
            End If

            '@ﾊﾟｽﾜｰﾄﾞがNULLか
            If txtPasswd.Text = vbNullString Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0095, CMstrPasswdTitle)
                '@"<TRM95W>$$[ﾊﾟｽﾜｰﾄﾞ]を入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@念の為、各Public変数を初期化
                pstrUserName = vbNullString     'ﾕｰｻﾞｰ名
                pstrDeptID = vbNullString       '職場ID
                pstrDeptName = vbNullString     '職場名
                pstrGroupID = vbNullString      '所属ｸﾞﾙｰﾌﾟID
                
                '@ﾊﾟｽﾜｰﾄﾞにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtPasswd)
                Exit Sub
            End If
            
            '@ﾊﾟｽﾜｰﾄﾞのEncode化
            lstrPasswdEncode = prvstrPassWdEncDec_Set(CMstrEncode, txtPasswd.Text)
            
            '@【作業者名取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnMasEmpName_Sel(CMstrmas_empname_Ver, _
                                           pstrUserID, _
                                           pstrUserName, _
                                           pstrDeptID, _
                                           pstrDeptName, _
                                           pstrGroupID, _
                                           vbNullString, _
                                           vbNullString, _
                                           vbNullString, _
                                           vbNullString, _
                                           vbNullString, _
                                           lstrPasswdEncode, _
                                           lstrPasswdErrorFlag)

            '@通信結果判定
            If lblnAns = True Then
                '@結果：正常の場合
                
                '@ﾊﾟｽﾜｰﾄﾞｴﾗｰ確認
                If lstrPasswdErrorFlag = CMstrPasswdErrorFlagNG Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0096, CMstrPasswdTitle)
                    '@"<TRM96W>$$[ﾊﾟｽﾜｰﾄﾞ]が違います。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@各Public変数を初期化
                    pstrUserID = vbNullString       'ﾕｰｻﾞｰID
                    pstrUserName = vbNullString     'ﾕｰｻﾞｰ名
                    pstrDeptID = vbNullString       '職場ID
                    pstrDeptName = vbNullString     '職場名
                    pstrGroupID = vbNullString      '所属ｸﾞﾙｰﾌﾟID
                
                    '@ﾊﾟｽﾜｰﾄﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtPasswd)
                    Exit Sub
                
                Else
                    '@ﾊﾟｽﾜｰﾄﾞ確認が正常の場合
                    '@ｷｬﾝｾﾙﾌﾗｸﾞをFlseにして正常終了する
                    pblnCancel = False
                End If
            Else
                '@結果：異常の場合
                
                '@各Public変数を初期化
                pstrUserID = vbNullString       'ﾕｰｻﾞｰID
                pstrUserName = vbNullString     'ﾕｰｻﾞｰ名
                pstrDeptID = vbNullString       '職場ID
                pstrDeptName = vbNullString     '職場名
                pstrGroupID = vbNullString      '所属ｸﾞﾙｰﾌﾟID
                
                '@作業者IDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtUserID)
                Exit Sub
            End If
            
            '@∇∇∇∇∇∇∇∇∇
            '@　ｱﾝﾛｰﾄﾞ処理
            '@∇∇∇∇∇∇∇∇∇
            Me.Close()
            
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

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/13 (Fri) 13:00:00 K.Takano
    '更新日：2008/04/22 (Tue) 21:25:00 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 21:25:00 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@∇∇∇∇∇∇∇∇∇
            '@　ｱﾝﾛｰﾄﾞ処理
            '@∇∇∇∇∇∇∇∇∇
            Me.Close()
            
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

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：prvcmdEnable_Set
    '機　能：ｺﾏﾝﾄﾞﾎﾞﾀﾝ制御処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/11/29 (Wed) 13:26:12 T.Kitagawa
    '更新日：2008/04/22 (Tue) 21:28:31 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 21:28:31 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub prvcmdEnable_Set()

        Try

            '@作業者IDが7桁、ﾊﾟｽﾜｰﾄﾞが1桁以上か
            If Len(txtUserID.Text) = CPlngEmpIDLength And _
                Len(txtPasswd.Text) > 0 Then
                
                '@確定ﾎﾞﾀﾝ有効
                cmdRegist.Enabled = True
            Else
                '@確定ﾎﾞﾀﾝ無効
                cmdRegist.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmdEnable_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvstrPassWdEncDec_Set
    '機　能：ﾊﾟｽﾜｰﾄﾞ暗号化(Encode)・復号化(Decode)処理
    '引　数：lstrFunc       ：ENC/暗号化、DEC/復号化
    '　　　：lstrPasswdwd   ：暗号化・復号化するﾊﾟｽﾜｰﾄﾞ
    '戻り値：String         ：暗号化・復号化したﾊﾟｽﾜｰﾄﾞ
    '作成日：2006/11/29 (Wed) 15:19:33 T.Kitagawa
    '更新日：2008/04/22 (Tue) 21:29:41 N.Kojima
    '備　考：仕様ﾏｽﾀ側も同ﾛｼﾞｯｸ使用
    '　　　：--◆暗号化・復号化の説明◆-----------------------------------------------------------------------------
    '　　　：1.有効な文字は半角英数記号。(ASCIIｺｰﾄﾞ 33「!」～126「~」)
    '　　　：2.暗号化・復号化は文字列を逆順に１文字づつ抽出し処理する。
    '　　　：3.暗号化は抽出文字をASCIIｺｰﾄﾞに変換して、そのASCIIｺｰﾄﾞに"+8"をする。
    '　　　：4.復号化は抽出文字をASCIIｺｰﾄﾞに変換して、そのASCIIｺｰﾄﾞに"-8"をする。
    '　　　：5.暗号化して有効な範囲を上回った場合はASCIIｺｰﾄﾞの数値を補正する。
    '　　　：例)「w」(ASCIIｺｰﾄﾞ=119)を暗号化した場合、通常はASCIIｺｰﾄﾞ=127となるが
    '　　　：　　有効な範囲の「~」(ASCIIｺｰﾄﾞ=126)を上回ったので数値の補正を行い「!」(ASCIIｺｰﾄﾞ=33)とする。
    '　　　：　　※イメージ的には「125→126→33→34．．．」というように変わっていきます。
    '　　　：6.復号化して有効な範囲を下回った場合はASCIIｺｰﾄﾞの数値を補正する。
    '　　　：例)「(」(ASCIIｺｰﾄﾞ=40)を復号化した場合、通常はASCIIｺｰﾄﾞ=32となるが
    '　　　：　　有効な範囲の「!」(ASCIIｺｰﾄﾞ=33)を下回ったので数値の補正を行い「~」(ASCIIｺｰﾄﾞ=126)とする。
    '　　　：　　※イメージ的には「34→33→126→125．．．」というように変わっていきます。
    '　　　：7.暗号化の例外として抽出文字が「}」(ASCIIｺｰﾄﾞ=125)の場合、抽出文字をASCIIｺｰﾄﾞに変換して"+52"をする。
    '　　　：　→　強制的に「ｱ」(ASCIIｺｰﾄﾞ=177)へと変換
    '　　　：　　※抽出文字が「}」(ASCIIｺｰﾄﾞ=125)の場合、通常の暗号化を行うと「'」(ASCIIｺｰﾄﾞ=39)に変換されてしまい
    '　　　：　　　そのままDBへINSERTしようとするとエラーが発生するので､それを回避するための処理｡
    '　　　：8.復号化の例外として抽出文字が「ｱ」(ASCIIｺｰﾄﾞ=177)の場合、抽出文字をASCIIｺｰﾄﾞに変換して"-52"をする。
    '　　　：　→　強制的に「}」(ASCIIｺｰﾄﾞ=125)へと変換
    '　　　：　　※7.でエラー回避した変換文字を元に戻すための処理｡
    '　　　：-----------------------------------------------------------------------------------------------------
    '　　　：2008/04/22 (Tue) 21:29:41 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Function prvstrPassWdEncDec_Set(ByRef lstrFunc As String, ByRef lstrPasswd As String) As String

        Try
            
            Dim lstrChgPassWd    As String      '暗号化・復号化したﾊﾟｽﾜｰﾄﾞ
            Dim llngCnt         As Integer      'ｶｳﾝﾀ

            '@戻り値の設定
            prvstrPassWdEncDec_Set = vbNullString
            
            '@初期化
            lstrChgPassWd = vbNullString     '暗号化・復号化したﾊﾟｽﾜｰﾄﾞ
            
            '@ﾊﾟﾗﾒｰﾀの判定
            Select Case UCase(lstrFunc)
            
                Case CMstrEncode
                    
                    '@"ENC"の場合
                    For llngCnt = Len(lstrPasswd) To 1 Step -1
                        '@ﾊﾟﾗﾒｰﾀ文字列を逆順に1文字づつ抽出。
                    
                        '@抽出文字のﾁｪｯｸ
                        If Asc(Mid(lstrPasswd, llngCnt, 1)) <> 125 Then
                            '@ASCIIｺｰﾄﾞ変換後の抽出文字が「}」以外の場合
                            
                            '@ASCIIｺｰﾄﾞのﾁｪｯｸ
                            If Asc(Mid(lstrPasswd, llngCnt, 1)) + 8 > 126 Then
                                '@抽出文字をASCIIｺｰﾄﾞに変換し、"8"を足した数が有効範囲を上回った場合
                                
                                '@抽出文字をASCIIｺｰﾄﾞに変換し、そのASCIIｺｰﾄﾞから"86"を引く。(ASCIIｺｰﾄﾞの補正)
                                lstrChgPassWd = lstrChgPassWd & Chr(Asc(Mid(lstrPasswd, llngCnt, 1)) - 86)
                            Else
                                '@抽出文字をASCIIｺｰﾄﾞに変換し、"8"を足した数が有効範囲を上回っていない場合
                                
                                '@抽出文字をASCIIｺｰﾄﾞに変換し、そのASCIIｺｰﾄﾞに"8"を足す。
                                lstrChgPassWd = lstrChgPassWd & Chr(Asc(Mid(lstrPasswd, llngCnt, 1)) + 8)
                            End If
                        Else
                            '@ASCIIｺｰﾄﾞ変換後の抽出文字が「}」の場合
                            
                            '@抽出文字をASCIIｺｰﾄﾞに変換し、そのASCIIｺｰﾄﾞに"52"を足す。(強制的に「ｱ」へと変換する)
                            lstrChgPassWd = lstrChgPassWd & Chr(Asc(Mid(lstrPasswd, llngCnt, 1)) + 52)
                        End If
                    Next llngCnt

                Case CMstrDecode
                    
                    '@"DEC"の場合
                    For llngCnt = Len(lstrPasswd) To 1 Step -1
                        '@ﾊﾟﾗﾒｰﾀ文字列を逆順に１文字づつ抽出。
                        
                        '@抽出文字のﾁｪｯｸ
                        If Asc(Mid(lstrPasswd, llngCnt, 1)) <> 177 Then
                            '@ASCIIｺｰﾄﾞ変換後の抽出文字が[ｱ]以外の場合
                            
                            '@ASCIIｺｰﾄﾞのﾁｪｯｸ
                            If Asc(Mid(lstrPasswd, llngCnt, 1)) - 8 < 33 Then
                                '@抽出文字をASCIIｺｰﾄﾞに変換し、"8"を引いた数が有効範囲を下回った場合
                                
                                '@抽出文字をASCIIｺｰﾄﾞに変換し、そのASCIIｺｰﾄﾞに"86"を足す。(ASCIIｺｰﾄﾞの補正)
                                lstrChgPassWd = lstrChgPassWd & Chr(Asc(Mid(lstrPasswd, llngCnt, 1)) + 86)
                            Else
                                '@抽出文字をASCIIｺｰﾄﾞに変換し、"8"を引いた数が有効範囲を下回っていない場合
                                
                                '@抽出文字をASCIIｺｰﾄﾞに変換し、そのASCIIｺｰﾄﾞから"8"を引く。
                                lstrChgPassWd = lstrChgPassWd & Chr(Asc(Mid(lstrPasswd, llngCnt, 1)) - 8)
                            End If
                        Else
                            '@ASCIIｺｰﾄﾞ変換後の抽出文字が[ｱ]の場合
                            
                            '@抽出文字をASCIIｺｰﾄﾞに変換し、そのASCIIｺｰﾄﾞから"52"を引く。(強制的に「}」へと変換する)
                            lstrChgPassWd = lstrChgPassWd & Chr(Asc(Mid(lstrPasswd, llngCnt, 1)) - 52)
                        End If
                    Next llngCnt
            End Select

            '@変換・復元後ﾊﾟｽﾜｰﾄﾞを戻り値に設定
            prvstrPassWdEncDec_Set = lstrChgPassWd

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvstrPassWdEncDec_Set"
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

    '関数名：textbox_Enter
    '機　能：ハイライト処理用 フォーカス取得イベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub textbox_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles txtPasswd.Enter
        'NSYS フォーカスインでハイライト処理 開始
        sender.ScrollToCaret()
        If (sender.MouseButtons And MouseButtons.Left) = MouseButtons.Left Then
            sender.Tag("OnHighlight") = True
        Else
            sender.Tag("OnHighlight") = False
        End If
    End Sub

    '関数名：textbox_Leave
    '機　能：ハイライト処理用 フォーカス喪失イベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考
    Private Sub textbox_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtPasswd.Leave
        'NSYS マウス選択でのハイライトをキャンセルする
        sender.Tag("OnHighlight") = False
    End Sub

    '関数名：textbox_KeyUp
    '機　能：ハイライト処理用 キーアップイベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考
    Private Sub textbox_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtPasswd.KeyUp
        'NSYS Tabキー押下の場合
        If e.KeyCode = Keys.Tab Then
            'NSYS マウス選択でのハイライトをキャンセルする
            sender.Tag("OnHighlight") = False
        End If
    End Sub

    '関数名：textbox_MouseDown
    '機　能：ハイライト処理用 マウスダウンイベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub textbox_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtPasswd.MouseDown
        'NSYS MouseDown時のカーソル位置を保持
        sender.Tag("MouseDownStart") = sender.SelectionStart
    End Sub

    '関数名：textbox_MouseUp
    '機　能：ハイライト処理用 マウスアップイベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub textbox_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtPasswd.MouseUp
        Dim curpos As Integer   'NSYS ｶｰｿﾙ位置

        '@ﾊｲﾗｲﾄするになっている場合
        If CBool(sender.Tag("OnHighlight")) = True Then
            ''@ｶｰｿﾙ位置までﾊｲﾗｲﾄ表示
            curpos = sender.SelectionStart
            sender.SelectionStart = 0 
            If curpos < CInt(sender.Tag("MouseDownStart")) Then
                'NSYS 左ドラッグ時
                sender.SelectionLength = curpos
            Else
                sender.SelectionLength = curpos + sender.SelectedText.Length
            End If
            sender.ScrollToCaret()
            sender.Tag("OnHighlight") = False
        End If
    End Sub
End Class
