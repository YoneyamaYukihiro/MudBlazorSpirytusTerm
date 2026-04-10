'ﾌｧｲﾙ名：xxCM00H3.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：工程異常名変更　メインフォーム
'作成日：2004/08/10 (Tue) 10:07:17 S.Deguchi
'更新日：2004/08/10 (Tue) 10:07:17
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00H3
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00H3    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00H3
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00H3
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00H3)
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
    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ定数宣言
    Private Const CMstrMasTroubleItemListVer        As String = "01.00"                    '異常処理項目名取得
                                                                                           
    '@機能ID                                                                               
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyCM00H3             'ﾛｰｶﾙ機能ID

    '@vsfResumeListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfColName                   As Integer = 0                         '系列

    '@vsfResumeListの定数宣言(幅)
    Private Const CMlngvsfWColName                  As Integer = 333                       '工程異常項目名
                                                                                           
    '@vsfResumeListの定数宣言(ｶﾗﾑ)                                                         
    Private Const CMstrvsfColNameT                  As String = "工程異常名"               '工程異常名
    Private Const CMstrvsfColNameI                  As String = "不良特性名"               '不良特性名

    '@vsf共通の定数宣言
    Private Const CMlngVsfRowTitle                  As Integer = 0                         'ﾀｲﾄﾙ行（行）
    Private Const CMlngVsfColTitle                  As Integer = 0                         'ﾀｲﾄﾙ行（列）
    Private Const CMlngVsfHFontSize                 As Integer = 11                        'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfFontSize                  As Integer = 11                        'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                   As Integer = 20                        'ﾍｯﾀﾞｰの高さ
    Private Const CMlngVsfHeight                    As Integer = 24                        '1ｽﾛｯﾄの高さ

    '@異常処理項目取得の定数宣言
    Private Const CMlngItemIndex1                   As Integer = 1                         '異常処理項目
    Private Const CMlngItemIndex6                   As Integer = 6                         '不良特性項目

    '@定数宣言
    Private Const CMlngDefault0                     As Integer = 0                         '該当件数0件用定数
    Private Const CMstrLeftLabel                    As String = "＜"
    Private Const CMstrRightLabel                   As String = "＞"

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    Private mblnConnectFlag                         As Boolean                          '引継ﾌﾗｸﾞ(True：工程異常/False：不良特性)
    Private buttonProcessing                        As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                          'NSYS システムコマンドでの画面クローズ
    
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
    '作成日：2004/08/10 (Tue) 10:23:53 S.Deguchi
    '更新日：2004/08/10 (Tue) 10:23:53
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim ltypTroubleItemInfo     As TroubleItemInfo      '異常処理系列取得構造体
        Dim lstrItemIndex           As String               '項目ﾀｲﾌﾟ

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrEventName = "Form_Load"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, lstrEventName)

            '@画面情報の初期化
            Call prvfrmxxCM00H3_Init()
            
            '@ﾌｫｰﾑのﾀｲﾄﾙから取得する情報を判別
            If mblnConnectFlag = True Then
                lstrItemIndex = CMlngItemIndex1
            Else
                lstrItemIndex = CMlngItemIndex6
            End If
            
            '@異常処理項目の取得
            lblnAns = pubblnMasTroubleItemList_Sel(CMstrMasTroubleItemListVer, _
                                                   lstrItemIndex, _
                                                   ltypTroubleItemInfo)
            '@結果判定
            If lblnAns = False Then
            '@失敗の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                Exit Sub
            Else
                '@取得件数0件の場合にはﾌｫｰﾑを表示させない
                If ltypTroubleItemInfo.lngTroubleItemListCnt = 0 Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, lstrEventName)

                    '@0件ﾒｯｾｰｼﾞを表示する:表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0029, CMlngDefault0)
                    
                    '@publngMsgBoxInfo("メッセージコード：C_I29%0$$該当件数 ： 0 件")
                    Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)

                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = cmdClose

                    Exit Sub
                End If
            End If

            '@ｸﾞﾘｯﾄﾞに工程異常名をｾｯﾄ
            Call prvvsfExcpList_Disp(ltypTroubleItemInfo)
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)
            
            '@Form_Loadﾌﾗｸﾞ（正常）
            pblnFormLoad = True

            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：ｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ値
    '戻り値：なし
    '作成日：2004/08/18 (Wed) 17:12:24 S.Deguchi
    '更新日：2004/08/18 (Wed) 17:12:24
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@確定ﾎﾞﾀﾝが非表示の場合
            If cmdRegist.Visible = False Then
                '@Enterｷｰの場合
                Select Case e.KeyCode
                    Case Keys.Return
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                End Select
            Else
                '@Enterｷｰの場合
                Select Case e.KeyCode
                    Case Keys.Return
                        '@一覧にﾌｫｰｶｽがある場合
                        With vsfExcpList
                            If ActiveControl.Name = .Name Then
                                '@ﾃﾞｰﾀ行の場合
                                If .Row >= .Rows.Fixed Then
                                
                                    '@選択確定処理
                                    Call cmdRegist_Click(cmdRegist,New EventArgs)
                                End If
                            Else
                                SendKeys.SendWait(CPstrSendKeysTab)
                                e.Handled = True
                            End If
                        End With
                End Select
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：ﾌｫｰﾑｸｴﾘｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/08/18 (Wed) 17:11:45 S.Deguchi
    '更新日：2004/11/01 (Mon) 15:24:04 N.Kasai
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
           
            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：画面を閉じる処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/18 (Wed) 17:09:12 S.Deguchi
    '更新日：2004/11/01 (Mon) 15:22:58 N.Kasai
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

            '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞ
            Me.Close()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
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
    '作成日：2004/08/18 (Wed) 17:14:07 S.Deguchi
    '更新日：2004/08/18 (Wed) 17:14:07
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@行が選択されていない場合は格納しない
            With vsfExcpList
                If .Row >= 1 Then
                    '@工程異常名を格納
                    pstrExcpName = .GetData(.Row, CMlngvsfColName)
                    
                    '@ﾌｫｰﾑを閉じる
                    Me.Close()
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRegist_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfExcpList_DblClick
    '機　能：ｸﾞﾘｯﾄﾞの選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/18 (Wed) 17:10:20 S.Deguchi
    '更新日：2004/08/18 (Wed) 17:10:20
    '備　考：
    Private Sub vsfExcpList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfExcpList.DoubleClick

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfExcpList.Rows.Count <= vsfExcpList.Rows.Fixed Then
                Return
            End If

            '@確定ﾎﾞﾀﾝが表示されている場合
            If cmdRegist.Visible = True Then
                '@ﾍｯﾀﾞｰﾀﾞﾌﾞﾙｸﾘｯｸの場合
                If vsfExcpList.MouseRow <= 0 Then
                    Exit Sub
                End If
                
                '@選択確定処理へ
                Call cmdRegist_Click(cmdRegist,New EventArgs)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfExcpList_DblClick"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfExcpList_RowColChange
    '機　能：工程異常名選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/18 (Wed) 17:58:05 S.Deguchi
    '更新日：2004/08/18 (Wed) 17:58:05
    '備　考：
    Private Sub vsfExcpList_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfExcpList.RowColChange

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfExcpList.Rows.Count <= vsfExcpList.Rows.Fixed Then
                Return
            End If

            '@ﾀｲﾄﾙ以外の場合には,確定ﾎﾞﾀﾝが活性化
            With vsfExcpList
                If .Row > 0 Then
                    '@確定ﾎﾞﾀﾝ活性化
                    cmdRegist.Enabled = True
                Else
                    '@確定ﾎﾞﾀﾝ非活性化
                    cmdRegist.Enabled = False
                End If
            End With
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfExcpList_RowColChange"
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

    '関数名：prvfrmxxCM00H3_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/18 (Wed) 17:21:29 S.Deguchi
    '更新日：2004/08/18 (Wed) 17:21:29
    '備　考：
    Private Sub prvfrmxxCM00H3_Init()

        Try

            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = pstrExcpName

            '@引継変数から引継ﾌﾗｸﾞを設定
            If pstrExcpName = CPstrSubFormCM00H3T Then
            '@工程異常項目
                mblnConnectFlag = True
                
                '@ﾗﾍﾞﾙﾀｲﾄﾙ設定
                lblTitle.Text = CMstrLeftLabel & CMstrvsfColNameT & CMstrRightLabel
            Else
            '@不良特性項目
                mblnConnectFlag = False
            
                '@ﾗﾍﾞﾙﾀｲﾄﾙ設定
                lblTitle.Text = CMstrLeftLabel & CMstrvsfColNameI & CMstrRightLabel
            End If
            
            '@初期化
            pstrExcpName = vbNullString
            
            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfExcpList_Init()
            
            '@確定ﾎﾞﾀﾝの非活性化
            cmdRegist.Enabled = False
            
            '@閉じるボタンへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00H3_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfExcpList_Init
    '機　能：工程異常名の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/10 (Tue) 10:07:17 S.Deguchi
    '更新日：2004/08/10 (Tue) 10:07:17
    '備　考：
    Private Sub prvvsfExcpList_Init()

        Try

            With vsfExcpList
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear(ClearFlags.UserData)
                
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化(ｿｰﾄなし)
                .AllowSorting = AllowSortingEnum.None
                        
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                
                '@ﾌｫﾝﾄｻｲｽﾞ指定(=11)
                .Font = New Font(.Font.FontFamily, CMlngvsfFontSize, .Font.Style, .Font.Unit)
                
                '@一覧表の表題設定
                Dim cellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngvsfColName, CMlngVsfRowTitle, .Cols.Count - 1)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMlngvsfHFontSize, headerStyle.Font.Style, headerStyle.Font.Unit)       'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                                                               'ﾀｲﾄﾙ(中央寄せ中央揃え)
                cellRange.Style = headerStyle

                '@ﾀｲﾄﾙ設定
                If mblnConnectFlag = True Then
                    .SetData(CMlngVsfRowTitle, CMlngvsfColName, CMstrvsfColNameT)
                Else
                    .SetData(CMlngVsfRowTitle, CMlngvsfColName, CMstrvsfColNameI)
                End If

                '@列幅設定
                .Cols(CMlngvsfColName).Width = CMlngvsfWColName
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight                                          '高さ
                
                '@ﾛｯｸ
                .Enabled = False
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.None

            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfExcpList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfExcpList_Disp
    '機　能：工程異常名の表記処理
    '引　数：ltypTroubleItemInfo:工程異常名構造体
    '戻り値：なし
    '作成日：2004/08/10 (Tue) 10:07:17 S.Deguchi
    '更新日：2004/08/18 (Wed) 17:54:12 S.Deguchi
    '備　考：
    Private Sub prvvsfExcpList_Disp(ByRef ltypTroubleItemInfo As TroubleItemInfo)

        Dim llngDoCnt   As Integer  'ｶｳﾝﾄ

        Try
            
            With vsfExcpList
                If ltypTroubleItemInfo.lngTroubleItemListCnt = 0 Then
                '@格納ﾃﾞｰﾀがない場合
                    '@初期化
                    Call prvvsfExcpList_Init()
                
                    Exit Sub
                Else
                '@格納ﾃﾞｰﾀがあるの場合
                    
                    '@まず初期化
                    Call prvvsfExcpList_Init()
            
                    '@ﾊﾞｯﾌｧ経由で描画
                    .Redraw = False
                    
                    .Row = -1

                    '@行数設定
                    .Rows.Count = ltypTroubleItemInfo.lngTroubleItemListCnt + 1
                    
                    '@ｶｳﾝﾀの初期化
                    llngDoCnt = 1
                    
                    Do While .Rows.Count > llngDoCnt
                        '@ﾛｯﾄ一覧表示情報設定
                        .SetData(llngDoCnt, CMlngvsfColName, _
                            ltypTroubleItemInfo.typTroubleItemList(llngDoCnt -1).strItemName)           '工程異常名
                            
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngDoCnt).Height = CMlngVsfHeight
                        
                        '@ｶｳﾝﾄのｶｳﾝﾄｱｯﾌﾟ
                        llngDoCnt = llngDoCnt + 1
                    Loop
            
                    '@書式設定
                    .Cols(CMlngvsfColName).TextAlign = TextAlignEnum.LeftCenter
                    
                    '@行列のﾏｳｽでの変更を不可設定にする
                    .AllowResizing = AllowResizingEnum.None
                        
                    .Row = 0

                    .Redraw = True

                    '@ﾛｯｸ解除
                    .Enabled = True
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfExcpList_Disp"
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
                lblnWMClose = True

        End Select

        MyBase.WndProc(m)

        If lblnSysCommandScClose = True Then
            'NSYS SC_CLOSE 処理後 WM_CLOSE が発生しないでキャンセルされることもあるため、フラグを戻す
            'NSYS WM_CLOSE が発生していれば、すでにこの時点では画面は閉じている
            mblnCloseFromControlMenu = False
        End If
    End Sub

End Class
