'ﾌｧｲﾙ名：xxEN00F9.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：送品取消(在庫管理サブフォーム)
'作成日：2005/03/22 (Tue) 10:32:00 S.Deguchi
'更新日：2008/06/24 (Tue) 16:02:30 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00F9
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00F9    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00F9
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00F9
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00F9)
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
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN00F9          'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrcarrcurstateVer                  As String = "05.02"                 'ｷｬﾘｱ状態確認
    Private Const CMstrlot_cancelsendVer                As String = "02.00"                 'ﾛｯﾄ送品取消

    '@その他定数宣言
    Private Const CstrRegistEndFlag                     As String = "1"                     '処理完了
    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '@変数宣言
    Private mstrLastUpdate                              As String                           '最終更新日時
    Private mstrCarrierID                               As String                           'ｷｬﾘｱID
    Private mstrCarrierType                             As String                           'ｷｬﾘｱﾀｲﾌﾟ
    Private mblnFormLoadFlag                            As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True：起動時以外/False：起動時のみ)

    Private buttonProcessing                            As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                          'NSYS WindowCloseフラグ
     
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
    '機　能：画面起動
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/22 (Tue) 14:38:34 S.Deguchi
    '更新日：2005/03/22 (Tue) 14:38:34
    '備　考：
    Private Sub Form_Load()

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@画面情報の初期化
            Call prvfrmxxEN00F9_Init()
            
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
                Call prvfrmxxEN00F9_Disp()
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
    '機　能：ﾌｫｰﾑのKeyDown処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/03/24 (Thu) 16:23:39 S.Deguchi
    '更新日：2005/03/24 (Thu) 16:23:39
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

            '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙによる処理分岐
            Select Case ActiveControl.Name
                Case txtCarrierID.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@ｷｬﾘｱID入力欄のValidate処理へ
                            RemoveHandler txtCarrierID.Validating, AddressOf txtCarrierID_Validate
                            Call txtCarrierID_Validate(txtCarrierID, New CancelEventArgs(False))
                            AddHandler txtCarrierID.Validating, AddressOf txtCarrierID_Validate
                            e.Handled = True
                    End Select
            
                Case Else
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
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

    '関数名：Form_QueryUnload
    '機　能：終了処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2005/03/22 (Tue) 14:40:51 S.Deguchi
    '更新日：2005/03/22 (Tue) 14:40:51
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If

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
    '作成日：2005/03/22 (Tue) 14:40:09 S.Deguchi
    '更新日：2005/03/22 (Tue) 14:40:09
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

    '関数名：cmdRegist_Click
    '機　能：確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/22 (Tue) 15:17:35 S.Deguchi
    '更新日：2005/03/22 (Tue) 15:17:35
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lstrFormName            As String           'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypSendCancelList      As SendCancelList   '送品取消構造体
        Dim lblnAns                 As Boolean          '結果取得(True:正常,False:異常)

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

            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称を設定
            lstrFormName = Me.Name
            lstrEventName = "cmdRegist_Click"

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@送品取消構造体へ情報をｾｯﾄ
            With ltypSendCancelList
                .strLotID = lblLotID.Text                'ﾛｯﾄID
                .strLotLastUpdate = mstrLastUpdate          '最終更新日時
                .strMsgVer = CMstrlot_cancelsendVer         'MsgVer
                .strSbID = pstrSBID                         'SBID
                .strEmpID = pstrUserID                      '作業者ID
                .strCarrierId = txtCarrierID.Text           'ｷｬﾘｱID
            End With

            '@ﾒｯｾｰｼﾞ送信処理呼び出し
            lblnAns = pubblnlotCancelSend_Upd(ltypSendCancelList)
            '@結果取得
            If lblnAns = True Then
            '@成功ﾒｯｾｰｼﾞ表示
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003L)
                
                '@pubVsfInfo_Disp("メッセージコード：<TRM3LI>$$ロット送品を取消しました。")
                Call pubVsfInfo_Disp(pstrDMsg)

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@引継構造体の確定処理完了ﾌﾗｸﾞをたてる
                With ptypSendCancelConnect
                    .strRegistFlag = CstrRegistEndFlag
                End With
                
                '@閉じる処理へ
                Call cmdClose_Click(cmdClose, New EventArgs)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            End If

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

    '関数名：cmdCarrierSelect_Click
    '機　能：ｷｬﾘｱ選択
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/23 (Wed) 13:54:34 S.Deguchi
    '更新日：2005/03/23 (Wed) 13:54:34
    '備　考：
    '　　　：2005/10/06 (Thu) 16:34:39 S.Deguchi    ｷｬﾘｱの洗浄条件設定処理を追加
    Private Sub cmdCarrierSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCarrierSelect.Click

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

            '@Form_Loadﾌﾗｸﾞ初期化
            pblnFormLoad = False
            
            '@ｷｬﾘｱﾀｲﾌﾟID引渡し
            pstrCarrierTypeID = mstrCarrierType     '引継いできたｷｬﾘｱﾀｲﾌﾟ
            
        '@↓2005/10/06 (Thu) 16:36:32 S.Deguchi **************************************************
            '@ｷｬﾘｱの洗浄条件：未洗浄可
            pstrCleanCondition = CPstrCarrierClean1
        '@↑2005/10/06 (Thu) 16:36:32 S.Deguchi **************************************************
            
            '@初期化
            pstrCarrierID = vbNullString
            
            '@空きｷｬﾘｱ一覧表示
            frmxxCM00K0.Instance = New frmxxCM00K0()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM00K0.Instance = Nothing
                Exit Sub
            End If
            
            '@空きｷｬﾘｱ一覧表示
            frmxxCM00K0.Instance.ShowDialog(Me)
            frmxxCM00K0.Instance = Nothing
                 
            '@空きｷｬﾘｱが選択されている場合
            If pstrCarrierID <> vbNullString Then
                '@引継いだｷｬﾘｱが既に入力されているｷｬﾘｱIDと異なる場合
                If pstrCarrierID <> txtCarrierID.Text Then
                    '@ｷｬﾘｱIDをｾｯﾄ
                    txtCarrierID.Text = pstrCarrierID
                    
                    '@退避領域にｾｯﾄ
                    mstrCarrierID = pstrCarrierID
                End If
                
                '@確定ﾎﾞﾀﾝを活性化
                cmdRegist.Enabled = True
                
                '@確定ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdRegist)
            Else
                '@ﾃｷｽﾄﾎﾞｯｸｽへﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrierID)
            End If

        '@↓2005/10/06 (Thu) 16:37:47 S.Deguchi **************************************************
            '@使用したﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrCarrierTypeID = vbNullString                'ｷｬﾘｱﾀｲﾌﾟ
            pstrCleanCondition = vbNullString               '洗浄条件
            pstrCarrierID = vbNullString                    'ｷｬﾘｱID
        '@↑2005/10/06 (Thu) 16:37:47 S.Deguchi **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCarrierSelect_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierID_Change
    '機　能：ｷｬﾘｱID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/22 (Tue) 14:40:09 S.Deguchi
    '更新日：2005/03/22 (Tue) 14:40:09
    '備　考：
    Private Sub txtCarrierID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrierID.Change

        Try

            '@ｷｬﾘｱIDの桁ﾁｪｯｸ&確定ﾎﾞﾀﾝの活性化ﾁｪｯｸ
            With txtCarrierID
                If .NowByte = .ChrMaxByte Then
                    '@確定ﾎﾞﾀﾝ活性化
                    cmdRegist.Enabled = True
                Else
                    '@確定ﾎﾞﾀﾝ非活性化
                    cmdRegist.Enabled = False
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrierID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierID_Validate
    '機　能：ｷｬﾘｱIDValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/03/22 (Tue) 14:40:09 S.Deguchi
    '更新日：2005/03/22 (Tue) 14:40:09
    '備　考：
    '　　　：2005/10/07 (Fri) 12:04:12 S.Deguchi    不具合№2995の対応で,ｷｬﾘｱの状態取得の処理区分を3Zへ変更
    Private Sub txtCarrierID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrierID.Validating

        Dim ltypCarrCurstate    As CarrCurstate     'ｷｬﾘｱ状態確認構造体
        Dim lstrFormName        As String           'ﾌｫｰﾑ名
        Dim lstrEventName       As String           'ｲﾍﾞﾝﾄ名
        Dim lblnAns             As Boolean          '戻り値

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｷｬﾘｱIDの空白ﾁｪｯｸ
            If Trim(txtCarrierID.Text) = vbNullString Then
                '@確定ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = "txtCarrierID" Then
                    If cmdRegist.Enabled = True Then
                        Call pubSetFocus(cmdRegist)
                    Else
                        Call pubSetFocus(cmdCarrierSelect)
                    End If
                End If
                
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtCarrierID.NowByte < txtCarrierID.ChrMaxByte Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                e.Cancel = True
                Exit Sub
            End If
            
            '@前回ｷｬﾘｱIDのﾁｪｯｸ
            If mstrCarrierID = txtCarrierID.Text Then
                '@確定ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = "txtCarrierID" Then
                    If cmdRegist.Enabled = True Then
                        Call pubSetFocus(cmdRegist)
                    Else
                        Call pubSetFocus(cmdClose)
                    End If
                End If
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "txtCarrierID_Validate"
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@ｷｬﾘｱ情報(要求)格納
            With ltypCarrCurstate
                .strCarrierId = txtCarrierID.Text       'ｷｬﾘｱID
        '@↓2005/10/07 (Fri) 12:05:17 S.Deguchi **************************************************
        '        .strClassDivision = CPstrCD2D           '空ｷｬﾘｱﾁｪｯｸ
                .strClassDivision = CPstrCD3Z           '空ｷｬﾘｱﾁｪｯｸ
        '@↑2005/10/07 (Fri) 12:05:17 S.Deguchi **************************************************
                .strMsgVer = CMstrcarrcurstateVer       'MSGVER
                .strSbID = pstrSBID                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strCarrierTypeID = mstrCarrierType     'ｷｬﾘｱﾀｲﾌﾟ
                .strLotID = vbNullString                'ﾛｯﾄID
            End With

            '@ｷｬﾘｱ状態取得
            lblnAns = pubblnCarrcurstate_Sel(ltypCarrCurstate, True)
            '@取得結果確認
            If lblnAns = True Then
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                '@ｷｬﾘｱIDの退避
                mstrCarrierID = txtCarrierID.Text
                
                '@確定ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = "txtCarrierID" Then
                    If cmdRegist.Enabled = True Then
                        Call pubSetFocus(cmdRegist)
                    Else
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                '@ｷｬﾘｱIDのｸﾘｱ
                mstrCarrierID = vbNullString
                e.Cancel = True
                If ActiveControl.Name = "txtCarrierID" Then
                    Call pubSetFocus(txtCarrierID)
                End If
                Exit Sub
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrierID_Validate"
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

    '関数名：prvfrmxxEN00F9_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/22 (Tue) 14:39:28 S.Deguchi
    '更新日：2005/03/22 (Tue) 14:39:28
    '備　考：
    Private Sub prvfrmxxEN00F9_Init()

        Try

            '@ﾗﾍﾞﾙ初期化処理
            lblToSend.Text = vbNullString            '送品先
            lblSendDate.Text = vbNullString          '送品日
            lblLotID.Text = vbNullString             'ﾛｯﾄID
            lblPdID.Text = vbNullString              '機種
            lblBoxNo.Text = vbNullString             '箱№
            lblWF.Text = vbNullString                '送品WF数
            lblChip.Text = vbNullString              '送品Chip数
            
            '@ﾃｷｽﾄ初期化処理
            txtCarrierID.Text = vbNullString
            
            '@閉じるﾎﾞﾀﾝのCausesValidationを設定する
            cmdClose.CausesValidation = False
            
            '@空きｷｬﾘｱﾎﾞﾀﾝのCausesValidationを設定する
            cmdCarrierSelect.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN00F9_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN00F9_Disp
    '機　能：画面情報表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/22 (Tue) 14:39:31 S.Deguchi
    '更新日：2005/03/22 (Tue) 14:39:31
    '備　考：
    Private Sub prvfrmxxEN00F9_Disp()

        Try

            '@引継情報をｾｯﾄ
            With ptypSendCancelConnect
                lblToSend.Text = .strToSend                  '送品先
                lblSendDate.Text = .strSendDate              '送品日
                lblLotID.Text = .strLotID                    'ﾛｯﾄID
                lblPdID.Text = .strPdId                      '機種
                lblBoxNo.Text = .strBoxNo                    '箱№
                lblWF.Text = .strWFQuantity                  '送品WF数
                lblChip.Text = .strChipQuantity              '送品Chip数
            
                mstrLastUpdate = .strLotLastUpdate              '最終更新日時
                mstrCarrierType = .strCarrierType               'ｷｬﾘｱﾀｲﾌﾟ
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN00F9_Disp"
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraCarrier.Paint, fraFrame.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub

    '関数名：cursor_Enter
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考：Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles _
                                                                        cmdCarrierSelect.Enter,
                                                                        txtCarrierID.Enter,
                                                                        cmdClose.Enter,
                                                                        cmdRegist.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '閉じるボタンの場合は自動Validate = OFF
            Case cmdClose.Name
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
            '上記以外は自動Validate = ON
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

End Class
