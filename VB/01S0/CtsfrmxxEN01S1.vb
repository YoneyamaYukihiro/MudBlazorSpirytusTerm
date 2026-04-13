'ﾌｧｲﾙ名：xxEN01S1.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：P/Rオーダー管理　登録フォーム
'作成日：2005/12/20 (Tue) 16:21:42 T.Kitagawa
'更新日：2005/12/20 (Tue) 16:21:42
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01S1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01S1    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01S1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01S1
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01S1)
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
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN01S1      'ﾛｰｶﾙ機能ID

    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    Private Const CMstrpr__chgorderVer          As String = "01.00"             'P/Rｵｰﾀﾞｰ登録・更新・削除

    Private Const CMlngMaxDispRow               As Integer = 12                 'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '@P/R区分
    Private Const CMstrPrOrderNameP             As String = "Pオーダー"          'Pｵｰﾀﾞｰ名称
    Private Const CMstrPrOrderNameR             As String = "Rオーダー"          'Rｵｰﾀﾞｰ名称

    '@vsfPrOrderListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfPrOrderListColNo          As Integer = 0              '№
    Private Const CMlngvsfPrOrderListColID          As Integer = 1              'PRｵｰﾀﾞｰID
    Private Const CMlngvsfPrOrderListColDept        As Integer = 2              '設定部門
    Private Const CMlngvsfPrOrderListColCost        As Integer = 3              '原価ｺｰﾄﾞ
    Private Const CMlngvsfPrOrderListColEditTime    As Integer = 4              '最終更新日時
    Private Const CMlngvsfPrOrderListColCommentsV   As Integer = 5              'ｵｰﾀﾞｰｺﾒﾝﾄ内容（非表示）
    Private Const CMlngvsfPrOrderListColCommentsD   As Integer = 6              'ｵｰﾀﾞｰｺﾒﾝﾄ

    '@表示Msg用
    Private Const CMstrDspMsgInsert                 As String = "登録"          '表示ﾒｯｾｰｼﾞ（登録）
    Private Const CMstrDspMsgUpdate                 As String = "修正"          '表示ﾒｯｾｰｼﾞ（修正）

    Private ReadOnly vbButtonFace                   As Color = SystemColors.ControlLight 'NSYS vbButtonFace定義
    Private ReadOnly vbWhite                        As Color = Color.White               'NSYS vbBlack定義

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
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
    '作成日：2005/12/20 (Tue) 16:26:11 T.Kitagawa
    '更新日：2005/12/20 (Tue) 16:26:11
    '備　考：
    Private Sub Form_Load()

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@画面情報の初期化
            Call prvfrmxxEN01S1_Init()

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
    '作成日：2005/12/20 (Tue) 16:27:17 T.Kitagawa
    '更新日：2005/12/20 (Tue) 16:27:17
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
                Call prvfrmxxEN01S1_Disp()

                'NSYS 初期フォーカス位置
                Call pubSetFocus(txtPrOrderID)
                Select Case ptypPrOrderRenkeiInfo.lngInsertMode
                    '@新規、ｺﾋﾟｰ登録
                    Case 1, 2
                        Call pubSetFocus(txtPrOrderID)
                    '@修正
                    Case 3
                        Call pubSetFocus(txtGlobalDept)
                End Select

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
    '作成日：2005/12/20 (Tue) 16:28:20 T.Kitagawa
    '更新日：2005/12/20 (Tue) 16:28:20
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

            '@次ﾌｫｰｶｽ設定
            Select Case e.KeyCode
                '@Enterｷｰの場合
                Case Keys.Return
                    Select Case ActiveControl.Name
                        Case txtComment.Name
                            '@ｺﾒﾝﾄ時はﾌｫｰｶｽ移動せず
                            Exit Sub
                        Case Else
                    End Select
                    '@次項目へｾｯﾄﾌｫｰｶｽ
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

    '関数名：Form_QueryUnload
    '機　能：終了処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2005/12/20 (Tue) 16:29:44 T.Kitagawa
    '更新日：2005/12/20 (Tue) 16:29:44
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
    '機　能：ﾌﾟﾛｸﾞﾗﾑ終了
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/20 (Tue) 16:30:49 T.Kitagawa
    '更新日：2005/12/20 (Tue) 16:30:49
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

    '関数名：cmdCancel_Click
    '機　能：全部取消ﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/20 (Tue) 18:41:46 T.Kitagawa
    '更新日：2006/04/25 (Tue) 18:21:34 T.Kitagawa
    '備　考：
    '　　　：2006/04/25 (Tue) 18:21:34 T.Kitagawa　原価ｺｰﾄﾞをﾎﾞﾃﾞｨ部へ移動（ﾕｰｻﾞ要望№0179）
    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click

        Dim llngNowByte     As Integer          '現在のﾊﾞｲﾄ数格納
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@画面ｸﾘｱ
            '@登録ﾓｰﾄﾞにより各項目ｸﾘｱを行う
            Select Case ptypPrOrderRenkeiInfo.lngInsertMode
                '@新規、ｺﾋﾟｰ登録
                Case 1, 2
                    '@画面情報の初期化
                    Call prvfrmxxEN01S1_Init()
                    Call pubSetFocus(txtPrOrderID)
                '@修正
                Case 3
                    '@設定部門の初期化
                    txtGlobalDept.Text = vbNullString
        '@↓2006/04/25 (Tue) 18:22:56 T.Kitagawa **************************************************
                    '@原価ｺｰﾄﾞの初期化
                    txtCostCode.Text = vbNullString
        '@↑2006/04/25 (Tue) 18:22:56 T.Kitagawa **************************************************
                    '@Textﾎﾞｯｸｽの初期化
                    With txtComment
                        '@文字数設定
                        .ChrMaxByte = CPlngLotCommentsMaxByte
                        '@表示部初期化
                        .Text = vbNullString
                        '@現状のﾊﾞｲﾄ数を格納
                        llngNowByte = .NowByte
                        '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                        lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
                    End With
                    '@ﾎﾞﾀﾝの使用不可
                    cmdCommentUp.Enabled = False                'ｽｸﾛｰﾙ上
                    cmdCommentDown.Enabled = False              'ｽｸﾛｰﾙ下
                    cmdCancel.Enabled = False                   '全取消ﾎﾞﾀﾝ
                    '@設定部門へﾌｫｰｶｽ設定
                    Call pubSetFocus(txtGlobalDept)
            End Select

            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ制御
            Call prvcmdEnable_Set()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCancel_Click"
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
    '作成日：2005/12/20 (Tue) 17:10:40 T.Kitagawa
    '更新日：2006/11/29 (Wed) 19:24:16 T.Kitagawa
    '備　考：
    '　　　：2006/11/29 (Wed) 19:24:16 T.Kitagawa　ﾊﾟｽﾜｰﾄﾞ確認機能追加（案件№01581）
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrFormName            As String               'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrFunctionID          As String               '機能ID
        Dim lstrActionID            As String               'ｱｸｼｮﾝID
        Dim lstrEmpID               As String               '作業者ID
        Dim lstrEmpName             As String               '作業者名
        Dim lstrSBID                As String               'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim ltypPrChgOrderReq       As PrChgOrderReq        'P/Rｵｰﾀﾞｰ登録構造体

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
            
        '@↓2006/11/29 (Wed) 19:25:11 T.Kitagawa **************************************************
        '    '@作業者ｺｰﾄﾞ入力
        '    frmxxCM0010.Show vbModal
            '@作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力
            frmxxCM0020.Instance.ShowDialog(Me)
            frmxxCM0020.Instance = Nothing
        '@↑2006/11/29 (Wed) 19:25:11 T.Kitagawa **************************************************
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "cmdRegist_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@実行権限の処理を追加
            lstrFunctionID = CPstrKeyEN01S0             '機能ID：EN01S0
            lstrActionID = CPstrPrOrderControl          '処理ID：P/Rオーダー管理
            lstrEmpID = pstrUserID                      'ﾕｰｻﾞｰID
            lstrEmpName = pstrUserName                  'ﾕｰｻﾞｰ名
            lstrSBID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ

            '@実行権限ﾁｪｯｸ
            lblnAns = pubAuthority_Chk(lstrFunctionID, lstrActionID, lstrEmpID, lstrEmpName, lstrSBID)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, lstrActionID)
                '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxEN01S0.Instance.Text, True, 16)
                Exit Sub
            End If

            '@P/Rｵｰﾀﾞｰ登録構造体を格納
            With ltypPrChgOrderReq
                .strMsgVer = CMstrpr__chgorderVer                   'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                '@処理区分
                Select Case ptypPrOrderRenkeiInfo.lngInsertMode
                    '@新規、ｺﾋﾟｰ登録
                    Case 1, 2
                        .strClassDivision = CPstrCD39               '処理区分（新規）
                    '@修正
                    Case 3
                        .strClassDivision = CPstrCD06               '処理区分（修正）
                End Select
                .strPROrderID = txtPrOrderID.Text                   'P/RオーダーID
                .strOrderComments = txtComment.Text                 'ｺﾒﾝﾄ
                .strGlobalDept = txtGlobalDept.Text                 '設定部門
                .strCostCode = txtCostCode.Text                     '原価ｺｰﾄﾞ
                .strEditTime = ptypPrOrderRenkeiInfo.strEditTime    '最終更新日時（新規時にはNullが設定）
                .strEmpID = pstrUserID                              '作業者ID
            End With
            
            '@P/Rｵｰﾀﾞｰ登録Msg（登録・変更）
            lblnAns = pubblnPrChgOrder_Upd(ltypPrChgOrderReq)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            '@表示ﾒｯｾｰｼﾞ変換(""<TRM57I>$$P/Rオーダーを%1しました。P/Rオーダー[%2]")
            '@処理区分
            Select Case ptypPrOrderRenkeiInfo.lngInsertMode
                '@新規、ｺﾋﾟｰ登録
                Case 1, 2
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0057, CMstrDspMsgInsert, ltypPrChgOrderReq.strPROrderID)
                '@修正
                Case 3
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0057, CMstrDspMsgUpdate, ltypPrChgOrderReq.strPROrderID)
            End Select
            Call pubVsfInfo_Disp(pstrDMsg)

            '@P/Rｵｰﾀﾞｰ登録連携情報の設定
            With ptypPrOrderRenkeiInfo
                .strPROrderID = ltypPrChgOrderReq.strPROrderID              'P/RｵｰﾀﾞｰID
            End With

            '@画面を終了する。
            Call cmdClose_Click(cmdClose, New EventArgs)

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

    '関数名：txtPrOrderID_Change
    '機　能：P/RｵｰﾀﾞｰID変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/20 (Tue) 19:47:37 T.Kitagawa
    '更新日：2005/12/20 (Tue) 19:47:37
    '備　考：
    Private Sub txtPrOrderID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtPrOrderID.Change

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞ中は処理中止
            If mblnFormLoadFlag = False Then
                Exit Sub
            End If
            
            '@P/R区分の表示を行う
            lblPrOrderName.Text = vbNullString
            Select Case Strings.Left$(txtPrOrderID.Text, 1)
                '@1文字目が"P"
                Case CPstrPrOrderClassP
                    lblPrOrderName.Text = CMstrPrOrderNameP      'Pオーダー
                '@1文字目が"R"
                Case CPstrPrOrderClassR
                    lblPrOrderName.Text = CMstrPrOrderNameR      'Rオーダー
            End Select
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ制御
            Call prvcmdEnable_Set()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPrOrderID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtPrOrderID_Validate
    '機　能：P/RｵｰﾀﾞｰIDﾁｪｯｸ処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/12/20 (Tue) 19:55:50 T.Kitagawa
    '更新日：2005/12/20 (Tue) 19:55:50
    '備　考：
    Private Sub txtPrOrderID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtPrOrderID.Validating

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            If txtPrOrderID.Text = vbNullString Then
                Exit Sub
            End If
            
            If txtPrOrderID.Locked = True Then
                Exit Sub
            End If
            
            '@1文字目がP、Rかﾁｪｯｸする
            Select Case Strings.Left$(txtPrOrderID.Text, 1)
                '@1文字目が"P"、"R"
                Case CPstrPrOrderClassP, CPstrPrOrderClassR
                    '@正常
                '@1文字目が"P"、"R"以外
                Case Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007I, CPstrPrOrderClassP, CPstrPrOrderClassR)
                    '@"<TRM7IW>$$P/Rオーダーは[%1]か[%2]から開始してください｡"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    e.Cancel = True
            End Select
            
            '@既存のP/Rｵｰﾀﾞｰとの重複ﾁｪｯｸ
            For llngCnt = 1 To frmxxEN01S0.Instance.vsfPrOrderList.Rows.Count - 1
                If frmxxEN01S0.Instance.vsfPrOrderList.GetData(llngCnt, CMlngvsfPrOrderListColID) = txtPrOrderID.Text Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007K)
                    '@"<TRM7KW>$$同一P/Rオーダーの指定はできません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    e.Cancel = True
                    Exit For
                End If
            Next llngCnt
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ制御
            Call prvcmdEnable_Set()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPrOrderID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCostCode_Change
    '機　能：原価ｺｰﾄﾞChange
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/21 (Wed) 10:53:41 T.Kitagawa
    '更新日：2005/12/21 (Wed) 10:53:41
    '備　考：
    Private Sub txtCostCode_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCostCode.Change

        Try

            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ制御
            Call prvcmdEnable_Set()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCostCode_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtGlobalDept_Change
    '機　能：設定部門Change
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/21 (Wed) 10:23:52 T.Kitagawa
    '更新日：2005/12/21 (Wed) 10:23:52
    '備　考：
    Private Sub txtGlobalDept_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtGlobalDept.Change
        
        Try

            '@ﾌｫｰﾑﾛｰﾄﾞ中は処理中止
            If mblnFormLoadFlag = False Then
                Exit Sub
            End If
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ制御
            Call prvcmdEnable_Set()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtGlobalDept_Change"
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
    '作成日：2005/12/20 (Tue) 16:34:58 T.Kitagawa
    '更新日：2005/12/20 (Tue) 16:34:58
    '備　考：
    Private Sub txtComment_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtComment.Change

        Dim llngNowByte As Integer 'ﾊﾞｲﾄ数

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞ中は処理中止
            If mblnFormLoadFlag = False Then
                Exit Sub
            End If
            
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtComment.NowByte

            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComment, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)

            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ制御
            Call prvcmdEnable_Set()
            
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

    '関数名：cmdCommentUp_Click
    '機　能：ｺﾒﾝﾄ▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/20 (Tue) 16:32:14 T.Kitagawa
    '更新日：2005/12/20 (Tue) 16:32:14
    '備　考：
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
    '作成日：2005/12/20 (Tue) 16:33:03 T.Kitagawa
    '更新日：2005/12/20 (Tue) 16:33:03
    '備　考：
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

    '関数名：txtComment_KeyUp
    '機　能：ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/12/20 (Tue) 16:36:30 T.Kitagawa
    '更新日：2005/12/20 (Tue) 16:36:30
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
    '作成日：2005/12/20 (Tue) 16:44:09 T.Kitagawa
    '更新日：2005/12/20 (Tue) 16:44:09
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

    '関数名：prvfrmxxEN01S1_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/20 (Tue) 17:12:11 T.Kitagawa
    '更新日：2006/04/25 (Tue) 18:07:40 T.Kitagawa
    '備　考：
    '　　　：2006/04/25 (Tue) 18:07:40 T.Kitagawa　原価ｺｰﾄﾞをﾎﾞﾃﾞｨ部へ移動（ﾕｰｻﾞ要望№0179）
    Private Sub prvfrmxxEN01S1_Init()

        Dim llngNowByte     As Integer          '現在のﾊﾞｲﾄ数格納

        Try

            '@ﾍｯﾀﾞｰ情報の初期化
            '@P/RｵｰﾀﾞｰID
            With txtPrOrderID
                .Text = vbNullString
                .Enabled = True
                .Locked = False
                .TabStop = True
                .GotHighLight = True
                .BackColor = vbWhite
                .GotBackColor = vbWhite
            End With
            '@原価ｺｰﾄﾞを使用不可
            With txtCostCode
                .Text = vbNullString
                .Enabled = True
                .Locked = False
                .TabStop = True
                .GotHighLight = True
                .BackColor = vbWhite
                .GotBackColor = vbWhite
            End With
            '@P/R区分
            lblPrOrderName.Text = vbNullString
            
            '@設定部門の初期化
            txtGlobalDept.Text = vbNullString
            
            '@Textﾎﾞｯｸｽの初期化
            With txtComment
                '@文字数設定
                .ChrMaxByte = CPlngLotCommentsMaxByte
                '@表示部初期化
                .Text = vbNullString
                '@現状のﾊﾞｲﾄ数を格納
                llngNowByte = .NowByte
                '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            End With

            '@ﾎﾞﾀﾝの使用不可
            cmdCommentUp.Enabled = False                'ｽｸﾛｰﾙ上
            cmdCommentDown.Enabled = False              'ｽｸﾛｰﾙ下
            cmdCancel.Enabled = False                   '全取消ﾎﾞﾀﾝ
            cmdRegist.Enabled = False                   '確定ﾎﾞﾀﾝ

            '@ﾍｯﾀﾞｰ部の使用可否設定
            '@登録ﾓｰﾄﾞにより使用可否設定を行う
            Select Case ptypPrOrderRenkeiInfo.lngInsertMode
                '@新規、ｺﾋﾟｰ登録
                Case 1, 2
                    '@初期化状態のまま変更可能
                '@修正
                Case 3
                    '@P/RｵｰﾀﾞｰIDを使用不可
                    With txtPrOrderID
                        .Enabled = True
                        .Locked = True
                        .TabStop = False
                        .GotHighLight = False
                        .BackColor = vbButtonFace
                        .GotBackColor = vbButtonFace
                    End With
        '@↓2006/04/25 (Tue) 18:07:18 T.Kitagawa **************************************************
        '            '@原価ｺｰﾄﾞを使用不可
        '            With txtCostCode
        '                .Enabled = True
        '                .Locked = True
        '                .TabStop = False
        '                .GotHighLight = False
        '                .BackColor = vbButtonFace
        '                .GotBackColor = vbButtonFace
        '            End With
        '@↑2006/04/25 (Tue) 18:07:18 T.Kitagawa **************************************************
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01S1_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN01S1_Disp
    '機　能：画面情報表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/20 (Tue) 17:45:02 T.Kitagawa
    '更新日：2005/12/20 (Tue) 17:45:02
    '備　考：
    Private Sub prvfrmxxEN01S1_Disp()

        Try

            '@画面表示
            '@登録ﾓｰﾄﾞにより前画面内容設定を行う
            Select Case ptypPrOrderRenkeiInfo.lngInsertMode
                '@新規
                Case 1
                    '@初期化状態のまま
                '@ｺﾋﾟｰ登録、修正
                Case 2, 3
                    With frmxxEN01S0.Instance.vsfPrOrderList
                        '@内容表示
                        txtPrOrderID.Text = .GetData(.Row, CMlngvsfPrOrderListColID)       'PRｵｰﾀﾞｰID
                        txtCostCode.Text = .GetData(.Row, CMlngvsfPrOrderListColCost)      '原価ｺｰﾄﾞ
                        txtGlobalDept.Text = .GetData(.Row, CMlngvsfPrOrderListColDept)    '設定部門
                        txtComment.Text = .GetData(.Row, CMlngvsfPrOrderListColCommentsV)  'ｵｰﾀﾞｰｺﾒﾝﾄ内容（非表示用改行有り）
                    End With
            End Select
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ制御
            Call prvcmdEnable_Set()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01S1_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmdEnable_Set
    '機　能：ｺﾏﾝﾄﾞﾎﾞﾀﾝ制御
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/20 (Tue) 18:18:02 T.Kitagawa
    '更新日：2006/04/25 (Tue) 18:10:16 T.Kitagawa
    '備　考：
    '　　　：2006/04/25 (Tue) 18:10:16 T.Kitagawa　原価ｺｰﾄﾞをﾎﾞﾃﾞｨ部へ移動（ﾕｰｻﾞ要望№0179）
    Private Sub prvcmdEnable_Set()

        Try

            Dim llngCnt         As Integer              '汎用ｶｳﾝﾀ
            Dim lblnEnable      As Boolean              '使用可否（False:不可、True：可能）
            
            '@全部取消ﾎﾞﾀﾝの制御
            lblnEnable = False
            '@登録ﾓｰﾄﾞにより全部取消ﾎﾞﾀﾝ制御を行う
            Select Case ptypPrOrderRenkeiInfo.lngInsertMode
                '@新規、ｺﾋﾟｰ登録
                Case 1, 2
                    '@全項目中で、内容設定がある場合に使用可能とする
                    If txtPrOrderID.Text <> vbNullString Or _
                        txtCostCode.Text <> vbNullString Or _
                        txtGlobalDept.Text <> vbNullString Or _
                        txtComment.Text <> vbNullString Then
                        lblnEnable = True       '使用可能
                    End If
                '@修正
                Case 3
                    '@ﾎﾞﾃﾞｨ中で、内容設定がある場合に使用可能とする
        '@↓2006/04/25 (Tue) 18:11:50 T.Kitagawa **************************************************
        '            If txtGlobalDept.Text <> vbNullString Or _
        '                txtComment.Text <> vbNullString Then
        '                lblnEnable = True       '使用可能
        '            End If
                    If txtCostCode.Text <> vbNullString Or _
                        txtGlobalDept.Text <> vbNullString Or _
                        txtComment.Text <> vbNullString Then
                        lblnEnable = True       '使用可能
                    End If
        '@↑2006/04/25 (Tue) 18:11:50 T.Kitagawa **************************************************
            End Select
            If lblnEnable = True Then
                cmdCancel.Enabled = True
            Else
                cmdCancel.Enabled = False
            End If
            
            '@確定ﾎﾞﾀﾝの制御
            lblnEnable = False
            '@P/RｵｰﾀﾞｰID、P/R区分、原価ｺｰﾄﾞが設定されている場合のみ可能とする
            If txtPrOrderID.Text <> vbNullString And _
                lblPrOrderName.Text <> vbNullString And _
                txtCostCode.Text <> vbNullString Then
                lblnEnable = True       '使用可能
            End If
            '@新規、ｺﾋﾟｰ登録の場合は重複ﾁｪｯｸを行う
            Select Case ptypPrOrderRenkeiInfo.lngInsertMode
                '@新規、ｺﾋﾟｰ登録
                Case 1, 2
                    If lblnEnable = True Then
                        '@既存のP/Rｵｰﾀﾞｰとの重複ﾁｪｯｸ
                        For llngCnt = 1 To frmxxEN01S0.Instance.vsfPrOrderList.Rows.Count - 1
                            If frmxxEN01S0.Instance.vsfPrOrderList.GetData(llngCnt, CMlngvsfPrOrderListColID) = txtPrOrderID.Text Then
                                lblnEnable = False
                                Exit For
                            End If
                        Next llngCnt
                    End If
            End Select
            If lblnEnable = True Then
                cmdRegist.Enabled = True
            Else
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

End Class
