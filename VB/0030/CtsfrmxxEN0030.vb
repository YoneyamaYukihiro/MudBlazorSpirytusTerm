'ﾌｧｲﾙ名：xxEN0030.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：作業開始　ﾒｲﾝﾌｫｰﾑ
'作成日：2004/02/27 (Fri) 14:07:45 T.Oide
'更新日：2015/12/01 (Tue) 13:47:44 H.Hayashi
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN0030
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN0030    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN0030
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN0030
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN0030)
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
    '====================================== Private ========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    'Private Const CMstrLocalVersion             As String = "19.01"
	Private Const CMstrLocalVersion             As String = "19.02"
    '@ﾛｰｶﾙ機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN0030  'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrlot_curstateVer          As String = "04.00"         'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_recplistVer          As String = "02.05"         'ﾛｯﾄﾚｼﾋﾟﾘｽﾄ取得
    Private Const CPstrlot_wplist__Ver          As String = "02.05"         'ﾛｯﾄ装置情報取得
    Private Const CMstrlot_wrkstartVer          As String = "07.03"         'ﾛｯﾄ作業開始
    Private Const CMstrlot_actlist_Ver          As String = "01.00"         'ｱｸｼｮﾝ予約ﾘｽﾄ取得
    Private Const CMstrcarrcurstateVer          As String = "05.02"         'ｷｬﾘｱ状態確認
    Private Const CMstrcarrcfcurstateVer        As String = "02.00"         'CFｷｬﾘｱ状態確認
    Private Const CMstrmat_materiallistVer      As String = "02.01"         '装置部材情報取得
    Private Const CMstrmat_chkwpmaterialVer     As String = "03.00"         '装置使用部材判定
    Private Const CMstrspc_regcollectVer        As String = "05.00"         '装置ﾃﾞｰﾀ登録
    Private Const CMstrutilreftminfoVer         As String = "04.00"         '端末設定情報取得
    Private Const CMstreqchkintervalVer         As String = "01.00"         '装置経過時間ﾁｪｯｸ
    Private Const CMstrlot_chkovertake          As String = "01.00"         '無機ODF追越制限違反確認
    Private Const CMstrlot_chkfrtimerecipeVer   As String = "01.00"         'FR処理可能範囲ﾚｼﾋﾟ確認
    Private Const CMstrasm_chkodfreserveVer     As String = "01.00"         'ODF予約とのチェック
    Private Const CPstrasm_odfreservereinfoVer  As String = "01.00"         'ODF予約情報
	Private Const CMstrlot_chkdoublejpdVer		As String = "01.00"	        '蒸着2回対応対象機種ﾁｪｯｸ
    '@ｷｬﾘｱIDの最大桁数
    Private Const CMlngCarrierMaxLength         As Integer = 6              'ｷｬﾘｱIDの最大桁数

    '@WPIDｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbDispCols              As Integer = 1              'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbGridColWPName         As Integer = 0              '装置名列番
    Private Const CMlngCmbGridColWPID           As Integer = 1              '装置ID列番(非表示項目)
    Private Const CMlngCmbFontSize              As Integer = 16             'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize          As Integer = 16             'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbRowHeight             As Integer = 43             'ﾘｽﾄ行の高さ
    Private Const CMlngCmbSortAsc               As Integer = 1              '昇順(ｿｰﾄ)

    '@vsfWPの定数宣言(ｶﾗﾑ)
    Private Const CMvsfWPColNo                  As Integer = 0              '№
    Private Const CMvsfWPColOpID                As Integer = 1              '大工程
    Private Const CMvsfWPColStepID              As Integer = 2              '小工程
    Private Const CMvsfWPColDefault             As Integer = 3              'ﾃﾞﾌｫﾙﾄ小工程
    Private Const CMvsfWPColWpName              As Integer = 4              '装置
    Private Const CMvsfWPColWpID                As Integer = 5              '装置ID(WPID)
    Private Const CMvsfWPColAltNumber           As Integer = 6              '代替番号
    Private Const CMvsfWPColStepCnt             As Integer = 7              '小工程番号
    Private Const CMvsfWPColWpCnt               As Integer = 8              '装置番号
    Private Const CMvsfWPColActionFlg           As Integer = 9              'ｱｸｼｮﾝ予約表示ﾌﾗｸﾞ
    Private Const CMvsfWPColLoaderFlg           As Integer = 10             'Loader/Unloaderﾌﾗｸﾞ
    Private Const CMvsfWPColCarrierType         As Integer = 11             'UNLOADERｷｬﾘｱﾀｲﾌﾟID
    Private Const CMvsfWPColEqType              As Integer = 12             'EQﾀｲﾌﾟ
    Private Const CMvsfWPColCleanCondition      As Integer = 13             '洗浄条件
    Private Const CMvsfWPColLotRecipeFlag       As Integer = 14             'ﾛｯﾄﾚｼﾋﾟﾌﾗｸﾞ

    '@vsfWPの定数宣言(表示幅)
    Private Const CMvsfWPColWNo                 As Integer = 0              '№
    Private Const CMvsfWPColWOpID               As Integer = 187            '大工程
    Private Const CMvsfWPColWStepID             As Integer = 187            '小工程
    Private Const CMvsfWPColWDefault            As Integer = 67             'ﾃﾞﾌｫﾙﾄ小工程
    Private Const CMvsfWPColWWpName             As Integer = 187            '装置
    Private Const CMvsfWPColWWpID               As Integer = 0              '装置ID
    Private Const CMvsfWPColWAltNumber          As Integer = 0              '代替番号
    Private Const CMvsfWPColWStepCnt            As Integer = 0              '小工程番号
    Private Const CMvsfWPColWWpCnt              As Integer = 0              '装置番号
    Private Const CMvsfWPColWActionFlg          As Integer = 0              'ｱｸｼｮﾝ予約表示ﾌﾗｸﾞ
    Private Const CMvsfWPColWLoaderFlg          As Integer = 0              'Loader/Unloaderﾌﾗｸﾞ
    Private Const CMvsfWPColWCarrierType        As Integer = 0              'ｷｬﾘｱﾀｲﾌﾟID
    Private Const CMvsfWPColWCleanCondition     As Integer = 0              '洗浄条件

    Private Const CMvsfWPCols                   As Integer = 15             'ｶﾗﾑ数
    Private Const CMvsfWPRows                   As Integer = 4              '行数
    Private Const CMvsfWPHHeight                As Integer = 21             'ﾍｯﾀﾞｰの高さ
    Private Const CMvsfWPHeight                 As Integer = 43             '１ｽﾛｯﾄの高さ
    Private Const CMvsfWPTitleRow               As Integer = 0              'ﾀｲﾄﾙ行

    '@vsfWPの定数宣言(ﾀｲﾄﾙ)
    Private Const CMvsfWPColTNo                 As String = "№"
    Private Const CMvsfWPColTOpID               As String = "大工程"
    Private Const CMvsfWPColTStepID             As String = "小工程"
    Private Const CMvsfWPColTDefault            As String = "ﾃﾞﾌｫﾙﾄ"
    Private Const CMvsfWPColTWpID               As String = "装置名"

    Private Const CMvsfWPTFontSize              As Integer = 12             'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMvsfWPFontSize               As Integer = 16             'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ

    Private Const CMstrDefault                  As String = "○"            '小工程ﾃﾞﾌｫﾙﾄﾏｰｸ
    Private Const CMstrStepdivisionDefault      As String = "1"             '工程ﾌﾗｸﾞ(1：ﾃﾞﾌｫﾙﾄ工程)
    Private Const CMlngEqFlag                   As Integer = 0              '装置ﾌﾗｸﾞ

    Private Const CMstrAri                      As String = "あり"          '代替工程用
    Private Const CMstrNasi                     As String = "なし"          '代替工程用

    Private Const CMstrActionFlgNever           As String = "0"             'ｱｸｼｮﾝ予約ﾌﾗｸﾞ(未表示)
    Private Const CMstrActionFlgFinish          As String = "1"             'ｱｸｼｮﾝ予約ﾌﾗｸﾞ(表示済)
    Private Const CMstrLoaderUnloaderFlg        As String = "1"             'Loader/Unloaderﾌﾗｸﾞ(L/N装置)
    Private Const CMstrColon                    As String = ":"             'ｺﾛﾝ

    Private Const CMstrEN0030Title              As String = "作業開始"
    Private Const CMstrNoneRecipe               As String = "レシピ無し"    'ﾚｼﾋﾟ設定ﾎﾞﾀﾝ制御用

    '@制限ﾀｲﾌﾟ
    Private Const CMstrRestrictTypeID1          As String = "1"             '以下
    Private Const CMstrRestrictTypeID2          As String = "2"             '以上

    '@↓2015/11/13 (Fri) 13:15:53 H.Hayashi **************************************************
    '@FR処理可能ﾚｼﾋﾟ有無状態
    Private Const CMstrFrRecipeStatus0          As String = "0"             '表示不要
    Private Const CMstrFrRecipeStatus1          As String = "1"             '正常表示
    Private Const CMstrFrRecipeStatus2          As String = "2"             '異常表示(FR累積範囲以外)
    Private Const CMstrFrRecipeStatus3          As String = "3"             '異常表示(処理部状態に一致しないﾚｼﾋﾟ)
    '@↑2015/11/13 (Fri) 13:15:53 H.Hayashi **************************************************

    '@ｶﾗｰ(専属装置以外は青、それ以外は赤)
    Private Const CMlngRedColor                 As Integer = &HFF           '赤色

    '@その他
    Private Const CMlngRecpCrLen                As Integer = 16             'ﾚｼﾋﾟ折り返し文字数
    Private Const CMlngKeyAsciiComma            As Integer = 44             'KeyAscii=44(ｶﾝﾏ)
    Private Const CMVariableResultNG            As String = "1"             'CMP研磨ﾃﾞｰﾀなし(NG)
    Private Const CMstrHandWork                 As String = "0"             'ﾊﾝﾄﾞﾜｰｸ
    Private Const CMlngMaxDispRow               As Integer = 4              'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(ﾛｯﾄｺﾒﾝﾄ)
    Private Const CMlngMaxDispMemoRow           As Integer = 3              'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(作業ﾒﾓ)
    Private Const CMstrCLErrCode                As String = "<TRM7UW>"      'CLｴﾗｰｺｰﾄﾞ
    Private Const CMstrDoubleDollar             As String = "$$"            '改行ｺｰﾄﾞ(2行改行用)

    '@ﾚｽﾎﾟﾝｽ計測用
    Private Const CMstrFormName                 As String = "frmxxEN0030"               '自ﾌｫｰﾑ名
    Private Const CMstrPrvblnAuthorityChk       As String = "prvblnAuthority_Chk"       'ｲﾍﾞﾝﾄ名定数(権限ﾁｪｯｸ)
    Private Const CMstrCmdLotStartClick         As String = "cmdLotStart_Click"         'ｲﾍﾞﾝﾄ名定数(確定)
    Private Const CMstrPrvblnMaterialPeriodChk  As String = "prvblnMaterialPeriod_Chk"  'ｲﾍﾞﾝﾄ名定数(部材期限ﾁｪｯｸ)
    Private Const CMstrPrvBlnEqBatchMoveInProc  As String = "prvblnWpIdBatchMoveIn_Proc"  'ｲﾍﾞﾝﾄ名定数(ﾊﾞｯﾁ投入順通知処理)

    'ODFチェック結果
    Private Const CMstrOdfReserveChk_OK         As String = "0"             'OK
    Private Const CMstrOdfReserveChk_NG         As String = "1"             'NG(予約情報内容と異なる)
    Private Const CMstrOdfReserveChk_Empty      As String = "2"             'NG(予約情報なし)

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mstrLotLastUpdate                   As String                   'ﾛｯﾄ最終更新日時
    Private mstrCarrier                         As String                   'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mblnEnabled                         As String                   'ﾛｯｸﾌﾗｸﾞ(True：ﾛｯｸ解除、False：ﾛｯｸ)
    Private mstrMasPDVersion                    As String                   '工順ﾊﾞｰｼﾞｮﾝ
    Private mtypLotCurState                     As Lotprestate              'ﾛｯﾄ情報格納構造体
    Private mblnTakeOverDispFlg                 As Boolean                  '引継ぎ情報表示済みﾌﾗｸﾞ
    Private mblnBacthFlg                        As Boolean                  'ﾊﾞｯﾁ編成ﾌﾗｸﾞ(True：ﾊﾞｯﾁ編成、False：通常)
    Private mstrVariableResult                  As String                   'ﾚｼﾋﾟﾊﾟﾗﾒｰﾀ値入力判定(0：OK、1:NG)
    Private mblnValidateFlag                    As Boolean                  'True:Validate完了、False:Validate走行中(ﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)

    Private mstrPdErrMsg                        As String                   '機種限定判定ｴﾗｰMsg格納用
    Private mstrLimitErrMsg                     As String                   '部材期限判定ｴﾗｰMsg格納用

    Private mstrPdForcedAction                  As String                   '機種限定強制実行ﾌﾗｸﾞ格納用(0=通常実行、1=強制実行)
    Private mstrLimitForcedAction               As String                   '部材期限超過強制実行ﾌﾗｸﾞ格納用(0=通常実行、1=強制実行)

    Private buttonProcessing                    As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                  'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                  'NSYS WindowCloseフラグ

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
        pubVsfMouseWheelManager_Set(vsfWP, cmdUp, cmdDown)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　起動時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 16:32:23 T.Oide
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2005/07/06 (Wed) 10:52:57 N.Kojima     OnErr処理、SetFocus処理追加
    '　　　：2005/11/29 (Tue) 16:23:52 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2008/06/04 (Wed) 10:43:38 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub Form_Load()
        
        Dim lblnAns         As Boolean      '戻り値

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@=======================
            '@ 機能ﾊﾞｰｼﾞｮﾝの判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN0030, CMstrLocalVersion)
            
            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset
            
            '@=======================
            '@ 各種初期化処理(画面内ｺﾝﾄﾛｰﾙ、変数等)
            '@=======================
            Call prvFrmxxEN0030_Init()
            
            '@ｺﾒﾝﾄ、作業ﾒﾓ用の上下ｽｸﾛｰﾙﾎﾞﾀﾝの無効化
            cmdTxtUp.Enabled = False                    'ｺﾒﾝﾄ ▲ﾎﾞﾀﾝ
            cmdTxtDown.Enabled = False                  'ｺﾒﾝﾄ ▼ﾎﾞﾀﾝ
            cmdMemoUp.Enabled = False                   '作業ﾒﾓ ▲ﾎﾞﾀﾝ
            cmdMemoDown.Enabled = False                 '作業ﾒﾓ ▼ﾎﾞﾀﾝ
            
            '@=======================
            '@ 各ﾎﾞﾀﾝ/ﾃｷｽﾄの制御処理(False：使用不可)
            '@=======================
            Call prvFrmxxEN0030_CmbInit(False)
            
            '@=======================
            '@ 装置一覧ｸﾞﾘｯﾄﾞ初期化処理
            '@=======================
            Call prvvsfWP_init()
                
            '@ｷｬﾘｱIDのｸﾘｱ
            txtCarrier.Text = vbNullString

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"True：起動成功"をｾｯﾄ
            pblnFormLoad = True

            '@引継ぎ情報表示済みﾌﾗｸﾞに"False：未表示"をｾｯﾄ
            mblnTakeOverDispFlg = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030        '機能ID
                .strProcName = "Form_Load"          'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString       'ｴﾗｰﾒｯｾｰｼﾞ
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
    '作成日：2004/07/27 (Tue) 11:59:00 H.Wajima
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2005/07/12 (Tue) 09:42:19 N.Kojima     OnErr処理、SetFocus対応追加
    '　　　：2005/07/14 (Thu) 15:25:39 N.Kojima     Validateﾌﾗｸﾞ処理を追加
    '　　　：2008/06/04 (Wed) 10:49:55 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2008/06/30 (Mon) 09:40:29 M.Koni       ﾃﾞﾌｫﾙﾄ装置以外の色変え処理追加 <案件No.03006>
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        
        Dim llngLoopCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾀ

        Try
            
            '@引継ぎ情報表示済みﾌﾗｸﾞが"True:表示済"か
            '@　※FormLoad後、最初の1回しか処理しないように
            If mblnTakeOverDispFlg = True Then
                '@引継ぎ情報が表示済みの場合
                
                '@Escﾎﾞﾀﾝを有効にし、処理抜け
                Me.CancelButton = cmdClose
                Exit Sub
            End If
                
            '@Escﾎﾞﾀﾝを有効にする
            Me.CancelButton = cmdClose
            
            '@引継ぎ情報表示済みﾌﾗｸﾞに"True：表示済"をｾｯﾄする
            mblnTakeOverDispFlg = True
            
            '@Validateﾌﾗｸﾞの初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
            mblnValidateFlag = True
            
            '@引継ぎ情報のｷｬﾘｱIDがNULL以外か
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@NULL以外の場合
                
                '@引継ぎ情報のｷｬﾘｱIDを設定する
                txtCarrier.Text = ptypCommonInfo.strCarrierId
                
                '@=======================
                '@ ｷｬﾘｱIDﾃｷｽﾄのValidate処理
                '@=======================
                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                
                '@=======================
                '@ ﾃﾞﾌｫﾙﾄ装置以外(pstrTerminalFlag="1"orNULL)かにより、ﾗﾍﾞﾙ&ｸﾞﾘｯﾄﾞﾀｲﾄﾙ行の色を変える
                '@ (ｷｬﾘｱ引き継ぎ時の処理)
                '@=======================
                Call prvColorChang_EN0030()
                
                '@選択可能装置があるか
                If vsfWp.Rows.Count > 2 Then
                
                    '@装置IDから選択状態の設定を行う(装置選択の一覧がある場合)
                    For llngLoopCnt = 1 To vsfWp.Rows.Count - 1
                    
                        '@引継ぎ情報の大工程、小工程、装置IDと、装置一覧ｸﾞﾘｯﾄﾞの大工程、小工程、装置IDが全て同じか
                        If vsfWp.GetData(llngLoopCnt, CMvsfWPColOpID) = ptypCommonInfo.strOpID And _
                           vsfWp.GetData(llngLoopCnt, CMvsfWPColStepID) = ptypCommonInfo.strStepID And _
                           vsfWp.GetData(llngLoopCnt, CMvsfWPColWpID) = ptypCommonInfo.strWpID Then
                            
                            '@同じ大工程、小工程、装置IDが存在する場合は選択状態にする
                            vsfWp.Select(llngLoopCnt, 0)
                            
                            '@=======================
                            '@ ｿｰﾄ前後処理(擬似的に行選択したので、ｶﾚﾝﾄ行情報格納の為に行なう必要がある)
                            '@=======================
                            Call pubVsfBeforeSort(vsfWp, CMvsfWPColOpID & vbTab & CMvsfWPColStepID & vbTab & CMvsfWPColWpID)
                            Call pubVsfAfterSort(vsfWp, CMvsfWPColOpID & vbTab & CMvsfWPColStepID & vbTab & CMvsfWPColWpID, cmdUP, cmdDown, False)
                            
                            Exit For
                        End If
                    Next
                End If
            End If
            
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
                .strMenuKey = CPstrKeyEN0030             '機能ID
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
    '機　能：ﾌｫｰﾑ　ｷｰﾀﾞｳﾝ時処理
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/03/03 (Wed) 12:31:54 T.Kitagawa
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2005/07/06 (Wed) 10:59:21 N.Kojima     OnErr処理、SetFocus対応追加
    '　　　：2005/07/12 (Tue) 16:07:11 N.Kojima     txtLoaderCarrier,txtCFCarrierが有効ｺﾝﾄﾛｰﾙの時の処理を追加
    '　　　：2005/07/13 (Wed) 15:38:41 S.Deguchi    作業ﾒﾓのEnterｷｰ有効処理追加
    '　　　：2008/06/04 (Wed) 10:58:42 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@以下の条件の場合、ｷｰｺｰﾄﾞを初期化し処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                e.Handled = True
                Exit Sub
            End If

            '@装置一覧ｸﾞﾘｯﾄﾞがｱｸﾃｨﾌﾞか
            If ActiveControl.Name = vsfWp.Name Then
                
                '@ｶﾚﾝﾄ行がﾀｲﾄﾙ行ではないか
                If vsfWp.Row > vsfWp.Rows.Fixed Then
                    
                    '@ｶﾚﾝﾄ列が装置名以外か
                    If vsfWp.Col <> CMvsfWPColWpName Then
                    
                        '@ｶﾚﾝﾄ列を装置名に移動
                        vsfWp.Col = CMvsfWPColWpName
                    End If
                End If
            End If
            
            '@=======================
            '@ ｸﾞﾘｯﾄﾞｷｰ制御処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfWp, cmdUP, cmdDown)
            
            '@★ ｷｰｺｰﾄﾞにより処理分岐 ★
            Select Case e.KeyCode
            
                '@〓 Enterｷｰ 〓
                Case Keys.Return
                
                    '@★★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★★
                    Select Case ActiveControl.Name
                    
                        '@〓〓 ｷｬﾘｱID 〓〓
                        Case txtCarrier.Name
                            
                            '@=======================
                            '@ ｷｬﾘｱIDﾃｷｽﾄValidate処理
                            '@=======================
                            Call txtCarrier_Validate(txtCarrier, New CancelEventArgs)
                            e.Handled = True


                        '@〓〓 作業ﾒﾓ 〓〓
                        Case txtWorkMemo.Name
                        
                            '@処理なし
                                        
                                        
                        '@〓〓 UnloaderｷｬﾘｱID 〓〓
                        Case txtLoaderCarrier.Name
                        
                            '@=======================
                            '@ ｱﾝﾛｰﾀﾞｷｬﾘｱIDﾃｷｽﾄValidate処理
                            '@=======================
                            Call txtLoaderCarrier_Validate(txtLoaderCarrier, New CancelEventArgs)
                            e.Handled = True
                            
                            
                        '@〓〓 CFｷｬﾘｱID(組立限定) 〓〓
                        Case txtCFCarrier.Name
                        
                            '@=======================
                            '@ CFｷｬﾘｱIDﾃｷｽﾄValidate処理
                            '@=======================
                            Call txtCFCarrier_Validate(txtCFCarrier, New CancelEventArgs)
                            e.Handled = True


                        '@〓〓 その他 〓〓
                        Case Else
                        
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                    
                    End Select
                    
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030        '機能ID
                .strProcName = "Form_KeyDown"       'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString       'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyPress
    '機　能：ﾌｫｰﾑ　ｷｰ押下時処理
    '引　数：KeyAscii：入力ｷｰｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/03/03 (Wed) 12:34:15 T.Kitagawa
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2005/07/06 (Wed) 10:59:50 N.Kojima     OnErr処理追加
    '　　　：2008/06/04 (Wed) 11:26:51 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub Form_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles MyBase.KeyPress
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｷｰｺｰﾄﾞが"'(ｶﾝﾏ)"か
            If Asc(e.KeyChar) = CMlngKeyAsciiComma Then
            
                '@ｶﾝﾏは入力禁止なので、ｷｰｺｰﾄﾞを無効にする
                e.Handled = True
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030        '機能ID
                .strProcName = "Form_KeyPress"      'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString       'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑ　終了時処理
    '引　数：Cancel     ：未使用
    '　　　：UnloadMode ：未使用
    '戻り値：
    '作成日：2004/04/13 (Tue) 13:52:10 N.Kasai
    '更新日：2012/04/13 (Fri) 12:51:40 Y.Yoneyama
    '備　考：
    '　　　：2004/11/01 (Mon) 15:39:07 N.Kasai      閉じるﾎﾞﾀﾝ統合
    '　　　：2005/07/06 (Wed) 11:10:07 N.Kojima     OnErr処理、SetFocus対応追加
    '　　　：2005/07/14 (Thu) 15:20:21 N.Kojima     Validateﾌﾗｸﾞ処理追加
    '　　　：2006/06/27 (Tue) 20:16:52 N.Kojima     ﾌﾗｸﾞの初期化処理追加。(ﾕｰｻﾞｰ要望№0189)
    '　　　：2008/06/04 (Wed) 11:31:08 N.Kojima     ｿｰｽ整備。(案件№02884)
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    '　　　：2010/06/16 (Wed) 17:03:09 T.Oide       №04097 使用部材ﾎﾞﾀﾝ追加対応
    '      ：2012/04/13 (Fri) 12:51:40 Y.Yoneyama   装置別ﾛｯﾄ一覧子より子画面起動での終了時対応
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      'ACT開放結果格納

        Try
            
            '@以下の条件の場合、処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            '@　③Validateﾌﾗｸﾞが"False:Validate中"の場合
            '@　　(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
            If Me.Enabled = False Or _
                mblnValidateFlag = False Then
                
                e.Cancel = True
                Exit Sub
            End If
            
            '@"×"ﾎﾞﾀﾝでの終了か
            If mblnCloseFromControlMenu Then
            
                '@=======================
                '@　閉じるﾎﾞﾀﾝ押下時処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, EventArgs.Empty)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@各種ﾊﾟﾌﾞﾘｯｸﾌﾗｸﾞを初期化
            pblnFormLoad = False                    '装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
            pblnMaterialSelectFlag = False          '使用部材選択済みﾌﾗｸﾞの初期化
            pstrCarrierCategoryID = vbNullString    '引継ｷｬﾘｱｶﾃｺﾞﾘIDの初期化
            pstrVaFlag = vbNullString               '引継無機ﾌﾗｸﾞの初期化
            pstrTpalClass = vbNullString            '引継TPAL設定の初期化
            pblnfrmxxEN0030Kbn = False              '引継作業開始ﾌﾗｸﾞの初期化
            
            '@使用部材ﾘｽﾄ構造体をｸﾘｱ
            ptypChkMaterial.typMaterialTypeList = Nothing
            ptypChkMaterial.lngMaterialTypeCnt = 0              '部材種別IDｶｳﾝﾄ
            ptypChkMaterial.strClassDivision = vbNullString     '処理区分
            ptypChkMaterial.strLotID = vbNullString             'ﾛｯﾄID
            ptypChkMaterial.strMaterialID = vbNullString        '部材ID
            ptypChkMaterial.strMaterialLotID = vbNullString     '部材管理ID
            ptypChkMaterial.strMaterialTypeID = vbNullString    '部材種別ID
            ptypChkMaterial.strMsgVer = vbNullString            'Msgﾊﾞｰｼﾞｮﾝ
            ptypChkMaterial.strSbID = vbNullString              'ｼｽﾃﾑﾌﾞﾛｯｸ
            ptypChkMaterial.strWpID = vbNullString              '装置ID
            
            '@ﾊﾟﾌﾞﾘｯｸ構造体の初期化
            ptypLotrecpList = Nothing               'ﾛｯﾄ別ﾚｼﾋﾟ一覧格納用
            ptypWFrecpList = Nothing                'WFﾚｼﾋﾟ一覧格納用
            mtypLotCurState.strSteplist = Nothing   'ﾛｯﾄ情報格納用
            pstrPDIDAry = Nothing                   '機種ﾘｽﾄ初期化
            
            
            '@Act初期化ﾌﾗｸﾞが"True:初期化済"か
            If pblnActInitFlg = True Then
                '@Actを自前で初期化した場合
                
                '@=======================
                '@ ACTｵﾌﾞｼﾞｪｸﾄ開放処理
                '@=======================
                lblnAnsTerm = pubblnAct_Term
                
                '@処理結果判定
                If lblnAnsTerm = True Then
                    '@結果：正常の場合
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                End If
            
        '@↓2012/04/13 (Fri) 12:51:20 Y.Yoneyama **************************************************
            '@Act初期化ﾌﾗｸﾞが"False:未初期化"の場合
            ElseIf pblnfrmxxEN0150BCR = False Then
            
                '@=======================
                '@ ﾒｲﾝﾒﾆｭｰ画面拡張処理
                '@=======================
                Call pubMenuExpand_Disp
        '@↑2012/04/13 (Fri) 12:51:20 Y.Yoneyama **************************************************

            End If
            
            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030            '機能ID
                .strProcName = "Form_QueryUnload"       'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Change
    '機　能：ｷｬﾘｱIDﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/15 (Thu) 14:45:43 M.Miura
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2005/07/06 (Wed) 11:10:40 N.Kojima     OnErr処理追加
    '　　　：2006/07/03 (Mon) 16:13:05 N.Kojima     ｷｬﾘｱが変更されたら使用部材一覧構造体を初期化。(ﾕｰｻﾞｰ要望№0189)
    '　　　：2008/07/03 (Thu) 10:02:45 M.Koni       ﾃﾞﾌｫﾙﾄ端末外の色変え処理追加<案件No.03006>
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change
        
        Try

            '@=======================
            '@ 各種初期化処理(画面内ｺﾝﾄﾛｰﾙ、変数等)
            '@=======================
            Call prvFrmxxEN0030_Init()
            
            '@=======================
            '@ 各ﾎﾞﾀﾝ/ﾃｷｽﾄの制御処理(指定なし：使用不可)
            '@=======================
            Call prvFrmxxEN0030_CmbInit()
            
            '@=======================
            '@ 装置一覧ｸﾞﾘｯﾄﾞ初期化処理
            '@=======================
            Call prvvsfWP_init()
            
            '@=======================
            '@ ｺﾝﾄﾛｰﾙの色の初期化
            '@=======================
            Call prvControlColor_Init()
            
            '@使用部材選択済みﾌﾗｸﾞの初期化
            pblnMaterialSelectFlag = False
            
            '@使用部材ﾘｽﾄ構造体をｸﾘｱ
            ptypChkMaterial.typMaterialTypeList = Nothing
            ptypChkMaterial.lngMaterialTypeCnt = 0              '部材種別IDｶｳﾝﾄ
            ptypChkMaterial.strClassDivision = vbNullString     '処理区分
            ptypChkMaterial.strLotID = vbNullString             'ﾛｯﾄID
            ptypChkMaterial.strMaterialID = vbNullString        '部材ID
            ptypChkMaterial.strMaterialLotID = vbNullString     '部材管理ID
            ptypChkMaterial.strMaterialTypeID = vbNullString    '部材種別ID
            ptypChkMaterial.strMsgVer = vbNullString            'Msgﾊﾞｰｼﾞｮﾝ
            ptypChkMaterial.strSbID = vbNullString              'ｼｽﾃﾑﾌﾞﾛｯｸ
            ptypChkMaterial.strWpID = vbNullString              '装置ID
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "txtCarrier_Change"          'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Validate
    '機　能：ｷｬﾘｱIDのLOST
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/03/03 (Wed) 11:00:56 T.Kitagawa
    '更新日：2012/04/18 (Wed) 11:02:00 Y.Yoneyama
    '備　考：ｱｸｼｮﾝ予約表示追加
    '　　　：2004/06/15 (Tue) 18:58:16 H.Wajima     流動ﾀｲﾌﾟ判定追加(不具合改善№888)
    '　　　：2005/07/06 (Wed) 11:11:14 N.Kojima     OnErr処理、SetFocus処理追加
    '　　　：2005/07/14 (Thu) 15:15:34 N.Kojima     Valdate中はﾌｫｰﾑをｱﾝﾛｰﾄﾞさせないようにする為のﾌﾗｸﾞ追加。
    '　　　：2008/06/30 (Mon) 12:23:29 M.Koni       自端末の自動選択＆ﾃﾞﾌｫﾙﾄ端末外の色変え処理追加<案件No.03006>
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    '　　　：2012/04/18 (Wed) 11:02:00 Y.Yoneyama   ｷｬﾘｱID照合機能対応
    Public Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim lblnAnsLot              As Boolean              '結果取得(True:正常,False:異常)
        Dim lblnAnsWP               As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngCnt1                As Integer              '汎用ｶｳﾝﾀ1
        Dim llngCnt2                As Integer              '汎用ｶｳﾝﾀ2
        Dim llngWpCount             As Integer              '端末WP_ID数
        Dim lstrWpNameAtList        As String
        Dim lstrWpNameByTerminal    As String
        Dim lstrCurrentWpID         As String
        Dim lblnWpIDMatch           As Boolean
        Dim lblnAns                 As Boolean
        Dim llngRowCnt              As Integer              '装置ﾘｽﾄの行ｶｳﾝﾀ
        Dim llngRowSetPosition      As Integer              '対象装置の行番号
        Dim ltypTmInfo              As UtilRefTmInfo        '端末設定情報格納

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの空白ﾁｪｯｸ
            If Trim(txtCarrier.Text) = vbNullString Then
                
                '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(cmdClose, txtCarrier)
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtCarrier.NowByte < txtCarrier.ChrMaxByte Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM07W>$$キャリアIDは6桁で入力してください。"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽを留める
                e.Cancel = True
                Exit Sub
            End If
                
        '@↓2012/04/17 (Tue) 18:17:25 Y.Yoneyama **************************************************
            '@=======================
            '@【端末設定情報取得】ﾒｯｾｰｼﾞ送受信処理 "util.reftminfo"
            '@=======================
            lblnAns = pubblnUtilRefTmInfo_Sel(pstrSBID, _
                                              CMstrutilreftminfoVer, _
                                              pstrComputerName, _
                                              ltypTmInfo)
            
            
            '@組立工程の場合
            If pstrSBID = CPstrSBID2A0 Then
                
                '@BCRｷｬﾘｱID照合からの引継ぎの場合
                If pblnfrmxxEN0150BCR = True Then
                    
                    '@BCRｷｬﾘｱID照合と違うｷｬﾘｱIDの場合
                    If txtCarrier.Text <> ptypCommonInfo.strCarrierId Then
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「<TRM2QW>$$BCRキャリアID照合中です。$$[%1]以外のキャリアは[%2]できません。」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002Q, ptypCommonInfo.strCarrierId, Me.Text)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        txtCarrier.Text = vbNullString
                        Call prvSetFocus(cmdClose, txtCarrier)
                        Exit Sub
                    End If
                    
                '@それ以外(作業開始画面単独起動、装置別ﾛｯﾄ一覧等からの引継ぎ)
                Else
                    '@端末にBCRが付属している場合(前回の入力確定ｷｬﾘｱは除く)
                    If pblnTerminalBCR = True And txtCarrier.Text <> mstrCarrier Then
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「<TRM2NW>$$BCRキャリアID照合が未実施です。$$作業を継続するには権限が必要です。」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002N)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@=======================
                        '@ 作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力画面　表示処理
                        '@=======================
                        frmxxCM0020.Instance.ShowDialog(Me)
                        frmxxCM0020.Instance = Nothing
            
                        '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
                        If pblnCancel = True Then
                            txtCarrier.Text = vbNullString
                            Call prvSetFocus(cmdClose, txtCarrier)
                            Exit Sub
                        End If
                
                        '@=======================
                        '@ 権限確認
                        '@=======================
                        If prvblnBCRCarrierIdSkip_Chk = False Then
                            txtCarrier.Text = vbNullString
                            Call prvSetFocus(cmdClose, txtCarrier)
                            Exit Sub
                        End If
                    End If
                End If
            End If
        '@↑2012/04/17 (Tue) 18:17:25 Y.Yoneyama **************************************************

            '@ﾌﾗｸﾞ判定開始(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
            mblnValidateFlag = False
            
            '@ｷｬﾘｱID情報の取得(入力ｷｬﾘｱIDと前回のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功)と違う場合のみ実行)
            If txtCarrier.Text <> mstrCarrier Then
            
                '@ﾛｯｸﾌﾗｸﾞ(ﾛｯｸ解除)
                mblnEnabled = True
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                lstrFormName = Me.Name
                lstrEventName = "txtCarrier_Validate"
                Call pubResponseStart(lstrFormName, lstrEventName)
                
                '@=======================
                '@ 各種初期化処理(画面内ｺﾝﾄﾛｰﾙ、変数等)
                '@=======================
                Call prvFrmxxEN0030_Init()
                
                '@=======================
                '@ 各ﾎﾞﾀﾝ/ﾃｷｽﾄの制御処理(False：使用不可)
                '@=======================
                Call prvFrmxxEN0030_CmbInit(False)
                
                '@ﾛｯﾄ情報構造体の初期化
                mtypLotCurState.strSteplist = Nothing
                
                '@=======================
                '@ ﾛｯﾄ現在状態取得
                '@=======================
                lblnAnsLot = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                                   CPstrCD10, _
                                                   txtCarrier.Text, _
                                                   mtypLotCurState)
                
                '@結果判定
                If lblnAnsLot = True Then
                    
                    '@=======================
                    '@ 画面表示処理
                    '@=======================
                    Call prvFrmxxEN0030_Disp()
                
                Else
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                
                    '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
                    mblnValidateFlag = True
                
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    Exit Sub
                End If
                    
                '@ｷｬﾘｱID退避(ﾒｯｾｰｼﾞ成功時)
                mstrCarrier = txtCarrier.Text
                
                '@作業条件表示
                txtOpeCond.Text = mtypLotCurState.strWorkCondition          '作業条件
                
                '@ﾘｽﾄが0以上の場合
                If mtypLotCurState.lngStepListCnt <> 0 Then
                    
                    '@無機対応(次工程で使用できるｷｬﾘｱｶﾃｺﾞﾘIDを取得する)
                    pstrCarrierCategoryID = mtypLotCurState.strNextCarrierCategoryId
                    
                    '@=======================
                    '@ 装置(WPID)一覧の設定
                    '@=======================
                    lblnAnsWP = prvblnVsfWP_Disp(mtypLotCurState)
                    
                    '@結果判定
                    If lblnAnsWP = False Then
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        
                        '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
                        mblnValidateFlag = True
                    
                        '@ﾚｼﾋﾟ設定変更ﾎﾞﾀﾝを有効にする
                        cmdWFRecp.Enabled = True
                        
                        '@ｷｬﾘｱIDにﾌｫｰｶｽを留める
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
                
                llngWpCount = 0                     '割り当て装置数のｸﾘｱ
                lstrCurrentWpID = vbNullString      '現在WP_IDのｸﾘｱ
                lblnWpIDMatch = False               '装置ﾘｽﾄ内一致ﾌﾗｸﾞを初期化
                pblnWpSelectFlag = False            '自端末の装置選択ﾌﾗｸﾞを初期化
                
        '@↓2012/04/25 (Wed) 14:08:39 Y.Yoneyama **************************************************
                '@先頭部へ移動
                '@=======================
                '@【端末設定情報取得】ﾒｯｾｰｼﾞ送受信処理 "util.reftminfo"
                '@=======================
                'lblnAns = pubblnUtilRefTmInfo_Sel(pstrSBID, _
                '                                  CMstrutilreftminfoVer, _
                '                                  pstrComputerName, _
                '                                  ltypTmInfo) '
        '@↑2012/04/25 (Wed) 14:08:39 Y.Yoneyama **************************************************

                '@通信結果判定
                If lblnAns = True Then
                    
                    '@結果：正常の場合
                    With ltypTmInfo
                        
                        '@端末情報が取得出来たか
                        If .strMcGroupID <> vbNullString Then
                            
                            '@取得したWPIDを変数に格納
                            llngWpCount = .lngWpListCount               '端末に割当られた装置数入手
                            lstrCurrentWpID = .strWpID                  '現設定WP入手
                        End If
                    End With
                
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)

                    With vsfWp
                        
                        '@行ｶｳﾝﾀ初期化
                        llngRowCnt = 0
                        llngRowSetPosition = 0

                        '@装置ｸﾞﾘｯﾄ読み出し＆WPID比較
                        For llngCnt1 = 1 To .Rows.Count - 1
                            
                            lstrWpNameAtList = .GetData(llngCnt1, CMvsfWPColWpID)
                            llngRowCnt = llngRowCnt + 1

                            For llngCnt2 = 0 To llngWpCount - 1
                                
                                lstrWpNameByTerminal = ltypTmInfo.typWpList(llngCnt2).strDefaultWpID

                                '@装置ﾘｽﾄ内に，自端末のWPIDがあるか？
                                If StrComp(lstrWpNameByTerminal, lstrWpNameAtList, 1) = 0 Then
                                    
                                    lblnWpIDMatch = True
                                    llngRowSetPosition = llngRowCnt                             '行位置格納
                                    
                                    '@あったらそのWPIDは，現在選択中のWPIDに一致しているか？
                                    If StrComp(lstrCurrentWpID, lstrWpNameByTerminal, 1) = 0 Then
                                        pblnWpSelectFlag = True
                                    End If
                                End If
                            Next llngCnt2

                            If pblnWpSelectFlag = True Then
                                Exit For
                            End If
                        Next llngCnt1
                    End With
                    
                    '@装置ﾘｽﾄの自動選択処理
                    '@端末1つに対し複数装置が割り当てられている場合は，自動選択を実施しない。
                    If llngWpCount = 1 Then
                        
                        '@装置ﾘｽﾄ内に自端末の装置があった場合，その行番号にフォーカスする。
                        If lblnWpIDMatch = True Then
                            
                            If llngRowSetPosition > 1 Then
                                vsfWp.TopRow = llngRowSetPosition - 1
                            End If
                            
                            vsfWp.Row = llngRowSetPosition          '自端末の装置を選択(vsfWP_AfterRowColChangeｲﾍﾞﾝﾄ発生)
                            
                            '@=======================
                            '@ 装置一覧初期ﾎﾞﾀﾝ設定
                            '@=======================
                            Call pubVsfDisp(vsfWp, cmdUP, cmdDown)
                        End If
                    End If
                Else
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                
                End If
                
                '@=======================
                '@ ﾃﾞﾌｫﾙﾄ端末で無ければ色を変える
                '@=======================
                Call prvColorChang_EN0030()

                '@装置が1件の場合
                With vsfWp
                    If .Rows.Count = .Rows.Fixed + 1 Then
                        .Select(.Rows.Fixed, CMvsfWPColOpID, .Rows.Fixed, CMvsfWPColStepID)
                        .Row = .Rows.Fixed
                    End If
                End With
                  
                '@ﾛｯｸﾌﾗｸﾞがﾛｯｸ解除の場合
                If mblnEnabled = True Then
                    
                    '@流動ﾀｲﾌﾟの判定
                    If mtypLotCurState.strFlowType = CPstrLotCurstateFlowTypeMove Then
                        '@移載工程の場合
                        
                        '@=======================
                        '@ 各ﾎﾞﾀﾝ/ﾃｷｽﾄの制御処理(True：使用可、True：移載工程)
                        '@=======================
                        Call prvFrmxxEN0030_CmbInit(True, True)

                    Else

                        '@=======================
                        '@ 各ﾎﾞﾀﾝ/ﾃｷｽﾄの制御処理(True：使用可、指定なし：移載工程以外)
                        '@=======================
                        Call prvFrmxxEN0030_CmbInit(True)
                        
                        '@最終ﾎﾞﾀﾝ判定
                        '@ﾚｼﾋﾟ詳細設定/確定ﾎﾞﾀﾝ
                        If vsfWp.Row <= 0 Then

                            cmdWFRecp.Enabled = False
                            cmdLotStart.Enabled = False
                            cmdActionDisp.Enabled = False
                        Else
                            
                            '@ﾊﾞｯﾁ編成されている場合
                            If mblnBacthFlg = True Then
                                
                                '@ﾚｼﾋﾟ設定変更ﾎﾞﾀﾝを無効
                                cmdWFRecp.Enabled = False
                            Else
                                '@ﾚｼﾋﾟ無しの場合
                                If lblRecp.Text = CMstrNoneRecipe Then
                                    
                                    '@ﾚｼﾋﾟ設定変更ﾎﾞﾀﾝを無効
                                    cmdWFRecp.Enabled = False
                                Else
                                    '@ﾚｼﾋﾟ設定変更ﾎﾞﾀﾝを有効
                                    cmdWFRecp.Enabled = True
                                End If
                            End If
                            
                            '@ｱﾝﾛｰﾀﾞｷｬﾘｱが無効か
                            If txtLoaderCarrier.Enabled = False Then
                                
                                '@確定ﾎﾞﾀﾝを有効に
                                cmdLotStart.Enabled = True
                            Else
                                '@ｱﾝﾛｰﾀﾞｷｬﾘｱがNULLではないか
                                If txtLoaderCarrier.Text <> vbNullString Then
                                    
                                    '@確定ﾎﾞﾀﾝを有効に
                                    cmdLotStart.Enabled = True
                                Else
                                    '@確定ﾎﾞﾀﾝを無効に
                                    cmdLotStart.Enabled = False
                                End If
                            End If
                            
                            '@ｱｸｼｮﾝ予約表示ﾎﾞﾀﾝの使用可否を設定する
                            If vsfWp.GetData(vsfWp.Row, CMvsfWPColActionFlg) = CMstrActionFlgFinish Then
                                
                                '@ｱｸｼｮﾝ予約表示ﾌﾗｸﾞが表示済の場合は使用可能にする
                                cmdActionDisp.Enabled = True
                            Else
                                '@ｱｸｼｮﾝ予約表示ﾌﾗｸﾞが未表示の場合は使用不可にする
                                cmdActionDisp.Enabled = False
                            End If
                        End If
                    End If
                End If
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            End If
            
            '@ﾌｫｰｶｽの制御
            If vsfWp.Enabled = True Then
                
                '@装置ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(vsfWp, txtCarrier)
            Else
                
                '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(cmdClose, txtCarrier)
            End If
            
            '@ﾌﾗｸﾞ初期化(True:Validate完了、False:Validate走行中ｲﾍﾞﾝﾄ中にﾌｫｰﾑを終了させない為、使用)
            mblnValidateFlag = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "txtCarrier_Validate"        'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLoaderCarrier_Change
    '機　能：LoaderｷｬﾘｱID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/12 (Thu) 09:47:01 N.Kasai
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：１文字でも入力した場合は入力値の正当性にかかわらず確定ﾎﾞﾀﾝ使用可
    '　　　：2005/05/19 (Thu) 17:44:59 N.Kasai      CFｷｬﾘｱID入力判定追加
    '　　　：2005/07/06 (Wed) 11:12:09 N.Kojima     OnErr処理追加
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub txtLoaderCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLoaderCarrier.Change
        
        Try
            
            '@入力判定
            If txtLoaderCarrier.Text <> vbNullString Then
                
                '@ﾚｼﾋﾟ判定
                If lblRecp.Text = vbNullString Then
                    '@ﾚｼﾋﾟなし
                    
                    '@確定ﾎﾞﾀﾝ利用不可
                    cmdLotStart.Enabled = False
                    Exit Sub
                End If

                'CFｷｬﾘｱが表示されている場合
                If txtCFCarrier.Visible = True Then
                    
                    '@CFｷｬﾘｱID使用可否判定
                    If txtCFCarrier.Enabled = True Then
                        
                        '@CFｷｬﾘｱID入力判定
                        If txtCFCarrier.Text = vbNullString Then
                            
                            '@確定ﾎﾞﾀﾝ利用不可
                            cmdLotStart.Enabled = False
                            Exit Sub
                        End If
                    End If
                End If

                '@確定ﾎﾞﾀﾝ利用可
                cmdLotStart.Enabled = True
            Else
                '@確定ﾎﾞﾀﾝ利用不可
                cmdLotStart.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "txtLoaderCarrier_Change"    'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLoaderCarrier_Validate
    '機　能：LoaderｷｬﾘｱID入力ﾁｪｯｸ処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/10 (Tue) 12:50:27 N.Kasai
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2004/09/27 (Mon) 11:48:59 N.Kasai　    ltypCarrCurstateにロットID追加
    '　　　：2005/05/19 (Thu) 16:13:19 N.Kojima     ｷｬﾘｱ状態取得Msgの引数に大工程ID、小工程ID、代替番号追加
    '　　　：2005/07/06 (Wed) 11:12:44 N.Kojima     OnErr処理、SetFocus対応追加
    '　　　：2005/07/12 (Tue) 15:38:47 N.Kojima     SetFocus判定処理追加
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub txtLoaderCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtLoaderCarrier.Validating
        
        Dim lblnAns                 As Boolean              '汎用戻り値結果取得(True:正常,False:異常)
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypCarrCurstate        As CarrCurstate         'ｷｬﾘｱ状態確認要求構造体
		Dim lstrResult					As String				'結果(0:対象外/1:蒸着2回対応対象機種)
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの空白ﾁｪｯｸ
            If Trim(txtLoaderCarrier.Text) = vbNullString Then
                '@空きｷｬﾘｱ選択ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                Exit Sub
            End If
            
            '@LoaderｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtLoaderCarrier.NowByte < txtLoaderCarrier.ChrMaxByte Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM07W>$$キャリアIDは6桁で入力してください。"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDにﾌｫｰｶｽを留める
                e.Cancel = True
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "txtLoaderCarrier_Validate"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@***********************
            '@ ｷｬﾘｱ情報(要求)格納
            '@***********************
            With ltypCarrCurstate
                
                .strCarrierId = txtLoaderCarrier.Text                           'LoaderｷｬﾘｱID
                .strClassDivision = CPstrCD10                                   '処理区分:作業開始
                .strMsgVer = CMstrcarrcurstateVer                               'MSGVER
                .strSbID = pstrSBID                                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                
                '@選択された装置よりL/U装置の場合lot_wplistのｷｬﾘｱﾀｲﾌﾟを取得する。
                '@TPALの場合LoaderとUnloaderのｷｬﾘｱﾀｲﾌﾟが相違する場合がある。
                '@L/U装置判定
                If vsfWp.GetData(vsfWp.Row, CMvsfWPColLoaderFlg) = CMstrLoaderUnloaderFlg Then
                    .strCarrierTypeID = vsfWp.GetData(vsfWp.Row, CMvsfWPColCarrierType)    'ｷｬﾘｱﾀｲﾌﾟ(wpより)
                Else
                    .strCarrierTypeID = mtypLotCurState.strCarrierTypeID                   'ｷｬﾘｱﾀｲﾌﾟ(loader側のｷｬﾘｱﾀｲﾌﾟを引き継ぎ)
                End If
                
                .strLotID = lblLotID.Text                                      'ﾛｯﾄID(作業開始のみ)
                .strOpID = vsfWp.GetData(vsfWp.Row, CMvsfWPColOpID)            '大工程ID(作業開始のみ)
                .strStepID = vsfWp.GetData(vsfWp.Row, CMvsfWPColStepID)        '小工程ID(作業開始のみ)
                .strAltNumber = vsfWp.GetData(vsfWp.Row, CMvsfWPColAltNumber)  '代替番号(作業開始のみ)
            End With

			'@起動SBが2A0=組立の場合
			'装置ﾀｲﾌﾟが無機異物検査装置の場合、蒸着2回対象機種判定を行う
            If pstrSBID = CPstrSBID2A0 And vsfWp.GetData(vsfWp.Row, CMvsfWPColEqType) =  CPstrEqTypeVFI Then

				'kkw 蒸着2回対応対象機種か確認
				lblnAns = pubblnDoubleJPd_Chk(CMstrlot_chkdoublejpdVer, _
							lblLotID.Text, _
							lblPdID.Text, _
							lstrResult, _
							CPstrCD10
							)

				'蒸着2回対応機種の作業開始
				If lstrResult = CPstrFlagOn Then
					ltypCarrCurstate.strClassDivision = CPstrCD4V            '処理区分:蒸着2回対応
				End If
			End If

            '@=======================
            '@ ｷｬﾘｱ状態取得
            '@=======================
            lblnAns = pubblnCarrcurstate_Sel(ltypCarrCurstate, True, vbNullString)
            
            '@取得結果確認
            If lblnAns = True Then
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@確定ﾎﾞﾀﾝが有効か
                If cmdLotStart.Enabled = True Then
                    
                    '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(cmdLotStart, txtLoaderCarrier)
                Else
                    '@ODFｷｬﾘｱﾃｷｽﾄが有効か
                    If txtCFCarrier.Visible = True And _
                        txtCFCarrier.Enabled = True Then
                        
                        '@ODFｷｬﾘｱﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
                        Call prvSetFocus(txtCFCarrier, txtLoaderCarrier)
                    Else
                        '@空きｷｬﾘｱ選択にﾌｫｰｶｽｾｯﾄ
                        Call prvSetFocus(cmdCarrierSelect, txtLoaderCarrier)
                    End If
                End If

            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDにﾌｫｰｶｽを留める
                e.Cancel = True
                Exit Sub

                
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "txtLoaderCarrier_Validate"  'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCFCarrier_Change
    '機　能：CFｷｬﾘｱID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/17 (Tue) 08:49:57 N.Kasai
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：１文字でも入力した場合は入力値の正当性にかかわらず確定ﾎﾞﾀﾝ使用可
    '　　　：2005/07/06 (Wed) 11:13:14 N.Kojima     OnErr処理追加
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub txtCFCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCFCarrier.Change
        
        Try
            
            '@入力判定
            If txtCFCarrier.Text <> vbNullString Then
                
                '@ﾚｼﾋﾟ判定
                If lblRecp.Text = vbNullString Then
                    
                    '@確定ﾎﾞﾀﾝ利用不可
                    cmdLotStart.Enabled = False
                    Exit Sub
                End If
            
                '@Unloaderｷｬﾘｱの入力ﾁｪｯｸ
                If txtLoaderCarrier.Text = vbNullString Then
                    
                    '@確定ﾎﾞﾀﾝ利用不可
                    cmdLotStart.Enabled = False
                    Exit Sub
                End If
            
                '@確定ﾎﾞﾀﾝ利用可
                cmdLotStart.Enabled = True
            Else
                '@確定ﾎﾞﾀﾝ利用不可
                cmdLotStart.Enabled = False
            End If
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "txtCFCarrier_Change"        'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCFCarrier_Validate
    '機　能：CFｷｬﾘｱID入力ﾁｪｯｸ処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/05/17 (Tue) 08:50:48 N.Kasai
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2005/06/06 (Mon) 08:59:29 N.Kasai      不要ﾀｸﾞ整理
    '　　　：2005/07/06 (Wed) 11:13:47 N.Kojima     OnErr処理追加
    '　　　：2005/07/12 (Tue) 16:13:28 N.Kojima     SetFocus改造に伴い、ﾌｫｰｶｽ制御修正
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub txtCFCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCFCarrier.Validating
        
        Dim lblnAns                 As Boolean              '汎用戻り値結果取得(True:正常,False:異常)

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの空白ﾁｪｯｸ
            If Trim(txtCFCarrier.Text) = vbNullString Then

                '@空きｷｬﾘｱ選択ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                Exit Sub
            End If

            '@CFｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtCFCarrier.NowByte < txtCFCarrier.ChrMaxByte Then

                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM07W>$$キャリアIDは6桁で入力してください。"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@CFｷｬﾘｱIDにﾌｫｰｶｽを留める
                e.Cancel = True
                Exit Sub
            End If
            
        '@↓2013/12/20 (Fri) 18:35:01 T.Oide **************************************************
            '@***********************
            '@ CFチェック
            '@***********************
            lblnAns = prvCfCarrier_Chk
            
            '@結果確認
            If lblnAns = False Then
                '@CFキャリアを空にする
                txtCFCarrier.Text = vbNullString
                '@CFｷｬﾘｱIDにﾌｫｰｶｽを留める
                e.Cancel = True
                
            End If
            
        '@-------------------------------------------------------------------------------------
        '@    '@ﾚｽﾎﾟﾝｽ取得開始
        '@    lstrFormName = frmxxEN0030.Name
        '@    lstrEventName = "txtCFCarrier_Validate"
        '@    Call pubResponseStart(lstrFormName, lstrEventName)
        '@
        '@    '@***********************
        '@    '@ CFｷｬﾘｱ状態取得送信ﾃﾞｰﾀ
        '@    '@***********************
        '@    With ltypCFListRec
        '@        .strMsgVer = CMstrcarrcfcurstateVer     'MSGﾊﾞｰｼﾞｮﾝ
        '@        .strSbId = pstrSBID                     'SBID
        '@        .strTFTLotID = lblLotID.Caption         'TFTﾛｯﾄ
        '@        .strWFNum = mtypLotCurState.strWFNum    'WF数量
        '@        .strCFCarrierID = txtCFCarrier.Text     'CFｷｬﾘｱID
        '@    End With
        '@
        '@    '@=======================
        '@    '@ CFｷｬﾘｱ状態取得
        '@    '@=======================
        '@    lblnAns = pubblnCarrCfCurstate_Sel(ltypCFListRec)
        '@
        '@    '@取得結果確認
        '@    If lblnAns = True Then
        '@
        '@        '@ﾚｽﾎﾟﾝｽ取得終了
        '@        Call publngResponseEnd(lstrFormName, lstrEventName)
        '@
        '@        '@確定ﾎﾞﾀﾝが有効か
        '@        If cmdLotStart.Enabled = True Then
        '@
        '@            '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
        '@            Call pubSetFocus(cmdLotStart)
        '@        Else
        '@            '@CFｷｬﾘｱ選択ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
        '@            Call pubSetFocus(cmdCFCarrierSelect)
        '@        End If
        '@    Else
        '@        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
        '@        Call pubResponseCancel(lstrFormName, lstrEventName)
        '@
        '@        '@CFｷｬﾘｱIDにﾌｫｰｶｽを留める
        '@        Cancel = True
        '@
        '@        Exit Sub
        '@    End If
        '@↑2013/12/20 (Fri) 18:35:01 T.Oide **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "txtCFCarrier_Validate"      'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotCommnt_Change
    '機　能：ﾛｯﾄｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:12:03 N.Kasai
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub txtLotCommnt_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLotCommnt.Change

        Try

            '@=======================
            '@ ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtLotCommnt, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030
                .strProcName = "txtLotCommnt_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotCommnt_KeyUp
    '機　能：ﾛｯﾄｺﾒﾝﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 13:47:07 N.Kasai
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub txtLotCommnt_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtLotCommnt.KeyUp

        Try

            '@=======================
            '@ ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtLotCommnt, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030
                .strProcName = "txtLotCommnt_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotCommnt_MouseUp
    '機　能：ﾛｯﾄｺﾒﾝﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 13:48:44 N.Kasai
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub txtLotCommnt_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtLotCommnt.MouseUp

        Try

            '@=======================
            '@ ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtLotCommnt, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030
                .strProcName = "txtLotCommnt_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTxtUp_Click
    '機　能：ｺﾒﾝﾄﾃｷｽﾄ用上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 10:34:21 Y.Yamagishi
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2004/09/07 (Tue) 17:09:14 N.Kasai      ｺﾒﾝﾄ使用可否判定追加
    '　　　：2005/07/06 (Wed) 11:01:27 N.Kojima     OnErr処理、SetFocus処理追加
    '　　　：2005/11/29 (Tue) 13:43:13 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdTxtUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtUp.Click
        
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
                '@ ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
                '@=======================
                Call pubtxtCmdUp_Proc(txtLotCommnt, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)

            End If
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030             '機能ID
                .strProcName = "cmdTxtUp_Click"             'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTxtDown_Click
    '機　能：ｺﾒﾝﾄﾃｷｽﾄ用下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 10:34:36 Y.Yamagishi
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2004/09/07 (Tue) 17:08:39 N.Kasai      ｺﾒﾝﾄ使用可否判定追加
    '　　　：2005/07/06 (Wed) 11:02:14 N.Kojima     OnErr処理、SetFocus処理追加
    '　　　：2005/11/29 (Tue) 13:44:16 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdTxtDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtDown.Click
        
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
                '@ ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
                '@=======================
                Call pubtxtCmdDown_Proc(txtLotCommnt, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030             '機能ID
                .strProcName = "cmdTxtDown_Click"           'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_Change
    '機　能：作業メモ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 14:39:17 M.Miura
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2005/07/06 (Wed) 11:14:22 N.Kojima     OnErr処理追加
    '　　　：2005/11/29 (Tue) 13:45:54 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change
        
        Dim llngNowByte As Integer  'ﾊﾞｲﾄ数

        Try
            
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtWorkMemo.NowByte
            
            '@=======================
            '@ 現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            '@=======================
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
                    
            '@=======================
            '@ ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
                          
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "txtWorkMemo_Change"         'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoUp_Click
    '機　能：作業メモの前頁切替
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 14:52:32 M.Miura
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2005/07/06 (Wed) 11:14:51 N.Kojima     OnErr処理、SetFocus処理追加
    '　　　：2005/11/29 (Tue) 14:08:19 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
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
            '@ ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            '@=======================
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "cmdMemoUp_Click"            'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoDown_Click
    '機　能：作業メモの次頁切替
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 14:53:27 M.Miura
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2005/07/06 (Wed) 11:15:16 N.Kojima     OnErr処理、SetFocus対応追加
    '　　　：2005/11/29 (Tue) 14:09:38 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
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
            '@ ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            '@=======================
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "cmdMemoDown_Click"          'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdEasyDivide_Click
    '機　能：簡易分割画面呼び出し
    '引　数：なし
    '戻り値：なし
    '作成日：2009/06/24 (Wed) 13:46:31 Y.Yoneyama
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdEasyDivide_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEasyDivide.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@引継ぎﾃﾞｰﾀ格納
            pstrLotID = lblLotID.Text
            pstrCarrierID = txtCarrier.Text
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@無機専用の簡易分割ﾌﾗｸﾞをたてる
            pblnMkEasyDivFlag = True
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@作業開始ﾌﾗｸﾞ
            pblnfrmxxEN0030Kbn = True

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ ﾛｯﾄ分割画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxEN0160.Instance = New frmxxEN0160()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxEN0160.Instance = Nothing
                
                '@無機専用の簡易分割ﾌﾗｸﾞの初期化
                pblnMkEasyDivFlag = False
                
                '@作業開始ﾌﾗｸﾞ
                pblnfrmxxEN0030Kbn = False
                
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ ﾛｯﾄ分割画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxEN0160.Instance.ShowDialog(Me)
            frmxxEN0160.Instance = Nothing
                
            '@使用したﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrLotID = vbNullString
            pstrCarrierID = vbNullString
            pblnMkEasyDivFlag = False
            pblnfrmxxEN0030Kbn = False
            
            '@=======================
            '@ ｷｬﾘｱIDﾃｷｽﾄ変更時処理
            '@=======================
            Call txtCarrier_Change(txtCarrier, EventArgs.Empty)

            'NSYS ｷｬﾘｱIDﾃｷｽﾄ変更時フォームが初期化されたタイミングで ActiveControlが移動するためさらに移動する
            ActiveControl = txtCarrier

            '@=======================
            '@ ｷｬﾘｱIDﾃｷｽﾄのValidate処理
            '@=======================
            Call txtCarrier_Validate(txtCarrier, New CancelEventArgs)
            
            '@確定ﾎﾞﾀﾝが有効な場合
            If cmdLotStart.Enabled = True Then
                
                '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdLotStart)
            End If

            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdEasyDivide_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：前頁ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/18 (Tue) 13:18:38 M.Miura
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2005/07/06 (Wed) 11:16:09 N.Kojima     OnErr処理追加
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
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
            '@ 前頁処理▲
            '@=======================
            Call pubVsfCmdUp(vsfWp, cmdUP, cmdDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
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
    '機　能：次頁ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/18 (Tue) 13:21:09 M.Miura
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2005/07/06 (Wed) 11:16:35 N.Kojima     OnErr処理追加
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
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
            '@ 次頁処理▼
            '@=======================
            Call pubVsfCmdDown(vsfWp, cmdUP, cmdDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "cmdDown_Click"              'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_KeyUp
    '機　能：作業ﾒﾓｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:15:19 N.Kasai
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub txtWorkMemo_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtWorkMemo.KeyUp

        Try
            
            '@=======================
            '@ ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030
                .strProcName = "txtLotCommnt_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_MouseUp
    '機　能：作業ﾒﾓﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:52:24 N.Kasai
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub txtWorkMemo_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtWorkMemo.MouseUp

        Try

            '@=======================
            '@ ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030
                .strProcName = "txtWorkMemo_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfWP_AfterRowColChange
    '機　能：装置変更処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '戻り値：なし
    '作成日：2004/05/20 (Thu) 17:18:52 M.Miura
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2004/09/03 (Fri) 14:09:40 M.Miura　    選択した大小工程をﾍｯﾀﾞに表示するように修正
    '　　　：2004/09/22 (Wed) 20:49:55 M.Miura　    ﾚｼﾋﾟ無しの場合にﾚｼﾋﾟ設定ﾎﾞﾀﾝの無効化
    '　　　：2005/05/17 (Tue) 09:13:39 N.Kasai      CFｷｬﾘｱ使用条件追加
    '　　　：2005/05/19 (Thu) 17:52:00 N.Kojima     Uni装置の場合、Unloaderｷｬﾘｱを消す処理を追加。(運用障害№342)
    '　　　：2005/07/06 (Wed) 11:16:55 N.Kojima     OnErr処理追加
    '　　　：2006/06/28 (Wed) 16:43:58 N.Kojima     使用部材選択ﾎﾞﾀﾝの制御を追加。(ﾕｰｻﾞｰ要望№0189)
    '　　　：2008/12/01 (Mon) 16:43:58 T.Oide       装置処理間隔ﾜｰﾆﾝｸﾞﾁｪｯｸ追加。(ﾕｰｻﾞｰ要望№03231)
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub vsfWP_AfterRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfWP.AfterRowColChange

        Dim lblnAns         As Boolean      '結果格納(True:OK/False:NG)
        Dim lblnAnsAct      As Boolean      '戻り値領域(ｱｸｼｮﾝ予約)
        Dim lstrErrMessage  As String       '装置の処理間隔ﾜｰﾆﾝｸﾞ時間をﾁｪｯｸした場合のｴﾗｰﾒｯｾｰｼﾞ格納
        Dim strEqchk_Result As String       '装置の処理間隔ﾜｰﾆﾝｸﾞ時間をﾁｪｯｸした場合の結果格納
        Dim lstrWP_ID       As String       'WP_ID
        Dim llngMsgAns      As Integer      'ﾒｯｾｰｼﾞﾎﾞｯｸｽの戻り値格納
        
        Try
               
            With vsfWp
                
                '@ﾀｲﾄﾙではない場合
                If e.NewRange.r1 >= .Rows.Fixed And e.OldRange.r1 <> e.NewRange.r1 Then
                    
                    '@選択した大工程、小工程をﾍｯﾀﾞに表示
                    lblOpID.Text = .GetData(e.NewRange.r1, CMvsfWPColOpID)
                    lblStepID.Text = .GetData(e.NewRange.r1, CMvsfWPColStepID)
                                
                    '@使用部材選択ﾎﾞﾀﾝが表示されている場合
                    If cmdSelectMaterial.Visible = True Then
                        
                        '@使用部材選択ﾎﾞﾀﾝを有効に
                        cmdSelectMaterial.Enabled = True
                    End If

                    'NSYS グリッド選択行ハイライト色不具合対応
                    'NSYS エラーダイアログを含む子画面表示時に新行が選択状態で表示させるためGridをRefresh
                    vsfWP.Refresh
                           
                    '@=======================
                    '@ ﾚｼﾋﾟ情報取得・表示処理
                    '@=======================
                    lblnAns = prvblnLblRecp_Disp()
                    
                    '@結果判別
                    If lblnAns = True Then
                        
                        '@=======================
                        '@ 入力ﾁｪｯｸ(False:UNI装置ﾁｪｯｸ)
                        '@=======================
                        lblnAns = prvblnLotStartInput_Check(False)
                        
                        '@結果判別
                        If lblnAns = True Then
                            
                            '@流動ﾀｲﾌﾟを判定する
                            If mtypLotCurState.strFlowType <> CPstrLotCurstateFlowTypeMove Then
                                '@移載工程以外の場合
                                
                                '@ﾊﾞｯﾁ編成されている場合
                                If mblnBacthFlg = True Then
                                    
                                    '@ﾚｼﾋﾟ設定変更ﾎﾞﾀﾝを無効
                                    cmdWFRecp.Enabled = False
                                Else
                                    '@ﾚｼﾋﾟ設定変更ﾎﾞﾀﾝを有効
                                    cmdWFRecp.Enabled = True
                                End If
                            Else
                                '@移載工程の場合
                                
                                '@ﾚｼﾋﾟ設定変更ﾎﾞﾀﾝを無効
                                cmdWFRecp.Enabled = False
                            End If
                            
                            '@確定ﾎﾞﾀﾝを有効に
                            cmdLotStart.Enabled = True
                        Else
                            '@ﾚｼﾋﾟ設定/確定ﾎﾞﾀﾝを無効に
                            cmdWFRecp.Enabled = False
                            cmdLotStart.Enabled = False
                        End If
                    Else
                        '@ﾚｼﾋﾟ設定/確定ﾎﾞﾀﾝを無効に
                        cmdWFRecp.Enabled = False
                        cmdLotStart.Enabled = False
                    End If
                    
                    '@ﾚｼﾋﾟ無しの場合
                    If lblRecp.Text = CMstrNoneRecipe Then
                        
                        '@ﾚｼﾋﾟ設定ﾎﾞﾀﾝを無効
                        cmdWFRecp.Enabled = False
                    End If
                    
                    '@UnloaderｷｬﾘｱIDの使用可否判定
                    If vsfWp.GetData(e.NewRange.r1, CMvsfWPColLoaderFlg) = CMstrLoaderUnloaderFlg Then
                        
                        '@統合の場合
                        If mtypLotCurState.strCarrierId <> vbNullString And mtypLotCurState.strEqType = "5" Then
                            
                            '@ｱﾝﾛｰﾀﾞｷｬﾘｱ/空ｷｬﾘｱ選択ﾎﾞﾀﾝを無効に
                            txtLoaderCarrier.Enabled = False
                            txtLoaderCarrier.BackColor = SystemColors.ControlLight
                            cmdCarrierSelect.Enabled = False
                        Else
                            '@LD/ULDﾎﾟｰﾄ装置(使用可)
                            txtLoaderCarrier.Enabled = True
                            txtLoaderCarrier.BackColor = Color.White
                            cmdCarrierSelect.Enabled = True
                        End If
                        
                        '@ｱﾝﾛｰﾀﾞｷｬﾘｱがNULLか
                        If txtLoaderCarrier.Text = vbNullString Then
                            '@確定ﾎﾞﾀﾝを無効に
                            cmdLotStart.Enabled = False
                        End If
                    Else
                        '@Uniﾎﾟｰﾄ装置(使用不可)
                        txtLoaderCarrier.Enabled = False
                        txtLoaderCarrier.BackColor = SystemColors.ControlLight
                        cmdCarrierSelect.Enabled = False
                        txtLoaderCarrier.Text = vbNullString
                    End If
                    
                    '@流動ﾀｲﾌﾟを判定する
                    If mtypLotCurState.strFlowType <> CPstrLotCurstateFlowTypeMove Then
                        '@移載工程以外の場合
                        
                        '@ｱｸｼｮﾝ予約表示ﾌﾗｸﾞの判定
                        If vsfWp.GetData(e.NewRange.r1, CMvsfWPColActionFlg) = CMstrActionFlgNever Then
                            
                            '@ｱｸｼｮﾝ予約表示ﾌﾗｸﾞが未表示の場合
                            With mtypLotCurState
                                
                                '@=======================
                                '@ ｱｸｼｮﾝ予約ﾘｽﾄの表示
                                '@=======================
                                lblnAnsAct = prvblncmdActionDisp_Proc(.strLotID, _
                                                                .strSteplist(vsfWp.GetData(e.NewRange.r1, CMvsfWPColStepCnt)).strOpID, _
                                                                .strSteplist(vsfWp.GetData(e.NewRange.r1, CMvsfWPColStepCnt)).strStepID, _
                                                                .strPdId, _
                                                                .strMasPdVersion, _
                                                                .strSteplist(vsfWp.GetData(e.NewRange.r1, CMvsfWPColStepCnt)).strWPList(vsfWp.GetData(e.NewRange.r1, CMvsfWPColWpCnt)).strWpID, _
                                                                ptypLotAction)
                            End With
                            
                            '@戻り値の判定
                            If lblnAnsAct = False Then
                                '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞがない場合
                                
                                '@ｱｸｼｮﾝ予約ﾎﾞﾀﾝ非活性化
                                cmdActionDisp.Enabled = False
                            Else
                                '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞがある場合
                                
                                '@ｱｸｼｮﾝ予約ﾎﾞﾀﾝ活性化
                                cmdActionDisp.Enabled = True
                                
                                '@ｱｸｼｮﾝ予約表示ﾌﾗｸﾞに表示済を設定する
                                vsfWp.SetData(e.NewRange.r1, CMvsfWPColActionFlg, CMstrActionFlgFinish)
                            End If
                        Else
                            '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞが既に表示済の場合は
                            
                            '@ｱｸｼｮﾝ予約ﾎﾞﾀﾝ活性化
                            cmdActionDisp.Enabled = True
                        End If
                    Else
                        '@移載工程の場合(移載工程の場合はｱｸｼｮﾝ予約がかけられないはずだけど一応)
                        
                        '@ｱｸｼｮﾝ予約ﾎﾞﾀﾝ非活性化
                        cmdActionDisp.Enabled = False
                    End If
                    
                    '@=======================
                    '@ 装置処理経過時間ﾁｪｯｸ
                    '@=======================
                    lstrWP_ID = vsfWp.GetData(e.NewRange.r1, CMvsfWPColWpID)
                    Call pubEqWarning_Chk(CMstreqchkintervalVer, lstrWP_ID, lstrErrMessage, strEqchk_Result)
                    
                    '@装置処理経過時間ﾁｪｯｸの結果ｵｰﾊﾞありの場合ﾜｰﾆﾝｸﾞﾒｯｾｰｼﾞ表示
                    If strEqchk_Result = CPstrchkResultNG Then
                        
                        '@ﾒｯｾｰｼﾞ表示
                        llngMsgAns = publngMsgBox(lstrErrMessage, vbExclamation, Me.Text, True, 16, False)
                    End If
                    
                End If


                '@CFｷｬﾘｱ、簡易分割使用可否
                '@EQ_TYPEの判定(ODF装置の場合は使用可)
                If e.NewRange.r1 >= .Rows.Fixed AndAlso _
                    vsfWp.GetData(e.NewRange.r1, CMvsfWPColEqType) = CPstrEqTypeODF Then
                    
                    '@CFｷｬﾘｱ使用可
                    txtCFCarrier.BackColor = Color.White
                    txtCFCarrier.Enabled = True
                    cmdCFCarrierSelect.Enabled = True
                    
        '@↓2013/12/19 (Thu) 10:21:20 T.Oide **************************************************
        '@            '@簡易分割ﾎﾞﾀﾝ使用不可
        '@            cmdEasyDivide.Enabled = False
        '@------------------------------------------------------------------------------------

                    '@簡易分割ﾎﾞﾀﾝ使用可
                    cmdEasyDivide.Enabled = True
        '@↑2013/12/19 (Thu) 10:21:20 T.Oide **************************************************
                    
                    
                '@CFｷｬﾘｱ使用可否
                '@EQ_TYPEの判定(TPAL装置&無機ﾛｯﾄでTPAL_CLASS設定時の場合は使用可)
                ElseIf e.NewRange.r1 >= .Rows.Fixed AndAlso _
                       vsfWp.GetData(e.NewRange.r1, CMvsfWPColEqType) = CPstrEqTypeTPAL AndAlso _
                       mtypLotCurState.strVaFlag = CPstrOne AndAlso _
                       mtypLotCurState.strTpalClass <> vbNullString Then
                       
                    '@CFｷｬﾘｱID入力不可
                    txtCFCarrier.BackColor = SystemColors.ControlLight
                    txtCFCarrier.Enabled = False
                    
                    '@CFｷｬﾘｱ選択ﾎﾞﾀﾝ使用可
                    cmdCFCarrierSelect.Enabled = True
                    
                    '@ﾊﾞｯﾁ貼合時は分割なし
                    If mtypLotCurState.strTpalClass = CPstrTpalJBatch Then
                        '@簡易分割ﾎﾞﾀﾝ使用不可
                        cmdEasyDivide.Enabled = False
                    Else
                        '@簡易分割ﾎﾞﾀﾝ使用可
                        cmdEasyDivide.Enabled = True
                    End If
                    
                Else
                    '@CFｷｬﾘｱ使用不可
                    txtCFCarrier.BackColor = SystemColors.ControlLight
                    txtCFCarrier.Enabled = False
                    cmdCFCarrierSelect.Enabled = False
                    '@簡易分割ﾎﾞﾀﾝ使用不可
                    cmdEasyDivide.Enabled = False
                End If
            
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "vsfWP_AfterRowColChange"    'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfWP_BeforeRowColChange
    '機　能：装置ﾘｽﾄ行列変更前処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：
    '作成日：2006/07/03 (Mon) 16:22:45 N.Kojima
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub vsfWP_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfWP.BeforeRowColChange
        
        Dim llngAns     As Integer  '戻り値格納用
        
        Try
            
            With vsfWp
                
                '@ﾀｲﾄﾙではない場合
                If e.NewRange.r1 >= .Rows.Fixed And e.OldRange.r1 <> e.NewRange.r1 And e.OldRange.r1 <> 0 Then
                    
                    '@使用部材ﾘｽﾄ構造体にﾃﾞｰﾀが存在する場合
                    If ptypChkMaterial.lngMaterialTypeCnt <> 0 Then
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM8EW>$$装置を変更した場合、部材の選択情報をクリアします。 $よろしいですか？"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008E)
                        llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                        
                        '@要求確認
                        If llngAns = vbNo Then          '内容破棄しない
                            '@処理しない
                            e.Cancel = True
                            Exit Sub
                        End If
                        
                        '@使用部材選択済みﾌﾗｸﾞの初期化
                        pblnMaterialSelectFlag = False
                        
                        '@使用部材ﾘｽﾄ構造体をｸﾘｱ
                        ptypChkMaterial.typMaterialTypeList = Nothing
                        ptypChkMaterial.lngMaterialTypeCnt = 0              '部材種別IDｶｳﾝﾄ
                        ptypChkMaterial.strClassDivision = vbNullString     '処理区分
                        ptypChkMaterial.strLotID = vbNullString             'ﾛｯﾄID
                        ptypChkMaterial.strMaterialID = vbNullString        '部材ID
                        ptypChkMaterial.strMaterialLotID = vbNullString     '部材管理ID
                        ptypChkMaterial.strMaterialTypeID = vbNullString    '部材種別ID
                        ptypChkMaterial.strMsgVer = vbNullString            'Msgﾊﾞｰｼﾞｮﾝ
                        ptypChkMaterial.strSbID = vbNullString              'ｼｽﾃﾑﾌﾞﾛｯｸ
                        ptypChkMaterial.strWpID = vbNullString              '装置ID
                    End If
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "vsfWP_BeforeRowColChange"   'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWFRecp_Click
    '機　能：ﾚｼﾋﾟ詳細表示画面を表示する
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 16:07:18 T.Oide
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2004/11/02 (Tue) 15:06:58 M.Miura      ﾚｼﾋﾟ設定変更画面で使用するｷｬﾘｱ格納を追加(空きｷｬﾘｱ選択をしたｷｬﾘｱがﾚｼﾋﾟ画面に引き継がれる為)
    '　　　：2005/02/21 (Mon) 10:34:03 N.Kasai      pblnWpIDNullFlagﾌﾗｸﾞ判定追加(№510)
    '　　　：2005/06/28 (Tue) 12:32:24 N.Kojima     ｺﾒﾝﾄ行削除(pblnWpIDNullFlagﾌﾗｸﾞ判定処理部)
    '　　　：2005/07/06 (Wed) 11:03:04 N.Kojima     OnErr処理、SetFocus処理追加
    '　　　：2005/10/25 (Tue) 17:08:44 S.Deguchi    引継起動処理を修正
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdWFRecp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWFRecp.Click
        
        Dim lstrOldKey              As String               '旧：大工程ID+小工程ID+装置ID
        Dim lstrWorkMemo            As String               '作業ﾒﾓ退避用変数

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
              
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@ﾚｼﾋﾟ設定変更画面で使用するｷｬﾘｱを格納
            pstrCarrierID = txtCarrier.Text
            
            '@起動ﾌﾗｸﾞ(親から起動)
            pblnfrmxxCM0050Kbn = True
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ ﾚｼﾋﾟ設定変更画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0050.Instance = New frmxxCM0050()
            
            '@ﾚｼﾋﾟ詳細画面名称設定
            frmxxCM0050.Instance.Text = CPstrSubDispTitleRepSet
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                
                '@特殊処理：起動失敗の場合には,明示的にﾌﾗｸﾞを立てる
                pblnfrmxxCM0050CVFlag = True
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM0050.Instance = Nothing
                
                '@ﾌﾗｸﾞを戻す
                pblnfrmxxCM0050CVFlag = False
                
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ ﾚｼﾋﾟ設定変更画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0050.Instance.ShowDialog(Me)
            frmxxCM0050.Instance = Nothing
            
            '@起動ﾌﾗｸﾞの初期化
            pblnfrmxxCM0050Kbn = False
            
            '@ｻﾌﾞ画面で確定の場合
            If pblnSubDecision = True Then
                
                With vsfWp
                    
                    '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列 [ ﾛｯﾄID ] )
                    Call pubVsfBeforeSort(vsfWp, CMvsfWPColOpID & vbTab & CMvsfWPColStepID & vbTab & CMvsfWPColWpID)
                    
                    '@ｶﾚﾝﾄｷｰ値の保持
                    lstrOldKey = pubstrVsfTag_Get(vsfWp, 2)
                End With
                
                '@作業ﾒﾓ退避
                lstrWorkMemo = txtWorkMemo.Text
                
                '@=======================
                '@ ｷｬﾘｱID変更処理
                '@ ※ﾛｯﾄ最終更新日時を取得する為
                '@=======================
                Call txtCarrier_Change(txtCarrier, EventArgs.Empty)
                
                txtCarrier.Text = pstrCarrierID
                
                '@=======================
                '@ ｷｬﾘｱIDﾃｷｽﾄValidate処理
                '@=======================
                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs)
                
                With vsfWp
                    
                    '@最新の装置がある場合
                    If .Rows.Fixed < .Rows.Count Then
                        
                        '@=======================
                        '@ ｶﾚﾝﾄｷｰ値の設定
                        '@=======================
                        Call pubblnVsfTag_Set(vsfWp, 2, lstrOldKey)
                        
                        '@=======================
                        '@ ｶﾚﾝﾄ行の設定(ｸﾞﾘｯﾄﾞ、保持列 [ ﾛｯﾄID ] )
                        '@=======================
                        Call pubVsfAfterSort(vsfWp, CMvsfWPColOpID & vbTab & CMvsfWPColStepID & vbTab & CMvsfWPColWpID, cmdUP, cmdDown)
                        
                        '@=======================
                        '@ ﾚｼﾋﾟ表示処理
                        '@=======================
                        Call prvblnLblRecp_Disp()

                        '@作業開始→ﾚｼﾋﾟ変更画面で使用(True:WP_ID=NULL)
                        pblnWpIDNullFlag = False
                        
                        '@WP_IDが1件の場合
                        If .Rows.Count = 2 Then
                            '@1行目をｾﾚｸﾄ
                            .Select(1, CMvsfWPColOpID)
                        End If
                    Else
                        '@作業開始→ﾚｼﾋﾟ変更画面で使用(True:WP_ID=NULL)
                        pblnWpIDNullFlag = True
                    End If
                End With
                
                '@作業ﾒﾓ
                txtWorkMemo.Text = lstrWorkMemo
            End If
            
            '@確定ﾎﾞﾀﾝがﾛｯｸ解除の場合
            If cmdLotStart.Enabled = True Then
                
                '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                'NSYS pubVsfAfterSort によって、ActiveControl が vsfWP に移動している場合があるため、
                '     prvSetFocusでなく直接共通関数 pubSetFocus を呼び出す
                Call pubSetFocus(cmdLotStart)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "cmdWFRecp_Click"            'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdActionDisp_Click
    '機　能：ｱｸｼｮﾝ予約表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 16:24:24 T.Oide
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2005/07/06 (Wed) 11:03:38 N.Kojima     OnErr処理追加
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdActionDisp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdActionDisp.Click
        
        Dim lblnAnsAct              As Boolean              '結果取得(True:正常,False:異常)
        Dim llngRow                 As Integer              '行番号

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
            
            '@装置一覧の選択行を取得
            llngRow = vsfWp.Row
            
            '@★ 装置一覧の選択行により処理分岐 ★
            Select Case llngRow
                
                '@〓 -1：ﾃﾞｰﾀ行以外 〓
                Case Is <= -1
                    
                    '@選択されていない場合
                    Exit Sub
                
                '@〓 0：ﾀｲﾄﾙ行 〓
                Case 0 To vsfWp.Rows.Fixed - 1
                    
                    '@見出し行が選択されている場合
                    Exit Sub
            
            End Select
            
            With mtypLotCurState
                
                '@=======================
                '@ ｱｸｼｮﾝ予約ﾘｽﾄ表示処理
                '@=======================
                lblnAnsAct = prvblncmdActionDisp_Proc(.strLotID, _
                                                .strSteplist(vsfWp.GetData(llngRow, CMvsfWPColStepCnt)).strOpID, _
                                                .strSteplist(vsfWp.GetData(llngRow, CMvsfWPColStepCnt)).strStepID, _
                                                .strPdId, _
                                                .strMasPdVersion, _
                                                .strSteplist(vsfWp.GetData(llngRow, CMvsfWPColStepCnt)).strWPList(vsfWp.GetData(llngRow, CMvsfWPColWpCnt)).strWpID, _
                                                ptypLotAction)
            End With
                        
            '@戻り値の判定
            If lblnAnsAct = False Then
                '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞがない場合
                
                '@ｱｸｼｮﾝ予約ﾎﾞﾀﾝ非活性化
                cmdActionDisp.Enabled = False
            Else
                '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞがある場合
                
                '@ｱｸｼｮﾝ予約ﾎﾞﾀﾝ活性化
                cmdActionDisp.Enabled = True
                
                '@ｱｸｼｮﾝ予約表示ﾌﾗｸﾞに表示済を設定する
                vsfWp.SetData(llngRow, CMvsfWPColActionFlg, CMstrActionFlgFinish)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "cmdActionDisp_Click"        'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommntInput_Click
    '機　能：ﾛｯﾄｺﾒﾝﾄ登録画面表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 13:16:16 S.Deguchi
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2005/07/06 (Wed) 11:04:41 N.Kojima     OnErr処理追加
    '　　　：2005/11/02 (Wed) 13:44:23 S.Deguchi    不具合№2404の対応で,ﾛｯﾄｺﾒﾝﾄの子画面起動方法を修正
    '　　　：2008/06/04 (Wed) 10:27:50 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
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

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@***********************
            '@ 引継ぎﾃﾞｰﾀを格納
            '@ ※ptypLotprestateに格納してfrmxxCM0030を呼ぶ
            '@***********************
            With ptypLotprestate
                
                .strLotID = lblLotID.Text
                .strFlowClass = lblFlowClass.Text
                .strWfNum = lblWFNo.Text
                .strOpID = lblOpID.Text
                .strStartTime = lblStartDayTime.Text
                .strPdId = lblPdID.Text
                .strSpecialFlg = lblS.Text
                .strNowST = lblStatus.Text
                .strStepID = lblStepID.Text
                .strEngEmpName = lblLotManager.Text
                .strLimitTime = mtypLotCurState.strLimitTime
                .strWarnTime = mtypLotCurState.strWarnTime
                .strComments = txtLotCommnt.Text
                .strLotLastUpdate = mstrLotLastUpdate
                '@↓2020/01/15 (Wed) 16:51:27 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .strGRBClass = lblGRB.Text
                '@↑2020/01/15 (Wed) 16:51:27 Y.Yoneyama 「.Netへ反映未」 **************************************************
                
                pstrCarrierID = txtCarrier.Text                         'ｷｬﾘｱID
                
                '@親ﾌｫｰﾑからの呼び出しを識別するためにTrueにする
                pblnfrmxxCM0030Kbn = True
            
                '@起動ﾌﾗｸﾞを設定
                pblnFormLoad = False
                
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@ ﾛｯﾄｺﾒﾝﾄ画面　起動処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM0030.Instance = New frmxxCM0030()
                
                '@=======================
                '@ 機能関連情報取得処理
                '@=======================
                Call pubMenuItemCorrelation_Set(CPstrKeyEN0140, lstrTitle)

                '@ﾛｯﾄｺﾒﾝﾄ画面の名称設定
                frmxxCM0030.Instance.Text = lstrTitle
                
                '@ﾌｫｰﾑの呼出識別から判別
                If pblnFormLoad = True Then
                    
                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    '@ ﾛｯﾄｺﾒﾝﾄ画面　表示処理
                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    frmxxCM0030.Instance.ShowDialog(Me)
                    frmxxCM0030.Instance = Nothing
                    
                    '@ｺﾒﾝﾄｾｯﾄ
                    txtLotCommnt.Text = .strComments
                    
                    '@最終更新日時ｾｯﾄ
                    mstrLotLastUpdate = ptypLotprestate.strLotLastUpdate
                Else
                
                    '@∇∇∇∇∇∇∇∇∇∇∇
                    '@ ｱﾝﾛｰﾄﾞ処理
                    '@∇∇∇∇∇∇∇∇∇∇∇
                    frmxxCM0030.Instance = Nothing
                
                    '@起動ﾌﾗｸﾞを戻す
                    pblnFormLoad = True
                    
                    Exit Sub
                End If
                
                '@次項目にﾌｫｰｶｽｾｯﾄ
                SendKeys.SendWait(CPstrSendKeysTab)

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "cmdCommntInput_Click"       'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSelectMaterial_Click
    '機　能：使用部材選択
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/27 (Tue) 15:16:53 N.Kojima
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdSelectMaterial_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSelectMaterial.Click

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
                
            '@引継ぎﾃﾞｰﾀ格納
            pstrWPID = vsfWp.GetData(vsfWp.Row, CMvsfWPColWpID)        '装置ID

            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 使用部材一覧画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00Y0.Instance = New frmxxCM00Y0()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM00Y0.Instance = Nothing
                
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 使用部材一覧画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00Y0.Instance.ShowDialog(Me)
            frmxxCM00Y0.Instance = Nothing
            
            '@使用したﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrWPID = vbNullString                '装置ID
            
            '@確定ﾎﾞﾀﾝが有効な場合
            If cmdLotStart.Enabled = True Then
                
                '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(cmdLotStart, cmdSelectMaterial)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "cmdSelectMaterial_Click"    'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCarrierSelect_Click
    '機　能：空きｷｬﾘｱ一覧表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/10 (Tue) 09:24:13 N.Kasai
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2004/10/21 (Thu) 09:23:53 Y.Yamagishi  基板工程の場合ｷｬﾘｱﾀｲﾌﾟID引渡し処理追加(FOUP)
    '　　　：2004/10/22 (Fri) 15:20:45 Y.Yamagishi  ｱﾝﾛｰﾀﾞｰｷｬﾘｱﾀｲﾌﾟID引渡し処理追加
    '　　　：2005/07/06 (Wed) 11:05:02 N.Kojima     OnErr処理、SetFocus処理追加
    '　　　：2005/10/06 (Thu) 16:34:39 S.Deguchi    ｷｬﾘｱの洗浄条件設定処理を追加
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub cmdCarrierSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCarrierSelect.Click
        
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
            
            '@移載先ｷｬﾘｱID保存
            pstrCarrierID = txtLoaderCarrier.Text
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            With vsfWp
                
                '@ｱﾝﾛｰﾀﾞｰｷｬﾘｱﾀｲﾌﾟIDがNULL以外の場合
                If .GetData(.Row, CMvsfWPColCarrierType) <> vbNullString Then
                    
                    '@ｱﾝﾛｰﾀﾞｰｷｬﾘｱﾀｲﾌﾟID引渡し
                    pstrCarrierTypeID = .GetData(.Row, CMvsfWPColCarrierType)

                End If
                
                '@洗浄条件がNULL以外の場合
                If .GetData(.Row, CMvsfWPColCleanCondition) <> vbNullString Then
                    
                    '@洗浄条件引渡し
                    pstrCleanCondition = .GetData(.Row, CMvsfWPColCleanCondition)
                End If
            End With
            
			'kkw 蒸着2回対応
			'組立工程 無機異物検査装置 蒸着2回対象機種の場合　基板キャリアを一覧に表示する
			Dim lstrEqType As String
			Dim lblnAns As Boolean = False
			Dim lstrResult As String
			'@起動SBが2A0=組立の場合
            If pstrSBID = CPstrSBID2A0 Then

                '@装置ﾀｲﾌﾟ格納
                lstrEqType = vsfWp.GetData(vsfWp.Row, CMvsfWPColEqType)
				if lstrEqType = CPstrEqTypeVFI Then


					'kkw 蒸着2回対応対象機種か確認
					lblnAns = pubblnDoubleJPd_Chk(CMstrlot_chkdoublejpdVer, _
								lblLotID.Text, _
								lblPdID.Text, _
								lstrResult, _
								CPstrCD10)

					'蒸着2回対応機種の特殊流動最終工程(基板のみ）
					If lblnAns = true And lstrResult = CPstrFlagOn Then
						pblnDoubleJPdFlag = True
					End If

				End If

			End If

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 空きｷｬﾘｱ一覧画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00E0.Instance = New frmxxCM00E0()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM00E0.Instance = Nothing
                
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 空きｷｬﾘｱ一覧画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00E0.Instance.ShowDialog(Me)
            frmxxCM00E0.Instance = Nothing
                 
            '@空きｷｬﾘｱが選択されている場合
            If pstrCarrierID <> vbNullString Then
                
                '@ｷｬﾘｱIDをｾｯﾄ
                txtLoaderCarrier.Text = pstrCarrierID
            End If
            
            '@使用したﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrCarrierTypeID = vbNullString                'ｷｬﾘｱﾀｲﾌﾟ
            pstrCleanCondition = vbNullString               '洗浄条件
            pstrCarrierID = vbNullString                    'ｷｬﾘｱID
            pblnDoubleJPdFlag = false
            '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
            Call prvSetFocus(txtLoaderCarrier, cmdCarrierSelect)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "cmdCarrierSelect_Click"     'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCFCarrierSelect_Click
    '機　能：CFｷｬﾘｱ選択ﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/05/17 (Tue) 08:39:18 N.Kasai
    '更新日：2013/12/25 (Wed) 17:22:27 T.Oide
    '備　考：
    '　　　：2005/07/06 (Wed) 11:05:42 N.Kojima     OnErr処理、SetFocus処理追加
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/10/07 (Wed) 16:10:01 N.Kojima     CFｷｬﾘｱ一覧をTFT/CFﾛｯﾄ紐付き情報と共通化使用にしたことに伴う修正。(案件№03791)
    Private Sub cmdCFCarrierSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCFCarrierSelect.Click
        
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
            
            '@CFｷｬﾘｱID保存
            pstrCFCarrierID = txtCFCarrier.Text
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化(True：起動成功、False：起動中(起動失敗)・初期値)
            pblnFormLoad = False

        '@↓2009/10/07 (Wed) 14:39:05 N.Kojima **************************************************

            '@ﾌｫｰﾑ起動区分に"0：CFｷｬﾘｱ一覧起動"をｾｯﾄ
            '@ ※ﾌｫｰﾑ起動区分は初期値が"0"なので「Show」後の初期化は無し。
            plngfrmxxCM00T0Kbn = CPlngNumZero

        '@↑2009/10/07 (Wed) 14:39:05 N.Kojima **************************************************

            '@***********************
            '@ 引継ぎ情報作成
            '@***********************
            With ptypOdfInfo
                
                .strUnloaderCarrier = txtLoaderCarrier.Text         'TFTｷｬﾘｱID
                .strLoaderCarrier = txtCarrier.Text                 'TFTｷｬﾘｱID
                .strLotID = mtypLotCurState.strLotID                'TFTﾛｯﾄID
                .strFlowClass = mtypLotCurState.strFlowClass        '種別
                .strPdId = mtypLotCurState.strPdId                  '機種
                .strStatus = mtypLotCurState.strNowST               '状態
                .strWfNum = mtypLotCurState.strWfNum                '数量(WF)
                .strChipNum = mtypLotCurState.strChipQuantity       '数量(CHIP)
                .strCFCarrierID = mtypLotCurState.strCFCarrierID    'CFｷｬﾘｱID
                .strWpID = mtypLotCurState.strWpID                  'WPID
                .strOpID = mtypLotCurState.strOpID                  '大工程
                .strStepID = mtypLotCurState.strStepID              '小工程
            End With
            
            pstrVaFlag = mtypLotCurState.strVaFlag                  '無機ﾌﾗｸﾞ
            pstrTpalClass = mtypLotCurState.strTpalClass            'TPAL設定
            
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ CFｷｬﾘｱ一覧画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00T0.Instance = New frmxxCM00T0()
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False：起動処理失敗"か
            If pblnFormLoad = False Then
                
                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM00T0.Instance = Nothing
                
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ CFｷｬﾘｱ一覧画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00T0.Instance.ShowDialog(Me)
            frmxxCM00T0.Instance = Nothing
                 
            '@子画面でCFｷｬﾘｱが選択されたか
        '@↓2013/12/25 (Wed) 17:23:20 T.Oide **************************************************
        '@    If pstrCFCarrierID <> vbNullString Then
        '@-------------------------------------------------------------------------------------

            If pstrCFCarrierID <> vbNullString And _
               txtCFCarrier.Enabled = True Then
        '@↑2013/12/25 (Wed) 17:23:20 T.Oide **************************************************
                
                '@選択CFｷｬﾘｱIDをｾｯﾄ
                txtCFCarrier.Text = pstrCFCarrierID
                
                '@CFｷｬﾘｱIDﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(txtCFCarrier, cmdCFCarrierSelect)
            End If
            
            '@各種Public変数の初期化(保険：子画面で初期化してるので基本は問題ない)
            pstrVaFlag = vbNullString               '無機ﾌﾗｸﾞ
            pstrTpalClass = vbNullString            'TPAL設定

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "cmdCFCarrierSelect_Click"   'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLotStart_Click
    '機　能：確定(作業開始)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/04 (Thu) 18:48:59 T.Kitagawa
    '更新日：2015/12/01 (Tue) 13:47:33 H.Hayashi
    '備　考：
    '　　　：2004/09/17 (Fri) 11:26:04 Y.Yamagishi　時間制限対応(不具合改善№701)
    '　　　：2004/09/23 (Thu) 17:08:03 Y.Yamagishi　時間制限対応(不具合改善№871)
    '　　　：2004/10/14 (Thu) 13:59:14 Y.Yamagishi　引継ぎ構造体の代替番号ｸﾘｱ(不具合改善№1074)
    '　　　：2005/01/31 (Mon) 14:24:43 N.Kasai      CMP対応(№304)ﾚｼﾋﾟﾊﾟﾗﾒｰﾀ値の設定有無判定を追加
    '　　　：2005/03/02 (Wed) 17:28:07 S.Deguchi    不具合№261の対応で引継構造体へｾｯﾄするｷｬﾘｱを変更する処理を追加
    '　　　：2005/03/17 (Thu) 14:46:54 N.Kojima     Msg構造体にﾛｰﾀﾞ/ｱﾝﾛｰﾀﾞﾌﾗｸﾞ追加(運用障害№265)
    '　　　：2005/04/13 (Wed) 08:48:56 N.Kasai      不具合№541　ﾚｼﾋﾟﾊﾟﾗﾒｰﾀ値の入力ﾁｪｯｸでEQ_TYPE=9の条件を外す
    '　　　：2005/05/19 (Thu) 16:27:23 N.Kasai      CFｷｬﾘｱID追加(ODF対応)
    '　　　：2005/06/28 (Tue) 12:34:53 N.Kojima     ｺﾒﾝﾄ行の削除(Loader/Unloaderﾌﾗｸﾞ処理、CMP対応部等)
    '　　　：2005/07/06 (Wed) 11:06:21 N.Kojima     OnErr処理、SetFocus処理追加
    '　　　：2006/04/24 (Mon) 13:23:50 N.Kojima     使用部材判定処理追加。(ﾕｰｻﾞｰ要望№0164)
    '　　　：2006/07/04 (Tue) 13:53:49 N.Kojima     部材使用判定の修正とﾒｯｾｰｼﾞ表示処理を追加。(ﾕｰｻﾞｰ要望№0189)
    '　　　：2006/07/06 (Thu) 14:45:08 T.Kitagawa   部材使用判定ﾁｪｯｸﾊﾞｸﾞ対応(ﾕｰｻﾞｰ要望№0189)
    '　　　：2006/10/04 (Wed) 16:50:47 N.Kojima     部材の機種限定機能追加に伴い、処理修正。(案件№01472)
    '　　　：2006/10/20 (Fri) 17:39:21 N.Kojima     ﾚｽﾎﾟﾝｽ処理を追加。(案件№01605)
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/16 (Thu) 12:00:54 N.Kojima     無機対応 Phase2。(案件№03661)
    '　　　：2013/12/20 (Fri) 18:04:14 T.Oide       無機ODF対応(REQ-1440)
    '　　　：2014/12/02 (Tue) 13:31:10 H.Hayashi    組立無機ODF環境のｼｽﾃﾑ環境整備
    '      ：2015/11/20 (Fri) 16:29:27 H.Hayashi    千歳Spirytus_Prism処理チャンバー選択機能(H31096937)
    Private Sub cmdLotStart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotStart.Click
        
        Dim lblnInputCheck          As Boolean              '画面入力ﾁｪｯｸ(True:正常,False:異常)
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypLotwrkstart         As Lotwrkstart          'ﾛｯﾄ作業開始構造体
        Dim lstrActionFlag          As String               'ｱｸｼｮﾝ予約実行ﾌﾗｸﾞ(0:実行なし、1:停止、２:保留)
        Dim lstrToOpID              As String               '制限時間先大工程
        Dim lstrToStepID            As String               '制限時間先小工程
        Dim lstrLimitTime           As String               '制限時間
        Dim lstrWarnTime            As String               '警告時間
        
        Dim llngAns                 As String               '警告時間ﾁｪｯｸ結果
        Dim ltypMaterialList        As MaterialWPList       '部材ﾘｽﾄ(装置IDｷｰ)
        Dim lstrWpId                As String               'WPID
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ1
        Dim llngCnt2                As Integer              '汎用ｶｳﾝﾀ2
        Dim lblnChkFlag             As Boolean              'ﾁｪｯｸﾌﾗｸﾞ
        Dim lstrOvertakeLotId       As String               '追越制限違反ﾛｯﾄ
        Dim lstrFrWpId              As String               '装置ID
        Dim lstrFrRecipeStatus      As String               'FR処理可能ﾚｼﾋﾟ有無状態
                                                            '(0:表示不要/1:正常表示/2:異常表示)
        Dim lstrNgChamberId         As String               'FrNG結果の処理部
        Dim lstrNgProcessTime       As String               'FrNG結果のFR累積時間
        Dim lstrNgRecipeId          As String               'FrNG結果のﾚｼﾋﾟ
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim llngFrAns               As Integer              'FR処理可能ﾚｼﾋﾟ有無状態確認MsgBox戻り値
		Dim lstrResult				As String

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
            
            If txtCFCarrier.Text <> vbNullString Then
                '@CFキャリアチェック
                lblnAns = prvCfCarrier_Chk
                
                '@結果確認
                If lblnAns = False Then
                    '@CFキャリアを空にする
                    txtCFCarrier.Text = vbNullString
                    Exit Sub
                End If
            End If
            
            '@=======================
            '@ 画面入力ﾁｪｯｸ処理(True:L/N装置ﾁｪｯｸ含む)
            '@=======================
            lblnInputCheck = prvblnLotStartInput_Check(True)
            
            '@画面入力ﾁｪｯｸ処理結果が"False：ﾁｪｯｸNG"か
            If lblnInputCheck = False Then
                Exit Sub
            End If
            
            '@-----------------------
            '@ ﾚｼﾋﾟﾎﾞﾃﾞｨ(RECIPE_VALUE)の有無判定
            '@-----------------------
            '@ﾃﾞｰﾀなしの場合
            If mstrVariableResult = CMVariableResultNG Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM4CI>$$レシピパラメータ値が未設定です。処理を継続しますか？"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004C)
                llngAns = publngMsgBox(pstrDMsg & vbCrLf, vbNo, Me.Text, True, 16, False)
                
                '@★ ﾒｯｾｰｼﾞBOXの押下ﾎﾞﾀﾝにより処理分岐 ★
                Select Case llngAns
                
                    '@〓 vbNo：「いいえ」 〓
                    Case vbNo

                        '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                        Call prvSetFocus(txtCarrier, cmdLotStart)
                        Exit Sub

                End Select
            End If
                        
            '@起動SBが2A0=組立の場合
            If pstrSBID = CPstrSBID2A0 Then

				'@装置ID格納
                lstrWpId = vsfWp.GetData(vsfWp.Row, CMvsfWPColWpID)

                '-----------------------
                '無機マスクセット装置
                '-----------------------
                'EQ_TYPE判定ができないのでWPIDで判定
                Dim lintTargetIndex As Integer = lstrWpId.IndexOf("2MUMASKSET")
                '検索結果あり(なしの場合は-1)
                'ロットIDあり
                If lintTargetIndex = 0 And lblLotID.Text <> vbNullString Then
                    'ODF予約しているかチェック
                    If prvblnMukiMask_Chk = False Then
                        Exit Sub
                    End If
                End If

                '-----------------------
                'ODF貼り合せ装置
                '-----------------------
                'TFT/CFキャリアが選択済み
                If vsfWp.GetData(vsfWp.Row, CMvsfWPColEqType) = CPstrEqTypeODF And _
                    txtCarrier.Text <> vbNullString And txtCFCarrier.Text <> vbNullString Then
                    'ODF予約情報との比較
                    If prvblnEqTypeODF_Chk = False Then
                        Exit Sub
                    End If
                End If
                        
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrCmdLotStartClick)
                
				'kkw ｱﾝﾛｰﾀﾞｰｷｬﾘｱの抜け道つぶし
				'アンローダーキャリアが基板FOUPの場合
				If txtLoaderCarrier.Text <> vbNullString Then
					If txtLoaderCarrier.Text.Substring(0,1) = "A" Then
						If vsfWp.GetData(vsfWp.Row, CMvsfWPColEqType) <> CPstrEqTypeVFI  Then
							'無機異物検査装置以外は処理をキャンセルする
							Exit Sub
						End If

						'蒸着2回対象機種かつ基板特殊ルートが設定された工程か確認する
						lblnAns = pubblnDoubleJPd_Chk(CMstrlot_chkdoublejpdVer, _
															lblLotID.Text, _
															lblPdID.Text, _
															lstrResult, _
															CPstrCD10)

						If lstrResult = CPstrFlagOff Then
							'上記に当てはまらない場合はメッセージを表示して処理をキャンセルする
							pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0190)
							Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
							'@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
							Call pubResponseCancel(CMstrFormName, CMstrCmdLotStartClick)
                            '@ｱﾝﾛｰﾀﾞｰｷｬﾘｱﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call prvSetFocus(txtLoaderCarrier)
                            Exit Sub
						End If


					ElseIf txtLoaderCarrier.Text.Substring(0,1) = "B" Then
						'選択したｱﾝﾛｰﾀﾞｰｷｬﾘｱがBFOUPの場合
						If vsfWp.GetData(vsfWp.Row, CMvsfWPColEqType) = CPstrEqTypeVFI  Then
							'かつ無機異物検査装置の場合
							lblnAns = pubblnDoubleJPd_Chk(CMstrlot_chkdoublejpdVer, _
															lblLotID.Text, _
															lblPdID.Text, _
															lstrResult, _
															CPstrCD10)

							'蒸着2回対応機種 かつ 無機異物検査装置 かつ 特殊ルートが設定されている かつ 組立ｷｬﾘｱが選択されていれば警告を表示
							If lstrResult = CPstrFlagOn Then
							      '@"<TRM189W>$$蒸着2回用基板特殊ルートが設定されている工程です。$ｱﾝﾛｰﾀﾞｰｷｬﾘｱがAFOUPではありません$処理をキャンセルしますか？"
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0189)
                                llngFrAns = publngMsgBoxInfo(pstrDMsg, vbQuestion, Me.Text, True, 16)
                                
                                '@返答判定
                                If llngFrAns = vbYes Then
                                '@「はい」の場合
									'@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
									Call pubResponseCancel(CMstrFormName, CMstrCmdLotStartClick)
                                    Exit Sub
                                Else
                                '@「いいえ」の場合：処理続行

                                End If
							Else
								'処理続行
							End If
						End If
					End If
				End If

                '@=======================
                '@ 装置使用部材情報取得
                '@=======================
                lblnAns = pubblnMatMaterialList_Sel(CMstrmat_materiallistVer, _
                                                    lstrWpId, _
                                                    ltypMaterialList)
                
                '@結果判定
                If lblnAns = False Then
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdLotStartClick)
                    Exit Sub
                Else
                    '@部材種別に対して1部材が最低選択されているかのﾁｪｯｸ
                    
                    '@ﾁｪｯｸﾌﾗｸﾞ,汎用ｶｳﾝﾀの初期化
                    lblnChkFlag = False
                    
                    With ltypMaterialList
                        
                        For llngCnt = 0 To .lngMaterialTypeCnt - 1
                            
                            With .typMaterialTypeList(llngCnt)
                                
                                For llngCnt2 = 0 To ptypChkMaterial.lngMaterialTypeCnt - 1
                                    
                                    '@構造体の部材種別とｸﾞﾘｯﾄﾞに表示されている部材種別が同じ場合
                                    If .strMaterialTypeID = ptypChkMaterial.typMaterialTypeList(llngCnt2).strMaterialTypeID Then
                                        
                                        lblnChkFlag = True
                                        Exit For
                                    Else
                                        lblnChkFlag = False
                                    End If
                                Next llngCnt2
                                
                                '@ﾁｪｯｸﾌﾗｸﾞをFalse(=未選択)
                                If lblnChkFlag = False Then
                            
                                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                    Call pubResponseCancel(CMstrFormName, CMstrCmdLotStartClick)
                            
                                    '@表示ﾒｯｾｰｼﾞ変換
                                    '@「"<TRM8DW>$$選択されていない部材が存在します。$1つの部材種別に対し、最低1つ部材を選択してください。"」のﾒｯｾｰｼﾞ表示
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008D)
                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                    
                                    '@使用部材選択ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                                    Call prvSetFocus(cmdSelectMaterial, cmdLotStart)
                                    Exit Sub
                                End If
                            End With
                        Next
                    End With
            
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrCmdLotStartClick)
                End If
                
                '@=======================
                '@ 装置使用部材判定＆権限ﾁｪｯｸ処理
                '@=======================
                lblnAns = prvblnChgMaterial_Chk
                
                '@使用部材判定＆権限ﾁｪｯｸ処理の戻り値を判定
                If lblnAns = False Then
                    '@処理中断 or 権限なしの場合
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdLotStartClick)
                    Exit Sub
                Else
                    '@通常実行 or 権限ありの場合は処理続行
                End If
                   
                '@=======================
                '@ 無機ODF追越制限違反判定＆権限ﾁｪｯｸ処理
                '@=======================
                lblnAns = prvblnOvertakeAuthority_Chk(lstrWpId, _
                                                      lstrOvertakeLotId)
                
                '@無機ODF追越制限違反判定＆権限ﾁｪｯｸ処理の戻り値を判定
                If lblnAns = False Then
                    '@処理中断 or 権限なしの場合
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdLotStartClick)
                    Exit Sub
                Else
                    '@通常実行 or 権限ありの場合は処理続行
                End If

            Else
                '@基板での起動
                
        '@↓2015/11/13 (Fri) 09:22:13 H.Hayashi **************************************************
                
                '@CONTｴｯﾁｬｰの場合はFR処理可能範囲のﾚｼﾋﾟが存在するか確認する(※作業開始はS1の場合のみ実施)
                If vsfWp.GetData(vsfWp.Row, CMvsfWPColEqType) = CPstrEqTypeContEt Then

                    '@装置ID格納
                    lstrFrWpId = vsfWp.GetData(vsfWp.Row, CMvsfWPColWpID)
                
                    '@CONTｴｯﾁｬｰの場合はFR処理可能範囲のﾚｼﾋﾟが存在するか確認
                    lblnAns = pubblnLotChkFrTimeRecipe_Chk(CMstrlot_chkfrtimerecipeVer, _
                                                pstrSBID, _
                                                lblLotID.Text, _
                                                lblOpID.Text, _
                                                lblStepID.Text, _
                                                lstrFrWpId, _
                                                lblRecp.Text, _
                                                CPstrlot_wrkstart, _
                                                lstrFrRecipeStatus, _
                                                lstrNgChamberId, _
                                                lstrNgProcessTime, _
                                                lstrNgRecipeId, _
                                                lstrGuidMsg, _
                                                lstrGuidMsgCode)
                    '@結果判定
                    If lblnAns = False Then
                    
                        Exit Sub
                    End If
                
                    '@CONTｴｯﾁｬｰの判定(表示対象外以外の場合,ﾚｽﾎﾟﾝｽをｷｬﾝｾﾙする)
                    If lstrFrRecipeStatus <> vbNullString And lstrFrRecipeStatus <> CMstrFrRecipeStatus0 Then
                    
                        Select Case lstrFrRecipeStatus
                            '@S1の場合、ｵﾝﾗｲﾝなので表示する意味がないため削除(折角作成したのでｺﾒﾝﾄｱｳﾄして残す)
        '@                  '@正常表示
        '@                  Case CMstrFrRecipeStatus1
        '@
        '@                        '@"<TRM135W>$$レシピ[%1]が選択されました。$装置パネルにて､本レシピを指定して下さい｡"
        '@                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0135, Replace(lblRecp.Caption, vbCrLf, vbNullString))
        '@                        Call publngMsgBoxInfo(pstrDMsg, vbInformation, frmxxEN0030.Caption, True, 16)
        '@
        '@                  '@異常表示(FR累積範囲以外)
                            Case CMstrFrRecipeStatus2
                            
                                '@"<TRM136W>$$処理部[%1]のFR累積時間は[%2]です。範囲以外のレシピ[%3]が$選択されていますが[%4]を実施いたしますか｡"
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0136, lstrNgChamberId, lstrNgProcessTime, lstrNgRecipeId, CMstrEN0030Title)
                                llngFrAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                                
                                '@返答判定
                                If llngFrAns = vbYes Then
                                '@「はい」の場合：処理続行
        '@↓2015/12/01 (Tue) 13:41:26 H.Hayashi **************************************************
                                    '@ﾌｫｰﾑﾛｯｸ
        '@                            frmxxEN0030.Enabled = False
                                    '@処理を継続する
        '@↑2015/12/01 (Tue) 13:41:26 H.Hayashi **************************************************
                                Else
                                '@「いいえ」の場合
                                    Exit Sub
                                End If
                                
                            '@異常表示(処理部状態に一致しないﾚｼﾋﾟ)
                            Case CMstrFrRecipeStatus3
                            
                                '@"<TRM137W>$$処理部[%1]の状態に一致しないレシピ$[%2]が選択されていますが$[%3]を実施いたしますか。"
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0137, lstrNgChamberId, lstrNgRecipeId, CMstrEN0030Title)
                                llngFrAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                                
                                '@返答判定
                                If llngFrAns = vbYes Then
                                '@「はい」の場合：処理続行
        '@↓2015/12/01 (Tue) 13:41:52 H.Hayashi **************************************************
                                    '@ﾌｫｰﾑﾛｯｸ
        '@                            frmxxEN0030.Enabled = False
                                    '@処理を継続する
        '@↑2015/12/01 (Tue) 13:41:52 H.Hayashi **************************************************
                                Else
                                '@「いいえ」の場合
                                    Exit Sub
                                End If
                                
                                
                                        
                        End Select
                    
                    End If

                End If
        '@↑2015/11/13 (Fri) 09:22:13 H.Hayashi **************************************************
                
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@ 作業者ｺｰﾄﾞ入力画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM0010.Instance.ShowDialog(Me)
                frmxxCM0010.Instance = Nothing
                
                '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
                If pblnCancel = True Then
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdLotStartClick)
                    Exit Sub
                End If
            End If
            
            
        '@↓2009/07/16 (Thu) 11:56:27 N.Kojima **************************************************
        '@現状の装置仕様だと、単発ﾛｯﾄで報告されるとﾀﾞﾒらしい…。一旦ｺﾒﾝﾄｱｳﾄ。

        '    '@以下の条件を満たす場合、装置にﾊﾞｯﾁ投入順を報告する
        '    '@ ①選択装置がﾊﾞｯﾁ処理対象装置
        '    '@ ②装置ﾀｲﾌﾟが"20：表面処理装置"
        '    '@ ③装置がｵﾝﾗｲﾝ(S1 or S2(M1以外))
        '    If vsfWP.Cell(flexcpText, vsfWP.Row, CMvsfWPColWpID) = mtypLotCurState.strWpID And _
        '        mtypLotCurState.strEqType = CPstrEqTypeHyoumenSyori And _
        '        mtypLotCurState.strMesModeID <> CPstrM1 Then
        '
        '        '@=======================
        '        '@ ﾊﾞｯﾁ投入順通知処理(呼び先で表面処理のみで処理するようになっています)
        '        '@=======================
        '        lblnAns = prvblnWpIdBatchMoveIn_Proc
        '
        '        '@ﾊﾞｯﾁ投入順通知結果が"False：通知失敗"か
        '        If lblnAns = False Then
        '            Exit Sub
        '        End If
        '    End If

        '@↑2009/07/16 (Thu) 11:56:27 N.Kojima **************************************************
            
            
            '@***********************
            '@ 作業開始ﾃﾞｰﾀ格納
            '@***********************
            With ltypLotwrkstart
                
                .strLotID = lblLotID.Text                                      'ﾛｯﾄID
                .strOpID = vsfWp.GetData(vsfWp.Row, CMvsfWPColOpID)            '大工程ID
                .strStepID = vsfWp.GetData(vsfWp.Row, CMvsfWPColStepID)        '小工程ID
                .strWpID = vsfWp.GetData(vsfWp.Row, CMvsfWPColWpID)            'WPID
                .strEngEmpId = pstrUserID                                      '作業者ID
                .strLotLastUpdate = mstrLotLastUpdate                          'LOT最終更新日時
                .strComments = txtWorkMemo.Text                                '作業ﾒﾓ
                .strAltNumber = vsfWp.GetData(vsfWp.Row, CMvsfWPColAltNumber)  '代替番号
                .strToCarriaID = txtLoaderCarrier.Text                         'ｱﾝﾛｰﾀﾞｰｷｬﾘｱID
                .strLoaderUnloaderFlag = vsfWp.GetData(vsfWp.Row, CMvsfWPColLoaderFlg)     'ﾛｰﾀﾞ/ｱﾝﾛｰﾀﾞﾌﾗｸﾞ
                .strCFCarrierID = txtCFCarrier.Text                            'CFｷｬﾘｱID
            End With
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdLotStartClick)


            '@=======================
            '@ ﾛｯﾄ作業開始登録(処理区分：3B)
            '@=======================
            lblnAns = pubblnLotStart_Ins(CMstrlot_wrkstartVer, _
                                         ltypLotwrkstart, _
                                         lstrActionFlag, _
                                         lstrToOpID, _
                                         lstrToStepID, _
                                         lstrLimitTime, _
                                         lstrWarnTime, _
                                         mstrLotLastUpdate, _
                                         CPstrCD3B)
            
            '@結果判定
            If lblnAns = True Then
                '@引継ぎ構造体の代替番号が空白以外の場合
                
                If ptypCommonInfo.strAltPointer <> vbNullString Then
                    '@装置別ﾛｯﾄ一覧で、「作業待ち」以外のﾛｯﾄは代替番号が空白で返ってくる為、引継ぎ構造体の代替番号もｸﾘｱする
                    ptypCommonInfo.strAltPointer = vbNullString
                End If
                
                '@=======================
                '@ 引継構造体のｷｬﾘｱIDとｱﾝﾛｰﾀﾞｰ側ｷｬﾘｱIDの入れ替えを行う
                '@=======================
                Call prvHandWork_Set()
                
                '@制限時間超過の警告が発生している場合
                If lstrToOpID <> vbNullString Or lstrToStepID <> vbNullString Or lstrLimitTime <> vbNullString Then
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrCmdLotStartClick)
                                 
                    '@制限時間以下の場合
                    If mtypLotCurState.strRestrictTypeID = CMstrRestrictTypeID1 Then
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM3BW>$$ロット[xxx]は[xxx xxx]までの工程において制限時間を経過しています。処理を継続しますか？"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003F, lblLotID.Text, lstrToOpID, lstrToStepID)
                        llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                         
                        '@ﾒｯｾｰｼﾞBOXにて「いいえ」が選択されたか
                        If llngAns = vbNo Then
                            
                            '@処理をｷｬﾝｾﾙする
                        
                        Else
                            '@「はい」が選択された場合
                            
                            '@ﾚｽﾎﾟﾝｽ取得開始
                            Call pubResponseStart(CMstrFormName, CMstrCmdLotStartClick)
                            
                            '@=======================
                            '@ ﾛｯﾄ作業開始登録(処理区分：02)
                            '@=======================
                            lblnAns = pubblnLotStart_Ins(CMstrlot_wrkstartVer, _
                                                         ltypLotwrkstart, _
                                                         lstrActionFlag, _
                                                         lstrToOpID, _
                                                         lstrToStepID, _
                                                         lstrLimitTime, _
                                                         lstrWarnTime, _
                                                         mstrLotLastUpdate, _
                                                         CPstrCD02)

                            '@結果判定
                            If lblnAns = True Then
                                
                                '@使用部材が存在する場合
                                If ptypChkMaterial.lngMaterialTypeCnt > 0 Then
                                    
                                    '@=======================
                                    '@ 使用部材を作業記録へ反映
                                    '@=======================
                                    lblnAns = prvblnSpcRegcollect_Set(mstrLotLastUpdate)
                                    
                                    '@登録ｴﾗｰの場合
                                    If lblnAns = False Then
                                        
                                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                        Call pubResponseCancel(CMstrFormName, CMstrCmdLotStartClick)
                                        
                                        '@表示ﾒｯｾｰｼﾞ変換
                                        '@"<TRM97W>$$使用部材を作業記録へ登録に失敗しました。"
                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0097)
                                        
                                        '@ﾒｯｾｰｼﾞ表示
                                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                    Else
                                        '@ﾚｽﾎﾟﾝｽ取得終了
                                        Call publngResponseEnd(CMstrFormName, CMstrCmdLotStartClick)
                                    End If
                                Else
                                    '@ﾚｽﾎﾟﾝｽ取得終了
                                    Call publngResponseEnd(CMstrFormName, CMstrCmdLotStartClick)
                                End If
                                
                                '@Unloaderｷｬﾘｱの入力判定(Unloaderｷｬﾘｱの入力可否にて表示ﾒｯｾｰｼﾞを切替)
                                If txtLoaderCarrier.Text = vbNullString Then
                                    '@表示ﾒｯｾｰｼﾞ変換(UNI装置用)
                                    
                                    '@"<TRM05I>$$作業を開始しました。キャリア[ %1 ] ロット[ %2 ]"
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0005, txtCarrier.Text, lblLotID.Text)
                                Else
                                    '@CFｷｬﾘｱの入力判定(CFｷｬﾘｱの入力可否にて表示ﾒｯｾｰｼﾞを切替)
                                    If txtCFCarrier.Text = vbNullString Then
                                        '@表示ﾒｯｾｰｼﾞ変換(L/N装置用)
                                        
                                        '@"<TRM0TI>$$作業を開始しました。キャリア[ %1 ] ロット[ %2 ] Unloaderキャリア[ %3 ]"
                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000T, txtCarrier.Text, lblLotID.Text, txtLoaderCarrier.Text)
                                    Else
                                        '@表示ﾒｯｾｰｼﾞ変換(ODF用)
                                        
                                        '@"<TRM4VI>$$作業を開始しました。TFTキャリア[%1] ロット[%2] Unloaderキャリア[%3] CFキャリア[%3] "
                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004V, txtCarrier.Text, lblLotID.Text, txtLoaderCarrier.Text, txtCFCarrier.Text)
                                    End If
                                End If
                                
                                '@成功ﾒｯｾｰｼﾞ表示
                                Call pubVsfInfo_Disp(pstrDMsg)
                                
                                
                                '@ｷｬﾘｱIDのｸﾘｱ
                                txtCarrier.Text = vbNullString
                                
                                '@=======================
                                '@ 各種初期化処理(画面内ｺﾝﾄﾛｰﾙ、変数等)
                                '@=======================
                                Call prvFrmxxEN0030_Init()
                                
                                '@=======================
                                '@ 各ﾎﾞﾀﾝ/ﾃｷｽﾄの制御処理(False：使用不可)
                                '@=======================
                                Call prvFrmxxEN0030_CmbInit(False)
                            
                            Else
                                 
                                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                Call pubResponseCancel(CMstrFormName, CMstrCmdLotStartClick)
                            End If
                        End If
                    End If
                    
                    '@制限時間以下の場合
                    If mtypLotCurState.strRestrictTypeID = CMstrRestrictTypeID2 Then
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM3IW>$$ロット[xxx]は[xxx xxx]までの工程において制限時間を経過していません。処理を継続しますか？"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003I, lblLotID.Text, lstrToOpID, lstrToStepID)
                        llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                         
                        '@要求確認
                        If llngAns = vbNo Then
                            '@ｷｬﾝｾﾙする
                        Else
                            '@「はい」が選択された場合
                            
                            '@ﾚｽﾎﾟﾝｽ取得開始
                            Call pubResponseStart(CMstrFormName, CMstrCmdLotStartClick)
                            
                            '@=======================
                            '@ ﾛｯﾄ作業開始登録(処理区分：02)
                            '@=======================
                            lblnAns = pubblnLotStart_Ins(CMstrlot_wrkstartVer, _
                                                         ltypLotwrkstart, _
                                                         lstrActionFlag, _
                                                         lstrToOpID, _
                                                         lstrToStepID, _
                                                         lstrLimitTime, _
                                                         lstrWarnTime, _
                                                         mstrLotLastUpdate, _
                                                         CPstrCD02)

                            '@結果判定
                            If lblnAns = True Then
                            
                                '@使用部材が存在する場合
                                If ptypChkMaterial.lngMaterialTypeCnt > 0 Then
                                    
                                    '@=======================
                                    '@ 使用部材を作業記録へ反映
                                    '@=======================
                                    lblnAns = prvblnSpcRegcollect_Set(mstrLotLastUpdate)
                                    
                                    '@登録ｴﾗｰの場合
                                    If lblnAns = False Then
                                        
                                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                        Call pubResponseCancel(CMstrFormName, CMstrCmdLotStartClick)
                                        
                                        '@表示ﾒｯｾｰｼﾞ変換
                                        '@「"<TRM97W>$$使用部材を作業記録へ登録に失敗しました。"」のﾒｯｾｰｼﾞ表示
                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0097)
                                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                    Else
                                        '@ﾚｽﾎﾟﾝｽ取得終了
                                        Call publngResponseEnd(CMstrFormName, CMstrCmdLotStartClick)
                                    End If
                                Else
                                    '@ﾚｽﾎﾟﾝｽ取得終了
                                    Call publngResponseEnd(CMstrFormName, CMstrCmdLotStartClick)
                                End If
                            
                                '@Unloaderｷｬﾘｱの入力判定(Unloaderｷｬﾘｱの入力可否にて表示ﾒｯｾｰｼﾞを切替)
                                If txtLoaderCarrier.Text = vbNullString Then
                                    '@表示ﾒｯｾｰｼﾞ変換(UNI装置用)
                                    
                                    '@"<TRM05I>$$作業を開始しました。キャリア[ %1 ] ロット[ %2 ]"
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0005, txtCarrier.Text, lblLotID.Text)
                                Else
                                    '@CFｷｬﾘｱの入力判定(CFｷｬﾘｱの入力可否にて表示ﾒｯｾｰｼﾞを切替)
                                    If txtCFCarrier.Text = vbNullString Then
                                        '@表示ﾒｯｾｰｼﾞ変換(L/N装置用)
                                        
                                        '@"<TRM0TI>$$作業を開始しました。キャリア[ %1 ] ロット[ %2 ] Unloaderキャリア[ %3 ]"
                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000T, txtCarrier.Text, lblLotID.Text, txtLoaderCarrier.Text)
                                    Else
                                        '@表示ﾒｯｾｰｼﾞ変換(ODF用)
                                        
                                        '@"<TRM4VI>$$作業を開始しました。TFTキャリア[%1] ロット[%2] Unloaderキャリア[%3] CFキャリア[%3] "
                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004V, txtCarrier.Text, lblLotID.Text, txtLoaderCarrier.Text, txtCFCarrier.Text)
                                    End If
                                End If
                                
                                '@成功ﾒｯｾｰｼﾞ表示
                                Call pubVsfInfo_Disp(pstrDMsg)

                                
                                '@ｷｬﾘｱIDのｸﾘｱ
                                txtCarrier.Text = vbNullString
                                
                                '@=======================
                                '@ 各種初期化処理(画面内ｺﾝﾄﾛｰﾙ、変数等)
                                '@=======================
                                Call prvFrmxxEN0030_Init()
                                
                                '@=======================
                                '@ 各ﾎﾞﾀﾝ/ﾃｷｽﾄの制御処理(False：使用不可)
                                '@=======================
                                Call prvFrmxxEN0030_CmbInit(False)

                            Else
                                 
                                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                Call pubResponseCancel(CMstrFormName, CMstrCmdLotStartClick)
                            End If
                        End If
                    End If
                Else
                    '@制限時間が超過していない場合
                    
                    '@使用部材が存在する場合
                    If ptypChkMaterial.lngMaterialTypeCnt > 0 Then
                        
                        '@=======================
                        '@ 使用部材を作業記録へ反映
                        '@=======================
                        lblnAns = prvblnSpcRegcollect_Set(mstrLotLastUpdate)
                        
                        '@登録ｴﾗｰの場合
                        If lblnAns = False Then
                            
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(CMstrFormName, CMstrCmdLotStartClick)
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「"<TRM97W>$$使用部材を作業記録へ登録に失敗しました。"」のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0097)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        Else
                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(CMstrFormName, CMstrCmdLotStartClick)
                        End If
                    Else
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrCmdLotStartClick)
                    End If
                    
                    '@Unloaderｷｬﾘｱの入力判定(Unloaderｷｬﾘｱの入力可否にて表示ﾒｯｾｰｼﾞを切替)
                    If txtLoaderCarrier.Text = vbNullString Then
                        '@表示ﾒｯｾｰｼﾞ変換(UNI装置用)
                        
                        '@"<TRM05I>$$作業を開始しました。キャリア[ %1 ] ロット[ %2 ]"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0005, txtCarrier.Text, lblLotID.Text)
                    Else
                        '@CFｷｬﾘｱの入力判定(CFｷｬﾘｱの入力可否にて表示ﾒｯｾｰｼﾞを切替)
                        If txtCFCarrier.Text = vbNullString Then
                            '@表示ﾒｯｾｰｼﾞ変換(L/N装置用)
                           
                            '@"<TRM0TI>$$作業を開始しました。キャリア[ %1 ] ロット[ %2 ] Unloaderキャリア[ %3 ]"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000T, txtCarrier.Text, lblLotID.Text, txtLoaderCarrier.Text)
                        Else
                            '@表示ﾒｯｾｰｼﾞ変換(ODF用)
                            
                            '@"<TRM4VI>$$作業を開始しました。TFTキャリア[%1] ロット[%2] Unloaderキャリア[%3] CFキャリア[%3] "
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004V, txtCarrier.Text, lblLotID.Text, txtLoaderCarrier.Text, txtCFCarrier.Text)
                        End If
                    End If

                    '@成功ﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)
                    
                    
                    '@ｷｬﾘｱIDのｸﾘｱ
                    txtCarrier.Text = vbNullString
                    
                    '@=======================
                    '@ 各種初期化処理(画面内ｺﾝﾄﾛｰﾙ、変数等)
                    '@=======================
                    Call prvFrmxxEN0030_Init()
                    
                    '@=======================
                    '@ 各ﾎﾞﾀﾝ/ﾃｷｽﾄの制御処理(False：使用不可)
                    '@=======================
                    Call prvFrmxxEN0030_CmbInit(False)
                
                End If
            Else
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdLotStartClick)
            End If
                
            '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrier)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "cmdLotStart_Click"          'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
    '作成日：2004/02/27 (Fri) 16:43:51 T.Oide
    '更新日：2012/05/14 (Mon) 11:00:00 M.Sakka
    '備　考：
    '　　　：2005/03/07 (Mon) 11:02:03 N.Kojima     戻り先画面の判定を追加(改善№512)
    '　　　：2005/06/28 (Tue) 12:29:50 N.Kojima     ｺﾒﾝﾄ行の削除(引継ぎ元別終了処理部)
    '　　　：2005/07/06 (Wed) 11:02:33 N.Kojima     OnErr処理、SetFocus対応追加
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    '　　　：2012/04/13 (Fri) 11:37:28 Y.Yoneyama   装置別ﾛｯﾄ一覧のBCRｷｬﾘｱ照合対応
    '　　　：2012/05/14 (Mon) 11:00:00 M.Sakka      R9-02BR不具合対応
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        
        Dim ltypCommonInfo As CommonInfo

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@以下の条件の場合、ｷｰｺｰﾄﾞを無効にし処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If
            
            '@引継ぎ情報のｷｬﾘｱIDがNULL以外か
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@NULL以外の場合
                '治具Wafer紐付画面からの引継
                If pblnfrmxxEN02F0kbn = True Then                
                    Call pubMenuSelect_Proc(CPstrKeyEN02F0)
                    Exit Sub

                '@装置別ﾛｯﾄ一覧(BCRｷｬﾘｱ照合)から引き継いで起動されたか
                ElseIf pblnfrmxxEN0150BCR = True Then
                    
                    '@=======================
                    '@ 終了関数を実行する
                    '@=======================
                    '@親ﾌｫｰﾑから起動された場合
                    '@ｱﾝﾛｰﾄﾞ
                    'アンロード処理だけではなく、他の終了処理も行わせる
                    'publngEnd_Proc内部からアンロード処理は呼ばれる
                    'Call Unload(frmxxEN0030)
                    Call publngEnd_Proc(CPstrKeyEN0030, ltypCommonInfo)
                    Exit Sub
                
                '@装置別ﾛｯﾄ一覧から引き継いで起動されたか
                ElseIf pblnfrmxxEN0150Kbn = True Then
                    
                    '@=======================
                    '@ 装置別ﾛｯﾄ一覧を起動する
                    '@=======================
                    Call pubMenuSelect_Proc(CPstrKeyEN0150)
                    Exit Sub
                
                '@装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧から引き継いで起動されたか
                ElseIf pblnfrmxxEN00J0Kbn = True Then
                    
                    '@=======================
                    '@ 装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧を起動する
                    '@=======================
                    Call pubMenuSelect_Proc(CPstrKeyEN00J0)
                    Exit Sub
                    
                '@工程別ﾛｯﾄ一覧から引き継いで起動された場合
                ElseIf pblnfrmxxEN0200Kbn = True Then
                    
                    '@=======================
                    '@ 工程別ﾛｯﾄ一覧を起動する
                    '@=======================
                    Call pubMenuSelect_Proc(CPstrKeyEN0200)
                    Exit Sub
                    
                End If
            
            End If
            
            '@=======================
            '@ 終了関数を実行する
            '@=======================
            Call publngEnd_Proc(CPstrKeyEN0030, ltypCommonInfo)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030            '機能ID
                .strProcName = "cmdClose_Click"         'ﾌﾟﾛｼｰｼﾞｬ名
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
    '関数名：prvFrmxxEN0030_Init
    '機　能：各種初期化処理(画面内ｺﾝﾄﾛｰﾙ、変数等)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 16:35:41 T.Oide
    '更新日：2010/06/18 (Fri) 16:49:01 T.Oide
    '備　考：
    '　　　：2004/10/04 (Mon) 11:28:35 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2004/10/19 (Tue) 11:03:44 M.Miura　    CausesValidation設定を追加
    '　　　：2005/01/31 (Mon) 14:23:33 N.Kasai　    mstrVariableResult初期化追加
    '　　　：2005/05/17 (Tue) 09:31:58 N.Kasai      CFｷｬﾘｱ追加
    '　　　：2005/06/28 (Tue) 12:59:34 N.Kojima     ｺﾒﾝﾄ行削除(mstrVariableResult初期化追加)
    '　　　：2005/07/06 (Wed) 11:17:47 N.Kojima     OnErr処理追加
    '　　　：2006/06/28 (Wed) 16:40:19 N.Kojima     使用部材選択ﾎﾞﾀﾝの制御を追加。(ﾕｰｻﾞｰ要望№0189)
    '　　　：2006/10/04 (Wed) 09:21:31 N.Kojima     部材の機種限定機能追加に伴い、処理追加。(案件№01472)
    '　　　：2008/06/04 (Wed) 10:28:34 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/16 (Thu) 15:06:53 N.Kojima     無機対応 Phase2。(案件№03661)
    '　　　：2010/06/16 (Wed) 17:03:09 T.Oide       №04097 使用部材ﾎﾞﾀﾝ追加対応
    Private Sub prvFrmxxEN0030_Init()
        
        Dim lstrFormTitle       As String               'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        Dim ltypLotprestate     As Lotprestate          '引継ぎ構造体ｸﾘｱ用

        Try

            '@各種Public変数の初期化
            ptypLotprestate = ltypLotprestate           '引継ぎ構造体
            pblnWpIDNullFlag = False                    '引継ぎﾌﾗｸﾞ初期化作業開始→ﾚｼﾋﾟ変更画面で使用(True:WP_ID=NULL)
            pblnMkEasyDivFlag = False                   '無機専用の簡易分割ﾌﾗｸﾞ
            pblnfrmxxEN0030Kbn = False                  '作業開始ﾌﾗｸﾞ
            
            '@=======================
            '@ 機能関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0030, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@各ｺﾝﾄﾛｰﾙの初期化
            lblLotID.Text = vbNullString                'ﾛｯﾄID
            lblFlowClass.Text = vbNullString            '流動区分
            lblWFNo.Text = vbNullString                 'FW枚数
            lblOpID.Text = vbNullString                 '大工程ID
            lblStartDayTime.Text = vbNullString         '開始日時
            lblPdID.Text = vbNullString                 '機種名
            lblS.Text = vbNullString                    '特殊特性
            lblStatus.Text = vbNullString               '状態
            lblStepID.Text = vbNullString               '小工程ID
            lblLotManager.Text = vbNullString           'ﾛｯﾄ担当者
            lblTimeLimit.Text = vbNullString            '時間制約
            lblRecp.Text = vbNullString                 'ﾚｼﾋﾟID
            '@↓2020/01/15 (Wed) 16:53:46 Y.Yoneyama 「.Netへ反映未」 **************************************************
            lblGRB.Text = vbNullString                  'GRB
            '@GRB背景色
            lblGRB.BackColor = lblLotManager.BackColor
            '@↑2020/01/15 (Wed) 16:53:46 Y.Yoneyama 「.Netへ反映未」 **************************************************
            txtOpeCond.Text = vbNullString              '作業条件
            
            mstrLotLastUpdate = vbNullString            'ﾛｯﾄ最終更新日時
            mstrCarrier = vbNullString                  'ｷｬﾘｱID(ﾒｯｾｰｼﾞ成功時のｷｬﾘｱID)
            mblnBacthFlg = False                        'ﾊﾞｯﾁ編成ﾌﾗｸﾞ(通常)
            mstrVariableResult = vbNullString           'CMP研磨対応(ﾚｼﾋﾟﾊﾟﾗﾒｰﾀ入力有無)

            mstrPdErrMsg = vbNullString                 '機種限定ｴﾗｰMsg格納用
            mstrLimitErrMsg = vbNullString              '部材期限ｴﾗｰMsg格納用
            mstrPdForcedAction = CPstrZero              '機種限定強制実行判定用
            mstrLimitForcedAction = CPstrZero           '部材期限強制実行判定用
            
        '@↓2010/06/18 (Fri) 16:48:50 T.Oide **************************************************
            pstrPDIDAry = Nothing                       '機種ﾘｽﾄ初期化
        '@↑2010/06/18 (Fri) 16:48:50 T.Oide **************************************************

            '@作業ﾒﾓ初期化
            With txtWorkMemo
                
                '@入力Max数設定
                .ChrMaxByte = CPlngLotCommentsMaxByte
                
                '@ﾃｷｽﾄ部分初期化
                .Text = vbNullString
                
                '@=======================
                '@ 作業ﾒﾓﾊﾞｲﾄ数初期化
                '@=======================
                Call txtWorkMemo_Change(txtWorkMemo, EventArgs.Empty)
            End With
            
            '@作業条件設定
            With txtOpeCond
                
                '@背景色(ｸﾞﾚｰ)
                .BackColor = SystemColors.ControlLight
                .GotBackColor = SystemColors.ControlLight
                
                '@ﾛｯｸ
                .Locked = True
            End With
                
            '@ﾛｯﾄｺﾒﾝﾄ設定
            With txtLotCommnt
                
                '@入力Max数設定
                .ChrMaxByte = CPlngLotCommentsMaxByte
                
                '@ﾃｷｽﾄ部分初期化
                .Text = vbNullString
                
                '@背景色(ｸﾞﾚｰ)
                .BackColor = SystemColors.ControlLight
                .GotBackColor = SystemColors.ControlLight
                
                '@ﾛｯｸ
                .Locked = True
            End With
            
            '@Uniﾎﾟｰﾄ装置(使用不可)
            With txtLoaderCarrier
                
                '@ﾃｷｽﾄ部分初期化
                .Text = vbNullString
                
                '@非活性
                .Enabled = False
                
                '@背景色(ｸﾞﾚｰ)
                .BackColor = SystemColors.ControlLight
            End With

            '@★ 起動ｼｽﾃﾑﾌﾞﾛｯｸにより処理分岐 ★
            Select Case pstrSBID
                
                '@〓 2A0：組立 〓
                Case CPstrSBID2A0
                
                    '@各種CF関連ｺﾝﾄﾛｰﾙを有効にする
                    lblCFTtl.Visible = True                 'CFｷｬﾘｱﾀｲﾄﾙﾗﾍﾞﾙ
                    cmdCFCarrierSelect.Visible = True       'CFｷｬﾘｱ選択ﾎﾞﾀﾝ
                    txtCFCarrier.Visible = True             'CFｷｬﾘｱ入力ﾌｨｰﾙﾄﾞ
                    
                    '@「使用部材選択」ﾎﾞﾀﾝ表示
                    cmdSelectMaterial.Visible = True        '使用部材選択
                    cmdSelectMaterial.Enabled = False       'まだ使用不可
                    
                    '@CFｷｬﾘｱ(使用不可)
                    With txtCFCarrier
                        .Text = vbNullString
                        .Enabled = False
                        .BackColor = SystemColors.ControlLight
                    End With
                    cmdCFCarrierSelect.Enabled = False      'CFｷｬﾘｱ選択ﾎﾞﾀﾝ
                    
                    '@簡易分割ﾎﾞﾀﾝの制御
                    cmdEasyDivide.Enabled = False           '無効
                    cmdEasyDivide.Visible = True            '表示
                
                
                '@〓 その他(現在は1A0：基板のみ) 〓
                Case Else
                    
                    '@CFｷｬﾘｱ関連非表示
                    lblCFTtl.Visible = False                'CFｷｬﾘｱﾀｲﾄﾙﾗﾍﾞﾙ
                    cmdCFCarrierSelect.Visible = False      'CFｷｬﾘｱ選択ﾎﾞﾀﾝ
                    txtCFCarrier.Visible = False            'CFｷｬﾘｱ入力ﾌｨｰﾙﾄﾞ
                    
                    '@「使用部材選択」ﾎﾞﾀﾝ使用不可
                    cmdSelectMaterial.Enabled = False       '使用不可
                    cmdSelectMaterial.Visible = False       '使用部材選択
                    
                    '@簡易分割ﾎﾞﾀﾝの制御
                    cmdEasyDivide.Enabled = False           '無効
                    cmdEasyDivide.Visible = False           '非表示
            
            End Select
            
            '@Validateを実行しない
            cmdCarrierSelect.CausesValidation = False       '空きｷｬﾘｱ選択ﾎﾞﾀﾝ
            cmdClose.CausesValidation = False               '閉じるﾎﾞﾀﾝ
            cmdCFCarrierSelect.CausesValidation = False     'CFｷｬﾘｱﾎﾞﾀﾝ選択
            cmdCarrierSelect.Enabled = False                '空ｷｬﾘｱ選択
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "prvFrmxxEN0030_Init"        'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvFrmxxEN0030_CmbInit
    '機　能：各ﾎﾞﾀﾝ/ﾃｷｽﾄの制御処理
    '引　数：lblnEnable ：True:使用可能、False:使用不可
    '　　　：lblnMove   ：移載工程ﾌﾗｸﾞ/True:移載工程、False:移載工程以外
    '戻り値：なし
    '作成日：2004/03/08 (Mon) 16:15:05 T.Kitagawa
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2004/09/22 (Wed) 19:45:33 H.Wajima     流動ﾀｲﾌﾟ(移載工程)対応)(不具合改善№888)
    '　　　：2005/06/28 (Tue) 13:00:59 N.Kojima     ｺﾒﾝﾄ行の削除(流動ﾀｲﾌﾟ対応等)
    '　　　：2005/07/06 (Wed) 11:18:17 N.Kojima     OnErr処理追加
    '　　　：2005/11/29 (Tue) 15:52:37 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub prvFrmxxEN0030_CmbInit(Optional ByVal lblnEnable As Boolean = False, _
                                       Optional ByVal lblnMove As Boolean = False)

        Try
            
            '@流動区分の判定
            If lblnMove = False Then
                '@移載工程以外の場合
                
                '@各ｺﾏﾝﾄﾞﾎﾞﾀﾝのｺﾝﾄﾛｰﾙ
                cmdCommntInput.Enabled = lblnEnable         'ﾛｯﾄｺﾒﾝﾄ
                
                '@無効の場合
                If lblnEnable = True Then
                    
                    '@ﾊﾞｯﾁ編成されている場合
                    If mblnBacthFlg = True Then
                        
                        '@ﾚｼﾋﾟ設定変更ﾎﾞﾀﾝを無効
                        cmdWFRecp.Enabled = False
                    Else
                        '@ﾚｼﾋﾟ無しの場合
                        If lblRecp.Text = CMstrNoneRecipe Then
                            
                            '@ﾚｼﾋﾟ設定変更ﾎﾞﾀﾝを無効
                            cmdWFRecp.Enabled = False
                        Else
                            '@ﾚｼﾋﾟ設定変更ﾎﾞﾀﾝを有効
                            cmdWFRecp.Enabled = True
                        End If
                    End If
                Else
                    cmdWFRecp.Enabled = lblnEnable          'ﾚｼﾋﾟ詳細表示
                End If
                
                cmdActionDisp.Enabled = lblnEnable          'ｱｸｼｮﾝ予約確認
                
                '@ｺﾒﾝﾄ欄制御
                txtWorkMemo.Enabled = lblnEnable            '作業ﾒﾓ
            Else
                '@移載工程の場合
                
                '@空きｷｬﾘｱ選択、確定以外を無条件に使用不可にする
                cmdCommntInput.Enabled = False              'ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ
                cmdWFRecp.Enabled = False                   'ﾚｼﾋﾟ設定変更ﾎﾞﾀﾝ
                txtWorkMemo.Enabled = False                 '作業ﾒﾓﾃｷｽﾄﾎﾞｯｸｽ
                cmdMemoUp.Enabled = False                   '作業ﾒﾓ ▲ﾎﾞﾀﾝ
                cmdMemoDown.Enabled = False                 '作業ﾒﾓ ▼ﾎﾞﾀﾝ
                
                '@各ｺﾏﾝﾄﾞﾎﾞﾀﾝのｺﾝﾄﾛｰﾙ
                cmdActionDisp.Enabled = False               'ｱｸｼｮﾝ予約確認
            End If
            
            cmdLotStart.Enabled = lblnEnable            '確定
            
            '@ｺﾒﾝﾄ欄制御
            txtOpeCond.Enabled = lblnEnable             '作業条件
            txtLotCommnt.Enabled = lblnEnable           'ｺﾒﾝﾄ
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "prvFrmxxEN0030_CmbInit"     'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvFrmxxEN0030_Disp
    '機　能：画面の表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/03 (Wed) 18:22:50 T.Kitagawa
    '更新日：2010/06/18 (Fri) 16:47:16 T.Oide
    '備　考：
    '　　　：2004/08/25 (Wed) 11:32:06 N.Kasai      CFﾌﾗｸﾞ判定追加
    '　　　：2004/09/09 (Thu) 17:41:54 Y.Yamagishi　時間制限表示修正(不具合改善№693)
    '　　　：2004/09/14 (Tue) 10:28:44 N.Kojima　   数量表示(TPALﾛｯﾄ対応)修正(不具合改善№730)
    '　　　：2004/09/22 (Wed) 19:27:25 H.Wajima     流動ﾀｲﾌﾟ判定追加(不具合改善№888)
    '　　　：2004/09/24 (Fri) 10:28:25 Y.Yamagishi  制限時間以上の場合文字色を青に変更(不具合改善№825)
    '　　　：2005/05/26 (Thu) 14:04:26 N.Kasai      LP_FLAG判定追加
    '　　　：2005/07/06 (Wed) 11:18:55 N.Kojima     OnErr処理追加
    '　　　：2005/11/29 (Tue) 15:53:16 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2006/06/08 (Thu) 14:40:17 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2008/06/04 (Wed) 10:29:16 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    '　　　：2009/07/16 (Thu) 15:08:44 N.Kojima     無機対応 Phase2。(案件№03661)
    '　　　：2010/06/16 (Wed) 17:03:09 T.Oide       №04097 使用部材ﾎﾞﾀﾝ追加対応
    Private Sub prvFrmxxEN0030_Disp()

        Try

            '@ﾛｯﾄ情報の表示
            With mtypLotCurState
                
                lblLotID.Text = .strLotID                                                    'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass                                            '流動区分
                lblOpID.Text = .strOpID                                                      '大工程ID
                If IsDate(.strDispatchStartTime) Then                                        '処理開始予定"mm/dd hh:mm:ss"
                    lblStartDayTime.Text = Format$(CDate(.strDispatchStartTime), CPstrDateFormat)
                Else
                    lblStartDayTime.Text = .strDispatchStartTime
                End If
                lblPdID.Text = .strPdId                                                      '機種
                pstrPDIDAry = New List(Of String)
                pstrPDIDAry.Add(.strPdId)                                                    '機種を退避(使用部材選択画面で使用)
                lblS.Text = .strSpecialFlg                                                   '特殊特性
                lblStatus.Text = .strNowST                                                   '状態
                lblStepID.Text = .strStepID                                                  '小工程ID
                lblLotManager.Text = .strEngEmpName                                          'ﾛｯﾄ担当者
                '@↓2020/01/15 (Wed) 16:54:38 Y.Yoneyama 「.Netへ反映未」 **************************************************
                lblGRB.Text = .strGRBClass                                                   'GRB
                '@GRB背景色
                lblGRB.BackColor = pubGRBBackColor(.strGRBClass, lblLotManager.BackColor)
                '@↑2020/01/15 (Wed) 16:54:38 Y.Yoneyama 「.Netへ反映未」 **************************************************
                
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
                            lblTimeLimit.Text = Format$(CLng(.strLimitTime), CPstrDateFormatKanma) & CPstrh
                            '@右寄せ
                            lblTimeLimit.TextAlign = ContentAlignment.TopRight
                            
                            '@警告時間が設定されている場合
                            If .strWarnTime <> vbNullString Then
                                
                                '@時間制限が警告時間を過ぎている,且つ制限時間がｵｰﾊﾞｰしていない場合
                                If CLng(.strWarnTime) < 0 And CLng(.strLimitTime) >= 0 Then
                                    '@ﾌｫﾝﾄｶﾗｰを紫に変更
                                    lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple)    '紫色
                                Else
                                     '@ﾌｫﾝﾄｶﾗｰを黒に変更
                                    lblTimeLimit.ForeColor = Color.Black    '黒
                                End If
                            End If
                        End If
                    Else
                        '@制限時間がﾏｲﾅｽの場合
                        
                        '@制限時間先大工程+制限時間先小工程+制限時間
                        '@右寄せ
                        lblTimeLimit.TextAlign = ContentAlignment.TopRight
                        '@ForColorの変更
                        lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed)    '赤色
                        
                        '@制限時間以下or処理時間制限以下の場合
                        '@処理時間制限以下設定の場合、基本的に処理中で処理出来る機能しか関係ないが例外処理として挿入
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@ﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Format$(CLng(.strLimitTime), CPstrDateFormatKanma) & CPstrh
                        End If
                        
                        '@制限時間以上の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID2 Then
                            '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Replace(Format$(CLng(.strLimitTime), CPstrDateFormatKanma), CPstrReplaceMinus, vbNullString) & CPstrh
                        End If
                    End If
                End If
                        
                lblRecp.Text = vbNullString                 'ﾚｼﾋﾟID
                txtLotCommnt.Text = .strComments            'ﾛｯﾄｺﾒﾝﾄ
                mstrLotLastUpdate = .strLotLastUpdate       'ﾛｯﾄ最終更新日時
                mstrMasPDVersion = .strMasPdVersion         '機種ﾊﾞｰｼﾞｮﾝ
                
                '@枚数表示判定(CF_FLAGを判定し、WF枚数とﾁｯﾌﾟ枚数の表示を切替)
                Select Case .strCfFlag
                    
                    '@CFﾛｯﾄ
                    Case CPstrCF
                        
                        '@大判ﾌﾗｸﾞ判定(LP_FLAG)
                        If .strLpFlag = CPstrLP Then
                            '@大判の場合
                            lblWFNo.Text = .strWfNum                                            'WF枚数
                        Else
                            lblWFNo.Text = Format$(Val(.strChipQuantity), CPstrCFKnmaFormat)    'ﾁｯﾌﾟ枚数
                        End If
                    
                    '@CFﾛｯﾄ以外
                    Case Else
                        
                        '@TPALﾛｯﾄ
                        If Trim(Strings.Left(.strLotID, 2)) = CPstrTpalLot Then
                            lblWFNo.Text = Format$(Val(.strChipQuantity), CPstrCFKnmaFormat)    'ﾁｯﾌﾟ枚数
                        Else
                            '@CF,TPALﾛｯﾄ以外
                            lblWFNo.Text = .strWfNum                                            'WF枚数
                        End If
                End Select
                
                '@ﾊﾞｯﾁ編成されている場合
                If .strBatchId <> vbNullString Then
                    
                    '@ﾊﾞｯﾁ編成ﾌﾗｸﾞ設定(ﾊﾞｯﾁ編成)
                    mblnBacthFlg = True
                Else
                    '@ﾊﾞｯﾁ編成ﾌﾗｸﾞ設定(通常)
                    mblnBacthFlg = False
                End If
                
                '@統合の場合
                If .strCarrierId <> vbNullString And .strEqType = "5" Then
                    
                    '@統合先ｷｬﾘｱｾｯﾄ
                    txtLoaderCarrier.Text = .strCarrierId
                    '@無効
                    txtLoaderCarrier.Enabled = False
                End If
            End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "prvFrmxxEN0030_Disp"        'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfWP_init
    '機　能：装置一覧ｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/18 (Tue) 11:37:20 M.Miura
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2005/07/06 (Wed) 11:15:37 N.Kojima     OnErr処理追加
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub prvvsfWP_init()

        Try
            
            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfWp
                
                '@ｸﾘｱ
                .Clear
                
                '@ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '@ﾏｳｽでｾﾙ範囲選択不可
                .SelectionMode = SelectionModeEnum.Row

                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                
                '@列数設定
                .Cols.Count = CMvsfWPCols
                '@行数設定
                .Rows.Count = .Rows.Fixed

                .Row = -1
                
                '@ｶﾚﾝﾄｾﾙの周囲に描画するﾌｫｰｶｽ枠のｽﾀｲﾙを設定(なし)
                .FocusRect = FocusRectEnum.None
                
                '@一覧表の表題設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed

                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter      '中央表示
                lFixedStyle.ForeColor = Color.Yellow                    '文字色
                lFixedStyle.BackColor = Color.Navy                      '背景色
                With .Font                                              'ﾌｫﾝﾄｻｲｽﾞ
                    lFixedStyle.Font = New Font(.FontFamily, CMvsfWPTFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                lFixedStyle.Trimming = StringTrimming.None              'NSYS ﾍｯﾀﾞは省略表示なしに設定
                .Rows(CMvsfWPTitleRow).Height = CMvsfWPHHeight          '高さ
                        
                '@列幅、ﾀｲﾄﾙ設定
                .Cols(CMvsfWPColNo).Width = CMvsfWPColWNo
                .SetData(CMvsfWPTitleRow, CMvsfWPColNo, CMvsfWPColTNo)
                
                .Cols(CMvsfWPColOpID).Width = CMvsfWPColWOpID
                .SetData(CMvsfWPTitleRow, CMvsfWPColOpID, CMvsfWPColTOpID)
                
                .Cols(CMvsfWPColStepID).Width = CMvsfWPColWStepID
                .SetData(CMvsfWPTitleRow, CMvsfWPColStepID, CMvsfWPColTStepID)
                
                .Cols(CMvsfWPColDefault).Width = CMvsfWPColWDefault
                .SetData(CMvsfWPTitleRow, CMvsfWPColDefault, CMvsfWPColTDefault)
                
                .Cols(CMvsfWPColWpName).Width = CMvsfWPColWWpName
                .SetData(CMvsfWPTitleRow, CMvsfWPColWpName, CMvsfWPColTWpID)
                
                .Cols(CMvsfWPColWpID).Width = CMvsfWPColWWpID                                     '装置ID幅
                .Cols(CMvsfWPColAltNumber).Width = CMvsfWPColWAltNumber                           '代替番号幅
                .Cols(CMvsfWPColStepCnt).Width = CMvsfWPColWStepCnt                               '小工程番号幅
                .Cols(CMvsfWPColWpCnt).Width = CMvsfWPColWWpCnt                                   '装置番号幅
                .Cols(CMvsfWPColActionFlg).Width = CMvsfWPColWActionFlg                           'ｱｸｼｮﾝ予約表示幅
                .Cols(CMvsfWPColLoaderFlg).Width = CMvsfWPColWLoaderFlg                           'Loader/Unloaderﾌﾗｸﾞ表示の幅
                .Cols(CMvsfWPColCarrierType).Width = CMvsfWPColWCarrierType                       'ｷｬﾘｱﾀｲﾌﾟID表示の幅
                .Cols(CMvsfWPColCleanCondition).Width = CMvsfWPColWCleanCondition                 '洗浄条件表示の幅
                
                '@列位置の設定
                .Cols(CMvsfWPColNo).TextAlign = TextAlignEnum.RightCenter              '№
                .Cols(CMvsfWPColOpID).TextAlign = TextAlignEnum.LeftCenter             '大工程
                .Cols(CMvsfWPColStepID).TextAlign = TextAlignEnum.LeftCenter           '小工程
                .Cols(CMvsfWPColDefault).TextAlign = TextAlignEnum.LeftCenter          'ﾃﾞﾌｫﾙﾄ
                .Cols(CMvsfWPColWpName).TextAlign = TextAlignEnum.LeftCenter           '装置名
                
                '@非表示列設定
                .Cols(CMvsfWPColEqType).Visible = False                                'EQﾀｲﾌﾟ
                .Cols(CMvsfWPColLotRecipeFlag).Visible = False                         'ﾛｯﾄﾚｼﾋﾟﾌﾗｸﾞ
                        
                '@ﾛｯｸ
                .Enabled = False
                cmdUP.Enabled = False
                cmdDown.Enabled = False
                
                '@装置件数ｸﾘｱ
                lblWpCnt.Text = vbNullString

                'NSYS
                .Rows.DefaultSize = CMvsfWPHeight
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "prvVsfWP_init"              'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnVsfWP_Disp
    '機　能：装置(WPID)一覧の設定
    '引　数：ltypLotWpList：装置情報格納用構造体
    '戻り値：なし
    '作成日：2004/05/18 (Tue) 12:50:28 M.Miura
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：True：正常、False：異常
    '　　　：2004/09/03 (Fri) 19:10:18 M.Miura　    装置取得条件に代替番号追加
    '　　　：2004/09/17 (Fri) 16:40:49 N.Kasai　    装置取得条件にｷｬﾘｱﾀｲﾌﾟIDを追加
    '　　　：2004/10/22 (Fri) 17:04:04 Y.Yamagishi　装置取得条件に洗浄条件を追加
    '　　　：2004/11/30 (Tue) 11:05:09 S.Deguchi    装置の工程表示でﾃﾞﾌｫﾙﾄ⇒区分に変更し,表示文字も修正(№267)
    '　　　：2005/02/18 (Fri) 09:26:17 N.Kasai      引継ぎ構造体、引継ぎﾌﾗｸﾞを追加(№510)
    '　　　：2005/06/28 (Tue) 13:03:10 N.Kojima     ｺﾒﾝﾄ行の削除(ﾃﾞﾌｫﾙﾄ工程判定、構造体代入処理等)
    '　　　：2005/07/06 (Wed) 11:19:31 N.Kojima     OnErr処理追加
    '　　　：2006/07/04 (Tue) 09:54:44 N.Kojima     使用部材選択ﾎﾞﾀﾝの制御追加。(ﾕｰｻﾞｰ要望№0189)
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Function prvblnVsfWP_Disp(ByRef ltypLotprestate As Lotprestate) As Boolean
        
        Dim llngCnt             As Integer      'ｶｳﾝﾀ変数
        Dim llngWpCnt           As Integer      '装置ｶｳﾝﾄ
        Dim llngRowCnt          As Integer      'ｶｳﾝﾀ変数
        Dim lstrOpID            As String       '大工程ID
        Dim lstrStepID          As String       '小工程ID
        Dim lstrAltNumber       As String       '代替番号
        Dim lblnAns             As Boolean      '戻り値
        Dim ltypLotWpList       As LotWpList    '装置情報構造体

        Try
            
            '@初期化
            prvblnVsfWP_Disp = False
            
            '@装置一覧格納(ptypLotequipmntList)から装置ｸﾞﾘｯﾄﾞへｾｯﾄ
            With vsfWp
                
                '@ｶｳﾝﾀ初期化
                llngCnt = 1
                
                '@行設定
                llngRowCnt = .Rows.Fixed
                
                '@行数設定
                For llngCnt = 0 To ltypLotprestate.lngStepListCnt - 1
                    
                    '@大小工程ID、または、代替番号が変わったら装置取得
                    If lstrOpID <> ltypLotprestate.strSteplist(llngCnt).strOpID Or _
                       lstrStepID <> ltypLotprestate.strSteplist(llngCnt).strStepID Or _
                       lstrAltNumber <> ltypLotprestate.strSteplist(llngCnt).strAltNumber Then
                        
                        '@次回比較用大小工程、代替番号格納
                        lstrOpID = ltypLotprestate.strSteplist(llngCnt).strOpID
                        lstrStepID = ltypLotprestate.strSteplist(llngCnt).strStepID
                        lstrAltNumber = ltypLotprestate.strSteplist(llngCnt).strAltNumber
                        
                        '@=======================
                        '@ 装置情報取得
                        '@=======================
                        lblnAns = pubblnLotWplist_Sel(CPstrlot_wplist__Ver, _
                                                      CPstrCD10, _
                                                      lblLotID.Text, _
                                                      ltypLotprestate.strSteplist(llngCnt).strOpID, _
                                                      ltypLotprestate.strSteplist(llngCnt).strStepID, _
                                                      lstrAltNumber, _
                                                      ltypLotWpList)
                        '@結果判定
                        If lblnAns = False Then
                            
                            '@渡すﾃﾞｰﾀを格納
                            ptypLotprestate = ltypLotprestate
                            
                            '@作業開始→ﾚｼﾋﾟ変更画面で使用(True:WP_ID=NULL)
                            pblnWpIDNullFlag = True
                            
                            Exit Function
                        Else
                            '@作業開始→ﾚｼﾋﾟ変更画面で使用(True:WP_ID=NULL)
                            pblnWpIDNullFlag = False
                        End If

                        '@ﾛｯﾄ情報格納構造体のWP配列の初期化
                        Dim ltypStepListTmp As stepList
                        ltypStepListTmp = ltypLotprestate.strSteplist(llngCnt)

                        ltypStepListTmp.lngWpListCnt = 0
                        ltypStepListTmp.strWPList = New List(Of WP)

                        ltypLotprestate.strSteplist(llngCnt) = ltypStepListTmp
                        
                        '@装置ｸﾞﾘｯﾄ格納
                        For llngWpCnt = 0 To ltypLotWpList.lngWPCnt - 1
                            
                            .Rows.Count = .Rows.Count + 1
                            .SetData(llngRowCnt, CMvsfWPColNo, llngRowCnt)                                                        '№
                            .SetData(llngRowCnt, CMvsfWPColOpID, _
                                ltypLotprestate.strSteplist(llngCnt).strOpID)                                      '大工程
                                
                            .SetData(llngRowCnt, CMvsfWPColStepID, _
                                ltypLotprestate.strSteplist(llngCnt).strStepID)                                    '小工程
                                
                            .SetData(llngRowCnt, CMvsfWPColAltNumber, _
                                ltypLotprestate.strSteplist(llngCnt).strAltNumber)                                 '代替番号
                            
                            '@工程ﾌﾗｸﾞがﾃﾞﾌｫﾙﾄ工程の場合
                            If ltypLotprestate.strSteplist(llngCnt).strStepDivision = CMstrStepdivisionDefault Then
                                .SetData(llngRowCnt, CMvsfWPColDefault, CMstrDefault)                                             'ﾃﾞﾌｫﾙﾄに「○」をｾｯﾄ
                            End If
                            
                            .SetData(llngRowCnt, CMvsfWPColWpName, _
                                ltypLotWpList.typWpList(llngWpCnt).strWpName)                                      '装置
                                
                            .SetData(llngRowCnt, CMvsfWPColWpID, _
                                ltypLotWpList.typWpList(llngWpCnt).strWpID)                                        '装置ID
                                
                            .SetData(llngRowCnt, CMvsfWPColLoaderFlg, _
                                ltypLotWpList.typWpList(llngWpCnt).strLoaderUnloaderFlag)                          'Loader/Unloaderﾌﾗｸﾞ
                                
                            .SetData(llngRowCnt, CMvsfWPColCarrierType, _
                                ltypLotWpList.typWpList(llngWpCnt).strAfterCarrierTypeId)                          'UNLOADERｷｬﾘｱﾀｲﾌﾟID
                                
                            .SetData(llngRowCnt, CMvsfWPColEqType, _
                                ltypLotWpList.typWpList(llngWpCnt).strEqType)                                      'EQﾀｲﾌﾟ
                                
                            .SetData(llngRowCnt, CMvsfWPColCleanCondition, _
                                ltypLotWpList.typWpList(llngWpCnt).strCleanCondition)                              '洗浄条件

                            .SetData(llngRowCnt, CMvsfWPColLotRecipeFlag, _
                                ltypLotWpList.typWpList(llngWpCnt).strLotRecipeFlag)                               'ﾛｯﾄﾚｼﾋﾟﾌﾗｸﾞ
                            
                            '@装置情報構造体の配列に対応する番号を格納
                            .SetData(llngRowCnt, CMvsfWPColStepCnt, llngCnt)                                                      '大工程番号
                            .SetData(llngRowCnt, CMvsfWPColWpCnt, llngWpCnt)                                                      '装置番号
                            
                            '@ｱｸｼｮﾝ予約表示ﾌﾗｸﾞの初期化
                            .SetData(llngRowCnt, CMvsfWPColActionFlg, CMstrActionFlgNever)                                        '装置番号
                            
                            '@行の高さ設定
                            .Rows(llngRowCnt).Height = CMvsfWPHeight
                            llngRowCnt = llngRowCnt + 1
                        
                            '@ﾛｯﾄ情報格納構造体のWP配列の再設定
                            Dim ltypWPTmp As New WP
                            ltypStepListTmp = New stepList

                            ltypStepListTmp = ltypLotprestate.strSteplist(llngCnt)

                            ltypStepListTmp.lngWPListCnt = ltypStepListTmp.lngWPListCnt + 1

                            '@装置ID
                            ltypWPTmp.strWpID = ltypLotWpList.typWpList(llngWpCnt).strWpID
                                
                            '@装置名
                            ltypWPTmp.strWPName = ltypLotWpList.typWpList(llngWpCnt).strWpName

                            ltypStepListTmp.strWPList.Add(ltypWPTmp)

                            ltypLotprestate.strSteplist(llngCnt) = ltypStepListTmp

                        Next llngWpCnt
                        
                        '@使用部材選択ﾎﾞﾀﾝ表示がONで、装置が0件の場合
                        If ltypLotWpList.lngWPCnt = 0 And cmdSelectMaterial.Visible = True Then
                            
                            '@使用部材選択ﾎﾞﾀﾝを無効にする
                            cmdSelectMaterial.Enabled = False
                        End If
                    End If
                Next llngCnt
                
                '@ﾛｯｸ解除
                .Enabled = True
            End With
            
            '@=======================
            '@ 装置一覧初期ﾎﾞﾀﾝ設定
            '@=======================
            Call pubVsfDisp(vsfWp, cmdUP, cmdDown)
            
            '@装置件数ｾｯﾄ
            lblWpCnt.Text = vsfWp.Rows.Count - 1
            
            '@成功を返す
            prvblnVsfWP_Disp = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "prvblnVsfWP_Disp"           'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnLotStartInput_Check
    '機　能：確定時の入力ﾁｪｯｸ
    '引　数：lblCheckMode:False:UNI装置ﾁｪｯｸのみ True:L/N装置ﾁｪｯｸ含む
    '戻り値：True：項目正常、False：不正項目あり
    '作成日：2004/03/04 (Thu) 18:09:41 T.Kitagawa
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2005/05/19 (Thu) 17:53:48 N.Kasai      CFｷｬﾘｱﾁｪｯｸ追加
    '　　　：2005/07/06 (Wed) 11:22:55 N.Kojima     OnErr処理、SetFocus処理追加
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Function prvblnLotStartInput_Check(ByVal lblCheckMode As Boolean) As Boolean
        
        Try
            
            '@入力ﾁｪｯｸ=False
            prvblnLotStartInput_Check = False
            
            '@ｷｬﾘｱIDの入力ﾁｪｯｸ
            If txtCarrier.Text = vbNullString Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM01W>$$キャリアIDが設定されていません。設定を見直してください。"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(txtCarrier)
                Exit Function
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If Len(txtCarrier.Text) <> CMlngCarrierMaxLength Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM07W>$$キャリアIDは6桁で入力してください。"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(txtCarrier)
                Exit Function
            End If
            
            '@装置名一覧から選択された工程等のﾁｪｯｸ
            With vsfWp
                
                '@選択行が0(ﾀｲﾄﾙ以外の場合)
                If .Row >= .Rows.Fixed Then
                    
                    '@大工程のﾁｪｯｸ
                    If .GetData(vsfWp.Row, CMvsfWPColOpID) = vbNullString Then
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM68W>$$大工程が設定されていません。設定を見直してください。"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0068)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@装置一覧にﾌｫｰｶｽｾｯﾄ
                        Call prvSetFocus(vsfWp)
                        Exit Function
                    End If
                        
                    '@小工程のﾁｪｯｸ
                    If .GetData(vsfWp.Row, CMvsfWPColStepID) = vbNullString Then
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM69W>$$小工程が設定されていません。設定を見直してください。"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0069)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@装置一覧にﾌｫｰｶｽｾｯﾄ
                        Call prvSetFocus(vsfWp)
                        Exit Function
                    End If
                        
                    '@装置IDのﾁｪｯｸ
                    If .GetData(vsfWp.Row, CMvsfWPColWpID) = vbNullString Then
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@「"<TRM18W>$$装置名が設定されていません。設定を見直してください。"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0018)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@装置一覧にﾌｫｰｶｽｾｯﾄ
                        Call prvSetFocus(vsfWp)
                        Exit Function
                    End If
                Else

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@「"<TRM18W>$$装置名が設定されていません。設定を見直してください。"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0018)
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@装置一覧にﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(vsfWp)
                    Exit Function
                End If
            End With
            
            '@状態ﾁｪｯｸ
            If lblStatus.Text <> CPstrWaitWorkSt Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM19W>$$「作業待ち」以外のロットは開始できません。"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0019)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                Call prvSetFocus(txtCarrier)
                Exit Function
            End If
            
            '@L/U装置、CFｷｬﾘｱﾁｪｯｸ含む場合
            If lblCheckMode = True Then
                
                '@Unloaderｷｬﾘｱ
                With txtLoaderCarrier
                    
                    '@txtLoaderCarrierが入力可の場合のみﾁｪｯｸする。
                    If .Enabled = True Then
                        
                        '@UnloaderｷｬﾘｱIDの入力ﾁｪｯｸ
                        If .Text = vbNullString Then
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「"<TRM01W>$$キャリアIDが設定されていません。設定を見直してください。"」のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@ｱﾝﾛｰﾀﾞｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                            Call prvSetFocus(txtLoaderCarrier)
                            Exit Function
                        End If
                        
                        '@ｱﾝﾛｰﾀﾞｷｬﾘｱが6桁ではない場合
                        If Len(.Text) <> CMlngCarrierMaxLength Then
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            '@「"<TRM07W>$$キャリアIDは6桁で入力してください。"」のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@ｱﾝﾛｰﾀﾞｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                            Call prvSetFocus(txtLoaderCarrier)
                            Exit Function
                        End If
                    End If
                End With
            
                '@CFｷｬﾘｱ
                With txtCFCarrier
                    
                    '@CFｷｬﾘｱIDが表示されている場合
                    If .Visible = True Then
                        
                        '@txtLoaderCarrierが入力可の場合のみﾁｪｯｸする。
                        If .Enabled = True Then
                            
                            '@UnloaderｷｬﾘｱIDの入力ﾁｪｯｸ
                            If .Text = vbNullString Then
                                
                                '@表示ﾒｯｾｰｼﾞ変換
                                '@「"<TRM01W>$$キャリアIDが設定されていません。設定を見直してください。"」のﾒｯｾｰｼﾞ表示
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                '@CFｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                                Call prvSetFocus(txtCFCarrier)
                                Exit Function
                            End If
                            
                            '@UnloaderｷｬﾘｱIDが6桁以上か
                            If Len(.Text) <> CMlngCarrierMaxLength Then
                                
                                '@表示ﾒｯｾｰｼﾞ変換
                                '@「"<TRM07W>$$キャリアIDは6桁で入力してください。"」のﾒｯｾｰｼﾞ表示
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                '@CFｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                                Call prvSetFocus(txtCFCarrier)
                                Exit Function
                            End If
                        End If
                    End If
                End With
            End If
            
            '@入力OK
            prvblnLotStartInput_Check = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "prvblnLotStartInput_Check"  'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnCmdActionDisp_Proc
    '機　能：ｱｸｼｮﾝ予約表示
    '引　数：lstrLotID          ：ﾛｯﾄID
    '　　　：lstrOpID           ：大工程ID
    '　　　：lstrStepID         ：小工程ID
    '　　　：lstrPDID           ：機種ID
    '　　　：lstrMasPDVersion   ：工順ﾊﾞｰｼﾞｮﾝ
    '　　　：lstrWPID           ：装置ID
    '　　　：ltypLotAction      ：ｱｸｼｮﾝ予約情報構造体
    '戻り値：True:正常終了、False：異常終了
    '作成日：2004/06/17 (Thu) 15:57:18 H.Wajima
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 16:20:17 H.Wajima     入力項目ﾁｪｯｸを削除(入力ﾊﾟﾗﾒｰﾀが空の場合はｻｰﾊﾞ側及び確定ﾎﾞﾀﾝ等のﾁｪｯｸに依存させる)
    '　　　：2005/07/06 (Wed) 11:24:01 N.Kojima     OnErr処理追加
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Function prvblncmdActionDisp_Proc(ByVal lstrLotID As String, _
                                              ByVal lstrOpID As String, _
                                              ByVal lstrStepID As String, _
                                              ByVal lstrPdID As String, _
                                              ByVal lstrMasPDVersion As String, _
                                              ByVal lstrWpId As String, _
                                              ByRef ltypLotAction As LotAction) As Boolean
        
        Dim lblnAns                 As Boolean              'ｱｸｼｮﾝ予約ﾘｽﾄ取得結果格納
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngCnt                 As Integer              'ｶｳﾝﾄ

        Try
            
            '@初期化
            prvblncmdActionDisp_Proc = False
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "prvblnCmdActionDisp_Proc"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@構造体初期化
            ptypLotAction.lnglstCnt = 0
            ptypLotAction.typLotActList = Nothing
            
            '@=======================
            '@ ｱｸｼｮﾝ予約ﾘｽﾄ取得
            '@=======================
            lblnAns = pubblnLotActList_Sel(CMstrlot_actlist_Ver, _
                                           lstrLotID, _
                                           lstrOpID, _
                                           lstrStepID, _
                                           lstrPdID, _
                                           lstrMasPDVersion, _
                                           lstrWpId, _
                                           ltypLotAction)

            '@取得に成功したら表示(ｱｸｼｮﾝ予約ﾘｽﾄが0件の場合は何も表示しない)
            If lblnAns = True Then
                
                If ptypLotAction.lnglstCnt > 0 Then
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                    
                    With ptypLotAction
                        
                        '@ｱｸｼｮﾝ予約がなくなるまで
                        For llngCnt = 0 To .lnglstCnt - 1
                            Dim ltypLotActListTmp As LotActList

                            ltypLotActListTmp = .typLotActList(llngCnt)

                            ltypLotActListTmp.strLotID = lstrLotID                                'ﾛｯﾄID
                            ltypLotActListTmp.strFlowClass = lblFlowClass.Text                    '流動区分
                            
                            '@ｱｸｼｮﾝ予約ﾀｲﾌﾟ判定
                            Select Case .typLotActList(llngCnt).strLotActionTypeID
                                '@ﾛｯﾄの場合
                                Case CPstrLotActionTypeID0
                                    ltypLotActListTmp.strLotActionTypeName = CPstrActTypeLOT      'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
                                '@機種の場合
                                Case CPstrLotActionTypeID1
                                    ltypLotActListTmp.strLotActionTypeName = CPstrActTypePD       'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
                                '@装置の場合
                                Case CPstrLotActionTypeID2
                                    ltypLotActListTmp.strLotActionTypeName = CPstrActTypeWP       'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
                                '@特定工程の場合
                                Case CPstrLotActionTypeID3
                                    ltypLotActListTmp.strLotActionTypeName = CPstrActTypeTStep    'ｱｸｼｮﾝ予約ﾀｲﾌﾟ
                            End Select
                            
                            ltypLotActListTmp.strActionTrigger = CMstrEN0030Title                 'ｱｸｼｮﾝﾄﾘｶﾞｰ
                            ltypLotActListTmp.strOpID = lstrOpID                                  '大工程
                            ltypLotActListTmp.strStepID = lstrStepID                              '小工程

                            .typLotActList(llngCnt) = ltypLotActListTmp
                        Next llngCnt
                    End With
                    
                    '@ｻﾌﾞ画面で確定していない場合
                    If pblnSubDecision = False Then
                        
                        '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ画面名称設定
                        frmxxCM0040.Instance.Text = CPstrSubDispTitleActionMsg
                        
                        '@ｱｸｼｮﾝ予約ﾒｯｾｰｼﾞ表示画面を表示(ptypLotActionの情報でｱｸｼｮﾝ予約の内容を表示)
                        frmxxCM0040.Instance.ShowDialog(Me)
                        frmxxCM0040.Instance = Nothing
                    Else
                        '@ｻﾌﾞ画面確定ﾌﾗｸﾞ(確定していない)
                        pblnSubDecision = False
                    End If
                    
                    '@設定OK
                    prvblncmdActionDisp_Proc = True
                Else
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                End If
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@ﾛｯｸﾌﾗｸﾞ(ﾛｯｸ)
                mblnEnabled = False
            End If
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "prvblnCmdActionDisp_Proc"   'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnLblRecp_Disp
    '機　能：ﾚｼﾋﾟ表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/19 (Wed) 10:17:01 M.Miura
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2005/02/21 (Mon) 10:59:32 N.Kasai      枚葉ﾚｼﾋﾟ判定条件を変更
    '　　　：2005/06/28 (Tue) 13:11:21 N.Kojima     ｺﾒﾝﾄ行を削除(枚葉ﾚｼﾋﾟ判定条件部)
    '　　　：2005/07/06 (Wed) 11:25:03 N.Kojima     OnErr処理追加
    '　　　：2005/10/04 (Tue) 17:36:58 N.Kojima     Loader/Unloaderﾌﾗｸﾞ格納処理追加(ﾚｼﾋﾟ設定変更画面に引継ぎ)。(不具合№3163)
    '　　　：2008/06/04 (Wed) 10:29:48 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Function prvblnLblRecp_Disp() As Boolean
        
        Dim lstrFormName            As String               'ﾌｫｰﾑ名
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名
        Dim lstrOpID                As String               '大工程
        Dim lstrStepID              As String               '小工程
        Dim lstrWpId                As String               'WPID
        Dim lstrAltNumber           As String               '代替番号
        Dim llngAnsCnt              As Integer              'ﾚｼﾋﾟｶｳﾝﾄ
        Dim llngCnt                 As Integer              'ｶｳﾝﾄ
        Dim lblnAnsRecp             As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrRecpID              As String               'ﾚｼﾋﾟID
        Dim lblnMaiyou              As Boolean              '枚葉ﾚｼﾋﾟ判定ﾌﾗｸﾞ(True:枚葉、False：ﾛｯﾄ)

        Try

            '@ﾚｽﾎﾟﾝｽ開始
            lstrFormName = Me.Name
            lstrEventName = "cmdWFRecp_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            With vsfWp
                
                '@工程格納
                lstrOpID = .GetData(.Row, CMvsfWPColOpID)
                lstrStepID = .GetData(.Row, CMvsfWPColStepID)
                lstrWpId = .GetData(.Row, CMvsfWPColWpID)
                lstrAltNumber = .GetData(.Row, CMvsfWPColAltNumber)
                
                '@代替番号がNULLか
                If lstrAltNumber = vbNullString Then
                    lstrAltNumber = vbNullString
                End If
            End With
            
            '@WFﾄﾗﾝﾚｼﾋﾟ初期化
            ptypWFrecpList = Nothing
            
            'ﾛｯﾄID、大工程、小工程、装置IDがある場合
            If lblLotID.Text <> vbNullString And _
               lstrOpID <> vbNullString And _
               lstrStepID <> vbNullString And _
               lstrWpId <> vbNullString Then
                       
                '@=======================
                '@ ﾛｯﾄﾚｼﾋﾟﾘｽﾄ取得
                '@=======================
                lblnAnsRecp = pubblnLotrecplist_Sel(CMstrlot_recplistVer, lblLotID.Text, _
                                                    lstrOpID, _
                                                    lstrStepID, _
                                                    lstrWpId, _
                                                    CPstrCD23, _
                                                    CMlngEqFlag, _
                                                    lstrAltNumber, _
                                                    llngAnsCnt, , , , mstrVariableResult)
                
                '@結果判定
                If lblnAnsRecp = True Then
                    
                    '@ﾚｼﾋﾟがある場合
                    If llngAnsCnt > 0 Then
                        
                        '@WF別ﾄﾗﾝﾚｼﾋﾟ格納
                        'NSYS ディープコピー VB6の→と等価： ptypWFrecpList = ptypLotrecpList
                        If ptypLotrecpList Is Nothing Then
                            ptypWFrecpList = ptypLotrecpList
                        Else
                            ptypWFrecpList = New List(Of Lotrecplist)(ptypLotrecpList.Count)
                            For Each lLotrecplistTmp As Lotrecplist In ptypLotrecpList
                                If lLotrecplistTmp.typRecipeBodyList IsNot Nothing Then
                                    'NSYS RecipeBodyListのメンバーは値型のみなので、コピーコンストラクタで要素をコピー
                                    lLotrecplistTmp.typRecipeBodyList = New List(Of RecipeBodyList)(lLotrecplistTmp.typRecipeBodyList)
                                End If
                                ptypWFrecpList.Add(lLotrecplistTmp)
                            Next
                        End If

                        prvblnLblRecp_Disp = True
                    Else
                        '@ﾛｯｸﾌﾗｸﾞ(ﾛｯｸ)
                        mblnEnabled = False
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                    End If
                    
                    '@ﾚｼﾋﾟが1件の場合
                    If llngAnsCnt = 1 Then
                        
                        With ptypLotrecpList(llngAnsCnt - 1)
                            
                            '@WFIDがNULLか
                            If .strWfId = vbNullString Then
                                
                                '@折り返し後のﾚｼﾋﾟIDを取得
                                lstrRecpID = prvstrRecipeIDCr_Proc(.strRecipeId)
                                
                                '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟをｾｯﾄ
                                lblRecp.Text = lstrRecpID
                            Else
                                lblRecp.Text = CPstrRecpMaiyou
                            End If
                        End With
                    Else

                        '@ﾚｼﾋﾟが複数ある場合
                        If llngAnsCnt > 1 Then
                            
                            '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟｸﾘｱ
                            lblRecp.Text = vbNullString
                            llngCnt = 1
                            
                            '@枚葉ﾚｼﾋﾟ判定ﾌﾗｸﾞ初期化(True:枚葉、False：ﾛｯﾄ)
                            lblnMaiyou = False
                            
                            For llngCnt = 0 To llngAnsCnt - 1
                                
                                With ptypLotrecpList(llngCnt)
                                    
                                    '@WFIDの設定有無判定(WF_IDが設定済みの場合は枚葉と判断)
                                    If .strWfId <> vbNullString Then
                                        
                                        '@枚葉ﾚｼﾋﾟ判定ﾌﾗｸﾞ(True:枚葉、False：ﾛｯﾄ)
                                        lblnMaiyou = True
                                        Exit For
                                    End If
                                End With
                            Next llngCnt
                            
                            If lblnMaiyou = True Then
                                '@「枚葉レシピ」をｾｯﾄ
                                lblRecp.Text = CPstrRecpMaiyou
                            Else
                                For llngCnt = 0 To llngAnsCnt - 1
                                    
                                    With ptypLotrecpList(llngCnt)
                                        
                                        '@ﾛｯﾄ別ﾚｼﾋﾟのﾃﾞﾌｫﾙﾄﾌﾗｸﾞが"1"か
                                        If .strDefaultFlag = CPstrDefaultRecpFlag Then
                                            
                                            '@折り返し後のﾚｼﾋﾟIDを取得
                                            lstrRecpID = prvstrRecipeIDCr_Proc(.strRecipeId)
                                            
                                            '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟをｾｯﾄ
                                            lblRecp.Text = lstrRecpID
                                            
                                            Exit For
                                        End If
                                    End With
                                Next llngCnt
                                
                                '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟがない場合は1件目のﾚｼﾋﾟをｾｯﾄ
                                If lblRecp.Text = vbNullString Then
                                    
                                    llngCnt = 0
                                    
                                    With ptypLotrecpList(llngCnt)
                                        
                                        '@折り返し後のﾚｼﾋﾟIDを取得
                                        lstrRecpID = prvstrRecipeIDCr_Proc(.strRecipeId)
                                        
                                        '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟをｾｯﾄ
                                        lblRecp.Text = lstrRecpID
                                    End With
                                End If
                            End If
                        End If
                    End If
                Else
                    '@ﾛｯｸﾌﾗｸﾞ(ﾛｯｸ)
                    mblnEnabled = False
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                End If
                
                '@渡すﾃﾞｰﾀを格納
                With ptypLotprestate
                    
                    .strLotID = lblLotID.Text                                               'ﾛｯﾄID
                    .strFlowClass = lblFlowClass.Text                                       '種別
                    .strWfNum = lblWFNo.Text                                                'WF数量
                    .strOpID = vsfWp.GetData(vsfWp.Row, CMvsfWPColOpID)                     '大工程ID
                    .strStartTime = lblStartDayTime.Text                                    '処理開始日時
                    .strPdId = lblPdID.Text                                                 '機種
                    .strSpecialFlg = lblS.Text                                              '特殊特性
                    .strNowST = lblStatus.Text                                              'ﾛｯﾄ状態
                    .strStepID = vsfWp.GetData(vsfWp.Row, CMvsfWPColStepID)                 '小工程ID
                    .strEngEmpName = lblLotManager.Text                                     'ﾛｯﾄ担当者
                    .strLimitTime = mtypLotCurState.strLimitTime                            '制限時間
                    .strWarnTime = mtypLotCurState.strWarnTime                              '警告時間
                    .strAltNumber = lstrAltNumber                                           '代替番号
                    .strLotLastUpdate = mstrLotLastUpdate                                   '最終更新日時
                    '@↓2020/01/15 (Wed) 16:55:37 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    .strGRBClass = lblGRB.Text                                              'GRB
                    '@↑2020/01/15 (Wed) 16:55:37 Y.Yoneyama 「.Netへ反映未」 **************************************************
                End With
                
                pstrCarrierID = txtCarrier.Text                                             'ｷｬﾘｱID
                
                With vsfWp
                    pstrWPID = .GetData(.Row, CMvsfWPColWpID)                               '装置名
                    pstrWPName = .GetData(.Row, CMvsfWPColWpName)                           '装置名
                    pstrDefaultStep = .GetData(.Row, CMvsfWPColDefault)                     'ﾃﾞﾌｫﾙﾄ小工程
                    pstrEqType = .GetData(.Row, CMvsfWPColEqType)                           'EQﾀｲﾌﾟ
                    pstrLotRecipeFlag = .GetData(.Row, CMvsfWPColLotRecipeFlag)             'ﾛｯﾄﾚｼﾋﾟﾌﾗｸﾞ
                    pstrLoaderUnloaderFlag = .GetData(.Row, CMvsfWPColLoaderFlg)            'Loader/Unloaderﾌﾗｸﾞ
                End With
                
                '@流動ﾀｲﾌﾟの判定
                If mtypLotCurState.strFlowType <> CPstrLotCurstateFlowTypeMove Then
                    '@移載工程以外の場合
                    
                    '@ﾚｼﾋﾟがない、又は、ﾊﾞｯﾁ編成されている場合
                    If llngAnsCnt = 0 Then
                        
                        '@ﾚｼﾋﾟｸﾘｱ
                        lblRecp.Text = vbNullString
                        '@ﾛｯｸ
                        cmdWFRecp.Enabled = False
                    Else
                        
                        '@ﾊﾞｯﾁ編成されている場合
                        If mblnBacthFlg = True Then
                            
                            '@ﾛｯｸ
                            cmdWFRecp.Enabled = False
                        Else
                            '@ﾛｯｸ解除
                            cmdWFRecp.Enabled = True
                        End If
                    End If
                Else
                    '@移載工程の場合
                    
                    '@ﾛｯｸ
                    cmdWFRecp.Enabled = False
                End If
            Else
                '@ﾛｯｸ
                cmdWFRecp.Enabled = False
                
                '@ﾚｼﾋﾟｸﾘｱ
                lblRecp.Text = vbNullString
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "prvblnLblRecp_Disp"         'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvstrRecipeIDCr_Proc
    '機　能：ﾚｼﾋﾟIDを折り返す
    '引　数：lstrRecpID：ﾚｼﾋﾟID
    '戻り値：折り返し後のﾚｼﾋﾟID
    '作成日：2004/10/01 (Fri) 17:23:40 M.Miura
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2005/07/06 (Wed) 11:25:56 N.Kojima     OnErr処理追加
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Function prvstrRecipeIDCr_Proc(ByVal lstrRecpID As String) As String

        Dim llngMaxLen              As Integer              'ﾚｼﾋﾟ文字数
        Dim llngLenCnt              As Integer              '文字ｶｳﾝﾄ
        Dim lstrRecpIDWk            As String               'ﾚｼﾋﾟID

        Try

            '@ﾚｼﾋﾟIDの文字数
            llngMaxLen = Len(lstrRecpID)
            
            '@ﾚｼﾋﾟID文字数が折り返し文字数以下の場合
            If llngMaxLen <= CMlngRecpCrLen Then
                
                '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟをｾｯﾄ
                prvstrRecipeIDCr_Proc = lstrRecpID
            Else
                '@ﾚｼﾋﾟIDの最後の文字まで
                For llngLenCnt = 1 To llngMaxLen
                    
                    '@文字数判定
                    Select Case llngLenCnt
                        
                        '@折り返し文字数の場合
                        Case CMlngRecpCrLen, CMlngRecpCrLen + CMlngRecpCrLen
                            
                            lstrRecpIDWk = lstrRecpIDWk & Mid$(lstrRecpID, llngLenCnt, 1) & vbCrLf
                        
                        Case Else
                            
                            lstrRecpIDWk = lstrRecpIDWk & Mid$(lstrRecpID, llngLenCnt, 1)
                    
                    End Select
                Next llngLenCnt
                
                '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟをｾｯﾄ
                prvstrRecipeIDCr_Proc = lstrRecpIDWk
            End If

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "prvstrRecipeIDCr_Proc"      'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvHandWork_Set
    '機　能：ﾊﾝﾄﾞﾜｰｸ対応
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/02 (Wed) 17:29:17 S.Deguchi
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2005/03/09 (Wed) 13:46:21 S.Deguchi    不具合№512対応で単独起動時の判別を追加
    '　　　：2005/06/28 (Tue) 13:16:30 N.Kojima     ｺﾒﾝﾄ行を削除(引継ぎｷｬﾘｱ判定部)
    '　　　：2005/07/06 (Wed) 11:26:20 N.Kojima     OnErr処理追加
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub prvHandWork_Set()
        
        Try
                
            '@引継構造体のｷｬﾘｱIDが空欄でない場合
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                
                '@UnloaderｷｬﾘｱIDが空欄でないか否かで判別
                If txtLoaderCarrier.Text <> vbNullString Then
                    
                    ptypCommonInfo.strCarrierId = txtCarrier.Text               'ｷｬﾘｱID
                    ptypCommonInfo.strToCarrierId = txtLoaderCarrier.Text       'ｱﾝﾛｰﾀﾞｰ側ｷｬﾘｱID
                Else
                    ptypCommonInfo.strCarrierId = txtCarrier.Text               'ｷｬﾘｱID
                    ptypCommonInfo.strToCarrierId = vbNullString                'ｱﾝﾛｰﾀﾞｰ側ｷｬﾘｱID
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030                '機能ID
                .strProcName = "prvHandWork_Set"            'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvColorChang_EN0030
    '機　能：作業開始画面のﾗﾍﾞﾙ&ｸﾞﾘｯﾄﾀｲﾄﾙ行の色変え処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/07/01 (Tur) 11:40:10 M.Koni
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub prvColorChang_EN0030()

        Dim llngNo      As Integer      'ｶｳﾝﾀ

        Try

            '@ﾃﾞﾌｫﾙﾄ装置でない場合は，「赤」表示
            If pstrTerminalFlag = CPstrZero Then
                If pblnWpSelectFlag <> True Then

                    '@全てのｺﾝﾄﾛｰﾙのﾀｲﾄﾙを赤にする
                    '@↓2020/01/15 (Wed) 16:57:22 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    'For llngNo = 0 To 15
                    For llngNo = 0 To 16
                    '@↑2020/01/15 (Wed) 16:57:22 Y.Yoneyama 「.Netへ反映未」 **************************************************

                        Me.Controls("lblTtl" & llngNo.ToString).BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    Next

                    '@工程，装置名の行の色を変更(0,0-0,5)
                    vsfWP.Styles.Fixed.BackColor = ColorTranslator.FromWin32(CMlngRedColor)

                    '@装置件数欄
                    lblTitle1.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                    
                    '@CFｷｬﾘｱ欄
                    lblCFTtl.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                End If
            Else
                '@全てのｺﾝﾄﾛｰﾙのﾀｲﾄﾙを赤にする
                '@↓2020/01/15 (Wed) 16:58:05 Y.Yoneyama 「.Netへ反映未」 **************************************************
                'For llngNo = 0 To 15
                For llngNo = 0 To 16
                '@↑2020/01/15 (Wed) 16:58:05 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    Me.Controls("lblTtl" & llngNo.ToString).BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                Next

                '@工程，装置名の行の色を変更(0,0-0,5)
                 vsfWP.Styles.Fixed.BackColor = ColorTranslator.FromWin32(CMlngRedColor)

                '@装置件数欄
                lblTitle1.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
                            
                '@CFｷｬﾘｱ欄
                lblCFTtl.BackColor = ColorTranslator.FromWin32(CMlngRedColor)
            End If

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvColorChang_EN0030"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnChgMaterial_Chk
    '機　能：使用部材判定＆権限ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True   ：権限あり or 通常実行
    '　　　：False  ：権限なし or 処理中断
    '作成日：2006/04/19 (Wed) 16:26:10 N.Kojima
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2006/10/04 (Wed) 09:17:12 N.Kojima     部材の機種限定機能追加に伴い、処理修正。(案件№01472)
    '　　　：2006/11/29 (Wed) 16:44:12 T.Kitagawa　 ﾊﾟｽﾜｰﾄﾞ確認機能追加(案件№01581)
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Function prvblnChgMaterial_Chk() As Boolean

        Dim lblnAns                 As Boolean      '戻り値判定用(true or false)
        Dim llngAns                 As Integer      '戻り値判定用(ﾒｯｾｰｼﾞﾎﾞｯｸｽからのﾘﾀｰﾝ値参照)
        Dim lstrPdResultFlag        As String       '機種限定ﾁｪｯｸﾌﾗｸﾞ格納用

        Try
            
            '@戻り値の初期化
            prvblnChgMaterial_Chk = False
            
            '@---- 使用部材期限関連ﾁｪｯｸ ----
            
            '@=======================
            '@ 装置使用部材の判定処理(期限関連)を行なう
            '@=======================
            lblnAns = prvblnMaterialPeriod_Chk(lstrPdResultFlag)
                
            '@ｴﾗｰMsg判定(何らかの期限制約に引っ掛かっている場合は、"Msgあり")
            If lblnAns = True Then
                '@ﾁｪｯｸOK

                '@ｴﾗｰMsg判定(Msg有り=何らかの期限超過あり、Msg無し=期限等の制約に問題なし)
                If mstrLimitErrMsg <> vbNullString Then
                    '@ｴﾗｰMsgが格納されている場合

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@"<TRM7UW>$$%1"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007U, mstrLimitErrMsg)
                    '@確認ﾒｯｾｰｼﾞBOXを表示する
                    llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                    '@要求確認
                    If llngAns = vbNo Then
                        
                        '@戻り値を"false=処理中断"を設定
                        prvblnChgMaterial_Chk = False
                        
                        '@強制実行ﾌﾗｸﾞを初期化
                        mstrLimitForcedAction = CPstrZero
                        Exit Function
                    Else
                        '@強制実行を行なう(mstrLimitForcedAction=1)
                        mstrLimitForcedAction = CPstrOne
                    End If
                Else
                    '@ｴﾗｰMsgが格納されていない場合

                    '@通常実行を行なう(mstrLimitForcedAction=0)
                    mstrLimitForcedAction = CPstrZero
                End If

                '@機種限定判定ｴﾗｰMsg判定(Msg有り=機種限定判定問題あり、Msg無し=機種限定判定問題なし)
                If mstrPdErrMsg <> vbNullString Then
                    '@ｴﾗｰMsgが格納されている場合

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@"<TRM7UW>$$%1"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007U, mstrPdErrMsg)
                    '@確認ﾒｯｾｰｼﾞBOXを表示する
                    llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                    '@要求確認
                    If llngAns = vbNo Then
                        
                        '@戻り値を"false=処理中断"を設定
                        prvblnChgMaterial_Chk = False
                        
                        '@強制実行ﾌﾗｸﾞを初期化
                        mstrPdForcedAction = CPstrZero
                        Exit Function
                    Else
                        '@強制実行を行なう(mstrPdForcedAction=1)
                        mstrPdForcedAction = CPstrOne
                    End If
                Else
                    '@ｴﾗｰMsgが格納されていない場合

                    '@通常実行を行なう(mstrPdForcedAction=0)
                    mstrPdForcedAction = CPstrZero
                End If
            Else
                '@ﾁｪｯｸNG
                Exit Function
            End If
            
            '@期限切れ、機種限定部材の強制実行か
            If mstrPdForcedAction = CPstrOne Or _
                mstrLimitForcedAction = CPstrOne Then
                
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@ 作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM0020.Instance.ShowDialog(Me)
                frmxxCM0020.Instance = Nothing
            Else
            
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@ 作業者ｺｰﾄﾞ入力画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM0010.Instance.ShowDialog(Me)
                frmxxCM0010.Instance = Nothing
            End If
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                
                '@戻り値を"false=処理中断"を設定
                prvblnChgMaterial_Chk = False
                Exit Function
            End If
                
            '@強制実行が行なわれた場合は、権限ﾁｪｯｸを行なう
            If mstrPdForcedAction = CPstrOne Or _
                mstrLimitForcedAction = CPstrOne Then
                '@強制実行の場合
                
                '@=======================
                '@ 期限超過部材使用権限ﾁｪｯｸ
                '@=======================
                lblnAns = prvblnAuthority_Chk
                    
                '@権限判定結果
                If lblnAns = False Then
                    '@"権限なし"の場合
                
                    '@戻り値を"false=権限なし"を設定
                    prvblnChgMaterial_Chk = False
                    '@処理中断
                    Exit Function
                Else
                    '@"権限あり"の場合
                    
                    '@戻り値を"true=権限あり"を設定
                    prvblnChgMaterial_Chk = True
                End If
            Else
                '@通常実行の場合
                
                '@戻り値を"true=通常"を設定
                prvblnChgMaterial_Chk = True
            End If
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030
                .strProcName = "prvblnChgMaterial_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnMaterialPeriod_Chk
    '機　能：使用部材ﾁｪｯｸ処理
    '引　数：lstrPdResultFlag   :機種限定ﾁｪｯｸﾌﾗｸﾞ
    '戻り値：なし
    '作成日：2006/04/19 (Wed) 14:38:28 N.Kojima
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2006/06/27 (Tue) 20:08:52 N.Kojima     部材の機種限定対応,装置複数紐付け対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0189)
    '　　　：2006/10/04 (Wed) 16:51:50 N.Kojima     部材の機種限定機能への仕様追加に伴い、処理追加。(案件№01472)
    '　　　：2006/10/20 (Fri) 17:15:43 N.Kojima     ﾚｽﾎﾟﾝｽ処理を追加。(案件№01605)
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Function prvblnMaterialPeriod_Chk(ByRef lstrPdResultFlag As String) As Boolean

        Dim lblnAns                 As Boolean              '戻り値判定用
        Dim ltypChkMaterial         As ChkMaterial          '装置使用部材判定要求格納用

        Try
                    
            '@戻り値の初期化
            prvblnMaterialPeriod_Chk = False
            
            '@画面の使用禁止
            Me.KeyPreview = False
            
            '@***********************
            '@ 送信ﾃﾞｰﾀ格納
            '@***********************
            With ltypChkMaterial
                .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strMsgVer = CMstrmat_chkwpmaterialVer      'Msgﾊﾞｰｼﾞｮﾝ
                .strMaterialTypeID = vbNullString           '部材種別ID(NULL)
                .strMaterialID = vbNullString               '部材ID(NULL)
                .strMaterialLotID = vbNullString            '部材管理ID(NULL)
                .strClassDivision = CPstrCD10               '処理区分(10:作業開始)
                .strWpID = vsfWp.GetData(vsfWp.Row, CMvsfWPColWpID)        '装置ID
                .strLotID = lblLotID.Text                   'ﾛｯﾄID
            End With
            
            '@構造体のｺﾋﾟｰ
            ltypChkMaterial.typMaterialTypeList = ptypChkMaterial.typMaterialTypeList       '配列
            ltypChkMaterial.lngMaterialTypeCnt = ptypChkMaterial.lngMaterialTypeCnt         '配列ｶｳﾝﾀ
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvblnMaterialPeriodChk)
            
            '@=======================
            '@ 装置使用部材判定ﾒｯｾｰｼﾞ送信
            '@=======================
            lblnAns = pubblnMatChkWPMaterial_Chk(ltypChkMaterial, _
                                                 mstrPdErrMsg, _
                                                 mstrLimitErrMsg)
                
            '@画面の使用禁止解除
            Me.KeyPreview = True
            
            '@戻り値判定
            If lblnAns = True Then
                '@取得成功
         
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrPrvblnMaterialPeriodChk)
                
                '@戻り値の設定
                prvblnMaterialPeriod_Chk = True
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvblnMaterialPeriodChk)
            End If

            Exit Function

        Catch ex As Exception

            '@画面の使用禁止解除
            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030
                .strProcName = "prvblnMaterialPeriod_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnAuthority_Chk
    '機　能：期限超過部材使用権限ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/19 (Wed) 15:33:03 N.Kojima
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2006/10/04 (Wed) 16:52:32 N.Kojima     部材の機種限定機能への仕様追加に伴い、処理追加。(案件№01472)
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Function prvblnAuthority_Chk() As Boolean

        Dim lblnAns                 As Boolean              '戻り値判定用
        Dim lstrFunctionID          As String               '機能ID
        Dim lstrActionID            As String               'ｱｸｼｮﾝID
        Dim lstrEmpID               As String               '作業者ID
        Dim lstrEmpName             As String               '作業者名
        Dim lstrSBID                As String               'ｼｽﾃﾑﾌﾞﾛｯｸ

        Try
                    
            '@戻り値の初期化
            prvblnAuthority_Chk = False
                    
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Function
            End If
            
            '@ﾌｫｰﾑﾛｯｸ中の場合は処理を受け付けない
            If Me.Enabled = False Then
                Exit Function
            End If
            
            '@画面の使用禁止
            Me.KeyPreview = False
                
            '@部材期限強制実行が選択されている場合
            If mstrLimitForcedAction = CPstrOne Then
            
                '@実行権限の処理を追加
                lstrFunctionID = CPstrKeyEN0030             '機能ID：EN0030
                lstrActionID = CPstrUsePeriodOverMaterial   'ｱｸｼｮﾝID：期限超過部材使用
                lstrEmpID = pstrUserID                      'ﾕｰｻﾞｰID
                lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名
                lstrSBID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
            
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrPrvblnAuthorityChk)
                
                '@=======================
                '@ 実行権限ﾁｪｯｸ
                '@=======================
                lblnAns = pubAuthority_Chk(lstrFunctionID, _
                                           lstrActionID, _
                                           lstrEmpID, _
                                           lstrEmpName, _
                                           lstrSBID)
                
                '@画面の使用禁止
                Me.KeyPreview = True
                
                '@結果判定
                If lblnAns = False Then
                    '@権限が"なし"の場合
            
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrPrvblnAuthorityChk)
            
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, CPstrUsePeriodOverMaterial)
                    '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
                    '@戻り値を"False=権限なし"で設定
                    prvblnAuthority_Chk = False
                    Exit Function
                Else
                    '@権限が"あり"の場合
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrPrvblnAuthorityChk)
                    
                    '@戻り値を"True=権限あり"で設定
                    prvblnAuthority_Chk = True
                End If
            End If
            
            
            '@機種限定強制実行が選択された場合
            If mstrPdForcedAction = CPstrOne Then
            
                '@実行権限の処理を追加
                lstrFunctionID = CPstrKeyEN0030             '機能ID：EN0030
                lstrActionID = CPstrUsePdRestrictMaterial   'ｱｸｼｮﾝID：機種限定部材使用
                lstrEmpID = pstrUserID                      'ﾕｰｻﾞｰID
                lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名
                lstrSBID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
            
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrPrvblnAuthorityChk)
                
                '@=======================
                '@ 実行権限ﾁｪｯｸ
                '@=======================
                lblnAns = pubAuthority_Chk(lstrFunctionID, _
                                           lstrActionID, _
                                           lstrEmpID, _
                                           lstrEmpName, _
                                           lstrSBID)
                
                '@画面の使用禁止
                Me.KeyPreview = True
                
                '@結果判定
                If lblnAns = False Then
                    '@権限が"なし"の場合
            
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrPrvblnAuthorityChk)
            
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, CPstrUsePdRestrictMaterial)
                    '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
                    '@戻り値を"False=権限なし"で設定
                    prvblnAuthority_Chk = False
                Else
                    '@権限が"あり"の場合
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrPrvblnAuthorityChk)
                    
                    '@戻り値を"True=権限あり"で設定
                    prvblnAuthority_Chk = True
                End If
            End If
            
            Exit Function

        Catch ex As Exception

            '@画面の使用禁止解除
            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030
                .strProcName = "prvblnAuthority_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnSpcRegcollect_Set
    '機　能：装置ﾃﾞｰﾀ登録
    '引　数：mstrLotLastUpdate：
    '戻り値：True:成功、False:失敗
    '作成日：2006/12/20 (Wed) 13:29:00 N.Kasai
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Function prvblnSpcRegcollect_Set(ByRef mstrLotLastUpdate As String) As Boolean

        Dim lblnAns                 As Boolean              '戻り値
        Dim ltypWfChgCollection     As WfChgCollection      '装置ﾃﾞｰﾀ格納
        Dim llngCnt1                As Integer              '大ｶｳﾝﾀ
        Dim llngCnt2                As Integer              '中ｶｳﾝﾀ
        Dim llngCnt3                As Integer              '小ｶｳﾝﾀ
        Dim llngDataCnt             As Integer              '実ﾃﾞｰﾀｶｳﾝﾄ
        Dim lstrParameter           As String               'ﾊﾟﾗﾒｰﾀ格納
        
        Try
            
            '@戻り値
            prvblnSpcRegcollect_Set = False
            
            '@ｶｳﾝﾀ初期値
            llngDataCnt = 1

            ltypWfChgCollection.typEqWfDataEntry = New List(Of EqWfDataEntry)
            
            '@***********************
            '@ 送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypWfChgCollection
                
                .strMsgVer = CMstrspc_regcollectVer
                .strSbID = pstrSBID
                .strClassDivision = CPstrCD01
                .strCarrierId = txtCarrier.Text
                .strDataDivision = "LOT"
                .strEmpID = pstrUserID
                .strLotLastUpdate = mstrLotLastUpdate
                .strParameterID = vbNullString
                .strParameterVersion = vbNullString
                .strSlotPosition = vbNullString
                
                '@装置ﾃﾞｰﾀ取得
                For llngCnt1 = 0 To ptypChkMaterial.lngMaterialTypeCnt - 1
                    
                    For llngCnt2 = 0 To ptypChkMaterial.typMaterialTypeList(llngCnt1).lngMaterialCnt - 1
                        
                        For llngCnt3 = 0 To ptypChkMaterial.typMaterialTypeList(llngCnt1).typMaterialIDList(llngCnt2).lngMaterialLotCnt - 1
                    
                            '@配列の再定義
                            Dim ltypEqWfDataEntry As New EqWfDataEntry
                        
                            '@ﾃﾞｰﾀ格納
                            ltypEqWfDataEntry.strDvName = vbNullString
                        
                            lstrParameter = vbNullString
                            If ptypChkMaterial.typMaterialTypeList(llngCnt1).strParameterID <> vbNullString Then
                                lstrParameter = CMstrColon & CMstrColon & CMstrColon & CMstrColon & _
                                        ptypChkMaterial.typMaterialTypeList(llngCnt1).strParameterID & CMstrColon & CMstrColon
                            End If
                            ltypEqWfDataEntry.strDvNameParameter = lstrParameter
                                
                            ltypEqWfDataEntry.strDvValue = _
                                    ptypChkMaterial.typMaterialTypeList(llngCnt1).typMaterialIDList(llngCnt2).typMaterialLotIDList(llngCnt3).strMaterialLotID
                        
                            '@収集項目ﾀｲﾌﾟは作業開始からは必要ない項目だ(吉田氏より)
                            ltypEqWfDataEntry.strCollectionType = vbNullString
                            llngDataCnt = llngDataCnt + 1
                        
                            .typEqWfDataEntry.Add(ltypEqWfDataEntry)
                        Next
                    Next
                Next
                
                '@ﾃﾞｰﾀ数格納
                .lngEqWfDataEntryCnt = llngDataCnt - 1
            End With

            '@=======================
            '@ 装置ﾃﾞｰﾀ登録
            '@=======================
            lblnAns = pubblnSpcRegCollect_Ins(ltypWfChgCollection, mstrLotLastUpdate)
            
            '@結果判定
            If lblnAns = True Then
                prvblnSpcRegcollect_Set = True
            End If
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030
                .strProcName = "prvblnSpcRegcollect_Set"
                .strErrMessage = vbNullString
            End With
            
            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvControlColor_Init
    '機　能：ｺﾝﾄﾛｰﾙの色の初期化(青色化)
    '引　数：なし
    '戻り値：なし
    '作成日：2008/07/03 (Thu) 09:50:02 M.Koni
    '更新日：2009/07/02 (Thu) 18:13:37 N.Kojima
    '備　考：
    '　　　：2009/07/02 (Thu) 18:13:37 N.Kojima     無機対応。(案件№03560)
    Private Sub prvControlColor_Init()

        Dim llngCnt         As Integer

        Try

            '@ｺﾝﾄﾛｰﾙのﾀｲﾄﾙを青にする
            '@↓2020/01/20 (Mon) 15:00:47 Y.Yoneyama 「.Netへ反映未」 **************************************************
            'For llngCnt = 0 To 15
            For llngCnt = 0 To 16
            '@↑2020/01/20 (Mon) 15:00:47 Y.Yoneyama 「.Netへ反映未」 **************************************************
                Me.Controls("lblTtl" & llngCnt.ToString).BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
            Next

            '@装置件数欄
            lblTitle1.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
            
            '@CFｷｬﾘｱ欄
            lblCFTtl.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvControlColor_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2009/07/16 (Thu) 11:49:38 N.Kojima **************************************************
    '@現状の装置仕様だと、単発ﾛｯﾄで報告されるとﾀﾞﾒらしい…。後日復活の可能性を考え、現状は一旦ｺﾒﾝﾄｱｳﾄ。

    ''関数名：prvblnWpIdBatchMoveIn_Proc
    ''機　能：ﾊﾞｯﾁ投入順通知処理
    ''引　数：なし
    ''戻り値：True：通知成功、False：通知失敗
    ''作成日：2009/07/16 (Thu) 11:53:59 N.Kojima
    ''更新日：2009/07/16 (Thu) 11:53:59
    ''備　考：
    'Private Function prvblnWpIdBatchMoveIn_Proc() As Boolean
    '
    '    Dim lblnAns                 As Boolean              '戻り値判定用
    '    Dim llngCnt                 As Long                 '汎用ｶｳﾝﾀ
    '    Dim ltypEqBatchMoveIn       As EqBatchMoveIn        'ﾊﾞｯﾁ投入順通知要求ﾃﾞｰﾀ格納構造体
    '
    '    On Error GoTo Error_Handler
    '
    '    '@戻り値の初期化
    '    prvblnWpIdBatchMoveIn_Proc = False
    '
    '    '@*****************************************************
    '    '@ 表面処理装置の場合、装置にﾊﾞｯﾁ組ﾛｯﾄの投入順を通知する
    '    '@*****************************************************
    '
    '    '@表面処理装置か
    '    If vsfWP.Cell(flexcpText, vsfWP.Row, CMvsfWPColEqType) = CPstrEqTypeHyoumenSyori Then
    '
    '        '@***********************
    '        '@ 送信ﾃﾞｰﾀ作成
    '        '@***********************
    '        With ltypEqBatchMoveIn
    '
    '            '@MsgSubを作成([WP_ID].batchmovein)
    '            .strMsgSubject = vsfWP.Cell(flexcpText, vsfWP.Row, CMvsfWPColWpID) & CPstrwpidbatchmovein
    '
    '            .strMsgVer = CMstrwpidbatchmoveinVer        'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    '            .strBatchID = mtypLotCurState.strBatchID    'ﾊﾞｯﾁID
    '            .strRecipeID = lblRecp.Caption              'ﾚｼﾋﾟID
    '
    '            '@-----------------------
    '            '@ 投入ｷｬﾘｱﾘｽﾄ作成
    '            '@-----------------------
    '            '@ﾘｽﾄを+1する
    '            ReDim Preserve .typCarrierList(1)
    '
    '            .typCarrierList(1).strSeqNum = mtypLotCurState.strBatchSeqNum                   '投入順
    '            .typCarrierList(1).strLoaderCarrierID = txtCarrier.Text                         'LDｷｬﾘｱID
    '            .typCarrierList(1).strUnloaderCarrierID = mtypLotCurState.strUnloaderCarrierID  'ULDｷｬﾘｱID
    '            .typCarrierList(1).strUseID = Ucase(mtypLotCurState.strUseID)                   '機種区分
    '
    '        End With
    '
    '        '@ﾌｫｰﾑﾛｯｸ
    '        frmxxEN0030.Enabled = False
    '
    '        '@ﾚｽﾎﾟﾝｽ取得開始
    '        Call pubResponseStart(CMstrFormName, CMstrPrvBlnEqBatchMoveInProc)
    '
    '
    '        '@=======================
    '        '@ ﾊﾞｯﾁ投入順通知
    '        '@=======================
    '        lblnAns = pubblnWpIdBatchMoveIn_Ntf(ltypEqBatchMoveIn)
    '
    '
    '        '@ﾊﾞｯﾁ投入順通知結果が"True：通信成功"か
    '        If lblnAns = True Then
    '
    '            '@ﾌｫｰﾑﾛｯｸ解除
    '            frmxxEN0030.Enabled = True
    '
    '            '@ﾚｽﾎﾟﾝｽ取得終了
    '            Call publngResponseEnd(CMstrFormName, CMstrPrvBlnEqBatchMoveInProc)
    '
    '            '@表示ﾒｯｾｰｼﾞ変換
    '            '@ｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰに「<TRM1HI>$$装置に投入順を通知しました。」のﾒｯｾｰｼﾞ表示
    '            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001H)
    '            Call pubVsfInfo_Disp(pstrDMsg)
    '
    '        Else
    '            '@ﾊﾞｯﾁ投入順通知結果が"False：通信失敗"か
    '
    '            '@ﾌｫｰﾑﾛｯｸ解除
    '            frmxxEN0030.Enabled = True
    '
    '            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
    '            Call pubResponseCancel(CMstrFormName, CMstrPrvBlnEqBatchMoveInProc)
    '
    '            '@表示ﾒｯｾｰｼﾞ変換
    '            '@「"<TRM1QW>$$装置に対しての投入順通知が失敗した為、作業開始出来ません。"」のﾒｯｾｰｼﾞ表示
    '            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001Q)
    '            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxEN0030.Caption, True, 16)
    '
    '            Exit Function
    '        End If
    '    End If
    '
    '    '@戻り値に"True：通知成功"をｾｯﾄ
    '    prvblnWpIdBatchMoveIn_Proc = True
    '
    '    Exit Function
    '
    'Error_Handler:
    '
    '    '@ﾌｫｰﾑﾛｯｸ解除
    '    frmxxEN0030.Enabled = True
    '
    '    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '    With ptypOnErrorInfo
    '        .strMenuKey = CMstrLocalMenuKey
    '        .strProcName = "prvblnWpIdBatchMoveIn_Proc"
    '        .strErrMessage = vbNullString
    '    End With
    '
    '    '@=======================
    '    '@ 共通ｴﾗｰ処理
    '    '@=======================
    '    Call pubOnError_Proc
    '
    'End Function
    '@↑2009/07/16 (Thu) 11:49:38 N.Kojima **************************************************

    '関数名：prvblnBCRCarrierIdSkip_Chk
    '機　能：BCRｷｬﾘｱID照合ｽｷｯﾌﾟ権限有無確認
    '引　数：なし
    '戻り値：なし
    '作成日：2012/04/25 (Wed) 12:50:15 Y.Yoneyama
    '更新日：2012/04/25 (Wed) 12:50:15 Y.Yoneyama
    '備　考：
    Private Function prvblnBCRCarrierIdSkip_Chk() As Boolean

        Dim lblnAns                 As Boolean              '戻り値判定用
        Dim lstrFunctionID          As String               '機能ID
        Dim lstrActionID            As String               'ｱｸｼｮﾝID
        Dim lstrEmpID               As String               '作業者ID
        Dim lstrEmpName             As String               '作業者名
        Dim lstrSBID                As String               'ｼｽﾃﾑﾌﾞﾛｯｸ

        Try
                    
            '@戻り値の初期化
            prvblnBCRCarrierIdSkip_Chk = False
                    
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Function
            End If
            
            '@ﾌｫｰﾑﾛｯｸ中の場合は処理を受け付けない
            If Me.Enabled = False Then
                Exit Function
            End If
            
            '@画面の使用禁止
            Me.KeyPreview = False
                
            '@実行権限の処理を追加
            lstrFunctionID = CPstrKeyEN0030             '機能ID：EN0030
            lstrActionID = CPstrCBRCarrierIdSkip        'ｱｸｼｮﾝID：BCRキャリアID照合スキップ
            lstrEmpID = pstrUserID                      'ﾕｰｻﾞｰID
            lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名
            lstrSBID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                    
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, prvblnBCRCarrierIdSkip_Chk)
                
            '@=======================
            '@ 実行権限ﾁｪｯｸ
            '@=======================
            lblnAns = pubAuthority_Chk(lstrFunctionID, _
                                        lstrActionID, _
                                        lstrEmpID, _
                                        lstrEmpName, _
                                        lstrSBID)
                
            '@画面の使用禁止
            Me.KeyPreview = True
                
            '@結果判定
            If lblnAns = False Then
                
                '@権限が"なし"の場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, prvblnBCRCarrierIdSkip_Chk)
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, CPstrCBRCarrierIdSkip)
                '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
                '@戻り値を"False=権限なし"で設定
                prvblnBCRCarrierIdSkip_Chk = False
            Else
                '@権限が"あり"の場合
                    
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, prvblnBCRCarrierIdSkip_Chk)
                    
                '@戻り値を"True=権限あり"で設定
                prvblnBCRCarrierIdSkip_Chk = True
            End If
            
            Exit Function

        Catch ex As Exception

            '@画面の使用禁止解除
            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030
                .strProcName = "prvblnBCRCarrierIdSkip_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvCfCarrier_Chk
    '機　能：CFキャリアに入力されたロットをチェックする
    '引　数：なし
    '戻り値：True：OK、False：NG
    '作成日：2013/12/20 (Fri) 18:24:36 T.Oide
    '更新日：2013/12/20 (Fri) 18:24:36
    '備　考：
    Private Function prvCfCarrier_Chk() As Boolean

        Dim lblnAns                 As Boolean              '汎用戻り値結果取得(True:正常,False:異常)
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypCFListRec           As CFListRec            'CFﾘｽﾄ要求格納構造体

        Try

            '@初期値設定
            prvCfCarrier_Chk = False
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "txtCFCarrier_Validate"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@***********************
            '@ CFｷｬﾘｱ状態取得送信ﾃﾞｰﾀ
            '@***********************
            With ltypCFListRec
                .strMsgVer = CMstrcarrcfcurstateVer     'MSGﾊﾞｰｼﾞｮﾝ
                .strSbID = pstrSBID                     'SBID
                .strTFTLotID = lblLotID.Text            'TFTﾛｯﾄ
                .strWfNum = mtypLotCurState.strWfNum    'WF数量
                .strCFCarrierID = txtCFCarrier.Text     'CFｷｬﾘｱID
            End With
            
            '@=======================
            '@ CFｷｬﾘｱ状態取得
            '@=======================
            lblnAns = pubblnCarrCfCurstate_Sel(ltypCFListRec)
            
            '@取得結果確認
            If lblnAns = True Then
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@確定ﾎﾞﾀﾝが有効か
                If cmdLotStart.Enabled = True Then
                    
                    '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(cmdLotStart, txtCFCarrier)
                Else
                    '@CFｷｬﾘｱ選択ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call prvSetFocus(cmdCFCarrierSelect, txtCFCarrier)
                End If
                
                '@結果OK
                prvCfCarrier_Chk = True
                
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@結果NG
                prvCfCarrier_Chk = False
                
            End If
            
        Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0030
                .strProcName = "prvCfCarrier_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnOvertakeAuthority_Chk
    '機　能：無機ODF追越制限権限ﾁｪｯｸ処理
    '引　数：lstrWpId:装置ID
    '      ：lstrOvertakeLotId:追越制限違反ﾛｯﾄID
    '戻り値：True:成功、False:失敗
    '作成日：2014/11/26 (Wed) 10:56:05 H.Hayashi
    '更新日：
    '備　考：
    Private Function prvblnOvertakeAuthority_Chk(ByVal lstrWpId As String, _
                                                 ByVal lstrOvertakeLotId As String) As Boolean
        
        Dim lstrFunctionID          As String       '機能ID
        Dim lstrActionID            As String       'ｱｸｼｮﾝID
        Dim lstrEmpName             As String       '作業者名
        Dim lblnAns                 As Boolean      '戻り値格納用
        Dim llngMsgAns              As Integer      'Msg戻り値
        Dim lstrOvertakeStatus      As String       '追越制限違反状態(0:追越制限違反無し、1:追越制限違反有り)

        Try
            
            '@戻り値を初期化する
            prvblnOvertakeAuthority_Chk = False

            '@=======================
            '@ 無機ODF追越制限違反確認
            '@=======================
            lblnAns = pubblnOvertake_Sel(CMstrlot_chkovertake, _
                                         lblLotID.Text, _
                                         lstrWpId, _
                                         lstrOvertakeLotId, _
                                         lstrOvertakeStatus)
            '@結果判定
            If lblnAns = False Then
                    
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdLotStartClick)
                Exit Function
            Else
                
                '@追越制限違反が存在するか確認

                    
                 If lstrOvertakeStatus = CPstrOvertakeNg Then
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdLotStartClick)
                            
                    '@表示ﾒｯｾｰｼﾞ
                    '@「"<TRM133W>$$ロット[%1]は作業開始前ですが、$本ロットを[%2]致しますか。"」のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0133, lstrOvertakeLotId, "作業開始")
                    llngMsgAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                                  
                                    
                    '@ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdSelectMaterial)

                    '@要求確認(いいえ選択時は処理終了)
                    If llngMsgAns = vbNo Then

                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmdLotStartClick)
                        Exit Function

                    End If
                Else
                    
                    '@戻り値に"True:権限ﾁｪｯｸOK"をｾｯﾄ
                    prvblnOvertakeAuthority_Chk = True
            
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdLotStartClick)
                    Exit Function
                            
                End If
                
            End If

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0020.Instance.ShowDialog(Me)
            frmxxCM0020.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Function
            End If
                
            '@実行権限の処理を追加
            lstrFunctionID = CMstrLocalMenuKey          '機能ID：EN0030(作業開始)
            lstrActionID = CPstrOvertake                'ｱｸｼｮﾝID：ロット追越制限
            lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名：NULL
               
            '@=======================
            '@　実行権限ﾁｪｯｸ処理
            '@=======================
            lblnAns = pubAuthority_Chk(lstrFunctionID, _
                                       lstrActionID, _
                                       pstrUserID, _
                                       pstrUserName, _
                                       pstrSBID)

            '@通信結果判定
            If lblnAns = False Then
                '@結果：異常の場合

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, pstrUserName, lstrActionID)
                '@ﾒｯｾｰｼﾞ表示："<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdLotStartClick)
            
                Exit Function
            End If

            '@戻り値に"True:権限ﾁｪｯｸOK"をｾｯﾄ
            prvblnOvertakeAuthority_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnOvertakeAuthority_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    ''' <summary>
    ''' ODF貼り合わせ装置の専用チェック
    ''' 作業開始確定時にODF予約情報と貼り合わせWFを比較して、異なる場合はユーザー判断
    ''' </summary>
    ''' <returns></returns>
    Private Function prvblnEqTypeODF_Chk() As Boolean
        
        Dim lblnAns As Boolean
        Dim lintAns As Integer

        Try
            prvblnEqTypeODF_Chk = False

            'レスポンス開始
            Call pubResponseStart(CMstrFormName, CMstrCmdLotStartClick)

            Dim ltypChkOdfReserve As New List(Of typChkOdfReserve)
            Dim lstrResult As String = vbNullString
            '予約検索(引数:TFT_LOT/CF_LOT/TFT_WF/CF_WF)
            lblnAns = pubblnChkOdfReserve(CMstrasm_chkodfreserveVer, vbNullString, vbNullString, txtCarrier.Text, txtCFCarrier.Text, lstrResult, ltypChkOdfReserve)

            If lblnAns = False Then
                'レスポンス中止
                Call pubResponseCancel(CMstrFormName, CMstrCmdLotStartClick)
                Exit Function
            End If

            'レスポンス終了
            Call publngResponseEnd(CMstrFormName, CMstrCmdLotStartClick)

            '予約情報と異なる
            If lstrResult = CMstrOdfReserveChk_NG Then
                '<TRM176W>$$[%1]と異なります。$処理を継続しましすか?"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0176, "ODF予約情報")
                lintAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                '「いいえ」選択
                If lintAns = vbNo Then
                    Exit Function
                End If

                '予約情報なし
            ElseIf lstrResult = CMstrOdfReserveChk_Empty Then

                '2021/11/18 yoneyama 以下はコメントアウト(そもそも予約をしていない場合は何もしない)

                ''"<TRM175W>$$[%1]がありませんでした、$処理を継続しましすか?"
                'pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0175, "ODF予約情報")
                'lintAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                ''「いいえ」選択
                'If lintAns = vbNo Then
                '    Exit Function
                'End If
            End If

            prvblnEqTypeODF_Chk = True
            
            Exit Function

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnEqTypeODF_Chk"
                .strErrMessage = vbNullString
            End With

            Call pubOnError_Proc()

        End Try
    End Function

    ''' <summary>
    ''' 無機マスクセット装置の専用チェック
    ''' 作業開始確定時にODF予約情報の有無を確認、情報が無い場合はユーザー判断
    ''' TFT/CFの片方でしか作業開始しないので、ODF予約情報の内容までは(TFT/CF対)、ここでは不明なのでデータ有無で判断
    ''' </summary>
    ''' <returns></returns>
    Private Function prvblnMukiMask_Chk() As Boolean
        
        Dim lblnAns As Boolean
        Dim lintAns As Integer

        Try
            prvblnMukiMask_Chk = False

            'レスポンス開始
            Call pubResponseStart(CMstrFormName, "prvblnMukiMask_Chk")

            Dim ltypOdfReserveInfo = New List(Of typOdfReserveInfo)
            
            '引数(LOTID(TFT/CFのどちらでも可),WFID(ここでは指定なし))
            lblnAns = pubblnOdfReserveInfo_Sel(CPstrasm_odfreservereinfoVer, lblLotID.Text, vbNullString, ltypOdfReserveInfo)

            If lblnAns = False Then
                'レスポンス中止
                Call pubResponseCancel(CMstrFormName, "prvblnMukiMask_Chk")
                Exit Function
            End If

            'レスポンス終了
            Call publngResponseEnd(CMstrFormName, "prvblnMukiMask_Chk")

            If ltypOdfReserveInfo.Count = 0 Then
                '"<TRM175W>$$[%1]がありませんでした、$処理を継続しましすか?"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0175, "ODF予約情報")
                lintAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                '「いいえ」選択
                If lintAns = vbNo Then
                    Exit Function
                End If
            End If

            prvblnMukiMask_Chk = True
            
            Exit Function

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnMukiMask_Chk"
                .strErrMessage = vbNullString
            End With

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


    '関数名：prvSetFocus
    '機　能：フォーム専用のフォーカスセット追加処理
    '引　数：lctlNext：フォーカス先コントロールオブジェクト
    '      ：laryCallers：呼出し元コントロールの配列
    '戻り値：なし
    '作成日：2020/03/12 (Thu) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub prvSetFocus(ByVal lctlNext As Control, ParamArray ByVal laryCallers As Control())

        Dim ldicMatchHandler        As List(Of Tuple(Of Control, CancelEventHandler))
        Dim ldicCtrlToHandler       As Dictionary(Of Control, CancelEventHandler)

        'NSYS コントロールとValidateハンドラーの組み合わせ定義
        ldicCtrlToHandler = New Dictionary(Of Control, CancelEventHandler) From { _
                { txtCarrier, AddressOf txtCarrier_Validate }, _
                { txtLoaderCarrier, AddressOf txtLoaderCarrier_Validate }, _
                { txtCFCarrier, AddressOf txtCFCarrier_Validate } _
            }
        ldicMatchHandler = New List(Of Tuple(Of Control, CancelEventHandler))

        If ActiveControl IsNot Nothing Then
            Dim lblnMatch As Boolean = False
            ' 呼出し元コントロールの配列に ActiveControlが含まれるか
            For Each lctlCaller As Control In laryCallers
                If ActiveControl Is lctlCaller Then
                    lblnMatch = True
                End If
                ' Validateハンドラーコントロールの判定
                If ldicCtrlToHandler.ContainsKey(lctlCaller) = True Then
                    ldicMatchHandler.Add(Tuple.Create(lctlCaller, ldicCtrlToHandler(lctlCaller)))
                End If
            Next

            If lblnMatch = False Then
                ' ActiveControlが呼び出し元と異なる場合、フォーカス移動しない (VB6互換動作)
                Exit Sub
            End If
        End If

        Try
            ' Validateをハンドリングしているコントロールの場合は、ハンドラーをはずす
            For Each lPair As Tuple(Of Control, CancelEventHandler) In ldicMatchHandler
                RemoveHandler lPair.Item1.Validating, lPair.Item2
            Next
            ' フォーカスセット
            pubSetFocus(lctlNext)
        Finally
            ' Validateハンドラーを戻す
            For Each lPair As Tuple(Of Control, CancelEventHandler) In ldicMatchHandler
                AddHandler lPair.Item1.Validating, lPair.Item2
            Next
        End Try

    End Sub

End Class
