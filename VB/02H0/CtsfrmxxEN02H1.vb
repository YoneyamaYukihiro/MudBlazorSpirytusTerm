'ﾌｧｲﾙ名：xxEN02H1.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：無機対向基板紐付/蒸着バッチ情報　サブフォーム
'作成日：2010/03/04 (Thu) 10:36:16 T.Oide
'更新日：2010/03/04 (Thu) 10:36:16
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02H1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02H1    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02H1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02H1
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02H1)
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
    Private Const CMstrLocalMenuKey                         As String = CPstrKeyEN00F1      'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrinv_mkissuehistoryVer                As String = "01.00"             '無機CF払出履歴


    '@vsfCFHistoryの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfCFHistoryNo                       As Integer = 0                  'No
    Private Const CMlngvsfCFHistoryEvent                    As Integer = 1                  'ｲﾍﾞﾝﾄ
    Private Const CMlngvsfCFHistoryEntryTime                As Integer = 2                  '登録日時
    Private Const CMlngvsfCFHistoryNum                      As Integer = 3                  '数量
    Private Const CMlngvsfCFHistoryIssueNum                 As Integer = 4                  '払出数量
    Private Const CMlngvsfCFHistoryIssueLot                 As Integer = 5                  '払出先
    Private Const CMlngvsfCFHistoryEmpName                  As Integer = 6                  '作業者

    '@vsfCFHistoryの定数宣言(表示幅)
    Private Const CMlngvsfCFHistoryNoW                      As Integer = 33                 'No
    Private Const CMlngvsfCFHistoryEventW                   As Integer = 131                'ｲﾍﾞﾝﾄ
    Private Const CMlngvsfCFHistoryEntryTimeW               As Integer = 191                '登録日時
    Private Const CMlngvsfCFHistoryNumW                     As Integer = 72                 '数量
    Private Const CMlngvsfCFHistoryIssueNumW                As Integer = 85                 '払出数量
    Private Const CMlngvsfCFHistoryIssueLotW                As Integer = 110                '払出先
    Private Const CMlngvsfCFHistoryEmpNameW                 As Integer = 115                '作業者

    '@vsfCFHistoryの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfCFHistoryNoN                   As String = "No"
    Private Const CMstrvsfCFHistoryEventN                   As String = "イベント"
    Private Const CMstrvsfCFHistoryEntryTimeN               As String = "登録日時"
    Private Const CMstrvsfCFHistoryNumN                     As String = "数量"
    Private Const CMstrvsfCFHistoryIssueNumN                As String = "払出数量"
    Private Const CMstrvsfCFHistoryIssueLotN                As String = "払出先"
    Private Const CMstrvsfCFHistoryEmpNameN                 As String = "作業者"

    Private Const CMlngOne                                  As Integer = 1                  '1(数値)
    Private Const CMlngTwo                                  As Integer = 2                  '2(数値)
    Private Const CMlngThree                                As Integer = 3                  '3(数値)
    Private Const CMlngFour                                 As Integer = 4                  '4(数値)
    Private Const CMlngSix                                  As Integer = 6                  '6(数値)
    Private Const CMlngSeven                                As Integer = 7                  '7(数値)

    '@vsfCFHistoryのその他定数宣言
    Private Const CMlngvsfCFHistoryRowTitle               As Integer = 0                  '行ﾀｲﾄﾙ
    Private Const CMlngvsfCFHistoryColTitle               As Integer = 0                  '列ﾀｲﾄﾙ
    Private Const CMlngvsfCFHistoryHHeight                As Integer = 20                 'ﾍｯﾀﾞｰ高さ
    Private Const CMlngvsfCFHistoryHFontSize              As Integer = 11                 'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ：11


    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    Private mblnFormLoadFlag                                As Boolean                      'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True：起動時以外/False：起動時のみ)
    Private buttonProcessing                                As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                        As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                                 As Boolean                      'NSYS WindowCloseフラグ

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
        pubVsfMouseWheelManager_Set(vsfCFHistory, cmdTxtUp, cmdTxtDown)

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
    '作成日：2010/03/08 (Mon) 13:04:32 T.Oide
    '更新日：2010/03/08 (Mon) 13:04:32
    '備　考：
    Private Sub Form_Load()
        
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lblnAns                 As Boolean              'ﾛｯﾄ保留理由取得戻り値(True/False)
        Dim ltypeCFIssueHistory     As typeCFIssueHistory   '取得ﾃﾞｰﾀ格納用


        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "Form_Load"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@画面初期化
            Call prvfrmxxEN02H1_Init()
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False
            
            '@CF払出履歴情報取得
            lblnAns = pubblnVaCFIsueHistory_Sel(CMstrinv_mkissuehistoryVer, pstrCFLotID, ltypeCFIssueHistory)
            
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                Exit Sub
            End If
                 
            '@ﾍｯﾀﾞｰ情報設定
            lblLotID.Text = ltypeCFIssueHistory.strLotID
            labParts.Text = ltypeCFIssueHistory.strPartCode
            labProductLot.Text = ltypeCFIssueHistory.strProductionLotId
            lblThrowinTime.Text = frmxxEN02H0.Instance.vsfCF.GetData(frmxxEN02H0.Instance.vsfCF.Row, CMlngThree)
            labThrowinNum.Text = frmxxEN02H0.Instance.vsfCF.GetData(frmxxEN02H0.Instance.vsfCF.Row, CMlngFour)
            labEmpName.Text = frmxxEN02H0.Instance.vsfCF.GetData(frmxxEN02H0.Instance.vsfCF.Row, CMlngSix)
                 
            '@取得したﾃﾞｰﾀを表示
            Call prvEN02H1_Disp(ltypeCFIssueHistory)
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)

            '@Form_Loadﾌﾗｸﾞ(正常)
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

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑの終了
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2010/03/24 (Wed) 20:08:57 T.Oide
    '更新日：2010/03/24 (Wed) 20:08:57
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If
            
            '変数初期化
            pstrCFLotID = vbNullString
            
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
    '作成日：2010/03/24 (Wed) 20:09:26 T.Oide
    '更新日：2010/03/24 (Wed) 20:09:26
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

    '関数名：cmdTxtUp_Click
    '機　能：前頁ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2010/03/25 (Thu) 10:54:04 T.Oide
    '更新日：2010/03/25 (Thu) 10:54:04
    '備　考：
    Private Sub cmdTxtUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@前頁処理▲
            Call pubVsfCmdUp(vsfCFHistory, cmdTxtUp, cmdTxtDown)

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdTxtUp_Click"         '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()


        End Try
    End Sub

    '関数名：cmdTxtDown_Click
    '機　能：次頁ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2010/03/25 (Thu) 10:54:04 T.Oide
    '更新日：2010/03/25 (Thu) 10:54:04
    '備　考：
    Private Sub cmdTxtDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@次頁処理▼
            Call pubVsfCmdDown(vsfCFHistory, cmdTxtUp, cmdTxtDown)
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdTxtDown_Click"       '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '関数名：prvfrmxxEN02H1_Init
    '機　能：ﾒｲﾝﾌｫｰﾑ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2010/03/08 (Mon) 13:06:44 T.Oide
    '更新日：2010/03/08 (Mon) 13:06:44
    '備　考：
    Private Sub prvfrmxxEN02H1_Init()

        Try
            
            '@各ｺﾝﾄﾛｰﾙ初期化
            lblLotID.Text = vbNullString                                     'ﾛｯﾄID
            lblThrowinTime.Text = vbNullString                               '投入日時
            labThrowinNum.Text = vbNullString                                '投入数量
            labParts.Text = vbNullString                                     '部品
            labProductLot.Text = vbNullString                                '製造ﾛｯﾄID
            labEmpName.Text = vbNullString                                   '作業者
            
            'ｸﾞﾘｯﾄﾞ初期化
            Call prvvsfCFHistory_Init()

            '@ｽｸﾛｰﾙﾎﾞﾀﾝ無効化
            cmdTxtUp.Enabled = False
            cmdTxtDown.Enabled = False
            
            '@閉じるﾎﾞﾀﾝのValidateｲﾍﾞﾝﾄを解除
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN02H1_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfCFHistory_Init
    '機　能：画面の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2010/03/08 (Mon) 13:26:46 T.Oide
    '更新日：2010/03/08 (Mon) 13:26:46
    '備　考：
    Private Sub prvvsfCFHistory_Init()

        Try
            
            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfCFHistory
            
                '@ｸﾘｱ
                .Clear
                
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                
                '@ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '.AllowBigSelection = False
                
                '@ﾏｳｽでｾﾙ範囲選択不可
                '.AllowSelection = False
                
                '@行数設定
                .Rows.Count = CMlngOne
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定(なし)
                .FocusRect = FocusRectEnum.None
                
                '@一覧表ﾀｲﾄﾙの設定
                .Select(CMlngvsfCFHistoryRowTitle, CMlngvsfCFHistoryColTitle, .Rows.Count - 1, .Cols.Count - 1)
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter                                  '中央表示
                lFixedStyle.ForeColor = Color.Yellow                                                '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)                   '背景色
                lFixedStyle.Font = New Font(lFixedStyle.Font.FontFamily, CMlngvsfCFHistoryHFontSize, _
                                            lFixedStyle.Font.Style, lFixedStyle.Font.Unit)          'ﾌｫﾝﾄｻｲｽﾞ
                .Rows(CMlngvsfCFHistoryRowTitle).Height = CMlngvsfCFHistoryHHeight                  '高さ
                
                'ﾀｲﾄﾙ,列幅,ｱﾗｲﾒﾝﾄ設定
                .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfCFHistoryNo, CMstrvsfCFHistoryNoN)                'No(ﾀｲﾄﾙ)
                .Cols(CMlngvsfCFHistoryNo).Width = CMlngvsfCFHistoryNoW                                       'No(幅)
                .Cols(CMlngvsfCFHistoryNo).TextAlign = TextAlignEnum.GeneralCenter                            'No(ｱﾗｲﾒﾝﾄ)
                
                .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfCFHistoryEvent, CMstrvsfCFHistoryEventN)          'ｲﾍﾞﾝﾄ(ﾀｲﾄﾙ)
                .Cols(CMlngvsfCFHistoryEvent).Width = CMlngvsfCFHistoryEventW                                 'ｲﾍﾞﾝﾄ(幅)
                .Cols(CMlngvsfCFHistoryEvent).TextAlign = TextAlignEnum.GeneralCenter                         'ｲﾍﾞﾝﾄ(ｱﾗｲﾒﾝﾄ)
                
                .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfCFHistoryEntryTime, CMstrvsfCFHistoryEntryTimeN)  '登録日時(ﾀｲﾄﾙ)
                .Cols(CMlngvsfCFHistoryEntryTime).Width = CMlngvsfCFHistoryEntryTimeW                         '登録日時(幅)
                .Cols(CMlngvsfCFHistoryEntryTime).TextAlign = TextAlignEnum.GeneralCenter                     '登録日時(ｱﾗｲﾒﾝﾄ)
                
                .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfCFHistoryNum, CMstrvsfCFHistoryNumN)              '数量(ﾀｲﾄﾙ)
                .Cols(CMlngvsfCFHistoryNum).Width = CMlngvsfCFHistoryNumW                                     '数量(幅)
                .Cols(CMlngvsfCFHistoryNum).TextAlign = TextAlignEnum.GeneralCenter                           '数量(ｱﾗｲﾒﾝﾄ)
                
                .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfCFHistoryIssueNum, CMstrvsfCFHistoryIssueNumN)    '払出数量(ﾀｲﾄﾙ)
                .Cols(CMlngvsfCFHistoryIssueNum).Width = CMlngvsfCFHistoryIssueNumW                           '払出数量(幅)
                .Cols(CMlngvsfCFHistoryIssueNum).TextAlign = TextAlignEnum.GeneralCenter                      '払出数量(ｱﾗｲﾒﾝﾄ)
                
                .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfCFHistoryIssueLot, CMstrvsfCFHistoryIssueLotN)    '払出先(ﾀｲﾄﾙ)
                .Cols(CMlngvsfCFHistoryIssueLot).Width = CMlngvsfCFHistoryIssueLotW                           '払出先(幅)
                .Cols(CMlngvsfCFHistoryIssueLot).TextAlign = TextAlignEnum.GeneralCenter                      '払出先(ｱﾗｲﾒﾝﾄ)
                
                .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfCFHistoryEmpName, CMstrvsfCFHistoryEmpNameN)      '作業者(ﾀｲﾄﾙ)
                .Cols(CMlngvsfCFHistoryEmpName).Width = CMlngvsfCFHistoryEmpNameW                             '作業者(幅)
                .Cols(CMlngvsfCFHistoryEmpName).TextAlign = TextAlignEnum.GeneralCenter                       '作業者(ｱﾗｲﾒﾝﾄ)
                
                '@ﾛｯｸ
                .Enabled = False
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCFHistory_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvEN02H1_Disp
    '機　能：無機対向基板払出履歴表示
    '引　数：ltypeCFIssueHistory：表示ﾃﾞｰﾀ
    '戻り値：なし
    '作成日：2010/03/24 (Wed) 19:04:42 T.Oide
    '更新日：2010/03/24 (Wed) 19:04:42
    '備　考：
    Private Sub prvEN02H1_Disp(ByRef ltypeCFIssueHistory As typeCFIssueHistory)
        
        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾀ

        Try
            
            '@ｸﾞﾘｯﾄﾞの行数設定
            vsfCFHistory.Rows.Count = ltypeCFIssueHistory.lngtypeHistoryListCnt + 1
            
                With ltypeCFIssueHistory
                '@ﾃﾞｰﾀ分ﾙｰﾌﾟ
                llngCnt = 0
                Do While .lngtypeHistoryListCnt > llngCnt
                    vsfCFHistory.SetData(llngCnt + 1, CMlngvsfCFHistoryNo, llngCnt + 1)                                       'No
                    vsfCFHistory.SetData(llngCnt + 1, CMlngvsfCFHistoryEvent, .typeHistoryList(llngCnt).strEventName)         'ｲﾍﾞﾝﾄ名
                    vsfCFHistory.SetData(llngCnt + 1, CMlngvsfCFHistoryEntryTime, .typeHistoryList(llngCnt).strRecordTime)    '登録日時
                    vsfCFHistory.SetData(llngCnt + 1, CMlngvsfCFHistoryNum, .typeHistoryList(llngCnt).strQuantity)            '数量
                    vsfCFHistory.SetData(llngCnt + 1, CMlngvsfCFHistoryIssueNum, .typeHistoryList(llngCnt).strIssueQuantity)  '払出数量
                    vsfCFHistory.SetData(llngCnt + 1, CMlngvsfCFHistoryIssueLot, .typeHistoryList(llngCnt).strIssueLotID)     '払出先
                    vsfCFHistory.SetData(llngCnt + 1, CMlngvsfCFHistoryEmpName, .typeHistoryList(llngCnt).strEmpName)         '作業者
                    
                    llngCnt = llngCnt + 1
                Loop

                'NSYS ヘッダー行を選択
                vsfCFHistory.Row = 0
            
            End With
            
            '@ｽｸﾛｰﾙﾎﾞﾀﾝ設定
            Call pubVsfDisp(vsfCFHistory, cmdTxtUp, cmdTxtDown)
            
            Exit Sub
            
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCFHistory_Disp"
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


    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraHoldList.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub
    
End Class
