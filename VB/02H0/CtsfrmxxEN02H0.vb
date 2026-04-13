'ﾌｧｲﾙ名：xxEN02H0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：無機対向基板紐付/蒸着バッチ情報　メインフォーム
'作成日：2010/03/04 (Thu) 10:36:16 T.Oide
'更新日：2016/02/25 (Thu) 09:11:03 H.Hayashi
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02H0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02H0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02H0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02H0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02H0)
            Dim old_inst As Form
            old_inst = _instance
            _instance = value
            If old_inst IsNot Nothing AndAlso Not old_inst.IsDisposed Then
                old_inst.Close()
                old_inst.Dispose()
            End If
        End Set
    End Property

    '******************************************************************************************
    '                                       *定数の記述*
    '******************************************************************************************
    '=========================================Private==========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2012/03/16 (Fri) 17:11:58 T.Oide **************************************************
    '@Private Const CMstrLocalVersion                 As String = "01.00"
    Private Const CMstrLocalVersion                 As String = "01.01"
    '@↑2012/03/16 (Fri) 17:11:58 T.Oide **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN02H0      'ﾛｰｶﾙ機能ID
    '@↓2016/01/28 (Thu) 16:39:12 H.Hayashi **************************************************
    'Private Const CMstrlot_detail__Ver              As String = "02.05"                 'ﾛｯﾄ詳細情報
    Private Const CMstrlot_detail__Ver              As String = "03.00"                 'ﾛｯﾄ詳細情報
    '@↑2016/01/28 (Thu) 16:39:12 H.Hayashi **************************************************
    '@Msgﾊﾞｰｼﾞｮﾝ

    Private Const CMstrlot_relationmklotlistVer     As String = "01.00"             '紐付きMKﾛｯﾄﾘｽﾄ情報
    Private Const CMstrlot_cfrelationjbatchinfVer   As String = "01.00"             '対向基板紐付き/J蒸着ﾊﾞｯﾁ情報


    '@vsf共通のｶﾗﾑ定数
    Private Const CMlngvsfCFHistoryRowTitle         As Integer = 0                  '行ﾀｲﾄﾙ
    Private Const CMlngvsfCFHistoryColTitle         As Integer = 0                  '列ﾀｲﾄﾙ
    Private Const CMlngvsfCFHistoryHHeight          As Integer = 20                 'ﾍｯﾀﾞｰ高さ
    Private Const CMlngvsfCFHistoryHeight           As Integer = 18                 '行高さ
    Private Const CMlngvsfCFHistoryHFontSize        As Integer = 11                 'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ：11
    Private Const CMlngvsfCFHistoryFontSize         As Integer = 11                 'ﾌｫﾝﾄｻｲｽﾞ：11


    '@ｸﾞﾘｯﾄﾞの列設定(vsfCF)
    Private Const CMlngvsfCFLotID                   As Integer = 0                  'ﾛｯﾄID
    Private Const CMlngvsfCFPD                      As Integer = 1                  '機種
    Private Const CMlngvsfCFFlowClass               As Integer = 2                  '種別
    Private Const CMlngvsfCFThrowINDayTime          As Integer = 3                  '投入日時
    Private Const CMlngvsfCFThrowINNum              As Integer = 4                  '投入数量
    Private Const CMlngvsfCFMKLotIssue              As Integer = 5                  'MKﾛｯﾄ払出
    Private Const CMlngvsfCFEmpName                 As Integer = 6                  '作業者
    Private Const CMlngvsfCFStatus                  As Integer = 7                  '現在状態

    '@ｸﾞﾘｯﾄﾞの幅設定(vsfCF)
    Private Const CMlngvsfCFLotIDW                  As Integer = 100                'ﾛｯﾄID
    Private Const CMlngvsfCFPDW                     As Integer = 60                 '機種
    Private Const CMlngvsfCFFlowClassW              As Integer = 60                 '種別
    Private Const CMlngvsfCFThrowINDayTimeW         As Integer = 170                '投入日時
    Private Const CMlngvsfCFThrowINNumW             As Integer = 120                '投入数量
    Private Const CMlngvsfCFMKLotIssueW             As Integer = 120                'MKﾛｯﾄ払出
    Private Const CMlngvsfCFEmpNameW                As Integer = 130                '作業者
    Private Const CMlngvsfCFStatusW                 As Integer = 130                '現在状態

    '@ｸﾞﾘｯﾄﾞのﾀｲﾄﾙ設定(vsfCF)
    Private Const CMstrvsfCFLotIDN                  As String = "ロットID"
    Private Const CMstrvsfCFPDN                     As String = "機種"
    Private Const CMstrvsfCFFlowClassN              As String = "種別"
    Private Const CMstrvsfCFThrowINDayTimeN         As String = "投入日時"
    Private Const CMstrvsfCFThrowINNumN             As String = "投入数量(chip)"
    Private Const CMstrvsfCFMKLotIssueN             As String = "MKロット払出数"
    Private Const CMstrvsfCFEmpNameN                As String = "作業者"
    Private Const CMstrvsfCFStatusN                 As String = "現在状態"

    '@ｸﾞﾘｯﾄﾞの列設定(vsfMK)
    Private Const CMlngvsfMKLotID                   As Integer = 0                  'ﾛｯﾄID
    Private Const CMlngvsfMKPD                      As Integer = 1                  '機種
    Private Const CMlngvsfMKFlowClass               As Integer = 2                  '種別
    Private Const CMlngvsfMKThrowINDayTime          As Integer = 3                  '投入日時
    Private Const CMlngvsfMKThrowINNum              As Integer = 4                  '投入数量
    Private Const CMlngvsfMKCarrierID               As Integer = 5                  'キャリアID
    Private Const CMlngvsfMKEmpName                 As Integer = 6                  '作業者
    Private Const CMlngvsfMKStatus                  As Integer = 7                  '現在状態

    '@ｸﾞﾘｯﾄﾞの幅設定(vsfMK)
    Private Const CMlngvsfMKLotIDW                  As Integer = 100                'ﾛｯﾄID
    Private Const CMlngvsfMKPDW                     As Integer = 60                 '機種
    Private Const CMlngvsfMKFlowClassW              As Integer = 60                 '種別
    Private Const CMlngvsfMKThrowINDayTimeW         As Integer = 170                '投入日時
    Private Const CMlngvsfMKThrowINNumW             As Integer = 120                '投入数量
    Private Const CMlngvsfMKCarrierIDW              As Integer = 120                'キャリアID
    Private Const CMlngvsfMKEmpNameW                As Integer = 130                '作業者
    Private Const CMlngvsfMKStatusW                 As Integer = 130                '現在状態

    '@ｸﾞﾘｯﾄﾞのﾀｲﾄﾙ設定(vsfMK)
    Private Const CMstrvsfMKLotIDN                  As String = "ロットID"
    Private Const CMstrvsfMKPDN                     As String = "機種"
    Private Const CMstrvsfMKFlowClassN              As String = "種別"
    Private Const CMstrvsfMKThrowINDayTimeN         As String = "投入日時"
    Private Const CMstrvsfMKThrowINNumN             As String = "投入数量(chip)"
    Private Const CMstrvsfMKCarrierIDN              As String = "投入キャリアID"
    Private Const CMstrvsfMKEmpNameN                As String = "作業者"
    Private Const CMstrvsfMKStatusN                 As String = "現在状態"

    '@ｸﾞﾘｯﾄﾞの列設定(vsfTP)
    Private Const CMlngvsfTPLotID                   As Integer = 0                  'ﾛｯﾄID
    Private Const CMlngvsfTPPD                      As Integer = 1                  '機種
    Private Const CMlngvsfTPFlowClass               As Integer = 2                  '種別
    Private Const CMlngvsfTPThrowINDayTime          As Integer = 3                  '投入日時
    Private Const CMlngvsfTPThrowINNum              As Integer = 4                  '投入数量
    Private Const CMlngvsfTPMKLR                    As Integer = 5                  '左/右
    Private Const CMlngvsfTPEmpName                 As Integer = 6                  '作業者
    Private Const CMlngvsfTPStatus                  As Integer = 7                  '現在状態

    '@ｸﾞﾘｯﾄﾞの幅設定(vsfTP)
    Private Const CMlngvsfTPLotIDW                  As Integer = 100                'ﾛｯﾄID
    Private Const CMlngvsfTPPDW                     As Integer = 60                 '機種
    Private Const CMlngvsfTPFlowClassW              As Integer = 60                 '種別
    Private Const CMlngvsfTPThrowINDayTimeW         As Integer = 170                '投入日時
    Private Const CMlngvsfTPThrowINNumW             As Integer = 120                '投入数量
    Private Const CMlngvsfTPMKLRW                   As Integer = 120                '左/右
    Private Const CMlngvsfTPEmpNameW                As Integer = 130                '作業者
    Private Const CMlngvsfTPStatusW                 As Integer = 130                '現在状態

    '@ｸﾞﾘｯﾄﾞのﾀｲﾄﾙ設定(vsfTP)
    Private Const CMstrvsfTPLotIDN                  As String = "ロットID"
    Private Const CMstrvsfTPPDN                     As String = "機種"
    Private Const CMstrvsfTPFlowClassN              As String = "種別"
    Private Const CMstrvsfTPThrowINDayTimeN         As String = "投入日時"
    Private Const CMstrvsfTPThrowINNumN             As String = "投入数量(chip)"
    Private Const CMstrvsfTPMKLRN                   As String = "左/右"
    Private Const CMstrvsfTPEmpNameN                As String = "作業者"
    Private Const CMstrvsfTPStatusN                 As String = "現在状態"

    '@ｸﾞﾘｯﾄﾞの列設定(vsfTFT)
    Private Const CMlngvsfTFTLotID                  As Integer = 0                  'ﾛｯﾄID
    Private Const CMlngvsfTFTPD                     As Integer = 1                  '機種
    Private Const CMlngvsfTFTFlowClass              As Integer = 2                  '種別
    Private Const CMlngvsfTFTThrowINDayTime         As Integer = 3                  '投入日時
    Private Const CMlngvsfTFTThrowINNum             As Integer = 4                  '投入数量
    Private Const CMlngvsfTFTHari                   As Integer = 5                  '貼合せ
    Private Const CMlngvsfTFTEmpName                As Integer = 6                  '作業者
    Private Const CMlngvsfTFTStatus                 As Integer = 7                  '現在状態

    '@ｸﾞﾘｯﾄﾞの幅設定(vsfTFT)
    Private Const CMlngvsfTFTLotIDW                 As Integer = 100                'ﾛｯﾄID
    Private Const CMlngvsfTFTPDW                    As Integer = 60                 '機種
    Private Const CMlngvsfTFTFlowClassW             As Integer = 60                 '種別
    Private Const CMlngvsfTFTThrowINDayTimeW        As Integer = 170                '投入日時
    Private Const CMlngvsfTFTThrowINNumW            As Integer = 120                '投入数量
    Private Const CMlngvsfTFTHariW                  As Integer = 120                '貼合せ
    Private Const CMlngvsfTFTEmpNameW               As Integer = 130                '作業者
    Private Const CMlngvsfTFTStatusW                As Integer = 130                '現在状態

    '@ｸﾞﾘｯﾄﾞのﾀｲﾄﾙ設定(vsfTFT)
    Private Const CMstrvsfTFTLotIDN                 As String = "ロットID"
    Private Const CMstrvsfTFTPDN                    As String = "機種"
    Private Const CMstrvsfTFTFlowClassN             As String = "種別"
    Private Const CMstrvsfTFTThrowINDayTimeN        As String = "投入日時"
    Private Const CMstrvsfTFTThrowINNumN            As String = "投入数量(wf)"
    Private Const CMstrvsfTFTHariN                  As String = "貼合せ"
    Private Const CMstrvsfTFTEmpNameN               As String = "作業者"
    Private Const CMstrvsfTFTStatusN                As String = "現在状態"

    '@ｸﾞﾘｯﾄﾞの列設定(vsfBatch)
    Private Const CMlngvsfBatchID                   As Integer = 0                  'ﾊﾞｯﾁID
    Private Const CMlngvsfBatchEntryTime            As Integer = 1                  'ﾊﾞｯﾁ編成日時
    Private Const CMlngvsfBatchNum                  As Integer = 2                  'ﾊﾞｯﾁwf数
    Private Const CMlngvsfBatchEnpName              As Integer = 3                  '作業者

    '@ｸﾞﾘｯﾄﾞの幅設定(vsfBatch)
    Private Const CMlngvsfBatchIDW                  As Integer = 100                'ﾊﾞｯﾁID
    Private Const CMlngvsfBatchEntryTimeW           As Integer = 170                'ﾊﾞｯﾁ編成日時
    Private Const CMlngvsfBatchNumW                 As Integer = 100                'ﾊﾞｯﾁwf数
    Private Const CMlngvsfBatchEnpNameW             As Integer = 130                '作業者

    '@ｸﾞﾘｯﾄﾞのﾀｲﾄﾙ設定(vsfBatch)
    Private Const CMstrvsfBatchIDN                  As String = "バッチID"
    Private Const CMstrvsfBatchEntryTimeN           As String = "バッチ編成日時"
    Private Const CMstrvsfBatchNumN                 As String = "バッチwf数"
    Private Const CMstrvsfBatchEnpNameN             As String = "作業者"

    '@ｸﾞﾘｯﾄﾞの列設定(vsfShelf)
    Private Const CMlngvsfShelfSeq                   As Integer = 0                 '順
    Private Const CMlngvsfShelfJigID                 As Integer = 1                 '治具ID
    Private Const CMlngvsfShelfLotID                 As Integer = 2                 'ﾛｯﾄID
    Private Const CMlngvsfShelfWFID                  As Integer = 3                 'WF_ID

    '@ｸﾞﾘｯﾄﾞの幅設定(vsfShelf)
    Private Const CMlngvsfShelfSeqW                  As Integer = 30                '順
    Private Const CMlngvsfShelfJigIDW                As Integer = 100               '治具ID
    Private Const CMlngvsfShelfLotIDW                As Integer = 100               'ﾛｯﾄID
    Private Const CMlngvsfShelfWFIDW                 As Integer = 120               'WF_ID

    '@ｸﾞﾘｯﾄﾞのﾀｲﾄﾙ設定(vsfShelf)
    Private Const CMstrvsfShelfSeqN                  As String = "順"
    Private Const CMstrvsfShelfJigIDN                As String = "治具ID"
    Private Const CMstrvsfShelfLotIDN                As String = "ロットID"
    Private Const CMstrvsfShelfWFIDN                 As String = "WF_ID"

    '@情報取得ｺﾝﾄﾛｰﾙ名(ｷｬﾘｱ/ﾛｯﾄ)
    Private Const CMstrInfoGetControlNameCarrier    As String = "txtCarrier"        'ｷｬﾘｱIDのｺﾝﾄﾛｰﾙ名
    Private Const CMstrInfoGetControlNameLot        As String = "txtLot"            'ﾛｯﾄIDのｺﾝﾄﾛｰﾙ名

    '@その他宣言
    Private Const CMstrALot                         As String = "A"                 'Aﾛｯﾄ(特殊流動ﾛｯﾄ)
    Private Const CMstrRLot                         As String = "R"                 'Rﾛｯﾄ(ﾘﾜｰｸﾛｯﾄ)
    Private Const CMstrMLot                         As String = "M"                 'Mﾛｯﾄ(移載ﾛｯﾄ)
    Private Const CMstrLotClassMK                   As String = "MK"                'ﾛｯﾄｸﾗｽ(MK)
    Private Const CMstrLotClassTP                   As String = "TP"                'ﾛｯﾄｸﾗｽ(TP)


    Private Const CMlngCarrierMaxLength             As Integer = 6                  'ｷｬﾘｱIDの最大桁数
    Private Const CMlngLotMaxLength                 As Integer = 10                 'ﾛｯﾄIDの最大桁数

    '@CFﾌﾗｸﾞの値
    Private Const CMstrCF_FLAG_0                    As Integer = 0                  'CF_FLAG = TFT
    Private Const CMstrCF_FLAG_1                    As Integer = 1                  'CF_FLAG = CF/MK
    Private Const CMstrCF_FLAG_2                    As Integer = 2                  'CF_FLAG = TP
    Private Const CMstrVA_FLAG_0                    As Integer = 0                  'VA_FLAG = 有機
    Private Const CMstrVA_FLAG_1                    As Integer = 1                  'VA_FLAG = 無機

    '@貼合の種別
    Private Const CMstrTpalBatchLRName              As String = "ﾊﾞｯﾁ＋左右貼合"    'ﾊﾞｯﾁ＋左右貼合
    Private Const CMstrTpalLRName                   As String = "左右別貼合"        '左右別貼合
    Private Const CMstrTpalBatchName                As String = "バッチ貼合"        'バッチ貼合

    '@色宣言
    Private Const CMlngEnableFalseColor             As Integer = &H80000016         '灰色(使用不可)
    Private Const CMlngEnableTrueColor              As Integer = &H80000005         '白(使用可)
    Private Const CMlngOkForeColor                  As Integer = &H0                '黒色(通常色)
    Private Const CMlngNgForeColor                  As Integer = &HFF               '赤(ｴﾗｰ色)
    Private Const CMlngOKBackColor                  As Integer = &HFFC0C0           '藤色(ﾗｲﾄﾌﾞﾙｰ)
    Private Const CMlngInputColor                   As Integer = &HC0C0FF           'ﾋﾟﾝｸ
    Private Const CMlngNotInputColor                As Integer = &HE0E0E0           '薄灰色
    Private Const CMlngRetainColor                  As Integer = &HFFFFC0           '水色(引継情報)

    Private Const CMlngMaxSlotNo                    As Integer = 25                 'ｽﾛｯﾄ№の最大値
    Private Const CMlngInputClassMaxByte            As Integer = 30                 'ﾃﾞｰﾀ分類名の最大ﾊﾞｲﾄ数
    Private Const CMlngInputDataMaxByte             As Integer = 256                '文字入力の最大ﾊﾞｲﾄ数
    Private Const CMlngInputNumberMaxByte           As Integer = 35                 '数字入力の最大ﾊﾞｲﾄ数
    Private Const CMlngColonKeyAscii                As Integer = 58                 'ｺﾛﾝ(DV_NAMEｾﾊﾟﾚｰﾄ用)ｱｽｷｰ定数
    Private Const CMstrColon                        As String = ":"                 'ｺﾛﾝ(DV_NAMEｾﾊﾟﾚｰﾄ用)
    Private Const CMstrNoInputString                As String = "'"                 '禁則文字："'"

    'その他(数値定数)
    Private Const CMlngOne                          As Integer = 1                  '1(数値)


    '******************************************************************************************
    '                                       *変数の記述*
    '******************************************************************************************
    '=========================================Private==========================================
    Private mblnFormStartKbn                        As Boolean                      'ﾌｫｰﾑ起動区分(True:親ﾌｫｰﾑから起動、False:自ﾌｫｰﾑ起動)
    Private mblnTakeOverDispFlg                     As Boolean                      '引継ぎ表示ﾌﾗｸﾞ
    Private mstrInfoGetControlName                  As String                       '抽出ｺﾝﾄﾛｰﾙ(ｷｬﾘｱID or ﾛｯﾄID)
    Private mstrTaihiCarrierID                      As String                       'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mstrTaihiLotID                          As String                       'ﾛｯﾄ情報取得時のﾛｯﾄID(ﾒｯｾｰｼﾞ成功取得時)
    Private mblncmbMKLotChangeCancel                As Boolean                      'ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞ(cmbMKLot)
    Private mblntxtLotChangeCancel                  As Boolean                      'ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞ(txtLot)
    Private mblntxtCarrierChangeCancel              As Boolean                      'ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞ(txtCarrier)
    Private mblnCfRelationJbatchInfGet              As Boolean                      '無機対向基板紐付/蒸着バッチ情報ﾃﾞｰﾀ取得ﾌﾗｸﾞ

    Private buttonProcessing                        As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                      'NSYS WindowCloseフラグ

    '******************************************************************************************
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
        pubVsfMouseWheelManager_Set(vsfShelf, cmdTxtUpBatch, cmdTxtDownBatch)
        pubVsfMouseWheelManager_Set(vsfTFT, cmdTxtUptft, cmdTxtDowntft)
        pubVsfMouseWheelManager_Set(vsfCF, cmdTxtUpcf, cmdTxtDowncf)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                                 *イベントハンドラの記述*
    '******************************************************************************************
    '=========================================Private==========================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2010/03/05 (Fri) 11:02:07 T.Oide
    '更新日：2010/03/05 (Fri) 11:02:07
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns         As Boolean      '戻り値

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN02H0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If

            '@ﾌｫｰﾑ起動区分の設定
            mblnFormStartKbn = pblnfrmxxEN02H0kbn

            '@情報取得ｺﾝﾄﾛｰﾙ名(ｷｬﾘｱ/ﾛｯﾄ)のｸﾘｱ
            mstrInfoGetControlName = vbNullString
            
            'NSYS 表示位置設定
            Top = 0
            Left = -My.Settings.FormOffset
            
            '@画面初期化
            Call prvfrmxxEN02H0_Init()

            '@ﾌｫｰﾑ起動区分判定
            If mblnFormStartKbn = False Then
            '@単体起動の場合
                '@ｷｬﾘｱIDを使用可能
                txtCarrier.Enabled = True
                txtCarrier.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                
                '@ﾛｯﾄIDを使用可能
                txtLot.Enabled = True
                txtLot.BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)
                
                '@引継ぎ情報初期化
                With ptypCommonInfo
                    .strCarrierId = vbNullString    'ｷｬﾘｱID
                    .strDivision = vbNullString     '処理区分
                    .strLotID = vbNullString        'ﾛｯﾄID
                    .strOpID = vbNullString         '大工程
                    .strStepID = vbNullString       '小工程
                    .strWpID = vbNullString         '装置ID
                    .strWpName = vbNullString       '装置名
                End With
                
                '@Form_Loadﾌﾗｸﾞ(正常)
                pblnFormLoad = True
            Else
            '@親ﾌｫｰﾑから起動の場合
                '@ｷｬﾘｱIDを使用不可能
                With txtCarrier
                    .Enabled = True
                    .Locked = True
                    .TabStop = False
                    .BackColor = ColorTranslator.FromWin32(CMlngEnableFalseColor)
                    .GotBackColor = ColorTranslator.FromWin32(CMlngEnableFalseColor)
                    .GotHighLight = False
                    .Text = ptypCommonInfo.strCarrierId
                End With
                
                '@ﾛｯﾄIDを使用不可能
                With txtLot
                    .Enabled = True
                    .Locked = True
                    .TabStop = False
                    .BackColor = ColorTranslator.FromWin32(CMlngEnableFalseColor)
                    .GotBackColor = ColorTranslator.FromWin32(CMlngEnableFalseColor)
                    .GotHighLight = False
                    .Text = ptypCommonInfo.strLotID
                End With
                
                '@ｷｬﾘｱIDの自動取得
                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(True))
            End If
            
            '@引継ぎ情報表示済みﾌﾗｸﾞ
            mblnTakeOverDispFlg = False
            
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
    '作成日：2005/01/24 (Mon) 10:44:16 S.Deguchi
    '更新日：2005/01/24 (Mon) 10:44:16
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@親ﾌｫｰﾑ起動の場合
            If mblnFormStartKbn = True Then
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                '@処理を抜ける
                Exit Sub
            End If
                
            '@引継ぎ情報表示済みﾌﾗｸﾞの判定
            '@FormLoad後、最初の1回しか処理しない
            If mblnTakeOverDispFlg = True Then
            '@引継ぎ情報が表示済みの場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose
            
            '@引継ぎ情報表示済みﾌﾗｸﾞにTrueを設定する
            mblnTakeOverDispFlg = True

            '@引数のｷｬﾘｱIDが空白かどうか判定する
            If ptypCommonInfo.strCarrierId <> vbNullString Then
            '@空白でない場合
                '@ｷｬﾘｱIDの初期値を設定する
                txtCarrier.Text = ptypCommonInfo.strCarrierId
                
                '@情報取得ｺﾝﾄﾛｰﾙ名(ｷｬﾘｱ/ﾛｯﾄ)の設定
                mstrInfoGetControlName = CMstrInfoGetControlNameCarrier

                '@ｷｬﾘｱID情報取得
                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                
                
            Else
                '@ｷｬﾘｱID初期化
                ptypCommonInfo.strCarrierId = vbNullString
            End If
            
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

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2005/01/24 (Mon) 10:45:38 S.Deguchi
    '更新日：2008/05/08 (Thu) 11:31:20 N.Kojima
    '備　考：
    '　　　：2008/05/08 (Thu) 11:31:20 N.Kojima     装置ﾃﾞｰﾀｸﾞﾘｯﾄﾞのﾌｫｰｶｽ制御対応。(案件№02853)
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
            
            '@ｺﾝﾄﾛｰﾙによって処理分岐
            Select Case ActiveControl.Name
            
                '@ｷｬﾘｱIDにﾌｫｰｶｽがある場合
                Case txtCarrier.Name
                    '@Enterの場合
                    Select Case e.KeyCode
                    
                        Case Keys.Return
                            '@ﾛｯﾄ情報取得処理へ
                            Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                            
                    End Select
                
                '@ﾛｯﾄIDにﾌｫｰｶｽがある場合
                Case txtLot.Name
                
                    '@Enterの場合
                    Select Case e.KeyCode
                    
                        Case Keys.Return
                            '@ﾛｯﾄ情報取得処理へ
                            Call txtLot_Validate(txtLot, New CancelEventArgs(False))
                            
                    End Select
                
                
                '@CFｸﾞﾘｯﾄﾞの場合
                Case vsfCF.Name
                
                    '@装置ｸﾞﾘｯﾄﾞｷｰ制御
                    Call pubVsf_KeyDown(e, ActiveControl.Name, vsfCF, cmdTxtUpcf, cmdTxtDowncf)
                
                
                '@TFTｸﾞﾘｯﾄﾞの場合
                Case vsfTFT.Name
                
                    '@装置ｸﾞﾘｯﾄﾞｷｰ制御
                    Call pubVsf_KeyDown(e, ActiveControl.Name, vsfTFT, cmdTxtUptft, cmdTxtDowntft)
                
                
                '@その他のｺﾝﾄﾛｰﾙにﾌｫｰｶｽがある場合
                Case Else
                    
                    '@Enterの場合
                    Select Case e.KeyCode
                        
                        Case Keys.Return
                            
                            '@次ﾌｫｰｶｽへ
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

    '関数名：Form_KeyPress
    '機　能：ﾌｫｰﾑｷｰﾌﾟﾚｽ処理
    '引　数：KeyAscii：ｱｽｷｰｺｰﾄﾞ
    '戻り値：なし
    '作成日：2005/01/24 (Mon) 10:45:42 S.Deguchi
    '更新日：2005/01/24 (Mon) 10:45:42
    '備　考：
    Private Sub Form_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles MyBase.KeyPress

        Try

            Select Case Asc(e.KeyChar)
                '@ｺﾛﾝ(:)58の場合は入力不可
                Case CMlngColonKeyAscii
                   e.Handled = True
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_KeyPress"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2005/01/24 (Mon) 10:45:45 S.Deguchi
    '更新日：2005/01/24 (Mon) 10:45:45
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, EventArgs.Empty)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            
            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
            pblnFormLoad = False
            
            '@ﾌﾟﾗｲﾍﾞｰﾄ変数のｸﾘｱ
            '@自ﾌｫｰﾑ起動の場合はACT開放後、終了する
            If mblnFormStartKbn = False Then
                '@ActInitﾌﾗｸﾞの判定
                If pblnActInitFlg = True Then
                    
                    '@Actを自前で初期化した場合
                    '@ACTｵﾌﾞｼﾞｪｸﾄの開放
                    lblnAnsTerm = pubblnAct_Term
                    
                    If lblnAnsTerm = True Then
                        '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                    End If
                Else
                    '@単独機動か否かで処理分岐
                    If pblnfrmxxEN02H0kbn = False Then
                        '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                        Call pubMenuExpand_Disp()
                    End If
                End If
            End If
            
            '@変数初期化
            mblnCfRelationJbatchInfGet = False          'ﾃﾞｰﾀ取得ﾌﾗｸﾞ
            
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
    '機　能："閉じる"ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2010/03/08 (Mon) 11:29:47 T.Oide
    '更新日：2010/03/08 (Mon) 11:29:47
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim ltypCommonInfo  As CommonInfo   '戻り構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@親ﾌｫｰﾑ起動の場合
            If mblnFormStartKbn = True Then
                '@ﾌｫｰﾑを閉じる
                Me.Close()
            Else
                '@引継ぎ情報のｷｬﾘｱIDが空白かどうか判定する
                If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@空白でない場合
                    '@装置別ﾛｯﾄ一覧から引き継いで起動された場合
                    If pblnfrmxxEN0150Kbn = True Then
                        '@装置別ﾛｯﾄ一覧を起動する
                        Call pubMenuSelect_Proc(CPstrKeyEN0150)
                    Else
                        '@装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧から引き継いで起動された場合
                        If pblnfrmxxEN00J0Kbn = True Then
                            '@装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧を起動する
                            Call pubMenuSelect_Proc(CPstrKeyEN00J0)
                        Else
                        '@工程別ﾛｯﾄ一覧から引き継いで起動された場合
                            '@工程別ﾛｯﾄ一覧を起動する
                            Call pubMenuSelect_Proc(CPstrKeyEN0200)
                        End If
                    End If
                Else
                '@空白の場合
                    '@終了関数を実行する
                    Call publngEnd_Proc(CPstrKeyEN02H0, ltypCommonInfo)
                End If
            End If

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

    '関数名：txtCarrier_Change
    '機　能：ｷｬﾘｱIDChange処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/24 (Mon) 11:33:37 S.Deguchi
    '更新日：2005/01/24 (Mon) 11:33:37
    '備　考：
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change
        
        Try
            
            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞが立っている時は処理中止
            If mblntxtCarrierChangeCancel = True Then
                Exit Sub
            End If
            
            '@情報取得ｺﾝﾄﾛｰﾙがｷｬﾘｱIDではない場合(処理終了)
            If mstrInfoGetControlName <> CMstrInfoGetControlNameCarrier Then
                Exit Sub
            End If
            
            '@画面の初期化
            Call prvfrmxxEN02H0_Init()
                
        Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrier_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_GotFocus
    '機　能：ｷｬﾘｱIDGotFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/25 (Tue) 14:15:04 S.Deguchi
    '更新日：2005/01/25 (Tue) 14:15:04
    '備　考：
    Private Sub txtCarrier_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Enter

        Try

            '@情報取得ｺﾝﾄﾛｰﾙ設定
            mstrInfoGetControlName = CMstrInfoGetControlNameCarrier
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrier_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Validate
    '機　能：ｷｬﾘｱ情報取得
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2010/03/09 (Tue) 15:34:04 T.Oide
    '更新日：2010/03/09 (Tue) 15:34:04
    '備　考：
    Public Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating
        
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypLotDetailInfo       As LotDetailInfo        'ﾛｯﾄ詳細情報格納用
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｷｬﾘｱIDの空白ﾁｪｯｸ
            If Trim(txtCarrier.Text) = vbNullString Then
                '@ﾌｫｰｶｽ設定
                Call prvcontrolSetFocus_Set(vbNullString)
                
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtCarrier.NowByte < txtCarrier.ChrMaxByte Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                e.Cancel = True
                
                Exit Sub
            End If

            '@ｷｬﾘｱID情報の取得(入力ｷｬﾘｱIDと前回のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功)と違う場合のみ実行)
            If txtCarrier.Text <> mstrTaihiCarrierID Then
            
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(Me.Name, "txtCarrier_Validate")
                
                '@ﾛｯﾄ詳細情報の取得
                lblnAns = prvblnlotdetail_Get(CPstrCD0K, ltypLotDetailInfo, txtCarrier.Text)
                
                '@結果判定
                If lblnAns = True Then
                
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Name, "txtCarrier_Validate")
                    
                    '取得したﾛｯﾄIDを設定
                    mblntxtLotChangeCancel = True
                    txtLot.Text = ltypLotDetailInfo.strLotID
                    mblntxtLotChangeCancel = False
                    
                    '流動区分を設定
                    lblFlowClass.Text = ltypLotDetailInfo.strFlowClass
                    
                    '@次の処理判定
                    Call prvNextProcJudge(ltypLotDetailInfo)
                    
                    '@cmbMKが有効だったらﾌｫｰｶｽをｾｯﾄ
                    If cmbMKLot.Enabled = True Then
                        If ActiveControl Is txtCarrier Then
                            RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                            Call pubSetFocus(cmbMKLot)
                            AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                        End If
                    End If
                    
                    
                Else
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, "txtCarrier_Validate")
                End If
            
            Else
                '@ﾌｫｰｶｽ設定
                Call prvcontrolSetFocus_Set(vbNullString)
                
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtCarrier_Validate"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLot_Change
    '機　能：
    '引　数：なし
    '戻り値：
    '作成日：2010/03/24 (Wed) 10:11:22 T.Oide
    '更新日：2010/03/24 (Wed) 10:11:22
    '備　考：
    Private Sub txtLot_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLot.Change

        Try
            
            '@ｷｬﾝｾﾙﾌﾗｸﾞが立っている時は終了
            If mblntxtLotChangeCancel = True Then
                Exit Sub
            End If
            
            '@画面初期化
            Call prvfrmxxEN02H0_Init()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLot_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtLot_GotFocus
    '機　能ﾛｯﾄIDGotFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：2010/03/10 (Wed) 09:13:01 T.Oide
    '更新日：2010/03/10 (Wed) 09:13:01
    '備　考：
    Private Sub txtLot_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtLot.Enter

        Try

            '@情報取得ｺﾝﾄﾛｰﾙ設定
            mstrInfoGetControlName = CMstrInfoGetControlNameLot

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLot_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotID_Validate
    '機　能：ﾛｯﾄ情報取得
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2010/03/09 (Tue) 15:35:30 T.Oide
    '更新日：2010/03/09 (Tue) 15:35:30
    '備　考：
    Public Sub txtLot_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtLot.Validating

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypLotDetailInfo       As LotDetailInfo        'ﾛｯﾄ情報詳細の結果格納
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ﾛｯﾄIDの空白ﾁｪｯｸ
            If Trim(txtLot.Text) = vbNullString Then
                '@ﾌｫｰｶｽ設定
                Call prvcontrolSetFocus_Set(vbNullString)
                
                Exit Sub
            End If
            
            '@ﾛｯﾄIDの桁ﾁｪｯｸ
            If txtLot.NowByte < txtLot.ChrMaxByte Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0012)
                '@"ロットIDは10桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                e.Cancel = True
                
                Exit Sub
            End If

            '@ﾛｯﾄID情報の取得(入力ﾛｯﾄIDと前回のﾛｯﾄID(ﾒｯｾｰｼﾞ成功)と違う場合のみ実行)
            If txtLot.Text <> mstrTaihiLotID Then
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(Me.Name, "txtLotID_Validate")
                
                '@ﾛｯﾄ詳細情報の取得
                lblnAns = prvblnlotdetail_Get(CPstrCD0L, ltypLotDetailInfo, txtLot.Text)
                
                '@結果判定
                If lblnAns = True Then
                                
                    '@流動区分を設定
                    lblFlowClass.Text = ltypLotDetailInfo.strFlowClass
                    
                    '@ｷｬﾘｱIDを設定
                    mblntxtCarrierChangeCancel = True
                    txtCarrier.Text = ltypLotDetailInfo.strCarrierId
                    mblntxtCarrierChangeCancel = False
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(Me.Name, "txtLotID_Validate")
                    
                    '@次の処理を判定
                    Call prvNextProcJudge(ltypLotDetailInfo)
                    
                    '@cmbMKが有効だったらﾌｫｰｶｽをｾｯﾄ
                    If cmbMKLot.Enabled = True Then
                        If ActiveControl Is txtLot Then
                            RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                            Call pubSetFocus(cmbMKLot)
                            AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                        End If
                    End If
                    
                Else
                    '@ﾛｯﾄIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, "txtLotID_Validate")
                    
                End If
            
            Else
                '@ﾌｫｰｶｽ設定
                Call prvcontrolSetFocus_Set(vbNullString)
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtLot_Validate"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMKLot_Change
    '機　能：@CFの紐付け情報取得呼び出し
    '引　数：なし
    '戻り値：
    '作成日：2010/03/10 (Wed) 16:52:01 T.Oide
    '更新日：2010/03/10 (Wed) 16:52:01
    '備　考：
    Private Sub cmbMKLot_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMKLot.Change

        Try
            
            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞがTrueの場合は終了
            If mblncmbMKLotChangeCancel = True Then
                Exit Sub
            End If
            
            '@MKロットが選択されていない場合は終了
            If cmbMKLot.Text = vbNullString Then
                Exit Sub
            End If
            
            '@既にﾃﾞｰﾀ取得済みの場合は初期化してから再表示
            If mblnCfRelationJbatchInfGet = True Then
                
                '@ｸﾞﾘｯﾄの初期化
                Call prvvsfSlotMap_init(vsfCF)
                Call prvvsfSlotMap_init(vsfMK)
                Call prvvsfSlotMap_init(vsfTP)
                Call prvvsfSlotMap_init(vsfTFT)
                Call prvvsfSlotMap_init(vsfBatch)
                Call prvvsfSlotMap_init(vsfShelf)
                
                mblnCfRelationJbatchInfGet = False
                
            End If
            
            
            '@CFの紐付け情報取得&表示
            Call prvMKLotRelationInfoGet(cmbMKLot.Text, CMstrLotClassMK)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMKLot_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCFHistry_Click
    '機　能：CFロット払出履歴画面表示
    '引　数：なし
    '戻り値：
    '作成日：2010/03/08 (Mon) 11:36:30 T.Oide
    '更新日：2010/03/08 (Mon) 11:36:30
    '備　考：
    Private Sub cmdCFHistry_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCFHistry.Click
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '選択されているCFﾛｯﾄIDを渡してCFﾛｯﾄ払出履歴画面を起動する
            pstrCFLotID = vsfCF.GetData(vsfCF.Row, CMlngvsfCFLotID)
            
            If pstrCFLotID <> vbNullString Then
                frmxxEN02H1.Instance.ShowDialog(Me)
                frmxxEN02H1.Instance = Nothing
            End If
            
            '変数初期化
            pstrCFLotID = vbNullString
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCFHistry_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfCF_EnterCell
    '機　能：CFﾛｯﾄ払出履歴ﾎﾞﾀﾝを有効/無効化する
    '引　数：なし
    '戻り値：
    '作成日：2010/03/24 (Wed) 12:46:30 T.Oide
    '更新日：2010/03/24 (Wed) 12:46:30
    '備　考：
    Private Sub vsfCF_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfCF.EnterCell

        Try
            
            With vsfCF
            
                '@選択したセルは空か
                If .Row >= .Rows.Fixed AndAlso .GetData(.Row, 0) <> vbNullString Then
                
                    '@CFﾛｯﾄ払出履歴ﾎﾞﾀﾝを有効
                    cmdCFHistry.Enabled = True
                    
                Else
                
                    '@CFﾛｯﾄ払出履歴ﾎﾞﾀﾝを無効
                    cmdCFHistry.Enabled = False
                    
                End If
            
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfCF_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdTxtUpcf_Click
    '機　能：前頁ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2010/03/25 (Thu) 10:54:04 T.Oide
    '更新日：2010/03/25 (Thu) 10:54:04
    '備　考：
    Private Sub cmdTxtUpcf_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtUpcf.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@前頁処理▲
            Call pubVsfCmdUp(vsfCF, cmdTxtUpcf, cmdTxtDowncf)

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdTxtUpcf_Click"            '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()


        End Try
    End Sub

    '関数名：cmdTxtDowncf_Click
    '機　能：次頁ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2010/03/25 (Thu) 10:54:04 T.Oide
    '更新日：2010/03/25 (Thu) 10:54:04
    '備　考：
    Private Sub cmdTxtDowncf_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtDowncf.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@次頁処理▼
            Call pubVsfCmdDown(vsfCF, cmdTxtUpcf, cmdTxtDowncf)
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdTxtDowncf_Click"          '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTxtUptft_Click
    '機　能：前頁ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2010/03/25 (Thu) 10:54:04 T.Oide
    '更新日：2010/03/25 (Thu) 10:54:04
    '備　考：
    Private Sub cmdTxtUptft_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtUptft.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@前頁処理▲
            Call pubVsfCmdUp(vsfTFT, cmdTxtUptft, cmdTxtDowntft)

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdTxtUptft_Click"      '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()


        End Try
    End Sub

    '関数名：cmdTxtDowntft_Click
    '機　能：次頁ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2010/03/25 (Thu) 10:54:04 T.Oide
    '更新日：2010/03/25 (Thu) 10:54:04
    '備　考：
    Private Sub cmdTxtDowntft_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtDowntft.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@次頁処理▼
            Call pubVsfCmdDown(vsfTFT, cmdTxtUptft, cmdTxtDowntft)
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdTxtDowntft_Click"    '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTxtUpBatch_Click
    '機　能：前頁ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2012/03/16 (Fri) 16:41:47 T.Oide
    '更新日：2012/03/16 (Fri) 16:41:47
    '備　考：
    Private Sub cmdTxtUpBatch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtUpBatch.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@前頁処理▲
            Call pubVsfCmdUp(vsfShelf, cmdTxtUpBatch, cmdTxtDownBatch)

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdTxtUpBatch_Click"    '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()


        End Try
    End Sub

    '関数名：cmdTxtDownBatch_Click
    '機　能：次頁ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2012/03/16 (Fri) 16:41:47 T.Oide
    '更新日：2012/03/16 (Fri) 16:41:47
    '備　考：
    Private Sub cmdTxtDownBatch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtDownBatch.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@次頁処理▼
            Call pubVsfCmdDown(vsfShelf, cmdTxtUpBatch, cmdTxtDownBatch)
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdTxtDownBatch_Click"    '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '******************************************************************************************
    '                                       *関数の記述*
    '******************************************************************************************
    '=========================================Private==========================================
    '関数名：prvfrmxxEN02H0_Init
    '機　能：画面の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2010/03/05 (Fri) 11:03:14 T.Oide
    '更新日：2012/03/16 (Fri) 17:07:53 T.Oide
    '備　考：
    Private Sub prvfrmxxEN02H0_Init()

        Dim lstrFormTitle           As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try

            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN02H0, lstrFormTitle)
            
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@変数初期化
            mstrTaihiCarrierID = vbNullString                           'ﾛｯﾄ
            mstrTaihiLotID = vbNullString                               'ｷｬﾘｱ
            mblnCfRelationJbatchInfGet = False                          'ﾃﾞｰﾀ取得ﾌﾗｸﾞ

            'NSYS コンボボックスの背景色が灰色になるため、白を設定
            cmbMKLot.BackColor = SystemColors.Window
                
            '@各ｺﾝﾄﾛｰﾙを初期化
            lblFlowClass.Text = vbNullString                            '流動区分
            mblncmbMKLotChangeCancel = True
            cmbMKLot.Text = vbNullString                                'MKﾛｯﾄ
            cmbMKLot.Clear
            cmbMKLot.Enabled = False
            mblncmbMKLotChangeCancel = False
            
            '@ﾎﾞﾀﾝ設定
            cmdCFHistry.Enabled = False                                 'CF払出履歴ﾎﾞﾀﾝ
            cmdTxtUpcf.Enabled = False                                  'ｽｸﾛｰﾙ↑cf
            cmdTxtDowncf.Enabled = False                                'ｽｸﾛｰﾙ↓cf
            cmdTxtUptft.Enabled = False                                 'ｽｸﾛｰﾙ↑tft
            cmdTxtDowntft.Enabled = False                               'ｽｸﾛｰﾙ↓tft
        '@↓2012/03/16 (Fri) 17:07:13 T.Oide **************************************************
            cmdTxtUpBatch.Enabled = False                               'ｽｸﾛｰﾙ↑ﾊﾞｯﾁ
            cmdTxtDownBatch.Enabled = False                             'ｽｸﾛｰﾙ↓ﾊﾞｯﾁ
        '@↑2012/03/16 (Fri) 17:07:13 T.Oide **************************************************
            
            
            '@情報取得ｺﾝﾄﾛｰﾙ名(ｷｬﾘｱ/ﾛｯﾄ)の判定
            Select Case mstrInfoGetControlName
            
                '@ｷｬﾘｱID
                Case CMstrInfoGetControlNameCarrier
                    '@ﾛｯﾄIDを初期化
                    mblntxtLotChangeCancel = True
                    txtLot.Text = vbNullString
                    mblntxtLotChangeCancel = False
                    
                '@ﾛｯﾄID
                Case CMstrInfoGetControlNameLot
                    '@ｷｬﾘｱIDを初期化
                    mblntxtCarrierChangeCancel = True
                    txtCarrier.Text = vbNullString
                    mblntxtCarrierChangeCancel = False
                
                '@その他
                Case Else
                    '@親ﾌｫｰﾑ起動(作業終了から)の場合はｷｬﾘｱから情報を取得する
                    '@ﾛｯﾄIDを初期化
                    txtLot.Text = vbNullString
                    
                    '@ﾌｫｰﾑ起動区分が自ﾌｫｰﾑ起動の場合
                    If mblnFormStartKbn = False Then
                        '@ｷｬﾘｱIDを初期化
                        txtCarrier.Text = vbNullString
                    End If
            End Select

            '@ｸﾞﾘｯﾄの初期化
            Call prvvsfSlotMap_init(vsfCF)
            Call prvvsfSlotMap_init(vsfMK)
            Call prvvsfSlotMap_init(vsfTP)
            Call prvvsfSlotMap_init(vsfTFT)
            Call prvvsfSlotMap_init(vsfBatch)
            Call prvvsfSlotMap_init(vsfShelf)
            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False
            
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN02H0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSlotMap_init
    '機　能：ｸﾞﾘｯﾄﾞの初期化
    '引　数：lobjvsfGrid：対象ｸﾞﾘｯﾄﾞ
    '戻り値：
    '作成日：2010/03/05 (Fri) 13:51:55 T.Oide
    '更新日：2010/03/05 (Fri) 13:51:55
    '備　考：
    Private Sub prvvsfSlotMap_init(ByVal lobjvsfGrid As C1FlexGrid)

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With lobjvsfGrid

                .Row = -1
                
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                
                '@ﾀｲﾄﾙのｸﾘｯｸでｿｰﾄはしない
                .AllowSorting = False
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light
                
                '@一覧表ﾀｲﾄﾙの設定
                '.Select(CMlngvsfCFHistoryRowTitle, CMlngvsfCFHistoryColTitle, .Rows.Count - 1, .Cols.Count - 1)
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter                                  '中央表示
                lFixedStyle.ForeColor = Color.Yellow                                                '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)                   '背景色
                With .Font                                                                          'ﾌｫﾝﾄｻｲｽﾞ
                    lFixedStyle.Font = New Font(.FontFamily, CMlngvsfCFHistoryHFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .Rows(CMlngvsfCFHistoryRowTitle).Height = CMlngvsfCFHistoryHHeight                  '高さ
                
                
                '@対象のｸﾞﾘｯﾄﾞにより処理分岐
                Select Case lobjvsfGrid.Name
                
                    '@CFの場合
                    Case vsfCF.Name
                        '@列幅、ﾀｲﾄﾙ設定
                        .Cols(CMlngvsfCFLotID).Width = CMlngvsfCFLotIDW                                             'ﾛｯﾄID(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfCFLotID, CMstrvsfCFLotIDN)                      'ﾛｯﾄID(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfCFLotID).TextAlign = TextAlignEnum.GeneralCenter                              'ﾛｯﾄID(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfCFPD).Width = CMlngvsfCFPDW                                                   '機種(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfCFPD, CMstrvsfCFPDN)                            '機種(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfCFPD).TextAlign = TextAlignEnum.GeneralCenter                                 '機種(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfCFFlowClass).Width = CMlngvsfCFFlowClassW                                     '種別(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfCFFlowClass, CMstrvsfCFFlowClassN)              '種別(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfCFFlowClass).TextAlign = TextAlignEnum.GeneralCenter                          '種別(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfCFThrowINDayTime).Width = CMlngvsfCFThrowINDayTimeW                           '投入日時(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfCFThrowINDayTime, CMstrvsfCFThrowINDayTimeN)    '投入日時(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfCFThrowINDayTime).TextAlign = TextAlignEnum.RightCenter                       '投入日時(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfCFThrowINNum).Width = CMlngvsfCFThrowINNumW                                   '投入数量(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfCFThrowINNum, CMstrvsfCFThrowINNumN)            '投入数量(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfCFThrowINNum).TextAlign = TextAlignEnum.GeneralCenter                         '投入数量(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfCFMKLotIssue).Width = CMlngvsfCFMKLotIssueW                                   'MKﾛｯﾄ払出(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfCFMKLotIssue, CMstrvsfCFMKLotIssueN)            'MKﾛｯﾄ払出(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfCFMKLotIssue).TextAlign = TextAlignEnum.GeneralCenter                         'MKﾛｯﾄ払出(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfCFEmpName).Width = CMlngvsfCFEmpNameW                                         '作業者(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfCFEmpName, CMstrvsfCFEmpNameN)                  '作業者(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfCFEmpName).TextAlign = TextAlignEnum.GeneralCenter                            '作業者D(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfCFStatus).Width = CMlngvsfCFStatusW                                           '現在状態(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfCFStatus, CMstrvsfCFStatusN)                    '現在状態(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfCFStatus).TextAlign = TextAlignEnum.GeneralCenter                             '現在状態(ｱﾗｲﾒﾝﾄ)
                        
                        
                    '@MKの場合
                    Case vsfMK.Name
                        '@列幅、ﾀｲﾄﾙ設定
                        .Cols(CMlngvsfMKLotID).Width = CMlngvsfMKLotIDW                                             'ﾛｯﾄID(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfMKLotID, CMstrvsfMKLotIDN)                      'ﾛｯﾄID(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfMKLotID).TextAlign = TextAlignEnum.GeneralCenter                              'ﾛｯﾄID(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfMKPD).Width = CMlngvsfMKPDW                                                   '機種(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfMKPD, CMstrvsfMKPDN)                            '機種(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfMKPD).TextAlign = TextAlignEnum.GeneralCenter                                 '機種(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfMKFlowClass).Width = CMlngvsfMKFlowClassW                                     '種別(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfMKFlowClass, CMstrvsfMKFlowClassN)              '種別(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfMKFlowClass).TextAlign = TextAlignEnum.GeneralCenter                          '種別(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfMKThrowINDayTime).Width = CMlngvsfMKThrowINDayTimeW                           '投入日時(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfMKThrowINDayTime, CMstrvsfMKThrowINDayTimeN)    '投入日時(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfMKThrowINDayTime).TextAlign = TextAlignEnum.RightCenter                       '投入日時(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfMKThrowINNum).Width = CMlngvsfMKThrowINNumW                                   '投入数量(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfMKThrowINNum, CMstrvsfMKThrowINNumN)            '投入数量(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfMKThrowINNum).TextAlign = TextAlignEnum.GeneralCenter                         '投入数量(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfMKCarrierID).Width = CMlngvsfMKCarrierIDW                                     'キャリアID(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfMKCarrierID, CMstrvsfMKCarrierIDN)              'キャリアID(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfMKCarrierID).TextAlign = TextAlignEnum.GeneralCenter                          'キャリアID(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfMKEmpName).Width = CMlngvsfMKEmpNameW                                         '作業者(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfMKEmpName, CMstrvsfMKEmpNameN)                  '作業者(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfMKEmpName).TextAlign = TextAlignEnum.GeneralCenter                            '作業者(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfMKStatus).Width = CMlngvsfMKStatusW                                           '現在状態(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfMKStatus, CMstrvsfMKStatusN)                    '現在状態(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfMKStatus).TextAlign = TextAlignEnum.GeneralCenter                             '現在状態(ｱﾗｲﾒﾝﾄ)
                        
                        
                    '@TPの場合
                    Case vsfTP.Name
                        '@列幅、ﾀｲﾄﾙ設定
                        .Cols(CMlngvsfTPLotID).Width = CMlngvsfTPLotIDW                                             'ﾛｯﾄID(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfTPLotID, CMstrvsfTPLotIDN)                      'ﾛｯﾄID(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfTPLotID).TextAlign = TextAlignEnum.GeneralCenter                              'ﾛｯﾄID(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfTPPD).Width = CMlngvsfTPPDW                                                   '機種(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfTPPD, CMstrvsfTPPDN)                            '機種(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfTPPD).TextAlign = TextAlignEnum.GeneralCenter                                 '機種(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfTPFlowClass).Width = CMlngvsfTPFlowClassW                                     '種別(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfTPFlowClass, CMstrvsfTPFlowClassN)              '種別(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfTPFlowClass).TextAlign = TextAlignEnum.GeneralCenter                          '種別(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfTPThrowINDayTime).Width = CMlngvsfTPThrowINDayTimeW                           '投入日時(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfTPThrowINDayTime, CMstrvsfTPThrowINDayTimeN)    '投入日時(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfTPThrowINDayTime).TextAlign = TextAlignEnum.RightCenter                       '投入日時(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfTPThrowINNum).Width = CMlngvsfTPThrowINNumW                                   '投入数量(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfTPThrowINNum, CMstrvsfTPThrowINNumN)            '投入数量(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfTPThrowINNum).TextAlign = TextAlignEnum.GeneralCenter                         '投入数量(ｱﾗｲﾒﾝﾄ)」
                        
                        .Cols(CMlngvsfTPMKLR).Width = CMlngvsfTPMKLRW                                               '左/右(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfTPMKLR, CMstrvsfTPMKLRN)                        '左/右(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfTPMKLR).TextAlign = TextAlignEnum.GeneralCenter                               '左/右(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfTPEmpName).Width = CMlngvsfTPEmpNameW                                         '作業者(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfTPEmpName, CMstrvsfTPEmpNameN)                  '作業者(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfTPEmpName).TextAlign = TextAlignEnum.GeneralCenter                            '作業者(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfTPStatus).Width = CMlngvsfTPStatusW                                           '現在状態(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfTPStatus, CMstrvsfTPStatusN)                    '現在状態(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfTPStatus).TextAlign = TextAlignEnum.GeneralCenter                             '現在状態(ｱﾗｲﾒﾝﾄ)
                        
                        
                    '@TFTの場合
                    Case vsfTFT.Name
                        '@列幅、ﾀｲﾄﾙ設定
                        .Cols(CMlngvsfTFTLotID).Width = CMlngvsfTFTLotIDW                                           'ﾛｯﾄID(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfTFTLotID, CMstrvsfTFTLotIDN)                    'ﾛｯﾄID(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfTFTLotID).TextAlign = TextAlignEnum.GeneralCenter                             'ﾛｯﾄID(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfTFTPD).Width = CMlngvsfTFTPDW                                                 '機種(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfTFTPD, CMstrvsfTFTPDN)                          '機種(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfTFTPD).TextAlign = TextAlignEnum.GeneralCenter                                '機種(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfTFTFlowClass).Width = CMlngvsfTFTFlowClassW                                   '種別(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfTFTFlowClass, CMstrvsfTFTFlowClassN)            '種別(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfTFTFlowClass).TextAlign = TextAlignEnum.GeneralCenter                         '種別(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfTFTThrowINDayTime).Width = CMlngvsfTFTThrowINDayTimeW                         '投入日時(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfTFTThrowINDayTime, CMstrvsfTFTThrowINDayTimeN)  '投入日時(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfTFTThrowINDayTime).TextAlign = TextAlignEnum.RightCenter                      '投入日時(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfTFTThrowINNum).Width = CMlngvsfTFTThrowINNumW                                 '投入数量(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfTFTThrowINNum, CMstrvsfTFTThrowINNumN)          '投入数量(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfTFTThrowINNum).TextAlign = TextAlignEnum.GeneralCenter                        '投入数量(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfTFTHari).Width = CMlngvsfTFTHariW                                             '貼合せ(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfTFTHari, CMstrvsfTFTHariN)                      '貼合せ(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfTFTHari).TextAlign = TextAlignEnum.GeneralCenter                              '貼合(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfTFTEmpName).Width = CMlngvsfTFTEmpNameW                                       '作業者(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfTFTEmpName, CMstrvsfTFTEmpNameN)                '作業者(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfTFTEmpName).TextAlign = TextAlignEnum.GeneralCenter                           '作業D(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfTFTStatus).Width = CMlngvsfTFTStatusW                                         '現在状態(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfTFTStatus, CMstrvsfTFTStatusN)                  '現在状態(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfTFTStatus).TextAlign = TextAlignEnum.GeneralCenter                            '現在状態(ｱﾗｲﾒﾝﾄ)
                        
                        
                    '@ﾊﾞｯﾁ情報の場合
                    Case vsfBatch.Name
                        .Cols(CMlngvsfBatchID).Width = CMlngvsfBatchIDW                                             'ﾊﾞｯﾁID(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfBatchID, CMstrvsfBatchIDN)                      'ﾊﾞｯﾁID(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfBatchID).TextAlign = TextAlignEnum.GeneralCenter                              'ﾊﾞｯﾁID(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfBatchEntryTime).Width = CMlngvsfBatchEntryTimeW                               'ﾊﾞｯﾁ編成日時(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfBatchEntryTime, CMstrvsfBatchEntryTimeN)        'ﾊﾞｯﾁ編成日時(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfBatchEntryTime).TextAlign = TextAlignEnum.RightCenter                         'ﾊﾞｯﾁ編成日時(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfBatchNum).Width = CMlngvsfBatchNumW                                           'ﾊﾞｯﾁwf数(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfBatchNum, CMstrvsfBatchNumN)                    'ﾊﾞｯﾁwf数(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfBatchNum).TextAlign = TextAlignEnum.GeneralCenter                             'ﾊﾞｯﾁwf数(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfBatchEnpName).Width = CMlngvsfBatchEnpNameW                                   '作業者(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfBatchEnpName, CMstrvsfBatchEnpNameN)            '作業者(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfBatchEnpName).TextAlign = TextAlignEnum.GeneralCenter                         '作業者(ｱﾗｲﾒﾝﾄ)
                        
                        
                    '@棚情報の場合
                    Case vsfShelf.Name
                        .Cols(CMlngvsfShelfSeq).Width = CMlngvsfShelfSeqW                                           '順(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfShelfSeq, CMstrvsfShelfSeqN)                    '順(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfShelfSeq).TextAlign = TextAlignEnum.GeneralCenter                             '順(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfShelfJigID).Width = CMlngvsfShelfJigIDW                                       '治具ID(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfShelfJigID, CMstrvsfShelfJigIDN)                '治具ID(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfShelfJigID).TextAlign = TextAlignEnum.GeneralCenter                           '治具ID(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfShelfLotID).Width = CMlngvsfShelfLotIDW                                       'ﾛｯﾄID(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfShelfLotID, CMstrvsfShelfLotIDN)                'ﾛｯﾄID(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfShelfLotID).TextAlign = TextAlignEnum.GeneralCenter                           'ﾛｯﾄID(ｱﾗｲﾒﾝﾄ)
                        
                        .Cols(CMlngvsfShelfWFID).Width = CMlngvsfShelfWFIDW                                         'WF_ID(幅)
                        .SetData(CMlngvsfCFHistoryRowTitle, CMlngvsfShelfWFID, CMstrvsfShelfWFIDN)                  'WF_ID(ﾀｲﾄﾙ)
                        .Cols(CMlngvsfShelfWFID).TextAlign = TextAlignEnum.GeneralCenter                            'WF_ID(ｱﾗｲﾒﾝﾄ)
                        
                End Select
                
                '@行数の初期設定(行:1)
                .Redraw = False
                .Rows.Count = CMlngOne
                .Redraw = True
                
                '@無効化
                .Enabled = False
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMap_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnlotdetail_Get
    '機　能：ﾛｯﾄ詳細情報取得処理
    '引　数：lstrClassDivision：処理区分(OK：ｷｬﾘｱ指定/0L：ﾛｯﾄ指定)
    '戻り値：True：成功/False：失敗
    '作成日：2010/03/09 (Tue) 15:32:16 T.Oide
    '更新日：2010/03/09 (Tue) 15:32:16
    '備　考：
    Private Function prvblnlotdetail_Get(ByVal lstrClassDivision As String, _
                                         ByRef ltypLotDetailInfo As LotDetailInfo, _
                                         ByVal lstrKey As String) As Boolean

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrCarrierID           As String               'ｷｬﾘｱID退避
        Dim lstrLotID               As String               'ﾛｯﾄID退避
        
        Try

            '@初期化
            prvblnlotdetail_Get = False
            
            '@引数：ClassDivisionによる処理判別
            Select Case lstrClassDivision
            
                '@ｷｬﾘｱIDで取得
                Case CPstrCD0K
                    '@情報取得準備の為,内部変数へ退避
                    lstrCarrierID = lstrKey
                    lstrLotID = vbNullString
                    
                '@ﾛｯﾄID出取得
                Case CPstrCD0L
                    '@情報取得準備の為,内部変数へ退避
                    lstrCarrierID = vbNullString
                    lstrLotID = lstrKey
                    
            End Select
            
            '@ﾛｯﾄ情報詳細取得処理
            lblnAns = pubblnLotDetail_Sel(CMstrlot_detail__Ver, _
                                          pstrSBID, _
                                          lstrClassDivision, _
                                          lstrLotID, _
                                          lstrCarrierID, _
                                          ltypLotDetailInfo)
            '@結果判定
            If lblnAns = True Then
                
                '@ｷｬﾘｱID、ﾛｯﾄIDの退避
                mstrTaihiCarrierID = txtCarrier.Text
                mstrTaihiLotID = txtLot.Text
            
                '@成功を返す
                prvblnlotdetail_Get = True

            End If
            
            Exit Function
            

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnlotdetail_Get"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvcontrolSetFocus_Set
    '機　能：ｾｯﾄﾌｫｰｶｽ処理
    '引　数：lstrControlName：ｺﾝﾄﾛｰﾙ名(ｷｬﾘｱ/ﾛｯﾄ/Null)
    '戻り値：なし
    '作成日：2010/03/09 (Tue) 15:37:32 T.Oide
    '更新日：2010/03/09 (Tue) 15:37:32
    '備　考：
    Private Sub prvcontrolSetFocus_Set(ByVal lstrControlName As String)

        Try

            '@引数による処理判別
            Select Case lstrControlName
            
                '@ｷｬﾘｱID,ﾛｯﾄID 処理成功時
                Case txtCarrier.Name, txtLot.Name
                           
                    '@閉じるﾎﾞﾀﾝ
                    Call pubSetFocus(cmdClose)
                    
                '@ｷｬﾘｱID,ﾛｯﾄID 情報取得済時
                Case Else
                
                    Select Case ActiveControl.Name
                        
                        Case txtCarrier.Name
                        '@ｷｬﾘｱIDの場合
                            '@ﾛｯﾄID欄へﾌｫｰｶｽ
                            Call pubSetFocus(txtCarrier)
                            
                        Case txtLot.Name
                        '@ﾛｯﾄIDの場合
                            Call pubSetFocus(txtLot)

                    End Select
            End Select
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcontrolSetFocus_Set"     '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvNextProcJudge
    '機　能：ﾛｯﾄ情報詳細の取得結果で次の動作を決める
    '引　数：ltypLotDetailInf：
    '戻り値：
    '作成日：2010/03/10 (Wed) 09:29:32 T.Oide
    '更新日：2010/04/06 (Tue) 17:02:22 T.Oide
    '備　考：
    Private Sub prvNextProcJudge(ByRef ltypLotDetailInfo As LotDetailInfo)

        Dim lblnAns                 As Boolean              'ﾃﾞｰﾀ取得結果確認用
        Dim lstrLotID               As String               'ﾛｯﾄﾃﾞｰﾀ格納用
        Dim ltypRelationMKLotList   As typRelationMKLotList '紐付きMKﾛｯﾄﾘｽﾄ取得結果格納

        Try
            
            
            '@ﾛｯﾄIDは、TFTのﾛｯﾄで、Rﾛｯﾄ､Mﾛｯﾄ､Aﾛｯﾄのいずれかか
            If ltypLotDetailInfo.strCfFlag = CMstrCF_FLAG_0 And _
               (Mid$(ltypLotDetailInfo.strLotID, 8, 1) = CMstrALot Or _
                Mid$(ltypLotDetailInfo.strLotID, 8, 1) = CMstrRLot Or _
                Mid$(ltypLotDetailInfo.strLotID, 8, 1) = CMstrMLot) Then
                
                '@ﾛｯﾄIDは親ﾛｯﾄIDにする
                lstrLotID = ltypLotDetailInfo.strDivideLotID
                
            Else
                
                'ﾛｯﾄIDはそのまま
                lstrLotID = ltypLotDetailInfo.strLotID
                
            End If
            
            'VAﾌﾗｸﾞがNULLの場合は0に設定
            If ltypLotDetailInfo.strVaFlag = vbNullString Then
                ltypLotDetailInfo.strVaFlag = 0
            End If
            
            
            '@ﾛｯﾄの属性によって処理を分岐
            Select Case CLng(ltypLotDetailInfo.strCfFlag)
                
                '@TFTの場合
                Case CMstrCF_FLAG_0
                
                    'MKﾛｯﾄﾘｽﾄでMKﾛｯﾄのﾘｽﾄを取得する(J_BATCH)
                    lblnAns = pubblnRelationMKLotList_Sel(CMstrlot_relationmklotlistVer, _
                                                          lstrLotID, _
                                                          CMstrCF_FLAG_0, _
                                                          ltypRelationMKLotList)
                    
                    '@結果確認
                    If lblnAns = True Then
                    
                        '@1つ以上のMKﾛｯﾄがあるか
                        If ltypRelationMKLotList.lngCnt >= 1 Then
                        
                            '@MKﾛｯﾄのｺﾝﾎﾞに設定
                            Call prvcmbMKLotList_Set(ltypRelationMKLotList)
                            
                                
                        Else
                        
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0107, lstrLotID)
                            '@<TRM107W>$$ロット[%1]に紐付く同一バッチの対向基板情報はありません。
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit Sub
                            
                        End If
                    Else
                    
                        '@想定外のｴﾗｰ
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000C, lstrLotID)
                        '@システムエラーです。エラーメッセージは取得できませんでした。$システム担当者に連絡して下さい。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        Exit Sub
                        
                    End If
                
                
                '@CF,MKの場合
                Case CMstrCF_FLAG_1
                
                    Select Case CLng(ltypLotDetailInfo.strVaFlag)
                        
                        'CFの場合
                        Case CMstrVA_FLAG_0
                        
                            'MKﾛｯﾄのﾘｽﾄを取得する
                            lblnAns = pubblnRelationMKLotList_Sel(CMstrlot_relationmklotlistVer, _
                                                                  lstrLotID, _
                                                                  CMstrCF_FLAG_1, _
                                                                  ltypRelationMKLotList)
                            
                            '@結果確認
                            If lblnAns = True Then
                            
                                '@1つ以上のMKﾛｯﾄがあるか
                                If ltypRelationMKLotList.lngCnt >= 1 Then
                                
                                    '@MKﾛｯﾄのｺﾝﾎﾞに設定
                                    Call prvcmbMKLotList_Set(ltypRelationMKLotList)
                                        
                                Else
                                    
                                    '@表示ﾒｯｾｰｼﾞ変換
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0108, lstrLotID)
                                    '@<TRM108W>$$ロット[%1]に紐付くMKロットはありません
                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                    
                                    Exit Sub
                                    
                                    
                                End If
                                
                            Else
                            
                                '@想定外のｴﾗｰ
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000C, lstrLotID)
                                '@システムエラーです。エラーメッセージは取得できませんでした。$システム担当者に連絡して下さい。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        Exit Sub
                            
                            End If
                        
                        
                        'MKﾛｯﾄの場合
                        Case CMstrVA_FLAG_1
                            
                            '@cmbMKLotの値を設定、無効化
                            cmbMKLot.Enabled = False
                            mblncmbMKLotChangeCancel = True     'ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞｾｯﾄ
                            cmbMKLot.Text = txtLot.Text
                            mblncmbMKLotChangeCancel = False
                            
                            '@無機CF紐付ﾊﾞｯﾁ情報取得&表示
                            Call prvMKLotRelationInfoGet(txtLot.Text, CMstrLotClassMK)
                            

                    End Select

                '@TPﾛｯﾄの場合
                Case CMstrCF_FLAG_2
                           
                    '@無機CF紐付情報取得&表示
                    Call prvMKLotRelationInfoGet(txtLot.Text, CMstrLotClassTP)
                    
                    '@取得した情報でMKﾛｯﾄを表示しておく
                    cmbMKLot.Enabled = False
                    
        '@↓2010/04/06 (Tue) 17:02:38 T.Oide **************************************************
                    '@行数が1より大きいか？
                    If vsfMK.Rows.Count > 1 Then
                    
                        mblncmbMKLotChangeCancel = True     'ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞｾｯﾄ
                        cmbMKLot.Text = vsfMK.GetData(cmbMKLot.Rows, CMlngvsfMKLotID)
                        mblncmbMKLotChangeCancel = False
                    
                    End If
        '@↑2010/04/06 (Tue) 17:02:38 T.Oide **************************************************
                    
            End Select
            
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvNextProcJudge"           '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvcmbMKLotList_Set
    '機　能：取得したMKﾛｯﾄのﾘｽﾄをcmbMKLotのﾘｽﾄにｾｯﾄする
    '引　数：ltypRelationMKLotList：
    '戻り値：
    '作成日：2010/03/10 (Wed) 16:23:51 T.Oide
    '更新日：2010/03/10 (Wed) 16:23:51
    '備　考：メモ：MKﾛｯﾄのﾘｽﾄが0件の場合は、この前の処理でﾒｯｾｰｼﾞを表示して終了する
    Private Sub prvcmbMKLotList_Set(ByRef ltypRelationMKLotList As typRelationMKLotList)
        
        Dim lngCnt          As Integer
        
        Try
            
            lngCnt = 1
            
            '@MKﾛｯﾄのﾘｽﾄを作成
            cmbMKLot.Clear
            Do While ltypRelationMKLotList.lngCnt >= lngCnt
                
                cmbMKLot.AddItem (ltypRelationMKLotList.typRelationMKLot(lngCnt - 1).strMKLot)
                
                lngCnt = lngCnt + 1
            Loop
            
            '@複数ﾘｽﾄがあるか
            If cmbMKLot.ListCount > 1 Then
                
                '@cmdMKLotを有効にして終了
                cmbMKLot.Enabled = True
                
            Else
                
                '@1件の場合は、cmdMKLotを無効にして、その1件を表示
                '(cmbMKLot_Changeｲﾍﾞﾝﾄにより情報を取得する)
                cmbMKLot.ListIndex = 0
                cmbMKLot.Enabled = False
                
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmbMKLotList_Set"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub


    '関数名：prvMKLotRelationInfoGet
    '機　能：無機対向基板紐付け/蒸着ﾊﾞｯﾁ情報取得&表示
    '        MKﾛｯﾄかTPﾛｯﾄだけがここに呼ばれる(CFとTFTの場合は、一旦MKﾛｯﾄを特定してから呼ばれる)
    '引　数：lstrLotID：検索対象のﾛｯﾄID
    '　　　：lstrLotClass：ﾛｯﾄ区分("MK" or "TP")
    '戻り値：
    '作成日：2010/03/16 (Tue) 13:08:23 T.Oide
    '更新日：2012/03/16 (Fri) 16:43:30 T.Oide
    '備　考：
    Private Sub prvMKLotRelationInfoGet(ByVal lstrLotID As String, _
                                        ByVal lstrLotClass As String)

        Dim lblnAns                     As Boolean
        Dim ltypeMKRelationBatchInfo    As typeMKRelationBatchInfo
        
        Try
            
            
            '@無機対向基板紐付け/蒸着ﾊﾞｯﾁ情報取得
            lblnAns = pubMKLotRelationInfo_Sel(lstrLotID, _
                                               lstrLotClass, _
                                               CMstrlot_cfrelationjbatchinfVer, _
                                               ltypeMKRelationBatchInfo)
            '@取得結果確認
            If lblnAns = True Then
            
                '@無機対向基板紐付け/蒸着ﾊﾞｯﾁ情報表示
                Call prvMKLotRelationInfo_Disp(ltypeMKRelationBatchInfo)
                
               '@ｽｸﾛｰﾙﾎﾞﾀﾝ設定
                Call pubVsfDisp(vsfCF, cmdTxtUpcf, cmdTxtDowncf)
                Call pubVsfDisp(vsfTFT, cmdTxtUptft, cmdTxtDowntft)
        '@↓2012/03/16 (Fri) 16:42:47 T.Oide **************************************************
                Call pubVsfDisp(vsfShelf, cmdTxtUpBatch, cmdTxtDownBatch)
        '@↑2012/03/16 (Fri) 16:42:47 T.Oide **************************************************

                '@ﾃﾞｰﾀの取得に成功した場合取得した各ﾛｯﾄの現在状態を取得し表示する
                Call prvEachNowST_Sel()
                
                '@ﾃﾞｰﾀ取得ﾌﾗｸﾞｾｯﾄ
                mblnCfRelationJbatchInfGet = True
                
            Else
            
                '@取得できない場合ﾌｫｰｶｽを戻す
                If txtCarrier.Text <> vbNullString Then
                    
                    '@ｷｬﾘｱにﾌｫｰｶｽをｾｯﾄする
                    pubSetFocus(txtCarrier)
                Else
                
                    '@ﾛｯﾄにﾌｫｰｶｽをｾｯﾄする
                    pubSetFocus(txtLot)
                End If
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvMKLotRelationInfoGet"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvMKLotRelationInfo_Disp
    '機　能：無機対向基板紐付け/蒸着ﾊﾞｯﾁ情報表示
    '引　数：ltypeMKLotRelationInf：
    '戻り値：
    '作成日：2010/03/10 (Wed) 17:07:36 T.Oide
    '更新日：2010/03/10 (Wed) 17:07:36
    '備　考：
    Private Sub prvMKLotRelationInfo_Disp(ByRef ltypeMKRelationBatchInfo As typeMKRelationBatchInfo)

        Dim llngCnt         As Integer

        Try
                
            With ltypeMKRelationBatchInfo

                vsfCF.Redraw = False
                vsfMK.Redraw = False
                vsfTP.Redraw = False
                vsfTFT.Redraw = False
                vsfBatch.Redraw = False
                vsfShelf.Redraw = False
            
                '@CFﾛｯﾄ情報の表示
                llngCnt = 1
                vsfCF.Rows.Count = .lngCFLotListcnt + 1
                Do While .lngCFLotListcnt >= llngCnt
                    vsfCF.SetData(llngCnt, CMlngvsfCFLotID, .typCFLotList(llngCnt - 1).strLotID)                   'ﾛｯﾄID
                    vsfCF.SetData(llngCnt, CMlngvsfCFPD, .typCFLotList(llngCnt - 1).strPdId)                       '機種
                    vsfCF.SetData(llngCnt, CMlngvsfCFFlowClass, .typCFLotList(llngCnt - 1).strFlowClass)           '種別
                    If IsDate(.typCFLotList(llngCnt - 1).strTrowinTime) Then
                        vsfCF.SetData(llngCnt, CMlngvsfCFThrowINDayTime, Format(CDate(.typCFLotList(llngCnt - 1).strTrowinTime), CPstrDateTimeYMDHMS))  '投入日時
                    Else
                        vsfCF.SetData(llngCnt, CMlngvsfCFThrowINDayTime, .typCFLotList(llngCnt - 1).strTrowinTime) '投入日時
                    End If
                    vsfCF.SetData(llngCnt, CMlngvsfCFThrowINNum, .typCFLotList(llngCnt - 1).strTrowinNum)          '投入数量
                    vsfCF.SetData(llngCnt, CMlngvsfCFMKLotIssue, .typCFLotList(llngCnt - 1).strMKIsuueNum)         'MKﾛｯﾄ払出
                    vsfCF.SetData(llngCnt, CMlngvsfCFEmpName, .typCFLotList(llngCnt - 1).strEmpName)               '作業者
                    'vsfCF.Cell(flexcpText, llngCnt, CMlngvsfCFStatus) = .typCFLotList(llngCnt).strStatus                 '現在状態
                    
                    llngCnt = llngCnt + 1
                Loop
                
                vsfCF.Row = 0

                '@CF情報を表示したときはｸﾞﾘｯﾄﾞを有効にする
                If .lngCFLotListcnt > 0 Then
                    'NSYS 有効にするとCFロット情報グリッドだけ先に表示されるので、遅延実行する
                    If Me.Handle <> IntPtr.Zero Then
                        Me.BeginInvoke(Sub() vsfCF.Enabled = True)
                    Else
                        'NSYS コンストラクタ中(ハンドル未生成)は直接設定
                        vsfCF.Enabled = True
                    End If
                End If
                
                
                '@MKﾛｯﾄ情報の表示
                llngCnt = 1
                vsfMK.Rows.Count = 2
                vsfMK.SetData(llngCnt, CMlngvsfMKLotID, .typMKLot.strLotID)                                        'ﾛｯﾄID
                vsfMK.SetData(llngCnt, CMlngvsfMKPD, .typMKLot.strPdId)                                            '機種
                vsfMK.SetData(llngCnt, CMlngvsfMKFlowClass, .typMKLot.strFlowClass)                                '種別
                If IsDate(.typMKLot.strTrowinTime) Then
                    vsfMK.SetData(llngCnt, CMlngvsfMKThrowINDayTime, Format(CDate(.typMKLot.strTrowinTime), CPstrDateTimeYMDHMS))   '投入日時
                Else
                    vsfMK.SetData(llngCnt, CMlngvsfMKThrowINDayTime, .typMKLot.strTrowinTime)                      '投入日時
                End If
                vsfMK.SetData(llngCnt, CMlngvsfMKThrowINNum, .typMKLot.strTrowinNum)                               '投入数量
                vsfMK.SetData(llngCnt, CMlngvsfMKCarrierID, .typMKLot.strCarrierId)                                'キャリアID
                vsfMK.SetData(llngCnt, CMlngvsfMKEmpName, .typMKLot.strEmpName)                                    '作業者
                'vsfMK.Cell(flexcpText, llngCnt, CMlngvsfMKStatus) = .typMKLot.strStatus                                  '現在状態
                
                
                '@TPﾛｯﾄ情報の表示
                llngCnt = 1
                vsfTP.Rows.Count = .lngTpLotListCnt + 1
                Do While .lngTpLotListCnt >= llngCnt
                    
                    vsfTP.SetData(llngCnt, CMlngvsfTPLotID, .typTPLotList(llngCnt - 1).strLotID)                   'ﾛｯﾄID
                    vsfTP.SetData(llngCnt, CMlngvsfTPPD, .typTPLotList(llngCnt - 1).strPdId)                       '機種
                    vsfTP.SetData(llngCnt, CMlngvsfTPFlowClass, .typTPLotList(llngCnt - 1).strFlowClass)           '種別
                    If IsDate(.typTPLotList(llngCnt - 1).strTrowinTime) Then
                        vsfTP.SetData(llngCnt, CMlngvsfTPThrowINDayTime, Format(CDate(.typTPLotList(llngCnt - 1).strTrowinTime), CPstrDateTimeYMDHMS))  '投入日時
                    Else
                        vsfTP.SetData(llngCnt, CMlngvsfTPThrowINDayTime, .typTPLotList(llngCnt - 1).strTrowinTime) '投入日時
                    End If
                    vsfTP.SetData(llngCnt, CMlngvsfTPThrowINNum, .typTPLotList(llngCnt - 1).strTrowinNum)          '投入数量
                    
                    '@左/右
                    Select Case .typTPLotList(llngCnt - 1).strLR
                        
                        '@右の場合
                        Case CPstrTpalJRight
                            vsfTP.SetData(llngCnt, CMlngvsfTPMKLR, CPstrTpalJRightName)
                        
                        '@左の場合
                        Case CPstrTpalJLeft
                            vsfTP.SetData(llngCnt, CMlngvsfTPMKLR, CPstrTpalJLeftName)
                        
                        '@それ以外(空白)
                        Case Else
                            vsfTP.SetData(llngCnt, CMlngvsfTPMKLR, vbNullString)
                        
                    End Select
                    
                    vsfTP.SetData(llngCnt, CMlngvsfTPEmpName, .typTPLotList(llngCnt - 1).strEmpName)               '作業者
                    'vsfTP.Cell(flexcpText, llngCnt, CMlngvsfTPStatus) = .typTPLotList(llngCnt).strStatus                 '現在状態
                    
                    llngCnt = llngCnt + 1
                Loop
                
                
                '@TFTﾛｯﾄ情報の表示
                llngCnt = 1
                vsfTFT.Rows.Count = .lngTFTLotListCnt + 1
                Do While .lngTFTLotListCnt >= llngCnt

                    vsfTFT.SetData(llngCnt, CMlngvsfTFTLotID, .typTFTLotList(llngCnt - 1).strLotID)                'ﾛｯﾄID
                    vsfTFT.SetData(llngCnt, CMlngvsfTFTPD, .typTFTLotList(llngCnt - 1).strPdId)                    '機種
                    vsfTFT.SetData(llngCnt, CMlngvsfTFTFlowClass, .typTFTLotList(llngCnt - 1).strFlowClass)        '種別
                    If IsDate(.typTFTLotList(llngCnt - 1).strTrowinTime) Then
                        vsfTFT.SetData(llngCnt, CMlngvsfTFTThrowINDayTime, Format(CDate(.typTFTLotList(llngCnt - 1).strTrowinTime), CPstrDateTimeYMDHMS))   '投入日時
                    Else
                        vsfTFT.SetData(llngCnt, CMlngvsfTFTThrowINDayTime, .typTFTLotList(llngCnt - 1).strTrowinTime)  '投入日時
                    End If
                    vsfTFT.SetData(llngCnt, CMlngvsfTFTThrowINNum, .typTFTLotList(llngCnt - 1).strTrowinNum)       '投入数量
                    
                    '貼合せ
                    Select Case .typTFTLotList(llngCnt - 1).strTpalClass
                        
                        '@ﾊﾞｯﾁ+左、ﾊﾞｯﾁ+右の場合
                        Case CPstrTpalJBatchLeft, CPstrTpalJBatchRight
                            vsfTFT.SetData(llngCnt, CMlngvsfTFTHari, CMstrTpalBatchLRName)
                        
                        '@左、右の場合
                        Case CPstrTpalJLeft, CPstrTpalJRight
                            vsfTFT.SetData(llngCnt, CMlngvsfTFTHari, CMstrTpalLRName)
                        
                        '@ﾊﾞｯﾁの場合
                        Case CPstrTpalJBatch
                            vsfTFT.SetData(llngCnt, CMlngvsfTFTHari, CMstrTpalBatchName)
                        
                        '@それ以外(空白)の場合
                        Case Else
                            vsfTFT.SetData(llngCnt, CMlngvsfTFTHari, vbNullString)
                            
                    End Select
                    
                    vsfTFT.SetData(llngCnt, CMlngvsfTFTEmpName, .typTFTLotList(llngCnt - 1).strEmpName)            '作業者
                    'vsfTFT.Cell(flexcpText, llngCnt, CMlngvsfTFTStatus) = .typTFTLotList(llngCnt).strStatus              '現在状態
                    
                    llngCnt = llngCnt + 1
                Loop
                
                '@ﾊﾞｯﾁ情報の表示
                If .strBatchId <> vbNullString Then
                    llngCnt = 1
                    vsfBatch.Rows.Count = 2
                    vsfBatch.SetData(llngCnt, CMlngvsfBatchID, .strBatchId)                                        'ﾊﾞｯﾁID
                    If IsDate(.strBatchTime) Then
                        vsfBatch.SetData(llngCnt, CMlngvsfBatchEntryTime, Format(CDate(.strBatchTime), CPstrDateTimeYMDHMS))    'ﾊﾞｯﾁ編成日時
                    Else
                        vsfBatch.SetData(llngCnt, CMlngvsfBatchEntryTime, .strBatchTime)                           'ﾊﾞｯﾁ編成日時
                    End If
                    vsfBatch.SetData(llngCnt, CMlngvsfBatchNum, .strBatchNum)                                      'ﾊﾞｯﾁwf数
                    vsfBatch.SetData(llngCnt, CMlngvsfBatchEnpName, .strEmpName)                                   '作業者
                End If
                
                '@ﾊﾞｯﾁ棚情報の表示
                llngCnt = 1
                vsfShelf.Rows.Count = .lngShelfInfoListcnt + 1
                Do While .lngShelfInfoListcnt >= llngCnt
                
                    vsfShelf.SetData(llngCnt, CMlngvsfShelfSeq, .typeShelfInfoList(llngCnt - 1).strSeq)            '順
                    vsfShelf.SetData(llngCnt, CMlngvsfShelfJigID, .typeShelfInfoList(llngCnt - 1).strjigId)        '治具ID
                    vsfShelf.SetData(llngCnt, CMlngvsfShelfLotID, .typeShelfInfoList(llngCnt - 1).strLotID)        'ﾛｯﾄID
                    vsfShelf.SetData(llngCnt, CMlngvsfShelfWFID, .typeShelfInfoList(llngCnt - 1).strWfId)          'WF_ID
                    
                    llngCnt = llngCnt + 1
                Loop
                
                vsfCF.Redraw = True
                vsfMK.Redraw = True
                vsfTP.Redraw = True
                vsfTFT.Redraw = True
                vsfBatch.Redraw = True
                vsfShelf.Redraw = True

            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvMKLotRelationInfo_Disp"  '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：prvEachNowST_Sel
    '機　能：
    '引　数：なし
    '戻り値：
    '作成日：2010/03/23 (Tue) 16:50:23 T.Oide
    '更新日：2010/03/23 (Tue) 16:50:23
    '備　考：
    Private Sub prvEachNowST_Sel()

        Dim llngCnt As Integer

        Try

            '@ﾃﾞｰﾀを取得でき且つ、現在状態がNULLのﾛｯﾄのみ取得する

            '@CFﾛｯﾄの現在状態取得
            llngCnt = 1
            Do While vsfCF.Rows.Count > llngCnt
                If vsfCF.GetData(llngCnt, CMlngvsfCFLotID) <> vbNullString And _
                   vsfCF.GetData(llngCnt, CMlngvsfCFStatus) = vbNullString Then
                    
                    vsfCF.SetData(llngCnt, CMlngvsfCFStatus, _
                            prvstrNoeST_Sel(vsfCF.GetData(llngCnt, CMlngvsfCFLotID)))
                    
                End If
                
                llngCnt = llngCnt + 1
            Loop
            
            '@MKﾛｯﾄの現在状態取得
            llngCnt = 1
            Do While vsfMK.Rows.Count > llngCnt
                If vsfMK.GetData(llngCnt, CMlngvsfMKLotID) <> vbNullString And _
                   vsfMK.GetData(llngCnt, CMlngvsfMKStatus) = vbNullString Then
                    
                    vsfMK.SetData(llngCnt, CMlngvsfMKStatus, _
                            prvstrNoeST_Sel(vsfMK.GetData(llngCnt, CMlngvsfMKLotID)))
                    
                End If
                
                llngCnt = llngCnt + 1
            Loop
            
            '@TPﾛｯﾄの現在状態取得
            llngCnt = 1
            Do While vsfTP.Rows.Count > llngCnt
                If vsfTP.GetData(llngCnt, CMlngvsfTPLotID) <> vbNullString And _
                   vsfTP.GetData(llngCnt, CMlngvsfTPStatus) = vbNullString Then
                    
                    vsfTP.SetData(llngCnt, CMlngvsfTPStatus, _
                            prvstrNoeST_Sel(vsfTP.GetData(llngCnt, CMlngvsfTPLotID)))
                    
                End If
                
                llngCnt = llngCnt + 1
            Loop
            
            '@TFTﾛｯﾄの現在状態取得
            llngCnt = 1
            Do While vsfTFT.Rows.Count > llngCnt
                If vsfTFT.GetData(llngCnt, CMlngvsfTFTLotID) <> vbNullString And _
                   vsfTFT.GetData(llngCnt, CMlngvsfTFTStatus) = vbNullString Then
                    
                    vsfTFT.SetData(llngCnt, CMlngvsfTFTStatus, _
                            prvstrNoeST_Sel(vsfTFT.GetData(llngCnt, CMlngvsfTFTLotID)))
                    
                End If
                
                llngCnt = llngCnt + 1
            Loop


            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvEachNowST_Sel"           '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub


    '関数名：prvstrNoeST_Sel
    '機　能：現在状態を取得する
    '引　数：lstrLot_ID：検索ﾛｯﾄ
    '戻り値：
    '作成日：2010/03/23 (Tue) 17:00:55 T.Oide
    '更新日：2010/03/23 (Tue) 17:00:55
    '備　考：
    Private Function prvstrNoeST_Sel(ByRef lstrLot_ID As String) As String

        Dim ltypLotDetailInfo   As LotDetailInfo
        Dim lblnAns             As Boolean

            '@初期値設定
            prvstrNoeST_Sel = ""

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, "prvNowST_Sel")
            
            '@ﾛｯﾄ詳細情報の取得
            lblnAns = prvblnlotdetail_Get(CPstrCD0L, ltypLotDetailInfo, lstrLot_ID)
            
            '@結果判定
            If lblnAns = True Then
                
                prvstrNoeST_Sel = ltypLotDetailInfo.strLastEventName
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, "prvNowST_Sel")
                    
            Else
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, "prvNowST_Sel")
                
            End If
            
            Exit Function
            
    Error_Handler:
        
        '@ｴﾗｰ情報設定
        With ptypOnErrorInfo
            .strMenuKey = CMstrLocalMenuKey             '機能ID
            .strProcName = "prvNowST_Sel"               '処理名
            .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
        End With

        '@共通ｴﾗｰ処理
        Call pubOnError_Proc()
        
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraFrame1.Paint, fraFrame2.Paint, fraFrame3.Paint, fraFrame4.Paint, fraFrame5.Paint, fraFrame6.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfBatch.BeforeDoubleClick, vsfCF.BeforeDoubleClick, vsfMK.BeforeDoubleClick, vsfShelf.BeforeDoubleClick, vsfTFT.BeforeDoubleClick, vsfTP.BeforeDoubleClick

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
