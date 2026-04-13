'ﾌｧｲﾙ名：xxEN01S0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：P/Rオーダー管理　メインフォーム
'作成日：2005/12/19 (Mon) 11:00:13 T.Kitagawa
'更新日：2005/12/19 (Mon) 11:00:13
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01S0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01S0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01S0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01S0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01S0)
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
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2006/11/29 (Wed) 19:20:10 T.Kitagawa **************************************************
    'Private Const CMstrLocalVersion                 As String = "01.01"                 '機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion                 As String = "01.02"                 '機能ﾊﾞｰｼﾞｮﾝ
    '@↑2006/11/29 (Wed) 19:20:10 T.Kitagawa **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN01S0          'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrpr__orderlistVer             As String = "01.00"                 'P/Rｵｰﾀﾞｰﾘｽﾄ取得
    Private Const CMstrpr__chgorderVer              As String = "01.00"                 'P/Rｵｰﾀﾞｰ登録・更新・削除

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                  As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols                  As Integer = 1                      'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbGroupCols                 As Integer = 1                      '列方向ｸﾞﾙｰﾌﾟ数
    Private Const CMlngCMbSelectMode                As Integer = 1                      '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
    Private Const CMlngCmbRowHeight                 As Integer = 270                    'ﾘｽﾄ行の高さ
    Private Const CMlngCmbGridCol0                  As Integer = 0                      '選択列数

    '@vsfPrOrderListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfPrOrderListColNo          As Integer = 0                      '№
    Private Const CMlngvsfPrOrderListColID          As Integer = 1                      'PRｵｰﾀﾞｰID
    Private Const CMlngvsfPrOrderListColDept        As Integer = 2                      '設定部門
    Private Const CMlngvsfPrOrderListColCost        As Integer = 3                      '原価ｺｰﾄﾞ
    Private Const CMlngvsfPrOrderListColEditTime    As Integer = 4                      '最終更新日時（非表示）
    Private Const CMlngvsfPrOrderListColCommentsV   As Integer = 5                      'ｵｰﾀﾞｰｺﾒﾝﾄ内容（非表示）
    Private Const CMlngvsfPrOrderListColCommentsD   As Integer = 6                      'ｵｰﾀﾞｰｺﾒﾝﾄ

    '@vsfPrOrderListの定数宣言(幅)
    Private Const CMlngvsfPrOrderListColWNo         As Integer = 33                     '№
    Private Const CMlngvsfPrOrderListColWID         As Integer = 104                    'PRｵｰﾀﾞｰID
    Private Const CMlngvsfPrOrderListColWDept       As Integer = 257                    '設定部門
    Private Const CMlngvsfPrOrderListColWCost       As Integer = 86                     '原価ｺｰﾄﾞ
    Private Const CMlngvsfPrOrderListColWEditTime   As Integer = 140                    '最終更新日時
    Private Const CMlngvsfPrOrderListColWCommentsV  As Integer = 400                    'ｵｰﾀﾞｰｺﾒﾝﾄ内容（非表示）
    Private Const CMlngvsfPrOrderListColWCommentsD  As Integer = 400                    'ｵｰﾀﾞｰｺﾒﾝﾄ

    '@vsfPRListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfPrOrderListColNo          As String = "№"                     '№
    Private Const CMstrvsfPrOrderListColID          As String = "P/Rオーダー"            'P/RｵｰﾀﾞｰID
    Private Const CMstrvsfPrOrderListColDept        As String = "設定部門"               '設定部門
    Private Const CMstrvsfPrOrderListColCost        As String = "原価コード"             '原価コード
    Private Const CMstrvsfPrOrderListColEditTime    As String = "最終更新日時"           '最終更新日時
    Private Const CMstrvsfPrOrderListColCommentsV   As String = "オーダーコメント内容"   'ｵｰﾀﾞｰｺﾒﾝﾄ内容
    Private Const CMstrvsfPrOrderListColCommentsD   As String = "オーダーコメント"       'ｵｰﾀﾞｰｺﾒﾝﾄ

    '@vsf共通の定数宣言
    Private Const CMlngVsfRowTitle                  As Integer = 0                      'ﾀｲﾄﾙ行（行）
    Private Const CMlngVsfColTitle                  As Integer = 0                      'ﾀｲﾄﾙ行（列）
    Private Const CMlngVsfHFontSize                 As Integer = 11                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                   As Integer = 20                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngVsfHeight                    As Integer = 18                     '1行の高さ
    Private Const CMlngVbColorBlack                 As Integer = &H0&                   '黒色

    '@ｺﾒﾝﾄｽｸﾛｰﾙ制御用
    Private Const CMlngMaxDispRow                   As Integer = 6                      'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '@表示Msg用
    Private Const CMstrDspMsgDelete                 As String = "削除"                  '表示ﾒｯｾｰｼﾞ（削除）
    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    Private mtypChgSort                             As ChgSort                          'ｿｰﾄ保持用
    Private mblnFormLoadFlag                        As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True:1回目/False:1回目以外)
    Private buttonProcessing                        As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                          'NSYS WindowCloseフラグ
    Private mintPrOrderListRowBeforeSort            As Integer                          'NSYS PrOrderListのソート前選択行

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
        mintPrOrderListRowBeforeSort = 0
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
    '作成日：2005/12/19 (Mon) 11:52:44 T.Kitagawa
    '更新日：2005/12/19 (Mon) 11:52:44
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns             As Boolean              '結果格納
        Dim lstrFormName        As String               'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN01S0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
                '@異常終了の場合
                '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                Call pubMenuExpand_Disp()
                '@ﾌｫｰﾑを閉じる
                Call Form_QueryUnload(Me, New FormClosingEventArgs(CloseReason.UserClosing, False))
                Exit Sub
            End If

            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "Form_Load"

            '@ｿｰﾄ保持用構造体の初期化
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                Else
                    .typChgSortList.Clear()
                End If
                '@列幅変更ﾌﾗｸﾞ（未変更）
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = True

            '@画面情報の初期化
            Call prvfrmxxEN01S0_Init()

            '@Form_Loadﾌﾗｸﾞ（正常）
            pblnFormLoad = True

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
    '作成日：2005/12/19 (Mon) 18:38:11 T.Kitagawa
    '更新日：2005/12/19 (Mon) 18:38:11
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrFormName            As String               'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理分岐
            If mblnFormLoadFlag = True Then
                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞを戻す
                mblnFormLoadFlag = False
                
                '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
                lstrFormName = Me.Name
                lstrEventName = "Form_Activate"
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(lstrFormName, lstrEventName)
                
                '@一覧情報取得処理
                lblnAns = prvblnPrOrderList_Proc()
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@Escﾎﾞﾀﾝを有効
                    '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
                    Me.CancelButton = cmdClose
                    
                    Exit Sub
                Else
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                    
                    '@一覧へﾌｫｰｶｽｾｯﾄ
                    If vsfPrOrderList.Enabled = True Then
                        Call pubSetFocus(vsfPrOrderList)
                    End If
                End If
                    
                '@Escﾎﾞﾀﾝを有効
                '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
                Me.CancelButton = cmdClose
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "Form_Activate"          '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ値
    '戻り値：なし
    '作成日：2005/12/19 (Mon) 18:45:26 T.Kitagawa
    '更新日：2005/12/19 (Mon) 18:45:26
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@砂時計の場合はｷｰﾎﾞｰﾄﾞ入力を抑止
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If

            '@ﾌｫｰﾑﾛｯｸ時ｷｰﾎﾞｰﾄﾞ入力を抑止
            If Me.Enabled = False Then
                e.Handled = True
                Exit Sub
            End If

            '@次ﾌｫｰｶｽ設定
            Select Case e.KeyCode
                '@Enterｷｰの場合
                Case Keys.Return
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
    '機　能：ﾌｫｰﾑ終了処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2005/12/19 (Mon) 18:47:23 T.Kitagawa
    '更新日：2005/12/19 (Mon) 18:47:23
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try

            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs())
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If

            '@ｿｰﾄ保持用構造体のｸﾘｱ
            If mtypChgSort.typChgSortList Is Nothing Then
                mtypChgSort.typChgSortList = New List(Of ChgSortList)
            Else
                mtypChgSort.typChgSortList.Clear()
            End If

            '@ActInitﾌﾗｸﾞの判定
            If pblnActInitFlg = True Then
                '@Actを自前で初期化した場合

                '@ACTｵﾌﾞｼﾞｪｸﾄの開放
                lblnAnsTerm = pubblnAct_Term
                If lblnAnsTerm = True Then
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                End If
            Else
                '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                Call pubMenuExpand_Disp()
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
    '機　能：閉じる処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/19 (Mon) 18:48:30 T.Kitagawa
    '更新日：2005/12/19 (Mon) 18:48:30
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim llngRet         As Integer              '関数戻り値
        Dim ltypCommonInfo  As CommonInfo

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@終了関数を実行する
            llngRet = publngEnd_Proc(CPstrKeyEN01S0, ltypCommonInfo)

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

    '関数名：cmdNowList_Click
    '機　能：最新取得
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/19 (Mon) 18:49:25 T.Kitagawa
    '更新日：2005/12/19 (Mon) 18:49:25
    '備　考：
    Private Sub cmdNowList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowList.Click

        Dim lblnAns                 As Boolean              '結果格納
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
 
           '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@P/Rｵｰﾀﾞｰ登録連携情報のｸﾘｱ
            With ptypPrOrderRenkeiInfo
                .lngInsertMode = 0                                      '登録ﾓｰﾄﾞなし
                .strPROrderID = vbNullString                            'P/RｵｰﾀﾞｰID
                .strEditTime = vbNullString                             '最終更新日時
            End With

            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "cmdNowList_Click"

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@一覧情報取得処理
            lblnAns = prvblnPrOrderList_Proc()
            '@結果判定
            If lblnAns = False Then

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@ﾌｫｰｶｽそのまま
                Call pubSetFocus(cmdNowList)

                Exit Sub
            Else

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)

                '@一覧へﾌｫｰｶｽｾｯﾄ
                If vsfPrOrderList.Enabled = True Then
                    Call pubSetFocus(vsfPrOrderList)
                    '@P/Rｵｰﾀﾞｰ一覧、ｺﾒﾝﾄの使用可否
                    If vsfPrOrderList.Rows.Count > 1 Then
                        txtComments.Enabled = True
                        '@ｶﾚﾝﾄ行ﾁｪｯｸ
                        Call vsfPrOrderList_EnterCell(vsfPrOrderList, New EventArgs())
                    Else
                        vsfPrOrderList.Enabled = False
                        txtComments.Enabled = False
                        txtComments.Text = vbNullString
                    End If
                    
                Else
                    Call pubSetFocus(cmdNowList)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdNowList_Click"       '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdInsert_Click
    '機　能：新規登録ﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/20 (Tue) 12:10:23 T.Kitagawa
    '更新日：2005/12/20 (Tue) 12:10:23
    '備　考：
    Private Sub cmdInsert_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdInsert.Click
        
        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrFormName            As String               'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        
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
            
            '@P/Rｵｰﾀﾞｰ登録連携情報の設定
            With ptypPrOrderRenkeiInfo
                .lngInsertMode = CPlngPrOrderInsertMode1        '新規ﾓｰﾄﾞ
                .strPROrderID = vbNullString                    'P/RｵｰﾀﾞｰID
                .strEditTime = vbNullString                     '最終更新日時
            End With
            
            '@P/Rｵｰﾀﾞｰ登録画面表示
            frmxxEN01S1.Instance.ShowDialog(Me)
            frmxxEN01S1.Instance = Nothing

            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "cmdUpdate_Click"

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@一覧情報取得処理
            lblnAns = prvblnPrOrderList_Proc()
            '@結果判定
            If lblnAns = False Then

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@ﾌｫｰｶｽそのまま
                Call pubSetFocus(cmdNowList)

                Exit Sub
            Else

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)

                '@一覧へﾌｫｰｶｽｾｯﾄ
                If vsfPrOrderList.Enabled = True Then
                    Call pubSetFocus(vsfPrOrderList)
                Else
                    Call pubSetFocus(cmdNowList)
                End If
            End If

            '@P/Rｵｰﾀﾞｰ一覧、ｺﾒﾝﾄの使用可否
            If vsfPrOrderList.Rows.Count > 1 Then
                vsfPrOrderList.Enabled = True
                txtComments.Enabled = True
                '@P/Rｵｰﾀﾞｰ登録画面から復帰時はP/Rｵｰﾀﾞ一覧の該当ｵｰﾀﾞｰへﾌｫｰｶｽを設定
                If ptypPrOrderRenkeiInfo.strPROrderID <> vbNullString Then
                    With vsfPrOrderList
                        For llngCnt = 1 To .Rows.Count - 1
                            If .GetData(llngCnt, CMlngvsfPrOrderListColID) = ptypPrOrderRenkeiInfo.strPROrderID Then
                                .Row = llngCnt
                                Exit For
                            End If
                        Next llngCnt
                    End With
                End If
                '@ﾌｫｰｶｽ移動
                vsfPrOrderList.ShowCell(vsfPrOrderList.Row, CMlngvsfPrOrderListColID)
                '@ｶﾚﾝﾄ行ﾁｪｯｸ
                Call vsfPrOrderList_EnterCell(vsfPrOrderList, New EventArgs())
            Else
                vsfPrOrderList.Enabled = False
                txtComments.Enabled = False
                txtComments.Text = vbNullString
            End If
            
            '@P/Rｵｰﾀﾞｰ登録連携情報のｸﾘｱ
            With ptypPrOrderRenkeiInfo
                .lngInsertMode = 0                                      '登録ﾓｰﾄﾞなし
                .strPROrderID = vbNullString                            'P/RｵｰﾀﾞｰID
                .strEditTime = vbNullString                             '最終更新日時
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdInsert_Click"        '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdCopyInsert_Click
    '機　能：ｺﾋﾟｰ登録ﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/19 (Mon) 20:34:00 T.Kitagawa
    '更新日：2005/12/19 (Mon) 20:34:00
    '備　考：
    Private Sub cmdCopyInsert_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCopyInsert.Click
        
        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrFormName            As String               'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        
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
            
            '@P/Rｵｰﾀﾞｰ登録連携情報の設定
            With ptypPrOrderRenkeiInfo
                .lngInsertMode = CPlngPrOrderInsertMode2        'ｺﾋﾟｰ登録ﾓｰﾄﾞ
                .strPROrderID = vbNullString                    'P/RｵｰﾀﾞｰID
                .strEditTime = vbNullString                     '最終更新日時
            End With
            
            '@P/Rｵｰﾀﾞｰ登録画面表示
            frmxxEN01S1.Instance.ShowDialog(Me)
            frmxxEN01S1.Instance = Nothing

            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "cmdCopyInsert_Click"

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@一覧情報取得処理
            lblnAns = prvblnPrOrderList_Proc()
            '@結果判定
            If lblnAns = False Then

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@ﾌｫｰｶｽそのまま
                Call pubSetFocus(cmdNowList)

                Exit Sub
            Else

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)

                '@一覧へﾌｫｰｶｽｾｯﾄ
                If vsfPrOrderList.Enabled = True Then
                    Call pubSetFocus(vsfPrOrderList)
                Else
                    Call pubSetFocus(cmdNowList)
                End If
            End If

            '@P/Rｵｰﾀﾞｰ一覧、ｺﾒﾝﾄの使用可否
            If vsfPrOrderList.Rows.Count > 1 Then
                vsfPrOrderList.Enabled = True
                txtComments.Enabled = True
                '@P/Rｵｰﾀﾞｰ登録画面から復帰時はP/Rｵｰﾀﾞ一覧の該当ｵｰﾀﾞｰへﾌｫｰｶｽを設定
                If ptypPrOrderRenkeiInfo.strPROrderID <> vbNullString Then
                    With vsfPrOrderList
                        For llngCnt = 1 To .Rows.Count - 1
                            If .GetData(llngCnt, CMlngvsfPrOrderListColID) = ptypPrOrderRenkeiInfo.strPROrderID Then
                                .Row = llngCnt
                                Exit For
                            End If
                        Next llngCnt
                    End With
                End If
                '@ﾌｫｰｶｽ移動
                vsfPrOrderList.ShowCell(vsfPrOrderList.Row, CMlngvsfPrOrderListColID)
                '@ｶﾚﾝﾄ行ﾁｪｯｸ
                Call vsfPrOrderList_EnterCell(vsfPrOrderList, New EventArgs())
            Else
                vsfPrOrderList.Enabled = False
                txtComments.Enabled = False
                txtComments.Text = vbNullString
            End If
            
            '@P/Rｵｰﾀﾞｰ登録連携情報のｸﾘｱ
            With ptypPrOrderRenkeiInfo
                .lngInsertMode = 0                                      '登録ﾓｰﾄﾞなし
                .strPROrderID = vbNullString                            'P/RｵｰﾀﾞｰID
                .strEditTime = vbNullString                             '最終更新日時
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdCopyInsert_Click"    '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdUpdate_Click
    '機　能：修正ﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/19 (Mon) 20:34:00 T.Kitagawa
    '更新日：2005/12/19 (Mon) 20:34:00
    '備　考：
    Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUpdate.Click
        
        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrFormName            As String               'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        
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
            
            '@P/Rｵｰﾀﾞｰ登録連携情報の設定
            With ptypPrOrderRenkeiInfo
                .lngInsertMode = CPlngPrOrderInsertMode3                                                            '修正ﾓｰﾄﾞ
                .strPROrderID = vsfPrOrderList.GetData(vsfPrOrderList.Row, CMlngvsfPrOrderListColID)       'P/RｵｰﾀﾞｰID
                .strEditTime = vsfPrOrderList.GetData(vsfPrOrderList.Row, CMlngvsfPrOrderListColEditTime)  '最終更新日時
            End With
            
            '@P/Rｵｰﾀﾞｰ登録画面表示
            frmxxEN01S1.Instance.ShowDialog(Me)
            frmxxEN01S1.Instance = Nothing

            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "cmdUpdate_Click"

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@一覧情報取得処理
            lblnAns = prvblnPrOrderList_Proc()
            '@結果判定
            If lblnAns = False Then

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@ﾌｫｰｶｽそのまま
                Call pubSetFocus(cmdNowList)

                Exit Sub
            Else

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)

                '@一覧へﾌｫｰｶｽｾｯﾄ
                If vsfPrOrderList.Enabled = True Then
                    Call pubSetFocus(vsfPrOrderList)
                Else
                    Call pubSetFocus(cmdNowList)
                End If
            End If
            
            '@P/Rｵｰﾀﾞｰ一覧、ｺﾒﾝﾄの使用可否
            If vsfPrOrderList.Rows.Count > 1 Then
                vsfPrOrderList.Enabled = True
                txtComments.Enabled = True
                '@P/Rｵｰﾀﾞｰ登録画面から復帰時はP/Rｵｰﾀﾞ一覧の該当ｵｰﾀﾞｰへﾌｫｰｶｽを設定
                If ptypPrOrderRenkeiInfo.strPROrderID <> vbNullString Then
                    With vsfPrOrderList
                        For llngCnt = 1 To .Rows.Count - 1
                            If .GetData(llngCnt, CMlngvsfPrOrderListColID) = ptypPrOrderRenkeiInfo.strPROrderID Then
                                .Row = llngCnt
                                Exit For
                            End If
                        Next llngCnt
                    End With
                End If
                '@ﾌｫｰｶｽ移動
                vsfPrOrderList.ShowCell(vsfPrOrderList.Row, CMlngvsfPrOrderListColID)
                '@ｶﾚﾝﾄ行ﾁｪｯｸ
                Call vsfPrOrderList_EnterCell(vsfPrOrderList, New EventArgs())
            Else
                vsfPrOrderList.Enabled = False
                txtComments.Enabled = False
                txtComments.Text = vbNullString
            End If
            
            '@P/Rｵｰﾀﾞｰ登録連携情報のｸﾘｱ
            With ptypPrOrderRenkeiInfo
                .lngInsertMode = 0                                      '登録ﾓｰﾄﾞなし
                .strPROrderID = vbNullString                            'P/RｵｰﾀﾞｰID
                .strEditTime = vbNullString                             '最終更新日時
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdUpdate_Click"        '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdDelete_Click
    '機　能：削除ﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/20 (Tue) 12:17:30 T.Kitagawa
    '更新日：2006/11/29 (Wed) 19:21:19 T.Kitagawa
    '備　考：
    '　　　：2006/11/29 (Wed) 19:21:19 T.Kitagawa　ﾊﾟｽﾜｰﾄﾞ確認機能追加（案件№01581）
    Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
        
        Dim lblnAns                 As Boolean              '結果格納
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
            
        '@↓2006/11/29 (Wed) 19:21:52 T.Kitagawa **************************************************
        '    '@作業者ｺｰﾄﾞ入力
        '    frmxxCM0010.Show vbModal
            '@作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力
            frmxxCM0020.Instance.ShowDialog(Me)
            frmxxCM0020.Instance = Nothing
        '@↑2006/11/29 (Wed) 19:21:52 T.Kitagawa **************************************************
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "cmdDelete_Click"
            
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
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                Exit Sub
            End If

            '@P/Rｵｰﾀﾞｰ登録構造体を格納（削除）
            With ltypPrChgOrderReq
                .strMsgVer = CMstrpr__chgorderVer                                                                  'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strClassDivision = CPstrCD05                                                                      '処理区分：削除
                .strPROrderID = vsfPrOrderList.GetData(vsfPrOrderList.Row, CMlngvsfPrOrderListColID)               'P/RオーダーID
                .strOrderComments = vsfPrOrderList.GetData(vsfPrOrderList.Row, CMlngvsfPrOrderListColCommentsV)    'ｺﾒﾝﾄ
                .strGlobalDept = vsfPrOrderList.GetData(vsfPrOrderList.Row, CMlngvsfPrOrderListColDept)            '設定部門
                .strCostCode = vsfPrOrderList.GetData(vsfPrOrderList.Row, CMlngvsfPrOrderListColCost)              '原価ｺｰﾄﾞ
                .strEditTime = vsfPrOrderList.GetData(vsfPrOrderList.Row, CMlngvsfPrOrderListColEditTime)          '最終更新日時
                .strEmpID = pstrUserID                                                                             '作業者ID
            End With
            
            '@P/Rｵｰﾀﾞｰ登録Msg（削除）
            lblnAns = pubblnPrChgOrder_Upd(ltypPrChgOrderReq)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Exit Sub
            End If
            
            '@表示ﾒｯｾｰｼﾞ変換(""<TRM57I>$$P/Rオーダーを%1しました。P/Rオーダー[%2]")
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0057, CMstrDspMsgDelete, ltypPrChgOrderReq.strPROrderID)
            Call pubVsfInfo_Disp(pstrDMsg)
            
            '@P/Rｵｰﾀﾞｰ登録連携情報のｸﾘｱ
            With ptypPrOrderRenkeiInfo
                .lngInsertMode = 0                                      '登録ﾓｰﾄﾞなし
                .strPROrderID = vbNullString                            'P/RｵｰﾀﾞｰID
                .strEditTime = vbNullString                             '最終更新日時
            End With

            '@一覧情報取得処理
            lblnAns = prvblnPrOrderList_Proc()
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Exit Sub
            Else
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                '@一覧へﾌｫｰｶｽｾｯﾄ
                If vsfPrOrderList.Enabled = True Then
                    Call pubSetFocus(vsfPrOrderList)
                Else
                    Call pubSetFocus(cmdNowList)
                End If
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdDelete_Click"        '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfPrOrderList_BeforeSort
    '機　能：ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2005/12/19 (Mon) 19:06:59 T.Kitagawa
    '更新日：2005/12/19 (Mon) 19:06:59
    '備　考：
    Private Sub vsfPrOrderList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfPrOrderList.BeforeSort

        Try

            'NSYS ソート時はBeforeRowColChange/EnterCellを抑制する
            RemoveHandler vsfPrOrderList.BeforeRowColChange, AddressOf vsfPrOrderList_BeforeRowColChange
            RemoveHandler vsfPrOrderList.EnterCell, AddressOf vsfPrOrderList_EnterCell
            mintPrOrderListRowBeforeSort = vsfPrOrderList.Row 'NSYS ソート前の選択行を保持

            'NSYS データ行がない場合は処理を抜ける
            If vsfPrOrderList.Rows.Count <= vsfPrOrderList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ順を格納
            With mtypChgSort
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                Dim ltypChgSortListTmp As ChgSortList
                '@ｿｰﾄ列番号を格納
                ltypChgSortListTmp.lngCol = e.Col
                '@並び替え方法を格納（昇順/降順）
                ltypChgSortListTmp.lngOrder = e.Order
                .typChgSortList.Add(ltypChgSortListTmp)
            End With

            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列）
            Call pubVsfBeforeSort(vsfPrOrderList, CMlngVsfRowTitle)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfPrOrderList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfPrOrderList_AfterSort
    '機　能：ｿｰﾄ後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2005/12/19 (Mon) 19:02:39 T.Kitagawa
    '更新日：2005/12/19 (Mon) 19:02:39
    '備　考：
    Private Sub vsfPrOrderList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfPrOrderList.AfterSort
        
        Try
            'NSYS ソート前の選択行が有効行でない場合、ヘッダを選択行とする
            If mintPrOrderListRowBeforeSort <  vsfPrOrderList.Rows.Fixed Then
                vsfPrOrderList.Row = 0
            End If
            'NSYS ソート時はBeforeRowColChange/EnterCellイベントの抑制を解除する
            AddHandler vsfPrOrderList.BeforeRowColChange, AddressOf vsfPrOrderList_BeforeRowColChange
            AddHandler vsfPrOrderList.EnterCell, AddressOf vsfPrOrderList_EnterCell

            'NSYS データ行がない場合は処理を抜ける
            If vsfPrOrderList.Rows.Count <= vsfPrOrderList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ後のｶﾚﾝﾄ行設定（ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁）
            Call pubVsfAfterSort(vsfPrOrderList, CMlngVsfRowTitle)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfPrOrderList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfPrOrderList_BeforeRowColChange
    '機　能：ｸﾞﾘｯﾄﾌｫｰｶｽ移動
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/12/19 (Mon) 19:04:13 T.Kitagawa
    '更新日：2005/12/19 (Mon) 19:04:13
    '備　考：
    Private Sub vsfPrOrderList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfPrOrderList.BeforeRowColChange
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfPrOrderList.Rows.Count <= vsfPrOrderList.Rows.Fixed Then
                Return
            End If

             '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納（ｵｰﾀﾞｰ№）
                mtypChgSort.strKey = vsfPrOrderList.GetData(e.NewRange.r1, CMlngvsfPrOrderListColID)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfPrOrderList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfPrOrderList_AfterUserResize
    '機　能：ｸﾞﾘｯﾄﾞ幅変更処理
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2005/12/26 (Mon) 11:54:05 T.Kitagawa
    '更新日：2005/12/26 (Mon) 11:54:05
    '備　考：
    Private Sub vsfPrOrderList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfPrOrderList.AfterResizeColumn, vsfPrOrderList.AfterResizeRow
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfPrOrderList.Rows.Count <= vsfPrOrderList.Rows.Fixed Then
                Return
            End If

            '@列幅変更ﾌﾗｸﾞ（変更）
            mtypChgSort.blnChgWidth = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfPrOrderList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfPrOrderList_EnterCell
    '機　能：P/Rｵｰﾀﾞｰ一覧　ｶﾚﾝﾄ移動
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/19 (Mon) 19:15:29 T.Kitagawa
    '更新日：2005/12/19 (Mon) 19:15:29
    '備　考：
    Private Sub vsfPrOrderList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfPrOrderList.EnterCell
        
        Try
            
            '@削除、修正、ｺﾋﾟｰ登録ﾎﾞﾀﾝの制御の初期化
            cmdDelete.Enabled = False
            cmdUpdate.Enabled = False
            cmdCopyInsert.Enabled = False
            
            '@移動判定
            If vsfPrOrderList.Row < 1 Then
                Exit Sub
            End If
            If vsfPrOrderList.Enabled = False Then
                Exit Sub
            End If
            
            '@ｵｰﾀﾞｰｺﾒﾝﾄの表示
            With vsfPrOrderList
                txtComments.Text = .GetData(.Row, CMlngvsfPrOrderListColCommentsV)
            End With
                
            '@削除、修正、ｺﾋﾟｰ登録ﾎﾞﾀﾝの制御
            cmdDelete.Enabled = True
            cmdUpdate.Enabled = True
            cmdCopyInsert.Enabled = True

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "vsfPrOrderList_EnterCell"       '処理名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：ｺﾒﾝﾄ▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/20 (Tue) 16:02:00 T.Kitagawa
    '更新日：2005/12/20 (Tue) 16:02:00
    '備　考：
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
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                       '機能ID
                .strProcName = "cmdUp_Click"                '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown_Click
    '機　能：ｺﾒﾝﾄ▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/20 (Tue) 16:03:25 T.Kitagawa
    '更新日：2005/12/20 (Tue) 16:03:25
    '備　考：
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
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                       '機能ID
                .strProcName = "cmdDown_Click"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComments_Change
    '機　能：ｺﾒﾝﾄ欄変更
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/20 (Tue) 16:03:58 T.Kitagawa
    '更新日：2005/12/20 (Tue) 16:03:58
    '備　考：
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
    '機　能：ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/12/20 (Tue) 16:05:42 T.Kitagawa
    '更新日：2005/12/20 (Tue) 16:05:42
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
    '機　能：ﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/12/20 (Tue) 16:06:27 T.Kitagawa
    '更新日：2005/12/20 (Tue) 16:06:27
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

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '関数名：prvfrmxxEN01S0_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/19 (Mon) 19:33:54 T.Kitagawa
    '更新日：2005/12/19 (Mon) 19:33:54
    '備　考：
    Private Sub prvfrmxxEN01S0_Init()

        Dim lstrFormTitle           As String               'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try

            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN01S0, lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle

            'NSYS 画面表示位置
            Me.StartPosition = FormStartPosition.Manual
            Me.Top  = 0
            Me.Left = 0 - My.Settings.FormOffset

            '@ﾗﾍﾞﾙの初期化
            lblNowDate.Text = vbNullString                              '情報取得日時
            lblLotCnt.Text = vbNullString                               '該当件数

            '@ｸﾞﾘｯﾄﾞ設定
            Call prvvsfPrOrderList_Init()

            '@ｵｰﾀﾞｰｺﾒﾝﾄの初期化
            txtComments.Text = vbNullString
            txtComments.Enabled = False
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ
            cmdNowList.Enabled = True                                   '最新取得ﾎﾞﾀﾝ
            cmdDelete.Enabled = False                                   '削除ﾎﾞﾀﾝ
            cmdUpdate.Enabled = False                                   '修正ﾎﾞﾀﾝ
            cmdCopyInsert.Enabled = False                               'ｺﾋﾟｰ登録
            cmdInsert.Enabled = True                                    '登録
            cmdUP.Enabled = False                                       '▲ﾎﾞﾀﾝ
            cmdDown.Enabled = False                                     '▼ﾎﾞﾀﾝ

            '@P/Rｵｰﾀﾞｰ登録連携情報のｸﾘｱ
            With ptypPrOrderRenkeiInfo
                .lngInsertMode = 0                                      '登録ﾓｰﾄﾞなし
                .strPROrderID = vbNullString                            'P/RｵｰﾀﾞｰID
                .strEditTime = vbNullString                             '最終更新日時
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01S0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfPrOrderList_Init
    '機　能：P/Rｵｰﾀﾞｰ一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/12/19 (Mon) 19:38:29 T.Kitagawa
    '更新日：2005/12/19 (Mon) 19:38:29
    '備　考：
    Private Sub prvvsfPrOrderList_Init()

        Dim lscpoint    As Point   ' NSYS ScrollPostion

        Try
            'NSYS 不要イベント発生抑止
            RemoveHandler vsfPrOrderList.BeforeRowColChange, AddressOf vsfPrOrderList_BeforeRowColChange
            RemoveHandler vsfPrOrderList.EnterCell, AddressOf vsfPrOrderList_EnterCell
            With vsfPrOrderList
                .Redraw = False
                lscpoint = .ScrollPosition 'NSYS スクロール位置保持
                '@ｸﾘｱ
                .Clear()
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                .AllowSorting = AllowSortingEnum.SingleColumn
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                '@ﾏｳｽでｾﾙ範囲選択不可
                .AllowDragging = False
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号（...）を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                '@選択方法
                .SelectionMode = SelectionModeEnum.Row
                '@一覧表の表題設定
                Dim headerSellRange = .GetCellRange(CMlngvsfRowTitle, CMlngvsfPrOrderListColNo, CMlngvsfRowTitle, .Cols.Count - 1)
                Dim headerStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                            '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)               '背景色
                headerStyle.Font = New Font(.Font.Name, CMlngvsfHFontSize, .Font.Style)         'ﾌｫﾝﾄｻｲｽﾞ
                headerStyle.Trimming = StringTrimming.None                                      'NSYS ﾍｯﾀﾞは省略表示なしに設定
                headerSellRange.Style = headerStyle
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngvsfPrOrderListColNo, CMstrvsfPrOrderListColNo)                'No.
                .SetData(CMlngVsfRowTitle, CMlngvsfPrOrderListColID, CMstrvsfPrOrderListColID)                'P/RｵｰﾀﾞｰID
                .SetData(CMlngVsfRowTitle, CMlngvsfPrOrderListColDept, CMstrvsfPrOrderListColDept)            '設定部門
                .SetData(CMlngVsfRowTitle, CMlngvsfPrOrderListColCost, CMstrvsfPrOrderListColCost)            '原価コード
                .SetData(CMlngVsfRowTitle, CMlngvsfPrOrderListColEditTime, CMstrvsfPrOrderListColEditTime)    '最終更新日時
                .SetData(CMlngVsfRowTitle, CMlngvsfPrOrderListColCommentsV, CMstrvsfPrOrderListColCommentsV)  'ｵｰﾀﾞｰｺﾒﾝﾄ内容（非表示）
                .SetData(CMlngVsfRowTitle, CMlngvsfPrOrderListColCommentsD, CMstrvsfPrOrderListColCommentsD)  'ｵｰﾀﾞｰｺﾒﾝﾄ

                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    '@列幅設定
                    .Cols(CMlngvsfPrOrderListColNo).Width = CMlngvsfPrOrderListColWNo                 '№
                    .Cols(CMlngvsfPrOrderListColID).Width = CMlngvsfPrOrderListColWID                 'P/RｵｰﾀﾞｰID
                    .Cols(CMlngvsfPrOrderListColDept).Width = CMlngvsfPrOrderListColWDept             '設定部門
                    .Cols(CMlngvsfPrOrderListColCost).Width = CMlngvsfPrOrderListColWCost             '原価コード
                    .Cols(CMlngvsfPrOrderListColEditTime).Width = CMlngvsfPrOrderListColWEditTime     '最終更新日時
                    .Cols(CMlngvsfPrOrderListColCommentsV).Width = CMlngvsfPrOrderListColWCommentsV   'ｵｰﾀﾞｰｺﾒﾝﾄ内容（非表示）
                    .Cols(CMlngvsfPrOrderListColCommentsD).Width = CMlngvsfPrOrderListColWCommentsD   'ｵｰﾀﾞｰｺﾒﾝﾄ
                End If

                '@表示位置の設定
                .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight    '高さ

                '@非表示設定
                .Cols(CMlngvsfPrOrderListColCommentsV).Visible = False       'ｵｰﾀﾞｰｺﾒﾝﾄ内容
                .Cols(CMlngvsfPrOrderListColEditTime).Visible = False        '最終更新日時

                '@固定列の設定
                .Cols.Frozen = CMlngvsfPrOrderListColID + 1
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light
                
                .ScrollPosition = New Point(lscpoint.X, .ScrollPosition.Y) 'NSYS 横スクロール位置復元

                .Redraw = True

                '@ﾛｯｸ
                .Enabled = False

            End With
            'NSYS 不要イベント発生抑止解除
            AddHandler vsfPrOrderList.BeforeRowColChange, AddressOf vsfPrOrderList_BeforeRowColChange
            AddHandler vsfPrOrderList.EnterCell, AddressOf vsfPrOrderList_EnterCell

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfPrOrderList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfPrOrderList_Disp
    '機　能：P/Rｵｰﾀﾞｰ一覧の表示
    '引　数：ltypPrOrderListAns：P/Rｵｰﾀﾞｰ一覧構造体
    '戻り値：なし
    '作成日：2005/12/19 (Mon) 19:51:17 T.Kitagawa
    '更新日：2005/12/19 (Mon) 19:51:17
    '備　考：
    Private Sub prvvsfPrOrderList_Disp(ByRef ltypPrOrderListAns As PrOrderListAns)

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ
        Dim lscpoint    As Point    ' NSYS ScrollPostion

        Try
            'NSYS 不要イベント発生抑止
            RemoveHandler vsfPrOrderList.BeforeRowColChange, AddressOf vsfPrOrderList_BeforeRowColChange
            RemoveHandler vsfPrOrderList.EnterCell, AddressOf vsfPrOrderList_EnterCell
            With vsfPrOrderList
                'NSYS スクロール位置保持
                lscpoint = .ScrollPosition
                If ltypPrOrderListAns.lngPrOrderListCnt > 0 Then
                    '@格納ﾃﾞｰﾀがあるの場合

                    '@描画ﾛｯｸ
                    .Redraw = False

                    '@行数初期化(グリッドの初期化)
                    .Rows.Count = .Rows.Fixed

                    '@行数設定
                    .Rows.Count = ltypPrOrderListAns.lngPrOrderListCnt + 1

                    '@ﾌｫﾝﾄの色変更(黒色)
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbBlack")
                    newStyle.ForeColor = Color.Black
                    Dim cellRange As CellRange
                    '@一覧設定
                    For llngCnt = 1 To ltypPrOrderListAns.lngPrOrderListCnt
                        '@内容設定
                        .SetData(llngCnt, CMlngvsfPrOrderListColNo, llngCnt)                                                                '№
                        .SetData(llngCnt, CMlngvsfPrOrderListColID, ltypPrOrderListAns.typPrOrderList(llngCnt-1).strPROrderID)              'PRｵｰﾀﾞｰID
                        .SetData(llngCnt, CMlngvsfPrOrderListColDept, ltypPrOrderListAns.typPrOrderList(llngCnt-1).strGlobalDept)           '設定部門
                        .SetData(llngCnt, CMlngvsfPrOrderListColCost, ltypPrOrderListAns.typPrOrderList(llngCnt-1).strCostCode)             '原価ｺｰﾄﾞ
                        '@最終更新日時の設定（排他制御用→排他ﾁｪｯｸは未実装）
                        .SetData(llngCnt, CMlngvsfPrOrderListColEditTime, ltypPrOrderListAns.typPrOrderList(llngCnt-1).strEditTime)         '最終更新日時
                        '@ｵｰﾀﾞｰｺﾒﾝﾄ内容（非表示用でｵｰﾀﾞｰｺﾒﾝﾄTextBoxへ使用）の設定
                        .SetData(llngCnt, CMlngvsfPrOrderListColCommentsV, ltypPrOrderListAns.typPrOrderList(llngCnt-1).strOrderComments)   'ｵｰﾀﾞｰｺﾒﾝﾄ内容（非表示）
                        '@ｵｰﾀﾞｰｺﾒﾝﾄの改行ｷｰ変換（→Spaceへ変換）
                        .SetData(llngCnt, CMlngvsfPrOrderListColCommentsD, _
                                    Replace$(ltypPrOrderListAns.typPrOrderList(llngCnt-1).strOrderComments, vbCrLf, Space$(1)))             'ｵｰﾀﾞｰｺﾒﾝﾄ
                        cellRange = .GetCellRange(llngCnt, CMlngvsfColTitle, llngCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngCnt).Height = CMlngVsfHeight
                    Next llngCnt
                    
                    '@ﾕｰｻﾞによる列幅変更されていない場合
                    If mtypChgSort.blnChgWidth = False Then
                        '@列幅設定
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCols(CMlngvsfPrOrderListColID, .Cols.Count - 1, 6)
                    End If

                    '@書式設定
                    .Cols(CMlngvsfPrOrderListColNo).TextAlign = TextAlignEnum.RightCenter              '№（右寄せ中央揃え）
                    .Cols(CMlngvsfPrOrderListColID).TextAlign = TextAlignEnum.LeftCenter               'PRｵｰﾀﾞｰID(左寄せ中央揃え)
                    .Cols(CMlngvsfPrOrderListColDept).TextAlign = TextAlignEnum.LeftCenter             '設定部門(左寄せ中央揃え)
                    .Cols(CMlngvsfPrOrderListColCost).TextAlign = TextAlignEnum.LeftCenter             '原価ｺｰﾄﾞ(左寄せ中央揃え)
                    .Cols(CMlngvsfPrOrderListColEditTime).TextAlign = TextAlignEnum.LeftCenter         '最終更新日時(左寄せ中央揃え)
                    .Cols(CMlngvsfPrOrderListColCommentsV).TextAlign = TextAlignEnum.LeftCenter        'ｵｰﾀﾞｰｺﾒﾝﾄ内容(左寄せ中央揃え)
                    .Cols(CMlngvsfPrOrderListColCommentsD).TextAlign = TextAlignEnum.LeftCenter        'ｵｰﾀﾞｰｺﾒﾝﾄ(左寄せ中央揃え)

                    '@固定列の設定
                    .Cols.Frozen = CMlngvsfPrOrderListColID + 1
                    
                    '@ﾏｳｽよる列ｻｲｽﾞ変更の可設定
                    .AllowResizing = False
                    
                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort.lngCnt -1
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSort.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort.typChgSortList(llngCnt).lngOrder
                            .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder,mtypChgSort.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If

                    'NSYS 不要イベント発生抑止解除
                    AddHandler vsfPrOrderList.BeforeRowColChange, AddressOf vsfPrOrderList_BeforeRowColChange
                    AddHandler vsfPrOrderList.EnterCell, AddressOf vsfPrOrderList_EnterCell

                    '@ｿｰﾄ検索用ｷｰ（PRｵｰﾀﾞｰID）がある場合
                    If mtypChgSort.strKey <> vbNullString Then
                        Dim findflg As Boolean = False
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@PRｵｰﾀﾞｰIDが同じ場合
                            If .GetData(llngCnt, CMlngvsfPrOrderListColID) = mtypChgSort.strKey Then
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列）
                                Call pubVsfBeforeSort(vsfPrOrderList, CMlngVsfRowTitle)

                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定（ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁）
                                Call pubVsfAfterSort(vsfPrOrderList, CMlngVsfRowTitle)
                                findflg = True
                                Exit For
                            End If
                        Next llngCnt
                        If Not findflg Then
                            '@先頭ﾍﾟｰｼﾞ設定
                            .TopRow = 0
                            '@ﾀｲﾄﾙ行に行設定
                            .Row = 0
                        End If
                    Else
                        '@先頭ﾍﾟｰｼﾞ設定
                        .TopRow = 0
                        '@ﾀｲﾄﾙ行に行設定
                        .Row = 0
                    End If
                    'NSYS 横スクロール位置復元
                    .ScrollPosition = New Point(lscpoint.X, .ScrollPosition.Y)
                    '@再描画
                    .Redraw = True
                Else
                    '@格納ﾃﾞｰﾀが無い場合
                    '@ｸﾞﾘｯﾄﾞ設定
                    Call prvvsfPrOrderList_Init()
                    '@ﾀｲﾄﾙ行に行設定
                    .Row = 0
                End If
            End With
            
            '@P/Rｵｰﾀﾞｰ一覧、ｺﾒﾝﾄの使用可否
            If vsfPrOrderList.Rows.Count > 1 Then
                vsfPrOrderList.Enabled = True
                txtComments.Enabled = True
                txtComments.Locked = True
                txtComments.Text = vbNullString
            Else
                vsfPrOrderList.Enabled = False
                txtComments.Enabled = False
                txtComments.Text = vbNullString
            End If
            
            '@現在日時表示
            lblNowDate.Text = Format$(Now, CPstrDateFormat)

            '@該当件数ﾗﾍﾞﾙに取得件数を表示
            lblLotCnt.Text = Format$(ltypPrOrderListAns.lngPrOrderListCnt, CPstrDateFormatKanma)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvvsfPrOrderList_Disp" '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnPrOrderList_Proc
    '機　能：P/Rｵｰﾀﾞｰ一覧取得処理
    '引　数：なし
    '戻り値：True:成功/False失敗
    '作成日：2005/12/19 (Mon) 20:23:10 T.Kitagawa
    '更新日：2005/12/19 (Mon) 20:23:10
    '備　考：
    Private Function prvblnPrOrderList_Proc() As Boolean

        Dim lblnAns                 As Boolean              '結果格納
        Dim ltypPrOrderListAns      As PrOrderListAns       'P/Rｵｰﾀﾞｰﾘｽﾄ取得構造体

        '@初期化
        prvblnPrOrderList_Proc = False

        Try

            '@情報取得を行う
            lblnAns = pubblnPrOrderList_Sel(CMstrpr__orderlistVer, ltypPrOrderListAns)
            '@結果判定
            If lblnAns = False Then
                Exit Function
            End If

            '@一覧情報を画面にｾｯﾄ
            Call prvvsfPrOrderList_Disp(ltypPrOrderListAns)

            '@成功を返す
            prvblnPrOrderList_Proc = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnPrOrderList_Proc"
                .strErrMessage = vbNullString
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

                    Case SC_MOVE
                        'フォームの移動を無効化する
                        m.Result = IntPtr.Zero
                        Return
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
