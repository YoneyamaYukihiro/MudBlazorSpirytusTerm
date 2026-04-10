'ﾌｧｲﾙ名：xxCM00H4.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾛｯﾄ流動履歴　メインフォーム
'作成日：2004/08/10 (Tue) 10:07:17 S.Deguchi
'更新日：2004/08/10 (Tue) 10:07:17
'備　考：使用しなくなりました。
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00H4
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00H4    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00H4
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00H4
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00H4)
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
    Private Const CMstrlotsimplitrvllistVer         As String = "01.00"                 '@ﾛｯﾄ流動履歴情報

    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyCM00H4          'ﾛｰｶﾙ機能ID

    '@vsfResumeListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfColNo                     As Integer = 0                         '№
    Private Const CMlngvsfColOpID                   As Integer = 1                         '大工程
    Private Const CMlngvsfColStepID                 As Integer = 2                         '小工程
    Private Const CMlngvsfColWPID                   As Integer = 3                         'WPID
    Private Const CMlngvsfColWpName                 As Integer = 4                         '装置名
    Private Const CMlngvsfColSEmpName               As Integer = 5                         '作業開始担当者
    Private Const CMlngvsfColSDeptName              As Integer = 6                         '作業開始担当T
    Private Const CMlngvsfColEEmpName               As Integer = 7                         '作業終了担当者
    Private Const CMlngvsfColEDeptName              As Integer = 8                         '作業終了担当T
    Private Const CMlngvsfColCauseName              As Integer = 9                         '原因系列

    '@vsfResumeListの定数宣言(幅)
    Private Const CMlngvsfWColNo                    As Integer = 57                        '№
    Private Const CMlngvsfWColOpID                  As Integer = 220                       '大工程
    Private Const CMlngvsfWColStepID                As Integer = 220                       '小工程
    Private Const CMlngvsfWColWpID                  As Integer = 220                       'WPID
    Private Const CMlngvsfWColWpName                As Integer = 220                       '装置名
    Private Const CMlngvsfWColSEmpName              As Integer = 220                       '作業開始担当者
    Private Const CMlngvsfWColSDeptName             As Integer = 220                       '作業開始担当T
    Private Const CMlngvsfWColEEmpName              As Integer = 220                       '作業終了担当者
    Private Const CMlngvsfWColEDeptName             As Integer = 220                       '作業終了担当T
    Private Const CMlngvsfWColCauseName             As Integer = 220                       '原因系列

    '@vsfResumeListの定数宣言(ｶﾗﾑ)
    Private Const CMstrvsfColNo                     As String = "№"                    '№
    Private Const CMstrvsfColOpID                   As String = "大工程"                 '大工程
    Private Const CMstrvsfColStepID                 As String = "小工程"                 '小工程
    Private Const CMstrvsfColWpID                   As String = "WPID"                  'WPID
    Private Const CMstrvsfColWpName                 As String = "装置端末"               '装置名
    Private Const CMstrvsfColSEmpName               As String = "作業開始担当者"         '作業開始担当者
    Private Const CMstrvsfColSDeptName              As String = "作業開始担当T"          '作業開始担当T
    Private Const CMstrvsfColEEmpName               As String = "作業終了担当者"         '作業終了担当者
    Private Const CMstrvsfColEDeptName              As String = "作業終了担当T"          '作業終了担当T
    Private Const CMstrvsfColCauseName              As String = "原因系列"               '原因系列"

    '@vsf共通の定数宣言
    Private Const CMlngVsfRowTitle                  As Integer = 0                         'ﾀｲﾄﾙ行（行）
    Private Const CMlngVsfColTitle                  As Integer = 0                         'ﾀｲﾄﾙ行（列）
    Private Const CMlngVsfHFontSize                 As Integer = 11                        'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfFontSize                  As Integer = 11                        'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                   As Integer = 20                        'ﾍｯﾀﾞｰの高さ
    Private Const CMlngVsfHeight                    As Integer = 24                        '1ｽﾛｯﾄの高さ

    '@定数宣言
    Private Const CMlngDefault0                     As Integer = 0                         '該当件数0件用定数

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    Private buttonProcessing                    As Boolean              'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean              'NSYS システムコマンドでの画面クローズ
    Private CMlngRow                            As Integer              'NSYS 選択行格納
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
        Dim ltypSimpliTrvlList      As SimpliTrvlList       'ﾛｯﾄ流動履歴情報構造体

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrEventName = "Form_Load"
            
            '@引継ぎﾌﾗｸﾞをFalse設定
            pblnfrmxxCM00H4Kbn = False
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, lstrEventName)

            '@画面情報の初期化
            Call prvfrmxxCM00H4_Init()
            
            '@ﾛｯﾄ流動履歴情報の取得
            lblnAns = pubblnLotSimpliTrvlList_Sel(pstrConnectSBID, _
                                                  CMstrlotsimplitrvllistVer, _
                                                  pstrLotID, _
                                                  ltypSimpliTrvlList)
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
                If ltypSimpliTrvlList.lngSimpliTrvlListCnt = 0 Then
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
            Call prvvsfResumeList_Disp(ltypSimpliTrvlList)
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)

            '@引継ぎﾌﾗｸﾞをTrue設定
            pblnfrmxxCM00H4Kbn = True

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
                        With vsfResumeList
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
    '更新日：2004/11/01 (Mon) 15:21:32 N.Kasai
    '備　考：2004/11/01 (Mon) 15:21:32 N.Kasai  閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose,New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
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
    '更新日：2004/08/18 (Wed) 17:09:12
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


            '@引継ぎ構造体をｸﾘｱする
            ptypFlowRecord.strOpID = vbNullString                   '大工程
            ptypFlowRecord.strStepID = vbNullString                 '小工程
            ptypFlowRecord.strWpID = vbNullString                   '装置ID
            ptypFlowRecord.strWpName = vbNullString                 '装置名
            ptypFlowRecord.strCauseSeriesName = vbNullString        '原因系列
            ptypFlowRecord.strStartWorkEmpName = vbNullString       '作業開始担当者
            ptypFlowRecord.strStartWorkTeamName = vbNullString      '作業開始ﾁｰﾑ
            ptypFlowRecord.strEndWorkEmpName = vbNullString         '作業終了担当者
            ptypFlowRecord.strEndWorkTeamName = vbNullString        '作業終了ﾁｰﾑ
                
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
            With vsfResumeList
                If .Row >= 1 Then
                    '@引継ぎ構造体へ格納
                    ptypFlowRecord.strOpID = .GetData(.Row, CMlngvsfColOpID)                       '大工程
                    ptypFlowRecord.strStepID = .GetData(.Row, CMlngvsfColStepID)                   '小工程
                    ptypFlowRecord.strWpID = .GetData(.Row, CMlngvsfColWPID)                       '装置ID
                    ptypFlowRecord.strWpName = .GetData(.Row, CMlngvsfColWpName)                   '装置名
                    ptypFlowRecord.strCauseSeriesName = .GetData(.Row, CMlngvsfColCauseName)       '原因系列
                    ptypFlowRecord.strStartWorkEmpName = .GetData(.Row, CMlngvsfColSEmpName)       '作業開始担当者
                    ptypFlowRecord.strStartWorkTeamName = .GetData(.Row, CMlngvsfColSDeptName)     '作業開始ﾁｰﾑ
                    ptypFlowRecord.strEndWorkEmpName = .GetData(.Row, CMlngvsfColEEmpName)         '作業終了担当者
                    ptypFlowRecord.strEndWorkTeamName = .GetData(.Row, CMlngvsfColEDeptName)       '作業終了ﾁｰﾑ
                    
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

    '関数名：vsfResumeList_DblClick
    '機　能：確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 17:07:53 S.Deguchi
    '更新日：2004/08/19 (Thu) 17:07:53
    '備　考：
    Private Sub vsfResumeList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfResumeList.DoubleClick

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfResumeList.Rows.Count <= vsfResumeList.Rows.Fixed Then
                Return
            End If


            '@確定ﾎﾞﾀﾝが表示されている場合
            If cmdRegist.Visible = True Then
                '@ﾍｯﾀﾞｰﾀﾞﾌﾞﾙｸﾘｯｸの場合
                If vsfResumeList.MouseRow <= 0 Then
                
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
                .strProcName = "vsfResumeList_DblClick"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfResumeList_RowColChange
    '機　能：流動履歴選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/18 (Wed) 17:58:05 S.Deguchi
    '更新日：2004/08/18 (Wed) 17:58:05
    '備　考：
    Private Sub vsfResumeList_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfResumeList.RowColChange

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfResumeList.Rows.Count <= vsfResumeList.Rows.Fixed Then
                Return
            End If

            '@ﾀｲﾄﾙ以外の場合には,確定ﾎﾞﾀﾝが活性化
            With vsfResumeList
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
                .strProcName = "vsfResumeList_RowColChange"
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

    '関数名：prvfrmxxCM00H4_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/18 (Wed) 17:21:29 S.Deguchi
    '更新日：2004/08/18 (Wed) 17:21:29
    '備　考：
    Private Sub prvfrmxxCM00H4_Init()

        Try

            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfResumeList_Init()
            
            '@確定ﾎﾞﾀﾝの非活性化
            cmdRegist.Enabled = False
            
            '@閉じるボタンへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00H4_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfResumeList_Init
    '機　能：ﾛｯﾄ流動履歴の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/10 (Tue) 10:07:17 S.Deguchi
    '更新日：2004/08/10 (Tue) 10:07:17
    '備　考：
    Private Sub prvvsfResumeList_Init()

        Try

            With vsfResumeList
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear(ClearFlags.UserData)
                
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                .AllowSorting = AllowSortingEnum.SingleColumn
                        
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                
                '@ｾﾚｸｼｮﾝﾓｰﾄﾞ(行選択)
                .SelectionMode = SelectionModeEnum.Row
                
                '@ﾌｫﾝﾄｻｲｽﾞ指定(=11)
                .Font = New Font(.Font.FontFamily, CMlngvsfFontSize, .Font.Style, .Font.Unit)
                
                Dim cellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngVsfColTitle, .Rows.Count - 1, .Cols.Count - 1)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")

                headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMlngvsfHFontSize, headerStyle.Font.Style, headerStyle.Font.Unit)       'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                
                '@一覧表の表題設定
                headerStyle.TextAlign = TextAlignEnum.CenterCenter

                cellRange.Style = headerStyle

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngvsfColNo, CMstrvsfColNo)                      '№
                .SetData(CMlngVsfRowTitle, CMlngvsfColOpID, CMstrvsfColOpID)                  '大工程
                .SetData(CMlngVsfRowTitle, CMlngvsfColStepID, CMstrvsfColStepID)              '小工程
                .SetData(CMlngVsfRowTitle, CMlngvsfColWPID, CMstrvsfColWpID)                  '装置ID
                .SetData(CMlngVsfRowTitle, CMlngvsfColWpName, CMstrvsfColWpName)              '装置端末
                .SetData(CMlngVsfRowTitle, CMlngvsfColSEmpName, CMstrvsfColSEmpName)          '作業開始担当者
                .SetData(CMlngVsfRowTitle, CMlngvsfColSDeptName, CMstrvsfColSDeptName)        '作業開始担当T
                .SetData(CMlngVsfRowTitle, CMlngvsfColEEmpName, CMstrvsfColEEmpName)          '作業終了担当者
                .SetData(CMlngVsfRowTitle, CMlngvsfColEDeptName, CMstrvsfColEDeptName)        '作業終了担当T
                .SetData(CMlngVsfRowTitle, CMlngvsfColCauseName, CMstrvsfColCauseName)        '原因系列

                '@列幅設定
                .Cols(CMlngvsfColNo).Width = CMlngvsfWColNo                                               '№
                .Cols(CMlngvsfColOpID).Width = CMlngvsfWColOpID                                           '大工程
                .Cols(CMlngvsfColStepID).Width = CMlngvsfWColStepID                                       '小工程
                .Cols(CMlngvsfColWPID).Width = CMlngvsfWColWpID                                           '装置ID
                .Cols(CMlngvsfColWpName).Width = CMlngvsfWColWpName                                       '装置端末名
                .Cols(CMlngvsfColSEmpName).Width = CMlngvsfWColSEmpName                                   '作業開始担当者
                .Cols(CMlngvsfColSDeptName).Width = CMlngvsfWColEEmpName                                  '作業開始担当T
                .Cols(CMlngvsfColEEmpName).Width = CMlngvsfWColEEmpName                                   '作業終了担当者
                .Cols(CMlngvsfColEDeptName).Width = CMlngvsfWColEDeptName                                 '作業終了担当T
                .Cols(CMlngvsfColCauseName).Width = CMlngvsfWColCauseName                                 '原因系列
                                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight                                          '高さ
                
                '@非表示項目の設定
                .Cols(CMlngvsfColWPID).Visible = False                                                      '装置ID
                .Cols(CMlngvsfColSEmpName).Visible = False                                                  '作業開始担当者
                .Cols(CMlngvsfColSDeptName).Visible = False                                                 '作業開始担当T
                .Cols(CMlngvsfColEEmpName).Visible = False                                                  '作業終了担当者
                .Cols(CMlngvsfColEDeptName).Visible = False                                                 '作業終了担当T
                .Cols(CMlngvsfColCauseName).Visible = False                                                 '原因系列
                
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
                .strProcName = "prvvsfResumeList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：prvvsfResumeList_Disp
    '機　能：ﾛｯﾄ流動履歴の情報表示
    '引　数：ltypSimpliTrvlList：ﾛｯﾄ流動履歴構造体
    '戻り値：なし
    '作成日：2004/08/10 (Tue) 10:07:17 S.Deguchi
    '更新日：2004/08/10 (Tue) 10:07:17
    '備　考：
    Private Sub prvvsfResumeList_Disp(ByRef ltypSimpliTrvlList As SimpliTrvlList)

        Dim llngCnt   As Integer  'ｶｳﾝﾄ

        Try
            
            With vsfResumeList
                If ltypSimpliTrvlList.lngSimpliTrvlListCnt <> 0 Then
                '@格納ﾃﾞｰﾀがあるの場合
                    
                    '@まず初期化
                    Call prvvsfResumeList_Init()

                    '@ﾊﾞｯﾌｧ経由で描画
                    .Redraw = False
                    
                    .Row = -1

                    '@行数設定
                    .Rows.Count = ltypSimpliTrvlList.lngSimpliTrvlListCnt + 1
                    
                    '@ｶｳﾝﾀの初期化
                    llngCnt = 1
                    
                    Do While .Rows.Count > llngCnt
                        '@ﾛｯﾄ一覧表示情報設定
                        .SetData(llngCnt, CMlngvsfColOpID, _
                            ltypSimpliTrvlList.typSimpliTrvlList(llngCnt -1).strOpID)                       '大工程
                            
                        .SetData(llngCnt, CMlngvsfColStepID, _
                            ltypSimpliTrvlList.typSimpliTrvlList(llngCnt -1).strStepID)                     '小工程
                            
                        .SetData(llngCnt, CMlngvsfColWPID, _
                            ltypSimpliTrvlList.typSimpliTrvlList(llngCnt -1).strWpID)                       '装置ID
                            
                        .SetData(llngCnt, CMlngvsfColWpName, _
                            ltypSimpliTrvlList.typSimpliTrvlList(llngCnt -1).strWpName)                     '装置名
                            
                        .SetData(llngCnt, CMlngvsfColSEmpName, _
                            ltypSimpliTrvlList.typSimpliTrvlList(llngCnt -1).strStartWorkEmpName)           '開始作業者
                            
                        .SetData(llngCnt, CMlngvsfColSDeptName, _
                            ltypSimpliTrvlList.typSimpliTrvlList(llngCnt -1).strStartWorkTeamName)          '開始作業者ﾁｰﾑ
                            
                        .SetData(llngCnt, CMlngvsfColEEmpName, _
                            ltypSimpliTrvlList.typSimpliTrvlList(llngCnt -1).strEndWorkEmpName)             '終了作業者
                            
                        .SetData(llngCnt, CMlngvsfColEDeptName, _
                            ltypSimpliTrvlList.typSimpliTrvlList(llngCnt -1).strEndWorkTeamName)            '終了作業者ﾁｰﾑ
                            
                        .SetData(llngCnt, CMlngvsfColCauseName, _
                            ltypSimpliTrvlList.typSimpliTrvlList(llngCnt -1).strCauseSeriesName)            '原因系列名

                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngCnt).Height = CMlngVsfHeight
                        
                        '@ｶｳﾝﾄのｶｳﾝﾄｱｯﾌﾟ
                        llngCnt = llngCnt + 1
                    Loop

                    '@書式設定
                    .Cols(CMlngvsfColNo).TextAlign = TextAlignEnum.LeftCenter
                    .Cols(CMlngvsfColOpID).TextAlign = TextAlignEnum.LeftCenter
                    .Cols(CMlngvsfColStepID).TextAlign = TextAlignEnum.LeftCenter
                    .Cols(CMlngvsfColWPID).TextAlign = TextAlignEnum.LeftCenter
                    .Cols(CMlngvsfColWpName).TextAlign = TextAlignEnum.LeftCenter
                    
                    '@№設定
                    For llngCnt = 1 To .Rows.Count - 1
                        .SetData(llngCnt, CMlngvsfColNo, llngCnt)                             '通し番号
                        
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngCnt).Height = CMlngVsfHeight
                        
                        '@ｽﾛｯﾄ№のｾﾝﾀﾘﾝｸﾞ
                        .Cols(CMlngvsfColNo).TextAlign = TextAlignEnum.RightCenter                             '№(右寄せ中央揃え)
                    Next llngCnt
                    
                    '@行列のﾏｳｽでの変更を不可設定にする
                    .AllowResizing = AllowResizingEnum.None
                         
                    .Row = 0

                    .Redraw = True

                    '@ﾛｯｸ解除
                    .Enabled = True
                                
                Else
                '@格納ﾃﾞｰﾀがないの場合
                    '@初期化
                    Call prvvsfResumeList_Init()
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfResumeList_Disp"
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

    '関数名 vsfResumeList_BeforeSort
    '機　能：ソート前処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/05/04 (Mon) 17:00:00 NSYS
    '備　考：
    Private Sub vsfResumeList_BeforeSort(sender As Object, e As EventArgs) Handles vsfResumeList.BeforeSort

        'NSYS データ行がない場合は処理を抜ける
        If vsfResumeList.Rows.Count <= vsfResumeList.Rows.Fixed Then
            Return
        End If

        CMlngRow = vsfResumeList.Row

    End Sub

    '関数名 vsfResumeList_AfterSort
    '機　能：ソート後処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/05/04 (Mon) 17:00:00 NSYS
    '備　考：
    Private Sub vsfResumeList_AfterSort(sender As Object, e As EventArgs) Handles vsfResumeList.AfterSort

        'NSYS データ行がない場合は処理を抜ける
        If vsfResumeList.Rows.Count <= vsfResumeList.Rows.Fixed Then
            Return
        End If

        vsfResumeList.Row = CMlngRow

    End Sub

End Class
