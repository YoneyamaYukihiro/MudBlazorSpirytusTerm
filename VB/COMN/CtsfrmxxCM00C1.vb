'ﾌｧｲﾙ名：xxCM00C1.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ｷｬﾘｱ洗浄
'作成日：2004/09/27 (Mon) 18:55:51 N.Kasai
'更新日：2004/09/27 (Mon) 18:55:51
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Public Class frmxxCM00C1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00C1    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00C1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00C1
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00C1)
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
    Private Const CMstrcarrclean___Ver                      As String = "01.00"                 'ｷｬﾘｱ洗浄

    '@ﾛｰｶﾙ機能ID
    Private Const CMstrLocalMenuKey                         As String = CPstrKeyCM00C1          'ﾛｰｶﾙ機能ID
    '***************************************************************************************
    '                                   * 変数の記述 *
    '***************************************************************************************
    '======================================Public===========================================
    '======================================Private==========================================
    Private buttonProcessing                                As Boolean                          'NSYS ボタン2度押し対策

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
    '作成日：2004/09/27 (Mon) 19:13:29 N.Kasai
    '更新日：2004/09/27 (Mon) 19:13:29
    '備　考：
    Private Sub Form_Load()

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@画面初期化
            Call prvfrmxxCM00C1_Init()

            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Load"
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
    '作成日：2004/09/27 (Mon) 19:13:29 N.Kasai
    '更新日：2004/09/27 (Mon) 19:13:29
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

        '    '@ｷｰｺｰﾄﾞ判定
        '    Select Case KeyCode
        '        Case vbKeyReturn    '[ENTER]押下
        '            '@ﾌｫｰｶｽの移動
        '            SendKeys CPstrSendKeysTab, True
        '            KeyCode = 0
        '    End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
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
    '作成日：2004/09/27 (Mon) 19:21:12 N.Kasai
    '更新日：2004/09/27 (Mon) 19:21:12
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If

            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_QueryUnload"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSet_Click
    '機　能：確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/27 (Mon) 19:15:28 N.Kasai
    '更新日：2004/09/27 (Mon) 19:15:28
    '備　考：
    Private Sub cmdSet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSet.Click

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
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
            
            '@画面入力ﾁｪｯｸ
            lblnAns = prvblnInput_Chk()
            If lblnAns = False Then
                Exit Sub
            End If
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "cmdSet_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@ﾒｯｾｰｼﾞ送信処理呼び出し
            lblnAns = pubblnCarrClean_Upd(CMstrcarrclean___Ver, txtCarrierID.Text, pstrUserID)
            If lblnAns = True Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000C, txtCarrierID.Text)
                '@成功ﾒｯｾｰｼﾞ表示
                '@pubVsfInfo_Disp("C_I0C%0$$キャリア[%1]の洗浄を完了しました。$いつでも利用可能です。")
                Call pubVsfInfo_Disp(pstrDMsg)
                '@ｷｬﾘｱID格納（親画面に引継ぎ）
                pstrCarrierID = txtCarrierID.Text
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@画面を閉じる
                Me.Close()
            
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                '@ｷｬﾘｱﾀｲﾌﾟにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrierID)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdSet_Click"
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
    '作成日：2004/09/27 (Mon) 19:03:08 N.Kasai
    '更新日：2004/09/27 (Mon) 19:03:08
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

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdClose_Click"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierID_Change
    '機　能：ｷｬﾘｱID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/27 (Mon) 21:32:43 N.Kasai
    '更新日：2004/09/27 (Mon) 21:32:43
    '備　考：
    Private Sub txtCarrierID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrierID.Change

        Try
            
            '@確定ﾎﾞﾀﾝ使用可否判定
            If txtCarrierID.Text <> vbNullString Then
                cmdSet.Enabled = True
            Else
                cmdSet.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtCarrierID_Change"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierID_KeyPress
    '機　能：ｷｬﾘｱIDのKeyPress処理
    '引　数：KeyAscii：ｱｽｷｰｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/10/04 (Mon) 10:27:59 S.Deguchi
    '更新日：2004/10/04 (Mon) 10:27:59
    '備　考：
    Private Sub txtCarrierID_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtCarrierID.KeyPress

        Try

            '@ｴﾝﾀｰｷｰかﾁｪｯｸ
            If Asc(e.KeyChar) = Keys.Return Then
                '@確定処理実行
                Call cmdSet_Click(cmdSet, New EventArgs())
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtCarrierID_KeyPress"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：prvfrmxxCM00C1_Init
    '機　能：画面初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/27 (Mon) 19:05:51 N.Kasai
    '更新日：2004/09/27 (Mon) 19:05:51
    '備　考：
    Private Sub prvfrmxxCM00C1_Init()

        Try

            '@ｷｬﾘｱIDの初期化
            txtCarrierID.Text = vbNullString

            '@確定ﾎﾞﾀﾝの使用不可
            cmdSet.Enabled = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxCM00C1_Init"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnInput_Chk
    '機　能：確定ﾎﾞﾀﾝﾁｪｯｸ
    '引　数：なし
    '戻り値：True:成功　False:失敗
    '作成日：2004/09/27 (Mon) 19:30:06 N.Kasai
    '更新日：2004/09/27 (Mon) 19:30:06
    '備　考：
    Private Function prvblnInput_Chk() As Boolean

        Try
            
            prvblnInput_Chk = False
            
            '@ｷｬﾘｱIDﾁｪｯｸ
            If Trim(txtCarrierID.Text) = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
               '@"キャリアIDが設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Call pubSetFocus(txtCarrierID)
                Exit Function
            Else
                '@ｷｬﾘｱIDの桁ﾁｪｯｸ
                If txtCarrierID.NowByte < txtCarrierID.ChrMaxByte Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                    '@"キャリアIDは6桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Call pubSetFocus(txtCarrierID)
                    Exit Function
                End If
            End If
            
             prvblnInput_Chk = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnInput_Chk"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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

End Class
