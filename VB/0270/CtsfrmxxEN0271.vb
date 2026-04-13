'ﾌｧｲﾙ名：xxEN0271.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：WF指定アクション予約
'作成日：2012/10/24 (Wed) 11:44:25 T.Oide
'更新日：2012/11/14 (Wed) 14:19:41
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN0271
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN0271    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN0271
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN0271
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN0271)
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
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN0271          'ﾛｰｶﾙ機能ID

    '@vsfWfActionの定数宣言（ｶﾗﾑ）
    Private Const CMlngColNew                   As Integer = 0                      '新規
    Private Const CMlngColDelChk                As Integer = 1                      '削除
    Private Const CMlngColWFID                  As Integer = 2                      'WF_ID
    Private Const CMlngColExeTime               As Integer = 3                      '実行時刻

    '@vsfWfActionの定数宣言（表示幅）
    Private Const CMlngColWNew                  As Integer = 72                     '新規
    Private Const CMlngColWDelChk               As Integer = 72                     '削除
    Private Const CMlngColWWFID                 As Integer = 125                    'WF_ID
    Private Const CMlngColWExeTime              As Integer = 203                    '実行時刻

    '@vsfWfActionの定数宣言（ﾀｲﾄﾙ）
    Private Const CMstrColNew                   As String = "新規"                  '新規
    Private Const CMstrColDelChk                As String = "削除"                  '削除
    Private Const CMstrColWfId                  As String = "WF_ID"                 'WF_ID
    Private Const CMstrColExeTime               As String = "保留実行時刻"          '保留実行時刻

    '@ｸﾞﾘｯﾄﾞの初期値定数宣言
    Private Const CMlngRowTitle                 As Integer = 0                      'ﾀｲﾄﾙ
    Private Const CMlngColTitle                 As Integer = 0                      'ﾀｲﾄﾙ
    Private Const CMlngGridFixedCols            As Integer = 0                      'ｸﾞﾘｯﾄﾞのFixedCol
    Private Const CMlngGridFixedRows            As Integer = 1                      'ｸﾞﾘｯﾄﾞのFixedRow
    Private Const CMlngCellFontSize             As Integer = 11                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngHHeight                  As Integer = 20                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngHeight                   As Integer = 24                     '1ｽﾛｯﾄの高さ
    Private Const CMlngInitRows                 As Integer = 1                      '初期表示行(=1)


    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    Private mblnFormLoad                        As Boolean                          '起動ﾌﾗｸﾞ

    Private buttonProcessing                    As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                          'NSYS WindowCloseフラグ

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
    '作成日：2012/10/24 (Wed) 12:39:35 T.Oide
    '更新日：2012/10/24 (Wed) 12:39:35 T.Oide
    '備　考：
    Private Sub Form_Load()

        Try

            '@Escﾎﾞﾀﾝを無効
            Me.CancelButton = Nothing

            '@画面初期化
            Call prvfrmxxEN0271_Init()

            '@起動ﾌﾗｸﾞの初期化
            mblnFormLoad = False

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
    '機　能：ﾌｫｰﾑの起動処理
    '引　数：なし
    '戻り値：なし
    '作成日：2012/10/24 (Wed) 12:39:35 T.Oide
    '更新日：2012/10/24 (Wed) 12:39:35 T.Oide
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@起動ﾌﾗｸﾞによる処理
            If mblnFormLoad = False Then
                '@初回のみ処理を行う為
                mblnFormLoad = True
            
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
            
                '@画面表示処理
                Call prvfrmxxEN0271_Disp()
                
            End If
            
            '@確定ﾎﾞﾀﾝ有効ﾁｪｯｸ
            Call prvcmdRegistChk()
            
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
    '機　能：ﾌｫｰｶｽ制御
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2012/10/24 (Wed) 12:39:35 T.Oide
    '更新日：2012/10/24 (Wed) 12:39:35 T.Oide
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
            
            '@ｺﾝﾄﾛｰﾙによって処理分岐
            Select Case ActiveControl.Name
                
                '@ｸﾞﾘｯﾄﾞの場合
                Case vsfWfAction.Name
                
                    '@ｷｰによって処理分岐
                    Select Case e.KeyCode
                            
                        '@F2ｷｰの場合
                        Case Keys.F2
                        
                            '@編集可否判定
                            Call vsfWfAction_Edit()
                            e.Handled = True
                            
                        Case Keys.Space
                            
                            '@[削除]の行か
                            If vsfWfAction.Col = CMlngColDelChk Then
                                '@ﾁｪｯｸON/OFFする
                                Call prvGuridCheckOnOff()
                            End If
                            
                    End Select
                    
                '@その他のｺﾝﾄﾛｰﾙにﾌｫｰｶｽがある場合
                Case Else
                    
                    '@Enterの場合
                    Select Case e.KeyCode
                        
                        Case Keys.Return
                            
                            If ActiveControl IsNot vsfWfAction.Editor Then
                                '@次ﾌｫｰｶｽへ
                                SendKeys.SendWait(CPstrSendKeysTab)
                            
                                e.Handled = True
                            End If
                            
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
    '機　能：ﾌｫｰﾑ終了前処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2012/10/24 (Wed) 12:39:35 T.Oide
    '更新日：2012/10/24 (Wed) 12:39:35 T.Oide
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
    '作成日：2012/10/24 (Wed) 12:39:35 T.Oide
    '更新日：2012/10/24 (Wed) 12:39:35 T.Oide
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
    '作成日：2012/10/24 (Wed) 12:39:35 T.Oide
    '更新日：2012/10/24 (Wed) 12:39:35 T.Oide
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnResult      As Boolean
        Dim llngCnt         As Integer
        Dim llngDataCnt     As Integer
        
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
            
            '@入力ﾃﾞｰﾀﾁｪｯｸ
            lblnResult = prvcmdRegist_Chk()
            
            '@ﾁｪｯｸNGの場合処理中止
            If lblnResult = False Then
                Exit Sub
            
            End If
            
            With vsfWfAction
            
                llngDataCnt = 0

                'リスト初期化
                If IsNothing(ptypWfactrsv.typWfAction) Then
                    ptypWfactrsv.typWfAction = New List(Of WfAction)()
                Else
                    ptypWfactrsv.typWfAction.Clear()
                End If
            
                '@設定ﾃﾞｰﾀを構造体に格納
                For llngCnt = 1 To .Rows.Count - 1
                    
                    '@削除フラグはOFFか
                    If .GetCellCheck(llngCnt, CMlngColDelChk) = CheckEnum.Unchecked Then
                        
                        '@修正フラグセット
                        pblnEN0271EditFlag = True
                        
                        'ﾃﾞｰﾀｶｳﾝﾄｱｯﾌﾟ
                        llngDataCnt = llngDataCnt + 1
                        
                        '@配列要素追加
                        ptypWfactrsv.lngWfActionCnt = llngDataCnt
                        Dim tmpWfAction As WfAction = New WfAction()
                        '@ﾃﾞｰﾀ格納
                        If .GetCellCheck(llngCnt, CMlngColNew) = CheckEnum.Checked Then                                    '新規
                            tmpWfAction.strNewFlag = "1"
                        End If
                        tmpWfAction.strWfId = .GetData(llngCnt, CMlngColWFID)           'WF_ID
                        tmpWfAction.strExecTime = .GetData(llngCnt, CMlngColExeTime)    '実行時刻

                        ptypWfactrsv.typWfAction.Add(tmpWfAction)
                    
                    End If
                Next

            End With
            
            '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞしてﾌﾟﾛｸﾞﾗﾑ終了
            Me.Close()
            
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

    '関数名：cmdAddRow_Click
    '機　能：行追加
    '引　数：なし
    '戻り値：
    '作成日：2012/10/24 (Wed) 13:54:51 T.Oide
    '更新日：2012/10/24 (Wed) 13:54:51
    '備　考：
    Private Sub cmdAddRow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAddRow.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfWfAction
                .Redraw = False
                .Rows.Count = .Rows.Count + 1                                   '@行追加
                .SetCellCheck(.Rows.Count - 1, CMlngColNew, CheckEnum.Checked)  '@新規ﾁｪｯｸON
                .Row = .Rows.Count - 1                                          '@追加行選択
                .Redraw = True
            End With
            
        Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdAddRow_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfWfAction_ValidateEdit
    '機　能：k禁則文字入力ﾁｪｯｸ
    '引　数：Row：
    '　　　：Col：
    '　　　：Cancel：
    '戻り値：
    '作成日：2012/11/06 (Tue) 17:53:14 T.Oide
    '更新日：2012/11/06 (Tue) 17:53:14
    '備　考：
    Private Sub vsfWfAction_ValidateEdit(ByVal sender As Object, ByVal e As ValidateEditEventArgs) Handles vsfWfAction.ValidateEdit

        Dim llngCnt     As Integer

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfWfAction.Rows.Count <= vsfWfAction.Rows.Fixed Then
                Return
            End If


            With vsfWfAction
            
                '@入力ﾌｨｰﾙﾄﾞの編集後判定
                For llngCnt = 1 To Len(.Editor.Text)
                
                    Select Case Mid(.Editor.Text, llngCnt, 1)
                    
                        Case CPstrSingleQ
                            '@禁則文字："'"
                            e.Cancel = True
                            
                            Exit For
                        Case Else
                            '@禁則文字以外
                            
                    End Select
                    
                Next llngCnt
                
                If e.Cancel = False Then
                    .Editor.Text = .Editor.Text
                Else
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004V, CPstrSingleQ)
                    '@"文字[%1]は入力できません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ｷｬﾝｾﾙ
                    e.Cancel = True
                    Dim tb As TextBox = .Editor
                    tb.Text = .GetData(e.Row, e.Col)
                    tb.SelectAll()
                    Exit Sub
                    
                End If
            End With
            
        Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfWfAction_ValidateEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfWfAction_AfterEdit
    '機　能：編集後処理(ﾎﾞﾀﾝ有効ﾁｪｯｸとWF_ID大文字化)
    '引　数：Row：
    '　　　：Col：
    '戻り値：
    '作成日：2012/10/30 (Tue) 13:23:26 T.Oide
    '更新日：2012/10/30 (Tue) 13:23:26
    '備　考：
    Private Sub vsfWfAction_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfWfAction.AfterEdit

        Dim lstrNowEdit     As String

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfWfAction.Rows.Count <= vsfWfAction.Rows.Fixed Then
                Return
            End If
            
            With vsfWfAction
            
                Select Case e.Col
            
                    Case CMlngColWFID
                
                        '@現在編集中の文字列を取得
                        lstrNowEdit = .GetData(e.Row, CMlngColWFID)
                                
                        '@[大文字変換]
                        .SetData(e.Row, CMlngColWFID, StrConv(lstrNowEdit, vbUpperCase))
                    
                End Select
            
            End With
            
            '@確定ﾎﾞﾀﾝﾁｪｯｸ
            Call prvcmdRegistChk()
            
        Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfWfAction_AfterEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfWfAction_BeforeEdit
    '機　能：WF_IDの入力文字数設定
    '引　数：Row：
    '　　　：Col：
    '　　　：Cancel：
    '戻り値：
    '作成日：2012/10/25 (Thu) 11:41:15 T.Oide
    '更新日：2012/10/25 (Thu) 11:41:15
    '備　考：
    Private Sub vsfWfAction_BeforeEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfWfAction.SetupEditor

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfWfAction.Rows.Count <= vsfWfAction.Rows.Fixed Then
                Return
            End If
            
            '@WF_IDは10文字まで
            If e.Col = CMlngColWFID Then
                Dim tb As TextBox = CType(vsfWfAction.Editor, TextBox)
                tb.MaxLength = 10
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfWfAction_BeforeEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfWfAction_Click
    '機　能：
    '引　数：なし
    '戻り値：
    '作成日：2012/10/29 (Mon) 17:24:35 T.Oide
    '更新日：2012/10/29 (Mon) 17:24:35
    '備　考：
    Private Sub vsfWfAction_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfWfAction.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合またはヘッダクリックの場合は処理を抜ける
            If vsfWfAction.Rows.Count <= vsfWfAction.Rows.Fixed OrElse _
                vsfWfAction.MouseRow < vsfWfAction.Rows.Fixed Then
                Return
            End If
                
            With vsfWfAction
            
                Select Case .Col

                    '@削除行ならﾁｪｯｸのON/OFFをする
                    Case CMlngColDelChk

                        '@ﾁｪｯｸをON/OFFする
                        Call prvGuridCheckOnOff()
                        
                End Select
            
            End With
            
            '@確定ﾎﾞﾀﾝの有効/無効ﾁｪｯｸ
            Call prvcmdRegistChk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfWfAction_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
            
        End Try
    End Sub

    '関数名：vsfWfAction_DblClick
    '機　能：
    '引　数：なし
    '戻り値：
    '作成日：2012/10/29 (Mon) 14:47:01 T.Oide
    '更新日：2012/10/29 (Mon) 14:47:01
    '備　考：
    Private Sub vsfWfAction_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfWfAction.DoubleClick
        
        Try
            
            '@編集可否判定
            Call vsfWfAction_Edit()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfWfAction_BeforeEdit"
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
    '関数名：prvfrmxxEN0271_Init
    '機　能：ﾒｲﾝﾌｫｰﾑ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2012/10/24 (Wed) 12:39:35 T.Oide
    '更新日：2012/10/24 (Wed) 12:39:35 T.Oide
    '備　考：
    Private Sub prvfrmxxEN0271_Init()

        Try
            
            '@内部変数の初期化
            'pstrEN0271 = vbNullString
            
            '@確定ﾎﾞﾀﾝの初期化
            cmdRegist.Enabled = True
            
            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfWfAction_Init()
            
            '@終了時にValidateｲﾍﾞﾝﾄを実行しない
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN0271_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN0271_Disp
    '機　能：引継ぎ情報表示
    '引　数：なし
    '戻り値：なし
    '作成日：2012/10/24 (Wed) 12:39:35 T.Oide
    '更新日：2012/10/24 (Wed) 12:39:35 T.Oide
    '備　考：
    Private Sub prvfrmxxEN0271_Disp()

        Try
            
            '@一覧表示
            Call prvvsfWfAction_Disp()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN0271_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfWfAction_Init
    '機　能：ｸﾞﾘｯﾄﾞの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2012/10/24 (Wed) 12:39:35 T.Oide
    '更新日：2012/10/24 (Wed) 12:39:35 T.Oide
    '備　考：
    Private Sub prvvsfWfAction_Init()

        Dim llngCnt As Integer  'ｶｳﾝﾄ

        Try
            
            With vsfWfAction
            
                '@基本設定
                .Clear(ClearFlags.Content)                                 'ｸﾘｱ
                .AllowSorting = AllowSortingEnum.None　                    'ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化(ｿｰﾄなし)
                .Rows.Count = CMlngInitRows                                '初期行数設定
                .SelectionMode = SelectionModeEnum.Row                     '選択モード(行選択)
                .AllowResizing = AllowResizingEnum.Columns                 'ﾏｳｽによる列ｻｲｽﾞ変更の可／不可設定
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter 'ｾﾙ内の文字列がしきれないとき、省略符号（...）表示
                .FocusRect = FocusRectEnum.Light                           'ﾌｫｰｶｽのあり方
                .HighLight = HighLightEnum.Always                          'ﾊｲﾗｲﾄ(ｸﾞﾘｯﾄﾞからﾌｫｰｶｽが外れた場合でも選択中のｾﾙを判るようにする)

                '@一覧表の表題設定
                Dim cellRange As CellRange = .GetCellRange(CMlngRowTitle, CMlngColTitle, CMlngRowTitle, .Cols.Count - 1)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                             '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)                '背景色
                headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMlngCellFontSize, _
                                            headerStyle.Font.Style, headerStyle.Font.Unit)       'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                               '文字位置
                headerStyle.Trimming  = StringTrimming.None                                      'NSYS ﾍｯﾀﾞは省略表示なしに設定
                cellRange.Style = headerStyle

                .SetData(CMlngRowTitle, CMlngColNew, CMstrColNew)         '新規
                .SetData(CMlngRowTitle, CMlngColDelChk, CMstrColDelChk)   '削除
                .SetData(CMlngRowTitle, CMlngColWFID, CMstrColWfId)       'WF_ID
                .SetData(CMlngRowTitle, CMlngColExeTime, CMstrColExeTime) '実行時刻
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngRowTitle).Height = CMlngHHeight                            'ヘッダ高さ
                
                '@残りの行設定
                For llngCnt = 1 To CMlngInitRows - 1
                    .Rows(llngCnt).Height = CMlngHeight                               'データ行高さ
                Next llngCnt
                        
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfWfAction_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfWfAction_Disp
    '機　能：処理記憶設定一覧
    '引　数：なし
    '戻り値：なし
    '作成日：2012/10/24 (Wed) 12:39:35 T.Oide
    '更新日：2012/10/24 (Wed) 12:39:35 T.Oide
    '備　考：
    Private Sub prvvsfWfAction_Disp()
        
        Dim llngCnt       As Integer  '汎用ｶｳﾝﾄ

        Try
            
            '@既にWFｱｸｼｮﾝ予約の子画面で設定した情報があるか
            If pblnEN0271EditFlag = False Then
                '@ない場合、ｻｰﾊﾞから取得した情報をｺﾋﾟｰ
                ptypWfactrsv.lngWfActionCnt = ptypLotActioninfo.lngWfActionCnt
                If Not IsNothing(ptypLotActioninfo.typWfAction) Then
                    If Not IsNothing(ptypWfactrsv.typWfAction) Then
                        ptypWfactrsv.typWfAction.Clear()
                        ptypWfactrsv.typWfAction = Nothing
                    End If
                    ptypWfactrsv.typWfAction = New List(Of WfAction)(ptypLotActioninfo.typWfAction)
                Else
                    ptypWfactrsv.typWfAction = New List(Of WfAction)()
                End If
            End If
            
            With vsfWfAction
                
                '@ﾃﾞｰﾀ件数0件
                If ptypWfactrsv.lngWfActionCnt = 0 Then
                    Exit Sub
                End If
                
                '@描画なし
                .Redraw = False
                
                '@行設定
                .Rows.Count = ptypWfactrsv.lngWfActionCnt + 1
                
                '@ﾃﾞｰﾀ設定
                For llngCnt = 0 To ptypWfactrsv.lngWfActionCnt - 1
                    .SetData(llngCnt+1, CMlngColNew, ptypWfactrsv.typWfAction(llngCnt).strNewFlag)         '新規
                    .SetData(llngCnt+1, CMlngColDelChk, ptypWfactrsv.typWfAction(llngCnt).strDelFlag)      '削除ﾌﾗｸﾞ
                    .SetData(llngCnt+1, CMlngColWFID, ptypWfactrsv.typWfAction(llngCnt).strWfId)           'WF_ID
                    .SetData(llngCnt+1, CMlngColExeTime, ptypWfactrsv.typWfAction(llngCnt).strExecTime)    '実行時刻
                
                    '@有効/無効
                    If ptypWfactrsv.typWfAction(llngCnt).strExecTime <> vbNullString Then
                        '@背景色のｾｯﾄ
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                        Dim cellRange As CellRange = .GetCellRange(llngCnt+1, CMlngColNew, llngCnt+1, .Cols.Count - 1)
                        cellRange.Style = newStyle            '灰色
                    Else
                        '@背景色のｾｯﾄ
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                        newStyle.BackColor = Color.White
                        Dim cellRange As CellRange = .GetCellRange(llngCnt+1, CMlngColNew, llngCnt+1, .Cols.Count - 1)
                        cellRange.Style = newStyle                  '白
                    End If
                Next
            
                '@項目ﾘｽﾄ　ｿｰﾄ処理
                .Col = CMlngColDelChk                   'ｿｰﾄｷｰを指定
                '.Sort = flexSortNumericAscending        '昇順でｿｰﾄ
                .Cols(CMlngColDelChk).Sort = SortFlags.Ascending
                .Sort(SortFlags.UseColSort,CMlngColDelChk)
                .Cols(CMlngColDelChk).Sort = SortFlags.None
                
                '@書式設定
                .Cols(CMlngColDelChk).TextAlign = TextAlignEnum.RightCenter            '表示(右寄せ中央揃え)
                .Cols(CMlngColWFID).TextAlign = TextAlignEnum.LeftCenter               '表示(左寄せ中央揃え)
                .Cols(CMlngColExeTime).TextAlign = TextAlignEnum.LeftCenter            '表示(左寄せ中央揃え)
                
                '@ﾌｫｰｶｽをｾｯﾄ
                .Row = 1
                
                '@ｵｰﾄ幅設定
                '.AutoSizeMode = flexAutoSizeColWidth
                .AutoSizeCols(CMlngColDelChk, .Cols.Count - 1, 6)
                
                '@直接描画
                .Redraw = True
                
            End With
            
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfWfAction_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：prvcmdRegist_chk
    '機　能：登録ﾃﾞｰﾀﾁｪｯｸ
    '引　数：なし
    '戻り値：True：OK、False：NG
    '作成日：2012/10/25 (Thu) 15:45:54 T.Oide
    '更新日：2012/10/25 (Thu) 15:45:54
    '備　考：
    Private Function prvcmdRegist_Chk() As Boolean
        
        Dim llngCnt         As Integer
        Dim llngCnt2        As Integer
        Dim lblnChkFlag     As Boolean
        Dim lstrCurWfId     As String
        Dim llngCurRow      As Integer
        Dim lblnDelChkFlag  As Boolean
        
        Try
            
            lblnChkFlag = True
            
            
            With vsfWfAction
            
                '@WF_IDのﾌｫｰﾏｯﾄﾁｪｯｸ
                '@全行に関して登録ﾃﾞｰﾀﾁｪｯｸ
                For llngCnt = 1 To vsfWfAction.Rows.Count - 1
                    
                    '@削除ﾁｪｯｸはOFFか
                    If .GetCellCheck(llngCnt, CMlngColDelChk) = CheckEnum.Unchecked Then
                    
                        '@WF_IDが10文字以外か
                        If LenB(.GetData(llngCnt, CMlngColWFID)) <> 10 Then
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0124)
                            '@「ウェハーIDは10文字で入力してください」ﾒｯｾｰｼﾞ表示
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@駄目なところを選択
                            .Row = llngCnt
                            .Col = CMlngColWFID
                            
                            lblnChkFlag = False
                            Exit For
                            
                        End If
                    
                    End If
                    
                Next llngCnt
                
                '@WF_IDの重複ﾁｪｯｸ
                '@登録ﾃﾞｰﾀのﾁｪｯｸで既にNGになっていないか
                If lblnChkFlag = True Then
                
                    '@全行に関してWF_IDの重複ﾁｪｯｸ(削除ﾃﾞｰﾀは対象としない)
                    For llngCnt = 1 To vsfWfAction.Rows.Count - 1
                        
                        '@削除ﾁｪｯｸOFFか
                        If .GetCellCheck(llngCnt, CMlngColDelChk) = CheckEnum.Unchecked Then
                            
                            '@現在WF_ID格納
                            lstrCurWfId = .GetData(llngCnt, CMlngColWFID)
                            '@現在行格納
                            llngCurRow = llngCnt
                            
                            '@全行に関してWF_IDの重複ﾁｪｯｸ(削除ﾃﾞｰﾀは対象としない)
                            For llngCnt2 = 1 To vsfWfAction.Rows.Count - 1
                                
                                '@自分以外に削除ﾁｪｯｸなしで同じWF_IDはいるか
                                If llngCurRow <> llngCnt2 And _
                                   lstrCurWfId = .GetData(llngCnt2, CMlngColWFID) And _
                                   .GetCellCheck(llngCnt2, CMlngColDelChk) = CheckEnum.Unchecked Then
                                   
                                    '@重複ﾁｪｯｸｴﾗｰ
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009W)
                                    '@「<TRM9WW>$$ウェハIDが重複しています。$設定を見直してください。」
                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                    
                                    '@駄目なところを選択
                                    .Row = llngCurRow
                                    .Col = CMlngColWFID
                                                                
                                    lblnChkFlag = False
                                    Exit For
                                End If
                                
                            Next llngCnt2
                            
                            '@Falseか
                            If lblnChkFlag = False Then
                                Exit For
                            End If
                            
                        End If
                    
                    Next llngCnt
                    
                End If
                
                '@全行削除ﾁｪｯｸ
                '@登録ﾃﾞｰﾀのﾁｪｯｸで既にNGになっていないか
                If lblnChkFlag = True Then
                    
                    lblnDelChkFlag = False
                    
                    '@全行に関してWF_IDの重複ﾁｪｯｸ(削除ﾃﾞｰﾀは対象としない)
                    For llngCnt = 1 To vsfWfAction.Rows.Count - 1
                
                        '@削除ﾁｪｯｸOFFか
                        If .GetCellCheck(llngCnt, CMlngColDelChk) = CheckEnum.Unchecked Then
                            lblnDelChkFlag = True
                            Exit For
                        End If
                    Next llngCnt
                    
                    '@削除ﾁｪｯｸﾌﾗｸﾞはTrue(全部削除)か
                    If lblnDelChkFlag = False Then
                        
                        '@全部削除ﾁｪｯｸNG
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0125)
                        '@「<TRM125W>$$全て削除する場合は削除ボタンを使用してください。」
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        lblnChkFlag = False     '登録ﾁｪｯｸNG
                    
                    End If
                    
                End If
                
            End With
            
            '@ﾁｪｯｸﾌﾗｸﾞはTrueか
            If lblnChkFlag = True Then
                prvcmdRegist_Chk = True
            Else
                prvcmdRegist_Chk = False
            End If
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmdRegist_chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：vsfWfAction_Edit
    '機　能：ｸﾞﾘｯﾄﾞの編集可否を判定
    '引　数：なし
    '戻り値：
    '作成日：2012/10/29 (Mon) 17:55:15 T.Oide
    '更新日：2012/10/29 (Mon) 17:55:15 T.Oide
    '備　考：
    Private Sub vsfWfAction_Edit()

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfWfAction.Rows.Count <= vsfWfAction.Rows.Fixed Then
                Return
            End If

            With vsfWfAction
                
                '有効行が選択されていない場合
                If .Row < .Rows.Fixed Then
                    Exit Sub
                End If

                Select Case .Col
                    
                    '@WF_IDの場合
                    Case CMlngColWFID
                    
                        '@ﾁｪｯｸはONか
                        If .GetCellCheck(.Row, CMlngColNew) <> CheckEnum.Unchecked Then
                            
                            '@編集状態にする
                            .Select(.Row, .Col)
                            .Styles.Editor.ForeColor = SystemColors.WindowText
                            .Styles.Editor.BackColor = SystemColors.Window
                            .StartEditing()
                            
                        End If
                        
                End Select
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfWfAction_Edit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvGuridCheckOnOff
    '機　能：対象のﾁｪｯｸをON/OFFする
    '引　数：なし
    '戻り値：
    '作成日：2012/10/29 (Mon) 17:55:15 T.Oide
    '更新日：2012/10/29 (Mon) 17:55:15 T.Oide
    '備　考：
    Private Sub prvGuridCheckOnOff()

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfWfAction.Rows.Count <= vsfWfAction.Rows.Fixed Then
                Return
            End If
                
            With vsfWfAction

                '有効行が選択されていない場合
                If .Row < .Rows.Fixed Then
                    Exit Sub
                End If
                        
                '@ﾁｪｯｸはOFFか
                If .GetCellCheck(.Row, CMlngColDelChk) = CheckEnum.Unchecked Then
                    '@ﾁｪｯｸON
                    .SetCellCheck(.Row, CMlngColDelChk, CheckEnum.Checked)
                Else
                    '@ﾁｪｯｸOFF
                    .SetCellCheck(.Row, CMlngColDelChk, CheckEnum.Unchecked)
                End If
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvGuridCheckOnOff"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvcmdRegistChk
    '機　能：確定ﾎﾞﾀﾝ有効/無効ﾁｪｯｸ
    '引　数：なし
    '戻り値：
    '作成日：2012/10/30 (Tue) 13:25:19 T.Oide
    '更新日：2012/10/30 (Tue) 13:25:19
    '備　考：
    Private Sub prvcmdRegistChk()

        Dim lblnChkFlag         As Boolean
        Dim llngCnt             As Integer

        Try
            
            lblnChkFlag = False
            
            '@新規行が1行以上あるか
            For llngCnt = 1 To vsfWfAction.Rows.Count - 1
                '@新規か
                If vsfWfAction.GetCellCheck(llngCnt, CMlngColNew) = CheckEnum.Checked Then
                    lblnChkFlag = True
                    Exit For
                End If
            Next llngCnt
            
            '@既存で削除はあるか
             For llngCnt = 1 To vsfWfAction.Rows.Count - 1
                '@既存で削除はあるか
                If vsfWfAction.GetCellCheck(llngCnt, CMlngColNew) = CheckEnum.Unchecked And _
                   vsfWfAction.GetCellCheck(llngCnt, CMlngColDelChk) = CheckEnum.Checked Then
                    lblnChkFlag = True
                    Exit For
                End If
            Next llngCnt
            
            
            '@ﾌﾗｸﾞは有効か
            If lblnChkFlag = True Then
                cmdRegist.Enabled = True
            Else
                cmdRegist.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmdRegistChk"
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

                    'Case SC_MOVE
                    '    'フォームの移動を無効化する
                    '    m.Result = IntPtr.Zero
                    '    Return
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraFrame.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub


    '関数名 list_BeforeDoubleClick
    '機　能：グリッドダブルクリック前処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/01/14 (Mon) 17:00:00 NSYS
    '備　考：
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfWfAction.BeforeDoubleClick

        ' ObjectをGridに変換
        Dim gridObj As C1FlexGrid
        gridObj = CType(sender, C1FlexGrid)

        Dim colindex As Integer 'ダブルクリックした列番号

        'ダブルクリックした箇所が列の境界線かを判断する
        If gridObj.HitTest(e.X,e.Y).Type = HitTestTypeEnum.ColumnResize Then

            '列の境界線の場合、本来の処理をキャンセル
            e.Cancel = True

            'ダブルクリックした列番号を格納
            colindex = gridObj.HitTest(e.X,e.Y).Column

            'サイズを自動調整
            'gridObj.AutoSizeCol(colindex,6)
        End If

    End Sub


    '関数名：flexGrid_KeyDownEdit
    '機　能：←→キーの取り扱い
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/01/28 (Mon) 10:00:00 NSYS
    '更新日：2019/04/05 (Fri) 12:00:00 NSYS
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfWfAction.KeyDownEdit

        With CType(sender, C1FlexGrid)
            '@'ｶﾚﾝﾄｾﾙがﾍｯﾀﾞｰ行でない場合
            If e.Row >= .Rows.Fixed Then
                Select Case e.KeyCode
                    Case Keys.Left  '[←]ｷｰ押下
                        Dim editor As Object = CType(.Editor, Object)
                        ' 編集不可のコンボボックスの場合
                        ' または、
                        ' テキストボックスまたは編集可のコンボボックスで、かつ、カーソルが先頭の場合は、
                        '   左隣へ
                        If (TypeOf editor Is ComboBox AndAlso _
                                    CType(editor, ComboBox).DropDownStyle = ComboBoxStyle.DropDownList) _
                            OrElse _
                            ((TypeOf editor Is TextBox OrElse TypeOf editor Is ComboBox) AndAlso _
                                (editor.SelectionStart = 0 AndAlso editor.SelectionLength = 0)) Then
                            If .FinishEditing() = True Then
                                ' 左側で固定行直前まで移動可能なセルを探す
                                For lintCnt As Integer = .Col - 1 To .Cols.Fixed Step -1
                                    If .Cols(lintCnt).Visible Then
                                        .Col = lintCnt
                                        Exit For
                                    End If
                                Next lintCnt
                            End If
                            e.Handled = True
                        End If
                    Case Keys.Right '[→]ｷｰ押下
                        Dim editor As Object = CType(.Editor, Object)
                        ' 編集不可のコンボボックスの場合
                        ' または、
                        ' テキストボックスまたは編集可のコンボボックスで、かつ、カーソルが末尾の場合は、
                        '   右隣へ
                        If (TypeOf editor Is ComboBox AndAlso _
                                CType(editor, ComboBox).DropDownStyle = ComboBoxStyle.DropDownList) _
                            OrElse _
                            ((TypeOf editor Is TextBox OrElse TypeOf editor Is ComboBox) AndAlso _
                                (editor.SelectionStart = editor.Text.Length)) Then
                            If .FinishEditing() = True Then
                                ' 右側でグリッドの最後まで移動可能なセルを探す
                                For lintCnt As Integer = .Col + 1 To .Cols.Count - 1 Step 1
                                    If .Cols(lintCnt).Visible Then
                                        .Col = lintCnt
                                        Exit For
                                    End If
                                Next lintCnt
                            End If
                            e.Handled = True
                        End If
                End Select
            End If
        End With

    End Sub

    '関数名：flex_SetupEditor
    '機　能：グリッド内コンボボックス表示行数調整
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/11/14 (Thu) 12:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub flex_SetupEditor(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfWfAction.SetupEditor

        Try
            If TypeOf sender.Editor Is ComboBox
                '行の高さを変更
                Dim editor As ComboBox = CType(sender.Editor, ComboBox)
                editor.DrawMode = DrawMode.OwnerDrawFixed
                editor.DropDownHeight = 106
                editor.MaxDropDownItems = 12
            End If

        Catch ex As Exception
            '異常終了した場合は何もしない

        End Try

    End Sub

    '関数名：cursor_Enter
    '機　能 ： 項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考 ： Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles cmdClose.Enter, _
            cmdRegist.Enter, cmdAddRow.Enter, vsfWfAction.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '自動Validate = OFF
            Case cmdClose.Name
                Me.AutoValidate = AutoValidate.Disable

            '自動Validate = ON
            Case Else
                Me.AutoValidate = AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

End Class
