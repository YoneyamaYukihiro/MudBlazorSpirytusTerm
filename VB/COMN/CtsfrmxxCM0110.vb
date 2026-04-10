'ﾌｧｲﾙ名：xxCM0110.frm
'説　明：ロット処理順変更　メインフォーム
'作成日：2004/05/17 (Mon) 15:33:25 Y.Yamagishi
'更新日：2025/04/18 (Fri) 16:34:52 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2025, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM0110
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM0110    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM0110
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM0110
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM0110)
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
    '@↓2025/04/18 (Fri) 16:34:52 T.Oide **************************************************
    'Private Const CMstrLocalVersion                     As String = "13.05"
    Private Const CMstrLocalVersion                     As String = "13.06"
    '@↑2025/04/18 (Fri) 16:34:52 T.Oide **************************************************

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrlot_chgseqnumVer                 As String = "06.00"                 'ﾛｯﾄ処理順番変更
    Private Const CMstrlot_list____Ver                  As String = "12.01"                 'ﾛｯﾄ一覧
    Private Const CMstreq__areacurlistVer               As String = "02.00"                 'ｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置用途情報取得
    Private Const CMstrutilregtminfoVer                 As String = "06.00"                 '端末設定情報登録
    Private Const CMstrutilreftminfoVer                 As String = "04.00"                 '端末設定情報取得
    Private Const CMstrmas_McGrouplistVer               As String = "01.00"                 '装置ｸﾞﾙｰﾌﾟ取得
    Private Const CMstreq__state___Ver                  As String = "03.00"                 '装置状態取得

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN0260          'ﾛｰｶﾙ機能ID

    '@以下、vsfLotWaitingListの定数宣言
    '@---------------------------------------------------------------------------------------
    '@列番号設定用定数
    Private Const CMlngvsfWaitListNo                    As Integer = 0                      '初期順番
    Private Const CMlngvsfWaitListKb                    As Integer = 1                      '保/停区分
    Private Const CMlngvsfWaitListSeqNumNow             As Integer = 2                      '現処理順№
    Private Const CMlngvsfWaitListSeqNum                As Integer = 3                      '変更後処理順№
    Private Const CMlngvsfWaitListLimitTime             As Integer = 4                      '時間制限
    Private Const CMlngvsfWaitListShipDiffDay           As Integer = 5                      'ﾛｯﾄ進捗度
    Private Const CMlngvsfWaitListLotId                 As Integer = 6                      'ﾛｯﾄID
    Private Const CMlngvsfWaitListGrbClass              As Integer = 7                      'GRB区分
    Private Const CMlngvsfWaitListFrowClass             As Integer = 8                      '種別
    Private Const CMlngvsfWaitListLotPriority           As Integer = 9                      '優先順位
    Private Const CMlngvsfWaitListOpID                  As Integer = 10                      '大工程
    Private Const CMlngvsfWaitListStepID                As Integer = 11                     '小工程
    Private Const CMlngvsfWaitListRecipeID              As Integer = 12                     'ﾚｼﾋﾟ
    Private Const CMlngvsfWaitListStartTime             As Integer = 13                     '処理開始予実
    Private Const CMlngvsfWaitListLotManagerName        As Integer = 14                     'ﾛｯﾄ担当
    Private Const CMlngvsfWaitListNowSt                 As Integer = 15                     '状態
    Private Const CMlngvsfWaitListWfNum                 As Integer = 16                     'WF枚数
    Private Const CMlngvsfWaitListCfNum                 As Integer = 17                     'ﾁｯﾌﾟ
    Private Const CMlngvsfWaitListCurrentPosition       As Integer = 18                     '現在位置ID
    Private Const CMlngvsfWaitListLotLastUpdate         As Integer = 19                     '最終更新日時
    Private Const CMlngvsfWaitListReworkFlag            As Integer = 20                     'ﾘﾜｰｸﾌﾗｸﾞ
    Private Const CMlngvsfWaitListLotComments           As Integer = 21                     'ｺﾒﾝﾄ
    Private Const CMlngvsfWaitListAvailableRecipeFlag   As Integer = 22                     '処理可能ﾚｼﾋﾟﾌﾗｸﾞ(0：処理可能ﾚｼﾋﾟ、1：処理限定ﾚｼﾋﾟﾌﾗｸﾞ)
    Private Const CMlngvsfWaitListCarrierID             As Integer = 23                     'ｷｬﾘｱID
    Private Const CMlngvsfWaitListFrFlag                As Integer = 24                     'FRﾚｼﾋﾟ有無ﾌﾗｸﾞ

    '@列幅設定用定数
    Private Const CMlngvsfWaitListWNo                   As Integer = 43                     '初期順番
    Private Const CMlngvsfWaitListWKb                   As Integer = 32                     '保/停区分
    Private Const CMlngvsfWaitListWSeqNumNow            As Integer = 81                     '現処理順№
    Private Const CMlngvsfWaitListWSeqNum               As Integer = 80                     '変更後処理順№
    Private Const CMlngvsfWaitListWLimitTime1A0         As Integer = 236                    '時間制限(基板)
    Private Const CMlngvsfWaitListWLimitTime2A0         As Integer = 189                    '時間制限(組立)
    Private Const CMlngvsfWaitListWCarrierID            As Integer = 133                    'ｷｬﾘｱID
    Private Const CMlngvsfWaitListWLotId                As Integer = 133                    'ﾛｯﾄID
    Private Const CMlngvsfWaitListWFrowClass            As Integer = 54                     '種別
    Private Const CMlngvsfWaitListWLotPriority          As Integer = 25                     '優先順位
    Private Const CMlngvsfWaitListWOpID                 As Integer = 133                    '大工程
    Private Const CMlngvsfWaitListWStepID               As Integer = 133                    '小工程
    Private Const CMlngvsfWaitListWRecipeID             As Integer = 73                     'ﾚｼﾋﾟ
    Private Const CMlngvsfWaitListWStartTime            As Integer = 176                    '処理開始予実
    Private Const CMlngvsfWaitListWEndTime              As Integer = 176                    '処理終了予実
    Private Const CMlngvsfWaitListWLotManagerName       As Integer = 149                    'ﾛｯﾄ担当
    Private Const CMlngvsfWaitListWNowSt                As Integer = 54                     '状態
    Private Const CMlngvsfWaitListWWfNum                As Integer = 133                    'WF枚数
    Private Const CMlngvsfWaitListWCfNum                As Integer = 133                    'ﾁｯﾌﾟ
    Private Const CMlngvsfWaitListWCurrentPosition      As Integer = 133                    '現在位置ID
    Private Const CMlngvsfWaitListWLotLastUpdate        As Integer = 133                    '最終更新日時
    Private Const CMlngvsfWaitListWReworkFlag           As Integer = 65                     'ﾘﾜｰｸﾌﾗｸﾞ
    Private Const CMlngvsfWaitListWLotComments          As Integer = 65                     'ｺﾒﾝﾄ有無
    Private Const CMlngvsfWaitListWAvailableRecipeFlag  As Integer = 0                      '処理可能ﾚｼﾋﾟﾌﾗｸﾞ(0：処理可能ﾚｼﾋﾟ、1：処理限定ﾚｼﾋﾟﾌﾗｸﾞ)
    Private Const CMlngvsfWaitListWShipDiffDay          As Integer = 53                     'ﾛｯﾄ進捗度
    Private Const CMlngvsfWaitListWFrFlag               As Integer = 0                      'FRﾚｼﾋﾟ有無ﾌﾗｸﾞ
    Private Const CMlngvsfWaitListWGrbClass             As Integer = 25                     'GRB区分
    Private Const CMlngvsfWaitListWColorCd              As Integer = 0                      '指定色

    '@ﾀｲﾄﾙ設定用定数
    Private Const CMstrvsfWaitListTNo                   As String = "№"                    '初期順番
    Private Const CMstrvsfWaitListTKb                   As String = ""                      '保/停区分
    Private Const CMstrvsfWaitListTSeqNumNow            As String = "現処理№"              '現処理順№
    Private Const CMstrvsfWaitListTSeqNum               As String = "変更後№"              '変更後処理順№
    Private Const CMstrvsfWaitListTLimitTime            As String = "時間制限"              '時間制限
    Private Const CMstrvsfWaitListTCarrierID            As String = "キャリアID"            'ｷｬﾘｱID
    Private Const CMstrvsfWaitListTLotId                As String = "ロットID"              'ﾛｯﾄID
    Private Const CMstrvsfWaitListTFrowClass            As String = "種別"                  '種別
    Private Const CMstrvsfWaitListTLotPriority          As String = "優"                    '優先順位
    Private Const CMstrvsfWaitListTOpID                 As String = "大工程"                '大工程
    Private Const CMstrvsfWaitListTStepID               As String = "小工程"                '小工程
    Private Const CMstrvsfWaitListTRecipeID             As String = "レシピ"                'ﾚｼﾋﾟ
    Private Const CMstrvsfWaitListTStartTime            As String = "処理開始予定"          '処理開始予実
    Private Const CMstrvsfWaitListTEndTime              As String = "処理終了予実"          '処理終了予実
    Private Const CMstrvsfWaitListTLotManagerName       As String = "ロット担当"            'ﾛｯﾄ担当
    Private Const CMstrvsfWaitListTNowSt                As String = "状態"                  '状態
    Private Const CMstrvsfWaitListTWfNum                As String = "WF枚数"                'WF枚数
    Private Const CMstrvsfWaitListTCfNum                As String = "チップ"                'ﾁｯﾌﾟ
    Private Const CMstrvsfWaitListTCurrentPosition      As String = "現在位置"              '現在位置ID
    Private Const CMstrvsfWaitListTLotLastUpdate        As String = "最終更新日時"          '最終更新日時
    Private Const CMstrvsfWaitListTReworkFlag           As String = "リワーク"              'ﾘﾜｰｸﾌﾗｸﾞ
    Private Const CMstrvsfWaitListTLotComments          As String = "コメント"              'ｺﾒﾝﾄ有無
    Private Const CMstrvsfWaitListTAvailableRecipeFlag  As String = "処理可能レシピフラグ"  '処理可能ﾚｼﾋﾟﾌﾗｸﾞ(0：処理可能ﾚｼﾋﾟ、1：処理限定ﾚｼﾋﾟﾌﾗｸﾞ)
    Private Const CMstrvsfWaitListTShipDiffDay          As String = "進捗度"                'ﾛｯﾄ進捗度
    Private Const CMstrvsfWaitListTFrFlag               As String = "FRﾚｼﾋﾟ有無ﾌﾗｸﾞ"        'FRﾚｼﾋﾟ有無ﾌﾗｸﾞ
    Private Const CMstrvsfWaitListTGrbClass             As String = "GRB"                   'GRB区分
    Private Const CMstrvsfWaitListTColorCd              As String = "指定色"                '指定色

    '@固定列/行用定数
    Private Const CMlngvsfWaitListRowTitle              As Integer = 0                      'ﾀｲﾄﾙ行(行)
    Private Const CMlngvsfWaitListColTitle              As Integer = 0                      'ﾀｲﾄﾙ行(列)
    Private Const CMlngvsfWaitListFrozenCols            As Integer = 7                      '固定列数


    '@1ﾍﾟｰｼﾞの表示行数、ﾌｫﾝﾄｻｲｽﾞ用定数
    Private Const CMlngvsfWaitListPageRows              As Integer = 10                     '1頁表示行数
    Private Const CMlngvsfWaitListHFontSize             As Integer = 12                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfWaitListTopRow                As Integer = 0                      '選択最上段行

    '@行高設定用定数
    Private Const CMlngvsfWaitListHHeight               As Integer = 27                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngvsfWaitListHeight                As Integer = 38                     '1ｽﾛｯﾄの高さ

    '@ﾛｯﾄ状態表示用定数
    Private Const CMstrBu                               As String = "部"                    '部分ﾚｼﾋﾟ表示
    Private Const CMstrGou                              As String = "号"                    '号機指定表示
    Private Const CMstrRi                               As String = "リ"                    'ﾘﾜｰｸ表示
    Private Const CMstrTsui                             As String = "追"                    '追加表示
    Private Const CMstrHo                               As String = "保"                    '保留表示
    Private Const CMstrTei                              As String = "停"                    '停止表示
    Private Const CMstrGen                              As String = "限"                    '処理限定表示
    Private Const CMstrGai                              As String = "外"                    'FR累積時間範囲外表示

    '@ｷｬﾘｱ位置表示用定数
    Private Const CMstrArrow                            As String = "→"

    '@ｺﾝﾎﾞﾎﾞｯｸｽ用定数
    Private Const CMlngCmbFontSize                      As Integer = 16                     'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Integer = 16                     'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColName                   As Integer = 0                      '名称列番
    Private Const CMlngCmbGridColID                     As Integer = 1                      'ID列番(非表示項目)
    Private Const CMlngCmbDispCols                      As Integer = 1                      'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbRowHeight                     As Integer = 43                     'ﾘｽﾄ行の高さ
    Private Const CMlngCmbValueColName                  As Integer = 0                      '装置ID名称取得列数
    Private Const CMlngCmbValueColID                    As Integer = 1                      '装置ID取得列数

    '@色表示用定数
    Private Const CMlngColorGlay                        As Integer = &H80000004             '灰色
    Private Const CMlngColorWhite                       As Integer = &HFFFFFF               '白色
    Private Const CMlngColorBlack                       As Integer = &H0&                   '黒色

    '@各種ﾌﾗｸﾞ用定数
    Private Const CMstrGoukiFlagOn                      As String = "1"                     '号機指定ﾌﾗｸﾞON
    Private Const CMstrLotHoldFlagOn                    As String = "1"                     '保留ﾛｯﾄﾌﾗｸﾞON
    Private Const CMstrLotStopFlagOn                    As String = "1"                     '停止ﾛｯﾄﾌﾗｸﾞON
    Private Const CMstrLotReworkFlagOn                  As String = "1"                     'ﾘﾜｰｸﾌﾗｸﾞON
    Private Const CMstrLotReworkFlagOn2                 As String = "2"                     'ﾘﾜｰｸﾌﾗｸﾞON2
    Private Const CMstrPartialRecipeFlagOn              As String = "1"                     '部分ﾚｼﾋﾟﾌﾗｸﾞON

    '@処理順用定数
    Private Const CMstrSeqNo                            As String = "000"                   '処理順№初期値
    Private Const CMstrSeqNumAll9                       As String = "999"                   '処理№がNullの場合の初期値
    Private Const CMstrSeqNumEntryMax                   As String = "998"                   '処理№の採番限界値

    '@以下、装置関連定数
    '@---------------------------------------------------------------------------------------
    '@稼動状態
    Private Const CMstrWpStopFlag0                      As String = "0"
    Private Const CMstrWpStopFlag1                      As String = "1"
    Private Const CMstrWpMoveStop                       As String = "停止中"
    Private Const CMstrWpMoveFlow                       As String = "稼動中"
    '@---------------------------------------------------------------------------------------

    '@その他の定数
    Private Const CMstrVbKeyTab                         As String = "{TAB}"                 'TABｷｰ
    Private Const CMstrSeqNumStandard                   As String = "標準"                   '処理順


    '@ﾚｽﾎﾟﾝｽ測定開始場所のﾌﾗｸﾞ設定用定数
    Private Const CMlngResStartClear                    As Integer = 0                      'ﾚｽﾎﾟﾝｽ測定が開始されていない(ﾌﾗｸﾞの初期化)
    Private Const CMlngResStartFormLoad                 As Integer = 1                      'Form_Loadでﾚｽﾎﾟﾝｽ測定開始
    Private Const CMlngResStartcmbMcGroupName           As Integer = 2                      'cmbMcGroupName_Validateでﾚｽﾎﾟﾝｽ測定開始
    Private Const CMlngResStartCmbWpID                  As Integer = 3                      'cmbWpID_Validateでﾚｽﾎﾟﾝｽ測定開始
    Private Const CMlngResStartCmdLotList               As Integer = 4                      'cmdLotList_Clickでﾚｽﾎﾟﾝｽ測定開始
    Private Const CMlngResStartCmdRegist                As Integer = 5                      'CmdRegist_Clickでﾚｽﾎﾟﾝｽ測定開始

    '@ﾚｽﾎﾟﾝｽ用定数
    Private Const CMstrFormName                         As String = "frmxxCM0110"           '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                         As String = "Form_Load"             'ｲﾍﾞﾝﾄ名称(ﾌｫｰﾑﾛｰﾄﾞ)
    Private Const CMstrCmdLotListClick                  As String = "cmdLotList_Click"      'ｲﾍﾞﾝﾄ名称(最新取得ﾎﾞﾀﾝ)
    Private Const CMstrCmdAreaNameValidate              As String = "cmbMcGroupName_Validate"  'ｲﾍﾞﾝﾄ名称(ｴﾘｱ名のValidate)
    Private Const CMstrCmdWpIdValidate                  As String = "cmbWpID_Validate"      'ｲﾍﾞﾝﾄ名称(装置IDのValidate)
    Private Const CMstrCmdRegistClick                   As String = "cmdRegist_Click"       'ｲﾍﾞﾝﾄ名称(確定ﾎﾞﾀﾝ)
    Private Const CMstrPrvMcGroupWpNameDisp             As String = "prvMcGroupWpName_Disp" 'ｲﾍﾞﾝﾄ名称(端末情報と一致する[装置ｸﾞﾙｰﾌﾟ]/[装置名]の表示処理)

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mtypAreaEquipmentList                       As List(Of AreaEquipmentList)       '装置用途格納
    Private mlngAreaEqCnt                               As Integer                          '装置用途件数
    Private mlngLotListCnt                              As Integer                          'ﾛｯﾄ一覧情報件数
    Private mtypEqstate                                 As Eqstate                          '装置状態ﾘｽﾄ格納
    Private mblnRecipeFlowNumFlag                       As Boolean                          'ﾚｼﾋﾟ(切替)ﾌﾗｸﾞ(True：ﾚｼﾋﾟ(切替)、False：FIFO(到着順)orﾚｼﾋﾟ(固定))
    Private mblnAllClearFlag                            As Boolean                          '処理順全解除ﾌﾗｸﾞ(True：全解除、False：処理順指定)

    Private mstrMcGroupWk                               As String                           '装置ｸﾞﾙｰﾌﾟID退避用
    Private mstrWpIDWk                                  As String                           '装置ID退避用
    Private mstrMcGroupID                               As String                           '装置ｸﾞﾙｰﾌﾟID格納
    Private mstrWpID                                    As String                           '装置ID格納
    Private mstrSeqNo                                   As String                           '処理順№
    Private mblnCmdRegist                               As Boolean                          '確定ﾎﾞﾀﾝ押下ﾌﾗｸﾞ(True：確定ﾎﾞﾀﾝ押下、False：確定ﾎﾞﾀﾝ押下以外)
    Private mblnCmdFlag                                 As Boolean                          'ﾎﾞﾀﾝ制御ﾌﾗｸﾞ(True：実行可、False：実行不可)
    Private mblnLoadFlag                                As Boolean                          '起動ﾌﾗｸﾞ(True：起動、False：終了)
    Private mblnFormActivateFlag                        As Boolean                          'ﾌｫｰﾑｱｸﾃｨﾍﾞｲﾄ実行ﾌﾗｸﾞ(True：処理済、False：未処理)
    Private mtypChgSort                                 As ChgSort                          'ｿｰﾄ保持用

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

        'NSYS スクロールバーなしグリッドのマウスホイール対応
        pubVsfMouseWheelManager_Set(vsfLotWaitingList, cmdUp, cmdDown, cmdLeft, cmdRight)

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
    '作成日：2004/05/17 (Mon) 15:33:25 Y.Yamagishi
    '更新日：2010/03/11 (Thu) 16:30:20 N.Kojima
    '備　考：
    '　　　：2004/09/22 (Wed) 16:55:09 H.Wajima     起動時以外にActivate処理が実行されるため、起動時ﾌﾗｸﾞを追加
    '　　　：2004/10/04 (Mon) 11:17:52 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理追加
    '　　　：2004/10/14 (Thu) 11:29:04 M.Miura      ｿｰﾄ保持構造体を追加
    '　　　：2004/10/18 (Mon) 15:23:20 N.Kasai      0件ﾒｯｾｰｼﾞ表示ｺﾒﾝﾄｱｳﾄ
    '　　　：2005/07/22 (Fri) 16:13:03 N.Kasai      L/R表示
    '　　　：2006/09/05 (Tue) 16:57:20 T.Kitagawa   装置の処理順指定が、「ﾚｼﾋﾟ毎連続」の場合は処理順指定を不可とする(案件№01097)
    '　　　：2009/02/25 (Wed) 17:09:08 N.Kojima     ﾁｯﾌﾟ品判別説明ﾗﾍﾞﾙの制御処理追加。(案件№03402)
    '　　　：2009/07/29 (Wed) 12:56:04 N.Kojima     無機対応Phase2、組立でもﾀﾞﾐｰﾛｯﾄが流動することになったので"ﾀﾞﾐｰ"説明を表示する。(案件№03661)
    '　　　：2010/01/21 (Thu) 12:53:41 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    '　　　：2010/03/11 (Thu) 16:30:20 N.Kojima     処理限定説明ﾗﾍﾞﾙを表示する。(案件№03897)
    Private Sub Form_Load()

        Dim lblnAns             As Boolean              '戻り値格納用
        Dim lstrFormTitle       As String               'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        Dim ltypDisp            As UtilRefTmInfo        '端末設定情報格納
        Dim ltypMcGroupList     As McGroupList          '装置ｸﾞﾙｰﾌﾟ情報格納

        Try

            '@=======================
            '@ 機能ﾊﾞｰｼﾞｮﾝ判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN0260, CMstrLocalVersion)

            '@機能ﾊﾞｰｼﾞｮﾝ判定処理結果が"False：ﾊﾞｰｼﾞｮﾝ不一致"か
            If lblnAns = False Then
                Exit Sub
            End If

        '@↓2010/03/11 (Thu) 16:29:27 N.Kojima **************************************************

            '@-----------------------
            '@ 説明ﾗﾍﾞﾙ表示設定
            '@-----------------------
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

                lblTitleExecRestrictLot.Top = 92            '処理限定
                lblTitleExecRestrictLot.Left = 658

                lblTitleL.Visible = False
                lblTitleR.Visible = False
                lblTitleChip.Visible = False                'ﾁｯﾌﾟ品説明
            End If

            lblTitleExecRestrictLot.Visible = True          '処理限定
            lblTitleD.BackColor = ColorTranslator.FromWin32(CPlngVbColorOrange)        'ﾀﾞﾐｰ
            lblTitleD.Visible = True
            lblTitleHT.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)        '保留/停止

        '@↑2010/03/11 (Thu) 16:29:27 N.Kojima **************************************************


            '@各種ﾌﾗｸﾞの設定
            mblnLoadFlag = True             '起動ﾌﾗｸﾞ：True：起動
            mblnCmdFlag = True              'ﾎﾞﾀﾝ制御ﾌﾗｸﾞTrue：実行可

            '@-----------------------
            '@ ｿｰﾄ構造体の初期化
            '@-----------------------
            With mtypChgSort

                .lngCnt = 0                 'ﾃﾞｰﾀ数
                .typChgSortList = New List(Of ChgSortList)       '配列
                .blnChgWidth = False        '列幅変更ﾌﾗｸﾞ：False：未変更
                .strKey = vbNullString      'ｶﾚﾝﾄ行検索ｷｰ
            End With


            '@=======================
            '@ 機能関連情報取得
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0260, lstrFormTitle)

            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle

            '@[閉じる]ﾎﾞﾀﾝを無効にする(Load中に落とされることを回避)
            cmdClose.Enabled = False


            '@=======================
            '@ 画面初期化処理
            '@=======================
            Call prvFrmxxCM0110_Init()

            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            '@=======================
            '@ ｺﾝﾋﾟｭｰﾀ名取得(META実行時はWBTのｸﾗｲｱﾝﾄ名)
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

                    '@装置ｸﾞﾙｰﾌﾟIDと装置IDがNULL以外か
                    If .strMcGroupID <> vbNullString And .strWpID <> vbNullString Then

                        '@装置ｸﾞﾙｰﾌﾟIDと装置IDを変数に格納
                        mstrMcGroupID = .strMcGroupID
                        mstrWpID = .strWpID

                        '@起動区分が"True：子画面起動"か
                        If pblnfrmxxCM0110Kbn = True Then

                            '@[装置ｸﾞﾙｰﾌﾟ]/[装置名]ｺﾝﾎﾞを無効にする
                            cmbMcGroupName.Enabled = False              '無効
                            cmbMcGroupName.BackColor = ColorTranslator.FromWin32(CMlngColorGlay)   '背景色：ｸﾞﾚｰ
                            cmbWpID.Enabled = False
                            cmbWpID.BackColor = ColorTranslator.FromWin32(CMlngColorGlay)
                        End If

                        '@=======================
                        '@ 端末情報と一致する[装置ｸﾞﾙｰﾌﾟ]/[装置名]の表示処理
                        '@=======================
                        Call prvMcGroupWpName_Disp(mstrMcGroupID, mstrWpID)

                    Else
                        '@装置ｸﾞﾙｰﾌﾟIDまたは装置IDがNULLの場合

                        '@ﾚｽﾎﾟﾝｽ取得開始
                        Call pubResponseStart(CMstrFormName, CMstrFormLoad)

                        '@=======================
                        '@ 装置ｸﾞﾙｰﾌﾟ取得(処理区分："02：全件")
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
                        Else
                            '@装置ｸﾞﾙｰﾌﾟ取得結果が"True：取得成功"の場合

                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)
            
                            '@=======================
                            '@ [装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ設定＆作成処理
                            '@=======================
                            Call prvcmbMcGroupName_Disp(ltypMcGroupList)

                        End If
                    End If
                End With
            Else
                '@端末設定情報取得結果が"False：取得失敗"の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                Exit Sub
            End If

            '@[閉じる]ﾎﾞﾀﾝを有効にする(Load中に落とされることを回避)
            cmdClose.Enabled = True

            '@起動ﾌﾗｸﾞが"False：終了"の場合(装置ｸﾞﾙｰﾌﾟ取得でｴﾗｰになった場合)
            If mblnLoadFlag = False Then
                Exit Sub
            End If

            '@ﾌｫｰﾑｱｸﾃｨﾍﾞｲﾄ実行ﾌﾗｸﾞの初期化
            mblnFormActivateFlag = False

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"True：起動処理成功"をｾｯﾄ
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
    '作成日：2004/09/17 (Fri) 17:08:47 S.Deguchi
    '更新日：2010/01/21 (Thu) 13:12:46 N.Kojima
    '備　考：
    '　　　：2004/09/17 (Fri) 17:10:05 S.Deguchi    ﾌｫｰﾑのShowを行わないように,ﾌｫｰﾑﾛｰﾄﾞの内容を移動
    '　　　：2004/09/22 (Wed) 16:54:11 H.Wajima     起動時以外にActivate処理が実行されるため、判定処理を追加
    '　　　：2004/10/06 (Wed) 09:00:44 M.Miura      閉じるﾎﾞﾀﾝの有効/無効制御追加
    '　　　：2010/01/21 (Thu) 13:12:46 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    '　　　：2010/03/11 (Thu) 15:42:00 N.Kojima     起動区分の縛りをｺﾒﾝﾄｱｳﾄ。(案件№03897)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@ﾌｫｰﾑｱｸﾃｨﾍﾞｲﾄ実行ﾌﾗｸﾞが"True：処理済"か
            If mblnFormActivateFlag = True Then

                Exit Sub
            Else
                '@ﾌｫｰﾑｱｸﾃｨﾍﾞｲﾄ実行ﾌﾗｸﾞが"False：未処理"の場合

                '@ﾌｫｰﾑｱｸﾃｨﾍﾞｲﾄ実行ﾌﾗｸﾞに"True：処理済"をｾｯﾄ
                mblnFormActivateFlag = True
            End If

        '@↓2010/03/11 (Thu) 15:42:00 N.Kojima **************************************************

        '    '@起動区分が"True：子画面起動"か
        '    If pblnfrmxxCM0110Kbn = True Then

            '@連続処理ﾛｯﾄ数が数値、かつ1以上か("ﾚｼﾋﾟ(切替)"or"ﾚｼﾋﾟ(切替)限定"か)
            If IsNumeric(mtypEqstate.strRecipeFlowNum) = True And _
                CInt(mtypEqstate.strRecipeFlowNum) > 0 Then

                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM8RW>$$処理順ルールに[%1]が指定されています。$ロット処理順変更はできません。"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008R, lblRecipeRule.Text)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            End If

            With vsfLotWaitingList

                '@[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞが有効、かつ、ﾃﾞｰﾀが表示されているか
                If .Enabled = True And .Rows.Count >= .Rows.Fixed Then
                    'NSYS イベントハンドラーを削除
                    RemoveHandler cmbMcGroupName.Validating, AddressOf cmbMcGroupName_Validate
                    '@[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfLotWaitingList)
                    'NSYS イベントハンドラーを元に戻す
                    AddHandler cmbMcGroupName.Validating, AddressOf cmbMcGroupName_Validate
                End If
            End With

        '    End If

        '@↑2010/03/11 (Thu) 15:42:00 N.Kojima **************************************************

            'NSYS Activate中にpublngMsgBox等で別ウィンドウを表示するとActivateがキャンセルされるため、再Activateする
            'NSYS Activateイベント中にActivate()を呼び出しても作用しないため、遅延で実行する。ラムダ式使用
            Dim lfuncActivate As Action = Sub()
                                              Me.Activate()
                                          End Sub
            Me.BeginInvoke(lfuncActivate)

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
    '作成日：2004/05/26 (Wed) 09:36:45 Y.Yamagishi
    '更新日：2010/01/21 (Thu) 12:53:41 N.Kojima
    '備　考：
    '　　　：2007/07/05 (Thu) 13:32:33 N.Kasai      ｸﾞﾘｯﾄﾞ機能共通化
    '　　　：2010/01/21 (Thu) 12:53:41 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@=======================
            '@ ｸﾞﾘｯﾄﾞｷｰ制御処理(ｸﾞﾘｯﾄﾞ共通処理：上下ｽｸﾛｰﾙﾎﾞﾀﾝの制御)
            '@=======================
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfLotWaitingList, cmdUP, cmdDown)

            '@=======================
            '@ ｸﾞﾘｯﾄﾞｷｰ制御処理(ｸﾞﾘｯﾄﾞ共通処理：左右ｽｸﾛｰﾙﾎﾞﾀﾝの制御)
            '@=======================
            Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfLotWaitingList, cmdLeft, cmdRight)


            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name

                '@〓 [装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ 〓
                Case cmbMcGroupName.Name

                    '@Enterｷｰが押下されたか
                    If e.KeyCode = Keys.Return Then

                        '@装置ｸﾞﾙｰﾌﾟが選択されているか
                        If cmbMcGroupName.Text <> vbNullString Then

                            '@=======================
                            '@ [装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞValidate処理
                            '@=======================
                            Call cmbMcGroupName_Validate(True, New CancelEventArgs)
                        Else
                            '@装置ｸﾞﾙｰﾌﾟが未選択の場合

                            '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
                            SendKeys.SendWait(CMstrVbKeyTab)
                        End If

                        Exit Sub
                    End If

                '@〓 [装置名]ｺﾝﾎﾞ 〓
                Case cmbWpID.Name

                    '@Enterｷｰが押下されたか
                    If e.KeyCode = Keys.Return Then

                        '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄし、ｷｰｺｰﾄﾞを無効にする
                        SendKeys.SendWait(CMstrVbKeyTab)
                        e.Handled = True

                        '@[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞが有効か
                        If vsfLotWaitingList.Enabled = True Then

                            '@[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(vsfLotWaitingList)
                        End If

                        Exit Sub
                    End If

                '@〓 [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ 〓
                Case vsfLotWaitingList.Name

                    With vsfLotWaitingList

                        '@Enterｷｰが押下されたか
                        If e.KeyCode = Keys.Return Then

                            '@=======================
                            '@ [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞClick時処理
                            '@=======================
                            Call vsfLotWaitingList_Click(vsfLotWaitingList, New EventArgs())

                        End If
                    End With

                '@〓 その他 〓
                Case Else

                    '@Enterｷｰが押下されたか
                    If e.KeyCode = Keys.Return Then

                        '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄし、ｷｰｺｰﾄﾞを無効にする
                        SendKeys.SendWait(CMstrVbKeyTab)
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
    '作成日：2004/05/25 (Tue) 09:19:42 Y.Yamagishi
    '更新日：2010/01/21 (Thu) 12:53:41 N.Kojima
    '備　考：
    '　　　：2004/10/26 (Tue) 17:04:55 T.Kitagawa　 DoEvents対応
    '　　　：2004/11/01 (Mon) 15:35:54 N.Kasai      閉じるﾎﾞﾀﾝ統合
    '　　　：2006/09/05 (Tue) 16:51:35 T.Kitagawa   mtypEqstate追加(案件№01097)
    '　　　：2010/01/21 (Thu) 12:53:41 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      'ACT開放結果格納用

        Try

            '@DoEventsﾌﾗｸﾞが"True：他の処理実行中"か
            If pblnTrnFlag = True Then

                '@終了処理をｷｬﾝｾﾙ
                e.Cancel = True
                Exit Sub
            End If

            '@ﾌｫｰﾑの"×"ﾎﾞﾀﾝ押下でのCallか
            If mblnCloseFromControlMenu Then

                '@=======================
                '@ [閉じる]ﾎﾞﾀﾝ押下処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender,e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If

            '@各種ﾓｼﾞｭｰﾙ構造体/配列の初期化
            If Not mtypAreaEquipmentList Is Nothing Then
                mtypAreaEquipmentList.Clear()
            End If
            If Not mtypChgSort.typChgSortList Is Nothing Then
                mtypChgSort.typChgSortList.Clear()
            End If
            If Not mtypEqstate.typPortList Is Nothing Then
                mtypEqstate.typPortList.Clear()
            End If
            mstrMcGroupWk = vbNullString
            mstrWpIDWk = vbNullString

            '@起動区分が"True：子画面起動"か
            If pblnfrmxxCM0110Kbn = True Then

                '@起動区分を初期化
                pblnfrmxxCM0110Kbn = False
            Else
                '@起動区分が"False：単独起動"の場合

                '@ACT初期化ﾌﾗｸﾞが"True：自前で初期化済"か
                If pblnActInitFlg = True Then
                    
                    '@ACTｵﾌﾞｼﾞｪｸﾄの開放
                    lblnAnsTerm = pubblnAct_Term

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

    '関数名：cmbMcGroupName_Change
    '機　能：[装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/24 (Mon) 10:17:54 Y.Yamagishi
    '更新日：2010/01/21 (Thu) 13:12:46 N.Kojima
    '備　考：
    '　　　：2010/01/21 (Thu) 12:53:41 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    Private Sub cmbMcGroupName_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGroupName.Change

        Try

            '@=======================
            '@ 画面初期化処理
            '@=======================
            Call prvFrmxxCM0110_Init()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：[装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/24 (Mon) 10:18:34 Y.Yamagishi
    '更新日：2010/01/21 (Thu) 12:53:41 N.Kojima
    '備　考：
    '　　　：2010/01/21 (Thu) 12:53:41 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    Private Sub cmbMcGroupName_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGroupName.CloseUp

        Try

            '@[装置ｸﾞﾙｰﾌﾟ]が選択されているか
            If cmbMcGroupName.Text <> vbNullString Then

                '@=======================
                '@ [装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞValidate処理
                '@=======================
                Call cmbMcGroupName_Validate(True, New CancelEventArgs)

                '@[装置名]ｺﾝﾎﾞが有効、かつﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True：起動処理成功"か
                If cmbWpID.Enabled = True And pblnFormLoad = True Then

                    '@[装置名]ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbWpID)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：[装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ　Validate処理(ﾌｫｰｶｽﾛｽﾄ時入力ﾁｪｯｸ処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/05/24 (Mon) 11:00:10 Y.Yamagishi
    '更新日：2010/01/21 (Thu) 12:53:41 N.Kojima
    '備　考：
    '　　　：2004/10/18 (Mon) 15:27:17 N.Kasai      0件ﾒｯｾｰｼﾞｺﾒﾝﾄｱｳﾄ
    '　　　：2004/11/15 (Mon) 09:46:50 N.Kojima     引継ぎの場合は装置ｺﾝﾎﾞを有効にしない
    '　　　：2010/01/21 (Thu) 12:53:41 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    Private Sub cmbMcGroupName_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbMcGroupName.Validating
        
        Dim lblnAns                     As Boolean              '戻り値格納用

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@前回選択の装置ｸﾞﾙｰﾌﾟと同じか
            If mstrMcGroupWk = cmbMcGroupName.Text Then

                '@[装置名]ｺﾝﾎﾞが有効、かつﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True：起動処理成功"か
                If cmbWpID.Enabled = True And pblnFormLoad = True Then

                    '@[装置名]ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbWpID)
                End If

                Exit Sub
            End If

            '@=======================
            '@ 画面初期化処理
            '@=======================
            Call prvFrmxxCM0110_Init()


            '@装置名退避用変数を初期化
            mstrWpIDWk = vbNullString

            '@装置ｸﾞﾙｰﾌﾟが未選択か
            If cmbMcGroupName.Text = vbNullString Then

                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True：起動処理成功"か
                If pblnFormLoad = True Then

                    '@[閉じる]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If

                Exit Sub
            Else
                '@装置ｸﾞﾙｰﾌﾟが選択されている場合

                '@起動区分が"False：単独起動"か
                If pblnfrmxxCM0110Kbn = False Then

                    '@[装置名]ｺﾝﾎﾞを有効にする
                    cmbWpID.Enabled = True
                End If
            End If


            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdAreaNameValidate)

            '@=======================
            '@ ｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置用途情報取得(処理区分："20：装置ｸﾞﾙｰﾌﾟ別")
            '@=======================
            lblnAns = pubblnEqAreaCurList_Sel(CMstreq__areacurlistVer, _
                                              vbNullString, _
                                              pstrSBID, _
                                              mtypAreaEquipmentList, _
                                              mlngAreaEqCnt, _
                                              CPstrCD20, _
                                              cmbMcGroupName.Value)

            '@ｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置用途情報取得結果が"False：取得失敗"か
            If lblnAns = False Then

                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdAreaNameValidate)

                '@=======================
                '@ 画面初期化処理
                '@=======================
                Call prvFrmxxCM0110_Init()

                '@装置ｸﾞﾙｰﾌﾟ退避用変数の初期化
                mstrMcGroupWk = vbNullString

                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrCmdAreaNameValidate)

            '@装置ｸﾞﾙｰﾌﾟ退避用変数に現在選択されている装置ｸﾞﾙｰﾌﾟを格納
            mstrMcGroupWk = cmbMcGroupName.Text


            '@=======================
            '@ [装置名]ｺﾝﾎﾞ設定＆作成処理
            '@=======================
            Call prvcmbWpID_Disp(mtypAreaEquipmentList, mlngAreaEqCnt)


            '@ｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置ﾃﾞｰﾀ件数が1件か
            If mlngAreaEqCnt = 1 Then

                '@1件のﾃﾞｰﾀを直接表示
                cmbWpID.ListIndex = mlngAreaEqCnt - 1

                '@=======================
                '@ [装置名]ｺﾝﾎﾞValidate処理
                '@=======================
                Call cmbWpID_Validate(False, New CancelEventArgs)
            Else
                '@ｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置ﾃﾞｰﾀ件数が1件以外の場合

                '@[装置名]ｺﾝﾎﾞが有効、かつﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True：起動処理成功"か
                If cmbWpID.Enabled = True And pblnFormLoad = True Then

                    '@[装置名]ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbWpID)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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

    '関数名：cmbWpID_Change
    '機　能：[装置名]ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/24 (Mon) 10:31:45 Y.Yamagishi
    '更新日：2010/01/21 (Thu) 12:53:41 N.Kojima
    '備　考：
    '　　　：2004/10/14 (Thu) 11:30:10 M.Miura      ｶﾚﾝﾄ行検索ｷｰの初期化を追加
    '　　　：2010/01/21 (Thu) 12:53:41 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    Private Sub cmbWpID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWpID.Change

        Try

            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString

            '@上下左右(▲,▼,<<,>>)ｽｸﾛｰﾙﾎﾞﾀﾝを無効にする
            cmdUP.Enabled = False
            cmdDown.Enabled = False
            cmdLeft.Enabled = False
            cmdRight.Enabled = False

            '@各種ﾗﾍﾞﾙの初期化
            lblNowDate.Text = vbNullString           '情報取得日時
            lblLotCnt.Text = vbNullString            '該当件数
            lblWpStatus.Text = vbNullString          '装置状態
            lblMode.Text = vbNullString              'ﾓｰﾄﾞ
            lblWpTrnStatus.Text = vbNullString       '処理状態
            lblRecipeRule.Text = vbNullString        '処理順ﾙｰﾙ
            lblNowSeqNum.Text = vbNullString         '処理順№


            '@=======================
            '@ [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ初期化処理
            '@=======================
            Call prvVsfLotWaitingList_Init()


            '@装置ｸﾞﾙｰﾌﾟが未選択、または装置名が未選択か
            If cmbMcGroupName.Value = vbNullString Or cmbWpID.Value = vbNullString Then

                '@[最新取得]ﾎﾞﾀﾝを無効にする
                cmdLotList.Enabled = False
            Else
                '@装置ｸﾞﾙｰﾌﾟ/装置名が両方選択されている場合

                '@[最新取得]ﾎﾞﾀﾝを有効にする
                cmdLotList.Enabled = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWpID_Change"
                .strErrMessage = vbNullString
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
    '作成日：2004/05/26 (Wed) 09:38:43 Y.Yamagishi
    '更新日：2010/01/21 (Thu) 12:53:41 N.Kojima
    '備　考：
    '　　　：2010/01/21 (Thu) 12:53:41 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    Private Sub cmbWpID_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWpID.CloseUp

        Try

            '@=======================
            '@ [装置名]ｺﾝﾎﾞValidate処理
            '@=======================
            Call cmbWpID_Validate(True, New CancelEventArgs)

            '@[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞにﾃﾞｰﾀあり＆有効、かつﾌｫｰﾑ起動済みか
            If vsfLotWaitingList.Rows.Count > 1 And _
                vsfLotWaitingList.Enabled = True And _
                pblnFormLoad = True Then

                '@[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfLotWaitingList)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWpID_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWpID_Validate
    '機　能：[装置名]ｺﾝﾎﾞ　Validate処理(ﾌｫｰｶｽﾛｽﾄ時入力ﾁｪｯｸ処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/05/24 (Mon) 13:15:47 Y.Yamagishi
    '更新日：2010/01/21 (Thu) 12:53:41 N.Kojima
    '備　考：
    '　　　：2004/10/18 (Mon) 15:28:20 N.Kasai  0件ﾒｯｾｰｼﾞｺﾒﾝﾄｱｳﾄ
    '　　　：2010/01/21 (Thu) 12:53:41 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    Private Sub cmbWpID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbWpID.Validating

        Dim llngWpCnt       As Integer      '装置ID行ｶｳﾝﾀ

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@[装置名]が未選択、または前回選択装置と同じか
            If cmbWpID.Value = vbNullString Or mstrWpIDWk = cmbWpID.Text Then
                Exit Sub
            End If

            '@=======================
            '@ [最新取得]ﾎﾞﾀﾝ押下時処理
            '@=======================
            Call cmdLotList_Click(sender, e)

            '@ﾛｯﾄ一覧ﾃﾞｰﾀ件数が1件以上、[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞが有効、かつﾌｫｰﾑ起動済みか
            If mlngLotListCnt > 0 And _
                vsfLotWaitingList.Enabled = True And _
                pblnFormLoad = True Then

                '@[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                'NSYS cmbWpID_Validateイベントを抑止
                RemoveHandler cmbWpID.Validating, AddressOf cmbWpID_Validate
                Call pubSetFocus(vsfLotWaitingList)
                'NSYS イベントハンドラーを元に戻す
                AddHandler cmbWpID.Validating, AddressOf cmbWpID_Validate
            End If

            '@装置件数分ﾙｰﾌﾟ
            For llngWpCnt = 0 To mlngAreaEqCnt - 1

                '@取得装置情報の装置IDと現在選択されている装置のIDが同じか
                If cmbWpID.Value = mtypAreaEquipmentList(llngWpCnt).strWpID Then
                    Exit For
                End If
            Next llngWpCnt

            '@[最新取得]ﾎﾞﾀﾝを有効にする
            cmdLotList.Enabled = True

            '@装置ID退避用変数に現在選択装置のIDを退避
            mstrWpIDWk = cmbWpID.Text

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWpID_Validate"
                .strErrMessage = vbNullString
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
    '作成日：2004/05/24 (Mon) 10:37:41 Y.Yamagishi
    '更新日：2010/03/11 (Thu) 14:01:36 N.Kojima
    '備　考：
    '　　　：2004/09/13 (Mon) 13:47:43 N.Kojima　   確定ﾎﾞﾀﾝﾛｯｸ処理追加(781～782行目)
    '　　　：2004/10/18 (Mon) 15:26:06 N.Kasai      0件ﾒｯｾｰｼﾞｺﾒﾝﾄｱｳﾄ
    '　　　：2004/10/26 (Tue) 17:01:23 T.Kitagawa   DoEvents対応
    '　　　：2006/09/05 (Tue) 17:42:14 T.Kitagawa   装置の処理順指定が、「ﾚｼﾋﾟ毎連続」の場合は処理順指定を不可とする(案件№01097)
    '　　　：2008/02/26 (Tue) 12:44:11 M.Koni       処理順解除失敗時(ｴﾗｰ時)の2重ﾎﾟｯﾌﾟｱｯﾌﾟ抑制処理追加(案件No.01536)
    '　　　：2008/06/25 (Wed) 08:30:00 S.Ochiai     部分ﾚｼﾋﾟ対応(案件№03008)、及びﾒｯｾｰｼﾞ構造を抜本的に変更
    '　　　：2008/07/01 (Tue) 17:34:53 M.Koni       "util.regtminfo"応答ﾒｯｾｰｼﾞ変更対応<案件No.03006>
    '　　　：2010/01/21 (Thu) 12:53:41 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    '　　　：2010/03/11 (Thu) 14:01:36 N.Kojima     処理順ﾙｰﾙが"ﾚｼﾋﾟ(切替)"の場合の処理をｺﾒﾝﾄｱｳﾄ。(案件№03897)
    Private Sub cmdLotList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotList.Click

        Dim lblnAns                         As Boolean              '戻り値格納用
        Dim llngLotListCnt                  As Integer              'ﾛｯﾄ一覧ﾃﾞｰﾀ件数格納用
        Dim ltypLotListReq                  As LotListReq           'ﾛｯﾄ一覧要求格納用
        Dim ltypLotListAns                  As LotListAns           'ﾛｯﾄ一覧応答格納用
        Dim ltypUtilRegTmInfo               As UtilRegTmInfo        '端末設定情報格納用

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾎﾞﾀﾝ制御ﾌﾗｸﾞが"False：実行不可"か
            If mblnCmdFlag = False Then
                Exit Sub
            End If

            '@各種ﾓｼﾞｭｰﾙ変数の初期化
            mblnCmdFlag = False             'ﾎﾞﾀﾝ制御ﾌﾗｸﾞ
            mlngLotListCnt = 0              'ﾛｯﾄ一覧情報件数

            '@各種ﾎﾞﾀﾝを無効にする
            cmdBack.Enabled = False         '[1つ前に戻る]
            cmdAllCancel.Enabled = False    '[処理順全解除]

            '@***********************
            '@ 要求ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotListReq

                .strMsgVer = CMstrlot_list____Ver       'Msgﾊﾞｰｼﾞｮﾝ
                .strClassDivision = CPstrCD25           '処理区分(25：ﾛｯﾄ処理順変更)
                .strSbID = pstrSBID                     'ｼｽﾃﾑﾌﾞﾛｯｸID
                .strWpID = cmbWpID.Value                '装置ID
            End With

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdLotListClick)

            '@=======================
            '@ ﾛｯﾄ一覧情報取得
            '@=======================
            lblnAns = pubblnLotList_Sel(ltypLotListReq, _
                                        ltypLotListAns, _
                                        llngLotListCnt)

            '@ﾛｯﾄ一覧情報取得結果が"True：取得成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdLotListClick)


                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrCmdLotListClick)

                '@=======================
                '@ 装置状態取得
                '@=======================
                lblnAns = pubblnEqState_Sel(CMstreq__state___Ver, _
                                            cmbWpID.Value, _
                                            mtypEqstate)

                '@装置状態取得結果が"True：取得成功"か
                If lblnAns = True Then

                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrCmdLotListClick)

        '@↓2010/03/11 (Thu) 13:49:55 N.Kojima **************************************************
        '            '@ﾚｼﾋﾟ(切替)ﾌﾗｸﾞの初期化
        '            mblnRecipeFlowNumFlag = False
        '
        '            '@連続処理ﾛｯﾄ数が数値、かつ1以上か(ﾚｼﾋﾟ(切替)か)
        '            If IsNumeric(mtypEqstate.strRecipeFlowNum) = True And _
        '                CLng(mtypEqstate.strRecipeFlowNum) > 0 Then
        '
        '                '@ﾚｼﾋﾟ切替ﾌﾗｸﾞに"True：ﾚｼﾋﾟ(切替)"をｾｯﾄ
        '                mblnRecipeFlowNumFlag = True
        '            End If
        '@↑2010/03/11 (Thu) 13:49:55 N.Kojima **************************************************

                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(CMstrFormName, CMstrCmdLotListClick)

                    '@=======================
                    '@ 端末設定情報登録
                    '@=======================
                    lblnAns = pubblnUtilRegTmInfo_Upd(pstrSBID, _
                                                      CMstrutilregtminfoVer, _
                                                      CPstrCD26, pstrComputerName, _
                                                      ltypUtilRegTmInfo, _
                                                      cmbWpID.Value, _
                                                      , _
                                                      , _
                                                      cmbMcGroupName.Value)

                    '@端末設定情報登録結果が"True：登録成功"か
                    If lblnAns = True Then

                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrCmdLotListClick)
                    Else
                        '@端末設定情報登録結果が"False：登録失敗"の場合

                        '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmdLotListClick)
                    End If
                Else
                    '@装置状態取得結果が"False：取得失敗"の場合

                    '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdLotListClick)

                    '@=======================
                    '@ [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ初期化処理
                    '@=======================
                    Call prvVsfLotWaitingList_Init()

                    '@[装置名]ｺﾝﾎﾞが有効、かつﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True：起動処理成功"か
                    If cmbWpID.Enabled = True And pblnFormLoad = True Then

                        '@[装置名]ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmbWpID)
                    End If

                    '@ﾎﾞﾀﾝ制御ﾌﾗｸﾞに"True：実行可"をｾｯﾄ
                    mblnCmdFlag = True

                    Exit Sub
                End If
            Else
                '@ﾛｯﾄ一覧情報取得結果が"False：取得失敗"の場合

                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdLotListClick)

                '@=======================
                '@ [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ初期化処理
                '@=======================
                Call prvVsfLotWaitingList_Init()

                '@[装置名]ｺﾝﾎﾞが有効、かつﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True：起動処理成功"か
                If cmbWpID.Enabled = True And pblnFormLoad = True Then

                    '@[装置名]ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbWpID)
                End If

                '@ﾎﾞﾀﾝ制御ﾌﾗｸﾞに"True：実行可"をｾｯﾄ
                mblnCmdFlag = True

                Exit Sub
            End If


            '@ﾛｯﾄ一覧情報件数格納用ﾓｼﾞｭｰﾙ変数にｾｯﾄ
            mlngLotListCnt = llngLotListCnt

            '@=======================
            '@ 装置状態表示処理
            '@=======================
            Call prvWpStatus_Disp(ltypLotListAns)

            '@=======================
            '@ [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ作成＆表示処理
            '@=======================
            Call prvVsfLotWaitingList_Disp(ltypLotListAns, llngLotListCnt)

            '@[確定]ﾎﾞﾀﾝ押下ﾌﾗｸﾞが"False：確定ﾎﾞﾀﾝ押下以外"か
            If mblnCmdRegist = False Then

                '@[確定]ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False

                '@各種ﾗﾍﾞﾙを表示
                lblNowDate.Text = Format$(CDate(Now), CPstrDateFormat)                 '情報取得日時
                lblLotCnt.Text = Format$(CInt(llngLotListCnt), CPstrDateFormatKanma)   '該当件数
            End If

            '@DoEvents前にﾌﾗｸﾞ・画面無効化の設定を行う
            'Call pubDoEventsBefoer(Me)

            'DoEvents

            '@DoEvents後にﾌﾗｸﾞ・画面有効化の設定を行う
            'Call pubDoEventsAfter(Me)

            '@ﾎﾞﾀﾝ制御ﾌﾗｸﾞに"True：実行可"をｾｯﾄ
            mblnCmdFlag = True

        '@↓2010/03/11 (Thu) 14:01:18 N.Kojima **************************************************
        '    '@ﾚｼﾋﾟ(切替)ﾌﾗｸﾞが"True：ﾚｼﾋﾟ(切替)"か
        '    If mblnRecipeFlowNumFlag = True Then
        '
        '        '@表示ﾒｯｾｰｼﾞ変換
        '        '@「"<TRM8RW>$$処理順ルールに[レシピ(切替)]が指定されています。$ロット処理順変更はできません。"」のﾒｯｾｰｼﾞ表示
        '        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008R)
        '        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxCM0110.Caption, True, 16)
        '    End If
        '@↑2010/03/11 (Thu) 14:01:18 N.Kojima **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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

    '関数名：vsfLotWaitingList_AfterUserResize
    '機　能：[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ﾕｰｻﾞｰﾘｻｲｽﾞ後処理
    '引　数：Row：行番号
    '　　　：Col：列番号
    '戻り値：なし
    '作成日：2004/05/26 (Wed) 09:39:15 Y.Yamagishi
    '更新日：2010/01/21 (Thu) 12:53:41 N.Kojima
    '備　考：
    '　　　：2007/07/09 (Mon) 13:26:39 N.Kasai      ｸﾞﾘｯﾄﾞ共通
    '　　　：2010/01/21 (Thu) 12:53:41 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    Private Sub vsfLotWaitingList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfLotWaitingList.AfterResizeColumn, vsfLotWaitingList.AfterResizeRow

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotWaitingList.Rows.Count <= vsfLotWaitingList.Rows.Fixed Then
                Return
            End If

            '@列幅変更ﾌﾗｸﾞに"True：変更あり"をｾｯﾄ
            mtypChgSort.blnChgWidth = True

            '@=======================
            '@ 左右("<<",">>")ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
            '@=======================
            Call pubCmdLREnable_Set(vsfLotWaitingList, cmdLeft, cmdRight)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotWaitingList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotWaitingList_BeforeRowColChange
    '機　能：[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ｶﾚﾝﾄｾﾙ変更前処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/05/26 (Wed) 09:39:56 Y.Yamagishi
    '更新日：2010/01/21 (Thu) 12:53:41 N.Kojima
    '備　考：
    '　　　：2010/01/21 (Thu) 12:53:41 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    Private Sub vsfLotWaitingList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfLotWaitingList.BeforeRowColChange

        Dim lstrUseName     As String       '用途

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotWaitingList.Rows.Count <= vsfLotWaitingList.Rows.Fixed Then
                Return
            End If

            '@旧行と新行が異なり、かつ新行がﾃﾞｰﾀ行か
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then

                '@新行の№をﾛｰｶﾙ変数に格納
                lstrUseName = vsfLotWaitingList.GetData(e.NewRange.TopRow, CMlngvsfWaitListColTitle)

                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ｷｬﾘｱID、大工程、小工程)
                mtypChgSort.strKey = vsfLotWaitingList.GetData(e.NewRange.TopRow, CMlngvsfWaitListCarrierID) & _
                                     vsfLotWaitingList.GetData(e.NewRange.TopRow, CMlngvsfWaitListOpID) & _
                                     vsfLotWaitingList.GetData(e.NewRange.TopRow, CMlngvsfWaitListStepID)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotWaitingList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotWaitingList_AfterSort
    '機　能：[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ｿｰﾄ後処理
    '引　数：Col    ：ｿｰﾄした列の番号
    '　　　：Order  ：ｿｰﾄ方法
    '戻り値：なし
    '作成日：2004/05/24 (Mon) 14:26:59 Y.Yamagishi
    '更新日：2010/01/21 (Thu) 12:53:41 N.Kojima
    '備　考：
    '　　　：2010/01/21 (Thu) 12:53:41 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    Private Sub vsfLotWaitingList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotWaitingList.AfterSort

        Try

            'BeforeSortで除外していたRowColChangeイベントを復帰
            AddHandler vsfLotWaitingList.BeforeRowColChange, AddressOf vsfLotWaitingList_BeforeRowColChange

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotWaitingList.Rows.Count <= vsfLotWaitingList.Rows.Fixed Then
                Return
            End If

            '@-----------------------
            '@ ｿｰﾄ情報格納
            '@-----------------------
            With mtypChgSort

                .lngCnt = .lngCnt + 1                       'ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                Dim typChgSortListtmp = New ChgSortList     'ｿｰﾄ配列の再定義
                typChgSortListtmp.lngCol = e.Col       'ｿｰﾄ列番号を格納
                typChgSortListtmp.lngOrder = e.Order   'ｿｰﾄ方法を格納(昇順/降順)
                .typChgSortList.Add(typChgSortListtmp)
            End With

            '@=======================
            '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納処理(ｸﾞﾘｯﾄﾞ、保持列)(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfAfterSort(vsfLotWaitingList, CMlngvsfWaitListCarrierID & vbTab & _
                                                    CMlngvsfWaitListOpID & vbTab & _
                                                    CMlngvsfWaitListStepID, cmdUP, cmdDown, True,True,True,False,True)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotWaitingList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotWaitingList_BeforeSort
    '機　能：[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ｿｰﾄ前処理
    '引　数：Col    ：ｿｰﾄした列の番号
    '　　　：Order  ：並べ替え方法
    '戻り値：なし
    '作成日：2004/05/24 (Mon) 14:27:02 Y.Yamagishi
    '更新日：2010/01/21 (Thu) 12:53:41 N.Kojima
    '備　考：
    '　　　：2010/01/21 (Thu) 12:53:41 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    Private Sub vsfLotWaitingList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotWaitingList.BeforeSort

        Try

            'NSYS 不要なHandler処理を抑止
            RemoveHandler vsfLotWaitingList.BeforeRowColChange, AddressOf vsfLotWaitingList_BeforeRowColChange

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotWaitingList.Rows.Count <= vsfLotWaitingList.Rows.Fixed Then
                Return
            End If

            '@=======================
            '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納処理(ｸﾞﾘｯﾄﾞ、保持列)(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfBeforeSort(vsfLotWaitingList, CMlngvsfWaitListCarrierID & vbTab & _
                                                     CMlngvsfWaitListOpID & vbTab & _
                                                     CMlngvsfWaitListStepID)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotWaitingList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotWaitingList_Click
    '機　能：[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/24 (Mon) 14:30:12 Y.Yamagishi
    '更新日：2010/03/11 (Thu) 14:42:56 N.Kojima
    '備　考：
    '　　　：2005/09/06 (Tue) 11:19:32 T.Kitagawa   SCHﾘﾘｰｽに伴い、Fﾓｰﾄﾞ時は処理順変更を無効にする(不具合№3092)
    '　　　：2006/09/05 (Tue) 17:27:23 T.Kitagawa   装置の処理順指定が、「ﾚｼﾋﾟ毎連続」の場合は処理順指定を不可とする(案件№01097)
    '　　　：2010/01/21 (Thu) 12:53:41 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    '　　　：2010/03/11 (Thu) 14:42:56 N.Kojima     処理可能ﾚｼﾋﾟの判定を追加。(案件№03897)
    Private Sub vsfLotWaitingList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotWaitingList.Click

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotWaitingList.Rows.Count <= vsfLotWaitingList.Rows.Fixed Then
                Return
            End If

            'NSYS ヘッダクリックの場合は処理を抜ける
            If vsfLotWaitingList.Row = 0 Then
                Exit Sub
            End If

        '@↓2010/03/11 (Thu) 14:06:32 N.Kojima **************************************************

        '    '@ﾓｰﾄﾞ(運用ﾓｰﾄﾞ)が"F"、または処理順ﾙｰﾙが"ﾚｼﾋﾟ(切替)"か
        '    If lblMode.Caption = CPstrF Or _
        '        mblnRecipeFlowNumFlag = True Then
        '
        '        Exit Sub
        '    End If

            '@処理順ﾙｰﾙが"1：ﾚｼﾋﾟ(切替)"or"4：ﾚｼﾋﾟ(切替)限定"か
            If mtypEqstate.strCollectTypeFlag = CStr(CPlngNumRecipeFlowNum) Or _
                mtypEqstate.strCollectTypeFlag = CStr(CPlngNumRecipeFlowNumSameNG) Then

                '@"ﾚｼﾋﾟ(切替)"or"ﾚｼﾋﾟ(切替)限定"の場合は無条件でﾛｯﾄ処理順変更不可。
                Exit Sub
            End If

        '@↑2010/03/11 (Thu) 14:06:32 N.Kojima **************************************************


            '@***********************
            '@ 処理順№の採番は001～998迄とする
            '@***********************
            With vsfLotWaitingList


        '@↓2010/03/11 (Thu) 14:20:58 N.Kojima **************************************************

                '@選択ﾛｯﾄが"0：処理可能ﾚｼﾋﾟ"か
                If .GetData(.Row, CMlngvsfWaitListAvailableRecipeFlag) = CPstrZero Then

        '@↑2010/03/11 (Thu) 14:20:58 N.Kojima **************************************************


                    '@現在処理順№が998以下か
                    If lblNowSeqNum.Text < CMstrSeqNumEntryMax Then

                        '@変更後処理順№がNULLか
                        If .GetData(.Row, CMlngvsfWaitListSeqNum) = vbNullString Then

                            '@処理順№をｲﾝｸﾘﾒﾝﾄする
                            mstrSeqNo = CStr(CInt(mstrSeqNo) + 1)

                            '@現在の処理順№を変更後処理順№列に格納する
                            .SetData(.Row, CMlngvsfWaitListSeqNum, Format$(CInt(mstrSeqNo), CMstrSeqNo))

                            '@[現在処理順]ﾗﾍﾞﾙに現在処理順№を表示する
                            lblNowSeqNum.text = Format$(CInt(mstrSeqNo), CMstrSeqNo)

                        End If
                    End If
                End If

                '@現在処理順№が1以上か
                If CInt(lblNowSeqNum.Text) > 0 Then

                    '@各種ﾎﾞﾀﾝを有効にする
                    cmdBack.Enabled = True      '[一つ前に戻る]
                    cmdRegist.Enabled = True    '[確定]
                End If

                '@時間制限がNULL以外か
                If .GetData(.Row, CMlngvsfWaitListLimitTime) <> vbNullString Then

                    '@[時間制限表示]ﾎﾞﾀﾝを有効にする
                    cmdTimeRestrictDisp.Enabled = True
                Else
                    '@時間制限がNULLの場合

                    '@[時間制限表示]ﾎﾞﾀﾝを無効にする
                    cmdTimeRestrictDisp.Enabled = False
                End If

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLotWaitingList_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：[上(▲)ｽｸﾛｰﾙ]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/26 (Wed) 09:38:13 Y.Yamagishi
    '更新日：2010/01/21 (Thu) 12:53:41 N.Kojima
    '備　考：
    '　　　：2010/01/21 (Thu) 12:53:41 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
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
            Call pubVsfCmdUp(vsfLotWaitingList, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：[下(▼)ｽｸﾛｰﾙ]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/26 (Wed) 09:38:23 Y.Yamagishi
    '更新日：2010/01/21 (Thu) 12:53:41 N.Kojima
    '備　考：
    '　　　：2010/01/21 (Thu) 12:53:41 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
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
            Call pubVsfCmdDown(vsfLotWaitingList, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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

    '関数名：cmdLeft_Click
    '機　能：[左(<<)ｽｸﾛｰﾙ]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/26 (Wed) 09:37:30 Y.Yamagishi
    '更新日：2010/01/21 (Thu) 12:53:41 N.Kojima
    '備　考：
    '　　　：2004/11/15 (Mon) 14:23:36 H.Wajima     ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ処理追加(不具合№219)
    '　　　：2007/07/05 (Thu) 12:15:22 N.Kasai      ｸﾞﾘｯﾄﾞ機能共通化
    '　　　：2010/01/21 (Thu) 12:53:41 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
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
            Call pubVsfCmdLeft(vsfLotWaitingList, cmdLeft, cmdRight)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：[右(>>)ｽｸﾛｰﾙ]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/26 (Wed) 09:37:51 Y.Yamagishi
    '更新日：2010/01/21 (Thu) 12:53:41 N.Kojima
    '備　考：
    '　　　：2004/11/15 (Mon) 14:23:11 H.Wajima     ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ処理追加(不具合№219)
    '　　　：2007/07/05 (Thu) 13:20:35 N.Kasai      ｸﾞﾘｯﾄﾞ機能共通化
    '　　　：2010/01/21 (Thu) 12:53:41 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
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
            Call pubVsfCmdRight(vsfLotWaitingList, cmdLeft, cmdRight)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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

    '関数名：cmdRegist_Click
    '機　能：[確定]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/25 (Tue) 10:34:50 Y.Yamagishi
    '更新日：2019/12/09 (Mon) 14:15:16 T.Oide
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnInputCheck              As Boolean              '確定前入力ﾁｪｯｸ処理結果格納用(True：ﾁｪｯｸOK、False：ﾁｪｯｸNG)
        Dim lblnAns                     As Boolean              'ﾛｯﾄ処理順変更結果格納用(True：更新成功、False：異常)
        Dim ltypLotChgSeqNumList        As List(Of LotChgSeqNumList)     '処理順変更要求構造体
        Dim llngCnt                     As Integer              '汎用ｶｳﾝﾀ
        Dim llngUpdateDataCnt           As Integer              '処理順変更ﾃﾞｰﾀ件数
        Dim lstrGuidMsg                 As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode             As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrFunctionID              As String
        Dim lstrActionID                As String
        Dim lstrEmpID                   As String
        Dim lstrEmpName                 As String
        Dim lstrSBID                    As String
        
        Try

            '@確定ﾎﾞﾀﾝ押下ﾌﾗｸﾞに"True：[確定]ﾎﾞﾀﾝ押下"をｾｯﾄ
            mblnCmdRegist = True

            '@=======================
            '@ 確定前入力ﾁｪｯｸ処理
            '@=======================
            lblnInputCheck = prvblnRegist_Chk

            '@確定前入力ﾁｪｯｸ処理結果が"False：ﾁｪｯｸNG"か
            If lblnInputCheck = False Then
                Exit Sub
            End If

        '@↓2019/12/09 (Mon) 14:19:21 T.Oide **************************************************
        '@    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
        '@    '@ 作業者ｺｰﾄﾞ入力画面　表示処理
        '@    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
        '@    Call frmxxCM0010.Show(vbModal)
        '@
        '@    '@作業者ｺｰﾄﾞ入力画面にて[閉じる]ﾎﾞﾀﾝが押下されたか
        '@    If pblnCancel = True Then
        '@        Exit Sub
        '@    End If
        '@---------------------------------------------------------

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0020.Instance.ShowDialog(Me)
            frmxxCM0020.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)
            
            '@実行権限の処理を追加
            lstrFunctionID = CPstrKeyEN0260             '機能ID: EN0260(ﾛｯﾄ処理準変更)
            lstrActionID = CPstrLotChgPlan              'ｱｸｼｮﾝID：変更/削除
            lstrEmpID = pstrUserID                      'ﾕｰｻﾞｰID
            lstrEmpName = pstrUserName                  'ﾕｰｻﾞｰ名
            lstrSBID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ

            '@実行権限ﾁｪｯｸ
            lblnAns = pubAuthority_Chk(lstrFunctionID, lstrActionID, lstrEmpID, lstrEmpName, lstrSBID)
            '@結果判定
            If lblnAns = False Then
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, lstrActionID)
                '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                Exit Sub
            End If
        '@↑2019/12/09 (Mon) 14:19:21 T.Oide **************************************************

            '@処理順変更要求構造体定義
            ltypLotChgSeqNumList =  New List(Of LotChgSeqNumList)

            '@処理順変更ﾃﾞｰﾀ件数の初期化
            llngUpdateDataCnt = 0

            '@処理順全解除ﾌﾗｸﾞが"False：処理順指定"か
            If mblnAllClearFlag = False Then

                For llngCnt = 1 To vsfLotWaitingList.Rows.Count - 1

                    '@変更後処理順№がNULL以外か
                    If vsfLotWaitingList.GetData(llngCnt, CMlngvsfWaitListSeqNum) <> vbNullString Then

                        '@処理順変更ﾃﾞｰﾀ件数をｲﾝｸﾘﾒﾝﾄ
                        llngUpdateDataCnt = llngUpdateDataCnt + 1
                        Dim typLotChgSeqNumListtmp = New LotChgSeqNumList
                        '@***********************
                        '@ 送信ﾃﾞｰﾀ作成
                        '@***********************
                        With typLotChgSeqNumListtmp

                            .strLotID = vsfLotWaitingList.GetData(llngCnt, CMlngvsfWaitListLotId)                  'ﾛｯﾄID
                            .strSeqNum = vsfLotWaitingList.GetData(llngCnt, CMlngvsfWaitListSeqNum)                '処理順№
                            .strOpID = vsfLotWaitingList.GetData(llngCnt, CMlngvsfWaitListOpID)                    '大工程
                            .strStepID = vsfLotWaitingList.GetData(llngCnt, CMlngvsfWaitListStepID)                '小工程
                            .strLotLastUpdate = vsfLotWaitingList.GetData(llngCnt, CMlngvsfWaitListLotLastUpdate)  '最終更新日時
                            .strAvailableRecipeFlag = vsfLotWaitingList.GetData(llngCnt, CMlngvsfWaitListAvailableRecipeFlag)  '処理可能ﾚｼﾋﾟﾌﾗｸﾞ(0：処理可能ﾚｼﾋﾟ、1：処理限定ﾚｼﾋﾟﾌﾗｸﾞ)

                        End With
                        ltypLotChgSeqNumList.Add(typLotChgSeqNumListtmp)
                    End If
                Next llngCnt
            End If

            '@=======================
            '@ ﾛｯﾄ処理順変更
            '@=======================
            lblnAns = pubblnLotChgSeqNum_Chg(CMstrlot_chgseqnumVer, _
                                             pstrSBID, _
                                             cmbWpID.Value, _
                                             ltypLotChgSeqNumList, _
                                             llngUpdateDataCnt, _
                                             lstrGuidMsg, _
                                             lstrGuidMsgCode)

            '@ﾛｯﾄ処理順変更結果が"True：更新成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)

                '@処理順全解除ﾌﾗｸﾞが"True：全解除"か
                If mblnAllClearFlag = True Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM64I>$$処理順全解除を行いました。"」のﾒｯｾｰｼﾞをｾｯﾄ
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0064)
                Else
                    '@処理順全解除ﾌﾗｸﾞが"False：処理順指定"の場合

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM53I>$$処理順変更を行いました。"」のﾒｯｾｰｼﾞをｾｯﾄ
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0053)
                End If

                '@ﾒｯｾｰｼﾞ表示処理
                Call pubVsfInfo_Disp(pstrDMsg)

                '@確定ﾎﾞﾀﾝ押下ﾌﾗｸﾞの初期化
                mblnCmdRegist = False

            Else
                '@ﾛｯﾄ処理順変更結果が"False：更新失敗"の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)

            End If

            '@=======================
            '@ [最新取得]ﾎﾞﾀﾝ押下処理
            '@=======================
            Call cmdLotList_Click(sender, e)

            '@各種ﾎﾞﾀﾝを無効にする
            cmdRegist.Enabled = False       '[確定]
            cmdBack.Enabled = False         '[1つ前に戻る]

            '@[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞが有効か
            If vsfLotWaitingList.Enabled = True Then

                '@[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfLotWaitingList)
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

    '関数名：cmdBack_Click
    '機　能：[一つ前に戻る]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/25 (Tue) 10:11:40 Y.Yamagishi
    '更新日：2010/01/21 (Thu) 12:53:41 N.Kojima
    '備　考：
    '　　　：2004/09/13 (Mon) 11:14:12 N.Kojima     変更後№が設定されていない場合は確定ﾎﾞﾀﾝをﾛｯｸする処理を追加
    '　　　：2005/09/06 (Tue) 11:23:47 T.Kitagawa   SCHﾘﾘｰｽに伴い、Fﾓｰﾄﾞ時は確定ﾎﾞﾀﾝを無効にする(不具合№3092)
    '　　　：2010/01/21 (Thu) 12:53:41 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    Private Sub cmdBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdBack.Click

        Dim llngCnt         As Integer  '汎用ｶｳﾝﾀ
        Dim llngSeqNumCnt   As Integer  '変更後処理順№

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            With vsfLotWaitingList

                '@現在処理順№の位置を検索
                For llngCnt = 1 To .Rows.Count - 1

                    '@現在処理順№が"000"以外か
                    If lblNowSeqNum.Text <> CMstrSeqNo Then

                        '@変更後処理順№と現在処理順№が同じか
                        If .GetData(llngCnt, CMlngvsfWaitListSeqNum) = lblNowSeqNum.Text Then

                            '@変更後処理順№をｸﾘｱする
                            .SetData(llngCnt, CMlngvsfWaitListSeqNum, vbNullString)

                            '@現在処理順№をﾃﾞｸﾘﾒﾝﾄし格納、[現在処理順№]ﾗﾍﾞﾙに表示する
                            mstrSeqNo = CStr(CInt(lblNowSeqNum.Text - 1))
                            lblNowSeqNum.Text = Format$(CInt(mstrSeqNo), CMstrSeqNo)

                            '@現在処理順№が"000"か
                            If lblNowSeqNum.Text = CMstrSeqNo Then

                                '@[一つ前に戻る]ﾎﾞﾀﾝを無効にする
                                cmdBack.Enabled = False

                                '@[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞが有効、かつﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True：起動処理成功"か
                                If vsfLotWaitingList.Enabled = True And _
                                    pblnFormLoad = True Then

                                    '@[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                                    Call pubSetFocus(vsfLotWaitingList)
                                End If
                            End If

                            For llngSeqNumCnt = 1 To .Rows.Count - 1

                                '@変更後処理順№がNULLか
                                If .GetData(llngSeqNumCnt, CMlngvsfWaitListSeqNum) = vbNullString Then

                                    '@[確定]ﾎﾞﾀﾝを無効にする
                                    cmdRegist.Enabled = False
                                Else
                                    '@変更後処理順№がNULL以外の場合

                                    '@ﾓｰﾄﾞ(運用ﾓｰﾄﾞ)が"F"以外か
                                    If lblMode.Text <> CPstrF Then

                                        '@[確定]ﾎﾞﾀﾝを有効にする
                                        cmdRegist.Enabled = True
                                        Exit For
                                    End If
                                End If
                            Next llngSeqNumCnt

                            '@処理終了
                            Exit Sub
                        End If
                    End If
                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdBack_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTimeRestrictDisp_Click
    '機　能：[時間制限表示]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2010/01/27 (Wed) 11:28:01 N.Kojima
    '更新日：2010/01/27 (Wed) 11:28:01
    '備　考：
    Private Sub cmdTimeRestrictDisp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTimeRestrictDisp.Click

        Dim llngNowRow      As Integer  '現在選択行格納用

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@時間制限ﾒｯｾｰｼﾞ/文字色格納用変数の初期化
            pstrRestrictMessage = vbNullString
            plngRestrictForeColor = CPlngNormalForeColor

            With vsfLotWaitingList

                '@-----------------------
                '@ 引継ぎ情報格納
                '@-----------------------
                '@時間制限がNULL以外か
                If .GetData(.Row, CMlngvsfWaitListLimitTime) <> vbNullString Then

                    '@時間制限内容/文字色を引継ぎ用変数へ格納
                    pstrRestrictMessage = .GetData(.Row, CMlngvsfWaitListLimitTime)

                    '@★ 時間制限の文字色により処理分岐 ★
                    Select Case .GetCellRange(.Row, CMlngvsfWaitListLimitTime).StyleDisplay.ForeColor

                        '@〓 赤 〓
                        Case ColorTranslator.FromWin32(CPlngVbColorRed)

                            plngRestrictForeColor = CPlngVbColorRed

                        '@〓 紫 〓
                        Case ColorTranslator.FromWin32(CPlngVbColorPurple)

                            plngRestrictForeColor = CPlngVbColorPurple

                        '@〓 その他(黒) 〓
                        Case Else

                            plngRestrictForeColor = CPlngNormalForeColor

                    End Select
                End If

                '@現在選択されている行を格納
                llngNowRow = .Row

                '@起動区分を設定(3：ﾛｯﾄ処理順変更)
                plngfrmxxCM00V0Kbn = CPlngNumThree

                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@ 時間制限表示画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM00V0.Instance.ShowDialog(Me)
                frmxxCM00V0.Instance = Nothing

                '@起動区分の初期化(0：ﾃﾞﾌｫﾙﾄ値(初期化値))
                plngfrmxxCM00V0Kbn = CPlngNumZero

                '@時間制限ﾒｯｾｰｼﾞ/文字色格納用変数の初期化
                pstrRestrictMessage = vbNullString
                plngRestrictForeColor = CPlngNormalForeColor

                '@[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfLotWaitingList)

                '@退避しておいた行を選択する
                .Select(llngNowRow, CMlngvsfWaitListNo)

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTimeRestrictDisp_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdAllCancel_Click
    '機　能：[処理順全解除]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/28 (Tue) 19:51:03 N.Kasai
    '更新日：2010/01/21 (Thu) 12:53:41 N.Kojima
    '備　考：
    '　　　：2004/09/30 (Thu) 21:08:33 N.Kasai      全解除ｴﾗｰの場合ﾎﾞﾀﾝの使用可№1012
    '　　　：2004/10/06 (Wed) 09:23:32 N.Kasai      全解除ﾎﾞﾀﾝに作業者ID入力追加　№1012
    '　　　：2004/10/07 (Thu) 11:16:41 N.Kasai      ﾛｯﾄ最終更新日付対応　№1044
    '　　　：2005/01/06 (Thu) 17:43:37 S.Deguchi    最新取得処理追加　№396
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2008/02/26 (Tue) 12:49:26 M.Koni       処理順解除失敗時(ｴﾗｰ時)の2重ﾎﾟｯﾌﾟｱｯﾌﾟ抑制処理追加(案件No.01536)
    '　　　：2008/04/18 (Fri) 10:00:00 S.Ochiai     処理順設定/解除共通化(案件No.02817)
    '　　　：2010/01/21 (Thu) 12:53:41 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    Private Sub cmdAllCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAllCancel.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@処理順全解除ﾌﾗｸﾞに"True：全解除"をｾｯﾄ
            mblnAllClearFlag = True

            '@=======================
            '@ [確定]ﾎﾞﾀﾝ押下処理
            '@=======================
            Call cmdRegist_Click(sender, e)

            '@処理順全解除ﾌﾗｸﾞの初期化
            mblnAllClearFlag = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdAllCancel_Click"
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
    '作成日：2004/05/25 (Tue) 09:19:32 Y.Yamagishi
    '更新日：2010/01/21 (Thu) 13:14:23 N.Kojima
    '備　考：
    '　　　：2004/10/26 (Tue) 17:03:15 T.Kitagawa　DoEvents対応
    '　　　：2010/01/21 (Thu) 13:14:23 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim llngRet         As Integer          '戻り値格納用
        Dim ltypCommonInfo  As CommonInfo       '引継ぎ情報構造体

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@DoEvents制御ﾌﾗｸﾞが"True：他処理実行中"か
            If pblnTrnFlag = True Then
                Exit Sub
            End If

            '@引継ぎ情報の装置IDがNULL以外か
            If ptypCommonInfo.strWpID <> vbNullString Then

                '@起動区分が"True：子画面起動"か
                If pblnfrmxxCM0110Kbn = True Then

                    '@∇∇∇∇∇∇∇∇∇∇∇
                    '@ ｱﾝﾛｰﾄﾞ処理
                    '@∇∇∇∇∇∇∇∇∇∇∇
                    Me.Close()
                Else
                    '@起動区分が"False：単独起動"の場合

                    '@∇∇∇∇∇∇∇∇∇∇∇
                    '@ ｱﾝﾛｰﾄﾞ処理
                    '@∇∇∇∇∇∇∇∇∇∇∇
                    Me.Close()

                    '@=======================
                    '@ 装置別ﾛｯﾄ一覧を起動する
                    '@=======================
                    Call pubMenuSelect_Proc(CPstrKeyEN0150)

                End If
            Else
                '@引継ぎ情報の装置IDがNULLの場合

                '@=======================
                '@ 終了処理
                '@=======================
                llngRet = publngEnd_Proc(CPstrKeyEN0260, ltypCommonInfo)

            End If

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

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：prvFrmxxCM0110_Init
    '機　能：画面初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/24 (Mon) 09:02:41 Y.Yamagishi
    '更新日：2010/01/21 (Thu) 12:53:41 N.Kojima
    '備　考：
    '　　　：2005/02/28 (Mon) 21:26:54 N.Kojima     稼動状態を削除(改善№524、525)
    '　　　：2010/01/21 (Thu) 13:14:23 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    '　　　：                                       時間制限表示を別画面で全表示する対応に伴い、処理追加。(案件№03510)
    Private Sub prvFrmxxCM0110_Init()

        Try

            '@-----------------------
            '@ [装置名]ｺﾝﾎﾞの初期化
            '@-----------------------
            cmbWpID.Clear
            cmbWpID.Enabled = False

            '@-----------------------
            '@ 各種ﾗﾍﾞﾙの初期化
            '@-----------------------
            lblWpStatus.Text = vbNullString          '装置状態
            lblMode.Text = vbNullString              'ﾓｰﾄﾞ
            lblWpTrnStatus.Text = vbNullString       '処理状態
            lblRecipeRule.Text = vbNullString        '処理順ﾙｰﾙ
            lblNowSeqNum.Text = vbNullString         '現在処理順№

            '@-----------------------
            '@ 各種ﾎﾞﾀﾝの初期化
            '@-----------------------
            cmdLotList.Enabled = False                  '[最新取得]
            cmdUP.Enabled = False                       '[▲]ｽｸﾛｰﾙ
            cmdDown.Enabled = False                     '[▼]ｽｸﾛｰﾙ
            cmdLeft.Enabled = False                     '[<<]ｽｸﾛｰﾙ
            cmdRight.Enabled = False                    '[>>]ｽｸﾛｰﾙ
            cmdBack.Enabled = False                     '[1つ前に戻る]
            cmdRegist.Enabled = False                   '[確定]
            cmdAllCancel.Enabled = False                '[処理順全解除]
            cmdTimeRestrictDisp.Enabled = False         '[時間制限表示]

            '@-----------------------
            '@ 各種ﾓｼﾞｭｰﾙ変数の初期化
            '@-----------------------
            If Not mtypAreaEquipmentList Is Nothing Then
                mtypAreaEquipmentList.Clear()
            End If
            mlngAreaEqCnt = 0
            mstrSeqNo = CMstrSeqNo                      '処理順№格納用
            mblnAllClearFlag = False                    '処理順全解除ﾌﾗｸﾞ

            '@[閉じる]ﾎﾞﾀﾝのCausesValidationを設定する
            cmdClose.CausesValidation = False

            '@=======================
            '@ [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ初期化処理
            '@=======================
            Call prvVsfLotWaitingList_Init()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxCM0110_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfLotWaitingList_Init
    '機　能：[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/24 (Mon) 09:17:49 Y.Yamagishi
    '更新日：2016/02/08 (Mon) 23:04:35 H.Hayashi
    '備　考：
    '　　　：2004/09/03 (Fri) 13:35:18 N.Kasai      ﾁｯﾌﾟ数量追加
    '　　　：2004/10/18 (Mon) 11:52:31 N.Kasai      ﾘﾜｰｸﾌﾗｸﾞ
    '　　　：2008/06/11 (Wed) 09:25:33 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2010/01/21 (Thu) 13:14:23 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    '　　　：2010/03/11 (Thu) 17:13:32 N.Kojima     処理可能ﾚｼﾋﾟ列追加に伴い、処理修正。(案件№03897)
    '　　　：2012/01/23 (Mon) 15:28:30 T.Oide       装置別ﾛｯﾄ一覧の並び順変更対応
    '　　　：2013/01/29 (Tue) 14:09:46 Y.Yoneyama   ﾛｯﾄ進捗度表示
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Private Sub prvVsfLotWaitingList_Init()

        Try

            With vsfLotWaitingList
                .Redraw = False
                '@ｸﾘｱ
                .Clear(ClearFlags.Content, .Rows.Fixed, 0, .Rows.Count - 1, .Cols.Count - 1)

                '@初期行数設定
                .Rows.Count = .Rows.Fixed

        '@↓2013/01/29 (Tue) 14:25:02 Y.Yoneyama **************************************************
                '@列数設定
                '.Cols = CMlngvsfWaitListAvailableRecipeFlag + 1
        '@↑2013/01/29 (Tue) 14:25:02 Y.Yoneyama **************************************************

                '@ﾀｲﾄﾙ文字・背景色の設定
                .Select(CMlngvsfWaitListRowTitle, CMlngvsfWaitListNo, CMlngvsfWaitListRowTitle, .Cols.Count - 1)
                .Styles.Fixed.ForeColor = Color.Yellow                                                   '文字色
                .Styles.Fixed.BackColor = Color.Navy                                                     '背景色
                .Styles.Fixed.Font = New Font(.Font.Name, CType(CMlngvsfWaitListHFontSize, Single))      'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                .Styles.Fixed.WordWrap = False                                                           '折り返し表示なし
                .Styles.Fixed.Trimming = StringTrimming.None                                             '省略表示の設定（省略表示しない）

                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light

                '@ｿｰﾄﾙｰﾙを設定
                '.ColSort(CMlngvsfWaitListNo) = flexSortGenericAscending '初期順番(昇順)

                .Styles.Normal.WordWrap = True                            '折り返し表示
                .Styles.Normal.Trimming = StringTrimming.None             '省略符号(...)表示なし

                '@ﾕｰｻﾞｰによる列幅変更ありか
                If mtypChgSort.blnChgWidth = False Then

                    '@列幅設定
                    .Cols(CMlngvsfWaitListNo).Width = CMlngvsfWaitListWNo
                    .Cols(CMlngvsfWaitListKb).Width = CMlngvsfWaitListWKb
                    .Cols(CMlngvsfWaitListSeqNumNow).Width = CMlngvsfWaitListWSeqNumNow
                    .Cols(CMlngvsfWaitListSeqNum).Width = CMlngvsfWaitListWSeqNum
                    .Cols(CMlngvsfWaitListLimitTime).Width = CMlngvsfWaitListWLimitTime1A0
                    .Cols(CMlngvsfWaitListCarrierID).Width = CMlngvsfWaitListWCarrierID
                    .Cols(CMlngvsfWaitListLotId).Width = CMlngvsfWaitListWLotId
                    .Cols(CMlngvsfWaitListFrowClass).Width = CMlngvsfWaitListWFrowClass
                    .Cols(CMlngvsfWaitListLotPriority).Width = CMlngvsfWaitListWLotPriority
                    .Cols(CMlngvsfWaitListOpID).Width = CMlngvsfWaitListWOpID
                    .Cols(CMlngvsfWaitListStepID).Width = CMlngvsfWaitListWStepID
                    .Cols(CMlngvsfWaitListRecipeID).Width = CMlngvsfWaitListWRecipeID
                    .Cols(CMlngvsfWaitListStartTime).Width = CMlngvsfWaitListWStartTime
                    .Cols(CMlngvsfWaitListLotManagerName).Width = CMlngvsfWaitListWLotManagerName
                    .Cols(CMlngvsfWaitListNowSt).Width = CMlngvsfWaitListWNowSt
                    .Cols(CMlngvsfWaitListWfNum).Width = CMlngvsfWaitListWWfNum
                    .Cols(CMlngvsfWaitListCfNum).Width = CMlngvsfWaitListWCfNum
                    .Cols(CMlngvsfWaitListCurrentPosition).Width = CMlngvsfWaitListWCurrentPosition
                    .Cols(CMlngvsfWaitListLotLastUpdate).Width = CMlngvsfWaitListWLotLastUpdate
                    .Cols(CMlngvsfWaitListReworkFlag).Width = CMlngvsfWaitListWReworkFlag
                    .Cols(CMlngvsfWaitListLotComments).Width = CMlngvsfWaitListWLotComments
                    .Cols(CMlngvsfWaitListAvailableRecipeFlag).Width = CMlngvsfWaitListWAvailableRecipeFlag
                    .Cols(CMlngvsfWaitListShipDiffDay).Width = CMlngvsfWaitListWShipDiffDay
                    .Cols(CMlngvsfWaitListFrFlag).Width = CMlngvsfWaitListWFrFlag
                    .Cols(CMlngvsfWaitListGrbClass).Width = CMlngvsfWaitListWGrbClass

                End If

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListNo, CMstrvsfWaitListTNo)                              '初期順番
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListSeqNumNow, CMstrvsfWaitListTSeqNumNow)                '現処理№
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListSeqNum, CMstrvsfWaitListTSeqNum)                      '変更後№
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListLimitTime, CMstrvsfWaitListTLimitTime)                '時間制約
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListCarrierID, CMstrvsfWaitListTCarrierID)                'ｷｬﾘｱID
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListLotId, CMstrvsfWaitListTLotId)                        'ﾛｯﾄID
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListFrowClass, CMstrvsfWaitListTFrowClass)                '種別
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListLotPriority, CMstrvsfWaitListTLotPriority)            '優先順位
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListOpID, CMstrvsfWaitListTOpID)                          '大工程
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListStepID, CMstrvsfWaitListTStepID)                      '小工程
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListRecipeID, CMstrvsfWaitListTRecipeID)                  'ﾚｼﾋﾟ
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListStartTime, CMstrvsfWaitListTStartTime)                '処理開始予実
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListLotManagerName, CMstrvsfWaitListTLotManagerName)      'ﾛｯﾄ担当
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListNowSt, CMstrvsfWaitListTNowSt)                        '状態
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListWfNum, CMstrvsfWaitListTWfNum)                        'WF枚数
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListCfNum, CMstrvsfWaitListTCfNum)                        'ﾁｯﾌﾟ
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListCurrentPosition, CMstrvsfWaitListTCurrentPosition)    '現在位置ID
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListLotLastUpdate, CMstrvsfWaitListTLotLastUpdate)        '最終更新日時
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListReworkFlag, CMstrvsfWaitListTReworkFlag)              'ﾘﾜｰｸﾌﾗｸﾞ
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListLotComments, CMstrvsfWaitListTLotComments)            'ｺﾒﾝﾄ有無
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListAvailableRecipeFlag, CMstrvsfWaitListTAvailableRecipeFlag) '処理可能ﾚｼﾋﾟﾌﾗｸﾞ(0：処理可能ﾚｼﾋﾟ、1：処理限定ﾚｼﾋﾟﾌﾗｸﾞ)
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListShipDiffDay, CMstrvsfWaitListTShipDiffDay)             'ﾛｯﾄ進捗度
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListFrFlag, CMstrvsfWaitListTFrFlag)                       'FRﾚｼﾋﾟ有無ﾌﾗｸﾞ
                .SetData(CMlngvsfWaitListRowTitle, CMlngvsfWaitListGrbClass, CMstrvsfWaitListTGrbClass)                   'GRB区分

                '@表示位置の設定
                .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

                '@DataType NSYS追加
                .Cols(CMlngvsfWaitListShipDiffDay).DataType = GetType(Double)
                .Cols(CMlngvsfWaitListWfNum).DataType = GetType(Int32)
                .Cols(CMlngvsfWaitListCfNum).DataType = GetType(Int32)
                .Cols(CMlngvsfWaitListCfNum).Format = CPstrCFKnmaFormat                            'チップ数のフォーマット
                .Cols(CMlngvsfWaitListShipDiffDay).DataType = GetType(Single)   
                .Cols(CMlngvsfWaitListShipDiffDay).Format = "##0.0"   

                '@書式設定
                .Cols(CMlngvsfWaitListSeqNumNow).TextAlign =  TextAlignEnum.RightCenter            '右詰の中央揃え(処理順)
                .Cols(CMlngvsfWaitListLimitTime).TextAlign =  TextAlignEnum.LeftCenter             '左詰の中央揃え(制限時間)
                .Cols(CMlngvsfWaitListFrowClass).TextAlign =  TextAlignEnum.LeftCenter             '左詰の中央揃え(種別)
                .Cols(CMlngvsfWaitListLotPriority).TextAlign = TextAlignEnum.RightCenter           '右詰の中央揃え(優先順位)
                .Cols(CMlngvsfWaitListLotComments).TextAlign =  TextAlignEnum.LeftCenter           '左詰の中央揃え(ｺﾒﾝﾄ)
                .Cols(CMlngvsfWaitListWfNum).TextAlign = TextAlignEnum.RightCenter                 '右詰の中央揃え(WF枚数)
                .Cols(CMlngvsfWaitListCfNum).TextAlign = TextAlignEnum.RightCenter                 '右詰の中央揃え(ﾁｯﾌﾟ)
                .Cols(CMlngvsfWaitListRecipeID).TextAlign =  TextAlignEnum.LeftCenter              '左詰の中央揃え(レシピ)
                .Cols(CMlngvsfWaitListShipDiffDay).TextAlign =  TextAlignEnum.RightCenter          '右詰の中央揃え(進捗度)

                '@ﾀｲﾄﾙ行の高さを設定
                .Rows(CMlngvsfWaitListRowTitle).Height = CMlngvsfWaitListHHeight

                '@固定列の設定
                .Cols.Frozen = CMlngvsfWaitListFrozenCols

                '@ﾏｳｽによる列ｻｲｽﾞ変更可に設定
                .AllowResizing = AllowResizingEnum.Columns

                '@非表示列設定
                .Cols(CMlngvsfWaitListLotLastUpdate).Visible = False        '最終更新日時
                .Cols(CMlngvsfWaitListReworkFlag).Visible = False           'ﾘﾜｰｸﾌﾗｸﾞ
                .Cols(CMlngvsfWaitListAvailableRecipeFlag).Visible = False  '処理可能ﾚｼﾋﾟﾌﾗｸﾞ(0：処理可能ﾚｼﾋﾟ、1：処理限定ﾚｼﾋﾟﾌﾗｸﾞ)
                .Cols(CMlngvsfWaitListFrFlag).Visible = False               'FRﾚｼﾋﾟ有無ﾌﾗｸﾞ
            
                '@組立工程
                If pstrSBID = CPstrSBID2A0 Then
                    .Cols(CMlngvsfWaitListShipDiffDay).Visible = False      '進捗度
                    .Cols(CMlngvsfWaitListGrbClass).Visible = False         'GRB区分
                End If
                
                '@各種ﾗﾍﾞﾙの初期化
                lblNowDate.Text = vbNullString       '情報取得日時
                lblLotCnt.Text = vbNullString        '該当件数

                .LeftCol = 0
                .Redraw = True

                '@ﾛｯｸ
                .Enabled = False

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfLotWaitingList_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbMcGroupName_Disp
    '機　能：[装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ設定＆作成処理
    '引　数：ltypAreaList   ：装置ｸﾞﾙｰﾌﾟ情報
    '戻り値：なし
    '作成日：2004/05/24 (Mon) 10:11:27 Y.Yamagishi
    '更新日：2010/01/21 (Thu) 12:53:41 N.Kojima
    '備　考：
    '　　　：2010/01/21 (Thu) 13:14:23 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    Private Sub prvcmbMcGroupName_Disp(ByRef ltypMcGroupList As McGroupList)

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try

            With cmbMcGroupName

                '@各種ﾌﾟﾛﾊﾟﾃｨを設定
                .Clear
                .DispCols = CMlngCmbDispCols                                    'ﾘｽﾄ表示列数
                .GetCol = CMlngCmbGridColName                                   'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColID                                   '値取得列
                .DirectInput = False                                            '直接入力：False：不可
                .Font = New Font(.Font.Name, CType(CMlngCmbFontSize, Single))           'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.Font.Name, CType(CMlngCmbGridFontSize, Single))   'ﾘｽﾄﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .GroupRows = ltypMcGroupList.lngMcGroupListCnt                  'ﾘｽﾄ表示行数
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter   '左寄中央揃え

                '@[装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞの作成
                For llngCnt = 0 To ltypMcGroupList.lngMcGroupListCnt - 1

                    '@装置ｸﾞﾙｰﾌﾟ名/装置ｸﾞﾙｰﾌﾟID
                    .AddItem(ltypMcGroupList.typMcGroupList(llngCnt).strMcGroupName & vbTab & _
                             ltypMcGroupList.typMcGroupList(llngCnt).strMcGroupID)
                Next llngCnt

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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

    '関数名：prvCmbWpID_Disp
    '機　能：[装置名]ｺﾝﾎﾞ設定＆作成処理
    '引　数：ltypAreaEquipmentList  ：装置ﾃﾞｰﾀ
    '　　　：llngAreaEqCnt          ：装置ﾃﾞｰﾀ数
    '戻り値：なし
    '作成日：2004/05/24 (Mon) 13:05:09 Y.Yamagishi
    '更新日：2010/01/21 (Thu) 12:53:41 N.Kojima
    '備　考：
    '　　　：2010/01/21 (Thu) 13:14:23 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    Private Sub prvcmbWpID_Disp(ByRef ltypAreaEquipmentList As List(Of AreaEquipmentList), ByVal llngAreaEqCnt As Integer)

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try

            With cmbWpID

                '@各種ﾌﾟﾛﾊﾟﾃｨを設定
                .Clear
                .DispCols = CMlngCmbDispCols                                    'ﾘｽﾄ表示列数
                .GetCol = CMlngCmbGridColName                                   'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColID                                   '値取得列
                .DirectInput = False                                            '直接入力：False：不可
                .Font = New Font(.Font.Name, CType(CMlngCmbFontSize, Single))   'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.Font.Name, CType(CMlngCmbGridFontSize, Single))   'ﾘｽﾄﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .GroupRows = llngAreaEqCnt                                      'ﾘｽﾄ表示行数
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter   '左寄中央揃え

                '@[装置名]ｺﾝﾎﾞの作成
                For llngCnt = 0 To llngAreaEqCnt - 1

                    '@装置名/装置ID/現在のｶｳﾝﾄ数
                    .AddItem(ltypAreaEquipmentList(llngCnt).strWpName & vbTab & _
                             ltypAreaEquipmentList(llngCnt).strWpID & vbTab & _
                             llngCnt)
                Next llngCnt

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbWpID_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvMcGroupWpName_Disp
    '機　能：端末情報と一致する[装置ｸﾞﾙｰﾌﾟ]/[装置名]の表示処理
    '引　数：lstrMcGroupID  ：端末情報の装置ｸﾞﾙｰﾌﾟID
    '　　　：lstrWpID       ：端末情報の装置ID
    '戻り値：なし
    '作成日：2004/05/24 (Mon) 17:43:29 Y.Yamagishi
    '更新日：2010/01/21 (Thu) 12:53:41 N.Kojima
    '備　考：
    '　　　：2010/01/21 (Thu) 13:14:23 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    Private Sub prvMcGroupWpName_Disp(ByVal lstrMcGroupID As String, ByVal lstrWpId As String)

        Dim lblnAns             As Boolean              '戻り値格納用
        Dim ltypMcGroupList     As McGroupList          '装置ｸﾞﾙｰﾌﾟ情報格納
        Dim llngCnt             As Integer              '汎用ｶｳﾝﾀ

        Try

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvMcGroupWpNameDisp)

            '@=======================
            '@ 装置ｸﾞﾙｰﾌﾟ取得(処理区分："02：全件")
            '@=======================
            lblnAns = pubblnMasMcGroupList_Sel(CMstrmas_McGrouplistVer, _
                                               CPstrCD02, _
                                               pstrSBID, _
                                               ltypMcGroupList)

            '@装置ｸﾞﾙｰﾌﾟ取得結果が"False：取得失敗"か
            If lblnAns = False Then

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvMcGroupWpNameDisp)

                '@=======================
                '@ [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ初期化処理
                '@=======================
                Call prvVsfLotWaitingList_Init()

                '@起動ﾌﾗｸﾞに"False：終了"をｾｯﾄ
                mblnLoadFlag = False
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrPrvMcGroupWpNameDisp)


            '@=======================
            '@ [装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ設定＆作成処理
            '@=======================
            Call prvcmbMcGroupName_Disp(ltypMcGroupList)

            For llngCnt = 0 To ltypMcGroupList.lngMcGroupListCnt - 1

                '@取得情報の装置ｸﾞﾙｰﾌﾟIDと端末情報の装置ｸﾞﾙｰﾌﾟIDが同じか
                If ltypMcGroupList.typMcGroupList(llngCnt).strMcGroupID = lstrMcGroupID Then

                    '@一致した装置ｸﾞﾙｰﾌﾟをﾃｷｽﾄ部分に表示する
                    cmbMcGroupName.ListIndex = llngCnt
                    Exit For
                End If
            Next llngCnt


            '@=======================
            '@ [装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞValidate処理
            '@=======================
            Call cmbMcGroupName_Validate(True, New CancelEventArgs)

            For llngCnt = 0 To mlngAreaEqCnt - 1

                '@取得情報の装置IDと端末情報の装置IDが同じか
                If mtypAreaEquipmentList(llngCnt).strWpID = lstrWpId Then

                    '@一致した装置をﾃｷｽﾄ部分に表示する
                    cmbWpID.ListIndex = llngCnt
                    Exit For
                End If
            Next llngCnt


            '@=======================
            '@ [装置名]ｺﾝﾎﾞValidate処理
            '@=======================
            Call cmbWpID_Validate(True, New CancelEventArgs)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMcGroupWpName_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfLotWaitingList_Disp
    '機　能：[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ作成＆表示処理
    '引　数：ltypLotWaitingList()   ：ﾛｯﾄ一覧情報格納構造体
    '　　　：llngLotWaitingListCnt  ：ﾛｯﾄ一覧ﾃﾞｰﾀ件数
    '戻り値：
    '作成日：2006/10/19 (Thu) 08:53:17 M.Miura
    '更新日：2018/01/17 (Wed) 13:38:31 Y.Yoneyama
    '備　考：
    '　　　：2004/09/09 (Thu) 14:52:37 Y.Yamagishi  時間制限を分表示に変更(不具合改善№693)
    '　　　：2004/09/13 (Mon) 13:14:32 N.Kojima　   確定ﾎﾞﾀﾝ押下可能条件変更に伴い、確定ﾎﾞﾀﾝ使用可能処理を削除(1853～1854行目)
    '　　　：2004/09/22 (Wed) 09:58:00 S.Deguchi    ｺﾒﾝﾄ表示をｻｰﾊﾞｰから送られてきている文字をそのまま表示するように変更
    '　　　：2004/09/26 (Sun) 14:10:45 S.Deguchi    ｺﾒﾝﾄ有無表記の判別を"あり"かそれ以外に変更
    '　　  ：2004/10/07 (Thu) 11:09:11 N.Kasai      ﾛｯﾄ最終更新日付追加
    '　　　：2005/02/02 (Wed) 15:49:40 N.Kasai      ｷｬﾘｱ位置表示をstrCurrentPositionIDからstrCurrentPositionName(和名)へ変更
    '　　　：2005/05/16 (Mon) 16:40:52 N.Kojima     一覧の処理開始予定のﾌｫｰﾏｯﾄを修正(不具合№808)
    '　　　：2005/09/06 (Tue) 10:59:02 T.Kitagawa   SCHﾘﾘｰｽに伴い、Fﾓｰﾄﾞ時は処理順全解除ﾎﾞﾀﾝを無効にする(不具合№3092)
    '　　　：2005/09/12 (Mon) 09:44:43 N.Kojima     処理順№表示処理の修正。
    '　　　：2006/05/12 (Fri) 12:52:12 T.Kitagawa   制限時間の表示を分合計から時間と分で分割表示する(#,##0時間 #0分)(ﾕｰｻﾞ要望№0186)
    '　　　：2006/06/08 (Thu) 14:33:14 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2006/09/05 (Tue) 17:25:41 T.Kitagawa   装置の処理順指定が、「ﾚｼﾋﾟ毎連続」の場合は処理順指定を不可とする(案件№01097)
    '　　　：2006/10/19 (Thu) 08:53:17 M.Miura      保/停区分の結合表示(案件№01565)
    '　　　：2007/07/09 (Mon) 13:30:17 N.Kasai      ｸﾞﾘｯﾄﾞ共通
    '　　　：2008/06/11 (Wed) 09:26:33 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2008/06/25 (Wed) 08:30:00 S.Ochiai     部分ﾚｼﾋﾟ対応(案件№03008)、及びﾒｯｾｰｼﾞ構造を抜本的に変更
    '　　　：2009/02/25 (Wed) 11:52:25 N.Kojima     起動SBが組立、かつ送品先が"7x0：ﾁｯﾌﾟ品"だったらﾌｫﾝﾄの色を青にする。(案件№03402)
    '　　　：2009/12/01 (Tue) 17:08:17 H.Hayashi    ﾁｯﾌﾟ品判定ﾛｼﾞｯｸ部変更。(案件No.03810)
    '　　　：2010/01/21 (Thu) 13:14:23 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    '　　　：                                       時間制限Colの列幅自動調整処理をｺﾒﾝﾄｱｳﾄ。(案件№03510)
    '　　　：2010/03/03 (Wed) 17:42:29 N.Kojima     不要処理削除、処理可能ﾚｼﾋﾟﾌﾗｸﾞの処理追加。(案件№03897)
    '　　　：2012/01/23 (Mon) 15:32:00 T.Oide       装置別ﾛｯﾄ一覧の並び順変更対応
    '　　　：2013/01/29 (Tue) 14:14:11 Y.Yoneyama   ﾛｯﾄ進捗度表示
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    '      ：2018/01/17 (Wed) 13:38:31 Y.Yoneyama   時間制限開始待ち保留の追加
    Private Sub prvVsfLotWaitingList_Disp(ByRef ltypLotListAns As LotListAns, ByVal llngLotListCnt As Integer)

        Dim llngDoCnt               As Integer          'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt                 As Integer          '汎用ｶｳﾝﾀ
        Dim llngNumCnt              As Integer          '処理№ｶｳﾝﾀ
        Dim lstrLimitTime           As String           '制限時間ﾌｫｰﾏｯﾄ用変数
        Dim lstrLimitTimeAns        As String           '時間制限変換用変数(#,##0時間 #0分)
        Dim lblnLimitTimeFlag       As Boolean          '時間制限表示ありﾌﾗｸﾞ
        Dim keepBackColorObj        As Color            'NSYS 設定済み背景色(時間制限ﾌｫﾝﾄ設定時初期化されるため再設定用)
        
        Try

            '@注意：下記ﾛｼﾞｯｸを変更する場合は、【装置別ﾛｯﾄ一覧(EN0150)】の変更要/不要を確認の事

            With vsfLotWaitingList

                '@ﾛｯﾄﾃﾞｰﾀが0件か
                If llngLotListCnt = 0 Then

                    '@=======================
                    '@ [ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ初期化処理
                    '@=======================
                    Call prvVsfLotWaitingList_Init()

                    '@各種ﾎﾞﾀﾝを無効にする
                    cmdLeft.Enabled = False         '[<<]ｽｸﾛｰﾙ
                    cmdRight.Enabled = False        '[>>]ｽｸﾛｰﾙ
                    cmdRegist.Enabled = False       '[確定]

                    Exit Sub
                Else
                    '@ﾃﾞｰﾀが1件以上ある場合

                    '@(一旦)描画はしない
                    .Redraw = False

                    'NSYS BeforeRowColChangeイベントを抑止し、ボタンの状態変更やｿｰﾄ検索用ｷｰ設定を抑える
                    RemoveHandler vsfLotWaitingList.BeforeRowColChange, AddressOf vsfLotWaitingList_BeforeRowColChange

                    '@行数設定
                    .Rows.Count = .Rows.Fixed
                    .Rows.Count = llngLotListCnt + 1

                    '@ﾙｰﾌﾟｶｳﾝﾀの初期化
                    llngDoCnt = 1

                    '@処理順№を("000"で)初期化
                    mstrSeqNo = CMstrSeqNo
                    llngNumCnt = 0
                    
                    '@時間制限表示ありﾌﾗｸﾞ初期化
                    lblnLimitTimeFlag = False

                    '@-----------------------
                    '@ ﾛｯﾄ情報設定
                    '@-----------------------
                    Do While .Rows.Count > llngDoCnt

                        '@処理№が初期値("999")か
                        If ltypLotListAns.typLotList(llngDoCnt - 1).strSeqNum = CMstrSeqNumAll9 Then

                            '@処理№に"標準"をｾｯﾄ
                            .SetData(llngDoCnt, CMlngvsfWaitListSeqNumNow, CMstrSeqNumStandard)                         '現処理順№
                        Else
                            '@処理№が初期値("999")以外の場合

                            '@処理№が数値か
                            If IsNumeric(ltypLotListAns.typLotList(llngDoCnt - 1).strSeqNum) = True Then

                                '@処理№をﾛｰｶﾙ変数に退避
                                llngNumCnt = CInt(ltypLotListAns.typLotList(llngDoCnt - 1).strSeqNum)
                                .SetData(llngDoCnt, CMlngvsfWaitListSeqNumNow, Format$(CInt(llngNumCnt), CMstrSeqNo))   '現処理順№
                            Else
                                '@処理№が数値以外の場合

                                '@現処理順№に"標準"をｾｯﾄ
                                .SetData(llngDoCnt, CMlngvsfWaitListSeqNumNow, CMstrSeqNumStandard)
                            End If

                            '@運用ﾓｰﾄﾞが"F"以外か
                            If lblMode.Text <> CPstrF Then

                                '@[処理順全解除]ﾎﾞﾀﾝ有効にする
                                cmdAllCancel.Enabled = True
                            End If
                        End If

                        .SetData(llngDoCnt, CMlngvsfWaitListSeqNum, vbNullString)                    '変更後処理順№

                        .SetData(llngDoCnt, CMlngvsfWaitListCarrierID, _
                            ltypLotListAns.typLotList(llngDoCnt - 1).strCarrierId)                   'ｷｬﾘｱID

                        .SetData(llngDoCnt, CMlngvsfWaitListLotId, _
                            ltypLotListAns.typLotList(llngDoCnt - 1).strLotID)                       'ﾛｯﾄID

                        .SetData(llngDoCnt, CMlngvsfWaitListFrowClass, _
                            ltypLotListAns.typLotList(llngDoCnt - 1).strFlowClass)                   '種別

                        .SetData(llngDoCnt, CMlngvsfWaitListLotPriority, _
                            ltypLotListAns.typLotList(llngDoCnt - 1).strLotPriority)                 '優先度

                        .SetData(llngDoCnt, CMlngvsfWaitListOpID, _
                            ltypLotListAns.typLotList(llngDoCnt - 1).strOpID)                        '大工程

                        .SetData(llngDoCnt, CMlngvsfWaitListStepID, _
                            ltypLotListAns.typLotList(llngDoCnt - 1).strStepID)                      '小工程

                        .SetData(llngDoCnt, CMlngvsfWaitListRecipeID, _
                            ltypLotListAns.typLotList(llngDoCnt - 1).strRecipeId)                    'ﾚｼﾋﾟ

                        If IsDate(ltypLotListAns.typLotList(llngDoCnt - 1).strDispatchStartTime) Then
                            .SetData(llngDoCnt, CMlngvsfWaitListStartTime, _
                            Format$(CDate(ltypLotListAns.typLotList(llngDoCnt - 1).strDispatchStartTime), CPstrDateFormatMDHM))           '処理開始予実
                        Else
                            .SetData(llngDoCnt, CMlngvsfWaitListStartTime, ltypLotListAns.typLotList(llngDoCnt - 1).strDispatchStartTime) '処理開始予実
                        End If

                        .SetData(llngDoCnt, CMlngvsfWaitListLotManagerName, _
                            ltypLotListAns.typLotList(llngDoCnt - 1).strEngEmpName)                  'ﾛｯﾄ担当

                        .SetData(llngDoCnt, CMlngvsfWaitListNowSt, _
                            ltypLotListAns.typLotList(llngDoCnt - 1).strNowST)                       'ﾛｯﾄ現在状態

                        .SetData(llngDoCnt, CMlngvsfWaitListWfNum, _
                            ltypLotListAns.typLotList(llngDoCnt - 1).strWfNum)                       'WF枚数

                        If IsNumeric(ltypLotListAns.typLotList(llngDoCnt - 1).strChipQuantity) Then
                            .SetData(llngDoCnt, CMlngvsfWaitListCfNum, _
                            Format$(CInt(ltypLotListAns.typLotList(llngDoCnt - 1).strChipQuantity), CPstrCFKnmaFormat))            'ﾁｯﾌﾟ
                        Else
                            .SetData(llngDoCnt, CMlngvsfWaitListCfNum, ltypLotListAns.typLotList(llngDoCnt - 1).strChipQuantity)   'ﾁｯﾌﾟ
                        End If

                        '@★ ｷｬﾘｱ状態により処理分岐 ★
                        Select Case ltypLotListAns.typLotList(llngDoCnt - 1).strCarrierStatID

                            '@〓 "MOVE(搬送中)","STKOUT(出庫中)","STKIN(入庫中)" 〓
                            Case CPstrCarrierStatMove, CPstrCarrierStatStkout, CPstrCarrierStatStkin

                                '@現在位置に"→"付きで搬送先をｾｯﾄ
                                .SetData(llngDoCnt, CMlngvsfWaitListCurrentPosition, _
                                    CMstrArrow & CPstrSpace & ltypLotListAns.typLotList(llngDoCnt - 1).strDestName)      '現在位置

                            '@〓 その他 〓
                            Case Else

                                '@搬送中以外の場合はｷｬﾘｱの現在位置をそのまま表示
                                .SetData(llngDoCnt, CMlngvsfWaitListCurrentPosition, _
                                    ltypLotListAns.typLotList(llngDoCnt - 1).strCurrentPositionName)                     '現在位置
                
                        End Select

                        '@ﾛｯﾄｺﾒﾝﾄが"あり"か
                        If ltypLotListAns.typLotList(llngDoCnt - 1).strLotCommentsFlg = CPstrAriFlg Then

                            '@ﾛｯﾄｺﾒﾝﾄに"あり"をｾｯﾄ
                            .SetData(llngDoCnt, CMlngvsfWaitListLotComments, CPstrAriFlg)                                'ﾛｯﾄｺﾒﾝﾄ
                        Else
                            '@ﾛｯﾄｺﾒﾝﾄに"なし"をｾｯﾄ
                            .SetData(llngDoCnt, CMlngvsfWaitListLotComments, vbNullString)
                        End If

                        .SetData(llngDoCnt, CMlngvsfWaitListLotLastUpdate, _
                            ltypLotListAns.typLotList(llngDoCnt - 1).strLotLastUpdate)               '最終更新日時

                        .SetData(llngDoCnt, CMlngvsfWaitListAvailableRecipeFlag, _
                            ltypLotListAns.typLotList(llngDoCnt - 1).strAvailableRecipeFlag)         '処理可能ﾚｼﾋﾟﾌﾗｸﾞ(0：処理可能ﾚｼﾋﾟ、1：処理限定ﾚｼﾋﾟﾌﾗｸﾞ)

                        .SetData(llngDoCnt, CMlngvsfWaitListShipDiffDay, _
                            ltypLotListAns.typLotList(llngDoCnt - 1).strShipDiffDay)                 'ﾛｯﾄ進捗度
                        
                        .SetData(llngDoCnt, CMlngvsfWaitListFrFlag, _
                            ltypLotListAns.typLotList(llngDoCnt - 1).strFrFlag)                      'FRﾚｼﾋﾟ有無ﾌﾗｸﾞ
                        
                           .SetData(llngDoCnt, CMlngvsfWaitListGrbClass, _
                            ltypLotListAns.typLotList(llngDoCnt - 1).strGrbClass)                    'GRB区分
                            
                        '@***********************
                        '@ 背景色/ﾌｫﾝﾄ色のﾃﾞﾌｫﾙﾄ設定
                        '@　①背景色：白
                        '@　②ﾌｫﾝﾄ色：黒
                        '@***********************
                        '@ｾﾙ背景色を"白(ﾃﾞﾌｫﾙﾄ)"に設定
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngColorWhite" + llngDoCnt.ToString)
                        newStyle.BackColor = ColorTranslator.FromWin32(CMlngColorWhite)
                        '@ﾌｫﾝﾄ色を"黒(ﾃﾞﾌｫﾙﾄ)"に設定
                        newStyle.ForeColor = ColorTranslator.FromWin32(CMlngColorBlack)
                        Dim cellRange As CellRange = .GetCellRange(llngDoCnt, CMlngvsfWaitListColTitle, _
                                               llngDoCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle
                        'NSYS 設定背景色名退避
                         keepBackColorObj = ColorTranslator.FromWin32(CMlngColorWhite) '白
                        '@***********************
                        '@ 背景色の設定
                        '@　①表示優先順位：部分ﾚｼﾋﾟ > 停止 > 保留 > 処理限定ﾚｼﾋﾟ > ﾀﾞﾐｰ > L/R色
                        '@***********************
                        '@-----------------------
                        '@ L/R色分け処理(組立機種)
                        '@-----------------------
                        '@液晶方向が"L(左)"か
                        If ltypLotListAns.typLotList(llngDoCnt - 1).strLcDirection = CPstrPDIDL Then

                            '@ｾﾙ背景色を"水色"に変更
                            Dim newStyle2 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngLColor" + llngDoCnt.ToString)
                            newStyle2.BackColor = ColorTranslator.FromWin32(CPlngLColor)
                            Dim cellRange2 As CellRange = .GetCellRange(llngDoCnt, CMlngvsfWaitListColTitle, _
                                                   llngDoCnt, .Cols.Count - 1)
                            cellRange2.Style = newStyle2
                            'NSYS 設定背景色名退避
                            keepBackColorObj = ColorTranslator.FromWin32(CPlngLColor) '水色
                        End If

                        '@液晶方向が"R(右)"か
                        If ltypLotListAns.typLotList(llngDoCnt - 1).strLcDirection = CPstrPDIDR Then

                            '@ｾﾙ背景色を"ﾋﾟﾝｸ"に変更
                            Dim newStyle2 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngRColor" + llngDoCnt.ToString)
                            newStyle2.BackColor = ColorTranslator.FromWin32(CPlngRColor)
                            Dim cellRange2 As CellRange = .GetCellRange(llngDoCnt, CMlngvsfWaitListColTitle, _
                                                   llngDoCnt, .Cols.Count - 1)
                            cellRange2.Style = newStyle2
                            'NSYS 設定背景色名退避
                            keepBackColorObj = ColorTranslator.FromWin32(CPlngRColor) 'ﾋﾟﾝｸ
                        End If


                        '@-----------------------
                        '@ ﾀﾞﾐｰ色分け処理
                        '@-----------------------
                        '@流動区分(種別)が"FD"or"SD"、かつ装置ﾀｲﾌﾟが"BATCH：ﾊﾞｯﾁ装置"か
                        If ((ltypLotListAns.typLotList(llngDoCnt - 1).strFlowClass = CPstrFillerDummy Or _
                             ltypLotListAns.typLotList(llngDoCnt - 1).strFlowClass = CPstrSideDummy) And _
                            ltypLotListAns.strMcType = CPstrMCTypeBatch) Then

                            '@ｾﾙ背景色を"ｵﾚﾝｼﾞ"に変更
                            Dim newStyle3 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngVbColorOrange" + llngDoCnt.ToString)
                            newStyle3.BackColor = ColorTranslator.FromWin32(CPlngVbColorOrange)
                            Dim cellRange3 As CellRange = .GetCellRange(llngDoCnt, CMlngvsfWaitListColTitle, _
                                                   llngDoCnt, .Cols.Count - 1)
                            cellRange3.Style = newStyle3
                            'NSYS 設定背景色名退避
                            keepBackColorObj = ColorTranslator.FromWin32(CPlngVbColorOrange) 'ｵﾚﾝｼﾞ
                        End If

                        '@流動区分(種別)が"ED"、かつ装置ﾀｲﾌﾟが"EXDUMMY：ｴｸｽﾄﾗﾀﾞﾐｰ使用装置"か
                        If ltypLotListAns.typLotList(llngDoCnt - 1).strFlowClass = CPstrExtraDummy And _
                            ltypLotListAns.strMcType = CPstrMCTypeExDummy Then

                            '@ｾﾙ背景色を"ｵﾚﾝｼﾞ"に変更
                            Dim newStyle4 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngVbColorOrange" + llngDoCnt.ToString)
                            newStyle4.BackColor = ColorTranslator.FromWin32(CPlngVbColorOrange)
                            Dim cellRange4 As CellRange = .GetCellRange(llngDoCnt, CMlngvsfWaitListColTitle, _
                                                   llngDoCnt, .Cols.Count - 1)
                            cellRange4.Style = newStyle4
                            'NSYS 設定背景色名退避
                            keepBackColorObj = ColorTranslator.FromWin32(CPlngVbColorOrange) 'ｵﾚﾝｼﾞ
                        End If

                        '@-----------------------
                        '@ FR累積時間範囲外結果色分け処理
                        '@-----------------------
                        '@FRﾚｼﾋﾟ有無ﾌﾗｸﾞが"1：処理不可"か
                        If ltypLotListAns.typLotList(llngDoCnt - 1).strFrFlag = CPstrOne Then

                            '@ｾﾙの色変更(ﾗｲﾄｸﾞﾘｰﾝ)
                            Dim newStyle5 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngFrNgColor" + llngDoCnt.ToString)
                            newStyle5.BackColor = ColorTranslator.FromWin32(CPlngFrNgColor)
                            Dim cellRange5 As CellRange = .GetCellRange(llngDoCnt, CMlngvsfWaitListColTitle, _
                                                   llngDoCnt, .Cols.Count - 1)
                            cellRange5.Style = newStyle5
                            'NSYS 設定背景色名退避
                            keepBackColorObj = ColorTranslator.FromWin32(CPlngFrNgColor) 'ﾗｲﾄｸﾞﾘｰﾝ
                        End If

                        '@-----------------------
                        '@ 処理限定ﾛｯﾄ色分け処理
                        '@-----------------------
                        '@処理可能ﾚｼﾋﾟﾌﾗｸﾞが"1：処理限定ﾚｼﾋﾟ"か
                        If ltypLotListAns.typLotList(llngDoCnt - 1).strAvailableRecipeFlag = CPstrOne Then
            
                            '@ｾﾙの色変更(ｸﾞﾚｰ)
                            Dim newStyle6 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray" + llngDoCnt.ToString)
                            newStyle6.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                            Dim cellRange6 As CellRange = .GetCellRange(llngDoCnt, CMlngvsfWaitListColTitle, _
                                                   llngDoCnt, .Cols.Count - 1)
                            cellRange6.Style = newStyle6
                            'NSYS 設定背景色名退避
                            keepBackColorObj = ColorTranslator.FromWin32(CPlngGridGray) 'ｸﾞﾚｰ
                        End If


                        '@-----------------------
                        '@ 保留/停止色分け処理
                        '@-----------------------
                        '@保留ﾌﾗｸﾞが"1：保留"か
                        If ltypLotListAns.typLotList(llngDoCnt - 1).strLotHoldFlag = CMstrLotHoldFlagOn Then

                            '@ｾﾙ背景色を"黄色"に変更
                            Dim newStyle7 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor" + llngDoCnt.ToString)
                            newStyle7.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                            Dim cellRange7 As CellRange = .GetCellRange(llngDoCnt, CMlngvsfWaitListColTitle, _
                                                   llngDoCnt, .Cols.Count - 1)
                            cellRange7.Style = newStyle7
                            'NSYS 設定背景色名退避
                            keepBackColorObj = ColorTranslator.FromWin32(CPlngHoldLotColor) '黄色
                        End If

                        '@停止ﾌﾗｸﾞが"1：停止"か
                        If ltypLotListAns.typLotList(llngDoCnt - 1).strLotStopFlag = CMstrLotStopFlagOn Then

                            '@ｾﾙ背景色を"黄色"に変更
                            Dim newStyle8 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor" + llngDoCnt.ToString)
                            newStyle8.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                            Dim cellRange8 As CellRange = .GetCellRange(llngDoCnt, CMlngvsfWaitListColTitle, _
                                                   llngDoCnt, .Cols.Count - 1)
                            cellRange8.Style = newStyle8
                            'NSYS 設定背景色名退避
                            keepBackColorObj = ColorTranslator.FromWin32(CPlngHoldLotColor) '黄色
                        End If


                        '@-----------------------
                        '@ 部分ﾚｼﾋﾟ色分け処理
                        '@-----------------------
                        '@部分ﾚｼﾋﾟﾌﾗｸﾞが"1：部分ﾚｼﾋﾟ"か
                        If ltypLotListAns.typLotList(llngDoCnt - 1).strWfPartialRecipeFlag = CMstrPartialRecipeFlagOn Then

                            '@区分列のｾﾙ背景色のみ"赤色"に変更
                            Dim newStyle9 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngVbColorRed" + llngDoCnt.ToString)
                            newStyle9.BackColor = ColorTranslator.FromWin32(CPlngVbColorRed)
                            Dim cellRange9 As CellRange = .GetCellRange(llngDoCnt, CMlngvsfWaitListKb, _
                                                   llngDoCnt, CMlngvsfWaitListKb)
                            cellRange9.Style = newStyle9
                        End If


                        '@***********************
                        '@ ﾌｫﾝﾄ色の設定(時間制限関連)
                        '@　①警告時間：紫色
                        '@　②制限時間：赤色
                        '@***********************
                        '@制限時間がNULL以外か
                        If ltypLotListAns.typLotList(llngDoCnt - 1).strLimitTime <> vbNullString Then
                            
                            '時間制限表示ありﾌﾗｸﾞｾｯﾄ
                            lblnLimitTimeFlag = True
                            
                            '@制限時間が0分以上(ﾌﾟﾗｽ)か
                            If CInt(ltypLotListAns.typLotList(llngDoCnt - 1).strLimitTime) >= 0 Then

                                '@制限ﾀｲﾌﾟが"1：制限時間以下"or"3：処理時間制限以下"か
                                If ltypLotListAns.typLotList(llngDoCnt - 1).strRestrictTypeID = CPstrRestrictTypeID1 Or _
                                    ltypLotListAns.typLotList(llngDoCnt - 1).strRestrictTypeID = CPstrRestrictTypeID3 Then

                                    '@制限時間をﾌｫｰﾏｯﾄ変換(##,##0)してﾛｰｶﾙ変数に格納
                                    lstrLimitTime = Format$(CInt(ltypLotListAns.typLotList(llngDoCnt - 1).strLimitTime), CPstrDateFormatKanma)

                                    '@=======================
                                    '@ 制限時間変換処理
                                    '@ ※制限時間を"時間"と"分"で分割
                                    '@=======================
                                    lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)
                                            
                                    '@制限時間先大工程+制限時間先小工程+制限時間+「以内」(組立の場合は小工程のみ)
                                    If pstrSBID = CPstrSBID1A0 Then
                                        .SetData(llngDoCnt, CMlngvsfWaitListLimitTime, _
                                                ltypLotListAns.typLotList(llngDoCnt - 1).strToOpId & CPstrSpace & _
                                                ltypLotListAns.typLotList(llngDoCnt - 1).strToStepId & CPstrMade & _
                                                lstrLimitTimeAns & CPstrinai)
                                    Else
                                        .SetData(llngDoCnt, CMlngvsfWaitListLimitTime, _
                                                ltypLotListAns.typLotList(llngDoCnt - 1).strToStepId & CPstrMade & _
                                                lstrLimitTimeAns & CPstrinai)
                                    End If
                                            
                                    '@警告時間がNULL以外か
                                    If ltypLotListAns.typLotList(llngDoCnt - 1).strWarnTime <> vbNullString Then

                                        '@警告時間がﾏｲﾅｽ(超過)、かつ制限時間が超過していないか
                                        If CInt(ltypLotListAns.typLotList(llngDoCnt - 1).strWarnTime) < 0 And _
                                            CInt(ltypLotListAns.typLotList(llngDoCnt - 1).strLimitTime) >= 0 Then

                                            '@文字色を"紫色"に変更
                                            Dim newStyle10 As CellStyle = .Styles.Add("CustomStyle_ForeColor_CPlngVbColorPurple" + llngDoCnt.ToString)
                                            newStyle10.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple)
                                            newStyle10.BackColor = keepBackColorObj
                                            Dim cellRange10 As CellRange = .GetCellRange(llngDoCnt, CMlngvsfWaitListLimitTime, _
                                                                   llngDoCnt, CMlngvsfWaitListLimitTime)
                                            cellRange10.Style = newStyle10
                                        End If
                                    End If
                                End If
                            Else
                                '@制限時間が0分以下(ﾏｲﾅｽ)の場合

                                '@文字色を"赤色"に変更
                                Dim newStyle10 As CellStyle = .Styles.Add("CustomStyle_ForeColor_CPlngVbColorRed" + llngDoCnt.ToString)
                                newStyle10.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed)
                                newStyle10.BackColor = keepBackColorObj
                                Dim cellRange10 As CellRange = .GetCellRange(llngDoCnt, CMlngvsfWaitListLimitTime, _
                                                       llngDoCnt, CMlngvsfWaitListLimitTime)
                                cellRange10.Style = newStyle10

                                '@制限ﾀｲﾌﾟが"1：制限時間以下"or"3：処理時間制限以下"か
                                If ltypLotListAns.typLotList(llngDoCnt - 1).strRestrictTypeID = CPstrRestrictTypeID1 Or _
                                    ltypLotListAns.typLotList(llngDoCnt - 1).strRestrictTypeID = CPstrRestrictTypeID3 Then

                                    '@制限時間をﾌｫｰﾏｯﾄ変換(##,##0)してﾛｰｶﾙ変数に格納
                                    lstrLimitTime = Format(CInt(ltypLotListAns.typLotList(llngDoCnt - 1).strLimitTime), CPstrDateFormatKanma)

                                    '@=======================
                                    '@ 制限時間変換処理
                                    '@ ※制限時間を"時間"と"分"で分割
                                    '@=======================
                                    lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)

                                    '@制限時間先大工程+制限時間先小工程+制限時間+「以内」(組立の場合は小工程のみ)
                                    If pstrSBID = CPstrSBID1A0 Then
                                        .SetData(llngDoCnt, CMlngvsfWaitListLimitTime, _
                                                ltypLotListAns.typLotList(llngDoCnt - 1).strToOpId & CPstrSpace & _
                                                ltypLotListAns.typLotList(llngDoCnt - 1).strToStepId & CPstrMade & _
                                                lstrLimitTimeAns & CPstrinai)
                                    Else
                                        .SetData(llngDoCnt, CMlngvsfWaitListLimitTime, _
                                                ltypLotListAns.typLotList(llngDoCnt - 1).strToStepId & CPstrMade & _
                                                lstrLimitTimeAns & CPstrinai)
                                    End If
                                                   
                                End If

                                '@制限ﾀｲﾌﾟが"2：制限時間以上"か
                                If ltypLotListAns.typLotList(llngDoCnt - 1).strRestrictTypeID = CPstrRestrictTypeID2 Then

                                    '@制限時間のﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換「(##,##0)+"分"」してﾛｰｶﾙ変数に格納
                                    lstrLimitTime = Replace(Format(CInt(ltypLotListAns.typLotList(llngDoCnt - 1).strLimitTime), CPstrDateFormatKanma), CPstrReplaceMinus, vbNullString)

                                    '@=======================
                                    '@ 制限時間変換処理
                                    '@ ※制限時間を"時間"と"分"で分割
                                    '@=======================
                                    lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)

                                    '@制限時間先大工程+制限時間先小工程+制限時間+「以上」(組立の場合は小工程のみ)
                                    If pstrSBID = CPstrSBID1A0 Then
                                        .SetData(llngDoCnt, CMlngvsfWaitListLimitTime, _
                                                ltypLotListAns.typLotList(llngDoCnt - 1).strToOpId & CPstrSpace & _
                                                ltypLotListAns.typLotList(llngDoCnt - 1).strToStepId & CPstrMade & _
                                                lstrLimitTimeAns & CPstrijyou)
                                    Else
                                        .SetData(llngDoCnt, CMlngvsfWaitListLimitTime, _
                                                ltypLotListAns.typLotList(llngDoCnt - 1).strToStepId & CPstrMade & _
                                                lstrLimitTimeAns & CPstrijyou)
                                    End If
                                End If
                            End If
                            
        '@↓2018/01/17 (Wed) 13:30:44 Y.Yoneyama **************************************************
                        '@ 時間制約無の場合
                        Else
                            '@ 時間制約開始待ち保留の場合
                            If ltypLotListAns.typLotList(llngDoCnt - 1).strTimeRestrictStartHold = CPstrOne Then
                                .SetData(llngDoCnt, CMlngvsfWaitListLimitTime, CPstrTimeRestrictStartWait)
                            End If
                        End If
        '@↑2018/01/17 (Wed) 13:30:44 Y.Yoneyama **************************************************

                        '@***********************
                        '@ 区分列の設定
                        '@　①対象状態分文字列を連結して表示(例：部・リ・保)
                        '@***********************
                        '@-----------------------
                        '@ 保留/停止
                        '@-----------------------
                        '@停止ﾌﾗｸﾞが"1：停止"か
                        If ltypLotListAns.typLotList(llngDoCnt - 1).strLotStopFlag = CMstrLotStopFlagOn Then

                            '@=======================
                            '@ 区分設定値返却処理
                            '@=======================
                            .SetData(llngDoCnt, CMlngvsfWaitListKb, _
                                pubstrColKbn_Set(.GetData(llngDoCnt, CMlngvsfWaitListKb), CMstrTei))    '停
                        End If

                        '@保留ﾌﾗｸﾞが"1：保留"か
                        If ltypLotListAns.typLotList(llngDoCnt - 1).strLotHoldFlag = CMstrLotHoldFlagOn Then

                            '@=======================
                            '@ 区分設定値返却処理
                            '@=======================
                            .SetData(llngDoCnt, CMlngvsfWaitListKb, _
                                pubstrColKbn_Set(.GetData(llngDoCnt, CMlngvsfWaitListKb), CMstrHo))     '保
                        End If

                        '@-----------------------
                        '@ ﾘﾜｰｸ/追加流動
                        '@-----------------------
                        .SetData(llngDoCnt, CMlngvsfWaitListReworkFlag, _
                                ltypLotListAns.typLotList(llngDoCnt - 1).strReworkFlag)          'ﾘﾜｰｸﾌﾗｸﾞ

                        '@ﾘﾜｰｸﾌﾗｸﾞが"1：ﾘﾜｰｸ"か
                        If ltypLotListAns.typLotList(llngDoCnt - 1).strReworkFlag = CMstrLotReworkFlagOn Then

                            '@=======================
                            '@ 区分設定値返却処理
                            '@=======================
                            .SetData(llngDoCnt, CMlngvsfWaitListKb, _
                                pubstrColKbn_Set(.GetData(llngDoCnt, CMlngvsfWaitListKb), CMstrRi))     'リ
                        End If

                        '@ﾘﾜｰｸﾌﾗｸﾞが"2：追加流動"か
                        If ltypLotListAns.typLotList(llngDoCnt - 1).strReworkFlag = CMstrLotReworkFlagOn2 Then

                            '@=======================
                            '@ 区分設定値返却処理
                            '@=======================
                            .SetData(llngDoCnt, CMlngvsfWaitListKb, _
                                pubstrColKbn_Set(.GetData(llngDoCnt, CMlngvsfWaitListKb), CMstrTsui))   '追
                        End If


                        '@-----------------------
                        '@ 号機指定
                        '@-----------------------
                        '@号機指定ﾌﾗｸﾞが"1：号機指定あり"か
                        If ltypLotListAns.typLotList(llngDoCnt - 1).strCommitFlag = CMstrGoukiFlagOn Then

                            '@=======================
                            '@ 区分設定値返却処理
                            '@=======================
                            .SetData(llngDoCnt, CMlngvsfWaitListKb, _
                                pubstrColKbn_Set(.GetData(llngDoCnt, CMlngvsfWaitListKb), CMstrGou))    '号
                        End If


                        '@-----------------------
                        '@ 部分ﾚｼﾋﾟ
                        '@-----------------------
                        '@部分ﾚｼﾋﾟﾌﾗｸﾞが"1：部分ﾚｼﾋﾟ"か
                        If ltypLotListAns.typLotList(llngDoCnt - 1).strWfPartialRecipeFlag = CMstrPartialRecipeFlagOn Then

                            '@=======================
                            '@ 区分設定値返却処理
                            '@=======================
                            .SetData(llngDoCnt, CMlngvsfWaitListKb, _
                                pubstrColKbn_Set(.GetData(llngDoCnt, CMlngvsfWaitListKb), CMstrBu))     '部
                        End If


                        '@-----------------------
                        '@ 処理限定ﾛｯﾄ
                        '@-----------------------
                        '@処理可能ﾚｼﾋﾟﾌﾗｸﾞが"1：処理限定ﾚｼﾋﾟ"か
                        If ltypLotListAns.typLotList(llngDoCnt - 1).strAvailableRecipeFlag = CPstrOne Then

                            '@=======================
                            '@ 区分設定値返却処理
                            '@=======================
                            .SetData(llngDoCnt, CMlngvsfWaitListKb, _
                                pubstrColKbn_Set(.GetData(llngDoCnt, CMlngvsfWaitListKb), CMstrGen))    '限
                        End If

                        '@-----------------------
                        '@ FR累積時間範囲外ﾛｯﾄ表示
                        '@-----------------------
                        '@FRﾚｼﾋﾟ有無ﾌﾗｸﾞが"1：処理不可"か
                        If ltypLotListAns.typLotList(llngDoCnt - 1).strFrFlag = CPstrOne Then

                            '@=======================
                            '@ 区分設定値返却処理
                            '@=======================
                            .SetData(llngDoCnt, CMlngvsfWaitListKb, _
                                pubstrColKbn_Set(.GetData(llngDoCnt, CMlngvsfWaitListKb), CMstrGai))    '外

                        End If

                        '@***********************
                        '@ ﾌｫﾝﾄ色の設定(ﾁｯﾌﾟ品関連(組立限定))
                        '@　①ﾁｯﾌﾟ品LOT：青色
                        '@***********************
                        '@起動SBが"2A0：組立"、かつｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"か
                        If pstrSBID = CPstrSBID2A0 And _
                            ltypLotListAns.typLotList(llngDoCnt - 1).strSbArea = CPstrProductChip Then

                            '@時間制限以外の文字色を"青色"に変更
                            Dim newStyle11 As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbBlue" + llngDoCnt.ToString)
                            newStyle11.ForeColor = Color.Blue
                            newStyle11.BackColor = keepBackColorObj
                            Dim cellRange11 As CellRange = .GetCellRange(llngDoCnt, CMlngvsfWaitListNo, _
                                llngDoCnt, CMlngvsfWaitListSeqNum)
                            cellRange11.Style = newStyle11
                            cellRange11 = .GetCellRange(llngDoCnt, CMlngvsfWaitListCarrierID, _
                                llngDoCnt, CMlngvsfWaitListLotComments)
                            cellRange11.Style = newStyle11
                        End If

                        '@↓2019/12/27 (Fri) 14:38:05 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        '@GRB背景色
                        If ltypLotListAns.typLotList(llngDoCnt - 1).strGRBClass <> vbNullString Then
                            Dim newStyleGRB As CellStyle = .Styles.Add("GRBColor" + llngDoCnt.ToString)
                            newStyleGRB.BackColor = pubGRBBackColor(ltypLotListAns.typLotList(llngDoCnt - 1).strGRBClass)
                            Dim cellRangeGRB As CellRange = .GetCellRange(llngDoCnt, CMlngvsfWaitListGrbClass, llngDoCnt, CMlngvsfWaitListGrbClass)
                            cellRangeGRB.Style = newStyleGRB
                        End If
                        '@↑2019/12/27 (Fri) 14:38:05 Y.Yoneyama 「.Netへ反映未」 **************************************************

                        '@行高設定
                        .Rows(llngDoCnt).Height = CMlngvsfWaitListHeight

                        '@ﾙｰﾌﾟｶｳﾝﾀをｲﾝｸﾘﾒﾝﾄ
                        llngDoCnt = llngDoCnt + 1
                    Loop


                    '@ﾕｰｻﾞｰにより列幅が手動で変更されているか
                    If mtypChgSort.blnChgWidth = False Then
                        '@変更されていない場合

                        '@ﾘｻｲｽﾞﾓｰﾄﾞに"0：列幅"をｾｯﾄ
                        '.AutoSizeMode = flexAutoSizeColWidth

                        .AutoSizeCol(CMlngvsfWaitListNo, 6)                  '初期順番
                        .AutoSizeCol(CMlngvsfWaitListKb, 6)                  '保/停区分
                        .AutoSizeCol(CMlngvsfWaitListSeqNumNow, 2)           '現処理№
                        .AutoSizeCol(CMlngvsfWaitListSeqNum, 6)              '変更後№
                        If lblnLimitTimeFlag = True Then
                            If pstrSBID = CPstrSBID1A0 Then
                                .Cols(CMlngvsfWaitListLimitTime).Width = CMlngvsfWaitListWLimitTime1A0    '時間制限表示あり(基板)
                            Else
                                .Cols(CMlngvsfWaitListLimitTime).Width = CMlngvsfWaitListWLimitTime2A0    '時間制限表示あり(組立)
                            End If
                        Else
                            .AutoSizeCol(CMlngvsfWaitListLimitTime, 6)       '時間制限(表示なし)
                        End If
                        .AutoSizeCol(CMlngvsfWaitListCarrierID, 6)           'ｷｬﾘｱID
                        .AutoSizeCol(CMlngvsfWaitListLotId, 6)               'ﾛｯﾄID
                        .AutoSizeCol(CMlngvsfWaitListFrowClass, 6)           '種別
                        .AutoSizeCol(CMlngvsfWaitListLotPriority, 8)         '種別
                        .AutoSizeCol(CMlngvsfWaitListOpID, 6)                '大工程
                        .AutoSizeCol(CMlngvsfWaitListStepID, 6)              '小工程
                        .AutoSizeCol(CMlngvsfWaitListRecipeID, 6)            'ﾚｼﾋﾟ
                        .AutoSizeCol(CMlngvsfWaitListStartTime, 6)           '処理開始予実
                        .AutoSizeCol(CMlngvsfWaitListLotManagerName, 6)      'ﾛｯﾄ担当
                        .AutoSizeCol(CMlngvsfWaitListNowSt, 6)               '状態
                        .AutoSizeCol(CMlngvsfWaitListWfNum, 6)               'WF枚数
                        .AutoSizeCol(CMlngvsfWaitListCfNum, 6)               'ﾁｯﾌﾟ
                        .AutoSizeCol(CMlngvsfWaitListCurrentPosition, 6)     '現在位置ID
                        .AutoSizeCol(CMlngvsfWaitListLotLastUpdate, 6)       '最終更新日時
                        .AutoSizeCol(CMlngvsfWaitListReworkFlag, 6)          'ﾘﾜｰｸﾌﾗｸﾞ
                        .AutoSizeCol(CMlngvsfWaitListLotComments, 6)         'ｺﾒﾝﾄ有無
                        .AutoSizeCol(CMlngvsfWaitListAvailableRecipeFlag, 6) '処理可能ﾚｼﾋﾟﾌﾗｸﾞ(0：処理可能ﾚｼﾋﾟ、1：処理限定ﾚｼﾋﾟﾌﾗｸﾞ)
                        .AutoSizeCol(CMlngvsfWaitListShipDiffDay, 6)         'ﾛｯﾄ進捗度
                        .AutoSizeCol(CMlngvsfWaitListFrFlag, 6)              'FRﾚｼﾋﾟ有無ﾌﾗｸﾞ
                        .AutoSizeCol(CMlngvsfWaitListGrbClass, 6)            'GRB区分
                    End If

                    '@行表示
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        .Rows(llngCnt).Visible = True
                    Next llngCnt

                    '@№設定(単純な行番号)
                    For llngDoCnt = 1 To .Rows.Count - 1

                        '@№をｾｯﾄし、ｱﾗｲﾒﾝﾄを"右中央揃え"に設定
                        .SetData(llngDoCnt, CMlngvsfWaitListNo, llngDoCnt)
                        .Cols(CMlngvsfWaitListColTitle).TextAlign = TextAlignEnum.RightCenter
                    Next llngDoCnt

                    '@現在処理順№をｾｯﾄ
                    lblNowSeqNum.Text = mstrSeqNo

                    '@初期表示位置の設定(ｸﾞﾘｯﾄﾞの1行目の1番左)
                    .TopRow = CMlngvsfWaitListRowTitle        '行
                    .Row = CMlngvsfWaitListRowTitle           'ｶﾚﾝﾄ行

                    '@全ﾃﾞｰﾀ行が12行以上存在するか(※)
                    '@ ※1ﾍﾟｰｼﾞの最大表示行数は11行でそれ以上なら次ﾍﾟｰｼﾞがある
                    If .Rows.Count > CMlngvsfWaitListPageRows + 1 Then

                        '@上下("▲","▼")ﾎﾞﾀﾝを有効にする
                        cmdUP.Enabled = True
                        cmdDown.Enabled = True
                    Else
                        '@全ﾃﾞｰﾀ行が11行以下の場合

                        '@上下("▲","▼")ﾎﾞﾀﾝを無効にする
                        cmdUP.Enabled = False
                        cmdDown.Enabled = False
                    End If


                    '@ｿｰﾄｶｳﾝﾀが1以上か(1以上：ｿｰﾄされている)
                    If mtypChgSort.lngCnt > 0 Then

                        '@ｿｰﾄ保持ﾘｽﾄ分ﾙｰﾌﾟ
                        For llngCnt = 0 To mtypChgSort.lngCnt - 1

                            '@該当列をｿｰﾄする
                            .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder, mtypChgSort.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If

                    '@ｿｰﾄ検索用ｷｰ(ｷｬﾘｱID)がNULL以外か
                    If mtypChgSort.strKey <> vbNullString Then

                        '@全ﾃﾞｰﾀ行分ﾙｰﾌﾟ
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1

                            '@ｿｰﾄｷｰとｷｬﾘｱID、大工程、小工程が同じか
                            If vsfLotWaitingList.GetData(llngCnt, CMlngvsfWaitListCarrierID) & _
                                vsfLotWaitingList.GetData(llngCnt, CMlngvsfWaitListOpID) & _
                                vsfLotWaitingList.GetData(llngCnt, CMlngvsfWaitListStepID) = mtypChgSort.strKey Then

                                '@対象行を選択する
                                .Row = llngCnt

                                '@=======================
                                '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納処理(ｸﾞﾘｯﾄﾞ、保持列)(ｸﾞﾘｯﾄﾞ共通仕様)
                                '@=======================
                                Call pubVsfBeforeSort(vsfLotWaitingList, CMlngvsfWaitListCarrierID & vbTab & _
                                                                         CMlngvsfWaitListOpID & vbTab & _
                                                                         CMlngvsfWaitListStepID)

                                '@=======================
                                '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納処理(ｸﾞﾘｯﾄﾞ、保持列)(ｸﾞﾘｯﾄﾞ共通仕様)
                                '@=======================
                                Call pubVsfAfterSort(vsfLotWaitingList, CMlngvsfWaitListCarrierID & vbTab & _
                                                                         CMlngvsfWaitListOpID & vbTab & _
                                                                         CMlngvsfWaitListStepID, _
                                                                         cmdUP, cmdDown, True,True,True,False,True)
                                Exit For
                            End If
                        Next llngCnt
                    Else
                        '@ｿｰﾄ検索用ｷｰ(ｷｬﾘｱID)がNULLの場合

                        '@ﾛｯﾄ一覧ﾃﾞｰﾀ件数が0件以外か
                        If mlngLotListCnt <> 0 Then

                            '@ｶﾚﾝﾄ行をﾀｲﾄﾙ行に設定
                            vsfLotWaitingList.Row = CMlngvsfWaitListTopRow
                        End If
                    End If

                    '@ｶﾚﾝﾄ列を№列(最左列)に設定
                    .Col = .Cols.Fixed


                    '@-----------------------
                    '@ 上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝの制御
                    '@-----------------------
                    '@表示先頭行がﾃﾞｰﾀ行目の1行目か
                    If .TopRow = .Rows.Fixed Then

                        '@上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝを無効にする
                        cmdUP.Enabled = False
                    Else
                        '@表示先頭行がﾃﾞｰﾀ行目の1行目以外の場合

                        '@上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝを有効にする
                        cmdUP.Enabled = True
                    End If

                    '@-----------------------
                    '@ 下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝの制御
                    '@-----------------------
                    '@表示先頭行+1ﾍﾟｰｼﾞの最大表示行数が全行数と同じ、または大きいか
                    If .TopRow + CMlngvsfWaitListPageRows >= .Rows.Count Then

                        '@下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝを無効にする
                        cmdDown.Enabled = False
                    Else
                        '@表示先頭行+1ﾍﾟｰｼﾞの最大表示行数が全行数より小さいか

                        '@下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝを有効にする
                        cmdDown.Enabled = True
                    End If

                    '@初期表示位置の設定(ｸﾞﾘｯﾄﾞの1行目の1番左)
                    .LeftCol = CMlngvsfWaitListColTitle       '列

                    '@=======================
                    '@ 左右("<<",">>")ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
                    '@=======================
                    Call pubCmdLREnable_Set(vsfLotWaitingList, cmdLeft, cmdRight)

                    '@ｸﾞﾘｯﾄﾞを描画する
                    .Redraw = True

                    'NSYS イベントハンドラーを元に戻す
                    AddHandler vsfLotWaitingList.BeforeRowColChange, AddressOf vsfLotWaitingList_BeforeRowColChange

                    '@[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞを有効にする
                    .Enabled = True

        '@↓2010/03/11 (Thu) 15:39:36 N.Kojima **************************************************

        '            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False："単独起動でﾌｫｰﾑﾛｰﾄﾞ中の場合
        '            If pblnFormLoad = False And pblnfrmxxCM0110Kbn = False Then
        '
        '                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
        '                '@ ﾛｯﾄ処理順変更画面　表示処理
        '                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
        '                Call frmxxCM0110.Show(vbModal)
        '
        '                '@[ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
        '                Call pubSetFocus(vsfLotWaitingList)
        '            End If

        '@↑2010/03/11 (Thu) 15:39:36 N.Kojima **************************************************

                End If
            End With

        '@↓2010/03/11 (Thu) 14:07:18 N.Kojima **************************************************
        '    '@ﾚｼﾋﾟ(切替)ﾌﾗｸﾞが"True：ﾚｼﾋﾟ(切替)"か
        '    '@ ※ﾚｼﾋﾟ(切替)の場合は処理順変更不可
        '    If mblnRecipeFlowNumFlag = True Then
        '
        '        '@各種ﾎﾞﾀﾝを無効にする
        '        cmdBack.Enabled = False                     '[1つ前に戻る]
        '        cmdRegist.Enabled = False                   '[確定]
        '        cmdAllCancel.Enabled = False                '[処理順全解除]
        '    End If
        '@↑2010/03/11 (Thu) 14:07:18 N.Kojima **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfLotWaitingList_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvWpStatus_Disp
    '機　能：装置情報表示処理
    '引　数：ltypLotList：ﾛｯﾄ一覧情報格納構造体
    '戻り値：なし
    '作成日：2004/09/23 (Thu) 09:56:29 N.Kasai
    '更新日：2010/01/21 (Thu) 11:36:40 N.Kojima
    '備　考：
    '　　　：2005/02/28 (Mon) 21:27:41 N.Kojima　　 稼動状態を削除(改善№524、525)
    '　　　：2008/06/25 (Wed) 08:30:00 S.Ochiai     部分ﾚｼﾋﾟ対応(案件№03008)、及びﾒｯｾｰｼﾞ構造を抜本的に変更
    '　　　：2010/01/21 (Thu) 11:36:40 N.Kojima     処理順ﾙｰﾙ表示に伴い、処理修正。(案件№03761暫定対応)
    Private Sub prvWpStatus_Disp(ByRef ltypLotListAns As LotListAns)
        
        Try
            
            With ltypLotListAns

                lblWpStatus.Text = .strUseName           '装置状態
                lblMode.Text = .strMesModeId             'ﾓｰﾄﾞ
                lblWpTrnStatus.Text = .strWpStatusName   '処理状態

                '@★ 処理順ﾌﾗｸﾞにより処理分岐 ★
                Select Case mtypEqstate.strCollectTypeFlag

                    '@〓 0：FIFO 〓
                    Case CPlngNumRecipeFlowFifo
            
                        lblRecipeRule.Text = CPstrRecipeFlowFifo         'FIFO(到着順)
            
                    '@〓 1：ﾚｼﾋﾟ(切替) 〓
                    Case CPlngNumRecipeFlowNum
            
                        lblRecipeRule.Text = CPstrRecipeFlowNum          'ﾚｼﾋﾟ(切替)
            
                    '@〓 2：ﾚｼﾋﾟ(固定) 〓
                    Case CPlngNumRecipeFlowGroup
            
                        lblRecipeRule.Text = CPstrRecipeFlowGroup        'ﾚｼﾋﾟ(固定)
                    
                    '@〓 3：FIFO限定 〓
                    Case CPlngNumRecipeFlowFifoSameNG
            
                        lblRecipeRule.Text = CPstrRecipeFlowFifoSameNG   'FIFO限定
            
                    '@〓 4：ﾚｼﾋﾟ(切替)限定 〓
                    Case CPlngNumRecipeFlowNumSameNG
            
                        lblRecipeRule.Text = CPstrRecipeFlowNumSameNG    'ﾚｼﾋﾟ(切替)限定
            
                    '@〓 5：ﾚｼﾋﾟ(固定)限定 〓
                    Case CPlngNumRecipeFlowGroupSameNG
            
                        lblRecipeRule.Text = CPstrRecipeFlowGroupSameNG  'ﾚｼﾋﾟ(固定)限定

                End Select

            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvWpStatus_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnRegist_Chk
    '機　能：確定前入力ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：ﾁｪｯｸOK、False：ﾁｪｯｸNG
    '作成日：2004/05/25 (Tue) 15:25:39 Y.Yamagishi
    '更新日：2010/03/11 (Thu) 17:15:48 N.Kojima
    '備　考：
    '　　　：2010/01/21 (Thu) 13:14:23 N.Kojima     案件№03761対応のついでにｿｰｽ整備。
    '　　　：2010/03/11 (Thu) 17:15:48 N.Kojima     案件№03897対応に伴い、暫定対応処理をｺﾒﾝﾄｱｳﾄ。(案件№03897)
    Private Function prvblnRegist_Chk() As Boolean

        Dim llngCnt             As Integer  '汎用ｶｳﾝﾀ
        Dim llngRet             As Integer  '戻り値格納用
        Dim llngUpdateDataCnt   As Integer  '処理順変更ﾃﾞｰﾀ件数
    '    Dim lblnSkipFlag        As Boolean  '処理ｽｷｯﾌﾟﾌﾗｸﾞ(True：処理ｽｷｯﾌﾟ、False：ﾃﾞﾌｫﾙﾄ値)

        Try

            '@各種値の初期化
            prvblnRegist_Chk = False        '戻り値
        '    lblnSkipFlag = False            '処理ｽｷｯﾌﾟﾌﾗｸﾞ

            '@処理順全解除ﾌﾗｸﾞが"False：処理順指定"か
            If mblnAllClearFlag = False Then

                '@処理順変更ﾃﾞｰﾀ件数の初期化
                llngUpdateDataCnt = 0

                For llngCnt = 1 To vsfLotWaitingList.Rows.Count - 1

                    '@現処理順№が変更後処理順№と異なるか
                    If vsfLotWaitingList.GetData(llngCnt, CMlngvsfWaitListSeqNumNow) <> _
                        vsfLotWaitingList.GetData(llngCnt, CMlngvsfWaitListSeqNum) Then

                        '@現処理順№が"標準"、または変更後処理順№がNULL以外か
                        If vsfLotWaitingList.GetData(llngCnt, CMlngvsfWaitListSeqNumNow) <> CMstrSeqNumStandard Or _
                            vsfLotWaitingList.GetData(llngCnt, CMlngvsfWaitListSeqNum) <> vbNullString Then

                            '@処理順変更ﾃﾞｰﾀ件数をｶｳﾝﾄｱｯﾌﾟ
                            llngUpdateDataCnt = llngUpdateDataCnt + 1
                            Exit For
                        End If
                    End If
                Next llngCnt

                '@処理順変更ﾃﾞｰﾀ件数が0件か
                If llngUpdateDataCnt = 0 Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM51I>$$現処理順№と変更後処理順№が全ロット同一です。設定を見直してください。"」のﾒｯｾｰｼﾞをｾｯﾄ
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0051)
                    Call publngMsgBox(pstrDMsg, vbInformation, Me.Text, True, 16)

                    Exit Function
                End If
            End If

            '@ﾒｯｾｰｼﾞ格納用変数の初期化
            pstrDMsg = vbNullString

            With vsfLotWaitingList

                '@処理順全解除ﾌﾗｸﾞが"True：全解除"か
                If mblnAllClearFlag = True Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM58I>$$処理順全解除を行うと全ロットの処理順番は標準に戻りますが
                    '@　$号機指定はそのまま残ります。$別装置で処理する場合には、別途、
                    '@　号機指定解除を行う必要があります。$よろしいですか？"」のﾒｯｾｰｼﾞをｾｯﾄ
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0058)
                Else
                    '@処理順全解除ﾌﾗｸﾞが"False：処理順指定"の場合

                    For llngCnt = 1 To .Rows.Count - 1

                        '@現処理順№が"標準"以外、かつ変更後処理順№がNULLか
                        If .GetData(llngCnt, CMlngvsfWaitListSeqNumNow) <> CMstrSeqNumStandard And _
                            .GetData(llngCnt, CMlngvsfWaitListSeqNum) = vbNullString Then

                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「"<TRM52I>$$変更後処理順№が未設定の場合は、該当ロットの処理順番が標準に戻りますが$
                            '@　号機指定はそのまま残ります。$別装置で処理する場合には、別途、
                            '@　号機指定解除を行う必要があります。$よろしいですか？"」のﾒｯｾｰｼﾞをｾｯﾄ
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0052)

                            Exit For
                        End If
                    Next llngCnt

        '@↓2010/03/11 (Thu) 15:46:48 N.Kojima **************************************************

        '            '@処理順ﾙｰﾙが"0：FIFO"以外か
        '            If mtypEqstate.strCollectTypeFlag <> 0 Then
        '
        '                '@表示ﾒｯｾｰｼﾞ変換
        '                '@「"<TRM8RO>$$処理順ルールに[%1]が指定されています。
        '                '@　$ロットは処理順ルール[%1]に従って処理(搬送)される為、
        '                '@　$処理順を設定しても指定された順で処理されない可能性があります。
        '                '@　$処理順を変更しますか？"」のﾒｯｾｰｼﾞをｾｯﾄ
        '                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008O, lblRecipeRule.Caption)
        '
        '                '@処理ｽｷｯﾌﾟﾌﾗｸﾞに"True：処理ｽｷｯﾌﾟ"をｾｯﾄ
        '                lblnSkipFlag = True
        '            End If

        '@↑2010/03/11 (Thu) 15:46:48 N.Kojima **************************************************

                End If

                '@ﾒｯｾｰｼﾞ格納用変数がNULL以外か
                If pstrDMsg <> vbNullString Then

                    '@ｾｯﾄしたﾒｯｾｰｼﾞを表示する
                    llngRet = publngMsgBox(pstrDMsg, vbNo, Me.Text, True, 16)

                    '@ﾒｯｾｰｼﾞBoxにて"いいえ"が選択されたか
                    If llngRet = vbNo Then

        '@↓2010/03/11 (Thu) 15:47:39 N.Kojima **************************************************

        '                '@処理ｽｷｯﾌﾟﾌﾗｸﾞに"False：ﾃﾞﾌｫﾙﾄ値"か
        '                If lblnSkipFlag = False Then

                        '@行を選択しﾌｫｰｶｽをｾｯﾄ
                        .Row = llngCnt
                        .ShowCell(.Row, CMlngvsfWaitListSeqNumNow)

        '                End If

        '@↑2010/03/11 (Thu) 15:47:39 N.Kojima **************************************************

                        Exit Function
                    End If
                End If
            End With

            '@戻り値に"True：ﾁｪｯｸOK"をｾｯﾄ
            prvblnRegist_Chk = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnRegist_Chk"
                .strErrMessage = vbNullString
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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfLotWaitingList.BeforeDoubleClick

        ' ObjectをGridに変換
        Dim gridObj As C1FlexGrid
        gridObj = CType(sender, C1FlexGrid)

        'ダブルクリックした箇所が列の境界線かを判断する
        If gridObj.HitTest(e.X,e.Y).Type = HitTestTypeEnum.ColumnResize Then

            '列の境界線の場合、本来の処理をキャンセル
            e.Cancel = True

        End If

    End Sub

End Class
