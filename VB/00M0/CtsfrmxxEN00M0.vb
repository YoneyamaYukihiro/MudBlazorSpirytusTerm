'ﾌｧｲﾙ名：xxEN00M0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：バッチ管理メインフォーム
'作成日：2004/07/22 (Thu) 17:38:12 T.Kitagawa
'更新日：2019/06/24 (Mon) 16:31:57 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2019, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00M0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00M0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00M0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00M0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00M0)
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
    'Private Const CMstrLocalVersion                 As String = "10.01"
    Private Const CMstrLocalVersion                 As String = "10.02"

    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_McGrouplistVer           As String = "01.00"                     '装置ｸﾞﾙｰﾌﾟ取得
    Private Const CMstrmas_wplist__Ver              As String = "05.01"                     '装置一覧取得
    Private Const CMstrmas_vaconditionVer           As String = "02.00"                     '蒸着処理条件取得
    Private Const CMstrlot_mcgplotlistVer           As String = "04.00"                     '装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄ取得
    Private Const CMstrbat_lotlist_Ver              As String = "03.00"                     'ﾊﾞｯﾁ組ﾛｯﾄ情報取得
    Private Const CMstrbat_change__Ver              As String = "03.00"                     'ﾊﾞｯﾁ組ﾛｯﾄ登録変更
    Private Const CMstrcarrcurstateVer              As String = "05.02"                     'ｷｬﾘｱ状態確認
    Private Const CPstrasm_odfreservereinfoVer      As String = "01.00"                     '貼り合わせ予約情報
    Private Const CPstrasm_hreservegroupVer         As String = "01.00"                     '表面処理予約GROUP
    Private Const CPstrasm_hreserveinfoVer          As String = "01.00"                     '表面処理予約情報

    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN00M0              'ﾛｰｶﾙ機能ID

    '@ﾌﾚｯｸｽｸﾞﾘｯﾄﾞのｶﾗﾑ定数
    Private Const CMlngGridTitleHeight              As Integer = 20                         'ﾀｲﾄﾙの高さ
    Private Const CMlngGridRowHeight                As Integer = 18                         '1明細の高さ
    Private Const CMlngGridTitleCol                 As Integer = 0                          'ﾀｲﾄﾙ列

    '@製品ﾛｯﾄ/ﾓﾆﾀﾛｯﾄ情報(列定義)
    Private Const CMlngvsfLotNoC                    As Integer = 0                          '№
    Private Const CMlngvsfLotWpNoC                  As Integer = 1                          '装置№
    Private Const CMlngvsfLotCarrierIdC             As Integer = 2                          'ｷｬﾘｱID
    Private Const CMlngvsfLotPairCarrierC           As Integer = 3                          '蒸着ﾍﾟｱ
    Private Const CMlngvsfLotHReserveC              As Integer = 4                          '表面処理予約
    Private Const CMlngvsfLotInspectFlagC           As Integer = 5                          '無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ
    Private Const CMlngvsfLotLotIdC                 As Integer = 6                          'ﾛｯﾄID
    Private Const CMlngvsfLotFlowClassC             As Integer = 7                          '種別
    Private Const CMlngvsfLotUseIDC                 As Integer = 8                          '製品区分
    Private Const CMlngvsfLotPriorityC              As Integer = 9                          '優先順位
    Private Const CMlngvsfLotWfNumC                 As Integer = 10                          'WF枚数
    Private Const CMlngvsfLotRecipeIdC              As Integer = 11                         'ﾚｼﾋﾟID
    Private Const CMlngvsfLotLimitTimeC             As Integer = 12                         '時間制限
    Private Const CMlngvsfLotOptionTextC            As Integer = 13                         '作業条件
    Private Const CMlngvsfLotOpIdC                  As Integer = 14                         '大工程
    Private Const CMlngvsfLotStepIdC                As Integer = 15                         '小工程
    Private Const CMlngvsfLotDispatchStartC         As Integer = 16                         '処理開始予定
    Private Const CMlngvsfLotLastUpdateC            As Integer = 17                         '最終更新日
    Private Const CMlngvsfLotWFIDC                  As Integer = 18                         'WFID
    Private Const CMlngvsfLotJigIDC                 As Integer = 19                         '冶具ID
    Private Const CMlngvsfLotLotKindC               As Integer = 20                         'Cfﾌﾗｸﾞ(0：TFT、1：CF)
    '@--------------------------------------------------------------
    '@ メモ:プログラム内のLotKindやPanelKindは全て「Cfフラグ」のこと
    '@--------------------------------------------------------------
    Private Const CMlngvsfLotUldCarrierIdC          As Integer = 21                         'ｱﾝﾛｰﾀﾞｷｬﾘｱID
    Private Const CMlngvsfLotLpFlagC                As Integer = 22                         '大板(Lp)ﾌﾗｸﾞ
    Private Const CMlngvsfLotVaFlagC                As Integer = 23                         '無機ﾌﾗｸﾞ
    Private Const CMlngvsfLotPdIdC                  As Integer = 24                         '機種
    Private Const CMlngvsfLotJBatchIdC              As Integer = 25                         '蒸着ﾊﾞｯﾁID
    Private Const CMlngvsfLotHBatchIdC              As Integer = 26                         '表面処理ﾊﾞｯﾁID

    '@製品ﾛｯﾄ/ﾓﾆﾀﾛｯﾄ情報(ﾀｲﾄﾙ定義)
    Private Const CMstrvsfLotNoT                    As String = "№"                         '№
    Private Const CMstrvsfLotWpNoT                  As String = "1"                         '装置№
    Private Const CMstrvsfLotCarrierIdT             As String = "ｷｬﾘｱID"                    'ｷｬﾘｱID
    Private Const CMstrvsfLotLotIdT                 As String = "ﾛｯﾄID"                     'ﾛｯﾄID
    Private Const CMstrvsfLotFlowClassT             As String = "種"                        '種別
    Private Const CMstrvsfLotUseIDT                 As String = "製品区分"                  '製品区分
    Private Const CMstrvsfLotPriorityT              As String = "優"                        '優先順位
    Private Const CMstrvsfLotWfNumT                 As String = "WF"                        'WF枚数
    Private Const CMstrvsfLotRecipeIdT              As String = "ﾚｼﾋﾟ"                      'ﾚｼﾋﾟ
    Private Const CMstrvsfLotLimitTimeT             As String = "時間制限"                  '時間制限
    Private Const CMstrvsfLotOptionTextT            As String = "作業条件"                  '作業条件
    Private Const CMstrvsfLotOpIdT                  As String = "大工程"                    '大工程
    Private Const CMstrvsfLotStepIdT                As String = "小工程"                    '小工程
    Private Const CMstrvsfLotDispatchStartT         As String = "処理開始予定"              '処理開始予定日時
    Private Const CMstrvsfLotLastUpdateT            As String = "最終更新日"                '最終更新日
    Private Const CMstrvsfLotWFIDT                  As String = "WFID"                      'WFID
    Private Const CMstrvsfLotJigIDT                 As String = "冶具ID"                    '冶具ID
    Private Const CMstrvsfLotLotKindT               As String = "CFフラグ"                  'Cfﾌﾗｸﾞ(0：TFT、1：CF)
    Private Const CMstrvsfLotUldCarrierIdT          As String = "ULｷｬﾘｱID"                 'ｱﾝﾛｰﾀﾞｷｬﾘｱID
    Private Const CMstrvsfLotLpFlagT                As String = "ODFフラグ"                 '大板(Lp)ﾌﾗｸﾞ
    Private Const CMstrvsfLotVaFlagT                As String = "無機フラグ"
    Private Const CMstrvsfLotPdIdT                  As String = "機種"
    Private Const CMstrvsfLotJBatchIdT              As String = "蒸着バッチID"
    Private Const CMstrvsfLotHBatchIdT              As String = "表面処理バッチID"
    Private Const CMstrvsfLotInspectFlagT           As String = "異S1"
    Private Const CMstrvsfLotPairCarrierT           As String = "蒸ﾍﾟｱ"
    Private Const CMstrvsfLotHReserveT              As String = "予約"

    '@製品ﾛｯﾄ/ﾓﾆﾀﾛｯﾄ情報(幅定義)
    Private Const CMlngvsfLotNoW                    As Integer = 25                         '№
    Private Const CMlngvsfLotWpNoW                  As Integer = 25                         '装置№
    Private Const CMlngvsfLotCarrierIdW             As Integer = 100                        'ｷｬﾘｱID
    Private Const CMlngvsfLotLotIdW                 As Integer = 88                         'ﾛｯﾄID
    Private Const CMlngvsfLotFlowClassW             As Integer = 25                         '種別
    Private Const CMlngvsfLotUseIDW                 As Integer = 0                          '製品区分
    Private Const CMlngvsfLotPriorityW              As Integer = 25                         '優先順位
    Private Const CMlngvsfLotWfNumW                 As Integer = 25                         'WF枚数
    Private Const CMlngvsfLotRecipeIdW              As Integer = 67                         'ﾚｼﾋﾟID
    Private Const CMlngvsfLotLimitTimeW             As Integer = 67                         '時間制限
    Private Const CMlngvsfLotOptionTextW            As Integer = 67                         '作業条件
    Private Const CMlngvsfLotOpIdW                  As Integer = 67                         '大工程
    Private Const CMlngvsfLotStepIdW                As Integer = 67                         '小工程
    Private Const CMlngvsfLotDispatchStartW         As Integer = 67                         '処理開始予定
    Private Const CMlngvsfLotLastUpdateW            As Integer = 67                         '最終更新日
    Private Const CMlngvsfLotWFIDW                  As Integer = 0                          'WFID
    Private Const CMlngvsfLotJigIDW                 As Integer = 0                          '冶具ID
    Private Const CMlngvsfLotLotKindW               As Integer = 1                          'Cfﾌﾗｸﾞ(0：TFT、1：CF)
    Private Const CMlngvsfLotUldCarrierIdW          As Integer = 0                          'ｱﾝﾛｰﾀﾞｷｬﾘｱID
    Private Const CMlngvsfLotLpFlagW                As Integer = 0                          '大板(Lp)ﾌﾗｸﾞ
    Private Const CMlngvsfLotVaFlagW                As Integer = 0                          '無機ﾌﾗｸﾞ
    Private Const CMlngvsfLotPdIdW                  As Integer = 0                          '機種
    Private Const CMlngvsfLotJBatchIdW              As Integer = 0                          '蒸着ﾊﾞｯﾁID
    Private Const CMlngvsfLotHBatchIdW              As Integer = 0                          '表面処理ﾊﾞｯﾁID
    Private Const CMlngvsfLotInspectFlagW           As Integer = 25                         '無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ
    Private Const CMlngvsfLotPairCarrierW           As Integer = 25                         '蒸着ﾍﾟｱ
    Private Const CMlngvsfLotHReserveW              As Integer = 25                         '表面処理予約

    '@ﾊﾞｯﾁ編成一覧情報(列定義)
    Private Const CMlngvsfBatListNoC                As Integer = 0                          '№
    Private Const CMlngvsfBatListWpNoC              As Integer = 1                          '装置№
    Private Const CMlngvsfBatListBatchIdC           As Integer = 2                          'ﾊﾞｯﾁID
    Private Const CMlngvsfBatListWfNumC             As Integer = 3                          'WF枚数
    Private Const CMlngvsfBatListRecipeIdC          As Integer = 4                          'ﾚｼﾋﾟID
    Private Const CMlngvsfBatListVaConditionIdC     As Integer = 5                          '蒸着処理条件ID
    Private Const CMlngvsfBatListVaConditionFlagC   As Integer = 6                          '蒸着処理条件制限ﾌﾗｸﾞ(0：無効、1：有効)
    Private Const CMlngvsfBatListLotNumC            As Integer = 7                          '編成ﾛｯﾄ数

    '@ﾊﾞｯﾁ編成一覧情報(ﾀｲﾄﾙ定義)
    Private Const CMstrvsfBatListNoT                As String = "№"                        '№
    Private Const CMstrvsfBatListWpNoT              As String = "1"                         '装置№
    Private Const CMstrvsfBatListBatchIdT           As String = "バッチID"                  'ﾊﾞｯﾁID
    Private Const CMstrvsfBatListWfNumT             As String = "WF"                        'WF枚数
    Private Const CMstrvsfBatListRecipeIdT          As String = "レシピ"                    'ﾚｼﾋﾟ
    Private Const CMstrvsfBatListVaConditionIdT     As String = "蒸着処理条件"              '蒸着処理条件ID
    Private Const CMstrvsfBatListVaConditionFlagT   As String = "蒸着処理条件制限フラグ"    '蒸着処理条件制限ﾌﾗｸﾞ(0：無効、1：有効)
    Private Const CMstrvsfBatListLotNumT            As String = "編成ロット数"              '編成ﾛｯﾄ数

    '@ﾊﾞｯﾁ編成一覧情報(幅定義)
    Private Const CMlngvsfBatListNoW                As Integer = 25                         '№
    Private Const CMlngvsfBatListWpNoW              As Integer = 25                         '装置№
    Private Const CMlngvsfBatListBatchIdW           As Integer = 100                        'ﾊﾞｯﾁID
    Private Const CMlngvsfBatListWfNumW             As Integer = 53                         'WF枚数
    Private Const CMlngvsfBatListRecipeIdW          As Integer = 67                         'ﾚｼﾋﾟID
    Private Const CMlngvsfBatListVaConditionIdW     As Integer = 0                          '蒸着処理条件ID
    Private Const CMlngvsfBatListVaConditionFlagW   As Integer = 0                          '蒸着処理条件制限ﾌﾗｸﾞ(0：無効、1：有効)
    Private Const CMlngvsfBatListLotNumW            As Integer = 109                        '編成ﾛｯﾄ数

    '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧情報(列定義)
    Private Const CMlngvsfBatSeqNumC                As Integer = 0                          '順序
    Private Const CMlngvsfBatCarrierIdC             As Integer = 1                          'ｷｬﾘｱID
    Private Const CMlngvsfBatJigIDC                 As Integer = 2                          '冶具ID
    Private Const CMlngvsfBatLotIdC                 As Integer = 3                          'ﾛｯﾄID
    Private Const CMlngvsfBatLastUpdateC            As Integer = 4                          '最終更新日
    Private Const CMlngvsfBatProductOldNoC          As Integer = 5                          '製品ﾛｯﾄｸﾞﾘｯﾄﾞの行番号("<"ﾎﾞﾀﾝ用)
    Private Const CMlngvsfBatUldCarrierIDC          As Integer = 6                          'ｱﾝﾛｰﾀﾞｰｷｬﾘｱID
    Private Const CMlngvsfBatWFIDC                  As Integer = 7                          'WFID
    Private Const CMlngvsfBatPanelKindC             As Integer = 8                          'Cfﾌﾗｸﾞ(0：TFT、1：CF、NULL：ﾀﾞﾐｰ冶具)
    Private Const CMlngvsfBatVaConditionIDC         As Integer = 9                          '蒸着処理条件
    Private Const CMlngvsfBatWFNumC                 As Integer = 10                         'WF枚数
    Private Const CMlngvsfBatUseIDC                 As Integer = 11                         '製品区分
    Private Const CMlngvsfBatLpFlagC                As Integer = 12                         '大板(Lp)ﾌﾗｸﾞ
    Private Const CMlngvsfBatFlowClassC             As Integer = 13                         '種（種別)
    Private Const CMlngvsfBatVaFlagC                As Integer = 14                         '無機ﾌﾗｸﾞ
    Private Const CMlngvsfBatPdIdC                  As Integer = 15                         '機種
    Private Const CMlngvsfBatJBatchIdC              As Integer = 16                         '蒸着ﾊﾞｯﾁID
    Private Const CMlngvsfBatHBatchIdC              As Integer = 17                         '表面処理ﾊﾞｯﾁID
    Private Const CMlngvsfBatInspectFlagC           As Integer = 18                         '無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ

    '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧情報(ﾀｲﾄﾙ定義)
    Private Const CMstrvsfBatSeqNumT                As String = "順"                        '順序
    Private Const CMstrvsfBatCarrierIdT             As String = "ｷｬﾘｱID"                    'ｷｬﾘｱID
    Private Const CMstrvsfBatJigIDT                 As String = "冶具ID"                    '冶具ID
    Private Const CMstrvsfBatLotIdT                 As String = "ﾛｯﾄID"                  'ﾛｯﾄID
    Private Const CMstrvsfBatLastUpdateT            As String = "最終更新日"                '最終更新日
    Private Const CMstrvsfBatProductOldNoT          As String = "戻り行番号"                '製品ﾛｯﾄｸﾞﾘｯﾄﾞの行番号(<ﾎﾞﾀﾝ用)
    Private Const CMstrvsfBatUldCarrierIDT          As String = "ULｷｬﾘｱID"                 'ｱﾝﾛｰﾀﾞｰｷｬﾘｱID
    Private Const CMstrvsfBatWFIDT                  As String = "WFID"                      'WFID
    Private Const CMstrvsfBatPanelKindT             As String = "Cfフラグ"                  'Cfﾌﾗｸﾞ(0：TFT,1：CF)
    Private Const CMstrvsfBatVaConditionIDT         As String = "蒸着処理条件"              '蒸着処理条件
    Private Const CMstrvsfBatWFNumT                 As String = "WF"                    'WF枚数
    Private Const CMstrvsfBatUseIDT                 As String = "製品区分"                  '製品区分
    Private Const CMstrvsfBatLpFlagT                As String = "ODFフラグ"                 '大板(Lp)ﾌﾗｸﾞ
    Private Const CMstrvsfBatFlowClassT             As String = "種"                        '種（種別)
    Private Const CMstrvsfBatVaFlagT                As String = "無機フラグ"
    Private Const CMstrvsfBatPdIdT                  As String = "機種"
    Private Const CMstrvsfBatJBatchIdT              As String = "蒸着バッチID"
    Private Const CMstrvsfBatHBatchIdT              As String = "表面処理バッチID"
    Private Const CMstrvsfBatInspectFlagT           As String = "異S1"

    '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧情報(幅定義)
    Private Const CMlngvsfBatSeqNumW                As Integer = 25                         '順序
    Private Const CMlngvsfBatCarrierIdW             As Integer = 80                        'ｷｬﾘｱID
    Private Const CMlngvsfBatJigIDW                 As Integer = 88                         '冶具ID
    Private Const CMlngvsfBatLotIdW                 As Integer = 88                         'ﾛｯﾄID
    Private Const CMlngvsfBatLastUpdateW            As Integer = 0                          '最終更新日
    Private Const CMlngvsfBatProductOldNoW          As Integer = 0                          '製品ﾛｯﾄｸﾞﾘｯﾄﾞの行番号(<ﾎﾞﾀﾝ用)
    Private Const CMlngvsfBatUldCarrierIDW          As Integer = 80                        'ｱﾝﾛｰﾀﾞｰｷｬﾘｱID
    Private Const CMlngvsfBatWFIDW                  As Integer = 88                         'WFID
    Private Const CMlngvsfBatPanelKindW             As Integer = 0                          'Cfﾌﾗｸﾞ(0：TFT,1：CF)
    Private Const CMlngvsfBatVaConditionIDW         As Integer = 0                          '蒸着処理条件
    Private Const CMlngvsfBatWFNumW                 As Integer = 30                          'WF枚数
    Private Const CMlngvsfBatUseIDW                 As Integer = 0                          '製品区分
    Private Const CMlngvsfBatLpFlagW                As Integer = 0                          '大板(Lp)ﾌﾗｸﾞ
    Private Const CMlngvsfBatFlowClassW             As Integer = 0                          '種（種別)

    Private Const CMlngvsfBatVaFlagW                As Integer = 0                          '無機ﾌﾗｸﾞ
    Private Const CMlngvsfBatPdIdW                  As Integer = 0                          '機種
    Private Const CMlngvsfBatJBatchIdW              As Integer = 0                          '蒸着ﾊﾞｯﾁID
    Private Const CMlngvsfBatHBatchIdW              As Integer = 0                          '表面処理ﾊﾞｯﾁID
    Private Const CMlngvsfBatInspectFlagW           As Integer = 25                         '無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                  As Integer = 11                         'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 11                         'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColName               As Integer = 0                          '名称列番
    Private Const CMlngCmbGridColID                 As Integer = 1                          'ID列番(非表示項目)
    Private Const CMlngCmbDispCols                  As Integer = 1                          'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbRowHeight                 As Integer = 18                         'ﾘｽﾄ行の高さ
    Private Const CMlngCmbWpNameName                As Integer = 0                          '装置名ｺﾝﾎﾞの名前列
    Private Const CMlngCmbWpNameId                  As Integer = 1                          '装置名ｺﾝﾎﾞのID列
    Private Const CMlngCmbWpNameMaxProcessBox       As Integer = 2                          '装置名ｺﾝﾎﾞの最大処理単位ﾎﾞｯｸｽ数列
    Private Const CMlngCmbWpNameMesModeID           As Integer = 3                          '装置名ｺﾝﾎﾞの運用ﾓｰﾄﾞ列
    Private Const CMlngCmbWpNameEqType              As Integer = 4                          '装置名ｺﾝﾎﾞの装置ﾀｲﾌﾟ(EqType)列

    '@色宣言
    Private Const CMlngEnableFalseForeColor         As Integer = &H80000016                 '灰色(使用不可)
    Private Const CMlngEnableTrueForeColor          As Integer = &H0&                       '黒色
    Private Const CMlngLimitOverForeColor           As Integer = &HFF&                      '赤色

    '@その他
    Private Const CMstrMade                         As String = " まで "                    '時間制限結合文字列
    Private Const CMstrh                            As String = "h"                         '時間制限結合文字列
    Private Const CMstrKouho                        As String = "△"                        '候補
    Private Const CMstrJidou                        As String = "○"                        '自動
    Private Const CMstrKakutei                      As String = "◎"                        '確定
    Private Const CMstrColon                        As String = "："                        'ｺﾛﾝ
    Private Const CMstrMsgNew                       As String = "登録"                      '確定ﾒｯｾｰｼﾞ
    Private Const CMstrMsgEdit                      As String = "変更"                      '確定ﾒｯｾｰｼﾞ
    Private Const CMstrMsgDelete                    As String = "削除"                      '確定ﾒｯｾｰｼﾞ
    Private Const CMstrDummy                        As String = "ダミー"                    'ﾀﾞﾐｰ冶具用
    Private Const CMstrNotUse                       As String = "未使用"                    '未使用処理部識別用
    Private Const CMstrValid                        As String = "有効"                      '有効/無効ﾗﾍﾞﾙ表示用(蒸着処理条件の有効/無効)
    Private Const CMstrInValid                      As String = "無効"                      '有効/無効ﾗﾍﾞﾙ表示用(蒸着処理条件の有効/無効)
    Private Const CMlngGridMaxWpCnt                 As Integer = 13                         'ｸﾞﾘｯﾄﾞの最大装置数
    Private Const CMlngMaxWFCnt                     As Integer = 44                         '最大ﾊﾞｯﾁ組可能WF数(2009/06/18現在未使用)
    Private Const CMstrNoOnline                     As String = "×"                        '無機異物検査ｵﾝﾗｲﾝ処理未

	'蒸着治具紐付け機能改修
	Private Const CMstrJJigCategoryDummy			As String = "D"							'ダミープレート

    '@ﾚｽﾎﾟﾝｽ計測用
    Private Const CMstrFormName                     As String = "frmxxEN00M0"               '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                     As String = "Form_Load"                 'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmbWpNameChange              As String = "cmbWpName_Change"          'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmdLotListClick              As String = "cmdLotList_Click"          'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmdKakuteiClick              As String = "cmdKakutei_Click"          'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmdMoveClick                 As String = "cmdMove_Click"             'ｲﾍﾞﾝﾄ名称
    Private Const CMstrPrvblnUldCarrierChk          As String = "prvblnUldCarrier_Chk"      'ｲﾍﾞﾝﾄ名称
    Private Const CMstrPrvblnMasVaConditionSelProc  As String = "prvblnMasVaConditionSel_Proc" 'ｲﾍﾞﾝﾄ名称
    Private Const CMstrArrowCmdLotConnectedInfoDispClick As String = "cmdLotConnectedInfoDisp_Click"  'ｲﾍﾞﾝﾄ名

    Private buttonProcessing                        As Boolean                              'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                              'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                              'NSYS WindowCloseフラグ

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================

    '@製品ﾛｯﾄ/ﾓﾆﾀﾛｯﾄ情報(可変列定義)
    Private mlngvsfLotNoC                           As Integer                              '№
    Private mlngvsfLotWpStartNoC                    As Integer                              '開始装置№
    Private mlngvsfLotWpEndNoC                      As Integer                              '終了装置№
    Private mlngvsfLotCarrierIdC                    As Integer                              'ｷｬﾘｱID
    Private mlngvsfLotLotIdC                        As Integer                              'ﾛｯﾄID
    Private mlngvsfLotFlowClassC                    As Integer                              '種別
    Private mlngvsfLotUseIDC                        As Integer                              '製品区分
    Private mlngvsfLotPriorityC                     As Integer                              '優先順位
    Private mlngvsfLotWfNumC                        As Integer                              'WF枚数
    Private mlngvsfLotRecipeIdC                     As Integer                              'ﾚｼﾋﾟID
    Private mlngvsfLotLimitTimeC                    As Integer                              '時間制限
    Private mlngvsfLotOptionTextC                   As Integer                              '作業条件
    Private mlngvsfLotOpIdC                         As Integer                              '大工程
    Private mlngvsfLotStepIdC                       As Integer                              '小工程
    Private mlngvsfLotDispatchStartC                As Integer                              '処理開始予定
    Private mlngvsfLotLastUpdateC                   As Integer                              '最終更新日
    Private mlngvsfLotWfIdC                         As Integer                              'WFID
    Private mlngvsfLotJigIDC                        As Integer                              '冶具ID
    Private mlngvsfLotLotKindC                      As Integer                              'Cfﾌﾗｸﾞ(0：TFT、1：CF)
    Private mlngvsfLotUldCarrierIdC                 As Integer                              'ｱﾝﾛｰﾀﾞｷｬﾘｱID
    Private mlngvsfLotLpFlagC                       As Integer                              '大板(Lp)ﾌﾗｸﾞ
    Private mlngvsfLotVaFlagC                       As Integer                              '無機ﾌﾗｸﾞ
    Private mlngvsfLotPdIdC                         As Integer                              '機種
    Private mlngvsfLotJBatchIdC                     As Integer                              '蒸着ﾊﾞｯﾁID
    Private mlngvsfLotHBatchIdC                     As Integer                              '表面処理ﾊﾞｯﾁID
    Private mlngvsfLotInspectFlagC                  As Integer                              '無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ
    Private mlngvsfLotPairCarrierC                  As Integer                              '蒸着ﾍﾟｱ
    Private mlngvsfLotHReserveC                     As Integer                              '表面処理予約

    '@ﾊﾞｯﾁ編成一覧情報(可変列定義)
    Private mlngvsfBatListNoC                       As Integer                              '№
    Private mlngvsfBatListWpStartNoC                As Integer                              '開始装置№
    Private mlngvsfBatListWpEndNoC                  As Integer                              '終了装置№
    Private mlngvsfBatListBatchIdC                  As Integer                              'ﾊﾞｯﾁID
    Private mlngvsfBatListWfNumC                    As Integer                              'WF枚数
    Private mlngvsfBatListRecipeIdC                 As Integer                              'ﾚｼﾋﾟID
    Private mlngvsfBatListVaConditionIdC            As Integer                              '蒸着処理条件ID
    Private mlngvsfBatListVaConditionFlagC          As Integer                              '蒸着処理条件制限ﾌﾗｸﾞ(0：無効、1：有効)
    Private mlngvsfBatListLotNumC                   As Integer                              '編成ﾛｯﾄ数

    '@装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄ構造体
    Private mtypMcGpLotInfo                         As McGpLotInfo                          '装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄ構造体

    '@配列定義
    Private mtypBatLotList                          As BatLotList                           'ﾊﾞｯﾁ組ﾛｯﾄ情報応答構造体
    Private mtypWpList                              As List(Of WpList)                      'WPﾘｽﾄ
    Private mlngWpListCnt                           As Integer                              'WPﾘｽﾄ数
    Private mtypVaConditionListAns                  As VaConditionListAns                   '蒸着処理条件取得結果格納用

    '@その他
    Private mstrOldMcGroupID                        As String                               '前回ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟID格納
    Private mstrInputClassDivision                  As String                               '入力処理区分(NULL:新規、05:削除、06:変更)
    Private mstrBeforeUldCarrierID                  As String                               '編集前ULDｷｬﾘｱID
    Private mblnInEditKbn                           As Boolean                              '編集中区分(True:編集中、False:未編集)
    Private mblnFirstActivateFlag                   As Boolean                              '初回ﾌｫｰﾑｱｸﾃｨﾌﾞ判定ﾌﾗｸﾞ(True：初回、False：2回目以降)
    Private mlngOldcmbWpNameIndex                   As Integer                              '前回装置名ｺﾝﾎﾞINDEX
    Private mlngDispConditionIndex                  As Integer                              '表示ｵﾌﾟｼｮﾝﾎﾞﾀﾝINDEX
    '@↓2019/06/06 (Thu) 12:02:53 Y.Yoneyama **************************************************
    Private mblnWpDetailDisp                        As Boolean                              'ﾊﾞｯﾁ組装置の詳細表示有無(True:表示、False:非表示)
    '@↑2019/06/06 (Thu) 12:02:53 Y.Yoneyama **************************************************


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
    '作成日：2004/07/22 (Thu) 20:31:23 T.Kitagawa
    '更新日：2009/06/04 (Thu) 13:21:23 N.Kojima
    '備　考：
    '　　　：2009/06/04 (Thu) 13:21:23 N.Kojima     無機対応。(案件№03560)
    Private Sub Form_Load()

        Dim lblnAns             As Boolean          '結果格納
        Dim ltypMcGroupList     As McGroupList      '装置ｸﾞﾙｰﾌﾟ格納構造体

        Try

            '@=======================
            '@ 機能ﾊﾞｰｼﾞｮﾝ判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN00M0, CMstrLocalVersion)

            '@戻り値の判定
            If lblnAns = False Then
                '@異常終了の場合

                '@=======================
                '@ ﾒﾆｭｰｻｲｽﾞ変更処理
                '@=======================
                Call pubMenuExpand_Disp()

                '@=======================
                '@ ﾌｫｰﾑ終了時処理
                '@=======================
                Call Form_QueryUnload(False, New FormClosingEventArgs(New CloseReason,  False))

                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)


            '@=======================
            '@ ﾌｫｰﾑ初期化処理
            '@=======================
            Call prvFrmxxEN00M0_Init()

            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            '@=======================
            '@ 装置ｸﾞﾙｰﾌﾟ取得
            '@=======================
            '@MSG送信処理：処理区分：2G⇒ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ指定
            lblnAns = pubblnMasMcGroupList_Sel(CMstrmas_McGrouplistVer, _
                                               CPstrCD2G, _
                                               pstrSBID, _
                                               ltypMcGroupList)

            '@MSG[装置ｸﾞﾙｰﾌﾟ取得]の結果判定
            If lblnAns = False Then

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                Exit Sub
            End If

            '@=======================
            '@ 装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞの設定
            '@=======================
            Call prvCmbMcGpName_Disp(ltypMcGroupList)

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)

            '@初回ﾌｫｰﾑｱｸﾃｨﾌﾞ判定ﾌﾗｸﾞに"True：初回"をｾｯﾄ
            mblnFirstActivateFlag = True

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"True：正常"をｾｯﾄ
            pblnFormLoad = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Load"                  'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
    '作成日：2004/10/07 (Thu) 10:36:12 Y.Yamagishi
    '更新日：2009/06/04 (Thu) 13:48:18 N.Kojima
    '備　考：
    '　　　：2005/01/12 (Wed) 10:48:44 S.Deguchi    処理見直し(False判別をTrue判別に変更)
    '　　　：2009/06/04 (Thu) 13:48:18 N.Kojima     無機対応。(案件№03560)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@初回ﾌｫｰﾑｱｸﾃｨﾌﾞ判定ﾌﾗｸﾞが"True：初回"か
            If mblnFirstActivateFlag = True Then
                '@初回の場合

                '@2回目以降は処理させない為にﾌﾗｸﾞに"False：2回目以降"をｾｯﾄ
                mblnFirstActivateFlag = False

                '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞのﾘｽﾄ内容が1件か
                If cmbMcGpName.ListCount = 1 Then

                    '@1件の場合は自動表示する
                    cmbMcGpName.ListIndex = 0

                    '@=======================
                    '@ 最新取得ﾎﾞﾀﾝ処理
                    '@=======================
                    Call cmdLotList_Click(sender, e)

                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Activate"              'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
    '作成日：2004/07/23 (Fri) 15:29:11 T.Kitagawa
    '更新日：2009/06/04 (Thu) 13:54:38 N.Kojima
    '備　考：
    '　　　：2005/01/12 (Wed) 10:54:45 S.Deguchi    処理見直し(空欄以外Validateを全てValidateに変更)
    '　　　：2009/06/04 (Thu) 13:54:38 N.Kojima     無機対応。(案件№03560)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name

                '@〓 [ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ 〓
                Case cmbMcGpName.Name

                    '@Enterｷｰか
                    If e.KeyCode = Keys.Return Then

                        '@=======================
                        '@ ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞのValidate処理
                        '@=======================
                        Call cmbMcGpName_Validate(True, New CancelEventArgs)

                    End If

                '@〓 その他 〓
                Case Else

                    '@Enterの場合
                    If e.KeyCode = Keys.Return Then
                        If ActiveControl IsNot vsfProduct.Editor And
                           ActiveControl IsNot vsfBatList.Editor And 
                           ActiveControl IsNot vsfBat.Editor Then
                            '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄし、ｷｰｺｰﾄﾞを初期化
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                        End If
                    End If
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_KeyDown"               'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
    '作成日：2004/07/23 (Fri) 09:37:44 T.Kitagawa
    '更新日：2009/06/04 (Thu) 13:57:30 N.Kojima
    '備　考：
    '　　　：2004/11/01 (Mon) 16:35:21 T.Kitagawa   閉じるﾎﾞﾀﾝ統合
    '　　　：2009/06/04 (Thu) 13:57:30 N.Kojima     無機対応。(案件№03560)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm                 As Boolean              'ACT開放結果格納用
        Dim ltypMcGpLotInfo             As McGpLotInfo          '装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄ構造体
        Dim ltypVaConditionListAns      As VaConditionListAns   '蒸着処理条件取得結果格納用

        Try

            '@Windowの"×"にて閉じたか
            If mblnCloseFromControlMenu Then

                '@=======================
                '@ 閉じるﾎﾞﾀﾝ処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender,e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload

            End If

            '@ﾓｼﾞｭｰﾙ変数/構造体の初期化
            If Not mtypBatLotList.typBatLot Is Nothing Then
                mtypBatLotList.typBatLot.Clear()
            End If
            If Not mtypWpList Is Nothing Then
                mtypWpList.Clear()
            End If
            mlngWpListCnt = 0
            mtypMcGpLotInfo = ltypMcGpLotInfo                   '装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄ構造体
            mtypVaConditionListAns = ltypVaConditionListAns     '蒸着処理条件格納構造体

            '@Act初期化ﾌﾗｸﾞが"True：成功"か
            If pblnActInitFlg = True Then
                '@Actを自前で初期化した場合

                '@=======================
                '@ ACTｵﾌﾞｼﾞｪｸﾄの開放
                '@=======================
                lblnAnsTerm = pubblnAct_Term

                '@ACTｵﾌﾞｼﾞｪｸﾄ開放処理が正常に行われたか
                If lblnAnsTerm = True Then

                    '@処理なし(ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了)
                End If
            Else
                '@Actを自前で初期化していない場合

                '@=======================
                '@ ﾒﾆｭｰｻｲｽﾞ変更処理
                '@=======================
                Call pubMenuExpand_Disp()

            End If

            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_QueryUnload"           'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGpName_Change
    '機　能：[ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/23 (Fri) 15:38:23 T.Kitagawa
    '更新日：2009/06/04 (Thu) 14:26:04 N.Kojima
    '備　考：
    '　　　：2005/01/12 (Wed) 14:20:41 S.Deguchi    ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ変更に退避領域をｸﾘｱ処理をChangeｲﾍﾞﾝﾄに追加
    '　　　：2009/06/04 (Thu) 14:26:04 N.Kojima     無機対応。(案件№03560)
    Private Sub cmbMcGpName_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGpName.Change

        Try

            '@=======================
            '@ ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ内容の初期化
            '@=======================
            Call prvALLInfo_Init()

            '@ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟID退避変数の初期化
            mstrOldMcGroupID = vbNullString

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbMcGpName_Change"         'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGpName_CloseUp
    '機　能：[ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/23 (Fri) 15:57:58 T.Kitagawa
    '更新日：2009/06/04 (Thu) 14:27:18 N.Kojima
    '備　考：
    '　　　：2005/01/12 (Wed) 10:58:07 S.Deguchi    空欄以外は処理を行わなくしていた処理を修正
    '　　　：2009/06/04 (Thu) 14:27:18 N.Kojima     無機対応。(案件№03560)
    Private Sub cmbMcGpName_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGpName.CloseUp

        Try

            '@=======================
            '@ ﾊﾞｯﾁ装置ｺﾝﾎﾞのValidate処理
            '@=======================
            Call cmbMcGpName_Validate(True, New CancelEventArgs)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbMcGpName_CloseUp"        'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGpName_Validate
    '機　能：[ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ　選択確定時処理(Validate処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/07/26 (Mon) 10:19:13 T.Kitagawa
    '更新日：2009/06/04 (Thu) 14:28:23 N.Kojima
    '備　考：
    '　　　：2005/01/12 (Wed) 12:54:56 S.Deguchi    ﾌｫｰｶｽｾｯﾄ処理修正
    '　　　：2009/06/04 (Thu) 14:28:23 N.Kojima     無機対応。(案件№03560)
    Private Sub cmbMcGpName_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbMcGpName.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@[ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞが未選択か
            If cmbMcGpName.Text = vbNullString Then

                If ActiveControl.Name <> cmbMcGpName.Name Then
                    Exit Sub
                End If

                '@ﾊﾞｯﾁ編成ﾌﾚｰﾑの[装置名]ｺﾝﾎﾞが有効か
                If cmbWpName.Enabled = True Then

                    '@[装置名]ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbWpName)
                Else
                    '@[装置名]ｺﾝﾎﾞが無効の場合

                    '@[製品ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞが有効か
                    If vsfProduct.Enabled = True Then

                        '@[製品ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfProduct)
                    Else
                        '@[閉じる]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
                End If

                Exit Sub
            End If


            '@前回選択のﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟIDと今回選択IDが同じか
            If cmbMcGpName.Value = mstrOldMcGroupID Then
                '@同じ場合

                If ActiveControl.Name <> cmbMcGpName.Name Then
                    Exit Sub
                End If

                '@[装置名]ｺﾝﾎﾞが有効か
                If cmbWpName.Enabled = True Then

                    '@[装置名]ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbWpName)
                Else
                    '@[装置名]ｺﾝﾎﾞが無効の場合

                    '@[製品ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞが有効か
                    If vsfProduct.Enabled = True Then

                        '@[製品ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfProduct)
                    Else
                        '@[閉じる]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
                End If

                Exit Sub
            End If

            '@各種ﾎﾞﾀﾝを有効にする
            cmdLotList.Enabled = True       '最新取得
            cmdClear.Enabled = True         '取消

            '@=======================
            '@ 最新取得ﾎﾞﾀﾝ処理
            '@=======================
            Call cmdLotList_Click(sender, e)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbMcGpName_Validate"       'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：optKubun_Click
    '機　能：[表示]ｵﾌﾟｼｮﾝﾎﾞﾀﾝ　ﾁｪｯｸON/OFF時処理
    '引　数：Index：ｵﾌﾟｼｮﾝﾎﾞﾀﾝIndex
    '戻り値：なし
    '作成日：2009/07/24 (Fri) 09:51:38 N.Kojima
    '更新日：2009/07/24 (Fri) 09:51:38
    '備　考：
    Private Sub optKubun_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optKubun0.CheckedChanged, _
                                                                                     optKubun1.CheckedChanged, _
                                                                                     optKubun2.CheckedChanged, _
                                                                                     optKubun3.CheckedChanged
        Try

            'NSYS チェックオフの場合処理を抜ける
            If sender.Checked = False Then
                Exit Sub
            End If

            '@選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝのｲﾝﾃﾞｯｸｽを退避
            Select Case sender.Name
                Case "optKubun0"
                    mlngDispConditionIndex = 0
                Case "optKubun1"
                    mlngDispConditionIndex = 1
                Case "optKubun2"
                    mlngDispConditionIndex = 2
                Case "optKubun3"
                    mlngDispConditionIndex = 3
            End Select

            '@=======================
            '@ 製品ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ初期化処理
            '@=======================
            Call prvVsfProduct_Init()

            '@=======================
            '@ 製品ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ表示処理
            '@=======================
            Call prvVsfProduct_Disp()


            '@-----------------------
            '@ 各種ｺﾝﾄﾛｰﾙの制御(条件によりTrue：有効にする)
            '@-----------------------
            '@①[最新取得]ﾎﾞﾀﾝを有効にする
            cmdLotList.Enabled = True

            '@②[製品ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞにﾃﾞｰﾀが1件以上あるか
            If vsfProduct.Rows.Count > 1 Then
                'NSYS 表示クリックまたは、＜ボタンで遷移した場合はグリッドを有効とする
                If Mid$(Me.ActiveControl.Name,1,8) = "optKubun" Or Me.ActiveControl.Name = "cmdRemove" Then
                    vsfProduct.Enabled = True       '有効
                End If
            Else
                'NSYS スクロール位置初期化
                vsfProduct.LeftCol = 0
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "optKubun_Click"             'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfProduct_BeforeSort
    '機　能：[製品ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ｿｰﾄ前処理
    '引　数：Col    ：列番号
    '　　　：Order  ：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/07/26 (Mon) 09:56:41 T.Kitagawa
    '更新日：2009/06/04 (Thu) 15:21:14 N.Kojima
    '備　考：
    '　　　：2009/06/04 (Thu) 15:21:14 N.Kojima     無機対応。(案件№03560)
    Private Sub vsfProduct_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfProduct.BeforeSort

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfProduct.Rows.Count <= vsfProduct.Rows.Fixed Then
                Return
            End If

            '@=======================
            '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納処理(ｸﾞﾘｯﾄﾞ、保持列)(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfBeforeSort(vsfProduct, CMlngGridTitleCol)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfProduct_BeforeSort"      'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfProduct_AfterSort
    '機　能：[製品ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ｿｰﾄ後処理
    '引　数：Col    ：列番号
    '　　　：Order  ：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/07/26 (Mon) 09:42:02 T.Kitagawa
    '更新日：2009/06/04 (Thu) 15:22:20 N.Kojima
    '備　考：
    '　　　：2009/06/04 (Thu) 15:22:20 N.Kojima     無機対応。(案件№03560)
    Private Sub vsfProduct_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfProduct.AfterSort

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfProduct.Rows.Count <= vsfProduct.Rows.Fixed Then
                Return
            End If

            '@=======================
            '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納処理(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfAfterSort(vsfProduct, CMlngGridTitleCol)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfProduct_AfterSort"       'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfProduct_EnterCell
    '機　能：[製品ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ｶﾚﾝﾄ行列変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 15:18:13 T.Kitagawa
    '更新日：2012/03/28 (Wed) 13:13:52 T.Oide
    '備　考：
    '　　　：2005/07/12 (Tue) 17:56:54 N.Kojima     装置が選択されていて、運用ﾓｰﾄﾞが「S2」の場合、">"ﾎﾞﾀﾝを無効に(不具合№2932)
    '　　　：2009/06/04 (Thu) 15:22:20 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/11/18 (Wed) 10:07:43 N.Kojima     [有効/無効]ﾗﾍﾞﾙの初期化処理追加。(案件№03790)
    '　　　：2012/03/28 (Wed) 13:13:52 T.Oide       無機装置追加対応(REQ-1303)テストで既存の不具合発見のため修正
    Private Sub vsfProduct_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfProduct.EnterCell

        Dim lFixedStyle     As CellStyle

        Try

            '@[ > ]ﾎﾞﾀﾝを無効にする
            cmdMove.Enabled = False
            cmdMoveAll.Enabled = False

            '@製品ﾛｯﾄが無いか
            If vsfProduct.Row < 1 Then
                Exit Sub
            End If
                
            '@蒸着ﾊﾞｯﾁID有無により「'TFT/CF情報表示」表示制御
            If vsfProduct.GetData(vsfProduct.Row, mlngvsfLotJBatchIdC) = vbNullString Then
                cmdLotConnectedInfoDisp.Enabled = False
            Else
                cmdLotConnectedInfoDisp.Enabled = True
            End If

            '@ﾊﾞｯﾁ編成済み一覧のﾃﾞｰﾀ行が選択されていて、かつ未編集状態か
            '(蒸着機の場合、編集ボタンは有効にならない。この状態で連続して蒸着機のﾊﾞｯﾁが組めないので修正)
            If vsfBatList.Row > 0 And _
                mblnInEditKbn = False Then

                '@入力処理区分の初期化(NULL：新規)
                mstrInputClassDivision = vbNullString

                '@各種ﾎﾞﾀﾝを無効にする
                cmdEdit.Enabled = False                     '編集
                cmdDelete.Enabled = False                   '削除
                cmdKakutei.Enabled = False                  '確定
                cmdMove.Enabled = False                     '">"
                cmdRemove.Enabled = False                   '"<"
                cmdClear.Enabled = False                    '取消
                cmdDummySelect.Enabled = False              'ﾀﾞﾐｰ冶具選択
                cmdMonitorLotList.Enabled = False           'ﾓﾆﾀ選択

                '@ﾊﾞｯﾁ編成一覧のﾀｲﾄﾙ行へﾌｫｰｶｽｾｯﾄ
                vsfBatList.Row = 0
                vsfBatList.ShowCell(0, 0)

                '@ﾊﾞｯﾁ編成情報の初期化
                '@ﾃｷｽﾄ内のｸﾘｱ
                cmbWpName.Enabled = True                    '装置名ｺﾝﾎﾞ
                cmbWpName.Text = vbNullString               '装置名ｺﾝﾎﾞ
                lblMaxLotCnt.Text = vbNullString            '最大ﾛｯﾄ数
                lblBatchID.Text = vbNullString              'ﾊﾞｯﾁID
                lblRecipeID.Text = vbNullString             'ﾚｼﾋﾟID
                lblBatLotWFCnt.Text = vbNullString          'ﾊﾞｯﾁ組WF枚数
                lblVaCondition.Text = vbNullString          '蒸着処理条件
                lblVaConditionFlag.Text = vbNullString      '(蒸着処理条件)有効/無効

                '@[ﾊﾞｯﾁ組予定ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞを有効にする
                vsfBat.Enabled = True

                With vsfBat

                    .Clear(ClearFlags.UserData)

                    '@ﾀｲﾄﾙの設定
                    lFixedStyle = .Styles.Fixed
                    lFixedStyle.ForeColor = Color.Yellow         '文字色
                    lFixedStyle.BackColor = Color.Navy           '背景色

                    .Rows(CMlngGridTitleCol).Height = CMlngGridTitleHeight

                    '@行数の初期設定
                    .Rows.Count = 1
                End With

            End If


            '@-----------------------
            '@ 現在状態ﾁｪｯｸ
            '@-----------------------
            '@①既にﾊﾞｯﾁ編成中か
            If vsfProduct.GetCellRange(vsfProduct.Row, mlngvsfLotNoC).StyleDisplay.ForeColor = ColorTranslator.FromWin32(CMlngEnableFalseForeColor) Then
                Exit Sub
            End If

            '@②ﾚｼﾋﾟ未設定か
            If Trim$(vsfProduct.GetData(vsfProduct.Row, mlngvsfLotRecipeIdC)) = vbNullString Then
                Exit Sub
            End If

            '@③装置名が未選択か
            If cmbWpName.Text = vbNullString Then
                Exit Sub
            End If

            '@④最大ﾛｯﾄ数が設定されていないか
            If IsNumeric(lblMaxLotCnt.Text) = False Then
                Exit Sub
            End If

            '@⑤ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ﾃﾞｰﾀ数が最大ﾛｯﾄ数より大きいか
            If vsfBat.Rows.Count - 1 > CLng(lblMaxLotCnt.Text) Then
                Exit Sub
            End If

            '@⑥ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞが無効か
            If vsfBat.Enabled = False Then
                Exit Sub
            End If


            '@★ 製品ﾛｯﾄの使用可能装置の判定により処理分岐 ★
            Select Case vsfProduct.GetData(vsfProduct.Row, cmbWpName.ListIndex + 1)

                '@〓 "△" or "○" or "◎" 〓
                Case CMstrKouho, CMstrJidou, CMstrKakutei

                    '@使用可能

                '@〓 その他(NULL) 〓
                Case Else

                    '@使用不可
                    Exit Sub

            End Select

            '@ﾚｼﾋﾟ未設定か
            If lblRecipeID.Text = vbNullString Then

                '@[ > ]ﾎﾞﾀﾝを有効にする
                cmdMove.Enabled = True
            Else
                '@[製品ﾛｯﾄ一覧]の選択行のﾚｼﾋﾟと表示されているﾚｼﾋﾟが同じか
                If vsfProduct.GetData(vsfProduct.Row, mlngvsfLotRecipeIdC) = lblRecipeID.Text Then

                    '@[ > ]ﾎﾞﾀﾝを有効にする
                    cmdMove.Enabled = True
                End If
            End If

            '表面処理予約一括移動
            If vsfProduct.GetData(vsfProduct.Row, mlngvsfLotHReserveC) <> vbNullString Then
                cmdMoveAll.Enabled = True
            End If

            '@[装置名]ｺﾝﾎﾞの値取得列を「運用ﾓｰﾄﾞ」列に
            cmbWpName.ValueCol = CMlngCmbWpNameMesModeID

            '@選択装置の運用ﾓｰﾄﾞが「S2」か(※S2は手動ﾊﾞｯﾁ組禁止)
            If cmbWpName.Value = CPstrS2 Then

                '@[ > ]ﾎﾞﾀﾝを無効にする
                cmdMove.Enabled = False
                cmdMoveAll.Enabled = False
            End If
            
            '@編成方式=自動
            If lblMethod.Text = CPstrAuto Then

                '@[ > ]ﾎﾞﾀﾝを無効にする
                cmdMove.Enabled = False
                cmdMoveAll.Enabled = False
            End If

            '@[装置名]ｺﾝﾎﾞの値取得列を「装置名」列に戻す
            cmbWpName.ValueCol = CMlngCmbWpNameName

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfProduct_EnterCell"       'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    ''' <summary>
    ''' [>>]
    ''' 表面処理用に一括移動
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdMoveAll_Click(sender As Object, e As EventArgs) Handles cmdMoveAll.Click
        
        Dim lstrSelectWPEqType As String = vbNullString
        Dim lstrRecipeRef As String = vbNullString
        Dim lstrHReserveRef As String = vbNullString
        Dim lintRowCf As Integer
        Dim lintRowTft As Integer
        Dim lintRowDefault As Integer
        Dim lblnErr As Boolean = False
        Dim lstrKindList = New List(Of String) 


        Try

            'EQ_TYPE取得
            cmbWpName.ValueCol = CMlngCmbWpNameEqType
            lstrSelectWPEqType = cmbWpName.Value
            cmbWpName.ValueCol = CMlngCmbWpNameName         

            'EQ_TYPE=20：表面処理
            '表面処理専用なのでそれ以外は終了
            If lstrSelectWPEqType <> CPstrEqTypeHyoumenSyori Then
                Exit Sub
            End If

            With vsfProduct
                '選択時のRowを退避
                lintRowDefault = .Row

                '基準情報の取得(レシピ、表面処理予約)
                lstrRecipeRef = .GetData(.Row, mlngvsfLotRecipeIdC)
                lstrHReserveRef = .GetData(.Row, mlngvsfLotHReserveC)

                '基準情報が無い場合は終了
                If lstrRecipeRef = vbNullString Or lstrHReserveRef = vbNullString Then
                    Exit Sub
                End If

                '補足
                '表面処理のバッチ編成は
                '蒸着バッチ(TFT/CF)の対で処理
                '搭載順はCFが先、TFTが後

                '基準情報と同じロットを検索
                'CFロット検索
                For lintRowCf = 1 To .Rows.Count - 1
                    If .GetData(lintRowCf, mlngvsfLotRecipeIdC) = lstrRecipeRef And _
                        .GetData(lintRowCf, mlngvsfLotHReserveC) = lstrHReserveRef And _
                        .GetData(lintRowCf, mlngvsfLotLotKindC) = CPstrOne Then

                        '蒸着ペア
                        Dim lstrJyoPair = .GetData(lintRowCf, mlngvsfLotPairCarrierC)

                        '行選択
                        .Row = lintRowCf
                        Call vsfProduct_EnterCell(sender, e)

                        '[>]有効
                        If cmdMove.Enabled = True
                            '[>]を押す
                            Me.buttonProcessing = False
                            Call cmdMove_Click(sender, e)
                            lstrKindList.Add(CPstrOne)

                        '[>]無効
                        Else
                            '一括移動を中止する(作業者のマニュアル編成で対応してもらう)
                            lblnErr = True
                            Exit For
                        End If

                        '蒸着ペアがあり
                        '基準情報と同じロットを検索
                        'TFTロット検索
                        If lstrJyoPair <> vbNullString Then
                            For lintRowTft = 1 To .Rows.Count - 1
                                If .GetData(lintRowTft, mlngvsfLotRecipeIdC) = lstrRecipeRef And _
                                    .GetData(lintRowTft, mlngvsfLotHReserveC) = lstrHReserveRef And _
                                    .GetData(lintRowTft, mlngvsfLotLotKindC) = CPstrZero And _
                                    .GetData(lintRowTft, mlngvsfLotPairCarrierC) = lstrJyoPair Then

                                    '行選択
                                    .Row = lintRowTft
                                    Call vsfProduct_EnterCell(sender, e)

                                    '[>]を押す
                                    If cmdMove.Enabled = True
                                        Me.buttonProcessing = False
                                        Call cmdMove_Click(sender, e)
                                        lstrKindList.Add(CPstrZero)
                        
                                    '[>]無効
                                    Else
                                        '一括移動を中止する(作業者のマニュアル編成で対応してもらう)
                                        lblnErr = True
                                        Exit For
                                    End If
                                End If
                            Next

                        '蒸着ペアなし
                        Else
                            '一括移動を中止する(作業者のマニュアル編成で対応してもらう)
                            lblnErr = True
                            Exit For
                        End if
                    End If

                    'Errがある場合は終了
                    If lblnErr = True Then
                        Exit For
                    End If
                Next

                If lblnErr = True Then
                    '<TRM178W>$$ロット[%1]にデータ不備がある為、一括移動を中止しました。$手動でバッチ編成をしてください。
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0178, .GetData(.Row, mlngvsfLotLotIdC))
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Else

                    'CF/TFT順序の再確認
                    Dim lintListCount As Integer
                    For lintListCount = 0 To lstrKindList.Count - 1
                        '偶数(CF)
                        If lintListCount Mod 2 = 0 Then
                            If lstrKindList(lintListCount) <> CPstrOne Then
                                lblnErr = True
                                Exit For
                            End If
                        '奇数(TFT)
                        Else
                            If lstrKindList(lintListCount) <> CPstrZero Then
                                lblnErr = True
                                Exit For
                            End If
                        End If
                    Next

                    If lblnErr = True Then
                        '"<TRM179W>$$一括移動を実施しましたが[CF/TFT]の並びに不備があります。$バッチ編成を確認してください。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0179)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    End If

                    '選択Rowに戻す
                    .Row = lintRowDefault
                End If
            End With

            Exit Sub

        Catch ex As Exception
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMoveAll_Click"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：cmdMove_Click
    '機　能：[ > ]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 15:14:25 T.Kitagawa
    '更新日：2016/07/04 (Mon) 15:45:39 T.Oide
    '備　考：
    '　　　：2009/06/04 (Thu) 15:33:24 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/24 (Fri) 14:19:06 N.Kojima     無機対応Phase2、製品区分追加。(案件№03661)
    '　　　：2009/08/05 (Wed) 17:15:58 N.Kojima     無機対応Phase3、表面処理ﾊﾞｯﾁ組時の制約、FILLERのｱﾝﾛｰﾀﾞｷｬﾘｱ設定処理を追加。(案件№03704)
    '　　　：2009/11/18 (Wed) 10:43:11 N.Kojima     (蒸着処理条件)有効/無効ﾗﾍﾞﾙが"無効"の場合は、蒸着処理条件を無視してﾊﾞｯﾁ組出来るように改善。(案件№03790)
    '　　　：2010/07/05 (Mon) 11:56:54 T.Oide       No.04123対応(斜方蒸着ﾚｼﾋﾟ自動選択)
    '　　　：2012/03/06 (Tue) 13:24:49 T.Oide       無機装置追加対応(REQ-1303)
    Private Sub cmdMove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMove.Click

        Dim llngCnt                     As Integer              '汎用ｶｳﾝﾀ
        Dim llngBatWFCnt                As Integer              'ﾊﾞｯﾁ組予定ﾛｯﾄのWF枚数
        Dim llngWFCommaPosition         As Integer              'ｶﾝﾏ位置格納用(WF)
        Dim llngWFBeforeCommaPosition   As Integer              '1つ前のｶﾝﾏ位置格納用(WF)
        Dim llngWFLength                As Integer              'WF文字列長格納用(WF)
        Dim llngJigCommaPosition        As Integer              'ｶﾝﾏ位置格納用(冶具)
        Dim llngJigBeforeCommaPosition  As Integer              '1つ前のｶﾝﾏ位置格納用(冶具)
        Dim llngJigLength               As Integer              '冶具ID文字列長格納用(冶具)
        Dim lblnAns                     As Boolean              '通信結果格納
        Dim lblnEditBatchErrFlag        As Boolean              'ﾊﾞｯﾁ編成ｴﾗｰﾌﾗｸﾞ(True：ｴﾗｰ、False：初期値)
        Dim lstrVsfProductWFID          As String               '製品ﾛｯﾄ一覧のWFID
        Dim lstrVsfProductJigID         As String               '製品ﾛｯﾄ一覧の冶具ID
        Dim lstrSelectWPEqType          As String               '選択装置の装置ﾀｲﾌﾟ
        Dim lstrCallName                As String               '蒸着処理条件取得処理に渡す呼び元処理名
        Dim lstrWFID                    As String               'WFID
        Dim rowflg                      As Boolean              'NSYS 行選択有無フラグ

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@-----------------------
            '@ ﾊﾞｯﾁ編成情報の設定
            '@-----------------------


            '@[装置名]ｺﾝﾎﾞの値取得列を「装置ﾀｲﾌﾟ(EqType)」列に変更
            cmbWpName.ValueCol = CMlngCmbWpNameEqType

            '@選択装置の装置ﾀｲﾌﾟを格納
            lstrSelectWPEqType = cmbWpName.Value

            '@[装置名]ｺﾝﾎﾞの値取得列を「装置名」列に戻す
            cmbWpName.ValueCol = CMlngCmbWpNameName


            With vsfProduct

                '@-----------------------
                '@ 編成順ﾁｪｯｸ(表面処理装置)
                '@
                '@ << 仕様 >>
                '@ 　表面処理装置のﾊﾞｯﾁ組順は「製品ﾛｯﾄ(PRODUCT(TEG))⇒ﾓﾆﾀﾛｯﾄ(MONITOR)⇒ﾌｨﾙﾀﾞﾐｰ(FILLER(DUMMY))⇒その他」の
                '@ 　順でﾊﾞｯﾁ組されていなければ装置的にﾀﾞﾒだそうです。
                '@ 　例)PRODUCT(TEG) Only ：OK、PRODUCT(TEG) ⇒ MONITOR：OK、PRODUCT(TEG) ⇒ FILLER(DUMMY)：OK
                '@ 　　 MONITOR Only ：OK、MONITOR ⇒ FILLER(DUMMY) ：OK
                '@ 　　 FILLER(DUMMY)  Only ：OK
                '@ 　　 MONITOR ⇒ PRODUCT(TEG) ：NG、FILLER(DUMMY) ⇒ PRODUCT(TEG) ：NG、FILLER(DUMMY) ⇒ MONITOR ：NG
                '@-----------------------

                '@装置ﾀｲﾌﾟが"20：表面処理装置"か
                If lstrSelectWPEqType = CPstrEqTypeHyoumenSyori Then

                    '@ﾊﾞｯﾁ組予定ﾛｯﾄ数が1件以上あるか(1ﾛｯﾄ目は何が編成されてもOK)
                    If vsfBat.Rows.Count - 1 >= 1 Then

                        '@ﾊﾞｯﾁ編成ｴﾗｰﾌﾗｸﾞの初期化
                        lblnEditBatchErrFlag = False

                        '@★ ﾊﾞｯﾁ組予定ﾛｯﾄの製品区分により処理分岐 ★
                        Select Case UCase(.GetData(.Row, mlngvsfLotUseIDC))

                            '@〓 PRODUCT(TEG)：製品ﾛｯﾄ、実験品ﾛｯﾄ 〓
                            Case CPstrUseIDProduct, CPstrUseIDTeg

                                '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧の最終行の製品区分が"MONITOR" or "FILLER(DUMMY)"か
                                If vsfBat.GetData(vsfBat.Rows.Count - 1, CMlngvsfBatUseIDC) = CPstrUseIDMonitor Or _
                                    vsfBat.GetData(vsfBat.Rows.Count - 1, CMlngvsfBatUseIDC) = CPstrUseIDFiller Or _
                                    vsfBat.GetData(vsfBat.Rows.Count - 1, CMlngvsfBatUseIDC) = CPstrUseIDDummy Then

                                    '@ﾊﾞｯﾁ編成ｴﾗｰﾌﾗｸﾞに"True：ｴﾗｰ"をｾｯﾄ
                                    lblnEditBatchErrFlag = True
                                End If


                            '@〓 MONITOR：ﾓﾆﾀﾛｯﾄ 〓
                            Case CPstrUseIDMonitor

                                '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧の最終行の製品区分が"FILLER(DUMMY)"か
                                If (vsfBat.GetData(vsfBat.Rows.Count - 1, CMlngvsfBatUseIDC) = CPstrUseIDFiller Or _
                                    vsfBat.GetData(vsfBat.Rows.Count - 1, CMlngvsfBatUseIDC) = CPstrUseIDDummy) Then

                                    '@ﾊﾞｯﾁ編成ｴﾗｰﾌﾗｸﾞに"True：ｴﾗｰ"をｾｯﾄ
                                    lblnEditBatchErrFlag = True
                                End If


                            '@〓 FILLER(DUMMY)：ﾌｨﾙﾀﾞﾐｰﾛｯﾄ、ﾀﾞﾐｰﾛｯﾄ 〓
                            Case CPstrUseIDFiller, CPstrUseIDDummy

                                '@ﾊﾞｯﾁ編成順の最下位なので上位の順がOKなら良い


                            '@〓 その他 〓
                            Case Else

                                '@制約なし

                        End Select

                        '@編成順ﾁｪｯｸでｴﾗｰがあったか
                        If lblnEditBatchErrFlag = True Then

                            '@表示ﾒｯｾｰｼﾞ変換
                            '@"<TRM1SW>$$表面処理装置のバッチ組は装置仕様に従い、
                            '@ $[製品ロット]⇒[モニタロット]⇒[フィルダミーロット]
                            '@ $の順でバッチ組してください。"のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001S)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            Exit Sub
                        End If
                    End If
                End If

                '@ﾚｼﾋﾟ未設定か
                If lblRecipeID.Text = vbNullString Then

                    '@ﾚｼﾋﾟを表示する
                    lblRecipeID.Text = .GetData(.Row, mlngvsfLotRecipeIdC)
                End If

            End With


            '@-----------------------
            '@ [ﾊﾞｯﾁ組予定ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞの表示処理
            '@-----------------------
            With vsfBat

                '@WF数を格納
                llngBatWFCnt = CLng(vsfProduct.GetData(vsfProduct.Row, mlngvsfLotWfNumC))

                '@★ 選択装置の装置ﾀｲﾌﾟにより処理分岐 ★
                Select Case lstrSelectWPEqType

                    '@〓 19：斜方蒸着装置 〓
                    Case CPstrEqTypeJyoucyaku

                        '@蒸着処理条件取得処理に渡す呼び元処理名をｾｯﾄ
                        lstrCallName = CMstrCmdMoveClick

                        '@=======================
                        '@ 蒸着処理条件取得処理
                        '@=======================
                        lblnAns = prvblnMasVaConditionSel_Proc(lstrCallName)

                        '@蒸着処理条件取得処理結果が"False：処理失敗"か
                        If lblnAns = False Then
                            Exit Sub
                        End If


                        '@=======================
                        '@ 蒸着ﾊﾞｯﾁ組時ﾁｪｯｸ処理
                        '@=======================
                        lblnAns = prvblnJBatchSet_Chk(llngBatWFCnt)

                        '@蒸着ﾊﾞｯﾁ組時ﾁｪｯｸ処理結果が"False：ｴﾗｰあり"か
                        If lblnAns = False Then
                            Exit Sub
                        End If


                        '@-----------------------
                        '@ ﾊﾞｯﾁ編成ﾛｯﾄ一覧の表示処理
                        '@-----------------------
                        '@ｶﾝﾏ位置格納用変数の初期化
                        llngWFCommaPosition = 0
                        llngWFBeforeCommaPosition = 0
                        llngWFLength = 0
                        llngJigCommaPosition = 0
                        llngJigBeforeCommaPosition = 0
                        llngJigLength = 0

                        '@製品ﾛｯﾄ一覧のWFID、冶具IDを格納
                        lstrVsfProductWFID = vsfProduct.GetData(vsfProduct.Row, mlngvsfLotWfIdC)
                        lstrVsfProductJigID = vsfProduct.GetData(vsfProduct.Row, mlngvsfLotJigIDC)

                        '@"順(処理部)"分ﾙｰﾌﾟ
                        For llngCnt = 1 To .Rows.Count - 1

                            lstrWFID = .GetData(llngCnt, CMlngvsfBatWFIDC)

                            '@対象行がﾃﾞｰﾀ可能(NULL or 未使用)か
                            '@ ※既にﾊﾞｯﾁ組予定ﾃﾞｰﾀが入力されている場合、その行(処理部)はｽｷｯﾌﾟ
                            If lstrWFID = vbNullString Or _
                                InStr(1, lstrWFID, CMstrNotUse) <> 0 Then

                                '@ﾛｯﾄIDの設定
                                .SetData(llngCnt, CMlngvsfBatLotIdC, _
                                    vsfProduct.GetData(vsfProduct.Row, mlngvsfLotLotIdC))

                                '@最終更新日の設定
                                .SetData(llngCnt, CMlngvsfBatLastUpdateC, _
                                    vsfProduct.GetData(vsfProduct.Row, mlngvsfLotLastUpdateC))

                                '@製品ﾛｯﾄｸﾞﾘｯﾄﾞの行番号("<"ﾎﾞﾀﾝ用)
                                .SetData(llngCnt, CMlngvsfBatProductOldNoC, _
                                    vsfProduct.GetData(vsfProduct.Row, mlngvsfLotNoC))

                                '@WF枚数
                                .SetData(llngCnt, CMlngvsfBatWFNumC, CPstrOne)

                                '@Cfﾌﾗｸﾞ(通常ﾊﾞｯﾁ装置の場合もCfﾌﾗｸﾞの格納列として値を格納しておく)
                                .SetData(llngCnt, CMlngvsfBatPanelKindC, _
                                    vsfProduct.GetData(vsfProduct.Row, mlngvsfLotLotKindC))

                                '@CFﾛｯﾄ
                                If .GetData(llngCnt, CMlngvsfBatPanelKindC) = CPstrOne Then
                                    Dim newStyle1 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngCfColor")
                                    newStyle1.BackColor = ColorTranslator.FromWin32(CPlngCfColor)
                                    Dim cellRange1 As CellRange = .GetCellRange(llngCnt, CMlngvsfBatLotIdC)
                                    cellRange1.Style = newStyle1
                                '@CFﾛｯﾄ以外
                                Else
                                    Dim newStyle1 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngTftColor")
                                    newStyle1.BackColor = ColorTranslator.FromWin32(CPlngTftColor)
                                    Dim cellRange1 As CellRange = .GetCellRange(llngCnt, CMlngvsfBatLotIdC)
                                    cellRange1.Style = newStyle1
                                End If
                                
                                '@製品区分
                                .SetData(llngCnt, CMlngvsfBatUseIDC, _
                                    vsfProduct.GetData(vsfProduct.Row, mlngvsfLotUseIDC))
                                    
                                '@大板(Lp)ﾌﾗｸﾞ
                                .SetData(llngCnt, CMlngvsfBatLpFlagC, _
                                    vsfProduct.GetData(vsfProduct.Row, mlngvsfLotLpFlagC))
                                 
                                '@種別
                                .SetData(llngCnt, CMlngvsfBatFlowClassC, _
                                    vsfProduct.GetData(vsfProduct.Row, mlngvsfLotFlowClassC))
                                   
                                '@無機ﾌﾗｸﾞ
                                .SetData(llngCnt, CMlngvsfBatVaFlagC, _
                                    vsfProduct.GetData(vsfProduct.Row, mlngvsfLotVaFlagC))
                        
                                '@機種
                                .SetData(llngCnt, CMlngvsfBatPdIdC, _
                                    vsfProduct.GetData(vsfProduct.Row, mlngvsfLotPdIdC))
                                
                                '@蒸着ﾊﾞｯﾁID
                                .SetData(llngCnt, CMlngvsfBatJBatchIdC, _
                                    vsfProduct.GetData(vsfProduct.Row, mlngvsfLotJBatchIdC))
                                
                                '@表面処理ﾊﾞｯﾁID
                                .SetData(llngCnt, CMlngvsfBatHBatchIdC, _
                                    vsfProduct.GetData(vsfProduct.Row, mlngvsfLotHBatchIdC))
                                    
                                '@無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ
                                .SetData(llngCnt, CMlngvsfBatInspectFlagC, _
                                    vsfProduct.GetData(vsfProduct.Row, mlngvsfLotInspectFlagC))
                                    
                                '@ｵﾝﾗｲﾝ未
                                If .GetData(llngCnt, CMlngvsfBatInspectFlagC) <> CPstrFlagOn Then
                                    Dim newStyle2 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngInspectNg")
                                    newStyle2.BackColor = ColorTranslator.FromWin32(CPlngInspectNg)
                                    Dim cellRange2 As CellRange = .GetCellRange(llngCnt, CMlngvsfBatInspectFlagC)
                                    cellRange2.Style = newStyle2
                                Else
                                    Dim newStyle2 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngEnableTrueColor")
                                    newStyle2.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                                    Dim cellRange2 As CellRange = .GetCellRange(llngCnt, CMlngvsfBatInspectFlagC)
                                    cellRange2.Style = newStyle2
                                End If
                                                    
                                '@-----------------------
                                '@ 冶具IDの表示
                                '@-----------------------
                                '@製品ﾛｯﾄ一覧の冶具ID列のｶﾝﾏの位置を検索
                                llngJigCommaPosition = InStr(llngJigBeforeCommaPosition + 1, lstrVsfProductJigID, CPstrComma)

                                '@1冶具(0冶具は有り得ない)のみか(0だと",(ｶﾝﾏ)"が無かったことになる)
                                If llngJigCommaPosition = 0 Then

                                    '@初回の検索で"ｶﾝﾏなし"で冶具ID文字列がNULL以外の場合は、1冶具と見なす
                                    If llngJigBeforeCommaPosition = 0 And _
                                        lstrVsfProductJigID <> vbNullString Then

                                        '@製品ﾛｯﾄ一覧の冶具ID列の情報をそのまま格納
                                        .SetData(llngCnt, CMlngvsfBatJigIDC, lstrVsfProductJigID)
                                    Else

                                        llngJigLength = Len(lstrVsfProductJigID) - llngJigBeforeCommaPosition

                                        '@後ろからｶﾝﾏまでの1枚の冶具IDをｾｯﾄ
                                        .SetData(llngCnt, CMlngvsfBatJigIDC, _
                                            Strings.Right$(lstrVsfProductJigID, llngJigLength))
                                    End If
                                Else
                                    '@1冶具以上存在する場合

                                    '@ｶﾝﾏまでの1枚の冶具IDをｾｯﾄ
                                    .SetData(llngCnt, CMlngvsfBatJigIDC, _
                                        Mid$(lstrVsfProductJigID, llngJigBeforeCommaPosition + 1, (llngJigCommaPosition - llngJigBeforeCommaPosition - 1)))
                                End If

                                '@今格納した冶具IDまでのｶﾝﾏ位置を格納
                                llngJigBeforeCommaPosition = llngJigCommaPosition


                                '@-----------------------
                                '@ WFIDの表示
                                '@-----------------------
                                '@製品ﾛｯﾄ一覧のWFID列のｶﾝﾏの位置を検索
                                llngWFCommaPosition = InStr(llngWFBeforeCommaPosition + 1, lstrVsfProductWFID, CPstrComma)

                                '@1WF(0WFは有り得ない)のみか(0だと",(ｶﾝﾏ)"が無かったことになる)
                                If llngWFCommaPosition = 0 Then

                                    '@初回の検索で"ｶﾝﾏなし"でWFID文字列がNULL以外の場合は、1WFと見なす
                                    If llngWFBeforeCommaPosition = 0 And _
                                        lstrVsfProductWFID <> vbNullString Then

                                        '@製品ﾛｯﾄ一覧のWFID列の情報をそのまま格納
                                        .SetData(llngCnt, CMlngvsfBatWFIDC, lstrVsfProductWFID)

                                    Else

                                        llngWFLength = Len(lstrVsfProductWFID) - llngWFBeforeCommaPosition

                                        '@後ろからｶﾝﾏまでの1枚のWFIDをｾｯﾄ
                                        .SetData(llngCnt, CMlngvsfBatWFIDC, _
                                            Strings.Right$(lstrVsfProductWFID, llngWFLength))
                                    End If

                                    '@1枚にしろ、最終WFにしろこれ以上候補がないのでﾙｰﾌﾟ抜け
                                    Exit For

                                Else
                                    '@1WF以上存在する場合

                                    '@ｶﾝﾏまでの1枚のWFIDをｾｯﾄ
                                    .SetData(llngCnt, CMlngvsfBatWFIDC, _
                                        Mid$(lstrVsfProductWFID, llngWFBeforeCommaPosition + 1, (llngWFCommaPosition - llngWFBeforeCommaPosition - 1)))
                                End If

                                '@今格納したWFまでのｶﾝﾏ位置を格納
                                llngWFBeforeCommaPosition = llngWFCommaPosition

                                
                            End If
                        Next llngCnt


                        If .Row > 0 Then
                            '@選択行のWFIDがNULL以外か
                            If .GetData(.Row, CMlngvsfBatWFIDC) <> vbNullString Then

                                '@NULL以外の場合、ﾀﾞﾐｰ冶具選択ﾎﾞﾀﾝを無効にする
                                cmdDummySelect.Enabled = False
                            Else
                                '@NULLの場合、ﾀﾞﾐｰ冶具選択ﾎﾞﾀﾝを有効にする
                                cmdDummySelect.Enabled = True
                            End If
                        Else
                            '未選択の場合、ﾀﾞﾐｰ冶具選択ﾎﾞﾀﾝを無効にする
                            cmdDummySelect.Enabled = False
                        End If

                        '@=======================
                        '@ ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ　ｶﾚﾝﾄ行列変更時処理
                        '@=======================
                        Call vsfBat_EnterCell(sender, e)


                    '@〓 その他(基板ﾊﾞｯﾁ装置、組立の上記以外のﾊﾞｯﾁ装置) 〓
                    Case Else

                        rowflg = True
                        If .Row < 1 Then
                            '行選択なし
                            rowflg = False
                        End If

                        '@行数の加算
                        RemoveHandler vsfBat.EnterCell,AddressOf vsfBat_EnterCell
                        .Rows.Count = .Rows.Count + 1
                        AddHandler vsfBat.EnterCell,AddressOf vsfBat_EnterCell

                        '@順序の設定
                        If IsNumeric(.GetData(.Rows.Count - 2, CMlngvsfBatSeqNumC)) = True Then
                            
                            .SetData(.Rows.Count - 1, CMlngvsfBatSeqNumC, _
                                .GetData(.Rows.Count - 2, CMlngvsfBatSeqNumC) + 1)      '前行へ加算
                        Else
                            .SetData(.Rows.Count - 1, CMlngvsfBatSeqNumC, 1)            '初期設定
                        End If

                        '行選択なし
                        If rowflg = False Then
                            RemoveHandler vsfBat.EnterCell,AddressOf vsfBat_EnterCell
                            .Row = 0
                            AddHandler vsfBat.EnterCell,AddressOf vsfBat_EnterCell
                        End If

                        '@ｷｬﾘｱIDの設定
                        .SetData(.Rows.Count - 1, CMlngvsfBatCarrierIdC, _
                            vsfProduct.GetData(vsfProduct.Row, mlngvsfLotCarrierIdC))

                        '@ﾛｯﾄIDの設定
                        .SetData(.Rows.Count - 1, CMlngvsfBatLotIdC, _
                            vsfProduct.GetData(vsfProduct.Row, mlngvsfLotLotIdC))

                        '@最終更新日の設定
                        .SetData(.Rows.Count - 1, CMlngvsfBatLastUpdateC, _
                            vsfProduct.GetData(vsfProduct.Row, mlngvsfLotLastUpdateC))

                        '@製品ﾛｯﾄｸﾞﾘｯﾄﾞの行番号("<"ﾎﾞﾀﾝ用)
                        .SetData(.Rows.Count - 1, CMlngvsfBatProductOldNoC, _
                            vsfProduct.GetData(vsfProduct.Row, mlngvsfLotNoC))

                        '@WF枚数
                        .SetData(.Rows.Count - 1, CMlngvsfBatWFNumC, _
                            vsfProduct.GetData(vsfProduct.Row, mlngvsfLotWfNumC))

                        '@Cfﾌﾗｸﾞ(通常ﾊﾞｯﾁ装置の場合もCfﾌﾗｸﾞの格納列として値を格納しておく)
                        .SetData(.Rows.Count - 1, CMlngvsfBatPanelKindC, _
                            vsfProduct.GetData(vsfProduct.Row, mlngvsfLotLotKindC))
                            
                        '@CFﾛｯﾄ
                        If .GetData(.Rows.Count - 1, CMlngvsfBatPanelKindC) = CPstrOne Then
                            Dim newStyle3 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngCfColor")
                            newStyle3.BackColor = ColorTranslator.FromWin32(CPlngCfColor)
                            Dim cellRange3 As CellRange = .GetCellRange(.Rows.Count - 1, CMlngvsfBatLotIdC)
                            cellRange3.Style = newStyle3
                        '@CFﾛｯﾄ以外
                        Else
                            Dim newStyle3 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngTftColor")
                            newStyle3.BackColor = ColorTranslator.FromWin32(CPlngTftColor)
                            Dim cellRange3 As CellRange = .GetCellRange(.Rows.Count - 1, CMlngvsfBatLotIdC)
                            cellRange3.Style = newStyle3
                        End If
                        
                        '@製品区分
                        .SetData(.Rows.Count - 1, CMlngvsfBatUseIDC, _
                            vsfProduct.GetData(vsfProduct.Row, mlngvsfLotUseIDC))

                        '@大板(Lp)ﾌﾗｸﾞ
                        .SetData(.Rows.Count - 1, CMlngvsfBatLpFlagC, _
                            vsfProduct.GetData(vsfProduct.Row, mlngvsfLotLpFlagC))
                            
                        '@種別
                        .SetData(.Rows.Count - 1, CMlngvsfBatFlowClassC, _
                            vsfProduct.GetData(vsfProduct.Row, mlngvsfLotFlowClassC))
                            
                        '@無機ﾌﾗｸﾞ
                        .SetData(.Rows.Count - 1, CMlngvsfBatVaFlagC, _
                            vsfProduct.GetData(vsfProduct.Row, mlngvsfLotVaFlagC))
                                
                        '@機種
                        .SetData(.Rows.Count - 1, CMlngvsfBatPdIdC, _
                            vsfProduct.GetData(vsfProduct.Row, mlngvsfLotPdIdC))
                                
                        '@蒸着ﾊﾞｯﾁID
                        .SetData(.Rows.Count - 1, CMlngvsfBatJBatchIdC, _
                            vsfProduct.GetData(vsfProduct.Row, mlngvsfLotJBatchIdC))
                                
                        '@表面処理ﾊﾞｯﾁID
                        .SetData(.Rows.Count - 1, CMlngvsfBatHBatchIdC, _
                            vsfProduct.GetData(vsfProduct.Row, mlngvsfLotHBatchIdC))

                        '@無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ
                        .SetData(.Rows.Count - 1, CMlngvsfBatInspectFlagC, _
                            vsfProduct.GetData(vsfProduct.Row, mlngvsfLotInspectFlagC))
                            
                        '@ｵﾝﾗｲﾝ未
                        If .GetData(llngCnt, CMlngvsfBatInspectFlagC) <> CPstrFlagOn Then
                            Dim newStyle4 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngInspectNg")
                            newStyle4.BackColor = ColorTranslator.FromWin32(CPlngInspectNg)
                            Dim cellRange4 As CellRange = .GetCellRange(.Rows.Count - 1, CMlngvsfBatInspectFlagC)
                            cellRange4.Style = newStyle4
                        Else
                            Dim newStyle4 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngEnableTrueColor")
                            newStyle4.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                            Dim cellRange4 As CellRange = .GetCellRange(.Rows.Count - 1, CMlngvsfBatInspectFlagC)
                            cellRange4.Style = newStyle4
                        End If

                        '@選択装置が"20：表面処理装置"か
                        If lstrSelectWPEqType = CPstrEqTypeHyoumenSyori Then

                            '@対象ﾛｯﾄが"FILLER"ﾛｯﾄ or "DUMMY"ﾛｯﾄか、またはTeg品(GG)か
                            ' Teg実際にはﾀﾞﾐｰもｷｬﾘｱ交換しないので、実情に合わせて修正
                            If vsfProduct.GetData(vsfProduct.Row, mlngvsfLotUseIDC) = CPstrUseIDFiller Or _
                                vsfProduct.GetData(vsfProduct.Row, mlngvsfLotUseIDC) = CPstrUseIDDummy Or _
                                vsfProduct.GetData(vsfProduct.Row, mlngvsfLotFlowClassC) = CPstrFlowClassGG Then
                                
                                '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDにﾛｰﾀﾞｷｬﾘｱIDをｾｯﾄする(仕様)
                                .SetData(.Rows.Count - 1, CMlngvsfBatUldCarrierIDC, _
                                    vsfProduct.GetData(vsfProduct.Row, mlngvsfLotCarrierIdC))
                            Else
                                '@"FILLER"ﾛｯﾄ or "DUMMY"ﾛｯﾄ以外の場合
                                
                                '@Cfﾌﾗｸﾞは0か(TFTか)　または、Lpﾌﾗｸﾞは1か(ODFか)
                                If vsfProduct.GetData(vsfProduct.Row, mlngvsfLotLotKindC) = CPstrZero Or _
                                   vsfProduct.GetData(vsfProduct.Row, mlngvsfLotLpFlagC) = CPstrOne Then
                                    
                                    '@TFTかODFの場合はULDｷｬﾘｱは、製品ﾛｯﾄ一覧に格納されているULDｷｬﾘｱIDをｾｯﾄする(仕様)
                                    .SetData(.Rows.Count - 1, CMlngvsfBatUldCarrierIDC, _
                                        vsfProduct.GetData(vsfProduct.Row, mlngvsfLotUldCarrierIdC))
                                Else
                                    
                                    '@CF小板の場合は、ULDｷｬﾘｱIDにLDｷｬﾘｱIDをｾｯﾄする(仕様)
                                    .SetData(.Rows.Count - 1, CMlngvsfBatUldCarrierIDC, _
                                        vsfProduct.GetData(vsfProduct.Row, mlngvsfLotCarrierIdC))
                                End If
                                
                            End If
                            
                            '@WF_IDの情報をｺﾋﾟｰする(ﾊﾞｯﾁ組ﾒｯｾｰｼﾞ送信で使用する
                            .SetData(.Rows.Count - 1, CMlngvsfBatWFIDC, _
                                vsfProduct.GetData(vsfProduct.Row, mlngvsfLotWfIdC))
                            
                        End If

                        '@高さ設定
                        .Rows(.Rows.Count - 1).Height = CMlngGridRowHeight

                End Select

                '@=======================
                '@ ﾊﾞｯﾁ組WF枚数再計算処理
                '@=======================
                Call prvBatLotWFCnt_Cal()

                '@製品一覧ｸﾞﾘｯﾄﾞの該当行ForeColerを灰色に変更する
                Dim newStyle5 As CellStyle
                Dim cellRange5 As CellRange
                For llngCnt = mlngvsfLotNoC To mlngvsfLotLastUpdateC
                    newStyle5 = vsfProduct.Styles.Add("CustomStyle_ForeColor_CMlngEnableFalseForeColor_A" + vsfProduct.Row.ToString + llngCnt.ToString)
                    newStyle5.ForeColor = ColorTranslator.FromWin32(CMlngEnableFalseForeColor)
                    newStyle5.BackColor = vsfProduct.GetCellRange(vsfProduct.Row, llngCnt).StyleDisplay.BackColor
                    cellRange5 = vsfProduct.GetCellRange(vsfProduct.Row, llngCnt)
                    cellRange5.Style = newStyle5
                Next

                '@編集中区分の設定(編集中)
                mblnInEditKbn = True        'True：編集中

                '@各種ﾎﾞﾀﾝ制御
                cmdMove.Enabled = False     '">"：無効
                cmdClear.Enabled = True     '取消：有効
                cmdMoveAll.Enabled = False

                '@選択装置が"20：表面処理装置"か
                If lstrSelectWPEqType = CPstrEqTypeHyoumenSyori Then

                    '@一旦、確定ﾎﾞﾀﾝを有効にする
                    cmdKakutei.Enabled = True

                    For llngCnt = 1 To .Rows.Count - 1

                        '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULLか
                        If .GetData(llngCnt, CMlngvsfBatUldCarrierIDC) = vbNullString Then

                            '@確定ﾎﾞﾀﾝを無効にする
                            cmdKakutei.Enabled = False
                        End If
                    Next llngCnt
                Else
                    '@選択装置が"20：表面処理装置"以外

                    '@確定ﾎﾞﾀﾝを有効にする
                    cmdKakutei.Enabled = True
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdMove_Click"              'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRemove_Click
    '機　能：[ < ]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 15:15:08 T.Kitagawa
    '更新日：2016/07/04 (Mon) 15:43:52 T.Oide
    '備　考：
    '　　　：2004/09/09 (Thu) 14:06:16 N.Kasai　    旧№から現在位置を特定する(製品一覧をｿｰﾄされた場合の対応)追加
    '　　　：2005/08/03 (Wed) 13:42:08 N.Kasai      対象ｷｬﾘｱIDから構造体に格納されたINDEXを取得する。№2979
    '　　　：2005/09/14 (Wed) 10:38:31 T.Kitagawa   処理開始予定日を追加(不具合№2972)
    '　　　：2006/03/28 (Tue) 18:01:25 N.Kojima     時間制限不備の修正。(不具合№3444関連)
    '　　　：2009/06/04 (Thu) 15:33:24 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/24 (Fri) 14:27:29 N.Kojima     無機対応Phase2、製品区分追加。(案件№03661)
    '　　　：2009/11/18 (Wed) 11:14:45 N.Kojima     (蒸着処理条件)有効/無効ﾗﾍﾞﾙの初期化処理追加。(案件№03790)
    '　　　：2012/06/25 (Mon) 11:38:03 T.Oide       ウェハー数が正常に入らない不具合対応
    Private Sub cmdRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRemove.Click

        Dim llngCnt                     As Integer              'ｶｳﾝﾀ(汎用)
        Dim llngCnt2                    As Integer              'ｶｳﾝﾀ2(汎用)
        Dim llngvsfBatProductOldNo      As Integer              '製品ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞの旧№
        Dim llngListCnt                 As Integer              '配列Index
        Dim llngMcGpLotListCnt          As Integer              '装置仕掛ﾛｯﾄﾃﾞｰﾀｶｳﾝﾄ
        Dim llngMcGpLotListWFListCnt    As Integer              '装置仕掛ﾛｯﾄのWFﾘｽﾄﾃﾞｰﾀｶｳﾝﾄ
        Dim llngMcGpLotListWPListCnt    As Integer              '装置仕掛ﾛｯﾄのWPﾘｽﾄﾃﾞｰﾀｶｳﾝﾄ
        Dim lstrOldNoC                  As String               '旧№退避
        Dim lstrCarrierID               As String               '対象ｷｬﾘｱID格納
        Dim lstrWFID                    As String               '連結版WFID格納
        Dim lstrJigID                   As String               '連結版冶具ID格納
        Dim lstrSelectWPEqType          As String               '選択装置の装置ﾀｲﾌﾟ
        Dim lstrLimitTime               As String               '制限時間ﾌｫｰﾏｯﾄ用変数
        Dim lstrTmpWFID                 As Object               'ｶﾝﾏ区切りのWF_IDからｳｪﾊｰ数を求めるときの作業用
        Dim lstrTmpWFIDCnt              As Integer              '上記WFの枚数を格納

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@******************************************************************************
            '@★当Functionの処理概要
            '@　■製品ﾛｯﾄ一覧に表示されている場合は、ｸﾞﾚｰ表示を解除する
            '@　■製品ﾛｯﾄ一覧に表示されていない場合は、新規行として製品ﾛｯﾄ一覧に追加する
            '@　　※但し、蒸着ﾊﾞｯﾁ組の際に設定された、ﾀﾞﾐｰ冶具・未使用処理部は製品ﾛｯﾄ一覧には戻さない(当然ですが…)
            '@　■蒸着ﾊﾞｯﾁ組ﾛｯﾄ戻しの際は、同一ﾛｯﾄIDのﾃﾞｰﾀを検索し、WF情報・冶具情報を結合して戻す
            '@******************************************************************************


            '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞにﾃﾞｰﾀが1件以下か
            If vsfBat.Rows.Count <= 1 Then
                Exit Sub
            End If


            '@編集中区分の設定(編集中)
            mblnInEditKbn = True            'True：編集中
            cmdClear.Enabled = True         '取消ﾎﾞﾀﾝ：有効

            '@装置名ｺﾝﾎﾞの値取得列を「装置ﾀｲﾌﾟ(EqType)」列に変更
            cmbWpName.ValueCol = CMlngCmbWpNameEqType

            '@選択装置の装置ﾀｲﾌﾟを格納
            lstrSelectWPEqType = cmbWpName.Value

            '@装置名ｺﾝﾎﾞの値取得列を「装置名」列に戻す
            cmbWpName.ValueCol = CMlngCmbWpNameName


            '@-----------------------
            '@ 製品ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞの設定
            '@-----------------------
            '@戻しﾊﾞｯﾁ組予定ﾛｯﾄがﾓﾆﾀﾛｯﾄ以外か
            If vsfBat.GetData(vsfBat.Row, CMlngvsfBatSeqNumC) > 0 And _
                vsfBat.GetData(vsfBat.Row, CMlngvsfBatUseIDC) <> CPstrUseIDMonitor Then

                '@旧№格納
                lstrOldNoC = vsfBat.GetData(vsfBat.Row, CMlngvsfBatProductOldNoC)

                '@旧№が数値か
                If IsNumeric(lstrOldNoC) = True Then

                    '@製品区分別表示にした為、装置仕掛ﾛｯﾄﾘｽﾄから対象ﾛｯﾄを探す
                    For llngCnt = 0 To mtypMcGpLotInfo.lngMcGpLotListCnt - 1

                        '@まずは戻し対象のﾛｯﾄと装置仕掛ﾛｯﾄﾘｽﾄのﾛｯﾄが同じかﾁｪｯｸ
                        If mtypMcGpLotInfo.typMcGpLotList(llngCnt).strLotID = _
                            vsfBat.GetData(vsfBat.Row, CMlngvsfBatLotIdC) Then
                            '@同じﾛｯﾄIDが見つかった場合

                            '@現在「全て」が選択されている場合
                            If optKubun0.Checked = True Then

                                '@「全て」が選択されている場合は、処理なし

                            Else
                                '@「全て」以外の場合

                                '@★ 製品区分により処理分岐 ★
                                Select Case UCase(mtypMcGpLotInfo.typMcGpLotList(llngCnt).strUseId)

                                    '@〓 PRODUCT(TEG)：製品ﾛｯﾄ、試作/実験品ﾛｯﾄ 〓
                                    Case CPstrUseIDProduct, CPstrUseIDTeg

                                        '@表示を"製品ﾛｯﾄ"に変更
                                        optKubun1.Checked = True

                                    '@〓 MONITOR：ﾓﾆﾀﾛｯﾄ 〓
                                    Case CPstrUseIDMonitor

                                        '@表示を"ﾓﾆﾀﾛｯﾄ"に変更
                                        optKubun2.Checked = True

                                    '@〓 FILLER or DUMMY：ﾀﾞﾐｰﾛｯﾄ 〓
                                    Case CPstrUseIDFiller, CPstrUseIDDummy

                                        '@表示を"ﾀﾞﾐｰﾛｯﾄ"に変更
                                        optKubun3.Checked = True

                                End Select
                            End If


                            '@現在位置を特定する(製品ﾛｯﾄ一覧をｿｰﾄされた場合の対応)
                            For llngCnt2 = 1 To vsfProduct.Rows.Count - 1

                                '@再描画した製品ﾛｯﾄ一覧の中から対象ﾛｯﾄを探す
                                If vsfProduct.GetData(llngCnt2, mlngvsfLotLotIdC) = _
                                    vsfBat.GetData(vsfBat.Row, CMlngvsfBatLotIdC) Then

                                    '@製品ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞの現在№
                                    llngvsfBatProductOldNo = llngCnt2
                                    Exit For
                                End If
                            Next llngCnt2
                        End If
                    Next llngCnt


                    '@製品ﾛｯﾄｸﾞﾘｯﾄﾞの行番号(戻し用)が有る場合はForeColerを黒色に戻す
                    Dim newStyle As CellStyle
                    Dim cellRange As CellRange
                    For llngCnt = mlngvsfLotNoC To mlngvsfLotLastUpdateC
                        newStyle = vsfProduct.Styles.Add("CustomStyle_ForeColor_CMlngEnableTrueForeColor_B" + llngvsfBatProductOldNo.ToString + llngCnt.ToString)
                        newStyle.ForeColor = ColorTranslator.FromWin32(CMlngEnableTrueForeColor)
                        newStyle.BackColor = vsfProduct.GetCellRange(llngvsfBatProductOldNo, llngCnt).StyleDisplay.BackColor
                        cellRange = vsfProduct.GetCellRange(llngvsfBatProductOldNo, llngCnt)
                        cellRange.Style = newStyle
                    Next

                    '@制限時間がｵｰﾊﾞｰの場合は赤色を設定
                    If InStr(vsfProduct.GetData(llngvsfBatProductOldNo, mlngvsfLotLimitTimeC), CMstrMade & StrConv(CPstrMinus, vbNarrow)) > 0 Then

                        '@ForColorの変更
                        Dim newStyle2 As CellStyle = vsfProduct.Styles.Add("CustomStyle_ForeColor_CMlngLimitOverForeColor_C")
                        newStyle2.ForeColor = ColorTranslator.FromWin32(CMlngLimitOverForeColor)
                        Dim cellRange2 As CellRange = vsfProduct.GetCellRange(llngvsfBatProductOldNo, mlngvsfLotLimitTimeC)
                        cellRange2.Style = newStyle2   '赤色
                    End If
                Else
                    '@新規行の場合は製品ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞへ追加する(編集でロットをバッチから外す場合）

                    '@以下の条件を全て満たす場合、製品ﾛｯﾄ一覧にﾃﾞｰﾀを追加
                    '@　①ﾊﾞｯﾁ組予定ﾛｯﾄ一覧の選択行がﾃﾞｰﾀ行
                    '@　②ﾊﾞｯﾁ編成一覧の選択行もﾃﾞｰﾀ行
                    '@　③ﾊﾞｯﾁ組予定ﾛｯﾄ一覧の選択行のﾃﾞｰﾀがﾀﾞﾐｰ冶具以外
                    If vsfBat.Row > 0 And _
                        vsfBatList.Row > 0 And _
                        vsfBat.GetData(vsfBat.Row, CMlngvsfBatLotIdC) <> vbNullString Then

                        Dim typMcGpLotListtmp = New McGpLotList
                        With vsfProduct

                            '@-----------------------
                            '@ ﾊﾞｯﾁ組予定ﾛｯﾄ一覧からの戻し
                            '@-----------------------

                            '@行数の加算
                            .Rows.Count = .Rows.Count + 1

                            '@戻し情報を装置仕掛ﾛｯﾄに格納する為、ﾘｽﾄ要素を+1する
                            llngMcGpLotListCnt = mtypMcGpLotInfo.lngMcGpLotListCnt + 1
                            mtypMcGpLotInfo.lngMcGpLotListCnt = llngMcGpLotListCnt

                            '@ForeColor色設定
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngEnableTrueForeColor_D")
                            newStyle.ForeColor = ColorTranslator.FromWin32(CMlngEnableTrueForeColor)
                            Dim cellRange As CellRange = .GetCellRange(.Rows.Count - 1, CMlngGridTitleCol, .Rows.Count - 1, .Cols.Count - 1)
                            cellRange.Style = newStyle      '黒色

                            '@ｸﾞﾘｯﾄの設定
                            .SetData(.Rows.Count - 1, mlngvsfLotNoC, .Rows.Count - 1)                '№

                            For llngCnt = mlngvsfLotWpStartNoC To mlngvsfLotWpEndNoC

                                If llngCnt = cmbWpName.ListIndex + 1 Then

                                    
                                    .SetData(.Rows.Count - 1, llngCnt, CMstrKakutei)                 '確定(◎)

                                    '@戻し情報を装置仕掛ﾛｯﾄに格納する為、WPﾘｽﾄ要素を+1する
                                    llngMcGpLotListWPListCnt = typMcGpLotListtmp.lngMcGpLotWpListCnt + 1
                                    typMcGpLotListtmp.lngMcGpLotWpListCnt = llngMcGpLotListWPListCnt
                                    typMcGpLotListtmp.typMcGpLotWpList = New List(Of McGpLotWpList)

                                    Dim typMcGpLotWpListtmp = New McGpLotWpList
                                    typMcGpLotWpListtmp.strWpName = cmbWpName.Text

                                    '@装置名ｺﾝﾎﾞの値取得列を「装置ID」列に変更
                                    cmbWpName.ValueCol = CMlngCmbWpNameId

                                    '@選択装置の装置IDを格納
                                    typMcGpLotWpListtmp.strWpID = cmbWpName.Value

                                    '@装置名ｺﾝﾎﾞの値取得列を「装置名」列に戻す
                                    cmbWpName.ValueCol = CMlngCmbWpNameName

                                    typMcGpLotListtmp.typMcGpLotWpList.Add(typMcGpLotWpListtmp)
                                    Exit For
                                End If
                            Next llngCnt

                            .SetData(.Rows.Count - 1, mlngvsfLotCarrierIdC, _
                                vsfBat.GetData(vsfBat.Row, CMlngvsfBatCarrierIdC))              'ｷｬﾘｱID

                            typMcGpLotListtmp.strCarrierId = _
                                vsfBat.GetData(vsfBat.Row, CMlngvsfBatCarrierIdC)


                            .SetData(.Rows.Count - 1, mlngvsfLotLotIdC, _
                                vsfBat.GetData(vsfBat.Row, CMlngvsfBatLotIdC))                  'ﾛｯﾄID

                            typMcGpLotListtmp.strLotID = _
                                vsfBat.GetData(vsfBat.Row, CMlngvsfBatLotIdC)


                            .SetData(.Rows.Count - 1, mlngvsfLotLastUpdateC, _
                                vsfBat.GetData(vsfBat.Row, CMlngvsfBatLastUpdateC))             '最終更新日

                            typMcGpLotListtmp.strLotLastUpdate = _
                                vsfBat.GetData(vsfBat.Row, CMlngvsfBatLastUpdateC)


                            '@-----------------------
                            '@ WF＆冶具情報戻し
                            '@-----------------------
                            '@一旦、選択行のWFIDと冶具IDを格納
                            lstrWFID = vsfBat.GetData(vsfBat.Row, CMlngvsfBatWFIDC)
                            lstrJigID = vsfBat.GetData(vsfBat.Row, CMlngvsfBatJigIDC)

                            '@選択行のWFIDがNULL以外か(基板ﾊﾞｯﾁ組の場合NULL)
                            If lstrWFID <> vbNullString Then

                                '@WF_IDの中に「,」区切りで複数のWF_IDが存在するか
                                If InStr(lstrWFID, CPstrComma) <> CPlngNumZero Then
                                
                                    'ｶﾝﾏ区切りで複数ｳｪﾊｰの場合その数をｳｪﾊｰ数として格納
                                    lstrTmpWFID = Split(lstrWFID, CPstrComma)
                                    lstrTmpWFIDCnt = UBound(lstrTmpWFID) + 1
                                    typMcGpLotListtmp.strWFQuantity = lstrTmpWFIDCnt
                                    
                                Else
                                    'ｶﾝﾏが存在しない場合はWF数=1を格納
                                    typMcGpLotListtmp.strWFQuantity = CPstrOne
                                
                                End If
                                
                            End If

                            '@戻し情報を装置仕掛ﾛｯﾄに格納する為、WFﾘｽﾄ要素を+1する
                            llngMcGpLotListWFListCnt = typMcGpLotListtmp.lngMcGpLotWFListCnt + 1
                            typMcGpLotListtmp.lngMcGpLotWFListCnt = llngMcGpLotListWFListCnt
                            typMcGpLotListtmp.typMcGpLotWFList = New List(Of WfList)

                            '@選択行のWFIDと冶具IDを格納
                            Dim typWfList = New WfList
                            typWfList.strWfId = lstrWFID
                            typWfList.strjigId = lstrJigID
                            typMcGpLotListtmp.typMcGpLotWFList.Add(typWfList)


                            '@同一ﾛｯﾄの行を探す
                            For llngCnt2 = 1 To vsfBat.Rows.Count - 1

                                '@戻し対象行のﾛｯﾄIDと同じで、かつWFIDが異なるか
                                If (vsfBat.GetData(vsfBat.Row, CMlngvsfBatLotIdC) = _
                                    vsfBat.GetData(llngCnt2, CMlngvsfBatLotIdC)) And _
                                    (vsfBat.GetData(vsfBat.Row, CMlngvsfBatWFIDC) <> _
                                    vsfBat.GetData(llngCnt2, CMlngvsfBatWFIDC)) Then

                                    '@選択行と異なる行か
                                    If vsfBat.Row <> llngCnt2 Then

                                        '@ｶﾝﾏ区切りで連結する
                                        lstrWFID = lstrWFID & CPstrComma & vsfBat.GetData(llngCnt2, CMlngvsfBatWFIDC)
                                        lstrJigID = lstrJigID & CPstrComma & vsfBat.GetData(llngCnt2, CMlngvsfBatJigIDC)

                                        '@戻し情報を装置仕掛ﾛｯﾄに格納する為、WFﾘｽﾄ要素を+1する
                                        llngMcGpLotListWFListCnt = typMcGpLotListtmp.lngMcGpLotWFListCnt + 1
                                        typMcGpLotListtmp.lngMcGpLotWFListCnt = llngMcGpLotListWFListCnt
                                        Dim typWfList2 = New WfList

                                        '@装置仕掛ﾛｯﾄのWFﾘｽﾄはｶﾝﾏ区切りではなく、1要素として格納
                                        typWfList2.strWfId = _
                                            vsfBat.GetData(llngCnt2, CMlngvsfBatWFIDC)
                                        typWfList2.strjigId = _
                                            vsfBat.GetData(llngCnt2, CMlngvsfBatJigIDC)

                                        '@WF枚数を+1する
                                        typMcGpLotListtmp.strWFQuantity = _
                                            CStr(CLng(typMcGpLotListtmp.strWFQuantity) + 1)

                                        typMcGpLotListtmp.typMcGpLotWFList.Add(typWfList2)
                                    End If
                                End If
                            Next llngCnt2

                            '@編集したWFIDと冶具IDを格納
                            .SetData(.Rows.Count - 1, mlngvsfLotWfIdC, lstrWFID)        'WFID
                            .SetData(.Rows.Count - 1, mlngvsfLotJigIDC, lstrJigID)      '冶具ID


                            '@Cfﾌﾗｸﾞ戻す(構造体への戻しは下でやっている)
                            .SetData(.Rows.Count - 1, mlngvsfLotLotKindC, _
                                vsfBat.GetData(vsfBat.Row, CMlngvsfBatPanelKindC))      'Cfﾌﾗｸﾞ(0：TFT、1：CF)
                            
                            '@Lpﾌﾗｸﾞ戻す(構造体への戻しは下でやっている)
                            .SetData(.Rows.Count - 1, mlngvsfLotLpFlagC, _
                                vsfBat.GetData(vsfBat.Row, CMlngvsfBatLpFlagC))         'Lpﾌﾗｸﾞ(0：小板、1：大板)
                                
                            '@ULDｷｬﾘｱ戻す
                            .SetData(.Rows.Count - 1, mlngvsfLotUldCarrierIdC, _
                                vsfBat.GetData(vsfBat.Row, CMlngvsfBatUldCarrierIDC))

                            If vsfProduct.Row > 0 Then
                                '@無機ﾌﾗｸﾞ
                                .SetData(.Rows.Count - 1, mlngvsfLotVaFlagC, _
                                    vsfProduct.GetData(vsfProduct.Row, mlngvsfLotVaFlagC))
                                
                                '@機種
                                .SetData(.Rows.Count - 1, mlngvsfLotPdIdC, _
                                    vsfProduct.GetData(vsfProduct.Row, mlngvsfLotPdIdC))
                                
                                '@蒸着ﾊﾞｯﾁID
                                .SetData(.Rows.Count - 1, mlngvsfLotJBatchIdC, _
                                    vsfProduct.GetData(vsfProduct.Row, mlngvsfLotJBatchIdC))
                                
                                '@表面処理ﾊﾞｯﾁID
                                .SetData(.Rows.Count - 1, mlngvsfLotHBatchIdC, _
                                    vsfProduct.GetData(vsfProduct.Row, mlngvsfLotHBatchIdC))
                                
                                '@無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ
                                .SetData(.Rows.Count - 1, mlngvsfLotInspectFlagC, _
                                    vsfProduct.GetData(vsfProduct.Row, mlngvsfLotInspectFlagC))
                            End If

                            typMcGpLotListtmp.strUnlCarrierID = _
                                vsfBat.GetData(vsfBat.Row, CMlngvsfBatUldCarrierIDC)
                                
                                
        '@--------------------------------------------------------------------------------------
        '@
        '@メモ：表面処理装置の場合にULDキャリアをセット可能にするためにCfﾌﾗｸﾞをつかっていた(ODFの場合はCfﾌﾗｸﾞ=0:TFTと化かして)が
        '@　　　CfﾌﾗｸﾞとLpﾌﾗｸﾞを見ることで、普通に判定できるようにしたので下記のロジックは不要となり素直にCfﾌﾗｸﾞ(Lpﾌﾗｸﾞも)を
        '@　　　戻すことになったので下記は削除
        '@
        '@                    '@-----------------------
        '@                    '@ ﾊﾟﾈﾙ(ﾛｯﾄ)種類情報戻し
        '@                    '@-----------------------
        '@                    '@★ 選択装置により処理分岐 ★
        '@                    Select Case lstrSelectWPEqType
        '@
        '@                        '@〓 19：斜方蒸着装置 〓
        '@                        Case CPstrEqTypeJyoucyaku
        '@
        '@                            '@Cfﾌﾗｸﾞ列は同期しているのでCfﾌﾗｸﾞを戻す
        '@                            .Cell(flexcpText, .Rows - 1, mlngvsfLotLotKindC) = _
        '@                                vsfBat.Cell(flexcpText, vsfBat.Row, CMlngvsfBatPanelKindC)      'Cfﾌﾗｸﾞ(0：TFT、1：CF)
        '@
        '@
        '@                        '@〓 20：表面処理装置 〓
        '@                        Case CPstrEqTypeHyoumenSyori
        '@
        '@                            '@ｷｬﾘｱIDとｱﾝﾛｰﾀﾞｷｬﾘｱIDが同じか
        '@                            '@※ﾓﾆﾀﾛｯﾄもｷｬﾘｱID=ｱﾝﾛｰﾀﾞｷｬﾘｱIDだが製品ﾛｯﾄ一覧に戻らないので1：CFをｾｯﾄしてしまう
        '@                            If vsfBat.Cell(flexcpText, vsfBat.Row, CMlngvsfBatCarrierIdC) = _
        '@                                vsfBat.Cell(flexcpText, vsfBat.Row, CMlngvsfBatUldCarrierIDC) Then
        '@
        '@                                '@Cfﾌﾗｸﾞは"1：CF"を戻す
        '@                                .Cell(flexcpText, .Rows - 1, mlngvsfLotLotKindC) = CPstrOne     'Cfﾌﾗｸﾞ(0：TFT、1：CF)
        '@
        '@                            Else
        '@                                '@異なる場合
        '@
        '@                                '@Cfﾌﾗｸﾞは"0：TFT"を戻す
        '@                                .Cell(flexcpText, .Rows - 1, mlngvsfLotLotKindC) = CPstrZero    'Cfﾌﾗｸﾞ(0：TFT、1：CF)
        '@
        '@                                '@製品ﾛｯﾄ一覧のｱﾝﾛｰﾀﾞｷｬﾘｱID(隠しCol)をｾｯﾄする
        '@                                .Cell(flexcpText, .Rows - 1, mlngvsfLotUldCarrierIdC) = _
        '@                                    vsfBat.Cell(flexcpText, vsfBat.Row, CMlngvsfBatUldCarrierIDC)
        '@
        '@                                mtypMcGpLotInfo.typMcGpLotList(llngMcGpLotListCnt).strUnlCarrierID = _
        '@                                    vsfBat.Cell(flexcpText, vsfBat.Row, CMlngvsfBatUldCarrierIDC)
        '@                            End If
        '@
        '@
        '@                        '@〓 その他 〓
        '@                        Case Else
        '@
        '@                            '@CfﾌﾗｸﾞはNULLを戻す
        '@                            .Cell(flexcpText, .Rows - 1, mlngvsfLotLotKindC) = vbNullString     'Cfﾌﾗｸﾞ(0：TFT、1：CF)
        '@
        '@                    End Select
        '@ --------------------------------------------------------------------------------------
                        End With

                        '@対象ｷｬﾘｱIDを格納する
                        lstrCarrierID = vsfBat.GetData(vsfBat.Row, CMlngvsfBatCarrierIdC)

                        '@構造体に格納されているIndexを取得する。
                        For llngListCnt = 0 To mtypBatLotList.typBatLot(vsfBatList.Row - 1).lngBatLotListCnt - 1

                            If mtypBatLotList.typBatLot(vsfBatList.Row - 1).typBatList(llngListCnt).strCarrierId = lstrCarrierID Then
                                Exit For
                            End If
                        Next llngListCnt


                        '@-----------------------
                        '@ ①ﾊﾞｯﾁ組ﾛｯﾄの場合、ﾊﾞｯﾁ組ﾛｯﾄ配列ﾃﾞｰﾀから製品ﾛｯﾄ一覧にﾃﾞｰﾀを表示
                        '@ ②ﾊﾞｯﾁ組ﾛｯﾄの場合、ﾊﾞｯﾁ組ﾛｯﾄ配列ﾃﾞｰﾀから製品ﾛｯﾄ配列ﾃﾞｰﾀに内容をｺﾋﾟｰ
                        '@-----------------------
                        With mtypBatLotList.typBatLot(vsfBatList.Row - 1).typBatList(llngListCnt)

                            vsfProduct.SetData(vsfProduct.Rows.Count - 1, mlngvsfLotFlowClassC, .strFlowClass)          '種別
                            vsfProduct.SetData(vsfProduct.Rows.Count - 1, mlngvsfLotUseIDC, UCase(.strUseId))           '製品区分
                            vsfProduct.SetData(vsfProduct.Rows.Count - 1, mlngvsfLotPriorityC, .strLotPriority)         '優先順位
                            vsfProduct.SetData(vsfProduct.Rows.Count - 1, mlngvsfLotRecipeIdC, _
                                mtypBatLotList.typBatLot(vsfBatList.Row - 1).strRecipeId)                               'ﾚｼﾋﾟ

                            '@WFIDがNULLか
                            If lstrWFID = vbNullString Then

                                '@NULLの場合はﾊﾞｯﾁ組情報ﾃﾞｰﾀから表示(WF_IDを扱わない基板のﾊﾞｯﾁ組み)
                                vsfProduct.SetData(vsfProduct.Rows.Count - 1, mlngvsfLotWfNumC, .strWFQuantity)         'WF枚数
                                typMcGpLotListtmp.strWFQuantity = .strWFQuantity
                            Else
                                '@NULL以外の場合は、装置仕掛ﾛｯﾄﾃﾞｰﾀから表示(WF_IDを扱う組立のﾊﾞｯﾁ組み)
                                vsfProduct.SetData(vsfProduct.Rows.Count - 1, mlngvsfLotWfNumC, _
                                    typMcGpLotListtmp.strWFQuantity)                                                    'WF枚数
                            End If

                            typMcGpLotListtmp.strFlowClass = .strFlowClass
                            typMcGpLotListtmp.strUseId = UCase(.strUseId)
                            typMcGpLotListtmp.strLotPriority = .strLotPriority
                            typMcGpLotListtmp.strRecipeId = _
                                mtypBatLotList.typBatLot(vsfBatList.Row - 1).strRecipeId

                            '@時間制限関連情報の格納
                            typMcGpLotListtmp.strRestrictTypeID = .strRestrictTypeID
                            typMcGpLotListtmp.strLimitTime = .strLimitTime
                            typMcGpLotListtmp.strWarnTime = .strWarnTime


                            '@時間制限
                            If .strLimitTime <> vbNullString Then

                                '@制限時間が数値か
                                If IsNumeric(.strLimitTime) = True Then

                                    '@制限時間がﾌﾟﾗｽか
                                    If CLng(.strLimitTime) >= 0 Then

                                        '@制限時間以内か
                                        If .strRestrictTypeID = CPstrRestrictTypeID1 Then
                                    
                                            '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,##0)+"分"
                                            lstrLimitTime = Replace(Format(CInt(.strLimitTime), CPstrDateFormatKanma), CPstrReplaceMinus, vbNullString)

                                            '@制限時間先大工程+制限時間先小工程+制限時間+「以内」
                                            vsfProduct.SetData(vsfProduct.Rows.Count - 1, mlngvsfLotLimitTimeC, .strToOpId & Space(1) & _
                                                                                                                     .strToStepId & CMstrMade & _
                                                                                                                     lstrLimitTime & CPstrh & CPstrinai)     '時間制限

                                            '@警告時間が設定されている場合
                                            If .strWarnTime <> vbNullString Then

                                                '@制限時間と警告時間は数値か
                                                If IsNumeric(.strWarnTime) = True And IsNumeric(.strLimitTime) = True Then

                                                    '@時間制限が警告時間を過ぎている,且つ制限時間がｵｰﾊﾞｰしていない場合
                                                    If CLng(.strWarnTime) < 0 And CLng(.strLimitTime) >= 0 Then
                                                        '@ﾌｫﾝﾄｶﾗｰを紫に変更
                                                        Dim newStyle As CellStyle = vsfProduct.Styles.Add("CustomStyle_ForeColor_CPlngVbColorPurple_E")
                                                        newStyle.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple)
                                                        Dim cellRange As CellRange = vsfProduct.GetCellRange(vsfProduct.Rows.Count - 1, mlngvsfLotLimitTimeC)
                                                        cellRange.Style = newStyle
                                                    Else
                                                        '@ﾌｫﾝﾄｶﾗｰを黒に変更
                                                        Dim newStyle As CellStyle = vsfProduct.Styles.Add("CustomStyle_ForeColor_vbBlack_F")
                                                        newStyle.ForeColor = Color.Black
                                                        Dim cellRange As CellRange = vsfProduct.GetCellRange(vsfProduct.Rows.Count - 1, mlngvsfLotLimitTimeC)
                                                        cellRange.Style = newStyle
                                                    End If
                                                End If
                                            End If
                                        End If

                                    Else
                                        '@制限時間がﾏｲﾅｽの場合

                                        '@ﾌｫﾝﾄ色変更
                                        Dim newStyle As CellStyle = vsfProduct.Styles.Add("CustomStyle_ForeColor_CPlngVbColorRed_G")
                                        newStyle.ForeColor = Color.Red
                                        Dim cellRange As CellRange = vsfProduct.GetCellRange(vsfProduct.Rows.Count - 1, mlngvsfLotLimitTimeC)
                                        cellRange.Style = newStyle             '赤

                                        '@制限時間以下の場合
                                        If .strRestrictTypeID = CPstrRestrictTypeID1 Then

                                            '@ﾌｫｰﾏｯﾄ変換(##,##0)
                                            lstrLimitTime = Format(CInt(.strLimitTime), CPstrDateFormatKanma)

                                            '@制限時間先大工程+制限時間先小工程+制限時間+「以内」
                                            vsfProduct.SetData(vsfProduct.Rows.Count - 1, mlngvsfLotLimitTimeC, .strToOpId & CPstrSpace & _
                                                                                                                     .strToStepId & CPstrMade & _
                                                                                                                     lstrLimitTime & CPstrh & CPstrinai)
                                        End If

                                        '@制限時間以上の場合
                                        If .strRestrictTypeID = CPstrRestrictTypeID2 Then

                                            '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,##0)+"分"
                                            lstrLimitTime = Replace(Format(CInt(.strLimitTime), CPstrDateFormatKanma), CPstrReplaceMinus, vbNullString)

                                            '@制限時間先大工程+制限時間先小工程+制限時間+「以上」
                                            vsfProduct.SetData(vsfProduct.Rows.Count - 1, mlngvsfLotLimitTimeC, .strToOpId & CPstrSpace & _
                                                                                                                     .strToStepId & CPstrMade & _
                                                                                                                     lstrLimitTime & CPstrh & CPstrijyou)
                                        End If
                                    End If
                                End If
                            End If

                            vsfProduct.SetData(vsfProduct.Rows.Count - 1, mlngvsfLotOptionTextC, .strOptionText)        '作業条件
                            vsfProduct.SetData(vsfProduct.Rows.Count - 1, mlngvsfLotOpIdC, .strOpID)                    '大工程
                            vsfProduct.SetData(vsfProduct.Rows.Count - 1, mlngvsfLotStepIdC, .strStepID)                '小工程
                            If .strStartTime <> vbNullString Then
                                vsfProduct.SetData(vsfProduct.Rows.Count - 1, mlngvsfLotDispatchStartC, _
                                Format$(CDate(.strStartTime), CPstrDateFormatMDHM))                                     '処理開始予定
                            Else
                                vsfProduct.SetData(vsfProduct.Rows.Count - 1, mlngvsfLotDispatchStartC, .strStartTime)
                            End If
                            vsfProduct.SetData(vsfProduct.Rows.Count - 1, mlngvsfLotLpFlagC, .strLpFlag)                '大板(Lp)ﾌﾗｸﾞ
                            vsfProduct.SetData(vsfProduct.Rows.Count - 1, mlngvsfLotVaFlagC, .strLpFlag)                '無機ﾌﾗｸﾞ
                            vsfProduct.SetData(vsfProduct.Rows.Count - 1, mlngvsfLotPdIdC, .strLpFlag)                  '機種
                            vsfProduct.SetData(vsfProduct.Rows.Count - 1, mlngvsfLotJBatchIdC, .strLpFlag)              '蒸着ﾊﾞｯﾁID
                            vsfProduct.SetData(vsfProduct.Rows.Count - 1, mlngvsfLotHBatchIdC, .strLpFlag)              '表面処理ﾊﾞｯﾁID
                            
                            '@無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ判定
                            '@ｵﾝﾗｲﾝ未
                            If .strInspectFlag <> CPstrFlagOn Then
                                vsfProduct.SetData(vsfProduct.Rows.Count - 1, mlngvsfLotInspectFlagC, CMstrNoOnline)
                            Else
                                vsfProduct.SetData(vsfProduct.Rows.Count - 1, mlngvsfLotInspectFlagC, vbNullString)
                            End If

                            typMcGpLotListtmp.strOptionText = .strOptionText
                            typMcGpLotListtmp.strOpID = .strOpID
                            typMcGpLotListtmp.strStepID = .strStepID
                            typMcGpLotListtmp.strDispatchStartTime = .strStartTime

                            typMcGpLotListtmp.strCfFlag = .strCfFlag
                            typMcGpLotListtmp.strCurrentStatusID = .strCurrentStatusID
                            typMcGpLotListtmp.strCurrentStatusName = .strCurrentStatusName
                            typMcGpLotListtmp.strFlowClassName = .strFlowClassName
                            typMcGpLotListtmp.strLpFlag = .strLpFlag
                            typMcGpLotListtmp.strReworkFlag = .strReworkFlag
                            typMcGpLotListtmp.strToOpId = .strToOpId
                            typMcGpLotListtmp.strToStepId = .strToStepId

                        End With
                        mtypMcGpLotInfo.typMcGpLotList.Add(typMcGpLotListtmp)

                        '@高さ設定
                        vsfProduct.Rows(vsfProduct.Rows.Count - 1).Height = CMlngGridRowHeight

                        '@表示位置の設定
                        With vsfProduct

                            .Cols(mlngvsfLotNoC).TextAlign = TextAlignEnum.RightCenter             'No

                            For llngCnt = mlngvsfLotWpStartNoC To mlngvsfLotWpEndNoC
                                .Cols(llngCnt).TextAlign = TextAlignEnum.LeftCenter                '装置№
                            Next llngCnt

                            .Cols(mlngvsfLotCarrierIdC).TextAlign = TextAlignEnum.LeftCenter       'ｷｬﾘｱID
                            .Cols(mlngvsfLotLotIdC).TextAlign = TextAlignEnum.LeftCenter           'ﾛｯﾄID
                            .Cols(mlngvsfLotFlowClassC).TextAlign = TextAlignEnum.LeftCenter       '種別
                            .Cols(mlngvsfLotUseIDC).TextAlign = TextAlignEnum.LeftCenter           '製品区分
                            .Cols(mlngvsfLotPriorityC).TextAlign = TextAlignEnum.RightCenter       '優先順位
                            .Cols(mlngvsfLotWfNumC).TextAlign = TextAlignEnum.RightCenter          'WF枚数
                            .Cols(mlngvsfLotRecipeIdC).TextAlign = TextAlignEnum.LeftCenter        'ﾚｼﾋﾟ
                            .Cols(mlngvsfLotLimitTimeC).TextAlign = TextAlignEnum.LeftCenter       '時間制限
                            .Cols(mlngvsfLotOptionTextC).TextAlign = TextAlignEnum.LeftCenter      '作業条件
                            .Cols(mlngvsfLotOpIdC).TextAlign = TextAlignEnum.LeftCenter            '大工程
                            .Cols(mlngvsfLotStepIdC).TextAlign = TextAlignEnum.LeftCenter          '小工程
                            .Cols(mlngvsfLotDispatchStartC).TextAlign = TextAlignEnum.LeftCenter   '処理開始予定
                            .Cols(mlngvsfLotLastUpdateC).TextAlign = TextAlignEnum.LeftCenter      '最終更新日
                            .Cols(mlngvsfLotWfIdC).TextAlign = TextAlignEnum.LeftCenter            'WFID
                            .Cols(mlngvsfLotJigIDC).TextAlign = TextAlignEnum.LeftCenter           '冶具ID
                            .Cols(mlngvsfLotLotKindC).TextAlign = TextAlignEnum.LeftCenter         'Cfﾌﾗｸﾞ(0：TFT、1：CF)
                            .Cols(mlngvsfLotUldCarrierIdC).TextAlign = TextAlignEnum.LeftCenter    'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                            .Cols(mlngvsfLotLpFlagC).TextAlign = TextAlignEnum.LeftCenter          'Lpﾌﾗｸﾞ
                            .Cols(mlngvsfLotVaFlagC).TextAlign = TextAlignEnum.LeftCenter          '無機ﾌﾗｸﾞ
                            .Cols(mlngvsfLotPdIdC).TextAlign = TextAlignEnum.LeftCenter            '機種
                            .Cols(mlngvsfLotJBatchIdC).TextAlign = TextAlignEnum.LeftCenter        '蒸着ﾊﾞｯﾁID
                            .Cols(mlngvsfLotHBatchIdC).TextAlign = TextAlignEnum.LeftCenter        '表面処理ﾊﾞｯﾁID
                            .Cols(mlngvsfLotInspectFlagC).TextAlign = TextAlignEnum.LeftCenter     '無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ

                            '@非表示設定
                            For llngCnt = CMlngGridTitleCol To .Cols.Count - 1  '全列表示
                                .Cols(llngCnt).Visible = True
                            Next llngCnt
                            .Cols(mlngvsfLotUseIDC).Visible = False             '製品区分
                            .Cols(mlngvsfLotLastUpdateC).Visible = False        '最終更新日
                            .Cols(mlngvsfLotWfIdC).Visible = False              'WFID
                            .Cols(mlngvsfLotJigIDC).Visible = False             '冶具ID
                            .Cols(mlngvsfLotLotKindC).Visible = False           'Cfﾌﾗｸﾞ(0：TFT、1：CF)
                            .Cols(mlngvsfLotUldCarrierIdC).Visible = False      'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                            .Cols(mlngvsfLotLpFlagC).Visible = False            'Lpﾌﾗｸﾞ
                            .Cols(mlngvsfLotVaFlagC).Visible = False            '無機ﾌﾗｸﾞ
                            .Cols(mlngvsfLotPdIdC).Visible = False              '機種
                            .Cols(mlngvsfLotJBatchIdC).Visible = False          '蒸着ﾊﾞｯﾁID
                            .Cols(mlngvsfLotHBatchIdC).Visible = False          '表面処理ﾊﾞｯﾁID
                        End With

                        '@列幅の自動調整
                        resizevsfProduct()

                        '@固定列の設定
                        vsfProduct.Cols.Frozen = mlngvsfLotCarrierIdC + 1

                        '@ﾏｳｽよる列ｻｲｽﾞ変更の可／不可設定
                        vsfProduct.AllowResizing = AllowResizingEnum.Columns

                        '@製品ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞの使用可設定
                        vsfProduct.Enabled = True
                    End If
                End If
            End If


            '@-----------------------
            '@ ﾊﾞｯﾁ組予定ﾛｯﾄ一覧情報の設定
            '@-----------------------
            '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞの該当行削除
            With vsfBat

                '@★ 選択装置の装置ﾀｲﾌﾟにより処理分岐 ★
                Select Case lstrSelectWPEqType

                    '@〓 19：斜方蒸着装置 〓
                    Case CPstrEqTypeJyoucyaku

                        '@選択行がﾀﾞﾐｰ冶具か
                        If .GetData(.Row, CMlngvsfBatWFIDC) <> CMstrDummy Then

                            '@-----------------------
                            '@ 選択装置が蒸着装置の場合は、対象ｸﾞﾘｯﾄﾞの「順」と「Cfﾌﾗｸﾞ」以外の内容をｸﾘｱする
                            '@-----------------------
                            '@同一ﾛｯﾄの行を探す
                            For llngCnt = 1 To .Rows.Count - 1

                                '@戻し対象行のﾛｯﾄIDと同じで、かつWFIDが異なるか
                                If (.GetData(.Row, CMlngvsfBatLotIdC) = _
                                    .GetData(llngCnt, CMlngvsfBatLotIdC)) And _
                                    (.GetData(.Row, CMlngvsfBatWFIDC) <> _
                                    .GetData(llngCnt, CMlngvsfBatWFIDC)) Then

                                    '@選択行と異なる行か
                                    If .Row <> llngCnt Then

                                        '@内容をｸﾘｱする
                                        .SetData(llngCnt, CMlngvsfBatJigIDC, vbNullString)            '冶具ID
                                        .SetData(llngCnt, CMlngvsfBatLotIdC, vbNullString)            'ﾛｯﾄID
                                        .SetData(llngCnt, CMlngvsfBatLastUpdateC, vbNullString)       '最終更新日
                                        .SetData(llngCnt, CMlngvsfBatProductOldNoC, vbNullString)     '製品ﾛｯﾄｸﾞﾘｯﾄﾞの行番号
                                        .SetData(llngCnt, CMlngvsfBatWFIDC, vbNullString)             'WFID
                                        .SetData(llngCnt, CMlngvsfBatVaConditionIDC, vbNullString)    '蒸着処理条件
                                        .SetData(llngCnt, CMlngvsfBatWFNumC, vbNullString)            'WF枚数
                                        .SetData(llngCnt, CMlngvsfBatUseIDC, vbNullString)            '製品区分
                                        .SetData(llngCnt, CMlngvsfBatPanelKindC, vbNullString)        'Cfﾌﾗｸﾞ
                                        .SetData(llngCnt, CMlngvsfBatLpFlagC, vbNullString)           '大板(Lp)ﾌﾗｸﾞ
                                        .SetData(llngCnt, CMlngvsfBatFlowClassC, vbNullString)        '種別
                                        .SetData(llngCnt, CMlngvsfBatVaFlagC, vbNullString)           '無機ﾌﾗｸﾞ
                                        .SetData(llngCnt, CMlngvsfBatPdIdC, vbNullString)             '機種
                                        .SetData(llngCnt, CMlngvsfBatJBatchIdC, vbNullString)         '蒸着ﾊﾞｯﾁID
                                        .SetData(llngCnt, CMlngvsfBatHBatchIdC, vbNullString)         '表面処理ﾊﾞｯﾁID
                                        .SetData(llngCnt, CMlngvsfBatInspectFlagC, vbNullString)      '無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ
                                    End If
                                End If
                            Next llngCnt
                        End If

                        '@同一ﾛｯﾄID行の内容をｸﾘｱし終えたら、選択行もｸﾘｱ
                        .SetData(.Row, CMlngvsfBatJigIDC, vbNullString)                           '冶具ID
                        .SetData(.Row, CMlngvsfBatLotIdC, vbNullString)                           'ﾛｯﾄID
                        .SetData(.Row, CMlngvsfBatLastUpdateC, vbNullString)                      '最終更新日
                        .SetData(.Row, CMlngvsfBatProductOldNoC, vbNullString)                    '製品ﾛｯﾄｸﾞﾘｯﾄﾞの行番号
                        .SetData(.Row, CMlngvsfBatWFIDC, vbNullString)                            'WFID
                        .SetData(.Row, CMlngvsfBatVaConditionIDC, vbNullString)                   '蒸着処理条件
                        .SetData(.Row, CMlngvsfBatWFNumC, vbNullString)                           'WF枚数
                        .SetData(.Row, CMlngvsfBatUseIDC, vbNullString)                           '製品区分
                        .SetData(.Row, CMlngvsfBatPanelKindC, vbNullString)                       'Cfﾌﾗｸﾞ
                        .SetData(.Row, CMlngvsfBatLpFlagC, vbNullString)                          '大板(Lp)ﾌﾗｸﾞ
                        .SetData(.Row, CMlngvsfBatFlowClassC, vbNullString)                       '種別
                        .SetData(.Row, CMlngvsfBatVaFlagC, vbNullString)                          '無機ﾌﾗｸﾞ
                        .SetData(.Row, CMlngvsfBatPdIdC, vbNullString)                            '機種
                        .SetData(.Row, CMlngvsfBatJBatchIdC, vbNullString)                        '蒸着ﾊﾞｯﾁID
                        .SetData(.Row, CMlngvsfBatHBatchIdC, vbNullString)                        '表面処理ﾊﾞｯﾁID
                        .SetData(.Row, CMlngvsfBatInspectFlagC, vbNullString)                     '無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ

                        '@ﾀﾞﾐｰ冶具選択ﾎﾞﾀﾝを有効にする
                        cmdDummySelect.Enabled = True


                    '@〓 その他 〓
                    Case Else

                        '@行削除
                        RemoveHandler vsfBat.EnterCell,AddressOf vsfBat_EnterCell
                        .Redraw = False
                        .RemoveItem(.Row)
                        .Redraw = True
                        AddHandler vsfBat.EnterCell,AddressOf vsfBat_EnterCell

                        '@順の振り直し
                        For llngCnt = 1 To .Rows.Count - 1

                            '@順が"0(基板ﾓﾆﾀﾛｯﾄ)"か
                            If .GetData(llngCnt, CMlngvsfBatSeqNumC) = CPstrZero Then

                                '@順が"0"の場合は、0(基板ﾓﾆﾀﾛｯﾄの仕様)を振る
                                .SetData(llngCnt, CMlngvsfBatSeqNumC, CPstrZero)
                            Else
                                '@1行目か
                                If llngCnt = 1 Then
                                    '@順が"0"以外の場合は、番号振り直し
                                    .SetData(llngCnt, CMlngvsfBatSeqNumC, llngCnt)
                                Else
                                    '@順が"0"以外の場合は、番号振り直し
                                    .SetData(llngCnt, CMlngvsfBatSeqNumC, _
                                        CStr(CLng(.GetData(llngCnt - 1, CMlngvsfBatSeqNumC)) + 1))
                                End If
                            End If
                        Next llngCnt

                End Select

                '@=======================
                '@ ﾊﾞｯﾁ組WF枚数再計算処理
                '@=======================
                Call prvBatLotWFCnt_Cal()

                '@-----------------------
                '@ ﾊﾞｯﾁ組予定ﾛｯﾄ一覧が0件になった場合の制御
                '@-----------------------
                '@ﾊﾞｯﾁ編成にﾛｯﾄが0件、またはﾊﾞｯﾁ組WF枚数が0か
                If .Rows.Count <= 1 Or lblBatLotWFCnt.Text = 0 Then

                    '@各種ﾗﾍﾞﾙをｸﾘｱ
                    lblRecipeID.Text = vbNullString                  'ﾚｼﾋﾟ
                    lblBatLotWFCnt.Text = CPstrZero                  'ﾊﾞｯﾁ組ﾛｯﾄ数

                    '@蒸着処理条件ﾗﾍﾞﾙが表示されているか
                    If lblVaCondition.Visible = True Then

                        '@蒸着処理条件、有効/無効をｸﾘｱ
                        lblVaCondition.Text = vbNullString           '蒸着処理条件
                        lblVaConditionFlag.Text = vbNullString       '(蒸着処理条件)有効/無効

                    End If

                    '@[ < ]ﾎﾞﾀﾝを無効にする
                    cmdRemove.Enabled = False
                End If


                '@-----------------------
                '@ [ < ]ﾎﾞﾀﾝ押下後の[確定]ﾎﾞﾀﾝ制御
                '@-----------------------
                '@ﾊﾞｯﾁ編成にﾛｯﾄが1件以上あるか(ﾊﾞｯﾁ組WF枚数が1以上)
                If .Rows.Count > 1 And lblBatLotWFCnt.Text >= 1 Then

                    '@選択装置が"20：表面処理装置"の場合は以下を追加でﾁｪｯｸ
                    If lstrSelectWPEqType = CPstrEqTypeHyoumenSyori Then

                        '@TFTﾛｯﾄか
                        If .GetData(.Row, CMlngvsfBatPanelKindC) <> CPstrZero Then

                            '@ULDｷｬﾘｱ選択ﾎﾞﾀﾝを無効にする
                            cmdCarrierSelect.Enabled = False
                        End If

                        '@一旦、確定ﾎﾞﾀﾝを有効にする
                        cmdKakutei.Enabled = True

                        For llngCnt = 1 To .Rows.Count - 1

                            '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULLか
                            If .GetData(llngCnt, CMlngvsfBatUldCarrierIDC) = vbNullString Then

                                '@確定ﾎﾞﾀﾝを無効にする
                                cmdKakutei.Enabled = False
                            End If
                        Next llngCnt
                    Else
                        '@選択装置が"20：表面処理装置"以外の場合

                        '@一旦、確定ﾎﾞﾀﾝを無効にする
                        cmdKakutei.Enabled = False

                        For llngCnt = 1 To .Rows.Count - 1

                            '@ﾛｯﾄIDがNULL以外か
                            If .GetData(llngCnt, CMlngvsfBatLotIdC) <> vbNullString Then

                                '@確定ﾎﾞﾀﾝを有効にする
                                cmdKakutei.Enabled = True
                                Exit For
                            End If
                        Next llngCnt
                    End If
                Else
                    '@各種ﾎﾞﾀﾝを無効にする
                    cmdCarrierSelect.Enabled = False            'ULDｷｬﾘｱ選択
                    cmdKakutei.Enabled = False                  '確定
                End If


                '@-----------------------
                '@ 製品ﾛｯﾄ一覧の文字色制御
                '@-----------------------
                '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧から同一ﾛｯﾄを検索
                For llngCnt = 1 To vsfProduct.Rows.Count - 1

                    For llngCnt2 = 1 To .Rows.Count - 1

                        '@表示ﾛｯﾄとﾊﾞｯﾁ組予定ﾛｯﾄが同じか
                        If vsfProduct.GetData(llngCnt, mlngvsfLotLotIdC) = _
                            .GetData(llngCnt2, CMlngvsfBatLotIdC) Then

                            '@製品一覧ｸﾞﾘｯﾄﾞの該当行ForeColerを灰色に変更する
                            Dim newStyle As CellStyle
                            Dim cellRange As CellRange
                            Dim llngCnt3 As Integer
                            For llngCnt3 = mlngvsfLotNoC To mlngvsfLotLastUpdateC
                                newStyle = vsfProduct.Styles.Add("CustomStyle_ForeColor_CMlngEnableFalseForeColor_H" + llngCnt.ToString + llngCnt3.ToString)
                                newStyle.ForeColor = ColorTranslator.FromWin32(CMlngEnableFalseForeColor)
                                newStyle.BackColor = vsfProduct.GetCellRange(llngCnt, llngCnt3).StyleDisplay.BackColor
                                cellRange = vsfProduct.GetCellRange(llngCnt, llngCnt3)
                                cellRange.Style = newStyle
                            Next
                            Exit For
                        End If
                    Next llngCnt2
                Next llngCnt

            End With

            '@=======================
            '@ 製品ﾛｯﾄｸﾞﾘｯﾄﾞ ｶﾚﾝﾄ行列変更処理
            '@=======================
            Call vsfProduct_EnterCell(sender, e)

            '@=======================
            '@ ﾊﾞｯﾁ組予定ﾛｯﾄﾌﾚｰﾑ内ｺﾝﾄﾛｰﾙ初期化処理
            '@=======================
            Call prvVsfBatControlClear_Proc()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdRemove_Click"            'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWpName_Change
    '機　能：[装置名]ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 12:02:38 T.Kitagawa
    '更新日：2013/11/06 (Wed) 18:43:14 T.Oide
    '備　考：
    '　　　：2009/06/04 (Thu) 15:51:57 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/24 (Fri) 14:21:56 N.Kojima     無機対応Phase2、製品区分追加。(案件№03661)
    '　　　：2012/03/05 (Mon) 15:40:42 T.Oide       無機装置対応(REQ-1303)
    Private Sub cmbWpName_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWpName.Change

        Dim llngAns                 As Integer      'ﾒｯｾｰｼﾞBOX戻り値格納
        Dim llngOldWpName           As Integer      '装置名(退避用)
        Dim llngCnt                 As Integer      '汎用ｶｳﾝﾀ
        Dim lblnAns                 As Boolean      '通信戻り値格納
        Dim lstrSelectWPEqType      As String       '選択装置の装置ﾀｲﾌﾟ
        Dim lstrCallName            As String       '蒸着処理条件取得処理に渡す呼び元処理名
        Dim llngCnt3                As Integer      'NSYS Batの.Row位置

        Try

            '@装置名が未選択か
            If cmbWpName.Text = vbNullString Then
                Exit Sub
            End If


            '@ﾊﾞｯﾁ編集中か
            If vsfBat.Rows.Count > 1 And mblnInEditKbn = True Then
                '@ﾊﾞｯﾁ編集中の場合

                '@装置名の変更確認
                If cmbWpName.ListIndex <> mlngOldcmbWpNameIndex Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@"<TRM0PW>$$バッチ編成中です。 内容を破棄してよろしいですか？"のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000P)
                    llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                    '@ﾒｯｾｰｼﾞBoxにて「いいえ」が選択されたか
                    If llngAns = vbNo Then

                        '@選択後の装置名の設定
                        cmbWpName.ListIndex = mlngOldcmbWpNameIndex
                        Exit Sub
                    Else
                        '@「はい」が選択

                        '@選択中の装置名の退避(下記処理にて一旦消えてしまう為)
                        llngOldWpName = cmbWpName.ListIndex

                        '@=======================
                        '@ ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ内容の初期化
                        '@=======================
                        Call prvALLInfo_Init()

                        '@=======================
                        '@ ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ内容の表示
                        '@=======================
                        Call prvALLInfo_Sel()

                        '@選択中の装置名の設定
                        cmbWpName.ListIndex = llngOldWpName
                    End If
                Else
                    Exit Sub
                End If
            Else
                '@ﾊﾞｯﾁ編集中ではない場合

                '@最大ﾛｯﾄ数の設定、ﾚｼﾋﾟ初期化
                lblMaxLotCnt.Text = mtypWpList(cmbWpName.ListIndex).strMaxProcessBox     '最大ﾛｯﾄ数
                lblRecipeID.Text = vbNullString                                          'ﾚｼﾋﾟ

                '@ﾓﾆﾀ選択ﾎﾞﾀﾝを有効にする
                cmdMonitorLotList.Enabled = True
                
                lblMesModeId.Text = mtypWpList(cmbWpName.ListIndex).strMesModeId         '運用ﾓｰﾄﾞ
                If mtypWpList(cmbWpName.ListIndex).strBatchComposeType = CPstrOne Then   'ﾊﾞｯﾁ自動編成方式
                    lblMethod.Text = CPstrAuto
                Else
                    lblMethod.Text = CPstrManual
                End If
            End If

            '@">"ﾎﾞﾀﾝを無効にする
            cmdMove.Enabled = False
            cmdMoveAll.Enabled = False


            '@起動SBが"2A0：組立"か
            If pstrSBID = CPstrSBID2A0 Then

                '@装置名ｺﾝﾎﾞの値取得列を「装置ﾀｲﾌﾟ(EqType)」列に変更
                cmbWpName.ValueCol = CMlngCmbWpNameEqType

                '@選択装置の装置ﾀｲﾌﾟを格納
                lstrSelectWPEqType = cmbWpName.Value

                '@装置名ｺﾝﾎﾞの値取得列を「装置名」列に戻す
                cmbWpName.ValueCol = CMlngCmbWpNameName

                '@ﾊﾞｯﾁ組WF枚数ﾗﾍﾞﾙを表示する
                lblBatLotWFCntTitle.Visible = True
                lblBatLotWFCnt.Visible = True
                lblBatLotWFCnt.Text = CPstrZero                  'ﾃﾞﾌｫﾙﾄ：0

                '@★ 選択装置の装置ﾀｲﾌﾟにより処理分岐 ★
                Select Case lstrSelectWPEqType

                    '@〓 19：斜方蒸着装置 〓
                    Case CPstrEqTypeJyoucyaku

                        '@各種ﾎﾞﾀﾝ制御
                        cmdMonitorLotList.Enabled = False   'ﾓﾆﾀ選択ﾎﾞﾀﾝ：無効
                        cmdCarrierSelect.Enabled = False    'ULDｷｬﾘｱ選択ﾎﾞﾀﾝ：無効

                        '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞの表示列を変更する
                        With vsfBat

                            '@ﾏｰｼﾞ設定(ﾏｰｼﾞ対象列：冶具ID、ﾛｯﾄID)
                            .AllowMerging = AllowMergingEnum.Free                     '1：隣接ｾﾙ単位のﾏｰｼﾞ
                            .Cols(CMlngvsfBatSeqNumC).AllowMerging = False
                            .Cols(CMlngvsfBatCarrierIdC).AllowMerging = False
                            .Cols(CMlngvsfBatJigIDC).AllowMerging = True
                            .Cols(CMlngvsfBatLotIdC).AllowMerging = True
                            .Cols(CMlngvsfBatLastUpdateC).AllowMerging = False
                            .Cols(CMlngvsfBatProductOldNoC).AllowMerging = False
                            .Cols(CMlngvsfBatUldCarrierIDC).AllowMerging = False
                            .Cols(CMlngvsfBatWFIDC).AllowMerging = False
                            .Cols(CMlngvsfBatPanelKindC).AllowMerging = False
                            .Cols(CMlngvsfBatVaConditionIDC).AllowMerging = False
                            .Cols(CMlngvsfBatWFNumC).AllowMerging = False
                            .Cols(CMlngvsfBatUseIDC).AllowMerging = False
                            .Cols(CMlngvsfBatLpFlagC).AllowMerging = False
                            .Cols(CMlngvsfBatFlowClassC).AllowMerging = False
                            .Cols(CMlngvsfBatVaFlagC).AllowMerging = False
                            .Cols(CMlngvsfBatPdIdC).AllowMerging = False
                            .Cols(CMlngvsfBatJBatchIdC).AllowMerging = False
                            .Cols(CMlngvsfBatHBatchIdC).AllowMerging = False
                            .Cols(CMlngvsfBatInspectFlagC).AllowMerging = False

                            '@蒸着#1と#2でスロット数が異なる対応
                            cmbWpName.ValueCol = CMlngCmbWpNameMaxProcessBox
                            RemoveHandler vsfBat.EnterCell,AddressOf vsfBat_EnterCell
                            llngCnt3 = .Row
                            .Rows.Count = cmbWpName.Value + 1
                            'NSYS 選択行が未指定の場合はヘッダ行を選択状態にする
                            If llngCnt3 <= 0 Then
                                .Row = 0
                            End If
                            AddHandler vsfBat.EnterCell,AddressOf vsfBat_EnterCell
                            cmbWpName.ValueCol = CMlngCmbWpNameName


                            '@"順(処理部)"の設定
                            For llngCnt = 1 To .Rows.Count - 1
                                .SetData(llngCnt, CMlngvsfBatSeqNumC, llngCnt)
                            Next llngCnt

                            '@高さ設定
                            .Rows(.Rows.Count - 1).Height = CMlngGridRowHeight

                            '@非表示設定
                            .Cols(CMlngvsfBatCarrierIdC).Visible = False        'ｷｬﾘｱID
                            .Cols(CMlngvsfBatUldCarrierIDC).Visible = False     'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                            .Cols(CMlngvsfBatInspectFlagC).Visible = False      '異物検査S1

                            '@表示設定
                            .Cols(CMlngvsfBatJigIDC).Visible = True             '冶具ID
                            .Cols(CMlngvsfBatWFIDC).Visible = True              'WFID
                        End With

                        '@蒸着処理条件取得処理に渡す呼び元処理名をｾｯﾄ
                        lstrCallName = CMstrCmbWpNameChange

                        '@=======================
                        '@ 蒸着処理条件取得処理(戻り値は使用しません)
                        '@=======================
                        lblnAns = prvblnMasVaConditionSel_Proc(lstrCallName)


                    '@〓 20：表面処理装置 〓
                    Case CPstrEqTypeHyoumenSyori

                        '@各種ﾎﾞﾀﾝ制御
                        cmdUP.Enabled = False               '"↑"：無効
                        cmdDown.Enabled = False             '"↓"：無効
                        cmdMonitorLotList.Enabled = True    'ﾓﾆﾀ選択ﾎﾞﾀﾝ：有効
                        cmdDummySelect.Enabled = False      'ﾀﾞﾐｰ冶具選択：無効
                        cmdKakutei.Enabled = False          '確定：無効

                        '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞの表示列を変更する
                        With vsfBat

                            '@行数設定
                            .Row = -1
                            .Rows.Count = 1

                            '@非表示設定
                            .Cols(CMlngvsfBatJigIDC).Visible = False            '冶具ID
                            .Cols(CMlngvsfBatWFIDC).Visible = False             'WFID

                            '@表示設定
                            .Cols(CMlngvsfBatCarrierIdC).Visible = True         'ｷｬﾘｱID
                            .Cols(CMlngvsfBatUldCarrierIDC).Visible = True      'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                            .Cols(CMlngvsfBatWFNumC).Visible = True             'WF枚数
                            .Cols(CMlngvsfBatInspectFlagC).Visible = True       '異物検査S1

                        End With


                    '@〓 その他 〓
                    Case Else

                        '@各種ﾎﾞﾀﾝ制御
                        cmdCarrierSelect.Enabled = False    'ULDｷｬﾘｱ選択ﾎﾞﾀﾝ：無効
                        cmdUP.Enabled = False               '"↑"ﾎﾞﾀﾝ：無効
                        cmdDown.Enabled = False             '"↓"ﾎﾞﾀﾝ：無効
                        cmdMonitorLotList.Enabled = True    'ﾓﾆﾀ選択ﾎﾞﾀﾝ：有効
                        cmdDummySelect.Enabled = False      'ﾀﾞﾐｰ冶具選択：無効

                        '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞの表示列を変更する
                        With vsfBat

                            '@行数設定
                            .Row = -1
                            .Rows.Count = 1

                            '@非表示設定
                            .Cols(CMlngvsfBatJigIDC).Visible = False            '冶具ID
                            .Cols(CMlngvsfBatUldCarrierIDC).Visible = False     'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                            .Cols(CMlngvsfBatWFIDC).Visible = False             'WFID

                            '@表示設定
                            .Cols(CMlngvsfBatCarrierIdC).Visible = True         'ｷｬﾘｱID
                        End With

                End Select

            End If


            '@-----------------------
            '@ ﾊﾞｯﾁ編成状態の確認
            '@-----------------------
            '@①製品ﾛｯﾄが0件か
            If vsfProduct.Row < 1 Then
                Exit Sub
            End If

            '@②既にﾊﾞｯﾁ編成中か
            If vsfProduct.GetCellRange(vsfProduct.Row, mlngvsfLotNoC).StyleDisplay.ForeColor = ColorTranslator.FromWin32(CMlngEnableFalseForeColor) Then
                Exit Sub
            End If

            '@③ﾚｼﾋﾟ未設定か
            If Trim$(vsfProduct.GetData(vsfProduct.Row, mlngvsfLotRecipeIdC)) = vbNullString Then
                Exit Sub
            End If

            '@④装置名が未選択か
            If cmbWpName.Text = vbNullString Then
                Exit Sub
            End If

            '@⑤最大ﾛｯﾄ数が設定されていないか
            If IsNumeric(lblMaxLotCnt.Text) = False Then
                Exit Sub
            End If

            '@⑥ﾊﾞｯﾁ組予定ﾛｯﾄ一覧のﾃﾞｰﾀが最大ﾛｯﾄ数より大きいか
            If vsfBat.Rows.Count - 1 > CLng(lblMaxLotCnt.Text) Then
                Exit Sub
            End If

            '@⑦ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞが有効か
            If vsfBat.Enabled = False Then
                Exit Sub
            End If


            '@★ 製品ﾛｯﾄの使用可能装置により処理分岐 ★
            Select Case vsfProduct.GetData(vsfProduct.Row, cmbWpName.ListIndex + 1)

                '@〓 "△" or "○" or "◎" 〓
                Case CMstrKouho, CMstrJidou, CMstrKakutei

                    '@使用可能

                '@〓 その他(NULL) 〓
                Case Else

                    '@使用不可
                    Exit Sub

            End Select

            '@ﾚｼﾋﾟ未設定か
            If lblRecipeID.Text = vbNullString Then

                '@">"ﾎﾞﾀﾝを有効にする
                cmdMove.Enabled = True
            Else
                '@ﾚｼﾋﾟが同一か
                If vsfProduct.GetData(vsfProduct.Row, mlngvsfLotRecipeIdC) = lblRecipeID.Text Then

                    '@">"ﾎﾞﾀﾝを有効にする
                    cmdMove.Enabled = True
                End If
            End If

            '表面処理予約一括移動
            If vsfProduct.GetData(vsfProduct.Row, mlngvsfLotHReserveC) <> vbNullString Then
                cmdMoveAll.Enabled = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbWpName_Change"           'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWpName_CloseUp
    '機　能：[装置名]ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 14:58:20 T.Kitagawa
    '更新日：2009/06/04 (Thu) 16:01:09 N.Kojima
    '備　考：
    '　　　：2005/07/12 (Tue) 17:50:34 N.Kojima     選択装置の運用ﾓｰﾄﾞが「S2」の場合は、ﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞを無効にする(不具合№2932)
    '　　　：2009/06/04 (Thu) 16:01:09 N.Kojima     無機対応。(案件№03560)
    Private Sub cmbWpName_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWpName.CloseUp

        Try

            '@装置ｺﾝﾎﾞの値取得列を「運用ﾓｰﾄﾞ」列に変更
            cmbWpName.ValueCol = CMlngCmbWpNameMesModeID

            '@選択装置の運用ﾓｰﾄﾞが「S2」か
            If cmbWpName.Value = CPstrS2 Then

                '@各種ｺﾝﾄﾛｰﾙの無効化
                cmdMove.Enabled = False             '">"ﾎﾞﾀﾝ
                cmdRemove.Enabled = False           '"<"ﾎﾞﾀﾝ
                cmdMonitorLotList.Enabled = False   'ﾓﾆﾀ選択ﾎﾞﾀﾝ
            End If

            '@装置ｺﾝﾎﾞの値取得列を「装置名」列に戻す
            cmbWpName.ValueCol = CMlngCmbWpNameName

            '@装置名が選択されているか
            If cmbWpName.Text <> vbNullString Then

                '@=======================
                '@ 装置名ｺﾝﾎﾞのValidate処理
                '@=======================
                Call cmbWpName_Validate(True, New CancelEventArgs)

                '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
                SendKeys.SendWait(CPstrSendKeysTab)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbWpName_CloseUp"          'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWpName_Validate
    '機　能：[装置名]ｺﾝﾎﾞ　選択確定時処理(Validate処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/02 (Mon) 09:44:26 T.Kitagawa
    '更新日：2009/12/01 (Tue) 17:02:05 N.Kojima
    '備　考：
    '　　　：2009/06/04 (Thu) 16:02:54 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/12/01 (Tue) 17:02:05 N.Kojima     蒸着処理条件取得判定ﾌﾗｸﾞの初期化処理追加。(案件№03790)
    Private Sub cmbWpName_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbWpName.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@装置名が選択されていない、または前回選択装置と同じか
            If cmbWpName.Text = vbNullString Or _
                cmbWpName.ListIndex = mlngOldcmbWpNameIndex Then

                Exit Sub
            End If

            '@前回選択の装置名ｺﾝﾎﾞのINDEXを退避し覚えておく
            mlngOldcmbWpNameIndex = cmbWpName.ListIndex

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbWpName_Validate"         'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
    '作成日：2004/07/26 (Mon) 11:26:26 T.Kitagawa
    '更新日：2009/06/04 (Thu) 13:53:42 N.Kojima
    '備　考：
    '　　　：2004/10/18 (Mon) 16:22:35 N.Kasai      0件ﾒｯｾｰｼﾞｺﾒﾝﾄｱｳﾄ
    '　　　：2009/06/04 (Thu) 13:53:42 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdLotList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotList.Click

        Dim llngAns     As Integer      'ﾒｯｾｰｼﾞBox戻り値格納用

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@編集中の場合は内容が初期化されるのでﾒｯｾｰｼﾞBOXを表示する
            If mblnInEditKbn = True Then

                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM0PW>$$バッチ編成中です。 内容を破棄してよろしいですか？"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000P)
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                '@「いいえ」が選択されたか
                If llngAns = vbNo Then

                    '@処理ｷｬﾝｾﾙ
                    Exit Sub
                End If
            End If

            '@ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞが未選択か
            If cmbMcGpName.Text = vbNullString Then
                Exit Sub
            End If

            '@=======================
            '@ ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ内容の初期化
            '@=======================
            Call prvALLInfo_Init()

            '@=======================
            '@ ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ内容の表示
            '@=======================
            Call prvALLInfo_Sel()

            '@ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟIDを退避する
            mstrOldMcGroupID = cmbMcGpName.Value

            '@装置名が1件以上存在し、かつ製品ﾛｯﾄが1ﾛｯﾄ以上あるか
            If mlngWpListCnt > 0 And vsfProduct.Rows.Count > 1 Then
                '@両方ある場合

                '@装置名ｺﾝﾎﾞが有効か
                If cmbWpName.Enabled = True Then

                    '@装置名ｺﾝﾎﾞへﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbWpName)
                End If
            Else
                '@どちらかが0件の場合

                '@製品ﾛｯﾄが0件か
                If vsfProduct.Rows.Count = 1 Then

                    '@ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbMcGpName)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdLotList_Click"           'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfBat_AfterEdit
    '機　能：[ﾊﾞｯﾁ組予定ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　編集後処理
    '引　数：Row：選択行
    '　　　：Col：選択列
    '戻り値：なし
    '作成日：2009/06/18 (Thu) 11:06:59 N.Kojima
    '更新日：2009/06/18 (Thu) 11:06:59
    '備　考：
    Private Sub vsfBat_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfBat.AfterEdit

        Dim lstrSelectWPEqType      As String       '選択装置の装置ﾀｲﾌﾟ
        Dim lstrChkString           As String       'ﾁｪｯｸ用文字列
        Dim llngCnt                 As Integer      '汎用ｶｳﾝﾀ
        Dim lblnAns                 As Boolean      '戻り値

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfBat.Rows.Count <= vsfBat.Rows.Fixed Then
                Return
            End If

            '@装置名ｺﾝﾎﾞの値取得列を「装置ﾀｲﾌﾟ(EqType)」列に変更
            cmbWpName.ValueCol = CMlngCmbWpNameEqType

            '@選択装置の装置ﾀｲﾌﾟを格納
            lstrSelectWPEqType = cmbWpName.Value

            '@装置名ｺﾝﾎﾞの値取得列を「装置名」列に戻す
            cmbWpName.ValueCol = CMlngCmbWpNameName


            '@選択装置が"20：表面処理装置"か
            If lstrSelectWPEqType = CPstrEqTypeHyoumenSyori Then

                With vsfBat

                    '@編集前と編集後のULDｷｬﾘｱIDが同じか
                    If mstrBeforeUldCarrierID = .GetData(.Row, CMlngvsfBatUldCarrierIDC) Then
                        Exit Sub
                    End If

                    '@=======================
                    '@ ｱﾝﾛｰﾀﾞｷｬﾘｱIDの文字変換
                    '@=======================
                    .SetData(.Row, CMlngvsfBatUldCarrierIDC, _
                        pubstrChangeString_Exec(.GetData(.Row, CMlngvsfBatUldCarrierIDC)))

                    '@変換値を格納
                    lstrChkString = .GetData(.Row, CMlngvsfBatUldCarrierIDC)

                    '@★ 選択列により処理分岐 ★
                    Select Case .Col

                        '@〓 ULDｷｬﾘｱID 〓
                        Case CMlngvsfBatUldCarrierIDC

                            '@「ULDｷｬﾘｱID」が6byte(ｷｬﾘｱIDの最大文字数)を超えているか
                            If LenB(lstrChkString) > CPlngCarrierMaxLength Then
                                '@6byte以上

                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                                '@「"<TRM07W>$$キャリアIDは6桁で入力してください。"」のﾒｯｾｰｼﾞ表示
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                                '@編集状態に
                                .Styles.Editor.BackColor = SystemColors.Window
                                .Styles.Editor.ForeColor = SystemColors.WindowText
                                .StartEditing()

                                cmdKakutei.Enabled = False   '確定：無効

                                Exit Sub
                            End If

                            '@=======================
                            '@ ｱﾝﾛｰﾀﾞｷｬﾘｱ重複ﾁｪｯｸ処理
                            '@=======================
                            lblnAns = prvblnJyufuku_Chk(e.Row, lstrChkString)

                            '@重複ﾁｪｯｸ処理結果が"True：重複あり"か
                            If lblnAns = True Then

                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009M)
                                '@"<TRM9MW>$$治具IDが重複しています。設定を見直してください。
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                                '@ｱﾝﾛｰﾀﾞｷｬﾘｱを削除
                                vsfBat.SetData(e.Row, CMlngvsfBatUldCarrierIDC, vbNullString)

                                Exit Sub
                            End If

                    End Select

                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULLか
                    If .GetData(.Row, CMlngvsfBatUldCarrierIDC) = vbNullString Then

                        cmdKakutei.Enabled = False   '確定：無効
                        Exit Sub
                    End If

                    '@=======================
                    '@ ｱﾝﾛｰﾀﾞｷｬﾘｱﾁｪｯｸ処理
                    '@=======================
                    lblnAns = prvblnUldCarrier_Chk

                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱﾁｪｯｸ処理結果が"True：ﾁｪｯｸOK"か
                    If lblnAns = True Then

                        '@一旦、確定ﾎﾞﾀﾝを有効にする
                        cmdKakutei.Enabled = True

                        For llngCnt = 1 To .Rows.Count - 1

                            '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULLか
                            If .GetData(llngCnt, CMlngvsfBatUldCarrierIDC) = vbNullString Then

                                '@確定ﾎﾞﾀﾝを無効にする
                                cmdKakutei.Enabled = False

                                '未入力の項目へ移動
                                .Row = llngCnt
                                .Col = CMlngvsfBatUldCarrierIDC
                                Exit For

                            End If
                        Next llngCnt
                    Else
                        '@ｱﾝﾛｰﾀﾞｷｬﾘｱﾁｪｯｸ処理結果が"False：ﾁｪｯｸNG"か

                        .Row = e.Row
                        .Col = e.Col

                        '@確定ﾎﾞﾀﾝを無効にする
                        cmdKakutei.Enabled = False
                    End If
                End With
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfBat_AfterEdit"           'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfBat_BeforeEdit
    '機　能：[ﾊﾞｯﾁ組予定ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　編集後処理
    '引　数：Row        ：選択行
    '　　　：Col        ：選択列
    '　　　：Cancel     ：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2009/08/18 (Tue) 17:27:53 N.Kojima
    '更新日：2009/08/18 (Tue) 17:27:53
    '備　考：
    Private Sub vsfBat_BeforeEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfBat.StartEdit

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfBat.Rows.Count <= vsfBat.Rows.Fixed Then
                Return
            End If

            With vsfBat

                '@選択行のULDｷｬﾘｱIDを退避
                mstrBeforeUldCarrierID = .GetData(.Row, CMlngvsfBatUldCarrierIDC)

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfBat_BeforeEdit"          'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfBat_DblClick
    '機　能：[ﾊﾞｯﾁ組予定ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ﾀﾞﾌﾞﾙｸﾘｯｸ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/06/18 (Thu) 11:48:13 N.Kojima
    '更新日：2016/07/04 (Mon) 15:42:03 T.Oide
    '備　考：
    '　　　：2009/08/17 (Mon) 17:49:34 N.Kojima     無機対応Phase3、FILLERのｱﾝﾛｰﾀﾞｷｬﾘｱ仕様追加に伴い、編集可状態にする場合のﾁｪｯｸ処理を修正。(案件№03704)
    Private Sub vsfBat_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfBat.DoubleClick

        Dim lstrSelectWPEqType      As String       '選択装置の装置ﾀｲﾌﾟ

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfBat.Rows.Count <= vsfBat.Rows.Fixed Then
                Return
            End If

            With vsfBat

                '@ﾊﾞｯﾁ編成一覧のﾃﾞｰﾀ行が選択されているか
                If vsfBatList.Row > 0 Then

                    '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞの選択行がﾃﾞｰﾀ行以外、または編集状態以外か
                    If .Row < 1 Or mblnInEditKbn = False Then
                        Exit Sub
                    End If
                Else
                    '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞの選択行がﾃﾞｰﾀ行以外か
                    If .Row < 1 Then
                        Exit Sub
                    End If
                End If

                '@装置名ｺﾝﾎﾞの値取得列を「装置ﾀｲﾌﾟ(EqType)」列に変更
                cmbWpName.ValueCol = CMlngCmbWpNameEqType

                '@選択装置の装置ﾀｲﾌﾟを格納
                lstrSelectWPEqType = cmbWpName.Value

                '@装置名ｺﾝﾎﾞの値取得列を「装置名」列に戻す
                cmbWpName.ValueCol = CMlngCmbWpNameName


                '@選択装置が"20：表面処理装置"、かつｱﾝﾛｰﾀﾞｷｬﾘｱ列、かつTFTﾛｯﾄ、かつ"FILLER"ﾛｯﾄ以外 and "MONITOR"ﾛｯﾄ以外か
                If lstrSelectWPEqType = CPstrEqTypeHyoumenSyori And _
                    .Col = CMlngvsfBatUldCarrierIDC And _
                    .GetData(.Row, CMlngvsfBatPanelKindC) = CPstrZero And _
                    (.GetData(.Row, CMlngvsfBatUseIDC) <> CPstrUseIDFiller And _
                    .GetData(.Row, CMlngvsfBatUseIDC) <> CPstrUseIDDummy) Then

                    '@Teg品(GG)は、ﾀﾞﾐｰとして運用しているため、ULDｷｬﾘｱは平行移動に仕様変更
                    If .GetData(.Row, CMlngvsfBatFlowClassC) <> CPstrFlowClassGG Then
                        '@編集状態にする
                        .Styles.Editor.BackColor = SystemColors.Window
                        .Styles.Editor.ForeColor = SystemColors.WindowText
                        .StartEditing()
                    End If
                End If

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfBat_DblClick"            'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfBat_EnterCell
    '機　能：[ﾊﾞｯﾁ組予定ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ｶﾚﾝﾄ行列変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 15:29:15 T.Kitagawa
    '更新日：2016/07/04 (Mon) 15:41:50 T.Oide
    '備　考：
    '　　　：2004/09/15 (Wed) 18:23:58 N.Kasai　    "<"ﾎﾞﾀﾝの使用可能設定追加
    '　　　：2009/06/04 (Thu) 16:04:33 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/08/17 (Mon) 17:49:34 N.Kojima     無機対応Phase3、FILLERのｱﾝﾛｰﾀﾞｷｬﾘｱ仕様追加に伴い、編集可状態にする場合のﾁｪｯｸ処理を修正。(案件№03704)
    '　　　：2010/07/05 (Mon) 11:56:54 T.Oide       No.04123対応(斜方蒸着ﾚｼﾋﾟ自動選択)
    Private Sub vsfBat_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfBat.EnterCell

        Dim lstrSelectWPEqType          As String       '選択装置の装置ﾀｲﾌﾟ

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfBat.Rows.Count <= vsfBat.Rows.Fixed Then
                Return
            End If

            '@***********************
            '@ ★処理概要
            '@　・"<"ﾎﾞﾀﾝ、"↑"ﾎﾞﾀﾝ、"↓"ﾎﾞﾀﾝの制御
            '@***********************

            With vsfBat

                '@ﾊﾞｯﾁ編成一覧のﾃﾞｰﾀ行が選択されているか
                If vsfBatList.Row > 0 Then

                    '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞの選択行がﾃﾞｰﾀ行以外、または編集状態以外か
                    If .Row < 1 Or mblnInEditKbn = False Then
                        Exit Sub
                    End If
                Else
                    '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞの選択行がﾃﾞｰﾀ行以外か
                    If .Row < 1 Then
                        Exit Sub
                    End If
                End If


                '@起動SBが"2A0：組立"か
                If pstrSBID = CPstrSBID2A0 Then

                    '@装置名ｺﾝﾎﾞの値取得列を「装置ﾀｲﾌﾟ(EqType)」列に変更
                    cmbWpName.ValueCol = CMlngCmbWpNameEqType

                    '@選択装置の装置ﾀｲﾌﾟを格納
                    lstrSelectWPEqType = cmbWpName.Value

                    '@装置名ｺﾝﾎﾞの値取得列を「装置名」列に戻す
                    cmbWpName.ValueCol = CMlngCmbWpNameName


                    '@★ 選択装置の装置ﾀｲﾌﾟにより処理分岐 ★
                    Select Case lstrSelectWPEqType

                        '@〓 19：斜方蒸着装置 〓
                        Case CPstrEqTypeJyoucyaku

                            '@-----------------------
                            '@ ﾀﾞﾐｰ冶具選択ﾎﾞﾀﾝ制御
                            '@-----------------------
                            '@選択行のﾛｯﾄIDがNULLか
                            If .GetData(.Row, CMlngvsfBatLotIdC) = vbNullString Then

                                '@ﾀﾞﾐｰ冶具選択ﾎﾞﾀﾝを有効にする
                                cmdDummySelect.Enabled = True
                            Else
                                '@ﾀﾞﾐｰ冶具選択ﾎﾞﾀﾝを無効にする
                                cmdDummySelect.Enabled = False
                            End If


                            '@-----------------------
                            '@ "↑"ﾎﾞﾀﾝ制御
                            '@-----------------------
                            '@選択行がﾃﾞｰﾀ行で、かつ先頭行以外か
                            If .Row >= 1 And .Row <> .TopRow Then
                                    '@"↑"ﾎﾞﾀﾝを有効にする
                                    cmdUP.Enabled = True
                            Else
                                '@選択行がﾃﾞｰﾀ行以外、または先頭行の場合
                                '@"↑"ﾎﾞﾀﾝを無効にする
                                cmdUP.Enabled = False
                            End If


                            '@-----------------------
                            '@ "↓"ﾎﾞﾀﾝ制御
                            '@-----------------------
                            '@選択行がﾃﾞｰﾀ行で、かつ最終行以外か
                            If .Row >= 1 And .Row <> .Rows.Count - 1 Then
                                '@"↓"ﾎﾞﾀﾝを有効にする
                                cmdDown.Enabled = True
                            Else
                                '@"↓"ﾎﾞﾀﾝを無効にする
                                cmdDown.Enabled = False
                            End If


                            '@-----------------------
                            '@ "<"ﾎﾞﾀﾝ制御
                            '@-----------------------
                            '@選択行のWFIDがNULL以外、かつ"未使用"以外か
                            If .GetData(.Row, CMlngvsfBatWFIDC) <> vbNullString And _
                                InStr(1, .GetData(.Row, CMlngvsfBatWFIDC), CMstrNotUse) = 0 Then

                                '@"<"ﾎﾞﾀﾝを有効にする
                                cmdRemove.Enabled = True
                            Else
                                '@"<"ﾎﾞﾀﾝを無効にする
                                cmdRemove.Enabled = False
                            End If


                        '@〓 20：表面処理装置 〓
                        Case CPstrEqTypeHyoumenSyori

                            '@対象ﾛｯﾄが"FILLER"ﾛｯﾄ以外 and "DUMMY"ﾛｯﾄ以外か
                            If (.GetData(.Row, CMlngvsfBatUseIDC) <> CPstrUseIDFiller And _
                                .GetData(.Row, CMlngvsfBatUseIDC) <> CPstrUseIDDummy) Then

                                '@ 選択ｾﾙの列が"ｱﾝﾛｰﾀﾞｷｬﾘｱID"列で、かつ
                                '@ Cfﾌﾗｸﾞ列の値が"0:TFT"か大板(ODF)の場合、
                                '@ ULDｷｬﾘｱを設定可能にする
                                '@ ※CF(小板)の場合はLDｷｬﾘｱ⇒ULDｷｬﾘｱと平行移載になる為、ULDｷｬﾘｱは選択させない
                                If .Col = CMlngvsfBatUldCarrierIDC And _
                                   (.GetData(.Row, CMlngvsfBatPanelKindC) = CPstrZero Or _
                                    .GetData(.Row, CMlngvsfBatLpFlagC) = CPstrOne) Then
                                    
                                    '@Teg品(GG)は、ﾀﾞﾐｰとして運用しているため、ULDｷｬﾘｱは平行移動に仕様変更
                                    If .GetData(.Row, CMlngvsfBatFlowClassC) <> CPstrFlowClassGG Then
                                        '@直接入力を可にする
                                        .Styles.Editor.BackColor = SystemColors.Window
                                        .Styles.Editor.ForeColor = SystemColors.WindowText
                                        .StartEditing()
                                    End If
                                        
                                End If

                                '@CF(小板)以外、またはTeg(GG)はULDｷｬﾘｱ選択ﾎﾞﾀﾝを有効にする(TFTとODFは有効)
                                cmdCarrierSelect.Enabled = True
                                If (.GetData(.Row, CMlngvsfBatPanelKindC) = CPstrOne And _
                                    .GetData(.Row, CMlngvsfBatLpFlagC) = CPstrZero) Or _
                                   .GetData(.Row, CMlngvsfBatFlowClassC) = CPstrFlowClassGG Then
                                   
                                   '@ULDｷｬﾘｱ選択ﾎﾞﾀﾝを無効にする
                                   cmdCarrierSelect.Enabled = False
                                    
                                End If
                            End If

                    End Select

                    '@選択装置が"19：斜方蒸着装置"以外か
                    If lstrSelectWPEqType <> CPstrEqTypeJyoucyaku Then

                        '@-----------------------
                        '@ "<"ﾎﾞﾀﾝ制御
                        '@-----------------------
                        '@選択行のﾛｯﾄIDがNULL以外か
                        If .GetData(.Row, CMlngvsfBatLotIdC) <> vbNullString Then

                            '@"<"ﾎﾞﾀﾝを有効にする
                            cmdRemove.Enabled = True
                        Else
                            '@"<"ﾎﾞﾀﾝを無効にする
                            cmdRemove.Enabled = False
                        End If
                    End If

                Else
                    '@起動SBが基板の場合

                    '@-----------------------
                    '@ "<"ﾎﾞﾀﾝ制御
                    '@-----------------------
                    '@選択行のﾛｯﾄIDがNULLか
                    If .GetData(.Row, CMlngvsfBatLotIdC) = vbNullString Then
                        Exit Sub
                    End If

                    '@装置名ｺﾝﾎﾞが無効か
                    If cmbWpName.Enabled = False Then

                        '@編集中(True)か
                        If mblnInEditKbn = True Then

                            '@"<"ﾎﾞﾀﾝを有効にする
                            cmdRemove.Enabled = True
                        End If
                    Else
                        '@装置名ｺﾝﾎﾞが有効

                        '@"<"ﾎﾞﾀﾝを有効にする
                        cmdRemove.Enabled = True
                    End If
                End If

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfBat_EnterCell"           'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfBat_KeyDown
    '機　能：[ﾊﾞｯﾁ組予定ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ｷｰ押下時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：未使用
    '戻り値：なし
    '作成日：2009/06/23 (Tue) 15:10:19 N.Kojima
    '更新日：2009/08/17 (Mon) 17:49:34 N.Kojima
    '備　考：
    '　　　：2009/08/17 (Mon) 17:49:34 N.Kojima     無機対応Phase3、FILLERのｱﾝﾛｰﾀﾞｷｬﾘｱ仕様追加に伴い、編集可状態にする場合のﾁｪｯｸ処理を修正。(案件№03704)
    Private Sub vsfBat_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles vsfBat.KeyDown

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfBat.Rows.Count <= vsfBat.Rows.Fixed Then
                Return
            End If

            With vsfBat

                '@ﾍｯﾀﾞｰ行の場合、処理中止
                If .Row = 0 Then
                    Exit Sub
                End If

                '@★ ｷｰｺｰﾄﾞにより処理分岐 ★
                Select Case e.KeyCode

                    '@〓 "↑","↓","→","←"ｷｰ 〓
                    Case Keys.Up, Keys.Down, Keys.Left, Keys.Right

                        '@処理なし


                    '@〓 その他 〓
                    Case Else

                        '@TFTﾛｯﾄで、かつULDｷｬﾘｱ列、かつ"FILLER"ﾛｯﾄ以外 and "DUMMY"ﾛｯﾄ以外か
                        'If .GetData(.Row, CMlngvsfBatPanelKindC) = CPstrZero And _
                        '    .Col = .GetData(.Row, CMlngvsfBatUldCarrierIDC) And _
                        '    (.GetData(.Row, CMlngvsfBatUseIDC) <> CPstrUseIDFiller And _
                        '    .GetData(.Row, CMlngvsfBatUseIDC) <> CPstrUseIDDummy) Then

                        '    '@ｽﾍﾟｰｽは無効
                        '    If e.KeyCode = Keys.Space Then
                        '        e.Handled = True
                        '    End If

                        '    '@編集可能ｾﾙの場合
                        '    .Select(.Row, .Col)      '編集可能ｾﾙの範囲選択
                        '    .Styles.Editor.BackColor = SystemColors.Window
                        '    .Styles.Editor.ForeColor = SystemColors.WindowText
                        '    .StartEditing()          '編集可能にする
                        'End If

                End Select
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfBat_KeyDown"             'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfBat_KeyPressEdit
    '機　能：[ﾊﾞｯﾁ組予定ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ ｷｰ押下編集時処理
    '引　数：Row     ：未使用
    '　　　：Col     ：列
    '　　　：KeyAscii：ｱｽｷｰｺｰﾄﾞ
    '戻り値：なし
    '作成日：2009/06/23 (Tue) 15:10:19 N.Kojima
    '更新日：2009/08/17 (Mon) 17:49:34 N.Kojima
    '備　考：
    '　　　：2009/08/17 (Mon) 17:49:34 N.Kojima     無機対応Phase3、FILLERのｱﾝﾛｰﾀﾞｷｬﾘｱ仕様追加に伴い、編集可状態にする場合のﾁｪｯｸ処理を修正。(案件№03704)
    Private Sub vsfBat_KeyPressEdit(ByVal sender As Object, ByVal e As KeyPressEditEventArgs) Handles vsfBat.KeyPressEdit

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfBat.Rows.Count <= vsfBat.Rows.Fixed Then
                Return
            End If

            With vsfBat

                '@TFTﾛｯﾄで、かつULDｷｬﾘｱ列、かつ"FILLER"ﾛｯﾄ以外 and "DUMMY"ﾛｯﾄ以外か
                If .GetData(.Row, CMlngvsfBatPanelKindC) = CPstrZero And _
                    .Col = CMlngvsfBatUldCarrierIDC And _
                    (.GetData(.Row, CMlngvsfBatUseIDC) <> CPstrUseIDFiller And _
                    .GetData(.Row, CMlngvsfBatUseIDC) <> CPstrUseIDDummy) Then

                    '@★ ｷｰｺｰﾄﾞにより処理分岐 ★
                    Select Case Asc(e.KeyChar)

                        '@〓 半角英数字、ﾊﾞｯｸｽﾍﾟｰｽ、Enterｷｰ 〓
                        Case CPlngKeyAsciiNum0 To CPlngKeyAsciiNum9, _
                                CPlngKeyAsciiUppA To CPlngKeyAsciiUppZ, _
                                CPlngKeyBackSpace, CPlngKeyReturn

                            '@処理なし

                        '@〓 その他 〓
                        Case Else

                            '@ｷｰ無効
                            e.Handled = True

                    End Select
                End If

            End With

            '@[']の入力禁止
            If Asc(e.KeyChar) = CPlngKeyAscSingleQ Then
                e.Handled = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfBat_KeyPressEdit"        'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：[ ↑ ]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/06/12 (Fri) 14:29:40 N.Kojima
    '更新日：2009/06/12 (Fri) 14:29:40
    '備　考：
    Private Sub cmdUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUp.Click

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            With vsfBat

                '@選択行が先頭行以外のﾃﾞｰﾀ行か
                If .Row > 1 Then

                    '@選択行を1行上に移動
                    .Rows.Move(.Row, .Row - 1)
                 End If

                '@順の振り直し＆確定ﾎﾞﾀﾝ制御
                For llngCnt = 1 To .Rows.Count - 1

                    .SetData(llngCnt, CMlngvsfBatSeqNumC, llngCnt)

                    '@製品ﾛｯﾄが1ﾛｯﾄ以上存在するか
                    If .GetData(llngCnt, CMlngvsfBatLotIdC) <> vbNullString Then

                        '@確定ﾎﾞﾀﾝを有効にする
                        cmdKakutei.Enabled = True
                    End If
                Next llngCnt

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdUp_Click"                'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown_Click
    '機　能：[ ↓ ]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/06/12 (Fri) 14:29:40 N.Kojima
    '更新日：2009/06/12 (Fri) 14:29:40
    '備　考：
    Private Sub cmdDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown.Click

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            With vsfBat

                '@選択行がﾃﾞｰﾀ行で、かつ最終行以外か
                If .Row >= 1 And .Row <> .Rows.Count - 1 Then

                    '@選択行を1行下に移動
                    .Rows.Move(.Row, .Row + 1)
                End If

                '@順の振り直し
                For llngCnt = 1 To .Rows.Count - 1

                    .SetData(llngCnt, CMlngvsfBatSeqNumC, llngCnt)

                    '@製品ﾛｯﾄが1ﾛｯﾄ以上存在するか
                    If .GetData(llngCnt, CMlngvsfBatLotIdC) <> vbNullString Then

                        '@確定ﾎﾞﾀﾝを有効にする
                        cmdKakutei.Enabled = True
                    End If
                Next llngCnt

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdDown_Click"              'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCarrierSelect_Click
    '機　能：[ULDｷｬﾘｱ選択]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/06/05 (Fri) 10:37:00 N.Kojima
    '更新日：2009/06/05 (Fri) 10:37:00
    '備　考：
    Private Sub cmdCarrierSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCarrierSelect.Click

        Dim llngCnt                 As Integer      '汎用ｶｳﾝﾀ
        Dim lstrSelectWPEqType      As String       '選択装置の装置ﾀｲﾌﾟ
        Dim lblnAnsChk              As Boolean      '結果格納

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

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            pblnFormLoad = False

            '@ｷｬﾘｱ条件の格納
            pstrCarrierTypeID = CPstrCarrTypeHotOP      'ｷｬﾘｱﾀｲﾌﾟ：耐熱ｵｰﾌﾟﾝｶｾｯﾄ限定
            pstrCleanCondition = CPstrCarrierClean4     '洗浄条件：空、洗浄済


            '@装置名ｺﾝﾎﾞの値取得列を「装置ﾀｲﾌﾟ(EqType)」列に変更
            cmbWpName.ValueCol = CMlngCmbWpNameEqType

            '@選択装置の装置ﾀｲﾌﾟを格納
            lstrSelectWPEqType = cmbWpName.Value

            '@装置名ｺﾝﾎﾞの値取得列を「装置名」列に戻す
            cmbWpName.ValueCol = CMlngCmbWpNameName
            
            '選択装置によりキャリアカテゴリを変更
            '蒸着装置
            If lstrSelectWPEqType = CPstrEqTypeJyoucyaku Then
                pstrCarrierCategoryID = CPstrCarrCateJyo
            '表面処理
            ElseIf lstrSelectWPEqType = CPstrEqTypeHyoumenSyori Then
                pstrCarrierCategoryID = CPstrCarrCateHyo
            'その他
            Else
                pstrCarrierCategoryID = vbNullString
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 空きｷｬﾘｱ一覧　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00K0.Instance = New frmxxCM00K0()

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False：起動失敗"か
            If pblnFormLoad = False Then

                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM00K0.Instance = Nothing

                Exit Sub
            End If

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 空きｷｬﾘｱ一覧　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00K0.Instance.ShowDialog(Me)
            frmxxCM00K0.Instance = Nothing

            '@ｱﾝﾛｰﾀﾞｷｬﾘｱが選択されているか
            If pstrCarrierID <> vbNullString Then

                '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDをｾｯﾄ
                vsfBat.SetData(vsfBat.Row, CMlngvsfBatUldCarrierIDC, pstrCarrierID)
            End If

            '@使用したﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrCarrierTypeID = vbNullString                'ｷｬﾘｱﾀｲﾌﾟ
            pstrCleanCondition = vbNullString               '洗浄条件
            pstrCarrierID = vbNullString                    'ｷｬﾘｱID
            pstrCarrierCategoryID = vbNullString 

            ''@装置名ｺﾝﾎﾞの値取得列を「装置ﾀｲﾌﾟ(EqType)」列に変更
            'cmbWpName.ValueCol = CMlngCmbWpNameEqType

            ''@選択装置の装置ﾀｲﾌﾟを格納
            'lstrSelectWPEqType = cmbWpName.Value

            ''@装置名ｺﾝﾎﾞの値取得列を「装置名」列に戻す
            'cmbWpName.ValueCol = CMlngCmbWpNameName


            '@選択装置が"20：表面処理装置"の場合は以下を追加でﾁｪｯｸ
            If lstrSelectWPEqType = CPstrEqTypeHyoumenSyori Then

                '@一旦、確定ﾎﾞﾀﾝを有効にする
                cmdKakutei.Enabled = True

                For llngCnt = 1 To vsfBat.Rows.Count - 1

                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULLか
                    If vsfBat.GetData(llngCnt, CMlngvsfBatUldCarrierIDC) = vbNullString Then

                        '@確定ﾎﾞﾀﾝを無効にする
                        cmdKakutei.Enabled = False
                    End If
                Next llngCnt
            End If


            '@=======================
            '@ ｱﾝﾛｰﾀﾞｷｬﾘｱID重複ﾁｪｯｸ処理
            '@=======================
            lblnAnsChk = prvblnJyufuku_Chk(vsfBat.Row, vsfBat.GetData(vsfBat.Row, CMlngvsfBatUldCarrierIDC))

            '@重複ﾌﾗｸﾞがTrueならｴﾗｰ表示
            If lblnAnsChk = True Then

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009M)
                '@"<TRM9MW>$$治具IDが重複しています。設定を見直してください。
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@ｱﾝﾛｰﾀﾞｷｬﾘｱを削除
                vsfBat.SetData(vsfBat.Row, CMlngvsfBatUldCarrierIDC, vbNullString)

                Exit Sub
            End If


            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdCarrierSelect_Click"     'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfBatList_BeforeSort
    '機　能：[ﾊﾞｯﾁ編成一覧]ｸﾞﾘｯﾄﾞ　ｿｰﾄ前処理
    '引　数：Col    ：列番号
    '　　　：Order  ：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/07/26 (Mon) 09:59:19 T.Kitagawa
    '更新日：2009/06/04 (Thu) 16:07:46 N.Kojima
    '備　考：
    '　　　：2009/06/04 (Thu) 16:07:46 N.Kojima     無機対応。(案件№03560)
    Private Sub vsfBatList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfBatList.BeforeSort

        Try

            'NSYS 不要なHandler処理を抑止
            RemoveHandler vsfBatList.BeforeRowColChange, AddressOf vsfBatList_BeforeRowColChange
            RemoveHandler vsfBatList.EnterCell, AddressOf vsfBatList_EnterCell

            'NSYS データ行がない場合は処理を抜ける
            If vsfBatList.Rows.Count <= vsfBatList.Rows.Fixed Then
                Return
            End If

            '@=======================
            '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納処理(ｸﾞﾘｯﾄﾞ、保持列)(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfBeforeSort(vsfBatList, CMlngGridTitleCol)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfBatList_BeforeSort"      'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfBatList_AfterSort
    '機　能：[ﾊﾞｯﾁ編成一覧]ｸﾞﾘｯﾄﾞ　ｿｰﾄ後処理
    '引　数：Col    ：列番号
    '　　　：Order  ：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/07/26 (Mon) 09:59:15 T.Kitagawa
    '更新日：2009/06/04 (Thu) 16:08:54 N.Kojima
    '備　考：
    '　　　：2009/06/04 (Thu) 16:08:54 N.Kojima     無機対応。(案件№03560)
    Private Sub vsfBatList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfBatList.AfterSort

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfBatList.Rows.Count <= vsfBatList.Rows.Fixed Then
                Return
            End If

            '@=======================
            '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納処理(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfAfterSort(vsfBatList, CMlngGridTitleCol)

            'BeforeSortで除外していたRowColChangeイベントを復帰
            AddHandler vsfBatList.BeforeRowColChange, AddressOf vsfBatList_BeforeRowColChange
            AddHandler vsfBatList.EnterCell, AddressOf vsfBatList_EnterCell

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfBatList_AfterSort"       'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfBatList_BeforeRowColChange
    '機　能：[ﾊﾞｯﾁ編成一覧]ｸﾞﾘｯﾄﾞ　ｶﾚﾝﾄ行列変更前処理
    '引　数：OldRow ：旧行
    '　　　：OldCol ：旧列
    '　　　：NewRow ：新行
    '　　　：NewCol ：新列
    '　　　：Cancel ：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 19:37:41 T.Kitagawa
    '更新日：2009/06/04 (Thu) 16:09:40 N.Kojima
    '備　考：
    '　　　：2009/06/04 (Thu) 16:09:40 N.Kojima     無機対応。(案件№03560)
    Private Sub vsfBatList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfBatList.BeforeRowColChange

        Dim llngAns                 As Integer  '結果格納

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfBatList.Rows.Count <= vsfBatList.Rows.Fixed Then
                Return
            End If

            '@読み込み判定
            If e.NewRange.r1 < 1 Then
                Exit Sub
            End If

            '@編集中の場合は内容が初期化されるのでﾒｯｾｰｼﾞBOXを表示する
            If mblnInEditKbn = True Then

                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM0PW>$$バッチ編成中です。 内容を破棄してよろしいですか？"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000P)
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                '@「いいえ」が選択されたか
                If llngAns = vbNo Then

                    '@「いいえ」の場合、行列変更をｷｬﾝｾﾙ
                    e.Cancel = True
                    Exit Sub
                Else
                    '@「はい」の場合

                    Dim row As Integer
                    row = e.NewRange.r1

                    '@=======================
                    '@ ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ内容の初期化
                    '@=======================
                    Call prvALLInfo_Init()

                    '@=======================
                    '@ ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ内容の表示
                    '@=======================
                    Call prvALLInfo_Sel()

                    '@現在選択中のﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟIDを退避
                    mstrOldMcGroupID = cmbMcGpName.Value

                    'NSYS 選択位置戻し
                    vsfBatList.row = row
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "vsfBatList_BeforeRowColChange"  'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfBatList_EnterCell
    '機　能：[ﾊﾞｯﾁ編成一覧]ｸﾞﾘｯﾄﾞ　ｶﾚﾝﾄ行列変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 15:24:25 T.Kitagawa
    '更新日：2016/07/04 (Mon) 15:41:16 T.Oide
    '備　考：
    '　　　：2004/09/15 (Wed) 18:23:02 N.Kasai      ">"ﾎﾞﾀﾝの使用設定制御変更
    '　　　：2005/07/12 (Tue) 18:13:52 N.Kojima     ﾊﾞｯﾁ装置の運用ﾓｰﾄﾞが「S2」の場合、「編集,削除」両ﾎﾞﾀﾝを無効に(不具合№2932)
    '　　　：2009/06/04 (Thu) 16:12:23 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/24 (Fri) 14:25:37 N.Kojima     無機対応Phase2、製品区分追加。(案件№03661)
    '　　　：2009/08/05 (Wed) 09:35:39 N.Kojima     無機不具合対応、表面処理装置の場合、Cfﾌﾗｸﾞ列にCfﾌﾗｸﾞを格納する。(案件№03661)
    '　　　：2009/11/18 (Wed) 11:14:45 N.Kojima     (蒸着処理条件)有効/無効ﾗﾍﾞﾙの初期化処理、設定処理追加。(案件№03790)
    '　　　：2009/12/16 (Wed) 19:59:02 N.Kojima     蒸着処理条件、有効/無効の表示条件を変更。(緊急対応：案件№03908)
    '　　　：2010/07/05 (Mon) 11:56:54 T.Oide       No.04123対応(斜方蒸着ﾚｼﾋﾟ自動選択)
    '　　　：2011/09/01 (Thu) 15:51:26 T.Oide       R8-3 表面処理ODFアンローダキャリア変更対応
    '　　　：2012/03/12 (Mon) 09:41:52 T.Oide       無機装置追加対応(REQ-1303)
    '　　　：2012/04/09 (Mon) 10:07:25 T.Oide       R9-01-BR2 モニターロットが編成できない不具合対応
    Private Sub vsfBatList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfBatList.EnterCell

        Dim llngCnt                 As Integer  'ｶｳﾝﾀ(汎用)
        Dim lstrSelectWPEqType      As String   '選択装置の装置ﾀｲﾌﾟ
        Dim lngTmpValueCol          As Integer  'ValueCol一時退避用
        Dim lstrTmpLotId            As String   'ﾛｯﾄID格納
        Dim lngRowCnt               As Integer  'ｸﾞﾘｯﾄﾞ表示ｶｳﾝﾀ

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfBatList.Rows.Count <= vsfBatList.Rows.Fixed Then
                Return
            End If

            '@ﾊﾞｯﾁ編成一覧にﾃﾞｰﾀがないか
            If vsfBatList.Row < 1 Then
                Exit Sub
            End If

            '@装置名ｺﾝﾎﾞの初期設定
            cmbWpName.ListIndex = -1

            '@各種ﾗﾍﾞﾙのｸﾘｱ
            lblMaxLotCnt.Text = vbNullString             '最大ﾛｯﾄ数
            lblBatchID.Text = vbNullString               'ﾊﾞｯﾁID
            lblRecipeID.Text = vbNullString              'ﾚｼﾋﾟID
            lblBatLotWFCnt.Text = vbNullString           'ﾊﾞｯﾁ組WF枚数
            lblVaCondition.Text = vbNullString           '蒸着処理条件
            lblVaConditionFlag.Text = vbNullString       '(蒸着処理条件)有効/無効


            '@-----------------------
            '@ 装置名ｺﾝﾎﾞの設定
            '@-----------------------
            For llngCnt = mlngvsfBatListWpStartNoC To mlngvsfBatListWpEndNoC

                '@"◎"(確定装置)か
                If vsfBatList.GetData(vsfBatList.Row, llngCnt) = CMstrKakutei Then

                    '@確定装置を選択する
                    cmbWpName.ListIndex = llngCnt - 1
                    Exit For
                End If
            Next llngCnt

            '@各種ﾗﾍﾞﾙの設定
            lblMaxLotCnt.Text = mtypWpList(cmbWpName.ListIndex).strMaxProcessBox                '最大ﾛｯﾄ数
            lblBatchID.Text = vsfBatList.GetData(vsfBatList.Row, mlngvsfBatListBatchIdC)        'ﾊﾞｯﾁID
            lblRecipeID.Text = vsfBatList.GetData(vsfBatList.Row, mlngvsfBatListRecipeIdC)      'ﾚｼﾋﾟID
            lblBatLotWFCnt.Text = vsfBatList.GetData(vsfBatList.Row, mlngvsfBatListWfNumC)      'ﾊﾞｯﾁ組WF枚数

            '@下記は「prvblnMasVaConditionSel_Proc」で蒸着処理条件を設定出来なかった場合の対応

            '@蒸着処理条件がNULLか
            If lblVaCondition.Text = vbNullString Then

                lblVaCondition.Text = vsfBatList.GetData(vsfBatList.Row, mlngvsfBatListVaConditionIdC)          '蒸着処理条件
            
                '@蒸着処理条件制限ﾌﾗｸﾞが"0：無効"か
                If vsfBatList.GetData(vsfBatList.Row, mlngvsfBatListVaConditionFlagC) = CPstrZero Then
            
                    '@(蒸着処理条件)[有効/無効]ﾗﾍﾞﾙに"無効"を表示
                    lblVaConditionFlag.Text = CMstrInValid
                Else
                    '@(蒸着処理条件)[有効/無効]ﾗﾍﾞﾙに"有効"を表示
                    lblVaConditionFlag.Text = CMstrValid
                End If
            End If



            '@-----------------------
            '@ ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞの表示
            '@-----------------------
            '@ﾊﾞｯﾌｧ経由で描画
            vsfBat.Redraw = False

            With mtypBatLotList.typBatLot(vsfBatList.Row - 1)

                '@ｶｳﾝﾀｰ初期化
                vsfBat.Row = -1
                lngRowCnt = 1
                
                '@装置タイプ格納
                lstrSelectWPEqType = mtypBatLotList.typBatLot(vsfBatList.Row - 1).strEqType
                
                '@ｸﾞﾘｯﾄﾞ内容の設定
                For llngCnt = 0 To .lngBatLotListCnt - 1

                    '@行数の設定
                    'vsfBat.Rows = lngRowCnt + 1
                
                    With .typBatList(llngCnt)
                    
                        '@表面処理装置でﾛｯﾄIDが前回値と同じか
                        If lstrTmpLotId = .strLotID And _
                           lstrSelectWPEqType = CPstrEqTypeHyoumenSyori Then
                            'WF_IDを「,」区切りで格納
                            lngRowCnt = lngRowCnt - 1
                            vsfBat.SetData(lngRowCnt, CMlngvsfBatWFIDC, _
                            vsfBat.GetData(lngRowCnt, CMlngvsfBatWFIDC) & "," & .strWfId)     'WFID
                            vsfBat.SetData(lngRowCnt, CMlngvsfBatWFNumC, _
                                CLng(vsfBat.GetData(lngRowCnt, CMlngvsfBatWFNumC)) + 1)       'WF枚数(表面処理のｳｪﾊｰ枚数は1ﾚｺｰﾄﾞ1枚で来るので足し算して戻す)
                        Else
                            vsfBat.Rows.Count = lngRowCnt + 1
                            vsfBat.SetData(lngRowCnt, CMlngvsfBatWFIDC, .strWfId)             'WFID
                            vsfBat.SetData(lngRowCnt, CMlngvsfBatWFNumC, .strWFQuantity)      'WF枚数(表面処理のﾙｰﾌﾟ1回目、表面処理装置以外はこちらを通る)
                                                                                                        '      (蒸着装置も1レコード1枚だがこちらでOK)
                        End If
                        
                        '@無機斜方蒸着、無機表面処理 以外か
                        If lstrSelectWPEqType <> CPstrEqTypeJyoucyaku And _
                           lstrSelectWPEqType <> CPstrEqTypeHyoumenSyori Then
                           
                            '@無機斜方蒸着、無機表面処理 以外の場合
                            vsfBat.SetData(lngRowCnt, CMlngvsfBatSeqNumC, .strSeqNum)             '順序
                        Else
                            '@無機斜方蒸着、無機表面処理 の場合
                            vsfBat.SetData(lngRowCnt, CMlngvsfBatSeqNumC, lngRowCnt)              '順序
                        End If
                        
                        vsfBat.SetData(lngRowCnt, CMlngvsfBatCarrierIdC, .strCarrierId)       'ｷｬﾘｱID
                        vsfBat.SetData(lngRowCnt, CMlngvsfBatJigIDC, .strjigId)               '冶具ID
                        vsfBat.SetData(lngRowCnt, CMlngvsfBatLotIdC, .strLotID)               'ﾛｯﾄID
                        vsfBat.SetData(lngRowCnt, CMlngvsfBatLastUpdateC, .strLotLastUpdate)  '最終更新日
                        vsfBat.SetData(lngRowCnt, CMlngvsfBatProductOldNoC, vbNullString)     '製品ﾛｯﾄｸﾞﾘｯﾄﾞの行番号("<"ﾎﾞﾀﾝ用)
                        vsfBat.SetData(lngRowCnt, CMlngvsfBatUldCarrierIDC, .strUldCarrierID) 'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                        vsfBat.SetData(lngRowCnt, CMlngvsfBatUseIDC, UCase(.strUseId))        '製品区分(大文字に変換)
                        vsfBat.SetData(lngRowCnt, CMlngvsfBatPanelKindC, .strCfFlag)          'Cfフラグ(0：TFT、1：CF、9：ﾀﾞﾐｰ冶具 ※9は仕様ではなく、便宜的にSVでｾｯﾄしています。Lpﾌﾗｸﾞも)
                        
                        '@CFﾛｯﾄ
                        If vsfBat.GetData(lngRowCnt, CMlngvsfBatPanelKindC) = CPstrOne Then
                            Dim newStyle As CellStyle = vsfBat.Styles.Add("CustomStyle_BackColor_CPlngCfColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngCfColor)
                            Dim cellRange As CellRange = vsfBat.GetCellRange(lngRowCnt, CMlngvsfBatLotIdC)
                            cellRange.Style = newStyle
                        '@CFﾛｯﾄ以外
                        Else
                            Dim newStyle As CellStyle = vsfBat.Styles.Add("CustomStyle_BackColor_CPlngTftColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngTftColor)
                            Dim cellRange As CellRange = vsfBat.GetCellRange(lngRowCnt, CMlngvsfBatLotIdC)
                            cellRange.Style = newStyle
                        End If
                        
                        vsfBat.SetData(lngRowCnt, CMlngvsfBatLpFlagC, .strLpFlag)             '大板(Lp)ﾌﾗｸﾞ
                        vsfBat.SetData(lngRowCnt, CMlngvsfBatFlowClassC, .strFlowClass)       '種別
                        vsfBat.SetData(lngRowCnt, CMlngvsfBatVaFlagC, .strVaFlag)             '無機ﾌﾗｸﾞ
                        vsfBat.SetData(lngRowCnt, CMlngvsfBatPdIdC, .strPdId)                 '機種
                        vsfBat.SetData(lngRowCnt, CMlngvsfBatJBatchIdC, .strJBatchId)         '蒸着ﾊﾞｯﾁID
                        vsfBat.SetData(lngRowCnt, CMlngvsfBatHBatchIdC, .strHBatchId)         '表面処理ﾊﾞｯﾁID
                        '@無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ
                        '@ｵﾝﾗｲﾝ未
                        If .strInspectFlag <> CPstrFlagOn Then
                            vsfBat.SetData(lngRowCnt, CMlngvsfBatInspectFlagC, CMstrNoOnline)
                            Dim newStyle As CellStyle = vsfBat.Styles.Add("CustomStyle_BackColor_CPlngInspectNg")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngInspectNg)
                            Dim cellRange As CellRange = vsfBat.GetCellRange(lngRowCnt, CMlngvsfBatInspectFlagC)
                            cellRange.Style = newStyle
                        Else
                            vsfBat.SetData(lngRowCnt, CMlngvsfBatInspectFlagC, vbNullString)
                            Dim newStyle As CellStyle = vsfBat.Styles.Add("CustomStyle_BackColor_CPlngEnableTrueColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                            Dim cellRange As CellRange = vsfBat.GetCellRange(lngRowCnt, CMlngvsfBatInspectFlagC)
                            cellRange.Style = newStyle
                        End If
                        
                        '@蒸着処理条件ﾘｽﾄのﾃﾞｰﾀがあるか
                        If mtypVaConditionListAns.lngVaConditionListCnt > 0 Then

                            vsfBat.SetData(lngRowCnt, CMlngvsfBatVaConditionIDC, _
                                mtypVaConditionListAns.typVaConditionList(0).strVaConditionID)                       '蒸着処理条件
                        Else
                            vsfBat.SetData(lngRowCnt, CMlngvsfBatVaConditionIDC, vbNullString)
                        End If

                    End With

                    '@高さ設定
                    vsfBat.Rows(lngRowCnt).Height = CMlngGridRowHeight

                    '@ﾛｯﾄIDを前回値として退避
                    lstrTmpLotId = .typBatList(llngCnt).strLotID
                    '@行ｶｳﾝﾀ+1
                    lngRowCnt = lngRowCnt + 1

                Next llngCnt
                
            End With

            vsfBat.Redraw = True
            'NSYS 選択行が未指定の場合はヘッダ行を選択状態にする
            If vsfBat.Row < 0 Then
                vsfBat.Row = 0
            End If

            '@入力処理区分の設定(06：変更)
            mstrInputClassDivision = CPstrCD06

            '@編集中区分の初期化
            mblnInEditKbn = False       'False：未編集

            '@取消ﾎﾞﾀﾝを無効にする
            cmdClear.Enabled = False


            '@装置ｺﾝﾎﾞの値取得列を「運用ﾓｰﾄﾞ」列に変更
            cmbWpName.ValueCol = CMlngCmbWpNameMesModeID

            '@選択装置の運用ﾓｰﾄﾞが「S2」か
            If cmbWpName.Value = CPstrS2 Then

                '@編集、削除ﾎﾞﾀﾝを無効にする
                cmdEdit.Enabled = False
                cmdDelete.Enabled = False

            '背景が濃いグレー
            ElseIf vsfBatList.GetCellRange(vsfBatList.Row, CMlngvsfBatListNoC).StyleDisplay.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray) Then

                '@編集、削除ﾎﾞﾀﾝを無効にする
                cmdEdit.Enabled = False
                cmdDelete.Enabled = False

            Else
            
                '@編集、削除ﾎﾞﾀﾝの有効/無効を設定
                cmdDelete.Enabled = True

                '@Eq_Typeが蒸着装置の場合編集ﾎﾞﾀﾝは無効
                lngTmpValueCol = cmbWpName.ValueCol
                cmbWpName.ValueCol = CPstrFour
                
                If cmbWpName.Value = CPstrEqTypeJyoucyaku Then
                    cmdEdit.Enabled = False
                Else
                    cmdEdit.Enabled = True
                End If
                
                cmbWpName.ValueCol = lngTmpValueCol
                       
            End If

            '@装置ｺﾝﾎﾞの値取得列を「装置名」列に戻す
            cmbWpName.ValueCol = CMlngCmbWpNameName


            '@装置名ｺﾝﾎﾞを無効にする
            cmbWpName.Enabled = False

            '@各種ｺﾝﾄﾛｰﾙの制御
            vsfBat.Enabled = True       'ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ：有効
            cmdMove.Enabled = False     '">"ﾎﾞﾀﾝ：無効
            cmdRemove.Enabled = False   '"<"ﾎﾞﾀﾝ：無効

            '@編集中ﾌﾗｸﾞが"True：編集中"か
            If mblnInEditKbn = True Then

                '@">"ﾎﾞﾀﾝを有効にする
                cmdMove.Enabled = True
            End If

            '@各種ﾎﾞﾀﾝを無効にする
            cmdUP.Enabled = False                   '"↑"ﾎﾞﾀﾝ
            cmdDown.Enabled = False                 '"↓"ﾎﾞﾀﾝ
            cmdMonitorLotList.Enabled = False       'ﾓﾆﾀ選択
            cmdDummySelect.Enabled = False          'ﾀﾞﾐｰ冶具選択

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfBatList_EnterCell"       'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdEdit_Click
    '機　能：[編集]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 14:57:05 T.Kitagawa
    '更新日：2009/06/04 (Thu) 16:20:35 N.Kojima
    '備　考：
    '　　　：2005/01/12 (Wed) 10:30:34 S.Deguchi    編集ﾎﾞﾀﾝ押下時既に編成一覧が選択されている場合の処理を追加
    '　　　：2009/06/04 (Thu) 16:20:35 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEdit.Click

        Dim lstrSelectWPEqType      As String   '選択装置の装置ﾀｲﾌﾟ

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@各種ﾓｼﾞｭｰﾙ変数の制御
            mstrInputClassDivision = CPstrCD06      '入力処理区分："06：変更"
            mblnInEditKbn = True                    '編集中ﾌﾗｸﾞ："True：編集中"

            '@各種ｺﾝﾄﾛｰﾙの制御
            cmbWpName.Enabled = False               '装置名ｺﾝﾎﾞ：無効
            vsfBat.Enabled = True                   'ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ：有効
            cmdClear.Enabled = True                 '取消ﾎﾞﾀﾝ：有効

            '@起動SBが組立か
            If pstrSBID = CPstrSBID2A0 Then

                '@装置名ｺﾝﾎﾞの値取得列を「装置ﾀｲﾌﾟ(EqType)」列に変更
                cmbWpName.ValueCol = CMlngCmbWpNameEqType

                '@選択装置の装置ﾀｲﾌﾟを格納
                lstrSelectWPEqType = cmbWpName.Value

                '@装置名ｺﾝﾎﾞの値取得列を「装置名」列に戻す
                cmbWpName.ValueCol = CMlngCmbWpNameName

                '@蒸着装置か
                If lstrSelectWPEqType = CPstrEqTypeJyoucyaku Then

                    cmdMonitorLotList.Enabled = False           'ﾓﾆﾀ選択ﾎﾞﾀﾝ：無効
                    cmdDummySelect.Enabled = False              'ﾀﾞﾐｰ冶具選択ﾎﾞﾀﾝ：無効
                Else
                    '@蒸着装置以外の場合

                    cmdMonitorLotList.Enabled = True            'ﾓﾆﾀ選択ﾎﾞﾀﾝ：有効
                    cmdDummySelect.Enabled = False              'ﾀﾞﾐｰ冶具選択ﾎﾞﾀﾝ：無効
                End If
            Else
                '@基板起動の場合

                cmdMonitorLotList.Enabled = True                'ﾓﾆﾀ選択ﾎﾞﾀﾝ：有効
            End If


            With vsfBat

                '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞへﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfBat)

                '@編成済みのﾊﾞｯﾁが表示されているか
                If .Rows.Count > 1 Then

                    '@ﾀｲﾄﾙ選択以外の場合
                    If .Row <> 0 Then

                        '@=======================
                        '@ ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ　ｶﾚﾝﾄ行列変更時処理
                        '@=======================
                        Call vsfBat_EnterCell(sender, e)
                    Else
                        '@1行目を選択
                        vsfBat.Row = 1
                    End If
                End If
            End With

            '@">"ﾎﾞﾀﾝを無効にする
            cmdMove.Enabled = False


            '@-----------------------
            '@ ﾊﾞｯﾁ編成状態ﾁｪｯｸ
            '@-----------------------
            '@①製品ﾛｯﾄが0件か
            If vsfProduct.Row < 1 Then
                Exit Sub
            End If

            '@②既にﾊﾞｯﾁ編成中か
            If vsfProduct.GetCellRange(vsfProduct.Row, mlngvsfLotNoC).StyleDisplay.ForeColor = ColorTranslator.FromWin32(CMlngEnableFalseForeColor) Then
                Exit Sub
            End If

            '@③装置名が未選択か
            If cmbWpName.Text = vbNullString Then
                Exit Sub
            End If

            '@④最大ﾛｯﾄ数が設定されていないか
            If IsNumeric(lblMaxLotCnt.Text) = False Then
                Exit Sub
            End If

            '@⑤ﾊﾞｯﾁ組予定ﾛｯﾄ一覧のﾃﾞｰﾀが最大ﾛｯﾄ数より大きいか
            If vsfBat.Rows.Count - 1 > CLng(lblMaxLotCnt.Text) Then
                Exit Sub
            End If

            '@⑥ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞが無効か
            If vsfBat.Enabled = False Then
                Exit Sub
            End If


            '@〓 製品ﾛｯﾄの使用可能装置により処理分岐 〓
            Select Case vsfProduct.GetData(vsfProduct.Row, cmbWpName.ListIndex + 1)

                '@〓 "△" or "○" or "◎" 〓
                Case CMstrKouho, CMstrJidou, CMstrKakutei

                    '@使用可能

                '@〓 その他(NULL) 〓
                Case Else

                    '@使用不可
                    Exit Sub

            End Select


            '@ﾚｼﾋﾟ未設定か
            If lblRecipeID.Text = vbNullString Then

                '@">"ﾎﾞﾀﾝを有効にする
                cmdMove.Enabled = True
            Else
                '@ﾚｼﾋﾟが同一か
                If vsfProduct.GetData(vsfProduct.Row, mlngvsfLotRecipeIdC) = lblRecipeID.Text Then

                    '@">"ﾎﾞﾀﾝを有効にする
                    cmdMove.Enabled = True
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdEdit_Click"              'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDelete_Click
    '機　能：[削除]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 15:06:38 T.Kitagawa
    '更新日：2009/12/02 (Wed) 19:32:19 N.Kojima
    '備　考：
    '　　　：2005/01/12 (Wed) 11:26:01 S.Deguchi    処理見直し(最新情報取得を削除)
    '　　　：2009/06/04 (Thu) 14:03:55 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/12/02 (Wed) 19:32:19 N.Kojima     案件№03790対応のついでに既存ﾊﾞｸﾞを修正。
    Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDelete.Click

        Dim llngCnt             As Integer      'ｶｳﾝﾀ(汎用)
        Dim llngAns             As Integer      '結果格納
        Dim lstrOldBatchID      As String       '退避用ﾊﾞｯﾁID

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@編集中の場合は内容が初期化されるのでﾒｯｾｰｼﾞBOXを表示する
            If mblnInEditKbn = True Then

                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM0PW>$$バッチ編成中です。 内容を破棄してよろしいですか？"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000P)
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                '@ﾒｯｾｰｼﾞBoxにて"いいえ"が選択されたか
                If llngAns = vbNo Then

                    '@"いいえ"の場合、削除処理ｷｬﾝｾﾙ
                    Exit Sub
                End If

                '@画面初期化＆情報再取得前に、現在選択中のﾊﾞｯﾁIDを退避
                lstrOldBatchID = vsfBatList.GetData(vsfBatList.Row, mlngvsfBatListBatchIdC)

                '@=======================
                '@ ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ内容の初期化
                '@=======================
                Call prvALLInfo_Init()
            
                '@=======================
                '@ ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ内容の表示
                '@=======================
                Call prvALLInfo_Sel()
            
                With vsfBatList
            
                    For llngCnt = 1 To .Rows.Count - 1
            
                        '@退避ﾊﾞｯﾁIDと現在ﾙｰﾌﾟ行のﾊﾞｯﾁIDが同じか
                        If .GetData(llngCnt, mlngvsfBatListBatchIdC) = lstrOldBatchID Then
            
                            '@対象ﾊﾞｯﾁIDの行を選択する
                            .Row = llngCnt
                            .ShowCell(.Row, mlngvsfBatListBatchIdC)
                        End If
                    Next llngCnt
                End With

            End If

            '@入力処理区分の設定(05：削除)
            mstrInputClassDivision = CPstrCD05

            '@=======================
            '@ 確定ﾎﾞﾀﾝ処理
            '@=======================
            Call cmdKakutei_Click(sender, e)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdDelete_Click"            'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
    '作成日：2004/07/23 (Fri) 15:21:56 T.Kitagawa
    '更新日：2009/06/04 (Thu) 14:02:01 N.Kojima
    '備　考：
    '　　　：2009/06/04 (Thu) 14:02:01 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim llngRet         As Integer      'ﾌﾟﾛｸﾞﾗﾑ終了処理結果格納用
        Dim ltypCommonInfo  As CommonInfo   '共用構造体

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@ 共通終了処理
            '@=======================
            llngRet = publngEnd_Proc(CPstrKeyEN00M0, ltypCommonInfo)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdClose_Click"             'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMonitorLotList_Click
    '機　能：[ﾓﾆﾀﾛｯﾄ選択]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/29 (Thu) 11:45:02 T.Kitagawa
    '更新日：2009/07/28 (Tue) 17:18:50 N.Kojima
    '備　考：
    '　　　：2009/06/04 (Thu) 16:27:08 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/28 (Tue) 17:18:50 N.Kojima     無機対応Phase2、ﾓﾆﾀﾛｯﾄ選択ﾎﾞﾀﾝからﾓﾆﾀﾛｯﾄが選択された場合の処理追加。(案件№03661)
    Private Sub cmdMonitorLotList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMonitorLotList.Click

        Dim lstrSelectWPEqType          As String       '選択装置の装置ﾀｲﾌﾟ
        Dim llngCnt                     As Integer      '汎用ｶｳﾝﾀ
        Dim llngCnt2                    As Integer      '汎用ｶｳﾝﾀ
        Dim llngRow                     As Integer      'NSYS ROW位置退避

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS .Row退避,EnterCell回避
            llngRow = vsfBat.Row
            RemoveHandler vsfBat.EnterCell,AddressOf vsfBat_EnterCell

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            pblnFormLoad = False

            '@起動区分に"1：ﾓﾆﾀ選択での起動"をｾｯﾄ
            pstrfrmxxEN00M1Kbn = CPstrOne

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ ﾓﾆﾀﾛｯﾄ一覧画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxEN00M1.Instance = New frmxxEN00M1()

            '@子画面起動処理失敗か
            If pblnFormLoad = False Then

                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxEN00M1.Instance = Nothing

                Exit Sub
            End If

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ ﾓﾆﾀﾛｯﾄ一覧画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxEN00M1.Instance.ShowDialog(Me)
            frmxxEN00M1.Instance = Nothing

            '@起動区分の初期化
            pstrfrmxxEN00M1Kbn = vbNullString

            'NSYS .Row戻し,EnterCell追加
            vsfBat.Row = llngRow
            AddHandler vsfBat.EnterCell,AddressOf vsfBat_EnterCell

            '@装置名ｺﾝﾎﾞの値取得列を「装置ﾀｲﾌﾟ(EqType)」列に変更
            cmbWpName.ValueCol = CMlngCmbWpNameEqType

            '@選択装置の装置ﾀｲﾌﾟを格納
            lstrSelectWPEqType = cmbWpName.Value

            '@装置名ｺﾝﾎﾞの値取得列を「装置名」列に戻す
            cmbWpName.ValueCol = CMlngCmbWpNameName


            '@★ 選択装置の装置ﾀｲﾌﾟにより処理分岐 ★
            Select Case lstrSelectWPEqType

                '@〓 19：斜方蒸着装置 〓
                Case CPstrEqTypeJyoucyaku

                    '@処理なし


                '@〓 20：表面処理装置 〓
                Case CPstrEqTypeHyoumenSyori

                    '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧にﾃﾞｰﾀがあるか
                    If vsfBat.Rows.Count > 1 Then

                        '@各種ﾎﾞﾀﾝを有効にする
                        cmdKakutei.Enabled = True       '確定
                        cmdClear.Enabled = True         '取消

                        '@編集中ﾌﾗｸﾞに"True：編集中"をｾｯﾄ
                        mblnInEditKbn = True
                    End If


                '@〓 その他 〓
                Case Else

                    '@ﾓﾆﾀﾛｯﾄ指定後は確定可能
                    With vsfBat

                        '@ﾊﾞｯﾁ組予定ﾛｯﾄにﾃﾞｰﾀがあるか
                        If .Rows.Count > 1 Then

                            '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧の先頭がﾓﾆﾀｰﾛｯﾄか(基板ではﾓﾆﾀｰﾛｯﾄの順は必ず"0")
                            If vsfBat.GetData(1, CMlngvsfBatSeqNumC) = 0 Then

                                '@各種ﾎﾞﾀﾝを有効にする
                                cmdKakutei.Enabled = True       '確定
                                cmdClear.Enabled = True         '取消

                                '@編集中ﾌﾗｸﾞに"True：編集中"をｾｯﾄ
                                mblnInEditKbn = True
                            End If
                        End If
                    End With

            End Select


            '@-----------------------
            '@ 製品ﾛｯﾄ一覧の文字色制御
            '@-----------------------
            '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧から同一ﾛｯﾄを検索
            For llngCnt = 1 To vsfProduct.Rows.Count - 1

                For llngCnt2 = 1 To vsfBat.Rows.Count - 1

                    '@表示ﾛｯﾄとﾊﾞｯﾁ組予定ﾛｯﾄが同じか
                    If vsfProduct.GetData(llngCnt, mlngvsfLotLotIdC) = _
                        vsfBat.GetData(llngCnt2, CMlngvsfBatLotIdC) Then

                        '@製品一覧ｸﾞﾘｯﾄﾞの該当行ForeColerを灰色に変更する
                        Dim newStyle As CellStyle
                        Dim cellRange As CellRange
                        Dim llngCnt3 As Integer
                        For llngCnt3 = mlngvsfLotNoC To mlngvsfLotLastUpdateC
                            newStyle = vsfProduct.Styles.Add("CustomStyle_ForeColor_CMlngEnableFalseForeColor_I" + llngCnt.ToString + llngCnt3.ToString)
                            newStyle.ForeColor = ColorTranslator.FromWin32(CMlngEnableFalseForeColor)
                            newStyle.BackColor = vsfProduct.GetCellRange(llngCnt, llngCnt3).StyleDisplay.BackColor
                            cellRange = vsfProduct.GetCellRange(llngCnt, llngCnt3)
                            cellRange.Style = newStyle
                        Next
                        Exit For
                    End If
                Next llngCnt2
            Next llngCnt

            '@=======================
            '@ 製品ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ　ｶﾚﾝﾄ行列変更時処理
            '@=======================
            Call vsfProduct_EnterCell(sender, e)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdMonitorLotList_Click"    'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDummySelect_Click
    '機　能：[ﾀﾞﾐｰ冶具選択]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/06/05 (Fri) 10:37:00 N.Kojima
    '更新日：2016/07/04 (Mon) 15:46:17 T.Oide
    '備　考：
    Private Sub cmdDummySelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDummySelect.Click

        Dim llngCnt                 As Integer      '汎用ｶｳﾝﾀ
        Dim lstrSelectWPEqType      As String       '選択装置の装置ﾀｲﾌﾟ

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合、処理抜け
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@装置名ｺﾝﾎﾞの値取得列を「装置ﾀｲﾌﾟ(EqType)」列に変更
            cmbWpName.ValueCol = CMlngCmbWpNameEqType

            '@選択装置の装置ﾀｲﾌﾟを格納
            lstrSelectWPEqType = cmbWpName.Value

            '@装置名ｺﾝﾎﾞの値取得列を「装置名」列に戻す
            cmbWpName.ValueCol = CMlngCmbWpNameName

            '@各種Pubilc変数の初期化
            pblnFormLoad = False            'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ
            pblnfrmxxEN02D0kbn = False      'ﾌｫｰﾑ起動区分


            '@装置ﾀｲﾌﾟが"19：斜方蒸着装置"か
            If lstrSelectWPEqType = CPstrEqTypeJyoucyaku Then

                '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧の選択行がﾃﾞｰﾀ行以外の場合、処理抜け
                If vsfBat.Row < 1 Then
                    Exit Sub
                End If

                '@各種Pubilc変数の初期化＆設定
                pstrJigID = vbNullString            '冶具ID引継ぎ用 ：初期化
                pblnfrmxxCM0130Kbn = True           'ﾌｫｰﾑ起動区分   ：True(子画面起動)
				'↓J_JIG_CATEGORYを使用するため空にする
				pstrJigTypeID = vbNullString		'冶具ﾀｲﾌﾟ       ：JD(ﾀﾞﾐｰ冶具)
                pstrJigStatus = CPstrZero           '冶具状態       ：0(使用可)
				pstrJJigCategoryID = CMstrJJigCategoryDummy　'蒸着治具カテゴリ　：D(ダミープレート)

                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@ 空き冶具選択画面　起動処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM0130.Instance = New frmxxCM0130()

                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False：起動失敗"か
                If pblnFormLoad = False Then

                    '@∇∇∇∇∇∇∇∇∇∇∇
                    '@ ｱﾝﾛｰﾄﾞ処理
                    '@∇∇∇∇∇∇∇∇∇∇∇
                    frmxxCM0130.Instance = Nothing

                    Exit Sub
                End If

                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@ 空き冶具選択画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM0130.Instance.ShowDialog(Me)
                frmxxCM0130.Instance = Nothing

                '@ﾀﾞﾐｰ冶具が選択されたか
                If pstrJigID <> vbNullString Then

                    '@選択されたﾀﾞﾐｰ冶具をﾊﾞｯﾁ組予定ﾛｯﾄ一覧に反映、製品ﾛｯﾄｸﾞﾘｯﾄﾞの行番号・製品区分列にはNULLを格納
                    vsfBat.SetData(vsfBat.Row, CMlngvsfBatJigIDC, pstrJigID)              '冶具ID
                    vsfBat.SetData(vsfBat.Row, CMlngvsfBatWFIDC, CMstrDummy)              'WFID
                    vsfBat.SetData(vsfBat.Row, CMlngvsfBatProductOldNoC, vbNullString)    '製品ﾛｯﾄ一覧の行番号
                    vsfBat.SetData(vsfBat.Row, CMlngvsfBatWFNumC, CPstrOne)               'WF枚数
                    vsfBat.SetData(vsfBat.Row, CMlngvsfBatUseIDC, vbNullString)           '製品区分
                    vsfBat.SetData(vsfBat.Row, CMlngvsfBatLpFlagC, vbNullString)          '大板(Lp)ﾌﾗｸﾞ
                    vsfBat.SetData(vsfBat.Row, CMlngvsfBatFlowClassC, vbNullString)       '種別
                    vsfBat.SetData(vsfBat.Row, CMlngvsfBatVaFlagC, vbNullString)          '無機ﾌﾗｸﾞ
                    vsfBat.SetData(vsfBat.Row, CMlngvsfBatPdIdC, vbNullString)            '機種
                    vsfBat.SetData(vsfBat.Row, CMlngvsfBatJBatchIdC, vbNullString)        '蒸着ﾊﾞｯﾁID
                    vsfBat.SetData(vsfBat.Row, CMlngvsfBatHBatchIdC, vbNullString)        '表面処理ﾊﾞｯﾁID
                    vsfBat.SetData(vsfBat.Row, CMlngvsfBatInspectFlagC, vbNullString)     '無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ

                    '@=======================
                    '@ ﾊﾞｯﾁ組WF枚数再計算処理
                    '@=======================
                    Call prvBatLotWFCnt_Cal()

                    '@ﾀﾞﾐｰ冶具が選択されたか
                    If pstrJigID <> vbNullString Then

                        '@ﾀﾞﾐｰ冶具選択ﾎﾞﾀﾝを無効にする
                        cmdDummySelect.Enabled = False
                    End If

                    '@使用ﾊﾟﾌﾞﾘｯｸ変数の初期化
                    pstrJigID = vbNullString            '冶具ID
                    pstrJigTypeID = vbNullString      '冶具ﾀｲﾌﾟ
                    pstrJigStatus = CPstrZero           '冶具状態
					pstrJJigCategoryID = vbNullString	'蒸着治具カテゴリ

                    '@各種ﾎﾞﾀﾝを有効にする
                    cmdRemove.Enabled = True            '"<"
                    cmdDummySelect.Enabled = True       'ﾀﾞﾐｰ冶具選択

                    '@確定ﾎﾞﾀﾝ制御
                    For llngCnt = 1 To vsfBat.Rows.Count - 1

                        '@製品ﾛｯﾄが1ﾛｯﾄ以上存在するか
                        If vsfBat.GetData(llngCnt, CMlngvsfBatLotIdC) <> vbNullString Then

                            '@確定ﾎﾞﾀﾝを有効にする
                            cmdKakutei.Enabled = True
                        End If
                    Next llngCnt
                End If

                '@ﾌｫｰﾑ起動区分の初期化
                pblnfrmxxCM0130Kbn = False

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdDummySelect_Click"       'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClear_Click
    '機　能：[取消]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/30 (Fri) 15:48:29 T.Kitagawa
    '更新日：2009/06/04 (Thu) 14:07:22 N.Kojima
    '備　考：
    '　　　：2009/06/04 (Thu) 14:07:22 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClear.Click

        Try

            '@=======================
            '@ 最新取得ﾎﾞﾀﾝ処理
            '@=======================
            Call cmdLotList_Click(sender, e)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdClear_Click"             'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdKakutei_Click
    '機　能：[確定]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/29 (Thu) 15:27:18 T.Kitagawa
    '更新日：2012/03/27 (Tue) 15:16:19 T.Oide
    '備　考：
    '　　　：2004/10/21 (Thu) 09:21:30 N.Kojima　   空ﾀｸﾞ挿入処理削除に伴い、0件ﾁｪｯｸ処理追加。
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2005/07/13 (Wed) 12:06:49 S.Deguchi    ﾊﾞｯﾁ自動搬送対応の修正
    '　　　：2009/06/04 (Thu) 14:08:03 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/11/26 (Thu) 08:51:13 N.Kojima     送信ﾃﾞｰﾀに蒸着処理条件制限ﾌﾗｸﾞを追加。(案件№03790)
    '　　　：2012/03/27 (Tue) 15:16:19 T.Oide       無機装置追加対応(REQ-1303)
    Private Sub cmdKakutei_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdKakutei.Click

        Dim lblnInputCheck          As Boolean              '画面入力ﾁｪｯｸ(True:正常,False:異常)
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypBatChange           As BatChange            'ﾊﾞｯﾁ組ﾛｯﾄ登録変更構造体
        Dim llngCnt                 As Integer              'ｶｳﾝﾀ(汎用)
        Dim llngNoUseCnt            As Integer              '未使用処理部ｶｳﾝﾀ
        Dim lstrAnsBatchID          As String               '確定後のﾊﾞｯﾁID
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance        As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrWFID                As Object               'WF_IDを格納
        Dim llngWFcnt               As Integer              'WF枚数格納
        Dim llngCnt2                As Integer              '汎用ｶｳﾝﾀ
        Dim lstrWpId                As String
        Dim lstrEqType              As String

        Try

            '@=======================
            '@ 確定時ﾁｪｯｸ処理
            '@=======================
            lblnInputCheck = prvblnInput_Chk

            '@"False：不正項目あり"か
            If lblnInputCheck = False Then

                '@確定処理ｷｬﾝｾﾙ
                Exit Sub
            End If

            'WPID/EQ_TYPE取得
            cmbWpName.ValueCol = CMlngCmbWpNameId
            lstrWpId = cmbWpName.Value                 
            cmbWpName.ValueCol = CMlngCmbWpNameEqType
            lstrEqType = cmbWpName.Value   
            '@装置名ｺﾝﾎﾞの値取得列を「装置名」列に戻す
            cmbWpName.ValueCol = CMlngCmbGridColName

            '表面処理
            'バッチ編成新規(mstrInputClassDivision:NULL)
            If lstrEqType = CPstrEqTypeHyoumenSyori And mstrInputClassDivision = vbNullString Then
                If prvblnHyoumenSyoriChek = False Then
                    Exit Sub
                End If
            End If

            '斜方蒸着
            'バッチ編成新規(mstrInputClassDivision:NULL)
            If lstrEqType = CPstrEqTypeJyoucyaku And mstrInputClassDivision = vbNullString Then
                If prvblnJyoucyakuChek = False Then
                    Exit Sub
                End If
            End If

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 作業者ｺｰﾄﾞ入力画面　表示
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@作業者ｺｰﾄﾞ入力がｷｬﾝｾﾙされたか
            If pblnCancel = True Then

                '@確定処理ｷｬﾝｾﾙ
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdKakuteiClick)


            '@***********************
            '@ 登録ﾃﾞｰﾀ設定
            '@***********************
            With ltypBatChange

                '@未使用処理部ｶｳﾝﾀの初期化
                llngNoUseCnt = 1

                .strBatchId = lblBatchID.Text            'ﾊﾞｯﾁID
                .lngBatChangeLotListCnt = 0                 '登録ﾛｯﾄｶｳﾝﾄの初期化



        '@↓2012/03/08 (Thu) 15:50:18 T.Oide **************************************************
        '@        For llngCnt = 1 To vsfBat.Rows - 1
        '@
        '@            '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧の"順"が数値か
        '@            If IsNumeric(vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatSeqNumC)) = True Then
        '@
        '@                '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧の件数をｶｳﾝﾄｱｯﾌﾟ
        '@                .lngBatChangeLotListCnt = .lngBatChangeLotListCnt + 1
        '@
        '@                '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ﾘｽﾄ構造体の格納
        '@                ReDim Preserve .typBatChangeLotList(.lngBatChangeLotListCnt)
        '@
        '@                With .typBatChangeLotList(.lngBatChangeLotListCnt)
        '@
        '@                    .strSeqNum = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatSeqNumC)               '順序
        '@                    .strCarrierId = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatCarrierIdC)         'ｷｬﾘｱID
        '@                    .strjigId = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatJigIDC)                 '冶具ID
        '@                    .strLotId = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatLotIdC)                 'ﾛｯﾄID
        '@                    .strLotLastUpdate = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatLastUpdateC)    '最終更新日
        '@                    .strUldCarrierID = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatUldCarrierIDC)   'ｱﾝﾛｰﾀﾞｷｬﾘｱID
        '@                    .strWfID = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatWFIDC)                   'WFID
        '@                    .strPanelKind = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatPanelKindC)         'Cfﾌﾗｸﾞ
        '@                    .strVaConditionID = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatVaConditionIDC) '蒸着処理条件
        '@
        '@                    '@ﾛｯﾄID・冶具・WFIDがNULL、または未使用か
        '@                    If (.strLotId = vbNullString And _
        '@                        .strjigId = vbNullString And _
        '@                        .strWfID = vbNullString) Or _
        '@                        (.strLotId = vbNullString And _
        '@                        InStr(1, .strjigId, CMstrNotUse) <> 0 And _
        '@                        InStr(1, .strWfID, CMstrNotUse) <> 0) Then
        '@
        '@                        '@DBがNOT NULL設定の為、"未使用N"をｾｯﾄ
        '@                        .strjigId = CMstrNotUse & CStr(llngNoUseCnt)                    '冶具ID
        '@                        .strWfID = CMstrNotUse & CStr(llngNoUseCnt)                     'WFID
        '@                        ltypBatChange.strRecipeId = CMstrNotUse                         'ﾚｼﾋﾟID
        '@
        '@                        '@未使用ｶｳﾝﾀを+1する
        '@                        llngNoUseCnt = llngNoUseCnt + 1
        '@                    End If
        '@                End With
        '@            End If
        '@        Next llngCnt


                .strWpID = lstrWpId                     '装置ID
                .strEqType = lstrEqType                 '装置ﾀｲﾌﾟ
                .strEmpID = pstrUserID                  '作業者ID
                .strRecipeId = lblRecipeID.Text         'ﾚｼﾋﾟID
                        
                For llngCnt = 1 To vsfBat.Rows.Count - 1

                    '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧の"順"が数値か
                    If IsNumeric(vsfBat.GetData(llngCnt, CMlngvsfBatSeqNumC)) = True Then

        '@↓2012/03/27 (Tue) 15:16:19 T.Oide **************************************************
        '@                '@ｸﾞﾘｯﾄﾞ1行のWF枚数格納
        '@                 llngWFcnt = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatWFNumC)
        '@---------------------------------------------------------------------------------------------
                        '@ｸﾞﾘｯﾄﾞ1行のWF枚数格納
                        If vsfBat.GetData(llngCnt, CMlngvsfBatWFNumC) = vbNullString Then
                            llngWFcnt = 0                                                           '未使用の場合を考慮
                        Else
                            llngWFcnt = vsfBat.GetData(llngCnt, CMlngvsfBatWFNumC)
                        End If
        '@↑2012/03/27 (Tue) 15:16:19 T.Oide **************************************************
                        
                        
                        '@表面処理装置でWF枚数が1枚より多い場合は、WF枚数分ﾃﾞｰﾀを作成
                        '@メモ：表面処理装置のみｸﾞﾘｯﾄﾞに表示しているﾚｺｰﾄﾞxWF枚数分ﾃﾞｰﾀを作成してﾒｯｾｰｼﾞを送信する
                        If .strEqType = CPstrEqTypeHyoumenSyori And _
                           llngWFcnt > 1 Then
                           
                            '@***********************
                            '@表面処理装置で1ﾚｺｰﾄﾞにWFが複数枚ある場合(xxxx#01,xxxx#02...と格納されている場合)
                            '@***********************
                            
                            '@WF_IDを配列に格納
                            lstrWFID = Split(vsfBat.GetData(llngCnt, CMlngvsfBatWFIDC), CPstrComma)
                            
                            For llngCnt2 = 0 To UBound(lstrWFID)
                                '@ﾃﾞｰﾀ作成
                                
                                '@ﾃﾞｰﾀｾｯﾄ関数で値をｾｯﾄ
                                Call prvsubDataSet(ltypBatChange, lstrWFID(llngCnt2), llngCnt, llngNoUseCnt)
                                
                                
        '@                        '--------------------------------------------------------------------------
        '@
        '@                        '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧の件数をｶｳﾝﾄｱｯﾌﾟ
        '@                        .lngBatChangeLotListCnt = .lngBatChangeLotListCnt + 1
        '@
        '@                        '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ﾘｽﾄ構造体の格納
        '@                        ReDim Preserve .typBatChangeLotList(.lngBatChangeLotListCnt)
        '@
        '@                        With .typBatChangeLotList(.lngBatChangeLotListCnt)
        '@
        '@                            .strSeqNum = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatSeqNumC)               '順序
        '@                            .strCarrierId = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatCarrierIdC)         'ｷｬﾘｱID
        '@                            .strjigId = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatJigIDC)                 '冶具ID
        '@                            .strLotId = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatLotIdC)                 'ﾛｯﾄID
        '@                            .strLotLastUpdate = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatLastUpdateC)    '最終更新日
        '@                            .strUldCarrierID = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatUldCarrierIDC)   'ｱﾝﾛｰﾀﾞｷｬﾘｱID
        '@                            .strWfID = lstrWfId(llngCnt2)                                                   'WFID
        '@                            .strPanelKind = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatPanelKindC)         'Cfﾌﾗｸﾞ
        '@                            .strVaConditionID = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatVaConditionIDC) '蒸着処理条件
        '@
        '@                            '@ﾛｯﾄID・冶具・WFIDがNULL、または未使用か
        '@                            If (.strLotId = vbNullString And _
        '@                                .strjigId = vbNullString And _
        '@                                .strWfID = vbNullString) Or _
        '@                                (.strLotId = vbNullString And _
        '@                                InStr(1, .strjigId, CMstrNotUse) <> 0 And _
        '@                                InStr(1, .strWfID, CMstrNotUse) <> 0) Then
        '@
        '@                                '@DBがNOT NULL設定の為、"未使用N"をｾｯﾄ
        '@                                .strjigId = CMstrNotUse & CStr(llngNoUseCnt)                    '冶具ID
        '@                                .strWfID = CMstrNotUse & CStr(llngNoUseCnt)                     'WFID
        '@                                ltypBatChange.strRecipeId = CMstrNotUse                         'ﾚｼﾋﾟID
        '@
        '@                                '@未使用ｶｳﾝﾀを+1する
        '@                                llngNoUseCnt = llngNoUseCnt + 1
        '@                            End If
        '@                        End With
        '@                        '--------------------------------------------------------------------------
                                
                            Next llngCnt2
                            
                        Else
                            '@***********************
                            '@表面処理装置以外
                            '@***********************
                            
                             '@ﾃﾞｰﾀｾｯﾄ関数で値をｾｯﾄ
                             Call prvsubDataSet(ltypBatChange, vbNullString, llngCnt, llngNoUseCnt)
                            
        '@
        '@                    '--------------------------------------------------------------------------
        '@
        '@                    '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧の件数をｶｳﾝﾄｱｯﾌﾟ
        '@                    .lngBatChangeLotListCnt = .lngBatChangeLotListCnt + 1
        '@
        '@                    '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ﾘｽﾄ構造体の格納
        '@                    ReDim Preserve .typBatChangeLotList(.lngBatChangeLotListCnt)
        '@
        '@                    With .typBatChangeLotList(.lngBatChangeLotListCnt)
        '@
        '@                        .strSeqNum = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatSeqNumC)               '順序
        '@                        .strCarrierId = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatCarrierIdC)         'ｷｬﾘｱID
        '@                        .strjigId = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatJigIDC)                 '冶具ID
        '@                        .strLotId = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatLotIdC)                 'ﾛｯﾄID
        '@                        .strLotLastUpdate = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatLastUpdateC)    '最終更新日
        '@                        .strUldCarrierID = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatUldCarrierIDC)   'ｱﾝﾛｰﾀﾞｷｬﾘｱID
        '@                        .strWfID = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatWFIDC)                   'WFID
        '@                        .strPanelKind = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatPanelKindC)         'Cfﾌﾗｸﾞ
        '@                        .strVaConditionID = vsfBat.Cell(flexcpText, llngCnt, CMlngvsfBatVaConditionIDC) '蒸着処理条件
        '@
        '@                        '@ﾛｯﾄID・冶具・WFIDがNULL、または未使用か
        '@                        If (.strLotId = vbNullString And _
        '@                            .strjigId = vbNullString And _
        '@                            .strWfID = vbNullString) Or _
        '@                            (.strLotId = vbNullString And _
        '@                            InStr(1, .strjigId, CMstrNotUse) <> 0 And _
        '@                            InStr(1, .strWfID, CMstrNotUse) <> 0) Then
        '@
        '@                            '@DBがNOT NULL設定の為、"未使用N"をｾｯﾄ
        '@                            .strjigId = CMstrNotUse & CStr(llngNoUseCnt)                    '冶具ID
        '@                            .strWfID = CMstrNotUse & CStr(llngNoUseCnt)                     'WFID
        '@                            ltypBatChange.strRecipeId = CMstrNotUse                         'ﾚｼﾋﾟID
        '@
        '@                            '@未使用ｶｳﾝﾀを+1する
        '@                            llngNoUseCnt = llngNoUseCnt + 1
        '@                        End If
        '@                    End With
        '@                    '--------------------------------------------------------------------------
                        
                        End If
                        
                    End If
                Next llngCnt
        '@↑2012/03/08 (Thu) 15:50:18 T.Oide **************************************************

            End With

            '@ﾊﾞｯﾁ編成ﾘｽﾄの件数が0件か
            If ltypBatChange.lngBatChangeLotListCnt <= 0 Then

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdKakuteiClick)

                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM3PW>$$バッチロット情報が設定されていません。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003P)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                Exit Sub
            End If


            '@=======================
            '@ 【ﾊﾞｯﾁ組ﾛｯﾄ登録変更】ﾒｯｾｰｼﾞ送受信処理(処理区分：処理による)
            '@=======================
            lblnAns = pubblnBatChange_Upd(CMstrbat_change__Ver, _
                                          pstrSBID, _
                                          mstrInputClassDivision, _
                                          ltypBatChange, _
                                          lstrAnsBatchID, _
                                          lstrGuidMsg, _
                                          lstrGuidMsgCode)

            '@通信結果の判定
            If lblnAns = True Then
                '@通信成功の場合

                '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞに値が入っている場合
                If lstrGuidMsgCode <> vbNullString Then

                    '@表示ｶﾞｲﾀﾞﾝｽMsgの編集("【警告】" & "$$" & "ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ[CODE]">" & "$$" & ｶﾞｲﾀﾞﾝｽMsg)
                    lstrEditGuidance = CPstrWarMsgCode & CPstrGuidanceMsg & CPstrMsgCrCode & _
                                       CPstrGuidanceCode & CPstrBracketLeft & lstrGuidMsgCode & CPstrBracketRight & _
                                       CPstrMsgCrCode & lstrGuidMsg

                    '@表示ﾒｯｾｰｼﾞ変換＆ﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(lstrEditGuidance)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                End If

                '@★ 入力処理区分により処理分岐 ★
                '@　⇒"<TRM0PI>$$バッチ編成を%1しました。バッチ[%2]"の「%1」に入れる文言の設定
                Select Case mstrInputClassDivision

                    '@〓 NULL：新規 〓
                    Case vbNullString

                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000P, CMstrMsgNew, lstrAnsBatchID)

                    '@〓 06：変更 〓
                    Case CPstrCD06

                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000P, CMstrMsgEdit, lstrAnsBatchID)

                    '@〓 05：削除 〓
                    Case CPstrCD05

                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000P, CMstrMsgDelete, lstrAnsBatchID)

                End Select
                '@"<TRM0PI>$$バッチ編成を%1しました。バッチ[%2]"のﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)


                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdKakuteiClick)

                '@=======================
                '@ ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ内容の初期化
                '@=======================
                Call prvALLInfo_Init()

                '@=======================
                '@ ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ内容の表示
                '@=======================
                Call prvALLInfo_Sel()


                '@★ 入力処理区分により処理分岐 ★
                Select Case mstrInputClassDivision

                    '@〓 NULL：新規 or 06：変更 〓
                    Case vbNullString, CPstrCD06

                        '@ﾊﾞｯﾁ編成へ登録内容を表示させる為、ﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞへ登録行へﾌｫｰｶｽを設定する
                        With vsfBatList

                            For llngCnt = 1 To .Rows.Count - 1

                                '@ｸﾞﾘｯﾄﾞのﾊﾞｯﾁIDと登録ﾊﾞｯﾁIDが同じか
                                If .GetData(llngCnt, mlngvsfBatListBatchIdC) = lstrAnsBatchID Then

                                    '@同じ行にﾌｫｰｶｽｾｯﾄ
                                    .Row = llngCnt
                                    .ShowCell(llngCnt, mlngvsfBatListBatchIdC)

                                    Exit For
                                End If
                            Next llngCnt
                        End With

                    '@〓 05：削除 〓
                    Case CPstrCD05

                        '@製品ﾛｯﾄｸﾞﾘｯﾄﾞが有効ならﾌｫｰｶｽｾｯﾄ
                        If vsfProduct.Enabled = True Then
                            Call pubSetFocus(vsfProduct)
                        End If

                End Select
            Else
                '@通信失敗の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdKakuteiClick)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdKakutei_Click"           'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
    '更新日：2019/05/16 (Thu) 11:01:36 Y.Yoneyama
    '備　考：
    '　　　：2019/05/16 (Thu) 11:01:36 Y.Yoneyama   装置別ﾛｯﾄ一覧からの移植
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
            If Cursor.Current = Cursors.WaitCursor Then

                Exit Sub
            End If

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化(True：起動成功、False：起動中(起動失敗)・初期値)
            pblnFormLoad = False

            '@ﾌｫｰﾑ起動区分に"1：TFT/CFﾛｯﾄ紐付き情報起動"をｾｯﾄ
            plngfrmxxCM01B0Kbn = CPlngNumOne
            
            '@***********************
            '@ 引継ぎ情報作成
            '@***********************
            With vsfProduct
                ptypCommonInfo.strCarrierId = .GetData(.Row, mlngvsfLotCarrierIdC)     'ｷｬﾘｱID
                ptypCommonInfo.strLotID = .GetData(.Row, mlngvsfLotLotIdC)             'ﾛｯﾄID
                ptypCommonInfo.strFlowClass = .GetData(.Row, mlngvsfLotFlowClassC)     '流動区分
                ptypCommonInfo.strPdId = .GetData(.Row, mlngvsfLotPdIdC)               '機種
                ptypCommonInfo.strNowST = vbNullString                                 'ﾛｯﾄ状態
                ptypCommonInfo.strWfNum = .GetData(.Row, mlngvsfLotWfNumC)             'WF枚数
                ptypCommonInfo.strChipQuantity = vbNullString                          'ﾁｯﾌﾟ数
                ptypCommonInfo.strOpID = .GetData(.Row, mlngvsfLotOpIdC)               '大工程
                ptypCommonInfo.strStepID = .GetData(.Row, mlngvsfLotStepIdC)           '小工程
                ptypCommonInfo.strCfFlag = .GetData(.Row, mlngvsfLotLotKindC)          'CFﾌﾗｸﾞ
                ptypCommonInfo.strBatchId = .GetData(.Row, mlngvsfLotJBatchIdC)        '蒸着ﾊﾞｯﾁID
                pstrVaFlag = .GetData(.Row, mlngvsfLotVaFlagC)                         '無機ﾌﾗｸﾞ
                pstrTpalClass = vbNullString                                           'TPAL設定
            End With

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ TFT/CFﾛｯﾄ紐付き情報画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM01B0.Instance = New frmxxCM01B0()

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False：起動処理失敗"か
            If pblnFormLoad = False Then

                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM01B0.Instance = Nothing

                '@各種ﾎﾞﾀﾝ制御ﾌﾗｸﾞに"True：有効化"をｾｯﾄ
                'mblnCmdFlag = True

                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
                pblnFormLoad = True

                Exit Sub
            End If

            '@閉じるﾎﾞﾀﾝを無効にする(閉じる連打で落ちるのを回避)
            cmdClose.Enabled = False

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ TFT/CFﾛｯﾄ紐付き情報画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM01B0.Instance.ShowDialog(Me)
            frmxxCM01B0.Instance = Nothing

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            pblnFormLoad = True

            '@各種ﾎﾞﾀﾝ制御ﾌﾗｸﾞに"True：有効化"をｾｯﾄ
            'mblnCmdFlag = True

            '@装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞにﾃﾞｰﾀがあるか
            If vsfProduct.Rows.Count > 1 Then

                With ptypOnErrorInfo

                    '@ｴﾗｰ発生箇所の設定
                    .strErrPositionDetail = CMstrArrowCmdLotConnectedInfoDispClick

                    '@=======================
                    '@ 最新取得ﾎﾞﾀﾝ処理
                    '@=======================
                    Call cmdLotList_Click(sender, e)

                    '@ｴﾗｰ発生箇所の初期化
                    .strErrPositionDetail = vbNullString

                End With
            End If

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
            plngfrmxxCM01B0Kbn = CPlngNumZero

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

    '関数名：cmdVsfProductDisp_Click
    '機　能：vsfProductの表示切替
    '引　数：なし
    '戻り値：なし
    '作成日：2019/05/30 (Thu) 16:01:09 Y.Yoneyama
    '更新日：2019/05/30 (Thu) 16:01:09 Y.Yoneyama
    '備　考：
    Private Sub cmdVsfProductDisp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdVsfProductDisp.Click
        
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

            '@表示ﾌﾗｸﾞ反転
            mblnWpDetailDisp = Not mblnWpDetailDisp
            
            '@***********************
            '@ 表示/非表示切替
            '@***********************
            Call chgWpDetailDisp(mblnWpDetailDisp)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "cmdVsfProductDisp_Click"        '処理名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
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

    '関数名：prvFrmxxEN00M0_Init
    '機　能：ﾌｫｰﾑ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/26 (Mon) 14:20:12 T.Kitagawa
    '更新日：2009/11/18 (Wed) 10:01:44 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 13:23:22 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2005/01/12 (Wed) 10:13:48 S.Deguchi    CausesValidation設定をForm_Loadから移動
    '　　　：2009/06/04 (Thu) 13:23:57 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/08/06 (Thu) 09:33:47 N.Kojima     無機対応Phase3、表面処理装置ﾊﾞｯﾁ組仕様説明ﾗﾍﾞﾙの制御追加。(案件№03704)
    '　　　：2009/11/18 (Wed) 10:01:44 N.Kojima     組立起動の場合のみ[有効/無効]ﾗﾍﾞﾙを表示するように処理追加。(案件№03790)
    Private Sub prvFrmxxEN00M0_Init()

        Dim lstrFormTitle               As String               'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        Dim ltypMcGpLotInfo             As McGpLotInfo          '装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄ構造体

        Try

            '@=======================
            '@ ﾒﾆｭｰ関連付け処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00M0, lstrFormTitle)

            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle

            '@=======================
            '@ ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ内容の初期化
            '@=======================
            Call prvALLInfo_Init()

            '@=======================
            '@ ｺﾝﾎﾞﾎﾞｯｸｽ初期化処理
            '@=======================
            Call prvComboBox_Init()

            '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞを無効にする
            vsfBat.Enabled = False


            '@-----------------------
            '@ 画面ｺﾝﾄﾛｰﾙ表示/非表示制御
            '@-----------------------
            If pstrSBID = CPstrSBID1A0 Then
                '@1A0：基板起動の場合

                '@各種ｺﾝﾄﾛｰﾙを非表示にする
                cmdUP.Visible = False                       '"↑"ﾎﾞﾀﾝ
                cmdDown.Visible = False                     '"↓"ﾎﾞﾀﾝ
                cmdCarrierSelect.Visible = False            'ULDｷｬﾘｱ選択
                lblVaConditionTitle.Visible = False         '蒸着処理条件ﾀｲﾄﾙﾗﾍﾞﾙ
                lblVaCondition.Visible = False              '蒸着処理条件ﾗﾍﾞﾙ
                lblVaConditionFlagTitle.Visible = False     '(蒸着処理条件)有効/無効ﾀｲﾄﾙﾗﾍﾞﾙ
                lblVaConditionFlag.Visible = False          '(蒸着処理条件)有効/無効ﾗﾍﾞﾙ
                cmdDummySelect.Visible = False              'ﾀﾞﾐｰ冶具選択
                cmdLotConnectedInfoDisp.Visible = False     'TFT/CF情報表示

                lblInstruction.Visible = False              '表面処理装置ﾊﾞｯﾁ組仕様の説明
                lblTitlePair.Visible = False
                lblTitleInspect.Visible = False
                lblTitleCfLot.Visible = True
                cmdMoveAll.Visible = False                

                mblnWpDetailDisp = True                     '装置詳細表示(する)
                
                vsfBat.Top = 159                            'ﾊﾞｯﾁ組予定ﾛｯﾄ一覧の表示位置(Top)
                vsfBat.Height = 256                         'ﾊﾞｯﾁ組予定ﾛｯﾄ一覧の高さ

            Else
                '@2A0：基板起動の場合

                '@各種ｺﾝﾄﾛｰﾙを表示する
                cmdUP.Visible = True                        '"↑"ﾎﾞﾀﾝ
                cmdDown.Visible = True                      '"↓"ﾎﾞﾀﾝ
                cmdCarrierSelect.Visible = True             'ULDｷｬﾘｱ選択
                lblVaConditionTitle.Visible = True          '蒸着処理条件ﾀｲﾄﾙﾗﾍﾞﾙ
                lblVaCondition.Visible = True               '蒸着処理条件ﾗﾍﾞﾙ
                lblVaConditionFlagTitle.Visible = True      '(蒸着処理条件)有効/無効ﾀｲﾄﾙﾗﾍﾞﾙ
                lblVaConditionFlag.Visible = True           '(蒸着処理条件)有効/無効ﾗﾍﾞﾙ
                cmdDummySelect.Visible = True               'ﾀﾞﾐｰ冶具選択
                cmdLotConnectedInfoDisp.Visible = True      'TFT/CF情報表示

                lblInstruction.Visible = True               '表面処理装置ﾊﾞｯﾁ組仕様の説明
                lblTitlePair.Visible = True
                lblTitleInspect.Visible = True
                lblTitleCfLot.Visible = True
                cmdMoveAll.Visible = False
                cmdMoveAll.Text = ">>" + vbCrLf + "一括移動"
                
                lblTitlePair.BackColor = ColorTranslator.FromWin32(CPlngBatchPair)
                lblTitleInspect.BackColor = ColorTranslator.FromWin32(CPlngInspectNg)
                lblTitleCfLot.BackColor = ColorTranslator.FromWin32(CPlngCfColor)
                
                mblnWpDetailDisp = False                    '装置詳細表示(しない)

                vsfBat.Top = 206                            'ﾊﾞｯﾁ組予定ﾛｯﾄ一覧の表示位置(Top)
                vsfBat.Height = 220                         'ﾊﾞｯﾁ組予定ﾛｯﾄ一覧の高さ

            End If

            '@ﾓｼﾞｭｰﾙ変数の初期化
            mstrOldMcGroupID = vbNullString                 '前回ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟID退避用変数

            '@ﾓｼﾞｭｰﾙ構造体の初期化
            mtypMcGpLotInfo = ltypMcGpLotInfo               '装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄ構造体

            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvFrmxxEN00M0_Init"        'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvComboBox_Init
    '機　能：ｺﾝﾎﾞﾎﾞｯｸｽ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/06/04 (Thu) 13:28:44 N.Kojima
    '更新日：2009/06/04 (Thu) 13:28:44
    '備　考：
    Private Sub prvComboBox_Init()

        Try

            '@ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞの初期化
            With cmbMcGpName

                .Clear                                                          'ｺﾝﾎﾞ情報初期化
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColName                                   'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColID                                   '値取得列
                .DirectInput = False                                            'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.Name, CType(CMlngCmbFontSize, Single))   'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.Font.Name, CType(CMlngCmbGridFontSize, Single))  'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  '行の高さ
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter   '左寄中央揃え
                .BackColor = Color.White
            End With

            '@装置名ｺﾝﾎﾞの初期化
            With cmbWpName

                .Clear                                                          'ｺﾝﾎﾞ情報初期化
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColName                                   'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColID                                   '値取得列
                .DirectInput = False                                            'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.Name, CType(CMlngCmbFontSize, Single))   'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.Font.Name, CType(CMlngCmbGridFontSize, Single))  'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  '行の高さ
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter   '左寄中央揃え
                .Enabled = False                                                '使用不可
                .BackColor = Color.White
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvComboBox_Init"           'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbMcGpName_Disp
    '機　能：装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞの設定
    '引　数：ltypMcGroupList：装置ｸﾞﾙｰﾌﾟ構造体
    '戻り値：なし
    '作成日：2004/07/22 (Thu) 20:35:53 T.Kitagawa
    '更新日：2009/06/04 (Thu) 13:45:57 N.Kojima
    '備　考：
    '　　　：2009/06/04 (Thu) 13:45:57 N.Kojima     無機対応。(案件№03560)
    Private Sub prvCmbMcGpName_Disp(ByRef ltypMcGroupList As McGroupList)

        Dim llngCnt     As Integer  'ｶｳﾝﾀ

        Try

            With ltypMcGroupList

                '@装置ｸﾞﾙｰﾌﾟ情報ｾｯﾄ
                For llngCnt = 0 To .lngMcGroupListCnt - 1

                    '@装置ｸﾞﾙｰﾌﾟ名/装置ｸﾞﾙｰﾌﾟID
                    cmbMcGpName.AddItem(ltypMcGroupList.typMcGroupList(llngCnt).strMcGroupName _
                    & vbTab & _
                    ltypMcGroupList.typMcGroupList(llngCnt).strMcGroupID)

                Next llngCnt

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvCmbMcGpName_Disp"        'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvALLInfo_Init
    '機　能：ﾊﾞｯﾁ管理画面情報初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/23 (Fri) 09:58:29 T.Kitagawa
    '更新日：2016/07/04 (Mon) 15:40:18 T.Oide
    '備　考：
    '　　　：2004/10/04 (Mon) 17:48:32 T.Kitagawa　 ﾀｲﾄﾙの自動列幅調整(不具合№1040)
    '　　　：2005/01/18 (Tue) 08:50:39 S.Deguchi    ﾊﾞｯﾁ編成済み一覧のﾌﾟﾛﾊﾟﾃｨ追加
    '　　　：2005/09/13 (Tue) 11:25:02 T.Kitagawa   処理開始予定日を追加(不具合№2972)
    '　　　：2009/06/05 (Fri) 10:21:33 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/24 (Fri) 10:21:51 N.Kojima     無機対応Phase2、流動区分名列追加。(案件№03661)
    '　　　：2009/11/18 (Wed) 11:20:03 N.Kojima     (蒸着処理条件)有効/無効ﾗﾍﾞﾙの初期化処理を追加。(案件№03790)
    Private Sub prvALLInfo_Init()

        Dim ltypVaConditionListAns      As VaConditionListAns   '蒸着処理条件取得結果格納用
        Dim llngCnt                     As Integer              'ｶｳﾝﾀ(汎用)

        Try

            '@-----------------------
            '@ ﾎﾞﾀﾝの初期化
            '@-----------------------
            '@各種ﾎﾞﾀﾝを無効にする
            cmdLotList.Enabled = False                      '最新取得
            cmdEdit.Enabled = False                         '編集
            cmdDelete.Enabled = False                       '削除
            cmdKakutei.Enabled = False                      '確定
            cmdMove.Enabled = False                         '">"
            cmdRemove.Enabled = False                       '"<"
            cmdUP.Enabled = False                           '"↑"
            cmdDown.Enabled = False                         '"↓"
            cmdCarrierSelect.Enabled = False                'ULDｷｬﾘｱ選択
            cmdMonitorLotList.Enabled = False               'ﾓﾆﾀ選択
            cmdDummySelect.Enabled = False                  'ﾀﾞﾐｰ冶具選択
            cmdClear.Enabled = False                        '取消
        '@↓2019/06/04 (Tue) 11:37:19 Y.Yoneyama **************************************************
            cmdLotConnectedInfoDisp.Enabled = False         'TFT/CF情報表示
        '@↑2019/06/04 (Tue) 11:37:19 Y.Yoneyama **************************************************


            '@ｺﾝﾎﾞBOXのｸﾘｱ
            cmbWpName.Clear                                 '装置名
            cmbWpName.Enabled = False

            '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧を無効にする
            vsfBat.Enabled = False

            '@-----------------------
            '@ ﾗﾍﾞﾙの初期化
            '@-----------------------
            lblNowDate.Text = vbNullString                  '情報取得日時
            lblLotListCnt.Text = vbNullString               '該当件数
            lblProductWpList.Text = vbNullString            '製品ﾛｯﾄWPﾘｽﾄ
            lblProductWpList.Width = vsfProduct.Width       '製品ﾛｯﾄWPﾘｽﾄ
            lblProductWpList.AutoSize = False               'NSYS 自動幅調整なし
            lblMaxLotCnt.Text = vbNullString                '最大ﾛｯﾄ数
            lblBatchID.Text = vbNullString                  'ﾊﾞｯﾁID
            lblRecipeID.Text = vbNullString                 'ﾚｼﾋﾟID
            lblBatLotWFCnt.Text = vbNullString              'ﾊﾞｯﾁ組WF枚数
            lblVaCondition.Text = vbNullString              '蒸着処理条件
            lblVaConditionFlag.Text = vbNullString          '(蒸着処理条件)有効/無効
            lblMesModeId.Text = vbNullString                '運用モード
            lblMethod.Text = vbNullString                   'ﾊﾞｯﾁ編成方式

            '@-----------------------
            '@ 表示ｵﾌﾟｼｮﾝﾎﾞﾀﾝの初期化
            '@-----------------------
            '@各種ｵﾌﾟｼｮﾝﾎﾞﾀﾝの有効/無効を制御
            optKubun0.Enabled = False                       '全て
            optKubun1.Enabled = False                       '製品ﾛｯﾄ
            optKubun2.Enabled = False                       'ﾓﾆﾀﾛｯﾄ
            optKubun3.Enabled = False                       'ﾀﾞﾐｰﾛｯﾄ

            '@各種ｵﾌﾟｼｮﾝﾎﾞﾀﾝのﾁｪｯｸをOFFにする
            optKubun0.Checked = False                       '全て
            optKubun1.Checked = False                       '製品ﾛｯﾄ
            optKubun2.Checked = False                       'ﾓﾆﾀﾛｯﾄ
            optKubun3.Checked = False                       'ﾀﾞﾐｰﾛｯﾄ


            '@-----------------------
            '@ 製品ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞの初期化
            '@-----------------------
            '@=======================
            '@ 製品ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ初期化処理
            '@=======================
            Call prvVsfProduct_Init()


            '@-----------------------
            '@ ﾊﾞｯﾁ編成済み一覧ｸﾞﾘｯﾄﾞの初期化
            '@-----------------------
            With vsfBatList

                .Redraw = False
                '@内容初期化
                .Clear 'flexClearScrollable, flexClearText

                '@行数、列数の初期設定
                RemoveHandler vsfBatList.BeforeRowColChange,AddressOf vsfBatList_BeforeRowColChange
                RemoveHandler vsfBatList.EnterCell,AddressOf vsfBatList_EnterCell
                .Rows.Count = 1
                .Cols.Count = 8
                AddHandler vsfBatList.EnterCell,AddressOf vsfBatList_EnterCell
                AddHandler vsfBatList.BeforeRowColChange,AddressOf vsfBatList_BeforeRowColChange

                '@列幅、ﾀｲﾄﾙ設定
                .SetData(CMlngGridTitleCol, CMlngvsfBatListNoC, CMstrvsfBatListNoT)                   'No
                .Cols(CMlngvsfBatListNoC).Width = CMlngvsfBatListNoW

                .SetData(CMlngGridTitleCol, CMlngvsfBatListWpNoC, CMstrvsfBatListWpNoT)               '装置№
                .Cols(CMlngvsfBatListWpNoC).Width = CMlngvsfBatListWpNoW

                .SetData(CMlngGridTitleCol, CMlngvsfBatListBatchIdC, CMstrvsfBatListBatchIdT)         'ﾊﾞｯﾁID
                .Cols(CMlngvsfBatListBatchIdC).Width = CMlngvsfBatListBatchIdW

                .SetData(CMlngGridTitleCol, CMlngvsfBatListWfNumC, CMstrvsfBatListWfNumT)             'WF枚数
                .Cols(CMlngvsfBatListWfNumC).Width = CMlngvsfBatListWfNumW

                .SetData(CMlngGridTitleCol, CMlngvsfBatListRecipeIdC, CMstrvsfBatListRecipeIdT)       'ﾚｼﾋﾟ
                .Cols(CMlngvsfBatListRecipeIdC).Width = CMlngvsfBatListRecipeIdW

                .SetData(CMlngGridTitleCol, CMlngvsfBatListVaConditionIdC, CMstrvsfBatListVaConditionIdT)         '蒸着処理条件
                .Cols(CMlngvsfBatListVaConditionIdC).Width = CMlngvsfBatListVaConditionIdW

                .SetData(CMlngGridTitleCol, CMlngvsfBatListVaConditionFlagC, CMstrvsfBatListVaConditionFlagT)     '蒸着処理条件制限ﾌﾗｸﾞ(0：無効、1：有効)
                .Cols(CMlngvsfBatListVaConditionFlagC).Width = CMlngvsfBatListVaConditionFlagW

                .SetData(CMlngGridTitleCol, CMlngvsfBatListLotNumC, CMstrvsfBatListLotNumT)           '編成ﾛｯﾄ数
                .Cols(CMlngvsfBatListVaConditionFlagC).Width = CMlngvsfBatListLotNumW


                '@ﾀｲﾄﾙの設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbYellow")
                newStyle.ForeColor = Color.Yellow
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
                Dim cellRange As CellRange = .GetCellRange(CMlngGridTitleCol, CMlngGridTitleCol, CMlngGridTitleCol, .Cols.Count - 1)
                cellRange.Style = newStyle
                .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
                .Styles.Fixed.Trimming = StringTrimming.None             '省略符号(...)表示なし

        '@↓2019/06/06 (Thu) 11:04:53 Y.Yoneyama **************************************************
                For llngCnt = CMlngGridTitleCol To .Cols.Count - 1  '全列表示
                    .Cols(llngCnt).Visible = True
                Next llngCnt
        '@↑2019/06/06 (Thu) 11:04:53 Y.Yoneyama **************************************************

                '@行幅設定
                .Rows(CMlngGridTitleCol).Height = CMlngGridTitleHeight

                '@自動列幅変更=ﾃﾞｰﾀ書き換えの際、自動調整しない
                .AllowResizing = AllowResizingEnum.None

                '@ｿｰﾄ不可
                '.AllowSorting = SortFlags.None

                '@複数選択不可
                .SelectionMode  = SelectionModeEnum.Row

                '@自動列幅設定(初期調整)
                .AutoSizeCols(CMlngvsfBatListNoC, .Cols.Count - 1, 6)

                .LeftCol = 0
                .Redraw = True

                '@使用不可設定
                .Enabled = False

                '@ﾘﾌﾚｯｼｭする
                .Refresh

            End With


            '@-----------------------
            '@ ﾊﾞｯﾁ組予定ﾛｯﾄ一覧の初期化
            '@-----------------------
            With vsfBat

                '@行数、列数の初期設定
                RemoveHandler vsfBat.EnterCell,AddressOf vsfBat_EnterCell
                .Rows.Count = 1
                AddHandler vsfBat.EnterCell,AddressOf vsfBat_EnterCell

                '@内容初期化
                .Clear(ClearFlags.Content, .Rows.Fixed, .Cols.Fixed, .Rows.Count - 1, .Cols.Count - 1)

                .Cols(CMlngvsfBatSeqNumC).Width = CMlngvsfBatListNoW
                .Cols(CMlngvsfBatCarrierIdC).Width = CMlngvsfLotCarrierIdW
                .Cols(CMlngvsfBatLotIdC).Width = CMlngvsfLotLotIdW

                '@列幅、ﾀｲﾄﾙ設定
                .SetData(CMlngGridTitleCol, CMlngvsfBatSeqNumC, CMstrvsfBatSeqNumT)               '順
                .Cols(CMlngvsfBatSeqNumC).Width = CMlngvsfBatSeqNumW

                .SetData(CMlngGridTitleCol, CMlngvsfBatCarrierIdC, CMstrvsfBatCarrierIdT)         'ｷｬﾘｱID
                .Cols(CMlngvsfBatCarrierIdC).Width = CMlngvsfBatCarrierIdW

                .SetData(CMlngGridTitleCol, CMlngvsfBatJigIDC, CMstrvsfBatJigIDT)                 '冶具ID
                .Cols(CMlngvsfBatJigIDC).Width = CMlngvsfBatJigIDW

                .SetData(CMlngGridTitleCol, CMlngvsfBatLotIdC, CMstrvsfBatLotIdT)                 'ﾛｯﾄID
                .Cols(CMlngvsfBatLotIdC).Width = CMlngvsfBatLotIdW

                .SetData(CMlngGridTitleCol, CMlngvsfBatLastUpdateC, CMstrvsfBatLastUpdateT)       '最終更新日
                .Cols(CMlngvsfBatLastUpdateC).Width = CMlngvsfBatLastUpdateW

                .SetData(CMlngGridTitleCol, CMlngvsfBatProductOldNoC, CMstrvsfBatProductOldNoT)   '製品ﾛｯﾄｸﾞﾘｯﾄﾞの行番号("<"ﾎﾞﾀﾝ用)
                .Cols(CMlngvsfBatProductOldNoC).Width = CMlngvsfBatProductOldNoW

                .SetData(CMlngGridTitleCol, CMlngvsfBatUldCarrierIDC, CMstrvsfBatUldCarrierIDT)   'ULDｷｬﾘｱID
                .Cols(CMlngvsfBatUldCarrierIDC).Width = CMlngvsfBatUldCarrierIDW

                .SetData(CMlngGridTitleCol, CMlngvsfBatWFIDC, CMstrvsfBatWFIDT)                   'WFID
                .Cols(CMlngvsfBatWFIDC).Width = CMlngvsfBatWFIDW

                .SetData(CMlngGridTitleCol, CMlngvsfBatPanelKindC, CMstrvsfBatPanelKindT)         'Cfﾌﾗｸﾞ(0：TFT、1：CF)
                .Cols(CMlngvsfBatPanelKindC).Width = CMlngvsfBatPanelKindW

                .SetData(CMlngGridTitleCol, CMlngvsfBatVaConditionIDC, CMstrvsfBatVaConditionIDT) '蒸着処理条件
                .Cols(CMlngvsfBatVaConditionIDC).Width = CMlngvsfBatVaConditionIDW

                .SetData(CMlngGridTitleCol, CMlngvsfBatWFNumC, CMstrvsfBatWFNumT)                 'WF枚数
                .Cols(CMlngvsfBatWFNumC).Width = CMlngvsfBatWFNumW

                .SetData(CMlngGridTitleCol, CMlngvsfBatUseIDC, CMstrvsfBatUseIDT)                 '製品区分
                .Cols(CMlngvsfBatUseIDC).Width = CMlngvsfBatUseIDW

                .SetData(CMlngGridTitleCol, CMlngvsfBatLpFlagC, CMstrvsfBatLpFlagT)               '大板(Lp)ﾌﾗｸﾞ
                .Cols(CMlngvsfBatLpFlagC).Width = CMlngvsfBatLpFlagW

                .SetData(CMlngGridTitleCol, CMlngvsfBatFlowClassC, CMstrvsfBatFlowClassT)         '種別
                .Cols(CMlngvsfBatFlowClassC).Width = CMlngvsfBatFlowClassW

                '@↓2019/05/17 (Fri) 10:15:15 Y.Yoneyama **************************************************
                .SetData(CMlngGridTitleCol, CMlngvsfBatVaFlagC, CMstrvsfBatVaFlagT)               '無機ﾌﾗｸﾞ
                .Cols(CMlngvsfBatVaFlagC).Width = CMlngvsfBatVaFlagW

                .SetData(CMlngGridTitleCol, CMlngvsfBatPdIdC, CMstrvsfBatPdIdT)                   '機種
                .Cols(CMlngvsfBatPdIdC).Width = CMlngvsfBatPdIdW

                .SetData(CMlngGridTitleCol, CMlngvsfBatJBatchIdC, CMstrvsfBatJBatchIdT)           '蒸着ﾊﾞｯﾁID
                .Cols(CMlngvsfBatJBatchIdC).Width = CMlngvsfBatJBatchIdW

                .SetData(CMlngGridTitleCol, CMlngvsfBatHBatchIdC, CMstrvsfBatHBatchIdT)           '表面処理ﾊﾞｯﾁID
                .Cols(CMlngvsfBatHBatchIdC).Width = CMlngvsfBatHBatchIdW

                .SetData(CMlngGridTitleCol, CMlngvsfBatInspectFlagC, CMstrvsfBatInspectFlagT)     '無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ
                .Cols(CMlngvsfBatInspectFlagC).Width = CMlngvsfBatInspectFlagW

                '@↑2019/05/17 (Fri) 10:15:15 Y.Yoneyama **************************************************

                '@表示列の設定
                .Cols(CMlngvsfBatSeqNumC).Visible = True            '順
                .Cols(CMlngvsfBatCarrierIdC).Visible = True         'ｷｬﾘｱID
                .Cols(CMlngvsfBatLotIdC).Visible = True             'ﾛｯﾄID

                '@非表示列の設定
                .Cols(CMlngvsfBatJigIDC).Visible = False            '冶具ID
                .Cols(CMlngvsfBatLastUpdateC).Visible = False       '最終更新日
                .Cols(CMlngvsfBatProductOldNoC).Visible = False     '製品ﾛｯﾄｸﾞﾘｯﾄﾞの行番号("<"ﾎﾞﾀﾝ用)
                .Cols(CMlngvsfBatUldCarrierIDC).Visible = False     'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                .Cols(CMlngvsfBatWFIDC).Visible = False             'WFID
                .Cols(CMlngvsfBatPanelKindC).Visible = False        'ﾊﾟﾈﾙ種別(0：TFT、1：CF)
                .Cols(CMlngvsfBatVaConditionIDC).Visible = False    '蒸着処理条件
                .Cols(CMlngvsfBatWFNumC).Visible = False            'WF枚数
                .Cols(CMlngvsfBatUseIDC).Visible = False            '製品区分
                .Cols(CMlngvsfBatLpFlagC).Visible = False           '大板(Lp)ﾌﾗｸﾞ
                .Cols(CMlngvsfBatFlowClassC).Visible = False        '種別
                '@↓2019/05/17 (Fri) 10:19:17 Y.Yoneyama **************************************************
                .Cols(CMlngvsfBatVaFlagC).Visible = False           '無機ﾌﾗｸﾞ
                .Cols(CMlngvsfBatPdIdC).Visible = False             '機種
                .Cols(CMlngvsfBatJBatchIdC).Visible = False         '蒸着ﾊﾞｯﾁID
                .Cols(CMlngvsfBatHBatchIdC).Visible = False         '表面処理ﾊﾞｯﾁID
                If pstrSBID = CPstrSBID1A0 Then
                    .Cols(CMlngvsfBatInspectFlagC).Visible = False  '無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ
                End If
                '@↑2019/05/17 (Fri) 10:19:17 Y.Yoneyama **************************************************

                '@ﾀｲﾄﾙの設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbYellow")
                newStyle.ForeColor = Color.Yellow
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
                Dim cellRange As CellRange = .GetCellRange(CMlngGridTitleCol, CMlngGridTitleCol, CMlngGridTitleCol, .Cols.Count - 1)
                cellRange.Style = newStyle
                .Styles.Fixed.Trimming = StringTrimming.None             '省略符号(...)表示なし

                '@行幅設定
                .Rows(CMlngGridTitleCol).Height = CMlngGridTitleHeight

                '@複数選択不可
                .SelectionMode = SelectionModeEnum.Row

                '@ﾘﾌﾚｯｼｭする
                .Refresh

            End With

            '@WPﾘｽﾄの初期化
            If mtypWpList Is Nothing Then
                mtypWpList = New List(Of WpList)
            Else
                mtypWpList.Clear()
            End If
            mlngWpListCnt = 0

            '@ﾊﾞｯﾁ組ﾛｯﾄ情報応答構造体の初期化
            If mtypBatLotList.typBatLot Is Nothing Then
                mtypBatLotList.typBatLot = New List(Of BatLot)
            Else
                mtypBatLotList.typBatLot.Clear()
            End If
            mtypBatLotList.lngBatLotCnt = 0

            '@各種ﾓｼﾞｭｰﾙ変数の初期化
            mtypVaConditionListAns = ltypVaConditionListAns     '蒸着処理条件格納構造体
            mlngOldcmbWpNameIndex = -1                          '前回装置名ｺﾝﾎﾞのINDEX退避用変数の初期化
            mstrInputClassDivision = vbNullString               '入力処理区分の初期化(新規)
            mblnInEditKbn = False                               '編集中区分の初期化(未編集)

            '@取消ﾎﾞﾀﾝを無効にする
            cmdClear.Enabled = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvALLInfo_Init"            'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvALLInfo_Sel
    '機　能：ﾊﾞｯﾁ管理画面情報取得(製品ﾛｯﾄ一覧情報etc…)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/26 (Mon) 11:38:17 T.Kitagawa
    '更新日：2012/03/08 (Thu) 13:00:29 T.Oide
    '備　考：
    '　　　：2004/09/15 (Wed) 11:21:29 N.Kasai      新COM対応(pubblnWpList_Sel　引数修正)
    '　　　：2005/07/12 (Tue) 17:46:36 N.Kojima     ﾊﾞｯﾁ全自動搬送対応(選択装置の運用ﾓｰﾄﾞがS2の場合はﾎﾞﾀﾝ操作無効)
    '　　　：2006/07/18 (Tue) 16:36:00 T.Kitagawa   製品ﾛｯﾄが無くてもﾓﾆﾀﾛｯﾄのみでもﾊﾞｯﾁ組を可能にする(ｼｽﾃﾑ案件№00871)
    '　　　：2009/06/04 (Thu) 16:57:27 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/24 (Fri) 10:23:49 N.Kojima     無機対応Phase2、組立の場合の装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄ取得を変更。(案件№03661)
    '　　　：2009/08/07 (Fri) 10:21:07 N.Kojima     運用障害対応(無機対応Phase3にてﾘﾘｰｽ)。(案件№03707)
    '　　　：2009/08/28 (Fri) 15:39:27 N.Kojima     [表示]ｵﾌﾟｼｮﾝﾎﾞﾀﾝの動作不具合修正に伴い、処理追加。(案件№03751)
    '　　　：2012/03/06 (Tue) 13:24:49 T.Oide       無機装置追加対応(REQ-1303)
    Private Sub prvALLInfo_Sel()

        Dim lblnAns                     As Boolean              '結果格納
        Dim ltypBatRequestList          As BatRequestList       'ﾊﾞｯﾁ組ﾛｯﾄ情報構造体(要求)
        Dim llngCnt                     As Integer              'ｶｳﾝﾀ(汎用)
        Dim lstrBefWpName               As String               '装置名格納
        Dim lstrWpNameList              As String               '装置名ﾘｽﾄ

        Try

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdLotListClick)

            '@=======================
            '@ 装置一覧取得
            '@=======================
            '@処理区分：20⇒装置ｸﾞﾙｰﾌﾟ別
            lblnAns = pubblnWpList_Sel(CMstrmas_wplist__Ver, _
                                        mlngWpListCnt, _
                                        pstrSBID, _
                                        CPstrCD20, _
                                        cmbMcGpName.Value)

            '@結果判定
            If lblnAns = True Then
                '@通信成功の場合

                '@装置名ｺﾝﾎﾞの初期化
                cmbWpName.Clear

                For llngCnt = 0 To mlngWpListCnt - 1

                    With ptypWPList(llngCnt)

                        '@装置名 & 装置ID & 最大処理単位ﾎﾞｯｸｽ数 & 運用ﾓｰﾄﾞ & 装置ﾀｲﾌﾟ(Eqtype)
                        cmbWpName.AddItem(.strWpName & vbTab & _
                                        .strWpID & vbTab & _
                                        .strMaxProcessBox & vbTab & _
                                        .strMesModeId & vbTab & _
                                        .strEqType)

                        '@WPﾘｽﾄの設定
                        Dim typWpListtmp = New WpList

                        typWpListtmp.strWpID = .strWpID                      '装置ID
                        typWpListtmp.strWpName = .strWpName                  '装置名
                        typWpListtmp.strMaxProcessBox = .strMaxProcessBox    '最大処理数
                        typWpListtmp.strMesModeId = .strMesModeId            '運用ﾓｰﾄﾞ
                        typWpListtmp.strEqType = .strEqType                  '装置ﾀｲﾌﾟ(Eqtype)
                        typWpListtmp.strBatchComposeType = .strBatchComposeType  'ﾊﾞｯﾁ自動編成ﾀｲﾌﾟ
                        mtypWpList.Add(typWpListtmp)
                    End With

                Next llngCnt

                '@装置名ｺﾝﾎﾞが1個の場合は該当装置名を自動表示する
                If cmbWpName.ListCount = 1 Then
                    cmbWpName.ListIndex = 0
                End If

                '@製品ﾛｯﾄWPﾘｽﾄﾗﾍﾞﾙの設定
                lblProductWpList.Text = vbNullString

                '@装置ﾘｽﾄｶｳﾝﾀが1件以上あるか
                If mlngWpListCnt > 0 Then
                    lblProductWpList.AutoSize = True    '自動幅調整
                Else
                    lblProductWpList.AutoSize = False   '自動幅調整なし
                End If


                lstrBefWpName = "ダミー初期値"                  '下記For文のﾙｰﾌﾟ一回目でｴﾗｰにしないため
                For llngCnt = 0 To mlngWpListCnt - 1
                
                    '@装置ﾘｽﾄを表示する(同じ装置名の号機違いは「#n」だけ表示)
                    If Mid$(lstrBefWpName, 1, Len(lstrBefWpName) - 2) = _
                       Mid$(mtypWpList(llngCnt).strWpName, 1, Len(mtypWpList(llngCnt).strWpName) - 2) Then
                       
                        '@号機だけ違う場合
                        lstrWpNameList = lstrWpNameList & _
                                         str$(llngCnt+1) & _
                                         CMstrColon & _
                                         Mid$(mtypWpList(llngCnt).strWpName, Len(mtypWpList(llngCnt).strWpName) - 1) & _
                                         Space$(1)
                    
                    Else
                    
                        '@まったく別装置の場合
                        lstrWpNameList = lstrWpNameList & _
                                         str$(llngCnt+1) & _
                                         CMstrColon & _
                                         mtypWpList(llngCnt).strWpName & _
                                         Space$(1)
                    End If
                    
                    '@前回値として退避
                    lstrBefWpName = mtypWpList(llngCnt).strWpName
                    
                Next llngCnt
                
                lblProductWpList.Text = lstrWpNameList

            Else
                '@通信失敗の場合

                '@ﾚｽﾎﾟﾝｽ取得中止
                Call pubResponseCancel(CMstrFormName, CMstrCmdLotListClick)
                Exit Sub
            End If


            '@=======================
            '@ 装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄ取得(全て)
            '@=======================
            '@処理区分：02⇒全て(量産品・実験品・試作品・ﾓﾆﾀ・ﾀﾞﾐｰ)
            lblnAns = pubblnLotMcGpLotList_Sel(CMstrlot_mcgplotlistVer, _
                                               pstrSBID, _
                                               cmbMcGpName.Value, _
                                               CPstrCD02, _
                                               mtypMcGpLotInfo)


            '@結果判定
            If lblnAns = True Then
                '@通信成功の場合

                '@取得日時、該当件数の表示
                lblNowDate.Text = Format$(Now, CPstrDateTimeMD) & Space(1) & Format$(Now, CPstrDateFormatHMS)      '取得日時
                lblLotListCnt.Text = Format$(mtypMcGpLotInfo.lngMcGpLotListCnt, CPstrDateFormatKanma)              '該当件数

                '@-----------------------
                '@ ｵﾌﾟｼｮﾝﾎﾞﾀﾝの初期化
                '@-----------------------
                '@基板(1A0)起動か
                If pstrSBID = CPstrSBID1A0 Then

                    '@各種ｵﾌﾟｼｮﾝﾎﾞﾀﾝの有効/無効を制御
                    optKubun0.Enabled = False                       '全て
                    optKubun1.Enabled = True                        '製品ﾛｯﾄ
                    optKubun2.Enabled = False                       'ﾓﾆﾀﾛｯﾄ
                    optKubun3.Enabled = False                       'ﾀﾞﾐｰﾛｯﾄ

                Else
                    '@組立(2A0)起動か

                    '@各種ｵﾌﾟｼｮﾝﾎﾞﾀﾝの有効/無効を制御
                    optKubun0.Enabled = True                        '全て
                    optKubun1.Enabled = True                        '製品ﾛｯﾄ
                    optKubun2.Enabled = True                        'ﾓﾆﾀﾛｯﾄ
                    optKubun3.Enabled = True                        'ﾀﾞﾐｰﾛｯﾄ

                    '@各種ｵﾌﾟｼｮﾝﾎﾞﾀﾝのﾁｪｯｸをOFFにする
                    optKubun0.Checked = False
                    optKubun2.Checked = False
                    optKubun3.Checked = False

                End If

                '@初期値は「1：製品ﾛｯﾄ」ｵﾌﾟｼｮﾝﾎﾞﾀﾝをﾁｪｯｸONにする
                optKubun1.Checked = True


                '@ﾊﾞｯﾁ組ﾛｯﾄ情報取得
                With ltypBatRequestList

                    .strMsgVer = CMstrbat_lotlist_Ver           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                    .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                    .strClassDivision = CPstrCD2G               '処理区分(装置ｸﾞﾙｰﾌﾟ指定)
                    .strCarrierId = vbNullString                'ｷｬﾘｱID
                    .strMcGroupID = cmbMcGpName.Value           '装置ｸﾞﾙｰﾌﾟID
                    .strWpID = vbNullString                     'WP_ID
                End With

                '@=======================
                '@ ﾊﾞｯﾁ組ﾛｯﾄ情報取得
                '@=======================
                lblnAns = pubblnBatLotList_Sel(ltypBatRequestList, mtypBatLotList)

                '@結果判定
                If lblnAns = True Then

                    '@=======================
                    '@ ﾊﾞｯﾁ編成一覧ｸﾞﾘｯﾄﾞの表示
                    '@=======================
                    Call prvVsfBatList_Disp()
                Else
                    '@最新取得ﾎﾞﾀﾝを有効にする
                    cmdLotList.Enabled = True

                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdLotListClick)
                    Exit Sub
                End If
            Else
                '@通信失敗の場合

                '@最新取得ﾎﾞﾀﾝを有効にする
                cmdLotList.Enabled = True

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdLotListClick)
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrCmdLotListClick)

            '表面処理予約の表示
            Call prvHReserveDisp

            '@-----------------------
            '@ 各種ｺﾝﾄﾛｰﾙの制御(条件によりTrue：有効にする)
            '@-----------------------
            '@①最新取得ﾎﾞﾀﾝを有効にする
            cmdLotList.Enabled = True

            '@②装置ﾘｽﾄが1件以上あるか
            If mlngWpListCnt > 0 Then

                cmbWpName.Enabled = True                '装置名ｺﾝﾎﾞ
                vsfBat.Enabled = True                   'ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ
            End If

            '@③製品ﾛｯﾄ一覧にﾃﾞｰﾀが1件以上あるか
            If vsfProduct.Rows.Count > 1 Then
                vsfProduct.Enabled = True               '製品ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ
            End If

            '@④ﾊﾞｯﾁ編成一覧にﾃﾞｰﾀが1件以上あるか
            If vsfBatList.Rows.Count > 1 Then
                vsfBatList.Enabled = True               'ﾊﾞｯﾁ編成一覧ｸﾞﾘｯﾄﾞ
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvALLInfo_Sel"    'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfProduct_Init
    '機　能：製品ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/07/24 (Fri) 13:33:21 N.Kojima
    '更新日：2013/11/06 (Wed) 16:30:49 T.Oide
    '備　考：
    Private Sub prvVsfProduct_Init()
        Dim llngCnt                     As Integer              'ｶｳﾝﾀ(汎用)

        Try

            '@-----------------------
            '@ 製品ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞの初期化
            '@-----------------------
            With vsfProduct

                .Redraw = False

                '@内容初期化
                .Clear 'flexClearScrollable, flexClearText

                '@行数、列数の初期設定
                .Rows.Count = 1
                .Cols.Count = 27

                '@列幅、ﾀｲﾄﾙ設定
                .SetData(CMlngGridTitleCol, CMlngvsfLotNoC, CMstrvsfLotNoT)                   'No
                .Cols(CMlngvsfLotNoC).Width = CMlngvsfLotNoW

                .SetData(CMlngGridTitleCol, CMlngvsfLotWpNoC, CMstrvsfLotWpNoT)               '装置№
                .Cols(CMlngvsfLotWpNoC).Width = CMlngvsfLotWpNoW

                .SetData(CMlngGridTitleCol, CMlngvsfLotCarrierIdC, CMstrvsfLotCarrierIdT)     'ｷｬﾘｱID
                .Cols(CMlngvsfLotCarrierIdC).Width = CMlngvsfLotCarrierIdW

                .SetData(CMlngGridTitleCol, CMlngvsfLotLotIdC, CMstrvsfLotLotIdT)             'ﾛｯﾄID
                .Cols(CMlngvsfLotLotIdC).Width = CMlngvsfLotLotIdW

                .SetData(CMlngGridTitleCol, CMlngvsfLotFlowClassC, CMstrvsfLotFlowClassT)     '種別
                .Cols(CMlngvsfLotFlowClassC).Width = CMlngvsfLotFlowClassW

                .SetData(CMlngGridTitleCol, CMlngvsfLotUseIDC, CMstrvsfLotUseIDT)             '製品区分
                .Cols(CMlngvsfLotUseIDC).Width = CMlngvsfLotUseIDW

                .SetData(CMlngGridTitleCol, CMlngvsfLotPriorityC, CMstrvsfLotPriorityT)       '優先順位
                .Cols(CMlngvsfLotPriorityC).Width = CMlngvsfLotPriorityW

                .SetData(CMlngGridTitleCol, CMlngvsfLotWfNumC, CMstrvsfLotWfNumT)             'WF枚数
                .Cols(CMlngvsfLotWfNumC).Width = CMlngvsfLotWfNumW

                .SetData(CMlngGridTitleCol, CMlngvsfLotRecipeIdC, CMstrvsfLotRecipeIdT)       'ﾚｼﾋﾟ
                .Cols(CMlngvsfLotRecipeIdC).Width = CMlngvsfLotRecipeIdW

                .SetData(CMlngGridTitleCol, CMlngvsfLotLimitTimeC, CMstrvsfLotLimitTimeT)     '時間制限
                .Cols(CMlngvsfLotLimitTimeC).Width = CMlngvsfLotLimitTimeW

                .SetData(CMlngGridTitleCol, CMlngvsfLotOptionTextC, CMstrvsfLotOptionTextT)   '作業条件
                .Cols(CMlngvsfLotOptionTextC).Width = CMlngvsfLotOptionTextW

                .SetData(CMlngGridTitleCol, CMlngvsfLotOpIdC, CMstrvsfLotOpIdT)               '大工程
                .Cols(CMlngvsfLotOpIdC).Width = CMlngvsfLotOpIdW

                .SetData(CMlngGridTitleCol, CMlngvsfLotStepIdC, CMstrvsfLotStepIdT)           '小工程
                .Cols(CMlngvsfLotStepIdC).Width = CMlngvsfLotStepIdW

                .SetData(CMlngGridTitleCol, CMlngvsfLotDispatchStartC, CMstrvsfLotDispatchStartT)     '処理開始予定
                .Cols(CMlngvsfLotDispatchStartC).Width = CMlngvsfLotDispatchStartW

                .SetData(CMlngGridTitleCol, CMlngvsfLotLastUpdateC, CMstrvsfLotLastUpdateT)   '最終更新日
                .Cols(CMlngvsfLotLastUpdateC).Width = CMlngvsfLotNoW

                .SetData(CMlngGridTitleCol, CMlngvsfLotWFIDC, CMstrvsfLotWFIDT)               'WFID
                .Cols(CMlngvsfLotWFIDC).Width = CMlngvsfLotWFIDW

                .SetData(CMlngGridTitleCol, CMlngvsfLotJigIDC, CMstrvsfLotJigIDT)             '冶具ID
                .Cols(CMlngvsfLotJigIDC).Width = CMlngvsfLotJigIDW

                .SetData(CMlngGridTitleCol, CMlngvsfLotLotKindC, CMstrvsfLotLotKindT)         'Cfﾌﾗｸﾞ(0：TFT、1：CF)
                .Cols(CMlngvsfLotLotKindC).Width = CMlngvsfLotLotKindW

                .SetData(CMlngGridTitleCol, CMlngvsfLotUldCarrierIdC, CMstrvsfLotUldCarrierIdT)       'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                .Cols(CMlngvsfLotUldCarrierIdC).Width = CMlngvsfLotUldCarrierIdW
                
                .SetData(CMlngGridTitleCol, CMlngvsfLotLpFlagC, CMstrvsfLotLpFlagT)           '大板(Lp)ﾌﾗｸﾞ
                .Cols(CMlngvsfLotLpFlagC).Width = CMlngvsfLotLpFlagW
                
                .SetData(CMlngGridTitleCol, CMlngvsfLotVaFlagC, CMstrvsfLotVaFlagT)           '無機ﾌﾗｸﾞ
                .Cols(CMlngvsfLotVaFlagC).Width = CMlngvsfLotVaFlagW
              
                .SetData(CMlngGridTitleCol, CMlngvsfLotPdIdC, CMstrvsfLotPdIdT)               '機種
                .Cols(CMlngvsfLotPdIdC).Width = CMlngvsfLotPdIdW
              
                .SetData(CMlngGridTitleCol, CMlngvsfLotJBatchIdC, CMstrvsfLotJBatchIdT)       '蒸着ﾊﾞｯﾁID
                .Cols(CMlngvsfLotJBatchIdC).Width = CMlngvsfLotJBatchIdW
              
                .SetData(CMlngGridTitleCol, CMlngvsfLotHBatchIdC, CMstrvsfLotHBatchIdT)       '表面処理ﾊﾞｯﾁID
                .Cols(CMlngvsfLotHBatchIdC).Width = CMlngvsfLotHBatchIdW
                
                .SetData(CMlngGridTitleCol, CMlngvsfLotInspectFlagC, CMstrvsfLotInspectFlagT) '無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ
                .Cols(CMlngvsfLotInspectFlagC).Width = CMlngvsfLotInspectFlagW
                
                .SetData(CMlngGridTitleCol, CMlngvsfLotPairCarrierC, CMstrvsfLotPairCarrierT) '蒸着ﾍﾟｱ
                .Cols(CMlngvsfLotPairCarrierC).Width = CMlngvsfLotPairCarrierW

                .SetData(CMlngGridTitleCol, CMlngvsfLotHReserveC, CMstrvsfLotHReserveT)         '表面処理予約
                .Cols(CMlngvsfLotHReserveC).Width = CMlngvsfLotHReserveW

                '@非表示列の設定
                For llngCnt = CMlngGridTitleCol To .Cols.Count - 1  '全列表示
                    .Cols(llngCnt).Visible = True
                Next llngCnt
                .Cols(CMlngvsfLotUseIDC).Visible = False          '製品区分
                .Cols(CMlngvsfLotLastUpdateC).Visible = False     '最終更新日
                .Cols(CMlngvsfLotWFIDC).Visible = False           'WFID
                .Cols(CMlngvsfLotJigIDC).Visible = False          '冶具ID
                .Cols(CMlngvsfLotLotKindC).Visible = False        'Cfﾌﾗｸﾞ(0：TFT、1：CF)
                .Cols(CMlngvsfLotUldCarrierIdC).Visible = False   'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                .Cols(CMlngvsfLotLpFlagC).Visible = False         '大板(Lp)ﾌﾗｸﾞ
                .Cols(CMlngvsfLotVaFlagC).Visible = False         '無機ﾌﾗｸﾞ
                .Cols(CMlngvsfLotPdIdC).Visible = False           '機種
                .Cols(CMlngvsfLotJBatchIdC).Visible = False       '蒸着ﾊﾞｯﾁID
                .Cols(CMlngvsfLotHBatchIdC).Visible = False       '表面処理ﾊﾞｯﾁID
                .Cols(CMlngvsfLotHReserveC).Visible = False       '表面処理予約

                '@ﾀｲﾄﾙの設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbYellow")
                newStyle.ForeColor = Color.Yellow
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
                Dim cellRange As CellRange = .GetCellRange(CMlngGridTitleCol, CMlngGridTitleCol, CMlngGridTitleCol, .Cols.Count - 1)
                cellRange.Style = newStyle
                .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
                .Styles.Fixed.Trimming = StringTrimming.None             '省略符号(...)表示なし

                '@行幅設定
                .Rows(CMlngGridTitleCol).Height = CMlngGridTitleHeight

                '@自動列幅設定=自動調整する
                .AutoSizeCols(CMlngvsfLotNoC, .Cols.Count - 1, 6)

                .Redraw = True

                '@使用不可設定
                .Enabled = False

                '@ﾘﾌﾚｯｼｭする
                .Refresh

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvVsfProduct_Init"         'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfProduct_Disp
    '機　能：製品ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞの表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/26 (Mon) 17:30:55 T.Kitagawa
    '更新日：2013/11/06 (Wed) 18:41:04 T.Oide
    '備　考：
    '　　　：2004/09/10 (Fri) 10:01:16 Y.Yamagishi　時間制限表示変更
    '　　　：2005/09/13 (Tue) 11:31:05 T.Kitagawa   処理開始予定日を追加(不具合№2972)
    '　　　：2006/05/12 (Fri) 13:32:51 T.Kitagawa   制限時間の表示を分合計から時間と分で分割表示する(#,##0時間 #0分)(ﾕｰｻﾞ要望№0186)
    '　　　：2009/06/04 (Thu) 17:05:43 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/24 (Fri) 10:24:55 N.Kojima     無機対応Phase2、流動区分列追加。(案件№03661)
    Private Sub prvVsfProduct_Disp()

        Dim lblnFindFlag                As Boolean              '検索ﾌﾗｸﾞ(True:有、False:無)
        Dim llngCnt                     As Integer              'ｶｳﾝﾀ(汎用)
        Dim llngCnt2                    As Integer              'ｶｳﾝﾀ(汎用)
        Dim llngCnt3                    As Integer              'ｶｳﾝﾀ(汎用)
        Dim llngCnt4                    As Integer              'ｶｳﾝﾀ(汎用)
        Dim llngCnt5                    As Integer              'ｶｳﾝﾀ(汎用)
        Dim lstrLimitTime               As String               '制限時間ﾌｫｰﾏｯﾄ用変数
        Dim lstrLimitTimeAns            As String               '時間制限変換用変数(#,##0時間 #0分)
        Dim lstrDispCondition           As String               '製品ﾛｯﾄ一覧表示条件
        Dim llngDispRow                 As Integer              '製品ﾛｯﾄ一覧表示行

        Try

            '@製品一覧ｸﾞﾘｯﾄﾞのﾀｲﾄﾙ可変列設定
            mlngvsfLotNoC = CMlngvsfLotNoC                                          'No
            mlngvsfLotWpStartNoC = CMlngvsfLotWpNoC                                 '開始装置№
            mlngvsfLotWpEndNoC = CMlngvsfLotWpNoC + mlngWpListCnt - 1               '終了装置№
            mlngvsfLotCarrierIdC = CMlngvsfLotCarrierIdC + mlngWpListCnt - 1        'ｷｬﾘｱID
            mlngvsfLotLotIdC = CMlngvsfLotLotIdC + mlngWpListCnt - 1                'ﾛｯﾄID
            mlngvsfLotFlowClassC = CMlngvsfLotFlowClassC + mlngWpListCnt - 1        '種別
            mlngvsfLotUseIDC = CMlngvsfLotUseIDC + mlngWpListCnt - 1                '製品区分
            mlngvsfLotPriorityC = CMlngvsfLotPriorityC + mlngWpListCnt - 1          '優先順位
            mlngvsfLotWfNumC = CMlngvsfLotWfNumC + mlngWpListCnt - 1                'WF枚数
            mlngvsfLotRecipeIdC = CMlngvsfLotRecipeIdC + mlngWpListCnt - 1          'ﾚｼﾋﾟID
            mlngvsfLotLimitTimeC = CMlngvsfLotLimitTimeC + mlngWpListCnt - 1        '時間制限
            mlngvsfLotOptionTextC = CMlngvsfLotOptionTextC + mlngWpListCnt - 1      '作業条件
            mlngvsfLotOpIdC = CMlngvsfLotOpIdC + mlngWpListCnt - 1                  '大工程
            mlngvsfLotStepIdC = CMlngvsfLotStepIdC + mlngWpListCnt - 1              '小工程
            mlngvsfLotDispatchStartC = CMlngvsfLotDispatchStartC + mlngWpListCnt - 1    '処理開始予定
            mlngvsfLotLastUpdateC = CMlngvsfLotLastUpdateC + mlngWpListCnt - 1      '最終更新日
            mlngvsfLotWfIdC = CMlngvsfLotWFIDC + mlngWpListCnt - 1                  'WFID
            mlngvsfLotJigIDC = CMlngvsfLotJigIDC + mlngWpListCnt - 1                '冶具ID
            mlngvsfLotLotKindC = CMlngvsfLotLotKindC + mlngWpListCnt - 1            'Cfﾌﾗｸﾞ(0：TFT、1：CF)
            mlngvsfLotUldCarrierIdC = CMlngvsfLotUldCarrierIdC + mlngWpListCnt - 1  'ｱﾝﾛｰﾀﾞｷｬﾘｱID
            mlngvsfLotLpFlagC = CMlngvsfLotLpFlagC + mlngWpListCnt - 1              '大板(Lp)ﾌﾗｸﾞ
            mlngvsfLotVaFlagC = CMlngvsfLotVaFlagC + mlngWpListCnt - 1              '無機ﾌﾗｸﾞ
            mlngvsfLotPdIdC = CMlngvsfLotPdIdC + mlngWpListCnt - 1                  '機種
            mlngvsfLotJBatchIdC = CMlngvsfLotJBatchIdC + mlngWpListCnt - 1          '蒸着ﾊﾞｯﾁID
            mlngvsfLotHBatchIdC = CMlngvsfLotHBatchIdC + mlngWpListCnt - 1          '表面処理ﾊﾞｯﾁID
            mlngvsfLotInspectFlagC = CMlngvsfLotInspectFlagC + mlngWpListCnt - 1    '無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ
            mlngvsfLotPairCarrierC = CMlngvsfLotPairCarrierC + mlngWpListCnt - 1    '蒸着ﾍﾟｱ
            mlngvsfLotHReserveC = CMlngvsfLotHReserveC + mlngWpListCnt - 1          '表面処理予約

            '@製品一覧ｸﾞﾘｯﾄﾞのﾀｲﾄﾙ(列)設定
            With vsfProduct

                '@初期設定
                RemoveHandler vsfProduct.EnterCell,AddressOf vsfProduct_EnterCell
                .Row = -1
                .Rows.Count = 1
                AddHandler vsfProduct.EnterCell,AddressOf vsfProduct_EnterCell

                '@列数設定
                .Cols.Count = .Cols.Count + mlngWpListCnt - 1

                '@ﾀｲﾄﾙの文字設定
                .SetData(CMlngGridTitleCol, mlngvsfLotNoC, CMstrvsfLotNoT)                            'No

                For llngCnt = mlngvsfLotWpStartNoC To mlngvsfLotWpEndNoC
                    .SetData(CMlngGridTitleCol, llngCnt, Trim$(str$(llngCnt)))                        '装置№
                Next llngCnt

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngGridTitleCol, mlngvsfLotCarrierIdC, CMstrvsfLotCarrierIdT)              'ｷｬﾘｱID
                .SetData(CMlngGridTitleCol, mlngvsfLotLotIdC, CMstrvsfLotLotIdT)                      'ﾛｯﾄID
                .SetData(CMlngGridTitleCol, mlngvsfLotFlowClassC, CMstrvsfLotFlowClassT)              '種別
                .SetData(CMlngGridTitleCol, mlngvsfLotUseIDC, CMstrvsfLotUseIDT)                      '製品区分
                .SetData(CMlngGridTitleCol, mlngvsfLotPriorityC, CMstrvsfLotPriorityT)                '優先順位
                .SetData(CMlngGridTitleCol, mlngvsfLotWfNumC, CMstrvsfLotWfNumT)                      'WF枚数
                .SetData(CMlngGridTitleCol, mlngvsfLotRecipeIdC, CMstrvsfLotRecipeIdT)                'ﾚｼﾋﾟ
                .SetData(CMlngGridTitleCol, mlngvsfLotLimitTimeC, CMstrvsfLotLimitTimeT)              '時間制限
                .SetData(CMlngGridTitleCol, mlngvsfLotOptionTextC, CMstrvsfLotOptionTextT)            '作業条件
                .SetData(CMlngGridTitleCol, mlngvsfLotOpIdC, CMstrvsfLotOpIdT)                        '大工程
                .SetData(CMlngGridTitleCol, mlngvsfLotStepIdC, CMstrvsfLotStepIdT)                    '小工程
                .SetData(CMlngGridTitleCol, mlngvsfLotDispatchStartC, CMstrvsfLotDispatchStartT)      '処理開始予定
                .SetData(CMlngGridTitleCol, mlngvsfLotLastUpdateC, CMstrvsfLotLastUpdateT)            '最終更新日
                .SetData(CMlngGridTitleCol, mlngvsfLotWfIdC, CMstrvsfLotWFIDT)                        'WFID
                .SetData(CMlngGridTitleCol, mlngvsfLotJigIDC, CMstrvsfLotJigIDT)                      '冶具ID
                .SetData(CMlngGridTitleCol, mlngvsfLotLotKindC, CMstrvsfLotLotKindT)                  'Cfﾌﾗｸﾞ(0：TFT、1：CF)
                .SetData(CMlngGridTitleCol, mlngvsfLotUldCarrierIdC, CMstrvsfLotUldCarrierIdT)        'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                .SetData(CMlngGridTitleCol, mlngvsfLotLpFlagC, CMstrvsfLotLpFlagT)                    '大板(Lp)ﾌﾗｸﾞ
                .SetData(CMlngGridTitleCol, mlngvsfLotVaFlagC, CMstrvsfLotVaFlagT)                    '無機ﾌﾗｸﾞ
                .SetData(CMlngGridTitleCol, mlngvsfLotPdIdC, CMstrvsfLotPdIdT)                        '機種
                .SetData(CMlngGridTitleCol, mlngvsfLotJBatchIdC, CMstrvsfLotJBatchIdT)                '蒸着ﾊﾞｯﾁID
                .SetData(CMlngGridTitleCol, mlngvsfLotHBatchIdC, CMstrvsfLotHBatchIdT)                '表面処理ﾊﾞｯﾁID
                .SetData(CMlngGridTitleCol, mlngvsfLotInspectFlagC, CMstrvsfLotInspectFlagT)          '無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ
                .SetData(CMlngGridTitleCol, mlngvsfLotPairCarrierC, CMstrvsfLotPairCarrierT)          '蒸着ﾍﾟｱ
                .SetData(CMlngGridTitleCol, mlngvsfLotHReserveC, CMstrvsfLotHReserveT)                '表面処理予約

                '@非表示設定
                For llngCnt = CMlngGridTitleCol To .Cols.Count - 1  '全列表示
                    .Cols(llngCnt).Visible = True
                Next llngCnt
                .Cols(mlngvsfLotUseIDC).Visible = False             '製品区分
                .Cols(mlngvsfLotLastUpdateC).Visible = False        '最終更新日
                .Cols(mlngvsfLotWfIdC).Visible = False              'WFID
                .Cols(mlngvsfLotJigIDC).Visible = False             '冶具ID
                .Cols(mlngvsfLotLotKindC).Visible = False           'Cfﾌﾗｸﾞ(0：TFT、1：CF)
                .Cols(mlngvsfLotUldCarrierIdC).Visible = False      'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                .Cols(mlngvsfLotLpFlagC).Visible = False            '大板(Lp)ﾌﾗｸﾞ
                .Cols(mlngvsfLotVaFlagC).Visible = False            '無機ﾌﾗｸﾞ
                .Cols(mlngvsfLotPdIdC).Visible = False              '機種
                .Cols(mlngvsfLotJBatchIdC).Visible = False          '蒸着ﾊﾞｯﾁID
                .Cols(mlngvsfLotHBatchIdC).Visible = False          '表面処理ﾊﾞｯﾁID
                .Cols(mlngvsfLotHReserveC).Visible = False          '表面処理予約
                
        '@↓2019/06/06 (Thu) 12:09:48 Y.Yoneyama **************************************************
                '@装置候補の表示切替
                Call chgWpDetailDisp(mblnWpDetailDisp)
        '@↑2019/06/06 (Thu) 12:09:48 Y.Yoneyama **************************************************
                
                '@基板工程
                If pstrSBID = CPstrSBID1A0 Then
                    .Cols(mlngvsfLotInspectFlagC).Visible = False   '無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ
                    .Cols(mlngvsfLotPairCarrierC).Visible = False   '蒸着ﾍﾟｱ
                End If
        '@↑2019/05/16 (Thu) 17:11:24 Y.Yoneyama **************************************************

                '@ﾀｲﾄﾙの色、表示位置、高さ設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbYellow")
                newStyle.ForeColor = Color.Yellow
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
                Dim cellRange As CellRange = .GetCellRange(CMlngGridTitleCol, CMlngGridTitleCol, CMlngGridTitleCol, .Cols.Count - 1)
                cellRange.Style = newStyle
                .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

                .Rows(CMlngGridTitleCol).Height = CMlngGridTitleHeight

                'マージ
                '蒸着ペア
                .AllowMerging = AllowMergingEnum.Free                     '1：隣接ｾﾙ単位のﾏｰｼﾞ
                .Cols(mlngvsfLotPairCarrierC).AllowMerging = True
                .Cols(mlngvsfLotHReserveC).AllowMerging = True
            End With


            '@★ 選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐 ★
            Select Case mlngDispConditionIndex

                '@〓 0：全て 〓
                Case 0

                    '@製品ﾛｯﾄの表示条件に"ALL"をｾｯﾄ
                    lstrDispCondition = CPstrUseIDALL

                '@〓 1：製品ﾛｯﾄ、試作/実験品ﾛｯﾄ 〓
                Case 1

                    '@製品ﾛｯﾄの表示条件に"PRODUCT, TEG"をｾｯﾄ
                    lstrDispCondition = CPstrUseIDProduct & CPstrComma & CPstrUseIDTeg

                '@〓 2：ﾓﾆﾀﾛｯﾄ 〓
                Case 2

                    '@製品ﾛｯﾄの表示条件に"MONITOR"をｾｯﾄ
                    lstrDispCondition = CPstrUseIDMonitor

                '@〓 3：ﾀﾞﾐｰﾛｯﾄ 〓
                Case 3

                    '@製品ﾛｯﾄの表示条件に"FILLER, DUMMY"をｾｯﾄ
                    lstrDispCondition = CPstrUseIDFiller & CPstrComma & CPstrUseIDDummy

            End Select


            '@-----------------------
            '@ 取得した製品ﾛｯﾄ情報の表示
            '@-----------------------
            vsfProduct.Redraw = False            'ﾊﾞｯﾌｧ経由で描画

            For llngCnt = 0 To mtypMcGpLotInfo.lngMcGpLotListCnt - 1

                '@表示条件がALL、または上記で設定した表示条件含まれるか
                If lstrDispCondition = CPstrUseIDALL Or _
                    InStr(1, lstrDispCondition, UCase(mtypMcGpLotInfo.typMcGpLotList(llngCnt).strUseId)) <> 0 Then

                    '@-----------------------
                    '@ ALL、含まれる場合は表示する
                    '@-----------------------

                    '@行数の設定
                    vsfProduct.Rows.Count = vsfProduct.Rows.Count + 1

                    '@ﾃﾞｰﾀ表示行の格納
                    llngDispRow = vsfProduct.Rows.Count - 1


                    With mtypMcGpLotInfo.typMcGpLotList(llngCnt)

                        '@ForeColor色設定
                        Dim newStyle As CellStyle = vsfProduct.Styles.Add("CustomStyle_ForeColor_CMlngEnableTrueForeColor_J" + llngDispRow.ToString)
                        newStyle.ForeColor = ColorTranslator.FromWin32(CMlngEnableTrueForeColor)
                        newStyle.BackColor = Color.White
                        Dim cellRange As CellRange = vsfProduct.GetCellRange(llngDispRow, CMlngGridTitleCol, llngDispRow, vsfProduct.Cols.Count - 1)
                        cellRange.Style = newStyle     '黒色

                        '@№の設定
                        vsfProduct.SetData(llngDispRow, CMlngvsfLotNoC, llngDispRow)                        'No

                        '@装置№の設定
                        For llngCnt2 = 0 To .lngMcGpLotWpListCnt - 1

                            With .typMcGpLotWpList(llngCnt2)

                                '@検索ﾌﾗｸﾞの初期化
                                lblnFindFlag = False

                                '@装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄWPﾘｽﾄの検索
                                For llngCnt3 = 0 To mlngWpListCnt - 1

                                    If .strWpID = mtypWpList(llngCnt3).strWpID Then

                                        '@検索ﾌﾗｸﾞの有設定
                                        lblnFindFlag = True
                                        Exit For
                                    End If
                                Next llngCnt3

                                '@検索ﾌﾗｸﾞ判定(WPID有の場合は設定)
                                If lblnFindFlag = True Then

                                    '@★ 装置ﾘｽﾄにより処理分岐 ★
                                    Select Case mtypMcGpLotInfo.typMcGpLotList(llngCnt).lngMcGpLotWpListCnt

                                        '@〓 1件の場合 〓
                                        Case 1

                                            '@1件の場合は確定(◎)を設定する
                                            vsfProduct.SetData(llngDispRow, llngCnt3 + 1, CMstrKakutei)      '装置№

                                        '@〓 2件の場合 〓
                                        Case Is >= 2

                                            '@2件の場合は候補(△)を設定する
                                            vsfProduct.SetData(llngDispRow, llngCnt3 + 1, CMstrKouho)        '装置№

                                    End Select
                                End If
                            End With
                        Next llngCnt2

                        '@装置№以降の設定
                        vsfProduct.SetData(llngDispRow, mlngvsfLotCarrierIdC, .strCarrierId)          'ｷｬﾘｱID
                        vsfProduct.SetData(llngDispRow, mlngvsfLotLotIdC, .strLotID)                  'ﾛｯﾄID
                        vsfProduct.SetData(llngDispRow, mlngvsfLotFlowClassC, .strFlowClass)          '種別
                        vsfProduct.SetData(llngDispRow, mlngvsfLotUseIDC, UCase(.strUseId))           '製品区分
                        vsfProduct.SetData(llngDispRow, mlngvsfLotPriorityC, .strLotPriority)         '優先順位
                        vsfProduct.SetData(llngDispRow, mlngvsfLotWfNumC, .strWFQuantity)             'WF枚数
                        vsfProduct.SetData(llngDispRow, mlngvsfLotRecipeIdC, .strRecipeId)            'ﾚｼﾋﾟ

                        '@時間制約有無の表示
                        If mtypMcGpLotInfo.typMcGpLotList(llngCnt).strLimitTime <> vbNullString Then

                            '@時間制約がﾌﾟﾗｽの場合
                            If CLng(mtypMcGpLotInfo.typMcGpLotList(llngCnt).strLimitTime) >= 0 Then

                                '@制限時間以下の場合
                                If mtypMcGpLotInfo.typMcGpLotList(llngCnt).strRestrictTypeID = CPstrRestrictTypeID1 Then

                                    '@ﾌｫｰﾏｯﾄ変換(##,##0)
                                    lstrLimitTime = Format$(CInt(mtypMcGpLotInfo.typMcGpLotList(llngCnt).strLimitTime), CPstrDateFormatKanma)

                                    '@制限時間先大工程+制限時間先小工程+制限時間+「以内」
                                    '@制限時間を時間と分で分割表示する
                                    lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)
                                    vsfProduct.SetData(llngDispRow, mlngvsfLotLimitTimeC, _
                                        mtypMcGpLotInfo.typMcGpLotList(llngCnt).strToOpId & CPstrSpace & _
                                        mtypMcGpLotInfo.typMcGpLotList(llngCnt).strToStepId & CPstrMade & _
                                        lstrLimitTimeAns & CPstrinai)

                                    '@左寄せ
                                    vsfProduct.Cols(mlngvsfLotLimitTimeC).TextAlign = TextAlignEnum.LeftCenter

                                    '@警告時間が設定されている場合
                                    If mtypMcGpLotInfo.typMcGpLotList(llngCnt).strWarnTime <> vbNullString Then

                                        '@時間制限が警告時間を過ぎている,且つ制限時間がｵｰﾊﾞｰしていない場合
                                        If CLng(mtypMcGpLotInfo.typMcGpLotList(llngCnt).strWarnTime) < 0 And _
                                            CLng(mtypMcGpLotInfo.typMcGpLotList(llngCnt).strLimitTime) >= 0 Then

                                            '@ﾌｫﾝﾄｶﾗｰを紫に変更
                                            Dim newStyle2 As CellStyle = vsfProduct.Styles.Add("CustomStyle_ForeColor_CPlngVbColorPurple_K" + llngDispRow.ToString)
                                            newStyle2.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple)
                                            newStyle2.BackColor = Color.White
                                            Dim cellRange2 As CellRange = vsfProduct.GetCellRange(llngDispRow, mlngvsfLotLimitTimeC, llngDispRow, mlngvsfLotLimitTimeC)
                                            cellRange2.Style = newStyle2       '紫色
                                        Else
                                            '@ﾌｫﾝﾄｶﾗｰを黒に変更
                                            Dim newStyle2 As CellStyle = vsfProduct.Styles.Add("CustomStyle_ForeColor_vbBlack_L" + llngDispRow.ToString)
                                            newStyle2.ForeColor = Color.Black
                                            newStyle2.BackColor = Color.White
                                            Dim cellRange2 As CellRange = vsfProduct.GetCellRange(llngDispRow, mlngvsfLotLimitTimeC, llngDispRow, mlngvsfLotLimitTimeC)
                                            cellRange2.Style = newStyle2       '黒
                                        End If
                                    End If
                                End If
                            Else
                                '@制限時間がﾏｲﾅｽの場合

                                '@左寄せ
                                vsfProduct.Cols(mlngvsfLotLimitTimeC).TextAlign = TextAlignEnum.CenterCenter

                                '@ForColorの変更
                                Dim newStyle2 As CellStyle = vsfProduct.Styles.Add("CustomStyle_ForeColor_CPlngVbColorRed_M" + llngDispRow.ToString)
                                newStyle2.ForeColor = Color.Red
                                newStyle2.BackColor = Color.White
                                Dim cellRange2 As CellRange = vsfProduct.GetCellRange(llngDispRow, mlngvsfLotLimitTimeC, llngDispRow, mlngvsfLotLimitTimeC)
                                cellRange2.Style = newStyle2                   '赤色

                                '@制限時間以下の場合
                                If mtypMcGpLotInfo.typMcGpLotList(llngCnt).strRestrictTypeID = CPstrRestrictTypeID1 Then

                                    '@ﾌｫｰﾏｯﾄ変換(##,##0)
                                    lstrLimitTime = Format$(CInt(mtypMcGpLotInfo.typMcGpLotList(llngCnt).strLimitTime), CPstrDateFormatKanma)

                                    '@制限時間先大工程+制限時間先小工程+制限時間+「以内」
                                    '@制限時間を時間と分で分割表示する
                                    lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)
                                    vsfProduct.SetData(llngDispRow, mlngvsfLotLimitTimeC, _
                                        mtypMcGpLotInfo.typMcGpLotList(llngCnt).strToOpId & CPstrSpace & _
                                        mtypMcGpLotInfo.typMcGpLotList(llngCnt).strToStepId & CPstrMade & _
                                        lstrLimitTimeAns & CPstrinai)
                                End If

                                '@制限時間以上の場合
                                If mtypMcGpLotInfo.typMcGpLotList(llngCnt).strRestrictTypeID = CPstrRestrictTypeID2 Then

                                    '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,##0)+"分"
                                    lstrLimitTime = Replace(Format$(CInt(mtypMcGpLotInfo.typMcGpLotList(llngCnt).strLimitTime), CPstrDateFormatKanma), CPstrReplaceMinus, vbNullString)

                                    '@制限時間先大工程+制限時間先小工程+制限時間+「以上」
                                    '@制限時間を時間と分で分割表示する
                                    lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)
                                    vsfProduct.SetData(llngDispRow, mlngvsfLotLimitTimeC, _
                                        mtypMcGpLotInfo.typMcGpLotList(llngCnt).strToOpId & CPstrSpace & _
                                        mtypMcGpLotInfo.typMcGpLotList(llngCnt).strToStepId & CPstrMade & _
                                        lstrLimitTimeAns & CPstrijyou)

                                End If
                            End If
                        End If

                        vsfProduct.SetData(llngDispRow, mlngvsfLotOptionTextC, .strOptionText)        '作業条件
                        vsfProduct.SetData(llngDispRow, mlngvsfLotOpIdC, .strOpID)                    '大工程
                        vsfProduct.SetData(llngDispRow, mlngvsfLotStepIdC, .strStepID)                '小工程
                        If .strDispatchStartTime <> vbNullString Then
                            vsfProduct.SetData(llngDispRow, mlngvsfLotDispatchStartC, _
                            Format$(CDate(.strDispatchStartTime), CPstrDateFormatMDHM))               '処理開始予定
                        End If
                        vsfProduct.SetData(llngDispRow, mlngvsfLotLastUpdateC, .strLotLastUpdate)     '最終更新日


                        '@起動SBが組立か
                        If pstrSBID = CPstrSBID2A0 Then

                            '@WFが1枚か(WFが0枚のﾛｯﾄはﾛｯﾄｱｳﾄしているので無視)
                            If .lngMcGpLotWFListCnt = 1 Then

                                '@WFﾘｽﾄが1件の場合は、取得情報をそのまま表示
                                vsfProduct.SetData(llngDispRow, mlngvsfLotWfIdC, .typMcGpLotWFList(0).strWfId)        'WFID
                                vsfProduct.SetData(llngDispRow, mlngvsfLotJigIDC, .typMcGpLotWFList(0).strjigId)      '冶具ID
                            Else
                                '@複数枚WFがある場合

                                For llngCnt4 = 0 To .typMcGpLotWFList.Count - 1

                                    '@1枚目か
                                    If llngCnt4 = 0 Then

                                        '@1枚目の場合は、取得情報をそのまま格納
                                        vsfProduct.SetData(llngDispRow, mlngvsfLotWfIdC, .typMcGpLotWFList(llngCnt4).strWfId)     'WFID
                                        vsfProduct.SetData(llngDispRow, mlngvsfLotJigIDC, .typMcGpLotWFList(llngCnt4).strjigId)   '冶具ID
                                    Else

                                        '@2枚目以降は",(ｶﾝﾏ)"区切りで格納
                                        vsfProduct.SetData(llngDispRow, mlngvsfLotWfIdC, _
                                            vsfProduct.GetData(llngDispRow, mlngvsfLotWfIdC) & CPstrComma & .typMcGpLotWFList(llngCnt4).strWfId)        'WFID

                                        vsfProduct.SetData(llngDispRow, mlngvsfLotJigIDC, _
                                            vsfProduct.GetData(llngDispRow, mlngvsfLotJigIDC) & CPstrComma & .typMcGpLotWFList(llngCnt4).strjigId)      '冶具ID
                                    End If
                                Next llngCnt4
                            End If
                        Else
                            '@起動SBが組立以外

                            '@WFID/冶具IDはNULLをｾｯﾄしておく
                            vsfProduct.SetData(llngDispRow, mlngvsfLotWfIdC, vbNullString)            'WFID
                            vsfProduct.SetData(llngDispRow, mlngvsfLotJigIDC, vbNullString)           '冶具ID
                        End If


                        '@★ CFﾌﾗｸﾞにより処理分岐 ★
                        Select Case .strCfFlag

                            '@〓 0 or NULL：TFT基板ﾛｯﾄ(CFﾛｯﾄandTPALﾛｯﾄ以外) 〓
                            Case CPstrZero, vbNullString

                                '@Cfﾌﾗｸﾞに"0：TFT"をｾｯﾄ
                                vsfProduct.SetData(llngDispRow, mlngvsfLotLotKindC, CPstrZero)
                                
                            '@〓 1：CFﾛｯﾄ(小板、大板) 〓
                            Case CPstrOne

                                '@※参考***********************************
                                '@ ①CFﾛｯﾄ  ：CF_FLAG=1,LP_FLAG=0
                                '@ ②TPALﾛｯﾄ：CF_FLAG=2,LP_FLAG=0
                                '@ ③ODFﾛｯﾄ ：CF_FLAG=1,LP_FLAG=1
                                '@※参考***********************************

                                '@Cfﾌﾗｸﾞに"1：CF"をｾｯﾄ
                                vsfProduct.SetData(llngDispRow, mlngvsfLotLotKindC, CPstrOne)



                            '@〓 2：TPALﾛｯﾄ 〓
                            Case CPstrTwo

                                '@処理なし

                        End Select
                        
        '@↓2019/05/15 (Wed) 16:53:12 Y.Yoneyama **************************************************
                        '@CFﾛｯﾄ
                        If vsfProduct.GetData(llngDispRow, mlngvsfLotLotKindC) = CPstrOne Then
                            Dim newStyle2 As CellStyle = vsfProduct.Styles.Add("CustomStyle_BackColor_CPlngCfColor" + llngDispRow.ToString)
                            newStyle2.BackColor = ColorTranslator.FromWin32(CPlngCfColor)
                            Dim cellRange2 As CellRange = vsfProduct.GetCellRange(llngDispRow, mlngvsfLotLotIdC)
                            cellRange2.Style = newStyle2
                        '@CFﾛｯﾄ以外
                        Else
                            Dim newStyle2 As CellStyle = vsfProduct.Styles.Add("CustomStyle_BackColor_CPlngTftColor" + llngDispRow.ToString)
                            newStyle2.BackColor = ColorTranslator.FromWin32(CPlngTftColor)
                            Dim cellRange2 As CellRange = vsfProduct.GetCellRange(llngDispRow, mlngvsfLotLotIdC)
                            cellRange2.Style = newStyle2
                        End If
        '@↑2019/05/15 (Wed) 16:53:12 Y.Yoneyama **************************************************
                        
                        '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDにNULLをｾｯﾄ
                        vsfProduct.SetData(llngDispRow, mlngvsfLotUldCarrierIdC, .strUnlCarrierID)
                        
                        '@大板(Lp)ﾌﾗｸﾞ
                        vsfProduct.SetData(llngDispRow, mlngvsfLotLpFlagC, .strLpFlag)

        '@↓2019/05/16 (Thu) 17:12:50 Y.Yoneyama **************************************************
                        '@無機ﾌﾗｸﾞ
                        vsfProduct.SetData(llngDispRow, mlngvsfLotVaFlagC, .strVaFlag)
                                
                        '@機種
                        vsfProduct.SetData(llngDispRow, mlngvsfLotPdIdC, .strPdId)
                                
                        '@蒸着ﾊﾞｯﾁID
                        vsfProduct.SetData(llngDispRow, mlngvsfLotJBatchIdC, .strJBatchId)
                                
                        '@表面処理ﾊﾞｯﾁID
                        vsfProduct.SetData(llngDispRow, mlngvsfLotHBatchIdC, .strHBatchId)
                        
                        '@無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ判定
                        '@ｵﾝﾗｲﾝ未
                        If .strInspectFlag <> CPstrFlagOn Then
                            vsfProduct.SetData(llngDispRow, mlngvsfLotInspectFlagC, CMstrNoOnline)
                            Dim newStyle2 As CellStyle = vsfProduct.Styles.Add("CustomStyle_BackColor_CPlngInspectNg" + llngDispRow.ToString)
                            newStyle2.BackColor = ColorTranslator.FromWin32(CPlngInspectNg)
                            Dim cellRange2 As CellRange = vsfProduct.GetCellRange(llngDispRow, mlngvsfLotInspectFlagC)
                            cellRange2.Style = newStyle2

                        Else
                            vsfProduct.SetData(llngDispRow, mlngvsfLotInspectFlagC, vbNullString)
                            Dim newStyle2 As CellStyle = vsfProduct.Styles.Add("CustomStyle_BackColor_CPlngEnableTrueColor" + llngDispRow.ToString)
                            newStyle2.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                            Dim cellRange2 As CellRange = vsfProduct.GetCellRange(llngDispRow, mlngvsfLotInspectFlagC)
                            cellRange2.Style = newStyle2
                        End If
                        
                        '@蒸着ﾍﾟｱ
                        vsfProduct.SetData(llngDispRow, mlngvsfLotPairCarrierC, Replace(.strPairCarrier, "/", vbCrLf))
                        If vsfProduct.GetData(llngDispRow, mlngvsfLotPairCarrierC) <> vbNullString Then
                            Dim newStyle2 As CellStyle = vsfProduct.Styles.Add("CustomStyle_BackColor_CPlngBatchPair" + llngDispRow.ToString)
                            newStyle2.BackColor = ColorTranslator.FromWin32(CPlngBatchPair)
                            Dim cellRange2 As CellRange = vsfProduct.GetCellRange(llngDispRow, mlngvsfLotPairCarrierC)
                            cellRange2.Style = newStyle2
                        Else
                            Dim newStyle2 As CellStyle = vsfProduct.Styles.Add("CustomStyle_BackColor_CPlngEnableTrueColor" + llngDispRow.ToString)
                            newStyle2.BackColor = ColorTranslator.FromWin32(CPlngEnableTrueColor)
                            Dim cellRange2 As CellRange = vsfProduct.GetCellRange(llngDispRow, mlngvsfLotPairCarrierC)
                            cellRange2.Style = newStyle2
                        End If
        '@↑2019/05/16 (Thu) 17:12:50 Y.Yoneyama **************************************************

                        '@高さ設定
                        vsfProduct.Rows(llngDispRow).Height = CMlngGridRowHeight

                        '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧から同一ﾛｯﾄを検索
                        For llngCnt5 = 1 To vsfBat.Rows.Count - 1

                            '@表示ﾛｯﾄとﾊﾞｯﾁ組予定ﾛｯﾄが同じか
                            If vsfProduct.GetData(llngDispRow, mlngvsfLotLotIdC) = _
                                vsfBat.GetData(llngCnt5, CMlngvsfBatLotIdC) Then

                                '@製品一覧ｸﾞﾘｯﾄﾞの該当行ForeColerを灰色に変更する
                                Dim newStyle2 As CellStyle
                                Dim cellRange2 As CellRange
                                Dim llngCnt6 As Integer
                                For llngCnt6 = mlngvsfLotNoC To mlngvsfLotLastUpdateC
                                   newStyle2 = vsfProduct.Styles.Add("CustomStyle_ForeColor_CMlngEnableFalseForeColor_N" + llngDispRow.ToString + llngCnt6.ToString)
                                   newStyle2.ForeColor = ColorTranslator.FromWin32(CMlngEnableFalseForeColor)
                                   newStyle2.BackColor = vsfProduct.GetCellRange(llngDispRow, llngCnt6).StyleDisplay.BackColor
                                   cellRange2 = vsfProduct.GetCellRange(llngDispRow, llngCnt6)
                                   cellRange2.Style = newStyle2
                                Next
                                Exit For
                            End If
                        Next llngCnt5

                    End With
                End If

            Next llngCnt


            '@ﾃﾞｰﾀが1件以上の場合
            If vsfProduct.Rows.Count > 1 Then

                '@表示位置の設定
                With vsfProduct

                    .Cols(mlngvsfLotNoC).TextAlign = TextAlignEnum.RightCenter                'No

                    For llngCnt = mlngvsfLotWpStartNoC To mlngvsfLotWpEndNoC
                        .Cols(llngCnt).TextAlign = TextAlignEnum.LeftCenter                   '装置№
                    Next llngCnt

                    .Cols(mlngvsfLotCarrierIdC).TextAlign = TextAlignEnum.LeftCenter          'ｷｬﾘｱID
                    .Cols(mlngvsfLotLotIdC).TextAlign = TextAlignEnum.LeftCenter              'ﾛｯﾄID
                    .Cols(mlngvsfLotFlowClassC).TextAlign = TextAlignEnum.LeftCenter          '種別
                    .Cols(mlngvsfLotUseIDC).TextAlign = TextAlignEnum.LeftCenter              '製品区分
                    .Cols(mlngvsfLotPriorityC).TextAlign = TextAlignEnum.RightCenter          '優先順位
                    .Cols(mlngvsfLotWfNumC).TextAlign = TextAlignEnum.RightCenter             'WF枚数
                    .Cols(mlngvsfLotRecipeIdC).TextAlign = TextAlignEnum.LeftCenter           'ﾚｼﾋﾟ
                    .Cols(mlngvsfLotLimitTimeC).TextAlign = TextAlignEnum.LeftCenter          '時間制限
                    .Cols(mlngvsfLotOptionTextC).TextAlign = TextAlignEnum.LeftCenter         '作業条件
                    .Cols(mlngvsfLotOpIdC).TextAlign = TextAlignEnum.LeftCenter               '大工程
                    .Cols(mlngvsfLotStepIdC).TextAlign = TextAlignEnum.LeftCenter             '小工程
                    .Cols(mlngvsfLotDispatchStartC).TextAlign = TextAlignEnum.LeftCenter      '処理開始予定
                    .Cols(mlngvsfLotLastUpdateC).TextAlign = TextAlignEnum.LeftCenter         '最終更新日
                    .Cols(mlngvsfLotWfIdC).TextAlign = TextAlignEnum.LeftCenter               'WFID
                    .Cols(mlngvsfLotJigIDC).TextAlign = TextAlignEnum.LeftCenter              '冶具ID
                    .Cols(mlngvsfLotLotKindC).TextAlign = TextAlignEnum.LeftCenter            'Cfﾌﾗｸﾞ(0：TFT、1：CF)
                    .Cols(mlngvsfLotUldCarrierIdC).TextAlign = TextAlignEnum.LeftCenter       'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                    .Cols(mlngvsfLotLpFlagC).TextAlign = TextAlignEnum.LeftCenter             '大板(Lp)ﾌﾗｸﾞ
                    .Cols(mlngvsfLotVaFlagC).TextAlign = TextAlignEnum.LeftCenter             '無機ﾌﾗｸﾞ
                    .Cols(mlngvsfLotPdIdC).TextAlign = TextAlignEnum.LeftCenter               '機種
                    .Cols(mlngvsfLotJBatchIdC).TextAlign = TextAlignEnum.LeftCenter           '蒸着ﾊﾞｯﾁID
                    .Cols(mlngvsfLotHBatchIdC).TextAlign = TextAlignEnum.LeftCenter           '表面処理ﾊﾞｯﾁID
                    .Cols(mlngvsfLotInspectFlagC).TextAlign = TextAlignEnum.LeftCenter        '無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ
                    .Cols(mlngvsfLotPairCarrierC).TextAlign = TextAlignEnum.LeftCenter        '蒸着ﾍﾟｱ
                    .Cols(mlngvsfLotHReserveC).TextAlign = TextAlignEnum.LeftCenter           '表面処理予約
                End With
            End If

            '@列幅の自動調整
            resizevsfProduct()

            '@固定列の設定
            If mlngWpListCnt <= CMlngGridMaxWpCnt Then

                vsfProduct.Cols.Frozen = mlngvsfLotCarrierIdC + 1
            Else
                '@装置数が14個以上の場合は固定列なし
                vsfProduct.Cols.Frozen = 0
            End If

            '@ﾏｳｽよる列ｻｲｽﾞ変更の可／不可設定
            vsfProduct.AllowResizing = AllowResizingEnum.Columns

            vsfProduct.Redraw = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvVsfProduct_Disp"         'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfBatList_Disp
    '機　能：ﾊﾞｯﾁ編成一覧ｸﾞﾘｯﾄﾞの表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 09:15:58 T.Kitagawa
    '更新日：2009/12/02 (Wed) 13:22:44 N.Kojima
    '備　考：
    '　　　：2009/06/04 (Thu) 17:09:05 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/12/02 (Wed) 13:22:44 N.Kojima     蒸着処理条件、蒸着処理条件制限ﾌﾗｸﾞ列追加に伴い処理追加。(案件№03790)
    Private Sub prvVsfBatList_Disp()

        Dim lblnFindFlag        As Boolean      '検索ﾌﾗｸﾞ(True:有、False:無)
        Dim llngCnt             As Integer      'ｶｳﾝﾀ(汎用)
        Dim llngCnt2            As Integer      'ｶｳﾝﾀ(汎用)
        Dim llngWfTotalCnt      As Integer      'WF枚数合計

        Dim llngLotTotalCnt     As Integer      'LOT数合計
        Dim lstrTempLot         As String = ""  ’LOT数計算用も文字列格納用

        Try

            '@ﾊﾞｯﾁ編成一覧ｸﾞﾘｯﾄﾞのﾀｲﾄﾙ可変列設定
            mlngvsfBatListNoC = CMlngvsfBatListNoC                                                  'No
            mlngvsfBatListWpStartNoC = CMlngvsfBatListWpNoC                                         '開始装置№
            mlngvsfBatListWpEndNoC = CMlngvsfBatListWpNoC + mlngWpListCnt - 1                       '終了装置№
            mlngvsfBatListBatchIdC = CMlngvsfBatListBatchIdC + mlngWpListCnt - 1                    'ﾊﾞｯﾁID
            mlngvsfBatListWfNumC = CMlngvsfBatListWfNumC + mlngWpListCnt - 1                        'WF枚数
            mlngvsfBatListRecipeIdC = CMlngvsfBatListRecipeIdC + mlngWpListCnt - 1                  'ﾚｼﾋﾟID
            mlngvsfBatListVaConditionIdC = CMlngvsfBatListVaConditionIdC + mlngWpListCnt - 1        '蒸着処理条件
            mlngvsfBatListVaConditionFlagC = CMlngvsfBatListVaConditionFlagC + mlngWpListCnt - 1    '蒸着処理条件制限ﾌﾗｸﾞ(0：無効、1：有効)
            mlngvsfBatListLotNumC = CMlngvsfBatListLotNumC + mlngWpListCnt - 1                      '編成ﾛｯﾄ数

            '@ﾊﾞｯﾁ編成一覧ｸﾞﾘｯﾄﾞのﾀｲﾄﾙ(列)設定
            With vsfBatList

                '@初期設定
                RemoveHandler vsfBatList.BeforeRowColChange,AddressOf vsfBatList_BeforeRowColChange
                RemoveHandler vsfBatList.EnterCell,AddressOf vsfBatList_EnterCell
                .Row = -1
                .Rows.Count = 1
                AddHandler vsfBatList.EnterCell,AddressOf vsfBatList_EnterCell
                AddHandler vsfBatList.BeforeRowColChange,AddressOf vsfBatList_BeforeRowColChange

                '@列数設定
                .Cols.Count = .Cols.Count + mlngWpListCnt - 1

                '@ﾀｲﾄﾙの文字設定
                .SetData(CMlngGridTitleCol, mlngvsfBatListNoC, CMstrvsfBatListNoT)                '№

                For llngCnt = mlngvsfBatListWpStartNoC To mlngvsfBatListWpEndNoC
                    .SetData(CMlngGridTitleCol, llngCnt, Trim$(str$(llngCnt)))                    '装置№
                Next llngCnt

                .SetData(CMlngGridTitleCol, mlngvsfBatListBatchIdC, CMstrvsfBatListBatchIdT)      'ﾊﾞｯﾁID
                .SetData(CMlngGridTitleCol, mlngvsfBatListWfNumC, CMstrvsfBatListWfNumT)          'WF枚数
                .SetData(CMlngGridTitleCol, mlngvsfBatListRecipeIdC, CMstrvsfBatListRecipeIdT)    'ﾚｼﾋﾟ
                .SetData(CMlngGridTitleCol, mlngvsfBatListVaConditionIdC, CMstrvsfBatListVaConditionIdT)      '蒸着処理条件
                .SetData(CMlngGridTitleCol, mlngvsfBatListVaConditionFlagC, CMstrvsfBatListVaConditionFlagT)  '蒸着処理条件制限ﾌﾗｸﾞ(0：無効、1：有効)
                .SetData(CMlngGridTitleCol, mlngvsfBatListLotNumC, CMstrvsfBatListLotNumT)        '編成ﾛｯﾄ数

                '@ﾀｲﾄﾙの色、表示位置、高さ設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_vbYellow")
                newStyle.ForeColor = Color.Yellow
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
                Dim cellRange As CellRange = .GetCellRange(CMlngGridTitleCol, CMlngGridTitleCol, CMlngGridTitleCol, .Cols.Count - 1)
                cellRange.Style = newStyle
                
                .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

                .Rows(CMlngGridTitleCol).Height = CMlngGridTitleHeight
            End With


            '@-----------------------
            '@ ﾊﾞｯﾁ編成一覧ｸﾞﾘｯﾄﾞの表示
            '@-----------------------
            vsfBatList.Redraw = False          'ﾊﾞｯﾌｧ経由で描画

            For llngCnt = 1 To mtypBatLotList.lngBatLotCnt

                '@行数の設定
                vsfBatList.Rows.Count = mtypBatLotList.lngBatLotCnt + 1

                With mtypBatLotList.typBatLot(llngCnt - 1)

                    '@№の設定
                    vsfBatList.SetData(llngCnt, CMlngvsfBatListNoC, llngCnt)          'No

                    '@装置№の設定
                    lblnFindFlag = False        '検索ﾌﾗｸﾞの初期化

                    '@装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄWPﾘｽﾄの検索
                    For llngCnt2 = 0 To mlngWpListCnt - 1

                        If .strWpID = mtypWpList(llngCnt2).strWpID Then

                            '@検索ﾌﾗｸﾞの有設定
                            lblnFindFlag = True
                            Exit For
                        End If
                    Next llngCnt2

                    '@検索ﾌﾗｸﾞ判定(WPID有の場合は設定)
                    If lblnFindFlag = True Then

                        '@確定(◎)を設定する
                        vsfBatList.SetData(llngCnt, llngCnt2 + 1, CMstrKakutei)       '装置№
                    End If

                    '@装置№以降の設定
                    vsfBatList.SetData(llngCnt, mlngvsfBatListBatchIdC, .strBatchId)  'ﾊﾞｯﾁID

                    '@WF枚数は同一ﾊﾞｯﾁID内の全ﾛｯﾄWF数を合計し、取得する
                    llngWfTotalCnt = 0
                    llngLotTotalCnt = 0

                    For llngCnt2 = 0 To .lngBatLotListCnt - 1
                        With .typBatList(llngCnt2)
                            If IsNumeric(.strWFQuantity) = True Then
                                '@WF枚数の加算
                                llngWfTotalCnt = llngWfTotalCnt + CLng(.strWFQuantity)
                            End If
                        End With
                        
                        'LOTIDがある場合(LOT数算出用)
                        If .typBatList(llngCnt2).strLotID <> vbNullString Then                   
                            'temp文字列が空
                            If lstrTempLot = vbNullString Then
                                lstrTempLot = lstrTempLot + .typBatList(llngCnt2).strLotID
                                llngLotTotalCnt = 1
                            Else
                                'LOTIDが文字列に無い場合
                                If lstrTempLot.IndexOf(.typBatList(llngCnt2).strLotID) = -1 then
                                    lstrTempLot = lstrTempLot + .typBatList(llngCnt2).strLotID
                                    llngLotTotalCnt = llngLotTotalCnt + 1
                                End If
                            End If
                        End if

                        'ロットが処理中以上の場合は背景を濃いグレー
                        If vsfBatList.GetCellRange(llngCnt, CMlngvsfBatListNoC).StyleDisplay.BackColor <> ColorTranslator.FromWin32(CPlngGridDarkGray) And _
                            IsNumeric(.typBatList(llngCnt2).strCurrentStatusID) = True Then

                            'CurrentStatus:2(処理中)
                            If CLng(.typBatList(llngCnt2).strCurrentStatusID) >= 2 Then
                                Dim newStyle2 As CellStyle = vsfBatList.Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                                newStyle2.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                                Dim cellRange2 As CellRange = vsfBatList.GetCellRange(llngCnt, CMlngvsfBatListNoC, llngCnt, vsfBatList.Cols.Count - 1)
                                cellRange2.Style = newStyle2
                            End If
                        End If

                    Next llngCnt2

                    vsfBatList.SetData(llngCnt, mlngvsfBatListWfNumC, llngWfTotalCnt)         'WF枚数(合計枚数)
                    vsfBatList.SetData(llngCnt, mlngvsfBatListRecipeIdC, .strRecipeId)        'ﾚｼﾋﾟ
                    vsfBatList.SetData(llngCnt, mlngvsfBatListVaConditionIdC, .strVaConditionID)      '蒸着処理条件
                    vsfBatList.SetData(llngCnt, mlngvsfBatListVaConditionFlagC, .strVaConditionFlag)  '蒸着処理条件制限ﾌﾗｸﾞ(0：無効、1：有効)
                    'vsfBatList.SetData(llngCnt, mlngvsfBatListLotNumC, .lngBatLotListCnt)     '編成ﾛｯﾄ数
                    vsfBatList.SetData(llngCnt, mlngvsfBatListLotNumC, llngLotTotalCnt)     '編成ﾛｯﾄ数

                    '@高さ設定
                    vsfBatList.Rows(llngCnt).Height = CMlngGridRowHeight

                End With
            Next llngCnt

            '@ﾃﾞｰﾀが1件以上の場合
            If vsfBatList.Rows.Count > 1 Then

                '@表示位置の設定
                With vsfBatList

                    .Cols(mlngvsfBatListNoC).TextAlign = TextAlignEnum.RightCenter             'No

                    For llngCnt = mlngvsfBatListWpStartNoC To mlngvsfBatListWpEndNoC
                        .Cols(llngCnt).TextAlign = TextAlignEnum.LeftCenter                    '装置№
                    Next llngCnt

                    .Cols(mlngvsfBatListBatchIdC).TextAlign =TextAlignEnum.LeftCenter          'ﾊﾞｯﾁID
                    .Cols(mlngvsfBatListWfNumC).TextAlign = TextAlignEnum.RightCenter          'WF枚数
                    .Cols(mlngvsfBatListRecipeIdC).TextAlign = TextAlignEnum.LeftCenter        'ﾚｼﾋﾟ
                    .Cols(mlngvsfBatListVaConditionIdC).TextAlign = TextAlignEnum.LeftCenter   '蒸着処理条件
                    .Cols(mlngvsfBatListVaConditionFlagC).TextAlign = TextAlignEnum.LeftCenter '蒸着処理条件制限ﾌﾗｸﾞ(0：無効、1：有効)
                    .Cols(mlngvsfBatListLotNumC).TextAlign = TextAlignEnum.RightCenter         '編成ﾛｯﾄ数
                End With
            End If

            '@表示後の各種設定
            With vsfBatList

                '@列幅の自動調整
                For llngCnt = CMlngGridTitleCol To .Cols.Count - 1
                    .AutoSizeCol(llngCnt, 6)
                Next llngCnt

                '@固定列の設定
                If mlngWpListCnt <= CMlngGridMaxWpCnt Then

                    .Cols.Frozen = mlngvsfBatListBatchIdC + 1
                Else
                    '@装置数が14個以上の場合は固定列なし
                    .Cols.Frozen = 0
                End If

                '@非表示列の設定
                .Cols(mlngvsfBatListVaConditionIdC).Visible = False         '蒸着処理条件
                .Cols(mlngvsfBatListVaConditionFlagC).Visible = False       '蒸着処理条件制限ﾌﾗｸﾞ(0：無効、1：有効)

            End With

            vsfBatList.LeftCol = 0
            vsfBatList.Redraw = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvVsfBatList_Disp"         'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvBatLotWFCnt_Cal
    '機　能：ﾊﾞｯﾁ組WF枚数再計算処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/06/04 (Thu) 17:10:34 N.Kojima
    '更新日：2009/06/04 (Thu) 17:10:34
    '備　考：
    Private Sub prvBatLotWFCnt_Cal()

        Dim llngCnt     As Integer      'ｶｳﾝﾀ(汎用)

        Try

            '@******************************************************************************
            '@★当Functionの処理概要
            '@　■ﾊﾞｯﾁ組WF枚数の再計算
            '@******************************************************************************

            With vsfBat

                '@ﾊﾞｯﾁ組WF数の初期化
                lblBatLotWFCnt.Text = CPstrZero

                For llngCnt = 1 To .Rows.Count - 1

                    '@WF枚数がNULL以外か
                    If .GetData(llngCnt, CMlngvsfBatWFNumC) <> vbNullString Then

                        '@ﾊﾞｯﾁ組WF枚数を計算して表示
                        lblBatLotWFCnt.Text = CStr(CLng(lblBatLotWFCnt.Text) + _
                                                CLng(.GetData(llngCnt, CMlngvsfBatWFNumC)))
                    End If
                Next llngCnt

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvBatLotWFCnt_Cal"         'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnMasVaConditionSel_Proc
    '機　能：蒸着処理条件取得処理
    '引　数：lstrCallName   ：呼び元処理
    '戻り値：True：処理成功、False：処理失敗
    '作成日：2009/06/04 (Thu) 17:10:34 N.Kojima
    '更新日：2019/06/24 (Mon) 16:31:48 T.Oide
    '備　考：
    '　　　：2009/12/02 (Wed) 16:24:48 N.Kojima     [有効/無効]ﾗﾍﾞﾙへの取得内容表示処理を追加。(案件№03790)
    '　　　：2010/07/05 (Mon) 11:56:54 T.Oide       No.04123対応(斜方蒸着ﾚｼﾋﾟ自動選択)
    Private Function prvblnMasVaConditionSel_Proc(Optional ByVal lstrCallName As String = vbNullString) As Boolean

        Dim lblnAns                 As Boolean              '汎用戻り値結果取得(True:正常,False:異常)
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        Dim lstrRecipeID            As String               'ﾚｼﾋﾟID退避用
        Dim lstrWpId                As String               '装置ID退避用

        Try

            '@******************************************************************************
            '@★当Functionの処理概要
            '@　■ 蒸着処理条件取得
            '@　■ ﾊﾞｯﾁ組予定ﾛｯﾄｸﾞﾘｯﾄﾞへ取得情報を格納
            '@　■ 蒸着処理条件ﾗﾍﾞﾙ、有効/無効ﾗﾍﾞﾙへ取得情報表示
            '@******************************************************************************

            '@-----------------------
            '@ 蒸着処理条件取得
            '@ ※初回ﾛｯﾄの1回だけ通信を行う
            '@ 　⇒ﾏｽﾀﾃﾞｰﾀなので何回も取得しても意味がない。
            '@-----------------------

            '@戻り値の初期化
            prvblnMasVaConditionSel_Proc = False


            '@★ 呼び元の処理により処理分岐 ★
            Select Case lstrCallName

                '@〓 ">"ﾎﾞﾀﾝ押下処理からのCall 〓
                Case CMstrCmdMoveClick

                    With vsfProduct

                        '@製品ﾛｯﾄ一覧のﾃﾞｰﾀ行が選択されているか
                        If .Row > 0 Then

                            '@ﾚｼﾋﾟIDを格納する
                            lstrRecipeID = .GetData(.Row, mlngvsfLotRecipeIdC)
                        End If
                    End With


                '@〓 装置名ｺﾝﾎﾞ変更時処理からのCall 〓
                Case CMstrCmbWpNameChange

                    With vsfBatList

                        '@ﾊﾞｯﾁ編成一覧のﾃﾞｰﾀ行が選択されているか
                        If .Row > 0 Then

                            '@ﾚｼﾋﾟIDを格納する
                            lstrRecipeID = .GetData(.Row, mlngvsfBatListRecipeIdC)
                        End If
                    End With

            End Select


            '@ﾚｼﾋﾟIDが格納出来たか
            '@ ※製品ﾛｯﾄも選択されていない、ﾊﾞｯﾁ編成一覧にも蒸着ﾊﾞｯﾁ組情報が存在しない場合は処理抜け
            If lstrRecipeID = vbNullString Then
                Exit Function
            End If

            '@装置名ｺﾝﾎﾞの値取得列を「装置ID」列に変更
            cmbWpName.ValueCol = CMlngCmbWpNameId

            lstrWpId = cmbWpName.Value                      '装置ID

            '@装置名ｺﾝﾎﾞの値取得列を「装置名」列に戻す
            cmbWpName.ValueCol = CMlngCmbGridColName


            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvblnMasVaConditionSelProc)

            '@=======================
            '@ 蒸着処理条件ﾃｰﾌﾞﾙ(VA_CODITION(ﾏｽﾀ))から蒸着処理条件を取得する
            '@=======================
            lblnAns = pubblnMasVaCondition_Sel(CMstrmas_vaconditionVer, _
                                               pstrSBID, _
                                               lstrRecipeID, _
                                               lstrWpId, _
                                               mtypVaConditionListAns)


            '@通信結果判定
            If lblnAns = False Then

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvblnMasVaConditionSelProc)
                Exit Function
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrPrvblnMasVaConditionSelProc)

            With vsfBat

                For llngCnt = 1 To .Rows.Count - 1

        '@↓2019/06/24 (Mon) 16:31:29 T.Oide **************************************************
        '@            '@ｸﾞﾘｯﾄﾞの"順(処理部)"と蒸着処理条件の"順(処理部)"が同じか
        '@            If .Cell(flexcpText, llngCnt, CMlngvsfBatSeqNumC) = _
        '@                mtypVaConditionListAns.typVaConditionList(llngCnt).strSeqNum Then
        '@
        '@                '@Cfﾌﾗｸﾞ(0：TFT、1：CF)をｾｯﾄ
        '@                .Cell(flexcpText, llngCnt, CMlngvsfBatPanelKindC) = _
        '@                    mtypVaConditionListAns.typVaConditionList(llngCnt).strPanelKind
        '@            End If
        '@↑2019/06/24 (Mon) 16:31:29 T.Oide **************************************************

                    '@蒸着処理条件をｾｯﾄ
                    .SetData(llngCnt, CMlngvsfBatVaConditionIDC, _
                        mtypVaConditionListAns.typVaConditionList(llngCnt - 1).strVaConditionID)

                Next llngCnt
            End With

            '@蒸着処理条件を表示する
            lblVaCondition.Text = _
                mtypVaConditionListAns.typVaConditionList(0).strVaConditionID

            '@蒸着処理条件制限ﾌﾗｸﾞが"0：無効"か
            If mtypVaConditionListAns.typVaConditionList(0).strVaConditionFlag = CPstrZero Then

                '@(蒸着処理条件)有効/無効に"無効"をｾｯﾄ
                lblVaConditionFlag.Text = CMstrInValid
            Else
                '@蒸着処理条件制限ﾌﾗｸﾞがNULL、"1：有効"の場合

                '@(蒸着処理条件)有効/無効に"有効"をｾｯﾄ
                lblVaConditionFlag.Text = CMstrValid
            End If


            '@戻り値に"True：処理成功"をｾｯﾄ
            prvblnMasVaConditionSel_Proc = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "prvblnMasVaConditionSel_Proc"   'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnJBatchSet_Chk
    '機　能：蒸着ﾊﾞｯﾁ組時ﾁｪｯｸ処理
    '引　数：llngBatWFCnt   ：ﾊﾞｯﾁ組予定ﾛｯﾄのWF枚数
    '戻り値：True：正常、False：ｴﾗｰあり
    '作成日：2009/06/04 (Thu) 17:10:34 N.Kojima
    '更新日：2012/03/05 (Mon) 16:31:59 T.Oide
    '備　考：
    '　　　：2010/07/05 (Mon) 11:56:54 T.Oide       No.04123対応(斜方蒸着ﾚｼﾋﾟ自動選択)
    '　　　：2012/03/05 (Mon) 16:31:59 T.Oide       無機装置追加対応(REQ-1303)
    Private Function prvblnJBatchSet_Chk(ByVal llngBatWFCnt As Integer) As Boolean

        Dim llngCnt                 As Integer      'ｶｳﾝﾀ(汎用)
        Dim llngCnt2                As Integer      'ｶｳﾝﾀ2(汎用)
        Dim llngEmptySlotCnt        As Integer      '空き処理部数
        Dim lstrLotID               As String       'ﾛｯﾄID
        Dim lstrLotKind             As String       'Cfﾌﾗｸﾞ(0：TFT、1：CF)
        Dim lstrWFNum               As String       '製品ﾛｯﾄのWF数
        Dim llngVaSlotCnt           As Integer      '無機装置のスロット数(1号機は5、2号機は6)

        Try

            '@******************************************************************************
            '@★当Functionの処理概要
            '@　■CHECK1：製品ﾛｯﾄ一覧情報格納構造体からWF枚数を調べる
            '@　■CHECK2：冶具に紐付いていないWFがあるかを調べる
            '@　■CHECK3：ﾊﾞｯﾁ組出来る空き処理部があるか調べる
            '@******************************************************************************


            '@戻り値の初期化
            prvblnJBatchSet_Chk = False

            '@ﾛｯﾄID/WFIDを格納(長いので)
            lstrLotID = vsfProduct.GetData(vsfProduct.Row, mlngvsfLotLotIdC)
            lstrWFNum = vsfProduct.GetData(vsfProduct.Row, mlngvsfLotWfNumC)

            '@******************************************************************************
            '@■CHECK1：製品ﾛｯﾄ一覧情報格納構造体からWF枚数を調べる ■
            '@　⇒蒸着装置は5枚(#1号機)または6枚(#2号機)までしか処理出来ないので5枚を超える場合はｴﾗｰとする
            '@******************************************************************************
            cmbWpName.ValueCol = CMlngCmbWpNameMaxProcessBox
            llngVaSlotCnt = cmbWpName.Value
            cmbWpName.ValueCol = CMlngCmbWpNameName


            '@ﾊﾞｯﾁ予定ﾛｯﾄの搭載WFが装置のスロット数以上か
            If llngBatWFCnt > llngVaSlotCnt Then

                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM9PW>$$ロット[%1]はウェハが[%2]枚以上搭載されおり、
                '@           $装置の処理部数を超えている為、バッチ組出来ません。
                '@           $1ロット5枚以下にロット分割し、再度バッチ組して下さい。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009P, lstrLotID, CPstrSix)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@=======================
                '@ ﾊﾞｯﾁ組予定ﾛｯﾄﾌﾚｰﾑ内ｺﾝﾄﾛｰﾙ初期化処理
                '@=======================
                Call prvVsfBatControlClear_Proc()

                Exit Function
            End If

            
            '@ﾊﾞｯﾁ予定ﾛｯﾄの搭載WF + 既にﾊﾞｯﾁ組されているﾛｯﾄの総WFが装置のスロット数以上か
            If (CLng(lblBatLotWFCnt.Text) + llngBatWFCnt) > llngVaSlotCnt Then

                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM9QW>$$製品ロットのWF数[%1]に対し、設定可能装置処理部が不足している為、$バッチ組出来ません。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009Q, lstrWFNum)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@=======================
                '@ ﾊﾞｯﾁ組予定ﾛｯﾄﾌﾚｰﾑ内ｺﾝﾄﾛｰﾙ初期化処理
                '@=======================
                Call prvVsfBatControlClear_Proc()

                Exit Function
                
            End If


            '@******************************************************************************
            '@■CHECK2：冶具が紐付いていないWF枚数を調べる ■
            '@　⇒冶具に紐付いていないと処理出来ないのでｴﾗｰとする
            '@******************************************************************************

            For llngCnt = 0 To mtypMcGpLotInfo.lngMcGpLotListCnt - 1

                '@ﾊﾞｯﾁ組予定ﾛｯﾄの配列か
                If mtypMcGpLotInfo.typMcGpLotList(llngCnt).strLotID = lstrLotID Then

                    For llngCnt2 = 0 To mtypMcGpLotInfo.typMcGpLotList(llngCnt).lngMcGpLotWFListCnt - 1

                        '@冶具IDがNULLか
                        If mtypMcGpLotInfo.typMcGpLotList(llngCnt).typMcGpLotWFList(llngCnt2).strjigId = vbNullString Then

                            '@表示ﾒｯｾｰｼﾞ変換
                            '@"<TRM9RW>$$冶具に紐付いていないウェハが存在する為、バッチ組出来ません。$WFID[%1]"のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009R, _
                                                            mtypMcGpLotInfo.typMcGpLotList(llngCnt).typMcGpLotWFList(llngCnt2).strWfId)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            '@=======================
                            '@ ﾊﾞｯﾁ組予定ﾛｯﾄﾌﾚｰﾑ内ｺﾝﾄﾛｰﾙ初期化処理
                            '@=======================
                            Call prvVsfBatControlClear_Proc()

                            Exit Function
                        End If
                    Next llngCnt2
                End If
            Next llngCnt


            '@******************************************************************************
            '@■CHECK3：ﾊﾞｯﾁ組出来る空き処理部があるか調べる ■
            '@　⇒蒸着処理条件制限ﾌﾗｸﾞが"0：無効"以外の場合のみﾁｪｯｸする
            '@　⇒蒸着装置は各処理部にCfﾌﾗｸﾞの指定があり、もしそこが空いていない場合はｴﾗｰとする
            '@******************************************************************************
            '@蒸着処理条件ﾃﾞｰﾀが存在するか
            If mtypVaConditionListAns.lngVaConditionListCnt > 0 Then

                '@ﾊﾞｯﾁ組予定ﾛｯﾄのCfﾌﾗｸﾞを格納
                lstrLotKind = vsfProduct.GetData(vsfProduct.Row, mlngvsfLotLotKindC)

                For llngCnt = 1 To vsfBat.Rows.Count - 1

                    '@WFID列が空き状態(NULL or 未使用)か
                    If vsfBat.GetData(llngCnt, CMlngvsfBatWFIDC) = vbNullString Or _
                        InStr(1, vsfBat.GetData(llngCnt, CMlngvsfBatWFIDC), CMstrNotUse) <> 0 Then

                        '@空き処理部数をｶｳﾝﾄUP
                        llngEmptySlotCnt = llngEmptySlotCnt + 1

                        '@ﾊﾞｯﾁ組予定ﾛｯﾄのWF数と空き処理部数が一致するか
                        If llngBatWFCnt = llngEmptySlotCnt Then

                            '@ﾊﾞｯﾁ組可なのでOKと言うことでﾙｰﾌﾟ抜け
                            Exit For
                        End If
                    End If
                    

                    '@ﾊﾞｯﾁ組予定ﾛｯﾄのWF数分処理部が空いていない場合
                    If llngCnt = vsfBat.Rows.Count - 1 And _
                        llngBatWFCnt <> llngEmptySlotCnt Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM9QW>$$製品ロットのWF数[%1]に対し、設定可能装置処理部が不足している為、$バッチ組出来ません。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009Q, lstrWFNum)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@=======================
                        '@ ﾊﾞｯﾁ組予定ﾛｯﾄﾌﾚｰﾑ内ｺﾝﾄﾛｰﾙ初期化処理
                        '@=======================
                        Call prvVsfBatControlClear_Proc()

                        Exit Function
                    End If

                Next llngCnt
            End If


            '@戻り値に"True：正常"をｾｯﾄ
            prvblnJBatchSet_Chk = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnJBatchSet_Chk"        'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvVsfBatControlClear_Proc
    '機　能：ﾊﾞｯﾁ組予定ﾛｯﾄﾌﾚｰﾑ内ｺﾝﾄﾛｰﾙ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/11/18 (Wed) 12:40:05 N.Kojima
    '更新日：2009/11/18 (Wed) 12:40:05
    '備　考：
    Private Sub prvVsfBatControlClear_Proc()

        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ
        Dim lblnNoDataFlag  As Boolean      'ﾃﾞｰﾀ有無判定ﾌﾗｸﾞ(True：ﾃﾞｰﾀあり、False：ﾃﾞｰﾀなし)

        Try

            '@******************************************************************************
            '@★当Functionの処理概要
            '@　■ ﾊﾞｯﾁ組予定ﾛｯﾄ一覧に編成ﾛｯﾄ(WF)が無い場合は所定のｺﾝﾄﾛｰﾙを初期化する
            '@******************************************************************************

            '@ﾃﾞｰﾀ有無判定ﾌﾗｸﾞの初期化
            lblnNoDataFlag = False

            With vsfBat

                '@-----------------------
                '@ ﾃﾞｰﾀ有無検索
                '@-----------------------
                For llngCnt = 1 To .Rows.Count - 1

                    '@ﾛｯﾄIDがNULL以外か
                    If .GetData(llngCnt, CMlngvsfBatLotIdC) <> vbNullString Then

                        '@ﾃﾞｰﾀ有無判定ﾌﾗｸﾞに"True：ﾃﾞｰﾀあり"をｾｯﾄ
                        lblnNoDataFlag = True

                        Exit For
                    End If
                Next llngCnt

                '@ﾃﾞｰﾀ有無判定ﾌﾗｸﾞに"False：ﾃﾞｰﾀなし"か
                If lblnNoDataFlag = False Then

                    '@各種ﾗﾍﾞﾙの初期化
        '            lblBatchId.Caption = vbNullString               'ﾊﾞｯﾁID
                    lblRecipeID.Text = vbNullString              'ﾚｼﾋﾟID
                    lblVaCondition.Text = vbNullString           '蒸着処理条件
                    lblVaConditionFlag.Text = vbNullString       '(蒸着処理条件)有効/無効
                    lblBatLotWFCnt.Text = CPstrZero              'ﾊﾞｯﾁ組WF数

                    '@各種ﾎﾞﾀﾝの初期化
                    cmdUP.Enabled = False                           '"↑"
                    cmdDown.Enabled = False                         '"↓"
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "prvVsfBatControlClear_Proc"     'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnUldCarrier_Chk
    '機　能：ｱﾝﾛｰﾀﾞｷｬﾘｱﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：ﾁｪｯｸOK、False：ﾁｪｯｸNG
    '作成日：2009/06/04 (Thu) 17:10:34 N.Kojima
    '更新日：2009/06/04 (Thu) 17:10:34
    '備　考：
    Private Function prvblnUldCarrier_Chk() As Boolean

        Dim lblnAns                 As Boolean              '汎用戻り値結果取得(True:正常,False:異常)
        Dim ltypCarrCurstate        As CarrCurstate         'ｷｬﾘｱ状態確認要求構造体

        Try

            '@******************************************************************************
            '@★当Functionの処理概要
            '@　■ ｱﾝﾛｰﾀﾞｷｬﾘｱの種別/状態ﾁｪｯｸ処理(ｵｰﾌﾟﾝｷｬﾘｱ、空き、洗浄済)
            '@******************************************************************************

            '@戻り値の初期化
            prvblnUldCarrier_Chk = False

            '@ｷｬﾘｱ情報(要求)格納
            With ltypCarrCurstate

                .strCarrierId = vsfBat.GetData(vsfBat.Row, CMlngvsfBatUldCarrierIDC)   'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                .strClassDivision = CPstrCD2D           '処理区分：ｷｬﾘｱ一覧(空)
                .strMsgVer = CMstrcarrcurstateVer       'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strSbID = pstrSBID                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strCarrierTypeID = CPstrCarrTypeHotOP  'ｷｬﾘｱﾀｲﾌﾟ：耐熱ｵｰﾌﾟﾝｶｾｯﾄ
                .strLotID = vbNullString                'ﾛｯﾄID(処理区分：10=作業開始時のみ指定)
                .strOpID = vbNullString                 '大工程ID(処理区分：10=作業開始時のみ指定)
                .strStepID = vbNullString               '小工程ID(処理区分：10=作業開始時のみ指定)
                .strAltNumber = vbNullString            '代替番号(処理区分：10=作業開始時のみ指定)
            End With

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvblnUldCarrierChk)

            '@=======================
            '@ ｷｬﾘｱ状態取得
            '@=======================
            lblnAns = pubblnCarrcurstate_Sel(ltypCarrCurstate, True, vbNullString)

            '@通信結果確認
            If lblnAns = True Then
                '@通信成功の場合

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrPrvblnUldCarrierChk)
            Else
                '@通信失敗の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvblnUldCarrierChk)
                Exit Function
            End If

            '@戻り値に"True：ﾁｪｯｸOK"をｾｯﾄ
            prvblnUldCarrier_Chk = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnUldCarrier_Chk"       'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnJyufuku_Chk
    '機　能：ｱﾝﾛｰﾀﾞｷｬﾘｱID重複ﾁｪｯｸ処理
    '引　数：llngRow        ：選択行
    '　　　：lstrChkString  ：ｱﾝﾛｰﾀﾞｷｬﾘｱID
    '戻り値：True：重複あり、False：重複なし
    '作成日：2009/07/02 (Thu) 20:39:02 T.Oide
    '更新日：2009/07/24 (Fri) 10:13:48 N.Kojima
    '備　考：
    '　　　：2009/07/24 (Fri) 10:13:48 N.Kojima     無機対応Phase2、ｿｰｽ整備。(案件№03661)
    Private Function prvblnJyufuku_Chk(ByVal llngRow As Integer, _
                                       ByVal lstrChkString As String) As Boolean

        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ

        Try

            '@******************************************************************************
            '@★当Functionの処理概要
            '@　■ ｱﾝﾛｰﾀﾞｷｬﾘｱの重複設定ﾁｪｯｸを行う
            '@******************************************************************************

            '@戻り値の初期化
            prvblnJyufuku_Chk = False

            '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULLか
            If lstrChkString = vbNullString Then

                Exit Function
            End If

            For llngCnt = 1 To vsfBat.Rows.Count - 1

                '@各行のｱﾝﾛｰﾀﾞｷｬﾘｱと新規設定したｱﾝﾛｰﾀﾞｷｬﾘｱが同じか
                If vsfBat.GetData(llngCnt, CMlngvsfBatUldCarrierIDC) = lstrChkString Then

                    '@選択行以外か
                    If llngCnt <> llngRow Then

                        '@戻り値に"True：重複あり"をｾｯﾄ
                        prvblnJyufuku_Chk = True
                        Exit For
                    End If
                End If
            Next llngCnt


            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "prvblnJyufuku_Chk"              'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnInput_Chk
    '機　能：確定時ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：全項目正常、False：不正項目あり
    '作成日：2004/07/29 (Thu) 15:29:25 T.Kitagawa
    '更新日：2010/07/05 (Mon) 13:38:49 T.Oide
    '備　考：
    '　　　：2009/06/04 (Thu) 17:10:34 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/28 (Tue) 16:55:38 N.Kojima     無機対応Phase2、WFID=ﾀﾞﾐｰの重複もﾁｪｯｸしないように修正。(案件№03661)
    '　　　：2009/08/05 (Wed) 17:15:58 N.Kojima     無機対応Phase3、表面処理ﾊﾞｯﾁ組時の制約を追加。(案件№03704)
    '　　　：2009/11/18 (Wed) 11:25:16 N.Kojima     蒸着処理条件ﾁｪｯｸにて[有効/無効]ﾗﾍﾞﾙが"有効"の場合のみﾁｪｯｸするように改善。(案件№03790)
    '　　　：2010/07/05 (Mon) 11:56:54 T.Oide       No.04123対応(斜方蒸着ﾚｼﾋﾟ自動選択)
    Private Function prvblnInput_Chk() As Boolean

        Dim llngCnt                 As Integer      'ｶｳﾝﾀ(汎用)
        Dim llngCnt2                As Integer      'ｶｳﾝﾀ2(汎用)
        Dim lstrSelectWPEqType      As String       '選択装置の装置ﾀｲﾌﾟ
        Dim lstrWFID                As String       'WFID
        Dim lblnEditBatchErrFlag    As Boolean      'ﾊﾞｯﾁ編成ｴﾗｰﾌﾗｸﾞ(True：ｴﾗｰ、False：初期値)

        Try

            '@戻り値の初期化
            prvblnInput_Chk = False

            With vsfBat

                '@★ 入力処理区分により処理分岐 ★
                Select Case mstrInputClassDivision

                    '@〓 NULL：新規 or 06：変更 〓
                    Case vbNullString, CPstrCD06

                        '@装置名が未選択の場合はｽｷｯﾌﾟ
                        If cmbWpName.Text = vbNullString Then

                            '@表示ﾒｯｾｰｼﾞ変換
                            '@"<TRM18W>$$装置名が設定されていません。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0018)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            Exit Function
                        End If

                        '@ﾛｯﾄ未選択の場合はｽｷｯﾌﾟ
                        If .Rows.Count <= 1 Then

                            '@表示ﾒｯｾｰｼﾞ変換
                            '@"<TRM0KW>$$バッチ組みされているロットIDが存在しません。設定を見直して下さい。"のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000K)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            Exit Function
                        End If

                        '@最大ﾛｯﾄ数のﾁｪｯｸ
                        If IsNumeric(lblMaxLotCnt.Text) = True Then

                            If .Rows.Count - 1 > CLng(lblMaxLotCnt.Text) Then

                                '@表示ﾒｯｾｰｼﾞ変換
                                '@"<TRM0RW>$$最大ロット数を超えています。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000R)
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                                Exit Function
                            End If
                        End If


                        '@装置名ｺﾝﾎﾞの値取得列を「装置ﾀｲﾌﾟ(EqType)」列に変更
                        cmbWpName.ValueCol = CMlngCmbWpNameEqType

                        '@選択装置の装置ﾀｲﾌﾟを格納
                        lstrSelectWPEqType = cmbWpName.Value

                        '@装置名ｺﾝﾎﾞの値取得列を「装置名」列に戻す
                        cmbWpName.ValueCol = CMlngCmbWpNameName


                        '@選択装置が"19：斜方蒸着装置"以外か
                        If lstrSelectWPEqType <> CPstrEqTypeJyoucyaku Then

                            '@-----------------------
                            '@ ﾛｯﾄIDが重複しているか
                            '@-----------------------
                            For llngCnt = 1 To .Rows.Count - 1

                                For llngCnt2 = 1 To .Rows.Count - 1

                                    '@ﾛｯﾄIDが重複しているか(同一行は除く)
                                    If llngCnt <> llngCnt2 And _
                                        .GetData(llngCnt, CMlngvsfBatLotIdC) = _
                                        .GetData(llngCnt2, CMlngvsfBatLotIdC) Then

                                        '@表示ﾒｯｾｰｼﾞ変換
                                        '@"<TRM5EW>$$ロットIDが重複しています。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005E)
                                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                                        '@不整合行にﾌｫｰｶｽｾｯﾄ
                                        .Row = llngCnt2

                                        Exit Function
                                    End If
                                Next llngCnt2
                            Next llngCnt
                        End If

                        '@起動SBが"2A0：組立"か
                        If pstrSBID = CPstrSBID2A0 Then

                            '@★ 選択装置の装置ﾀｲﾌﾟにより処理分岐 ★
                            Select Case lstrSelectWPEqType

                                '@〓 19：斜方蒸着装置 〓
                                Case CPstrEqTypeJyoucyaku

                                    For llngCnt = 1 To .Rows.Count - 1

                                        '@WFIDを格納する
                                        lstrWFID = .GetData(llngCnt, CMlngvsfBatWFIDC)

                                        '@-----------------------
                                        '@ 冶具とWFが紐付いているか
                                        '@-----------------------
                                        '@WFIDがNULL以外で冶具IDがNULLか
                                        If lstrWFID <> vbNullString And _
                                            .GetData(llngCnt, CMlngvsfBatJigIDC) = vbNullString Then

                                            '@表示ﾒｯｾｰｼﾞ変換
                                            '@"<TRM9RW>$$冶具に紐付いていないウェハが存在する為、バッチ組出来ません。$WFID[%1]"のﾒｯｾｰｼﾞ表示
                                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009R, lstrWFID)
                                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                                            '@不整合行にﾌｫｰｶｽｾｯﾄ
                                            .Row = llngCnt

                                            Exit Function
                                        End If

                                        '@-----------------------
                                        '@ WFIDが重複しているか
                                        '@-----------------------
                                        For llngCnt2 = 1 To .Rows.Count - 1

                                            '@WFIDが重複しているか
                                            If llngCnt <> llngCnt2 And _
                                                .GetData(llngCnt, CMlngvsfBatWFIDC) = _
                                                .GetData(llngCnt2, CMlngvsfBatWFIDC) Then

                                                '@WFIDのNULLの重複はﾁｪｯｸ対象外
                                                If .GetData(llngCnt, CMlngvsfBatWFIDC) <> vbNullString And _
                                                    .GetData(llngCnt2, CMlngvsfBatWFIDC) <> vbNullString Then

                                                    '@WFIDが"ﾀﾞﾐｰ"の重複もﾁｪｯｸ対象外
                                                    If .GetData(llngCnt, CMlngvsfBatWFIDC) <> CMstrDummy And _
                                                        .GetData(llngCnt2, CMlngvsfBatWFIDC) <> CMstrDummy Then

                                                        '@表示ﾒｯｾｰｼﾞ変換
                                                        '@"<TRM9WW>$$ウェハIDが重複しています。$設定を見直してください。"のﾒｯｾｰｼﾞ表示
                                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009W)
                                                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                                                        '@不整合行にﾌｫｰｶｽｾｯﾄ
                                                        .Row = llngCnt2

                                                        Exit Function
                                                    End If
                                                End If
                                            End If
                                        Next llngCnt2
                                    Next llngCnt


                                '@〓 20：表面処理装置 〓
                                Case CPstrEqTypeHyoumenSyori


                                    For llngCnt = 1 To .Rows.Count - 1

                                        '@-----------------------
                                        '@ 編成順ﾁｪｯｸ(表面処理装置)
                                        '@
                                        '@ << 仕様 >>
                                        '@ 　表面処理装置のﾊﾞｯﾁ組順は「製品ﾛｯﾄ、試作/実験品ﾛｯﾄ(PRODUCT(TEG))⇒ﾓﾆﾀﾛｯﾄ(MONITOR)⇒ﾌｨﾙﾀﾞﾐｰ(FILLER(DUMMY))⇒その他」の
                                        '@ 　順でﾊﾞｯﾁ組されていなければ装置的にﾀﾞﾒだそうです。
                                        '@ 　例)PRODUCT(TEG) Only ：OK、PRODUCT(TEG) ⇒ MONITOR：OK、PRODUCT(TEG) ⇒ FILLER(DUMMY)：OK
                                        '@ 　　 MONITOR Only ：OK、MONITOR ⇒ FILLER(DUMMY) ：OK
                                        '@ 　　 FILLER(DUMMY)  Only ：OK
                                        '@ 　　 MONITOR ⇒ PRODUCT(TEG) ：NG、FILLER(DUMMY) ⇒ PRODUCT(TEG) ：NG、FILLER(DUMMY) ⇒ MONITOR ：NG
                                        '@-----------------------

                                        '@1行目以降か(1行目は比較対象が無いので処理ｽｷｯﾌﾟ)
                                        If llngCnt <> 1 Then

                                            '@ﾊﾞｯﾁ編成ｴﾗｰﾌﾗｸﾞの初期化
                                            lblnEditBatchErrFlag = False

                                            '@★ ﾊﾞｯﾁ組予定ﾛｯﾄの製品区分により処理分岐 ★
                                            Select Case UCase(.GetData(llngCnt, CMlngvsfBatUseIDC))

                                                '@〓 PRODUCT(TEG)：製品ﾛｯﾄ、試作/実験品ﾛｯﾄ 〓
                                                Case CPstrUseIDProduct, CPstrUseIDTeg

                                                    For llngCnt2 = 1 To llngCnt

                                                        '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧の製品ﾛｯﾄ行より上に"MONITOR" or "FILLER(DUMMY)"ﾛｯﾄが存在するか
                                                        If .GetData(llngCnt2, CMlngvsfBatUseIDC) = CPstrUseIDMonitor Or _
                                                            .GetData(llngCnt2, CMlngvsfBatUseIDC) = CPstrUseIDFiller Or _
                                                            .GetData(llngCnt2, CMlngvsfBatUseIDC) = CPstrUseIDDummy Then

                                                            '@ﾊﾞｯﾁ編成ｴﾗｰﾌﾗｸﾞに"True：ｴﾗｰ"をｾｯﾄ
                                                            lblnEditBatchErrFlag = True
                                                            Exit For
                                                        End If
                                                    Next llngCnt2


                                                '@〓 MONITOR：ﾓﾆﾀﾛｯﾄ 〓
                                                Case CPstrUseIDMonitor

                                                    For llngCnt2 = 1 To llngCnt

                                                        '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧のﾓﾆﾀﾛｯﾄ行より上に"FILLER(DUMMY)"ﾛｯﾄが存在するか
                                                        If .GetData(llngCnt2, CMlngvsfBatUseIDC) = CPstrUseIDFiller Or _
                                                            .GetData(llngCnt2, CMlngvsfBatUseIDC) = CPstrUseIDDummy Then

                                                            '@ﾊﾞｯﾁ編成ｴﾗｰﾌﾗｸﾞに"True：ｴﾗｰ"をｾｯﾄ
                                                            lblnEditBatchErrFlag = True
                                                            Exit For
                                                        End If
                                                    Next llngCnt2


                                                '@〓 FILLER(DUMMY)：ﾌｨﾙﾀﾞﾐｰﾛｯﾄ 〓
                                                Case CPstrUseIDFiller, CPstrUseIDDummy

                                                    '@ﾊﾞｯﾁ編成順の最下位なので上位の順がOKなら良い


                                                '@〓 その他 〓
                                                Case Else

                                                    '@制約なし

                                            End Select

                                            '@編成順ﾁｪｯｸでｴﾗｰがあったか
                                            If lblnEditBatchErrFlag = True Then

                                                '@表示ﾒｯｾｰｼﾞ変換
                                                '@"<TRM1SW>$$表面処理装置のバッチ組は装置仕様に従い、
                                                '@ $[製品ロット]⇒[モニタロット]⇒[フィルダミーロット]
                                                '@ $の順でバッチ組してください。"のﾒｯｾｰｼﾞ表示
                                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001S)
                                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                                                Exit Function
                                            End If
                                        End If


                                        '@-----------------------
                                        '@ ｱﾝﾛｰﾀﾞｷｬﾘｱIDが未設定か
                                        '@-----------------------
                                        If .GetData(llngCnt, CMlngvsfBatUldCarrierIDC) = vbNullString Then

                                            '@表示ﾒｯｾｰｼﾞ変換
                                            '@"<TRM01W>$$キャリアIDが設定されていません。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                                            '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDｾﾙにﾌｫｰｶｽｾｯﾄ
                                            .ShowCell(llngCnt, CMlngvsfBatUldCarrierIDC)

                                            Exit Function
                                        End If

                                        '@-----------------------
                                        '@ ｱﾝﾛｰﾀﾞｷｬﾘｱIDが重複しているか
                                        '@-----------------------
                                        For llngCnt2 = 1 To .Rows.Count - 1

                                            '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDが重複しているか
                                            If llngCnt <> llngCnt2 And _
                                                .GetData(llngCnt, CMlngvsfBatUldCarrierIDC) = _
                                                .GetData(llngCnt2, CMlngvsfBatUldCarrierIDC) Then

                                                '@表示ﾒｯｾｰｼﾞ変換
                                                '@"<TRM0CW>$$キャリアIDが重複しています。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000C)
                                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                                                '@不整合行にﾌｫｰｶｽｾｯﾄ
                                                .Row = llngCnt2

                                                Exit Function
                                            End If
                                        Next llngCnt2
                                    Next llngCnt


                                '@〓 その他 〓
                                Case Else

                                    '@処理なし

                            End Select

                        End If

                End Select

                '@★ 入力処理区分により処理分岐 ★
                Select Case mstrInputClassDivision

                    '@〓 05：削除 or 06：変更 〓
                    Case CPstrCD06, CPstrCD05

                        '@ﾊﾞｯﾁIDがNULLか
                        If lblBatchID.Text = vbNullString Then

                            '@表示ﾒｯｾｰｼﾞ変換
                            '@"<TRM0JW>$$バッチIDが存在しません。設定を見直して下さい。"のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000J)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            Exit Function
                        End If

                End Select

            End With

            '@戻り値に"True：全項目正常"をｾｯﾄ
            prvblnInput_Chk = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnInput_Chk"          'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvsubDataSet
    '機　能：ﾊﾞｯﾁ組みﾃﾞｰﾀを構造体にｾｯﾄする
    '引　数：ltypBatChange：ﾃﾞｰﾀ格納構造体
    '　　　：lstrWfI：WF_ID
    '戻り値：なし
    '作成日：2012/03/08 (Thu) 17:07:36 T.Oide
    '更新日：2012/04/09 (Mon) 08:41:24 T.Oide
    '備　考：
    Private Sub prvsubDataSet(ByRef ltypBatChange As BatChange, _
                              ByRef lstrWFID As String, _
                              ByRef llngCnt As Integer, _
                              ByRef llngNoUseCnt As Integer)

        Try
            
            With ltypBatChange
                
                '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧の件数をｶｳﾝﾄｱｯﾌﾟ
                .lngBatChangeLotListCnt = .lngBatChangeLotListCnt + 1
                If .typBatChangeLotList Is Nothing Then
                    .typBatChangeLotList = New List(Of BatChangeLotList)
                End If
            
                '@ﾊﾞｯﾁ組予定ﾛｯﾄ一覧ﾘｽﾄ構造体の格納
                Dim typBatChangeLotListtmp = New BatChangeLotList
            
                With typBatChangeLotListtmp

                    '@無機斜方蒸着、無機表面処理 以外か
                    If ltypBatChange.strEqType <> CPstrEqTypeJyoucyaku And _
                       ltypBatChange.strEqType <> CPstrEqTypeHyoumenSyori Then
                        '@無機斜方蒸着、無機表面処理 以外の場合
                        .strSeqNum = vsfBat.GetData(llngCnt, CMlngvsfBatSeqNumC)           '順序
                    Else
                        '@無機斜方蒸着、無機表面処理 の場合
                        .strSeqNum = ltypBatChange.lngBatChangeLotListCnt                           '順序
                    End If
                    
                    .strCarrierId = vsfBat.GetData(llngCnt, CMlngvsfBatCarrierIdC)         'ｷｬﾘｱID
                    .strjigId = vsfBat.GetData(llngCnt, CMlngvsfBatJigIDC)                 '冶具ID
                    .strLotID = vsfBat.GetData(llngCnt, CMlngvsfBatLotIdC)                 'ﾛｯﾄID
                    .strLotLastUpdate = vsfBat.GetData(llngCnt, CMlngvsfBatLastUpdateC)    '最終更新日
                    .strUldCarrierID = vsfBat.GetData(llngCnt, CMlngvsfBatUldCarrierIDC)   'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                    '@ｳｪﾊｰIDは空か
                    If lstrWFID = vbNullString Then
                        .strWfId = vsfBat.GetData(llngCnt, CMlngvsfBatWFIDC)               'WFID
                    Else
                        .strWfId = lstrWFID                                                         'WFID
                    End If
                    .strPanelKind = vsfBat.GetData(llngCnt, CMlngvsfBatPanelKindC)         'Cfﾌﾗｸﾞ
                    .strVaConditionID = vsfBat.GetData(llngCnt, CMlngvsfBatVaConditionIDC) '蒸着処理条件
            
                    '@ﾛｯﾄID・冶具・WFIDがNULL、または未使用か
                    If (.strLotID = vbNullString And _
                        .strjigId = vbNullString And _
                        .strWfId = vbNullString) Or _
                        (.strLotID = vbNullString And _
                        InStr(1, .strjigId, CMstrNotUse) <> 0 And _
                        InStr(1, .strWfId, CMstrNotUse) <> 0) Then
            
                        '@DBがNOT NULL設定の為、"未使用N"をｾｯﾄ
                        .strjigId = CMstrNotUse & CStr(llngNoUseCnt)                    '冶具ID
                        .strWfId = CMstrNotUse & CStr(llngNoUseCnt)                     'WFID
                        ltypBatChange.strRecipeId = CMstrNotUse                         'ﾚｼﾋﾟID
            
                        '@未使用ｶｳﾝﾀを+1する
                        llngNoUseCnt = llngNoUseCnt + 1
                    End If
                
                End With
                .typBatChangeLotList.Add(typBatChangeLotListtmp)
                
            End With
                                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvsubDataSet"              'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：chgWpDetailDisp
    '機　能：候補装置の表示切替
    '引　数：llbnDisp：true(表示)、false(非表示)
    '戻り値：なし
    '作成日：2019/05/30 (Thu) 16:01:09 Y.Yoneyama
    '更新日：2019/05/30 (Thu) 16:01:09 Y.Yoneyama
    '備　考：
    Private Sub chgWpDetailDisp(ByVal llbnDisp As Boolean)
        
        Dim llngCnt As Integer
        
        Try

            '@装置ﾘｽﾄが無い場合
            If mlngWpListCnt = 0 Then
                Exit Sub
            End If
                
            '@***********************
            '@ 表示/非表示切替
            '@***********************
            With vsfProduct
                For llngCnt = 1 To mlngWpListCnt
                    '@引数とのﾌﾗｸﾞは反転なので注意
                    .Cols(llngCnt).Visible = llbnDisp
                Next
                
                '@ﾘﾌﾚｯｼｭする
                '.Refresh
            End With

            '@***********************
            '@ 表示/非表示切替
            '@***********************
            With vsfBatList
                
                For llngCnt = 1 To mlngWpListCnt
                    .Cols(llngCnt).Visible = llbnDisp
                Next
                
                '@ﾘﾌﾚｯｼｭする
                '.Refresh
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "chgWpDetailDisp"                '処理名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraBat.Paint, fraBatList.Paint, fraProduct.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfProduct.BeforeDoubleClick

        ' ObjectをGridに変換
        Dim gridObj As C1FlexGrid
        Dim llngCnt  As Integer
        Dim lstData  As Boolean

        gridObj = CType(sender, C1FlexGrid)

        Dim colindex As Integer 'ダブルクリックした列番号

        'ダブルクリックした箇所が列の境界線かを判断する
        If gridObj.HitTest(e.X,e.Y).Type = HitTestTypeEnum.ColumnResize Then

            '列の境界線の場合、本来の処理をキャンセル
            e.Cancel = True

            'ダブルクリックした列番号を格納
            colindex = gridObj.HitTest(e.X,e.Y).Column

            'サイズを自動調整
            If colindex > 0 And colindex <= mlngWpListCnt Then
                lstData = False
                For llngCnt = 1 TO gridObj.Rows.Count - 1
                    If gridObj.GetData(llngCnt, colindex) <> vbNullString Then
                        lstData = True
                        Exit For
                    End If
                Next
                '空白でない場合
                If lstData = True Then
                    gridObj.AutoSizeCol(colindex, 4)                '装置名
                Else
                    gridObj.AutoSizeCol(colindex, -4)               '装置名
                End If
            Else
                Select colindex
                    Case mlngvsfLotNoC


                        If gridObj.Rows.Count > 99 Then
                            gridObj.AutoSizeCol(colindex, 4)        'No
                        Else
                            gridObj.AutoSizeCol(colindex, 0)        'No
                        End If
                    Case mlngvsfLotCarrierIdC
                        gridObj.AutoSizeCol(colindex,0)             'ｷｬﾘｱID
                    Case mlngvsfLotPairCarrierC
                        gridObj.AutoSizeCol(colindex,2)             '蒸着ﾍﾟｱ
                    Case mlngvsfLotInspectFlagC
                        gridObj.AutoSizeCol(colindex,-2)            '無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ
                    Case mlngvsfLotFlowClassC
                        gridObj.AutoSizeCol(colindex,-2)            '種別
                    Case mlngvsfLotPriorityC
                        gridObj.AutoSizeCol(colindex,-4)            '優先順位
                    Case mlngvsfLotWfNumC
                        gridObj.AutoSizeCol(colindex,-2)            'WF
                    Case mlngvsfLotLimitTimeC
                        gridObj.AutoSizeCol(colindex,0)             '時間制限
                    Case mlngvsfLotOptionTextC
                        gridObj.AutoSizeCol(colindex,0)             '作業条件
                    Case Else
                        gridObj.AutoSizeCol(colindex,6)
                End Select
            End If
        End If

    End Sub


    '関数名：flexGrid_KeyDownEdit
    '機　能：←→キーの取り扱い
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/01/28 (Mon) 10:00:00 NSYS
    '更新日：2019/04/05 (Fri) 12:00:00 NSYS
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfBat.KeyDownEdit

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

    '関数名 resizevsfProduct
    '機　能：自動列幅調整
    '引　数：なし
    '戻り値：なし
    '作成日：2020/01/31 (Fri) 17:00:00 NSYS
    '備　考：
    Private Sub resizevsfProduct()
        Dim llngCnt  As Integer
        Dim llngCnt2 As Integer
        Dim lstData  As Boolean

        With vsfProduct
            If (.Rows.Count > 1) Then
                For llngCnt = CMlngGridTitleCol To .Cols.Count - 1
                    .AutoSizeCol(llngCnt, 6)
                Next llngCnt
                For llngCnt = 1 To mlngWpListCnt
                    lstData = False
                    For llngCnt2 = 1 TO .Rows.Count - 1
                        If .GetData(llngCnt2, llngCnt) <> vbNullString Then
                            lstData = True
                            Exit For
                        End If
                    Next
                    '空白でない場合
                    If lstData = True Then
                        .AutoSizeCol(llngCnt, 4)          '装置名
                    Else
                        .AutoSizeCol(llngCnt, -4)         '装置名
                    End If
                Next
                If .Rows.Count > 99 Then
                    .AutoSizeCol(mlngvsfLotNoC, 4)        'No
                Else
                    .AutoSizeCol(mlngvsfLotNoC, 0)        'No
                End If
                .AutoSizeCol(mlngvsfLotCarrierIdC, 0)     'ｷｬﾘｱID
                .AutoSizeCol(mlngvsfLotPairCarrierC, 2)   '蒸着ﾍﾟｱ
                .AutoSizeCol(mlngvsfLotInspectFlagC, -2)  '無機異物検査ｵﾝﾗｲﾝ処理ﾌﾗｸﾞ
                .AutoSizeCol(mlngvsfLotFlowClassC, -2)    '種別
                .AutoSizeCol(mlngvsfLotPriorityC, -4)     '優先順位
                .AutoSizeCol(mlngvsfLotWfNumC, -2)        'WF
                .AutoSizeCol(mlngvsfLotLimitTimeC, 0)     '時間制限
                .AutoSizeCol(mlngvsfLotOptionTextC, 0)    '作業条件
            Else
                .AutoSizeCols(CMlngvsfLotNoC, .Cols.Count - 1, 0)
            End If
        End With
    End Sub

    ''' <summary>
    ''' 表面処理装置のチェック
    ''' </summary>
    Private Function prvblnHyoumenSyoriChek() As Boolean

        Try
            Dim lintCnt As Integer
            Dim llngAns As Integer
            Dim ltypHyoumenReserveGroup As List(Of typHyoumenReserveGroup)
            Dim lblnAns As Boolean

            prvblnHyoumenSyoriChek = False

            With vsfBat
                '******************************
                '異物検査S1=×の場合は警告文を出す
                '******************************
                Dim lstrLots As String = vbNullString
                For lintCnt = 1 To .Rows.Count - 1
                    '異物検査S1=×
                    If vsfBat.GetData(lintCnt, CMlngvsfBatInspectFlagC) = CMstrNoOnline Then
                        'PR/ES/WS/ZZ/SY
                        If .GetData(lintCnt, CMlngvsfBatFlowClassC) = CPstrFlowClassPR Or _
                           .GetData(lintCnt, CMlngvsfBatFlowClassC) = CPstrFlowClassES Or _
                           .GetData(lintCnt, CMlngvsfBatFlowClassC) = CPstrFlowClassWS Or _
                           .GetData(lintCnt, CMlngvsfBatFlowClassC) = CPstrFlowClassZZ Or _
                           .GetData(lintCnt, CMlngvsfBatFlowClassC) = CPstrFlowClassSY Then
                            
                            If lstrLots = vbNullString Then
                                lstrLots = .GetData(lintCnt, CMlngvsfBatLotIdC)
                            Else
                                '新規LotIdの場合
                                If lstrLots.IndexOf(.GetData(lintCnt, CMlngvsfBatLotIdC)) = -1 Then
                                    lstrLots = lstrLots + "/" + .GetData(lintCnt, CMlngvsfBatLotIdC)
                                End If
                            End If
                        End If
                    End If
                Next

                '対象LOTがある場合
                If lstrLots <> vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    '"<TRM173W>$$ロット[%1]は、$搭載スロットの確認が必要です。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0173, lstrLots)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                End If


                '******************************
                '表面処理バッチ予約の確認
                '******************************
                Dim lstrProductLotId As String = vbNullString
                For lintCnt = 1 To .Rows.Count - 1
                    'PR/ES/WS/ZZ/SY
                    If .GetData(lintCnt, CMlngvsfBatFlowClassC) = CPstrFlowClassPR Or _
                       .GetData(lintCnt, CMlngvsfBatFlowClassC) = CPstrFlowClassES Or _
                       .GetData(lintCnt, CMlngvsfBatFlowClassC) = CPstrFlowClassWS Or _
                       .GetData(lintCnt, CMlngvsfBatFlowClassC) = CPstrFlowClassZZ Or _
                       .GetData(lintCnt, CMlngvsfBatFlowClassC) = CPstrFlowClassSY Then

                        '表面処理バッチ予約検索用の代表ロットを決める
                        'WFIDがダミー以外
                        If vsfBat.GetData(lintCnt, CMlngvsfBatWFIDC) <> CMstrDummy And lstrProductLotId = vbNullString Then
                            
                            lstrProductLotId = vsfBat.GetData(lintCnt, CMlngvsfBatLotIdC)
                            Exit For
                        End If
                    End If
                Next

                '検索用の製品ロットがある場合
                If lstrProductLotId <> vbNullString Then

                    Dim lstrMessageBoxStr As String = "表面処理バッチ予約情報"

                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(CMstrFormName, "prvblnHyoumenSyoriChek")

                    ltypHyoumenReserveGroup = New List(Of typHyoumenReserveGroup)
                    '引数(WFID)
                    lblnAns = pubblnHReserveGroup_Sel(CPstrasm_hreservegroupVer, lstrProductLotId, ltypHyoumenReserveGroup)

                    '@結果確認
                    If lblnAns = False Then
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, "prvblnHyoumenSyoriChek")

                        '"<TRM174W>$$[%1]チェックでエラーしました、$処理を継続しましすか?"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0174, lstrMessageBoxStr)
                        llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                        '「いいえ」選択
                        If llngAns = vbNo Then
                            Exit Function
                        Else
                            'ユーザー判断で処理継続なので、この後のチェックはしない
                            prvblnHyoumenSyoriChek = True
                            Exit Function
                        End If
                    End If

                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, "prvblnHyoumenSyoriChek")

                    '予約WFがない場合
                    If ltypHyoumenReserveGroup.Count = 0 Then
                        '"<TRM175W>$$[%1]がありませんでした、$処理を継続しましすか?"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0175, lstrMessageBoxStr)
                        llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                        '「いいえ」選択
                        If llngAns = vbNo Then
                            Exit Function
                        Else
                            'ユーザー判断で処理継続なので、この後のチェックはしない
                            prvblnHyoumenSyoriChek = True
                            Exit Function
                        End If

                    '予約WFあり
                    Else
                        Dim lintProductWfCnt As Integer = 0
                        Dim lintReserveWfCnt As Integer = 0
                        'バッチ編成の内容(WF)と表面処理バッチ予約(WF)との内容をチェックする
                        For lintCnt = 1 To .Rows.Count - 1

                            'WFIDがダミー以外
                            'PR/ES/WS/ZZ/SY
                            If vsfBat.GetData(lintCnt, CMlngvsfBatWFIDC) <> CMstrDummy And _ 
                                (.GetData(lintCnt, CMlngvsfBatFlowClassC) = CPstrFlowClassPR Or _
                                .GetData(lintCnt, CMlngvsfBatFlowClassC) = CPstrFlowClassES Or _
                                .GetData(lintCnt, CMlngvsfBatFlowClassC) = CPstrFlowClassWS Or _
                                .GetData(lintCnt, CMlngvsfBatFlowClassC) = CPstrFlowClassZZ Or _
                                .GetData(lintCnt, CMlngvsfBatFlowClassC) = CPstrFlowClassSY) Then

                                'WFIDの取得
                                '表面処理の場合WFIDはカンマ区切りでつながっている
                                Dim lstrAllWf As String = vsfBat.GetData(lintCnt, CMlngvsfBatWFIDC)
                                Dim lIntTargetIndex As String = vbNullString

                                'カンマ区切りでつながった文字なので分解する
                                'NULLで終わり
                                While lstrAllWf <> vbNullString

                                    '製品WFのCountUp
                                    lintProductWfCnt = lintProductWfCnt + 1

                                    '文字列をカンマで検索
                                    lIntTargetIndex = lstrAllWf.IndexOf(",")

                                    '検索結果なし
                                    If lIntTargetIndex < 0 Then

                                        '予約情報にWFがあるか探す
                                        For Each tmp As typHyoumenReserveGroup In ltypHyoumenReserveGroup
                                            If lstrAllWf = tmp.strWfId Then
                                                '予約WFのCountUp
                                                lintReserveWfCnt = lintReserveWfCnt + 1
                                                Exit For
                                            End If
                                        Next

                                        Exit While

                                    '検索結果あり
                                    Else
                                        'WFを抜き出す
                                        Dim lstrWf As String = lstrAllWf.Substring(0, lIntTargetIndex)

                                        '予約情報にWFがあるか探す
                                        For Each tmp As typHyoumenReserveGroup In ltypHyoumenReserveGroup
                                            If lstrWf = tmp.strWfId Then
                                                '予約WFのCountUp
                                                lintReserveWfCnt = lintReserveWfCnt + 1
                                                Exit For
                                            End If
                                        Next

                                        '文字列の更新
                                        lstrAllWf = lstrAllWf.Substring(lIntTargetIndex + 1)
                                    End If
                                End While
                            End If
                        Next

                        '製品WF数と予約WF数が異なる場合
                        'lintProductWfCnt <> lintReserveWfCnt　ロット内WFに予約以外の混入を考慮
                        'ltypHyoumenReserveGroup.Count <> lintReserveWfCn　予約数との一致確認
                        if lintProductWfCnt <> lintReserveWfCnt Or _
                            ltypHyoumenReserveGroup.Count <> lintReserveWfCnt Then

                            '<TRM176W>$$[%1]と異なります。$処理を継続しましすか?"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0176, lstrMessageBoxStr)
                            llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                            '「いいえ」選択
                            If llngAns = vbNo Then
                                Exit Function
                            Else
                                'ユーザー判断で処理継続なので、この後のチェックはしない
                                prvblnHyoumenSyoriChek = True
                                Exit Function
                            End If
                        End If
                    End If
                End If
                
            End With

            prvblnHyoumenSyoriChek = True
                                
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             
                .strProcName = "prvblnHyoumenSyoriChek"      
                .strErrMessage = vbNullString               
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    ''' <summary>
    ''' 蒸着装置のチェック
    ''' CheckNGでもユーザー判断で続行は可能
    ''' </summary>
    ''' <returns></returns>
    Private Function prvblnJyoucyakuChek() As Boolean

        Try
            Dim lintCnt As Integer
            Dim lintCnt2 As Integer
            Dim lstrWfId As String = vbNullString
            Dim llngAns As Integer

            prvblnJyoucyakuChek = False

            With vsfBat
                
                '本来はODF予約情報のみで取得でいいが、ODF予約IDが異なるロットが混在することがあるので
                '全情報を取得する為、手っ取り早く表面処理予約情報の全データを取得して判断
                '表面処理予約情報の取得(ALL=全て(予約済/未))
                Dim ltypHyounenReserveInfo As New List(Of typHyoumenReserveInfo)
                If prvblnHyoumenReserveInfo("ALL", ltypHyounenReserveInfo) = False Then
                    '"<TRM174W>$$[%1]チェックでエラーしました、$処理を継続しましすか?"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0174, "蒸着")
                    llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                    '「いいえ」選択
                    If llngAns = vbNo Then
                        Exit Function
                    Else
                        'ユーザー判断で処理継続なので、この後のチェックはしない
                        prvblnJyoucyakuChek = True
                        Exit Function
                    End If
                End If

                Dim lblnAriFlag As Boolean = False
                For lintCnt = 1 To .Rows.Count - 1
                    
                    Dim lstrTargetWfId As String = vbNullString

                    'WFIDがダミー以外
                    'WFID空(蒸着ユニットが故障等で使用禁止の場合、WFIDは空なので、それは除外)2022/01/28追加
                    If vsfBat.GetData(lintCnt, CMlngvsfBatWFIDC) <> CMstrDummy And _
                        vsfBat.GetData(lintCnt, CMlngvsfBatWFIDC) <> vbNullString Then
                        lstrWfId = vsfBat.GetData(lintCnt, CMlngvsfBatWFIDC)
                        
                        'ODF貼り合せ予約情報を検索して対となるTFT/CFのWFIDを探す
                        For Each tmp As typHyoumenReserveInfo In ltypHyounenReserveInfo
                            If tmp.strWfId = lstrWfId Then
                                lstrTargetWfId = tmp.strCfWfId
                                Exit For
                            ElseIf tmp.strCfWfId = lstrWfId Then
                                lstrTargetWfId = tmp.strWfId
                                Exit For
                            End If
                        Next
                    
                        'バッチ編成のTFT/CFのWFを検索してODF貼り合せ予約情報が無い
                        If lstrTargetWfId = vbNullString Then
                            '"<TRM175W>$$[%1]がありませんでした、$処理を継続しましすか?"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0175, "ODF予約情報")
                            llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                            '「いいえ」選択
                            If llngAns = vbNo Then
                                Exit Function
                            Else
                                'ユーザー判断で処理継続なので、この後のチェックはしない
                                prvblnJyoucyakuChek = True
                                Exit Function
                            End If
                        End If

                        '対のWFをバッチ編成から検索
                        For lintCnt2 = 1 To .Rows.Count - 1
                            If lstrTargetWfId = vsfBat.GetData(lintCnt2, CMlngvsfBatWFIDC) Then
                                lblnAriFlag = True
                                Exit For
                            End If
                            lblnAriFlag = False
                        Next

                        '対が見つからない場合
                        If lblnAriFlag = False Then
                            Exit For
                        End If
                    End If
                Next

                If lblnAriFlag = False Then
                    '<TRM176W>$$[%1]と異なります。$処理を継続しましすか?"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0176, "ODF予約情報")
                    llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                    '「いいえ」選択
                    If llngAns = vbNo Then
                        Exit Function
                    Else
                        'ユーザー判断で処理継続なので、この後のチェックはしない
                        prvblnJyoucyakuChek = True
                        Exit Function
                    End If
                End If     
            End With
                             
            prvblnJyoucyakuChek = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             
                .strProcName = "prvblnJyoucyakuChek"      
                .strErrMessage = vbNullString               
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    ''' <summary>
    ''' 表面処理予約情報の取得
    ''' </summary>
    ''' <param name="ltypHyounenReserveInfo"></param>
    ''' <returns></returns>
    Private Function prvblnHyoumenReserveInfo(ByVal lstrOpt As String, ByRef ltypHyounenReserveInfo As List(Of typHyoumenReserveInfo)) As Boolean
        
        Dim lblnAns As Boolean
        
        Try
            prvblnHyoumenReserveInfo = False
            
            'レスポンス開始
            Call pubResponseStart(Me.Name, "prvblnHyoumenReserveInfo")
            
            '表面処理予約情報の取得
            lblnAns = pubblnHReserveInfo_Sel(CPstrasm_hreserveinfoVer, lstrOpt, ltypHyounenReserveInfo)
            
            '結果NG
            If lblnAns = False Then
                'レスポンス中止
                Call pubResponseCancel(Me.Name, "prvblnHyoumenReserveInfo")                
                Exit Function   
            End If

            'レスポンス終了
            Call publngResponseEnd(Me.Name, "prvblnHyoumenReserveInfo")

            prvblnHyoumenReserveInfo = True

            Exit Function
            
        Catch ex As Exception
            
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey      
                .strProcName = "prvblnHyoumenReserveInfo" 
                .strErrMessage = ""                    
            End With

            Call pubOnError_Proc()

        End Try
    End Function

    ''' <summary>
    ''' 表面処理予約の表示
    ''' </summary>
    Private Sub prvHReserveDisp()
        Try
            With vsfProduct

                '組立工程専用
                If pstrSBID <> CPstrSBID2A0 Then
                    Exit Sub
                End If

                '表面処理の専用表示を隠す
                .Cols(mlngvsfLotPairCarrierC).Visible = False     '蒸着ペア
                .Cols(mlngvsfLotInspectFlagC).Visible = False     '異物S1
                .Cols(mlngvsfLotHReserveC).Visible = False        '表面処理予約

                '[>>]一括移動ボタン
                cmdMoveAll.Visible = False

                '表面処理の場合(装置グループに表面の文字がある場合のみ対応)
                Dim lIntTargetIndex As Integer = cmbMcGpName.Text.IndexOf("表面")
                '検索文字列が無い場合
                If lIntTargetIndex = -1 Then
                    Exit Sub
                End If

                '表面処理の専用表示を表示
                .Cols(mlngvsfLotPairCarrierC).Visible = True      '蒸着ペア
                .Cols(mlngvsfLotInspectFlagC).Visible = True      '異物S1
                .Cols(mlngvsfLotHReserveC).Visible = True         '表面処理予約

                '[>>]一括移動ボタン
                cmdMoveAll.Visible = True
                cmdMoveAll.Enabled = False

                '表面処理予約情報の取得(DONE=予約済)
                Dim ltypHyounenReserveInfo As New List(Of typHyoumenReserveInfo)
                If prvblnHyoumenReserveInfo("DONE", ltypHyounenReserveInfo) = False Then
                    Exit Sub
                End If

                '表示
                Dim lintRow As Integer
                For lintRow = 1 To .Rows.Count - 1
                    '表面処理予約が無い場合
                    If .GetData(lintRow, mlngvsfLotHReserveC) = vbNullString Then
                        Dim lstrWfId = .GetData(lintRow, mlngvsfLotWfIdC)

                        '表面処理予約情報からWFIDがあるか検索
                        For Each tmp As typHyoumenReserveInfo In ltypHyounenReserveInfo
                            'TFT側での検索
                            lIntTargetIndex = lstrWfId.IndexOf(tmp.strWfId)
                            If lIntTargetIndex >= 0 Then
                                .SetData(lintRow, mlngvsfLotHReserveC, tmp.strHReserveTime)
                                Exit For
                            End If

                            'CF側での検索
                            lIntTargetIndex = lstrWfId.IndexOf(tmp.strCfWfId)
                            If lIntTargetIndex >= 0 Then
                                .SetData(lintRow, mlngvsfLotHReserveC, tmp.strHReserveTime)
                                Exit For
                            End If
                        Next          
                    End If
                Next
            End With

        Exit Sub

        Catch ex As Exception
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             
                .strProcName = "prvHReserveDisp"      
                .strErrMessage = vbNullString               
            End With

            Call pubOnError_Proc()
        End Try
    End Sub

End Class
