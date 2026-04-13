'ﾌｧｲﾙ名：xxEN00F8.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：コメント(次SB連絡情報専用)(在庫管理サブフォーム)
'作成日：2005/01/11 (Tue) 17:54:43 H.Wajima
'更新日：2008/06/24 (Tue) 16:02:11 N.Kojima
'備　考：項目ｻｲｽﾞを帳票の項目ｻｲｽﾞに合わせる為、次SB連絡情報専用に独立。
'　　　：2005/04/11 (Mon) 11:07:48 S.Deguchi    不具合№719の対応で過去に入力されたﾃﾞｰﾀと比較して確定ﾎﾞﾀﾝの活性化処理を行うように修正
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00F8
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00F8    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00F8
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00F8
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00F8)
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
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN00F8      'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrinv_chgcmmentVer             As String = "01.00"             '次SB連絡ｺﾒﾝﾄ登録

    '@警告文
    Private Const CMstrWarningMsg1                  As String = "※ロット検定票の次工程連絡情報は入力項目とほぼ同じイメージで印刷されます｡"
    Private Const CMstrWarningMsg2                  As String = "　入力項目に表示されない部分は､帳票に印刷されませんので注意してください｡"

    '@ﾌｫﾝﾄ
    Private Const CMstrSBCommentFontName            As String = "FixedSys"          'ﾌｫﾝﾄ名
    Private Const CMlngSBCommentFontSize            As Integer = 14                 'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngMaxDispRow                   As Integer = 15                 'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    Private mstrLotLastUpdate                       As String                       '最終更新日時
    Private mstrNextSBMemo                          As String                       '次SB連絡ﾒﾓ退避領域
    Private mblnFormLoadFlag                        As Boolean                      'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True：起動時以外/False：起動時のみ)

    Private buttonProcessing                        As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                      'NSYS WindowCloseフラグ
    Private ReadOnly vbButtonFace                   As Color = SystemColors.ControlLight 'NSYS ボタンの背景色定義
    Private ReadOnly vbWhite                        As Color = Color.white               'NSYS 白色定義

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
    '作成日：2005/01/11 (Tue) 17:55:56 H.Wajima
    '更新日：2005/01/11 (Tue) 17:55:56
    '備　考：
    Private Sub Form_Load()

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@画面情報の初期化
            Call prvfrmxxEN00F8_Init()
            
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
                Call prvfrmxxEN00F8_Disp()
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
    '機　能：ﾌｫｰﾑｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/07/07 (Thu) 10:16:14 S.Deguchi
    '更新日：2005/07/07 (Thu) 10:16:14
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

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
    '作成日：2005/01/11 (Tue) 17:56:53 H.Wajima
    '更新日：2005/01/11 (Tue) 17:56:53
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
    '作成日：2005/01/11 (Tue) 17:57:27 H.Wajima
    '更新日：2005/01/11 (Tue) 17:57:27
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
    '作成日：2005/01/11 (Tue) 17:58:44 H.Wajima
    '更新日：2006/02/09 (Thu) 10:12:21 N.Kojima
    '備　考：次SB連絡登録のみ使用可
    '　　　：2006/02/09 (Thu) 10:12:21 N.Kojima     引継ぎ構造体への格納処理をｺﾒﾝﾄｱｳﾄ。(運用障害№539対応)
    '　　　：                                       ※戻り先で最新情報を取得する
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)

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
            lstrFormName = Me.Name
            lstrEventName = "cmdRegist_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@最終更新日時退避
            mstrLotLastUpdate = ptypHoldConnect.strLastUpdate
            
            '@Lotｺﾒﾝﾄ登録ﾒｯｾｰｼﾞ送信(最終更新日時は、確定時に返される値を使う。ﾒｯｾｰｼﾞ関数内で書き換えている。)
            lblnAns = pubblnInvChgComm_Upd(CMstrinv_chgcmmentVer, _
                                           lblLotID.Text, _
                                           pstrUserID, _
                                           txtComment.Text, _
                                           mstrLotLastUpdate)

        '@↓2006/02/09 (Thu) 10:12:05 N.Kojima **************************************************
            '@結果が正常の場合
            If lblnAns = True Then
            
                '@ｺﾒﾝﾄ更新ﾌﾗｸﾞをTrueに
                pblnCommetsCommitFlag = True
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003K, lblLotID.Text)
                
                '@ｽﾃｰﾀｽﾊﾞｰ表示
                '@pubVsfInfo_Disp("<TRM3KI>$$次SB連絡コメントを登録しました。ロット[%1]")
                Call pubVsfInfo_Disp(pstrDMsg)
                                     
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                    
                '@引継ぎ構造体にｺﾒﾝﾄ内容をｾｯﾄ
                ptypHoldConnect.strNextCommnents = txtComment.Text
                '@引継ぎ構造体に最終更新日時をｾｯﾄ
                ptypHoldConnect.strLastUpdate = mstrLotLastUpdate
                
                '@画面を終了する。
                Call cmdClose_Click(cmdClose, New EventArgs)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            End If
        '@↑2006/02/09 (Thu) 10:12:05 N.Kojima **************************************************
            
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

    '関数名：txtComment_Change
    '機　能：ｺﾒﾝﾄ欄変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/11 (Tue) 17:59:31 H.Wajima
    '更新日：2006/02/10 (Fri) 10:51:47 N.Kojima
    '備　考：
    '　　　：2005/04/11 (Mon) 11:16:13 S.Deguchi    退避領域と比較して確定ﾎﾞﾀﾝ活性化判断
    '　　　：2005/11/22 (Tue) 13:15:34 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    '　　　：2006/02/10 (Fri) 10:51:47 N.Kojima     確定ﾎﾞﾀﾝの制御をｺﾒﾝﾄｱｳﾄ(運用障害№539対応)
    Private Sub txtComment_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtComment.Change

        Dim llngNowByte As Integer 'ﾊﾞｲﾄ数

        Try
            
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtComment.NowByte
            
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComment, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)
            
        '@↓2006/02/10 (Fri) 10:50:41 N.Kojima **************************************************
        '@確定ﾎﾞﾀﾝはいつでも押せるようにする
        '
        '    '@退避領域と異なる場合のみ,確定ﾎﾞﾀﾝを活性化
        '    If txtComment.Text <> mstrNextSBMemo Then
        '        cmdRegist.Enabled = True
        '    Else
        '        cmdRegist.Enabled = False
        '    End If
        '@↑2006/02/10 (Fri) 10:50:41 N.Kojima **************************************************
            
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
    '関数名：prvfrmxxEN00F8_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/11 (Tue) 17:56:24 H.Wajima
    '更新日：2005/01/21 (Fri) 09:49:00 H.Wajima
    '備　考：2005/01/21 (Fri) 09:49:00 H.Wajima     ﾌｫﾝﾄ名、ﾌｫﾝﾄｻｲｽﾞの指定を追加
    '　　　：2005/04/11 (Mon) 11:11:18 S.Deguchi    次SB連絡の退避領域を初期化
    Private Sub prvfrmxxEN00F8_Init()

        Dim llngNowByte     As Integer          '現在のﾊﾞｲﾄ数格納

        Try
            
            mstrNextSBMemo = vbNullString           '退避領域(次SB連絡)

            '@Textﾎﾞｯｸｽの初期化
            With txtComment
                '@ﾌｫﾝﾄ名、ﾌｫﾝﾄｻｲｽﾞを指定
                '@(全角、半角文字のｻｲｽﾞを揃える必要がある為、例外的にFixedSysﾌｫﾝﾄを使用。(半角2文字が全角1文字になる))
                'NSYS VB.NETでビットマップフォントを使用できないため、FixedSysを指定できない
                With .Font
                    txtComment.Font = New Font(.FontFamily, CMlngSBCommentFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .ChrMaxByte = CPlngLotCommentsMaxByte
                .Text = vbNullString
                '@現状のﾊﾞｲﾄ数を格納
                llngNowByte = .NowByte
                '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            End With
            
            '@ｷｬﾘｱID、ﾛｯﾄID、流動区分
            lblCarrier.Text = vbNullString
            lblLotID.Text = vbNullString
            lblFlowClass.Text = vbNullString
            
            '@警告文の表示
            lblWarning.Text = CMstrWarningMsg1 & vbCrLf & CMstrWarningMsg2
            
            '@ﾎﾞﾀﾝの使用不可
            cmdCommentUp.Enabled = False                'ｽｸﾛｰﾙ上
            cmdCommentDown.Enabled = False              'ｽｸﾛｰﾙ下
            cmdRegist.Enabled = False                   '確定ﾎﾞﾀﾝ
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN00F8_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN00F8_Disp
    '機　能：画面情報表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/11 (Tue) 17:59:53 H.Wajima
    '更新日：2006/02/10 (Fri) 10:53:52 N.Kojima
    '備　考：
    '　　　：2005/04/11 (Mon) 11:11:18 S.Deguchi    次SB連絡の退避領域へ情報をｾｯﾄ
    '　　　：2006/02/10 (Fri) 10:53:52 N.Kojima     確定ﾎﾞﾀﾝを無条件で有効にする。(運用障害№539対応)
    Private Sub prvfrmxxEN00F8_Disp()

        Try
            
            '@ｷｬﾘｱID
            lblCarrier.Text = ptypHoldConnect.strCarrierId
            
            '@ﾛｯﾄID
            lblLotID.Text = ptypHoldConnect.strLotID
            
            '@流動区分
            lblFlowClass.Text = ptypHoldConnect.strFlowClass
                
            '@SB連絡ﾒﾓ
            mstrNextSBMemo = ptypHoldConnect.strNextCommnents
            
            '@起動区分を判定してﾃｷｽﾄ設定を変更する。
            Select Case ptypHoldConnect.strTitleFlg
                '@次SB連絡の場合
                Case CPstrSubFormEN00F4Next
                    '@引継ぎ情報の表示
                    With ptypHoldConnect
                        txtComment.Text = .strNextCommnents     '次SB連絡
                    
                        '@外部送品ﾌﾗｸﾞの判定
                        If .blnOuterSendFlag = True Then
                            '@外部送品ありの場合(送品伝票、検定票を印刷する場合)
                            '@警告文を表示する
                            lblWarning.Visible = True
                        Else
                            '@外部送品なしの場合(送品伝票、検定票を印刷しない場合)
                            '@警告文を表示しない
                            lblWarning.Visible = False
                        End If
                    
                    End With
                
                '@前SB連絡の場合
                Case CPstrSubFormEN00F4Pre

                    '@引継ぎ情報の表示
                    With ptypHoldConnect
                        txtComment.Text = .strNextCommnents     'ｺﾒﾝﾄ
                    End With
                    
                    '@警告文を表示しない
                    lblWarning.Visible = False
                
                '@その他
                Case Else
                    '@引継ぎ情報の表示
                    With ptypHoldConnect
                        txtComment.Text = .strCommnents         'ｺﾒﾝﾄ
                    End With
                    
                    '@警告文を表示しない
                    lblWarning.Visible = False
            End Select
                  
            '@編集ﾌﾗｸﾞの判定
            Select Case ptypHoldConnect.blnEditFlag
                Case True
                '@入力可の場合
                    '@Textﾎﾞｯｸｽの設定変更(入力可)
                    With txtComment
                        .BackColor = vbWhite
                        .GotBackColor = vbWhite
                        .Locked = False
                        .TabStop = True
                    End With
                
                    '確定ﾎﾞﾀﾝの設定
                    cmdRegist.Visible = True
                
        '@↓2006/02/10 (Fri) 10:47:58 N.Kojima **************************************************
        '            '@次SB連絡があるか判定
        '            If txtComment.Text <> vbNullString Then
        '                '@確定ﾎﾞﾀﾝ使用可
        '                cmdRegist.Enabled = False
        '            Else
        '                '@確定ﾎﾞﾀﾝ使用不可
        '                cmdRegist.Enabled = False
        '            End If
                    
                    '@無条件で確定ﾎﾞﾀﾝを有効にする
                    cmdRegist.Enabled = True
        '@↑2006/02/10 (Fri) 10:47:58 N.Kojima **************************************************
                    
                    '@ﾗﾍﾞﾙﾀｲﾄﾙに文字数を表示
                    lblLengthCount.Visible = True
                
                Case False
                '@入力不可の場合
                    '@Textﾎﾞｯｸｽの設定変更(入力不可)
                    With txtComment
                        .BackColor = vbButtonFace
                        .GotBackColor = vbButtonFace
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
                .strProcName = "prvfrmxxEN00F8_Disp"
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
