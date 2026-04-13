'ﾌｧｲﾙ名：xxEN01A0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：TPAL貼り合わせ登録　メインフォーム
'作成日：2004/08/30 (Mon) 16:44:58 N.Kojima
'更新日：2014/11/25 (Tue) 09:16:51 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01A0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01A0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01A0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01A0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01A0)
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
    '======================================Private===========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2020/03/06 (Fri) 11:35:39 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion                         As String = "08.02"
    Private Const CMstrLocalVersion                         As String = "08.03"
    '@↑2020/03/06 (Fri) 11:35:39 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@Msgﾊﾞｰｼﾞｮﾝ
    '@↓2020/01/15 (Wed) 13:03:04 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_curstateVer                     As String = "03.04"         'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer                      As String = "04.00"         'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 13:03:04 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrlot_tpalcombstartVer                 As String = "03.00"                     'TPAL貼り合わせ登録
    Private Const CMstrlot_tpalcombresultVer                As String = "02.00"                     'TPAL貼り合わせ実績取得
    Private Const CMstrlot_tpalinfoVer                      As String = "01.00"                     '入力TPALﾛｯﾄ情報取得
    Private Const CMstrinv_combabletpalVer                  As String = "01.00"                     'TPAL前(貼り合わせ可能)在庫取得

    '@機能ID
    Private Const CMstrLocalMenuKey                         As String = CPstrKeyEN01A0              'ﾛｰｶﾙﾒﾆｭｰKey

    '@TPAL貼り合わせ実績一覧列設定
    Private Const CMlngvsfUseTpalListColNo                  As Integer = 0                          '№
    Private Const CMlngvsfUseTpalListColCarrierID           As Integer = 1                          'TPALｷｬﾘｱID
    Private Const CMlngvsfUseTpalListColLotID               As Integer = 2                          'TPALﾛｯﾄID
    Private Const CMlngvsfUseTpalListColCoverNum            As Integer = 3                          '貼数
    Private Const CMlngvsfUseTpalListColOutNum              As Integer = 4                          '不良数
    Private Const CMlngvsfUseTpalListColRestNum             As Integer = 5                          '残数
    Private Const CMlngvsfUseTpalListColLotLastUpdate       As Integer = 6                          'TPALﾛｯﾄ最終更新日時(非表示)
    Private Const CMlngvsfUseTpalListColLimitTime           As Integer = 7                          '有効期限(非表示)
    Private Const CMlngvsfUseTpalListColInsertFlag          As Integer = 8                          '登録ﾌﾗｸﾞ(1：登録候補(未登録TPALﾛｯﾄ))(非表示)

    '@TPAL貼り合わせ実績一覧幅設定
    Private Const CMlngvsfUseTpalListWNo                    As Integer = 35                         '№
    Private Const CMlngvsfUseTpalListWCarrierID             As Integer = 115                        'TPALｷｬﾘｱID
    Private Const CMlngvsfUseTpalListWLotID                 As Integer = 122                        'TPALﾛｯﾄID
    Private Const CMlngvsfUseTpalListWCoverNum              As Integer = 90                         '貼数
    Private Const CMlngvsfUseTpalListWOutNum                As Integer = 90                         '不良数
    Private Const CMlngvsfUseTpalListWRestNum               As Integer = 90                         '残数
    Private Const CMlngvsfUseTpalListWLotLastUpdate         As Integer = 66                         'TPALﾛｯﾄ最終更新日時(非表示)
    Private Const CMlngvsfUseTpalListWLimitTime             As Integer = 66                         '有効期限(非表示)
    Private Const CMlngvsfUseTpalListWInsertFlag            As Integer = 33                         '登録ﾌﾗｸﾞ(非表示)

    '@TPAL貼り合わせ実績一覧ﾀｲﾄﾙ設定
    Private Const CMstrvsfUseTpalListTNo                    As String = ""                          '№
    Private Const CMstrvsfUseTpalListTCarrierID             As String = "キャリアID"                'TPALｷｬﾘｱID
    Private Const CMstrvsfUseTpalListTLotID                 As String = "TPALロットID"              'TPALﾛｯﾄID
    Private Const CMstrvsfUseTpalListTCoverNum              As String = "貼数"                      '貼数
    Private Const CMstrvsfUseTpalListTOutNum                As String = "不良数"                    '不良数
    Private Const CMstrvsfUseTpalListTRestNum               As String = "残数"                      '残数
    Private Const CMlngvsfUseTpalListTLotLastUpdate         As String = "最終更新日時"              'TPALﾛｯﾄ最終更新日時(非表示)
    Private Const CMlngvsfUseTpalListTLimitTime             As String = "有効期限"                  '有効期限(非表示)
    Private Const CMlngvsfUseTpalListTInsertFlag            As String = "登録ﾌﾗｸﾞ"                  '登録ﾌﾗｸﾞ(非表示)

    '@ｸﾞﾘｯﾄ共通設定
    Private Const CMlngvsfGridTitleRow                      As Integer = 0                          'ﾀｲﾄﾙ行(列)
    Private Const CMlngvsfGridTitleCol                      As Integer = 0                          'ﾀｲﾄﾙ行(行)
    Private Const CMlngvsfSlotFontSize                      As Integer = 12                         'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfGridHHeight                       As Integer = 27                         'ﾍｯﾀﾞｰの高さ
    Private Const CMlngvsfGridHeight                        As Integer = 38                         '1ｽﾛｯﾄの高さ
    Private Const CMlngNoSelect                             As Integer = -1                         'ｸﾞﾘｯﾄ行未選択
    Private Const CMstrGridFontName                         As String = "ＭＳ ゴシック"             'ｸﾞﾘｯﾄﾞのﾌｫﾝﾄ名
    Private Const CMlngvsfGridRows                          As Integer = 8                          '1ﾍﾟｰｼﾞの最大表示行数

    '@その他の定数
    Private Const CMstrCoverFlagFinish                      As String = "1"                         '貼り合わせ済みﾌﾗｸﾞ

    '@ﾚｽﾎﾟﾝｽ計測用
    Private Const CMstrCmdNowListClick                      As String = "cmdNowList_Click"          'ｲﾍﾞﾝﾄ名定数(最新取得)
    Private Const CMstrCmdClearClick                        As String = "cmdClear_Click"            'ｲﾍﾞﾝﾄ名定数(取消)
    Private Const CMstrTxtCarrierValidate                   As String = "txtCarrier_Validate"       'ｲﾍﾞﾝﾄ名定数(TFTｷｬﾘｱ確定)
    Private Const CMstrTxtTPALCarrierValidate               As String = "txtTPALCarrier_Validate"   'ｲﾍﾞﾝﾄ名定数(TPALｷｬﾘｱ確定)
    Private Const CMstrCmdRegistClick                       As String = "cmdRegist_Click"           'ｲﾍﾞﾝﾄ名定数(貼り合わせ登録確定)
    Private Const CMstrcmdTreatChipClick                    As String = "cmdTreatChip_Click"        'ｲﾍﾞﾝﾄ名定数(ﾁｯﾌﾟ状態変更)

    '@色宣言
    Private Const CMlngEnableFalseColor                     As Integer = &H80000003                 '濃い灰色(使用不可)
    Private Const CMlngPaleEnableFalseColor                 As Integer = &H80000004                 '灰色(使用不可)
    Private Const CMlngEnableTrueColor                      As Integer = &H80000005                 '白(使用可)
    Private Const CMlngBlackColor                           As Integer = &H80000008                 '黒

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private===========================================
    Private mtypChgSort                                     As ChgSort                              'ｿｰﾄ保持用
    Private mtypCoverCompLot                                As CoverCompLot                         'TPAL貼り合わせ実績構造体
    Private mtypTpalCombStart                               As TpalCombStart                        'TPAL貼り合わせ登録構造体
    Private mstrCarrierID                                   As String                               'TFTｷｬﾘｱID退避領域
    Private mstrLotLastUpdate                               As String                               'TFTﾛｯﾄ最終更新日時
    Private mstrCompableChip                                As String                               '貼り合せ可能ﾁｯﾌﾟ数退避領域
    Private mstrTpalCarrierID                               As String                               'TPALｷｬﾘｱID退避領域
    Private mstrTpalLotLastUpdate                           As String                               'TPALﾛｯﾄ最終更新日時
    Private mstrChipOutQuantity                             As String                               '不良数退避領域
    Private mstrChipRestQuantity                            As String                               '残数退避領域
    Private mblnActivateFlag                                As Boolean                              'ﾌｫｰﾑｱｸﾃｨﾌﾞ判定用(True：ｱｸﾃｨﾌﾞ、False：非ｱｸﾃｨﾌﾞ)
    Private mblnErrFlag                                     As Boolean                              'ｴﾗｰ判定用ﾌﾗｸﾞ(True：ｴﾗｰあり、False：ｴﾗｰなし)
    Private mblnCancelFlag                                  As Boolean                              'ｷｬﾝｾﾙﾌﾗｸﾞ(True：処理をｷｬﾝｾﾙする、False：初期値)
    Private mblnCombAbleTpalFlag                            As Boolean                              'TPAL貼り合わせ可能在庫有無判定ﾌﾗｸﾞ(True：初期値(あり)、False：なし)
    Private mblnResponseFlag                                As Boolean                              'ﾚｽﾎﾟﾝｽ中判定ﾌﾗｸﾞ(True：ﾚｽﾎﾟﾝｽ測定中、False：ﾚｽﾎﾟﾝｽ未測定)
    Private mblnFormLoadFlg                                 As Boolean                              '引継ぎ表示ﾌﾗｸﾞ(ﾌｫｰﾑﾛｰﾄﾞﾛｰｶﾙﾌﾗｸﾞ)
    Private buttonProcessing                                As Boolean                              'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                        As Boolean                              'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                                 As Boolean                              'NSYS WindowCloseフラグ
    Private vsfUseTpalListRowBeforeSort                     As Integer                              'NSYS ｿｰﾄ時の選択行退避

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
        pubVsfMouseWheelManager_Set(vsfUseTpalList, cmdUp, cmdDown)

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
    '作成日：2004/08/30 (Mon) 14:43:12 N.Kojima
    '更新日：2009/10/14 (Wed) 10:19:05 N.Kojima
    '備　考：
    '　　　：2004/10/19 (Tue) 12:15:16 N.Kasai      0件ﾒｯｾｰｼﾞ追加
    '　　　：2004/11/04 (Thu) 13:05:05 T.Kitagawa   子画面起動の場合はForm_Loadﾌﾗｸﾞが常に正常になってしまうので、単体起動のみ設定するように変更
    '　　　：2004/12/27 (Mon) 08:37:44 S.Deguchi    初期化処理の前にｷｬﾘｱID欄の初期化を追加
    '　　　：2005/07/25 (Mon) 10:16:19 N.Kojima     機能改造に伴い、大幅修正(削除)。ﾕｰｻﾞ要望№0061
    '　　　：2005/10/26 (Wed) 15:43:55 S.Deguchi    不具合№2404の対応で機能ﾊﾞｰｼﾞｮﾝ判定処理修正
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub Form_Load()

        Dim lblnAns         As Boolean      '戻り値

        Try

            '@=======================
            '@ 機能ﾊﾞｰｼﾞｮﾝ判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN01A0, CMstrLocalVersion)

            '@機能ﾊﾞｰｼﾞｮﾝ判定処理結果が"False：不一致"か
            If lblnAns = False Then

                Exit Sub
            End If

            '@ﾌｫｰﾑｱｸﾃｨﾌﾞﾌﾗｸﾞを初期化
            mblnActivateFlag = False

            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            '@=======================
            '@ 各種初期化処理
            '@=======================
            Call prvFrmxxEN01A0_Init()          'TFTﾛｯﾄ(ｷｬﾘｱ)情報の初期化
            Call prvCombAbleTpalInfo_Init()     'TPAL貼り合わせ可能在庫情報の初期化 ⇒仕掛前ｶｾｯﾄﾌﾚｰﾑ
            Call prvTpalInfo_Init()             'TPALﾛｯﾄ情報の初期化               ⇒仕掛前ｶｾｯﾄﾌﾚｰﾑ
            Call prvVsfUseTpalList_Init()       'TPAL貼り合わせ一覧の初期化         ⇒登録済ｶｾｯﾄﾌﾚｰﾑ

            '@ﾌｫｰﾑ起動区分が"False：単独起動"か
            If pblnfrmxxEN01A0Kbn = False Then

                '@[ｷｬﾘｱID(TFT側)]ﾃｷｽﾄの制御(有効化)
                With txtCarrier

                    .Enabled = True                             '有効
                    .Locked = False                             'ｱﾝﾛｯｸ
                    .TabStop = True                             'ﾌｫｰｶｽ取得対象にする
                    .BackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor)    '背景色：白
                    .GotBackColor = ColorTranslator.FromWin32(CMlngEnableTrueColor) 'ﾌｫｰｶｽ時の背景色：白
                    .GotHighLight = True                        'ﾊｲﾗｲﾄ：あり
                    .Text = vbNullString                        '表示：NULL
                End With

            Else
                '@子画面起動の場合

                '@[ｷｬﾘｱID(TFT側)]ﾃｷｽﾄの制御(無効化)
                With txtCarrier

                    .Enabled = True                             '有効
                    .Locked = True                              'ﾛｯｸ
                    .TabStop = False                            'ﾌｫｰｶｽ取得対象にしない
                    .BackColor = SystemColors.ControlLight      '背景色：ｸﾞﾚｰ
                    .GotBackColor = SystemColors.ControlLight   'ﾌｫｰｶｽ時の背景色：ｸﾞﾚｰ
                    .GotHighLight = False                       'ﾊｲﾗｲﾄ：なし
                    .Text = ptypCfkiRenkeiInfo.strCarrierId     '表示：引継ぎｷｬﾘｱID
                    .Text = ptypCommonInfo.strCarrierId         '表示：引継ぎｷｬﾘｱID(こちらに値がある場合は優先)
                End With

                '@=======================
                '@ ｷｬﾘｱID(TFT側)のValidate処理
                '@=======================
                RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                Call txtCarrier_Validate(txtCarrier,new CancelEventArgs(True))
                AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate

                '@無機ﾌﾗｸﾞが"0：有機ﾛｯﾄ"、かつTPAL区分が"NULL：指定なし"か
                If ptypLotprestate.strVaFlag = CPstrZero And _
                    ptypLotprestate.strTpalClass = vbNullString Then

                    '@貼り合わせ可能在庫(TPALﾛｯﾄ)の数量が"0"か
                    If mstrCompableChip = CPstrZero Then

                        '@引継ぎ情報表示済みﾌﾗｸﾞに"True：表示済"をｾｯﾄ
                        mblnFormLoadFlg = True

                        '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"False：起動処理失敗"をｾｯﾄ
                        pblnFormLoad = False
                        Exit Sub
                    End If

        '@↓2009/10/15 (Thu) 19:14:11 N.Kojima **************************************************

                Else
                    '@無機ﾌﾗｸﾞが"1：無機ﾛｯﾄ"、またはTPAL区分が"NULL以外：指定あり"か

                    '@TPAL貼り合わせ可能在庫有無判定ﾌﾗｸﾞが"False：なし"か
                    If mblnCombAbleTpalFlag = False Then
                        Exit Sub
                    End If

        '@↑2009/10/15 (Thu) 19:14:11 N.Kojima **************************************************

                End If

        '@↓2009/10/15 (Thu) 19:17:01 N.Kojima **************************************************
        '        Exit Sub
        '@↑2009/10/15 (Thu) 19:17:01 N.Kojima **************************************************

            End If

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"True：起動処理成功"をｾｯﾄ
            pblnFormLoad = True

            '@閉じるﾎﾞﾀﾝはﾌｫｰｶｽﾛｽﾄ時にﾁｪｯｸを行わない設定にする
            cmdClose.CausesValidation = False

            '@引継ぎ情報表示済みﾌﾗｸﾞに"False：未表示"をｾｯﾄ
            mblnFormLoadFlg = False

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
    '機　能：ﾌｫｰﾑ　ｱｸﾃｨﾌﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/01 (Wed) 09:55:00 N.Kojima
    '更新日：2009/10/14 (Wed) 10:26:36 N.Kojima
    '備　考：
    '　　　：2004/11/22 (Mon) 10:15:12 S.Deguchi    Form_Loadの処理で行っているのでここで行う必要なし⇒削除(ﾌﾗｸﾞの判定は残す)
    '　　　：2005/01/08 (Sat) 13:17:16 S.Deguchi    装置別ﾛｯﾄ一覧からの引継ぎで表示するのは,ｱﾝﾛｰﾀﾞｰｷｬﾘｱとする
    '　　　：2005/06/07 (Tue) 15:12:51 N.Kojima     Loader/Unloader対応(不具合№829)
    '　　　：2005/07/21 (Thu) 16:13:37 N.Kojima     機能改造に伴い、大幅修正(削除)。ﾕｰｻﾞ要望№0061
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            '@ﾌｫｰﾑｱｸﾃｨﾌﾞﾌﾗｸﾞに"True：ｱｸﾃｨﾌﾞ"をｾｯﾄ
            mblnActivateFlag = True

            '@引継ぎ情報表示済みﾌﾗｸﾞが"True：表示済"か
            '@ ※FormLoad後、最初の1回しか処理しない
            If mblnFormLoadFlg = True Then

                Exit Sub
            End If

            '@引継ぎ情報表示済みﾌﾗｸﾞに"True：表示済"をｾｯﾄ
            mblnFormLoadFlg = True


            '@-----------------------
            '@ ｷｬﾘｱID(TFT側)の設定
            '@-----------------------
            With ptypCommonInfo

                '@引継ぎﾛｰﾀﾞｰｷｬﾘｱIDがNULL以外か
                If .strCarrierId <> vbNullString Then

                    '@引継ぎｱﾝﾛｰﾀﾞｰｷｬﾘｱIDがNULL以外か
                    If .strToCarrierId <> vbNullString Then
                        '@引継ぎｱﾝﾛｰﾀﾞｷｬﾘｱが指定されている場合

                        '@ﾛｯﾄ状態が「後処理」か
                        If lblStatus.Text = CPstrAfterProgressSt Then

                            '@[ｷｬﾘｱID(TFT側)]に引継ぎｱﾝﾛｰﾀﾞｰｷｬﾘｱIDをｾｯﾄ
                            txtCarrier.Text = .strToCarrierId
                        Else
                            '@[ｷｬﾘｱID(TFT側)]に引継ぎﾛｰﾀﾞｰｷｬﾘｱIDをｾｯﾄ
                            txtCarrier.Text = .strCarrierId
                        End If
                    Else
                        '@引継ぎｱﾝﾛｰﾀﾞｷｬﾘｱが指定されていない場合

                        '@[ｷｬﾘｱID(TFT側)]に引継ぎﾛｰﾀﾞｰｷｬﾘｱIDをｾｯﾄ
                        txtCarrier.Text = .strCarrierId
                    End If

                    '@=======================
                    '@ ｷｬﾘｱIDﾃｷｽﾄのValidate処理
                    '@=======================
                    'NSYS 初回時はキャリアID（TFT側）をActiveとする
                    ActiveControl = txtCarrier
                    RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                    Call txtCarrier_Validate(txtCarrier,new CancelEventArgs(True))
                    AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate

                Else
                    '@引継ぎ(ﾛｰﾀﾞｰ)ｷｬﾘｱIDがNULLの場合

                    '@一応、引き継ぎｷｬﾘｱIDを初期化
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
    '機　能：ﾌｫｰﾑ　ｷｰﾀﾞｳﾝ時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ値
    '戻り値：なし
    '作成日：2004/08/30 (Mon) 17:24:11 N.Kojima
    '更新日：2009/10/14 (Wed) 10:19:05 N.Kojima
    '備　考：
    '　　　：2005/07/21 (Thu) 16:53:37 N.Kojima     機能改造に伴い、大幅修正(削除)。ﾕｰｻﾞ要望№0061
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            '@=======================
            '@ ｸﾞﾘｯﾄﾞｷｰ制御処理(ｸﾞﾘｯﾄﾞ共通処理：上下ｽｸﾛｰﾙﾎﾞﾀﾝの制御)
            '@=======================
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfUseTpalList, cmdUP, cmdDown)

            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name

                '@〓 [ｷｬﾘｱID(TFT側)]ﾃｷｽﾄ 〓
                Case txtCarrier.Name

                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode

                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return

                            '@=======================
                            '@ ｷｬﾘｱID(TFT側)ﾃｷｽﾄのValidate処理
                            '@=======================
                            RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                            Call txtCarrier_Validate(txtCarrier,New CancelEventArgs(False))
                            AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate

                    End Select


                '@〓 [ｷｬﾘｱID(TPAL側)]ﾃｷｽﾄ 〓
                Case txtTPALCarrier.Name

                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode

                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return

                            '@=======================
                            '@ ｷｬﾘｱID(TPAL側)ﾃｷｽﾄのValidate処理
                            '@=======================
                            RemoveHandler txtTPALCarrier.Validating,AddressOf txtTPALCarrier_Validate
                            Call txtTPALCarrier_Validate(txtTPALCarrier,New CancelEventArgs(False))
                            AddHandler txtTPALCarrier.Validating,AddressOf txtTPALCarrier_Validate

                    End Select


                '@〓 [不良数]ﾃｷｽﾄ 〓
                Case txtChipOutQuantity.Name

                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode

                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return

                            '@=======================
                            '@ 不良数ﾃｷｽﾄのValidate処理
                            '@=======================
                            RemoveHandler txtChipOutQuantity.Validating,AddressOf txtChipOutQuantity_Validate
                            Call txtChipOutQuantity_Validate(txtChipOutQuantity,New CancelEventArgs(False))
                            AddHandler txtChipOutQuantity.Validating,AddressOf txtChipOutQuantity_Validate

                            '@ｷｬﾝｾﾙﾌﾗｸﾞが"False：初期値"か
                            If mblnCancelFlag = False Then

                                '@[残数]ﾃｷｽﾄが有効か
                                If txtChipRestQuantity.Enabled = True Then

                                    '@[残数]ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
                                    Call pubSetFocus(txtChipRestQuantity)
                                End If

                                '@ｷｬﾝｾﾙﾌﾗｸﾞに"True：処理をｷｬﾝｾﾙする"をｾｯﾄ
                                mblnCancelFlag = True
                            End If

                    End Select


                '@〓 [残数]ﾃｷｽﾄ 〓
                Case txtChipRestQuantity.Name

                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode

                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return

                            '@=======================
                            '@ 残数ﾃｷｽﾄのValidate処理
                            '@=======================
                            RemoveHandler txtChipRestQuantity.Validating,AddressOf txtChipRestQuantity_Validate
                            Call txtChipRestQuantity_Validate(txtChipRestQuantity,New CancelEventArgs(False))
                            AddHandler txtChipRestQuantity.Validating,AddressOf txtChipRestQuantity_Validate

                            '@ｷｬﾝｾﾙﾌﾗｸﾞが"False：初期値"か
                            If mblnCancelFlag = False Then

                                '@[">"]ﾎﾞﾀﾝが有効か
                                If cmdMove.Enabled = True Then

                                    '@[">"]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                                    Call pubSetFocus(cmdMove)
                                Else
                                    '@[">"]ﾎﾞﾀﾝが無効な場合

                                    '@[不良数]がNULLか
                                    If txtChipOutQuantity.Text = vbNullString Then

                                        '@[">"]ﾎﾞﾀﾝを無効にする
                                        cmdMove.Enabled = False

                                        '@[不良数]ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
                                        Call pubSetFocus(txtChipOutQuantity)
                                    Else
                                        '@[不良数]がNULL以外か

                                        '@[取消]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                                        Call pubSetFocus(cmdClear)
                                    End If
                                End If

                                '@ｷｬﾝｾﾙﾌﾗｸﾞに"True：処理をｷｬﾝｾﾙする"をｾｯﾄ
                                mblnCancelFlag = True

                            End If

                    End Select


                '@〓 その他 〓
                Case Else

                    '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                    Select Case e.KeyCode

                        '@〓〓 Enterｷｰ 〓〓
                        Case Keys.Return

                            '@次TabIndexの有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄし、ｷｰｺｰﾄﾞを初期化する
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

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑ　終了時処理
    '引　数：Cancel     ：ｷｬﾝｾﾙ
    '　　　：UnloadMode ：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/08/30 (Mon) 17:27:46 N.Kojima
    '更新日：2009/10/14 (Wed) 10:24:27 N.Kojima
    '備　考：
    '　　　：2004/11/01 (Mon) 16:00:49 T.Kitagawa   閉じるﾎﾞﾀﾝ統合
    '　　　：2005/01/14 (Fri) 11:00:02 H.Wajima     pblnfrmxxEN01A0KbnがpblnfrmxxCM00A0Kbnになっていたので修正。
    '　　　：2005/07/21 (Thu) 17:48:10 N.Kojima     機能改造に伴う、大幅修正(大幅削除)。ﾕｰｻﾞ要望№0061
    '　　　：2007/01/22 (Mon) 15:56:30 N.Kojima     貼合せ要求配列の初期化処理を貼合せ登録Msg送信後に変更。(案件№01734)
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      'ACT開放結果格納

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

            '@各種配列の初期化
            mtypCoverCompLot.typCoverCompLotList = New List(Of CoverCompLotList)   'TPAL貼り合わせ実績情報用
            mtypChgSort.typChgSortList = New List(Of ChgSortList)                  'ｿｰﾄ保持用

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
            pblnFormLoad = False

            '@ﾌｫｰﾑ起動区分が"True：子画面起動"か
            If pblnfrmxxEN01A0Kbn = True Then
                '@子画面起動の場合

                '@ﾌｫｰﾑ起動区分を初期化
                pblnfrmxxCM00A0Kbn = False
            Else
                '@単独起動の場合

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

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Change
    '機　能：[ｷｬﾘｱID(TFT側)]ﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/27 (Mon) 08:46:57 S.Deguchi
    '更新日：2009/10/14 (Wed) 10:24:39 N.Kojima
    '備　考：
    '　　　：2005/07/25 (Mon) 13:59:58 N.Kojima     機能改造に伴い、大幅修正(削除)。ﾕｰｻﾞ要望№0061
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change

        Try
            '@=======================
            '@ 各種情報の初期化
            '@=======================
            Call prvFrmxxEN01A0_Init()          'TFTﾛｯﾄ(ｷｬﾘｱ)情報の初期化
            Call prvCombAbleTpalInfo_Init(True) 'TPAL貼り合わせ可能在庫情報の初期化     ⇒仕掛前ｶｾｯﾄﾌﾚｰﾑ
            Call prvTpalInfo_Init()             'TPALﾛｯﾄ情報の初期化                   ⇒仕掛前ｶｾｯﾄﾌﾚｰﾑ
            Call prvVsfUseTpalList_Init()       'TPAL貼り合わせ一覧の初期化         　　⇒登録済ｶｾｯﾄﾌﾚｰﾑ

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrier_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Validate
    '機　能：[ｷｬﾘｱID(TFT側)]ﾃｷｽﾄ　入力確定時処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/30 (Mon) 17:57:39 N.Kojima
    '更新日：2009/10/14 (Wed) 10:24:43 N.Kojima
    '備　考：
    '　　　：2004/10/19 (Tue) 10:32:28 N.Kasai      0件ﾒｯｾｰｼﾞｺﾒﾝﾄｱｳﾄ
    '　　　：2004/11/04 (Thu) 13:08:20 T.Kitagawa   Form_Loadフラグ設定処理を追加
    '　　　：2004/11/22 (Mon) 10:42:38 S.Deguchi    使用枚数欄と不良枚数欄,最新取得ﾎﾞﾀﾝ処理を追加
    '　　　：2004/12/07 (Tue) 09:15:06 N.Kojima     処理区分を"1N"で送信するように修正(不具合№157)
    '　　　：2004/12/27 (Mon) 09:22:52 S.Deguchi    状態判別を追加
    '　　　：2005/01/07 (Fri) 14:12:53 S.Deguchi    貼り合わせ済み判別処理を追加
    '　　　：2005/01/13 (Thu) 12:59:46 S.Deguchi    貼り合わせ済み判別処理にEQ_TYPEの判別も追加
    '　　　：2005/07/25 (Mon) 11:44:08 N.Kojima     機能改造に伴い、大幅修正(削除)。ﾕｰｻﾞ要望№0061
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim lblnAns                 As Boolean      '結果取得(True:正常,False:異常)

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ判定ﾌﾗｸﾞの初期化
            mblnResponseFlag = False

            '@-----------------------
            '@ ｷｬﾘｱ関連ﾁｪｯｸ
            '@-----------------------
            '@[ｷｬﾘｱID(TFT側)]がNULLか
            If Trim(txtCarrier.Text) = vbNullString Then

                '@ﾌｫｰﾑｱｸﾃｨﾌﾞﾌﾗｸﾞが"True：ｱｸﾃｨﾌﾞ"か
                If mblnActivateFlag = True Then

                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = txtCarrier.Name Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If

                Exit Sub
            End If

            '@入力ｷｬﾘｱが前回入力ｷｬﾘｱと同じか
            If mstrCarrierID = txtCarrier.Text Then

                '@ﾌｫｰﾑｱｸﾃｨﾌﾞﾌﾗｸﾞが"True：ｱｸﾃｨﾌﾞ"か
                If mblnActivateFlag = True Then

                    '@[ｷｬﾘｱID(TPAL側)]ﾃｷｽﾄが有効か
                    If txtTPALCarrier.Enabled = True Then

                        '@[ｷｬﾘｱID(TPAL側)]ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
                        If ActiveControl.Name = txtCarrier.Name Then
                            Call pubSetFocus(txtTPALCarrier)
                        End if
                    Else
                        '@[ｷｬﾘｱID(TPAL側)]ﾃｷｽﾄが無効な場合
                        
                        '@[閉じる]ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                        If ActiveControl.Name = txtCarrier.Name Then
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                End If

                Exit Sub
            End If

            '@ｷｬﾘｱIDの桁数が6桁未満か
            If txtCarrier.NowByte < txtCarrier.ChrMaxByte Then

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"<TRM07W>$$キャリアIDは6桁で入力してください。"のﾒｯｾｰｼﾞ表示
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@[ｷｬﾘｱID(TFT側)]にﾌｫｰｶｽ保持
                e.Cancel = True
                Exit Sub
            End If


            '@-----------------------
            '@ ﾛｯﾄ情報取得(TFT側)
            '@-----------------------
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, CMstrTxtCarrierValidate)

            '@ﾚｽﾎﾟﾝｽ判定ﾌﾗｸﾞに"True：ﾚｽﾎﾟﾝｽ計測中"をｾｯﾄ
            mblnResponseFlag = True

            '@=======================
            '@ ﾛｯﾄ現在状態取得(処理区分:1N=TPAL)
            '@=======================
            lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                            CPstrCD1N, _
                                            txtCarrier.Text, _
                                            ptypLotprestate)

            '@ﾚｽﾎﾟﾝｽ判定ﾌﾗｸﾞに"False：ﾚｽﾎﾟﾝｽ未計測"をｾｯﾄ
            mblnResponseFlag = False

            '@ﾛｯﾄ現在状態取得結果が"True：取得成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, CMstrTxtCarrierValidate)

                With ptypLotprestate

                    '@EQ_TYPE="4：TPAL装置"か
                    If .strEqType = CPstrEqTypeTPAL Then

                        '@貼り合わせ完了ﾌﾗｸﾞが"1：完了"か
                        If .strCoverFlag = CMstrCoverFlagFinish Then

                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003V, .strLotID)
                            '@"<TRM3VI>$$貼り合わせ登録済みのロットです。ロット[%1]"のﾒｯｾｰｼﾞ表示
                            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)

                            '@[ｷｬﾘｱID(TFT側)]ﾃｷｽﾄにﾌｫｰｶｽ保持
                            e.Cancel = True

                            '@無機ﾌﾗｸﾞが"1：無機"以外、かつTPAL区分が"NULL：指定なし"か
                            If ptypLotprestate.strVaFlag <> CPstrOne And _
                                ptypLotprestate.strTpalClass = vbNullString Then

                                '@有機ﾛｯﾄ、またはTPAL指定ありの場合は処理終了
                                Exit Sub
                            End If
                        End If
                    Else
                        '@EQ_TYPEが"4：TPAL装置"以外の場合

                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004P, .strCarrierId, .strLotID)
                        '@"<TRM4PW>$$該当工程が、TPAL貼り合わせ工程ではないため、TPAL貼り合わせ登録できません。$キャリア[%1] ロット[%2]"のﾒｯｾｰｼﾞ表示
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@[ｷｬﾘｱID(TFT側)]ﾃｷｽﾄにﾌｫｰｶｽ保持
                        e.Cancel = True
                        Exit Sub
                    End If
                End With
            Else
                '@ﾛｯﾄ現在状態取得結果が"False：取得失敗"の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, CMstrTxtCarrierValidate)

                '@[最新取得]ﾎﾞﾀﾝを無効にする
                cmdNowList.Enabled = False

                '@[ｷｬﾘｱID(TFT側)]ﾃｷｽﾄにﾌｫｰｶｽ保持
                e.Cancel = True
                Exit Sub
            End If


            '@-----------------------
            '@ ﾛｯﾄ情報取得(TPAL側)
            '@-----------------------
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, CMstrTxtCarrierValidate)

            '@ﾚｽﾎﾟﾝｽ判定ﾌﾗｸﾞに"True：ﾚｽﾎﾟﾝｽ計測中"をｾｯﾄ
            mblnResponseFlag = True

            '@=======================
            '@ TPALﾛｯﾄ貼り合わせ実績取得
            '@=======================
            lblnAns = pubblnLotTpalCombResult_Sel(CMstrlot_tpalcombresultVer, _
                                                  ptypLotprestate.strLotID, _
                                                  ptypLotprestate.strVaFlag, _
                                                  ptypLotprestate.strTpalClass, _
                                                  mtypCoverCompLot)

            '@ﾚｽﾎﾟﾝｽ判定ﾌﾗｸﾞに"False：ﾚｽﾎﾟﾝｽ未計測"をｾｯﾄ
            mblnResponseFlag = False

            '@TPALﾛｯﾄ貼り合わせ実績取得結果が"True：取得成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, CMstrTxtCarrierValidate)

                '@貼り合わせTPALﾛｯﾄが無いか
                If mtypCoverCompLot.lngCoverCompLotListCnt < 0 Then

                    '@[ｷｬﾘｱID(TFT側)]ﾃｷｽﾄにﾌｫｰｶｽ保持
                    e.Cancel = True
                    Exit Sub
                End If
            Else
                '@TPALﾛｯﾄ貼り合わせ実績取得結果が"False：取得失敗"か

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, CMstrTxtCarrierValidate)

                '@[ｷｬﾘｱID(TFT側)]ﾃｷｽﾄにﾌｫｰｶｽ保持
                e.Cancel = True
                Exit Sub
            End If


            '@取得日時を表示
            lblNowDate.Text = Format$(Now(), CPstrDateFormat)

            '@=======================
            '@ ﾛｯﾄ情報(TFT側)表示処理
            '@=======================
            Call prvFrmxxEN01A0_Disp()

            '@=======================
            '@ TPAL貼り合わせ実績一覧表示処理
            '@=======================
            Call prvVsfUseTpalList_Disp()

            '@=======================
            '@ [最新取得]ﾎﾞﾀﾝ押下処理
            '@ ※TPAL貼り合わせ可能在庫情報取得
            '@=======================
            Call cmdNowList_Click(sender,e)

            '@TPAL貼り合わせ可能在庫有無判定ﾌﾗｸﾞが"False：無し"か
            If mblnCombAbleTpalFlag = False Then

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, CMstrTxtCarrierValidate)

                '@[ｷｬﾘｱID(TFT側)]ﾃｷｽﾄにﾌｫｰｶｽ保持
                e.Cancel = True
                Exit Sub
            End If


            '@TPALｷｬﾘｱIDﾃｷｽﾄを有効に
            txtTPALCarrier.Enabled = True

            '@最新取得ﾎﾞﾀﾝを有効に
            cmdNowList.Enabled = True

            '@ﾌｫｰﾑｱｸﾃｨﾌﾞﾌﾗｸﾞがtrueか
            If mblnActivateFlag = True Then
                '@ﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = txtCarrier.Name Then
                    Call pubSetFocus(txtTPALCarrier)
                End If
            End If

            '@ｷｬﾘｱIDを退避領域に
            mstrCarrierID = txtCarrier.Text

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrier_Validate"
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
    '作成日：2004/09/01 (Wed) 09:52:18 N.Kojima
    '更新日：2009/10/14 (Wed) 10:24:35 N.Kojima
    '備　考：
    '　　　：2004/10/19 (Tue) 10:30:37 N.Kasai      0件ﾒｯｾｰｼﾞｺﾒﾝﾄｱｳﾄ
    '　　　：2004/11/02 (Tue) 10:33:17 M.Miura　    移動ﾎﾞﾀﾝの非活性化
    '　　　：2004/11/22 (Mon) 17:29:27 S.Deguchi    最新取得時の初期化で残数にはChip数+不良ﾁｯﾌﾟ数をｾｯﾄする
    '　　　：2005/07/21 (Thu) 17:51:56 N.Kojima     機能改造に伴う、大幅修正(大幅削除)。ﾕｰｻﾞ要望№0061
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub cmdNowList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowList.Click

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrTotalLotNum         As String               '合計使用可能TPALﾛｯﾄ数
        Dim lstrTotalChipNum        As String               '合計使用可能TPAL数

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@TPAL貼り合わせ可能在庫有無判定ﾌﾗｸﾞの初期化(True：初期値(有り)、False：無し)
            mblnCombAbleTpalFlag = True

            '@ｷｬﾘｱIDがNULLか
            If txtCarrier.Text = vbNullString Then
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ判定ﾌﾗｸﾞが"False：ﾚｽﾎﾟﾝｽ未測定"か
            If mblnResponseFlag = False Then

                '@ﾚｽﾎﾟﾝｽ測定開始
                Call pubResponseStart(Me.Name, CMstrCmdNowListClick)
            End If

            '@各種ﾗﾍﾞﾙの初期化
            lblNowDate.Text = vbNullString           '情報取得日時
            lblInvTPALLotCnt.Text = vbNullString     '貼り合わせ可能TPALﾛｯﾄ数
            lblInvTPALChipCnt.Text = vbNullString    '貼り合わせ可能TPALﾁｯﾌﾟ数

            '@=======================
            '@ TPAL貼り合わせ可能在庫情報取得
            '@=======================
            lblnAns = pubblnInvCombAbleTpal_Sel(CMstrinv_combabletpalVer, _
                                                ptypLotprestate.strLotID, _
                                                lstrTotalLotNum, _
                                                lstrTotalChipNum)

            '@TPAL貼り合わせ可能在庫情報取得結果が"True：取得成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ判定ﾌﾗｸﾞが"False：ﾚｽﾎﾟﾝｽ未測定"か
                If mblnResponseFlag = False Then

                    '@ﾚｽﾎﾟﾝｽ測定終了
                    Call publngResponseEnd(Me.Name, CMstrCmdNowListClick)
                End If

                '@情報取得日時を表示
                lblNowDate.Text = Format$(Now(), CPstrDateFormat)

                '@貼り合わせ可能TPALﾛｯﾄ数・ﾁｯﾌﾟ数を表示
                '貼り合わせ可能TPALﾛｯﾄ数
                If IsNumeric(lstrTotalLotNum) Then
                    lblInvTPALLotCnt.Text = Format$(CLng(lstrTotalLotNum), CPstrDateFormatKanma)
                Else
                    lblInvTPALLotCnt.Text = lstrTotalLotNum
                End If

                '貼り合わせ可能TPALﾁｯﾌﾟ数
                If IsNumeric(lstrTotalChipNum) Then
                    lblInvTPALChipCnt.Text = Format$(CLng(lstrTotalChipNum), CPstrDateFormatKanma)
                Else
                    lblInvTPALChipCnt.Text = lstrTotalChipNum
                End If
                
                '@貼り合せ可能ﾁｯﾌﾟ数に値を退避
                mstrCompableChip = lstrTotalChipNum

                '@貼り合わせ可能TPALﾛｯﾄ数が1ﾛｯﾄ以上存在し、かつﾁｯﾌﾟも1ﾁｯﾌﾟ以上あるか
                If CLng(lstrTotalLotNum) > 0 And CLng(lstrTotalChipNum) > 0 Then

                    '@[ｷｬﾘｱID(TPAL側)]ﾃｷｽﾄを有効にする
                    txtTPALCarrier.Enabled = True

                    '@ﾌｫｰﾑｱｸﾃｨﾌﾞﾌﾗｸﾞが"True：ｱｸﾃｨﾌﾞ"か
                    If mblnActivateFlag = True Then

                        '@[ｷｬﾘｱID(TPAL側)]ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtTPALCarrier)
                    End If
                Else
                    '@貼り合わせ可能TPALﾛｯﾄ数が0、またはﾁｯﾌﾟが0の場合

                    '@ﾚｽﾎﾟﾝｽ判定ﾌﾗｸﾞが"False：ﾚｽﾎﾟﾝｽ未測定"か
                    If mblnResponseFlag = False Then

                        '@ﾚｽﾎﾟﾝｽ測定ｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, CMstrCmdNowListClick)
                    End If

                    '@各種ｺﾝﾄﾛｰﾙを無効にする
                    txtTPALCarrier.Enabled = False          '[ｷｬﾘｱID(TPAL側)]ﾃｷｽﾄ
                    txtChipOutQuantity.Enabled = False      '[不良数]ﾃｷｽﾄ
                    txtChipRestQuantity.Enabled = False     '[残数]ﾃｷｽﾄ
                    cmdMove.Enabled = False                 '[">"]ﾎﾞﾀﾝ
                    cmdMoveCancel.Enabled = False           '[">"]ﾎﾞﾀﾝ
                    cmdUP.Enabled = False                   '[▲]ﾎﾞﾀﾝ
                    cmdDown.Enabled = False                 '[▼]ﾎﾞﾀﾝ
                    cmdClear.Enabled = False                '[取消]ﾎﾞﾀﾝ
                    cmdRegist.Enabled = False               '[確定]ﾎﾞﾀﾝ

                    '@無機ﾌﾗｸﾞが"1：無機"(無機ﾛｯﾄ)、かつTPAL区分が"NULL以外：指定あり"か
                    If ptypLotprestate.strVaFlag = CPstrOne And _
                        ptypLotprestate.strTpalClass <> vbNullString Then

                        '@各種ﾎﾞﾀﾝの制御
                        cmdTreatChip.Enabled = True         '[ﾁｯﾌﾟ状態変更]ﾎﾞﾀﾝ：有効
                        cmdCFCarrierSelect.Enabled = False  '[CFｷｬﾘｱ選択]ﾎﾞﾀﾝ：無効

                        '@ﾌｫｰﾑｱｸﾃｨﾌﾞﾌﾗｸﾞが"True：ｱｸﾃｨﾌﾞ"か
                        If mblnActivateFlag = True Then

                            '@[ﾁｯﾌﾟ状態変更]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdTreatChip)
                        End If

                    Else
                        '@無機ﾌﾗｸﾞが"0：有機"(有機ﾛｯﾄ)、かつTPAL区分が"NULL：指定なし"の場合

                        '@各種ﾎﾞﾀﾝを無効にする
                        cmdTreatChip.Enabled = False        '[ﾁｯﾌﾟ状態変更]ﾎﾞﾀﾝ
                        cmdCFCarrierSelect.Enabled = False  '[CFｷｬﾘｱ選択]ﾎﾞﾀﾝ

        '@↓2009/10/15 (Thu) 19:13:09 N.Kojima **************************************************
        '                '@貼り合わせ可能TPALﾛｯﾄ数/ﾁｯﾌﾟ数の何れかが"0"か
        '                If CLng(lstrTotalLotNum) = 0 Or CLng(lstrTotalChipNum) = 0 Then
        '
        '                    '@表示ﾒｯｾｰｼﾞ変換
        '                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006B)
        '                    '@"<TRM6BW>$$貼り合わせ可能なTPALロットが在庫にありません。"のﾒｯｾｰｼﾞ表示
        '                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxEN01A0.Caption, True, 16)
        '                End If
        '@↑2009/10/15 (Thu) 19:13:09 N.Kojima **************************************************

                    End If

        '@↓2009/10/15 (Thu) 18:29:11 N.Kojima **************************************************

                    '@貼り合わせ可能TPALﾛｯﾄ数/ﾁｯﾌﾟ数の何れかが"0"か
                    If CLng(lstrTotalLotNum) = 0 Or CLng(lstrTotalChipNum) = 0 Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006B)
                        '@"<TRM6BW>$$貼り合わせ可能なTPALロットが在庫にありません。"のﾒｯｾｰｼﾞ表示
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    End If

        '@↑2009/10/15 (Thu) 18:29:11 N.Kojima **************************************************

                    '@ﾌｫｰﾑｱｸﾃｨﾌﾞﾌﾗｸﾞが"True：ｱｸﾃｨﾌﾞ"か
                    If mblnActivateFlag = True Then

                        '@[最新取得]ﾎﾞﾀﾝを有効にする
                        cmdNowList.Enabled = True
                    End If

                    '@TPAL貼り合わせ可能在庫有無判定ﾌﾗｸﾞに"False：無し"をｾｯﾄ
                    mblnCombAbleTpalFlag = False

                End If
            Else
                '@TPAL貼り合わせ可能在庫情報取得結果が"False：取得失敗"の場合

                '@ﾚｽﾎﾟﾝｽ判定ﾌﾗｸﾞが"False：ﾚｽﾎﾟﾝｽ未測定"か
                If mblnResponseFlag = False Then

                    '@ﾚｽﾎﾟﾝｽ測定ｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, CMstrCmdNowListClick)
                End If

                '@各種ｺﾝﾄﾛｰﾙを無効にする
                txtTPALCarrier.Enabled = False          '[ｷｬﾘｱID(TPAL側)]ﾃｷｽﾄ
                txtChipOutQuantity.Enabled = False      '[不良数]ﾃｷｽﾄ
                txtChipRestQuantity.Enabled = False     '[残数]ﾃｷｽﾄ
                cmdMove.Enabled = False                 '[">"]ﾎﾞﾀﾝ
                cmdMoveCancel.Enabled = False           '[">"]ﾎﾞﾀﾝ
                cmdUP.Enabled = False                   '[▲]ﾎﾞﾀﾝ
                cmdDown.Enabled = False                 '[▼]ﾎﾞﾀﾝ
                cmdClear.Enabled = False                '[取消]ﾎﾞﾀﾝ
                cmdRegist.Enabled = False               '[確定]ﾎﾞﾀﾝ
                cmdTreatChip.Enabled = False            '[ﾁｯﾌﾟ状態変更]ﾎﾞﾀﾝ

                '@無機ﾌﾗｸﾞが"1：無機"(無機ﾛｯﾄ)、かつTPAL区分が"NULL以外：指定あり"か
                If ptypLotprestate.strVaFlag = CPstrOne And _
                    ptypLotprestate.strTpalClass <> vbNullString Then

                    '@[CFｷｬﾘｱ選択]ﾎﾞﾀﾝを有効にする
                    cmdCFCarrierSelect.Enabled = True
                Else
                    '@無機ﾌﾗｸﾞが"0：有機"(有機ﾛｯﾄ)、かつTPAL区分が"NULL：指定なし"の場合

                    '@[CFｷｬﾘｱ選択]ﾎﾞﾀﾝを無効にする
                    cmdCFCarrierSelect.Enabled = False
                End If

                '@TPAL貼り合わせ可能在庫有無判定ﾌﾗｸﾞに"False：無し"をｾｯﾄ
                mblnCombAbleTpalFlag = False

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

    '関数名：txtTPALCarrier_Change
    '機　能：[ｷｬﾘｱID(TPAL側)]ﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：
    '作成日：2005/07/25 (Mon) 13:37:33 N.Kojima
    '更新日：2009/10/14 (Wed) 10:24:47 N.Kojima
    '備　考：
    '　　　：2007/01/22 (Mon) 17:00:40 N.Kojima     登録候補かどうかをﾌﾗｸﾞで判定するように修正。(案件№01734)
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub txtTPALCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtTPALCarrier.Change

        Dim llngCnt     As Integer      'ｶｳﾝﾀ

        Try
            '@=======================
            '@ 仕掛前ｶｾｯﾄﾌﾚｰﾑ(TPALﾛｯﾄ情報)初期化処理
            '@=======================
            Call prvTpalInfo_Init()

            With vsfUseTpalList

                For llngCnt = 1 To .Rows.Count - 1

                    '@登録ﾌﾗｸﾞが"1：登録候補"か
                    If .GetData(llngCnt, CMlngvsfUseTpalListColInsertFlag) = CPstrOne Then

                        '@["<"]ﾎﾞﾀﾝを有効にする
                        cmdMoveCancel.Enabled = True
                        Exit For
                    End If
                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtTPALCarrier_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtTPALCarrier_Validate
    '機　能：[ｷｬﾘｱID(TPAL側)]ﾃｷｽﾄ　入力確定時処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：
    '作成日：2005/07/25 (Mon) 13:09:51 N.Kojima
    '更新日：2009/10/14 (Wed) 10:24:51 N.Kojima
    '備　考：
    '　　　：2007/01/22 (Mon) 17:01:35 N.Kojima     登録候補かどうかをﾌﾗｸﾞで判定するように修正。(案件№01734)
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub txtTPALCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtTPALCarrier.Validating

        Dim lblnAns                 As Boolean          '結果取得(True:正常,False:異常)
        Dim llngCnt                 As Integer          'ｶｳﾝﾀ
        Dim lstrTpalLotID           As String           'TPALﾛｯﾄID
        Dim lstrChipQuantity        As String           'TPALﾛｯﾄﾁｯﾌﾟ数
        Dim lstrLimitTime           As String           '有効期限
        Dim lstrLotLastUpdeta       As String           '最終更新日

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            'ﾚｽﾎﾟﾝｽ中判定ﾌﾗｸﾞの初期化(True：ﾚｽﾎﾟﾝｽ測定中、False：ﾚｽﾎﾟﾝｽ未測定)
            mblnResponseFlag = False

            '@-----------------------
            '@ ｷｬﾘｱID(TPAL側)のﾁｪｯｸ
            '@-----------------------
            '@ｷｬﾘｱID(TPAL側)がNULLか
            If Trim(txtTPALCarrier.Text) = vbNullString Then

                '@[貼り合わせTPALﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞが有効か
                If vsfUseTpalList.Enabled = True Then

                    '@[貼り合わせTPALﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = txtTPALCarrier.Name Then
                        Call pubSetFocus(vsfUseTpalList)
                    End If
                Else
                    '@[貼り合わせTPALﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞが無効な場合

                    '@[閉じる]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = txtTPALCarrier.Name Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If

                Exit Sub
            End If

            '@入力ｷｬﾘｱが前回入力ｷｬﾘｱと同じか
            If mstrTpalCarrierID = txtTPALCarrier.Text Then

                '@[不良数]ﾃｷｽﾄが有効か
                If txtChipOutQuantity.Enabled = True Then

                    '@[不良数]ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = txtTPALCarrier.Name Then
                        Call pubSetFocus(txtChipOutQuantity)
                    End If
                End If

                Exit Sub
            End If

            '@ｷｬﾘｱID(TPAL側)の桁数が6桁未満か
            If txtTPALCarrier.NowByte < txtTPALCarrier.ChrMaxByte Then

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"<TRM07W>$$キャリアIDは6桁で入力してください。"のﾒｯｾｰｼﾞ表示
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@[ｷｬﾘｱID(TPAL側)]ﾃｷｽﾄにﾌｫｰｶｽ保持
                e.Cancel = True
                Exit Sub
            End If


            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, CMstrTxtTPALCarrierValidate)

            '@=======================
            '@ TPALﾛｯﾄ情報取得
            '@=======================
            lblnAns = pubblnLotTpalInfo_Sel(CMstrlot_tpalinfoVer, _
                                            txtTPALCarrier.Text, _
                                            lblLotID.Text, _
                                            lstrTpalLotID, _
                                            lstrChipQuantity, _
                                            lstrLimitTime, _
                                            lstrLotLastUpdeta)

            '@TPALﾛｯﾄ情報取得結果が"True：取得成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, CMstrTxtTPALCarrierValidate)

                With vsfUseTpalList

                    For llngCnt = 1 To .Rows.Count - 1

                        '@対象行の登録ﾌﾗｸﾞが"1：登録候補(未登録TPALﾛｯﾄ)"か
                        If .GetData(llngCnt, CMlngvsfUseTpalListColInsertFlag) = CPstrOne Then

                            '@入力TPALﾛｯﾄIDと貼り合わせTPALﾛｯﾄ一覧のﾛｯﾄIDが同じか
                            If lstrTpalLotID = .GetData(llngCnt, CMlngvsfUseTpalListColLotID) Then

                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006G)
                                '@"<TRM6GW>$$入力されたTPALロットが貼り合わせ予定一覧に存在します。$数量を変更する場合は、
                                '@「<」ボタンで情報を戻し、$設定し直してください。"のﾒｯｾｰｼﾞ表示
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                                '@["<"]ﾎﾞﾀﾝを有効にする
                                cmdMoveCancel.Enabled = True

                                '@[ｷｬﾘｱID(TPAL側)]ﾃｷｽﾄにﾌｫｰｶｽ保持
                                e.Cancel = True
                                Exit Sub
                            End If
                        End If
                    Next llngCnt
                End With

                '@各種ﾗﾍﾞﾙの表示
                lblTPALLotID.Text = lstrTpalLotID                                                'TPALﾛｯﾄID

                'TPALﾛｯﾄﾁｯﾌﾟ数
                If IsNumeric(lstrChipQuantity) Then
                    lblTPALChipQuantity.Text = Format$(CLng(lstrChipQuantity), CPstrDateFormatKanma)
                Else
                    lblTPALChipQuantity.Text = lstrChipQuantity'TPALﾛｯﾄﾁｯﾌﾟ数
                End If

                '有効期限
                If IsDate(lstrLimitTime) Then
                    lblLimitTime.Text = Format$(CDate(lstrLimitTime), CPstrDateTimeYMDHM)
                Else
                    lblLimitTime.Text = lstrLimitTime
                End If

                mstrTpalLotLastUpdate = lstrLotLastUpdeta                                        'TPALﾛｯﾄ最終更新日

                '@有効期限が過ぎているか(有効期限 < 現在日時 の場合)
                If lblLimitTime.Text < _
                    Format$(Now(), CPstrDateTimeYMDHM) Then

                    '@有効期限を赤字で表示する
                    lblLimitTime.ForeColor = Color.Red

                    '@TFTﾛｯﾄが「PR/ES」品か
                    If lblFlowClass.Text = CPstrFlowClassPR Or _
                        lblFlowClass.Text = CPstrFlowClassES Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002R)
                        '@"<TRM2RW>$$使用TPALロットの有効期限が切れているため、使用できません。"のﾒｯｾｰｼﾞ表示
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@[ｷｬﾘｱID(TPAL側)]ﾃｷｽﾄにﾌｫｰｶｽ保持
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    '@有効期限が過ぎていない場合(有効期限 > 現在日時 の場合)

                    '@有効期限を黒字で表示する
                    lblLimitTime.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
                End If

                '@[不良数]ﾃｷｽﾄ、[残数]ﾃｷｽﾄを有効にする
                txtChipOutQuantity.Enabled = True
                txtChipRestQuantity.Enabled = True

                '@[不良数]ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = txtTPALCarrier.Name Then
                    Call pubSetFocus(txtChipOutQuantity)
                End if

            Else
                '@TPALﾛｯﾄ情報取得結果が"False：取得失敗"の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, CMstrTxtTPALCarrierValidate)

                '@[ｷｬﾘｱID(TPAL側)]ﾃｷｽﾄにﾌｫｰｶｽ保持
                e.Cancel = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtTPALCarrier_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtChipOutQuantity_Change
    '機　能：[不良数]ﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：
    '作成日：2005/07/25 (Mon) 13:07:49 N.Kojima
    '更新日：2009/10/14 (Wed) 10:24:58 N.Kojima
    '備　考：
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub txtChipOutQuantity_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtChipOutQuantity.Change

        Try
            '@不良数がNULL、または残数がNULLか
            If txtChipOutQuantity.Text = vbNullString Or _
                txtChipRestQuantity.Text = vbNullString Then

                '@[">"]ﾎﾞﾀﾝを無効にする
                cmdMove.Enabled = False
            Else
                '@不良数、残数が共にNULL以外の場合

                '@不良数がNULL、またはｴﾗｰﾌﾗｸﾞが"True：ｴﾗｰあり"か
                If txtChipOutQuantity.Text = vbNullString Or _
                    mblnErrFlag = True Then

                    '@[">"]ﾎﾞﾀﾝを無効にする
                    cmdMove.Enabled = False
                Else
                    '@不良数がNULL以外、かつｴﾗｰﾌﾗｸﾞが"False：ｴﾗｰなし"の場合

                    '@残数がNULL以外か
                    If txtChipRestQuantity.Text <> vbNullString Then

                        '@[">"]ﾎﾞﾀﾝを有効にする
                        cmdMove.Enabled = True
                    Else
                        '@残数がNULLの場合

                        '@[">"]ﾎﾞﾀﾝを無効にする
                        cmdMove.Enabled = False
                    End If
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtChipOutQuantity_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtChipOutQuantity_Validate
    '機　能：[不良数]ﾃｷｽﾄ　入力確定時処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/07/25 (Mon) 13:05:12 N.Kojima
    '更新日：2009/10/14 (Wed) 10:25:02 N.Kojima
    '備　考：
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub txtChipOutQuantity_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtChipOutQuantity.Validating

        Dim llngTotalNum    As Integer    '不良数 + 残数
        Dim llngCombNum     As Integer    '貼数(数量 - 不良数 - 残数)

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@入力不良数が前回入力不良数と同じで、かつｷｬﾝｾﾙﾌﾗｸﾞが"False：初期値"か
            If mstrChipOutQuantity = txtChipOutQuantity.Text And _
                mblnCancelFlag = False Then

                Exit Sub
            End If

            'NSYS カンマ編集と数値保持用変数
            Dim lstrEditedTxtChipOutQuantityKanma As String
            Dim llngTxtChipOutQuantity As Integer
            Dim lstrEditedtxtChipRestQuantityKanma As String
            Dim llngTxtChipRestQuantity As Integer
            Dim lstrLblTPALChipQuantityKanma As String
            Dim llngLblTPALChipQuantity As Integer

            '@入力不良数をﾓｼﾞｭｰﾙ変数に退避
            mstrChipOutQuantity = txtChipOutQuantity.Text

            'NSYS TPALﾁｯﾌﾟ数量編集
            If IsNumeric(lblTPALChipQuantity.Text) Then
                lstrLblTPALChipQuantityKanma = Format$(CLng(lblTPALChipQuantity.Text), CPstrDateFormatKanma)
                llngLblTPALChipQuantity = CLng(lblTPALChipQuantity.Text)
            Else
                lstrLblTPALChipQuantityKanma = lblTPALChipQuantity.Text
                llngLblTPALChipQuantity = 0
            End If

            '@不良数がNULL以外か
            If txtChipOutQuantity.Text <> vbNullString Then

                'NSYS 不良数編集
                If IsNumeric(txtChipOutQuantity.Text) Then
                    lstrEditedTxtChipOutQuantityKanma = Format$(CLng(txtChipOutQuantity.Text), CPstrDateFormatKanma)
                    llngTxtChipOutQuantity = CLng(txtChipOutQuantity.Text)
                Else
                    lstrEditedTxtChipOutQuantityKanma = txtChipOutQuantity.Text
                    llngTxtChipOutQuantity = 0
                End If

                '@残数がNULL以外か
                If txtChipRestQuantity.Text <> vbNullString Then

                    'NSYS 残数編集
                    If IsNumeric(txtChipRestQuantity.Text) Then
                        lstrEditedtxtChipRestQuantityKanma = Format$(CLng(txtChipRestQuantity.Text), CPstrDateFormatKanma)
                        llngTxtChipRestQuantity = CLng(txtChipRestQuantity.Text)
                    Else
                        lstrEditedtxtChipRestQuantityKanma = txtChipRestQuantity.Text
                        llngTxtChipRestQuantity = 0
                    End If

                    '@入力不良数がTPALﾁｯﾌﾟ数量を超えているか
                    If llngTxtChipOutQuantity > llngLblTPALChipQuantity Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM6CW>$$入力不良数がTPALチップ数を超えています。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006C, lstrEditedTxtChipOutQuantityKanma, _
                                                        lstrLblTPALChipQuantityKanma)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@[">"]ﾎﾞﾀﾝを無効にする
                        cmdMove.Enabled = False

                        '@各種ﾌﾗｸﾞに値をｾｯﾄ
                        mblnErrFlag = True          'ｴﾗｰﾌﾗｸﾞ："True：ｴﾗｰあり"
                        mblnCancelFlag = True       'ｷｬﾝｾﾙﾌﾗｸﾞ："True：処理ｷｬﾝｾﾙ"

                        '@[不良数]ﾃｷｽﾄにﾌｫｰｶｽ保持
                        e.Cancel = True
                        Exit Sub
                    End If

                    '@不良数 + 残数を格納
                    llngTotalNum = llngTxtChipRestQuantity + llngTxtChipOutQuantity
                    '@貼数(入力TPALﾛｯﾄのﾁｯﾌﾟ数 - (不良数 + 残数))を格納
                    llngCombNum = llngLblTPALChipQuantity - llngTotalNum

                    '@(不良数 + 残数) > 入力TPALﾛｯﾄのﾁｯﾌﾟ数か
                    If llngTotalNum > llngLblTPALChipQuantity Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM2MW>$$入力合計数[%1]がTPALチップ数量[%2]を超えています。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002M, Format$(llngTotalNum, CPstrDateFormatKanma), _
                                                        lstrLblTPALChipQuantityKanma)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@[">"]ﾎﾞﾀﾝを無効にする
                        cmdMove.Enabled = False

                        '@各種ﾌﾗｸﾞに値をｾｯﾄ
                        mblnErrFlag = True          'ｴﾗｰﾌﾗｸﾞ："True：ｴﾗｰあり"
                        mblnCancelFlag = True       'ｷｬﾝｾﾙﾌﾗｸﾞ："True：処理ｷｬﾝｾﾙ"

                        '@[不良数]ﾃｷｽﾄにﾌｫｰｶｽ保持
                        e.Cancel = True
                        Exit Sub
                    Else
                        '@(不良数 + 残数) <= 入力TPALﾛｯﾄのﾁｯﾌﾟ数の場合

                        '@貼数 > 貼り合わせ数(TFTﾛｯﾄに対しての貼り合わせ対象ﾁｯﾌﾟ数)
                        If llngCombNum > CLng(lblCoverCnt.Text) Then

                            'NSYS 数値変換判定
                            Dim lstrEditedLblCoverCntKanma As String
                            If IsNumeric(lblCoverCnt.Text) Then
                                lstrEditedLblCoverCntKanma = Format$(CLng(lblCoverCnt.Text), CPstrDateFormatKanma)
                            Else
                                lstrEditedLblCoverCntKanma = lblCoverCnt.Text
                            End If

                            '@表示ﾒｯｾｰｼﾞ変換
                            '@"<TRM6EW>$$貼数[%1]が貼り合わせ可能数[%2]を超えています。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006E, Format$(llngCombNum, CPstrDateFormatKanma), _
                                                            lstrEditedLblCoverCntKanma)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            '@[">"]ﾎﾞﾀﾝを無効にする
                            cmdMove.Enabled = False

                            '@各種ﾌﾗｸﾞに値をｾｯﾄ
                            mblnErrFlag = True          'ｴﾗｰﾌﾗｸﾞ："True：ｴﾗｰあり"
                            mblnCancelFlag = True       'ｷｬﾝｾﾙﾌﾗｸﾞ："True：処理ｷｬﾝｾﾙ"

                            '@[不良数]ﾃｷｽﾄにﾌｫｰｶｽ保持
                            e.Cancel = True
                            Exit Sub
                        Else
                            '@貼数 <= 貼り合わせ数(TFTﾛｯﾄに対しての貼り合わせ対象ﾁｯﾌﾟ数)の場合

                            '@不良数が"0"で、かつ"残数=入力TPALﾛｯﾄのﾁｯﾌﾟ数"か
                            If llngTxtChipOutQuantity = 0 And _
                                llngTxtChipRestQuantity = llngLblTPALChipQuantity Then

                                '@表示ﾒｯｾｰｼﾞ変換
                                '@"<TRM6IW>$$入力された不良数[%1]、残数[%2]が不正です。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006I, lstrEditedTxtChipOutQuantityKanma, _
                                                                lstrEditedtxtChipRestQuantityKanma)
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                                '@[">"]ﾎﾞﾀﾝを無効にする
                                cmdMove.Enabled = False

                                '@各種ﾌﾗｸﾞに値をｾｯﾄ
                                mblnErrFlag = True          'ｴﾗｰﾌﾗｸﾞ："True：ｴﾗｰあり"
                                mblnCancelFlag = True       'ｷｬﾝｾﾙﾌﾗｸﾞ："True：処理ｷｬﾝｾﾙ"

                                '@[不良数]ﾃｷｽﾄにﾌｫｰｶｽ保持
                                e.Cancel = True
                                Exit Sub
                            Else
                                '@不良数が"0"以外、または"残数 <> 入力TPALﾛｯﾄのﾁｯﾌﾟ数"の場合

                                '@[">"]ﾎﾞﾀﾝを有効にする
                                cmdMove.Enabled = True

                                '@ｴﾗｰﾌﾗｸﾞに"False：ｴﾗｰなし"をｾｯﾄ
                                mblnErrFlag = False

                                '@[残数]ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
                                If ActiveControl.Name = txtChipOutQuantity.Name Then
                                    Call pubSetFocus(txtChipRestQuantity)
                                End If
                            End If
                        End If
                    End If
                Else
                    '@残数がNULLの場合

                    '@不良数 > 入力TPALﾛｯﾄのﾁｯﾌﾟ数か
                    If llngTxtChipOutQuantity > llngLblTPALChipQuantity Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM6CW>$$入力不良数がTPALチップ数を超えています。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006C, lstrEditedTxtChipOutQuantityKanma, _
                                                        lstrLblTPALChipQuantityKanma)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@[">"]ﾎﾞﾀﾝを無効にする
                        cmdMove.Enabled = False

                        '@各種ﾌﾗｸﾞに値をｾｯﾄ
                        mblnErrFlag = True          'ｴﾗｰﾌﾗｸﾞ："True：ｴﾗｰあり"
                        mblnCancelFlag = True       'ｷｬﾝｾﾙﾌﾗｸﾞ："True：処理ｷｬﾝｾﾙ"

                        '@[不良数]ﾃｷｽﾄにﾌｫｰｶｽ保持
                        e.Cancel = True
                    Else
                        '@不良数 <= 入力TPALﾛｯﾄのﾁｯﾌﾟ数の場合

                        '@[残数]ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
                        If ActiveControl.Name = txtChipOutQuantity.Name Then
                            Call pubSetFocus(txtChipRestQuantity)
                        End if
                    End If
                End If
            Else
                '@不良数がNULLの場合

                '@[残数]ﾃｷｽﾄが有効か
                If txtChipRestQuantity.Enabled = True Then

                    '@[残数]ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = txtChipOutQuantity.Name Then
                        Call pubSetFocus(txtChipRestQuantity)
                    End If
                Else
                    '@[閉じる]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = txtChipOutQuantity.Name Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtChipOutQuantity_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtChipRestQuantity_Change
    '機　能：[残数]ﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/25 (Mon) 13:06:54 N.Kojima
    '更新日：2009/10/14 (Wed) 10:25:05 N.Kojima
    '備　考：
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub txtChipRestQuantity_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtChipRestQuantity.Change

        Try
            '@残数がNULL、またはｴﾗｰﾌﾗｸﾞが"True：ｴﾗｰあり"か
            If txtChipRestQuantity.Text = vbNullString Or _
                mblnErrFlag = True Then

                '@[">"]ﾎﾞﾀﾝを無効にする
                cmdMove.Enabled = False
            Else
                '@残数がNULL以外、かつｴﾗｰﾌﾗｸﾞが"False：ｴﾗｰなし"の場合

                '@不良数がNULL以外か
                If txtChipOutQuantity.Text <> vbNullString Then

                    '@[">"]ﾎﾞﾀﾝを有効にする
                    cmdMove.Enabled = True
                Else
                    '@[">"]ﾎﾞﾀﾝを無効にする
                    cmdMove.Enabled = False
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtChipRestQuantity_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtChipRestQuantity_Validate
    '機　能：[残数]ﾃｷｽﾄ　入力確定時処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/07/25 (Mon) 13:04:28 N.Kojima
    '更新日：2009/10/14 (Wed) 10:25:08 N.Kojima
    '備　考：
    '　　　：2005/08/02 (Tue) 11:05:02 N.Kasai      ﾌｫｰｶｽ制御追加
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub txtChipRestQuantity_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtChipRestQuantity.Validating

        Dim llngTotalNum    As Integer    '不良数 + 残数
        Dim llngCombNum     As Integer    '貼数(数量 - 不良数 - 残数)

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@入力残数が残数退避変数と同じ、かつｷｬﾝｾﾙﾌﾗｸﾞが"False：処理をｷｬﾝｾﾙしない"か
            If mstrChipRestQuantity = txtChipRestQuantity.Text And _
                mblnCancelFlag = False Then

                Exit Sub
            End If

            'NSYS カンマ編集退避用変数
            Dim lstrEditedTxtChipRestQuantityKanma As String
            Dim llngTxtChipRestQuantity As Integer
            Dim lstrEditedTxtChipOutQuantityKanma As String
            Dim llngTxtChipOutQuantity As Integer
            Dim lstrEditedLblTPALChipQuantityKanma As String
            Dim llngLblTPALChipQuantity As Integer

            '@入力残数をﾓｼﾞｭｰﾙ変数に退避
            mstrChipRestQuantity = txtChipRestQuantity.Text

            'NSYS TPALロットチップ数カンマ編集
            If IsNumeric(lblTPALChipQuantity.Text) Then
                lstrEditedLblTPALChipQuantityKanma = Format$(CLng(lblTPALChipQuantity.Text), CPstrDateFormatKanma)
                llngLblTPALChipQuantity = CLng(lblTPALChipQuantity.Text)
            Else
                lstrEditedLblTPALChipQuantityKanma = lblTPALChipQuantity.Text
                llngLblTPALChipQuantity = 0
            End If

            '@残数がNULL以外か
            If txtChipRestQuantity.Text <> vbNullString Then

                'NSYS 残数カンマ編集
                If IsNumeric(txtChipRestQuantity.Text) Then
                    lstrEditedTxtChipRestQuantityKanma = Format$(CLng(txtChipRestQuantity.Text), CPstrDateFormatKanma)
                    llngTxtChipRestQuantity = CLng(txtChipRestQuantity.Text)
                Else
                    lstrEditedTxtChipRestQuantityKanma = txtChipRestQuantity.Text
                    llngTxtChipRestQuantity = 0
                End If

                '@不良数がNULL以外か
                If txtChipOutQuantity.Text <> vbNullString Then

                    'NSYS 不良数カンマ編集
                    If IsNumeric(txtChipOutQuantity.Text) Then
                        lstrEditedTxtChipOutQuantityKanma = Format$(CLng(txtChipOutQuantity.Text), CPstrDateFormatKanma)
                        llngTxtChipOutQuantity = CLng(txtChipOutQuantity.Text)
                    Else
                        lstrEditedTxtChipOutQuantityKanma = 
                        llngTxtChipOutQuantity = 0
                    End If

                    '@残数 > 入力TPALﾛｯﾄのﾁｯﾌﾟ数か
                    If llngTxtChipRestQuantity > llngLblTPALChipQuantity Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM6DW>$$入力残数[%1]がTPALチップ数[%2]を超えています。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006D, lstrEditedTxtChipRestQuantityKanma, _
                                                        lstrEditedLblTPALChipQuantityKanma)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@[">"]ﾎﾞﾀﾝを無効にする
                        cmdMove.Enabled = False

                        '@各種ﾌﾗｸﾞに値をｾｯﾄ
                        mblnErrFlag = True          'ｴﾗｰﾌﾗｸﾞ："True：ｴﾗｰあり"
                        mblnCancelFlag = True       'ｷｬﾝｾﾙﾌﾗｸﾞ："True：処理ｷｬﾝｾﾙ"

                        '@[残数]ﾃｷｽﾄにﾌｫｰｶｽ保持
                        e.Cancel = True
                        Exit Sub
                    End If

                    '@不良数 + 残数を格納
                    llngTotalNum = llngTxtChipRestQuantity + llngTxtChipOutQuantity
                    '@貼数(入力TPALﾛｯﾄのﾁｯﾌﾟ数量 - (不良数 + 残数))を格納
                    llngCombNum = llngLblTPALChipQuantity - llngTotalNum

                    '@(不良数 + 残数) > 入力TPALﾛｯﾄのﾁｯﾌﾟ数か
                    If llngTotalNum > llngLblTPALChipQuantity Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM2MW>$$入力合計数[%1]がTPALチップ数量[%2]を超えています。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002M, Format$(llngTotalNum, CPstrDateFormatKanma), _
                                                        lstrEditedLblTPALChipQuantityKanma)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@[">"]ﾎﾞﾀﾝを無効にする
                        cmdMove.Enabled = False

                        '@各種ﾌﾗｸﾞに値をｾｯﾄ
                        mblnErrFlag = True          'ｴﾗｰﾌﾗｸﾞ："True：ｴﾗｰあり"
                        mblnCancelFlag = True       'ｷｬﾝｾﾙﾌﾗｸﾞ："True：処理ｷｬﾝｾﾙ"

                        '@[残数]ﾃｷｽﾄにﾌｫｰｶｽ保持
                        e.Cancel = True
                        Exit Sub
                    Else
                        '@(不良数 + 残数) <= 入力TPALﾛｯﾄのﾁｯﾌﾟ数の場合

                        '@貼数 > 貼り合わせ数(TFTﾛｯﾄに対しての貼り合わせ対象ﾁｯﾌﾟ数)
                        If llngCombNum > CLng(lblCoverCnt.Text) Then

                            'NSYS カンマ編集
                            Dim lstrEditedLblCoverCntKanma As String
                            If IsNumeric(lblCoverCnt.Text) Then
                                lstrEditedLblCoverCntKanma = Format$(CLng(lblCoverCnt.Text), CPstrDateFormatKanma)
                            Else
                                lstrEditedLblCoverCntKanma = lblCoverCnt.Text
                            End If

                            '@表示ﾒｯｾｰｼﾞ変換
                            '@"<TRM6EW>$$貼数[%1]が貼り合わせ可能数[%2]を超えています。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006E, Format$(llngCombNum, CPstrDateFormatKanma), _
                                                            lstrEditedLblCoverCntKanma)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            '@[">"]ﾎﾞﾀﾝを無効にする
                            cmdMove.Enabled = False

                            '@各種ﾌﾗｸﾞに値をｾｯﾄ
                            mblnErrFlag = True          'ｴﾗｰﾌﾗｸﾞ："True：ｴﾗｰあり"
                            mblnCancelFlag = True       'ｷｬﾝｾﾙﾌﾗｸﾞ："True：処理ｷｬﾝｾﾙ"

                            '@[残数]ﾃｷｽﾄにﾌｫｰｶｽ保持
                            e.Cancel = True
                            Exit Sub
                        Else
                            '@貼数 <= 貼り合わせ数(TFTﾛｯﾄに対しての貼り合わせ対象ﾁｯﾌﾟ数)の場合

                            '@不良数が"0"、かつ"残数=入力TPALﾛｯﾄのﾁｯﾌﾟ数"か
                            If llngTxtChipOutQuantity = 0 And _
                                llngTxtChipRestQuantity = llngLblTPALChipQuantity Then

                                '@表示ﾒｯｾｰｼﾞ変換
                                '@"<TRM6IW>$$入力された不良数[%1]、残数[%2]が不正です。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006I, lstrEditedTxtChipOutQuantityKanma, _
                                                                lstrEditedTxtChipRestQuantityKanma)
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                                '@[">"]ﾎﾞﾀﾝを無効にする
                                cmdMove.Enabled = False

                                '@各種ﾌﾗｸﾞに値をｾｯﾄ
                                mblnErrFlag = True          'ｴﾗｰﾌﾗｸﾞ："True：ｴﾗｰあり"
                                mblnCancelFlag = True       'ｷｬﾝｾﾙﾌﾗｸﾞ："True：処理ｷｬﾝｾﾙ"

                                '@[残数]ﾃｷｽﾄにﾌｫｰｶｽ保持
                                e.Cancel = True
                                Exit Sub
                            Else
                                '@不良数が"0"以外、または"残数 <> 入力TPALﾛｯﾄのﾁｯﾌﾟ数"の場合

                                '@[">"]ﾎﾞﾀﾝを有効にする
                                cmdMove.Enabled = True

                                '@ｴﾗｰﾌﾗｸﾞに"False：ｴﾗｰなし"をｾｯﾄ
                                mblnErrFlag = False
                            End If
                        End If
                    End If
                Else
                    '@不良数がNULLの場合

                    '@残数 > 入力TPALﾛｯﾄのﾁｯﾌﾟ数か
                    If llngTxtChipRestQuantity > llngLblTPALChipQuantity Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM6DW>$$入力残数[%1]がTPALチップ数[%2]を超えています。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006D, lstrEditedTxtChipRestQuantityKanma, _
                                                        lstrEditedLblTPALChipQuantityKanma)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@[">"]ﾎﾞﾀﾝを無効にする
                        cmdMove.Enabled = False

                        '@各種ﾌﾗｸﾞに値をｾｯﾄ
                        mblnErrFlag = True          'ｴﾗｰﾌﾗｸﾞ："True：ｴﾗｰあり"
                        mblnCancelFlag = True       'ｷｬﾝｾﾙﾌﾗｸﾞ："True：処理ｷｬﾝｾﾙ"

                        '@[残数]ﾃｷｽﾄにﾌｫｰｶｽ保持
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If

            '@[">"]ﾎﾞﾀﾝが有効か
            If cmdMove.Enabled = True Then

                '@[">"]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = txtChipRestQuantity.Name Then
                    Call pubSetFocus(cmdMove)
                End If
            Else
                '@[">"]ﾎﾞﾀﾝが無効な場合

                '@[取消]ﾎﾞﾀﾝが有効か
                If cmdClear.Enabled = True Then

                    '@[取消]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = txtChipRestQuantity.Name Then
                        Call pubSetFocus(cmdClear)
                    End If
                Else
                    '@[閉じる]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = txtChipRestQuantity.Name Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtChipRestQuantity_Validate"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMove_Click
    '機　能：[">"]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/31 (Tue) 15:14:30 N.Kojima
    '更新日：2009/10/14 (Wed) 10:25:12 N.Kojima
    '備　考：
    '　　　：2004/10/06 (Wed) 16:41:55 H.Wajima     動作変更。
    '　　　：2004/11/22 (Mon) 18:02:16 S.Deguchi    正常処理時の使用枚数欄の初期化処理を追加。
    '　　　：2005/07/25 (Mon) 17:13:31 N.Kojima     機能改造に伴い、大幅修正(削除)。ﾕｰｻﾞ要望№0061
    '　　　：2007/01/22 (Mon) 17:01:35 N.Kojima     登録候補かどうかをﾌﾗｸﾞで判定するように修正。(案件№01734)
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub cmdMove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMove.Click

        Dim lstrCombNum             As String       '貼数
        Dim lstrCalcNum             As String       '計算結果格納用
        Dim llngCnt                 As Integer      'ｶｳﾝﾄ

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@確定ﾎﾞﾀﾝを有効にする
            cmdRegist.Enabled = True

            '@入力TPALﾛｯﾄのﾁｯﾌﾟ数、不良数、残数が全てNULL以外か
            If lblTPALChipQuantity.Text <> vbNullString And _
                txtChipOutQuantity.Text <> vbNullString And _
                txtChipRestQuantity.Text <> vbNullString Then

                'NSYS 数値チェック
                Dim llngLblTPALChipQuantity As Integer
                If IsNumeric(lblTPALChipQuantity.Text) Then
                    llngLblTPALChipQuantity = CLng(lblTPALChipQuantity.Text)
                Else
                    llngLblTPALChipQuantity = 0
                End If

                Dim lstrEditedTxtChipOutQuantityKanma As String
                Dim llngTxtChipOutQuantity As Integer
                If IsNumeric(txtChipOutQuantity.Text) Then
                    lstrEditedTxtChipOutQuantityKanma = Format$(CLng(txtChipOutQuantity.Text), CPstrDateFormatKanma)
                    llngTxtChipOutQuantity = CLng(txtChipOutQuantity.Text)
                Else
                    lstrEditedTxtChipOutQuantityKanma = txtChipOutQuantity.Text
                    llngTxtChipOutQuantity = 0
                End If

                Dim lstrEditedTxtChipRestQuantityKanma As String
                Dim llngTxtChipRestQuantity As Integer
                If IsNumeric(txtChipRestQuantity.Text) Then
                    lstrEditedTxtChipRestQuantityKanma = Format$(CLng(txtChipRestQuantity.Text), CPstrDateFormatKanma)
                    llngTxtChipRestQuantity = CLng(txtChipRestQuantity.Text)
                Else
                    lstrEditedTxtChipRestQuantityKanma = txtChipRestQuantity.Text
                    llngTxtChipRestQuantity = 0
                End If

                '@貼数を求める(入力TPALﾛｯﾄのﾁｯﾌﾟ数 - 不良数 - 残数)
                lstrCalcNum = CStr(llngLblTPALChipQuantity _
                                - llngTxtChipOutQuantity _
                                - llngTxtChipRestQuantity)

                '@貼残数がNULL以外か
                If lblCoverRestQuantity.Text <> vbNullString Then

                    'NSYS カンマ編集
                    Dim lstrEditedLblCoverRestQuantityKanma As String
                    Dim llngLblCoverRestQuantity As Integer
                    If IsNumeric(lblCoverRestQuantity.Text) Then
                        lstrEditedLblCoverRestQuantityKanma = Format$(CLng(lblCoverRestQuantity.Text), CPstrDateFormatKanma)
                        llngLblCoverRestQuantity = CLng(lblCoverRestQuantity.Text)
                    Else
                        lstrEditedLblCoverRestQuantityKanma = lblCoverRestQuantity.Text
                        llngLblCoverRestQuantity = 0
                    End If

                    '@貼数 > 貼残数か
                    If CLng(lstrCalcNum) > llngLblCoverRestQuantity Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM6FW>$$貼数[%1]が貼残数[%2]を超えています。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006F, Format$(CLng(lstrCalcNum), CPstrDateFormatKanma), _
                                                        lstrEditedLblCoverRestQuantityKanma)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@[">"]ﾎﾞﾀﾝを無効にする
                        cmdMove.Enabled = False

                        '@[不良数]ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtChipOutQuantity)
                        Exit Sub
                    End If
                End If


                '@-----------------------
                '@ [貼り合わせTPALﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞに情報を追加
                '@-----------------------
                With vsfUseTpalList

                    '@描画ﾛｯｸ
                    .Redraw = False

                    '@行数設定(貼り合わせTPALﾛｯﾄ一覧)
                    RemoveHandler vsfUseTpalList.BeforeRowColChange,AddressOf vsfUseTpalList_BeforeRowColChange
                    RemoveHandler vsfUseTpalList.EnterCell,AddressOf vsfUseTpalList_EnterCell
                    .Rows.Count = .Rows.Count + 1
                    AddHandler vsfUseTpalList.BeforeRowColChange,AddressOf vsfUseTpalList_BeforeRowColChange
                    AddHandler vsfUseTpalList.EnterCell,AddressOf vsfUseTpalList_EnterCell

                    '@貼数を文字型に変換
                    lstrCombNum = lstrCalcNum

                    '@№の振り直し
                    For llngCnt = 1 To .Rows.Count - 1
                        .SetData(llngCnt, CMlngvsfUseTpalListColNo, llngCnt)
                    Next llngCnt

                    .SetData(.Rows.Count - 1, CMlngvsfUseTpalListColNo, .Rows.Count - 1)                                     '№
                    .SetData(.Rows.Count - 1, CMlngvsfUseTpalListColCarrierID, txtTPALCarrier.Text)                          'TPALｷｬﾘｱID
                    .SetData(.Rows.Count - 1, CMlngvsfUseTpalListColLotID, lblTPALLotID.Text)                                'TPALﾛｯﾄID
                    .SetData(.Rows.Count - 1, CMlngvsfUseTpalListColCoverNum, Format$(CLng(lstrCombNum), CPstrDateFormatKanma))    '貼数
                    .SetData(.Rows.Count - 1, CMlngvsfUseTpalListColOutNum, lstrEditedTxtChipOutQuantityKanma)               '不良数
                    .SetData(.Rows.Count - 1, CMlngvsfUseTpalListColRestNum, lstrEditedTxtChipRestQuantityKanma)             '残数
                    .SetData(.Rows.Count - 1, CMlngvsfUseTpalListColLotLastUpdate, mstrTpalLotLastUpdate)                    'TPALﾛｯﾄ最終更新日時
                    .SetData(.Rows.Count - 1, CMlngvsfUseTpalListColLimitTime, lblLimitTime.Text)                            '有効期限
                    .SetData(.Rows.Count - 1, CMlngvsfUseTpalListColInsertFlag, CPstrOne)                                    '登録ﾌﾗｸﾞ(0:登録済み、1:新規登録)

                    '@ﾌｫﾝﾄの色変更(黒色)
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngBlackColor")
                    newStyle.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
                    Dim cellRange As CellRange = .GetCellRange(.Rows.Count - 1, CMlngvsfGridTitleCol, _
                                           .Rows.Count - 1, .Cols.Count - 1)
                    cellRange.Style = newStyle

                    '@書式設定
                    .Cols(CMlngvsfUseTpalListColCarrierID).TextAlign = TextAlignEnum.LeftCenter        'TPALｷｬﾘｱID(左寄せ中央揃え)
                    .Cols(CMlngvsfUseTpalListColLotID).TextAlign = TextAlignEnum.LeftCenter            'TPALﾛｯﾄID(左寄せ中央揃え)
                    .Cols(CMlngvsfUseTpalListColCoverNum).TextAlign = TextAlignEnum.RightCenter        '貼数(右寄せ中央揃え)
                    .Cols(CMlngvsfUseTpalListColOutNum).TextAlign = TextAlignEnum.RightCenter          '不良数(右寄せ中央揃え)
                    .Cols(CMlngvsfUseTpalListColRestNum).TextAlign = TextAlignEnum.RightCenter         '残数(右寄せ中央揃え)
                    .Cols(CMlngvsfUseTpalListColLotLastUpdate).TextAlign = TextAlignEnum.LeftCenter    'TPALﾛｯﾄ最終更新日時(非表示)(左寄せ中央揃え)
                    .Cols(CMlngvsfUseTpalListColLimitTime).TextAlign = TextAlignEnum.LeftCenter        '有効期限(非表示)(左寄せ中央揃え)
                    .Cols(CMlngvsfUseTpalListColInsertFlag).TextAlign = TextAlignEnum.LeftCenter       '登録ﾌﾗｸﾞ(非表示)(左寄せ中央揃え)

                    '@ｽﾛｯﾄの高さの設定
                    .Rows(.Rows.Count - 1).Height = CMlngvsfGridHeight

                    '@[貼り合わせTPALﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞを有効にする
                    .Enabled = True

                    '@各種ｺﾝﾄﾛｰﾙの初期化(仕掛前ｶｾｯﾄﾌﾚｰﾑ内)
                    lblTPALLotID.Text = vbNullString             '[TPALﾛｯﾄID]ﾗﾍﾞﾙ
                    lblTPALChipQuantity.Text = vbNullString      '[数量(TPAL)]ﾗﾍﾞﾙ
                    lblLimitTime.Text = vbNullString             '[有効期限]ﾗﾍﾞﾙ
                    txtChipOutQuantity.Text = vbNullString          '[不良数]ﾃｷｽﾄ
                    txtChipRestQuantity.Text = vbNullString         '[残数]ﾃｷｽﾄ

                    '@各種ｺﾝﾄﾛｰﾙを無効にする
                    txtChipOutQuantity.Enabled = False              '[不良数]ﾃｷｽﾄ
                    txtChipRestQuantity.Enabled = False             '[残数]ﾃｷｽﾄ
                    cmdMove.Enabled = False                         '[">"]ﾎﾞﾀﾝ

                    '@TPALｷｬﾘｱIDの初期化
                    txtTPALCarrier.Text = vbNullString

                    '@追加行を選択
                    .Row = .Rows.Count - 1

                    '@=======================
                    '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                    '@=======================
                    Call pubVsfBeforeSort(vsfUseTpalList, CMlngvsfUseTpalListColCarrierID & vbTab & _
                                                            CMlngvsfUseTpalListColCoverNum & vbTab & _
                                                            CMlngvsfUseTpalListColLotLastUpdate)

                    '@=======================
                    '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                    '@=======================
                    Call pubVsfAfterSort(vsfUseTpalList, CMlngvsfUseTpalListColCarrierID & vbTab & _
                                                            CMlngvsfUseTpalListColCoverNum & vbTab & _
                                                            CMlngvsfUseTpalListColLotLastUpdate, _
                                                            cmdUP, cmdDown)

                    '@描画実施
                    .Redraw = True

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
                    If .TopRow + CMlngvsfGridRows >= .Rows.Count Then

                        '@下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝを無効にする
                        cmdDown.Enabled = False
                    Else
                        '@表示先頭行+1ﾍﾟｰｼﾞの最大表示行数が全行数より小さいか

                        '@下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝを有効にする
                        cmdDown.Enabled = True
                    End If

                    '@=======================
                    '@ 各種ﾁｯﾌﾟ数計算処理
                    '@=======================
                    Call prvCalcChipNum_Disp()

                End With
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMove_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMoveCancel_Click
    '機　能：["<"]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/31 (Tue) 15:15:02 N.Kojima
    '更新日：2009/10/14 (Wed) 10:25:15 N.Kojima
    '備　考：
    '　　　：2004/10/06 (Wed) 16:43:23 H.Wajima     動作変更。
    '　　　：2004/11/22 (Mon) 13:09:48 S.Deguchi    残数と総枚数の計算に不良枚数を追加。
    '　　　：2005/07/25 (Mon) 17:14:44 N.Kojima     機能改造に伴い、大幅修正(削除)。ﾕｰｻﾞ要望№0061
    '　　　：2007/01/22 (Mon) 17:01:35 N.Kojima     登録候補かどうかをﾌﾗｸﾞで判定するように修正。(案件№01734)
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub cmdMoveCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMoveCancel.Click

        Dim llngCnt                 As Integer      'ｶｳﾝﾄ
        Dim llngRow                 As Integer      'TPAL貼り合わせ実績選択行
        Dim llngSelectedRowNum()    As Integer      '選択行番号

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            With vsfUseTpalList

                '@選択行番号配列の初期化
                ReDim llngSelectedRowNum(0 To .Rows.Selected.Count - 1)

                '@選択行番号取得
                'llngRow = .Rows.Selected(llngCnt).Index
                llngRow = .Row

                '@有効行(ﾀｲﾄﾙ・ﾃﾞｰﾀ行)が選択されているか(SelectedRow値が-1以外)
                If llngRow <> CMlngNoSelect Then

                    '@[貼り合わせTPALﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞのﾃﾞｰﾀ行が選択されているか
                    If .Rows.Fixed <= llngRow Then

                        '@選択行のﾃﾞｰﾀを戻す
                        txtTPALCarrier.Text = .GetData(llngRow, CMlngvsfUseTpalListColCarrierID)       'TPALｷｬﾘｱID
                        lblTPALLotID.Text = .GetData(llngRow, CMlngvsfUseTpalListColLotID)          'TPALﾛｯﾄID
                        txtChipOutQuantity.Text = .GetData(llngRow, CMlngvsfUseTpalListColOutNum)      '不良数
                        txtChipRestQuantity.Text = .GetData(llngRow, CMlngvsfUseTpalListColRestNum)    '残数

                        'NSYS 計算対象カラムの数値変換
                        Dim llngvsfUseTpalListColCoverNum As Integer
                        If IsNumeric(.GetData(llngRow, CMlngvsfUseTpalListColCoverNum)) Then
                            llngvsfUseTpalListColCoverNum = CLng(.GetData(llngRow, CMlngvsfUseTpalListColCoverNum))
                        End If

                        Dim llngvsfUseTpalListColOutNum As Integer
                        If IsNumeric(.GetData(llngRow, CMlngvsfUseTpalListColOutNum)) Then
                            llngvsfUseTpalListColOutNum = CLng(.GetData(llngRow, CMlngvsfUseTpalListColOutNum))
                        End If

                        Dim llngvsfUseTpalListColRestNum As Integer
                        If IsNumeric(.GetData(llngRow, CMlngvsfUseTpalListColRestNum)) Then
                            llngvsfUseTpalListColRestNum = CLng(.GetData(llngRow, CMlngvsfUseTpalListColRestNum))
                        End If

                        lblTPALChipQuantity.Text = Format$((llngvsfUseTpalListColCoverNum + _
                                                              llngvsfUseTpalListColOutNum + _
                                                              llngvsfUseTpalListColRestNum), CPstrDateFormatKanma)        '数量
                        lblLimitTime.Text = .GetData(llngRow, CMlngvsfUseTpalListColLimitTime)      '有効期限

                        mstrTpalLotLastUpdate = .GetData(llngRow, CMlngvsfUseTpalListColLotLastUpdate) 'TPALﾛｯﾄ最終更新日時

                        '@選択行のﾃﾞｰﾀを消す
                        '.SetData(llngRow, CMlngvsfUseTpalListColCarrierID, vbNullString)          'TPALｷｬﾘｱID
                        '.SetData(llngRow, CMlngvsfUseTpalListColLotID, vbNullString)              'TPALﾛｯﾄID
                        '.SetData(llngRow, CMlngvsfUseTpalListColCoverNum, vbNullString)           '貼数
                        '.SetData(llngRow, CMlngvsfUseTpalListColOutNum, vbNullString)             '不良数
                        '.SetData(llngRow, CMlngvsfUseTpalListColRestNum, vbNullString)            '残数
                        '.SetData(llngRow, CMlngvsfUseTpalListColLotLastUpdate, vbNullString)      'TPALﾛｯﾄ最終更新日時
                        '.SetData(llngRow, CMlngvsfUseTpalListColLimitTime, vbNullString)          '有効期限
                        '.SetData(llngRow, CMlngvsfUseTpalListColInsertFlag, vbNullString)         '登録ﾌﾗｸﾞ
                        .RemoveItem(llngRow)

                        '@選択行の退避
                        'llngSelectedRowNum(llngCnt) = llngCombListCnt
                    End If
                End If

                'NSYS RemoveItem方式へ変更
                ''@移動完了ﾌﾗｸﾞの初期化
                'lblnMoveCompleteFlag = False

                ''@移動完了ﾌﾗｸﾞが"False：未完了"の間はﾙｰﾌﾟ
                'Do While lblnMoveCompleteFlag <> True

                '    '@移動ﾃﾞｰﾀ有無ﾌﾗｸﾞが"False：なし"か(ﾃﾞｰﾀの移動が無かった場合)
                '    If lblnMoveDataFlag = False Then

                '        '@移動完了ﾌﾗｸﾞを"True：完了"をｾｯﾄ
                '        lblnMoveCompleteFlag = True
                '    Else
                '        '@移動ﾃﾞｰﾀ有無ﾌﾗｸﾞが"True：あり"の場合

                '        '@ﾙｰﾌﾟｶｳﾝﾀの初期化
                '        llngReMoveCnt = 0
                '    End If

                '    '@移動ﾃﾞｰﾀ有無ﾌﾗｸﾞの初期化
                '    lblnMoveDataFlag = False

                '    For llngReMoveCnt = 0 To .Rows.Count - 1

                '        '@現在行が最終行以外か
                '        If llngReMoveCnt <> .Rows.Count - 1 Then

                '            '@現在行のｷｬﾘｱIDがNULLか
                '            If .GetData(llngReMoveCnt, CMlngvsfUseTpalListColCarrierID) = vbNullString Then

                '                '@1つ下のﾃﾞｰﾀ行を現在行へ移動
                '                .SetData(llngReMoveCnt, CMlngvsfUseTpalListColCarrierID, _
                '                    .GetData(llngReMoveCnt + 1, CMlngvsfUseTpalListColCarrierID))           'TPALｷｬﾘｱID
                '                .SetData(llngReMoveCnt, CMlngvsfUseTpalListColLotID, _
                '                    .GetData(llngReMoveCnt + 1, CMlngvsfUseTpalListColLotID))               'TPALﾛｯﾄID
                '                .SetData(llngReMoveCnt, CMlngvsfUseTpalListColCoverNum, _
                '                    .GetData(llngReMoveCnt + 1, CMlngvsfUseTpalListColCoverNum))            '貼数
                '                .SetData(llngReMoveCnt, CMlngvsfUseTpalListColOutNum, _
                '                    .GetData(llngReMoveCnt + 1, CMlngvsfUseTpalListColOutNum))              '不良数
                '                .SetData(llngReMoveCnt, CMlngvsfUseTpalListColRestNum, _
                '                    .GetData(llngReMoveCnt + 1, CMlngvsfUseTpalListColRestNum))             '残数
                '                .SetData(llngReMoveCnt, CMlngvsfUseTpalListColLotLastUpdate, _
                '                    .GetData(llngReMoveCnt + 1, CMlngvsfUseTpalListColLotLastUpdate))       'TPALﾛｯﾄ最終更新日時
                '                .SetData(llngReMoveCnt, CMlngvsfUseTpalListColLimitTime, _
                '                    .GetData(llngReMoveCnt + 1, CMlngvsfUseTpalListColLimitTime))           '有効期限
                '                .SetData(llngReMoveCnt, CMlngvsfUseTpalListColInsertFlag, _
                '                    .GetData(llngReMoveCnt + 1, CMlngvsfUseTpalListColInsertFlag))          '登録ﾌﾗｸﾞ

                '                '@移動前の行が登録済みﾃﾞｰﾀか(登録ﾌﾗｸﾞ=0,NULL)
                '                If .GetData(llngReMoveCnt + 1, CMlngvsfUseTpalListColInsertFlag) <> CPstrOne Then

                '                    '@移動後の行でもｸﾞﾚｰ(文字)で表示
                '                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngEnableFalseColor" & llngReMoveCnt.ToString)
                '                    newStyle.ForeColor = SystemColors.ControlDark
                '                    Dim cellRange As CellRange = .GetCellRange(llngReMoveCnt, CMlngvsfGridTitleCol, llngReMoveCnt + 1, .Cols.Count - 1)
                '                    cellRange.Style = newStyle
                '                Else
                '                    '@登録候補(未登録)ﾃﾞｰﾀ(登録ﾌﾗｸﾞ=1)の場合

                '                    '@移動後の行でも黒(文字)で表示
                '                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngBlackColor" & llngReMoveCnt.ToString)
                '                    newStyle.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)
                '                    Dim cellRange As CellRange = .GetCellRange(llngReMoveCnt, CMlngvsfGridTitleCol, llngReMoveCnt + 1, .Cols.Count - 1)
                '                    cellRange.Style = newStyle
                '                End If

                '                '@移動後、移動ﾃﾞｰﾀ行を初期化する
                '                .SetData(llngReMoveCnt + 1, CMlngvsfUseTpalListColCarrierID, vbNullString)        'TPALｷｬﾘｱID
                '                .SetData(llngReMoveCnt + 1, CMlngvsfUseTpalListColLotID, vbNullString)            'TPALﾛｯﾄID
                '                .SetData(llngReMoveCnt + 1, CMlngvsfUseTpalListColCoverNum, vbNullString)         '貼数
                '                .SetData(llngReMoveCnt + 1, CMlngvsfUseTpalListColOutNum, vbNullString)           '不良数
                '                .SetData(llngReMoveCnt + 1, CMlngvsfUseTpalListColRestNum, vbNullString)          '残数
                '                .SetData(llngReMoveCnt + 1, CMlngvsfUseTpalListColLotLastUpdate, vbNullString)    'TPALﾛｯﾄ最終更新日時
                '                .SetData(llngReMoveCnt + 1, CMlngvsfUseTpalListColLimitTime, vbNullString)        '有効期限
                '                .SetData(llngReMoveCnt + 1, CMlngvsfUseTpalListColInsertFlag, vbNullString)       '登録ﾌﾗｸﾞ

                '                '@移動ﾃﾞｰﾀ有無ﾌﾗｸﾞに"True：あり"をｾｯﾄ
                '                lblnMoveDataFlag = True

                '                '@移動完了ﾌﾗｸﾞに"False：未完了"をｾｯﾄ
                '                lblnMoveCompleteFlag = False
                '            End If
                '        End If
                '    Next llngReMoveCnt

                '    '@最終行のﾃﾞｰﾀがNULLになるまでﾙｰﾌﾟ
                '    Do While .GetData(.Rows.Count - 1, CMlngvsfUseTpalListColCarrierID) = vbNullString
                '        '@行数の減算
                '        .Rows.Count = .Rows.Count - 1
                '    Loop
                'Loop

                '@№の振り直し
                For llngCnt = 1 To .Rows.Count - 1
                    .SetData(llngCnt, CMlngvsfUseTpalListColNo, llngCnt)
                Next llngCnt

                '@[貼り合わせTPALﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞのﾃﾞｰﾀ件数が"0"件か
                If .Rows.Count - 1 = 0 Then

                    '@各種ﾎﾞﾀﾝを無効にする
                    cmdUP.Enabled = False               '["▲"]
                    cmdDown.Enabled = False             '["▼"]
                    cmdMoveCancel.Enabled = False       '["<"]
                    cmdRegist.Enabled = False           '[確定]
                Else
                    '@[貼り合わせTPALﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞのﾃﾞｰﾀ件数が"0"件以外の場合

                    '@最終行が1ﾍﾟｰｼﾞMAX表示数内に収まっているか
                    If .Rows.Count - 1 < CMlngvsfGridRows Then

                        '@各種ﾎﾞﾀﾝを無効にする
                        cmdUP.Enabled = False           '["▲"]
                        cmdDown.Enabled = False         '["▼"]
                    End If
                End If

            End With

            '@=======================
            '@ 上下ｽｸﾛｰﾙﾎﾞﾀﾝ制御処理(ｸﾞﾘｯﾄﾞ共通化関数)
            '@=======================
            Call pubVsfDisp(vsfUseTpalList, cmdUP, cmdDown)

            '@=======================
            '@ 各種ﾁｯﾌﾟ数計算処理
            '@=======================
            Call prvCalcChipNum_Disp()


            With vsfUseTpalList

                '@選択行が登録済みﾃﾞｰﾀ(登録ﾌﾗｸﾞ=0,NULL)か
                'NSYS Or条件追加：データ行が無くなった場合
                If .Rows.Count -1 = 0 OrElse .GetData(.Row, CMlngvsfUseTpalListColInsertFlag) <> CPstrOne Then

                    '@["<"]ﾎﾞﾀﾝを無効にする
                    cmdMoveCancel.Enabled = False
                End If

            End With

            '@[不良数]、[残数]ﾃｷｽﾄを有効にする
            txtChipOutQuantity.Enabled = True       '[不良数]
            txtChipRestQuantity.Enabled = True      '[残数]

            '@=======================
            '@ 確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvTpalCombRegist_Set()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMoveCancel_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfUseTpalList_AfterSort
    '機　能：[貼り合わせTPALﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ｿｰﾄ後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/09/03 (Fri) 13:08:29 N.Kojima
    '更新日：2009/10/14 (Wed) 10:25:23 N.Kojima
    '備　考：
    '　　　：2005/07/25 (Mon) 15:48:18 N.Kojima     機能改造に伴い、大幅修正(削除)。ﾕｰｻﾞ要望№0061
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub vsfUseTpalList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfUseTpalList.AfterSort

        Try
            'BeforeSortで除外していたRowColChangeイベントを復帰
            AddHandler vsfUseTpalList.BeforeRowColChange, AddressOf vsfUseTpalList_BeforeRowColChange
            AddHandler vsfUseTpalList.EnterCell, AddressOf vsfUseTpalList_EnterCell

            'NSYS ソート前の選択行が有効行でない場合、ヘッダを選択行とする
            If vsfUseTpalListRowBeforeSort <  vsfUseTpalList.Rows.Fixed Then
                vsfUseTpalList.Row = 0
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfUseTpalList.Rows.Count <= vsfUseTpalList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ順を格納
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
            Call pubVsfAfterSort(vsfUseTpalList, CMlngvsfUseTpalListColNo & vbTab & _
                                    CMlngvsfUseTpalListColRestNum, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfUseTpalList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfUseTpalList_BeforeRowColChange
    '機　能：[貼り合わせTPALﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　行列変更前処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/07/25 (Mon) 15:48:01 N.Kojima
    '更新日：2009/10/14 (Wed) 10:25:26 N.Kojima
    '備　考：
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub vsfUseTpalList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfUseTpalList.BeforeRowColChange

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfUseTpalList.Rows.Count <= vsfUseTpalList.Rows.Fixed Then
                Return
            End If

            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行か
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then

                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ｷｰ：№)
                mtypChgSort.strKey = vsfUseTpalList.GetData(e.NewRange.r1, CMlngvsfUseTpalListColNo)
            End If

            '@=======================
            '@ 確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvTpalCombRegist_Set()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfUseTpalList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfUseTpalList_BeforeSort
    '機　能：[貼り合わせTPALﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ｿｰﾄ前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/09/03 (Fri) 13:08:17 N.Kojima
    '更新日：2009/10/14 (Wed) 10:25:19 N.Kojima
    '備　考：
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub vsfUseTpalList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfUseTpalList.BeforeSort

        Try
            'NSYS 不要なHandler処理を抑止
            RemoveHandler vsfUseTpalList.BeforeRowColChange, AddressOf vsfUseTpalList_BeforeRowColChange
            RemoveHandler vsfUseTpalList.EnterCell, AddressOf vsfUseTpalList_EnterCell
            vsfUseTpalListRowBeforeSort = vsfUseTpalList.Row

            'NSYS データ行がない場合は処理を抜ける
            If vsfUseTpalList.Rows.Count <= vsfUseTpalList.Rows.Fixed Then
                Return
            End If

            '@=======================
            '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfBeforeSort(vsfUseTpalList, CMlngvsfUseTpalListColNo & vbTab & _
                                    CMlngvsfUseTpalListColRestNum)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfUseTpalList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfUseTpalList_DblClick
    '機　能：[貼り合わせTPALﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　ﾀﾞﾌﾞﾙｸﾘｯｸ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/31 (Tue) 15:13:15 N.Kojima
    '更新日：2009/10/14 (Wed) 10:25:30 N.Kojima
    '備　考：
    '　　　：2007/01/22 (Mon) 17:01:35 N.Kojima     登録候補かどうかをﾌﾗｸﾞで判定するように修正。(案件№01734)
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub vsfUseTpalList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfUseTpalList.DoubleClick

        Dim llngRow     As Integer  '選択行

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfUseTpalList.Rows.Count <= vsfUseTpalList.Rows.Fixed Then
                Return
            End If

            With vsfUseTpalList

                '@選択行取得
                'llngRow = .Rows.Selected(llngCnt).Index
                llngRow = .Row

                '@選択行がﾃﾞｰﾀ行か
                If llngRow = .MouseRow Then

                    '@選択行の登録ﾌﾗｸﾞが"1：未登録ﾃﾞｰﾀ"か
                    If .GetData(llngRow, CMlngvsfUseTpalListColInsertFlag) = CPstrOne Then

                        '@=======================
                        '@ "<"ﾎﾞﾀﾝ押下処理
                        '@=======================
                        Call cmdMoveCancel_Click(sender,e)
                    End If
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfUseTpalList_DblClick"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfUseTpalList_EnterCell
    '機　能：[貼り合わせTPALﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/28 (Thu) 13:52:49 N.Kojima
    '更新日：2009/10/14 (Wed) 10:25:33 N.Kojima
    '備　考：
    '　　　：2007/01/22 (Mon) 17:01:35 N.Kojima     登録候補かどうかをﾌﾗｸﾞで判定するように修正。(案件№01734)
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub vsfUseTpalList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfUseTpalList.EnterCell

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfUseTpalList.Rows.Count <= vsfUseTpalList.Rows.Fixed Then
                Return
            End If

            With vsfUseTpalList

                '@選択行の登録ﾌﾗｸﾞが"0orNULL：登録ﾃﾞｰﾀ"か
                If .GetData(.Row, CMlngvsfUseTpalListColInsertFlag) <> CPstrOne Then

                    '@["<"]ﾎﾞﾀﾝを無効にする
                    cmdMoveCancel.Enabled = False
                Else
                    '@選択行の登録ﾌﾗｸﾞが"1：未登録ﾃﾞｰﾀ"の場合

                    '@["<"]ﾎﾞﾀﾝを有効にする
                    cmdMoveCancel.Enabled = True
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfUseTpalList_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：[上(▲)ｽｸﾛｰﾙ(TPAL貼り合わせ実績一覧用)]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/07 (Tue) 17:07:36 N.Kojima
    '更新日：2009/10/14 (Wed) 10:25:36 N.Kojima
    '備　考：
    '　　　：2004/10/06 (Wed) 16:41:13 H.Wajima     初期表示行設定処理削除
    '　　　：2005/07/25 (Mon) 13:12:28 N.Kojima     機能改造に伴い、大幅修正(削除)。ﾕｰｻﾞ要望№0061
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
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
            Call pubVsfCmdUp(vsfUseTpalList, cmdUP, cmdDown)

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
    '機　能：[下(▼)ｽｸﾛｰﾙ(TPAL貼り合わせ実績一覧用)]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/07 (Tue) 17:07:24 N.Kojima
    '更新日：2009/10/14 (Wed) 10:25:40 N.Kojima
    '備　考：
    '　　　：2004/10/06 (Wed) 16:41:27 H.Wajima     初期表示行設定処理削除
    '　　　；2005/07/25 (Mon) 13:12:52 N.Kojima     機能改造に伴い、大幅修正(削除)。ﾕｰｻﾞ要望№0061
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
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
            Call pubVsfCmdDown(vsfUseTpalList, cmdUP, cmdDown)

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

    '関数名：cmdRegist_Click
    '機　能：[確定]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/30 (Mon) 17:58:05 N.Kojima
    '更新日：2009/10/14 (Wed) 10:25:43 N.Kojima
    '備　考：
    '　　　：2004/12/01 (Wed) 13:13:46 S.Deguchi    ﾁｯﾌﾟの数量計算処理を別処理へ変更&画面終了処理追加
    '　　　：2005/01/07 (Fri) 12:43:45 S.Deguchi    画面終了処理(単体起動処理)を追加
    '　　　：2005/07/25 (Mon) 13:01:31 N.Kojima     機能改造に伴い、大幅修正(削除)。ﾕｰｻﾞ要望№0061
    '　　　：2005/10/12 (Wed) 14:36:47 S.Deguchi    単独起動時,貼り合わせ完了と途中で確定処理後の動作を分岐する。
    '　　　：2007/01/22 (Mon) 15:51:10 N.Kojima     貼合せ要求配列の初期化処理追加。(案件№01734)
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean          '戻り値
        Dim lstrLotLastUpdate       As String           'TFTﾛｯﾄ最終更新日時
        Dim lblnCoverFlag           As Boolean          '貼り合わせﾌﾗｸﾞ(True：完了、False：途中)

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@貼り合わせﾌﾗｸﾞの初期化
            lblnCoverFlag = False

            '@=======================
            '@ 確定処理前ﾁｪｯｸ
            '@=======================
            lblnAns = prvblnTpalComb_Chk()

            '@確定処理前ﾁｪｯｸ結果が"False：ﾁｪｯｸNG"か
            If lblnAns = False Then

                '@[確定]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdRegist)
                Exit Sub
            End If

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 作業者ID入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@作業者ID入力画面にて、ｷｬﾝｾﾙﾎﾞﾀﾝが押されたか
            If pblnCancel = True Then
                Exit Sub
            End If


            '@=======================
            '@ 確定送信用構造体への格納処理
            '@=======================
            Call prvCombStartListIn_Ins(mtypTpalCombStart)

            '@[貼残数]が"0"か
            If CLng(lblCoverRestQuantity.Text) = 0 Then

                '@貼り合わせﾌﾗｸﾞに"True：完了"をｾｯﾄ
                lblnCoverFlag = True
            End If


            '@作業終了画面にて使用するTFTﾛｯﾄの最終更新日時退避
            ptypCfkiRenkeiInfo.strLotLastUpdate = mstrLotLastUpdate

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, CMstrCmdRegistClick)

            '@=======================
            '@ TPAL貼り合わせ登録
            '@=======================
            lblnAns = pubblnLotTpalCombStart_Upd(CMstrlot_tpalcombstartVer, _
                                                 mtypTpalCombStart, _
                                                 lstrLotLastUpdate)


            '@要求配列を初期化
            mtypTpalCombStart.typTpalLotList = New List(Of TpalLotList)


            '@TPAL貼り合わせ登録結果が"True：登録成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, CMstrCmdRegistClick)

                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM2DI>$$TPAL貼り合わせ登録しました。キャリア[%1] ロット[%2]"のﾒｯｾｰｼﾞをｲﾝﾌｫﾒｰｼｮﾝﾊﾞｰに表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002D, txtCarrier.Text, lblLotID.Text)
                Call pubVsfInfo_Disp(pstrDMsg)

                '@ﾌｫｰﾑ起動区分が"True：子画面起動"か
                If pblnfrmxxEN01A0Kbn = True Then

                    '@=======================
                    '@ ﾌｫｰﾑ終了処理
                    '@=======================
                    Call cmdClose_Click(sender,e)
                Else
                    '@ﾌｫｰﾑ起動区分が"False：単独起動"の場合

                    '@貼り合わせﾌﾗｸﾞが"False：未完了"か
                    If lblnCoverFlag = False Then

                        '@=======================
                        '@ 各種初期化処理
                        '@=======================
                        Call prvFrmxxEN01A0_Init()                  'TFTﾛｯﾄ(ｷｬﾘｱ)情報の初期化
                        Call prvCombAbleTpalInfo_Init()             'TPAL貼り合わせ可能在庫情報の初期化     ⇒仕掛前ｶｾｯﾄﾌﾚｰﾑ
                        Call prvTpalInfo_Init()                     'TPALﾛｯﾄ情報の初期化                    ⇒仕掛前ｶｾｯﾄﾌﾚｰﾑ
                        Call prvVsfUseTpalList_Init()               'TPAL貼り合わせ一覧の初期化         　　⇒登録済ｶｾｯﾄﾌﾚｰﾑ

                        '@=======================
                        '@ ｷｬﾘｱID(TFT側)のValidate処理(画面情報再取得・再描画)
                        '@=======================
                        RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                        Call txtCarrier_Validate(sender,New CancelEventArgs(False))
                        AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                    Else
                        '@貼り合わせﾌﾗｸﾞが"True：完了"の場合

                        '@[ｷｬﾘｱID(TFT側)]ﾃｷｽﾄを初期化し、ﾌｫｰｶｽｾｯﾄ
                        txtCarrier.Text = vbNullString
                        Call pubSetFocus(txtCarrier)
                    End If

                    '@[貼り合わせTPALﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞのﾊｲﾗｲﾄを消す
                    vsfUseTpalList.HighLight = HighLightEnum.WithFocus
                End If
            Else
                '@TPAL貼り合わせ登録結果が"False：登録失敗"の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, CMstrCmdRegistClick)
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

    '関数名：cmdClear_Click
    '機　能：[取消]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/30 (Mon) 18:03:06 N.Kojima
    '更新日：2009/10/14 (Wed) 10:24:55 N.Kojima
    '備　考：
    '　　　：2004/10/27 (Wed) 17:15:24 N.Kasai      移動ﾎﾞﾀﾝ使用不可追加
    '　　　：2005/07/25 (Mon) 12:57:58 N.Kojima     機能改造に伴い、大幅修正(削除)。ﾕｰｻﾞ要望№0061
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub cmdClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClear.Click

        Dim lblnAns     As Boolean      '戻り値

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾚｽﾎﾟﾝｽ判定ﾌﾗｸﾞの初期化
            mblnResponseFlag = False

            '@=======================
            '@ 各種初期化処理
            '@=======================
            Call prvVsfUseTpalList_Init()   '[貼り合わせTPALﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ
            Call prvTpalInfo_Init()         'TPALﾛｯﾄ情報(仕掛前ｶｾｯﾄﾌﾚｰﾑ内)

            '@TPALｷｬﾘｱIDの初期化
            txtTPALCarrier.Text = vbNullString

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, CMstrCmdClearClick)

            '@ﾚｽﾎﾟﾝｽ判定ﾌﾗｸﾞに"True：ﾚｽﾎﾟﾝｽ計測中"をｾｯﾄ
            mblnResponseFlag = True

            '@=======================
            '@ 最新取得ﾎﾞﾀﾝ押下処理
            '@=======================
            Call cmdNowList_Click(sender,e)

            '@=======================
            '@ TPAL貼り合わせ実績情報取得
            '@=======================
            lblnAns = pubblnLotTpalCombResult_Sel(CMstrlot_tpalcombresultVer, _
                                                  lblLotID.Text, _
                                                  ptypLotprestate.strVaFlag, _
                                                  ptypLotprestate.strTpalClass, _
                                                  mtypCoverCompLot)

            '@TPAL貼り合わせ実績情報取得結果が"True：取得成功"か
            If lblnAns = True Then

                '@貼り合わせ済みTPALﾛｯﾄが0件か
                If mtypCoverCompLot.lngCoverCompLotListCnt < 0 Then

                    '@TPAL貼り合わせ可能在庫有無判定ﾌﾗｸﾞが"True：初期値(有り)"か
                    If mblnCombAbleTpalFlag = True Then

                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, CMstrCmdClearClick)
                    End If

                    Exit Sub
                End If
            Else
                '@TPAL貼り合わせ実績情報取得結果が"False：取得失敗"の場合

                '@TPAL貼り合わせ可能在庫有無判定ﾌﾗｸﾞが"True：初期値(有り)"か
                If mblnCombAbleTpalFlag = True Then

                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, CMstrCmdClearClick)
                End If

                Exit Sub
            End If

            '@TPAL貼り合わせ可能在庫有無判定ﾌﾗｸﾞが"True：初期値(有り)"か
            If mblnCombAbleTpalFlag = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, CMstrCmdClearClick)
            End If


            '@=======================
            '@ [貼り合わせTPALﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ表示処理
            '@=======================
            Call prvVsfUseTpalList_Disp()

            '@=======================
            '@ 各種ﾁｯﾌﾟ数計算処理
            '@=======================
            Call prvCalcChipNum_Disp()

            '@=======================
            '@ 確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvTpalCombRegist_Set()

            '@各種ﾎﾞﾀﾝを無効にする
            cmdMove.Enabled = False         '[">"]
            cmdMoveCancel.Enabled = False   '["<"]

            '@[ｷｬﾘｱID(TPAL側)]ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtTPALCarrier)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClear_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTreatChip_Click
    '機　能：[ﾁｯﾌﾟ状態変更]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/06/18 (Thu) 15:01:38 Y.Yoneyama
    '更新日：2009/10/14 (Wed) 10:25:47 N.Kojima
    '備　考：
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub cmdTreatChip_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTreatChip.Click

        Dim ltypOldCommonInfo   As CommonInfo   '引継ぎ構造体の退避領域

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計(通信中or処理中)か
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

            '@引継ぎ構造体の退避
            ltypOldCommonInfo = ptypCommonInfo

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            pblnFormLoad = False

            '@ﾌｫｰﾑ起動区分に"True：親画面からの起動"をｾｯﾄ
            pblnfrmxxCM0080Kbn = True

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ ﾁｯﾌﾟ状態変更登録画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0080.Instance = New frmxxCM0080()


            '@ﾌｫｰﾑﾌﾗｸﾞが"False：起動失敗"か
            If pblnFormLoad = False Then

                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                frmxxCM0080.Instance = Nothing

                '@引継ぎｷｬﾘｱ情報の復元、ﾌｫｰﾑ起動区分の初期化
                ptypCommonInfo = ltypOldCommonInfo
                pblnfrmxxCM0080Kbn = False

                Exit Sub
            End If


            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ ﾁｯﾌﾟ状態変更登録画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0080.Instance.ShowDialog(Me)
            frmxxCM0080.Instance = Nothing


            '@引継ぎｷｬﾘｱ情報の復元、ﾌｫｰﾑ起動区分の初期化
            ptypCommonInfo = ltypOldCommonInfo
            pblnfrmxxCM0080Kbn = False

            '@引継ぎ情報のｷｬﾘｱIDをｾｯﾄ
            txtCarrier.Text = ptypCommonInfo.strCarrierId

            '@[ｷｬﾘｱID(TFT側)]ﾃｷｽﾄにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrier)

            '@=======================
            '@ ｷｬﾘｱIDのValidate処理
            '@=======================
            RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
            Call txtCarrier_Validate(sender,New CancelEventArgs(True))
            AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdTreatChip_Click"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCFCarrierSelect_Click
    '機　能：[CFｷｬﾘｱ選択]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/06/22 (Mon) 10:26:16 Y.Yoneyama
    '更新日：2009/10/14 (Wed) 10:25:50 N.Kojima
    '備　考：
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

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計(通信中or処理中)か
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If

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

                .strUnloaderCarrier = ptypLotprestate.strUnloaderCarrierID  'TFTｷｬﾘｱID(Unloader)
                .strLoaderCarrier = ptypLotprestate.strCarrierId            'TFTｷｬﾘｱID(Loader)
                .strLotID = ptypLotprestate.strLotID                        'TFTﾛｯﾄID
                .strFlowClass = ptypLotprestate.strFlowClass                '種別
                .strPdId = ptypLotprestate.strPdId                          '機種
                .strStatus = ptypLotprestate.strNowST                       '状態
                .strWfNum = ptypLotprestate.strWfNum                        '数量(WF)
                .strChipNum = ptypLotprestate.strChipQuantity               '数量(CHIP)
                .strCFCarrierID = ptypLotprestate.strCFCarrierID            'CFｷｬﾘｱID
                .strWpID = ptypLotprestate.strWpID                          'WPID
                .strOpID = ptypLotprestate.strOpID                          '大工程
                .strStepID = ptypLotprestate.strStepID                      '小工程
            End With

            pstrVaFlag = ptypLotprestate.strVaFlag                          '無機ﾌﾗｸﾞ
            pstrTpalClass = ptypLotprestate.strTpalClass                    'TPAL設定


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


            '@各種Public変数の初期化(保険：子画面で初期化してるので基本は問題ない)
            pstrVaFlag = vbNullString               '無機ﾌﾗｸﾞ
            pstrTpalClass = vbNullString            'TPAL設定


            '@子画面でTPALｷｬﾘｱが選択されたか
            If pstrCFCarrierID <> vbNullString Then

                '@[ｷｬﾘｱID(TPAL側)]にｾｯﾄ
                txtTPALCarrier.Text = pstrCFCarrierID
            End If

            '@[ｷｬﾘｱID(TPAL側)]にﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtTPALCarrier)

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

    '関数名：cmdClose_Click
    '機　能：[閉じる]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/30 (Mon) 17:40:33 N.Kojima
    '更新日：2009/10/14 (Wed) 10:24:31 N.Kojima
    '備　考：
    '　　　：2004/12/27 (Mon) 10:12:15 S.Deguchi　  装置別ﾛｯﾄ一覧への引継ぎ処理を追加
    '　　　：2005/01/14 (Fri) 09:00:38 H.Wajima　   ﾌｫｰﾑ起動区分の判定処理を追加(作業終了から起動時に作業終了に戻らない)
    '　　　：2005/02/15 (Tue) 13:25:37 N.Kojima     戻り先画面の判定を追加(改善№512)
    '　　　：2005/07/21 (Thu) 17:50:12 N.Kojima     機能改造に伴う、大幅修正(大幅削除)。ﾕｰｻﾞ要望№0061
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim ltypCommonInfo  As CommonInfo       'PG間ﾃﾞｰﾀ受け渡し用

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@引継ぎ情報のｷｬﾘｱIDがNULL以外か
            If ptypCommonInfo.strCarrierId <> vbNullString Then

                '@ﾌｫｰﾑ起動区分が"True：子画面起動"か
                If pblnfrmxxEN01A0Kbn = True Then

                    '@∇∇∇∇∇∇∇∇∇∇∇
                    '@ ｱﾝﾛｰﾄﾞ処理
                    '@∇∇∇∇∇∇∇∇∇∇∇
                    Me.Close()
                Else
                    '@単独起動の場合

                    '@=======================
                    '@ 親画面切り替え引継ぎ制御処理
                    '@=======================
                    Call pubChangeScreen_Set(Me)
                End If
            Else
                '@引継ぎ情報のｷｬﾘｱIDがNULLの場合

                '@=======================
                '@ 終了処理
                '@=======================
                Call publngEnd_Proc(CPstrKeyEN01A0, ltypCommonInfo)
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
    '関数名：prvFrmxxEN01A0_Init
    '機　能：画面情報(TFTﾛｯﾄ(ｷｬﾘｱ)情報)初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/31 (Tue) 13:27:24 N.Kojima
    '更新日：2009/10/14 (Wed) 10:25:53 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 14:31:32 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2004/11/22 (Mon) 09:59:33 S.Deguchi    不良枚数欄の初期化処理を追加(最新取得ﾎﾞﾀﾝを非活性にする)
    '　　　：2005/07/21 (Thu) 16:56:11 N.Kojima     機能改造に伴い、大幅修正(大幅削除)。ﾕｰｻﾞ要望№0061
    '　　　：2008/06/11 (Wed) 14:34:39 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub prvFrmxxEN01A0_Init()

        Dim lstrFormTitle       As String       'ﾌｫｰﾑﾀｲﾄﾙ用

        Try

            '@=======================
            '@ 機能関連情報取得
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN01A0, lstrFormTitle)

            '@取得機能関連情報からﾌｫｰﾑｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle

            '@各種ﾓｼﾞｭｰﾙ変数の初期化
            mstrCarrierID = vbNullString                    'ｷｬﾘｱID退避用
            mstrLotLastUpdate = vbNullString                'ﾛｯﾄ最終更新日時


            '@-----------------------
            '@ 表示の初期化
            '@-----------------------
            '@各ｺﾝﾄﾛｰﾙの初期化(ﾍｯﾀﾞｰ部)
            lblLotID.Text = vbNullString                 'ﾛｯﾄID
            lblFlowClass.Text = vbNullString             '流動区分
            lblChipNum.Text = vbNullString               '数量
            lblOpID.Text = vbNullString                  '大工程ID
            lblStartDayTime.Text = vbNullString          '開始日時
            lblPdID.Text = vbNullString                  '機種名
            lblS.Text = vbNullString                     '特殊特性
            lblStatus.Text = vbNullString                '状態
            lblStepID.Text = vbNullString                '小工程ID
            lblLotManager.Text = vbNullString            'ﾛｯﾄ担当
            lblTimeLimit.Text = vbNullString             '時間制約

            '@各ｺﾝﾄﾛｰﾙの初期化(仕掛前ｶｾｯﾄﾌﾚｰﾑ内)
            txtTPALCarrier.Text = vbNullString              'ｷｬﾘｱID(TPAL側)
            lblTPALLotID.Text = vbNullString             'TPALﾛｯﾄID
            lblTPALChipQuantity.Text = vbNullString      '数量(TPALﾛｯﾄ)
            lblLimitTime.Text = vbNullString             '有効期限
            txtChipOutQuantity.Text = vbNullString          '不良数
            txtChipRestQuantity.Text = vbNullString         '残数
            lblNowDate.Text = vbNullString               '情報取得日時
            lblInvTPALLotCnt.Text = vbNullString         '貼り合わせ可能TPAL総ﾛｯﾄ数
            lblInvTPALChipCnt.Text = vbNullString        '貼り合わせ可能TPAL総ﾁｯﾌﾟ数

            '@貼り合わせ
            lblCoverCnt.Text = vbNullString

            '@各ｺﾝﾄﾛｰﾙの初期化(登録済ｶｾｯﾄﾌﾚｰﾑ内)
            lblCoverRestQuantity.Text = vbNullString     '貼残数
            lblTotalUseNum.Text = vbNullString           '使用計
            lblTotalCoverNum.Text = vbNullString         '貼計
            lblTotalOutNum.Text = vbNullString           '不良計


            '@-----------------------
            '@ 状態の初期化
            '@-----------------------
            '@各種ｺﾝﾄﾛｰﾙを無効にする(仕掛前ｶｾｯﾄﾌﾚｰﾑ内)
            txtTPALCarrier.Enabled = False                  'ｷｬﾘｱID(TPAL側)
            txtChipOutQuantity.Enabled = False              '不良数
            txtChipRestQuantity.Enabled = False             '残数
            cmdNowList.Enabled = False                      '最新取得ﾎﾞﾀﾝ

            '@各種ﾎﾞﾀﾝを無効にする
            cmdMove.Enabled = False                         '">"
            cmdMoveCancel.Enabled = False                   '"<"

            '@各種ｺﾝﾄﾛｰﾙを無効にする(登録済ｶｾｯﾄﾌﾚｰﾑ内)
            vsfUseTpalList.Enabled = False                  '貼り合わせTPALﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ
            cmdUP.Enabled = False                           '上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ
            cmdDown.Enabled = False                         '下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ

            '@各種ﾎﾞﾀﾝを無効にする(ﾌｯﾀｰ部)
            cmdRegist.Enabled = False                       '確定ﾎﾞﾀﾝ
            cmdClear.Enabled = False                        '取消ﾎﾞﾀﾝ
            cmdTreatChip.Enabled = False                    'ﾁｯﾌﾟ状態変更ﾎﾞﾀﾝ
            cmdCFCarrierSelect.Enabled = False              'CFｷｬﾘｱ選択ﾎﾞﾀﾝ

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN01A0_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvTpalInfo_Init
    '機　能：仕掛前ｶｾｯﾄﾌﾚｰﾑ(TPALﾛｯﾄ情報)初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/25 (Mon) 13:21:22 N.Kojima
    '更新日：2009/10/14 (Wed) 10:25:57 N.Kojima
    '備　考：
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub prvTpalInfo_Init()

        Try

            '@-----------------------
            '@ 仕掛前ｶｾｯﾄﾌﾚｰﾑ
            '@-----------------------
            '@各種ｺﾝﾄﾛｰﾙの初期化
            lblTPALLotID.Text = vbNullString             '[TPALﾛｯﾄID]ﾗﾍﾞﾙ
            lblTPALChipQuantity.Text = vbNullString      '[数量(TPALﾁｯﾌﾟ)]ﾗﾍﾞﾙ
            lblLimitTime.Text = vbNullString             '[有効期限]ﾗﾍﾞﾙ
            txtChipOutQuantity.Text = vbNullString          '[不良数]ﾃｷｽﾄ
            txtChipRestQuantity.Text = vbNullString         '[残数]ﾃｷｽﾄ

            '@各種ｺﾝﾄﾛｰﾙを無効にする
            txtChipOutQuantity.Enabled = False              '[不良数]ﾃｷｽﾄ
            txtChipRestQuantity.Enabled = False             '[残数]ﾃｷｽﾄ
            cmdMove.Enabled = False                         '[">"]ﾎﾞﾀﾝ
            cmdMoveCancel.Enabled = False                   '["<"]ﾎﾞﾀﾝ

            '@ﾓｼﾞｭｰﾙ変数の初期化
            mblnCancelFlag = False                          'ｷｬﾝｾﾙﾌﾗｸﾞ
            mstrChipOutQuantity = vbNullString              '不良数退避領域
            mstrChipRestQuantity = vbNullString             '残数退避領域

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvTpalInfo_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCombAbleTpalInfo_Init
    '機　能：TPAL貼り合わせ可能ﾛｯﾄ情報初期化処理
    '引　数：lblnCfCarrSelectButtonFlag     ：[CFｷｬﾘｱ選択]ﾎﾞﾀﾝの制御ﾌﾗｸﾞ(True：無効、False：条件による)
    '戻り値：なし
    '作成日：2005/07/25 (Mon) 13:23:34 N.Kojima
    '更新日：2009/10/14 (Wed) 10:26:00 N.Kojima
    '備　考：
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub prvCombAbleTpalInfo_Init(ByRef Optional lblnCfCarrSelectButtonFlag As Boolean = False)

        Try

            '@各種ﾗﾍﾞﾙの初期化
            lblNowDate.Text = vbNullString               '情報取得日時
            lblInvTPALLotCnt.Text = vbNullString         '貼り合わせ可能TPAL総ﾛｯﾄ数
            lblInvTPALChipCnt.Text = vbNullString        '貼り合わせ可能TPAL総ﾁｯﾌﾟ数

            '@貼り合わせ
            lblCoverCnt.Text = vbNullString

            '@各種ｺﾝﾄﾛｰﾙを無効にする(仕掛前ｶｾｯﾄﾌﾚｰﾑ内)
            txtTPALCarrier.Enabled = False                  'ｷｬﾘｱID(TPAL側)
            txtChipOutQuantity.Enabled = False              '不良数
            txtChipRestQuantity.Enabled = False             '残数

            '@各種ﾎﾞﾀﾝを無効にする
            cmdMove.Enabled = False                         '">"
            cmdMoveCancel.Enabled = False                   '"<"

            '@各種ｺﾝﾄﾛｰﾙを無効にする(登録済ｶｾｯﾄﾌﾚｰﾑ内)
            vsfUseTpalList.Enabled = False                  '貼り合わせTPALﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ
            cmdUP.Enabled = False                           '上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ
            cmdDown.Enabled = False                         '下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ

            '@各種ﾎﾞﾀﾝを無効にする(ﾌｯﾀｰ部)
            cmdRegist.Enabled = False                       '確定
            cmdClear.Enabled = False                        '取消
            cmdTreatChip.Enabled = False                    'ﾁｯﾌﾟ状態変更

            '@[CFｷｬﾘｱ選択]ﾎﾞﾀﾝの制御ﾌﾗｸﾞが"False：条件による"か
            If lblnCfCarrSelectButtonFlag = False Then

                '@無機ﾌﾗｸﾞが"1：無機"(無機ﾛｯﾄ)、かつTPAL区分が"NULL以外：指定あり"か
                If ptypLotprestate.strVaFlag = CPstrOne And _
                    ptypLotprestate.strTpalClass <> vbNullString Then
            
                    '@[CFｷｬﾘｱ選択]ﾎﾞﾀﾝを有効にする
                    cmdCFCarrierSelect.Enabled = True
                Else
                    '@有機ﾛｯﾄ、またはTPAL区分の指定なしの場合
            
                    '@[CFｷｬﾘｱ選択]ﾎﾞﾀﾝを無効にする
                    cmdCFCarrierSelect.Enabled = False
                End If
            Else
                '@[CFｷｬﾘｱ選択]ﾎﾞﾀﾝの制御ﾌﾗｸﾞが"True：無効"の場合

                '@[CFｷｬﾘｱ選択]ﾎﾞﾀﾝを無効にする
                cmdCFCarrierSelect.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCombAbleTpalInfo_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfUseTpalList_Init
    '機　能：TPAL貼り合わせ一覧初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/31 (Tue) 12:12:49 N.Kojima
    '更新日：2009/10/14 (Wed) 10:26:03 N.Kojima
    '備　考：
    '　　　：2005/07/21 (Thu) 17:19:54 N.Kojima     機能改造に伴い、大幅修正(大幅削除)。ﾕｰｻﾞ要望№0061
    '　　　：2007/01/22 (Mon) 17:01:35 N.Kojima     登録候補かどうかをﾌﾗｸﾞで判定するように修正。(案件№01734)
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub prvVsfUseTpalList_Init()

        Try

            '@ｿｰﾄ保持用構造体の初期化
            With mtypChgSort

                .lngCnt = 0                               'ﾃﾞｰﾀ格納件数
                .typChgSortList = New List(Of ChgSortList)'ﾃﾞｰﾀ配列
                .blnChgWidth = False                      '列幅変更ﾌﾗｸﾞ(False：未変更)
                .strKey = vbNullString                    'ｶﾚﾝﾄ行検索ｷｰ
            End With

            '@-----------------------
            '@ [貼り合わせTPALﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞの初期化
            '@-----------------------
            With vsfUseTpalList

                'NSYS 再描画抑止
                .Redraw = False

                '.Clear
                RemoveHandler vsfUseTpalList.BeforeRowColChange,AddressOf vsfUseTpalList_BeforeRowColChange
                RemoveHandler vsfUseTpalList.EnterCell,AddressOf vsfUseTpalList_EnterCell
                .Rows.Count = .Rows.Fixed                  '表示行
                .Row = 0                                   'NSYS 初期状態はヘッダーを選択
                AddHandler vsfUseTpalList.BeforeRowColChange,AddressOf vsfUseTpalList_BeforeRowColChange
                AddHandler vsfUseTpalList.EnterCell,AddressOf vsfUseTpalList_EnterCell
                .SelectionMode = SelectionModeEnum.Row     '選択ﾓｰﾄﾞ
                '.FillStyle = flexFillRepeat               'ｶﾚﾝﾄｾﾙ全て
                .FocusRect = FocusRectEnum.None            'ﾌｫｰｶｽ枠
                .ScrollBars = ScrollBars.None              'ｽｸﾛｰﾙﾊﾞｰ
                '.AllowBigSelection = False                '選択
                '.AllowSelection = False                   'ﾏｳｽでｾﾙ範囲選択不可
                .Font = New Font(CMstrGridFontName, CMlngvsfSlotFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont) 'ﾌｫﾝﾄｻｲｽﾞ
                .HighLight = HighLightEnum.Always          'ﾊｲﾗｲﾄ

                '@文字表示位置設定
                .Cols(CMlngvsfUseTpalListColNo).TextAlign = TextAlignEnum.RightCenter           '№(右中央)
                .Cols(CMlngvsfUseTpalListColCarrierID).TextAlign = TextAlignEnum.LeftCenter     'ｷｬﾘｱID(左中央)
                .Cols(CMlngvsfUseTpalListColLotID).TextAlign = TextAlignEnum.LeftCenter         'TPALﾛｯﾄID(左中央)
                .Cols(CMlngvsfUseTpalListColCoverNum).TextAlign = TextAlignEnum.RightCenter     '貼数(右中央)
                .Cols(CMlngvsfUseTpalListColOutNum).TextAlign = TextAlignEnum.RightCenter       '不良数(右中央)
                .Cols(CMlngvsfUseTpalListColRestNum).TextAlign = TextAlignEnum.RightCenter      '残数(右中央)
                .Cols(CMlngvsfUseTpalListColLotLastUpdate).TextAlign = TextAlignEnum.LeftCenter 'TPALﾛｯﾄ最終更新日時(左中央:非表示)
                .Cols(CMlngvsfUseTpalListColLimitTime).TextAlign = TextAlignEnum.LeftCenter     '有効期限(左中央:非表示)
                .Cols(CMlngvsfUseTpalListColInsertFlag).TextAlign = TextAlignEnum.LeftCenter    '登録ﾌﾗｸﾞ(左中央:非表示)

                '@非表示設定
                .Cols(CMlngvsfUseTpalListColLotLastUpdate).Visible = False                      'TPALﾛｯﾄ最終更新日時(左中央:非表示)
                .Cols(CMlngvsfUseTpalListColLimitTime).Visible = False                          '有効期限(左中央:非表示)
                .Cols(CMlngvsfUseTpalListColInsertFlag).Visible = False                         '登録ﾌﾗｸﾞ(左中央:非表示)

                'NSYS DataType設定
                .Cols(CMlngvsfUseTpalListColCoverNum).DataType = GetType(Int32)                 '貼数
                .Cols(CMlngvsfUseTpalListColOutNum).DataType = GetType(Int32)                   '不良数
                .Cols(CMlngvsfUseTpalListColRestNum).DataType = GetType(Int32)                  '残数

                '@ﾀｲﾄﾙ行の各種設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_vsfUseTpalList_Header")
                Dim cellRange As CellRange = .GetCellRange(CMlngvsfGridTitleRow, CMlngvsfUseTpalListColNo, CMlngvsfGridTitleRow, .Cols.Count - 1)
                newStyle.TextAlign = TextAlignEnum.CenterCenter                 '中央表示
                newStyle.ForeColor = Color.Yellow                               '文字色(黄色)
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)  '背景色(紺色)
                cellRange.Style = newStyle

                .Rows(CMlngvsfGridTitleRow).Height = CMlngvsfGridHHeight          '高さ

                '@列幅、ﾀｲﾄﾙ文字設定
                .Cols(CMlngvsfUseTpalListColNo).Width = CMlngvsfUseTpalListWNo                      '№
                .SetData(CMlngvsfGridTitleRow, CMlngvsfUseTpalListColNo, CMstrvsfUseTpalListTNo)    '№

                .Cols(CMlngvsfUseTpalListColCarrierID).Width = CMlngvsfUseTpalListWCarrierID                      'ｷｬﾘｱID
                .SetData(CMlngvsfGridTitleRow, CMlngvsfUseTpalListColCarrierID, CMstrvsfUseTpalListTCarrierID)    'ｷｬﾘｱID

                .Cols(CMlngvsfUseTpalListColLotID).Width = CMlngvsfUseTpalListWLotID                              'ﾛｯﾄID
                .SetData(CMlngvsfGridTitleRow, CMlngvsfUseTpalListColLotID, CMstrvsfUseTpalListTLotID)            'ﾛｯﾄID

                .Cols(CMlngvsfUseTpalListColCoverNum).Width = CMlngvsfUseTpalListWCoverNum                        '貼数
                .SetData(CMlngvsfGridTitleRow, CMlngvsfUseTpalListColCoverNum, CMstrvsfUseTpalListTCoverNum)      '貼数

                .Cols(CMlngvsfUseTpalListColOutNum).Width = CMlngvsfUseTpalListWOutNum                            '不良数
                .SetData(CMlngvsfGridTitleRow, CMlngvsfUseTpalListColOutNum, CMstrvsfUseTpalListTOutNum)          '不良数

                .Cols(CMlngvsfUseTpalListColRestNum).Width = CMlngvsfUseTpalListWRestNum                          '残数
                .SetData(CMlngvsfGridTitleRow, CMlngvsfUseTpalListColRestNum, CMstrvsfUseTpalListTRestNum)        '残数

                .Cols(CMlngvsfUseTpalListColLotLastUpdate).Width = CMlngvsfUseTpalListWLotLastUpdate                      'TPALﾛｯﾄ最終更新日時
                .SetData(CMlngvsfGridTitleRow, CMlngvsfUseTpalListColLotLastUpdate, CMlngvsfUseTpalListTLotLastUpdate)    'TPALﾛｯﾄ最終更新日時

                .Cols(CMlngvsfUseTpalListColLimitTime).Width = CMlngvsfUseTpalListWLimitTime                      '有効期限
                .SetData(CMlngvsfGridTitleRow, CMlngvsfUseTpalListColLimitTime, CMlngvsfUseTpalListTLimitTime)    '有効期限

                .Cols(CMlngvsfUseTpalListColInsertFlag).Width = CMlngvsfUseTpalListWInsertFlag                    '登録ﾌﾗｸﾞ
                .SetData(CMlngvsfGridTitleRow, CMlngvsfUseTpalListColInsertFlag, CMlngvsfUseTpalListTInsertFlag)  '登録ﾌﾗｸﾞ

                '@[貼り合わせTPALﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞを無効にする
                '.Enabled = False

                'NSYS 再描画再開
                .Redraw = True

                '@ｽｸﾛｰﾙﾎﾞﾀﾝを無効にする
                cmdUP.Enabled = False       '上(▲)
                cmdDown.Enabled = False     '下(▼)

                '@先頭行を最下行とする(最下行と言っても初期化しているのでﾀｲﾄﾙ行になる)
                .TopRow = .Rows.Count - 1

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfUseTpalList_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvFrmxxEN01A0_Disp
    '機　能：ﾛｯﾄ情報(TFT側)表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/30 (Mon) 18:29:03 N.Kojima
    '更新日：2009/10/14 (Wed) 10:26:10 N.Kojima
    '備　考：
    '　　　：2004/09/09 (Thu) 21:07:47 Y.Yamagishi  時間制限表示変更(不具合改善№693)
    '　　　：2004/09/24 (Fri) 11:40:39 Y.Yamagishi  制限時間以上の場合文字色を青に変更(不具合改善№825)
    '　　　：2004/10/29 (Fri) 11:17:32 Y.Yamagishi  TFT基板のﾁｯﾌﾟ数がNULLの場合残数に0を入れる
    '　　　：2005/07/25 (Mon) 11:50:47 N.Kojima     機能改造に伴い、大幅修正(削除)。ﾕｰｻﾞ要望№0061
    '　　　：2006/06/08 (Thu) 15:18:48 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2008/06/11 (Wed) 14:35:17 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub prvFrmxxEN01A0_Disp()

        Try

            '@ﾛｯﾄ情報(TFT側)の表示
            With ptypLotprestate

                lblLotID.Text = .strLotID                                                'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass                                        '流動区分
                'ﾁｯﾌﾟ数
                If IsNumeric(.strChipQuantity) Then
                    lblChipNum.Text = Format$(CLng(.strChipQuantity), CPstrDateFormatKanma)
                Else
                    lblChipNum.Text = .strChipQuantity
                End If
                lblOpID.Text = .strOpID                                                  '大工程ID
                '処理開始日時
                If IsDate(.strStartTime) Then
                    lblStartDayTime.Text = Format$(CDate(.strStartTime), CPstrDateFormat)
                Else
                    lblStartDayTime.Text = .strStartTime
                End If
                lblPdID.Text = .strPdId                                                  '機種ID
                lblS.Text = .strSpecialFlg                                               '特殊特性
                lblStatus.Text = .strNowST                                               '状態
                lblStepID.Text = .strStepID                                              '小工程ID
                lblLotManager.Text = .strEngEmpName                                      'ﾛｯﾄ担当

                '@-----------------------
                '@ 時間制約関連の表示
                '@-----------------------
                '@制限時間がNULL以外か
                If .strLimitTime <> vbNullString Then

                    '@制約時間が"0分"以上か
                    If CLng(.strLimitTime) >= 0 Then

                        '@制約ﾀｲﾌﾟが"1：制限時間以下"、または"3：処理時間制限以下"か
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then

                            '@[時間制限]ﾗﾍﾞﾙに「ﾌｫｰﾏｯﾄ変換(##,##0)+"分"」を右寄せで表示
                            If IsNumeric(.strLimitTime) Then
                                lblTimeLimit.Text = Format$(CLng(.strLimitTime), CPstrDateFormatKanma) & CPstrh
                            Else
                                lblTimeLimit.Text = .strLimitTime & CPstrh
                            End If
                            lblTimeLimit.TextAlign = ContentAlignment.TopRight

                            '@警告時間がNULL以外か
                            If .strWarnTime <> vbNullString Then

                                '@警告時間が0分未満(超過)、かつ制限時間が0分以上(未超過)か
                                If CLng(.strWarnTime) < 0 And CLng(.strLimitTime) >= 0 Then

                                    '@ﾌｫﾝﾄｶﾗｰを紫に変更
                                    lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple) '紫色(警告時間内)
                                Else
                                    '@警告時間が0分以上(未超過)、または制限時間が0分未満(超過)の場合
                                    '@ ※設定上「警告時間 < 制限時間」しか不可なのであり得ない？

                                    '@ﾌｫﾝﾄｶﾗｰを黒に変更
                                    lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CMlngBlackColor)    '黒(通常)
                                End If
                            End If
                        End If

                    Else
                        '@制約時間が"0分"未満(ﾏｲﾅｽ)の場合

                        '@[時間制限]ﾗﾍﾞﾙに右寄せ・文字色：赤で表示
                        lblTimeLimit.TextAlign = ContentAlignment.TopRight
                        lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed)

                        '@制約ﾀｲﾌﾟが"1：制限時間以下"、または"3：処理時間制限以下"か
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then

                            '@[時間制限]ﾗﾍﾞﾙに「ﾌｫｰﾏｯﾄ変換(##,##0)+"分"」で表示
                            If IsNumeric(.strLimitTime) Then
                                lblTimeLimit.Text = Format(CLng(.strLimitTime), CPstrDateFormatKanma) & CPstrh
                            Else
                                lblTimeLimit.Text = .strLimitTime & CPstrh
                            End If
                        End If

                        '@制約ﾀｲﾌﾟが"2：制限時間以上"か
                        If .strRestrictTypeID = CPstrRestrictTypeID2 Then

                            '@[時間制限]ﾗﾍﾞﾙにﾏｲﾅｽ記号を取って「ﾌｫｰﾏｯﾄ変換(##,##0)+"分"」で表示
                            If IsNumeric(.strLimitTime) Then
                                lblTimeLimit.Text = Replace(Format(CLng(.strLimitTime), CPstrDateFormatKanma), CPstrReplaceMinus, vbNullString) & CPstrh
                            Else
                                lblTimeLimit.Text = Replace(.strLimitTime, CPstrReplaceMinus, vbNullString) & CPstrh
                            End If
                        End If
                    End If
                End If

                '@(TFTﾛｯﾄの)ﾛｯﾄ最終更新日時をﾓｼﾞｭｰﾙ変数に格納
                mstrLotLastUpdate = .strLotLastUpdate


                '@-----------------------
                '@ 貼り合わせを表示
                '@-----------------------
                '@無機ﾌﾗｸﾞが"1：無機"(無機ﾛｯﾄ)か
                If .strVaFlag = CPstrOne Then

                    '@TPAL区分が"L"or"R"or"BL"or"BR"か(Bはﾊﾞｯﾁ)
                    '@※左右貼り合せ指定ありの場合
                    If .strTpalClass = CPstrTpalJLeft Or _
                        .strTpalClass = CPstrTpalJRight Or _
                        .strTpalClass = CPstrTpalJBatchLeft Or _
                        .strTpalClass = CPstrTpalJBatchRight Then

                        '@[貼り合わせ]ﾗﾍﾞﾙに(TPAL_CLASS設定がある場合のみ値が入る)TPAL貼合数を表示
                        If IsNumeric(.strTpalChipQuantity) Then
                            lblCoverCnt.Text = Format$(CLng(.strTpalChipQuantity), CPstrDateFormatKanma)
                        Else
                            lblCoverCnt.Text = .strTpalChipQuantity
                        End If

                    Else
                        '@左右貼り合せ指定なしの場合(指定なし、同一ﾊﾞｯﾁのみが条件の場合)

                        '@[貼り合わせ]ﾗﾍﾞﾙに全貼り合わせﾁｯﾌﾟ数を表示
                        If IsNumeric(.strChipQuantity) Then
                            lblCoverCnt.Text = Format$(CLng(.strChipQuantity), CPstrDateFormatKanma)
                        Else
                            lblCoverCnt.Text = .strChipQuantity
                        End If
                    End If
                Else
                    '@無機ﾌﾗｸﾞが"1：無機"以外(有機ﾛｯﾄ)の場合

                    '@[貼り合わせ]ﾗﾍﾞﾙに全貼り合わせﾁｯﾌﾟ数を表示
                    If IsNumeric(.strChipQuantity) Then
                        lblCoverCnt.Text = Format$(CLng(.strChipQuantity), CPstrDateFormatKanma)
                    Else
                        lblCoverCnt.Text = .strChipQuantity
                    End If

                End If

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxEN01A0_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfUseTpalList_Disp
    '機　能：貼り合わせTPALﾛｯﾄ一覧(登録済ｶｾｯﾄﾌﾚｰﾑ)表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/01 (Wed) 15:14:23 N.Kojima
    '更新日：2009/10/14 (Wed) 10:26:14 N.Kojima
    '備　考：
    '　　　：2005/07/25 (Mon) 11:59:03 N.Kojima     機能改造に伴い、大幅修正(削除)。ﾕｰｻﾞ要望№0061
    '　　　：2007/01/22 (Mon) 17:01:35 N.Kojima     登録候補かどうかをﾌﾗｸﾞで判定するように修正。(案件№01734)
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub prvVsfUseTpalList_Disp()

        Dim llngDoCnt   As Integer  'ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngCnt     As Integer  'ｿｰﾄ配列ﾙｰﾌﾟ用ｶｳﾝﾀ

        Try

            '@-----------------------
            '@ 貼り合わせTPALﾛｯﾄ一覧(登録済ｶｾｯﾄﾌﾚｰﾑ)
            '@-----------------------
            With vsfUseTpalList

                '@貼り合わせ済みﾛｯﾄがあるか
                If mtypCoverCompLot.lngCoverCompLotListCnt <> 0 Then

                    'NSYS 選択行退避
                    Dim llngSelectedRow As Integer = .Row

                    .Redraw = False                                               '描画ﾛｯｸ
                    RemoveHandler vsfUseTpalList.BeforeRowColChange,AddressOf vsfUseTpalList_BeforeRowColChange
                    RemoveHandler vsfUseTpalList.EnterCell,AddressOf vsfUseTpalList_EnterCell
                    .Rows.Count = .Rows.Fixed                                     '行数初期化(ｸﾞﾘｯﾄﾞの初期化)
                    .Rows.Count = mtypCoverCompLot.lngCoverCompLotListCnt + 1     '行数設定(貼り合わせ済みﾛｯﾄ数)
                    .Row = llngSelectedRow                                        'NSYS 選択行を戻す
                    AddHandler vsfUseTpalList.BeforeRowColChange,AddressOf vsfUseTpalList_BeforeRowColChange
                    AddHandler vsfUseTpalList.EnterCell,AddressOf vsfUseTpalList_EnterCell

                    '@ﾙｰﾌﾟｶｳﾝﾀの初期化
                    llngDoCnt = 1

                    Do While .Rows.Count > llngDoCnt

                        .SetData(llngDoCnt, CMlngvsfUseTpalListColNo, llngDoCnt)                             '№

                        .SetData(llngDoCnt, CMlngvsfUseTpalListColCarrierID, _
                            mtypCoverCompLot.typCoverCompLotList(llngDoCnt - 1).strTpalCarrierID)            'TPALｷｬﾘｱID

                        .SetData(llngDoCnt, CMlngvsfUseTpalListColLotID, _
                            mtypCoverCompLot.typCoverCompLotList(llngDoCnt - 1).strTpalLotId)                'TPALﾛｯﾄID

                        .SetData(llngDoCnt, CMlngvsfUseTpalListColCoverNum, _
                            mtypCoverCompLot.typCoverCompLotList(llngDoCnt - 1).strChipCombQuantity)         '貼数

                        .SetData(llngDoCnt, CMlngvsfUseTpalListColOutNum, _
                            mtypCoverCompLot.typCoverCompLotList(llngDoCnt - 1).strChipOutQuantity)          '不良数

                        .SetData(llngDoCnt, CMlngvsfUseTpalListColRestNum, _
                            mtypCoverCompLot.typCoverCompLotList(llngDoCnt - 1).strChipRestQuantity)         '残数

                        .SetData(llngDoCnt, CMlngvsfUseTpalListColInsertFlag, CPstrZero)      '登録ﾌﾗｸﾞ(=0)

                        '@ﾌｫﾝﾄの色変更(ｸﾞﾚｰ色)
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_ForeColor_CMlngEnableFalseColor" & llngDoCnt.ToString)
                        newStyle.ForeColor = SystemColors.ControlDark
                        Dim cellRange As CellRange = .GetCellRange(llngDoCnt, CMlngvsfGridTitleCol, llngDoCnt, .Cols.Count - 1)
                        cellRange.Style = newStyle

                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngDoCnt).Height = CMlngvsfGridHeight

                        '@ﾙｰﾌﾟｶｳﾝﾀをｶｳﾝﾄｱｯﾌﾟ
                        llngDoCnt = llngDoCnt + 1
                    Loop

                    '@書式設定
                    .Cols(CMlngvsfUseTpalListColCarrierID).TextAlign = TextAlignEnum.LeftCenter    'TPALｷｬﾘｱID(左寄せ中央揃え)
                    .Cols(CMlngvsfUseTpalListColLotID).TextAlign = TextAlignEnum.LeftCenter        'TPALﾛｯﾄID(左寄せ中央揃え)
                    .Cols(CMlngvsfUseTpalListColCoverNum).TextAlign = TextAlignEnum.RightCenter    '貼数(右寄せ中央揃え)
                    .Cols(CMlngvsfUseTpalListColOutNum).TextAlign = TextAlignEnum.RightCenter      '不良数(右寄せ中央揃え)
                    .Cols(CMlngvsfUseTpalListColRestNum).TextAlign = TextAlignEnum.RightCenter     '残数(右寄せ中央揃え)
                    .Cols(CMlngvsfUseTpalListColLotLastUpdate).TextAlign = TextAlignEnum.LeftCenter'TPALﾛｯﾄ最終更新日時(非表示)(左寄せ中央揃え)
                    .Cols(CMlngvsfUseTpalListColLimitTime).TextAlign = TextAlignEnum.LeftCenter    '有効期限(非表示)(左寄せ中央揃え)
                    .Cols(CMlngvsfUseTpalListColInsertFlag).TextAlign = TextAlignEnum.LeftCenter   '登録ﾌﾗｸﾞ(非表示)(左寄せ中央揃え)


                    '@-----------------------
                    '@ ｿｰﾄ関連処理
                    '@-----------------------
                    '@ｿｰﾄ配列にﾃﾞｰﾀがあるか
                    If mtypChgSort.lngCnt > 0 Then

                        For llngCnt = 0 To mtypChgSort.lngCnt - 1

                            '@該当列をｿｰﾄする
                            RemoveHandler vsfUseTpalList.BeforeRowColChange,AddressOf vsfUseTpalList_BeforeRowColChange
                            RemoveHandler vsfUseTpalList.EnterCell,AddressOf vsfUseTpalList_EnterCell
                            .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder,mtypChgSort.typChgSortList(llngCnt).lngCol)
                            AddHandler vsfUseTpalList.BeforeRowColChange,AddressOf vsfUseTpalList_BeforeRowColChange
                            AddHandler vsfUseTpalList.EnterCell,AddressOf vsfUseTpalList_EnterCell
                        Next llngCnt
                    End If

                    '@ｿｰﾄ検索ｷｰがNULL以外か
                    If mtypChgSort.strKey <> vbNullString Then

                        For llngCnt = .Rows.Fixed To .Rows.Count - 1

                            '@ｿｰﾄ検索ｷｰの№と現在行の№が同じか
                            If .GetData(llngCnt, CMlngvsfUseTpalListColNo) = mtypChgSort.strKey Then

                                '@一致行を選択状態にする
                                .Row = llngCnt

                                '@=======================
                                '@ ｿｰﾄ前のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                '@=======================
                                Call pubVsfBeforeSort(vsfUseTpalList, CMlngvsfUseTpalListColNo & vbTab & _
                                                        CMlngvsfUseTpalListColRestNum)

                                '@=======================
                                '@ ｿｰﾄ後のｶﾚﾝﾄKey値の格納(ｸﾞﾘｯﾄﾞ共通仕様)
                                '@=======================
                                Call pubVsfAfterSort(vsfUseTpalList, CMlngvsfUseTpalListColNo & vbTab & _
                                                        CMlngvsfUseTpalListColRestNum, cmdUP, cmdDown)

                                Exit For
                            End If
                        Next llngCnt
                    End If

                    '@描画する
                    .Redraw = True

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
                    If .TopRow + CMlngvsfGridRows >= .Rows.Count Then

                        '@下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝを無効にする
                        cmdDown.Enabled = False
                    Else
                        '@表示先頭行+1ﾍﾟｰｼﾞの最大表示行数が全行数より小さいか

                        '@下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝを有効にする
                        cmdDown.Enabled = True
                    End If

                    '@ｸﾞﾘｯﾄﾞを有効にする
                    .Enabled = True

                    '@=======================
                    '@ 各種ﾁｯﾌﾟ数計算処理
                    '@=======================
                    Call prvCalcChipNum_Disp()

                Else
                    '@貼り合わせ済みﾛｯﾄが0件(ない)場合

                    '@各数量ﾗﾍﾞﾙの表示
                    lblTotalCoverNum.Text = CPstrZero                    '貼計
                    lblTotalOutNum.Text = CPstrZero                      '不良計
                    lblTotalUseNum.Text = CPstrZero                      '使用計

                    If IsNumeric(lblCoverCnt.Text) Then
                        lblCoverRestQuantity.Text = Format$(CLng(lblCoverCnt.Text), CPstrDateFormatKanma)  '貼残数
                    Else
                        lblCoverRestQuantity.Text = lblCoverCnt.Text  '貼残数
                    End If

                    'NSYS 0件の場合はグリッド無効
                    .Enabled = False
                End If

            End With

            '@[取消]ﾎﾞﾀﾝを有効にする
            cmdClear.Enabled = True

            '@無機ﾌﾗｸﾞが"1：無機"(無機ﾛｯﾄ)、かつTPAL区分が"NULL以外：左右指定あり"か
            If ptypLotprestate.strVaFlag = CPstrOne And _
                ptypLotprestate.strTpalClass <> vbNullString Then

                '@CFｷｬﾘｱ選択ﾎﾞﾀﾝを有効にする
                cmdCFCarrierSelect.Enabled = True
            Else
                '@無機ﾌﾗｸﾞが"0：有機"(有機ﾛｯﾄ)、またはTPAL区分が"NULL：指定なし"の場合

                '@CFｷｬﾘｱ選択ﾎﾞﾀﾝを無効にする
                cmdCFCarrierSelect.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfUseTpalList_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCalcChipNum_Disp
    '機　能：各種ﾁｯﾌﾟ数計算処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/26 (Tue) 08:57:51 N.Kojima
    '更新日：2009/10/14 (Wed) 10:26:25 N.Kojima
    '備　考：
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Function prvCalcChipNum_Disp() As Boolean

        Dim llngTotalCombNum        As Integer      '貼計
        Dim llngTotalOutNum         As Integer      '不良計
        Dim llngTotalUseNum         As Integer      '使用計
        Dim llngTotalCombRestNum    As Integer      '貼残計
        Dim llngCnt                 As Integer      'ｶｳﾝﾄ

        Try
            
            With vsfUseTpalList
                
                For llngCnt = 1 To .Rows.Count - 1
                
                    '@ﾃﾞｰﾀ(貼り合わせ一覧、貼り合わせ)がNULLではないことを確認
                    If .GetData(llngCnt, CMlngvsfUseTpalListColCoverNum) <> vbNullString And _
                        .GetData(llngCnt, CMlngvsfUseTpalListColCoverNum) <> vbNullString And _
                        lblCoverCnt.Text <> vbNullString Then

                        '@貼計(= Σ貼数(貼り合わせ実績))
                        llngTotalCombNum = llngTotalCombNum + CLng(.GetData(llngCnt, CMlngvsfUseTpalListColCoverNum))
                        
                        '@不良計(= Σ不良数(貼り合わせ実績))
                        llngTotalOutNum = llngTotalOutNum + CLng(.GetData(llngCnt, CMlngvsfUseTpalListColOutNum))

        '@↓2005/07/28 (Thu) 13:53:52 N.Kojima **************************************************
        '@復活の可能性あり(2005/07/27 kojima)
        '''                '@残計(= Σ残数(貼り合わせ実績))
        '''                llngTotalRestNum = llngTotalRestNum + CLng(.Cell(flexcpText, llngCnt, CMlngvsfUseTpalListColRestNum))
        '@↑2005/07/28 (Thu) 13:53:52 N.Kojima **************************************************

                    End If

                Next llngCnt
                
                '@使用計(= 貼計 + 不良計)
                llngTotalUseNum = llngTotalCombNum + llngTotalOutNum
                    
                '@貼残数(貼り合わせ － 貼計)
                llngTotalCombRestNum = CLng(lblCoverCnt.Text) - llngTotalCombNum
            
            End With
            
            '@各数量表示
            lblTotalCoverNum.Text = Format$(llngTotalCombNum, CPstrDateFormatKanma)            '貼計
            lblTotalOutNum.Text = Format$(llngTotalOutNum, CPstrDateFormatKanma)               '不良計
            lblTotalUseNum.Text = Format$(llngTotalUseNum, CPstrDateFormatKanma)               '使用計
            lblCoverRestQuantity.Text = Format$(llngTotalCombRestNum, CPstrDateFormatKanma)    '貼残数
        '@↓2005/07/28 (Thu) 13:53:44 N.Kojima **************************************************
        '@復活の可能性あり(2005/07/27 kojima)
        '''    lblTotalRestNum.Caption = Format$(llngTotalRestNum, CPstrDateFormatKanma)             '残計
        '@↑2005/07/28 (Thu) 13:53:44 N.Kojima **************************************************

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCalcChipNum_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvTpalCombRegist_Set
    '機　能：確定ﾎﾞﾀﾝ制御処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/01 (Wed) 13:49:01 N.Kojima
    '更新日：2009/10/14 (Wed) 10:26:17 N.Kojima
    '備　考：
    '　　　：2004/11/22 (Mon) 13:41:39 S.Deguchi    ﾁｯﾌﾟ残数に不良ﾁｯﾌﾟ入力数を加算して判定をするように修正。
    '　　　：2005/08/01 (Mon) 13:24:49 N.Kojima     機能改造に伴い、大幅修正(削除)。ﾕｰｻﾞ要望№0061
    '　　　：2007/01/22 (Mon) 17:01:35 N.Kojima     登録候補かどうかをﾌﾗｸﾞで判定するように修正。(案件№01734)
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub prvTpalCombRegist_Set()

        Dim llngCnt     As Integer  'ｶｳﾝﾄ

        Try

            With vsfUseTpalList

                '@[貼り合わせTPALﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞに貼り合わせ候補TPALﾛｯﾄが存在するか
                If .Rows.Count - 1 > 0 Then

                    For llngCnt = 1 To .Rows.Count - 1

                        '@検索行の登録ﾌﾗｸﾞが"1：未登録"か
                        If .GetData(llngCnt, CMlngvsfUseTpalListColInsertFlag) = CPstrOne Then

                            '@[確定]ﾎﾞﾀﾝを有効にし、ﾙｰﾌﾟ抜け
                            cmdRegist.Enabled = True
                            Exit For
                        Else
                            '@[確定]ﾎﾞﾀﾝを無効にする
                            cmdRegist.Enabled = False
                        End If
                    Next llngCnt
                Else
                    '@貼り合わせ候補TPALﾛｯﾄが存在しない場合

                    '@[確定]ﾎﾞﾀﾝを無効にする
                    cmdRegist.Enabled = False
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvTpalCombRegist_Set"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnTpalComb_Chk
    '機　能：TPAL貼り合わせ登録時の画面項目ﾁｪｯｸ(確定処理前ﾁｪｯｸ)
    '引　数：なし
    '戻り値：True：ﾁｪｯｸOK、False：ﾁｪｯｸNG
    '作成日：2004/08/31 (Tue) 15:16:56 N.Kojima
    '更新日：2009/10/14 (Wed) 10:26:06 N.Kojima
    '備　考：例外処理も含む
    '　　　：2004/11/22 (Mon) 13:56:31 S.Deguchi    不良ﾁｯﾌﾟ数の加算処理を追加
    '　　　：2005/07/25 (Mon) 13:14:31 N.Kojima     機能改造に伴い、大幅修正(削除)。ﾕｰｻﾞ要望№0061
    '　　　：2007/01/22 (Mon) 15:26:16 N.Kojima     例外が発生し、Longｷｬｽﾄ値=NULLで確定処理を行うとｼｽﾃﾑｴﾗｰになる件の予防策を追加。(案件№)
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Function prvblnTpalComb_Chk() As Boolean

        Try

            '@======================================================================================
            '@　★当Functionの処理概要
            '@　　①[貼残数]、[貼計]、[貼り合わせ]がNULL以外であることをﾁｪｯｸ
            '@　　②[貼計] <= [貼り合わせ]、[貼残数] >= 0であることをﾁｪｯｸ
            '@======================================================================================

            '@戻り値の初期化
            prvblnTpalComb_Chk = False

            '@-----------------------
            '@ 必要数量の有無ﾁｪｯｸ
            '@-----------------------
            '@[貼残数]、[貼計]、[貼り合わせ]の何れかがNULLか
            If lblCoverRestQuantity.Text = vbNullString Or _
                lblTotalCoverNum.Text = vbNullString Or _
                lblCoverCnt.Text = vbNullString Then

                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM0LE>$$画面の表示にて例外的なエラーが発生しました。
                '@          $一旦画面を開き直して、再度、入力・確定を行なってください。
                '@          $それでもエラーになる場合は、システム担当者に連絡してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000L)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                Exit Function
            End If


            '@-----------------------
            '@ 数量関係のﾁｪｯｸ
            '@-----------------------
            '@[貼計] > [貼り合わせ]か
            If CLng(lblTotalCoverNum.Text) > CLng(lblCoverCnt.Text) Then

                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM2LW>$$貼り合わせ可能枚数[%1]を超えています。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                If IsNumeric(lblCoverCnt.Text) Then
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002L, Format$(CLng(lblCoverCnt.Text), CPstrDateFormatKanma))
                Else
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002L, lblCoverCnt.Text)
                End If
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            Else
                '@[貼計] <= [貼り合わせ]の場合

                '@[貼残数] < 0 か
                If CLng(lblCoverRestQuantity.Text) < 0 Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@"<TRM2LW>$$貼り合わせ可能枚数[%1]を超えています。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                    If IsNumeric(lblCoverCnt.Text) Then
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002L, Format$(CLng(lblCoverCnt.Text), CPstrDateFormatKanma))
                    Else
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002L, lblCoverCnt.Text)
                    End If
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Else
                    '@[貼残数] >= 0 の場合

                    '@戻り値に"True：ﾁｪｯｸOK"をｾｯﾄ
                    prvblnTpalComb_Chk = True
                End If
            End If

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnTpalComb_Chk"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvCombStartListIn_Ins
    '機　能：確定ﾒｯｾｰｼﾞ送信情報格納処理
    '引　数：ltypTpalCombStart()：要求構造体
    '戻り値：なし
    '作成日：2005/07/25 (Mon) 18:52:59 N.Kojima
    '更新日：2009/10/14 (Wed) 10:26:21 N.Kojima
    '備　考：
    '　　　：2007/01/22 (Mon) 17:01:35 N.Kojima     登録候補かどうかをﾌﾗｸﾞで判定するように修正。(案件№01734)
    '　　　：2009/10/14 (Wed) 10:19:05 N.Kojima     案件№03791のついでにｿｰｽ整備。
    Private Sub prvCombStartListIn_Ins(ByRef ltypTpalCombStart As TpalCombStart)

        Dim llngGrigDataCnt         As Integer      '[貼り合わせTPALﾛｯﾄ一覧]ｸﾞﾘｯﾄﾞ用ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngArrayCnt            As Integer      '配列用ﾙｰﾌﾟｶｳﾝﾀ
        Dim llngRegistDataCnt       As Integer      '登録ﾃﾞｰﾀ数ｶｳﾝﾀ

        Try

            '@***********************
            '@ 送信ﾃﾞｰﾀ格納
            '@***********************
            With ltypTpalCombStart

                .strMsgVer = CMstrlot_tpalcombstartVer      'Msgﾊﾞｰｼﾞｮﾝ
                .strSbID = CPstrSBID2A0                     'SBID
                .strLotID = lblLotID.Text                'TFTﾛｯﾄID
                .strEmpID = pstrUserID                      '作業者ID
                .strLotLastUpdate = mstrLotLastUpdate       'TFTﾛｯﾄ最終更新日時


                For llngArrayCnt = 1 To vsfUseTpalList.Rows.Count - 1

                    '@現在行の登録ﾌﾗｸﾞが"1：未登録"か
                    If vsfUseTpalList.GetData(llngArrayCnt, CMlngvsfUseTpalListColInsertFlag) = CPstrOne Then

                        '@登録ﾃﾞｰﾀ数ｶｳﾝﾀを+1する
                        llngRegistDataCnt = llngRegistDataCnt + 1
                    End If
                Next llngArrayCnt


                '@配列用ﾙｰﾌﾟｶｳﾝﾀの初期化
                llngArrayCnt = 0

                '@配列の再定義
                .typTpalLotList = New List(Of TpalLotList)

                For llngGrigDataCnt = 1 To vsfUseTpalList.Rows.Count - 1

                    'NSYS 登録用構造体初期化
                    Dim typTpalLotListTmp As TpalLotList = New TpalLotList

                    '@現在行の登録ﾌﾗｸﾞが"1：未登録"か
                    If vsfUseTpalList.GetData(llngGrigDataCnt, CMlngvsfUseTpalListColInsertFlag) = CPstrOne Then

                        If IsNumeric(vsfUseTpalList.GetData(llngGrigDataCnt,CMlngvsfUseTpalListColLotID)) Then
                            typTpalLotListTmp.strTpalLotId = _
                                Format$(CLng(vsfUseTpalList.GetData(llngGrigDataCnt,CMlngvsfUseTpalListColLotID)), CPstrNoKanmaFormat)    '使用TPALﾛｯﾄID
                        Else
                            typTpalLotListTmp.strTpalLotId = _
                                vsfUseTpalList.GetData(llngGrigDataCnt, CMlngvsfUseTpalListColLotID)                                      '使用TPALﾛｯﾄID
                        End If

                        If IsNumeric(vsfUseTpalList.GetData(llngGrigDataCnt,CMlngvsfUseTpalListColCoverNum)) Then
                            typTpalLotListTmp.strChipQuantity = _
                                Format$(CLng(vsfUseTpalList.GetData(llngGrigDataCnt, CMlngvsfUseTpalListColCoverNum)), CPstrNoKanmaFormat)'貼数ﾁｯﾌﾟ数
                        Else
                            typTpalLotListTmp.strChipQuantity = _
                                vsfUseTpalList.GetData(llngGrigDataCnt, CMlngvsfUseTpalListColCoverNum)                                   '貼数ﾁｯﾌﾟ数
                        End If

                        If IsNumeric(vsfUseTpalList.GetData(llngGrigDataCnt, CMlngvsfUseTpalListColOutNum)) Then
                            typTpalLotListTmp.strChipOutQuantity = _
                                Format$(CLng(vsfUseTpalList.GetData(llngGrigDataCnt, CMlngvsfUseTpalListColOutNum)), CPstrNoKanmaFormat)  '不良ﾁｯﾌﾟ数
                        Else
                            typTpalLotListTmp.strChipOutQuantity = _
                                vsfUseTpalList.GetData(llngGrigDataCnt, CMlngvsfUseTpalListColOutNum)                                     '不良ﾁｯﾌﾟ数
                        End If

                        typTpalLotListTmp.strLotLastUpdate = vsfUseTpalList.GetData(llngGrigDataCnt,CMlngvsfUseTpalListColLotLastUpdate)  'TPALﾛｯﾄ最終更新日時

                        'NSYS 編集済み構造体を追加
                        .typTpalLotList.Add(typTpalLotListTmp)

                        '@配列用ﾙｰﾌﾟｶｳﾝﾀをｲﾝｸﾘﾒﾝﾄ
                        llngArrayCnt = llngArrayCnt + 1
                    End If

                Next llngGrigDataCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCombStartListIn_Ins"
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


    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles frCoverInfo.Paint, frInvTPALInfo.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfUseTpalList.BeforeDoubleClick

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
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles txtCarrier.Enter, txtTPALCarrier.Enter, txtChipOutQuantity.Enter, _
                                                                       txtChipRestQuantity.Enter, cmdMove.Enter, cmdMoveCancel.Enter, _
                                                                       vsfUseTpalList.Enter, cmdUP.Enter, cmdDown.Enter,cmdNowList.Enter, _
                                                                       cmdClose.Enter, cmdCFCarrierSelect.Enter, cmdTreatChip.Enter, cmdClear.Enter, cmdRegist.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '閉じるボタンの場合は自動Validate = OFF
            Case cmdClose.Name,cmdClear.Name
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
            '上記以外は自動Validate = ON
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

End Class
