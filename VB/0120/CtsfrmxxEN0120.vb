'ﾌｧｲﾙ名：xxEN0120.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ロット編成(保留/払出Wafer)　メインフォーム
'作成日：2004/03/26 (Fri) 14:07:34 K.Takano
'更新日：2009/04/15 (Wed) 10:11:18 N.Kojima
'備　考：
'Copyright(C)2003-, SEIKO EPSON CORPORATION.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN0120
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN0120    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN0120
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN0120
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN0120)
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
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2020/03/06 (Fri) 11:23:50 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion                         As String = "06.02"
    Private Const CMstrLocalVersion                         As String = "07.00"
    '@↑2020/03/06 (Fri) 11:23:50 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrinv_throwin_Ver                      As String = "03.00"         '在庫ﾛｯﾄ投入
    '@↓2020/01/27 (Mon) 16:12:28 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrinv_waferlistVer                     As String = "03.02"         'ｳｪﾊ在庫情報取得
    Private Const CMstrinv_waferlistVer                     As String = "04.00"         'ｳｪﾊ在庫情報取得
    '@↑2020/01/27 (Mon) 16:12:28 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrmas_priolistVer                      As String = "01.00"         'ﾏｽﾀ優先順位項目取得
    Private Const CMstrinv_lotlist_Ver                      As String = "02.00"         '在庫ﾛｯﾄﾘｽﾄ取得

    '@機能ID
    Private Const CMstrLocalMenuKey                         As String = CPstrKeyEN0120  'ﾛｰｶﾙﾒﾆｭｰkey

    '@ｽﾛｯﾄﾏｯﾌﾟの定数宣言
    '@↓2020/02/19 (Wed) 17:09:00 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMlngSlotMapColmNum                       As Integer = 4                 'ｶﾗﾑ数
    Private Const CMlngSlotMapColmNum                       As Integer = 5                 'ｶﾗﾑ数
    '@↑2020/02/19 (Wed) 17:09:00 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngSlotMapRowS                          As Integer = 26             '行数
    Private Const CMlngSlotMapHHeight                       As Integer = 27             'ﾍｯﾀﾞｰの高さ
    Private Const CMlngSlotMapHeight                        As Integer = 38             '1ｽﾛｯﾄの高さ
    Private Const CMvsfSlotMapRowTitle                      As Integer = 0              'ｽﾛｯﾄﾏｯﾌﾟﾀｲﾄﾙ

    '@ｽﾛｯﾄﾏｯﾌﾟ列設定

    '@↓2020/02/19 (Wed) 17:09:25 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMlngvsfMoveSlotMapColNo                  As Integer = 0              'ｽﾛｯﾄ№
    'Private Const CMlngvsfMoveSlotMapColWFID                As Integer = 1              'WFID
    'Private Const CMlngvsfMoveSlotMapColWFStat              As Integer = 2              '状態
    'Private Const CMlngvsfMoveSlotMapColBeforLotID          As Integer = 3              '元ﾛｯﾄID
    Private Const CMlngvsfMoveSlotMapColNo                  As Integer = 0              'ｽﾛｯﾄ№
    Private Const CMlngvsfMoveSlotMapColWFID                As Integer = 1              'WFID
    Private Const CMlngvsfMoveSlotMapColWFStat              As Integer = 2              '状態
    Private Const CMlngvsfMoveSlotMapColGRB                 As Integer = 3              'GRB
    Private Const CMlngvsfMoveSlotMapColBeforLotID          As Integer = 4              '元ﾛｯﾄID
    '@↑2020/02/19 (Wed) 17:09:25 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@ｽﾛｯﾄﾏｯﾌﾟ幅設定
    Private Const CMlngvsfMoveSlotMapWNo                    As Integer = 19             'ｽﾛｯﾄ№
    Private Const CMlngvsfMoveSlotMapWWFID                  As Integer = 126            'WFID
    Private Const CMlngvsfMoveSlotMapWWFStat                As Integer = 80             '状態
    Private Const CMlngvsfMoveSlotMapWBeforLotID            As Integer = 126            '元ﾛｯﾄID
    '@↓2020/02/19 (Wed) 17:10:18 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngvsfMoveSlotMapWGRB                   As Integer = 40             'GRB
    '@↑2020/02/19 (Wed) 17:10:18 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@ｽﾛｯﾄﾏｯﾌﾟﾀｲﾄﾙ設定
    Private Const CMstrvsfMoveSlotMapTNo                    As String = ""              'ｽﾛｯﾄ№
    Private Const CMstrvsfMoveSlotMapTWFID                  As String = "WFID"          'WFID
    Private Const CMstrvsfMoveSlotMapTWFStat                As String = "状態"          '状態
    Private Const CMstrvsfMoveSlotMapTBeforLotID            As String = "元ロットID"    '元ﾛｯﾄID
    '@↓2020/02/19 (Wed) 17:10:44 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrvsfMoveSlotMapTGRB                   As String = "GRB"           'GRB
    '@↑2020/02/19 (Wed) 17:10:44 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@ｷｬﾘｱIDﾃｷｽﾄの定数宣言
    Private Const CMlngMaxByte                              As Integer = 6              'MAX桁数

    '@優先順位選択ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbPrioSelFontSize                   As Integer = 16             'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbPrioSelGridFontSize               As Integer = 16             'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbPrioSelGridColPriorityName        As Integer = 0              '優先順位項目列番
    Private Const CMlngCmbPrioSelGridColPriorityID          As Integer = 1              '優先順位項目ID列番(非表示項目)
    Private Const CMlngCmbPrioSelSortAsc                    As Integer = 1              '昇順(ｿｰﾄ)
    Private Const CMlngCmbPrioSelDispCols                   As Integer = 1              'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngComboRowHeight                       As Integer = 43             '行の高さ

    '@優先順位ｺﾝﾎﾞﾎﾞｯｸｽ初期値
    Private Const CMstrcmbPrioSel                           As Integer = 1              'ﾘｽﾄｲﾝﾃﾞｯｸｽ

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    Private mstrCarrier                                     As String                   'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mtypPriorityReasonList                          As List(Of typPriorityReasonList)    '優先度ﾘｽﾄ構造体
    Private mblnCmdFlag                                     As Boolean                  'ﾎﾞﾀﾝ制御ﾌﾗｸﾞ

    Private buttonProcessing                                As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                        As Boolean                  'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                                 As Boolean                  'NSYS WindowCloseフラグ


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
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 11:12:47 M.Miura
    '更新日：2004/07/22 (Thu) 09:43:16 Y.Yamagishi
    '備　考：
    Private Sub Form_Load()

        Dim lblnAnsPrioritycodeList     As Boolean      'ﾛｯﾄ優先順位項目取得戻り値(True/False)
        Dim llngPrioritydcodeListCnt    As Integer      'ﾛｯﾄ優先順位項目のｶｳﾝﾄ
        Dim lstrFormName                As String       'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName               As String       'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lblnAns                     As Boolean      '戻り値

        Try
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = 0 - My.Settings.FormOffset
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN0120, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
                '@異常終了の場合
                '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                Call pubMenuExpand_Disp()
                '@ﾌｫｰﾑを閉じる
                Call Form_QueryUnload(Me, New FormClosingEventArgs(CloseReason.UserClosing,  False))
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "Form_Load"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@画面初期化
            Call prvMainForm_Init()
                
            '@ｽﾛｯﾄﾏｯﾌﾟの初期化
            Call prvvsfSlotMap_init()
            
            '@優先順位ｺﾝﾎﾞﾎﾞｯｸｽ初期化
            Call prvcmbPrioSel_Init()
            
            '@優先順位ﾏｽﾀ取得、結果ﾁｪｯｸ
            lblnAnsPrioritycodeList = pubblnMasPriolist_Sel(CMstrmas_priolistVer, _
                                                            llngPrioritydcodeListCnt, _
                                                            mtypPriorityReasonList)
            '@結果判定
            If lblnAnsPrioritycodeList = True Then
                '配列の件数ﾁｪｯｸ
                If llngPrioritydcodeListCnt > 0 Then
                    '@優先情報項目ﾏｽﾀをｺﾝﾎﾞへｾｯﾄ
                    Call prvMasPrioinfo_Disp()
                End If
            Else
                '@異常の場合終了
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Exit Sub
            End If

            '@優先順位ｺﾝﾎﾞﾎﾞｯｸｽ初期値ｾｯﾄ
            With cmbPrioSel
                .ListIndex = CMstrcmbPrioSel
            End With
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
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
    '機　能：ｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2004/03/03 (Wed) 17:26:21 M.Miura
    '更新日：2004/07/22 (Thu) 09:43:43 Y.Yamagishi
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            Select Case e.KeyCode
                '@Enterｷｰの場合
                Case Keys.Return
                    '@次項目へﾌｫｰｶｽｾｯﾄ
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

    '関数名：cmdResvLot_Click
    '機　能：投入予定ﾛｯﾄID選択画面表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 15:41:09 M.Miura
    '更新日：2008/06/11 (Wed) 14:18:47 N.Kojima
    '備　考：
    '　　　：2004/09/27 (Mon) 16:07:27 H.Wajima     中間WF在庫選択ﾎﾞﾀﾝ追加
    '　　　：2005/11/17 (Thu) 14:00:32 N.Kojima     ﾛｯﾄ編成からの起動区分を追加。(ﾕｰｻﾞｰ要望№0114)
    '　　　：2008/06/11 (Wed) 14:18:47 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub cmdResvLot_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdResvLot.Click
        
        Dim llngCnt As Integer  'ｶｳﾝﾄ

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｷｬﾘｱIDｸﾘｱ
            txtCarrierID.Text = vbNullString
            
            '@取得区分に値ｾｯﾄ
            pstrfrmxxCM0090Kbn = CPstrCD0M
            
            '@ﾛｯﾄ編成からの起動区分を設定
            pblnfrmxxEN0120Kbn = True

            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@投入予定ﾛｯﾄ一覧画面を表示
            frmxxCM0090.Instance = New frmxxCM0090()
            
            '@投入予定ﾛｯﾄ一覧画面名設定
            frmxxCM0090.Instance.Text = CPstrSubDispTitleLotThrwList
           
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM0090.Instance = Nothing
                Exit Sub
            End If
            
            '@投入予定ﾛｯﾄ選択画面表示
            frmxxCM0090.Instance.ShowDialog(Me)
            frmxxCM0090.Instance = Nothing
            
            '@ﾛｯﾄ編成からの起動区分を初期化
            pblnfrmxxEN0120Kbn = False
            
            '@投入予定ﾛｯﾄ選択結果処理
            If pblnCancel = True Then
                '@ｷｬﾝｾﾙ初期化
                pblnCancel = False
            Else
                '@選択投入予定ﾛｯﾄ表示
                With ptypLotRlst
                    lblLotID.Text = .strLotID                                                    'ﾛｯﾄID
                    lblDivision.Text = .strFlowClass                                             '種別ID
                    lblPd.Text = .strPdId                                                        '機種ID
                    lblWF.Text = .strWfNum                                                       'WF枚数
                    If IsDate(.strPlanThrowinDate) Then
                        lblThrowinDate.Text = Format$(CDate(.strPlanThrowinDate), CPstrDateTimeYMD) '投入予定日
                    Else
                        lblThrowinDate.Text = .strPlanThrowinDate                                '投入予定日
                    End If
                    lblLotManager.Text = .strEngEmpName                                          'ﾛｯﾄ担当
                End With
                
                '@中間WF在庫選択ﾎﾞﾀﾝ使用可能
                cmdWFStockSelect.Enabled = True
                
                '@ﾎﾞﾀﾝ制御ﾌﾗｸﾞ(実行可)
                mblnCmdFlag = True
                
                '@ｷｬﾘｱID使用可能
                txtCarrierID.Enabled = True
                
                '@全部取り消しﾎﾞﾀﾝ使用可能
                cmdClear.Enabled = True
                
                '@優先度使用可能
                cmbPrioSel.Enabled = True
                
                '@ｽﾛｯﾄﾏｯﾌﾟの内容のみｸﾘｱ
                With vsfSlotMap
                    For llngCnt = 1 To CMlngSlotMapRowS - 1
                        .SetData(llngCnt, CMlngvsfMoveSlotMapColWFID, vbNullString)         'WFID
                        .SetData(llngCnt, CMlngvsfMoveSlotMapColWFStat, vbNullString)       '状態
                        .SetData(llngCnt, CMlngvsfMoveSlotMapColBeforLotID, vbNullString)   '元ﾛｯﾄID
                        '@↓2020/02/19 (Wed) 17:11:34 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        .SetData(llngCnt, CMlngvsfMoveSlotMapColGRB, vbNullString)          'GRB
                        '@↑2020/02/19 (Wed) 17:11:34 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    Next llngCnt
                End With
            End If
            
            '@中間WF在庫選択ﾎﾞﾀﾝが使用可能の場合
            If cmdWFStockSelect.Enabled = True Then
                '@中間WF在庫選択ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdWFStockSelect)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdResvLot_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierID_Change
    '機　能：編成元ｷｬﾘｱID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 16:31:44 N.Kasai
    '更新日：2005/03/07 (Mon) 13:49:06 M.Matsuura
    '備　考：2005/03/07 (Mon) 13:49:06 M.Matsuura  不具合改善対応(No.538)
    Private Sub txtCarrierID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrierID.Change

        Try
            
            '@ｽﾛｯﾄﾏｯﾌﾟの初期化
            Call prvvsfSlotMap_init()
            
        '@↓2005/03/07 (Mon) 13:49:06 M.Matsuura **************************************************追加
            '@ｷｬﾘｱIDを格納している変数を初期化
            pstrCarrierID = vbNullString    'NULL値を設定
        '@↑2005/03/07 (Mon) 13:49:06 M.Matsuura **************************************************追加
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrierID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierID_Validate
    '機　能：ｷｬﾘｱID変更時処理
    '引　数：Cancel：TRUE:ﾌｫｰｶｽ移動不可、FALSE:ﾌｫｰｶｽ移動可
    '戻り値：なし
    '作成日：2004/04/06 (Tue) 16:59:34 Y.Yamagishi
    '更新日：2005/03/07 (Mon) 13:54:00 M.Matsuura
    '備　考：2004/10/13 (Wed) 20:05:19 H.Wajima    inv_.waferlist変更対応
    '　　　：2005/02/04 (Fri) 14:22:29 S.Deguchi    不具合№471対応
    '　　　：2005/03/07 (Mon) 13:54:00 M.Matsuura  不具合改善対応No.538
    Private Sub txtCarrierID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrierID.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@Validate処理を実行
            If prvCareerIDValidate_Proc() = False Then
                '@Validate処理の結果がNGの場合
                e.Cancel = True       'ﾌｫｰｶｽ移動不可
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrierID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClear_Click
    '機　能：画面初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/03 (Wed) 11:13:13 M.Miura
    '更新日：2004/07/22 (Thu) 09:54:15 Y.Yamagishi
    '備　考：
    Private Sub cmdClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClear.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@画面初期化
            Call prvMainFormBd_Init()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClear_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUseChange_Click
    '機　能：ﾛｯﾄ編成確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/03 (Wed) 11:40:16 M.Miura
    '更新日：2005/03/31 (Thu) 16:27:48 N.Kojima
    '備　考：
    '　　　：2005/03/31 (Thu) 14:10:06 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    Private Sub cmdUseChange_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUseChange.Click

        Dim lblnAns                 As Boolean          '戻り値(True/False)
        Dim ltypLotThrowin          As WFstockthrowin   '投入要求格納用
        Dim lstrFormName            As String           'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrGuidMsg             As String           'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String           'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance        As String           '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@画面項目ﾁｪｯｸ
            lblnAns = prvblnThrowin_Chk()
            If lblnAns = False Then
                '@不正項目あり
                Exit Sub
            End If

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
            If pstrUserID = vbNullString Then
                '@未入力の場合、投入中止
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "cmdUseChange_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@ﾛｯﾄ投入ﾃﾞｰﾀ作成
            With ltypLotThrowin
                .strLotID = lblLotID.Text                       'ﾛｯﾄID
                .strCarrierId = txtCarrierID.Text               'ｷｬﾘｱID
                .strEmpID = pstrUserID                          '作業者ｺｰﾄﾞ
                .strLotPriority = cmbPrioSel.Value              '優先度
            End With

            '@ﾒｯｾｰｼﾞ送信処理呼び出し
            lblnAns = pubblnInvThrowin_Sel(CMstrinv_throwin_Ver, _
                                           ltypLotThrowin, _
                                           lstrGuidMsg, _
                                           lstrGuidMsgCode)
            
            If lblnAns = True Then

                '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞに値が入っている場合
                If lstrGuidMsgCode <> vbNullString Then
                    
                    '@表示ｶﾞｲﾀﾞﾝｽMsgの編集("【警告】" & "$$" & "ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ[CODE]">" & "$$" & ｶﾞｲﾀﾞﾝｽMsg)
                    lstrEditGuidance = CPstrWarMsgCode & CPstrGuidanceMsg & CPstrMsgCrCode & _
                                       CPstrGuidanceCode & CPstrBracketLeft & lstrGuidMsgCode & CPstrBracketRight & _
                                       CPstrMsgCrCode & lstrGuidMsg
                    
                    '@ﾒｯｾｰｼﾞ表示"編集済みｶﾞｲﾀﾞﾝｽMsg"
                    pstrDMsg = pubstrMsgReplace_Set(lstrEditGuidance)
                    '@ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                End If
            
                '@画面の初期化
                Call prvMainFormBd_Init()
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0007, ltypLotThrowin.strCarrierId, ltypLotThrowin.strLotID)
                
                '@成功ﾒｯｾｰｼﾞｽﾃｰﾀｽﾊﾞｰ表示
                '@pubVsfInfo_Disp("メッセージコード：C_I07%0$$ロット[ %2 ]を投入しました。キャリア[ %1 ]")
                Call pubVsfInfo_Disp(pstrDMsg)
                                     
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUseChange_Click"
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
    '作成日：2004/03/30 (Tue) 11:06:50 Y.Yamagishi
    '更新日：2004/07/22 (Thu) 16:02:41 Y.Yamagishi
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim llngRet         As Integer          '終了関数戻り値格納
        Dim ltypCommonInfo  As CommonInfo       '終了関数戻り構造体格納

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@終了関数を実行する
            llngRet = publngEnd_Proc(CPstrKeyEN0120, ltypCommonInfo)
            
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

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｱﾝﾛｰﾄﾞ
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/04/01 (Thu) 11:39:49 N.Kasai
    '更新日：2004/11/01 (Mon) 16:25:25 T.Kitagawa
    '備　考：2004/11/01 (Mon) 16:25:25 T.Kitagawa　閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@構造体のｸﾘｱ
            If Not IsNothing(mtypPriorityReasonList) Then
                mtypPriorityReasonList.Clear()           '優先度ﾘｽﾄ構造体
            End If
            
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
            
            '@EN0120ﾌﾗｸﾞの初期化
            pblnfrmxxEN0120Kbn = False
            
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

    '関数名：cmdWFStockSelect_Click
    '機　能：中間WF在庫選択ｸﾘｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/27 (Mon) 15:55:38 H.Wajima
    '更新日：2004/11/02 (Tue) 16:54:14 M.Miura
    '備　考：2004/10/22 (Fri) 11:30:54 Y.Yamagishi　中間WF在庫選択ﾎﾞﾀﾝを押して在庫を選択したときにｽﾛｯﾄマップを表示させる(不具合改善№148)
    '　　　：2004/11/02 (Tue) 16:54:14 M.Miura　ﾎﾞﾀﾝ制御ﾌﾗｸﾞ判定追加(連打で落ちる為)
    '　　　：2005/03/17 (Thu) 16:53:11 S.Deguchi    中間WF在庫一覧で同じｷｬﾘｱを選んだ場合にはﾌｫｰｶｽ移動のみ行う処理を追加
    Private Sub cmdWFStockSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWFStockSelect.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾎﾞﾀﾝ制御ﾌﾗｸﾞが実行不可の場合
            If mblnCmdFlag = False Then
                Exit Sub
            End If
                    
            '@ﾎﾞﾀﾝ制御ﾌﾗｸﾞ(実行不可)
            mblnCmdFlag = False
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@中間WF在庫選択
            frmxxCM00N0.Instance = New frmxxCM00N0()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM00N0.Instance = Nothing
                '@ﾎﾞﾀﾝ制御ﾌﾗｸﾞ(実行可)
                mblnCmdFlag = True
                Exit Sub
            End If
            
            '@ｷｬﾘｱ一覧表示
           frmxxCM00N0.Instance.ShowDialog(Me)
           frmxxCM00N0.Instance = Nothing
                 
        '@↓2005/03/17 (Thu) 16:56:09 S.Deguchi **************************************************修正
            '@中間WF在庫が選択されている場合
            If pstrCarrierID <> vbNullString Then
                '@退避領域と比較
                If pstrCarrierID <> mstrCarrier Then
                    '@ｷｬﾘｱIDをｾｯﾄ
                    txtCarrierID.Text = pstrCarrierID
                
                    '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtCarrierID)
                    
                    '@ｷｬﾘｱIDのValidate処理を実行
                    RemoveHandler txtCarrierID.Validating, AddressOf txtCarrierID_Validate
                    Call txtCarrierID_Validate(txtCarrierID, New CancelEventArgs(False))
                    AddHandler txtCarrierID.Validating, AddressOf txtCarrierID_Validate
                Else
                    '@ﾌｫｰｶｽ移動
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If
            End If
        '@↑2005/03/17 (Thu) 16:56:09 S.Deguchi **************************************************修正
            
            '@ﾎﾞﾀﾝ制御ﾌﾗｸﾞ(実行可)
            mblnCmdFlag = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWFStockSelect_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPrioSel_CloseUp
    '機　能：優先度ｺﾝﾎﾞﾎﾞｯｸｽ CloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/30 (Thu) 19:49:17 H.Wajima
    '更新日：2004/09/30 (Thu) 19:49:17
    '備　考：
    Private Sub cmbPrioSel_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPrioSel.CloseUp

        Try
            
            '@ｺﾝﾎﾞﾎﾞｯｸｽが空白かどうか判定
            If cmbPrioSel.Text <> vbNullString Then
                '@空白でない場合
                '@Tab送り
                SendKeys.SendWait(CPstrSendKeysTab)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPrioSel_CloseUp"
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

    '関数名：prvMainFormBd_Init
    '機　能：画面初期化(ｽﾃｰﾀｽﾊﾞｰ以外)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/05 (Fri) 14:26:20 M.Miura
    '更新日：2004/07/22 (Thu) 09:59:43 Y.Yamagishi
    '備　考：
    Private Sub prvMainFormBd_Init()

        Try

            '@画面初期化
            Call prvMainForm_Init()
            
            '@ｽﾛｯﾄﾏｯﾌﾟの初期化
            Call prvvsfSlotMap_init()
            
            '@優先順位ｺﾝﾎﾞﾎﾞｯｸｽ初期値ｾｯﾄ
            cmbPrioSel.ListIndex = CMstrcmbPrioSel

            '@投入予定ﾛｯﾄID選択ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(cmdResvLot)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMainFormBd_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvMainForm_Init
    '機　能：ﾒｲﾝﾌｫｰﾑ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 11:26:36 M.Miura
    '更新日：2008/06/11 (Wed) 14:19:14 N.Kojima
    '備　考：
    '　　　：2004/09/27 (Mon) 16:06:14 H.Wajima     中間WF在庫ﾎﾞﾀﾝ追加
    '　　　：2004/10/04 (Mon) 14:03:14 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2004/10/22 (Fri) 11:28:32 Y.Yamagishi  中間在庫WF選択ﾎﾞﾀﾝにValidateｲﾍﾞﾝﾄが起こらないよう修正
    '　　　：2005/03/22 (Tue) 11:33:36 N.Kojima     変数pstrCarrierIDの初期化処理追加(不具合№538)
    '　　　：2008/06/11 (Wed) 14:19:14 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvMainForm_Init()

        Dim lstrFormTitle           As String           'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0120, lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@初期値設定
            mstrCarrier = vbNullString                  'ｷｬﾘｱID(ﾒｯｾｰｼﾞ成功時のｷｬﾘｱID)
            lblLotID.Text = vbNullString             'ﾛｯﾄID
            lblDivision.Text = vbNullString          '種別ID
            lblPd.Text = vbNullString                '機種ID
            lblWF.Text = vbNullString                'WF枚数
            lblThrowinDate.Text = vbNullString       '投入予定日
            lblLotManager.Text = vbNullString        'ﾛｯﾄ担当
            txtCarrierID.Text = vbNullString            'ｷｬﾘｱID
            
            '@Public変数の初期化
            pstrCarrierID = vbNullString
            
            '@ﾛｯｸ設定
            cmdUseChange.Enabled = False                '確定ﾎﾞﾀﾝ
            cmdClear.Enabled = False                    '全部取り消しﾎﾞﾀﾝ
            cmbPrioSel.Enabled = False                  '優先度ｺﾝﾎﾞﾎﾞｯｸｽ
            cmdWFStockSelect.Enabled = False            '中間WF在庫選択ﾎﾞﾀﾝ
            txtCarrierID.Enabled = False                'ｷｬﾘｱID
            vsfSlotMap.Enabled = False                  'ｽﾛｯﾄﾏｯﾌﾟ
            
            '@中間在庫WF選択ﾎﾞﾀﾝのCausesValidationをFalseにする
            cmdWFStockSelect.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMainForm_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSlotMap_init
    '機　能：ｽﾛｯﾄﾏｯﾌﾟの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 11:46:16 M.Miura
    '更新日：2004/07/22 (Thu) 10:01:53 Y.Yamagishi
    '備　考：
    Private Sub prvvsfSlotMap_init()

        Dim llngCnt As Integer  'ｶｳﾝﾄ

        Try
            
            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfSlotMap
                .Redraw = False
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear()
                
                '@↓2020/02/19 (Wed) 17:18:38 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .Cols.Count = CMlngSlotMapColmNum
                '@↑2020/02/19 (Wed) 17:18:38 Y.Yoneyama 「.Netへ反映未」 **************************************************

                '@文字表示位置設定
                .Cols(CMlngvsfMoveSlotMapColNo).TextAlign = TextAlignEnum.LeftCenter 'flexAlignRightCenter              '右中央
                .Cols(CMlngvsfMoveSlotMapColWFID).TextAlign = TextAlignEnum.LeftCenter 'flexAlignLeftCenter             '左中央
                .Cols(CMlngvsfMoveSlotMapColWFStat).TextAlign = TextAlignEnum.LeftCenter 'flexAlignLeftCenter           '左中央
                .Cols(CMlngvsfMoveSlotMapColBeforLotID).TextAlign = TextAlignEnum.LeftCenter 'flexAlignLeftCenter       '左中央
                '@↓2020/02/19 (Wed) 17:12:16 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .Cols(CMlngvsfMoveSlotMapColGRB).TextAlign = TextAlignEnum.LeftCenter       '左中央
                '@↑2020/02/19 (Wed) 17:12:16 Y.Yoneyama 「.Netへ反映未」 **************************************************

                '@行数設定
                .Rows.Count = CMlngSlotMapRowS
                .Row = 0
                
                '@ｶﾚﾝﾄｾﾙの周囲に描画するﾌｫｰｶｽ枠のｽﾀｲﾙを設定(なし)
                .FocusRect = FocusRectEnum.None
                
                '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽがある時のみﾊｲﾗｲﾄ
                .HighLight = HighLightEnum.WithFocus

                '@一覧表の表題設定
                Dim cellRange As CellRange = .GetCellRange(CMvsfSlotMapRowTitle, CMlngvsfMoveSlotMapColNo, CMvsfSlotMapRowTitle, CMlngvsfMoveSlotMapColBeforLotID) '表題
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                  '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)     '背景色
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                    '文字位置
                headerStyle.Trimming  = StringTrimming.None                           'NSYS ﾍｯﾀﾞは省略表示なしに設定
                cellRange.Style = headerStyle
                
                '@ｽﾛｯﾄﾏｯﾌﾟの1行からｽﾛｯﾄﾏｯﾌﾟの最後まで
                For llngCnt = .Rows.Fixed To .Rows.Count - 1
                    '@ｽﾛｯﾄ№設定
                    .SetData(llngCnt, CMlngvsfMoveSlotMapColNo, Format$(CMlngSlotMapRowS - llngCnt, CPstrSlotNoFormat))
                Next llngCnt
                
                '@列幅、ﾀｲﾄﾙ設定
                .Cols(CMlngvsfMoveSlotMapColNo).Width = CMlngvsfMoveSlotMapWNo
                .SetData(CMvsfSlotMapRowTitle, CMlngvsfMoveSlotMapColNo, CMstrvsfMoveSlotMapTNo)
                
                .Cols(CMlngvsfMoveSlotMapColWFID).Width = CMlngvsfMoveSlotMapWWFID
                .SetData(CMvsfSlotMapRowTitle, CMlngvsfMoveSlotMapColWFID, CMstrvsfMoveSlotMapTWFID)
                
                .Cols(CMlngvsfMoveSlotMapColWFStat).Width = CMlngvsfMoveSlotMapWWFStat
                .SetData(CMvsfSlotMapRowTitle, CMlngvsfMoveSlotMapColWFStat, CMstrvsfMoveSlotMapTWFStat)
                
                .Cols(CMlngvsfMoveSlotMapColBeforLotID).Width = CMlngvsfMoveSlotMapWBeforLotID
                .SetData(CMvsfSlotMapRowTitle, CMlngvsfMoveSlotMapColBeforLotID, CMstrvsfMoveSlotMapTBeforLotID)

                '@↓2020/02/19 (Wed) 17:12:40 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .Cols(CMlngvsfMoveSlotMapColGRB).Width = CMlngvsfMoveSlotMapWGRB
                .SetData(CMvsfSlotMapRowTitle, CMlngvsfMoveSlotMapColGRB, CMstrvsfMoveSlotMapTGRB)
                '@↑2020/02/19 (Wed) 17:12:40 Y.Yoneyama 「.Netへ反映未」 **************************************************

                .Redraw = True
                '@ﾛｯｸ
                .Enabled = False
                
            End With
            
            '@確定ﾎﾞﾀﾝ使用不可
            cmdUseChange.Enabled = False
            '@退避用ｷｬﾘｱID(ﾒｯｾｰｼﾞ成功時のｷｬﾘｱID)初期化
            mstrCarrier = vbNullString

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMap_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbPrioSel_Init
    '機　能：ｺﾝﾎﾞﾎﾞｯｸｽ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/19 (Mon) 13:28:15 Y.Yamagishi
    '更新日：2004/07/22 (Thu) 10:30:36 Y.Yamagishi
    '備　考：
    Private Sub prvcmbPrioSel_Init()

        Try

            '@ｺﾝﾎﾞﾎﾞｯｸｽ設定
            With cmbPrioSel
                .Clear()
                .BackColor = SystemColors.Window
                .DispCols = CMlngCmbPrioSelDispCols                 'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbPrioSelGridColPriorityName        'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbPrioSelGridColPriorityID        '値取得列
                .DirectInput = False                                'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                '.Font.Size = CMlngCmbPrioSelFontSize                'ﾌｫﾝﾄｻｲｽﾞ
                .Font = New Font(.Font.FontFamily, CMlngCmbPrioSelFontSize, _
                                 .Font.Style, .Font.Unit)            'ﾌｫﾝﾄｻｲｽﾞ      
                '.GridFont.Size = CMlngCmbPrioSelGridFontSize        'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbPrioSelGridFontSize, _
                                     .GridFont.Style, .GridFont.Unit) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngComboRowHeight                    '行の高さ
                .ColAlignment(CMlngCmbPrioSelGridColPriorityName) = TextAlignEnum.LeftCenter '左中央
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbPrioSel_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvMasPrioinfo_Disp
    '機　能：優先順位情報項目ﾏｽﾀをｺﾝﾎﾞへｾｯﾄ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/19 (Mon) 13:28:56 Y.Yamagishi
    '更新日：2004/07/22 (Thu) 10:23:20 Y.Yamagishi
    '備　考：構造体の0件ﾁｪｯｸは上流工程でﾁｪｯｸ済み
    Private Sub prvMasPrioinfo_Disp()

        Dim llngCnt                 As Integer  'ｶｳﾝﾄ

        Try
                
                '@優先順位項目名ｾｯﾄ
                With cmbPrioSel
                    .Clear()
                    For llngCnt = 0 To mtypPriorityReasonList.Count - 1
                        .AddItem(mtypPriorityReasonList(llngCnt).strMasPriorityId & CPstrSpace & _
                                 mtypPriorityReasonList(llngCnt).strMasPriorityName & vbTab & _
                                 mtypPriorityReasonList(llngCnt).strMasPriorityId)
                    Next llngCnt
                End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMasPrioinfo_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN0120_Disp
    '機　能：画面の表示
    '引　数：ltypInvWaferList：在庫WFﾘｽﾄ
    '戻り値：
    '作成日：2005/02/04 (Fri) 14:27:26 S.Deguchi
    '作成日：2004/04/01 (Thu) 11:39:49 N.Kasai
    '更新日：2004/10/26 (Tue) 09:30:55 Y.Yamagishi
    '備　考：2004/10/13 (Wed) 20:06:34 H.Wajima     inv_.waferlist変更対応
    '　　　：2004/10/26 (Tue) 09:30:55 Y.Yamagishi  ｽﾛｯﾄﾏｯﾌﾟの背景色変更
    '　　　：2005/02/04 (Fri) 14:28:15 S.Deguchi    不具合№471対応
    Private Sub prvfrmxxEN0120_Disp(ByRef ltypInvWaferList As InvWaferList, ByRef ltypInvLotList As InvLotListAns)


        Dim llngCnt             As Integer      'ｷｬﾘｱのｶｳﾝﾄ数
        Dim llngSlotPosition    As Integer      'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝの格納
        Dim cellRange           As CellRange

        Try
            Dim newStyle_BackColor_vbButtonFace As CellStyle = vsfSlotMap.Styles.Add("CustomStyle_BackColor_vbButtonFace")
            newStyle_BackColor_vbButtonFace.BackColor = SystemColors.ControlLight
            Dim newStyle_BackColor_CPlngGridDarkGray As CellStyle = vsfSlotMap.Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
            newStyle_BackColor_CPlngGridDarkGray.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)

            vsfSlotMap.Redraw = False

            For llngCnt = 1 To CMlngSlotMapRowS - 1
                '@ｽﾛｯﾄｻｲｽﾞ以上のｽﾛｯﾄ№を空白に、背景色を薄い灰色(ﾎﾞﾀﾝの表面の色)に変更
                If llngCnt <= CMlngSlotMapRowS - CInt(ltypInvLotList.typLotListAns(0).strSlotSize) - 1 Then
                    '@ｽﾛｯﾄ№は空白
                    vsfSlotMap.SetData(llngCnt, CMlngvsfMoveSlotMapColNo, vbNullString)
                    '@WFID
                    '@WF状態表示
                    '@元ﾛｯﾄID
                    '@GRB               
                    cellRange = vsfSlotMap.GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColBeforLotID)
                    cellRange.Style = newStyle_BackColor_vbButtonFace

                Else
                '@ｽﾛｯﾄｻｲｽﾞ以下でWFの存在しないｽﾛｯﾄの背景色を濃い灰色に変更
                    '@WFID
                    '@WF状態表示
                    '@元ﾛｯﾄID
                    '@GRB    
                    cellRange = vsfSlotMap.GetCellRange(llngCnt, CMlngvsfMoveSlotMapColWFID, llngCnt, CMlngvsfMoveSlotMapColBeforLotID)
                    cellRange.Style = newStyle_BackColor_CPlngGridDarkGray
                End If
            Next

            Dim newStyle_BackColor_vbWhite As CellStyle = vsfSlotMap.Styles.Add("CustomStyle_BackColor_vbWhite")
            newStyle_BackColor_vbWhite.BackColor = Color.White

            Dim newStyleGRB As CellStyle
            Dim cellRangeGRB As CellRange

            llngCnt = 0
            '@WFﾘｽﾄ分ﾙｰﾌﾟ
            Do While ltypInvWaferList.lngInvWaferListCnt > llngCnt
                '@ｽﾛｯﾄﾏｯﾌﾟの表示
                With ltypInvWaferList.typInvWaferList(llngCnt)
                    
                    '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝが空白ではないこと
                    If Trim(.strSlotPosition) <> vbNullString Then
                        
                        '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝの取得
                        llngSlotPosition = (CMlngSlotMapRowS - CLng(.strSlotPosition))
                        
                        '@WFID
                        vsfSlotMap.SetData(llngSlotPosition, CMlngvsfMoveSlotMapColWFID, .strWfId)
                        '@WF状態表示
                        vsfSlotMap.SetData(llngSlotPosition, CMlngvsfMoveSlotMapColWFStat, .strWFStatus)
                        '@元ﾛｯﾄID
                        vsfSlotMap.SetData(llngSlotPosition, CMlngvsfMoveSlotMapColBeforLotID, .strBFLotID)
                        
                        '@WFID
                        '@WF状態表示
                        '@元ﾛｯﾄID
                        cellRange = vsfSlotMap.GetCellRange(llngSlotPosition, CMlngvsfMoveSlotMapColWFID, llngSlotPosition, CMlngvsfMoveSlotMapColBeforLotID)
                        cellRange.Style = newStyle_BackColor_vbWhite

                        '@↓2020/02/19 (Wed) 17:15:25 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        '@GRB
                        vsfSlotMap.SetData(llngSlotPosition, CMlngvsfMoveSlotMapColGRB, .strGRBClass)
                        '@GRB背景色
                        newStyleGRB = vsfSlotMap.Styles.Add("GRBColor" + llngSlotPosition.ToString)
                        newStyleGRB.BackColor = pubGRBBackColor(.strGRBClass, Color.White)
                        cellRangeGRB = vsfSlotMap.GetCellRange(llngSlotPosition, CMlngvsfMoveSlotMapColGRB)
                        cellRangeGRB.Style = newStyleGRB
                        '@↑2020/02/19 (Wed) 17:15:25 Y.Yoneyama 「.Netへ反映未」 **************************************************

                    End If
                End With
                llngCnt = llngCnt + 1
            Loop

            vsfSlotMap.Redraw = True
           
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN0120_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '@↓2005/03/03 (Thu) 09:49:11 M.Matsuura  **************************************************
    '関数名：prvCareerIDValidate_Proc
    '機　能：　Validate処理の代用(共通化)
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/03 (Thu) 09:49:11 M.Matsuura
    '更新日：2005/11/25 (Fri) 11:38:30 N.Kasai
    '備　考：
    '　　　：2005/11/25 (Fri) 11:38:30 N.Kasai      処理区分追加
    Private Function prvCareerIDValidate_Proc() As Boolean
        
        Dim lblnAnsList             As Boolean              'WF在庫情報取得結果
        Dim ltypInvWaferList        As InvWaferList         '在庫ｳｪﾊﾘｽﾄ
        Dim ltypInvLotListReq       As InvLotListReq        '要求構造体
        Dim ltypInvLotList          As InvLotListAns        '在庫ﾛｯﾄﾘｽﾄ
        Dim lstrReseponseFormName   As String               'ﾌｫｰﾑ名格納(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名格納(ﾚｽﾎﾟﾝｽ用)
        Dim lblnNextCtrl            As Boolean              'NSYS Focus設定フラグ

        Try

            '@戻り値の設定
            prvCareerIDValidate_Proc = True

            '@ｷｬﾘｱIDが空白の場合は処理を行わない。
            If txtCarrierID.Text = vbNullString Then
                Exit Function
            End If

            If ActiveControl.Name = txtCarrierID.Name OrElse _
                ActiveControl.Name = cmbPrioSel.Name Then
                lblnNextCtrl = True
            Else
                lblnNextCtrl = False
            End If
            
            '@投入予定ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtCarrierID.NowByte < CMlngMaxByte Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@戻り値を設定
                '@Cancel = True
                '@txtCarrierID.SetFocus
                prvCareerIDValidate_Proc = False
                
                Exit Function
            End If
            
            '@ｷｬﾘｱID情報の取得(入力ｷｬﾘｱIDと前回のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功)と違う場合のみ実行)
            If Trim(txtCarrierID.Text) <> vbNullString And _
                txtCarrierID.Text <> mstrCarrier Then
            
                '@ｽﾛｯﾄﾏｯﾌﾟの初期化
                Call prvvsfSlotMap_init()
                
                 '@ﾚｽﾎﾟﾝｽ取得開始
                lstrReseponseFormName = "frmxxEN0120"
                lstrEventName = "txtCarrier_Validate"
                Call pubResponseStart(lstrReseponseFormName, lstrEventName)
                
        '@↓2005/02/04 (Fri) 12:39:22 S.Deguchi **************************************************修正
                '@要求構造体に格納
                With ltypInvLotListReq
                    '@ｼｽﾃﾑﾌﾞﾛｯｸ
                    .strSbID = vbNullString
                    
        '@↓2005/11/25 (Fri) 11:38:25 N.Kasai **************************************************
                    '@処理区分(ｷｬﾘｱ指定&ﾛｯﾄ編成)
                    .strClassDivision = CPstrCD0K & CPstrCD1W
        '@↑2005/11/25 (Fri) 11:38:25 N.Kasai **************************************************
                    
                    '@ｷｬﾘｱID(空欄)
                    .strCarrierId = txtCarrierID.Text
                    
                    '@ﾛｯﾄID
                    .strLotID = vbNullString
                    
                    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                    .strMsgVer = CMstrinv_lotlist_Ver
                End With
                
                '@中間在庫Lot一覧取得
                lblnAnsList = pubblnInvLotList_Sel(ltypInvLotListReq, ltypInvLotList)

        '@↑2005/02/04 (Fri) 12:39:22 S.Deguchi **************************************************修正
                '@結果確認
                If lblnAnsList = True Then
                    '@ﾛｯﾄﾘｽﾄの件数が1件以上の場合
                    If ltypInvLotList.lngLotListAnsCnt > 0 Then
                        
                        '@WF在庫情報取得
                        lblnAnsList = pubblnInvWaferlist_Sel(CMstrinv_waferlistVer, _
                                                             txtCarrierID.Text, _
                                                             vbNullString, _
                                                             ltypInvWaferList)
                        
                        '@戻り値の判定
                        If lblnAnsList = False Then
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(lstrReseponseFormName, lstrEventName)
                            
                            Exit Function
                        End If
                        
                        '@WFの件数を判定する
                        Select Case ltypInvWaferList.lngInvWaferListCnt
                            Case 0
                                '@WFﾘｽﾄが0の場合
                                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                Call pubResponseCancel(lstrReseponseFormName, lstrEventName)
                            
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0077, txtCarrierID.Text)
                                
                                '@"キャリアに紐付くWFが存在しません。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                '@ｴﾗｰ時のｶｰｿﾙ制御
                                
                                '@戻り値を設定
                                '@Cancel = True
                                prvCareerIDValidate_Proc = False
                                
                                Exit Function
                            Case Is > 0
                                '@WFﾘｽﾄが1以上の場合
                                '@取得OK
                                
                                '@結果表示
                                Call prvfrmxxEN0120_Disp(ltypInvWaferList, ltypInvLotList)
                                
                                '@確定ﾎﾞﾀﾝ使用可能
                                cmdUseChange.Enabled = True
                                
                                '@優先度ｺﾝﾎﾞﾎﾞｯｸｽにｾｯﾄﾌｫｰｶｽ
                                If lblnNextCtrl Then
                                    Call pubSetFocus(cmbPrioSel)
                                End If
                        End Select
                    
                        '@ｷｬﾘｱID退避(ﾒｯｾｰｼﾞ成功時)
                        mstrCarrier = txtCarrierID.Text
                    Else
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0004, txtCarrierID.Text)
                        
                        '@"該当データがありません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ｴﾗｰ時のｶｰｿﾙ制御
                                
                        '@戻り値を設定
                        '@Cancel = True
                        prvCareerIDValidate_Proc = False
                    
                    End If
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrReseponseFormName, lstrEventName)
                    
                    Exit Function

                Else
                    '@ｴﾗｰ時のｶｰｿﾙ制御
                    
                    '@戻り値を設定
                    '@Cancel = True
                    prvCareerIDValidate_Proc = False
                    
                End If
            End If
            
            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
            Call pubResponseCancel(lstrReseponseFormName, lstrEventName)

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCareerIDValidate_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function
    '@↑2005/03/03 (Thu) 09:49:11 M.Matsuura  **************************************************


    '関数名：prvblnThrowin_Chk
    '機　能：投入確定前ﾁｪｯｸ
    '引　数：なし
    '戻り値：True：ﾍﾞﾝﾀﾞｰあり、False：ﾍﾞﾝﾀﾞｰなし
    '作成日：2004/07/22 (Thu) 17:25:55 Y.Yamagishi
    '更新日：2004/12/09 (Thu) 10:21:54 N.Kasai
    '備　考：
    '　　　：2004/12/09 (Thu) 10:21:54 N.Kasai  CLng関数前にIsNumeric関数を追加(VBｴﾗｰを抑止)
    Private Function prvblnThrowin_Chk() As Boolean

        Dim llngRCnt        As Integer  'ｶｳﾝﾄ
        Dim llngWFcnt       As Integer  'WF設定ｶｳﾝﾄ数
        Dim llngWFNum       As Integer  'WFNUM格納変数

        Try
            
            '@初期化
            prvblnThrowin_Chk = False
            llngWFcnt = 1
            
            '@ﾛｯﾄIDﾁｪｯｸ
            If lblLotID.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0022)
                '@"ロットIDが設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Call pubSetFocus(cmdResvLot)
                Exit Function
            End If
            
            '@ｷｬﾘｱIDﾁｪｯｸ
            If Trim(txtCarrierID.Text) = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
               '@"キャリアIDが設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Call pubSetFocus(txtCarrierID)
                Exit Function
            End If

            With vsfSlotMap
                '@ｽﾛｯﾄﾏｯﾌﾟ(WF)の状況
                For llngRCnt = 1 To .Rows.Count - 1
                    If .GetData(llngRCnt, CMlngvsfMoveSlotMapColWFID) <> vbNullString Then
                        llngWFcnt = llngWFcnt + 1
                    End If
                Next llngRCnt
                
                '@設定WF枚数確定
                If llngWFcnt <> 1 Then
                    llngWFcnt = llngWFcnt - 1
                End If

        '@start：2004/12/09 (Thu) 10:21:54 N.Kasai  CLng関数前にIsNumeric関数を追加(VBｴﾗｰを抑止)

                '@数値ﾁｪｯｸ
                If IsNumeric(lblWF.Text) = True Then
                    llngWFNum = CLng(lblWF.Text)
                Else
                    llngWFNum = 0
                End If

        '@end：2004/12/09 (Thu) 10:21:54 N.Kasai  CLng関数前にIsNumeric関数を追加(VBｴﾗｰを抑止)

                '@WF枚数判定
                If llngWFcnt <> llngWFNum Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0024)
                    '@"投入予定のWF枚数と設定数が異なります。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@ｷｬﾘｱIDにｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(txtCarrierID)
                    Exit Function
                End If
                
            End With
            
            prvblnThrowin_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnThrowin_Chk"
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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfSlotMap.BeforeDoubleClick

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

    '関数名：cursor_Enter
    '機　能 ： 項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考 ： Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles cmdClose.Enter, _
            cmdWFStockSelect.Enter, cmdResvLot.Enter, cmdUseChange.Enter, cmdClear.Enter, _
            cmbPrioSel.Enter, vsfSlotMap.Enter, txtCarrierID.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '自動Validate = OFF
            Case cmdClose.Name, cmdResvLot.Name
                Me.AutoValidate = AutoValidate.Disable

            '自動Validate = ON
            Case Else
                Me.AutoValidate = AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

End Class
