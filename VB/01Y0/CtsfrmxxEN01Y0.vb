'ﾌｧｲﾙ名：xxEN01Y0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：過去在庫一覧 メインフォーム
'作成日：2006/07/24 (Mon) 16:54:31 N.Kojima
'更新日：2014/01/16 (Thu) 11:07:59 T.Oide
'備　考：
'　　　：2011/04/26 (Tue) 11:12:37 T.Oide       CHR0001319 QUを組立に送品可能にする
'　　　：2012/06/27 (Wed) 11:42:25 T.Oide       ポイントが求められなかった場合「不明」を表示
'　　　：2014/01/16 (Thu) 11:07:59 T.Oide       GNS対応(Bacchus→Gnsに変更したところは一括置換のため履歴なし)
'Copyright(C)SEIKO EPSON CORPORATION 2014. All rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01Y0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01Y0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01Y0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01Y0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01Y0)
            Dim old_inst As Form
            old_inst = _instance
            _instance = value
            If old_inst IsNot Nothing AndAlso Not old_inst.IsDisposed Then
                old_inst.Close()
                old_inst.Dispose()
            End If
        End Set
    End Property

    
    

    '****************************************************************************************
    '                                      *定数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion                             As String = "05.01"

    '@機能ID
    Private Const CMstrLocalMenuKey                             As String = CPstrKeyEN01Y0          'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_mapinfo_Ver                          As String = "01.01"                 'ｽﾛｯﾄﾏｯﾌﾟ取得
    Private Const CMstrmas_pdlist__Ver                          As String = "03.00"                 '機種区分一覧取得
    Private Const CMstrmas_flowlistVer                          As String = "04.00"                 '種別区分一覧取得
    Private Const CMstrmas_UseOpList__Ver                       As String = "02.00"                 '大工程ﾏｽﾀ取得
    Private Const CMstrlot_steplistVer                          As String = "03.00"                 '小工程取得
    Private Const CMstrlot_snapshotlistVer                      As String = "04.00"                 '過去在庫一覧取得
    Private Const CMstrlot_curpositionlistVer                   As String = "01.00"                 'ｷｬﾘｱ位置取得
    Private Const CMstrmas_reportpointVer                       As String = "01.00"                 '実績報告工程取得

    '@vsfSnapShotListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfSnapShotListColNo                     As Integer = 0                      '№
    Private Const CMlngvsfSnapShotListColCheck                  As Integer = 1                      'ﾁｪｯｸﾎﾞｯｸｽ
    Private Const CMlngvsfSnapShotListColPoint                  As Integer = 2                      'ﾎﾟｲﾝﾄ
    Private Const CMlngvsfSnapShotListColPD                     As Integer = 3                      '機種
    Private Const CMlngvsfSnapShotListColLotID                  As Integer = 4                      'ﾛｯﾄID
    Private Const CMlngvsfSnapShotListColCarrierID              As Integer = 5                      'ｷｬﾘｱID
    Private Const CMlngvsfSnapShotListColPartCode               As Integer = 6                      '部品ｺｰﾄﾞ
    Private Const CMlngvsfSnapShotListColWFNum                  As Integer = 7                      'WF枚数
    Private Const CMlngvsfSnapShotListColChipQuantity           As Integer = 8                      '良品Chip
    Private Const CMlngvsfSnapShotListColChipOutQty             As Integer = 9                      '不良Chip
    Private Const CMlngvsfSnapShotListColChipForwardQty         As Integer = 10                     '払出Chip
    Private Const CMlngvsfSnapShotListColCfPartCode             As Integer = 11                     '対向部品コード
    Private Const CMlngvsfSnapShotListColCfWfNum                As Integer = 12                     '対向貼合WF数
    Private Const CMlngvsfSnapShotListColGnsWFNum               As Integer = 13                     'Gns報告WF枚数
    Private Const CMlngvsfSnapShotListColGnsChipQuantity        As Integer = 14                     'Gns報告ﾁｯﾌﾟ数
    Private Const CMlngvsfSnapShotListColCurrentPosition        As Integer = 15                     'ｷｬﾘｱ位置
    Private Const CMlngvsfSnapShotListColOpID                   As Integer = 16                     '大工程
    Private Const CMlngvsfSnapShotListColStepID                 As Integer = 17                     '小工程
    Private Const CMlngvsfSnapShotListColMPROrder               As Integer = 18                     '量産ｵｰﾀﾞｰ№
    Private Const CMlngvsfSnapShotListColPROrder                As Integer = 19                     'PRｵｰﾀﾞｰ
    Private Const CMlngvsfSnapShotListColCFFlag                 As Integer = 20                     'CFﾌﾗｸﾞ
    Private Const CMlngvsfSnapShotListColLpFlag                 As Integer = 21                     '大判ﾌﾗｸﾞ
    Private Const CMlngvsfSnapShotListColFlowClass              As Integer = 22                     '種別

    '@vsfSnapShotListの定数宣言(幅)
    Private Const CMlngvsfSnapShotListWColNo                    As Integer = 50                     '№
    Private Const CMlngvsfSnapShotListWColCheck                 As Integer = 37                     'ﾁｪｯｸﾎﾞｯｸｽ
    Private Const CMlngvsfSnapShotListWColPoint                 As Integer = 110                    'ﾎﾟｲﾝﾄ
    Private Const CMlngvsfSnapShotListWColPD                    As Integer = 80                     '機種
    Private Const CMlngvsfSnapShotListWColLotID                 As Integer = 100                    'ﾛｯﾄID
    Private Const CMlngvsfSnapShotListWColCarrierID             As Integer = 100                    'ｷｬﾘｱID
    Private Const CMlngvsfSnapShotListWColPartCode              As Integer = 150                    '部品ｺｰﾄﾞ
    Private Const CMlngvsfSnapShotListWColWFNum                 As Integer = 33                     'WF枚数
    Private Const CMlngvsfSnapShotListWColChipQuantity          As Integer = 57                     '良品Chip
    Private Const CMlngvsfSnapShotListWColChipOutQty            As Integer = 57                     '不良Chip
    Private Const CMlngvsfSnapShotListWColChipForwardQty        As Integer = 57                     '払出Chip
    Private Const CMlngvsfSnapShotListWColCfPartCode            As Integer = 150                    '対向部品コード
    Private Const CMlngvsfSnapShotListWColCfWfNum               As Integer = 33                     '対向貼合WF数
    Private Const CMlngvsfSnapShotListWColGnsWFNum              As Integer = 57                     'Gns報告WF枚数
    Private Const CMlngvsfSnapShotListWColGnsChipQuantity       As Integer = 72                     'Gns報告ﾁｯﾌﾟ数
    Private Const CMlngvsfSnapShotListWColCurrentPosition       As Integer = 106                    'ｷｬﾘｱ位置
    Private Const CMlngvsfSnapShotListWColOpID                  As Integer = 164                    '大工程
    Private Const CMlngvsfSnapShotListWColStepID                As Integer = 164                    '小工程
    Private Const CMlngvsfSnapShotListWColMPROrder              As Integer = 126                    '量産ｵｰﾀﾞｰ№
    Private Const CMlngvsfSnapShotListWColPROrder               As Integer = 90                     'PRｵｰﾀﾞｰ
    Private Const CMlngvsfSnapShotListWColCFFlag                As Integer = 0                      'CFﾌﾗｸﾞ
    Private Const CMlngvsfSnapShotListWColLpFlag                As Integer = 0                      '大判ﾌﾗｸﾞ
    Private Const CMlngvsfSnapShotListWColFlowClass             As Integer = 54                     '種別

    '@vsfSnapShotListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfSnapShotListTColNo                    As String = "№"          
    Private Const CMstrvsfSnapShotListTColPoint                 As String = "ポイント"       
    Private Const CMstrvsfSnapShotListTColPD                    As String = "機種"        
    Private Const CMstrvsfSnapShotListTColLotID                 As String = "ロットID"
    Private Const CMstrvsfSnapShotListTColCarrierID             As String = "キャリアID"
    Private Const CMstrvsfSnapShotListTColPartCode              As String = "部品コード"
    Private Const CMstrvsfSnapShotListTColWFNum                 As String = "WF"
    Private Const CMstrvsfSnapShotListTColChipQuantity          As String = "良品"
    Private Const CMstrvsfSnapShotListTColChipOutQty            As String = "不良"
    Private Const CMstrvsfSnapShotListTColChipForwardQty        As String = "払出"
    Private Const CMstrvsfSnapShotListTColCfPartCode            As String = "部品コード(対向)"
    Private Const CMstrvsfSnapShotListTColCfWfNum               As String = "WF(対向)"
    Private Const CMstrvsfSnapShotListTColGnsWFNum              As String = "Gns_WF"
    Private Const CMstrvsfSnapShotListTColGnsChipQuantity       As String = "Gns_ﾁｯﾌﾟ"
    Private Const CMstrvsfSnapShotListTColCurrentPosition       As String = "キャリア位置"
    Private Const CMstrvsfSnapShotListTColOpID                  As String = "大工程"
    Private Const CMstrvsfSnapShotListTColStepID                As String = "小工程"
    Private Const CMstrvsfSnapShotListTColMPROrder              As String = "量産ｵｰﾀﾞｰ"
    Private Const CMstrvsfSnapShotListTColPROrder               As String = "PRオーダー"
    Private Const CMstrvsfSnapShotListTColCFFlag                As String = "CFﾌﾗｸﾞ"
    Private Const CMstrvsfSnapShotListTColLpFlag                As String = "大判ﾌﾗｸﾞ"
    Private Const CMstrvsfSnapShotListTColFlowClass             As String = "種別"

    '@ｸﾞﾘｯﾄﾞ共通の定数宣言
    Private Const CMlngVsfRowTitle                              As Integer = 0                         'ﾀｲﾄﾙ行(行)
    Private Const CMlngVsfColTitle                              As Integer = 0                         'ﾀｲﾄﾙ行(列)
    Private Const CMlngVsfHFontSize                             As Integer = 11                        'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                               As Integer = 20                       'ﾍｯﾀﾞｰの高さ
    Private Const CMlngVsfHeight                                As Integer = 18                       '1ｽﾛｯﾄの高さ

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                              As Integer = 11                        'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                          As Integer = 11                        'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols                              As Integer = 1                         'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngcmbPartCodeDispCols                      As Integer = 3                         'ｸﾞﾘｯﾄﾞ表示列数(ｺｰﾄﾞと名称と紐付く機種表示)
    Private Const CMlngCmbDispCol2                              As Integer = 2                         'ｸﾞﾘｯﾄﾞ表示列数=2
    Private Const CMlngCmbGroupCols                             As Integer = 1                         '列方向ｸﾞﾙｰﾌﾟ数
    Private Const CMlngCMbSelectMode                            As Integer = 1                         '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
    Private Const CMlngCmbRowHeight                             As Integer = 18                        'ﾘｽﾄ行の高さ
    Private Const CMstrCmbAllSelect                             As String = "全て"                  '表示 文字列
    Private Const CMstrCmbSelect                                As String = " 項目選択"              '表示 文字列
    Private Const CMstrCmbNotSelect                             As String = "0 項目選択"             '表示 文字列「選択なし」
    Private Const CMlngCmbGridCol0                              As Integer = 0                         '選択列数
    Private Const CMstrCmbCheckOn                               As String = "1"                     'ﾁｪｯｸON
    Private Const CMstrCmbCheckOff                              As String = "0"                     'ﾁｪｯｸOFF
    Private Const CMlngCmbCheck0                                As Integer = 0                         'ﾁｪｯｸ数

    '@ｷｬﾘｱ位置ｺﾝﾎﾞ
    Private Const CMstrWpName                                   As String = "装置"                  'ｷｬﾘｱ位置ｺﾝﾎﾞ表示用
    Private Const CMstrWPID                                     As String = "WP"                    'ｷｬﾘｱ位置ｺﾝﾎﾞ用

    '@ﾚｽﾎﾟﾝｽ,引継ぎ用ｲﾍﾞﾝﾄ定数
    Private Const CMstrFormName                                 As String = "frmxxEN01Y0"               '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                                 As String = "Form_Load"                 'Form_Load
    Private Const CMstrFormActivate                             As String = "Form_Activate"             'Form_Activate
    Private Const CMstrCmbOpValidate                            As String = "cmbOp_Validate"            'cmbOp_Validate
    Private Const CMstrCmdSearchClick                           As String = "cmdSearch_Click"           'cmdSearch_Click
    Private Const CMstrCalSearchDateChange                      As String = "calSearchDate_Change"      'calSearchDate_Change
    Private Const CMstrCalSearchDateValidate                    As String = "calSearchDate_Validate"    'calSearchDate_Validate
    Private Const CMstrCmbSearchTimeValidate                    As String = "cmbSearchTime_Validate"    'cmbSearchTime_Validate
    Private Const CMstrCmbPDChange                              As String = "cmbPD_Change"              'cmbPD_Change
    Private Const CMstrCmbPdValidate                            As String = "cmbPD_Validate"            'cmbPD_Validate
    Private Const CMstrCmbFlowClassChange                       As String = "cmbFlowClass_Change"       'cmbFlowClass_Change
    Private Const CMstrCmbFlowClassValidate                     As String = "cmbFlowClass_Validate"     'cmbFlowClass_Validate
    Private Const CMstrCmbStepValidate                          As String = "cmbStep_Validate"          'cmbStep_Validate
    Private Const CMstrCmbInventoryValidate                     As String = "cmbInventory_Validate"     'cmbInventory_Validate
    Private Const CMstrCmbCurrentPositionValidate               As String = "cmbCurrentPosition_Validate"   'cmbCurrentPosition_Validate
    Private Const CMstrcmbPartCodeValidate                      As String = "cmbPartCode_Validate"      'cmbPartCode_Validate
    Private Const CMstrprvblnPdMapInfo_proc                     As String = "prvblnPdMapInfo_proc"      'prvblnPdMapInfo_proc

    '@検索日時表示用
    Private Const CMstrDoubleZero                               As String = "00"                    '時間表示用(ﾌｫｰﾏｯﾄ用)
    Private Const CMstrColon                                    As String = ":"                     '時間表示用(ｾﾐｺﾛﾝ)
    Private Const CMstrMorningTime                              As String = "06:45"                 '時間表示用(朝=06:45)
    Private Const CMstrEveningTime                              As String = "13:45"                 '時間表示用(夕=13:45)
    Private Const CMstrInitTime                                 As String = "00:00"                 '時間表示用(月末の在庫は月の切り替わりの00:00:00)

    '@その他
    Private Const CMlngChkMaxCnt                                As Integer = 10                     '最大ﾁｪｯｸ可能数
    Private Const CMstrFumeiPoint                               As String = "不明"
    Private Const CMstrPartTypeBuzai                            As String = "1"                     'ﾊﾟｰﾂﾀｲﾌﾟ(部材)
    Private Const CMstrPartTypeRyuDou                           As String = "2"                     'ﾊﾟｰﾂﾀｲﾌﾟ(流動中)
    Private Const CMstrPartTypeKansei                           As String = "3"                     'ﾊﾟｰﾂﾀｲﾌﾟ(完成)
    Private Const CMstrPartTypeSouhin                           As String = "4"                     'ﾊﾟｰﾂﾀｲﾌﾟ(送品)
    Private Const CMstrPartTypeBuzaiName                        As String = "部材"
    Private Const CMstrPartTypeRyuDouName                       As String = "流動"
    Private Const CMstrPartTypeKanseiName                       As String = "完成"
    Private Const CMstrPartTypeSouhinName                       As String = "送品"

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '@機種格納構造体
    Private mtypPdList                                          As List(Of ProductList)             '機種格納用配列
    Private mlngPdListCnt                                       As Integer                          '機種格納数

    '@種別格納構造体
    Private mtypFlowClassList                                   As List(Of DivisionList)            '種別格納用配列
    Private mlngFlowClassListCnt                                As Integer                          '種別格納数

    '@ｷｬﾘｱ位置格納構造体
    Private mtypCurrnetPositionList                             As List(Of CurrentPositionList)     'ｷｬﾘｱ位置格納用配列
    Private mlngCurrentPositionListCnt                          As Integer                          'ｷｬﾘｱ位置格納数

    '@ﾎﾟｲﾝﾄ格納構造体
    Private mtypPointList                                       As List(Of PointList)               'ﾎﾟｲﾝﾄ格納用配列
    Private mlngPointListCnt                                    As Integer                          'ﾎﾟｲﾝﾄ格納数

    '@大工程格納構造体
    Private mtypMasOpList                                       As MasOpList                        '大工程格納用構造体
    Private mlngOpListCnt                                       As Integer                          '大工程格納数

    '@小工程格納構造体
    Private mtypMasStepList                                     As MasStepList                      '小工程格納用構造体
    Private mlngStepListCnt                                     As Integer                          '小工程格納数

    '@過去在庫一覧要求格納構造体
    Private mtypSnapShotReqList                                 As SnapShotReqList                  '過去在庫一覧要求格納用構造体

    '@過去在庫一覧応答格納構造体
    Private mtypSnapShotAnsList                                 As SnapShotAnsList                  '過去在庫一覧応答格納用構造体

    '@機種別ｽﾛｯﾄ情報(機種別)
    Private mtypSnapPDMap                                       As SnapPDMap                        'ｽﾛｯﾄﾏｯﾌﾟ構造体(機種別)
    '@機種別ｽﾛｯﾄ情報(機種指定)
    Private mtypMasPdMap                                        As MasPdMapList                     'ｽﾛｯﾄﾏｯﾌﾟ構造体(機種指定)

    '@実績報告工程格納
    Private mtypeReportPoint                                    As ReportPoint

    '@退避用変数
    Private mstrSearchDate                                      As String                           '検索年月日
    Private mstrSearchTime                                      As String                           '検索時間
    Private mstrOpID                                            As String                           '大工程
    Private mstrStepID                                          As String                           '小工程
    Private mstrCurrentPosition                                 As String                           'ｷｬﾘｱ位置
    '@ｿｰﾄ用
    Private mtypChgSort                                         As ChgSort                          'ｿｰﾄ保持用
    '@その他
    Private mblnPrintChkFlag                                    As Boolean                          '印刷判定ﾌﾗｸﾞ
    Private mblnFormLoadFlag                                    As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ
    Private buttonProcessing                                    As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                            As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                                     As Boolean                          'NSYS WindowCloseフラグ


    '****************************************************************************************
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
    '                                *イベントハンドラの記述*
    '****************************************************************************************
    '========================================Private=========================================
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/25 (Tue) 14:44:40 N.Kojima
    '更新日：2014/01/16 (Thu) 18:13:41 T.Oide
    '備　考：
    '　　　：2006/09/26 (Tue) 17:28:30 N.Kojima     機種の取得条件(CLASS_DIVISION)の設定変更に伴い、処理修正。(案件№01517)
    Private Sub Form_Load()

        Dim lblnAns             As Boolean              '結果格納
        Dim lstrClassDivision   As String               'ClassDivision設定

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton  = Nothing  
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN01Y0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
                '@異常終了の場合
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton  = cmdClose
                Exit Sub
            End If
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)
            
            '@ｿｰﾄ保持用構造体の初期化
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                If  .typChgSortList Is Nothing Then
                  .typChgSortList = New List(Of ChgSortList)
                Else
                  .typChgSortList.Clear()
                End If
                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            '@画面情報の初期化
            Call prvfrmxxEN01Y0_Init()
            
            '@過去在庫一覧の初期化
            Call prvvsfSnapShotList_Init()
            
            '@各種ｺﾝﾎﾞの初期化
            Call prvcmbSearchTime_Init      '検索時間ｺﾝﾎﾞ
            Call prvcmbPd_Init              '機種ｺﾝﾎﾞ
            Call prvcmbFlowClass_Init       '種別ｺﾝﾎﾞ
            Call prvcmbOp_Init              '大工程ｺﾝﾎﾞ
            Call prvcmbStep_Init            '小工程ｺﾝﾎﾞ
            Call prvcmbCurrentPosition_Init 'ｷｬﾘｱ位置ｺﾝﾎﾞ
            Call prvcmbPartCode_Init        'ﾎﾟｲﾝﾄｺﾝﾎﾞ
            
            '@cron指定の検索時間を格納
            Call prvcmbSearchTime_Disp()
            
            '@起動SBによって、処理区分を変えて送信
            If pstrSBID = CPstrSBID1A0 Then
                '@基板(1A0)の場合
                '@機種区分一覧取得(4A02：棚卸用+起動SBの全ての機種)
                lstrClassDivision = CPstrCD4A & CPstrCD02
                lblnAns = pubblnMasPdlist_Sel(CMstrmas_pdlist__Ver, _
                                              lstrClassDivision, _
                                              mtypPdList, _
                                              mlngPdListCnt, _
                                              pstrSBID)
            Else
                '@組立(2A0)の場合
                '@機種区分一覧取得(4A02：棚卸用+全ての機種(1A0+2A0))
                lstrClassDivision = CPstrCD4A & CPstrCD02
                lblnAns = pubblnMasPdlist_Sel(CMstrmas_pdlist__Ver, _
                                              lstrClassDivision, _
                                              mtypPdList, _
                                              mlngPdListCnt, _
                                              pstrSBID)
            End If
            
            '@結果判定
            If lblnAns = True Then
                '@正常
                '@機種ｺﾝﾎﾞ設定
                Call prvcmbPd_Disp()
            Else
                '@異常
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose 
                Exit Sub
            End If
            
            '@流動区分一覧取得
            lstrClassDivision = CPstrCD2T & CPstrCD02  '(ﾌﾟﾛﾀﾞｸﾄ品の種別を選択する)
            lblnAns = pubblnMasFlowlist_Sel(CMstrmas_flowlistVer, _
                                            mtypFlowClassList, _
                                            mlngFlowClassListCnt, _
                                            pstrSBID, _
                                            lstrClassDivision)
            '@結果判定
            If lblnAns = True Then
                '@正常
                '@種別ｺﾝﾎﾞ設定
                Call prvcmbFlowClass_Disp()
            Else
                '@異常
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose 
                Exit Sub
            End If
            
            '@ｷｬﾘｱ位置一覧取得
            lblnAns = pubblnLotCurPositionList_Sel(CMstrlot_curpositionlistVer, _
                                                   mtypCurrnetPositionList, _
                                                   mlngCurrentPositionListCnt)

            '@結果判定
            If lblnAns = True Then
                '@正常
                '@ｷｬﾘｱ位置設定
                Call prvcmbCurrentPosition_Disp()
            Else
                '@異常
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose 
                Exit Sub
            End If
            
        '@↓2014/01/16 (Thu) 18:10:53 T.Oide **************************************************
        '@    '@ﾎﾟｲﾝﾄ一覧取得
        '@    lblnAns = pubblnAtlasPointList_Sel(CMstratlspointlistVer, _
        '@                                       mtypPointList(), _
        '@                                       mlngPointListCnt)
        '@
        '@    '@結果判定
        '@    If lblnAns = True Then
        '@        '@正常
        '@        '@ﾎﾟｲﾝﾄ設定
        '@        Call prvcmbPartCode_Disp
        '@    Else
        '@        '@異常
        '@        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
        '@        Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
        '@
        '@        '@Escﾎﾞﾀﾝを有効
        '@        cmdClose.Cancel = True
        '@        Exit Sub
        '@    End If
        '@-------------------------------------------------------------------------------------

            '@ﾊﾟｰﾂｺｰﾄﾞ一覧取得
            lblnAns = pubblnReportPoint_Sel(CMstrmas_reportpointVer, _
                                            pstrSBID, _
                                            vbNullString, _
                                            mtypeReportPoint)
            '@結果判定
            If lblnAns = True Then
                '@正常
                '@ﾎﾟｲﾝﾄ設定
                Call prvcmbPartCode_Disp()
            Else
                '@異常
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose 
                Exit Sub
            End If
        '@↑2014/01/16 (Thu) 18:10:53 T.Oide **************************************************
            
            '@大工程取得(全て)
            lstrClassDivision = CPstrCD2T
            lblnAns = pubblnMasUseOpList_Sel(pstrSBID, _
                                             CMstrmas_UseOpList__Ver, _
                                             lstrClassDivision, _
                                             mtypMasOpList)
                                          
            '@結果判定
            If lblnAns = True Then
                '@正常
                '@大工程ｺﾝﾎﾞ設定
                Call prvcmbOp_Disp()
            Else
                '@異常
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose 
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

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑｱｸﾃｨﾍﾞｲﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/25 (Tue) 16:10:38 N.Kojima
    '更新日：2007/02/02 (Fri) 11:42:47 N.Kasai
    '備　考：
    '　　　：2007/02/02 (Fri) 11:42:47 N.Kasai  検索条件追加に伴う修正(№01756)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Dim lblnRet     As Boolean      '戻り値判定用

        Try
           
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理分岐
            If mblnFormLoadFlag = False Then
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose 
                
                '@検索日時にﾃﾞﾌｫﾙﾄ値を格納
                '@現在日(YYYY/MM/DD)を格納
                calSearchDate.Value = Format$(Now, CPstrDateTimeYMD)
                '@"06:45"を表示
                cmbSearchTime.ListIndex = 1
                '@退避領域へ検索条件をｾｯﾄ
                mstrSearchDate = calSearchDate.Value    '年月日
                mstrSearchTime = cmbSearchTime.Text     '時間
                
                '@必須検索条件が全て揃っているか判定(引数:ｲﾍﾞﾝﾄ名)
                lblnRet = prvblnSearchCondition_Chk(CMstrFormActivate)
                '@戻り値の判定
                If lblnRet = True Then
                    '@必須検索条件が揃っている場合は、検索ﾎﾞﾀﾝを有効にする
                    cmdSearch.Enabled = True
                Else
                    '@必須検索条件が揃っていない場合、検索ﾎﾞﾀﾝを無効にする
                    cmdSearch.Enabled = False
                End If
                
                '@ﾌﾗｸﾞを戻す
                mblnFormLoadFlag = True
            End If
            
            Exit Sub

        Catch ex As Exception

            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose 

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

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑのKeyDown処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2006/07/25 (Tue) 16:16:08 N.Kojima
    '更新日：2006/08/28 (Mon) 11:32:25 N.Kojima
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
           '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙによる処理分岐
            Select Case ActiveControl.Name
                
                '@検索日時(年月日)
                Case calSearchDate.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@検索日Validate処理へ
                            RemoveHandler calSearchDate.validating,AddressOf calSearchDate_Validate
                            Call calSearchDate_Validate(sender, New CancelEventArgs(True))
                            AddHandler calSearchDate.validating,AddressOf calSearchDate_Validate
                            e.Handled = True
                    End Select
                
                '@検索日時(時間)
                Case cmbSearchTime.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@検索時間Validate処理へ
                            RemoveHandler cmbSearchTime.Validating, AddressOf cmbSearchTime_Validate
                            Call cmbSearchTime_Validate(sender, New CancelEventArgs(True))
                            AddHandler cmbSearchTime.Validating, AddressOf cmbSearchTime_Validate
                            e.Handled = True
                    End Select
                
                '@機種
                Case cmbPD.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@機種Validate処理へ
                            RemoveHandler cmbPD.Validating, AddressOf cmbPD_validate
                            Call cmbPd_Validate(sender, New CancelEventArgs(True))
                            AddHandler cmbSearchTime.Validating, AddressOf cmbSearchTime_Validate
                            e.Handled = True
                    End Select
                
                '@種別
                Case cmbFlowClass.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@種別Validate処理へ
                            RemoveHandler cmbFlowClass.Validating, AddressOf cmbFlowClass_validate
                            Call cmbFlowClass_Validate(sender, New CancelEventArgs(True))
                            AddHandler cmbFlowClass.Validating, AddressOf cmbFlowClass_validate
                            e.Handled = True
                    End Select
                            
                '@工程指定ﾁｪｯｸﾎﾞｯｸｽ
                Case chkProcess.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                        
                            '@ﾁｪｯｸﾎﾞｯｸｽの状態に応じて値を変更
                            If chkProcess.Checked = 0 Then
                                '@ﾁｪｯｸON
                                chkProcess.Checked = 1
                            Else
                                '@ﾁｪｯｸOFF
                                chkProcess.Checked = 0
                            End If

                            e.Handled = True
                    End Select
                    
                '@大工程
                Case cmbOp.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@大工程Validate処理へ
                            RemoveHandler cmbOp.Validating, AddressOf cmbOp_Validate
                            Call cmbOp_Validate(sender, New CancelEventArgs(True))
                            AddHandler cmbOp.Validating, AddressOf cmbOp_Validate
                            e.Handled = True
                    End Select
                    
                '@小工程
                Case cmbStep.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@小工程Validate処理へ
                            RemoveHandler cmbStep.Validating, AddressOf cmbStep_validate
                            Call cmbStep_Validate(sender, New CancelEventArgs(True))
                            AddHandler cmbStep.Validating, AddressOf cmbStep_validate
                            e.Handled = True
                    End Select
                
                '@ｷｬﾘｱ位置
                Case cmbCurrentPosition.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@ｷｬﾘｱ位置Validate処理へ
                            RemoveHandler cmbCurrentPosition.Validating, AddressOf cmbCurrentPosition_validate
                            Call cmbCurrentPosition_Validate(sender, New CancelEventArgs(True))
                            AddHandler cmbCurrentPosition.Validating, AddressOf cmbCurrentPosition_validate
                            e.Handled = True
                    End Select
                    
                '@ｷｬﾘｱ位置ﾁｪｯｸﾎﾞｯｸｽ
                Case chkCarrierPosition.Name
                    Select Case e.KeyCode
                        Case Keys.Return

                            '@ﾁｪｯｸﾎﾞｯｸｽの状態に応じて値を変更
                            If chkCarrierPosition.Checked = 0 Then
                                '@ﾁｪｯｸON
                                chkCarrierPosition.Checked = 1
                            Else
                                '@ﾁｪｯｸOFF
                                chkCarrierPosition.Checked = 0
                            End If

                            e.Handled = True
                    End Select
                    
                '@ﾎﾟｲﾝﾄ
                Case cmbPartCode.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@ﾎﾟｲﾝﾄValidate処理へ
                            RemoveHandler cmbPartCode.Validating, AddressOf cmbPartCode_Validate
                            Call cmbPartCode_Validate(sender, New CancelEventArgs(True))
                            AddHandler cmbPartCode.Validating, AddressOf cmbPartCode_Validate
                            e.Handled = True
                    End Select
                            
                '@ｽﾅｯﾌﾟｼｮｯﾄ一覧
                Case vsfSnapShotList.Name
                    
                    With vsfSnapShotList
                        Select Case e.KeyCode
                            '@Enterｷｰの場合
                            Case Keys.Return
                                '@次項目へｾｯﾄﾌｫｰｶｽ
                                SendKeys.SendWait(CPstrSendKeysTab)
                                e.Handled = True
                                
                            '@ｽﾍﾟｰｽｷｰの場合
                            Case Keys.Space
                                '@過去在庫一覧ｸﾘｯｸ処理
                                Call vsfSnapShotList_Click(sender, e)
                                e.Handled = True
                        End Select
                    End With
                    
                '@その他
                Case Else
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@次項目へｾｯﾄﾌｫｰｶｽ
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
    '機　能：終了処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2006/07/25 (Tue) 16:17:01 N.Kojima
    '更新日：2006/07/25 (Tue) 16:17:01
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm             As Boolean              '開放結果格納
        Dim ltypSnapPDMap           As SnapPDMap            'ｽﾛｯﾄﾏｯﾌﾟ構造体(機種別)
        Dim ltypMasPdMap            As MasPdMapList         'ｽﾛｯﾄﾏｯﾌﾟ構造体(機種指定)
        
        Try
           
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender, e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@sort保持用構造体のｸﾘｱ
            If  mtypChgSort.typChgSortList Is Nothing Then
                mtypChgSort.typChgSortList = New List(Of ChgSortList)
            Else
                mtypChgSort.typChgSortList.Clear()
            End If
            
            '@構造体・配列・ｶｳﾝﾀの初期化            
            If mtypPdList Is Nothing Then                       '機種格納用配列  
                mtypPdList= New List(Of ProductList) 
            Else
                mtypPdList.Clear()
            End If
            
            mlngPdListCnt = 0                                   '機種格納数           
            mtypFlowClassList = New List(Of DivisionList)       '種別格納用配列                                                         
            mlngFlowClassListCnt = 0                            '種別格納数
            If mtypCurrnetPositionList Is Nothing Then          'ｷｬﾘｱ位置格納用配列
                mtypCurrnetPositionList= New List(Of CurrentPositionList)  
            Else
                mtypCurrnetPositionList.Clear()
            End If
            
            mlngCurrentPositionListCnt = 0     
            If mtypPointList Is Nothing Then                    'ﾎﾟｲﾝﾄ格納用配列
                mtypPointList = New List(Of PointList) 
            Else 
                mtypPointList.Clear()
            End If                               
            mlngPointListCnt = 0                                'ﾎﾟｲﾝﾄ格納数

            If mtypMasOpList.typMasOpId Is Nothing  Then        '大工程格納用構造体
                mtypMasOpList.typMasOpId = New List(Of MasOpId)    
            Else
               mtypMasOpList.typMasOpId.Clear()
            End If
            mlngOpListCnt = 0                                   '大工程格納数            
            If mtypMasStepList.typMasStepId Is Nothing Then     '小工程格納用構造 
                mtypMasStepList.typMasStepId = New List(Of MasStepId)     
            Else
                mtypMasStepList.typMasStepId.Clear()
            End If
            mlngStepListCnt = 0                                 '小工程格納数                       
            If mtypSnapShotReqList.typPointList Is Nothing Then '過去在庫一覧要求格納用構造体(Atlasﾎﾟｲﾝﾄ配列)
               mtypSnapShotReqList.typPointList = New List(Of PointList)   
            Else    
               mtypSnapShotReqList.typPointList.Clear() 
            End If
            If mtypSnapShotReqList.typFlowClassList Is Nothing Then '過去在庫一覧要求格納用構造体(種別配列) 
               mtypSnapShotReqList.typFlowClassList = New List(Of FlowClassList)    
            Else
               mtypSnapShotReqList.typFlowClassList.Clear()
            End If
            If mtypSnapShotReqList.typPdList Is Nothing Then       '過去在庫一覧要求格納用構造体(機種配列)
               mtypSnapShotReqList.typPdList = New List(Of PDList) 
            Else
                mtypSnapShotReqList.typPdList.Clear()
            End If
            mtypSnapShotReqList.lngPointCnt = 0                    '過去在庫一覧要求格納用構造体(Atlasﾎﾟｲﾝﾄｶｳﾝﾄ)
            mtypSnapShotReqList.lngFlowClassCnt = 0                '過去在庫一覧要求格納用構造体(種別ｶｳﾝﾄ)
            mtypSnapShotReqList.lngPdCnt = 0                       '過去在庫一覧要求格納用構造体(機種ｶｳﾝﾄ)                       
            If mtypSnapShotAnsList.typSnapShotList Is Nothing Then '過去在庫一覧応答格納用構造体
               mtypSnapShotAnsList.typSnapShotList = New List(Of SnapShotAns) 
            Else
                mtypSnapShotAnsList.typSnapShotList.Clear()
            End If
            
            mtypSnapPDMap = ltypSnapPDMap                       '機種別ｽﾛｯﾄ情報(機種別)
            mtypMasPdMap = ltypMasPdMap                         '機種別ｽﾛｯﾄ情報(機種指定)
            
            '@印刷要求判定ﾌﾗｸﾞ(子画面引継ぎ用)を初期化
            pblnReqPrint = False
            
            '@引継ぎ構造体の初期化
            If ptypTakeOverDataEN01Y0 Is Nothing then           '星取表表示画面への引継ぎ用配列
               ptypTakeOverDataEN01Y0 = New List(Of TakeOverDataEN01Y0)
            Else
               ptypTakeOverDataEN01Y0.Clear()
            End If                      
            plngPrintLotCnt = 0                                 '印刷ﾛｯﾄ数ｶｳﾝﾀ
            
            '@ActInitﾌﾗｸﾞの判定
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
            
            '@ﾓｼﾞｭｰﾙ変数の初期化
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

    '関数名：calSearchDate_CalendarSelect
    '機　能：検索日時 ｶﾚﾝﾀﾞｰ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/25 (Tue) 16:18:30 N.Kojima
    '更新日：2006/07/25 (Tue) 16:18:30
    '備　考：
    Private Sub calSearchDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calSearchDate.CalendarSelect

        Try
            '@Validate処理へ
            RemoveHandler calSearchDate.Validating, AddressOf calSearchDate_Validate    
            Call calSearchDate_Validate(sender, New CancelEventArgs(true))
            AddHandler calSearchDate.Validating, AddressOf calSearchDate_Validate       
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calSearchDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calSearchDate_Change
    '機　能：検索日時 ｶﾚﾝﾀﾞｰ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/25 (Tue) 16:18:30 N.Kojima
    '更新日：2006/08/28 (Mon) 12:01:07 N.Kojima
    '備　考：
    Private Sub calSearchDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calSearchDate.Change
        
        Dim lblnRet         As Boolean      '戻り値判定用
        
        Try
                        
            '@"Form_Load","Form_Activate"時以外か
            If mblnFormLoadFlag = True Then
            
                '@退避変数を初期化
                mstrSearchDate = vbNullString
            
                '@ﾘｽﾄ、各種ﾎﾞﾀﾝ、ｿｰﾄｷｰの初期化
                Call prvInitialize_proc()
            
                '@必須検索条件が全て揃っているか判定(引数:ｲﾍﾞﾝﾄ名)
                lblnRet = prvblnSearchCondition_Chk(CMstrCalSearchDateChange)
                '@戻り値の判定
                If lblnRet = True Then
                    '@必須検索条件が揃っている場合は、検索ﾎﾞﾀﾝを有効にする
                    cmdSearch.Enabled = True
                Else
                    '@必須検索条件が揃っていない場合、検索ﾎﾞﾀﾝを無効にする
                    cmdSearch.Enabled = False
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calSearchDate_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calSearchDate_Validate
    '機　能：検索日付 Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ
    '戻り値：なし
    '作成日：2006/07/25 (Tue) 16:18:50 N.Kojima
    '更新日：2006/08/28 (Mon) 12:01:12 N.Kojima
    '備　考：
    Private Sub calSearchDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calSearchDate.Validating
        
        Dim lblnRet         As Boolean      '戻り値

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@退避変数の年月日と選択された年月日が同じ場合
            If mstrSearchDate = calSearchDate.Value Then
                If ActiveControl.Name = calSearchDate.Name Then
                    '@検索日時(時間)へﾌｫｰｶｽｾｯﾄ
                    If cmbSearchTime.Enabled = True Then
                        Call pubSetFocus(cmbSearchTime)
                    End If
                End If
                Exit Sub
            End If

            '@ﾘｽﾄ、各種ﾎﾞﾀﾝ、ｿｰﾄｷｰの初期化
            Call prvInitialize_proc()
            
            '@選択年月日を退避
           mstrSearchDate = calSearchDate.Value
            
            '@日付の有効性ﾁｪｯｸ
            '@日付が入力されている場合
            If calSearchDate.Value <> CPstrNullDate Then
                '@日付が初期値以外の場合
                If pubblnYearRange_Chk(calSearchDate.Value) = False Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@"正しい日付を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ﾌｫｰｶｽを移さない
                    e.Cancel = True
                    Exit Sub
                End If
                
                '@未来日付を指定された場合
                If Format$(Cdate(calSearchDate.Value), CPstrDateTimeYMD) > Format$(Now, CPstrDateTimeYMD) Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
                    '@"<TRM1XW>$$未来の日付は指定できません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ﾌｫｰｶｽを移さない
                    e.cancel = True
                    Exit Sub
                End If
                
                '@必須検索条件が全て揃っているか判定(引数:ｲﾍﾞﾝﾄ名)
                lblnRet = prvblnSearchCondition_Chk(CMstrCalSearchDateValidate)
                '@戻り値の判定
                If lblnRet = True Then
                    '@必須検索条件が揃っている場合は、検索ﾎﾞﾀﾝを有効にする
                    cmdSearch.Enabled = True
                Else
                    '@必須検索条件が揃っていない場合、検索ﾎﾞﾀﾝを無効にする
                    cmdSearch.Enabled = False
                End If

                '@検索日時(時間)へﾌｫｰｶｽｾｯﾄ
                If cmbSearchTime.Enabled = True Then
                    If ActiveControl.Name = calSearchDate.Name Then
                        Call pubSetFocus(cmbSearchTime)
                    End If
                End If
            End If  
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calSearchDate_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbSearchTime_Change
    '機　能：検索時間ｺﾝﾎﾞ　変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/25 (Tue) 16:30:26 N.Kojima
    '更新日：2006/07/25 (Tue) 16:30:26
    '備　考：
    Private Sub cmbSearchTime_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSearchTime.Change

        Try
            
            '@"Form_Load","Form_Activate"時以外か
            If mblnFormLoadFlag = True Then
                
                '@退避変数を初期化
                mstrSearchTime = vbNullString
            
                '@ﾘｽﾄ、各種ﾎﾞﾀﾝ、ｿｰﾄｷｰの初期化
                Call prvInitialize_proc()
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbSearchTime_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbSearchTime_KeyPress
    '機　能：時刻の書式か確認
    '引　数：KeyAscii：ｱｽｷｰｺｰﾄﾞ
    '戻り値：なし
    '作成日：2014/01/28 (Tue) 17:04:25 T.Oide
    '更新日：2014/01/28 (Tue) 17:04:25
    '備　考：
    Private Sub cmbSearchTime_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles cmbSearchTime.KeyPress

        Try

            Select Case Asc(e.KeyChar)

                '@数字、: のみ入力可能
                Case 8
                Case 48
                Case 49
                Case 50
                Case 51
                Case 52
                Case 53
                Case 54
                Case 55
                Case 56
                Case 57
                Case 58
                    '何もしない
                Case 13
                    'NSYS ENTERを押下し場合、処理を抜ける　　※　VB6版と同様の動作にする為
                    Exit Sub
                Case Else
                    '@空にする
                    e.Handled = True

            End Select

            '@Max5桁とする
            cmbSearchTime.Text = Mid$(cmbSearchTime.Text, 1, 4)
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbSearchTime_KeyPress"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub
    '関数名：cmbSearchTime_KeyUp
    '機　能：
    '引　数：KeyCode：
    '　　　：Shift：
    '戻り値：
    '作成日：2014/01/28 (Tue) 17:52:12 T.Oide
    '更新日：2014/01/28 (Tue) 17:52:12
    '備　考：
    Private Sub cmbSearchTime_KeyUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSearchTime.KeyUp

        Dim strTmpString    As String
        Dim lngTmpNum       As Integer
        Dim lblnChkFlag     As Boolean

        Try
            
            '@初期化
            lblnChkFlag = True

            '@5桁入力された場合、時刻かチェックする
            If Len(cmbSearchTime.Text) = 5 Then
                '@時刻かチェック
                
                '@先頭2桁確認-------------------------------------
                strTmpString = Mid$(cmbSearchTime.Text, 1, 2)
                lngTmpNum = 0
                If IsNumeric(strTmpString) = False Then
                
                    '@エラー
                    lblnChkFlag = False
                Else
                    lngTmpNum = strTmpString
                End If
                
                '@数値以外か24より大きいか
                If lngTmpNum > 23 Then
                    '@エラー
                    lblnChkFlag = False
                End If
                
                '@3桁目確認-------------------------------------
                strTmpString = Mid$(cmbSearchTime.Text, 3, 1)
                
                '@｢:｣以外か
                If strTmpString <> ":" Then
                    '@エラー
                    lblnChkFlag = False
                End If
                
                '@末尾2桁確認-------------------------------------
                strTmpString = Mid$(cmbSearchTime.Text, 4, 2)
                lngTmpNum = 0
                
                '@数値か
                If IsNumeric(strTmpString) = False Then
                    '@エラー
                    lblnChkFlag = False
                Else
                    lngTmpNum = strTmpString
                End If
                
                '@24より大きいか
                If lngTmpNum > 59 Then
                    
                    '@エラー
                    lblnChkFlag = False
                    
                End If
                
                '@エラーがあった場合メッセージを表示して値をクリア
                If lblnChkFlag = False Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0127)
                    '@<TRM127W>$$時刻[hh:mm]を入力してください。
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                    cmbSearchTime.Text = vbNullString
                End If
                
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbSearchTime_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：cmbSearchTime_CloseUp
    '機　能：検索時間ｺﾝﾎﾞ　CloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/25 (Tue) 16:55:54 N.Kojima
    '更新日：2006/07/25 (Tue) 16:55:54
    '備　考：
    Private Sub cmbSearchTime_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbSearchTime.CloseUp

        Try
            
            '@空欄じゃない場合
            If cmbSearchTime.Text <> vbNullString Then                
                '@Validate処理へ
                RemoveHandler cmbSearchTime.Validating, AddressOf cmbSearchTime_Validate
                Call cmbSearchTime_Validate(sender, New CancelEventArgs(True))
                AddHandler cmbSearchTime.Validating, AddressOf cmbSearchTime_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbSearchTime_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbSearchTime_Validate
    '機　能：検索時間ｺﾝﾎﾞ　Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/07/25 (Tue) 16:56:28 N.Kojima
    '更新日：2006/08/28 (Mon) 12:01:18 N.Kojima
    '備　考：
    Private Sub cmbSearchTime_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbSearchTime.Validating

        Dim lblnRet         As Boolean      '戻り値

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
                                    
            '@検索日時(時間)が変わっていない場合処理しない
            If mstrSearchTime = cmbSearchTime.Text Then
                If ActiveControl.Name = cmbSearchTime.Name Then
                    '@機種ｺﾝﾎﾞが有効で検索日時が選択されている場合
                    If cmbPD.Enabled = True And _
                        cmbSearchTime.Text <> vbNullString Then
                    
                        '@機種ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmbPD)
                    End If
                End If
                Exit Sub
            Else
                '@検索日時(時間)が空欄の場合には,処理しない
                If cmbSearchTime.Text = vbNullString Then
                    Exit Sub
                End If
            End If
                                
            '@退避領域へ検索条件をｾｯﾄ
            mstrSearchTime = cmbSearchTime.Text
                                
            '@必須検索条件が全て揃っているか判定(引数:ｲﾍﾞﾝﾄ名)
            lblnRet = prvblnSearchCondition_Chk(CMstrCmbSearchTimeValidate)
            '@戻り値の判定
            If lblnRet = True Then
                '@必須検索条件が揃っている時
                cmdSearch.Enabled = True
            Else
                '@必須検索条件が揃っていない場合
                cmdSearch.Enabled = False
            End If
            
            '@機種ｺﾝﾎﾞが有効で検索日時が選択されている場合
            If cmbPD.Enabled = True And _
                cmbSearchTime.Text <> vbNullString Then
                 If ActiveControl.Name = cmbSearchTime.Name Then                 
                    '@機種ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbPD)
                 End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbSearchTime_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPD_Change
    '機　能：機種ｺﾝﾎﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/25 (Tue) 16:30:26 N.Kojima
    '更新日：2006/08/28 (Mon) 12:01:24 N.Kojima
    '備　考：
    Private Sub cmbPd_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPd.Change

        Dim lblnRet         As Boolean      '戻り値判定用

        Try
            
            '@ﾘｽﾄ、各種ﾎﾞﾀﾝ、ｿｰﾄｷｰの初期化
            Call prvInitialize_proc()
            
            '@必須検索条件が全て揃っているか判定(引数:ｲﾍﾞﾝﾄ名)
            lblnRet = prvblnSearchCondition_Chk(CMstrCmbPDChange)
            '@戻り値の判定
            If lblnRet = True Then
                '@必須検索条件が揃っている時
                cmdSearch.Enabled = True
            Else
                '@必須検索条件が揃っていない場合
                cmdSearch.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPD_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPD_CloseUp
    '機　能：機種ｺﾝﾎﾞCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/25 (Tue) 16:55:54 N.Kojima
    '更新日：2006/07/25 (Tue) 16:55:54
    '備　考：
    Private Sub cmbPd_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPd.CloseUp

        Try
            
            '@空欄 or 0項目以外の場合
            If cmbPd.Text <> vbNullString And _
                cmbPd.Text <> CMstrCmbNotSelect Then
                
                '@種別ｺﾝﾎﾞを有効にする
                cmbFlowClass.Enabled = True
                
                RemoveHandler cmbPd.Validating, AddressOf cmbPd_Validate
                Call cmbPd_Validate(sender, New CancelEventArgs(True))
                AddHandler cmbPd.Validating, AddressOf cmbPd_Validate

            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPD_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPD_Validate
    '機　能：機種ｺﾝﾎﾞValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/07/25 (Tue) 16:56:28 N.Kojima
    '更新日：2006/08/28 (Mon) 12:01:28 N.Kojima
    '備　考：
    Private Sub cmbPd_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPd.Validating

        Dim lblnRet         As Boolean      '戻り値

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
                                
            '@必須検索条件が全て揃っているか判定(引数:ｲﾍﾞﾝﾄ名)
            lblnRet = prvblnSearchCondition_Chk(CMstrCmbPdValidate)
            '@戻り値の判定
            If lblnRet = True Then
                '@必須検索条件が揃っている時
                cmdSearch.Enabled = True
            Else
                '@必須検索条件が揃っていない場合
                cmdSearch.Enabled = False
            End If
            
            If ActiveControl.Name = cmbPd.Name Then 
                '@種別にﾌｫｰｶｽｾｯﾄ
                If cmbFlowClass.Enabled = True Then
                    'If ActiveControl.Name = cmbPd.Name Then 
                        Call pubSetFocus(cmbFlowClass)
                    'End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPD_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbFlowClass_Change
    '機　能：種別ｺﾝﾎﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/25 (Tue) 16:26:46 N.Kojima
    '更新日：2006/08/28 (Mon) 12:01:33 N.Kojima
    '備　考：
    Private Sub cmbFlowClass_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbFlowClass.Change

        Dim lblnRet         As Boolean      '戻り値判定用

        Try
            
            '@ﾘｽﾄ、各種ﾎﾞﾀﾝ、ｿｰﾄｷｰの初期化
            Call prvInitialize_proc()

            '@必須検索条件が全て揃っているか判定(引数:ｲﾍﾞﾝﾄ名)
            lblnRet = prvblnSearchCondition_Chk(CMstrCmbFlowClassChange)
            '@戻り値の判定
            If lblnRet = True Then
                '@必須検索条件が揃っている時
                cmdSearch.Enabled = True
            Else
                '@必須検索条件が揃っていない場合
                cmdSearch.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbFlowClass_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbFlowClass_CloseUp
    '機　能：種別ｺﾝﾎﾞCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/25 (Tue) 16:28:17 N.Kojima
    '更新日：2006/07/25 (Tue) 16:28:17
    '備　考：
    Private Sub cmbFlowClass_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbFlowClass.CloseUp

        Try
            
            '@空欄 or 0項目以外の場合
            If cmbFlowClass.Text <> vbNullString And _
                cmbFlowClass.Text <> CMstrCmbNotSelect Then
                
                '@Validate処理へ
                RemoveHandler cmbFlowClass.Validating, AddressOf cmbFlowClass_Validate
                Call cmbFlowClass_Validate(sender, New CancelEventArgs(True))
                AddHandler cmbFlowClass.Validating, AddressOf cmbFlowClass_Validate
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbFlowClass_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbFlowClass_Validate
    '機　能：種別ｺﾝﾎﾞValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/07/25 (Tue) 16:29:14 N.Kojima
    '更新日：2006/08/28 (Mon) 12:01:42 N.Kojima
    '備　考：
    Private Sub cmbFlowClass_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbFlowClass.Validating
        
        Dim lblnRet         As Boolean      '戻り値

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
                                   
            '@必須検索条件が全て揃っているか判定(引数:ｲﾍﾞﾝﾄ名)
            lblnRet = prvblnSearchCondition_Chk(CMstrCmbFlowClassValidate)
            '@戻り値の判定
            If lblnRet = True Then
                '@必須検索条件が揃っている時
                cmdSearch.Enabled = True
            Else
                '@必須検索条件が揃っていない場合
                cmdSearch.Enabled = False
            End If
            
            If ActiveControl.Name = cmbFlowClass.Name Then
                '@工程指定ﾁｪｯｸﾎﾞｯｸｽにﾌｫｰｶｽｾｯﾄ
                If chkProcess.Enabled = True Then
                    If ActiveControl.Name = cmbFlowClass.Name Then
                        Call pubSetFocus(chkProcess)
                    End If
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

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbOp_Change
    '機　能：大工程ｺﾝﾎﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/01 (Tue) 14:28:01 N.Kojima
    '更新日：2006/08/01 (Tue) 14:28:01
    '備　考：
    Private Sub cmbOp_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOp.Change

        Try
                        
            '@項目の初期化
            cmbStep.Clear                         '小工程(ｺﾝﾎﾞのｾｯﾄ内容ごとｸﾘｱ)
            cmbStep.Enabled = False               '非活性化
            
            '@退避変数を初期化
            mstrOpID = vbNullString
            
            '@ﾘｽﾄ、各種ﾎﾞﾀﾝ、ｿｰﾄｷｰの初期化
            Call prvInitialize_proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbOp_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbOp_CloseUp
    '機　能：大工程ｺﾝﾎﾞのCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/01 (Tue) 14:31:53 N.Kojima
    '更新日：2006/08/01 (Tue) 14:31:53
    '備　考：
    Private Sub cmbOp_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOp.CloseUp

        Try
                        
            '@cmbOpのValidateｲﾍﾞﾝﾄ呼び出す
            If cmbOp.Text <> vbNullString Then
                RemoveHandler cmbOp.Validating, AddressOf cmbOp_validate
                Call cmbOp_Validate(sender, New CancelEventArgs(True))
                AddHandler cmbOp.Validating, AddressOf cmbOp_validate
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbOp_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbOp_Validate
    '機　能：大工程ｺﾝﾎﾞのValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/08/01 (Tue) 14:32:26 N.Kojima
    '更新日：2008/01/22 (Tue) 10:26:29 N.Kojima
    '備　考：
    '　　　：2008/01/22 (Tue) 10:26:29 N.Kojima     lot_.steplistの要求に"LOT_LIST"追加に関連して処理修正。(案件№02405)
    Private Sub cmbOp_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbOp.Validating
        
        Dim lblnAns         As Boolean               '結果格納
        Dim ltypLotList     As List(Of LotIdList)    'ﾛｯﾄﾘｽﾄ(引数合わせ用)
        
        Try
           
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If           
           
           '@大工程が変わっていない場合処理しない
            If mstrOpID = cmbOp.Text Then
                '@小工程ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = cmbOp.Name Then
                    If cmbStep.Enabled = True Then
                        Call pubSetFocus(cmbStep)
                    Else
                        '@ｷｬﾘｱ位置指定ﾁｪｯｸﾎﾞｯｸｽにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(chkCarrierPosition)
                    End If
                End If
                Exit Sub
            Else
                '@大工程が空欄の場合には,処理しない
                If cmbOp.Text = vbNullString Then
                    Exit Sub
                End If
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmbOpValidate)
            
            '@小工程取得処理を起動
            '@小工程取得
            lblnAns = pubblnLotStepList_Sel(pstrSBID, _
                                            CMstrlot_steplistVer, _
                                            CPstrCD28, _
                                            ltypLotList, _
                                            mtypMasStepList, _
                                            cmbOp.Text)

             '@結果判定
            If lblnAns = True Then
                '@小工程取得成功
                
                '@小工程ｺﾝﾎﾞを有効にする
                cmbStep.Enabled = True
                
                '@小工程ｺﾝﾎﾞにﾃﾞｰﾀをｾｯﾄ
                Call prvcmbStep_Disp()
                If ActiveControl.Name = cmbOp.Name Then
                    '@小工程ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    If cmbStep.Enabled = True Then
                        Call pubSetFocus(cmbStep)
                    End If
                End If
            Else
                '@小工程取得失敗
                
                '@退避変数をｸﾘｱ
                mstrOpID = vbNullString
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmbOpValidate)
                
                '@ﾌｫｰｶｽ保持
                Me.CancelButton = Nothing
                Exit Sub
            End If
                            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrCmbOpValidate)
            
            '@退避領域へ大工程をｾｯﾄ
            mstrOpID = cmbOp.Text
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbOp_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbStep_Change
    '機　能：小工程ｺﾝﾎﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/01 (Tue) 15:11:38 N.Kojima
    '更新日：2006/08/01 (Tue) 15:11:38
    '備　考：
    Private Sub cmbStep_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbStep.Change

        Try
           
            '@退避変数の初期化
            mstrStepID = vbNullString

            '@ﾘｽﾄ、各種ﾎﾞﾀﾝ、ｿｰﾄｷｰの初期化
            Call prvInitialize_proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbStep_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbStep_CloseUp
    '機　能：小工程ｺﾝﾎﾞのCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/01 (Tue) 15:15:07 N.Kojima
    '更新日：2006/08/01 (Tue) 15:15:07
    '備　考：
    Private Sub cmbStep_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbStep.CloseUp

        Try
               
            '@cmbStepのValidateｲﾍﾞﾝﾄ呼び出す
            RemoveHandler cmbStep.Validating, AddressOf cmbStep_Validate
            Call cmbStep_Validate(sender, New CancelEventArgs(True))
            AddHandler cmbStep.Validating, AddressOf cmbStep_Validate


            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbStep_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbStep_Validate
    '機　能：小工程ｺﾝﾎﾞのValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/08/01 (Tue) 15:15:27 N.Kojima
    '更新日：2006/08/28 (Mon) 11:59:48 N.Kojima
    '備　考：
    Private Sub cmbStep_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbStep.Validating

        Dim lblnRet         As Boolean      '戻り値判定用

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
        
            
            '@小工程が変わっていない場合処理しない
            If mstrStepID = cmbStep.Text Then
                 If ActiveControl.Name = cmbStep.Name Then
                    '@ｷｬﾘｱ位置指定ﾁｪｯｸﾎﾞｯｸｽにﾌｫｰｶｽｾｯﾄ
                    If chkCarrierPosition.Enabled = True Then
                        Call pubSetFocus(chkCarrierPosition)
                    End If
                 End If

                Exit Sub
            Else
                '@小工程が空欄の場合には,処理しない
                If cmbStep.Text = vbNullString Then
                    Exit Sub
                End If
            End If

            '@退避領域へｾｯﾄ
            mstrStepID = cmbStep.Text

            '@必須検索条件が全て揃っているか判定(引数:ｲﾍﾞﾝﾄ名)
            lblnRet = prvblnSearchCondition_Chk(CMstrCmbStepValidate)
            '@戻り値の判定
            If lblnRet = True Then
                '@必須検索条件が揃っている場合は、検索ﾎﾞﾀﾝを有効にする
                cmdSearch.Enabled = True
            Else
                '@必須検索条件が揃っていない場合、検索ﾎﾞﾀﾝを無効にする
                cmdSearch.Enabled = False
            End If

            If ActiveControl.Name = cmbStep.Name Then
                '@ｷｬﾘｱ位置指定ﾁｪｯｸﾎﾞｯｸｽにﾌｫｰｶｽｾｯﾄ
                If chkCarrierPosition.Enabled = True Then
                    Call pubSetFocus(chkCarrierPosition)
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbStep_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbCurrentPosition_Change
    '機　能：ｷｬﾘｱ位置ｺﾝﾎﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/28 (Mon) 15:10:35 N.Kojima
    '更新日：2006/08/28 (Mon) 15:10:35
    '備　考：
    Private Sub cmbCurrentPosition_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCurrentPosition.Change

        Try
            
            '@退避変数の初期化
            mstrCurrentPosition = vbNullString

            '@ﾘｽﾄ、各種ﾎﾞﾀﾝ、ｿｰﾄｷｰの初期化
            Call prvInitialize_proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbCurrentPosition_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbCurrentPosition_CloseUp
    '機　能：ｷｬﾘｱ位置ｺﾝﾎﾞのCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/28 (Mon) 15:11:45 N.Kojima
    '更新日：2006/08/28 (Mon) 15:11:45
    '備　考：
    Private Sub cmbCurrentPosition_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbCurrentPosition.CloseUp

        Try
                          
            '@cmbCurrentPositionのValidateｲﾍﾞﾝﾄ呼び出す
            RemoveHandler cmbCurrentPosition.Validating, AddressOf cmbCurrentPosition_Validate
            Call cmbCurrentPosition_Validate(sender, New CancelEventArgs(True))
            AddHandler cmbCurrentPosition.Validating, AddressOf cmbCurrentPosition_Validate



            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbCurrentPosition_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbCurrentPosition_Validate
    '機　能：ｷｬﾘｱ位置ｺﾝﾎﾞのValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/08/28 (Mon) 12:02:23 N.Kojima
    '更新日：2006/08/28 (Mon) 12:02:23
    '備　考：
    Private Sub cmbCurrentPosition_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbCurrentPosition.Validating

        Dim lblnRet         As Boolean      '戻り値判定用

        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            

            '@ｷｬﾘｱ位置が変わっていない場合処理しない
            If mstrCurrentPosition = cmbCurrentPosition.Text Then
                '@ﾎﾟｲﾝﾄｺﾝﾎﾞが有効な場合、ﾌｫｰｶｽｾｯﾄ
                If cmbPartCode.Enabled = True Then
                    If ActiveControl.Name = cmbCurrentPosition.Name Then
                        Call pubSetFocus(cmbPartCode)
                    End if
                End If
                Exit Sub
            Else
                '@ｷｬﾘｱ位置が空欄の場合には,処理しない
                If cmbCurrentPosition.Text = vbNullString Then
                    Exit Sub
                End If
            End If

            '@退避領域へｾｯﾄ
            mstrCurrentPosition = cmbCurrentPosition.Text

            '@必須検索条件が全て揃っているか判定(引数:ｲﾍﾞﾝﾄ名)
            lblnRet = prvblnSearchCondition_Chk(CMstrCmbCurrentPositionValidate)
            '@戻り値の判定
            If lblnRet = True Then
                '@必須検索条件が揃っている場合は、検索ﾎﾞﾀﾝを有効にする
                cmdSearch.Enabled = True
            Else
                '@必須検索条件が揃っていない場合、検索ﾎﾞﾀﾝを無効にする
                cmdSearch.Enabled = False
            End If
            
            '@ﾎﾟｲﾝﾄｺﾝﾎﾞが有効な場合、ﾌｫｰｶｽｾｯﾄ
            If ActiveControl.Name = cmbCurrentPosition.Name Then
                If cmbPartCode.Enabled = True Then
                    Call pubSetFocus(cmbPartCode)
               
                Else
                    '@無効な場合、閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
            End if
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbCurrentPosition_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPartCode_Change
    '機　能：ﾎﾟｲﾝﾄｺﾝﾎﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/01 (Tue) 15:11:38 N.Kojima
    '更新日：2006/08/01 (Tue) 15:11:38
    '備　考：
    Private Sub cmbPartCode_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPartCode.Change

        Try
            
            '@ﾘｽﾄ、各種ﾎﾞﾀﾝ、ｿｰﾄｷｰの初期化
            Call prvInitialize_proc()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPartCode_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPartCode_CloseUp
    '機　能：ﾎﾟｲﾝﾄｺﾝﾎﾞのCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/01 (Tue) 15:15:07 N.Kojima
    '更新日：2006/08/01 (Tue) 15:15:07
    '備　考：
    Private Sub cmbPartCode_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPartCode.CloseUp

        Try
                           
            '@cmbPartCodeのValidateｲﾍﾞﾝﾄ呼び出す
            RemoveHandler cmbPartCode.Validating, AddressOf cmbPartCode_Validate
            Call cmbPartCode_Validate(cmbPartCode, New CancelEventArgs(True))
            AddHandler cmbPartCode.Validating, AddressOf cmbPartCode_Validate

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPartCode_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPartCode_Validate
    '機　能：ﾎﾟｲﾝﾄｺﾝﾎﾞのValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/08/01 (Tue) 15:15:27 N.Kojima
    '更新日：2006/08/28 (Mon) 12:02:23 N.Kojima
    '備　考：
    Private Sub cmbPartCode_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPartCode.Validating

        Dim lblnRet         As Boolean      '戻り値判定用

        Try
           
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@必須検索条件が全て揃っているか判定(引数:ｲﾍﾞﾝﾄ名)
            lblnRet = prvblnSearchCondition_Chk(CMstrcmbPartCodeValidate)
            '@戻り値の判定
            If lblnRet = True Then
                '@必須検索条件が揃っている場合は、検索ﾎﾞﾀﾝを有効にする
                cmdSearch.Enabled = True
            Else
                '@必須検索条件が揃っていない場合、検索ﾎﾞﾀﾝを無効にする
                cmdSearch.Enabled = False
            End If
            
            '@検索ﾎﾞﾀﾝが有効な場合、ﾌｫｰｶｽｾｯﾄ
            If ActiveControl.Name = cmbPartCode.Name 
                If cmdSearch.Enabled = True Then
                    Call pubSetFocus(cmdSearch)
                Else
                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
            End If 

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPartCode_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：chkProcess_Click
    '機　能：工程指定ﾁｪｯｸﾎﾞｯｸｽ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/27 (Thu) 15:07:04 N.Kojima
    '更新日：2006/07/27 (Thu) 15:07:04
    '備　考：
    Private Sub chkProcess_Click(ByVal sender As Object, ByVal e As EventArgs) Handles chkProcess.CheckedChanged

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
           '@ﾌｫｰﾑﾛｰﾄﾞ済みの場合
            If mblnFormLoadFlag = True Then
            
                '@ﾁｪｯｸOFFの場合
                If chkProcess.Checked = 0 Then
                    '@大工程・小工程ｺﾝﾎﾞを無効に
                    cmbOp.Text = vbNullString
                    cmbStep.Text = vbNullString
                    cmbOp.Enabled = False
                    cmbStep.Enabled = False
                    cmbOp.ListIndex = -1
                    cmbStep.ListIndex = -1
                Else
                    '@大工程ｺﾝﾎﾞを有効に
                    cmbOp.Enabled = True

                    '@1件しかない場合は直表示
                    If cmbOp.ListCount = 1 Then
                        '@1件目表示
                        cmbOp.ListIndex = 0
                    End If
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "chkProcess_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名: chkCarrierPosition_Click
    '機　能：ｷｬﾘｱ位置指定ﾁｪｯｸﾎﾞｯｸｽ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/27 (Thu) 15:07:04 N.Kojima
    '更新日：2006/07/27 (Thu) 15:07:04
    '備　考：
    Private Sub chkCarrierPosition_Click(ByVal sender As Object, ByVal e As EventArgs) Handles chkCarrierPosition.CheckedChanged

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
     
            
            '@ﾌｫｰﾑﾛｰﾄﾞ済みの場合
            If mblnFormLoadFlag = True Then

                '@ﾁｪｯｸOFF場合
                If chkCarrierPosition.Checked = 0 Then
                    '@ｷｬﾘｱ位置ｺﾝﾎﾞを無効に
                    cmbCurrentPosition.Text = vbNullString
                    cmbCurrentPosition.Enabled = False
                    cmbCurrentPosition.ListIndex = -1
                Else
                    '@ｷｬﾘｱ位置ｺﾝﾎﾞを有効にする
                    cmbCurrentPosition.Enabled = True

                    '@1件しかない場合は直表示
                    If cmbCurrentPosition.ListCount = 1 Then
                        '@1件目表示
                        cmbCurrentPosition.ListIndex = 0
                    End If
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "chkCarrierPosition_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSearch_Click
    '機　能：検索ﾎﾞﾀﾝClick処理　最新取得
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/25 (Tue) 16:22:50 N.Kojima
    '更新日：2006/08/28 (Mon) 12:12:49 N.Kojima
    '備　考：
    Private Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch.Click
        
        Dim lblnAns         As Boolean      '結果格納
        Dim lngCnt          As Integer      '汎用ｶｳﾝﾄ
        Dim lvrnTemp        As Object       '一時取得

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
            
            '@ﾌｫｰﾑのﾛｯｸ中は処理を行わない
            If Me.Enabled = False Then
                Exit Sub
            End If
            
            '@必須検索条件が全て揃っているか判定(引数:ｲﾍﾞﾝﾄ名)
            lblnAns = prvblnSearchCondition_Chk(CMstrCmdSearchClick)
            '@戻り値の判定
            If lblnAns = False Then
                '@必須検索条件が揃っていない場合
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdSearchClick)

            'NSYS スクロール位置格納
            Dim SrollPosition As Point = vsfSnapShotList.ScrollPosition

            '@要求・応答格納構造体の初期化
            If mtypSnapShotReqList.typPointList Is Nothing Then
               mtypSnapShotReqList.typPointList = New List(Of PointList)
            Else
               mtypSnapShotReqList.typPointList.Clear()
            End If
            If mtypSnapShotReqList.typFlowClassList Is Nothing Then
               mtypSnapShotReqList.typFlowClassList = New List(Of FlowClassList)
            Else
               mtypSnapShotReqList.typFlowClassList.Clear()
            End If
            If mtypSnapShotReqList.typPdList Is Nothing Then
               mtypSnapShotReqList.typPdList = New List(Of PDList)
            Else
               mtypSnapShotReqList.typPdList.Clear()
            End If
            If mtypSnapShotAnsList.typSnapShotList Is Nothing Then
               mtypSnapShotAnsList.typSnapShotList = New List(Of SnapShotAns)
            Else
               mtypSnapShotAnsList.typSnapShotList.Clear()
            End If
            
            '@要求格納構造体へ格納
            With mtypSnapShotReqList
                .strSbID = pstrSBID                                                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strMsgVer = CMstrlot_snapshotlistVer                                   'MsgVer
                .strSearchDate = calSearchDate.Value & CPstrSpace & cmbSearchTime.Text  '検索日時(年月日+" "+時間)
                .strOpID = cmbOp.Text                                                   '大工程
                .strStepID = cmbStep.Text                                               '小工程
                .strCurrentPositionID = cmbCurrentPosition.Value                        'ｷｬﾘｱ位置
                       
                '@機種区分構造体作成
                .lngPdCnt = cmbPD.ValueCount                                            '機種選択数
                If cmbPD.ValueCount <> 0 Then
                    'ReDim Preserve .typPdList(.lngPdCnt)                                '配列再定義
                .typPdList = New List(Of PDList)                  
                lvrnTemp = Split(cmbPD.Value, vbTab)
                Dim typPdlistTmp = New PDList
                For lngCnt = LBound(lvrnTemp) To UBound(lvrnTemp)
                    typPdlistTmp.strPDID = lvrnTemp(lngCnt)               '機種
                    .typPdList.Add(typPdlistTmp)
                Next lngCnt
                    
                End If
                
                '@種別構造体作成
                .lngFlowClassCnt = cmbFlowClass.ValueCount                              '種別選択数
                If cmbFlowClass.ValueCount <> 0 Then
                    'ReDim Preserve .typFlowClassList(.lngFlowClassCnt)                  '配列再定義               
                    .typFlowClassList = New List(Of FlowClassList)                                    
                    lvrnTemp = Split(cmbFlowClass.Value, vbTab)
                    Dim typFlowClassListTmp = New FlowClassList
                    For lngCnt = LBound(lvrnTemp) To UBound(lvrnTemp)
                        typFlowClassListTmp.strFlowClass = lvrnTemp(lngCnt)   '種別
                        .typFlowClassList.Add(typFlowClassListTmp)
                    Next lngCnt
                End If
                
                '@実績ﾎﾟｲﾝﾄ構造体作成
                .lngPointCnt = cmbPartCode.ValueCount                                   'ﾎﾟｲﾝﾄ選択数
                If cmbPartCode.ValueCount <> 0 Then
                    'ReDim Preserve .typPointList(.lngPointCnt)                          '配列再定義
                    .typPointList = New List(Of PointList) 
                    lvrnTemp = Split(cmbPartCode.Value, vbTab)
                    Dim typPointListtmp As PointList = New PointList 
                    For lngCnt = LBound(lvrnTemp) To UBound(lvrnTemp)
                        typPointListtmp.strPoint = lvrnTemp(lngCnt)                     'ﾎﾟｲﾝﾄ
                        .typPointList.Add(typPointListtmp)
                    Next lngCnt
                End If
            End With
                
            '@過去在庫一覧取得
            lblnAns = pubblnLotSnapShotList_Sel(mtypSnapShotReqList, _
                                                mtypSnapShotAnsList)

            '@戻り値判定
            If lblnAns = True Then
                                
                '@過去在庫一覧表示
                Call prvvsfSnapShotList_Disp()

                'NSYS スクロール位置設定
                 vsfSnapShotList.ScrollPosition = New Point(SrollPosition.X,vsfSnapShotList.ScrollPosition.Y)

                '@1件以上ﾃﾞｰﾀが存在する場合
                If mtypSnapShotAnsList.lngSnapShotListCnt > 0 Then
                    
                    '@各種ﾎﾞﾀﾝを無効に
                    cmdAllCancel.Enabled = False        '全取消
                    cmdLotPrintDisp.Enabled = False     'ﾛｯﾄ一覧帳票表示
                    cmdPrint.Enabled = False            '星取表印刷
                    cmdWFMapDisp.Enabled = False        '星取表表示
                Else
                    '@該当件数が0件の場合
                     '@過去在庫一覧のｸﾘｱ
                    Call prvvsfSnapShotList_Init()

                    '@各種ﾎﾞﾀﾝを無効に
                    cmdAllCancel.Enabled = False        '全取消
                    cmdLotPrintDisp.Enabled = False     'ﾛｯﾄ一覧帳票表示
                    cmdPrint.Enabled = False            '星取表印刷
                    cmdWFMapDisp.Enabled = False        '星取表表示
                End If

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdSearchClick)
            Else              
                '@過去在庫一覧のｸﾘｱ
                Call prvvsfSnapShotList_Init()
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdSearchClick)

                '@各種ﾎﾞﾀﾝを無効に
                cmdAllCancel.Enabled = False        '全取消
                cmdLotPrintDisp.Enabled = False     'ﾛｯﾄ一覧帳票表示
                cmdPrint.Enabled = False            '星取表印刷
                cmdWFMapDisp.Enabled = False        '星取表表示

                Exit Sub
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ﾌｫｰﾑﾛｯｸ解除
            'Me.Enabled = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSearch_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSnapShotList_AfterSort
    '機　能：過去在庫一覧　ｿｰﾄ後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2006/08/03 (Thu) 14:35:11 N.Kojima
    '更新日：2006/08/03 (Thu) 14:35:11
    '備　考：
    Private Sub vsfSnapShotList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfSnapShotList.AfterSort
        Dim ScrollPosition As Point
        Try
           'NSYS データ行がない場合は処理を抜ける
            If vsfSnapShotList.Rows.Count <= vsfSnapShotList.Rows.Fixed Then
                Return
            End If
            vsfSnapShotList.Redraw = False
            'NSYS スクロール位置格納
            ScrollPosition = vsfSnapShotList.ScrollPosition

            '@ｿｰﾄ後のｶﾚﾝﾄ行設定（ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁）
            Call pubVsfAfterSort(vsfSnapShotList, CMlngvsfRowTitle, Nothing, Nothing, False, False, False, False)

            vsfSnapShotList.ScrollPosition = New Point(ScrollPosition.X,vsfSnapShotList.ScrollPosition.Y)
            vsfSnapShotList.Redraw = True

            AddHandler vsfSnapShotList.EnterCell, AddressOf vsfSnapShotList_EnterCell
            AddHandler vsfSnapShotList.BeforeRowColChange, AddressOf vsfSnapShotList_BeforeRowColChange

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSnapShotList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSnapShotList_AfterUserResize
    '機　能：過去在庫一覧　列幅変更処理
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2006/08/03 (Thu) 15:01:42 N.Kojima
    '更新日：2006/08/03 (Thu) 15:01:42
    '備　考：
    Private Sub vsfSnapShotList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfSnapShotList.AfterResizeColumn, vsfSnapShotList.AfterResizeRow

        Try
           'NSYS データ行がない場合は処理を抜ける
            If vsfSnapShotList.Rows.Count <= vsfSnapShotList.Rows.Fixed Then
                Return
            End If

             '@列幅変更ﾌﾗｸﾞ(変更)
            mtypChgSort.blnChgWidth = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSnapShotList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSnapShotList_BeforeRowColChange
    '機　能：過去在庫一覧　行列変更前処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/08/03 (Thu) 15:01:17 N.Kojima
    '更新日：2006/08/03 (Thu) 15:01:17
    '備　考：
    Private Sub vsfSnapShotList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfSnapShotList.BeforeRowColChange

        Try
             'NSYS データ行がない場合は処理を抜ける
            If vsfSnapShotList.Rows.Count <= vsfSnapShotList.Rows.Fixed Then
                Return
            End If
         
             
             '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納（ﾛｯﾄID）
                mtypChgSort.strKey = vsfSnapShotList.GetData(e.NewRange.r1, CMlngvsfSnapShotListColLotID)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSnapShotList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSnapShotList_BeforeSort
    '機　能：過去在庫一覧　ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2006/08/03 (Thu) 14:35:48 N.Kojima
    '更新日：2006/08/03 (Thu) 14:35:48
    '備　考：
    Private Sub vsfSnapShotList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfSnapShotList.BeforeSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfSnapShotList.Rows.Count <= vsfSnapShotList.Rows.Fixed Then
                Return
            End If

            RemoveHandler vsfSnapShotList.EnterCell, AddressOf vsfSnapShotList_EnterCell
            RemoveHandler vsfSnapShotList.BeforeRowColChange, AddressOf vsfSnapShotList_BeforeRowColChange
           
            
            '@ｿｰﾄ順を格納
            With mtypChgSort
               
                'ReDim Preserve .typChgSortList(.lngCnt) 
                If  .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList) 
                End If

                Dim typChgSortListTmp As ChgSortList 
                '@ｿｰﾄ列番号を格納
                typChgSortListTmp.lngCol = e.Col
                '@並び替え方法を格納（昇順/降順）
                typChgSortListTmp.lngOrder = e.Order
                                 
                .typChgSortList.Add(typChgSortListTmp)
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
            End With
            
            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列）
            Call pubVsfBeforeSort(vsfSnapShotList, CMlngvsfRowTitle)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSnapShotList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSnapShotList_Click
    '機　能：過去在庫一覧　Click処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/03 (Thu) 14:59:26 N.Kojima
    '更新日：2006/08/03 (Thu) 14:59:26
    '備　考：ﾛｯﾄ一覧帳票表示ﾎﾞﾀﾝの機能は仕様未確定の為、使用不可です。
    Private Sub vsfSnapShotList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSnapShotList.Click

        Dim llngCnt             As Integer  '汎用ｶｳﾝﾀ
        Dim llngCheckCnt        As Integer  'ﾁｪｯｸｶｳﾝﾀ
        Dim lblnCkeckFlag       As Boolean  'ﾁｪｯｸ判定ﾌﾗｸﾞ

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
         
          
            'NSYS データ行がない場合は処理を抜ける
            If vsfSnapShotList.Rows.Count <= vsfSnapShotList.Rows.Fixed Then
                Return
            End If
         
            If  vsfSnapShotList.MouseRow < 1 
                Exit Sub           
            End If
            With vsfSnapShotList
                
                '@ﾁｪｯｸﾎﾞｯｸｽ行以外の行の場合は、処理終了
                If .Col <> CMlngvsfSnapShotListColCheck Then
                    Exit Sub
                End If
                
                '@ﾁｪｯｸ判定ﾌﾗｸﾞの初期化
                lblnCkeckFlag = False
                
                '@選択行のﾁｪｯｸﾎﾞｯｸｽのﾁｪｯｸが外れているか
                If .GetCellCheck(.Row, CMlngvsfSnapShotListColCheck) = CheckEnum.Unchecked Then
                
                    '@ﾁｪｯｸｶｳﾝﾀの初期化
                    llngCheckCnt = 0
                    
                    '@ﾁｪｯｸが付いている数をｶｳﾝﾄする(※ﾁｪｯｸは10個まで)
                    For llngCnt = 1 To .Rows.Count - 1
                        '@ﾁｪｯｸが付いているか
                        If .GetCellCheck(llngCnt, CMlngvsfSnapShotListColCheck) = CheckEnum.Checked Then
                            '@ｶｳﾝﾀUP
                            llngCheckCnt = llngCheckCnt + 1
                        End If
                        
                        '@ﾁｪｯｸが10個付いている場合
                        If llngCheckCnt >= CMlngChkMaxCnt Then
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008P)
                            '@"<TRM8PW>$$星取表印刷候補ロットは、10ロットまでしか選択することができません。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit Sub
                        End If
                    Next llngCnt
                    
                    '@TFT基板ﾛｯﾄ(CFﾛｯﾄandTPALﾛｯﾄ以外)か
                    If .GetData(.Row, CMlngvsfSnapShotListColCFFlag) = CPstrZero Or _
                        .GetData(.Row, CMlngvsfSnapShotListColCFFlag) = vbNullString Then
                    
                        '@ﾁｪｯｸなし→ﾁｪｯｸ
                        .AllowEditing = True
                        .SetCellCheck(.Row, CMlngvsfSnapShotListColCheck, CheckEnum.Checked)     'ﾁｪｯｸ
                        .AllowEditing = False
                        
                        '@各種ﾎﾞﾀﾝを有効にする
                        cmdPrint.Enabled = True             '星取表印刷
                        cmdAllCancel.Enabled = True         '全取消
        '                cmdLotPrintDisp.Enabled = True      'ﾛｯﾄ一覧帳票表示
                        
                        '@印刷判定ﾌﾗｸﾞをTrue(=ﾁｪｯｸあり)
                        mblnPrintChkFlag = True
                    Else
                        '@CFﾛｯﾄ(CF_FLAG=1,LP_FLAG=0)orTPALﾛｯﾄ(CF_FLAG=2,LP_FLAG=0)orODFﾛｯﾄ(CF_FLAG=1,LP_FLAG=1)の場合
                        
                        '@ODFﾛｯﾄか
                        If .GetData(.Row, CMlngvsfSnapShotListColLpFlag) = CPstrOne Then
                            '@ﾁｪｯｸなし→ﾁｪｯｸ
                            .AllowEditing = True
                            .SetCellCheck(.Row, CMlngvsfSnapShotListColCheck, CheckEnum.Checked)     'ﾁｪｯｸ
                            .AllowEditing = False
                            
                            '@各種ﾎﾞﾀﾝを有効にする
                            cmdPrint.Enabled = True             '星取表印刷
                            cmdAllCancel.Enabled = True         '全取消
        '                    cmdLotPrintDisp.Enabled = True      'ﾛｯﾄ一覧帳票表示
                            
                            '@印刷判定ﾌﾗｸﾞをTrue(=ﾁｪｯｸあり)
                            mblnPrintChkFlag = True
                        End If
                    End If
                Else
                    '@ﾁｪｯｸ→ﾁｪｯｸなし
                    .AllowEditing = True
                    .SetCellCheck(.Row, CMlngvsfSnapShotListColCheck, CheckEnum.Unchecked)   'ﾁｪｯｸ解除
                    .AllowEditing = False
                    
                    For llngCnt = 1 To .Rows.Count - 1
                        '@ﾁｪｯｸが付いているか
                        If .GetCellCheck(llngCnt, CMlngvsfSnapShotListColCheck) = CheckEnum.Checked Then
                            '@ﾁｪｯｸ付いている場合は、ﾌﾗｸﾞをTrue(=ﾁｪｯｸあり)にする
                            lblnCkeckFlag = True
                            Exit For
                        End If
                    Next llngCnt
                    
                    '@ﾁｪｯｸ行が存在しない場合は、各種ﾎﾞﾀﾝを無効にする
                    If lblnCkeckFlag = False Then
                    
                        cmdPrint.Enabled = False            '星取表印刷
                        cmdAllCancel.Enabled = False        '全取消
        '                cmdLotPrintDisp.Enabled = False     'ﾛｯﾄ一覧帳票表示
                        
                        '@印刷判定ﾌﾗｸﾞをFalse(=ﾁｪｯｸなし)
                        mblnPrintChkFlag = False
                    End If
                End If             
            End With
                      
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSnapShotList_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSnapShotList_EnterCell
    '機　能：過去在庫一覧　ｸﾞﾘｯﾄﾞ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/27 (Thu) 11:22:06 N.Kojima
    '更新日：2006/07/27 (Thu) 11:22:06
    '備　考：
    Private Sub vsfSnapShotList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSnapShotList.EnterCell
        
        Dim llngDataNo          As Integer      '選択ﾃﾞｰﾀ№格納用

        Try
           
            'NSYS データ行がない場合は処理を抜ける
            If vsfSnapShotList.Rows.Count <= vsfSnapShotList.Rows.Fixed Then
                Return
            End If
            
            
            '@送品待ちの場合
            With vsfSnapShotList
                '@ﾍｯﾀﾞｰ以外の場合
                If .Row <> 0 Then
                
                    '@ﾃﾞｰﾀ検索用№の取得
                    llngDataNo = CLng(.GetData(.Row, CMlngvsfSnapShotListColNo))

                    '@WFﾘｽﾄｶｳﾝﾄがNULLの場合は処理抜け
                    If mtypSnapShotAnsList.typSnapShotList(llngDataNo-1).lngWfListCnt = 0 Then
                        
                        '@星取表表示ﾎﾞﾀﾝを無効にして、処理抜け
                        cmdWFMapDisp.Enabled = False
                        
                        Exit Sub
                    End If
                
                    '@CFﾛｯﾄorTPALﾛｯﾄ以外
                    If .GetData(.Row, CMlngvsfSnapShotListColCFFlag) = CPstrZero Or _
                        .GetData(.Row, CMlngvsfSnapShotListColCFFlag) = vbNullString Then
                        
                        '@星取表表示ﾎﾞﾀﾝを有効にする
                        cmdWFMapDisp.Enabled = True
                    Else
                        '@ODFﾛｯﾄの場合
                        If .GetData(.Row, CMlngvsfSnapShotListColLpFlag) = CPstrOne Then
                            '@星取表表示ﾎﾞﾀﾝを有効にする
                            cmdWFMapDisp.Enabled = True
                        Else
                            '@星取表表示ﾎﾞﾀﾝを無効にする
                            cmdWFMapDisp.Enabled = False
                        End If
                    End If
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfSnapShotList_EnterCell"
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
    '作成日：2006/07/27 (Thu) 13:17:07 N.Kojima
    '更新日：2006/07/27 (Thu) 13:17:07
    '備　考：
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
           
           
            '@終了関数を実行する
            Call publngEnd_Proc(CPstrKeyEN01Y0, ltypCommonInfo)

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

    '関数名：cmdPrint_Click
    '機　能：星取表印刷　ﾎﾞﾀﾝ押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/04 (Fri) 14:28:12 N.Kojima
    '更新日：2006/08/04 (Fri) 14:28:12
    '備　考：
    Private Sub cmdPrint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdPrint.Click

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
            
            '@ﾌｫｰﾑのﾛｯｸ中は処理を行わない
            If Me.Enabled = False Then
                Exit Sub
            End If
            
            '@印刷要求判定ﾌﾗｸﾞの初期化
            pblnReqPrint = False
            
            '@印刷処理
            With vsfSnapShotList
                '@印刷判定ﾌﾗｸﾞがTrue(=ﾁｪｯｸあり)の場合
                If mblnPrintChkFlag = True Then
                    
                    '@印刷要求判定ﾌﾗｸﾞをTrue(印刷)に設定
                    pblnReqPrint = True
                    
                    '@星取表表示ﾎﾞﾀﾝ押下処理を起動
                    Call cmdWFMapDisp_Click(sender, e)
                End If
            End With

            '@印刷要求判定ﾌﾗｸﾞの初期化(一応)
            pblnReqPrint = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdPrint_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdAllCancel_Click
    '機　能：全取消ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/02 (Wed) 11:20:24 N.Kojima
    '更新日：2006/08/02 (Wed) 11:20:24
    '備　考：ﾛｯﾄ一覧帳票表示ﾎﾞﾀﾝの機能は仕様未確定の為、使用不可です。
    Private Sub cmdAllCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAllCancel.Click

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try
           
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
    

            With vsfSnapShotList
                For llngCnt = 1 To .Rows.Count - 1
                    '@ﾁｪｯｸﾎﾞｯｸｽのﾁｪｯｸを外す
                    .SetCellCheck(llngCnt, CMlngvsfSnapShotListColCheck, CheckEnum.Unchecked)
                Next llngCnt
                
                '@各種ﾎﾞﾀﾝを無効にする
                cmdAllCancel.Enabled = False        '全取消
                cmdPrint.Enabled = False            '星取表印刷
        '        cmdLotPrintDisp.Enabled = False    'ﾛｯﾄ一覧帳票表示
                
            End With

            '@印刷判定ﾌﾗｸﾞをFalse(=ﾁｪｯｸなし)に設定
            mblnPrintChkFlag = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdAllCancel_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWFMapDisp_Click
    '機　能：星取表表示ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/02 (Wed) 11:20:24 N.Kojima
    '更新日：2007/11/15 (Thu) 14:24:49 N.Kasai
    '備　考：
    '　　　：2006/09/28 (Thu) 17:56:30 N.Kojima     棚卸改善対応に伴い、処理修正。(案件№01517)
    '　　　：2007/11/15 (Thu) 14:24:49 N.Kasai      №02294
    Private Sub cmdWFMapDisp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWFMapDisp.Click

        Dim llngCnt             As Integer  '汎用ｶｳﾝﾀ
        Dim llngDataNo          As Integer  '選択ﾃﾞｰﾀ№格納用
        Dim llngWFListCnt       As Integer  'WFListｶｳﾝﾄ数格納用
        Dim lblnRtn             As Boolean  '汎用戻り値
        Dim llngPdCnt           As Integer  '機種ｶｳﾝﾀ

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is cmdWFMapDisp Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If


            With vsfSnapShotList
                    
                '@印刷ﾛｯﾄ数ｶｳﾝﾀの初期化
                plngPrintLotCnt = 0
                
                '@星取表印刷画面からの起動の場合
                If pblnReqPrint = True Then
                    
                    '@機種別ｽﾛｯﾄﾏｯﾌﾟ情報取得
                    lblnRtn = prvblnPdMapInfo_proc
                    '@戻り値判定
                    If lblnRtn = False Then
                        Exit Sub
                    End If
                    
                    For llngCnt = 1 To .Rows.Count - 1
                        '@ﾁｪｯｸが付いているか
                        If .GetCellCheck(llngCnt, CMlngvsfSnapShotListColCheck) = CheckEnum.Checked Then
                            
                            
                            '@ﾃﾞｰﾀ検索用に№を退避(Col№)
                            llngDataNo = CLng(.GetData(llngCnt, CMlngvsfSnapShotListColNo))
                            
                            '@WFﾘｽﾄｶｳﾝﾄがNULLの場合は処理抜け
                            If mtypSnapShotAnsList.typSnapShotList(llngDataNo-1).lngWfListCnt = 0 Then
                                
                                '@引継ぎ構造体を初期化し、処理抜け
                                If ptypTakeOverDataEN01Y0 Is Nothing Then                                      '星取表表示画面への引継ぎ用配列
                                   ptypTakeOverDataEN01Y0= New List(Of TakeOverDataEN01Y0)
                                Else 
                                   ptypTakeOverDataEN01Y0.Clear()
                                End If
                                plngPrintLotCnt = 0                                                            '印刷ﾛｯﾄ数ｶｳﾝﾀ
                                
                                Exit Sub
                            End If

                            '@ｶｳﾝﾀをUP
                            plngPrintLotCnt = plngPrintLotCnt + 1

                            '@配列の再定義
                            If ptypTakeOverDataEN01Y0 Is Nothing Then
                                ptypTakeOverDataEN01Y0 = New List(Of TakeOverDataEN01Y0) 
                            End If
                            Dim ptypTakeOverDataEN01Y0Tmp = New TakeOverDataEN01Y0
                            
                            '@引継ぎ情報を格納
                            ptypTakeOverDataEN01Y0Tmp.strCarrierId = .GetData(llngCnt, CMlngvsfSnapShotListColCarrierID)         'ｷｬﾘｱID
                            ptypTakeOverDataEN01Y0Tmp.strLotID = .GetData(llngCnt, CMlngvsfSnapShotListColLotID)                 'ﾛｯﾄID
                            ptypTakeOverDataEN01Y0Tmp.strPdId = .GetData(llngCnt, CMlngvsfSnapShotListColPD)                     '機種
                            ptypTakeOverDataEN01Y0Tmp.strFlowClass = .GetData(llngCnt, CMlngvsfSnapShotListColFlowClass)         '種別
                            ptypTakeOverDataEN01Y0Tmp.strOpID = .GetData(llngCnt, CMlngvsfSnapShotListColOpID)                   '大工程
                            ptypTakeOverDataEN01Y0Tmp.strStepID = .GetData(llngCnt, CMlngvsfSnapShotListColStepID)               '小工程
                            ptypTakeOverDataEN01Y0Tmp.strMPROrder = .GetData(llngCnt, CMlngvsfSnapShotListColMPROrder)           '量産ｵｰﾀﾞｰ
                            ptypTakeOverDataEN01Y0Tmp.strPartCode = .GetData(llngCnt, CMlngvsfSnapShotListColPartCode)           '部品ｺｰﾄﾞ
                            ptypTakeOverDataEN01Y0Tmp.strPoint = .GetData(llngCnt, CMlngvsfSnapShotListColPoint)                 'ﾎﾟｲﾝﾄ
                            ptypTakeOverDataEN01Y0Tmp.strSearchDate = calSearchDate.Value & CPstrSpace & cmbSearchTime.Text               '検索日時
                            ptypTakeOverDataEN01Y0Tmp.strCfFlag = .GetData(llngCnt, CMlngvsfSnapShotListColCFFlag)               'CFﾌﾗｸﾞ
                            ptypTakeOverDataEN01Y0Tmp.strLpFlag = .GetData(llngCnt, CMlngvsfSnapShotListColLpFlag)               'LPﾌﾗｸﾞ
                            ptypTakeOverDataEN01Y0Tmp.lngWfListCnt = mtypSnapShotAnsList.typSnapShotList(llngDataNo-1).lngWfListCnt         'WFﾘｽﾄｶｳﾝﾄ

                            '@過去在庫ﾘｽﾄのWFﾘｽﾄ
                            llngWFListCnt = mtypSnapShotAnsList.typSnapShotList(llngDataNo-1).lngWfListCnt
                            
                            '@配列の再定義
                            ptypTakeOverDataEN01Y0Tmp.typWfList = New List(Of SnapWfList)
                            ptypTakeOverDataEN01Y0Tmp.typRowNumList  = New List(Of MasPdMap)

                            '@WFﾘｽﾄの配列をｺﾋﾟｰ
                            ptypTakeOverDataEN01Y0Tmp.typWfList = _
                               mtypSnapShotAnsList.typSnapShotList(llngDataNo-1).typWfList

                            '機種別ｽﾛｯﾄﾏｯﾌﾟ反映
                            For llngPdCnt = 0 To mtypSnapPDMap.strSnapPDCnt-1
                                '@機種ID判定
                                If mtypSnapPDMap.typSnapPDList(llngPdCnt).strPdId = ptypTakeOverDataEN01Y0Tmp.strPdId Then

                                    ptypTakeOverDataEN01Y0Tmp.lngRowNumListCnt =
                                        mtypSnapPDMap.typSnapPDList(llngPdCnt).lngRowNumListCnt     'ﾁｯﾌﾟﾏｯﾌﾟ情報

                                    ptypTakeOverDataEN01Y0Tmp.typRowNumList =
                                        mtypSnapPDMap.typSnapPDList(llngPdCnt).typRowNumList
                                    Exit For
                                End If
                            Next
                        ptypTakeOverDataEN01Y0.Add(ptypTakeOverDataEN01Y0Tmp)

                        End If
                    Next llngCnt
                Else

                    
                    '@ﾃﾞｰﾀ検索用に№を退避(Col№)
                    llngDataNo = CLng(.GetData(.Row, CMlngvsfSnapShotListColNo))

                    '@WFﾘｽﾄｶｳﾝﾄがNULLの場合は処理抜け
                    If mtypSnapShotAnsList.typSnapShotList(llngDataNo-1).lngWfListCnt = 0 Then
                        
                        '@引継ぎ構造体を初期化し、処理抜け
                        If ptypTakeOverDataEN01Y0 Is Nothing Then          '星取表表示画面への引継ぎ用配列
                            ptypTakeOverDataEN01Y0 = New List(Of TakeOverDataEN01Y0)
                         Else
                            ptypTakeOverDataEN01Y0.Clear()
                         End If
                        plngPrintLotCnt = 0                                 '印刷ﾛｯﾄ数ｶｳﾝﾀ
                        
                        Exit Sub
                    End If
                            
                    
                    '@機種別ｽﾛｯﾄﾏｯﾌﾟ情報取得
                    lblnRtn = prvblnPdMapInfo_proc
                    '@戻り値判定
                    If lblnRtn = False Then
                        Exit Sub
                    End If
                    
                    '@ｶｳﾝﾀをUP
                    plngPrintLotCnt = 1
                
                    '@配列の再定義
                    'ReDim Preserve ptypTakeOverDataEN01Y0(plngPrintLotCnt)
                    If ptypTakeOverDataEN01Y0 Is Nothing Then
                        ptypTakeOverDataEN01Y0 = New List(Of TakeOverDataEN01Y0)
                    End If 
                    
                    Dim  ptypTakeOverDataEN01Y0Tmp = New TakeOverDataEN01Y0

                    '@引継ぎ情報を格納
                    ptypTakeOverDataEN01Y0Tmp.strCarrierId = .GetData(.Row, CMlngvsfSnapShotListColCarrierID)            'ｷｬﾘｱID
                    ptypTakeOverDataEN01Y0Tmp.strLotID = .GetData(.Row, CMlngvsfSnapShotListColLotID)                    'ﾛｯﾄID
                    ptypTakeOverDataEN01Y0Tmp.strPdId = .GetData(.Row, CMlngvsfSnapShotListColPD)                        '機種
                    ptypTakeOverDataEN01Y0Tmp.strFlowClass = .GetData(.Row, CMlngvsfSnapShotListColFlowClass)            '種別
                    ptypTakeOverDataEN01Y0Tmp.strOpID = .GetData(.Row, CMlngvsfSnapShotListColOpID)                      '大工程
                    ptypTakeOverDataEN01Y0Tmp.strStepID = .GetData(.Row, CMlngvsfSnapShotListColStepID)                  '小工程
                    ptypTakeOverDataEN01Y0Tmp.strMPROrder = .GetData(.Row, CMlngvsfSnapShotListColMPROrder)              '量産ｵｰﾀﾞｰ
                    ptypTakeOverDataEN01Y0Tmp.strPartCode = .GetData(.Row, CMlngvsfSnapShotListColPartCode)              '部品ｺｰﾄﾞ
                    ptypTakeOverDataEN01Y0Tmp.strPoint = .GetData(.Row, CMlngvsfSnapShotListColPoint)                    'ﾎﾟｲﾝﾄ
                    ptypTakeOverDataEN01Y0Tmp.strSearchDate = calSearchDate.Value & CPstrSpace & cmbSearchTime.Text               '検索日時
                    ptypTakeOverDataEN01Y0Tmp.strCfFlag = .GetData(.Row, CMlngvsfSnapShotListColCFFlag)                  'CFﾌﾗｸﾞ
                    ptypTakeOverDataEN01Y0Tmp.strLpFlag = .GetData(.Row, CMlngvsfSnapShotListColLpFlag)                  'LPﾌﾗｸﾞ
                    ptypTakeOverDataEN01Y0Tmp.lngWfListCnt = mtypSnapShotAnsList.typSnapShotList(llngDataNo-1).lngWfListCnt         'WFﾘｽﾄｶｳﾝﾄ
                
                    '@過去在庫ﾘｽﾄのWFﾘｽﾄ
                    llngWFListCnt = mtypSnapShotAnsList.typSnapShotList(llngDataNo-1).lngWfListCnt
                    
                    '@配列の再定義
                    ptypTakeOverDataEN01Y0Tmp.typWfList = New List(Of SnapWfList)
                    ptypTakeOverDataEN01Y0Tmp.typRowNumList  = New List(Of MasPdMap)

                    '@WFﾘｽﾄの配列をｺﾋﾟｰ
                    ptypTakeOverDataEN01Y0Tmp.typWfList = _
                        mtypSnapShotAnsList.typSnapShotList(llngDataNo-1).typWfList
                    
                     ptypTakeOverDataEN01Y0Tmp.lngRowNumListCnt = _
                        mtypMasPdMap.lngListCnt                 'ﾁｯﾌﾟﾏｯﾌﾟ情報ｶｳﾝﾄ

                    '@ｽﾛｯﾄﾏｯﾌﾟ情報ﾘｽﾄの配列をｺﾋﾟｰ
                    ptypTakeOverDataEN01Y0Tmp.typRowNumList = _
                        mtypMasPdMap.typRowNumList
                    ptypTakeOverDataEN01Y0.Add(ptypTakeOverDataEN01Y0Tmp)
                End If
            End With
                
            '@子画面名称設定(星取表表示)
            frmxxEN01Y1.Instance.Text = CPstrSubFormEN01Y1
                
            '@星取表表示画面起動
            frmxxEN01Y1.Instance.ShowDialog(Me)
            frmxxEN01Y1.Instance = Nothing
            
            '@引継ぎ用構造体・ｶｳﾝﾀを初期化する
            ptypTakeOverDataEN01Y0 = New List(Of TakeOverDataEN01Y0)
            plngPrintLotCnt = 0

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWFMapDisp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCopy_Click
    '機　能：EXCELに貼り付ける際に、ｾﾙの先頭の文字列が、
    '　　　　「－」、「＋」の場合は、自動計算されるので、罫線文字におきかえる
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/28 (Mon) 09:26:43 N.Kojima
    '更新日：2006/08/28 (Mon) 09:26:43
    '備　考：
    Private Sub cmdCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCopy.Click

        Dim llngRowCnt     As Integer      '行ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngColCnt     As Integer      '列ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrRET        As String       'ｺﾋﾟｰ文字列
        Dim lstrWk         As String       '文字列編集
        
        Try
    
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
    
            
            '@ﾏｳｽﾎﾟｲﾝﾀ砂時計
            Cursor.Current = Cursors.WaitCursor

            
            '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞの内容を削除
            Clipboard.Clear
            
            With vsfSnapShotList
                
                '@一覧をｺﾋﾟｰする
                For llngRowCnt = 0 To .Rows.Count - 1
                    
                    For llngColCnt = 0 To .Cols.Count - 1
                        '@列が非表示ではなく、かつﾁｪｯｸﾎﾞｯｸｽ列ではない場合
                        If Not .Cols(llngColCnt).Visible = False  And _
                            llngColCnt <> CMlngvsfSnapShotListColCheck Then
                        
                            '@文字列編集変数に値をｾｯﾄ
                            lstrWk = .GetData(llngRowCnt, llngColCnt)
                            
                            '@先頭の文字列が「-」「+」の場合は罫線文字に置き換える
                            If Mid$(lstrWk, 1, 1) = CPstrMinus Then
                                Mid$(lstrWk, 1, 1) = CPstrMinusWide
                            End If
                            If Mid$(lstrWk, 1, 1) = CPstrPlus Then
                                Mid$(lstrWk, 1, 1) = CPstrPlusWide
                            End If
                            
                            '@最終列の場合Tabいらない
                            If llngColCnt = CMlngvsfSnapShotListColFlowClass Then
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
            
            '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞにﾃｷｽﾄ文字列を挿入
            Clipboard.SetText(lstrRET)
            
            '@ﾏｳｽﾎﾟｲﾝﾀﾃﾞﾌｫﾙﾄ
            Cursor.Current = Cursors.Default
            
            '@表示ﾒｯｾｰｼﾞ変換
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0041)
            
            '@"<TRM41I>$$クリップボードにコピーしました。(Ctrl＋Vキー で貼り付けてください)"
            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ﾏｳｽﾎﾟｲﾝﾀﾃﾞﾌｫﾙﾄ
            Cursor.Current = Cursors.Default
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdCopy_Click"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdCopyWF_Click
    '機　能：ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ(WF)
    '引　数：なし
    '戻り値：なし
    '作成日：2007/11/15 (Thu) 10:45:31 N.Kasai
    '更新日：2007/11/15 (Thu) 10:45:31
    '　　　：2008/02/27 (Tue) 12:50:00 S.Ochiai     ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ(WF)時に欠点数の出力を追加(案件№02847)
    '備　考：
    Private Sub cmdCopyWF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCopyWF.Click

        Dim llngRowCnt      As Integer      '行ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngColCnt      As Integer      '列ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngCnt         As Integer      'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngArryCnt     As Integer      '配列ｶｳﾝﾄ
        Dim lstrRET         As String       'ｺﾋﾟｰ文字列
        Dim lstrWk          As String       '文字列編集
        Dim lstrRETwk       As String       'ｺﾋﾟｰ文字列(編集中)

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            
            '@ﾏｳｽﾎﾟｲﾝﾀ砂時計
            Cursor.Current = Cursors.WaitCursor
            
            '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞの内容を削除
            Clipboard.Clear
            
            With vsfSnapShotList
                
                '@一覧をｺﾋﾟｰする
                For llngRowCnt = 0 To .Rows.Count - 1
                    
                    For llngColCnt = 0 To .Cols.Count - 1
                        '@列が非表示ではなく、かつﾁｪｯｸﾎﾞｯｸｽ列ではない場合
                        If  .Cols(llngColCnt).Visible = True  And _
                            llngColCnt <> CMlngvsfSnapShotListColCheck Then
                            If IsNumeric(.GetData(llngRowCnt, llngColCnt)) Then 
                                '@文字列編集変数に値をｾｯﾄ
                                 lstrWk = Format$(Double.Parse(.GetData(llngRowCnt, llngColCnt)),CPstrNoKanmaFormat)
                            Else
                                '@文字列編集変数に値をｾｯﾄ
                                lstrWk = .GetData(llngRowCnt, llngColCnt)
                            End If
                                                                                 
                            '@先頭の文字列が「-」「+」の場合は罫線文字に置き換える
                            If Mid$(lstrWk, 1, 1) = CPstrMinus Then
                                Mid$(lstrWk, 1, 1) = CPstrMinusWide
                            End If
                            If Mid$(lstrWk, 1, 1) = CPstrPlus Then
                                Mid$(lstrWk, 1, 1) = CPstrPlusWide
                            End If
                            
                            '@ｺﾋﾟｰ文字列作成
                            lstrRETwk = lstrRETwk & lstrWk & vbTab
                            
                        End If
                    Next llngColCnt
                    
                    '@初期化
                    llngArryCnt = -1
                    '@構造体検索
                    For llngCnt = 0 To mtypSnapShotAnsList.lngSnapShotListCnt-1
                        If .GetData(llngRowCnt, CMlngvsfSnapShotListColLotID) = _
                            mtypSnapShotAnsList.typSnapShotList(llngCnt).strLotID Then
                            llngArryCnt = llngCnt
                            Exit For
                        End If
                    Next
                    
                    '@配列№あり
                    If llngArryCnt <> -1 Then
                        For llngCnt = 0 To mtypSnapShotAnsList.typSnapShotList(llngArryCnt).lngWfListCnt-1
                            
                            lstrRET = lstrRET & lstrRETwk & _
                                    mtypSnapShotAnsList.typSnapShotList(llngArryCnt).typWfList(llngCnt).strWfId & vbTab & _
                                    mtypSnapShotAnsList.typSnapShotList(llngArryCnt).typWfList(llngCnt).strChipGoodQuantity & vbTab & _
                                    mtypSnapShotAnsList.typSnapShotList(llngArryCnt).typWfList(llngCnt).strChipOutQuantity & vbTab & _
                                    mtypSnapShotAnsList.typSnapShotList(llngArryCnt).typWfList(llngCnt).strChipForwardQuantity & vbCrLf
                                    'mtypSnapShotAnsList.typSnapShotList(llngArryCnt).typWfList(llngCnt).strKettenChipQuantity & vbCrLf
                        Next
                    Else
                        '@見出し行
                        lstrRET = lstrRET & lstrRETwk & "WF_ID" & vbTab & "良品" & vbTab & "不良" & vbTab & "払出" & vbCrLf
                    End If
                    
                    '@編集中文字列初期化
                    lstrRETwk = vbNullString
                    
                Next llngRowCnt                
            End With
            
            '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞにﾃｷｽﾄ文字列を挿入
            Clipboard.SetText(lstrRET)
            
            '@ﾏｳｽﾎﾟｲﾝﾀﾃﾞﾌｫﾙﾄ
            Cursor.Current = Cursors.Default
            
            '@表示ﾒｯｾｰｼﾞ変換
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0041)
            
            '@"<TRM41I>$$クリップボードにコピーしました。(Ctrl＋Vキー で貼り付けてください)"
            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ﾏｳｽﾎﾟｲﾝﾀﾃﾞﾌｫﾙﾄ
            Cursor.Current = Cursors.Default

            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdCopyWF_Click"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================

    '関数名：prvfrmxxEN01Y0_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/25 (Tue) 14:46:43 N.Kojima
    '更新日：2006/08/28 (Mon) 11:30:12 N.Kojima
    '備　考：ﾛｯﾄ一覧帳票表示ﾎﾞﾀﾝの機能は仕様未確定の為、使用不可です。
    Private Sub prvfrmxxEN01Y0_Init()

        Dim lstrFormTitle       As String           'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        Dim lstrNowDate         As String           '日付一時置換格納
        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN01Y0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@退避領域の初期化

            '@各ｺﾝﾎﾞﾎﾞｯｸｽの初期化
            cmbSearchTime.Clear                         '検索時間
            cmbPartCode.Clear                              'ﾎﾟｲﾝﾄ
            cmbFlowClass.Clear                          '種別
            cmbPd.Clear                                 '機種
            cmbCurrentPosition.Clear                    'ｷｬﾘｱ位置
            cmbOp.Clear                                 '大工程
            cmbStep.Clear                               '小工程
            
            '@各ｺﾝﾎﾞﾎﾞｯｸｽの無効化
            cmbSearchTime.Enabled = False               '検索時間
            cmbPartCode.Enabled = False                    'ﾎﾟｲﾝﾄ
            cmbFlowClass.Enabled = False                '種別
            cmbPd.Enabled = False                       '機種
            cmbCurrentPosition.Enabled = False          'ｷｬﾘｱ位置
            cmbOp.Enabled = False                       '大工程
            cmbStep.Enabled = False                     '小工程
            
            '@ﾁｪｯｸﾎﾞｯｸｽの初期化
            chkCarrierPosition.Checked = 0                'ｷｬﾘｱ位置指定ﾁｪｯｸﾎﾞｯｸｽ
            chkProcess.Checked = 0                        '工程指定ﾁｪｯｸﾎﾞｯｸｽ

            lstrNowDate = Format(Now, CPstrDateTimeYMD)           
            Call pubblnCalendar_Init(calSearchDate, CPlngCalModeTool, lstrNowDate)
            
            '@各ﾗﾍﾞﾙの初期化
            lblNowDate.Text = vbNullString           '情報取得日時
            lblSnapShotCntSend.Text = vbNullString   '該当件数
            
            '@非表示設定(06/08/09現在)
            cmdLotPrintDisp.Visible = False
            
            '@各ﾎﾞﾀﾝの初期化(非活性化)
            cmdSearch.Enabled = False                   '検索
            cmdPrint.Enabled = False                    '星取表印刷
            cmdAllCancel.Enabled = False                '全取消
            cmdWFMapDisp.Enabled = False                '星取表表示
            cmdCopy.Enabled = False                     'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
            cmdCopyWF.Enabled = False                   'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ(WF)

        '    cmdLotPrintDisp.Enabled = False             'ﾛｯﾄ一覧帳票表示
            
            '@ｶﾚﾝﾀﾞｰ設定
            With calSearchDate
                .CalendarHeight = CPlngMClHeight                                                                                 '高さ
                .CalendarWidth = CPlngMClWidth                                                                                   '幅
                .Font = New Font(.Font.FontFamily, CPlngMClFontSize, .Font.Style, .Font.Unit)                                    'ﾌｫﾝﾄｻｲｽﾞ
                .TitleFont = New Font(.TitleFont.FontFamily, CPlngMClTlFontSize, .TitleFont.Style, .TitleFont.Unit)              'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CPlngMClGridFontSize, .GridFont.Style, .GridFont.Unit)                'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .Enabled = True                                                                                                  '有効
                .Value = CPstrNullDate                                                                                           'ﾃｷｽﾄ(____/__/__)
            End With
            
            '@ﾓｼﾞｭｰﾙ変数の初期化
            mstrSearchDate = vbNullString                           '検索年月日退避用
            mstrSearchTime = vbNullString                           '検索日時退避用
            mstrOpID = vbNullString                                 '大工程
            mstrStepID = vbNullString                               '小工程
            mblnPrintChkFlag = False                                '印刷判定ﾌﾗｸﾞ
            mstrCurrentPosition = vbNullString                      'ｷｬﾘｱ位置
            mblnFormLoadFlag = False                                'ﾌｫ ｰﾑﾛｰﾄﾞﾌﾗｸﾞ

           '@構造体・配列・ｶｳﾝﾀの初期化
            If mtypPdList Is Nothing Then                          '機種格納用配列
               mtypPdList = New List(Of ProductList)  
            Else
                mtypPdList.Clear()
            End If
            mlngPdListCnt = 0                                       '機種格納数
            
            If mtypFlowClassList Is Nothing Then                    '種別格納用配列
               mtypFlowClassList = New List(Of DivisionList)
            Else
                mtypFlowClassList.Clear()
            End If
            mlngFlowClassListCnt = 0                                '種別格納数
            
            If mtypCurrnetPositionList Is Nothing Then              'ｷｬﾘｱ位置格納用配列
               mtypCurrnetPositionList = New List(Of CurrentPositionList)
            Else
                mtypCurrnetPositionList.Clear()
            End If
            mlngCurrentPositionListCnt = 0    
            
           If mtypPointList Is Nothing Then                         'ﾎﾟｲﾝﾄ格納用配列
                mtypPointList = New List(Of PointList) 
            Else 
                mtypPointList.Clear()
            End If                               
            mlngPointListCnt = 0                                    'ﾎﾟｲﾝﾄ格納数
            
           If mtypMasOpList.typMasOpId Is Nothing then              '大工程格納用構造体
               mtypMasOpList.typMasOpId = New List(Of MasOpId)
             Else
                mtypMasOpList.typMasOpId.Clear()
            End If
            mlngOpListCnt = 0                                       '大工程格納数
            
            If  mtypMasStepList.typMasStepId Is Nothing Then        '小工程格納用構造体
                mtypMasStepList.typMasStepId= New List(Of MasStepId)
            Else
                mtypMasStepList.typMasStepId.Clear()
            End If
            mlngStepListCnt = 0       
            
            mtypSnapShotReqList.typPointList = new List(Of PointList)   '過去在庫一覧要求格納用構造体(ﾎﾟｲﾝﾄ配列)
            If mtypSnapShotReqList.typFlowClassList Is Nothing Then     '過去在庫一覧要求格納用構造体(種別配列)
                 mtypSnapShotReqList.typFlowClassList= New List(Of FlowClassList)            
             Else
                mtypSnapShotReqList.typFlowClassList.Clear()
             End If
            mtypSnapShotReqList.typPdList = New List(Of PDList)     '過去在庫一覧要求格納用構造体(機種配列)
            mtypSnapShotReqList.lngPointCnt = 0                     '過去在庫一覧要求格納用構造体(ﾎﾟｲﾝﾄｶｳﾝﾄ)
            mtypSnapShotReqList.lngFlowClassCnt = 0                 '過去在庫一覧要求格納用構造体(種別ｶｳﾝﾄ)
            mtypSnapShotReqList.lngPdCnt = 0                        '過去在庫一覧要求格納用構造体(機種ｶｳﾝﾄ)
            
            If mtypSnapShotAnsList.typSnapShotList Is Nothing Then   '過去在庫一覧応答格納用構造体
                mtypSnapShotAnsList.typSnapShotList = New List(Of SnapShotAns)
            Else
                mtypSnapShotAnsList.typSnapShotList.Clear()
            End If

            '@印刷要求判定ﾌﾗｸﾞ(子画面引継ぎ用)を初期化
            pblnReqPrint = False
            
            '@引継ぎ構造体の初期化
            If ptypTakeOverDataEN01Y0 Is Nothing Then               '星取表表示画面への引継ぎ用配列
                ptypTakeOverDataEN01Y0 = New List(Of TakeOverDataEN01Y0)
             Else
                ptypTakeOverDataEN01Y0.Clear()
             End If
            plngPrintLotCnt = 0                                     '印刷ﾛｯﾄ数ｶｳﾝﾀ

            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01Y0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSnapShotList_Init
    '機　能：過去在庫一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/25 (Tue) 15:35:23 N.Kojima
    '更新日：2014/01/16 (Thu) 11:38:49 T.Oide
    '備　考：
    Private Sub prvvsfSnapShotList_Init()
        
        Dim llngCnt     As Integer      '汎用ｶｳﾝﾀ

        Try
            
            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfSnapShotList
               '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ            
                
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                .AllowSorting = AllowSortingEnum.SingleColumn
                        
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                                              
                '@行単位選択
                .SelectionMode = SelectionModeEnum.Row
                
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号（...）を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter 
                
                '@ﾊｲﾗｲﾄ設定
                .HighLight = HighlighteNUM.Always
                
                '@一覧表の表題設定                           
                .Styles.Fixed.ForeColor = color.Yellow                                                                '文字色
                .Styles.Fixed.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))                  '背景色
                .Styles.Fixed.Font = New Font(.Font.Name, CMlngvsfHFontSize, .Font.Style)                             'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngvsfSnapShotListColNo, CMstrvsfSnapShotListTColNo)                           'No.
                .SetData(CMlngVsfRowTitle, CMlngvsfSnapShotListColPoint, CMstrvsfSnapShotListTColPoint)                     'ﾎﾟｲﾝﾄ
                .SetData(CMlngVsfRowTitle, CMlngvsfSnapShotListColPD, CMstrvsfSnapShotListTColPD)                           '機種
                .SetData(CMlngVsfRowTitle, CMlngvsfSnapShotListColLotID, CMstrvsfSnapShotListTColLotID)                     'ﾛｯﾄID
                .SetData(CMlngVsfRowTitle, CMlngvsfSnapShotListColCarrierID, CMstrvsfSnapShotListTColCarrierID)             'ｷｬﾘｱID
                .SetData(CMlngVsfRowTitle, CMlngvsfSnapShotListColPartCode, CMstrvsfSnapShotListTColPartCode)               '部品ｺｰﾄﾞ
                .SetData(CMlngVsfRowTitle, CMlngvsfSnapShotListColWFNum, CMstrvsfSnapShotListTColWFNum)                     'WF枚数
                .SetData(CMlngVsfRowTitle, CMlngvsfSnapShotListColChipQuantity, CMstrvsfSnapShotListTColChipQuantity)       '良品Chip
                .SetData(CMlngVsfRowTitle, CMlngvsfSnapShotListColChipOutQty, CMstrvsfSnapShotListTColChipOutQty)           '不良Chip
                .SetData(CMlngVsfRowTitle, CMlngvsfSnapShotListColChipForwardQty, CMstrvsfSnapShotListTColChipForwardQty)   '払出Chip
                .SetData(CMlngVsfRowTitle, CMlngvsfSnapShotListColCfPartCode, CMstrvsfSnapShotListTColCfPartCode)           '部品コード(対向)
                .SetData(CMlngVsfRowTitle, CMlngvsfSnapShotListColCfWfNum, CMstrvsfSnapShotListTColCfWfNum)                 'WF数(対向)
                .SetData(CMlngVsfRowTitle, CMlngvsfSnapShotListColGnsWFNum, CMstrvsfSnapShotListTColGnsWFNum)               'Gns報告WF枚数
                .SetData(CMlngVsfRowTitle, CMlngvsfSnapShotListColGnsChipQuantity, CMstrvsfSnapShotListTColGnsChipQuantity) 'Gns報告ﾁｯﾌﾟ数
                .SetData(CMlngVsfRowTitle, CMlngvsfSnapShotListColCurrentPosition, CMstrvsfSnapShotListTColCurrentPosition) 'ｷｬﾘｱ位置
                .SetData(CMlngVsfRowTitle, CMlngvsfSnapShotListColOpID, CMstrvsfSnapShotListTColOpID)                       '大工程
                .SetData(CMlngVsfRowTitle, CMlngvsfSnapShotListColStepID, CMstrvsfSnapShotListTColStepID)                   '小工程
                .SetData(CMlngVsfRowTitle, CMlngvsfSnapShotListColMPROrder, CMstrvsfSnapShotListTColMPROrder)               '量産ｵｰﾀﾞｰ
                .SetData(CMlngVsfRowTitle, CMlngvsfSnapShotListColPROrder, CMstrvsfSnapShotListTColPROrder)                 'PRｵｰﾀﾞｰ
                .SetData(CMlngVsfRowTitle, CMlngvsfSnapShotListColCFFlag, CMstrvsfSnapShotListTColCFFlag)                   'CFﾌﾗｸﾞ
                .SetData(CMlngVsfRowTitle, CMlngvsfSnapShotListColLpFlag, CMstrvsfSnapShotListTColLpFlag)                   '大判ﾌﾗｸﾞ
                .SetData(CMlngVsfRowTitle, CMlngvsfSnapShotListColFlowClass, CMstrvsfSnapShotListTColFlowClass)             '種別

                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    '自動調整する
                    .AutoSizeCols(CMlngvsfSnapShotListColNo, .Cols.Count - 1, 6)
                End If
                
                '@表示位置の設定
                .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height  = CMlngVsfHHeight      '高さ
                
                '@非表示設定
                For llngCnt = 0 To .Cols.Count - 1
                    '@非表示設定初期化
                    .Cols(llngCnt).Visible = true
                Next llngCnt
                
                '@非表示設定
                .Cols(CMlngvsfSnapShotListColPoint).Visible = False                 'ﾎﾟｲﾝﾄ
                .Cols(CMlngvsfSnapShotListColMPROrder).Visible = False              '量産ｵｰﾀ
                .Cols(CMlngvsfSnapShotListColCFFlag).Visible = False                'CFﾌﾗｸﾞ
                .Cols(CMlngvsfSnapShotListColLpFlag).Visible = False                '大判フラグ
                '.Cols(CMlngvsfSnapShotListColGnsWFNum).Visible = False              'GNS_WF
                '.Cols(CMlngvsfSnapShotListColGnsChipQuantity).Visible = False       'GNS_CHIP

                '基板工程
                If pstrSBID = CPstrSBID1A0 Then
                    .Cols(CMlngvsfSnapShotListColChipOutQty).Visible = False        '不良Chip
                    .Cols(CMlngvsfSnapShotListColChipForwardQty).Visible = False    '払出Chip
                    .Cols(CMlngvsfSnapShotListColCfPartCode).Visible = False        '部品コード(対向)
                    .Cols(CMlngvsfSnapShotListColCfWfNum).Visible = False           'WF数(対向)
                ElseIf pstrSBID = CPstrSBID3A0 Then
                    .Cols(CMlngvsfSnapShotListColCfPartCode).Visible = False        '部品コード(対向)
                    .Cols(CMlngvsfSnapShotListColCfWfNum).Visible = False           'WF数(対向)
                End If

                '@ﾛｯｸ
                .Enabled = False
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light
                .ShowCell(.Rows.Count -1, CMlngvsfColTitle)
            End With
            
            '@該当件数のｸﾘｱ
            lblSnapShotCntSend.Text = CPstrZero
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSnapShotList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSnapShotList_Disp
    '機　能：過去在庫一覧の作成
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/27 (Thu) 11:16:28 N.Kojima
    '更新日：2012/06/27 (Wed) 11:42:25 T.Oide
    '備　考：
    Private Sub prvvsfSnapShotList_Disp()

        Dim llngDoCnt       As Integer      'ｶｳﾝﾄ
        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ
        Dim lstrPoint1      As String       'ﾎﾟｲﾝﾄ文字列退避用1
        Dim lstrPoint2      As String       'ﾎﾟｲﾝﾄ文字列退避用2
        Dim lstrEditPoint   As String       '編集後ﾎﾟｲﾝﾄ格納用

        Try
            
            With vsfSnapShotList
                
                '@格納ﾃﾞｰﾀがあるの場合
                If mtypSnapShotAnsList.lngSnapShotListCnt <> 0 Then
                
                    '@描画ﾛｯｸ
                    .Redraw = false
                    
                    '@行数設定
                    RemoveHandler  vsfSnapShotList.EnterCell, AddressOf  vsfSnapShotList_EnterCell
                    .Rows.Count = mtypSnapShotAnsList.lngSnapShotListCnt + 1
                    AddHandler  vsfSnapShotList.EnterCell, AddressOf vsfSnapShotList_EnterCell                    
                    
                    '@行数設定
                    .Rows.Count = mtypSnapShotAnsList.lngSnapShotListCnt + 1
                    
                    '@ｶｳﾝﾀの初期化
                    llngDoCnt = 1
                    
                    '@過去在庫一覧表示情報設定
                    For llngCnt = 0 To mtypSnapShotAnsList.lngSnapShotListCnt-1
                        
                        .SetData(llngCnt+1, CMlngvsfSnapShotListColNo, llngCnt+1)                 '№
                    
                        .SetCellCheck(llngCnt+1, CMlngvsfSnapShotListColCheck, CheckEnum.Unchecked)     'ﾁｪｯｸﾎﾞｯｸｽ
                            
                        '@ﾎﾟｲﾝﾄがNULLじゃない場合は、ﾌｫｰﾏｯﾄして表示
                        If mtypSnapShotAnsList.typSnapShotList(llngCnt).strPoint <> vbNullString Then
                        
        '@↓2012/06/27 (Wed) 11:42:25 T.Oide **************************************************
        '@
        '@                    '@編集用に文字列を退避
        '@                    lstrPoint1 = Mid$(mtypSnapShotAnsList.typSnapShotList(llngCnt).strPoint, 1, 5)
        '@                    lstrPoint2 = Right$(mtypSnapShotAnsList.typSnapShotList(llngCnt).strPoint, 2)
        '@                    lstrEditPoint = lstrPoint1 & CPstrReplaceMinus & lstrPoint2 & CPstrZero
        '@
        '@                    .Cell(flexcpText, llngCnt, CMlngvsfSnapShotListColPoint) = lstrEditPoint    'ﾎﾟｲﾝﾄ(ﾌｫｰﾏｯﾄ)
        '@----------------------------------------------------------------------------------------
                            
                            '@ポイントは「不明」か
                            If mtypSnapShotAnsList.typSnapShotList(llngCnt).strPoint = CMstrFumeiPoint Then
                        
                                '@不明を表示
                                .SetData(llngCnt+1, CMlngvsfSnapShotListColPoint, CMstrFumeiPoint)
                            Else
                            
                                '@通常のポイントを表示
                            lstrPoint1 = Mid$(mtypSnapShotAnsList.typSnapShotList(llngCnt).strPoint, 1, 5)
                            lstrPoint2 = strings.Right$(mtypSnapShotAnsList.typSnapShotList(llngCnt).strPoint, 2)
                            lstrEditPoint = lstrPoint1 & CPstrReplaceMinus & lstrPoint2 & CPstrZero
                            
                            .SetData(llngCnt+1, CMlngvsfSnapShotListColPoint, lstrEditPoint)    'ﾎﾟｲﾝﾄ(ﾌｫｰﾏｯﾄ)
                                
                            End If
        '@↑2012/06/27 (Wed) 11:42:25 T.Oide **************************************************
                        
                        Else
                            .SetData(llngCnt+1, CMlngvsfSnapShotListColPoint, _
                                mtypSnapShotAnsList.typSnapShotList(llngCnt).strPoint)                   'ﾎﾟｲﾝﾄ(NULL)
                        End If
                            
                        .SetData(llngCnt+1, CMlngvsfSnapShotListColPD, _
                            mtypSnapShotAnsList.typSnapShotList(llngCnt).strPdId)                        '機種
                        
                        .SetData(llngCnt+1, CMlngvsfSnapShotListColLotID, _
                            mtypSnapShotAnsList.typSnapShotList(llngCnt).strLotID)                       'ﾛｯﾄID
                        
                        .SetData(llngCnt+1, CMlngvsfSnapShotListColCarrierID, _
                            mtypSnapShotAnsList.typSnapShotList(llngCnt).strCarrierId)                   'ｷｬﾘｱID
                            
                        .SetData(llngCnt+1, CMlngvsfSnapShotListColPartCode, _
                            mtypSnapShotAnsList.typSnapShotList(llngCnt).strPartCode)                    '部品ｺｰﾄﾞ
                            
                        .SetData(llngCnt+1, CMlngvsfSnapShotListColWFNum, _
                            mtypSnapShotAnsList.typSnapShotList(llngCnt).strWfNum)                       'WF枚数
                         
                        If IsNumeric(mtypSnapShotAnsList.typSnapShotList(llngCnt).strChipQuantity) Then
                          .SetData(llngCnt+1, CMlngvsfSnapShotListColChipQuantity, _
                            Format$(CInt(mtypSnapShotAnsList.typSnapShotList(llngCnt).strChipQuantity),CPstrDateFormatKanma)) '良品Chip
                        End If

                        If IsNumeric(mtypSnapShotAnsList.typSnapShotList(llngCnt).strChipOutQuantity) Then
                            If CInt(mtypSnapShotAnsList.typSnapShotList(llngCnt).strChipOutQuantity) > 0 Then
                                .SetData(llngCnt+1, CMlngvsfSnapShotListColChipOutQty, _
                                    Format$(CInt(mtypSnapShotAnsList.typSnapShotList(llngCnt).strChipOutQuantity),CPstrDateFormatKanma)) 'SB内不良Chip
                            End If
                        End If

                        If IsNumeric(mtypSnapShotAnsList.typSnapShotList(llngCnt).strChipForwardQuantity) Then
                            If CInt(mtypSnapShotAnsList.typSnapShotList(llngCnt).strChipForwardQuantity) > 0 Then
                                .SetData(llngCnt+1, CMlngvsfSnapShotListColChipForwardQty, _
                                    Format$(CInt(mtypSnapShotAnsList.typSnapShotList(llngCnt).strChipForwardQuantity),CPstrDateFormatKanma)) 'SB内払出Chip
                            End If
                        End If

                        .SetData(llngCnt+1, CMlngvsfSnapShotListColCfPartCode, _
                            mtypSnapShotAnsList.typSnapShotList(llngCnt).strCfPartCode)                 '部品コード(対向)

                        .SetData(llngCnt+1, CMlngvsfSnapShotListColCfWFNum, _
                            mtypSnapShotAnsList.typSnapShotList(llngCnt).strCfWfNum)                    'WF枚数(対向)

                        .SetData(llngCnt+1, CMlngvsfSnapShotListColGnsWFNum, _
                            mtypSnapShotAnsList.typSnapShotList(llngCnt).strGnsWFNum)                    'Gns報告WF枚数

                        If IsNumeric(mtypSnapShotAnsList.typSnapShotList(llngCnt).strGnsChipQuantity)   
                            .SetData(llngCnt+1, CMlngvsfSnapShotListColGnsChipQuantity, _
                                Format$(Integer.Parse(mtypSnapShotAnsList.typSnapShotList(llngCnt).strGnsChipQuantity),CPstrDateFormatKanma))'Gns報告ﾁｯﾌﾟ数
                        End If

                        .SetData(llngCnt+1, CMlngvsfSnapShotListColCurrentPosition, _
                            mtypSnapShotAnsList.typSnapShotList(llngCnt).strCurrentPositionName)         'ｷｬﾘｱ位置
                            
                        .SetData(llngCnt+1, CMlngvsfSnapShotListColOpID, _
                            mtypSnapShotAnsList.typSnapShotList(llngCnt).strOpID)                        '大工程
                            
                        .SetData(llngCnt+1, CMlngvsfSnapShotListColStepID, _
                            mtypSnapShotAnsList.typSnapShotList(llngCnt).strStepID)                      '小工程
                            
                        .SetData(llngCnt+1, CMlngvsfSnapShotListColMPROrder, _
                            mtypSnapShotAnsList.typSnapShotList(llngCnt).strMPROrder)                    '量産ｵｰﾀﾞｰ№
                        
                        .SetData(llngCnt+1, CMlngvsfSnapShotListColPROrder, _
                            mtypSnapShotAnsList.typSnapShotList(llngCnt).strPROrder)                     'PRｵｰﾀﾞｰ
                            
                        .SetData(llngCnt+1, CMlngvsfSnapShotListColCFFlag, _
                            mtypSnapShotAnsList.typSnapShotList(llngCnt).strCfFlag)                      'CFﾌﾗｸﾞ

                        .SetData(llngCnt+1, CMlngvsfSnapShotListColLpFlag, _
                            mtypSnapShotAnsList.typSnapShotList(llngCnt).strLpFlag)                      '大判ﾌﾗｸﾞ
                            
                        .SetData(llngCnt+1, CMlngvsfSnapShotListColFlowClass, _
                            mtypSnapShotAnsList.typSnapShotList(llngCnt).strFlowClass)                   '種別

                        '組立工程の場合
                        '対向ロットの情報は対向側へ移動
                        If pstrSBID = CPstrSBID2A0 And mtypSnapShotAnsList.typSnapShotList(llngCnt).strCfFlag = CPstrFlagOn Then
                            
                            '部品コード(対向)
                            .SetData(llngCnt+1, CMlngvsfSnapShotListColCfPartCode, .GetData(llngCnt+1, CMlngvsfSnapShotListColPartCode))
                            'WF枚数(対向)
                            .SetData(llngCnt+1, CMlngvsfSnapShotListColCfWFNum, .GetData(llngCnt+1, CMlngvsfSnapShotListColWFNum))              

                            .SetData(llngCnt+1, CMlngvsfSnapShotListColPartCode, vbNullString)          '部品ｺｰﾄﾞ
                            .SetData(llngCnt+1, CMlngvsfSnapShotListColWFNum, vbNullString)             'WF枚数
                        End If

                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngCnt+1).Height = CMlngvsfHeight
                    Next llngCnt
                    
                    '@ﾕｰｻﾞによる列幅変更されていない場合
                    If mtypChgSort.blnChgWidth = False Then
                        '自動調整する
                        .AutoSizeCols(CMlngvsfSnapShotListColNo, .Cols.Count - 1, 6)
                    End If
                    
                    '@書式設定
                    .Cols(CMlngvsfSnapShotListColNo).TextAlign = TextAlignEnum.RightCenter                      '№（右寄せ中央揃え）
                    .Cols(CMlngvsfSnapShotListColCheck).TextAlign = TextAlignEnum.CenterCenter                  'ﾁｪｯｸﾎﾞｯｸｽ(中央寄せ中央揃え)
                    .Cols(CMlngvsfSnapShotListColPoint).TextAlign = TextAlignEnum.LeftCenter                    'ﾎﾟｲﾝﾄ(左寄せ中央揃え)
                    .Cols(CMlngvsfSnapShotListColPD).TextAlign = TextAlignEnum.LeftCenter                       '機種(左寄せ中央揃え)
                    .Cols(CMlngvsfSnapShotListColLotID).TextAlign = TextAlignEnum.LeftCenter                    'ﾛｯﾄID(左寄せ中央揃え)
                    .Cols(CMlngvsfSnapShotListColCarrierID).TextAlign = TextAlignEnum.LeftCenter                'ｷｬﾘｱID(左寄せ中央揃え)
                    .Cols(CMlngvsfSnapShotListColPartCode).TextAlign = TextAlignEnum.LeftCenter                 '部品ｺｰﾄﾞ(左寄せ中央揃え)
                    .Cols(CMlngvsfSnapShotListColWFNum).TextAlign = TextAlignEnum.RightCenter                   'WF枚数(右寄せ中央揃え)
                    .Cols(CMlngvsfSnapShotListColChipQuantity).TextAlign = TextAlignEnum.RightCenter            'ﾁｯﾌﾟ数(右寄せ中央揃え)
                    .Cols(CMlngvsfSnapShotListColChipOutQty).TextAlign = TextAlignEnum.RightCenter              '不良Chip
                    .Cols(CMlngvsfSnapShotListColChipForwardQty).TextAlign = TextAlignEnum.RightCenter          '払出Chip
                    .Cols(CMlngvsfSnapShotListColGnsWFNum).TextAlign = TextAlignEnum.RightCenter                'Gns報告WF枚数(右寄せ中央揃え)
                    .Cols(CMlngvsfSnapShotListColGnsChipQuantity).TextAlign = TextAlignEnum.RightCenter         'Gns報告ﾁｯﾌﾟ数(右寄せ中央揃え)
                    .Cols(CMlngvsfSnapShotListColCurrentPosition).TextAlign = TextAlignEnum.LeftCenter          'ｷｬﾘｱ位置(左寄せ中央揃え)
                    .Cols(CMlngvsfSnapShotListColOpID).TextAlign = TextAlignEnum.LeftCenter                     '大工程(左寄せ中央揃え)
                    .Cols(CMlngvsfSnapShotListColStepID).TextAlign = TextAlignEnum.LeftCenter                   '小工程(左寄せ中央揃え)
                    .Cols(CMlngvsfSnapShotListColMPROrder).TextAlign = TextAlignEnum.LeftCenter                 '量産ｵｰﾀﾞｰ№(左寄せ中央揃え)
                    .Cols(CMlngvsfSnapShotListColPROrder).TextAlign = TextAlignEnum.LeftCenter                  'PRｵｰﾀﾞｰ(左寄せ中央揃え)
                    .Cols(CMlngvsfSnapShotListColCFFlag).TextAlign = TextAlignEnum.LeftCenter                   'CFﾌﾗｸﾞ(左寄せ中央揃え)
                    .Cols(CMlngvsfSnapShotListColLpFlag).TextAlign = TextAlignEnum.LeftCenter                   '大判ﾌﾗｸﾞ(左寄せ中央揃え)
                    .Cols(CMlngvsfSnapShotListColFlowClass).TextAlign = TextAlignEnum.LeftCenter                '種別(左寄せ中央揃え)

                   '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort.lngCnt -1
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSort.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort.typChgSortList(llngCnt).lngOrder
                            .Sort(SortFlags.UseColSort,mtypChgSort.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If
                    
                    '@ｿｰﾄ検索用ｷｰ（小工程）がある場合
                    If mtypChgSort.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@WF枚数が同じ場合
                            If .GetData(llngCnt, CMlngvsfSnapShotListColWFNum).ToString = mtypChgSort.strKey Then
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列）
                                Call pubVsfBeforeSort(vsfSnapShotList, CMlngvsfRowTitle)
                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定（ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁）
                                Call pubVsfAfterSort(vsfSnapShotList, CMlngvsfRowTitle)
                                Exit For
                            End If
                        Next llngCnt
                    End If
                    
                    '@非表示
                    .Row = 0   
                    .TopRow = 0
                    
                    'NSYS カレントセルも先頭へ移動
                    .Col = 0
                    
                    '@再描画
                    .Redraw =True
                    
                    '@ﾛｯｸ解除
                    .Enabled = True       
                    
                    '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝ使用可
                    cmdCopy.Enabled = True
                    cmdCopyWF.Enabled = True

                    
                    '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                    If .Enabled = True Then
                        Call pubSetFocus(vsfSnapShotList)
                    End If
                End If
            End With

            '@該当件数ﾗﾍﾞﾙに取得件数を表示
            lblSnapShotCntSend.Text = Format$(mtypSnapShotAnsList.lngSnapShotListCnt, CPstrDateFormatKanma)

            '@現在日時表示
            lblNowDate.Text = Format$(Now, CPstrDateFormat)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSnapShotList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbSearchTime_Init
    '機　能：検索時間ｺﾝﾎﾞの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/27 (Thu) 10:26:43 N.Kojima
    '更新日：2014/01/17 (Fri) 12:12:26 T.Oide
    '備　考：
    Private Sub prvcmbSearchTime_Init()

        Try

            '@ｺﾝﾎﾞの設定
            With cmbSearchTime
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear
                .Enabled = True                                                 '活性化
                .BackColor = System.Drawing.SystemColors.Window 
        '@↓2014/01/17 (Fri) 12:12:05 T.Oide **************************************************
        '@        .DirectInput = False                                            '直接入力(False)
                .DirectInput = True                                             '直接入力(True)
        '@↑2014/01/17 (Fri) 12:12:05 T.Oide **************************************************
                .SelectMode = 0                                                 '選択ﾓｰﾄﾞ(単数選択ﾓｰﾄﾞ=0)
                .AllSelectButton = False                                        '全選択ﾎﾞﾀﾝ表示
                .DispCols = 1                                                   'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = 1                                                  '表示列
                .ValueCol = 1                                                   '値取得列
                .Font = New Font(.Font.FontFamily,CType(CMlngCmbFontSize, Single), .Font.Style)                                         'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CType(CMlngCmbGridFontSize, Single), .GridFont.Style)                        'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbSearchTime_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbSearchTime_Disp
    '機　能：検索時間ｺﾝﾎﾞ作成
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/27 (Thu) 10:26:43 N.Kojima
    '更新日：2007/02/02 (Fri) 11:40:45 N.Kasai
    '備　考：
    '　　　：2007/02/02 (Fri) 11:40:45 N.Kasai  検索条件追加(№01756)
    Private Sub prvcmbSearchTime_Disp()

        Dim llngCnt             As Integer          '汎用ｶｳﾝﾀ

        Try
            
            '@ｺﾝﾎﾞの設定
            With cmbSearchTime
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                .AddItem(CMstrInitTime & vbTab & llngCnt)            '時間(月末の在庫は月の切り替わりの00:00:00)/Index
                .AddItem(CMstrMorningTime & vbTab & llngCnt + 1)     '時間(朝 06:45)/Index
                .AddItem(CMstrEveningTime & vbTab & llngCnt + 2)     '時間(夕 11:45)/Index
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbSearchTime_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbPd_Init
    '機　能：機種ｺﾝﾎﾞの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/27 (Thu) 10:21:06 N.Kojima
    '更新日：2006/07/27 (Thu) 10:21:06
    '備　考：
    Private Sub prvcmbPd_Init()

        Try
            
            '@ｺﾝﾎﾞの設定
            With cmbPd
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear
                .Enabled = True
                .DirectInput = False                                        '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                            '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                     '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = CMlngCmbGroupCols                              '列方向のﾚｺｰﾄﾞ数
                .GroupRows = mlngPdListCnt                                  '行方向のﾚｺｰﾄﾞ数
                .AddedComment = CMstrCmbSelect                              '"選択"文字列
                .Font = New Font(.Font.FontFamily,CType(CMlngCmbFontSize, Single), .Font.Style)                                     'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CType(CMlngCmbGridFontSize, Single), .GridFont.Style)                   
                .RowHeight = CMlngCmbRowHeight                              'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter  '左寄中央揃え
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbPd_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbPd_Disp
    '機　能：機種ｺﾝﾎﾞ作成
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/27 (Thu) 10:21:06 N.Kojima
    '更新日：2006/07/27 (Thu) 10:21:06
    '備　考：
    Private Sub prvcmbPd_Disp()

        Dim llngCnt                     As Integer          'ﾙｰﾌﾟｶｳﾝﾄ

        Try
            
            '@ｺﾝﾎﾞの設定
            With cmbPD
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                For llngCnt = 0 To mlngPdListCnt - 1
                    '小片の対向基板
                    If mtypPdList(llngCnt).strLpFlag = CPstrFlagOff And mtypPdList(llngCnt).strCfFlag = CPstrFlagOn Then
                        '何もしない
                    Else
                        .AddItem(mtypPdList(llngCnt).strProductID & vbTab & _
                                    llngCnt & vbTab & _
                                    vbNullString & vbTab & _
                                    vbNullString & vbTab & _
                                    CMstrCmbCheckOn)             'ID/Index
                    End If
                Next llngCnt
                
                .AddedComment = CMstrCmbSelect          '"XX 項目選択"
                .Text = .ListCount & CMstrCmbSelect     'XX部に項目数を格納
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbPd_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbFlowClass_Init
    '機　能：種別ｺﾝﾎﾞの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/27 (Thu) 10:26:43 N.Kojima
    '更新日：2006/07/27 (Thu) 10:26:43
    '備　考：
    Private Sub prvcmbFlowClass_Init()

        Try

            '@ｺﾝﾎﾞの設定
            With cmbFlowClass
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear
                .Enabled = True                                                 '活性化
                .DirectInput = False                                            '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = 1                                                  '列方向のﾚｺｰﾄﾞ数
                .GroupRows = mlngFlowClassListCnt                               '行方向のﾚｺｰﾄﾞ数
                .AddedComment = CMstrCmbSelect                                  '"選択"文字列
                .Font = New Font(.Font.FontFamily,CType(CMlngCmbFontSize, Single), .Font.Style)                                        'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CType(CMlngCmbGridFontSize, Single), .GridFont.Style)                       'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbFlowClass_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbFlowClass_Disp
    '機　能：種別ｺﾝﾎﾞ作成
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/27 (Thu) 10:26:43 N.Kojima
    '更新日：2006/07/27 (Thu) 10:26:43
    '備　考：
    Private Sub prvcmbFlowClass_Disp()

        Dim llngCnt             As Integer          'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            '@ｺﾝﾎﾞの設定
            With cmbFlowClass
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                For llngCnt = 0 To mlngFlowClassListCnt -1
                    '@「PR」か(初回表示は「PR」のみとする為)
                    If mtypFlowClassList(llngCnt).strDivisionID = CPstrFlowClassPR Then
                        .AddItem(mtypFlowClassList(llngCnt).strDivisionID & vbTab & _
                                    llngCnt & vbTab & _
                                    vbNullString & vbTab & _
                                    vbNullString & vbTab & _
                                    CMstrCmbCheckOn)             'ID/Index/NULL/NULL/ﾁｪｯｸON
                    Else
                        .AddItem(mtypFlowClassList(llngCnt).strDivisionID & vbTab & _
                                    llngCnt & vbTab & _
                                    vbNullString & vbTab & _
                                    vbNullString & vbTab & _
                                    CMstrCmbCheckOff)            'ID/Index/NULL/NULL/ﾁｪｯｸOFF
                    End If
                Next llngCnt
                
                .AddedComment = CMstrCmbSelect          '"XX 項目選択"
                .Text = CPstrOne & CMstrCmbSelect     'XX部に項目数を格納
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbFlowClass_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbCurrentPosition_Init
    '機　能：ｷｬﾘｱ位置ｺﾝﾎﾞの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/28 (Mon) 11:03:20 N.Kojima
    '更新日：2006/08/28 (Mon) 11:03:20
    '備　考：
    Private Sub prvcmbCurrentPosition_Init()

        Try

            '@ｺﾝﾎﾞの初期化
            With cmbCurrentPosition
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear
                .Enabled = False                                                '非活性化
                .DirectInput = False                                            '直接入力(False)
                .SelectMode = 0                                                 '選択ﾓｰﾄﾞ(単数選択ﾓｰﾄﾞ=0)
                .AllSelectButton = False                                        '全選択ﾎﾞﾀﾝ表示
                .DispCols = 1                                                   'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = 1                                                  '表示列
                .ValueCol = 1                                                   '値取得列
                .Font = New Font(.Font.FontFamily,CType(CMlngCmbFontSize, Single), .Font.Style)                                       'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CType(CMlngCmbGridFontSize, Single), .GridFont.Style)                      'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbCurrentPosition_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbCurrentPosition_Disp
    '機　能：ｷｬﾘｱ位置ｺﾝﾎﾞ作成
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/28 (Mon) 11:07:26 N.Kojima
    '更新日：2006/08/28 (Mon) 11:07:26
    '備　考：
    Private Sub prvcmbCurrentPosition_Disp()

        Dim llngCnt             As Integer              'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            '@ｺﾝﾎﾞの設定
            With cmbCurrentPosition
                
                '@和名に"装置"を、ID"WP"を格納
                .AddItem(CMstrWpName & vbTab & CMstrWPID & vbTab & CPstrOne)
            
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                For llngCnt = 0 To mlngCurrentPositionListCnt - 1 

                    .AddItem(mtypCurrnetPositionList(llngCnt).strCurrentPositionName & vbTab & _
                             mtypCurrnetPositionList(llngCnt).strCurrentPositionid & vbTab & _
                             llngCnt + 1)                    '和名/ID/Index
                
                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbCurrentPosition_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbPartCode_Init
    '機　能：ﾎﾟｲﾝﾄｺﾝﾎﾞの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/27 (Thu) 10:26:43 N.Kojima
    '更新日：2006/07/27 (Thu) 10:26:43
    '備　考：
    Private Sub prvcmbPartCode_Init()

        Try

            '@ｺﾝﾎﾞの初期化
            With cmbPartCode
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear
                .Enabled = True                                                 '活性化
                .DirectInput = False                                            '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngcmbPartCodeDispCols                            'ｸﾞﾘｯﾄﾞ表示列数(ｺｰﾄﾞと名称表示)
                .GroupCols = 1                                                  '列方向のﾚｺｰﾄﾞ数
                .GroupRows = mlngPointListCnt                                   '行方向のﾚｺｰﾄﾞ数
                .ValueCol = 0                                                   '値取得列(部品ｺｰﾄﾞ)
                .AddedComment = CMstrCmbSelect                                  '"選択"文字列
                .Font = New Font(.Font.FontFamily,CType(CMlngCmbFontSize, Single), .Font.Style)                                       'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CType(CMlngCmbGridFontSize, Single), .GridFont.Style)                      'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbPartCode_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbPartCode_Disp
    '機　能：ﾎﾟｲﾝﾄｺﾝﾎﾞ作成
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/27 (Thu) 10:26:43 N.Kojima
    '更新日：2014/01/16 (Thu) 18:16:53 T.Oide
    '備　考：
    '　　　：2006/10/05 (Thu) 17:50:07 N.Kojima     ﾎﾟｲﾝﾄの表示はﾃﾞﾌｫﾙﾄ「0 項目選択」とする。(案件№01517)
    '　　　：2014/01/16 (Thu) 18:16:53 T.Oide       GNS対応
    Private Sub prvcmbPartCode_Disp()

        Dim llngCnt             As Integer              'ﾙｰﾌﾟｶｳﾝﾄ
    '@↓2014/01/16 (Thu) 18:23:03 T.Oide **************************************************
    '@    Dim lstrPoint1          As String               'ﾎﾟｲﾝﾄ文字列退避用1
    '@    Dim lstrPoint2          As String               'ﾎﾟｲﾝﾄ文字列退避用2
    '@    Dim lstrEditPoint       As String               '編集後ﾎﾟｲﾝﾄ格納用
        Dim llngCnt1            As Integer              'PDｶｳﾝﾄ
        Dim llngCnt2            As Integer              'ｺﾝﾎﾞのﾘｽﾄ数
        Dim lstrPartName        As String               '部品の名称表示
    '@↑2014/01/16 (Thu) 18:23:03 T.Oide **************************************************

        Try

            '@ｺﾝﾎﾞの設定
            With cmbPartCode
        '@↓2014/01/16 (Thu) 18:19:08 T.Oide **************************************************
        '@        '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
        '@        For llngCnt = 1 To mlngPointListCnt
        '@
        '@            '@編集用に文字列を退避
        '@            lstrPoint1 = Mid$(mtypPointList(llngCnt).strPoint, 1, 5)
        '@            lstrPoint2 = Right$(mtypPointList(llngCnt).strPoint, 2)
        '@            lstrEditPoint = lstrPoint1 & CPstrReplaceMinus & lstrPoint2 & CPstrZero
        '@            .AddItem lstrEditPoint & vbTab & _
        '@                        mtypPointList(llngCnt).strPoint & vbTab & _
        '@                        llngCnt & vbTab & _
        '@                        vbNullString & vbTab & _
        '@                        CMstrCmbCheckOff            'ﾌｫｰﾏｯﾄ後ﾎﾟｲﾝﾄ/本来のﾎﾟｲﾝﾄ/Index/NULL/ﾁｪｯｸOFF
        '@        Next llngCnt
        '@
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                llngCnt1 = 0
                llngCnt2 = 1
                '@PDﾘｽﾄのﾙｰﾌﾟ
                For llngCnt = 0 To mtypeReportPoint.lngPdListCnt-1
                    
                    '@1機種の報告ﾏｽﾀｰﾚｺｰﾄﾞ数のﾙｰﾌﾟ
                    For llngCnt1 = 0 To mtypeReportPoint.typePdList(llngCnt).lngPdReportPointCnt-1
                    
                        '@送品用の部品ｺｰﾄﾞ以外か
                        If mtypeReportPoint.typePdList(llngCnt).typeReportPointList(llngCnt1).strPrtsType <> CMstrPartTypeSouhin Then
                            
                            '@和名を設定
                            Select Case mtypeReportPoint.typePdList(llngCnt).typeReportPointList(llngCnt1).strPrtsType
                                
                                '@部材の場合
                                Case CMstrPartTypeBuzai
                                    lstrPartName = CMstrPartTypeBuzaiName
                                
                                '@流動中の場合
                                Case CMstrPartTypeRyuDou
                                    lstrPartName = CMstrPartTypeRyuDouName & _
                                                   CPstrParenthesisLeft & _
                                                   mtypeReportPoint.typePdList(llngCnt).typeReportPointList(llngCnt1).strOpID & _
                                                   CPstrMinusWide & _
                                                   mtypeReportPoint.typePdList(llngCnt).typeReportPointList(llngCnt1).strStepID & _
                                                   CPstrParenthesisRight
                                    
                                '@完成の場合
                                Case CMstrPartTypeKansei
                                    lstrPartName = CMstrPartTypeKanseiName
                                
                            End Select
                            
                            '@コンボに追加(部品ｺｰﾄﾞ/部品名/Index/NULL/ﾁｪｯｸOFF)
                            .AddItem(mtypeReportPoint.typePdList(llngCnt).typeReportPointList(llngCnt1).strPartCode & vbTab & _
                                     lstrPartName & vbTab & _
                                     mtypeReportPoint.typePdList(llngCnt).strPdId & vbTab & _
                                     llngCnt2 & vbTab & _
                                     CMstrCmbCheckOff)
                                     
                            llngCnt2 = llngCnt2 + 1         'ｺﾝﾎﾞのﾘｽﾄ数
                            
                        End If
                        
                    Next llngCnt1
                    
                Next llngCnt
        '@↑2014/01/16 (Thu) 18:19:08 T.Oide **************************************************
                
                '@ﾘｽﾄ件数が0件の場合
                .AddedComment = CMstrCmbSelect              '"XX 項目選択"

                .Text = CMlngCmbCheck0 & CMstrCmbSelect     'XX部に項目数を格納
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbPartCode_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbOp_Init
    '機　能：大工程ｺﾝﾎﾞの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/27 (Thu) 10:26:43 N.Kojima
    '更新日：2006/07/27 (Thu) 10:26:43
    '備　考：
    Private Sub prvcmbOp_Init()

        Try

            '@ｺﾝﾎﾞの設定
            With cmbOp
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear
                .Enabled = False                                                '非活性化
                .BackColor = System.Drawing.SystemColors.Window 
                .DirectInput = False                                            '直接入力(False)
                .SelectMode = 0                                                 '選択ﾓｰﾄﾞ(単数選択ﾓｰﾄﾞ=0)
                .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                .DispCols = 1                                                   'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = 1                                                  '列方向のﾚｺｰﾄﾞ数
                .ValueCol = 1                                                   '値取得列
                .Font = New Font(.Font.FontFamily,CType(CMlngCmbFontSize, Single), .Font.Style)                                         'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CType(CMlngCmbGridFontSize, Single), .GridFont.Style)                        'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
            End With

            Exit Sub


        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbOp_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbOp_Disp
    '機　能：大工程ｺﾝﾎﾞ作成
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/27 (Thu) 10:26:43 N.Kojima
    '更新日：2006/07/27 (Thu) 10:26:43
    '備　考：
    Private Sub prvcmbOp_Disp()

        Dim llngCnt             As Integer          'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            '@ｺﾝﾎﾞの設定
            With cmbOp
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                For llngCnt = 0 To mtypMasOpList.lngMasOpCnt-1
                    .AddItem(mtypMasOpList.typMasOpId(llngCnt).strOpID & _
                             vbTab & _
                             llngCnt)                                            'ID/Index
                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbOp_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbStep_Init
    '機　能：小工程ｺﾝﾎﾞの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/27 (Thu) 10:26:43 N.Kojima
    '更新日：2006/07/27 (Thu) 10:26:43
    '備　考：
    Private Sub prvcmbStep_Init()

        Try

           '@ｺﾝﾎﾞの設定
            With cmbStep
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化  
                .Clear
                .Enabled = False                                                '非活性化
                .DirectInput = False                                            '直接入力(False)
                .SelectMode = 0                                                 '選択ﾓｰﾄﾞ(単数選択ﾓｰﾄﾞ=0)
                .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                .DispCols = 1                                                   'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = 1                                                  '列方向のﾚｺｰﾄﾞ数
                .ValueCol = 1                                                   '値取得列
                .Font = New Font(.Font.FontFamily,CType(CMlngCmbFontSize, Single), .Font.Style)                                                  'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CType(CMlngCmbGridFontSize, Single), .GridFont.Style)                                'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbStep_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbStep_Disp
    '機　能：小工程ｺﾝﾎﾞ作成
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/27 (Thu) 10:26:43 N.Kojima
    '更新日：2006/07/27 (Thu) 10:26:43
    '備　考：
    Private Sub prvcmbStep_Disp()

        Dim llngCnt             As Integer          'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            '@ｺﾝﾎﾞの設定
            With cmbStep
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                For llngCnt = 0 To mtypMasStepList.lngMasStepCnt-1
                    .AddItem(mtypMasStepList.typMasStepId(llngCnt).strStepID & _
                             vbTab & _
                             llngCnt)                                            'ID/Index
                Next llngCnt
                
                '@1件しかない場合は直表示
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
                .strProcName = "prvcmbStep_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnSearchCondition_Chk
    '機　能：検索ﾎﾞﾀﾝ制御用ﾁｪｯｸ処理
    '引　数：lstrEventName  ：呼び出し元ｲﾍﾞﾝﾄ名
    '戻り値：True:検索条件All-OK、False:検索条件不足
    '作成日：2006/07/27 (Thu) 14:36:08 N.Kojima
    '更新日：2006/07/27 (Thu) 14:36:08
    '備　考：
    Private Function prvblnSearchCondition_Chk(ByVal lstrEventName As String) As Boolean

        Try
            
            '@戻り値にFalseを設定
            prvblnSearchCondition_Chk = False
            
            '@検索日時(年月日)の判定
            Select Case calSearchDate.Value
                Case CPstrNullDate
                    '@検索日時(年月日)がNULLの場合
                    
                    '@検索ﾎﾞﾀﾝ押下の場合
                    If lstrEventName = CMstrCmdSearchClick Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003D)
                        '@"<TRM3DW>$$日付が設定されていません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    End If
                    
                    Exit Function
                
                Case Not calSearchDate.IsDate
                    '@日付として妥当でない場合
                    
                    '@検索ﾎﾞﾀﾝ押下の場合
                    If lstrEventName = CMstrCmdSearchClick Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                        '@"<TRM08W>$$正しい日付を入力してください。$1900年～2100年以外の日付は入力できません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    End If
                    
                    Exit Function
                    
                Case vbNullString
                    '@空白の場合
                    
                    '@検索ﾎﾞﾀﾝ押下の場合
                    If lstrEventName = CMstrCmdSearchClick Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003D)
                        '@"<TRM3DW>$$日付が設定されていません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    End If
                    
                    Exit Function
                    
                Case Not pubblnYearRange_Chk(calSearchDate.Value)
                    '@日付の有効範囲外の場合
                    
                    '@検索ﾎﾞﾀﾝ押下の場合
                    If lstrEventName = CMstrCmdSearchClick Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                        '@"<TRM08W>$$正しい日付を入力してください。$1900年～2100年以外の日付は入力できません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    End If
                    
                    Exit Function
            End Select
            
            '@検索日時(時間)の判定
            Select Case cmbSearchTime.Text
                        
                Case vbNullString
                    '@空白の場合
                    
                    '@検索ﾎﾞﾀﾝ押下の場合
                    If lstrEventName = CMstrCmdSearchClick Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0093)
                        '@"<TRM93W>$$検索時間が選択されていません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    End If
                    
                    Exit Function
            End Select
            
            '@機種の判定
            Select Case cmbPd.Text
                Case vbNullString
                    '@機種が未選択の場合
                    
                    '@検索ﾎﾞﾀﾝ押下の場合
                    If lstrEventName = CMstrCmdSearchClick Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0013)
                        '@"<TRM13W>$$機種が設定されていません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    End If
                    
                    Exit Function
                    
                Case CMstrCmbNotSelect
                    '@0項目選択の場合
                    
                    '@検索ﾎﾞﾀﾝ押下の場合
                    If lstrEventName = CMstrCmdSearchClick Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0013)
                        '@"<TRM13W>$$機種が設定されていません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    End If
                    
                    Exit Function
            End Select
            
            '@種別の判定
            Select Case cmbFlowClass.Text
                Case vbNullString
                    '@種別が未選択の場合
                    
                    '@検索ﾎﾞﾀﾝ押下の場合
                    If lstrEventName = CMstrCmdSearchClick Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0014)
                        '@"<TRM14W>$$種別が設定されていません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    End If
                    
                    Exit Function
                    
                Case CMstrCmbNotSelect
                    '@0項目選択の場合
                    
                    '@検索ﾎﾞﾀﾝ押下の場合
                    If lstrEventName = CMstrCmdSearchClick Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0014)
                        '@"<TRM14W>$$種別が設定されていません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    End If
                    
                    Exit Function
            End Select
            
            '@当関数の戻り値にTrueを設定
            prvblnSearchCondition_Chk = True
                
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnSearchCondition_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvInitialize_proc
    '機　能：各種ｺﾝﾎﾞ変更時の初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/03 (Thu) 16:32:04 N.Kojima
    '更新日：2006/08/03 (Thu) 16:32:04
    '備　考：ﾛｯﾄ一覧帳票表示ﾎﾞﾀﾝの機能は仕様未確定の為、使用不可です。
    Private Sub prvInitialize_proc()

        Try
            
            '@過去在庫一覧のｸﾘｱ
            Call prvvsfSnapShotList_Init()
            
            '@各ﾎﾞﾀﾝの初期化(非活性化)
            cmdPrint.Enabled = False                    '星取表印刷
            cmdWFMapDisp.Enabled = False                '星取表表示
            cmdAllCancel.Enabled = False                '全取消
            cmdCopy.Enabled = False                     'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
            cmdCopyWF.Enabled = False                   'ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ

        '    cmdLotPrintDisp.Enabled = False             'ﾛｯﾄ一覧帳票表示
            
            '@ｶﾚﾝﾄ行検索ｷｰ、ﾘｻｲｽﾞを初期化
            mtypChgSort.strKey = vbNullString
            mtypChgSort.blnChgWidth = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvInitialize_proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    Private Function prvblnPdMapInfo_proc() As Boolean

        Dim llngCnt             As Integer          'ｶｳﾝﾀ
        Dim llngCnt2            As Integer          'ｶｳﾝﾀ
        Dim llngPdCnt           As Integer          '機種件数
        Dim lstrPdID            As String           '機種
        Dim lblnPdFlg           As Boolean          '機種ﾌﾗｸﾞ
        Dim lblnAns             As Boolean          '汎用戻り値
        Dim ltypMasPdMap        As MasPdMapList     'ｽﾛｯﾄﾏｯﾌﾟ構造体

        Try
            
            '@戻り値初期化
            prvblnPdMapInfo_proc = False
            
            '@星取表印刷画面からの起動の場合
            If pblnReqPrint = True Then
            
                '@変数初期化
                llngPdCnt = 0
                
                '@構造体の初期化
                mtypSnapPDMap.strSnapPDCnt = 0
                If mtypSnapPDMap.typSnapPDList Is Nothing 
                    mtypSnapPDMap.typSnapPDList = New List(Of SnapPDList) 
                Else 
                    mtypSnapPDMap.typSnapPDList.Clear()
                End If

                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(Me.Name, CMstrprvblnPdMapInfo_proc)
                
                With vsfSnapShotList
                
                    For llngCnt = 1 To .Rows.Count - 1
                        '@ﾁｪｯｸあり
                        If .GetCellCheck(llngCnt, CMlngvsfSnapShotListColCheck) = CheckEnum.Checked Then
                            
                            '@機種取得
                            lstrPdID = .GetData(llngCnt, CMlngvsfSnapShotListColPD)
                            '@変数初期化
                            lblnPdFlg = False
                            
                            If llngPdCnt > 0 Then
                                For llngCnt2 = 0 To llngPdCnt-1
                                    If mtypSnapPDMap.typSnapPDList(llngCnt2).strPdId = lstrPdID Then
                                        '@既に取得済み
                                        lblnPdFlg = True
                                        Exit For
                                    End If
                                Next
                            End If
                            
                            '@新規機種情報
                            If lblnPdFlg = False Then
                                '@ｽﾛｯﾄﾏｯﾌﾟ情報の取得
                                lblnAns = pubblnMasMapInfo_Sel(CMstrmas_mapinfo_Ver, lstrPdID, pstrSBID, ltypMasPdMap)
                                If lblnAns = True Then
                                    With mtypSnapPDMap
                                        llngPdCnt = llngPdCnt + 1
                                        .strSnapPDCnt = llngPdCnt
                                        '@配列再定義
                                        Dim typSnapPDListtmp As SnapPDList  = New SnapPDList 
                                        typSnapPDListtmp.strPdId = lstrPdID
                                        typSnapPDListtmp.lngRowNumListCnt = ltypMasPdMap.lngListCnt
                                        typSnapPDListtmp.typRowNumList = ltypMasPdMap.typRowNumList
                                        mtypSnapPDMap.typSnapPDList.Add(typSnapPDListtmp)
                                    End With
                                Else
                                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                    Call pubResponseCancel(Me.Name, CMstrprvblnPdMapInfo_proc)
            
                                    '@ｴﾗｰ
                                    Exit Function
                                End If
                            End If
                        End If
                    Next
                
                End With
            Else
            
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(Me.Name, CMstrprvblnPdMapInfo_proc)
                With vsfSnapShotList
                    If .Row < 1 Then
                        Exit Function
                    End If
                
                    '@機種取得
                    lstrPdID = .GetData(.Row, CMlngvsfSnapShotListColPD)
                    '@ｽﾛｯﾄﾏｯﾌﾟ情報の取得
                    lblnAns = pubblnMasMapInfo_Sel(CMstrmas_mapinfo_Ver, lstrPdID, pstrSBID, mtypMasPdMap)
                    If lblnAns = False Then
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, CMstrprvblnPdMapInfo_proc)
                        '@ｴﾗｰ
                        Exit Function
                    End If
                    
                End With
            
            End If
            
            '@戻り値設定
            prvblnPdMapInfo_proc = True
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, CMstrprvblnPdMapInfo_proc)
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnPdMapInfo_proc"
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
        Dim lblnSysCommandScClose   As Boolean = False  'NSYS コントロールメニュー SC_CLOSE処理時 True

   

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

        End Select

        MyBase.WndProc(m)

        If lblnSysCommandScClose = True Then
            'NSYS SC_CLOSE 処理後 WM_CLOSE が発生しないでキャンセルされることもあるため、フラグを戻す
            'NSYS WM_CLOSE が発生していれば、すでにこの時点では画面は閉じている
            mblnCloseFromControlMenu = False
        End If
    End Sub


    '関数名 list_BeforeDoubleClick
    '機　能：グリッドダブルクリック前処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/01/14 (Mon) 17:00:00 NSYS
    '備　考：
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfSnapShotList.BeforeDoubleClick

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
