'ﾌｧｲﾙ名：xxEN01G1.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：装置ﾚｼﾋﾟ表示画面
'作成日：2004/10/21 (Thu) 20:23:14 H.Wajima
'更新日：2005/10/25 (Tue) 15:22:09 N.Kasai
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01G1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01G1    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01G1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01G1
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01G1)
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

    '======================================Private==========================================

    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN01G1          'ﾛｰｶﾙﾒﾆｭｰKey

    '@ｸﾞﾘｯﾄﾞ共通
    Private Const CMlngVsfHFontSize             As Integer = 12                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight               As Integer = 27                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngVsfHeight                As Integer = 43                     '1ｽﾛｯﾄの高さ
    Private Const CMlngvsfFixedRow              As Integer = 0                      'ﾀｲﾄﾙ行
    Private Const CMlngvsfFixedRows             As Integer = 1                      'ﾀｲﾄﾙ行数
    Private Const CMlngvsfAllRow                As Integer = -1                     '全行指定
    Private Const CMlngvsfColS                  As Integer = 7                      '列数
    Private Const CMlngvsfGridFontSize          As Integer = 16                     'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfFrozenCols            As Integer = 2                      '固定列

    '@装置ﾚｼﾋﾟ一覧定数(列番号)
    Private Const CMlngvsfColNo                 As Integer = 0                      '№
    Private Const CMlngvsfColWpName             As Integer = 1                      '装置名
    Private Const CMlngvsfColDefault            As Integer = 2                      'ﾃﾞﾌｫﾙﾄ
    Private Const CMlngvsfColRecipeID           As Integer = 3                      'ﾚｼﾋﾟID
    Private Const CMlngvsfColRecipeItem         As Integer = 4                      'ﾚｼﾋﾟｱｲﾃﾑ
    Private Const CMlngvsfColRecipeValue        As Integer = 5                      'ﾚｼﾋﾟﾊﾟﾗﾒｰﾀ値
    Private Const CMlngvsfColRecipeComments     As Integer = 6                      'ﾚｼﾋﾟｺﾒﾝﾄ

    '@装置ﾚｼﾋﾟ一覧定数(列幅)
    Private Const CMlngvsfColWNo                As Integer = 37                     '№
    Private Const CMlngvsfColWWPName            As Integer = 247                    '装置名
    Private Const CMlngvsfCOlWDefault           As Integer = 53                     'ﾃﾞﾌｫﾙﾄ
    Private Const CMlngvsfCOlWRecipeID          As Integer = 233                    'ﾚｼﾋﾟID
    Private Const CMlngvsfCOlWRecipeItem        As Integer = 167                    'ﾚｼﾋﾟｱｲﾃﾑ
    Private Const CMlngvsfCOlWRecipeValue       As Integer = 167                    'ﾚｼﾋﾟﾊﾟﾗﾒｰﾀ値
    Private Const CMlngvsfCOlWRecipeComments    As Integer = 167                    'ﾚｼﾋﾟｺﾒﾝﾄ

    '@装置ﾚｼﾋﾟ一覧定数(ﾀｲﾄﾙ)
    Private Const CMstrvsfColTNo                As String = "№"                    '№
    Private Const CMstrvsfColTWPName            As String = "装置名"                '装置名
    Private Const CMstrvsfColTDefault           As String = "ﾃﾞﾌｫﾙﾄ"                'ﾃﾞﾌｫﾙﾄ
    Private Const CMstrvsfColTWFID              As String = "WFID"                  'WFID
    Private Const CMstrvsfColTRecipeID          As String = "レシピID"               'ﾚｼﾋﾟID
    Private Const CMstrvsfColTRecipeItem        As String = "ﾚｼﾋﾟﾊﾟﾗﾒｰﾀ"            'ﾚｼﾋﾟﾊﾟﾗﾒｰﾀ
    Private Const CMstrvsfColTRecipeValue       As String = "ﾚｼﾋﾟﾊﾟﾗﾒｰﾀ値"           'ﾚｼﾋﾟﾊﾟﾗﾒｰﾀ値
    Private Const CMstrvsfColTRecipeComments    As String = "レシピコメント"        'ﾚｼﾋﾟｺﾒﾝﾄ

    '@表示用ﾌｫｰﾏｯﾄ
    Private Const CMstrDefaultOn                As String = "○"                    'ﾃﾞﾌｫﾙﾄ表示
    Private Const CMstrDataTypeA                As String = "A"                     '文字ﾃﾞｰﾀﾀｲﾌﾟ
    Private Const CMstrDataTypeN                As String = "N"                     '数字ﾃﾞｰﾀﾀｲﾌﾟ
    '@ﾌﾗｸﾞ判定
    Private Const CMstrDefaultFlgOn             As String = "1"                     'ﾃﾞﾌｫﾙﾄﾌﾗｸﾞON
    Private Const CMstrHistoryFlgOn             As String = "1"                     '実績ﾌﾗｸﾞON

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private buttonProcessing                    As Boolean                          'NSYS ボタン2度押し対策

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
        'NSYS スクロールバーなしグリッドのマウスホイール対応
        pubVsfMouseWheelManager_Set(vsfWPRecipeList, cmdUP, cmdDown, cmdLeft, cmdRight)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ Load処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/27 (Wed) 13:11:26 H.Wajima
    '更新日：2004/10/27 (Wed) 13:11:26
    '備　考：
    Private Sub Form_Load()

        Try

            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            '@ﾍｯﾀﾞ部の初期化
            lblCarrierID.Text = vbNullString                'ｷｬﾘｱID
            lblLotID.Text = vbNullString                    'ﾛｯﾄID
            lblOpID.Text = vbNullString                     '大工程
            lblStepID.Text = vbNullString                   '小工程
            lblSelectConditionID.Text = vbNullString        'WF選択条件
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化
            cmdLeft.Enabled = False                         '≪ﾎﾞﾀﾝ
            cmdRight.Enabled = False                        '≫ﾎﾞﾀﾝ
            
            '@装置ﾚｼﾋﾟﾘｽﾄ初期化処理
            Call prvvsfWPRecipeList_Init()
            
            '@装置ﾚｼﾋﾟﾘｽﾄ表示処理
            Call prvvsfWPRecipeList_Disp()
            
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
    '機　能：ﾌｫｰﾑKeyDown
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2007/07/06 (Fri) 13:29:45 N.Kasai
    '更新日：2007/07/06 (Fri) 13:29:45
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            
            '@ｸﾞﾘｯﾄﾞｷｰ制御（ｸﾞﾘｯﾄﾞ共通仕様）
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfWPRecipeList, cmdUP, cmdDown)
            '@ｸﾞﾘｯﾄﾞｷｰ制御（ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、左ﾎﾞﾀﾝ、右ﾎﾞﾀﾝ）
            Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfWPRecipeList, cmdLeft, cmdRight)

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
    '機　能：閉じるﾎﾞﾀﾝ Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/27 (Wed) 13:12:34 H.Wajima
    '更新日：2004/10/27 (Wed) 13:12:34
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
            
            '@ﾌｫｰﾑを閉じる
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

    '関数名：cmdDown_Click
    '機　能：▼ﾎﾞﾀﾝ Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/27 (Wed) 13:12:51 H.Wajima
    '更新日：2004/10/27 (Wed) 13:12:51
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
            Call pubVsfCmdDown(vsfWPRecipeList, cmdUP, cmdDown)

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

    '関数名：cmdUp_Click
    '機　能：▲ﾎﾞﾀﾝ Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/27 (Wed) 13:13:06 H.Wajima
    '更新日：2004/10/27 (Wed) 13:13:06
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
            Call pubVsfCmdUp(vsfWPRecipeList, cmdUP, cmdDown)

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

    '関数名：cmdLeft_Click
    '機　能：≪ﾎﾞﾀﾝ Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/21 (Thu) 14:14:10 H.Wajima
    '更新日：2007/07/06 (Fri) 13:27:32 N.Kasai
    '備　考：
    '　　　：2007/07/06 (Fri) 13:27:32 N.Kasai  ｸﾞﾘｯﾄﾞ共通化
    Private Sub cmdLeft_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLeft.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2007/07/06 (Fri) 13:27:29 N.Kasai **************************************************
        '    '@左ｽｸﾛｰﾙ処理
        '    Call prvcmdLeft_Proc(vsfWPRecipeList, cmdLeft, cmdRight)
            '@左ｽｸﾛｰﾙﾎﾞﾀﾝ制御
            Call pubVsfCmdLeft(vsfWPRecipeList, cmdLeft, cmdRight)
        '@↑2007/07/06 (Fri) 13:27:29 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLeft_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRight_Click
    '機　能：≫ﾎﾞﾀﾝ Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/21 (Thu) 14:15:05 H.Wajima
    '更新日：2007/07/06 (Fri) 13:11:29 N.Kasai
    '備　考：
    '　　　：2007/07/06 (Fri) 13:11:29 N.Kasai  ｸﾞﾘｯﾄﾞ共通化
    Private Sub cmdRight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRight.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2007/07/06 (Fri) 13:11:27 N.Kasai **************************************************
        '    '@右ｽｸﾛｰﾙ処理
        '    Call prvcmdRight_Proc(vsfWPRecipeList, cmdLeft, cmdRight)
            '@右ｽｸﾛｰﾙﾎﾞﾀﾝ処理
            Call pubVsfCmdRight(vsfWPRecipeList, cmdLeft, cmdRight)
        '@↑2007/07/06 (Fri) 13:11:27 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRight_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：prvvsfWPRecipeList_Init
    '機　能：装置ﾚｼﾋﾟﾘｽﾄ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/27 (Wed) 13:11:55 H.Wajima
    '更新日：2005/01/31 (Mon) 17:26:27 N.Kasai
    '備　考：2004/11/10 (Wed) 18:07:30 H.Wajima     構造体空対応
    '　　　：2005/01/31 (Mon) 17:26:27 N.Kasai      CMP対応（№304）ﾚｼﾋﾟｱｲﾃﾑ追加
    Private Sub prvvsfWPRecipeList_Init()

        Try

            With vsfWPRecipeList
                .Row = -1
                '@列数
                .Cols.Count = CMlngvsfColS
                '@行数
                .Rows.Count = .Rows.Fixed
                '@ﾌｫﾝﾄｻｲｽﾞ(16)
                With .Font
                    vsfWPRecipeList.Font = New Font(.FontFamily, CMlngvsfGridFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                
                '@行選択
                .SelectionMode = SelectionModeEnum.Row
                '@ﾌｫｰｶｽ表示なし
                .FocusRect = FocusRectEnum.None
                '@ﾊｲﾗｲﾄ表示
                .HighLight = HighLightEnum.Never
                '@省略符号（...）を表示
                .Styles.Normal.Trimming = StringTrimming.None
                '@ｿｰﾄ機能なし
                .AllowDragging = AllowDraggingEnum.None
                .AllowSorting = AllowSortingEnum.None
                
                '@一覧表の表題設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                With .Font                                              'ﾌｫﾝﾄｻｲｽﾞ
                    lFixedStyle.Font = New Font(.FontFamily, CMlngVsfHFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                lFixedStyle.ForeColor = Color.Yellow                    '文字色
                lFixedStyle.BackColor = Color.Navy                      '背景色
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter      '配置
                lFixedStyle.Trimming = StringTrimming.None              '省略表示なし
                
                .SetData(CMlngvsfFixedRow, CMlngvsfColNo, CMstrvsfColTNo)                         '№
                .SetData(CMlngvsfFixedRow, CMlngvsfColWpName, CMstrvsfColTWPName)                 '装置名
                .SetData(CMlngvsfFixedRow, CMlngvsfColDefault, CMstrvsfColTDefault)               'ﾃﾞﾌｫﾙﾄ
                .SetData(CMlngvsfFixedRow, CMlngvsfColRecipeID, CMstrvsfColTRecipeID)             'ﾚｼﾋﾟID
                .SetData(CMlngvsfFixedRow, CMlngvsfColRecipeItem, CMstrvsfColTRecipeItem)         'ﾚｼﾋﾟｱｲﾃﾑ
                .SetData(CMlngvsfFixedRow, CMlngvsfColRecipeValue, CMstrvsfColTRecipeValue)       'ﾚｼﾋﾟ値
                .SetData(CMlngvsfFixedRow, CMlngvsfColRecipeComments, CMstrvsfColTRecipeComments) 'ﾚｼﾋﾟｺﾒﾝﾄ
                
                '@列幅設定
                .Cols(CMlngvsfColNo).Width = CMlngvsfColWNo                           '№
                .Cols(CMlngvsfColWpName).Width = CMlngvsfColWWPName                   '装置名
                .Cols(CMlngvsfColDefault).Width = CMlngvsfCOlWDefault                 'ﾃﾞﾌｫﾙﾄ
                .Cols(CMlngvsfColRecipeID).Width = CMlngvsfCOlWRecipeID               'ﾚｼﾋﾟID
                .Cols(CMlngvsfColRecipeItem).Width = CMlngvsfCOlWRecipeItem           'ﾚｼﾋﾟｱｲﾃﾑ
                .Cols(CMlngvsfColRecipeValue).Width = CMlngvsfCOlWRecipeValue         'ﾚｼﾋﾟﾊﾟﾗﾒｰﾀ値
                .Cols(CMlngvsfColRecipeComments).Width = CMlngvsfCOlWRecipeComments   'ﾚｼﾋﾟｺﾒﾝﾄ

                '@行の高さ
                .Rows.DefaultSize = CMlngVsfHeight
                .Rows(CMlngvsfFixedRow).Height = CMlngVsfHHeight
                
                '@結合セルの設定
                .AllowMerging = AllowMergingEnum.RestrictAll
                .Cols(CMlngvsfColNo).AllowMerging = True                 '№
                .Cols(CMlngvsfColWpName).AllowMerging = True             '装置名
                .Cols(CMlngvsfColDefault).AllowMerging = True            'ﾃﾞﾌｫﾙﾄﾌﾗｸﾞ
                .Cols(CMlngvsfColRecipeID).AllowMerging = True           'ﾚｼﾋﾟID
                .Cols(CMlngvsfColRecipeComments).AllowMerging = True     'ﾚｼﾋﾟｺﾒﾝﾄ
                
                '@固定列
                .Cols.Frozen = CMlngvsfFrozenCols
                '@横ｽｸﾛｰﾙ画面初期化処理
                .LeftCol = CMlngvsfFrozenCols
                '@ﾛｯｸ
                .Enabled = False
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfWPRecipeList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfWPRecipeList_Disp
    '機　能：装置ﾚｼﾋﾟﾘｽﾄ 表示項目設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/10/31 (Mon) 16:46:18 N.Kasai
    '更新日：2006/03/16 (Thu) 14:13:28 N.Kasai
    '備　考：
    '　　　：2006/03/16 (Thu) 14:13:28 N.Kasai  ﾌｫﾄF/B設定ににより小数点以下の値が存在することによってCLではﾌｫｰﾏｯﾄ表示はしない（DBの内容を直表示）
    Private Sub prvvsfWPRecipeList_Disp()
        
        Dim llngCnt                 As Integer      '汎用ｶｳﾝﾀ
        Dim llngCnt2                As Integer      '汎用ｶｳﾝﾀ
        Dim llngCnt3                As Integer      '汎用ｶｳﾝﾀ
        Dim llngRowCnt              As Integer      '行ｶｳﾝﾀ
        Dim lstrWPName              As String       '装置名
        Dim lstrWFID                As String       'WFID
        Dim lstrHistoryFlag         As String       '実績ﾌﾗｸﾞ
        Dim lstrRecipeID            As String       'ﾚｼﾋﾟID
        Dim lstrDefaultFlag         As String       'ﾃﾞﾌｫﾙﾄﾌﾗｸﾞ
        Dim lstrRecipeComments      As String       'ﾚｼﾋﾟｺﾒﾝﾄ
        Dim lstRecipeValue          As String       'ﾚﾁｸﾙ型番
        Dim lstrRecipeItem          As String       'ﾚｼﾋﾟｱｲﾃﾑ
        Dim lstrValueType           As String       'ﾃﾞｰﾀﾀｲﾌﾟ
        Dim lblnBodyFlag            As Boolean      'ﾎﾞﾃﾞｨ存在ﾌﾗｸﾞ(True:あり、False:なし）
        Dim llngWpCnt               As Integer      '装置数ｶｳﾝﾄ
        Dim lblnDispWfFlag          As Boolean      'WFﾚｼﾋﾟ&実績ﾌﾗｸﾞ
        Dim newStyle                As CellStyle    'NSYS セルスタイル
        Dim cellRange               As CellRange    'NSYS セルレンジ
        
        Try
            
            '@ﾌﾗｸﾞ初期化（なし）
            lblnBodyFlag = False
            lblnDispWfFlag = False
            
            
            '@ﾍｯﾀﾞ部の表示
            With ptypUseRecpList
                lblCarrierID.Text = .strCarrierId    'ｷｬﾘｱID
                lblLotID.Text = .strLotID            'ﾛｯﾄID
                lblOpID.Text = .strOpID              '大工程
                lblStepID.Text = .strStepID          '小工程
            End With
            
            With vsfWPRecipeList
                
                '@描画なし
                .Redraw = False
                
                With ptypUseRecpList.typUseRecpAns
                
                    'WF選択条件
                    lblSelectConditionID.Text = .strSelectConditionID
                    
                    '@WF選択条件の表示可否
                    If .strSelectConditionID = vbNullString Then
                        '@非表示
                        lblSelectConditionID.Visible = False
                        lblTitleSelectConditionID.Visible = False
                    Else
                        '@表示
                        lblSelectConditionID.Visible = True
                        lblTitleSelectConditionID.Visible = True
                    End If
                    
                    
                    '@装置ﾘｽﾄのﾙｰﾌﾟ
                    For llngCnt = 0 To .lngUseWpListCnt - 1
                    
                        With .typUseWpList(llngCnt)
                            
                            If llngCnt = 0 Then
                                '@装置名
                                lstrWPName = .strWpName
                                '@装置ｶｳﾝﾀの初期化
                                llngWpCnt = 1
                                
                                '@実績ﾌﾗｸﾞがONの場合
                                If .strHistoryFlag = CMstrHistoryFlgOn Then
                                    '@見出しのﾀｲﾄﾙをWFIDに変更する。
                                    vsfWPRecipeList.SetData(CMlngvsfFixedRow, CMlngvsfColDefault, CMstrvsfColTWFID)   'WFID
                                    '@実績ﾌﾗｸﾞ
                                    lstrHistoryFlag = .strHistoryFlag
                                End If
                            Else
                                If lstrWPName <> .strWpName Then
                                    '@装置名
                                    lstrWPName = .strWpName
                                    llngWpCnt = llngWpCnt + 1
                                End If
                            End If
                            
                            '@WFID
                            lstrWFID = .strWfId
                            
                            '@WFID存在ﾁｪｯｸ
                            If lstrWFID <> vbNullString Then
                                '@WFIDに値がある場合は画面に表示する。
                                '@存在しない場合はﾛｯﾄﾚｼﾋﾟの場合or予定
                                lblnDispWfFlag = True   '表示
                            End If
                            
                            '@ﾚｼﾋﾟﾘｽﾄの判定(H/Wのでﾚｼﾋﾟ0件の場合を考慮)
                            If .lngtypUseRecipeListCnt = 0 Then
                            '@ﾚｼﾋﾟﾘｽﾄが0件の場合
                                '@ｸﾞﾘｯﾄﾞにﾃﾞｰﾀを設定
                                With Me.vsfWPRecipeList
                                    '@行ｶｳﾝﾀのｲﾝｸﾘﾒﾝﾄ
                                    llngRowCnt = llngRowCnt + 1
                                    '@行数の設定
                                    .Rows.Count = llngRowCnt + 1
                                    '@行番号
                                    .SetData(llngRowCnt, CMlngvsfColNo, llngWpCnt)
                                    '@装置名
                                    .SetData(llngRowCnt, CMlngvsfColWpName, lstrWPName)
                                    '@ﾃﾞﾌｫﾙﾄﾌﾗｸﾞ
                                    .SetData(llngRowCnt, CMlngvsfColDefault, vbNullString)
                                    '@ﾚｼﾋﾟID
                                    .SetData(llngRowCnt, CMlngvsfColRecipeID, vbNullString)
                                    '@ﾚﾁｸﾙﾊﾟﾗﾒｰﾀ値
                                    .SetData(llngRowCnt, CMlngvsfColRecipeValue, vbNullString)
                                    '@ﾚｼﾋﾟｱｲﾃﾑ
                                    .SetData(llngRowCnt, CMlngvsfColRecipeItem, vbNullString)
                                    '@ﾚｼﾋﾟｺﾒﾝﾄ
                                    .SetData(llngRowCnt, CMlngvsfColRecipeComments, vbNullString)
                                End With
                            Else
                                '@ﾚｼﾋﾟﾘｽﾄのﾙｰﾌﾟ
                                For llngCnt2 = 0 To .lngtypUseRecipeListCnt - 1
                                
                                    With .typUseRecipeList(llngCnt2)
                                        '@ﾚｼﾋﾟID
                                        lstrRecipeID = .strRecipeId
                                        
                                        '@実績の場合はﾃﾞﾌｫﾙﾄﾌﾗｸﾞ→WFID
                                        If lstrHistoryFlag = CMstrHistoryFlgOn Then
                                            
                                            '@WFIDがNULLの場合は空白を設定（ｾﾙﾏｰｼﾞに必要）
                                            If lstrWFID <> vbNullString Then
                                                '@WFID
                                                lstrDefaultFlag = lstrWFID
                                            Else
                                                'NSYS ループが0始まりになり、Space(0)(=空文字列)だとマージされない
                                                lstrDefaultFlag = Space(llngCnt + 1)   'ｾﾙﾏｰｼﾞ用ｽﾍﾟｰｽ付加
                                            End If
                                            
                                        Else
                                            '@ﾃﾞﾌｫﾙﾄﾌﾗｸﾞ
                                            Select Case .strDefaultFlag
                                                Case CMstrDefaultFlgOn
                                                    '@ﾃﾞﾌｫﾙﾄﾌﾗｸﾞが立っている場合
                                                    lstrDefaultFlag = CMstrDefaultOn & Space(llngCnt + 1)  'ｾﾙﾏｰｼﾞ用ｽﾍﾟｰｽ付加
                                                Case Else
                                                    '@上記以外の場合
                                                    'NSYS ループが0始まりになり、Space(0)(=空文字列)だとマージされない
                                                    lstrDefaultFlag = Space(llngCnt + 1)   'ｾﾙﾏｰｼﾞ用ｽﾍﾟｰｽ付加
                                            End Select
                                        End If
                                        
                                        '@ﾚｼﾋﾟｺﾒﾝﾄ
                                        lstrRecipeComments = .strRecipeComments
                                        
                                        '@ﾎﾞﾃﾞｨﾘｽﾄの判定
                                        If .lngUseRecipeBodyListCnt = 0 Then
                                            '@ﾚﾁｸﾙ型番ﾘｽﾄが0件の場合
                                            '@ｸﾞﾘｯﾄﾞにﾃﾞｰﾀを設定
                                            With Me.vsfWPRecipeList
                                                '@行ｶｳﾝﾀのｲﾝｸﾘﾒﾝﾄ
                                                llngRowCnt = llngRowCnt + 1
                                                '@行数の設定
                                                .Rows.Count = llngRowCnt + 1
                                                '@行番号
                                                .SetData(llngRowCnt, CMlngvsfColNo, llngWpCnt)
                                                '@装置名
                                                .SetData(llngRowCnt, CMlngvsfColWpName, lstrWPName)
                                                '@ﾃﾞﾌｫﾙﾄﾌﾗｸﾞ
                                                .SetData(llngRowCnt, CMlngvsfColDefault, lstrDefaultFlag)
                                                '@ﾚｼﾋﾟID
                                                .SetData(llngRowCnt, CMlngvsfColRecipeID, lstrRecipeID)
                                                '@ﾚﾁｸﾙ型番
                                                .SetData(llngRowCnt, CMlngvsfColRecipeValue, vbNullString)
                                                '@ﾚｼﾋﾟｱｲﾃﾑ
                                                .SetData(llngRowCnt, CMlngvsfColRecipeItem, vbNullString)
                                                '@ﾚｼﾋﾟｺﾒﾝﾄ(改行ｺｰﾄﾞは空白に置き換え）
                                                .SetData(llngRowCnt, CMlngvsfColRecipeComments, _
                                                        Replace(lstrRecipeComments, vbCrLf, CPstrSpace))
                                            
                                            End With
                                        Else
                                        '@ﾎﾞﾃﾞｨﾘｽﾄが1件以上ある場合
                                        
                                            '@ﾎﾞﾃﾞｨ存在ﾌﾗｸﾞにTrueを設定（あり）
                                            lblnBodyFlag = True
                                            
                                            '@ﾎﾞﾃﾞｨﾘｽﾄのﾙｰﾌﾟ
                                            For llngCnt3 = 0 To .lngUseRecipeBodyListCnt - 1
                                                
                                                With .typUseRecipeBodyList(llngCnt3)
                                                    '@ﾚﾁｸﾙﾊﾟﾗﾒｰﾀ値
                                                    lstRecipeValue = .strRecipeValue
                                                    '@ﾚｼﾋﾟｱｲﾃﾑ
                                                    lstrRecipeItem = .strRecipeItem
                                                    '@ﾃﾞｰﾀﾀｲﾌﾟ
                                                    lstrValueType = .strValueType
                                                End With
                                                
                                                '@ｸﾞﾘｯﾄﾞにﾃﾞｰﾀを設定
                                                With Me.vsfWPRecipeList
                                                    '@行ｶｳﾝﾀのｲﾝｸﾘﾒﾝﾄ
                                                    llngRowCnt = llngRowCnt + 1
                                                    '@行数の設定
                                                    .Rows.Count = llngRowCnt + 1
                                                    '@行番号
                                                    .SetData(llngRowCnt, CMlngvsfColNo, llngWpCnt)
                                                    '@装置名
                                                    .SetData(llngRowCnt, CMlngvsfColWpName, lstrWPName)
                                                    '@ﾃﾞﾌｫﾙﾄﾌﾗｸﾞ
                                                    .SetData(llngRowCnt, CMlngvsfColDefault, lstrDefaultFlag)
                                                    '@ﾚｼﾋﾟID
                                                    .SetData(llngRowCnt, CMlngvsfColRecipeID, lstrRecipeID)
                                                   
                                                    '@ﾚｼﾋﾟｱｲﾃﾑ
                                                    .SetData(llngRowCnt, CMlngvsfColRecipeItem, lstrRecipeItem)
                                                    '@ﾚｼﾋﾟｺﾒﾝﾄ(改行ｺｰﾄﾞは空白に置き換え）
                                                    .SetData(llngRowCnt, CMlngvsfColRecipeComments, _
                                                        Replace(lstrRecipeComments, vbCrLf, CPstrSpace))
                                                    
                                                    '@対象ｾﾙの設定
                                                    .Row = llngRowCnt
                                                    .Col = CMlngvsfColRecipeValue
                                                    
                                                    '@ﾃﾞｰﾀﾀｲﾌﾟの判定（数値の場合）
                                                    If lstrValueType = CMstrDataTypeN Then
                                                        '@表示位置設定
                                                        newStyle = .Styles.Add("CustomStyle_TextAlign_RightCenter")
                                                        newStyle.TextAlign = TextAlignEnum.RightCenter
                                                        cellRange = .GetCellRange(llngRowCnt, CMlngvsfColRecipeValue)
                                                        cellRange.Style = newStyle  '右寄せ
                                                        
        '@↓2006/03/16 (Thu) 14:12:50 N.Kasai **************************************************
        '@ﾌｫﾄF/B対応ｶﾝﾏ編集なし
        '                                                '@ﾚｼﾋﾟﾊﾟﾗﾒｰﾀ値の判定
        '                                                If IsNumeric(lstRecipeValue) = True Then
        '                                                    '@数値の場合はｶﾝﾏ編集
        '                                                    lstRecipeValue = Format$(lstRecipeValue, CMstrKnmaFormat)   '#,##0
        '                                                End If
        '@↑2006/03/16 (Thu) 14:12:50 N.Kasai **************************************************
                                                    Else
                                                        '@表示位置設定
                                                        newStyle = .Styles.Add("CustomStyle_TextAlign_LeftCenter")
                                                        newStyle.TextAlign = TextAlignEnum.LeftCenter
                                                        cellRange = .GetCellRange(llngRowCnt, CMlngvsfColRecipeValue)
                                                        cellRange.Style = newStyle  '左寄せ
                                                    End If
                                                    
                                                    '@ﾚｼﾋﾟﾊﾟﾗﾒｰﾀ値
                                                    .SetData(llngRowCnt, CMlngvsfColRecipeValue, lstRecipeValue)

                                                End With
                                            Next llngCnt3
                                        End If
                                    End With
                                Next llngCnt2
                            End If
                        End With
                    Next llngCnt
                End With
                
                '@行の高さ
                .Rows.DefaultSize = CMlngVsfHeight
                .Rows(CMlngvsfFixedRow).Height = CMlngVsfHHeight
                
                '@右端の列の幅を自動調整をやめる
                .ExtendLastCol = False
                
                '@列幅設定
                .AutoSizeCols(CMlngvsfColWpName, .Cols.Count - 1, 6)
                
                '@ﾎﾞﾃﾞｨ存在ﾌﾗｸﾞの判定
                If lblnBodyFlag = False Then
                    .Cols(CMlngvsfColRecipeValue).Visible = False
                    .Cols(CMlngvsfColRecipeItem).Visible = False
                End If
                
                'WFID存在ﾌﾗｸﾞの判定
                If lblnDispWfFlag = False And lstrHistoryFlag = CMstrHistoryFlgOn Then
                    .Cols(CMlngvsfColDefault).Visible = False
                End If
                
                '@右端の列の幅を自動調整する
                .ExtendLastCol = True
                
                '@ﾛｯｸ解除
                .Enabled = True

                .Row = 0
                
                '@直製描画
                .Redraw = True

                '@横ｽｸﾛｰﾙ画面初期化処理
                .LeftCol = CMlngvsfFrozenCols
                
                '@<<>>ﾎﾞﾀﾝ制御
                Call pubCmdLREnable_Set(vsfWPRecipeList, cmdLeft, cmdRight)
            
            End With

            '@▲▼ﾎﾞﾀﾝ初期化
            Call pubVsfDisp(vsfWPRecipeList, cmdUP, cmdDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfWPRecipeList_Disp"
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

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑの終了
    '引　数：sender：イベント発生元
    '　　　：e     ：イベントオブジェクト
    '戻り値：
    '作成日：2020/03/30 (Mon) 19:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub Form_QueryUnload(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'NSYS 静的イベントハンドラ解除
        RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '関数名：vsfWPRecipeList_AfterScroll
    '機　能：装置レシピ一覧グリッドのスクロール後時
    '引　数：sender：イベント発生元
    '　　　：e     ：イベントオブジェクト
    '戻り値：
    '作成日：2019/08/08 (Tue) 15:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub vsfWPRecipeList_AfterScroll(sender As Object, e As RangeEventArgs) Handles vsfWPRecipeList.AfterScroll
        '@<<>>ﾎﾞﾀﾝ制御
        Call pubCmdLREnable_Set(vsfWPRecipeList, cmdLeft, cmdRight)
    End Sub

End Class
