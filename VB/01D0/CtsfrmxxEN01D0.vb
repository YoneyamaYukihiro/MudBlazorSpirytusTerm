'ﾌｧｲﾙ名：xxEN01D0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ｶﾞｲﾀﾞﾝｽ表示
'作成日：2004/09/16 (Thu) 15:13:07 T.Kitagawa
'更新日：2009/10/20 (Tue) 16:08:58 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01D0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01D0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01D0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01D0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01D0)
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
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2009/10/20 (Tue) 16:40:13 T.Oide **************************************************
    'Private Const CMstrLocalVersion             As String = "04.00"
    Private Const CMstrLocalVersion             As String = "05.00"
    '@↑2009/10/20 (Tue) 16:40:13 T.Oide **************************************************

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_McGrouplistVer       As String = "01.00"         '装置ｸﾞﾙｰﾌﾟ取得
    Private Const CMstreq__areacurlistVer       As String = "02.00"         'ｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置用途情報取得
    Private Const CMstrguidinfo____Ver          As String = "02.00"         'ｶﾞｲﾀﾞﾝｽ情報取得
    '@↓2009/10/20 (Tue) 16:08:58 T.Oide **************************************************
    'Private Const CMstreq__state___Ver          As String = "02.01"         '装置状態取得
    Private Const CMstreq__state___Ver          As String = "03.00"         '装置状態取得
    '@↑2009/10/20 (Tue) 16:08:58 T.Oide **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN01D0  'ﾛｰｶﾙﾒﾆｭｰKey

    '@ﾌﾚｯｸｽｸﾞﾘｯﾄﾞのｶﾗﾑ定数
    Private Const CMlngGridTitleHeight          As Integer = 20                'ﾀｲﾄﾙの高さ
    Private Const CMlngGridRowHeight            As Integer = 18                '1明細の高さ

    '@vsfGuidListの定数宣言(ｶﾗﾑ)
    Private Const CMlngGuidListNo               As Integer = 0                 '№
    Private Const CMlngGuidListGuideLevelID     As Integer = 1                 'ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙID
    Private Const CMlngGuidListDate             As Integer = 2                 '発生日時
    Private Const CMlngGuidListWpID             As Integer = 3                 '装置ID
    Private Const CMlngGuidListWpName           As Integer = 4                 '装置名
    Private Const CMlngGuidListPortID           As Integer = 5                 'ﾎﾟｰﾄID
    Private Const CMlngGuidListLotID            As Integer = 6                 'ﾛｯﾄID
    Private Const CMlngGuidListCarrierID        As Integer = 7                 'ｷｬﾘｱID
    Private Const CMlngGuidListOpId             As Integer = 8                 '大工程
    Private Const CMlngGuidListStepId           As Integer = 9                 '小工程
    Private Const CMlngGuidListGuideCode        As Integer = 10                'ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ
    Private Const CMlngGuidListGuideMsg         As Integer = 11                'ｶﾞｲﾀﾞﾝｽﾒｯｾｰｼﾞ

    '@ﾚｽﾎﾟﾝｽ取得用
    Private Const CMstrFormName                 As String = "frmxxEN01D0"              '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                 As String = "Form_Load"                'ｲﾍﾞﾝﾄ名称(ﾌｫｰﾑﾛｰﾄﾞ)
    Private Const CMstrCmdGuidListClick         As String = "cmdGuidList_Click"        'ｲﾍﾞﾝﾄ名称(最新取得)
    Private Const CMstrCmdMcGroupNameValidate   As String = "cmbMcGroupName_Validate"  'ｲﾍﾞﾝﾄ名称(装置ｸﾞﾙｰﾌﾟのValidate)

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize              As Integer = 11                         'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize          As Integer = 11                         'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbRowHeight             As Integer = 18                         'ﾘｽﾄ行の高さ
    Private Const CMlngCmbDispCols1             As Integer = 1                          'ｸﾞﾘｯﾄﾞ表示列数=1
    Private Const CMlngCmbValueCol1             As Integer = 1                          '値取得個数=1
    Private Const CMlngCmbGridCol0              As Integer = 0                          '名称列番=0
    Private Const CMlngCmbValueColWpStatusName  As Integer = 3                          '装置状態取得列
    Private Const CMstrCmbAddedComment          As String = " 項目選択"                 '表示 文字列
    Private Const CMstrCmbAddedCommentNone      As String = "0 項目選択"                '表示 文字列「選択なし」
    Private Const CMstrCmbCheckOn               As String = "1"                         'ﾁｪｯｸON
    Private Const CMstrNoSelectString           As String = "指定なし"                  '装置ｸﾞﾙｰﾌﾟ、装置名指定なし文字

    '@ﾀﾞｲﾀﾞﾝｽﾚﾍﾞﾙ情報
    Private Const CMstrGuidLevelE               As String = "E"                         'ERROR
    Private Const CMstrGuidLevelEname           As String = "ERROR"                     'ERROR
    Private Const CMstrGuidLevelW               As String = "W"                         'WARNING
    Private Const CMstrGuidLevelWname           As String = "WARNING"                   'WARNING
    Private Const CMstrGuidLevelI               As String = "I"                         'INFORMATION
    Private Const CMstrGuidLevelIname           As String = "INFORMATION"               'INFORMATION
    Private Const CMlngGuidLevelCnt             As Integer = 3                          'ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙ件数

    '@その他
    Private Const CMlngDisplayMaxCnt            As Integer = 500                        '表示最大件数
    Private Const CMstrDateSelectOn             As String = "検　索"                    '検索(最新取得ﾎﾞﾀﾝ名)
    Private Const CMstrDateSelectOff            As String = "最新取得"                  '最新取得(最新取得ﾎﾞﾀﾝ名)
    Private Const CMlngSortClass1               As Integer = 1                          'ｿｰﾄ区分(昇順)
    Private Const CMlngSortClass2               As Integer = 2                          'ｿｰﾄ区分(降順)
    Private Const CMstrSortClassString1         As String = "1"                         'ｿｰﾄ区分文字(昇順)
    Private Const CMstrSortClassString2         As String = "2"                         'ｿｰﾄ区分文字(降順)
    Private Const CMstrDisplayMaxOverOn         As String = "期間"                      '表示最大件数ｵｰﾊﾞｰ時のMsgBox文字(期間指定の場合)
    Private Const CMstrDisplayMaxOverOff        As String = "最新"                      '表示最大件数ｵｰﾊﾞｰ時のMsgBox文字(最新の場合)
    Private Const CMstrDisplayMax               As String = "最大"                      '表示最大件数ｵｰﾊﾞｰ時の文字

    '@ﾃｷｽﾄ
    Private Const CMlngMaxDispRow               As Integer = 3                          'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '***************************************************************************************
    '                                   * 変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    Private mstrOldMcGroupID                    As String                           '退避用装置ｸﾞﾙｰﾌﾟID
    Private mstrOldWpID                         As String                           '退避用装置ID
    Private mtypEqstate                         As Eqstate                          '装置状態ﾘｽﾄ格納
    Private mtypChgSort                         As ChgSort                          'ｿｰﾄ保持用
    Private buttonProcessing                    As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                          'NSYS WindowCloseフラグ
    Private mintGuidListRowBeforeSort           As Integer                          'NSYS GuidListのソート前選択行

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
        medFromTime.Tag = New Hashtable() From {{"OnHighlight", False}, {"MouseDownStart", 0}}
        medToTime.Tag = New Hashtable() From {{"OnHighlight", False}, {"MouseDownStart", 0}}
        Form_Load()

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              * イベントハンドラの記述 *
    '***************************************************************************************
    '======================================Private==========================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ時
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 15:47:47 T.Kitagawa
    '更新日：2005/12/02 (Fri) 15:34:14 N.Kasai
    '備　考：2004/10/15 (Fri) 13:29:23 M.Miura　    ｿｰﾄ保持用構造体初期化
    '　　　：2005/12/02 (Fri) 15:34:14 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub Form_Load()

        Dim lblnAns                 As Boolean          '結果格納
        Dim ltypMcGroupList         As McGroupList      '装置ｸﾞﾙｰﾌﾟ情報格納
        Dim llngCnt                 As Integer

        Try
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN01D0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
                '@異常終了の場合
                '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                Call pubMenuExpand_Disp()
                '@ﾌｫｰﾑを閉じる
                Call Form_QueryUnload(False, New FormClosingEventArgs(CloseReason.UserClosing,  False))
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)
            
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                .typChgSortList = New List(Of ChgSortList)
                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            '@閉じるボタンへCausesValidationを設定する
            cmdClose.CausesValidation = False

            '@ﾒｲﾝﾌｫｰﾑの初期化
            Call prvfrmxxEN01D0_Init()
            
        '@↓2005/12/02 (Fri) 15:34:08 N.Kasai **************************************************
            cmdMessegeUp.Enabled = False
            cmdMessegeDown.Enabled = False
        '@↑2005/12/02 (Fri) 15:34:08 N.Kasai **************************************************
            
            '@ｶﾞｲﾀﾞﾝｽ情報ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfGuidList_Init()
            
            '@装置ｸﾞﾙｰﾌﾟの初期設定
            cmbMcGroupName.AddItem(CMstrNoSelectString & vbTab & vbNullString)               '指定なし
            
            '@装置ｸﾞﾙｰﾌﾟ取得(処理区分：全件)
            lblnAns = pubblnMasMcGroupList_Sel(CMstrmas_McGrouplistVer, CPstrCD02, pstrSBID, ltypMcGroupList)
            '@結果判定
            If lblnAns = True Then
                '@装置ｸﾞﾙｰﾌﾟ取得情報表示
                With ltypMcGroupList
                    cmbMcGroupName.ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter         '左寄中央揃え
                    '@ｴﾘｱ情報ｾｯﾄ
                    For llngCnt = 0 To .lngMcGroupListCnt - 1
                        With .typMcGroupList(llngCnt)
                            cmbMcGroupName.AddItem(.strMcGroupName & vbTab & .strMcGroupID)          '装置ｸﾞﾙｰﾌﾟ名 & 装置ｸﾞﾙｰﾌﾟID
                        End With
                    Next llngCnt
                    cmbMcGroupName.GroupRows = .lngMcGroupListCnt + 1
                End With
                '@装置ｸﾞﾙｰﾌﾟの初期表示
                If cmbMcGroupName.ListCount > 0 Then
                    cmbMcGroupName.ListIndex = 0
                End If
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                Exit Sub
            End If
                
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)
            
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

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑのKeyDown
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：未使用
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 16:32:37 T.Kitagawa
    '更新日：2004/09/16 (Thu) 16:32:37
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
             Select Case e.KeyCode
                '@Enterｷｰの場合
                Case Keys.Return
                    Select Case ActiveControl.Name
                        Case cmbMcGroupName.Name
                            'NSYS Validatingの多重起動抑止
                            RemoveHandler cmbMcGroupName.Validating,AddressOf cmbMcGroupName_Validate
                            Call cmbMcGroupName_Validate(sender,New CancelEventArgs(True))
                            AddHandler cmbMcGroupName.Validating,AddressOf cmbMcGroupName_Validate
                            If cmbWpName.Enabled = True Then
                                Call pubSetFocus(cmbWpName)
                            End If
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

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑのｸｴﾘｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 16:36:47 T.Kitagawa
    '更新日：2004/11/01 (Mon) 15:43:23 T.Kitagawa
    '備　考：2004/11/01 (Mon) 15:43:23 T.Kitagawa　閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender,e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@ﾓｼﾞｭｰﾙ構造体のｸﾘｱ
            mtypEqstate.typPortList = New List(Of eqPortList)
            
            '@ActInitフラグの判定
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

            '@ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄとの関連付けを解除
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
    '機　能：閉じるﾎﾞﾀﾝ押下時
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 16:37:39 T.Kitagawa
    '更新日：2004/09/16 (Thu) 16:37:39
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        
        Dim llngRet         As Integer
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
            llngRet = publngEnd_Proc(CPstrKeyEN01D0, ltypCommonInfo)

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

    '関数名：cmdMessegeUp_Click
    '機　能：ﾒｯｾｰｼﾞ▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 16:50:22 T.Kitagawa
    '更新日：2005/12/02 (Fri) 15:25:04 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 15:25:04 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdMessegeUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMessegeUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/12/02 (Fri) 15:25:01 N.Kasai **************************************************
        '    '@ﾒｯｾｰｼﾞにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtMessege)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtMessege, CMlngMaxDispRow, cmdMessegeUp, cmdMessegeDown)
        '@↑2005/12/02 (Fri) 15:25:01 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMessegeUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMessegeDown_Click
    '機　能：ﾒｯｾｰｼﾞ▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 16:53:28 T.Kitagawa
    '更新日：2004/09/16 (Thu) 16:53:28
    '備　考：
    Private Sub cmdMessegeDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMessegeDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/02 (Fri) 15:27:01 N.Kasai **************************************************
        '    '@ﾒｯｾｰｼﾞにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtMessege)
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtMessege, CMlngMaxDispRow, cmdMessegeUp, cmdMessegeDown)
        '@↑2005/12/02 (Fri) 15:27:01 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMessegeDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGroupName_Change
    '機　能：装置ｸﾞﾙｰﾌﾟ 変更時
    '引　数：なし
    '戻り値：ない
    '作成日：2004/09/16 (Thu) 17:01:40 T.Kitagawa
    '更新日：2004/10/15 (Fri) 13:31:39 M.Miura
    '備　考：2004/10/15 (Fri) 13:31:39 M.Miura　ｶﾚﾝﾄ行検索ｷｰ初期化を追加
    Private Sub cmbMcGroupName_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGroupName.Change

        Try
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@ｶﾞｲﾀﾞﾝｽ情報ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfGuidList_Init()
            
            '@装置名の初期化
            cmbWpName.Clear
            cmbWpName.Text = vbNullString    '装置名の初期化
            cmbWpName.Enabled = False
            mstrOldWpID = vbNullString       '退避用装置の初期化
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMcGroupName_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGroupName_CloseUp
    '機　能：装置ｸﾞﾙｰﾌﾟ 選択時
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 17:05:11 T.Kitagawa
    '更新日：2004/09/16 (Thu) 17:05:11
    '備　考：
    Private Sub cmbMcGroupName_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGroupName.CloseUp

        Try
            '@Validate処理へ
            If cmbMcGroupName.Text <> vbNullString Then
                'NSYS Validatingの多重起動抑止
                RemoveHandler cmbMcGroupName.Validating,AddressOf cmbMcGroupName_Validate
                Call cmbMcGroupName_Validate(sender,New CancelEventArgs(True))
                AddHandler cmbMcGroupName.Validating,AddressOf cmbMcGroupName_Validate
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMcGroupName_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGroupName_Validate
    '機　能：装置ｸﾞﾙｰﾌﾟ Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 17:06:25 T.Kitagawa
    '更新日：2004/09/22 (Wed) 15:23:05 H.Wajima
    '備　考：2004/09/22 (Wed) 15:23:05 H.Wajima   装置ｸﾞﾙｰﾌﾟIDの退避処理を追加
    Private Sub cmbMcGroupName_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbMcGroupName.Validating

        Dim lblnAns                     As Boolean                    '結果格納
        Dim llngAreaEqCnt               As Integer                    'ｴﾘｱ情報ｶｳﾝﾄ
        Dim ltypAreaEquipmentList       As List(Of AreaEquipmentList) 'ｴﾘｱ装置情報格納
        Dim llngCnt                     As Integer

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@未選択の場合は処理しない
            If cmbMcGroupName.Text = vbNullString Or cmbMcGroupName.Value = vbNullString Then
                '@ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙへﾌｫｰｶｽ設定
                If cmbGuidLevel.Enabled = True Then
                    'NSYS 自コントロール処理の場合フォーカス処理
                    If ActiveControl.Name = cmbMcGroupName.Name then
                        Call pubSetFocus(cmbGuidLevel)
                    End If
                End If
                Exit Sub
            End If
            
            '@前回ID格納と同じ場合は処理しない
            If cmbMcGroupName.Value = mstrOldMcGroupID And cmbWpName.ListCount > 0 Then
                If cmbWpName.Enabled = True Then
                    'NSYS 自コントロール処理の場合フォーカス処理
                    If ActiveControl.Name = cmbMcGroupName.Name then
                        Call pubSetFocus(cmbWpName)
                    Exit Sub
                    End If
                End If
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdMcGroupNameValidate)
            
            '@装置一覧取得
            lblnAns = pubblnEqAreaCurList_Sel(CMstreq__areacurlistVer, vbNullString, pstrSBID, _
                        ltypAreaEquipmentList, llngAreaEqCnt, CPstrCD20, cmbMcGroupName.Value)
            '@結果判定
            If lblnAns = True Then
                '@装置名設定
                cmbWpName.Clear
                cmbWpName.ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter       '左寄中央揃え
                cmbWpName.AddItem(CMstrNoSelectString & vbTab & vbNullString)             '指定なし
                For llngCnt = 0 To llngAreaEqCnt - 1
                    cmbWpName.AddItem(ltypAreaEquipmentList(llngCnt).strWpName & vbTab & ltypAreaEquipmentList(llngCnt).strWpID & vbTab & _
                             llngCnt & vbTab & ltypAreaEquipmentList(llngCnt).strWpStatusName)       '装置名 & 装置ID & 現在のｶｳﾝﾄ数 & 装置状態
                Next llngCnt
                cmbWpName.GroupRows = llngAreaEqCnt + 1
                '@装置の初期表示
                If cmbWpName.ListCount > 0 Then
                    cmbWpName.ListIndex = 0             '指定なし
                End If
                '@装置名退避
                mstrOldWpID = Trim(cmbWpName.Value)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdMcGroupNameValidate)
                e.Cancel = True
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrCmdMcGroupNameValidate)
            
            '@装置ｸﾞﾙｰﾌﾟIDを退避
            mstrOldMcGroupID = cmbMcGroupName.Value
            
            '@装置を有効にする
            cmbWpName.Enabled = True

            'NSYS 自コントロール処理の場合フォーカス処理
            If ActiveControl.Name = cmbMcGroupName.Name then
                Call pubSetFocus(cmbWpName)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMcGroupName_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWpName_Change
    '機　能：装置ｺﾝﾎﾞ　変更時
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 18:37:31 T.Kitagawa
    '更新日：2004/10/15 (Fri) 13:31:39 M.Miura
    '備　考：2004/10/15 (Fri) 13:31:39 M.Miura　ｶﾚﾝﾄ行検索ｷｰ初期化を追加
    Private Sub cmbWpName_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWpName.Change

        Try
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@ｶﾞｲﾀﾞﾝｽ情報ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfGuidList_Init()
            
            '@取得列を装置状態列に設定
            cmbWpName.ValueCol = CMlngCmbValueColWpStatusName
            
            '@装置状態ｾｯﾄ
            lblWpStatusName.Text = vbNullString
            
            '@値取得列を戻す
            cmbWpName.ValueCol = CMlngCmbValueCol1
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWpName_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWpName_CloseUp
    '機　能：装置の選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 18:39:54 T.Kitagawa
    '更新日：2004/10/04 (Mon) 09:24:48 T.Kitagawa
    '備　考：2004/10/04 (Mon) 09:24:48 T.Kitagawa 自動的にValidateｲﾍﾞﾝﾄが発生する場合はValidateｲﾍﾞﾝﾄをCallしない！！
    Private Sub cmbWpName_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWpName.CloseUp

        Try
            '@Validate処理へ
            If cmbWpName.Text <> vbNullString Then
                SendKeys.SendWait(CPstrSendKeysTab)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWpName_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWpName_Validate
    '機　能：装置のValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 18:42:14 T.Kitagawa
    '更新日：2004/09/29 (Wed) 20:05:12 T.Kitagawa
    '備　考：2004/09/24 (Fri) 13:34:40 S.Deguchi 装置状態を取得する処理を追加
    '　　　：2004/09/29 (Wed) 20:05:12 T.Kitagawa 装置を未指定の場合は装置状態を取得しないように修正
    Private Sub cmbWpName_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbWpName.Validating

        Dim lblnAns                 As Boolean          '結果格納

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If cmbWpName.Text = vbNullString Or cmbWpName.Value = vbNullString Then
                Exit Sub
            End If
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, "cmbWpName_Validate")

            '@初期化(使う部分のみ)
            mtypEqstate.strWpStatusName = vbNullString
            
            '@装置状態の取得
            lblnAns = pubblnEqState_Sel(CMstreq__state___Ver, cmbWpName.Value, mtypEqstate)
            '@結果判定
            If lblnAns = True Then
                '@ﾗﾍﾞﾙに処理状態を設定
                lblWpStatusName.Text = mtypEqstate.strWpStatusName
            Else
                '@Nullを設定
                lblWpStatusName.Text = vbNullString
                
                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, "cmbWpName_Validate")

                '@ﾌｫｰｶｽそのまま
                e.Cancel = True
                
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, "cmbWpName_Validate")

            '@装置退避
            mstrOldWpID = Trim(cmbWpName.Value)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWpName_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbGuidLevel_Change
    '機　能：ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙの変更
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 18:59:07 T.Kitagawa
    '更新日：2004/10/15 (Fri) 13:31:39 M.Miura
    '備　考：2004/10/15 (Fri) 13:31:39 M.Miura　ｶﾚﾝﾄ行検索ｷｰ初期化を追加
    Private Sub cmbGuidLevel_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbGuidLevel.Change

        Try
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            '@ｶﾞｲﾀﾞﾝｽ情報ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfGuidList_Init()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbGuidLevel_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbGuidLevel_CloseUp
    '機　能：ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙの選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 18:59:43 T.Kitagawa
    '更新日：2004/09/16 (Thu) 18:59:43
    '備　考：
    Private Sub cmbGuidLevel_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbGuidLevel.CloseUp

        Try
            SendKeys.SendWait(CPstrSendKeysTab)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbGuidLevel_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：chkDateSelectKbn_Click
    '機　能：期間指定区分の変更
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/06 (Wed) 09:50:07 T.Kitagawa
    '更新日：2004/11/08 (Mon) 09:33:06 M.Miura
    '備　考：2004/10/15 (Fri) 13:31:39 M.Miura　ｶﾚﾝﾄ行検索ｷｰ初期化を追加
    '　　　：2004/11/08 (Mon) 09:33:06 M.Miura　昇順/降順ｵﾌﾟｼｮﾅﾙﾎﾞﾀﾝ設定を削除(ｶﾞｲﾀﾞﾝｽ情報は固定で降順になった)(不具合№201)
    '　　　：2004/11/09 (Tue) 16:14:06 S.Deguchi 時刻のﾌｫｰﾏｯﾄ"HH:MM"をﾊﾟﾌﾞﾘｯｸ定数へ変更&"00:00"をﾊﾟﾌﾞﾘｯｸ変数へ変更
    Private Sub chkDateSelectKbn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles chkDateSelectKbn.CheckedChanged

        Try
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@ｶﾞｲﾀﾞﾝｽ情報ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfGuidList_Init()
            
            '@期間指定するかしないかにより、期間、ｿｰﾄ区分を有効制御する
            If chkDateSelectKbn.Checked = True Then
                '@最新取得ﾎﾞﾀﾝ名の変更
                cmdGuidList.Text = CMstrDateSelectOn                     '検索(最新取得ﾎﾞﾀﾝ名)
                '@期間、ｿｰﾄ区分を有効にする
                calFromDate.Enabled = True                                  '開始日
                calToDate.Enabled = True                                    '終了日
                medFromTime.Enabled = True                                  '開始時刻
                medToTime.Enabled = True                                    '終了時刻
        '@↓2004/11/08 (Mon) 09:29:35 M.Miura **************************************************
        '@ｶﾞｲﾀﾞﾝｽ情報は固定で降順になった為削除(不具合№201)
        ''        optSortClass(CMlngSortClass1).Enabled = True                'ｿｰﾄ区分(昇順)
        ''        optSortClass(CMlngSortClass2).Enabled = True                'ｿｰﾄ区分(降順)
        '@↑2004/11/08 (Mon) 09:29:35 M.Miura **************************************************
                '@期間、ｿｰﾄ区分を初期値設定する
                calFromDate.Value = Format$(Now(), CPstrDateTimeYMD)         '当日に設定
                calToDate.Value = Format$(Now(), CPstrDateTimeYMD)           '当日に設定
                medFromTime.Text = CPstrTimeFormat0H0M                       '0時固定
                medToTime.Text = Format$(Now(), CPstrTimeFormatHM)           '現在時刻を初期値設定
        '@↓2004/11/08 (Mon) 09:31:49 M.Miura **************************************************
        '@ｶﾞｲﾀﾞﾝｽ情報は固定で降順になった為削除(不具合№201)
        ''        optSortClass(CMlngSortClass1).Value = True                  '昇順を初期値設定
        '@↑2004/11/08 (Mon) 09:31:49 M.Miura **************************************************
            Else
                '@最新取得ﾎﾞﾀﾝ名の変更
                cmdGuidList.Text = CMstrDateSelectOff                    '最新取得(最新取得ﾎﾞﾀﾝ名)
                '@期間、ｿｰﾄ区分をｸﾘｱする
                calFromDate.Value = vbNullString                            '開始日
                calToDate.Value = vbNullString                              '終了日
                medFromTime.Text = CPstrNullTime                            '開始時刻
                medToTime.Text = CPstrNullTime                              '終了時刻
        '@↓2004/11/08 (Mon) 09:32:35 M.Miura **************************************************
        '@ｶﾞｲﾀﾞﾝｽ情報は固定で降順になった為削除(不具合№201)
        ''        optSortClass(CMlngSortClass2).Value = True                  '降順を初期値設定
        '@↑2004/11/08 (Mon) 09:32:35 M.Miura **************************************************
                '@期間、ｿｰﾄ区分を無効にする(※降順のみ有効)
                calFromDate.Enabled = False                                 '開始日
                calToDate.Enabled = False                                   '終了日
                medFromTime.Enabled = False                                 '開始時刻
                medToTime.Enabled = False                                   '終了時刻
        '@↓2004/11/08 (Mon) 09:32:51 M.Miura **************************************************
        '@ｶﾞｲﾀﾞﾝｽ情報は固定で降順になった為削除(不具合№201)
        ''        optSortClass(CMlngSortClass1).Enabled = False               'ｿｰﾄ区分(昇順)
        ''        optSortClass(CMlngSortClass2).Enabled = True                'ｿｰﾄ区分(降順)
        '@↑2004/11/08 (Mon) 09:32:51 M.Miura **************************************************
            End If
            
            '@ﾌｫｰｶｽ移動する
            SendKeys.SendWait(CPstrSendKeysTab)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "chkDateSelectKbn_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calFromDate_Change
    '機　能：検索開始日の変更
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 19:02:44 T.Kitagawa
    '更新日：2004/10/15 (Fri) 13:31:39 M.Miura
    '備　考：2004/10/15 (Fri) 13:31:39 M.Miura　ｶﾚﾝﾄ行検索ｷｰ初期化を追加
    Private Sub calFromDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calFromDate.Change

        Try
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            '@ｶﾞｲﾀﾞﾝｽ情報ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfGuidList_Init()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calFromDate_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calToDate_Change
    '機　能：検索終了日の変更
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 19:02:44 T.Kitagawa
    '更新日：2004/09/16 (Thu) 19:02:44
    '備　考：
    Private Sub calToDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calToDate.Change

        Try
            '@ｶﾞｲﾀﾞﾝｽ情報ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfGuidList_Init()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calToDate_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calFromDate_CalendarSelect
    '機　能：検索開始日の選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 19:05:54 T.Kitagawa
    '更新日：2004/09/16 (Thu) 19:05:54
    '備　考：
    Private Sub calFromDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calFromDate.CalendarSelect

        Try
            With calFromDate
                '@開始日付が選択されている場合
                If .Value <> CPstrNullDate Then
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If
            End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calFromDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calToDate_CalendarSelect
    '機　能：検索終了日の選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 19:05:54 T.Kitagawa
    '更新日：2004/10/15 (Fri) 13:31:39 M.Miura
    '備　考：2004/10/15 (Fri) 13:31:39 M.Miura　ｶﾚﾝﾄ行検索ｷｰ初期化を追加
    Private Sub calToDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calToDate.CalendarSelect

        Try
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            With calToDate
                '@終了日付が選択されている場合
                If .Value <> CPstrNullDate Then
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If
            End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calToDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calFromDate_Validate
    '機　能：検索開始日のValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 19:17:17 T.Kitagawa
    '更新日：2004/09/16 (Thu) 19:17:17
    '備　考：
    Private Sub calFromDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calFromDate.Validating
        
        Dim lstrNowDT As String     '現在日時の退避

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            If calFromDate.Value = CPstrNullDate Then
                Exit Sub
            End If
            
            '@日付の有効性ﾁｪｯｸ
            If pubblnYearRange_Chk(calFromDate.Value) = True Then
                '@現在日付取得
                lstrNowDT = Format$(Now, CPstrDateTimeYMD)

                'NSYS 日付型変換
                Dim strDateTmp As String
                If IsDate(calFromDate.Value) Then
                    strDateTmp = Format$(CDate(calFromDate.Value), CPstrDateTimeYMD)
                Else
                    strDateTmp = calFromDate.Value
                End If

                '@未来日付の場合
                If strDateTmp > lstrNowDT Then
                   '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
                    '@"未来日付は指定できません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@ﾌｫｰｶｽを移さない
                    e.Cancel = True
                End If
            Else
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                '@"正しい日付を入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@ﾌｫｰｶｽを移さない
                e.Cancel = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calFromDate_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calToDate_Validate
    '機　能：検索終了日のValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 19:17:17 T.Kitagawa
    '更新日：2004/09/16 (Thu) 19:17:17
    '備　考：
    Private Sub calToDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calToDate.Validating
        
        Dim lstrNowDT As String     '現在日時の退避

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            If calToDate.Value = CPstrNullDate Then
                Exit Sub
            End If
            
            '@日付の有効性ﾁｪｯｸ
            If pubblnYearRange_Chk(calToDate.Value) = True Then
                '@現在日付取得
                lstrNowDT = Format$(Now, CPstrDateTimeYMD)

                'NSYS 日付型変換
                Dim strDateTmp As String
                If IsDate(calToDate.Value) Then
                    strDateTmp = Format$(CDate(calToDate.Value), CPstrDateTimeYMD)
                Else
                    strDateTmp = calToDate.Value
                End If

                '@未来日付の場合
                If strDateTmp > lstrNowDT Then
                   '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
                    '@"未来日付は指定できません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@ﾌｫｰｶｽを移さない
                    e.Cancel = True
                End If
            Else
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                '@"正しい日付を入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@ﾌｫｰｶｽを移さない
                e.Cancel = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calToDate_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medFromTime_GotFocus
    '機　能：検索開始時刻のﾌｫｰｶｽ取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 19:26:09 T.Kitagawa
    '更新日：2004/09/16 (Thu) 19:26:09
    '備　考：
    Private Sub medFromTime_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles medFromTime.GotFocus

        Try
            '@ﾊｲﾗｲﾄ処理
            Call pubHighlight(medFromTime)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medFromTime_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medToTime_GotFocus
    '機　能：検索終了時刻のﾌｫｰｶｽ取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 19:26:09 T.Kitagawa
    '更新日：2004/09/16 (Thu) 19:26:09
    '備　考：
    Private Sub medToTime_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles medToTime.GotFocus

        Try
            '@ﾊｲﾗｲﾄ処理
            Call pubHighlight(medToTime)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medToTime_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medFromTime_Change
    '機　能：検索開始時刻の変更
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 19:29:39 T.Kitagawa
    '更新日：2004/10/15 (Fri) 13:31:39 M.Miura
    '備　考：2004/10/15 (Fri) 13:31:39 M.Miura　ｶﾚﾝﾄ行検索ｷｰ初期化を追加
    Private Sub medFromTime_Change(ByVal sender As Object, ByVal e As EventArgs) Handles medFromTime.TextChanged

        Try
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            '@ｶﾞｲﾀﾞﾝｽ情報ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfGuidList_Init()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medFromTime_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medToTime_Change
    '機　能：検索終了時刻の変更
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 19:29:39 T.Kitagawa
    '更新日：2004/10/15 (Fri) 13:31:39 M.Miura
    '備　考：2004/10/15 (Fri) 13:31:39 M.Miura　ｶﾚﾝﾄ行検索ｷｰ初期化を追加
    Private Sub medToTime_Change(ByVal sender As Object, ByVal e As EventArgs) Handles medToTime.TextChanged

        Try
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            '@ｶﾞｲﾀﾞﾝｽ情報ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfGuidList_Init()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medToTime_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medFromTime_Validate
    '機　能：検索開始時刻のValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 19:32:01 T.Kitagawa
    '更新日：2004/09/16 (Thu) 19:32:01
    '備　考：
    Private Sub medFromTime_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles medFromTime.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If medFromTime.Text = CPstrNullTime Then
                Exit Sub
            End If
            
            If IsDate(medFromTime.Text) = False Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003C)
                '@"時刻の設定が正しくありません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@ｾｯﾄﾌｫｰｶｽ
                e.Cancel = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medFromTime_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medToTime_Validate
    '機　能：検索終了時刻のValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 19:32:01 T.Kitagawa
    '更新日：2004/09/16 (Thu) 19:32:01
    '備　考：
    Private Sub medToTime_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles medToTime.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If medToTime.Text = CPstrNullTime Then
                Exit Sub
            End If
            
            If IsDate(medToTime.Text) = False Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003C)
                '@"時刻の設定が正しくありません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@ｾｯﾄﾌｫｰｶｽ
                e.Cancel = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medToTime_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdGuidList_Click
    '機　能：最新取得ﾎﾞﾀﾝ　押下時
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 20:10:06 T.Kitagawa
    '更新日：2004/11/08 (Mon) 09:37:39 M.Miura
    '備　考：2004/10/06 (Wed) 10:51:29 T.Kitagawa　期間指定条件、ｿｰﾄ区分の追加(不具合№808)
    '　　　：2004/10/19 (Tue) 13:09:04 T.Kitagawa　500件以上ﾒｯｾｰｼﾞBOXの廃止(不具合№1094)
    '　　　：2004/10/20 (Wed) 13:23:15 T.Kitagawa　500件以上の場合は"最大 500"を件数に表示する(不具合№88)
    '　　　：2004/11/08 (Mon) 09:37:39 M.Miura　　 昇順/降順判定を削除しｿｰﾄ区分を降順固定に変更(不具合№201)
    Private Sub cmdGuidList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdGuidList.Click
        
        Dim lblnAns                 As Boolean          '結果格納
        Dim ltypGuidInfoList        As GuidInfoList     'ｶﾞｲﾀﾞﾝｽ情報格納
        Dim llngCnt                 As Integer          'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lvntGuidLevel           As Object           'ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙMsg用
        Dim lstrMsgClassDivision    As String           '処理区分(07:最新、3G:期間指定)
        Dim lstrMsgStartDate        As String           '検索開始日
        Dim lstrMsgStartTime        As String           '検索開始時刻
        Dim lstrMsgEndDate          As String           '検索終了日
        Dim lstrMsgEndTime          As String           '検索終了時刻
        Dim lstrMsgLevel            As String           'ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙMsg
        Dim lstrMsgSortClass        As String           'ｿｰﾄ区分
        Dim lstrWarningMsgBox       As String           '表示最大件数ｵｰﾊﾞｰ時のMsgBox文字

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@検索ﾁｪｯｸ
            If prvSearch_Chk() = False Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdGuidListClick)
            
            '@期間指定にて検索条件を設定する
            If chkDateSelectKbn.Checked = True Then
                '@期間指定する場合
                '@処理区分の設定
                lstrMsgClassDivision = CPstrCD3G            '期間指定する
                '@検索開始日の設定
                If IsDate(calFromDate.Value) = True Then
                    lstrMsgStartDate = calFromDate.Value
                Else
                    lstrMsgStartDate = vbNullString
                End If
                '@検索開始時刻の設定
                If IsDate(medFromTime.Text) = True Then
                    lstrMsgStartTime = medFromTime.Text
                Else
                    lstrMsgStartTime = vbNullString
                End If
                '@検索終了日の設定
                If IsDate(calToDate.Value) = True Then
                    lstrMsgEndDate = calToDate.Value
                Else
                    lstrMsgEndDate = vbNullString
                End If
                '@検索終了時刻の設定
                If IsDate(medToTime.Text) = True Then
                    lstrMsgEndTime = medToTime.Text
                Else
                    lstrMsgEndTime = vbNullString
                End If
        '@↓2004/11/08 (Mon) 09:36:03 M.Miura **************************************************
        '@ｶﾞｲﾀﾞﾝｽ情報は固定で降順になった為削除(不具合№201)
        ''        '@ｿｰﾄ区分の設定
        ''        If optSortClass(CMlngSortClass1).Value = True Then
        ''            lstrMsgSortClass = CMstrSortClassString1    '昇順
        ''        Else
        ''            lstrMsgSortClass = CMstrSortClassString2    '降順
        ''        End If
        '@↑2004/11/08 (Mon) 09:36:03 M.Miura **************************************************
                '@ｿｰﾄ区分の設定(降順固定)
                lstrMsgSortClass = CMstrSortClassString2
                 
                '@表示最大件数ｵｰﾊﾞｰ時のMsgBox文字設定
                lstrWarningMsgBox = CMstrDisplayMaxOverOn       '期間
            Else
                '@期間指定しない場合
                '@処理区分の設定
                lstrMsgClassDivision = CPstrCD07            '最新取得(期間指定しない)
                lstrMsgStartDate = vbNullString             '検索開始日
                lstrMsgStartTime = vbNullString             '検索開始時刻
                lstrMsgEndDate = vbNullString               '検索終了日
                lstrMsgEndTime = vbNullString               '検索終了時刻
                '@ｿｰﾄ区分の設定
                lstrMsgSortClass = CMstrSortClassString2    '降順固定
                '@表示最大件数ｵｰﾊﾞｰ時のMsgBox文字設定
                lstrWarningMsgBox = CMstrDisplayMaxOverOff  '最新
            End If
            
            '@抽出ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙの設定
            lstrMsgLevel = vbNullString
            If cmbGuidLevel.ValueCount <> cmbGuidLevel.GroupRows Then
                lvntGuidLevel = Split(cmbGuidLevel.Value, vbTab)
                For llngCnt = LBound(lvntGuidLevel) To UBound(lvntGuidLevel)
                    lstrMsgLevel = lstrMsgLevel & lvntGuidLevel(llngCnt)                 'ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙ
                Next llngCnt
            End If
            
            '@MSG[ｶﾞｲﾀﾞﾝｽ情報取得]を実行
            lblnAns = pubblnGuidInfo_Sel(pstrSBID, CMstrguidinfo____Ver, lstrMsgClassDivision, _
                                        lstrMsgStartDate, lstrMsgStartTime, lstrMsgEndDate, lstrMsgEndTime, _
                                        lstrMsgLevel, cmbWpName.Value, cmbMcGroupName.Value, lstrMsgSortClass, ltypGuidInfoList)
            '@結果判定
            If lblnAns = True Then
                '@装置名が選択されていない場合は装置状態を取得しない
                If cmbWpName.Value <> vbNullString Then
                    '@初期化
                    mtypEqstate.strWpStatusName = vbNullString
                    
                    '@装置状態の取得
                    lblnAns = pubblnEqState_Sel(CMstreq__state___Ver, cmbWpName.Value, mtypEqstate)
                    '@結果判定
                    If lblnAns = True Then
                        '@ﾗﾍﾞﾙに処理状態を設定
                        lblWpStatusName.Text = mtypEqstate.strWpStatusName
                    Else
                        'NSYS 取得に失敗の場合は初期化
                        Call prvvsfGuidList_Init()

                        '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmdGuidListClick)
            
                        Exit Sub
                    End If
                End If
                
                '@検索結果表示
                If ltypGuidInfoList.lngGuidInfoCnt > 0 Then
                    Call prvvsfGuidList_Disp(ltypGuidInfoList)
                    If vsfGuidList.Enabled = True Then
                        '@一覧にﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfGuidList)
                    End If
                Else
                    'NSYS 0件の場合は初期化
                    Call prvvsfGuidList_Init()
                End If
                
                '@情報取得日時表示
                lblNowDate.Text = Format$(Now, CPstrDateFormat)

                '@該当件数ﾗﾍﾞﾙに取得件数を表示
                If ltypGuidInfoList.lngGuidInfoCnt >= CMlngDisplayMaxCnt Then
                    '@該当件数が500件以上の場合は、"最大 500"を表示する
                    lblGaidanceCnt.Text = CMstrDisplayMax & Space(1) & Format$(ltypGuidInfoList.lngGuidInfoCnt, CPstrDateFormatKanma)
                Else
                    lblGaidanceCnt.Text = Format$(ltypGuidInfoList.lngGuidInfoCnt, CPstrDateFormatKanma)
                End If
            Else
                '@ﾛｯﾄ一覧取得に失敗

                'NSYS 取得に失敗の場合は初期化
                Call prvvsfGuidList_Init()

                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdGuidListClick)

                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrCmdGuidListClick)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdGuidList_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtMessege_Change
    '機　能：ﾛｯﾄｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:12:03 N.Kasai
    '更新日：2005/11/29 (Tue) 14:12:03
    '備　考：
    Private Sub txtMessege_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtMessege.Change

        Try
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtMessege, CMlngMaxDispRow, cmdMessegeUp, cmdMessegeDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtMessege_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtMessege_KeyUp
    '機　能：ﾛｯﾄｺﾒﾝﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 13:47:07 N.Kasai
    '更新日：2005/11/29 (Tue) 13:47:07
    '備　考：
    Private Sub txtMessege_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtMessege.KeyUp

        Try
            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtMessege, CMlngMaxDispRow, cmdMessegeUp, cmdMessegeDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtMessege_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：txtMessege_MouseUp
    '機　能：ﾛｯﾄｺﾒﾝﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 13:48:44 N.Kasai
    '更新日：2005/11/29 (Tue) 13:48:44
    '備　考：
    Private Sub txtMessege_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtMessege.MouseUp

        Try
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtMessege, CMlngMaxDispRow, cmdMessegeUp, cmdMessegeDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtMessege_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：vsfGuidList_AfterUserResize
    '機　能：列幅変更時処理
    '引　数：Row：行番号
    '　　　：Col：列番号
    '戻り値：なし
    '作成日：2004/10/15 (Fri) 13:36:44 M.Miura
    '更新日：2004/10/15 (Fri) 13:36:44
    '備　考：
    Private Sub vsfGuidList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfGuidList.AfterResizeColumn, vsfGuidList.AfterResizeRow

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfGuidList.Rows.Count <= vsfGuidList.Rows.Fixed Then
                Return
            End If

            '@列幅変更ﾌﾗｸﾞ(変更)
            mtypChgSort.blnChgWidth = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfGuidList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfGuidList_BeforeRowColChange
    '機　能：行列変更前
    '引　数：OldRow：旧行番号
    '　　　：OldCol：旧列番号
    '　　　：NewRow：新行番号
    '　　　：NewCol：新列番号
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/10/15 (Fri) 13:38:51 M.Miura
    '更新日：2004/10/15 (Fri) 13:38:51
    '備　考：
    Private Sub vsfGuidList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfGuidList.BeforeRowColChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfGuidList.Rows.Count <= vsfGuidList.Rows.Fixed Then
                Return
            End If
            
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ｷｬﾘｱID)
                mtypChgSort.strKey = vsfGuidList.GetData(e.NewRange.r1, CMlngGuidListDate) & _
                                     vsfGuidList.GetData(e.NewRange.r1, CMlngGuidListWpID) & _
                                     vsfGuidList.GetData(e.NewRange.r1, CMlngGuidListGuideCode)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfGuidList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfGuidList_BeforeSort
    '機　能：ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 21:21:20 T.Kitagawa
    '更新日：2004/09/16 (Thu) 21:21:20
    '備　考：
    Private Sub vsfGuidList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfGuidList.BeforeSort

        Try
            'NSYS 不要なHandler実行を抑止
            RemoveHandler vsfGuidList.BeforeRowColChange, AddressOf vsfGuidList_BeforeRowColChange
            RemoveHandler vsfGuidList.EnterCell, AddressOf vsfGuidList_EnterCell
            mintGuidListRowBeforeSort = vsfGuidList.Row 'NSYS ソート前の選択行を保持

            'NSYS データ行がない場合は処理を抜ける
            If vsfGuidList.Rows.Count <= vsfGuidList.Rows.Fixed Then
                Return
            End If

            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
            Call pubVsfBeforeSort(vsfGuidList, CMlngGuidListDate & vbTab & CMlngGuidListWpID & vbTab & CMlngGuidListGuideCode)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfGuidList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfGuidList_AfterSort
    '機　能：ｿｰﾄ後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 21:22:15 T.Kitagawa
    '更新日：2004/09/16 (Thu) 21:22:15
    '備　考：
    Private Sub vsfGuidList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfGuidList.AfterSort

        Try
            'NSYS ソート前の選択行が有効行でない場合ヘッダを選択行とする
            If mintGuidListRowBeforeSort <  vsfGuidList.Rows.Fixed Then
                vsfGuidList.Row = 0
            End If

            'NSYS Handler抑止解除
            AddHandler vsfGuidList.BeforeRowColChange, AddressOf vsfGuidList_BeforeRowColChange
            AddHandler vsfGuidList.EnterCell, AddressOf vsfGuidList_EnterCell

            'NSYS データ行がない場合は処理を抜ける
            If vsfGuidList.Rows.Count <= vsfGuidList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
            Call pubVsfAfterSort(vsfGuidList, CMlngGuidListDate & vbTab & CMlngGuidListWpID & vbTab & CMlngGuidListGuideCode)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfGuidList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfGuidList_EnterCell
    '機　能：ｶﾞｲﾀﾞﾝｽ情報のｶﾚﾝﾄ行移動
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 21:23:00 T.Kitagawa
    '更新日：2004/09/16 (Thu) 21:23:00
    '備　考：
    Private Sub vsfGuidList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfGuidList.EnterCell

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfGuidList.Rows.Count <= vsfGuidList.Rows.Fixed Then
                Return
            End If

            '@読み込み判定
            If vsfGuidList.Row < 1 Then
                Exit Sub
            End If
            
            '@ﾒｯｾｰｼﾞ表示
            With vsfGuidList
                 txtMessege.Text = .GetData(.Row, CMlngGuidListGuideMsg)
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfGuidList_EnterCell"
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

    '関数名：prvfrmxxEN01D0_Init
    '機　能：ﾌｫｰﾑのｸﾘｱ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 21:25:58 T.Kitagawa
    '更新日：2004/11/08 (Mon) 09:41:33 M.Miura
    '備　考：2004/09/20 (Mon) 11:50:28 S.Deguchi  ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙの初期表示に"3 項目選択"を設定
    '　　　：2004/10/04 (Mon) 14:37:53 H.Wajima   ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2004/10/06 (Wed) 10:44:49 T.Kitagawa 期間指定条件、ｿｰﾄ区分追加(不具合№808)
    '　　　：2004/11/08 (Mon) 09:41:33 M.Miura　　昇順/降順ｵﾌﾟｼｮﾅﾙﾎﾞﾀﾝ設定を削除(ｿｰﾄ区分が降順固定になった為)(不具合№201)
    Private Sub prvfrmxxEN01D0_Init()
        
        Dim lstrFormTitle       As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try

            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN01D0, lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@内容のｸﾘｱ
                
            '@装置ｸﾞﾙｰﾌﾟ
            With cmbMcGroupName
                '@ｴﾘｱ情報初期化
                .Enabled = True
                .Clear
                .DirectInput = False                                            '直接入力不可
                .Height = CMlngCmbRowHeight                                     '高さ
                .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)                     'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .ValueCol = CMlngCmbValueCol1                                   '値取得列
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .BackColor = SystemColors.Window                                'NSYS 背景色設定
            End With
             
            '@装置名
            With cmbWpName
                '@ｴﾘｱ情報初期化
                .Enabled = False
                .Clear
                .DirectInput = False                                            '直接入力不可
                .Height = CMlngCmbRowHeight                                     '高さ
                .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)                     'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .ValueCol = CMlngCmbValueCol1                                   '値取得列
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .BackColor = SystemColors.Window                                'NSYS 背景色設定
            End With
            
            '@期間の初期設定
            chkDateSelectKbn.Checked = False                            '指定しない
            cmdGuidList.Text = CMstrDateSelectOff                       '最新取得(最新取得ﾎﾞﾀﾝ名)
            '@期間、ｿｰﾄ区分を無効にする(※降順のみ有効)
            calFromDate.Enabled = False                                 '開始日
            calToDate.Enabled = False                                   '終了日
            medFromTime.Enabled = False                                 '開始時刻
            medToTime.Enabled = False                                   '終了時刻
        '@↓2004/11/08 (Mon) 09:39:58 M.Miura **************************************************
        '@ｶﾞｲﾀﾞﾝｽ情報は固定で降順になった為削除(不具合№201)
        ''    optSortClass(CMlngSortClass1).Enabled = False               'ｿｰﾄ区分(昇順)
        ''    optSortClass(CMlngSortClass2).Enabled = True                'ｿｰﾄ区分(降順)
        '@↑2004/11/08 (Mon) 09:39:58 M.Miura **************************************************
            '@期間、ｿｰﾄ区分をｸﾘｱする
            calFromDate.Value = vbNullString                            '開始日
            calToDate.Value = vbNullString                              '終了日
            medFromTime.Text = CPstrNullTime                            '開始時刻
            medToTime.Text = CPstrNullTime                              '終了時刻
        '@↓2004/11/08 (Mon) 09:40:28 M.Miura **************************************************
        '@ｶﾞｲﾀﾞﾝｽ情報は固定で降順になった為削除(不具合№201)
        ''    optSortClass(CMlngSortClass2).Value = True                  '降順を初期値設定
        '@↑2004/11/08 (Mon) 09:40:28 M.Miura **************************************************
            
            '@表示情報
            lblWpStatusName.Text = vbNullString
            lblNowDate.Text = vbNullString
            lblGaidanceCnt.Text = vbNullString
            
            '@ｶﾚﾝﾀﾞｰ設定
            With calFromDate
                .CalendarHeight = CPlngMClHeight                     '高さ
                .CalendarWidth = CPlngMClWidth                       '幅
                .DayFont = New Font(.DayFont.FontFamily, CPlngMClFontSize, .DayFont.Style, .DayFont.Unit)           'ﾌｫﾝﾄｻｲｽﾞ
                .TitleFont = New Font(.TitleFont.FontFamily, CPlngMClTlFontSize, .TitleFont.Style, .TitleFont.Unit) 'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CPlngMClGridFontSize, .GridFont.Style, .GridFont.Unit)   'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
            End With
            With calToDate
                .CalendarHeight = CPlngMClHeight                     '高さ
                .CalendarWidth = CPlngMClWidth                       '幅
                .DayFont = New Font(.DayFont.FontFamily, CPlngMClFontSize, .DayFont.Style, .DayFont.Unit)           'ﾌｫﾝﾄｻｲｽﾞ
                .TitleFont = New Font(.TitleFont.FontFamily, CPlngMClTlFontSize, .TitleFont.Style, .TitleFont.Unit) 'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CPlngMClGridFontSize, .GridFont.Style, .GridFont.Unit)   'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
            End With

            '@ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙ情報表示
            With cmbGuidLevel
                '@ERROR(ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙ名 & ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙID)
                .AddItem(CMstrGuidLevelEname & vbTab & CMstrGuidLevelE & vbTab & vbNullString & vbTab & vbNullString & vbTab & CMstrCmbCheckOn)
                '@WARNING(ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙ名 & ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙID)
                .AddItem(CMstrGuidLevelWname & vbTab & CMstrGuidLevelW & vbTab & vbNullString & vbTab & vbNullString & vbTab & CMstrCmbCheckOn)
                '@INFORMATION(ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙ名 & ｶﾞｲﾀﾞﾝｽﾚﾍﾞﾙID)
                .AddItem(CMstrGuidLevelIname & vbTab & CMstrGuidLevelI & vbTab & vbNullString & vbTab & vbNullString & vbTab & CMstrCmbCheckOn)
                '@行数ｾｯﾄ
                .GroupRows = CMlngGuidLevelCnt
                
                '@ﾃｷｽﾄ部分に情報をｾｯﾄ
                .AddedComment = CMstrCmbAddedComment        '"選択"文字列
                .Text = .ListCount & CMstrCmbAddedComment
                .BackColor = SystemColors.Window                                'NSYS 背景色設定
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01D0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfGuidList_Init
    '機　能：ｶﾞｲﾀﾞﾝｽ情報ｸﾞﾘｯﾄﾞの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 21:43:49 T.Kitagawa
    '更新日：2005/12/02 (Fri) 15:32:17 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 15:32:17 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub prvvsfGuidList_Init()

        Try
            
            '@ｶﾞｲﾀﾞﾝｽ情報
            With vsfGuidList
                .Clear(ClearFlags.UserData)
                '@ﾀｲﾄﾙの設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbYellow_BackColor_CPlngBlueColor")
                Dim cellRange As CellRange = .GetCellRange(CMlngGuidListNo, CMlngGuidListNo, CMlngGuidListNo, .Cols.Count - 1)
                newStyle.ForeColor = Color.Yellow
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
                cellRange.Style = newStyle
                .Rows(CMlngGuidListNo).Height = CMlngGridTitleHeight
                'NSYS 不要なHandler実行を抑止
                RemoveHandler vsfGuidList.BeforeRowColChange,AddressOf vsfGuidList_BeforeRowColChange
                RemoveHandler vsfGuidList.EnterCell,AddressOf vsfGuidList_EnterCell
                '@行数の初期設定
                .Rows.Count = 1
                'NSYS 初期化時はヘッダーを選択
                .Row = -1
                'NSYS 抑止解除
                AddHandler vsfGuidList.BeforeRowColChange,AddressOf vsfGuidList_BeforeRowColChange
                AddHandler vsfGuidList.EnterCell,AddressOf vsfGuidList_EnterCell
                .Enabled = False
            End With
            txtMessege.Text = vbNullString
            txtMessege.Enabled = False
            txtMessege.Locked = True
        '@↓2005/12/02 (Fri) 15:32:13 N.Kasai **************************************************
        '    cmdMessegeUp.Enabled = False
        '    cmdMessegeDown.Enabled = False
        '@↑2005/12/02 (Fri) 15:32:13 N.Kasai **************************************************
            
            '@表示情報
            lblNowDate.Text = vbNullString
            lblGaidanceCnt.Text = vbNullString

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfGuidList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfGuidList_Disp
    '機　能：ｶﾞｲﾀﾞﾝｽ情報の表示
    '引　数：ltypGuidInfoList：格納ﾃﾞｰﾀ
    '戻り値：なし
    '作成日：2004/09/16 (Thu) 21:45:45 T.Kitagawa
    '更新日：2005/12/02 (Fri) 15:31:32 N.Kasai
    '備　考：2004/10/15 (Fri) 15:36:20 M.Miura　列幅保持、ｶﾚﾝﾄ行設定を追加
    '　　　：2005/12/02 (Fri) 15:31:32 N.Kasai  ｽｸﾛｰﾙ連動
    Private Sub prvvsfGuidList_Disp(ByRef ltypGuidInfoList As GuidInfoList)
        
        Dim llngCnt     As Integer'ｶｳﾝﾀ

        Try
            
            '@ﾒｯｾｰｼﾞｸﾘｱ
            txtMessege.Text = vbNullString
            
            '@ｶﾞｲﾀﾞﾝｽ情報
            With ltypGuidInfoList
                '@ﾊﾞｯﾌｧ経由で描画
                vsfGuidList.Redraw = False
                '@ｸﾞﾘｯﾄﾞの初期化
                vsfGuidList.Clear(ClearFlags.UserData)
                'NSYS 不要なHandler実行を抑止
                RemoveHandler vsfGuidList.BeforeRowColChange,AddressOf vsfGuidList_BeforeRowColChange
                RemoveHandler vsfGuidList.EnterCell,AddressOf vsfGuidList_EnterCell
                '@行数の設定
                vsfGuidList.Rows.Count = .lngGuidInfoCnt + 1
                'NSYS 抑止解除
                AddHandler vsfGuidList.BeforeRowColChange,AddressOf vsfGuidList_BeforeRowColChange
                AddHandler vsfGuidList.EnterCell,AddressOf vsfGuidList_EnterCell
                For llngCnt = 1 To .lngGuidInfoCnt
                    With .typGuidInfo(llngCnt - 1)
                         vsfGuidList.SetData(llngCnt, CMlngGuidListNo, llngCnt)
                         vsfGuidList.SetData(llngCnt, CMlngGuidListGuideLevelID, .strGuideLevelID)
                         vsfGuidList.SetData(llngCnt, CMlngGuidListDate, .strGuideTime)
                         vsfGuidList.SetData(llngCnt, CMlngGuidListWpID, .strWpID)
                         vsfGuidList.SetData(llngCnt, CMlngGuidListWpName, .strWpName)
                         vsfGuidList.SetData(llngCnt, CMlngGuidListPortID, .strPortID)
                         vsfGuidList.SetData(llngCnt, CMlngGuidListLotID, .strLotID)
                         vsfGuidList.SetData(llngCnt, CMlngGuidListCarrierID, .strCarrierId)
                         vsfGuidList.SetData(llngCnt, CMlngGuidListOpId, .strOpID)
                         vsfGuidList.SetData(llngCnt, CMlngGuidListStepId, .strStepID)
                         vsfGuidList.SetData(llngCnt, CMlngGuidListGuideCode, .strGuideCode)
                         vsfGuidList.SetData(llngCnt, CMlngGuidListGuideMsg, .strGuideMessage)
                         vsfGuidList.Rows(llngCnt).Height = CMlngGridRowHeight
                    End With
                Next llngCnt
                
                '@ｿｰﾄ検索用ｷｰ(ｷｬﾘｱID)がある場合
                If mtypChgSort.strKey <> vbNullString Then
                    For llngCnt = vsfGuidList.Rows.Fixed To vsfGuidList.Rows.Count - 1
                        '@ｷｬﾘｱID、大工程、小工程が同じ場合
                        If vsfGuidList.GetData(llngCnt, CMlngGuidListDate) & _
                           vsfGuidList.GetData(llngCnt, CMlngGuidListWpID) & _
                           vsfGuidList.GetData(llngCnt, CMlngGuidListGuideCode) = mtypChgSort.strKey Then

                            'NSYS 不要なHandler実行を抑止
                            RemoveHandler vsfGuidList.BeforeRowColChange,AddressOf vsfGuidList_BeforeRowColChange
                            RemoveHandler vsfGuidList.EnterCell,AddressOf vsfGuidList_EnterCell
                            vsfGuidList.Row = llngCnt
                            'NSYS 抑止解除
                            AddHandler vsfGuidList.BeforeRowColChange,AddressOf vsfGuidList_BeforeRowColChange
                            AddHandler vsfGuidList.EnterCell,AddressOf vsfGuidList_EnterCell

                            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                            Call pubVsfBeforeSort(vsfGuidList, CMlngGuidListDate & vbTab & CMlngGuidListWpID & vbTab & CMlngGuidListGuideCode)
                            '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
                            Call pubVsfAfterSort(vsfGuidList, CMlngGuidListDate & vbTab & CMlngGuidListWpID & vbTab & CMlngGuidListGuideCode)
                            Exit For
                        End If
                    Next llngCnt
                End If
                    
                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    '@列幅の自動調整
                    'vsfGuidList.AutoSizeMode = flexAutoSizeColWidth
                    vsfGuidList.AutoSizeCols(CMlngGuidListNo, vsfGuidList.Cols.Count - 1, 6)
                End If
                '@固定列の設定
                vsfGuidList.Cols.Frozen = CMlngGuidListWpID + 1
                '@ﾏｳｽよる列ｻｲｽﾞ変更の可／不可設定
                vsfGuidList.AllowResizing = AllowResizingEnum.Columns

                'NSYS 一覧設定後に行選択処理を実行
                Call vsfGuidList_EnterCell(vsfGuidList,New EventArgs)

                'NSYS 再描画
                vsfGuidList.Redraw = True
            End With
            
            '@ﾎﾞﾀﾝの使用許可
            If vsfGuidList.Rows.Count > 1 Then
        '@↓2005/12/02 (Fri) 15:31:22 N.Kasai **************************************************
        '        cmdMessegeUp.Enabled = True             '▲ﾎﾞﾀﾝ
        '        cmdMessegeDown.Enabled = True           '▼ﾎﾞﾀﾝ
        '@↑2005/12/02 (Fri) 15:31:22 N.Kasai **************************************************
                txtMessege.Enabled = True               'ﾒｯｾｰｼﾞ
                vsfGuidList.Enabled = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfGuidList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvSearch_Chk
    '機　能：最新取得ﾁｪｯｸ
    '引　数：なし
    '戻り値：True：成功　False：失敗
    '作成日：2004/09/16 (Thu) 21:54:52 T.Kitagawa
    '更新日：2004/09/16 (Thu) 21:54:52
    '備　考：
    Private Function prvSearch_Chk() As Boolean

        Try
            
            '@初期化
            prvSearch_Chk = False
            
            '@検索日付ﾁｪｯｸ
            
            '@検索日付大小ﾁｪｯｸ
            If calFromDate.Value <> CPstrNullDate And calToDate.Value <> CPstrNullDate Then
                If calFromDate.Value > calToDate.Value Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002H)
                    '@"開始日が終了日より大きくなっています。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@ｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(calFromDate)
                    Exit Function
                End If
            End If
                
            '@検索時刻大小ﾁｪｯｸ
            If medFromTime.Text <> CPstrNullTime And medToTime.Text <> CPstrNullTime Then
                If calFromDate.Value = calToDate.Value Then
                    If medFromTime.Text > medToTime.Text Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003E)
                        '@"開始時刻が終了時刻より大きくなっています。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        '@ｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(medFromTime)
                        Exit Function
                    End If
                End If
            End If
            
            '@時間を設定している場合の日付け入力ﾁｪｯｸ
            If medFromTime.Text <> CPstrNullTime And calFromDate.Value = CPstrNullDate Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003D)
                '@"日付を設定していません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@ｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(calFromDate)
                Exit Function
            End If
            If medToTime.Text <> CPstrNullTime And calToDate.Value = CPstrNullDate Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003D)
                '@"日付を設定していません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@ｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(calToDate)
                Exit Function
            End If
            
            '@成功
            prvSearch_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvSearch_Chk"
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


    '関数名 list_BeforeDoubleClick
    '機　能：グリッドダブルクリック前処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/01/14 (Mon) 17:00:00 NSYS
    '備　考：
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfGuidList.BeforeDoubleClick

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

    '関数名：textbox_Enter
    '機　能：ハイライト処理用 フォーカス取得イベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub textbox_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles medFromTime.Enter, medToTime.Enter
        'NSYS フォーカスインでハイライト処理 開始
        sender.ScrollToCaret()
        If (sender.MouseButtons And MouseButtons.Left) = MouseButtons.Left Then
            sender.Tag("OnHighlight") = True
        Else
            sender.Tag("OnHighlight") = False
        End If
    End Sub

    '関数名：textbox_Leave
    '機　能：ハイライト処理用 フォーカス喪失イベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考
    Private Sub textbox_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles medFromTime.Leave, medToTime.Leave
        'NSYS マウス選択でのハイライトをキャンセルする
        sender.Tag("OnHighlight") = False
    End Sub

    '関数名：textbox_KeyUp
    '機　能：ハイライト処理用 キーアップイベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考
    Private Sub textbox_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles medFromTime.KeyUp, medToTime.KeyUp
        'NSYS Tabキー押下の場合
        If e.KeyCode = Keys.Tab Then
            'NSYS マウス選択でのハイライトをキャンセルする
            sender.Tag("OnHighlight") = False
        End If
    End Sub

    '関数名：textbox_MouseDown
    '機　能：ハイライト処理用 マウスダウンイベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub textbox_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles medFromTime.MouseDown, medToTime.MouseDown
        'NSYS MouseDown時のカーソル位置を保持
        sender.Tag("MouseDownStart") = sender.SelectionStart
    End Sub

    '関数名：textbox_MouseUp
    '機　能：ハイライト処理用 マウスアップイベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub textbox_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles medFromTime.MouseUp, medToTime.MouseUp
        Dim curpos As Integer   'NSYS ｶｰｿﾙ位置

        '@ﾊｲﾗｲﾄするになっている場合
        If CBool(sender.Tag("OnHighlight")) = True Then
            ''@ｶｰｿﾙ位置までﾊｲﾗｲﾄ表示
            curpos = sender.SelectionStart
            sender.SelectionStart = 0 
            If curpos < CInt(sender.Tag("MouseDownStart")) Then
                'NSYS 左ドラッグ時
                sender.SelectionLength = curpos
            Else
                sender.SelectionLength = curpos + sender.SelectedText.Length
            End If
            sender.ScrollToCaret()
            sender.Tag("OnHighlight") = False
        End If
    End Sub
End Class
