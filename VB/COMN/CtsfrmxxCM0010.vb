'ﾌｧｲﾙ名：xxCM0010.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ｺｰﾄﾞ入力画面
'作成日：2004/02/13 (Fri) 13:00:00 K.Takano
'更新日：2008/04/22 (Tue) 20:39:42 N.Kojima
'備　考：
'　　　：2005/08/29 (Mon) 14:45:50 S.Deguchi    ｿｰｽ整備
'Copyright(C)2003-, SEIKO EPSON CORPORATION.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Public Class frmxxCM0010
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM0010    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM0010
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM0010
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM0010)
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
    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_empname_Ver          As String = "02.01"             '作業者名取得

    '@表示ﾒｯｾｰｼﾞ
    Private Const CMstrUserIDTitle              As String = "作業者ID"          '作業者ID表示

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private buttonProcessing                    As Boolean                      'NSYS ボタン2度押し対策

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
    '====================================Private============================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　Load時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/13 (Fri) 14:00:00 K.Takano
    '更新日：2008/04/22 (Tue) 20:42:40 N.Kojima
    '備　考：
    '　　　：2005/08/29 (Mon) 14:47:29 S.Deguchi    ﾊﾟﾌﾞﾘｯｸ変数の初期化処理を追加
    '　　　：2008/04/22 (Tue) 20:42:40 N.Kojima     ｿｰｽ整備、所属ｸﾞﾙｰﾌﾟIDの初期化処理追加。(案件№02786)
    Private Sub Form_Load()

        Try

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
                .FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num      'ｱﾙﾌｧﾍﾞｯﾄ＆数値
                .ChrMaxByte = CPlngEmpIDLength                                      '最大7桁
                .ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper       '半角大文字
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = "frmxxCM0010"
                .strProcName = "Form_Load"
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
    '作成日：2004/02/13 (Fri) 14:00:00 K.Takano
    '更新日：2008/04/22 (Tue) 20:45:17 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 20:45:17 N.Kojima     ｿｰｽ整備、所属ｸﾞﾙｰﾌﾟIDの初期化処理追加。(案件№02786)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            
            '@ｷｬﾝｾﾙ時の初期化処理
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
                .strMenuKey = "frmxxCM0010"
                .strProcName = "Form_QueryUnload"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtUserID_KeyPress
    '機　能：ﾕｰｻﾞｰIDﾃｷｽﾄ　ｷｰ押下時処理
    '引　数：KeyAscii：ｷｰｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/02/13 (Fri) 14:00:00 K.Takano
    '更新日：2008/04/22 (Tue) 20:47:08 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 20:47:08 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub txtUserID_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtUserID.KeyPress

        Try

            '@ｴﾝﾀｰｷｰかﾁｪｯｸ
            If Asc(e.KeyChar) = Keys.Return Then
                
                '@=======================
                '@　確定実行処理
                '@=======================
                Call prvCmmit_Proc()
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = "frmxxCM0010"
                .strProcName = "txtUserID_KeyPress"
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
    '作成日：2004/02/13 (Fri) 13:00:00 K.Takano
    '更新日：2008/04/22 (Tue) 20:41:14 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 20:41:14 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@　確定実行処理
            '@=======================
            Call prvCmmit_Proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = "frmxxCM0010"
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
    '更新日：2008/04/22 (Tue) 20:48:56 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 20:48:56 N.Kojima     ｿｰｽ整備。(案件№02786)
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
                .strMenuKey = "frmxxCM0010"
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

    '関数名：prvCmmit_Proc
    '機　能：作業者ID確定処理(ﾒｲﾝﾌｫｰﾑにpstrUserIDで作業者IDを渡す)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/13 (Fri) 14:00:00 K.Takano
    '更新日：2008/04/22 (Tue) 20:39:00 N.Kojima
    '備　考：
    '　　　：2008/04/22 (Tue) 20:39:00 N.Kojima     ｿｰｽ整備、作業者情報取得処理の引数にｸﾞﾙｰﾌﾟID追加。(案件№02786)
    Private Sub prvCmmit_Proc()

        Dim lblnAns         As Boolean      '戻り値
        
        Try
            
            '@ﾕｰｻﾞｰIDをﾊﾟﾌﾞﾘｯｸ変数にｾｯﾄ
            pstrUserID = txtUserID.Text
                
            '@ﾕｰｻﾞｰIDがNULLか
            If pstrUserID = vbNullString Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0021)
                '@"<TRM21W>$$作業者IDを入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@作業者IDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtUserID)
                
                '@念の為、各Public変数を初期化
                pstrUserName = vbNullString     'ﾕｰｻﾞｰ名
                pstrDeptID = vbNullString       '職場ID
                pstrDeptName = vbNullString     '職場名
                pstrGroupID = vbNullString      '所属ｸﾞﾙｰﾌﾟID
                
                Exit Sub
            End If
            
            '@ﾕｰｻﾞｰID桁ﾁｪｯｸ(7桁)
            If Len(pstrUserID) <> CPlngEmpIDLength Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003K, CMstrUserIDTitle)
                '@"<TRM3KW>$$[作業者ID]は7桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@作業者IDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtUserID)
                
                '@念の為、各Public変数を初期化
                pstrUserName = vbNullString     'ﾕｰｻﾞｰ名
                pstrDeptID = vbNullString       '職場ID
                pstrDeptName = vbNullString     '職場名
                pstrGroupID = vbNullString      '所属ｸﾞﾙｰﾌﾟID
                
                Exit Sub
            End If

            '@【作業者名取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnMasEmpName_Sel(CMstrmas_empname_Ver, _
                                           pstrUserID, _
                                           pstrUserName, _
                                           pstrDeptID, _
                                           pstrDeptName, _
                                           pstrGroupID)

            '@通信結果判定
            If lblnAns = True Then
                '@結果：正常の場合
                
                '@ｷｬﾝｾﾙﾌﾗｸﾞをFlseにして正常終了する
                pblnCancel = False
            Else
                '@失敗の場合
                
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
                .strMenuKey = "frmxxCM0010"
                .strProcName = "prvCmmit_Proc"
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

End Class
