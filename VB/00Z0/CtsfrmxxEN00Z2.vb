'ﾌｧｲﾙ名：xxEN00Z2.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾚﾁｸﾙ管理 ﾚﾁｸﾙ情報変更画面
'作成日：2004/08/24 (Tue) 09:21:49 Y.Yamagishi
'更新日：2004/08/24 (Tue) 09:21:49
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00Z2
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00Z2    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00Z2
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00Z2
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00Z2)
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
    '======================================Public===========================================
    '@機能ID
    Private Const CMstrLocalMenuKey                         As String = CPstrKeyEN00Z2

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                          As Integer = 16                        'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                      As Integer = 16                        'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColErrName                    As Integer = 0                         'ｴﾗｰ理由列番
    Private Const CMlngCmbGridColHoldID                     As Integer = 1                         'ｴﾗｰ理由ID列番（非表示項目）
    Private Const CMlngCmbDispCols                          As Integer = 1                         'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbRowHeight                         As Integer = 42                        'ﾘｽﾄ行の高さ

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_reasoncodeVer                    As String = "02.00"                 '理由ｺｰﾄﾞ取得
    Private Const CMstrrtclerrset__Ver                      As String = "01.00"                 'ﾚﾁｸﾙｴﾗｰ設定

    '@ﾃｷｽﾄ
    Private Const CMlngMaxDispRow                           As Integer = 4                         'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(ﾛｯﾄｺﾒﾝﾄ)

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    Private mtypMasItemList                                 As MasItemList                      'ｴﾗｰ理由構造体
    Private mstrReason                                      As String                           'ｴﾗｰ理由退避用変数
    Private buttonProcessing                                As Boolean                          'NSYS ボタン2度押し対策    
    Private mblnCloseFromControlMenu                        As Boolean                          'NSYS システムコマンドでの画面クローズ   
    Private mblnWindowClose                                 As Boolean                          'NSYS WindowCloseフラグ

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
    '機　能：画面起動
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 20:25:58 Y.Yamagishi
    '更新日：2005/12/02 (Fri) 11:46:15 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 11:46:15 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub Form_Load()

        Try
            
            '@画面初期化
            Call prvfrmxxEN00Z2_INit()
            
        '@↓2005/12/02 (Fri) 11:46:13 N.Kasai **************************************************
            '@ｴﾗｰｺﾒﾝﾄ上下ﾎﾞﾀﾝ使用不可
            cmdErrCommentsUp.Enabled = False
            cmdErrCommentsDown.Enabled = False
            '@ｴﾗｰ解除時ｺﾒﾝﾄ上下ﾎﾞﾀﾝ使用不可
            cmdErrreleseCommentsUp.Enabled = False
            cmdErrreleseCommentsDown.Enabled = False
        '@↑2005/12/02 (Fri) 11:46:13 N.Kasai **************************************************
            
            '@画面表示処理
            Call prvfrmxxEN00Z2_Disp()
            
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
    '機　能：ﾌｫｰｶｽ制御
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 15:45:11 Y.Yamagishi
    '更新日：2004/08/26 (Thu) 15:45:11
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
            
            Select Case e.KeyCode
                '@Enterｷｰの場合
                Case Keys.Return
                    Select Case ActiveControl.Name
                        '@ｴﾗｰ/ｴﾗｰ解除ｺﾒﾝﾄ
                        Case txtErrComments.Name, txtErrReleseComments.Name
                            '@ｴﾗｰ/ｴﾗｰ解除ｺﾒﾝﾄは改行がある為、Enterでﾌｫｰｶｽ移動しない
                            Exit Sub
                    End Select
                    
                    SendKeys.SendWait(CPstrSendKeysTab)
                    e.Handled = True
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

    '関数名：cmdClose_Click
    '機　能：ﾌﾟﾛｸﾞﾗﾑ終了
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 20:45:28 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 20:45:28
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

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑの終了
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 20:45:55 Y.Yamagishi
    '更新日：2004/08/25 (Wed) 20:45:55
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            ''@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            'If mblnCloseFromControlMenu Then
            '   RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            '    Call cmdClose_Click(cmdClose, New EventArgs)
            '    AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            'End If


            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If

            '@ｵﾌﾞｼﾞｪｸﾄの開放

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

    '関数名：cmdRegist_Click
    '機　能：確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 11:31:27 Y.Yamagishi
    '更新日：2004/08/26 (Thu) 11:31:27
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean          '登録戻り値(True/False)
        Dim ltypRtclErrSet          As RtclErrSet       'ﾚﾁｸﾙｴﾗｰ設定情報
        Dim lstrFormName            As String           'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
            If pstrUserID = vbNullString Then
                '@未入力の場合、投入中止
                Exit Sub
            End If

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "cmdRegist_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@処理区分
            If ptypRtclInfChg.blnErrBtnFlg = True Then
            '@ｴﾗｰ設定の場合
                With ltypRtclErrSet
                    '@ｼｽﾃﾑﾌﾞﾛｯｸｾｯﾄ
                    .strSbID = pstrSBID
                    '@Msgﾊﾞｰｼﾞｮﾝｾｯﾄ
                    .strMsgVer = CMstrrtclerrset__Ver
                    '@処理区分ｾｯﾄ
                    .strClassDivison = CPstrCD35
                    '@ﾚﾁｸﾙIDｾｯﾄ
                    .strReticleID = lblReticleID.Text
                    '@ｴﾗｰ理由ｾｯﾄ
                    .strReasonCode = cmbReason.Value
                    '@ｴﾗｰｺﾒﾝﾄｾｯﾄ
                    .strReasonComments = txtErrComments.Text
                    '@作業者ID
                    .strEmpID = pstrUserID
                    '@最終更新日
                    .strEditTime = ptypRtclInfChg.strEditTime
                End With
            
                '@ﾚﾁｸﾙ位置変更処理実行
                lblnAns = pubblnReticleErrSet_Ins(ltypRtclErrSet)
                If lblnAns = True Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001N, lblReticleID.Text)
                    
                    '@pubVsfInfo_Disp("<TRM1NI>$$レチクル[ %1 ]をエラーに設定しました。")
                    Call pubVsfInfo_Disp(pstrDMsg)
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                    
                    '@ｻﾌﾞ画面を閉じる
                    Call cmdClose_Click(sender,New EventArgs())
            
                    Exit Sub
                End If
            Else
            '@ｴﾗｰ解除の場合
                With ltypRtclErrSet
                    '@ｼｽﾃﾑﾌﾞﾛｯｸｾｯﾄ
                    .strSbID = pstrSBID
                    '@Msgﾊﾞｰｼﾞｮﾝｾｯﾄ
                    .strMsgVer = CMstrrtclerrset__Ver
                    '@処理区分ｾｯﾄ
                    .strClassDivison = CPstrCD2X
                    '@ﾚﾁｸﾙIDｾｯﾄ
                    .strReticleID = lblReticleID.Text
                    '@ｴﾗｰ理由ｾｯﾄ
                    .strReasonCode = vbNullString
                    '@ｴﾗｰｺﾒﾝﾄｾｯﾄ
                    .strReasonComments = txtErrReleseComments.Text
                    '@作業者ID
                    .strEmpID = pstrUserID
                    '@最終更新日
                    .strEditTime = ptypRtclInfChg.strEditTime
                End With
                '@ﾚﾁｸﾙ位置変更処理実行
                lblnAns = pubblnReticleErrSet_Ins(ltypRtclErrSet)
                If lblnAns = True Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001O, lblReticleID.Text)
                    
                    '@pubVsfInfo_Disp("<TRM1OI>$$レチクル[ %1 ]をエラー解除しました。")
                    Call pubVsfInfo_Disp(pstrDMsg)
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                    
                    '@ｻﾌﾞ画面を閉じる
                    Call cmdClose_Click(sender,New EventArgs())
            
                    Exit Sub
                End If
            End If
            
            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
            Call pubResponseCancel(lstrFormName, lstrEventName)
            
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

    '関数名：txtErrComments_Change
    '機　能：ｴﾗｰｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:08:52 Y.Yamagishi
    '更新日：2005/12/02 (Fri) 11:01:06 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 11:01:06 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub txtErrComments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtErrComments.Change

        Dim llngNowByte         As Integer  '現在のﾊﾞｲﾄ数

        Try
            
            '@現状のﾊﾞｲﾄ数を格納
            llngNowByte = txtErrComments.NowByte
            
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            
            '@退避用変数初期化
            mstrReason = vbNullString
            
        '@↓2005/12/02 (Fri) 11:01:03 N.Kasai **************************************************
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtErrComments, CMlngMaxDispRow, cmdErrCommentsUp, cmdErrCommentsDown)
        '@↑2005/12/02 (Fri) 11:01:03 N.Kasai **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtErrComments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtErrComments_KeyUp
    '機　能：ﾛｯﾄｺﾒﾝﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 13:47:07 N.Kasai
    '更新日：2005/11/29 (Tue) 13:47:07
    '備　考：
    Private Sub txtErrComments_KeyUp(ByVal sender As Object, ByVal e As keyEventArgs) Handles txtErrComments.KeyUp

        Try
            
            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtErrComments, CMlngMaxDispRow, cmdErrCommentsUp, cmdErrCommentsDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtErrComments_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：txtErrComments_MouseUp
    '機　能：ﾛｯﾄｺﾒﾝﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 13:48:44 N.Kasai
    '更新日：2005/11/29 (Tue) 13:48:44
    '備　考：
    Private Sub txtErrComments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtErrComments.MouseUp

        Try
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtErrComments, CMlngMaxDispRow, cmdErrCommentsUp, cmdErrCommentsDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtErrComments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub



    '関数名：txtErrReleseComments_Change
    '機　能：ｴﾗｰ解除ｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:08:36 Y.Yamagishi
    '更新日：2005/12/02 (Fri) 11:07:27 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 11:07:27 N.Kasai
    Private Sub txtErrReleseComments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtErrReleseComments.Change

        Dim llngNowByte      As Integer  '現在のﾊﾞｲﾄ数

        Try
            
            '@現状のﾊﾞｲﾄ数を格納
            llngNowByte = txtErrReleseComments.NowByte
            
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblReleaseLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            
        '@↓2005/12/02 (Fri) 11:06:56 N.Kasai **************************************************
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtErrReleseComments, CMlngMaxDispRow, cmdErrreleseCommentsUp, cmdErrreleseCommentsDown)
        '@↑2005/12/02 (Fri) 11:06:56 N.Kasai **************************************************

            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtErrReleseComments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtErrReleseComments_KeyUp
    '機　能：ﾛｯﾄｺﾒﾝﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 13:47:07 N.Kasai
    '更新日：2005/11/29 (Tue) 13:47:07
    '備　考：
    Private Sub txtErrReleseComments_KeyUp(ByVal sender As Object, ByVal e As keyEventArgs) Handles txtErrReleseComments.KeyUp

        Try
            
            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtErrReleseComments, CMlngMaxDispRow, cmdErrreleseCommentsUp, cmdErrreleseCommentsDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtErrReleseComments_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：txtErrReleseComments_MouseUp
    '機　能：ﾛｯﾄｺﾒﾝﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 13:48:44 N.Kasai
    '更新日：2005/11/29 (Tue) 13:48:44
    '備　考：
    Private Sub txtErrReleseComments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtErrReleseComments.MouseUp

        Try
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtErrReleseComments, CMlngMaxDispRow, cmdErrreleseCommentsUp, cmdErrreleseCommentsDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtErrReleseComments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbReason_Change
    '機　能：ｴﾗｰ理由変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:38:56 Y.Yamagishi
    '更新日：2004/08/26 (Thu) 14:38:56
    '備　考：
    Private Sub cmbReason_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbReason.Change

        Try
                        
            '@理由ｺﾝﾎﾞﾎﾞｯｸｽが選択された場合
            If cmbReason.Text <> vbNullString Then
                '@設定ﾎﾞﾀﾝ有効
                cmdRegist.Enabled = True
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbReason_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbReason_CloseUp
    '機　能：ｸﾛｰｽﾞｱｯﾌﾟ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/30 (Thu) 19:32:01 Y.Yamagishi
    '更新日：2004/09/30 (Thu) 19:32:01
    '備　考：
    Private Sub cmbReason_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbReason.CloseUp

        Try
            
            With cmbReason
                '@保留理由IDが選択されている場合
                If .Text <> vbNullString Then
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbReason_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdErrreleseCommentsUp_Click
    '機　能：ｴﾗｰ解除時ｺﾒﾝﾄ▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/30 (Mon) 18:15:00 Y.Yamagishi
    '更新日：2005/12/02 (Fri) 11:04:36 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 11:04:36 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdErrreleseCommentsUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdErrreleseCommentsUp.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
        '@↓2005/12/02 (Fri) 11:04:33 N.Kasai **************************************************
        '    '@ｴﾗｰ解除時ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtErrReleseComments)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtErrReleseComments, CMlngMaxDispRow, cmdErrreleseCommentsUp, cmdErrreleseCommentsDown)
        '@↑2005/12/02 (Fri) 11:04:33 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdErrreleseCommentsUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdErrreleseCommentsDown_Click
    '機　能：ｴﾗｰ解除時ｺﾒﾝﾄ▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/30 (Mon) 18:14:53 Y.Yamagishi
    '更新日：2005/12/02 (Fri) 11:06:06 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 11:06:06 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdErrreleseCommentsDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdErrreleseCommentsDown.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

        '@↓2005/12/02 (Fri) 11:05:41 N.Kasai **************************************************
        '    '@ｴﾗｰ解除時ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtErrReleseComments)
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtErrReleseComments, CMlngMaxDispRow, cmdErrreleseCommentsUp, cmdErrreleseCommentsDown)
        '@↑2005/12/02 (Fri) 11:05:41 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdErrreleseCommentsDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdErrCommentsUp_Click
    '機　能：ｴﾗｰ時ｺﾒﾝﾄ▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/30 (Mon) 18:14:13 Y.Yamagishi
    '更新日：2005/12/02 (Fri) 10:58:00 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 10:58:00 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdErrCommentsUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdErrCommentsUp.Click

        Try
           
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
        '@↓2005/12/02 (Fri) 10:57:57 N.Kasai **************************************************
        '    '@ｴﾗｰ時ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtErrComments)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtErrComments, CMlngMaxDispRow, cmdErrCommentsUp, cmdErrCommentsDown)
        '@↑2005/12/02 (Fri) 10:57:57 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdErrCommentsUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdErrCommentsDown_Click
    '機　能：ｴﾗｰ時ｺﾒﾝﾄ▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/30 (Mon) 18:14:05 Y.Yamagishi
    '更新日：2005/12/02 (Fri) 10:59:25 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 10:59:25 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdErrCommentsDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdErrCommentsDown.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
           

        '@↓2005/12/02 (Fri) 10:59:22 N.Kasai **************************************************
        '    '@ｴﾗｰ時ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtErrComments)
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtErrComments, CMlngMaxDispRow, cmdErrCommentsUp, cmdErrCommentsDown)
        '@↑2005/12/02 (Fri) 10:59:22 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdErrCommentsDown_Click"
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
    '関数名：prvfrmxxEN00Z2_INit
    '機　能：ﾒｲﾝﾌｫｰﾑ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/30 (Wed) 13:35:43 N.Kasai
    '更新日：2004/06/30 (Wed) 13:35:43
    '備　考：
    Private Sub prvfrmxxEN00Z2_INit()

        Dim llngNowByte As Integer          'ﾊﾞｲﾄ数格納

        Try
            
            '@初期値設定
            txtErrComments.Text = vbNullString                                  'ｴﾗｰｺﾒﾝﾄ
            txtErrReleseComments.Text = vbNullString                            'ｴﾗｰ解除ｺﾒﾝﾄ
            
            '@ｺﾝﾎﾞﾎﾞｯｸｽ設定
            With cmbReason
                .Clear
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColErrName                                'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColHoldID                               '値取得列
                .DirectInput = False                                            'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Text = vbNullString                                            '初期化
                .Font = New Font(.Font.FontFamily,CMlngCmbFontSize)             'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily,CMlngCmbGridFontSize) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  '行の高さ
                .ColAlignment(CMlngCmbGridColErrName) = TextAlignEnum.LeftCenter'左寄中央揃え
                .BackColor = SystemColors.Window
            End With
            
            '@ｴﾗｰｺﾒﾝﾄ初期化
            With txtErrComments
                .MultiLineEx = True                                             '複数行表示
                .ChrMaxByte = CPlngLotCommentsMaxByte                           '文字入力制限ﾊﾞｲﾄ数
                '@現状のﾊﾞｲﾄ数を格納
                llngNowByte = .NowByte
                '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            End With
            
            '@ｴﾗｰ解除ｺﾒﾝﾄ初期化
            With txtErrReleseComments
                .MultiLineEx = True                                             '複数行表示
                .ChrMaxByte = CPlngLotCommentsMaxByte                           '文字入力制限ﾊﾞｲﾄ数
                '@現状のﾊﾞｲﾄ数を格納
                llngNowByte = .NowByte
                '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                lblReleaseLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            End With
            
            '@ﾊﾞｲﾄ数非表示
            lblLengthCount.Visible = False
            lblReleaseLengthCount.Visible = False

            '@起動区分による処理対応
            Select Case ptypRtclInfChg.blnErrBtnFlg
            
                '@ｴﾗｰ設定
                Case True
                    '@ｴﾗｰ解除ｺﾒﾝﾄ非表示
                    txtErrReleseComments.Visible = False
                    cmdErrreleseCommentsUp.Visible = False
                    cmdErrreleseCommentsDown.Visible = False
                    lblReleaseLengthCount.Visible = False
                    lblTtl0.Visible = False
                    '@ｴﾗｰ理由有効
                    cmbReason.Enabled = True
                    '@ｴﾗｰｺﾒﾝﾄ有効
                    txtErrComments.Enabled = True
                    
                '@ｴﾗｰ解除
                Case False
                    '@ｴﾗｰ理由無効
                    cmbReason.Enabled = False
                    '@ｴﾗｰｺﾒﾝﾄ無効
                    txtErrComments.Enabled = False
                    '@ｴﾗｰｺﾒﾝﾄ有効
                    txtErrReleseComments.Enabled = True
                    
            End Select
            
            '@退避用変数初期化
            mstrReason = vbNullString

            '@終了時にValidateｲﾍﾞﾝﾄを実行しない
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN00Z2_INit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN00Z2_Disp
    '機　能：情報の表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 13:36:55 Y.Yamagishi
    '更新日：2004/08/26 (Thu) 13:36:55
    '備　考：
    Private Sub prvfrmxxEN00Z2_Disp()

        Dim lblnAns             As Boolean      'ﾛｯﾄ保留理由取得戻り値(True/False)
        Dim llngCnt             As Integer      'ｶｳﾝﾀ変数
        Dim lstrFormName        As String       'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName       As String       'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）


        Try
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "prvfrmxxEN00Z2_Disp"
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@引継ぎ情報の表示
            '@ﾚﾁｸﾙID引継ぎ
            If ptypRtclInfChg.strReticleID <> vbNullString Then
                lblReticleID.Text  = ptypRtclInfChg.strReticleID
            Else
                lblReticleID.Text  = vbNullString
            End If
            
            '@処理区分(ｴﾗｰ/ｴﾗｰ解除を判定し表示内容を変更する）
            Select Case ptypRtclInfChg.blnErrBtnFlg
                Case True
                    '@ｴﾗｰ理由取得結果
                    lblnAns = pubblnMasResonCode_Sel(CMstrmas_reasoncodeVer, CPstrCD2J, mtypMasItemList)
                    If lblnAns = False Then
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        Exit Sub
                    End If
                    
                    '@ｴﾗｰ理由ｾｯﾄ
                    With cmbReason
                        .Clear
                        For llngCnt = 0 To mtypMasItemList.lngListCnt-1
                            '@ｴﾗｰ理由名&ｴﾗｰ理由ｺｰﾄﾞ
                            .AddItem(mtypMasItemList.typeMasItem(llngCnt).strItemName & _
                                     vbTab & _
                                     mtypMasItemList.typeMasItem(llngCnt).strItemID)
                        Next llngCnt
                        '@ｴﾗｰ理由が1件の場合
                        If .ListCount = 1 Then
                            '@1件目表示
                            .ListIndex = 0
                            '@設定ﾎﾞﾀﾝ有効
                            cmdRegist.Enabled = True
                        Else
                            '@設定ﾎﾞﾀﾝ無効
                            cmdRegist.Enabled = False
                        End If
                        
                    End With
                    
                    '@ｴﾗｰｺﾒﾝﾄ設定（非表示）
                    Call prvErrComment_Init(False)
                    
                Case False
                    '@ｴﾗｰ理由取得結果
                    lblnAns = pubblnMasResonCode_Sel(CMstrmas_reasoncodeVer, CPstrCD2J, mtypMasItemList)
                    
                    If lblnAns = False Then
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        Exit Sub
                    End If
                    
                    '@ｴﾗｰ理由ｾｯﾄ
                    With cmbReason
                        .Clear
                        For llngCnt = 0 To mtypMasItemList.lngListCnt-1
                            '@ｴﾗｰ理由名&ｴﾗｰ理由ｺｰﾄﾞ
                            .AddItem(mtypMasItemList.typeMasItem(llngCnt).strItemName & _
                                     vbTab & _
                                     mtypMasItemList.typeMasItem(llngCnt).strItemID)
                            
                            '@引き継いだｴﾗｰ理由ｺｰﾄﾞと同じ場合
                            If mtypMasItemList.typeMasItem(llngCnt).strItemID = ptypRtclInfChg.strReasonCode Then
                                '@ﾘｽﾄｲﾝﾃﾞｯｸｽ設定
                                .ListIndex = llngCnt
                            End If
                        Next llngCnt
                    End With
                    
                    '@ｴﾗｰｺﾒﾝﾄｾｯﾄ
                    txtErrComments.Text = ptypRtclInfChg.strReasonComments
                     '@ｴﾗｰｺﾒﾝﾄ設定（表示）
                    Call prvErrComment_Init(True)
                    
            End Select
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)

            '@Form_Loadﾌﾗｸﾞ（正常）
            pblnFormLoad = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN00Z2_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvErrComment_Init
    '機　能：ｴﾗｰｺﾒﾝﾄ設定
    '引　数：lblnVisible：表示設定（True：ｴﾗｰ解除表示、False：ｴﾗｰ表示）
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 14:01:41 Y.Yamagishi
    '更新日：2004/08/26 (Thu) 14:01:41
    '備　考：
    Private Sub prvErrComment_Init(ByVal lblnVisible As Boolean)

        Try

            If lblnVisible = False Then
                '@ｴﾗｰの場合
                '@ｴﾗｰｺﾒﾝﾄ設定
                With txtErrComments
                    .BackColor = System.Drawing.SystemColors.Window
                    .GotBackColor = System.Drawing.SystemColors.Window
                    .Locked = False
                    .Enabled = True
                End With
                
        '@↓2005/12/02 (Fri) 11:44:28 N.Kasai **************************************************
        '        '@ｴﾗｰﾎﾞﾀﾝｺﾒﾝﾄ上下ﾎﾞﾀﾝ使用可
        '        cmdErrCommentsUp.Enabled = True
        '        cmdErrCommentsDown.Enabled = True
        '@↑2005/12/02 (Fri) 11:44:28 N.Kasai **************************************************
                
                '@ｴﾗｰ解除設定
                With txtErrReleseComments
                    .BackColor = System.Drawing.SystemColors.ControlLight
                    .Enabled = False
                End With
                
        '@↓2005/12/02 (Fri) 11:44:24 N.Kasai **************************************************
        '        '@ｴﾗｰ留解除時ｺﾒﾝﾄ上下ﾎﾞﾀﾝ使用不可
        '        cmdErrreleseCommentsUp.Enabled = False
        '        cmdErrreleseCommentsDown.Enabled = False
        '@↑2005/12/02 (Fri) 11:44:24 N.Kasai **************************************************
                
                '@ｴﾗｰｺﾒﾝﾄﾊﾞｲﾄ数表示
                lblLengthCount.Visible = True
                '@ｴﾗｰ解除ｺﾒﾝﾄﾊﾞｲﾄ数非表示
                lblReleaseLengthCount.Visible = False
                
                '@ｴﾗｰｺﾒﾝﾄﾊﾞｲﾄ数設定
                Call txtErrComments_Change(txtErrComments,New EventArgs())
            Else
                '@ｴﾗｰ解除の場合
                '@ｴﾗｰｺﾒﾝﾄ設定
                With txtErrComments
                    .BackColor = System.Drawing.SystemColors.ControlLight
                    .GotBackColor = System.Drawing.SystemColors.ControlLight
                    .Enabled = True
                    .Locked = True
                    .TabStop = False
                End With
                
        '        '@ｴﾗｰ時ｺﾒﾝﾄ上下ﾎﾞﾀﾝ使用可能
        '        cmdErrCommentsUp.Enabled = True
        '        cmdErrCommentsDown.Enabled = True
                
                '@ｴﾗｰ解除設定
                With txtErrReleseComments
                    .Visible = True
                    .BackColor = System.Drawing.SystemColors.Window
                    .Enabled = True
                End With
                
                '@ｴﾗｰ理由使用不可
                cmbReason.Enabled = False
                cmbReason.BackColor = System.Drawing.SystemColors.ControlLight
                
        '@↓2005/12/02 (Fri) 11:44:16 N.Kasai **************************************************
                '@ｴﾗｰ解除時ｺﾒﾝﾄ上下ﾎﾞﾀﾝ使用可
        '        cmdErrreleseCommentsUp.Enabled = True
        '        cmdErrreleseCommentsDown.Enabled = True
        '@↑2005/12/02 (Fri) 11:44:16 N.Kasai **************************************************
                cmdErrreleseCommentsUp.Visible = True
                cmdErrreleseCommentsDown.Visible = True
                
                '@ﾀｲﾄﾙ
                lblTtl0.Visible = True
                '@ｴﾗｰｺﾒﾝﾄﾊﾞｲﾄ数非表示
                lblLengthCount.Visible = False
                '@ｴﾗｰ解除ｺﾒﾝﾄﾊﾞｲﾄ数表示
                lblReleaseLengthCount.Visible = True
                
                '@ｴﾗｰｺﾒﾝﾄﾊﾞｲﾄ数設定
                Call txtErrReleseComments_Change(txtErrComments,New EventArgs())
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvErrComment_Init"
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

    '関数名：cursor_Enter
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考：Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles _
                                                                     cmdClose.Enter ,
                                                                     cmdErrCommentsUp.Enter ,
                                                                     cmdRegist.Enter ,
                                                                     cmdErrCommentsDown.Enter,
                                                                     cmdErrreleseCommentsUp.Enter,
                                                                     cmdErrreleseCommentsDown.Enter,
                                                                     cmbReason.Enter,
                                                                     txtErrComments.Enter ,
                                                                     txtErrReleseComments.Enter 

        '選択されている項目の名前で判定
        Select sender.Name
            '投入予定一覧ボタン、閉じるボタンの場合は自動Validate = OFF
            Case cmdClose.Name
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
            '上記以外は自動Validate = ON
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

End Class
