'ﾌｧｲﾙ名：xxEN0270.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：アクション予約　メインフォーム
'作成日：2004/05/27 (Thu) 11:46:57 N.Kasai
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：
'　　　：
'Copyright(C) SEIKO EPSON CORPORATION 2004-2018, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN0270
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN0270    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN0270
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN0270
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN0270)
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
    'Private Const CMstrLocalVersion                 As String = "15.01"
    Private Const CMstrLocalVersion                 As String = "15.03"


    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_wplist__Ver              As String = "05.01"                 '装置一覧取得
    Private Const CMstrmas_useoplist_Ver            As String = "02.00"                 '大工程ﾏｽﾀ取得
    Private Const CMstrmas_emplist_Ver              As String = "02.00"                 '作業者ﾘｽﾄ取得
    Private Const CMstrmas_reasoncodeVer            As String = "02.00"                 '理由ｺｰﾄﾞ取得
    Private Const CMstrmas_reworktravelerVer        As String = "03.00"                 'ﾘﾜｰｸ工程取得
    Private Const CMstrmas_pdlist__Ver              As String = "03.00"                 '機種区分一覧取得
    Private Const CMstrmas_pdentrylistVer           As String = "03.00"                 'ﾏｽﾀ工順一覧取得
    Private Const CMstrmas_pdtravelerVer            As String = "04.00"                 '機種別ｽﾃｯﾌﾟ取得
    '@↓2012/11/07 (Wed) 15:03:14 T.Oide **************************************************
    'Private Const CMstrmas_stepusedwplistVer        As String = "02.00"                 '装置使用工程取得
    Private Const CMstrmas_stepusedwplistVer        As String = "03.00"                 '装置使用工程取得
    '@↑2012/11/07 (Wed) 15:03:14 T.Oide **************************************************
    Private Const CMstrlot_travelerVer              As String = "03.02"                 'ﾛｯﾄｽﾃｯﾌﾟ取得
    Private Const CMstrlot_steplistVer              As String = "03.00"                 '小工程取得
    Private Const CMstrlot_alttravelerVer           As String = "03.01"                 '代替工程取得
    '@↓2012/11/07 (Wed) 14:58:37 T.Oide **************************************************
    'Private Const CMstrlot_actinfo_Ver              As String = "03.00"                 'ｱｸｼｮﾝ予約検索
    Private Const CMstrlot_actinfo_Ver              As String = "04.01"                 'ｱｸｼｮﾝ予約検索
    '@↑2012/11/07 (Wed) 14:58:37 T.Oide **************************************************
    '@↓2012/11/07 (Wed) 15:00:43 T.Oide **************************************************
    'Private Const CMstrlot_actrsv__Ver              As String = "05.00"                 'ｱｸｼｮﾝ予約設定
    Private Const CMstrlot_actrsv__Ver              As String = "06.01"                 'ｱｸｼｮﾝ予約設定
    '@↑2012/11/07 (Wed) 15:00:43 T.Oide **************************************************
    Private Const CMstrlot_delact__Ver              As String = "02.01"                 'ｱｸｼｮﾝ予約削除

    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN0270          'ﾛｰｶﾙﾒﾆｭｰKey

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMstrCmbFontName                  As String = "ＭＳ ゴシック"         'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄ名
    Private Const CMlngCmbFontSize                  As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColName               As Integer = 0                      '名称列番
    Private Const CMlngCmbGridColID                 As Integer = 1                      'ID列番(非表示項目：PD_ID)
    Private Const CMlngCmbGridColID2                As Integer = 2                      'ID列番2(非表示項目：USE_ID)
    Private Const CMlngCmbSortAsc                   As Integer = 1                      '昇順(ｿｰﾄ)
    Private Const CMlngCmbDispCols                  As Integer = 1                      'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbRowHeight                 As Integer = 18                     'ﾘｽﾄ行の高さ
    Private Const CMlngCmbClearListIndex            As Integer = -1                     'ﾃｷｽﾄ値初期化
    Private Const CMlngCMbSelectMode                As Integer = 1                      '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
    Private Const CMlngCmbFirstListIndex            As Integer = 0                      'ｺﾝﾎﾞLISTの表示位置
    Private Const CMlngCmbGetCol5                   As Integer = 5                      'ﾊﾞｯｸｶﾗｰ格納Col


    '@ﾃｷｽﾄ文字制限表示
    Private Const CMlngLotCommentsDefault           As Integer = 0                      'ﾛｯﾄｺﾒﾝﾄの初期値(=0)

    '@ｺﾝﾎﾞ取得Col
    Private Const CMlngGetValueCol                  As Integer = 1                      '取得Col数

    '@vsfUseInfoの定数宣言(ColWidth)
    Private Const CMlngGridColWidthNo               As Integer = 37                     'No
    Private Const CMlngGridColWidthAltNumber        As Integer = 37                     '代替番号
    Private Const CMlngGridColWidthOpID             As Integer = 183                    '大工程ID
    Private Const CMlngGridColWidthStepID           As Integer = 183                    '小工程ID
    Private Const CMlngGridColWidthActStepInfo      As Integer = 106                    '予約状況
    Private Const CMlngGridColWidthAltStep          As Integer = 33                     '代替工程有無
    Private Const CMlngGridColWidthReworkStep       As Integer = 33                     'ﾘﾜｰｸ工程有無
    Private Const CMlngGridColWidthSpecialStep      As Integer = 33                     '特殊工程有無

    '@vsfUseInfoの定数宣言(ｶﾗﾑ)
    Private Const CMlngLotPrestateColNo             As Integer = 0                      'No
    Private Const CMlngLotPrestateColAltNumber      As Integer = 1                      '代替番号
    Private Const CMlngLotPrestateColOpID           As Integer = 2                      '大工程ID
    Private Const CMlngLotPrestateColStepID         As Integer = 3                      '小工程ID
    Private Const CMlngLotPrestateColActStepInfo    As Integer = 4                      '予約状況
    Private Const CMlngLotPrestateColAltStep        As Integer = 5                      '代替工程有無
    Private Const CMlngLotPrestateColReworkStep     As Integer = 6                      'ﾘﾜｰｸ工程有無
    Private Const CMlngLotPrestateColSpecialStep    As Integer = 7                      '特殊工程有無
    Private Const CMlngLotPrestateColStepNum        As Integer = 8                      'ｽﾃｯﾌﾟ番号
    Private Const CMlngLotPrestateColReworkRouteID  As Integer = 9                      'ﾘﾜｰｸ時ﾙｰﾄID
    Private Const CMlngLotPrestateColSPRouteID      As Integer = 10                     '特殊ﾙｰﾄID
    Private Const CMlngLotPrestateColActFlg         As Integer = 11                     'ｱｸｼｮﾝ予約取得ﾌﾗｸﾞ

    '@vsfUseInfoの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrLotPrestateColTNo            As String = "№"                    '№
    Private Const CMstrLotPrestateColTAltNumber     As String = "代"                    '代
    Private Const CMstrLotPrestateColTOpID          As String = "大工程"                '大工程ID
    Private Const CMstrLotPrestateColTStepID        As String = "小工程"                '小工程ID
    Private Const CMstrLotPrestateColTActStepInfo   As String = "予約状況"              '予約状況
    Private Const CMstrLotPrestateColTAltStep       As String = "代替"                  '代替工程有無
    Private Const CMstrLotPrestateColTReworkStep    As String = "リ"                    'ﾘﾜｰｸ工程有無
    Private Const CMstrLotPrestateColTSpecialStep   As String = "特"                    '特殊工程有無

    '@ｸﾞﾘｯﾄﾞの初期値定数宣言
    Private Const CMstrGridFontName                 As String = "ＭＳ ゴシック"         'ｸﾞﾘｯﾄﾞのﾌｫﾝﾄ名
    Private Const CMlngGridFontSize                 As Integer = 11                     'ｸﾞﾘｯﾄﾞのﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngGridFixedCols                As Integer = 0                      'ｸﾞﾘｯﾄﾞのFixedCol
    Private Const CMlngGridFixedRows                As Integer = 1                      'ｸﾞﾘｯﾄﾞのFixedRow
    Private Const CMlngGridTitleHeight              As Integer = 20                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngGridRowHeight                As Integer = 18                     '1明細の高さ
    Private Const CMlngGridPageRows                 As Integer = 10                     '1ﾍﾟｰｼﾞのｾﾙの行数
    Private Const CMlngGrid3DBlank                  As Integer = 2                      'ｸﾞﾘｯﾄﾞの3D表示の余白
    Private Const CMlngGridRowTitle                 As Integer = 0                      'ﾀｲﾄﾙ行(行)
    Private Const CMlngGridScrollBarWidth           As Integer = 16                     '縦ｽｸﾛｰﾙﾊﾞｰの幅
    Private Const CMstrMaru                         As String = "○"                    '代替,ﾘﾜｰｸ工程あり
    Private Const CMstrTsuika                       As String = "追"                    '追加流動工程あり
    Private Const CMstrSaki                         As String = "先"                    '先行流動工程あり

    '@ｸﾞﾘｯﾄﾞの幅
    Private Const CMlngGridWidth                    As Integer = 633

    '@ｸﾞﾘｯﾄﾞの高さ
    Private Const CMlngGridHeight                   As Integer = (CMlngGridTitleHeight _
                                                    * CMlngGridFixedRows) _
                                                    + (CMlngGridRowHeight _
                                                    * CMlngGridPageRows) _
                                                    + CMlngGrid3DBlank
    '@ｱｸｼｮﾝ予約ﾀｲﾌﾟ
    Private Const CMlngActionLot                    As Integer = 0                      'ﾛｯﾄ
    Private Const CMlngActionProduct                As Integer = 1                      '機種
    Private Const CMlngActionWP                     As Integer = 2                      '装置
    Private Const CMlngActionProcess                As Integer = 3                      '工程

    '@ｱｸｼｮﾝ予約ﾀｲﾌﾟ(ｵﾌﾟｼｮﾝﾎﾞﾀﾝｲﾝﾃﾞｯｸｽ)
    Private Const CMlngActionIndexLot               As Integer = 0                      'ﾛｯﾄ
    Private Const CMlngActionIndexProduct           As Integer = 1                      '機種
    Private Const CMlngActionIndexWP                As Integer = 2                      '装置
    Private Const CMlngActionIndexProcess           As Integer = 3                      '工程

    '@ｱｸｼｮﾝﾄﾘｶﾞｰ
    Private Const CMlngTriggerStart                 As Integer = 0                      '作業開始
    Private Const CMlngTriggerEnd                   As Integer = 1                      '作業終了
    Private Const CMlngTriggerAll                   As Integer = 2                      '全ﾀｲﾐﾝｸﾞ

    '@ﾛｯﾄ停止/保留
    Private Const CMlngLotNotSpecify                As Integer = 0                      'ﾛｯﾄ停止/保留しない
    Private Const CMlngLotStop                      As Integer = 1                      'ﾛｯﾄ停止
    Private Const CMlngLotHold                      As Integer = 2                      'ﾛｯﾄ保留

    '@ｱｸｼｮﾝﾌﾗｸﾞ
    Private Const CMstrActionFlg0                   As String = "0"                     'なし
    Private Const CMstrActionFlg1                   As String = "1"                     '開始
    Private Const CMstrActionFlg2                   As String = "2"                     '終了
    Private Const CMstrActionFlg3                   As String = "3"                     '全ﾀｲﾐﾝｸﾞ

    '@代替,ﾘﾜｰｸ工程有無ﾌﾗｸﾞ用
    Private Const CMstrStepFlg0                     As String = "0"                     'なし
    Private Const CMstrStepFlg1                     As String = "1"                     'あり(追加)
    Private Const CMstrStepFlg2                     As String = "2"                     'あり(先行)

    '@工程ﾌﾗｸﾞ用
    Private Const CMlngStepFlg0                     As Integer = 0                      'ﾃﾞﾌｫﾙﾄ工程
    Private Const CMlngStepFlg1                     As Integer = 1                      '代替工程
    Private Const CMlngStepFlg2                     As Integer = 2                      'ﾘﾜｰｸ工程

    '@工程ﾗﾍﾞﾙ表示用
    Private Const CMstrDefultStep                   As String = "デフォルト工程"
    Private Const CMstrAltStep                      As String = "代替工程"
    Private Const CMstrReworkStep                   As String = "リワーク工程"
    Private Const CMstrAddkStep                     As String = "追加流動工程"
    Private Const CMstrForwardStep                  As String = "先行流動工程"

    '@その他
    Private Const CMstrItemNameSeparator            As String = ";"                     'ITEM_NAME区切り文字
    Private Const CMlngtxtWorkDirect                As Integer = 13                     '作業指示書№Max桁数
    Private Const CMlngLotIDByte                    As Integer = 10                     'ﾛｯﾄIDﾊﾞｲﾄ数
    Private Const CMstrActionFlgUnAcquire           As String = "未取得"                '予約状況未取得
    Private Const CPlngHoldCommentsMaxByte          As Integer = 2032                   '保留ｺﾒﾝﾄ最大桁数(頭に必ず「アクション予約　」が付くので-16ﾊﾞｲﾄ)
    Private Const CMlngGetActFlg                    As Integer = 1                      'ｱｸｼｮﾝ予約状況取得済み
    Private Const CMstrM                            As String = "M"                     '1ヶ月後計算用
    Private Const CMstrStepNum1                     As String = "1"                     '初工程
    Private Const CMstrOneWeek                      As String = "7"                     '1週間指定用定数
    Private Const CMlngMaxDispRow                   As Integer = 3                      'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数
    Private Const CMstrHoldTrem2                    As String = "2"                     '保留期限設定：2日
    Private Const CMstrHoldTrem7                    As String = "7"                     '保留期限設定：7日
    Private Const CMlngHoldTremMax30                As Integer = 30                     '保留期限最大設定値
    Private Const CMlngHoldComments900              As Integer = 900                    '保留ｺﾒﾝﾄ
    Private Const CMstrWFSiteiOp                    As String = "==========ウェハー指定"'ｳｪﾊｰ指定ｱｸｼｮﾝ予約表示
    Private Const CMstrWFSiteiStep                  As String = "アクション予約========"'ｳｪﾊｰ指定ｱｸｼｮﾝ予約表示
    '@↓2014/06/12 (Thu) 18:11:46 Y.Yoneyama **************************************************
    Private Const CMstrForeverDate                  As String = "2100/01/01"            'ｱｸｼｮﾝ予約無期限日
    '@↑2014/06/12 (Thu) 18:11:46 Y.Yoneyama **************************************************

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '@退避情報
    Private mintActionType                          As Short                            'ｱｸｼｮﾝ予約ﾀｲﾌﾟ退避(indexに使用する為integer型)
    Private mlngTechManListCnt                      As Integer                          '技術担当者ｺﾝﾎﾞ件数退避
    Private mstrLotActionID                         As String                           'ﾛｯﾄｱｸｼｮﾝ予約ID退避
    Private mstrHoldTermDate                        As String                           '保留期限退避

    '@最新取得
    Private mblnNewDataFlag                         As Boolean                          '最新取得ﾎﾞﾀﾝ押下ﾌﾗｸﾞ

    '@ﾒｯｾｰｼﾞﾌｫｰﾑへ送るﾒｯｾｰｼﾞ文字列
    Private mstrInfoMsg                             As String                           'ﾒｯｾｰｼﾞﾌｫｰﾑへ送るﾒｯｾｰｼﾞ文字列

    Private mtypMasItemList                         As MasItemList                      '保留理由構造体
    Private mtypTechManList                         As List(Of TechManList)             '技術担当者ﾘｽﾄ格納用
    Private mtypDivisionList                        As List(Of DivisionList)            '種別一覧格納用
    Private mtypProductList                         As List(Of ProductList)             '機種一覧格納用

    Private mtypStepTypeGrid                        As List(Of StepTypeGrid)            '工程選択ｸﾞﾘｯﾄﾞ退避
    Private mstrEntryID                             As String                           '最新ｴﾝﾄﾘID
    Private mstrEditTime                            As String                           '最終更新日時
    Private mlngStepFlg                             As Integer                          '工程ﾌﾗｸﾞ(0:ﾃﾞﾌｫﾙﾄ工程,1：代替工程,2：ﾘﾜｰｸ工程)
    Private mstrTechManID                           As String                           '技術担当者ID
    Private mstrTechManName                         As String                           '技術担当者名
    Private mblnFastStepNg                          As Boolean                          '初工程編集不可ﾌﾗｸﾞ(True：編集不可,False：編集可)
    Private mstrReworkRouteID                       As String                           'ﾘﾜｰｸﾙｰﾄID退避
    Private mstrSPRouteId                           As String                           '特殊ﾙｰﾄID退避
    Private mstrOpID                                As String                           'ﾃﾞﾌｫﾙﾄ大工程退避
    Private mstrStepNum                             As String                           'ｽﾃｯﾌﾟ番号退避
    Private mlblKakuteiFlag                         As Boolean                          '確定/削除ﾎﾞﾀﾝ押下判定ﾌﾗｸﾞ(True：ﾎﾞﾀﾝ押下,False：ﾎﾞﾀﾝ押下以外)
    Private mblnLotID_Change                        As Boolean                          'ﾛｯﾄID(True：変更あり,False：変更なし)
    Private mblnProduct_Change                      As Boolean                          '機種ｺﾝﾎﾞ(True：変更あり,False：変更なし)
    Private mblnWpID_Change                         As Boolean                          '装置名ｺﾝﾎﾞ(True：変更あり,False：変更なし)
    Private mblnProcessinfo_Change                  As Boolean                          '特殊工程ｺﾝﾎﾞ(True：変更あり,False：変更なし)
    Private mstrDefaultHoldPeriod                   As String                           'ﾃﾞﾌｫﾙﾄ保留期限
    Private buttonProcessing                        As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                          'NSYS WindowCloseフラグ
    Private mstrOptYoyakuClickedName                As String                           'NSYS クリックしたアクション予約タイプラジオボタン名

    '****************************************************************************************
    '　　　　　　　　　　　　　　 　　       * 型の記述 *
    '****************************************************************************************
    '========================================Private=========================================
    '@工程選択一覧退避構造体
    Private Structure StepTypeList
        Dim strSeqNum                                   As String                           '№
        Dim strOpID                                     As String                           '大工程
        Dim strStepID                                   As String                           '小工程
        Dim strActionFlg                                As String                           '予約状況
    End Structure

    '@工程選択ｸﾞﾘｯﾄﾞ退避構造体
    Private Structure StepTypeGrid
        Dim blnMessageReadFlg                           As Boolean                          '既読ﾌﾗｸﾞ
        Dim lngDataCount                                As Integer                          '件数
        Dim strReadTime                                 As String                           '更新日時
        Dim typStepTypeList                             As List(Of StepTypeList)            '一覧構造体
    End Structure


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
    '機　能：ACT初期設定および初期情報取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/19 (Mon) 10:36:36 S.Deguchi
    '更新日：2008/06/12 (Thu) 09:24:07 N.Kojima
    '備　考：
    '　　　：2004/12/08 (Wed) 13:17:58 N.Kasai      削除ﾎﾞﾀﾝヘCausesValidationを設定する
    '　　　：2005/07/26 (Tue) 11:29:36 N.Kasai      L/R色追加
    '　　　：2005/08/08 (Mon) 20:23:56 N.Kojima     機種ｺﾝﾎﾞのﾒﾝﾊﾞ追加、mas_.reasoncodeの引数追加(不具合№2985)
    Private Sub Form_Load()

        Dim lblnAns                     As Boolean      '汎用戻り値(True/False)
        Dim llngCnt                     As Integer      '汎用ｶｳﾝﾀ
        Dim lstrFormName                As String       'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName               As String       'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngProductCnt              As Integer      'ﾌﾟﾛﾀﾞｸﾄﾘｽﾄのｶｳﾝﾄ
        Dim llngWpCnt                   As Integer      '装置IDのｶｳﾝﾄ
        Dim lstrClassDivision           As String       '処理区分
        Dim ltypMasOpList               As MasOpList    '大工程情報格納

        Try
            'NSYS 画面表示位置
            Me.StartPosition = FormStartPosition.Manual
            Me.Top  = 0
            Me.Left = 0 - My.Settings.FormOffset
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN0270, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = Me.cmdClose
                
                Exit Sub
            End If
            
            '@画面情報の初期化
            Call prvfrmxxEN0270_Init()
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "Form_Load"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@機種区分一覧取得
            lstrClassDivision = CPstrCD2A & CPstrCD02
            lblnAns = pubblnMasPdlist_Sel(CMstrmas_pdlist__Ver, _
                                          lstrClassDivision, _
                                          mtypProductList, _
                                          llngProductCnt, _
                                          pstrSBID)
            '@結果判定
            With cmbProduct
                If lblnAns = True Then
                '@成功の場合
                    If llngProductCnt > 0 Then
                        '@ﾘｽﾄｾｯﾄ
                        For llngCnt = 0 To llngProductCnt - 1
                            '@機種ｺﾝﾎﾞ格納
                            .AddItem(mtypProductList(llngCnt).strProductID _
                                   & vbTab _
                                   & mtypProductList(llngCnt).strUseId _
                                   & vbTab _
                                   & vbNullString _
                                   & vbTab _
                                   & vbNullString _
                                   & vbTab _
                                   & mtypProductList(llngCnt).strForeColor _
                                   & vbTab _
                                   & mtypProductList(llngCnt).strBackColor)
                        Next
                    End If
                Else
                '@異常の場合終了
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = Me.cmdClose
                        
                    Exit Sub
                End If

                '@機種が１件の場合は表示
                If .ListCount = 1 Then
                    RemoveHandler cmbProduct.Change,AddressOf cmbProduct_Change
                    .ListIndex = 0
                    AddHandler cmbProduct.Change,AddressOf cmbProduct_Change
                End If
            End With

            '@装置一覧取得結果
            lblnAns = pubblnWpList_Sel(CMstrmas_wplist__Ver, _
                                       llngWpCnt, _
                                       pstrSBID, _
                                       CPstrCD02)
            '@結果判定
            With cmbWpID
                If lblnAns = True Then
                '@成功の場合
                    .Clear              '初期化
                    
                    If llngWpCnt > 0 Then
                        For llngCnt = 0 To llngWpCnt - 1
                            '@ﾘｽﾄｾｯﾄ
                            .AddItem (ptypWPList(llngCnt).strWpName _
                                   & vbTab _
                                   & ptypWPList(llngCnt).strWpID)
                        Next
                    End If
                Else
                '@異常の場合終了
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = Me.cmdClose
                    
                    Exit Sub
                End If
            
                '@技術担当者が1件か
                If .ListCount = 1 Then
                    '@1件の技術担当者をﾃﾞﾌｫﾙﾄで表示する
                    RemoveHandler cmbWpID.Change,AddressOf cmbWpID_Change
                    .ListIndex = 0
                    AddHandler cmbWpID.Change,AddressOf cmbWpID_Change
                End If
            End With
            
            '@特定工程取得結果
            lblnAns = pubblnMasUseOpList_Sel(pstrSBID, _
                                             CMstrmas_useoplist_Ver, _
                                             CPstrCD02, _
                                             ltypMasOpList)
            '@結果判定
            With cmbProcessinfo
                If lblnAns = True Then
                '@成功の場合
                    .Clear              '初期化
                    
                    '@ﾘｽﾄｾｯﾄ
                    For llngCnt = 0 To ltypMasOpList.lngMasOpCnt - 1
                        .AddItem(ltypMasOpList.typMasOpId(llngCnt).strOpID)
                    Next
                Else
                '@異常の場合終了
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = Me.cmdClose
                    
                    Exit Sub
                End If

                '@@特定工程取得結果が１件の場合は表示
                If .ListCount = 1 Then
                    RemoveHandler cmbProcessinfo.Change,AddressOf cmbProcessinfo_Change
                    .ListIndex = 0
                    AddHandler cmbProcessinfo.Change,AddressOf cmbProcessinfo_Change
                End If
            End With
            
            '@【作業者ﾘｽﾄ取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnMasEmplist_Sel(CMstrmas_emplist_Ver, _
                                           mtypTechManList, _
                                           mlngTechManListCnt)

            With cmbTechMan
                
                '@作業者ﾘｽﾄ取得結果判定
                If lblnAns = True Then
                    '@作業者ﾘｽﾄ取得結果：正常の場合
                    
                    .Clear      '初期化
                    
                    '@作業者ﾘｽﾄﾃﾞｰﾀ数が1件以上存在するか
                    If mlngTechManListCnt > 0 Then

                        For llngCnt = 0 To mlngTechManListCnt - 1
                        
                            '@ｺﾝﾎﾞ内容設定：技術担当者名/技術担当者ID
                            .AddItem (mtypTechManList(llngCnt).strTechManName _
                                    & vbTab _
                                    & mtypTechManList(llngCnt).strTechManID)
                        Next
                    End If
                Else
                    '@作業者ﾘｽﾄ取得結果：異常の場合
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = Me.cmdClose
                    Exit Sub
                End If
            
                '@技術担当者が1件か
                If .ListCount = 1 Then
                
                    '@1件の場合はﾃﾞﾌｫﾙﾄ表示する
                    RemoveHandler cmbTechMan.Change,AddressOf cmbTechMan_Change
                    .ListIndex = 0
                    AddHandler cmbTechMan.Change,AddressOf cmbTechMan_Change
                End If
            End With
            
        '@↓2005/11/25 (Fri) 15:15:41 S.Deguchi **************************************************
        '@処理変更の為,保留期限取得処理を削除
            '@ﾛｯﾄ保留理由取得結果
        '    lblnAns = pubblnMasResonCode_Sel(CMstrmas_reasoncodeVer, _
        '                                     CPstrCD2U, _
        '                                     mtypMasItemList, _
        '                                     mstrDefaultHoldPeriod)
            lblnAns = pubblnMasResonCode_Sel(CMstrmas_reasoncodeVer, _
                                             CPstrCD2U, _
                                             mtypMasItemList)
        '@↑2005/11/25 (Fri) 15:15:41 S.Deguchi **************************************************
            '@結果判定
            With cmbMasHold
                If lblnAns = True Then
                '@成功の場合
                    '@保留理由ｾｯﾄ
                    .Clear          '初期化
                    '@取得した保留理由が1件以上存在する場合
                    If mtypMasItemList.lngListCnt > 0 Then
                        For llngCnt = 0 To mtypMasItemList.lngListCnt - 1
                            .AddItem(mtypMasItemList.typeMasItem(llngCnt).strItemName _
                                   & vbTab _
                                   & mtypMasItemList.typeMasItem(llngCnt).strItemID)
                        Next llngCnt
                    End If
                Else
                '@異常の場合終了
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = Me.cmdClose
                    
                    Exit Sub
                End If
            
                '@保留理由が1件の場合
                If .ListCount = 1 Then
                    '@1件目表示
                    RemoveHandler cmbMasHold.Change,AddressOf cmbMasHold_Change
                    .ListIndex = 0
                    AddHandler cmbMasHold.Change,AddressOf cmbMasHold_Change
                End If
            End With
                
             '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False
            
            '@削除ﾎﾞﾀﾝヘCausesValidationを設定する
            '@保留期限が過ぎているﾃﾞｰﾀを表示して削除する場合を考慮する。
            cmdDelete.CausesValidation = False
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True

            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = Me.cmdClose

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
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/04/19 (Mon) 13:31:48 S.Deguchi
    '更新日：2004/05/28 (Fri) 11:35:23 N.Kasai
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If

            '@ﾌｫｰﾑﾛｯｸ中の場合は処理を受け付けない
            If Me.Enabled = False Then
                e.Handled = True
                Exit Sub
            End If
            
            Select Case ActiveControl.Name
                Case txtWorkMemo.Name, txtHoldComments.Name
                    '@ｱｸｼｮﾝﾒｯｾｰｼﾞ,保留ｺﾒﾝﾄの場合には処理抜け
                    Exit Sub
                Case txtLotID.Name
                    '@ﾛｯﾄIDの場合
                    '@ｷｰｺｰﾄﾞの判定
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@Enterｷｰの場合
                            RemoveHandler txtLotID.Validating, AddressOf txtLotID_Validate
                            Call txtLotID_Validate(txtLotID,New CancelEventArgs(True))
                            AddHandler txtLotID.Validating, AddressOf txtLotID_Validate
                            If txtLotID.Text = vbNullString Then
                                SendKeys.SendWait(CPstrSendKeysTab)
                                e.Handled = True
                            End If
                    End Select
                Case cmbProduct.Name
                    '@機種の場合
                    '@ｷｰｺｰﾄﾞの判定
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@Enterｷｰの場合
                            RemoveHandler cmbProduct.Validating,AddressOf cmbProduct_Validate
                            Call cmbProduct_Validate(cmbProduct,New CancelEventArgs(False))
                            AddHandler cmbProduct.Validating,AddressOf cmbProduct_Validate
                            e.Handled = True
                    End Select
                Case cmbWpID.Name
                    '@装置名の場合
                    '@ｷｰｺｰﾄﾞの判定
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@Enterｷｰの場合
                            RemoveHandler cmbWpID.Validating,AddressOf cmbWpID_Validate
                            Call cmbWpID_Validate(cmbWpID,New CancelEventArgs(False))
                            AddHandler cmbWpID.Validating,AddressOf cmbWpID_Validate
                            e.Handled = True
                    End Select
                Case cmbProcessinfo.Name
                    '@特定工程の場合
                    '@ｷｰｺｰﾄﾞの判定
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@Enterｷｰの場合
                            RemoveHandler cmbProcessinfo.Validating,AddressOf cmbProcessinfo_Validate
                            Call cmbProcessinfo_Validate(cmbProcessinfo,New CancelEventArgs(False))
                            AddHandler cmbProcessinfo.Validating,AddressOf cmbProcessinfo_Validate
                            e.Handled = True
                    End Select
                Case Else
                    Select Case e.KeyCode
                    '@上記以外のEnterｷｰの場合
                        Case Keys.Return
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
    '機　能：ﾌｫｰﾑｱﾝﾛｰﾄﾞ
    '引　数：Cancel     ：未使用
    '　　　：UnloadMode ：未使用
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 12:42:59 N.Kasai
    '更新日：2012/11/06 (Tue) 15:27:34 T.Oide
    '備　考：
    '　　　：2004/11/01 (Mon) 14:57:46 T.Kitagawa   閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm                 As Boolean      '開放結果格納

        Try
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose,e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@構造体のｸﾘｱ
            mtypStepTypeGrid = Nothing
            mtypTechManList = Nothing           '技術担当者一覧格納用
            mtypDivisionList = Nothing          '種別一覧格納用
            mtypProductList = Nothing           '機種一覧格納用
        '@↓2012/11/06 (Tue) 15:27:52 T.Oide **************************************************
            pstrWfActionFlag = vbNullString
        '@↑2012/11/06 (Tue) 15:27:52 T.Oide **************************************************

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
    '機　能：ﾌﾟﾛｸﾞﾗﾑ終了
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 11:35:23 N.Kasai
    '更新日：2004/05/28 (Fri) 11:35:23 N.Kasai
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim ltypCommonInfo  As CommonInfo   'ﾀﾞﾐｰ構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@終了関数を実行する
            Call publngEnd_Proc(CPstrKeyEN0270, ltypCommonInfo)
            
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

    '関数名：cmdRegist_Click
    '機　能：確定ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 11:35:23 N.Kasai
    '更新日：2012/11/07 (Wed) 12:43:29 T.Oide
    '備　考：技術担当者ｺｰﾄﾞの送信対応(不具合№448)
    '　　　：2005/01/05 (Wed) 09:22:33 N.Kasai      確定後内容をｸﾘｱしない。全部取消処理ｺﾒﾝﾄｱｳﾄ(不具合№390)
    '　　　：2005/04/01 (Fri) 10:26:34 S.Deguchi    確定処理で,ﾛｯﾄ指定の場合には,期間をNullで送る処理を追加
    '　　　：2005/04/28 (Thu) 10:54:52 S.Deguchi    確定処理で,保留責任者IDには作業者IDをｾｯﾄするように修正
    '　　　：2005/08/08 (Mon) 19:42:00 N.Kojima     機種指定(USE_IDが"Monitor","Quality")の場合の"開始日"and"終了日"のｾｯﾄ処理の追加(不具合№2985)
    '　　　：2005/08/23 (Tue) 16:51:46 N.Kojima     ﾃｽﾄ戻り対応。装置指定,特定工程指定の場合は、starttime,endtimeをｾｯﾄして送信する。
    '　　　：2006/10/16 (Mon) 15:51:39 M.Miura      ﾀﾞﾐｰの有効期限をなしに修正(案件№01573)
    '　　　：2006/12/08 (Fri) 16:42:58 N.Kasai      ｴﾗｰ時のﾌｫｰｶｽ設定追加(№01447)
    '　　　：2008/04/15 (Tue) 12:18:26 M.Koni       ｱｸｼｮﾝ予約設定用構造体の初期化処理追加<案件No.02254>
    '　　　：2012/10/29 (Mon) 19:29:50 T.Oide       R9-05(Chipの誤送品対応)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lintCnt                 As Short                'ｵﾌﾟｼｮﾝﾎﾞﾀﾝ専用ｶｳﾝﾀ
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrProduct             As String               '機種ID格納
        Dim llngRow                 As Integer
        Dim ltypLotactrsv           As Lotactrsv            'Lotactrsv初期化用ﾀﾞﾐｰ

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
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称を設定
            lstrFormName = Me.Name
            lstrEventName = "cmdRegist_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ﾌｫｰﾑﾛｯｸ
            
            '@ｱｸｼｮﾝ予約設定用構造体の初期化
            ptypLotactrsv = ltypLotactrsv
            
        '@↓2012/11/12 (Mon) 16:23:54 T.Oide **************************************************
            If vsfUseInfo.GetData(vsfUseInfo.Row, CMlngLotPrestateColOpID) = CMstrWFSiteiOp Then
                '@Wfｱｸｼｮﾝ設定ｺﾋﾟｰ
                ptypLotactrsv.lngWfActionCnt = ptypWfactrsv.lngWfActionCnt
                'ptypLotactrsv.typWfAction = ptypWfactrsv.typWfAction
                'NSYS リスト内容コピー
                ptypLotactrsv.typWfAction = New List(Of WfAction)
                For llngCnt = 0 To ptypLotactrsv.lngWfActionCnt - 1
                    Dim typWfActionTmp As WfAction = New WfAction
                    With typWfActionTmp
                        .strDelFlag = ptypWfactrsv.typWfAction(llngCnt).strDelFlag
                        .strExecTime = ptypWfactrsv.typWfAction(llngCnt).strExecTime
                        .strNewFlag = ptypWfactrsv.typWfAction(llngCnt).strNewFlag
                        .strWfId = ptypWfactrsv.typWfAction(llngCnt).strWfId
                    End With
                    ptypLotactrsv.typWfAction.Add(typWfActionTmp)
                Next
            End If
        '@↑2012/11/12 (Mon) 16:23:54 T.Oide **************************************************
            
            '@ﾛｯﾄ終了ﾃﾞｰﾀ格納
            With ptypLotactrsv
                .strSbID = pstrSBID                                                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                
                '@ｱｸｼｮﾝ予約対象判定
                Select Case True
                    Case optYoyaku0.Checked
                        '@ﾛｯﾄ
                        .strLotActionTypeID = CStr(CMlngActionLot)                          'ﾛｯﾄ
                        .strItemName = txtLotID.Text                                        '項目名(ﾛｯﾄID)
                        
                    Case optYoyaku1.Checked
                        '@機種・ｴﾝﾄﾘ
                        .strLotActionTypeID = CStr(CMlngActionProduct)                      '機種
                        
                        '@機種ID取得
                        With cmbProduct
                            .ValueCol = 0
                            lstrProduct = .Value
                        End With
                        
                        .strItemName = lstrProduct    '項目名(機種ID)
                        
                    Case optYoyaku2.Checked
                        '@装置
                        .strLotActionTypeID = CStr(CMlngActionWP)                           '装置
                        '@装置ID取得
                         cmbWpID.ValueCol = CMlngCmbGridColID
                        .strItemName = cmbWpID.Value                                        '項目名(WPID)
                        
                    Case optYoyaku3.Checked
                        '@特定工程
                        .strLotActionTypeID = CStr(CMlngActionProcess)                      '工程
                        '@空白を設定
                        .strItemName = CPstrMsgNull                                         '項目名(特殊工程)
                End Select
                
        '@↓2012/11/12 (Mon) 12:46:55 T.Oide **************************************************
        '@        .strOpId = vsfUseInfo.Cell(flexcpText, vsfUseInfo.Row, CMlngLotPrestateColOpID)         '大工程
        '@        .strSTEP_ID = vsfUseInfo.Cell(flexcpText, vsfUseInfo.Row, CMlngLotPrestateColStepID)    '小工程
        '@-------------------------------------------------------------------------------------

                '@WFｱｸｼｮﾝ予約以外か
                If vsfUseInfo.GetData(vsfUseInfo.Row, CMlngLotPrestateColOpID) <> CMstrWFSiteiOp Then
                    '@普通のｱｸｼｮﾝ予約の場合工程をｾｯﾄ
                    .strOpID = vsfUseInfo.GetData(vsfUseInfo.Row, CMlngLotPrestateColOpID)         '大工程
                    .strSTEP_ID = vsfUseInfo.GetData(vsfUseInfo.Row, CMlngLotPrestateColStepID)    '小工程
                End If
        '@↑2012/11/12 (Mon) 12:46:55 T.Oide **************************************************
                
                '@技術担当
                cmbTechMan.ValueCol = CMlngGetValueCol
                .strEngEmpId = cmbTechMan.Value                                             '技術担当者ID
            
                '@ｱｸｼｮﾝﾄﾘｶﾞｰ判定
                For lintCnt = 0 To 2
                    If CType(Me.fraFrame3.Controls("optTrigger" & lintCnt.ToString), RadioButton).Checked = True Then
                        Exit For
                    End If
                Next lintCnt
                
                '@ｱｸｼｮﾝﾄﾘｶﾞｰの判定
                Select Case True
                    Case optTrigger0.Checked
                        '@作業開始時
                        .strActionTrigger = CStr(CMlngTriggerStart)     '作業開始
                        
                    Case optTrigger1.Checked
                        '@作業終了時
                        .strActionTrigger = CStr(CMlngTriggerEnd)       '作業終了
                    
                    Case Else
                        '@上記以外
                        .strActionTrigger = CPstrMsgNull
                End Select
                
                '@各ｱｸｼｮﾝ予約対象によって、StartTime,EndTimeの格納値を変える
                '@開始日付
                If calFromDate.Value <> CPstrNullDate Then
                    '@ﾛｯﾄ指定の場合にはNull設定
                    If optYoyaku0.Checked = True Then
                        '@日付が初期値の場合
                        .strStartTime = CPstrMsgNull
                    Else
                        '@機種指定の場合
                        If optYoyaku1.Checked = True Then
                            '@1番目の値を参照(用途:USE_ID)
                            cmbProduct.ValueCol = CMlngCmbGridColID
                            
                            '@USE_IDが"Monitor"(ﾓﾆﾀ),"Quality"(品確),"Dummy"(ﾀﾞﾐｰ)の場合
                            If cmbProduct.Value = CPstrMonitor Or _
                               cmbProduct.Value = CPstrQuality Or _
                               cmbProduct.Value = CPstrPdDummy Then

                                '@日付が初期値の場合
                                .strStartTime = CPstrMsgNull
                            Else
                                '@日付が初期値以外の場合
                                .strStartTime = calFromDate.Value
                            End If
                            
                            '@0番目の値を参照するように戻す(用途:USE_ID)
                            cmbProduct.ValueCol = CMlngCmbGridColName
                        Else
                            '@装置指定,特定工程指定の場合
                            
                            '@日付が初期値以外の場合
                            .strStartTime = calFromDate.Value
                        End If
                    End If
                Else
                    '@日付が初期値の場合
                    .strStartTime = CPstrMsgNull
                End If
                
                '@終了日付
                If calToDate.Value <> CPstrNullDate Then
                    '@ﾛｯﾄ指定の場合にはNull設定
                    If optYoyaku0.Checked = True Then
                        '@日付が初期値の場合
                        .strEndTime = CPstrMsgNull
                    Else
                        '@機種指定の場合
                        If optYoyaku1.Checked = True Then
                            '@1番目の値を参照(用途:USE_ID)
                            cmbProduct.ValueCol = CMlngCmbGridColID
                            
                            '@USE_IDが"Monitor"(ﾓﾆﾀ),"Quality"(品確),"Dummy"(ﾀﾞﾐｰ)の場合
                            If cmbProduct.Value = CPstrMonitor Or _
                               cmbProduct.Value = CPstrQuality Or _
                               cmbProduct.Value = CPstrPdDummy Then

                                '@日付が初期値の場合
                                .strEndTime = CPstrMsgNull
                            Else
                                '@日付が初期値以外の場合
        '@↓2014/06/12 (Thu) 18:13:30 Y.Yoneyama **************************************************
                                '.strEndTime = calToDate.Value
                                .strEndTime = CMstrForeverDate
        '@↑2014/06/12 (Thu) 18:13:30 Y.Yoneyama **************************************************
                                
                            End If
                            
                            '@0番目の値を参照するように戻す(用途:USE_ID)
                            cmbProduct.ValueCol = CMlngCmbGridColName
                        Else
                            '@装置指定,特定工程指定の場合
                            
                            '@日付が初期値以外の場合
        '@↓2014/06/12 (Thu) 18:13:09 Y.Yoneyama **************************************************
                            '.strEndTime = calToDate.Value
                            .strEndTime = CMstrForeverDate
        '@↑2014/06/12 (Thu) 18:13:09 Y.Yoneyama **************************************************
                            
                        End If
                    End If
                Else
                    '@日付が初期値の場合
                    .strEndTime = CPstrMsgNull
                End If
                
                '@最終更新日時
                If mstrEditTime <> vbNullString Then
                    '@日付がある場合
                    .strEditTime = mstrEditTime
                Else
                    '@日付がない場合
                    .strEditTime = CPstrMsgNull
                End If
                
                '@作業ﾒｯｾｰｼﾞNULL判定
                If Trim(txtWorkMemo.Text) <> vbNullString Then
                    .strMessage = txtWorkMemo.Text                      '作業ﾒｯｾｰｼﾞ
                Else
                    .strMessage = CPstrMsgNull                          '空白
                End If
                
                '@作業指示書NULL判定
                If Trim(txtWorkDirect.Text) <> vbNullString Then
                    .strWorkDirectionID = txtWorkDirect.Text            '作業指示書№
                Else
                    .strWorkDirectionID = CPstrMsgNull                  '空白
                End If
                
                '@停止/保留判定
                Select Case True
                    Case optBunrui0.Checked
                        '@指定なし
                        .strStopHoldFlag = CStr(CMlngLotNotSpecify) '指定なし
                        
                    Case optBunrui1.Checked
                        '@ﾛｯﾄ停止
                        .strStopHoldFlag = CStr(CMlngLotStop)       '停止
                        
                    Case optBunrui2.Checked
                        '@ﾛｯﾄ保留
                        .strStopHoldFlag = CStr(CMlngLotHold)       '保留
                    
                End Select
                
                '@停止/保留判定で保留を選択された場合に保留要因、技術担当を取得する。
                If .strStopHoldFlag = CStr(CMlngLotHold) Then
                
                    '@保留責任者取得
                    cmbMasHold.ValueCol = CMlngGetValueCol
                    .strHoldReasonID = cmbMasHold.Value                 '保留理由ID
                    
                    '@保留期限が設定されている場合
                    If txtHoldPeriod.Text <> vbNullString Then
                        .strHoldPeriod = txtHoldPeriod.Text             '保留期限
                    Else
                        .strHoldPeriod = vbNullString                   '保留期限
                    End If
                    
                    .strHoldComments = txtHoldComments.Text             '保留理由

                    .strHoldEmpID = pstrUserID                          '保留責任者
                Else
                    .strHoldPeriod = vbNullString                       '保留期限
                    .strHoldReasonID = CPstrMsgNull                     '保留理由
                End If
                
                .strEmpID = pstrUserID                                  '作業者ID
            End With
            
            '@登録前のRowを退避
            llngRow = vsfUseInfo.Row
            
            '@ﾒｯｾｰｼﾞ送信処理呼び出し
            lblnAns = pubblnLotactrsv_Upd(CMstrlot_actrsv__Ver, ptypLotactrsv)
            '@結果取得
            If lblnAns = True Then
            '@ｽﾃｰﾀｽﾌｫｰﾑ情報へ情報
                '@成功ﾒｯｾｰｼﾞ表示
                '@pubVsfInfo_Disp("C_INF0054　アクション予約登録完了しました。")
                mstrInfoMsg = pubstrMsgReplace_Set(CPstrMsgInf0054)
                
                '@表示ﾒｯｾｰｼﾞ変換
                Call pubVsfInfo_Disp(mstrInfoMsg)
                
                '@確定/削除ﾎﾞﾀﾝﾌﾗｸﾞON
                mlblKakuteiFlag = True
                
                '@ﾌｫｰﾑﾛｯｸ解除
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@表示工程判定
                Select Case lblStepType.Text
                    '@ﾃﾞﾌｫﾙﾄ工程
                    Case CMstrDefultStep
                        '@工程検索処理(画面初期化なし)
                        Call prvStepSearch_Sel(False)
                    '@ﾘﾜｰｸ工程
                    Case CMstrReworkStep
                        '@ﾘﾜｰｸ工程最新表示
                        Call cmdRework_Click(cmdRework,e)
                    '@代替工程
                    Case CMstrAltStep
                        '@代替工程再表示
                        Call cmdAlt_Click(cmdAlt,e)
                    '@特殊工程(先行流動工程,追加流動工程)
                    Case CMstrForwardStep, CMstrAddkStep
                        '@特殊工程再表示
                        Call cmdSpecial_Click(cmdSpecial,e)
                End Select
                
                '@確定/削除ﾎﾞﾀﾝﾌﾗｸﾞ初期化
                mlblKakuteiFlag = False
                
        '@↓2012/11/07 (Wed) 12:42:05 T.Oide **************************************************
                '@編集ﾌﾗｸﾞ初期化
                pblnEN0271EditFlag = False
        '@↑2012/11/07 (Wed) 12:42:05 T.Oide **************************************************
                
                '@ﾌｫｰｶｽの制御
                With vsfUseInfo
                    If .Enabled = True Then
                        .Row = llngRow
                        .ShowCell(llngRow, .Col)
                        Call pubSetFocus(vsfUseInfo)
                    End If
                End With
                
                '@ｱｸｼｮﾝﾄﾘｶﾞｰの再設定
                With optTrigger0
                    .Enabled = True
                    .TabStop = True
                End With
                With optTrigger1
                    .Enabled = True
                    .TabStop = True
                End With
                Select Case ptypLotactrsv.strActionTrigger
                    '@作業開始
                    Case CStr(CMlngTriggerStart)
                        optTrigger0.Checked = True
                        Call optTrigger_Click(optTrigger0,e) 'NSYS Checkedの代入でClickイベントが自動実行されないため手動実行
                    '@作業終了
                    Case CStr(CMlngTriggerEnd)
                        optTrigger1.Checked = True
                        Call optTrigger_Click(optTrigger1,e) 'NSYS Checkedの代入でClickイベントが自動実行されないため手動実行
                    '@例外
                    Case Else
                        optTrigger0.Checked = False
                        optTrigger1.Checked = False
                End Select
            Else
                '@ﾌｫｰﾑﾛｯｸ解除
                
                '@ｴﾗｰ時のﾌｫｰｶｽｾｯﾄ
                Call prvErrFocus_Set()
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            End If
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRegist_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDelete_Click
    '機　能：削除ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 20:39:21 H.Wajima
    '更新日：2012/11/12 (Mon) 16:34:28 T.Oide
    '備　考：
    '　　　：2005/01/05 (Wed) 13:49:51 N.Kasai      全部取消処理ｺﾒﾝﾄｱｳﾄ工程再表示機能追加(不具合№390)
    '　　　：2006/12/08 (Fri) 16:44:12 N.Kasai      ｴﾗｰ時のﾌｫｰｶｽ制御追加(№01447)
    '　　　：2012/11/12 (Mon) 16:34:18 T.Oide       R9-05Chip後誤送品対応
    Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click
        
        Dim lblnAns                     As Boolean          '結果取得(True:正常,False:異常)
        Dim lstrFormName                As String           'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName               As String           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngRow                     As Integer          '登録前行退避
    '@↓2012/11/12 (Mon) 16:34:18 T.Oide **************************************************
        Dim ltypLotActioninfo           As LotActioninfo    'データ削除用
    '@↑2012/11/12 (Mon) 16:34:18 T.Oide **************************************************

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
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称を設定
            lstrFormName = Me.Name
            lstrEventName = "cmdDelete_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ﾌｫｰﾑﾛｯｸ
            
            '@削除前のRowを退避
            llngRow = vsfUseInfo.Row
            
            '@ﾒｯｾｰｼﾞ送信処理呼び出し
            lblnAns = pubblnLotDelAct_Upd(CMstrlot_delact__Ver, mstrLotActionID, mstrEditTime)
            '@結果取得
            If lblnAns = True Then
            '@ｽﾃｰﾀｽﾌｫｰﾑ情報へ情報
                '@成功ﾒｯｾｰｼﾞ表示
                '@pubVsfInfo_Disp("C_INF0069　アクション予約を削除しました。")
                mstrInfoMsg = pubstrMsgReplace_Set(CPstrMsgInf0069)
                
                '@表示ﾒｯｾｰｼﾞ変換
                Call pubVsfInfo_Disp(mstrInfoMsg)

                '@確定/削除ﾎﾞﾀﾝﾌﾗｸﾞON
                mlblKakuteiFlag = True
                
                '@ﾌｫｰﾑﾛｯｸ解除
                
                '@表示工程判定
                Select Case lblStepType.Text
                    '@ﾃﾞﾌｫﾙﾄ工程
                    Case CMstrDefultStep
                        '@工程検索処理(画面初期化なし)
                        Call prvStepSearch_Sel(False)
                    '@ﾘﾜｰｸ工程
                    Case CMstrReworkStep
                        '@ﾘﾜｰｸ工程最新表示
                        Call cmdRework_Click(cmdRework,e)
                    '@代替工程
                    Case CMstrAltStep
                        '@代替工程再表示
                        Call cmdAlt_Click(cmdAlt,e)
                    '@特殊工程(先行流動工程,追加流動工程)
                    Case CMstrForwardStep, CMstrAddkStep
                        '@特殊工程再表示
                        Call cmdSpecial_Click(cmdSpecial,e)
                End Select
                
                '@確定/削除ﾎﾞﾀﾝﾌﾗｸﾞ初期化
                mlblKakuteiFlag = False
                
                '@ﾌｫｰｶｽの制御
                With vsfUseInfo
                    If .Enabled = True Then
                        .Row = llngRow
                        .ShowCell(llngRow, .Col)
                        Call pubSetFocus(vsfUseInfo)
                    End If
                End With
                
                
        '@↓2012/11/12 (Mon) 16:35:49 T.Oide **************************************************
                '@アクション予約データ削除
                ptypLotActioninfo = ltypLotActioninfo

                '@ｳｪﾊｰｱｸｼｮﾝ予約初期化
                Call prvEditDataInit()
        '@↑2012/11/12 (Mon) 16:35:49 T.Oide **************************************************
                

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            Else
                '@ﾌｫｰﾑﾛｯｸ解除
                
                '@ｴﾗｰ時のﾌｫｰｶｽｾｯﾄ
                Call prvErrFocus_Set()
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDelete_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWFAction_Click
    '機　能：ウェハーID設定のアクション予約の設定、設定状況の参照をする
    '引　数：なし
    '戻り値：
    '作成日：2012/10/23 (Tue) 17:21:13 T.Oide
    '更新日：2012/10/23 (Tue) 17:21:13
    '備　考：
    Private Sub cmdWFAction_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWFAction.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfUseInfo
                
                '@WF指定ｱｸｼｮﾝ予約画面を起動
                frmxxEN0271.Instance.ShowDialog(Me)
                frmxxEN0271.Instance = Nothing
                
                '@戻り値判定
                If ptypWfactrsv.lngWfActionCnt <> 0 Then
                    
                    '@WFｱｸｼｮﾝ予約編集ﾌﾗｸﾞはTrueか(ｳｪﾊのｱｸｼｮﾝ予約は工程を選択させない)
                    If pblnEN0271EditFlag = True Then
                            
                        '@最終行は「ウェハー指定」か
                        If .GetData(.Rows.Count - 1, CMlngLotPrestateColOpID) <> CMstrWFSiteiOp Then
                            '@工程を1行追加して、WFｱｸｼｮﾝの設定とする
                            RemoveHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                            .Rows.Count = .Rows.Count + 1
                            AddHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                        
                            .SetData(.Rows.Count - 1, CMlngLotPrestateColNo, .Rows.Count - 1)       'No
                            .SetData(.Rows.Count - 1, CMlngLotPrestateColOpID, CMstrWFSiteiOp)      '大工程
                            .SetData(.Rows.Count - 1, CMlngLotPrestateColStepID, CMstrWFSiteiStep)  '小工程
                        End If
                        .Row = .Rows.Count - 1
                        '@追加した行にフォーカスを当てる(ﾁｪｯｸﾎﾞｯｸｽ等のｲﾈｰﾌﾞﾙが変わるはず)
                        Call pubSetFocus(vsfUseInfo)
                        
                    End If
                    
                End If
            
            End With
            
            '@確定ﾎﾞﾀﾝの有効/無効ﾁｪｯｸ
            Call prvcmdRegist_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWFAction_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdClear_Click
    '機　能：全部取消ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 11:32:17 N.Kasai
    '更新日：2004/05/28 (Fri) 11:32:17
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

            '全部取消処理
            Call prvcmdClear_Proc()
            
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

    '関数名：cmdNowList_Click
    '機　能：最新取得ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/19 (Mon) 10:36:36 S.Deguchi
    '更新日：2012/10/29 (Mon) 20:16:54 T.Oide
    '備　考：
    '　　　：2005/01/08 (Sat) 09:40:12 N.Kasai      格納変数初期化追加
    '　　　：2005/05/06 (Fri) 12:47:17 S.Deguchi    工程取得失敗時の処理にﾘｽﾄなしの場合の処理を追加
    '　　　：2012/10/29 (Mon) 20:16:54 T.Oide       R9-05(Chip誤送品対応)
    Private Sub cmdNowList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowList.Click
        
        Dim ltypWfactrsv        As Wfactrsv         '構造体削除用ﾀﾞﾐｰ
        Dim ltypLotActioninfo   As LotActioninfo

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
            
            '@ﾛｯﾄID,ｴﾝﾄﾘ,装置,特定工程の何れかが入力・選択されている場合のみ処理
            If txtLotID.Text <> vbNullString _
                Or cmbProcessinfo.Text <> vbNullString _
                Or cmbWpID.Text <> vbNullString _
                Or mstrEntryID <> vbNullString Then
                
                '@最新取得ﾎﾞﾀﾝ押下ﾌﾗｸﾞをONに
                mblnNewDataFlag = True
                
                '@退避変数初期化
                mstrReworkRouteID = vbNullString    'ﾘﾜｰｸﾙｰﾄID
                mstrSPRouteId = vbNullString        '特殊ﾙｰﾄID
                mstrOpID = vbNullString             'ﾃﾞﾌｫﾙﾄ大工程
                mstrStepNum = vbNullString          'ｽﾃｯﾌﾟ番号
                
        '@↓2012/10/29 (Mon) 20:16:43 T.Oide **************************************************
                ptypWfactrsv = ltypWfactrsv         'WF設定ｱｸｼｮﾝ予約ｸﾘｱ
                pstrWfActionFlag = vbNullString     '@ｳｪﾊｰｱｸｼｮﾝﾌﾗｸﾞ初期化
        '@↑2012/10/29 (Mon) 20:16:43 T.Oide **************************************************
                
        '@↓2012/11/12 (Mon) 13:05:14 T.Oide **************************************************
                '@ﾛｯﾄｱｸｼｮﾝ情報初期化
                ptypLotActioninfo = ltypLotActioninfo
            
                '@ｳｪﾊｰｱｸｼｮﾝ予約初期化
                Call prvEditDataInit()
        '@↑2012/11/12 (Mon) 13:05:14 T.Oide **************************************************
                
                '@工程検索処理
                Call prvStepSearch_Sel()
                
                With vsfUseInfo
                    '@工程検索処理で,工程一覧の取得に失敗すると,EnableがFalseに設定される為,判定。
                    If .Enabled = True And .Rows.Count > .Rows.Fixed Then
                        '@工程一覧にﾌｫｰｶｽ
                        Call pubSetFocus(vsfUseInfo)
                    End If
                End With
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNowList_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDefult_Click
    '機　能：ﾃﾞﾌｫﾙﾄﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/13 (Mon) 10:40:31 M.Miura
    '更新日：2005/01/05 (Wed) 14:31:53 N.Kasai
    '備　考：
    '　　　：2005/01/05 (Wed) 14:31:53 N.Kasai  格納変数初期化追加
    Private Sub cmdDefult_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDefult.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@退避変数初期化
            mstrReworkRouteID = vbNullString    'ﾘﾜｰｸﾙｰﾄID
            mstrSPRouteId = vbNullString        '特殊ﾙｰﾄID
            mstrOpID = vbNullString             'ﾃﾞﾌｫﾙﾄ大工程
            mstrStepNum = vbNullString          'ｽﾃｯﾌﾟ番号

            '@最新取得ﾎﾞﾀﾝ処理
            Call cmdNowList_Click(cmdNowList,e)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDefult_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdAlt_Click
    '機　能：代替表示ﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/09 (Thu) 17:05:55 M.Miura
    '更新日：2005/01/08 (Sat) 09:18:41 N.Kasai
    '備　考：
    '　　　：2005/01/08 (Sat) 09:18:41 N.Kasai      確定/削除後の設定を残す(不具合№390)
    Private Sub cmdAlt_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAlt.Click

        Dim lblnAns                     As Boolean          '汎用戻り値(True/False)
        Dim llngCnt                     As Integer          '汎用ｶｳﾝﾀ
        Dim ltypLotAltTraveler          As LotAltTraveler   '代替工程要求構造体
        Dim ltypLotAltStepList          As LotAltStepList   '代替工程応答構造体
        Dim lstrItemName                As String           '項目名
        Dim lstrActionTrigger           As String           'ｱｸｼｮﾝﾄﾘｶﾞｰ
        Dim llngRow                     As Integer          '表示最終行
        Dim lstrFormName                As String           'ﾌｫｰﾑ名
        Dim lstrEventName               As String           'ｲﾍﾞﾝﾄ名

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
            
            '@ﾛｯﾄID,ｴﾝﾄﾘの何れかが入力されている場合
            If txtLotID.Text = vbNullString And mstrEntryID = vbNullString Then
                Exit Sub
            End If
                
            '@工程ﾌﾗｸﾞ(代替工程)
            mlngStepFlg = CMlngStepFlg1
            
            '@初工程編集不可ﾌﾗｸﾞ(編集可)
            mblnFastStepNg = False
                
            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称を設定
            lstrFormName = Me.Name
            lstrEventName = "cmdAlt_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
                    
            '@ｱｸｼｮﾝ予約対象判定
            For llngCnt = CMlngActionIndexLot To CMlngActionIndexProcess
                If CType(Me.fraActionReserve.Controls("optYoyaku" & llngCnt.ToString),RadioButton).Checked = True Then
                    Exit For
                End If
            Next llngCnt
                
            With vsfUseInfo
                '@ｱｸｼｮﾝ予約ﾀｲﾌﾟを退避する。(ｱｸｼｮﾝ予約検索時に使用する)
                Select Case llngCnt
                    Case CMlngActionIndexLot
                        '@ｶｳﾝﾀが1の時(ﾛｯﾄ)
                        mintActionType = CMlngActionLot
                        '@代替工程有無列を表示
                        .Cols(CMlngLotPrestateColAltStep).Visible = True
                        '@ﾘﾜｰｸ工程有無列を非表示
                        .Cols(CMlngLotPrestateColReworkStep).Visible = False
                        
                        '@代替工程取得要求構造体にｾｯﾄ
                        ltypLotAltTraveler.strClassDivision = CPstrCD0L     '処理区分
                        ltypLotAltTraveler.strLotID = txtLotID.Text         'ﾛｯﾄID
                        
                    Case CMlngActionIndexProduct
                        '@ｶｳﾝﾀが0の時(機種・ｴﾝﾄﾘ)
                        mintActionType = CMlngActionProduct
                        '@代替工程有無列を表示
                        .Cols(CMlngLotPrestateColAltStep).Visible = True
                        '@ﾘﾜｰｸ工程有無列を表示
                        .Cols(CMlngLotPrestateColReworkStep).Visible = True
                        
                        '@代替工程取得要求構造体にｾｯﾄ
                        ltypLotAltTraveler.strClassDivision = CPstrCD04     '処理区分
                        ltypLotAltTraveler.strPdId = cmbProduct.Value       '機種ID
                        ltypLotAltTraveler.strEntryID = mstrEntryID         'ｴﾝﾄﾘID
                End Select
            End With
            
            '@代替工程取得要求構造体にｾｯﾄ
            With vsfUseInfo
                '@確定/削除ﾎﾞﾀﾝからの再読み込みの場合はｽﾃｯﾌﾟ番号を取得しない
                If mlblKakuteiFlag = False Then
                    '@ｽﾃｯﾌﾟ番号退避
                    mstrStepNum = .GetData(.Row, CMlngLotPrestateColStepNum)                   'ｽﾃｯﾌﾟ番号
                End If
            
                ltypLotAltTraveler.strMsgVer = CMstrlot_alttravelerVer                                  'Msgﾊﾞｰｼﾞｮﾝ
                ltypLotAltTraveler.strSTEPNUM = mstrStepNum                                             'ｽﾃｯﾌﾟ番号
            End With

            '@代替工程取得
            lblnAns = pubblnLotAltTraveler_Sel(ltypLotAltTraveler, _
                                               ltypLotAltStepList)
            '@結果判定
            If lblnAns = False Then
                '@異常の場合終了
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Exit Sub
            End If
            
            '@ｸﾞﾘｯﾄﾞの初期化(構造体は初期化しない)
            Call prvvsfUseInfo_Init(False)
            
            '@取得日時ｾｯﾄ
            lblNowDate.Text = Format$(Now(), CPstrDateTimeMD) & Space(1) & Format$(Now(), CPstrDateFormatHMS)
            
            '@件数ｾｯﾄ
            lblStepCnt.Text = Format$(ltypLotAltStepList.lngStepCnt, CPstrDateFormatKanma)
            
            '@工程に「代替工程」をｾｯﾄ
            lblStepType.Text = CMstrAltStep
            
            '@代替工程表示
            Call prvvsfUseInfoAlt_Disp(ltypLotAltStepList)
            
            '@項目名
            Select Case mintActionType
                Case CMlngActionLot
                    '@ﾛｯﾄの場合
                    '@ﾛｯﾄIDを設定する
                    lstrItemName = txtLotID.Text
                Case CMlngActionProduct
                    '@機種の場合
                    '@機種を設定する
                    lstrItemName = cmbProduct.Value
            End Select
            
            '@ｱｸｼｮﾝﾄﾘｶﾞｰ
            lstrActionTrigger = CPstrMsgNull
            
            With vsfUseInfo
                '@表示最終行を格納
                llngRow = CMlngGridPageRows
                '@表示最終行が最終行以上の場合
                If llngRow >= .Rows.Count Then
                    '@最終行を格納
                    llngRow = .Rows.Count - 1
                End If
                
                '@ﾃﾞｰﾀがある場合
                If .Rows.Count > .Rows.Fixed Then
                    '@ｶﾚﾝﾄ行をﾀｲﾄﾙ行にｾｯﾄ
                    RemoveHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                    .Row = .Rows.Fixed - 1
                    AddHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                End If
                        
                '@EnableがFalseに設定される為,判定。
                If .Enabled = True Then
                    '@工程一覧にﾌｫｰｶｽ
                    Call pubSetFocus(vsfUseInfo)
                End If
            End With
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdAlt_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRework_Click
    '機　能：ﾘﾜｰｸ表示ﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/10 (Fri) 10:59:58 M.Miura
    '更新日：2007/06/25 (Mon) 08:35:21 N.Kasai
    '備　考：
    '　　　：2005/01/05 (Wed) 14:44:13 N.Kasai  ﾃﾞﾌｫﾙﾄ大工程取得ﾀｲﾐﾝｸﾞを変更,確定/削除ﾎﾞﾀﾝ判定ﾌﾗｸﾞの判定追加(確定/削除より呼ばれた場合は取得しない)
    '　　　：2007/06/25 (Mon) 08:35:21 N.Kasai  №01965
    Private Sub cmdRework_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRework.Click

        Dim lblnAns                     As Boolean          '汎用戻り値(True/False)
        Dim llngCnt                     As Integer          '汎用ｶｳﾝﾀ
        Dim ltypMasReworkTraveler       As MasReworkTraveler'ﾘﾜｰｸ工程応答構造体
        Dim lstrActionTrigger           As String           'ｱｸｼｮﾝﾄﾘｶﾞｰ
        Dim llngRow                     As Integer          '表示最終行
        Dim lstrFormName                As String           'ﾌｫｰﾑ名
        Dim lstrEventName               As String           'ｲﾍﾞﾝﾄ名
        Dim lstrLotActionTypeID         As String           'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
        Dim lstrPdID                    As String           '機種ID
        
        
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
            
            '@機種ID,ｴﾝﾄﾘIDの何れかが入力されていない場合
            If cmbProduct.Text = vbNullString Or mstrEntryID = vbNullString Then
                Exit Sub
            End If
                
            '@工程ﾌﾗｸﾞ(ﾘﾜｰｸ工程)
            mlngStepFlg = CMlngStepFlg2
                
            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称を設定
            lstrFormName = Me.Name
            lstrEventName = "cmdRework_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
                    
            '@ｱｸｼｮﾝ予約対象判定
            For llngCnt = CMlngActionIndexLot To CMlngActionIndexProcess
                If CType(Me.fraActionReserve.Controls("optYoyaku" & llngCnt.ToString),RadioButton).Checked = True Then
                    Exit For
                End If
            Next llngCnt
                
            With vsfUseInfo
                '@ｱｸｼｮﾝ予約ﾀｲﾌﾟを退避する。(ｱｸｼｮﾝ予約検索時に使用する)
                Select Case llngCnt
                    Case CMlngActionIndexProduct
                        '@ｶｳﾝﾀが0の時(機種・ｴﾝﾄﾘ)
                        mintActionType = CMlngActionProduct
                        '@代替工程有無列を表示
                        .Cols(CMlngLotPrestateColAltStep).Visible = True
                        '@ﾘﾜｰｸ工程有無列を表示
                        .Cols(CMlngLotPrestateColReworkStep).Visible = True
                        
                        '@確定/削除ﾎﾞﾀﾝ判定ﾌﾗｸﾞの判定(確定/削除より呼ばれた場合は取得しない)
                        If mlblKakuteiFlag = False Then
                            '@ﾘﾜｰｸ時ﾙｰﾄID格納
                            mstrReworkRouteID = .GetData(.Row, CMlngLotPrestateColReworkRouteID)
                            '@ﾃﾞﾌｫﾙﾄ大工程を退避
                            mstrOpID = .GetData(.Row, CMlngLotPrestateColOpID)
                        End If
                End Select
            End With
                        
        '@↓2007/06/22 (Fri) 16:52:29 N.Kasai **************************************************
            '@ｱｸｼｮﾝ予約ﾀｲﾌﾟ判定
            '@ｱｸｼｮﾝ予約ﾀｲﾌﾟ(0:ﾛｯﾄ,1:機種,2:装置,3:工程)
            For llngCnt = CMlngActionIndexLot To CMlngActionIndexProcess
                If CType(Me.fraActionReserve.Controls("optYoyaku" & llngCnt.ToString),RadioButton).Checked = True Then
                    lstrLotActionTypeID = CStr(llngCnt)
                    Exit For
                End If
            Next llngCnt
                        
            '@機種ID
            If cmbProduct.ListIndex = -1 Then
                lstrPdID = vbNullString
            Else
                lstrPdID = Trim$(cmbProduct.Text)
            End If
                        
            '@ﾘﾜｰｸ工程取得
            lblnAns = pubblnMasReworkTraveler_Sel(CMstrmas_reworktravelerVer, _
                                                  mstrOpID, _
                                                  mstrReworkRouteID, _
                                                  lstrLotActionTypeID, _
                                                  lstrPdID, _
                                                  ltypMasReworkTraveler)
        '@↑2007/06/22 (Fri) 16:52:29 N.Kasai **************************************************
            '@結果判定
            If lblnAns = False Then
                '@異常の場合終了
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Exit Sub
            End If
            
            '@ｸﾞﾘｯﾄﾞの初期化(構造体は初期化しない)
            Call prvvsfUseInfo_Init(False)
            
            '@工程に「リワーク工程」をｾｯﾄ
            lblStepType.Text = CMstrReworkStep
            
            '@取得日時ｾｯﾄ
            lblNowDate.Text = Format$(Now(), CPstrDateTimeMD) & Space(1) & Format$(Now(), CPstrDateFormatHMS)
            
            '@件数ｾｯﾄ
            lblStepCnt.Text = Format$(ltypMasReworkTraveler.lngReworkStepCnt, CPstrDateFormatKanma)
            
            '@ﾘﾜｰｸ工程表示
            Call prvvsfUseInfoRework_Disp(mstrOpID, ltypMasReworkTraveler)
                
            '@ｱｸｼｮﾝﾄﾘｶﾞｰ
            lstrActionTrigger = CPstrMsgNull
            
            With vsfUseInfo
                '@表示最終行を格納
                llngRow = CMlngGridPageRows
                '@表示最終行が最終行以上の場合
                If llngRow >= .Rows.Count Then
                    '@最終行を格納
                    llngRow = .Rows.Count - 1
                End If
                
                '@ﾃﾞｰﾀがある場合
                If .Rows.Count > .Rows.Fixed Then
                    '@ｶﾚﾝﾄ行をﾀｲﾄﾙ行にｾｯﾄ
                    RemoveHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                    .Row = .Rows.Fixed - 1
                    AddHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                End If
                
                '@EnableがFalseに設定される為,判定。
                If .Enabled = True Then
                    '@工程一覧にﾌｫｰｶｽ
                    Call pubSetFocus(vsfUseInfo)
                End If
            End With
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRework_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSpecial_Click
    '機　能：特殊工程表示ﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/22 (Fri) 13:43:10 S.Deguchi
    '更新日：2007/06/25 (Mon) 08:36:19 N.Kasai
    '備　考：ﾘﾜｰｸ工程取得と全く一緒
    '備　考：ﾎﾞﾀﾝの有効/無効制御追加
    '　　　：2005/01/05 (Wed) 14:48:00 N.Kasai  ﾃﾞﾌｫﾙﾄ大工程取得ﾀｲﾐﾝｸﾞを変更,確定/削除ﾎﾞﾀﾝ判定ﾌﾗｸﾞの判定追加(確定/削除より呼ばれた場合は取得しない)
    '　　　：2007/06/25 (Mon) 08:36:19 N.Kasai  №01965
    Private Sub cmdSpecial_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSpecial.Click

        Dim lblnAns                     As Boolean          '汎用戻り値(True/False)
        Dim llngCnt                     As Integer          '汎用ｶｳﾝﾀ
        Dim ltypMasReworkTraveler       As MasReworkTraveler'ﾘﾜｰｸ工程応答構造体
        Dim lstrActionTrigger           As String           'ｱｸｼｮﾝﾄﾘｶﾞｰ
        Dim llngRow                     As Integer          '表示最終行
        Dim lstrFormName                As String           'ﾌｫｰﾑ名
        Dim lstrEventName               As String           'ｲﾍﾞﾝﾄ名
        Dim lstrLotActionTypeID         As String           'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
        Dim lstrPdID                    As String           '機種ID

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
            
            '@機種ID,ｴﾝﾄﾘIDの何れかが入力されていない場合
            If cmbProduct.Text = vbNullString Or mstrEntryID = vbNullString Then
                Exit Sub
            End If
                
            '@工程ﾌﾗｸﾞ(ﾘﾜｰｸ工程)
            mlngStepFlg = CMlngStepFlg2
                
            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称を設定
            lstrFormName = Me.Name
            lstrEventName = "cmdSpecial_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
                    
            '@ｱｸｼｮﾝ予約対象判定
            For llngCnt = CMlngActionIndexLot To CMlngActionIndexProcess
                If CType(Me.fraActionReserve.Controls("optYoyaku" & llngCnt.ToString),RadioButton).Checked = True Then
                    Exit For
                End If
            Next llngCnt
                
            With vsfUseInfo
                '@ｱｸｼｮﾝ予約ﾀｲﾌﾟを退避する。(ｱｸｼｮﾝ予約検索時に使用する)
                Select Case llngCnt
                    Case CMlngActionIndexProduct
                        '@ｶｳﾝﾀが0の時(機種・ｴﾝﾄﾘ)
                        mintActionType = CMlngActionProduct
                        '@代替工程有無列を表示
                        .Cols(CMlngLotPrestateColAltStep).Visible = True
                        '@ﾘﾜｰｸ工程有無列を表示
                        .Cols(CMlngLotPrestateColReworkStep).Visible = True
                        
                        If mlblKakuteiFlag = False Then
                            '@特殊時ﾙｰﾄID格納
                            mstrSPRouteId = .GetData(.Row, CMlngLotPrestateColSPRouteID)
                            '@ﾃﾞﾌｫﾙﾄ大工程を退避
                            mstrOpID = .GetData(.Row, CMlngLotPrestateColOpID)
                        End If
                End Select
            End With
            
        '@↓2007/06/22 (Fri) 17:01:30 N.Kasai **************************************************
            '@ｱｸｼｮﾝ予約ﾀｲﾌﾟ判定
            '@ｱｸｼｮﾝ予約ﾀｲﾌﾟ(0:ﾛｯﾄ,1:機種,2:装置,3:工程)
            For llngCnt = CMlngActionIndexLot To CMlngActionIndexProcess
                If CType(Me.fraActionReserve.Controls("optYoyaku" & llngCnt.ToString),RadioButton).Checked = True Then
                    lstrLotActionTypeID = CStr(llngCnt)
                    Exit For
                End If
            Next llngCnt
                        
            '@機種ID
            If cmbProduct.ListIndex = -1 Then
                lstrPdID = vbNullString
            Else
                lstrPdID = Trim$(cmbProduct.Text)
            End If
            
            '@特殊工程取得
            lblnAns = pubblnMasReworkTraveler_Sel(CMstrmas_reworktravelerVer, _
                                                  mstrOpID, _
                                                  mstrSPRouteId, _
                                                  lstrLotActionTypeID, _
                                                  lstrPdID, _
                                                  ltypMasReworkTraveler)
        '@↑2007/06/22 (Fri) 17:01:30 N.Kasai **************************************************

            '@結果判定
            If lblnAns = False Then
                '@異常の場合終了
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                Exit Sub
            End If
            
            '@ｸﾞﾘｯﾄﾞの初期化(構造体は初期化しない)
            Call prvvsfUseInfo_Init(False)
            
            '@工程に「追加工程」をｾｯﾄ
            lblStepType.Text = CMstrAddkStep
            
            '@取得日時ｾｯﾄ
            lblNowDate.Text = Format$(Now(), CPstrDateTimeMD) & Space(1) & Format$(Now(), CPstrDateFormatHMS)
            
            '@件数ｾｯﾄ
            lblStepCnt.Text = Format$(ltypMasReworkTraveler.lngReworkStepCnt, CPstrDateFormatKanma)
            
            '@特殊工程表示
            Call prvvsfUseInfoRework_Disp(mstrOpID, ltypMasReworkTraveler)
                
            '@ｱｸｼｮﾝﾄﾘｶﾞｰ
            lstrActionTrigger = CPstrMsgNull
            
            With vsfUseInfo
                '@表示最終行を格納
                llngRow = CMlngGridPageRows
                '@表示最終行が最終行以上の場合
                If llngRow >= .Rows.Count Then
                    '@最終行を格納
                    llngRow = .Rows.Count - 1
                End If
                
                '@ﾃﾞｰﾀがある場合
                If .Rows.Count > .Rows.Fixed Then
                    '@ｶﾚﾝﾄ行をﾀｲﾄﾙ行にｾｯﾄ
                    RemoveHandler vsfUseInfo.Enter,AddressOf vsfUseInfo_EnterCell
                    .Row = .Rows.Fixed - 1
                    AddHandler vsfUseInfo.Enter,AddressOf vsfUseInfo_EnterCell
                End If
                
                '@EnableがFalseに設定される為,判定。
                If .Enabled = True Then
                    '@工程一覧にﾌｫｰｶｽ
                    Call pubSetFocus(vsfUseInfo)
                End If
            End With
            
            cmdAlt.Enabled = False      '代替表示ﾎﾞﾀﾝ
            cmdRework.Enabled = False   'ﾘﾜｰｸ表示ﾎﾞﾀﾝ
            cmdSpecial.Enabled = False  '特殊工程表示ﾎﾞﾀﾝ
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSpecial_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：optYoyaku_Click
    '機　能：ｱｸｼｮﾝ予約対象選択処理
    '引　数：Index：ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 11:39:40 N.Kasai
    '更新日：2005/01/06 (Thu) 17:20:17 N.Kasai
    '備　考：
    '　　　：2005/01/06 (Thu) 17:20:17 N.Kasai  特殊工程ﾎﾞﾀﾝ初期化を追加
    Private Sub optYoyaku_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optYoyaku0.Click, optYoyaku1. Click, optYoyaku2.Click, optYoyaku3.Click

        Dim Index As Integer 'NSYS 押下オプションボタン種別

        Try
            'NSYS 選択オプションボタン名の最後尾1文字取得
            If IsNumeric(Strings.Right$(sender.Name,1)) then
                Index = CLng(Strings.Right(sender.Name,1))

                'NSYS 選択ラジオボタン判定
                If mstrOptYoyakuClickedName = sender.Name Then
                    '変更されていない場合は処理を抜ける
                    Exit Sub
                Else
                    '変更されている場合はラジオボタン名を退避
                    mstrOptYoyakuClickedName = sender.Name
                End If
            Else
                Exit Sub
            End If

            Select Case Index
                Case CMlngActionIndexLot
                '@ﾛｯﾄの場合
                    '@ﾛｯﾄID
                    With txtLotID
                        .Enabled = True
                        .Text = vbNullString
                    End With
                    '@機種
                    With cmbProduct
                        .Enabled = False
                        RemoveHandler cmbProduct.Change,AddressOf cmbProduct_Change
                        .ListIndex = CMlngCmbClearListIndex
                        AddHandler cmbProduct.Change,AddressOf cmbProduct_Change
                        .BackColor = SystemColors.Window
                    End With
                    '@装置
                    With cmbWpID
                        .Enabled = False
                        RemoveHandler cmbWpID.Change,AddressOf cmbWpID_Change
                        .ListIndex = CMlngCmbClearListIndex
                        AddHandler cmbWpID.Change,AddressOf cmbWpID_Change
                    End With
                    '@特定工程
                    With cmbProcessinfo
                        .Enabled = False
                        RemoveHandler cmbProcessinfo.Change,AddressOf cmbProcessinfo_Change
                        .ListIndex = CMlngCmbClearListIndex
                        AddHandler cmbProcessinfo.Change,AddressOf cmbProcessinfo_Change
                    End With
                
                Case CMlngActionIndexProduct
                '@機種
                    '@ﾛｯﾄID
                    With txtLotID
                        .Enabled = False
                        .Text = vbNullString
                    End With
                    '@機種
                    With cmbProduct
                        .Enabled = True
                        RemoveHandler cmbProduct.Change,AddressOf cmbProduct_Change
                        .ListIndex = CMlngCmbClearListIndex
                        AddHandler cmbProduct.Change,AddressOf cmbProduct_Change
                    End With
                    '@ｴﾝﾄﾘID退避領域の初期化
                    mstrEntryID = vbNullString
                    '@装置
                    With cmbWpID
                        .Enabled = False
                        RemoveHandler cmbWpID.Change,AddressOf cmbWpID_Change
                        .ListIndex = CMlngCmbClearListIndex
                        AddHandler cmbWpID.Change,AddressOf cmbWpID_Change
                    End With
                    '@特定工程
                    With cmbProcessinfo
                        .Enabled = False
                        RemoveHandler cmbProcessinfo.Change,AddressOf cmbProcessinfo_Change
                        .ListIndex = CMlngCmbClearListIndex
                        AddHandler cmbProcessinfo.Change,AddressOf cmbProcessinfo_Change
                    End With
                    
                Case CMlngActionIndexWP
                '@装置
                    '@ﾛｯﾄID
                    With txtLotID
                        .Enabled = False
                        .Text = vbNullString
                    End With
                    '@機種
                    With cmbProduct
                        .Enabled = False
                        RemoveHandler cmbProduct.Change,AddressOf cmbProduct_Change
                        .ListIndex = CMlngCmbClearListIndex
                        AddHandler cmbProduct.Change,AddressOf cmbProduct_Change
                        .BackColor = SystemColors.Window
                    End With
                    '@装置
                    With cmbWpID
                        .Enabled = True
                        RemoveHandler cmbWpID.Change,AddressOf cmbWpID_Change
                        .ListIndex = CMlngCmbClearListIndex
                        AddHandler cmbWpID.Change,AddressOf cmbWpID_Change
                    End With
                    '@特定工程
                    With cmbProcessinfo
                        .Enabled = False
                        RemoveHandler cmbProcessinfo.Change,AddressOf cmbProcessinfo_Change
                        .ListIndex = CMlngCmbClearListIndex
                        AddHandler cmbProcessinfo.Change,AddressOf cmbProcessinfo_Change
                    End With
                    
                Case CMlngActionIndexProcess
                '@特定工程
                    '@ﾛｯﾄID
                    With txtLotID
                        .Enabled = False
                        .Text = vbNullString
                    End With
                    '@機種
                    With cmbProduct
                        .Enabled = False
                        RemoveHandler cmbProduct.Change,AddressOf cmbProduct_Change
                        .ListIndex = CMlngCmbClearListIndex
                        AddHandler cmbProduct.Change,AddressOf cmbProduct_Change
                        .BackColor = SystemColors.Window
                    End With
                    '@装置
                    With cmbWpID
                        .Enabled = False
                        RemoveHandler cmbWpID.Change,AddressOf cmbWpID_Change
                        .ListIndex = CMlngCmbClearListIndex
                        AddHandler cmbWpID.Change,AddressOf cmbWpID_Change
                    End With
                    '@特定工程
                    With cmbProcessinfo
                        .Enabled = True
                        RemoveHandler cmbProcessinfo.Change,AddressOf cmbProcessinfo_Change
                        .ListIndex = CMlngCmbClearListIndex
                        AddHandler cmbProcessinfo.Change,AddressOf cmbProcessinfo_Change
                    End With
                    
            End Select
            
            '@代替表示ﾎﾞﾀﾝを無効
            cmdAlt.Enabled = False
            '@ﾘﾜｰｸ表示ﾎﾞﾀﾝを無効
            cmdRework.Enabled = False
            '@特殊工程表示ﾎﾞﾀﾝを無効
            cmdSpecial.Enabled = False
            
            '@検索ﾎﾞﾀﾝの押下可能ﾁｪｯｸを行う
            Call prvcmdSearch_Chk()
            
            '@WF指定設定ﾎﾞﾀﾝﾁｪｯｸ
            Call prvcmdWFAction_Chk()
            
            '@各ｺﾝﾄﾛｰﾙの設定(使用不可)
            Call prvControlEnabled_Init()
            
            '@最新取得ﾎﾞﾀﾝﾛｯｸ
            cmdNowList.Enabled = False
            '@ﾃﾞﾌｫﾙﾄﾎﾞﾀﾝﾛｯｸ
            cmdDefult.Enabled = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optYoyaku_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotID_Change
    '機　能：ﾛｯﾄID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 11:42:04 N.Kasai
    '更新日：2005/01/11 (Tue) 16:32:02 N.Kasai
    '備　考：
    '　　　：2005/01/11 (Tue) 16:32:02 N.Kasai  ﾛｯﾄID変更ﾌﾗｸﾞ追加
    Private Sub txtLotID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLotID.Change

        Try
            '@検索ﾎﾞﾀﾝの押下可能ﾁｪｯｸを行う
            Call prvcmdSearch_Chk()

            '@ﾛｯﾄID変更ﾌﾗｸﾞ(変更あり)
            mblnLotID_Change = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotID_Validate
    '機　能：ﾛｯﾄID入力後処理
    '引　数：Cancel：ﾌｫｰｶｽ維持
    '戻り値：なし
    '作成日：2004/06/23 (Wed) 08:57:03 H.Wajima
    '更新日：2005/01/11 (Tue) 16:24:42 N.Kasai
    '備　考：
    '　　　：2005/01/11 (Tue) 16:24:42 N.Kasai  ﾛｯﾄID未変更の場合再読み込みしない
    Private Sub txtLotID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtLotID.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@空白の場合
            If txtLotID.Text = vbNullString Then
                '@処理を抜ける
                Exit Sub
            End If
            
            '@ﾛｯﾄID桁数の判定
            If Len(txtLotID.Text) = CMlngLotIDByte Then
                '@10桁の場合
                '@最新取得ﾎﾞﾀﾝﾛｯｸ解除
                cmdNowList.Enabled = True
                '@ﾃﾞﾌｫﾙﾄﾎﾞﾀﾝﾛｯｸ解除
                cmdDefult.Enabled = True

                '@ﾛｯﾄIDが変更された場合
                If mblnLotID_Change = True Then
                    '@最新取得
                    Call cmdNowList_Click(cmdNowList,e)
                Else
                    '@ﾛｯﾄIDは未変更だが,一覧取得ｴﾗｰの場合
                     If vsfUseInfo.Enabled = False Then
                        '@最新取得
                        Call cmdNowList_Click(cmdNowList,e)
                    End If
                End If
                '@ﾛｯﾄID変更ﾌﾗｸﾞ初期化
                mblnLotID_Change = False
                
                '@ﾌｫｰｶｽの制御
                '@一覧表示状態判定
                If vsfUseInfo.Enabled = False Then
                    'ﾃﾞｰﾀなしの為ﾛｯﾄにﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = txtLotID.Name then
                        Call pubSetFocus(txtLotID)
                    End If
                Else
                    '@一覧が表示されている場合は一覧へﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = txtLotID.Name then
                        Call pubSetFocus(vsfUseInfo)
                    End If
                End If
            Else
                '@10桁以外の場合
                If txtLotID.Text <> vbNullString Then
                    '@空欄以外の場合

					'kkw 組立試作流動表電子化
					'1文字目が@から始まるユーザープロセスIDの場合
					If Strings.Left$(txtLotID.Text, 1) = "@" Then
						'@最新取得ﾎﾞﾀﾝﾛｯｸ解除
						cmdNowList.Enabled = True
						'@ﾃﾞﾌｫﾙﾄﾎﾞﾀﾝﾛｯｸ解除
						cmdDefult.Enabled = True
						
						'@ﾛｯﾄIDが変更された場合
						If mblnLotID_Change = True Then
							'@最新取得
							Call cmdNowList_Click(cmdNowList,e)
						Else
							'@ﾛｯﾄIDは未変更だが,一覧取得ｴﾗｰの場合
							 If vsfUseInfo.Enabled = False Then
								'@最新取得
								Call cmdNowList_Click(cmdNowList,e)
							End If
						End If
						'@ﾛｯﾄID変更ﾌﾗｸﾞ初期化
						mblnLotID_Change = False
                
						'@ﾌｫｰｶｽの制御
						'@一覧表示状態判定
						If vsfUseInfo.Enabled = False Then
							'ﾃﾞｰﾀなしの為ﾛｯﾄにﾌｫｰｶｽｾｯﾄ
							If ActiveControl.Name = txtLotID.Name then
								Call pubSetFocus(txtLotID)
							End If
						Else
							'@一覧が表示されている場合は一覧へﾌｫｰｶｽｾｯﾄ
							If ActiveControl.Name = txtLotID.Name then
								Call pubSetFocus(vsfUseInfo)
							End If
						End If

					Else


						'@表示ﾒｯｾｰｼﾞ変換
						pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0012)
						'@"ロットIDは10桁で入力してください。"
						Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
						'@再入力
						e.Cancel = True
					End If
				
				Else
					'@空欄の場合
					e.Cancel = False
				End If

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbProduct_Change
    '機　能：機種変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 13:43:46 M.Miura
    '更新日：2005/01/11 (Tue) 16:33:51 N.Kasai
    '備　考：
    '　　　：2005/01/11 (Tue) 16:33:51 N.Kasai  機種変更ﾌﾗｸﾞ追加
    Private Sub cmbProduct_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProduct.Change

        Try
            '@工程表示ｸﾞﾘｯﾄの初期化
            Call prvvsfUseInfo_Init()
            
            '@検索ﾎﾞﾀﾝ押下可能ﾁｪｯｸ
            Call prvcmdSearch_Chk()
            
            '@最新取得ﾎﾞﾀﾝﾛｯｸ解除
            cmdNowList.Enabled = True
            
            '@ﾃﾞﾌｫﾙﾄﾎﾞﾀﾝﾛｯｸ解除
            cmdDefult.Enabled = True
            
            '@機種変更ﾌﾗｸﾞ(変更あり)
            mblnProduct_Change = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbProduct_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbProduct_CloseUp
    '機　能：機種選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 11:29:01 N.Kasai
    '更新日：2004/05/28 (Fri) 11:29:01
    '備　考：
    Private Sub cmbProduct_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProduct.CloseUp

        Try
            With cmbProduct
                '@機種取得に設定
                .ValueCol = 0
                '@機種が選択されている場合
                If .Value <> vbNullString Then
                    '@機種入力後処理を実行する
                    RemoveHandler cmbProduct.Validating,AddressOf cmbProduct_Validate
                    Call cmbProduct_Validate(cmbProduct,New CancelEventArgs(True))
                    AddHandler cmbProduct.Validating,AddressOf cmbProduct_Validate
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbProduct_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbProduct_Validate
    '機　能：機種入力後処理
    '引　数：Cancel：ﾌｫｰｶｽ維持
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 19:30:19 H.Wajima
    '更新日：2005/01/11 (Tue) 16:34:56 N.Kasai
    '備　考：
    '　　　：2005/01/11 (Tue) 16:34:56 N.Kasai  機種変更ﾌﾗｸﾞ判定追加
    Private Sub cmbProduct_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbProduct.Validating

        Dim lstrPdID                    As String       '機種ID
        Dim llngSeqCnt                  As Integer      '機種一覧ｶｳﾝﾄ
        Dim lstrFormName                As String       'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName               As String       'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lblnAns                     As Boolean      '汎用戻り値(True/False)
        Dim llngCnt                     As Integer      '汎用ｶｳﾝﾀ

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@機種変更ﾌﾗｸﾞ判定
            If mblnProduct_Change = False Then
                '@一覧が表示判定
                If vsfUseInfo.Enabled = True Then
                    '@一覧が表示されている場合は一覧へﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbProduct.Name Then
                        Call pubSetFocus(vsfUseInfo)
                    End If
                Else
                    '@一覧が表示されている場合は閉じるへﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbProduct.Name Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
                '@再読み込みせずﾌｫｰｶｽの移動
                Exit Sub
            End If
            '@機種変更ﾌﾗｸﾞ判定初期化
            mblnProduct_Change = False
           
            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称を設定
            lstrFormName = Me.Name
            lstrEventName = "cmbProduct_Validate"

            If cmbProduct.Text <> vbNullString Then
                '@機種が選択されている場合
                
                
        '@↓2005/07/26 (Tue) 10:13:39 N.Kasai **************************************************
                '@値取得(ﾊﾞｯｸｶﾗｰ値)
                cmbProduct.ValueCol = CMlngCmbGetCol5
                
                If cmbProduct.Value <> vbNullString Then
                    '@ﾊﾞｯｸｶﾗｰ反映
                    cmbProduct.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(cmbProduct.Value))
                Else
                    cmbProduct.BackColor = SystemColors.Window
                End If
        '@↑2005/07/26 (Tue) 10:13:39 N.Kasai **************************************************
                
                '@ﾊﾞｰｼﾞｮﾝの候補を取得する
                Call pubResponseStart(lstrFormName, lstrEventName)
                With cmbProduct
                    .ValueCol = 0
                    lstrPdID = .Value
                End With
                
                '@ﾏｽﾀ工順一覧取得
                lblnAns = pubblnmasPdEntryList_Sel(CMstrmas_pdentrylistVer, _
                                                   lstrPdID, _
                                                   ptypEntryList, _
                                                   llngSeqCnt, _
                                                   pstrSBID, _
                                                   CPstrCD07)
                '@ｴﾝﾄﾘ
                mstrEntryID = vbNullString
                '@最新取得ﾎﾞﾀﾝﾛｯｸ
                cmdNowList.Enabled = False
                '@ﾃﾞﾌｫﾙﾄﾎﾞﾀﾝﾛｯｸ
                cmdDefult.Enabled = False
                
                If lblnAns = True Then
                    If llngSeqCnt > 0 Then
                        llngCnt = 0
                        '@最新ｴﾝﾄﾘID格納
                        mstrEntryID = ptypEntryList(llngCnt).strEntryID
                    End If
                Else
                    '@異常の場合終了
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    Exit Sub
                End If
                        
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                If mstrEntryID <> vbNullString Then
                    '@最新取得ﾎﾞﾀﾝを有効
                    cmdNowList.Enabled = True
                    '@ﾃﾞﾌｫﾙﾄﾎﾞﾀﾝを有効
                    cmdDefult.Enabled = True
                    '@工程検索処理
                    Call prvStepSearch_Sel()
                Else
                    '@空白の場合処理を抜ける
                    Exit Sub
                End If
            
                '@工程一覧が使用可の場合
                If vsfUseInfo.Enabled = True Then
                    '@工程一覧にﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbProduct.Name Then
                        Call pubSetFocus(vsfUseInfo)
                    End If
                Else
                    'NSYS 自身を明示的にフォーカス
                    If ActiveControl.Name = cmbProduct.Name Then
                        Call pubSetFocus(cmbProduct)
                    End If
                End If
            Else
                '@機種が選択されていない場合
                '@最新ｴﾝﾄﾘID初期化
                mstrEntryID = vbNullString
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbProduct_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWpID_Change
    '機　能：装置ID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 11:31:06 N.Kasai
    '更新日：2012/10/24 (Wed) 13:43:30 T.Oide
    '備　考：
    '　　　：2005/01/11 (Tue) 16:37:06 N.Kasai  装置名変更ﾌﾗｸﾞ追加
    Private Sub cmbWpID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWpID.Change

        Dim ltypLotActioninfo   As LotActioninfo

        Try
            '@工程表示ｸﾞﾘｯﾄの初期化
            Call prvvsfUseInfo_Init()
            
            '@検索ﾎﾞﾀﾝ押下可能ﾁｪｯｸ
            Call prvcmdSearch_Chk()
            
            '@最新取得ﾎﾞﾀﾝﾛｯｸ解除
            cmdNowList.Enabled = True
            '@ﾃﾞﾌｫﾙﾄﾎﾞﾀﾝﾛｯｸ解除
            cmdDefult.Enabled = True
            
            '@装置名変更ﾌﾗｸﾞ(変更あり)
            mblnWpID_Change = True
            
        '@↓2012/10/24 (Wed) 13:43:26 T.Oide **************************************************
            '@ﾛｯﾄｱｸｼｮﾝ情報初期化
            ptypLotActioninfo = ltypLotActioninfo

            '@ｳｪﾊｰｱｸｼｮﾝ予約初期化
            Call prvEditDataInit()
            
            '@WF指定設定ボタン有効/無効ﾁｪｯｸ
            Call prvcmdWFAction_Chk()
        '@↑2012/10/24 (Wed) 13:43:26 T.Oide **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWpID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWpID_CloseUp
    '機　能：装置ID選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 11:31:36 N.Kasai
    '更新日：2004/05/28 (Fri) 11:31:36
    '備　考：
    Private Sub cmbWpID_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWpID.CloseUp

        Try
            With cmbWpID
                '@ｴﾝﾄﾘ取得に設定
                .ValueCol = 0
                '@装置が選択されている場合
                If .Value <> vbNullString Then
                    '@KeyDown処理を実行(Enter)
                    Call Form_KeyDown(sender, New KeyEventArgs(Keys.Return))
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWpID_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWpID_Validate
    '機　能：装置入力後処理
    '引　数：Cancel：ﾌｫｰｶｽ維持
    '戻り値：なし
    '作成日：2004/06/23 (Wed) 09:01:11 H.Wajima
    '更新日：2005/01/11 (Tue) 16:38:30 N.Kasai
    '備　考：
    '　　　：2005/01/11 (Tue) 16:38:30 N.Kasai  装置名変更ﾌﾗｸﾞ判定追加
    Private Sub cmbWpID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbWpID.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
          
            '@空白の場合
            If cmbWpID.Text = vbNullString Then
                '@一覧が表示判定
                If vsfUseInfo.Enabled = True Then
                    '@一覧が表示されている場合は一覧へﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbWpID.Name Then
                        Call pubSetFocus(vsfUseInfo)
                    End If
                Else
                    '@一覧が表示されている場合は閉じるへﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbWpID.Name Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
                '@再読み込みせずﾌｫｰｶｽの移動
                Exit Sub
            End If
            
            '@装置名変更ﾌﾗｸﾞ判定
            If mblnWpID_Change = False Then
                '@一覧が表示判定
                If vsfUseInfo.Enabled = True Then
                    '@一覧が表示されている場合は一覧へﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbWpID.Name Then
                        Call pubSetFocus(vsfUseInfo)
                    End If
                Else
                    '@一覧が表示されている場合は閉じるへﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbWpID.Name Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
                '@再読み込みせずﾌｫｰｶｽの移動
                Exit Sub
            End If
            '@装置名変更ﾌﾗｸﾞ判定初期化
            mblnWpID_Change = False
            
            '@工程検索処理
            Call prvStepSearch_Sel()
            
            With vsfUseInfo
                '@工程検索処理で,工程一覧の取得に失敗すると
                '@EnableがFalseに設定される為,判定。
                If .Enabled = True Then
                    '@工程一覧にﾌｫｰｶｽ
                    If ActiveControl.Name = cmbWpID.Name Then
                        Call pubSetFocus(vsfUseInfo)
                    End if
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWpID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbProcessinfo_Change
    '機　能：特殊工程変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 11:26:48 N.Kasai
    '更新日：2005/01/11 (Tue) 16:39:47 N.Kasai
    '備　考：
    '　　　：2005/01/11 (Tue) 16:39:47 N.Kasai  特殊工程変更ﾌﾗｸﾞ追加
    Private Sub cmbProcessinfo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProcessinfo.Change

        Try
            '@工程表示ｸﾞﾘｯﾄの初期化
            Call prvvsfUseInfo_Init()
            
            '@検索ﾎﾞﾀﾝ押下可能ﾁｪｯｸ
            Call prvcmdSearch_Chk()
            
            '@最新取得ﾎﾞﾀﾝﾛｯｸ解除
            cmdNowList.Enabled = True
            '@ﾃﾞﾌｫﾙﾄﾎﾞﾀﾝﾛｯｸ解除
            cmdDefult.Enabled = True
            
            '@特殊工程変更ﾌﾗｸﾞ(変更あり)
            mblnProcessinfo_Change = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbProcessinfo_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbProcessinfo_CloseUp
    '機　能：特殊工程選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 11:27:26 N.Kasai
    '更新日：2004/05/28 (Fri) 11:27:26
    '備　考：
    Private Sub cmbProcessinfo_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProcessinfo.CloseUp

        Try
            With cmbProcessinfo
                '@特定工程取得に設定
                .ValueCol = 0
                '@装置が選択されている場合
                If .Value <> vbNullString Then
                    '@KeyDown処理を実行(Enter)
                    Call Form_KeyDown(sender, New KeyEventArgs(Keys.Return))
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbProcessinfo_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbProcessinfo_Validate
    '機　能：特定工程入力後処理
    '引　数：Cancel：ﾌｫｰｶｽ維持
    '戻り値：なし
    '作成日：2004/06/23 (Wed) 09:01:32 H.Wajima
    '更新日：2005/01/11 (Tue) 16:40:56 N.Kasai
    '備　考：
    '　　　：2005/01/11 (Tue) 16:40:56 N.Kasai  特殊工程変更判定追加
    Private Sub cmbProcessinfo_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbProcessinfo.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@空白の場合
            If cmbProcessinfo.Text = vbNullString Then
                '@一覧が表示判定
                If vsfUseInfo.Enabled = True Then
                    '@一覧が表示されている場合は一覧へﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbProcessinfo.Name Then
                        Call pubSetFocus(vsfUseInfo)
                    End If
                Else
                    '@一覧が表示されている場合は閉じるへﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbProcessinfo.Name Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
                '@再読み込みせずﾌｫｰｶｽの移動
                Exit Sub
            End If
            
            '@特殊工程変更ﾌﾗｸﾞ判定
            If mblnProcessinfo_Change = False Then
                '@一覧が表示判定
                If vsfUseInfo.Enabled = True Then
                    '@一覧が表示されている場合は一覧へﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbProcessinfo.Name Then
                        Call pubSetFocus(vsfUseInfo)
                    End If
                Else
                    '@一覧が表示されている場合は閉じるへﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbProcessinfo.Name Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
                '@再読み込みせずﾌｫｰｶｽの移動
                Exit Sub
            End If
            '@特殊工程変更ﾌﾗｸﾞ判定初期化
            mblnProcessinfo_Change = False

            '@工程検索処理
            Call prvStepSearch_Sel()

            With vsfUseInfo
                '@工程検索処理で,工程一覧の取得に失敗すると
                '@EnableがFalseに設定される為,判定。
                If .Enabled = True Then
                    '@工程一覧にﾌｫｰｶｽ
                    If ActiveControl.Name = cmbProcessinfo.Name Then
                        Call pubSetFocus(vsfUseInfo)
                    End If
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbProcessinfo_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：optTrigger_Click
    '機　能：ｱｸｼｮﾝﾄﾘｶﾞｰ選択処理
    '引　数：Index：ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 11:38:00 N.Kasai
    '更新日：2012/11/06 (Tue) 19:22:23 T.Oide
    '備　考：
    '　　　：2004/11/05 (Fri) 17:50:29 M.Miura　    保留/停止なしｵﾌﾟｼｮﾅﾙﾎﾞﾀﾝの有効判定を追加
    '　　　：2004/12/06 (Mon) 11:32:55 N.Kasai      ｱｸｼｮﾝ予約がﾛｯﾄの場合日付の初期値は空白とする(№276)
    '　　　：2005/04/01 (Fri) 09:31:07 S.Deguchi    ｱｸｼｮﾝ予約がﾛｯﾄの場合日付のｶﾚﾝﾀﾞｰｺﾝﾎﾞを使用不可にする(№680)
    '　　　：2005/05/06 (Fri) 11:15:36 S.Deguchi    ｱｸｼｮﾝ予約が設定されている場合のみﾒｯｾｰｼﾞを投げるように修正
    '　　　：2005/08/08 (Mon) 19:44:27 N.Kojima     機種指定(USE_IDが"Monitor","Quality")の場合の"開始日","終了日"の有効無効判定の追加(不具合№2985)
    '　　　：2006/10/16 (Mon) 15:48:12 M.Miura      機種指定(USE_IDが"Dummy")の場合の"開始日","終了日"の有効無効判定の追加(案件№01573)
    '　　　：2012/11/06 (Tue) 19:22:34 T.Oide       R9-05 Chip誤送品防止対応
    Private Sub optTrigger_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optTrigger0.Click, optTrigger1.Click
        
        Dim lstrOpID                    As String       '大工程
        Dim llngCnt                     As Integer      '汎用ｶｳﾝﾀ
        Dim lblnAns                     As Boolean      '汎用戻り値(True/False)
        Dim lblnFlag                    As Boolean      '汎用結果
        Dim lblnTechManMatchFlag        As Boolean      '同一技術担当存在判定ﾌﾗｸﾞ(True：存在する、False：存在しない)
        Dim Index                       As Integer      'NSYS 押下オプションボタン種別

        Try
            'NSYS 押下オプションボタン名の最後尾1文字取得
            If IsNumeric(Strings.Right$(sender.Name,1)) Then
                Index = CLng(Strings.Right$(sender.Name,1))
            Else
                Exit Sub
            End If

            '@ｸﾞﾘｯﾄﾞの明細取得(大工程)
            lstrOpID = vsfUseInfo.GetData(vsfUseInfo.Row, CMlngLotPrestateColOpID)
            
            '@ｸﾞﾘｯﾄﾞが未選択の場合
            If lstrOpID = vbNullString Then
            '@使用不可
                '@ｱｸｼｮﾝ予約設定部分の初期化
                Call prvControlEnabled_Init()
            Else
            '@使用可
                '@画面の表示設定
                If optYoyaku0.Checked = True Then
                '@ｱｸｼｮﾝﾌﾗｸﾞ(ﾛｯﾄ選択)の場合
                    '@開始日付
                    calFromDate.Value = vbNullString
                    '@終了日付
                    calToDate.Value = vbNullString
                     
                    '@開始日付/終了日付のｶﾚﾝﾀﾞｰｺﾝﾎﾞを使用不可状態にする
                    calFromDate.Enabled = False
                    calToDate.Enabled = False
                Else
                '@ｱｸｼｮﾝﾌﾗｸﾞ(ﾛｯﾄ選択)以外の場合
                    If optYoyaku1.Checked = True Then
                        '@機種指定の場合
                        '@1番目の値を参照(用途:USE_ID)
                        cmbProduct.ValueCol = CMlngCmbGridColID
                        
                        '@USE_IDが"Monitor"(ﾓﾆﾀ),"Quality"(品確),"Dummy"(ﾀﾞﾐｰ)の場合
                        If cmbProduct.Value = CPstrMonitor Or _
                           cmbProduct.Value = CPstrQuality Or _
                           cmbProduct.Value = CPstrPdDummy Then

                            '@開始日付
                            calFromDate.Value = vbNullString
                            '@終了日付
                            calToDate.Value = vbNullString
                             
                            '@開始日付/終了日付のｶﾚﾝﾀﾞｰｺﾝﾎﾞを使用不可状態にする
                            calFromDate.Enabled = False
                            calToDate.Enabled = False
                        Else
                            '@開始日付
                            calFromDate.Value = Format$(Now(), CPstrDateTimeYMD)
                            '@終了日付
                            calToDate.Value = Format$(DateAdd(CMstrM, 1, Now()), CPstrDateTimeYMD)
                            
                            '@開始日付/終了日付のｶﾚﾝﾀﾞｰｺﾝﾎﾞを使用可能状態にする
                            calFromDate.Enabled = True
                            calToDate.Enabled = True
                        End If
                        
                        '@0番目の値を参照するように戻す(用途:USE_ID)
                        cmbProduct.ValueCol = CMlngCmbGridColName
                    Else
                    
        '@↓2012/11/07 (Wed) 13:25:05 T.Oide **************************************************
        '@                '@開始日付
        '@                calFromDate.Value = Format$(Date, CPstrDateTimeYMD)
        '@                '@終了日付
        '@                calToDate.Value = Format$(DateAdd(CMstrM, 1, Date), CPstrDateTimeYMD)
        '@
        '@                '@開始日付/終了日付のｶﾚﾝﾀﾞｰｺﾝﾎﾞを使用可能状態にする
        '@                calFromDate.Enabled = True
        '@                calToDate.Enabled = True
        '@-------------------------------------------------------------------------------------
                        
                        '@(装置ｱｸｼｮﾝで)WF指定ｱｸｼｮﾝ以外か
                        If vsfUseInfo.GetData(vsfUseInfo.Row, CMlngLotPrestateColOpID) <> CMstrWFSiteiOp Then
                            calFromDate.Value = Format$(Now(), CPstrDateTimeYMD)                     '@開始日付
                            calToDate.Value = Format$(DateAdd(CMstrM, 1, Now()), CPstrDateTimeYMD)   '@終了日付
                            '@開始日付/終了日付のｶﾚﾝﾀﾞｰｺﾝﾎﾞを使用可能状態にする
                            calFromDate.Enabled = True
                            calToDate.Enabled = True
                        End If

        '@↑2012/11/07 (Wed) 13:25:05 T.Oide **************************************************
                    End If
                End If
                
                '@作業指示書№
                txtWorkDirect.Text = vbNullString
                
                '@ﾒｯｾｰｼﾞ
                txtWorkMemo.Text = vbNullString
                
                '@保留期限
                txtHoldPeriod.Text = vbNullString
                
                '@保留ｺﾒﾝﾄ
                txtHoldComments.Text = vbNullString
                
                '@保留理由
                RemoveHandler cmbMasHold.Change,AddressOf cmbMasHold_Change
                cmbMasHold.ListIndex = -1
                AddHandler cmbMasHold.Change,AddressOf cmbMasHold_Change
                
                '@技術担当
                RemoveHandler cmbTechMan.Change,AddressOf cmbTechMan_Change
                cmbTechMan.ListIndex = -1
                AddHandler cmbTechMan.Change,AddressOf cmbTechMan_Change
                
                '@保留/停止なしｵﾌﾟｼｮﾅﾙﾎﾞﾀﾝが有効な場合
                If optBunrui0.Enabled = True Then
                    '保留/停止なしを選択
                    optBunrui0.Checked = True
                    Call optBunrui_Click(optBunrui0,e) 'NSYS Checkedの代入でClickイベントが自動実行されないため手動実行
                End If
                
                '@選択された工程にｱｸｼｮﾝ予約が設定されているか否かで処理分岐
                With vsfUseInfo
                    If .GetData(.Row, CMlngLotPrestateColActStepInfo) <> vbNullString Then
                        '@ｱｸｼｮﾝ予約検索
                        lblnAns = prvblnActInfo_Sel(Index)
                        '@結果判定
                        If lblnAns = True Then
                            '@取得結果OK
                            lblnFlag = True
                        Else
                            '@取得結果NG
                            lblnFlag = False
                        End If
                    Else
                        '@取得結果NG(設定されていない場合)
                        lblnFlag = False
                    End If
                    
                    '@取得結果による処理分岐
                    If lblnFlag = False Then
                        '@ﾛｯﾄｱｸｼｮﾝ予約IDを初期化
                        mstrLotActionID = vbNullString
                        
                        '@最終更新日時を初期化
                        mstrEditTime = vbNullString
                        
                        '@削除ﾎﾞﾀﾝを押下不能にする
                        cmdDelete.Enabled = False
                    
                        '@保留期限を退避
                        If lblnFlag = True Then
                             mstrHoldTermDate = ptypLotActioninfo.strHoldPeriod
                        Else
                            '@保留期限ｾｯﾄ
                            mstrHoldTermDate = CMstrOneWeek     '1週間後計算値
                        End If
                        
                        '@ｱｸｼｮﾝ予約ﾀｲﾌﾟ="ﾛｯﾄ"で、かつ技術担当者がNULL以外か
                        If optYoyaku0.Checked = True And _
                            mstrTechManID <> vbNullString Then
                            
                            '@同一技術担当者存在判定ﾌﾗｸﾞを初期化する
                            lblnTechManMatchFlag = False
                            
                            '@技術担当者ﾘｽﾄが1件以上存在するか
                            If mlngTechManListCnt > 0 Then
                                
                                For llngCnt = 0 To mtypTechManList.Count - 1
                                    
                                    '@退避領域の技術担当者IDと技術担当者ｺﾝﾎﾞの技術担当者IDが同じか
                                    If mtypTechManList(llngCnt).strTechManID = mstrTechManID Then
                                    
                                        '@同一技術担当者存在判定ﾌﾗｸﾞに"True：存在する"をｾｯﾄ
                                        lblnTechManMatchFlag = True
                                        Exit For
                                    End If
                                Next llngCnt
                            End If
                            
                            '@同一技術担当者存在判定ﾌﾗｸﾞが"True：存在する"か
                            If lblnTechManMatchFlag = True Then
                                '@同一技術担当者名を表示する
                                cmbTechMan.ListIndex = llngCnt
                            Else
                                '@技術担当者を表示しない
                                RemoveHandler cmbTechMan.Change,AddressOf cmbTechMan_Change
                                cmbTechMan.ListIndex = -1
                                AddHandler cmbTechMan.Change,AddressOf cmbTechMan_Change
                            End If
                        End If
                    End If
                End With
            End If
            
            With vsfUseInfo
            '@ｱｸｼｮﾝ予約設定可の場合
                '@背景色がｸﾞﾚｰではない又は,背景色がｸﾞﾚｰでﾃﾞﾌｫﾙﾄ工程,又は,背景色がｸﾞﾚｰで初工程編集不可ﾌﾗｸﾞが編集可の場合
                If .GetCellRange(.Row, CMlngLotPrestateColOpID).StyleDisplay.BackColor <> ColorTranslator.FromWin32(CPlngGridGray) Or _
                   (.GetCellRange(.Row, CMlngLotPrestateColOpID).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngGridGray) And _
                   (mlngStepFlg = CMlngStepFlg0 Or mblnFastStepNg = False)) Then
                    
                    '@ｱｸｼｮﾝﾌﾗｸﾞ(ﾛｯﾄ選択)の場合
                    If optYoyaku0.Checked = True Then
                        '@作業終了の場合
                        calFromDate.Enabled = False
                        calToDate.Enabled = False
                    Else
                        '@機種指定の場合
                        If optYoyaku1.Checked = True Then
                            
                            '@1番目の値を参照(用途:USE_ID)
                            cmbProduct.ValueCol = CMlngCmbGridColID
                            
                            '@USE_IDが"Monitor"(ﾓﾆﾀ),"Quality"(品確),"Dummy"(ﾀﾞﾐｰ)の場合
                            If cmbProduct.Value = CPstrMonitor Or _
                               cmbProduct.Value = CPstrQuality Or _
                               cmbProduct.Value = CPstrPdDummy Then

                                '@作業終了の場合
                                calFromDate.Enabled = False
                                calToDate.Enabled = False
                            Else
                                '@作業終了の場合
                                calFromDate.Enabled = True
                                calToDate.Enabled = True
                            End If
                            
                            '@0番目の値を参照するように戻す(用途:USE_ID)
                            cmbProduct.ValueCol = CMlngCmbGridColName
                        Else
        '@↓2012/11/07 (Wed) 13:34:57 T.Oide **************************************************
        '@                    '@作業終了の場合
        '@                    calFromDate.Enabled = True
        '@                    calToDate.Enabled = True
        '@-------------------------------------------------------------------------------------
                            '@(装置ｱｸｼｮﾝで)WF指定ｱｸｼｮﾝ以外か
                            If vsfUseInfo.GetData(vsfUseInfo.Row, CMlngLotPrestateColOpID) <> CMstrWFSiteiOp Then
                                calFromDate.Enabled = True      '作業開始時を有効
                                calToDate.Enabled = True        '作業終了時を有効
                            End If
        '@↑2012/11/07 (Wed) 13:34:57 T.Oide **************************************************
                        End If
                    End If
                    
                    For llngCnt = CMlngLotNotSpecify To CMlngLotHold
                        
                        With CType(Me.fraBunrui.Controls("optBunrui" & llngCnt.ToString),RadioButton)
                            .Enabled = True
                            .TabStop = True
                        End With
                    Next llngCnt
                    
                    '@保留/停止不可の工程又は,ｱｸｼｮﾝ予約ﾀｲﾌﾟに装置が選ばれている場合
                    If .GetCellRange(.Row, CMlngLotPrestateColOpID).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngGridGray) Or _
                       optYoyaku2.Checked = True Then
                        
                        '@ｱｸｼｮﾝﾄﾘｶﾞｰが作業終了で,ﾃﾞﾌｫﾙﾄ工程の場合
                        If optTrigger1.Checked = True And mlngStepFlg = CMlngStepFlg0 Then
                            '@ﾛｯﾄ保留/停止は設定可
                            optBunrui1.Enabled = True
                            optBunrui2.Enabled = True
                        Else
                            '@ﾛｯﾄ保留/停止は設定不可
                            optBunrui1.Enabled = False
                            optBunrui2.Enabled = False
                        End If
                    End If
                            
                    '@停止解除機能が未開発の為,停止ｵﾌﾟｼｮﾅﾙﾎﾞﾀﾝを無効化
                    With optBunrui1
                        .Enabled = False
                        .TabStop = False
                    End With
                    
                    Select Case True
                        Case optBunrui0.Checked, optBunrui1.Checked
                        '@停止/保留なし,停止
                            cmbMasHold.Enabled = False
                            txtHoldPeriod.Enabled = False
                            cmbTechMan.Enabled = True
                            txtWorkMemo.Enabled = True
                            txtWorkDirect.Enabled = True
                            txtHoldComments.Enabled = False
                        
                        Case optBunrui2.Checked
                            '@保留
                            cmbMasHold.Enabled = True
                            txtHoldPeriod.Enabled = True
                            cmbTechMan.Enabled = True
                            txtWorkMemo.Enabled = True
                            txtWorkDirect.Enabled = True
                            txtHoldComments.Enabled = True
                        
                        Case Else
                            '@上記以外の場合
                            optBunrui0.Checked = True
                            Call optBunrui_Click(optBunrui0,e) 'NSYS Checkedの代入でClickイベントが自動実行されないため手動実行
                            cmbMasHold.Enabled = False
                            txtHoldPeriod.Enabled = False
                            cmbTechMan.Enabled = True
                            txtWorkMemo.Enabled = True
                            txtWorkDirect.Enabled = True
                            txtHoldComments.Enabled = False
                    End Select
                Else
                    '@ｱｸｼｮﾝ予約設定不可の場合
                    cmbMasHold.Enabled = False
                    txtHoldPeriod.Enabled = False
                    cmbTechMan.Enabled = False
                    txtWorkMemo.Enabled = False
                    txtWorkDirect.Enabled = False
                    txtHoldComments.Enabled = False
                End If
            End With

            'NSYS 選択したラジオボタンのみTab移動可とする
            If optTrigger0.Checked Then
                optTrigger0.TabStop = True
                optTrigger1.TabStop = False
            Else
                optTrigger0.TabStop = False
                optTrigger1.TabStop = True
            End If
            
            '@確定ﾎﾞﾀﾝの使用可否ﾁｪｯｸ
            Call prvcmdRegist_Chk()
            
        '@↓2012/11/13 (Tue) 09:43:09 T.Oide **************************************************
            '@WF指定設定ﾎﾞﾀﾝﾁｪｯｸ
            Call prvcmdWFAction_Chk()
            '@編集ﾌﾗｸﾞ初期化
            pblnEN0271EditFlag = False
            
            '@WF指定ｱｸｼｮﾝ予約情報を編集用構造体にｺﾋﾟｰ
            ptypWfactrsv.lngWfActionCnt = ptypLotActioninfo.lngWfActionCnt
            'ptypWfactrsv.typWfAction = ptypLotActioninfo.typWfAction
            'NSYS リスト内容コピー
            ptypWfactrsv.typWfAction = New List(Of WfAction)
            For llngCnt = 0 To ptypWfactrsv.lngWfActionCnt - 1
                Dim typWfActionTmp As WfAction = New WfAction
                With typWfActionTmp
                    .strDelFlag = ptypLotActioninfo.typWfAction(llngCnt).strDelFlag
                    .strExecTime = ptypLotActioninfo.typWfAction(llngCnt).strExecTime
                    .strNewFlag = ptypLotActioninfo.typWfAction(llngCnt).strNewFlag
                    .strWfId = ptypLotActioninfo.typWfAction(llngCnt).strWfId
                End With
                ptypWfactrsv.typWfAction.Add(typWfActionTmp)
            Next
        '@↑2012/11/13 (Tue) 09:43:09 T.Oide **************************************************

            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optTrigger_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calFromDate_Change
    '機　能：開始日付変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 20:00:01 H.Wajima
    '更新日：2004/06/28 (Mon) 20:00:01
    '備　考：
    Private Sub calFromDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calFromDate.Change

        Try
            '@確定ﾎﾞﾀﾝ押下ﾁｪｯｸ
            Call prvcmdRegist_Chk()

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

    '関数名：calFromDate_CalendarSelect
    '機　能：開始日付選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 20:07:26 H.Wajima
    '更新日：2004/08/19 (Thu) 11:34:15 Y.Yamagishi
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

    '関数名：calFromDate_Validate
    '機　能：開始日付のValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/07/07 (Wed) 16:34:43 T.Kitagawa
    '更新日：2004/08/19 (Thu) 11:36:51 Y.Yamagishi
    '備　考：
    Private Sub calFromDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calFromDate.Validating
        
        Dim lstrDate    As String   '日付

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            With calFromDate
                '@日付が入力されていない(空欄)場合
                If .Value <> CPstrNullDate Then
                    '@日付の有効性ﾁｪｯｸ
                    If pubblnYearRange_Chk(.Value) = False Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                        '@"1900年～2100年以外の日付は入力できません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
                '@過去日付の場合
                If .Value < Format$(Now(), CPstrDateTimeYMD) Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                    '@"過去日付は指定できません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@開始日付にｾｯﾄﾌｫｰｶｽ
                    e.Cancel = True
                    Exit Sub
                End If
                
                '@ｼｽﾃﾑ日付の１ヶ月後を格納
                lstrDate = Format$(DateAdd(CMstrM, 1, Now()), CPstrDateTimeYMD)
                
                '@空欄以外の場合
                If .Value <> CPstrNullDate Then
                    '@開始日付がｼｽﾃﾑ日付の１ヶ月後より大きい場合
                    If lstrDate < .Value Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003A)
                        '@"<TRM3AW>$$有効期限は本日から１ヶ月を越えて設定できません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        '@開始日付にｾｯﾄﾌｫｰｶｽ
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End With
                
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

    '関数名：calToDate_Change
    '機　能：終了日付変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 20:00:10 H.Wajima
    '更新日：2004/06/28 (Mon) 20:00:10
    '備　考：
    Private Sub calToDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calToDate.Change

        Try
            '@確定ﾎﾞﾀﾝ押下ﾁｪｯｸ
            Call prvcmdRegist_Chk()

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

    '関数名：calToDate_CalendarSelect
    '機　能：終了日付選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 20:07:26 H.Wajima
    '更新日：2004/06/28 (Mon) 20:09:47 H.Wajima
    '備　考：
    Private Sub calToDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calToDate.CalendarSelect

        Try
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

    '関数名：calToDate_Validate
    '機　能：終了日付のValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/07/07 (Wed) 16:34:43 T.Kitagawa
    '更新日：2004/07/07 (Wed) 16:34:43
    '備　考：
    Private Sub calToDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calToDate.Validating
        Dim lstrDate    As String   '日付

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            With calToDate
                '@日付が入力されていない(空欄)場合
                If .Value <> CPstrNullDate Then
                    '@日付の有効性ﾁｪｯｸ
                    If pubblnYearRange_Chk(.Value) = False Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                        '@"1900年～2100年以外の日付は入力できません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
                '@過去日付の場合
                If .Value < Format$(Now(), CPstrDateTimeYMD) Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                    '@"過去日付は指定できません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@終了日付にｾｯﾄﾌｫｰｶｽ
                    e.Cancel = True
                    Exit Sub
                End If
                
                '@ｼｽﾃﾑ日付の１ヶ月後を格納
                lstrDate = Format$(DateAdd(CMstrM, 1, Now()), CPstrDateTimeYMD)
                
                '@空欄以外の場合
                If .Value <> CPstrNullDate Then
                    '@開始日付がｼｽﾃﾑ日付の１ヶ月後より大きい場合
                    If lstrDate < .Value Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003A)
                        '@"<TRM3AW>$$有効期限は本日から１ヶ月を越えて設定できません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        '@開始日付にｾｯﾄﾌｫｰｶｽ
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End With
                
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

    '関数名：cmbTechMan_Change
    '機　能：技術担当者ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 11:29:21 N.Kasai
    '更新日：2004/05/28 (Fri) 11:29:21 N.Kasai
    '備　考：
    Private Sub cmbTechMan_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbTechMan.Change

        Try
            '@技術担当者の値取得列を技術担当者IDに設定
            cmbTechMan.ValueCol = CMlngGetValueCol
            
            '@確定ﾎﾞﾀﾝの使用可否ﾁｪｯｸ
            Call prvcmdRegist_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbTechMan_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbTechMan_CloseUp
    '機　能：技術担当者ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/24 (Mon) 13:06:04 N.Kasai
    '更新日：2004/05/24 (Mon) 13:06:04 N.Kasai
    '備　考：
    Private Sub cmbTechMan_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbTechMan.CloseUp

        Try
            With cmbTechMan
            
                '@技術担当者の値取得列を技術担当者IDに設定
                .ValueCol = CMlngGetValueCol
                
                '@技術担当者が選択されている場合
                If .Value <> vbNullString Then
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbTechMan_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMasHold_Change
    '機　能：保留理由変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/27 (Thu) 11:46:57 N.Kasai
    '更新日：2004/05/27 (Thu) 11:46:57
    '備　考：
    Private Sub cmbMasHold_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMasHold.Change

        Try
            '@確定ﾎﾞﾀﾝの使用可否ﾁｪｯｸ
            Call prvcmdRegist_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMasHold_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMasHold_CloseUp
    '機　能：保留理由選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/24 (Mon) 13:06:04 N.Kasai
    '更新日：2004/05/24 (Mon) 13:06:00 N.Kasai
    '備　考：
    Private Sub cmbMasHold_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMasHold.CloseUp

        Try
            With cmbMasHold
                '@取得列を保留理由IDに設定
                .ValueCol = CMlngGetValueCol
                '@保留理由IDが選択されている場合
                If .Value <> vbNullString Then
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMasHold_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：optBunrui_Click
    '機　能：ﾛｯﾄ停止/保留選択処理
    '引　数：Index：ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 11:36:37 N.Kasai
    '更新日：2004/05/28 (Fri) 11:36:37
    '備　考：
    Private Sub optBunrui_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optBunrui0.Click, optBunrui1.Click, optBunrui2.Click

        Dim Index As Integer 'NSYS 押下オプションボタン種別

        Try
            'NSYS 押下オプションボタン名の最後尾1文字取得
            If IsNumeric(Strings.Right$(sender.Name,1)) Then
                Index = CLng(Strings.Right$(sender.Name,1))
            Else
                Exit Sub
            End If

            '@ﾛｯﾄ状態判定
            Select Case Index
                Case CMlngLotHold
                '@ﾛｯﾄ保留の場合
                    '@保留関連ｺﾝﾄﾛｰﾙを有効
                    Call prvHoldCtlEnabled_Set(True)
                    
                    '@技術担当者ｺﾝﾎﾞの値取得列を技術担当者IDに設定
                    cmbTechMan.ValueCol = CMlngGetValueCol
                    
                Case Else
                '@保留関連ｺﾝﾄﾛｰﾙを無効
                    Call prvHoldCtlEnabled_Set(False)
            End Select

            'NSYS 選択したラジオボタンのみTab移動可能とする
            If optBunrui0.Checked Then
                optBunrui0.TabStop = True
                optBunrui1.TabStop = False
                optBunrui2.TabStop = False
            Else If optBunrui1.Checked Then 
                optBunrui0.TabStop = False
                optBunrui1.TabStop = True
                optBunrui2.TabStop = False
            Else If optBunrui2.Checked Then
                optBunrui0.TabStop = False
                optBunrui1.TabStop = False
                optBunrui2.TabStop = True
            End If
            
            '@確定ﾎﾞﾀﾝの使用可否ﾁｪｯｸ
            Call prvcmdRegist_Chk()
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optBunrui_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtHoldPeriod_Change
    '機　能：保留期限変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/08 (Mon) 20:28:57 N.Kojima
    '更新日：2005/08/08 (Mon) 20:28:57
    '備　考：
    Private Sub txtHoldPeriod_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtHoldPeriod.Change

        Try
            '@確定ﾎﾞﾀﾝの使用可否ﾁｪｯｸ
            Call prvcmdRegist_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtHoldPeriod_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtHoldPeriod_Validate
    '機　能：保留期限入力ﾁｪｯｸ
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/08/08 (Mon) 20:31:40 N.Kojima
    '更新日：2005/08/08 (Mon) 20:31:40
    '備　考：
    '　　　：2005/11/25 (Fri) 15:27:32 S.Deguchi    保留期限上限値を設定
    Private Sub txtHoldPeriod_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtHoldPeriod.Validating

        Dim lstrNowDate     As String       '現在日付(YYYY/MM/DD)
        Dim lstrLimitDate   As String       '期限日付(入力値)(YYYY/MM/DD)
        Dim lstrTremDate    As String       '期限日付(設定値)(YYYY/MM/DD)
        Dim llngInputNum    As Integer      '入力値の退避領域
        
        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@「ﾛｯﾄ保留」のｵﾌﾟｼｮﾝﾎﾞﾀﾝにﾁｪｯｸが付いている場合
            If optBunrui2.Checked = True Then
                '@日付が入力されていない(空欄)、または「0」の場合
                If txtHoldPeriod.Text = vbNullString Or txtHoldPeriod.Text = CPstrZero Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006L)
                    
                    '@"<TRM6LW>$$保留期限が不正です。$設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@保留期限にｾｯﾄﾌｫｰｶｽ
                    e.Cancel = True
                Else
        '@↓2005/11/25 (Fri) 15:31:58 S.Deguchi **************************************************
        '@↓2005/12/14 (Wed) 14:45:58 S.Deguchi 厳密な1ヶ月計算ﾛｼﾞｯｸ：いらないなら削除
                    '@数値か否かのﾁｪｯｸ
                    If IsNumeric(txtHoldPeriod.Text) = True Then
                    '@数値の場合
                        '@入力値のﾌｫｰﾏｯﾄ変更(Long型)
                        llngInputNum = CLng(txtHoldPeriod.Text)

                        '@現在日付の取得
                        lstrNowDate = Format(Now, CPstrDateTimeYMD)

                        '@期限日付(入力値)取得
                        lstrLimitDate = DateAdd("d", llngInputNum, Now())

                        '@期限日付(設定値)
                        lstrTremDate = DateAdd("m", 1, lstrNowDate)

                        '@1ヶ月以上の設定がされている場合
                        If lstrTremDate < lstrLimitDate Then
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000H)

                            '@"保留期限を1ヶ月以上設定することはできません。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            '@保留期限にｾｯﾄﾌｫｰｶｽ
                            e.Cancel = True
                        End If
                    Else
                    '@数値以外の場合
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006L)

                        '@"<TRM6LW>$$保留期限が不正です。$設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@保留期限にｾｯﾄﾌｫｰｶｽ
                        e.Cancel = True
                    End If
        '@↑2005/12/14 (Wed) 14:45:58 S.Deguchi 厳密な1ヶ月計算ﾛｼﾞｯｸ：いらないなら削除
                    
        '            '@30日以上の設定がされている場合
        '            If CLng(txtHoldPeriod.Text) > CMlngHoldTremMax30 Then
        '                '@表示ﾒｯｾｰｼﾞ変換
        '                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000H)
        '
        '                '@"保留期限を1ヶ月以上設定することはできません。"
        '                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxEN0270.Caption, True, 16)
        '
        '                '@保留期限にｾｯﾄﾌｫｰｶｽ
        '                Cancel = True
        '            End If
        '@↑2005/11/25 (Fri) 15:31:58 S.Deguchi **************************************************
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtHoldPeriod_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkDirect_Change
    '機　能：作業指示書№変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/15 (Tue) 17:20:42 H.Wajima
    '更新日：2004/06/15 (Tue) 17:20:42
    '備　考：
    Private Sub txtWorkDirect_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkDirect.Change

        Try
            '@確定ﾎﾞﾀﾝ押下ﾁｪｯｸ
            Call prvcmdRegist_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkDirect_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_Change
    '機　能：ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 11:42:57 N.Kasai
    '更新日：2004/05/28 (Fri) 11:42:57 N.Kasai
    '備　考：
    '　　　：2005/11/22 (Tue) 13:15:34 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change

        Dim llngNowByte As Integer 'ﾊﾞｲﾄ数

        Try
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtWorkMemo.NowByte
            
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
                                     
        '@↓2005/11/25 (Fri) 14:31:15 S.Deguchi **************************************************
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispRow, cmdWorkMemoUp, cmdWorkMemoDown)
        '@↑2005/11/25 (Fri) 14:31:15 S.Deguchi **************************************************
            
            '@確定ﾎﾞﾀﾝ押下ﾁｪｯｸ
            Call prvcmdRegist_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2005/11/25 (Fri) 14:32:58 S.Deguchi **************************************************
    '関数名：txtWorkMemo_KeyUp
    '機　能：ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/11/25 (Fri) 14:31:58 S.Deguchi
    '更新日：2005/11/25 (Fri) 14:31:58
    '備　考：
    Private Sub txtWorkMemo_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtWorkMemo.KeyUp

        Try
            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtWorkMemo, CMlngMaxDispRow, cmdWorkMemoUp, cmdWorkMemoDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_MouseUp
    '機　能：ﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/25 (Fri) 14:32:13 S.Deguchi
    '更新日：2005/11/25 (Fri) 14:32:13
    '備　考：
    Private Sub txtWorkMemo_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtWorkMemo.MouseUp

        Try
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispRow, cmdWorkMemoUp, cmdWorkMemoDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2005/11/25 (Fri) 14:32:58 S.Deguchi **************************************************

    '関数名：cmdWorkMemoUp_Click
    '機　能：作業ﾒﾓ▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/16 (Fri) 09:20:24 Y.Yamagishi
    '更新日：2004/07/16 (Fri) 09:20:24
    '備　考：
    '　　　：2005/11/22 (Tue) 13:15:34 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdWorkMemoUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWorkMemoUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/11/25 (Fri) 14:29:03 S.Deguchi **************************************************
        '    '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtWorkMemo)
        '
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispRow, cmdWorkMemoUp, cmdWorkMemoDown)
        '@↑2005/11/25 (Fri) 14:29:03 S.Deguchi **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWorkMemoUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWorkMemoDown_Click
    '機　能：作業ﾒﾓ▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/16 (Fri) 09:20:29 Y.Yamagishi
    '更新日：2004/07/16 (Fri) 09:20:29
    '備　考：
    '　　　：2005/11/22 (Tue) 13:15:34 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdWorkMemoDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWorkMemoDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/11/25 (Fri) 14:29:46 S.Deguchi **************************************************
        '    '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtWorkMemo)
        '
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispRow, cmdWorkMemoUp, cmdWorkMemoDown)
        '@↑2005/11/25 (Fri) 14:29:46 S.Deguchi **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWorkMemoDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtHoldComments_Change
    '機　能：保留ｺﾒﾝtﾉ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/09 (Thu) 14:27:58 M.Miura
    '更新日：2004/09/09 (Thu) 14:27:58
    '備　考：
    '　　　：2005/11/22 (Tue) 13:15:34 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    '　　　：2005/12/16 (Fri) 11:00:19 S.Deguchi    保留ｺﾒﾝﾄの文字制限変更
    '　　　：2005/12/20 (Tue) 11:00:19 S.Deguchi    保留ｺﾒﾝﾄの文字制限変更ﾊﾟｰﾄ2
    Private Sub txtHoldComments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtHoldComments.Change

        Dim llngNowByte As Integer 'ﾊﾞｲﾄ数

        Try
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtHoldComments.NowByte
            
        '@↓2005/12/20 (Tue) 09:05:20 S.Deguchi **************************************************
        '@↓2005/12/16 (Fri) 11:01:08 S.Deguchi **************************************************
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
        ''    lblHoldLengthCount.Caption = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngHoldCommentsMaxByte)
        '    lblHoldLengthCount.Caption = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngMailContentsMaxByteConnect)
            lblHoldLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CMlngHoldComments900)
        '@↑2005/12/16 (Fri) 11:01:08 S.Deguchi **************************************************
        '@↑2005/12/20 (Tue) 09:05:20 S.Deguchi **************************************************
                                     
        '@↓2005/11/25 (Fri) 14:31:15 S.Deguchi **************************************************
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtHoldComments, CMlngMaxDispRow, cmdHoldUp, cmdHoldDown)
        '@↑2005/11/25 (Fri) 14:31:15 S.Deguchi **************************************************
            
            '@確定ﾎﾞﾀﾝ押下ﾁｪｯｸ
            Call prvcmdRegist_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtHoldComments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2005/11/25 (Fri) 14:32:58 S.Deguchi **************************************************
    '関数名：txtHoldComments_KeyUp
    '機　能：ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/11/25 (Fri) 14:31:58 S.Deguchi
    '更新日：2005/11/25 (Fri) 14:31:58
    '備　考：
    Private Sub txtHoldComments_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtHoldComments.KeyUp

        Try
            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtHoldComments, CMlngMaxDispRow, cmdHoldUp, cmdHoldDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtHoldComments_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtHoldComments_MouseUp
    '機　能：ﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/25 (Fri) 14:32:13 S.Deguchi
    '更新日：2005/11/25 (Fri) 14:32:13
    '備　考：
    Private Sub txtHoldComments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtHoldComments.MouseUp

        Try
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtHoldComments, CMlngMaxDispRow, cmdHoldUp, cmdHoldDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtHoldComments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2005/11/25 (Fri) 14:32:58 S.Deguchi **************************************************

    '関数名：cmdHoldUp_Click
    '機　能：作業ﾒﾓ▲ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/09 (Thu) 14:28:13 M.Miura
    '更新日：2004/09/09 (Thu) 14:28:13
    '備　考：
    '　　　：2005/11/22 (Tue) 13:15:34 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdHoldUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdHoldUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/11/25 (Fri) 14:45:24 S.Deguchi **************************************************
        '    '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtHoldComments)
        '
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtHoldComments, CMlngMaxDispRow, cmdHoldUp, cmdHoldDown)
        '@↑2005/11/25 (Fri) 14:45:24 S.Deguchi **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdHoldUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdHoldDown_Click
    '機　能：作業ﾒﾓ▼ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/09 (Thu) 14:30:03 M.Miura
    '更新日：2004/09/09 (Thu) 14:30:03
    '備　考：
    '　　　：2005/11/22 (Tue) 13:15:34 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdHoldDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdHoldDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/11/25 (Fri) 14:46:01 S.Deguchi **************************************************
        '    '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtHoldComments)
        '
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtHoldComments, CMlngMaxDispRow, cmdHoldUp, cmdHoldDown)
        '@↑2005/11/25 (Fri) 14:46:01 S.Deguchi **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdHoldDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：vsfUseInfo_AfterSort
    '機　能：ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/06/15 (Tue) 17:42:12 H.Wajima
    '更新日：2004/06/15 (Tue) 17:42:12
    '備　考：
    Private Sub vsfUseInfo_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfUseInfo.AfterSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfUseInfo.Rows.Count <= vsfUseInfo.Rows.Fixed Then
                Return
            End If

            '@ｶﾚﾝﾄ行の設定(ｸﾞﾘｯﾄﾞ,保持列 [ ﾛｯﾄID ] )
            Call pubVsfAfterSort(vsfUseInfo, _
                                 CMlngLotPrestateColNo & _
                                 vbTab & _
                                 CMlngLotPrestateColOpID & _
                                 vbTab & _
                                 CMlngLotPrestateColStepID)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfUseInfo_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfUseInfo_BeforeSort
    '機　能：ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/06/15 (Tue) 17:38:59 H.Wajima
    '更新日：2004/06/15 (Tue) 17:38:59
    '備　考：
    Private Sub vsfUseInfo_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfUseInfo.BeforeSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfUseInfo.Rows.Count <= vsfUseInfo.Rows.Fixed Then
                Return
            End If

            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ,保持列 [ ﾛｯﾄID ] )
            Call pubVsfBeforeSort(vsfUseInfo, _
                                  CMlngLotPrestateColNo & _
                                  vbTab & _
                                  CMlngLotPrestateColOpID & _
                                  vbTab & _
                                  CMlngLotPrestateColStepID)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfUseInfo_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfUseInfo_EnterCell
    '機　能：工程選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 12:36:21 N.Kasai
    '更新日：2004/11/05 (Fri) 15:03:34 M.Miura
    '備　考：2004/10/25 (Mon) 08:44:53 S.Deguchi 特殊工程が存在した場合のﾎﾞﾀﾝ制御を追加
    '　　　：2004/11/05 (Fri) 15:03:34 M.Miura　 ｱｸｼｮﾝﾄﾘｶﾞｰ設定を追加
    Private Sub vsfUseInfo_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfUseInfo.EnterCell
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfUseInfo.Rows.Count <= vsfUseInfo.Rows.Fixed Then
                Return
            End If

            With vsfUseInfo
                '@使用不可の場合は走行しない。
                If .Enabled = False Then
                    Exit Sub
                End If

                '@ｸﾞﾘｯﾄﾞの選択状態の判定
                Select Case .Row
                    Case -1
                    '@未選択の場合
                        Call prvControlEnabled_Init(False, False, False)
                        
                    Case 0 To .Rows.Fixed - 1
                    '@ﾀｲﾄﾙ行の場合
                        '@ｱｸｼｮﾝﾄﾘｶﾞｰを無効に設定
                        optTrigger0.Enabled = False
                        optTrigger0.Checked = False
                        optTrigger0.TabStop = False
                        optTrigger1.Enabled = False
                        optTrigger1.Checked = False
                        optTrigger1.TabStop = False
                        
                        Exit Sub
                        
                    Case Else
                    '@その他
                        '@ｱｸｼｮﾝﾄﾘｶﾞｰを有効に設定
                        optTrigger0.Enabled = True
                        optTrigger0.Checked = False
                        optTrigger0.TabStop = True
                        optTrigger1.Enabled = True
                        optTrigger1.Checked = False
                        optTrigger1.TabStop = True
                            
                        '@有効行の場合
                        Call prvControlEnabled_Init(False, True, False)
                        
                        '@代替列に「○」がある(代替工程がある)場合
                        If .GetData(.Row, CMlngLotPrestateColAltStep) = CMstrMaru Then
                            '@代替表示ﾎﾞﾀﾝを有効
                            cmdAlt.Enabled = True
                        Else
                            '@代替表示ﾎﾞﾀﾝを無効
                            cmdAlt.Enabled = False
                        End If
                        
                        '@ﾘﾜｰｸ列に「○」がある(ﾘﾜｰｸ工程がある)場合
                        If .GetData(.Row, CMlngLotPrestateColReworkStep) = CMstrMaru Then
                            '@ﾘﾜｰｸ表示ﾎﾞﾀﾝを有効(但し,ｱｸｼｮﾝ予約ﾀｲﾌﾟがﾛｯﾄの場合はﾘﾜｰｸ設定は行わない)
                            If optYoyaku0.Checked = True Then
                                cmdRework.Enabled = False
                            Else
                                cmdRework.Enabled = True
                            End If
                        Else
                            '@ﾘﾜｰｸ表示ﾎﾞﾀﾝを無効
                            cmdRework.Enabled = False
                        End If
                        
                        '@特殊工程列に「追」がある(特殊工程がある)場合
                        If .GetData(.Row, CMlngLotPrestateColSpecialStep) = CMstrTsuika _
                            Or .GetData(.Row, CMlngLotPrestateColSpecialStep) = CMstrSaki Then
                            '@特殊流動表示ﾎﾞﾀﾝを有効
                            cmdSpecial.Enabled = True
                        Else
                            '@特殊流動表示ﾎﾞﾀﾝを無効
                            cmdSpecial.Enabled = False
                        End If
                        
        '@↓2012/11/06 (Tue) 18:23:53 T.Oide **************************************************
                        '@WFｱｸｼｮﾝ設定以外の行の場合(大工程が"ウェハー指定")
                        If .GetData(.Row, CMlngLotPrestateColOpID) <> CMstrWFSiteiOp Then
                                                
                            '@ｳｪﾊｰｱｸｼｮﾝ予約初期化
                            Call prvEditDataInit()
                        End If
        '@↑2012/11/06 (Tue) 18:23:53 T.Oide **************************************************
                        
                End Select
            End With

        '@↓2012/11/06 (Tue) 19:13:26 T.Oide **************************************************
            '@WF指定設定ﾎﾞﾀﾝﾁｪｯｸ
            Call prvcmdWFAction_Chk()
        '@↑2012/11/06 (Tue) 19:13:26 T.Oide **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfUseInfo_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '****************************************************************************************
    '                              　　    *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '関数名：prvfrmxxEN0270_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/26 (Wed) 10:16:58 N.Kasai
    '更新日：2012/10/25 (Thu) 09:38:46 T.Oide
    '備　考：
    '　　　：2004/10/04 (Mon) 14:58:15 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2004/12/08 (Wed) 13:00:37 N.Kasai      保留期限ｶﾚﾝﾀﾞｰの初期化追加
    '　　　：2005/08/10 (Wed) 09:31:38 N.Kojima     保留期限の初期化処理追加。(不具合№2985)
    '　　　：2005/12/16 (Fri) 10:56:45 S.Deguchi    保留ｺﾒﾝﾄの文字制限を1500Byteへ変更
    '　　　：2005/12/20 (Tue) 09:04:09 S.Deguchi    保留ｺﾒﾝﾄの文字制限を900Byteへ変更
    '　　　：2012/10/25 (Thu) 09:38:46 T.Oide       R9-05(Chip誤送品対応)
    Private Sub prvfrmxxEN0270_Init()
        
        Dim lstrFormTitle       As String               'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0270, lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            vsfUseInfo.Enabled = False
            
            '@工程を初期化
            lblStepType.Text = vbNullString
            
            '@各ｺﾝﾄﾛｰﾙの初期化
            '@機種
            With cmbProduct
                .Clear
                .Enabled = False
                .DirectInput = False
                .DispCols = 1
                .GetCol = 0
                .ColAlignment(.GetCol) = TextAlignEnum.LeftCenter
                .Font = New Font(CMstrCmbFontName, CMlngCmbFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                .GridFont = New Font(CMstrCmbFontName, CMlngCmbGridFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                .BackColor = SystemColors.Window
            End With
            
            '@初期化
            mstrEditTime = vbNullString     '最終更新日時
            mstrEntryID = vbNullString      'ｴﾝﾄﾘ
        '@↓2012/11/06 (Tue) 15:23:02 T.Oide **************************************************
            pstrWfActionFlag = vbNullString 'ｳｪﾊｰｱｸｼｮﾝﾌﾗｸﾞ
        '@↑2012/11/06 (Tue) 15:23:02 T.Oide **************************************************
            
            '@ﾛｯﾄ
            txtLotID.Enabled = False
            
            '@装置
            With cmbWpID
                .Clear
                .Enabled = False
                .DirectInput = False
                .DispCols = 1
                .GetCol = 0
                .ColAlignment(.GetCol) = TextAlignEnum.LeftCenter
                .Font = New Font(CMstrCmbFontName, CMlngCmbFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                .GridFont = New Font(CMstrCmbFontName, CMlngCmbGridFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                .BackColor = SystemColors.Window
            End With
            
            '@特定工程
            With cmbProcessinfo
                .Clear
                .Enabled = False
                .DirectInput = False
                .DispCols = 1
                .GetCol = 0
                .ColAlignment(.GetCol) = TextAlignEnum.LeftCenter
                .Font = New Font(CMstrCmbFontName, CMlngCmbFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                .GridFont = New Font(CMstrCmbFontName, CMlngCmbGridFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                .BackColor = SystemColors.Window
            End With
            
            '@作業指示書№
            With txtWorkDirect
                .ChrMaxByte = CMlngtxtWorkDirect
            End With
            
            '@保留要因
             With cmbMasHold
                .Clear
                .Enabled = False
                .DirectInput = False
                .DispCols = 1
                .GetCol = 0
                .ColAlignment(.GetCol) = TextAlignEnum.LeftCenter
                .Font = New Font(CMstrCmbFontName, CMlngCmbFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                .GridFont = New Font(CMstrCmbFontName, CMlngCmbGridFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                .BackColor = SystemColors.Window
            End With
            
            '@技術担当者
             With cmbTechMan
                .Clear
                .Enabled = False
                .DirectInput = False
                .DispCols = 1
                .GetCol = 0
                .ColAlignment(.GetCol) = TextAlignEnum.LeftCenter
                .Font = New Font(CMstrCmbFontName, CMlngCmbFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                .GridFont = New Font(CMstrCmbFontName, CMlngCmbGridFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                .BackColor = SystemColors.Window
            End With
            
            '@工程表示ｸﾞﾘｯﾄの初期化
            Call prvvsfUseInfo_Init()
            
            '@開始日付の初期化
            With calFromDate
                .CalendarHeight = CPlngMClHeight                    '高さ
                .CalendarWidth = CPlngMClWidth                      '幅
                .DayFont = New Font(.Font.FontFamily, CPlngMClFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)    'ﾌｫﾝﾄｻｲｽﾞ
                .TitleFont = New Font(.TitleFont.FontFamily, Ctype(CPlngMClTlFontSize, Single), .TitleFont.Style)                           'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CType(CPlngMClGridFontSize, Single), .GridFont.Style)                            'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .BackColor = SystemColors.Window
            End With
            
            '@開始日付の初期化
            With calToDate
        '@↓2014/06/12 (Thu) 17:52:38 Y.Yoneyama **************************************************
                .Visible = False
        '@↑2014/06/12 (Thu) 17:52:38 Y.Yoneyama **************************************************
                .CalendarHeight = CPlngMClHeight                    '高さ
                .CalendarWidth = CPlngMClWidth                      '幅
                .DayFont = New Font(.Font.FontFamily, CPlngMClFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)    'ﾌｫﾝﾄｻｲｽﾞ
                .TitleFont = New Font(.TitleFont.FontFamily, Ctype(CPlngMClTlFontSize, Single), .TitleFont.Style)                           'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CType(CPlngMClGridFontSize, Single), .GridFont.Style)                            'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .BackColor = SystemColors.Window
            End With
            
            '@保留期限の初期化
            txtHoldPeriod.Text = vbNullString
            
            '@現在の作業ﾒﾓのﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                          CMlngLotCommentsDefault, _
                                                          CPlngLotCommentsMaxByte)
            
            With txtWorkMemo
                .ChrMaxByte = CPlngLotCommentsMaxByte               'ﾒｯｾｰｼﾞ桁数
                .Text = vbNullString                                'ﾒｯｾｰｼﾞ表示
            End With
            txtWorkDirect.Text = vbNullString                       '作業指示書№
            
            '@現在の保留ｺﾒﾝﾄのﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblHoldLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                              CMlngLotCommentsDefault, _
                                                              CMlngHoldComments900)
            
            '@保留ｺﾒﾝﾄ初期化
            With txtHoldComments
                .ChrMaxByte = CMlngHoldComments900                  'ﾒｯｾｰｼﾞ桁数(900)
                .Text = vbNullString                                'ﾒｯｾｰｼﾞ表示
            End With
            
            '@ｽﾃｰﾀｽ登録部分を使用不可に設定
            Call prvControlEnabled_Init()
            
            '@ｽﾃｰﾀｽﾌｫｰﾑへ送るﾒｯｾｰｼﾞの初期化
            mstrInfoMsg = vbNullString                              'ｽﾃｰﾀｽﾌｫｰﾑへ送るﾒｯｾｰｼﾞ
            
            '@ﾛｯﾄｱｸｼｮﾝ予約IDを初期化
            mstrLotActionID = vbNullString
            
            '@技術担当者ID/名の初期化
            mstrTechManID = vbNullString
            mstrTechManName = vbNullString
            
            '@保留期限初期化
            mstrHoldTermDate = vbNullString
            
            '@ｱｸｼｮﾝ予約対象の選択状態
            optYoyaku0.Checked = True
            Call optYoyaku_Click(optYoyaku0,New EventArgs()) 'NSYS Checkedの代入でClickイベント発生しないため手動実行
            
            '@最新取得ﾎﾞﾀﾝﾛｯｸ
            cmdNowList.Enabled = False
            
            '@ﾃﾞﾌｫﾙﾄﾎﾞﾀﾝﾛｯｸ
            cmdDefult.Enabled = False
            
        '@↓2012/10/25 (Thu) 09:38:38 T.Oide **************************************************
            pblnEN0271EditFlag = False
        '@↑2012/10/25 (Thu) 09:38:38 T.Oide **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN0270_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvControlEnabled_Init
    '機　能：各ｺﾝﾄﾛｰﾙの初期設定
    '引　数：lblnEnable             ：True:使用可能,False:使用不可
    '　　　：lblTriggerflg          ：True:使用可能,False:使用不可
    '　　　：lblnStepTypeChangeFlg  ：True:工程選択を変更する,False:工程選択を変更しない
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 15:00:44 H.Wajima
    '更新日：2008/06/12 (Thu) 11:17:08 N.Kojima
    '備　考：
    '　　　：2005/01/06 (Thu) 17:22:45 N.Kasai      構造体ｸﾘｱを追加(ptypWpuseinfo)
    '　　　：2005/08/08 (Mon) 20:38:17 N.Kojima     保留期限の有効無効制御処理追加。(不具合№2985)
    Private Sub prvControlEnabled_Init(Optional ByVal lblnEnable As Boolean = False, _
                                       Optional ByVal lblnTriggerflg As Boolean = False, _
                                       Optional ByVal lblnStepTypeChangeFlg As Boolean = True)
        
        Dim lblnStepTypeFlg     As Boolean  '工程選択ﾌﾗｸﾞ

        Try
            
            '@構造体のｸﾘｱ
            ptypWpuseinfo = New List(Of Wpuseinfo)
            
            '@各ｺﾝﾄﾛｰﾙの設定
            '@工程選択変更ﾌﾗｸﾞの確認
            If lblnStepTypeChangeFlg = True Then
                '@工程選択
                If lblnTriggerflg = True Then
                    '@ｺﾝﾄﾛｰﾙ使用可能の場合
                    '@工程選択ﾌﾗｸﾞの初期化
                    lblnStepTypeFlg = True
                    '@ｱｸｼｮﾝ予約ﾀｲﾌﾟの判定
                    If optYoyaku0.Checked = True Then
                        '@ﾛｯﾄの場合
                        '@工程選択ﾌﾗｸﾞにTrueを設定する
                        lblnStepTypeFlg = True
                    End If
                    If optYoyaku1.Checked = True Then
                        '@機種の場合
                        '@工程選択ﾌﾗｸﾞにTrueを設定する
                        lblnStepTypeFlg = True
                    End If
                    If optYoyaku2.Checked = True Then
                        '@装置の場合
                        '@工程選択ﾌﾗｸﾞにFalseを設定する
                        lblnStepTypeFlg = False
                    End If
                    If optYoyaku3.Checked = True Then
                        '@工程の場合
                        '@工程選択ﾌﾗｸﾞにFalseを設定する
                        lblnStepTypeFlg = False
                    End If
                End If
            End If
            
            '@ｱｸｼｮﾝ予約ﾄﾘｶﾞｰﾌﾗｸﾞ使用不可の場合
            If lblnTriggerflg = False Then
                With optTrigger0
                    .Enabled = lblnTriggerflg                                   'ｱｸｼｮﾝﾄﾘｶﾞｰ(作業開始)
                    .Checked = False
                    .TabStop = lblnTriggerflg
                End With
                With optTrigger1
                    .Enabled = lblnTriggerflg                                   'ｱｸｼｮﾝﾄﾘｶﾞｰ(作業終了)
                    .Checked = False
                    .TabStop = lblnTriggerflg
                End With
            End If
            
            calFromDate.Enabled = lblnEnable                                    '開始日付
            calToDate.Enabled = lblnEnable                                      '終了日付
            If lblnEnable = False Then
                '@使用不可の場合
                calFromDate.Value = vbNullString                                '開始日付
                calToDate.Value = vbNullString                                  '終了日付
            End If
            
            '@停止解除機能が未開発の為,停止ｵﾌﾟｼｮﾅﾙﾎﾞﾀﾝを無効化(後で削除)
            optBunrui1.Enabled = False                                          'ﾛｯﾄ状態(ﾛｯﾄ停止)
            optBunrui2.Enabled = lblnEnable                                     'ﾛｯﾄ状態(ﾛｯﾄ保留)
            optBunrui0.Enabled = lblnEnable                                     'ﾛｯﾄ状態(指定なし)
            txtWorkMemo.Enabled = lblnEnable                                    'ﾒｯｾｰｼﾞ表示
            cmdWorkMemoUp.Enabled = lblnEnable                                  'ﾒｯｾｰｼﾞ表示上ﾎﾞﾀﾝ
            cmdWorkMemoDown.Enabled = lblnEnable                                'ﾒｯｾｰｼﾞ表示下ﾎﾞﾀﾝ
            txtHoldComments.Enabled = lblnEnable                                '保留ｺﾒﾝﾄ
            cmdHoldUp.Enabled = lblnEnable                                      '保留ｺﾒﾝﾄﾎﾞﾀﾝ上
            cmdHoldDown.Enabled = lblnEnable                                    '保留ｺﾒﾝﾄﾎﾞﾀﾝ下
            txtHoldPeriod.Enabled = lblnEnable                                  '保留期限
            txtWorkDirect.Enabled = lblnEnable                                  '作業指示書№
            cmbMasHold.Enabled = lblnEnable                                     '保留要因
            cmbTechMan.Enabled = lblnEnable                                     '技術担当者
        '@↓2012/10/24 (Wed) 13:30:56 T.Oide **************************************************
            cmdWFAction.Enabled = lblnEnable                                    'WF指定設定ﾎﾞﾀﾝ
        '@↑2012/10/24 (Wed) 13:30:56 T.Oide **************************************************
            cmdDelete.Enabled = lblnEnable                                      '削除ﾎﾞﾀﾝ
            cmdRegist.Enabled = lblnEnable                                      '確定ﾎﾞﾀﾝ
            
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                          CMlngLotCommentsDefault, _
                                                          CPlngLotCommentsMaxByte)
            
            txtWorkMemo.Text = vbNullString                                     'ﾒｯｾｰｼﾞ表示
            txtWorkDirect.Text = vbNullString                                   '作業指示書№
            
            '@停止/保留
            optBunrui1.Checked = False                                          '停止/保留なし
            optBunrui2.Checked = False                                          '停止
            optBunrui0.Checked = False                                          '保留
            
            '@保留要因
             With cmbMasHold
                .Enabled = False
                RemoveHandler cmbMasHold.Change,AddressOf cmbMasHold_Change
                .ListIndex = -1
                AddHandler cmbMasHold.Change,AddressOf cmbMasHold_Change
            End With
            
            '@技術担当者
            With cmbTechMan
                .Enabled = False
                RemoveHandler cmbTechMan.Change,AddressOf cmbTechMan_Change
                .ListIndex = -1
                AddHandler cmbTechMan.Change,AddressOf cmbTechMan_Change
            End With
            
            txtHoldPeriod.Text = vbNullString                                   '保留期限

            txtHoldComments.Text = vbNullString                                 '保留ｺﾒﾝﾄ
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvControlEnabled_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN0270_Disp
    '機　能：画面の表示
    '引　数：ltypLotActioninfo：ｱｸｼｮﾝ予約検索内容格構造体
    '戻り値：なし
    '作成日：2004/05/27 (Thu) 17:13:26 N.Kasai
    '更新日：2012/11/07 (Wed) 14:44:54 T.Oide
    '備　考：
    '　　　：2005/04/01 (Fri) 11:19:17 S.Deguchi    不具合№680対応でﾛｯﾄ指定のとき,ﾒｯｾｰｼﾞで帰ってきている情報を更新(開始日をNull)
    '　　　：2005/08/10 (Wed) 09:26:42 N.Kojima     機種指定の場合の処理追加、保留期限の入力方式変更に伴う修正。(不具合№2985)
    '　　　：2006/10/16 (Mon) 15:51:39 M.Miura      ﾀﾞﾐｰの有効期限をなしに修正(案件№01573)
    '　　　：：2012/11/07 (Wed) 14:44:54 T.Oide     Chip誤送品対応
    Private Sub prvfrmxxEN0270_Disp(ByRef ptypLotActioninfo As LotActioninfo)
        
        Dim llngCnt                     As Integer      '汎用ｶｳﾝﾀ
        Dim llngBunrui                  As Integer      '停止/保留
        Dim lblnHoldReason              As Boolean      '保留理由ﾌﾗｸﾞ
        Dim lstrHoldReasonID            As String       '保留理由ID
        Dim lblnTechManMatchFlag        As Boolean      '同一技術担当者存在判定ﾌﾗｸﾞ(True：存在する、False：存在しない)

        Try
            
            With ptypLotActioninfo
            
        '@↓2012/11/07 (Wed) 14:45:33 T.Oide **************************************************
        '@        '@ﾛｯﾄ指定の場合には開始日にNullをｾｯﾄする
        '@        If optYoyaku(CMlngActionIndexLot).Value = True Then
        '@--------------------------------------------------------------------------------------
                '@ﾛｯﾄ指定、装置指定で終了日が入っていない場合、開始日にNullをｾｯﾄする
                '@ﾛｯﾄ指定は通常終了日がDB上は行っていない。装置指定の場合はWF指定ｱｸｼｮﾝ予約の場合終了日が入っていない
                If optYoyaku0.Checked = True Or _
                   optYoyaku2.Checked = True Then
                   
        '@↑2012/11/07 (Wed) 14:45:33 T.Oide **************************************************
                
                    '@運用終了日時がNullの場合
                    If .strEndTime = vbNullString Then
                        '@運用開始日時にNullをｾｯﾄ
                        .strStartTime = vbNullString
                    End If
                Else
                    '@機種指定の場合で"Monitor"or"Quality"の場合も開始日にNULLをｾｯﾄする
                    If optYoyaku1.Checked = True Then
                    
                        '@1番目の値を参照(用途:USE_ID)
                        cmbProduct.ValueCol = CMlngCmbGridColID
                        
                        '@USE_IDが"Monitor"(ﾓﾆﾀ),"Quality"(品確),"Dummy"(ﾀﾞﾐｰ)の場合
                        If cmbProduct.Value = CPstrMonitor Or _
                            cmbProduct.Value = CPstrQuality Or _
                            cmbProduct.Value = CPstrPdDummy Then
                            
                            '@運用終了日時がNullの場合
                            If .strEndTime = vbNullString Then
                                '@運用開始日時にNullをｾｯﾄ
                                .strStartTime = vbNullString
                            End If
                        End If
                        
                        '@0番目の値を参照するように戻す(用途:USE_ID)
                        cmbProduct.ValueCol = CMlngCmbGridColName
                    End If
                End If
                
                '@ﾛｯﾄｱｸｼｮﾝ予約ID退避
                mstrLotActionID = .strLotActionID
                        
                '@運用開始日時
                If .strStartTime = vbNullString Then
                    '@運用開始日付が空白の場合
                    
                    '@初期値日付を設定する
                    calFromDate.Value = vbNullString 'Format$(Date, CPstrDateTimeYMD)
                Else
                    '@空白以外の場合
                    
                    '@取得日付を設定する
                    calFromDate.Value = .strStartTime
                End If
                
                '@運用終了日時
                If .strEndTime = vbNullString Then
                    '@運用終了日付が空白の場合
                    
                    '@初期値日付を設定する
                    calToDate.Value = vbNullString
                Else
                    '@空白以外の場合
                    
                    '@取得日付を設定する
                    calToDate.Value = .strEndTime
                End If
                    
                    
                '@同一技術担当者存在判定ﾌﾗｸﾞを初期化する
                lblnTechManMatchFlag = False
                
                '@技術担当者ﾘｽﾄが1件以上存在するか
                If mlngTechManListCnt > 0 Then
                
                    For llngCnt = 0 To mtypTechManList.Count - 1
                    
                        '@技術担当者ｺﾝﾎﾞの技術担当者IDとｱｸｼｮﾝ予約情報の技術担当者IDが同じか
                        If mtypTechManList(llngCnt).strTechManID = .strEngEmpId Then
                        
                            '@同一技術担当者存在判定ﾌﾗｸﾞに"True：存在する"をｾｯﾄ
                            lblnTechManMatchFlag = True
                            Exit For
                        End If
                    Next llngCnt
                End If
                
                '@技術担当者
                With cmbTechMan
                
                    '@同一技術担当者存在判定ﾌﾗｸﾞが"True：存在する"か
                    If lblnTechManMatchFlag = True Then
                        '@技術担当者を表示
                        .ListIndex = llngCnt
                    Else
                        '@技術担当者を表示しない
                        RemoveHandler cmbTechMan.Change,AddressOf cmbTechMan_Change
                        .ListIndex = -1
                        AddHandler cmbTechMan.Change,AddressOf cmbTechMan_Change
                    End If
                End With
                
                
                '@ｱｸｼｮﾝ分類取得
                txtWorkMemo.Text = .strMessage                      'ｱｸｼｮﾝﾒｯｾｰｼﾞ
                txtWorkDirect.Text = .strWorkDirectionID            '作業指示書№
                
                '@ﾛｯﾄ停止/保留取得
                llngBunrui = CLng(.strStopHoldFlag)                 'ﾛｯﾄ停止/保留
                Select Case llngBunrui
                    Case CMlngLotNotSpecify
                    '@保留/停止なし
                        optBunrui0.Checked = True
                        Call optBunrui_Click(optBunrui0,New EventArgs()) 'NSYS Checkedの代入でClickイベントが自動実行されないため手動実行
                        
                    Case CMlngLotStop
                    '@停止
                    
                    Case CMlngLotHold
                    '@保留
                        optBunrui2.Checked = True
                        Call optBunrui_Click(optBunrui2,New EventArgs()) 'NSYS Checkedの代入でClickイベントが自動実行されないため手動実行
                End Select
                
                '@保留停止時のみｺﾝﾎﾞ設定を行う
                 If llngBunrui = CMlngLotHold Then
                    '@保留情報取得
                    lblnHoldReason = False                          'ﾌﾗｸﾞ初期化
                    lstrHoldReasonID = .strHoldReasonID             '保留理由ID
                    For llngCnt = 0 To mtypMasItemList.lngListCnt - 1
                        If mtypMasItemList.typeMasItem(llngCnt).strItemID = lstrHoldReasonID Then
                            '@保留理由IDが一致した場合
                            lblnHoldReason = True
                            Exit For
                        End If
                    Next llngCnt
                    
                    With cmbMasHold
                        If lblnHoldReason = True Then
                            '@保留理由表示
                            .ListIndex = llngCnt
                        Else
                            RemoveHandler cmbMasHold.Change,AddressOf cmbMasHold_Change
                            .ListIndex = -1
                            AddHandler cmbMasHold.Change,AddressOf cmbMasHold_Change
                        End If
                    End With
                    
                    '@保留期限(ﾃﾞﾌｫﾙﾄをｾｯﾄ)
                    txtHoldPeriod.Text = .strHoldPeriod
                    
                    '@保留ｺﾒﾝﾄ
                    txtHoldComments.Text = .strHoldComments
                    
                End If
            End With
            
            '@削除ﾎﾞﾀﾝを押下可能にする
            cmdDelete.Enabled = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN0270_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfUseInfo_Init
    '機　能：現工程表示ｸﾞﾘｯﾄの初期化
    '引　数：lblnArayInitFlg：構造体初期化ﾌﾗｸﾞ(True:構造体を初期化する,False:構造体を初期化しない(ﾃﾞﾌｫﾙﾄ))
    '戻り値：なし
    '作成日：2004/05/17 (Mon) 14:42:21 H.Wajima
    '更新日：2004/10/27 (Wed) 10:47:00 M.Miura
    '備　考：
    '　　　：2004/10/22 (Fri) 13:26:52 S.Deguchi 特殊工程対応で列追加
    '　　　：2004/10/27 (Wed) 10:47:00 M.Miura　ｿｰﾄ設定をｿｰﾄなしに変更(流動票では不要な為)
    Private Sub prvvsfUseInfo_Init(ByRef Optional lblnArayInitFlg As Boolean = True)
            
        Dim llngCnt             As Integer      '汎用ｶｳﾝﾀ

        Try
            
            '@構造体初期化ﾌﾗｸﾞの判定
            If lblnArayInitFlg = True Then
                '@構造体初期化
                'Erase mtypStepTypeGrid
                'ReDim mtypStepTypeGrid(CMlngStepFlg0 To CMlngStepFlg2)
                mtypStepTypeGrid = New List(Of StepTypeGrid)
                For llngCnt = CMlngStepFlg0 To CMlngStepFlg2

                    'NSYS 編集用構造体初期化
                    Dim mtypStepTypeGridTmp As StepTypeGrid

                    With mtypStepTypeGridTmp
                        .blnMessageReadFlg = False
                        .lngDataCount = 0
                        .strReadTime = vbNullString
                        .typStepTypeList = New List(Of StepTypeList)
                    End With

                    'NSYS 編集済み構造体追加
                    mtypStepTypeGrid.Add(mtypStepTypeGridTmp)

                Next llngCnt
            End If
            
            '@ｱｸｼｮﾝﾄﾘｶﾞｰの初期化
            With optTrigger0
                .Checked = False
                .Enabled = False
                .TabStop = False
            End With
            With optTrigger1
                .Checked = False
                .Enabled = False
                .TabStop = False
            End With
            
            With vsfUseInfo
                '@ﾌﾟﾛﾊﾟﾃｨ初期値
                .Clear
                RemoveHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                .Cols.Count = CMlngLotPrestateColActFlg + 1
                .Rows.Count = CMlngGridFixedRows
                .Cols.Fixed = CMlngGridFixedCols
                .Rows.Fixed = CMlngGridFixedRows
                AddHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                .SelectionMode = SelectionModeEnum.Row
                '.FillStyle = flexFillRepeat
                .FocusRect = FocusRectEnum.Light
                .HighLight = HighLightEnum.Always
                .Font = New Font(CMstrGridFontName, CMlngGridFontSize, .Font.Style, .Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)
                .ScrollBars = ScrollBars.Vertical
                .Width = CMlngGridWidth
                .Height = CMlngGridHeight
                '.AllowSelection = False
                .ExtendLastCol = True
                '.ExplorerBar = flexExNone
                .Cols(CMlngLotPrestateColNo).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngLotPrestateColOpID).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngLotPrestateColStepID).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngLotPrestateColActStepInfo).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngLotPrestateColAltStep).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngLotPrestateColReworkStep).TextAlign = TextAlignEnum.LeftCenter
                
                '@ｸﾞﾘｯﾄﾞの表題設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_vsfUseInfo_Header")
                Dim cellRange As CellRange = .GetCellRange(CMlngGridRowTitle, CMlngLotPrestateColNo, CMlngGridRowTitle, .Cols.Count - 1)
                newStyle.ForeColor = Color.Yellow                             '文字色
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)'背景色
                newStyle.Font = New Font(.Font.FontFamily, CMlngGridFontSize, .Font.Style, .Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                newStyle.TextAlign = TextAlignEnum.CenterCenter               '文字位置
                cellRange.Style = newStyle
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngGridRowTitle, CMlngLotPrestateColNo, CMstrLotPrestateColTNo)                    '№
                .SetData(CMlngGridRowTitle, CMlngLotPrestateColAltNumber, CMstrLotPrestateColTAltNumber)      '代替番号
                .SetData(CMlngGridRowTitle, CMlngLotPrestateColOpID, CMstrLotPrestateColTOpID)                '大工程ID
                .SetData(CMlngGridRowTitle, CMlngLotPrestateColStepID, CMstrLotPrestateColTStepID)            '小工程ID
                .SetData(CMlngGridRowTitle, CMlngLotPrestateColActStepInfo, CMstrLotPrestateColTActStepInfo)  '予約状況
                .SetData(CMlngGridRowTitle, CMlngLotPrestateColAltStep, CMstrLotPrestateColTAltStep)          '代替工程有無
                .SetData(CMlngGridRowTitle, CMlngLotPrestateColReworkStep, CMstrLotPrestateColTReworkStep)    'ﾘﾜｰｸ工程有無
                .SetData(CMlngGridRowTitle, CMlngLotPrestateColSpecialStep, CMstrLotPrestateColTSpecialStep)  '特殊工程有無
                
                '@列幅の設定
                .Cols(CMlngLotPrestateColNo).Width = CMlngGridColWidthNo                      '№
                .Cols(CMlngLotPrestateColAltNumber).Width = CMlngGridColWidthAltNumber        '代替番号
                .Cols(CMlngLotPrestateColOpID).Width = CMlngGridColWidthOpID                  '大工程ID
                .Cols(CMlngLotPrestateColStepID).Width = CMlngGridColWidthStepID              '小工程ID
                .Cols(CMlngLotPrestateColActStepInfo).Width = CMlngGridColWidthActStepInfo    '予約状況
                .Cols(CMlngLotPrestateColAltStep).Width = CMlngGridColWidthAltStep            '代替工程有無
                .Cols(CMlngLotPrestateColReworkStep).Width = CMlngGridColWidthReworkStep      'ﾘﾜｰｸ工程有無
                .Cols(CMlngLotPrestateColSpecialStep).Width = CMlngGridColWidthSpecialStep    '特殊工程有無
                
                '@列非表示設定
                .Cols(CMlngLotPrestateColStepNum).Visible = False       'ｽﾃｯﾌﾟ番号
                .Cols(CMlngLotPrestateColAltNumber).Visible = False     '代替番号
                .Cols(CMlngLotPrestateColReworkRouteID).Visible = False 'ﾘﾜｰｸ時ﾙｰﾄID
                .Cols(CMlngLotPrestateColSPRouteID).Visible = False     '特殊ﾙｰﾄID
                .Cols(CMlngLotPrestateColActFlg).Visible = False        'ｱｸｼｮﾝ予約取得ﾌﾗｸﾞ

                Select Case mintActionType
                    Case CMlngActionLot
                        '@代替工程有無列を表示
                        .Cols(CMlngLotPrestateColAltStep).Visible = True
                        '@ﾘﾜｰｸ工程有無列を非表示
                        .Cols(CMlngLotPrestateColReworkStep).Visible = False
                        '@特殊工程有無列を非表示
                        .Cols(CMlngLotPrestateColSpecialStep).Visible = False

                    Case CMlngActionProduct
                        '@代替工程有無列を表示
                        .Cols(CMlngLotPrestateColAltStep).Visible = True
                        '@ﾘﾜｰｸ工程有無列を表示
                        .Cols(CMlngLotPrestateColReworkStep).Visible = True
                        '@特殊工程有無列を非表示
                        .Cols(CMlngLotPrestateColSpecialStep).Visible = True

                    Case CMlngActionWP
                        '@代替工程有無列を非表示
                        .Cols(CMlngLotPrestateColAltStep).Visible = False
                        '@ﾘﾜｰｸ工程有無列を非表示
                        .Cols(CMlngLotPrestateColReworkStep).Visible = False
                        '@特殊工程有無列を非表示
                        .Cols(CMlngLotPrestateColSpecialStep).Visible = False

                    Case CMlngActionProcess
                        '@代替工程有無列を非表示
                        .Cols(CMlngLotPrestateColAltStep).Visible = False
                        '@ﾘﾜｰｸ工程有無列を非表示
                        .Cols(CMlngLotPrestateColReworkStep).Visible = False
                        '@特殊工程有無列を非表示
                        .Cols(CMlngLotPrestateColSpecialStep).Visible = False
                End Select
                
                '@ﾀｲﾄﾙの高さ
                .Rows(CMlngGridRowTitle).Height = CMlngGridTitleHeight
                        
                '@更新日付
                lblNowDate.Text = vbNullString
                
                '@件数
                lblStepCnt.Text = vbNullString
                
                '@工程を初期化
                lblStepType.Text = vbNullString
                
                '@無効
                cmdAlt.Enabled = False      '代替表示ﾎﾞﾀﾝ
                cmdRework.Enabled = False   'ﾘﾜｰｸ表示ﾎﾞﾀﾝ
                cmdSpecial.Enabled = False  '特殊特性表示ﾎﾞﾀﾝ
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfUseInfo_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfUseInfo_Disp
    '機　能：現工程ｸﾞﾘｯﾄﾞ情報設定処理
    '引　数：ltypLotPrestate：現工程取得ﾃﾞｰﾀ格納構造体
    '　　　：llngCnt：ﾃﾞｰﾀ件数
    '戻り値：なし
    '作成日：2004/05/19 (Wed) 13:02:38 H.Wajima
    '更新日：2012/11/06 (Tue) 15:33:11 T.Oide
    '備　考：
    '　　　：2004/10/22 (Fri) 13:27:12 S.Deguchi    特殊工程対応で特殊工程列とﾌﾗｸﾞ表示処理を追加
    '　　　：2004/12/13 (Mon) 17:19:47 N.KasaiIf    llngStepCnt <= llngPageMaxRow Thenｺﾒﾝﾄｱｳﾄ(10明細以上読み込みできない)
    '　　　：2005/04/26 (Tue) 15:55:28 S.Deguchi    Travelerに,Action_Flagを追加の対応で処理修正
    '　　　：2005/04/28 (Thu) 16:23:40 S.Deguchi    先頭工程に対して背景色ｸﾞﾚｰにする処理を削除
    '　　　：2012/11/06 (Tue) 15:33:21 T.Oide       Chip誤送品防止対応
    Private Sub prvvsfUseInfo_Disp(ByRef ltypWpuseinfo As List(Of Wpuseinfo), _
                                   ByVal llngCnt As Integer)

        Dim llngStepCnt                 As Integer          '小工程ｶｳﾝﾀ
        Dim llngRowCnt                  As Integer          '行ｶｳﾝﾀ
        Dim lstrActStepInfo             As String           'ｱｸｼｮﾝ予約状況
        Dim lstrLotActionTypeID         As String           'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
        Dim llngPageMaxRow              As Integer          'ﾍﾟｰｼﾞ最終行

        Try
            
            '@ｸﾞﾘｯﾄﾞの初期化(構造体は初期化する)
            Call prvvsfUseInfo_Init(True)
            
            '@一覧表示
            With vsfUseInfo
                '@描画ﾛｯｸ
                .Redraw = False
                    
                '@ｶｳﾝﾀの初期化
                llngRowCnt = .Rows.Fixed
                
                '@行設定
                RemoveHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                .Rows.Count = .Rows.Fixed + llngCnt
                AddHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell

                'NSYS 処理対象行取得
                Dim mtypStepTypeGridTmp As StepTypeGrid = mtypStepTypeGrid(mlngStepFlg)
                
                '@構造体の初期化
                With mtypStepTypeGridTmp
                    .typStepTypeList = New List(Of StepTypeList)
                    If llngCnt > 0 Then
                        'ReDim .typStepTypeList(llngCnt)
                        .blnMessageReadFlg = True                                       '既読ﾌﾗｸﾞを設定する
                        .lngDataCount = llngCnt                                         'ﾃﾞｰﾀ件数
                        lblStepCnt.Text = .lngDataCount
                        .strReadTime = Format$(Now(), CPstrDateTimeMD) _
                                     & Space(1) _
                                     & Format$(Now(), CPstrDateFormatHMS)                '取得日時
                        lblNowDate.Text = .strReadTime
                    Else
                        '@0件の場合
                        .blnMessageReadFlg = True                                       '既読ﾌﾗｸﾞを設定する
                        .lngDataCount = llngCnt                                         'ﾃﾞｰﾀ件数
                        lblStepCnt.Text = .lngDataCount
                        .strReadTime = Format$(Now(), CPstrDateTimeMD) _
                                     & Space(1) _
                                     & Format$(Now(), CPstrDateFormatHMS)                '取得日時
                        lblNowDate.Text = .strReadTime
                    End If
                End With

                'NSYS 編集後状態を適用
                mtypStepTypeGrid(mlngStepFlg) = mtypStepTypeGridTmp
                
                '@表示最終行を格納
                llngPageMaxRow = CMlngGridPageRows
                
                '@表示最終行が最終行以上の場合
                If llngPageMaxRow >= .Rows.Count Then
                    '@最終行を格納
                    llngPageMaxRow = .Rows.Count - 1
                End If
                
                For llngStepCnt = 1 To llngCnt
                    '@№
                    .SetData(llngStepCnt, CMlngLotPrestateColNo, llngStepCnt)
                            
                    '@大工程
                    .SetData(llngStepCnt, CMlngLotPrestateColOpID, ltypWpuseinfo(llngStepCnt - 1).strOpID)
                    
                    '@小工程
                    .SetData(llngStepCnt, CMlngLotPrestateColStepID, ltypWpuseinfo(llngStepCnt - 1).strStepID)
                    
                    '@代替工程有無ﾌﾗｸﾞがありの場合
                    If ltypWpuseinfo(llngStepCnt - 1).strAltStepFlag = CMstrStepFlg1 Then
                        '@代替工程有無列に「○」をｾｯﾄ」
                        .SetData(llngStepCnt, CMlngLotPrestateColAltStep, CMstrMaru)
                    Else
                        '@代替工程有無列を初期化
                        .SetData(llngStepCnt, CMlngLotPrestateColAltStep, vbNullString)
                    End If
                    
                    '@ﾘﾜｰｸ工程有無ﾌﾗｸﾞがありの場合
                    If ltypWpuseinfo(llngStepCnt - 1).strReworkStepFlag = CMstrStepFlg1 Then
                        '@ﾘﾜｰｸ工程有無列に「○」をｾｯﾄ」
                        .SetData(llngStepCnt, CMlngLotPrestateColReworkStep, CMstrMaru)
                    Else
                        '@ﾘﾜｰｸ工程有無列を初期化
                        .SetData(llngStepCnt, CMlngLotPrestateColReworkStep, vbNullString)
                    End If
                    
                    '@特殊工程有無ﾌﾗｸﾞがありの場合
                    If ltypWpuseinfo(llngStepCnt - 1).strSpecialStepFlag = CMstrStepFlg1 Then
                        '@特殊工程有無列に「追」をｾｯﾄ」
                        .SetData(llngStepCnt, CMlngLotPrestateColSpecialStep, CMstrTsuika)
                    Else
                        If ltypWpuseinfo(llngStepCnt - 1).strSpecialStepFlag = CMstrStepFlg2 Then
                            '@特殊工程有無列に「先」をｾｯﾄ」
                            .SetData(llngStepCnt, CMlngLotPrestateColSpecialStep, CMstrSaki)
                        Else
                            '@特殊工程有無列を初期化
                            .SetData(llngStepCnt, CMlngLotPrestateColSpecialStep, vbNullString)
                        End If
                    End If
                    
                    '@ﾘﾜｰｸ時ﾙｰﾄID
                    .SetData(llngStepCnt, CMlngLotPrestateColReworkRouteID, ltypWpuseinfo(llngStepCnt - 1).strReworkRouteID)
                    
                    '@特殊ﾙｰﾄID
                    .SetData(llngStepCnt, CMlngLotPrestateColSPRouteID, ltypWpuseinfo(llngStepCnt - 1).strSpecialRouteID)
                    
                    '@ｽﾃｯﾌﾟ番号
                    .SetData(llngStepCnt, CMlngLotPrestateColStepNum, ltypWpuseinfo(llngStepCnt - 1).strSTEPNUM)
                    
                    '@ｱｸｼｮﾝ予約ﾀｲﾌﾟ判定
                    For llngCnt = CMlngActionIndexLot To CMlngActionIndexProcess
                        If CType(Me.fraActionReserve.Controls("optYoyaku" & llngCnt.ToString),RadioButton).Checked = True Then
                            lstrLotActionTypeID = CStr(llngCnt)
                            Exit For
                        End If
                    Next llngCnt
                    
                    '@ｱｸｼｮﾝ予約ﾌﾗｸﾞの判定
                    Select Case ltypWpuseinfo(llngStepCnt - 1).strActionFlag
                        Case CMstrActionFlg0
                            '@なし
                            lstrActStepInfo = vbNullString
                        Case CMstrActionFlg1
                            '@作業開始時
                            lstrActStepInfo = CPlngLotActStepInfoWrkStart
                        Case CMstrActionFlg2
                            '@作業終了時
                            lstrActStepInfo = CPlngLotActStepInfoWrkEnd
                        Case CMstrActionFlg3
                            '@開始/終了
                            lstrActStepInfo = CPlngLotActStepInfoBoth
                        Case Else
                            '@ｱｸｼｮﾝ予約がない場合
                            lstrActStepInfo = vbNullString
                    End Select
                    .SetData(llngStepCnt, CMlngLotPrestateColActStepInfo, lstrActStepInfo)
                        
                    '@予約状況取得ﾌﾗｸﾞに「1」取得済みをｾｯﾄ
                    .SetData(llngStepCnt, CMlngLotPrestateColActFlg, CMlngGetActFlg)
                    
                    'NSYS 編集用構造体初期化
                    Dim typStepTypeListTmp As StepTypeList

                    '@退避用構造体へﾃﾞｰﾀを格納
                    With typStepTypeListTmp
                        .strSeqNum = llngStepCnt                                    '№
                        .strOpID = ltypWpuseinfo(llngStepCnt - 1).strOpID           '大工程
                        .strStepID = ltypWpuseinfo(llngStepCnt - 1).strStepID       '小工程
                        .strActionFlg = lstrActStepInfo                             '予約状況
                    End With

                    'NSYS 編集済み構造体追加
                    mtypStepTypeGrid(mlngStepFlg).typStepTypeList.Add(typStepTypeListTmp)

                Next llngStepCnt
                
        '@↓2012/11/06 (Tue) 15:33:01 T.Oide **************************************************
                With vsfUseInfo
                        
                    '@装置のｱｸｼｮﾝ予約の場合
                    If optYoyaku2.Checked = True Then
                        
                        '@ｳｪﾊｰｱｸｼｮﾝ予約を最終行に追加
                        RemoveHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                        .Rows.Count = .Rows.Count + 1
                        AddHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                        .SetData(.Rows.Count - 1, CMlngLotPrestateColNo, .Rows.Count - 1)             'No
                        .SetData(.Rows.Count - 1, CMlngLotPrestateColOpID, CMstrWFSiteiOp)      '大工程
                        .SetData(.Rows.Count - 1, CMlngLotPrestateColStepID, CMstrWFSiteiStep)  '小工程
                        .SetData(.Rows.Count - 1, CMlngLotPrestateColActStepInfo, _
                                                        prvSetActionTriggerName(pstrWfActionFlag))   '予約状況
                        'NSYS テーブルレコード無し（固定行のみ）の場合は選択状態にしない
                        If .Rows.Count = 2 Then
                            .Row = 0
                        End If
                    End If
                
                End With
        '@↑2012/11/06 (Tue) 15:33:01 T.Oide **************************************************
                
                '@明細の行の高さ
                .Rows.DefaultSize = CMlngGridRowHeight
                
                '@ﾀｲﾄﾙの行の高さ
                .Rows(CMlngGridRowTitle).Height = CMlngGridTitleHeight
                
                '@描画の再開
                .Redraw = True
                
                '@ｸﾞﾘｯﾄﾞﾛｯｸ解除
                .Enabled = True
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfUseInfo_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmdSearch_Chk
    '機　能：検索ﾎﾞﾀﾝ押下可能ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/25 (Tue) 16:49:53 H.Wajima
    '更新日：2004/05/25 (Tue) 16:49:53
    '備　考：
    Private Sub prvcmdSearch_Chk()
        
        Dim lintCnt                     As Short        '汎用ｶｳﾝﾀ

        Try
            
            For lintCnt = CMlngActionIndexLot To CMlngActionIndexProcess
                If CType( Me.fraActionReserve.Controls("optYoyaku" & lintCnt.ToString),RadioButton).Checked = True Then
                    Exit For
                End If
            Next lintCnt
            
            Select Case lintCnt
                Case CMlngActionIndexLot
                    '@ﾛｯﾄの場合
                    If txtLotID.Text <> vbNullString Then
                        '@全部取消ﾎﾞﾀﾝを押下可能にする。
                        cmdClear.Enabled = True
                    Else
                        '@全部取消ﾎﾞﾀﾝを押下不能にする。
                        cmdClear.Enabled = False
                        
                    End If
                    
                    '@ﾛｯﾄの場合
                    If Len(txtLotID.Text) <> 10 Then
                        '@最新取得ﾎﾞﾀﾝをﾛｯｸ
                        cmdNowList.Enabled = False
                        '@ﾃﾞﾌｫﾙﾄﾎﾞﾀﾝﾛｯｸ
                        cmdDefult.Enabled = False
                    End If
                    
                    '@工程表示ｸﾞﾘｯﾄの初期化
                    Call prvvsfUseInfo_Init()
                    
                Case CMlngActionIndexProduct
                    If cmbProduct.Text <> vbNullString Then
                        '@全部取消ﾎﾞﾀﾝを押下可能にする。
                        cmdClear.Enabled = True
                    Else
                        '@全部取消ﾎﾞﾀﾝを押下不能にする。
                        cmdClear.Enabled = False
                        
                        
                        '@工程表示ｸﾞﾘｯﾄの初期化
                        Call prvvsfUseInfo_Init()
                        
                    End If
                Case CMlngActionIndexWP
                    If cmbWpID.Text <> vbNullString Then
                        '@全部取消ﾎﾞﾀﾝを押下可能にする。
                        cmdClear.Enabled = True
                    Else
                        '@工程表示ｸﾞﾘｯﾄの初期化
                        Call prvvsfUseInfo_Init()
                        
                        '@全部取消ﾎﾞﾀﾝを押下不能にする。
                        cmdClear.Enabled = False
                        
                    End If
                Case CMlngActionIndexProcess
                    If cmbProcessinfo.Text <> vbNullString Then
                        '@全部取消ﾎﾞﾀﾝを押下可能にする。
                        cmdClear.Enabled = True
                    Else
                        '@工程表示ｸﾞﾘｯﾄの初期化
                        Call prvvsfUseInfo_Init()
                        
                        '@全部取消ﾎﾞﾀﾝを押下不能にする。
                        cmdClear.Enabled = False
                    End If
                    
            End Select
            
            Call prvControlEnabled_Init()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmdSearch_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmdRegist_Chk
    '機　能：確定ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 12:39:48 N.Kasai
    '更新日：2012/11/07 (Wed) 13:42:21 T.Oide
    '備　考：
    '　　　：2004/12/06 (Mon) 11:36:09 N.Kasai      ｱｸｼｮﾝ予約ﾀｲﾌﾟﾛｯﾄを選択した場合日付設定を任意入力とする(№276)
    '　　　：2005/05/07 (Sat) 17:41:43 S.Deguchi    仕様確認で処理見直し(保留なしはﾒｯｾｰｼﾞ必須とする)
    '　　　：2005/08/08 (Mon) 19:17:41 N.Kojima     ｱｸｼｮﾝﾌﾗｸﾞ(機種指定でUSE_IDが"Monitor"or"Quality")の場合、日付ﾁｪｯｸをしない(不具合№2985)
    '　　　：2006/10/16 (Mon) 16:36:01 M.Miura      ﾀﾞﾐｰを有効期限なしに修正(案件№01573)
    '　　　：2012/11/07 (Wed) 13:42:21 T.Oide       R9-05 Chipの誤送品防止対応
    Private Sub prvcmdRegist_Chk()

        Dim lintCnt                     As Short        '汎用ｶｳﾝﾀ
        Dim lblnChkFlg                  As Boolean      '確定判定ﾌﾗｸﾞ
        Dim lblnDateCheck               As Boolean      '日付ﾁｪｯｸ可否ﾌﾗｸﾞ(True:ﾁｪｯｸ要,False:ﾁｪｯｸ不要)

        Try
            
            lblnChkFlg = False
            
            '@ｱｸｼｮﾝﾄﾘｶﾞｰﾁｪｯｸ
            For lintCnt = 0 To 1
                If CType(Me.fraFrame3.Controls("optTrigger" & lintCnt.ToString),RadioButton).Checked = True Then
                    lblnChkFlg = True
                    Exit For
                End If
            Next lintCnt

            If lblnChkFlg = False Then
                cmdRegist.Enabled = False
                Exit Sub
            End If
            
            With vsfUseInfo
                '@ｱｸｼｮﾝ予約設定不可の場合
                If .GetCellRange(.Row, CMlngLotPrestateColOpID).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngGridGray) Then
                    '@代替,ﾘﾜｰｸ工程の場合
                    If mlngStepFlg = CMlngStepFlg1 Or _
                       mlngStepFlg = CMlngStepFlg2 Then
                       
                        cmdRegist.Enabled = False
                        Exit Sub
                    End If
                End If
            End With
            
            '@ｱｸｼｮﾝ予約ﾀｲﾌﾟがﾛｯﾄを選択した場合は任意入力とする
            '@日付ﾁｪｯｸ可否ﾌﾗｸﾞ初期化
            lblnDateCheck = True
            
            '@ｱｸｼｮﾝﾌﾗｸﾞ(ﾛｯﾄ選択)の場合
            If optYoyaku0.Checked = True Then
                '@日付(from-to)が空白の場合
                If calFromDate.Value = CPstrNullDate And calToDate.Value = CPstrNullDate Then
                    lblnDateCheck = False   'ﾁｪｯｸ必要なし
                End If
            End If
            
            '@ｱｸｼｮﾝﾌﾗｸﾞ(機種指定)の場合
            If optYoyaku1.Checked = True Then
                
                '@1番目の値を参照(用途:USE_ID)
                cmbProduct.ValueCol = CMlngCmbGridColID
                
                '@USE_IDが"Monitor"(ﾓﾆﾀ),"Quality"(品確),"Dummy"(ﾀﾞﾐｰ)の場合
                If cmbProduct.Value = CPstrMonitor Or _
                   cmbProduct.Value = CPstrQuality Or _
                   cmbProduct.Value = CPstrPdDummy Then
                    
                    '@日付(from-to)が空白の場合
                    If calFromDate.Value = CPstrNullDate And calToDate.Value = CPstrNullDate Then
                        lblnDateCheck = False   'ﾁｪｯｸ必要なし
                    End If
                End If
                
                '@0番目の値を参照するように戻す(用途:USE_ID)
                cmbProduct.ValueCol = CMlngCmbGridColName
            End If
            
        '@↓2012/11/13 (Tue) 09:44:55 T.Oide **************************************************
            '@ｱｸｼｮﾝﾌﾗｸﾞ(装置指定)の場合
            If optYoyaku2.Checked = True Then
            
                '@----------------------------------------------------
                '@通常は日付け必要、WF指定ｱｸｼｮﾝ予約の場合は日付け不要
                '@----------------------------------------------------
                '@WF指定のｱｸｼｮﾝ予約か
                If vsfUseInfo.GetData(vsfUseInfo.Row, CMlngLotPrestateColOpID) = CMstrWFSiteiOp Then
                    lblnDateCheck = False
                    
                    '@ｳｪﾊｰ設定は入っているか
                    If ptypWfactrsv.lngWfActionCnt = 0 Then
                        '@無い場合
                        cmdRegist.Enabled = False
                        Exit Sub
                    End If
                Else
                    lblnDateCheck = True
                End If
            
            End If
        '@↑2012/11/13 (Tue) 09:44:55 T.Oide **************************************************
            
            '@日付ﾁｪｯｸ要の場合
            If lblnDateCheck = True Then
                '@開始日付
                Select Case calFromDate.Value
                    Case CPstrNullDate
                        '@空白の場合
                        cmdRegist.Enabled = False
                        Exit Sub
                    Case Is < calFromDate.MinDate
                        '@最小日付よりも過去の場合
                        cmdRegist.Enabled = False
                        Exit Sub
                    Case Is > calFromDate.MaxDate
                        '@最大日付よりも未来の場合
                        cmdRegist.Enabled = False
                        Exit Sub
                End Select
                If calFromDate.IsDate = False Then
                    '@正当な日付でない場合
                    cmdRegist.Enabled = False
                    Exit Sub
                End If
                

                '@終了日付
                Select Case calToDate.Value
                    Case CPstrNullDate
                        '@ｱｸｼｮﾝﾌﾗｸﾞ(ﾛｯﾄ選択)ではない場合
                        If optYoyaku0.Checked <> True Then
                
                            '@機種指定の場合
                            If optYoyaku1.Checked = True Then
                
                                '@1番目の値を参照(用途:USE_ID)
                                cmbProduct.ValueCol = CMlngCmbGridColID
                
                                '@USE_IDが"Monitor"(ﾓﾆﾀ),"Quality"(品確),"Dummy"(ﾀﾞﾐｰ)ではない場合
                                If cmbProduct.Value <> CPstrMonitor And _
                                   cmbProduct.Value <> CPstrQuality And _
                                   cmbProduct.Value <> CPstrPdDummy Then
                
                                    '@空白の場合
                                    cmdRegist.Enabled = False
                
                                    '@0番目の値を参照するように戻す(用途:USE_ID)
                                    cmbProduct.ValueCol = CMlngCmbGridColName
                                    Exit Sub
                                End If
                
                                '@0番目の値を参照するように戻す(用途:USE_ID)
                                cmbProduct.ValueCol = CMlngCmbGridColName
                            Else
                                '@空白の場合
                                cmdRegist.Enabled = False
                                Exit Sub
                            End If
                        End If
                    Case Is < calToDate.MinDate
                        '@最小日付よりも過去の場合
                        cmdRegist.Enabled = False
                        Exit Sub
                    Case Is > calToDate.MaxDate
                        '@最大日付よりも未来の場合
                        cmdRegist.Enabled = False
                        Exit Sub
                    Case Is <> CPstrNullDate
                        '@初期値以外の場合
                        If calToDate.IsDate = False Then
                            '@正当な日付でない場合
                            cmdRegist.Enabled = False
                            Exit Sub
                        Else
                            '@正当な日付の場合
                            '@開始日付と終了日付の大小ﾁｪｯｸ
                            If calFromDate.Value > calToDate.Value Then
                                '@開始日付のほうが終了日付よりも新しい場合
                                cmdRegist.Enabled = False
                                Exit Sub
                            End If
                        End If
                End Select
            End If
            
            '@技術担当者がNULLか
            If cmbTechMan.Text = vbNullString Then
                cmdRegist.Enabled = False
                Exit Sub
            End If
            
            lblnChkFlg = False
            '@停止/保留ﾁｪｯｸ
            Select Case True
                Case optBunrui0.Checked
                '@停止/保留なしの場合
                    '@ﾒｯｾｰｼﾞ表示は必須
                    If txtWorkMemo.Text = vbNullString Then
                        cmdRegist.Enabled = False
                        Exit Sub
                    End If
                
                Case optBunrui1.Checked
                '@停止の場合
            
                Case optBunrui2.Checked
                '@保留の場合
                    '@保留要因のﾁｪｯｸ
                    If cmbMasHold.Text = vbNullString Then
                        cmdRegist.Enabled = False
                        
                        Exit Sub
                    End If
                    
                    '@保留期限が設定されてない場合
                    If txtHoldPeriod.Text = vbNullString Then
                        cmdRegist.Enabled = False
                        
                        Exit Sub
                    End If
                    
                Case Else
                    '@どれも選択されていない場合
                    cmdRegist.Enabled = False
                    
                    Exit Sub
            End Select
            
            cmdRegist.Enabled = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmdRegist_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmdWFAction_Chk
    '機　能：WF指定設定ﾎﾞﾀﾝ　有効/無効ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2012/10/24 (Wed) 13:38:47  T.Oide
    '更新日：2018/11/15 (Thu) 10:47:51  Y.Yoneyama
    '備　考：
    Private Sub prvcmdWFAction_Chk()

        Try
            
            With vsfUseInfo
                    
                '@装置のｱｸｼｮﾝ予約で且つ、装置が選択されていて且つ、WF指定のｱｸｼｮﾝ予約の行にフォーカスがあるか
                'NSYS 条件に行が選択状態を追加
                If optYoyaku2.Checked = True AndAlso _
                   cmbWpID.Value <> vbNullString AndAlso _
                   .Row > 0 AndAlso _
                   .GetData(.Row, CMlngLotPrestateColOpID) = CMstrWFSiteiOp Then
                   
        '@↓2018/11/15 (Thu) 10:47:51 Y.Yoneyama **************************************************
                    '@防湿ALDでは機能を無効とする
                    '@防湿ALDの場合
                    If pstrSBID = CPstrSBID3A0 Then

                        'NSYS メッセージ表示前に行表示状態を反映
                        .Refresh()
            
                        '@"<TRM3SW>$$「%1」では使用できません。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003S, CPstrSBID3A0Name)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
                        cmdWFAction.Enabled = False
                        Exit Sub
                    End If
        '@↑2018/11/15 (Thu) 10:47:51 Y.Yoneyama **************************************************
                   
                    '@作業開始 or 作業終了が選択されているか
                    If optTrigger0.Checked = True Or optTrigger1.Checked = True Then
                        '@有効
                        cmdWFAction.Enabled = True
                    Else
                        '@無効
                        cmdWFAction.Enabled = False
                    End If
                Else
                
                    '@無効
                    cmdWFAction.Enabled = False
                End If
            
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmdWFAction_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmdClear_Proc
    '機　能：全部取消ﾎﾞﾀﾝ押下時の画面初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 12:40:36 N.Kasai
    '更新日：2005/07/26 (Tue) 11:34:29 N.Kasai
    '備　考：
    '　　　：2005/07/26 (Tue) 11:34:29 N.Kasai      L/R色追加
    Private Sub prvcmdClear_Proc()

        Try
            
            '@ﾛｯﾄ
            With txtLotID
                .Text = vbNullString
                .Enabled = True
            End With
            '@機種
            With cmbProduct
                .Enabled = False
                RemoveHandler cmbProduct.Change,AddressOf cmbProduct_Change
                .ListIndex = CMlngCmbClearListIndex
                AddHandler cmbProduct.Change,AddressOf cmbProduct_Change
                .BackColor = SystemColors.Window        'ﾊﾞｯｸｶﾗｰ(白)
            End With
            '@装置
            With cmbWpID
                .Enabled = False
                RemoveHandler cmbWpID.Change,AddressOf cmbWpID_Change
                .ListIndex = CMlngCmbClearListIndex
                AddHandler cmbWpID.Change,AddressOf cmbWpID_Change
            End With
            '@特定工程
            With cmbProcessinfo
                .Enabled = False
                RemoveHandler cmbProcessinfo.Change,AddressOf cmbProcessinfo_Change
                .ListIndex = CMlngCmbClearListIndex
                AddHandler cmbProcessinfo.Change,AddressOf cmbProcessinfo_Change
            End With
            
            '@工程表示ｸﾞﾘｯﾄの初期化
            Call prvvsfUseInfo_Init()
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ(使用不可)
            Call prvControlEnabled_Init()
            
            '@ｽﾃｰﾀｽﾌｫｰﾑへ送るﾒｯｾｰｼﾞの初期化(ｽﾃｰﾀｽﾌｫｰﾑへ送るﾒｯｾｰｼﾞ)
            mstrInfoMsg = vbNullString

            'NSYS 退避文字列を初期化
            mstrOptYoyakuClickedName = vbNullString
            
            '@機種・ｴﾝﾄﾘを初期設定
            optYoyaku0.Checked = True
            Call optYoyaku_Click(optYoyaku0,New EventArgs()) 'NSYS Checkedの代入でClickイベントが自動実行されないため手動実行
            
            '@ﾌｫｰｶｽの移動
            Call pubSetFocus(optYoyaku0)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmdClear_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvStepSearch_Sel
    '機　能：工程検索処理
    '引　数：lblInitFlag　True：画面初期化する False:画面初期化しない(確定,削除ﾎﾞﾀﾝ押下後のみ)
    '戻り値：なし
    '作成日：2004/06/23 (Wed) 08:59:30 H.Wajima
    '更新日：2008/01/22 (Tue) 12:42:31 N.Kojima
    '備　考：
    '　　　：2004/09/14 (Tue) 12:03:45 N.Kasai      新COM対応　不要ﾀｸﾞ削除(lstrClassDivision)
    '　　　：2004/10/19 (Tue) 09:07:17 Y.Yamagishi　ﾒｯｾｰｼﾞﾎﾞｯｸｽの0件表示をしない(不具合改善対応№87)
    '　　　：2004/11/05 (Fri) 17:13:07 M.Miura      初工程編集不可ﾌﾗｸﾞ設定追加。ｱｸｼｮﾝﾄﾘｶﾞｰ有効/無効制御追加(不具合№198)
    '　　　：2005/01/05 (Wed) 10:01:16 N.Kasai      引数追加(lblInitFlag)不具合№390　0件ﾒｯｾｰｼﾞﾎﾞｯｸｽｺﾒﾝﾄｱｳﾄ削除
    '　　　：2005/01/08 (Sat) 17:14:57 H.Wajima     特定工程で小工程の数が10件以上の場合,ﾘｽﾄに値が設定されない問題を修正
    '　　　：2005/04/27 (Wed) 11:32:05 S.Deguchi    不具合№571の対応でlot_.actinfo_の送受信方法見直し
    '　　　：2005/11/25 (Fri) 15:17:13 S.Deguchi    ﾕｰｻﾞｰ要望№0106の対応で,保留期限設定処理を追加
    '　　　：2006/12/08 (Fri) 16:32:09 N.Kasai      ｴﾗｰ時のﾌｫｰｶｽ制御追加(№01447)
    '　　　：2008/01/22 (Tue) 12:42:31 N.Kojima     lot_.steplistの要求に"LOT_LIST"を追加したことに伴う修正。(案件№02405)
    Private Sub prvStepSearch_Sel(Optional ByVal lblInitFlag As Boolean = True)

        Dim lblnAns                     As Boolean      '汎用戻り値(True/False)
        Dim llngWpuseinfoCnt            As Integer      '装置使用工程のｶｳﾝﾄ
        Dim llngStepListCnt             As Integer      'ﾛｯﾄｽﾃｯﾌﾟのｶｳﾝﾄ
        Dim llngMasPdtravelerCnt        As Integer      '機種・ｴﾝﾄﾘのｶｳﾝﾄ
        Dim lstrWpId                    As String       '装置ID格納
        Dim lstrLotID                   As String       'ﾛｯﾄID格納
        Dim lstrPdID                    As String       '機種ID格納
        Dim lintCnt                     As Short        '汎用ｶｳﾝﾀ
        Dim lstrFormName                As String       'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName               As String       'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypMasStepList             As MasStepList  '小工程情報ｶｳﾝﾀ格納
        Dim lstrOpID                    As String       '大工程格納
        Dim lstrFlowClass               As String       '種別
        Dim ltypLotList                 As List(Of LotIdList)    'ﾛｯﾄﾘｽﾄ(引数合わせ用)

        Try
            
            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称を設定
            lstrFormName = Me.Name
            lstrEventName = "cmdSearch_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ﾌｫｰﾑﾛｯｸ
            
            '@工程ﾌﾗｸﾞ(ﾃﾞﾌｫﾙﾄ工程)
            mlngStepFlg = CMlngStepFlg0
            
            '@初工程編集不可ﾌﾗｸﾞ(編集可)
            mblnFastStepNg = False
            
            '@ｱｸｼｮﾝ予約対象判定(ｵﾌﾟｼｮﾝﾎﾞﾀﾝの選択状態で判定)
            For lintCnt = CMlngActionIndexLot To CMlngActionIndexProcess
                '@選択状態の場合処理続行
                If CType(Me.fraActionReserve.Controls("optYoyaku" & lintCnt.ToString),RadioButton).Checked = True Then
                    Exit For
                End If
            Next lintCnt
            
            With vsfUseInfo
                '@ｱｸｼｮﾝ予約ﾀｲﾌﾟを退避する。(ｱｸｼｮﾝ予約検索時に使用する)
                Select Case lintCnt
                    Case CMlngActionIndexLot
                    '@ｶｳﾝﾀが0の時(ﾛｯﾄ)
                        mintActionType = CMlngActionLot
                        '@代替工程有無列を表示
                        .Cols(CMlngLotPrestateColAltStep).Visible = True
                        '@ﾘﾜｰｸ工程有無列を非表示
                        .Cols(CMlngLotPrestateColReworkStep).Visible = False

                    Case CMlngActionIndexProduct
                    '@ｶｳﾝﾀが1の時(機種)
                        mintActionType = CMlngActionProduct
                        '@代替工程有無列を表示
                        .Cols(CMlngLotPrestateColAltStep).Visible = True
                        '@ﾘﾜｰｸ工程有無列を表示
                        .Cols(CMlngLotPrestateColReworkStep).Visible = True

                    Case CMlngActionIndexWP
                    '@ｶｳﾝﾀが2の時(装置)
                        mintActionType = CMlngActionWP
                        '@代替工程有無列を非表示
                        .Cols(CMlngLotPrestateColAltStep).Visible = False
                        '@ﾘﾜｰｸ工程有無列を非表示
                        .Cols(CMlngLotPrestateColReworkStep).Visible = False

                    Case CMlngActionIndexProcess
                    '@ｶｳﾝﾀが3の時(工程)
                        mintActionType = CMlngActionProcess
                        '@代替工程有無列を非表示
                        .Cols(CMlngLotPrestateColAltStep).Visible = False
                        '@ﾘﾜｰｸ工程有無列を非表示
                        .Cols(CMlngLotPrestateColReworkStep).Visible = False
                End Select
            End With
                    
            '@工程取得
            Select Case mintActionType
                
                '@ﾛｯﾄ
                Case CMlngActionLot
                
                    '@ﾛｯﾄID取得
                    lstrLotID = txtLotID.Text
                    
                    '@【ﾛｯﾄｽﾃｯﾌﾟ取得】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnLotTraveler_Sel(CMstrlot_travelerVer, _
                                                    llngStepListCnt, _
                                                    lstrLotID, _
                                                    pstrSBID, _
                                                    mstrTechManID, _
                                                    mstrTechManName, _
                                                    lstrFlowClass)
                    
                    '@結果判定
                    If lblnAns = True Then
                        '@ﾌｫｰﾑﾛｯｸ解除
                        
                        '@工程表示
                        Call prvvsfUseInfo_Disp(ptypWpuseinfo, llngStepListCnt)
                        
                        '@件数判定(取得0件の場合)
                        If llngStepListCnt = 0 Then
                            '@表示の初期化
                            Call prvControlEnabled_Init(False, False, False)
                                            
                            '@ﾛｯﾄにﾌｫｰｶｽ移動
                            Call pubSetFocus(txtLotID)
                        
                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(lstrFormName, lstrEventName)
                            
                            '@工程一覧使用不可
                            vsfUseInfo.Enabled = False
                            
                            '@最新取得ﾎﾞﾀﾝﾛｯｸ
                            cmdNowList.Enabled = False
                            
                            '@ﾃﾞﾌｫﾙﾄﾎﾞﾀﾝﾛｯｸ
                            cmdDefult.Enabled = False
                            
                            Exit Sub
                        Else
                            '@情報取得成功＆1件以上
                            With vsfUseInfo
                                '@活性化処理(非活性の場合のみ処理)
                                If .Enabled = False Then
                                    .Enabled = True
                                End If
                                
                                '@ｶﾚﾝﾄ行をﾀｲﾄﾙにｾｯﾄ
                                .Row = .Rows.Fixed - 1
                                
                                '@先頭を表示
                                .ShowCell(.Rows.Fixed, .Col)
                            End With
                        End If
                    Else
                        '@異常の場合終了
                        
                        '@ﾌｫｰﾑﾛｯｸ解除
                        
                        '@各ｺﾝﾄﾛｰﾙの設定(使用不可)
                        Call prvControlEnabled_Init()
                        
                        '@ｴﾗｰの為、ｸﾞﾘｯﾄﾞ使用不可
                         '@ｶﾚﾝﾄ行をﾀｲﾄﾙにｾｯﾄ
                         With vsfUseInfo
                            .Rows.Count = .Rows.Fixed
                            .Enabled = False
                        End With
                        
                        lblStepType.Text = vbNullString
                        lblNowDate.Text = vbNullString
                        lblStepCnt.Text = vbNullString
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        
                        '@ﾛｯﾄにﾌｫｰｶｽ移動
                        Call pubSetFocus(txtLotID)
                        
                        '@最新取得ﾎﾞﾀﾝﾛｯｸ
                        cmdNowList.Enabled = False
                        
                        '@ﾃﾞﾌｫﾙﾄﾎﾞﾀﾝﾛｯｸ
                        cmdDefult.Enabled = False
                        
                        Exit Sub
                    End If
                
                '@機種
                Case CMlngActionProduct
                    
                    '@機種ID取得
                    cmbProduct.ValueCol = 0
                    lstrPdID = cmbProduct.Value
                    
                    '@機種別ｽﾃｯﾌﾟ取得
                    lblnAns = pubblnMasPdtraveler_Sel(CMstrmas_pdtravelerVer, _
                                                      llngMasPdtravelerCnt, _
                                                      pstrSBID, _
                                                      lstrPdID, _
                                                      mstrEntryID)
                    '@結果判定
                    If lblnAns = True Then
                        '@ﾌｫｰﾑﾛｯｸ解除
                        
                        '@工程表示
                        Call prvvsfUseInfo_Disp(ptypWpuseinfo, llngMasPdtravelerCnt)
                        
                        '@件数判定(取得0件の場合)
                        If llngMasPdtravelerCnt = 0 Then
                            '@表示の初期化
                            Call prvControlEnabled_Init(False, False, False)
                                                            
                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(lstrFormName, lstrEventName)
                            
                            '@工程一覧使用不可
                            vsfUseInfo.Enabled = False
                            
                            '@最新取得ﾎﾞﾀﾝﾛｯｸ
                            cmdNowList.Enabled = False
                            
                            '@ﾃﾞﾌｫﾙﾄﾎﾞﾀﾝﾛｯｸ
                            cmdDefult.Enabled = False
                            
                            Exit Sub
                        Else
                            With vsfUseInfo
                                '@活性化処理(非活性の場合のみ処理)
                                If .Enabled = False Then
                                    .Enabled = True
                                End If
                                
                                '@ｶﾚﾝﾄ行をﾀｲﾄﾙにｾｯﾄ
                                .Row = .Rows.Fixed - 1
                                
                                '@ﾀｲﾄﾙ行を表示
                                .ShowCell(.Rows.Fixed, .Col)
                            End With
                        End If
                    Else
                        '@異常の場合終了
                        
                        '@ﾌｫｰﾑﾛｯｸ解除
                        '@ｴﾗｰの為、ｸﾞﾘｯﾄﾞ使用不可
                        '@ｶﾚﾝﾄ行をﾀｲﾄﾙにｾｯﾄ
                        With vsfUseInfo
                            .Rows.Count = .Rows.Fixed
                            .Enabled = False
                        End With
                        
                        lblStepType.Text = vbNullString
                        lblNowDate.Text = vbNullString
                        lblStepCnt.Text = vbNullString

                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        
                        '@機種にﾌｫｰｶｽ移動
                        Call pubSetFocus(cmbProduct)
                        
                        Exit Sub
                    End If
                
                '@装置
                Case CMlngActionWP
                    '@装置ID取得
                    cmbWpID.ValueCol = CMlngCmbGridColID
                    lstrWpId = cmbWpID.Value
                    
                    '@装置使用工程取得
                    lblnAns = pubblnStepUsedWpList_Sel(CMstrmas_stepusedwplistVer, _
                                                       llngWpuseinfoCnt, _
                                                       lstrWpId, _
                                                       pstrSBID)
                    '@結果判定
                    If lblnAns = True Then
                        '@ﾌｫｰﾑﾛｯｸ解除
                        
                        '@工程表示
                        Call prvvsfUseInfo_Disp(ptypWpuseinfo, llngWpuseinfoCnt)
                        
                        '@件数判定(取得0件の場合)
                        If llngWpuseinfoCnt = 0 Then
                            '@表示の初期化
                            Call prvControlEnabled_Init(False, False, False)
                                            
                            '@装置にﾌｫｰｶｽ移動
                            Call pubSetFocus(cmbWpID)
                        
                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(lstrFormName, lstrEventName)
                            
                            '@工程一覧使用不可
                            vsfUseInfo.Enabled = False
                            
                            '@最新取得ﾎﾞﾀﾝﾛｯｸ
                            cmdNowList.Enabled = False
                            
                            '@ﾃﾞﾌｫﾙﾄﾎﾞﾀﾝﾛｯｸ
                            cmdDefult.Enabled = False
                            
                            Exit Sub
                        Else
                            With vsfUseInfo
                                '@活性化処理(非活性の場合のみ処理)
                                If .Enabled = False Then
                                    .Enabled = True
                                End If
                                
                                '@ｶﾚﾝﾄ行をﾀｲﾄﾙにｾｯﾄ
                                .Row = .Rows.Fixed - 1
                                
                                '@ﾀｲﾄﾙ行を表示
                                .ShowCell(.Rows.Fixed, .Col)
                            End With
                        End If
                    Else
                    '@異常の場合終了
                        '@ﾌｫｰﾑﾛｯｸ解除
        '@↓2006/12/08 (Fri) 16:26:22 N.Kasai **************************************************
                        '@ｴﾗｰの為、ｸﾞﾘｯﾄﾞ使用不可
                        '@ｶﾚﾝﾄ行をﾀｲﾄﾙにｾｯﾄ
                        With vsfUseInfo
                            .Rows.Count = .Rows.Fixed
                            .Enabled = False
                        End With
                        
                        lblStepType.Text = vbNullString
                        lblNowDate.Text = vbNullString
                        lblStepCnt.Text = vbNullString

        '@↑2006/12/08 (Fri) 16:26:22 N.Kasai **************************************************
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        
                        '@装置にﾌｫｰｶｽ移動
                        Call pubSetFocus(cmbWpID)
                        
                        Exit Sub
                    End If
                    
                '@特定工程
                Case CMlngActionProcess
                    
                    '@大工程取得
                    With cmbProcessinfo
                        .ValueCol = 0
                        lstrOpID = .Value
                    End With
                    
                    '@特定工程取得
                    lblnAns = pubblnLotStepList_Sel(pstrSBID, _
                                                    CMstrlot_steplistVer, _
                                                    CPstrCD28, _
                                                    ltypLotList, _
                                                    ltypMasStepList, _
                                                    lstrOpID)

                    '@結果判定
                    If lblnAns = True Then
                        '@ﾌｫｰﾑﾛｯｸ解除
                        
                        '@工程表示
                        Call prvvsfUseInfo2_Disp(ltypMasStepList, lstrOpID)
                        
                        '@件数判定(取得0件の場合)
                        If ltypMasStepList.lngMasStepCnt = 0 Then
                            '@表示の初期化
                            Call prvControlEnabled_Init(False, False, False)
                            
                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(lstrFormName, lstrEventName)
            
                            '@工程一覧使用不可
                            vsfUseInfo.Enabled = False
                            
                            '@最新取得ﾎﾞﾀﾝﾛｯｸ
                            cmdNowList.Enabled = False
                            
                            '@ﾃﾞﾌｫﾙﾄﾎﾞﾀﾝﾛｯｸ
                            cmdDefult.Enabled = False
                            
                            Exit Sub
                        Else
                            With vsfUseInfo
                                '@活性化処理(非活性の場合のみ処理)
                                If .Enabled = False Then
                                    .Enabled = True
                                End If
                                
                                '@ｶﾚﾝﾄ行をﾀｲﾄﾙにｾｯﾄ
                                .Row = .Rows.Fixed - 1
                                
                                '@ﾀｲﾄﾙ行を表示
                                .ShowCell(.Rows.Fixed, .Col)
                            End With
                        End If
                    Else
                    '@異常の場合終了
                        '@ﾌｫｰﾑﾛｯｸ解除
        '@↓2006/12/08 (Fri) 16:26:22 N.Kasai **************************************************
                        '@ｴﾗｰの為、ｸﾞﾘｯﾄﾞ使用不可
                        '@ｶﾚﾝﾄ行をﾀｲﾄﾙにｾｯﾄ
                        With vsfUseInfo
                            .Rows.Count = .Rows.Fixed
                            .Enabled = False
                        End With
                        
                        lblStepType.Text = vbNullString
                        lblNowDate.Text = vbNullString
                        lblStepCnt.Text = vbNullString
        '@↑2006/12/08 (Fri) 16:26:22 N.Kasai **************************************************
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)

                        '@装置にﾌｫｰｶｽ移動
                        Call pubSetFocus(cmbProcessinfo)
                        
                        Exit Sub
                    End If
            End Select
            
            '@初期化ﾌﾗｸﾞの判定(True:初期化する　False:初期化しない)
            '@確定ﾎﾞﾀﾝ押下後表示を残す(不具合№390)
            If lblInitFlag = True Then
                '@表示の初期化
                Call prvControlEnabled_Init(False, True, False)
            End If
            
            '@工程に「デフォルト工程」をｾｯﾄ
            lblStepType.Text = CMstrDefultStep
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
        '@↓2005/11/25 (Fri) 15:20:27 S.Deguchi **************************************************
            '@種別による保留期限の設定処理
            Select Case lstrFlowClass
                Case CPstrFlowClassES, CPstrFlowClassPR
                '@ES/PR:2日
                    mstrDefaultHoldPeriod = CMstrHoldTrem2
                    
                Case Else
                '@その他:7日
                    mstrDefaultHoldPeriod = CMstrHoldTrem7
            End Select
        '@↑2005/11/25 (Fri) 15:20:27 S.Deguchi **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvStepSearch_Sel"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnActStepInfo_Disp
    '機　能：ｱｸｼｮﾝ予約状況を表示ﾍﾟｰｼﾞごとに表示する
    '引　数：llngRow：ｸﾞﾘｯﾄﾞの対象行
    '　　　：lstrLotActionTypeID：ﾛｯﾄｱｸｼｮﾝﾀｲﾌﾟID
    '　　　：lstrOPID：大工程
    '　　　：lstrStepID：小工程
    '　　　：lstrItemName：項目名
    '　　　：lstrActionTrigger：ｱｸｼｮﾝﾄﾘｶﾞｰ
    '　　　：lstrActStepInfo：ｱｸｼｮﾝ予約状況
    '戻り値：なし
    '作成日：2004/06/29 (Tue) 10:29:33 H.Wajima
    '更新日：2008/04/14 (Mon) 16:47:09 M.Koni
    '備　考：True：正常,False：異常
    '　　　：2008/04/14 (Mon) 16:48:18 M.Koni       本関数，未使用に付き削除。<案件No.02254>
    'Private Function prvblnActStepInfo_Disp(ByVal llngRow As Long, _
    '                                        ByVal lstrLotActionTypeID As String, _
    '                                        ByVal lstrOpID As String, _
    '                                        ByVal lstrStepID As String, _
    '                                        ByVal lstrItemName As String, _
    '                                        ByVal lstrActionTrigger As String, _
    '                                        ByRef lstrActStepInfo As String) As Boolean
    '
    '    Dim ltypLotActInfo              As LotActioninfo    'ｱｸｼｮﾝ内容検索構造体
    '    Dim lblnRet                     As Boolean          '戻り値
    '
    '    On Error GoTo Error_Handler
    '
    '    prvblnActStepInfo_Disp = False
    '
    '    '@ｱｸｼｮﾝ予約状況取得
    '    lblnRet = pubblnLotActinfo_Sel(CMstrlot_actinfo_Ver, CPstrCD32, _
    '                                    pstrSBID, _
    '                                    lstrLotActionTypeID, _
    '                                    lstrOpID, _
    '                                    lstrStepID, _
    '                                    lstrItemName, _
    '                                    lstrActionTrigger, _
    '                                    ltypLotActInfo)
    '    '@戻り値の判定
    '    If lblnRet = False Then
    '        '@戻り値がFalseの場合
    '        '@ｱｸｼｮﾝ予約状況
    '        lstrActStepInfo = vbNullString
    '        '@最終更新日時を初期化
    '        mstrEditTime = vbNullString
    '
    '        Exit Function
    '    Else
    '        '@戻り値がTrueの場合
    '        With ltypLotActInfo
    '            '@ｱｸｼｮﾝ予約ﾌﾗｸﾞの判定
    '            Select Case .strActionFlag
    '                Case CMstrActionFlg0
    '                    '@なし
    '                    lstrActStepInfo = vbNullString
    '                Case CMstrActionFlg1
    '                    '@作業開始時
    '                    lstrActStepInfo = CPlngLotActStepInfoWrkStart
    '                Case CMstrActionFlg2
    '                    '@作業終了時
    '                    lstrActStepInfo = CPlngLotActStepInfoWrkEnd
    '                Case CMstrActionFlg3
    '                    '@開始/終了
    '                    lstrActStepInfo = CPlngLotActStepInfoBoth
    '                Case Else
    '                    '@ｱｸｼｮﾝ予約がない場合
    '                    lstrActStepInfo = vbNullString
    '            End Select
    '            '@最終更新日時を格納
    '            mstrEditTime = .strEditTime
    '        End With
    '    End If
    '
    '    '@正常
    '    prvblnActStepInfo_Disp = True
    '
    '    Exit Function
    '
    'Error_Handler:
    '
    '    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '    With ptypOnErrorInfo
    '        .strMenuKey = CMstrLocalMenuKey
    '        .strProcName = "prvblnActStepInfo_Disp"
    '        .strErrMessage = vbNullString
    '    End With
    '
    '    '@共通ｴﾗｰ処理
    '    Call pubOnError_Proc
    '
    'End Function

    '関数名：prvHoldCtlEnabled_Set
    '機　能：保留関連ｺﾝﾄﾛｰﾙ有効無効制御
    '引　数：lblnEnabled：True：有効,False：無効
    '戻り値：なし
    '作成日：2004/09/09 (Thu) 11:56:49 M.Miura
    '更新日：2005/08/10 (Wed) 09:50:36 N.Kojima
    '備　考：
    '　　　：2004/09/29 (Wed) 16:30:22 N.Kasai      保留期限の初期値をｼｽﾃﾑ日付からｻｰﾊﾞより取得した値を表示
    '　　　：2005/08/10 (Wed) 09:50:36 N.Kojima     保留期限の入力方式変更に伴う修正。(不具合№2985)
    Private Sub prvHoldCtlEnabled_Set(ByVal lblnEnabled As Boolean)

        Try

            '@有効/無効設定
            cmbMasHold.Enabled = lblnEnabled
            txtHoldPeriod.Enabled = lblnEnabled
            txtHoldComments.Enabled = lblnEnabled
            
            '@保留理由,保留責任者ｺﾝﾎﾞを未選択に設定
            RemoveHandler cmbMasHold.Change,AddressOf cmbMasHold_Change
            cmbMasHold.ListIndex = -1
            AddHandler cmbMasHold.Change,AddressOf cmbMasHold_Change
            
            '@有効の場合
            If lblnEnabled = True Then
                '@保留期限にﾃﾞﾌｫﾙﾄ日付をｾｯﾄ
                txtHoldPeriod.Text = mstrDefaultHoldPeriod
            Else
                '@保留期限を初期化
                txtHoldPeriod.Text = vbNullString
                
                '@保留ｺﾒﾝﾄを初期化
                txtHoldComments.Text = vbNullString
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvHoldCtlEnabled_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfUseInfoAlt_Disp
    '機　能：代替工程表示
    '引　数：ltypLotAltStepList：代替工程構造体
    '戻り値：なし
    '作成日：2004/09/09 (Thu) 19:38:14 M.Miura
    '更新日：2005/01/08 (Sat) 13:03:43 N.Kasai
    '備　考：
    '　　　：2004/10/25 (Mon) 11:25:03 S.Deguchi    ﾘﾜｰｸﾌﾗｸﾞに追加流動を追加処理による修正
    '　　　：2004/11/05 (Fri) 17:38:33 M.Miura　    初工程編集不可ﾌﾗｸﾞを追加
    '　　　：2005/01/08 (Sat) 13:03:43 N.Kasai      機種が選択されている場合のみﾘﾜｰｸ列を表示する。
    '　　　：2005/04/28 (Thu) 16:23:40 S.Deguchi    先頭工程に対して背景色ｸﾞﾚｰにする処理を削除
    Private Sub prvvsfUseInfoAlt_Disp(ByRef ltypLotAltStepList As LotAltStepList)
        
        Dim llngACnt                    As Integer          'ｶｳﾝﾄ
        Dim llngSCnt                    As Integer          'ｶｳﾝﾄ
        Dim llngRow                     As Integer          '行番号
        Dim llngDfCnt                   As Integer          'ｶｳﾝﾄ
        Dim lstrActStepInfo             As String           'ｱｸｼｮﾝ予約状況

        Try
            'NSYS 処理対象行情報取得
            Dim mtypStepTypeGridTmp As StepTypeGrid = mtypStepTypeGrid(CMlngStepFlg1)
            
            '@構造体の初期化
            With mtypStepTypeGridTmp
                .typStepTypeList = New List(Of StepTypeList)
                If ltypLotAltStepList.lngStepCnt > 0 Then
                    'ReDim .typStepTypeList(ltypLotAltStepList.lngStepCnt)
                    .blnMessageReadFlg = True                                       '既読ﾌﾗｸﾞを設定する
                    .lngDataCount = ltypLotAltStepList.lngStepCnt                   'ﾃﾞｰﾀ件数
                Else
                    '@0件の場合
                    .blnMessageReadFlg = True                                       '既読ﾌﾗｸﾞを設定する
                    .lngDataCount = ltypLotAltStepList.lngStepCnt                   'ﾃﾞｰﾀ件数
                End If
            End With

            'NSYS 編集後処理対象行情報へ入れ替え
            mtypStepTypeGrid(CMlngStepFlg1) = mtypStepTypeGridTmp

            With vsfUseInfo
                RemoveHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                .Rows.Count = .Rows.Fixed
                AddHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                '@代替番号列を表示
                .Cols(CMlngLotPrestateColAltNumber).Visible = True
                '@代替工程有無列を非表示
                .Cols(CMlngLotPrestateColAltStep).Visible = False
                
                '@機種を選択されている場合のみﾘﾜｰｸ列を表示する。
                If optYoyaku1.Checked = True Then
                    '@ﾘﾜｰｸ工程有無列を表示
                    .Cols(CMlngLotPrestateColReworkStep).Visible = True
                Else
                     '@ﾘﾜｰｸ工程有無列を非表示
                    .Cols(CMlngLotPrestateColReworkStep).Visible = False
                End If
                
                '@代替工程がある場合
                If ltypLotAltStepList.lngStepCnt > 0 Then
                    '@行設定
                    RemoveHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                    .Rows.Count = ltypLotAltStepList.lngStepCnt + 1
                    AddHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                Else
                    '@行初期化
                    RemoveHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                    .Rows.Count = .Rows.Fixed
                    AddHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                    Exit Sub
                End If
                '@行番号
                llngRow = 0
                '@代替番号がなくなるまで
                For llngACnt = 0 To ltypLotAltStepList.lngAltNumberCnt - 1
                    '@代替工程がなくなるまで
                    For llngSCnt = 0 To ltypLotAltStepList.typAltNumberList(llngACnt).lngAltStepCnt - 1

                        'NSYS 編集前構造体初期化
                        Dim typStepTypeListTmp As StepTypeList = New StepTypeList

                        llngRow = llngRow + 1
                        '@№
                        .SetData(llngRow, CMlngLotPrestateColNo, llngRow)
                        '@代替番号
                        .SetData(llngRow, CMlngLotPrestateColAltNumber, ltypLotAltStepList.typAltNumberList(llngACnt).strAltNumber)
                            
                        '@大工程IDをｾｯﾄ
                        .SetData(llngRow, CMlngLotPrestateColOpID, ltypLotAltStepList.typAltNumberList(llngACnt).typAltStepList(llngSCnt).strOpID)
                            
                        typStepTypeListTmp.strOpID = ltypLotAltStepList.typAltNumberList(llngACnt).typAltStepList(llngSCnt).strOpID
                            
                        '@小工程IDをｾｯﾄ
                        .SetData(llngRow, CMlngLotPrestateColStepID, ltypLotAltStepList.typAltNumberList(llngACnt).typAltStepList(llngSCnt).strStepID)
                            
                        typStepTypeListTmp.strStepID = ltypLotAltStepList.typAltNumberList(llngACnt).typAltStepList(llngSCnt).strStepID
                            
                        '@ﾘﾜｰｸ工程有無ﾌﾗｸﾞがﾘﾜｰｸ/追加の場合
                        Select Case ltypLotAltStepList.typAltNumberList(llngACnt).typAltStepList(llngSCnt).strReworkFlag
                            Case CMstrStepFlg1
                                .SetData(llngRow, CMlngLotPrestateColReworkStep, CMstrMaru)
                                .SetData(llngRow, CMlngLotPrestateColSpecialStep, vbNullString)
                            Case CMstrStepFlg2
                                .SetData(llngRow, CMlngLotPrestateColReworkStep, vbNullString)
                                .SetData(llngRow, CMlngLotPrestateColSpecialStep, CMstrTsuika)
                        End Select
                        
                        '@ﾘﾜｰｸ時ﾙｰﾄID
                        .SetData(llngRow, CMlngLotPrestateColReworkRouteID, ltypLotAltStepList.typAltNumberList(llngACnt).typAltStepList(llngSCnt).strReworkRouteID)
                            
                        '@ｽﾃｯﾌﾟ番号
                        .SetData(llngRow, CMlngLotPrestateColStepNum, ltypLotAltStepList.typAltNumberList(llngACnt).typAltStepList(llngSCnt).strSeqNum)
                            
                        typStepTypeListTmp.strSeqNum = ltypLotAltStepList.typAltNumberList(llngACnt).typAltStepList(llngSCnt).strSeqNum
                        
                        '@ｱｸｼｮﾝ予約ﾌﾗｸﾞの判定
                        Select Case ltypLotAltStepList.typAltNumberList(llngACnt).typAltStepList(llngSCnt).strActionFlag
                            Case CMstrActionFlg0
                                '@なし
                                lstrActStepInfo = vbNullString
                            Case CMstrActionFlg1
                                '@作業開始時
                                lstrActStepInfo = CPlngLotActStepInfoWrkStart
                            Case CMstrActionFlg2
                                '@作業終了時
                                lstrActStepInfo = CPlngLotActStepInfoWrkEnd
                            Case CMstrActionFlg3
                                '@開始/終了
                                lstrActStepInfo = CPlngLotActStepInfoBoth
                            Case Else
                                '@ｱｸｼｮﾝ予約がない場合
                                lstrActStepInfo = vbNullString
                        End Select
                        .SetData(llngRow, CMlngLotPrestateColActStepInfo, lstrActStepInfo)

                        'NSYS 編集済み構造体追加
                        mtypStepTypeGrid(CMlngStepFlg1).typStepTypeList.Add(typStepTypeListTmp)
                        
                        '@ﾃﾞﾌｫﾙﾄ工程がなくなるまで
                        For llngDfCnt = 0 To mtypStepTypeGrid(CMlngStepFlg0).lngDataCount - 1
                            '@代替工程と同じ工程がﾃﾞﾌｫﾙﾄ工程にある場合
                            If ltypLotAltStepList.typAltNumberList(llngACnt).typAltStepList(llngSCnt).strOpID & _
                               ltypLotAltStepList.typAltNumberList(llngACnt).typAltStepList(llngSCnt).strStepID = _
                               mtypStepTypeGrid(CMlngStepFlg0).typStepTypeList(llngDfCnt).strOpID & _
                               mtypStepTypeGrid(CMlngStepFlg0).typStepTypeList(llngDfCnt).strStepID Then
                                '@背景色をｸﾞﾚｰに設定
                                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                                Dim cellRange As CellRange = .GetCellRange(llngRow, CMlngLotPrestateColNo, llngRow, .Cols.Count - 1)
                                cellRange.Style = newStyle
                                '@初工程の場合
                                If ltypLotAltStepList.typAltNumberList(llngACnt).typAltStepList(llngSCnt).strSeqNum = CMstrStepNum1 Then
                                    '@初工程編集不可ﾌﾗｸﾞ(編集不可)
                                    mblnFastStepNg = True
                                End If
                                
                                Exit For
                            End If
                        Next llngDfCnt
                    Next llngSCnt
                Next llngACnt
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfUseInfoAlt_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfUseInfoRework_Disp
    '機　能：ﾘﾜｰｸ工程表示
    '引　数：lstrOpID：大工程ID
    '　　　：ltypMasReworkTraveler：ﾘﾜｰｸ工程応答構造体
    '戻り値：なし
    '作成日：2004/09/13 (Mon) 10:46:50 M.Miura
    '更新日：2004/11/05 (Fri) 14:39:58 M.Miura
    '備　考：2004/10/25 (Mon) 08:57:35 S.Deguchi    特殊工程を表示しないように処理追加
    '　　　：2004/11/05 (Fri) 14:39:58 M.Miura　    初工程の場合は該当行の背景色をｸﾞﾚｰに変更。初工程編集ﾌﾗｸﾞを追加
    '　　　：2005/04/28 (Thu) 16:23:40 S.Deguchi    先頭工程に対して背景色ｸﾞﾚｰにする処理を削除
    Private Sub prvvsfUseInfoRework_Disp(ByVal lstrOpID As String, _
                                         ByRef ltypMasReworkTraveler As MasReworkTraveler)
        
        Dim llngSCnt            As Integer  'ｶｳﾝﾄ
        Dim llngDfCnt           As Integer  'ｶｳﾝﾄ
        Dim llngDaCnt           As Integer  'ｶｳﾝﾄ
        Dim lblnChgFlg          As Boolean  '変更ﾌﾗｸﾞ(True：変更可,False：変更不可)
        Dim lstrActStepInfo     As String   'ｱｸｼｮﾝ予約状況

        Try
            'NSYS 処理対象行情報取得
            Dim mtypStepTypeGridTmp As StepTypeGrid = mtypStepTypeGrid(CMlngStepFlg2)

            '@構造体の初期化
            With mtypStepTypeGridTmp
                .typStepTypeList = New List(Of StepTypeList)
                If ltypMasReworkTraveler.lngReworkStepCnt > 0 Then
                    'ReDim .typStepTypeList(ltypMasReworkTraveler.lngReworkStepCnt)
                    .blnMessageReadFlg = True                                       '既読ﾌﾗｸﾞを設定する
                    .lngDataCount = ltypMasReworkTraveler.lngReworkStepCnt          'ﾃﾞｰﾀ件数
                Else
                    '@0件の場合
                    .blnMessageReadFlg = True                                       '既読ﾌﾗｸﾞを設定する
                    .lngDataCount = ltypMasReworkTraveler.lngReworkStepCnt          'ﾃﾞｰﾀ件数
                End If
            End With

            'NSYS 編集後処理対象行情報へ入れ替え
            mtypStepTypeGrid(CMlngStepFlg2) = mtypStepTypeGridTmp
            
            With vsfUseInfo
                RemoveHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                .Rows.Count = .Rows.Fixed
                AddHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                '@代替番号列を非表示
                .Cols(CMlngLotPrestateColAltNumber).Visible = False
                '@代替工程有無列を非表示
                .Cols(CMlngLotPrestateColAltStep).Visible = False
                '@ﾘﾜｰｸ工程有無列を非表示
                .Cols(CMlngLotPrestateColReworkStep).Visible = False
                '@特殊工程有無列を非表示
                .Cols(CMlngLotPrestateColSpecialStep).Visible = False
                '@ﾘﾜｰｸ工程がある場合
                If ltypMasReworkTraveler.lngReworkStepCnt > 0 Then
                    '@行設定
                    RemoveHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                    .Rows.Count = ltypMasReworkTraveler.lngReworkStepCnt + 1
                    AddHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                Else
                    '@行初期化
                    RemoveHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                    .Rows.Count = .Rows.Fixed
                    AddHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                    Exit Sub
                End If
                '@行番号
                
                '@ﾘﾜｰｸ工程がなくなるまで
                For llngSCnt = 1 To ltypMasReworkTraveler.lngReworkStepCnt

                    'NSYS
                    Dim typStepTypeListTmp As StepTypeList = New StepTypeList

                    '@№
                    .SetData(llngSCnt, CMlngLotPrestateColNo, llngSCnt)
                    
                    '@大工程IDをｾｯﾄ
                    .SetData(llngSCnt, CMlngLotPrestateColOpID, lstrOpID)
                    
                    typStepTypeListTmp.strOpID = lstrOpID
                    
                    '@小工程IDをｾｯﾄ
                    .SetData(llngSCnt, CMlngLotPrestateColStepID, ltypMasReworkTraveler.typReworkStepList(llngSCnt - 1).strStepID)
                    
                    typStepTypeListTmp.strStepID _
                        = ltypMasReworkTraveler.typReworkStepList(llngSCnt - 1).strStepID
                    
                    '@ｽﾃｯﾌﾟ番号
                    .SetData(llngSCnt, CMlngLotPrestateColStepNum, ltypMasReworkTraveler.typReworkStepList(llngSCnt - 1).strSTEPNUM)
                        
                    typStepTypeListTmp.strSeqNum _
                        = ltypMasReworkTraveler.typReworkStepList(llngSCnt - 1).strSTEPNUM
                    
                    '@ｱｸｼｮﾝ予約ﾌﾗｸﾞの判定
                    Select Case ltypMasReworkTraveler.typReworkStepList(llngSCnt - 1).strActionFlag
                        Case CMstrActionFlg0
                            '@なし
                            lstrActStepInfo = vbNullString
                        Case CMstrActionFlg1
                            '@作業開始時
                            lstrActStepInfo = CPlngLotActStepInfoWrkStart
                        Case CMstrActionFlg2
                            '@作業終了時
                            lstrActStepInfo = CPlngLotActStepInfoWrkEnd
                        Case CMstrActionFlg3
                            '@開始/終了
                            lstrActStepInfo = CPlngLotActStepInfoBoth
                        Case Else
                            '@ｱｸｼｮﾝ予約がない場合
                            lstrActStepInfo = vbNullString
                    End Select
                    .SetData(llngSCnt, CMlngLotPrestateColActStepInfo, lstrActStepInfo)

                    'NSYS 編集済み構造体追加
                    mtypStepTypeGrid(CMlngStepFlg2).typStepTypeList.Add(typStepTypeListTmp)
                    
                    '@変更ﾌﾗｸﾞ(変更可)
                    lblnChgFlg = True
                    '@ﾃﾞﾌｫﾙﾄ工程がなくなるまで
                    For llngDfCnt = 0 To mtypStepTypeGrid(CMlngStepFlg0).lngDataCount - 1
                        '@代替工程と同じ工程がﾘﾜｰｸ工程にある場合
                        If lstrOpID & _
                           ltypMasReworkTraveler.typReworkStepList(llngSCnt - 1).strStepID = _
                           mtypStepTypeGrid(CMlngStepFlg0).typStepTypeList(llngDfCnt).strOpID & _
                           mtypStepTypeGrid(CMlngStepFlg0).typStepTypeList(llngDfCnt).strStepID Then
                            '@背景色をｸﾞﾚｰに設定
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                            Dim cellRange As CellRange = .GetCellRange(llngSCnt, CMlngLotPrestateColNo, llngSCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                            '@初工程の場合
                            If ltypMasReworkTraveler.typReworkStepList(llngSCnt - 1).strSTEPNUM = CMstrStepNum1 Then
                                '@初工程編集不可ﾌﾗｸﾞ(編集不可)
                                mblnFastStepNg = True
                            End If
                            '@変更ﾌﾗｸﾞ(変更不可)
                            lblnChgFlg = False
                            Exit For
                        End If
                    Next llngDfCnt
                    
                    '@変更可の場合
                    If lblnChgFlg = True Then
                        '@ﾃﾞﾌｫﾙﾄ工程がなくなるまで
                        For llngDaCnt = 0 To mtypStepTypeGrid(CMlngStepFlg1).lngDataCount - 1
                            '@代替工程と同じ工程がﾘﾜｰｸ工程にある場合
                            If lstrOpID & _
                               ltypMasReworkTraveler.typReworkStepList(llngSCnt - 1).strStepID = _
                               mtypStepTypeGrid(CMlngStepFlg1).typStepTypeList(llngDaCnt).strOpID & _
                               mtypStepTypeGrid(CMlngStepFlg1).typStepTypeList(llngDaCnt).strStepID Then
                                '@背景色をｸﾞﾚｰに設定
                                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                                Dim cellRange As CellRange = .GetCellRange(llngSCnt, CMlngLotPrestateColNo, llngSCnt, .Cols.Count - 1)
                                cellRange.Style = newStyle
                                '@初工程の場合
                                If ltypMasReworkTraveler.typReworkStepList(llngSCnt - 1).strSTEPNUM = CMstrStepNum1 Then
                                    '@初工程編集不可ﾌﾗｸﾞ(編集不可)
                                    mblnFastStepNg = True
                                End If
                                Exit For
                            End If
                        Next llngDaCnt
                    End If
                Next llngSCnt
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfUseInfoRework_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfUseInfo2_Disp
    '機　能：特定工程用表示処理
    '引　数：ltypMasStepList：小工程
    '戻り値：なし
    '作成日：2005/04/28 (Thu) 16:52:54 S.Deguchi
    '更新日：2005/04/28 (Thu) 16:52:54
    '備　考：
    Private Sub prvvsfUseInfo2_Disp(ByRef ltypMasStepList As MasStepList, _
                                    ByRef lstrOpID As String)
        
        Dim llngRowCnt                  As Integer      '行ｶｳﾝﾀ
        Dim llngStepCnt                 As Integer      '工程ｶｳﾝﾀ
        Dim lstrActStepInfo             As String       '予約状況
        Dim llngPageMaxRow              As Integer      'ﾍﾟｰｼﾞ最終行

        Try

            '@工程表示
            With vsfUseInfo
                '@描画ﾛｯｸ
                .Redraw = False
                
                '@ｶｳﾝﾀの初期化
                llngRowCnt = .Rows.Fixed
                
                '@行設定
                RemoveHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                .Rows.Count = .Rows.Fixed + ltypMasStepList.lngMasStepCnt
                AddHandler vsfUseInfo.EnterCell,AddressOf vsfUseInfo_EnterCell
                
                'NSYS 処理対象行情報取得
                Dim mtypStepTypeGridTmp As StepTypeGrid = mtypStepTypeGrid(CMlngStepFlg0)

                With mtypStepTypeGridTmp
                    '@構造体の初期化
                    .typStepTypeList = New List(Of StepTypeList)
                    '@取得情報の件数による処理分岐
                    If ltypMasStepList.lngMasStepCnt > 0 Then
                    '@1件以上
                        '@領域確保
                        'ReDim .typStepTypeList(ltypMasStepList.lngMasStepCnt)
                        
                        '@ﾌﾗｸﾞ設定(既読ﾌﾗｸﾞを設定する)
                        .blnMessageReadFlg = True
                        
                        '@ﾃﾞｰﾀ件数
                        .lngDataCount = ltypMasStepList.lngMasStepCnt
                        
                        '@ﾃﾞｰﾀ件数画面表示
                        lblStepCnt.Text = .lngDataCount
                        
                        '@取得日時
                        .strReadTime = Format$(Now(), CPstrDateTimeMD) _
                                     & Space(1) _
                                     & Format$(Now(), CPstrDateFormatHMS)
                        lblNowDate.Text = .strReadTime
                    Else
                    '@0件の場合
                        '@既読ﾌﾗｸﾞを設定する
                        .blnMessageReadFlg = True
                        
                        '@ﾃﾞｰﾀ件数
                        .lngDataCount = ltypMasStepList.lngMasStepCnt
                        
                        '@ﾃﾞｰﾀ件数画面表示
                        lblStepCnt.Text = .lngDataCount
                        
                        '@取得日時
                        .strReadTime = Format$(Now(), CPstrDateTimeMD) _
                                     & Space(1) _
                                     & Format$(Now(), CPstrDateFormatHMS)
                        lblNowDate.Text = .strReadTime
                    End If
                End With
                
                '@表示最終行を格納
                llngPageMaxRow = CMlngGridPageRows
                    
                '@最終行を格納
                llngPageMaxRow = ltypMasStepList.lngMasStepCnt
                
                '@ﾙｰﾌﾟ
                For llngStepCnt = 1 To llngPageMaxRow
                    '@№
                    .SetData(llngStepCnt, CMlngLotPrestateColNo, llngStepCnt)
                            
                    '@大工程
                    .SetData(llngStepCnt, CMlngLotPrestateColOpID, lstrOpID)
                    
                    '@小工程
                    .SetData(llngStepCnt, CMlngLotPrestateColStepID, ltypMasStepList.typMasStepId(llngStepCnt - 1).strStepID)
                
                    '@ｱｸｼｮﾝ予約ﾌﾗｸﾞの判定
                    Select Case ltypMasStepList.typMasStepId(llngStepCnt - 1).strActionFlag
                        Case CMstrActionFlg0
                            '@なし
                            lstrActStepInfo = vbNullString
                        Case CMstrActionFlg1
                            '@作業開始時
                            lstrActStepInfo = CPlngLotActStepInfoWrkStart
                        Case CMstrActionFlg2
                            '@作業終了時
                            lstrActStepInfo = CPlngLotActStepInfoWrkEnd
                        Case CMstrActionFlg3
                            '@開始/終了
                            lstrActStepInfo = CPlngLotActStepInfoBoth
                        Case Else
                            '@ｱｸｼｮﾝ予約がない場合
                            lstrActStepInfo = vbNullString
                    End Select
                    .SetData(llngStepCnt, CMlngLotPrestateColActStepInfo, lstrActStepInfo)
                    
                    '@予約状況取得ﾌﾗｸﾞに「1」取得済みをｾｯﾄ
                    .SetData(llngStepCnt, CMlngLotPrestateColActFlg, CMlngGetActFlg)
                    
                    'NSYS 編集用構造体初期化
                    Dim typStepTypeListTmp As StepTypeList

                    '@退避用構造体へﾃﾞｰﾀを格納
                    With typStepTypeListTmp
                        .strSeqNum = llngStepCnt                                            '№
                        .strOpID = lstrOpID                                                 '大工程
                        .strStepID = ltypMasStepList.typMasStepId(llngStepCnt - 1).strStepID'小工程
                        .strActionFlg = lstrActStepInfo                                     '予約状況
                    End With

                    'NSYS 編集済み構造体追加
                    mtypStepTypeGrid(CMlngStepFlg0).typStepTypeList.Add(typStepTypeListTmp)
                
                Next llngStepCnt
                
                '@明細の行の高さ
                .Rows.DefaultSize = CMlngGridRowHeight
                
                '@ﾀｲﾄﾙの行の高さ
                .Rows(CMlngGridRowTitle).Height = CMlngGridTitleHeight
                
                '@描画の再開
                .Redraw = True
                
                '@活性化
                .Enabled = True
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfUseInfo2_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnActInfo_Sel
    '機　能：ｱｸｼｮﾝ予約の検索処理
    '引　数：lintIndex：選択(0:開始時/1:終了時)
    '戻り値：True:OK/False:NG
    '作成日：2005/05/06 (Fri) 11:34:17 S.Deguchi
    '更新日：2012/11/06 (Tue) 15:00:43 T.Oide
    '備　考：
    Private Function prvblnActInfo_Sel(ByVal lintIndex As Short) As Boolean
        
        Dim lstrFormName                As String       'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName               As String       'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrLotActionTypeID         As String       'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
        Dim lstrOpID                    As String       '大工程
        Dim lstrStepID                  As String       '小工程
        Dim lstrItemName                As String       '項目名
        Dim lstrProduct                 As String       '機種ID格納
        Dim lstrActionTrigger           As String       'ｱｸｼｮﾝﾄﾘｶﾞｰ
        Dim lblnAns                     As Boolean      '汎用戻り値

        Try
                
            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称を設定
            lstrFormName = Me.Name
            lstrEventName = "prvblnActInfo_Sel"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
                
            '@必要情報を変数へ退避
            With vsfUseInfo
                '@ｱｸｼｮﾝﾀｲﾌﾟID
                lstrLotActionTypeID = CStr(mintActionType)
                
        '@↓2012/11/02 (Fri) 19:40:45 T.Oide **************************************************
        '@        '@大工程
        '@        lstrOpID = .Cell(flexcpText, .Row, CMlngLotPrestateColOpID)
        '@
        '@        '@小工程
        '@        lstrStepID = .Cell(flexcpText, .Row, CMlngLotPrestateColStepID)
        '@--------------------------------------------------------------------------------------

                '@WF指定ｱｸｼｮﾝ予約の時は、工程を入れない
                '@(工程が「ウェハー指定」の場合）
                If .GetData(.Row, CMlngLotPrestateColOpID) <> CMstrWFSiteiOp Then
                    lstrOpID = .GetData(.Row, CMlngLotPrestateColOpID)     '@大工程
                    lstrStepID = .GetData(.Row, CMlngLotPrestateColStepID) '@小工程
                End If
        '@↑2012/11/02 (Fri) 19:40:45 T.Oide **************************************************
                
                
                
                '@ｱｸｼｮﾝﾀｲﾌﾟによる他設定
                Select Case lstrLotActionTypeID '0:ﾛｯﾄ,1:機種,2:装置,3:特定工程
                    Case CStr(CMlngActionLot)
                    '@ﾛｯﾄ
                        '@ﾛｯﾄNo取得
                        lstrItemName = txtLotID.Text
                        
                    Case CStr(CMlngActionProduct)
                    '@機種
                        '@機種ID取得
                        With cmbProduct
                            .ValueCol = 0
                            lstrProduct = .Value
                        End With
                        
                        '@項目名(機種ID)
                        lstrItemName = lstrProduct
                    
                    Case CStr(CMlngActionWP)
                    '装置
                        '@装置ID取得
                        cmbWpID.ValueCol = CMlngCmbGridColID
                        '@項目名(WPID)
                        lstrItemName = cmbWpID.Value
                    
                    Case CStr(CMlngActionProcess)
                    '@特定工程
                        lstrItemName = CPstrMsgNull
                End Select
                
                'ｱｸｼｮﾝﾄﾘｶﾞｰの設定
                lstrActionTrigger = lintIndex
                
                '@ｱｸｼｮﾝ予約検索取得
                lblnAns = pubblnLotActinfo_Sel(CMstrlot_actinfo_Ver, _
                                               pstrSBID, _
                                               lstrLotActionTypeID, _
                                               lstrOpID, _
                                               lstrStepID, _
                                               lstrItemName, _
                                               lstrActionTrigger)

                '@結果判定
                If lblnAns = True Then
                    '@正常終了の場合
                    prvblnActInfo_Sel = True
                    
                    '@ﾛｯﾄｱｸｼｮﾝ予約IDの判定
                    If ptypLotActioninfo.strLotActionID <> vbNullString Then
                        '@画面表示
                        Call prvfrmxxEN0270_Disp(ptypLotActioninfo)
                        
                        '@最終更新日時
                        mstrEditTime = ptypLotActioninfo.strEditTime
                    
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(lstrFormName, lstrEventName)
                    Else
                        '@異常の場合終了
                        prvblnActInfo_Sel = False
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        
                        '@ﾛｯﾄｱｸｼｮﾝ予約IDを初期化
                        mstrLotActionID = vbNullString
                    End If
                Else
                    '@異常の場合終了
                    prvblnActInfo_Sel = False
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@ﾛｯﾄｱｸｼｮﾝ予約IDを初期化
                    mstrLotActionID = vbNullString
                End If
            End With

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnActInfo_Sel"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvErrFocus_Set
    '機　能：確定/削除ｴﾗｰ時のﾌｫｰｶｽｾｯﾄ
    '引　数：なし
    '戻り値：なし
    '作成日：2006/12/08 (Fri) 16:38:57 N.Kasai
    '更新日：2006/12/08 (Fri) 16:38:57
    '備　考：
    Private Sub prvErrFocus_Set()

        Try
            
            '@ｱｸｼｮﾝ予約対象判定
            Select Case True
                Case optYoyaku0.Checked
                    '@ﾛｯﾄID変更ﾌﾗｸﾞ(変更なし)
                    mblnLotID_Change = False
                    '@ﾛｯﾄ
                    Call pubSetFocus(txtLotID)
                Case optYoyaku1.Checked
                    '@機種変更ﾌﾗｸﾞ(変更なし)
                    mblnProduct_Change = False
                    '@機種・ｴﾝﾄﾘ
                    Call pubSetFocus(cmbProduct)
                Case optYoyaku2.Checked
                    '@装置名変更ﾌﾗｸﾞ(変更なし)
                    mblnWpID_Change = False
                    '@装置
                    Call pubSetFocus(cmbWpID)
                Case optYoyaku3.Checked
                    '@特殊工程変更ﾌﾗｸﾞ(変更なし)
                    mblnProcessinfo_Change = False
                    '@特定工程
                    Call pubSetFocus(cmbProcessinfo)
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvErrFocus_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvEditDataInit
    '機　能：WF設定ｱｸｼｮﾝ予約情報初期化
    '引　数：なし
    '戻り値：
    '作成日：2012/11/06 (Tue) 18:19:44 T.Oide
    '更新日：2012/11/06 (Tue) 18:19:44
    '備　考：
    Private Sub prvEditDataInit()

        Try

            '@ｳｪﾊｰｱｸｼｮﾝ予約初期化
            pstrWfActionFlag = vbNullString
            
            '@WF設定ｱｸｼｮﾝ予約ｸﾘｱ
            ptypWfactrsv.lngWfActionCnt = ptypLotActioninfo.lngWfActionCnt
            'ptypWfactrsv.typWfAction = ptypLotActioninfo.typWfAction
            'NSYS リスト内容コピー
            ptypWfactrsv.typWfAction = New List(Of WfAction)
            For llngCnt = 0 To ptypWfactrsv.lngWfActionCnt - 1
                Dim typWfActionTmp As WfAction = New WfAction
                With typWfActionTmp
                    .strDelFlag = ptypLotActioninfo.typWfAction(llngCnt).strDelFlag
                    .strExecTime = ptypLotActioninfo.typWfAction(llngCnt).strExecTime
                    .strNewFlag = ptypLotActioninfo.typWfAction(llngCnt).strNewFlag
                    .strWfId = ptypLotActioninfo.typWfAction(llngCnt).strWfId
                End With
                ptypWfactrsv.typWfAction.Add(typWfActionTmp)
            Next
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvEditDataInit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvSetActionTriggerName
    '機　能：ｱｸｼｮﾝFlagを和名に変換
    '引　数：strActionFlag：0：作業時、1：終了時、2：開始時/終了時
    '戻り値：
    '作成日：2012/11/07 (Wed) 09:59:13 T.Oide
    '更新日：2012/11/07 (Wed) 09:59:13
    '備　考：
    Private Function prvSetActionTriggerName(ByVal strActionFlag As String) As String

        Try
            
                '@ｱｸｼｮﾝ予約ﾌﾗｸﾞの判定
                Select Case strActionFlag
                
                    Case CMstrActionFlg0
                        '@なし
                        prvSetActionTriggerName = vbNullString
                    Case CMstrActionFlg1
                        '@作業開始時
                        prvSetActionTriggerName = CPlngLotActStepInfoWrkStart
                    Case CMstrActionFlg2
                        '@作業終了時
                        prvSetActionTriggerName = CPlngLotActStepInfoWrkEnd
                    Case CMstrActionFlg3
                        '@開始/終了
                        prvSetActionTriggerName = CPlngLotActStepInfoBoth
                    Case Else
                        '@ｱｸｼｮﾝ予約がない場合
                        prvSetActionTriggerName = vbNullString
                        
                End Select
                
                Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvSetActionTriggerName"
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


    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraFrame2.Paint, ltypWFMapInfo0.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfUseInfo.BeforeDoubleClick

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

    '関数名：cursor_Enter
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考：Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles _
        calFromDate.Enter,calHoldTermDate.Enter,calToDate.Enter,cmbMasHold.Enter,cmbProcessinfo.Enter, _ 
        cmbProduct.Enter,cmbTechMan.Enter,cmbWpID.Enter,cmdAlt.Enter,cmdClear.Enter,cmdClose.Enter, _ 
        cmdDefult.Enter,cmdDelete.Enter,cmdHoldDown.Enter,cmdHoldUp.Enter,cmdNowList.Enter,cmdRegist.Enter, _ 
        cmdRework.Enter,cmdSpecial.Enter,cmdWFAction.Enter,cmdWorkMemoDown.Enter,cmdWorkMemoUp.Enter, _ 
        fraActionReserve.Enter,fraBunrui.Enter,fraFrame3.Enter, _ 
        optBunrui0.Enter,optBunrui1.Enter,optBunrui2.Enter,optTrigger0.Enter,optTrigger1.Enter,optYoyaku0.Enter, _ 
        optYoyaku1.Enter,optYoyaku2.Enter,optYoyaku3.Enter,txtHoldComments.Enter,txtHoldPeriod.Enter,txtLotID.Enter, _ 
        txtWorkDirect.Enter,txtWorkMemo.Enter,vsfUseInfo.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '閉じるボタンの場合は自動Validate = OFF
            Case cmdClose.Name,optYoyaku0.Name,optYoyaku1.Name,optYoyaku2.Name,optYoyaku3.Name,cmdClear.Name
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
            '上記以外は自動Validate = ON
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        End Select

    End Sub


End Class
