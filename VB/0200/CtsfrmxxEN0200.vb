'ﾌｧｲﾙ名：xxEN0200.frm
'説　明：工程別ロット一覧(工程別)　メインフォーム
'作成日：2004/04/26 (Mon) 17:11:50 M.Matsuura
'更新日：2025/04/18 (Fri) 16:34:52 T.Oide
'備　考：★★★　ｶﾗﾑ追加があった場合(特にｶﾗﾑ挿入)はCM0060.basに影響が出るので注意！！　★★★
'Copyright(C) SEIKO EPSON CORPORATION 2003-2025, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN0200
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN0200    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN0200
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN0200
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN0200)
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
    '@↓2025/04/18 (Fri) 16:34:52 T.Oide **************************************************
    'Private Const CMstrLocalVersion                     As String = "15.02"
    Private Const CMstrLocalVersion                     As String = "15.03"
    '@↑2025/04/18 (Fri) 16:34:52 T.Oide **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN0200

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrlot_oplotlistVer                 As String = "07.00"                 '大工程ﾛｯﾄ検索一覧
    Private Const CMstrlot_steplistVer                  As String = "03.00"                 '小工程取得
    '@↓2012/04/23 (Mon) 12:46:36 Y.Yoneyama **************************************************
    'Private Const CMstrutilregtminfoVer                 As String = "05.00"                 '端末設定情報登録
    Private Const CMstrutilregtminfoVer                 As String = "06.00"                 '端末設定情報登録
    'Private Const CMstrutilreftminfoVer                 As String = "03.00"                 '端末設定情報取得
    Private Const CMstrutilreftminfoVer                 As String = "04.00"                 '端末設定情報取得
    '@↑2012/04/23 (Mon) 12:46:36 Y.Yoneyama **************************************************
    Private Const CMstrmas_useoplistVer                 As String = "02.00"                 '大工程ﾏｽﾀ取得
    Private Const CMstrmas_pdlist__Ver                  As String = "03.00"                 '機種区分一覧取得
    Private Const CMstrmas_flowlistVer                  As String = "04.00"                 '種別区分一覧取得

    '@vsfStepLotListの定数宣言(ｶﾗﾑ)
    '@★★★　ｶﾗﾑ追加/変更があった場合(特に列番の変更)はCM0060.basに影響が出るので注意！！　★★★
    Private Const CMlngvsfStepLLColNo                   As Integer = 0                      '№
    Private Const CMlngvsfStepLLColKb                   As Integer = 1                      '保/停区分
    Private Const CMlngvsfStepLLColOpID                 As Integer = 2                      '大工程名
    Private Const CMlngvsfStepLLColStepID               As Integer = 3                      '小工程名
    Private Const CMlngvsfStepLLColNowSt                As Integer = 4                      'ﾛｯﾄ状態
    Private Const CMlngvsfStepLLColCarrierID            As Integer = 5                      'ｷｬﾘｱID
    Private Const CMlngvsfStepLLColLotID                As Integer = 6                      'ﾛｯﾄID
    Private Const CMlngvsfStepLLColPdID                 As Integer = 7                      '機種ID
    Private Const CMlngvsfStepLLColFlowClass            As Integer = 8                      '種別(流動区分)
    Private Const CMlngvsfStepLLColPriority             As Integer = 9                      '優先順位
    Private Const CMlngvsfStepLLColLotPosition          As Integer = 10                     'ﾛｯﾄ位置
    Private Const CMlngvsfStepLLColLotManagerName       As Integer = 11                     'ﾛｯﾄ担当
    Private Const CMlngvsfStepLLColWfNum                As Integer = 12                     'WF枚数
    Private Const CMlngvsfStepLLColChipNum              As Integer = 13                     'ﾁｯﾌﾟ
    Private Const CMlngvsfStepLLColPlanShipDate         As Integer = 14                     '送品予定日
    Private Const CMlngvsfStepLLColLotComments          As Integer = 15                     'ﾛｯﾄｺﾒﾝﾄ有無
    Private Const CMlngvsfStepLLColUnLoaderCarrierID    As Integer = 16                     'ｱﾝﾛｰﾀﾞｷｬﾘｱID
    Private Const CMlngvsfStepLLColAltNumber            As Integer = 17                     '代替番号
    Private Const CMlngvsfStepLLColJBatchID             As Integer = 18                     '蒸着ﾊﾞｯﾁID
    Private Const CMlngvsfStepLLColCfFlag               As Integer = 19                     'CFﾌﾗｸﾞ
    Private Const CMlngvsfStepLLColLpFlag               As Integer = 20                     'LPﾌﾗｸﾞ
    Private Const CMlngvsfStepLLColVaFlag               As Integer = 21                     '無機ﾌﾗｸﾞ
    Private Const CMlngvsfStepLLColTpalClass            As Integer = 22                     'TPAL区分

    '@vsfStepLotListの定数宣言(幅)
    Private Const CMlngvsfStepLLColWNo                  As Integer = 44                     '№
    Private Const CMlngvsfStepLLColWKb                  As Integer = 25                     '保/停区分
    Private Const CMlngvsfStepLLColWOpID                As Integer = 81                     '大工程名
    Private Const CMlngvsfStepLLColWStepID              As Integer = 81                     '小工程名
    Private Const CMlngvsfStepLLColWNowSt               As Integer = 81                     'ﾛｯﾄ状態
    Private Const CMlngvsfStepLLColWCarrierID           As Integer = 65                     'ｷｬﾘｱID
    Private Const CMlngvsfStepLLColWLotID               As Integer = 81                     'ﾛｯﾄID
    Private Const CMlngvsfStepLLColWPdID                As Integer = 53                     '機種ID
    Private Const CMlngvsfStepLLColWFlowClass           As Integer = 25                     '種別(流動区分)
    Private Const CMlngvsfStepLLColWPriority            As Integer = 25                     '優先順位
    Private Const CMlngvsfStepLLColWLotPosition         As Integer = 81                     'ﾛｯﾄ位置
    Private Const CMlngvsfStepLLColWLotManagerName      As Integer = 81                     'ﾛｯﾄ担当
    Private Const CMlngvsfStepLLColWWfNum               As Integer = 53                     'WF枚数
    Private Const CMlngvsfStepLLColWChipNum             As Integer = 53                     'ﾁｯﾌﾟ
    Private Const CMlngvsfStepLLColWPlanShipDate        As Integer = 67                     '送品予定日
    Private Const CMlngvsfStepLLColWLotComments         As Integer = 47                     'ﾛｯﾄｺﾒﾝﾄ有無
    Private Const CMlngvsfStepLLColWUnLoaderCarrierID   As Integer = 67                     'ｱﾝﾛｰﾀﾞｷｬﾘｱID
    Private Const CMlngvsfStepLLColWAltNumber           As Integer = 25                     '代替番号
    Private Const CMlngvsfStepLLColWJBatchID            As Integer = 0                      '蒸着ﾊﾞｯﾁID
    Private Const CMlngvsfStepLLColWCfFlag              As Integer = 0                      'CFﾌﾗｸﾞ
    Private Const CMlngvsfStepLLColWLpFlag              As Integer = 0                      'LPﾌﾗｸﾞ
    Private Const CMlngvsfStepLLColWVaFlag              As Integer = 0                      '無機ﾌﾗｸﾞ
    Private Const CMlngvsfStepLLColWTpalClass           As Integer = 0                      'TPAL区分

    '@vsfStepLotListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfStepLLColTNo                  As String = "№"                    '№
    Private Const CMstrvsfStepLLColTKb                  As String = ""                      '保/停区分
    Private Const CMstrvsfStepLLColTOpID                As String = "大工程"                '大工程名
    Private Const CMstrvsfStepLLColTStepID              As String = "小工程"                '小工程名
    Private Const CMstrvsfStepLLColTNowSt               As String = "状態"                  'ﾛｯﾄ状態
    Private Const CMstrvsfStepLLColTCarrierID           As String = "キャリアID"            'ｷｬﾘｱID
    Private Const CMstrvsfStepLLColTLotID               As String = "ロットID"              'ﾛｯﾄID
    Private Const CMstrvsfStepLLColTPdID                As String = "機種"                  '機種ID
    Private Const CMstrvsfStepLLColTFlowClass           As String = "種"                    '種別(流動区分)
    Private Const CMstrvsfStepLLColTPriority            As String = "優"                    '優先順位
    Private Const CMstrvsfStepLLColTLotPosition         As String = "ロット位置"             'ﾛｯﾄ位置
    Private Const CMstrvsfStepLLColTLotManagerName      As String = "ロット担当"            'ﾛｯﾄ担当
    Private Const CMstrvsfStepLLColTWfNum               As String = "WF枚数"                'WF枚数
    Private Const CMstrvsfStepLLColTChipNum             As String = "チップ"                'ﾁｯﾌﾟ
    Private Const CMstrvsfStepLLColTPlanShipDate        As String = "送品予定日"            '送品予定日
    Private Const CMstrvsfStepLLColTLotComments         As String = "コメント"              'ﾛｯﾄｺﾒﾝﾄ有無

    '@vsfStepLotListの定数宣言
    Private Const CMlngvsfStepLLRowTitle                As Integer = 0                      'ﾀｲﾄﾙ行(行)
    Private Const CMlngvsfStepLLColTitle                As Integer = 0                      'ﾀｲﾄﾙ行(列)
    Private Const CMlngvsfStepLLHFontSize               As Integer = 11                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfStepLLHHeight                 As Integer = 20                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngvsfStepLLHeight                  As Integer = 16                     '1ｽﾛｯﾄの高さ
    Private Const CMlngvsfFrozenCols                    As Integer = 7                      '固定列数
    Private Const CMlngvsfCellPaintColorStart           As Integer = 4                      'ｾﾙの背景色塗りつぶし開始列

    Private Const CMstrHo                               As String = "保"                    '保留表示
    Private Const CMstrTei                              As String = "停"                    '停止表示
    Private Const CMstrRi                               As String = "リ"                    'ﾘﾜｰｸ表示
    Private Const CMstrTsui                             As String = "追"                    '追加表示
    Private Const CMstrSen                              As String = "先"                    '先行表示

    '@色の定数宣言
    Private Const CMlngVbColorWhite                     As Integer = &HFFFFFF               '白色
    Private Const CMlngVbColorBlack                     As Integer = &H0&                   '黒色

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                      As Integer = 14                     'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Integer = 14                     'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColName                   As Integer = 0                      '名称列番
    Private Const CMlngCmbGridColID                     As Integer = 1                      'ID列番(非表示項目)
    Private Const CMlngCmbDispCols                      As Integer = 1                      'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbRowHeight                     As Integer = 30                     'ﾘｽﾄ行の高さ

    '@一覧ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbDispCol2                      As Integer = 2                      'ｸﾞﾘｯﾄﾞ表示列数=2
    Private Const CMlngCmbGroupCols                     As Integer = 1                      '列方向ｸﾞﾙｰﾌﾟ数
    Private Const CMlngCMbSelectMode                    As Integer = 1                      '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
    Private Const CMstrCmbAddedComment                  As String = " 項目選択"              '表示 文字列
    Private Const CMstrCmbAddedCommentNone              As String = "0 項目選択"             '表示 文字列「選択なし」
    Private Const CMlngCmbGridCol0                      As Integer = 0                      '選択列数
    Private Const CMlngCmbValueCol1                     As Integer = 1                      '値取得列=1
    Private Const CMlngCmbGetCol0                       As Integer = 0                      'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=0
    Private Const CMlngCmbGetCol1                       As Integer = 1                      'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=1
    Private Const CMstrCmbCheckOn                       As String = "1"                     'ﾁｪｯｸON

    '@その他
    Private Const CMstrFormName                         As String = "frmxxEN0200"           '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                         As String = "Form_Load"             'ｲﾍﾞﾝﾄ名称
    Private Const CMstrPrvblnOpListSel                  As String = "prvblnLotOpList_Sel"   'ｲﾍﾞﾝﾄ名称
    Private Const CMstrPrvblnStepListSel                As String = "prvblnStepList_Sel"    'ｲﾍﾞﾝﾄ名称
    Private Const CMstrPrvblnLotOpListSel               As String = "prvblnLotOpList_Sel"   'ｲﾍﾞﾝﾄ名称


    '@表示区分
    Private Const CMstrProcess                          As String = "工程別"                '表示区分に設定
    Private Const CmstrProcessAll                       As String = "全工程"                '表示区分に設定
    Private Const CmstrProcessTemplate                  As String = "テンプレート"          '表示区分に設定

    Private Const CMstrLotHoldFlgOn                     As String = "1"                     '保留ﾛｯﾄﾌﾗｸﾞON
    Private Const CMstrLotStopFlgOn                     As String = "1"                     '停止ﾛｯﾄﾌﾗｸﾞON
    Private Const CMstrReworkFlgOn                      As String = "1"                     'ﾘﾜｰｸﾌﾗｸﾞON
    Private Const CMstrReworkFlgOn2                     As String = "2"                     '追加ﾌﾗｸﾞON
    Private Const CMstrTemplateSeqNum                   As String = "99999"                 '標準工順番号

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mlngWkLotCnt                                As Integer                          '出力件数格納
    Private mtypWkLotList                               As List(Of LotListList)             '出力情報格納
    Private mtypMasOpList                               As MasOpList                        '大工程格納変数
    Private mblnOpListDispFlag                          As Boolean                          '大工程引継情報表示ﾌﾗｸﾞ(True：OK/False：NG)
    Private mtypMasStepList                             As MasStepList                      '小工程格納変数
    Private mblnStepListDispFlag                        As Boolean                          '小工程引継情報表示ﾌﾗｸﾞ(True：OK/False：NG)
    Private mtypLotList                                 As LotList                          'ﾛｯﾄ一覧取得情報格納
    Private mlngLotListCnt                              As Integer                          'ﾛｯﾄ一覧取得件数格納
    Private mstrKbn                                     As String                           '表示区分名格納
    Private mstrOpID                                    As String                           '大工程名格納
    Private mstrStepID                                  As String                           '小工程名格納
    Private mtypChgSort                                 As ChgSort                          'ｿｰﾄ保持用
    Private mtypProductList                             As List(Of ProductList)             '機種格納変数
    Private mlngProductListCnt                          As Integer                          '機種格納数
    Private mtypDivisionList                            As List(Of DivisionList)            '種別格納変数
    Private mlngDivisionListCnt                         As Integer                          '種別格納数
    Private mblnFormLoadFlag                            As Boolean                          '初回ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True：初回以降、False：初回)
    Private mblnTakeOverFlag                            As Boolean                          '引継ぎ判定ﾌﾗｸﾞ
    Private mblnProcSkipFlag                            As Boolean                          '処理ｽｷｯﾌﾟﾌﾗｸﾞ(True：ｽｷｯﾌﾟする、False：ｽｷｯﾌﾟしない)
    Private mblnPDIDChgFlag                             As Boolean                          '機種変更ﾌﾗｸﾞ(True：変更あり、False：未変更)
    Private mblnFlowClassChgFlag                        As Boolean                          '種別変更ﾌﾗｸﾞ(True：変更あり、False：未変更)
    Private mtypCommonInfo                              As CommonInfo                       '引継ぎ構造体を格納

    Private buttonProcessing                            As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                          'NSYS WindowCloseフラグ
    Private mintStepLotListRowBeforeSort                As Integer                          'NSYS StepLotListのソート前選択行

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
        mintStepLotListRowBeforeSort =  0

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
    '作成日：2004/04/26 (Mon) 17:11:50 M.Matsuura
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 14:41:23 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2004/10/06 (Wed) 08:57:28 M.Miura  　  閉じるﾎﾞﾀﾝの有効/無効制御追加
    '　　　：2004/10/14 (Thu) 15:07:48 M.Miura　    ｿｰﾄ順保持構造体の初期化を追加
    '　　　：2004/10/18 (Mon) 16:13:43 N.Kasai      0件ﾒｯｾｰｼﾞｺﾒﾝﾄｱｳﾄ
    '　　　：2004/10/26 (Tue) 12:01:50 S.Deguchi    DoEvents前後に画面の有効/無効処理を追加(終了ｺﾏﾝﾄﾞｴﾗｰ対応)
    '　　　：2005/06/16 (Thu) 15:39:55 N.Kojima     ｺﾒﾝﾄｱｳﾄ行の削除(ﾘｽﾄ表示件数0件時のﾒｯｾｰｼﾞ表示)
    '　　　：2005/09/06 (Tue) 11:23:13 S.Deguchi    処理見直しを実行
    '　　　：2009/02/24 (Tue) 17:01:49 N.Kojima     ﾁｯﾌﾟ品判別説明ﾗﾍﾞﾙの制御処理追加。(案件№03402)
    '　　　：2009/07/29 (Wed) 12:56:04 N.Kojima     無機対応Phase2、組立でもﾀﾞﾐｰﾛｯﾄが流動することになったので"ﾀﾞﾐｰ"説明を表示する。(案件№03661)
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub Form_Load()

        Dim ltypDisp            As UtilRefTmInfo    '端末設定情報格納
        Dim lblnAns             As Boolean          '結果格納
        Dim lstrClassDivision   As String           '処理区分格納用
        Dim llngCnt             As Integer          '汎用ｶｳﾝﾀ

        Try

            '@Escﾎﾞﾀﾝを無効にする(ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない)
            Me.CancelButton = Nothing

            '@=======================
            '@ 機能ﾊﾞｰｼﾞｮﾝの判定
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN0200, CMstrLocalVersion)

            '@機能ﾊﾞｰｼﾞｮﾝの判定結果が"False：Ver相違"か
            If lblnAns = False Then

                '@Escﾎﾞﾀﾝを有効に戻す
                Me.CancelButton = cmdClose
                Exit Sub
            End If

            '@=======================
            '@ 画面初期化処理
            '@=======================
            Call prvFrmxxEN0200_Init()

            '@=======================
            '@ ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ初期化処理
            '@=======================
            Call prvVsfStepLotList_Init()


            '@各種ﾓｼﾞｭｰﾙ変数の初期化
            mblnFormLoadFlag = False                        '初回ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True：初回以降、False：初回)
            mblnTakeOverFlag = False                        '引継起動ﾌﾗｸﾞ
            mblnOpListDispFlag = False                      '大工程引継表示ﾌﾗｸﾞ
            mblnStepListDispFlag = False                    '小工程引継表示ﾌﾗｸﾞ


            '@起動SBが組立か
            If pstrSBID = CPstrSBID2A0 Then
                '@2A0：組立の場合

                lblTitleL.BackColor = ColorTranslator.FromWin32(CPlngLColor)           '機種L
                lblTitleR.BackColor = ColorTranslator.FromWin32(CPlngRColor)           '機種R
                lblTitleL.Visible = True
                lblTitleR.Visible = True
                lblTitleChip.Visible = True                 'ﾁｯﾌﾟ品説明
            Else
                '@1A0：基板の場合

                lblTitleL.Visible = False
                lblTitleR.Visible = False
                lblTitleChip.Visible = False                'ﾁｯﾌﾟ品説明
            End If

            lblTitleD.BackColor = ColorTranslator.FromWin32(CPlngVbColorOrange)        'ﾀﾞﾐｰ
            lblTitleD.Visible = True
            lblTitleHT.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)        '保留/停止


            '@ｿｰﾄ情報保持用構造体の初期化
            With mtypChgSort

                .lngCnt = 0                                     'ﾃﾞｰﾀ数
                .typChgSortList = New List(Of ChgSortList)      '配列
                .blnChgWidth = False                            '列幅変更ﾌﾗｸﾞ(False：未変更)
                .strKey = vbNullString                          'ｶﾚﾝﾄ行検索ｷｰ
            End With


            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)

            '@処理区分に"2A02：全機種・全種別"をｾｯﾄ
            lstrClassDivision = CPstrCD2A & CPstrCD02

            '@=======================
            '@ 機種区分一覧取得
            '@=======================
            lblnAns = pubblnMasPdlist_Sel(CMstrmas_pdlist__Ver, _
                                          lstrClassDivision, _
                                          mtypProductList, _
                                          mlngProductListCnt, _
                                          pstrSBID)

            '@機種区分一覧取得結果が"False：取得失敗"か
            If lblnAns = False Then

                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)

                '@Escﾎﾞﾀﾝを有効に戻す
                Me.CancelButton = cmdClose
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)



            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)

            '@処理区分に"02：全て"をｾｯﾄ
            lstrClassDivision = CPstrCD02

            '@=======================
            '@ 流動区分一覧取得
            '@=======================
            lblnAns = pubblnMasFlowlist_Sel(CMstrmas_flowlistVer, _
                                            mtypDivisionList, _
                                            mlngDivisionListCnt, _
                                            pstrSBID, _
                                            lstrClassDivision)

            '@流動区分一覧取得結果が"False：取得失敗"か
            If lblnAns = False Then

                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)

                '@Escﾎﾞﾀﾝを有効に戻す
                Me.CancelButton = cmdClose
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)


            '@処理ｽｷｯﾌﾟﾌﾗｸﾞに"True：ｽｷｯﾌﾟする"をｾｯﾄ(Comboの表示設定をする時に,Change処理を動かさない為)
            mblnProcSkipFlag = True

            '@=======================
            '@ 機種ｺﾝﾎﾞ設定処理
            '@=======================
            Call prvcmbPd_Disp()

            '@=======================
            '@ 種別ｺﾝﾎﾞ設定処理
            '@=======================
            Call prvcmbFlowClass_Disp()

            '@処理ｽｷｯﾌﾟﾌﾗｸﾞの初期化(Comboの表示設定をする時に,Change処理を動かさない為)
            mblnProcSkipFlag = False


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

                    '@端末情報の大工程がNULL以外か
                    If .strOpID <> vbNullString Then

                        '@取得値を各種変数に格納
                        mstrKbn = CMstrProcess      '"工程別"
                        mstrOpID = .strOpID         '大工程
                        mstrStepID = .strStepID     '小工程

                        '@引継起動ﾌﾗｸﾞに"True：引継ぎ起動"をｾｯﾄ
                        mblnTakeOverFlag = True

                        '@=======================
                        '@ 大工程取得処理
                        '@=======================
                        lblnAns = prvblnMasOpList_Sel()

                        '@大工程取得処理結果が"True：処理成功"か
                        If lblnAns = True Then

                            '@大工程ﾘｽﾄにﾃﾞｰﾀが存在するか
                            If mtypMasOpList.lngMasOpCnt > 0 Then

                                For llngCnt = 0 To mtypMasOpList.lngMasOpCnt - 1

                                    '@大工程ﾘｽﾄの中に端末情報の大工程が存在するか
                                    If mstrOpID = mtypMasOpList.typMasOpId(llngCnt).strOpID Then

                                        '@大工程存在ﾌﾗｸﾞに"True：存在"をｾｯﾄ
                                        mblnOpListDispFlag = True
                                        Exit For
                                    End If
                                Next llngCnt
                            Else
                                '@大工程ﾘｽﾄにﾃﾞｰﾀが無い場合

                                '@Escﾎﾞﾀﾝを有効にする
                                Me.CancelButton = cmdClose
                            End If
                        Else
                            '@大工程取得処理結果が"False：処理失敗"か

                            '@Escﾎﾞﾀﾝを有効に戻す
                            Me.CancelButton = cmdClose
                            Exit Sub
                        End If


                        '@=======================
                        '@ 小工程取得処理
                        '@=======================
                        lblnAns = prvblnStepList_Sel

                        '@小工程取得処理結果が"True：処理成功"か
                        If lblnAns = True Then

                            '@小工程ﾘｽﾄにﾃﾞｰﾀが存在するか
                            If mtypMasStepList.lngMasStepCnt > 0 Then

                                For llngCnt = 0 To mtypMasStepList.lngMasStepCnt - 1

                                    '@小工程ﾘｽﾄの中に端末情報の小工程が存在するか
                                    If mstrStepID = mtypMasStepList.typMasStepId(llngCnt).strStepID Then

                                        '@小工程存在ﾌﾗｸﾞに"True：存在"をｾｯﾄ
                                        mblnStepListDispFlag = True
                                        Exit For
                                    End If
                                Next llngCnt
                            Else
                                '@小工程ﾘｽﾄにﾃﾞｰﾀが無い場合

                                '@Escﾎﾞﾀﾝを有効に戻す
                                Me.CancelButton = cmdClose
                            End If
                        Else
                            '@小工程取得処理結果が"False：処理失敗"の場合

                            '@Escﾎﾞﾀﾝを有効に戻す
                            Me.CancelButton = cmdClose
                            Exit Sub
                        End If
                    End If
                End With
            Else
                '@端末設定情報取得結果が"False：取得失敗"か

                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)

                '@Escﾎﾞﾀﾝを有効に戻す
                Me.CancelButton = cmdClose
                Exit Sub
            End If

            '@引継ぎ構造体を格納する(※ﾌｫｰﾑﾛｰﾄﾞ後のSTART_PROCで値がｸﾘｱされる為、格納しておく)
            mtypCommonInfo = ptypCommonInfo

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"True：起動成功"をｾｯﾄ
            pblnFormLoad = True

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

    '関数名：Form_Activate
    '機　能：[ﾌｫｰﾑ]　ｱｸﾃｨﾌﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/09/06 (Tue) 10:18:56 S.Deguchi
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Dim lblnAns             As Boolean          '結果格納
        Dim ltypLotListReq      As OpLotList        '工程別ﾛｯﾄ一覧要求構造体

        Try

            '@初回ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False：初回"か
            If mblnFormLoadFlag = False Then

                '@初回ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"True：初回以降"をｾｯﾄ
                mblnFormLoadFlag = True

                '@=======================
                '@ 表示区分ｺﾝﾎﾞ設定処理
                '@=======================
                Call prvCmbOutKbn_Disp()

                '@=======================
                '@ 大工程ｺﾝﾎﾞ設定処理
                '@=======================
                Call prvCmbOpID_Disp()

                '@=======================
                '@ 小工程ｺﾝﾎﾞ設定処理
                '@=======================
                Call prvCmbStepID_Disp()

                '@引継起動ﾌﾗｸﾞが"True：引継ぎ起動"か
                If mblnTakeOverFlag = True Then

                    '@処理ｽｷｯﾌﾟﾌﾗｸﾞに"True：ｽｷｯﾌﾟする"をｾｯﾄ(Comboの表示設定をする時に,Change処理を動かさない為)
                    mblnProcSkipFlag = True

                    '@制御をOSに渡す
                    '@ﾌｫｰﾑﾛｰﾄﾞ中の通信に負荷がかかった場合にﾌｫｰﾑに制御を渡す
                    '@ｲﾍﾞﾝﾄを抑止する為、ﾌｫｰﾑをﾛｯｸする。
                    'DoEvents
                    Refresh()

                    '@表示区分ｺﾝﾎﾞに「工程別」をｾｯﾄ
                    cmbOutKbn.Text = mstrKbn

                    '@大工程に前回選択大工程をｾｯﾄ
                    cmbOpID.Text = mstrOpID

                    '@大工程ｺﾝﾎﾞ内容が0件か
                    If cmbOpID.ListCount = 0 Then

                        '@大工程ｺﾝﾎﾞを無効にする
                        cmbOpID.Enabled = False
                    End If

                    '@小工程に前回選択小工程をｾｯﾄ
                    cmbStepID.Text = mstrStepID

                    '@小工程ｺﾝﾎﾞ内容が0件か
                    If cmbStepID.ListCount = 0 Then

                        '@小工程ｺﾝﾎﾞを無効にする
                        cmbStepID.Enabled = False
                    End If

                    ' Focus 設定
                    RemoveHandler cmbOutKbn.Validating, AddressOf cmbOutKbn_Validate
                    If Me.ActiveControl.Name = cmbOutKbn.Name Then
                        '一旦フォーカスをLostする
                        Me.ActiveControl = Nothing
                        'フォーカスを再度当てる
                        Me.ActiveControl = Me.cmbOutKbn
                        Me.cmbOutKbn.Focus()
                    End If
                    AddHandler cmbOutKbn.Validating, AddressOf cmbOutKbn_Validate

                    '@処理ｽｷｯﾌﾟﾌﾗｸﾞの初期化(Comboの表示設定をする時に,Change処理を動かさない為)
                    mblnProcSkipFlag = False


                    '@=======================
                    '@ 工程別ﾛｯﾄ一覧取得要求ﾃﾞｰﾀ作成処理(27：大工程・小工程指定/機種・種別全指定)
                    '@=======================
                    Call prvLotListReq_Proc(CPstrCD27, ltypLotListReq)

                    '@=======================
                    '@ 工程別ﾛｯﾄ一覧ﾘｽﾄ取得処理
                    '@=======================
                    lblnAns = prvblnLotOpList_Sel(ltypLotListReq)

                    '@工程別ﾛｯﾄ一覧ﾘｽﾄ取得処理結果が"True：処理成功"か
                    If lblnAns = True Then

                        '@工程別ﾛｯﾄ一覧取得ﾃﾞｰﾀ数が1件以上あるか
                        If mlngLotListCnt > 0 Then

                            mlngWkLotCnt = mlngLotListCnt                                           '工程別ﾛｯﾄ一覧取得件数の退避
                            mtypWkLotList = New List(Of LotListList)(mtypLotList.typLotListList)    '工程別ﾛｯﾄﾘｽﾄに退避
                        End If
                    Else
                        '@工程別ﾛｯﾄ一覧ﾘｽﾄ取得処理結果が"False：処理失敗"か

                        '@Escﾎﾞﾀﾝを有効に戻す
                        Me.CancelButton = cmdClose
                        Exit Sub
                    End If

                    '@=======================
                    '@ 工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ表示処理
                    '@=======================
                    Call prvVsfStepLotList_Disp(mtypWkLotList, _
                                                mlngWkLotCnt)

                    '@各種ﾗﾍﾞﾙの表示
                    lblNowDate.Text = Format$(Now, CPstrDateFormat)              '情報取得日時
                    lblLotCnt.Text = Format(mlngWkLotCnt, CPstrDateFormatKanma)  '該当件数

                    '@最新取得ﾎﾞﾀﾝを有効にする
                    cmdNowList.Enabled = True

                    '@Escﾎﾞﾀﾝを有効に戻す
                    Me.CancelButton = cmdClose
                Else
                    '@引継起動ﾌﾗｸﾞが"False：単独起動"の場合

                    '@処理ｽｷｯﾌﾟﾌﾗｸﾞに"True：ｽｷｯﾌﾟする"をｾｯﾄ
                    mblnProcSkipFlag = True

                    '@表示区分ｺﾝﾎﾞを未選択状態にする
                    cmbOutKbn.ListIndex = -1

                    '@大工程ｺﾝﾎﾞを無効、未選択状態にする
                    cmbOpID.Enabled = False
                    cmbOpID.ListIndex = -1

                    '@小工程ｺﾝﾎﾞを無効、未選択状態にする
                    cmbStepID.Enabled = False
                    cmbStepID.ListIndex = -1

                    ' Focus 設定
                    RemoveHandler cmbOutKbn.Validating, AddressOf cmbOutKbn_Validate
                    If Me.ActiveControl.Name = cmbOutKbn.Name Then
                        '一旦フォーカスをLostする
                        Me.ActiveControl = Nothing
                        'フォーカスを再度当てる
                        Me.ActiveControl = Me.cmbOutKbn
                        Me.cmbOutKbn.Focus()
                    End If
                    AddHandler cmbOutKbn.Validating, AddressOf cmbOutKbn_Validate
                    
                    '@処理ｽｷｯﾌﾟﾌﾗｸﾞを初期化する
                    mblnProcSkipFlag = False

                    '@Escﾎﾞﾀﾝを有効にする
                    Me.CancelButton = cmdClose
                End If
                'NSYS Activate中にpublngMsgBox等で別ウィンドウを表示するとActivateがキャンセルされるため、再Activateする
                'NSYS Activateイベント中にActivate()を呼び出しても作用しないため、遅延で実行する。ラムダ式使用
                Dim lfuncActivate As Action = Sub()
                                                  Me.Activate()
                                              End Sub
                Me.BeginInvoke(lfuncActivate)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：[ﾌｫｰﾑ]　ｷｰﾀﾞｳﾝ時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2004/04/26 (Mon) 17:11:50 M.Matsuura
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2005/06/16 (Thu) 15:39:01 N.Kojima     ｺﾒﾝﾄｱｳﾄ行の削除(SetFocus処理のｺﾒﾝﾄｱｳﾄ)
    '　　　：2005/09/06 (Tue) 14:48:34 S.Deguchi    処理見直し
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@以下の条件の場合、ｷｰｺｰﾄﾞを無効にし処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                e.Handled = True
                Exit Sub
            End If

            '@=======================
            '@ ｸﾞﾘｯﾄﾞｷｰ制御処理(ｸﾞﾘｯﾄﾞ共通処理)
            '@=======================
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfStepLotList)

            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name

                '@〓 大工程ｺﾝﾎﾞ 〓
                Case cmbOpID.Name

                    '@Enterｷｰが押下されたか
                    If e.KeyCode = Keys.Return Then

                        '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄし、ｷｰｺｰﾄﾞを初期化する
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True

                        Exit Sub
                    End If

                '@〓 小工程ｺﾝﾎﾞ 〓
                Case cmbStepID.Name

                    '@Enterｷｰが押下されたか
                    If e.KeyCode = Keys.Return Then

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

                        Exit Sub
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
    '作成日：2004/04/27 (Tue) 18:06:18 M.Matsuura
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2004/10/14 (Thu) 15:08:39 M.Miura　    ｿｰﾄ順構造体のｸﾘｱを追加
    '　　　：2004/10/26 (Tue) 10:58:42 S.Deguchi    DoEventsﾌﾗｸﾞによる判別を追加(終了ｺﾏﾝﾄﾞｴﾗｰ対応)
    '　　　：2004/11/01 (Mon) 15:27:54 T.Kitagawa　 閉じるﾎﾞﾀﾝ統合
    '　　　：2005/09/06 (Tue) 14:48:14 S.Deguchi    処理見直し
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      'ACT開放結果格納

        Try

            '@ﾌｫｰﾑの"×"ﾎﾞﾀﾝにて呼ばれたか
            If mblnCloseFromControlMenu Then

                '@=======================
                '@ 閉じるﾎﾞﾀﾝ処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, EventArgs.Empty)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If

            '@各種構造体の初期化
            mtypWkLotList = Nothing
            mtypMasOpList.typMasOpId = Nothing
            mtypMasStepList.typMasStepId = Nothing
            mtypLotList.typLotListList = Nothing
            mtypChgSort.typChgSortList = Nothing
            mtypProductList = Nothing
            mtypDivisionList = Nothing

            '@ACT初期化ﾌﾗｸﾞが"Treu：初期化済"か
            If pblnActInitFlg = True Then

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

    '関数名：cmdNowList_Click
    '機　能：[最新取得]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/26 (Mon) 17:11:50 M.Matsuura
    '更新日：2009/08/27 (Thu) 12:41:54 N.Kojima
    '備　考：
    '　　　：2004/09/22 (Wed) 15:31:25 N.Kasai      pubblnLotList_Selの引数を修正
    '　　　：2004/10/08 (Fri) 11:11:37 M.Miura　    連打対応追加
    '　　　：2004/10/18 (Mon) 16:14:48 N.Kasai      0件ﾒｯｾｰｼﾞｺﾒﾝﾄｱｳﾄ
    '　　　：2004/11/05 (Fri) 17:09:56 T.Kitagawa   ﾃﾝﾌﾟﾚｰﾄ表示対応(不具合№199)
    '　　　：2005/06/16 (Thu) 15:41:34 N.Kojima     ｺﾒﾝﾄｱｳﾄ行の削除(ﾘｽﾄの表示件数が0件の時のｲﾝﾌｫﾒｰｼｮﾝ)
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmdNowList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowList.Click

        Dim lblnAns             As Boolean          '結果格納
        Dim ltypLotListReq      As OpLotList        '工程別ﾛｯﾄ一覧要求構造体

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


            '@配列・ﾓｼﾞｭｰﾙ変数の初期化
            mtypWkLotList = Nothing             '工程別ﾛｯﾄ一覧ﾘｽﾄ
            mlngWkLotCnt = 0                    '工程別ﾛｯﾄ一覧ﾘｽﾄ件数

            '@★ 表示区分により処理分岐 ★
            Select Case cmbOutKbn.ListIndex

                '@〓 工程別 〓
                Case 0

                    '@=======================
                    '@ 工程別ﾛｯﾄ一覧取得要求ﾃﾞｰﾀ作成処理(27：大工程・小工程指定/機種・種別全指定)
                    '@=======================
                    Call prvLotListReq_Proc(CPstrCD27, ltypLotListReq)

                '@〓 全工程 〓
                Case 1

                    '@=======================
                    '@ 工程別ﾛｯﾄ一覧取得要求ﾃﾞｰﾀ作成処理(02：全工程指定)
                    '@=======================
                    Call prvLotListReq_Proc(CPstrCD02, ltypLotListReq)

                '@〓 ﾃﾝﾌﾟﾚｰﾄ 〓
                Case 2

                    '@=======================
                    '@ 工程別ﾛｯﾄ一覧取得要求ﾃﾞｰﾀ作成処理(3J：ﾃﾝﾌﾟﾚｰﾄ指定)
                    '@=======================
                    Call prvLotListReq_Proc(CPstrCD3J, ltypLotListReq)

            End Select


            '@=======================
            '@ 工程別ﾛｯﾄ一覧ﾘｽﾄ取得
            '@=======================
            lblnAns = prvblnLotOpList_Sel(ltypLotListReq)

            '@工程別ﾛｯﾄ一覧ﾘｽﾄ取得結果が"True：処理成功"か
            If lblnAns = True Then

                '@工程別ﾛｯﾄ一覧ﾘｽﾄ件数が1件以上存在するか
                If mlngLotListCnt > 0 Then

                    '@各種退避用配列・変数に取得値を格納
                    mlngWkLotCnt = mlngLotListCnt                                           '工程別ﾛｯﾄ一覧ﾘｽﾄ件数
                    mtypWkLotList = New List(Of LotListList)(mtypLotList.typLotListList)    '工程別ﾛｯﾄ一覧ﾘｽﾄ

                    '@=======================
                    '@ 工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ表示処理
                    '@=======================
                    Call prvVsfStepLotList_Disp(mtypWkLotList, mlngWkLotCnt)

                    If ActiveControl Is sender OrElse ActiveControl Is cmbPd OrElse ActiveControl Is cmbFlowClass Then
                        '@工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfStepLotList)
                    End If

                Else
                    '@工程別ﾛｯﾄ一覧ﾘｽﾄ件数が0件の場合

                    If ActiveControl Is cmbPd OrElse ActiveControl Is cmbFlowClass Then
                        '@最新取得ﾎﾞﾀﾝにﾌｫｰｶｽ保持
                        Call pubSetFocus(cmdNowList)
                    End If

                End If

                '@情報取得日時表示
                lblNowDate.Text = Format$(Now, CPstrDateFormat)              '情報取得日時
                lblLotCnt.Text = Format(mlngWkLotCnt, CPstrDateFormatKanma)  '該当件数

                '@最新取得ﾎﾞﾀﾝを有効にする
                cmdNowList.Enabled = True

            Else
                '@工程別ﾛｯﾄ一覧ﾘｽﾄ取得結果が"False：処理失敗"か

                If ActiveControl Is cmbPd OrElse ActiveControl Is cmbFlowClass Then
                    '@最新取得ﾎﾞﾀﾝにﾌｫｰｶｽ保持
                    Call pubSetFocus(cmdNowList)
                End If
                Exit Sub
            End If

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

    '関数名：cmbOutKbn_Change
    '機　能：[表示区分]ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/26 (Mon) 17:11:50 M.Matsuura
    '更新日：2009/08/27 (Thu) 12:41:54 N.Kojima
    '備　考：
    '　　　：2004/10/13 (Wed) 11:24:38 N.Kasai      ①ｺﾝﾎﾞ使用可追加
    '　　　：                                       ②DoEvents初期化に対しての判別処理を追加
    '　　　：2004/11/17 (Wed) 11:04:38 S.Deguchi    小工程のComboは使用不可に設定
    '　　　：2005/06/16 (Thu) 15:43:07 N.Kojima     ｺﾒﾝﾄｱｳﾄ行の削除(cmbStepID.Enabled = True)
    '　　　：2005/09/06 (Tue) 14:52:46 S.Deguchi    処理見直し
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbOutKbn_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOutKbn.Change

        Try

            '@処理ｽｷｯﾌﾟﾌﾗｸﾞが"False：ｽｷｯﾌﾟしない"か
            If mblnProcSkipFlag = False Then

                '@-----------------------
                '@ 大工程ｺﾝﾎﾞの初期化
                '@-----------------------
                RemoveHandler cmbOpID.Change, AddressOf cmbOpID_Change
                cmbOpID.Clear()                         '内容ｸﾘｱ
                cmbOpID.ListIndex = 0                   'ﾘｽﾄｲﾝﾃﾞｯｸｽｸﾘｱ
                AddHandler cmbOpID.Change, AddressOf cmbOpID_Change

                '@表示区分ｺﾝﾎﾞにて「工程別」が選択されているか
                If cmbOutKbn.Text = CMstrProcess Then

                    '@大工程ｺﾝﾎﾞを有効にする
                    cmbOpID.Enabled = True
                Else
                    '@表示区分ｺﾝﾎﾞにて「工程別」が選択されていない場合

                    '@大工程ｺﾝﾎﾞを無効にする
                    cmbOpID.Enabled = False
                End If


                '@-----------------------
                '@ 小工程ｺﾝﾎﾞの初期化
                '@-----------------------
                RemoveHandler cmbStepID.Change, AddressOf cmbStepID_Change
                cmbStepID.Clear()                       '内容
                cmbStepID.ListIndex = 0                 'ﾘｽﾄｲﾝﾃﾞｯｸｽ
                AddHandler cmbStepID.Change, AddressOf cmbStepID_Change
                cmbStepID.Enabled = False               '無効

                '@各種ﾗﾍﾞﾙの初期化
                lblNowDate.Text = vbNullString          '情報取得日時
                lblLotCnt.Text = vbNullString           '該当件数

                '@最新取得ﾎﾞﾀﾝを無効にする
                cmdNowList.Enabled = False

                '@工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞにﾃﾞｰﾀがあるか
                If vsfStepLotList.Rows.Count <> 1 Then

                    '@=======================
                    '@ 工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ初期化処理
                    '@=======================
                    Call prvVsfStepLotList_Init()

                End If

                '@各種退避変数の初期化
                mstrKbn = vbNullString                  '表示区分
                mstrOpID = vbNullString                 '大工程
                mstrStepID = vbNullString               '小工程
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbOutKbn_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbOutKbn_CloseUp
    '機　能：[表示区分]ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/29 (Thu) 09:05:06 M.Matsuura
    '更新日：2009/08/27 (Thu) 12:41:54 N.Kojima
    '備　考：
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbOutKbn_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOutKbn.CloseUp

        Try

            '@=======================
            '@ 表示区分ｺﾝﾎﾞValidate処理
            '@=======================
            RemoveHandler cmbOutKbn.Validating, AddressOf cmbOutKbn_Validate
            Call cmbOutKbn_Validate(cmbOutKbn, New CancelEventArgs(True))
            AddHandler cmbOutKbn.Validating, AddressOf cmbOutKbn_Validate

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbOutKbn_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbOutKbn_Validate
    '機　能：[表示区分]ｺﾝﾎﾞ　Validate処理(ﾌｫｰｶｽﾛｽﾄ時入力ﾁｪｯｸ処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/04/26 (Mon) 17:11:50 M.Matsuura
    '更新日：2009/08/27 (Thu) 12:41:54 N.Kojima
    '備　考：
    '　　　：2004/10/13 (Wed) 10:58:04 N.Kasai      mblnCngOutKbnを追加し、再読み込みを防止
    '　　　：2004/11/05 (Fri) 14:47:48 T.Kitagawa　 ﾃﾝﾌﾟﾚｰﾄ表示対応(不具合№199)
    '　　　：2004/11/17 (Wed) 10:39:49 S.Deguchi    工程別を選択した場合,無条件に工程Comboが使用できる処理を修正」
    '　　　：2005/06/16 (Thu) 15:44:03 N.Kojima     ｺﾒﾝﾄｱｳﾄ行の削除(Timer関数記述部,ｺﾝﾎﾞ有効無効制御)
    '　　　：2005/09/06 (Tue) 14:53:40 S.Deguchi    処理見直し
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbOutKbn_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbOutKbn.Validating

        Dim lblnAns             As Boolean          '結果格納
        Dim ltypLotListReq      As OpLotList        '工程別ﾛｯﾄ一覧要求構造体
        Dim lblnNextCtrl        As Boolean          'NSYS Focus設定フラグ

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            ' NSYS フォーカス設定可能か判定
            If Me.ActiveControl.Name = cmbOutKbn.Name OrElse Me.ActiveControl.Name = cmbOpID.Name OrElse _
                (cmbOpID.Enabled = False AndAlso Me.ActiveControl.Name = cmbPD.Name ) Then
                ' 次コントロールがアクティブの場合
                lblnNextCtrl = True
            Else
                ' 次コントロール以外がアクティブの場合
                lblnNextCtrl = False
            End If

            '@選択表示区分が前回選択の表示区分と同じか
            If mstrKbn = cmbOutKbn.Text Then

                '@★ 各ｺﾝﾄﾛｰﾙのEnabled値がTrueかにより処理分岐 ★
                Select Case True

                    '@〓 大工程ｺﾝﾎﾞ 〓
                    Case cmbOpID.Enabled

                        If lblnNextCtrl AndAlso ActiveControl IsNot cmbOpID Then
                            Call pubSetFocus(cmbOpID)           'ﾌｫｰｶｽ：大工程ｺﾝﾎﾞ
                        End If

                    '@〓 小工程ｺﾝﾎﾞ 〓
                    Case cmbStepID.Enabled

                        If lblnNextCtrl AndAlso ActiveControl IsNot cmbStepID Then
                            Call pubSetFocus(cmbStepID)         'ﾌｫｰｶｽ：小工程ｺﾝﾎﾞ
                        End If

                    '@〓 機種ｺﾝﾎﾞ 〓
                    Case cmbPD.Enabled

                        If lblnNextCtrl AndAlso ActiveControl IsNot cmbPD Then
                            Call pubSetFocus(cmbPD)             'ﾌｫｰｶｽ：機種ｺﾝﾎﾞ
                        End If

                    '@〓 種別ｺﾝﾎﾞ 〓
                    Case cmbFlowClass.Enabled

                        If lblnNextCtrl AndAlso ActiveControl IsNot cmbFlowClass Then
                            Call pubSetFocus(cmbFlowClass)      'ﾌｫｰｶｽ：種別ｺﾝﾎﾞ
                        End If

                    '@〓 最新取得ﾎﾞﾀﾝ 〓
                    Case cmdNowList.Enabled

                        If lblnNextCtrl AndAlso ActiveControl IsNot cmdNowList Then
                            Call pubSetFocus(cmdNowList)        'ﾌｫｰｶｽ：最新取得ﾎﾞﾀﾝ
                        End If

                    '@〓 その他 〓
                    Case Else

                        If lblnNextCtrl AndAlso ActiveControl IsNot cmdClose Then
                            Call pubSetFocus(cmdClose)          'ﾌｫｰｶｽ：閉じるﾎﾞﾀﾝ
                        End If

                End Select

                Exit Sub
            End If

            '@各種配列・変数の初期化
            mtypWkLotList = Nothing                 '工程別ﾛｯﾄ一覧ﾘｽﾄ
            mlngWkLotCnt = 0                        '工程別ﾛｯﾄ一覧ﾘｽﾄ件数


            With cmbOutKbn

                '@★ 選択表示区分により処理分岐 ★
                Select Case .ListIndex

                    '@〓 0：工程別 〓
                    Case 0

                        '@最新取得ﾎﾞﾀﾝを無効にする
                        cmdNowList.Enabled = False

                        '@=======================
                        '@ 大工程取得処理
                        '@=======================
                        lblnAns = prvblnMasOpList_Sel()

                        '@大工程取得処理結果が"True：処理成功"か
                        If lblnAns = True Then

                            '@=======================
                            '@ 大工程ｺﾝﾎﾞ設定処理
                            '@=======================
                            Call prvCmbOpID_Disp()

                            '@★★ 大工程取得件数により処理分岐 ★★
                            Select Case mtypMasOpList.lngMasOpCnt

                                '@〓〓 0件 〓〓
                                Case 0

                                    '@退避用表示区分を初期化
                                    mstrKbn = vbNullString

                                    '@大工程ｺﾝﾎﾞを無効にする
                                    cmbOpID.Enabled = False

                                    '@表示区分にﾌｫｰｶｽを保持
                                    e.Cancel = True

                                '@〓〓 1件 〓〓
                                Case 1

                                    '@各種選択項目を退避
                                    mstrKbn = cmbOutKbn.Text        '表示区分
                                    mstrOpID = cmbOpID.Text         '大工程

                                    '@大工程ｺﾝﾎﾞを有効にする
                                    cmbOpID.Enabled = True

                                    '@=======================
                                    '@ 小工程取得処理
                                    '@=======================
                                    lblnAns = prvblnStepList_Sel

                                    '@小工程取得処理結果が"True：処理成功"か
                                    If lblnAns = True Then

                                        '@=======================
                                        '@ 小工程ｺﾝﾎﾞ設定処理
                                        '@=======================
                                        Call prvCmbStepID_Disp()

                                        '@小工程取得件数が0件か
                                        If mtypMasOpList.lngMasOpCnt = 0 Then

                                            '@小工程ｺﾝﾎﾞを無効にする
                                            cmbStepID.Enabled = False
                                        Else
                                            '@小工程ｺﾝﾎﾞを有効にする
                                            cmbStepID.Enabled = True
                                        End If

                                        '@選択小工程を退避
                                        mstrStepID = cmbStepID.Text

                                        '@=======================
                                        '@ 工程別ﾛｯﾄ一覧取得要求ﾃﾞｰﾀ作成処理(27：大工程・小工程指定/機種・種別全指定)
                                        '@=======================
                                        Call prvLotListReq_Proc(CPstrCD27, ltypLotListReq)

                                        '@=======================
                                        '@ 工程別ﾛｯﾄ一覧ﾘｽﾄ取得処理
                                        '@=======================
                                        lblnAns = prvblnLotOpList_Sel(ltypLotListReq)

                                        '@工程別ﾛｯﾄ一覧ﾘｽﾄ取得処理結果が"True：処理成功"か
                                        If lblnAns = True Then

                                            '@工程別ﾛｯﾄ一覧ﾘｽﾄのﾃﾞｰﾀ件数が1件以上あるか
                                            If mlngLotListCnt > 0 Then

                                                mlngWkLotCnt = mlngLotListCnt                                           '工程別ﾛｯﾄ一覧ﾘｽﾄ件数
                                                mtypWkLotList = New List(Of LotListList)(mtypLotList.typLotListList)    '工程別ﾛｯﾄ一覧ﾘｽﾄ

                                                '@=======================
                                                '@ 工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ表示処理
                                                '@=======================
                                                Call prvVsfStepLotList_Disp(mtypWkLotList, mlngWkLotCnt)

                                                If lblnNextCtrl AndAlso ActiveControl IsNot vsfStepLotList Then
                                                    '@工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞへﾌｫｰｶｽｾｯﾄ
                                                    Call pubSetFocus(vsfStepLotList)
                                                End If

                                            Else
                                                '@工程別ﾛｯﾄ一覧ﾘｽﾄのﾃﾞｰﾀ件数が0件の場合

                                                '@大工程ﾘｽﾄﾃﾞｰﾀ件数が0件か
                                                If mtypMasOpList.lngMasOpCnt = 0 Then

                                                    If lblnNextCtrl AndAlso ActiveControl IsNot cmbOpID Then
                                                        '@大工程ｺﾝﾎﾞへﾌｫｰｶｽｾｯﾄ
                                                        Call pubSetFocus(cmbOpID)
                                                    End If
                                                Else
                                                    If lblnNextCtrl AndAlso ActiveControl IsNot cmbStepID Then
                                                        '@小工程ｺﾝﾎﾞへﾌｫｰｶｽｾｯﾄ
                                                        Call pubSetFocus(cmbStepID)
                                                    End If
                                                End If
                                            End If

                                            '@各種ﾗﾍﾞﾙの表示
                                            lblNowDate.Text = Format$(Now, CPstrDateFormat)              '情報取得日時
                                            lblLotCnt.Text = Format(mlngWkLotCnt, CPstrDateFormatKanma)  '該当件数

                                            '@最新取得ﾎﾞﾀﾝを有効にする
                                            cmdNowList.Enabled = True

                                        Else
                                            '@工程別ﾛｯﾄ一覧ﾘｽﾄ取得処理結果が"False：処理失敗"の場合

                                            If lblnNextCtrl AndAlso ActiveControl IsNot cmbStepID Then
                                                '@小工程ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                                                Call pubSetFocus(cmbStepID)
                                            End If
                                            Exit Sub
                                        End If
                                    Else
                                        '@小工程取得処理結果が"False：処理失敗"の場合

                                        '@表示区分ｺﾝﾎﾞにﾌｫｰｶｽ保持
                                        e.Cancel = True
                                    End If

                                '@〓〓 その他(1件以上) 〓〓
                                Case Else

                                    '@選択表示区分を退避
                                    mstrKbn = cmbOutKbn.Text

                                    '@大工程ｺﾝﾎﾞを有効にする
                                    cmbOpID.Enabled = True

                                    If lblnNextCtrl AndAlso ActiveControl IsNot cmbOpID Then
                                        '@大工程ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                                        Call pubSetFocus(cmbOpID)
                                    End If

                            End Select

                        Else
                            '@大工程取得処理結果が"False：処理失敗"の場合

                            '@表示区分ｺﾝﾎﾞにﾌｫｰｶｽを保持
                            e.Cancel = True
                        End If

                    '@〓 1：全工程 or 2：ﾃﾝﾌﾟﾚｰﾄ 〓
                    Case 1, 2

                        '@各種ｺﾝﾄﾛｰﾙの制御
                        cmbOpID.Enabled = False         '大工程ｺﾝﾎﾞ：無効
                        cmbStepID.Enabled = False       '小工程ｺﾝﾎﾞ：無効
                        cmdNowList.Enabled = True       '最新取得ﾎﾞﾀﾝ：有効

                        '@★★ 表示区分により処理分岐 ★★
                        Select Case cmbOutKbn.ListIndex

                            '@〓〓 1：全工程 〓〓
                            Case 1

                                '@=======================
                                '@ 工程別ﾛｯﾄ一覧取得要求ﾃﾞｰﾀ作成処理(02：全工程指定)
                                '@=======================
                                Call prvLotListReq_Proc(CPstrCD02, ltypLotListReq)

                            '@〓〓 2：ﾃﾝﾌﾟﾚｰﾄ 〓〓
                            Case 2

                                '@=======================
                                '@ 工程別ﾛｯﾄ一覧取得要求ﾃﾞｰﾀ作成処理(3J：ﾃﾝﾌﾟﾚｰﾄ指定)
                                '@=======================
                                Call prvLotListReq_Proc(CPstrCD3J, ltypLotListReq)

                        End Select

                        '@=======================
                        '@ 工程別ﾛｯﾄ一覧ﾘｽﾄ取得
                        '@=======================
                        lblnAns = prvblnLotOpList_Sel(ltypLotListReq)

                        '@工程別ﾛｯﾄ一覧ﾘｽﾄ取得結果が"True：処理成功"か
                        If lblnAns = True Then

                            '@表示区分を退避
                            mstrKbn = cmbOutKbn.Text

                            '@工程別ﾛｯﾄ一覧ﾘｽﾄﾃﾞｰﾀ件数が1件以上か
                            If mlngLotListCnt > 0 Then

                                mlngWkLotCnt = mlngLotListCnt                                           '工程別ﾛｯﾄ一覧ﾘｽﾄ件数
                                mtypWkLotList = New List(Of LotListList)(mtypLotList.typLotListList)    '工程別ﾛｯﾄ一覧ﾘｽﾄ

                                '@=======================
                                '@ 工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ表示処理
                                '@=======================
                                Call prvVsfStepLotList_Disp(mtypWkLotList, mlngWkLotCnt)

                                If lblnNextCtrl AndAlso ActiveControl IsNot vsfStepLotList Then
                                    '@工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞへﾌｫｰｶｽｾｯﾄ
                                    Call pubSetFocus(vsfStepLotList)
                                End If
                            Else
                                '@工程別ﾛｯﾄ一覧ﾘｽﾄﾃﾞｰﾀ件数が0件の場合

                                '@表示区分にﾌｫｰｶｽを保持
                                e.Cancel = True
                            End If

                            '@各種ﾗﾍﾞﾙの表示
                            lblNowDate.Text = Format$(Now, CPstrDateFormat)              '情報取得日時
                            lblLotCnt.Text = Format(mlngWkLotCnt, CPstrDateFormatKanma)  '該当件数

                            '@最新取得ﾎﾞﾀﾝを有効にする
                            cmdNowList.Enabled = True

                        Else
                            '@工程別ﾛｯﾄ一覧ﾘｽﾄ取得結果が"False：処理失敗"の場合

                            '@表示区分退避変数を初期化
                            mstrKbn = vbNullString

                            '@表示区分にﾌｫｰｶｽを保持
                            e.Cancel = True
                            Exit Sub
                        End If

                    '@〓 その他(未選択) 〓
                    Case Else

                        '@表示区分にﾌｫｰｶｽを保持
                        e.Cancel = True

                End Select

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbOutKbn_Validate"
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
    '作成日：2004/04/26 (Mon) 17:11:50 M.Matsuura
    '更新日：2009/08/27 (Thu) 12:41:54 N.Kojima
    '備　考：
    '　　　：2005/09/06 (Tue) 16:53:03 S.Deguchi    処理見直し
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbOpID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOpID.Change

        Try

            '@処理ｽｷｯﾌﾟﾌﾗｸﾞが"False：ｽｷｯﾌﾟしない"か
            If mblnProcSkipFlag = False Then

                '@-----------------------
                '@ 小工程ｺﾝﾎﾞの初期化
                '@-----------------------
                RemoveHandler cmbStepID.Change, AddressOf cmbStepID_Change
                cmbStepID.Clear()                       '内容ｸﾘｱ
                cmbStepID.ListIndex = 0                 'ﾘｽﾄｲﾝﾃﾞｯｸｽｸﾘｱ
                AddHandler cmbStepID.Change, AddressOf cmbStepID_Change
                cmbStepID.Enabled = False               '非活性化

                '@各種ﾗﾍﾞﾙの初期化
                lblNowDate.Text = vbNullString          '情報取得日時
                lblLotCnt.Text = vbNullString           '該当件数

                '@最新取得ﾎﾞﾀﾝを無効にする
                cmdNowList.Enabled = False

                '@工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞにﾃﾞｰﾀがあるか
                If vsfStepLotList.Rows.Count <> 1 Then

                    '@=======================
                    '@ 工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ初期化処理
                    '@=======================
                    Call prvVsfStepLotList_Init()

                End If

                '@各種退避変数の初期化
                mstrOpID = vbNullString                 '大工程
                mstrStepID = vbNullString               '小工程

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
    '作成日：2004/04/29 (Thu) 17:18:50 M.Matsuura
    '更新日：2009/08/27 (Thu) 12:41:54 N.Kojima
    '備　考：
    '　　　：2004/10/13 (Wed) 11:00:12 N.Kasai      ﾌｫｰｶｽ移動の条件を変更(旧：If lblLotCnt.Caption = CPstrLotCnt0 Then)
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbOpID_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOpID.CloseUp

        Try

            '@大工程ｺﾝﾎﾞが選択されているか
            If cmbOpID.Text <> vbNullString Then

                '@=======================
                '@ 大工程ｺﾝﾎﾞValidate処理
                '@=======================
                RemoveHandler cmbOpID.Validating, AddressOf cmbOpID_Validate
                Call cmbOpID_Validate(cmbOpID, New CancelEventArgs(True))
                AddHandler cmbOpID.Validating, AddressOf cmbOpID_Validate

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
    '作成日：2004/04/26 (Mon) 17:11:50 M.Matsuura
    '更新日：2009/08/27 (Thu) 12:41:54 N.Kojima
    '備　考：
    '　　　：2004/10/13 (Wed) 11:02:51 N.Kasai      mblCngOpIDを追加し再読み込みを防止
    '　　　：2004/10/18 (Mon) 16:15:34 N.Kasai      0件ﾒｯｾｰｼﾞｺﾒﾝﾄｱｳﾄ
    '　　　：2004/11/17 (Wed) 10:11:43 S.Deguchi    0件の場合にはComboを使用不可にする処理を追加
    '　　　：2005/03/04 (Fri) 17:07:16 N.Kojima     引継ぎ処理追加に伴う修正(改善№512)
    '　　　：2005/03/09 (Wed) 16:34:07 N.Kasai      大工程、小工程退避を追加(大工程を変更した場合、端末情報登録されない為)
    '　　　：2005/06/20 (Mon) 10:30:40 N.Kojima     ｺﾒﾝﾄｱｳﾄ行の削除(処理状態ﾁｪｯｸ,大工程、小工程退避追加部,引継ぎ処理部)
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbOpID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbOpID.Validating

        Dim lblnAns             As Boolean          '結果格納
        Dim ltypLotListReq      As OpLotList        '工程ﾛｯﾄ一覧検索要求構造体
        Dim lblnNextCtrl        As Boolean          'NSYS Focus設定フラグ

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            ' NSYS フォーカス設定可能か判定
            If Me.ActiveControl.Name = cmbStepID.Name OrElse Me.ActiveControl.Name = cmbOpID.Name Then
                ' 次コントロールがアクティブの場合
                lblnNextCtrl = True
            Else
                ' 次コントロール以外がアクティブの場合
                lblnNextCtrl = False
            End If

            '@選択大工程が前回選択の大工程と同じか
            If mstrOpID = cmbOpID.Text Then

                '@★ 各ｺﾝﾄﾛｰﾙのEnabled値がTrueかにより処理分岐 ★
                Select Case True

                    '@〓 小工程ｺﾝﾎﾞ 〓
                    Case cmbStepID.Enabled

                        If lblnNextCtrl AndAlso ActiveControl IsNot cmbStepID Then
                            Call pubSetFocus(cmbStepID)         'ﾌｫｰｶｽ：小工程ｺﾝﾎﾞ
                        End If

                    '@〓 機種ｺﾝﾎﾞ 〓
                    Case cmbPD.Enabled

                        If lblnNextCtrl AndAlso ActiveControl IsNot cmbPD Then
                            Call pubSetFocus(cmbPD)             'ﾌｫｰｶｽ：機種ｺﾝﾎﾞ
                        End If

                    '@〓 種別ｺﾝﾎﾞ 〓
                    Case cmbFlowClass.Enabled

                        If lblnNextCtrl AndAlso ActiveControl IsNot cmbFlowClass Then
                            Call pubSetFocus(cmbFlowClass)      'ﾌｫｰｶｽ：種別ｺﾝﾎﾞ
                        End If

                    '@〓 最新取得ﾎﾞﾀﾝ 〓
                    Case cmdNowList.Enabled

                        If lblnNextCtrl AndAlso ActiveControl IsNot cmdNowList Then
                            Call pubSetFocus(cmdNowList)        'ﾌｫｰｶｽ：最新取得ﾎﾞﾀﾝ
                        End If

                    '@〓 その他 〓
                    Case Else

                        If lblnNextCtrl AndAlso ActiveControl IsNot cmdClose Then
                            Call pubSetFocus(cmdClose)          'ﾌｫｰｶｽ：閉じるﾎﾞﾀﾝ
                        End If

                End Select

                Exit Sub
            Else
                '@選択大工程が前回選択の大工程と異なる場合

                '@大工程が未選択か
                If cmbOpID.Text = vbNullString Then
                    Exit Sub
                End If
            End If

            '@各種配列・変数の初期化
            mtypWkLotList = Nothing                 '工程別ﾛｯﾄ一覧ﾘｽﾄ
            mlngWkLotCnt = 0                        '工程別ﾛｯﾄ一覧ﾘｽﾄ件数


            '@=======================
            '@ 小工程取得処理
            '@=======================
            lblnAns = prvblnStepList_Sel(cmbOpID.Text)

            '@小工程取得処理結果が"True：処理成功"か
            If lblnAns = True Then

                '@選択大工程を退避領域にｾｯﾄ
                mstrOpID = cmbOpID.Text

                '@=======================
                '@ 小工程ｺﾝﾎﾞ設定処理
                '@=======================
                Call prvCmbStepID_Disp()

                '@小工程ﾘｽﾄが0件か
                If mtypMasStepList.lngMasStepCnt = 0 Then

                    '@小工程ｺﾝﾎﾞを無効にする
                    cmbStepID.Enabled = False
                Else
                    '@小工程ｺﾝﾎﾞを有効にする
                    cmbStepID.Enabled = True
                End If

                '@選択小工程を退避領域へｾｯﾄ
                mstrStepID = cmbStepID.Text

                '@=======================
                '@ 工程別ﾛｯﾄ一覧取得要求ﾃﾞｰﾀ作成処理(27：大工程・小工程指定/機種・種別全指定)
                '@=======================
                Call prvLotListReq_Proc(CPstrCD27, ltypLotListReq)

                '@=======================
                '@ 工程別ﾛｯﾄ一覧ﾘｽﾄ取得
                '@=======================
                lblnAns = prvblnLotOpList_Sel(ltypLotListReq)

                '@工程別ﾛｯﾄ一覧ﾘｽﾄ取得結果が"True：処理成功"か
                If lblnAns = True Then

                    '@工程別ﾛｯﾄ一覧ﾘｽﾄﾃﾞｰﾀが1件以上あるか
                    If mlngLotListCnt > 0 Then

                        mlngWkLotCnt = mlngLotListCnt                                           '工程別ﾛｯﾄ一覧ﾘｽﾄ件数
                        mtypWkLotList = New List(Of LotListList)(mtypLotList.typLotListList)    '工程別ﾛｯﾄ一覧ﾘｽﾄ

                        '@=======================
                        '@ 工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ表示処理
                        '@=======================
                        Call prvVsfStepLotList_Disp(mtypWkLotList, mlngWkLotCnt)

                        If lblnNextCtrl AndAlso ActiveControl IsNot vsfStepLotList Then
                            '@工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞへﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(vsfStepLotList)
                        End If
                    Else
                        '@工程別ﾛｯﾄ一覧ﾘｽﾄﾃﾞｰﾀが0件の場合

                        '@大工程ｺﾝﾎﾞにﾌｫｰｶｽ保持
                        e.Cancel = True

                    End If

                    '@情報取得日時表示
                    lblNowDate.Text = Format$(Now, CPstrDateFormat)              '情報取得日時
                    lblLotCnt.Text = Format$(mlngWkLotCnt, CPstrDateFormatKanma) '該当件数

                    '@最新取得ﾎﾞﾀﾝを有効にする
                    cmdNowList.Enabled = True

                Else
                    '@工程別ﾛｯﾄ一覧ﾘｽﾄ取得結果が"False：処理失敗"の場合
                    
                    If lblnNextCtrl AndAlso ActiveControl IsNot cmbStepID Then
                        '@小工程ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmbStepID)
                    End If
                    Exit Sub
                End If
            Else
                '@小工程取得処理結果が"False：処理失敗"の場合

                '@大工程退避領域を初期化
                mstrOpID = vbNullString
                
                '@大工程ｺﾝﾎﾞにﾌｫｰｶｽ保持
                e.Cancel = True
                Exit Sub
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
    '作成日：2004/04/26 (Mon) 17:11:50 M.Matsuura
    '更新日：2009/08/27 (Thu) 12:41:54 N.Kojima
    '備　考：
    '　　　：2004/10/14 (Thu) 15:09:34 M.Miura　    ｶﾚﾝﾄ行検索ｷｰ初期化を追加
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbStepID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbStepID.Change

        Try

            '@処理ｽｷｯﾌﾟﾌﾗｸﾞが"False：ｽｷｯﾌﾟしない"か
            If mblnProcSkipFlag = False Then

                '@各種ﾗﾍﾞﾙの初期化
                lblNowDate.Text = vbNullString       '情報取得日時
                lblLotCnt.Text = vbNullString        '該当件数

                '@最新取得ﾎﾞﾀﾝを無効にする
                cmdNowList.Enabled = False

                '@工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞにﾃﾞｰﾀがあるか
                If vsfStepLotList.Rows.Count <> 1 Then

                    '@=======================
                    '@ 工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ初期化処理
                    '@=======================
                    Call prvVsfStepLotList_Init()

                End If

                '@小工程退避変数を初期化
                mstrStepID = vbNullString

                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                mtypChgSort.strKey = vbNullString

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
    '作成日：2004/04/26 (Mon) 17:11:50 M.Matsuura
    '更新日：2009/08/27 (Thu) 12:41:54 N.Kojima
    '備　考：
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbStepID_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbStepID.CloseUp

        Try

            '@=======================
            '@ 小工程ｺﾝﾎﾞValidate処理
            '@=======================
            RemoveHandler cmbStepID.Validating, AddressOf cmbStepID_Validate
            Call cmbStepID_Validate(cmbStepID, New CancelEventArgs(True))
            AddHandler cmbStepID.Validating, AddressOf cmbStepID_Validate

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
    '作成日：2004/04/26 (Mon) 17:11:50 M.Matsuura
    '更新日：2009/08/27 (Thu) 12:41:54 N.Kojima
    '備　考：
    '　　　：2004/10/18 (Mon) 16:16:27 N.Kasai      0件ﾒｯｾｰｼﾞｺﾒﾝﾄｱｳﾄ
    '　　　：2005/06/20 (Mon) 10:30:40 N.Kojima     ｺﾒﾝﾄｱｳﾄ行の削除(0件ﾒｯｾｰｼﾞ表示部)
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbStepID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbStepID.Validating

        Dim lblnAns             As Boolean          '結果格納
        Dim ltypLotListReq      As OpLotList        '工程別ﾛｯﾄ一覧要求構造体
        Dim lblnNextCtrl        As Boolean          'NSYS Focus設定フラグ

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            ' NSYS フォーカス設定可能か判定
            If Me.ActiveControl.Name = cmbPD.Name OrElse Me.ActiveControl.Name = cmbStepID.Name Then
                ' 次コントロールがアクティブの場合
                lblnNextCtrl = True
            Else
                ' 次コントロール以外がアクティブの場合
                lblnNextCtrl = False
            End If

            '@選択小工程が前回選択の小工程と同じか
            If mstrStepID = cmbStepID.Text Then

                '@★ 各ｺﾝﾄﾛｰﾙのEnabled値がTrueかにより処理分岐 ★
                Select Case True

                    '@〓 機種ｺﾝﾎﾞ 〓
                    Case cmbPD.Enabled

                        If lblnNextCtrl AndAlso ActiveControl IsNot cmbPD Then
                            Call pubSetFocus(cmbPD)             'ﾌｫｰｶｽ：機種ｺﾝﾎﾞ
                        End If

                    '@〓 種別ｺﾝﾎﾞ 〓
                    Case cmbFlowClass.Enabled

                        If lblnNextCtrl AndAlso ActiveControl IsNot cmbFlowClass Then
                            Call pubSetFocus(cmbFlowClass)      'ﾌｫｰｶｽ：種別ｺﾝﾎﾞ
                        End If

                    '@〓 最新取得ﾎﾞﾀﾝ 〓
                    Case cmdNowList.Enabled

                        If lblnNextCtrl AndAlso ActiveControl IsNot cmdNowList Then
                            Call pubSetFocus(cmdNowList)        'ﾌｫｰｶｽ：最新取得ﾎﾞﾀﾝ
                        End If

                    '@〓 その他 〓
                    Case Else

                        If lblnNextCtrl AndAlso ActiveControl IsNot cmdClose Then
                            Call pubSetFocus(cmdClose)          'ﾌｫｰｶｽ：閉じるﾎﾞﾀﾝ
                        End If

                End Select

                Exit Sub
            Else
                '@選択小工程が前回選択の小工程と異なる場合

                '@小工程が未選択か
                If cmbStepID.Text = vbNullString Then
                    Exit Sub
                End If
            End If

            '@各種配列・変数の初期化
            mtypWkLotList = Nothing                 '工程別ﾛｯﾄ一覧ﾘｽﾄ
            mlngWkLotCnt = 0                        '工程別ﾛｯﾄ一覧ﾘｽﾄ件数

            '@選択小工程を退避領域へｾｯﾄ
            mstrStepID = cmbStepID.Text


            '@=======================
            '@ 工程別ﾛｯﾄ一覧取得要求ﾃﾞｰﾀ作成処理(27：大工程・小工程指定/機種・種別全指定)
            '@=======================
            Call prvLotListReq_Proc(CPstrCD27, ltypLotListReq)

            '@=======================
            '@ 工程別ﾛｯﾄ一覧ﾘｽﾄ取得
            '@=======================
            lblnAns = prvblnLotOpList_Sel(ltypLotListReq)

            '@工程別ﾛｯﾄ一覧ﾘｽﾄ取得結果が"True：処理成功"か
            If lblnAns = True Then

                '@工程別ﾛｯﾄ一覧ﾘｽﾄﾃﾞｰﾀが1件以上あるか
                If mlngLotListCnt > 0 Then

                    mlngWkLotCnt = mlngLotListCnt                                           '工程別ﾛｯﾄ一覧ﾘｽﾄ件数
                    mtypWkLotList = New List(Of LotListList)(mtypLotList.typLotListList)    '工程別ﾛｯﾄ一覧ﾘｽﾄ

                    '@=======================
                    '@ 工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ表示処理
                    '@=======================
                    Call prvVsfStepLotList_Disp(mtypWkLotList, mlngWkLotCnt)

                    If lblnNextCtrl AndAlso ActiveControl IsNot vsfStepLotList Then
                        '@工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfStepLotList)
                    End If
                Else
                    '@工程別ﾛｯﾄ一覧ﾘｽﾄ取得結果が"False：処理失敗"の場合

                    '@小工程ｺﾝﾎﾞにﾌｫｰｶｽ保持
                    e.Cancel = True
                End If

                '@各種ﾗﾍﾞﾙの表示
                lblNowDate.Text = Format$(Now, CPstrDateFormat)              '情報取得日時
                lblLotCnt.Text = Format(mlngWkLotCnt, CPstrDateFormatKanma)  '該当件数

                '@最新取得ﾎﾞﾀﾝを有効にする
                cmdNowList.Enabled = True

            Else
                '@工程別ﾛｯﾄ一覧ﾘｽﾄ取得結果が"False：処理失敗"の場合
                
                '@小工程ｺﾝﾎﾞにﾌｫｰｶｽ保持
                e.Cancel = True
                Exit Sub
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

    '関数名：cmbPd_Change
    '機　能：[機種]ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/20 (Wed) 15:59:04 N.Kasai
    '更新日：2009/08/27 (Thu) 12:41:54 N.Kojima
    '備　考：
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbPd_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPd.Change

        Try

            '@処理ｽｷｯﾌﾟﾌﾗｸﾞが"False：ｽｷｯﾌﾟしない"か
            If mblnProcSkipFlag = False Then

                '@各種ﾗﾍﾞﾙの表示
                lblNowDate.Text = vbNullString       '情報取得日時
                lblLotCnt.Text = vbNullString        '該当件数

                '@=======================
                '@ 工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ初期化処理
                '@=======================
                Call prvVsfStepLotList_Init()

                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                mtypChgSort.strKey = vbNullString

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
    '作成日：2004/10/20 (Wed) 15:58:49 N.Kasai
    '更新日：2009/08/27 (Thu) 12:41:54 N.Kojima
    '備　考：
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbPd_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPd.CloseUp

        Try

            '@=======================
            '@ 機種ｺﾝﾎﾞValidate処理
            '@=======================
            RemoveHandler cmbPd.Validating, AddressOf cmbPd_Validate
            Call cmbPd_Validate(cmbPd, New CancelEventArgs(True))
            AddHandler cmbPd.Validating, AddressOf cmbPd_Validate

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
    '作成日：2004/10/20 (Wed) 15:58:37 N.Kasai
    '更新日：2009/08/27 (Thu) 12:41:54 N.Kojima
    '備　考：
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbPd_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPd.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@機種変更ﾌﾗｸﾞが"True：変更あり"か
            If mblnPDIDChgFlag = True Then

                '@最新取得ﾎﾞﾀﾝが有効か
                If cmdNowList.Enabled = True Then

                    '@=======================
                    '@ 最新取得ﾎﾞﾀﾝ処理
                    '@=======================
                    Call cmdNowList_Click(cmdNowList, EventArgs.Empty)

                End If

                '@機種変更ﾌﾗｸﾞの初期化
                mblnPDIDChgFlag = False
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
    '作成日：2004/10/20 (Wed) 15:58:13 N.Kasai
    '更新日：2009/08/27 (Thu) 12:41:54 N.Kojima
    '備　考：
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbFlowClass_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbFlowClass.Change

        Try

            '@処理ｽｷｯﾌﾟﾌﾗｸﾞが"False：ｽｷｯﾌﾟしない"か
            If mblnProcSkipFlag = False Then

                '@各種ﾗﾍﾞﾙの初期化
                lblNowDate.Text = vbNullString       '情報取得日時
                lblLotCnt.Text = vbNullString        '該当件数

                '@=======================
                '@ ﾛｯﾄ一覧表示情報初期化
                '@=======================
                Call prvVsfStepLotList_Init()

                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                mtypChgSort.strKey = vbNullString

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
    '作成日：2004/10/20 (Wed) 15:58:02 N.Kasai
    '更新日：2009/08/27 (Thu) 12:41:54 N.Kojima
    '備　考：
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbFlowClass_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbFlowClass.CloseUp

        Try

            '@=======================
            '@ 種別ｺﾝﾎﾞValidate処理
            '@=======================
            RemoveHandler cmbFlowClass.Validating, AddressOf cmbFlowClass_Validate
            Call cmbFlowClass_Validate(cmbFlowClass, New CancelEventArgs(True))
            AddHandler cmbFlowClass.Validating, AddressOf cmbFlowClass_Validate

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
    '作成日：2004/10/20 (Wed) 15:57:49 N.Kasai
    '更新日：2009/08/27 (Thu) 12:41:54 N.Kojima
    '備　考：
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbFlowClass_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbFlowClass.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@種別変更ﾌﾗｸﾞが"True：変更あり"か
            If mblnFlowClassChgFlag = True Then

                '@最新取得ﾎﾞﾀﾝが有効か
                If cmdNowList.Enabled = True Then

                    '@=======================
                    '@ 最新取得ﾎﾞﾀﾝ処理
                    '@=======================
                    Call cmdNowList_Click(cmdNowList, EventArgs.Empty)

                End If

                '@種別変更ﾌﾗｸﾞを初期化
                mblnFlowClassChgFlag = False
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

    '関数名：vsfStepLotList_AfterSort
    '機　能：[工程別ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ｿｰﾄ後処理
    '引　数：Col    ：列番号
    '　　　：Order  ：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/04/26 (Mon) 17:11:50 M.Matsuura
    '更新日：2009/08/27 (Thu) 12:41:54 N.Kojima
    '備　考：
    '　　　：2004/10/14 (Thu) 15:10:08 M.Miura      ｿｰﾄ順の格納を追加
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub vsfStepLotList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfStepLotList.AfterSort

        Try
           'NSYS ソート前の選択行が有効行でない場合、ヘッダを選択行とする
            If mintStepLotListRowBeforeSort <  vsfStepLotList.Rows.Fixed Then
                vsfStepLotList.Row = 0
            End If
            'NSYS ソート時のBeforeRowColChangeイベントの抑制を解除する
            RemoveHandler vsfStepLotList.BeforeRowColChange, AddressOf vsfStepLotList_BeforeRowColChange
            AddHandler vsfStepLotList.BeforeRowColChange, AddressOf vsfStepLotList_BeforeRowColChange
            'NSYS データ行がない場合は処理を抜ける
            If vsfStepLotList.Rows.Count <= vsfStepLotList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ構造体の設定
            With mtypChgSort
                Dim ltypChgSortListTmp As ChgSortList

                .lngCnt = .lngCnt + 1                       'ｿｰﾄﾘｽﾄｶｳﾝﾀ
                ltypChgSortListTmp.lngCol = e.Col           'ｿｰﾄ列番号
                ltypChgSortListTmp.lngOrder = e.Order       'ｿｰﾄ方法(昇順/降順)

                .typChgSortList.Add(ltypChgSortListTmp)
            End With

            '@=======================
            '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfAfterSort(vsfStepLotList, CMlngvsfStepLLRowTitle)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfStepLotList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfStepLotList_AfterUserResize
    '機　能：[工程別ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　列幅変更時処理
    '引　数：Row：行番号
    '　　　：Col：列番号
    '戻り値：なし
    '作成日：2004/10/14 (Thu) 15:10:41 M.Miura
    '更新日：2009/08/27 (Thu) 12:41:54 N.Kojima
    '備　考：
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub vsfStepLotList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfStepLotList.AfterResizeColumn, vsfStepLotList.AfterResizeRow

        Try

            '@列幅変更ﾌﾗｸﾞ(ﾕｰｻﾞｰﾘｻｲｽﾞﾌﾗｸﾞ)に"True：ﾕｰｻﾞｰﾘｻｲｽﾞあり"をｾｯﾄ
            mtypChgSort.blnChgWidth = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfStepLotList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfStepLotList_BeforeRowColChange
    '機　能：[工程別ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　行列変更前処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/04/26 (Mon) 17:11:50 M.Matsuura
    '更新日：2009/10/05 (Mon) 12:56:36 N.Kojima
    '備　考：
    '　　　：2004/10/14 (Thu) 15:14:54 M.Miura　    ｶﾚﾝﾄ行検索用のｷｰの格納を追加
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    '　　　：2009/10/05 (Mon) 12:56:36 N.Kojima     TFT/CFﾛｯﾄ紐付情報表示機能追加に伴う修正。(案件№03791)
    Private Sub vsfStepLotList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfStepLotList.BeforeRowColChange

        Dim OldRow      As Integer      'NSYS
        Dim NewRow      As Integer

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfStepLotList.Rows.Count <= vsfStepLotList.Rows.Fixed Then
                Return
            End If

            OldRow = e.OldRange.r1
            NewRow = e.NewRange.r1

            '@旧行と新行が違っていて、かつ新行がﾃﾞｰﾀ行か
            If OldRow <> NewRow And NewRow > 0 Then

                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ｷｬﾘｱID)
                mtypChgSort.strKey = vsfStepLotList.GetData(NewRow, CMlngvsfStepLLColCarrierID)
            End If


            With vsfStepLotList

                '@選択行がﾍｯﾀﾞｰ行以外か
                If NewRow > 0 Then

                    '@ﾛｯﾄ情報詳細表示ﾎﾞﾀﾝを有効にする
                    cmdLotDetail.Enabled = True

                    '@起動SBが組立(2A0)か
                    If pstrSBID = CPstrSBID2A0 Then

                        '@蒸着ﾊﾞｯﾁIDがNULL以外か(=蒸着工程流動済み)
                        If .GetData(NewRow, CMlngvsfStepLLColJBatchID) <> vbNullString Then

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

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfStepLotList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfStepLotList_BeforeSort
    '機　能：[工程別ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ｿｰﾄ前処理
    '引　数：Col    ：列番号
    '　　　：Order  ：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/04/26 (Mon) 17:11:50 M.Matsuura
    '更新日：2009/08/27 (Thu) 12:41:54 N.Kojima
    '備　考：
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub vsfStepLotList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfStepLotList.BeforeSort

        Try
            'NSYS ソート時はBeforeRowColChangeを抑制する
            RemoveHandler vsfStepLotList.BeforeRowColChange, AddressOf vsfStepLotList_BeforeRowColChange
            mintStepLotListRowBeforeSort = vsfStepLotList.Row 'NSYS ソート前の選択行を保持
            'NSYS データ行がない場合は処理を抜ける
            If vsfStepLotList.Rows.Count <= vsfStepLotList.Rows.Fixed Then
                Return
            End If

            '@=======================
            '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfBeforeSort(vsfStepLotList, CMlngvsfStepLLRowTitle)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfStepLotList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfStepLotList_EnterCell
    '機　能：[工程別ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/05/10 (Thu) 15:05:15 N.Kasai
    '更新日：2009/08/27 (Thu) 12:41:54 N.Kojima
    '備　考：
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub vsfStepLotList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfStepLotList.EnterCell

        Try

            With vsfStepLotList

                '@対象ﾃﾞｰﾀ0件か
                If .Rows.Count = 1 Then
                    Exit Sub
                End If

                '@=======================
                '@ ﾛｯﾄ情報詳細表示ﾎﾞﾀﾝ有効/無効制御処理
                '@=======================
                Call prvCmdLotDitailControl_Proc()

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfStepLotList_EnterCell"
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
    '作成日：2004/04/26 (Mon) 17:11:50 M.Matsuura
    '更新日：2009/08/27 (Thu) 12:41:54 N.Kojima
    '備　考：
    '　　　：2004/10/26 (Tue) 10:58:42 S.Deguchi    DoEventsﾌﾗｸﾞによる判別を追加(終了ｺﾏﾝﾄﾞｴﾗｰ対応)
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
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
            '@ 終了処理
            '@=======================
            Call publngEnd_Proc(CPstrKeyEN0200, ltypCommonInfo)

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

    '関数名：cmdLotDetail_Click
    '機　能：[ﾛｯﾄ情報詳細表示]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/11/07 (Wed) 11:09:28 N.Kasai
    '更新日：2009/08/27 (Thu) 12:41:54 N.Kojima
    '備　考：
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmdLotDetail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotDetail.Click

        Dim lstrTitle               As String       'ﾀｲﾄﾙ
        Dim lstrCarrierID           As String       'ｷｬﾘｱID

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

            With vsfStepLotList

                '@選択行がﾃﾞｰﾀ行か
                If .Row > 0 Then

                    '@ｷｬﾘｱIDを格納
                    lstrCarrierID = .GetData(.Row, CMlngvsfStepLLColCarrierID)
                Else
                    Exit Sub
                End If
            End With
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞを初期化(True：起動成功、False：起動中(起動失敗)or初期値)
            pblnFormLoad = False
            
            '@ﾌｫｰﾑ起動区分に"True：子画面起動"をｾｯﾄ
            pblnfrmxxCM00R0Kbn = True

            '@***********************
            '@ 引継ぎﾃﾞｰﾀ作成
            '@***********************
            With ptypCommonInfo

                .strCarrierId = lstrCarrierID       'ｷｬﾘｱID

                '@=======================
                '@ 機能関連情報取得
                '@=======================
                Call pubMenuItemCorrelation_Set(CPstrKeyEN01C0, lstrTitle)

                '@ﾛｯﾄ情報詳細画面のﾌｫｰﾑﾀｲﾄﾙ設定
                frmxxCM00R0.Instance = New frmxxCM00R0
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

                    '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"True：起動成功"をｾｯﾄ
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

                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"True：起動成功"をｾｯﾄ
                pblnFormLoad = True

                '@工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞにﾃﾞｰﾀがあるか
                If vsfStepLotList.Rows.Count > 1 Then

                    '@=======================
                    '@ ﾛｯﾄ情報詳細表示ﾎﾞﾀﾝ処理
                    '@=======================
                    Call cmdNowList_Click(cmdNowList, EventArgs.Empty)
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

    '関数名：cmdLotConnectedInfoDisp_Click
    '機　能：[TFT/CF紐付情報表示]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/10/05 (Mon) 09:45:13 N.Kojima
    '更新日：2014/12/02 (Tue) 13:58:37 H.Hayashi
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
        '@↓2014/11/26 (Wed) 18:11:35 H.Hayashi **************************************************
        '@    plngfrmxxCM00T0Kbn = CPlngNumOne
            plngfrmxxCM01B0Kbn = CPlngNumOne
        '@↑2014/11/26 (Wed) 18:11:35 H.Hayashi **************************************************

            '@***********************
            '@ 引継ぎ情報作成
            '@***********************
            With vsfStepLotList

                ptypCommonInfo.strCarrierId = .GetData(.Row, CMlngvsfStepLLColCarrierID)       'ｷｬﾘｱID
                ptypCommonInfo.strLotID = .GetData(.Row, CMlngvsfStepLLColLotID)               'ﾛｯﾄID
                ptypCommonInfo.strFlowClass = .GetData(.Row, CMlngvsfStepLLColFlowClass)       '流動区分
                ptypCommonInfo.strPdId = .GetData(.Row, CMlngvsfStepLLColPdID)                 '機種
                ptypCommonInfo.strNowST = .GetData(.Row, CMlngvsfStepLLColNowSt)               'ﾛｯﾄ状態
                ptypCommonInfo.strWfNum = .GetData(.Row, CMlngvsfStepLLColWfNum)               'WF枚数
                ptypCommonInfo.strChipQuantity = .GetData(.Row, CMlngvsfStepLLColChipNum)      'ﾁｯﾌﾟ数
                ptypCommonInfo.strOpID = .GetData(.Row, CMlngvsfStepLLColOpID)                 '大工程
                ptypCommonInfo.strStepID = .GetData(.Row, CMlngvsfStepLLColStepID)             '小工程
                ptypCommonInfo.strCfFlag = .GetData(.Row, CMlngvsfStepLLColCfFlag)             'CFﾌﾗｸﾞ
                ptypCommonInfo.strBatchId = .GetData(.Row, CMlngvsfStepLLColJBatchID)          '蒸着ﾊﾞｯﾁID

                pstrVaFlag = .GetData(.Row, CMlngvsfStepLLColVaFlag)                           '無機ﾌﾗｸﾞ
                pstrTpalClass = .GetData(.Row, CMlngvsfStepLLColTpalClass)                     'TPAL設定
            End With


            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ TFT/CFﾛｯﾄ紐付き情報画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
        '@↓2014/11/26 (Wed) 18:12:32 H.Hayashi **************************************************
        '@    Call Load(frmxxCM00T0)
            frmxxCM01B0.Instance = New frmxxCM01B0()
        '@↑2014/11/26 (Wed) 18:12:32 H.Hayashi **************************************************

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False：起動処理失敗"か
            If pblnFormLoad = False Then

                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
        '@↓2014/11/26 (Wed) 18:13:05 H.Hayashi **************************************************
        '@        Call Unload(frmxxCM00T0)
                frmxxCM01B0.Instance = Nothing
        '@↑2014/11/26 (Wed) 18:13:05 H.Hayashi **************************************************

                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
                pblnFormLoad = True

                Exit Sub
            End If

            '@閉じるﾎﾞﾀﾝを無効にする(閉じる連打で落ちるのを回避)
            cmdClose.Enabled = False

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ TFT/CFﾛｯﾄ紐付き情報画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
        '@↓2014/11/26 (Wed) 18:13:38 H.Hayashi **************************************************
        '@    Call frmxxCM00T0.Show(vbModal)
            frmxxCM01B0.Instance.ShowDialog(Me)
            frmxxCM01B0.Instance = Nothing
        '@↑2014/11/26 (Wed) 18:13:38 H.Hayashi **************************************************

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
        '@↓2014/11/26 (Wed) 18:14:13 H.Hayashi **************************************************
        '@    plngfrmxxCM00T0Kbn = CPlngNumZero
            plngfrmxxCM01B0Kbn = CPlngNumZero
        '@↑2014/11/26 (Wed) 18:14:13 H.Hayashi **************************************************

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

    '@↓2010/01/14 (Thu) 10:00:39 N.Kojima **************************************************
    '関数名：cmdCopy_Click
    '機　能：[ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2010/01/14 (Thu) 10:00:35 N.Kojima
    '更新日：2010/01/14 (Thu) 10:00:35
    '備　考：
    Private Sub cmdCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCopy.Click

        Dim llngRowCnt          As Integer      '行ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngColCnt          As Integer      '列ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrRET             As String       'ｺﾋﾟｰ文字列
        Dim lstrWk              As String       '文字列編集
 
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の条件の場合は処理抜け
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If


            '@Clipboardの内容を削除
            Clipboard.Clear

            '@一覧をｺﾋﾟｰする
            With vsfStepLotList

                '@行分ﾙｰﾌﾟ
                For llngRowCnt = 0 To .Rows.Count - 1

                    '@列分ﾙｰﾌﾟ
                    For llngColCnt = 0 To .Cols.Count - 1

                        '@対象列が非表示でないか
                        If .Cols(llngColCnt).Visible Then

                            '@文字列編集変数に値をｾｯﾄ
                            lstrWk = .GetDataDisplay(llngRowCnt, llngColCnt)

                            '@先頭の文字列が「-」「+」の場合は罫線文字に置き換える
                            If Mid$(lstrWk, 1, 1) = CPstrMinus Then
                                Mid$(lstrWk, 1, 1) = CPstrMinusWide
                            End If
                            If Mid$(lstrWk, 1, 1) = CPstrPlus Then
                                Mid$(lstrWk, 1, 1) = CPstrPlusWide
                            End If

                            '@最終列の場合Tabいらない
                            If llngColCnt = .Cols.Count - 1 Then
                                '@ｺﾋﾟｰ文字列作成
                                lstrRET = lstrRET & lstrWk
                            Else
                                '@ｺﾋﾟｰ文字列作成
                                lstrRET = lstrRET & lstrWk & vbTab
                            End If
                        End If
                    Next llngColCnt

                    '@ｺﾋﾟｰ文字列作成
                    lstrRET = lstrRET & vbCrLf

                Next llngRowCnt
            End With

            '@Clipboard にﾃｷｽﾄ文字列を挿入
            Clipboard.SetText(lstrRET)


            '@表示ﾒｯｾｰｼﾞ変換
            '@「"<TRM41I>$$クリップボードにコピーしました。(Ctrl＋Vキー で貼り付けてください)"」のﾒｯｾｰｼﾞ表示
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0041)
            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "cmdCopy_Click"                  '処理名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2010/01/14 (Thu) 10:00:39 N.Kojima **************************************************

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：prvFrmxxEN0200_Init
    '機　能：画面初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/26 (Mon) 17:11:50 M.Matsuura
    '更新日：2009/10/13 (Tue) 15:50:15 N.Kojima
    '備　考：
    '　　　：2004/10/26 (Tue) 15:39:52 S.Deguchi    DoEventsのChange処理実行ﾌﾗｸﾞの初期化を追加
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    '　　　：2009/10/13 (Tue) 15:50:15 N.Kojima     TFT/CFﾛｯﾄ紐付情報表示機能追加に伴う修正。(案件№03791)
    Private Sub prvFrmxxEN0200_Init()

        Dim lstrFormTitle       As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try

            '@=======================
            '@ 機能関連情報取得
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0200, lstrFormTitle)

            '@ﾌｫｰﾑｷｬﾌﾟｼｮﾝの設定
            Me.Text = lstrFormTitle

            'NSYS ﾌｫｰﾑの表示位置設定
            Me.Top = 0
            Me.Left = 0 - My.Settings.FormOffset
                
            '@各種ﾎﾞﾀﾝの初期化
            cmdNowList.Enabled = False              '最新取得
            cmdLotDetail.Enabled = False            'ﾛｯﾄ情報詳細表示
            cmdLotConnectedInfoDisp.Enabled = False 'TFT/CF紐付情報表示
        '@↓2010/01/14 (Thu) 10:16:28 N.Kojima **************************************************
            cmdCopy.Enabled = False                 'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
        '@↑2010/01/14 (Thu) 10:16:28 N.Kojima **************************************************

            '@基板(1A0)起動か
            If pstrSBID = CPstrSBID1A0 Then

                '@TFT/CF紐付情報表示ﾎﾞﾀﾝを非表示にする
                cmdLotConnectedInfoDisp.Visible = False
            Else
                '@基板(1A0)起動以外の場合(現在は組立(2A0)が対象)

                '@TFT/CF紐付情報表示ﾎﾞﾀﾝを表示する
                cmdLotConnectedInfoDisp.Visible = True
            End If

            '@各種ｺﾝﾎﾞの初期化
            RemoveHandler cmbOutKbn.Change, AddressOf cmbOutKbn_Change
            RemoveHandler cmbOpID.Change, AddressOf cmbOpID_Change
            RemoveHandler cmbStepID.Change, AddressOf cmbStepID_Change
            RemoveHandler cmbPD.Change, AddressOf cmbPD_Change
            RemoveHandler cmbFlowClass.Change, AddressOf cmbFlowClass_Change
            cmbOutKbn.Clear                     '表示区分
            cmbOpID.Clear                       '大工程
            cmbStepID.Clear                     '小工程
            cmbPD.Clear                         '機種
            cmbFlowClass.Clear                  '種別
            AddHandler cmbOutKbn.Change, AddressOf cmbOutKbn_Change
            AddHandler cmbOpID.Change, AddressOf cmbOpID_Change
            AddHandler cmbStepID.Change, AddressOf cmbStepID_Change
            AddHandler cmbPD.Change, AddressOf cmbPD_Change
            AddHandler cmbFlowClass.Change, AddressOf cmbFlowClass_Change

            '@各種退避用ﾓｼﾞｭｰﾙ変数の初期化
            mstrKbn = vbNullString              '表示区分退避用
            mstrOpID = vbNullString             '大工程退避用
            mstrStepID = vbNullString           '小工程退避用

            '@各種ﾌﾗｸﾞの初期化
            mblnPDIDChgFlag = False             '機種変更ﾌﾗｸﾞ
            mblnFlowClassChgFlag = False        '種別変更ﾌﾗｸﾞ

            '@閉じるﾎﾞﾀﾝのCausesValidationを設定(False：ﾌｫｰｶｽLost時に入力ﾁｪｯｸをしない)
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN0200_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfStepLotList_Init
    '機　能：工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/26 (Mon) 17:11:50 M.Matsuura
    '更新日：2009/10/05 (Mon) 12:56:36 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 17:28:10 T.Kitagawa   ﾀｲﾄﾙの自動列幅調整(不具合№1040)
    '　　　：2004/10/14 (Thu) 15:15:32 M.Miura　    列幅変更の判定を追加
    '　　　：2005/03/03 (Thu) 13:00:40 N.Kojima     ｱﾝﾛｰﾀﾞｷｬﾘｱID、代替番号列追加に伴う修正(改善№512)
    '　　　：2005/06/20 (Mon) 10:30:40 N.Kojima     ｺﾒﾝﾄｱｳﾄ行の削除
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2006/10/19 (Thu) 08:53:17 M.Miura      保/停区分の結合表示(案件№01565)
    '　　　：2007/05/02 (Wed) 15:37:20 N.Kasai      処理開始予実、ﾚｼﾋﾟID削除不要ｶﾗﾑ精査
    '　　　：2008/06/12 (Thu) 08:39:00 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    '　　　：2009/10/05 (Mon) 12:56:36 N.Kojima     蒸着ﾊﾞｯﾁID、CF/LP/VAﾌﾗｸﾞ、TPAL区分列追加に伴う修正。(案件№03791)
    Private Sub prvVsfStepLotList_Init(Optional ByVal lbnLocked As Boolean = True)

        Try

            With vsfStepLotList
                .Redraw = False

                .Clear(ClearFlags.Content)                      'ｸﾘｱ
                .Rows.Count = .Rows.Fixed                       '初期行数設定
                .Cols.Count = CMlngvsfStepLLColTpalClass + 1    '列設定

                '@ｸﾞﾘｯﾄﾞのﾀｲﾄﾙ設定
                Dim newStyle_title As CellStyle = .Styles.Add("CustomStyle_title")
                Dim cellRange As CellRange = .GetCellRange(CMlngvsfStepLLRowTitle, CMlngvsfStepLLColNo, CMlngvsfStepLLRowTitle, .Cols.Count - 1)
                newStyle_title.ForeColor = Color.Yellow                                                '文字色
                newStyle_title.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))  '背景色
                newStyle_title.Font = New Font(newStyle_title.Font.FontFamily, CType(CMlngvsfStepLLHFontSize, Single),newStyle_title.Font.Style,newStyle_title.Font.Unit) 'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                '@表示位置の設定
                newStyle_title.TextAlign = TextAlignEnum.CenterCenter
                newStyle_title.Trimming = StringTrimming.None 'NSYS ﾍｯﾀﾞは省略表示なしに設定
                cellRange.Style = newStyle_title


                '@ﾕｰｻﾞｰにより列幅が変更されていないか
                If mtypChgSort.blnChgWidth = False Then

                    '@列幅設定
                    .Cols(CMlngvsfStepLLColNo).Width = CMlngvsfStepLLColWNo
                    .Cols(CMlngvsfStepLLColOpID).Width = CMlngvsfStepLLColWOpID
                    .Cols(CMlngvsfStepLLColStepID).Width = CMlngvsfStepLLColWStepID
                    .Cols(CMlngvsfStepLLColNowSt).Width = CMlngvsfStepLLColWNowSt
                    .Cols(CMlngvsfStepLLColCarrierID).Width = CMlngvsfStepLLColWCarrierID
                    .Cols(CMlngvsfStepLLColLotID).Width = CMlngvsfStepLLColWLotID
                    .Cols(CMlngvsfStepLLColPdID).Width = CMlngvsfStepLLColWPdID
                    .Cols(CMlngvsfStepLLColFlowClass).Width = CMlngvsfStepLLColWFlowClass
                    .Cols(CMlngvsfStepLLColPriority).Width = CMlngvsfStepLLColWPriority
                    .Cols(CMlngvsfStepLLColLotPosition).Width = CMlngvsfStepLLColWLotPosition
                    .Cols(CMlngvsfStepLLColLotManagerName).Width = CMlngvsfStepLLColWLotManagerName
                    .Cols(CMlngvsfStepLLColWfNum).Width = CMlngvsfStepLLColWWfNum
                    .Cols(CMlngvsfStepLLColChipNum).Width = CMlngvsfStepLLColWChipNum
                    .Cols(CMlngvsfStepLLColPlanShipDate).Width = CMlngvsfStepLLColWPlanShipDate
                    .Cols(CMlngvsfStepLLColLotComments).Width = CMlngvsfStepLLColWLotComments
                    .Cols(CMlngvsfStepLLColUnLoaderCarrierID).Width = CMlngvsfStepLLColWUnLoaderCarrierID     'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                    .Cols(CMlngvsfStepLLColAltNumber).Width = CMlngvsfStepLLColWAltNumber                     '代替番号
                    .Cols(CMlngvsfStepLLColJBatchID).Width = CMlngvsfStepLLColWJBatchID                       '蒸着ﾊﾞｯﾁID
                    .Cols(CMlngvsfStepLLColCfFlag).Width = CMlngvsfStepLLColWCfFlag                           'CFﾌﾗｸﾞ
                    .Cols(CMlngvsfStepLLColLpFlag).Width = CMlngvsfStepLLColWLpFlag                           'LPﾌﾗｸﾞ
                    .Cols(CMlngvsfStepLLColVaFlag).Width = CMlngvsfStepLLColWVaFlag                           '無機ﾌﾗｸﾞ
                    .Cols(CMlngvsfStepLLColTpalClass).Width = CMlngvsfStepLLColWTpalClass                     'TPAL区分
                End If

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfStepLLColNo, CMstrvsfStepLLColTNo)                                   'No.
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfStepLLColOpID, CMstrvsfStepLLColTOpID)                               '大工程
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfStepLLColStepID, CMstrvsfStepLLColTStepID)                           '小工程
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfStepLLColNowSt, CMstrvsfStepLLColTNowSt)                             'ﾛｯﾄ状態
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfStepLLColCarrierID, CMstrvsfStepLLColTCarrierID)                     'ｷｬﾘｱID
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfStepLLColLotID, CMstrvsfStepLLColTLotID)                             'ﾛｯﾄID
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfStepLLColPdID, CMstrvsfStepLLColTPdID)                               '機種ID
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfStepLLColFlowClass, CMstrvsfStepLLColTFlowClass)                     '種別(流動区分)
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfStepLLColPriority, CMstrvsfStepLLColTPriority)                       '優先度
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfStepLLColLotPosition, CMstrvsfStepLLColTLotPosition)                 'ﾛｯﾄ位置
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfStepLLColLotManagerName, CMstrvsfStepLLColTLotManagerName)           'ﾛｯﾄ担当
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfStepLLColWfNum, CMstrvsfStepLLColTWfNum)                             'WF枚数
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfStepLLColChipNum, CMstrvsfStepLLColTChipNum)                             'ﾁｯﾌﾟ
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfStepLLColPlanShipDate, CMstrvsfStepLLColTPlanShipDate)               '送品予定日                              'ﾁｯﾌﾟ
                .SetData(CMlngvsfStepLLRowTitle, CMlngvsfStepLLColLotComments, CMstrvsfStepLLColTLotComments)                 'ﾛｯﾄｺﾒﾝﾄ有無

                '@非表示列の設定
                .Cols(CMlngvsfStepLLColUnLoaderCarrierID).Visible = False           'ｱﾝﾛｰﾀﾞｷｬﾘｱID列
                .Cols(CMlngvsfStepLLColAltNumber).Visible = False                   '代替番号列
                .Cols(CMlngvsfStepLLColJBatchID).Visible = False                    '蒸着ﾊﾞｯﾁID
                .Cols(CMlngvsfStepLLColCfFlag).Visible = False                      'CFﾌﾗｸﾞ
                .Cols(CMlngvsfStepLLColLpFlag).Visible = False                      'LPﾌﾗｸﾞ
                .Cols(CMlngvsfStepLLColVaFlag).Visible = False                      '無機ﾌﾗｸﾞ
                .Cols(CMlngvsfStepLLColTpalClass).Visible = False                   'TPAL区分

                '@基板(1A0)起動か
                If pstrSBID = CPstrSBID1A0 Then
                
                    '@基板起動の場合は"機種"列を非表示にする
                    .Cols(CMlngvsfStepLLColPdID).Visible = False
                End If

                .Rows(CMlngvsfStepLLRowTitle).Height = CMlngvsfStepLLHHeight        'ﾍｯﾀﾞｰの高さ
                .Cols.Frozen = CMlngvsfFrozenCols                                   '固定列の設定(7)
                .AllowResizing = AllowResizingEnum.Columns                          'ﾏｳｽによる列ｻｲｽﾞ変更可

                '@ﾕｰｻﾞｰにより列幅が変更されていないか
                If mtypChgSort.blnChgWidth = False Then
                    ' NSYS AllowMergingの設定がNone以外だとAutoSizeColの動作が異なるためNoneに設定
                    .AllowMerging = AllowMergingEnum.None

                    '@自動で列幅を調整
                    '.AutoSizeMode = flexAutoSizeColWidth
                    .AutoSizeCols(CMlngvsfStepLLColKb, .Cols.Count - 1, 6)
                End If

                '@各種ﾗﾍﾞﾙの初期化
                lblNowDate.Text = vbNullString       '情報取得日時
                lblLotCnt.Text = vbNullString        '該当件数

                '@[ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ]を無効にする
                cmdCopy.Enabled = False

                .Redraw = True

                '@ｸﾞﾘｯﾄﾞを無効にする
                If lbnLocked Then
                    .Enabled = False
                End If

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfStepLotList_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfStepLotList_Disp
    '機　能：工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ表示処理
    '引　数：ltypLotList    ：格納ﾃﾞｰﾀ
    '　　　：ltypLotListCnt ：ﾃﾞｰﾀ件数
    '戻り値：なし
    '作成日：2004/04/26 (Mon) 17:11:50 M.Matsuura
    '更新日：2009/12/01 (Tue) 14:30:00 H.Hayashi
    '備　考：2004/08/25 (Wed) 11:23:51 M.Miura      ｸﾞﾘｯﾄﾞ表示に時間がかかる場合に「SetFocus」でｴﾗｰになるのを
    '                                       　      回避する為、「DoEvents」を追加
    '　　　：2004/09/09 (Thu) 14:08:16 Y.Yamagishi  時間制限を分表示に変更(不具合改善№693)
    '　　　：2004/09/22 (Wed) 10:42:40 S.Deguchi    ｺﾒﾝﾄの表示をありなしへ変更
    '　　　：2004/09/26 (Sun) 14:10:45 S.Deguchi    ｺﾒﾝﾄ有無表記の判別を"あり"かそれ以外に変更
    '　　　：2004/09/30 (Thu) 16:40:22 S.Deguchi    時間制限の部分を隠す(3秒越え対応)
    '　　　：2004/10/14 (Thu) 15:16:41 M.Miura　    列幅変更の判定、ｿｰﾄ順の保持表示、ｶﾚﾝﾄ行設定を追加
    '　　　：2004/10/18 (Mon) 13:51:31 N.Kasai      ﾘﾜｰｸﾌﾗｸﾞ追加
    '　　　：2004/10/19 (Tue) 17:34:59 N.Kasai      応答ﾀｸﾞにTEMPLATE_SEQ_NUMを追加
    '　　　：2004/10/20 (Wed) 15:40:26 N.Kasai      小工程ｾﾙﾏｰｼﾞｺﾒﾝﾄｱｳﾄ
    '　　　：2004/10/26 (Tue) 12:01:50 S.Deguchi    DoEvents前後に画面の有効/無効処理を追加(終了ｺﾏﾝﾄﾞｴﾗｰ対応)
    '　　　：2004/11/01 (Mon) 11:19:27 N.Kasai      全工程又は工程別で大工程のみ選択の場合は「TEMPLATE_TRAVELER」の表示を行う(№109)
    '　　　：2004/11/05 (Fri) 14:38:24 T.Kitagawa   ﾃﾝﾌﾟﾚｰﾄ表示対応(不具合№199)
    '　　　：2005/03/03 (Thu) 13:01:41 N.Kojima     引継ぎ機能追加に伴う修正(改善№512)
    '　　　：2005/04/20 (Wed) 17:19:55 N.Kojima     ﾀﾞﾐｰは「薄ｵﾚﾝｼﾞ(橙)」で表示するように改善。(不具合改善№706)
    '　　　：2005/06/15 (Wed) 18:34:06 N.Kojima     最終更新日時のﾌｫｰﾏｯﾄを統一(不具合№430)
    '　　　：2005/06/20 (Mon) 10:30:40 N.Kojima     ｺﾒﾝﾄｱｳﾄ行の削除(ｱﾝﾛｰﾀﾞ表示部等)
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2005/11/04 (Fri) 14:57:09 S.Deguchi    不具合№3236の対応で,日時ﾌｫｰﾏｯﾄを"MM/DD HH:MM"とする
    '　　　：2006/10/19 (Thu) 08:53:17 M.Miura      保/停区分の結合表示(案件№01565)
    '　　　：2007/07/31 (Tue) 08:43:39 N.Kasai      H/W,L/U装置,処理中のｷｬﾘｱ表示変更(№02093)
    '　　　：2008/06/12 (Thu) 08:40:32 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/02/25 (Wed) 11:32:22 N.Kojima     起動SBが組立、かつ送品先が"7x0：ﾁｯﾌﾟ品"だったらﾌｫﾝﾄの色を青にする。(案件№03402)
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    '　　　：2009/10/05 (Mon) 12:56:36 N.Kojima     蒸着ﾊﾞｯﾁID、CF/LP/VAﾌﾗｸﾞ、TPAL区分列追加に伴う修正。(案件№03791)
    '　　　：2009/12/01 (Tue) 14:30:00 H.Hayashi    ﾁｯﾌﾟ品判定ﾛｼﾞｯｸ部変更。(案件No.03810)
    Private Sub prvVsfStepLotList_Disp(ByRef ltypLotList As List(Of LotListList), ByVal ltypLotListCnt As Integer)

        Dim llngDoCnt           As Integer      'ｶｳﾝﾄ
        Dim llngCnt             As Integer      'ｶｳﾝﾄ

        Try
            'NSYS 不要イベント発生抑止
            RemoveHandler vsfStepLotList.BeforeRowColChange, AddressOf vsfStepLotList_BeforeRowColChange

            '@=======================
            '@ 工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ初期化処理
            '@=======================
            Call prvVsfStepLotList_Init(False)

            '@工程別ﾛｯﾄﾃﾞｰﾀが0件か
            If ltypLotListCnt = 0 Then

                '@=======================
                '@ ﾛｯﾄ情報詳細表示ﾎﾞﾀﾝ有効/無効制御処理
                '@=======================
                Call prvCmdLotDitailControl_Proc()

                vsfStepLotList.Enabled = False
                Exit Sub
            End If

            '@工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞの設定
            With vsfStepLotList

                .Redraw = False                     '描画ﾛｯｸ
                .Rows.Count = ltypLotListCnt + 1    '行数設定

                'NSYS Style定義
                Dim newStyle_BackColor_CMlngVbColorWhite_ForeColor_CMlngVbColorBlack As CellStyle = _
                    .Styles.Add("CustomStyle_BackColor_CMlngVbColorWhite_ForeColor_CMlngVbColorBlack")
                Dim newStyle_BackColor_CPlngLColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngLColor")
                Dim newStyle_BackColor_CPlngRColor As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngRColor")
                Dim newStyle_BackColor_CPlngHoldLotColor_ForeColor_CMlngVbColorBlack As CellStyle = _
                    .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor_ForeColor_CMlngVbColorBlack")
                Dim newStyle_BackColor_CPlngVbColorOrange_ForeColor_CMlngVbColorBlack As CellStyle = _
                    .Styles.Add("CustomStyle_BackColor_CPlngVbColorOrange_ForeColor_CMlngVbColorBlack")
                Dim newStyle_BackColor_CPlngGridGray As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")

                Dim cellRange As CellRange
                    
                '@ｶｳﾝﾀの初期化
                llngDoCnt = 1

                Do While .Rows.Count > llngDoCnt

                    .SetData(llngDoCnt, CMlngvsfStepLLColNo, llngDoCnt)                               '№
                    .SetData(llngDoCnt, CMlngvsfStepLLColOpID, ltypLotList(llngDoCnt-1).strOpID)      '大工程
                    .SetData(llngDoCnt, CMlngvsfStepLLColStepID, ltypLotList(llngDoCnt-1).strStepID)  '小工程
                    .SetData(llngDoCnt, CMlngvsfStepLLColNowSt, ltypLotList(llngDoCnt-1).strNowST)    'ﾛｯﾄ現在状態

                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULL以外、かつﾛｯﾄ状態が「後処理」か
                    If ltypLotList(llngDoCnt-1).strToCarrierId <> vbNullString And _
                        ltypLotList(llngDoCnt-1).strNowST = CPstrAfterProgressSt Then

                        '@ｷｬﾘｱID列にｱﾝﾛｰﾀﾞｷｬﾘｱIDをｾｯﾄ
                        .SetData(llngDoCnt, CMlngvsfStepLLColCarrierID, _
                            ltypLotList(llngDoCnt-1).strToCarrierId)                                'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                    Else
                        '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULL、またはﾛｯﾄ状態が「後処理」以外か

                        '@ｷｬﾘｱID列にﾛｰﾀﾞｷｬﾘｱIDをｾｯﾄ
                        .SetData(llngDoCnt, CMlngvsfStepLLColCarrierID, _
                            ltypLotList(llngDoCnt-1).strCarrierId)                                  'ﾛｰﾀﾞｷｬﾘｱID
                    End If

                    .SetData(llngDoCnt, CMlngvsfStepLLColLotID, _
                        ltypLotList(llngDoCnt-1).strLotID)                                          'ﾛｯﾄID

                    .SetData(llngDoCnt, CMlngvsfStepLLColPdID, _
                        ltypLotList(llngDoCnt-1).strPdId)                                           '機種ID

                    .SetData(llngDoCnt, CMlngvsfStepLLColFlowClass, _
                        ltypLotList(llngDoCnt-1).strFlowClass)                                      '種別

                    .SetData(llngDoCnt, CMlngvsfStepLLColPriority, _
                        ltypLotList(llngDoCnt-1).strLotPriority)                                    '優先度

                    .SetData(llngDoCnt, CMlngvsfStepLLColLotPosition, _
                        ltypLotList(llngDoCnt-1).strCurrentPositionName)                            'ﾛｯﾄ位置

                    .SetData(llngDoCnt, CMlngvsfStepLLColLotManagerName, _
                        ltypLotList(llngDoCnt-1).strEngEmpName)                                     'ﾛｯﾄ担当

                    .SetData(llngDoCnt, CMlngvsfStepLLColWfNum, _
                        ltypLotList(llngDoCnt-1).strWfNum)                                          'WF枚数

                    If IsNumeric(ltypLotList(llngDoCnt-1).strChipQuantity) Then
                        .SetData(llngDoCnt, CMlngvsfStepLLColChipNum, _
                            Format$(CInt(ltypLotList(llngDoCnt-1).strChipQuantity), CPstrCFKnmaFormat)) 'ﾁｯﾌﾟ数
                    Else
                        .SetData(llngDoCnt, CMlngvsfStepLLColChipNum, _
                            ltypLotList(llngDoCnt-1).strChipQuantity)                               'ﾁｯﾌﾟ数
                    End If

                    If IsDate(ltypLotList(llngDoCnt-1).strPlanShipDate) Then
                        .SetData(llngDoCnt, CMlngvsfStepLLColPlanShipDate, _
                            Format$(CDate(ltypLotList(llngDoCnt-1).strPlanShipDate), CPstrDateTimeYMD)) '送品予定日
                    Else
                        .SetData(llngDoCnt, CMlngvsfStepLLColPlanShipDate, _
                            ltypLotList(llngDoCnt-1).strPlanShipDate)                               '送品予定日
                    End If

                    '@ﾛｯﾄｺﾒﾝﾄ有無ﾌﾗｸﾞが"あり"か
                    If ltypLotList(llngDoCnt-1).strLotCommentsFlg = CPstrAriFlg Then

                        .SetData(llngDoCnt, CMlngvsfStepLLColLotComments, CPstrAriFlg)              '"あり"
                    Else
                        .SetData(llngDoCnt, CMlngvsfStepLLColLotComments, vbNullString)             '"なし"
                    End If

                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULL以外か
                    If ltypLotList(llngDoCnt-1).strToCarrierId <> vbNullString Then

                        .SetData(llngDoCnt, CMlngvsfStepLLColUnLoaderCarrierID, _
                            ltypLotList(llngDoCnt-1).strToCarrierId)                                'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                    End If

                    .SetData(llngDoCnt, CMlngvsfStepLLColAltNumber, _
                        ltypLotList(llngDoCnt-1).strAltNumber)                                      '代替番号

                    .SetData(llngDoCnt, CMlngvsfStepLLColJBatchID, _
                            ltypLotList(llngDoCnt-1).strJBatchId)                                   '蒸着ﾊﾞｯﾁID

                    .SetData(llngDoCnt, CMlngvsfStepLLColCfFlag, _
                            ltypLotList(llngDoCnt-1).strCfFlag)                                     'CFﾌﾗｸﾞ

                    .SetData(llngDoCnt, CMlngvsfStepLLColLpFlag, _
                            ltypLotList(llngDoCnt-1).strLpFlag)                                     'LPﾌﾗｸﾞ

                    .SetData(llngDoCnt, CMlngvsfStepLLColVaFlag, _
                            ltypLotList(llngDoCnt-1).strVaFlag)                                     '無機ﾌﾗｸﾞ

                    .SetData(llngDoCnt, CMlngvsfStepLLColTpalClass, _
                            ltypLotList(llngDoCnt-1).strTpalClass)                                  'TPAL区分

                     cellRange = .GetCellRange(llngDoCnt, CMlngvsfStepLLColTitle, llngDoCnt, .Cols.Count - 1)
                    '@背景色を設定
                    newStyle_BackColor_CMlngVbColorWhite_ForeColor_CMlngVbColorBlack.BackColor = _
                        ColorTranslator.FromWin32(Convert.ToInt32(CMlngVbColorWhite)) '白色

                    '@文字色を設定
                    newStyle_BackColor_CMlngVbColorWhite_ForeColor_CMlngVbColorBlack.ForeColor = _
                        ColorTranslator.FromWin32(Convert.ToInt32(CMlngVbColorBlack)) '黒色
                    cellRange.Style = newStyle_BackColor_CMlngVbColorWhite_ForeColor_CMlngVbColorBlack


                    '@-----------------------------------------------
                    '@ 背景色/文字色の設定
                    '@　優先順位：保留/停止 > ﾀﾞﾐｰﾛｯﾄ > L/R
                    '@-----------------------------------------------
                    '@★ 液晶方向により処理分岐(L/R色分け処理) ★
                    Select Case ltypLotList(llngDoCnt-1).strLcDirection

                        '@〓 L 〓
                        Case CPstrPDIDL

                            '@背景色変更(0、1列目)
                            newStyle_BackColor_CPlngLColor.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngLColor))
                            cellRange = .GetCellRange(llngDoCnt, CMlngvsfStepLLColTitle, llngDoCnt, CMlngvsfStepLLColKb)
                            cellRange.Style = newStyle_BackColor_CPlngLColor                        'Lｶﾗｰ(水色)

                            '@表示区分が「全工程」または「ﾃﾝﾌﾟﾚｰﾄ」か
                            If cmbOutKbn.ListIndex = 1 Or cmbOutKbn.ListIndex = 2 Then

                                '@背景色変更(3列目～最終列)
                                newStyle_BackColor_CPlngLColor.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngLColor))
                                cellRange = .GetCellRange(llngDoCnt, CMlngvsfCellPaintColorStart - 1, llngDoCnt, .Cols.Count - 1)
                                cellRange.Style = newStyle_BackColor_CPlngLColor                    'Lｶﾗｰ(水色)

                            Else
                                '@表示区分が「工程別」の場合

                                '@背景色変更(4列目～最終列)
                                newStyle_BackColor_CPlngLColor.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngLColor))
                                cellRange = .GetCellRange(llngDoCnt, CMlngvsfCellPaintColorStart, llngDoCnt, .Cols.Count - 1)
                                cellRange.Style = newStyle_BackColor_CPlngLColor                    'Lｶﾗｰ(水色)

                            End If


                        '@〓 R 〓
                        Case CPstrPDIDR

                            '@背景色変更(0、1列目)
                            newStyle_BackColor_CPlngRColor.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngRColor))
                            cellRange = .GetCellRange(llngDoCnt, CMlngvsfStepLLColTitle, llngDoCnt, CMlngvsfStepLLColKb)
                            cellRange.Style = newStyle_BackColor_CPlngRColor                        'Rｶﾗｰ(ﾋﾟﾝｸ)

                            '@表示区分が「全工程」または「ﾃﾝﾌﾟﾚｰﾄ」か
                            If cmbOutKbn.ListIndex = 1 Or cmbOutKbn.ListIndex = 2 Then

                                '@背景色変更(3列目～最終列)
                                newStyle_BackColor_CPlngRColor.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngRColor))
                                cellRange = .GetCellRange(llngDoCnt, CMlngvsfCellPaintColorStart - 1, llngDoCnt, .Cols.Count - 1)
                                cellRange.Style = newStyle_BackColor_CPlngRColor                    'Rｶﾗｰ(ﾋﾟﾝｸ)

                            Else
                                '@表示区分が「工程別」の場合

                                '@背景色変更(4列目～最終列)
                                newStyle_BackColor_CPlngRColor.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngRColor))
                                cellRange = .GetCellRange(llngDoCnt, CMlngvsfCellPaintColorStart, llngDoCnt, .Cols.Count - 1)
                                cellRange.Style = newStyle_BackColor_CPlngRColor                    'Rｶﾗｰ(ﾋﾟﾝｸ)

                            End If

                    End Select


                    '@種別の2文字目が"D：ﾀﾞﾐｰ"か
                    If Trim$(Strings.Right(.GetData(llngDoCnt, CMlngvsfStepLLColFlowClass), 1)) = CPstrFlowDummy Then

                        cellRange = .GetCellRange(llngDoCnt, CMlngvsfStepLLColTitle, llngDoCnt, CMlngvsfStepLLColKb)
                        '@背景色変更(0、1列目)
                        newStyle_BackColor_CPlngVbColorOrange_ForeColor_CMlngVbColorBlack.BackColor = _
                            ColorTranslator.FromWin32(Convert.ToInt32(CPlngVbColorOrange))          'ﾀﾞﾐｰLotｶﾗｰ

                        '@文字色変更(0、1列目)
                        newStyle_BackColor_CPlngVbColorOrange_ForeColor_CMlngVbColorBlack.ForeColor = _
                            ColorTranslator.FromWin32(Convert.ToInt32(CMlngVbColorBlack))           '黒色
                        cellRange.Style = newStyle_BackColor_CPlngVbColorOrange_ForeColor_CMlngVbColorBlack

                        '@表示区分が「全工程」または「ﾃﾝﾌﾟﾚｰﾄ」か
                        If cmbOutKbn.ListIndex = 1 Or cmbOutKbn.ListIndex = 2 Then

                            cellRange = .GetCellRange(llngDoCnt, CMlngvsfCellPaintColorStart - 1, llngDoCnt, .Cols.Count - 1)
                            '@背景色変更(3列目～最終列)
                            newStyle_BackColor_CPlngVbColorOrange_ForeColor_CMlngVbColorBlack.BackColor = _
                                ColorTranslator.FromWin32(Convert.ToInt32(CPlngVbColorOrange))      'ﾀﾞﾐｰLotｶﾗｰ

                            '@文字色変更(3列目～最終列)
                            newStyle_BackColor_CPlngVbColorOrange_ForeColor_CMlngVbColorBlack.ForeColor = _
                                ColorTranslator.FromWin32(Convert.ToInt32(CMlngVbColorBlack))       '黒色
                            cellRange.Style = newStyle_BackColor_CPlngVbColorOrange_ForeColor_CMlngVbColorBlack

                        Else
                            '@表示区分が「工程別」の場合

                            cellRange = .GetCellRange(llngDoCnt, CMlngvsfCellPaintColorStart, llngDoCnt, .Cols.Count - 1)
                            '@背景色変更(4列目～最終列)
                            newStyle_BackColor_CPlngVbColorOrange_ForeColor_CMlngVbColorBlack.BackColor = _
                                ColorTranslator.FromWin32(Convert.ToInt32(CPlngVbColorOrange))      'ﾀﾞﾐｰLotｶﾗｰ

                            '@文字色変更(4列目～最終列)
                            newStyle_BackColor_CPlngVbColorOrange_ForeColor_CMlngVbColorBlack.ForeColor = _
                                ColorTranslator.FromWin32(Convert.ToInt32(CMlngVbColorBlack))       '黒色
                            cellRange.Style = newStyle_BackColor_CPlngVbColorOrange_ForeColor_CMlngVbColorBlack

                        End If
                    End If


                    '@保留/停止ﾌﾗｸﾞが"1：保留/停止"か
                    If ltypLotList(llngDoCnt-1).strLotHoldFlag = CMstrLotHoldFlgOn Or _
                        ltypLotList(llngDoCnt-1).strLotStopFlag = CMstrLotStopFlgOn Then

                        cellRange = .GetCellRange(llngDoCnt, CMlngvsfStepLLColTitle, llngDoCnt, CMlngvsfStepLLColKb)
                        '@背景色変更(0、1列目)
                        newStyle_BackColor_CPlngHoldLotColor_ForeColor_CMlngVbColorBlack.BackColor = _
                            ColorTranslator.FromWin32(Convert.ToInt32(CPlngHoldLotColor))           '保留Lotｶﾗｰ

                        '@文字色変更(0、1列目)
                        newStyle_BackColor_CPlngHoldLotColor_ForeColor_CMlngVbColorBlack.ForeColor = _
                            ColorTranslator.FromWin32(Convert.ToInt32(CMlngVbColorBlack))           '黒色
                        cellRange.Style = newStyle_BackColor_CPlngHoldLotColor_ForeColor_CMlngVbColorBlack

                        '@★ 保留/停止ﾌﾗｸﾞが"1"かにより処理分岐 ★
                        Select Case CMstrLotHoldFlgOn

                            '@〓 保留ﾌﾗｸﾞ 〓
                            Case ltypLotList(llngDoCnt-1).strLotHoldFlag

                                '@=======================
                                '@ 区分列表示処理(※区分列に"保"を表示)
                                '@=======================
                                .SetData(llngDoCnt, CMlngvsfStepLLColKb, _
                                    pubstrColKbn_Set(.GetData(llngDoCnt, CMlngvsfStepLLColKb), CMstrHo))

                            '@〓 停止ﾌﾗｸﾞ 〓
                            Case ltypLotList(llngDoCnt-1).strLotStopFlag

                                '@=======================
                                '@ 区分列表示処理(※区分列に"停"を表示)
                                '@=======================
                                .SetData(llngDoCnt, CMlngvsfStepLLColKb, _
                                    pubstrColKbn_Set(.GetData(llngDoCnt, CMlngvsfStepLLColKb), CMstrTei))

                        End Select

                        '@表示区分が「全工程」または「ﾃﾝﾌﾟﾚｰﾄ」か
                        If cmbOutKbn.ListIndex = 1 Or cmbOutKbn.ListIndex = 2 Then

                            cellRange = .GetCellRange(llngDoCnt, CMlngvsfCellPaintColorStart - 1, llngDoCnt, .Cols.Count - 1)
                            '@背景色変更(3列目～最終列)
                            newStyle_BackColor_CPlngHoldLotColor_ForeColor_CMlngVbColorBlack.BackColor = _
                                ColorTranslator.FromWin32(Convert.ToInt32(CPlngHoldLotColor))       '保留Lotｶﾗｰ

                            '@文字色変更(3列目～最終列)
                            newStyle_BackColor_CPlngHoldLotColor_ForeColor_CMlngVbColorBlack.ForeColor = _
                                ColorTranslator.FromWin32(Convert.ToInt32(CMlngVbColorBlack))       '黒色
                            cellRange.Style = newStyle_BackColor_CPlngHoldLotColor_ForeColor_CMlngVbColorBlack

                        Else
                            '@表示区分が「工程別」の場合

                            cellRange = .GetCellRange(llngDoCnt, CMlngvsfCellPaintColorStart, llngDoCnt, .Cols.Count - 1)
                            '@背景色変更(4列目～最終列)
                            newStyle_BackColor_CPlngHoldLotColor_ForeColor_CMlngVbColorBlack.BackColor = _
                                ColorTranslator.FromWin32(Convert.ToInt32(CPlngHoldLotColor))       '保留Lotｶﾗｰ

                            '@文字色変更(4列目～最終列)
                            newStyle_BackColor_CPlngHoldLotColor_ForeColor_CMlngVbColorBlack.ForeColor = _
                                ColorTranslator.FromWin32(Convert.ToInt32(CMlngVbColorBlack))       '黒色
                            cellRange.Style = newStyle_BackColor_CPlngHoldLotColor_ForeColor_CMlngVbColorBlack

                        End If
                    End If


                    '@-----------------------
                    '@ ﾘﾜｰｸ="リ"、追加流動="追"の表示
                    '@-----------------------
                    '@★ ﾘﾜｰｸﾌﾗｸﾞにより処理分岐 ★
                    Select Case ltypLotList(llngDoCnt-1).strReworkFlag

                        '@〓 1：ﾘﾜｰｸ 〓
                        Case CMstrReworkFlgOn

                            '@=======================
                            '@ 区分列表示処理(※区分列に"リ"を表示)
                            '@=======================
                            .SetData(llngDoCnt, CMlngvsfStepLLColKb, _
                                pubstrColKbn_Set(.GetData(llngDoCnt, CMlngvsfStepLLColKb), CMstrRi))

                        '@〓 2：追加流動 〓
                        Case CMstrReworkFlgOn2

                            '@=======================
                            '@ 区分列表示処理(※区分列に"追"を表示)
                            '@=======================
                            .SetData(llngDoCnt, CMlngvsfStepLLColKb, _
                                pubstrColKbn_Set(.GetData(llngDoCnt, CMlngvsfStepLLColKb), CMstrTsui))

                    End Select


                    '@表示区分が「全工程」または「ﾃﾝﾌﾟﾚｰﾄ」か
                    If cmbOutKbn.ListIndex = 1 Or cmbOutKbn.ListIndex = 2 Then

                        '@ﾃﾝﾌﾟﾚｰﾄ工順ﾌﾗｸﾞが"99999"か(TEMPLATE_SEQ_NUMが"99999"の場合ｸﾞﾚｰ表示)
                        If ltypLotList(llngDoCnt-1).strTemplateSeqNum = CMstrTemplateSeqNum Then

                            '@背景色変更(0、1列目)
                            newStyle_BackColor_CPlngGridGray.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngGridGray))
                            cellRange = .GetCellRange(llngDoCnt, CMlngvsfStepLLColTitle, llngDoCnt, CMlngvsfStepLLColKb)
                            cellRange.Style = newStyle_BackColor_CPlngGridGray                      '薄いｸﾞﾚｰ

                            '@文字色変更(0、1列目)
                            cellRange = .GetCellRange(llngDoCnt, CMlngvsfCellPaintColorStart - 1, llngDoCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle_BackColor_CPlngGridGray                      '薄いｸﾞﾚｰ

                        End If
                    Else
                        '@表示区分が「工程別」の場合

                        '@小工程ｺﾝﾎﾞが未選択か(TEMPLATE_TRAVELEをの表示する)
                        If cmbStepID.Text = vbNullString Then

                            '@ﾃﾝﾌﾟﾚｰﾄ工順ﾌﾗｸﾞが"99999"か(TEMPLATE_SEQ_NUMが"99999"の場合ｸﾞﾚｰ表示)
                            If ltypLotList(llngDoCnt-1).strTemplateSeqNum = CMstrTemplateSeqNum Then

                                '@背景色変更(0、1列目)
                                newStyle_BackColor_CPlngGridGray.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngGridGray))
                                cellRange = .GetCellRange(llngDoCnt, CMlngvsfStepLLColTitle, llngDoCnt, CMlngvsfStepLLColKb)
                                cellRange.Style = newStyle_BackColor_CPlngGridGray                  '薄いｸﾞﾚｰ

                                '@背景色変更(4列目～最終列)
                                cellRange = .GetCellRange(llngDoCnt, CMlngvsfCellPaintColorStart, llngDoCnt, .Cols.Count - 1)
                                cellRange.Style = newStyle_BackColor_CPlngGridGray                  '薄いｸﾞﾚｰ
                            End If
                        End If
                    End If

                    '@-----------------------------------------------
                    '@ 文字色の設定(組立限定機能)
                    '@　①ﾁｯﾌﾟ品LOT：青色
                    '@-----------------------------------------------
                    '@起動SBが組立、かつｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"か
                    If pstrSBID = CPstrSBID2A0 And _
                        ltypLotList(llngDoCnt-1).strSbArea = CPstrProductChip Then

                        '@文字色を青色に変更
                        Dim newStyle As CellStyle
                        Dim oldStyle As CellStyle
                        cellRange = .GetCellRange(llngDoCnt, CMlngvsfStepLLColNo, _
                            llngDoCnt, .Cols.Count - 1)

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

                    '@行高を設定
                    .Rows(llngDoCnt).Height = CMlngvsfStepLLHeight

                    '@ﾙｰﾌﾟｶｳﾝﾀをｲﾝｸﾘﾒﾝﾄする
                    llngDoCnt = llngDoCnt + 1
                Loop

                '@書式設定
                .Cols(CMlngvsfStepLLColNo).TextAlign = TextAlignEnum.RightCenter                   '右の中央揃え(No.)
                .Cols(CMlngvsfStepLLColOpID).TextAlign = TextAlignEnum.LeftCenter                  '左の中央揃え(大工程)
                .Cols(CMlngvsfStepLLColStepID).TextAlign = TextAlignEnum.LeftCenter                '左の中央揃え(小工程)
                .Cols(CMlngvsfStepLLColNowSt).TextAlign = TextAlignEnum.LeftCenter                 '左の中央揃え(ﾛｯﾄ状態)
                .Cols(CMlngvsfStepLLColCarrierID).TextAlign = TextAlignEnum.LeftCenter             '左の中央揃え(ｷｬﾘｱID)
                .Cols(CMlngvsfStepLLColLotID).TextAlign = TextAlignEnum.LeftCenter                 '左の中央揃え(ﾛｯﾄID)
                .Cols(CMlngvsfStepLLColPdID).TextAlign = TextAlignEnum.LeftCenter                  '左の中央揃え(機種ID)
                .Cols(CMlngvsfStepLLColFlowClass).TextAlign = TextAlignEnum.LeftCenter             '左の中央揃え(種別)
                .Cols(CMlngvsfStepLLColPriority).TextAlign = TextAlignEnum.RightCenter             '右の中央揃え(優先順位)
                .Cols(CMlngvsfStepLLColLotPosition).TextAlign = TextAlignEnum.LeftCenter           '左の中央寄せ(ﾛｯﾄ位置)
                .Cols(CMlngvsfStepLLColLotManagerName).TextAlign = TextAlignEnum.LeftCenter        '左の中央寄せ(ﾛｯﾄ担当)
                .Cols(CMlngvsfStepLLColWfNum).TextAlign = TextAlignEnum.RightCenter                '右の中央揃え(WF枚数)
                .Cols(CMlngvsfStepLLColChipNum).TextAlign = TextAlignEnum.RightCenter                '右の中央揃え(ﾁｯﾌﾟ)
                .Cols(CMlngvsfStepLLColPlanShipDate).TextAlign = TextAlignEnum.LeftCenter          '左の中央揃え(送品予定日)
                .Cols(CMlngvsfStepLLColLotComments).TextAlign = TextAlignEnum.LeftCenter           '左の中央寄せ(ﾛｯﾄｺﾒﾝﾄ有無)

                '@ﾕｰｻﾞｰにより列幅が変更されていないか
                If mtypChgSort.blnChgWidth = False Then

                    '@列幅設定(対象：列)
                    ' NSYS AllowMergingの設定がNone以外だとAutoSizeColの動作が異なるためNoneに設定
                    .AllowMerging = AllowMergingEnum.None

                    .AutoSizeCol(CMlngvsfStepLLColKb, 6)                     '保/停区分
                    .AutoSizeCol(CMlngvsfStepLLColOpID, 6)                   '大工程
                    .AutoSizeCol(CMlngvsfStepLLColStepID, 6)                 '小工程
                    .AutoSizeCol(CMlngvsfStepLLColNowSt, 6)                  'ﾛｯﾄ状態
                    .AutoSizeCol(CMlngvsfStepLLColCarrierID, 6)              'ｷｬﾘｱID
                    .AutoSizeCol(CMlngvsfStepLLColLotID, 6)                  'ﾛｯﾄID
                    .AutoSizeCol(CMlngvsfStepLLColPdID, 6)                   '機種ID
                    .AutoSizeCol(CMlngvsfStepLLColFlowClass, 6)              '種別(流動区分)
                    .AutoSizeCol(CMlngvsfStepLLColPriority, 6)               '優先順位
                    .AutoSizeCol(CMlngvsfStepLLColLotPosition, 6)            'ﾛｯﾄ位置
                    .AutoSizeCol(CMlngvsfStepLLColLotManagerName, 6)         'ﾛｯﾄ担当
                    .AutoSizeCol(CMlngvsfStepLLColWfNum, 6)                  'WF枚数
                    .AutoSizeCol(CMlngvsfStepLLColChipNum, 6)                'ﾁｯﾌﾟ
                    .AutoSizeCol(CMlngvsfStepLLColPlanShipDate, 6)           '送品予定日
                    .AutoSizeCol(CMlngvsfStepLLColLotComments, 6)            'ﾛｯﾄｺﾒﾝﾄ有無
                End If

                '@行表示
                For llngCnt = .Rows.Fixed To .Rows.Count - 1
                    .Rows(llngCnt).Visible = True
                Next llngCnt

                '@ﾏｰｼﾞ設定(対象：№、大工程)
                .AllowMerging = AllowMergingEnum.Free                            '隣接ｾﾙのﾏｰｼﾞ
                .Cols(CMlngvsfStepLLColNo).AllowMerging = True                   '№
                .Cols(CMlngvsfStepLLColOpID).AllowMerging = True                 '大工程

                '@表示区分が「工程別」か(小工程をﾏｰｼﾞ対象にするかの判定)
                If cmbOutKbn.ListIndex = 0 Then
                    .Cols(CMlngvsfStepLLColStepID).AllowMerging = True           '小工程も対象
                Else
                    .Cols(CMlngvsfStepLLColStepID).AllowMerging = False          '小工程は対象外
                End If

                '@ﾕｰｻﾞｰによりｿｰﾄされているか
                If mtypChgSort.lngCnt > 0 Then

                    For llngCnt = 0 To mtypChgSort.lngCnt - 1

                        '@該当行をｿｰﾄする
                        .Cols(mtypChgSort.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort.typChgSortList(llngCnt).lngOrder
                        .Sort(SortFlags.UseColSort,mtypChgSort.typChgSortList(llngCnt).lngCol)

                    Next llngCnt
                End If

                'NSYS 不要イベント発生抑止解除
                AddHandler vsfStepLotList.BeforeRowColChange, AddressOf vsfStepLotList_BeforeRowColChange

                '@ｿｰﾄ検索用ｷｰ(ｷｬﾘｱID)がNULL以外か
                If mtypChgSort.strKey <> vbNullString Then

                    For llngCnt = .Rows.Fixed To .Rows.Count - 1

                        '@ｿｰﾄ検索ｷｰと現在行のｷｬﾘｱIDが同じか
                        If .GetData(llngCnt, CMlngvsfStepLLColCarrierID) = mtypChgSort.strKey Then

                            '@一致行を選択
                            .Row = llngCnt

                            '@=======================
                            '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                            '@=======================
                            Call pubVsfBeforeSort(vsfStepLotList, CMlngvsfStepLLColCarrierID)

                            '@=======================
                            '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                            '@=======================
                            Call pubVsfAfterSort(vsfStepLotList, CMlngvsfStepLLColCarrierID)

                            Exit For
                        End If
                    Next llngCnt
                Else
                    '@ｿｰﾄ検索用ｷｰ(ｷｬﾘｱID)がNULLの場合

                    .TopRow = CMlngvsfStepLLRowTitle    '先頭行をﾀｲﾄﾙ行に設定
                    .Row = CMlngvsfStepLLRowTitle       'ｶﾚﾝﾄ行をﾀｲﾄﾙ行に設定
                End If

                '@列選択
                .LeftCol = CMlngvsfStepLLColTitle       '先頭列を№列に設定
                .Col = CMlngvsfStepLLColTitle           'ｶﾚﾝﾄ列を№列に設定

                '@描画ﾛｯｸ解除
                .Redraw = True


                '@引継ぎｷｬﾘｱIDがNULL以外か
                If mtypCommonInfo.strCarrierId <> vbNullString Then

                    '@引継ぎｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULL以外か
                    If mtypCommonInfo.strToCarrierId <> vbNullString Then

                        For llngCnt = .Rows.Fixed To .Rows.Count - 1

                            '@代替番号がNULL、または"0"か
                            If mtypCommonInfo.strAltPointer = vbNullString Or _
                                mtypCommonInfo.strAltPointer = CPstrZero Then

                                '@現在行のｷｬﾘｱIDが引き継ぎｱﾝﾛｰﾀﾞｷｬﾘｱIDと同じか
                                If .GetData(llngCnt, CMlngvsfStepLLColCarrierID) = _
                                    mtypCommonInfo.strToCarrierId Then

                                    '@一致行を選択
                                    .Row = llngCnt

                                    '@=======================
                                    '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfBeforeSort(vsfStepLotList, CMlngvsfStepLLColCarrierID & vbTab & _
                                                                          CMlngvsfStepLLColOpID & vbTab & _
                                                                          CMlngvsfStepLLColStepID)

                                    '@=======================
                                    '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfAfterSort(vsfStepLotList, CMlngvsfStepLLColCarrierID & vbTab & _
                                                                         CMlngvsfStepLLColOpID & vbTab & _
                                                                         CMlngvsfStepLLColStepID)

                                    Exit For
                                Else
                                    '@現在行のｷｬﾘｱIDが引き継ぎｱﾝﾛｰﾀﾞｷｬﾘｱIDと異なる場合(作業開始取消対応)

                                    '@現在行のｷｬﾘｱIDが引き継ぎﾛｰﾀﾞｷｬﾘｱIDと同じか
                                    If .GetData(llngCnt, CMlngvsfStepLLColCarrierID) = _
                                        mtypCommonInfo.strCarrierId Then

                                        '@一致行を選択
                                        .Row = llngCnt

                                        '@=======================
                                        '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                        '@=======================
                                        Call pubVsfBeforeSort(vsfStepLotList, CMlngvsfStepLLColCarrierID & vbTab & _
                                                                              CMlngvsfStepLLColOpID & vbTab & _
                                                                              CMlngvsfStepLLColStepID)

                                        '@=======================
                                        '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                        '@=======================
                                        Call pubVsfAfterSort(vsfStepLotList, CMlngvsfStepLLColCarrierID & vbTab & _
                                                                             CMlngvsfStepLLColOpID & vbTab & _
                                                                             CMlngvsfStepLLColStepID)

                                        Exit For
                                    End If
                                End If
                            Else
                                '@代替番号がNULL以外、かつ"0"以外の場合

                                '@現在行のｷｬﾘｱIDと引継ぎｱﾝﾛｰﾀﾞｷｬﾘｱIDが同じ、かつ現在行の代替番号と引継ぎ代替番号が同じか
                                If (.GetData(llngCnt, CMlngvsfStepLLColCarrierID) = _
                                    mtypCommonInfo.strToCarrierId) And _
                                    (.GetData(llngCnt, CMlngvsfStepLLColAltNumber) = _
                                    mtypCommonInfo.strAltPointer) Then

                                    '@一致行を選択
                                    .Row = llngCnt

                                    '@=======================
                                    '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfBeforeSort(vsfStepLotList, CMlngvsfStepLLColCarrierID & vbTab & _
                                                                          CMlngvsfStepLLColOpID & vbTab & _
                                                                          CMlngvsfStepLLColStepID)

                                    '@=======================
                                    '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfAfterSort(vsfStepLotList, CMlngvsfStepLLColCarrierID & vbTab & _
                                                                         CMlngvsfStepLLColOpID & vbTab & _
                                                                         CMlngvsfStepLLColStepID)

                                    Exit For
                                End If
                            End If
                        Next llngCnt
                    Else
                        '@引継ぎｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULLの場合

                        For llngCnt = .Rows.Fixed To .Rows.Count - 1

                            '@代替番号がNULL、または"0"か
                            If mtypCommonInfo.strAltPointer = vbNullString Or _
                                mtypCommonInfo.strAltPointer = CPstrZero Then

                                '@現在行のｷｬﾘｱIDが引き継ぎﾛｰﾀﾞｷｬﾘｱIDと同じか
                                If .GetData(llngCnt, CMlngvsfStepLLColCarrierID) = _
                                    mtypCommonInfo.strCarrierId Then

                                    '@一致行を選択
                                    .Row = llngCnt

                                    '@=======================
                                    '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfBeforeSort(vsfStepLotList, CMlngvsfStepLLColCarrierID & vbTab & _
                                                                          CMlngvsfStepLLColOpID & vbTab & _
                                                                          CMlngvsfStepLLColStepID)

                                    '@=======================
                                    '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfAfterSort(vsfStepLotList, CMlngvsfStepLLColCarrierID & vbTab & _
                                                                         CMlngvsfStepLLColOpID & vbTab & _
                                                                         CMlngvsfStepLLColStepID)

                                    Exit For
                                End If
                            Else
                                '@代替番号がNULL以外、かつ"0"以外の場合

                                '@現在行のｷｬﾘｱIDと引継ぎﾛｰﾀﾞｷｬﾘｱIDが同じ、かつ現在行の代替番号と引継ぎ代替番号が同じか
                                If (.GetData(llngCnt, CMlngvsfStepLLColCarrierID) = _
                                    mtypCommonInfo.strCarrierId) And _
                                    (.GetData(llngCnt, CMlngvsfStepLLColAltNumber) = _
                                    mtypCommonInfo.strAltPointer) Then

                                    '@一致行を選択
                                    .Row = llngCnt

                                    '@=======================
                                    '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfBeforeSort(vsfStepLotList, CMlngvsfStepLLColCarrierID & vbTab & _
                                                                          CMlngvsfStepLLColOpID & vbTab & _
                                                                          CMlngvsfStepLLColStepID)

                                    '@=======================
                                    '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfAfterSort(vsfStepLotList, CMlngvsfStepLLColCarrierID & vbTab & _
                                                                         CMlngvsfStepLLColOpID & vbTab & _
                                                                         CMlngvsfStepLLColStepID)

                                    Exit For
                                End If
                            End If
                        Next llngCnt
                    End If

                    '@引継ぎﾌﾗｸﾞが"False：単独起動"か
                    If mblnTakeOverFlag = False Then

                        '@引継ぎ情報の初期化
                        With mtypCommonInfo

                            .strCarrierId = vbNullString
                            .strDivision = vbNullString
                            .strLotID = vbNullString
                            .strWpID = vbNullString
                            .strWpName = vbNullString
                            .strToCarrierId = vbNullString
                            .strAltPointer = vbNullString
                            .strWpID = vbNullString
                        End With
                    End If

                    '@引継ぎﾌﾗｸﾞの初期化
                    mblnTakeOverFlag = False
                End If

                '@工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞを有効にする
                .Enabled = True

                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False：起動中(or初期値)"か
                If pblnFormLoad = False Then

                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    '@ 工程別ﾛｯﾄ一覧画面　表示処理
                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    Me.Show()

                End If

                '@工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞが有効か
                If .Enabled = True Then

                    '@工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfStepLotList)
                Else
                    '@工程別ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞを有効にする
                    .Enabled = True
                End If

            End With

            '@=======================
            '@ ﾛｯﾄ情報詳細表示ﾎﾞﾀﾝ有効/無効制御処理
            '@=======================
            Call prvCmdLotDitailControl_Proc()

            '@[ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ]を有効にする
            cmdCopy.Enabled = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfStepLotList_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbOutKbn_Disp
    '機　能：表示区分ｺﾝﾎﾞ設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 09:45:12 M.Matsuura
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2004/11/05 (Fri) 14:26:24 T.Kitagawa　 ﾃﾝﾌﾟﾚｰﾄ表示対応(不具合№199)
    '　　　：2005/01/13 (Thu) 16:23:31 H.Wajima     ﾃﾝﾌﾟﾚｰﾄ表示対応(不具合№199) ｺﾒﾝﾄ解除
    '　　　：2005/06/20 (Mon) 10:30:40 N.Kojima     ｺﾒﾝﾄｱｳﾄ行の削除(工順ﾃﾝﾌﾟﾚｰﾄ対応部)
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub prvCmbOutKbn_Disp()

        Try

            '@表示区分ｺﾝﾎﾞの設定
            RemoveHandler cmbOutKbn.Change, AddressOf cmbOutKbn_Change
            With cmbOutKbn

                .Clear()
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColName                                   'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColID                                   '値取得列
                .DirectInput = False                                            'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.FontFamily, CType(CMlngCmbFontSize,Single), .Font.Style, .Font.Unit) 'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CType(CMlngCmbGridFontSize,Single), .GridFont.Style, .GridFont.Unit) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  '行の高さ
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter   '左寄中央揃え

                '@表示区分情報をｾｯﾄ(工程別/全工程/ﾃﾝﾌﾟﾚｰﾄ)
                .AddItem(CMstrProcess)                                          '工程別
                .AddItem(CmstrProcessAll)                                       '全工程
                .AddItem(CmstrProcessTemplate)                                  'ﾃﾝﾌﾟﾚｰﾄ
            End With
            AddHandler cmbOutKbn.Change, AddressOf cmbOutKbn_Change

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbOutKbn_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbOpID_Disp
    '機　能：大工程ｺﾝﾎﾞ設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/26 (Mon) 17:11:50 M.Matsuura
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub prvCmbOpID_Disp()

        Dim llngCnt     As Integer  'ｶｳﾝﾄ

        Try

            '@大工程ｺﾝﾎﾞの設定
            RemoveHandler cmbOpID.Change, AddressOf cmbOpID_Change
            With cmbOpID

                .Clear()                                                        'ｸﾘｱ
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColName                                   'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColID                                   '値取得列
                .DirectInput = False                                            'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.FontFamily, CType(CMlngCmbFontSize,Single), .Font.Style, .Font.Unit) 'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CType(CMlngCmbGridFontSize,Single), .GridFont.Style, .GridFont.Unit) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  '行の高さ
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter   '左寄中央揃え

                '@大工程ｺﾝﾎﾞ内容の設定(大工程名/ﾘｽﾄIndex)
                For llngCnt = 1 To mtypMasOpList.lngMasOpCnt

                    .AddItem(mtypMasOpList.typMasOpId(llngCnt-1).strOpID _
                           & vbTab _
                           & llngCnt)

                Next llngCnt

                '@大工程ﾘｽﾄ件数が1件か
                If mtypMasOpList.lngMasOpCnt = 1 Then

                    '@1件の場合は直接表示
                    .ListIndex = 0
                End If
            End With
            AddHandler cmbOpID.Change, AddressOf cmbOpID_Change

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
    '機　能：小工程ｺﾝﾎﾞ設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/26 (Mon) 17:11:50 M.Matsuura
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub prvCmbStepID_Disp()

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try

            '@小工程ｺﾝﾎﾞの設定
            RemoveHandler cmbStepID.Change, AddressOf cmbStepID_Change
            With cmbStepID

                .Clear()                                                        'ｸﾘｱ
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColName                                   'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColID                                   '値取得列
                .DirectInput = False                                            'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.FontFamily, CType(CMlngCmbFontSize,Single), .Font.Style, .Font.Unit) 'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CType(CMlngCmbGridFontSize,Single), .GridFont.Style, .GridFont.Unit) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  '行の高さ
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter   '左寄中央揃え

                '@小工程ｺﾝﾎﾞ内容の設定(小工程名/ﾘｽﾄIndex)
                For llngCnt = 1 To mtypMasStepList.lngMasStepCnt

                    .AddItem(mtypMasStepList.typMasStepId(llngCnt-1).strStepID _
                           & vbTab _
                           & llngCnt)

                Next llngCnt

                '@小工程ﾘｽﾄ件数が1件か
                If mtypMasStepList.lngMasStepCnt = 1 Then

                    '@1件の場合は直接表示
                    .ListIndex = 0
                End If
            End With
            AddHandler cmbStepID.Change, AddressOf cmbStepID_Change

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

    '関数名：prvCmbPd_Disp
    '機　能：機種ｺﾝﾎﾞ設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/20 (Wed) 13:18:19 N.Kasai
    '更新日：2009/08/28 (Fri) 09:28:22 N.Kojima
    '備　考：
    '　　　：2005/09/06 (Tue) 14:49:47 S.Deguchi    処理見直し
    '　　　：2009/08/28 (Fri) 09:28:22 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub prvcmbPd_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            '@機種ｺﾝﾎﾞの設定
            RemoveHandler cmbPD.Change, AddressOf cmbPD_Change
            With cmbPD

                .Clear()                                                    'ｸﾘｱ
                .Enabled = True                                             '有効
                .DirectInput = False                                        '直接入力不可(False)
                .SelectMode = CMlngCMbSelectMode                            '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                     '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = CMlngCmbDispCols                               '列方向のﾚｺｰﾄﾞ数
                .GroupRows = mlngProductListCnt                             '行方向のﾚｺｰﾄﾞ数
                .AddedComment = CMstrCmbAddedComment                        '"選択"文字列
                .Font = New Font(.Font.FontFamily, CType(CMlngCmbFontSize,Single), .Font.Style, .Font.Unit) 'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CType(CMlngCmbGridFontSize,Single), .GridFont.Style, .GridFont.Unit) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                              '行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter  '左寄中央揃え

                For llngCnt = 1 To mlngProductListCnt

                    '@機種ｺﾝﾎﾞ内容の設定(機種ID/機種名/ﾘｽﾄIndex/NULL/ﾁｪｯｸBOXのﾃﾞﾌｫﾙﾄﾁｪｯｸ(1：ON))
                    .AddItem(mtypProductList(llngCnt-1).strProductID & vbTab & _
                             mtypProductList(llngCnt-1).strProductName & vbTab & _
                             llngCnt & vbTab & _
                             vbNullString & vbTab & _
                             CMstrCmbCheckOn)

                Next llngCnt

                '@ﾃｷｽﾄ部分に情報をｾｯﾄ
                .AddedComment = CMstrCmbAddedComment        '" 項目選択"
                .Text = .ListCount & CMstrCmbAddedComment   '"N項目選択"(Nは選択数)

            End With
            AddHandler cmbPD.Change, AddressOf cmbPD_Change

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
    '機　能：種別ｺﾝﾎﾞ設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/20 (Wed) 13:18:19 N.Kasai
    '更新日：2009/08/28 (Fri) 09:28:22 N.Kojima
    '備　考：
    '　　　：2009/08/28 (Fri) 09:28:22 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub prvcmbFlowClass_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            '@種別ｺﾝﾎﾞの設定
            RemoveHandler cmbFlowClass.Change, AddressOf cmbFlowClass_Change
            With cmbFlowClass

                .Clear()                                                    'ｸﾘｱ
                .Enabled = True                                             '有効
                .DirectInput = False                                        '直接入力不可(False)
                .SelectMode = CMlngCMbSelectMode                            '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                     '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = CMlngCmbDispCols                               '列方向のﾚｺｰﾄﾞ数
                .GroupRows = mlngDivisionListCnt                            '行方向のﾚｺｰﾄﾞ数
                .AddedComment = CMstrCmbAddedComment                        '"選択"文字列
                .Font = New Font(.Font.FontFamily, CType(CMlngCmbFontSize,Single), .Font.Style, .Font.Unit) 'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CType(CMlngCmbGridFontSize,Single), .GridFont.Style, .GridFont.Unit) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                              'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter  '左寄中央揃え

                For llngCnt = 1 To mlngDivisionListCnt

                    '@種別ｺﾝﾎﾞ内容の設定(種別/ﾘｽﾄIndex/NULL/NULL/ﾁｪｯｸBOXのﾃﾞﾌｫﾙﾄﾁｪｯｸ(1：ON))
                    .AddItem(mtypDivisionList(llngCnt-1).strDivisionID & vbTab & _
                             llngCnt & vbTab & _
                             vbNullString & vbTab & _
                             vbNullString & vbTab & _
                             CMstrCmbCheckOn)

                Next llngCnt

                '@ﾃｷｽﾄ部分に情報をｾｯﾄ
                .AddedComment = CMstrCmbAddedComment        '" 項目選択"
                .Text = .ListCount & CMstrCmbAddedComment   '"N項目選択"(Nは選択数)

            End With
            AddHandler cmbFlowClass.Change, AddressOf cmbFlowClass_Change

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

    '関数名：prvblnMasOpList_Sel
    '機　能：大工程取得処理
    '引　数：なし
    '戻り値：True：処理成功、False：処理失敗
    '作成日：2005/09/06 (Tue) 11:06:50 S.Deguchi
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Function prvblnMasOpList_Sel() As Boolean

        Dim lblnAns     As Boolean      '汎用戻り値

        Try

            '@戻り値の初期化
            prvblnMasOpList_Sel = False

            '@配列の初期化
            If Not IsNothing(mtypMasOpList.typMasOpId) Then
                mtypMasOpList.typMasOpId.Clear()
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvblnOpListSel)

            '@=======================
            '@ 大工程ﾏｽﾀ取得
            '@=======================
            lblnAns = pubblnMasUseOpList_Sel(pstrSBID, _
                                             CMstrmas_useoplistVer, _
                                             CPstrCD02, _
                                             mtypMasOpList)

            '@大工程ﾏｽﾀ取得結果が"False：取得失敗"か
            If lblnAns = False Then

                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvblnOpListSel)
                Exit Function
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrPrvblnOpListSel)

            '@戻り値に"True：処理成功"をｾｯﾄ
            prvblnMasOpList_Sel = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnMasOpList_Sel"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnStepList_Sel
    '機　能：小工程取得処理
    '引　数：lstrOpID   ：大工程ID
    '戻り値：True：処理成功、False：処理失敗
    '作成日：2005/09/06 (Tue) 11:09:34 S.Deguchi
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2008/01/22 (Tue) 10:24:19 N.Kojima     lot_.steplistの要求に"LOT_LIST"追加に関連して処理修正。(案件№02405)
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Function prvblnStepList_Sel(Optional ByVal lstrOpID As String = vbNullString) As Boolean

        Dim lblnAns         As Boolean              '汎用戻り値
        Dim ltypLotList     As List(Of LotIdList)   'ﾛｯﾄﾘｽﾄ(引数合わせ用で内容は未使用)

        Try

            '@戻り値の初期化
            prvblnStepList_Sel = False

            '@配列の初期化
            If Not IsNothing(mtypMasStepList.typMasStepId) Then
                mtypMasStepList.typMasStepId.Clear()
            End If

            '@大工程を変数にｾｯﾄ
            If lstrOpID = vbNullString Then
                lstrOpID = mstrOpID
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvblnStepListSel)

            '@=======================
            '@ 小工程取得
            '@=======================
            lblnAns = pubblnLotStepList_Sel(pstrSBID, _
                                            CMstrlot_steplistVer, _
                                            CPstrCD28, _
                                            ltypLotList, _
                                            mtypMasStepList, _
                                            lstrOpID)

            '@小工程取得結果が"False：取得失敗"か
            If lblnAns = False Then

                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvblnStepListSel)
                Exit Function
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrPrvblnStepListSel)

            '@戻り値に"True：処理成功"をｾｯﾄ
            prvblnStepList_Sel = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnStepList_Sel"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvLotListReq_Proc
    '機　能：工程別ﾛｯﾄ一覧取得要求ﾃﾞｰﾀ作成処理
    '引　数：lstrClassDivision  ：処理区分
    '　　　：ltypLotListReq     ：要求構造体
    '戻り値：なし
    '作成日：2005/09/07 (Wed) 11:50:37 S.Deguchi
    '更新日：2009/08/28 (Fri) 09:28:22 N.Kojima
    '備　考：
    '　　　：2009/08/28 (Fri) 09:28:22 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub prvLotListReq_Proc(ByVal lstrClassDivision As String, _
                                   ByRef ltypLotListReq As OpLotList)

        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ
        Dim lstrTemp()      As String       '一時取得用変数

        Try

            '@各種構造体ﾒﾝﾊﾞの配列の初期化
            ltypLotListReq.typFlowClassList = Nothing       '流動区分ﾘｽﾄ
            ltypLotListReq.typPdList = Nothing              '機種ﾘｽﾄ

            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotListReq

                .strSbID = pstrSBID                                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strMsgVer = CMstrlot_oplotlistVer                          'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strClassDivision = lstrClassDivision                       '処理区分
                .strOpID = mstrOpID                                         '大工程
                .strStepID = mstrStepID                                     '小工程

                .lngPdCnt = cmbPD.ValueCount                                '機種ｶｳﾝﾄ数

                '@機種ｺﾝﾎﾞﾃﾞｰﾀ件数が1件以上か
                If cmbPD.ValueCount > 0 Then

                    .typPdList = New List(Of PDList)
                    lstrTemp = Split(cmbPD.Value, vbTab)

                    For llngCnt = LBound(lstrTemp) To UBound(lstrTemp)

                        Dim tmpPDList As PDList = New PDList()
                        tmpPDList.strPdId = lstrTemp(llngCnt)               '機種
                        .typPdList.Add(tmpPDList)
                    Next llngCnt
                End If

                .lngFlowClassCnt = cmbFlowClass.ValueCount                  '流動区分ｶｳﾝﾄ数

                '@流動区分ｺﾝﾎﾞﾃﾞｰﾀ件数が1件以上か
                If cmbFlowClass.ValueCount > 0 Then

                    .typFlowClassList = New List(Of FlowClassList)
                    lstrTemp = Split(cmbFlowClass.Value, vbTab)

                    For llngCnt = LBound(lstrTemp) To UBound(lstrTemp)

                        Dim tmpFlowClassList As FlowClassList = New FlowClassList()
                        tmpFlowClassList.strFlowClass = lstrTemp(llngCnt)   '流動区分
                        .typFlowClassList.Add(tmpFlowClassList)
                    Next llngCnt
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvLotListReq_Proc"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnLotOpList_Sel
    '機　能：工程別ﾛｯﾄ一覧ﾘｽﾄ取得
    '引　数：ltypLotListReq ：要求構造体
    '戻り値：True：処理成功、False：処理失敗
    '作成日：2005/09/06 (Tue) 13:10:37 S.Deguchi
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2008/07/01 (Tue) 17:34:53 M.Koni       "util.regtminfo"応答ﾒｯｾｰｼﾞ変更対応<案件No.03006>
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Function prvblnLotOpList_Sel(ByRef ltypLotListReq As OpLotList) As Boolean

        Dim lblnAns             As Boolean              '汎用戻り値
        Dim ltypUtilRegTmInfo   As UtilRegTmInfo        '端末設定情報格納

        Try

            '@戻り値の初期化
            prvblnLotOpList_Sel = False

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvblnLotOpListSel)

            '@=======================
            '@ 工程別ﾛｯﾄ一覧取得
            '@=======================
            lblnAns = pubblnOpLotList_Sel(ltypLotListReq, _
                                          mtypLotList, _
                                          mlngLotListCnt)

            '@工程別ﾛｯﾄ一覧取得結果が"True：取得成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrPrvblnLotOpListSel)

                With ltypLotListReq

                    '@処理区分が"27：大工程,小工程別"、かつ大工程がNULL以外か
                    If .strClassDivision = CPstrCD27 And _
                        .strOpID <> vbNullString Then

                        '@ﾚｽﾎﾟﾝｽ取得開始
                        Call pubResponseStart(CMstrFormName, CMstrPrvblnLotOpListSel)

                        '@=======================
                        '@ 端末設定情報登録
                        '@=======================
                        lblnAns = pubblnUtilRegTmInfo_Upd(pstrSBID, _
                                                          CMstrutilregtminfoVer, _
                                                          .strClassDivision, _
                                                          pstrComputerName, _
                                                          ltypUtilRegTmInfo, _
                                                          vbNullString, _
                                                          .strOpID, _
                                                          .strStepID)

                        '@端末設定情報登録結果が"False：登録失敗"か
                        If lblnAns = False Then

                            '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                            Call pubResponseCancel(CMstrFormName, CMstrPrvblnLotOpListSel)
                            Exit Function
                        End If

                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrPrvblnLotOpListSel)

                    End If
                End With
            Else
                '@工程別ﾛｯﾄ一覧取得結果が"False：取得失敗"か

                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvblnLotOpListSel)
                Exit Function
            End If

            '@成功を返す
            prvblnLotOpList_Sel = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnLotOpList_Sel"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvCmdLotDitailControl_Proc
    '機　能：ﾛｯﾄ情報詳細表示ﾎﾞﾀﾝ有効/無効制御処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/05/10 (Thu) 14:43:33 N.Kasai
    '更新日：2009/08/27 (Thu) 12:41:54 N.Kojima
    '備　考：
    '　　　：2009/08/27 (Thu) 12:41:54 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub prvCmdLotDitailControl_Proc()

        Try

            '@初回ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False：初回"か
            If mblnFormLoadFlag = False Then
                Exit Sub
            End If

            With vsfStepLotList

                '@対象ﾃﾞｰﾀ0件か
                If .Rows.Count = 1 Then

                    '@ﾛｯﾄ情報詳細表示ﾎﾞﾀﾝを無効にする
                    cmdLotDetail.Enabled = False
                    Exit Sub
                End If

                '@選択行がﾃﾞｰﾀ行か
                If .Row > 0 Then

                    '@ｷｬﾘｱIDがNULL以外か
                    If .GetData(.Row, CMlngvsfStepLLColCarrierID) <> vbNullString Then

                        '@ﾛｯﾄ情報詳細表示ﾎﾞﾀﾝを有効にする
                        cmdLotDetail.Enabled = True
                    Else
                        '@ﾛｯﾄ情報詳細表示ﾎﾞﾀﾝを無効にする
                        cmdLotDetail.Enabled = False
                    End If
                Else
                    '@選択行がﾃﾞｰﾀ行以外か

                    '@ﾛｯﾄ情報詳細表示ﾎﾞﾀﾝを無効にする
                    cmdLotDetail.Enabled = False
                End If

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmdLotDitailControl_Proc"
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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfStepLotList.BeforeDoubleClick

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
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考：Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles cmbOutKbn.Enter, cmbOpID.Enter, cmbStepID.Enter, _
        cmbPD.Enter, cmbFlowClass.Enter, vsfStepLotList.Enter, cmdClose.Enter, cmdNowList.Enter, cmdCopy.Enter, _
        cmdLotConnectedInfoDisp.Enter, cmdLotDetail.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '閉じるボタンの場合は自動Validate = OFF
            Case "cmdClose", "cmdLotDetail"
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
                '上記以外は自動Validate = ON
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

End Class
