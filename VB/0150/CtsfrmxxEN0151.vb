'ﾌｧｲﾙ名：xxEN0151.frm
'説　明：装置別ロット一覧(防湿ALD)　メインフォーム
'作成日：2018/07/24 (Tue) 15:46:42 Y.Yoneyama
'更新日：2025/04/18 (Fri) 16:34:52 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2025, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN0151
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN0151    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN0151
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN0151
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN0151)
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
    '@↓2025/04/18 (Fri) 16:34:52 T.Oide **************************************************
    'Private Const CMstrLocalVersion                     As String = "01.03"
    Private Const CMstrLocalVersion                     As String = "01.04"
    '@↑2025/04/18 (Fri) 16:34:52 T.Oide **************************************************

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrlot_listald_Ver                  As String = "01.00"                 'ﾛｯﾄ一覧(防湿ALD)
    Private Const CMstreq__state___Ver                  As String = "03.00"                 '装置状態取得
    Private Const CMstrmas_McGrouplistVer               As String = "01.00"                 '装置ｸﾞﾙｰﾌﾟ取得
    Private Const CMstreq__areacurlistVer               As String = "02.00"                 'ｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置用途情報取得
    Private Const CMstrutilregtminfoVer                 As String = "06.00"                 '端末設定情報登録
    Private Const CMstrutilreftminfoVer                 As String = "04.00"                 '端末設定情報取得

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN0151          'ﾛｰｶﾙ機能ID

    '@vsfAreaEquipmentの定数宣言(幅)
    Private Const CMlngvsfAreaEqColWNo                  As Integer = 37                     '№
    Private Const CMlngvsfAreaEqColWKb                  As Integer = 27                     '保/停区分
    Private Const CMlngvsfAreaEqColWNowSt               As Integer = 15                     '状態
    Private Const CMlngvsfAreaEqColWLimitTime           As Integer = 189                    '時間制限(ﾃﾞｰﾀなし)
    Private Const CMlngvsfAreaEqColWRecipe              As Integer = 200                    'ﾚｼﾋﾟ
    Private Const CMlngvsfAreaEqColWPdID                As Integer = 53                     '機種
    Private Const CMlngvsfAreaEqColWLotID               As Integer = 110                    'ﾛｯﾄID
    Private Const CMlngvsfAreaEqColWWfID                As Integer = 144                    'WFID
    Private Const CMlngvsfAreaEqColWWfNum               As Integer = 133                    'WF枚数
    Private Const CMlngvsfAreaEqColWChipNum             As Integer = 133                    'ﾁｯﾌﾟ数
    Private Const CMlngvsfAreaEqColWCarrierID           As Integer = 65                     'ｷｬﾘｱID
    Private Const CMlngvsfAreaEqColWACarrierID          As Integer = 65                     'AｷｬﾘｱID
    Private Const CMlngvsfAreaEqColWTapeBatchID         As Integer = 53                     'ﾃｰﾌﾟﾊﾞｯﾁID
    Private Const CMlngvsfAreaEqColWOvenBatchID         As Integer = 53                     'ｵｰﾌﾞﾊﾞｯﾁID
    Private Const CMlngvsfAreaEqColWALDBatchID          As Integer = 53                     'ALDﾊﾞｯﾁID
    Private Const CMlngvsfAreaEqColWFlowClass           As Integer = 25                     '種別
    Private Const CMlngvsfAreaEqColWPriority            As Integer = 25                     '優先順位
    Private Const CMlngvsfAreaEqColWLcDirection         As Integer = 25                     '液晶方向
    Private Const CMlngvsfAreaEqColWOpID                As Integer = 133                    '大工程
    Private Const CMlngvsfAreaEqColWStepID              As Integer = 133                    '小工程
    Private Const CMlngvsfAreaEqColWLotManagerName      As Integer = 133                    'ﾛｯﾄ担当
    Private Const CMlngvsfAreaEqColWLotComments         As Integer = 133                    'ｺﾒﾝﾄ
    Private Const CMlngvsfAreaEqColWALDProcessNum       As Integer = 27                     '防湿ALD処理番号
    Private Const CMlngvsfAreaEqColWALDProcessName      As Integer = 133                    '防湿ALD処理名
    Private Const CMlngvsfAreaEqColWMonitorUseFlag      As Integer = 65
    Private Const CMlngvsfAreaEqColWBatchFlowClass      As Integer = 65

    '@vsfAreaEquipmentの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfAreaEqColTNo                  As String = "№"                    '№
    Private Const CMstrvsfAreaEqColTKb                  As String = ""                      '保/停区分
    Private Const CMstrvsfAreaEqColTNowSt               As String = "状態"                  '状態
    Private Const CMstrvsfAreaEqColTLimitTime           As String = "時間制限"              '時間制限
    Private Const CMstrvsfAreaEqColTRecipe              As String = "ﾚｼﾋﾟ"                  'ﾚｼﾋﾟ
    Private Const CMstrvsfAreaEqColTPdID                As String = "機種"                  '機種
    Private Const CMstrvsfAreaEqColTLotID               As String = "ﾛｯﾄID"                 'ﾛｯﾄID
    Private Const CMstrvsfAreaEqColTWfID                As String = "WFID"                  'WFID
    Private Const CMstrvsfAreaEqColTWfNum               As String = "WF数"                  'WF枚数
    Private Const CMstrvsfAreaEqColTChipNum             As String = "ﾁｯﾌﾟ"                  'ﾁｯﾌﾟ数
    Private Const CMstrvsfAreaEqColTCarrierID           As String = "ｷｬﾘｱID"                'ｷｬﾘｱID
    Private Const CMstrvsfAreaEqColTACarrierID          As String = "AｷｬﾘｱID"               'AｷｬﾘｱID
    Private Const CMstrvsfAreaEqColTTapeBatchID         As String = "ﾃｰﾌﾟﾊﾞｯﾁID"            'ﾃｰﾌﾟﾊﾞｯﾁID
    Private Const CMstrvsfAreaEqColTOvenBatchID         As String = "ｵｰﾌﾞﾝﾊﾞｯﾁID"           'ｵｰﾌﾞﾊﾞｯﾁID
    Private Const CMstrvsfAreaEqColTALDBatchID          As String = "ALDﾊﾞｯﾁID"             'ALDﾊﾞｯﾁID
    Private Const CMstrvsfAreaEqColTFlowClass           As String = "種別"                  '種別
    Private Const CMstrvsfAreaEqColTPriority            As String = "優"                    '優先順位
    Private Const CMstrvsfAreaEqColTLcDirection         As String = "液"                    '液晶方向
    Private Const CMstrvsfAreaEqColTOpID                As String = "大工程"                '大工程
    Private Const CMstrvsfAreaEqColTStepID              As String = "小工程"                '小工程
    Private Const CMstrvsfAreaEqColTLotManagerName      As String = "ﾛｯﾄ担当"               'ﾛｯﾄ担当
    Private Const CMstrvsfAreaEqColTLotComments         As String = "ｺﾒﾝﾄ"                  'ｺﾒﾝﾄ有無
    Private Const CMstrvsfAreaEqColTALDProcessNum       As String = ""                      '防湿ALD処理番号
    Private Const CMstrvsfAreaEqColTALDProcessName      As String = "処理名"                '防湿ALD処理名
    Private Const CMstrvsfAreaEqColTMonitorUseFlag      As String = "ﾓﾆﾀ"
    Private Const CMstrvsfAreaEqColTBatchFlowClass      As String = "ﾊﾞｯﾁ区分"

    '@ｸﾞﾘｯﾄﾞの設定
    Private Const CMlngvsfAreaEqRowTitle                As Integer = 0                      'ﾀｲﾄﾙ行(行)
    Private Const CMlngvsfAreaEqColTitle                As Integer = 0                      'ﾀｲﾄﾙ行(列)
    Private Const CMlngvsfAreaEqPageRows                As Integer = 10                     '1ﾍﾟｰｼﾞの表示行数
    Private Const CMlngvsfAreaEqHFontSize               As Integer = 12                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfAreaEqHHeight                 As Integer = 27                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngvsfAreaEqHeight                  As Integer = 38                     '1行の高さ
    Private Const CMlngStsBarIndex                      As Integer = 1                      'ｽﾃｰﾀｽﾊﾞｰの表示ｲﾝﾃﾞｯｸｽ
    Private Const CMlngvsfFrozenCols                    As Integer = 4                      '固定列数

    '@ﾛｯﾄ状態表記
    Private Const CMstrHo                               As String = "保"                    '保留表示
    Private Const CMstrTei                              As String = "停"                    '停止表示

    '@色指定
    Private Const CMlngVbColorWhite                     As Integer = &HFFFFFF               '白色
    Private Const CMlngVbColorBlack                     As Integer = &H0&                   '黒色

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                      As Integer = 16                     'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Integer = 16                     'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColName                   As Integer = 0                      '名称列番
    Private Const CMlngCmbGridColID                     As Integer = 1                      'ID列番(非表示項目)
    Private Const CMlngCmbDispCols                      As Integer = 1                      'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbRowHeight                     As Integer = 43                     'ﾘｽﾄ行の高さ
    Private Const CMlngCmbValueColWpId                  As Integer = 1                      '装置ID
    Private Const CMlngCmbValueColEqType                As Integer = 2                      'EQﾀｲﾌﾟ

    '@ｲﾍﾞﾝﾄ名称
    Private Const CMstrFormName                         As String = "frmxxEN0151"                   '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                         As String = "Form_Load"                     'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmdLotListClick                  As String = "cmdLotList_Click"              'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmdMcGroupNameValidate           As String = "cmbMcGroupName_Validate"       'ｲﾍﾞﾝﾄ名称
    Private Const CMstrArrowFormActivate                As String = "⇔Form_Activate"               'ｲﾍﾞﾝﾄ名
    Private Const CMstrArrowCmbMcGroupNameValidate      As String = "⇔cmbMcGroupName_Validate"     'ｲﾍﾞﾝﾄ名
    Private Const CMstrArrowCmbWpIDValidate             As String = "⇔cmbWpID_Validate"            'ｲﾍﾞﾝﾄ名
    Private Const CMstrArrowCmdLotDetailClick           As String = "⇔cmdLotDetail_Click"          'ｲﾍﾞﾝﾄ名

    '@保留/停止
    Private Const CMstrLotHoldFlgOn                     As String = "1"                     '保留ﾛｯﾄﾌﾗｸﾞON
    Private Const CMstrLotStopFlgOn                     As String = "1"                     '停止ﾛｯﾄﾌﾗｸﾞON

    '@稼動状態の表示
    Private Const CMstrWpStopFlag0                      As String = "0"
    Private Const CMstrWpStopFlag1                      As String = "1"
    Private Const CMstrWpMoveStop                       As String = "停止中"
    Private Const CMstrWpMoveFlow                       As String = "稼動中"

    '@WFID整形用
    Private Const CMstrWfIDCondChr                      As String = "#"                     'WFIDの8桁目
    Private Const CMlngWfIDCondChrPos                   As Integer = 8                      'WFIDの8桁目
    Private Const CMlngWfIDCondLength                   As Integer = 10                     'WFIDの桁数
    Private Const CMlngWfIDDispRightLength              As Integer = 3                      'WFIDの表示文字数(下3桁)
    Private Const CMlngWfIDDispRightLength2             As Integer = 2                      'WFIDの表示文字数(下2桁)

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mtypAreaEquipmentList                       As List(Of AreaEquipmentList)       '装置用途格納
    Private mlngAreaEqCnt                               As Integer                          '装置用途件数
    Private mstrCarrierID                               As String                           'ｷｬﾘｱID退避用
    Private mlngOutputCnt                               As Integer                          '出力総件数格納
    Private mstrMcGroupIDWk                             As String                           '装置ｸﾞﾙｰﾌﾟID退避用
    Private mstrWpIDWk                                  As String                           '装置ID退避用
    Private mstrMcGroupID                               As String                           '装置ｸﾞﾙｰﾌﾟID格納
    Private mstrWpID                                    As String                           '装置ID格納
    Private mstrWkWpID                                  As String                           '装置ID格納2
    Private mblnCmdFlag                                 As Boolean                          'ﾎﾞﾀﾝ制御ﾌﾗｸﾞ
    Private mblnLoadFlag                                As Boolean                          'Local起動ﾌﾗｸﾞ(True：起動、False：終了)
    Private mblnFormLoad1st                             As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞ初回ﾌﾗｸﾞ(Ture：初回、False：初回以降(ﾌｫｰﾑﾛｰﾄﾞ済み))
    Private mtypChgSort                                 As ChgSort                          'ｿｰﾄ保持用
    Private mtypCommonInfo                              As CommonInfo                       '引継ぎ構造体を格納
    Private mtypEqstate                                 As Eqstate                          '装置状態ﾘｽﾄ格納

    Private buttonProcessing                            As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                          'NSYS WindowCloseフラグ
    Private mintAreaEquipmentRowBeforeSort              As Integer                          'NSYS ｿｰﾄ時の選択行退避

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
        pubVsfMouseWheelManager_Set(vsfAreaEquipment, cmdUp, cmdDown, cmdLeft, cmdRight)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　起動時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns             As Boolean              '結果格納
        Dim ltypMcGroupList     As McGroupList          '装置ｸﾞﾙｰﾌﾟ情報格納
        Dim ltypDisp            As UtilRefTmInfo        '端末設定情報格納
        Dim lstrFormTitle       As String               'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        Dim llngCnt             As Integer              'ｶｳﾝﾀ

        Try

            '@子画面をAlt+F4で終了した場合に再表示できない為、ﾛｰｶﾙ変数に変更
            '@Form_Loadﾌﾗｸﾞ(True：正常、False：異常)(初期化)
            mblnLoadFlag = False

            '@=======================
            '@ 機能ﾊﾞｰｼﾞｮﾝ判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CMstrLocalMenuKey, CMstrLocalVersion)

            '@機能ﾊﾞｰｼﾞｮﾝ判定処理結果が"False：不一致"か
            If lblnAns = False Then
                Exit Sub
            End If

            '@防湿ALD以外の場合
            If pstrSBID <> CPstrSBID3A0 Then
                Exit Sub
            End If

            '@=======================
            '@ 機能関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CMstrLocalMenuKey, lstrFormTitle)

            '@ﾌｫｰﾑﾀｲﾄﾙ設定
            Me.Text = lstrFormTitle

            '@Escﾎﾞﾀﾝを無効にする(※ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない為に必要)
            Me.CancelButton = Nothing

            '@=======================
            '@ 画面初期化処理
            '@=======================
            Call prvFrmxxEN0151_Init()

            '@=======================
            '@ 装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ初期化
            '@=======================
            Call prvVsfAreaEquipment_Init()

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)

            '@=======================
            '@ 装置ｸﾞﾙｰﾌﾟ取得(処理区分="02"：全件)
            '@=======================
            lblnAns = pubblnMasMcGroupList_Sel(CMstrmas_McGrouplistVer, _
                                               CPstrCD02, _
                                               pstrSBID, _
                                               ltypMcGroupList)

            '@装置ｸﾞﾙｰﾌﾟ取得結果が"False：取得失敗"か
            If lblnAns = False Then

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)


            '@=======================
            '@ 装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ設定処理
            '@=======================
            Call prvcmbMcGroupName_Disp(ltypMcGroupList)

            '@=======================
            '@ ｺﾝﾋﾟｭｰﾀ名取得処理(META実行時はWBTのｸﾗｲｱﾝﾄ名)
            '@=======================
            Call pubGetWbtComputerName()

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)

            '@=======================
            '@ 端末設定情報取得
            '@=======================
            lblnAns = pubblnUtilRefTmInfo_Sel(pstrSBID, _
                                              CMstrutilreftminfoVer, _
                                              pstrComputerName, _
                                              ltypDisp)

            '@端末設定情報取得結果が"True：取得成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrFormLoad)

                With ltypDisp

                    '@端末情報の装置ｸﾞﾙｰﾌﾟIDがNULL以外、かつ装置IDもNULL以外か
                    If .strMcGroupID <> vbNullString And _
                        .strWpID <> vbNullString Then

                        '@各端末情報を変数に格納
                        mstrMcGroupID = .strMcGroupID       '装置ｸﾞﾙｰﾌﾟID
                        mstrWpID = .strWpID                 '装置ID
                    End If
                End With
            Else
                '@端末設定情報取得結果が"False：取得失敗"か

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
            End If


            '@-----------------------
            '@ 前回表示処理の実施ﾁｪｯｸ(装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ)
            '@-----------------------
            '@装置ｸﾞﾙｰﾌﾟ退避変数がNULL以外か
            If mstrMcGroupID <> vbNullString Then

                For llngCnt = 0 To ltypMcGroupList.lngMcGroupListCnt - 1

                    '@取得装置ｸﾞﾙｰﾌﾟIDと退避装置ｸﾞﾙｰﾌﾟが同じか
                    If ltypMcGroupList.typMcGroupList(llngCnt).strMcGroupID = mstrMcGroupID Then

                        '@一致ﾃﾞｰﾀを選択する
                        cmbMcGroupName.ListIndex = llngCnt

                        '@装置ｸﾞﾙｰﾌﾟIDを再格納
                        mstrMcGroupIDWk = mstrMcGroupID
                        Exit For
                    End If
                Next llngCnt
            End If


            '@装置ｸﾞﾙｰﾌﾟがNULL以外か(選択されているか)
            If cmbMcGroupName.Text <> vbNullString Then

                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrFormLoad)

                '@=======================
                '@ 装置ｸﾞﾙｰﾌﾟ別装置情報取得Call処理
                '@=======================
                lblnAns = prvblnEqAreaCurList_Sel(mtypAreaEquipmentList, _
                                                  mlngAreaEqCnt, _
                                                  cmbMcGroupName.Value)

                '@装置ｸﾞﾙｰﾌﾟ別装置情報取得Call処理結果が"False：取得失敗"か
                If lblnAns = False Then

                    '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                    Exit Sub
                End If

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrFormLoad)


                '@=======================
                '@ 装置名ｺﾝﾎﾞ設定処理
                '@=======================
                Call prvcmbWpID_Disp(mtypAreaEquipmentList, _
                                     mlngAreaEqCnt)

                '@-----------------------
                '@ 前回表示処理の実施ﾁｪｯｸ(装置名ｺﾝﾎﾞ)
                '@-----------------------
                '@装置名退避変数がNULL以外か
                If mstrWpID <> vbNullString Then

                    For llngCnt = 0 To mlngAreaEqCnt - 1

                        '@取得装置IDと退避装置IDが同じか
                        If mtypAreaEquipmentList(llngCnt).strWpID = mstrWpID Then

                            '@一致ﾃﾞｰﾀを選択する
                            cmbWpID.ListIndex = llngCnt

                            '@装置IDを再格納
                            mstrWpIDWk = mstrWpID
                            Exit For
                        End If
                    Next llngCnt
                End If


                '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞがNULL、または装置名ｺﾝﾎﾞがNULLか
                If cmbMcGroupName.Value = vbNullString Or _
                    cmbWpID.Value = vbNullString Then

                    '@未選択項目あり：最新取得ﾎﾞﾀﾝを無効にする
                    cmdLotList.Enabled = False
                Else
                    '@未選択項目なし：最新取得ﾎﾞﾀﾝを有効にする
                    cmdLotList.Enabled = True
                End If

            End If


            '@Localﾌｫｰﾑ起動ﾌﾗｸﾞの初期化(True：起動処理成功、False：起動処理失敗)
            mblnLoadFlag = True

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"True：起動処理成功"をｾｯﾄ(True：起動処理成功、False：起動処理失敗)
            pblnFormLoad = True

            '@初回ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"True：初回"をｾｯﾄ(True：初回、False：初回以降)
            mblnFormLoad1st = True

            '@ﾎﾞﾀﾝ制御ﾌﾗｸﾞの初期化(True：使用可、False：使用不可)
            mblnCmdFlag = True

            '@引継ぎ構造体を格納する(※ﾌｫｰﾑﾛｰﾄﾞ後のSTART_PROCで値がｸﾘｱされる為、退避する必要あり)
            mtypCommonInfo = ptypCommonInfo

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "Form_Load"              '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑ　ｱｸﾃｨﾌﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@初回ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True：初回"か(※初回ﾛｰﾄﾞのみ最新ﾛｯﾄ一覧を取得する)
            If mblnFormLoad1st = True Then

                '@-----------------------
                '@ 子画面をAlt+F4で終了した場合に再表示できない為、ﾛｰｶﾙ変数に変更
                '@ Local起動ﾌﾗｸﾞ(True：起動、False：終了)
                '@-----------------------
                '@Local起動ﾌﾗｸﾞが"True：起動"か
                If mblnLoadFlag = True Then

                    '@初回ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"False：初回以降(ﾌｫｰﾑﾛｰﾄﾞ済み)"をｾｯﾄ
                    mblnFormLoad1st = False

                    '@制御をOSに渡す
                    '@ﾌｫｰﾑﾛｰﾄﾞ中の通信に負荷がかかった場合にﾌｫｰﾑに制御を渡す
                    '@ｲﾍﾞﾝﾄを抑止する為、ﾌｫｰﾑをﾛｯｸする。
                    'DoEvents
                    Me.Refresh()

                    '@Escﾎﾞﾀﾝを有効
                    '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
                    Me.CancelButton = cmdClose

                    With ptypOnErrorInfo

                        '@ｴﾗｰ発生箇所の設定
                        .strErrPositionDetail = CMstrArrowFormActivate

                        '@=======================
                        '@ 最新取得ﾎﾞﾀﾝ処理
                        '@=======================
                        Call cmdLotList_Click(cmdLotList, New EventArgs())

                        '@ｴﾗｰ発生箇所の初期化
                        .strErrPositionDetail = vbNullString
                    End With
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "Form_Activate"          '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑ　ｷｰﾀﾞｳﾝ時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@以下の条件の場合、ｷｰｺｰﾄﾞを無効にし処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Then

                e.Handled = True
                Exit Sub
            End If


            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name

                '@〓 装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ 〓
                Case cmbMcGroupName.Name

                    '@Enterｷｰが押下されたか
                    If e.KeyCode = Keys.Return Then

                        '@=======================
                        '@ 装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞValidateｲ処理
                        '@=======================
                        RemoveHandler cmbMcGroupName.Validating, AddressOf cmbMcGroupName_Validate
                        Call cmbMcGroupName_Validate(cmbMcGroupName, New CancelEventArgs(True))
                        AddHandler cmbMcGroupName.Validating, AddressOf cmbMcGroupName_Validate

                        e.Handled = True
                        Exit Sub
                    End If

                '@〓 装置名ｺﾝﾎﾞ 〓
                Case cmbWpID.Name

                    '@Enterｷｰが押下されたか
                    If e.KeyCode = Keys.Return Then

                        '@=======================
                        '@ 装置名ｺﾝﾎﾞValidateｲ処理
                        '@=======================
                        RemoveHandler cmbWpID.Validating, AddressOf cmbWpID_Validate
                        Call cmbWpID_Validate(cmbWpID, New CancelEventArgs(True))
                        AddHandler cmbWpID.Validating, AddressOf cmbWpID_Validate

                        Exit Sub
                    End If

                '@〓 装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ 〓
                Case vsfAreaEquipment.Name

                    '@=======================
                    '@ ｸﾞﾘｯﾄﾞｷｰ制御処理(ｸﾞﾘｯﾄﾞ共通処理：上下ｽｸﾛｰﾙﾎﾞﾀﾝの制御)
                    '@=======================
                    Call pubVsf_KeyDown(e, ActiveControl.Name, vsfAreaEquipment, cmdUP, cmdDown)

                    '@=======================
                    '@ ｸﾞﾘｯﾄﾞｷｰ制御処理(ｸﾞﾘｯﾄﾞ共通処理：左右ｽｸﾛｰﾙﾎﾞﾀﾝの制御)
                    '@=======================
                    Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfAreaEquipment, cmdLeft, cmdRight)

                    '@★ ｷｰｺｰﾄﾞにより処理分岐 ★
                    Select Case e.KeyCode

                       '@〓 Enterｷｰ 〓
                        Case Keys.Return

                            '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                            Exit Sub

                    End Select

                '@〓 その他 〓
                Case Else

                    '@Enterｷｰが押下されたか
                    If e.KeyCode = Keys.Return Then

                        '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                        Exit Sub
                    End If

            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "Form_KeyDown"           '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑ　終了時処理
    '引　数：Cancel     ：ｷｬﾝｾﾙ値
    '　　　：UnloadMode ：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 10:14:49 M.Miura
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean          'ACT開放結果格納
        Dim ltypCommonInfo  As CommonInfo       '引継ぎ構造体

        Try
            
            '@ﾌｫｰﾑの"×"ﾎﾞﾀﾝ押下でのCallか
            If mblnCloseFromControlMenu Then

                '@=======================
                '@ 閉じるﾎﾞﾀﾝ処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs())
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload

            End If

            '@各種ﾓｼﾞｭｰﾙ配列/構造体の初期化
            '装置仕掛ﾛｯﾄﾘｽﾄ
            If Not IsNothing(mtypAreaEquipmentList) Then
                mtypAreaEquipmentList.Clear()
            End If
            'ｿｰﾄﾘｽﾄ
            If Not IsNothing(mtypChgSort.typChgSortList) Then
                mtypChgSort.typChgSortList.Clear()
            End If
            mtypCommonInfo = ltypCommonInfo                     '引継ぎﾘｽﾄ

            '@各種ﾓｼﾞｭｰﾙ変数の初期化
            mstrMcGroupIDWk = vbNullString                      '装置ｸﾞﾙｰﾌﾟID退避用
            mstrWpIDWk = vbNullString                           '装置ID退避用
            mstrMcGroupID = vbNullString                        '装置ｸﾞﾙｰﾌﾟID格納用
            mstrWpID = vbNullString                             '装置ID格納用
            mstrWkWpID = vbNullString                           '装置ID格納用2
            mstrCarrierID = vbNullString                        'ｷｬﾘｱID退避用

            '@ACT初期化ﾌﾗｸﾞが"True：自前で初期化済"か
            If pblnActInitFlg = True Then

                '@ACTｵﾌﾞｼﾞｪｸﾄの開放
                lblnAnsTerm = pubblnAct_Term()

                If lblnAnsTerm = True Then
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                End If
            Else
                '@ACT初期化ﾌﾗｸﾞが"False：自前で未初期化"の場合

                '@=======================
                '@ ﾒﾆｭｰ伸縮処理
                '@=======================
                Call pubMenuExpand_Disp()
            End If

            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "Form_QueryUnload"       '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGroupName_Change
    '機　能：[装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：。
    Private Sub cmbMcGroupName_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGroupName.Change

        Try

            '@以下の条件の場合、処理終了
            '@ ①ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False：起動失敗(起動中)"の場合(画面起動中は初期化を行わない)
            '@ ②ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ③ﾌｫｰﾑﾛｯｸ中の場合
            If pblnFormLoad = False Or _
                Cursor.Current = Cursors.WaitCursor Then

                Exit Sub
            End If


            '@-----------------------
            '@ 各種初期化処理
            '@-----------------------
            '@装置名ｺﾝﾎﾞ
            cmbWpID.Clear()
            cmbWpID.Enabled = False


            '@各種ﾗﾍﾞﾙ
            lblNowDate.Text = vbNullString              '情報取得日時
            lblLotCnt.Text = vbNullString               '該当件数
            lblEqUseName.Text = vbNullString            '装置状態
            lblMesMode.Text = vbNullString              '運用ﾓｰﾄﾞ
            lblWpStatusName.Text = vbNullString         '装置状態
            lblALDProcessName.Text = vbNullString       '処理名
            lblProcessUnit.Text = vbNullString          '処理単位
            
            '@=======================
            '@ 装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞｸﾘｱ処理
            '@=======================
            Call prvVsfAreaEquipment_Clr()

            '@退避変数
            mstrWpIDWk = vbNullString                   '装置ID
            mlngOutputCnt = 0                           '装置仕掛ﾛｯﾄ件数

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmbMcGroupName_Change"  '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGroupName_CloseUp
    '機　能：[装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub cmbMcGroupName_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGroupName.CloseUp

        Try

            '@装置ｸﾞﾙｰﾌﾟがNULL以外か
            If cmbMcGroupName.Text <> vbNullString Then

                '@=======================
                '@ 装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞValidate処理
                '@=======================
                RemoveHandler cmbMcGroupName.Validating, AddressOf cmbMcGroupName_Validate
                Call cmbMcGroupName_Validate(cmbMcGroupName, New CancelEventArgs(True))
                AddHandler cmbMcGroupName.Validating, AddressOf cmbMcGroupName_Validate

                '@装置仕掛ﾛｯﾄが存在するか
                If mlngOutputCnt > 0 Then
                    Exit Sub
                End If

                '@装置名ｺﾝﾎﾞが有効か
                If cmbWpID.Enabled = True Then

                    '@装置名ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbWpID)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmbMcGroupName_CloseUp" '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGroupName_Validate
    '機　能：[装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ　選択確定時(Validate)処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub cmbMcGroupName_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbMcGroupName.Validating

        Dim lblnAns                     As Boolean              '結果格納
        Dim llngAreaEqCnt               As Integer              '装置ｸﾞﾙｰﾌﾟ別装置情報ﾃﾞｰﾀ件数
        Dim lstrMcGroupID               As String               '装置ｸﾞﾙｰﾌﾟID格納
        Dim lstrWpId                    As String               '装置ID格納

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl Is cmdClose OrElse mblnWindowClose = True Then
                Exit Sub
            End If

            '@装置ｸﾞﾙｰﾌﾟが未選択、かつﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False：起動失敗(起動中)"か
            If cmbMcGroupName.Text = vbNullString And _
                pblnFormLoad = False Then

                Exit Sub
            Else
                '@装置ｸﾞﾙｰﾌﾟが選択済、またはﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True：起動成功"の場合

                '@前回選択の装置ｸﾞﾙｰﾌﾟIDと選択されている装置ｸﾞﾙｰﾌﾟIDが同じか
                If mstrMcGroupIDWk = cmbMcGroupName.Value Then

                    '@装置名ｺﾝﾎﾞが有効か
                    If cmbWpID.Enabled = True Then
                        If Me.ActiveControl Is cmbMcGroupName Then
                            '@装置名ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmbWpID)
                        End If
                    Else
                        If Me.ActiveControl Is cmbMcGroupName Then
                            '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdClose)
                        End If
                    End If

                    Exit Sub
                End If
            End If


            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdMcGroupNameValidate)

            '@=======================
            '@ 装置ｸﾞﾙｰﾌﾟ別装置情報取得Call処理
            '@=======================
            lblnAns = prvblnEqAreaCurList_Sel(mtypAreaEquipmentList, _
                                              llngAreaEqCnt, _
                                              cmbMcGroupName.Value)

            '@装置ｸﾞﾙｰﾌﾟ別装置情報取得Call処理結果が"False：取得失敗"か
            If lblnAns = False Then

                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdMcGroupNameValidate)

                '@装置ｸﾞﾙｰﾌﾟID退避用変数をｸﾘｱ
                mstrMcGroupIDWk = vbNullString
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrCmdMcGroupNameValidate)


            '@装置ｸﾞﾙｰﾌﾟID退避用変数、格納用変数にそれぞれ値を格納
            mstrMcGroupIDWk = cmbMcGroupName.Value
            lstrMcGroupID = cmbMcGroupName.Value

            '@退避装置ｸﾞﾙｰﾌﾟIDがNULL、かつ装置IDもNULLか
            If mstrMcGroupID = vbNullString And _
                mstrWpID = vbNullString Then

                '@装置名ｺﾝﾎﾞの値取得列をID列に設定
                cmbWpID.ValueCol = CMlngCmbValueColWpId

                '@現在表示されている装置のIDを変数に格納
                mstrWkWpID = cmbWpID.Value
            End If

            '@=======================
            '@ 装置名ｺﾝﾎﾞ設定処理
            '@=======================
            Call prvcmbWpID_Disp(mtypAreaEquipmentList, llngAreaEqCnt)

            '@装置ｸﾞﾙｰﾌﾟ別装置情報ﾃﾞｰﾀ件数を退避変数に格納
            mlngAreaEqCnt = llngAreaEqCnt

            '@退避装置ｸﾞﾙｰﾌﾟIDがNULL、かつ装置IDもNULLか
            If mstrMcGroupID = vbNullString And _
                mstrWpID = vbNullString Then

                '@装置ｸﾞﾙｰﾌﾟ別装置情報ﾃﾞｰﾀ件数が0件か
                If llngAreaEqCnt = 0 Then

                    '@装置名ｺﾝﾎﾞに空白を表示
                    cmbWpID.ListIndex = -1
                End If
            End If

            '@装置名ｺﾝﾎﾞの値取得列をID列に設定
            cmbWpID.ValueCol = CMlngCmbValueColWpId

            '@装置IDを格納
            lstrWpId = cmbWpID.Value

            '@装置ｸﾞﾙｰﾌﾟID、または装置IDがNULLか
            If lstrMcGroupID = vbNullString Or _
                lstrWpId = vbNullString Then

                '@最新取得ﾎﾞﾀﾝを無効にする
                cmdLotList.Enabled = False
            Else
                '@最新取得ﾎﾞﾀﾝを有効にする
                cmdLotList.Enabled = True
            End If


            '@装置ｸﾞﾙｰﾌﾟ別装置情報ﾃﾞｰﾀ件数が1件か
            If llngAreaEqCnt = 1 Then

                With ptypOnErrorInfo

                    '@ｴﾗｰ発生箇所の設定
                    .strErrPositionDetail = CMstrArrowCmbMcGroupNameValidate

                    '@=======================
                    '@ 最新取得ﾎﾞﾀﾝ処理
                    '@=======================
                    Call cmdLotList_Click(cmdLotList, New EventArgs())

                    '@ｴﾗｰ発生箇所の初期化
                    .strErrPositionDetail = vbNullString
                End With

                Exit Sub
            End If

            '@該当件数がNULL以外、かつ0件か
            If lblLotCnt.Text <> vbNullString And _
                lblLotCnt.Text = CPstrLotCnt0 Then

                '@情報取得日時表示
                lblNowDate.Text = Format$(Now, CPstrDateFormat)
            End If

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True：起動成功"か
            '@ ※直後にExitSubさせる為、移動
            If pblnFormLoad = True Then
                If Me.ActiveControl Is cmbMcGroupName Then
                    '@装置IDにﾌｫｰｶｽの移動
                    Call pubSetFocus(cmbWpID)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbMcGroupName_Validate"    '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWpID_Change
    '機　能：[装置名]ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：。
    Private Sub cmbWpID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWpID.Change

        Try

            '@以下の条件の場合、処理終了
            '@ ①ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False：起動失敗(起動中)"の場合(画面起動中は初期化を行わない)
            '@ ②ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ③ﾌｫｰﾑﾛｯｸ中の場合
            If pblnFormLoad = False Or _
                Cursor.Current = Cursors.WaitCursor Then

                Exit Sub
            End If

            '@各種ﾗﾍﾞﾙの初期化
            lblNowDate.Text = vbNullString           '情報取得日時
            lblLotCnt.Text = vbNullString            '該当件数
            lblEqUseName.Text = vbNullString         '装置状態
            lblMesMode.Text = vbNullString           '運用ﾓｰﾄﾞ
            lblWpStatusName.Text = vbNullString      '装置状態
            lblALDProcessName.Text = vbNullString    '処理名
            lblProcessUnit.Text = vbNullString       '処理単位

            '@=======================
            '@ 装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞｸﾘｱ処理
            '@=======================
            Call prvVsfAreaEquipment_Clr()

            '@装置ｸﾞﾙｰﾌﾟIDがNULL、または装置IDがNULLか
            If cmbMcGroupName.Value = vbNullString Or _
                cmbWpID.Value = vbNullString Then

                '@最新取得ﾎﾞﾀﾝを無効にする
                cmdLotList.Enabled = False
            Else
                '@最新取得ﾎﾞﾀﾝを有効にする
                cmdLotList.Enabled = True
            End If

            '@ｶﾚﾝﾄ行検索ｷｰの初期化
            mtypChgSort.strKey = vbNullString

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmbWpID_Change"         '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWpID_CloseUp
    '機　能：[装置名]ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub cmbWpID_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWpID.CloseUp

        Try

            '@ｴﾗｰ発生箇所の初期化
            ptypOnErrorInfo.strErrPositionDetail = vbNullString
            
            '@=======================
            '@ 装置名ｺﾝﾎﾞValidate処理
            '@=======================
            RemoveHandler cmbWpID.Validating, AddressOf cmbWpID_Validate
            Call cmbWpID_Validate(cmbWpID, New CancelEventArgs(False))
            AddHandler cmbWpID.Validating, AddressOf cmbWpID_Validate

            '@装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞにﾃﾞｰﾀがあるか
            If vsfAreaEquipment.Rows.Count > 1 Then

                '@装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfAreaEquipment)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmbWpID_CloseUp"        '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWpID_Validate
    '機　能：[装置名]ｺﾝﾎﾞ　選択確定時(Validate)処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub cmbWpID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbWpID.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@装置名が未選択か
            If cmbWpID.Value = vbNullString Then
                If Me.ActiveControl Is cmbWpID Then
                    '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
                Exit Sub
            End If

            '@前回選択装置と同じか
            If mstrWpIDWk = cmbWpID.Value Then

                '@装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞが有効か
                If vsfAreaEquipment.Enabled = True Then
                    If Me.ActiveControl Is cmbWpID Then
                        '@装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfAreaEquipment)
                    End If
                Else
                    If Me.ActiveControl Is cmbWpID Then
                        '@最新取得ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdLotList)
                    End If
                End If

                Exit Sub
            End If

            '@次回比較用に装置IDを退避
            mstrWpIDWk = cmbWpID.Value

            '@装置IDを退避
            mstrWpID = cmbWpID.Value

            '@装置名ｺﾝﾎﾞの値取得列をID列に設定
            cmbWpID.ValueCol = CMlngCmbValueColWpId

            With ptypOnErrorInfo

                '@ｴﾗｰ発生箇所の設定
                .strErrPositionDetail = CMstrArrowCmbWpIDValidate

                '@=======================
                '@ 最新取得ﾎﾞﾀﾝ処理
                '@=======================
                Call cmdLotList_Click(cmdLotList, New EventArgs())

                '@ｴﾗｰ発生箇所の初期化
                .strErrPositionDetail = vbNullString
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmbWpID_Validate"       '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLotList_Click
    '機　能：[最新取得]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：。
    Private Sub cmdLotList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotList.Click

        Dim lblnAns                     As Boolean              '結果格納
        Dim llngLotListCnt              As Integer              'ﾃﾞｰﾀ格納数
        Dim lstrMcGroupID               As String               'ｴﾘｱID格納
        Dim lstrWpId                    As String               '装置ID格納
        Dim ltypLotListReq              As LotListReq           'ﾛｯﾄ一覧要求構造体
        Dim ltypLotListALDAns           As LotListALDAns        'ﾛｯﾄ一覧応答格納用
        Dim ltypEqstate                 As Eqstate              '装置状態ﾘｽﾄ格納
        Dim ltypUtilRegTmInfo           As UtilRegTmInfo        '端末設定情報格納

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@出力総件数ｶｳﾝﾀの初期化
            mlngOutputCnt = 0
            mtypEqstate = ltypEqstate

            '@以下の条件の場合、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑのﾛｯｸ中の場合
            '@ ③装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞが未選択の場合
            '@ ④装置名ｺﾝﾎﾞが未選択の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                cmbMcGroupName.Text = vbNullString Or _
                cmbWpID.Text = vbNullString Then

                Exit Sub
            End If

            '@退避装置ｸﾞﾙｰﾌﾟIDがNULLか
            If mstrMcGroupID = vbNullString Then
                '@退避装置ｸﾞﾙｰﾌﾟIDがNULLの場合は選択装置ｸﾞﾙｰﾌﾟを格納
                lstrMcGroupID = cmbMcGroupName.Value
            Else
                '@退避装置ｸﾞﾙｰﾌﾟIDがNULL以外の場合は退避装置ｸﾞﾙｰﾌﾟを格納
                lstrMcGroupID = mstrMcGroupID
            End If

            '@装置名ｺﾝﾎﾞの値取得列を装置ID列に設定
            cmbWpID.ValueCol = CMlngCmbValueColWpId

            '@退避装置IDがNULLか
            If mstrWpID = vbNullString Then

                '@退避装置IDがNULLの場合は選択装置名の装置IDを格納
                lstrWpId = cmbWpID.Value
            Else
                '@退避装置IDがNULL以外の場合は退避装置IDを格納
                lstrWpId = mstrWpID
            End If

            '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞを無効にする
            cmbMcGroupName.Enabled = False

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdLotListClick)

            '@=======================
            '@ 装置状態取得
            '@=======================
            lblnAns = pubblnEqState_Sel(CMstreq__state___Ver, lstrWpId, mtypEqstate)

            '@装置状態取得結果が"True：取得成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdLotListClick)

                '@-----------------------
                '@ 端末設定情報登録処理
                '@-----------------------
                '@ﾚｽﾎﾟﾝｽ取得開始
                 Call pubResponseStart(CMstrFormName, CMstrCmdLotListClick)

                 '@=======================
                 '@ 端末設定情報登録
                 '@=======================
                 lblnAns = pubblnUtilRegTmInfo_Upd(pstrSBID, CMstrutilregtminfoVer, _
                                                   CPstrCD26, _
                                                   pstrComputerName, _
                                                   ltypUtilRegTmInfo, _
                                                   cmbWpID.Value, , , cmbMcGroupName.Value)

                 '@端末設定情報登録結果が"False：登録失敗"か
                 '@ ※端末情報登録は失敗しても処理を継続
                 If lblnAns = False Then

                    '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdLotListClick)

                    '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞを有効にする
                    cmbMcGroupName.Enabled = True
                End If
                    
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdLotListClick)

            Else
                '@装置状態取得結果が"False：取得失敗"か

                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdLotListClick)

                '@=======================
                '@ 装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ初期化
                '@=======================
                Call prvVsfAreaEquipment_Init()

                '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞを有効にする
                cmbMcGroupName.Enabled = True

                Exit Sub
            End If


            '@-----------------------
            '@ ﾛｯﾄ一覧情報取得処理
            '@-----------------------
            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotListReq
                .strMsgVer = CMstrlot_listald_Ver       'Msgﾊﾞｰｼﾞｮﾝ
                .strClassDivision = CPstrCD26           '処理区分：26(装置別ﾛｯﾄ一覧)
                .strSbID = pstrSBID                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strWpID = lstrWpId                     '装置ID
            End With

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdLotListClick)

            '@=======================
            '@ ﾛｯﾄ一覧情報取得
            '@=======================
            lblnAns = pubblnLotListALD_Sel(ltypLotListReq, ltypLotListALDAns, llngLotListCnt)

            '@ﾛｯﾄ一覧情報取得結果が"True：取得成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdLotListClick)

            Else
                '@ﾛｯﾄ一覧情報取得結果が"False：取得失敗"か

                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdLotListClick)

                '@=======================
                '@ 装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ初期化
                '@=======================
                Call prvVsfAreaEquipment_Init()

                '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞを有効にする
                cmbMcGroupName.Enabled = True

                Exit Sub
            End If

            '@=======================
            '@ 装置状態表示処理
            '@=======================
            Call prvWpStatus_Disp()

            '@=======================
            '@ 装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ表示処理
            '@=======================
            Call prvVsfAreaEquipment_Disp(ltypLotListALDAns, llngLotListCnt)


            '@取得装置仕掛ﾛｯﾄ件数を退避変数に格納
            mlngOutputCnt = llngLotListCnt

            '@各種ﾗﾍﾞﾙの表示
            lblNowDate.Text = Format$(Now, CPstrDateFormat)                  '情報取得日時表示
            lblLotCnt.Text = Format$(llngLotListCnt, CPstrDateFormatKanma)   '該当件数
            

            '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞを有効にする
            cmbMcGroupName.Enabled = True

            '@装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞが有効か
            If vsfAreaEquipment.Enabled = True Then

                '@装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfAreaEquipment)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞを有効にする
            cmbMcGroupName.Enabled = True

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = CMstrCmdLotListClick     '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfAreaEquipment_AfterSort
    '機　能：[装置仕掛ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ｿｰﾄ後処理
    '引　数：Col    ：列番号
    '　　　：Order  ：ｿｰﾄ値
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub vsfAreaEquipment_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfAreaEquipment.AfterSort

        Try
            'NSYS ソート前の選択行が有効行でない場合、ヘッダを選択行とする
            If mintAreaEquipmentRowBeforeSort <  vsfAreaEquipment.Rows.Fixed Then
                vsfAreaEquipment.Row = 0
            End If
            'NSYS ソート時のBeforeRowColChange/EnterCellイベントの抑制を解除する
            RemoveHandler vsfAreaEquipment.BeforeRowColChange, AddressOf vsfAreaEquipment_BeforeRowColChange
            RemoveHandler vsfAreaEquipment.EnterCell, AddressOf vsfAreaEquipment_EnterCell
            AddHandler vsfAreaEquipment.BeforeRowColChange, AddressOf vsfAreaEquipment_BeforeRowColChange
            AddHandler vsfAreaEquipment.EnterCell, AddressOf vsfAreaEquipment_EnterCell
            'NSYS データ行がない場合は処理を抜ける
            If vsfAreaEquipment.Rows.Count <= vsfAreaEquipment.Rows.Fixed Then
                Return
            End If
            
            '@ｿｰﾄ情報を格納
            With mtypChgSort
                Dim lChgSortList As ChgSortList = New ChgSortList()
                lChgSortList.lngCol = e.Col                 'ｿｰﾄ列番号を格納
                lChgSortList.lngOrder = e.Order             '並び替え方法を格納(昇順/降順)
                If IsNothing(.typChgSortList) Then
                    .typChgSortList = New List(Of ChgSortList)()
                End If
                .typChgSortList.Add(lChgSortList)
                .lngCnt = .lngCnt + 1                       'ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
            End With

            '@=======================
            '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfAfterSort(vsfAreaEquipment, CMlngvsfAreaEqColLotID & vbTab & _
                                                   CMlngvsfAreaEqColOpID & vbTab & _
                                                   CMlngvsfAreaEqColStepID, _
                                                   cmdUP, cmdDown)


            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "vsfAreaEquipment_AfterSort"     '処理名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfAreaEquipment_AfterUserResize
    '機　能：[装置仕掛ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ﾕｰｻﾞｰﾘｻｲｽﾞ後処理
    '引　数：Row    ：行番号
    '　　　：Col    ：列番号
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub vsfAreaEquipment_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfAreaEquipment.AfterResizeColumn, vsfAreaEquipment.AfterResizeRow

        Try

            '@列幅変更ﾌﾗｸﾞに"True：変更"をｾｯﾄ
            mtypChgSort.blnChgWidth = True

            '@=======================
            '@ 左右("<<",">>")ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
            '@=======================
            Call pubCmdLREnable_Set(vsfAreaEquipment, cmdLeft, cmdRight)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                         '機能ID
                .strProcName = "vsfAreaEquipment_AfterUserResize"       '処理名
                .strErrMessage = vbNullString                           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfAreaEquipment_BeforeRowColChange
    '機　能：[装置仕掛ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　行列変更前処理
    '引　数：OldRow ：旧行
    '　　　：OldCol ：旧列
    '　　　：NewRow ：新行
    '　　　：NewCol ：新列
    '　　　：Cancel ：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub vsfAreaEquipment_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfAreaEquipment.BeforeRowColChange

        Dim OldRow              As Integer      'NSYS 
        Dim NewRow              As Integer

        Try
            
            OldRow = e.OldRange.r1
            NewRow = e.NewRange.r1

            '@選択前行と選択行が違い、かつ選択行がﾃﾞｰﾀ行か
            If OldRow <> NewRow And NewRow > 0 Then

                '@ｶﾚﾝﾄ行検索用のｷｰを格納
                mtypChgSort.strKey = vsfAreaEquipment.GetData(NewRow, CMlngvsfAreaEqColLotID) & _
                                     vsfAreaEquipment.GetData(NewRow, CMlngvsfAreaEqColOpID) & _
                                     vsfAreaEquipment.GetData(NewRow, CMlngvsfAreaEqColStepID)

            End If

            '@選択行のｷｬﾘｱIDを退避
            If NewRow > 0 Then
                mstrCarrierID = vsfAreaEquipment.GetData(NewRow, CMlngvsfAreaEqColCarrierID)
            End If

            With vsfAreaEquipment

                '@選択行がﾍｯﾀﾞｰ行以外か
                If NewRow > 0 Then

                    '@ﾛｯﾄ情報詳細表示ﾎﾞﾀﾝを有効にする
                    cmdLotDetail.Enabled = True

                    '@運用ﾓｰﾄﾞが「S1」以外か
                    If lblMesMode.Text <> CPstrS1 Then

                        Exit Sub
                    End If

                Else
                    '@選択行がﾍｯﾀﾞｰ行の場合

                    '@各種ﾎﾞﾀﾝを無効にする
                    cmdLotDetail.Enabled = False                'ﾛｯﾄ情報詳細表示
                End If

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                         '機能ID
                .strProcName = "vsfAreaEquipment_BeforeRowColChange"    '処理名
                .strErrMessage = vbNullString                           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfAreaEquipment_BeforeSort
    '機　能：[装置仕掛ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub vsfAreaEquipment_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfAreaEquipment.BeforeSort

        Try
            'NSYS ソート時はBeforeRowColChange/EnterCellを抑制する
            RemoveHandler vsfAreaEquipment.BeforeRowColChange, AddressOf vsfAreaEquipment_BeforeRowColChange
            RemoveHandler vsfAreaEquipment.EnterCell, AddressOf vsfAreaEquipment_EnterCell
            mintAreaEquipmentRowBeforeSort = vsfAreaEquipment.Row 'NSYS ソート前の選択行を保持
            'NSYS データ行がない場合は処理を抜ける
            If vsfAreaEquipment.Rows.Count <= vsfAreaEquipment.Rows.Fixed Then
                Return
            End If

            '@=======================
            '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfBeforeSort(vsfAreaEquipment, CMlngvsfAreaEqColLotID & vbTab & _
                                                    CMlngvsfAreaEqColOpID & vbTab & _
                                                    CMlngvsfAreaEqColStepID)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                     '機能ID
                .strProcName = "vsfAreaEquipment_BeforeSort"        '処理名
                .strErrMessage = vbNullString                       'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfAreaEquipment_EnterCell
    '機　能：[装置仕掛ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub vsfAreaEquipment_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfAreaEquipment.EnterCell

        Try
            
            With vsfAreaEquipment

                '@ﾍｯﾀﾞｰ以外が選択されたか
                If .Row > 0 Then
                    
                    '@MO/QUの場合&成膜装置の場合
                    If (.GetData(.Row, CMlngvsfAreaEqColFlowClass) = CPstrFlowClassMO Or _
                        .GetData(.Row, CMlngvsfAreaEqColFlowClass) = CPstrFlowClassQU) And _
                        .GetData(.Row, CMlngvsfAreaEqColALDProcessNum) = CPstrALDProcessNum_40 Then
                        
                        cmdACarrierMoQuFdSelect.Enabled = True
                    Else
                        cmdACarrierMoQuFdSelect.Enabled = False
                    End If
                    
                    '@***********************
                    '@ 引継ぎ情報作成
                    '@***********************
                    ptypCommonInfo.strCarrierId = .GetData(.Row, CMlngvsfAreaEqColCarrierID)
                    ptypCommonInfo.strLotID = .GetData(.Row, CMlngvsfAreaEqColLotID)
                    ptypCommonInfo.strFlowClass = .GetData(.Row, CMlngvsfAreaEqColFlowClass)
                    ptypCommonInfo.strACarrierId = .GetData(.Row, CMlngvsfAreaEqColACarrierID)
                    ptypCommonInfo.strAldBatchId = .GetData(.Row, CMlngvsfAreaEqColALDBatchID)
                    ptypCommonInfo.strTapeBatchId = .GetData(.Row, CMlngvsfAreaEqColTapeBatchID)
                    ptypCommonInfo.strOvenBatchId = .GetData(.Row, CMlngvsfAreaEqColOvenBatchID)
                    ptypCommonInfo.strOpID = .GetData(.Row, CMlngvsfAreaEqColOpID)
                    ptypCommonInfo.strStepID = .GetData(.Row, CMlngvsfAreaEqColStepID)
                    ptypCommonInfo.strWpID = cmbWpID.Value
                    
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "vsfAreaEquipment_EnterCell"     '処理名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLeft_Click
    '機　能：[左(<<)ｽｸﾛｰﾙ]ﾎﾞﾀﾝ(装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub cmdLeft_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLeft.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@ 左("<<")ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdLeft(vsfAreaEquipment, cmdLeft, cmdRight)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdLeft_Click"          '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRight_Click
    '機　能：[右(>>)ｽｸﾛｰﾙ]ﾎﾞﾀﾝ(装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub cmdRight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRight.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@ 右(">>")ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdRight(vsfAreaEquipment, cmdLeft, cmdRight)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdRight_Click"         '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：[上(▲)ｽｸﾛｰﾙ]ﾎﾞﾀﾝ(装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
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

            '@=======================
            '@ 上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdUp(vsfAreaEquipment, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdUp_Click"            '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown_Click
    '機　能：[下(▼)ｽｸﾛｰﾙ]ﾎﾞﾀﾝ(装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
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

            '@=======================
            '@ 下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdDown(vsfAreaEquipment, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdDown_Click"          '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
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
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim ltypCommonInfo  As CommonInfo   '引継ぎ構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の条件の場合、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Then

                Exit Sub
            End If

            '@=======================
            '@ 終了処理
            '@=======================
            Call publngEnd_Proc(CMstrLocalMenuKey, ltypCommonInfo)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdClose_Click"         '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLotDetail_Click
    '機　能：[ﾛｯﾄ情報詳細表示]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub cmdLotDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotDetail.Click

        Dim lstrTitle       As String       'ﾀｲﾄﾙ

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の条件の場合、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Then

                Exit Sub
            End If

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化(True：起動成功、False：起動中(起動失敗)・初期値)
            pblnFormLoad = False

            '@ﾌｫｰﾑ起動区分に"True：子画面起動"をｾｯﾄ
            pblnfrmxxCM00R0Kbn = True


            '@***********************
            '@ 引継ぎ情報作成
            '@***********************
            With ptypCommonInfo

                '@ｷｬﾘｱID
                .strCarrierId = mstrCarrierID

                '@=======================
                '@ 機能関連情報取得
                '@=======================
                Call pubMenuItemCorrelation_Set(CPstrKeyEN01C0, lstrTitle)

                '@ﾛｯﾄ情報詳細画面のﾌｫｰﾑｷｬﾌﾟｼｮﾝに設定
                frmxxCM00R0.Instance.Text = lstrTitle

                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False：初期値"か
                If pblnFormLoad = False Then

                    '@***********************
                    '@■■ 改善Point ■■
                    '@ 一応、子画面をUnloadするところまではOKだが、
                    '@ ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞをTrueにしているところを見ると、
                    '@ 起動が成功することが約束された形の処理になっている。
                    '@ まずは"Load frmxxXX"の処理を行い、子画面のForm_Load処理で
                    '@ ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの設定を行うように改善する必要あり！！
                    '@***********************

                    '@∇∇∇∇∇∇∇∇∇∇∇
                    '@ ｱﾝﾛｰﾄﾞ処理
                    '@∇∇∇∇∇∇∇∇∇∇∇
                    frmxxCM00R0.Instance = Nothing

                    '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
                    pblnFormLoad = True

                    '@各種ﾎﾞﾀﾝ制御ﾌﾗｸﾞに"True：有効化"をｾｯﾄ
                    mblnCmdFlag = True
                    Exit Sub
                End If

                '@閉じるﾎﾞﾀﾝを無効にする(閉じる連打で落ちるのを回避)
                cmdClose.Enabled = False


                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@ ﾛｯﾄ情報詳細画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM00R0.Instance.ShowDialog(Me)
                frmxxCM00R0.Instance = Nothing

                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
                pblnFormLoad = True

                '@各種ﾎﾞﾀﾝ制御ﾌﾗｸﾞに"True：有効化"をｾｯﾄ
                mblnCmdFlag = True

                '@装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞにﾃﾞｰﾀがあるか
                If vsfAreaEquipment.Rows.Count > 1 Then

                    With ptypOnErrorInfo

                        '@ｴﾗｰ発生箇所の設定
                        .strErrPositionDetail = CMstrArrowCmdLotDetailClick

                        '@=======================
                        '@ 最新取得ﾎﾞﾀﾝ処理
                        '@=======================
                        Call cmdLotList_Click(cmdLotList, New EventArgs())

                        '@ｴﾗｰ発生箇所の初期化
                        .strErrPositionDetail = vbNullString

                    End With
                End If

                '@閉じるﾎﾞﾀﾝを有効にする(閉じる連打で落ちるのを回避)
                cmdClose.Enabled = True
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdLotDetail_Click"     '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdACarrierMoQuFdSelect
    '機　能：Aｷｬﾘｱ(MO/QU/FD)選択
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/02 (Thu) 17:58:01 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub cmdACarrierMoQuFdSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdACarrierMoQuFdSelect.Click

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
            
            With vsfAreaEquipment
            
                If .Row = CMlngvsfAreaEqRowTitle Then
                    Exit Sub
                End If
            
                '@ALDﾊﾞｯﾁIDがNULL時は実行しない
                If .GetData(.Row, CMlngvsfAreaEqColALDBatchID) = vbNullString Then
                    Exit Sub
                End If
            
                '@ﾊﾟﾌﾞﾘｯｸ変数に引継
                ptypACarrierGroup.strAldBatchId = .GetData(.Row, CMlngvsfAreaEqColALDBatchID)
            End With
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ Aｷｬﾘｱ選択画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00E2.Instance = New frmxxCM00E2()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM00E2.Instance = Nothing
                
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ Aｷｬﾘｱ選択画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00E2.Instance.ShowDialog(Me)
            frmxxCM00E2.Instance = Nothing
            
            '@=======================
            '@ 最新取得ﾎﾞﾀﾝ処理
            '@=======================
            Call cmdLotList_Click(cmdLotList, New EventArgs())
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdACarrierMoQuFdSelect"    'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub


    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：prvFrmxxEN0151_Init
    '機　能：画面初期化処理
    '引　数：lblnMcGroupID：(True：装置ｸﾞﾙｰﾌﾟ項目初期化、False：装置ｸﾞﾙｰﾌﾟ項目無変更)
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvFrmxxEN0151_Init(Optional ByVal lblnMcGroupID As Boolean = False)

        Try

            '@各種ﾗﾍﾞﾙの初期化
            lblTitleD.BackColor = ColorTranslator.FromWin32(CPlngVbColorOrange)    'ﾀﾞﾐｰ
            lblTitleHT.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)    '保留/停止
            lblTitleWpNotUseLot.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
            lblTitleMonitorUseBatch.BackColor = ColorTranslator.FromWin32(CPlngSpecialEditColor)
            lblEqUseName.Text = vbNullString         '装置状態
            lblMesMode.Text = vbNullString           '運用ﾓｰﾄﾞ
            lblWpStatusName.Text = vbNullString      '処理状態
            lblALDProcessName.Text = vbNullString    '処理名
            lblProcessUnit.Text = vbNullString       '処理単位

            '@各種ﾓｼﾞｭｰﾙ変数の初期化
            mstrWpID = vbNullString                     '装置ID退避用変数
            mstrWpIDWk = vbNullString                   '装置ID退避用変数
            mstrWkWpID = vbNullString                   '装置ID退避用変数
            mstrMcGroupID = vbNullString                '装置ｸﾞﾙｰﾌﾟ退避用変数
            mstrMcGroupIDWk = vbNullString              '装置ｸﾞﾙｰﾌﾟ退避用変数

            '@ｿｰﾄ保持構造体の初期化
            With mtypChgSort
                .lngCnt = 0                             'ｶｳﾝﾀ
                '格納配列
                If IsNothing(.typChgSortList) Then
                    .typChgSortList = New List(Of ChgSortList)
                Else
                    .typChgSortList.Clear()
                End If
                .blnChgWidth = False                    '列幅変更ﾌﾗｸﾞ(False：未変更)
                .strKey = vbNullString                  'ｶﾚﾝﾄ行検索ｷｰ
            End With

            '@装置ｺﾝﾎﾞの初期化
            cmbWpID.Clear()                             '装置ID(WPID)項目
            cmbWpID.Enabled = False                     '装置ｺﾝﾎﾞ

            '@各種ﾎﾞﾀﾝの初期化
            cmdLotList.Enabled = False                  '最新取得
            cmdUP.Enabled = False                       '上(▲)ｽｸﾛｰﾙ
            cmdDown.Enabled = False                     '下(▼)ｽｸﾛｰﾙ
            cmdLeft.Enabled = False                     '左(<<)ｽｸﾛｰﾙ
            cmdRight.Enabled = False                    '右(>>)ｽｸﾛｰﾙ
            cmdLotDetail.Enabled = False                'ﾛｯﾄ情報詳細表示
            cmdACarrierMoQuFdSelect.Enabled = False

            '@閉じるﾎﾞﾀﾝのCausesValidationを設定(False：ﾌｫｰｶｽLost時に入力ﾁｪｯｸをしない)
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvFrmxxEN0151_Init"    '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfAreaEquipment_Clr
    '機　能：[装置仕掛ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞｸﾘｱ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvVsfAreaEquipment_Clr()

        Try

            With vsfAreaEquipment

                .Rows.Count = .Rows.Fixed  '行数
                .Enabled = False           '無効

                '@ﾕｰｻﾞｰﾘｻｲｽﾞが実施されていないか
                If mtypChgSort.blnChgWidth = False Then
                    ' NSYS AllowMergingの設定がNone以外だとAutoSizeColの動作が異なるためNoneに設定
                    .AllowMerging = AllowMergingEnum.None 

                    '@自動で列幅を調整する
                    '.AutoSizeMode = flexAutoSizeColWidth
                    .AutoSizeCols(CMlngvsfAreaEqColNo, .Cols.Count - 1, 6)
                End If

            End With

            '@各種ﾗﾍﾞﾙのｸﾘｱ
            lblNowDate.Text = vbNullString          '情報取得日時
            lblLotCnt.Text = vbNullString           '該当件数

            '@各種ｽｸﾛｰﾙﾎﾞﾀﾝの無効化
            cmdLeft.Enabled = False                 '左(<<)ｽｸﾛｰﾙ
            cmdRight.Enabled = False                '右(>>)ｽｸﾛｰﾙ
            cmdUP.Enabled = False                   '上(▲)ｽｸﾛｰﾙ
            cmdDown.Enabled = False                 '下(▼)ｽｸﾛｰﾙ

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvVsfAreaEquipment_Clr"       '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfAreaEquipment_Init
    '機　能：[装置仕掛ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvVsfAreaEquipment_Init()

        Dim llngCnt     As Integer   '汎用ｶｳﾝﾀ
        Dim cellRange   As CellRange 'NSYS 追加Sytle設定範囲
        Dim headerStyle As CellStyle 'NSYS ヘッダー用追加Style


        Try

            '@装置状態関連ﾗﾍﾞﾙの初期化
            lblEqUseName.Text = vbNullString             '装置状態
            lblMesMode.Text = vbNullString               '運用ﾓｰﾄﾞ
            lblWpStatusName.Text = vbNullString          '処理状態
            lblALDProcessName.Text = vbNullString        '処理名
            lblProcessUnit.Text = vbNullString           '処理単位
            
            With vsfAreaEquipment

                .Redraw = False                                   '描画ﾛｯｸ
                .Clear()                                          'ｸﾘｱ
                .Cols.Count = CMlngvsfAreaEqColBatchFlowClass + 1
                .Rows.Count = .Rows.Fixed                         '初期行数設定
                .AllowResizing = AllowResizingEnum.Columns        '行列のﾏｳｽでの変更を可にする
                .SelectionMode = SelectionModeEnum.Row            'ｾﾙ選択の設定
                '.Styles.Normal.Trimming = StringTrimming.EllipsisCharacter '省略符号(...)を文字列の最後に表示
                .HighLight = HighLightEnum.Always                 'ﾊｲﾗｲﾄ表示
                .FocusRect = FocusRectEnum.Light                  'ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .Styles.Normal.WordWrap = True '折り返し表示      '時間制限、WF_IDを折り返し表示することが目的
                .Cols.Frozen = CMlngvsfFrozenCols                 '固定列の設定

                '@一覧表の表題設定
                headerStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                  '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))    '背景色
                headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMlngvsfAreaEqHFontSize, _
                                            headerStyle.Font.Style, headerStyle.Font.Unit)            'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                    '文字位置
                headerStyle.Trimming = StringTrimming.None                                            'NSYS ﾍｯﾀﾞは省略表示なしに設定
                cellRange = .GetCellRange(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColNo, _
                                          CMlngvsfAreaEqRowTitle, .Cols.Count - 1)
                cellRange.Style = headerStyle

                '@ﾕｰｻﾞｰﾘｻｲｽﾞが行われていないか(False：未変更)
                If mtypChgSort.blnChgWidth = False Then
                    '@列幅設定
                    .Cols(CMlngvsfAreaEqColNo).Width = CMlngvsfAreaEqColWNo
                    .Cols(CMlngvsfAreaEqColKb).Width = CMlngvsfAreaEqColWNowSt
                    .Cols(CMlngvsfAreaEqColNowSt).Width = CMlngvsfAreaEqColWLimitTime
                    .Cols(CMlngvsfAreaEqColLimitTime).Width = CMlngvsfAreaEqColWLimitTime
                    .Cols(CMlngvsfAreaEqColRecipe).Width = CMlngvsfAreaEqColWRecipe
                    .Cols(CMlngvsfAreaEqColPdID).Width = CMlngvsfAreaEqColWPdID
                    .Cols(CMlngvsfAreaEqColLotID).Width = CMlngvsfAreaEqColWLotID
                    .Cols(CMlngvsfAreaEqColWfId).Width = CMlngvsfAreaEqColWWfID
                    .Cols(CMlngvsfAreaEqColWfNum).Width = CMlngvsfAreaEqColWWfNum
                    .Cols(CMlngvsfAreaEqColChipNum).Width = CMlngvsfAreaEqColWChipNum
                    .Cols(CMlngvsfAreaEqColCarrierID).Width = CMlngvsfAreaEqColWCarrierID
                    .Cols(CMlngvsfAreaEqColACarrierID).Width = CMlngvsfAreaEqColWACarrierID
                    .Cols(CMlngvsfAreaEqColTapeBatchID).Width = CMlngvsfAreaEqColWTapeBatchID
                    .Cols(CMlngvsfAreaEqColOvenBatchID).Width = CMlngvsfAreaEqColWOvenBatchID
                    .Cols(CMlngvsfAreaEqColALDBatchID).Width = CMlngvsfAreaEqColWALDBatchID
                    .Cols(CMlngvsfAreaEqColFlowClass).Width = CMlngvsfAreaEqColWFlowClass
                    .Cols(CMlngvsfAreaEqColPriority).Width = CMlngvsfAreaEqColWPriority
                    .Cols(CMlngvsfAreaEqColLcDirection).Width = CMlngvsfAreaEqColWLcDirection
                    .Cols(CMlngvsfAreaEqColOpID).Width = CMlngvsfAreaEqColWOpID
                    .Cols(CMlngvsfAreaEqColStepID).Width = CMlngvsfAreaEqColWStepID
                    .Cols(CMlngvsfAreaEqColLotManagerName).Width = CMlngvsfAreaEqColWLotManagerName
                    .Cols(CMlngvsfAreaEqColLotComments).Width = CMlngvsfAreaEqColWLotComments
                    .Cols(CMlngvsfAreaEqColALDProcessNum).Width = CMlngvsfAreaEqColWALDProcessNum
                    .Cols(CMlngvsfAreaEqColALDProcessName).Width = CMlngvsfAreaEqColWALDProcessName
                    .Cols(CMlngvsfAreaEqColMonitorUseFlag).Width = CMlngvsfAreaEqColWMonitorUseFlag
                    .Cols(CMlngvsfAreaEqColBatchFlowClass).Width = CMlngvsfAreaEqColWBatchFlowClass
                End If

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColNo, CMstrvsfAreaEqColTNo)                                   'No.
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColNowSt, CMstrvsfAreaEqColTNowSt)                             '状態
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColLimitTime, CMstrvsfAreaEqColTLimitTime)                     '時間制限
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColRecipe, CMstrvsfAreaEqColTRecipe)                           'ﾚｼﾋﾟ
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColPdID, CMstrvsfAreaEqColTPdID)                               '機種
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColLotID, CMstrvsfAreaEqColTLotID)                             'ﾛｯﾄID
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColWfId, CMstrvsfAreaEqColTWfID)                               'WD_ID
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColWfNum, CMstrvsfAreaEqColTWfNum)                             'WF枚数
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColChipNum, CMstrvsfAreaEqColTChipNum)                         'ﾁｯﾌﾟ数
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColCarrierID, CMstrvsfAreaEqColTCarrierID)                     'ｷｬﾘｱID
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColACarrierID, CMstrvsfAreaEqColTACarrierID)                   'AｷｬﾘｱID
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColTapeBatchID, CMstrvsfAreaEqColTTapeBatchID)                 'ﾃｰﾌﾟﾊﾞｯﾁID
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColOvenBatchID, CMstrvsfAreaEqColTOvenBatchID)                 'ｵｰﾌﾞﾊﾞｯﾁID
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColALDBatchID, CMstrvsfAreaEqColTALDBatchID)                   'ALDﾊﾞｯﾁID
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColFlowClass, CMstrvsfAreaEqColTFlowClass)                     '種別
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColPriority, CMstrvsfAreaEqColTPriority)                       '優先度
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColLcDirection, CMstrvsfAreaEqColTLcDirection)                 '液晶方向
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColOpID, CMstrvsfAreaEqColTOpID)                               '大工程
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColStepID, CMstrvsfAreaEqColTStepID)                           '小工程
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColLotManagerName, CMstrvsfAreaEqColTLotManagerName)           'ﾛｯﾄ担当
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColLotComments, CMstrvsfAreaEqColTLotComments)                 'ｺﾒﾝﾄ
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColALDProcessNum, CMstrvsfAreaEqColTALDProcessNum)             '防湿ALD処理番号
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColALDProcessName, CMstrvsfAreaEqColTALDProcessName)           '防湿ALD処理名
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColMonitorUseFlag, CMstrvsfAreaEqColTMonitorUseFlag)
                .SetData(CMlngvsfAreaEqRowTitle, CMlngvsfAreaEqColBatchFlowClass, CMstrvsfAreaEqColTBatchFlowClass)

                '@Cellの表示位置設定(デフォルト右上)
                For llngCnt = 0 To .Cols.Count - 1
                    .Cols(llngCnt).TextAlign = TextAlignEnum.LeftCenter 'flexAlignLeftCenter
                Next
                
                '@DataType
                .Cols(CMlngvsfAreaEqColNo).DataType = GetType(Int32)
                .Cols(CMlngvsfAreaEqColWfNum).DataType = GetType(Int32)
                .Cols(CMlngvsfAreaEqColChipNum).DataType = GetType(Int32)
                .Cols(CMlngvsfAreaEqColALDProcessNum).DataType = GetType(Int32)
                .Cols(CMlngvsfAreaEqColMonitorUseFlag).DataType = GetType(Int32)
                .Cols(CMlngvsfAreaEqColBatchFlowClass).DataType = GetType(Int32)

                '@表示位置
                .Cols(CMlngvsfAreaEqColNo).TextAlign = TextAlignEnum.RightCenter                'No.
                .Cols(CMlngvsfAreaEqColNowSt).TextAlign = TextAlignEnum.LeftCenter              '状態
                .Cols(CMlngvsfAreaEqColLimitTime).TextAlign = TextAlignEnum.LeftCenter          '時間制限
                .Cols(CMlngvsfAreaEqColRecipe).TextAlign = TextAlignEnum.LeftCenter             'ﾚｼﾋﾟ
                .Cols(CMlngvsfAreaEqColPdID).TextAlign = TextAlignEnum.LeftCenter               '機種
                .Cols(CMlngvsfAreaEqColLotID).TextAlign = TextAlignEnum.LeftCenter              'ﾛｯﾄID
                .Cols(CMlngvsfAreaEqColWfId).TextAlign = TextAlignEnum.LeftCenter               'WD_ID
                .Cols(CMlngvsfAreaEqColWfNum).TextAlign = TextAlignEnum.RightCenter             'WF枚数
                .Cols(CMlngvsfAreaEqColChipNum).TextAlign = TextAlignEnum.RightCenter           'ﾁｯﾌﾟ数
                .Cols(CMlngvsfAreaEqColCarrierID).TextAlign = TextAlignEnum.LeftCenter          'ｷｬﾘｱID
                .Cols(CMlngvsfAreaEqColACarrierID).TextAlign = TextAlignEnum.LeftCenter         'AｷｬﾘｱID
                .Cols(CMlngvsfAreaEqColTapeBatchID).TextAlign = TextAlignEnum.LeftCenter        'ﾃｰﾌﾟﾊﾞｯﾁID
                .Cols(CMlngvsfAreaEqColOvenBatchID).TextAlign = TextAlignEnum.LeftCenter        'ｵｰﾌﾞﾊﾞｯﾁID
                .Cols(CMlngvsfAreaEqColALDBatchID).TextAlign = TextAlignEnum.LeftCenter         'ALDﾊﾞｯﾁID
                .Cols(CMlngvsfAreaEqColFlowClass).TextAlign = TextAlignEnum.LeftCenter          '種別
                .Cols(CMlngvsfAreaEqColPriority).TextAlign = TextAlignEnum.RightCenter          '優先度
                .Cols(CMlngvsfAreaEqColLcDirection).TextAlign = TextAlignEnum.LeftCenter        '液晶方向
                .Cols(CMlngvsfAreaEqColOpID).TextAlign = TextAlignEnum.LeftCenter               '大工程
                .Cols(CMlngvsfAreaEqColStepID).TextAlign = TextAlignEnum.LeftCenter             '小工程
                .Cols(CMlngvsfAreaEqColLotManagerName).TextAlign = TextAlignEnum.LeftCenter     'ﾛｯﾄ担当
                .Cols(CMlngvsfAreaEqColLotComments).TextAlign = TextAlignEnum.LeftCenter        'ｺﾒﾝﾄ
                .Cols(CMlngvsfAreaEqColALDProcessNum).TextAlign = TextAlignEnum.RightCenter     '防湿ALD処理番号
                .Cols(CMlngvsfAreaEqColALDProcessName).TextAlign = TextAlignEnum.LeftCenter     '防湿ALD処理名
                .Cols(CMlngvsfAreaEqColMonitorUseFlag).TextAlign = TextAlignEnum.RightCenter 
                .Cols(CMlngvsfAreaEqColBatchFlowClass).TextAlign = TextAlignEnum.RightCenter 

                '@非表示
                .Cols(CMlngvsfAreaEqColACarrierID).Visible = False
                .Cols(CMlngvsfAreaEqColLcDirection).Visible = False
                .Cols(CMlngvsfAreaEqColALDProcessNum).Visible = False
                .Cols(CMlngvsfAreaEqColMonitorUseFlag).Visible = False
                .Cols(CMlngvsfAreaEqColBatchFlowClass).Visible = False
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngvsfAreaEqRowTitle).Height = CMlngvsfAreaEqHHeight

                '@ﾕｰｻﾞｰﾘｻｲｽﾞが行われていないか(False：未変更)
                If mtypChgSort.blnChgWidth = False Then
                    ' NSYS AllowMergingの設定がNone以外だとAutoSizeColの動作が異なるためNoneに設定
                    .AllowMerging = AllowMergingEnum.None 

                    '@列幅の自動調整を行う
                    '.AutoSizeMode = flexAutoSizeColWidth
                    .AutoSizeCols(CMlngvsfAreaEqColNo, .Cols.Count - 1, 6)

                End If

                '@直接表示
                .Redraw = True

                '@ﾛｯｸ
                .Enabled = False

            End With


            '@各種ﾗﾍﾞﾙの初期化
            lblNowDate.Text = vbNullString          '情報取得日時
            lblLotCnt.Text = vbNullString           '該当件数

            '@各種ﾎﾞﾀﾝを無効にする
            cmdLeft.Enabled = False                 '左(<<)ｽｸﾛｰﾙ
            cmdRight.Enabled = False                '右(>>)ｽｸﾛｰﾙ
            cmdUP.Enabled = False                   '上(▲)ｽｸﾛｰﾙ
            cmdDown.Enabled = False                 '下(▼)ｽｸﾛｰﾙ


            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvVsfAreaEquipment_Init"   '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvWpStatus_Disp
    '機　能：装置情報表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvWpStatus_Disp()

        Try

            '@各種ﾗﾍﾞﾙの設定
            lblEqUseName.Text = mtypEqstate.strUseName               '装置状態
            lblMesMode.Text = mtypEqstate.strMesModeId               '運用ﾓｰﾄﾞ
            lblWpStatusName.Text = mtypEqstate.strWpStatusName       '処理状態
            lblALDProcessName.Text = mtypEqstate.strALDProcessName   '処理名
            
            If mtypEqstate.strMcType = CPstrMCTypeBatch Then
                lblProcessUnit.Text = CPstrProcessUnitName_Batch     '処理単位(ﾊﾞｯﾁ)
            Else
                lblProcessUnit.Text = CPstrProcessUnitName_Lot       '処理単位(ﾛｯﾄ)
            End If
            
            '@=======================
            '@ 装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ選択時処理
            '@=======================
            Call vsfAreaEquipment_EnterCell(vsfAreaEquipment, New EventArgs())

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvWpStatus_Disp"       '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbMcGroupName_Disp
    '機　能：[装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ設定処理
    '引　数：ltypMcGroupList：装置ｸﾞﾙｰﾌﾟ情報格納ﾃﾞｰﾀ
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvcmbMcGroupName_Disp(ByRef ltypMcGroupList As McGroupList)

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try

            '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞの設定
            With cmbMcGroupName

                .Clear()                                                      'ｸﾘｱ
                .DispCols = CMlngCmbDispCols                                  'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColName                                 'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColID                                 '値取得列
                .DirectInput = False                                          'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.FontFamily, CSng(CMlngCmbFontSize), _
                                 .Font.Style, .Font.Unit)                     'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CSng(CMlngCmbGridFontSize), _
                                     .GridFont.Style, .GridFont.Unit)         'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                '行の高さ
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter '左寄中央揃え
                .GroupRows = ltypMcGroupList.lngMcGroupListCnt                'GroupRow=取得件数

                For llngCnt = 0 To ltypMcGroupList.lngMcGroupListCnt - 1

                    '@装置ｸﾞﾙｰﾌﾟ名/装置ｸﾞﾙｰﾌﾟID
                    .AddItem(ltypMcGroupList.typMcGroupList(llngCnt).strMcGroupName & _
                             vbTab & _
                             ltypMcGroupList.typMcGroupList(llngCnt).strMcGroupID)

                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvCmbMcGroupName_Disp"     '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbWpID_Disp
    '機　能：[装置名]ｺﾝﾎﾞ設定処理
    '引　数：ltypAreaEquipmentList  ：装置ID情報格納ﾃﾞｰﾀ
    '　　　：llngAreaEqCnt          ：ﾃﾞｰﾀ数
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvcmbWpID_Disp(ByRef ltypAreaEquipmentList As List(Of AreaEquipmentList), _
                                ByVal llngAreaEqCnt As Integer)

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try

            '@装置名ｺﾝﾎﾞの設定
            With cmbWpID

                .Clear()                                                      'ｸﾘｱ
                .DispCols = CMlngCmbDispCols                                  'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColName                                 'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColID                                 '値取得列
                .DirectInput = False                                          'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.FontFamily, CSng(CMlngCmbFontSize), _
                                 .Font.Style, .Font.Unit)                     'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CSng(CMlngCmbGridFontSize), _
                                     .GridFont.Style, .GridFont.Unit)         'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                '行の高さ
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter '左寄中央揃え
                .Enabled = True                                               '有効
                .GroupRows = llngAreaEqCnt                                    'GroupRow=取得件数

                For llngCnt = 0 To llngAreaEqCnt -1

                    '@装置名/装置ID/EQﾀｲﾌﾟ/現在のｶｳﾝﾄ数
                    .AddItem(ltypAreaEquipmentList(llngCnt).strWpName & vbTab _
                           & ltypAreaEquipmentList(llngCnt).strWpID & vbTab _
                           & ltypAreaEquipmentList(llngCnt).strEqType & vbTab & llngCnt)

                Next llngCnt

                '@ﾘｽﾄのﾃﾞｰﾀが1件か
                If .ListCount = 1 Then

                    '@1件の場合は直接表示する
                    .ListIndex = 0

                    '@表示装置IDを退避変数に格納
                    mstrWpID = cmbWpID.Value
                    mstrWpIDWk = cmbWpID.Value
                End If

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvCmbWpID_Disp"        '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfAreaEquipment_Disp
    '機　能：[装置仕掛ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ表示処理
    '引　数：ltypLotListALDAns         ：格納ﾃﾞｰﾀ
    '　　　：llngLotListCnt         ：ﾃﾞｰﾀ件数
    '戻り値：なし
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Sub prvVsfAreaEquipment_Disp(ByRef ltypLotListALDAns As LotListALDAns, _
                                         ByVal llngLotListCnt As Integer)

        Dim llngDoCnt           As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt             As Integer      '汎用ｶｳﾝﾀ
        Dim lstrLimitTime       As String       '制限時間ﾌｫｰﾏｯﾄ用変数
        Dim lstrLimitTimeAns    As String       '時間制限変換用変数(#,##0時間 #0分)
        Dim llngWfIDDispCnt     As Integer      'WFID表示行ｶｳﾝﾀ
        Dim lstrWfIDDispChr     As String       '表示WFID文字列格納用変数("#01,#02,#03,#04,#05")
        Dim blnLimitTimeFlag    As Boolean      '表示するﾃﾞｰﾀに時間制限あり
        Dim blnHoldLotFlag      As Boolean      '表示するﾃﾞｰﾀに保留/停止あり
        Dim strEqType           As String

        Try


            '@ﾃﾞｰﾀが0件か
            If llngLotListCnt = 0 Then

                '@=======================
                '@ 装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞｸﾘｱ処理
                '@=======================
                Call prvVsfAreaEquipment_Clr()
                vsfAreaEquipment.Cols(CMlngvsfAreaEqColKb).Width = CMlngvsfAreaEqColWNowSt
                Exit Sub
            End If

            blnLimitTimeFlag = False        '時間制限ありﾌﾗｸﾞ初期設定
            blnHoldLotFlag   = False        '保留/停止ありフラグ初期値設定
            
            '@WPIDがある場合
            If mstrWpID <> vbNullString Then

                '@EQ_TYPE取得
                cmbWpID.ValueCol = CMlngCmbValueColEqType
                strEqType = cmbWpID.Value
                
                '@装置名ｺﾝﾎﾞの値取得列をID列に設定
                cmbWpID.ValueCol = CMlngCmbValueColWpId
            End If

            '@ﾛｯﾄ一覧の設定
            With vsfAreaEquipment

                'NSYS 不要イベント発生抑止
                RemoveHandler vsfAreaEquipment.BeforeRowColChange, AddressOf vsfAreaEquipment_BeforeRowColChange
                RemoveHandler vsfAreaEquipment.EnterCell, AddressOf vsfAreaEquipment_EnterCell

                .Redraw = False                   '描画ﾛｯｸ
                .Rows.Count = .Rows.Fixed         '行数初期設定
                .Rows.Count = llngLotListCnt + 1  '行数設定

                '@各種ｶｳﾝﾀの初期化
                llngDoCnt = 0               'ﾙｰﾌﾟｶｳﾝﾀ
                llngWfIDDispCnt = 0         'WFID表示数ｶｳﾝﾀ

                '@装置(ﾃｰﾌﾟ、ｵｰﾌﾞﾝ、ALD)
                'If strEqType = CPstrEqTypeALDTape Or _
                '    strEqType = CPstrEqTypeALDOven Or _
                '    strEqType = CPstrEqTypeALDSeimaku Then
                '
                '    '@非表示
                '    .ColHidden(CMlngvsfAreaEqColACarrierID) = False
                'Else
                '    '@非表示
                '    .ColHidden(CMlngvsfAreaEqColACarrierID) = True
                'End If

                'NSYS 前景色/背景色の設定
                Dim newStyle_Default As CellStyle = .Styles.Add("CustomStyle_Default")
                newStyle_Default.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                newStyle_Default.ForeColor = ColorTranslator.FromWin32(CPlngNormalForeColor)
                newStyle_Default.Trimming = StringTrimming.None
                newStyle_Default.WordWrap = True
                Dim newStyle_GridGray As CellStyle = .Styles.Add("CustomStyle_GridGray")
                newStyle_GridGray.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                newStyle_GridGray.ForeColor = ColorTranslator.FromWin32(CPlngNormalForeColor)
                newStyle_GridGray.Trimming = StringTrimming.None
                newStyle_GridGray.WordWrap = True
                Dim newStyle_Orange As CellStyle = .Styles.Add("CustomStyle_CPlngVbColorOrange")
                newStyle_Orange.BackColor = ColorTranslator.FromWin32(CPlngVbColorOrange)
                newStyle_Orange.ForeColor = ColorTranslator.FromWin32(CPlngNormalForeColor)
                newStyle_Orange.Trimming = StringTrimming.None
                newStyle_Orange.WordWrap = True
                'ALDﾊﾞｯﾁID列
                Dim newStyle_SpecialEdit As CellStyle = .Styles.Add("CustomStyle_CPlngSpecialEditColor")
                newStyle_SpecialEdit.BackColor = ColorTranslator.FromWin32(CPlngSpecialEditColor)
                newStyle_SpecialEdit.ForeColor = ColorTranslator.FromWin32(CPlngNormalForeColor)
                newStyle_SpecialEdit.Trimming = StringTrimming.None
                newStyle_SpecialEdit.WordWrap = True
                '保留/停止
                Dim newStyle_HoldLot As CellStyle = .Styles.Add("CustomStyle_CPlngHoldLotColor")
                newStyle_HoldLot.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                newStyle_HoldLot.ForeColor = ColorTranslator.FromWin32(CPlngNormalForeColor)
                newStyle_HoldLot.Trimming = StringTrimming.None
                newStyle_HoldLot.WordWrap = True
                'LifeTime(警告時間)
                Dim newStyle_PurpleDefault As CellStyle = .Styles.Add("CustomStyle_CPlngVbColorPurpleDefault")
                newStyle_PurpleDefault.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                newStyle_PurpleDefault.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple)
                newStyle_PurpleDefault.Trimming = StringTrimming.None
                newStyle_PurpleDefault.WordWrap = True
                Dim newStyle_PurpleGridGray As CellStyle = .Styles.Add("CustomStyle_CPlngVbColorPurpleGridGray")
                newStyle_PurpleGridGray.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                newStyle_PurpleGridGray.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple)
                newStyle_PurpleGridGray.Trimming = StringTrimming.None
                newStyle_PurpleGridGray.WordWrap = True
                Dim newStyle_PurpleOrange As CellStyle = .Styles.Add("CustomStyle_CPlngVbColorPurpleOrange")
                newStyle_PurpleOrange.BackColor = ColorTranslator.FromWin32(CPlngVbColorOrange)
                newStyle_PurpleOrange.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple)
                newStyle_PurpleOrange.Trimming = StringTrimming.None
                newStyle_PurpleOrange.WordWrap = True
                'LifeTime(制限時間)
                Dim newStyle_RedDefault As CellStyle = .Styles.Add("CustomStyle_CPlngVbColorRedDefault")
                newStyle_RedDefault.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                newStyle_RedDefault.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed)
                newStyle_RedDefault.Trimming = StringTrimming.None
                newStyle_RedDefault.WordWrap = True
                Dim newStyle_RedGridGray As CellStyle = .Styles.Add("CustomStyle_CPlngVbColorRedGridGray")
                newStyle_RedGridGray.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                newStyle_RedGridGray.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed)
                newStyle_RedGridGray.Trimming = StringTrimming.None
                newStyle_RedGridGray.WordWrap = True
                Dim newStyle_RedOrange As CellStyle = .Styles.Add("CustomStyle_CPlngVbColorRedOrange")
                newStyle_RedOrange.BackColor = ColorTranslator.FromWin32(CPlngVbColorOrange)
                newStyle_RedOrange.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed)
                newStyle_RedOrange.Trimming = StringTrimming.None
                newStyle_RedOrange.WordWrap = True

                Dim cellRange As CellRange
                Dim limitTimeBackColor As Integer '時間制限列の背景色の保持
                
                Do While .Rows.Count - 1 > llngDoCnt

                    '@ﾛｯﾄ現在状態
                    .SetData(llngDoCnt+1, CMlngvsfAreaEqColNowSt, ltypLotListALDAns.typLotList(llngDoCnt).strNowST)

                    '@ﾛｯﾄID
                    .SetData(llngDoCnt+1, CMlngvsfAreaEqColLotID, ltypLotListALDAns.typLotList(llngDoCnt).strLotID)

                    '@機種ID
                    .SetData(llngDoCnt+1, CMlngvsfAreaEqColPdID, ltypLotListALDAns.typLotList(llngDoCnt).strPdId)

                    '@種別
                    .SetData(llngDoCnt+1, CMlngvsfAreaEqColFlowClass, ltypLotListALDAns.typLotList(llngDoCnt).strFlowClass)

                    '@優先順位
                    .SetData(llngDoCnt+1, CMlngvsfAreaEqColPriority, ltypLotListALDAns.typLotList(llngDoCnt).strLotPriority)
                    
                    '@大工程
                    .SetData(llngDoCnt+1, CMlngvsfAreaEqColOpID, ltypLotListALDAns.typLotList(llngDoCnt).strOpID)
                    
                    '@小工程
                    .SetData(llngDoCnt+1, CMlngvsfAreaEqColStepID, ltypLotListALDAns.typLotList(llngDoCnt).strStepID)

                    '@ﾚｼﾋﾟ
                    .SetData(llngDoCnt+1, CMlngvsfAreaEqColRecipe, ltypLotListALDAns.typLotList(llngDoCnt).strRecipeId)

                    '@ﾛｯﾄ担当者
                    .SetData(llngDoCnt+1, CMlngvsfAreaEqColLotManagerName, ltypLotListALDAns.typLotList(llngDoCnt).strEngEmpName)

                    '@WF枚数
                    .SetData(llngDoCnt+1, CMlngvsfAreaEqColWfNum, ltypLotListALDAns.typLotList(llngDoCnt).strWfNum)

                    '@ﾁｯﾌﾟ数
                    If IsNumeric(ltypLotListALDAns.typLotList(llngDoCnt).strChipQuantity) Then
                        .SetData(llngDoCnt+1, CMlngvsfAreaEqColChipNum, Format$(CLng(ltypLotListALDAns.typLotList(llngDoCnt).strChipQuantity), CPstrCFKnmaFormat))
                    Else
                        .SetData(llngDoCnt+1, CMlngvsfAreaEqColChipNum, ltypLotListALDAns.typLotList(llngDoCnt).strChipQuantity)
                    End If
                    
                    '@ｷｬﾘｱID
                    .SetData(llngDoCnt+1, CMlngvsfAreaEqColCarrierID, ltypLotListALDAns.typLotList(llngDoCnt).strCarrierId)

                    '@AｷｬﾘｱID
                    .SetData(llngDoCnt+1, CMlngvsfAreaEqColACarrierID, ltypLotListALDAns.typLotList(llngDoCnt).strACarrierId)
                    
                    '@ﾃｰﾌﾟﾊﾞｯﾁID
                    .SetData(llngDoCnt+1, CMlngvsfAreaEqColTapeBatchID, ltypLotListALDAns.typLotList(llngDoCnt).strTapeBatchId)
                            
                    '@ｵｰﾌﾞﾝﾊﾞｯﾁID
                    .SetData(llngDoCnt+1, CMlngvsfAreaEqColOvenBatchID, ltypLotListALDAns.typLotList(llngDoCnt).strOvenBatchId)

                    '@ALDﾊﾞｯﾁID
                    .SetData(llngDoCnt+1, CMlngvsfAreaEqColALDBatchID, ltypLotListALDAns.typLotList(llngDoCnt).strAldBatchId)

                    '@液晶方向
                    .SetData(llngDoCnt+1, CMlngvsfAreaEqColLcDirection, ltypLotListALDAns.typLotList(llngDoCnt).strLcDirection)

                    '@(ﾛｯﾄ)ｺﾒﾝﾄﾌﾗｸﾞが"あり"か
                    If ltypLotListALDAns.typLotList(llngDoCnt).strLotCommentsFlg = CPstrAriFlg Then
                        '@"あり"の場合、ｺﾒﾝﾄに"あり"を表示
                        .SetData(llngDoCnt+1, CMlngvsfAreaEqColLotComments, CPstrAriFlg)
                    Else
                        '@(ﾛｯﾄ)ｺﾒﾝﾄﾌﾗｸﾞが"NULL"の場合、ｺﾒﾝﾄに空白を表示
                        .SetData(llngDoCnt+1, CMlngvsfAreaEqColLotComments, vbNullString)
                    End If

                    '@防湿ALD処理番号
                    .SetData(llngDoCnt+1, CMlngvsfAreaEqColALDProcessNum, ltypLotListALDAns.typLotList(llngDoCnt).strALDProcessNum)

                    '@防湿ALD処理名
                    .SetData(llngDoCnt+1, CMlngvsfAreaEqColALDProcessName, ltypLotListALDAns.typLotList(llngDoCnt).strALDProcessName)
                    
                    '@ﾓﾆﾀ使用ﾌﾗｸﾞ
                    .SetData(llngDoCnt+1, CMlngvsfAreaEqColMonitorUseFlag, ltypLotListALDAns.typLotList(llngDoCnt).strMonitorUseFlag)
                    
                    '@ﾊﾞｯﾁ区分
                    .SetData(llngDoCnt+1, CMlngvsfAreaEqColBatchFlowClass, ltypLotListALDAns.typLotList(llngDoCnt).strBatchFlowClass)

                    '@-----------------------------------------------
                    '@ 背景色/ﾌｫﾝﾄ色のﾃﾞﾌｫﾙﾄ設定
                    '@　①背景色：白
                    '@　②ﾌｫﾝﾄ色：黒
                    '@-----------------------------------------------
                    '@ｾﾙ色変更
                    '@ﾌｫﾝﾄ色変更
                    cellRange = .GetCellRange(llngDoCnt+1, CMlngvsfAreaEqColTitle, llngDoCnt+1, .Cols.Count - 1)
                    cellRange.Style = newStyle_Default
                    limitTimeBackColor = CPlngEnableTrueColor

                    '@-----------------------------------------------
                    '@ 背景色の設定
                    '@-----------------------------------------------
                    
                    '@防湿ALD処理の照合
                    '@ﾛｯﾄ処理と装置処理が異なる場合
                    If ltypLotListALDAns.typLotList(llngDoCnt).strALDProcessNum <> mtypEqstate.strALDProcessNum Then
                        cellRange = .GetCellRange(llngDoCnt+1, CMlngvsfAreaEqColNo, llngDoCnt+1, .Cols.Count - 1)
                        cellRange.Style = newStyle_GridGray
                        limitTimeBackColor = CPlngGridGray
                    End If
                    
                    '@防湿ALDﾊﾞｯﾁのﾓﾆﾀｰ使用の場合
                    If ltypLotListALDAns.typLotList(llngDoCnt).strMonitorUseFlag = CPstrFlagOn Then
                        cellRange = .GetCellRange(llngDoCnt+1, CMlngvsfAreaEqColALDBatchID)
                        cellRange.Style = newStyle_SpecialEdit
                    End If
                    
                    '@★ 液晶方向により処理分岐(※組立機種(L/R色分け処理)) ★
                    'Select Case ltypLotListALDAns.typLotList(llngDoCnt).strLcDirection
                    '    '@〓 L 〓
                    '    Case CPstrPDIDL
                    '        '@ｾﾙ背景色変更(水色)
                    '        .Cell(flexcpBackColor, llngDoCnt, CMlngvsfAreaEqColTitle, llngDoCnt, .Cols - 1) = CPlngLColor
                    '    '@〓 R 〓
                    '    Case CPstrPDIDR
                    '        '@ｾﾙ背景色変更(ﾋﾟﾝｸ色)
                    '        .Cell(flexcpBackColor, llngDoCnt, CMlngvsfAreaEqColTitle, llngDoCnt, .Cols - 1) = CPlngRColor
                    'End Select


                    '@流動区分が"FD"or"SD"、かつ装置ﾀｲﾌﾟが"BATCH"か
                    If ((ltypLotListALDAns.typLotList(llngDoCnt).strFlowClass = CPstrFillerDummy Or ltypLotListALDAns.typLotList(llngDoCnt).strFlowClass = CPstrSideDummy) And _
                        ltypLotListALDAns.strMcType = CPstrMCTypeBatch) Then
                        '@ｾﾙ色変更(ｵﾚﾝｼﾞ色)
                        cellRange = .GetCellRange(llngDoCnt+1, CMlngvsfAreaEqColTitle, llngDoCnt+1, .Cols.Count - 1)
                        cellRange.Style = newStyle_Orange
                        limitTimeBackColor = CPlngVbColorOrange
                    End If

                    '@保留ﾌﾗｸﾞが"1：保留中"か
                    If ltypLotListALDAns.typLotList(llngDoCnt).strLotHoldFlag = CMstrLotHoldFlgOn Then
                        '@ｾﾙの色変更(黄色)
                        cellRange = .GetCellRange(llngDoCnt+1, CMlngvsfAreaEqColKb)
                        cellRange.Style = newStyle_HoldLot
                        blnHoldLotFlag = True
                    End If

                    '@停止ﾌﾗｸﾞが"1：停止中"か
                    If ltypLotListALDAns.typLotList(llngDoCnt).strLotStopFlag = CMstrLotStopFlgOn Then
                        '@ｾﾙ色変更(黄色)
                        cellRange = .GetCellRange(llngDoCnt+1, CMlngvsfAreaEqColKb)
                        cellRange.Style = newStyle_HoldLot
                        blnHoldLotFlag = True
                    End If


                    '@-----------------------------------------------
                    '@ ﾌｫﾝﾄ色の設定1
                    '@　①警告時間：紫色
                    '@　②制限時間：赤色
                    '@-----------------------------------------------
                    '@時間制約有無の表示
                    If ltypLotListALDAns.typLotList(llngDoCnt).strLimitTime <> vbNullString Then

                        blnLimitTimeFlag = True     '時間制限表示ﾌﾗｸﾞON

                        '@時間制約がﾌﾟﾗｽの場合
                        If CLng(ltypLotListALDAns.typLotList(llngDoCnt).strLimitTime) >= 0 Then

                            '@制限時間以下or処理時間制限以下の場合
                            If ltypLotListALDAns.typLotList(llngDoCnt).strRestrictTypeID = CPstrRestrictTypeID1 Or _
                                ltypLotListALDAns.typLotList(llngDoCnt).strRestrictTypeID = CPstrRestrictTypeID3 Then

                                '@ﾌｫｰﾏｯﾄ変換(##,##0)
                                lstrLimitTime = Format(CLng(ltypLotListALDAns.typLotList(llngDoCnt).strLimitTime), CPstrDateFormatKanma)

                                '@制限時間先大工程+制限時間先小工程+制限時間+「以内」(組立は小工程のみの表示）
                                '@制限時間を時間と分で分割表示する
                                lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)

                                
                                .SetData(llngDoCnt+1, CMlngvsfAreaEqColLimitTime, _
                                            ltypLotListALDAns.typLotList(llngDoCnt).strToStepId & CPstrMade & _
                                            lstrLimitTimeAns & CPstrinai)
                                
                                    
                                '@警告時間が設定されている場合
                                If ltypLotListALDAns.typLotList(llngDoCnt).strWarnTime <> vbNullString Then
                                    '@時間制限が警告時間を過ぎている,且つ制限時間がｵｰﾊﾞｰしていない場合
                                    If CLng(ltypLotListALDAns.typLotList(llngDoCnt).strWarnTime) < 0 And _
                                       CLng(ltypLotListALDAns.typLotList(llngDoCnt).strLimitTime) >= 0 Then
                                        '@ﾌｫﾝﾄｶﾗｰを紫に変更
                                        cellRange = .GetCellRange(llngDoCnt+1, CMlngvsfAreaEqColLimitTime, _
                                                               llngDoCnt+1, CMlngvsfAreaEqColLimitTime)
                                        Select limitTimeBackColor
                                            Case CPlngGridGray
                                                cellRange.Style = newStyle_PurpleGridGray
                                            Case CPlngVbColorOrange
                                                cellRange.Style = newStyle_PurpleOrange
                                            Case Else
                                                cellRange.Style = newStyle_PurpleDefault
                                        End Select
                                    End If
                                End If
                            End If
                        Else
                            '@制限時間がﾏｲﾅｽの場合

                            '@ﾌｫﾝﾄｶﾗｰを赤に変更
                            cellRange = .GetCellRange(llngDoCnt+1, CMlngvsfAreaEqColLimitTime, _
                                                   llngDoCnt+1, CMlngvsfAreaEqColLimitTime)
                            Select limitTimeBackColor
                                Case CPlngGridGray
                                    cellRange.Style = newStyle_RedGridGray
                                Case CPlngVbColorOrange
                                    cellRange.Style = newStyle_RedOrange
                                Case Else
                                    cellRange.Style = newStyle_RedDefault
                            End Select

                            '@制限時間以下or処理時間制限以下の場合
                            If ltypLotListALDAns.typLotList(llngDoCnt).strRestrictTypeID = CPstrRestrictTypeID1 Or _
                                ltypLotListALDAns.typLotList(llngDoCnt).strRestrictTypeID = CPstrRestrictTypeID3 Then

                                '@ﾌｫｰﾏｯﾄ変換(##,##0)
                                lstrLimitTime = Format(CLng(ltypLotListALDAns.typLotList(llngDoCnt).strLimitTime), CPstrDateFormatKanma)

                                '@制限時間先大工程+制限時間先小工程+制限時間+「以内」(組立は小工程のみの表示）
                                '@制限時間を時間と分で分割表示する
                                lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)

                                .SetData(llngDoCnt+1, CMlngvsfAreaEqColLimitTime, _
                                            ltypLotListALDAns.typLotList(llngDoCnt).strToStepId & CPstrMade & _
                                            lstrLimitTimeAns & CPstrinai)
                                
           
                            End If

                            '@制限時間以上の場合
                            If ltypLotListALDAns.typLotList(llngDoCnt).strRestrictTypeID = CPstrRestrictTypeID2 Then

                                '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,##0)+"分"
                                lstrLimitTime = Replace(Format(CLng(ltypLotListALDAns.typLotList(llngDoCnt).strLimitTime), CPstrDateFormatKanma), CPstrReplaceMinus, vbNullString)

                                '@制限時間先大工程+制限時間先小工程+制限時間+「以上」(組立は小工程のみの表示）
                                '@制限時間を時間と分で分割表示する
                                lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)

                                .SetData(llngDoCnt+1, CMlngvsfAreaEqColLimitTime, _
                                            ltypLotListALDAns.typLotList(llngDoCnt).strToStepId & CPstrMade & _
                                            lstrLimitTimeAns & CPstrijyou)
                                
                                               
                            End If
                        End If
                    End If

                    '@-----------------------------------------------
                    '@ 保/停区分列の設定
                    '@　①部分ﾚｼﾋﾟ > 号機指定 > ﾘﾜｰｸ/追加流動 > 処理限定ﾚｼﾋﾟ > 保留 > 停止
                    '@-----------------------------------------------
                    '@停止ﾌﾗｸﾞが"1：停止中"か
                    If ltypLotListALDAns.typLotList(llngDoCnt).strLotStopFlag = CMstrLotStopFlgOn Then

                        '@=======================
                        '@ 区分列表示処理(※区分列に"停"を表示)
                        '@=======================
                        .SetData(llngDoCnt+1, CMlngvsfAreaEqColKb, _
                            pubstrColKbn_Set(.GetData(llngDoCnt+1, CMlngvsfAreaEqColKb), CMstrTei))

                    End If

                    '@保留ﾌﾗｸﾞが"1：保留中"か
                    If ltypLotListALDAns.typLotList(llngDoCnt).strLotHoldFlag = CMstrLotHoldFlgOn Then

                        '@=======================
                        '@ 区分列表示処理(※区分列に"保"を表示)
                        '@=======================
                        .SetData(llngDoCnt+1, CMlngvsfAreaEqColKb, _
                            pubstrColKbn_Set(.GetData(llngDoCnt+1, CMlngvsfAreaEqColKb), CMstrHo))
                    End If

                    '@-----------------------
                    '@ WFIDの表示
                    '@-----------------------
                    '@WF枚数が1枚以上あり、かつ数値か
                    If CDec(.GetData(llngDoCnt+1, CMlngvsfAreaEqColWfNum)) > 0 And _
                        IsNumeric(.GetData(llngDoCnt+1, CMlngvsfAreaEqColWfNum)) = True Then

                        '@表示WFID文字列格納用変数の初期化
                        lstrWfIDDispChr = vbNullString

                        '@WFﾘｽﾄ分、ｶﾝﾏ区切りで文字列を編集
                        For llngCnt = 0 To ltypLotListALDAns.typLotList(llngDoCnt).lngWfListCnt - 1


                            '@***********************
                            '@ WFIDが10桁で、8桁目が"#"の場合に下3桁結合とする
                            '@***********************
                            '@WFIDが10桁か
                            If Len(ltypLotListALDAns.typLotList(llngDoCnt).typWfList(llngCnt).strWfId) = _
                                    CMlngWfIDCondLength Then

                                '@WFIDの8桁目が"#"か
                                If Mid$(ltypLotListALDAns.typLotList(llngDoCnt).typWfList(llngCnt).strWfId, CMlngWfIDCondChrPos, 1) _
                                        = CMstrWfIDCondChr Then
                                        
                                    '@表示WFIDの文字結合
                                    '@先頭のみ#を付けて移行は2桁のWFID部分のみ連結する(REQ-1115で仕様変更)
                                    If llngCnt = 0 Then
                                        lstrWfIDDispChr = lstrWfIDDispChr & _
                                                              Strings.Right$(ltypLotListALDAns.typLotList(llngDoCnt).typWfList(llngCnt).strWfId, _
                                                              CMlngWfIDDispRightLength) & CPstrComma
                                    Else
                                        lstrWfIDDispChr = lstrWfIDDispChr & _
                                                              Strings.Right$(ltypLotListALDAns.typLotList(llngDoCnt).typWfList(llngCnt).strWfId, _
                                                              CMlngWfIDDispRightLength2) & CPstrComma
                                    End If

                                End If
                            End If
                                
                        Next llngCnt

                        '@表示WFIDの最終ｶﾝﾏを除去する
                        If lstrWfIDDispChr <> vbNullString Then

                            '@最終ｶﾝﾏを除去
                            lstrWfIDDispChr = Strings.Left$(lstrWfIDDispChr, Len(lstrWfIDDispChr) - 1)

                            '@WFID表示数ｶｳﾝﾄｱｯﾌﾟ
                            llngWfIDDispCnt = llngWfIDDispCnt + 1
                        End If

                        '@WFIDの表示
                        .SetData(llngDoCnt+1, CMlngvsfAreaEqColWfId, lstrWfIDDispChr)
                    End If


                    '@行高設定
                    .Rows(llngDoCnt+1).Height = CMlngvsfAreaEqHeight

                    '@№の設定
                    .SetData(llngDoCnt+1, CMlngvsfAreaEqColNo, llngDoCnt+1)

                    '@ｶｳﾝﾄｱｯﾌﾟ
                    llngDoCnt = llngDoCnt + 1
                Loop
                
                '@ﾕｰｻﾞﾘｻｲｽﾞが行われているか(False：未変更)
                If mtypChgSort.blnChgWidth = False Then
                    
                    ' NSYS AllowMergingの設定がNone以外だとAutoSizeColの動作が異なるためNoneに設定
                    .AllowMerging = AllowMergingEnum.None 

                    '@自動で列幅調整を行う
                    '.AutoSizeMode = flexAutoSizeColWidth
                    .AutoSizeCols(CMlngvsfAreaEqColNo, .Cols.Count - 1, 6)

                    '@保留/停止区分の表示がない場合
                    If blnHoldLotFlag = False Then
                        .Cols(CMlngvsfAreaEqColKb).Width = CMlngvsfAreaEqColWNowSt
                    End If
                    
                    '@時間制限の表示はあるか
                    If blnLimitTimeFlag = False Then
                        .Cols(CMlngvsfAreaEqColLimitTime).Width = CMlngvsfAreaEqColWLimitTime      '時間制限幅指定(表示なし)
                        
                    End If
                End If

                '@ﾏｰｼﾞ設定
                .AllowMerging = AllowMergingEnum.Free
                .Cols(CMlngvsfAreaEqColACarrierID).AllowMerging = True
                .Cols(CMlngvsfAreaEqColTapeBatchID).AllowMerging = True
                .Cols(CMlngvsfAreaEqColOvenBatchID).AllowMerging = True
                .Cols(CMlngvsfAreaEqColALDBatchID).AllowMerging = True
                .Cols(CMlngvsfAreaEqColMonitorUseFlag).AllowMerging = True

                '@ｸﾞﾘｯﾄﾞを初期値へ移動
                .LeftCol = CMlngvsfAreaEqColTitle       '列
                .TopRow = CMlngvsfAreaEqRowTitle        '行



                '@=======================
                '@ 左右("<<",">>")ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
                '@=======================
                Call pubCmdLREnable_Set(vsfAreaEquipment, cmdLeft, cmdRight)

                'NSYS ちらつき対応
                ''@行数が1ﾍﾟｰｼﾞの表示行数を上回っているか
                'If .Rows.Count > CMlngvsfAreaEqPageRows + 1 Then

                '    '@上下ｽｸﾛｰﾙﾎﾞﾀﾝを有効にする
                '    cmdUP.Enabled = True                '上(▲)ｽｸﾛｰﾙ
                '    cmdDown.Enabled = True              '下(▼)ｽｸﾛｰﾙ
                'Else
                '    '@同じ、または下回っている場合

                '    '@上下ｽｸﾛｰﾙﾎﾞﾀﾝを無効にする
                '    cmdUP.Enabled = False               '上(▲)ｽｸﾛｰﾙ
                '    cmdDown.Enabled = False             '下(▼)ｽｸﾛｰﾙ
                'End If


                '@ﾕｰｻﾞｿｰﾄが行われているか(ｿｰﾄ保持ﾘｽﾄにﾃﾞｰﾀがある)
                If mtypChgSort.lngCnt > 0 Then

                    For llngCnt = 0 To mtypChgSort.lngCnt - 1

                        '@該当行をｿｰﾄする
                        .Cols(mtypChgSort.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort.typChgSortList(llngCnt).lngOrder
                        .Sort(SortFlags.UseColSort,mtypChgSort.typChgSortList(llngCnt).lngCol)

                    Next llngCnt
                End If
                
                'NSYS 不要イベント発生抑止解除
                AddHandler vsfAreaEquipment.BeforeRowColChange, AddressOf vsfAreaEquipment_BeforeRowColChange
                AddHandler vsfAreaEquipment.EnterCell, AddressOf vsfAreaEquipment_EnterCell
                .Row = CMlngvsfAreaEqRowTitle           'ｶﾚﾝﾄ行の移動

                '@ｿｰﾄｷｰ(ｷｬﾘｱID)がNULL以外
                If mtypChgSort.strKey <> vbNullString Then

                    For llngCnt = .Rows.Fixed To .Rows.Count - 1

                        '@ｿｰﾄ配列の検索ｷｰとｶﾚﾝﾄ行検索ｷｰが同じか
                        If .GetData(llngCnt, CMlngvsfAreaEqColLotID) & _
                            .GetData(llngCnt, CMlngvsfAreaEqColOpID) & _
                            .GetData(llngCnt, CMlngvsfAreaEqColStepID) = mtypChgSort.strKey Then
                            
                            
                            '@一致行を選択
                            .Row = llngCnt

                            '@=======================
                            '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                            '@=======================
                            Call pubVsfBeforeSort(vsfAreaEquipment, CMlngvsfAreaEqColLotID & vbTab & _
                                                                    CMlngvsfAreaEqColOpID & vbTab & _
                                                                    CMlngvsfAreaEqColStepID)

                            '@=======================
                            '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                            '@=======================
                            Call pubVsfAfterSort(vsfAreaEquipment, CMlngvsfAreaEqColLotID & vbTab & _
                                                                   CMlngvsfAreaEqColOpID & vbTab & _
                                                                   CMlngvsfAreaEqColStepID, _
                                                                   cmdUP, cmdDown)

                            '@処理ﾙｰﾌﾟ抜け
                            Exit For
                        End If
                    Next llngCnt
                End If

                '@-----------------------
                '@ 画面間情報引継処理
                '@-----------------------
                '@引継ぎﾛｯﾄIDがNULL以外か
                If mtypCommonInfo.strLotID <> vbNullString Then
                    '@ﾛｯﾄ検索
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@表示と引継ぎが同じか
                        If .GetData(llngCnt, CMlngvsfAreaEqColLotID) = mtypCommonInfo.strLotID Then
                            '@一致行を選択
                            .Row = llngCnt

                            Call pubVsfBeforeSort(vsfAreaEquipment, CMlngvsfAreaEqColLotID & vbTab & _
                                                                    CMlngvsfAreaEqColOpID & vbTab & _
                                                                    CMlngvsfAreaEqColStepID)

                            Call pubVsfAfterSort(vsfAreaEquipment, CMlngvsfAreaEqColLotID & vbTab & _
                                                                   CMlngvsfAreaEqColOpID & vbTab & _
                                                                   CMlngvsfAreaEqColStepID, _
                                                                   cmdUP, cmdDown)
                                
                            '@処理ﾙｰﾌﾟ抜け
                            Exit For
                        End If
                    Next llngCnt

                    '@引継ぎ情報初期化
                    With mtypCommonInfo
                        .strCarrierId = vbNullString        'ｷｬﾘｱID
                        .strDivision = vbNullString         '起動区分
                        .strLotID = vbNullString            'ﾛｯﾄID
                        .strWpID = vbNullString             '装置ID
                        .strWpName = vbNullString           '装置名
                        .strToCarrierId = vbNullString      'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                        .strAltPointer = vbNullString       '代替番号
                    End With
                End If

                '@引継ぎ装置IDがNULL以外か
                If mtypCommonInfo.strWpID <> vbNullString Then

                    '@引継ぎ装置IDを初期化
                    mtypCommonInfo.strWpID = vbNullString
                End If


                '@-----------------------
                '@ 上下(▲,▼)ｽｸﾛｰﾙﾎﾞﾀﾝ制御
                '@-----------------------
                '@最上位行が1行目か
                If .TopRow = .Rows.Fixed Then

                    '@上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝを無効にする
                    cmdUP.Enabled = False
                Else
                    '@最上位行が1行目以外の場合(上に1行でもある)

                    '@上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝを有効にする
                    cmdUP.Enabled = True
                End If

                '@最上位行+1ﾍﾟｰｼﾞの表示行数が総行数と同じ、または大きいか(下に1行もない)
                If .TopRow + CMlngvsfAreaEqPageRows >= .Rows.Count Then

                    '@下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝを無効にする
                    cmdDown.Enabled = False
                Else
                    '@最上位行+1ﾍﾟｰｼﾞの表示行数が総行数より小さい場合(下に1行以上ある)

                    '@下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝを有効にする
                    cmdDown.Enabled = True
                End If

                '@ｸﾞﾘｯﾄﾞを描画する
                .Redraw = True

                .Enabled = True  '@ｸﾞﾘｯﾄﾞ有効

                'NSYS 不要イベント発生抑止
                RemoveHandler vsfAreaEquipment.BeforeRowColChange,AddressOf vsfAreaEquipment_BeforeRowColChange
                RemoveHandler vsfAreaEquipment.EnterCell,AddressOf vsfAreaEquipment_EnterCell

                'NSYS 先頭カラム表示および選択
                .LeftCol = CMlngvsfAreaEqColTitle
                .Col = CMlngvsfAreaEqColTitle

                '@=======================
                '@ 左右("<<",">>")ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
                '@=======================
                Call pubCmdLREnable_Set(vsfAreaEquipment, cmdLeft, cmdRight)

                'NSYS 不要イベント発生抑止解除
                AddHandler vsfAreaEquipment.BeforeRowColChange,AddressOf vsfAreaEquipment_BeforeRowColChange
                AddHandler vsfAreaEquipment.EnterCell,AddressOf vsfAreaEquipment_EnterCell

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "prvVsfAreaEquipment_Disp"       '処理名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnEqAreaCurList_Sel
    '機　能：装置ｸﾞﾙｰﾌﾟ別装置情報取得Call処理
    '引　数：ltypAreaEquipmentList()：装置ｸﾞﾙｰﾌﾟ別装置情報格納
    '　　　：llngAreaEqCnt          ：装置ｸﾞﾙｰﾌﾟ別装置情報ﾃﾞｰﾀ件数
    '　　　：lstrMcGroupName        ：装置ｸﾞﾙｰﾌﾟ
    '戻り値：True：取得成功、False：取得失敗
    '作成日：2018/07/24 (Tue) 15:48:42 Y.Yoneyama
    '更新日：
    '備　考：
    Private Function prvblnEqAreaCurList_Sel(ByRef ltypAreaEquipmentList As List(Of AreaEquipmentList), _
                                             ByRef llngAreaEqCnt As Integer, _
                                             ByRef lstrMcGroupName As String) As Boolean

        Dim lblnAns     As Boolean      '結果格納

        Try

            '@戻り値の初期化
            prvblnEqAreaCurList_Sel = False

            '@=======================
            '@ 装置ｸﾞﾙｰﾌﾟ別装置情報取得
            '@=======================
            lblnAns = pubblnEqAreaCurList_Sel(CMstreq__areacurlistVer, _
                                              vbNullString, pstrSBID, _
                                              ltypAreaEquipmentList, _
                                              llngAreaEqCnt, _
                                              CPstrCD20, _
                                              lstrMcGroupName)

            '@装置ｸﾞﾙｰﾌﾟ別装置情報取得結果が"True：取得成功"か
            If lblnAns = True Then

                '@戻り値に"True：取得成功"をｾｯﾄ
                prvblnEqAreaCurList_Sel = True
            End If

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "prvblnEqAreaCurList_Sel"        '処理名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfAreaEquipment.BeforeDoubleClick

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

End Class
