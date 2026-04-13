'ﾌｧｲﾙ名：xxEN00Z1.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾚﾁｸﾙ管理 ﾚﾁｸﾙ情報変更画面
'作成日：2004/08/24 (Tue) 09:21:49 Y.Yamagishi
'更新日：2005/05/20 (Fri) 08:35:40 N.Kojima
'備　考：
'　　　：2005/06/16 (Thu) 15:19:39 S.Deguchi    空きSMIF一覧(EN00Z3)を空きキャリア一覧(CM00E0)へ移行
'　　　：2005/06/16 (Thu) 16:32:35 S.Deguchi    SetFocus対応で,OnError処理追加
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00Z1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00Z1    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00Z1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00Z1
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00Z1)
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
    Private Const CMstrLocalMenuKey                         As String = CPstrKeyEN00Z1

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrrtclstaterepVer                      As String = "01.00"                 'ﾚﾁｸﾙ状態報告
    Private Const CMstrcarrcurstateVer                      As String = "05.02"                 'ｷｬﾘｱ状態確認

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                          As Integer = 16                        'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                      As Integer = 16                        'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols                          As Integer = 1                         'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbValueCol1                         As Integer = 1                         '値取得列=1
    Private Const CMlngCmbGetCol0                           As Integer = 0                         'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=0

    '@その他
    Private Const CMstrOnlineFlag                           As String = "0"                     '0:装置稼動中／ｸﾗｲｱﾝﾄ

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    Private mtypCarrierEmptyList                            As CarrList                         'ｷｬﾘｱﾘｽﾄ取得結果格納
    Private mstrCarrierID                                   As String                           'ｷｬﾘｱID退避
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
    '更新日：2004/12/08 (Wed) 13:35:14 N.Kasai
    '備　考：
    '　　　：2004/12/08 (Wed) 13:35:14 N.Kasai  不要ﾒｯｾｰｼﾞをｺﾒﾝﾄｱｳﾄ
    Private Sub Form_Load()
        
        Try
            
            '@画面初期化
            '@ﾚﾁｸﾙID引継ぎ
            If ptypRtclInfChg.strReticleID <> vbNullString Then
                lblReticleID.Text  = ptypRtclInfChg.strReticleID
            Else
                lblReticleID.Text  = vbNullString
            End If
            
            '@SMIFID引継ぎ
            If ptypRtclInfChg.strSmifID <> vbNullString Then
                lblSMIFID.Text  = ptypRtclInfChg.strSmifID
            Else
                lblSMIFID.Text  = vbNullString
            End If
            
            '@確定ﾎﾞﾀﾝﾁｪｯｸ
            Call prvcmdRegist_Chk()

            '@退避ｷｬﾘｱID初期化
            mstrCarrierID = vbNullString

            '@Form_Loadﾌﾗｸﾞ（正常）
            pblnFormLoad = True
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Load"                  '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
                    SendKeys.SendWait(CPstrSendKeysTab)
                    e.Handled = True
            End Select
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_KeyDown"               '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_QueryUnload"           '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdClose_Click"             '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
    '更新日：2005/05/30 (Mon) 11:44:47 N.Kasai
    '備　考：2004/10/25 (Mon) 09:59:27 Y.Yamagishi　pubblnrtclchgposition_Updに処理区分追加(不具合改善№153)
    '　　　：2005/05/30 (Mon) 11:44:47 N.Kasai      ﾒｯｾｰｼﾞ統合対応(№613)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean          '登録戻り値(True/False)
        Dim lstrFormName            As String           'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim ltypRtclStaterep_Rec    As RtclStaterep_Rec
        
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

            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "cmdRegist_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@@ﾚﾁｸﾙ状態報告要求ﾒｯｾｰｼﾞ格納
            With ltypRtclStaterep_Rec
                '@SBID
                .strSbID = pstrSBID
                '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strMsgVer = CMstrrtclstaterepVer
                '@処理区分
                .strClassDivision = CPstrCD01               '("ZZ":装置(全自動)指定、"FF":搬送（ﾊﾞｰｺｰﾄﾞﾘｰﾀﾞｰ）、指定(01:ｸﾗｲｱﾝﾄ)）
                '@ｵﾝﾗｲﾝﾌﾗｸﾞ
                .strOnlineFlag = CMstrOnlineFlag            '(1:装置ｵﾝﾗｲﾝ時、0:装置稼動中／ｸﾗｲｱﾝﾄ  ※処理区分:"FF"時はNULL)
                '@WPID
                .strWpID = vbNullString                     '(処理区分："ZZ"のみ値を設定  ※処理区分:"FF"時はNULL)
                '@ﾘｽﾄｶｳﾝﾄ格納(ｸﾗｲｱﾝﾄからは必ず１件)
                .lngRtclStatereplist = 1
               
                '@ｴﾘｱ確保
                If .typRtclStatereplist Is Nothing 
                   .typRtclStatereplist = New List(Of RtclStatereplist) 
                End If
                
                Dim typRtclStatereplistmp As RtclStatereplist = New RtclStatereplist ()

                '@装置内ﾚﾁｸﾙﾘｽﾄ格納
                With typRtclStatereplistmp
                    '@ﾚﾁｸﾙID
                    .strReticleID = lblReticleID.Text
                    '@ﾚﾁｸﾙ状態ID
                    .strReticleStatusItemID = vbNullString          '(処理区分："ZZ"のみ値を設定 ※処理区分:"FF"時はNULL)
                    '@現在位置
                    .strCurrentPositionID = vbNullString            '(処理区分："ZZ","FF"のみ値を設定)
                    '@SMIFID
                    .strSmifID = txtCarrierID.Text
                    '@最終更新日時
                    .strEditTime = ptypRtclInfChg.strEditTime
                End With
                
                .typRtclStatereplist.Add(typRtclStatereplistmp)

                '@作業者ID
                .strEmpID = pstrUserID
            End With
            
            '@ﾚﾁｸﾙ状態報告
            lblnAns = pubblnrtclStaterep_Upd(ltypRtclStaterep_Rec)
            '@結果判定
            If lblnAns = True Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001P, lblReticleID.Text)
                
                '@pubVsfInfo_Disp("<TRM1PI>$$レチクル[ %1 ]の情報を変更しました。")
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@ｻﾌﾞ画面を閉じる
                Call cmdClose_Click(sender,New EventArgs())

                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
            Call pubResponseCancel(lstrFormName, lstrEventName)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdRegist_Click"               '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdCarrierSelect_Click
    '機　能：空きSMIF一覧表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/23 (Thu) 08:40:53 Y.Yamagishi
    '更新日：2004/09/23 (Thu) 08:40:53
    '備　考：
    '　　　：2005/06/16 (Thu) 15:19:39 S.Deguchi    空きSMIF一覧(EN00Z3)を空きキャリア一覧(CM00E0)へ移行
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
            
            '@Form_Loadﾌﾗｸﾞ（異常）
            pblnFormLoad = False
            
            '@ｷｬﾘｱﾀｲﾌﾟID引渡し
            pstrCarrierTypeID = CPstrCarrTypeSMIF
            
        '@↓2005/10/06 (Thu) 16:36:32 S.Deguchi **************************************************
            '@ｷｬﾘｱの洗浄条件：未洗浄可
            pstrCleanCondition = CPstrCarrierClean1
        '@↑2005/10/06 (Thu) 16:36:32 S.Deguchi **************************************************
            
            '@空きSMIF一覧表示
            frmxxCM00E0.Instance = New frmxxCM00E0()

            '@ﾀｲﾄﾙ変更
            frmxxCM00E0.Instance.Text = CPstrSubFormCM00E0SMIF
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM00E0.Instance = Nothing
                Exit Sub
            End If

            '@空きSMIF一覧表示
            frmxxCM00E0.Instance.ShowDialog(Me)
            frmxxCM00E0.Instance = Nothing
                 
            '@空きｷｬﾘｱが選択されている場合
            If pstrCarrierID <> vbNullString Then
                '@ｷｬﾘｱIDをｾｯﾄ
                txtCarrierID.Text = pstrCarrierID
                
                '@設定ﾎﾞﾀﾝ有効
                cmdRegist.Enabled = True
                
                '@設定ﾎﾞﾀﾝﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdRegist)
            Else
                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
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
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdCarrierSelect_Click"     '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtCarrierID_Change
    '機　能：ｷｬﾘｱIDﾁｪﾝｼﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/22 (Thu) 12:57:02 Y.Yamagishi
    '更新日：2004/04/22 (Thu) 12:57:02
    '備　考：
    Private Sub txtCarrierID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrierID.Change
        
        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@入力ﾁｪｯｸ
            Call prvcmdRegist_Chk()

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtCarrierID_Change"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierID_Validate
    '機　能：ｷｬﾘｱID入力ﾁｪｯｸ
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/09/23 (Thu) 11:15:54 Y.Yamagishi
    '更新日：2005/03/25 (Fri) 11:41:40 N.Kasai
    '備　考：
    '　　　：2005/03/25 (Fri) 11:41:40 N.Kasai      不具合.618　処理区分（2D→2J）変更
    Public Sub txtCarrierID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrierID.Validating
        
        Dim lblnAns                 As Boolean          '結果取得(True:正常,False:異常)
        Dim lstrFormName            As String           'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim ltypCarrCurstate        As CarrCurstate     'ｷｬﾘｱ状態確認要求構造体
        
        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            
            '@ｷｬﾘｱIDがある場合
            If Trim(txtCarrierID.Text) <> vbNullString Then
                '@ｷｬﾘｱIDの桁ﾁｪｯｸ
                If txtCarrierID.NowByte < txtCarrierID.ChrMaxByte Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                    
                    '@"キャリアIDは6桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    e.Cancel = True
                    
                    Call pubSetFocus(txtCarrierID)
                    
                    Exit Sub
                End If
            End If
            
            '@前回ｷｬﾘｱIDのﾁｪｯｸ
            If mstrCarrierID = txtCarrierID.Text Then
                '@前回ｷｬﾘｱIDと同じ場合
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "txtCarrierID_Validate"
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@ｷｬﾘｱ情報（要求）格納
            With ltypCarrCurstate
                .strCarrierId = txtCarrierID.Text       'ｷｬﾘｱID
                .strClassDivision = CPstrCD2J           '空ｷｬﾘｱﾁｪｯｸ（ﾚﾁｸﾙ）
                .strMsgVer = CMstrcarrcurstateVer       'MSGVER
                .strSbID = pstrSBID                     '処理区分
                .strCarrierTypeID = CPstrCarrTypeSMIF   'ｷｬﾘｱﾀｲﾌﾟ（SMIF限定）
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
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@TPALｷｬﾘｱIDのｸﾘｱ
                mstrCarrierID = vbNullString
                
                e.Cancel = True
                
                Call pubSetFocus(txtCarrierID)
                
                Exit Sub
            End If
            
            '@入力ﾁｪｯｸ
            Call prvcmdRegist_Chk()
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtCarrierID_Validate"      '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub


    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================

    '関数名：prvcmdRegist_Chk
    '機　能：入力ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/23 (Thu) 11:17:34 Y.Yamagishi
    '更新日：2004/09/23 (Thu) 11:17:34
    '備　考：
    Private Sub prvcmdRegist_Chk()
        
        Try
            
            '@変更前と変更後が同じ場合
            If lblSMIFID.Text = txtCarrierID.Text Then
                '@ﾛｯｸ
                cmdRegist.Enabled = False
                Exit Sub
            End If
            
            '@6桁以外の場合(空白可)
            If Len(txtCarrierID.Text) > txtCarrierID.ChrMaxByte _
                Or (Len(txtCarrierID.Text) < txtCarrierID.ChrMaxByte _
                And Len(txtCarrierID.Text) > 0) Then
                
                '@ﾛｯｸ
                cmdRegist.Enabled = False
                Exit Sub
           End If
           
            '@ﾛｯｸ解除
            cmdRegist.Enabled = True
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmdRegist_Chk"           '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
                

        End Select

        MyBase.WndProc(m)

        If lblnSysCommandScClose = True Then
            'NSYS SC_CLOSE 処理後 WM_CLOSE が発生しないでキャンセルされることもあるため、フラグを戻す
            'NSYS WM_CLOSE が発生していれば、すでにこの時点では画面は閉じている
            mblnCloseFromControlMenu = False
        End If        
    End Sub

    '関数名：cursor_Enter
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考：Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles _
                                                                     cmdClose.Enter ,
                                                                     cmdCarrierSelect.Enter ,
                                                                     cmdRegist.Enter ,
                                                                     txtCarrierID.Enter 

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
