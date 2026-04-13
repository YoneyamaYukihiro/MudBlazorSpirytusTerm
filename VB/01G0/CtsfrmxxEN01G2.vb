'ﾌｧｲﾙ名：xxEN01G2.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾛｯﾄｺﾒﾝﾄ表示専用画面
'作成日：2004/10/25 (Mon) 17:34:57 H.Wajima
'更新日：2004/10/25 (Mon) 17:34:57
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01G2
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01G2    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01G2
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01G2
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01G2)
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
    '======================================Private==========================================
    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN01G2          'ﾛｰｶﾙﾒﾆｭｰKey
    '@ﾃｷｽﾄ
    Private Const CMlngMaxDispRow               As Integer = 19                     'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private buttonProcessing                    As Boolean                          'NSYS ボタン2度押し対策

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
    '======================================Private==========================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ Load処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/26 (Tue) 12:00:04 H.Wajima
    '更新日：2004/10/26 (Tue) 12:00:04
    '備　考：
    Private Sub Form_Load()

        Try

            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            
            '@画面上のｺﾝﾄﾛｰﾙを初期化する
            Call prvControl_Init()
            
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

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ ｸﾘｯｸ処理
    '引　数：なし
    '戻り値：
    '作成日：2004/10/25 (Mon) 17:55:53 H.Wajima
    '更新日：2004/10/25 (Mon) 17:55:53
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
            
            '@ﾌｫｰﾑを閉じる
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

    '関数名：cmdUp_Click
    '機　能：▲ﾎﾞﾀﾝ ｸﾘｯｸ処理
    '引　数：なし
    '戻り値：
    '作成日：2004/10/25 (Mon) 17:55:38 H.Wajima
    '更新日：2005/12/02 (Fri) 15:47:45 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 15:47:45 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/02 (Fri) 15:47:41 N.Kasai **************************************************
        '    '@ﾛｯﾄｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtLotComment)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtLotComment, CMlngMaxDispRow, cmdUP, cmdDown)
        '@↑2005/12/02 (Fri) 15:47:41 N.Kasai **************************************************

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
    '機　能：▼ﾎﾞﾀﾝ ｸﾘｯｸ処理
    '引　数：なし
    '戻り値：
    '作成日：2004/10/25 (Mon) 17:55:35 H.Wajima
    '更新日：2005/12/02 (Fri) 15:48:41 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 15:48:41 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/02 (Fri) 15:48:38 N.Kasai **************************************************
        '    '@ﾛｯﾄｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtLotComment)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtLotComment, CMlngMaxDispRow, cmdUP, cmdDown)
        '@↑2005/12/02 (Fri) 15:48:38 N.Kasai **************************************************

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

    '関数名：txtLotComment_Change
    '機　能：ﾛｯﾄｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:12:03 N.Kasai
    '更新日：2005/11/29 (Tue) 14:12:03
    '備　考：
    Private Sub txtLotComment_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLotComment.Change

        Try
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtLotComment, CMlngMaxDispRow, cmdUP, cmdDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotComment_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotComment_KeyUp
    '機　能：ﾛｯﾄｺﾒﾝﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 13:47:07 N.Kasai
    '更新日：2005/11/29 (Tue) 13:47:07
    '備　考：
    Private Sub txtLotComment_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtLotComment.KeyUp

        Try
            
            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtLotComment, CMlngMaxDispRow, cmdUP, cmdDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotComment_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：txtLotComment_MouseUp
    '機　能：ﾛｯﾄｺﾒﾝﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 13:48:44 N.Kasai
    '更新日：2005/11/29 (Tue) 13:48:44
    '備　考：
    Private Sub txtLotComment_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtLotComment.MouseUp

        Try
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtLotComment, CMlngMaxDispRow, cmdUP, cmdDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotComment_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '======================================Public===========================================
    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：prvControl_Init
    '機　能：画面上ｺﾝﾄﾛｰﾙ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/26 (Tue) 12:06:02 H.Wajima
    '更新日：2005/12/02 (Fri) 15:53:12 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 15:53:12 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub prvControl_Init()

        Try

            '@各ｺﾝﾄﾛｰﾙの初期値設定
            '@ﾃｷｽﾄﾎﾞｯｸｽ
            With txtLotComment
                .BackColor = SystemColors.ControlLight      '背景色
                .GotBackColor = SystemColors.ControlLight   'ﾌｫｰｶｽ取得時背景色
                .TabStop = True                             'ﾀﾌﾞｽﾄｯﾌﾟ
                .Enabled = True                             'ｺﾝﾄﾛｰﾙ有効
                .Locked = True                              'NSYS 変更不可
            End With
            '@▲ﾎﾞﾀﾝ
            With cmdUP
                .TabStop = True                             'ﾀﾌﾞｽﾄｯﾌﾟ
        '@↓2005/12/02 (Fri) 15:52:47 N.Kasai **************************************************
        '        .Enabled = True                            'ｺﾝﾄﾛｰﾙ有効
                .Enabled = False                            'ｺﾝﾄﾛｰﾙ無効
        '@↑2005/12/02 (Fri) 15:52:47 N.Kasai **************************************************

            End With
            '@▼ﾎﾞﾀﾝ
            With cmdDown
                .TabStop = True                             'ﾀﾌﾞｽﾄｯﾌﾟ
        '@↓2005/12/02 (Fri) 15:53:08 N.Kasai **************************************************
        '        .Enabled = True                             'ｺﾝﾄﾛｰﾙ有効
                .Enabled = False                            'ｺﾝﾄﾛｰﾙ無効
        '@↑2005/12/02 (Fri) 15:53:08 N.Kasai **************************************************
            End With
            '@閉じるﾎﾞﾀﾝ
            With cmdClose
                .TabStop = True                             'ﾀﾌﾞｽﾄｯﾌﾟ
                .Enabled = True                             'ｺﾝﾄﾛｰﾙ有効
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvControl_Init"
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

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑの終了
    '引　数：sender：イベント発生元
    '　　　：e     ：イベントオブジェクト
    '戻り値：
    '作成日：2020/03/30 (Mon) 18:30:00 NSYS
    '更新日：
    '備　考：
    Private Sub Form_QueryUnload(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'NSYS 静的イベントハンドラ解除
        RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub
    
End Class
