'ﾌｧｲﾙ名：xxEN0150.frm
'説　明：装置別ロット一覧　メインフォーム
'作成日：2004/04/13 (Tue) 14:16:34 M.Matsuura
'更新日：2025/04/18 (Fri) 16:34:52 T.Oide
'備　考：★★★　ｶﾗﾑ追加があった場合(特にｶﾗﾑ挿入)はCM0060.basに影響が出るので注意！！　★★★
'Copyright(C) SEIKO EPSON CORPORATION 2003-2025, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN0150
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN0150    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN0150
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN0150
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN0150)
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
    'Private Const CMstrLocalVersion                     As String = "19.03"
    Private Const CMstrLocalVersion                     As String = "19.04"
    '@↑2025/04/18 (Fri) 16:34:52 T.Oide **************************************************

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrlot_list____Ver                  As String = "12.01"                 'ﾛｯﾄ一覧
    Private Const CMstreq__state___Ver                  As String = "03.00"                 '装置状態取得
    Private Const CMstrmas_McGrouplistVer               As String = "01.00"                 '装置ｸﾞﾙｰﾌﾟ取得
    Private Const CMstreq__areacurlistVer               As String = "02.00"                 'ｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置用途情報取得
    Private Const CMstrutilregtminfoVer                 As String = "06.00"                 '端末設定情報登録
    Private Const CMstrutilreftminfoVer                 As String = "04.00"                 '端末設定情報取得
    Private Const CMstrlot_chgctlwpVer                  As String = "03.00"                 '処理順号機設定解除
    Private Const CMstrcarrmanuoutportVer               As String = "01.00"                 'ｷｬﾘｱ手動出庫要求
    Private Const CMstrmas_stockerlistVer               As String = "01.00"                 'ｽﾄｯｶｰﾏｽﾀ取得
    Private Const CMstrdumy_carout__Ver                 As String = "01.00"                 'ﾀﾞﾐｰｷｬﾘｱ払出

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN0150          'ﾛｰｶﾙ機能ID

    '@vsfAreaEquipmentの定数宣言(幅)
    Private Const CMlngvsfAreaEqColWNo                  As Integer = 37                        '№
    Private Const CMlngvsfAreaEqColWKb                  As Integer = 15                        '保/停区分
    Private Const CMlngvsfAreaEqColWNowSt               As Integer = 87                        '状態
    Private Const CMlngvsfAreaEqColWLimitTime           As Integer = 87                        '時間制限(ﾃﾞｰﾀなし)
    Private Const CMlngvsfAreaEqColWLimitTime1A0        As Integer = 236                       '時間制限(ﾃﾞｰﾀあり)基板
    Private Const CMlngvsfAreaEqColWLimitTime2A0        As Integer = 189                       '時間制限(ﾃﾞｰﾀあり)組立
    Private Const CMlngvsfAreaEqColWCarrierID           As Integer = 65                        'ｷｬﾘｱID
    Private Const CMlngvsfAreaEqColWCarrierPositionName As Integer = 133                       'ｷｬﾘｱ位置
    Private Const CMlngvsfAreaEqColWCarrierStatusName   As Integer = 133                       'ｷｬﾘｱ状態
    Private Const CMlngvsfAreaEqColWLotID               As Integer = 110                       'ﾛｯﾄID
    Private Const CMlngvsfAreaEqColWPdID                As Integer = 53                        '機種
    Private Const CMlngvsfAreaEqColWFlowClass           As Integer = 25                        '種別
    Private Const CMlngvsfAreaEqColWWfID                As Integer = 144                       'WFID
    Private Const CMlngvsfAreaEqColWPriority            As Integer = 25                        '優先順位
    Private Const CMlngvsfAreaEqColWOpID                As Integer = 133                       '大工程
    Private Const CMlngvsfAreaEqColWStepID              As Integer = 133                       '小工程
    Private Const CMlngvsfAreaEqColWRecipe              As Integer = 200                       'ﾚｼﾋﾟ
    Private Const CMlngvsfAreaEqColWDispatchStartTime   As Integer = 133                       '処理開始予実
    Private Const CMlngvsfAreaEqColWCommitFlag          As Integer = 33                        '号機指定
    Private Const CMlngvsfAreaEqColWLotManagerName      As Integer = 133                       'ﾛｯﾄ担当
    Private Const CMlngvsfAreaEqColWWfNum               As Integer = 133                       'WF枚数
    Private Const CMlngvsfAreaEqColWChipNum             As Integer = 133                       'ﾁｯﾌﾟ数
    Private Const CMlngvsfAreaEqColWLotComments         As Integer = 133                       'ｺﾒﾝﾄ有無
    Private Const CMlngvsfAreaEqColWLCarrierID          As Integer = 65                        'ﾛｰﾀﾞｷｬﾘｱID
    Private Const CMlngvsfAreaEqColWUCarrierID          As Integer = 65                        'ｱﾝﾛｰﾀﾞｷｬﾘｱID
    Private Const CMlngvsfAreaEqColWLotLastUpdate       As Integer = 133                       'ﾛｯﾄ最終更新日付
    Private Const CMlngvsfAreaEqColWAltNumber           As Integer = 65                        '代替番号
    Private Const CMlngvsfAreaEqColWReworkFlag          As Integer = 65                        'ﾘﾜｰｸﾌﾗｸﾞ
    Private Const CMlngvsfAreaEqColWCarrierPositionID   As Integer = 33                        'ｷｬﾘｱ位置ID
    Private Const CMlngvsfAreaEqColWCarrierStatusID     As Integer = 33                        'ｷｬﾘｱ状態ID
    Private Const CMlngvsfAreaEqColWJBatchID            As Integer = 0                         '蒸着ﾊﾞｯﾁID
    Private Const CMlngvsfAreaEqColWCfFlag              As Integer = 0                         'CFﾌﾗｸﾞ
    Private Const CMlngvsfAreaEqColWLpFlag              As Integer = 0                         'LPﾌﾗｸﾞ
    Private Const CMlngvsfAreaEqColWVaFlag              As Integer = 0                         '無機ﾌﾗｸﾞ
    Private Const CMlngvsfAreaEqColWTpalClass           As Integer = 0                         'TPAL区分
    Private Const CMlngvsfAreaEqColWHBatchID            As Integer = 0                         '表面ﾊﾞｯﾁID
    Private Const CMlngvsfAreaEqColWShipDiffDay         As Integer = 53                        '進捗度(完成日との差分)
    Private Const CMlngvsfAreaEqColWFrFlag              As Integer = 0                         'FRﾚｼﾋﾟ有無ﾌﾗｸﾞ
    Private Const CMlngvsfAreaEqColWGrbClass            As Integer = 25                        'GRB区分
    Private Const CMlngvsfAreaEqColWColorCd             As Integer = 0                         '指定色

    '@vsfAreaEquipmentの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfAreaEqColTNo                  As String = "№"                    '№
    Private Const CMstrvsfAreaEqColTKb                  As String = ""                      '保/停区分
    Private Const CMstrvsfAreaEqColTNowSt               As String = "状態"                  '状態
    Private Const CMstrvsfAreaEqColTLimitTime           As String = "時間制限"              '時間制限
    Private Const CMstrvsfAreaEqColTCarrierID           As String = "ｷｬﾘｱID"                'ｷｬﾘｱID
    Private Const CMstrvsfAreaEqColTCarrierPosition     As String = "ｷｬﾘｱ位置"              'ｷｬﾘｱ位置
    Private Const CMstrvsfAreaEqColTCarrierStatus       As String = "ｷｬﾘｱ状態"              'ｷｬﾘｱ状態
    Private Const CMstrvsfAreaEqColTLotID               As String = "ﾛｯﾄID"                 'ﾛｯﾄID
    Private Const CMstrvsfAreaEqColTPdID                As String = "機種"                  '機種
    Private Const CMstrvsfAreaEqColTFlowClass           As String = "種別"                  '種別
    Private Const CMstrvsfAreaEqColTWfID                As String = "WFID"                  'WFID
    Private Const CMstrvsfAreaEqColTPriority            As String = "優"                    '優先順位
    Private Const CMstrvsfAreaEqColTOpID                As String = "大工程"                '大工程
    Private Const CMstrvsfAreaEqColTStepID              As String = "小工程"                '小工程
    Private Const CMstrvsfAreaEqColTRecipe              As String = "ﾚｼﾋﾟ"                  'ﾚｼﾋﾟ
    Private Const CMstrvsfAreaEqColTDispatchStartTime   As String = "処理開始予実"          '処理開始予実
    Private Const CMstrvsfAreaEqColTCommitFlag          As String = "号機指定"              '号機指定
    Private Const CMstrvsfAreaEqColTLotManagerName      As String = "ﾛｯﾄ担当"               'ﾛｯﾄ担当
    Private Const CMstrvsfAreaEqColTWfNum               As String = "WF枚数"                'WF枚数
    Private Const CMstrvsfAreaEqColTChipNum             As String = "ﾁｯﾌﾟ"                  'ﾁｯﾌﾟ数
    Private Const CMstrvsfAreaEqColTLotComments         As String = "ｺﾒﾝﾄ"                  'ｺﾒﾝﾄ有無
    Private Const CMstrvsfAreaEqColTLCarrierID          As String = "ﾛｰﾀﾞｷｬﾘｱID"            'ﾛｰﾀﾞｷｬﾘｱID
    Private Const CMstrvsfAreaEqColTUCarrierID          As String = "ｱﾝﾛｰﾀﾞｷｬﾘｱID"          'ｱﾝﾛｰﾀﾞｷｬﾘｱID
    Private Const CMstrvsfAreaEqColTAltNumber           As String = "代替番号"              '代替番号
    Private Const CMstrvsfAreaEqColTLotLastUpdate       As String = "ロット最終更新日付"    'ﾛｯﾄ最終更新日付
    Private Const CMstrvsfAreaEqColTReworkFlag          As String = "リワーク"              'ﾘﾜｰｸﾌﾗｸﾞ
    Private Const CMstrvsfAreaEqColTJBatchID            As String = "蒸着バッチID"          '蒸着ﾊﾞｯﾁID
    Private Const CMstrvsfAreaEqColTCfFlag              As String = "CFフラグ"              'CFﾌﾗｸﾞ
    Private Const CMstrvsfAreaEqColTLpFlag              As String = "LPフラグ"              'LPﾌﾗｸﾞ
    Private Const CMstrvsfAreaEqColTVaFlag              As String = "無機フラグ"            '無機ﾌﾗｸﾞ
    Private Const CMstrvsfAreaEqColTTpalClass           As String = "TPAL区分"              'TPAL区分
    Private Const CMstrvsfAreaEqColTHBatchID            As String = "表面バッチID"          '表面ﾊﾞｯﾁID
    Private Const CMstrvsfAreaEqColTShipDiffDay         As String = "進捗度"                '進捗度(完成日との差分)
    Private Const CMstrvsfAreaEqColTFrFlag              As String = "FRﾚｼﾋﾟ有無ﾌﾗｸﾞ"        'FRﾚｼﾋﾟ有無ﾌﾗｸﾞ
    Private Const CMstrvsfAreaEqColTGrbClass            As String = "GRB"                   'GRB区分
    Private Const CMstrvsfAreaEqColTColorCd             As String = "指定色"                '指定色

    '@lblTitle(10)の定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrlblTitle10Stocker                As String = "ストッカー"
    Private Const CMstrlblTitle10BCRCarrier             As String = "BCRｷｬﾘｱID"

    '@ｸﾞﾘｯﾄﾞの設定
    Private Const CMlngvsfAreaEqRowTitle                As Integer = 0                         'ﾀｲﾄﾙ行(行)
    Private Const CMlngvsfAreaEqColTitle                As Integer = 0                         'ﾀｲﾄﾙ行(列)
    Private Const CMlngvsfAreaEqPageRows                As Integer = 10                        '1ﾍﾟｰｼﾞの表示行数
    Private Const CMlngvsfAreaEqHFontSize               As Integer = 12                        'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfAreaEqHHeight                 As Integer = 26                        'ﾍｯﾀﾞｰの高さ
    Private Const CMlngvsfAreaEqHeight                  As Integer = 38                        '1行の高さ
    Private Const CMlngStsBarIndex                      As Integer = 1                         'ｽﾃｰﾀｽﾊﾞｰの表示ｲﾝﾃﾞｯｸｽ
    Private Const CMlngvsfFrozenCols_1A0                As Integer = 5                         '固定列数
    Private Const CMlngvsfFrozenCols_2A0                As Integer = 4                         '固定列数

    '@ﾛｯﾄ状態表記
    Private Const CMstrBu                               As String = "部"                    '部分ﾚｼﾋﾟ表示
    Private Const CMstrGou                              As String = "号"                    '号機表示
    Private Const CMstrRi                               As String = "リ"                    'ﾘﾜｰｸ表示
    Private Const CMstrTsui                             As String = "追"                    '追加表示
    Private Const CMstrHo                               As String = "保"                    '保留表示
    Private Const CMstrTei                              As String = "停"                    '停止表示
    Private Const CMstrGen                              As String = "限"                    '処理限定表示
    Private Const CMstrGai                              As String = "外"                    'FR累積時間範囲外表示

    '@色指定
    Private Const CMlngVbColorWhite                     As Integer = &HFFFFFF                  '白色
    Private Const CMlngVbColorBlack                     As Integer = &H0&                      '黒色

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                      As Integer = 16                        'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Integer = 16                        'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColName                   As Integer = 0                         '名称列番
    Private Const CMlngCmbGridColID                     As Integer = 1                         'ID列番(非表示項目)
    Private Const CMlngCmbDispCols                      As Integer = 1                         'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbRowHeight                     As Integer = 42                        'ﾘｽﾄ行の高さ
    Private Const CMlngCmbValueColID                    As Integer = 1                         '装置ID・ｽﾄｯｶｰの取得列数

    '@ｲﾍﾞﾝﾄ名称
    Private Const CMstrFormName                         As String = "frmxxEN0150"                   '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                         As String = "Form_Load"                     'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmdLotListClick                  As String = "cmdLotList_Click"              'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmdMcGroupNameValidate           As String = "cmbMcGroupName_Validate"       'ｲﾍﾞﾝﾄ名称
    Private Const CMstrcmdShipClick                     As String = "cmdShip_Click"                 'ｲﾍﾞﾝﾄ名称
    Private Const CMstrCmdRegistClick                   As String = "cmdRegist_Click"               'ｲﾍﾞﾝﾄ名称
    Private Const CMstrcmdDummyDisChargeClick           As String = "cmdDummyDisCharge_Click"       'ｲﾍﾞﾝﾄ名称
    Private Const CMstrcmdShipSetfocus                  As String = "cmdShip.SetFocus"              'ｲﾍﾞﾝﾄ名
    Private Const CMstrArrowFormActivate                As String = "⇔Form_Activate"               'ｲﾍﾞﾝﾄ名
    Private Const CMstrArrowCmbMcGroupNameValidate      As String = "⇔cmbMcGroupName_Validate"     'ｲﾍﾞﾝﾄ名
    Private Const CMstrArrowCmbWpIDValidate             As String = "⇔cmbWpID_Validate"            'ｲﾍﾞﾝﾄ名
    Private Const CMstrArrowCmdShipClick                As String = "⇔cmdShip_Click"               'ｲﾍﾞﾝﾄ名
    Private Const CMstrArrowCmdLotDetailClick           As String = "⇔cmdLotDetail_Click"          'ｲﾍﾞﾝﾄ名
    Private Const CMstrArrowCmdChgSeqNum_Click          As String = "⇔cmdChgSeqNum_Click"          'ｲﾍﾞﾝﾄ名
    Private Const CMstrArrowCmdRegistClick              As String = "⇔cmdRegist_Click"             'ｲﾍﾞﾝﾄ名
    Private Const CMstrArrowCmdLotConnectedInfoDispClick As String = "⇔cmdLotConnectedInfoDisp_Click"  'ｲﾍﾞﾝﾄ名

    '@保留/停止/ﾘﾜｰｸ
    Private Const CMstrLotHoldFlgOn                     As String = "1"                     '保留ﾛｯﾄﾌﾗｸﾞON
    Private Const CMstrLotStopFlgOn                     As String = "1"                     '停止ﾛｯﾄﾌﾗｸﾞON
    Private Const CMstrLotReworkFlgOn                   As String = "1"                     'ﾘﾜｰｸﾌﾗｸﾞON
    Private Const CMstrLotReworkFlgOn2                  As String = "2"                     '追加流動ﾌﾗｸﾞON

    '@部分ﾚｼﾋﾟ
    Private Const CMstrPartialRecipeFlgOn               As String = "1"                     '部分ﾚｼﾋﾟﾌﾗｸﾞON

    '@稼動状態の表示
    Private Const CMstrWpStopFlag0                      As String = "0"
    Private Const CMstrWpStopFlag1                      As String = "1"
    Private Const CMstrWpMoveStop                       As String = "停止中"
    Private Const CMstrWpMoveFlow                       As String = "稼動中"

    '@号機の状態
    Private Const CMstrWpName                           As String = "号機"
    Private Const CMstrWpInit                           As String = "設定"
    Private Const CMstrWpOn                             As String = "指定"
    Private Const CMstrWpOff                            As String = "解除"
    Private Const CMstrGoukiFlgOn                       As String = "1"                     '号機設定
    Private Const CMstrGoukiFlgOff                      As String = "0"                     '号機解除

    '@ｷｬﾘｱ位置
    Private Const CMstrArrow                            As String = "→"

    '@WFID整形用
    Private Const CMstrWfIDCondChr                      As String = "#"                     'WFIDの8桁目
    Private Const CMlngWfIDCondChrPos                   As Integer = 8                      'WFIDの8桁目
    Private Const CMlngWfIDCondLength                   As Integer = 10                     'WFIDの桁数
    Private Const CMlngWfIDDispRightLength              As Integer = 3                      'WFIDの表示文字数(下3桁)
    Private Const CMlngWfIDDispRightLength2             As Integer = 2                      'WFIDの表示文字数(下2桁)

    '@幅
    Private Const CMlnglblTitle10Stocker                As Integer = 222
    Private Const CMlnglblTitle10BCRCarrier             As Integer = 100

    '@↓2016/06/22 (Wed) 10:36:33 T.Oide **************************************************
    '@WPID判別用
    Private Const CMstrContEtWpId                       As String = "1TELIUSDTL"        'CONTｴｯﾁｬｰ判別用

    '@FR時間ラベル表示/非表示
    Private Const CMlnglblFrLimitLeft_Visble            As Integer = 823
    Private Const CMlnglblFrLimitLeft_InVisble          As Integer = 627
    '@↑2016/06/22 (Wed) 10:36:33 T.Oide **************************************************
    

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '@ｸﾞﾘｯﾄﾞの並びを格納する
    Private mlngvsfAreaEqColNo                          As Integer                          '№
    Private mlngvsfAreaEqColKb                          As Integer                          '保/停区分
    Private mlngvsfAreaEqColNowSt                       As Integer                          'ﾛｯﾄ状態
    Private mlngvsfAreaEqColLimitTime                   As Integer                          '時間制限
    Private mlngvsfAreaEqColCarrierID                   As Integer                          'ｷｬﾘｱID(col変更時はbasxxEN150も同じく修正する必要あり)
    Private mlngvsfAreaEqColCarrierPositionName         As Integer                          'ｷｬﾘｱ位置
    Private mlngvsfAreaEqColCarrierStatusName           As Integer                          'ｷｬﾘｱ状態
    Private mlngvsfAreaEqColLotID                       As Integer                          'ﾛｯﾄID(col変更時はbasxxEN150も同じく修正する必要あり)
    Private mlngvsfAreaEqColPdID                        As Integer                          '機種(col変更時はbasxxEN150も同じく修正する必要あり)
    Private mlngvsfAreaEqColFlowClass                   As Integer                          '種別
    Private mlngvsfAreaEqColWfId                        As Integer                          'WFIDの下3桁の結合("#01,#02,#03,#04,#05")
    Private mlngvsfAreaEqColPriority                    As Integer                          '優先順位
    Private mlngvsfAreaEqColOpID                        As Integer                          '大工程(col変更時はbasxxEN150も同じく修正する必要あり)
    Private mlngvsfAreaEqColStepID                      As Integer                          '小工程(col変更時はbasxxEN150も同じく修正する必要あり)
    Private mlngvsfAreaEqColRecipe                      As Integer                          'ﾚｼﾋﾟ
    Private mlngvsfAreaEqColDispatchStartTime           As Integer                          '処理開始予実
    Private mlngvsfAreaEqColLotManagerName              As Integer                          'ﾛｯﾄ担当
    Private mlngvsfAreaEqColWfNum                       As Integer                          'WF枚数
    Private mlngvsfAreaEqColChipNum                     As Integer                          'ﾁｯﾌﾟ数
    Private mlngvsfAreaEqColCommitFlag                  As Integer                          '号機指定(1：指定　0：指定なし)
    Private mlngvsfAreaEqColLCarrierID                  As Integer                          'ﾛｰﾀﾞｷｬﾘｱID(ｷｬﾘｱID引継ぎに使用)
    Private mlngvsfAreaEqColUCarrierID                  As Integer                          'ｱﾝﾛｰﾀﾞｷｬﾘｱID(ｷｬﾘｱID引継ぎに使用)
    Private mlngvsfAreaEqColAltNumber                   As Integer                          '代替番号
    Private mlngvsfAreaEqColLotLastUpdate               As Integer                          'ﾛｯﾄ最終更新日付
    Private mlngvsfAreaEqColReworkFlag                  As Integer                          'ﾘﾜｰｸﾌﾗｸﾞ(1:ﾘﾜｰｸあり　0:ﾘﾜｰｸなし)
    Private mlngvsfAreaEqColCarrierPositionID           As Integer                          'ｷｬﾘｱ位置ID
    Private mlngvsfAreaEqColCarrierStatusID             As Integer                          'ｷｬﾘｱ状態ID
    Private mlngvsfAreaEqColLotComments                 As Integer                          'ｺﾒﾝﾄ
    Private mlngvsfAreaEqColJBatchID                    As Integer                          '蒸着ﾊﾞｯﾁID
    Private mlngvsfAreaEqColHBatchID                    As Integer                          '表面ﾊﾞｯﾁID
    Private mlngvsfAreaEqColCfFlag                      As Integer                          'CFﾌﾗｸﾞ
    Private mlngvsfAreaEqColLpFlag                      As Integer                          'LPﾌﾗｸﾞ
    Private mlngvsfAreaEqColVaFlag                      As Integer                          '無機ﾌﾗｸﾞ
    Private mlngvsfAreaEqColTpalClass                   As Integer                          'TPAL区分
    Private mlngvsfAreaEqColShipDiffDay                 As Integer                          '進捗度
    Private mlngvsfAreaEqColFrFlag                      As Integer                          'FRﾚｼﾋﾟ有無ﾌﾗｸﾞ
    Private mlngvsfAreaEqColGrbClass                    As Integer                          'GRB区分
    Private mlngvsfAreaEqColColorCd                     As Integer                          '指定色
    Private mtypAreaEquipmentList                       As List(Of AreaEquipmentList)       '装置用途格納
    Private mlngAreaEqCnt                               As Integer                          '装置用途件数
    Private mtypStockerList                             As List(Of StockerList)             'ｽﾄｯｶﾏｽﾀ格納
    Private mstrCarrierID                               As String                           'ｷｬﾘｱID退避用
    Private mlngStockerListCnt                          As Integer                          'ｽﾄｯｶﾘｽﾄｶｳﾝﾄ
    Private mstrStockerName                             As String                           'ｽﾄｯｶ名退避用
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
    Private buttonProcessing                            As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                          'NSYS WindowCloseフラグ
    Private vsfAreaEquipmentRowBeforeSort               As Integer                          'NSYS ｿｰﾄ時の選択行退避


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
        pubVsfMouseWheelManager_Set(vsfAreaEquipment, cmdUp, cmdDown,cmdLeft,cmdRight)

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
    '作成日：2004/04/13 (Tue) 14:16:34 M.Matsuura
    '更新日：2016/06/22 (Wed) 10:28:51 T.Oide
    '備　考：
    '　　　：2004/09/16 (Thu) 16:04:10 S.Deguchi    機能ﾊﾞｰｼﾞｮﾝ処理を追加
    '　　　：2005/06/21 (Tue) 16:53:23 N.Kasai      子画面をAlt+F4で終了した場合に再表示できない為、ﾛｰｶﾙ変数に変更
    '　　　：2009/02/25 (Wed) 20:02:06 N.Kojima     ﾁｯﾌﾟ品判別説明ﾗﾍﾞﾙの制御処理追加。(案件№03402)
    '　　　：2009/07/28 (Tue) 14:03:48 N.Kojima     無機対応Phase2、組立でもﾀﾞﾐｰ説明ﾗﾍﾞﾙを表示する。(案件№03661)
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    '　　　：2010/03/11 (Thu) 16:30:20 N.Kojima     処理限定説明ﾗﾍﾞﾙを表示する。(案件№03897)
    Private Sub Form_Load()

        Dim lblnAns             As Boolean              '結果格納
        Dim ltypMcGroupList     As McGroupList          '装置ｸﾞﾙｰﾌﾟ情報格納
        Dim ltypDisp            As UtilRefTmInfo        '端末設定情報格納
        Dim lstrFormTitle       As String               'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        Dim llngCnt             As Integer              'ｶｳﾝﾀ

        Try
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

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

            '@起動SBが"2A0：組立"か
            If pstrSBID = CPstrSBID2A0 Then
                '@2A0：組立の場合

                lblTitleL.BackColor = ColorTranslator.FromWin32(CPlngLColor) '機種L
                lblTitleR.BackColor = ColorTranslator.FromWin32(CPlngRColor) '機種R
                lblTitleL.Visible = True
                lblTitleR.Visible = True
                lblTitleChip.Visible = True                 'ﾁｯﾌﾟ品説明
            Else
                '@1A0：基板の場合

                lblTitleExecRestrictLot.Top = 73            '処理限定
                lblTitleExecRestrictLot.Left = 712
                lblTitleExecRestrictLot.Width = 112

                lblTitleL.Visible = False
                lblTitleR.Visible = False
                lblTitleChip.Visible = False                'ﾁｯﾌﾟ品説明
                
            End If

        '@↓2016/06/22 (Wed) 10:28:42 T.Oide **************************************************
            '@FR時間
            labFrLimit.Visible = False
        '@↑2016/06/22 (Wed) 10:28:42 T.Oide **************************************************

            lblTitleExecRestrictLot.Visible = True          '処理限定
            lblTitleD.BackColor = ColorTranslator.FromWin32(CPlngVbColorOrange)        'ﾀﾞﾐｰ
            lblTitleD.Visible = True
            lblTitleHT.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)        '保留/停止

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
            Call prvFrmxxEN0150_Init()

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


                '@-----------------------
                '@ 起動SBが基板(1A0)の場合のみｽﾄｯｶｰ情報を取得
                '@-----------------------
                '@起動SBが"1A0"か
                If pstrSBID = CPstrSBID1A0 Then

                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(CMstrFormName, CMstrFormLoad)

                    '@=======================
                    '@ ｽﾄｯｶﾏｽﾀ取得(3K：FOUPｽﾄｯｶｰのみ)
                    '@=======================
                    lblnAns = pubblnMasStockerList_Sel(mtypStockerList, _
                                                       CMstrmas_stockerlistVer, _
                                                       mlngStockerListCnt, _
                                                       CPstrCD3K)

                    '@ｽﾄｯｶﾏｽﾀ取得結果が"False：取得失敗"か
                    If lblnAns = False Then

                        '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                        Exit Sub
                    End If

                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrFormLoad)

                    '@=======================
                    '@ ｽﾄｯｶｰｺﾝﾎﾞ設定処理
                    '@=======================
                    Call prvcmbStockerName_Disp()

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

            'NSYS 退避変数へ初期表示処理結果を退避
            mstrStockerName = cmbStockerName.Text
            mstrMcGroupID = cmbMcGroupName.Value
            mstrWpID = cmbWpID.Value

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
    '作成日：2005/03/28 (Mon) 11:13:03 N.Kasai
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2005/03/28 (Mon) 11:13:03 N.Kasai      mblnFormLoad1st：初回ﾛｰﾄﾞのみ最新ﾛｯﾄ一覧を取得する。
    '　　　：                                       mblnLoadFlag：画面起動中にｴﾗｰが発生した場合は最新取得を行わない。
    '　　　：                                       DoEvents：ﾌｫｰﾑﾛｰﾄﾞ中の通信に負荷がかかった場合にﾌｫｰﾑに制御を渡す
    '　　　：                                       cmdClose.Cancel：ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない。
    '　　　：2005/06/21 (Tue) 16:50:53 N.Kasai      子画面をAlt+F4で終了した場合に再表示できない為、ﾛｰｶﾙ変数に変更
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
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

                    '@ﾌｫｰﾑﾛｯｸ

                    '@制御をOSに渡す
                    '@ﾌｫｰﾑﾛｰﾄﾞ中の通信に負荷がかかった場合にﾌｫｰﾑに制御を渡す
                    '@ｲﾍﾞﾝﾄを抑止する為、ﾌｫｰﾑをﾛｯｸする。
                    'DoEvents
                    Me.Refresh

                    '@ﾌｫｰﾑﾛｯｸ解除

                    '@Escﾎﾞﾀﾝを有効
                    '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
                    Me.CancelButton = Me.cmdClose

                    With ptypOnErrorInfo

                        '@ｴﾗｰ発生箇所の設定
                        .strErrPositionDetail = CMstrArrowFormActivate

                        '@=======================
                        '@ 最新取得ﾎﾞﾀﾝ処理
                        '@=======================
                        Call cmdLotList_Click(sender,e)

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
    '作成日：2004/04/13 (Tue) 14:16:34 M.Matsuura
    '更新日：2012/04/17 (Tue) 12:33:30 Y.Yoneyama
    '備　考：
    '　　　：2004/10/26 (Tue) 17:11:40 S.Deguchi    DoEvents時にはAlt+F4キーを無効にする処理を追加
    '　　　：2004/11/29 (Mon) 08:53:52 S.Deguchi    左右ｷｰによるｽｸﾛｰﾙ処理で隠し列の処理を追加
    '　　　：2005/01/06 (Thu) 09:25:24 S.Deguchi    cmbMcGroupNameのValidateｲﾍﾞﾝﾄ呼び出す処理の空欄以外の条件を削除
    '　　　：2005/02/02 (Wed) 17:01:46 H.Wajima     ｴﾗｰ処理追加
    '　　　：2006/07/04 (Tue) 16:59:15 T.Kitagawa　 WFID("#01,#02,#03,#04,#05")の非表示ｶﾗﾑ追加(ﾕｰｻﾞ要望№0213)
    '　　　：2007/07/06 (Fri) 12:05:11 N.Kasai      ｸﾞﾘｯﾄﾞ機能共通化
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    '　　　：2012/04/17 (Tue) 12:33:30 Y.Yoneyama   BCRｷｬﾘｱID照合機能対応
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


            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name

                '@〓 装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ 〓
                Case cmbMcGroupName.Name

                    '@Enterｷｰが押下されたか
                    If e.KeyCode = Keys.Return Then

                        '@=======================
                        '@ 装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞValidateｲ処理
                        '@=======================
                        'NSYS Validatingの多重起動抑止
                        RemoveHandler cmbMcGroupName.Validating,AddressOf cmbMcGroupName_Validate
                        Call cmbMcGroupName_Validate(sender,New CancelEventArgs(True))
                        AddHandler cmbMcGroupName.Validating,AddressOf cmbMcGroupName_Validate

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
                        'NSYS Validatingの多重起動抑止
                        RemoveHandler cmbWpID.Validating,AddressOf cmbWpID_Validate
                        Call cmbWpID_Validate(sender,New CancelEventArgs(True))
                        AddHandler cmbWpID.Validating,AddressOf cmbWpID_Validate

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

        '@↓2012/04/17 (Tue) 11:38:35 Y.Yoneyama **************************************************
                '@〓 BCRｷｬﾘｱID 〓
                Case txtBCRCarrier.Name

                    '@Enterｷｰが押下されたか
                    If e.KeyCode = Keys.Return Then

                        '@=======================
                        '@ BCRｷｬﾘｱIDValidateｲ処理
                        '@=======================
                        RemoveHandler txtBCRCarrier.Validating,AddressOf txtBCRCarrier_Validate
                        Call txtBCRCarrier_Validate(sender,New CancelEventArgs(True))
                        AddHandler txtBCRCarrier.Validating,AddressOf txtBCRCarrier_Validate
                        
                        Exit Sub
                    End If
        '@↑2012/04/17 (Tue) 11:38:35 Y.Yoneyama **************************************************

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
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2004/10/14 (Thu) 09:22:30 M.Miura　    ｿｰﾄ保持用構造体のｸﾘｱを追加
    '　　　：2004/11/01 (Mon) 16:20:59 T.Kitagawa　 閉じるﾎﾞﾀﾝ統合
    '　　　：2004/11/09 (Tue) 11:45:35 N.Kojima　   出庫指示機能追加に伴い、追加した変数を初期化
    '　　　：2005/02/02 (Wed) 17:00:06 H.Wajima     ｴﾗｰ処理追加(ｺﾒﾝﾄ省略)
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
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
                Call cmdClose_Click(sender,e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload

            End If

            '@各種ﾓｼﾞｭｰﾙ配列/構造体の初期化
            mtypAreaEquipmentList = Nothing                     '装置仕掛ﾛｯﾄﾘｽﾄ
            mtypStockerList = Nothing                           'ｽﾄｯｶｰﾘｽﾄ
            mtypChgSort.typChgSortList = Nothing                'ｿｰﾄﾘｽﾄ
            mtypCommonInfo = ltypCommonInfo                     '引継ぎﾘｽﾄ

            '@各種ﾓｼﾞｭｰﾙ変数の初期化
            mstrMcGroupIDWk = vbNullString                      '装置ｸﾞﾙｰﾌﾟID退避用
            mstrWpIDWk = vbNullString                           '装置ID退避用
            mstrMcGroupID = vbNullString                        '装置ｸﾞﾙｰﾌﾟID格納用
            mstrWpID = vbNullString                             '装置ID格納用
            mstrWkWpID = vbNullString                           '装置ID格納用2
            mstrCarrierID = vbNullString                        'ｷｬﾘｱID退避用
            mstrStockerName = vbNullString                      'ｽﾄｯｶｰ退避用
            mlngStockerListCnt = 0                              'ｽﾄｯｶﾘｽﾄｶｳﾝﾄ

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

            '@ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄとの関連付けを解除
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
    '作成日：2004/04/13 (Tue) 14:16:34 M.Matsuura
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2004/09/15 (Wed) 14:51:10 M.Miura　    装置状態ﾗﾍﾞﾙ初期化を追加(不具合№629)
    '　　　：2005/02/02 (Wed) 17:08:19 H.Wajima     ｴﾗｰ処理追加
    '　　　：2005/03/02 (Wed) 09:54:50 N.Kojima　   稼動状態ﾗﾍﾞﾙ削除に伴う修正(改善№524、525)
    '　　　：2007/10/15 (Mon) 10:57:05 N.Kojima     処理順ﾙｰﾙﾗﾍﾞﾙの追加に伴う修正。(案件№02152)
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbMcGroupName_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGroupName.Change

        Try
            '@以下の条件の場合、処理終了
            '@ ①ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False：起動失敗(起動中)"の場合(画面起動中は初期化を行わない)
            '@ ②ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ③ﾌｫｰﾑﾛｯｸ中の場合
            If pblnFormLoad = False Or _
                Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If


            '@-----------------------
            '@ 各種初期化処理
            '@-----------------------
            '@装置名ｺﾝﾎﾞ
            cmbWpID.Clear
            cmbWpID.Enabled = False

            '@ｽﾄｯｶｰｺﾝﾎﾞ
            cmbStockerName.Clear
            cmbStockerName.Enabled = False

            '@各種ﾗﾍﾞﾙ
            lblNowDate.Text = vbNullString           '情報取得日時
            lblLotCnt.Text = vbNullString            '該当件数
            lblYouto.Text = vbNullString             '用途
            lblMode.Text = vbNullString              '運用ﾓｰﾄﾞ
            lblWpStatusName.Text = vbNullString      '装置状態
            lblRecipeRule.Text = vbNullString        '処理順ﾙｰﾙ

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
    '作成日：2004/05/12 (Wed) 17:52:06 T.Kitagawa
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2005/02/02 (Wed) 17:08:58 H.Wajima     ｴﾗｰ処理追加
    '　　　：2005/06/23 (Thu) 17:35:18 N.Kojima     ｺﾒﾝﾄ行削除(SetFocus対応部)
    '　　　：2005/06/27 (Mon) 16:14:12 N.Kasai      ｾｯﾄﾌｫｰｶｽ共通ﾙｰﾁﾝ化
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbMcGroupName_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGroupName.CloseUp

        Try
            '@装置ｸﾞﾙｰﾌﾟがNULL以外か
            If cmbMcGroupName.Text <> vbNullString Then

                '@=======================
                '@ 装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞValidate処理
                '@=======================
                'NSYS Validatingの多重起動抑止
                RemoveHandler cmbMcGroupName.Validating,AddressOf cmbMcGroupName_Validate
                Call cmbMcGroupName_Validate(sender,New CancelEventArgs(True))
                AddHandler cmbMcGroupName.Validating,AddressOf cmbMcGroupName_Validate

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
    '作成日：2004/04/21 (Wed) 15:46:13 M.Matsuura
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2004/10/18 (Mon) 16:09:50 N.Kasai      0件ﾒｯｾｰｼﾞｺﾒﾝﾄｱｳﾄ
    '　　　：2004/11/08 (Mon) 17:01:35 N.Kojima　   出庫指示機能追加に伴い、処理追加
    '　　　：2005/01/06 (Thu) 09:02:12 S.Deguchi    ｴﾘｱID比較で空欄の場合も処理を抜けるように修正(不具合№392)
    '　　　：2005/02/02 (Wed) 17:09:54 H.Wajima     ｴﾗｰ処理追加
    '　　　：2005/06/23 (Thu) 17:36:09 N.Kojima     ｺﾒﾝﾄ行削除(SetFocus対応、装置IDの件数ﾁｪｯｸ部)
    '　　　：2005/06/27 (Mon) 17:13:31 N.Kasai      ｾｯﾄﾌｫｰｶｽ共通ﾙｰﾁﾝ化
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbMcGroupName_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbMcGroupName.Validating

        Dim lblnAns                     As Boolean                    '結果格納
        Dim llngAreaEqCnt               As Integer                    '装置ｸﾞﾙｰﾌﾟ別装置情報ﾃﾞｰﾀ件数
        Dim lstrMcGroupID               As String                     '装置ｸﾞﾙｰﾌﾟID格納
        Dim lstrWpId                    As String                     '装置ID格納

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl Is cmdClose OrElse mblnWindowClose Then
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
                        'NSYS 自コントロール処理の場合はフォーカス処理
                        If ActiveControl.Name = cmbMcGroupName.Name Then
                            '@装置名ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmbWpID)
                        End If
                    Else
                        'NSYS 自コントロール処理の場合はフォーカス処理
                        If ActiveControl.Name = cmbMcGroupName.Name Then
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
                cmbWpID.ValueCol = CMlngCmbValueColID

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
            cmbWpID.ValueCol = CMlngCmbValueColID

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

                '@起動SBが基板(1A0)か
                If pstrSBID = CPstrSBID1A0 Then

                    '@=======================
                    '@ ｽﾄｯｶｰｺﾝﾎﾞ設定処理
                    '@=======================
                    Call prvcmbStockerName_Disp()
                End If

                With ptypOnErrorInfo

                    '@ｴﾗｰ発生箇所の設定
                    .strErrPositionDetail = CMstrArrowCmbMcGroupNameValidate

                    '@=======================
                    '@ 最新取得ﾎﾞﾀﾝ処理
                    '@=======================
                    Call cmdLotList_Click(sender,e)

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
                'NSYS 自コントロール処理の場合はフォーカス処理
                If ActiveControl.Name = cmbMcGroupName.Name Then
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
    '作成日：2004/04/14 (Wed) 11:22:43 M.Matsuura
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2004/09/15 (Wed) 14:53:13 M.Miura      装置状態ﾗﾍﾞﾙ初期化を追加(不具合№629)
    '　　　：2004/10/14 (Thu) 10:56:05 M.Miura　    ｶﾚﾝﾄ行検索ｷｰを追加
    '　　　：2005/02/02 (Wed) 17:10:49 H.Wajima     ｴﾗｰ処理追加
    '　　　：2005/04/12 (Tue) 15:43:54 N.Kasai      不具合№725　対応
    '　　　：2007/10/15 (Mon) 10:58:02 N.Kojima     処理順ﾙｰﾙﾗﾍﾞﾙ追加に伴う修正。(案件№02152)
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbWpID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWpID.Change

        Try
            '@以下の条件の場合、処理終了
            '@ ①ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False：起動失敗(起動中)"の場合(画面起動中は初期化を行わない)
            '@ ②ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ③ﾌｫｰﾑﾛｯｸ中の場合
            If pblnFormLoad = False Or _
                Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If

            '@各種ﾗﾍﾞﾙの初期化
            lblNowDate.Text = vbNullString           '情報取得日時
            lblLotCnt.Text = vbNullString            '該当件数
            lblYouto.Text = vbNullString             '用途
            lblMode.Text = vbNullString              '運用ﾓｰﾄﾞ
            lblWpStatusName.Text = vbNullString      '装置状態
            lblRecipeRule.Text = vbNullString        '処理順ﾙｰﾙ

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
    '作成日：2004/04/21 (Wed) 18:19:04 M.Matsuura
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2005/02/02 (Wed) 17:11:30 H.Wajima     ｴﾗｰ処理追加
    '　　　：2005/06/23 (Thu) 17:39:06 N.Kojima     ｺﾒﾝﾄ行削除(SetFocus対応部)
    '　　　：2005/06/27 (Mon) 17:14:12 N.Kasai      ｾｯﾄﾌｫｰｶｽ共通ﾙｰﾁﾝ化
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbWpID_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWpID.CloseUp

        Try
            '@ｴﾗｰ発生箇所の初期化
            ptypOnErrorInfo.strErrPositionDetail = vbNullString
                
            '@装置名が選択されているか
            If cmbWpID.Text <> vbNullString Then

                '@ｽﾄｯｶｰｺﾝﾎﾞを有効にする
                cmbStockerName.Enabled = True
            End If

            '@=======================
            '@ 装置名ｺﾝﾎﾞValidate処理
            '@=======================
            'NSYS Validatingの多重起動抑止
            RemoveHandler cmbWpID.Validating,AddressOf cmbWpID_Validate
            Call cmbWpID_Validate(sender,New CancelEventArgs(False))
            AddHandler cmbWpID.Validating,AddressOf cmbWpID_Validate

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
    '作成日：2004/04/21 (Wed) 15:46:28 M.Matsuura
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2004/10/18 (Mon) 16:10:37 N.Kasai      0件ﾒｯｾｰｼﾞｺﾒﾝﾄｱｳﾄ
    '　　　：2004/11/08 (Mon) 17:02:14 N.Kojima　   出庫指示機能追加に伴い、処理追加
    '　　　：2005/02/02 (Wed) 17:12:09 H.Wajima     ｴﾗｰ処理追加
    '　　　：2005/06/27 (Mon) 17:14:39 N.Kasai      ｾｯﾄﾌｫｰｶｽ共通ﾙｰﾁﾝ化
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmbWpID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbWpID.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@装置名が未選択か
            If cmbWpID.Value = vbNullString Then
                'NSYS 自コントロール処理の場合はフォーカス処理
                If ActiveControl.Name = cmbWpID.Name Then
                    '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
                Exit Sub
            End If

            '@前回選択装置と同じか
            If mstrWpIDWk = cmbWpID.Value Then

                '@装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞが有効か
                If vsfAreaEquipment.Enabled = True Then
                    'NSYS 自コントロール処理の場合はフォーカス処理
                    If ActiveControl.Name = cmbWpID.Name Then
                        '@装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfAreaEquipment)
                    End If
                Else
                    'NSYS 自コントロール処理の場合はフォーカス処理
                    If ActiveControl.Name = cmbWpID.Name Then
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
            cmbWpID.ValueCol = CMlngCmbValueColID

            With ptypOnErrorInfo

                '@ｴﾗｰ発生箇所の設定
                .strErrPositionDetail = CMstrArrowCmbWpIDValidate

                '@=======================
                '@ 最新取得ﾎﾞﾀﾝ処理
                '@=======================
                Call cmdLotList_Click(sender,e)

                '@ｴﾗｰ発生箇所の初期化
                .strErrPositionDetail = vbNullString
            End With

            '@起動SBが基板(1A0)か
            If pstrSBID = CPstrSBID1A0 Then

                '@=======================
                '@ ｽﾄｯｶｰｺﾝﾎﾞ設定処理
                '@=======================
                Call prvcmbStockerName_Disp()

            End If

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

    '関数名：cmbStockerName_Change
    '機　能：[ｽﾄｯｶｰ]ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/05 (Fri) 20:28:03 N.Kojima
    '更新日：2009/08/26 (Wed) 08:43:26 N.Kojima
    '備　考：
    '　　　：2005/02/02 (Wed) 17:18:57 H.Wajima     ｴﾗｰ処理追加
    '　　　：2009/08/26 (Wed) 08:43:26 N.Kojima     案件№03611の対応のついでにｿｰｽ整備
    Private Sub cmbStockerName_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbStockerName.Change

        Try
            '@以下の条件の場合、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If

            '@ｽﾄｯｶｰが未選択か
            If cmbStockerName.Text = vbNullString Then

                '@出庫指示ﾎﾞﾀﾝを無効にする
                cmdShip.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbStockerName_Change"      '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbStockerName_CloseUp
    '機　能：[ｽﾄｯｶｰ]ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/08 (Mon) 11:52:37 N.Kojima
    '更新日：2009/08/26 (Wed) 08:43:26 N.Kojima
    '備　考：
    '　　　：2005/02/02 (Wed) 17:19:16 H.Wajima     ｴﾗｰ処理追加
    '　　　：2005/06/23 (Thu) 17:57:08 N.Kojima     ｺﾒﾝﾄ行削除(SetFocus対応部)
    '　　　：2005/06/27 (Mon) 17:16:03 N.Kasai      ｾｯﾄﾌｫｰｶｽ共通ﾙｰﾁﾝ化
    '　　　：2009/08/26 (Wed) 08:43:26 N.Kojima     案件№03611の対応のついでにｿｰｽ整備
    Private Sub cmbStockerName_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbStockerName.CloseUp

        Try
            '@ｽﾄｯｶｰが選択されているか
            If cmbStockerName.Text <> vbNullString Then

                '@=======================
                '@ ｽﾄｯｶｰｺﾝﾎﾞValidate処理
                '@=======================
                'NSYS Validatingの多重起動抑止
                RemoveHandler cmbStockerName.Validating,AddressOf cmbStockerName_Validate
                Call cmbStockerName_Validate(sender,New CancelEventArgs(True))
                AddHandler cmbStockerName.Validating,AddressOf cmbStockerName_Validate

                '@装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞが有効か
                If vsfAreaEquipment.Enabled = True Then

                    '@装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfAreaEquipment)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmbStockerName_CloseUp" '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbStockerName_Validate
    '機　能：[ｽﾄｯｶｰ]ｺﾝﾎﾞ　選択確定時(Validate)処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/11/08 (Mon) 11:55:40 N.Kojima
    '更新日：2009/08/26 (Wed) 08:43:26 N.Kojima
    '備　考：
    '　　　：2005/02/02 (Wed) 17:19:46 H.Wajima     ｴﾗｰ処理追加
    '　　　：2005/06/23 (Thu) 17:57:58 N.Kojima     ｺﾒﾝﾄ行削除(SetFocus対応部)
    '　　　：2005/06/27 (Mon) 17:16:29 N.Kasai      ｾｯﾄﾌｫｰｶｽ共通ﾙｰﾁﾝ化
    '　　　：2009/08/26 (Wed) 08:43:26 N.Kojima     案件№03611の対応のついでにｿｰｽ整備
    Private Sub cmbStockerName_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbStockerName.Validating

        Dim lstrMcGroupID       As String       '装置ｸﾞﾙｰﾌﾟID格納
        Dim lstrWpId            As String       '装置ID格納

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｴﾗｰ発生箇所の初期化
            ptypOnErrorInfo.strErrPositionDetail = vbNullString

            '@前回選択ｽﾄｯｶｰと同じ、またはｽﾄｯｶｰが未選択か
            If mstrStockerName = cmbStockerName.Text Or _
                cmbStockerName.Value = vbNullString Then

                Exit Sub
            End If

            '@ｽﾄｯｶｰｺﾝﾎﾞの値取得列をｽﾄｯｶｰID列に設定
            cmbStockerName.ValueCol = CMlngCmbValueColID

            '@装置ｸﾞﾙｰﾌﾟIDを退避
            lstrMcGroupID = cmbMcGroupName.Value

            '@装置IDを格納
            lstrWpId = cmbWpID.Value
            mstrWpID = cmbWpID.Value

            '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ、または装置名ｺﾝﾎﾞが未選択か
            If lstrMcGroupID = vbNullString Or _
                lstrWpId = vbNullString Then

                '@最新取得ﾎﾞﾀﾝを無効にする
                cmdLotList.Enabled = False

                '@=======================
                '@ 装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ初期化
                '@=======================
                Call prvVsfAreaEquipment_Init()

                Exit Sub
            Else
                '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞ、装置名ｺﾝﾎﾞが選択されている場合

                '@最新取得ﾎﾞﾀﾝを有効にする
                cmdLotList.Enabled = True
            End If

            '@選択ｽﾄｯｶｰ名を退避用変数に格納
            mstrStockerName = cmbStockerName.Text

            '@装置仕掛ﾛｯﾄが1件以上存在するか
            If mlngOutputCnt > 0 Then

                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True：起動成功"か
                If pblnFormLoad = True Then
                    'NSYS 自コントロール処理の場合フォーカス処理
                    If ActiveControl.Name = cmbStockerName.Name Then
                        '@装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfAreaEquipment)
                    End If
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbStockerName_Validate"    '処理名
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
    '作成日：2004/04/13 (Tue) 15:57:14 M.Matsuura
    '更新日：2016/06/22 (Wed) 10:49:56 T.Oide
    '備　考：
    '　　　：2004/09/15 (Wed) 19:10:15 S.Deguchi    最新取得処理にｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置用途情報取得処理を追加
    '　　　：2004/10/18 (Mon) 16:08:37 N.Kasai      0件ﾒｯｾｰｼﾞｺﾒﾝﾄｱｳﾄ
    '　　　：2005/02/02 (Wed) 17:05:51 H.Wajima     ｴﾗｰ処理追加
    '　　　：2005/06/27 (Mon) 16:07:39 N.Kasai      ｾｯﾄﾌｫｰｶｽ共通ﾙｰﾁﾝ化
    '　　　：2005/07/15 (Fri) 11:33:23 S.Deguchi    ﾛｯﾄ一覧ﾒｯｾｰｼﾞ修正の対応を追加
    '　　　：2008/06/25 (Wed) 08:30:00 S.Ochiai     部分ﾚｼﾋﾟ対応(案件№03008)、及びﾒｯｾｰｼﾞ構造を抜本的に変更
    '　　　：2008/07/01 (Tue) 17:34:53 M.Koni       "util.regtminfo"応答ﾒｯｾｰｼﾞ変更対応<案件No.03006>
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmdLotList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotList.Click

        Dim lblnAns                     As Boolean              '結果格納
        Dim llngLotListCnt              As Integer              'ﾃﾞｰﾀ格納数
        Dim lstrMcGroupID               As String               'ｴﾘｱID格納
        Dim lstrWpId                    As String               '装置ID格納
        Dim ltypLotListReq              As LotListReq           'ﾛｯﾄ一覧要求構造体
        Dim ltypLotListAns              As LotListAns           'ﾛｯﾄ一覧応答格納用
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

            '@号機設定ﾎﾞﾀﾝの初期化
            cmdRegist.Enabled = False

            '@以下の条件の場合、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑのﾛｯｸ中の場合
            '@ ③装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞが未選択の場合
            '@ ④装置名ｺﾝﾎﾞが未選択の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Or _
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
            cmbWpID.ValueCol = CMlngCmbValueColID

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


            '@-----------------------
            '@ ﾛｯﾄ一覧情報取得処理
            '@-----------------------
            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotListReq

                .strMsgVer = CMstrlot_list____Ver       'Msgﾊﾞｰｼﾞｮﾝ
                .strClassDivision = CPstrCD26           '処理区分：26(装置別ﾛｯﾄ一覧)
                .strSbID = pstrSBID                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strWpID = lstrWpId                     '装置ID
            End With

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdLotListClick)

            '@ﾌｫｰﾑﾛｯｸ

            '@=======================
            '@ ﾛｯﾄ一覧情報取得
            '@=======================
            lblnAns = pubblnLotList_Sel(ltypLotListReq, _
                                        ltypLotListAns, _
                                        llngLotListCnt)

            '@ﾌｫｰﾑﾛｯｸ解除

            '@ﾛｯﾄ一覧情報取得結果が"True：取得成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdLotListClick)

                '@-----------------------
                '@ 装置状態取得処理
                '@-----------------------
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrCmdLotListClick)

                '@ﾌｫｰﾑﾛｯｸ

                '@=======================
                '@ 装置状態取得
                '@=======================
                lblnAns = pubblnEqState_Sel(CMstreq__state___Ver, lstrWpId, ltypEqstate)

                '@ﾌｫｰﾑﾛｯｸ解除

                '@装置状態取得結果が"True：取得成功"か
                If lblnAns = True Then

                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrCmdLotListClick)

                    '@-----------------------
                    '@ 端末設定情報登録処理
                    '@-----------------------
                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(CMstrFormName, CMstrCmdLotListClick)

                    '@ﾌｫｰﾑﾛｯｸ

                    '@=======================
                    '@ 端末設定情報登録
                    '@=======================
                    lblnAns = pubblnUtilRegTmInfo_Upd(pstrSBID, CMstrutilregtminfoVer, _
                                                      CPstrCD26, _
                                                      pstrComputerName, _
                                                      ltypUtilRegTmInfo, _
                                                      cmbWpID.Value, , , cmbMcGroupName.Value)

                    '@ﾌｫｰﾑﾛｯｸ解除

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
            '@ 装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ表示処理
            '@=======================
            Call prvVsfAreaEquipment_Disp(ltypLotListAns, llngLotListCnt)

            '@=======================
            '@ 装置状態表示処理
            '@=======================
            Call prvWpStatus_Disp(ltypLotListAns, ltypEqstate)

            '@取得装置仕掛ﾛｯﾄ件数を退避変数に格納
            mlngOutputCnt = llngLotListCnt

            '@各種ﾗﾍﾞﾙの表示
            lblNowDate.Text = Format$(Now, CPstrDateFormat)                  '情報取得日時表示
            lblLotCnt.Text = Format$(llngLotListCnt, CPstrDateFormatKanma)   '該当件数
            
        '@↓2016/06/22 (Wed) 10:38:10 T.Oide **************************************************
            '@CONTｴｯﾁｬｰの場合、「FR時間の判例を表示」
            If Mid$(cmbWpID.Value, 1, 10) = CMstrContEtWpId Then
                labFrLimit.Visible = True
                labFrLimit.Left = CMlnglblFrLimitLeft_Visble
            Else
                labFrLimit.Visible = False
                labFrLimit.Left = CMlnglblFrLimitLeft_InVisble
            End If
        '@↑2016/06/22 (Wed) 10:38:10 T.Oide **************************************************

            '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞを有効にする
            cmbMcGroupName.Enabled = True

            '@装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞが有効か
            If vsfAreaEquipment.Enabled = True Then

                '@装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(vsfAreaEquipment)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ﾌｫｰﾑﾛｯｸ解除

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
    '作成日：2004/04/13 (Tue) 14:16:34 M.Matsuura
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2004/10/14 (Thu) 09:23:26 M.Miura      ｿｰﾄ保持用構造体のｸﾘｱを追加
    '　　　：2005/02/02 (Wed) 17:13:07 H.Wajima     ｴﾗｰ処理追加
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub vsfAreaEquipment_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfAreaEquipment.AfterSort

        Try
            'BeforeSortで除外していたRowColChangeイベントを復帰
            AddHandler vsfAreaEquipment.BeforeRowColChange, AddressOf vsfAreaEquipment_BeforeRowColChange
            AddHandler vsfAreaEquipment.EnterCell, AddressOf vsfAreaEquipment_EnterCell

            'NSYS ソート前の選択行が有効行でない場合、ヘッダを選択行とする
            If vsfAreaEquipmentRowBeforeSort <  vsfAreaEquipment.Rows.Fixed Then
                vsfAreaEquipment.Row = 0
            End If

            '@ｿｰﾄ情報を格納
            With mtypChgSort

                .lngCnt = .lngCnt + 1                       'ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                Dim typChgSortListTmp As ChgSortList        '配列定義
                typChgSortListTmp.lngCol = e.Col            'ｿｰﾄ列番号を格納
                typChgSortListTmp.lngOrder = e.Order        '並び替え方法を格納(昇順/降順)
                .typChgSortList.Add(typChgSortListTmp)

            End With

            '@=======================
            '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfAfterSort(vsfAreaEquipment, mlngvsfAreaEqColCarrierID & vbTab & _
                                                   mlngvsfAreaEqColOpID & vbTab & _
                                                   mlngvsfAreaEqColStepID, _
                                                   cmdUP, cmdDown, True,True,True,False,True)

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
    '作成日：2004/04/16 (Fri) 15:06:31 S.Deguchi
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2004/10/14 (Thu) 09:27:49 M.Miura      列幅変更ﾌﾗｸﾞを追加
    '　　　：2005/02/02 (Wed) 17:13:47 H.Wajima     ｴﾗｰ処理追加
    '　　　：2007/07/09 (Mon) 15:10:40 N.Kasai      ｸﾞﾘｯﾄﾞ共通
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
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
    '作成日：2004/04/13 (Tue) 14:16:34 M.Matsuura
    '更新日：2009/10/05 (Mon) 12:56:36 N.Kojima
    '備　考：
    '　　　：2004/10/14 (Thu) 09:28:43 M.Miura　    ｶﾚﾝﾄ行検索用のｷｰを格納を追加
    '　　　：2004/11/08 (Mon) 17:02:49 N.Kojima　   出庫指示機能追加に伴い、処理追加
    '　　　：2004/11/29 (Mon) 14:42:32 N.Kojima　   出庫指示機能追加に伴い、出庫指示ﾎﾞﾀﾝ有効無効判定修正
    '　　　：2004/12/03 (Fri) 19:11:25 N.Kojima　   装置用途構造体からｽﾄｯｶﾏｽﾀ構造体を判定する処理に修正(不具合№294)
    '　　　：2005/02/02 (Wed) 17:14:50 H.Wajima     ｴﾗｰ処理追加
    '　　　：2005/04/19 (Tue) 13:34:55 N.Kojima     ﾊﾞｯﾁS1運用対応(ﾀﾞﾐｰｷｬﾘｱ払出ﾎﾞﾀﾝ制御追加)
    '　　　：2005/06/23 (Thu) 17:41:15 N.Kojima     ｺﾒﾝﾄ行削除(ﾀﾞﾐｰ対応部)
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    '　　　：2009/10/05 (Mon) 12:56:36 N.Kojima     TFT/CFﾛｯﾄ紐付情報表示機能追加に伴う修正。(案件№03791)
    Private Sub vsfAreaEquipment_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfAreaEquipment.BeforeRowColChange

        Dim llngCnt             As Integer      'ｶｳﾝﾄ

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfAreaEquipment.Rows.Count <= vsfAreaEquipment.Rows.Fixed Then
                'NSYS ヘッダークリック時と同じ処理を実施
                cmdLotDetail.Enabled = False                'ﾛｯﾄ情報詳細表示
                cmdLotConnectedInfoDisp.Enabled = False     'TFT/CFﾛｯﾄ紐付情報表示
                Return
            End If

            '@選択前行と選択行が違い、かつ選択行がﾃﾞｰﾀ行か
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then

                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ｷｬﾘｱID、大工程、小工程、代替番号)
                mtypChgSort.strKey = vsfAreaEquipment.GetData(e.NewRange.r1, mlngvsfAreaEqColCarrierID) & _
                                     vsfAreaEquipment.GetData(e.NewRange.r1, mlngvsfAreaEqColOpID) & _
                                     vsfAreaEquipment.GetData(e.NewRange.r1, mlngvsfAreaEqColStepID)

            End If

            '@選択行のｷｬﾘｱIDを退避
            mstrCarrierID = vsfAreaEquipment.GetData(e.NewRange.r1, mlngvsfAreaEqColCarrierID)

            With vsfAreaEquipment

                '@選択行がﾍｯﾀﾞｰ行以外か
                If e.NewRange.r1 > 0 Then

                    '@起動SBが基板(1A0)か
                    If pstrSBID = CPstrSBID1A0 Then

                        '@ｷｬﾘｱ位置がNULL以外か
                        If .GetData(e.NewRange.r1, mlngvsfAreaEqColCarrierPositionName) <> vbNullString Then

                            '@ｽﾄｯｶ情報を検索
                            For llngCnt = 0 To mlngStockerListCnt - 1

                                '@ｷｬﾘｱ位置IDとｽﾄｯｶIDが同じか
                                If .GetData(e.NewRange.r1, mlngvsfAreaEqColCarrierPositionID) = _
                                    mtypStockerList(llngCnt).strStockerId Then

                                    '@出庫指示ﾎﾞﾀﾝを有効にする
                                    cmdShip.Enabled = True
                                    Exit For
                                Else
                                    '@出庫指示ﾎﾞﾀﾝを無効にする
                                    cmdShip.Enabled = False
                                End If
                            Next llngCnt
                        Else
                            '@ｷｬﾘｱ位置がNULLの場合

                            '@出庫指示ﾎﾞﾀﾝを無効にする
                            cmdShip.Enabled = False
                        End If
                    Else
                        '@起動SBが組立(2A0)の場合

                        '@蒸着ﾊﾞｯﾁIDがNULL以外か(=蒸着工程流動済み)
        '@↓2012/06/27 (Wed) 11:29:00 H.Hayashi **************************************************
                        ' .Cell(flexcpText, NewRow, mlngvsfAreaEqColJBatchID) <> vbNullString Then
                        If .GetData(e.NewRange.r1, mlngvsfAreaEqColJBatchID) <> vbNullString Or _
                           .GetData(e.NewRange.r1, mlngvsfAreaEqColHBatchID) <> vbNullString Then
        '@↑2012/06/27 (Wed) 11:29:00 H.Hayashi **************************************************
                        

                            '@TFT/CFﾛｯﾄ紐付情報表示ﾎﾞﾀﾝを有効にする
                            cmdLotConnectedInfoDisp.Enabled = True
                        Else
                            '@蒸着ﾊﾞｯﾁIDがNULLの場合

                            '@TFT/CFﾛｯﾄ紐付情報表示ﾎﾞﾀﾝを無効にする
                            cmdLotConnectedInfoDisp.Enabled = False
                        End If
                    End If


                    '@ﾛｯﾄ情報詳細表示ﾎﾞﾀﾝを有効にする
                    cmdLotDetail.Enabled = True

                    '@運用ﾓｰﾄﾞが「S1」以外か
                    If lblMode.Text <> CPstrS1 Then

                        '@ﾀﾞﾐｰｷｬﾘｱ払出ﾎﾞﾀﾝを無効にする
                        cmdDummyDisCharge.Enabled = False
                        Exit Sub
                    End If

                    '@選択行の種別がNULL以外か
                    If .GetData(e.NewRange.r1, mlngvsfAreaEqColFlowClass) <> vbNullString Then

                        '@ﾛｯﾄ状態が「LOAD中」、かつ種別の2文字目が「D」(「ﾀﾞﾐｰ：FD,SD,ED」)、かつ装置状態が「処理実行中」以外か
                        If .GetData(e.NewRange.r1, mlngvsfAreaEqColNowSt) = CPstrLoadSt And _
                            Trim$(Strings.Right$(.GetData(e.NewRange.r1, mlngvsfAreaEqColFlowClass), 1)) = CPstrFlowDummy And _
                            lblWpStatusName.Text <> CPstrWpExecuting Then

                            '@ﾀﾞﾐｰｷｬﾘｱ払出ﾎﾞﾀﾝを有効にする
                            cmdDummyDisCharge.Enabled = True
                        Else
                            '@ﾀﾞﾐｰｷｬﾘｱ払出ﾎﾞﾀﾝを無効にする
                            cmdDummyDisCharge.Enabled = False
                        End If
                    Else
                        '@選択行の種別がNULLの場合

                        '@ﾀﾞﾐｰｷｬﾘｱ払出ﾎﾞﾀﾝを無効にする
                        cmdDummyDisCharge.Enabled = False
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
    '作成日：2004/04/13 (Tue) 14:20:30 M.Matsuura
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2005/02/02 (Wed) 17:15:43 H.Wajima     ｴﾗｰ処理追加
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub vsfAreaEquipment_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfAreaEquipment.BeforeSort

        Try
            'NSYS 不要なHandler処理を抑止
            RemoveHandler vsfAreaEquipment.BeforeRowColChange, AddressOf vsfAreaEquipment_BeforeRowColChange
            RemoveHandler vsfAreaEquipment.EnterCell, AddressOf vsfAreaEquipment_EnterCell
            vsfAreaEquipmentRowBeforeSort = vsfAreaEquipment.Row

            'NSYS データ行がない場合は処理を抜ける
            If vsfAreaEquipment.Rows.Count <= vsfAreaEquipment.Rows.Fixed Then
                Return
            End If

            '@=======================
            '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfBeforeSort(vsfAreaEquipment, mlngvsfAreaEqColCarrierID & vbTab & _
                                                    mlngvsfAreaEqColOpID & vbTab & _
                                                    mlngvsfAreaEqColStepID)

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
    '作成日：2004/09/23 (Thu) 09:54:54 N.Kasai
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：「号機設定」ﾎﾞﾀﾝの使用可否を制御する。
    '　　　：2005/02/02 (Wed) 17:16:00 H.Wajima     ｴﾗｰ処理追加
    '　　　：2005/09/06 (Tue) 13:37:31 T.Kitagawa   SCHﾘﾘｰｽに伴い、Fﾓｰﾄﾞ時は号機設定ﾎﾞﾀﾝを無効にする(不具合№3092)
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub vsfAreaEquipment_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfAreaEquipment.EnterCell

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfAreaEquipment.Rows.Count <= vsfAreaEquipment.Rows.Fixed Then
                Return
            End If

            '@装置運用ﾓｰﾄﾞが"F(全自動)"か
            If lblMode.Text = CPstrF Then

                '@号機指定ﾎﾞﾀﾝの設定変更
                cmdRegist.Enabled = False                    '無効
                cmdRegist.Text = CMstrWpName & CMstrWpInit   'ｷｬﾌﾟｼｮﾝ変更("号機設定"にする)

                Exit Sub
            End If


            With vsfAreaEquipment

                '@ﾍｯﾀﾞｰ以外が選択されたか
                If .Row >= .Rows.Fixed Then

                    '@選択ﾛｯﾄの状態が「作業待ち」か
                    If .GetData(.Row, mlngvsfAreaEqColNowSt) = CPstrWaitWorkSt Then

                        '@★ 号機指定ﾌﾗｸﾞにより処理分岐 ★
                        Select Case .GetData(.Row, mlngvsfAreaEqColCommitFlag)

                            '@〓 0：号機未設定 〓
                            Case CMstrGoukiFlgOff

                                '@号機指定ﾎﾞﾀﾝの設定変更
                                cmdRegist.Enabled = True                     '有効
                                cmdRegist.Text = CMstrWpName & CMstrWpOn     'ｷｬﾌﾟｼｮﾝ変更("号機指定"にする)

                            '@〓 1：号機設定済 〓
                            Case CMstrGoukiFlgOn

                                '@号機指定ﾎﾞﾀﾝの設定変更
                                cmdRegist.Enabled = True                     '有効
                                cmdRegist.Text = CMstrWpName & CMstrWpOff    'ｷｬﾌﾟｼｮﾝ変更("号機解除"にする)

                            '@〓 その他：例外処理 〓
                            Case Else

                                '@号機指定ﾎﾞﾀﾝの設定変更
                                cmdRegist.Enabled = False                    '無効
                                cmdRegist.Text = CMstrWpName & CMstrWpInit   'ｷｬﾌﾟｼｮﾝ変更("号機設定"にする)

                        End Select
                    Else
                        '@選択ﾛｯﾄの状態が「作業待ち」以外の場合

                        '@号機指定ﾎﾞﾀﾝの設定変更
                        cmdRegist.Enabled = False                            '無効
                        cmdRegist.Text = CMstrWpName & CMstrWpInit           'ｷｬﾌﾟｼｮﾝ変更("号機設定"にする)
                    End If
                    
        '@↓2012/04/06 (Fri) 16:25:22 Y.Yoneyama **************************************************
                    '@ﾊﾞｰｺｰﾄﾞ読取ｷｬﾘｱIDは表示されている場合
                    If txtBCRCarrier.Visible = True Then
                        txtBCRCarrier.Text = vbNullString
                        Call pubSetFocus(txtBCRCarrier)
                    End If
        '@↑2012/04/06 (Fri) 16:25:22 Y.Yoneyama **************************************************
                    
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
    '作成日：2004/04/15 (Thu) 13:34:48 S.Deguchi
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2005/02/02 (Wed) 17:03:12 H.Wajima     ｴﾗｰ処理追加
    '　　　：2005/06/23 (Thu) 17:17:24 N.Kojima     ｺﾒﾝﾄ行削除(SetFocus対応部)
    '　　　：2005/06/27 (Mon) 17:12:10 N.Kasai      ｾｯﾄﾌｫｰｶｽ共通ﾙｰﾁﾝ化
    '　　　：2006/07/04 (Tue) 15:36:46 T.Kitagawa　 WFID("#01,#02,#03,#04,#05")の非表示ｶﾗﾑ追加(ﾕｰｻﾞ要望№0213)
    '　　　：2007/07/06 (Fri) 12:02:46 N.Kasai      ｸﾞﾘｯﾄﾞ機能共通化
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
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
    '作成日：2004/04/15 (Thu) 13:06:13 S.Deguchi
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2005/02/02 (Wed) 17:04:35 H.Wajima     ｴﾗｰ処理追加
    '　　　：2005/06/23 (Thu) 17:18:22 N.Kojima     ｺﾒﾝﾄ行削除(SetFocus対応)
    '　　　：2005/06/27 (Mon) 17:12:47 N.Kasai      ｾｯﾄﾌｫｰｶｽ共通ﾙｰﾁﾝ化
    '　　　：2006/07/04 (Tue) 16:59:15 T.Kitagawa　 WFID("#01,#02,#03,#04,#05")の非表示ｶﾗﾑ追加(ﾕｰｻﾞ要望№0213)
    '　　　：2007/07/06 (Fri) 12:02:05 N.Kasai      ｸﾞﾘｯﾄﾞ機能共通化
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
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
    '作成日：2004/04/13 (Tue) 14:16:34 M.Matsuura
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2005/02/02 (Wed) 17:07:10 H.Wajima     ｴﾗｰ処理追加
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
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
    '作成日：2004/04/13 (Tue) 14:16:34 M.Matsuura
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2005/02/02 (Wed) 17:07:46 H.Wajima     ｴﾗｰ処理追加
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
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
    '作成日：2004/04/13 (Tue) 14:16:34 M.Matsuura
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2005/02/02 (Wed) 17:01:08 H.Wajima     ｴﾗｰ処理追加
    '　　　：2005/02/03 (Thu) 13:01:33 H.Wajima     機能ID定数をﾛｰｶﾙ定数に変更
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
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
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

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
    '作成日：2004/09/27 (Mon) 12:58:58 N.Kasai
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2005/02/02 (Wed) 17:18:08 H.Wajima     ｴﾗｰ処理追加
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
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
                        Call cmdLotList_Click(cmdLotDetail,e)

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

    '関数名：cmdLotConnectedInfoDisp_Click
    '機　能：[TFT/CF紐付情報表示]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/10/05 (Mon) 09:45:13 N.Kojima
    '更新日：2014/12/02 (Tue) 13:56:07 H.Hayashi
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
        '@↓2014/11/11 (Tue) 15:43:51 H.Hayashi **************************************************
        '    plngfrmxxCM00T0Kbn = CPlngNumOne
            plngfrmxxCM01B0Kbn = CPlngNumOne
        '@↑2014/11/11 (Tue) 15:43:51 H.Hayashi **************************************************
            
            '@***********************
            '@ 引継ぎ情報作成
            '@***********************
            With vsfAreaEquipment

                ptypCommonInfo.strCarrierId = .GetData(.Row, mlngvsfAreaEqColCarrierID)       'ｷｬﾘｱID
                ptypCommonInfo.strLotID = .GetData(.Row, mlngvsfAreaEqColLotID)               'ﾛｯﾄID
                ptypCommonInfo.strFlowClass = .GetData(.Row, mlngvsfAreaEqColFlowClass)       '流動区分
                ptypCommonInfo.strPdId = .GetData(.Row, mlngvsfAreaEqColPdID)                 '機種
                ptypCommonInfo.strNowST = .GetData(.Row, mlngvsfAreaEqColNowSt)               'ﾛｯﾄ状態
                ptypCommonInfo.strWfNum = .GetData(.Row, mlngvsfAreaEqColWfNum)               'WF枚数
                ptypCommonInfo.strChipQuantity = .GetData(.Row, mlngvsfAreaEqColChipNum)      'ﾁｯﾌﾟ数
                ptypCommonInfo.strOpID = .GetData(.Row, mlngvsfAreaEqColOpID)                 '大工程
                ptypCommonInfo.strStepID = .GetData(.Row, mlngvsfAreaEqColStepID)             '小工程
                ptypCommonInfo.strCfFlag = .GetData(.Row, mlngvsfAreaEqColCfFlag)             'CFﾌﾗｸﾞ
                ptypCommonInfo.strBatchId = .GetData(.Row, mlngvsfAreaEqColJBatchID)          '蒸着ﾊﾞｯﾁID

                pstrVaFlag = .GetData(.Row, mlngvsfAreaEqColVaFlag)                           '無機ﾌﾗｸﾞ
                pstrTpalClass = .GetData(.Row, mlngvsfAreaEqColTpalClass)                     'TPAL設定
            End With


            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ TFT/CFﾛｯﾄ紐付き情報画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
        '@↓2014/11/11 (Tue) 15:44:17 H.Hayashi **************************************************
        '    Call Load(frmxxCM00T0)
            frmxxCM01B0.Instance = New frmxxCM01B0()
        '@↑2014/11/11 (Tue) 15:44:17 H.Hayashi **************************************************

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False：起動処理失敗"か
            If pblnFormLoad = False Then

                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
        '@↓2014/11/11 (Tue) 15:44:47 H.Hayashi **************************************************
        '        Call Unload(frmxxCM00T0)
                frmxxCM01B0.Instance = Nothing
        '@↑2014/11/11 (Tue) 15:44:47 H.Hayashi **************************************************

                '@各種ﾎﾞﾀﾝ制御ﾌﾗｸﾞに"True：有効化"をｾｯﾄ
                mblnCmdFlag = True

                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
                pblnFormLoad = True

                Exit Sub
            End If

            '@閉じるﾎﾞﾀﾝを無効にする(閉じる連打で落ちるのを回避)
            cmdClose.Enabled = False

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ TFT/CFﾛｯﾄ紐付き情報画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
        '@↓2014/11/11 (Tue) 15:45:14 H.Hayashi **************************************************
        '    Call frmxxCM00T0.Show(vbModal)
            frmxxCM01B0.Instance.ShowDialog(Me)
            frmxxCM01B0.Instance = Nothing
        '@↑2014/11/11 (Tue) 15:45:14 H.Hayashi **************************************************

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            pblnFormLoad = True

            '@各種ﾎﾞﾀﾝ制御ﾌﾗｸﾞに"True：有効化"をｾｯﾄ
            mblnCmdFlag = True

            '@装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞにﾃﾞｰﾀがあるか
            If vsfAreaEquipment.Rows.Count > 1 Then

                With ptypOnErrorInfo

                    '@ｴﾗｰ発生箇所の設定
                    .strErrPositionDetail = CMstrArrowCmdLotConnectedInfoDispClick

                    '@=======================
                    '@ 最新取得ﾎﾞﾀﾝ処理
                    '@=======================
                    Call cmdLotList_Click(cmdLotConnectedInfoDisp,e)

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
        '@↓2014/11/11 (Tue) 15:45:47 H.Hayashi **************************************************
        '    plngfrmxxCM00T0Kbn = CPlngNumZero
            plngfrmxxCM01B0Kbn = CPlngNumZero
        '@↑2014/11/11 (Tue) 15:45:47 H.Hayashi **************************************************

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

    '関数名：cmdDummyDisCharge_Click
    '機　能：[ﾀﾞﾐｰｷｬﾘｱ払出]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/04/18 (Mon) 20:43:48 N.Kojima
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub cmdDummyDisCharge_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDummyDisCharge.Click

        Dim lblnAns                 As Boolean          '戻り値
        Dim lstrCarrierID           As String           'ｷｬﾘｱID
        Dim lstrLotLastUpdate       As String           '最終更新日時

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｴﾗｰ発生箇所の初期化
            ptypOnErrorInfo.strErrPositionDetail = vbNullString

            '@以下の条件の場合、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If

            '@ﾃﾞｰﾀﾁｪｯｸ用にｷｬﾘｱIDを格納
            With vsfAreaEquipment
                lstrCarrierID = .GetData(.Row, mlngvsfAreaEqColCarrierID)     'ｷｬﾘｱID
            End With

            '@ｷｬﾘｱIDがNULLか
            If lstrCarrierID = vbNullString Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM01W>$$キャリアIDが設定されていません。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@出庫指示ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdShip)
                Exit Sub
            End If


            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@作業者ｺｰﾄﾞ入力画面でｷｬﾝｾﾙﾎﾞﾀﾝが押されたか
            If pblnCancel = True Then
                Exit Sub
            End If


            With vsfAreaEquipment
                '@最終更新日時格納
                lstrLotLastUpdate = .GetData(.Row, mlngvsfAreaEqColLotLastUpdate)
            End With

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrcmdDummyDisChargeClick)

            '@=======================
            '@ ﾀﾞﾐｰｷｬﾘｱ払出要求
            '@=======================
            lblnAns = pubblnDumyCarOut_Upd(cmbWpID.Value, _
                                           lstrCarrierID, _
                                           CMstrdumy_carout__Ver, _
                                           lstrLotLastUpdate)

            '@ﾀﾞﾐｰｷｬﾘｱ払出要求結果が"True：払出成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrcmdDummyDisChargeClick)

                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM4PI>$$ダミーキャリア[%1]の払出を受け付けました。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004P, lstrCarrierID)
                Call pubVsfInfo_Disp(pstrDMsg)

                With ptypOnErrorInfo

                    '@ｴﾗｰ発生箇所の設定
                    .strErrPositionDetail = CMstrArrowCmdShipClick

                    '@=======================
                    '@ 最新取得ﾎﾞﾀﾝ処理
                    '@=======================
                    Call cmdLotList_Click(cmdDummyDisCharge,e)

                    '@ｴﾗｰ発生箇所の初期化
                    .strErrPositionDetail = vbNullString
                End With
            Else
                '@ﾀﾞﾐｰｷｬﾘｱ払出要求結果が"False：払出失敗"か

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrcmdDummyDisChargeClick)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = CMstrcmdDummyDisChargeClick  '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdChgSeqNum_Click
    '機　能：[処理順変更]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/24 (Mon) 16:57:10 Y.Yamagishi
    '更新日：2009/08/26 (Wed) 08:43:26 N.Kojima
    '備　考：
    '　　　：2004/10/06 (Wed) 08:44:53 M.Miura      閉じるﾎﾞﾀﾝの有効/無効制御追加
    '　　　：2005/01/06 (Thu) 15:06:35 H.Wajima     引継ぎ構造体に装置IDを設定する処理を追加
    '　　　：2005/01/12 (Wed) 15:49:13 H.Wajima     引継ぎ情報の装置IDの初期化処理を追加
    '　　　：2005/02/02 (Wed) 17:16:44 H.Wajima     ｴﾗｰ処理追加
    '　　　：2009/08/26 (Wed) 08:43:26 N.Kojima     案件№03611の対応のついでにｿｰｽ整備
    Private Sub cmdChgSeqNum_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdChgSeqNum.Click

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
            pblnfrmxxCM0110Kbn = True

            '@装置名ｺﾝﾎﾞの値取得列をID列に設定
            cmbWpID.ValueCol = CMlngCmbValueColID

            '@退避装置IDがNULLか
            If mstrWpID = vbNullString Then

                '@選択装置のIDを格納
                ptypCommonInfo.strWpID = cmbWpID.Value
            Else
                '@退避装置IDを格納
                ptypCommonInfo.strWpID = mstrWpID
            End If

            '@=======================
            '@ 機能関連情報取得
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0260, lstrTitle)

            '@ﾛｯﾄ処理順変更のﾌｫｰﾑｷｬﾌﾟｼｮﾝを設定
            frmxxCM0110.Instance.Text = lstrTitle

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False：起動失敗"か
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
                frmxxCM0110.Instance = Nothing

                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
                pblnFormLoad = True

                '@各種ﾎﾞﾀﾝ制御ﾌﾗｸﾞに"True：有効化"をｾｯﾄ
                mblnCmdFlag = True
                Exit Sub
            End If

            '@閉じるﾎﾞﾀﾝを無効にする(閉じる連打で落ちるのを回避)
            cmdClose.Enabled = False


            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ ﾛｯﾄ処理順変更画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0110.Instance.ShowDialog(Me)
            frmxxCM0110.Instance = Nothing

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            pblnFormLoad = True

            '@各種ﾎﾞﾀﾝ制御ﾌﾗｸﾞに"True：有効化"をｾｯﾄ
            mblnCmdFlag = True

            '@装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞにﾃﾞｰﾀがあるか
            If vsfAreaEquipment.Rows.Count > 1 Then

                With ptypOnErrorInfo

                    '@ｴﾗｰ発生箇所の設定
                    .strErrPositionDetail = CMstrArrowCmdChgSeqNum_Click

                    '@=======================
                    '@ 最新取得ﾎﾞﾀﾝ処理
                    '@=======================
                    Call cmdLotList_Click(cmdChgSeqNum,e)

                    '@ｴﾗｰ発生箇所の初期化
                    .strErrPositionDetail = vbNullString
                End With

            Else
                '@引継ぎ情報の装置IDを初期化
                ptypCommonInfo.strWpID = vbNullString
            End If

            '@閉じるﾎﾞﾀﾝを有効にする(閉じる連打で落ちるのを回避)
            cmdClose.Enabled = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdChgSeqNum_Click"     '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：[号機設定]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/23 (Thu) 09:59:05 N.Kasai
    '更新日：2009/08/26 (Wed) 08:43:26 N.Kojima
    '備　考：
    '　　　：2004/09/26 (Sun) 19:53:46 N.Kasai      ｴﾗｰ時は最新読み込みをしない
    '　　　：2004/10/04 (Mon) 15:21:03 Y.Yamagishi  ﾌｫｰｶｽ戻り位置のｷｰに代替番号追加(不具合改善№981)
    '　　　：2004/10/07 (Thu) 11:33:49 N.Kasai      ﾛｯﾄ最終更新日付追加　№1044
    '　　　：2005/02/02 (Wed) 17:17:30 H.Wajima     ｴﾗｰ処理追加
    '　　　：2005/04/07 (Thu) 10:39:46 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2005/06/23 (Thu) 17:55:17 N.Kojima     ｺﾒﾝﾄ行削除(ｶﾞｲﾀﾞﾝｽ対応、SetFocus対応部)
    '　　　：2005/06/27 (Mon) 17:15:26 N.Kasai      ｾｯﾄﾌｫｰｶｽ共通ﾙｰﾁﾝ化
    '　　　：2005/09/07 (Wed) 14:13:29 T.Kitagawa　 SCHﾘﾘｰｽに伴い、Fﾓｰﾄﾞ時は処理順変更ﾎﾞﾀﾝ、号機指定ﾎﾞﾀﾝを無効にする(不具合№3092)
    '　　　：2005/11/01 (Tue) 10:46:05 S.Deguchi    不具合№2969の対応で,ﾌｫｰｶｽ処理を修正
    '　　　：2009/08/26 (Wed) 08:43:26 N.Kojima     案件№03611の対応のついでにｿｰｽ整備
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypChgctlwp            As Chgctlwp             '処理順号機設定解除要求格納構造体
        Dim lstrCommitFlag          As String               '号機設定退避
        Dim lstrSMsg                As String               '成功ﾒｯｾｰｼﾞ内容格納
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance        As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｴﾗｰ発生箇所の初期化
            ptypOnErrorInfo.strErrPositionDetail = vbNullString

            '@以下の条件の場合、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If


            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With vsfAreaEquipment

                ltypChgctlwp.strMsgVer = CMstrlot_chgctlwpVer                                                                               'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                ltypChgctlwp.strSbID = pstrSBID                                                                                             'SBID
                ltypChgctlwp.strLotID = .GetData(.Row, mlngvsfAreaEqColLotID)                     'ﾛｯﾄID
                ltypChgctlwp.strOpID = .GetData(.Row, mlngvsfAreaEqColOpID)                       '大工程
                ltypChgctlwp.strStepID = .GetData(.Row, mlngvsfAreaEqColStepID)                   '小工程
                ltypChgctlwp.strCarrierId = .GetData(.Row, mlngvsfAreaEqColCarrierID)             'ｷｬﾘｱID(成功ﾒｯｾｰｼﾞ用に格納)
                ltypChgctlwp.strAltNumber = .GetData(.Row, mlngvsfAreaEqColAltNumber)             '代替番号
                ltypChgctlwp.strLotLastUpdate = .GetData(.Row, mlngvsfAreaEqColLotLastUpdate)     'ﾛｯﾄ最終更新日付

                '@装置名ｺﾝﾎﾞの値取得列をID列に設定
                cmbWpID.ValueCol = CMlngCmbValueColID
                ltypChgctlwp.strWpID = cmbWpID.Value        '装置ID

                '@号機設定退避(判定、成功ﾒｯｾｰｼﾞに使用)
                lstrCommitFlag = .GetData(.Row, mlngvsfAreaEqColCommitFlag)

                '@★ 号機設定/解除ﾌﾗｸﾞにより処理分岐(設定：1、解除：0) ★
                Select Case lstrCommitFlag

                    '@〓 0：号機未設定 〓
                    Case CMstrGoukiFlgOff

                        ltypChgctlwp.strKindFlag = CMstrGoukiFlgOn      '設定
                        lstrSMsg = CMstrWpOn

                    '@〓 1：号機設定済み 〓
                    Case CMstrGoukiFlgOn

                        ltypChgctlwp.strKindFlag = CMstrGoukiFlgOff     '解除
                        lstrSMsg = CMstrWpOff

                End Select

                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)

                '@=======================
                '@ 処理順号機設定/解除
                '@=======================
                lblnAns = pubblnLotchgctlwp_Upd(ltypChgctlwp, _
                                                lstrGuidMsg, _
                                                lstrGuidMsgCode)

                '@処理順号機設定/解除結果が"True：処理成功"か
                If lblnAns = True Then

                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)

                    '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞがNULL以外か
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

                    '@表示ﾒｯｾｰｼﾞ変換("<TRM2WI>$$号機%1しました。キャリア[%2] ロット[%3]")
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002W, lstrSMsg, ltypChgctlwp.strCarrierId, ltypChgctlwp.strLotID)

                    '@成功ﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)
                Else
                    '@処理順号機設定/解除結果が"False：処理失敗"の場合

                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)

                    '@装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞが有効か
                    If vsfAreaEquipment.Enabled = True Then

                        '@装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfAreaEquipment)
                    End If

                    Exit Sub
                End If
            End With


            '@号機指定ﾎﾞﾀﾝを無効にする
            cmdRegist.Enabled = False

            With ptypOnErrorInfo

                '@ｴﾗｰ発生箇所の設定
                .strErrPositionDetail = CMstrArrowCmdRegistClick

                '@=======================
                '@ 最新取得ﾎﾞﾀﾝ処理
                '@=======================
                Call cmdLotList_Click(cmdRegist,e)

                '@ｴﾗｰ発生箇所の初期化
                .strErrPositionDetail = vbNullString
            End With

            '@運用ﾓｰﾄﾞが"F(全自動)"か
            If lblMode.Text = CPstrF Then

                '@"F"の場合は号機設定ﾎﾞﾀﾝを無効にし、ﾎﾞﾀﾝ名を"号機設定"に変更
                cmdRegist.Enabled = False
                cmdRegist.Text = CMstrWpName & CMstrWpInit
            Else
                '@運用ﾓｰﾄﾞが"F(全自動)"以外の場合

                '@号機指定ﾎﾞﾀﾝを有効にする
                cmdRegist.Enabled = True
            End If


            '@=======================
            '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfBeforeSort(vsfAreaEquipment, mlngvsfAreaEqColNo)

            '@=======================
            '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfAfterSort(vsfAreaEquipment, mlngvsfAreaEqColNo, cmdUP, cmdDown, True,True,True,False,True)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdRegist_Click"        '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdShip_Click
    '機　能：[出庫指示]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/05 (Fri) 20:32:39 N.Kojima
    '更新日：2009/08/26 (Wed) 08:43:26 N.Kojima
    '備　考：
    '　　　：2004/12/01 (Wed) 18:47:21 N.Kojima　   出庫指示ﾎﾞﾀﾝ押下可否判定変更に伴い、処理削除
    '　　　：2005/02/02 (Wed) 17:20:23 H.Wajima     ｴﾗｰ処理追加
    '　　　：2005/06/23 (Thu) 17:59:18 N.Kojima     ｺﾒﾝﾄ行削除(SetFocus対応部)
    '　　　：2005/06/27 (Mon) 17:16:58 N.Kasai      ｾｯﾄﾌｫｰｶｽ共通ﾙｰﾁﾝ化
    '　　　：2009/08/26 (Wed) 08:43:26 N.Kojima     案件№03611の対応のついでにｿｰｽ整備
    Private Sub cmdShip_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdShip.Click

        Dim lblnAns                 As Boolean          '戻り値
        Dim lstrCarrierID           As String           'ｷｬﾘｱID
        Dim lstrCarrierPosition     As String           'ｷｬﾘｱ位置
        Dim lstrCarrierStatus       As String           'ｷｬﾘｱ状態

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｴﾗｰ発生箇所の初期化
            ptypOnErrorInfo.strErrPositionDetail = vbNullString

            '@以下の条件の場合、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If

            '@ﾃﾞｰﾀﾁｪｯｸ用に変数に値を格納(長いので)
            With vsfAreaEquipment

                lstrCarrierID = .GetData(.Row, mlngvsfAreaEqColCarrierID)                     'ｷｬﾘｱID
                lstrCarrierPosition = .GetData(.Row, mlngvsfAreaEqColCarrierPositionID)       'ｷｬﾘｱ位置ID
                lstrCarrierStatus = .GetData(.Row, mlngvsfAreaEqColCarrierStatusName)         'ｷｬﾘｱ状態
            End With

            '@ｷｬﾘｱIDがNULLか
            If lstrCarrierID = vbNullString Then

                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM01W>$$キャリアIDが設定されていません。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@出庫指示ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdShip)
                Exit Sub
            End If

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@作業者ｺｰﾄﾞ入力画面でｷｬﾝｾﾙﾎﾞﾀﾝが押下されたか
            If pblnCancel = True Then
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrcmdShipClick)

            '@=======================
            '@ ｷｬﾘｱ手動出庫要求
            '@=======================
            lblnAns = pubblnCarrManuOutPort_Ins(lstrCarrierID, _
                                                CMstrcarrmanuoutportVer, _
                                                cmbStockerName.Value, _
                                                pstrUserID)

            '@ｷｬﾘｱ手動出庫要求結果が"True：処理成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrcmdShipClick)

                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM3GI>$$キャリア[%1]のストッカー[%2]への出庫指示を受け付けました。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003G, lstrCarrierID, cmbStockerName.Text)
                Call pubVsfInfo_Disp(pstrDMsg)

                With ptypOnErrorInfo

                    '@ｴﾗｰ発生箇所の設定
                    .strErrPositionDetail = CMstrArrowCmdShipClick

                    '@=======================
                    '@ 最新取得ﾎﾞﾀﾝ処理
                    '@=======================
                    Call cmdLotList_Click(cmdShip,e)

                    '@ｴﾗｰ発生箇所の初期化
                    .strErrPositionDetail = vbNullString
                End With

                Exit Sub
            Else
                '@ｷｬﾘｱ手動出庫要求結果が"False：処理失敗"か

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrcmdShipClick)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdShip_Click"          '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtBCRCarrier_Validate
    '機　能：BCRｷｬﾘｱIDのLOST
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2012/04/06 (Fri) 16:16:40 Y.Yoneyama
    '更新日：2012/04/06 (Fri) 16:16:40 Y.Yoneyama
    '備　考：
    Public Sub txtBCRCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtBCRCarrier.Validating

        Dim lstrTitle               As String
        Dim lstrCarrierID           As String
            
        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            
            '@BCRｷｬﾘｱ照合ﾌﾗｸﾞ初期化
            pblnfrmxxEN0150BCR = False

            '@BCRが無い場合は照合なし
            If pblnTerminalBCR = False Then
                'NSYS 自コントロール処理の場合フォーカス処理
                If ActiveControl.Name = txtBCRCarrier.Name Then
                    '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの空白ﾁｪｯｸ
            If Trim(txtBCRCarrier.Text) = vbNullString Then
                'NSYS 自コントロール処理の場合フォーカス処理
                If ActiveControl.Name = txtBCRCarrier.Name Then
                    '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtBCRCarrier.NowByte < txtBCRCarrier.ChrMaxByte Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM07W>$$キャリアIDは6桁で入力してください。"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽを留める
                e.Cancel = True
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの格納&初期化
            lstrCarrierID = Trim(txtBCRCarrier.Text)
            txtBCRCarrier.Text = vbNullString
            
            
            With vsfAreaEquipment
                
                '@ﾍｯﾀﾞｰが選択されたか
                If .Row < .Rows.Fixed Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「<TRM2JW>$$ロットを選択してからBCRキャリアID照合を実施してください。」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002J)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    'NSYS 自コントロール処理の場合フォーカス処理
                    If ActiveControl.Name = txtBCRCarrier.Name Then
                        '@ﾛｯﾄ一覧にﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfAreaEquipment)
                    End If
                    
                    Exit Sub
                End If
                
                '@選択ﾛｯﾄは「作業待ち」のみ有効
                If .GetData(.Row, mlngvsfAreaEqColNowSt) <> CPstrWaitWorkSt Then
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「<TRM2KW>$$「作業待ち」ではないのでBCRキャリアID照合は実施できません。」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002K, CPstrWaitWorkSt)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    'NSYS 自コントロール処理の場合フォーカス処理
                    If ActiveControl.Name = txtBCRCarrier.Name Then
                        '@ﾛｯﾄ一覧にﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfAreaEquipment)
                    End If
                    
                    Exit Sub
                End If
                
                '@選択ﾛｯﾄのｷｬﾘｱIDとBCRｷｬﾘｱIDが同じ場合
                If .GetData(.Row, mlngvsfAreaEqColCarrierID) = lstrCarrierID Then
                        
                    '@以下の条件の場合、処理終了
                    '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
                    '@ ②ﾌｫｰﾑﾛｯｸ中の場合
                    If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                        Exit Sub
                    End If

                    '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化(True：起動成功、False：起動中(起動失敗)・初期値)
                    pblnFormLoad = False
                        
                    '@ﾌｫｰﾑ起動区分に"True：子画面起動"をｾｯﾄ
                    pblnfrmxxEN0030Kbn = True

                    '@***********************
                    '@ 引継ぎ情報作成
                    '@***********************
                    ptypCommonInfo.strCarrierId = lstrCarrierID
                    ptypCommonInfo.strOpID = .GetData(.Row, mlngvsfAreaEqColOpID)
                    ptypCommonInfo.strStepID = .GetData(.Row, mlngvsfAreaEqColStepID)
                    ptypCommonInfo.strWpID = cmbWpID.Value

                    '@=======================
                    '@ 機能関連情報取得
                    '@=======================
                    Call pubMenuItemCorrelation_Set(CPstrKeyEN0030, lstrTitle)
                        
                    '@ﾛｯﾄ情報詳細画面のﾌｫｰﾑｷｬﾌﾟｼｮﾝに設定
                    frmxxEN0030.Instance.Text = lstrTitle
                        
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
                        frmxxEN0030.Instance = Nothing
                            
                        '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
                        pblnFormLoad = True

                        '@各種ﾎﾞﾀﾝ制御ﾌﾗｸﾞに"True：有効化"をｾｯﾄ
                        mblnCmdFlag = True
                        Exit Sub
                    End If

                    '@閉じるﾎﾞﾀﾝを無効にする(閉じる連打で落ちるのを回避)
                    cmdClose.Enabled = False

                    '@BCRｷｬﾘｱ照合ﾌﾗｸﾞON
                    pblnfrmxxEN0150BCR = True
                        
                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    '@ ﾛｯﾄ情報詳細画面　表示処理
                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    frmxxEN0030.Instance.ShowDialog(Me)
                    frmxxEN0030.Instance = Nothing
                        
                    '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
                    pblnFormLoad = True

                    '@各種ﾎﾞﾀﾝ制御ﾌﾗｸﾞに"True：有効化"をｾｯﾄ
                    mblnCmdFlag = True

                    '@装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞにﾃﾞｰﾀがあるか
                    If .Rows.Count > 1 Then
                        
                        With ptypOnErrorInfo

                            '@ｴﾗｰ発生箇所の設定
                            .strErrPositionDetail = CMstrArrowCmdLotDetailClick

                            '@=======================
                            '@ 最新取得ﾎﾞﾀﾝ処理
                            '@=======================
                            Call cmdLotList_Click(sender,e)

                            '@ｴﾗｰ発生箇所の初期化
                            .strErrPositionDetail = vbNullString

                        End With
                    End If
                    
                    '@BCRｷｬﾘｱ照合ﾌﾗｸﾞ初期化
                    pblnfrmxxEN0150BCR = False
                        
                    '@閉じるﾎﾞﾀﾝを有効にする(閉じる連打で落ちるのを回避)
                    cmdClose.Enabled = True
                        
                    '@BCRｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtBCRCarrier)
                         
                '@ｷｬﾘｱID照合失敗
                Else
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「<TRM28W>$$BCRキャリアID照合に失敗しました。$読込キャリアID[%1]"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0028, lstrCarrierID)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                    '@ｷｬﾘｱIDにﾌｫｰｶｽを留める
                    e.Cancel = True
                    Exit Sub
                        
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdRegist_Click"        '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
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

    '関数名：prvFrmxxEN0150_Init
    '機　能：画面初期化処理
    '引　数：lblnMcGroupID：(True：装置ｸﾞﾙｰﾌﾟ項目初期化、False：装置ｸﾞﾙｰﾌﾟ項目無変更)
    '戻り値：なし
    '作成日：2004/04/13 (Tue) 14:16:34 M.Matsuura
    '更新日：2009/10/05 (Mon) 12:56:36 N.Kojima
    '備　考：
    '　　　：2004/10/27 (Wed) 10:38:43 S.Deguchi    DoEventsのChange処理実行ﾌﾗｸﾞの初期化を追加
    '　　　：2004/11/08 (Mon) 17:03:32 N.Kojima　   出庫指示機能追加に伴い、処理追加
    '　　　：2005/02/02 (Wed) 17:21:09 H.Wajima     ｴﾗｰ処理追加
    '　　　：2005/03/02 (Wed) 09:54:50 N.Kojima　   稼動状態ﾗﾍﾞﾙ削除に伴う修正(改善№524、525)
    '　　　：2005/04/19 (Tue) 13:32:04 N.Kojima     ﾊﾞｯﾁS1運用対応(ﾀﾞﾐｰｷｬﾘｱ払出ﾎﾞﾀﾝの制御追加)
    '　　　：2005/06/23 (Thu) 18:00:33 N.Kojima     ｺﾒﾝﾄ行削除(ﾀﾞﾐｰ対応部)
    '　　　：2007/10/15 (Mon) 10:59:24 N.Kojima     処理順ﾙｰﾙﾗﾍﾞﾙ追加に伴う修正。(案件№02152)
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    '　　　：2009/10/05 (Mon) 12:56:36 N.Kojima     TFT/CFﾛｯﾄ紐付情報表示機能追加に伴う修正。(案件№03791)
    Private Sub prvFrmxxEN0150_Init(Optional ByVal lblnMcGroupID As Boolean = False)

        Try

            '@各種ﾗﾍﾞﾙの初期化
            lblYouto.Text = vbNullString             '用途
            lblMode.Text = vbNullString              'ﾓｰﾄﾞ
            lblWpStatusName.Text = vbNullString      '処理状態
            lblRecipeRule.Text = vbNullString        '処理順ﾙｰﾙ

            '@各種ﾓｼﾞｭｰﾙ変数の初期化
            mstrWpID = vbNullString                     '装置ID退避用変数
            mstrWpIDWk = vbNullString                   '装置ID退避用変数
            mstrWkWpID = vbNullString                   '装置ID退避用変数
            mstrMcGroupID = vbNullString                '装置ｸﾞﾙｰﾌﾟ退避用変数
            mstrMcGroupIDWk = vbNullString              '装置ｸﾞﾙｰﾌﾟ退避用変数

            '@ｿｰﾄ保持構造体の初期化
            With mtypChgSort

                .lngCnt = 0                                'ｶｳﾝﾀ
                .typChgSortList = New List(Of ChgSortList) '格納配列
                .blnChgWidth = False                       '列幅変更ﾌﾗｸﾞ(False：未変更)
                .strKey = vbNullString                     'ｶﾚﾝﾄ行検索ｷｰ
            End With

            '@装置ｺﾝﾎﾞの初期化
            cmbWpID.Clear                               '装置ID(WPID)項目
            cmbWpID.Enabled = False                     '装置ｺﾝﾎﾞ

            '@各種ﾎﾞﾀﾝの初期化
            cmdLotList.Enabled = False                  '最新取得
            cmdUP.Enabled = False                       '上(▲)ｽｸﾛｰﾙ
            cmdDown.Enabled = False                     '下(▼)ｽｸﾛｰﾙ
            cmdLeft.Enabled = False                     '左(<<)ｽｸﾛｰﾙ
            cmdRight.Enabled = False                    '右(>>)ｽｸﾛｰﾙ
            cmdChgSeqNum.Enabled = False                '処理順変更
            cmdRegist.Enabled = False                   '号機設定
            cmdLotDetail.Enabled = False                'ﾛｯﾄ情報詳細表示
            cmdDummyDisCharge.Enabled = False           'ﾀﾞﾐｰｷｬﾘｱ払出
            cmdLotConnectedInfoDisp.Enabled = False     'TFT/CF紐付情報表示

            '@基板(1A0)起動か
            If pstrSBID = CPstrSBID1A0 Then

                '@各ﾎﾞﾀﾝの初期化
                cmdShip.Enabled = False
                cmdLotConnectedInfoDisp.Visible = False
                
        '@↓2012/04/06 (Fri) 15:56:30 Y.Yoneyama **************************************************
                '@ｽﾄｯｶｰｺﾝﾎﾞ関連設定
                lblTitle10.Text = CMstrlblTitle10Stocker
                lblTitle10.Width = CMlnglblTitle10Stocker
                cmbStockerName.Enabled = False
                cmbStockerName.Visible = True
                cmbStockerName.Width = lblTitle10.Width
                
                '@BCRｷｬﾘｱID関連設定
                txtBCRCarrier.Visible = False
                
        '@↑2012/04/06 (Fri) 15:56:30 Y.Yoneyama **************************************************
                
            '@基板(1A0)起動以外の場合(現在は組立(2A0)が対象)
            Else

                '@各種ｺﾝﾄﾛｰﾙを非表示・無効にする
                cmdShip.Visible = False                 '出庫指示ﾎﾞﾀﾝ
                
        '@↓2012/04/06 (Fri) 15:57:05 Y.Yoneyama **************************************************
                '@ｽﾄｯｶｰｺﾝﾎﾞ関連設定
                cmbStockerName.Visible = False

                '@BCRｷｬﾘｱID関連設定
                lblTitle10.Text = CMstrlblTitle10BCRCarrier
                lblTitle10.Width = CMlnglblTitle10BCRCarrier
                txtBCRCarrier.Visible = True
                txtBCRCarrier.Width = lblTitle10.Width
                txtBCRCarrier.Left = lblTitle10.Left
        '@↑2012/04/06 (Fri) 15:57:05 Y.Yoneyama **************************************************
            End If

            '@閉じるﾎﾞﾀﾝのCausesValidationを設定(False：ﾌｫｰｶｽLost時に入力ﾁｪｯｸをしない)
            cmdClose.CausesValidation = False
            
        '@↓2012/04/19 (Thu) 17:04:01 Y.Yoneyama **************************************************
            '@BCRｷｬﾘｱ照合ﾌﾗｸﾞ初期化
            pblnfrmxxEN0150BCR = False
        '@↑2012/04/19 (Thu) 17:04:01 Y.Yoneyama **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvFrmxxEN0150_Init"    '処理名
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
    '作成日：2005/04/12 (Tue) 15:22:08 N.Kasai
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：ﾃﾞｰﾀが0件の場合に装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞﾃﾞｰﾀをｸﾘｱする
    '　　　：2005/04/19 (Tue) 10:54:05 N.Kojima     ﾊﾞｯﾁS1運用対応(ﾀﾞﾐｰｷｬﾘｱ払出ﾎﾞﾀﾝ制御)
    '　　　：2005/06/23 (Thu) 18:01:20 N.Kojima     ｺﾒﾝﾄ行削除(ﾀﾞﾐｰ対応)
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub prvVsfAreaEquipment_Clr()

        Try

            With vsfAreaEquipment

                .Rows.Count = .Rows.Fixed '行数
                .Enabled = False          '無効

                '@ﾕｰｻﾞｰﾘｻｲｽﾞが実施されていないか
                If mtypChgSort.blnChgWidth = False Then

                    '@自動で列幅を調整する
                    '.AutoSizeMode = flexAutoSizeColWidth
                    .AutoSizeCols(mlngvsfAreaEqColNo, .Cols.Count - 1, 6)
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

            '@各種ﾎﾞﾀﾝの無効化
            cmdChgSeqNum.Enabled = False            '処理順変更
            cmdRegist.Enabled = False               '号機指定
            cmdShip.Enabled = False                 '出庫指示
            cmdDummyDisCharge.Enabled = False       'ﾀﾞﾐｰｷｬﾘｱ払出

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
    '作成日：2004/04/13 (Tue) 14:16:34 M.Matsuura
    '更新日：2016/02/09 (Tue) 00:11:54 H.Hayashi
    '備　考：
    '　　　：2004/09/26 (Sun) 14:03:23 N.Kasai　    引継ぎ構造体にｱﾝﾛｰﾀﾞｷｬﾘｱIDを追加
    '　　　：2004/09/27 (Mon) 10:37:00 N.Kasai　    代替番号追加
    '　　　：2004/10/14 (Thu) 10:47:56 M.Miura　    列幅変更条件追加
    '　　　：2004/10/18 (Mon) 11:35:47 N.Kasai      ﾘﾜｰｸﾌﾗｸﾞ追加
    '　　　：2004/11/05 (Fri) 20:00:17 N.Kojima　   出庫指示機能追加に伴い、ｷｬﾘｱ位置・ｷｬﾘｱ状態追加
    '　　　：2004/11/26 (Fri) 17:35:12 S.Deguchi    隠し列の設定をｺｰﾄﾞに明文化
    '　　　：2005/02/02 (Wed) 17:21:48 H.Wajima     ｴﾗｰ処理追加
    '　　　：2005/03/02 (Wed) 09:54:50 N.Kojima　   稼動状態ﾗﾍﾞﾙ削除に伴う修正(改善№524、525)
    '　　　：2006/07/04 (Tue) 11:23:33 T.Kitagawa　 WFID("#01,#02,#03,#04,#05")のｶﾗﾑ追加(ﾕｰｻﾞ要望№0213)
    '　　　：2007/10/15 (Mon) 11:00:39 N.Kojima     処理順ﾙｰﾙ追加に伴う修正。(案件№02152)
    '　　　：2008/06/11 (Wed) 14:28:36 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     機種列の初期化処理追加、ついでにｿｰｽ整備。(案件№03611)
    '　　　：2009/10/05 (Mon) 12:56:36 N.Kojima     蒸着ﾊﾞｯﾁID、CF/LP/VAﾌﾗｸﾞ、TPAL区分列追加に伴う修正。(案件№03791)
    '　　　：2010/03/03 (Wed) 17:35:35 N.Kojima     処理可能ﾚｼﾋﾟﾌﾗｸﾞ列追加に伴う修正。(案件№03897)
    '　　　：2012/01/20 (Fri) 15:56:42 T.Oide       基板と組立のカラム順変更対応
    '　　　：2013/01/29 (Tue) 13:52:50 Y.Yoneyama   ﾛｯﾄ進捗度表示
    '      ：2015/11/20 (Fri) 16:29:27 H.Hayashi    千歳Spirytus_Prism処理チャンバー選択機能(H31096937)
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Private Sub prvVsfAreaEquipment_Init()

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try

            '@装置状態関連ﾗﾍﾞﾙの初期化
            lblYouto.Text = vbNullString                 '用途
            lblMode.Text = vbNullString                  'ﾓｰﾄﾞ
            lblWpStatusName.Text = vbNullString          '処理状態
            lblRecipeRule.Text = vbNullString            '処理順ﾙｰﾙ

            With vsfAreaEquipment

                .Redraw = False                             '描画ﾛｯｸ
                .Clear                                      'ｸﾘｱ
                'NSYS 不要なHanlder実行を抑止
                RemoveHandler vsfAreaEquipment.BeforeRowColChange,AddressOf vsfAreaEquipment_BeforeRowColChange
                RemoveHandler vsfAreaEquipment.EnterCell,AddressOf vsfAreaEquipment_EnterCell
                .Rows.Count = .Rows.Fixed                   '初期行数設定
                .Row = 0                                    'NSYS 初期選択行をヘッダーに設定
                'Handler抑止解除
                AddHandler vsfAreaEquipment.BeforeRowColChange,AddressOf vsfAreaEquipment_BeforeRowColChange
                AddHandler vsfAreaEquipment.EnterCell,AddressOf vsfAreaEquipment_EnterCell
                .AllowResizing = AllowResizingEnum.Columns         '行列のﾏｳｽでの変更を可にする
                '.FillStyle = flexFillRepeat                       'ﾌﾟﾛﾊﾟﾃｨの設定対象を選択されたｾﾙに設定
                '.AllowBigSelection = False                        'ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '.AllowSelection = False                           'ﾏｳｽでｾﾙ範囲選択不可
                .SelectionMode = SelectionModeEnum.Row             'ｾﾙ選択の設定
                '.Styles.Normal.Trimming = StringTrimming.Character '省略符号(...)を文字列の最後に表示
                .HighLight = HighLightEnum.Always                  'ﾊｲﾗｲﾄ表示
                .FocusRect = FocusRectEnum.Light                   'ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .Styles.Fixed.WordWrap = False                     'NSYS ソート時のタイトル行の表示状態対策
                .Styles.Normal.WordWrap = True                     '折り返し表示                               '時間制限、WF_IDを折り返し表示することが目的

                '@列並び順設定
                If pstrSBID = CPstrSBID1A0 Then
                    
                    .Cols.Frozen = CMlngvsfFrozenCols_1A0    '固定列の設定

                    '@1A0基板の並び
                    mlngvsfAreaEqColNo = CPlngvsfAreaEqCol_1A0_No                                      '№
                    mlngvsfAreaEqColKb = CPlngvsfAreaEqCol_1A0_Kb                                      '保/停区分
                    mlngvsfAreaEqColShipDiffDay = CPlngvsfAreaEqCol_1A0_ShipDiffDay                    '進捗度
                    mlngvsfAreaEqColNowSt = CPlngvsfAreaEqCol_1A0_NowSt                                'ﾛｯﾄ状態
                    mlngvsfAreaEqColLimitTime = CPlngvsfAreaEqCol_1A0_LimitTime                        '時間制限
                    mlngvsfAreaEqColPriority = CPlngvsfAreaEqCol_1A0_Priority                          '優先順位
                    mlngvsfAreaEqColLotID = CPlngvsfAreaEqCol_1A0_LotID                                'ﾛｯﾄID(col変更時はbasxxEN150も同じく修正する必要あり)
                    mlngvsfAreaEqColGrbClass = CPlngvsfAreaEqCol_1A0_GrbClass                          'GRB区分
                    mlngvsfAreaEqColCarrierID = CPlngvsfAreaEqCol_1A0_CarrierID                        'ｷｬﾘｱID(col変更時はbasxxEN150も同じく修正する必要あり)
                    mlngvsfAreaEqColWfNum = CPlngvsfAreaEqCol_1A0_WfNum                                'WF枚数
                    mlngvsfAreaEqColRecipe = CPlngvsfAreaEqCol_1A0_Recipe                              'ﾚｼﾋﾟ
                    mlngvsfAreaEqColOpID = CPlngvsfAreaEqCol_1A0_OpID                                  '大工程(col変更時はbasxxEN150も同じく修正する必要あり)
                    mlngvsfAreaEqColStepID = CPlngvsfAreaEqCol_1A0_StepID                              '小工程(col変更時はbasxxEN150も同じく修正する必要あり)
                    mlngvsfAreaEqColLotManagerName = CPlngvsfAreaEqCol_1A0_LotManagerName              'ﾛｯﾄ担当
                    mlngvsfAreaEqColCarrierPositionName = CPlngvsfAreaEqCol_1A0_CarrierPositionName    'ｷｬﾘｱ位置
                    mlngvsfAreaEqColCarrierStatusName = CPlngvsfAreaEqCol_1A0_CarrierStatusName        'ｷｬﾘｱ状態
                    mlngvsfAreaEqColFlowClass = CPlngvsfAreaEqCol_1A0_FlowClass                        '種別
                    mlngvsfAreaEqColChipNum = CPlngvsfAreaEqCol_1A0_ChipNum                            'ﾁｯﾌﾟ数
                    mlngvsfAreaEqColDispatchStartTime = CPlngvsfAreaEqCol_1A0_DispatchStartTime        '処理開始予実
                    mlngvsfAreaEqColLotComments = CPlngvsfAreaEqCol_1A0_LotComments                    'ｺﾒﾝﾄ
                    mlngvsfAreaEqColWfId = CPlngvsfAreaEqCol_1A0_WfId                                  'WFIDの下3桁の結合("#01,#02,#03,#04,#05")
                    mlngvsfAreaEqColCommitFlag = CPlngvsfAreaEqCol_1A0_CommitFlag                      '号機指定(1：指定0：指定なし)
                    mlngvsfAreaEqColLCarrierID = CPlngvsfAreaEqCol_1A0_LCarrierID                      'ﾛｰﾀﾞｷｬﾘｱID(ｷｬﾘｱID引継ぎに使用)
                    mlngvsfAreaEqColUCarrierID = CPlngvsfAreaEqCol_1A0_UCarrierID                      'ｱﾝﾛｰﾀﾞｷｬﾘｱID(ｷｬﾘｱID引継ぎに使用)
                    mlngvsfAreaEqColAltNumber = CPlngvsfAreaEqCol_1A0_AltNumber                        '代替番号
                    mlngvsfAreaEqColLotLastUpdate = CPlngvsfAreaEqCol_1A0_LotLastUpdate                'ﾛｯﾄ最終更新日付
                    mlngvsfAreaEqColReworkFlag = CPlngvsfAreaEqCol_1A0_ReworkFlag                      'ﾘﾜｰｸﾌﾗｸﾞ(1:ﾘﾜｰｸあり0:ﾘﾜｰｸなし)
                    mlngvsfAreaEqColCarrierPositionID = CPlngvsfAreaEqCol_1A0_CarrierPositionID        'ｷｬﾘｱ位置ID
                    mlngvsfAreaEqColCarrierStatusID = CPlngvsfAreaEqCol_1A0_CarrierStatusID            'ｷｬﾘｱ状態ID
                    mlngvsfAreaEqColPdID = CPlngvsfAreaEqCol_1A0_PdID                                  '機種(col変更時はbasxxEN150も同じく修正する必要あり)
                    mlngvsfAreaEqColJBatchID = CPlngvsfAreaEqCol_1A0_JBatchID                          '蒸着ﾊﾞｯﾁID
                    mlngvsfAreaEqColCfFlag = CPlngvsfAreaEqCol_1A0_CfFlag                              'CFﾌﾗｸﾞ
                    mlngvsfAreaEqColLpFlag = CPlngvsfAreaEqCol_1A0_LpFlag                              'LPﾌﾗｸﾞ
                    mlngvsfAreaEqColVaFlag = CPlngvsfAreaEqCol_1A0_VaFlag                              '無機ﾌﾗｸﾞ
                    mlngvsfAreaEqColTpalClass = CPlngvsfAreaEqCol_1A0_TpalClass                        'TPAL区分
                    mlngvsfAreaEqColHBatchID = CPlngvsfAreaEqCol_1A0_HBatchID                          '表面ﾊﾞｯﾁID
                    mlngvsfAreaEqColFrFlag = CPlngvsfAreaEqCol_1A0_FrFlag                              'FRﾚｼﾋﾟ有無ﾌﾗｸﾞ
                    mlngvsfAreaEqColColorCd = CPlngvsfAreaEqCol_1A0_ColorCd                            '指定色
                Else
                
                    .Cols.Frozen = CMlngvsfFrozenCols_2A0    '固定列の設定

                    '@2A0組立の並び
                    mlngvsfAreaEqColNo = CPlngvsfAreaEqCol_2A0_No                                      '№
                    mlngvsfAreaEqColKb = CPlngvsfAreaEqCol_2A0_Kb                                      '保/停区分
                    mlngvsfAreaEqColNowSt = CPlngvsfAreaEqCol_2A0_NowSt                                'ﾛｯﾄ状態
                    mlngvsfAreaEqColLimitTime = CPlngvsfAreaEqCol_2A0_LimitTime                        '時間制限
                    mlngvsfAreaEqColRecipe = CPlngvsfAreaEqCol_2A0_Recipe                              'ﾚｼﾋﾟ
                    mlngvsfAreaEqColPdID = CPlngvsfAreaEqCol_2A0_PdID                                  '機種(col変更時はbasxxEN150も同じく修正する必要あり)
                    mlngvsfAreaEqColCarrierID = CPlngvsfAreaEqCol_2A0_CarrierID                        'ｷｬﾘｱID(col変更時はbasxxEN150も同じく修正する必要あり)
                    mlngvsfAreaEqColLotID = CPlngvsfAreaEqCol_2A0_LotID                                'ﾛｯﾄID(col変更時はbasxxEN150も同じく修正する必要あり)
                    mlngvsfAreaEqColWfId = CPlngvsfAreaEqCol_2A0_WfId                                  'WFIDの下3桁の結合("#01,#02,#03,#04,#05")
                    mlngvsfAreaEqColWfNum = CPlngvsfAreaEqCol_2A0_WfNum                                'WF枚数
                    mlngvsfAreaEqColChipNum = CPlngvsfAreaEqCol_2A0_ChipNum                            'ﾁｯﾌﾟ数
                    mlngvsfAreaEqColFlowClass = CPlngvsfAreaEqCol_2A0_FlowClass                        '種別
                    mlngvsfAreaEqColCarrierPositionName = CPlngvsfAreaEqCol_2A0_CarrierPositionName    'ｷｬﾘｱ位置
                    mlngvsfAreaEqColCarrierStatusName = CPlngvsfAreaEqCol_2A0_CarrierStatusName        'ｷｬﾘｱ状態
                    mlngvsfAreaEqColPriority = CPlngvsfAreaEqCol_2A0_Priority                          '優先順位
                    mlngvsfAreaEqColOpID = CPlngvsfAreaEqCol_2A0_OpID                                  '大工程(col変更時はbasxxEN150も同じく修正する必要あり)
                    mlngvsfAreaEqColStepID = CPlngvsfAreaEqCol_2A0_StepID                              '小工程(col変更時はbasxxEN150も同じく修正する必要あり)
                    mlngvsfAreaEqColDispatchStartTime = CPlngvsfAreaEqCol_2A0_DispatchStartTime        '処理開始予実
                    mlngvsfAreaEqColLotManagerName = CPlngvsfAreaEqCol_2A0_LotManagerName              'ﾛｯﾄ担当
                    mlngvsfAreaEqColLotComments = CPlngvsfAreaEqCol_2A0_LotComments                    'ｺﾒﾝﾄ
                    mlngvsfAreaEqColLCarrierID = CPlngvsfAreaEqCol_2A0_LCarrierID                      'ﾛｰﾀﾞｷｬﾘｱID(ｷｬﾘｱID引継ぎに使用)
                    mlngvsfAreaEqColUCarrierID = CPlngvsfAreaEqCol_2A0_UCarrierID                      'ｱﾝﾛｰﾀﾞｷｬﾘｱID(ｷｬﾘｱID引継ぎに使用)
                    mlngvsfAreaEqColCommitFlag = CPlngvsfAreaEqCol_2A0_CommitFlag                      '号機指定(1：指定0：指定なし)
                    mlngvsfAreaEqColAltNumber = CPlngvsfAreaEqCol_2A0_AltNumber                        '代替番号
                    mlngvsfAreaEqColLotLastUpdate = CPlngvsfAreaEqCol_2A0_LotLastUpdate                'ﾛｯﾄ最終更新日付
                    mlngvsfAreaEqColReworkFlag = CPlngvsfAreaEqCol_2A0_ReworkFlag                      'ﾘﾜｰｸﾌﾗｸﾞ(1:ﾘﾜｰｸあり0:ﾘﾜｰｸなし)
                    mlngvsfAreaEqColCarrierPositionID = CPlngvsfAreaEqCol_2A0_CarrierPositionID        'ｷｬﾘｱ位置ID
                    mlngvsfAreaEqColCarrierStatusID = CPlngvsfAreaEqCol_2A0_CarrierStatusID            'ｷｬﾘｱ状態ID
                    mlngvsfAreaEqColJBatchID = CPlngvsfAreaEqCol_2A0_JBatchID                          '蒸着ﾊﾞｯﾁID
                    mlngvsfAreaEqColCfFlag = CPlngvsfAreaEqCol_2A0_CfFlag                              'CFﾌﾗｸﾞ
                    mlngvsfAreaEqColLpFlag = CPlngvsfAreaEqCol_2A0_LpFlag                              'LPﾌﾗｸﾞ
                    mlngvsfAreaEqColVaFlag = CPlngvsfAreaEqCol_2A0_VaFlag                              '無機ﾌﾗｸﾞ
                    mlngvsfAreaEqColTpalClass = CPlngvsfAreaEqCol_2A0_TpalClass                        'TPAL区分
                    mlngvsfAreaEqColHBatchID = CPlngvsfAreaEqCol_2A0_HBatchID                          '表面ﾊﾞｯﾁID
                    mlngvsfAreaEqColShipDiffDay = CPlngvsfAreaEqCol_2A0_ShipDiffDay                     '進捗度
                    mlngvsfAreaEqColFrFlag = CPlngvsfAreaEqCol_2A0_FrFlag                              'FRﾚｼﾋﾟ有無ﾌﾗｸﾞ
                    mlngvsfAreaEqColGrbClass = CPlngvsfAreaEqCol_2A0_GrbClass                          'GRB区分
                    mlngvsfAreaEqColColorCd = CPlngvsfAreaEqCol_2A0_ColorCd                            '指定色
                End If

                '@一覧表の表題設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_vsfAreaEquipment_Header")
                Dim cellRange As CellRange = .GetCellRange(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColNo, CMlngvsfAreaEqRowTitle, .Cols.Count - 1)
                newStyle.ForeColor = Color.Yellow                              '文字色
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor) '背景色
                newStyle.TextAlign = TextAlignEnum.CenterCenter                '@表示位置の設定
                newStyle.Font = New Font(.Font.FontFamily, CMlngvsfAreaEqHFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont) 'ﾌｫﾝﾄｻｲｽﾞ
                cellRange.Style = newStyle

                '@ﾕｰｻﾞｰﾘｻｲｽﾞが行われていないか(False：未変更)
                If mtypChgSort.blnChgWidth = False Then

                    '@列幅設定
                    .Cols(mlngvsfAreaEqColNo).Width = CMlngvsfAreaEqColWNo
                    .Cols(mlngvsfAreaEqColKb).Width = CMlngvsfAreaEqColWKb
                    .Cols(mlngvsfAreaEqColNowSt).Width = CMlngvsfAreaEqColWNowSt
                    .Cols(mlngvsfAreaEqColLimitTime).Width = CMlngvsfAreaEqColWLimitTime
                    .Cols(mlngvsfAreaEqColLotID).Width = CMlngvsfAreaEqColWLotID
                    .Cols(mlngvsfAreaEqColPdID).Width = CMlngvsfAreaEqColWPdID
                    .Cols(mlngvsfAreaEqColFlowClass).Width = CMlngvsfAreaEqColWFlowClass
                    .Cols(mlngvsfAreaEqColWfId).Width = CMlngvsfAreaEqColWWfID
                    .Cols(mlngvsfAreaEqColCarrierID).Width = CMlngvsfAreaEqColWCarrierID                                                 'ｷｬﾘｱID
                    .Cols(mlngvsfAreaEqColCarrierPositionName).Width = CMlngvsfAreaEqColWCarrierPositionName                             'ｷｬﾘｱ位置
                    .Cols(mlngvsfAreaEqColCarrierStatusName).Width = CMlngvsfAreaEqColWCarrierStatusName                                 'ｷｬﾘｱ状態
                    .Cols(mlngvsfAreaEqColPriority).Width = CMlngvsfAreaEqColWPriority
                    .Cols(mlngvsfAreaEqColOpID).Width = CMlngvsfAreaEqColWOpID
                    .Cols(mlngvsfAreaEqColStepID).Width = CMlngvsfAreaEqColWStepID
                    .Cols(mlngvsfAreaEqColRecipe).Width = CMlngvsfAreaEqColWRecipe
                    .Cols(mlngvsfAreaEqColDispatchStartTime).Width = CMlngvsfAreaEqColWDispatchStartTime
                    .Cols(mlngvsfAreaEqColLotManagerName).Width = CMlngvsfAreaEqColWLotManagerName
                    .Cols(mlngvsfAreaEqColWfNum).Width = CMlngvsfAreaEqColWWfNum
                    .Cols(mlngvsfAreaEqColChipNum).Width = CMlngvsfAreaEqColWChipNum
                    .Cols(mlngvsfAreaEqColLotComments).Width = CMlngvsfAreaEqColWLotComments
                    .Cols(mlngvsfAreaEqColCommitFlag).Width = CMlngvsfAreaEqColWCommitFlag
                    .Cols(mlngvsfAreaEqColLCarrierID).Width = CMlngvsfAreaEqColWLCarrierID
                    .Cols(mlngvsfAreaEqColUCarrierID).Width = CMlngvsfAreaEqColWUCarrierID
                    .Cols(mlngvsfAreaEqColAltNumber).Width = CMlngvsfAreaEqColWAltNumber
                    .Cols(mlngvsfAreaEqColLotLastUpdate).Width = CMlngvsfAreaEqColWLotLastUpdate
                    .Cols(mlngvsfAreaEqColReworkFlag).Width = CMlngvsfAreaEqColWReworkFlag
                    .Cols(mlngvsfAreaEqColJBatchID).Width = CMlngvsfAreaEqColWJBatchID
                    .Cols(mlngvsfAreaEqColCfFlag).Width = CMlngvsfAreaEqColWCfFlag
                    .Cols(mlngvsfAreaEqColLpFlag).Width = CMlngvsfAreaEqColWLpFlag
                    .Cols(mlngvsfAreaEqColVaFlag).Width = CMlngvsfAreaEqColWVaFlag
                    .Cols(mlngvsfAreaEqColTpalClass).Width = CMlngvsfAreaEqColWTpalClass
                    .Cols(mlngvsfAreaEqColHBatchID).Width = CMlngvsfAreaEqColWHBatchID
                    .Cols(mlngvsfAreaEqColShipDiffDay).Width = CMlngvsfAreaEqColWShipDiffDay
                    .Cols(mlngvsfAreaEqColFrFlag).Width = CMlngvsfAreaEqColWFrFlag
                    .Cols(mlngvsfAreaEqColGrbClass).Width = CMlngvsfAreaEqColWGrbClass
                    .Cols(mlngvsfAreaEqColColorCd).Width = CMlngvsfAreaEqColWColorCd

                End If

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColNo, CMstrvsfAreaEqColTNo)                                   'No.
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColNowSt, CMstrvsfAreaEqColTNowSt)                             '状態
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColLimitTime, CMstrvsfAreaEqColTLimitTime)                     '時
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColLotID, CMstrvsfAreaEqColTLotID)                             'ﾛｯﾄID
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColPdID, CMstrvsfAreaEqColTPdID)                               '機種
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColFlowClass, CMstrvsfAreaEqColTFlowClass)                     '種別
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColWfId, CMstrvsfAreaEqColTWfID)                               'WD_ID
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColCarrierID, CMstrvsfAreaEqColTCarrierID)                     'ｷｬﾘｱID
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColCarrierPositionName, CMstrvsfAreaEqColTCarrierPosition)     'ｷｬﾘｱ位置
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColCarrierStatusName, CMstrvsfAreaEqColTCarrierStatus)         'ｷｬﾘｱ状態
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColPriority, CMstrvsfAreaEqColTPriority)                       '優先度
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColOpID, CMstrvsfAreaEqColTOpID)                               '大工程
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColStepID, CMstrvsfAreaEqColTStepID)                           '小工程
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColRecipe, CMstrvsfAreaEqColTRecipe)                           'ﾚｼﾋﾟ
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColDispatchStartTime, CMstrvsfAreaEqColTDispatchStartTime)     '開始時間
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColLotManagerName, CMstrvsfAreaEqColTLotManagerName)           'ﾛｯﾄ担当
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColWfNum, CMstrvsfAreaEqColTWfNum)                             'WF枚数
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColChipNum, CMstrvsfAreaEqColTChipNum)                         'ﾁｯﾌﾟ数
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColLotComments, CMstrvsfAreaEqColTLotComments)                 'ｺﾒﾝﾄ
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColCommitFlag, CMstrvsfAreaEqColTCommitFlag)                   '号機指定
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColLCarrierID, CMstrvsfAreaEqColTLCarrierID)                   'ﾛｰﾀﾞｷｬﾘｱID
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColUCarrierID, CMstrvsfAreaEqColTUCarrierID)                   'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColAltNumber, CMstrvsfAreaEqColTAltNumber)                     '代替番号
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColLotLastUpdate, CMstrvsfAreaEqColTLotLastUpdate)             'ﾛｯﾄ最終更新日付
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColReworkFlag, CMstrvsfAreaEqColTReworkFlag)                   'ﾘﾜｰｸﾌﾗｸﾞ
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColJBatchID, CMstrvsfAreaEqColTJBatchID)                       '蒸着ﾊﾞｯﾁID
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColCfFlag, CMstrvsfAreaEqColTCfFlag)                           'CFﾌﾗｸﾞ
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColLpFlag, CMstrvsfAreaEqColTLpFlag)                           'LPﾌﾗｸﾞ
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColVaFlag, CMstrvsfAreaEqColTVaFlag)                           '無機ﾌﾗｸﾞ
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColTpalClass, CMstrvsfAreaEqColTTpalClass)                     'TPAL区分
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColHBatchID, CMstrvsfAreaEqColTHBatchID)                       '表面ﾊﾞｯﾁID
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColShipDiffDay, CMstrvsfAreaEqColTShipDiffDay)                  '進捗度
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColFrFlag, CMstrvsfAreaEqColTFrFlag)                            'FRﾚｼﾋﾟ有無ﾌﾗｸﾞ
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColGrbClass, CMstrvsfAreaEqColTGrbClass)                        'GRB区分
                .SetData(CMlngvsfAreaEqRowTitle, mlngvsfAreaEqColColorCd, CMstrvsfAreaEqColTColorCd)                          '指定色
                
                '@Cellの表示位置設定(デフォルト右上)
                For llngCnt = 0 To .Cols.Count - 1
                    .Cols(llngCnt).TextAlign = TextAlignEnum.LeftCenter
                Next
                
                '@以下は個別設定
                .Cols(mlngvsfAreaEqColNo).TextAlign = TextAlignEnum.RightCenter                    '右詰の中央揃え(ｽﾛｯﾄ№)
                .Cols(mlngvsfAreaEqColCarrierPositionName).TextAlign = TextAlignEnum.LeftCenter    '左詰の中央揃え(ｷｬﾘｱ位置)
                .Cols(mlngvsfAreaEqColCarrierStatusName).TextAlign = TextAlignEnum.LeftCenter      '左詰の中央揃え(ｷｬﾘｱ状態)
                .Cols(mlngvsfAreaEqColLimitTime).TextAlign = TextAlignEnum.LeftCenter              '左詰の中央揃え(制限時間)
                .Cols(mlngvsfAreaEqColFlowClass).TextAlign = TextAlignEnum.LeftCenter              '左詰の中央揃え(種別)
                .Cols(mlngvsfAreaEqColWfId).TextAlign = TextAlignEnum.LeftCenter                   '左詰の中央揃え(WFID)
                .Cols(mlngvsfAreaEqColPriority).TextAlign = TextAlignEnum.RightCenter              '右詰の中央揃え(優先順位)
                .Cols(mlngvsfAreaEqColLotComments).TextAlign = TextAlignEnum.LeftCenter            '左詰の中央揃え(ｺﾒﾝﾄ)
                .Cols(mlngvsfAreaEqColWfNum).TextAlign = TextAlignEnum.RightCenter                 '右詰の中央揃え(WF枚数)
                .Cols(mlngvsfAreaEqColChipNum).TextAlign = TextAlignEnum.RightCenter               '右詰の中央揃え(ﾁｯﾌﾟ数)
                .Cols(mlngvsfAreaEqColChipNum).Format = CPstrCFKnmaFormat                          'NSYS チップ数のフォーマット
                .Cols(mlngvsfAreaEqColShipDiffDay).TextAlign = TextAlignEnum.RightCenter           '右詰の中央揃え(進捗度)
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngvsfAreaEqRowTitle).Height = CMlngvsfAreaEqHHeight

                '@ﾕｰｻﾞｰﾘｻｲｽﾞが行われていないか(False：未変更)
                If mtypChgSort.blnChgWidth = False Then

                    '@列幅の自動調整を行う
                    '.AutoSizeMode = flexAutoSizeColWidth
                    .AutoSizeCols(mlngvsfAreaEqColNo, .Cols.Count - 1, 6)
                End If

                '@非表示設定
                .Cols(mlngvsfAreaEqColCommitFlag).Visible = False          '号機指定
                .Cols(mlngvsfAreaEqColLCarrierID).Visible = False          'ﾛｰﾀﾞｷｬﾘｱID
                .Cols(mlngvsfAreaEqColUCarrierID).Visible = False          'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                .Cols(mlngvsfAreaEqColAltNumber).Visible = False           '代替番号
                .Cols(mlngvsfAreaEqColLotLastUpdate).Visible = False       'ﾛｯﾄ最終更新日付
                .Cols(mlngvsfAreaEqColReworkFlag).Visible = False          'ﾘﾜｰｸﾌﾗｸﾞ
                .Cols(mlngvsfAreaEqColCarrierPositionID).Visible = False   'ｷｬﾘｱ位置ID
                .Cols(mlngvsfAreaEqColCarrierStatusID).Visible = False     'ｷｬﾘｱ状態ID
                .Cols(mlngvsfAreaEqColJBatchID).Visible = False            '蒸着ﾊﾞｯﾁID
                .Cols(mlngvsfAreaEqColCfFlag).Visible = False              'CFﾌﾗｸﾞ
                .Cols(mlngvsfAreaEqColLpFlag).Visible = False              'LPﾌﾗｸﾞ
                .Cols(mlngvsfAreaEqColVaFlag).Visible = False              '無機ﾌﾗｸﾞ
                .Cols(mlngvsfAreaEqColTpalClass).Visible = False           'TPAL区分
                .Cols(mlngvsfAreaEqColHBatchID).Visible = False            '表面ﾊﾞｯﾁID
                .Cols(mlngvsfAreaEqColFrFlag).Visible = False              'FRﾚｼﾋﾟ有無ﾌﾗｸﾞ
                .Cols(mlngvsfAreaEqColColorCd).Visible = False             '指定色

                '@起動SBが組立(2A0)か(表示判定：機種、WFID列は組立工程の場合のみ表示する)
                If pstrSBID = CPstrSBID2A0 Then

                    .Cols(mlngvsfAreaEqColPdID).Visible = True             '機種
                    .Cols(mlngvsfAreaEqColWfId).Visible = True             'WFID
                    .Cols(mlngvsfAreaEqColShipDiffDay).Visible = False     '進捗度
                    .Cols(mlngvsfAreaEqColGrbClass).Visible = False        'GRB区分

                Else

                    .Cols(mlngvsfAreaEqColPdID).Visible = False            '機種
                    .Cols(mlngvsfAreaEqColWfId).Visible = False            'WFID
                    .Cols(mlngvsfAreaEqColShipDiffDay).Visible = True      '進捗度
                    .Cols(mlngvsfAreaEqColGrbClass).Visible = True         'GRB区分
                    
                End If

                .Cols(mlngvsfAreaEqColShipDiffDay).DataType = GetType(Single)   'NSYS 進捗度列のDataTypeを設定
                .Cols(mlngvsfAreaEqColShipDiffDay).Format = "##0.0"             'NSYS 進捗度列のフォーマットを設定

                '@直接表示
                .Redraw = True

                '@ﾛｯｸ
                .Enabled = False

            End With


            '@各種ﾗﾍﾞﾙの初期化
            lblNowDate.Text = vbNullString       '情報取得日時
            lblLotCnt.Text = vbNullString        '該当件数

            '@各種ﾎﾞﾀﾝを無効にする
            cmdLeft.Enabled = False                 '左(<<)ｽｸﾛｰﾙ
            cmdRight.Enabled = False                '右(>>)ｽｸﾛｰﾙ
            cmdUP.Enabled = False                   '上(▲)ｽｸﾛｰﾙ
            cmdDown.Enabled = False                 '下(▼)ｽｸﾛｰﾙ
            cmdChgSeqNum.Enabled = False            '処理順変更
            cmdRegist.Enabled = False               '号機指定

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
    '引　数：ltypLotList    ：ﾛｯﾄ一覧格納構造体
    '　　　：ltypEqstate    ：装置状態構造体
    '戻り値：なし
    '作成日：2004/09/23 (Thu) 09:56:29 N.Kasai
    '更新日：2010/03/11 (Thu) 17:08:03 N.Kojima
    '備　考：
    '　　　：2004/11/08 (Mon) 16:59:41 N.Kojima　　 出庫指示機能追加に伴い、運用ﾓｰﾄﾞにより出庫指示ﾎﾞﾀﾝの有効・無効を制御
    '　　　：2004/11/29 (Mon) 14:01:48 N.Kojima　　 運用ﾓｰﾄﾞにより出庫指示ﾎﾞﾀﾝの有効・無効制御処理削除
    '　　　：2005/02/02 (Wed) 17:27:08 H.Wajima  　 ｴﾗｰ処理追加
    '　　　：2005/03/02 (Wed) 09:54:50 N.Kojima　　 稼動状態ﾗﾍﾞﾙ削除に伴う修正(改善№524、525)
    '　　　：2005/09/06 (Tue) 09:33:30 T.Kitagawa　 SCHﾘﾘｰｽに伴い、Fﾓｰﾄﾞ時は処理順変更ﾎﾞﾀﾝ、号機指定ﾎﾞﾀﾝを無効にする(不具合№3092)
    '　　　：2006/09/05 (Tue) 15:55:27 T.Kitagawa   引数にltypEqstate(装置状態構造体)を追加(案件№01097)
    '　　　：2007/10/15 (Mon) 11:22:42 N.Kojima     処理順ﾙｰﾙ追加に伴い処理追加。(案件№02152)
    '　　　：2008/06/25 (Wed) 08:30:00 S.Ochiai     部分ﾚｼﾋﾟ対応(案件№03008)、及びﾒｯｾｰｼﾞ構造を抜本的に変更
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    '　　　：2009/10/20 (Tue) 10:26:59 T.Oide       搬送モード追加(案件№03761)
    '　　　：2010/03/11 (Thu) 17:08:03 N.Kojima     処理順ﾙｰﾙが"FIFO"or"FIFO限定"以外の場合は、処理順変更ﾎﾞﾀﾝを無効にする。(案件№03897)
    Private Sub prvWpStatus_Disp(ByRef ltypLotListAns As LotListAns, _
                                 ByRef ltypEqstate As Eqstate)

        Try

            '@各種ﾗﾍﾞﾙの設定
            lblYouto.Text = ltypLotListAns.strUseName                '用途
            lblMode.Text = ltypLotListAns.strMesModeId               'ﾓｰﾄﾞ
            lblWpStatusName.Text = ltypLotListAns.strWpStatusName    '処理状態

            '@★ 処理順ﾌﾗｸﾞにより処理分岐 ★
            Select Case ltypEqstate.strCollectTypeFlag

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


            '@装置運用ﾓｰﾄﾞが"F(全自動)"か
            If lblMode.Text = CPstrF Then

                '@Fﾓｰﾄﾞの場合は処理順変更ﾎﾞﾀﾝ、号機指定ﾎﾞﾀﾝは無効にする
                cmdChgSeqNum.Enabled = False
                cmdRegist.Enabled = False

                '@号機指定ﾎﾞﾀﾝのｷｬﾌﾟｼｮﾝ変更("号機設定"にする)
                cmdRegist.Text = CMstrWpName & CMstrWpInit

            Else
                '@装置運用ﾓｰﾄﾞが"F(全自動)"以外の場合

                '@=======================
                '@ 装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ選択時処理
                '@=======================
                Call vsfAreaEquipment_EnterCell(vsfAreaEquipment,New EventArgs())

        '@↓2010/03/11 (Thu) 16:35:06 N.Kojima **************************************************

        '        '@-----------------------
        '        '@ 装置の処理順指定が、「ﾚｼﾋﾟ(切替)」の場合は処理順指定を不可とする
        '        '@ ※FIFO、ﾚｼﾋﾟ(固定)の場合は処理順変更ﾎﾞﾀﾝ有効
        '        '@-----------------------
        '        '@処理ﾛｯﾄ数が数値か
        '        If IsNumeric(ltypEqstate.strRecipeFlowNum) = True Then
        '
        '            '@処理ﾛｯﾄ数が1以上か
        '            If CLng(ltypEqstate.strRecipeFlowNum) > 0 Then
        '
        '                '@処理順変更ﾎﾞﾀﾝを無効にする
        '                cmdChgSeqNum.Enabled = False
        '            Else
        '
        '                '@処理順変更ﾎﾞﾀﾝを有効にする
        '                cmdChgSeqNum.Enabled = True
        '            End If
        '
        '        Else
        '            '@処理ﾛｯﾄ数が数値以外の場合
        '
        '            '@処理順変更ﾎﾞﾀﾝを有効にする
        '            cmdChgSeqNum.Enabled = True
        '        End If

                '@-----------------------
                '@ 装置の処理順ﾙｰﾙが、"1：ﾚｼﾋﾟ(切替)、ﾚｼﾋﾟ(切替)限定の場合は、
                '@ 無条件で処理順変更を不可とする。
                '@-----------------------
                '@処理順ﾙｰﾙが"1：ﾚｼﾋﾟ(切替)"or"4：ﾚｼﾋﾟ(切替)限定"か
                If ltypEqstate.strCollectTypeFlag = CStr(CPlngNumRecipeFlowNum) Or _
                    ltypEqstate.strCollectTypeFlag = CStr(CPlngNumRecipeFlowNumSameNG) Then

                    '@[処理順変更]ﾎﾞﾀﾝを無効にする
                    cmdChgSeqNum.Enabled = False
                Else
                    '@処理順ﾙｰﾙが"1：ﾚｼﾋﾟ(切替)"or"4：ﾚｼﾋﾟ(切替)限定"以外の場合

                    '@[処理順変更]ﾎﾞﾀﾝを有効にする
                    cmdChgSeqNum.Enabled = True
                End If

        '@↑2010/03/11 (Thu) 16:35:06 N.Kojima **************************************************

            End If

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
    '作成日：2004/04/13 (Tue) 14:16:34 M.Matsuura
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2004/09/16 (Thu) 17:57:13 S.Deguchi    一覧へ変更処理
    '　　　：2005/02/02 (Wed) 17:22:31 H.Wajima     ｴﾗｰ処理追加
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub prvcmbMcGroupName_Disp(ByRef ltypMcGroupList As McGroupList)

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try

            '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞの設定
            With cmbMcGroupName

                .Clear                                                       'ｸﾘｱ
                .DispCols = CMlngCmbDispCols                                 'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColName                                'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColID                                '値取得列
                .DirectInput = False                                         'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)        'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.Font.FontFamily, CMlngCmbGridFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                               '行の高さ
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter'左寄中央揃え
                .GroupRows = ltypMcGroupList.lngMcGroupListCnt               'GroupRow=取得件数
                .BackColor = SystemColors.Window                             'NSYS 背景色設定

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
    '作成日：2004/04/14 (Wed) 15:47:15 M.Matsuura
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2004/09/15 (Wed) 14:55:06 M.Miura　    装置ｺﾝﾎﾞに装置状態追加(不具合№629)
    '　　　：2004/09/16 (Thu) 17:57:13 S.Deguchi    一覧へ変更処理
    '　　　：2004/09/15 (Wed) 14:55:06 M.Miura　    装置ｺﾝﾎﾞから装置状態削除(構造体から取得するように変更)(不具合№629)
    '　　　：2005/02/02 (Wed) 17:24:28 H.Wajima     ｴﾗｰ処理追加
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub prvcmbWpID_Disp(ByRef ltypAreaEquipmentList As List(Of AreaEquipmentList), _
                                ByVal llngAreaEqCnt As Integer)

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try

            '@装置名ｺﾝﾎﾞの設定
            With cmbWpID

                .Clear                                                       'ｸﾘｱ
                .DispCols = CMlngCmbDispCols                                 'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColName                                'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColID                                '値取得列
                .DirectInput = False                                         'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)        'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.Font.FontFamily, CMlngCmbGridFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                               '行の高さ
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter'左寄中央揃え
                .Enabled = True                                              '有効
                .GroupRows = llngAreaEqCnt                                   'GroupRow=取得件数
                .BackColor = SystemColors.Window                             'NSYS 背景色設定

                For llngCnt = 0 To llngAreaEqCnt - 1

                    '@装置名/装置ID/EQﾀｲﾌﾟ/現在のｶｳﾝﾄ数
                    .AddItem(ltypAreaEquipmentList(llngCnt).strWpName & vbTab _
                           & ltypAreaEquipmentList(llngCnt).strWpID & vbTab _
                           & ltypAreaEquipmentList(llngCnt).strEqType & vbTab & llngCnt + 1)

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

    '関数名：prvCmbStockerName_Disp
    '機　能：[ｽﾄｯｶｰ]ｺﾝﾎﾞ設定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/05 (Fri) 18:47:31 N.Kojima
    '更新日：2009/08/24 (Mon) 10:17:16 N.Kojima
    '備　考：
    '　　　：2005/02/02 (Wed) 17:25:01 H.Wajima     ｴﾗｰ処理追加
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
    Private Sub prvcmbStockerName_Disp()

        Dim llngCnt             As Integer      'ｶｳﾝﾄ
        Dim lblnDefaultFlag     As Boolean      'ﾃﾞﾌｫﾙﾄﾌﾗｸﾞ(True：ﾃﾞﾌｫﾙﾄ表示済、False：ﾃﾞﾌｫﾙﾄ未表示)

        Try

            '@ｽﾄｯｶｰｺﾝﾎﾞの設定
            With cmbStockerName

                .Clear                                                       'ｸﾘｱ
                .DispCols = CMlngCmbDispCols                                 'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColName                                'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColID                                '値取得列
                .DirectInput = False                                         'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)        'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.Font.FontFamily, CMlngCmbGridFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                               '行の高さ
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter'左寄中央揃え
                .Enabled = True                                              '有効
                .GroupRows = mlngAreaEqCnt                                   'GroupRow=取得件数
                .BackColor = SystemColors.Window                             'NSYS 背景色設定

                For llngCnt = 0 To mlngStockerListCnt - 1

                    '@ｽﾄｯｶ名/ｽﾄｯｶID/現在のｶｳﾝﾄ数
                    .AddItem(mtypStockerList(llngCnt).strStockerName & vbTab & _
                             mtypStockerList(llngCnt).strStockerId & vbTab & _
                             llngCnt + 1)

                Next llngCnt

                '@表示件数分だけ表示
                .GroupRows = llngCnt

                '@ﾘｽﾄのﾃﾞｰﾀが1件か
                If .ListCount = 1 Then

                    '@1件の場合は直接表示
                    .ListIndex = 0
                End If

                '@ﾃﾞﾌｫﾙﾄﾌﾗｸﾞの初期化
                lblnDefaultFlag = False

                For llngCnt = 0 To mlngAreaEqCnt - 1

                    '@選択装置とｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置用途情報の装置が同じか
                    If cmbWpID.Text = mtypAreaEquipmentList(llngCnt).strWpName Then

                        '@ﾃﾞﾌｫﾙﾄﾌﾗｸﾞが"False：ﾃﾞﾌｫﾙﾄ未表示"か
                        If lblnDefaultFlag = False Then

                            '@ｽﾄｯｶｺﾝﾎﾞのﾃｷｽﾄにｴﾘｱ/ｸﾞﾙｰﾌﾟ別装置用途情報のｽﾄｯｶ名を表示
                            .Text = mtypAreaEquipmentList(llngCnt).strPlaceName

                            '@ﾃﾞﾌｫﾙﾄﾌﾗｸﾞに"True：ﾃﾞﾌｫﾙﾄ表示済"をｾｯﾄ
                            lblnDefaultFlag = True
                            Exit For
                        End If
                    End If
                Next llngCnt

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvCmbStockerName_Disp"     '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfAreaEquipment_Disp
    '機　能：[装置仕掛ﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ表示処理
    '引　数：ltypLotListAns         ：格納ﾃﾞｰﾀ
    '　　　：llngLotListCnt         ：ﾃﾞｰﾀ件数
    '戻り値：なし
    '作成日：2004/04/13 (Tue) 14:16:34 M.Matsuura
    '更新日：2016/02/09 (Tue) 00:13:16 H.Hayashi
    '備　考：
    '　　　：2004/08/25 (Wed) 15:26:34 M.Miura　　　グリッド表示に時間がかかる場合に「SetFocus」でエラーになるのを
    '                                       　  　　回避する為、「DoEvents」を追加
    '　　　：2004/09/09 (Thu) 11:57:40 Y.Yamagishi  時間制限を分表示に変更(不具合改善№693)
    '　　　：2004/09/16 (Thu) 13:03:22 S.Deguchi
    '　　　：2004/09/23 (Thu) 08:50:22 N.Kasai      ｱﾝﾄﾞｰﾀﾞｷｬﾘｱIDが指定されている場合はｷｬﾘｱIDを切替表示
    '　　　：2004/09/26 (Sun) 14:01:58 N.Kasai      引継ぎ構造体にｱﾝﾛｰﾀﾞｷｬﾘｱIDを追加に伴う修正
    '　　　：2004/09/26 (Sun) 14:20:58 S.Deguchi    ｺﾒﾝﾄ有無表記の判別を"あり"かそれ以外に変更
    '　　　：2004/09/27 (Mon) 10:37:24 N.Kasai　    代替番号追加
    '　　　：2004/10/06 (Wed) 13:52:28 Y.Yamagishi　引継ぎ構造体に代替番号追加に伴う修正(不具合改善№984)
    '　　　：2004/10/07 (Thu) 11:27:12 N.Kasai      ﾛｯﾄ最終更新日付追加　№1044
    '　　　：2004/10/14 (Thu) 10:49:00 M.Miura      列幅変更、ｿｰﾄ変更条件追加
    '　　　：2004/10/25 (Mon) 10:22:55 S.Deguchi    ﾘﾜｰｸﾌﾗｸﾞを追加ﾌﾗｸﾞ対応に修正
    '　　　：2004/10/25 (Mon) 14:47:31 Y.Yamagishi  引継ぎｱﾝﾛｰﾀﾞｰｷｬﾘｱIDが設定されている場合の処理追加(不具合改善№154)
    '　　　：2004/10/25 (Mon) 16:44:02 N.Kojima     DoEvents前後処理の追加(PGﾀﾞｳﾝ防止策)。(不具合改善№97)
    '　　　：2004/10/27 (Tue) 12:01:50 S.Deguchi    DoEvents前後に画面の有効/無効処理を追加(終了ｺﾏﾝﾄﾞｴﾗｰ対応)
    '　　　：2004/11/05 (Fri) 20:01:02 N.Kojima     出庫指示機能追加に伴い、ｷｬﾘｱ位置・ｷｬﾘｱ状態の表示追加
    '　　　：2005/01/12 (Wed) 15:43:44 H.Wajima     引継ぎ装置IDの初期化処理を追加
    '　　　：2005/01/21 (Fri) 09:35:09 N.Kasai      搬送先表示用ﾀｸﾞ変更(DEST→DEST_NAME)　不具合№327
    '　　　：2005/02/02 (Wed) 14:35:55 N.Kojima     処理終了から戻った際にｶﾚﾝﾄ行が保持されるように修正(不具合№506)
    '　　　：2005/02/02 (Wed) 17:23:35 H.Wajima     ｴﾗｰ処理追加
    '　　　：2005/02/08 (Tue) 17:18:23 N.Kasai      出庫、入庫表示対応(№514)
    '　　　：2005/03/08 (Tue) 10:41:30 N.Kojima     作業開始取消時、Loaderｷｬﾘｱでの取消になるので、ｶﾚﾝﾄ行保持処理も改訂(改善№512)
    '　　　：2005/04/19 (Tue) 14:10:30 N.Kojima     ﾀﾞﾐｰ識別対応(不具合№706)
    '　　　：2005/06/06 (Mon) 10:05:06 N.Kojima     Loader/Unloader表示・引継ぎ対応(不具合№829)
    '　　　：2005/06/23 (Thu) 16:34:04 N.Kojima     ﾀﾞﾐｰ識別対応(不具合№706：装置ﾀｲﾌﾟによっての判定を追加)、ｺﾒﾝﾄ行削除(ﾀﾞﾐｰ対応部)
    '　　　：2006/05/11 (Thu) 15:50:17 T.Kitagawa   制限時間の表示を分合計から時間と分で分割表示する(#,##0時間 #0分)(ﾕｰｻﾞ要望№0186)
    '　　　：2006/06/08 (Thu) 15:13:58 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2006/07/04 (Tue) 11:37:47 T.Kitagawa   WFID("#01,#02,#03,#04,#05")のｶﾗﾑ追加(ﾕｰｻﾞ要望№0213)
    '　　　：2006/10/18 (Wed) 13:17:53 M.Miura      保/停区分の結合表示(案件№01565)
    '　　　：2007/10/15 (Mon) 11:37:30 N.Kojima     ﾚｼﾋﾟｸﾞﾙｰﾌﾟの表示処理を追加。(案件№02152)
    '　　　：2008/06/11 (Wed) 14:29:07 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2008/06/25 (Wed) 08:30:00 S.Ochiai     部分ﾚｼﾋﾟ表示対応(案件№03008)、背景色/ﾌｫﾝﾄ色/保・停区分表示ﾛｼﾞｯｸの簡易化
    '　　　：2009/02/24 (Tue) 16:34:58 N.Kojima     起動SBが組立、かつ送品先が"7x0：ﾁｯﾌﾟ品"だったらﾌｫﾝﾄの色を青にする。(案件№03402)
    '　　　：2009/08/24 (Mon) 10:17:16 N.Kojima     機種情報表示処理追加。(案件№03611)
    '　　　：2009/10/05 (Mon) 12:56:36 N.Kojima     蒸着ﾊﾞｯﾁID、CF/LP/VAﾌﾗｸﾞ、TPAL区分列追加に伴う修正。(案件№03791)
    '　　　：2009/12/01 (Tue) 16:38:45 H.Hayashi    ﾁｯﾌﾟ品判定ﾛｼﾞｯｸ部変更。(案件No.03810)
    '　　　：2010/03/03 (Wed) 17:42:29 N.Kojima     処理可能ﾚｼﾋﾟﾌﾗｸﾞの処理追加。(案件№03897)
    '　　　：2012/01/20 (Fri) 17:13:42 T.Oide       基板/組立表示ｶﾗﾑ順変更対応
    '      ：2013/01/29 (Tue) 13:50:23 Y.Yoneyama   ﾛｯﾄ進捗表示
    '      ：2015/11/25 (Wed) 09:38:04 H.Hayashi    千歳Spirytus_Prism処理チャンバー選択機能(H31096937)
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    '      ：2018/01/17 (Wed) 13:38:31 Y.Yoneyama   時間制限開始待ち保留の追加
    Private Sub prvVsfAreaEquipment_Disp(ByRef ltypLotListAns As LotListAns, _
                                         ByVal llngLotListCnt As Integer)

        Dim llngDoCnt           As Integer      'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt             As Integer      '汎用ｶｳﾝﾀ
        Dim lstrLimitTime       As String       '制限時間ﾌｫｰﾏｯﾄ用変数
        Dim lstrLimitTimeAns    As String       '時間制限変換用変数(#,##0時間 #0分)
        Dim llngWfIDDispCnt     As Integer      'WFID表示行ｶｳﾝﾀ
        Dim lstrWfIDDispChr     As String       '表示WFID文字列格納用変数("#01,#02,#03,#04,#05")
        Dim blnLimitTimeFlag    As Boolean      '表示するﾃﾞｰﾀに時間制限あり
        Dim keepBackColorObj    As Color        'NSYS 設定済み背景色(時間制限ﾌｫﾝﾄ設定時初期化されるため再設定用)

        Try

            '@注意：下記ﾛｼﾞｯｸを変更する場合は、【ﾛｯﾄ処理順変更(CM0110)】の変更要/不要を確認の事

            '@ﾃﾞｰﾀが0件か
            If llngLotListCnt = 0 Then

                '@=======================
                '@ 装置仕掛ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞｸﾘｱ処理
                '@=======================
                Call prvVsfAreaEquipment_Clr()

                Exit Sub
            End If

            blnLimitTimeFlag = False        '時間制限ありﾌﾗｸﾞ初期設定
            
            '@ﾛｯﾄ一覧の設定
            With vsfAreaEquipment

                '.Enabled = True             '無効
                .Redraw = False             '描画ﾛｯｸ
                'NSYS 不要なHandler処理を抑止
                RemoveHandler vsfAreaEquipment.BeforeRowColChange,AddressOf vsfAreaEquipment_BeforeRowColChange
                RemoveHandler vsfAreaEquipment.EnterCell,AddressOf vsfAreaEquipment_EnterCell
                .Rows.Count = .Rows.Fixed         '行数初期設定
                .Rows.Count = llngLotListCnt + 1  '行数設定
                .Row = 0                          'NSYS ヘッダーを選択
                'NSYS Hanlder抑止解除
                AddHandler vsfAreaEquipment.BeforeRowColChange,AddressOf vsfAreaEquipment_BeforeRowColChange
                AddHandler vsfAreaEquipment.EnterCell,AddressOf vsfAreaEquipment_EnterCell

                '@各種ｶｳﾝﾀの初期化
                llngDoCnt = 1               'ﾙｰﾌﾟｶｳﾝﾀ
                llngWfIDDispCnt = 0         'WFID表示数ｶｳﾝﾀ


                Do While .Rows.Count > llngDoCnt

                    .SetData(llngDoCnt, mlngvsfAreaEqColNowSt, _
                                ltypLotListAns.typLotList(llngDoCnt-1).strNowST)                       'ﾛｯﾄ現在状態

                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULL以外、かつﾛｯﾄ状態が「後処理」か
                    If ltypLotListAns.typLotList(llngDoCnt-1).strToCarrierId <> vbNullString And _
                        ltypLotListAns.typLotList(llngDoCnt-1).strNowST = CPstrAfterProgressSt Then

                        '@ｷｬﾘｱID列にｱﾝﾛｰﾀﾞｷｬﾘｱIDをｾｯﾄ
                        .SetData(llngDoCnt, mlngvsfAreaEqColCarrierID, _
                                ltypLotListAns.typLotList(llngDoCnt-1).strToCarrierId)
                    Else
                        '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULL、またはﾛｯﾄ状態が「後処理」以外か

                        '@ｷｬﾘｱID列にﾛｰﾀﾞｷｬﾘｱIDをｾｯﾄ
                        .SetData(llngDoCnt, mlngvsfAreaEqColCarrierID, _
                                ltypLotListAns.typLotList(llngDoCnt-1).strCarrierId)
                    End If

                    '@★ ｷｬﾘｱ状態により処理分岐 ★
                    Select Case ltypLotListAns.typLotList(llngDoCnt-1).strCarrierStatID

                        '@〓 MOVE：搬送中 or STKOUT：出庫中 or STKIN：入庫中 〓
                        Case CPstrCarrierStatMove, CPstrCarrierStatStkout, CPstrCarrierStatStkin

                            '@ｷｬﾘｱ位置に"→"を付加して搬送先を表示
                            .SetData(llngDoCnt, mlngvsfAreaEqColCarrierPositionName, _
                                CMstrArrow & CPstrSpace & ltypLotListAns.typLotList(llngDoCnt-1).strDestName)

                            '@ｷｬﾘｱ位置IDをｸﾘｱする
                            '@ ※搬送中の場合はｷｬﾘｱ位置IDをｸﾘｱする。ここでｸﾘｱしないと出庫指示ﾎﾞﾀﾝの制御に不具合が生じる
                            .SetData(llngDoCnt, mlngvsfAreaEqColCarrierPositionID, vbNullString)


                        '@〓 その他(搬送中ではない場合) 〓
                        Case Else

                            .SetData(llngDoCnt, mlngvsfAreaEqColCarrierPositionID, _
                                ltypLotListAns.typLotList(llngDoCnt-1).strCurrentPositionID)           'ｷｬﾘｱ位置ID

                            .SetData(llngDoCnt, mlngvsfAreaEqColCarrierPositionName, _
                                ltypLotListAns.typLotList(llngDoCnt-1).strCurrentPositionName)         'ｷｬﾘｱ位置

                    End Select

                    .SetData(llngDoCnt, mlngvsfAreaEqColCarrierStatusName, _
                            ltypLotListAns.typLotList(llngDoCnt-1).strCarrierStatName)                 'ｷｬﾘｱ状態

                    .SetData(llngDoCnt, mlngvsfAreaEqColCarrierStatusID, _
                            ltypLotListAns.typLotList(llngDoCnt-1).strCarrierStatID)                   'ｷｬﾘｱ状態ID

                    .SetData(llngDoCnt, mlngvsfAreaEqColLotID, _
                            ltypLotListAns.typLotList(llngDoCnt-1).strLotID)                           'ﾛｯﾄID

                    .SetData(llngDoCnt, mlngvsfAreaEqColPdID, _
                            ltypLotListAns.typLotList(llngDoCnt-1).strPdId)                            '機種ID

                    .SetData(llngDoCnt, mlngvsfAreaEqColFlowClass, _
                            ltypLotListAns.typLotList(llngDoCnt-1).strFlowClass)                       '種別

                    '優先順位
                    Dim strLotPriorityTmp As String = ltypLotListAns.typLotList(llngDoCnt-1).strLotPriority
                    If IsNumeric(strLotPriorityTmp) Then
                        .SetData(llngDoCnt, mlngvsfAreaEqColPriority,CLng(strLotPriorityTmp))
                    Else
                        .SetData(llngDoCnt, mlngvsfAreaEqColPriority,strLotPriorityTmp)
                    End If

                    .SetData(llngDoCnt, mlngvsfAreaEqColOpID, _
                            ltypLotListAns.typLotList(llngDoCnt-1).strOpID)                            '大工程

                    .SetData(llngDoCnt, mlngvsfAreaEqColStepID, _
                            ltypLotListAns.typLotList(llngDoCnt-1).strStepID)                          '小工程

                    .SetData(llngDoCnt, mlngvsfAreaEqColRecipe, _
                            ltypLotListAns.typLotList(llngDoCnt-1).strRecipeId)                        'ﾚｼﾋﾟ

                    '処理開始予実
                    Dim strDateTmp As String = ltypLotListAns.typLotList(llngDoCnt-1).strDispatchStartTime
                    If IsDate(strDateTmp) Then
                        .SetData(llngDoCnt, mlngvsfAreaEqColDispatchStartTime, Format(CDate(strDateTmp), CPstrDateFormatMDHM))
                    Else
                        .SetData(llngDoCnt, mlngvsfAreaEqColDispatchStartTime, strDateTmp)
                    End If

                    .SetData(llngDoCnt, mlngvsfAreaEqColLotManagerName, _
                            ltypLotListAns.typLotList(llngDoCnt-1).strEngEmpName)                      'ﾛｯﾄ担当者

                    'WF枚数
                    Dim strWfNumTmp As String = ltypLotListAns.typLotList(llngDoCnt-1).strWfNum
                    If IsNumeric(strWfNumTmp) Then
                        .SetData(llngDoCnt, mlngvsfAreaEqColWfNum,CLng(strWfNumTmp))
                    Else
                        .SetData(llngDoCnt, mlngvsfAreaEqColWfNum,strWfNumTmp)
                    End If

                    'ﾁｯﾌﾟ数
                    Dim strChipQuantityTmp As String = ltypLotListAns.typLotList(llngDoCnt-1).strChipQuantity
                    If IsNumeric(strChipQuantityTmp) Then
                        .SetData(llngDoCnt, mlngvsfAreaEqColChipNum, CLng(strChipQuantityTmp))
                    Else
                        .SetData(llngDoCnt, mlngvsfAreaEqColChipNum, strChipQuantityTmp)
                    End If

                    '@(ﾛｯﾄ)ｺﾒﾝﾄﾌﾗｸﾞが"あり"か
                    If ltypLotListAns.typLotList(llngDoCnt-1).strLotCommentsFlg = CPstrAriFlg Then

                        '@"あり"の場合、ｺﾒﾝﾄに"あり"を表示
                        .SetData(llngDoCnt, mlngvsfAreaEqColLotComments, CPstrAriFlg)
                    Else
                        '@(ﾛｯﾄ)ｺﾒﾝﾄﾌﾗｸﾞが"NULL"の場合、ｺﾒﾝﾄに空白を表示
                        .SetData(llngDoCnt, mlngvsfAreaEqColLotComments, vbNullString)
                    End If

                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULL以外、かつﾛｯﾄ状態が「後処理」か
                    If ltypLotListAns.typLotList(llngDoCnt-1).strToCarrierId <> vbNullString And _
                        ltypLotListAns.typLotList(llngDoCnt-1).strNowST = CPstrAfterProgressSt Then

                        '@ｷｬﾘｱID列にｱﾝﾛｰﾀﾞｷｬﾘｱIDをｾｯﾄ
                        .SetData(llngDoCnt, mlngvsfAreaEqColLCarrierID, _
                                ltypLotListAns.typLotList(llngDoCnt-1).strToCarrierId)
                    Else
                        '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULL、またはﾛｯﾄ状態が「後処理」以外か

                        '@ｷｬﾘｱID列にﾛｰﾀﾞｷｬﾘｱIDをｾｯﾄ
                        .SetData(llngDoCnt, mlngvsfAreaEqColLCarrierID, _
                                ltypLotListAns.typLotList(llngDoCnt-1).strCarrierId)
                    End If

                    .SetData(llngDoCnt, mlngvsfAreaEqColUCarrierID, _
                            ltypLotListAns.typLotList(llngDoCnt-1).strToCarrierId)                     'ｱﾝﾛｰﾀﾞｷｬﾘｱID

                    .SetData(llngDoCnt, mlngvsfAreaEqColAltNumber, _
                            ltypLotListAns.typLotList(llngDoCnt-1).strAltNumber)                       '代替番号

                    .SetData(llngDoCnt, mlngvsfAreaEqColLotLastUpdate, _
                            ltypLotListAns.typLotList(llngDoCnt-1).strLotLastUpdate)                   'ﾛｯﾄ最終更新日時


                    '@-----------------------------------------------
                    '@ 背景色/ﾌｫﾝﾄ色のﾃﾞﾌｫﾙﾄ設定
                    '@　①背景色：白
                    '@　②ﾌｫﾝﾄ色：黒
                    '@-----------------------------------------------
                    '@ｾﾙ色変更
                    '@ﾌｫﾝﾄ色変更
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CMlngVbColorWhite_ForeColor_CMlngVbColorBlack" & llngDoCnt.ToString)
                    Dim cellRange As CellRange = .GetCellRange(llngDoCnt, CMlngvsfAreaEqColTitle,llngDoCnt, .Cols.Count - 1)
                    newStyle.BackColor = ColorTranslator.FromWin32(CMlngVbColorWhite)
                    newStyle.ForeColor = ColorTranslator.FromWin32(CMlngVbColorBlack)
                    cellRange.Style = newStyle

                    'NSYS 設定背景色名退避
                    keepBackColorObj = ColorTranslator.FromWin32(CMlngVbColorWhite) '白

                    '@-----------------------------------------------
                    '@ 背景色の設定
                    '@　①停止 > 保留 > 処理限定ﾚｼﾋﾟ > ﾀﾞﾐｰﾛｯﾄ > L/R
                    '@-----------------------------------------------
                    '@★ 液晶方向により処理分岐(※組立機種(L/R色分け処理)) ★
                    Select Case ltypLotListAns.typLotList(llngDoCnt-1).strLcDirection

                        '@〓 L 〓
                        Case CPstrPDIDL

                            '@ｾﾙ背景色変更(水色)
                            newStyle = .Styles.Add("CustomStyle_BackColor_CPlngLColor" & llngDoCnt.ToString)
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngLColor)
                            cellRange = .GetCellRange(llngDoCnt, CMlngvsfAreaEqColTitle, llngDoCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle

                            'NSYS 設定背景色名退避
                            keepBackColorObj = ColorTranslator.FromWin32(CPlngLColor)

                        '@〓 R 〓
                        Case CPstrPDIDR

                            '@ｾﾙ背景色変更(ﾋﾟﾝｸ色)
                            newStyle = .Styles.Add("CustomStyle_BackColor_CPlngRColor" & llngDoCnt.ToString)
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngRColor)
                            cellRange = .GetCellRange(llngDoCnt, CMlngvsfAreaEqColTitle, llngDoCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle

                            'NSYS 設定背景色名退避
                            keepBackColorObj = ColorTranslator.FromWin32(CPlngRColor)

                    End Select


                    '@流動区分が"FD"or"SD"、かつ装置ﾀｲﾌﾟが"BATCH"か
                    If ((ltypLotListAns.typLotList(llngDoCnt-1).strFlowClass = CPstrFillerDummy Or _
                        ltypLotListAns.typLotList(llngDoCnt-1).strFlowClass = CPstrSideDummy) And _
                        ltypLotListAns.strMcType = CPstrMCTypeBatch) Then

                        '@ｾﾙ色変更(ｵﾚﾝｼﾞ色)
                        newStyle = .Styles.Add("CustomStyle_BackColor_CPlngVbColorOrange" & llngDoCnt.ToString)
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngVbColorOrange)
                        cellRange = .GetCellRange(llngDoCnt, CMlngvsfAreaEqColTitle, llngDoCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle

                        'NSYS 設定背景色名退避
                        keepBackColorObj = ColorTranslator.FromWin32(CPlngVbColorOrange)
                    End If

                    '@流動区分が"ED"、かつ装置ﾀｲﾌﾟが"EXDUMMY"か
                    If ltypLotListAns.typLotList(llngDoCnt-1).strFlowClass = CPstrExtraDummy And _
                        ltypLotListAns.strMcType = CPstrMCTypeExDummy Then

                        '@ｾﾙ色変更(ｵﾚﾝｼﾞ色)
                        newStyle = .Styles.Add("CustomStyle_BackColor_CPlngVbColorOrange" & llngDoCnt.ToString)
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngVbColorOrange)
                        cellRange = .GetCellRange(llngDoCnt, CMlngvsfAreaEqColTitle, llngDoCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle

                        'NSYS 設定背景色名退避
                        keepBackColorObj = ColorTranslator.FromWin32(CPlngVbColorOrange)
                    End If

                    '@FRﾚｼﾋﾟ有無ﾌﾗｸﾞが"1：処理不可"か
                    If ltypLotListAns.typLotList(llngDoCnt-1).strFrFlag = CPstrOne Then

                        '@ｾﾙの色変更(ﾗｲﾄｸﾞﾘｰﾝ)
                        newStyle = .Styles.Add("CustomStyle_BackColor_CPlngFrNgColor" & llngDoCnt.ToString)
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngFrNgColor)
                        cellRange = .GetCellRange(llngDoCnt, CMlngvsfAreaEqColTitle, llngDoCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle

                        'NSYS 設定背景色名退避
                        keepBackColorObj = ColorTranslator.FromWin32(CPlngFrNgColor)
                    End If

                    '@処理可能ﾚｼﾋﾟﾌﾗｸﾞが"1：処理限定ﾚｼﾋﾟ"か
                    If ltypLotListAns.typLotList(llngDoCnt-1).strAvailableRecipeFlag = CPstrOne Then

                        '@ｾﾙの色変更(ｸﾞﾚｰ)
                        newStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray" & llngDoCnt.ToString)
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                        cellRange = .GetCellRange(llngDoCnt, CMlngvsfAreaEqColTitle, llngDoCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle

                        'NSYS 設定背景色名退避
                        keepBackColorObj = ColorTranslator.FromWin32(CPlngGridGray)
                    End If

                    '@保留ﾌﾗｸﾞが"1：保留中"か
                    If ltypLotListAns.typLotList(llngDoCnt-1).strLotHoldFlag = CMstrLotHoldFlgOn Then

                        '@ｾﾙの色変更(黄色)
                        newStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor" & llngDoCnt.ToString)
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                        cellRange = .GetCellRange(llngDoCnt, CMlngvsfAreaEqColTitle, llngDoCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle

                        'NSYS 設定背景色名退避
                        keepBackColorObj = ColorTranslator.FromWin32(CPlngHoldLotColor)
                    End If

                    '@停止ﾌﾗｸﾞが"1：停止中"か
                    If ltypLotListAns.typLotList(llngDoCnt-1).strLotStopFlag = CMstrLotStopFlgOn Then

                        '@ｾﾙ色変更(黄色)
                        newStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor" & llngDoCnt.ToString)
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                        cellRange = .GetCellRange(llngDoCnt, CMlngvsfAreaEqColTitle, llngDoCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle

                        'NSYS 設定背景色名退避
                        keepBackColorObj = ColorTranslator.FromWin32(CPlngHoldLotColor)
                    End If

                    '@部分ﾚｼﾋﾟﾌﾗｸﾞが"1：部分ﾚｼﾋﾟ"か
                    If ltypLotListAns.typLotList(llngDoCnt-1).strWfPartialRecipeFlag = CMstrPartialRecipeFlgOn Then

                        '@ｾﾙ色変更(保/停区分列のみ赤色)
                        newStyle = .Styles.Add("CustomStyle_BackColor_CPlngVbColorRed" & llngDoCnt.ToString)
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngVbColorRed)
                        cellRange = .GetCellRange(llngDoCnt, mlngvsfAreaEqColKb, llngDoCnt, mlngvsfAreaEqColKb)
                        cellRange.Style = newStyle
                    End If

                    '@-----------------------------------------------
                    '@ 背景色が指定色されている場合の設定
                    '@　①背景色：MST01.DEFINE.COLUMN_NAME(&が先頭についていないのでここで付与する)
                    '@　　　　　　MST01.PD.COLOR_NAME → MST01.DEFINE.NAME →　MST01.DEFINE.COLUMN_NAME
                    '@-----------------------------------------------
                    '@組立
                    If pstrSBID = CPstrSBID2A0 Then

                        '@指定色有りか
                        If ltypLotListAns.typLotList(llngDoCnt-1).strColorCd <> vbNullString Then

                            '@ｾﾙ色変更(機種のみ指定色)
                            '& + 指定色(H4763FFなどの形式)
                            newStyle = .Styles.Add("CustomStyle_BackColor_strColorCd" & llngDoCnt.ToString)
                            newStyle.BackColor = ColorTranslator.FromWin32(CPstrAmpersand & ltypLotListAns.typLotList(llngDoCnt-1).strColorCd)
                            cellRange = .GetCellRange(llngDoCnt, mlngvsfAreaEqColPdID, llngDoCnt, mlngvsfAreaEqColPdID)
                            cellRange.Style = newStyle

                        End If


                    End If

                    '@-----------------------------------------------
                    '@ ﾌｫﾝﾄ色の設定1
                    '@　①警告時間：紫色
                    '@　②制限時間：赤色
                    '@-----------------------------------------------
                    '@時間制約有無の表示
                    If ltypLotListAns.typLotList(llngDoCnt-1).strLimitTime <> vbNullString Then

                        blnLimitTimeFlag = True     '時間制限表示ﾌﾗｸﾞON

                        '@時間制約がﾌﾟﾗｽの場合
                        If CLng(ltypLotListAns.typLotList(llngDoCnt-1).strLimitTime) >= 0 Then

                            '@制限時間以下or処理時間制限以下の場合
                            If ltypLotListAns.typLotList(llngDoCnt-1).strRestrictTypeID = CPstrRestrictTypeID1 Or _
                                ltypLotListAns.typLotList(llngDoCnt-1).strRestrictTypeID = CPstrRestrictTypeID3 Then

                                '@ﾌｫｰﾏｯﾄ変換(##,##0)
                                Dim strLimitTimeTmp As String = ltypLotListAns.typLotList(llngDoCnt-1).strLimitTime
                                If IsNumeric(strLimitTimeTmp) Then
                                    lstrLimitTime = Format(CLng(strLimitTimeTmp), CPstrDateFormatKanma)
                                Else
                                    lstrLimitTime = strLimitTimeTmp
                                End If

                                '@制限時間先大工程+制限時間先小工程+制限時間+「以内」(組立は小工程のみの表示）
                                '@制限時間を時間と分で分割表示する
                                lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)
                                If pstrSBID = CPstrSBID1A0 Then
                                    '@基板
                                    .SetData(llngDoCnt, mlngvsfAreaEqColLimitTime, _
                                            ltypLotListAns.typLotList(llngDoCnt-1).strToOpId & CPstrSpace & _
                                            ltypLotListAns.typLotList(llngDoCnt-1).strToStepId & CPstrMade & _
                                            lstrLimitTimeAns & CPstrinai)
                                Else
                                    '@組立
                                    .SetData(llngDoCnt, mlngvsfAreaEqColLimitTime, _
                                            ltypLotListAns.typLotList(llngDoCnt-1).strToStepId & CPstrMade & _
                                            lstrLimitTimeAns & CPstrinai)
                                End If
                                    
                                '@警告時間が設定されている場合
                                If ltypLotListAns.typLotList(llngDoCnt-1).strWarnTime <> vbNullString Then
                                    '@時間制限が警告時間を過ぎている,且つ制限時間がｵｰﾊﾞｰしていない場合
                                    If CLng(ltypLotListAns.typLotList(llngDoCnt-1).strWarnTime) < 0 And _
                                       CLng(ltypLotListAns.typLotList(llngDoCnt-1).strLimitTime) >= 0 Then
                                        '@ﾌｫﾝﾄｶﾗｰを紫に変更
                                        newStyle = .Styles.Add("CustomStyle_ForeColor_CPlngVbColorPurple" & llngDoCnt.ToString)
                                        newStyle.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple)
                                        newStyle.BackColor = keepBackColorObj
                                        cellRange = .GetCellRange(llngDoCnt, mlngvsfAreaEqColLimitTime, llngDoCnt, mlngvsfAreaEqColLimitTime)
                                        cellRange.Style = newStyle
                                    End If
                                End If
                            End If
                        Else
                            '@制限時間がﾏｲﾅｽの場合

                            '@ﾌｫﾝﾄｶﾗｰを赤に変更
                            newStyle = .Styles.Add("CustomStyle_ForeColor_CPlngVbColorRed" & llngDoCnt.ToString)
                            newStyle.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed)
                            newStyle.BackColor = keepBackColorObj
                            cellRange = .GetCellRange(llngDoCnt, mlngvsfAreaEqColLimitTime, llngDoCnt, mlngvsfAreaEqColLimitTime)
                            cellRange.Style = newStyle

                            '@制限時間以下or処理時間制限以下の場合
                            If ltypLotListAns.typLotList(llngDoCnt-1).strRestrictTypeID = CPstrRestrictTypeID1 Or _
                                ltypLotListAns.typLotList(llngDoCnt-1).strRestrictTypeID = CPstrRestrictTypeID3 Then

                                '@ﾌｫｰﾏｯﾄ変換(##,##0)
                                Dim strLimitTimeTmp As String = ltypLotListAns.typLotList(llngDoCnt-1).strLimitTime
                                If IsNumeric(strLimitTimeTmp) Then
                                    lstrLimitTime = Format(CLng(strLimitTimeTmp), CPstrDateFormatKanma)
                                Else
                                    lstrLimitTime = strLimitTimeTmp
                                End If

                                '@制限時間先大工程+制限時間先小工程+制限時間+「以内」(組立は小工程のみの表示）
                                '@制限時間を時間と分で分割表示する
                                lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)
                                If pstrSBID = CPstrSBID1A0 Then
                                    .SetData(llngDoCnt, mlngvsfAreaEqColLimitTime, _
                                            ltypLotListAns.typLotList(llngDoCnt-1).strToOpId & CPstrSpace & _
                                            ltypLotListAns.typLotList(llngDoCnt-1).strToStepId & CPstrMade & _
                                            lstrLimitTimeAns & CPstrinai)
                                Else
                                    .SetData(llngDoCnt, mlngvsfAreaEqColLimitTime, _
                                            ltypLotListAns.typLotList(llngDoCnt-1).strToStepId & CPstrMade & _
                                            lstrLimitTimeAns & CPstrinai)
                                End If
           
                            End If

                            '@制限時間以上の場合
                            If ltypLotListAns.typLotList(llngDoCnt-1).strRestrictTypeID = CPstrRestrictTypeID2 Then

                                '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,##0)+"分"
                                Dim strLimitTimeTmp As String = ltypLotListAns.typLotList(llngDoCnt-1).strLimitTime, CPstrDateFormatKanma
                                If IsNumeric(strLimitTimeTmp) Then
                                    lstrLimitTime = Replace(Format(CLng(strLimitTimeTmp), CPstrDateFormatKanma), CPstrReplaceMinus, vbNullString)
                                Else
                                    lstrLimitTime = Replace(strLimitTimeTmp, CPstrReplaceMinus, vbNullString)
                                End If

                                '@制限時間先大工程+制限時間先小工程+制限時間+「以上」(組立は小工程のみの表示）
                                '@制限時間を時間と分で分割表示する
                                lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)
                                If pstrSBID = CPstrSBID1A0 Then
                                    .SetData(llngDoCnt, mlngvsfAreaEqColLimitTime, _
                                            ltypLotListAns.typLotList(llngDoCnt-1).strToOpId & CPstrSpace & _
                                            ltypLotListAns.typLotList(llngDoCnt-1).strToStepId & CPstrMade & _
                                            lstrLimitTimeAns & CPstrijyou)
                                Else
                                    .SetData(llngDoCnt, mlngvsfAreaEqColLimitTime, _
                                            ltypLotListAns.typLotList(llngDoCnt-1).strToStepId & CPstrMade & _
                                            lstrLimitTimeAns & CPstrijyou)
                                End If
                                               
                            End If
                        End If

                    '@ 時間制約無の場合
                    Else
                        '@ 時間制約開始待ち保留の場合
                        If ltypLotListAns.typLotList(llngDoCnt-1).strTimeRestrictStartHold = CPstrOne Then
                            .SetData(llngDoCnt, mlngvsfAreaEqColLimitTime, CPstrTimeRestrictStartWait)
                        End If
                    End If

                    '@-----------------------------------------------
                    '@ 保/停区分列の設定
                    '@　①部分ﾚｼﾋﾟ > 号機指定 > ﾘﾜｰｸ/追加流動 > 処理限定ﾚｼﾋﾟ > 保留 > 停止
                    '@-----------------------------------------------
                    '@停止ﾌﾗｸﾞが"1：停止中"か
                    If ltypLotListAns.typLotList(llngDoCnt-1).strLotStopFlag = CMstrLotStopFlgOn Then

                        '@=======================
                        '@ 区分列表示処理(※区分列に"停"を表示)
                        '@=======================
                        .SetData(llngDoCnt, mlngvsfAreaEqColKb, _
                            pubstrColKbn_Set(.GetData(llngDoCnt, mlngvsfAreaEqColKb), CMstrTei))

                    End If

                    '@保留ﾌﾗｸﾞが"1：保留中"か
                    If ltypLotListAns.typLotList(llngDoCnt-1).strLotHoldFlag = CMstrLotHoldFlgOn Then

                        '@=======================
                        '@ 区分列表示処理(※区分列に"保"を表示)
                        '@=======================
                        .SetData(llngDoCnt, mlngvsfAreaEqColKb, _
                            pubstrColKbn_Set(.GetData(llngDoCnt, mlngvsfAreaEqColKb), CMstrHo))
                    End If

                    '@-----------------------
                    '@ ﾘﾜｰｸ/追加流動表示
                    '@-----------------------
                    .SetData(llngDoCnt, mlngvsfAreaEqColReworkFlag, _
                            ltypLotListAns.typLotList(llngDoCnt-1).strReworkFlag)                                  'ﾘﾜｰｸﾌﾗｸﾞ

                    '@ﾘﾜｰｸﾌﾗｸﾞが"1：ﾘﾜｰｸ中"か
                    If ltypLotListAns.typLotList(llngDoCnt-1).strReworkFlag = CMstrLotReworkFlgOn Then

                        '@=======================
                        '@ 区分列表示処理(※区分列に"リ"を表示)
                        '@=======================
                        .SetData(llngDoCnt, mlngvsfAreaEqColKb, _
                            pubstrColKbn_Set(.GetData(llngDoCnt, mlngvsfAreaEqColKb), CMstrRi))

                    End If

                    '@ﾘﾜｰｸﾌﾗｸﾞが"2：追加流動中"か
                    If ltypLotListAns.typLotList(llngDoCnt-1).strReworkFlag = CMstrLotReworkFlgOn2 Then

                        '@=======================
                        '@ 区分列表示処理(※区分列に"追"を表示)
                        '@=======================
                        .SetData(llngDoCnt, mlngvsfAreaEqColKb, _
                            pubstrColKbn_Set(.GetData(llngDoCnt, mlngvsfAreaEqColKb), CMstrTsui))

                    End If


                    '@-----------------------
                    '@ 号機指定表示
                    '@-----------------------
                    .SetData(llngDoCnt, mlngvsfAreaEqColCommitFlag, _
                            ltypLotListAns.typLotList(llngDoCnt-1).strCommitFlag)                                  '号機指定ﾌﾗｸﾞ

                    '@号機指定ﾌﾗｸﾞが"1：号機指定あり"か
                    If ltypLotListAns.typLotList(llngDoCnt-1).strCommitFlag = CMstrGoukiFlgOn Then

                        '@=======================
                        '@ 区分列表示処理(※区分列に"号"を表示)
                        '@=======================
                        .SetData(llngDoCnt, mlngvsfAreaEqColKb, _
                            pubstrColKbn_Set(.GetData(llngDoCnt, mlngvsfAreaEqColKb), CMstrGou))

                    End If


                    '@-----------------------
                    '@ 部分ﾚｼﾋﾟ表示
                    '@-----------------------
                    '@部分ﾚｼﾋﾟﾌﾗｸﾞが"1：部分ﾚｼﾋﾟ"か
                    If ltypLotListAns.typLotList(llngDoCnt-1).strWfPartialRecipeFlag = CMstrPartialRecipeFlgOn Then

                        '@=======================
                        '@ 区分列表示処理(※区分列に"部"を表示)
                        '@=======================
                        .SetData(llngDoCnt, mlngvsfAreaEqColKb, _
                            pubstrColKbn_Set(.GetData(llngDoCnt, mlngvsfAreaEqColKb), CMstrBu))

                    End If


                    '@-----------------------
                    '@ 処理限定ﾛｯﾄ表示
                    '@-----------------------
                    '@処理可能ﾚｼﾋﾟﾌﾗｸﾞが"1：処理限定ﾚｼﾋﾟ"か
                    If ltypLotListAns.typLotList(llngDoCnt-1).strAvailableRecipeFlag = CPstrOne Then

                        '@=======================
                        '@ 区分列表示処理(※区分列に"限"を表示)
                        '@=======================
                        .SetData(llngDoCnt, mlngvsfAreaEqColKb, _
                            pubstrColKbn_Set(.GetData(llngDoCnt, mlngvsfAreaEqColKb), CMstrGen))

                    End If

                    '@-----------------------
                    '@ FR累積時間範囲外ﾛｯﾄ表示
                    '@-----------------------
                    '@FRﾚｼﾋﾟ有無ﾌﾗｸﾞが"1：処理不可"か
                    If ltypLotListAns.typLotList(llngDoCnt-1).strFrFlag = CPstrOne Then

                        '@=======================
                        '@ 区分列表示処理(※区分列に"外"を表示)
                        '@=======================
                        .SetData(llngDoCnt, mlngvsfAreaEqColKb, _
                            pubstrColKbn_Set(.GetData(llngDoCnt, mlngvsfAreaEqColKb), CMstrGai))

                    End If

                    '@-----------------------
                    '@ WFIDの表示(組立工程のみ)
                    '@-----------------------
                    If pstrSBID = CPstrSBID2A0 Then

                        '@WF枚数が1枚以上あり、かつ数値か
                        If IsNumeric(.GetData(llngDoCnt, mlngvsfAreaEqColWfNum)) = True And _
                             CLng(.GetData(llngDoCnt, mlngvsfAreaEqColWfNum)) > 0 Then

                            '@表示WFID文字列格納用変数の初期化
                            lstrWfIDDispChr = vbNullString

                            '@WFﾘｽﾄ分、ｶﾝﾏ区切りで文字列を編集
                            For llngCnt = 0 To ltypLotListAns.typLotList(llngDoCnt-1).lngWfListCnt - 1


                                '@***********************
                                '@ WFIDが10桁で、8桁目が"#"の場合に下3桁結合とする
                                '@***********************
                                '@WFIDが10桁か
                                If Len(ltypLotListAns.typLotList(llngDoCnt-1).typWfList(llngCnt).strWfId) = _
                                    CMlngWfIDCondLength Then

                                    '@WFIDの8桁目が"#"か
                                    If Mid$(ltypLotListAns.typLotList(llngDoCnt-1).typWfList(llngCnt).strWfId, CMlngWfIDCondChrPos, 1) _
                                        = CMstrWfIDCondChr Then
                                        
                                        '@表示WFIDの文字結合
                                        '@先頭のみ#を付けて移行は2桁のWFID部分のみ連結する(REQ-1115で仕様変更)
                                        If llngCnt = 0 Then
                                            lstrWfIDDispChr = lstrWfIDDispChr & _
                                                              Strings.Right$(ltypLotListAns.typLotList(llngDoCnt-1).typWfList(llngCnt).strWfId, _
                                                              CMlngWfIDDispRightLength) & CPstrComma
                                        Else
                                            lstrWfIDDispChr = lstrWfIDDispChr & _
                                                              Strings.Right$(ltypLotListAns.typLotList(llngDoCnt-1).typWfList(llngCnt).strWfId, _
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
                            .SetData(llngDoCnt, mlngvsfAreaEqColWfId, lstrWfIDDispChr)
                        End If


                        '@-----------------------------------------------
                        '@ ﾌｫﾝﾄ色の設定(組立限定機能)
                        '@　①ﾁｯﾌﾟ品LOT：青色
                        '@-----------------------------------------------
                        '@起動SBが組立、かつｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"か
                        If pstrSBID = CPstrSBID2A0 And _
                            ltypLotListAns.typLotList(llngDoCnt-1).strSbArea = CPstrProductChip Then

                            '@時間制限以外の文字色を青色に変更
                            newStyle = .Styles.Add("CustomStyle_ForeColor_vbBlue1" & llngDoCnt.ToString)
                            newStyle.ForeColor = Color.Blue
                            newStyle.BackColor = keepBackColorObj
                            cellRange = .GetCellRange(llngDoCnt, mlngvsfAreaEqColNo, llngDoCnt, mlngvsfAreaEqColNowSt)
                            cellRange.Style = newStyle

                            newStyle = .Styles.Add("CustomStyle_ForeColor_vbBlue2" & llngDoCnt.ToString)
                            newStyle.ForeColor = Color.Blue
                            newStyle.BackColor = keepBackColorObj
                            cellRange = .GetCellRange(llngDoCnt, mlngvsfAreaEqColCarrierID, llngDoCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        End If
                    End If

                    '@蒸着ﾊﾞｯﾁID
                    .SetData(llngDoCnt, mlngvsfAreaEqColJBatchID, _
                            ltypLotListAns.typLotList(llngDoCnt-1).strJBatchId)
                            
                    '@表面ﾊﾞｯﾁID
                    .SetData(llngDoCnt, mlngvsfAreaEqColHBatchID, _
                            ltypLotListAns.typLotList(llngDoCnt-1).strHBatchId)

                    '@CFﾌﾗｸﾞ
                    .SetData(llngDoCnt, mlngvsfAreaEqColCfFlag, _
                            ltypLotListAns.typLotList(llngDoCnt-1).strCfFlag)

                    '@LPﾌﾗｸﾞ
                    .SetData(llngDoCnt, mlngvsfAreaEqColLpFlag, _
                            ltypLotListAns.typLotList(llngDoCnt-1).strLpFlag)

                    '@無機ﾌﾗｸﾞ
                    .SetData(llngDoCnt, mlngvsfAreaEqColVaFlag, _
                            ltypLotListAns.typLotList(llngDoCnt-1).strVaFlag)

                    '@TPAL区分
                    .SetData(llngDoCnt, mlngvsfAreaEqColTpalClass, _
                            ltypLotListAns.typLotList(llngDoCnt-1).strTpalClass)

                    '@ﾛｯﾄ進捗度
                    .SetData(llngDoCnt, mlngvsfAreaEqColShipDiffDay, _
                             ltypLotListAns.typLotList(llngDoCnt-1).strShipDiffDay)
                                                             
                    '@FRﾚｼﾋﾟ有無ﾌﾗｸﾞ
                    .SetData(llngDoCnt, mlngvsfAreaEqColFrFlag, _
                            ltypLotListAns.typLotList(llngDoCnt-1).strFrFlag)

                    '@GRB区分
                    .SetData(llngDoCnt, mlngvsfAreaEqColGrbClass, _
                            ltypLotListAns.typLotList(llngDoCnt-1).strGrbClass)

                    '@↓2019/12/18 (Wed) 14:24:41 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    '@GRB背景色
                    newStyle = .Styles.Add("CustomStyle_BackColor_GRB" & llngDoCnt.ToString)
                    newStyle.BackColor = pubGRBBackColor(ltypLotListAns.typLotList(llngDoCnt-1).strGRBClass, .GetCellStyle(llngDoCnt, mlngvsfAreaEqColGrbClass).BackColor)
                    cellRange = .GetCellRange(llngDoCnt, mlngvsfAreaEqColGrbClass, llngDoCnt, mlngvsfAreaEqColGrbClass)
                    cellRange.Style = newStyle
                    '@↑2019/12/18 (Wed) 14:24:41 Y.Yoneyama 「.Netへ反映未」 **************************************************

                    '@指定色
                    .SetData(llngDoCnt, mlngvsfAreaEqColColorCd, _
                            ltypLotListAns.typLotList(llngDoCnt-1).strColorCd)

                    '@行高設定
                    .Rows(llngDoCnt).Height = CMlngvsfAreaEqHeight

                    '@ｽﾛｯﾄ№の設定
                    .SetData(llngDoCnt, mlngvsfAreaEqColNo, llngDoCnt)

                    '@ｶｳﾝﾄｱｯﾌﾟ
                    llngDoCnt = llngDoCnt + 1
                Loop
                
                '@ﾕｰｻﾞﾘｻｲｽﾞが行われているか(False：未変更)
                If mtypChgSort.blnChgWidth = False Then

                    '@自動で列幅調整を行う
                    '.AutoSizeMode = flexAutoSizeColWidth
                    .AutoSizeCols(mlngvsfAreaEqColNo, .Cols.Count - 1, 6)
                    
                    '@時間制限の表示はあるか
                    If blnLimitTimeFlag = False Then
                        .Cols(mlngvsfAreaEqColLimitTime).Width = CMlngvsfAreaEqColWLimitTime          '時間制限幅指定(表示なし)
                    Else
                        If pstrSBID = CPstrSBID1A0 Then
                            .Cols(mlngvsfAreaEqColLimitTime).Width = CMlngvsfAreaEqColWLimitTime1A0   '時間制限幅指定(1A0表示あり)
                        Else
                            .Cols(mlngvsfAreaEqColLimitTime).Width = CMlngvsfAreaEqColWLimitTime2A0   '時間制限幅指定(2A0表示あり)
                        End If
                    End If
                End If

                'NSYS 不要なHandler処理を抑止
                RemoveHandler vsfAreaEquipment.BeforeRowColChange,AddressOf vsfAreaEquipment_BeforeRowColChange
                RemoveHandler vsfAreaEquipment.EnterCell,AddressOf vsfAreaEquipment_EnterCell

                '@ｸﾞﾘｯﾄﾞを初期値へ移動
                .LeftCol = CMlngvsfAreaEqColTitle       '列
                .TopRow = CMlngvsfAreaEqRowTitle        '行
                .Row = CMlngvsfAreaEqRowTitle           'ｶﾚﾝﾄ行の移動

                'NSYS Handler抑止解除
                AddHandler vsfAreaEquipment.BeforeRowColChange,AddressOf vsfAreaEquipment_BeforeRowColChange
                AddHandler vsfAreaEquipment.EnterCell,AddressOf vsfAreaEquipment_EnterCell

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
                        RemoveHandler vsfAreaEquipment.BeforeRowColChange,AddressOf vsfAreaEquipment_BeforeRowColChange
                        RemoveHandler vsfAreaEquipment.EnterCell,AddressOf vsfAreaEquipment_EnterCell
                        .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder,mtypChgSort.typChgSortList(llngCnt).lngCol)
                        AddHandler vsfAreaEquipment.BeforeRowColChange,AddressOf vsfAreaEquipment_BeforeRowColChange
                        AddHandler vsfAreaEquipment.EnterCell,AddressOf vsfAreaEquipment_EnterCell

                    Next llngCnt
                End If

                '@ｿｰﾄｷｰ(ｷｬﾘｱID)がNULL以外
                If mtypChgSort.strKey <> vbNullString Then

                    For llngCnt = .Rows.Fixed To .Rows.Count - 1

                        '@ｿｰﾄ配列の検索ｷｰとｶﾚﾝﾄ行検索ｷｰが同じか(ｷｬﾘｱID、大工程、小工程)
                        If .GetData(llngCnt, mlngvsfAreaEqColCarrierID) & _
                            .GetData(llngCnt, mlngvsfAreaEqColOpID) & _
                            .GetData(llngCnt, mlngvsfAreaEqColStepID) = mtypChgSort.strKey Then

                            '@一致行を選択
                            .Row = llngCnt

                            '@=======================
                            '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                            '@=======================
                            Call pubVsfBeforeSort(vsfAreaEquipment, mlngvsfAreaEqColCarrierID & vbTab & _
                                                                    mlngvsfAreaEqColOpID & vbTab & _
                                                                    mlngvsfAreaEqColStepID)

                            '@=======================
                            '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                            '@=======================
                            RemoveHandler txtBCRCarrier.Validating,AddressOf txtBCRCarrier_Validate
                            Call pubVsfAfterSort(vsfAreaEquipment, mlngvsfAreaEqColCarrierID & vbTab & _
                                                                   mlngvsfAreaEqColOpID & vbTab & _
                                                                   mlngvsfAreaEqColStepID, _
                                                                   cmdUP, cmdDown)
                            AddHandler txtBCRCarrier.Validating,AddressOf txtBCRCarrier_Validate

                            '@処理ﾙｰﾌﾟ抜け
                            Exit For
                        End If
                    Next llngCnt
                Else
                    'NSYS 未選択だった場合ヘッダーを選択
                    RemoveHandler vsfAreaEquipment.BeforeRowColChange,AddressOf vsfAreaEquipment_BeforeRowColChange
                    RemoveHandler vsfAreaEquipment.EnterCell,AddressOf vsfAreaEquipment_EnterCell
                    .Row = 0
                    AddHandler vsfAreaEquipment.BeforeRowColChange,AddressOf vsfAreaEquipment_BeforeRowColChange
                    AddHandler vsfAreaEquipment.EnterCell,AddressOf vsfAreaEquipment_EnterCell
                End If

                '@-----------------------
                '@ 画面間情報引継処理
                '@-----------------------
                '@引継ぎｷｬﾘｱIDがNULL以外か
                If mtypCommonInfo.strCarrierId <> vbNullString Then

                    '@引継ぎｱﾝﾛｰﾀﾞｰｷｬﾘｱIDがNULL以外か
                    If mtypCommonInfo.strToCarrierId <> vbNullString Then

                        For llngCnt = .Rows.Fixed To .Rows.Count - 1

                            '@代替番号がNULL、または"0"か
                            If mtypCommonInfo.strAltPointer = vbNullString Or _
                                mtypCommonInfo.strAltPointer = CPstrZero Then

                                '@現在行のｷｬﾘｱIDと引継ぎｱﾝﾛｰﾀﾞｰｷｬﾘｱIDが同じか
                                If .GetData(llngCnt, mlngvsfAreaEqColLCarrierID) = _
                                    mtypCommonInfo.strToCarrierId Then

                                    '@一致行を選択
                                    .Row = llngCnt

                                    '@=======================
                                    '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfBeforeSort(vsfAreaEquipment, mlngvsfAreaEqColCarrierID & vbTab & _
                                                                            mlngvsfAreaEqColOpID & vbTab & _
                                                                            mlngvsfAreaEqColStepID)

                                    '@=======================
                                    '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfAfterSort(vsfAreaEquipment, mlngvsfAreaEqColCarrierID & vbTab & _
                                                                           mlngvsfAreaEqColOpID & vbTab & _
                                                                           mlngvsfAreaEqColStepID, _
                                                                           cmdUP, cmdDown, True,True,True,False,True)

                                    '@処理ﾙｰﾌﾟ抜け
                                    Exit For
                                Else
                                    '@現在行のｷｬﾘｱIDと引継ぎｱﾝﾛｰﾀﾞｰｷｬﾘｱIDが異なる場合(作業開始取消対応)

                                    '@表示ｷｬﾘｱIDと引継ぎｷｬﾘｱIDが同じか
                                    If .GetData(llngCnt, mlngvsfAreaEqColCarrierID) = _
                                        mtypCommonInfo.strCarrierId Then

                                        '@一致行を選択
                                        .Row = llngCnt

                                        '@=======================
                                        '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                        '@=======================
                                        Call pubVsfBeforeSort(vsfAreaEquipment, mlngvsfAreaEqColCarrierID & vbTab & _
                                                                                mlngvsfAreaEqColOpID & vbTab & _
                                                                                mlngvsfAreaEqColStepID)

                                        '@=======================
                                        '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                        '@=======================
                                        Call pubVsfAfterSort(vsfAreaEquipment, mlngvsfAreaEqColCarrierID & vbTab & _
                                                                               mlngvsfAreaEqColOpID & vbTab & _
                                                                               mlngvsfAreaEqColStepID, _
                                                                               cmdUP, cmdDown, True,True,True,False,True)

                                        '@処理ﾙｰﾌﾟ抜け
                                        Exit For
                                    End If
                                End If
                            Else
                                '@代替番号がNULL以外、かつ"0"以外か

                                '@ﾛｰﾀﾞｰｷｬﾘｱIDと引継ぎｱﾝﾛｰﾀﾞｰｷｬﾘｱIDが同じ、かつ代替番号も同じか
                                If .GetData(llngCnt, mlngvsfAreaEqColLCarrierID) = mtypCommonInfo.strToCarrierId And _
                                    .GetData(llngCnt, mlngvsfAreaEqColAltNumber) = mtypCommonInfo.strAltPointer Then

                                    '@一致行を選択
                                    .Row = llngCnt

                                    '@=======================
                                    '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfBeforeSort(vsfAreaEquipment, mlngvsfAreaEqColCarrierID & vbTab & _
                                                                            mlngvsfAreaEqColOpID & vbTab & _
                                                                            mlngvsfAreaEqColStepID)

                                    '@=======================
                                    '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfAfterSort(vsfAreaEquipment, mlngvsfAreaEqColCarrierID & vbTab & _
                                                                           mlngvsfAreaEqColOpID & vbTab & _
                                                                           mlngvsfAreaEqColStepID, _
                                                                           cmdUP, cmdDown, True,True,True,False,True)

                                    '@処理ﾙｰﾌﾟ抜け
                                    Exit For
                                End If
                            End If
                        Next llngCnt
                    Else
                        '@引継ぎｱﾝﾛｰﾀﾞｰｷｬﾘｱIDがNULLか

                        For llngCnt = .Rows.Fixed To .Rows.Count - 1

                            '@代替番号がNULL、または"0"か
                            If mtypCommonInfo.strAltPointer = vbNullString Or _
                                mtypCommonInfo.strAltPointer = CPstrZero Then

                                '@ﾛｰﾀﾞｰｷｬﾘｱIDと引継ぎｷｬﾘｱIDが同じか
                                If .GetData(llngCnt, mlngvsfAreaEqColLCarrierID) = _
                                    mtypCommonInfo.strCarrierId Then

                                    '@一致行を選択
                                    .Row = llngCnt

                                    '@=======================
                                    '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfBeforeSort(vsfAreaEquipment, mlngvsfAreaEqColCarrierID & vbTab & _
                                                                            mlngvsfAreaEqColOpID & vbTab & _
                                                                            mlngvsfAreaEqColStepID)

                                    '@=======================
                                    '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfAfterSort(vsfAreaEquipment, mlngvsfAreaEqColCarrierID & vbTab & _
                                                                           mlngvsfAreaEqColOpID & vbTab & _
                                                                           mlngvsfAreaEqColStepID, _
                                                                           cmdUP, cmdDown,True,True,True,False,True)

                                    '@ﾙｰﾌﾟ抜け
                                    Exit For
                                End If
                            Else
                                '@代替番号がNULL以外、かつ"0"以外か

                                '@ﾛｰﾀﾞｰｷｬﾘｱIDと引継ぎｱﾝﾛｰﾀﾞｰｷｬﾘｱIDが同じ、かつ代替番号も同じか
                                If .GetData(llngCnt, mlngvsfAreaEqColLCarrierID) = mtypCommonInfo.strCarrierId And _
                                    .GetData(llngCnt, mlngvsfAreaEqColAltNumber) = mtypCommonInfo.strAltPointer Then

                                    '@一致行を選択
                                    .Row = llngCnt

                                    '@=======================
                                    '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfBeforeSort(vsfAreaEquipment, mlngvsfAreaEqColCarrierID & vbTab & _
                                                                            mlngvsfAreaEqColOpID & vbTab & _
                                                                            mlngvsfAreaEqColStepID)

                                    '@=======================
                                    '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                    '@=======================
                                    Call pubVsfAfterSort(vsfAreaEquipment, mlngvsfAreaEqColCarrierID & vbTab & _
                                                                           mlngvsfAreaEqColOpID & vbTab & _
                                                                           mlngvsfAreaEqColStepID, _
                                                                           cmdUP, cmdDown, True,True,True,False,True)

                                    '@ﾙｰﾌﾟ抜け
                                    Exit For
                                End If
                            End If
                        Next llngCnt
                    End If

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

                '@処理順変更ﾎﾞﾀﾝを無効にする
                cmdChgSeqNum.Enabled = True

                '@画面描画に負荷が掛かった時に画面に制御を戻す
                'DoEvents

                '@ｸﾞﾘｯﾄﾞを描画する
                .Redraw = True

                'NSYS グリッドを有効化
                .Enabled = True

                'NSYS 不要なHandler処理を抑止
                RemoveHandler vsfAreaEquipment.BeforeRowColChange,AddressOf vsfAreaEquipment_BeforeRowColChange
                RemoveHandler vsfAreaEquipment.EnterCell,AddressOf vsfAreaEquipment_EnterCell

                'NSYS 先頭カラム表示および選択
                .LeftCol = CMlngvsfAreaEqColTitle

                'NSYS Handler抑止解除
                AddHandler vsfAreaEquipment.BeforeRowColChange,AddressOf vsfAreaEquipment_BeforeRowColChange
                AddHandler vsfAreaEquipment.EnterCell,AddressOf vsfAreaEquipment_EnterCell

                '@=======================
                '@ 左右("<<",">>")ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
                '@=======================
                Call pubCmdLREnable_Set(vsfAreaEquipment, cmdLeft, cmdRight)

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
    '作成日：2004/09/15 (Wed) 18:54:02 S.Deguchi
    '更新日：2009/08/25 (Tue) 09:31:14 N.Kojima
    '備　考：
    '　　　：2005/02/02 (Wed) 17:26:18 H.Wajima     ｴﾗｰ処理追加
    '　　　：2009/08/25 (Tue) 09:31:14 N.Kojima     案件№03611の対応のついでにｿｰｽ整備。
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

            'サイズを自動調整しない
        End If

    End Sub

End Class
