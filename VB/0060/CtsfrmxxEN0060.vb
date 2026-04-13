'ﾌｧｲﾙ名：xxEN0060.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：作業終了　ﾒｲﾝﾌｫｰﾑ
'作成日：2004/02/27 (Fri) 14:07:45 T.Oide
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2018, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Imports TFLib
Public Class frmxxEN0060
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN0060    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN0060
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN0060
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN0060)
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
    Private Const CMstrLocalVersion                 As String = "24.02"

    '@ﾛｰｶﾙ機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN0060     'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrlot_curstateVer              As String = "04.00"            'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_actlist_Ver              As String = "01.00"            'ｱｸｼｮﾝ予約ﾘｽﾄ取得
    Private Const CMstrlot_nextsteplistVer          As String = "03.01"            'ﾛｯﾄ次工程取得
    Private Const CMstrlot_nextSendVer              As String = "03.03"            'ﾛｯﾄ次工程送出
    Private Const CPstrlot_wplist__Ver              As String = "02.05"            'ﾛｯﾄ装置情報取得
    Private Const CPstrlot_cfend___Ver              As String = "02.00"            'CFﾛｯﾄ終了
    Private Const CMstrlot_wrkendVer                As String = "04.05"            'ﾛｯﾄ作業終了
    Private Const CMstrlot_chkwaistVer              As String = "01.00"            'WAITﾃﾞｰﾀ状態確認
    Private Const CMstrctl_updwaitinglotVer         As String = "01.01"            '処理待ちﾛｯﾄ更新
    Private Const CMstrlot_detail__Ver              As String = "03.00"            'ﾛｯﾄ詳細情報
    Private Const CMstrspc_judge___Ver              As String = "03.01"            'SPC規格値判定
    Private Const CMstreq__state___Ver              As String = "03.00"            '装置状態取得
    Private Const CMstreq_apc_start___Ver           As String = "01.00"            'APC計算開始
    Private Const CMstrlot_chkodfcovsrVer           As String = "01.01"            '無機ODF貼り合せ状態確認
    Private Const CMstrlot_odfholdlastupdateVer     As String = "01.00"            '無機ODF貼り合せ状態確認
    Private Const CMstrlot_hold____Ver              As String = "02.01"            'ﾛｯﾄ保留設定
    Private Const CMstrlot_waferlistVer             As String = "02.05"            'ﾛｯﾄWF情報取得(新)
    Private Const CMstrftp_regcollectVer            As String = "01.00"            'ODFﾃﾞｰﾀ登録確認
    Private Const CMstreqft_syncregistVer           As String = "02.00"            'ｵﾌﾗｲﾝFTPﾃﾞｰﾀ同期登録
    Private Const CMstrlot_chkchangeorderVer        As String = "01.00"            '量産ｵｰﾀﾞｰ振替ﾁｪｯｸ
    Private Const CMstrlot_chkeasycombineVer        As String = "01.00"            '簡易統合可否ﾁｪｯｸ
    Private Const CMstrlot_chkexclusionprocessVer   As String = "02.00"            '抜取・全数検査ﾁｪｯｸ
	Private Const CMstrlot_chkdoublejpdVer			As String = "01.00"	           '蒸着2回対応対象機種ﾁｪｯｸ

    Private Const CMstrAri                          As String = "あり"             '表示文字列(あり)
    Private Const CMstrNasi                         As String = "なし"             '表示文字列(なし)

    Private Const CMlngCarrierMaxLength             As Integer = 6                 'ｷｬﾘｱIDの最大桁数
    Private Const CMlngMemoDefault                  As Integer = 0                 '作業ﾒﾓの初期値(=0)
    Private Const CMlngCmbRowHeight                 As Integer = 43                'ｺﾝﾎﾞﾘｽﾄ行の高さ

    Private Const CMlngNextStepListIndex            As Integer = 1                 'LIST表示用ｲﾝﾃﾞｯｸｽ

    '@ｸﾞﾘｯﾄﾞの初期値定数宣言
    Private Const CMstrGridFontName                 As String = "ＭＳ ゴシック"    'ｸﾞﾘｯﾄﾞのﾌｫﾝﾄ名
    Private Const CMlngGridFontSize                 As Integer = 11                'ｸﾞﾘｯﾄﾞのﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngGridFixedCols                As Integer = 0                 'ｸﾞﾘｯﾄﾞのFixedCol
    Private Const CMlngGridFixedRows                As Integer = 1                 'ｸﾞﾘｯﾄﾞのFixedRow
    Private Const CMlngGridTitleHeight              As Integer = 20                'ﾍｯﾀﾞｰの高さ
    Private Const CMlngGridRowHeight                As Integer = 18                '1明細の高さ
    Private Const CMlngGridPageRows                 As Integer = 7                 '1ﾍﾟｰｼﾞのｾﾙの行数
    Private Const CMlngGrid3DBlank                  As Integer = 4                 'ｸﾞﾘｯﾄﾞの3D表示の余白
    Private Const CMlngScrollButtonSize             As Integer = 49                'ｽｸﾛｰﾙﾎﾞﾀﾝのｻｲｽﾞ

    Private Const CMlngGridRowTitle                 As Integer = 0                 'ﾀｲﾄﾙ行(行)
    Private Const CMstrDefaultStep                  As String = "○"               'ﾃﾞﾌｫﾙﾄ小工程
    Private Const CMstrDaitaiStep                   As String = "　"               '代替小工程

    '@ｸﾞﾘｯﾄﾞの定数宣言(ColWidth)
    Private Const CMlngGridColWidthOpID             As Integer = 200               '大工程ID
    Private Const CMlngGridColWidthStepID           As Integer = 200               '小工程ID
    Private Const CMlngGridColWidthDefault          As Integer = 67                'ﾃﾞﾌｫﾙﾄ
    Private Const CMlngGridColWidthWPID             As Integer = 276               'WPID

    '@vsfNextStepInfoの定数宣言(ｶﾗﾑ)
    Private Const CMlngNextStepInfoColOpID          As Integer = 0                 '大工程ID
    Private Const CMlngNextStepInfoColStepID        As Integer = 1                 '小工程ID
    Private Const CMlngNextStepInfoColDefault       As Integer = 2                 'ﾃﾞﾌｫﾙﾄ
    Private Const CMlngNextStepInfoColWPID          As Integer = 3                 'WPID

    '@ｸﾞﾘｯﾄﾞの幅
    Private Const CMlngGridWidth                    As Integer = CMlngGridColWidthOpID _
                                                    + CMlngGridColWidthStepID _
                                                    + CMlngGridColWidthDefault _
                                                    + CMlngGridColWidthWPID _
                                                    
    '@ｸﾞﾘｯﾄﾞの高さ
    Private Const CMlngGridHeight                   As Integer = (CMlngGridTitleHeight _
                                                    * CMlngGridFixedRows) _
                                                    + (CMlngGridRowHeight _
                                                    * CMlngGridPageRows) _
                                                    + CMlngGrid3DBlank

    '@vsfNextStepInfoの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrNextStepInfoColTOpID         As String = "次大工程"          '大工程ID
    Private Const CMstrNextStepInfoColTStepID       As String = "次小工程"          '小工程ID
    Private Const CMstrNextStepInfoColTDefault      As String = "ﾃﾞﾌｫﾙﾄ"            'ﾃﾞﾌｫﾙﾄ
    Private Const CMstrNextStepInfoColTWPID         As String = "装置名"            'WPID

    '@コンボボックス定数宣言
    Private Const CMlngComboDispCols                As Integer = 1                  '表示列数
    Private Const CMlngComboGetCol                  As Integer = 0                  '値取得列
    Private Const CMlngComboRowHeight               As Integer = 43                 '行高さ

    '@次工程ｵﾌﾟｼｮﾝﾎﾞﾀﾝの定数宣言
    Private Const CMlngOptLotNextSend0              As Integer = 0                  '次工程自動送出あり
    Private Const CMlngOptLotNextSend1              As Integer = 1                  '次工程自動送出なし
    Private Const CMlngOptLotNextSend2              As Integer = 2                  'ﾘﾜｰｸ
    Private Const CMlngOptLotNextSend3              As Integer = 3                  '追加流動

    '@特殊流動中ﾌﾗｸﾞ用
    Private Const CMstrReworkKind0                  As String = "0"                 '特殊流動なし
    Private Const CMstrReworkKind1                  As String = "1"                 '分割先(子)特殊流動中
    Private Const CMstrReworkKind2                  As String = "2"                 '分割元(親)特殊流動中
    Private Const CMstrReworkKind3                  As String = "3"                 '全数特殊流動中
    Private Const CMstrReworkFinishFlag0            As String = "0"                 '特殊流動工程ﾌﾗｸﾞ_通常工程
    Private Const CMstrReworkFinishFlag1            As String = "1"                 '特殊流動工程ﾌﾗｸﾞ_最終工程
    Private Const CMstrReworkFlag0                  As String = "0"                 '通常ﾛｯﾄ
    Private Const CMstrReworkFlag1                  As String = "1"                 'ﾘﾜｰｸﾛｯﾄ
    Private Const CMstrReworkFlag2                  As String = "2"                 '追加流動ﾛｯﾄ
    Private Const CMlngReworkLen                    As Integer = 3                  '特殊流動状態桁数
    Private Const CMlngReworkLen1                   As Integer = 1                  '特殊流動桁
    Private Const CMlngReworkLen2                   As Integer = 2                  '特殊流動桁
    Private Const CMlngReworkLen3                   As Integer = 3                  '特殊流動桁
    Private Const CMstrRework0                      As String = "0"                 '特殊流動状態で使用
    Private Const CMstrRework1                      As String = "1"                 '特殊流動状態で使用
    Private Const CMstrRework2                      As String = "2"                 '特殊流動状態で使用

    Private Const CMstrStepDivision1                As String = "1"                 '工程ﾌﾗｸﾞ(1:ﾃﾞﾌｫﾙﾄ工程)

    '@追加処理結果用
    Private Const CMstrOK                           As String = "OK"                '結果OK
    Private Const CMstrNG                           As String = "NG"                '結果NG

    '@ｱｸｼｮﾝﾄﾘｶﾞｰ用
    Private Const CMstrEN0060Title                  As String = "作業終了"

    '@移載状態用
    Private Const CMstrMoveResult0                  As String = "0"                 '移載なし
    Private Const CMstrMoveResult1                  As String = "1"                 'WF処置後、移載工程前
    Private Const CMstrMoveResult2                  As String = "2"                 '移載完了

    '@EQﾀｲﾌﾟ比較用
    Private Const CMstrEqType5                      As String = "5"                 '移載

    '@ｷｬﾘｱﾀｲﾌﾟ比較用
    Private Const CMstrCFCarrier                    As String = "CARR0005"          'CF
    Private Const CMstrTPALCarrier                  As String = "CARR0006"          'TPAL

    '@WAISTﾃﾞｰﾀ状態
    Private Const CMstrWaistStatus0                 As String = "0"                 '正常
    Private Const CMstrWaistStatus1                 As String = "1"                 '入力ﾌｧｲﾙ作成中
    Private Const CMstrWaistStatus2                 As String = "2"                 '入力ﾌｧｲﾙ作成異常
    Private Const CMstrWaistStatus3                 As String = "3"                 'DB更新中
    Private Const CMstrWaistStatus4                 As String = "4"                 'DB更新異常

    '@WP_TYPE
    Private Const CMstrHandWork                     As String = "0"

    '@SPC規格値判定結果
    Private Const CMstrSpecCheckOK                  As String = "0"                 '正常
    Private Const CMstrSpecCheckSPCNG               As String = "1"                 'SPC異常
    Private Const CMstrSpecCheckSpecNG              As String = "2"                 '規格値異常
    Private Const CMstrSpecCheckOtherNG             As String = "3"                 'その他異常

    '@SPC判定ｱﾗｰﾑﾒｯｾｰｼﾞﾎﾞｯｸｽ ｷｬﾌﾟｼｮﾝ
    Private Const CMstrSpecCheckAlarmCaption        As String = "品質管理システムアラーム"

    '@保留完了ﾌﾗｸﾞ
    Private Const CMstrHoldCompleteFlagOK           As String = "0"                 '保留成功
    Private Const CMstrHoldCompleteFlagNG           As String = "1"                 '保留失敗

    Private Const CMstrLotEventChip                 As String = "1"                 'ﾁｯﾌﾟ
    Private Const CMstrLotEventMove                 As String = "2"                 '移載
    Private Const CMstrLotEventLotOut               As String = "3"                 'ﾛｯﾄ終了
    Private Const CMstrLotEventWfScrap              As String = "4"                 'WF廃棄

    Private Const CMstrSpecialFlag0                 As String = "0"                 '処理なし
    Private Const CMstrSpecialFlagR1                As String = "1"                 'ﾘﾜｰｸ(=1)
    Private Const CMstrSpecialFlagA2                As String = "2"                 '追加流動(=2)

    '@画面表示ﾒｯｾｰｼﾞ用
    Private Const CMstrMsgNextSend                  As String = "次工程送出"        '次工程送出
    Private Const CMstrMsgSpecialR                  As String = "リワーク"          'リワーク
    Private Const CMstrMsgSpecialA                  As String = "追加流動"          '追加流動

    '@電特、保留時のﾒｯｾｰｼﾞ
    Private Const CMstrMsgELT                       As String = "電特"              '電特
    Private Const CMstrMsgTFT                       As String = "TFT"               'TFT
    Private Const CMstrMsgEltTft                    As String = "電特及びTFT"       '電特＆TFT
    Private Const CMstrMsgHold                      As String = "保留"              '保留
    Private Const CMstrMsgExcpHold                  As String = "異常処理票保留"     '異常処理票保留
    Private Const CMstrMsgActHold                   As String = "アクション予約保留" 'ｱｸｼｮﾝ予約保留
    Private Const CMstrMsgActStop                   As String = "アクション予約停止" 'ｱｸｼｮﾝ予約停止

    '@無機ODF貼り合せ結果
    Private Const CMstrOdfJBatchOK                  As String = "0"                 '無機ODF蒸着ﾊﾞｯﾁ組合せ正常
    Private Const CMstrOdfJBatchNG                  As String = "1"                 '無機ODF蒸着ﾊﾞｯﾁ組合せ異常
    Private Const CMstrEmp                          As String = "作業者"
    Private mstrOdfConverLastUpdate                 As String
    Private mstrHoldTermDate                        As String

    '@ﾃｷｽﾄ制御用
    Private Const CMlngMaxDispRow                   As Integer = 4                     'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(ﾛｯﾄｺﾒﾝﾄ)
    Private Const CMlngMaxDispMemoRow               As Integer = 3                     'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(作業ﾒﾓ)

    '@ﾚｽﾎﾟﾝｽ用定数
    Private Const CMstrFormName                     As String = "frmxxEN0060"
    Private Const CMstrCmdRegistClick               As String = "cmdRegist_Click"
    Private Const CMstrCarrValidate                 As String = "txtCarrier_Validate"
    Private Const CMstrInputChk                     As String = "prvblnInput_Chk"
    Private Const CMstrActionListDisp               As String = "prvActionList_Disp"
    Private Const CMstrWPDataChk                    As String = "prvWPData_Chk"
    Private Const CMstrcmdODFClick                  As String = "cmdODF_Click"

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '======================================Private==========================================
    Private mstrLotLastUpdate                       As String           'ﾛｯﾄ最終更新日時
    Private mstrCarrier                             As String           'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mstrMasPDVersion                        As String           '工順ﾊﾞｰｼﾞｮﾝ
    Private mblnTakeOverDispFlg                     As Boolean          '引継ぎ表示ﾌﾗｸﾞ
    Private mblnCfkiFlg                             As Boolean          'CFKIﾎﾞﾀﾝﾌﾗｸﾞ(True：有効、False：無効)
    Private mstrWpID                                As String           '装置ID
    Private mstrReworkFinishFlag                    As String           '特殊流動工程ﾌﾗｸﾞ(0:通常工程,1:最終工程)
    Private mstrReworkKind                          As String           '特殊流動状態判定ﾌﾗｸﾞ(0:特殊流動なし、1:分割先(子)、2:分割元(親)、3：全数)
    Private mstrReworkFlag                          As String           '特殊流動ﾌﾗｸﾞ(0:通常/1:ﾘﾜｰｸ/2:追加流動)
    Private mstrRWRouteId                           As String           'ﾘﾜｰｸﾙｰﾄIDの退避
    Private mstrSPRouteId                           As String           '特殊流動(追加ﾙｰﾄID)の退避
    Private mstrWPTYPE                              As String           'WP_TYPE退避領域
    Private mstrMesMode                             As String           '運用ﾓｰﾄﾞ退避用
    Private mstrRetainCarrier                       As String           '引継ぎｷｬﾘｱ退避用(Loader側)
    Private mstrRetainToCarrier                     As String           '引継ぎｷｬﾘｱ退避用(Unloader側)
    Private mblnTxtCarrierErr                       As Boolean          'ｷｬﾘｱ入力ｴﾗｰ判定用ﾌﾗｸﾞ(True:ｴﾗｰあり、False:ｴﾗｰなし)
    Private mstrFtpDataFlag                         As String           'ｵﾌﾗｲﾝFTPﾌﾗｸﾞ
    Private buttonProcessing                        As Boolean          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean          'NSYS システムコマンドでの画面クローズ
    Private ButtonClickFlag                         As Boolean          'NSYS 子画面クリックフラグ
    Private mblnWindowClose                         As Boolean          'NSYS WindowCloseフラグ

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
        pubVsfMouseWheelManager_Set(vsfNextStepInfo, cmdNextUP, cmdNextDown)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '======================================Private==========================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　Load時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 16:32:23 T.Oide
    '更新日：2008/05/02 (Fri) 18:11:15 N.Kojima
    '備　考：
    '　　　：2004/08/26 (Thu) 17:23:32 M.Miura　    次工程自動送出有無ｺﾝﾎﾞをｵﾌﾟｼｮﾝﾎﾞﾀﾝに変更した為、ｺﾝﾎﾞの設定を削除
    '　　　：2005/11/29 (Tue) 16:24:31 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2008/05/02 (Fri) 18:11:15 N.Kojima     ｿｰｽ整備。(案件№02791)
    Private Sub Form_Load()
        
        Dim lblnAns         As Boolean      '戻り値
          
        Try
              
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
              
            '@=======================
            '@　機能ﾊﾞｰｼﾞｮﾝの判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN0060, CMstrLocalVersion)
            
            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@=======================
            '@　画面初期化処理
            '@=======================
            Call prvfrmxxEN0060_Init()
            
            '@各種ｽｸﾛｰﾙﾎﾞﾀﾝの制御
            cmdCommentUp.Enabled = False                'ｺﾒﾝﾄ ▲ﾎﾞﾀﾝ
            cmdCommentDown.Enabled = False              'ｺﾒﾝﾄ ▼ﾎﾞﾀﾝ
            cmdMemoUp.Enabled = False                   '作業ﾒﾓ ▲ﾎﾞﾀﾝ
            cmdMemoDown.Enabled = False                 '作業ﾒﾓ ▼ﾎﾞﾀﾝ

            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset
            
            '@=======================
            '@　各種ﾎﾞﾀﾝの制御処理(無効化)
            '@=======================
            Call prvfrmxxEN0060_CmbInit(False)
            
            '@ｷｬﾘｱIDのｸﾘｱ
            txtCarrier.Text = vbNullString
            
            '@=======================
            '@　次工程表示一覧の初期化処理
            '@=======================
            Call prvVsfNextStepInfo_Init()
            
            '@Form_Loadﾌﾗｸﾞに"True:処理正常"をｾｯﾄ
            pblnFormLoad = True
            
            '@引継ぎ情報表示済みﾌﾗｸﾞに"False:未表示"をｾｯﾄ
            mblnTakeOverDispFlg = False
            
            Exit Sub
            
        Catch ex As Exception
                       
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "Form_Load"              '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑ　ｱｸﾃｨﾌﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 14:23:07 H.Wajima
    '更新日：2008/05/02 (Fri) 18:15:33 N.Kojima
    '備　考：
    '　　　：2005/06/09 (Thu) 13:37:01 N.Kojima     Loader/Unloader運用の場合は、Unloaderｷｬﾘｱで通信する(不具合№829)
    '　　　：2008/05/02 (Fri) 18:15:33 N.Kojima     ｿｰｽ整備。(案件№02791)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            
            '@引継ぎ情報表示済みﾌﾗｸﾞが"True:表示済"か(Form_Load後、最初の1回しか処理しない)
            If mblnTakeOverDispFlg = True Then
                '@引継ぎ情報が表示済みの場合
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@引継ぎ情報表示済みﾌﾗｸﾞに"True:表示済"をｾｯﾄ
            mblnTakeOverDispFlg = True
            
            '@Escﾎﾞﾀﾝを有効にする
            Me.CancelButton = cmdClose
            
            With ptypCommonInfo
            
                '@引数情報のｷｬﾘｱIDがNULL以外か
                If .strCarrierId <> vbNullString Then
                    '@NULL以外の場合
                    
                    '@引継ぎLoader/Unloaderｷｬﾘｱを退避
                    mstrRetainCarrier = .strCarrierId
                    mstrRetainToCarrier = .strToCarrierId
            
                    '@Loader/Unloader装置か(ｱﾝﾛｰﾀﾞｷｬﾘｱがNULL以外か)
                    If .strToCarrierId <> vbNullString Then
                        '@Loader/Unloader装置の場合
                    
                        '@EQﾀｲﾌﾟが"5=ｿｰﾀ"以外か
                        If .strEqType <> CPstrFive Then
                            '@"5:ｿｰﾀ"以外の場合
                        
                            '@初期値として、ｷｬﾘｱIDにｱﾝﾛｰﾀﾞｷｬﾘｱIDをｾｯﾄする
                            txtCarrier.Text = .strToCarrierId
                        Else
                            '@"5:ｿｰﾀ"の場合
                            
                            '@初期値として、ｷｬﾘｱIDにﾛｰﾀﾞｷｬﾘｱIDをｾｯﾄする
                            txtCarrier.Text = .strCarrierId
                        End If
                    Else
                        '@通常装置の場合
                    
                        '@初期値として、ｷｬﾘｱIDにﾛｰﾀﾞｷｬﾘｱIDをｾｯﾄする
                        txtCarrier.Text = .strCarrierId
                    End If
                    
                    '@=======================
                    '@　ｷｬﾘｱIDﾃｷｽﾄのValidate処理
                    '@=======================
                    RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                    Call txtCarrier_Validate(txtCarrier,New CancelEventArgs(False) )
                    AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                Else
                    '@NULLの場合
                    
                    '@ｷｬﾘｱIDにNULLをｾｯﾄする
                    .strCarrierId = vbNullString
                End If
            End With

            'NSYS Activate中にpublngMsgBox等で別ウィンドウを表示するとActivateがキャンセルされるため、再Activateする
            'NSYS Activateイベント中にActivate()を呼び出しても作用しないため、遅延で実行する。ラムダ式使用
            Dim lfuncActivate As Action = Sub()
                                              Me.Activate()
                                          End Sub
            Me.BeginInvoke(lfuncActivate)

            Exit Sub
            
        Catch ex As Exception
                        
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "Form_Activate"          '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑ　ｷｰﾀﾞｳﾝ時処理
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/03/03 (Wed) 12:31:54 T.Kitagawa
    '更新日：2008/05/02 (Fri) 18:22:17 N.Kojima
    '備　考：
    '　　　：2004/08/26 (Thu) 19:37:30 M.Miura　    次工程送出ｺﾝﾎﾞから次工程ｵﾌﾟｼｮﾅﾙﾎﾞﾀﾝに変更
    '　　　：2005/07/21 (Thu) 09:49:22 N.Kojima     ｷｬﾘｱﾁｪｯｸErrになった場合、ﾌｫｰｶｽが移動しない不具合を修正。
    '　　　：2008/05/02 (Fri) 18:22:17 N.Kojima     ｿｰｽ整備。(案件№02791)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
                        
            '@以下の条件の場合は、ｷｰｺｰﾄﾞを無効にし処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                e.Handled = True
                Exit Sub
            End If
            
            '@★ ｷｰｺｰﾄﾞにより処理分岐 ★
            Select Case e.KeyCode
            
                '@〓 Enterｷｰ 〓
                Case Keys.Return
                
                    '@★★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★★
                    Select Case ActiveControl.Name
                        
                        
                        '@〓〓 ｷｬﾘｱID 〓〓
                        Case txtCarrier.Name
                                                   
                            '@ｷｬﾘｱIDがNULL以外か
                            If txtCarrier.Text <> vbNullString Then
                                RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                                '@=======================
                                '@　ｷｬﾘｱIDﾃｷｽﾄのValidate処理
                                '@=======================
                                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs)
                                AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                                
                                '@ｷｬﾘｱが入力された場合にﾌｫｰｶｽが移動するようにする為
                                '@ActiveControlが"txtCarrier"の以外の場合 or Err判定ﾌﾗｸﾞがtrueの場合は
                                '@ﾌｫｰｶｽを次に移動させない
                                If ActiveControl.Name <> txtCarrier.Name Or mblnTxtCarrierErr = True Then
                                    Exit Sub
                                End If
                            End If
                        
                        '@〓〓 作業ﾒﾓ 〓〓
                        Case txtWorkMemo.Name

                            Exit Sub
                            
                    End Select
                    
                    '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽをｾｯﾄし、ｷｰｺｰﾄﾞを無効にする
                    SendKeys.SendWait(CPstrSendKeysTab)
                    e.Handled = True
            End Select
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "Form_KeyDown"           '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyPress
    '機　能：ﾌｫｰﾑ　ｷｰ押下時処理
    '引　数：KeyAscii   ：入力ｷｰｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/03/03 (Wed) 12:34:15 T.Kitagawa
    '更新日：2008/05/02 (Fri) 18:27:06 N.Kojima
    '備　考：
    '　　　：2008/05/02 (Fri) 18:27:06 N.Kojima     ｿｰｽ整備。(案件№02791)
    Private Sub Form_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles MyBase.KeyPress

        Try
           
            '@入力ｷｰが"44:ｶﾝﾏ"か
            If Asc(e.KeyChar) = 44 Then
                '@ｶﾝﾏは入力禁止
                e.Handled = True
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "Form_KeyPress"          '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑ　終了時処理
    '引　数：Cancel     ：未使用
    '　　　：UnloadMode ：未使用
    '戻り値：なし
    '作成日：2004/03/12 (Fri) 15:31:28 T.Oide
    '更新日：2008/05/07 (Wed) 10:32:02 N.Kojima
    '備　考：
    '　　　：2004/11/01 (Mon) 15:41:04 N.Kasai      閉じるﾎﾞﾀﾝ統合
    '　　　：2005/09/12 (Mon) 17:46:20 N.Kojima     Public変数の初期化処理追加。(不具合№2183)
    '　　　：2008/05/07 (Wed) 10:32:02 N.Kojima     ｿｰｽ整備。(案件№02791)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      'ACT開放処理結果格納用
        
        Try
            
            '@ﾌｫｰﾑの"×"が押されたか
            If mblnCloseFromControlMenu Then
            
                '@=======================
                '@　閉じるﾎﾞﾀﾝ押下時処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload

            End If

            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
            pblnFormLoad = False
            
            '@ﾊﾟﾌﾞﾘｯｸ構造体のｸﾘｱ
            ptypExcpConnectList.typLotList.lngBatLotListCnt = 0     '異常処理登録/表示引継ぎ用構造体
            
            '異常処理登録/表示引継ぎ構造体-ﾊﾞｯﾁﾘｽﾄ配列
            If ptypExcpConnectList.typLotList.typBatList Is Nothing Then
                ptypExcpConnectList.typLotList.typBatList = New List(Of BatList)
            Else
                ptypExcpConnectList.typLotList.typBatList.Clear()
            End If

            'ﾛｯﾄ情報-小工程ﾘｽﾄ格納用配列
            If ptypLotprestate.strSteplist Is Nothing Then
                ptypLotprestate.strSteplist = New List(Of stepList)
            Else
                ptypLotprestate.strSteplist.Clear()
            End If
            
            '@Public変数(ｵﾌﾟｼｮﾝﾎﾞﾀﾝのValue)の初期化
            pstrOptionValue = vbNullString
            
            '@Act初期化ﾌﾗｸﾞが"True:初期化済"か
            If pblnActInitFlg = True Then
                '@Actを自前で初期化した場合
                
                '@=======================
                '@　ACTｵﾌﾞｼﾞｪｸﾄ開放処理
                '@=======================
                lblnAnsTerm = pubblnAct_Term
                
                '@処理結果判定
                If lblnAnsTerm = True Then
                    '@結果：正常の場合
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                End If
            Else
                '@Act初期化ﾌﾗｸﾞが"False:未初期化"の場合
            
                '@=======================
                '@　ﾒｲﾝﾒﾆｭｰ画面拡張処理
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
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Change
    '機　能：ｷｬﾘｱIDﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/16 (Fri) 11:43:57 M.Miura
    '更新日：2008/05/07 (Wed) 10:39:26 N.Kojima
    '備　考：
    '　　　：2008/05/07 (Wed) 10:39:26 N.Kojima     ｿｰｽ整備。(案件№02791)
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change

        Try
                        
            '@=======================
            '@　画面情報初期化処理
            '@=======================
            Call prvfrmxxEN0060_Init()
            
            '@=======================
            '@　各種ﾎﾞﾀﾝの制御処理(無効化)
            '@=======================
            Call prvfrmxxEN0060_CmbInit(False)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "txtCarrier_Change"      '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Validate
    '機　能：ｷｬﾘｱIDﾃｷｽﾄ　Validate処理(入力確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/03/03 (Wed) 11:00:56 T.Kitagawa
    '更新日：2018/07/02 (Mon) 16:40:22 Y.Yoneyama
    '備　考：
    '　　　：2004/08/26 (Thu) 19:03:20 M.Miura　    次工程ｵﾌﾟｼｮﾝﾝﾎﾞﾀﾝの有効/無効制御追加
    '　　　：2004/08/26 (Thu) 19:03:20 M.Miura　    特殊流動可能条件に特殊流動中ﾌﾗｸﾞを追加
    '　　　：2004/09/06 (Mon) 10:03:21 N.Kasai　    装置情報取得ﾛｼﾞｯｸｺﾒﾝﾄｱｳﾄ(不具合№435にてWP_IDを２重取得している為、lot_curstateで取得するよう修正)
    '　　　：2004/09/07 (Tue) 22:01:21 N.Kojima　   TPAL貼り合わせ登録に関しての制御追加。
    '　　　：2004/09/08 (Wed) 13:41:40 N.Kojima　   CFKI・TPAL貼り合わせ登録の使用時のﾒｯｾｰｼﾞ表示処理をｺﾒﾝﾄ化。
    '　　　：2004/09/10 (Fri) 11:07:34 N.Kasai　    装置ﾃﾞｰﾀ登録/参照ﾎﾞﾀﾝ制御追加
    '　　　：2004/09/22 (Wed) 22:13:38 H.Wajima　   流動ﾀｲﾌﾟの判定処理追加(№891)
    '　　　：2004/10/19 (Tue) 10:45:41 S.Deguchi    「追加流動」処理追加対応
    '　　　：2004/10/26 (Tue) 11:21:42 N.Kojima　   対向基板処置登録ﾎﾞﾀﾝ制御追加(不具合№124)
    '　　　：2004/10/29 (Fri) 16:12:06 M.Miura　    対向基板処置登録ﾎﾞﾀﾝ制御の条件変更(不具合№124)
    '　　　：2004/11/17 (Wed) 16:50:46 S.Deguchi    流動ﾀｲﾌﾟの判定処理を修正(流動ﾀｲﾌﾟ:Mの場合は無条件に全てのﾎﾞﾀﾝを非活性,M以外でCF/TPALはWF/ﾁｯﾌﾟを非活性)
    '　　　：2004/12/17 (Fri) 13:36:48 S.Deguchi    ｷｬﾘｱIDの入力後のﾌｫｰｶｽ処理を修正
    '　　　：2005/01/31 (Mon) 16:20:25 H.Wajima     特殊流動ﾌﾗｸﾞの初期化処理を追加
    '　　　：2005/02/24 (Thu) 15:14:02 S.Deguchi    不具合№261の対応(ﾊﾝﾄﾞﾜｰｸ工程対応)でCL側で状態ﾁｪｯｸを行っている部分をｺﾒﾝﾄｱｳﾄ
    '　　　：                                       不具合№456の対応でﾘﾜｰｸ中のﾘﾜｰｸ,追加流動が行えるように修正
    '　　　：2005/03/08 (Tue) 16:17:21 S.Deguchi    ﾘﾜｰｸ中のﾘﾜｰｸを完全に行えないように処理を修正
    '　　　：2005/05/17 (Tue) 17:02:00 N.Kasai      ODF判定追加
    '　　　：2005/05/19 (Thu) 14:10:41 S.Deguchi    不具合№640の対応で,先行処理時の次工程ｵﾌﾟｼｮﾝﾎﾞﾀﾝ設定を修正
    '　　　：2005/05/26 (Thu) 14:11:36 N.Kasai      LP_FLAG判定追加
    '　　　：2005/05/26 (Thu) 16:43:48 N.Kojima     MES_MODE_TYPE取得の為、装置状態取得Msg追加。(改善№625対応漏れ)
    '　　　：2005/06/07 (Tue) 14:06:51 N.Kojima     Loader/Unloader対応(不具合№829)
    '　　　：2005/06/28 (Tue) 15:20:42 N.Kojima     lot_.curstateの応答のｷｬﾘｱIDがNULLの場合の対応を追加
    '　　　：2005/07/12 (Tue) 15:46:35 N.Kojima     WF状態変更・ﾁｯﾌﾟ処置(1WF全数)登録された場合に、ｵﾌﾟｼｮﾝﾎﾞﾀﾝを「送出なし」に制御する為、処理追加。(不具合№1875)
    '　　　：2005/07/21 (Thu) 13:24:11 N.Kojima     ｷｬﾘｱﾁｪｯｸでErrの場合、ﾌｫｰｶｽが次項目に進んでしまう不具合の修正。
    '　　　：2005/08/23 (Tue) 17:36:54 N.Kojima     貼り合わせ済みﾁｪｯｸにより、「ﾁｯﾌﾟ状態変更/WF状態変更」ﾎﾞﾀﾝの制御を行う。(運用障害№501)
    '　　　：2005/09/12 (Mon) 17:01:53 N.Kojima     ｵﾌﾟｼｮﾝﾎﾞﾀﾝのﾁｪｯｸが消えてしまう件の修正。(不具合№2183)
    '　　　：2005/12/27 (Tue) 13:17:41 N.Kojima     ﾚｽﾎﾟﾝｽ関数の引数を定数化。
    '　　　：2007/02/02 (Fri) 14:55:45 N.Kasai      ｱｸｼｮﾝ予約取得記述位置をｺﾏﾝﾄﾞﾎﾞﾀﾝ制御後、ﾌｫｰｶｽｾｯﾄ前に移動(№01716)
    '　　　：2008/05/07 (Wed) 10:45:13 N.Kojima     ｿｰｽ整備、ｵﾌﾟｼｮﾝﾎﾞﾀﾝの制御を「ﾃﾞﾌｫﾙﾄ=送出あり」に設定。(案件№02791)
    '　　　：2009/08/12 (Wed) 09:54:33 N.Kojima     案件№03542のついでにｿｰｽ整備。
    '　　　：2018/07/02 (Mon) 16:40:22 Y.Yoneyama   ODF#2ｵﾝﾗｲﾝ対応
    Private Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating
        
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lblnAnsNextStep         As Boolean              '次工程取得結果格納
        Dim lblnAnsChkEasComb       As Boolean              '簡易統合ﾁｪｯｸ結果格納
        Dim ltypLotNextStep         As LotNextStep          '次工程取得ﾃﾞｰﾀ格納
        Dim llngMsgAns              As Integer              'Msg戻り値
        Dim ltypEqstate             As Eqstate              '装置状態ﾘｽﾄ格納
        Dim lstrResult              As String               'ﾛｯﾄ簡易統合可否判断(0:統合不可、1:統合可)
        Dim lstrDivLotID            As String               '分割ﾛｯﾄID
        Dim lstrDivCarrierID        As String               '分割ﾛｯﾄ格納ｷｬﾘｱ
        Dim llngoptLotNextSend      As Integer              'NSYS ラジオボタン判定

        Try
           
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｷｬﾘｱIDがNULLか
            If Trim(txtCarrier.Text) = vbNullString Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDが6桁以下か
            If txtCarrier.NowByte < txtCarrier.ChrMaxByte Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"<TRM07W>$$キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱ入力ｴﾗｰ判定用ﾌﾗｸﾞに"True:ｴﾗｰあり"をｾｯﾄ
                mblnTxtCarrierErr = True
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽ保持
                e.Cancel = True
                Exit Sub
            End If
            
            '@入力ｷｬﾘｱIDと前回のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功)が同じか
            If txtCarrier.Text = mstrCarrier Then
                '@同じ場合
            
                '@ｷｬﾘｱ入力ｴﾗｰ判定用ﾌﾗｸﾞに"False:ｴﾗｰなし"をｾｯﾄ
                mblnTxtCarrierErr = False
                Exit Sub
            End If
            
            '@特殊流動画面起動制御ﾌﾗｸﾞの初期化
            pblnfrmxxEN0060SPStartFlag = False
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCarrValidate)
   
            '@=======================
            '@　画面情報初期化処理
            '@=======================
            Call prvfrmxxEN0060_Init()
            
            '@=======================
            '@　各種ﾎﾞﾀﾝの制御処理(無効化)
            '@=======================
            
            '@【ﾛｯﾄ現在状態取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                            CPstrCD13, _
                                            txtCarrier.Text, _
                                            ptypLotprestate)

             'NSYS フォーカスがある場合はチェックを付ける
            Select Case ActiveControl.Name
                Case optLotNextSend0.Name
                    llngoptLotNextSend = 0
                Case optLotNextSend1.Name
                    llngoptLotNextSend = 1
                Case optLotNextSend2.Name
                    llngoptLotNextSend = 2
                Case optLotNextSend3.Name
                    llngoptLotNextSend = 3
                Case Else
                    llngoptLotNextSend = 5
            End Select

            'NSYS 再描画
             vsfNextStepInfo.Redraw = False
            
            '@ﾛｯﾄ現在状態取得結果判定
            If lblnAns = True Then
                '@ﾛｯﾄ現在状態取得結果：正常の場合

                '@ｷｬﾘｱIDがNULLか
                If ptypLotprestate.strCarrierId = vbNullString Then
                    '@入力されたｷｬﾘｱを引継ぎｷｬﾘｱ退避用に格納(Loader側)
                    mstrRetainCarrier = txtCarrier.Text
                Else
                    '@ﾛｯﾄ現在状態取得で取得したｷｬﾘｱを引継ぎｷｬﾘｱ退避用に格納(Loader側)
                    mstrRetainCarrier = ptypLotprestate.strCarrierId
                End If

                '@ｷｬﾘｱ入力ｴﾗｰ判定用ﾌﾗｸﾞに"False:ｴﾗｰなし"をｾｯﾄ
                mblnTxtCarrierErr = False
                
                '@=======================
                '@　ﾛｯﾄ情報表示処理
                '@=======================
                Call prvfrmxxEN0060_Disp(ptypLotprestate)

                'NSYS 再描画
                vsfNextStepInfo.Redraw = True

            Else
                '@ﾛｯﾄ現在状態取得結果：異常の場合

                'NSYS 再描画
                vsfNextStepInfo.Redraw = True
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCarrValidate)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽ保持
                e.Cancel = True
                
                '@=======================
                '@　ﾊｲﾗｲﾄ処理
                '@=======================
                Call pubHighlight(txtCarrier)
                
                '@ｷｬﾘｱ入力ｴﾗｰ判定用ﾌﾗｸﾞに"True:ｴﾗｰあり"をｾｯﾄ
                mblnTxtCarrierErr = True

                                
                Exit Sub
            End If
            
            '@ﾛｯﾄ現在状態取得のWPIDをﾓｼﾞｭｰﾙ変数に格納
            '@　①装置ﾃﾞｰﾀ登録/参照画面で使用する為
            '@　②ｱｸｼｮﾝ予約確認画面の情報取得で使用する為
            mstrWpID = ptypLotprestate.strWpID

            '@次回ｷｬﾘｱIDが入力されて同じだったら処理をｷｬﾝｾﾙする為に格納
            mstrCarrier = txtCarrier.Text
            
            '@=======================
            '@　各種ﾎﾞﾀﾝの制御処理(有効化)
            '@=======================
            Call prvfrmxxEN0060_CmbInit(True)

            ltypLotNextStep = New LotNextStep ()
            '@【ﾛｯﾄ次工程取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAnsNextStep = pubblnLotNextStepList_Sel(CMstrlot_nextsteplistVer, _
                                                        ptypLotprestate.strLotID, _
                                                        ptypLotprestate.strOpID, _
                                                        ptypLotprestate.strStepID, _
                                                        ltypLotNextStep)

            '@ﾛｯﾄ次工程取得結果判定
            If lblnAnsNextStep = True Then
                '@ﾛｯﾄ次工程取得結果：正常の場合
            
                With ltypLotNextStep
                      
                    '@ﾛｯﾄ次工程ﾘｽﾄが1件以上存在するか
                    If .lngNextStepListCnt > 0 Then
                        '@1件以上存在する場合
                        
                        '@次大工程、次小工程、工程ﾌﾗｸﾞ(0：ﾃﾞﾌｫﾙﾄ工程、1：代替工程)がNULLか
                        '@　※最終工程の判定は次大工程/次小工程/工程ﾌﾗｸﾞ(0：ﾃﾞﾌｫﾙﾄ工程、1：代替工程)が空白の場合で判断する。(SV確認)
                        If .strNextStepList(0).strNextOpId = vbNullString And _
                            .strNextStepList(0).strNextStepId = vbNullString And _
                            .strNextStepList(0).strStepDivision = vbNullString Then
                            
                            '@大工程/小工程/工程ﾌﾗｸﾞが空白の場合は、処理なし
                        Else
                            '@上記条件以外の場合
                            
                            '@=======================
                            '@　次工程情報表示処理
                            '@=======================
                            Call prvVsfNextStepInfo_Disp(ltypLotNextStep, ltypLotNextStep.lngNextStepListCnt)
                        End If
                    Else
                        '@0件以下の場合
                    
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCarrValidate)
                        
                        '@=======================
                        '@　各種ﾎﾞﾀﾝの制御処理(無効化)
                        '@=======================
                        Call prvfrmxxEN0060_CmbInit(False)
                         
                        '@ｷｬﾘｱIDにﾌｫｰｶｽ保持
                        e.Cancel = True
                        Exit Sub
                    End If
                End With

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCarrValidate)
            Else
                '@ﾛｯﾄ次工程取得結果：異常の場合
            
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
                
                '@=======================
                '@　各種ﾎﾞﾀﾝの制御処理(無効化)
                '@=======================
                Call prvfrmxxEN0060_CmbInit(False)
                
                '@=======================
                '@　ﾊｲﾗｲﾄ処理
                '@=======================
                Call pubHighlight(txtCarrier)
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCarrValidate)
                
                Exit Sub
            End If
            
            
            '@***********************
            '@　CFKI作業終了入力ﾎﾞﾀﾝの制御
            '@***********************
            '@装置ﾀｲﾌﾟが"3:CFKI"か
            If ptypLotprestate.strEqType = CPstrEqTypeCFKI Then
                '@CFKIの場合
            
                '@CFﾛｯﾄ確定可能ﾌﾗｸﾞが"1:CFﾛｯﾄ確定可能"か
                If ptypLotprestate.strCfCompFlag = CPstrCOMP Then
                
                    '@CFKI作業終了ﾎﾞﾀﾝを無効にする
                    cmdCFKIWorkEnd.Enabled = False
                Else
                    '@CFKI作業終了ﾎﾞﾀﾝを有効にする
                    cmdCFKIWorkEnd.Enabled = True
                End If
            End If
                
            '@***********************
            '@　TPAL貼り合せ登録ﾎﾞﾀﾝ、WF状態変更ﾎﾞﾀﾝ、ﾁｯﾌﾟ状態変更ﾎﾞﾀﾝの制御
            '@　※貼り合わせ済みﾛｯﾄ入力時のみ、「ﾁｯﾌﾟ状態変更,WF状態変更」ﾎﾞﾀﾝを有効にする
            '@***********************
            '@装置ﾀｲﾌﾟが"4:TPAL"か
            If ptypLotprestate.strEqType = CPstrEqTypeTPAL Then
                '@TPALの場合
            
                '@貼り合せﾌﾗｸﾞが"1:貼り合せ済み"か
                If ptypLotprestate.strCoverFlag = CPstrTpalComp Then
                
                    '@TPAL貼り合せ登録ﾎﾞﾀﾝを無効にする
                    cmdTpalCombRegist.Enabled = False
                    
                    '@WF状態変更、ﾁｯﾌﾟ状態変更ﾎﾞﾀﾝを有効にする
                    cmdTreatChip.Enabled = True
                    cmdTreatWF.Enabled = True
                Else
                    '@TPAL貼り合せ登録ﾎﾞﾀﾝを有効にする
                    cmdTpalCombRegist.Enabled = True
                    
                    '@WF状態変更,ﾁｯﾌﾟ状態変更ﾎﾞﾀﾝを無効にする
                    cmdTreatChip.Enabled = False
                    cmdTreatWF.Enabled = False
                End If
                
            End If
            
            
            '@↓2009/06/15 (Mon) 17:32:42 T.Oide **************************************************
            '@***********************
            '@　CF移載情報登録ﾎﾞﾀﾝ制御
            '@　　※CF移載機以外は使用不可
            '@***********************
            '@EQ_TYPEがCF移載B、Cの場合
            If ptypLotprestate.strEqType = CPstrEQ_TYPE_MoveB Or _
               ptypLotprestate.strEqType = CPstrEQ_TYPE_MoveC Then
               
                '@CF移載情報を有効にする
                cmdCFMove.Enabled = True
            Else
                
                '@CF移載情報を無効にする
                cmdCFMove.Enabled = False
            End If
            '@↑2009/06/15 (Mon) 17:32:42 T.Oide **************************************************
            
            
            
            '@***********************
            '@　装置ﾃﾞｰﾀ登録／参照ﾎﾞﾀﾝの制御
            '@　　※COLLECTION_IDがNULLの場合は使用不可
            '@***********************
            '@収集項目IDがNULLか
            If ptypLotprestate.strCollectionID = vbNullString Then
            
                '@装置ﾃﾞｰﾀ登録／参照ﾎﾞﾀﾝを無効にする
                cmdCollectionInfo.Enabled = False
            Else
                '@装置ﾃﾞｰﾀ登録／参照ﾎﾞﾀﾝを有効にする
                cmdCollectionInfo.Enabled = True
            End If
            
            
            '@***********************
            '@　対向基板処置登録ﾎﾞﾀﾝの制御
            '@***********************
            '@対向基板処置登録ﾎﾞﾀﾝが表示されているか
            If cmdTreatCF.Visible = True Then
                '@表示されている場合
                
                '@CFﾌﾗｸﾞがNULL or "0"(CF以外)、またはCFﾛｯﾄ確定可能ﾌﾗｸﾞが"1:CFﾛｯﾄ確定可能"か
                If ptypLotprestate.strCfFlag = vbNullString Or _
                    ptypLotprestate.strCfFlag = CPstrZero Or _
                    ptypLotprestate.strCfCompFlag = CPstrCOMP Then
                    
                    '@対向基板処置登録ﾎﾞﾀﾝを無効にする
                    cmdTreatCF.Enabled = False
                Else
                    '@上記条件以外の場合
                
        '@↓2009/08/12 (Wed) 09:54:22 N.Kojima **************************************************

        '            '@ODFﾌﾗｸﾞが"1:ODF"、またはCFﾌﾗｸﾞが"3:ODF"か
        '            If ptypLotprestate.strLpFlag = CPstrLP Or _
        '                ptypLotprestate.strCfFlag = CPstrODF Then

                    '@ODFﾌﾗｸﾞが"1:ODF"か
                    If ptypLotprestate.strLpFlag = CPstrLP Then

        '@↑2009/08/12 (Wed) 09:54:22 N.Kojima **************************************************
                    
                        '@対向基板処置登録ﾎﾞﾀﾝを無効にする
                        cmdTreatCF.Enabled = False
                    Else
                        '@上記条件以外の場合
                    
                        '@対向基板処置登録ﾎﾞﾀﾝを有効にする
                        cmdTreatCF.Enabled = True
                    End If
                End If
            End If

            
            '@***********************
            '@　ｵﾌﾟｼｮﾝﾎﾞﾀﾝの制御
            '@***********************
            '@↓CFKI判定でも確定ﾎﾞﾀﾝの制御しているので注意して下さいね。
            '@次工程あり、または装置ﾀｲﾌﾟが"5:移載"以外で、かつ特殊流動状態判定ﾌﾗｸﾞが部分特殊流動中ではないか
            If vsfNextStepInfo.Rows.Count > vsfNextStepInfo.Rows.Fixed Or _
               (ptypLotprestate.strEqType <> CMstrEqType5 And _
                mstrReworkKind <> CMstrReworkKind1 And _
                mstrReworkKind <> CMstrReworkKind2) Then
                
                '@全数特殊流動中で、かつ特殊流動の最終工程か
                If mstrReworkKind = CMstrReworkKind3 And _
                    mstrReworkFinishFlag = CMstrReworkFinishFlag1 Then
                    
                    '@ﾛｯﾄ次工程情報の装置ﾘｽﾄがNULL以外か
                    If ltypLotNextStep.strNextStepList(0).strWPList(0).strWpID <> vbNullString Then
                        
                        '@「送出あり」ｵﾌﾟｼｮﾝﾎﾞﾀﾝを有効にし、ﾁｪｯｸを付ける
                        optLotNextSend0.Enabled = True
                        optLotNextSend0.Checked = True
                    Else
                        '@ﾛｯﾄ次工程情報の装置ﾘｽﾄがNULLの場合
                        
                        '@「送出あり」ｵﾌﾟｼｮﾝﾎﾞﾀﾝを無効にし、ﾁｪｯｸを外す
                        optLotNextSend0.Enabled = False
                        optLotNextSend0.Checked = False
                        
                        '@「送出なし」ｵﾌﾟｼｮﾝﾎﾞﾀﾝにﾁｪｯｸを付ける
                        optLotNextSend1.Checked = True
                    End If
                Else
                    '@上記条件以外の場合
                
                    '@「送出あり」ｵﾌﾟｼｮﾝﾎﾞﾀﾝを有効にし、ﾁｪｯｸを付ける
                    optLotNextSend0.Enabled = True
                    optLotNextSend0.Checked = True
                End If

            Else
                '@上記条件以外の場合
                
                '@「送出あり」ｵﾌﾟｼｮﾝﾎﾞﾀﾝを無効にし、ﾁｪｯｸを外す
                optLotNextSend0.Enabled = False
                optLotNextSend0.Checked = False
                
                '@「送出なし」ｵﾌﾟｼｮﾝﾎﾞﾀﾝにﾁｪｯｸを付ける
                optLotNextSend1.Checked = True
            End If

            '@----------------------------------------------------------------------------------------------------
            '@EQ_TYPEﾌﾗｸﾞを判定しCFKIの場合のみ次工程送出禁止。№01787
            '  CFKIでは,作業開始～作業終了の間にCFﾛｯﾄからTPALﾛｯﾄの移載が行われ,作業終了後はCFﾛｯﾄとしては存在しない。
            '  なので対応方法としては , CFKIの作業終了後は直ぐにTPALﾛｯﾄをActiveにし,CFロットとして
            '  次工程送出ができないようにした方が , 現物の状態と適合すると思われる
            '  1) CFKIの場合, 作業終了時に送出なしを選べなくする(必ず次工程送出が作業終了に連動して実行される)
            '  2) 1)の対応により, CFKI作業終了後に"lot_.cfend"を送る事がなくなるので, 次工程送出画面からﾛｼﾞｯｸを削除する
            '@----------------------------------------------------------------------------------------------------
            '@装置ﾀｲﾌﾟが"3:CFKI"か
            If ptypLotprestate.strEqType = CPstrEqTypeCFKI Then
            
                '@「送出なし」ｵﾌﾟｼｮﾝﾎﾞﾀﾝを無効にする
                optLotNextSend1.Enabled = False
            Else
                '@「送出なし」ｵﾌﾟｼｮﾝﾎﾞﾀﾝを有効にする
                optLotNextSend1.Enabled = True
            End If
            
            '@ﾘﾜｰｸ設定されていて、かつ(通常ﾛｯﾄ、またはﾘﾜｰｸﾛｯﾄ(全数/部分問わず)で、かつﾘﾜｰｸ最終工程以外)か
            If ptypLotprestate.strReworkRouteID <> vbNullString And _
               (mstrReworkFlag = CMstrReworkFlag0 Or _
                (mstrReworkFlag = CMstrReworkFlag1 And _
                 mstrReworkFinishFlag = CMstrReworkFinishFlag0)) Then
                 
                '@「ﾘﾜｰｸ」ｵﾌﾟｼｮﾝﾎﾞﾀﾝを有効にする
                optLotNextSend2.Enabled = True
            Else
                '@「ﾘﾜｰｸ」ｵﾌﾟｼｮﾝﾎﾞﾀﾝを無効にする
                optLotNextSend2.Enabled = False
            End If

            '@追加流動が設定されていて、かつ分割先(子)も分割元(親)も特殊流動中ではないか
            If mstrSPRouteId <> vbNullString And mstrReworkFlag = CMstrReworkFlag0 Then
            
                '@「追加流動」ｵﾌﾟｼｮﾝﾎﾞﾀﾝを有効にする
                optLotNextSend3.Enabled = True
            Else
                '@「追加流動」ｵﾌﾟｼｮﾝﾎﾞﾀﾝを無効にする
                optLotNextSend3.Enabled = False
            End If
               
            '@↓ '09/06/24(Wed) K.Nishizawa ************************************************************************
            If ptypLotprestate.strEqType = CPstrEqTypeTPAL And _
                ptypLotprestate.strVaFlag = CPstrOne Then

                lblnAnsChkEasComb = pubblnLotChkEasyCombine_sel(CMstrlot_chkeasycombineVer, _
                                                                pstrSBID, _
                                                                ptypLotprestate.strLotID, _
                                                                lstrResult, lstrDivCarrierID, lstrDivLotID)
                                                                
                If lblnAnsChkEasComb Then
                    If lstrResult = CPstrOne Then
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009J, ptypLotprestate.strLotID)
                        llngMsgAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                        If llngMsgAns = vbYes Then
                            optLotNextSend1.Checked  = False
                            optLotNextSend0.Enabled  = True
                            optLotNextSend0.Checked  = True
                            
                        Else
                            optLotNextSend0.Checked  = False
                            optLotNextSend0.Enabled = False
                            optLotNextSend1.Checked  = True
                        End If
                    End If
                Else
                    '@確定ﾎﾞﾀﾝを無効にする
                    cmdRegist.Enabled = False
                        
                    '@=======================
                    '@　各種ﾎﾞﾀﾝの制御処理(無効化)
                    '@=======================
                    Call prvfrmxxEN0060_CmbInit(False)
                        
                    '@=======================
                    '@　ﾊｲﾗｲﾄ処理
                    '@=======================
                    Call pubHighlight(txtCarrier)
                        
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCarrValidate)
                    Exit Sub
                End If
            End If
            '@↑ '09/06/24(Wed) K.Nishizawa ************************************************************************


			'kkw 蒸着2回対応対象機種、基板特殊ルート設定済み判定
			'条件を満たす場合は「追加流動」オプションボタンを選択状態にする
			'組立工程の場合
			'@起動SBが2A0=組立の場合
            If pstrSBID = CPstrSBID2A0 Then
				'アンローダーキャリアが基板FOUPの場合
				If txtCarrier.Text <> vbNullString And txtCarrier.Text.Substring(0,1) = "A" Then
					'装置が異物検査装置の場合
					If ptypLotprestate.strEqType =  CPstrEqTypeVFI  Then

						'蒸着2回対象機種かつ基板特殊ルートが設定された工程か確認する
						lblnAns = pubblnDoubleJPd_Chk(CMstrlot_chkdoublejpdVer, _
															lblLotID.Text, _
															lblPdID.Text, _
															lstrResult, _
															CPstrCD13)

						'蒸着2回対象機種かつ基板特殊ルートが設定されているかつ基板ｷｬﾘｱの場合は「追加流動」にチェックを入れる
						If lstrResult = CPstrFlagOn Then
							If optLotNextSend3.Enabled = True Then
								optLotNextSend3.Checked = True
							End If
						End If


					End If
				End If
			End If


            '@=======================
            '@　確定ﾎﾞﾀﾝの有効/無効制御処理
            '@=======================
            Call prvcmdRegist_Set()
            
            
            '@流動ﾀｲﾌﾟが"M:移載工程"か
            If ptypLotprestate.strFlowType = CPstrLotCurstateFlowTypeMove Then
                '@"M:移載工程"の場合
                
                '@確定、閉じる以外のﾎﾞﾀﾝは無効にする
                cmdCFKIWorkEnd.Enabled = False          'CFKI作業終了入力
                cmdTpalCombRegist.Enabled = False       'TPAL貼り合せ登録
                cmdTreatCF.Enabled = False              '対向基板処置登録
                cmdActionDisp.Enabled = False           'ｱｸｼｮﾝ予約確認
                cmdCommntInput.Enabled = False          'ﾛｯﾄｺﾒﾝﾄ
                cmdCollectionInfo.Enabled = False       '装置ﾃﾞｰﾀ登録/参照
                cmdTrouble.Enabled = False              '異常処理票起案
                cmdTreatWF.Enabled = False              'WF処置登録
                cmdTreatChip.Enabled = False            'ﾁｯﾌﾟ処置登録
                cmdODF.Enabled = False                  'ODF貼り合せ登録
             
                '@作業ﾒﾓ関連ｺﾝﾄﾛｰﾙを無効にする
                txtWorkMemo.Enabled = False             '作業ﾒﾓ
                cmdMemoUp.Enabled = False               '上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ
                cmdMemoDown.Enabled = False             '下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ
                
            Else
                '@"M:移載工程"以外の場合
            
                '@ｷｬﾘｱﾀｲﾌﾟが"CARR0005:CFｷｬﾘｱ"、または"CARR0006:TPALｷｬﾘｱ"か
                If ptypLotprestate.strCarrierTypeID = CMstrCFCarrier Or _
                    ptypLotprestate.strCarrierTypeID = CMstrTPALCarrier Then
                    
                    '@各種ﾎﾞﾀﾝを無効にする
                    cmdTreatWF.Enabled = False              'WF処置登録
                    cmdTreatChip.Enabled = False            'ﾁｯﾌﾟ処置登録
                End If
                
                
                '@***********************
                '@　ODF判定
                '@***********************
                '@装置ﾀｲﾌﾟが"14:ODF"&ﾊﾝﾄﾞﾜｰｸ装置の場合
        '@↓2018/07/02 (Mon) 10:38:59 Y.Yoneyama **************************************************
                If ptypLotprestate.strEqType = CPstrEqTypeODF And _
                    ptypLotprestate.strWpTypeFlag = CMstrHandWork Then
        '@↑2018/07/02 (Mon) 10:38:59 Y.Yoneyama **************************************************
                    '@ODFの場合
                    
                    '@ODF貼り合せ登録ﾎﾞﾀﾝを有効にする
                    cmdODF.Enabled = True
                    
                    '@「ﾘﾜｰｸ」・「追加流動」ｵﾌﾟｼｮﾝﾎﾞﾀﾝを無効にする
                    optLotNextSend2.Enabled = False
                    optLotNextSend3.Enabled = False
                    
                    '@貼り合せﾌﾗｸﾞが"1:貼り合せ未完"以外か
                    If ptypLotprestate.strCoverFlag <> CPstrODFComp Then
                    
                        '@ODF貼り合せ未完の場合は、下記のﾎﾞﾀﾝを無効にする
                        cmdCollectionInfo.Enabled = False       '装置ﾃﾞｰﾀ登録/参照
                        cmdTrouble.Enabled = False              '異常処理票起案
                        cmdTreatWF.Enabled = False              'WF処置登録
                        cmdTreatChip.Enabled = False            'ﾁｯﾌﾟ処置登録
                    End If
                Else
                    '@装置ﾀｲﾌﾟが"14:ODF"以外
                
                    '@ODF貼り合せ登録ﾎﾞﾀﾝを無効にする
                    cmdODF.Enabled = False
                End If
            End If
            
            
            '@=======================
            '@　ｱｸｼｮﾝ予約ﾘｽﾄ取得処理
            '@　　※ｺﾏﾝﾄﾞﾎﾞﾀﾝ制御後で且つ、ﾌｫｰｶｽ制御前に取得を行なう必要がある
            '@=======================
            Call prvActionList_Disp()
            
            
            '@「送出あり」ｵﾌﾟｼｮﾝﾎﾞﾀﾝが無効で、かつ「送出なし」ｵﾌﾟｼｮﾝﾎﾞﾀﾝが有効か
            If optLotNextSend0.Enabled = False And _
                optLotNextSend1.Enabled = True Then
                
                If ActiveControl.Name <>  cmdRegist.Name And ActiveControl.Name <> txtLotCommnt.Name And 
                   ActiveControl.Name <>  cmdTreatChip.Name And ActiveControl.Name <> cmdTreatWF.Name And 
                   ActiveControl.Name <>  cmdTrouble.Name And ActiveControl.Name <> cmdActionDisp.Name And
                   ActiveControl.Name <>  cmdCommntInput.Name And ActiveControl.Name <> cmdNextUP.Name And
                   ActiveControl.Name <>  cmdNextDown.Name  Or ButtonClickFlag = True Then
                
                    '@確定ﾎﾞﾀﾝが有効か
                If cmdRegist.Enabled = True Then
                
                    '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdRegist)
                Else
                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If

               End If
                
            Else
                '@上記条件以外の場合
            
                '@「ﾘﾜｰｸ」ｵﾌﾟｼｮﾝﾎﾞﾀﾝが有効、または「追加流動」ｵﾌﾟｼｮﾝﾎﾞﾀﾝが有効か
                If optLotNextSend2.Enabled = True Or _
                    optLotNextSend3.Enabled = True Then

                    If ActiveControl.Name <>  cmdRegist.Name And ActiveControl.Name <> txtLotCommnt.Name And 
                       ActiveControl.Name <>  cmdTreatChip.Name And ActiveControl.Name <> cmdTreatWF.Name And 
                       ActiveControl.Name <>  cmdTrouble.Name And ActiveControl.Name <> cmdActionDisp.Name And
                       ActiveControl.Name <>  cmdCommntInput.Name And ActiveControl.Name <> cmdNextUP.Name And
                       ActiveControl.Name <>  cmdNextDown.Name  Or ButtonClickFlag = True Then

                
                        '@ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝが有効か
                        If cmdCommntInput.Enabled = True Then
                    
                           '@ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                           Call pubSetFocus(cmdCommntInput)
                        Else
                          '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                           Call pubSetFocus(cmdClose)
                        End If
                    End If
                Else
                    '@上記条件以外の場合
                
                    '@「送出あり」ｵﾌﾟｼｮﾝﾎﾞﾀﾝが有効で、かつ「ﾘﾜｰｸ」・「追加流動」ｵﾌﾟｼｮﾝﾎﾞﾀﾝが無効か
                    If optLotNextSend0.Enabled = True And _
                        optLotNextSend2.Enabled = False And _
                        optLotNextSend3.Enabled = False Then

                        If ActiveControl.Name <>  cmdRegist.Name And ActiveControl.Name <> txtLotCommnt.Name And 
                           ActiveControl.Name <>  cmdTreatChip.Name And ActiveControl.Name <> cmdTreatWF.Name And 
                           ActiveControl.Name <>  cmdTrouble.Name And ActiveControl.Name <> cmdActionDisp.Name And
                           ActiveControl.Name <>  cmdCommntInput.Name And ActiveControl.Name <> cmdNextUP.Name And
                           ActiveControl.Name <>  cmdNextDown.Name  Or ButtonClickFlag = True Then

                            '@「送出あり」ｵﾌﾟｼｮﾝﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(optLotNextSend0)

                        End If 
                                               
                    End If
                End If
            End If
            
            
            '@WF状態変更・ﾁｯﾌﾟ処置(1WF全数)登録された場合に、ｵﾌﾟｼｮﾝﾎﾞﾀﾝを「送出なし」に制御する為、処理追加。
            '@大工程ID、小工程ID、ﾛｯﾄIDが退避構造体と同じで、移載予約中の場合
            If pstrLotInsprstResult.strOpID = lblOpID.Text And _
                pstrLotInsprstResult.strStepID = lblStepID.Text And _
                pstrLotInsprstResult.strLotID = lblLotID.Text And _
                pstrLotInsprstResult.strWorkKbn = CMstrMoveResult2 Then
                
                '@「送出あり」ｵﾌﾟｼｮﾝﾎﾞﾀﾝ関連
                optLotNextSend0.Enabled = False       '無効
                optLotNextSend0.Checked  = False      'ﾁｪｯｸなし
                
                '@「ﾘﾜｰｸ」ｵﾌﾟｼｮﾝﾎﾞﾀﾝ関連
                optLotNextSend2.Enabled = False       '無効
                optLotNextSend2.Checked  = False      'ﾁｪｯｸなし
                
                '@「追加流動」ｵﾌﾟｼｮﾝﾎﾞﾀﾝ関連
                optLotNextSend3.Enabled  = False      '無効
                optLotNextSend3.Checked  = False      'ﾁｪｯｸなし
                
                '@「送出なし」ｵﾌﾟｼｮﾝﾎﾞﾀﾝが有効か
                If optLotNextSend1.Enabled = True Then
                    '@「送出なし」にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(optLotNextSend1)
                End If
                
            End If
            
            
            '@***********************
            '@　ｵﾌﾟｼｮﾝﾎﾞﾀﾝのﾁｪｯｸが消えてしまう件の対応
            '@***********************
            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ格納変数に値が入っているか
            If pstrOptionValue <> vbNullString Then
               '@格納されているｵﾌﾟｼｮﾝﾎﾞﾀﾝが有効か
                Dim ctrl As New RadioButton
                Select pstrOptionValue
                    Case 0
                     ctrl = optLotNextSend0
                    Case 1
                     ctrl = optLotNextSend1
                    Case 2
                     ctrl = optLotNextSend2
                    Case 3
                     ctrl = optLotNextSend3
                    Case Else 
                                                          
                End Select

                 If ctrl.Enabled = True Then
                    '@格納されている値のｵﾌﾟｼｮﾝﾎﾞﾀﾝにﾁｪｯｸを付ける
                    ctrl.Checked = True
                 End If

            End If
            

            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ格納変数の値をｸﾘｱ
            pstrOptionValue = vbNullString
              
            '@【装置状態取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnEqState_Sel(CMstreq__state___Ver, _
                                        ptypLotprestate.strWpID, _
                                        ltypEqstate)
            
            '@装置状態取得結果判定
            If lblnAns = False Then
                '@装置状態取得結果：異常の場合
                Exit Sub
            End If

            '@使用装置の運用ﾓｰﾄﾞを格納
            '@　①確定処理で"運用ﾓｰﾄﾞ:M1"かのﾁｪｯｸで使用
            mstrMesMode = ltypEqstate.strMesModeId

             'NSYS フォーカスがある場合はチェックを付ける
            Select Case llngoptLotNextSend
             Case 0 
                optLotNextSend0.Checked = True
                Call pubSetFocus(optLotNextSend0)
             Case=1 
                optLotNextSend1.Checked = True
                Call pubSetFocus(optLotNextSend1)
             Case 2 
                optLotNextSend2.Checked = True
                Call pubSetFocus(optLotNextSend2)
             Case 3 
                optLotNextSend3.Checked = True
                Call pubSetFocus(optLotNextSend3)
        End Select
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "txtCarrier_Validate"    '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNextUP_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(次工程ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 10:19:20 M.Miura
    '更新日：2008/05/07 (Wed) 17:00:31 N.Kojima
    '備　考：
    '　　　：2008/05/07 (Wed) 17:00:31 N.Kojima     ｿｰｽ整備。(案件№02791)
    Private Sub cmdNextUP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNextUP.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@　ｸﾞﾘｯﾄﾞ用上ｽｸﾛｰﾙﾎﾞﾀﾝ処理
            '@=======================
            Call pubVsfCmdUp(vsfNextStepInfo, cmdNextUP, cmdNextDown)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdNextUP_Click"        '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNextDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(次工程ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 10:19:55 M.Miura
    '更新日：2008/05/07 (Wed) 17:01:47 N.Kojima
    '備　考：
    '　　　：2008/05/07 (Wed) 17:01:47 N.Kojima     ｿｰｽ整備。(案件№02791)
    Private Sub cmdNextDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNextDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@　ｸﾞﾘｯﾄﾞ用下ｽｸﾛｰﾙﾎﾞﾀﾝ処理
            '@=======================
            Call pubVsfCmdDown(vsfNextStepInfo, cmdNextUP, cmdNextDown)

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdNextDown_Click"      '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：optLotNextSend_Click
    '機　能：次工程送出ｵﾌﾟｼｮﾅﾙﾎﾞﾀﾝ　選択時処理
    '引　数：Index  ：ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2004/10/18 (Mon) 11:59:25 M.Miura
    '更新日：2008/05/07 (Wed) 16:46:15 N.Kojima
    '備　考：
    '　　　：2008/05/07 (Wed) 16:46:15 N.Kojima     ｿｰｽ整備。(案件№02791)
    Private Sub optLotNextSend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optLotNextSend0.Click,optLotNextSend1.Click, _
                                                                                           optLotNextSend2.Click,optLotNextSend3.Click
        Try
                     
            '@=======================
            '@　確定ﾎﾞﾀﾝの有効/無効制御処理
            '@=======================
            Call prvcmdRegist_Set()

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "optLotNextSend_Click"   '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_Change
    '機　能：作業ﾒﾓﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 14:39:17 M.Miura
    '更新日：2008/05/07 (Wed) 16:49:36 N.Kojima
    '備　考：
    '　　　：2005/11/29 (Tue) 15:58:56 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2008/05/07 (Wed) 16:49:36 N.Kojima     ｿｰｽ整備。(案件№02791)
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change
        
        Dim llngNowByte     As Integer  'ﾊﾞｲﾄ数
        
        Try
           
            '@作業ﾒﾓの入力ﾃﾞｰﾀﾊﾞｲﾄ数格納
            llngNowByte = txtWorkMemo.NowByte
            
            '@=======================
            '@　現在のﾊﾞｲﾄ数表示処理(表示ﾒｯｾｰｼﾞ変換)
            '@=======================
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            
            '@=======================
            '@　ﾃｷｽﾄ変更時処理
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtWorkMemo_Change"         '処理名
                .strErrMessage = ""                         'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
                                
        End Try
    End Sub

    '関数名：txtWorkMemo_KeyUp
    '機　能：作業ﾒﾓﾃｷｽﾄ　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:15:19 N.Kasai
    '更新日：2008/05/07 (Wed) 16:51:29 N.Kojima
    '備　考：
    '　　　：2008/05/07 (Wed) 16:51:29 N.Kojima     ｿｰｽ整備。(案件№02791)
    Private Sub txtWorkMemo_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtWorkMemo.KeyUp

        Try
                       
            '@=======================
            '@　ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作時処理
            '@=======================
            Call pubtxtKeyUp_Proc(e.keycode, txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotCommnt_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_MouseUp
    '機　能：作業ﾒﾓﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:52:24 N.Kasai
    '更新日：2008/05/07 (Wed) 16:52:18 N.Kojima
    '備　考：
    '　　　：2008/05/07 (Wed) 16:52:18 N.Kojima     ｿｰｽ整備。(案件№02791)
    Private Sub txtWorkMemo_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtWorkMemo.MouseUp

        Try
                        
            '@=======================
            '@　ﾃｷｽﾄ変更時処理
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown, e.Button)
            
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

    '関数名：cmdMemoUp_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(作業ﾒﾓ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 14:52:32 M.Miura
    '更新日：2008/05/07 (Wed) 16:53:16 N.Kojima
    '備　考：
    '　　　：2005/11/29 (Tue) 15:56:34 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2008/05/07 (Wed) 16:53:16 N.Kojima     ｿｰｽ整備。(案件№02791)
    Private Sub cmdMemoUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoUp.Click

        Try
 
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@=======================
            '@　ﾃｷｽﾄ用上ｽｸﾛｰﾙﾎﾞﾀﾝ処理
            '@=======================
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdMemoUp_Click"        '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(作業ﾒﾓ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 14:53:27 M.Miura
    '更新日：2008/05/07 (Wed) 16:54:14 N.Kojima
    '備　考：
    '　　　：2005/11/29 (Tue) 15:57:55 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2008/05/07 (Wed) 16:54:14 N.Kojima     ｿｰｽ整備。(案件№02791)
    Private Sub cmdMemoDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoDown.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@=======================
            '@　ﾃｷｽﾄ用下ｽｸﾛｰﾙﾎﾞﾀﾝ処理
            '@=======================
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdMemoDown_Click"      '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotCommnt_Change
    '機　能：ｺﾒﾝﾄﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:12:03 N.Kasai
    '更新日：2008/05/07 (Wed) 16:55:33 N.Kojima
    '備　考：
    '　　　：2008/05/07 (Wed) 16:55:33 N.Kojima     ｿｰｽ整備。(案件№02791)
    Private Sub txtLotCommnt_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLotCommnt.Change

        Try
            
            '@=======================
            '@　ﾃｷｽﾄ変更時処理
            '@=======================
            Call pubtxtChange_Proc(txtLotCommnt, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotCommnt_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotCommnt_KeyUp
    '機　能：ｺﾒﾝﾄﾃｷｽﾄ　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 13:47:07 N.Kasai
    '更新日：2008/05/07 (Wed) 16:56:29 N.Kojima
    '備　考：
    '　　　：2008/05/07 (Wed) 16:56:29 N.Kojima     ｿｰｽ整備。(案件№02791)
    Private Sub txtLotCommnt_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtLotCommnt.KeyUp

        Try
                        
            '@=======================
            '@　ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作時処理
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtLotCommnt, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotCommnt_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：txtLotCommnt_MouseUp
    '機　能：ｺﾒﾝﾄﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 13:48:44 N.Kasai
    '更新日：2008/05/07 (Wed) 16:57:16 N.Kojima
    '備　考：
    '　　　：2008/05/07 (Wed) 16:57:16 N.Kojima     ｿｰｽ整備。(案件№02791)
    Private Sub txtLotCommnt_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtLotCommnt.MouseUp

        Try
                        
            '@=======================
            '@　ﾃｷｽﾄ変更時処理
            '@=======================
            Call pubtxtChange_Proc(txtLotCommnt, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotCommnt_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommentUp_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(ｺﾒﾝﾄ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 10:34:21 Y.Yamagishi
    '更新日：2008/05/02 (Fri) 18:31:47 N.Kojima
    '備　考：
    '　　　：2004/09/07 (Tue) 19:02:12 N.Kasai      ｺﾒﾝﾄ欄の使用可否判定追加
    '　　　：2005/11/29 (Tue) 16:05:57 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2008/05/02 (Fri) 18:31:47 N.Kojima     ｿｰｽ整備。(案件№02791)
    Private Sub cmdCommentUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCommentUp.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@ｺﾒﾝﾄが有効か
            If txtLotCommnt.Enabled = True Then
                
                '@=======================
                '@　ﾃｷｽﾄ用上ｽｸﾛｰﾙﾎﾞﾀﾝ処理
                '@=======================
                Call pubtxtCmdUp_Proc(txtLotCommnt, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdCommentUp_Click"         '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommentDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(ｺﾒﾝﾄ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 10:34:36 Y.Yamagishi
    '更新日：2008/05/02 (Fri) 18:34:07 N.Kojima
    '備　考：
    '　　　：2004/09/07 (Tue) 19:02:59 N.Kasai      ｺﾒﾝﾄ欄の使用可否判定追加
    '　　　：2005/11/29 (Tue) 16:07:17 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2008/05/02 (Fri) 18:34:07 N.Kojima     ｿｰｽ整備。(案件№02791)
    Private Sub cmdCommentDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCommentDown.Click
        
        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@ｺﾒﾝﾄが有効か
            If txtLotCommnt.Enabled = True Then
                
                '@=======================
                '@　ﾃｷｽﾄ用下ｽｸﾛｰﾙﾎﾞﾀﾝ処理
                '@=======================
                Call pubtxtCmdDown_Proc(txtLotCommnt, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdCommentDown_Click"       '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 16:43:51 T.Oide
    '更新日：2008/05/02 (Fri) 18:36:23 N.Kojima
    '備　考：
    '　　　：2005/02/23 (Wed) 10:20:58 N.Kojima     戻り先画面の判定を追加(改善№512)
    '　　　：2005/03/02 (Wed) 09:14:46 S.Deguchi    作業終了遷移構造体の初期化処理を追加
    '　　　：2008/05/02 (Fri) 18:36:23 N.Kojima     ｿｰｽ整備。(案件№02791)
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        
        Dim ltypCommonInfo           As CommonInfo
        Dim ltypWorkEndInfo          As WorkEndInfo

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
                        
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計か
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@作業終了から起動されるWF状態変更/ﾁｯﾌﾟ状態変更/特殊流動へ(から)の引継ぎ構造体の初期化
            ptypWorkEndInfo = ltypWorkEndInfo
            
            '@引継ぎ情報のｷｬﾘｱIDがNULL以外か
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@NULL以外の場合
                '治具Wafer紐付画面からの引継
                If pblnfrmxxEN02F0kbn = True Then
                    Call pubMenuSelect_Proc(CPstrKeyEN02F0)
                    Exit Sub

                '@装置別ﾛｯﾄ一覧からの引継ぎ起動か
                ElseIf pblnfrmxxEN0150Kbn = True Then
                    
                    '@=======================
                    '@　装置別ﾛｯﾄ一覧起動処理
                    '@=======================
                    Call pubMenuSelect_Proc(CPstrKeyEN0150)
                    Exit Sub
                
                '@装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧からの引継ぎ起動か
                ElseIf pblnfrmxxEN00J0Kbn = True Then

                    '@=======================
                    '@　装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧起動処理
                    '@=======================
                    Call pubMenuSelect_Proc(CPstrKeyEN00J0)
                    Exit Sub
                
                '@工程別ﾛｯﾄ一覧から引き継いで起動された場合
                ElseIf pblnfrmxxEN0200Kbn = True Then

                    '@=======================
                    '@　工程別ﾛｯﾄ一覧起動処理
                    '@=======================
                    Call pubMenuSelect_Proc(CPstrKeyEN0200)
                    Exit Sub

                End If
            End If

            '@=======================
            '@ 終了関数を実行する
            '@=======================
            Call publngEnd_Proc(CPstrKeyEN0060, ltypCommonInfo)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdClose_Click"         '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdActionDisp_Click
    '機　能：ｱｸｼｮﾝ予約確認ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 16:24:24 T.Oide
    '更新日：2008/05/07 (Wed) 10:30:06 N.Kojima
    '備　考：
    '　　　：2008/05/07 (Wed) 10:30:06 N.Kojima     ｿｰｽ整備。(案件№02791)
    Private Sub cmdActionDisp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdActionDisp.Click

        Try
       
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計か
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@=======================
            '@　ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ画面表示処理
            '@=======================
            Call prvActionList_Disp()
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdActionDisp_Click"    '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommntInput_Click
    '機　能：ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/10 (Wed) 20:49:18 T.Oide
    '更新日：2008/06/04 (Wed) 10:32:26 N.Kojima
    '備　考：
    '　　　：2005/06/06 (Mon) 17:09:19 N.Kojima     ﾛｯﾄ状態から引継ぎｷｬﾘｱを変更する処理を追加(不具合№829)
    '　　　：2005/10/25 (Tue) 08:53:02 S.Deguchi    不具合№2404の対応で,ﾌｫｰﾑｷｬﾌﾟｼｮﾝ設定を削除
    '　　　：2006/06/07 (Wed) 09:00:21 M.Miura      子画面戻りで最新取得と情報復元処理の共通化(不具合№3435)
    '　　　：2008/05/07 (Wed) 17:03:51 N.Kojima     ｿｰｽ整備。(案件№02791)
    '　　　：2008/06/04 (Wed) 10:32:26 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub cmdCommntInput_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCommntInput.Click
        
        Dim lstrTitle       As String       'ﾀｲﾄﾙ

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計か
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ﾛｯﾄｺﾒﾝﾄ画面(CM0030.frm)への引継ぎﾃﾞｰﾀ格納
            With ptypLotprestate
            
                .strLotID = lblLotID.Text                       'ﾛｯﾄID
                .strFlowClass = lblFlowClass.Text               '流動区分
                .strWfNum = lblWFNo.Text                        'WF枚数
                .strOpID = lblOpID.Text                         '大工程名
                .strStartTime = lblStartDayTime.Text            '処理開始日時
                .strPdId = lblPdID.Text                         '機種名
                .strSpecialFlg = lblS.Text                      '特殊特性ﾌﾗｸﾞ
                .strNowST = lblStatus.Text                      'ﾛｯﾄ状態
                .strStepID = lblStepID.Text                     '小工程名
                .strEngEmpName = lblLotManager.Text             'ﾛｯﾄ担当
                .strLimitTime = ptypLotprestate.strLimitTime    '制限時間
                .strWarnTime = ptypLotprestate.strWarnTime      '警告時間
                .strComments = txtLotCommnt.Text                'ｺﾒﾝﾄ
                '@↓2020/01/17 (Fri) 13:49:13 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .strGRBClass = lblGRB.Text                      'GRB
                '@↑2020/01/17 (Fri) 13:49:13 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .strLotLastUpdate = mstrLotLastUpdate           '最終更新日時
                
                '@ﾛｯﾄ状態が「後処理」か
                If lblStatus.Text = CPstrAfterProgressSt Then
                
                    '@ｱﾝﾛｰﾀﾞｰｷｬﾘｱを引き継ぎ変数に格納
                    pstrCarrierID = txtCarrier.Text
                Else
                    '@ﾛｰﾀﾞｰｷｬﾘｱを引き継ぎ変数に格納
                    pstrCarrierID = mstrRetainCarrier
                End If
                
                '@子画面起動ﾌﾗｸﾞに"True:子画面として起動"をｾｯﾄ
                pblnfrmxxCM0030Kbn = True
            
                '@起動ﾌﾗｸﾞに"False:起動処理未完"をｾｯﾄ
                pblnFormLoad = False
                
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@　ﾛｯﾄｺﾒﾝﾄ画面　起動処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM0030.Instance = New frmxxCM0030()
                
                '@=======================
                '@　機能関連情報取得処理
                '@=======================
                Call pubMenuItemCorrelation_Set(CPstrKeyEN0140, lstrTitle)

                '@ﾛｯﾄｺﾒﾝﾄ画面のﾌｫｰﾑ名称を設定する
                frmxxCM0030.Instance.Text = lstrTitle
                
                '@CM0030.frmのForm_Load処理が正常に終了したか
                If pblnFormLoad = True Then
                    '@起動処理結果：正常の場合
                    
                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    '@　ﾛｯﾄｺﾒﾝﾄ画面　表示処理
                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    frmxxCM0030.Instance.ShowDialog(Me)
                    frmxxCM0030.Instance = Nothing
                    
                Else
                    '@起動処理結果：異常の場合
                
                    '@∇∇∇∇∇∇∇∇∇∇∇
                    '@　ｱﾝﾛｰﾄﾞ処理
                    '@∇∇∇∇∇∇∇∇∇∇∇
                    frmxxCM0030.Instance = Nothing
                
                    '@起動ﾌﾗｸﾞを初期化する
                    pblnFormLoad = True
                    
                    Exit Sub
                End If

                '@=======================
                '@　作業終了画面の最新取得＆復元処理(最終更新日時判定あり)
                '@=======================
                Call prvRefresh_Disp(True)
                
            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdCommntInput_Click"   '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCollectionInfo_Click
    '機　能：装置ﾃﾞｰﾀ登録/参照ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/18 (Wed) 14:47:40 T.Kitagawa
    '更新日：2008/05/07 (Wed) 17:13:29 N.Kojima
    '備　考：
    '　　　：2004/11/04 (Thu) 10:57:52 T.Kitagawa   引継ぎ構造体を共通で使用している為、
    '　　　：                                       ｴﾗｰ時はｷｬﾘｱIDが最終的に引継ぎ構造体にｾｯﾄされてしまう件を修正
    '　　　：2005/06/06 (Mon) 16:30:59 N.Kojima     ﾛｯﾄ状態から引継ぎｷｬﾘｱを変更する処理を追加(不具合№829)
    '　　　：2005/10/25 (Tue) 08:53:02 S.Deguchi    不具合№2404の対応で,ﾌｫｰﾑｷｬﾌﾟｼｮﾝ設定を削除
    '　　　：2005/12/19 (Mon) 11:17:09 S.Deguchi    不具合№3314の対応で,装置ﾃﾞｰﾀ画面へ遷移し,戻ってきた段階で最終更新日時を比較
    '　　　：                                       し,異なる場合には,ﾛｯﾄ情報を再取得・表示するように修正
    '　　　：2006/06/07 (Wed) 09:00:21 M.Miura      子画面戻りで最新取得と情報復元処理の共通化(不具合№3435)
    '　　　：2008/05/07 (Wed) 17:13:29 N.Kojima     ｿｰｽ整備。(案件№02791)
    Private Sub cmdCollectionInfo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCollectionInfo.Click
        
        Dim lstrTitle               As String           '装置ﾃﾞｰﾀ登録/参照画面ﾀｲﾄﾙ格納用
        Dim lstrtxtWorkMemo         As String           '作業ﾒﾓ退避ｴﾘｱ
        Dim lintNextSendIndex       As Short            '送出Index
        Dim ltypOldCommonInfo       As CommonInfo       '機能間受け渡し情報格納用構造体
        Dim ltypLotprestate         As Lotprestate      'ﾛｯﾄ現在情報格納用構造体
        
        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計か
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@引継ぎ情報構造体を退避する。※当Functionの処理後に値を戻す
            ltypOldCommonInfo = ptypCommonInfo          '機能間受け渡し情報格納用構造体
            ltypLotprestate = ptypLotprestate           'ﾛｯﾄ現在情報格納用構造体


            '@★ 選択されているｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐 ★
            Select Case True
            
                '@〓 送出あり 〓
                Case optLotNextSend0.Checked 

                   lintNextSendIndex = CMlngOptLotNextSend0
                
                '@〓 送出なし 〓
                Case optLotNextSend1.Checked 

                   lintNextSendIndex = CMlngOptLotNextSend1
                
                '@〓 ﾘﾜｰｸ 〓
                Case optLotNextSend2.Checked 

                   lintNextSendIndex = CMlngOptLotNextSend2

                '@〓 追加流動 〓
                Case optLotNextSend3.Checked 
                
                   lintNextSendIndex = CMlngOptLotNextSend3
                
                '@〓 その他(選択なし) 〓
                Case Else

                   lintNextSendIndex = 9
            End Select

            '@現在入力されている作業ﾒﾓを退避
            lstrtxtWorkMemo = txtWorkMemo.Text
            
            '@引継ぎ情報格納
            With ptypCommonInfo
                .strCarrierId = txtCarrier.Text     'ｷｬﾘｱID
                .strLotID = lblLotID.Text           'ﾛｯﾄID
                .strOpID = lblOpID.Text             '大工程名
                .strStepID = lblStepID.Text         '小工程名
                .strWpID = mstrWpID                 '装置ID
                .strWpName = vbNullString           '装置名
            End With
            
            '@起動ﾌﾗｸﾞに"False:起動処理未完"をｾｯﾄ
            pblnFormLoad = False
            
            '@子画面起動ﾌﾗｸﾞに"True:子画面として起動"をｾｯﾄ
            pblnfrmxxCM00G0Kbn = True
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　装置ﾃﾞｰﾀ登録/参照画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00G0.Instance = New frmxxCM00G0()
                
            '@=======================
            '@　機能関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00T0, lstrTitle)

            '@装置ﾃﾞｰﾀ登録/参照画面のﾌｫｰﾑ名称を設定
            frmxxCM00G0.Instance.Text = lstrTitle
            
            '@起動ﾌﾗｸﾞが"False:起動処理未完"か
            If pblnFormLoad = False Then
                '@起動処理結果：異常の場合
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM00G0.Instance = Nothing
                
                '@引継ぎ情報構造体の復元
                ptypCommonInfo = ltypOldCommonInfo      '機能間受け渡し情報格納用構造体
                '@子画面起動ﾌﾗｸﾞの初期化
                pblnfrmxxCM00G0Kbn = False
                
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　装置ﾃﾞｰﾀ登録/参照画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00G0.Instance.ShowDialog(Me)
            frmxxCM00G0.Instance = Nothing
            
            '@引継ぎ情報構造体の復元
            ptypCommonInfo = ltypOldCommonInfo          '機能間受け渡し情報格納用構造体
            '@子画面起動ﾌﾗｸﾞの初期化
            pblnfrmxxCM00G0Kbn = False
            
            '@最終更新日時が更新されているか
            If mstrLotLastUpdate = ptypLotprestate.strLotLastUpdate Then
                '@更新されていない場合
                
                '@ﾛｯﾄ現在情報格納構造体を復元する
                ptypLotprestate = ltypLotprestate
            Else
                '@更新されている場合
                
                '@=======================
                '@　作業終了画面の最新取得＆復元処理
                '@=======================
                Call prvRefresh_Disp()
                
                '@装置ﾃﾞｰﾀ登録/参照ﾎﾞﾀﾝが有効か
                If cmdCollectionInfo.Enabled = True Then
                    '@装置ﾃﾞｰﾀ登録/参照ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdCollectionInfo)
                End If
            End If
            
            '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
            SendKeys.SendWait(CPstrSendKeysTab)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdCollectionInfo_Click"    '処理名
                .strErrMessage = ""                         'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTrouble_Click
    '機　能：異常処理票起案ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/12 (Thu) 16:33:14 S.Deguchi
    '更新日：2008/06/04 (Wed) 10:33:15 N.Kojima
    '備　考：
    '　　　：2005/03/03 (Thu) 10:06:56 S.Deguchi    引継の情報を保持する処理を追加
    '　　　：2005/06/06 (Mon) 17:23:35 N.Kojima     ﾛｯﾄ状態から引継ぎｷｬﾘｱを変更する処理を追加(不具合№829)
    '　　　：2006/06/07 (Wed) 09:00:21 M.Miura      子画面戻りで最新取得と情報復元処理の共通化(不具合№3435)
    '　　　：2008/05/07 (Wed) 17:57:59 N.Kojima     ｿｰｽ整備。(案件№02791)
    '　　　：2008/06/04 (Wed) 10:33:15 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub cmdTrouble_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTrouble.Click

        Dim llngCnt                 As Integer              'ｶｳﾝﾄ格納
        Dim lstrTitle               As String               'ﾀｲﾄﾙ
        Dim ltypExcpConnectList     As ExcpConnectList      '異常処理登録/表示引継ぎ構造体初期化用

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
 
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計か
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@子画面起動ﾌﾗｸﾞに"True:子画面として起動"をｾｯﾄ
            pblnfrmxxCM00I0Kbn = True
            
            '@起動ﾌﾗｸﾞに"False:起動処理未完"をｾｯﾄ
            pblnFormLoad = False

            '@異常処理登録/表示引継ぎ構造体を初期化する
            ptypExcpConnectList = New ExcpConnectList()
            
            '@引継ぎ情報格納
            With ptypExcpConnectList.typLotList
                llngCnt = 1
                .lngBatLotListCnt = 1                                       'ﾛｯﾄ数(=1)
                .strBatchId = vbNullString                                  'ﾊﾞｯﾁID(=Null)
                .strWpID = ptypLotprestate.strWpID                          '装置ID
                .strWpName = ptypLotprestate.strWpName                      '装置名
                .strRecipeId = vbNullString                                 'ﾚｼﾋﾟID(=Null)
                
                '@領域を確保
                If .typBatList Is Nothing Then 
                   .typBatList = New List(Of BatList) 
                Else 
                   .typBatList.Clear()
                End If
                
                Dim typBatListmp As BatList = New BatList()

                '@領域へ情報をｾｯﾄする
                typBatListmp.strLotID = lblLotID.Text                  'ﾛｯﾄID
                typBatListmp.strFlowClass = lblFlowClass.Text          '種別
                typBatListmp.strWFQuantity = lblWFNo.Text              '数量
                typBatListmp.strOpID = lblOpID.Text                    '大工程
                typBatListmp.strStepID = lblStepID.Text                '小工程
                typBatListmp.strPdId = lblPdID.Text                    '機種
                typBatListmp.strSpecialFlag = lblS.Text                '特殊特性
                typBatListmp.strStartTime = lblStartDayTime.Text       '処理開始日時
                typBatListmp.strCurrentStatusName = lblStatus.Text     '状態
                typBatListmp.strEngEmpName = lblLotManager.Text        'ﾛｯﾄ担当
                typBatListmp.strLimitTime = lblTimeLimit.Text          '時間制約
                typBatListmp.strLotLastUpdate = mstrLotLastUpdate      '最終更新日時
                .typBatList.Add(typBatListmp)
                
                '@ﾛｯﾄ状態が「後処理」か
                If lblStatus.Text = CPstrAfterProgressSt Then
                    
                    '@ｱﾝﾛｰﾀﾞｰｷｬﾘｱを格納する
                    typBatListmp.strCarrierId = txtCarrier.Text
                Else
                    '@ﾛｰﾀﾞｰｷｬﾘｱを格納する
                    typBatListmp.strCarrierId = mstrRetainCarrier
                End If
            End With

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　工程異常/不適合品処理票登録画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00I0.Instance = New frmxxCM00I0()
            
            '@=======================
            '@　機能関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00U0, lstrTitle)

            '@工程異常/不適合品処理票登録画面のﾌｫｰﾑ名称を設定
            frmxxCM00I0.Instance.Text = lstrTitle
            
            '@起動ﾌﾗｸﾞが"False:起動処理未完"か
            If pblnFormLoad = False Then
                '@起動処理結果：異常の場合
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM00I0.Instance = Nothing
                
                '@異常処理登録/表示引継ぎ構造体を初期化する
                ptypExcpConnectList = ltypExcpConnectList
                '@子画面起動ﾌﾗｸﾞの初期化
                pblnfrmxxCM00I0Kbn = False

                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　工程異常/不適合品処理票登録画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00I0.Instance.ShowDialog(Me)
            frmxxCM00I0.Instance = Nothing
            
            '@異常処理登録/表示引継ぎ構造体を初期化する
            ptypExcpConnectList = ltypExcpConnectList
            '@子画面起動ﾌﾗｸﾞの初期化
            pblnfrmxxCM00I0Kbn = False
            
            '@=======================
            '@　作業終了画面の最新取得＆復元処理
            '@=======================
            Call prvRefresh_Disp()
            
            '@異常処理票起案ﾎﾞﾀﾝが有効か
            If cmdTrouble.Enabled = True Then
                '@異常処理票起案ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                Call pubSetFocus(cmdTrouble)
                AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
            End If
            
            '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
            RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
            SendKeys.SendWait(CPstrSendKeysTab)
            AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdTrouble_Click"       '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTreatWF_Click
    '機　能：WF状態変更ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 10:11:11 T.Oide
    '更新日：2008/05/07 (Wed) 18:08:11 N.Kojima
    '備　考：
    '　　　：2005/02/24 (Thu) 16:08:51 S.Deguchi    不具合№352/561対応で引継構造体処理を追加
    '　　　：2005/05/20 (Fri) 08:44:54 S.Deguchi    不具合№640他対応で特殊流動最終工程時にﾒｯｾｰｼﾞを出すように処理追加(暫定)
    '　　　：2005/06/06 (Mon) 16:29:21 N.Kojima     ﾛｯﾄ状態から引継ぎｷｬﾘｱを変更する処理を追加(不具合№829)
    '　　　：2006/06/07 (Wed) 09:00:21 M.Miura      子画面戻りで最新取得と情報復元処理の共通化(不具合№3539)
    '　　　：2006/11/14 (Tue) 11:41:29 N.Kasai      WF廃棄機能追加(№01595)
    '　　　：2008/05/07 (Wed) 18:08:11 N.Kojima     ｿｰｽ整備。(案件№02791)
    Private Sub cmdTreatWF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTreatWF.Click

        Dim lstrTitle           As String           'WF状態変更登録画面ﾀｲﾄﾙ用
        Dim lstrSelect          As String           '画面ﾒｯｾｰｼﾞ用変数
        Dim ltypOldCommonInfo   As CommonInfo       '機能間受け渡し情報格納用構造体
        
        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計か
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@ﾘﾜｰｸ中(特殊流動状態判定ﾌﾗｸﾞが"0"以外)で、かつﾘﾜｰｸ最終工程(ﾘﾜｰｸ最終工程判断ﾌﾗｸﾞが"1")か。
            '@　※退避していたﾓｼﾞｭｰﾙ変数から判断
            If mstrReworkKind <> CMstrReworkKind0 And _
                mstrReworkKind <> CMstrReworkKind3 And _
                mstrReworkFinishFlag = CMstrReworkFinishFlag1 Then
            
                '@特殊流動ﾌﾗｸﾞが"1:ﾘﾜｰｸ中"か
                If mstrReworkFlag = CMstrReworkFlag1 Then
                    
                    '@画面ﾒｯｾｰｼﾞ用変数に"ﾘﾜｰｸ"をｾｯﾄ
                    lstrSelect = CMstrMsgSpecialR
                
                Else
                    '@特殊流動ﾌﾗｸﾞが"2:追加流動中"か
                    If mstrReworkFlag = CMstrReworkFlag2 Then
                    
                        '@画面ﾒｯｾｰｼﾞ用変数に"追加流動"をｾｯﾄ
                        lstrSelect = CMstrMsgSpecialA
                    End If
                End If
                
                '@=======================
                '@　機能関連情報取得処理
                '@=======================
                Call pubMenuItemCorrelation_Set(CPstrKeyEN0180, lstrTitle)
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005T, lstrSelect, lstrTitle)
                '@ﾒｯｾｰｼﾞ表示："<TRM5TW>$$[%1]の最終工程で[%2]できません。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Exit Sub
            End If
            
            
            '@***********************
            '@　特殊流動中ではない場合
            '@***********************
            
            '@機能間受け渡し情報格納用構造体を退避構造体に格納
            ltypOldCommonInfo = ptypCommonInfo
            
            '@引継ぎ情報格納①
            With ptypCommonInfo
            
                '@ﾛｯﾄ状態が「後処理」か
                If lblStatus.Text = CPstrAfterProgressSt Then
                
                    '@ｱﾝﾛｰﾀﾞｰｷｬﾘｱを格納
                    .strCarrierId = txtCarrier.Text
                Else
                    '@ﾛｰﾀﾞｰｷｬﾘｱを格納
                    .strCarrierId = mstrRetainCarrier
                End If
                
                .strDivision = vbNullString         '起動区分：NULL
                .strLotID = vbNullString            'ﾛｯﾄID：NULL
                .strOpID = vbNullString             '大工程：NULL
                .strStepID = vbNullString           '小工程：NULL
                .strWpID = vbNullString             '装置ID：NULL
                .strWpName = vbNullString           '装置名：NULL
            End With


            '@作業終了<=>WF状態変更/ﾁｯﾌﾟ状態変更/特殊流動 引継ぎ構造体の初期化
            ptypWorkEndInfo = New WorkEndInfo()
            
            '@引継ぎ情報格納②
            With ptypWorkEndInfo
            
                '@ﾛｯﾄ状態が「後処理」か
                If lblStatus.Text = CPstrAfterProgressSt Then
                    
                    '@ｱﾝﾛｰﾀﾞｰｷｬﾘｱを格納
                    .strCarrierId = txtCarrier.Text
                Else
                    '@ﾛｰﾀﾞｰｷｬﾘｱを格納
                    .strCarrierId = mstrRetainCarrier
                End If
                
                .strLotID = lblLotID.Text               'ﾛｯﾄID
                .strfrmxxKbn = CPstrKeyEN0180           '子画面の機能ID
            End With
            
            '@起動ﾌﾗｸﾞに"False:起動処理未完"をｾｯﾄ
            pblnFormLoad = False
            
            '@子画面起動ﾌﾗｸﾞに"True:子画面として起動"をｾｯﾄ
            pblnfrmxxCM0070Kbn = True

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　WF状態変更登録画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0070.Instance = New frmxxCM0070()
            
            '@=======================
            '@　機能関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0180, lstrTitle)
            
            '@WF状態変更登録画面のﾌｫｰﾑ名称を設定
            frmxxCM0070.Instance.Text = lstrTitle
            
            '@起動ﾌﾗｸﾞが"False:起動処理未完"か
            If pblnFormLoad = False Then
                '@起動処理結果：異常の場合
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM0070.Instance = Nothing
                
                '@引継ぎ情報構造体の復元
                ptypCommonInfo = ltypOldCommonInfo      '機能間受け渡し情報格納用構造体
                '@子画面起動ﾌﾗｸﾞの初期化
                pblnfrmxxCM0070Kbn = False
                
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　WF状態変更登録画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0070.Instance.ShowDialog(Me)
            frmxxCM0070.Instance = Nothing

            '@引継ぎ情報構造体の復元
            ptypCommonInfo = ltypOldCommonInfo          '機能間受け渡し情報格納用構造体
            '@子画面起動ﾌﾗｸﾞの初期化
            pblnfrmxxCM0070Kbn = False

            '@最終更新日を書き換える
            mstrLotLastUpdate = ptypLotprestate.strLotLastUpdate
            

            With ptypWorkEndInfo
                
                '@★ 作業ﾌﾗｸﾞ(0:処理なし/1:ﾁｯﾌﾟ/2:WF移載/3:ﾛｯﾄ終了)により処理分岐 ★
                Select Case .strWorkKbn
                
                    '@〓 2:移載 〓
                    Case CMstrLotEventMove
                        
                        '@=======================
                        '@　作業終了画面の最新取得＆復元処理
                        '@=======================
                        Call prvRefresh_Disp()
                        
                        '@ﾁｯﾌﾟ状態変更ﾎﾞﾀﾝが有効か
                        If cmdTreatChip.Enabled = True Then
                            '@ﾁｯﾌﾟ状態変更ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdTreatChip)
                        End If

                        Exit Sub
                    
                    
                    '@〓 3:ﾛｯﾄｱｳﾄ 〓
                    Case CMstrLotEventLotOut

                        '@ｷｬﾘｱIDを初期化する(画面情報を初期化する)
                        txtCarrier.Text = vbNullString

                        Exit Sub
                    
                    
                    '@〓 4:WF廃棄 〓
                    Case CMstrLotEventWfScrap

                        '@特に制御なしだが、明示的に記述しておきます。
                    
                    
                    '@〓 その他 〓
                    Case Else

                        '@特に制御なしだが、明示的に記述しておきます。

                End Select
            End With
            
            '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
            SendKeys.SendWait(CPstrSendKeysTab)
            
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdTreatWF_Click"       '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTreatChip_Click
    '機　能：ﾁｯﾌﾟ状態変更ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/23 (Tue) 15:20:11 T.Kitagawa
    '更新日：2008/05/07 (Wed) 18:28:57 N.Kojima
    '備　考：
    '　　　：2004/09/29 (Wed) 20:55:34 Y.Yamagishi　最終更新日時書き換えの為、ｷｬﾘｱIDValidateを呼ぶ(不具合改善№914)
    '　　　：2004/11/04 (Thu) 11:03:54 T.Kitagawa　 引継ぎ構造体を共通で使用している為、ｴﾗｰ時はｷｬﾘｱIDが最終的に引継ぎ構造体にｾｯﾄされてしまう件を修正
    '　　　：2005/05/20 (Fri) 08:44:54 S.Deguchi    不具合№640他対応で特殊流動最終工程時にﾒｯｾｰｼﾞを出すように処理追加(暫定)
    '　　　：2005/06/06 (Mon) 11:17:18 N.Kojima     ﾛｯﾄ状態から引継ぎｷｬﾘｱを変更する処理を追加(不具合№829)
    '　　　：2005/08/05 (Fri) 16:00:15 N.Kasai      引数を判定してﾁｯﾌﾟ状態変更画面のﾌｫｰﾑｷｬﾌﾟｼｮﾝを変更
    '　　　：2006/06/07 (Wed) 09:00:21 M.Miura      子画面戻りで最新取得と情報復元処理の共通化(不具合№3539)
    '　　　：2008/05/07 (Wed) 18:28:57 N.Kojima     ｿｰｽ整備。(案件№02791)
    '　　　：2008/06/26 (Thu) 09:34:04 T.Sawaguchi　ﾁｯﾌﾟ状態変更画面からﾛｯﾄｺﾒﾝﾄ画面を起動し登録した時のLAST_UPDATE更新不具合対応(案件No3027)
    Private Sub cmdTreatChip_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTreatChip.Click

        Dim lstrTitle           As String           'ﾁｯﾌﾟ状態変更登録画面ﾀｲﾄﾙ用
        Dim lstrSelect          As String           '画面ﾒｯｾｰｼﾞ用変数
        Dim lstrFunctionKey     As String           'ﾒﾆｭｰKey格納
        Dim ltypOldCommonInfo   As CommonInfo       '機能間受け渡し情報格納用構造体
        
        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計か
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@★ 起動引数により処理分岐 ★
            Select Case pstrTerminalMode
            
                '@〓 M:工程管理 〓
                Case CPstrManufactureStatus
                    
                    '@機能IDに"EN0190:ﾁｯﾌﾟ状態変更登録"を格納
                    lstrFunctionKey = CPstrKeyEN0190
                
                '@〓 その他 〓
                Case Else
                    
                    '@機能IDに"EN01Q0:ﾁｯﾌﾟ状態変更登録(上書き)"を格納
                    lstrFunctionKey = CPstrKeyEN01Q0

            End Select
            
            '@ﾘﾜｰｸ中(特殊流動状態判定ﾌﾗｸﾞが"0"以外)で、かつﾘﾜｰｸ最終工程(ﾘﾜｰｸ最終工程判断ﾌﾗｸﾞが"1")か。
            '@　※退避していたﾓｼﾞｭｰﾙ変数から判断
            If mstrReworkKind <> CMstrReworkKind0 And _
                mstrReworkKind <> CMstrReworkKind3 And _
                mstrReworkFinishFlag = CMstrReworkFinishFlag1 Then
                
                '@特殊流動ﾌﾗｸﾞが"1:ﾘﾜｰｸ中"か
                If mstrReworkFlag = CMstrReworkFlag1 Then
                    
                    '@画面ﾒｯｾｰｼﾞ用変数に"ﾘﾜｰｸ"をｾｯﾄ
                    lstrSelect = CMstrMsgSpecialR
                
                Else
                    '@特殊流動ﾌﾗｸﾞが"2:追加流動中"か
                    If mstrReworkFlag = CMstrReworkFlag2 Then
                    
                        '@画面ﾒｯｾｰｼﾞ用変数に"追加流動"をｾｯﾄ
                        lstrSelect = CMstrMsgSpecialA
                    End If
                End If
                
                '@=======================
                '@　機能関連情報取得処理
                '@=======================
                Call pubMenuItemCorrelation_Set(lstrFunctionKey, lstrTitle)
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005T, lstrSelect, lstrTitle)
                '@ﾒｯｾｰｼﾞ表示："<TRM5TW>$$[%1]の最終工程で[%2]できません。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Exit Sub
            End If
            
            '@機能間受け渡し情報格納用構造体の退避
            ltypOldCommonInfo = ptypCommonInfo
            
            '@引継ぎ情報格納①
            With ptypCommonInfo
            
                '@ﾛｯﾄ状態が「後処理」か
                If lblStatus.Text = CPstrAfterProgressSt Then
                
                    '@ｱﾝﾛｰﾀﾞｰｷｬﾘｱを格納
                    .strCarrierId = txtCarrier.Text
                Else
                    '@ﾛｰﾀﾞｰｷｬﾘｱを格納
                    .strCarrierId = mstrRetainCarrier
                End If
                
                .strDivision = vbNullString         '起動区分：NULL
                .strLotID = vbNullString            'ﾛｯﾄID：NULL
                .strOpID = vbNullString             '大工程：NULL
                .strStepID = vbNullString           '小工程：NULL
                .strWpID = vbNullString             '装置ID：NULL
                .strWpName = vbNullString           '装置名：NULL
            End With
            
            
            '@作業終了<=>WF状態変更/ﾁｯﾌﾟ状態変更/特殊流動 引継ぎ構造体の初期化
            ptypWorkEndInfo = New WorkEndInfo()
            
            '@引継ぎ情報格納②
            With ptypWorkEndInfo
            
                '@ﾛｯﾄ状態が「後処理」か
                If lblStatus.Text = CPstrAfterProgressSt Then
                    
                    '@ｱﾝﾛｰﾀﾞｰｷｬﾘｱを格納
                    .strCarrierId = txtCarrier.Text
                Else
                    '@ﾛｰﾀﾞｰｷｬﾘｱを格納
                    .strCarrierId = mstrRetainCarrier
                End If
                
                .strLotID = lblLotID.Text            'ﾛｯﾄID
                .strfrmxxKbn = lstrFunctionKey          '子画面の機能ID
            End With
            
            '@起動ﾌﾗｸﾞに"False:起動処理未完"をｾｯﾄ
            pblnFormLoad = False
            
            '@子画面起動ﾌﾗｸﾞに"True:子画面として起動"をｾｯﾄ
            pblnfrmxxCM0080Kbn = True
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　ﾁｯﾌﾟ状態変更登録画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0080.Instance = New frmxxCM0080()
                    
            '@起動ﾌﾗｸﾞが"False:起動処理未完"か
            If pblnFormLoad = True Then
                '@起動処理結果：正常の場合
                
                '@=======================
                '@　機能関連情報取得処理
                '@=======================
                Call pubMenuItemCorrelation_Set(lstrFunctionKey, lstrTitle)
            
                '@ﾁｯﾌﾟ状態変更登録画面のﾌｫｰﾑ名称を設定
                frmxxCM0080.Instance.Text = lstrTitle
            
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@　ﾁｯﾌﾟ状態変更登録画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM0080.Instance.ShowDialog(Me)
                frmxxCM0080.Instance = Nothing
            
                '@引継ぎ情報構造体の復元
                ptypCommonInfo = ltypOldCommonInfo

                '@子画面起動ﾌﾗｸﾞの初期化
                pblnfrmxxCM0080Kbn = False
                
            Else
                '@起動処理結果：異常の場合
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM0080.Instance = Nothing
                
                '@引継ぎ情報構造体の復元
                ptypCommonInfo = ltypOldCommonInfo
                '@子画面起動ﾌﾗｸﾞの初期化
                pblnfrmxxCM0080Kbn = False
                
                Exit Sub
            End If

            '@ﾁｯﾌﾟ状態変更登録から戻ってきたときに、ｽﾃｰﾀｽﾊﾞｰにﾒｯｾｰｼﾞを表示する
            Call pubVsfInfo_Disp(pstrStatusberMSG)
                

            With ptypWorkEndInfo
            
                '@★ 作業ﾌﾗｸﾞ(0:処理なし/1:ﾁｯﾌﾟ/2:WF移載/3:ﾛｯﾄ終了)により処理分岐 ★
                Select Case .strWorkKbn
                    
                    '@〓 1:ﾁｯﾌﾟ or 2:移載 〓
                    Case CMstrLotEventChip, CMstrLotEventMove
                        
                        '@=======================
                        '@　作業終了画面の最新取得＆復元処理
                        '@=======================
                        Call prvRefresh_Disp()
                        
                        '@ﾁｯﾌﾟ状態変更ﾎﾞﾀﾝが有効か
                        If cmdTreatChip.Enabled = True Then
                            '@ﾁｯﾌﾟ状態変更ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdTreatChip)
                        End If
                                    
                    
                    '@〓 3:ﾛｯﾄｱｳﾄ 〓
                    Case CMstrLotEventLotOut

                        '@ｷｬﾘｱIDを初期化(画面情報を初期化する)
                        txtCarrier.Text = vbNullString
                        
                        Exit Sub
                        
                        
                    '@〓 その他 〓
                    Case Else
                        
                        '@処理なし

                End Select
            End With

        '@↓2008/06/26 (Thu) 09:31:56 T.Sawaguchi 案件03027 **************************
            '@=======================
            '@　作業終了画面の最新取得＆復元処理
            '@=======================
            Call prvRefresh_Disp()
        '@↑2008/06/26 (Thu) 09:31:56 T.Sawaguchi 案件03027 **************************

            RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
            '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
            SendKeys.SendWait(CPstrSendKeysTab)
            AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdTreatChip_Click"     '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@***********************************************************************************************************
    '@　2008/05/07　R5-02でここまでｿｰｽ整備。この記述を発見した人は、この行以降のｿｰｽ整備を行なってください(by kojima)
    '@***********************************************************************************************************

    '関数名：cmdTpalCombRegist_Click
    '機　能：TPAL貼り合せ登録ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/03 (Fri) 18:57:36 N.Kojima
    '更新日：2006/06/07 (Wed) 09:00:21 M.Miura
    '備　考：
    '　　　：2005/01/07 (Fri) 10:54:32 S.Deguchi    初期化処理を追加
    '　　　：2005/01/14 (Fri) 11:22:47 H.Wajima     ptypCommonInfoの設定処理を追加
    '　　　：2005/06/06 (Mon) 17:10:36 N.Kojima     ﾛｯﾄ状態から引継ぎｷｬﾘｱを変更する処理を追加(不具合№829)
    '　　　：2006/06/07 (Wed) 09:00:21 M.Miura      子画面戻りで最新取得と情報復元処理の共通化(不具合№3435)
    Private Sub cmdTpalCombRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTpalCombRegist.Click

        Dim ltypOldCommonInfo       As CommonInfo       '機能間受け渡し情報格納用構造体
        Dim ltypCfkiRenkeiInfo      As CfkiRenkeiInfo   '初期化用構造体
        
        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@ﾌｫｰﾑ起動区分設定
            pblnfrmxxEN01A0Kbn = True
            
            '@起動ﾌﾗｸﾞの初期化
            pblnFormLoad = False

            '@引継ぎ構造体の退避
            ltypOldCommonInfo = ptypCommonInfo
            
            '@子ﾌｫｰﾑの表示情報を変数に格納
            With ptypCommonInfo
                '@ﾛｯﾄ状態が「後処理」の場合
                If lblStatus.Text = CPstrAfterProgressSt Then
                    '@Unloader側ｷｬﾘｱ
                    .strCarrierId = txtCarrier.Text
                Else
                    '@「処理中」の場合
                    '@Loader側ｷｬﾘｱ
                    .strCarrierId = mstrRetainCarrier
                End If
                
                .strDivision = vbNullString
                .strLotID = vbNullString
                .strOpID = vbNullString
                .strStepID = vbNullString
                .strWpID = vbNullString
                .strWpName = vbNullString
            End With
            
            With ptypCfkiRenkeiInfo
                '@ﾛｯﾄ状態が「後処理」の場合
                If lblStatus.Text = CPstrAfterProgressSt Then
                    '@Unloader側ｷｬﾘｱ
                    .strCarrierId = txtCarrier.Text
                Else
                    '@「処理中」の場合
                    '@Loader側ｷｬﾘｱ
                    .strCarrierId = mstrRetainCarrier
                End If
            End With
            
            '@子画面をﾛｰﾄﾞ
            frmxxEN01A0.Instance = New frmxxEN01A0()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxEN01A0.Instance = Nothing
                
                '@引継構造体の内容を戻す
                ptypCommonInfo = ltypOldCommonInfo
                ptypCfkiRenkeiInfo = New CfkiRenkeiInfo()
                pblnfrmxxEN01A0Kbn = False
                
                Exit Sub
            End If
            
            '@TPAL貼り合せ登録画面表示
            frmxxEN01A0.Instance.ShowDialog(Me)
            frmxxEN01A0.Instance = Nothing
            
            '@起動ﾌﾗｸﾞを戻す
            pblnFormLoad = True
            
            With ptypCfkiRenkeiInfo
                '@最終更新日時の判定
                If .strLotLastUpdate <> vbNullString Then
                    '@空白以外の場合

                    '@作業終了画面の最新取得と復元
                    Call prvRefresh_Disp()
            
                    '@TPAL貼り合せﾎﾞﾀﾝが有効な場合
                    If cmdTpalCombRegist.Enabled = True Then
                        '@TPAL貼り合せﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdTpalCombRegist)
                        '@次項目にﾌｫｰｶｽｾｯﾄ
                        SendKeys.SendWait(CPstrSendKeysTab)
                    Else
                        '@確定ﾎﾞﾀﾝが有効な場合
                        If cmdRegist.Enabled = True Then
                            '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdRegist)
                        End If
                    End If
                Else
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If
            End With
            
            '@引継ぎｷｬﾘｱ情報の復元
            ptypCommonInfo = ltypOldCommonInfo
            ptypCfkiRenkeiInfo = ltypCfkiRenkeiInfo
            
            '@ﾌｫｰﾑ起動区分にFalse(次ﾌｫｰﾑ起動)を設定
            pblnfrmxxEN01A0Kbn = False
            
        '@↓2009/07/03 (Fri) 16:44:00 Y.Yoneyama **************************************************
            '@作業終了画面の最新取得＆復元処理
            Call prvRefresh_Disp()
        '@↑2009/07/03 (Fri) 16:44:00 Y.Yoneyama **************************************************
                
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdTpalCombRegist_Click"    '処理名
                .strErrMessage = ""                         'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCFKIWorkEnd_Click
    '機　能：CFKI作業指示書入力
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 13:21:13 S.Deguchi
    '更新日：2006/06/07 (Wed) 09:00:21 M.Miura
    '備　考：
    '　　　：2004/08/26 (Thu) 14:27:52 N.Kasai　    CFKI作業終了実行可能ﾌﾗｸﾞ判定対応
    '　　　：2004/08/26 (Thu) 19:57:43 M.Miura　    次工程送出ｺﾝﾎﾞから次工程ｵﾌﾟｼｮﾝﾎﾞﾀﾝに変更
    '　　　：2004/09/28 (Tue) 20:37:09 N.Kojima　   CFKI作業終了確定後、確定ﾎﾞﾀﾝにﾌｫｰｶｽをｾｯﾄする。(不具合№974)
    '　　　：2005/01/19 (Wed) 12:57:41 S.Deguchi    対向基板処置登録でﾛｯﾄｱｳﾄしている場合の処理を追加
    '　　　：2005/03/03 (Thu) 09:13:13 S.Deguchi    CFKI引継構造体を使用する前に初期化する処理を追加
    '　　　：2005/06/06 (Mon) 17:05:15 N.Kojima     ﾛｯﾄ状態から引継ぎｷｬﾘｱを変更する処理を追加(不具合№829)
    '　　　：2006/06/07 (Wed) 09:00:21 M.Miura      子画面戻りで最新取得と情報復元処理の共通化(不具合№3435)
    Private Sub cmdCFKIWorkEnd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCFKIWorkEnd.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@ﾌｫｰﾑ起動区分設定
            pblnfrmxxCM00A0Kbn = True
            
            '@ﾊﾟﾌﾞﾘｯｸ構造体を使用する前に初期化
            ptypCfkiRenkeiInfo = New CfkiRenkeiInfo ()
            
            With ptypCfkiRenkeiInfo
                '@ﾛｯﾄ状態が「後処理」の場合
                If lblStatus.Text = CPstrAfterProgressSt Then
                    '@Unloader側ｷｬﾘｱ
                    .strCarrierId = txtCarrier.Text
                Else
                    '@「処理中」の場合
                    '@Loader側ｷｬﾘｱ
                    .strCarrierId = mstrRetainCarrier
                End If

                '@Form_Loadﾌﾗｸﾞの初期化
                pblnFormLoad = False
                 
                '@子画面をﾛｰﾄﾞ
                frmxxCM00A0.Instance = New frmxxCM00A0()
                 
                '@Form_Loadﾌﾗｸﾞが異常の場合
                If pblnFormLoad = False Then
                    '@異常の場合は子画面終了
                    frmxxCM00A0.Instance = Nothing
                    
                    '@ﾌｫｰﾑ起動区分設定(戻し)
                    pblnfrmxxCM00A0Kbn = False
                    
                    '@ﾊﾟﾌﾞﾘｯｸ構造体を初期化する
                    ptypCfkiRenkeiInfo = New CfkiRenkeiInfo ()
                    
                    Exit Sub
                End If
                
                '@対向基板特殊流動不良画面表示
                frmxxCM00A0.Instance.ShowDialog(Me)
                frmxxCM00A0.Instance = Nothing
                
                '@ﾌｫｰﾑ起動区分設定
                pblnfrmxxCM00A0Kbn = False
                
                '@最終更新日時の判定
                If .strLotLastUpdate <> vbNullString Then
                    '@空白以外の場合
                    
                    '@作業終了画面の最新取得と復元
                    Call prvRefresh_Disp()
                    
                    '@CFKI作業終了入力ﾎﾞﾀﾝが有効な場合
                    If cmdCFKIWorkEnd.Enabled = True Then
                        '@CFKI作業終了入力ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdCFKIWorkEnd)
                        '@次項目にﾌｫｰｶｽｾｯﾄ
                        SendKeys.SendWait(CPstrSendKeysTab)
                    Else
                        '@確定ﾎﾞﾀﾝが有効な場合
                        If cmdRegist.Enabled = True Then
                            '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdRegist)
                        End If
                    End If
                Else
                    '@ﾛｯﾄｱｳﾄ処置
                    
                    '@画面初期化
                    Call prvfrmxxEN0060_Init()
                    
                    txtCarrier.Text = vbNullString
                    
                    '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdCFKIWorkEnd_Click"   '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdODF_Click
    '機　能：ODF貼り合せ登録
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/17 (Tue) 10:16:55 N.Kasai
    '更新日：2006/06/08 (Thu) 09:38:19 M.Miura
    '備　考：
    '　　　：2005/06/09 (Thu) 17:20:38 N.Kojima     Loader/Unloader対応(不具合№829)
    '　　　：2006/01/17 (Tue) 17:56:00 N.Kasai      貼り合せ済みﾌﾗｸﾞ追加
    '　　　：2006/02/21 (Tue) 15:34:04 N.Kasai      最終更新日時再取得
    '　　　：2006/06/08 (Thu) 09:38:19 M.Miura      子画面戻りで最新取得と情報復元処理の共通化(不具合№3435)
    Private Sub cmdODF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdODF.Click
                
        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@ODF引継ぎ項目取得
            With ptypOdfInfo
                '@ﾛｯﾄ状態が「後処理」の場合
                If lblStatus.Text = CPstrAfterProgressSt Then
                    .strUnloaderCarrier = txtCarrier.Text               'TFTｷｬﾘｱID
                    .strLoaderCarrier = ptypLotprestate.strCarrierId    'TFTｷｬﾘｱID
                Else
                    '@「処理中」の場合
                    .strUnloaderCarrier = ptypLotprestate.strCarrierId  'TFTｷｬﾘｱID
                    .strLoaderCarrier = txtCarrier.Text                 'TFTｷｬﾘｱID
                End If
                
                .strLotID = ptypLotprestate.strLotID                'TFTﾛｯﾄID
                .strFlowClass = ptypLotprestate.strFlowClass        '種別
                .strPdId = ptypLotprestate.strPdId                  '機種
                .strStatus = ptypLotprestate.strNowST               '状態
                .strWfNum = ptypLotprestate.strWfNum                '数量(WF)
                .strChipNum = ptypLotprestate.strChipQuantity      '数量(CHIP)
                .strCFCarrierID = ptypLotprestate.strCFCarrierID   'CFｷｬﾘｱID
                .strWpID = ptypLotprestate.strWpID
                .strOdfCoverFixFlag = ptypLotprestate.strCoverFlag  'ODF貼り合せ済みﾌﾗｸﾞ
            End With
                
            '@子画面をﾛｰﾄﾞ
            frmxxCM00U0.Instance = New frmxxCM00U0()
             
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM00U0.Instance = Nothing
                Exit Sub
            End If
            
            '@ODF貼り合せ画面表示
            frmxxCM00U0.Instance.ShowDialog(Me)
            frmxxCM00U0.Instance = Nothing
                
            '@作業終了画面の最新取得と復元
            Call prvRefresh_Disp()
            
            '@ODF貼り合せ登録ﾎﾞﾀﾝが有効な場合
            If cmdODF.Enabled = True Then
                '@ｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(cmdODF)
                '@次項目にﾌｫｰｶｽｾｯﾄ
                SendKeys.SendWait(CPstrSendKeysTab)
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdODF_Click"           '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：作業終了確定
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/10 (Wed) 13:35:13 T.Oide
    '更新日：2018/03/05 (Mon) 10:21:14 T.Oide
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnInputCheck              As Boolean              '画面入力ﾁｪｯｸ(True:正常,False:異常)
        Dim lblnAns                     As Boolean              '結果取得(True:正常,False:異常)
        Dim lblnAnsNextSend             As Boolean              '次工程取得結果格納
        Dim ltypLotwrkend               As LotwrkEnd            'ﾛｯﾄ作業終了構造体
        Dim llngCnt                     As Integer              '汎用ｶｳﾝﾀ
        Dim lstrClassDivision           As String               '処理区分格納
        Dim lstrActionFlag              As String               'ｱｸｼｮﾝ予約実行ﾌﾗｸﾞ(0:実行なし、1:停止、２:保留)
        Dim lblnReworkFlag              As Boolean              '特殊流動ﾌﾗｸﾞ(True：特殊流動可、False：特殊流動不可)
        Dim ltypLotCfEnd                As LotCfEnd             'CFﾛｯﾄ終了要求構造体
        Dim lstrResultReworkState       As String               '特殊流動状態(3桁で制御
                                                                '    百の位：0；特殊流動無/1；部分特殊流動/2;全数特殊流動
                                                                '    十の位：0；分割元の次工程無/1；分割元の次工程有
                                                                '    一の位：0；分割先(or全数)の次工程無/1；分割先(or全数)の次工程有)
        Dim lstrResultRework1           As String               '特殊流動状態の百の位
        Dim lstrResultRework2           As String               '特殊流動状態の十の位
        Dim lstrResultRework3           As String               '特殊流動状態の一の位
        Dim lblnNextFlag                As String               '次工程送出ﾌﾗｸﾞ(True：送出可、False：送出不可)
        Dim lstrFoldFlag                As String               '保留ﾌﾗｸﾞ
        Dim lstrMoveResult              As String               '移載状態(0：移載なし、1：移載前、2：移載完了)
        Dim lstrNextActionFlag          As String               '次工程ｱｸｼｮﾝ予約実行ﾌﾗｸﾞ(0:実行なし、1:停止、２:保留)
        Dim lstrSendResult              As String               '次工程送出結果格納(Null:次工程送出/0:中間在庫/1:完成在庫/2:組立送品)
        Dim lstrToCarrierID             As String               '特殊流動分割元ｷｬﾘｱID
        Dim lstrMsg3                    As String               'ﾒｯｾｰｼﾞ内容
        Dim lblnCtlAns                  As Boolean              'CtlSvr2結果取得(True:正常,False:異常)
        Dim ltypCtlUpdWaitingLotList    As CtlUpWaitingLot      'CtlSvr2送信構造体
        Dim ltypSpcJudge                As SpcJudge             'SPC規格値判定構造体
        Dim lblnSpcSpecchkAns           As Boolean              'SPC規格値判定結果
        Dim lstrGuidMsg                 As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode             As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance            As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg
        Dim lblnMsgFlag                 As Boolean              'ﾒｯｾｰｼﾞ重複ﾁｪｯｸﾌﾗｸﾞ(True：既に表示/False：既表示無)
        Dim lstrFTPResult               As String               'FTPﾃﾞｰﾀ登録結果判定用変数
        Dim lstrTftHoldFlag             As String               'TFT保留ﾌﾗｸﾞ
        Dim lblnDataCheck               As Boolean              '装置ﾃﾞｰﾀ登録済みﾁｪｯｸ(True:正常,False:異常)
        Dim lblnCM00X0DispFlag          As Boolean              '処理中ﾌｫｰﾑ表示ﾌﾗｸﾞ(False:未表示、True:表示済)
        Dim lstrExcpHoldFlag            As String               '異常処理票保留(0：未保留、1：保留)
        Dim lstrNormalHoldFlag          As String               '通常保留(0：未保留、1：保留)
        Dim lstrMsgHold                 As String               'ﾒｯｾｰｼﾞ表示用
        Dim lstrWfFlag                  As String               'ｴﾗｰ判定(FTPﾃﾞｰﾀ同期登録)
        Dim lstrDividedCheckFlag        As String               'ﾛｯﾄ分割確認要求ﾌﾗｸﾞ
        Dim llngMsgAns                  As Integer              'ﾎﾟｯﾌﾟｱｯﾌﾟ結果格納用
        Dim lblnChkChangeOrderAns       As Boolean              '量産ｵｰﾀﾞｰ振替ﾁｪｯｸ戻り値格納用
        Dim ltypLotCfkiMoveAns          As LotCfkiMoveAns       'CFKI作業入力要求応答構造体
        Dim lstrOdfJBatchStatus         As String               '無機ODF貼り合せ結果
        Dim lstrComment                 As String               '次行程送出結果のｺﾒﾝﾄ格納
    '@↓2018/08/31 (Fri) 15:02:50 Y.Yoneyama **************************************************
        Dim lblnFTPSync                 As Boolean
    '@↑2018/08/31 (Fri) 15:02:50 Y.Yoneyama **************************************************


        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@画面が無効な場合は中止
            If Me.Enabled = False Then
                Exit Sub
            End If
            
            '@画面入力ﾁｪｯｸ
            lblnInputCheck = prvblnInput_Chk
            If lblnInputCheck = False Then
                Exit Sub
            End If

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            
            '@ESCでの画面終了無効
             Me.CancelButton = Nothing 
            
            '@ﾌﾗｸﾞ初期化
            lblnMsgFlag = False
			

            '@戻り値初期化(FTP送信結果)
            lstrFTPResult = vbNullString
            
            '@WAIST検査機orODF貼り合せ装置(ﾊﾝﾄﾞﾜｰｸ)の場合は作業終了可能かﾁｪｯｸを行う
        '@↓2018/08/31 (Fri) 15:31:19 Y.Yoneyama **************************************************
            If ptypLotprestate.strEqType = CPstrEqTypeWAIST Or _
               (ptypLotprestate.strEqType = CPstrEqTypeODF And ptypLotprestate.strWpTypeFlag = CPstrFlagOff) Then
            'If ptypLotprestate.strEqType = CPstrEqTypeWAIST Or _
            '   ptypLotprestate.strEqType = CPstrEqTypeODF  Then
        '@↑2018/08/31 (Fri) 15:31:19 Y.Yoneyama **************************************************
                
                '@装置ﾃﾞｰﾀﾁｪｯｸ処理
                lblnDataCheck = prvWPData_Chk
                
                '@装置ﾃﾞｰﾀﾁｪｯｸ処理判定
                If lblnDataCheck = False Then
                    
                    '@ESCでの画面終了有効
                    Me.CancelButton = cmdClose
                    
                    Exit Sub
                End If
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)
            
            '@処理中ﾌｫｰﾑ表示ﾌﾗｸﾞの初期化
            lblnCM00X0DispFlag = False          '処理中ﾌｫｰﾑ表示ﾌﾗｸﾞ(False:未表示、True:表示済)
            
        '@↓2018/08/31 (Fri) 14:53:01 Y.Yoneyama **************************************************
            '@装置ﾃﾞｰﾀをFTPで取得するか判別
            lblnFTPSync = False
            '@装置ﾃﾞｰﾀFTPあり、運用ﾓｰﾄﾞ[M1]
            If mstrFtpDataFlag = CPstrFtpDataFlagOn And mstrMesMode = CPstrM1 Then
                '@FTP同期あり
                lblnFTPSync = True
                
                '@ODF貼合装置でﾊﾝﾄﾞﾜｰｸ(WpTypeFlag=0)
                If ptypLotprestate.strEqType = CPstrEqTypeODF And ptypLotprestate.strWpTypeFlag = CPstrFlagOff Then
                    '@FTP同期なし
                    lblnFTPSync = False
                End If
            End If
                
            '@FTP同期の場合
            If lblnFTPSync = True Then
            '@ｵﾌﾗｲﾝFTPﾃﾞｰﾀ登録の場合は処理中の子ﾌｫｰﾑを表示する(ODF装置以外の場合のみ)
            '@ODF装置はFTP_DATA_FLAG=1ではあるが、ﾎﾟｰﾘﾝｸﾞSVRで収集するので不用！！
            '@条件：FTP装置(FTP_DATA_FLAG=1)AND 装置ﾀｲﾌﾟODF以外　AND 運用ﾓｰﾄﾞ=M1
            'If mstrFtpDataFlag = CPstrFtpDataFlagOn And _
            '   ptypLotprestate.strEqType <> CPstrEqTypeODF And mstrMesMode = CPstrM1 Then
        '@↑2018/08/31 (Fri) 14:53:01 Y.Yoneyama **************************************************
                
                '@ｲﾝﾌｫﾒｰｼｮﾝ画面起動
                frmxxCM00X0.Instance = New frmxxCM00X0()
                frmxxCM00X0.Instance.Show(Me)
                
                '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定
                frmxxCM00X0.Instance.Text = CPstrSubFormCM00X0Work
                '@ｲﾝﾌｫﾒｰｼｮﾝ(装置データ登録中です。)
                frmxxCM00X0.Instance.lblInfomation1.Text = CPstrFTP
                
                '@処理中ﾌｫｰﾑ表示ﾌﾗｸﾞON
                lblnCM00X0DispFlag = True      '処理中ﾌｫｰﾑ表示ﾌﾗｸﾞ(False:未表示、True:表示済)
                '@ｲﾝﾌｫﾒｰｼｮﾝﾌｫｰﾑを先行して描画する為、記述しています。
                frmxxCM00X0.Instance.Refresh()
                
                '@ｵﾌﾗｲﾝFTPﾃﾞｰﾀ同期処理【lstrFTPResult:FTP送信結果】
                lblnAns = prvblnEqftSyncRegist_Proc(lstrFTPResult, lstrWfFlag)
                '@結果判定
                If lblnAns = False Then
                    '@ｴﾗｰの場合 (ここでは通信ｴﾗｰ等)
                    '@FTPｻｰﾊﾞｰが死んでる場合(CLのﾛｸﾞにも出力します。)又は
                    '@FTP送信結果がNGの場合でも作業終了続行する。
                    '@WFﾘｽﾄが取得できない場合は致命的なｴﾗｰの為以降の処理はSTOP
                    
                    lblnCM00X0DispFlag = False
                    lstrFTPResult = CMstrNG
                    
                    '@ｲﾝﾌｫﾒｰｼｮﾝ画面終了
                    frmxxCM00X0.Instance = Nothing
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                    
                    '@致命的なｴﾗｰが発生した場合(WFﾘｽﾄが取得できない)
                    If lstrWfFlag = CMstrNG Then
                        
                        '@ESCでの画面終了有効
                        Me.CancelButton = cmdClose
                        
                        Exit Sub
                    End If
                    
                End If
            End If
            
            '@特殊流動ﾌﾗｸﾞ(不可)
            lblnReworkFlag = False
                            
            '@作業終了ﾃﾞｰﾀ格納
            With ltypLotwrkend
                .strLotID = lblLotID.Text                               'ﾛｯﾄID
                .strOpID = lblOpID.Text                                 '大工程ID
                .strStepID = lblStepID.Text                             '小工程ID
                .strEngEmpId = pstrUserID                               '作業者ID
                .strComment = txtWorkMemo.Text                          '作業ﾒﾓ
                .strLotLastUpdate = mstrLotLastUpdate                   'LOT最終更新日時

                '@作業終了処理
                lblnAns = pubblnLotWrkend_Upd(CMstrlot_wrkendVer, _
                                              ltypLotwrkend, _
                                              lstrActionFlag, _
                                              lstrFoldFlag, _
                                              lstrResultReworkState, _
                                              CPstrCD23, _
                                              lstrGuidMsg, _
                                              lstrGuidMsgCode, _
                                              lstrTftHoldFlag, _
                                              lstrExcpHoldFlag, _
                                              lstrNormalHoldFlag, _
                                              ltypLotCfkiMoveAns, _
                                              lstrMoveResult, _
                                              lstrToCarrierID)
                                              
                '@結果判定
                If lblnAns = True Then
                
                    '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞに値が入っている場合
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

                    '@FTPﾃﾞｰﾀ登録要求が「NG」の場合
                    '@解説：応答はNGで判定する。OK以外に文字列が返る可能性があるそうです。
                    '@旧SVのﾛｼﾞｯｸに真似て「NG」文字列で判定する。
                    If lstrFTPResult = CMstrNG Then
                        
                        '@処理中ﾌｫｰﾑを表示している場合は子ﾌｫｰﾑをUnloadする
                        If lblnCM00X0DispFlag = True Then
                            '@ｲﾝﾌｫﾒｰｼｮﾝ画面終了
                            frmxxCM00X0.Instance = Nothing
                        End If
                        
                        '@登録失敗のｴﾗｰを表示し、継続or中断を選択させる
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005X)
                        '@"装置データ取得処理[FTPデータ登録要求]に失敗しました。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                    End If
                
                    '@成功ﾒｯｾｰｼﾞ格納
                    '@表示ﾒｯｾｰｼﾞ変換"メッセージコード：C_I13%0$$作業を終了しました。キャリア[ %1 ] ロット[ %2 ]"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0013, txtCarrier.Text, lblLotID.Text)
                    '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)
                    


                    '@SPC規格値判定
                    '@構造体に情報をｾｯﾄする
                    With ltypSpcJudge
                        .strMsgVer = CMstrspc_judge___Ver               'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                        
                        .strLotID = lblLotID.Text                    'ﾛｯﾄID
                        .strOpID = lblOpID.Text                      '大工程ID
                        .strStepID = lblStepID.Text                  '小工程ID
                        .strEmpID = pstrUserID                          '作業者ID
                        .strNextLotID = ltypLotwrkend.strLotID          '作業終了後ﾛｯﾄID
						.strSbID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸ

                    End With

                    '@**************************************************
                    '@ SPC規格値判定ﾒｯｾｰｼﾞ送信処理呼び出し
                    '@**************************************************
                    lblnSpcSpecchkAns = pubblnSpcJudge_Sel(ltypSpcJudge)

                    '@SPC規格値判定ﾒｯｾｰｼﾞ送信処理の戻り値の判定
                    If lblnSpcSpecchkAns = False Then
                        '@戻り値がFalseの場合
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                        
                        '@ESCでの画面終了有効
                        Me.CancelButton = cmdClose
                        
                        '@処理中ﾌｫｰﾑを表示している場合は子ﾌｫｰﾑをUnloadする
                        If lblnCM00X0DispFlag = True Then
                            '@ｲﾝﾌｫﾒｰｼｮﾝ画面終了
                            frmxxCM00X0.Instance = Nothing
                        End If
                        
                        Exit Sub
                    End If

					'@特殊流動状態の桁数が3桁の(正常な)場合
                    If Len(lstrResultReworkState) = CMlngReworkLen Then
                        '@特殊流動状態格納
                        lstrResultRework1 = Mid(lstrResultReworkState, CMlngReworkLen1, CMlngReworkLen1)    '百の位
                        lstrResultRework2 = Mid(lstrResultReworkState, CMlngReworkLen2, CMlngReworkLen1)    '十の位
                        lstrResultRework3 = Mid(lstrResultReworkState, CMlngReworkLen3, CMlngReworkLen1)    '一の位
                    Else
                        '@特殊流動状態が取得できない場合は特殊流動なしをｾｯﾄ
                        lstrResultRework1 = CMstrRework0
                        lstrResultRework2 = CMstrRework0
                        lstrResultRework3 = CMstrRework0
                    End If

                    
                    Call StartApcDepo(ltypSpcJudge.strSpecCheck, _
                                        .strLotID, _
                                        .strOpID, _
                                        .strStepID, _
                                        lblFlowClass.Text)


					'@**************************************************
					'@ 無機ODF貼り合せ結果取得
					'@**************************************************
					lblnAns = chkOdfCover(CMstrlot_chkodfcovsrVer, _
											pstrSBID, _
											.strLotID, _
											lstrOdfJBatchStatus, _
											mstrHoldTermDate)


					'@無機ODF貼り合せ結果取得の判定
					If lblnAns = False Then
						'@戻り値がFalseの場合
                        
						'@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
						Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                        
                        
						'@ESCでの画面終了有効
						Me.CancelButton = cmdClose
                        
						'@処理中ﾌｫｰﾑを表示している場合は子ﾌｫｰﾑをUnloadする
						If lblnCM00X0DispFlag = True Then
							'@ｲﾝﾌｫﾒｰｼｮﾝ画面終了
							frmxxCM00X0.Instance = Nothing
						End If
                        
						Exit Sub
					End If
					

                    '@**************************************************
                    '@ｱｸｼｮﾝ予定実行ﾌﾗｸﾞ判定
                    '@**************************************************
                    Select Case lstrActionFlag
                    
                        '@保留/停止の実行なし
                        Case CPstrActionFlag0
                        
                            '@SPC規格値判定結果の判定
                            Select Case ltypSpcJudge.strSpecCheck
                            
                                Case CMstrSpecCheckOK, CMstrSpecCheckSPCNG
                                '@SPC規格値判定ﾒｯｾｰｼﾞが正常、SPC異常の場合
                                
                                    '@自動送信「あり」の場合、次工程送出ﾒｯｾｰｼﾞ送信
                                    If optLotNextSend0.Checked  = True Then
                                        
                                        '@========================
                                        '@次行程送出ﾁｪｯｸOnの場合
                                        '@========================
                                        
                                        '@次工程送出ﾌﾗｸﾞ(可能)
                                        lblnNextFlag = True
                                        
                                        '@特殊流動中ﾌﾗｸﾞ判定
                                        Select Case mstrReworkKind
                                        
                                            '@分割先(子)特殊流動中
                                            Case CMstrReworkKind1
                                            
                                                '@分割先(子)の次工程なし
                                                If lstrResultRework3 = CMstrRework0 Then
													'@次工程送出ﾌﾗｸﾞ(不可)
                                                    lblnNextFlag = False
                                                    '@分割元(親)の次工程なし
                                                    If lstrResultRework2 = CMstrRework0 Then
                                                    End If
                                                    '@分割元(親)の次工程あり
                                                    If lstrResultRework2 = CMstrRework1 Then

                                                    End If
                                                   
                                                End If
                
                                            '@分割元(親)特殊流動中
                                            Case CMstrReworkKind2
                                            
                                                '@分割元(親)の次工程なし
                                                If lstrResultRework2 = CMstrRework0 Then
                                                    '@分割元(親)の次工程なし
                                                    If lstrResultRework3 = CMstrRework0 Then
                                                    End If
                                                    '@分割先(子)の次工程あり
                                                    If lstrResultRework3 = CMstrRework1 Then
                                                    End If
                                                    '@次工程送出ﾌﾗｸﾞ(不可)
                                                    lblnNextFlag = False
                                                End If
                                        End Select
                                        
                                        '@移載状態がWF移載予約後で移載前、又は移載完了で次工程がない
                                        If lstrMoveResult = CMstrMoveResult1 Or _
                                           (lstrMoveResult = CMstrMoveResult2 And vsfNextStepInfo.Rows.Count <= vsfNextStepInfo.Rows.Fixed) Then
                                            '@次工程送出ﾌﾗｸﾞ(不可)
                                            lblnNextFlag = False
                                        End If
                                        
                                        '@次工程送出可能な場合
                                        If lblnNextFlag = True Then
                                        
                                            '@CFKI判定(CFKIの場合はCFﾛｯﾄ終了、CFKI以外は次工程送出)
                                            If mblnCfkiFlg = True Then
                                                '@CFKIﾌﾗｸﾞ(有効)
                
                                                '@CFﾛｯﾄ終了要求構造体に値を格納
                                                With ltypLotCfEnd
                                                    .strSbID = pstrSBID                                         '処理区分
                                                    .strMsgVer = CPstrlot_cfend___Ver                           'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                                                    .strLotID = lblLotID.Text                                'ﾛｯﾄID
                                                    .strEmpID = pstrUserID                                      '作業者ID
                                                    .strLotLastUpdate = ltypLotwrkend.strLotLastUpdate          'LOT最終更新日時(作業終了から引継ぎ)
                                                End With
                
                                                '@**************************************************
                                                '@ ﾛｯﾄ終了処理
                                                '@**************************************************
                                                lblnAns = pubblnLotCfEnd_Upd(ltypLotCfEnd, lstrGuidMsg, lstrGuidMsgCode)
                                                
                                                '@結果判定
                                                If lblnAns = True Then
                                                    '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞに値が入っている場合
                                                    If lstrGuidMsgCode <> vbNullString Then
                                                        '@表示ｶﾞｲﾀﾞﾝｽMsgの編集("【警告】" & "$$" & "ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ[CODE]">" & "$$" & ｶﾞｲﾀﾞﾝｽMsg)
                                                        lstrEditGuidance = CPstrWarMsgCode & CPstrGuidanceMsg & CPstrMsgCrCode & _
                                                                           CPstrGuidanceCode & CPstrBracketLeft & lstrGuidMsgCode & CPstrBracketRight & _
                                                                           CPstrMsgCrCode & lstrGuidMsg
                                                        
                                                        '@ﾒｯｾｰｼﾞ表示"<編集済みｶﾞｲﾀﾞﾝｽMsg"
                                                        pstrDMsg = pubstrMsgReplace_Set(lstrEditGuidance)
                                                        '@ﾒｯｾｰｼﾞ表示
                                                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                                    End If
                                                
                                                    '@pubVsfInfo_Disp("メッセージコード：C_I32%0$$ロット[ %2 ]終了しました。キャリア[ %1 ]")
                                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0032, txtCarrier.Text, lblLotID.Text)
                                                    '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                                                    Call pubVsfInfo_Disp(pstrDMsg)
                                                Else
                                                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                                    Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                                                End If
                                                
                                            Else
                                                '@CFKIﾌﾗｸﾞ(無効)
                                                
                                                '@電特保留、TFT保留、異常処理票保留、通常保留のいずれも掛かっていない場合
                                                If lstrFoldFlag <> CPstrHold1 And _
                                                    lstrTftHoldFlag <> CPstrHold1 And _
                                                    lstrExcpHoldFlag <> CPstrHold1 And _
                                                    lstrNormalHoldFlag <> CPstrHold1 Then
                                                   
                                                    '@最終工程で特殊流動なしの場合
                                                    If vsfNextStepInfo.Rows.Count <= vsfNextStepInfo.Rows.Fixed And _
                                                       mstrReworkKind = CMstrReworkKind0 Then
                                                      
                                                        '@処理区分に「24」(最終区分に送る)を格納
                                                        lstrClassDivision = CPstrCD24

                                                        '@ﾛｯﾄ分割ﾁｪｯｸを有効化
                                                        lstrDividedCheckFlag = CPstrEnableFlagTrue
                                                        
                                                        '@起動SBが組立か
                                                        If pstrSBID = CPstrSBID2A0 Then
                                                            '@2A0：組立の場合
                                                            
                                                            '@=======================
                                                            '@ 量産ｵｰﾀﾞｰ振替ﾁｪｯｸ
                                                            '@=======================
                                                            '@【量産ｵｰﾀﾞｰ振替ﾁｪｯｸ】ﾒｯｾｰｼﾞ送受信処理
                                                            lblnChkChangeOrderAns = pubblnLotChkChgOrder_Chk(CMstrlot_chkchangeorderVer, _
                                                                                                            .strLotID, _
                                                                                                            lstrGuidMsg, _
                                                                                                            lstrGuidMsgCode)
            
                                                            '@量産ｵｰﾀﾞｰ振替ﾁｪｯｸ結果が"True：ﾁｪｯｸ処理成功"か
                                                            If lblnChkChangeOrderAns = True Then
            
                                                                '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞがNULL以外か
                                                                If lstrGuidMsgCode <> vbNullString Then
            
                                                                    '@表示ｶﾞｲﾀﾞﾝｽMsgの編集("【警告】" & "$$" & "ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ[CODE]">" & "$$" & ｶﾞｲﾀﾞﾝｽMsg)
                                                                    lstrEditGuidance = CPstrWarMsgCode & CPstrGuidanceMsg & CPstrMsgCrCode & _
                                                                                       CPstrGuidanceCode & CPstrBracketLeft & lstrGuidMsgCode & CPstrBracketRight & _
                                                                                       CPstrMsgCrCode & lstrGuidMsg
            
                                                                    '@表示ﾒｯｾｰｼﾞ変換
                                                                    '@「上記編集済みｶﾞｲﾀﾞﾝｽMsg」のﾒｯｾｰｼﾞ表示
                                                                    pstrDMsg = pubstrMsgReplace_Set(lstrEditGuidance)
                                                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                                                
                                                                End If
                                                            End If
                                                        End If


                                                        '@=======================
                                                        '@ 次工程送出(DIVIDED_CHECK_FLAG = 1)
                                                        '@ ※最終更新日時は、確定時に返される値を使う。ﾒｯｾｰｼﾞ関数内で書き換えている
                                                        '@=======================
                                                        '@【次工程送出】ﾒｯｾｰｼﾞ送受信処理
                                                        lblnAnsNextSend = pubblnLotNextSend_Upd(CMstrlot_nextSendVer, _
                                                                                                .strLotID, _
                                                                                                .strLotLastUpdate, _
                                                                                                .strEngEmpId, _
                                                                                                lstrDividedCheckFlag, _
                                                                                                lstrClassDivision, , , , _
                                                                                                lstrNextActionFlag, _
                                                                                                lstrFoldFlag, _
                                                                                                lstrSendResult, _
                                                                                                lstrTftHoldFlag)

                                                        '@結果判定
                                                        If lblnAnsNextSend = True Then

                                                            '@送出結果がTrueの場合の処理。
                                                            '@
                                                            '@まず，(9：送品中断)かどうか先に判断する。

                                                            If lstrSendResult = CPstrSendAbort Then

                                                                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                                                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)

                                                                '@「送品中断」の場合は，ﾎﾟｯﾌﾟｱｯﾌﾟ表示し，作業者に指示を仰ぐ。
                                                                '@表示ﾒｯｾｰｼﾞ変換("<TRM9JW>$$ロット[%1]は、ロット分割されています。ロット分割状態のまま送出しますか？")
                                                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009J, .strLotID)
                                                                llngMsgAns = publngMsgBox(pstrDMsg & vbCrLf, vbNo, Me.Text, True, 16, False)

                                                                '@「はい」なら分割状態で送品していいので，DIVIDED_CHECK_FLAG=0(ﾛｯﾄ分割ﾁｪｯｸ無し) とし，再度，ﾒｯｾｰｼﾞを発行する。
                                                                If llngMsgAns = vbYes Then

                                                                    '@ﾛｯﾄ分割ﾁｪｯｸを無効化ｾｯﾄ
                                                                    lstrDividedCheckFlag = CPstrEnableFlagFalse

                                                                    '@起動SBが組立か
                                                                    If pstrSBID = CPstrSBID2A0 Then
                                                                        '@2A0：組立の場合

                                                                        '@=======================
                                                                        '@ 量産ｵｰﾀﾞｰ振替ﾁｪｯｸ
                                                                        '@=======================
                                                                        '@【量産ｵｰﾀﾞｰ振替ﾁｪｯｸ】ﾒｯｾｰｼﾞ送受信処理
                                                                        lblnChkChangeOrderAns = pubblnLotChkChgOrder_Chk(CMstrlot_chkchangeorderVer, _
                                                                                                                        .strLotID, _
                                                                                                                        lstrGuidMsg, _
                                                                                                                        lstrGuidMsgCode)
            
                                                                        '@量産ｵｰﾀﾞｰ振替ﾁｪｯｸ結果が"True：ﾁｪｯｸ処理成功"か
                                                                        If lblnChkChangeOrderAns = True Then
            
                                                                            '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞがNULL以外か
                                                                            If lstrGuidMsgCode <> vbNullString Then
            
                                                                                '@表示ｶﾞｲﾀﾞﾝｽMsgの編集("【警告】" & "$$" & "ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ[CODE]">" & "$$" & ｶﾞｲﾀﾞﾝｽMsg)
                                                                                lstrEditGuidance = CPstrWarMsgCode & CPstrGuidanceMsg & CPstrMsgCrCode & _
                                                                                                   CPstrGuidanceCode & CPstrBracketLeft & lstrGuidMsgCode & CPstrBracketRight & _
                                                                                                   CPstrMsgCrCode & lstrGuidMsg
            
                                                                                '@表示ﾒｯｾｰｼﾞ変換
                                                                                '@「上記編集済みｶﾞｲﾀﾞﾝｽMsg」のﾒｯｾｰｼﾞ表示
                                                                                pstrDMsg = pubstrMsgReplace_Set(lstrEditGuidance)
                                                                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                                                            End If
                                                                        End If
                                                                    End If


                                                                    '@=======================
                                                                    '@ 次工程送出処理(DIVIDED_CHECK_FLAG = 0)
                                                                    '@=======================
                                                                    '@【次工程送出】ﾒｯｾｰｼﾞ送受信処理
                                                                    lblnAnsNextSend = pubblnLotNextSend_Upd(CMstrlot_nextSendVer, _
                                                                                            .strLotID, _
                                                                                            .strLotLastUpdate, _
                                                                                            .strEngEmpId, _
                                                                                            lstrDividedCheckFlag, _
                                                                                            lstrClassDivision, , , , _
                                                                                            lstrNextActionFlag, _
                                                                                            lstrFoldFlag, _
                                                                                            lstrSendResult, _
                                                                                            lstrTftHoldFlag)

                                                                    '@結果判定
                                                                    If lblnAnsNextSend = True Then

                                                                        '@送出結果がTrueの場合に表示するﾒｯｾｰｼﾞを分ける
                                                                        Call pubLotNextSendResultPopUp(lstrSendResult, txtCarrier.Text, .strLotID)
                                                                        '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                                                                        Call pubVsfInfo_Disp(pstrDMsg)

                                                                    Else
                                                                        '@次工程送出失敗( DIVIDED_CHECK_FLAG = 0 )
                                                                        '@
                                                                        '@表示ﾒｯｾｰｼﾞ変換
                                                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000E)

                                                                        '@「次工程送出に失敗しました。メニューの次工程送出から再度実行して下さい。」ﾒｯｾｰｼﾞ表示
                                                                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)


                                                                        '@ESCでの画面終了有効
                                                                        Me.CancelButton = cmdClose

                                                                        '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                                                                        Call pubSetFocus(txtCarrier)

                                                                        Exit Sub
                                                                    End If

                                                                Else
                                                                    '@「いいえ」の場合（送出中断の場合）( DIVIDED_CHECK_FLAG = 1 )
                                                                    '@　→　この後，画面を終了し，ﾛｯﾄ統合処理をする筈。
                                                                    '@
                                                                    '@処理中ﾌｫｰﾑを表示している場合は子ﾌｫｰﾑをUnloadする
                                                                    If lblnCM00X0DispFlag = True Then
                                                                        '@ｲﾝﾌｫﾒｰｼｮﾝ画面終了
                                                                        frmxxCM00X0.Instance = Nothing
                                                                    End If


                                                                    '@ESCでの画面終了有効
                                                                    Me.CancelButton = cmdClose

                                                                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                                                                    Call pubSetFocus(txtCarrier)

                                                                    Exit Sub

                                                                End If
                                                            
                                                            Else
                                                                '@「9:送品中断」以外の場合
                                                                '@送出結果がTrueの場合に表示するﾒｯｾｰｼﾞを分ける
                                                                Call pubLotNextSendResultPopUp(lstrSendResult, txtCarrier.Text, .strLotID)
                                                                '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                                                                Call pubVsfInfo_Disp(pstrDMsg)

                                                            End If

                                                        Else
                                                            '@次工程送出失敗（DIVIDED_CHECK_FLAG=1 の状態）
                                                            '@
                                                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                                            Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)

                                                            '@表示ﾒｯｾｰｼﾞ変換
                                                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000E)

                                                            '@「次工程送出に失敗しました。メニューの次工程送出から再度実行して下さい。」ﾒｯｾｰｼﾞ表示
                                                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                                                        End If

                                                    Else
                                                        '@「最終工程で特殊流動なし」以外の場合

                                                        '@ﾛｯﾄ分割ﾁｪｯｸの無効化
                                                        lstrDividedCheckFlag = CPstrEnableFlagFalse


                                                        '@起動SBが組立か
                                                        If pstrSBID = CPstrSBID2A0 Then
                                                            '@2A0：組立の場合

                                                            '@=======================
                                                            '@ 量産ｵｰﾀﾞｰ振替ﾁｪｯｸ
                                                            '@=======================
                                                            '@【量産ｵｰﾀﾞｰ振替ﾁｪｯｸ】ﾒｯｾｰｼﾞ送受信処理
                                                            lblnChkChangeOrderAns = pubblnLotChkChgOrder_Chk(CMstrlot_chkchangeorderVer, _
                                                                                                            .strLotID, _
                                                                                                            lstrGuidMsg, _
                                                                                                            lstrGuidMsgCode)
            
                                                            '@量産ｵｰﾀﾞｰ振替ﾁｪｯｸ結果が"True：ﾁｪｯｸ処理成功"か
                                                            If lblnChkChangeOrderAns = True Then
            
                                                                '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞがNULL以外か
                                                                If lstrGuidMsgCode <> vbNullString Then
            
                                                                    '@表示ｶﾞｲﾀﾞﾝｽMsgの編集("【警告】" & "$$" & "ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ[CODE]">" & "$$" & ｶﾞｲﾀﾞﾝｽMsg)
                                                                    lstrEditGuidance = CPstrWarMsgCode & CPstrGuidanceMsg & CPstrMsgCrCode & _
                                                                                       CPstrGuidanceCode & CPstrBracketLeft & lstrGuidMsgCode & CPstrBracketRight & _
                                                                                       CPstrMsgCrCode & lstrGuidMsg
            
                                                                    '@表示ﾒｯｾｰｼﾞ変換
                                                                    '@「上記編集済みｶﾞｲﾀﾞﾝｽMsg」のﾒｯｾｰｼﾞ表示
                                                                    pstrDMsg = pubstrMsgReplace_Set(lstrEditGuidance)
                                                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                                                End If
                                                            End If
                                                        End If



  
															'@=======================
															'@ 次工程送出(DIVIDED_CHECK_FLAG = 0)
															'@ ※最終更新日時は、確定時に返される値を使う。ﾒｯｾｰｼﾞ関数内で書き換えている
															'@=======================
															'@【次工程送出】ﾒｯｾｰｼﾞ送受信処理
															lblnAnsNextSend = pubblnLotNextSend_Upd(CMstrlot_nextSendVer, _
																									.strLotID, _
																									.strLotLastUpdate, _
																									.strEngEmpId, _
																									lstrDividedCheckFlag, , , lstrComment, , _
																									lstrNextActionFlag, _
																									lstrFoldFlag, _
																									lstrSendResult, _
																								    lstrTftHoldFlag)
												
                                                        '@結果判定
                                                        If lblnAnsNextSend = True Then

                                                            '@次工程送出結果格納(Null:次工程送出/0:中間在庫/1:完成在庫/2:組立送品)
                                                            If lstrSendResult = vbNullString Then

                                                                '@更新処理の為送信構造体に状態をｾｯﾄする
                                                                With ltypCtlUpdWaitingLotList
                                                                    .strClassDivision = CPstrCD01                                                       '処理区分(=01)
                                                                    .strMsgVer = CMstrctl_updwaitinglotVer                                              'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                                                                    .strSbID = pstrSBID                                                                 'ｼｽﾃﾑﾌﾞﾛｯｸ
                                                                    .strWpID = vbNullString                                                             'WPID(=vbNullString)
                                                                    .lngWaitingLotListCnt = 1                                                           'ﾘｽﾄｶｳﾝﾄ(=1)
                                                                    If .typWaitingLotList Is Nothing Then 
                                                                        .typWaitingLotList = New List(Of UpWaitingLotList) 
                                                                    Else 
                                                                        .typWaitingLotList.Clear()
                                                                    End If

                                                                    Dim typWaitingLotListtmp As UpWaitingLotList = New UpWaitingLotList ()

                                                                    '@作業終了Msgの応答LotIDを設定
                                                                    typWaitingLotListtmp.strLotID = ltypLotwrkend.strLotID         'ﾛｯﾄID
                                                                    typWaitingLotListtmp.strOpID = lblOpID.Text                    '大工程
                                                                    typWaitingLotListtmp.strStepID = lblStepID.Text                '小工程
                                                                    typWaitingLotListtmp.strSeqNum = vbNullString                  '処理順(=vbNullString)

                                                                    'NSYS 更新ロットを格納
                                                                    .typWaitingLotList.Add( typWaitingLotListtmp)
                                                                End With
                                                                
                                                                '@**************************************************
                                                                '@結果OKの場合,処理待ちﾛｯﾄ更新処理を行う
                                                                '@**************************************************
                                                                lblnCtlAns = pubblnCtlUpdWaitingLot_Upd(ltypCtlUpdWaitingLotList)
                                                                '@結果判定
                                                                If lblnCtlAns = False Then
                                                                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                                                    Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                                                                End If
                                                            End If
                                                            
                                                            '@ｺﾒﾝﾄは空か
                                                            If lstrComment = vbNullString Then
                                                                '@表示ﾒｯｾｰｼﾞ変換"<TRM23I>$$次工程送出しました。キャリア[ %1 ] ロット[ %2 ]"
                                                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0023, txtCarrier.Text, .strLotID)
                                                            End If
                                                            
                                                            '@送品中止の場合(ﾚｼﾋﾟ選択APCの測定行程ﾁｪｯｸNG)
                                                            If lstrSendResult = CPstrSendAbort And lstrComment <> vbNullString Then
                                                                '@ﾒｯｾｰｼﾞ表示
                                                                pstrDMsg = pubstrMsgReplace_Set(lstrComment)
                                                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                                            End If
                                                            
                                                            '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                                                            Call pubVsfInfo_Disp(pstrDMsg)
                                                            
                                                            '@装置別ﾛｯﾄ一覧より呼ばれている場合、次工程送出にて装置ID、大工程、小工程が変わる為
                                                            '@引継ぎ構造体よりｸﾘｱする。
                                                            With ptypCommonInfo
                                                                .strWpID = vbNullString
                                                                .strWpName = vbNullString
                                                                .strOpID = vbNullString
                                                                .strStepID = vbNullString
                                                            End With
                                                            
                                                            '@表示ﾒｯｾｰｼﾞ初期化
                                                            pstrDMsg = vbNullString
                                                            
                                                            '@ｱｸｼｮﾝﾌﾗｸﾞによる分岐
                                                            Select Case lstrNextActionFlag
                                                            
                                                                '@停止の場合
                                                                Case CPstrActionFlag1
                                                                    '@表示ﾒｯｾｰｼﾞ変換"<TRM2SI>$$アクション予約によりロット[ %1 ] は [停止] されました。"
                                                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002S, lblLotID.Text, CPstrStopSt)
                                                                
                                                                '@保留の場合
                                                                Case CPstrActionFlag2
                                                                    '@表示ﾒｯｾｰｼﾞ変換"<TRM2SI>$$アクション予約によりロット[ %1 ] は [保留] されました。"
                                                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002S, lblLotID.Text, CPstrHoldSt)
                                                            End Select
                                                            
                                                            '@表示ﾒｯｾｰｼﾞがある場合
                                                            If pstrDMsg <> vbNullString Then
                                                                '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                                                                Call pubVsfInfo_Disp(pstrDMsg)
                                                            End If

                                                        Else
                                                            '@次工程送出失敗 ( DIVIDED_CHECK_FLAG = 0 )
                                                            '@
                                                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                                            Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)

                                                        End If
                                                    End If
                                                Else
                                                    '@電特保留、TFT保留、異常処理票保留、通常保留のいずれかが掛かっている場合
                                                    '@次工程送出不可ﾒｯｾｰｼﾞ表示
                                                    Call prvNextNgMsg_Disp(ltypLotwrkend.strLotID, lstrFoldFlag, lstrTftHoldFlag, lstrExcpHoldFlag, lstrNormalHoldFlag)
                                                End If
                                                
                                            End If

                                        Else
                                        
                                            '@====================
                                            '@次行程送出不可の場合
                                            '@====================
                                            
                                            '@次工程送出結果を判定してｴﾗｰﾒｯｾｰｼﾞを表示する。
                                            Select Case True
                                            
                                                '@電特保留、TFT保留　両方保留の場合
                                                Case lstrFoldFlag = CPstrHold1 And lstrTftHoldFlag = CPstrHold1
                                                
                                                    '@電特＆TFT測定結果が「NG」のため保留
                                                    '@表示ﾒｯｾｰｼﾞ変換"<TRM2OI>$$%1測定結果にNGのウエハが存在するため、ロット[%2]は保留されました。"
                                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002O, CMstrMsgEltTft, lblLotID.Text)
                                                    Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                                                    
                                                    '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                                                    Call pubVsfInfo_Disp(pstrDMsg)
                                                    
                                                '@電特のみ保留
                                                Case lstrFoldFlag = CPstrHold1 And lstrTftHoldFlag = CPstrHold0
                                                
                                                    '@電特測定結果が「NG」のため保留
                                                    '@表示ﾒｯｾｰｼﾞ変換"<TRM2OI>$$%1測定結果にNGのウエハが存在するため、ロット[%2]は保留されました。"
                                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002O, CMstrMsgELT, lblLotID.Text)
                                                    Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                                                    
                                                    '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                                                    Call pubVsfInfo_Disp(pstrDMsg)
                                            
                                                '@TFTのみ保留
                                                Case lstrFoldFlag = CPstrHold0 And lstrTftHoldFlag = CPstrHold1
                                                
                                                    '@TFT測定結果が「NG」のため保留
                                                    '@表示ﾒｯｾｰｼﾞ変換"<TRM2OI>$$%1測定結果にNGのウエハが存在するため、ロット[%2]は保留されました。"
                                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002O, CMstrMsgTFT, lblLotID.Text)
                                                    Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                                                    
                                                    '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                                                    Call pubVsfInfo_Disp(pstrDMsg)
                                                    
                                            End Select
                                        End If
                                    Else
                                    
                                        '@=======================
                                        '@次行程送出ﾁｪｯｸOffの場合
                                        '@=======================
                                    
                                        '@ﾚｽﾎﾟﾝｽ取得終了
                                        Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                
                                        '@特殊流動する場合(ﾘﾜｰｸ/追加流動)
                                        If optLotNextSend2.Checked  = True Or _
                                           optLotNextSend3.Checked  = True Then
                                           
                                            '@特殊流動ﾌﾗｸﾞ(可能)
                                            lblnReworkFlag = True
                                        End If
                                        
                                        '@次工程送出結果を判定してｴﾗｰﾒｯｾｰｼﾞを表示する。
                                        Select Case True
                                        
                                            '@電特保留、TFT保留　両方保留の場合
                                            Case lstrFoldFlag = CPstrHold1 And lstrTftHoldFlag = CPstrHold1
                                            
                                                '@電特＆TFT測定結果が「NG」のため保留
                                                '@表示ﾒｯｾｰｼﾞ変換"<TRM2OI>$$%1測定結果にNGのウエハが存在するため、ロット[%2]は保留されました。"
                                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002O, CMstrMsgEltTft, lblLotID.Text)
                                                Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                                                
                                                '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                                                Call pubVsfInfo_Disp(pstrDMsg)
                                               
                                            '@電特のみ保留
                                            Case lstrFoldFlag = CPstrHold1 And lstrTftHoldFlag = CPstrHold0
                                            
                                                '@電特測定結果が「NG」のため保留
                                                '@表示ﾒｯｾｰｼﾞ変換"<TRM2OI>$$%1測定結果にNGのウエハが存在するため、ロット[%2]は保留されました。"
                                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002O, CMstrMsgELT, lblLotID.Text)
                                                Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                                                
                                                '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                                                Call pubVsfInfo_Disp(pstrDMsg)
                                            
                                            '@TFTのみ保留
                                            Case lstrFoldFlag = CPstrHold0 And lstrTftHoldFlag = CPstrHold1
                                            
                                                '@TFT測定結果が「NG」のため保留
                                                '@表示ﾒｯｾｰｼﾞ変換"<TRM2OI>$$%1測定結果にNGのウエハが存在するため、ロット[%2]は保留されました。"
                                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002O, CMstrMsgTFT, lblLotID.Text)
                                                Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                                                
                                                '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                                                Call pubVsfInfo_Disp(pstrDMsg)
                                        End Select
                                        
                                    End If
                                    
                                    '@特殊流動中ﾌﾗｸﾞ判定
                                    Select Case mstrReworkKind
                                    
                                        '@分割先(子)特殊流動中
                                        Case CMstrReworkKind1
                                            '@分割先(子)の次工程なし
                                            If lstrResultRework3 = CMstrRework0 Then
                                                '@分割元から表示ﾒｯｾｰｼﾞ判断
                                                If lstrResultRework2 = CMstrRework1 Then
                                                    '@表示ﾒｯｾｰｼﾞ変換"<TRM4NI>$$キャリア[%1]の特殊流動工程が完了しました。$分割元キャリア[%2]が特殊流動工程終了後、$移載を行ってください。"
                                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004N, txtCarrier.Text, lstrToCarrierID)
                                                Else
                                                    '@表示ﾒｯｾｰｼﾞ変換"<TRM1YI>$$キャリア[%1]の特殊流動工程が完了しました。$分割元キャリア[%2]に移載して下さい。"
                                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001Y, txtCarrier.Text, lstrToCarrierID)
                                                End If
                                                '@ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示
                                                Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                                                '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                                                Call pubVsfInfo_Disp(pstrDMsg)
                                            End If
                
                                         '@分割元(親)特殊流動中
                                        Case CMstrReworkKind2
                                            '@分割元(親)の次工程なし
                                            If lstrResultRework2 = CMstrRework0 Then
                                                '@表示ﾒｯｾｰｼﾞ変換"<TRM2AI>$$キャリア[%1]は分割先キャリアから移載されるまで次工程送出できません。"
                                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002A, txtCarrier.Text)
                                                '@ﾒｯｾｰｼﾞﾎﾞｯｸｽ表示
                                                Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                                                '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                                                Call pubVsfInfo_Disp(pstrDMsg)
                                                '@ﾌﾗｸﾞ立て
                                                lblnMsgFlag = True
                                            End If
                                    End Select
                            End Select
                        
                        '@停止
                        Case CPstrActionFlag1
                        
                            '@自動送信「あり」の場合は連続して次工程送出ﾒｯｾｰｼﾞ送信
                            If optLotNextSend0.Checked = True Then
                                '@表示ﾒｯｾｰｼﾞ変換("アクション予約によりロット[ %1 ] は [ %2 ] されました。" & "$$ロット[ %3 ]は次工程送出されません。")
                                pstrDMsg = CPstrActionInfo & CPstrActionStopNextStepInfo
                                pstrDMsg = pubstrMsgReplace_Set(pstrDMsg, lblLotID.Text, CPstrStopSt, ltypLotwrkend.strLotID)
                                '@表示ﾒｯｾｰｼﾞ変換"<TRM6LI>$$ロット[%1]は[%2]されているため、次工程送出されません。"
                                lstrMsgHold = pubstrMsgReplace_Set(CPstrMsgInf006L, ltypLotwrkend.strLotID, CMstrMsgActStop)
                                '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                                Call pubVsfInfo_Disp(lstrMsgHold)
                            Else
                                '@表示ﾒｯｾｰｼﾞ変換("アクション予約によりロット[ %1 ] は [ %2 ] されました。")
                                pstrDMsg = pubstrMsgReplace_Set(CPstrActionInfo, lblLotID.Text, CPstrStopSt)
                            End If
                            
                            '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ構造体設定
                            With ptypLotAction
                                .lnglstCnt = 1
                                .strActionFlag = CPstrActionFlag1   '1:停止
                                'NSYS 配列の初期化
                                If .typLotActList Is Nothing Then 
                                    .typLotActList = New List(Of LotActList) 
                                Else 
                                    .typLotActList.Clear()
                                End If
                                Dim typLotActListmp As LotActList = New LotActList ()
                                typLotActListmp.strLotID = lblLotID.Text
                                typLotActListmp.strFlowClass = lblFlowClass.Text
                                typLotActListmp.strLotActionTypeName = lblFlowClass.Text
                                typLotActListmp.strMessage = pstrDMsg
                                'NSYS ｱｸｼｮﾝ予約ﾘｽﾄを格納
                                .typLotActList.Add(typLotActListmp)
                            End With
                            
                        '@保留
                        Case CPstrActionFlag2
                        
                            '@自動送信「あり」の場合は連続して次工程送出ﾒｯｾｰｼﾞ送信
                            If optLotNextSend0.Checked  = True Then
                                '@表示ﾒｯｾｰｼﾞ変換("アクション予約によりロット[ %1 ] は [ %2 ] されました。" & "$$ロット[ %3 ]は次工程送出されません。")
                                pstrDMsg = CPstrActionInfo & CPstrActionStopNextStepInfo
                                pstrDMsg = pubstrMsgReplace_Set(pstrDMsg, lblLotID.Text, CPstrHoldSt, ltypLotwrkend.strLotID)
                                '@表示ﾒｯｾｰｼﾞ変換"<TRM6LI>$$ロット[%1]は[%2]されているため、次工程送出されません。"
                                lstrMsgHold = pubstrMsgReplace_Set(CPstrMsgInf006L, ltypLotwrkend.strLotID, CMstrMsgActHold)
                                '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                                Call pubVsfInfo_Disp(lstrMsgHold)
                            Else
                                '@表示ﾒｯｾｰｼﾞ変換("アクション予約によりロット[ %1 ] は [ %2 ] されました。")
                                pstrDMsg = pubstrMsgReplace_Set(CPstrActionInfo, lblLotID.Text, CPstrHoldSt)
                            End If
                            
                            '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ構造体設定
                            With ptypLotAction
                                .lnglstCnt = 1
                                .strActionFlag = CPstrActionFlag2   '2:保留
                                'NSYS ｱｸｼｮﾝ予約ﾘｽﾄを格納
                                Dim typLotActListTmp As LotActList
                                typLotActListTmp = .typLotActList(.lnglstCnt - 1)
                                typLotActListTmp.strMessage = pstrDMsg
                                .typLotActList(.lnglstCnt - 1) = typLotActListTmp
                            End With
                    End Select

                    '@**************************************************
                    '@ｱｸｼｮﾝ予定実行ﾌﾗｸﾞ判定
                    '@**************************************************
                    Select Case lstrActionFlag
                    
                        '@停止、保留の場合
                        Case CPstrActionFlag1, CPstrActionFlag2
                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)

                            '@処理中ﾌｫｰﾑを表示している場合は子ﾌｫｰﾑをUnloadする
                            If lblnCM00X0DispFlag = True Then
                                '@ｲﾝﾌｫﾒｰｼｮﾝ画面終了
                                frmxxCM00X0.Instance = Nothing
                            End If

                            '@ｱｸｼｮﾝ予約実行ﾒｯｾｰｼﾞ画面名称設定
                            frmxxCM0040.Instance.Text = CPstrSubDispTitleActionInfo

                            '@ｱｸｼｮﾝ予約実行ﾒｯｾｰｼﾞ表示画面を表示(ptypLotActionの情報でｱｸｼｮﾝ予約の内容を表示)
                            frmxxCM0040.Instance.ShowDialog(Me)
                            frmxxCM0040.Instance = Nothing
                            
                    End Select


                    '@**************************************************
                    '@無機ODF貼り合せ結果の判定
                    '@**************************************************
                    Select Case lstrOdfJBatchStatus
                    
                        Case CMstrOdfJBatchNG

                            '@**************************************************
                            '@ 無機ODF貼り合せ結果取得
                            '@**************************************************
                            lblnAns = odfholdlastupdate(CMstrlot_odfholdlastupdateVer, _
                                            pstrSBID, _
                                            .strLotID, _
                                            mstrOdfConverLastUpdate)

                            '@無機ODF貼り合せ結果取得の判定
                            If lblnAns = False Then
                            '@戻り値がFalseの場合
                        
                                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                        
                                '@ESCでの画面終了有効
                                Me.CancelButton = cmdClose 
                        
                                '@処理中ﾌｫｰﾑを表示している場合は子ﾌｫｰﾑをUnloadする
                                If lblnCM00X0DispFlag = True Then
                                    '@ｲﾝﾌｫﾒｰｼｮﾝ画面終了
                                    frmxxCM00X0.Instance = Nothing
                                End If
                        
                                Exit Sub
                            End If

                            '@**************************************************
                            '@ﾛｯﾄ保留をかける
                            '@**************************************************
                            '@保留確定処理実行
                            lblnAns = prvblnLotHold_Proc(.strLotID, mstrOdfConverLastUpdate, mstrHoldTermDate)
                                           
                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「"<TRM132W>$$蒸着バッチが異なる状態で貼り合せされたウェハが有ります。$貼り合せ結果を確認して下さい。"」
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0132)
                            
                            '@ﾒｯｾｰｼﾞ表示
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    End Select

                    '@処理中ﾌｫｰﾑを表示している場合は子ﾌｫｰﾑをUnloadする
                    If lblnCM00X0DispFlag = True Then
                        '@ｲﾝﾌｫﾒｰｼｮﾝ画面終了
                        frmxxCM00X0.Instance = Nothing
                    End If
                    

                    '@**************************************************
                    '@SPC規格値判定結果の判定
                    '@**************************************************
                    Select Case ltypSpcJudge.strSpecCheck
                    
                        '@SPC規格値判定結果が、規格値異常、またはその他異常の場合 (SPEC_CHEK="2"or"3")
                        Case CMstrSpecCheckSpecNG, CMstrSpecCheckOtherNG

                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(ltypSpcJudge.strSpecMsg)
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「"<%1><TRM4WW>$$%2"」
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004W, ltypSpcJudge.strSpecMsgCode, pstrDMsg)
                            
                            '@ﾒｯｾｰｼﾞ表示
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, CMstrSpecCheckAlarmCaption, True, 16)
                            
                        '@SPC規格値判定結果が、正常、またはSPC異常の場合
                        Case CMstrSpecCheckOK, CMstrSpecCheckSPCNG

                            '@SPC異常の場合は、ﾒｯｾｰｼﾞを表示する
                            If ltypSpcJudge.strSpecCheck = CMstrSpecCheckSPCNG Then
                                '@表示ﾒｯｾｰｼﾞ変換
                                lstrMsg3 = pubstrMsgReplace_Set(ltypSpcJudge.strSpecMsg)
                                
                                '@表示ﾒｯｾｰｼﾞ変換(%1→ｻｰﾊﾞｰﾒｯｾｰｼﾞｺｰﾄﾞ、%2→ｻｰﾊﾞｰﾒｯｾｰｼﾞ)
                                '@「"<%1><TRM4MI>$$%2"」
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004M, ltypSpcJudge.strSpecMsgCode, lstrMsg3)
                                
                                '@ﾒｯｾｰｼﾞ表示
                                Call publngMsgBoxInfo(pstrDMsg, vbInformation, CMstrSpecCheckAlarmCaption, True, 16)
                            End If
                            
                            '@特殊流動が選択されていて移載状態がWF処置後、移載工程前の場合
                            If lstrMoveResult = CMstrMoveResult1 And _
                               (optLotNextSend2.Checked  = True Or _
                                optLotNextSend3.Checked  = True) Then
                                
                                '@表示ﾒｯｾｰｼﾞ変換
                                '@ﾒｯｾｰｼﾞに表示する工程を設定
                                If optLotNextSend2.Checked = True Then
                                    lstrMsg3 = optLotNextSend2.Text     'ﾘﾜｰｸ
                                End If
                                If optLotNextSend3.Checked = True Then
                                    lstrMsg3 = optLotNextSend3.Text     '追加流動
                                End If
                                
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003J, txtCarrier.Text, lstrMsg3)
                                
                                '@"<TRM3JW>$$キャリア[%1]はウエハが移載予定のため、$[%2]できません。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                '@特殊流動ﾌﾗｸﾞを不可に設定
                                lblnReworkFlag = False
                            End If
                            
                            '@自動送出が選択されていて移載状態が移載前で既にﾒｯｾｰｼﾞが表示されていないの場合
                            If lstrMoveResult = CMstrMoveResult1 And _
                                optLotNextSend0.Checked = True And _
                                lblnMsgFlag = False Then
                                
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003L, txtCarrier.Text)
                                
                                '@"<TRM3LW>$$キャリア[%1]はウエハが移載予定のため、$[次工程送出]できません。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                '@特殊流動ﾌﾗｸﾞを不可に設定
                                lblnReworkFlag = False
                            End If
                            
                            '@特殊流動可能な場合
                            If lblnReworkFlag = True Then
                                '@特殊流動ﾌﾗｸﾞにTrueを設定(Trueなら特殊流動にｷｬﾘｱID引継ぎ、Falseなら引継ぎなし)
                                '@初期化はtxtCarrier_Validate、判定はbasxxCM0060のpublngEnd_Procで行っています。
                                pblnfrmxxEN0060SPStartFlag = True
                                
                                '@ﾘﾜｰｸ/追加流動のどちらを選択しているかﾊﾟﾌﾞﾘｯｸ構造体へ格納
                                With ptypWorkEndInfo
                                    .strCarrierId = txtCarrier.Text         'ｷｬﾘｱID(必要なし)
                                    .strLotID = lblLotID.Text            'ﾛｯﾄID(必要なし)
                                    .strfrmxxKbn = CPstrKeyEN00Y0           '遷移先ﾌｫｰﾑ名(特殊流動)
                                    .strWorkKbn = vbNullString              '処理区分(Null)
                                    
                                    '@特殊流動の引継
                                    Select Case True
                                        Case optLotNextSend2.Checked 
                                        '@ﾘﾜｰｸ
                                            .strSpecialRuteFlag = CMstrSpecialFlagR1
                                        Case optLotNextSend3.Checked 
                                        '@追加流動
                                            .strSpecialRuteFlag = CMstrSpecialFlagA2
                                        Case Else
                                        '@特殊流動なし
                                            .strSpecialRuteFlag = CMstrSpecialFlag0
                                    End Select
                                End With
                                
                                
                                '@処理中ﾌｫｰﾑを表示している場合は子ﾌｫｰﾑをUnloadする
                                If lblnCM00X0DispFlag = True Then
                                    '@ｲﾝﾌｫﾒｰｼｮﾝ画面終了
                                    frmxxCM00X0.Instance = Nothing
                                End If
                                
                                '@ESCでの画面終了有効
                                Me.CancelButton = cmdClose 
                                
                                '@**************************************************
                                '@ﾛｯﾄ特殊流動を起動する
                                '@**************************************************
                                Call pubMenuSelect_Proc(CPstrKeyEN00Y0)
                                
                                Exit Sub
                            End If
                    End Select

                    '@処理中ﾌｫｰﾑを表示している場合は子ﾌｫｰﾑをUnloadする
                    If lblnCM00X0DispFlag = True Then
                        '@ｲﾝﾌｫﾒｰｼｮﾝ画面終了
                        frmxxCM00X0.Instance = Nothing
                    End If
                    
                    '@無機CFKｵﾝﾗｲﾝ対応
                    With ltypLotCfkiMoveAns
                        '@TPALﾛｯﾄがある場合は表示する
                        If .lngTpLotListCnt > 0 Then
                            lstrMsg3 = vbNullString
                            For llngCnt = 0 To .lngTpLotListCnt-1
                                '@ﾒｯｾｰｼﾞ作成"TPALロット[TP********] キャリア[******]"
                                lstrMsg3 = lstrMsg3 + "TPALロット[" + .typTPLotList(llngCnt).strTpLotID + "] "
                                lstrMsg3 = lstrMsg3 + "キャリア[" + .typTPLotList(llngCnt).strCarrierId + "]" + vbCrLf
                            Next
                        
                            '@"<TRM1TI>$$オンラインCFKI作業終了を実施しました。$%1"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001T, lstrMsg3)
                            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                        End If
                    End With
                    
                    '@ｷｬﾘｱIDのｸﾘｱ
                    txtCarrier.Text = vbNullString
                    
                    '@ﾛｯﾄ情報の初期化
                    Call prvfrmxxEN0060_Init()
                    
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用不可)
                    Call prvfrmxxEN0060_CmbInit(False)

                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                Else
                    '@処理中ﾌｫｰﾑを表示している場合は子ﾌｫｰﾑをUnloadする
                    If lblnCM00X0DispFlag = True Then
                        '@ｲﾝﾌｫﾒｰｼｮﾝ画面終了
                        frmxxCM00X0.Instance = Nothing
                    End If
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                End If
            End With
            
            
            '@ESCでの画面終了有効
            Me.CancelButton = cmdClose
            
            '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrier)
            
            Exit Sub

        '@例外処理
        Catch ex As Exception

            
            '@処理中ﾌｫｰﾑを表示している場合は子ﾌｫｰﾑをUnloadする
            If lblnCM00X0DispFlag = True Then
                '@ｲﾝﾌｫﾒｰｼｮﾝ画面終了
                frmxxCM00X0.Instance = Nothing
            End If
            
            '@ESCでの画面終了有効
            Me.CancelButton = cmdClose
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用不可)
            Call prvfrmxxEN0060_CmbInit(False)
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdRegist_Click"        '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdTreatCF_Click
    '機　能：対向基板処置登録画面表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/25 (Mon) 10:44:30 N.Kojima
    '更新日：2006/06/07 (Wed) 09:00:21 M.Miura
    '備　考：
    '　　　：2004/11/04 (Thu) 11:47:47 T.Kitagawa　 ptypCommonInfo　にｾｯﾄする処理は不要なので削除
    '　　　：2005/01/19 (Wed) 12:52:31 S.Deguchi    対向基板処置登録でﾛｯﾄｱｳﾄされた場合情報を取得しなおさない処理を追加
    '　　　：2005/06/06 (Mon) 17:14:56 N.Kojima     ﾛｯﾄ状態から引継ぎｷｬﾘｱを変更する処理を追加(不具合№829)
    '　　　：2005/09/12 (Mon) 16:44:39 N.Kojima     ｵﾌﾟｼｮﾝﾎﾞﾀﾝのﾁｪｯｸが外れてしまう件の修正。(不具合№2183)
    '　　　：2006/06/07 (Wed) 09:00:21 M.Miura      子画面戻りで最新取得と情報復元処理の共通化(不具合№3435)
    Private Sub cmdTreatCF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTreatCF.Click

        Dim lstrTitle           As String               'ﾀｲﾄﾙ

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ﾊﾟﾌﾞﾘｯｸ構造体を使用する前に初期化
            ptypCfkiRenkeiInfo = New CfkiRenkeiInfo()
            
            With ptypCfkiRenkeiInfo
                '@ﾛｯﾄ状態が「後処理」の場合
                If lblStatus.Text = CPstrAfterProgressSt Then
                    '@Unloader側ｷｬﾘｱ
                    .strCarrierId = txtCarrier.Text
                Else
                    '@「処理中」の場合
                    '@Loader側ｷｬﾘｱ
                    .strCarrierId = mstrRetainCarrier
                End If
            End With
            
            '@ﾁｯﾌﾟ数がNULLの場合
            If lblWFNo.Text <> vbNullString Then
                With ptypCfkiRenkeiInfo
                    '@ﾁｯﾌﾟ数を退避
                    .lngChipRemainCount = CLng(lblWFNo.Text)
                End With
            End If
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@対向基板リワーク不良ﾌｫｰﾑを表示
            pblnfrmxxCM00B0Kbn = True
            
            '@子画面をﾛｰﾄﾞ
            frmxxCM00B0.Instance = New frmxxCM00B0()
                
            '@ﾒﾆｭｰｷｰから機能の関連情報を取得する
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00H0, lstrTitle)
            
            '@対向基板リワーク不良名称設定
            frmxxCM00B0.Instance.Text = lstrTitle
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM00B0.Instance = Nothing

                ptypCfkiRenkeiInfo = New CfkiRenkeiInfo()
                
                '@対向基板処置登録の起動区分を初期化
                pblnfrmxxCM00B0Kbn = False
                
                Exit Sub
            End If
            
            '@画面表示
            frmxxCM00B0.Instance.ShowDialog(Me)
            frmxxCM00B0.Instance = Nothing
            
            '@戻り処理
            If ptypCfkiRenkeiInfo.strCarrierId = vbNullString Then
                '@初期化
                Call prvfrmxxEN0060_Init()
                txtCarrier.Text = vbNullString
                
                '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdClose)
            Else
                '@情報を取得し直す
                
                '@作業終了画面の最新取得と復元
                Call prvRefresh_Disp()
            End If
            
            '@次項目にﾌｫｰｶｽｾｯﾄ
            If txtWorkMemo.Enabled = True Then
                Call pubSetFocus(txtWorkMemo)
            End If
            
            '@ﾌｫｰﾑ起動区分=False
            pblnfrmxxCM00B0Kbn = False

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdTreatCF_Click"       '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCFMove_Click
    '機　能：CF移載情報入力を呼び出す
    '引　数：なし
    '戻り値：
    '作成日：2009/06/15 (Mon) 15:55:27 T.Oide
    '更新日：2009/06/15 (Mon) 15:55:27
    '備　考：
    Private Sub cmdCFMove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCFMove.Click

        Dim lstrTitle           As String           'WF状態変更登録画面ﾀｲﾄﾙ用
        Dim lstrSelect          As String           '画面ﾒｯｾｰｼﾞ用変数
        Dim ltypOldCommonInfo   As CommonInfo       '機能間受け渡し情報格納用構造体
        
        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計か
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@ﾘﾜｰｸ中(特殊流動状態判定ﾌﾗｸﾞが"0"以外)で、かつﾘﾜｰｸ最終工程(ﾘﾜｰｸ最終工程判断ﾌﾗｸﾞが"1")か。
            '@　※退避していたﾓｼﾞｭｰﾙ変数から判断
            If mstrReworkKind <> CMstrReworkKind0 And _
                mstrReworkKind <> CMstrReworkKind3 And _
                mstrReworkFinishFlag = CMstrReworkFinishFlag1 Then
            
                '@特殊流動ﾌﾗｸﾞが"1:ﾘﾜｰｸ中"か
                If mstrReworkFlag = CMstrReworkFlag1 Then
                    
                    '@画面ﾒｯｾｰｼﾞ用変数に"ﾘﾜｰｸ"をｾｯﾄ
                    lstrSelect = CMstrMsgSpecialR
                
                Else
                    '@特殊流動ﾌﾗｸﾞが"2:追加流動中"か
                    If mstrReworkFlag = CMstrReworkFlag2 Then
                    
                        '@画面ﾒｯｾｰｼﾞ用変数に"追加流動"をｾｯﾄ
                        lstrSelect = CMstrMsgSpecialA
                    End If
                End If
                
                '@=======================
                '@　機能関連情報取得処理
                '@=======================
                Call pubMenuItemCorrelation_Set(CPstrKeyEN02E0, lstrTitle)
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005T, lstrSelect, lstrTitle)
                '@ﾒｯｾｰｼﾞ表示："<TRM5TW>$$[%1]の最終工程で[%2]できません。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Exit Sub
            End If
            
            
            '@***********************
            '@　特殊流動中ではない場合
            '@***********************
            
            '@機能間受け渡し情報格納用構造体を退避構造体に格納
            ltypOldCommonInfo = ptypCommonInfo
            
            '@引継ぎ情報格納①
            With ptypCommonInfo
            
                '@ﾛｯﾄ状態が「後処理」か
                If lblStatus.Text = CPstrAfterProgressSt Then
                
                    '@ｱﾝﾛｰﾀﾞｰｷｬﾘｱを格納
                    .strCarrierId = txtCarrier.Text
                Else
                    '@ﾛｰﾀﾞｰｷｬﾘｱを格納
                    .strCarrierId = mstrRetainCarrier
                End If
                
                .strDivision = vbNullString         '起動区分：NULL
                .strLotID = vbNullString            'ﾛｯﾄID：NULL
                .strOpID = vbNullString             '大工程：NULL
                .strStepID = vbNullString           '小工程：NULL
                .strWpID = vbNullString             '装置ID：NULL
                .strWpName = vbNullString           '装置名：NULL
            End With


            '@作業終了<=>WF状態変更/ﾁｯﾌﾟ状態変更/特殊流動 引継ぎ構造体の初期化
            ptypWorkEndInfo = New WorkEndInfo()
            
            '@引継ぎ情報格納②
            With ptypWorkEndInfo
            
                '@ﾛｯﾄ状態が「後処理」か
                If lblStatus.Text = CPstrAfterProgressSt Then
                    
                    '@ｱﾝﾛｰﾀﾞｰｷｬﾘｱを格納
                    .strCarrierId = txtCarrier.Text
                Else
                    '@ﾛｰﾀﾞｰｷｬﾘｱを格納
                    .strCarrierId = mstrRetainCarrier
                End If
                
                .strLotID = lblLotID.Text            'ﾛｯﾄID
                .strfrmxxKbn = CPstrKeyEN02E0           '子画面の機能ID
            End With
            
            '@起動ﾌﾗｸﾞに"False:起動処理未完"をｾｯﾄ
            pblnFormLoad = False
            
            '@子画面起動ﾌﾗｸﾞに"True:子画面として起動"をｾｯﾄ
            pblnfrmxxEN02E0kbn = True
            '@子画面で移載情報を入力したかのﾌﾗｸﾞをﾘｾｯﾄ
            pblnCFMoveDataFlag = False

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　CF移載情報登録画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxEN02E0.Instance = New frmxxEN02E0()
            
            '@=======================
            '@　機能関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN02E0, lstrTitle)
            
            '@WF状態変更登録画面のﾌｫｰﾑ名称を設定
            frmxxEN02E0.Instance.Text = lstrTitle
            
            '@起動ﾌﾗｸﾞが"False:起動処理未完"か
            If pblnFormLoad = False Then
                '@起動処理結果：異常の場合
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxEN02E0.Instance = Nothing
                
                '@引継ぎ情報構造体の復元
                ptypCommonInfo = ltypOldCommonInfo      '機能間受け渡し情報格納用構造体
                '@子画面起動ﾌﾗｸﾞの初期化
                pblnfrmxxEN02E0kbn = False
                
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　CF移載情報入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxEN02E0.Instance.ShowDialog(Me)
            frmxxEN02E0.Instance = Nothing

            '@引継ぎ情報構造体の復元
            ptypCommonInfo = ltypOldCommonInfo          '機能間受け渡し情報格納用構造体
            '@子画面起動ﾌﾗｸﾞの初期化
            pblnfrmxxEN02E0kbn = False

            '@最終更新日を書き換える
            If ptypCfkiRenkeiInfo.strLotLastUpdate >= ptypLotprestate.strLotLastUpdate Then
                mstrLotLastUpdate = ptypCfkiRenkeiInfo.strLotLastUpdate     '対向基板処置登録
            Else
                mstrLotLastUpdate = ptypLotprestate.strLotLastUpdate        'CF移載登録
            End If
            
            '@登録したﾃﾞｰﾀがあれば｢確定｣ﾎﾞﾀﾝを有効化する
            If pblnCFMoveDataFlag = True Then
            
                '@確定ﾎﾞﾀﾝを有効にする
                ptypLotprestate.strCFMoveDataFlag = True
                Call prvcmdRegist_Set()
            End If
            
            
            
            '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
            SendKeys.SendWait(CPstrSendKeysTab)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdCFMove_Click"        '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()


        End Try
    End Sub


    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：prvfrmxxEN0060_Init
    '機　能：ﾛｯﾄ情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 16:35:41 T.Oide
    '更新日：2008/06/04 (Wed) 10:33:53 N.Kojima
    '備　考：
    '　　　：2004/08/26 (Thu) 19:15:03 M.Miura　    次工程送出ｺﾝﾎﾞ設定を削除し、次工程ｵﾌﾟｼｮﾝﾎﾞﾀﾝの無効制御を追加
    '　　　：2004/09/01 (Wed) 08:52:40 M.Miura　    特殊流動中ﾌﾗｸﾞの初期化を追加(特殊流動対応)
    '　　　：2004/10/04 (Mon) 11:36:20 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理追加
    '　　　：2004/10/19 (Tue) 10:45:41 S.Deguchi    「追加流動」処理追加対応
    '　　　：2005/03/02 (Wed) 09:08:27 S.Deguchi    作業終了から遷移する時使用するﾊﾟﾌﾞﾘｯｸ構造体の初期化
    '　　　：2005/06/06 (Mon) 13:01:17 N.Kojima     ﾓｼﾞｭｰﾙ変数の初期化処理追加(不具合№829)
    '　　　：2005/11/24 (Thu) 10:37:23 S.Deguchi    不具合№3248の対応でｵﾌﾗｲﾝFTPﾌﾗｸﾞ処理を追加
    '　　　：2008/06/04 (Wed) 10:33:53 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxEN0060_Init()
        
        Dim llngNowByte         As Integer      'ﾊﾞｲﾄ数を格納
        Dim lstrFormTitle       As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try

            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0060, lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle

            '@ﾊﾟﾌﾞﾘｯｸ構造体の初期化
            ptypWorkEndInfo = New WorkEndInfo ()
            
            '@各ｺﾝﾄﾛｰﾙの初期化
            lblLotID.Text = vbNullString                            'ﾛｯﾄID
            lblFlowClass.Text = vbNullString                        '流動区分
            lblWFNo.Text = vbNullString                             'FW枚数
            lblOpID.Text = vbNullString                             '大工程ID
            lblStartDayTime.Text = vbNullString                     '開始日時
            lblPdID.Text = vbNullString                             '機種名
            lblS.Text = vbNullString                                '特殊特性
            lblStatus.Text = vbNullString                           '状態
            lblStepID.Text = vbNullString                           '小工程ID
            lblLotManager.Text = vbNullString                       'ﾛｯﾄ担当
            lblTimeLimit.Text = vbNullString                        '時間制約
            '@↓2020/01/17 (Fri) 13:47:13 Y.Yoneyama 「.Netへ反映未」 **************************************************
            lblGRB.Text = vbNullString                               'GRB
            '@GRB背景色
            lblGRB.BackColor = lblLotManager.BackColor
            '@↑2020/01/17 (Fri) 13:47:13 Y.Yoneyama 「.Netへ反映未」 **************************************************
            mblnCfkiFlg = False                                     'CFKIﾌﾗｸﾞ(無効)
            mstrWpID = vbNullString                                 '装置ID
            mstrReworkKind = vbNullString                           '特殊流動中ﾌﾗｸﾞ
            mstrRWRouteId = vbNullString                            'ﾘﾜｰｸﾙｰﾄID
            mstrSPRouteId = vbNullString                            '追加ﾙｰﾄID
            mstrLotLastUpdate = vbNullString                        'ﾛｯﾄ最終更新日時
            mstrCarrier = vbNullString                              'ｷｬﾘｱID(ﾒｯｾｰｼﾞ成功時のｷｬﾘｱID)
            mstrWPTYPE = vbNullString                               'WP_TYPE
            mstrMesMode = vbNullString                              '運用ﾓｰﾄﾞ
            mstrFtpDataFlag = vbNullString                          'ｵﾌﾗｲﾝFTPﾌﾗｸﾞ
            
            '@初期化
            optLotNextSend0.Checked  = False                        '「自動送出あり」ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optLotNextSend1.Checked  = False                        '「自動送出なし」ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optLotNextSend2.Checked  = False                        '「リワーク」ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optLotNextSend3.Checked  = False                        '「追加流動」ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            
            '@無効
            optLotNextSend0.Enabled = False        '「自動送出あり」ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optLotNextSend1.Enabled = False        '「自動送出なし」ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optLotNextSend2.Enabled = False        '「リワーク」ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optLotNextSend3.Enabled = False        '「追加流動」ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            
            '@作業ﾒﾓの初期化
            With txtWorkMemo
                .ChrMaxByte = CPlngLotCommentsMaxByte
                .Text = vbNullString
                '@現状のﾊﾞｲﾄ数を格納
                llngNowByte = .NowByte
                '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, CMlngMemoDefault, CPlngLotCommentsMaxByte)
            End With

            If IsNothing(Me.ActiveControl) Or (Not IsNothing(Me.ActiveControl) AndAlso ActiveControl.Name <> cmdCommentDown.Name) Then
                '@ｺﾒﾝﾄの初期化
                With txtLotCommnt
                  .ChrMaxByte = CPlngLotCommentsMaxByte
                  .Text = vbNullString                            'ﾛｯﾄｺﾒﾝﾄ
                  .MultiLineEx = True                             'ﾛｯﾄｺﾒﾝﾄ複数行表示
                 End With
            End If
            
            '@ﾛｯﾄｺﾒﾝﾄ設定
            With txtLotCommnt
                '@背景色(ｸﾞﾚｰ)
                .BackColor = SystemColors.ControlLight
                .GotBackColor = SystemColors.ControlLight'@ﾛｯｸ
                .Locked = True
            End With
            
            If IsNothing(Me.ActiveControl) Or (Not IsNothing(Me.ActiveControl) AndAlso ActiveControl.Name <> cmdNextDown.Name) Then
                '@次工程ｸﾞﾘｯﾄﾞの初期化
                Call prvVsfNextStepInfo_Init()
            End if
            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvfrmxxEN0060_Init"    '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN0060_CmbInit
    '機　能：各種ﾎﾞﾀﾝの制御処理
    '引　数：lblnEnable：True:使用可能,False:使用不可
    '戻り値：なし
    '作成日：2004/03/08 (Mon) 16:15:05 T.Kitagawa
    '更新日：2005/11/29 (Tue) 16:22:08 N.Kasai
    '備　考：
    '　　　：2004/08/26 (Thu) 19:17:46 M.Miura　    次工程送出ｺﾝﾎﾞ制御削除(ｵﾌﾟｼｮﾝﾎﾞﾀﾝに変更の為)
    '　　　：2004/09/22 (Wed) 22:12:21 H.Wajima     流動ﾀｲﾌﾟの判定処理追加(№891)
    '　　　：2004/10/18 (Mon) 16:04:05 N.Kojima     WF処置・ﾁｯﾌﾟ処置ﾎﾞﾀﾝ制御追加(不具合№124)
    '　　　：2004/10/26 (Tue) 11:17:31 N.Kojima     対向基板処置登録ﾎﾞﾀﾝ制御追加(不具合№124)
    '　　　：2004/10/28 (Thu) 14:33:08 Y.Yamagishi  lblnEnable=Falseの場合CFKI作業終了ﾎﾞﾀﾝ,TPAL張り合わせ登録ﾎﾞﾀﾝ,対向基板ﾘﾜｰｸ不良ﾎﾞﾀﾝを無効
    '　　　：2004/11/19 (Fri) 16:36:31 S.Deguchi    CFKI作業終了ﾎﾞﾀﾝ制御修正(ｺﾝﾄﾛｰﾙ名がTPALになっていた)
    '　　　：2005/11/29 (Tue) 16:22:08 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2009/06/15 (Mon) 17:24:16 T.Oide       無機対応｢CF移載情報｣ﾎﾞﾀﾝ追加
    Private Sub prvfrmxxEN0060_CmbInit(Optional ByVal lblnEnable As Boolean = False)

        Try

            '@流動ﾀｲﾌﾟの判定
            If ptypLotprestate.strFlowType = CPstrLotCurstateFlowTypeMove Then
            '@移載工程の場合
                '@ｼｽﾃﾑﾌﾞﾛｯｸにより表示・非表示を変更
                Select Case pstrSBID
                    Case CPstrSBID1A0
                        '@基板工程の場合
                        cmdCFKIWorkEnd.Visible = False              'CFKI作業終了
                        cmdTpalCombRegist.Visible = False           'TPAL貼り合せ登録
                        cmdTreatCF.Visible = False                  '対向基板ﾘﾜｰｸ不良
                        cmdTreatWF.Enabled = lblnEnable             'WF　保留／不良／払出
                        cmdTreatChip.Enabled = lblnEnable           'ﾁｯﾌﾟ　保留／不良／払出

                        '@↓2009/06/15 (Mon) 17:05:54 T.Oide **************************************************
                        cmdCFMove.Visible = False                     'CF移載情報入力
                        '@↑2009/06/15 (Mon) 17:05:54 T.Oide **************************************************
                        
                        cmdODF.Visible = False                        'ODF貼り合せ登録
                        
                    Case CPstrSBID2A0
                        '@組立工程の場合
                        cmdCFKIWorkEnd.Visible = True               'CFKI作業終了
                        cmdTpalCombRegist.Visible = True            'TPAL貼り合せ登録
                        cmdTreatCF.Visible = True                   '対向基板ﾘﾜｰｸ不良
                        
                        '@↓2009/06/15 (Mon) 17:05:54 T.Oide **************************************************
                        cmdCFMove.Visible = True                     'CF移載情報入力
                        '@↑2009/06/15 (Mon) 17:05:54 T.Oide **************************************************
                        
                         cmdODF.Visible = True                        'ODF貼り合せ登録
                        
                        '@有効の場合
                        If lblnEnable = True Then
                            '@ｷｬﾘｱﾀｲﾌﾟが空の場合
                            If ptypLotprestate.strCarrierTypeID <> vbNullString Then
                                '@CF・TPALの場合は、非表示
                                If ptypLotprestate.strCarrierTypeID <> CMstrCFCarrier And _
                                    ptypLotprestate.strCarrierTypeID <> CMstrTPALCarrier Then
                                    '@WF処置・ﾁｯﾌﾟ処置ﾎﾞﾀﾝ有効
                                    cmdTreatWF.Enabled = True           'WF処置登録
                                    cmdTreatChip.Enabled = True         'ﾁｯﾌﾟ処置登録
                                Else
                                    '@WF処置・ﾁｯﾌﾟ処置ﾎﾞﾀﾝ無効
                                    cmdTreatWF.Enabled = False          'WF　保留／不良／払出
                                    cmdTreatChip.Enabled = False        'ﾁｯﾌﾟ　保留／不良／払出
                                End If
                            Else
                                cmdTreatWF.Enabled = False              'WF　保留／不良／払出
                                cmdTreatChip.Enabled = False            'ﾁｯﾌﾟ　保留／不良／払出
                            End If
                        Else
                            cmdTreatWF.Enabled = False                  'WF　保留／不良／払出
                            cmdTreatChip.Enabled = False                'ﾁｯﾌﾟ　保留／不良／払出
                        End If
                End Select
                
                '@確定、閉じる以外のﾎﾞﾀﾝは使用不可
                cmdTreatCF.Enabled = False              '対向基板ﾘﾜｰｸ不良
                cmdCFKIWorkEnd.Enabled = False          'CFKI作業終了入力
                cmdTpalCombRegist.Enabled = False       'TPAL貼り合せ登録
                cmdActionDisp.Enabled = False           'ｱｸｼｮﾝ予約確認
                cmdCommntInput.Enabled = False          'ﾛｯﾄｺﾒﾝﾄ
                cmdCollectionInfo.Enabled = False       '装置ﾃﾞｰﾀ登録/参照
                cmdTrouble.Enabled = False              '異常処理票起案
                
                '@↓2009/06/15 (Mon) 17:05:54 T.Oide **************************************************
                cmdCFMove.Visible = False                     'CF移載情報入力
                '@↑2009/06/15 (Mon) 17:05:54 T.Oide **************************************************
                
                cmdODF.Enabled = False                  'ODF貼り合せ登録
                
                '@作業ﾒﾓ使用不可
                txtWorkMemo.Enabled = False             '作業ﾒﾓ
                cmdMemoUp.Enabled = False               '作業ﾒﾓ▲
                cmdMemoDown.Enabled = False             '作業ﾒﾓ▼
                
                '@次工程送出あり固定
                optLotNextSend0.Checked = 1        '送出なし
                optLotNextSend1.Enabled = False    '送出なし
                optLotNextSend2.Enabled = False    'ﾘﾜｰｸ
                optLotNextSend3.Enabled = False    '追加流動
                
            Else
            '@移載工程以外の場合
                '@ｼｽﾃﾑﾌﾞﾛｯｸにより表示・非表示を変更
                Select Case pstrSBID
                    Case CPstrSBID1A0
                        '@基板工程の場合
                        cmdTreatCF.Visible = False                  '対向基板ﾘﾜｰｸ不良
                        cmdCFKIWorkEnd.Visible = False              'CFKI作業終了
                        cmdTpalCombRegist.Visible = False           'TPAL貼り合せ登録
                        cmdTreatWF.Enabled = lblnEnable             'WF　保留／不良／払出
                        cmdTreatChip.Enabled = lblnEnable           'ﾁｯﾌﾟ　保留／不良／払出
                        
                        '@↓2009/06/15 (Mon) 17:05:54 T.Oide **************************************************
                        cmdCFMove.Visible = False                     'CF移載情報入力
                        '@↑2009/06/15 (Mon) 17:05:54 T.Oide **************************************************
                        
                        cmdODF.Visible = False                      'ODF貼り合せ登録

                    Case CPstrSBID2A0
                        '@組立工程の場合
                        cmdCFKIWorkEnd.Visible = True               'CFKI作業終了
                        cmdTpalCombRegist.Visible = True            'TPAL貼り合せ登録
                        cmdTreatCF.Visible = True                   '対向基板ﾘﾜｰｸ不良
                        
                        '@↓2009/06/15 (Mon) 17:05:54 T.Oide **************************************************
                        cmdCFMove.Visible = True                     'CF移載情報入力
                        '@↑2009/06/15 (Mon) 17:05:54 T.Oide **************************************************
                        
                        cmdODF.Visible = True                       'ODF貼り合せ登録
                        
                        '@無効の場合
                        If lblnEnable = False Then
                            '@CFKI作業終了ﾎﾞﾀﾝ無効
                            cmdCFKIWorkEnd.Enabled = False
                            '@TPAL張り合わせ登録ﾎﾞﾀﾝ無効
                            cmdTpalCombRegist.Enabled = False
                            '@対向基板ﾘﾜｰｸ不良ﾎﾞﾀﾝ無効
                            cmdTreatCF.Enabled = False
                            
                            '@ODF貼り合せ登録ﾎﾞﾀﾝ無効
                            cmdODF.Enabled = False
                        End If
                        
                        '@有効の場合
                        If lblnEnable = True Then
                            '@ｷｬﾘｱﾀｲﾌﾟが空以外の場合
                            If ptypLotprestate.strCarrierTypeID <> vbNullString Then
                                '@CF・TPALの場合は、非表示
                                If ptypLotprestate.strCarrierTypeID <> CMstrCFCarrier And _
                                    ptypLotprestate.strCarrierTypeID <> CMstrTPALCarrier Then
                                    '@WF処置・ﾁｯﾌﾟ処置ﾎﾞﾀﾝ有効
                                    cmdTreatWF.Enabled = True              'WF処置登録
                                    cmdTreatChip.Enabled = True            'ﾁｯﾌﾟ処置登録
                                Else
                                    '@WF処置・ﾁｯﾌﾟ処置ﾎﾞﾀﾝ無効
                                    cmdTreatWF.Enabled = False              'WF　保留／不良／払出
                                    cmdTreatChip.Enabled = False            'ﾁｯﾌﾟ　保留／不良／払出
                                End If
                            Else
                                cmdTreatWF.Enabled = False                  'WF　保留／不良／払出
                                cmdTreatChip.Enabled = False                'ﾁｯﾌﾟ　保留／不良／払出
                            End If
                        Else
                            cmdTreatWF.Enabled = False                      'WF　保留／不良／払出
                            cmdTreatChip.Enabled = False                    'ﾁｯﾌﾟ　保留／不良／払出
                        End If
                        
                End Select
                
                '@各ｺﾏﾝﾄﾞﾎﾞﾀﾝのｺﾝﾄﾛｰﾙ
                cmdActionDisp.Enabled = lblnEnable          'ｱｸｼｮﾝ予約確認
                cmdCollectionInfo.Enabled = lblnEnable      '装置ﾃﾞｰﾀ登録/参照
                cmdCommntInput.Enabled = lblnEnable         'ﾛｯﾄｺﾒﾝﾄ入力
                cmdTrouble.Enabled = lblnEnable             '異常処理票登録
                cmdTreatCF.Enabled = lblnEnable             '対向基板ﾘﾜｰｸ不良
                
                '@作業ﾒﾓの制御
                txtWorkMemo.Enabled = lblnEnable
                
            End If
            
            '@各ｺﾏﾝﾄﾞﾎﾞﾀﾝのｺﾝﾄﾛｰﾙ
            cmdRegist.Enabled = lblnEnable              '作業開始
            
            '@ｺﾒﾝﾄ欄の制御
            txtLotCommnt.Enabled = lblnEnable
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxEN0060_CmbInit"     '処理名
                .strErrMessage = ""                         'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN0060_Disp
    '機　能：画面の表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/03 (Wed) 18:22:50 T.Kitagawa
    '更新日：2008/06/04 (Wed) 10:34:39 N.Kojima
    '備　考：
    '　　　：2004/08/25 (Wed) 13:33:32 N.Kasai      CFﾌﾗｸﾞ判定追加、"mm/dd hh:mm:ss"を共通変数化
    '　　　：2004/09/01 (Wed) 08:54:38 M.Miura      特殊流動中ﾌﾗｸﾞ追加(特殊流動対応)
    '　　　：2004/09/09 (Thu) 20:06:39 Y.Yamagishi　時間制限表示変更(不具合改善№693)
    '　　　：2004/09/14 (Tue) 10:28:44 N.Kojima　   数量表示(TPALﾛｯﾄ対応)修正(不具合改善№730)
    '　　　：2004/09/24 (Fri) 10:28:25 Y.Yamagishi  制限時間以上の場合文字色を青に変更(不具合改善№825)
    '　　　：2004/10/19 (Tue) 10:45:41 S.Deguchi    「追加流動」処理追加対応
    '　　　：2004/10/26 (Tue) 16:41:10 N.Kojima　   ﾁｯﾌﾟ枚数が"0"枚の時、ﾗﾍﾞﾙに"0"を表示するように修正
    '　　　：2005/05/19 (Thu) 15:16:13 S.Deguchi    不具合№640の対応で,ReworkFlagの退避を修正
    '　　　：2005/05/26 (Thu) 14:08:00 N.Kasai      LP_FLAG追加
    '　　　：2005/11/24 (Thu) 10:37:23 S.Deguchi    不具合№3248の対応でｵﾌﾗｲﾝFTPﾌﾗｸﾞ処理を追加
    '　　　：2006/06/13 (Tue) 18:54:02 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2008/06/04 (Wed) 10:34:39 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxEN0060_Disp(ByRef ltypLotCurState As Lotprestate)

        Try

            '@ﾛｯﾄ情報の表示
            With ltypLotCurState
                lblLotID.Text = .strLotID                                                   'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass                                           '流動区分
                lblOpID.Text = .strOpID                                                     '大工程ID
                If IsDate(.strStartTime) Then
                  lblStartDayTime.Text = Format$(CDate(.strStartTime), CPstrDateFormat)     '開始日時"mm/dd hh:mm:ss"
                Else
                  lblStartDayTime.Text = .strStartTime
                End If 
                lblPdID.Text = .strPdId                                                     '機種名
                lblS.Text = .strSpecialFlg                                                  '特殊特性
                lblStatus.Text = .strNowST                                                  '状態
                lblStepID.Text = .strStepID                                                 '小工程ID
                lblLotManager.Text = .strEngEmpName                                         'ﾛｯﾄ担当
                '@↓2020/01/17 (Fri) 13:48:18 Y.Yoneyama 「.Netへ反映未」 **************************************************
                lblGRB.Text = .strGRBClass                                                  'GRB
                '@GRB背景色
                lblGRB.BackColor = pubGRBBackColor(.strGRBClass, lblLotManager.BackColor)
                '@↑2020/01/17 (Fri) 13:48:18 Y.Yoneyama 「.Netへ反映未」 **************************************************
                mstrFtpDataFlag = .strFtpDataFlag                                           'ｵﾌﾗｲﾝFTPﾌﾗｸﾞ
                
                '@時間制約有無の表示
                If .strLimitTime <> vbNullString Then
                    '@時間制約がﾌﾟﾗｽの場合
                    If CLng(.strLimitTime) >= 0 Then
                        
                        '@制限時間以下or処理時間制限以下の場合
                        '@処理時間制限以下設定の場合、基本的に処理中で処理出来る機能しか関係ないが例外処理として挿入
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@制限時間先大工程+制限時間先小工程+制限時間
                            '@ﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Format(CLng(.strLimitTime), CPstrDateFormatKanma) & CPstrh
                            '@右寄せ
                            lblTimeLimit.TextAlign = ContentAlignment.MiddleRight
                            
                            '@警告時間が設定されている場合
                            If .strWarnTime <> vbNullString Then
                                '@時間制限が警告時間を過ぎている,且つ制限時間がｵｰﾊﾞｰしていない場合
                                If CLng(.strWarnTime) < 0 And CLng(.strLimitTime) >= 0 Then
                                    '@ﾌｫﾝﾄｶﾗｰを紫に変更
                                    lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple)  '紫色
                                Else
                                     '@ﾌｫﾝﾄｶﾗｰを黒に変更
                                    lblTimeLimit.ForeColor = Color.Black  '黒
                                End If
                            End If
                        End If
                        
                    Else
                    '@制限時間がﾏｲﾅｽの場合
                        '@制限時間先大工程+制限時間先小工程+制限時間
                        '@右寄せ
                        lblTimeLimit.TextAlign = ContentAlignment.MiddleRight
                        '@ForColorの変更
                        lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed)  '赤色
                        
                        '@制限時間以下or処理時間制限以下の場合
                        '@処理時間制限以下設定の場合、基本的に処理中で処理出来る機能しか関係ないが例外処理として挿入
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@ﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Format(CLng(.strLimitTime), CPstrDateFormatKanma) & CPstrh
                        End If
                        
                        '@制限時間以上の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID2 Then
                            '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Replace(Format(.strLimitTime, CPstrDateFormatKanma), CPstrReplaceMinus, vbNullString) & CPstrh
                        End If
                    End If
                End If
                        
                txtLotCommnt.Text = .strComments                                        'ﾛｯﾄｺﾒﾝﾄ
                mstrLotLastUpdate = .strLotLastUpdate                                   'ﾛｯﾄ最終更新日時
                mstrMasPDVersion = .strMasPdVersion                                     '工順ﾊﾞｰｼﾞｮﾝ
                mstrRWRouteId = .strReworkRouteID                                       'ﾘﾜｰｸﾙｰﾄID
                mstrReworkFinishFlag = Mid(.strReworkFlag, CMlngReworkLen1, CMlngReworkLen1)    '0:通常工程/1:最終工程
                mstrReworkKind = Mid(.strReworkFlag, CMlngReworkLen2, CMlngReworkLen1)          '0:通常/1:部分ﾘﾜｰｸ/3:全数ﾘﾜｰｸ
                mstrReworkFlag = Mid(.strReworkFlag, CMlngReworkLen3, CMlngReworkLen1)          '0:通常/1:ﾘﾜｰｸ/2:追加流動
                mstrSPRouteId = .strSpecialRouteID                                      '追加ﾙｰﾄID
                mstrWPTYPE = .strWpTypeFlag                                             'WP_TYPE

                '@枚数表示判定(CF_FLAGを判定し、WF枚数とﾁｯﾌﾟ枚数の表示を切替)
                Select Case .strCfFlag
                    '@CFﾛｯﾄ
                    Case CPstrCF
                        '@大判ﾌﾗｸﾞ判定(LP_FLAG)
                        If .strLpFlag = CPstrLP Then
                            '@大判の場合
                            lblWFNo.Text = .strWfNum                                         'WF枚数
                        Else
                            If IsNumeric(.strChipQuantity) Then
                                lblWFNo.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)      'ﾁｯﾌﾟ枚数
                            Else
                                lblWFNo.Text = .strChipQuantity
                            End If
                        End If
                    
                    Case Else
                    '@CFﾛｯﾄ以外
                        '@TPALﾛｯﾄ
                        If Trim(Strings.Left(.strLotID, 2)) = CPstrTpalLot Then
                            lblWFNo.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)      'ﾁｯﾌﾟ枚数
                        Else
                            '@CF,TPALﾛｯﾄ以外
                            lblWFNo.Text = .strWfNum                                         'WF枚数
                        End If
                End Select
                
                '@装置ﾀｲﾌﾟがCFKIの場合
                If .strEqType = CPstrEqTypeCFKI Then
                    '@CFKIﾌﾗｸﾞ(有効)
                    mblnCfkiFlg = True
                Else
                    '@CFKIﾌﾗｸﾞ(無効)
                    mblnCfkiFlg = False
                End If

            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvfrmxxEN0060_Disp"    '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnInput_Chk
    '機　能：確定ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/10 (Wed) 13:50:14 T.Oide
    '更新日：2005/12/27 (Tue) 13:18:19 N.Kojima
    '備　考：
    '　　　：2005/01/31 (Mon) 15:22:04 N.Kasai      KRFﾌｧｲﾙ名の設定有無判定を追加
    '　　　：2005/03/03 (Thu) 12:42:35 S.Deguchi    ﾊﾝﾄﾞﾜｰｸ工程の確定ﾁｪｯｸを追加
    '　　　：2005/12/27 (Tue) 13:18:19 N.Kojima     ﾚｽﾎﾟﾝｽ関数の引数を定数化。
    Private Function prvblnInput_Chk() As Boolean
        
        Dim ltypLotDetailInfo           As LotDetailInfo        'ﾛｯﾄ詳細情報構造体
        Dim lblnAns                     As Boolean              '結果取得(True:正常,False:異常)
        Dim llngAns                     As Integer              'KRFｲﾝﾌｫﾒｰｼｮﾝ戻り値
        '@↓2020/03/19 (Thu) 19:18:07 Y.Yoneyama 「.Netへ反映未」 **************************************************
        Dim lstrGuidMsg                 As String
        Dim lstrGuidMsgCode             As String
        Dim lstrPanelInspectType        As String
        '@↑2020/03/19 (Thu) 19:18:07 Y.Yoneyama 「.Netへ反映未」 **************************************************

        Try

            prvblnInput_Chk = False
            
            '@ｷｬﾘｱIDの入力ﾁｪｯｸ
            If txtCarrier.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                
                '@失敗ﾒｯｾｰｼﾞ表示("キャリアIDが設定されていません。設定を見直してください。")
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Call pubSetFocus(txtCarrier)
                
                Exit Function
            End If
            '@ｷｬﾘｱIDが6桁であるかﾁｪｯｸ
            If Len(txtCarrier.Text) <> CMlngCarrierMaxLength Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Call pubSetFocus(txtCarrier)

                Exit Function
            End If
            
            '@状態ﾁｪｯｸ
            If mstrWPTYPE = CMstrHandWork Then
                If lblStatus.Text <> CPstrProcessingSt Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0020)
                    
                    '@publngMsgBoxInfo("メッセージコード：C_I12%0$$「処理中」以外のロット[ %2 ]は終了できません。キャリア[ %1 ]")
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                    Call pubSetFocus(txtCarrier)
                    
                    Exit Function
                End If
            Else
                If lblStatus.Text <> CPstrAfterProgressSt Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0012)
                    
                    '@publngMsgBoxInfo("メッセージコード：C_I12%0$$「後処理」以外のロット[ %2 ]は終了できません。キャリア[ %1 ]")
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                    Call pubSetFocus(txtCarrier)
                    
                    Exit Function
                End If
            End If

            '@ﾊﾟﾀｰﾝ検査機の場合のみ
            If ptypLotprestate.strEqType = CPstrEqTypeKRF Then
            
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrInputChk)
            
                '@KRFﾌｧｲﾙ名の取得
                '@ﾛｯﾄ詳細情報の取得
                lblnAns = pubblnLotDetail_Sel(CMstrlot_detail__Ver, pstrSBID, CPstrCD0K, vbNullString, txtCarrier.Text, ltypLotDetailInfo)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrInputChk)
                    Exit Function
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrInputChk)
                
                '@KRFﾌｧｲﾙ設定有無の判定
                If ltypLotDetailInfo.strKrfFileName = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004D)
                    
                    '@"<TRM4DI>$$ＫＲＦファイルが未設定です。処理を継続しますか？"
                    llngAns = publngMsgBox(pstrDMsg & vbCrLf, vbNo, Me.Text, True, 16, False)
                    
                    '@ﾒｯｾｰｼﾞﾎﾞｯｸｽの戻り値判定
                    Select Case llngAns
                        Case vbNo       '「いいえ」を選択
                            Call pubSetFocus(txtCarrier)
                            
                            Exit Function
                    End Select
                End If
            End If
            
            '@↓2020/03/19 (Thu) 19:05:02 Y.Yoneyama 「.Netへ反映未」 **************************************************
            '@ﾊﾟﾈﾙ検査の場合
            If Mid$(ptypLotprestate.strWpID, 1, 7) = CPstrPakenWpId Then
        
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrInputChk)
                
                '@=======================
                '@ 抜取・全数確認処理
                '@=======================
                '@【抜取・全数ﾁｪｯｸ】ﾒｯｾｰｼﾞ送受信処理
                lblnAns = pubblnLotExclusionProcess_Chk(CMstrlot_chkexclusionprocessVer, _
                                                                ptypLotprestate.strLotID, _
                                                                lstrGuidMsg, _
                                                                lstrGuidMsgCode, _
                                                                lstrPanelInspectType)
    
                '@抜取・全数ﾁｪｯｸ結果が"True：ﾁｪｯｸ処理成功"か
                If lblnAns = True Then
                
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrInputChk)
            
                    '@全数検査実施の再確認
                    If lstrPanelInspectType = CPstrPanelInspectAll Then
            
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf007X)
                
                        '@"<TRM7XI>$$全数検査を実施しましたか？"
                        llngAns = publngMsgBox(pstrDMsg & vbCrLf, vbNo, Me.Text, True, 16, False)
            
                        '@ﾒｯｾｰｼﾞﾎﾞｯｸｽの戻り値判定
                        Select Case llngAns
                            Case vbNo       '「いいえ」を選択
                                Call pubSetFocus(txtCarrier)
                        
                                Exit Function
                        End Select
                    End If
                
                '@結果：異常の場合
                Else
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrInputChk)
                End If
            End If
            '@↑2020/03/19 (Thu) 19:05:02 Y.Yoneyama 「.Netへ反映未」 **************************************************

            '@入力ＯＫ
            prvblnInput_Chk = True
            
            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "prvblnInput_Chk"        '処理名
                .strErrMessage = ""                             'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvActionList_Disp
    '機　能：ｱｸｼｮﾝ予約表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/09 (Tue) 18:17:27 T.Oide
    '更新日：2005/12/27 (Tue) 13:15:40 N.Kojima
    '備　考：
    '　　　：2004/09/30 (Thu) 16:13:06 S.Deguchi    ｱｸｼｮﾝ予約を送る機種を修正(2A0用)
    '　　　：2004/10/04 (Mon) 16:27:28 H.Wajima     入力項目ﾁｪｯｸを削除(入力ﾊﾟﾗﾒｰﾀが空の場合はｻｰﾊﾞ側及び確定ﾎﾞﾀﾝ等のﾁｪｯｸに依存させる)
    '　　　：2005/12/27 (Tue) 13:15:40 N.Kojima     ﾚｽﾎﾟﾝｽ関数の引数を定数化。
    Private Sub prvActionList_Disp()
        
        Dim lblnAns                 As Boolean          'ｱｸｼｮﾝ予約ﾘｽﾄ取得結果格納
        Dim llngCnt                 As Integer          'ｶｳﾝﾄ

        Try

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrActionListDisp)
            
            '@ｱｸｼｮﾝ予約ﾘｽﾄ取得
            ptypLotAction.lnglstCnt = 0
            ptypLotAction.strActionFlag = vbNullString
            If ptypLotAction .typLotActList Is Nothing Then 
                ptypLotAction.typLotActList = New List(Of LotActList) 
            Else 
                ptypLotAction.typLotActList.Clear()
            End If

            lblnAns = pubblnLotActList_Sel(CMstrlot_actlist_Ver, lblLotID.Text, lblOpID.Text, lblStepID.Text, _
                                           lblPdID.Text, mstrMasPDVersion, mstrWpID, ptypLotAction)
            
            '@取得に成功したら表示(ｱｸｼｮﾝ予約ﾘｽﾄが0件の場合は何も表示しない)
            If lblnAns = True Then
                If ptypLotAction.lnglstCnt > 0 Then
                    With ptypLotAction
                        Dim typLotActListmp As LotActList
                        '@ｱｸｼｮﾝ予約がなくなるまで
                        For llngCnt = 0 To .lnglstCnt-1
                            typLotActListmp = ptypLotAction.typLotActList(llngCnt)
                            typLotActListmp.strLotID = lblLotID.Text             'ﾛｯﾄID
                            typLotActListmp.strFlowClass = lblFlowClass.Text     '流動区分
                            '@ｱｸｼｮﾝ予約ﾀｲﾌﾟ判定
                            Select Case .typLotActList(llngCnt).strLotActionTypeID
                                '@ﾛｯﾄの場合
                                Case CPstrLotActionTypeID0
                                    typLotActListmp.strLotActionTypeName = CPstrActTypeLOT     'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
                                '@機種の場合
                                Case CPstrLotActionTypeID1
                                   typLotActListmp.strLotActionTypeName = CPstrActTypePD       'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
                                '@装置の場合
                                Case CPstrLotActionTypeID2
                                   typLotActListmp.strLotActionTypeName = CPstrActTypeWP       'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
                                '@特定工程の場合
                                Case CPstrLotActionTypeID3
                                   typLotActListmp.strLotActionTypeName = CPstrActTypeTStep    'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
                            End Select
                            typLotActListmp.strActionTrigger = CMstrEN0060Title                'ｱｸｼｮﾝﾄﾘｶﾞｰ
                            typLotActListmp.strOpID = lblOpID.Text                             '大工程
                            typLotActListmp.strStepID = lblStepID.Text                         '小工程
                            'NSYS ｱｸｼｮﾝ予約ﾘｽﾄに値を格納
                            ptypLotAction .typLotActList(llngCnt) = typLotActListmp
                        Next llngCnt
                    End With
                    
                    '@ﾛｯｸ解除
                    cmdActionDisp.Enabled = True
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrActionListDisp)
                    
                    '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ画面名称設定
                    frmxxCM0040.Instance.Text = CPstrSubDispTitleActionMsg
                    
                    '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ表示画面を表示(ptypLotActionの情報でｱｸｼｮﾝ予約の内容を表示)
                    frmxxCM0040.Instance.ShowDialog(Me)
                    frmxxCM0040.Instance = Nothing
                Else
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrActionListDisp)
                    
                    '@ﾛｯｸ
                    cmdActionDisp.Enabled = False
                End If
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrActionListDisp)
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvActionList_Disp"     '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfNextStepInfo_Init
    '機　能：次工程情報一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/17 (Mon) 14:42:21 H.Wajima
    '更新日：2005/11/29 (Tue) 15:11:43 N.Kasai
    '備　考：
    '　　　：2005/11/29 (Tue) 15:11:43 N.Kasai      ｽｸﾛｰﾙﾎﾞﾀﾝｻｲｽﾞ変更
    Private Sub prvVsfNextStepInfo_Init()

        Try

            With vsfNextStepInfo
                '@ﾌﾟﾛﾊﾟﾃｨ初期値
                .Clear
                .Cols.Count = CMlngNextStepInfoColWPID + 1
                .Rows.Count = CMlngGridFixedRows
                .Cols.Fixed = CMlngGridFixedCols
                .Rows.Fixed = CMlngGridFixedRows
                .SelectionMode = SelectionModeEnum.RowRange
                '.FillStyle = flexFillRepeat
                .FocusRect = FocusRectEnum.None
                .HighLight = HighLightEnum.Never
                .Font = New Font(CMstrGridFontName, CMlngGridFontSize,.Font.Style)
                .ScrollBars = ScrollBars.None
                .Width = CMlngGridWidth
                .Height = CMlngGridHeight
                
                '@表示位置の設定(ﾃﾞﾌｫﾙﾄ)
                .Cols(CMlngNextStepInfoColDefault).TextAlign = TextAlignEnum.LeftCenter    '@左中央寄せ
                
                '@ｸﾞﾘｯﾄﾞの表題設定
                .Select(CMlngGridRowTitle, CMlngNextStepInfoColOpID, CMlngGridRowTitle, CMlngNextStepInfoColWPID)

                Dim headerSellRange = .GetCellRange(CMlngGridRowTitle, CMlngNextStepInfoColOpID, CMlngGridRowTitle, CMlngNextStepInfoColWPID)
                Dim headerStyle = .Styles.Add("headerStyle")

                headerStyle.ForeColor = Color.Yellow                                    '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)       '背景色
                headerStyle.Font = New Font(.Font.Name, CMlngGridFontSize, .Font.Style) 'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                      '文字位置

                headerSellRange.Style = headerStyle
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngGridRowTitle, CMlngNextStepInfoColOpID, CMstrNextStepInfoColTOpID)          '大工程ID
                .SetData(CMlngGridRowTitle, CMlngNextStepInfoColStepID, CMstrNextStepInfoColTStepID)      '小工程ID
                .SetData(CMlngGridRowTitle, CMlngNextStepInfoColDefault, CMstrNextStepInfoColTDefault)    'ﾃﾞﾌｫﾙﾄ
                .SetData(CMlngGridRowTitle, CMlngNextStepInfoColWPID, CMstrNextStepInfoColTWPID)          'WPID
                
                '@列幅の設定
                .Cols(CMlngNextStepInfoColOpID).Width = CMlngGridColWidthOpID          '大工程ID
                .Cols(CMlngNextStepInfoColStepID).Width = CMlngGridColWidthStepID      '小工程ID
                .Cols(CMlngNextStepInfoColDefault).Width = CMlngGridColWidthDefault    'ﾃﾞﾌｫﾙﾄ
                .Cols(CMlngNextStepInfoColWPID).Width = CMlngGridColWidthWPID          'WPID
                
                '@結合セルの設定
                .AllowMerging = AllowMergingEnum.RestrictAll
                .Cols(CMlngNextStepInfoColOpID).AllowMerging = True
                .Cols(CMlngNextStepInfoColStepID).AllowMerging = True
                .Cols(CMlngNextStepInfoColDefault).AllowMerging = True

                '@ﾀｲﾄﾙの高さ
                .Rows(CMlngGridRowTitle).Height = CMlngGridTitleHeight
                
                '@ﾛｯｸ
                .Enabled = False
            
                '@ｽｸﾛｰﾙﾎﾞﾀﾝの表示初期化
                Call pubVsfDisp(vsfNextStepInfo, cmdNextUP, cmdNextDown)
            
            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "prvvsfNextStepInfo_Init"        '処理名
                .strErrMessage = ""                             'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfNextStepInfo_Disp
    '機　能：次工程ｸﾞﾘｯﾄﾞの表示処理
    '引　数：ltypLotNextStep：次工程格納構造体
    '　　　：llngCnt：格納ｶｳﾝﾄ
    '戻り値：なし
    '作成日：2004/05/18 (Tue) 12:31:33 N.Kasai
    '更新日：2004/05/19 (Wed) 10:42:55 H.Wajima
    '備　考：
    Private Sub prvVsfNextStepInfo_Disp(ByRef ltypLotNextStep As LotNextStep, _
                                        ByVal llngCnt As Integer)
        
        Dim lllngWPListCnt  As Integer  'WPListCntカウンタ
        Dim llngStepCnt     As Integer
        Dim llngRowCnt      As Integer  '行ｶｳﾝﾀ

        Try
            '@一覧表示
            With vsfNextStepInfo
                '@描画ﾛｯｸ
                .Redraw = False

                '@ｶｳﾝﾀの初期化
                llngRowCnt = .Rows.Fixed

                '@ｸﾞﾘｯﾄﾞの明細行ﾙｰﾌﾟ
                For llngStepCnt = 0 To llngCnt-1
                    For lllngWPListCnt = 0 To ltypLotNextStep.strNextStepList(llngStepCnt).lngWPListCnt-1
                        '@行数の設定
                        .Rows.Count = llngRowCnt + 1

                        '@大工程
                        .SetData(llngRowCnt, CMlngNextStepInfoColOpID, ltypLotNextStep.strNextStepList(llngStepCnt).strNextOpID)

                        '@小工程
                        .SetData(llngRowCnt, CMlngNextStepInfoColStepID, ltypLotNextStep.strNextStepList(llngStepCnt).strNextStepID)

                        '@ﾃﾞﾌｫﾙﾄ
                        Select Case ltypLotNextStep.strNextStepList(llngStepCnt).strStepDivision
                            Case "0"
                                .SetData(llngRowCnt, CMlngNextStepInfoColDefault, CMstrDaitaiStep)
                            Case "1"
                                .SetData(llngRowCnt, CMlngNextStepInfoColDefault, CMstrDefaultStep)
                            Case Else
                                .SetData(llngRowCnt, CMlngNextStepInfoColDefault, vbNullString)
                        End Select

                        '@装置
                        .SetData(llngRowCnt, CMlngNextStepInfoColWPID, ltypLotNextStep.strNextStepList(llngStepCnt).strWPList(lllngWPListCnt).strWPName)

                        '@明細の行の高さ
                        .Rows(llngRowCnt).Height = CMlngGridRowHeight

                        '@ｶｳﾝﾀのｲﾝｸﾘﾒﾝﾄ
                        llngRowCnt = llngRowCnt + 1
                    Next lllngWPListCnt
                Next llngStepCnt

                '@ﾀｲﾄﾙの行の高さ
                .Rows(CMlngGridRowTitle).Height = CMlngGridTitleHeight

                '@描画の再開
                .Redraw = True

                '@ｽｸﾛｰﾙﾎﾞﾀﾝの表示初期化
                Call pubVsfDisp(vsfNextStepInfo, cmdNextUP, cmdNextDown)

            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "prvvsfNextStepInfo_Disp"        '処理名
                .strErrMessage = ""                             'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmdRegist_Set
    '機　能：確定ﾎﾞﾀﾝの有効/無効制御
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/18 (Mon) 11:33:45 M.Miura
    '更新日：2005/05/24 (Tue) 14:47:31 N.Kasai
    '備　考：
    '　　　：2004/10/19 (Tue) 10:45:41 S.Deguchi    「追加流動」処理追加対応
    '　　　：2004/11/08 (Mon) 13:41:43 M.Miura      TPAL条件の定数を修正(不具合№208)
    '　　　：2005/05/24 (Tue) 14:47:31 N.Kasai      ODF条件追加
    Private Sub prvcmdRegist_Set()
        
        Dim lblnFlag    As Boolean 'True：確定可、False：確定不可
        
        Try

            With ptypLotprestate
                '@EQ_TYPE判定
                Select Case .strEqType
                    '@CFKIの場合
                    Case CPstrEqTypeCFKI
                        '@1；CFﾛｯﾄ確定可能の場合
                        If .strCfCompFlag = CPstrCOMP Then
                            '@確定ﾌﾗｸﾞ(確定可)
                            lblnFlag = True
                        End If
                        
                    '@TPALの場合
                    Case CPstrEqTypeTPAL
                        '@1:張り合わせ済み(13のみ判定処理実施)の場合
                        If .strCoverFlag = CPstrTpalComp Then
                            '@確定ﾌﾗｸﾞ(確定可)
                            lblnFlag = True
                        End If
                     
                    '@ODFの場合
                    Case CPstrEqTypeODF
                        '@1:張り合わせ済み(13のみ判定処理実施)の場合
                        If .strCoverFlag = CPstrODFComp Then
                            '@確定ﾌﾗｸﾞ(確定可)
                            lblnFlag = True
                        End If
                        
                    '@CF移載機の場合
                    Case CPstrEQ_TYPE_MoveB, CPstrEQ_TYPE_MoveC
                        '@1:CF移載ﾃﾞｰﾀ登録済みの場合
                        If .strCFMoveDataFlag = True Then
                            '@確定ﾌﾗｸﾞ(確定可)
                            lblnFlag = True
                        End If
                        
                    Case Else
                        '@確定ﾌﾗｸﾞ(確定可)
                        lblnFlag = True
                        
                End Select
            End With
            
            '@確定ﾌﾗｸﾞが可で次工程送出ｵﾌﾟｼｮﾅﾙﾎﾞﾀﾝのいずれかにﾁｪｯｸが付いている場合
            If lblnFlag = True And _
               (optLotNextSend0.Checked = True Or _
                optLotNextSend1.Checked = True Or _
                optLotNextSend2.Checked = True Or _
                optLotNextSend3.Checked = True) Then
                '@確定ﾎﾞﾀﾝを有効
                cmdRegist.Enabled = True
            Else
                '@確定ﾎﾞﾀﾝを無効
                cmdRegist.Enabled = False
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvcmdRegist_Set"       '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvWPData_Chk
    '機　能：装置ﾃﾞｰﾀﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：正常、False：異常
    '作成日：2005/12/27 (Tue) 11:57:36 N.Kojima
    '更新日：2006/07/20 (Thu) 11:24:02 T.Kitagawa
    '備　考：
    '　　　：2006/01/30 (Mon) 12:51:13 N.Kojima     仕様変更により、再修正。ODF貼り合せ装置の場合(eq_.type=14)、
    '　　　：                                       装置ﾃﾞｰﾀ確認中のMsgBoxを表示しないようにする。(R2-27対応)
    '　　　：2006/07/20 (Thu) 10:07:24 T.Kitagawa   余計なﾛｼﾞｯｸを削除(案件№00864)
    Private Function prvWPData_Chk() As Boolean

        Dim lblnAns                     As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypTFTList                 As Waferlist            'TFTWF情報格納用構造体
        Dim ltypCFList                  As Waferlist            'WFおよびﾁｯﾌﾟ情報格納用構造体
        Dim ltypFtpRegcollect           As FtpRegCollect        'FTP収集状況確認(装置ﾃﾞｰﾀ登録状況確認)送信ﾃﾞｰﾀ格納用構造体
        Dim llngCnt                     As Integer              '汎用ｶｳﾝﾀ
        Dim llngTotalWFNum              As Integer              'TFTﾛｯﾄとCFﾛｯﾄのWF枚数の合計
        Dim llngWaistAns                As Integer              'WAISTﾃﾞｰﾀ状態確認MsgBox戻り値
        Dim lstrWaistStatus             As String               'WAISTﾃﾞｰﾀ状態

        Try

            '@初期化
            prvWPData_Chk = False

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrWPDataChk)
            
            '@WAIST検査機の場合はWAIST結果が格納されているか確認する(※装置ﾀｲﾌﾟがWAIST検査機の場合のみ)
            If ptypLotprestate.strEqType = CPstrEqTypeWAIST Then
                '@WAISTﾃﾞｰﾀ状態の取得
                lblnAns = pubblnLotChkWaist_Sel(CMstrlot_chkwaistVer, pstrSBID, lblLotID.Text, lstrWaistStatus)
                '@結果判定
                If lblnAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrWPDataChk)
                    Exit Function
                End If
                '@WAISTﾃﾞｰﾀ状態の判定
                Select Case lstrWaistStatus
                    '@正常
                    Case CMstrWaistStatus0
                        '@何もしない
                    '@DB更新中
                    Case CMstrWaistStatus3
                        '@"<TRM3WW>$$現在、WAIST検査機の結果を取得中です。$再度、確定ボタンを押してください。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003W)
                        llngWaistAns = publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrWPDataChk)
                        Exit Function
                    '@DB更新異常
                    Case CMstrWaistStatus4
                        '@"<TRM3XW>$$WAIST検査機の結果取得中にエラーが発生しました。$システム担当者に連絡してください。$WAIST検査機の結果が反映されませんが、強制実行しますか？"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003X)
                        llngWaistAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                        '@返答判定
                        If llngWaistAns = vbNo Then
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(CMstrFormName, CMstrWPDataChk)
                            Exit Function
                        End If
                    '@その他の異常
                    Case Else
                        '@"<TRM0GE>$$WAIST検査機の状態エラーが発生しました。$システム担当者に連絡してください。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000G)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrWPDataChk)
                        Exit Function
                End Select
            End If
            
            '@*****************************************************************
            '@ ODF貼合せ装置の場合は、進捗Msgを表示しない、1回装置ﾃﾞｰﾀの確認の行なう。
            '@ ODF貼合せ装置以外の場合は、進捗Msgを表示し、WF枚数分装置ﾃﾞｰﾀの確認を行なう
            '@ 現在「WAIST・ODF」に限ってFTP収集確認を行なっているが、
            '@ 今後FTP対象装置の場合も、この確認Msgを使用する場合は、lot_.curstate.strFtpDataFlagを
            '@ 判定し、ODF・WAISTの場合と処理を分ける。(導入時は要検討)
            '@*****************************************************************
            With ptypLotprestate
                '@FTP_DATA_FLAGが"1(FTP対象)"の場合
                If .strFtpDataFlag = CPstrOne Then
                    '@TFTｷｬﾘｱIDが取得出来た場合(ｷｬﾘｱIDがNULL以外、CF_FLAGが0(CF=1,TPAL=2,大判=1+(LP_FLAG=1)))
                    If .strCarrierId <> vbNullString And .strCfFlag = CPstrZero Or .strCfFlag = CPstrThree Then
                        '@TFTﾛｯﾄの場合
                        '@WF情報取得(TFT)
                        '@CPstrCD0T:有効ｳｪﾊ
                        lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, _
                                                         .strCarrierId, _
                                                         CPstrCD0T, _
                                                         ltypTFTList)
                        '@結果判定
                        If lblnAns = False Then
                            '@Escﾎﾞﾀﾝを有効
                            Me.CancelButton = cmdClose 
                            '@失敗の場合ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(CMstrFormName, CMstrWPDataChk)
                            Exit Function
                        End If
                    End If
                    '@CFｷｬﾘｱIDが取得出来た場合(CFｷｬﾘｱIDがNULL以外、CF_FLAGが2以外(TFT=0,CF=1,TPAL=2,大判=1+(LP_FLAG=1)))
                    If .strCFCarrierID <> vbNullString And .strCfFlag <> CPstrTwo Then
                        '@CFﾛｯﾄ(TAPLはﾁｯﾌﾟ単位管理なので除く)の場合
                        '@WF情報取得(CF)
                        '@CPstrCD0T:有効ｳｪﾊ
                        lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, _
                                                         .strCFCarrierID, _
                                                         CPstrCD0T, _
                                                         ltypCFList)
                        '@結果判定
                        If lblnAns = False Then
                            '@Escﾎﾞﾀﾝを有効
                            Me.CancelButton = cmdClose
                            '@失敗の場合ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(CMstrFormName, CMstrWPDataChk)
                            Exit Function
                        End If
                    End If
                    '@TFTﾛｯﾄWF枚数+CFﾛｯﾄWF枚数を格納
                    llngTotalWFNum = ltypTFTList.lngListCnt + ltypCFList.lngListCnt
                    '@FTP収集状況確認要求構造体にﾃﾞｰﾀを格納　→　WFIDはﾙｰﾌﾟ処理で格納
                    With ltypFtpRegcollect
                        '@ﾊﾝﾄﾞﾜｰｸ工程の場合(WP_TYPE_FLAG=0)
                        If ptypLotprestate.strWpTypeFlag = CPstrZero Then
                            .strCarrierId = ptypLotprestate.strUnloaderCarrierID    'TFTｷｬﾘｱID(Unloaderに指定されているｷｬﾘｱ)
                        Else
                            '@通常工程の場合
                            .strCarrierId = ptypLotprestate.strCarrierId            'TFTｷｬﾘｱID(Loaderに指定されているｷｬﾘｱ)
                        End If
                        .strWpID = ptypLotprestate.strWpID                          '装置ID
                        .strSbID = pstrSBID                                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                    End With
                End If
                
                '@ODF装置(eq_type=14)か
                If .strEqType = CPstrEqTypeODF Then
                    '@WF枚数分ﾙｰﾌﾟさせる(TFT)
                    For llngCnt = 0 To ltypTFTList.lngListCnt-1
                        '@WFID格納
                        ltypFtpRegcollect.strWfId = ltypTFTList.typWfList(llngCnt).strWfId      'WFID(TFTﾛｯﾄ)
                        '@FTP収集状況確認要求(装置ﾃﾞｰﾀ登録状況確認要求)
                        lblnAns = pubblnFtpRegCollect_Sel(CMstrftp_regcollectVer, ltypFtpRegcollect)
                        '@応答判定
                        If lblnAns = False Then
                            '@異常(失敗)の場合
                            '@Escﾎﾞﾀﾝを有効
                            Me.CancelButton = cmdClose
                            '@失敗の場合ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(CMstrFormName, CMstrWPDataChk)
                            Exit Function
                        End If
                    Next llngCnt
                    '@送信ﾃﾞｰﾀのｷｬﾘｱIDをCF側のｷｬﾘｱIDにｾｯﾄし直し
                    ltypFtpRegcollect.strCarrierId = ptypLotprestate.strCFCarrierID
                    '@WF枚数分ﾙｰﾌﾟさせる(CF)
                    For llngCnt = 0 To ltypCFList.lngListCnt-1
                        '@WFID格納
                        ltypFtpRegcollect.strWfId = ltypCFList.typWfList(llngCnt).strWfId       'WFID(CF)
                        '@FTP収集状況確認要求(装置ﾃﾞｰﾀ登録状況確認要求)
                        lblnAns = pubblnFtpRegCollect_Sel(CMstrftp_regcollectVer, ltypFtpRegcollect)
                        '@応答判定
                        If lblnAns = False Then
                            '@異常(失敗)の場合
                            '@Escﾎﾞﾀﾝを有効
                            Me.CancelButton = cmdClose
                            '@失敗の場合ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(CMstrFormName, CMstrWPDataChk)
                            Exit Function
                        End If
                    Next llngCnt
                End If

            End With

            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrWPDataChk)
            
            '@装置ﾃﾞｰﾀﾁｪｯｸがOK
            prvWPData_Chk = True

            Exit Function

        Catch ex As Exception
            
            '@ESCでの画面終了有効
            Me.CancelButton = cmdClose
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "prvWPData_Chk"          '処理名
                .strErrMessage = ""                     'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvRefresh_Disp
    '機　能：作業終了画面の最新取得と復元
    '引　数：blnJudge(True：最終更新日時の判定あり、False：なし)
    '戻り値：なし
    '作成日：2006/06/07 (Wed) 09:00:21 M.Miura
    '更新日：2006/06/07 (Wed) 09:00:21
    '備　考：
    Private Sub prvRefresh_Disp(ByRef Optional blnJudge As Boolean = False)
        
        Dim lstrWorkMemo        As String           '作業ﾒﾓ復元用
        Dim llngOptCnt          As Integer          '次工程ｵﾌﾟｼｮﾅﾙﾎﾞﾀﾝのｶｳﾝﾄ

        '@最終更新日時の判定あり
        If blnJudge = True Then
            '@子画面で更新されていない場合は抜ける
            If mstrLotLastUpdate = ptypLotprestate.strLotLastUpdate Then
                Exit Sub
            End If
        End If
        
         '@次工程ｵﾌﾟｼｮﾅﾙﾎﾞﾀﾝがなくなるまで(送出あり～追加流動)
            For llngOptCnt = 0 To 3
                Dim ctrl As New RadioButton
                Dim optCtrl As Control() = Me.Controls.Find("optLotNextSend" + llngOptCnt.ToString,True)

                ctrl = CType(optCtrl(0),RadioButton)

                '@ﾁｪｯｸが付いている場合
                If ctrl.Checked = True Then
                    '@ﾁｪｯｸ付きIndex退避
                    pstrOptionValue = llngOptCnt
                    '@ﾙｰﾌﾟを抜ける
                    Exit For
                End If
            Next llngOptCnt
        
        '@作業ﾒﾓを退避
        lstrWorkMemo = txtWorkMemo.Text

        '@同一ｷｬﾘｱで最新取得する為、初期化
        mstrCarrier = vbNullString
        vsfNextStepInfo.Redraw = false
        '@ｷｬﾘｱ再入力(次工程ｵﾌﾟｼｮﾅﾙﾁｪｯｸ付きの復元処理はValidateにあります)
        RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
        Call txtCarrier_Validate(txtCarrier, New CancelEventArgs)
        AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
        vsfNextStepInfo.Redraw = True
        '@送出なしのみ有効な場合(送出できない場合)
        If optLotNextSend0.Enabled = False And _
           optLotNextSend1.Enabled = True And _
           optLotNextSend2.Enabled = False And _
           optLotNextSend3.Enabled = False Then

           '@送出なしにﾁｪｯｸ
           optLotNextSend1.Checked = True
        End If
        
        '@作業ﾒﾓを子画面起動前に復元
        txtWorkMemo.Text = lstrWorkMemo
                              
    End Sub

    '関数名：prvNextNgMsg_Disp
    '機　能：次工程送出不可ﾒｯｾｰｼﾞ表示
    '引　数：lstrRtnLotId       ：作業終了後、ﾛｯﾄID
    '　　　：lstrEleHoldFlag    ：電特保留ﾌﾗｸﾞ(0：未保留、1：保留)
    '　　　：lstrTftHoldFlag    ：TFT保留ﾌﾗｸﾞ(0：未保留、1：保留)
    '　　　：lstrExcpHoldFlag   ：異常処理票保留ﾌﾗｸﾞ(0：未保留、1：保留)
    '　　　：lstrNormalHoldFlag ：通常保留ﾌﾗｸﾞ(0：未保留、1：保留)
    '戻り値：なし
    '作成日：2006/11/07 (Tue) 10:56:48 M.Miura
    '更新日：2006/11/07 (Tue) 10:56:48
    '備　考：
    Private Sub prvNextNgMsg_Disp(ByVal lstrRtnLotId As String, _
                                  ByVal lstrEleHoldFlag As String, _
                                  ByVal lstrTftHoldFlag As String, _
                                  ByVal lstrExcpHoldFlag As String, _
                                  ByVal lstrNormalHoldFlag As String)
                                  
        Try

            Select Case True
                
                '@電特保留、TFT保留　両方保留の場合
                Case lstrEleHoldFlag = CPstrHold1 And lstrTftHoldFlag = CPstrHold1
                    
                    '@電特＆TFT測定結果が「NG」のため保留
                    '@表示ﾒｯｾｰｼﾞ変換"<TRM3BI>$$%1測定結果にNGのウエハが存在するため、ロット[%2]は保留されました。$次工程送出できません。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003B, CMstrMsgEltTft, lstrRtnLotId)
                    Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                    
                    '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)
                    
                '@電特のみ保留
                Case lstrEleHoldFlag = CPstrHold1 And lstrTftHoldFlag = CPstrHold0
                    
                    '@電特測定結果が「NG」のため保留
                    '@表示ﾒｯｾｰｼﾞ変換"<TRM3BI>$$%1測定結果にNGのウエハが存在するため、ロット[%2]は保留されました。$次工程送出できません。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003B, CMstrMsgELT, lstrRtnLotId)
                    Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                    
                    '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)
                    
                '@TFTのみ保留
                Case lstrEleHoldFlag = CPstrHold0 And lstrTftHoldFlag = CPstrHold1
                    
                    '@TFT測定結果が「NG」のため保留
                    '@表示ﾒｯｾｰｼﾞ変換"<TRM3BI>$$%1測定結果にNGのウエハが存在するため、ロット[%2]は保留されました。$次工程送出できません。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003B, CMstrMsgTFT, lstrRtnLotId)
                    Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                    
                    '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)
                    
                '@異常処理票保留
                Case lstrExcpHoldFlag = CPstrHold1
                    
                    '@異常処理票保留の場合
                    '@表示ﾒｯｾｰｼﾞ変換"<TRM6LI>$$ロット[%1]は[%2]されているため、次工程送出されません。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006L, lstrRtnLotId, CMstrMsgExcpHold)
                    Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                    
                    '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)
            
                '@通常保留
                Case lstrNormalHoldFlag = CPstrHold1
                    
                    '@通常保留の場合
                    '@表示ﾒｯｾｰｼﾞ変換"<TRM6LI>$$ロット[%1]は[%2]されているため、次工程送出されません。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006L, lstrRtnLotId, CMstrMsgHold)
                    Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                    
                    '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)
                    
            End Select
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "prvNextNgMsg_Disp"              '処理名
                .strErrMessage = ""                             'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvblnEqftSyncRegist_Proc
    '機　能：ｵﾌﾗｲﾝFTPﾃﾞｰﾀ同期登録処理
    '引　数：lstrFTPResult  ：FTP送信結果
    '　　　：lstrWfFlag     ：WF情報取得判定 NG:失敗
    '戻り値：True:成功、False:失敗
    '作成日：2007/06/19 (Tue) 14:34:03 N.Kasai
    '更新日：2007/06/19 (Tue) 14:34:03
    '備　考：
    Private Function prvblnEqftSyncRegist_Proc(ByRef lstrFTPResult As String, _
                                               ByRef lstrWfFlag As String) As Boolean
        
        Dim ltypWFList                  As Waferlist                'WF情報ﾃﾞｰﾀ
        Dim ltypEqftSyncregistReq       As EqftSyncregistReq        'ｵﾌﾗｲﾝFTPﾃﾞｰﾀ
        Dim lblnAns                     As Boolean                  '汎用戻り値
        Dim llngCnt                     As Integer                  '汎用ｶｳﾝﾀ

        Try
            
            '@----------------------------------------
            '@ ｵﾌﾗｲﾝFTPﾃﾞｰﾀ同期登録
            '@ 処理条件(AND条件です。)
            '@ ①FTP装置
            '@ ②運用ﾓｰﾄﾞがM1
            '@ ③装置ﾀｲﾌﾟがODF以外(ODFの場合はﾎﾟｰﾘﾝｸﾞSVで行う為)
            '@ pubblnEqftSyncRegist_Upd　ﾛｸﾞ出力機能あり(FTPｻｰﾊﾞｰが起動していない場合通信ｴﾗｰとなります。SVのﾛｸﾞに表示されない)
            '@ そこで落合様よりCLのﾛｸﾞに残して欲しいと要望があり(Deve以外はあり得ないが例外処理として記述します。)
            '@----------------------------------------
            
            '@戻り値初期化
            prvblnEqftSyncRegist_Proc = False
            
            '@WFﾘｽﾄ取得ﾌﾗｸﾞ初期化
            lstrWfFlag = vbNullString
            
            With ptypLotprestate
                
                '@WF情報取得【CPstrCD0T:有効ｳｪﾊ】
                lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, .strCarrierId, CPstrCD0T, ltypWFList)
                '@結果判定
                If lblnAns = False Then
                    '@WFﾘｽﾄ取得失敗
                    '@WF情報取得に失敗すると言うことは致命的であり
                    '@作業終了はさせない
                    lstrWfFlag = CMstrNG
                    Exit Function
                End If

            End With
            
            '@ｵﾌﾗｲﾝFTPﾃﾞｰﾀ要求ﾃﾞｰﾀ格納
            With ltypEqftSyncregistReq
                .strMsgVer = CMstreqft_syncregistVer
                .strWpID = ptypLotprestate.strWpID
                .strSbID = pstrSBID
                .strCarrierId = txtCarrier.Text
                .strLotID = ptypLotprestate.strLotID
                .strWorkStartTime = Format$(cdate(ptypLotprestate.strStartTime), "yyyyMMddHHmmss") 'ftpの日付ﾌｫｰﾏｯﾄ
                '@ﾃﾞｰﾀ件数
                .lngEqftWfListCnt = ltypWFList.lngListCnt
                '@件数ありの場合
                If .lngEqftWfListCnt > 0 Then
                    '@配列の定義
                    if .typEqftWfList Is Nothing Then
                        .typEqftWfList = New List(Of EqftWfList) 
                    Else 
                        .typEqftWfList.Clear()
                    End If
                     Dim typEqftWfListtmp As EqftWfList
                    '@ﾃﾞｰﾀ件数分格納
                    For llngCnt = 0 To .lngEqftWfListCnt-1
                        typEqftWfListtmp = New EqftWfList ()
                        typEqftWfListtmp.strWfId = ltypWFList.typWfList(llngCnt).strWfId
                        typEqftWfListtmp.strSlotNo = ltypWFList.typWfList(llngCnt).strSlotPosition
                        'NSYS ｵﾌﾗｲﾝFTPﾃﾞｰﾀを格納
                        .typEqftWfList.Add(typEqftWfListtmp)
                    Next
                End If
            End With
                
            '@ｵﾌﾗｲﾝFTPﾃﾞｰﾀ同期登録【lstrFTPResult：FTP送信結果】
            lblnAns = pubblnEqftSyncRegist_Upd(ltypEqftSyncregistReq, lstrFTPResult)
            '@結果判定
            If lblnAns = False Then
                Exit Function
            End If
            
            '@正常終了
            prvblnEqftSyncRegist_Proc = True
            
            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "prvblnEqftSyncRegist_Proc"      '処理名
                .strErrMessage = ""                             'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function


    '関数名：StartApcDepo
    '機　能：APC DEPO計算開始メッセージ送信
    '引　数：strSpecCheck       ：SPC規格値判定の結果
    '        strLotId           ：ロットID
    '        strOpId            ：大工程
    '        strStepId          ：小工程
    '        strFlowClass       ：流動区分
    '戻り値：なし
    '作成日：2012/02/13 (Thu) 10:00:08 M.Sakka
    '更新日：2012/02/13 (Thu) 10:00:08 M.Sakka
    '備　考：
    Private Sub StartApcDepo(ByVal strSpecCheck As String, _
                             ByVal strLotID As String, _
                             ByVal strOpID As String, _
                             ByVal strStepID As String, _
                             ByVal strFlowClass As String)

        Dim bErrFlg     As Boolean  'エラー処理フラグ     
        
        Try
            
            Dim oSendMsg    As TfMsg    '送信ﾒｯｾｰｼﾞ(ﾘｸｴｽﾄ)
            Dim oReciveMsg  As TfMsg    '受信ﾒｯｾｰｼﾞ(ｱﾝｻｰ)
            Dim strResutl   As String   '応答取得
            
            
            '== 注意!!!! ======================================
            'エラーを無視するためFalse固定
            '通信エラーなどをエラーとして扱いたい場合は
            'このフラグをtrueに設定してください！！
            '==================================================
            bErrFlg = False
            
            oSendMsg = New TfMsg
            oReciveMsg = New TfMsg
            
            '規格値が以下の場合はAPCサーバーに計算を依頼
            ' - F/B処理起動OK(0)
            ' - 管理値異常(1)
            '逆に以下の場合はなにもしない
            ' - 規格値異常(2)
            ' - その他異常(3)
            
            Select Case strSpecCheck
                Case CMstrSpecCheckOK, CMstrSpecCheckSPCNG
                    'Msgﾊﾞｰｼﾞｮﾝ
                    If CMstreq_apc_start___Ver <> vbNullString Then
                        Call oSendMsg.addString(CPstrMSG_VER, CMstreq_apc_start___Ver)
                    Else
                        Call oSendMsg.addString(CPstrMSG_VER, CPstrMsgNull)
                    End If
                    
                    'SB_ID
                    If pstrSBID <> vbNullString Then
                        Call oSendMsg.addString(CPstrSB_ID, pstrSBID)
                    Else
                        Call oSendMsg.addString(CPstrSB_ID, CPstrMsgNull)
                    End If
                    
                    'ロットID
                    If strLotID <> vbNullString Then
                        Call oSendMsg.addString(CPstrLOT_ID, strLotID)
                    Else
                        Call oSendMsg.addString(CPstrLOT_ID, CPstrMsgNull)
                    End If
                
                    '大工程ID
                    If strOpID <> vbNullString Then
                        Call oSendMsg.addString(CPstrOP_ID, strOpID)
                    Else
                        Call oSendMsg.addString(CPstrOP_ID, CPstrMsgNull)
                    End If
                
                    '小工程ID
                    If strStepID <> vbNullString Then
                        Call oSendMsg.addString(CPstrSTEP_ID, strStepID)
                    Else
                        Call oSendMsg.addString(CPstrSTEP_ID, CPstrMsgNull)
                    End If
                
                    '流動区分
                    If strFlowClass <> vbNullString Then
                        Call oSendMsg.addString(CPstrFLOW_CLASS, strFlowClass)
                    Else
                        Call oSendMsg.addString(CPstrFLOW_CLASS, CPstrMsgNull)
                    End If
            'その他の異常
                Case Else
                    GoTo EndThisSub
            End Select  'case終了
            
            'ﾒｯｾｰｼﾞ送信
            Call pTerm.sendRequest(CPstrapc_start___, oSendMsg, oReciveMsg)
            
            '受信結果取得(結果は無視)
            Call oReciveMsg.getString(CPstrRESULT, strResutl)
            
        EndThisSub:
            'ｵﾌﾞｼﾞｪｸﾄのｸﾘｱ
            oSendMsg = Nothing
            oReciveMsg = Nothing
            
            Exit Sub    '関数終了

        Catch ex As Exception
            If bErrFlg = False Then
                GoTo EndThisSub
            End If

            'ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey     '機能ID
                .strProcName = "StartApcDepo"       '処理名
                .strErrMessage = ""                 'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：prvblnLotHold_Proc
    '機　能：保留処理
    '引　数：lstrLotID:ﾛｯﾄID
    '      ：lstrOdfConverLastUpdate:ﾛｯﾄ更新日
    '      ：lstrHoldTermDate:ﾛｯﾄ保留期間
    '戻り値：True：成功/False：失敗
    '作成日：2014/12/01 (Mon) 15:56:10 H.Hayashi
    '更新日：
    '備　考：
    Private Function prvblnLotHold_Proc(ByVal lstrLotID As String, _
                                        ByVal lstrOdfConverLastUpdate As String, _
                                        ByVal lstrHoldTermDate As String) As Boolean

        Dim lblnAns                 As Boolean              '登録戻り値(True/False)
        Dim ltypLotHoldset          As LotHoldset           'ﾛｯﾄ保留設定要求格納用
        Dim lstrMailTemp            As String               'ﾒｰﾙ本文作成用退避領域
        Dim lstrAns                 As String               'ﾒｰﾙｱﾄﾞﾚｽ取得           
        Dim HoldDate                As String               'NSYS 保留日時
        Dim HoldLimit               As String               'NSYS 保留期限

        Try

            '@初期化
            prvblnLotHold_Proc = False
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)

            '@作業者IDからﾒｰﾙｱﾄﾞﾚｽ取得処理
            lstrAns = pubstrMailAddress_Sel(pstrUserID)
            '@結果判定
            If lstrAns = vbNullString Then
            '@成功の場合
                '@ｱﾄﾞﾚｽが存在していない場合
                '@ﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005N, CMstrEmp, ptypSendMessageList.strSendEmpName)

                '@pubVsfInfo_Disp("[%1 %2]のメールアドレスが取得できず、$[%2]へメール送信できませんでした。")
                Call pubVsfInfo_Disp(pstrDMsg)
            Else
                '@領域の件数を増やす
                ptypSendMessageList.lngMailListCnt = ptypSendMessageList.lngMailListCnt + 1

                '@領域確保
                If ptypSendMessageList.typMailList Is Nothing Then 
                    ptypSendMessageList.typMailList = New List(Of MailList) 
                Else 
                     
                End If
                
                '@ﾒｰﾙｱﾄﾞﾚｽ
                Dim typMailListtmp As MailList = New MailList 
                typMailListtmp.strMailAddress = lstrAns
                 ptypSendMessageList.typMailList.Add(typMailListtmp)

            End If

            '@ﾛｯﾄ保留設定ﾃﾞｰﾀ作成
            With ltypLotHoldset
                .strLotID = lstrLotID                                                       'ﾛｯﾄID
                .strHoldReasonID = "R000000017"                                             '保留理由ID
                .strHoldComment = "異なる蒸着バッチで無機ODF貼り合せを実施しています。"     '保留ｺﾒﾝﾄ
                .strHoldTermDate = lstrHoldTermDate
                .strHoldEmpID = pstrUserID                                                  '保留責任者ID
                .strEmpID = pstrUserID                                                      '作業者ID
                .strLotLastUpdate = lstrOdfConverLastUpdate                                 'ﾛｯﾄ最終更新日時
            End With

            '@保留処理実行
            lblnAns = pubblnLotHold_Ins(CMstrlot_hold____Ver, ltypLotHoldset)
            '@結果判定
            If lblnAns = True Then
            '@成功の場合
                '@成功ﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf007J, txtCarrier.Text, lstrLotID)

                '@pubVsfInfo_Disp("メッセージコード：C_I08%0$$ロット[ %2 ]を保留しました。キャリア[ %1 ]")
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@ﾒｰﾙ送信処理開始
                '@初期化
                lstrMailTemp = vbNullString

                '@ﾒｰﾙ自動挿入情報を作成
                '@##########ﾒｰﾙ本文固定表記##########
                '@送信者：XXXXXXXXXX
                '@ロット№：XXXXXXXXXX
                '@機種：XXXXXXXXXX
                '@大工程：XXXXXXXXXX
                '@小工程：XXXXXXXXXX
                '@保留理由：XXXXXXXXXX
                '@保留日時：XXXXXXXXXX
                '@保留期限：XXXXXXXXXX
                '@メール本文：
                '@＜内容＞
                '@##########ﾒｰﾙ本文固定表記##########

                '@ﾒｰﾙ本文作成
                'cmbMasHold.Text
                'Format(dtpHoldTermDate.Value, CPstrDateTimeYMD)
                If IsDate(ltypLotHoldset.strHoldEditTime)
                    HoldDate = Format(cdate(ltypLotHoldset.strHoldEditTime), CPstrDateTimeYMDHMS).ToString 
                Else 
                    HoldDate = ltypLotHoldset.strHoldEditTime
                End If

                If IsDate(ltypLotHoldset.strHoldEditTime)
                    HoldLimit = Format(cdate(ltypLotHoldset.strHoldEditTime), CPstrDateTimeYMD).ToString 
                Else 
                    HoldLimit = ltypLotHoldset.strHoldEditTime
                End If

                lstrMailTemp = CPstrMailSENDER & ptypSendMessageList.strSendEmpName & vbCrLf & _
                               CPstrMailLOT & lstrLotID & vbCrLf & _
                               CPstrMailPDID & lblPdID.Text & vbCrLf & _
                               CPstrMailOPID & lblOpID.Text & vbCrLf & _
                               CPstrMailSTEPID & lblStepID.Text & vbCrLf & _
                               CPstrMailHOLDREASON & ltypLotHoldset.strHoldComment & vbCrLf & _
                               CPstrMailSENDDATE & HoldDate & vbCrLf & _
                               CPstrMailHOLDTERMDATE & HoldLimit & vbCrLf & _
                               CPstrMailHOLDComments & vbCrLf & _
                               ptypSendMessageList.strMailContents

				'DBに2048文字制限があるため超えている場合は切り詰める
				If lstrMailTemp.Length > 2047 Then
					lstrMailTemp = lstrMailTemp.Substring(0, 2047)
				End If

                '@ﾒｰﾙ本文差換
                ptypSendMessageList.strMailContents = lstrMailTemp
                
                '@件名格納：ロット保留(%1)
                ptypSendMessageList.strMailSubject = Replace(CPstrMailSubjectHold, "%1", lstrLotID)
                
                '@ﾒｯｾｰｼﾞ送信【ﾒｰﾙ送信】
                lblnAns = pubblnGuidSendMessage_Sel(ptypSendMessageList)
                '@結果判定
                If lblnAns = True Then
                '@成功の場合
                    '@表示ﾒｯｾｰｼﾞ変換("<TRM4SI>$$メールの送信を受け付けました。")
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004S)

                    '@ﾒｯｾｰｼﾞ表示
                   Call pubVsfInfo_Disp(pstrDMsg)
                End If
            Else
            '@失敗の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                
                Exit Function
            End If
            
            '@成功を返す
            prvblnLotHold_Proc = True

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnLotHold_Proc"
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


    '関数名 list_BeforeDoubleClick
    '機　能：グリッドダブルクリック前処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/01/14 (Mon) 17:00:00 NSYS
    '備　考：
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfNextStepInfo.BeforeDoubleClick

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


    '関数名：flexGrid_KeyDownEdit
    '機　能：←→キーの取り扱い
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/01/28 (Mon) 10:00:00 NSYS
    '更新日：2019/04/05 (Fri) 12:00:00 NSYS
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfNextStepInfo.KeyDownEdit

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
    Private Sub flex_SetupEditor(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfNextStepInfo.SetupEditor

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

   
End Class
