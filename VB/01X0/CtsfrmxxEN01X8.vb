'ﾌｧｲﾙ名：xxEN01X8.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：号機記憶工程一覧
'作成日：2007/05/29 (Tue) 17:01:02 N.Kasai
'更新日：2007/05/29 (Tue) 17:01:02 N.Kasai
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01X8
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01X8    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01X8
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01X8
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01X8)
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
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN01X8          'ﾛｰｶﾙ機能ID

    '@vsfWpRestrictの定数宣言（ｶﾗﾑ）
    Private Const CMlngColNo                    As Integer = 0                         '番号
    Private Const CMlngColOpId                  As Integer = 1                         '大工程
    Private Const CMlngColStepId                As Integer = 2                         '小工程

    '@vsfWpRestrictの定数宣言（表示幅）
    Private Const CMlngColWNo                   As Integer = 72                       '番号
    Private Const CMlngColWOpId                 As Integer = 144                      '大工程
    Private Const CMlngColWStepId               As Integer = 144                      '小工程

    '@vsfWpRestrictの定数宣言（ﾀｲﾄﾙ）
    Private Const CMstrColNo                    As String = "番号"                    '番号
    Private Const CMstrColOpId                  As String = "大工程"                  '大工程
    Private Const CMstrColStepId                As String = "小工程"                  '小工程

    '@ｸﾞﾘｯﾄﾞの初期値定数宣言
    Private Const CMlngRowTitle                 As Integer = 0                         'ﾀｲﾄﾙ
    Private Const CMlngColTitle                 As Integer = 0                         'ﾀｲﾄﾙ
    Private Const CMlngGridFixedCols            As Integer = 0                         'ｸﾞﾘｯﾄﾞのFixedCol
    Private Const CMlngGridFixedRows            As Integer = 1                         'ｸﾞﾘｯﾄﾞのFixedRow
    Private Const CMlngCellFontSize             As Integer = 11                        'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngHHeight                  As Integer = 20                        'ﾍｯﾀﾞｰの高さ
    Private Const CMlngHeight                   As Integer = 24                        '1ｽﾛｯﾄの高さ
    Private Const CMlngInitRows                 As Integer = 1                         '初期表示行(=1)

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    Private mblnFormLoad                        As Boolean                          '起動ﾌﾗｸﾞ
    Private buttonProcessing                    As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                          'NSYS システムコマンドでの画面クローズ

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
    '作成日：2007/05/30 (Wed) 10:27:26 N.Kasai
    '更新日：2007/05/30 (Wed) 10:27:26
    '備　考：
    Private Sub Form_Load()

        Try

            '@Escﾎﾞﾀﾝを無効
            Me.CancelButton = Nothing

            '@画面初期化
            Call prvfrmxxEN01X8_Init()

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
    '作成日：2007/05/30 (Wed) 10:26:42 N.Kasai
    '更新日：2007/05/30 (Wed) 10:26:42
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
                Call prvfrmxxEN01X8_Disp()
                
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
    '機　能：ﾌｫｰｶｽ制御
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2007/05/30 (Wed) 10:29:45 N.Kasai
    '更新日：2007/05/30 (Wed) 10:29:45
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If

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
    '機　能：ﾌｫｰﾑ終了前処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2007/05/30 (Wed) 10:21:19 N.Kasai
    '更新日：2007/05/30 (Wed) 10:21:19
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim ltypWpRestrictInfo As WpRestrictInfo    'ﾃﾞｰﾀ構造体
        
        Try

            '@配列の初期化
            ptypWpRestrictInfo = ltypWpRestrictInfo
            
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
    '作成日：2007/05/30 (Wed) 10:29:26 N.Kasai
    '更新日：2007/05/30 (Wed) 10:29:26
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
    '作成日：2007/05/30 (Wed) 10:23:03 N.Kasai
    '更新日：2007/05/30 (Wed) 10:23:03
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
                
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
                
           With vsfWpRestrict
                
                '@無効ﾃﾞｰﾀの場合
                If .GetCellRange(.Row, CMlngColNo).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngGridGray) Then
                    Exit Sub
                End If
            
                '@戻り値に値ｾｯﾄ
                pstrEN01X8 = .GetData(.Row, CMlngColNo)
            End With
            
            '@ｻﾌﾞ画面を閉じる
            Call cmdClose_Click(cmdClose,New EventArgs)

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

    '関数名：vsfWpRestrict_DblClick
    '機　能：ｸﾞﾘｯﾄﾞﾀﾞﾌﾞﾙｸﾘｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2007/05/30 (Wed) 10:34:00 N.Kasai
    '更新日：2007/05/30 (Wed) 10:34:00
    '備　考：
    Private Sub vsfWpRestrict_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfWpRestrict.DoubleClick

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfWpRestrict.Rows.Count <= vsfWpRestrict.Rows.Fixed Then
                Return
            End If

             With vsfWpRestrict
                If .Row > 0 Then
                    '@設定ﾎﾞﾀﾝｸﾘｯｸ
                    Call cmdRegist_Click(cmdRegist,New EventArgs)
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfWpRestrict_DblClick"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：vsfWpRestrict_EnterCell
    '機　能：Enter処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/05/30 (Wed) 10:17:39 N.Kasai
    '更新日：2007/05/30 (Wed) 10:17:39
    '備　考：
    Private Sub vsfWpRestrict_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfWpRestrict.EnterCell

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfWpRestrict.Rows.Count <= vsfWpRestrict.Rows.Fixed Then
                Return
            End If

            With vsfWpRestrict
                
                If .Row > 0 Then
                    '@無効ﾃﾞｰﾀの場合
                    If .GetCellRange(.Row, CMlngColNo).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngGridGray) Then
                        cmdRegist.Enabled = False
                    Else
                        cmdRegist.Enabled = True
                    End If
                End If
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfWpRestrict_EnterCell"
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
    '関数名：prvfrmxxEN01X8_Init
    '機　能：ﾒｲﾝﾌｫｰﾑ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2007/05/30 (Wed) 10:23:54 N.Kasai
    '更新日：2007/05/30 (Wed) 10:23:54
    '備　考：
    Private Sub prvfrmxxEN01X8_Init()

        Try
            
            '@内部変数の初期化
            pstrEN01X8 = vbNullString
            
            '@ﾎﾞﾀﾝの初期化
            cmdRegist.Enabled = False                       '確定
            
            '@ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfWpRestrict_Init()
            
            '@終了時にValidateｲﾍﾞﾝﾄを実行しない
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01X8_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN01X8_Disp
    '機　能：引継ぎ情報表示
    '引　数：なし
    '戻り値：なし
    '作成日：2007/05/30 (Wed) 10:28:53 N.Kasai
    '更新日：2007/05/30 (Wed) 10:28:53
    '備　考：
    Private Sub prvfrmxxEN01X8_Disp()

        Try
            
            '@一覧表示
            Call prvvsfWpRestrict_Disp()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01X8_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfWpRestrict_Init
    '機　能：ｸﾞﾘｯﾄﾞの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2007/05/30 (Wed) 10:07:35 N.Kasai
    '更新日：2007/05/30 (Wed) 10:07:35
    '備　考：
    Private Sub prvvsfWpRestrict_Init()

        Dim llngCnt As Integer  'ｶｳﾝﾄ

        Try
            
            With vsfWpRestrict
                '@ｸﾘｱ
                .Clear(ClearFlags.Content)
                
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化(ｿｰﾄなし)
                .AllowSorting = AllowSortingEnum.None
                        
                '@初期行数設定
                .Rows.Count = CMlngInitRows

                .SelectionMode = SelectionModeEnum.Row
                
                '@ﾏｳｽによる列ｻｲｽﾞ変更の可／不可設定
                .AllowResizing = AllowResizingEnum.Columns
                
                '@ﾌｫｰｶｽのあり方
                .FocusRect = FocusRectEnum.Light
                
                '@選択行のﾊｲﾗｲﾄ表示
                .HighLight = HighLightEnum.WithFocus
                
                '@一覧表の表題設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.ForeColor = Color.Yellow                   '文字色
                lFixedStyle.BackColor = Color.Navy                     '背景色
                With .Font                                             'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                    lFixedStyle.Font = New Font(.FontFamily, CMlngCellFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngRowTitle, CMlngColNo, CMstrColNo)           '番号
                .SetData(CMlngRowTitle, CMlngColOpId, CMstrColOpId)       '大工程
                .SetData(CMlngRowTitle, CMlngColStepId, CMstrColStepId)   '小工程
                
                '@表示位置の設定
                .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngRowTitle).Height = CMlngHHeight                            '高さ
                
                '@残りの行設定
                For llngCnt = 1 To CMlngInitRows - 1
                    .Rows(llngCnt).Height = CMlngHeight                               '高さ
                Next llngCnt
                        
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfWpRestrict_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfWpRestrict_Disp
    '機　能：処理記憶設定一覧
    '引　数：なし
    '戻り値：なし
    '作成日：2007/05/30 (Wed) 10:07:52 N.Kasai
    '更新日：2007/05/30 (Wed) 10:07:52
    '備　考：
    Private Sub prvvsfWpRestrict_Disp()
        
        Dim llngCnt       As Integer  '汎用ｶｳﾝﾄ

        Try
            
            With vsfWpRestrict
                
                '@ﾃﾞｰﾀ件数0件
                If ptypWpRestrictInfo.lngWpRestrictCnt = 0 Then
                    Exit Sub
                End If
                
                '@描画なし
                .Redraw = False
                
                '@行設定
                RemoveHandler vsfWpRestrict.EnterCell,AddressOf vsfWpRestrict_EnterCell
                .Rows.Count = ptypWpRestrictInfo.lngWpRestrictCnt + 1
                .Row = 0
                AddHandler vsfWpRestrict.EnterCell,AddressOf vsfWpRestrict_EnterCell

                '@ﾃﾞｰﾀ設定
                For llngCnt = 1 To ptypWpRestrictInfo.lngWpRestrictCnt
                    .SetData(llngCnt, CMlngColNo, ptypWpRestrictInfo.typWpRestrict(llngCnt -1).strWpRestrictNum)
                    .SetData(llngCnt, CMlngColOpId, ptypWpRestrictInfo.typWpRestrict(llngCnt -1).strOpID)
                    .SetData(llngCnt, CMlngColStepId, ptypWpRestrictInfo.typWpRestrict(llngCnt -1).strStepID)
                
                    '@有効/無効
                    If ptypWpRestrictInfo.typWpRestrict(llngCnt -1).strValidFlag = "0" Then
                        '@背景色のｾｯﾄ
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                        Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngColNo, llngCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle
                    Else
                        '@背景色のｾｯﾄ
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                        newStyle.BackColor = Color.White
                        Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngColNo, llngCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle
                    End If
                Next
            
                '@項目ﾘｽﾄ　ｿｰﾄ処理
                .Col = CMlngColNo                       'ｿｰﾄｷｰを指定
                '.Sort = flexSortNumericAscending        '昇順でｿｰﾄ
                .Sort(SortFlags.Ascending, CMlngColNo)

                '@書式設定
                .Cols(CMlngColNo).TextAlign = TextAlignEnum.RightCenter                '表示(右寄せ中央揃え)
                .Cols(CMlngColOpId).TextAlign = TextAlignEnum.LeftCenter               '表示(左寄せ中央揃え)
                .Cols(CMlngColStepId).TextAlign = TextAlignEnum.LeftCenter             '表示(左寄せ中央揃え)
                
                '@ﾌｫｰｶｽをｾｯﾄ
                .Row = 1
                
                '@ｵｰﾄ幅設定
                '.AutoSizeMode = flexAutoSizeColWidth
                .AutoSizeCols(CMlngColNo, CMlngColOpId, 6)
                .AutoSizeCol(CMlngColStepId, -2)

                '@直接描画
                .Redraw = True
            End With
            
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfWpRestrict_Disp"
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

                    Case SC_MOVE
                        'フォームの移動を無効化する
                        m.Result = IntPtr.Zero
                        Return
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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfWpRestrict.BeforeDoubleClick

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
            gridObj.AutoSizeCol(colindex,6)
        End If

    End Sub

End Class
