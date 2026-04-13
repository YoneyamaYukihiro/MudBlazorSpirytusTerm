'ﾌｧｲﾙ名：xxEN00J0.frm
'説　明：装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧ﾒｲﾝﾌｫｰﾑ
'作成日：2004/04/13 (Tue) 16:16:44 N.Kasai
'更新日：2025/04/18 (Fri) 16:34:52 T.Oide
'備　考：★★★　ｶﾗﾑ追加があった場合(特にｶﾗﾑ挿入)はCM0060.basに影響が出るので注意！！　★★★
'Copyright(C) SEIKO EPSON CORPORATION 2003-2025, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00J0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00J0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00J0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00J0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00J0)
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
    '@機能Ver
    '@↓2025/04/18 (Fri) 16:34:52 T.Oide **************************************************
    'Private Const CMstrLocalVersion             As String = "08.03"                     '機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion             As String = "08.04"                     '機能ﾊﾞｰｼﾞｮﾝ
    '@↑2025/04/18 (Fri) 16:34:52 T.Oide **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN00J0              'ﾛｰｶﾙ機能ID

    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ

    Private Const CMstrlot_mcalllotlistVer      As String = "05.02"                     '装置ｸﾞﾙｰﾌﾟﾛｯﾄﾘｽﾄ
    Private Const CMstrmas_McGrouplistVer       As String = "01.00"                     '装置ｸﾞﾙｰﾌﾟ取得
    '@↓2012/04/23 (Mon) 12:45:12 Y.Yoneyama **************************************************
    'Private Const CMstrutilregtminfoVer         As String = "05.00"                     '端末設定情報登録
    Private Const CMstrutilregtminfoVer         As String = "06.00"                     '端末設定情報登録
    'Private Const CMstrutilreftminfoVer         As String = "03.00"                     '端末設定情報取得
    Private Const CMstrutilreftminfoVer         As String = "04.00"                     '端末設定情報取得
    '@↑2012/04/23 (Mon) 12:45:12 Y.Yoneyama **************************************************

    '@vsfMcAllLotlistの定数宣言(ｶﾗﾑ)
    '@★★★　ｶﾗﾑ追加/変更があった場合(特に列番の変更)はCM0060.basに影響が出るので注意！！　★★★
    Private Const CMlngColNo                    As Integer = 0                             '№
    Private Const CMlngColKb                    As Integer = 1                             '保/停区分
    Private Const CMlngColOpId                  As Integer = 2                             '大工程
    Private Const CMlngColStepId                As Integer = 3                             '小工程
    Private Const CMlngColNowSt                 As Integer = 4                             '状態
    Private Const CMlngColCarrierID             As Integer = 5                             'ｷｬﾘｱID
    Private Const CMlngColLotID                 As Integer = 6                             'ﾛｯﾄID
    Private Const CMlngColPdID                  As Integer = 7                             '機種
    Private Const CMlngColFlowClass             As Integer = 8                             '種別
    Private Const CMlngColPriority              As Integer = 9                             '優先順位
    Private Const CMlngColCurrentPositionName   As Integer = 10                            'ﾛｯﾄ位置
    Private Const CMlngColLimitTime             As Integer = 11                            '時間制限
    Private Const CMlngColDispatchStartTime     As Integer = 12                            '処理開始予実
    Private Const CMlngColWfNum                 As Integer = 13                            'WF枚数
    Private Const CMlngColChipNum               As Integer = 14                            'ﾁｯﾌﾟ
    Private Const CMlngColUnLoaderCarrierID     As Integer = 15                            'ｱﾝﾛｰﾀﾞｷｬﾘｱID(非表示)
    Private Const CMlngColAltNumber             As Integer = 16                            '代替番号(非表示)
    Private Const CMlngColJBatchID              As Integer = 17                            '蒸着ﾊﾞｯﾁID(非表示)
    Private Const CMlngColCfFlag                As Integer = 18                            'CFﾌﾗｸﾞ(非表示)
    Private Const CMlngColLpFlag                As Integer = 19                            'LPﾌﾗｸﾞ(非表示)
    Private Const CMlngColVaFlag                As Integer = 20                            '無機ﾌﾗｸﾞ(非表示)
    Private Const CMlngColTpalClass             As Integer = 21                            'TPAL区分(非表示)

    '@vsfMcAllLotlistの定数宣言(幅)
    Private Const CMlngColWNo                   As Integer = 37                            '№
    Private Const CMlngColWKb                   As Integer = 25                            '保/停区分
    Private Const CMlngColWOpId                 As Integer = 66                            '大工程
    Private Const CMlngColWStepId               As Integer = 66                            '小工程
    Private Const CMlngColWNowSt                As Integer = 53                            '状態
    Private Const CMlngColWCarrierID            As Integer = 100                           'ｷｬﾘｱID
    Private Const CMlngColWLotID                As Integer = 86                            'ﾛｯﾄID
    Private Const CMlngColWPdID                 As Integer = 53                            '機種
    Private Const CMlngColWFlowClass            As Integer = 25                            '種別
    Private Const CMlngColWPriority             As Integer = 25                            '優先順位
    Private Const CMlngColWCurrentPositionName  As Integer = 100                           'ﾛｯﾄ位置
    Private Const CMlngColWLimitTime            As Integer = 66                            '時間制限
    Private Const CMlngColWDispatchStartTime    As Integer = 111                           '処理開始予実
    Private Const CMlngColWWfNum                As Integer = 53                            'WF枚数
    Private Const CMlngColWChipNum              As Integer = 53                            'ﾁｯﾌﾟ
    Private Const CMlngColWUnLoaderCarrierID    As Integer = 33                            'ｱﾝﾛｰﾀﾞｷｬﾘｱID
    Private Const CMlngColWAltNumber            As Integer = 33                            '代替番号
    Private Const CMlngColWJBatchID             As Integer = 0                             '蒸着ﾊﾞｯﾁID
    Private Const CMlngColWCfFlag               As Integer = 0                             'CFﾌﾗｸﾞ
    Private Const CMlngColWLpFlag               As Integer = 0                             'LPﾌﾗｸﾞ
    Private Const CMlngColWVaFlag               As Integer = 0                             '無機ﾌﾗｸﾞ
    Private Const CMlngColWTpalClass            As Integer = 0                             'TPAL区分

    '@vsfMcAllLotlistの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrColTNo                   As String = "№"                        '№
    Private Const CMstrColTKb                   As String = CPstrSpace                  '保/停区分
    Private Const CMstrColTOpID                 As String = "大工程"                    '大工程
    Private Const CMstrColTStepID               As String = "小工程"                    '小工程
    Private Const CMstrColTNowSt                As String = "状態"                      '状態
    Private Const CMstrColTCarrierID            As String = "キャリアID"                'ｷｬﾘｱID
    Private Const CMstrColTLotID                As String = "ロットID"                  'ﾛｯﾄID
    Private Const CMstrColTPdID                 As String = "機種"                      '機種
    Private Const CMstrColTFlowClass            As String = "種"                        '種別
    Private Const CMstrColTPriority             As String = "優"                        '優先順位
    Private Const CMstrColTCurrentPositionName  As String = "ロット位置"                'ﾛｯﾄ位置
    Private Const CMstrColTLimitTime            As String = "時間制限"                  '制限
    Private Const CMstrColTDispatchStartTime    As String = "処理開始予実"              '処理開始予実
    Private Const CMstrColTWfNum                As String = "WF枚数"                    'WF枚数
    Private Const CMstrColTChipNum              As String = "チップ"                    'ﾁｯﾌﾟ

    Private Const CMlngVsfRowTitle              As Integer = 0                             'ﾀｲﾄﾙ行(行)
    Private Const CMlngColTitle                 As Integer = 0                             'ﾀｲﾄﾙ行(列)
    Private Const CMlngvsfPageRows              As Integer = 24                            '1頁表示行数
    Private Const CMlngVsfHFontSize             As Integer = 11                            'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight               As Integer = 22                            'ﾍｯﾀﾞｰの高さ
    Private Const CMlngHeight                   As Integer = 18                            '1行の高さ
    Private Const CMlngvsfFontSize              As Integer = 11                            'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVbColorWhite             As Integer = &HFFFFFF                      '白色
    Private Const CMlngVbColorBlack             As Integer = &H0&                          '黒色
    Private Const CMlngVbColorRed               As Integer = &HFF&                         '赤色

    Private Const CMlngGridFixedCols            As Integer = 0                             'ｸﾞﾘｯﾄﾞのFixedCol
    Private Const CMlngGridFixedRows            As Integer = 1                             'ｸﾞﾘｯﾄﾞのFixedRow
    Private Const CMlngGrid3DBlank              As Integer = 2                             'ｸﾞﾘｯﾄﾞの3D表示の余白
    Private Const CMlngvsfFrozenCols            As Integer = 6                             '固定列数

    '@ｸﾞﾘｯﾄﾞの高さ
    Private Const CMlngGridHeight               As Integer = (CMlngVsfHHeight _
                                                * CMlngGridFixedRows) _
                                                + (CMlngHeight _
                                                * CMlngvsfPageRows + 1)
    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize              As Integer = 16                            'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize          As Integer = 16                            'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColName           As Integer = 0                             '名称列番
    Private Const CMlngCmbGridColID             As Integer = 1                             'ID列番(非表示項目)
    Private Const CMlngCmbDispCols              As Integer = 1                             'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbRowHeight             As Integer = 42                            'ﾘｽﾄ行の高さ

    '@その他
    Private Const CMstrFormName                 As String = "frmxxEN00J0"               '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                 As String = "Form_Load"                 'ｲﾍﾞﾝﾄ名称
    Private Const CMstrPrvblnLotMcallLotListSel As String = "prvblnLotMcallLotList_Sel" 'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmdLotListClick          As String = "cmdLotList_Click"          'ｲﾍﾞﾝﾄ名称
    Private Const CMstrcmbMcGroupNameValidate   As String = "cmbMcGroupName_Validate"   'ｲﾍﾞﾝﾄ名称
    Private Const CMstrLotHoldFlgOn             As String = "1"                         '保留ﾛｯﾄﾌﾗｸﾞON
    Private Const CMstrLotStopFlgOn             As String = "1"                         '停止ﾛｯﾄﾌﾗｸﾞON
    Private Const CMstrLotReworkFlgOn           As String = "1"                         'ﾘﾜｰｸﾌﾗｸﾞON
    Private Const CMstrLotReworkFlgOn2          As String = "2"                         '追加ﾌﾗｸﾞON
    Private Const CMstrMade                     As String = " まで "                    '時間制約結合文字列
    Private Const CMstrHo                       As String = "保"                        '保留表示
    Private Const CMstrTei                      As String = "停"                        '停止表示
    Private Const CMstrRi                       As String = "リ"                        'ﾘﾜｰｸ表示
    Private Const CMstrTsui                     As String = "追"                        '追加表示
    Private Const CMstrSen                      As String = "先"                        '先行表示
    Private Const CMlngSideScrollOnFlag         As Integer = 1                          '横ｽｸﾛｰﾙ活性化
    Private Const CMlngSideScrollOffFlag        As Integer = 2                          '横ｽｸﾛｰﾙ非活性化

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mtypChgSort                         As ChgSort                              'Sort保持用
    Private mblnFormLoadFlag                    As Boolean                              'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True：表示済、False：未表示)
    Private mstrMcGroupID                       As String                               '装置ｸﾞﾙｰﾌﾟID格納
    Private mtypMcLotList                       As McLotList                            '装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧
    Private mlngSideScrollFlag                  As Integer                              '横ｽｸﾛｰﾙの使用ﾌﾗｸﾞ(1:発生/2:不要)
    Private mtypCommonInfo                      As CommonInfo                           '引継ぎ構造体を格納
    Private buttonProcessing                    As Boolean                              'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                              'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                              'NSYS WindowCloseフラグ
    Private vsfMcAllLotlistRowBeforeSort        As Integer                              'NSYS ｿｰﾄ時の選択行退避

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
        pubVsfMouseWheelManager_Set(vsfMcAllLotlist, cmdUp, cmdDown, cmdLeft, cmdRight)

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
    '作成日：2004/07/23 (Fri) 11:27:27 M.Miura
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2004/10/06 (Wed) 08:55:50 M.Miura　    閉じるﾎﾞﾀﾝの有効/無効制御追加
    '　　　：2004/10/12 (Tue) 08:54:23 M.Miura　    ｴﾗｰ時に画面を表示しないように修正(Show削除)
    '　　　：2004/10/14 (Thu) 16:02:18 N.Kasai      ｵｰﾄｻｲｽﾞ保持対応
    '　　　：2004/10/18 (Mon) 15:37:15 N.Kasai      0件ﾒｯｾｰｼﾞｺﾒﾝﾄｱｳﾄ
    '　　　：2004/10/26 (Tue) 15:44:43 S.Deguchi    DoEvents処理の前後にﾌｫｰﾑﾛｯｸ共通関数を追加
    '　　　：2005/06/30 (Thu) 12:51:34 S.Deguchi    処理見直し
    '　　　：2005/07/22 (Fri) 16:19:08 N.Kasai      L/R表示
    '　　　：2009/02/25 (Wed) 19:53:50 N.Kojima     ﾁｯﾌﾟ品判別説明ﾗﾍﾞﾙの制御処理追加。(案件№03402)
    '　　　：2009/07/29 (Wed) 12:56:04 N.Kojima     無機対応Phase2、組立でもﾀﾞﾐｰﾛｯﾄが流動することになったので"ﾀﾞﾐｰ"説明を表示する。(案件№03661)
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub Form_Load()

        Dim lblnAns             As Boolean          '結果格納
        Dim llngCnt             As Integer          '汎用ｶｳﾝﾀ
        Dim ltypMcGroupList     As McGroupList      '装置ｸﾞﾙｰﾌﾟ格納構造体
        Dim ltypUtilDisp        As UtilRefTmInfo    '端末設定情報格納

        Try
            
            '@Escﾎﾞﾀﾝを無効(ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない為の対応)
            Me.CancelButton = Nothing
            
            '@=======================
            '@ 機能ﾊﾞｰｼﾞｮﾝ判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN00J0, CMstrLocalVersion)
            
            '@機能ﾊﾞｰｼﾞｮﾝ判定処理結果が"False：Verｴﾗｰ"か
            If lblnAns = False Then
                
                '@=======================
                '@ ﾒﾆｭｰ伸縮処理
                '@=======================
                Call pubMenuExpand_Disp()
                
                '@=======================
                '@ ﾌｫｰﾑ終了処理
                '@=======================
                Call Form_QueryUnload(False, New FormClosingEventArgs(New CloseReason,  False))
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = Me.cmdClose
                
                Exit Sub
            End If
            
            '@起動SBが"2A0：組立"か
            If pstrSBID = CPstrSBID2A0 Then
                '@2A0：組立の場合
            
                lblTitleL.BackColor = ColorTranslator.FromWin32(CPlngLColor)    '機種L
                lblTitleR.BackColor = ColorTranslator.FromWin32(CPlngRColor)    '機種R
                lblTitleL.Visible = True
                lblTitleR.Visible = True
                lblTitleChip.Visible = True                                     'ﾁｯﾌﾟ品説明
            Else
                '@1A0：基板の場合

                lblTitleL.Visible = False
                lblTitleR.Visible = False
                lblTitleChip.Visible = False                                    'ﾁｯﾌﾟ品説明
            End If

            lblTitleD.BackColor = ColorTranslator.FromWin32(CPlngVbColorOrange) 'ﾀﾞﾐｰ
            lblTitleD.Visible = True
            lblTitleHT.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor) '保留/停止
            
            '@ｿｰﾄ保持構造体初期化
            With mtypChgSort
                
                .lngCnt = 0                                 'ｶｳﾝﾀ
                .typChgSortList = New List(Of ChgSortList)  '構造体
                .blnChgWidth = False                        '列幅変更ﾌﾗｸﾞ(未変更)
                .strKey = vbNullString                      'ｶﾚﾝﾄ行検索ｷｰ
            End With
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False
            
            '@=======================
            '@ 画面初期化処理
            '@=======================
            Call prvFrmxxEN00J0_Init()


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
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = Me.cmdClose
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)

            '@=======================
            '@ 装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ設定
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
                                              ltypUtilDisp)

            '@端末設定情報取得結果が"False：取得失敗"か
            If lblnAns = False Then
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = Me.cmdClose
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)


            With ltypUtilDisp
                
                '@端末設定情報取得で取得した装置ｸﾞﾙｰﾌﾟIDがNULL以外か
                If .strMcGroupID <> vbNullString Then

                    '@装置ｸﾞﾙｰﾌﾟﾘｽﾄから端末設定情報と一致する装置ｸﾞﾙｰﾌﾟを検索
                    For llngCnt = 0 To ltypMcGroupList.lngMcGroupListCnt - 1
                        
                        '@装置ｸﾞﾙｰﾌﾟが同じか
                        If ltypMcGroupList.typMcGroupList(llngCnt).strMcGroupID = .strMcGroupID Then
                            
                            '@一致した装置ｸﾞﾙｰﾌﾟを選択する
                            cmbMcGroupName.ListIndex = llngCnt
                            Exit For
                        End If
                    Next llngCnt
                    
                    '@端末設定情報の装置ｸﾞﾙｰﾌﾟを退避
                    mstrMcGroupID = .strMcGroupID
                End If
            End With
            
            '@引継ぎ構造体を退避(※ﾌｫｰﾑﾛｰﾄﾞ後のSTART_PROCで値がｸﾘｱされる為、退避しておく必要あり)
            mtypCommonInfo = ptypCommonInfo
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"True：起動処理成功"をｾｯﾄ
            pblnFormLoad = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
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

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑ　ｱｸﾃｨﾌﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/06/30 (Thu) 13:05:50 S.Deguchi
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2005/09/08 (Thu) 16:45:03 S.Deguchi    不具合№3106の対応で一覧が存在しない場合のﾌｫｰｶｽ処理を修正
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Dim lblnAns         As Boolean          '戻り値格納用

        Try
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False：未表示"か
            If mblnFormLoadFlag = False Then
                
                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"True：表示済"をｾｯﾄ
                mblnFormLoadFlag = True
                
                '@端末情報の装置ｸﾞﾙｰﾌﾟがNULL以外か
                If mstrMcGroupID <> vbNullString Then

                    'NSYS 表示中白抜け対策
                    Me.Refresh()

                    '@=======================
                    '@ 装置ｸﾞﾙｰﾌﾟﾛｯﾄﾘｽﾄ取得処理
                    '@=======================
                    lblnAns = prvblnLotMcallLotList_Sel(mstrMcGroupID, mtypMcLotList)
                    
                    '@装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧取得処理結果が"True：取得成功"か
                    If lblnAns = True Then

                        '@=======================
                        '@ 装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ表示処理
                        '@=======================
                        Call prvVsfMcAllLotlist_Disp(mtypMcLotList)
                    
                        '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞが未選択か
                        If cmbMcGroupName.Value = vbNullString Then
                            
                            '@最新取得ﾎﾞﾀﾝを無効にする
                            cmdLotList.Enabled = False
                            
                            '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmbMcGroupName)

                        Else
                            '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞが選択されている場合

                            '@最新取得ﾎﾞﾀﾝを有効にする
                            cmdLotList.Enabled = True
                            
                            '@装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧のﾃﾞｰﾀが1件以上あるか
                            If mtypMcLotList.lngMcLotListCnt > 0 Then

                                '@装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧ｸﾞﾘｯﾄﾞへﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(vsfMcAllLotlist)
                            Else
                                '@装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧のﾃﾞｰﾀが0件の場合
                                
                                '@最新取得ﾎﾞﾀﾝが有効か
                                If cmdLotList.Enabled = True Then

                                    '@最新取得ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                                    Call pubSetFocus(cmdLotList)
                                Else
                                    '@最新取得ﾎﾞﾀﾝが無効の場合
                                    
                                    '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                                    Call pubSetFocus(cmbMcGroupName)
                                End If
                            End If
                        End If
                    Else
                        '@装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧取得処理結果が"False：取得失敗"か

                        '@Escﾎﾞﾀﾝを有効にする
                        Me.CancelButton = Me.cmdClose
                        Exit Sub
                    End If
                End If
            End If

            '@Escﾎﾞﾀﾝを有効にする
            Me.CancelButton = Me.cmdClose

            Exit Sub

        Catch ex As Exception

            '@Escﾎﾞﾀﾝを有効にする
            Me.CancelButton = Me.cmdClose

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_Activate"
                .strErrMessage = vbNullString
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
    '作成日：2004/07/15 (Thu) 10:27:50 N.Kasai
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2004/10/26 (Tue) 17:11:40 S.Deguchi    DoEvents時にはAlt+F4キーを無効にする処理を追加
    '　　　：2005/09/09 (Fri) 08:50:45 S.Deguchi    ⇔ｷｰによる制御を関数へ変更
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            '@以下の条件の場合、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                e.Handled = True
                Exit Sub
            End If

            '@=======================
            '@ ｸﾞﾘｯﾄﾞｷｰ制御処理(ｸﾞﾘｯﾄﾞ共通処理：上下ｽｸﾛｰﾙﾎﾞﾀﾝの制御)
            '@=======================
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfMcAllLotlist, cmdUP, cmdDown)
            
            '@=======================
            '@ ｸﾞﾘｯﾄﾞｷｰ制御処理(ｸﾞﾘｯﾄﾞ共通処理：左右ｽｸﾛｰﾙﾎﾞﾀﾝの制御)
            '@=======================
            Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfMcAllLotlist, cmdLeft, cmdRight)
            
            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name
            
                '@〓 装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ 〓
                Case cmbMcGroupName.Name
                    
                    '@Enterｷｰが押下されたか
                    If e.KeyCode = Keys.Return Then
                        
                        '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞがNULL以外か
                        If cmbMcGroupName.Text <> vbNullString Then
                            
                            '@=======================
                            '@ 装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞValidate処理
                            '@=======================
                            RemoveHandler cmbMcGroupName.Validating,AddressOf cmbMcGroupName_Validate
                            Call cmbMcGroupName_Validate(cmbMcGroupName,new CancelEventArgs(True))
                            AddHandler cmbMcGroupName.Validating,AddressOf cmbMcGroupName_Validate
                            Exit Sub
                        End If

                        '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄし、ｷｰｺｰﾄﾞを初期化する
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                        
                        Exit Sub
                    End If

                '@〓 その他 〓
                Case Else
                    
                    '@Enterｷｰが押下されたか
                    If e.KeyCode = Keys.Return Then

                        '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄし、ｷｰｺｰﾄﾞを初期化する
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                    End If
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：ﾌｫｰﾑ　終了時処理
    '引　数：Cancel     ：ｷｬﾝｾﾙ値
    '　　　：UnloadMode ：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/07/15 (Thu) 10:27:19 N.Kasai
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2004/10/26 (Tue) 10:58:42 S.Deguchi    DoEventsﾌﾗｸﾞによる判別を追加(終了ｺﾏﾝﾄﾞｴﾗｰ対応)
    '　　　：2004/11/01 (Mon) 16:15:42 N.Kasai      閉じるﾎﾞﾀﾝ統合
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm         As Boolean          'ACT開放結果格納

        Try
            '@ﾌｫｰﾑの"×"ﾎﾞﾀﾝにて呼ばれたか
            If mblnCloseFromControlMenu Then
            
                '@=======================
                '@ 閉じるﾎﾞﾀﾝ処理
                '@=======================
                RemoveHandler MyBase.FormClosing,AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose,e)
                AddHandler MyBase.FormClosing,AddressOf Form_QueryUnload

            End If
            
            '@各種構造体の初期化
            mtypChgSort.typChgSortList = Nothing        'ｿｰﾄ用
            mtypMcLotList.typMcLotList = Nothing        '装置ｸﾞﾙｰﾌﾟﾘｽﾄ
                
            '@装置ｸﾞﾙｰﾌﾟ格納用変数の初期化
            mstrMcGroupID = vbNullString
            
            '@ACT初期化ﾌﾗｸﾞが"Treu：初期化済"か
            If pblnActInitFlg = True Then
                '@ACTを自前で初期化した場合
                
                '@=======================
                '@ ACTｵﾌﾞｼﾞｪｸﾄ開放処理
                '@=======================
                lblnAnsTerm = pubblnAct_Term
                
                If lblnAnsTerm = True Then
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                End If
            Else
                '@ACTを自前で初期化していない場合

                '@=======================
                '@ ﾒﾆｭｰ伸縮処理
                '@=======================
                Call pubMenuExpand_Disp()

            End If
            
            '@ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄとの関連付けを解除
            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
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

    '関数名：cmbMcGroupName_Change
    '機　能：装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/15 (Thu) 10:28:50 N.Kasai
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbMcGroupName_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGroupName.Change

        Try
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False：起動処理未完了"か
            If pblnFormLoad = False Then

                '@ｿｰﾄ用ｶﾚﾝﾄ行検索ｷｰを初期化
                mtypChgSort.strKey = vbNullString
                
                '@装置ｸﾞﾙｰﾌﾟ退避変数の初期化
                mstrMcGroupID = vbNullString
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMcGroupName_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGroupName_CloseUp
    '機　能：装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/15 (Thu) 10:29:04 N.Kasai
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbMcGroupName_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGroupName.CloseUp

        Try
            '@装置ｸﾞﾙｰﾌﾟがNULL以外(選択されている)か
            If cmbMcGroupName.Text <> vbNullString Then

                '@=======================
                '@ 装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞValidate処理
                '@=======================
                RemoveHandler cmbMcGroupName.Validating,AddressOf cmbMcGroupName_Validate
                Call cmbMcGroupName_Validate(sender,new CancelEventArgs(False))
                AddHandler cmbMcGroupName.Validating,AddressOf cmbMcGroupName_Validate

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMcGroupName_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGroupName_Validate
    '機　能：装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ　選択確定時(Validate)処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/07/14 (Wed) 17:28:24 N.Kasai
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2004/09/21 (Tue) 13:17:58 S.Deguchi    装置ｸﾞﾙｰﾌﾟの退避領域判定を追加
    '　　　：2004/10/18 (Mon) 15:35:00 N.Kasai      0件ﾒｯｾｰｼﾞｺﾒﾝﾄｱｳﾄ
    '　　　：2008/07/01 (Tue) 17:34:53 M.Koni       "util.regtminfo"応答ﾒｯｾｰｼﾞ変更対応<案件No.03006>
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbMcGroupName_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbMcGroupName.Validating
        
        Dim lblnAns             As Boolean              '戻り値格納用
        Dim lstrMcGroupID       As String               '装置ｸﾞﾙｰﾌﾟ退避
        Dim ltypUtilRegTmInfo   As UtilRegTmInfo        '端末設定情報格納

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@装置ｸﾞﾙｰﾌﾟIDを変数に退避
            lstrMcGroupID = cmbMcGroupName.Value
            
            '@退避変数の装置ｸﾞﾙｰﾌﾟIDと現在選択されている装置ｸﾞﾙｰﾌﾟIDが同じか
            If mstrMcGroupID = lstrMcGroupID Then
                
                '@最新取得ﾎﾞﾀﾝが有効か
                If cmdLotList.Enabled = True Then

                    '@最新取得ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbMcGroupName.Name then
                        Call pubSetFocus(cmdLotList)
                    End If
                Else
                    '@最新取得ﾎﾞﾀﾝが無効な場合

                    '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbMcGroupName.Name then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
                
                Exit Sub
            End If

            '@構造体初期化
            mtypMcLotList.typMcLotList = New List(Of McLot)
            mtypMcLotList.lngMcLotListCnt = 0
            
            '@=======================
            '@ 装置ｸﾞﾙｰﾌﾟﾛｯﾄﾘｽﾄ取得処理
            '@=======================
            lblnAns = prvblnLotMcallLotList_Sel(lstrMcGroupID, mtypMcLotList)
            
            '@装置ｸﾞﾙｰﾌﾟﾛｯﾄﾘｽﾄ取得処理結果が"True：取得成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrcmbMcGroupNameValidate)

                '@ﾌｫｰﾑﾛｯｸ

                '@=======================
                '@ 端末設定情報登録
                '@=======================
                lblnAns = pubblnUtilRegTmInfo_Upd(pstrSBID, _
                                                  CMstrutilregtminfoVer, _
                                                  CPstrCD20, _
                                                  pstrComputerName, _
                                                  ltypUtilRegTmInfo, _
                                                  , _
                                                  , _
                                                  , _
                                                  lstrMcGroupID)

                '@ﾌｫｰﾑﾛｯｸ解除

                '@端末設定情報登録結果が"True：登録成功"か
                If lblnAns = True Then

                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrcmbMcGroupNameValidate)

                    '@=======================
                    '@ 装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ表示処理
                    '@=======================
                    Call prvVsfMcAllLotlist_Disp(mtypMcLotList)
                                
                    '@装置ｸﾞﾙｰﾌﾟIDを退避
                    mstrMcGroupID = lstrMcGroupID
                    
                    '@装置ｸﾞﾙｰﾌﾟﾛｯﾄﾘｽﾄのﾃﾞｰﾀが0件か
                    If mtypMcLotList.lngMcLotListCnt = 0 Then

                        '@ﾌｫｰｶｽを装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞに留める
                        e.Cancel = True
                    Else
                        '@装置ｸﾞﾙｰﾌﾟﾛｯﾄﾘｽﾄのﾃﾞｰﾀが1件以上ある場合
                        
                        '@装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧にﾌｫｰｶｽｾｯﾄ
                        If ActiveControl.Name = cmbMcGroupName.Name then
                            Call pubSetFocus(vsfMcAllLotlist)
                        End If
                    End If
                Else
                    '@端末設定情報登録結果が"False：登録失敗"か
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrcmbMcGroupNameValidate)
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ﾌｫｰﾑﾛｯｸ解除

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMcGroupName_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLotList_Click
    '機　能：最新取得ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/14 (Wed) 17:16:07 N.Kasai
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2004/10/08 (Fri) 09:46:04 M.Miura　    連打回避追加
    '　　　：2004/10/18 (Mon) 15:33:52 N.Kasai      0件ﾒｯｾｰｼﾞｺﾒﾝﾄｱｳﾄ
    '　　　：2005/09/08 (Thu) 16:54:54 S.Deguchi    不具合№3106の対応でﾌｫｰｶｽ処理を修正
    '　　　：2008/07/01 (Tue) 17:34:53 M.Koni       "util.regtminfo"応答ﾒｯｾｰｼﾞ変更対応<案件No.03006>
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmdLotList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotList.Click

        Dim lblnAns             As Boolean          '汎用戻り値
        Dim lstrMcGroupID       As String           '装置ｸﾞﾙｰﾌﾟID
        Dim ltypUtilRegTmInfo   As UtilRegTmInfo    '端末設定情報格納

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
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If


            '@構造体初期化
            mtypMcLotList.typMcLotList = New List(Of McLot)
            mtypMcLotList.lngMcLotListCnt = 0
            
            '@装置ｸﾞﾙｰﾌﾟIDを退避
            lstrMcGroupID = cmbMcGroupName.Value
            
            '@=======================
            '@ 装置ｸﾞﾙｰﾌﾟﾛｯﾄﾘｽﾄ取得処理
            '@=======================
            lblnAns = prvblnLotMcallLotList_Sel(lstrMcGroupID, mtypMcLotList)
            
            '@装置ｸﾞﾙｰﾌﾟﾛｯﾄﾘｽﾄ取得処理結果が"True：取得成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrCmdLotListClick)

                '@ﾌｫｰﾑﾛｯｸ

                '@=======================
                '@ 端末設定情報登録
                '@=======================
                lblnAns = pubblnUtilRegTmInfo_Upd(pstrSBID, _
                                                  CMstrutilregtminfoVer, _
                                                  CPstrCD20, _
                                                  pstrComputerName, _
                                                  ltypUtilRegTmInfo, _
                                                  , _
                                                  , _
                                                  , _
                                                  lstrMcGroupID)

                '@ﾌｫｰﾑﾛｯｸ解除

                '@端末設定情報登録結果が"True：登録成功"か
                If lblnAns = True Then

                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrCmdLotListClick)

                    '@=======================
                    '@ 装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ表示処理
                    '@=======================
                    Call prvVsfMcAllLotlist_Disp(mtypMcLotList)
                    
                    '@装置ｸﾞﾙｰﾌﾟIDを退避変数に格納
                    mstrMcGroupID = lstrMcGroupID
                    
                    '@装置ｸﾞﾙｰﾌﾟﾛｯﾄﾘｽﾄのﾃﾞｰﾀ件数が1件以上あるか
                    If mtypMcLotList.lngMcLotListCnt > 0 Then

                        '@装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧へﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfMcAllLotlist)
                    Else
                        '@装置ｸﾞﾙｰﾌﾟﾛｯﾄﾘｽﾄのﾃﾞｰﾀ件数が0件の場合

                        '@最新取得ﾎﾞﾀﾝが有効か
                        If cmdLotList.Enabled = True Then

                            '@最新取得ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdLotList)
                        Else
                            '@最新取得ﾎﾞﾀﾝが無効の場合
                            
                            '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmbMcGroupName)
                        End If
                    End If
                Else
                    '@端末設定情報登録結果が"False：登録失敗"の場合
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdLotListClick)
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ﾌｫｰﾑﾛｯｸ解除

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLotList_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMcAllLotlist_AfterSort
    '機　能：装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ　ｿｰﾄ後処理
    '引　数：Col    ：列番号
    '　　　：Order  ：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/07/15 (Thu) 10:29:36 N.Kasai
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub vsfMcAllLotlist_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfMcAllLotlist.AfterSort

        Try
            'BeforeSortで除外していたRowColChangeイベントを復帰
            AddHandler vsfMcAllLotlist.BeforeRowColChange, AddressOf vsfMcAllLotlist_BeforeRowColChange

            'NSYS ソート前の選択行が有効行でない場合、ヘッダを選択行とする
            If vsfMcAllLotlistRowBeforeSort <  vsfMcAllLotlist.Rows.Fixed Then
                vsfMcAllLotlist.Row = 0
            End If

            '@ｿｰﾄ情報を格納
            With mtypChgSort
                
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                
                '@ｿｰﾄﾘｽﾄ数分配列定義
                'ReDim Preserve .typChgSortList(.lngCnt)
                Dim typChgSortListTmp As ChgSortList
                
                '@ｿｰﾄ列番号を格納
                '@並び替え方法を格納(昇順/降順)
                typChgSortListTmp.lngCol = e.Col
                typChgSortListTmp.lngOrder = e.Order
                .typChgSortList.Add(typChgSortListTmp)

            End With
            
            '@=======================
            '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfAfterSort(vsfMcAllLotlist, CMlngColCarrierID, cmdUP, cmdDown)
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMcAllLotlist_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMcAllLotlist_AfterUserResize
    '機　能：装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ　列幅変更後処理(ﾕｰｻﾞｰﾘｻｲｽﾞ)
    '引　数：Row    ：行番号
    '　　　：Col    ：列番号
    '戻り値：なし
    '作成日：2004/07/15 (Thu) 10:29:46 N.Kasai
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2007/07/09 (Mon) 13:44:47 N.Kasai      ｸﾞﾘｯﾄﾞ共通
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub vsfMcAllLotlist_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfMcAllLotlist.AfterResizeColumn, vsfMcAllLotlist.AfterResizeRow

        Try
            '@列幅変更ﾌﾗｸﾞに"True：変更"をｾｯﾄ
            mtypChgSort.blnChgWidth = True
            
            '@=======================
            '@ 左右("<<",">>")ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
            '@=======================
            Call pubCmdLREnable_Set(vsfMcAllLotlist, cmdLeft, cmdRight)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMcAllLotlist_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub
    '

    '関数名：vsfMcAllLotlist_BeforeRowColChange
    '機　能：装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ　行列変更前処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/10/14 (Thu) 16:04:41 N.Kasai
    '更新日：2009/10/05 (Mon) 12:56:36 N.Kojima
    '備　考：
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    '　　　：2009/10/05 (Mon) 12:56:36 N.Kojima     TFT/CFﾛｯﾄ紐付情報表示機能追加に伴う修正。(案件№03791)
    Private Sub vsfMcAllLotlist_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfMcAllLotlist.BeforeRowColChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfMcAllLotlist.Rows.Count <= vsfMcAllLotlist.Rows.Fixed Then
                'NSYS ヘッダークリック時と同じ処理を実施
                cmdLotDetail.Enabled = False                'ﾛｯﾄ情報詳細表示
                cmdLotConnectedInfoDisp.Enabled = False     'TFT/CFﾛｯﾄ紐付情報表示
                Return
            End If
            
            '@旧行と新行が異なり、かつ新行がﾃﾞｰﾀ行か
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ｷｬﾘｱID)
                mtypChgSort.strKey = vsfMcAllLotlist.GetData(e.NewRange.r1, CMlngColCarrierID)
            End If


        '@↓2009/10/13 (Tue) 14:46:33 N.Kojima **************************************************

            With vsfMcAllLotlist

                '@選択行がﾍｯﾀﾞｰ行以外か
                If e.NewRange.r1 > 0 Then

                    '@ﾛｯﾄ情報詳細表示ﾎﾞﾀﾝを有効にする
                    cmdLotDetail.Enabled = True

                    '@起動SBが組立(2A0)か
                    If pstrSBID = CPstrSBID2A0 Then

                        '@蒸着ﾊﾞｯﾁIDがNULL以外か(=蒸着工程流動済み)
                        If .GetData(e.NewRange.r1, CMlngColJBatchID) <> vbNullString Then

                            '@TFT/CFﾛｯﾄ紐付情報表示ﾎﾞﾀﾝを有効にする
                            cmdLotConnectedInfoDisp.Enabled = True
                        Else
                            '@蒸着ﾊﾞｯﾁIDがNULLの場合

                            '@TFT/CFﾛｯﾄ紐付情報表示ﾎﾞﾀﾝを無効にする
                            cmdLotConnectedInfoDisp.Enabled = False
                        End If
                    End If
                Else
                    '@選択行がﾍｯﾀﾞｰ行の場合

                    '@各種ﾎﾞﾀﾝを無効にする
                    cmdLotDetail.Enabled = False                'ﾛｯﾄ情報詳細表示
                    cmdLotConnectedInfoDisp.Enabled = False     'TFT/CFﾛｯﾄ紐付情報表示
                End If

            End With

        '@↑2009/10/13 (Tue) 14:46:33 N.Kojima **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMcAllLotlist_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMcAllLotlist_BeforeSort
    '機　能：装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ　ｿｰﾄ前処理
    '引　数：Col    ：列番号
    '　　　：Order  ：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/07/15 (Thu) 10:30:47 N.Kasai
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub vsfMcAllLotlist_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfMcAllLotlist.BeforeSort

        Try
            'NSYS 不要なHandler処理を抑止
            RemoveHandler vsfMcAllLotlist.BeforeRowColChange, AddressOf vsfMcAllLotlist_BeforeRowColChange
            vsfMcAllLotlistRowBeforeSort = vsfMcAllLotlist.Row

            'NSYS データ行がない場合は処理を抜ける
            If vsfMcAllLotlist.Rows.Count <= vsfMcAllLotlist.Rows.Fixed Then
                Return
            End If
            
            '@=======================
            '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfBeforeSort(vsfMcAllLotlist, CMlngColCarrierID)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMcAllLotlist_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLeft_Click
    '機　能：左(<<)ｽｸﾛｰﾙﾎﾞﾀﾝ(装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/15 (Thu) 10:28:23 N.Kasai
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2004/11/15 (Mon) 08:49:20 H.Wajima     ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ処理追加(不具合№219)
    '　　　：2005/09/09 (Fri) 08:45:58 S.Deguchi    関数へ変更
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
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
            Call pubVsfCmdLeft(vsfMcAllLotlist, cmdLeft, cmdRight)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLeft_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRight_Click
    '機　能：右(>>)ｽｸﾛｰﾙﾎﾞﾀﾝ(装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/15 (Thu) 10:28:28 N.Kasai
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2004/11/15 (Mon) 08:48:54 H.Wajima     ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ処理追加(不具合№219)
    '　　　：2005/09/09 (Fri) 08:45:58 S.Deguchi    関数へ変更
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
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
            Call pubVsfCmdRight(vsfMcAllLotlist, cmdLeft, cmdRight)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRight_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/15 (Thu) 10:28:46 N.Kasai
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
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
            Call pubVsfCmdUp(vsfMcAllLotlist, cmdUP, cmdDown)
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUp_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/15 (Thu) 10:28:50 N.Kasai
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
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
            Call pubVsfCmdDown(vsfMcAllLotlist, cmdUP, cmdDown)
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDown_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/13 (Tue) 16:07:52 N.Kasai
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2005/06/30 (Thu) 13:08:26 S.Deguchi    処理見直し
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim llngRet         As Integer              '戻り値
        Dim ltypCommonInfo  As CommonInfo           '引継構造体

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
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If
            
            '@=======================
            '@ 終了処理
            '@=======================
            llngRet = publngEnd_Proc(CPstrKeyEN00J0, ltypCommonInfo)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
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

    '@↓2009/10/09 (Fri) 15:10:06 N.Kojima **************************************************
    '関数名：cmdLotDetail_Click
    '機　能：[ﾛｯﾄ情報詳細表示]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/10/09 (Fri) 15:10:06 N.Kojima
    '更新日：2009/10/09 (Fri) 15:10:06
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
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

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
                .strCarrierId = vsfMcAllLotlist.GetData(vsfMcAllLotlist.Row, CMlngColCarrierID)

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
    '@↑2009/10/09 (Fri) 15:10:06 N.Kojima **************************************************

    '@↓2009/10/09 (Fri) 15:09:48 N.Kojima **************************************************
    '関数名：cmdLotConnectedInfoDisp_Click
    '機　能：[TFT/CF紐付情報表示]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/10/05 (Mon) 09:45:13 N.Kojima
    '更新日：2014/12/02 (Tue) 13:53:46 H.Hayashi
    '備　考：
    '　　　：2014/12/02 (Tue) 13:31:10 H.Hayashi    組立無機ODF環境のｼｽﾃﾑ環境整備
    Private Sub cmdLotConnectedInfoDisp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotConnectedInfoDisp.Click

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
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化(True：起動成功、False：起動中(起動失敗)・初期値)
            pblnFormLoad = False

            '@ﾌｫｰﾑ起動区分に"1：TFT/CFﾛｯﾄ紐付き情報起動"をｾｯﾄ
        '@↓2014/11/26 (Wed) 17:40:20 H.Hayashi **************************************************
        '@    plngfrmxxCM00T0Kbn = CPlngNumOne
            plngfrmxxCM01B0Kbn = CPlngNumOne
        '@↑2014/11/26 (Wed) 17:40:20 H.Hayashi **************************************************

            '@***********************
            '@ 引継ぎ情報作成
            '@***********************
            With vsfMcAllLotlist

                ptypCommonInfo.strCarrierId = .GetData(.Row, CMlngColCarrierID)       'ｷｬﾘｱID
                ptypCommonInfo.strLotID = .GetData(.Row, CMlngColLotID)               'ﾛｯﾄID
                ptypCommonInfo.strFlowClass = .GetData(.Row, CMlngColFlowClass)       '流動区分
                ptypCommonInfo.strPdId = .GetData(.Row, CMlngColPdID)                 '機種
                ptypCommonInfo.strNowST = .GetData(.Row, CMlngColNowSt)               'ﾛｯﾄ状態
                ptypCommonInfo.strWfNum = .GetData(.Row, CMlngColWfNum)               'WF枚数
                ptypCommonInfo.strChipQuantity = .GetData(.Row, CMlngColChipNum)      'ﾁｯﾌﾟ数
                ptypCommonInfo.strOpID = .GetData(.Row, CMlngColOpId)                 '大工程
                ptypCommonInfo.strStepID = .GetData(.Row, CMlngColStepId)             '小工程
                ptypCommonInfo.strCfFlag = .GetData(.Row, CMlngColCfFlag)             'CFﾌﾗｸﾞ
                ptypCommonInfo.strBatchId = .GetData(.Row, CMlngColJBatchID)          '蒸着ﾊﾞｯﾁID

                pstrVaFlag = .GetData(.Row, CMlngColVaFlag)                           '無機ﾌﾗｸﾞ
                pstrTpalClass = .GetData(.Row, CMlngColTpalClass)                     'TPAL設定
            End With


            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ TFT/CFﾛｯﾄ紐付き情報画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
        '@↓2014/11/26 (Wed) 17:41:12 H.Hayashi **************************************************
        '@    Call Load(frmxxCM00T0)
            frmxxCM01B0.Instance = New frmxxCM01B0()
        '@↑2014/11/26 (Wed) 17:41:12 H.Hayashi **************************************************

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False：起動処理失敗"か
            If pblnFormLoad = False Then

                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
        '@↓2014/11/26 (Wed) 17:41:53 H.Hayashi **************************************************
        '@        Call Unload(frmxxCM00T0)
                frmxxCM01B0.Instance = Nothing
        '@↑2014/11/26 (Wed) 17:41:53 H.Hayashi **************************************************

                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
                pblnFormLoad = True

                Exit Sub
            End If

            '@閉じるﾎﾞﾀﾝを無効にする(閉じる連打で落ちるのを回避)
            cmdClose.Enabled = False

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ TFT/CFﾛｯﾄ紐付き情報画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
        '@↓2014/11/26 (Wed) 17:42:23 H.Hayashi **************************************************
        '@    Call frmxxCM00T0.Show(vbModal)
            frmxxCM01B0.Instance.ShowDialog(Me)
            frmxxCM01B0.Instance = Nothing
        '@↑2014/11/26 (Wed) 17:42:23 H.Hayashi **************************************************

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            pblnFormLoad = True

            '@閉じるﾎﾞﾀﾝを有効にする(閉じる連打で落ちるのを回避)
            cmdClose.Enabled = True


            '@***********************
            '@ 引継ぎ情報初期化(使ったﾒﾝﾊﾞのみ)
            '@***********************
            With ptypCommonInfo

                .strCarrierId = vbNullString        'ｷｬﾘｱID
                .strLotID = vbNullString            'ﾛｯﾄID
                .strFlowClass = vbNullString        '流動区分
                .strPdId = vbNullString             '機種
                .strNowST = vbNullString            'ﾛｯﾄ状態
                .strWfNum = vbNullString            'WF枚数
                .strChipQuantity = vbNullString     'ﾁｯﾌﾟ数
                .strOpID = vbNullString             '大工程
                .strStepID = vbNullString           '小工程

            End With

            '@ﾌｫｰﾑ起動区分の初期化
        '@↓2014/11/26 (Wed) 17:42:57 H.Hayashi **************************************************
        '    plngfrmxxCM00T0Kbn = CPlngNumZero
            plngfrmxxCM01B0Kbn = CPlngNumZero
        '@↑2014/11/26 (Wed) 17:42:57 H.Hayashi **************************************************

            '@各種Public変数の初期化(保険：子画面で初期化してるので基本は問題ない)
            pstrVaFlag = vbNullString               '無機ﾌﾗｸﾞ
            pstrTpalClass = vbNullString            'TPAL設定

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "cmdLotConnectedInfoDisp_Click"  '処理名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2009/10/09 (Fri) 15:09:48 N.Kojima **************************************************

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：prvFrmxxEN00J0_Init
    '機　能：画面初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/15 (Thu) 10:30:47 N.Kasai
    '更新日：2009/10/13 (Tue) 15:50:15 N.Kojima
    '備　考：
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    '　　　：2009/10/13 (Tue) 15:50:15 N.Kojima     TFT/CFﾛｯﾄ紐付情報表示機能追加に伴う修正。(案件№03791)
    Private Sub prvFrmxxEN00J0_Init()
        
        Dim lstrTitle           As String           'ﾀｲﾄﾙ

        Try
            
            '@=======================
            '@ 機能関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00J0, lstrTitle)
            
            '@ﾌｫｰﾑﾀｲﾄﾙを設定
            Me.Text = lstrTitle
            
            '@各種ﾎﾞﾀﾝの初期化
            cmdLotList.Enabled = False              '最新取得
            cmdUP.Enabled = False                   '上(▲)ｽｸﾛｰﾙ
            cmdDown.Enabled = False                 '下(▼)ｽｸﾛｰﾙ
            cmdLeft.Enabled = False                 '左(<<)ｽｸﾛｰﾙ
            cmdRight.Enabled = False                '右(>>)ｽｸﾛｰﾙ
        '@↓2009/10/13 (Tue) 15:49:49 N.Kojima **************************************************
            cmdLotDetail.Enabled = False            'ﾛｯﾄ情報詳細表示
            cmdLotConnectedInfoDisp.Enabled = False 'TFT/CF紐付情報表示

            '@基板(1A0)起動か
            If pstrSBID = CPstrSBID1A0 Then

                '@TFT/CF紐付情報表示ﾎﾞﾀﾝを非表示にする
                cmdLotConnectedInfoDisp.Visible = False
            Else
                '@基板(1A0)起動以外の場合(現在は組立(2A0)が対象)

                '@TFT/CF紐付情報表示ﾎﾞﾀﾝを表示する
                cmdLotConnectedInfoDisp.Visible = True
            End If

        '@↑2009/10/13 (Tue) 15:49:49 N.Kojima **************************************************

            '@各種ﾗﾍﾞﾙの初期化
            lblNowDate.Text = vbNullString       '情報取得日時
            lblLotCnt.Text = vbNullString        '該当件数
            
            '@=======================
            '@ 装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ初期化処理
            '@=======================
            Call prvVsfMcAllLotlist_Init()
            
            '@装置ｸﾞﾙｰﾌﾟの退避用変数の初期化
            mstrMcGroupID = vbNullString
            
            '@閉じるﾎﾞﾀﾝのCausesValidationを設定(False：ﾌｫｰｶｽLost時に入力ﾁｪｯｸをしない)
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN00J0_Init"
                .strErrMessage = vbNullString
            End With
            
            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbMcGroupName_Disp
    '機　能：装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ設定
    '引　数：ltypMcGroupList    ：装置ｸﾞﾙｰﾌﾟ構造体
    '戻り値：なし
    '作成日：2004/07/14 (Wed) 17:04:42 N.Kasai
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub prvcmbMcGroupName_Disp(ByRef ltypMcGroupList As McGroupList)
        
        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try
            
            '@初期化設定
            With cmbMcGroupName

                .Clear                                                          'ｸﾘｱ
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColName                                   'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColID                                   '値取得列
                .DirectInput = False                                            'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)        'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.Font.FontFamily, CMlngCmbGridFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  '行の高さ
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter   '左寄中央揃え
                .BackColor = SystemColors.Window                                'NSYS 背景色白色
                .GroupRows = ltypMcGroupList.lngMcGroupListCnt
            End With
            
            With ltypMcGroupList
                
                '@装置ｸﾞﾙｰﾌﾟﾘｽﾄのﾃﾞｰﾀ件数が1件以上存在するか
                If .lngMcGroupListCnt > 0 Then

                    For llngCnt = 0 To .lngMcGroupListCnt - 1
                        
                        '@装置ｸﾞﾙｰﾌﾟ名/装置ｸﾞﾙｰﾌﾟID
                        cmbMcGroupName.AddItem(ltypMcGroupList.typMcGroupList(llngCnt).strMcGroupName _
                                             & vbTab _
                                             & ltypMcGroupList.typMcGroupList(llngCnt).strMcGroupID)
                    Next llngCnt
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbMcGroupName_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfMcAllLotlist_Init
    '機　能：装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/14 (Wed) 17:03:42 N.Kasai
    '更新日：2009/10/05 (Mon) 12:56:36 N.Kojima
    '備　考：
    '　　　：2004/08/27 (Fri) 11:22:55 N.Kojima     処理終了予実ｶﾗﾑの設定をｺﾒﾝﾄ化(1060～1061行目、1086行目)。
    '　　　：2004/10/04 (Mon) 17:12:36 T.Kitagawa   ﾀｲﾄﾙの自動列幅調整(不具合№1040)
    '　　　：2004/10/14 (Thu) 16:06:29 N.Kasai      ｵｰﾄｻｲｽﾞ保持対応
    '　　　：2005/03/03 (Thu) 13:16:06 N.Kojima     引継ぎ機能追加に伴う修正(改善№512)
    '　　　：2006/10/19 (Thu) 08:53:17 M.Miura      保/停区分の結合表示(案件№01565)
    '　　　：2009/08/24 (Mon) 10:16:02 N.Kojima     機種追加。(案件№03611)
    '　　　：2009/10/05 (Mon) 12:56:36 N.Kojima     蒸着ﾊﾞｯﾁID、CF/LP/VAﾌﾗｸﾞ、TPAL区分列追加に伴う修正。(案件№03791)
    Private Sub prvVsfMcAllLotlist_Init()

        Try
            
            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfMcAllLotlist
                
                '@ｸﾘｱ
                .Clear

                'NSYS 再描画抑止
                .Redraw = False
                
                '@初期行数設定
                RemoveHandler vsfMcAllLotlist.BeforeRowColChange,AddressOf vsfMcAllLotlist_BeforeRowColChange
                .Rows.Count = .Rows.Fixed
                .Row = 0                     'NSYS 初期選択行をヘッダーに設定
                AddHandler vsfMcAllLotlist.BeforeRowColChange,AddressOf vsfMcAllLotlist_BeforeRowColChange
                
                '@一覧表の表題設定
                '@表示位置の設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_vsfMcAllLotlist_Header")
                Dim cellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngColNo, CMlngVsfRowTitle, .Cols.Count - 1)
                newStyle.ForeColor = Color.Yellow                              '文字色
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor) '背景色
                newStyle.TextAlign = TextAlignEnum.CenterCenter
                newStyle.Font = New Font(.Font.FontFamily, CMlngVsfHFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont) 'ﾌｫﾝﾄｻｲｽﾞ
                cellRange.Style = newStyle
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight
                
                '@ﾕｰｻﾞﾘｻｲｽﾞ未設定の場合
                If mtypChgSort.blnChgWidth = False Then

                    '@列幅
                    .Cols(CMlngColNo).Width = CMlngColWNo                                             'No.
                    .Cols(CMlngColKb).Width = CMlngColWKb                                             '保/停
                    .Cols(CMlngColOpId).Width = CMlngColWOpId                                         '大工程
                    .Cols(CMlngColStepId).Width = CMlngColWStepId                                     '小工程
                    .Cols(CMlngColNowSt).Width = CMlngColWNowSt                                       '状態
                    .Cols(CMlngColCarrierID).Width = CMlngColWCarrierID                               'ｷｬﾘｱID
                    .Cols(CMlngColLotID).Width = CMlngColWLotID                                       'ﾛｯﾄID
                    .Cols(CMlngColPdID).Width = CMlngColWPdID                                         '機種
                    .Cols(CMlngColFlowClass).Width = CMlngColWFlowClass                               '種別
                    .Cols(CMlngColPriority).Width = CMlngColWPriority                                 '優先度
                    .Cols(CMlngColCurrentPositionName).Width = CMlngColWCurrentPositionName           'ﾛｯﾄ位置
                    .Cols(CMlngColLimitTime).Width = CMlngColWLimitTime                               '時間制限
                    .Cols(CMlngColDispatchStartTime).Width = CMlngColWDispatchStartTime               '処理開始予実
                    .Cols(CMlngColWfNum).Width = CMlngColWWfNum                                       'WF枚数
                    .Cols(CMlngColChipNum).Width = CMlngColWChipNum                                   'ﾁｯﾌﾟ
                    .Cols(CMlngColUnLoaderCarrierID).Width = CMlngColWUnLoaderCarrierID               'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                    .Cols(CMlngColAltNumber).Width = CMlngColWAltNumber                               '代替番号
        '@↓2009/10/13 (Tue) 15:34:32 N.Kojima **************************************************
                    .Cols(CMlngColJBatchID).Width = CMlngColWJBatchID                                 '蒸着ﾊﾞｯﾁID
                    .Cols(CMlngColCfFlag).Width = CMlngColWCfFlag                                     'CFﾌﾗｸﾞ
                    .Cols(CMlngColLpFlag).Width = CMlngColWLpFlag                                     'LPﾌﾗｸﾞ
                    .Cols(CMlngColVaFlag).Width = CMlngColWVaFlag                                     '無機ﾌﾗｸﾞ
                    .Cols(CMlngColTpalClass).Width = CMlngColWTpalClass                               'TPAL区分
        '@↑2009/10/13 (Tue) 15:34:32 N.Kojima **************************************************
                End If
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngColNo, CMstrColTNo)                                       'No.
                .SetData(CMlngVsfRowTitle, CMlngColKb, CMstrColTKb)                                       '保/停
                .SetData(CMlngVsfRowTitle, CMlngColOpId, CMstrColTOpID)                                   '大工程
                .SetData(CMlngVsfRowTitle, CMlngColStepId, CMstrColTStepID)                               '小工程
                .SetData(CMlngVsfRowTitle, CMlngColNowSt, CMstrColTNowSt)                                 '状態
                .SetData(CMlngVsfRowTitle, CMlngColCarrierID, CMstrColTCarrierID)                         'ｷｬﾘｱID
                .SetData(CMlngVsfRowTitle, CMlngColLotID, CMstrColTLotID)                                 'ﾛｯﾄID
                .SetData(CMlngVsfRowTitle, CMlngColPdID, CMstrColTPdID)                                   '機種
                .SetData(CMlngVsfRowTitle, CMlngColFlowClass, CMstrColTFlowClass)                         '種別
                .SetData(CMlngVsfRowTitle, CMlngColPriority, CMstrColTPriority)                           '優先度
                .SetData(CMlngVsfRowTitle, CMlngColCurrentPositionName, CMstrColTCurrentPositionName)     'ﾛｯﾄ位置
                .SetData(CMlngVsfRowTitle, CMlngColLimitTime, CMstrColTLimitTime)                         '時間制限
                .SetData(CMlngVsfRowTitle, CMlngColDispatchStartTime, CMstrColTDispatchStartTime)         '処理開始予実
                .SetData(CMlngVsfRowTitle, CMlngColWfNum, CMstrColTWfNum)                                 'WF枚数
                .SetData(CMlngVsfRowTitle, CMlngColChipNum, CMstrColTChipNum)                             'ﾁｯﾌﾟ
                
                '@固定列の設定
                .Cols.Frozen = CMlngvsfFrozenCols
                
                '@ﾏｳｽによる列ｻｲｽﾞ変更の可/不可設定
                .AllowResizing = AllowResizingEnum.Columns
                
                '@書式設定
                .Cols(CMlngColKb).TextAlign = TextAlignEnum.LeftCenter                  '左中央(保/停)
                .Cols(CMlngColOpId).TextAlign = TextAlignEnum.LeftCenter                '左中央(大工程)
                .Cols(CMlngColStepId).TextAlign = TextAlignEnum.LeftCenter              '左中央(小工程)
                .Cols(CMlngColNowSt).TextAlign = TextAlignEnum.LeftCenter               '左中央(状態)
                .Cols(CMlngColCarrierID).TextAlign = TextAlignEnum.LeftCenter           '左中央(ｷｬﾘｱID)
                .Cols(CMlngColLotID).TextAlign = TextAlignEnum.LeftCenter               '左中央(ﾛｯﾄID)
                .Cols(CMlngColPdID).TextAlign = TextAlignEnum.LeftCenter                '左中央(機種)
                .Cols(CMlngColFlowClass).TextAlign = TextAlignEnum.LeftCenter           '左中央(種別)
                .Cols(CMlngColPriority).TextAlign = TextAlignEnum.RightCenter           '右中央(優先順位)
                .Cols(CMlngColCurrentPositionName).TextAlign = TextAlignEnum.LeftCenter '左中央(ﾛｯﾄ位置)
                .Cols(CMlngColLimitTime).TextAlign = TextAlignEnum.LeftCenter           '左中央(時間制約)
                .Cols(CMlngColDispatchStartTime).TextAlign = TextAlignEnum.LeftCenter   '左中央(処理開始予実)
                .Cols(CMlngColWfNum).TextAlign = TextAlignEnum.RightCenter              '右中央(WF枚数)
                .Cols(CMlngColChipNum).TextAlign = TextAlignEnum.RightCenter            '右中央(ﾁｯﾌﾟ)

                'NSYS DataType設定
                .Cols(CMlngColPriority).DataType = GetType(System.Int32) '優先順位
                .Cols(CMlngColWfNum).DataType = GetType(System.Int32)    'WF枚数
                .Cols(CMlngColChipNum).DataType = GetType(System.Int32)  'チップ

                'NSYS フォーマット設定
                .Cols(CMlngColChipNum).Format = CPstrCFKnmaFormat

                '11P
                .Font = New Font(.Font.FontFamily, CMlngvsfFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont) 'ﾌｫﾝﾄｻｲｽﾞ
                .Height = CMlngGridHeight                                           'ｸﾞﾘｯﾄ高さ
                
                '@ﾕｰｻﾞﾘｻｲｽﾞ未設定か
                If mtypChgSort.blnChgWidth = False Then
                    
                    '@ｵｰﾄ幅設定
                    '.AutoSizeMode = flexAutoSizeColWidth
                    .AutoSizeCols(CMlngColKb, .Cols.Count - 1, 6)
                End If
                
                '@非表示設定
                .Cols(CMlngColUnLoaderCarrierID).Visible = False   'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                .Cols(CMlngColAltNumber).Visible = False           '代替番号
        '@↓2009/10/13 (Tue) 15:37:14 N.Kojima **************************************************
                .Cols(CMlngColJBatchID).Visible = False            '蒸着ﾊﾞｯﾁID
                .Cols(CMlngColCfFlag).Visible = False              'CFﾌﾗｸﾞ
                .Cols(CMlngColLpFlag).Visible = False              'LPﾌﾗｸﾞ
                .Cols(CMlngColVaFlag).Visible = False              '無機ﾌﾗｸﾞ
                .Cols(CMlngColTpalClass).Visible = False           'TPAL区分
        '@↑2009/10/13 (Tue) 15:37:14 N.Kojima **************************************************
                

                '@基板(1A0)起動か
                If pstrSBID = CPstrSBID1A0 Then
                
                    '@基板起動の場合は"機種"列を非表示にする
                    .Cols(CMlngColPdID).Visible = False
                End If
                
                '@最終行の幅を自動調節する。
                .ExtendLastCol = True

                'NSYS 再描画実行
                .Redraw = True
                
                '@ﾛｯｸ
                .Enabled = False
            End With

            '@各種ﾗﾍﾞﾙの初期化
            lblNowDate.Text = vbNullString       '情報取得日時
            lblLotCnt.Text = vbNullString        '該当件数
            
            '@左右ｽｸﾛｰﾙﾎﾞﾀﾝの初期化
            cmdLeft.Enabled = False                 '左
            cmdRight.Enabled = False                '右
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfMcAllLotlist_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfMcAllLotlist_Disp
    '機　能：装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ表示処理
    '引　数：ltypMcLotList  ：装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧ﾃﾞｰﾀ格納構造体
    '戻り値：なし
    '作成日：2005/06/30 (Thu) 12:57:11 S.Deguchi
    '更新日：2009/12/01 (Tue) 16:18:47 H.Hayashi
    '備　考：
    '　　　：2005/09/08 (Thu) 16:47:29 S.Deguchi    取得件数0件の場合,ｸﾘｱ処理を追加
    '　　　：2006/05/12 (Fri) 12:36:01 T.Kitagawa   制限時間の表示を分合計から時間と分で分割表示する(#,##0時間 #0分)(ﾕｰｻﾞ要望№0186)
    '　　　：2006/06/08 (Thu) 14:57:47 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2006/10/19 (Thu) 08:53:17 M.Miura      保/停区分の結合表示(案件№01565)
    '　　　：2009/02/24 (Tue) 16:34:58 N.Kojima     起動SBが組立、かつ送品先が"7x0：ﾁｯﾌﾟ品"だったらﾌｫﾝﾄの色を青にする。(案件№03402)
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    '　　　：2009/10/05 (Mon) 12:56:36 N.Kojima     蒸着ﾊﾞｯﾁID、CF/LP/VAﾌﾗｸﾞ、TPAL区分列追加に伴う修正。(案件№03791)
    '　　　：2009/12/01 (Tue) 16:18:47 H.Hayashi    ﾁｯﾌﾟ品判定ﾛｼﾞｯｸ部変更。(案件No.03810)
    Private Sub prvVsfMcAllLotlist_Disp(ByRef ltypMcLotList As McLotList)

        Dim llngCnt                     As Integer              '汎用ｶｳﾝﾀ
        Dim lstrLimitTimeAns            As String               '時間制限変換用変数(#,##0時間 #0分)
        Dim keepBackColorObj            As Color                'NSYS 設定済み背景色(時間制限ﾌｫﾝﾄ設定時初期化されるため再設定用)

        Try
            
            With vsfMcAllLotlist
                
                '@ｸﾞﾘｯﾄﾞ行数の初期化
                .Rows.Count = .Rows.Fixed
                
                '@表示ﾃﾞｰﾀがあるか
                If ltypMcLotList.lngMcLotListCnt = 0 Then
                    '@表示ﾃﾞｰﾀがない場合
                    
                    '@各種ﾎﾞﾀﾝを無効にする
                    cmdUP.Enabled = False                   '上(▲)ｽｸﾛｰﾙ
                    cmdDown.Enabled = False                 '下(▼)ｽｸﾛｰﾙ
                    cmdLeft.Enabled = False                 '左(>>)ｽｸﾛｰﾙ
                    cmdRight.Enabled = False                '右(<<)ｽｸﾛｰﾙ
                    
                    '@各種ﾗﾍﾞﾙの表示
                    lblNowDate.Text = Format$(Now(), CPstrDateFormat)      '情報取得日時
                    lblLotCnt.Text = ltypMcLotList.lngMcLotListCnt       '該当件数
                    
                    '@最新取得ﾎﾞﾀﾝを有効にする
                    cmdLotList.Enabled = True
                    
                    Exit Sub
                Else
                    '@表示ﾃﾞｰﾀがある場合
                    
                    '@描画ﾛｯｸ
                    .Redraw = False
                    
                    '@行数設定
                    RemoveHandler vsfMcAllLotlist.BeforeRowColChange,AddressOf vsfMcAllLotlist_BeforeRowColChange
                    .Rows.Count = ltypMcLotList.lngMcLotListCnt + 1
                    AddHandler vsfMcAllLotlist.BeforeRowColChange,AddressOf vsfMcAllLotlist_BeforeRowColChange
                
                    '@ｶｳﾝﾀの初期化
                    llngCnt = 1
                    Dim typMcLotListIdx As Integer = 0

                    Do While .Rows.Count > llngCnt
                        
                        .SetData(llngCnt, CMlngColNo, llngCnt)                                                            '№
                        .SetData(llngCnt, CMlngColOpId, ltypMcLotList.typMcLotList(typMcLotListIdx).strOpID)              '大工程
                        .SetData(llngCnt, CMlngColStepId, ltypMcLotList.typMcLotList(typMcLotListIdx).strStepID)          '小工程
                        .SetData(llngCnt, CMlngColNowSt, ltypMcLotList.typMcLotList(typMcLotListIdx).strNowST)            'ﾛｯﾄ現在状態
                        .SetData(llngCnt, CMlngColCarrierID, ltypMcLotList.typMcLotList(typMcLotListIdx).strCarrierId)    'ｷｬﾘｱID
                        
                        '@ﾛｯﾄ状態が"後処理"か
                        If ltypMcLotList.typMcLotList(typMcLotListIdx).strNowST = CPstrAfterProgressSt Then
                            
                            '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULL以外か
                            If ltypMcLotList.typMcLotList(typMcLotListIdx).strToCarrierId <> vbNullString Then
                                
                                '@ｷｬﾘｱID列にｱﾝﾛｰﾀﾞｷｬﾘｱIDをｾｯﾄ
                                .SetData(llngCnt, CMlngColCarrierID, _
                                    ltypMcLotList.typMcLotList(typMcLotListIdx).strToCarrierId)
                            Else
                                '@ｱﾝﾛｰﾀﾞｷｬﾘｱがNULLの場合

                                '@ｷｬﾘｱID列にﾛｰﾀﾞｷｬﾘｱIDをｾｯﾄ
                                .SetData(llngCnt, CMlngColCarrierID, _
                                    ltypMcLotList.typMcLotList(typMcLotListIdx).strCarrierId)
                            End If
                        Else
                            '@ﾛｯﾄ状態が"後処理"以外の場合

                            '@ｷｬﾘｱID列にﾛｰﾀﾞｷｬﾘｱIDをｾｯﾄ
                            .SetData(llngCnt, CMlngColCarrierID, _
                                ltypMcLotList.typMcLotList(typMcLotListIdx).strCarrierId)
                        End If
                        
                        .SetData(llngCnt, CMlngColLotID, ltypMcLotList.typMcLotList(typMcLotListIdx).strLotID)                                'ﾛｯﾄID
                        .SetData(llngCnt, CMlngColPdID, ltypMcLotList.typMcLotList(typMcLotListIdx).strPdId)                                  '機種
                        .SetData(llngCnt, CMlngColFlowClass, ltypMcLotList.typMcLotList(typMcLotListIdx).strFlowClass)                        '種別
                        '優先度
                        If IsNumeric(ltypMcLotList.typMcLotList(typMcLotListIdx).strLotPriority) Then
                            .SetData(llngCnt, CMlngColPriority, CLng(ltypMcLotList.typMcLotList(typMcLotListIdx).strLotPriority))
                        Else
                            .SetData(llngCnt, CMlngColPriority, ltypMcLotList.typMcLotList(typMcLotListIdx).strLotPriority)
                        End If
                        .SetData(llngCnt, CMlngColCurrentPositionName, ltypMcLotList.typMcLotList(typMcLotListIdx).strCurrentPositionName)    'ﾛｯﾄ位置
                        
                        '@処理開始予実をﾌｫｰﾏｯﾄ変換して格納
                        'lstrTempString = Format$(ltypMcLotList.typMcLotList(typMcLotListIdx).strDispatchStartTime, CPstrDateFormatMDHM)
                        Dim dispatchStartTimeTmp As String
                        If IsDate(ltypMcLotList.typMcLotList(typMcLotListIdx).strDispatchStartTime) Then
                            dispatchStartTimeTmp = Format$(CDate(ltypMcLotList.typMcLotList(typMcLotListIdx).strDispatchStartTime), CPstrDateFormatMDHM)
                        Else
                            dispatchStartTimeTmp = ltypMcLotList.typMcLotList(typMcLotListIdx).strDispatchStartTime
                        End If
                        .SetData(llngCnt, CMlngColDispatchStartTime, dispatchStartTimeTmp)
                        
                        'WF枚数
                        If IsNumeric(ltypMcLotList.typMcLotList(typMcLotListIdx).strWfNum) Then
                            .SetData(llngCnt, CMlngColWfNum, CLng(ltypMcLotList.typMcLotList(typMcLotListIdx).strWfNum))
                        Else
                            .SetData(llngCnt, CMlngColWfNum, ltypMcLotList.typMcLotList(typMcLotListIdx).strWfNum)
                        End If
                        
                        '@ﾁｯﾌﾟ数量をﾌｫｰﾏｯﾄ変換して格納
                        'ﾁｯﾌﾟ
                        'lstrTempString = Format$(ltypMcLotList.typMcLotList(typMcLotListIdx).strChipQuantity, CPstrCFKnmaFormat)
                        If IsNumeric(ltypMcLotList.typMcLotList(typMcLotListIdx).strChipQuantity) Then
                            .SetData(llngCnt, CMlngColChipNum, CLng(ltypMcLotList.typMcLotList(typMcLotListIdx).strChipQuantity))
                        Else
                            .SetData(llngCnt, CMlngColChipNum, ltypMcLotList.typMcLotList(typMcLotListIdx).strChipQuantity)
                        End If

                        '@ｱﾝﾄﾞｰﾀﾞｷｬﾘｱIDがNULL以外か
                        If ltypMcLotList.typMcLotList(typMcLotListIdx).strToCarrierId <> vbNullString Then
                            
                            '@ｷｬﾘｱID列にｱﾝﾛｰﾀﾞｷｬﾘｱIDをｾｯﾄ
                            .SetData(llngCnt, CMlngColUnLoaderCarrierID, _
                                ltypMcLotList.typMcLotList(typMcLotListIdx).strToCarrierId)
                        End If
                        
                        '@代替番号
                        .SetData(llngCnt, CMlngColAltNumber, ltypMcLotList.typMcLotList(typMcLotListIdx).strAltNumber)

        '@↓2009/10/05 (Mon) 13:01:36 N.Kojima **************************************************

                        '@蒸着ﾊﾞｯﾁID
                        .SetData(llngCnt, CMlngColJBatchID, _
                                ltypMcLotList.typMcLotList(typMcLotListIdx).strJBatchId)
                
                        '@CFﾌﾗｸﾞ
                        .SetData(llngCnt, CMlngColCfFlag, _
                                ltypMcLotList.typMcLotList(typMcLotListIdx).strCfFlag)
                
                        '@LPﾌﾗｸﾞ
                        .SetData(llngCnt, CMlngColLpFlag, _
                                ltypMcLotList.typMcLotList(typMcLotListIdx).strLpFlag)
                
                        '@無機ﾌﾗｸﾞ
                        .SetData(llngCnt, CMlngColVaFlag, _
                                ltypMcLotList.typMcLotList(typMcLotListIdx).strVaFlag)
                
                        '@TPAL区分
                        .SetData(llngCnt, CMlngColTpalClass, _
                                ltypMcLotList.typMcLotList(typMcLotListIdx).strTpalClass)

        '@↑2009/10/05 (Mon) 13:01:36 N.Kojima **************************************************


                        '@ｾﾙ背景色変更(白)
                        '@ﾌｫﾝﾄ色変更(黒)
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngVbColorWhiteForeColor_CMlngVbColorBlack" & llngCnt.ToString)
                        Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngColTitle, llngCnt, .Cols.Count - 1)
                        newStyle.BackColor = ColorTranslator.FromWin32(CMlngVbColorWhite)
                        newStyle.ForeColor = ColorTranslator.FromWin32(CMlngVbColorBlack)
                        cellRange.Style = newStyle

                        'NSYS 設定背景色名退避
                        keepBackColorObj = ColorTranslator.FromWin32(CMlngVbColorWhite) '白
                        
                        '@-----------------------------------------------
                        '@ 背景色の優先順位
                        '@　①保留/停止 > ﾀﾞﾐｰ > L/R色
                        '@-----------------------------------------------
                        '@組立機種(L/R色分け処理)
                        '@★ 液晶方向により処理分岐 ★
                        Select Case ltypMcLotList.typMcLotList(typMcLotListIdx).strLcDirection
                            
                            '@〓 "L" 〓
                            Case CPstrPDIDL
                                
                                '@背景色を水色にする(Lの共通仕様色)
                                newStyle = .Styles.Add("CustomStyle_BackColor_CPlngLColor" & llngCnt.ToString)
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngLColor)
                                cellRange = .GetCellRange(llngCnt, CMlngColTitle, llngCnt, .Cols.Count - 1)
                                cellRange.Style = newStyle

                                'NSYS 設定背景色名退避
                                keepBackColorObj = ColorTranslator.FromWin32(CPlngLColor)
                            
                            '@〓 "R" 〓
                            Case CPstrPDIDR

                                '@背景色をﾋﾟﾝｸにする(Rの共通仕様色)
                                newStyle = .Styles.Add("CustomStyle_BackColor_CPlngRColor" & llngCnt.ToString)
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngRColor)
                                cellRange = .GetCellRange(llngCnt, CMlngColTitle, llngCnt, .Cols.Count - 1)
                                cellRange.Style = newStyle

                                'NSYS 設定背景色名退避
                                keepBackColorObj = ColorTranslator.FromWin32(CPlngRColor)

                        End Select
                        
                        '@種別が「ﾀﾞﾐｰ」か
                        If Trim(Strings.Right$(.GetData(llngCnt, CMlngColFlowClass), 1)) = CPstrFlowDummy Then

                            '@背景色をｵﾚﾝｼﾞにする(ﾀﾞﾐｰの共通仕様色)
                            newStyle = .Styles.Add("CustomStyle_BackColor_CPlngVbColorOrange" & llngCnt.ToString)
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngVbColorOrange)
                            cellRange = .GetCellRange(llngCnt, CMlngColTitle, llngCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle

                            'NSYS 設定背景色名退避
                            keepBackColorObj = ColorTranslator.FromWin32(CPlngVbColorOrange)
                        End If
                        
                        '@保留ﾌﾗｸﾞが"1：保留"か
                        If ltypMcLotList.typMcLotList(typMcLotListIdx).strLotHoldFlag = CMstrLotHoldFlgOn Then
                            
                            '@背景色を黄色にする(保留の共通仕様色)
                            newStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor" & llngCnt.ToString)
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                            cellRange = .GetCellRange(llngCnt, CMlngColTitle, llngCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle

                            'NSYS 設定背景色名退避
                            keepBackColorObj = ColorTranslator.FromWin32(CPlngHoldLotColor)
                            
                            '@=======================
                            '@ 区分列表示処理(※区分列に"保"を表示)
                            '@=======================
                            .SetData(llngCnt, CMlngColKb, _
                                pubstrColKbn_Set(.GetData(llngCnt, CMlngColKb), CMstrHo))
                        End If
                        
                        '@停止ﾌﾗｸﾞが"1：停止"か
                        If ltypMcLotList.typMcLotList(typMcLotListIdx).strLotStopFlag = CMstrLotStopFlgOn Then
                            
                            '@背景色を黄色にする(停止の共通仕様色)
                            newStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor" & llngCnt.ToString)
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                            cellRange = .GetCellRange(llngCnt, CMlngColTitle, llngCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle

                            'NSYS 設定背景色名退避
                            keepBackColorObj = ColorTranslator.FromWin32(CPlngHoldLotColor)
                            
                            '@=======================
                            '@ 区分列表示処理(※区分列に"停"を表示)
                            '@=======================
                            .SetData(llngCnt, CMlngColKb, _
                                pubstrColKbn_Set(.GetData(llngCnt, CMlngColKb), CMstrTei))
                        End If
                        
                        '@★ ﾘﾜｰｸﾌﾗｸﾞにより処理分岐 ★
                        Select Case ltypMcLotList.typMcLotList(typMcLotListIdx).strReworkFlag
                            
                            '@〓 1：ﾘﾜｰｸ 〓
                            Case CMstrLotReworkFlgOn

                                '@=======================
                                '@ 区分列表示処理(※区分列に"リ"を表示)
                                '@=======================
                                .SetData(llngCnt, CMlngColKb, _
                                    pubstrColKbn_Set(.GetData(llngCnt, CMlngColKb), CMstrRi))
                            
                            '@〓 2：追加流動 〓
                            Case CMstrLotReworkFlgOn2

                                '@=======================
                                '@ 区分列表示処理(※区分列に"追"を表示)
                                '@=======================
                                .SetData(llngCnt, CMlngColKb, _
                                    pubstrColKbn_Set(.GetData(llngCnt, CMlngColKb), CMstrTsui))
                        
                        End Select


                        '@時間制約有無の表示
                        If ltypMcLotList.typMcLotList(typMcLotListIdx).strLimitTime <> vbNullString Then
                            
                            '@時間制約がﾌﾟﾗｽの場合
                            If CLng(ltypMcLotList.typMcLotList(typMcLotListIdx).strLimitTime) >= 0 Then
                                
                                '@制限時間以下or処理時間制限以下の場合
                                If ltypMcLotList.typMcLotList(typMcLotListIdx).strRestrictTypeID = CPstrRestrictTypeID1 Or _
                                    ltypMcLotList.typMcLotList(typMcLotListIdx).strRestrictTypeID = CPstrRestrictTypeID3 Then
                                    
                                    '@ﾌｫｰﾏｯﾄ変換(##,##0)
                                    'lstrLimitTime = Format(ltypMcLotList.typMcLotList(typMcLotListIdx).strLimitTime, CPstrDateFormatKanma)
                                    Dim limitTimeTmp As String
                                    If IsNumeric(limitTimeTmp) Then
                                        limitTimeTmp = Format(CLng(ltypMcLotList.typMcLotList(typMcLotListIdx).strLimitTime), CPstrDateFormatKanma)
                                    Else
                                        limitTimeTmp = ltypMcLotList.typMcLotList(typMcLotListIdx).strLimitTime
                                    End If
                                    
                                    '@制限時間先大工程+制限時間先小工程+制限時間+「以内」
                                    '@制限時間を時間と分で分割表示する
                                    lstrLimitTimeAns = pubstrLimitTime_Set(limitTimeTmp)
                                    .SetData(llngCnt, CMlngColLimitTime, ltypMcLotList.typMcLotList(typMcLotListIdx).strToOpId _
                                                                                    & CPstrSpace _
                                                                                    & ltypMcLotList.typMcLotList(typMcLotListIdx).strToStepId _
                                                                                    & CPstrMade _
                                                                                    & lstrLimitTimeAns _
                                                                                    & CPstrinai)
                                    '@左寄せ
                                    '.Cell(flexcpAlignment, llngCnt, CMlngColLimitTime) = flexAlignLeftCenter
                                    
                                    '@警告時間が設定されている場合
                                    If ltypMcLotList.typMcLotList(typMcLotListIdx).strWarnTime <> vbNullString Then
                                        
                                        '@時間制限が警告時間を過ぎている,且つ制限時間がｵｰﾊﾞｰしていない場合
                                        If CLng(ltypMcLotList.typMcLotList(typMcLotListIdx).strWarnTime) < 0 And _
                                            CLng(ltypMcLotList.typMcLotList(typMcLotListIdx).strLimitTime) >= 0 Then
                                            
                                            '@ﾌｫﾝﾄｶﾗｰを紫に変更
                                            newStyle = .Styles.Add("CustomStyle_ForeColor_CPlngVbColorPurple" & llngCnt.ToString)
                                            newStyle.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple)
                                            newStyle.BackColor = keepBackColorObj
                                            cellRange = .GetCellRange(llngCnt, CMlngColLimitTime, llngCnt, CMlngColLimitTime)
                                            cellRange.Style = newStyle
                                        Else
                                            '@ﾌｫﾝﾄｶﾗｰを黒に変更
                                            newStyle = .Styles.Add("CustomStyle_ForeColor_vbBlack" & llngCnt.ToString)
                                            newStyle.ForeColor = SystemColors.WindowText
                                            newStyle.BackColor = keepBackColorObj
                                            cellRange = .GetCellRange(llngCnt, CMlngColLimitTime, llngCnt, CMlngColLimitTime)
                                            cellRange.Style = newStyle
                                        End If
                                    End If
                                End If
                            Else
                                '@制限時間がﾏｲﾅｽの場合
                                
                                '@左寄せ
                                '.Cell(flexcpAlignment, llngCnt, CMlngColLimitTime) = flexAlignLeftCenter
                                
                                '@ForColorの変更
                                '赤色
                                newStyle = .Styles.Add("CustomStyle_ForeColor_CPlngVbColorRed" & llngCnt.ToString)
                                newStyle.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed)
                                newStyle.BackColor = keepBackColorObj
                                cellRange = .GetCellRange(llngCnt, CMlngColLimitTime, llngCnt, CMlngColLimitTime)
                                cellRange.Style = newStyle
                                
                                '@制限時間以下or処理時間制限以下の場合
                                If ltypMcLotList.typMcLotList(typMcLotListIdx).strRestrictTypeID = CPstrRestrictTypeID1 Or _
                                    ltypMcLotList.typMcLotList(typMcLotListIdx).strRestrictTypeID = CPstrRestrictTypeID3 Then
                                    
                                    '@ﾌｫｰﾏｯﾄ変換(##,##0)
                                    'lstrLimitTime = Format(ltypMcLotList.typMcLotList(typMcLotListIdx).strLimitTime, CPstrDateFormatKanma)
                                    Dim limitTimeTmp As String
                                    If IsNumeric(ltypMcLotList.typMcLotList(typMcLotListIdx).strLimitTime) Then
                                        limitTimeTmp = Format(CLng(ltypMcLotList.typMcLotList(typMcLotListIdx).strLimitTime), CPstrDateFormatKanma)
                                    Else
                                        limitTimeTmp = ltypMcLotList.typMcLotList(typMcLotListIdx).strLimitTime
                                    End If
                                    
                                    '@制限時間先大工程+制限時間先小工程+制限時間+「以内」
                                    '@制限時間を時間と分で分割表示する
                                    lstrLimitTimeAns = pubstrLimitTime_Set(limitTimeTmp)
                                    .SetData(llngCnt, CMlngColLimitTime, ltypMcLotList.typMcLotList(typMcLotListIdx).strToOpId _
                                                                                    & CPstrSpace _
                                                                                    & ltypMcLotList.typMcLotList(typMcLotListIdx).strToStepId _
                                                                                    & CPstrMade _
                                                                                    & lstrLimitTimeAns _
                                                                                    & CPstrinai)
                                End If
                                
                                '@制限時間以上の場合
                                If ltypMcLotList.typMcLotList(typMcLotListIdx).strRestrictTypeID = CPstrRestrictTypeID2 Then
                                    
                                    '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,##0)+"分"
                                    'lstrLimitTime = Replace(Format(ltypMcLotList.typMcLotList(typMcLotListIdx).strLimitTime, CPstrDateFormatKanma), CPstrReplaceMinus, vbNullString)
                                    Dim limitTimeTmp As String
                                    If IsNumeric(ltypMcLotList.typMcLotList(typMcLotListIdx).strLimitTime) Then
                                        limitTimeTmp = Replace(Format(CLng(ltypMcLotList.typMcLotList(typMcLotListIdx).strLimitTime), CPstrDateFormatKanma), CPstrReplaceMinus, vbNullString)
                                    Else
                                        limitTimeTmp = ltypMcLotList.typMcLotList(typMcLotListIdx).strLimitTime
                                    End If
                                    
                                    '@制限時間先大工程+制限時間先小工程+制限時間+「以上」
                                    '@制限時間を時間と分で分割表示する
                                    lstrLimitTimeAns = pubstrLimitTime_Set(limitTimeTmp)
                                    .SetData(llngCnt, CMlngColLimitTime, ltypMcLotList.typMcLotList(typMcLotListIdx).strToOpId _
                                                                                    & CPstrSpace _
                                                                                    & ltypMcLotList.typMcLotList(typMcLotListIdx).strToStepId _
                                                                                    & CPstrMade _
                                                                                    & lstrLimitTimeAns _
                                                                                    & CPstrijyou)
                                End If
                            End If
                        End If
                        

                        '@-----------------------------------------------
                        '@ ﾌｫﾝﾄ色の設定(組立限定機能)
                        '@　①ﾁｯﾌﾟ品LOT：青色
                        '@-----------------------------------------------
        '@↓2009/12/01 (Tue) 16:19:51 H.Hayashi **************************************************
                        '@起動SBが組立、かつｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"か
        '                If pstrSBID = CPstrSBID2A0 And _
        '                    Left$(ltypMcLotList.typMcLotList(llngCnt).strSendSBID, 1) = CPstrProductChip Then
                            
                        If pstrSBID = CPstrSBID2A0 And _
                            ltypMcLotList.typMcLotList(typMcLotListIdx).strSbArea = CPstrProductChip Then
                            
                            '@起動SBが組立、かつｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"の場合
        '@↑2009/12/01 (Tue) 16:19:51 H.Hayashi **************************************************
                            
                            '@時間制限以外の文字色を青色に変更
                            newStyle = .Styles.Add("CustomStyle_ForeColor_vbBlue1" & llngCnt.ToString)
                            newStyle.ForeColor = Color.Blue
                            newStyle.BackColor = keepBackColorObj
                            cellRange = .GetCellRange(llngCnt, CMlngColNo,llngCnt, CMlngColCurrentPositionName)
                            cellRange.Style = newStyle

                            newStyle = .Styles.Add("CustomStyle_ForeColor_vbBlue2" & llngCnt.ToString)
                            newStyle.ForeColor = Color.Blue
                            newStyle.BackColor = keepBackColorObj
                            cellRange = .GetCellRange(llngCnt, CMlngColDispatchStartTime,llngCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        
                        End If

                        
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngCnt).Height = CMlngHeight
                        
                        '@ｶｳﾝﾄｱｯﾌﾟ
                        llngCnt = llngCnt + 1
                        typMcLotListIdx = typMcLotListIdx + 1
                    Loop
                        
                    '@列幅の自動調整不可ﾌﾗｸﾞが"False：不可"か
                    If mtypChgSort.blnChgWidth = False Then
                        '@列幅の自動調整不可ﾌﾗｸﾞが"False：不可"の場合
                        
                        '@列幅設定
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCol(CMlngColKb, 6)
                        .AutoSizeCol(CMlngColOpId, 6)
                        .AutoSizeCol(CMlngColStepId, 6)
                        .AutoSizeCol(CMlngColNowSt, 6)
                        .AutoSizeCol(CMlngColCarrierID, 6)
                        .AutoSizeCol(CMlngColLotID, 6)
                        .AutoSizeCol(CMlngColPdID, 6)
                        .AutoSizeCol(CMlngColFlowClass, 6)
                        .AutoSizeCol(CMlngColPriority, 6)
                        .AutoSizeCol(CMlngColCurrentPositionName, 6)
                        .AutoSizeCol(CMlngColLimitTime, 6)
                        .AutoSizeCol(CMlngColDispatchStartTime, 6)
                        .AutoSizeCol(CMlngColWfNum, 6)
                        .AutoSizeCol(CMlngColChipNum, 6)
                    End If
                        
                    '@行表示
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        .Rows(llngCnt).Visible = True
                    Next llngCnt
                        
                    '@ﾕｰｻﾞによりｿｰﾄされているか
                    If mtypChgSort.lngCnt > 0 Then

                        For llngCnt = 0 To mtypChgSort.lngCnt - 1
                            
                            '@該当行をｿｰﾄ
                            '.Cell(flexcpSort, .Rows.Fixed, mtypChgSort.typChgSortList(llngCnt).lngCol, .Rows.Count - 1) _
                            '    = mtypChgSort.typChgSortList(llngCnt).lngOrder
                            RemoveHandler vsfMcAllLotlist.BeforeRowColChange,AddressOf vsfMcAllLotlist_BeforeRowColChange
                            .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder,mtypChgSort.typChgSortList(llngCnt).lngCol)
                            AddHandler vsfMcAllLotlist.BeforeRowColChange,AddressOf vsfMcAllLotlist_BeforeRowColChange


                        Next llngCnt
                    End If

                    'NSYS 不要なHandler処理を抑止
                    RemoveHandler vsfMcAllLotlist.BeforeRowColChange,AddressOf vsfMcAllLotlist_BeforeRowColChange

                    '@ｸﾞﾘｯﾄﾞを初期値へ移動
                    .LeftCol = CMlngColTitle            '列
                    .TopRow = CMlngVsfRowTitle          '行
                    .Row = CMlngVsfRowTitle             'ｶﾚﾝﾄ行の移動

                    'NSYS Handler抑止解除
                    AddHandler vsfMcAllLotlist.BeforeRowColChange,AddressOf vsfMcAllLotlist_BeforeRowColChange
                        
                    '@ｿｰﾄ検索用ｷｰ(ｷｬﾘｱID)がNULL以外か
                    If mtypChgSort.strKey <> vbNullString Then
                        
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            
                            '@ｷｬﾘｱIDがｿｰﾄ構造体のｷｬﾘｱIDと同じか
                            If .GetData(llngCnt, CMlngColCarrierID) = mtypChgSort.strKey Then
                                
                                '@一致行を選択
                                .Row = llngCnt
                                
                                '@=======================
                                '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                '@=======================
                                Call pubVsfBeforeSort(vsfMcAllLotlist, CMlngColCarrierID)
                                
                                '@=======================
                                '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                '@=======================
                                Call pubVsfAfterSort(vsfMcAllLotlist, CMlngColCarrierID, cmdUP, cmdDown)
                                
                                Exit For
                            End If
                        Next llngCnt
                    Else
                        '@ｿｰﾄ検索ｷｰがない場合
                        
                        '@=======================
                        '@ 引継ﾛｯﾄ(ｷｬﾘｱ)選択処理
                        '@=======================
                        Call prvVsfConnectCarrier_Sel()

                    End If
                End If
            End With


            With vsfMcAllLotlist
                
                '@各種ﾗﾍﾞﾙの表示
                lblNowDate.Text = Format$(Now(), CPstrDateFormat)      '情報取得日時
                lblLotCnt.Text = ltypMcLotList.lngMcLotListCnt       '該当件数
                
                '@=======================
                '@ ｸﾞﾘｯﾄﾞ選択の初期化(ｸﾞﾘｯﾄﾞ共通化関数)
                '@=======================
                Call pubVsfDisp(vsfMcAllLotlist, cmdUP, cmdDown)
                
                '@ﾌｫｰﾑﾛｯｸ
                
                '@制御をOSに渡す
                '@ﾌｫｰﾑﾛｰﾄﾞ中の通信に負荷がかかった場合にﾌｫｰﾑに制御を渡す
                '@ｲﾍﾞﾝﾄを抑止する為、ﾌｫｰﾑをﾛｯｸする。
                'DoEvents
                
                '@ﾌｫｰﾑﾛｯｸ解除

                '@描画ﾛｯｸ解除
                .Redraw = True
                
                '@ﾛｯｸ解除
                .Enabled = True

                'NSYS 不要なHandler処理を抑止
                RemoveHandler vsfMcAllLotlist.BeforeRowColChange,AddressOf vsfMcAllLotlist_BeforeRowColChange

                'NSYS 先頭カラム表示および選択
                .LeftCol = CMlngColNo

                'NSYS Handler抑止解除
                AddHandler vsfMcAllLotlist.BeforeRowColChange,AddressOf vsfMcAllLotlist_BeforeRowColChange

                '@=======================
                '@ 左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
                '@=======================
                Call pubCmdLREnable_Set(vsfMcAllLotlist, cmdLeft, cmdRight)
                
                '@最新取得ﾎﾞﾀﾝを有効にする
                cmdLotList.Enabled = True
                
                '@装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧ｸﾞﾘｯﾄﾞが有効か
                If vsfMcAllLotlist.Enabled = True Then

                    '@装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfMcAllLotlist)
                Else
                    '@装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧ｸﾞﾘｯﾄﾞが無効な場合
                    
                    '@最新取得ﾎﾞﾀﾝが有効か
                    If cmdLotList.Enabled = True Then

                        '@最新取得ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdLotList)
                    Else
                        '@最新取得ﾎﾞﾀﾝが無効の場合

                        '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmbMcGroupName)
                    End If
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfMcAllLotlist_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnLotMcallLotList_Sel
    '機　能：装置ｸﾞﾙｰﾌﾟﾛｯﾄﾘｽﾄ取得処理
    '引　数：lstrMcGroupID  ：装置ｸﾞﾙｰﾌﾟID
    '　　　：ltypMcLotList  ：格納構造体
    '戻り値：True：取得成功、Flase：取得失敗
    '作成日：2005/06/30 (Thu) 13:02:25 S.Deguchi
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Function prvblnLotMcallLotList_Sel(ByVal lstrMcGroupID As String, _
                                               ByRef ltypMcLotList As McLotList) As Boolean

        Dim lblnAns     As Boolean          '結果格納

        Try
            
            '@戻り値の初期化
            prvblnLotMcallLotList_Sel = False

            '@装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧格納構造体の初期化
            mtypMcLotList.typMcLotList = New List(Of McLot)
            mtypMcLotList.lngMcLotListCnt = 0

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvblnLotMcallLotListSel)
            
            '@ﾌｫｰﾑﾛｯｸ
            
            '@制御をOSに渡す
            '@ﾌｫｰﾑﾛｰﾄﾞ中の通信に負荷がかかった場合にﾌｫｰﾑに制御を渡す
            '@ｲﾍﾞﾝﾄを抑止する為、ﾌｫｰﾑをﾛｯｸする。
            'DoEvents

            '@=======================
            '@ 装置ｸﾞﾙｰﾌﾟﾛｯﾄﾘｽﾄ取得
            '@=======================
            lblnAns = pubblnLotMcallLotList_Sel(CMstrlot_mcalllotlistVer, _
                                                pstrSBID, _
                                                lstrMcGroupID, _
                                                ltypMcLotList)
                                                
            '@ﾌｫｰﾑﾛｯｸ解除

            '@結果判定
            If lblnAns = False Then

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvblnLotMcallLotListSel)
                Exit Function
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrPrvblnLotMcallLotListSel)
            
            '@戻り値に"True：取得成功"をｾｯﾄ
            prvblnLotMcallLotList_Sel = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnLotMcallLotList_Sel"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvVsfConnectCarrier_Sel
    '機　能：引継ﾛｯﾄ(ｷｬﾘｱ)選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/01 (Fri) 12:14:17 S.Deguchi
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub prvVsfConnectCarrier_Sel()

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ
        
        Try
            
            With vsfMcAllLotlist
                
                '@引継ぎｷｬﾘｱIDがNULL以外か
                If mtypCommonInfo.strCarrierId <> vbNullString Then
                    
                    '@引継ぎｱﾝﾛｰﾀﾞｰｷｬﾘｱIDがNULL以外か
                    If mtypCommonInfo.strToCarrierId <> vbNullString Then
                        
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            
                            '@代替番号がNULL、または"0"か
                            If mtypCommonInfo.strAltPointer = vbNullString Or _
                                mtypCommonInfo.strAltPointer = CPstrZero Then
                                
                                '@装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧のｷｬﾘｱIDと、引継ぎｱﾝﾛｰﾀﾞｷｬﾘｱIDが同じか
                                If .GetData(llngCnt, CMlngColCarrierID) = mtypCommonInfo.strToCarrierId Then
                                    
                                    '@一致行を選択
                                    .Row = llngCnt
                                    
                                    '@=======================
                                    '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfBeforeSort(vsfMcAllLotlist, CMlngColCarrierID)
                                                                            
                                    '@=======================
                                    '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfAfterSort(vsfMcAllLotlist, CMlngColCarrierID, cmdUP, cmdDown)
                                    
                                    Exit For
                                Else
                                    '@装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧のｷｬﾘｱIDと、引継ぎｱﾝﾛｰﾀﾞｷｬﾘｱIDが異なる場合
                                    
                                    '@装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧のｷｬﾘｱIDと、引継ぎｷｬﾘｱIDが同じか
                                    If .GetData(llngCnt, CMlngColCarrierID) = mtypCommonInfo.strCarrierId Then
                                        
                                        '@一致行を選択
                                        .Row = llngCnt
                                        
                                        '@=======================
                                        '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                        '@=======================
                                        Call pubVsfBeforeSort(vsfMcAllLotlist, CMlngColCarrierID)
                                        
                                        '@=======================
                                        '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                        '@=======================
                                        Call pubVsfAfterSort(vsfMcAllLotlist, CMlngColCarrierID, cmdUP, cmdDown)
                                        
                                        Exit For
                                    End If
                                End If
                            Else
                                '@代替番号がNULL以外、かつ"0"以外の場合
                                
                                '@装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧のｷｬﾘｱIDと、引継ぎｱﾝﾛｰﾀﾞｷｬﾘｱIDが同じか
                                If .GetData(llngCnt, CMlngColCarrierID) = mtypCommonInfo.strToCarrierId Then
                                    
                                    '@一致行を選択
                                    .Row = llngCnt
                                    
                                    '@=======================
                                    '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfBeforeSort(vsfMcAllLotlist, CMlngColCarrierID)
                                                                            
                                    '@=======================
                                    '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfAfterSort(vsfMcAllLotlist, CMlngColCarrierID, cmdUP, cmdDown)
                                    
                                    Exit For
                                Else
                                    '@装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧のｷｬﾘｱIDと、引継ぎｱﾝﾛｰﾀﾞｷｬﾘｱIDが異なる場合
                                    
                                    '@装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧のｷｬﾘｱIDと、引継ぎｱﾝﾛｰﾀﾞｷｬﾘｱIDが同じか
                                    If .GetData(llngCnt, CMlngColCarrierID) = mtypCommonInfo.strCarrierId Then
                                        
                                        '@一致行を選択
                                        .Row = llngCnt
                                        
                                        '@=======================
                                        '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                        '@=======================
                                        Call pubVsfBeforeSort(vsfMcAllLotlist, CMlngColCarrierID)
                                        
                                        '@=======================
                                        '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                        '@=======================
                                        Call pubVsfAfterSort(vsfMcAllLotlist, CMlngColCarrierID, cmdUP, cmdDown)
                                        
                                        Exit For
                                    End If
                                End If
                            End If
                        Next llngCnt
                    Else
                        '@引継ぎｱﾝﾛｰﾀﾞｰｷｬﾘｱIDがNULLの場合

                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            
                            '@代替番号がNULL、または"0"か
                            If mtypCommonInfo.strAltPointer = vbNullString Or _
                                mtypCommonInfo.strAltPointer = CPstrZero Then
                                
                                '@装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧のｷｬﾘｱIDと、引継ぎｷｬﾘｱIDが同じか
                                If .GetData(llngCnt, CMlngColCarrierID) = mtypCommonInfo.strCarrierId Then
                                    
                                    '@一致行を選択
                                    .Row = llngCnt
                                    
                                    '@=======================
                                    '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfBeforeSort(vsfMcAllLotlist, CMlngColCarrierID)
                                                                         
                                    '@=======================
                                    '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfAfterSort(vsfMcAllLotlist, CMlngColCarrierID, cmdUP, cmdDown)
                                    
                                    Exit For
                                End If
                            Else
                                '@代替番号がNULL以外、かつ"0"以外の場合
                                
                                '@装置ｸﾞﾙｰﾌﾟﾛｯﾄ一覧のｷｬﾘｱIDと、引継ぎｷｬﾘｱIDが同じか
                                If .GetData(llngCnt, CMlngColCarrierID) = mtypCommonInfo.strCarrierId Then
                                    
                                    '@一致行を選択
                                    .Row = llngCnt
                                    
                                    '@=======================
                                    '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfBeforeSort(vsfMcAllLotlist, CMlngColCarrierID)
                                    
                                    '@=======================
                                    '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfAfterSort(vsfMcAllLotlist, CMlngColCarrierID, cmdUP, cmdDown)
                                    
                                    Exit For
                                End If
                            End If
                        Next llngCnt
                    End If
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfConnectCarrier_Sel"
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


    '関数名 list_BeforeDoubleClick
    '機　能：グリッドダブルクリック前処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/01/14 (Mon) 17:00:00 NSYS
    '備　考：
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfMcAllLotlist.BeforeDoubleClick

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
        End If

    End Sub

End Class
