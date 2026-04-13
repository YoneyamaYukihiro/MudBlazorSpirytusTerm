'ﾌｧｲﾙ名：CtsfrmxxEN00F4.vb
'説　明：コメント(在庫管理サブフォーム)
'作成日：2004/07/07 (Wed) 20:41:31 S.Deguchi
'更新日：2026/03/12 (Thu) 15:42:00 T.Oide
'備　考：次SB連絡登録/表示機能をEN00F8に移行。ただし、EN00F4の次SB連絡機能は残したまま。
'Copyright(C) SEIKO EPSON CORPORATION 2003-2026, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00F4
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00F4    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00F4
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00F4
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00F4)
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
    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN00F4      'ﾛｰｶﾙ機能ID

    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    Private Const CMstrlot_chgcmmentVer         As String = "01.00"             'ﾛｯﾄｺﾒﾝﾄ登録

    '@ﾃｷｽﾄ
    Private Const CMlngMaxDispRow               As Integer = 10                    'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '@ﾚｽﾎﾟﾝｽ用定数
    Private Const CMstrFormName                 As String = "frmxxEN00F4"
    Private Const CMstrCmdRegistClick           As String = "cmdRegist_Click"

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    Private mstrLotLastUpdate                   As String                       '最終更新日時
    Private mblnFormLoadFlag                    As Boolean                      'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True：起動時以外/False：起動時のみ)
    Private buttonProcessing                    As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                      'NSYS WindowCloseフラグ
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
        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                                *イベントハンドラの記述*
    '****************************************************************************************
    '========================================Private=========================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/07 (Wed) 20:43:42 S.Deguchi
    '更新日：2004/07/07 (Wed) 20:43:42
    '備　考：
    Private Sub Form_Load()

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@画面情報の初期化
            Call prvfrmxxEN00F4_Init()
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
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

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑｱｸﾃｨﾍﾞｲﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/07 (Thu) 08:32:38 S.Deguchi
    '更新日：2005/07/07 (Thu) 08:32:38
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理分岐
            If mblnFormLoadFlag = False Then
                '@ﾌﾗｸﾞを戻す
                mblnFormLoadFlag = True
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                '@画面情報表示処理
                Call prvfrmxxEN00F4_Disp()
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
    '機　能：ｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/07/07 (Thu) 10:14:54 S.Deguchi
    '更新日：2005/07/07 (Thu) 10:14:54
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

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
                e.Handled = True
                Exit Sub
            End If

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
    '機　能：終了処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/07/09 (Fri) 08:51:51 S.Deguchi
    '更新日：2004/07/09 (Fri) 08:51:51
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If

            '@ﾀｲﾄﾙ判定ﾌﾗｸﾞの初期化
            ptypHoldConnect.strTitleFlg = vbNullString
            
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
    '作成日：2004/07/07 (Wed) 21:00:40 S.Deguchi
    '更新日：2004/07/07 (Wed) 21:00:40
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
            
            '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞしてﾌﾟﾛｸﾞﾗﾑ終了
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

    '関数名：cmdCommentUp_Click
    '機　能：ｺﾒﾝﾄ▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/16 (Fri) 09:20:24 Y.Yamagishi
    '更新日：2004/07/16 (Fri) 15:36:15 Y.Yamagishi
    '備　考：
    '　　　：2005/11/22 (Tue) 13:15:34 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdCommentUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCommentUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtComment, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCommentUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommentDown_Click
    '機　能：ｺﾒﾝﾄ▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/16 (Fri) 09:20:29 Y.Yamagishi
    '更新日：2004/07/16 (Fri) 15:36:18 Y.Yamagishi
    '備　考：
    '　　　：2005/11/22 (Tue) 13:15:34 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdCommentDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCommentDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtComment, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCommentDown_Click"
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
    '作成日：2004/08/05 (Thu) 14:17:42 N.Kasai
    '更新日：2006/02/03 (Fri) 14:53:38 N.Kojima
    '備　考：
    '　　　：2004/11/26 (Fri) 18:29:25 H.Wajima     次SB連絡登録Msg単独登録対応
    '　　　：2006/02/03 (Fri) 14:53:38 N.Kojima     ①ﾛｯﾄｺﾒﾝﾄ登録は「lot_.chgcomm_」を使用する。
    '　　　：                                       ②ﾚｽﾎﾟﾝｽ関数への引数を修正。
    '　　　：                                       ③引継ぎ構造体への格納処理をｺﾒﾝﾄｱｳﾄ。(運用障害№539対応)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)

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
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)
            

        '@↓2006/02/09 (Thu) 16:21:21 N.Kojima **************************************************
        '@ﾛｯﾄｺﾒﾝﾄ登録機能追加に伴い、Msgを"inv_.chgcomm_"から"lot_.chgcomm_"に変更

            '@通信中はESCでの画面終了は無効
            Me.CancelButton = Nothing

        '    '@Lotｺﾒﾝﾄ登録ﾒｯｾｰｼﾞ送信(最終更新日時は、確定時に返される値を使う。ﾒｯｾｰｼﾞ関数内で書き換えている。)
        '    lblnAns = pubblnInvChgComm_Upd(CMstrinv_chgcmmentVer, _
        '                                   lblLotID.Caption, _
        '                                   pstrUserID, _
        '                                   txtComment.Text, _
        '                                   mstrLotLastUpdate)

            '@Lotｺﾒﾝﾄ登録ﾒｯｾｰｼﾞ送信(最終更新日時は、確定時に返される値を使う。ﾒｯｾｰｼﾞ関数内で書き換えている。)
            lblnAns = pubblnLotChgComm_Upd(CMstrlot_chgcmmentVer, _
                                           lblLotID.Text, _
                                           pstrUserID, _
                                           txtComment.Text, _
                                           mstrLotLastUpdate)

            
            '@ESCでの画面を有効に
            Me.CancelButton = cmdClose
            
            '@結果が正常の場合
            If lblnAns = True Then
                
                '@ｺﾒﾝﾄ更新ﾌﾗｸﾞをTrueに
                pblnCommetsCommitFlag = True
            
                '@表示ﾒｯｾｰｼﾞ変換
        '        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003K, lblLotID.Caption)
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002R, lblLotID.Text)
                
                '@ｽﾃｰﾀｽﾊﾞｰ表示
                '@pubVsfInfo_Disp("<TRM2RI>$$ロットコメントを登録しました。ロット[%1]")
                Call pubVsfInfo_Disp(pstrDMsg)
                                     
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                    
                '@引継ぎ構造体にｺﾒﾝﾄ内容をｾｯﾄ
                ptypHoldConnect.strCommnents = txtComment.Text
                '@引継ぎ構造体に最終更新日時をｾｯﾄ
                ptypHoldConnect.strLastUpdate = mstrLotLastUpdate
                
                '@画面を終了する
                Call cmdClose_Click(cmdClose, e)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
            End If

        '@↑2006/02/09 (Thu) 16:21:21 N.Kojima **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ESCでの画面を有効に
            Me.CancelButton = cmdClose

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

    '関数名：txtComment_Change
    '機　能：ｺﾒﾝﾄ欄変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/05 (Thu) 14:28:02 N.Kasai
    '更新日：2026/03/12 (Thu) 15:42:00 T.Oide
    '備　考：
    Private Sub txtComment_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtComment.Change

        Dim llngNowByte As Integer 'ﾊﾞｲﾄ数

        Try
            
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtComment.NowByte
            
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte4000)
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComment, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComment_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComment_KeyUp
    '機　能：ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/11/25 (Fri) 11:25:57 S.Deguchi
    '更新日：2005/11/25 (Fri) 11:25:57
    '備　考：
    Private Sub txtComment_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtComment.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtComment, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComment_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComment_MouseUp
    '機　能：ﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/25 (Fri) 11:26:00 S.Deguchi
    '更新日：2005/11/25 (Fri) 11:26:00
    '備　考：
    Private Sub txtComment_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtComment.MouseUp

        Try
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComment, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComment_MouseUp"
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

    '関数名：prvfrmxxEN00F4_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/07 (Wed) 20:44:51 S.Deguchi
    '更新日：2026/03/12 (Thu) 15:42:00 T.Oide
    '備　考：
    Private Sub prvfrmxxEN00F4_Init()

        Dim llngNowByte     As Integer          '現在のﾊﾞｲﾄ数格納

        Try
            
            '@Textﾎﾞｯｸｽの初期化
            With txtComment
                '@文字数設定
                .ChrMaxByte = CPlngLotCommentsMaxByte4000
                
                '@表示部初期化
                .Text = vbNullString
                
                '@現状のﾊﾞｲﾄ数を格納
                llngNowByte = .NowByte
                
                '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte4000)
            End With
            
            '@ｷｬﾘｱID、ﾛｯﾄID、流動区分
            lblCarrier.Text = vbNullString
            lblLotID.Text = vbNullString
            lblFlowClass.Text = vbNullString
            
            '@ﾎﾞﾀﾝの使用不可
            cmdCommentUp.Enabled = False                'ｽｸﾛｰﾙ上
            cmdCommentDown.Enabled = False              'ｽｸﾛｰﾙ下
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN00F4_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN00F4_Disp
    '機　能：画面情報表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/07 (Wed) 20:47:05 S.Deguchi
    '更新日：2006/02/03 (Fri) 14:52:24 N.Kojima
    '備　考：
    '　　　：2006/02/03 (Fri) 14:52:24 N.Kojima     不要処理削除。(運用障害№539対応)
    Private Sub prvfrmxxEN00F4_Disp()

        Try
            
            '@ｷｬﾘｱID
            lblCarrier.Text = ptypHoldConnect.strCarrierId
            
            '@ﾛｯﾄID
            lblLotID.Text = ptypHoldConnect.strLotID
            
            '@流動区分
            lblFlowClass.Text = ptypHoldConnect.strFlowClass
            
            '@最終更新日時退避
            mstrLotLastUpdate = ptypHoldConnect.strLastUpdate
                
            '@起動区分を判定してﾃｷｽﾄ設定を変更する。
            '@次SB連絡、前SB連絡はEN00F8へ移行。以下の判定は、とりあえずそのまま。
            With ptypHoldConnect
                Select Case ptypHoldConnect.strTitleFlg
                    '@次SB連絡の場合
                    Case CPstrSubFormEN00F4Next
                        '@引継ぎ情報の表示
                        txtComment.Text = .strNextCommnents     '次SB連絡
            
                    '前SB連絡の場合
                    Case CPstrSubFormEN00F4Pre
                        '@引継ぎ情報の表示
                        txtComment.Text = .strNextCommnents     'ｺﾒﾝﾄ
                    
                    Case Else
                        '@引継ぎ情報の表示
                        txtComment.Text = .strCommnents         'ｺﾒﾝﾄ
                End Select
            End With
            
            '@編集ﾌﾗｸﾞの判定
            Select Case ptypHoldConnect.blnEditFlag
                Case True
                '@入力可の場合
                    '@Textﾎﾞｯｸｽの設定変更(入力可)
                    With txtComment
                        .BackColor = Color.White
                        .GotBackColor = Color.White
                        .Locked = False
                        .TabStop = True
                    End With
                
                    '確定ﾎﾞﾀﾝの設定
                    cmdRegist.Visible = True
                
        '@↓2006/02/03 (Fri) 14:53:08 N.Kojima **************************************************
        '@確定ﾎﾞﾀﾝは常に有効(活性化)にするので、不要処理。
        '            '@次SB連絡があるか判定
        '            If txtComment.Text <> vbNullString Then
        '                '@確定ﾎﾞﾀﾝ使用可
        '                cmdRegist.Enabled = True
        '            Else
        '                '@確定ﾎﾞﾀﾝ使用不可
        '                cmdRegist.Enabled = False
        '            End If
        '@↑2006/02/03 (Fri) 14:53:08 N.Kojima **************************************************
                    
                    '@ﾗﾍﾞﾙﾀｲﾄﾙに文字数を表示
                    lblLengthCount.Visible = True

                Case False
                '@入力不可の場合
                    '@Textﾎﾞｯｸｽの設定変更(入力不可)
                    With txtComment
                        .BackColor = SystemColors.ControlLight
                        .GotBackColor = SystemColors.ControlLight
                        .Locked = True
                        .TabStop = True
                    End With
            
                    '@確定ﾎﾞﾀﾝ使用不可
                    cmdRegist.Visible = False
                    
                    '@ﾗﾍﾞﾙﾀｲﾄﾙに文字数を非表示
                    lblLengthCount.Visible = False
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN00F4_Disp"
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
                End Select

            Case WM_CLOSE
                'Application.Exit以外で閉じられようとしている場合

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
