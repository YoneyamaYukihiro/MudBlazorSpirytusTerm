'ﾌｧｲﾙ名：xxEN02B0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ロット情報一括変更　メインフォーム
'作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
'更新日：2013/01/30 (Wed) 13:55:30 Y.Yoneyama
'備　考：
'　　　：2011/04/26 (Tue) 11:12:37 T.Oide       CHR0001319 QUを組立に送品可能にする
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02B0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02B0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02B0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02B0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02B0)
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
    '======================================Private==========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    'Private Const CMstrLocalVersion                     As String = "07.00"
    Private Const CMstrLocalVersion                     As String = "07.01"

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN02B0

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_pdlist__Ver                  As String = "03.00"                 '機種区分一覧取得
    Private Const CMstrmas_flowlistVer                  As String = "04.00"                 '種別区分一覧取得
    Private Const CMstrmas_priolistVer                  As String = "01.00"                 '優先度ﾏｽﾀﾘｽﾄ取得
    Private Const CMstrmas_useoplistVer                 As String = "02.00"                 '大工程ﾏｽﾀ取得
    Private Const CMstrlot_steplistVer                  As String = "03.00"                 '小工程取得
    Private Const CMstrlot_oplotlistVer                 As String = "07.01"                 '大工程ﾛｯﾄ検索一覧
    Private Const CMstrlot_chgattributesVer             As String = "03.01"                 'ﾛｯﾄ情報一括変更

    '@vsfLotListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfLotListColNo                  As Integer = 0                      '№
    Private Const CMlngvsfLotListColCheck               As Integer = 1                      'ﾁｪｯｸﾎﾞｯｸｽ
    Private Const CMlngvsfLotListColPlanShipDate        As Integer = 2                      '送品日
    Private Const CMlngvsfLotListColSendSbName          As Integer = 3                      '送品先
    Private Const CMlngvsfLotListColPlanAssThrowDate    As Integer = 4                      '組立投入日
    Private Const CMlngvsfLotListColShipDiffDay         As Integer = 5                      '進捗度
    Private Const CMlngvsfLotListColLotID               As Integer = 6                      'ﾛｯﾄID
    Private Const CMlngvsfLotListColLotStatus           As Integer = 7                      '状態
    Private Const CMlngvsfLotListColFlowClass           As Integer = 8                      '種別(流動区分)
    Private Const CMlngvsfLotListColPriority            As Integer = 9                      '優先度
    Private Const CMlngvsfLotListColBeforePriority      As Integer = 10                     '変更前優先度
    Private Const CMlngvsfLotListColSecPriorityFlag     As Integer = 11                     '区間優先度ﾌﾗｸﾞ
    Private Const CMlngvsfLotListColPdID                As Integer = 12                     '機種
    Private Const CMlngvsfLotListColWfNum               As Integer = 13                     'WF枚数
    Private Const CMlngvsfLotListColCfNum               As Integer = 14                     'ﾁｯﾌﾟ
    Private Const CMlngvsfLotListColOpID                As Integer = 15                     '大工程
    Private Const CMlngvsfLotListColStepID              As Integer = 16                     '小工程
    Private Const CMlngvsfLotListColPlanFinishDate      As Integer = 17                     '完成予定日
    Private Const CMlngvsfLotListColEditLastUpdate      As Integer = 18                     '(LOT_EVENT_ID=14の)最終更新日時
    Private Const CMlngvsfLotListColEditEmpName         As Integer = 19                     '(LOT_EVENT_ID=14の)最終更新者

    '@vsfLotListの定数宣言(幅)
    Private Const CMlngvsfLotListColWNo                 As Integer = 33                     '№
    Private Const CMlngvsfLotListColWCheck              As Integer = 30                     'ﾁｪｯｸﾎﾞｯｸｽ
    Private Const CMlngvsfLotListColWPlanShipDate       As Integer = 85                     '送品予定日
    Private Const CMlngvsfLotListColWSendSbName         As Integer = 105                    '送品先
    Private Const CMlngvsfLotListColWPlanAssThrowDate   As Integer = 85                     '組立投入日
    Private Const CMlngvsfLotListColWShipDiffDay        As Integer = 54                     '進捗度
    Private Const CMlngvsfLotListColWLotID              As Integer = 90                     'ﾛｯﾄID
    Private Const CMlngvsfLotListColWLotStatus          As Integer = 45                     '状態
    Private Const CMlngvsfLotListColWFlowClass          As Integer = 25                     '種別(流動区分)
    Private Const CMlngvsfLotListColWPriority           As Integer = 25                     '優先度
    Private Const CMlngvsfLotListColWBeforePriority     As Integer = 0                      '変更前優先度
    Private Const CMlngvsfLotListColWSecPriorityFlag    As Integer = 44                     '区間優先度ﾌﾗｸﾞ
    Private Const CMlngvsfLotListColWPdID               As Integer = 53                     '機種
    Private Const CMlngvsfLotListColWWfNum              As Integer = 25                     'WF
    Private Const CMlngvsfLotListColWCfNum              As Integer = 55                     'ﾁｯﾌﾟ
    Private Const CMlngvsfLotListColWOpID               As Integer = 164                    '大工程
    Private Const CMlngvsfLotListColWStepID             As Integer = 164                    '小工程
    Private Const CMlngvsfLotListColWPlanFinishDate     As Integer = 85                     '完成予定日
    Private Const CMlngvsfLotListColWEditLastUpdate     As Integer = 85                     '(LOT_EVENT_ID=14の)最終更新日時
    Private Const CMlngvsfLotListColWEditEmpName        As Integer = 85                     '(LOT_EVENT_ID=14の)最終更新者

    '@vsfLotListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfStepLLColTNo                  As String = "№"
    Private Const CMstrvsfStepLLColTCheck               As String = ""
    Private Const CMstrvsfStepLLColTPlanShipDate        As String = "送品日"
    Private Const CMstrvsfStepLLColTSendSbName          As String = "送品先"
    Private Const CMstrvsfStepLLColTPlanAssThrowDate    As String = "組立投入日"
    Private Const CMstrvsfStepLLColTShipDiffDay         As String = "進捗度"
    Private Const CMstrvsfStepLLColTLotID               As String = "ロットID"
    Private Const CMstrvsfStepLLColTLotStatus           As String = "状態"
    Private Const CMstrvsfStepLLColTFlowClass           As String = "種"
    Private Const CMstrvsfStepLLColTPriority            As String = "優"
    Private Const CMstrvsfStepLLColTBeforePriority      As String = "優(変更前)"
    Private Const CMstrvsfStepLLColTSecPriorityFlag     As String = "区優"
    Private Const CMstrvsfStepLLColTPdID                As String = "機種"
    Private Const CMstrvsfStepLLColTWfNum               As String = "WF"
    Private Const CMstrvsfStepLLColTCfNum               As String = "チップ"
    Private Const CMstrvsfStepLLColTOpID                As String = "大工程"
    Private Const CMstrvsfStepLLColTStepID              As String = "小工程"
    Private Const CMstrvsfStepLLColTPlanFinishDate      As String = "完成予定日"
    Private Const CMstrvsfStepLLColTEditLastUpdate      As String = "最終更新日時"
    Private Const CMstrvsfStepLLColTEditEmpName         As String = "最終更新者"

    '@vsfLotListの定数宣言
    Private Const CMlngvsfStepLLRowTitle                As Integer = 0                      'ﾀｲﾄﾙ行(行)
    Private Const CMlngvsfLotListColTitle               As Integer = 0                      'ﾀｲﾄﾙ行(列)
    Private Const CMlngvsfStepLLHFontSize               As Integer = 11                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfStepLLHHeight                 As Integer = 20                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngvsfStepLLHeight                  As Integer = 16                     '1ｽﾛｯﾄの高さ
    Private Const CMlngvsfFrozenCols                    As Integer = 0                      '固定列数

    '@vsfLotListの定数宣言(処理区分)
    Private Const CMlngMouseClick                       As Integer = 1                      'ﾏｳｽｸﾘｯｸﾌﾗｸﾞ=1
    Private Const CMlngKeyDown                          As Integer = 2                      'ｷｰﾀﾞｳﾝﾌﾗｸﾞ=2
    Private Const CMlngvsfMauseClickEvent               As Integer = 0                      'ﾏｳｽｸﾘｯｸｲﾍﾞﾝﾄ(定義)

    '@色の定数宣言
    Private Const CMlngVbColorWhite                     As Integer = &HFFFFFF               '白色

    '@ｺﾝﾎﾞ用定数
    Private Const CMlngCmbFontSize                      As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColName                   As Integer = 0                      '名称列番
    Private Const CMlngCmbGridColID                     As Integer = 1                      'ID列番(非表示項目)
    Private Const CMlngCmbDispCols                      As Integer = 1                      'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbRowHeight                     As Integer = 18                     'ﾘｽﾄ行の高さ

    '@ｺﾝﾎﾞ一覧用定数
    Private Const CMlngCmbDispCol2                      As Integer = 2                      'ｸﾞﾘｯﾄﾞ表示列数=2
    Private Const CMlngCmbGroupCols                     As Integer = 1                      '列方向ｸﾞﾙｰﾌﾟ数
    Private Const CMlngCMbSelectMode                    As Integer = 1                      '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
    Private Const CMstrCmbAddedComment                  As String = " 項目選択"              '表示 文字列
    Private Const CMstrCmbAddedCommentNone              As String = "0 項目選択"             '表示 文字列「選択なし」
    Private Const CMlngCmbGridCol0                      As Integer = 0                      '選択列数
    Private Const CMlngCmbValueCol1                     As Integer = 1                      '値取得列=1
    Private Const CMlngCmbGetCol0                       As Integer = 0                      'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=0
    Private Const CMlngCmbGetCol1                       As Integer = 1                      'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=1
    Private Const CMstrSecPriorityFlag                  As String = "あり"                  '区間優先ﾌﾗｸﾞ
    Private Const CMstrSecPriorityString                As String = "区間優先設定あり"      '区間優先設定あり表示

    '@ｶﾚﾝﾀﾞｰ用定数
    Private Const CMstrM                                As String = "M"                     '月計算用
    Private Const CMstrD                                As String = "D"                     '日計算用
    Private Const CMstrOneYear                          As String = "1年"                   '表示ﾒｯｾｰｼﾞ(期間指定)
    Private Const CMstrFirstDate                        As String = "01"                    '初日作成用

    '@ﾃｷｽﾄ用定数
    Private Const CMlngMaxDispRow                       As Integer = 3                      'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '@ﾛｯﾄ状態用定数
    Private Const CMstrRi                               As String = "リ"                    'ﾘﾜｰｸ表示
    Private Const CMstrTsui                             As String = "追"                    '追加表示
    Private Const CMstrHo                               As String = "保"                    '保留表示
    Private Const CMstrTei                              As String = "停"                    '停止表示

    '@ﾒｯｾｰｼﾞ用定数
    Private Const CMstrNotChange                        As String = "一括変更"              '確定時のｴﾗｰMsg用

    '@ﾚｽﾎﾟﾝｽ計測用定数
    Private Const CMstrFormName                         As String = "frmxxEN02B0"               '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                         As String = "Form_Load"                 'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmbPdValidate                    As String = "cmbPd_Validate"            'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmbFlowClassValidate             As String = "cmbFlowClass_Validate"     'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmbOpIDValidate                  As String = "cmbOpID_Validate"          'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmbStepIDValidate                As String = "cmbStepID_Validate"        'ｲﾍﾞﾝﾄ名称
    Private Const CMstrChkThisMonthClick                As String = "chkThisMonth_Click"        'ｲﾍﾞﾝﾄ名称
    Private Const CMstrChkNextMonthClick                As String = "chkNextMonth_Click"        'ｲﾍﾞﾝﾄ名称
    Private Const CMstrChkPlanShipDateClick             As String = "chkPlanShipDate_Click"     'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCalFromDateValidate              As String = "calFromDate_Validate"      'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCalToDateValidate                As String = "calToDate_Validate"        'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmdNowListClick                  As String = "cmdNowList_Click"          'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmdRegistClick                   As String = "cmdRegist_Click"           'ｲﾍﾞﾝﾄ名称
    Private Const CMstrPrvblnRegistAuthorityChk         As String = "prvblnRegistAuthority_Chk" 'ｲﾍﾞﾝﾄ名称

    '@SendKeysの定義
    Public Const CPstrSendKeysEnter                     As String = "{ENTER}"                   '[ENTER]キー定義

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mtypOpLotList                               As OpLotListAns                     'ﾛｯﾄ一覧取得情報格納
    Private mlngOpLotListCnt                            As Integer                          'ﾛｯﾄ一覧取得件数
    Private mtypProductList                             As List(Of ProductList)             '機種ﾘｽﾄ格納
    Private mlngProductListCnt                          As Integer                          '機種ﾃﾞｰﾀ数
    Private mtypDivisionList                            As List(Of DivisionList)            '種別ﾘｽﾄ格納
    Private mlngDivisionListCnt                         As Integer                          '種別ﾃﾞｰﾀ数
    Private mtypMasOpList                               As MasOpList                        '大工程ﾘｽﾄ格納
    Private mlngMasOpListCnt                            As Integer                          '大工程ﾃﾞｰﾀ数
    Private mtypMasStepList                             As MasStepList                      '小工程ﾘｽﾄ格納
    Private mlngMasStepListCnt                          As Integer                          '小工程ﾃﾞｰﾀ数
    Private mtypPriorityReasonList                      As List(Of typPriorityReasonList)   '優先度ﾘｽﾄ
    Private mlngPriorityReasonListCnt                   As Integer                          '優先度ﾃﾞｰﾀ数
    Private mtypChgSort                                 As ChgSort                          'ｿｰﾄ保持用
    Private mblnEditFlag                                As Boolean                          '編集ﾌﾗｸﾞ (True：編集中、False：編集完)
    Private mblnPDIDChgFlag                             As Boolean                          '機種変更ﾌﾗｸﾞ(True：変更、False：未変更)
    Private mblnFlowClassChgFlag                        As Boolean                          '種別変更ﾌﾗｸﾞ(True：変更、False：未変更)
    Private mstrOpID                                    As String                           '大工程退避用
    Private mstrStepID                                  As String                           '小工程退避用
    Private mblnFromDateChgFlag                         As Boolean                          '検索開始日変更ﾌﾗｸﾞ(True：変更、False：未変更)
    Private mblnToDateChgFlag                           As Boolean                          '検索終了日変更ﾌﾗｸﾞ(True：変更、False：未変更)
    Private mstrFromDate                                As String                           '検索開始日退避用
    Private mstrToDate                                  As String                           '検索終了日退避用

    Private buttonProcessing                            As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                          'NSYS WindowCloseフラグ

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
    '機　能：[ﾌｫｰﾑ]　起動時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2009/02/24 (Tue) 17:01:49 N.Kojima     ﾁｯﾌﾟ品判別説明ﾗﾍﾞﾙの制御処理追加。(案件№03402)
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub Form_Load()

        Dim lblnAns             As Boolean          '戻り値格納用
        Dim lstrClassDivision   As String           '処理区分格納用

        Try

            '@Escﾎﾞﾀﾝを無効(ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない)
            Me.CancelButton = Nothing

            '@=======================
            '@ 機能ﾊﾞｰｼﾞｮﾝ判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN02B0, CMstrLocalVersion)

            '@機能ﾊﾞｰｼﾞｮﾝ判定処理結果が"False：Ver不一致"か
            If lblnAns = False Then

                '@Escﾎﾞﾀﾝを有効にし、処理終了
                Me.CancelButton = cmdClose
                Exit Sub
            End If


            '@=======================
            '@ 画面初期化処理
            '@=======================
            Call prvFrmxxEN02B0_Init()

            '@=======================
            '@ [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ初期化処理
            '@=======================
            Call prvvsfLotList_Init()


            '@起動SBが組立か
            If pstrSBID = CPstrSBID2A0 Then
                '@2A0：組立の場合

                lblTitleL.BackColor = ColorTranslator.FromWin32(CPlngLColor)   '機種L
                lblTitleR.BackColor = ColorTranslator.FromWin32(CPlngRColor)   '機種R
                lblTitleL.Visible = True
                lblTitleR.Visible = True
                lblTitleChip.Visible = True         'ﾁｯﾌﾟ品説明
            Else
                '@1A0：基板の場合

                lblTitleL.Visible = False
                lblTitleR.Visible = False
                lblTitleChip.Visible = False        'ﾁｯﾌﾟ品説明
            End If

            '@-----------------------
            '@ ｿｰﾄ保持用構造体の初期化
            '@-----------------------
            With mtypChgSort

                .lngCnt = 0
                .typChgSortList = New List(Of ChgSortList)  'ｿｰﾄ保持用配列
                .blnChgWidth = False                        '列幅変更ﾌﾗｸﾞ(False：未変更)
                .strKey = vbNullString                      'ｶﾚﾝﾄ行検索ｷｰ
            End With


            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)

            '@=======================
            '@ 機種一覧取得(4F30:送品可能機種のみ)
            '@=======================
            lstrClassDivision = CPstrCD4F & CPstrCD30

            lblnAns = pubblnMasPdlist_Sel(CMstrmas_pdlist__Ver, _
                                          lstrClassDivision, _
                                          mtypProductList, _
                                          mlngProductListCnt, _
                                          pstrSBID)

            '@機種一覧取得結果が"False：取得失敗"か
            If lblnAns = False Then

                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)

                '@Escﾎﾞﾀﾝを有効にする
                Me.CancelButton = cmdClose
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)


            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)

            '@=======================
            '@ 流動区分一覧取得(2T02:Productのみ)
            '@=======================
            lstrClassDivision = CPstrCD2T & CPstrCD02

            lblnAns = pubblnMasFlowlist_Sel(CMstrmas_flowlistVer, _
                                            mtypDivisionList, _
                                            mlngDivisionListCnt, _
                                            pstrSBID, _
                                            lstrClassDivision)

            '@流動区分一覧取得結果が"False：取得失敗"か
            If lblnAns = False Then

                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)

                '@Escﾎﾞﾀﾝを有効にする
                Me.CancelButton = cmdClose
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)


            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)

            '@=======================
            '@ 大工程ﾏｽﾀ取得(2T:Productのみ)
            '@=======================
            lstrClassDivision = CPstrCD2T

            lblnAns = pubblnMasUseOpList_Sel(pstrSBID, _
                                             CMstrmas_useoplistVer, _
                                             lstrClassDivision, _
                                             mtypMasOpList)

            '@大工程ﾏｽﾀ取得結果が"False：取得失敗"か
            If lblnAns = False Then

                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)

                '@Escﾎﾞﾀﾝを有効にする
                Me.CancelButton = cmdClose
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)


            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)

            '@=======================
            '@ 優先度ﾏｽﾀﾘｽﾄ取得
            '@=======================
            lblnAns = pubblnMasPriolist_Sel(CMstrmas_priolistVer, _
                                            mlngPriorityReasonListCnt, _
                                            mtypPriorityReasonList)
            
            '@優先度ﾏｽﾀﾘｽﾄ取得結果が"False：取得失敗"か
            If lblnAns = False Then

                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)

                '@Escﾎﾞﾀﾝを有効にする
                Me.CancelButton = cmdClose
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)


            '@=======================
            '@ [機種]ｺﾝﾎﾞ設定処理
            '@=======================
            Call prvcmbPd_Disp()

            '@=======================
            '@ [種別]ｺﾝﾎﾞ設定処理
            '@=======================
            Call prvcmbFlowClass_Disp()

            '@=======================
            '@ [大工程]ｺﾝﾎﾞ設定処理
            '@=======================
            Call prvCmbOpID_Disp()

            '@=======================
            '@ [優先度一括変更]ｺﾝﾎﾞ設定処理
            '@=======================
            Call prvCmbPriority_Disp()

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"True：起動成功"をｾｯﾄ
            pblnFormLoad = True

            '@Escﾎﾞﾀﾝを有効にする
            Me.CancelButton = cmdClose

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_Load"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：[ﾌｫｰﾑ]　ｷｰﾀﾞｳﾝ時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2013/01/30 (Wed) 16:00:14 Y.Yoneyama
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    '　　　：2013/01/30 (Wed) 16:00:14 Y.Yoneyama   組立投入日対応
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@以下の状態の場合、ｷｰｺｰﾄﾞを無効にし、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中(無効)の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                e.Handled = True
                Exit Sub
            End If

            '@=======================
            '@ ｸﾞﾘｯﾄﾞｷｰ制御処理(ｸﾞﾘｯﾄﾞ共通処理)
            '@=======================
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfLotList)


            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name

                '@〓 機種 〓
                Case cmbPD.Name

                    If e.KeyCode <> Keys.Up AndAlso e.KeyCode <> Keys.Down AndAlso _
                        e.KeyCode <> Keys.Left AndAlso e.KeyCode <> Keys.Right Then

                        '@=======================
                        '@ [機種]ｺﾝﾎﾞのValidate処理
                        '@=======================
                        Call cmbPd_Validate(cmbPd, New CancelEventArgs(False))
                    End If


                '@〓 種別 〓
                Case cmbFlowClass.Name

                    If e.KeyCode <> Keys.Up AndAlso e.KeyCode <> Keys.Down AndAlso _
                        e.KeyCode <> Keys.Left AndAlso e.KeyCode <> Keys.Right Then

                        '@=======================
                        '@ [種別]ｺﾝﾎﾞのValidate処理
                        '@=======================
                        Call cmbFlowClass_Validate(cmbFlowClass, New CancelEventArgs(False))

                        '@ｷｰｺｰﾄﾞを無効にする
                        e.Handled = True
                    End If

                '@〓 工程指定(指定する) 〓
                Case chkProcess.Name

                    '@Enterｷｰが押下されたか
                    If e.KeyCode = Keys.Return Then
                        
                        '@ﾁｪｯｸOFF状態か
                        If chkProcess.Checked = False Then

                            '@ﾁｪｯｸONにする
                            chkProcess.Checked = True
                        Else
                            '@ﾁｪｯｸOFFにする
                            chkProcess.Checked = False
                        End If
                    End If

                    '@ｷｰｺｰﾄﾞを無効にする
                    e.Handled = True


                '@〓 大工程 〓
                Case cmbOpID.Name

                    If e.KeyCode <> Keys.Up AndAlso e.KeyCode <> Keys.Down AndAlso _
                        e.KeyCode <> Keys.Left AndAlso e.KeyCode <> Keys.Right Then

                        '@=======================
                        '@ [大工程]ｺﾝﾎﾞのValidate処理
                        '@=======================
                        Call cmbOpID_Validate(cmbOpID, New CancelEventArgs(False))

                        '@ｷｰｺｰﾄﾞを無効にする
                        e.Handled = True
                    End If


                '@〓 小工程 〓
                Case cmbStepID.Name

                    If e.KeyCode <> Keys.Up AndAlso e.KeyCode <> Keys.Down AndAlso _
                        e.KeyCode <> Keys.Left AndAlso e.KeyCode <> Keys.Right Then

                        '@=======================
                        '@ [小工程]ｺﾝﾎﾞのValidate処理
                        '@=======================
                        Call cmbStepID_Validate(cmbStepID, New CancelEventArgs(False))

                        '@ｷｰｺｰﾄﾞを無効にする
                        e.Handled = True
                    End If


                '@〓 当月分 〓
                Case chkThisMonth.Name

                    '@Enterｷｰが押下されたか
                    If e.KeyCode = Keys.Return Then
                        
                        '@ﾁｪｯｸOFF状態か
                        If chkThisMonth.Checked = False Then

                            '@ﾁｪｯｸONにする
                            chkThisMonth.Checked = True
                        Else
                            '@ﾁｪｯｸOFFにする
                            chkThisMonth.Checked = False
                        End If
                    End If

                    '@ｷｰｺｰﾄﾞを無効にする
                    e.Handled = True


                '@〓 次月分 〓
                Case chkNextMonth.Name

                    '@Enterｷｰが押下されたか
                    If e.KeyCode = Keys.Return Then
                        
                        '@ﾁｪｯｸOFF状態か
                        If chkNextMonth.Checked = False Then

                            '@ﾁｪｯｸONにする
                            chkNextMonth.Checked = True
                        Else
                            '@ﾁｪｯｸOFFにする
                            chkNextMonth.Checked = False
                        End If
                    End If

                    '@ｷｰｺｰﾄﾞを無効にする
                    e.Handled = True


                '@〓 期間指定(指定する) 〓
                Case chkPlanShipDate.Name

                    '@Enterｷｰが押下されたか
                    If e.KeyCode = Keys.Return Then
                        
                        '@ﾁｪｯｸOFF状態か
                        If chkPlanShipDate.Checked = False Then

                            '@ﾁｪｯｸONにする
                            chkPlanShipDate.Checked = True
                        Else
                            '@ﾁｪｯｸOFFにする
                            chkPlanShipDate.Checked = False
                        End If
                    End If

                    '@ｷｰｺｰﾄﾞを無効にする
                    e.Handled = True


                '@〓 検索開始日(送品予定日の期間指定) 〓
                Case calFromDate.Name

                    '@Enterｷｰが押下されたか
                    If e.KeyCode = Keys.Return Then
                        
                        '@=======================
                        '@ [検索開始日]ｶﾚﾝﾀﾞｰValidate処理
                        '@=======================
                        Call calFromDate_Validate(calFromDate, New CancelEventArgs(False))

                        '@ｷｰｺｰﾄﾞを無効にする
                        e.Handled = True
                    End If
          
          
                '@〓 検索終了日(送品予定日の期間指定) 〓
                Case calToDate.Name

                    '@Enterｷｰが押下されたか
                    If e.KeyCode = Keys.Return Then
                        
                        '@=======================
                        '@ [検索終了日]ｶﾚﾝﾀﾞｰValidate処理
                        '@=======================
                        Call calToDate_Validate(calToDate, New CancelEventArgs(False))

                        '@ｷｰｺｰﾄﾞを無効にする
                        e.Handled = True
                    End If


                '@〓 送品予定日 〓
                Case calPlanShipDate.Name

                    '@Enterｷｰが押下されたか
                    If e.KeyCode = Keys.Return Then
                        
                        '@=======================
                        '@ [送品予定日]ｶﾚﾝﾀﾞｰValidate処理
                        '@=======================
                        Call calPlanShipDate_Validate(calPlanShipDate, New CancelEventArgs(False))

                        '@ｷｰｺｰﾄﾞを無効にする
                        e.Handled = True
                    End If

                '@〓 組立投入日 〓
                Case calPlanAssThrowDate.Name

                    '@Enterｷｰが押下されたか
                    If e.KeyCode = Keys.Return Then
                        
                        '@=======================
                        '@ [組立送品日]ｶﾚﾝﾀﾞｰValidate処理
                        '@=======================
                        Call calPlanAssThrowDate_Validate(calPlanAssThrowDate, New CancelEventArgs(False))

                        '@ｷｰｺｰﾄﾞを無効にする
                        e.Handled = True
                    End If

                '@〓 完成予定日 〓
                Case calPlanFinishDate.Name

                    '@Enterｷｰが押下されたか
                    If e.KeyCode = Keys.Return Then
                        
                        '@=======================
                        '@ [送品予定日]ｶﾚﾝﾀﾞｰValidate処理
                        '@=======================
                        Call calPlanFinishDate_Validate(calPlanFinishDate, New CancelEventArgs(False))

                        '@ｷｰｺｰﾄﾞを無効にする
                        e.Handled = True
                    End If

                '@〓 作業ﾒﾓ 〓
                Case txtComments.Name

                    Exit Sub


                '@〓 その他 〓
                Case Else

                    '@ｷｰｺｰﾄﾞがEnterｷｰか
                    If e.KeyCode = Keys.Return Then

                        '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽをｾｯﾄし、ｷｰｺｰﾄﾞを無効にする
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                    End If

            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：[ﾌｫｰﾑ]　終了時処理
    '引　数：Cancel     ：ｷｬﾝｾﾙ値
    '　　　：UnloadMode ：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm         As Boolean              '開放結果格納
        Dim ltypMasOpList       As New MasOpList()      '大工程ﾘｽﾄ初期化用
        Dim ltypMasStepList     As New MasStepList()    '小工程ﾘｽﾄ初期化用
        Dim lintAns As Integer

        Try
            '登録ボタンが有効の場合
            '編集中と判断して閉じる前にユーザー確認
            If cmdRegist.Enabled = True Then

                '"編集中です。 内容を破棄してよろしいですか？"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001A)
                lintAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                'NO
                If lintAns = vbNo Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If

            '@Windowの[×]ﾎﾞﾀﾝが押下されたか
            If mblnCloseFromControlMenu Then

                '@=======================
                '@ [閉じる]ﾎﾞﾀﾝ押下処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, EventArgs.Empty)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If

            '@各種配列の初期化
            'mtypWkLotList = Nothing                     'ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ表示用配列
            mtypOpLotList.typOpLotListList = Nothing    'ﾛｯﾄ一覧取得情報格納用配列
            mtypChgSort.typChgSortList = Nothing        'ｿｰﾄ保持用配列
            mtypProductList = Nothing                   '機種配列用
            mtypDivisionList = Nothing                  '種別配列用
            mtypPriorityReasonList = Nothing            '優先度配列用
            mtypMasOpList = ltypMasOpList               '大工程ﾘｽﾄ
            mtypMasStepList = ltypMasStepList           '小工程ﾘｽﾄ
            

            '@ActInitﾌﾗｸﾞの判定
            If pblnActInitFlg = True Then
                '@Actを自前で初期化した場合
                
                '@=======================
                '@ ACTｵﾌﾞｼﾞｪｸﾄの開放処理
                '@=======================
                lblnAnsTerm = pubblnAct_Term
                
                '@処理結果判定
                If lblnAnsTerm = True Then
                    '@結果：正常の場合
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                End If
            Else
                '@=======================
                '@ ﾒﾆｭｰ伸張処理
                '@=======================
                Call pubMenuExpand_Disp()
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

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPd_Change
    '機　能：[機種]ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub cmbPd_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPd.Change

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True：起動済"か
            If pblnFormLoad = True Then

                '@各種ﾗﾍﾞﾙの初期化
                lblNowDate.Text = vbNullString       '情報取得日時
                lblLotCnt.Text = vbNullString        '該当件数

                '@=======================
                '@ [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ初期化処理
                '@=======================
                Call prvvsfLotList_Init()

                '@機種変更ﾌﾗｸﾞに"True：変更あり"をｾｯﾄ
                mblnPDIDChgFlag = True

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPd_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPd_CloseUp
    '機　能：[機種]ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub cmbPd_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPd.CloseUp

        Try

            '@=======================
            '@ [機種]ｺﾝﾎﾞValidate処理
            '@=======================
            Call cmbPd_Validate(cmbPd, New CancelEventArgs(True))

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPd_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPd_Validate
    '機　能：[機種]ｺﾝﾎﾞ　Validate処理(ﾌｫｰｶｽﾛｽﾄ時入力ﾁｪｯｸ処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub cmbPd_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPd.Validating

        Dim lblnAns         As Boolean      '戻り値格納用

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@機種変更ﾌﾗｸﾞが"True：変更あり"か
            If mblnPDIDChgFlag = True Then

                '@機種が選択されてるか(NULL、"0項目選択"以外)
                If cmbPD.Text <> vbNullString And _
                    cmbPD.Text <> CMstrCmbAddedCommentNone Then

                    '@種別が選択されてるか(NULL、"0項目選択"以外)
                    If cmbFlowClass.Text <> vbNullString And _
                        cmbFlowClass.Text <> CMstrCmbAddedCommentNone Then

                        '@=======================
                        '@ [最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
                        '@=======================
                        lblnAns = prvblnSearchCondition_Chk(CMstrCmbPdValidate)

                        '@[最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"True：検索条件All-OK"か
                        If lblnAns = True Then

                            '@=======================
                            '@ [最新取得]ﾎﾞﾀﾝ押下処理
                            '@=======================
                            Call cmdNowList_Click(cmdNowList, EventArgs.Empty)
                        End If
                    Else
                        '@[種別]ｺﾝﾎﾞがNULLか"0項目選択"の場合

                        '@[最新取得]ﾎﾞﾀﾝを無効にする
                        cmdNowList.Enabled = False

                        '@[種別]ｺﾝﾎﾞへﾌｫｰｶｽｾｯﾄ
                        Call prvSetFocus(cmbFlowClass, cmbPD)
                    End If
                Else
                    '@[機種]ｺﾝﾎﾞがNULLか"0項目選択"の場合

                    '@[最新取得]ﾎﾞﾀﾝを無効にする
                    cmdNowList.Enabled = False

                    '@ﾌｫｰｶｽを[機種]ｺﾝﾎﾞに留める
                    Call prvSetFocus(cmbPD, cmbPD)
                End If

                '@機種変更ﾌﾗｸﾞを初期化
                mblnPDIDChgFlag = False
            Else
                '@機種変更ﾌﾗｸﾞが"False：変更なし"の場合

                '@[種別]ｺﾝﾎﾞへﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(cmbFlowClass, cmbPD)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPd_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbFlowClass_Change
    '機　能：[種別]ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub cmbFlowClass_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbFlowClass.Change

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True：起動済"か
            If pblnFormLoad = True Then

                '@各種ﾗﾍﾞﾙの初期化
                lblNowDate.Text = vbNullString       '情報取得日時
                lblLotCnt.Text = vbNullString        '該当件数

                '@=======================
                '@ [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ初期化処理
                '@=======================
                Call prvvsfLotList_Init()

                '@種別変更ﾌﾗｸﾞに"True：変更あり"をｾｯﾄ
                mblnFlowClassChgFlag = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbFlowClass_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbFlowClass_CloseUp
    '機　能：[種別]ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub cmbFlowClass_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbFlowClass.CloseUp

        Try

            '@=======================
            '@ [種別]ｺﾝﾎﾞValidate処理
            '@=======================
            Call cmbFlowClass_Validate(cmbFlowClass, New CancelEventArgs(True))

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbFlowClass_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbFlowClass_Validate
    '機　能：[種別]ｺﾝﾎﾞ　Validate処理(ﾌｫｰｶｽﾛｽﾄ時入力ﾁｪｯｸ処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub cmbFlowClass_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbFlowClass.Validating

        Dim lblnAns     As Boolean      '戻り値格納用

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@種別変更ﾌﾗｸﾞが"True：変更あり"か
            If mblnFlowClassChgFlag = True Then

                '@種別が選択されてるか(NULL、"0項目選択"以外)
                If cmbFlowClass.Text <> vbNullString And _
                    cmbFlowClass.Text <> CMstrCmbAddedCommentNone Then

                    '@機種が選択されているか(NULL、"0項目選択"以外)
                    If cmbPD.Text <> vbNullString And _
                        cmbPD.Text <> CMstrCmbAddedCommentNone Then

                        '@=======================
                        '@ [最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
                        '@=======================
                        lblnAns = prvblnSearchCondition_Chk(CMstrCmbFlowClassValidate)

                        '@[最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"True：検索条件All-OK"か
                        If lblnAns = True Then

                            '@=======================
                            '@ [最新取得]ﾎﾞﾀﾝ押下処理
                            '@=======================
                            Call cmdNowList_Click(cmdNowList, EventArgs.Empty)
                        End If
                    Else
                        '@[機種]ｺﾝﾎﾞがNULLか"0項目選択"の場合

                        '@[最新取得]ﾎﾞﾀﾝを無効にする
                        cmdNowList.Enabled = False

                        '@[機種]ｺﾝﾎﾞへﾌｫｰｶｽｾｯﾄ
                        Call prvSetFocus(cmbPD, cmbFlowClass)
                    End If
                Else
                    '@[種別]ｺﾝﾎﾞがNULLか"0項目選択"の場合

                    '@[最新取得]ﾎﾞﾀﾝを無効にする
                    cmdNowList.Enabled = False

                    '@種別にﾌｫｰｶｽを留める
                    Call prvSetFocus(cmbFlowClass, cmbFlowClass)
                End If

                '@種別変更ﾌﾗｸﾞを初期化
                mblnFlowClassChgFlag = False

            Else
                '@種別変更ﾌﾗｸﾞが"False：変更なし"の場合

                '@種別が選択されてるか(NULL、"0項目選択"以外)
                If cmbFlowClass.Text <> vbNullString And _
                    cmbFlowClass.Text <> CMstrCmbAddedCommentNone Then

                    '@機種が選択されているか(NULL、"0項目選択"以外)
                    If cmbPD.Text <> vbNullString And _
                        cmbPD.Text <> CMstrCmbAddedCommentNone Then

                        '@[工程指定(指定する)]ﾁｪｯｸﾎﾞｯｸｽへﾌｫｰｶｽｾｯﾄ
                        Call prvSetFocus(chkProcess, cmbFlowClass)

                    Else
                        '@[機種]ｺﾝﾎﾞがNULLか"0項目選択"の場合

                        '@[機種]ｺﾝﾎﾞへﾌｫｰｶｽｾｯﾄ
                        Call prvSetFocus(cmbPD, cmbFlowClass)
                    End If
                Else
                    '@[工程指定(指定する)]ﾁｪｯｸﾎﾞｯｸｽへﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(chkProcess, cmbFlowClass)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbFlowClass_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：chkProcess_Click
    '機　能：[工程指定(指定する)]ﾁｪｯｸﾎﾞｯｸｽ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/12/24 (Thu) 10:49:55 N.Kojima
    '更新日：2009/12/24 (Thu) 10:49:55
    '備　考：
    Private Sub chkProcess_Click(ByVal sender As Object, ByVal e As EventArgs) Handles chkProcess.CheckedChanged

        Dim lblnAns     As Boolean      '戻り値格納用

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True：起動済"か
            If pblnFormLoad = True Then

                '@ﾁｪｯｸOFFか
                If chkProcess.Checked = False Then

                    '@[大工程]・[小工程]ｺﾝﾎﾞの初期化
                    cmbOpID.Text = vbNullString
                    cmbStepID.Text = vbNullString
                    cmbOpID.Enabled = False
                    cmbStepID.Enabled = False
                    cmbOpID.ListIndex = -1
                    cmbStepID.ListIndex = -1
                Else
                    '@ﾁｪｯｸONの場合

                    '@[大工程]ｺﾝﾎﾞを有効にする
                    cmbOpID.Enabled = True

                    '@大工程が1件か
                    If cmbOpID.ListCount = 1 Then

                        '@1件を表示
                        cmbOpID.ListIndex = 0
                    End If
                End If
            End If

            '@=======================
            '@ [最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnSearchCondition_Chk(CMstrChkPlanShipDateClick)
            
            '@[最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"True：検索条件All-OK"か
            If lblnAns = True Then

                '@[最新取得]ﾎﾞﾀﾝを有効にする
                cmdNowList.Enabled = True
            Else
                '@[最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"False：検索条件設定不足"の場合

                '@[最新取得]ﾎﾞﾀﾝを無効にする
                cmdNowList.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "chkProcess_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbOpID_Change
    '機　能：[大工程]ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/12/24 (Thu) 10:49:55 N.Kojima
    '更新日：2009/12/24 (Thu) 10:49:55
    '備　考：
    Private Sub cmbOpID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOpID.Change

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True：起動済"、かつ変更大工程が退避変数と異なるか
            If pblnFormLoad = True And _
                mstrOpID <> cmbOpID.Text Then

                '@各種ﾗﾍﾞﾙの初期化
                lblNowDate.Text = vbNullString       '情報取得日時
                lblLotCnt.Text = vbNullString        '該当件数

                '@=======================
                '@ [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ初期化処理
                '@=======================
                Call prvvsfLotList_Init()

                '@[小工程]ｺﾝﾎﾞの初期化
                cmbStepID.Clear                 'ｸﾘｱ
                cmbStepID.Enabled = False       '無効
            
                '@大工程退避用変数の初期化
                mstrOpID = vbNullString
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbOpID_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbOpID_CloseUp
    '機　能：[大工程]ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/12/24 (Thu) 10:49:55 N.Kojima
    '更新日：2009/12/24 (Thu) 10:49:55
    '備　考：
    Private Sub cmbOpID_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOpID.CloseUp

        Try

            '@大工程が選択されているか
            If cmbOpID.Text <> vbNullString Then

                '@=======================
                '@ [大工程]ｺﾝﾎﾞValidate処理
                '@=======================
                Call cmbOpID_Validate(cmbOpID, New CancelEventArgs(True))
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbOpID_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbOpID_Validate
    '機　能：[大工程]ｺﾝﾎﾞ　Validate処理(ﾌｫｰｶｽﾛｽﾄ時入力ﾁｪｯｸ処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2009/12/24 (Thu) 10:49:55 N.Kojima
    '更新日：2009/12/24 (Thu) 10:49:55
    '備　考：
    Private Sub cmbOpID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbOpID.Validating

        Dim lblnAns         As Boolean              '戻り値格納用
        Dim ltypLotList     As List(Of LotIdList)   'ﾛｯﾄﾘｽﾄ(引数合わせ用)

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@前回選択された大工程と同じか
            If mstrOpID = cmbOpID.Text Then

                '@[小工程]ｺﾝﾎﾞが有効か
                If cmbStepID.Enabled = True Then

                    '@[小工程]ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(cmbStepID, cmbOpID)
                Else
                    '@[当月]ﾁｪｯｸﾎﾞｯｸｽにﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(chkThisMonth, cmbOpID)
                End If

                Exit Sub
            Else
                '@前回選択された大工程と異なる場合

                '@大工程がNULLか
                If cmbOpID.Text = vbNullString Then
                    Exit Sub
                End If
            End If


            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmbOpIDValidate)

            '@=======================
            '@ 小工程取得
            '@=======================
            lblnAns = pubblnLotStepList_Sel(pstrSBID, _
                                            CMstrlot_steplistVer, _
                                            CPstrCD28, _
                                            ltypLotList, _
                                            mtypMasStepList, _
                                            cmbOpID.Text)

            '@小工程取得結果が"True：取得成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmbOpIDValidate)

                '@[小工程]ｺﾝﾎﾞを有効にする
                cmbStepID.Enabled = True

                '@=======================
                '@ [小工程]ｺﾝﾎﾞ設定処理
                '@=======================
                Call prvCmbStepID_Disp()

                '@[小工程]ｺﾝﾎﾞが有効か
                If cmbStepID.Enabled = True Then

                    '@[小工程]ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(cmbStepID, cmbOpID)
                End If
            Else
                '@小工程取得結果が"False：取得失敗"の場合

                '@退避変数をｸﾘｱ
                mstrOpID = vbNullString

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmbOpIDValidate)

                '@[大工程]ｺﾝﾎﾞにﾌｫｰｶｽを留める
                e.Cancel = True
                Exit Sub
            End If

            '@現在選択されている大工程を退避変数にｾｯﾄ
            mstrOpID = cmbOpID.Text

            '@=======================
            '@ [最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnSearchCondition_Chk(CMstrCmbOpIDValidate)
            
            '@[最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"True：検索条件All-OK"か
            If lblnAns = True Then

                '@[最新取得]ﾎﾞﾀﾝを有効にする
                cmdNowList.Enabled = True
            Else
                '@[最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"False：検索条件設定不足"の場合

                '@[最新取得]ﾎﾞﾀﾝを無効にする
                cmdNowList.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbOpID_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbStepID_Change
    '機　能：[小工程]ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/12/24 (Thu) 10:49:55 N.Kojima
    '更新日：2009/12/24 (Thu) 10:49:55
    '備　考：
    Private Sub cmbStepID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbStepID.Change

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True：起動済"、かつ変更小工程が退避変数と異なるか
            If pblnFormLoad = True And _
                mstrStepID <> cmbOpID.Text Then

                '@各種ﾗﾍﾞﾙの初期化
                lblNowDate.Text = vbNullString       '情報取得日時
                lblLotCnt.Text = vbNullString        '該当件数

                '@=======================
                '@ [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ初期化処理
                '@=======================
                Call prvvsfLotList_Init()

                '@小工程退避用変数の初期化
                mstrStepID = vbNullString
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbStepID_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbStepID_CloseUp
    '機　能：[小工程]ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/12/24 (Thu) 10:49:55 N.Kojima
    '更新日：2009/12/24 (Thu) 10:49:55
    '備　考：
    Private Sub cmbStepID_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbStepID.CloseUp

        Try

            '@小工程が選択されているか
            If cmbStepID.Text <> vbNullString Then

                '@=======================
                '@ [小工程]ｺﾝﾎﾞValidate処理
                '@=======================
                Call cmbStepID_Validate(cmbStepID, New CancelEventArgs(True))
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbStepID_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbStepID_Validate
    '機　能：[小工程]ｺﾝﾎﾞ　Validate処理(ﾌｫｰｶｽﾛｽﾄ時入力ﾁｪｯｸ処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2009/12/24 (Thu) 10:49:55 N.Kojima
    '更新日：2009/12/24 (Thu) 10:49:55
    '備　考：
    Private Sub cmbStepID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbStepID.Validating

        Dim lblnAns     As Boolean      '戻り値格納用

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@前回選択された小工程と同じか
            If mstrStepID = cmbStepID.Text Then

                '@[当月]ﾁｪｯｸﾎﾞｯｸｽが有効か
                If chkThisMonth.Enabled = True Then

                    '@[当月]ﾁｪｯｸﾎﾞｯｸｽにﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(chkThisMonth, cmbStepID)
                Else
                    '@[閉じる]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(cmdClose, cmbStepID)
                End If

                Exit Sub
            Else
                '@前回選択された小工程と異なる場合

                '@小工程がNULLか
                If cmbStepID.Text = vbNullString Then
                    Exit Sub
                End If
            End If

            '@現在選択されている小工程を退避領域にｾｯﾄ
            mstrStepID = cmbStepID.Text

            '@=======================
            '@ [最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理(引数:ｲﾍﾞﾝﾄ名)
            '@=======================
            lblnAns = prvblnSearchCondition_Chk(CMstrCmbStepIDValidate)

            '@[最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"True：検索条件All-OK"か
            If lblnAns = True Then

                '@[最新取得]ﾎﾞﾀﾝを有効にする
                cmdNowList.Enabled = True
            Else
                '@[最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"False：検索条件設定不足"の場合

                '@[最新取得]ﾎﾞﾀﾝを無効にする
                cmdNowList.Enabled = False
            End If

            '@[当月]ﾁｪｯｸﾎﾞｯｸｽが有効か
            If chkThisMonth.Enabled = True Then

                '@[当月]ﾁｪｯｸﾎﾞｯｸｽにﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(chkThisMonth, cmbStepID)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbStepID_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：chkThisMonth_Click
    '機　能：[当月分]ﾁｪｯｸﾎﾞｯｸｽ　押下＆Click時処理
    '引　数：なし
    '戻り値：
    '作成日：2010/01/12 (Tue) 09:10:50 N.Kojima
    '更新日：2010/01/12 (Tue) 09:10:50
    '備　考：
    Private Sub chkThisMonth_Click(ByVal sender As Object, ByVal e As EventArgs) Handles chkThisMonth.CheckedChanged

        Dim lblnAns     As Boolean      '戻り値格納用

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True：起動済"か
            If pblnFormLoad = True Then

                '@ﾁｪｯｸONか
                If chkThisMonth.Checked = True Then

                    '@[指定する(期間指定)]ﾁｪｯｸﾎﾞｯｸｽをﾁｪｯｸOFFにする
                    chkPlanShipDate.Checked = False
                Else
                    '@ﾁｪｯｸOFFの場合

                    '@各種ﾗﾍﾞﾙの初期化
                    lblNowDate.Text = vbNullString       '情報取得日時
                    lblLotCnt.Text = vbNullString        '該当件数

                    '@[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞにﾃﾞｰﾀが存在するか
                    If vsfLotList.Rows.Count > 1 Then

                        '@=======================
                        '@ [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ初期化処理
                        '@=======================
                        Call prvvsfLotList_Init()
                    End If
                End If

                '@=======================
                '@ [最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
                '@=======================
                lblnAns = prvblnSearchCondition_Chk(CMstrChkThisMonthClick)
                
                '@[最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"True：検索条件All-OK"か
                If lblnAns = True Then
            
                    '@[最新取得]ﾎﾞﾀﾝを有効にする
                    cmdNowList.Enabled = True
                Else
                    '@[最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"False：検索条件設定不足"の場合
            
                    '@[最新取得]ﾎﾞﾀﾝを無効にする
                    cmdNowList.Enabled = False
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "chkThisMonth_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：chkNextMonth_Click
    '機　能：[次月分]ﾁｪｯｸﾎﾞｯｸｽ　押下＆Click時処理
    '引　数：なし
    '戻り値：
    '作成日：2010/01/12 (Tue) 09:10:50 N.Kojima
    '更新日：2010/01/12 (Tue) 09:10:50
    '備　考：
    Private Sub chkNextMonth_Click(ByVal sender As Object, ByVal e As EventArgs) Handles chkNextMonth.CheckedChanged

        Dim lblnAns     As Boolean      '戻り値格納用

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True：起動済"か
            If pblnFormLoad = True Then

                '@ﾁｪｯｸONか
                If chkNextMonth.Checked = True Then

                    '@[指定する(期間指定)]ﾁｪｯｸﾎﾞｯｸｽをﾁｪｯｸOFFにする
                    chkPlanShipDate.Checked = False
                Else
                    '@ﾁｪｯｸOFFの場合

                    '@各種ﾗﾍﾞﾙの初期化
                    lblNowDate.Text = vbNullString       '情報取得日時
                    lblLotCnt.Text = vbNullString        '該当件数

                    '@[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞにﾃﾞｰﾀが存在するか
                    If vsfLotList.Rows.Count > 1 Then

                        '@=======================
                        '@ [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ初期化処理
                        '@=======================
                        Call prvvsfLotList_Init()
                    End If
                End If

                '@=======================
                '@ [最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
                '@=======================
                lblnAns = prvblnSearchCondition_Chk(CMstrChkNextMonthClick)
                
                '@[最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"True：検索条件All-OK"か
                If lblnAns = True Then
            
                    '@[最新取得]ﾎﾞﾀﾝを有効にする
                    cmdNowList.Enabled = True
                Else
                    '@[最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"False：検索条件設定不足"の場合
            
                    '@[最新取得]ﾎﾞﾀﾝを無効にする
                    cmdNowList.Enabled = False
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "chkNextMonth_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：chkPlanShipDate_Click
    '機　能：[期間指定(指定する)]ﾁｪｯｸﾎﾞｯｸｽ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/12/24 (Thu) 10:49:55 N.Kojima
    '更新日：2009/12/24 (Thu) 10:49:55
    '備　考：
    Private Sub chkPlanShipDate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles chkPlanShipDate.CheckedChanged

        Dim lblnAns     As Boolean      '戻り値格納用

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True：起動済"か
            If pblnFormLoad = True Then

                '@ﾁｪｯｸOFFか
                If chkPlanShipDate.Checked = False Then

                    '@[検索開始日]・[検索終了日]ｶﾚﾝﾀﾞｰの初期化
                    '@ ※ｶﾚﾝﾀﾞｰはNULLでｸﾘｱ可能。CPstrNullDate("____/__/__")ではｸﾘｱ出来ないので注意！！
                    calFromDate.Value = vbNullString
                    calToDate.Value = vbNullString
                    calFromDate.Enabled = False
                    calToDate.Enabled = False
                Else
                    '@ﾁｪｯｸONの場合

                    '@[当月分]・[次月分]ﾁｪｯｸﾎﾞｯｸｽをﾁｪｯｸOFFにする
                    chkThisMonth.Checked = False
                    chkNextMonth.Checked = False

                    '@[検索開始日]・[検索終了日]ｺﾝﾎﾞを有効にする
                    calFromDate.Enabled = True
                    calToDate.Enabled = True
                End If

                '@=======================
                '@ [最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
                '@=======================
                lblnAns = prvblnSearchCondition_Chk(CMstrChkPlanShipDateClick)
                
                '@[最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"True：検索条件All-OK"か
                If lblnAns = True Then
            
                    '@[最新取得]ﾎﾞﾀﾝを有効にする
                    cmdNowList.Enabled = True
                Else
                    '@[最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"False：検索条件設定不足"の場合
            
                    '@[最新取得]ﾎﾞﾀﾝを無効にする
                    cmdNowList.Enabled = False
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "chkPlanShipDate_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calFromDate_CalendarSelect
    '機　能：[検索開始日(送品予定日)]ｶﾚﾝﾀﾞｰ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/12/28 (Mon) 10:21:53 N.Kojima
    '更新日：2009/12/28 (Mon) 10:21:53
    '備　考：
    Private Sub calFromDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calFromDate.CalendarSelect

        Try

            '@=======================
            '@ [検索開始日(送品予定日)]ｶﾚﾝﾀﾞｰValidate処理
            '@=======================
            Call calFromDate_Validate(calFromDate, New CancelEventArgs(False))

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calFromDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calFromDate_Change
    '機　能：[検索開始日(送品予定日)]ｶﾚﾝﾀﾞｰ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/12/28 (Mon) 10:21:53 N.Kojima
    '更新日：2009/12/28 (Mon) 10:21:53
    '備　考：
    Private Sub calFromDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calFromDate.Change

        Try

            '@検索開始日変更ﾌﾗｸﾞが"False：変更なし(ﾃﾞﾌｫﾙﾄ値)"か
            If mblnFromDateChgFlag = False Then

                '@各種ﾗﾍﾞﾙの初期化
                lblNowDate.Text = vbNullString       '情報取得日時
                lblLotCnt.Text = vbNullString        '該当件数

                '@=======================
                '@ [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ初期化処理
                '@=======================
                Call prvvsfLotList_Init()

                '@検索開始日変更ﾌﾗｸﾞに"True：変更あり"をｾｯﾄ
                mblnFromDateChgFlag = True

                '@検索開始日退避用変数の初期化
                mstrFromDate = vbNullString
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calFromDate_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calFromDate_Validate
    '機　能：[検索開始日(送品予定日)]ｶﾚﾝﾀﾞｰ　Validate処理(ﾌｫｰｶｽﾛｽﾄ時入力ﾁｪｯｸ処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2009/12/28 (Mon) 10:21:53 N.Kojima
    '更新日：2009/12/28 (Mon) 10:21:53
    '備　考：
    Private Sub calFromDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calFromDate.Validating

        Dim lstrNowDT           As String       '現在日付格納用
        Dim lstrDate            As String       '12ヵ月後の日付格納用
        Dim lblnErrFlag         As Boolean      'ｴﾗｰ判定ﾌﾗｸﾞ(True：ｴﾗｰあり、False：ｴﾗｰなし)
        Dim lblnAns             As Boolean      '戻り値用

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@検索開始日変更ﾌﾗｸﾞの初期化
            mblnFromDateChgFlag = False

            '@以下の条件の場合は処理抜け
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If

            '@現在選択されている検索開始日が退避変数の値と同じか
            If mstrFromDate = calFromDate.Value Then

                '@[検索終了日]ｶﾚﾝﾀﾞｰが有効か
                If calToDate.Enabled = True Then
            
                    '@[検索終了日]ｶﾚﾝﾀﾞｰにﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(calToDate, calFromDate)
                Else
                    '@[閉じる]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(cmdClose, calFromDate)
                End If

                Exit Sub
            End If


            '@ｴﾗｰ判定ﾌﾗｸﾞの初期化
            lblnErrFlag = False

            '@検索開始日に"_"が含まれていないか
            If calFromDate.Value <> CPstrNullDate Then

                '@=======================
                '@ 検索開始日の有効範囲ﾁｪｯｸ処理
                '@=======================
                If pubblnYearRange_Chk(calFromDate.Value) = False Then
                    '@無効日付の場合

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM08W>$$正しい日付を入力してください。$1900年～2100年以外の日付は入力できません。"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@ｴﾗｰ判定ﾌﾗｸﾞに"True：ｴﾗｰあり"をｾｯﾄ
                    lblnErrFlag = True
                Else
                    '@有効日付の場合

                    '@現在日付取得
                    lstrNowDT = Format$(Now, CPstrDateTimeYMD)

                    '@検索開始日 > 検索終了日か
                    If IsDate(calToDate.Value) AndAlso _
                        Format$(CDate(calFromDate.Value), CPstrDateTimeYMD) > _
                        Format$(CDate(calToDate.Value), CPstrDateTimeYMD) Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM2HW>$$開始日が終了日より大きくなっています。設定を見直してください。"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002H)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@ｴﾗｰ判定ﾌﾗｸﾞに"True：ｴﾗｰあり"をｾｯﾄ
                        lblnErrFlag = True
                    End If
                End If
            End If


            '@検索終了日・検索開始日に"_"が含まれていない、かつ上記ﾁｪｯｸでｴﾗｰになっていないか
            If InStr(1, calToDate.Value, CPstrHalfUnderScore) = CPlngNumZero And _
                InStr(1, calFromDate.Value, CPstrHalfUnderScore) = CPlngNumZero And _
                lblnErrFlag = False Then

                '@検索開始日に12ヵ月(1年)を足した日付を格納
                lstrDate = Format$(DateAdd(CMstrM, 12, CDate(calFromDate.Value)), CPstrDateTimeYMDHM)

                '@検索開始日に12ヶ月(1年)を足した日付 < 検索終了日か
                If lstrDate < calToDate.Value Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM8WW>$$期間指定について、開始～終了までの間は$%1以内で設定してください。"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008W, CMstrOneYear)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@ｴﾗｰ判定ﾌﾗｸﾞに"True：ｴﾗｰあり"をｾｯﾄ
                    lblnErrFlag = True
                End If
            End If


            '@ｴﾗｰ判定ﾌﾗｸﾞが"True：ｴﾗｰあり"か
            If lblnErrFlag = True Then

                '@[最新取得]ﾎﾞﾀﾝを無効にする
                cmdNowList.Enabled = False

                e.Cancel = True
                Exit Sub
            Else
                '@=======================
                '@ [最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
                '@=======================
                lblnAns = prvblnSearchCondition_Chk(CMstrCalFromDateValidate)

                '@[最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"True：検索条件All-OK"か
                If lblnAns = True Then

                    '@[最新取得]ﾎﾞﾀﾝを有効にする
                    cmdNowList.Enabled = True
                Else
                    '@[最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"False：検索条件設定不足"の場合

                    '@[最新取得]ﾎﾞﾀﾝを無効にする
                    cmdNowList.Enabled = False
                End If
            End If

            '@現在選択されている検索開始日を退避変数にｾｯﾄ
            mstrFromDate = calFromDate.Value

            '@[検索終了日]ｶﾚﾝﾀﾞｰが有効か
            If calToDate.Enabled = True Then

                '@[検索終了日]ｶﾚﾝﾀﾞｰにﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(calToDate, calFromDate)
            Else
                '@[閉じる]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(cmdClose, calFromDate)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calFromDate_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calToDate_CalendarSelect
    '機　能：[検索終了日(送品予定日)]ｶﾚﾝﾀﾞｰ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/12/28 (Mon) 10:21:53 N.Kojima
    '更新日：2009/12/28 (Mon) 10:21:53
    '備　考：
    Private Sub calToDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calToDate.CalendarSelect

        Try

            '@=======================
            '@ [検索終了日(送品予定日)]ｶﾚﾝﾀﾞｰValidate処理
            '@=======================
            Call calToDate_Validate(calToDate, New CancelEventArgs(False))

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calToDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calToDate_Change
    '機　能：[検索終了日(送品予定日)]ｶﾚﾝﾀﾞｰ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/12/28 (Mon) 10:21:53 N.Kojima
    '更新日：2009/12/28 (Mon) 10:21:53
    '備　考：
    Private Sub calToDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calToDate.Change

        Try

            '@検索終了日変更ﾌﾗｸﾞに"False：変更なし(ﾃﾞﾌｫﾙﾄ値)"か
            If mblnToDateChgFlag = False Then

                '@各種ﾗﾍﾞﾙの初期化
                lblNowDate.Text = vbNullString       '情報取得日時
                lblLotCnt.Text = vbNullString        '該当件数

                '@=======================
                '@ [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ初期化処理
                '@=======================
                Call prvvsfLotList_Init()

                '@検索終了日変更ﾌﾗｸﾞに"True：変更あり"をｾｯﾄ
                mblnToDateChgFlag = True

                '@検索終了日退避用変数の初期化
                mstrToDate = vbNullString
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calToDate_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calToDate_Validate
    '機　能：[検索終了日(送品予定日)]ｶﾚﾝﾀﾞｰ　Validate処理(ﾌｫｰｶｽﾛｽﾄ時入力ﾁｪｯｸ処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2009/12/28 (Mon) 10:21:53 N.Kojima
    '更新日：2009/12/28 (Mon) 10:21:53
    '備　考：
    Private Sub calToDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calToDate.Validating

        Dim lstrNowDT           As String       '現在日付格納用
        Dim lstrDate            As String       '12ヵ月前の日付格納用
        Dim lblnErrFlag         As Boolean      'ｴﾗｰ判定ﾌﾗｸﾞ(True：ｴﾗｰあり、False：ｴﾗｰなし)
        Dim lblnAns             As Boolean      '戻り値格納用

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@検索終了日変更ﾌﾗｸﾞの初期化
            mblnToDateChgFlag = False

            '@以下の条件の場合は処理抜け
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If

            '@現在選択されている検索終了日が退避変数の値と同じか
            If mstrToDate = calToDate.Value Then

                '@[最新取得]ﾎﾞﾀﾝが有効か
                If cmdNowList.Enabled = True Then

                    '@[最新取得]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(cmdNowList, calToDate)
                Else
                    '@[閉じる]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(cmdClose, calToDate)
                End If

                Exit Sub
            End If


            '@ｴﾗｰ判定ﾌﾗｸﾞの初期化
            lblnErrFlag = False

            '@検索終了日に"_"が含まれていないか
            If calToDate.Value <> CPstrNullDate Then

                '@=======================
                '@ 検索終了日の有効範囲ﾁｪｯｸ処理
                '@=======================
                If pubblnYearRange_Chk(calToDate.Value) = False Then
                    '@日付が無効な場合

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM08W>$$正しい日付を入力してください。$1900年～2100年以外の日付は入力できません。"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@ｴﾗｰ判定ﾌﾗｸﾞに"True：ｴﾗｰあり"をｾｯﾄ
                    lblnErrFlag = True
                Else
                    '@日付が有効な場合

                    '@現在日付取得
                    lstrNowDT = Format$(Now, CPstrDateTimeYMD)

                    '@検索開始日に"_"が含まれていないか
                    If InStr(1, calFromDate.Value, CPstrHalfUnderScore) = CPlngNumZero Then

                        '@検索開始日 > 検索終了日か
                        If Format$(CDate(calFromDate.Value), CPstrDateTimeYMD) > _
                            Format$(CDate(calToDate.Value), CPstrDateTimeYMD) Then
            
                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「"<TRM2HW>$$開始日が終了日より大きくなっています。設定を見直してください。"」のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002H)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
                            '@ｴﾗｰ判定ﾌﾗｸﾞに"True：ｴﾗｰあり"をｾｯﾄ
                            lblnErrFlag = True
                        End If
                    End If
                End If
            End If


            '@検索終了日・検索開始日に"_"が含まれていない、かつ上記ﾁｪｯｸでｴﾗｰになっていないか
            If InStr(1, calToDate.Value, CPstrHalfUnderScore) = CPlngNumZero And _
                InStr(1, calFromDate.Value, CPstrHalfUnderScore) = CPlngNumZero And _
                lblnErrFlag = False Then

                '@検索開始日に12ヵ月(1年)を足した日付を格納
                lstrDate = Format$(DateAdd(CMstrM, 12, CDate(calFromDate.Value)), CPstrDateTimeYMDHM)

                '@検索開始日に12ヶ月(1年)を足した日付 < 検索終了日か
                If lstrDate < calToDate.Value Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM2HW>$$開始日が終了日より大きくなっています。設定を見直してください。"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008W, CMstrOneYear)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@ｴﾗｰ判定ﾌﾗｸﾞに"True：ｴﾗｰあり"をｾｯﾄ
                    lblnErrFlag = True
                End If
            End If

            '@ｴﾗｰ判定ﾌﾗｸﾞが"True：ｴﾗｰあり"か
            If lblnErrFlag = True Then

                '@[最新取得]ﾎﾞﾀﾝを無効にする
                cmdNowList.Enabled = False

                e.Cancel = True
                Exit Sub
            Else
                '@=======================
                '@ [最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
                '@=======================
                lblnAns = prvblnSearchCondition_Chk(CMstrCalToDateValidate)

                '@[最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"True：検索条件All-OK"か
                If lblnAns = True Then

                    '@[最新取得]ﾎﾞﾀﾝを有効にする
                    cmdNowList.Enabled = True
                Else
                    '@[最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"False：検索条件設定不足"の場合

                    '@[最新取得]ﾎﾞﾀﾝを無効にする
                    cmdNowList.Enabled = False
                End If
            End If

            '@現在選択されている検索終了日を退避変数にｾｯﾄ
            mstrToDate = calToDate.Value

            '@[最新取得]ﾎﾞﾀﾝが有効か
            If cmdNowList.Enabled = True Then

                '@[最新取得]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(cmdNowList, calToDate)
            Else
                '@[閉じる]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(cmdClose, calToDate)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calToDate_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNowList_Click
    '機　能：[最新取得]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2013/01/30 (Wed) 16:02:50 Y.Yoneyama
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    '　　　：2013/01/30 (Wed) 16:02:50 Y.Yoneyama   組立投入日対応
    Private Sub cmdNowList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowList.Click

        Dim lblnAns             As Boolean          '戻り値格納用
        Dim ltypOpLotListReq    As New OpLotList()  'ﾛｯﾄ一覧情報取得要求構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の条件の場合は処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中(無効)の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If

            '@=======================
            '@ [最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnSearchCondition_Chk(CMstrCmdNowListClick)

            '@[最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理結果が"False：検索条件設定不足"か
            If lblnAns = False Then
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdNowListClick)

            '@=======================
            '@ ﾛｯﾄ一覧情報取得 要求構造体設定処理
            '@=======================
             Call prvOpLotListReq_Proc(ltypOpLotListReq)

            '@=======================
            '@ ﾛｯﾄ一覧情報取得
            '@=======================
            lblnAns = pubblnOpLotList2_Sel(ltypOpLotListReq, _
                                           mtypOpLotList, _
                                           mlngOpLotListCnt)

            '@[最新取得]ﾎﾞﾀﾝを有効にする
            cmdNowList.Enabled = True

            '@ﾛｯﾄ一覧情報取得結果が"True：通信成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdNowListClick)

                '@取得ﾛｯﾄ一覧情報が1件以上あるか
                If mlngOpLotListCnt > 0 Then

                    '@=======================
                    '@ [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ表示処理
                    '@=======================
                    Call prvvsfLotList_Disp(mtypOpLotList.typOpLotListList, mlngOpLotListCnt)

                    '@各種ｺﾝﾄﾛｰﾙを有効にする
                    calPlanFinishDate.Value = vbNullString '完成日
                    calPlanFinishDate.Enabled = True
                    calPlanShipDate.Value = vbNullString
                    calPlanShipDate.Enabled = True      '[送品予定日]ｶﾚﾝﾀﾞｰ
                    cmbPriority.Text = vbNullString
                    cmbPriority.Enabled = True          '[優先度]ｺﾝﾎﾞ
                    txtComments.Enabled = True          '[作業ﾒﾓ]ﾃｷｽﾄ
                    If pstrSBID = CPstrSBID1A0 Then
                        calPlanAssThrowDate.Value = vbNullString
                        calPlanAssThrowDate.Enabled = True
                                                        '[組立投入日]ｶﾚﾝﾀﾞｰ
                    End If
                    
                    '@[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞへﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(vsfLotList, cmdNowList, cmbPD, cmbFlowClass, cmdRegist)
                Else
                    '@取得ﾛｯﾄ一覧情報が0件の場合

                    '@[最新取得]ﾎﾞﾀﾝにﾌｫｰｶｽを留める
                    Call prvSetFocus(cmdNowList, cmdNowList, cmbPD, cmbFlowClass, cmdRegist)

                    '@=======================
                    '@ [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ初期化処理
                    '@=======================
                    Call prvvsfLotList_Init()
                End If

                '@各種ﾗﾍﾞﾙに情報をｾｯﾄ
                lblNowDate.Text = Format$(Now, CPstrDateFormat)                  '情報取得日時
                lblLotCnt.Text = Format$(mlngOpLotListCnt, CPstrDateFormatKanma)     '該当件数

            Else
                '@ﾛｯﾄ一覧情報取得結果が"False：通信失敗"の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdNowListClick)

                '@[最新取得]ﾎﾞﾀﾝにﾌｫｰｶｽを留める
                Call prvSetFocus(cmdNowList, cmdNowList, cmbPD, cmbFlowClass, cmdRegist)
                Exit Sub
            End If

            '「区間優先設定あり」表示なし
            lblSecPriority.Text = vbNullString

            '@=======================
            '@ [確定]ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvblnRegistButton_Proc()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNowList_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_AfterEdit
    '機　能：[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　編集後処理
    '引　数：Row：行番号
    '　　　：Col：列番号
    '戻り値：
    '作成日：2010/01/07 (Thu) 17:24:40 N.Kojima
    '更新日：2010/01/07 (Thu) 17:24:40
    '備　考：
    Private Sub vsfLotList_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfLotList.AfterEdit

        Try
            With vsfLotList

                '@編集対象が"優"(優先度)列、かつ変更前と値が異なるか
                If e.Col = CMlngvsfLotListColPriority And _
                    (.GetData(e.Row, CMlngvsfLotListColPriority) <> _
                    .GetData(e.Row, CMlngvsfLotListColBeforePriority)) Then

                    '@背景色をｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝに変更する
                    Dim newStyle As CellStyle
                    Dim oldStyle As CellStyle
                    Dim cellRange As CellRange = .GetCellRange(e.Row, e.Col)

                    'NSYS 文字色が適用済みか確認
                    If cellRange.Style IsNot Nothing AndAlso (cellRange.Style.DefinedElements And StyleElementFlags.ForeColor) Then
                        oldStyle = cellRange.Style
                        newStyle = .Styles.Add("CustomStyle_BackColor_CPlngSpecialEditColor_ForeColor_" & Hex(oldStyle.ForeColor.ToArgb))
                        newStyle.ForeColor = oldStyle.ForeColor
                    Else
                        newStyle = .Styles.Add("CustomStyle_BackColor_CPlngSpecialEditColor")
                    End If

                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngSpecialEditColor)
                    cellRange.Style = newStyle
                End If
            End With

            '@=======================
            '@ [確定]ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvblnRegistButton_Proc()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_AfterEdit"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_AfterSort
    '機　能：[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ｿｰﾄ後処理
    '引　数：Col    ：列番号
    '　　　：Order  ：ｿｰﾄ値
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub vsfLotList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotList.AfterSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If

            '@-----------------------
            '@ ｿｰﾄ情報格納
            '@-----------------------
            With mtypChgSort
                Dim ltypChgSortListTmp As ChgSortList

                .lngCnt = .lngCnt + 1
                ltypChgSortListTmp.lngCol = e.Col       'ｿｰﾄ列番号格納
                ltypChgSortListTmp.lngOrder = e.Order   '並び替え方法を格納(昇順/降順)

                .typChgSortList.Add(ltypChgSortListTmp)
            End With

            '@=======================
            '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納処理(ｸﾞﾘｯﾄﾞ、保持列)(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfAfterSort(vsfLotList, CMlngvsfStepLLRowTitle)

            'NSYS ソート時にBeforeRowColChangeイベントが発生し、検索キー mtypChgSort.strKey
            'NSYS が設定されるのを避けるため
            'NSYS 元に戻す
            AddHandler vsfLotList.BeforeRowColChange, AddressOf vsfLotList_BeforeRowColChange

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_AfterUserResize
    '機　能：[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ﾕｰｻﾞｰﾘｻｲｽﾞ後処理
    '引　数：Row    ：行番号
    '　　　：Col    ：列番号
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub vsfLotList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfLotList.AfterResizeColumn, vsfLotList.AfterResizeRow

        Try

            '@列幅変更ﾌﾗｸﾞに"True：変更"をｾｯﾄ
            mtypChgSort.blnChgWidth = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_BeforeRowColChange
    '機　能：[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ｶﾚﾝﾄｾﾙ変更前処理
    '引　数：OldRow ：旧行
    '　　　：OldCol ：旧列
    '　　　：NewRow ：新行
    '　　　：NewCol ：新列
    '　　　：Cancel ：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub vsfLotList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfLotList.BeforeRowColChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If

            '@旧行と新行が異なり、かつ新行がﾃﾞｰﾀ行か
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then

                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ﾛｯﾄID)
                mtypChgSort.strKey = vsfLotList.GetData(e.NewRange.r1, CMlngvsfLotListColLotID)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_BeforeSort
    '機　能：[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ｿｰﾄ前処理
    '引　数：Col    ：列番号
    '　　　：Order  ：ｿｰﾄ値
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub vsfLotList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotList.BeforeSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfLotList.Rows.Count <= vsfLotList.Rows.Fixed Then
                Return
            End If

            '@=======================
            '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納処理(ｸﾞﾘｯﾄﾞ、保持列)(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfBeforeSort(vsfLotList, CMlngvsfStepLLRowTitle)

            'NSYS ソート時にBeforeRowColChangeイベントが発生し、検索キー mtypChgSort.strKey
            'NSYS が設定されるのを避けるため
            RemoveHandler vsfLotList.BeforeRowColChange, AddressOf vsfLotList_BeforeRowColChange

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_Click
    '機　能：[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub vsfLotList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotList.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS カレントセルがデータ行でない場合は処理を抜ける
            If vsfLotList.Row < vsfLotList.Rows.Fixed Then
                Return
            End If

            'NSYS 見出しクリックの場合は処理を抜ける
            If vsfLotList.MouseRow < vsfLotList.Rows.Fixed Then
                Return
            End If

            '@=======================
            '@ [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ編集可否制御処理(ﾏｳｽﾄﾘｶﾞｰ、ﾏｳｽｲﾍﾞﾝﾄ)
            '@=======================
            Call prvVsfLotList_Edit(CMlngMouseClick, CMlngvsfMauseClickEvent)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_ComboCloseUp
    '機　能：[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ｸﾞﾘｯﾄﾞｺﾝﾎﾞ選択時処理
    '引　数：Row        ：行
    '　　　：Col        ：列
    '　　　：FinishEdit ：編集終了
    '戻り値：なし
    '作成日：2010/01/09 (Sat) 13:44:24 N.Kojima
    '更新日：2010/01/09 (Sat) 13:44:24
    '備　考：
    Private Sub vsfLotList_ComboCloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotList.ComboCloseUp

        Try

            With vsfLotList

                '@以下の場合は処理終了
                '@　①対象行がﾀｲﾄﾙ行
                '@　②対象列が"優(優先度)"列以外
                If .Row < .Rows.Fixed Or .Col <> CMlngvsfLotListColPriority Then
                    Exit Sub
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_ComboCloseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotList_KeyDown
    '機　能：[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ｷｰﾀﾞｳﾝ時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub vsfLotList_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles vsfLotList.KeyDown

        Try
            'NSYS カレントセルがデータ行でない場合は処理を抜ける
            If vsfLotList.Row < vsfLotList.Rows.Fixed Then
                Return
            End If

            '@=======================
            '@ [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ編集可否制御処理(ｷｰﾀﾞｳﾝﾄﾘｶﾞｰ、ｷｰｺｰﾄﾞ)
            '@=======================
            Call prvVsfLotList_Edit(CMlngKeyDown, e.KeyCode)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotList_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' [組立投入日]ｶﾚﾝﾀﾞｰ　変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub calPlanAssThrowDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calPlanAssThrowDate.Change

        Try

            '@=======================
            '@ 日付範囲ﾁｪｯｸ
            '@=======================
            '@変更後が有効日付範囲内か(1900/01/01～2100/12/31)
            If pubblnYearRange_Chk(calPlanAssThrowDate.Value) = True Then

                '@=======================
                '@ [組立投入日]ｶﾚﾝﾀﾞｰValidate処理
                '@=======================
                'NSYS 直接Validateを呼び出すと、CalendarExのMaskedTextBoxの選択状態が不安定になるため
                SendKeys.Send(CPstrSendKeysEnter)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calPlanAssThrowDate_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calPlanAssThrowDate_Validate
    '機　能：[組立投入日]ｶﾚﾝﾀﾞｰ　Validate処理(ﾌｫｰｶｽﾛｽﾄ時入力ﾁｪｯｸ処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2013/01/30 (Wed) 15:43:21 Y.Yoneyama
    '更新日：2013/01/30 (Wed) 15:43:21 Y.Yoneyama
    '備　考：
    Private Sub calPlanAssThrowDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calPlanAssThrowDate.Validating

        Dim lstrNowDT       As String       '現在日付取得
        Dim lblnErrChkFlag  As Boolean      'ｴﾗｰﾁｪｯｸﾌﾗｸﾞ(True：ｴﾗｰあり、False：ﾃﾞﾌｫﾙﾄ値)

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｴﾗｰﾁｪｯｸﾌﾗｸﾞの初期化
            lblnErrChkFlag = False

            '@-----------------------
            '@ 投入予定日ﾁｪｯｸ
            '@-----------------------
            With calPlanAssThrowDate

                '@現在日付取得
                lstrNowDT = Format$(Now, CPstrDateTimeYMD)

                '@投入予定日に"_"が含まれていないか
                If .Value <> CPstrNullDate Then

                    '@=======================
                    '@ 日付範囲ﾁｪｯｸ(1900/01/01～2100/12/31)
                    '@=======================
                    '@設定日付が有効範囲外か
                    If pubblnYearRange_Chk(.Value) = False Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM08W>$$正しい日付を入力してください。$1900年～2100年以外の日付は入力できません。"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@[送品予定日]ｶﾚﾝﾀﾞｰにﾌｫｰｶｽを留める
                        e.Cancel = True

                        '@ｴﾗｰﾁｪｯｸﾌﾗｸﾞに"True：ｴﾗｰあり"をｾｯﾄ
                        lblnErrChkFlag = True

                    Else
                        '@設定日付が有効範囲内の場合

                        '@設定日付が現在日付より過去か
                        If Format$(CDate(.Value), CPstrDateTimeYMD) < lstrNowDT Then

                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「"<TRM10W>$$過去の日付は指定できません。"」のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            '@[送品予定日]ｶﾚﾝﾀﾞｰにﾌｫｰｶｽを留める
                            e.Cancel = True

                            '@ｴﾗｰﾁｪｯｸﾌﾗｸﾞに"True：ｴﾗｰあり"をｾｯﾄ
                            lblnErrChkFlag = True

                        End If
                    End If
                Else
                    '@投入予定日が"____/__/__"の場合

                    '@ｴﾗｰﾁｪｯｸﾌﾗｸﾞに"True：ｴﾗｰあり"をｾｯﾄ
                    lblnErrChkFlag = False
                End If

            End With

            '@=======================
            '@ [確定]ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvblnRegistButton_Proc()


            '@ｴﾗｰﾁｪｯｸﾌﾗｸﾞが"False：ｴﾗｰなし"か
            If lblnErrChkFlag = False Then

                '@[優先度一括変更]ｺﾝﾎﾞが有効か
                If cmbPriority.Enabled = True Then
            
                    '@[優先度一括変更]ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(cmbPriority, calPlanAssThrowDate)
                Else
                    '@[閉じる]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(cmdClose, calPlanAssThrowDate)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calPlanAssThrowDate_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' [完成予定日]ｶﾚﾝﾀﾞｰ　変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub calPlanFinishDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calPlanFinishDate.Change

        Try

            '@=======================
            '@ 日付範囲ﾁｪｯｸ
            '@=======================
            '@変更後送品予定日が有効日付範囲内か(1900/01/01～2100/12/31)
            If pubblnYearRange_Chk(calPlanFinishDate.Value) = True Then

                '@=======================
                '@ [送品予定日]ｶﾚﾝﾀﾞｰValidate処理
                '@=======================
                'NSYS 直接Validateを呼び出すと、CalendarExのMaskedTextBoxの選択状態が不安定になるため
                SendKeys.Send(CPstrSendKeysEnter)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calPlanFinishDate_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' [完成予定日]ｶﾚﾝﾀﾞｰ　Validate処理(ﾌｫｰｶｽﾛｽﾄ時入力ﾁｪｯｸ処理)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>

    Private Sub calPlanFinishDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calPlanFinishDate.Validating

        Dim lstrNowDT       As String       '現在日付取得
        Dim lblnErrChkFlag  As Boolean      'ｴﾗｰﾁｪｯｸﾌﾗｸﾞ(True：ｴﾗｰあり、False：ﾃﾞﾌｫﾙﾄ値)

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｴﾗｰﾁｪｯｸﾌﾗｸﾞの初期化
            lblnErrChkFlag = False

            '@-----------------------
            '@ 完成予定日ﾁｪｯｸ
            '@-----------------------
            With calPlanFinishDate

                '@現在日付取得
                lstrNowDT = Format$(Now, CPstrDateTimeYMD)

                '@送品予定日に"_"が含まれていないか
                If .Value <> CPstrNullDate Then

                    '@=======================
                    '@ 日付範囲ﾁｪｯｸ(1900/01/01～2100/12/31)
                    '@=======================
                    '@設定日付が有効範囲外か
                    If pubblnYearRange_Chk(.Value) = False Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM08W>$$正しい日付を入力してください。$1900年～2100年以外の日付は入力できません。"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@[完成予定日]ｶﾚﾝﾀﾞｰにﾌｫｰｶｽを留める
                        e.Cancel = True

                        '@ｴﾗｰﾁｪｯｸﾌﾗｸﾞに"True：ｴﾗｰあり"をｾｯﾄ
                        lblnErrChkFlag = True

                    Else
                        '@設定日付が有効範囲内の場合

                        '@設定日付が現在日付より過去か
                        If Format$(CDate(.Value), CPstrDateTimeYMD) < lstrNowDT Then

                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「"<TRM10W>$$過去の日付は指定できません。"」のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            '@[完成予定日]ｶﾚﾝﾀﾞｰにﾌｫｰｶｽを留める
                            e.Cancel = True

                            '@ｴﾗｰﾁｪｯｸﾌﾗｸﾞに"True：ｴﾗｰあり"をｾｯﾄ
                            lblnErrChkFlag = True

                        End If
                    End If
                Else
                    '@送品予定日が"____/__/__"の場合

                    '@ｴﾗｰﾁｪｯｸﾌﾗｸﾞに"True：ｴﾗｰあり"をｾｯﾄ
                    lblnErrChkFlag = False
                End If

            End With

            '@=======================
            '@ [確定]ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvblnRegistButton_Proc()

            '@ｴﾗｰﾁｪｯｸﾌﾗｸﾞが"False：ｴﾗｰなし"か
            If lblnErrChkFlag = False Then

                '@[優先度一括変更]ｺﾝﾎﾞが有効か
                If cmbPriority.Enabled = True Then
            
                    '@[優先度一括変更]ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(cmbPriority, calPlanFinishDate)
                Else
                    '@[閉じる]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(cmdClose, calPlanFinishDate)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calPlanFinishDate_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' [送品予定日]ｶﾚﾝﾀﾞｰ　変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub calPlanShipDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calPlanShipDate.Change

        Try

            '@=======================
            '@ 日付範囲ﾁｪｯｸ
            '@=======================
            '@変更後送品予定日が有効日付範囲内か(1900/01/01～2100/12/31)
            If pubblnYearRange_Chk(calPlanShipDate.Value) = True Then

                '@=======================
                '@ [送品予定日]ｶﾚﾝﾀﾞｰValidate処理
                '@=======================
                'NSYS 直接Validateを呼び出すと、CalendarExのMaskedTextBoxの選択状態が不安定になるため
                SendKeys.Send(CPstrSendKeysEnter)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calPlanShipDate_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calPlanShipDate_Validate
    '機　能：[送品予定日]ｶﾚﾝﾀﾞｰ　Validate処理(ﾌｫｰｶｽﾛｽﾄ時入力ﾁｪｯｸ処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub calPlanShipDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calPlanShipDate.Validating

        Dim lstrNowDT       As String       '現在日付取得
        Dim lblnErrChkFlag  As Boolean      'ｴﾗｰﾁｪｯｸﾌﾗｸﾞ(True：ｴﾗｰあり、False：ﾃﾞﾌｫﾙﾄ値)

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｴﾗｰﾁｪｯｸﾌﾗｸﾞの初期化
            lblnErrChkFlag = False

            '@-----------------------
            '@ 送品予定日ﾁｪｯｸ
            '@-----------------------
            With calPlanShipDate

                '@現在日付取得
                lstrNowDT = Format$(Now, CPstrDateTimeYMD)

                '@送品予定日に"_"が含まれていないか
                If .Value <> CPstrNullDate Then

                    '@=======================
                    '@ 日付範囲ﾁｪｯｸ(1900/01/01～2100/12/31)
                    '@=======================
                    '@設定日付が有効範囲外か
                    If pubblnYearRange_Chk(.Value) = False Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM08W>$$正しい日付を入力してください。$1900年～2100年以外の日付は入力できません。"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@[送品予定日]ｶﾚﾝﾀﾞｰにﾌｫｰｶｽを留める
                        e.Cancel = True

                        '@ｴﾗｰﾁｪｯｸﾌﾗｸﾞに"True：ｴﾗｰあり"をｾｯﾄ
                        lblnErrChkFlag = True

                    Else
                        '@設定日付が有効範囲内の場合

                        '@設定日付が現在日付より過去か
                        If Format$(CDate(.Value), CPstrDateTimeYMD) < lstrNowDT Then

                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「"<TRM10W>$$過去の日付は指定できません。"」のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            '@[送品予定日]ｶﾚﾝﾀﾞｰにﾌｫｰｶｽを留める
                            e.Cancel = True

                            '@ｴﾗｰﾁｪｯｸﾌﾗｸﾞに"True：ｴﾗｰあり"をｾｯﾄ
                            lblnErrChkFlag = True

                        End If
                    End If
                Else
                    '@送品予定日が"____/__/__"の場合

                    '@ｴﾗｰﾁｪｯｸﾌﾗｸﾞに"True：ｴﾗｰあり"をｾｯﾄ
                    lblnErrChkFlag = False
                End If

            End With

            '@=======================
            '@ [確定]ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvblnRegistButton_Proc()

            '@ｴﾗｰﾁｪｯｸﾌﾗｸﾞが"False：ｴﾗｰなし"か
            If lblnErrChkFlag = False Then

                '@[優先度一括変更]ｺﾝﾎﾞが有効か
                If cmbPriority.Enabled = True Then
            
                    '@[優先度一括変更]ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(cmbPriority, calPlanShipDate)
                Else
                    '@[閉じる]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(cmdClose, calPlanShipDate)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calPlanShipDate_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' [優先度一括変更]ｺﾝﾎﾞ　変更時処理
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmbPriority_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPriority.Change

        Try
            '@=======================
            '@ [確定]ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvblnRegistButton_Proc()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPriority_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPriority_CloseUp
    '機　能：[優先度一括変更]ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2010/01/12 (Tue) 10:45:39 N.Kojima
    '更新日：2010/01/12 (Tue) 10:45:39
    '備　考：
    Private Sub cmbPriority_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPriority.CloseUp

        Try
            '@[確定]ﾎﾞﾀﾝが有効か
            If cmdRegist.Enabled = True Then

                '@[確定]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(cmdRegist, cmbPriority)
            Else
                '@[作業ﾒﾓ]ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(txtComments, cmbPriority)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPriority_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComments_Change
    '機　能：[作業ﾒﾓ]ﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub txtComments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtComments.Change

        Dim llngNowByte     As Integer  'ｺﾒﾝﾄ桁数

        Try

            '@現状のﾊﾞｲﾄ数を格納
            llngNowByte = txtComments.NowByte

            '@=======================
            '@ 表示ﾒｯｾｰｼﾞ変換処理
            '@=======================
            '@現在のﾊﾞｲﾄ数を表示
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)

            '@=======================
            '@ ﾃｷｽﾄ変更処理(ﾃｷｽﾄ共通仕様)
            '@=======================
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdSUp, cmdSDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComments_KeyUp
    '機　能：[作業ﾒﾓ]　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub txtComments_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtComments.KeyUp

        Try

            '@=======================
            '@ ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作(ﾃｷｽﾄ共通仕様)
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtComments, CMlngMaxDispRow, cmdSUp, cmdSDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComments_MouseUp
    '機　能：[作業ﾒﾓ]　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub txtComments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtComments.MouseUp

        Try

            '@=======================
            '@ ﾃｷｽﾄ変更処理(ﾃｷｽﾄ共通仕様)
            '@=======================
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdSUp, cmdSDown, e.Button)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSUp_Click
    '機　能：[上(▲)]ｽｸﾛｰﾙﾎﾞﾀﾝ(作業ﾒﾓ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/06/16 (Mon) 09:29:28 Y.Tomiya
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub cmdSUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@ ﾃｷｽﾄ上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ押下時処理(ﾃｷｽﾄ共通仕様)
            '@=======================
            Call pubtxtCmdUp_Proc(txtComments, CMlngMaxDispRow, cmdSUp, cmdSDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSUp_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSDown_Click
    '機　能：[下(▼)]ｽｸﾛｰﾙﾎﾞﾀﾝ(作業ﾒﾓ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/06/16 (Mon) 09:29:28 Y.Tomiya
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub cmdSDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@ ﾃｷｽﾄ下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ押下時処理(ﾃｷｽﾄ共通仕様)
            '@=======================
            Call pubtxtCmdDown_Proc(txtComments, CMlngMaxDispRow, cmdSUp, cmdSDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSDown_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：[確定]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2013/01/30 (Wed) 15:47:09 Y.Yoneyama
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    '　　　：2013/01/30 (Wed) 15:47:09 Y.Yoneyama   組立投入日追加
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean
        Dim ltypLotchgAttributes    As New LotchgAttributes
        Dim llngLotCnt              As Integer

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の場合、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If


            '@更新ﾛｯﾄ情報格納用構造体の初期化
            ltypLotchgAttributes.typChgAttrList = Nothing

            '@=======================
            '@ 更新ﾃﾞｰﾀ検索処理
            '@=======================
            lblnAns = prvblnUpdateData_Chk()

            '@変更対象ﾃﾞｰﾀ検索処理結果が"False：更新ﾃﾞｰﾀなし"か
            If lblnAns = False Then
                Exit Sub
            End If


            '@=======================
            '@ 権限ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnRegistAuthority_Chk

            '@権限ﾁｪｯｸ処理結果が"False：権限なし"か
            If lblnAns = False Then
                Exit Sub
            End If


            '@=======================
            '@ 更新ﾛｯﾄ情報設定処理
            '@=======================
            Call prvLotChgAttributesData_Set(ltypLotchgAttributes, llngLotCnt)


            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)

            '@=======================
            '@ ﾛｯﾄ情報一括変更
            '@=======================
            lblnAns = pubblnLotChgAttributes_Upd(ltypLotchgAttributes, llngLotCnt)

            '@ﾛｯﾄ情報一括変更処理結果が"True：更新成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)

                '@「"<TRM1ZI>$$ロット情報を変更しました。"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001Z)
                Call pubVsfInfo_Disp(pstrDMsg)

                '@=======================
                '@ [最新取得]ﾎﾞﾀﾝ押下処理
                '@=======================
                Call cmdNowList_Click(cmdNowList, EventArgs.Empty)

                '@各種ｺﾝﾄﾛｰﾙの初期化
                calPlanFinishDate.Value = vbNullString      '[完成予定日]
                calPlanShipDate.Value = vbNullString        '[送品予定日]
                calPlanAssThrowDate.Value = vbNullString    '[組立投入日]
                cmbPriority.Text = vbNullString             '[優先度一括変更]
                txtComments.Text = vbNullString             '[作業ﾒﾓ]

            Else
                '@ﾛｯﾄ情報一括変更処理結果が"False：更新失敗"の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)

                '@[確定]ﾎﾞﾀﾝにﾌｫｰｶｽ保持
                Call prvSetFocus(cmdRegist, cmdRegist)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRegist_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：[閉じる]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim ltypCommonInfo  As CommonInfo

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@ 終了処理(共通処理)
            '@=======================
            Call publngEnd_Proc(CPstrKeyEN02B0, ltypCommonInfo)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClose_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' オプション選択（流動中）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub optWork_CheckedChanged(sender As Object, e As EventArgs) Handles optWork.CheckedChanged
        Try
            If optWork.Checked = False Then
                Exit Sub
            End If

            '最新情報の取得
            If cmdNowList.Enabled = True Then
                Call cmdNowList_Click(sender, e)
            End If

            Exit Sub

        Catch ex As Exception
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optWork_CheckedChanged"
                .strErrMessage = vbNullString
            End With
            Call pubOnError_Proc()
        End Try
    End Sub

    ''' <summary>
    ''' オプション選択（在庫）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub optInventory_CheckedChanged(sender As Object, e As EventArgs) Handles optInventory.CheckedChanged
        Try
            If optInventory.Checked = False Then
                Exit Sub
            End If

            '最新情報の取得
            If cmdNowList.Enabled = True Then
                Call cmdNowList_Click(sender, e)
            End If

            Exit Sub

        Catch ex As Exception
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optInventory_CheckedChanged"
                .strErrMessage = vbNullString
            End With
            Call pubOnError_Proc()
        End Try
    End Sub

    ''' <summary>
    ''' オプション選択（流動中）Click
    ''' optWork.AutoCheck = False の設定でClickイベントが最初に発生、その代わり、Checked処理が必要
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub optWork_Click(sender As Object, e As EventArgs) Handles optWork.Click
 
        Dim lintAns As Integer

        Try
            If optWork.Checked = False Then
                '登録ボタンが有効の場合
                '編集中と判断して閉じる前にユーザー確認
                If cmdRegist.Enabled = True Then

                    '"編集中です。 内容を破棄してよろしいですか？"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001A)
                    lintAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                    'NO
                    If lintAns = vbNo Then
                        Exit Sub
                    End If
                End If
                optInventory.Checked = False
                optWork.Checked = True
            End If

            Exit Sub

        Catch ex As Exception
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optWork_Click"
                .strErrMessage = vbNullString
            End With
            Call pubOnError_Proc()
        End Try
    End Sub

    ''' <summary>
    ''' オプション選択（在庫）Click
    ''' optInventory.AutoCheck = False の設定でClickイベントが最初に発生、その代わり、Checked処理が必要
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub optInventory_Click(sender As Object, e As EventArgs) Handles optInventory.Click
        
        Dim lintAns As Integer

        Try
            If optInventory.Checked = False Then
                '登録ボタンが有効の場合
                '編集中と判断して閉じる前にユーザー確認
                If cmdRegist.Enabled = True Then

                    '"編集中です。 内容を破棄してよろしいですか？"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001A)
                    lintAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                    'NO
                    If lintAns = vbNo Then
                        Exit Sub
                    End If
                End If
                optWork.Checked = False
                optInventory.Checked = True
            End If

            Exit Sub

        Catch ex As Exception
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optInventory_Click"
                .strErrMessage = vbNullString
            End With
            Call pubOnError_Proc()
        End Try
    End Sub


    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：prvFrmxxEN02B0_Init
    '機　能：画面初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2011/10/05 (Wed) 15:04:23 T.Oide
    '備　考：
    '　　　：2009/12/21 (Mon) 19:19:38 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    '　　　：2011/10/05 (Wed) 15:04:19 T.Oide       R8-4区間優先設定対応<REQ-1109>
    Private Sub prvFrmxxEN02B0_Init()

        Dim lstrFormTitle  As String = vbNullString 'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        Dim llngNowByte    As Integer   '現在Byte格納用
        Dim lctlControl    As Control   'ｺﾝﾄﾛｰﾙ名称取得用変数

        Try
            '@=======================
            '@ 機能関連情報取得
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN02B0, lstrFormTitle)

            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle

            '@-----------------------
            '@ 各種ﾓｼﾞｭｰﾙ変数の初期化
            '@-----------------------
            mblnPDIDChgFlag = False             '[機種]変更ﾌﾗｸﾞ
            mblnFlowClassChgFlag = False        '[種別]変更ﾌﾗｸﾞ
            mstrOpID = vbNullString             '大工程退避用
            mstrStepID = vbNullString           '小工程退避用
            mblnFromDateChgFlag = False         '検索開始日変更ﾌﾗｸﾞ
            mblnToDateChgFlag = False           '検索終了日変更ﾌﾗｸﾞ
            mstrFromDate = vbNullString         '検索開始日退避用
            mstrToDate = vbNullString           '検索終了日退避用
            mblnEditFlag = False                '編集ﾌﾗｸﾞ

            '@-----------------------
            '@ 優先度一括変更の横のラベル初期化
            '@-----------------------
            lblSecPriority.Text = vbNullString

            '@-----------------------
            '@ 各種ｺﾝﾎﾞの初期化
            '@-----------------------
            '@各種ｺﾝﾎﾞ一覧の初期化
            cmbPD.Clear                         '[機種]
            cmbFlowClass.Clear                  '[種別]

            'NSYS コンボボックスの背景色が灰色になるため、白を設定
            cmbFlowClass.BackColor = SystemColors.Window
            cmbOpID.BackColor = SystemColors.Window
            cmbPD.BackColor = SystemColors.Window
            cmbPriority.BackColor = SystemColors.Window
            cmbStepID.BackColor = SystemColors.Window

            '@各種ｺﾝﾎﾞﾎﾞｯｸｽの初期化(大工程、小工程、優先度)
            For Each lctlControl In GetAllControls(Me)

                If TypeOf lctlControl Is SEComboBoxEx.ComboBoxEx Then

                    With CType(lctlControl, SEComboBoxEx.ComboBoxEx)

                        .Clear                                                          'ｸﾘｱ
                        .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                        .GetCol = CMlngCmbGridColName                                   'ﾃｷｽﾄ表示列
                        .ValueCol = CMlngCmbGridColID                                   '値取得列
                        .DirectInput = False                                            'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                        With .Font                                                      'ﾌｫﾝﾄｻｲｽﾞ
                            CType(lctlControl, SEComboBoxEx.ComboBoxEx).Font = _
                                New Font(.FontFamily, CMlngCmbFontSize, .Style, _
                                            .Unit, .GdiCharSet, .GdiVerticalFont)
                        End With
                        With .GridFont                                                  'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                            CType(lctlControl, SEComboBoxEx.ComboBoxEx).GridFont = _
                                New Font(.FontFamily, CMlngCmbGridFontSize, .Style, _
                                            .Unit, .GdiCharSet, .GdiVerticalFont)
                        End With
                        .RowHeight = CMlngCmbRowHeight                                  '行の高さ
                        .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter   '左寄中央揃え
                        .Enabled = False                                                '無効
                    End With
                End If
            Next

            '@-----------------------
            '@ 各種ｶﾚﾝﾀﾞｰの初期化＆設定
            '@ ※対象：検索開始日、検索終了日、送品予定日
            '@-----------------------
            For Each lctlControl In GetAllControls(Me)

                If TypeOf lctlControl Is SECalendarEx.CalendarEx Then

                    With CType(lctlControl, SECalendarEx.CalendarEx)

                        .CalendarHeight = CPlngMClHeight            '高さ
                        .CalendarWidth = CPlngMClWidth              '幅
                        With .Font                                  'ﾌｫﾝﾄｻｲｽﾞ
                            CType(lctlControl, SECalendarEx.CalendarEx).DayFont = _
                                New Font(.FontFamily, CPlngMClFontSize, .Style, _
                                            .Unit, .GdiCharSet, .GdiVerticalFont)
                        End With
                        With .Font                                  'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
                            CType(lctlControl, SECalendarEx.CalendarEx).TitleFont = _
                                New Font(.FontFamily, CPlngMClTlFontSize, .Style, _
                                            .Unit, .GdiCharSet, .GdiVerticalFont)
                        End With
                        With .Font                                  'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                            CType(lctlControl, SECalendarEx.CalendarEx).GridFont = _
                                New Font(.FontFamily, CPlngMClGridFontSize, .Style, _
                                            .Unit, .GdiCharSet, .GdiVerticalFont)
                        End With
                        .Value = CPstrNullDate                      'ﾃｷｽﾄ(____/__/__)
                        .Enabled = False                            '無効
                    End With
                End If
            Next

            '@-----------------------
            '@ [作業ﾒﾓ]ﾃｷｽﾄの初期化
            '@-----------------------
            txtComments.Enabled = False         '無効
            llngNowByte = txtComments.NowByte   '現在ﾊﾞｲﾄ数

            '@=======================
            '@ 現在ﾊﾞｲﾄ数の表示変化処理(共通処理)
            '@=======================
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)

            '@-----------------------
            '@ 各種ﾁｪｯｸﾎﾞｯｸｽの初期化
            '@-----------------------
            chkProcess.Checked = False          '工程指定(大工程、小工程)
            chkThisMonth.Checked = False        '当月(送品予定日)
            chkNextMonth.Checked = False        '次月(送品予定日)
            chkPlanShipDate.Checked = False     '期間指定(送品予定日)

            '@-----------------------
            '@ 各種ﾎﾞﾀﾝの初期化
            '@-----------------------
            cmdSUp.Enabled = False
            cmdSDown.Enabled = False
            cmdRegist.Enabled = False           '[確定]
            cmdNowList.Enabled = False          '[最新取得]

            'オプション選択
            optWork.AutoCheck = False       '自動変更なし
            optInventory.AutoCheck = False  '自動変更なし
            optWork.Checked = True          '流動ロットを初期値
            optInventory.Checked = False    '在庫ロットはOFF
            '基板工程の場合
            If pstrSBID = CPstrSBID1A0 Then
                optWork.Visible = True
                optInventory.Visible = True
                lblMemo1A0.Visible = True
            Else
                optWork.Visible = False
                optInventory.Visible = False
                lblMemo1A0.Visible = False
            End If

            '完成予定日カレンダー(非表示)
            lblPlanFinishDate.Visible = False
            calPlanFinishDate.Visible = False

            '@閉じるﾎﾞﾀﾝのCausesValidationを設定(False：ﾌｫｰｶｽLost時に入力値ﾁｪｯｸを行わない)
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN02B0_Init"
                .strErrMessage = vbNullString
            End With
            
            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfLotList_Init
    '機　能：[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2013/01/30 (Wed) 14:43:45 Y.Yoneyama
    '備　考：
    '　　　：2009/12/22 (Tue) 12:59:55 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    '　　　：2013/01/30 (Wed) 14:43:45 Y.Yoneyama   進捗度対応
    Private Sub prvvsfLotList_Init()

        Try

            With vsfLotList

                .Rows.Count = .Rows.Fixed                       '行数設定
        '@↓2011/10/03 (Mon) 16:05:03 Y.Yoneyama **************************************************
                '.Cols = CMlngvsfLotListColEditEmpName + 1   '列数設定
        '@↑2011/10/03 (Mon) 16:05:03 Y.Yoneyama **************************************************

                '@-----------------------
                '@ ﾀｲﾄﾙ行設定
                '@-----------------------
                .Select(CMlngvsfStepLLRowTitle, CMlngvsfLotListColNo, CMlngvsfStepLLRowTitle, .Cols.Count - 1)
                Dim lFixedStyle As CellStyle = .Styles.Fixed
                lFixedStyle.ForeColor = Color.Yellow                                                '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)                   '背景色
                With .Font                                                                          'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                    lFixedStyle.Font = New Font(.FontFamily, CMlngvsfStepLLHFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With


                '@ﾕｰｻﾞｰにより列幅変更されていないか
                If mtypChgSort.blnChgWidth = False Then

                    '@-----------------------
                    '@ 列幅設定
                    '@-----------------------
                    .Cols(CMlngvsfLotListColNo).Width = CMlngvsfLotListColWNo
                    .Cols(CMlngvsfLotListColPlanShipDate).Width = CMlngvsfLotListColWPlanShipDate
                    .Cols(CMlngvsfLotListColSendSbName).Width = CMlngvsfLotListColWSendSbName
                    .Cols(CMlngvsfLotListColPlanAssThrowDate).Width = CMlngvsfLotListColWPlanAssThrowDate
                    .Cols(CMlngvsfLotListColShipDiffDay).Width = CMlngvsfLotListColWShipDiffDay
                    .Cols(CMlngvsfLotListColLotID).Width = CMlngvsfLotListColWLotID
                    .Cols(CMlngvsfLotListColLotStatus).Width = CMlngvsfLotListColWLotStatus
                    .Cols(CMlngvsfLotListColFlowClass).Width = CMlngvsfLotListColWFlowClass
                    .Cols(CMlngvsfLotListColPriority).Width = CMlngvsfLotListColWPriority
                    .Cols(CMlngvsfLotListColBeforePriority).Width = CMlngvsfLotListColWBeforePriority
                    .Cols(CMlngvsfLotListColSecPriorityFlag).Width = CMlngvsfLotListColWSecPriorityFlag
                    .Cols(CMlngvsfLotListColPdID).Width = CMlngvsfLotListColWPdID
                    .Cols(CMlngvsfLotListColWfNum).Width = CMlngvsfLotListColWWfNum
                    .Cols(CMlngvsfLotListColCfNum).Width = CMlngvsfLotListColWCfNum
                    .Cols(CMlngvsfLotListColOpID).Width = CMlngvsfLotListColWOpID
                    .Cols(CMlngvsfLotListColStepID).Width = CMlngvsfLotListColWStepID
                    .Cols(CMlngvsfLotListColPlanFinishDate).Width = CMlngvsfLotListColWPlanFinishDate
                    .Cols(CMlngvsfLotListColEditLastUpdate).Width = CMlngvsfLotListColWEditLastUpdate
                    .Cols(CMlngvsfLotListColEditEmpName).Width = CMlngvsfLotListColWEditEmpName
                End If

                '@-----------------------
                '@ ﾀｲﾄﾙ設定
                '@-----------------------
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfLotListColNo, CMstrvsfStepLLColTNo)                          'No.
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfLotListColPlanShipDate, CMstrvsfStepLLColTPlanShipDate)      '送品日
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfLotListColSendSbName, CMstrvsfStepLLColTSendSbName)          '送品先
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfLotListColPlanAssThrowDate, CMstrvsfStepLLColTPlanAssThrowDate)    '組立投入日                                                                                                            
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfLotListColShipDiffDay, CMstrvsfStepLLColTShipDiffDay)        '進捗度
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfLotListColLotID, CMstrvsfStepLLColTLotID)                    'ﾛｯﾄID
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfLotListColLotStatus, CMstrvsfStepLLColTLotStatus)            '状態
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfLotListColFlowClass, CMstrvsfStepLLColTFlowClass)            '種別(流動区分)
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfLotListColPriority, CMstrvsfStepLLColTPriority)              '優先度
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfLotListColBeforePriority, CMstrvsfStepLLColTBeforePriority)  '変更前優先度
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfLotListColSecPriorityFlag, CMstrvsfStepLLColTSecPriorityFlag)  '区間優先度ﾌﾗｸﾞ
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfLotListColPdID, CMstrvsfStepLLColTPdID)                      'ﾛｯﾄ位置
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfLotListColWfNum, CMstrvsfStepLLColTWfNum)                    'WF枚数
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfLotListColCfNum, CMstrvsfStepLLColTCfNum)                    'ﾁｯﾌﾟ
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfLotListColOpID, CMstrvsfStepLLColTOpID)                      'ﾛｯﾄ状態
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfLotListColStepID, CMstrvsfStepLLColTStepID)                  'ｷｬﾘｱID
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfLotListColPlanFinishDate, CMstrvsfStepLLColTPlanFinishDate)  '送品予定日
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfLotListColEditLastUpdate, CMstrvsfStepLLColTEditLastUpdate)  '(LOT_EVENT_ID=14の)最終更新日時
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfLotListColEditEmpName, CMstrvsfStepLLColTEditEmpName)        '(LOT_EVENT_ID=14の)最終更新者

                '@表示位置の設定
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter

                '@ﾍｯﾀﾞｰ行の高さ設定
                .Rows(CMlngvsfStepLLRowTitle).Height = CMlngvsfStepLLHHeight

                '@固定列の設定(固定列なし)
                .Cols.Frozen = CMlngvsfFrozenCols

                '@ﾏｳｽによる列ｻｲｽﾞ変更の可/不可設定
                .AllowResizing = AllowResizingEnum.Columns

                '@ﾕｰｻﾞｰによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then

                    '@ｵｰﾄﾘｻｲｽﾞ設定
                    .AutoSizeCols(CMlngvsfLotListColCheck, .Cols.Count - 1, 6)
                End If


                '@起動SBが"1A0：基板"か
                If pstrSBID = CPstrSBID1A0 Then

                    '@以下の列は表示
                    .Cols(CMlngvsfLotListColPlanAssThrowDate).Visible = True    '組立投入日
                    .Cols(CMlngvsfLotListColShipDiffDay).Visible = True         '進捗度
                    .Cols(CMlngvsfLotListColEditLastUpdate).Visible = True      '(LOT_EVENT_ID=14の)最終更新日時
                    .Cols(CMlngvsfLotListColEditEmpName).Visible = True         '(LOT_EVENT_ID=14の)最終更新者

                    '@以下の列は非表示
                    .Cols(CMlngvsfLotListColSendSbName).Visible = False         '送品先
                    .Cols(CMlngvsfLotListColCfNum).Visible = False              'ﾁｯﾌﾟ
                    .Cols(CMlngvsfLotListColPlanFinishDate).Visible = False     '完成予定日

                Else
                    '@"2A0：組立"起動の場合

                    '@以下の列は表示
                    .Cols(CMlngvsfLotListColSendSbName).Visible = True          '送品先
                    .Cols(CMlngvsfLotListColCfNum).Visible = True               'ﾁｯﾌﾟ
                    .Cols(CMlngvsfLotListColPlanFinishDate).Visible = True      '完成予定日

                    '@以下の列は非表示
                    .Cols(CMlngvsfLotListColPlanAssThrowDate).Visible = False   '組立投入日
                    .Cols(CMlngvsfLotListColShipDiffDay).Visible = False        '進捗度
                    .Cols(CMlngvsfLotListColEditLastUpdate).Visible = False     '(LOT_EVENT_ID=14の)最終更新日時
                    .Cols(CMlngvsfLotListColEditEmpName).Visible = False        '(LOT_EVENT_ID=14の)最終更新者
                End If

                .Cols(CMlngvsfLotListColShipDiffDay).DataType = GetType(Single) 'NSYS 進捗度列のDataTypeを設定
                .Cols(CMlngvsfLotListColShipDiffDay).Format = "##0.0"           'NSYS 進捗度列のフォーマットを設定

                '@各種ﾗﾍﾞﾙの初期化
                lblNowDate.Text = vbNullString       '情報取得日時
                lblLotCnt.Text = vbNullString        '該当件数

                '@各種ｺﾝﾄﾛｰﾙをｸﾘｱし、無効にする
                calPlanFinishDate.Value = vbNullString
                calPlanFinishDate.Enabled = False
                calPlanShipDate.Value = vbNullString
                calPlanShipDate.Enabled = False
                calPlanAssThrowDate.Value = vbNullString
                calPlanAssThrowDate.Enabled = False
                cmbPriority.Text = vbNullString
                cmbPriority.Enabled = False

                '@[確定]ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False

                '@ｸﾞﾘｯﾄﾞを無効にする
                .Enabled = False

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfLotList_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbPd_Disp
    '機　能：[機種]ｺﾝﾎﾞ設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2009/12/22 (Tue) 13:19:36 N.Kojima
    '備　考：
    '　　　：2009/12/22 (Tue) 13:19:36 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub prvcmbPd_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            '@-----------------------
            '@ [機種]ｺﾝﾎﾞ設定
            '@-----------------------
            With cmbPD

                .Clear                                                          'ｸﾘｱ
                .Enabled = True                                                 '有効
                .DirectInput = False                                            '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = CMlngCmbDispCols                                   '列方向のﾚｺｰﾄﾞ数
                .GroupRows = mlngProductListCnt                                 '行方向のﾚｺｰﾄﾞ数
                .AddedComment = CMstrCmbAddedComment                            '"選択"文字列
                With .Font                                                      'ﾌｫﾝﾄｻｲｽﾞ
                    cmbPD.Font = _
                        New Font(.FontFamily, CMlngCmbFontSize, .Style, _
                                    .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                With .GridFont                                                  'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    cmbPD.GridFont = _
                        New Font(.FontFamily, CMlngCmbGridFontSize, .Style, _
                                    .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え

                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                For llngCnt = 0 To mlngProductListCnt - 1

                    '@機種ID/機種名/Index/NULL
                    .AddItem(mtypProductList(llngCnt).strProductID & vbTab & _
                            mtypProductList(llngCnt).strProductName & vbTab & _
                            llngCnt & vbTab & _
                            vbNullString)
                Next llngCnt

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbPd_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbFlowClass_Disp
    '機　能：[種別]ｺﾝﾎﾞ設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2009/12/22 (Tue) 13:19:36 N.Kojima
    '備　考：
    '　　　：2009/12/22 (Tue) 13:19:36 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub prvcmbFlowClass_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            '@-----------------------
            '@ [種別]ｺﾝﾎﾞ設定
            '@-----------------------
            With cmbFlowClass

                .Clear                                                          'ｸﾘｱ
                .Enabled = True                                                 '有効
                .DirectInput = False                                            '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = CMlngCmbDispCols                                   '列方向のﾚｺｰﾄﾞ数
                .GroupRows = mlngDivisionListCnt                                '行方向のﾚｺｰﾄﾞ数
                .AddedComment = CMstrCmbAddedComment                            '"選択"文字列
                With .Font                                                      'ﾌｫﾝﾄｻｲｽﾞ
                    cmbFlowClass.Font = _
                        New Font(.FontFamily, CMlngCmbFontSize, .Style, _
                                    .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                With .GridFont                                                  'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    cmbFlowClass.GridFont = _
                        New Font(.FontFamily, CMlngCmbGridFontSize, .Style, _
                                    .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え

                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                For llngCnt = 0 To mlngDivisionListCnt - 1

                    '@種別ID/Index/NULL/NULL
                    .AddItem(mtypDivisionList(llngCnt).strDivisionID & vbTab & _
                            llngCnt & vbTab & _
                            vbNullString & vbTab & _
                            vbNullString)
                Next llngCnt

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbFlowClass_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbOpID_Disp
    '機　能：[大工程]ｺﾝﾎﾞ設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/12/24 (Thu) 11:42:09 N.Kojima
    '更新日：2009/12/24 (Thu) 11:42:09
    '備　考：
    Private Sub prvCmbOpID_Disp()

        Dim llngCnt     As Integer  'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            '@-----------------------
            '@ [大工程]ｺﾝﾎﾞ設定
            '@-----------------------
            With cmbOpID

                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                For llngCnt = 0 To mtypMasOpList.lngMasOpCnt - 1

                    '@大工程ID/Index
                    .AddItem(mtypMasOpList.typMasOpId(llngCnt).strOpID & _
                             vbTab & _
                             CStr(llngCnt + 1))
                Next llngCnt

                '@大工程が1件か
                If .ListCount = 1 Then

                    '@ﾃﾞﾌｫﾙﾄで直接表示
                    .ListIndex = 0
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbOpID_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbStepID_Disp
    '機　能：[小工程]ｺﾝﾎﾞ設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/12/24 (Thu) 11:42:09 N.Kojima
    '更新日：2009/12/24 (Thu) 11:42:09
    '備　考：
    Private Sub prvCmbStepID_Disp()

        Dim llngCnt     As Integer  'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            '@-----------------------
            '@ [小工程]ｺﾝﾎﾞ設定
            '@-----------------------
            With cmbStepID

                .Clear

                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                For llngCnt = 0 To mtypMasStepList.lngMasStepCnt - 1

                    '@小工程ID/Index
                    .AddItem(mtypMasStepList.typMasStepId(llngCnt).strStepID & _
                             vbTab & _
                             CStr(llngCnt + 1))
                Next llngCnt

                '@小工程が1件か
                If .ListCount = 1 Then

                    '@ﾃﾞﾌｫﾙﾄで直接表示
                    .ListIndex = 0
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbStepID_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbPriority_Disp
    '機　能：[優先度一括変更]ｺﾝﾎﾞ設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/12/24 (Thu) 11:42:09 N.Kojima
    '更新日：2009/12/24 (Thu) 11:42:09
    '備　考：
    Private Sub prvCmbPriority_Disp()

        Dim llngCnt     As Integer  'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            '@-----------------------
            '@ [優先度一括変更]ｺﾝﾎﾞ設定
            '@-----------------------
            With cmbPriority

                .Clear
                
                For llngCnt = 0 To mtypPriorityReasonList.Count - 1

                    '@「優先度ID＋""＋優先度名」(例：1 鈍行)/優先度ID
                    .AddItem(mtypPriorityReasonList(llngCnt).strMasPriorityId & CPstrSpace & _
                             mtypPriorityReasonList(llngCnt).strMasPriorityName & vbTab & _
                             mtypPriorityReasonList(llngCnt).strMasPriorityId)
                Next llngCnt
                
                '@優先度が1件か
                If .ListCount = 1 Then

                    '@1件のﾃﾞｰﾀを表示
                    .ListIndex = 0
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbPriority_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotList_Disp
    '機　能：[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ表示処理
    '引　数：ltypOpLotList      ：ﾛｯﾄ一覧情報格納構造体
    '　　　：ltypOpLotListCnt   ：ﾛｯﾄ一覧ﾃﾞｰﾀ件数
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2013/01/30 (Wed) 14:43:45 Y.Yoneyama
    '備　考：
    '　　　：2009/02/25 (Wed) 11:32:22 N.Kojima     起動SBが組立、かつ送品先が"7x0：ﾁｯﾌﾟ品"だったらﾌｫﾝﾄの色を青にする。(案件№03402)
    '　　　：2009/12/01 (Tue) 18:34:40 H.Hayashi    ﾁｯﾌﾟ品判定ﾛｼﾞｯｸ部変更。(案件No.03810)
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    '　　　：2011/10/05 (Wed) 11:29:42 T.Oide       R8-4区間優先対応<REQ-1109>
    '　　　：2013/01/30 (Wed) 14:43:45 Y.Yoneyama   進捗度対応
    Private Sub prvvsfLotList_Disp(ByRef ltypOpLotList As List(Of OpLotListList), _
                                   ByVal ltypOpLotListCnt As Integer)

        Dim llngDoCnt           As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt             As Integer      'ｶｳﾝﾄ
        Dim lstrSpecialStatus   As String       '特殊流動状態表示用

        Try

            vsfLotList.Redraw = False                       '描画ﾛｯｸ

            '@=======================
            '@ [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ初期化処理
            '@=======================
            vsfLotList.Row = -1
            vsfLotList.Rows.Count = vsfLotList.Rows.Fixed

            '@ﾛｯﾄ一覧ﾃﾞｰﾀ件数が0件か
            If ltypOpLotListCnt = 0 Then
                vsfLotList.Select(CMlngvsfStepLLRowTitle, CMlngvsfLotListColNo）
                vsfLotList.Redraw = True
                Exit Sub
            End If

            'NSYS BeforeRowColChangeイベントを抑止し、ボタンの状態変更やｿｰﾄ検索用ｷｰ設定を抑える
            RemoveHandler vsfLotList.BeforeRowColChange, AddressOf vsfLotList_BeforeRowColChange

            '@-----------------------
            '@ [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ設定
            '@-----------------------
            With vsfLotList

                .Rows.Count = ltypOpLotListCnt + 1    '行数設定

                '@ﾙｰﾌﾟｶｳﾝﾀの初期化
                llngDoCnt = 1

                Do While .Rows.Count > llngDoCnt

                    .SetData(llngDoCnt, CMlngvsfLotListColNo, llngDoCnt)                        '№

                    .SetCellCheck(llngDoCnt, CMlngvsfLotListColCheck, CheckEnum.Unchecked)      'ﾁｪｯｸﾎﾞｯｸｽ

                    If IsDate(ltypOpLotList(llngDoCnt - 1).strPlanShipDate) Then                '送品予定日
                        .SetData(llngDoCnt, CMlngvsfLotListColPlanShipDate, _
                            Format$(CDate(ltypOpLotList(llngDoCnt - 1).strPlanShipDate), CPstrDateTimeYMD))
                    Else
                        .SetData(llngDoCnt, CMlngvsfLotListColPlanShipDate, _
                            ltypOpLotList(llngDoCnt - 1).strPlanShipDate)
                    End If

                    .SetData(llngDoCnt, CMlngvsfLotListColSendSbName, _
                        ltypOpLotList(llngDoCnt - 1).strSendSBName)                             '送品先名
                        
                    If IsDate(ltypOpLotList(llngDoCnt - 1).strPlanAssembleThrowinDate) Then     '組立投入日
                        .SetData(llngDoCnt, CMlngvsfLotListColPlanAssThrowDate, _
                            Format$(CDate(ltypOpLotList(llngDoCnt - 1).strPlanAssembleThrowinDate), CPstrDateTimeYMD))
                                                                                           
                    Else
                        .SetData(llngDoCnt, CMlngvsfLotListColPlanAssThrowDate, _
                            ltypOpLotList(llngDoCnt - 1).strPlanAssembleThrowinDate)
                    End If
                    
                    .SetData(llngDoCnt, CMlngvsfLotListColShipDiffDay, _
                        ltypOpLotList(llngDoCnt - 1).strShipDiffDay)                            '進捗度

                    .SetData(llngDoCnt, CMlngvsfLotListColOpID, _
                        ltypOpLotList(llngDoCnt - 1).strOpID)                                   '大工程

                    .SetData(llngDoCnt, CMlngvsfLotListColStepID, _
                        ltypOpLotList(llngDoCnt - 1).strStepID)                                 '小工程


                    '@-----------------------------------------------
                    '@ 保/停区分列の設定
                    '@ ・優先順位：ﾘﾜｰｸ(リ)/追加流動(追) > 保留(保) > 停止(停)
                    '@-----------------------------------------------
                    '@停止ﾌﾗｸﾞが"1：停止中"か
                    If ltypOpLotList(llngDoCnt - 1).strLotStopFlag = CPstrOne Then

                        '@=======================
                        '@ ﾛｯﾄ状態表示処理(※"停"を表示)
                        '@=======================
                        .SetData(llngDoCnt, CMlngvsfLotListColLotStatus, _
                            pubstrColKbn_Set(.GetData(llngDoCnt, CMlngvsfLotListColLotStatus), CMstrTei))

                    End If

                    '@保留ﾌﾗｸﾞが"1：保留中"か
                    If ltypOpLotList(llngDoCnt - 1).strLotHoldFlag = CPstrOne Then

                        '@=======================
                        '@ ﾛｯﾄ状態表示処理(※"保"を追加表示)
                        '@=======================
                        .SetData(llngDoCnt, CMlngvsfLotListColLotStatus, _
                            pubstrColKbn_Set(.GetData(llngDoCnt, CMlngvsfLotListColLotStatus), CMstrHo))
                    End If

                    '@-----------------------
                    '@ ﾘﾜｰｸ/追加流動票示
                    '@-----------------------
                    '@★ ﾘﾜｰｸﾌﾗｸﾞにより処理分岐 ★
                    Select Case ltypOpLotList(llngDoCnt - 1).strReworkFlag

                        '@〓 1：ﾘﾜｰｸ 〓
                        Case CPstrOne

                            lstrSpecialStatus = CMstrRi

                        '@〓 2：追加流動 〓
                        Case CPstrTwo

                            lstrSpecialStatus = CMstrTsui

                        '@〓 その他 〓
                        Case Else

                            lstrSpecialStatus = vbNullString

                    End Select

                    '@特殊流動状態格納変数がNULL以外か(特殊流動状態)
                    If lstrSpecialStatus <> vbNullString Then

                        '@=======================
                        '@ ﾛｯﾄ状態表示処理(※"リ"or"追"を追加表示)
                        '@=======================
                        .SetData(llngDoCnt, CMlngvsfLotListColLotStatus, _
                            pubstrColKbn_Set(.GetData(llngDoCnt, CMlngvsfLotListColLotStatus), lstrSpecialStatus))

                    End If


                    .SetData(llngDoCnt, CMlngvsfLotListColLotID, _
                        ltypOpLotList(llngDoCnt - 1).strLotID)                                     'ﾛｯﾄID

                    .SetData(llngDoCnt, CMlngvsfLotListColFlowClass, _
                        ltypOpLotList(llngDoCnt - 1).strFlowClass)                                 '種別

                    .SetData(llngDoCnt, CMlngvsfLotListColPriority, _
                        ltypOpLotList(llngDoCnt - 1).strLotPriority)                               '優先度
                    
                    If ltypOpLotList(llngDoCnt - 1).strSecPriorityFlag = 1 Then                    '区間優先度ﾌﾗｸﾞ
                    
                        .SetData(llngDoCnt, CMlngvsfLotListColSecPriorityFlag, CMstrSecPriorityFlag)
                    Else
                        
                        .SetData(llngDoCnt, CMlngvsfLotListColSecPriorityFlag, vbNullString)
                    End If
                    
                    .SetData(llngDoCnt, CMlngvsfLotListColBeforePriority, _
                        ltypOpLotList(llngDoCnt - 1).strLotPriority)                               '変更前優先度

                    .SetData(llngDoCnt, CMlngvsfLotListColPdID, _
                        ltypOpLotList(llngDoCnt - 1).strPdId)                                      '機種

        '@↓2009/12/28 (Mon) 14:40:35 N.Kojima **************************************************
        '@下記処理はｷｬﾘｱと紐付いていない場合は分割中とみなしているが、投入待ち等もｷｬﾘｱと紐付いていない。
        '@もし投入待ちﾛｯﾄが返って来ない仕様(SQL)であればOK。
        '@↑2009/12/28 (Mon) 14:40:35 N.Kojima **************************************************

                    '@分割中ﾛｯﾄの場合、WF,ﾁｯﾌﾟ数をNULLでｾｯﾄ
                    '@(ｷｬﾘｱとﾛｯﾄが紐づいていない場合、分割中ﾛｯﾄとみなす)
                    If ltypOpLotList(llngDoCnt - 1).strCarrierId = vbNullString Then

                        .SetData(llngDoCnt, CMlngvsfLotListColWfNum, _
                            vbNullString)                                                      'WF枚数

                        .SetData(llngDoCnt, CMlngvsfLotListColCfNum, _
                            vbNullString)                                                      'ﾁｯﾌﾟ数
                    Else
                        '@ｷｬﾘｱと紐付いている場合

                        .SetData(llngDoCnt, CMlngvsfLotListColWfNum, _
                            ltypOpLotList(llngDoCnt - 1).strWfNum)                                          'WF枚数

                        .SetData(llngDoCnt, CMlngvsfLotListColCfNum, _
                            ltypOpLotList(llngDoCnt - 1).strChipQuantity)                                   'ﾁｯﾌﾟ数
                    End If

                    If IsDate(ltypOpLotList(llngDoCnt - 1).strPlanFinishDate) Then                          '完成予定日
                        .SetData(llngDoCnt, CMlngvsfLotListColPlanFinishDate, _
                            Format$(CDate(ltypOpLotList(llngDoCnt - 1).strPlanFinishDate), CPstrDateTimeYMD))
                    Else
                        .SetData(llngDoCnt, CMlngvsfLotListColPlanFinishDate, _
                            ltypOpLotList(llngDoCnt - 1).strPlanFinishDate)
                    End If

                    If IsDate(ltypOpLotList(llngDoCnt - 1).strEditLastUpdate) Then                          '(LOT_EVENT_ID=14の)最終更新日時
                        .SetData(llngDoCnt, CMlngvsfLotListColEditLastUpdate, _
                            Format$(CDate(ltypOpLotList(llngDoCnt - 1).strEditLastUpdate), CPstrDateTimeYMDHM))
                    Else
                        .SetData(llngDoCnt, CMlngvsfLotListColEditLastUpdate, _
                            ltypOpLotList(llngDoCnt - 1).strEditLastUpdate)
                    End If

                    .SetData(llngDoCnt, CMlngvsfLotListColEditEmpName, _
                        ltypOpLotList(llngDoCnt - 1).strEditEmpName)                                        '(LOT_EVENT_ID=14の)最終更新者

                    '@-----------------------
                    '@ 背景色変更処理
                    '@ ・ﾃﾞﾌｫﾙﾄ：白
                    '@ ・優先度：保留/停止(黄色) > L(水色)/R(ﾋﾟﾝｸ)
                    '@-----------------------

                    '@-----------------------
                    '@ L/R(液晶方向)の背景色
                    '@-----------------------
                    '@★ 液晶方向により処理分岐 ★
                    Select Case ltypOpLotList(llngDoCnt - 1).strLcDirection

                        '@〓 "L"(左) 〓
                        Case CPstrPDIDL

                            '@背景色を水色に変更
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngLColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngLColor)
                            Dim cellRange As CellRange = .GetCellRange(llngDoCnt, CMlngvsfLotListColTitle, _
                                                   llngDoCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle

                        '@〓 "R"(右) 〓
                        Case CPstrPDIDR

                            '@背景色をﾋﾟﾝｸに変更
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngRColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngRColor)
                            Dim cellRange As CellRange = .GetCellRange(llngDoCnt, CMlngvsfLotListColTitle, _
                                                   llngDoCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle

                    End Select

                    '@-----------------------
                    '@ 保留/停止の背景色
                    '@-----------------------
                    '@保留ﾌﾗｸﾞが"1：保留中"、または停止ﾌﾗｸﾞが"1：停止中"か
                    If ltypOpLotList(llngDoCnt - 1).strLotHoldFlag = CPstrOne Or _
                        ltypOpLotList(llngDoCnt - 1).strLotStopFlag = CPstrOne Then

                        '@背景色を黄色に変更
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor")
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                        Dim cellRange As CellRange = .GetCellRange(llngDoCnt, CMlngvsfLotListColTitle, _
                                               llngDoCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle
                    End If

                    '@-----------------------------------------------
                    '@ ﾁｯﾌﾟ品の文字色設定(組立限定機能：ﾁｯﾌﾟ品ﾛｯﾄ(文字色：青色))
                    '@-----------------------------------------------
                    '@起動SBが組立、かつｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"か
                    If pstrSBID = CPstrSBID2A0 And _
                        ltypOpLotList(llngDoCnt - 1).strSbArea = CPstrProductChip Then

                        '@文字色を青色に変更
                        Dim newStyle As CellStyle
                        Dim oldStyle As CellStyle
                        Dim cellRange As CellRange = .GetCellRange(llngDoCnt, CMlngvsfLotListColNo, _
                            llngDoCnt, CMlngvsfLotListColPlanFinishDate)

                        'NSYS 背景色が適用済みか確認
                        If cellRange.Style IsNot Nothing AndAlso (cellRange.Style.DefinedElements And StyleElementFlags.BackColor) Then
                            oldStyle = cellRange.Style
                            newStyle = .Styles.Add("CustomStyle_ForeColor_vbBlue_BackColor_" & Hex(oldStyle.BackColor.ToArgb))
                            newStyle.BackColor = oldStyle.BackColor
                        Else
                            newStyle = .Styles.Add("CustomStyle_ForeColor_vbBlue")
                        End If

                        newStyle.ForeColor = Color.Blue
                        cellRange.Style = newStyle
                    End If

                    '@ｽﾛｯﾄの高さの設定
                    .Rows(llngDoCnt).Height = CMlngvsfStepLLHeight

                    '@ﾙｰﾌﾟｶｳﾝﾀをｲﾝｸﾘﾒﾝﾄする
                    llngDoCnt = llngDoCnt + 1
                Loop


                '@描画ﾛｯｸ解除(描画開始)
                .Redraw = True

                '@-----------------------
                '@ 書式設定
                '@-----------------------
                .Cols(CMlngvsfLotListColNo).TextAlign = TextAlignEnum.RightCenter              '右の中央揃え(№)
                .Cols(CMlngvsfLotListColPlanShipDate).TextAlign = TextAlignEnum.LeftCenter     '左の中央揃え(送品予定日)
                .Cols(CMlngvsfLotListColSendSbName).TextAlign = TextAlignEnum.LeftCenter       '左の中央揃え(送品先)
                .Cols(CMlngvsfLotListColPlanAssThrowDate).TextAlign = TextAlignEnum.LeftCenter '左の中央揃え(組立送品日)
                .Cols(CMlngvsfLotListColShipDiffDay).TextAlign = TextAlignEnum.RightCenter     '右の中央揃え(進捗度)
                .Cols(CMlngvsfLotListColLotID).TextAlign = TextAlignEnum.LeftCenter            '左の中央揃え(ﾛｯﾄID)
                .Cols(CMlngvsfLotListColLotStatus).TextAlign = TextAlignEnum.LeftCenter        '左の中央揃え(ﾛｯﾄ状態)
                .Cols(CMlngvsfLotListColFlowClass).TextAlign = TextAlignEnum.LeftCenter        '左の中央揃え(種別)
                .Cols(CMlngvsfLotListColPriority).TextAlign = TextAlignEnum.RightCenter        '右の中央揃え(優先度)
                .Cols(CMlngvsfLotListColBeforePriority).TextAlign = TextAlignEnum.RightCenter  '右の中央揃え(変更前優先度)
                .Cols(CMlngvsfLotListColSecPriorityFlag).TextAlign = TextAlignEnum.LeftCenter  '左の中央揃え(区間優先ﾌﾗｸﾞ)
                .Cols(CMlngvsfLotListColPdID).TextAlign = TextAlignEnum.LeftCenter             '左の中央寄せ(機種)
                .Cols(CMlngvsfLotListColWfNum).TextAlign = TextAlignEnum.RightCenter           '右の中央揃え(WF枚数)
                .Cols(CMlngvsfLotListColCfNum).TextAlign = TextAlignEnum.RightCenter           '右の中央揃え(ﾁｯﾌﾟ)
                .Cols(CMlngvsfLotListColOpID).TextAlign = TextAlignEnum.LeftCenter             '左の中央揃え(大工程)
                .Cols(CMlngvsfLotListColStepID).TextAlign = TextAlignEnum.LeftCenter           '左の中央揃え(小工程)
                .Cols(CMlngvsfLotListColPlanFinishDate).TextAlign = TextAlignEnum.LeftCenter   '左の中央揃え(完成予定日)
                .Cols(CMlngvsfLotListColEditLastUpdate).TextAlign = TextAlignEnum.LeftCenter   '左の中央揃え((LOT_EVENT_ID=14の)最終更新日時)
                .Cols(CMlngvsfLotListColEditEmpName).TextAlign = TextAlignEnum.LeftCenter      '左の中央揃え((LOT_EVENT_ID=14の)最終更新者)

                '@ﾕｰｻﾞｰにより列幅が変更されていないか(False：変更なし)
                If mtypChgSort.blnChgWidth = False Then

                    '@自動列幅調整を行う
                    .AutoSizeCols(CMlngvsfLotListColNo, .Cols.Count - 1, 6)
                    .Cols(CMlngvsfLotListColPriority).Width = CMlngvsfLotListColWPriority + 10
                End If


                '@行表示(何故この処理が必要？)
                For llngCnt = .Rows.Fixed To .Rows.Count - 1
                    .Rows(llngCnt).Visible = True
                Next llngCnt

                '@ﾕｰｻﾞによりｿｰﾄされているか
                If mtypChgSort.lngCnt > 0 Then

                    For llngCnt = 0 To mtypChgSort.lngCnt - 1

                        '@該当行をｿｰﾄする
                        .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder, mtypChgSort.typChgSortList(llngCnt).lngCol)
                    Next llngCnt
                End If

                '@-----------------------
                '@ №の振り直し
                '@-----------------------
                With vsfLotList

                    For llngCnt = 1 To .Rows.Count - 1
                        .SetData(llngCnt, CMlngvsfLotListColNo, llngCnt)
                    Next llngCnt
                End With

                .Row = CMlngvsfStepLLRowTitle

                '@ｿｰﾄ検索用ｷｰ(ﾛｯﾄID)がNULL以外か
                If mtypChgSort.strKey <> vbNullString Then

                    For llngCnt = .Rows.Fixed To .Rows.Count - 1

                        '@ﾙｰﾌﾟ行のﾛｯﾄIDとｿｰﾄｷｰのﾛｯﾄIDが同じか
                        If .GetData(llngCnt, CMlngvsfLotListColLotID) = mtypChgSort.strKey Then

                            '@一致した行を選択する
                            .Row = llngCnt

                            '@=======================
                            '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                            '@=======================
                            Call pubVsfBeforeSort(vsfLotList, CMlngvsfLotListColLotID)

                            '@=======================
                            '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                            '@=======================
                            Call pubVsfAfterSort(vsfLotList, CMlngvsfLotListColLotID)

                            Exit For
                        End If
                    Next llngCnt
                Else
                    '@ｿｰﾄ検索用ｷｰ(ﾛｯﾄID)がNULLの場合

                    '@表示・選択行をﾀｲﾄﾙ行に設定
                    .TopRow = CMlngvsfStepLLRowTitle
                    .Row = CMlngvsfStepLLRowTitle
                End If

                '@表示・選択列を左端列に設定
                .LeftCol = CMlngvsfLotListColTitle
                .Col = CMlngvsfLotListColTitle

                '@[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞを有効にする
                .Enabled = True

                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False：起動中"か
                If pblnFormLoad = False Then

                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    '@ ﾛｯﾄ情報一括変更画面　表示処理
                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    'Call frmxxEN02B0.Show(vbModal)
                End If

                '@[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞが有効か
                If .Enabled = True Then

                    '@[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(vsfLotList, cmdNowList)
                Else
                    '@[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞを有効にする
                    .Enabled = True
                End If
            End With

            'NSYS イベントハンドラーを元に戻す
            AddHandler vsfLotList.BeforeRowColChange, AddressOf vsfLotList_BeforeRowColChange

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfLotList_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' ﾛｯﾄ一覧情報取得 要求構造体設定処理
    ''' </summary>
    ''' <param name="ltypOpLotListReq"></param>
    Private Sub prvOpLotListReq_Proc(ByRef ltypOpLotListReq As OpLotList)

        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ
        Dim lstrTemp        As String()     '一時取得
        Dim lstrFirstDate   As String       '月初日付格納用
        Dim lstrAddDate     As String       '加算日付格納用

        Try

            '@要求構造体の機種ﾘｽﾄ、種別ﾘｽﾄを初期化
            ltypOpLotListReq.typFlowClassList = Nothing
            ltypOpLotListReq.typPdList = Nothing

            '@-----------------------
            '@ 要求ﾃﾞｰﾀ作成
            '@-----------------------
            With ltypOpLotListReq

                .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strMsgVer = CMstrlot_oplotlistVer          'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .lngPdCnt = cmbPD.ValueCount                '機種ｶｳﾝﾄ数
                '@-----------------------
                '@ (基板⇒4O：Mﾛｯﾄ以外、組立⇒0P：Sﾛｯﾄのみ)
                '@-----------------------
                If pstrSBID = CPstrSBID1A0 Then
                    .strClassDivision = CPstrCD4O
                    '在庫検索
                    If optInventory.Checked = True Then
                        .strInventoryFlag = CPstrFlagOn
                    Else
                        .strInventoryFlag = CPstrFlagOff
                    End If
                Else
                    .strClassDivision = CPstrCD0P
                    .strInventoryFlag = CPstrFlagOff
                End If

                '@-----------------------
                '@ 機種ﾘｽﾄ作成
                '@-----------------------
                '@[機種]ｺﾝﾎﾞにて機種が1件以上選択されているか
                If cmbPD.ValueCount > 0 Then

                    '@機種ﾘｽﾄ配列の再定義
                    .typPdList = New List(Of PDList)(.lngPdCnt)

                    '@一時領域に機種IDをﾀﾌﾞ区切りで格納
                    lstrTemp = Split(cmbPD.Value, vbTab)

                    For llngCnt = LBound(lstrTemp) To UBound(lstrTemp)
                        Dim ltypPDListTmp As New PDList
                        ltypPDListTmp.strPdId = lstrTemp(llngCnt)                 '機種ID
                        .typPdList.Add(ltypPDListTmp)
                    Next llngCnt
                End If

                .lngFlowClassCnt = cmbFlowClass.ValueCount      '種別ｶｳﾝﾄ数

                '@-----------------------
                '@ 種別ﾘｽﾄ作成
                '@-----------------------
                '@[種別]ｺﾝﾎﾞにて種別が1件以上選択されているか
                If cmbFlowClass.ValueCount > 0 Then

                    '@種別ﾘｽﾄ配列の再定義
                    .typFlowClassList = New List(Of FlowClassList)(.lngFlowClassCnt)

                    '@一時領域に種別IDをﾀﾌﾞ区切りで格納
                    lstrTemp = Split(cmbFlowClass.Value, vbTab)

                    For llngCnt = LBound(lstrTemp) To UBound(lstrTemp)
                        Dim ltypFlowClassListTmp As New FlowClassList
                        ltypFlowClassListTmp.strFlowClass = lstrTemp(llngCnt)     '種別ID
                        .typFlowClassList.Add(ltypFlowClassListTmp)
                    Next llngCnt
                End If


                '@工程指定(指定する)ﾁｪｯｸBoxがﾁｪｯｸONか
                If chkProcess.Checked = True Then

                    .strOpID = cmbOpID.Text             '大工程ID
                    .strStepID = cmbStepID.Text         '小工程ID
                End If

                '@-----------------------
                '@ 当月の初日を作成("YYYY/MM/01")
                '@-----------------------
                '@① 現在日時時から"YYYY/MM/"までを格納
                lstrFirstDate = Mid$(Format$(Now, CPstrDateTimeYMD), 1, 8)
                '@② ①に"01"を結合し、"YYYY/MM/01"を作成
                lstrFirstDate = lstrFirstDate & CMstrFirstDate

                '@★ 各種ﾁｪｯｸBoxがONかにより処理分岐 ★
                Select Case True

                    '@〓 当月分、次月分がﾁｪｯｸON 〓
                    Case chkThisMonth.Checked And chkNextMonth.Checked

                        '@上記で作成した"月初日"に2ヵ月を足して1日引いた日付を格納(翌月の最終日)
                        lstrAddDate = Format$(DateAdd(CMstrD, -1, DateAdd(CMstrM, 2, CDate(lstrFirstDate))), CPstrDateTimeYMD)
                        
                        '@検索開始日と検索終了日を格納
                        .strStartDate = lstrFirstDate
                        .strEndDate = lstrAddDate

                    '@〓 期間指定(指定する)がﾁｪｯｸON 〓
                    Case chkPlanShipDate.Checked

                        '@検索開始日と検索終了日を格納
                        .strStartDate = calFromDate.Value
                        .strEndDate = calToDate.Value

                    '@〓 当月分のみﾁｪｯｸON 〓
                    Case chkThisMonth.Checked

                        '@上記で作成した"月初日"に1ヵ月を足して1日引いた日付を格納(当月の最終日)
                        lstrAddDate = Format$(DateAdd(CMstrD, -1, DateAdd(CMstrM, 1, lstrFirstDate)), CPstrDateTimeYMD)
                        
                        '@検索開始日と検索終了日を格納
                        .strStartDate = lstrFirstDate
                        .strEndDate = lstrAddDate

                    '@〓 次月分のみﾁｪｯｸON 〓
                    Case chkNextMonth.Checked

                        '@上記で作成した"当月初日"に2ヵ月を足して1日引いた日付を格納(翌月の最終日)
                        lstrAddDate = Format$(DateAdd(CMstrD, -1, DateAdd(CMstrM, 2, CDate(lstrFirstDate))), CPstrDateTimeYMD)
                        '@上記で作成した"当月初日"に1ヵ月を足した日付を格納(翌月の初日)
                        lstrFirstDate = Format$(DateAdd(CMstrM, 1, CDate(lstrFirstDate)), CPstrDateTimeYMD)
                        
                        '@検索開始日と検索終了日を格納
                        .strStartDate = lstrFirstDate
                        .strEndDate = lstrAddDate

                End Select
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvOpLotListReq_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnSearchCondition_Chk
    '機　能：[最新取得]ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
    '引　数：lstrEventName  ：呼び出し元ｲﾍﾞﾝﾄ名
    '戻り値：True：検索条件All-OK、False：検索条件設定不足
    '作成日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '更新日：2009/12/21 (Mon) 16:44:15
    '備　考：
    Private Function prvblnSearchCondition_Chk(ByVal lstrEventName As String) As Boolean

        Dim laryCallers     As Control()    'NSYS 呼出元コントロール
        Dim lstrCtrlName    As String       'NSYS コントロール名

        Try

            '@戻り値の初期化
            prvblnSearchCondition_Chk = False

            'NSYS 呼出元コントロールを特定
            lstrCtrlName = Strings.Left(lstrEventName, InStr(lstrEventName, "_") - 1)
            laryCallers = Me.Controls.Find(lstrCtrlName, True)

            '@-----------------------
            '@ 必須指定項目(機種、種別)
            '@-----------------------
            '@★ 機種の選択状況により処理分岐 ★
            Select Case cmbPD.Text

                '@〓 NULL or 0 項目選択 〓
                Case vbNullString, CMstrCmbAddedCommentNone

                    '@[最新取得]ﾎﾞﾀﾝ押下処理よりCallされたか
                    If lstrEventName = CMstrCmdNowListClick Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM13W>$$機種が設定されていません。設定を見直してください。"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0013)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@[機種]ｺﾝﾎﾞが有効か
                        If cmbPD.Enabled = True Then

                            '@[機種]ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                            Call prvSetFocus(cmbPD, laryCallers)
                        End If
                    End If

                    Exit Function

            End Select


            '@★ 種別の選択状況により処理分岐 ★
            Select Case cmbFlowClass.Text

                '@〓 NULL or 0 項目選択 〓
                Case vbNullString, CMstrCmbAddedCommentNone

                    '@[最新取得]ﾎﾞﾀﾝ押下処理よりCallされたか
                    If lstrEventName = CMstrCmdNowListClick Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM14W>$$種別が設定されていません。設定を見直してください。"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0014)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@[種別]ｺﾝﾎﾞが有効か
                        If cmbFlowClass.Enabled = True Then

                            '@[種別]ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                            Call prvSetFocus(cmbFlowClass, laryCallers)
                        End If
                    End If

                    Exit Function

            End Select


            '@-----------------------
            '@ 任意指定項目(大工程、小工程、送品予定日)
            '@-----------------------
            '@[工程指定(指定する)]のﾁｪｯｸがONか
            If chkProcess.Checked = True Then

                '@大工程・小工程が両方NULLか
                If cmbOpID.Text = vbNullString And cmbStepID.Text = vbNullString Then
            
                    '@[最新取得]ﾎﾞﾀﾝ押下処理よりCallされたか
                    If lstrEventName = CMstrCmdNowListClick Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM68W>$$大工程が設定されていません。設定を見直してください。"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0068)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@[大工程]ｺﾝﾎﾞが有効か
                        If cmbOpID.Enabled = True Then

                            '@[大工程]ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                            Call prvSetFocus(cmbOpID, laryCallers)
                        End If
                    End If

                    Exit Function
                End If
            End If


            '@[期間指定(指定する)]のﾁｪｯｸがONか
            If chkPlanShipDate.Checked = True Then

                '@★ 送品予定日(検索開始日)の入力状態により処理分岐 ★
                Select Case calFromDate.Value

                    '@〓 NULL or "____/__/__" 〓
                    Case vbNullString, CPstrNullDate

                        '@[最新取得]ﾎﾞﾀﾝ押下処理よりCallされたか
                        If lstrEventName = CMstrCmdNowListClick Then

                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「"<TRM3DW>$$日付が設定されていません。設定を見直してください。"」のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003D)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            '@[検索開始日]ｶﾚﾝﾀﾞｰが有効か
                            If calFromDate.Enabled = True Then

                                '@[検索開始日]ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                                Call prvSetFocus(calFromDate, laryCallers)
                            End If
                        End If

                        Exit Function

                    '@〓 日付型以外 or 有効範囲外 〓
                    Case Not calFromDate.IsDate, Not pubblnYearRange_Chk(calFromDate.Value)

                        '@[最新取得]ﾎﾞﾀﾝ押下処理よりCallされたか
                        If lstrEventName = CMstrCmdNowListClick Then

                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「"<TRM08W>$$正しい日付を入力してください。$1900年～2100年以外の日付は入力できません。"」のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            '@[検索開始日]ｶﾚﾝﾀﾞｰが有効か
                            If calFromDate.Enabled = True Then

                                '@[検索開始日]ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                                Call prvSetFocus(calFromDate, laryCallers)
                            End If
                        End If

                        Exit Function

                End Select

                '@★ 送品予定日(検索終了日)の入力状態により処理分岐 ★
                Select Case calToDate.Value

                    '@〓 NULL or "____/__/__" 〓
                    Case vbNullString, CPstrNullDate

                        '@[最新取得]ﾎﾞﾀﾝ押下処理よりCallされたか
                        If lstrEventName = CMstrCmdNowListClick Then

                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「"<TRM3DW>$$日付が設定されていません。設定を見直してください。"」のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003D)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            '@[検索終了日]ｶﾚﾝﾀﾞｰが有効か
                            If calToDate.Enabled = True Then

                                '@[検索終了日]ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                                Call prvSetFocus(calToDate, laryCallers)
                            End If
                        End If

                        Exit Function

                    '@〓 日付型以外 or 有効範囲外 〓
                    Case Not calToDate.IsDate, Not pubblnYearRange_Chk(calToDate.Value)

                        '@[最新取得]ﾎﾞﾀﾝ押下処理よりCallされたか
                        If lstrEventName = CMstrCmdNowListClick Then

                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「"<TRM08W>$$正しい日付を入力してください。$1900年～2100年以外の日付は入力できません。"」のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            '@[検索終了日]ｶﾚﾝﾀﾞｰが有効か
                            If calToDate.Enabled = True Then

                                '@[検索終了日]ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                                Call prvSetFocus(calToDate, laryCallers)
                            End If
                        End If

                        Exit Function

                End Select
            End If

            '@戻り値に"True：検索条件All-OK"をｾｯﾄ
            prvblnSearchCondition_Chk = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnSearchCondition_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvVsfLotList_Edit
    '機　能：[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ編集可否制御処理(ﾁｪｯｸﾎﾞｯｸｽ、ﾘｽﾄ選択、ｺﾒﾝﾄ入力)
    '引　数：llngEditFlag       ：制御判断ﾌﾗｸﾞ(1：ﾏｳｽ、2：ｷｰﾎﾞｰﾄﾞ)
    '　　　：llngKeyCode        ：ｷｰｺｰﾄﾞ(0：ﾏｳｽ(定義)、32(vbKeySpace)：ｽﾍﾟｰｽｷｰ)
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Sub prvVsfLotList_Edit(ByRef llngEditFlag As Integer, _
                                   ByRef llngKeyCode As Short)

        Dim llngLoopCnt         As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim lstrPriorityList    As String       '優先度ｺﾝﾎﾞﾘｽﾄ作成用文字列

        Try

            With vsfLotList

                '@★ 選択列により処理分岐 ★
                Select Case .Col

                    '@〓 ﾁｪｯｸﾎﾞｯｸｽ列 〓
                    Case CMlngvsfLotListColCheck

                        '@制御判断ﾌﾗｸﾞが"1：ﾏｳｽ動作(ｸﾘｯｸ)"、またはｷｰｺｰﾄﾞが"32：ｽﾍﾟｰｽ"か
                        If llngEditFlag = CMlngMouseClick Or llngKeyCode = Keys.Space Then

                            '@ｸﾞﾘｯﾄﾞを編集可能にする
                            .StartEditing()

                            '@区間優先設定を持つﾛｯﾄが変更対象の場合「区間優先設定あり」を表示する
                            Call prvChkSecPriority()
                        End If

                    '@〓 "優"(優先度)列 〓
                    Case CMlngvsfLotListColPriority

                        '@-----------------------
                        '@ 優先度ｸﾞﾘｯﾄﾞｺﾝﾎﾞﾘｽﾄ設定(数値のみ表示)
                        '@-----------------------
                        '@各種変数の初期化
                        llngLoopCnt = 1
                        lstrPriorityList = vbNullString
                            
                        '@優先度ｸﾞﾘｯﾄﾞｺﾝﾎﾞﾘｽﾄの先頭ﾃﾞｰﾀの設定("1")
                        lstrPriorityList = lstrPriorityList & CPstrOne

                        For llngLoopCnt = 2 To 5

                            '@優先度ｸﾞﾘｯﾄﾞｺﾝﾎﾞﾘｽﾄの2ﾃﾞｰﾀ目以降の設定
                            lstrPriorityList = lstrPriorityList & "|" & llngLoopCnt
                        Next llngLoopCnt
                        
                        '@優先度ｸﾞﾘｯﾄﾞｺﾝﾎﾞﾘｽﾄに文字列を設定("1"|"2"|"3"|"4"|"5")
                        .Cols(CMlngvsfLotListColPriority).ComboList = lstrPriorityList

                        '@ｸﾞﾘｯﾄﾞを編集可能にする
                        .StartEditing()

                    '@〓 その他の列 〓
                    Case Else

                        '@編集不可にする
                        .AllowEditing = False

                End Select
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfLotList_Edit"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' ボタン制御
    ''' </summary>
    Private Sub prvblnRegistButton_Proc()

        Dim lintLoopCnt As Integer = 0
        Dim lintCheckOnCnt As Integer = 0
        Dim lintPriorityUpdateCnt As Integer = 0

        Try
            cmdRegist.Enabled = False

            With vsfLotList
                For lintLoopCnt = 1 To .Rows.Count - 1
                    '一括変更
                    If .GetCellCheck(lintLoopCnt, CMlngvsfLotListColCheck) = CheckEnum.Checked Then
                        lintCheckOnCnt = lintCheckOnCnt + 1
                    End If

                    '優先度の手動変更（背景色）
                    If .GetCellRange(lintLoopCnt, CMlngvsfLotListColPriority).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngSpecialEditColor) Then
                        lintPriorityUpdateCnt = lintPriorityUpdateCnt + 1
                    End If

                    '更新データがある場合
                    If lintCheckOnCnt > 0 And lintPriorityUpdateCnt > 0 Then
                        Exit For
                    End If
                Next
            End With

            '更新データなしの場合
            If lintCheckOnCnt = 0 And lintPriorityUpdateCnt = 0 Then
                Exit Sub
            End If

            '一括変更の場合
            If lintCheckOnCnt > 0 Then
                '組立投入日が有効の場合
                If calPlanAssThrowDate.Enabled = True Then
                    '@完成日が"____/__/__"
                    '@送品日が"____/__/__"
                    '@組立投入日が"____/__/__"
                    '@優先度NULL
                    If calPlanFinishDate.Value = CPstrNullDate And _
                       calPlanShipDate.Value = CPstrNullDate And _
                       calPlanAssThrowDate.Value = CPstrNullDate And _
                       cmbPriority.Text = vbNullString Then
                       
                        Exit Sub
                    End If
                Else
                    '@完成日が"____/__/__"
                    '@送品日が"____/__/__"
                    '@優先度NULL
                    If calPlanFinishDate.Value = CPstrNullDate And _
                       calPlanShipDate.Value = CPstrNullDate And _
                       cmbPriority.Text = vbNullString Then

                        Exit Sub
                    End If
                End If

                '@現在日付取得
                Dim lstrNowDT As String = Format$(Now, CPstrDateTimeYMD)

                '完成日設定あり
                If calPlanFinishDate.Value <> CPstrNullDate Then
                    '設定日付が現在日付より過去か
                    If Format$(CDate(calPlanFinishDate.Value), CPstrDateTimeYMD) < lstrNowDT Then
                        Exit Sub
                    End If
                End If

                '送品日設定あり
                If calPlanShipDate.Value <> CPstrNullDate Then
                    '設定日付が現在日付より過去か
                    If Format$(CDate(calPlanShipDate.Value), CPstrDateTimeYMD) < lstrNowDT Then
                        Exit Sub
                    End If
                End If

                '組立投入日設定あり
                If calPlanAssThrowDate.Value <> CPstrNullDate Then
                    '設定日付が現在日付より過去か
                    If Format$(CDate(calPlanAssThrowDate.Value), CPstrDateTimeYMD) < lstrNowDT Then
                        Exit Sub
                    End If
                End If                                

            End If  

            cmdRegist.Enabled = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnRegistButton_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' 更新データ確認
    ''' </summary>
    ''' <returns></returns>
    Private Function prvblnUpdateData_Chk() As Boolean

        Dim lintLoopCnt             As Integer
        Dim lintCheckOnCnt          As Integer
        Dim lintAns                 As Integer
        Dim lstrSubMsg              As String
        Dim lintPriorityUpdateCnt   As Integer
        Dim lintSecPriorityCnt      As Integer

        Try
            prvblnUpdateData_Chk = False
            lintPriorityUpdateCnt = 0
            lintSecPriorityCnt = 0

            '@ｻﾌﾞﾒｯｾｰｼﾞ定型文
            lstrSubMsg = "対象数："
            
            With vsfLotList
                For lintLoopCnt = 1 To .Rows.Count - 1

                    'チェックあり=一括変更数
                    If .GetCellCheck(lintLoopCnt, CMlngvsfLotListColCheck) = CheckEnum.Checked Then
                        lintCheckOnCnt = lintCheckOnCnt + 1
                    End If

                    '手動で優先度変更
                    If .GetCellRange(lintLoopCnt, CMlngvsfLotListColPriority).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngSpecialEditColor) Then
                        '優先度変更数
                        lintPriorityUpdateCnt = lintPriorityUpdateCnt + 1
                        '区間優先度が設定ありの場合
                        If .GetData(lintLoopCnt, CMlngvsfLotListColSecPriorityFlag) <> vbNullString Then
                            lintSecPriorityCnt = lintSecPriorityCnt + 1
                        End If
                    Else
                        '一括変更で優先度を変更
                        If .GetCellCheck(lintLoopCnt, CMlngvsfLotListColCheck) = CheckEnum.Checked And _
                            cmbPriority.Text <> vbNullString Then

                            '優先度変更数
                            lintPriorityUpdateCnt = lintPriorityUpdateCnt + 1
                            '区間優先度が設定ありの場合
                            If .GetData(lintLoopCnt, CMlngvsfLotListColSecPriorityFlag) <> vbNullString Then
                                lintSecPriorityCnt = lintSecPriorityCnt + 1
                            End If
                        End If
                    End If                    
                Next
            End With

            '更新データなし
            If lintCheckOnCnt = 0 And lintPriorityUpdateCnt = 0 Then
                '"<TRM82I>$$登録データがありませんでした。$設定を確認してください。"
                Call publngMsgBoxInfo(CPstrMsgInf0082, vbExclamation, Me.Text, True, 16)
                Exit Function
            End If

            '区間優先度ありのロットに対して優先度変更する場合
            If lintSecPriorityCnt > 0 Then
                '@"<TRM7AI>$$ロット[%1]には区間優先設定がされています。$確定処理を実行すると区間優先設定はクリアされますので、$必要に応じ再設定してください。$よろしいですか？"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf007A, lstrSubMsg + CStr(lintSecPriorityCnt))
                lintAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                '@上記MsgBoxで"いいえ"が選択されたか
                If lintAns = vbNo Then
                    Exit Function
                End If
            End If

            '一括変更の場合
            If lintCheckOnCnt > 0 Then
                '@完成日が"____/__/__"
                '@送品日が"____/__/__"
                '@組立投入日が"____/__/__"
                '@優先度NULL
                If calPlanFinishDate.Value = CPstrNullDate And _
                   calPlanShipDate.Value = CPstrNullDate And _
                   calPlanAssThrowDate.Value = CPstrNullDate And _
                   cmbPriority.Text = vbNullString Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM0WW>$$[%1]が設定されていません。設定を見直してください。"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000W, CMstrNotChange)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Exit Function
                End If

                '@現在日付取得
                Dim lstrNowDT As String = Format$(Now, CPstrDateTimeYMD)

                '完成日設定あり
                If calPlanFinishDate.Value <> CPstrNullDate Then
                    '設定日付が現在日付より過去か
                    If Format$(CDate(calPlanFinishDate.Value), CPstrDateTimeYMD) < lstrNowDT Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM10W>$$過去の日付は指定できません。"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        Exit Function
                    End If
                End If                

                '送品日設定あり
                If calPlanShipDate.Value <> CPstrNullDate Then
                    '設定日付が現在日付より過去か
                    If Format$(CDate(calPlanShipDate.Value), CPstrDateTimeYMD) < lstrNowDT Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM10W>$$過去の日付は指定できません。"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        Exit Function
                    End If
                End If

                '組立投入日設定あり
                If calPlanAssThrowDate.Value <> CPstrNullDate Then
                    '設定日付が現在日付より過去か
                    If Format$(CDate(calPlanAssThrowDate.Value), CPstrDateTimeYMD) < lstrNowDT Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM10W>$$過去の日付は指定できません。"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        Exit Function
                    End If
                End If
            End If

            prvblnUpdateData_Chk = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnUpdateData_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnRegistAuthority_Chk
    '機　能：権限ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：権限あり、False：権限なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2009/12/21 (Mon) 16:44:15 N.Kojima
    '備　考：
    '　　　：2009/12/21 (Mon) 16:44:15 N.Kojima     ﾛｯﾄ情報一括変更機能追加に伴う修正。(案件№03899)
    Private Function prvblnRegistAuthority_Chk() As Boolean

        Dim lstrFunctionID          As String       '機能ID
        Dim lstrActionID            As String       'ｱｸｼｮﾝID
        Dim lstrEmpName             As String       '作業者名
        Dim lblnAns                 As Boolean      '戻り値格納用

        Try

            '@戻り値の初期化
            prvblnRegistAuthority_Chk = False

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0020.Instance.ShowDialog(Me)
            frmxxCM0020.Instance = Nothing

            '@上記画面でｷｬﾝｾﾙﾎﾞﾀﾝが押下されたか
            If pblnCancel = True Then
                Exit Function
            End If


            '@権限ﾁｪｯｸ用情報の設定
            lstrFunctionID = CMstrLocalMenuKey          '機能ID：EN02B0(ﾛｯﾄ情報一括変更)
            lstrActionID = CPstrPlanShipAuthPlural      'ｱｸｼｮﾝID：送品予定日一括変更
            lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名：NULL

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvblnRegistAuthorityChk)

            '@=======================
            '@ 実行権限ﾁｪｯｸ処理
            '@=======================
            lblnAns = pubAuthority_Chk(lstrFunctionID, _
                                       lstrActionID, _
                                       pstrUserID, _
                                       pstrUserName, _
                                       pstrSBID)

            '@実行権限ﾁｪｯｸ処理結果が"False：権限なし"か
            If lblnAns = False Then

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvblnRegistAuthorityChk)

                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。$処理を中断します。"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, pstrUserName, lstrActionID)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                Exit Function
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrPrvblnRegistAuthorityChk)

            '@戻り値に"True：権限あり"をｾｯﾄ
            prvblnRegistAuthority_Chk = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnRegistAuthority_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvLotChgAttributesData_Set
    '機　能：更新ﾛｯﾄ情報設定処理
    '引　数：ltypLotchgAttributes   ：更新ﾛｯﾄ情報格納用構造体
    '　　　：llngLotCnt             ：更新ﾛｯﾄ数
    '戻り値：なし
    '作成日：2008/06/04 (Wed) 11:26:21 Y.Tomiya
    '更新日：2013/01/31 (Thu) 10:56:44 Y.Yoneyama
    '備　考：
    Private Sub prvLotChgAttributesData_Set(ByRef ltypLotchgAttributes As LotchgAttributes, _
                                            ByRef llngLotCnt As Integer)

        Dim llngCnt                     As Integer          '汎用ｶｳﾝﾀ
        Dim ltypLotchgAttrListTmp       As New LotchgAttrList   'NSYS 作業用構造体

        Try

            '@-----------------------
            '@ 更新ﾃﾞｰﾀ作成
            '@-----------------------
            With ltypLotchgAttributes

                .strMsgVer = CMstrlot_chgattributesVer          'ﾒｯｾｰｼﾞVer
                .strSbID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸID
                .strComments = txtComments.Text                 '作業ﾒﾓ
                .strEmpID = pstrUserID                          '作業者ID
                '在庫の場合
                If optInventory.Checked = True Then
                    .strInventoryFlag = CPstrFlagOn
                Else
                    .strInventoryFlag = CPstrFlagOff
                End If

                '@更新ﾛｯﾄ数の初期化
                llngLotCnt = 0
                .typChgAttrList = New List(Of LotchgAttrList)

                '@更新対象ﾃﾞｰﾀ検索
                For llngCnt = vsfLotList.Rows.Fixed To vsfLotList.Rows.Count - 1
                    
                    '@対象行のﾁｪｯｸがON
                    '@優先度の背景色がｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝ
                    If vsfLotList.GetCellCheck(llngCnt, CMlngvsfLotListColCheck) = CheckEnum.Checked Or _
                       vsfLotList.GetCellRange(llngCnt, CMlngvsfLotListColPriority).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngSpecialEditColor) Then

                        '@更新ﾛｯﾄ数のｶｳﾝﾄｱｯﾌﾟ＆配列の領域確保
                        llngLotCnt = llngLotCnt + 1
                        ltypLotchgAttrListTmp = New LotchgAttrList
                    
                        '@ﾛｯﾄID
                        ltypLotchgAttrListTmp.strLotID = _
                            vsfLotList.GetData(llngCnt, CMlngvsfLotListColLotID)

                        .typChgAttrList.Add(ltypLotchgAttrListTmp)
                    End If
                    
                    '@対象行のﾁｪｯｸがONか(一括変更処理)
                    If vsfLotList.GetCellCheck(llngCnt, CMlngvsfLotListColCheck) = CheckEnum.Checked Then

                        '@-----------------------
                        '@ 完成予定日
                        '@-----------------------
                        '@完成予定日が"____/__/__"以外か
                        If calPlanFinishDate.Value <> CPstrNullDate Then

                            '@指定されている送品予定日
                            ltypLotchgAttrListTmp = .typChgAttrList(llngLotCnt - 1)
                            ltypLotchgAttrListTmp.strLotPlanFinishDate = calPlanFinishDate.Value
                            .typChgAttrList(llngLotCnt - 1) = ltypLotchgAttrListTmp

                        End If

                        '@-----------------------
                        '@ 送品予定日
                        '@-----------------------
                        '@送品予定日が"____/__/__"以外か
                        If calPlanShipDate.Value <> CPstrNullDate Then

                            '@指定されている送品予定日
                            ltypLotchgAttrListTmp = .typChgAttrList(llngLotCnt - 1)
                            ltypLotchgAttrListTmp.strLotPlanShipDate = calPlanShipDate.Value
                            .typChgAttrList(llngLotCnt - 1) = ltypLotchgAttrListTmp

                        End If

                        '@-----------------------
                        '@ 組立投入予定日
                        '@-----------------------
                        '@組立投入予定日が"____/__/__"以外か
                        If calPlanAssThrowDate.Value <> CPstrNullDate Then

                            '@指定されている組立投入予定日
                            ltypLotchgAttrListTmp = .typChgAttrList(llngLotCnt - 1)
                            ltypLotchgAttrListTmp.strLotPlanAssThrowDate = calPlanAssThrowDate.Value
                            .typChgAttrList(llngLotCnt - 1) = ltypLotchgAttrListTmp

                        End If
                    End If
                                
                    '@優先度変更は一括よりも個別が有効になる
                    '@-----------------------
                    '@ 優先度(個別)
                    '@-----------------------
                    '@優先度の背景色がｴﾒﾗﾙﾄﾞｸﾞﾘｰﾝか
                    If vsfLotList.GetCellRange(llngCnt, CMlngvsfLotListColPriority).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngSpecialEditColor) Then

                        '@ｸﾞﾘｯﾄﾞの優先度
                        ltypLotchgAttrListTmp = .typChgAttrList(llngLotCnt - 1)
                        ltypLotchgAttrListTmp.strLotPriority = _
                            vsfLotList.GetData(llngCnt, CMlngvsfLotListColPriority)
                        .typChgAttrList(llngLotCnt - 1) = ltypLotchgAttrListTmp

                    '@-----------------------
                    '@ 優先度(一括)
                    '@-----------------------
                    '@対象行のﾁｪｯｸがON
                    '@優先度変更がNULL以外
                    ElseIf vsfLotList.GetCellCheck(llngCnt, CMlngvsfLotListColCheck) = CheckEnum.Checked And _
                           cmbPriority.Text <> vbNullString Then
                        
                        '@指定されている優先度
                        ltypLotchgAttrListTmp = .typChgAttrList(llngLotCnt - 1)
                        ltypLotchgAttrListTmp.strLotPriority = cmbPriority.Value
                        .typChgAttrList(llngLotCnt - 1) = ltypLotchgAttrListTmp
                        
                    End If


                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvLotChgAttributesData_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvChkSecPriority
    '機　能：区間優先設定を持つﾛｯﾄを一括で優先度変更する場合に「区間優先設定あり」を表示する
    '引　数：なし
    '戻り値：
    '作成日：2011/10/05 (Wed) 14:52:07 T.Oide
    '更新日：2011/10/05 (Wed) 14:52:07
    '備　考：
    Private Sub prvChkSecPriority()

        Dim llngCnt                     As Integer  '汎用ｶｳﾝﾀ
        Dim lblnFindFlag                As Boolean
        
        Try
            '@行ぶんﾙｰﾌﾟ
            With vsfLotList
                lblnFindFlag = False
                For llngCnt = 1 To vsfLotList.Rows.Count - 1
                    '一括変更のチェックがある場合
                    If .GetCellCheck(llngCnt, CMlngvsfLotListColCheck) = CheckEnum.Checked Then
                        '@区間優先設定がありの場合はﾌﾗｸﾞを設定
                        If .GetData(llngCnt, CMlngvsfLotListColSecPriorityFlag) <> vbNullString Then
                            lblnFindFlag = True
                            Exit For
                        End If
                    End If
                Next llngCnt
            End With
            
            '@ﾌﾗｸﾞはTrueか
            If lblnFindFlag = True Then
                '@区間優先設定ありを表示
                lblSecPriority.Text = CMstrSecPriorityString
            Else
                '@表示なし
                lblSecPriority.Text = vbNullString
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvLotChgAttributesData_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraAfterAttributes.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfLotList.BeforeDoubleClick

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
            '現行の AutoSizeMouse が False のため無効にする
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
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfLotList.KeyDownEdit

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
    Private Sub flex_SetupEditor(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfLotList.SetupEditor

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

    '関数名：prvSetFocus
    '機　能：フォーム専用のフォーカスセット追加処理
    '引　数：lctlNext：フォーカス先コントロールオブジェクト
    '      ：laryCallers：呼出し元コントロールの配列
    '戻り値：なし
    '作成日：2020/03/26 (Thu) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub prvSetFocus(ByVal lctlNext As Control, ParamArray ByVal laryCallers As Control())

        Dim ldicMatchHandler        As List(Of Tuple(Of Control, CancelEventHandler))
        Dim ldicCtrlToHandler       As Dictionary(Of Control, CancelEventHandler)

        'NSYS コントロールとValidateハンドラーの組み合わせ定義
        ldicCtrlToHandler = New Dictionary(Of Control, CancelEventHandler) From { _
                { cmbPd, AddressOf cmbPd_Validate }, _
                { cmbFlowClass, AddressOf cmbFlowClass_Validate }, _
                { cmbOpID, AddressOf cmbOpID_Validate }, _
                { cmbStepID, AddressOf cmbStepID_Validate }, _
                { calFromDate, AddressOf calFromDate_Validate }, _
                { calToDate, AddressOf calToDate_Validate }, _
                { calPlanAssThrowDate, AddressOf calPlanAssThrowDate_Validate }, _
                { calPlanFinishDate, AddressOf calPlanFinishDate_Validate }, _
                { calPlanShipDate, AddressOf calPlanShipDate_Validate } _
            }
        ldicMatchHandler = New List(Of Tuple(Of Control, CancelEventHandler))

        If ActiveControl IsNot Nothing Then
            Dim lblnMatch As Boolean = False
            ' 呼出し元コントロールの配列に ActiveControlが含まれるか
            For Each lctlCaller As Control In laryCallers
                If ActiveControl Is lctlCaller Then
                    lblnMatch = True
                End If
                ' Validateハンドラーコントロールの判定
                If ldicCtrlToHandler.ContainsKey(lctlCaller) = True Then
                    ldicMatchHandler.Add(Tuple.Create(lctlCaller, ldicCtrlToHandler(lctlCaller)))
                End If
            Next

            If lblnMatch = False Then
                ' ActiveControlが呼び出し元と異なる場合、フォーカス移動しない (VB6互換動作)
                Exit Sub
            End If
        End If

        Try
            ' Validateをハンドリングしているコントロールの場合は、ハンドラーをはずす
            For Each lPair As Tuple(Of Control, CancelEventHandler) In ldicMatchHandler
                RemoveHandler lPair.Item1.Validating, lPair.Item2
            Next
            ' フォーカスセット
            pubSetFocus(lctlNext)
        Finally
            ' Validateハンドラーを戻す
            For Each lPair As Tuple(Of Control, CancelEventHandler) In ldicMatchHandler
                AddHandler lPair.Item1.Validating, lPair.Item2
            Next
        End Try

    End Sub
End Class
