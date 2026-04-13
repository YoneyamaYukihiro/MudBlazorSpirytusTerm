'ﾌｧｲﾙ名：xxEN01K1.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：変更履歴確認
'作成日：2004/11/17 (Wed) 10:29:29 N.Kasai
'更新日：2004/11/17 (Wed) 10:29:29
'備　考：
'　　　：2005/06/01 (Wed) 10:27:20 S.Deguchi    不具合№832の対応でｺﾒﾝﾄ書式変更
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01K1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01K1    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01K1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01K1
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01K1)
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
    '======================================Private==========================================
    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    Private Const CMstrlot_eventlistVer             As String = "02.00"                 'ﾛｯﾄｲﾍﾞﾝﾄ履歴取得
    '@ﾛｰｶﾙ機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN01K1          '変更履歴確認
    '@ﾃｷｽﾄ
    Private Const CMlngMaxDispRow                   As Integer = 10                     'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '@変更履歴読込情報定数
    Private Const CMstrHistoryFlg1                  As String = "1"
    Private Const CMstrHistoryCntNo                 As String = "回目 "
    Private Const CMstrHistoryDeteFormat            As String = "yyyy/MM/dd HH:mm分"
    Private Const CMstrHistoryCntNow                As String = "今回分"
    Private Const CMstrHistoryChgName               As String = "－"
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private buttonProcessing                        As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                          'NSYS WindowCloseフラグ
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
    '機　能：
    '引　数：なし
    '戻り値：
    '作成日：2004/11/17 (Wed) 10:52:03 N.Kasai
    '更新日：2005/12/02 (Fri) 16:28:12 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 16:28:12 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub Form_Load()
        
        Dim lblnAns             As Boolean              '戻り値
        Dim ltypLotEventList    As LotEventList         'ﾛｯﾄｲﾍﾞﾝﾄ履歴構造体
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）

        Try

            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Me.Left = 0 - My.Settings.FormOffset
            Me.Top = 155
            
            '@ﾒｲﾝ画面初期化
            Call prvfrmxxEN01K1_Init()
            
            '@ｲﾍﾞﾝﾄ名格納
            lstrEventName = "Form_Load"
           
            With ptypRirekeiNextinfo
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(Me.Name, lstrEventName)
                
                '@ﾛｯﾄｲﾍﾞﾝﾄ履歴取得
                lblnAns = pubblnLotEventList_Sel(pstrSBID, CMstrlot_eventlistVer, .strLotID, ltypLotEventList)
                '@結果判定
                If lblnAns = True Then
                    '@ﾛｯﾄｲﾍﾞﾝﾄ履歴格納
                    Call prvLotEventHistory_Set(ltypLotEventList)
                    
                    '@ｲﾍﾞﾝﾄ履歴表示使用可
                    txtComments.Enabled = True
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Name, lstrEventName)
                Else
                    '@失敗の場合ﾚｽﾎﾟﾝｽ測定中止
                    Call pubResponseCancel(Me.Name, lstrEventName)
                End If
            End With
            
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
    '機　能：ｴﾝﾀｰで次項目に進む
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：未使用
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 14:22:53 N.Kasai
    '更新日：2004/11/18 (Thu) 14:22:53
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

            '@Enterｷｰ押下
            If e.KeyCode = Keys.Return Then
                Select Case ActiveControl.Name
                
                    '@ｺﾒﾝﾄ欄
                    Case txtComments.Name
                        Exit Sub
                        
                    '@上記以外
                    Case Else
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                        
                End Select
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
    '機　能：ﾌｫｰﾑのｸｴﾘｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel    ：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 14:25:25 N.Kasai
    '更新日：2004/11/18 (Thu) 14:25:25 N.Kasai
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
    '機　能：終了ﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/17 (Wed) 10:52:27 N.Kasai
    '更新日：2004/11/17 (Wed) 10:52:27
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
    '機　能：ｺﾒﾝﾄ▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 14:17:59 N.Kasai
    '更新日：2005/12/02 (Fri) 16:24:31 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 16:24:31 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUp.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtComments, CMlngMaxDispRow, cmdUP, cmdDown)

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
    '機　能：ｺﾒﾝﾄ▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 14:18:09 N.Kasai
    '更新日：2005/12/02 (Fri) 16:25:21 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 16:25:21 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtComments, CMlngMaxDispRow, cmdUP, cmdDown)

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

    '関数名：txtComments_Change
    '機　能：作業ﾒﾓ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 11:29:37 N.Kasai
    '更新日：2005/12/02 (Fri) 16:03:13 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 16:03:13 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub txtComments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtComments.Change

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComments_KeyUp
    '機　能：作業ﾒﾓｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 13:47:07 N.Kasai
    '更新日：2005/11/29 (Tue) 13:47:07
    '備　考：
    Private Sub txtComments_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtComments.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtComments, CMlngMaxDispRow, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：txtComments_MouseUp
    '機　能：作業ﾒﾓﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 13:48:44 N.Kasai
    '更新日：2005/11/29 (Tue) 13:48:44
    '備　考：
    Private Sub txtComments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtComments.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdUP, cmdDown, e.Button)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '***************************************************************************************
    '                                   * 関数の記述 *
    '***************************************************************************************
    '======================================Private==========================================

    '関数名：prvfrmxxEN01K1_Init
    '機　能：ﾌｫｰﾑのｸﾘｱ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/17 (Wed) 18:03:17 N.Kasai
    '更新日：2004/11/17 (Wed) 18:03:17
    '備　考：
    Private Sub prvfrmxxEN01K1_Init()

        Try
            
            '@表示内容のｸﾘｱ
            lblChangeCount.Text = vbNullString          '工順変更回数
            txtComments.Text = vbNullString             'ｺﾒﾝﾄ

            '@使用不可
            txtComments.Enabled = False                 'ｺﾒﾝﾄ欄
            cmdUP.Enabled = False                       '▲ﾎﾞﾀﾝ
            cmdDown.Enabled = False                     '▼ﾎﾞﾀﾝ
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01K1_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvLotEventHistory_Set
    '機　能：ﾛｯﾄ工順変更履歴の設定
    '引　数：ltypLotEventList：ﾛｯﾄｲﾍﾞﾝﾄ履歴構造体
    '戻り値：なし
    '作成日：2004/11/18 (Thu) 14:27:11 N.Kasai
    '更新日：2004/11/18 (Thu) 14:27:11
    '備　考：
    '　　　：2005/06/01 (Wed) 10:35:07 S.Deguchi    履歴に作業者名を追加
    Private Sub prvLotEventHistory_Set(ByRef ltypLotEventList As LotEventList)

        Dim llngCnt             As Integer              'ｶｳﾝﾀ
        Dim lstrHistory         As String               'ﾛｯﾄ履歴内容

        Try
            
            With ltypLotEventList
                '@ﾛｯﾄｲﾍﾞﾝﾄ履歴格納
                lstrHistory = vbNullString
                
                '@最新履歴から格納する
                For llngCnt = .lngLotEventCnt To 1 Step -1
                    With .typLotEvent(llngCnt - 1)
                        '@？回目を設定
                        lstrHistory = lstrHistory _
                                    & CMstrHistoryChgName _
                                    & Space(1) _
                                    & StrConv(CStr(llngCnt), vbNarrow) _
                                    & CMstrHistoryCntNo
                        
                        '@日時分&作業者名を設定
                        lstrHistory = lstrHistory _
                                    & Format$(CDate(.strEntryTime), CMstrHistoryDeteFormat) _
                                    & Space(1) _
                                    & .strEmpName _
                                    & Space(1) _
                                    & CMstrHistoryChgName _
                                    & vbCrLf
                        
                        '@履歴内容を設定
                        If .strComments <> vbNullString Then
                            lstrHistory = lstrHistory & .strComments & vbCrLf
                        End If
                    End With
                Next llngCnt
            
                '@変更履歴回数(ﾌｫｰﾏｯﾄ #,##0)
                lblChangeCount.Text = Format$(.lngLotEventCnt, CPstrDateFormatKanma)
            
                '@ﾛｯﾄｲﾍﾞﾝﾄ履歴格納
                txtComments.Text = lstrHistory
                txtComments.Locked = True
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvLotEventHistory_Set"
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

        Select Case m.Msg
            Case WM_ENDSESSION
                'OSのシャットダウンで閉じられようとしている場合
                mblnCloseFromControlMenu = True
                lblnSysCommandScClose = True

            Case WM_SYSCOMMAND
                Select Case (m.WParam.ToInt64() And &HFFF0L)
                    Case SC_CLOSE
                        '[×]ボタン、コントロールメニューの「閉じる」、
                        'コントロールボックスのダブルクリック、
                        'Atl+F4などにより閉じられようとしている場合
                        mblnCloseFromControlMenu = True

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
    End Sub


    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraRireki.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub

End Class
