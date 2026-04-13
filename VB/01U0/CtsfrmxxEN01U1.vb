'ﾌｧｲﾙ名：xxEN01U1.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ﾌｫﾄF/B専用ﾚｼﾋﾟ一覧検索画面
'作成日：2007/08/29 (Wed) 14:49:41 N.Kasai
'更新日：2007/08/29 (Wed) 14:49:41 N.Kasai
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01U1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01U1    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01U1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01U1
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01U1)
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
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN01U1  'ﾛｰｶﾙ機能ID

    '@ｸﾞﾘｯﾄﾞの行ﾀｲﾄﾙ
    Private Const CMlngvsfListNo                As Integer = 0              '№
    Private Const CMlngvsfListRecipeID          As Integer = 1              'ﾚｼﾋﾟID

    '@ｸﾞﾘｯﾄﾞの列幅
    Private Const CMlngvsfWListNo               As Integer = 49             '№
    Private Const CMlngvsfWListRecipeID         As Integer = 200            'ﾚｼﾋﾟID

    '@ｸﾞﾘｯﾄﾞの設定
    Private Const CMlngvsfListRowHeight         As Integer = 38             '行高さ
    Private Const CMlngvsfListTitleRowHeight    As Integer = 24             'ﾀｲﾄﾙ行高さ
    Private Const CMlngvsfListFontSize          As Single = 15.75           'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfListTitleFontSize     As Integer = 12             'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngTitleRow                 As Integer = 0              'ﾀｲﾄﾙ行

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    Private mblnFirstLoad                       As Boolean                  '初回画面ﾛｰﾄﾞ判定ﾌﾗｸﾞ
    Private buttonProcessing                    As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                  'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                  'NSYS WindowCloseフラグ
    Private nowActiveControl                    As Control                  'NSYS ActiveControl保持用
    Private mblnSetFocus                        As Boolean                  'NSYS フォーカス設定フラグ
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
        'NSYS スクロールバーなしグリッドのマウスホイール対応
        pubVsfMouseWheelManager_Set(vsfRecipeList, cmdUP, cmdDown)

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
    '作成日：2007/08/30 (Thu) 13:34:08 N.Kasai
    '更新日：2007/08/30 (Thu) 13:34:08
    '備　考：
    Private Sub Form_Load()

        Try
            
            '@画面情報の初期化
            Call prvfrmxxEN01U1_Init()
            
            '@画面情報表示処理
            Call prvfrmxxEN01U1_Disp()
            
            '@初回ﾛｰﾄﾞﾌﾗｸﾞ
            mblnFirstLoad = True
            
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

    '関数名：Form_QueryUnload
    '機　能：終了処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2007/08/30 (Thu) 13:34:27 N.Kasai
    '更新日：2007/08/30 (Thu) 13:34:27
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try

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

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑActivate
    '引　数：なし
    '戻り値：なし
    '作成日：2007/08/30 (Thu) 13:32:43 N.Kasai
    '更新日：2007/08/30 (Thu) 13:32:43
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            '@初回のみ処理
            If mblnFirstLoad = True Then
                '@初回ﾛｰﾄﾞﾌﾗｸﾞOFF
                mblnFirstLoad = False
                '@初期表示
                With ptypRecipeInfo
                    '@検索ｷｰﾜｰﾄﾞが設定済み
                    If .strSearchRecipeID <> vbNullString Then
                        '@ﾚｼﾋﾟﾃﾞｰﾀが存在する場合
                        If .typMasRecipeNameList.lngMasRecipeNameCnt > 0 Then
                            '@検索ﾎﾞﾀﾝ押下
                            Call cmdSearch_Click(cmdSearch, New EventArgs)
                        End If
                    End If
                End With
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
    '機　能：ﾌｫｰﾑKeyDown
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2007/08/30 (Thu) 13:33:11 N.Kasai
    '更新日：2007/08/30 (Thu) 13:33:11
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
                '@ｸﾞﾘｯﾄﾞｷｰ制御（ｸﾞﾘｯﾄﾞ共通仕様）
                Call pubVsf_KeyDown(e, ActiveControl.Name, vsfRecipeList, cmdUP, cmdDown)

                '@Enterｷｰの場合
                Select Case e.KeyCode
                    Case Keys.Return
                        Select Case ActiveControl.Name
                            '@ﾚｼﾋﾟIDの場合
                            Case txtRecipeID.Name
                                '@Validate処理
                                RemoveHandler txtRecipeID.Validating,AddressOf txtRecipeID_Validate
                                Call txtRecipeID_Validate(txtRecipeID, New CancelEventArgs(True))
                                AddHandler txtRecipeID.Validating,AddressOf txtRecipeID_Validate
                                e.Handled = True
                                
                            '@一覧の場合
                            Case vsfRecipeList.Name
                  
                                With vsfRecipeList
                                    If .Row >= .Rows.Fixed Then
                                        '@確定処理
                                        Call cmdRegist_Click(cmdRegist, New EventArgs)
                                    End If
                                End With
                                
                            '@その他
                            Case Else
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

    '関数名：cmdClose_Click
    '機　能：ﾌﾟﾛｸﾞﾗﾑ終了
    '引　数：なし
    '戻り値：なし
    '作成日：2007/08/30 (Thu) 13:34:49 N.Kasai
    '更新日：2007/08/30 (Thu) 13:34:49
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

    '関数名：cmdUp_Click
    '機　能：ｺﾒﾝﾄ▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/08/30 (Thu) 13:35:03 N.Kasai
    '更新日：2007/08/30 (Thu) 13:35:03
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

            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdUp(vsfRecipeList, cmdUP, cmdDown)

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
    '作成日：2007/08/30 (Thu) 13:35:18 N.Kasai
    '更新日：2007/08/30 (Thu) 13:35:18
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

            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理（ｸﾞﾘｯﾄﾞ共通仕様）を実行する
            Call pubVsfCmdDown(vsfRecipeList, cmdUP, cmdDown)

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

    '関数名：cmdSearch_Click
    '機　能：検索ﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2007/08/29 (Wed) 16:54:35 N.Kasai
    '更新日：2007/08/29 (Wed) 16:54:35
    '備　考：
    Private Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch.Click
        
        Dim llngFindResult  As Integer '検索結果行
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@検索ｷｰﾜｰﾄﾞが空白の場合は検索の必要なし
            If txtRecipeID.Text = vbNullString Then
                Exit Sub
            End If
            
            With vsfRecipeList
                '@一覧が存在しない場合
                If .Rows.Count <= 1 Then
                    '@ﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdSearch)
                    Exit Sub
                End If
                '@検索
                llngFindResult = .FindRow(txtRecipeID.Text, .Rows.Fixed, CMlngvsfListRecipeID, True, False, False)
                '@検索結果
                If llngFindResult <> -1 Then
                    .Row = llngFindResult
                    .Col = CMlngvsfListRecipeID
                    .ShowCell(llngFindResult, CMlngvsfListRecipeID)

                    '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ,保持列)
                    Call pubVsfBeforeSort(vsfRecipeList, CMlngvsfListRecipeID)
                    '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ,保持列,前頁,次頁)
                    Call pubVsfAfterSort(vsfRecipeList, CMlngvsfListRecipeID, Nothing, Nothing, True, True, False)
                    '@ｸﾞﾘｯﾄﾞ表示後処理
                    Call pubVsfDisp(vsfRecipeList, cmdUP, cmdDown)
                Else
                    '@見出し行
                    .Row = 0
                End If
            End With

            '@ﾌｫｰｶｽｾｯﾄ
            If nowActiveControl Is txtRecipeID OrElse mblnSetFocus = False Then
                Call pubSetFocus(vsfRecipeList)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSearch_Click"
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
    '作成日：2007/08/30 (Thu) 13:35:37 N.Kasai
    '更新日：2007/08/30 (Thu) 13:35:37
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
            
            With vsfRecipeList
                '@行選択の場合
                If .Row > 0 Then
                    '@選択行を引き渡し構造体へｾｯﾄ
                    ptypRecipeInfo.strResultRecipeID = .GetData(.Row, CMlngvsfListRecipeID)
                Else
                    Exit Sub
                End If
            End With
            
            '@ﾌｫｰﾑを閉じる終了
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

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================

    '関数名：prvfrmxxEN01U1_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2007/08/29 (Wed) 16:16:52 N.Kasai
    '更新日：2007/08/29 (Wed) 16:16:52
    '備　考：
    Private Sub prvfrmxxEN01U1_Init()

        Try
            
            '@ﾃｷｽﾄ
            txtRecipeID.Text = vbNullString
            
            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfRecipeList_Init()
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ
            cmdRegist.Enabled = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01U1_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN01U1_Disp
    '機　能：画面情報表示
    '引　数：なし
    '戻り値：なし
    '作成日：2007/08/29 (Wed) 16:21:52 N.Kasai
    '更新日：2007/08/29 (Wed) 16:21:52
    '備　考：
    Private Sub prvfrmxxEN01U1_Disp()
        
        Dim llngCnt As Integer
        
        Try
            
            '@検索ｷｰﾜｰﾄﾞ設定
            txtRecipeID.Text = ptypRecipeInfo.strSearchRecipeID
            
            '@ﾃﾞｰﾀ表示
            With vsfRecipeList
                '@描画ﾛｯｸ
                .Redraw = False
                '@行数設定
                .Rows.Count = ptypRecipeInfo.typMasRecipeNameList.lngMasRecipeNameCnt + 1
                .Row = .Rows.Fixed - 1
                '@ﾃﾞｰﾀ表示
                For llngCnt = 0 To ptypRecipeInfo.typMasRecipeNameList.lngMasRecipeNameCnt - 1
                    
                    .SetData(llngCnt + 1, CMlngvsfListNo, llngCnt + 1)
                    .SetData(llngCnt + 1, CMlngvsfListRecipeID, _
                            ptypRecipeInfo.typMasRecipeNameList.typMasRecipeName(llngCnt).strRecipeId)
                    '@行の高さ設定
                    .Rows(llngCnt + 1).Height = CMlngvsfListRowHeight
                Next
                '@直接描画
                .Redraw = True
                'ﾛｯｸ解除
                .Enabled = True
            End With
            
            '@ｸﾞﾘｯﾄﾞ表示後処理
            Call pubVsfDisp(vsfRecipeList, cmdUP, cmdDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01U1_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfRecipeList_Init
    '機　能：ｸﾞﾘｯﾄﾞの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2007/08/29 (Wed) 16:20:13 N.Kasai
    '更新日：2007/08/29 (Wed) 16:20:13
    '備　考：
    Private Sub prvvsfRecipeList_Init()

        Try
            
            With vsfRecipeList
                '@行初期化
                .Rows.Count = 1
            
                '@行の高さ指定
                .Rows.DefaultSize = CMlngvsfListRowHeight
                .Rows(0).Height = CMlngvsfListTitleRowHeight
                
                '@ﾌｫﾝﾄの設定
                .Styles.Normal.Font = New Font(.Font.FontFamily, CMlngvsfListFontSize, .Font.Style, .Font.Unit)
                
                .Select(0, CMlngvsfListNo, .Rows.Fixed - 1, .Cols.Count - 1)
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.Font = New Font(lFixedStyle.Font.FontFamily, CMlngvsfListTitleFontSize, _
                                            lFixedStyle.Font.Style, lFixedStyle.Font.Unit)
                
                '@見出し行の色設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngBlueColor")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
                newStyle.ForeColor = Color.Yellow
                Dim cellRange As CellRange = .GetCellRange(0, CMlngvsfListNo, .Rows.Fixed - 1, .Cols.Count - 1)
                cellRange.Style = newStyle
                
                '@列幅の設定
                .Cols(CMlngvsfListNo).Width = CMlngvsfWListNo
                .Cols(CMlngvsfListRecipeID).Width = CMlngvsfWListRecipeID
                
                '@見出し行の文字位置設定
                Dim headerCellRange As CellRange = .GetCellRange(0, CMlngvsfListNo, .Rows.Fixed - 1, .Cols.Count - 1)
                Dim headerStyle As CellStyle = .Styles.Add("textAlign")
                headerStyle.TextAlign = TextAlignEnum.CenterCenter
                headerCellRange.Style = headerStyle

                '@ﾍｯﾀﾞのｿｰﾄ指定なし
                .AllowSorting = AllowSortingEnum.None
                
                '@ﾛｯｸ
                .Enabled = False
            End With
            
            '@次,前ﾍﾟｰｼﾞﾎﾞﾀﾝ使用不可
            cmdUP.Enabled = False
            cmdDown.Enabled = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfRecipeList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtRecipeID_Validate
    '機　能：ﾚｼﾋﾟIDValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/08/30 (Thu) 13:36:32 N.Kasai
    '更新日：2007/08/30 (Thu) 13:36:32
    '備　考：
    Private Sub txtRecipeID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtRecipeID.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            mblnSetFocus = True

            'NSYS 現在のActiveControlを保持する
            nowActiveControl = Me.ActiveControl
            
            '@検索ｷｰﾜｰﾄﾞが存在している場合
            If txtRecipeID.Text <> vbNullString Then
                '@検索処理
                Call cmdSearch_Click(cmdSearch, New EventArgs)
            Else
                '@空ENTER（ﾌｫｰｶｽ移動）
                '@ﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = txtRecipeID.Name Then
                    Call pubSetFocus(cmdSearch)
                End If
            End If

            mblnSetFocus = False
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtRecipeID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRecipeList_DblClick
    '機　能：ｸﾞﾘｯﾄﾞDblClick
    '引　数：なし
    '戻り値：なし
    '作成日：2007/08/30 (Thu) 13:37:06 N.Kasai
    '更新日：2007/08/30 (Thu) 13:37:06
    '備　考：
    Private Sub vsfRecipeList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfRecipeList.DoubleClick

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfRecipeList.Rows.Count <= vsfRecipeList.Rows.Fixed Then
                Return
            End If
            
            With vsfRecipeList
            
                If .MouseRow > 0 Then
                    If .Row > 0 Then
                        '@確定処理
                        Call cmdRegist_Click(cmdRegist, New EventArgs)
                    End If
                End If
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRecipeList_DblClick"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：vsfRecipeList_EnterCell
    '機　能：ｸﾞﾘｯﾄﾞEnterCell
    '引　数：なし
    '戻り値：なし
    '作成日：2007/08/30 (Thu) 13:37:47 N.Kasai
    '更新日：2007/08/30 (Thu) 13:37:47
    '備　考：
    Private Sub vsfRecipeList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfRecipeList.EnterCell

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfRecipeList.Rows.Count <= vsfRecipeList.Rows.Fixed Then
                Return
            End If
            
            With vsfRecipeList
                If .Row > 0 Then
                    cmdRegist.Enabled = True    '使用可
                Else
                    cmdRegist.Enabled = False   '使用不可
                End If
            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRecipeList_EnterCell"
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
    
End Class
