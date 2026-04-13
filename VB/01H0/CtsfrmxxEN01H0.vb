'ﾌｧｲﾙ名：xxEN01H0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：投入移載一覧　メインフォーム
'作成日：2004/10/22 (Fri) 18:47:50 N.Kasai
'更新日：2008/06/11 (Wed) 15:19:40 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01H0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01H0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01H0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01H0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01H0)
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
    '@機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion                     As String = "03.01"

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrlot_uncarrylist_Ver              As String = "01.00"             '投入移載ﾛｯﾄﾘｽﾄ
    Private Const CMstrlot_forcedmoveVer                As String = "03.00"             '投入移載
    Private Const CMstrmas_wplist__Ver                  As String = "05.01"             '装置一覧取得

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN01H0      'ﾛｰｶﾙﾒﾆｭｰKey

    '@vsfUnCarryListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfListColNo                     As Integer = 0                  '№
    Private Const CMlngvsfListColThrowinDate            As Integer = 1                  '投入確定日
    Private Const CMlngvsfListColPdID                   As Integer = 2                  '機種ID
    Private Const CMlngvsfListColLotID                  As Integer = 3                  'ﾛｯﾄID
    Private Const CMlngvsfListColFlowClass              As Integer = 4                  '種別ID
    Private Const CMlngvsfListColCarrirID               As Integer = 5                  'ｷｬﾘｱID
    Private Const CMlngvsfListColWfNum                  As Integer = 6                  'WF枚数
    Private Const CMlngvsfListColPdName                 As Integer = 7                  '機種(非表示)
    Private Const CMlngvsfListColFlowClassName          As Integer = 8                  '種別名(非表示)
    Private Const CMlngvsfListColLotManagerID           As Integer = 9                  'ﾛｯﾄ担当者ID(非表示)
    Private Const CMlngvsfListColProductionLotID        As Integer = 10                 '製造ﾛｯﾄID
    Private Const CMlngvsfListColLotManagerName         As Integer = 11                 'ﾛｯﾄ担当者名

    '@vsfUnCarryListの定数宣言(表示幅)
    Private Const CMlngvsfListColWNo                    As Integer = 60                 '№
    Private Const CMlngvsfListColWThrowinDate           As Integer = 160                '投入予定日
    Private Const CMlngvsfListColWPdID                  As Integer = 100                '機種ID
    Private Const CMlngvsfListColWPdName                As Integer = 100                '機種名
    Private Const CMlngvsfListColWLotID                 As Integer = 213                'ﾛｯﾄID
    Private Const CMlngvsfListColWFlowClass             As Integer = 100                '種別ID
    Private Const CMlngvsfListColWFlowClassName         As Integer = 100                '種別名
    Private Const CMlngvsfListColWCarrierID             As Integer = 133                'ｷｬﾘｱID
    Private Const CMlngvsfListColWWfNum                 As Integer = 100                'WF枚数
    Private Const CMlngvsfListColWProductionLotID       As Integer = 213                '製造ﾛｯﾄID
    Private Const CMlngvsfListColWLotManagerID          As Integer = 120                'ﾛｯﾄ担当者ID
    Private Const CMlngvsfListColWLotManagerName        As Integer = 120                'ﾛｯﾄ担当者名

    '@vsfUnCarryListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfListColTNo                    As String = "№"
    Private Const CMstrvsfListColTThrowinDate           As String = "投入確定日"
    Private Const CMstrvsfListColTPdID                  As String = "機種"
    Private Const CMstrvsfListColTPdName                As String = "機種(和名)"
    Private Const CMstrvsfListColTLotID                 As String = "ロットID"
    Private Const CMstrvsfListColTFlowClass             As String = "種別"
    Private Const CMstrvsfListColTFlowClassName         As String = "種別(和名)"
    Private Const CMstrvsfListColTCarrirID              As String = "キャリアID"
    Private Const CMstrvsfListColTWfNum                 As String = "WF枚数"
    Private Const CMstrvsfListColTProductionLotID       As String = "製造ロットID"
    Private Const CMstrvsfListColTLotManagerID          As String = "ロット担当者ID"
    Private Const CMstrvsfListColTLotManagerName        As String = "ロット担当"

    '@ｸﾞﾘｯﾄﾞ制御
    Private Const CMlngvsfListCols                      As Integer = 12                 'ｶﾗﾑ数
    Private Const CMlngvsfUnCarryListTRow               As Integer = 0                  'ﾀｲﾄﾙ行
    Private Const CMlngvsfUnCarryListHFontSize          As Integer = 12                 'ﾍｯﾀﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfUnCarryListHdHeight           As Integer = 26                 '行の高さ(ﾍｯﾀﾞｰのみ)
    Private Const CMlngvsfUnCarryListHeight             As Integer = 43                 '行の高さ

    '@ｽｸﾛｰﾙ制御
    Private Const CMlngSideScrollOnFlag                 As Integer = 1                  '横ｽｸﾛｰﾙ活性化
    Private Const CMlngSideScrollOffFlag                As Integer = 2                  '横ｽｸﾛｰﾙ非活性化
    Private Const CMlngUpDownindex                      As Integer = 0                  '縦ｽｸﾛｰﾙﾗﾍﾞﾙｲﾝﾃﾞｯｸｽ
    Private Const CMlngLeftRightindex                   As Integer = 1                  '横ｽｸﾛｰﾙﾗﾍﾞﾙｲﾝﾃﾞｯｸｽ

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                      As Integer = 16                 'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Integer = 16                 'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols1                     As Integer = 1                  'ｸﾞﾘｯﾄﾞ表示列数=1
    Private Const CMlngCmbRowHeight                     As Integer = 43                 'ﾘｽﾄ行の高さ
    Private Const CMlngCmbGridCol0                      As Integer = 0                  '名称列番=0
    Private Const CMlngCmbGridCol1                      As Integer = 1                  '名称列番=1

    '@その他
    Private Const CMstrThrowineq_type                   As String = "13"                'EQ_TYPE(投入装置=13)

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mtypWpList                                  As List(Of WpList)              '装置一覧格納用
    Private mlngWpListCnt                               As Integer                      '装置一覧件数
    Private mtypChgSort                                 As ChgSort                      'ｿｰﾄ保持用
    Private mlngSideScrollFlag                          As Integer                      '横ｽｸﾛｰﾙの使用ﾌﾗｸﾞ(1:発生/2:不要)
    Private buttonProcessing                            As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                      'NSYS WindowCloseフラグ
    Private vsfUnCarryListRowBeforeSort                 As Integer                      'NSYS ｿｰﾄ時の選択行退避

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
        pubVsfMouseWheelManager_Set(vsfUnCarryList, cmdUp, cmdDown, cmdLeft, cmdRight)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：Form_Load
    '機　能：初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/22 (Fri) 14:25:02 N.Kasai
    '更新日：2005/03/16 (Wed) 09:21:46 N.Kojima
    '備　考：2005/03/16 (Wed) 09:21:46 N.Kojima     投入装置追加に伴う修正(改善№577)
    Private Sub Form_Load()

        Dim lblnAns                     As Boolean              '汎用戻り値
        Dim lstrFormName                As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName               As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)

        Try
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            '@起動区分：Null(単体起動)
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN01H0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
                '@異常終了の場合
                '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                Call pubMenuExpand_Disp()
                '@ﾌｫｰﾑを閉じる
                Exit Sub
            End If
            
            '@構造体の初期化(ｿｰﾄ用)
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                .typChgSortList = New List(Of ChgSortList)
                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            '@画面初期化
            Call prvMainForm_Init()

            '@ｸﾞﾘｯﾄﾞ表示の初期化
            Call prvvsfUnCarryList_init()
            
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString

            '@最新ﾎﾞﾀﾝｸﾘｯｸ処理
            Call cmdLotSearch_Click(cmdLotSearch,New EventArgs())
            
        '@↓2005/03/14 (Mon) 16:18:31 N.Kojima **************************************************
            '@投入装置ｺﾝﾎﾞﾎﾞｯｸｽ初期化
            Call prvcmbThrowinWP_Init()
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "Form_Load"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@装置一覧取得、結果ﾁｪｯｸ
            lblnAns = pubblnWpList_Sel(CMstrmas_wplist__Ver, mlngWpListCnt, pstrSBID, CPstrCD3U, _
                                            , , , , CMstrThrowineq_type)
            '@戻り値判定
            If lblnAns = True Then
                '配列の件数ﾁｪｯｸ
                If mlngWpListCnt > 0 Then
                    '@投入装置をｺﾝﾎﾞへｾｯﾄ
                    Call prvcmbThrowinWP_Disp()
                End If
            Else
                '@異常の場合終了
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
        '@↑2005/03/14 (Mon) 16:18:31 N.Kojima **************************************************
            
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

    '@↓2005/03/23 (Wed) 13:08:55 N.Kojima **************************************************
    '関数名：Form_Activate
    '機　能：ﾛｰﾄﾞ後処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/23 (Wed) 13:04:47 N.Kojima
    '更新日：2005/03/23 (Wed) 13:04:47
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            With vsfUnCarryList
                '@ｸﾞﾘｯﾄﾞにﾃﾞｰﾀが1件以上あり、かつ、投入装置が1件の場合
                If .Rows.Count > 1 And cmbThrowinWP.ListCount = 1 Then
                    '@ｸﾞﾘｯﾄﾞが有効か
                    If .Enabled = True Then
                        '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfUnCarryList)
                    End If
                End If
            End With

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
    '@↑2005/03/23 (Wed) 13:08:55 N.Kojima **************************************************

    '@↓2005/03/14 (Mon) 16:20:36 N.Kojima **************************************************
    '関数名：cmbThrowinWP_CloseUp
    '機　能：投入装置選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/14 (Mon) 16:21:25 N.Kojima
    '更新日：2005/03/14 (Mon) 16:21:25
    '備　考：
    Private Sub cmbThrowinWP_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbThrowinWP.CloseUp

        Try
            '@Validate処理を呼ぶ
            RemoveHandler cmbThrowinWP.Validating,AddressOf cmbThrowinWP_Validate
            Call cmbThrowinWP_Validate(sender,New CancelEventArgs(False))
            AddHandler cmbThrowinWP.Validating,AddressOf cmbThrowinWP_Validate

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbThrowinWP_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbThrowinWP_Validate
    '機　能：投入装置Validate処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 14:09:04 N.Kojima
    '更新日：2005/03/15 (Tue) 14:09:04
    '備　考：
    Private Sub cmbThrowinWP_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbThrowinWP.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            With cmbThrowinWP
                '@投入装置が選択されている場合
                If .Text <> vbNullString Then
                    '@ｽﾛｯﾄﾏｯﾌﾟを有効に
                    If vsfUnCarryList.Enabled = True Then
                        '@次項目にﾌｫｰｶｽｾｯﾄ
                        If ActiveControl.Name = cmbThrowinWP.Name Then
                            Call pubSetFocus(vsfUnCarryList)
                        End If
                    Else
                        '@最新取得ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        If ActiveControl.Name = cmbThrowinWP.Name Then
                            Call pubSetFocus(cmdLotSearch)
                        End If
                    End If
                End If
            End With
            
            '@投入装置が選択されていて、ｸﾞﾘｯﾄﾞも選択されている場合
            If cmbThrowinWP.Text <> vbNullString And vsfUnCarryList.Row > 0 Then
                '@強制移載ﾎﾞﾀﾝを有効に
                cmdProcEnd.Enabled = True
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbThrowinWP_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2005/03/14 (Mon) 16:20:36 N.Kojima **************************************************


    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/25 (Mon) 14:41:25 N.Kasai
    '更新日：2004/11/01 (Mon) 15:33:54 T.Kitagawa
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        
        Dim llngRet As Integer
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
            llngRet = publngEnd_Proc(CPstrKeyEN01H0, ltypCommonInfo)

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

    '関数名：cmdProcEnd_Click
    '機　能：確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/22 (Fri) 17:53:19 N.Kasai
    '更新日：2005/04/01 (Fri) 08:58:01 N.Kojima
    '備　考：2005/03/16 (Wed) 09:58:37 N.Kojima     投入装置追加に伴う修正(改善№577)
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    Private Sub cmdProcEnd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdProcEnd.Click
        
        Dim lblnAns                 As Boolean          '登録戻り値(True/False)
        Dim lstrFormName            As String           'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypForcedMove          As Forcedmove       '投入移載要求格納構造体
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
            
            '@投入装置ﾁｪｯｸ
            If cmbThrowinWP.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005F)
                '@"投入装置が選択されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@投入装置ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmbThrowinWP)
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
            lstrEventName = "cmdProcEnd_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@更新内容の設定
            With ltypForcedMove
                .strMsgVer = CMstrlot_forcedmoveVer                                                         'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strSbID = pstrSBID                                                                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strLotID = vsfUnCarryList.GetData(vsfUnCarryList.Row, CMlngvsfListColLotID)       'ﾛｯﾄID
                .strCarrierId = vbNullString                                                                'ｷｬﾘｱID(成功時表示ﾒｯｾｰｼﾞ用)
                .strEmpID = pstrUserID                                                                      '作業者ID
                .strWpID = cmbThrowinWP.Value                                                               '装置ID
            End With
            
            '@投入移載処理
            lblnAns = pubblnForcedMove_Upd(ltypForcedMove, lstrGuidMsg, lstrGuidMsgCode)
            
            '@結果判定
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
                
                '@ﾒｯｾｰｼﾞ表示"<TRM07I>$$ロット[%2]を投入しました。キャリア[%1]"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0007, ltypForcedMove.strCarrierId, ltypForcedMove.strLotID)
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                '@確定後の最新を取得する。
                Call cmdLotSearch_Click(sender,e)
                
                If vsfUnCarryList.Rows.Count > vsfUnCarryList.Rows.Fixed Then
                    '@該当件数あり
                    Call pubSetFocus(vsfUnCarryList)
                Else
                    '@該当件数なし
                    '@構造体の初期化(ｿｰﾄ用)
                    With mtypChgSort
                        '@ｿｰﾄ保持構造体初期化
                        .lngCnt = 0
                        .typChgSortList = New List(Of ChgSortList)
                        '@列幅変更ﾌﾗｸﾞ(未変更)
                        .blnChgWidth = False
                        '@ｶﾚﾝﾄ行検索ｷｰを初期化
                        .strKey = vbNullString
                    End With
                End If
                
                '@確定ﾎﾞﾀﾝ使用不可
                cmdProcEnd.Enabled = False
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                '@異常の場合終了
                Exit Sub
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdProcEnd_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLeft_Click
    '機　能：左ｽｸﾛｰﾙﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/25 (Mon) 14:39:25 N.Kasai
    '更新日：2007/07/06 (Fri) 13:36:10 N.Kasai
    '備　考：
    '　　　：2007/07/06 (Fri) 13:36:10 N.Kasai  ｸﾞﾘｯﾄﾞ機能共通化
    Private Sub cmdLeft_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLeft.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2007/07/06 (Fri) 13:36:08 N.Kasai **************************************************
            '@左ｽｸﾛｰﾙﾎﾞﾀﾝ制御
            Call pubVsfCmdLeft(vsfUnCarryList, cmdLeft, cmdRight)
        '@↑2007/07/06 (Fri) 13:36:08 N.Kasai **************************************************

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
    '機　能：右ｽｸﾛｰﾙﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/25 (Mon) 14:39:34 N.Kasai
    '更新日：2007/07/06 (Fri) 13:35:25 N.Kasai
    '備　考：
    '　　　：2007/07/06 (Fri) 13:35:25 N.Kasai  ｸﾞﾘｯﾄﾞ機能共通化
    Private Sub cmdRight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRight.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2007/07/06 (Fri) 13:36:35 N.Kasai **************************************************
            '@右ｽｸﾛｰﾙﾎﾞﾀﾝ処理
            Call pubVsfCmdRight(vsfUnCarryList, cmdLeft, cmdRight)
        '@↑2007/07/06 (Fri) 13:36:35 N.Kasai **************************************************

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

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｸｴﾘｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：ﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/10/25 (Mon) 14:43:53 N.Kasai
    '更新日：2004/11/01 (Mon) 15:34:15 T.Kitagawa
    '備　考：2004/11/01 (Mon) 15:34:15 T.Kitagawa　閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose,e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@配列の解放(ｿｰﾄ用)
            mtypChgSort.typChgSortList = New List(Of ChgSortList)
            
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

    '関数名：vsfUnCarryList_AfterUserResize
    '機　能：ｸﾞﾘﾄﾞｻｲｽﾞ変更
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2004/10/25 (Mon) 14:45:30 N.Kasai
    '更新日：2007/07/09 (Mon) 15:29:12 N.Kasai
    '備　考：
    '　　　：2007/07/09 (Mon) 15:29:12 N.Kasai  ｸﾞﾘｯﾄﾞ共通
    Private Sub vsfUnCarryList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfUnCarryList.AfterResizeColumn, vsfUnCarryList.AfterResizeRow

    '    Dim llngCnt         As Long 'ｶｳﾝﾄ
    '    Dim llngWidthAll    As Long 'ｸﾞﾘｯﾄﾞ幅

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfUnCarryList.Rows.Count <= vsfUnCarryList.Rows.Fixed Then
                Return
            End If
            
            '@列幅変更フラグ(変更)
            mtypChgSort.blnChgWidth = True
            
        '@↓2007/07/09 (Mon) 15:29:09 N.Kasai **************************************************
            '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
            Call pubCmdLREnable_Set(vsfUnCarryList, cmdLeft, cmdRight)
            
            
        '    With vsfUnCarryList
        '        '@全列数の幅取得(非表示項目は含めない)
        '        For llngCnt = 0 To .Cols - 1
        '            '@非表示列ではない場合
        '            If .ColHidden(llngCnt) <> True Then
        '                llngWidthAll = llngWidthAll + .ColWidth(llngCnt)
        '            End If
        '        Next llngCnt
        '
        '        '@ｸﾞﾘｯﾄﾞ幅と比較して横ｽｸﾛｰﾙﾎﾞﾀﾝを活性化するか判断
        '        If .Width - llngWidthAll >= 0 Then
        '            '@ｽｸﾛｰﾙﾌﾗｸﾞ(=2:非活性化)
        '            mlngSideScrollFlag = CMlngSideScrollOffFlag
        '
        '            '@右ｽｸﾛｰﾙ非活性化
        '            cmdRight.Enabled = False
        '        Else
        '            '@ｽｸﾛｰﾙﾌﾗｸﾞ(=1:活性化)
        '            mlngSideScrollFlag = CMlngSideScrollOnFlag
        '
        '            '@右ｽｸﾛｰﾙ活性化
        '            cmdRight.Enabled = True
        '        End If
        '    End With
        '@↑2007/07/09 (Mon) 15:29:09 N.Kasai **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfUnCarryList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfUnCarryList_BeforeRowColChange
    '機　能：行列変更前処理
    '引　数：OldRow：旧行番号
    '　　　：OldCol：旧列番号
    '　　　：NewRow：新行番号
    '　　　：NewCol：新列番号
    '　　　：Cancel：ｷｬﾝｾﾙt値
    '戻り値：なし
    '作成日：2004/10/25 (Mon) 14:47:09 N.Kasai
    '更新日：2004/10/25 (Mon) 14:47:09 N.Kasai
    '備　考：
    Private Sub vsfUnCarryList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfUnCarryList.BeforeRowColChange
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfUnCarryList.Rows.Count <= vsfUnCarryList.Rows.Fixed Then
                Return
            End If
            
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ﾛｯﾄID)
                mtypChgSort.strKey = vsfUnCarryList.GetData(e.NewRange.r1, CMlngvsfListColLotID)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfUnCarryList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLotSearch_Click
    '機　能：投入移載ﾛｯﾄﾘｽﾄ取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/22 (Fri) 14:23:03 N.Kasai
    '更新日：2004/10/22 (Fri) 14:23:03 N.Kasai
    '備　考：
    Private Sub cmdLotSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotSearch.Click

        Dim lblnAns             As Boolean      '戻り値
        Dim lstrFormName        As String       'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String       'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypUnCarryList     As UnCarryList  '投入移載ﾛｯﾄ一覧格納用構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "cmdLotSearch_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@情報取得日時初期化
            lblNowDate.Text = vbNullString
            '@該当件数ｸﾘｱ
            lblLotCnt.Text = vbNullString
            
            '@ｸﾞﾘｯﾄﾞ表示の初期化
            'Call prvvsfUnCarryList_init()

            '@投入予定ﾛｯﾄ一覧取得結果
            lblnAns = pubblnUnCarryList_Sel(CMstrlot_uncarrylist_Ver, pstrSBID, ltypUnCarryList)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Exit Sub
            End If
            
            '@投入移載ﾛｯﾄ一覧表示
            Call prvvsfUnCarryList_Disp(ltypUnCarryList,sender.Name)
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLotSearch_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：上ｽｸﾛｰﾙﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/25 (Mon) 14:48:42 N.Kasai
    '更新日：2004/10/25 (Mon) 14:48:42 N.Kasai
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

            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdUp(vsfUnCarryList, cmdUP, cmdDown)
            
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
    '機　能：下ｽｸﾛｰﾙﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/25 (Mon) 14:49:18 N.Kasai
    '更新日：2004/10/25 (Mon) 14:49:18 N.Kasai
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
            
            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdDown(vsfUnCarryList, cmdUP, cmdDown)
            
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

    '関数名：Form_KeyDown
    '機　能：ｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ値
    '戻り値：なし
    '作成日：2004/10/25 (Mon) 14:49:47 N.Kasai
    '更新日：2007/07/06 (Fri) 13:37:46 N.Kasai
    '備　考：2005/03/23 (Wed) 13:01:01 N.Kojima     投入装置追加に伴い、投入装置の場合でのｷｰ処理追加(改善№577)
    '　　　：2007/07/06 (Fri) 13:37:46 N.Kasai      ｸﾞﾘｯﾄﾞ機能共通化
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            '@ｸﾞﾘｯﾄﾞｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfUnCarryList, cmdUP, cmdDown)
            
        '@↓2007/07/06 (Fri) 13:37:42 N.Kasai **************************************************
            '@ｸﾞﾘｯﾄﾞｷｰ制御(ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、左ﾎﾞﾀﾝ、右ﾎﾞﾀﾝ)
            Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfUnCarryList, cmdLeft, cmdRight)
        '@↑2007/07/06 (Fri) 13:37:42 N.Kasai **************************************************


        '@↓2005/03/23 (Wed) 13:02:14 N.Kojima **************************************************
            '@確定ﾎﾞﾀﾝが非表示の場合
            If cmdProcEnd.Enabled = False Then
                '@Enterｷｰの場合
                Select Case e.KeyCode
                    Case Keys.Return
                        Select Case ActiveControl.Name
                            Case cmbThrowinWP.Name
                            '@投入装置の場合
                                '@投入装置のValidate処理を呼ぶ
                                RemoveHandler cmbThrowinWP.Validating,AddressOf cmbThrowinWP_Validate
                                Call cmbThrowinWP_Validate(sender,New CancelEventArgs(False))
                                AddHandler cmbThrowinWP.Validating,AddressOf cmbThrowinWP_Validate
                                e.Handled = True
                            Case Else
                            '@その他
                                SendKeys.SendWait(CPstrSendKeysTab)
                                e.Handled = True
                        End Select
                End Select
            Else
                '@Enterｷｰの場合
                Select Case e.KeyCode
                    Case Keys.Return
                        Select Case ActiveControl.Name
                            Case vsfUnCarryList.Name
                            '@一覧にﾌｫｰｶｽがある場合
                                '@ﾃﾞｰﾀ行の場合
                                If vsfUnCarryList.Row >= vsfUnCarryList.Rows.Fixed Then
                                    '@確定処理
                                    Call cmdProcEnd_Click(sender,e)
                                End If
                            Case cmbThrowinWP.Name
                            '@投入装置の場合
                                '@投入装置のValidate処理を呼ぶ
                                RemoveHandler cmbThrowinWP.Validating,AddressOf cmbThrowinWP_Validate
                                Call cmbThrowinWP_Validate(sender,New CancelEventArgs(False))
                                AddHandler cmbThrowinWP.Validating,AddressOf cmbThrowinWP_Validate
                                e.Handled = True
                            Case Else
                            '@その他
                                SendKeys.SendWait(CPstrSendKeysTab)
                                e.Handled = True
                        End Select
                    Case Else
                        '@処理を抜ける
                End Select
            End If
        '@↑2005/03/23 (Wed) 13:02:14 N.Kojima **************************************************

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

    '関数名：vsfUnCarryList_BeforeSort
    '機　能：ソート前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/10/25 (Mon) 14:50:57 N.Kasai
    '更新日：2004/10/25 (Mon) 14:50:57 N.Kasai
    '備　考：
    Private Sub vsfUnCarryList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfUnCarryList.BeforeSort

        Try
            'NSYS 不要なHandler処理を抑止
            RemoveHandler vsfUnCarryList.BeforeRowColChange, AddressOf vsfUnCarryList_BeforeRowColChange
            RemoveHandler vsfUnCarryList.EnterCell, AddressOf vsfUnCarryList_EnterCell
            vsfUnCarryListRowBeforeSort = vsfUnCarryList.Row

            'NSYS データ行がない場合は処理を抜ける
            If vsfUnCarryList.Rows.Count <= vsfUnCarryList.Rows.Fixed Then
                Return
            End If

            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列 [№] )
            Call pubVsfBeforeSort(vsfUnCarryList, CMlngvsfListColNo)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfUnCarryList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfUnCarryList_AfterSort
    '機　能：ソート後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/10/25 (Mon) 14:51:30 N.Kasai
    '更新日：2004/10/25 (Mon) 14:51:30 N.Kasai
    '備　考：
    Private Sub vsfUnCarryList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfUnCarryList.AfterSort

        Try
            'BeforeSortで除外していたRowColChangeイベントを復帰
            AddHandler vsfUnCarryList.BeforeRowColChange, AddressOf vsfUnCarryList_BeforeRowColChange
            AddHandler vsfUnCarryList.EnterCell, AddressOf vsfUnCarryList_EnterCell

            'NSYS ソート前の選択行が有効行でない場合、ヘッダを選択行とする
            If vsfUnCarryListRowBeforeSort <  vsfUnCarryList.Rows.Fixed Then
                vsfUnCarryList.Row = 0
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfUnCarryList.Rows.Count <= vsfUnCarryList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ順を格納
            With mtypChgSort
                .lngCnt = .lngCnt + 1                       'ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                Dim typChgSortListTmp As ChgSortList        '配列定義
                typChgSortListTmp.lngCol = e.Col            'ｿｰﾄ列番号を格納
                typChgSortListTmp.lngOrder = e.Order        '並び替え方法を格納(昇順/降順)
                .typChgSortList.Add(typChgSortListTmp)
            End With

            '@ｶﾚﾝﾄ行の設定(ｸﾞﾘｯﾄﾞ、保持列 [№]、前頁、次頁 )
            Call pubVsfAfterSort(vsfUnCarryList, CMlngvsfListColNo, cmdUP, cmdDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfUnCarryList_AfterSort"
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

    '関数名：prvvsfUnCarryList_init
    '機　能：vsfUnCarryListの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/25 (Mon) 14:52:06 N.Kasai
    '更新日：2008/06/11 (Wed) 15:44:25 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 15:44:25 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvvsfUnCarryList_init()

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfUnCarryList

                RemoveHandler vsfUnCarryList.BeforeRowColChange,AddressOf vsfUnCarryList_BeforeRowColChange
                RemoveHandler vsfUnCarryList.EnterCell,AddressOf vsfUnCarryList_EnterCell
                '@ｸﾞﾘｯﾄﾞの行設定
                .Rows.Count = CMlngvsfUnCarryListTRow + 1
                '@ｸﾞﾘｯﾄﾞの列設定
                .Cols.Count = CMlngvsfListCols
                'NSYS ヘッダーを明示的に選択
                .Row = 0
                AddHandler vsfUnCarryList.BeforeRowColChange,AddressOf vsfUnCarryList_BeforeRowColChange
                AddHandler vsfUnCarryList.EnterCell,AddressOf vsfUnCarryList_EnterCell
                '@投入日を日付ﾀｲﾌﾟに設定
                '.Cols(CMlngvsfListColThrowinDate).DataType = GetType(flexDTDate)
                
                '@ｸﾞﾘｯﾄﾞ設定
                '.AllowBigSelection = False              'ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '.AllowSelection = False                 'ﾏｳｽでｾﾙ範囲選択不可
                .SelectionMode = SelectionModeEnum.Row  '行選択
                '.FillStyle = flexFillRepeat             'ﾌﾟﾛﾊﾟﾃｨの設定対象(選択ｾﾙ)
                .FocusRect = FocusRectEnum.Light        'ｶﾚﾝﾄｾﾙのﾌｫｰｶｽ枠(細い枠)
                .ScrollBars = ScrollBars.None           'ｽｸﾛｰﾙﾊﾞｰ(なし)
                '.AutoSizeMode = flexAutoSizeColWidth    'ｵｰﾄｻｲｽﾞ(列)
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter  '文字列の最後に省略符号
                .Styles.Fixed.Trimming = StringTrimming.None
                .AllowResizing = AllowResizingEnum.Columns                  '列幅の変更許可
                .ExtendLastCol = True                   '右端の列をｸﾞﾘｯﾄﾞに合わせる
                
                '@一覧表の表題設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_vsfUseTpalList_Header")
                Dim cellRange As CellRange = .GetCellRange(CMlngvsfUnCarryListTRow, CMlngvsfListColNo, CMlngvsfUnCarryListTRow, .Cols.Count - 1)
                newStyle.TextAlign = TextAlignEnum.CenterCenter                 '中央表示
                newStyle.ForeColor = Color.Yellow                               '文字色(黄色)
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)  '背景色(紺色)
                newStyle.Font = New Font(.Font.FontFamily, CMlngvsfUnCarryListHFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont) 'ﾌｫﾝﾄｻｲｽﾞ
                cellRange.Style = newStyle

                .Rows(CMlngvsfUnCarryListTRow).Height = CMlngvsfUnCarryListHdHeight                         'ﾍｯﾀﾞｰの高さを設定
                
                '@列幅設定
                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    .Cols(CMlngvsfListColNo).Width = CMlngvsfListColWNo
                    .Cols(CMlngvsfListColThrowinDate).Width = CMlngvsfListColWThrowinDate
                    .Cols(CMlngvsfListColPdID).Width = CMlngvsfListColWPdID
                    .Cols(CMlngvsfListColPdName).Width = CMlngvsfListColWPdName
                    .Cols(CMlngvsfListColLotID).Width = CMlngvsfListColWLotID
                    .Cols(CMlngvsfListColFlowClass).Width = CMlngvsfListColWFlowClass
                    .Cols(CMlngvsfListColFlowClassName).Width = CMlngvsfListColWFlowClassName
                    .Cols(CMlngvsfListColCarrirID).Width = CMlngvsfListColWCarrierID
                    .Cols(CMlngvsfListColWfNum).Width = CMlngvsfListColWWfNum
                    .Cols(CMlngvsfListColProductionLotID).Width = CMlngvsfListColWProductionLotID
                    .Cols(CMlngvsfListColLotManagerID).Width = CMlngvsfListColWLotManagerID
                    .Cols(CMlngvsfListColLotManagerName).Width = CMlngvsfListColWLotManagerName
                End If
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfUnCarryListTRow, CMlngvsfListColNo, CMstrvsfListColTNo)
                .SetData(CMlngvsfUnCarryListTRow, CMlngvsfListColThrowinDate, CMstrvsfListColTThrowinDate)
                .SetData(CMlngvsfUnCarryListTRow, CMlngvsfListColPdID, CMstrvsfListColTPdID)
                .SetData(CMlngvsfUnCarryListTRow, CMlngvsfListColPdName, CMstrvsfListColTPdName)
                .SetData(CMlngvsfUnCarryListTRow, CMlngvsfListColLotID, CMstrvsfListColTLotID)
                .SetData(CMlngvsfUnCarryListTRow, CMlngvsfListColFlowClass, CMstrvsfListColTFlowClass)
                .SetData(CMlngvsfUnCarryListTRow, CMlngvsfListColFlowClassName, CMstrvsfListColTFlowClassName)
                .SetData(CMlngvsfUnCarryListTRow, CMlngvsfListColCarrirID, CMstrvsfListColTCarrirID)
                .SetData(CMlngvsfUnCarryListTRow, CMlngvsfListColWfNum, CMstrvsfListColTWfNum)
                .SetData(CMlngvsfUnCarryListTRow, CMlngvsfListColProductionLotID, CMstrvsfListColTProductionLotID)
                .SetData(CMlngvsfUnCarryListTRow, CMlngvsfListColLotManagerID, CMstrvsfListColTLotManagerID)
                .SetData(CMlngvsfUnCarryListTRow, CMlngvsfListColLotManagerName, CMstrvsfListColTLotManagerName)

                '@非表示列設定
                .Cols(CMlngvsfListColPdName).Visible = False                                                '機種ID
                .Cols(CMlngvsfListColFlowClassName).Visible = False                                         '種別ID
                .Cols(CMlngvsfListColLotManagerID).Visible = False                                          'ﾛｯﾄ担当者ID

                '@表示ﾌｫｰﾏｯﾄ
                .Cols(CMlngvsfListColThrowinDate).TextAlign = TextAlignEnum.LeftCenter                      '投入確定日(左中央寄せ)
                .Cols(CMlngvsfListColPdID).TextAlign = TextAlignEnum.LeftCenter                             '機種 (左中央寄せ)
                .Cols(CMlngvsfListColLotID).TextAlign = TextAlignEnum.LeftCenter                            'ﾛｯﾄID(左中央寄せ)
                .Cols(CMlngvsfListColFlowClass).TextAlign = TextAlignEnum.LeftCenter                        '種別 (左中央寄せ)
                .Cols(CMlngvsfListColCarrirID).TextAlign = TextAlignEnum.LeftCenter                         'ｷｬﾘｱID(左中央寄せ)
                .Cols(CMlngvsfListColWfNum).TextAlign = TextAlignEnum.RightCenter                           'WF枚数(右中央寄せ)
                .Cols(CMlngvsfListColProductionLotID).TextAlign = TextAlignEnum.LeftCenter                  '製造ﾛｯﾄID(左中央寄せ)
                .Cols(CMlngvsfListColLotManagerName).TextAlign = TextAlignEnum.LeftCenter                   'ﾛｯﾄ担当(左中央寄せ)
                
                '@ﾊﾞｯﾌｧ経由で描画
                '.Redraw = flexRDBuffered
                
                '@ﾛｯｸ
                .Enabled = False
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfUnCarryList_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvMainForm_Init
    '機　能：画面初期設定
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/22 (Fri) 14:16:39 N.Kasai
    '更新日：2004/10/22 (Fri) 14:16:39 N.Kasai
    '備　考：
    Private Sub prvMainForm_Init()

        Dim lstrFormTitle           As String   'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN01H0, lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            '@情報取得日時初期化
            lblNowDate.Text = vbNullString
            '@該当件数ｸﾘｱ
            lblLotCnt.Text = vbNullString
            
            '@使用不可
            cmdUP.Enabled = False                               '前ﾍﾟｰｼﾞ
            cmdDown.Enabled = False                             '次ﾍﾟｰｼﾞ
            cmdLeft.Enabled = False                             '左ﾎﾞﾀﾝ
            cmdRight.Enabled = False                            '右ﾎﾞﾀﾝ
            cmdProcEnd.Enabled = False                          '確定ﾎﾞﾀﾝ
            
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

    '関数名：prvvsfUnCarryList_Disp
    '機　能：投入移載ﾛｯﾄ一覧表示
    '引　数：ltypUnCarryList：投入移載ﾛｯﾄ応答格納用構造体
    '戻り値：なし
    '作成日：2004/10/25 (Mon) 15:19:46 N.Kasai
    '更新日：2008/06/11 (Wed) 15:45:32 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 15:45:32 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvvsfUnCarryList_Disp(ByRef ltypUnCarryList As UnCarryList,Optional ByVal lstrSenderName As String = Nothing)

        Dim llngDoCnt               As Integer  'Doの回数ｶｳﾝﾄ(Lotlist)
        Dim llngDoCnt2              As Integer  'Doの回数ｶｳﾝﾄ(Partist)
        Dim lstrProductionLotID     As String   '製造ﾛｯﾄID文字結合用変数
        Dim llngPartListCnt         As Integer  'PartList最大ｶｳﾝﾄ数格納
        Dim llngCnt                 As Integer  '汎用ｶｳﾝﾄ(ｿｰﾄ用に使用)
        Dim llngSelectedRow         As Integer  'NSYS メソッド呼び出し前に選択していたRow

        Try
            
            '@一覧表示
            With vsfUnCarryList
            
                '再描画抑止
                .Redraw = False

                '選択行退避
                llngSelectedRow = .Row
            
                '@行数設定
                RemoveHandler vsfUnCarryList.BeforeRowColChange,AddressOf vsfUnCarryList_BeforeRowColChange
                RemoveHandler vsfUnCarryList.EnterCell,AddressOf vsfUnCarryList_EnterCell
                .Rows.Count = .Rows.Fixed
                .Rows.Count = ltypUnCarryList.llngUnCarryListcnt + 1
                'NSYS 強制移載ボタンからCallされた場合はヘッダーを選択する
                If lstrSenderName = cmdProcEnd.Name Then
                    .Row = 0
                Else
                    .Row = llngSelectedRow
                End If
                AddHandler vsfUnCarryList.BeforeRowColChange,AddressOf vsfUnCarryList_BeforeRowColChange
                AddHandler vsfUnCarryList.EnterCell,AddressOf vsfUnCarryList_EnterCell
                
                '@ｶｳﾝﾀの初期化
                llngDoCnt = 1
                
                '@ﾛｯﾄ一覧表示情報設定
                Do While .Rows.Count > llngDoCnt
                    '投入確定日
                    If IsDate(ltypUnCarryList.typUnCarry(llngDoCnt - 1).strThowinDate) Then
                        .SetData(llngDoCnt, CMlngvsfListColThrowinDate, Format(CDate(ltypUnCarryList.typUnCarry(llngDoCnt - 1).strThowinDate),CPstrDateTimeYMD))
                    Else
                        .SetData(llngDoCnt, CMlngvsfListColThrowinDate,ltypUnCarryList.typUnCarry(llngDoCnt - 1).strThowinDate)
                    End If
                    .SetData(llngDoCnt, CMlngvsfListColPdID, ltypUnCarryList.typUnCarry(llngDoCnt - 1).strPdId)                           '機種ID
                    .SetData(llngDoCnt, CMlngvsfListColPdName, ltypUnCarryList.typUnCarry(llngDoCnt - 1).strPdName)                       '機種(和名)
                    .SetData(llngDoCnt, CMlngvsfListColLotID, ltypUnCarryList.typUnCarry(llngDoCnt - 1).strLotID)                         'ﾛｯﾄID
                    .SetData(llngDoCnt, CMlngvsfListColFlowClass, ltypUnCarryList.typUnCarry(llngDoCnt - 1).strFlowClass)                 '種別
                    .SetData(llngDoCnt, CMlngvsfListColFlowClassName, ltypUnCarryList.typUnCarry(llngDoCnt - 1).strFlowClassName)         '種別(和名)
                    .SetData(llngDoCnt, CMlngvsfListColCarrirID, ltypUnCarryList.typUnCarry(llngDoCnt - 1).strCarrierId)                  'ｷｬﾘｱID
                    .SetData(llngDoCnt, CMlngvsfListColWfNum, ltypUnCarryList.typUnCarry(llngDoCnt - 1).strWfNum)                         'WF枚数
                    .SetData(llngDoCnt, CMlngvsfListColLotManagerName, ltypUnCarryList.typUnCarry(llngDoCnt - 1).strEngEmpName)           'ﾛｯﾄ担当者名
                    .SetData(llngDoCnt, CMlngvsfListColLotManagerID, ltypUnCarryList.typUnCarry(llngDoCnt - 1).strEngEmpId)               'ﾛｯﾄ担当者ID
                    
                    '@Partlistの最大ｶｳﾝﾄを判定
                    If ltypUnCarryList.typUnCarry(llngDoCnt - 1).llngCarryPartListcnt > 0 Then
                        '@件数あり
                        '@PARTﾘｽﾄｶｳﾝﾄ格納
                        llngPartListCnt = ltypUnCarryList.typUnCarry(llngDoCnt - 1).llngCarryPartListcnt
                        '@文字結合変数初期化
                        lstrProductionLotID = vbNullString
                        '@ｶｳﾝﾀ初期化
                        llngDoCnt2 = 1
                        '@製造ﾛｯﾄ格納
                        'Do While llngPartListCnt > llngDoCnt2
                        For llngDoCnt2  = 0 To llngPartListCnt - 1
                            '@1件目は空白をｾｯﾄしない
                            If llngDoCnt2 = 0 Then
                                lstrProductionLotID = lstrProductionLotID & _
                                                    ltypUnCarryList.typUnCarry(llngDoCnt - 1).typUnCarryPartList(llngDoCnt2).strProductionLotId     '製造ﾛｯﾄID
                            Else
                                lstrProductionLotID = lstrProductionLotID & CPstrSpace & _
                                                    ltypUnCarryList.typUnCarry(llngDoCnt - 1).typUnCarryPartList(llngDoCnt2).strProductionLotId     '製造ﾛｯﾄID
                            End If
                            'llngDoCnt2 = llngDoCnt2 + 1
                        Next
                        .SetData(llngDoCnt, CMlngvsfListColProductionLotID, lstrProductionLotID)
                    Else
                        '@件数なし
                        .SetData(llngDoCnt, CMlngvsfListColProductionLotID, vbNullString)
                    End If
                                
                    '@スロットの高さの設定
                    .Rows(llngDoCnt).Height = CMlngvsfUnCarryListHeight
                    llngDoCnt = llngDoCnt + 1
                Loop

                '@№設定
                For llngDoCnt = 1 To .Rows.Count - 1
                    .SetData(llngDoCnt, CMlngvsfListColNo, llngDoCnt)
                Next llngDoCnt
                
                '@ｵｰﾄ幅設定
                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    '.AutoSizeMode = flexAutoSizeColWidth
                    .AutoSizeCols(CMlngvsfListColNo, .Cols.Count - 1, 6)
                End If

                '@ﾕｰｻﾞによりｿｰﾄされている場合
                If mtypChgSort.lngCnt > 0 Then
                    '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                    For llngCnt = 0 To mtypChgSort.lngCnt - 1
                        '@該当行をｿｰﾄ
                        RemoveHandler vsfUnCarryList.BeforeRowColChange,AddressOf vsfUnCarryList_BeforeRowColChange
                        RemoveHandler vsfUnCarryList.EnterCell,AddressOf vsfUnCarryList_EnterCell
                        .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder,mtypChgSort.typChgSortList(llngCnt).lngCol)
                        AddHandler vsfUnCarryList.BeforeRowColChange,AddressOf vsfUnCarryList_BeforeRowColChange
                        AddHandler vsfUnCarryList.EnterCell,AddressOf vsfUnCarryList_EnterCell
                    Next llngCnt
                End If
                
                '@ｿｰﾄ検索用ｷｰがある場合
                If mtypChgSort.strKey <> vbNullString Then
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@投入予定日とﾛｯﾄIDが同じ場合
                        If .GetData(llngCnt, CMlngvsfListColLotID) = mtypChgSort.strKey Then
                            .Row = llngCnt
                            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列 )
                            Call pubVsfBeforeSort(vsfUnCarryList, CMlngvsfListColNo)
                            '@ｶﾚﾝﾄ行の設定(ｸﾞﾘｯﾄﾞ、保持列 、前頁、次頁 )
                            Call pubVsfAfterSort(vsfUnCarryList, CMlngvsfListColNo, cmdUP, cmdDown,,,,False,)
                            Exit For
                        End If
                    Next llngCnt
                Else
                    '@ｶﾚﾝﾄ行初期化
                    RemoveHandler vsfUnCarryList.BeforeRowColChange,AddressOf vsfUnCarryList_BeforeRowColChange
                    RemoveHandler vsfUnCarryList.EnterCell,AddressOf vsfUnCarryList_EnterCell
                    .Row = .Rows.Fixed - 1
                    .TopRow = .Rows.Fixed
                    AddHandler vsfUnCarryList.BeforeRowColChange,AddressOf vsfUnCarryList_BeforeRowColChange
                    AddHandler vsfUnCarryList.EnterCell,AddressOf vsfUnCarryList_EnterCell
                End If
                
                'NSYS 再描画実行
                .Redraw = True
                
                '@左右ｽｸﾛｰﾙ制御の記述
                '@ｶﾚﾝﾄ列初期化
                .Col = .Cols.Fixed
                .LeftCol = .Cols.Fixed
                
        '@↓2007/07/09 (Mon) 15:30:19 N.Kasai **************************************************
        '        '@全列数の幅取得(非表示項目は含めない)
        '        For llngDoCnt = 0 To .Cols - 1
        '            If .ColHidden(llngDoCnt) <> True Then
        '                llngWidthAll = llngWidthAll + .ColWidth(llngDoCnt)
        '            End If
        '        Next llngDoCnt
        '        '@ｸﾞﾘｯﾄﾞ幅と比較して横ｽｸﾛｰﾙﾎﾞﾀﾝを活性化するか判断
        '        If .Width - llngWidthAll >= 0 Then
        '            '@ｽｸﾛｰﾙﾌﾗｸﾞ(=2:非活性化)
        '            mlngSideScrollFlag = CMlngSideScrollOffFlag
        '
        '            '@右ｽｸﾛｰﾙ非活性化
        '            cmdRight.Enabled = False
        '        Else
        '            '@ｽｸﾛｰﾙﾌﾗｸﾞ(=1:活性化)
        '            mlngSideScrollFlag = CMlngSideScrollOnFlag
        '
        '            '@右ｽｸﾛｰﾙ活性化
        '            cmdRight.Enabled = True
        '        End If

                '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
                Call pubCmdLREnable_Set(vsfUnCarryList, cmdLeft, cmdRight)
        '@↑2007/07/09 (Mon) 15:30:19 N.Kasai **************************************************

                '@前ﾍﾟｰｼﾞ、次ﾍﾟｰｼﾞ、ｽｸﾛｰﾙﾗﾍﾞﾙ表示設定
                If .Rows.Count > 1 Then
                    cmdUP.Enabled = True
                    cmdDown.Enabled = True

                    '@ｸﾞﾘｯﾄﾞﾎﾞﾀﾝ制御、保持値ｸﾘｱ
                    Call pubVsfDisp(vsfUnCarryList, cmdUP, cmdDown)
                Else
                    cmdUP.Enabled = False
                    cmdDown.Enabled = False
                End If
                
                
                 If .Rows.Count > .Rows.Fixed Then
                    '@該当件数設定
                    lblLotCnt.Text = Format$(.Rows.Count - 1, CPstrDateFormatKanma)
                    '@ﾛｯｸ解除
                    .Enabled = True
                Else
                    '@該当ﾃﾞｰﾀが存在しない場合
                    lblLotCnt.Text = 0
                    '@ﾛｯｸ
                    .Enabled = False
                End If
                
                '@情報取得日時表示
                lblNowDate.Text = Format$(Now(), CPstrDateFormat)
            
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfUnCarryList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfUnCarryList_EnterCell
    '機　能：ｸﾞﾘｯﾄﾞﾌｫｰｶｽ移動
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/22 (Fri) 18:54:56 N.Kasai
    '更新日：2005/03/16 (Wed) 14:34:02 N.Kojima
    '備　考：2005/03/16 (Wed) 14:34:02 N.Kojima     投入装置追加に伴う修正(改善№577)
    Private Sub vsfUnCarryList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfUnCarryList.EnterCell

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfUnCarryList.Rows.Count <= vsfUnCarryList.Rows.Fixed Then
                Return
            End If
            
        '@↓2005/03/16 (Wed) 14:35:57 N.Kojima **************************************************
            '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽがある場合
            If vsfUnCarryList.Row > 0 Then
                '@投入装置が選択されている場合
                If cmbThrowinWP.Text <> vbNullString Then
                    '@確定ﾎﾞﾀﾝ使用可
                    cmdProcEnd.Enabled = True
                Else
                    '@確定ﾎﾞﾀﾝ使用不可
                    cmdProcEnd.Enabled = False
                End If
            End If
        '@↑2005/03/16 (Wed) 14:35:57 N.Kojima **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfUnCarryList_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2005/03/14 (Mon) 16:16:39 N.Kojima **************************************************
    '関数名：prvcmbThrowinWP_Init
    '機　能：投入装置ｺﾝﾎﾞﾎﾞｯｸｽ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/14 (Mon) 16:14:16 N.Kojima
    '更新日：2005/03/14 (Mon) 16:16:30 N.Kojima
    '備　考：
    Private Sub prvcmbThrowinWP_Init()

        Try

            '@ｺﾝﾎﾞﾎﾞｯｸｽ設定
            With cmbThrowinWP
                .Clear
                .DispCols = CMlngCmbDispCols1                                       'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridCol0                                          'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridCol1                                        '値取得列
                .DirectInput = False                                                'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, _
                                                   .Font.Style, .Font.Unit)         'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _
                                                  .GridFont.Style, .GridFont.Unit)  'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                      '行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter          '左中央
                .BackColor = SystemColors.Window                                    'NSYS 背景色(白)
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbThrowinWP_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbThrowinWP_Disp
    '機　能：投入装置をｺﾝﾎﾞへｾｯﾄ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/14 (Mon) 16:15:36 N.Kojima
    '更新日：2005/03/14 (Mon) 16:15:36
    '備　考：
    Private Sub prvcmbThrowinWP_Disp()

        Dim llngCnt                 As Integer  'ｶｳﾝﾄ

        Try
                
                '@投入装置ｾｯﾄ
                With cmbThrowinWP
                    .Clear
                    For llngCnt = 0 To mlngWpListCnt - 1
                        .AddItem(ptypWPList(llngCnt).strWpName & vbTab & ptypWPList(llngCnt).strWpID)
                    Next llngCnt
                    
                    '@装置が1件の場合、ﾃﾞﾌｫﾙﾄ表示
                    If .ListCount = 1 Then
                        '@1件目表示
                        .ListIndex = 0
                    End If
                End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbThrowinWP_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2005/03/14 (Mon) 16:16:39 N.Kojima **************************************************


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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfUnCarryList.BeforeDoubleClick

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
