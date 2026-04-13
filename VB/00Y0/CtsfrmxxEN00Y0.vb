'ﾌｧｲﾙ名：xxEN00Y0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：特殊流動　メインフォーム
'作成日：2004/08/23 (Mon) 10:03:07 M.Miura
'更新日：2014/11/25 (Tue) 09:16:51 T.Oide
'備　考：
'　　　：2007/07/26 (Thu) 10:59:39 N.Kasai  ｿｰｽ整備
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00Y0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00Y0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00Y0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00Y0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00Y0)
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
    'Private Const CMstrLocalVersion                 As String = "15.00"
	Private Const CMstrLocalVersion                 As String = "16.00"

    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN00Y0  'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    '@↓2020/01/15 (Wed) 13:01:50 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_curstateVer              As String = "03.04"         'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer              As String = "04.00"         'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 13:01:50 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrlot_nextsteplistVer          As String = "03.01"         'ﾛｯﾄ次工程取得
    Private Const CMstrlot_waferlistVer             As String = "02.05"         'ﾛｯﾄWF情報取得(新)
    Private Const CMstrlot_reworksetVer             As String = "06.00"         '特殊流動登録
    Private Const CMstrlot_reworksetdirectVer       As String = "03.01"         'ﾛｯﾄ分割(一括移載)
    Private Const CMstrcarrcurstateVer              As String = "05.02"         'ｷｬﾘｱ状態確認
    Private Const CMstrmas_altroutelistVer          As String = "01.00"         '代替ﾙｰﾄ(ﾘﾜｰｸ/追加流動)一覧
	Private Const CMstrlot_chkdoublejpdVer			As String = "01.00"	        '蒸着2回対応対象機種ﾁｪｯｸ

    '@vsfSlotMapの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfSlotMapColSlot            As Integer = 0              'ｽﾛｯﾄ
    Private Const CMlngvsfSlotMapColCheck           As Integer = 1              'ﾁｪｯｸﾎﾞｯｸｽ
    Private Const CMlngvsfSlotMapColWFID            As Integer = 2              'WFID
    '@↓2019/11/18 (Mon) 18:26:40 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngvsfSlotMapColGRB             As Integer = 3              'GRB
    '@↑2019/11/18 (Mon) 18:26:40 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@vsfSlotMapの定数宣言(表示幅)
    Private Const CMlngvsfSlotMapColWSlot           As Integer = 25             'ｽﾛｯﾄ
    Private Const CMlngvsfSlotMapColWCheck          As Integer = 18             'ﾁｪｯｸﾎﾞｯｸｽ
    Private Const CMlngvsfSlotMapColWWFID           As Integer = 95             'WFID
    '@↓2019/11/18 (Mon) 18:28:16 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngvsfSlotMapColWGRB            As Integer = 30             'GRB
    '@↑2019/11/18 (Mon) 18:28:16 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@vsfSlotMapの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfSlotMapColTSlot           As String = ""              'ｽﾛｯﾄ
    Private Const CMstrvsfSlotMapColTCheck          As String = ""              'ﾁｪｯｸﾎﾞｯｸｽ
    Private Const CMstrvsfSlotMapColTWFID           As String = "WFID"          'WFID
    '@↓2019/11/18 (Mon) 18:28:29 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrvsfSlotMapColTGRB            As String = "GRB"           'GRB
    '@↑2019/11/18 (Mon) 18:28:29 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@ｽﾛｯﾄﾏｯﾌﾟ基本設定
    Private Const CMlngvsfSlotMapRows               As Integer = 26             'ｽﾛｯﾄﾏｯﾌﾟの行数
    '@↓2019/11/18 (Mon) 18:29:27 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMlngvsfSlotMapCols               As Integer = 3              'ｶﾗﾑ数
    Private Const CMlngvsfSlotMapCols               As Integer = 4              'ｶﾗﾑ数
    '@↑2019/11/18 (Mon) 18:29:27 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngvsfSlotMapHHeight            As Integer = 27             'ﾍｯﾀﾞｰの高さ
    Private Const CMlngvsfSlotMapHeight             As Integer = 38             '1ｽﾛｯﾄの高さ
    Private Const CMlngvsfSlotFontSize              As Integer = 12             'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngSlotNo10Row                  As Integer = 17             '最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№10の行番号
    Private Const CMlngSlotNo16Row                  As Integer = 11             '最大ｽﾛｯﾄ数25の時のｽﾛｯﾄ№16の行番号
    Private Const CMlngvsfSlotPageRows              As Integer = 10             '1頁の行数

    '@ｸﾞﾘｯﾄﾞの初期値定数宣言
    Private Const CMstrGridFontName                 As String = "ＭＳ ゴシック" 'ｸﾞﾘｯﾄﾞのﾌｫﾝﾄ名
    Private Const CMlngGridFixedCols                As Integer = 0              'ｸﾞﾘｯﾄﾞのFixedCol
    Private Const CMlngGridFixedRows                As Integer = 1              'ｸﾞﾘｯﾄﾞのFixedRow
    Private Const CMlngGridTitleHeight              As Integer = 20             'ﾍｯﾀﾞｰの高さ
    Private Const CMlngGridRowHeight                As Integer = 18             '1明細の高さ

    Private Const CMlngGridRowTitle                 As Integer = 0              'ﾀｲﾄﾙ行(行)
    Private Const CMstrDefaultStep                  As String = "○"            'ﾃﾞﾌｫﾙﾄ小工程
    Private Const CMstrDaitaiStep                   As String = "　"            '代替小工程
    Private Const CMstrStepDivision0                As Integer = 0              '0：代替工程
    Private Const CMstrStepDivision1                As Integer = 1              '1：ﾃﾞﾌｫﾙﾄ工程

    '@vsfNextStepInfoの定数宣言(ｶﾗﾑ)
    Private Const CMlngNextStepInfoColOpID          As Integer = 0              '大工程ID
    Private Const CMlngNextStepInfoColStepID        As Integer = 1              '小工程ID
    Private Const CMlngNextStepInfoColDefault       As Integer = 2              'ﾃﾞﾌｫﾙﾄ
    Private Const CMlngNextStepInfoColWpName        As Integer = 3              'WPID

    '@vsfNextStepInfoの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrNextStepInfoColTOpID         As String = "次大工程"
    Private Const CMstrNextStepInfoColTStepID       As String = "次小工程"
    Private Const CMstrNextStepInfoColTDefault      As String = "ﾃﾞﾌｫﾙﾄ"
    Private Const CMstrNextStepInfoColTWpName       As String = "装置名"

    Private Const CMlngNextStepInfoFontSize         As Integer = 11             '特殊流動先次工程ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngNextStepListIndex            As Integer = 0              '最終工程判定用ｲﾝﾃﾞｯｸｽ

    Private Const CMlngGridColWidthOpID             As Integer = 174            '大工程ID
    Private Const CMlngGridColWidthStepID           As Integer = 174            '小工程ID
    Private Const CMlngGridColWidthDefault          As Integer = 62             'ﾃﾞﾌｫﾙﾄ
    Private Const CMlngGridColWidthWpName           As Integer = 229            'WPID

    '@特殊流動分類のｵﾌﾟｼｮﾝﾎﾞﾀﾝ
    Private Const CMlngoptSPFlow0                   As Integer = 0              'ﾘﾜｰｸ
    Private Const CMlngoptSPFlow1                   As Integer = 1              '追加流動

    Private Const CMlngoptDivFlag0                  As Integer = 0              '分割無
    Private Const CMlngoptDivFlag1                  As Integer = 1              '分割有

    Private Const CMlngSideScrollOnFlag             As Integer = 1              '横ｽｸﾛｰﾙ活性化
    Private Const CMlngSideScrollOffFlag            As Integer = 2              '横ｽｸﾛｰﾙ非活性化

    Private Const CMstrRouteIDFlag0                 As String = "0"             'ﾘﾜｰｸ/追加流動両方設定可
    Private Const CMstrRouteIDFlag1                 As String = "1"             'ﾘﾜｰｸのみ設定可
    Private Const CMstrRouteIDFlag2                 As String = "2"             '追加流動のみ設定可

    Private Const CMstrReworkFlagOff                As String = "0"             'ﾘﾜｰｸﾌﾗｸﾞOff

    Private Const CMstrDefault0                     As String = "0"             '初期設定(=0)
    Private Const CMstrDefault1                     As String = "1"             '初期設定(=1)

    '@代替ﾙｰﾄ(ﾘﾜｰｸ/追加流動)ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                  As Integer = 16             'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 16             'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColRouteName          As Integer = 0              '代替ﾙｰﾄ名称表示列番
    Private Const CMlngCmbGridColRouteId            As Integer = 1              '代替ﾙｰﾄID列番(非表示項目)
    Private Const CMlngCmbDispCols                  As Integer = 1              'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbRowHeight                 As Integer = 43             'ﾘｽﾄ行の高さ

    '@ﾃｷｽﾄ
    Private Const CMlngMaxDispRow                   As Integer = 4              'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(ﾛｯﾄｺﾒﾝﾄ)
    Private Const CMlngMaxDispMemoRow               As Integer = 3              'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(作業ﾒﾓ)

    '@ﾚｽﾎﾟﾝｽ,引継ぎ用ｲﾍﾞﾝﾄ定数
    Private Const CMstrFormName                     As String = "frmxxEN00Y0"               '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                     As String = "Form_Load"                 'ﾌｫｰﾑ起動時処理
    Private Const CMstrTxtCarrierValidate           As String = "txtCarrier_Validate"       'ｷｬﾘｱIDValidate処理
    Private Const CMstrOptSPFlowClick               As String = "optSPFlow_Click"           'ﾘﾜｰｸ/追加流動ｵﾌﾟｼｮﾝﾎﾞﾀﾝ選択時処理
    Private Const CMstrTxtToCarrierValidate         As String = "txtToCarrier_Validate"     'ｱﾝﾛｰﾀﾞｷｬﾘｱIDValidate処理
    Private Const CMstrCmbRouteIdChange             As String = "cmbRouteId_Change"         '特殊ﾙｰﾄIDｺﾝﾎﾞ変更時処理
    Private Const CMstrCmdRegistClick               As String = "cmdRegist_Click"           '確定ﾎﾞﾀﾝ押下時処理

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    '======================================Private==========================================
    Private mstrLotLastUpdate                       As String               'ﾛｯﾄ最終更新日時
    Private mstrCarrierID                           As String               'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mstrSpecialRuteFlag                     As String               '特殊流動ﾌﾗｸﾞ(0：処理なし、1：ﾘﾜｰｸ、2：追加流動)
    Private mblnTakeOverDispFlg                     As Boolean              '引継ぎ表示ﾌﾗｸﾞ
    Private mblnAllSelectFlag                       As Boolean              '全選択ﾌﾗｸﾞ(True：全選択、False：初期値(部分))
    Private mtypLotCurState                         As Lotprestate          'ﾛｯﾄ情報格納構造体
    Private buttonProcessing                        As Boolean              'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean              'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean              'NSYS WindowCloseフラグ

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
        pubVsfMouseWheelManager_Set(vsfSlotMap, cmdUp, cmdDown)
        pubVsfMouseWheelManager_Set(vsfNextStepInfo, cmdNextUP, cmdNextDown,cmdLeft,cmdRight)

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '======================================Private==========================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　起動時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 21:54:04 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 10:41:59 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub Form_Load()

        Dim lblnAns         As Boolean      '戻り値
            
        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@=======================
            '@ 機能ﾊﾞｰｼﾞｮﾝ判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN00Y0, CMstrLocalVersion)
            
            '@機能ﾊﾞｰｼﾞｮﾝ判定処理結果が"False：機能Ver不一致"か
            If lblnAns = False Then

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@=======================
            '@ 画面初期化処理
            '@=======================
            Call prvFrmxxEN00Y0_Init()
            
            '@各種ｽｸﾛｰﾙﾎﾞﾀﾝの初期化
            cmdTxtUp.Enabled = False                    'ｺﾒﾝﾄ用：上(▲)
            cmdTxtDown.Enabled = False                  'ｺﾒﾝﾄ用：下(▼)
            cmdMemoUp.Enabled = False                   '作業ﾒﾓ用：上(▲)
            cmdMemoDown.Enabled = False                 '作業ﾒﾓ用：下(▼)
            
            
            '@=======================
            '@ 各種ｺﾝﾄﾛｰﾙ(ｵﾌﾞｼﾞｪｸﾄ)制御処理(無効化)
            '@=======================
            Call prvAnyObjectControl_Proc(False)
            
            '@各種値、ﾌﾗｸﾞの初期化
            txtCarrier.Text = vbNullString              'ｷｬﾘｱID
            mstrSpecialRuteFlag = vbNullString          '特殊流動ﾌﾗｸﾞ
            mblnTakeOverDispFlg = False                 '引継ぎ情報表示済みﾌﾗｸﾞ
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞに"True：起動成功"をｾｯﾄ
            pblnFormLoad = True
            
            '@閉じるﾎﾞﾀﾝはﾌｫｰｶｽLost時の入力ﾁｪｯｸを行わないように設定
            cmdClose.CausesValidation = False

            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Me.Left = 0 - My.Settings.FormOffset
            Me.Top = 0

            'NSYS 背景色
            cmbRouteId.BackColor = Color.White                                              

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Load"                  '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
    '作成日：2004/08/25 (Wed) 21:55:11 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2005/03/02 (Wed) 09:22:45 S.Deguchi    作業終了画面から引継起動した場合の処理を追加
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@-----------------------
            '@ 引継ぎ情報表示済みﾌﾗｸﾞの判定
            '@ ※FormLoad後、最初の1回しか処理しない
            '@-----------------------
            If mblnTakeOverDispFlg = True Then

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@引継ぎ情報表示済みﾌﾗｸﾞに"True：表示済"をｾｯﾄ
            mblnTakeOverDispFlg = True
            
            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose

            '@引数のｷｬﾘｱIDがNULL以外(引継ぎあり)か
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@引継ぎ「有り」の場合
                
                '@ｷｬﾘｱIDの初期値として設定
                txtCarrier.Text = ptypCommonInfo.strCarrierId
                
                '@引継構造体から特殊流動ﾌﾗｸﾞ(0：処理なし、1：ﾘﾜｰｸ、2：追加流動)を変数に格納
                mstrSpecialRuteFlag = ptypWorkEndInfo.strSpecialRuteFlag
                
                '@=======================
                '@ ｷｬﾘｱIDﾃｷｽﾄValidate処理
                '@=======================
                RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                
                '@ｽﾛｯﾄﾏｯﾌﾟが無効、またはｷｬﾘｱIDがNULLか
                If vsfSlotMap.Enabled = True Or _
                   txtCarrier.Text = vbNullString Then
                    
                    '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If
            Else
                '@引継ぎ「無し」の場合
            
                '@引継ぎｷｬﾘｱIDの初期化
                ptypCommonInfo.strCarrierId = vbNullString
                
                '@引継ぎ情報の初期化
                ptypCommonInfo.strSPSelectFlag = vbNullString
                mstrSpecialRuteFlag = vbNullString
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
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Activate"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑ　ｷｰ押下時処理
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 21:55:41 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2007/07/05 (Thu) 14:17:15 N.Kasai      ｸﾞﾘｯﾄﾞ機能共通化
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

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
                e.Handled = True
                Exit Sub
            End If

            '@=======================
            '@ ｸﾞﾘｯﾄﾞ上下(▲,▼)ｽｸﾛｰﾙﾎﾞﾀﾝｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            '@ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfSlotMap, cmdUP, cmdDown, False)


            '@=======================
            '@ ｸﾞﾘｯﾄﾞ上下(▲,▼)ｽｸﾛｰﾙﾎﾞﾀﾝｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            '@特殊流動先次工程ｸﾞﾘｯﾄﾞ
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfNextStepInfo, cmdNextUP, cmdNextDown)
            
            '@=======================
            '@ ｸﾞﾘｯﾄﾞ左右("<<",">>")ｽｸﾛｰﾙﾎﾞﾀﾝｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            '@特殊流動先次工程ｸﾞﾘｯﾄﾞ
            Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfNextStepInfo, cmdLeft, cmdRight)


            '@★ ｷｰｺｰﾄﾞにより処理分岐 ★
            Select Case e.KeyCode
                
                '@〓 Enterｷｰ 〓
                Case Keys.Return

                    '@★★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★★
                    Select Case ActiveControl.Name
                        
                        '@〓〓 ｷｬﾘｱID 〓〓
                        Case txtCarrier.Name    
                            
                            '@=======================
                            '@ ｷｬﾘｱIDValidate処理
                            '@=======================
                            RemoveHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                            Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                            AddHandler txtCarrier.Validating,AddressOf txtCarrier_Validate
                            
                            '@ｽﾛｯﾄﾏｯﾌﾟが無効、またはｷｬﾘｱIDがNULLか
                            If vsfSlotMap.Enabled = True Or _
                                txtCarrier.Text = vbNullString Then

                                'NSYS VB6版と同じ動きになるよう追加
                                If optSPFlow0.Enabled = True AndAlso optSPFlow1.Enabled = True AndAlso _
                                   optSPFlow0.Checked = False AndAlso optSPFlow1.Checked = False Then
                                    optSPFlow0.Checked = True
                                End If

                                '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
                                SendKeys.SendWait(CPstrSendKeysTab)
                                e.Handled = True
                            End If

                            Exit Sub

                        '@〓〓 作業ﾒﾓ 〓〓
                        Case txtWorkMemo.Name
                            
                            '@ﾃｷｽﾄは改行する為、処理なし
                            Exit Sub

                    End Select
                    
                    '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
                    SendKeys.SendWait(CPstrSendKeysTab)
                    e.Handled = True
                 
                '@〓 SPACEｷｰ 〓
                Case Keys.Space
                    
                    '@=======================
                    '@ ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　Click時処理
                    '@=======================
                    Call vsfSlotMap_Click(vsfSlotMap, New EventArgs())
            
            End Select
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_KeyDown"               '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑ　終了時処理
    '引　数：Cancel     ：(True：終了ｷｬﾝｾﾙ、False：終了)
    '　　　：UnloadMode ：(0:×ﾎﾞﾀﾝ終了、1：閉じるﾎﾞﾀﾝ終了)
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 10:07:19 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2004/11/01 (Mon) 16:00:35 S.Deguchi    閉じるﾎﾞﾀﾝ統合
    '　　　：2005/04/20 (Wed) 15:45:58 N.Kasai      不適合品処理票自動起案対応(構造体初期化)
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm             As Boolean          'ACT開放結果格納

        Try

            '@ﾌｫｰﾑの"×"ﾎﾞﾀﾝにて閉じたか
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                '@=======================
                '@ 閉じるﾎﾞﾀﾝ処理
                '@=======================
                Call cmdClose_Click(sender,e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If

            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化
            '@ ※装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要
            pblnFormLoad = False
            
            '@ACT初期化ﾌﾗｸﾞが"True：自前で初期化"か
            If pblnActInitFlg = True Then

                '@ACTｵﾌﾞｼﾞｪｸﾄの開放
                lblnAnsTerm = pubblnAct_Term
                '@結果判定
                If lblnAnsTerm = True Then
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                End If
            Else
                '@ACT初期化ﾌﾗｸﾞが"False：自前で初期化していない"の場合
                
                '@=======================
                '@ ﾒﾆｭｰ伸縮処理
                '@=======================
                Call pubMenuExpand_Disp()
            End If

            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_QueryUnload"           '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
    '作成日：2004/08/26 (Thu) 10:14:56 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change

        Try

            '@=======================
            '@ 画面初期化処理
            '@=======================
            Call prvFrmxxEN00Y0_Init()
            
            '@=======================
            '@ 各種ｺﾝﾄﾛｰﾙ(ｵﾌﾞｼﾞｪｸﾄ)制御処理
            '@=======================
            Call prvAnyObjectControl_Proc(False)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtCarrier_Change"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtCarrier_Validate
    '機　能：ｷｬﾘｱIDﾃｷｽﾄ　入力確定(Validate)処理
    '引　数：Cancel ：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 10:42:28 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2004/09/22 (Wed) 17:17:31 M.Miura　    ｷｬﾘｱWF情報の処理区分を良品のみに変更
    '　　　：2004/10/18 (Mon) 12:04:05 S.Deguchi    特殊流動対応でｵﾌﾟｼｮﾝﾎﾞﾀﾝ制御変更
    '　　　：2004/10/25 (Mon) 15:10:50 S.Deguchi    引継ぎ情報からの判別処理は、先行流動が未実装の為ｺﾒﾝﾄｱｳﾄ
    '　　　：2004/10/26 (Tue) 11:40:44 M.Miura      ｽﾛｯﾄﾏｯﾌﾟの初期表示位置設定を追加
    '　　　：2005/03/02 (Wed) 09:24:11 S.Deguchi    作業終了画面から引継いだ情報を表示する処理を修正
    '　　　：2005/03/04 (Fri) 15:11:37 S.Deguchi    単独起動処理を追加
    '　　　：2005/10/31 (Mon) 11:01:52 S.Deguchi    例外処理を追加
    '　　　：2008/03/31 (Mon) 11:13:00 S.Ochiai     No.02541対応(ﾘﾜｰｸ/追加流動ﾙｰﾄID選択)
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim lblnAns                     As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrClassDivision           As String               '処理区分
        Dim ltypWaferList               As Waferlist            'ｷｬﾘｱWF情報構造体
        Dim lstrSpecialRuteSelectFlag   As String               'ﾘﾜｰｸ/追加流動ｵﾌﾟｼｮﾝﾎﾞﾀﾝ選択可否ﾌﾗｸﾞ
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl Is cmdClose OrElse mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@-----------------------
            '@ ｷｬﾘｱIDﾁｪｯｸ(下記①～③をﾁｪｯｸ)
            '@-----------------------
            '@①ｷｬﾘｱIDがNULLか
            If Trim(txtCarrier.Text) = vbNullString Then
                Exit Sub
            End If
            
            '@②ｷｬﾘｱIDが6桁未満か
            If txtCarrier.NowByte < txtCarrier.ChrMaxByte Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM07W>$$キャリアIDは6桁で入力してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽ保持
                e.Cancel = True
                Exit Sub
            End If
            
            '@③前回の正常なｷｬﾘｱIDと同じｷｬﾘｱIDの場合は抜ける
            If txtCarrier.Text = mstrCarrierID Then
                Exit Sub
            End If

            
            '@=======================
            '@ 画面初期化処理
            '@=======================
            Call prvFrmxxEN00Y0_Init()
            
            '@=======================
            '@ 各種ｺﾝﾄﾛｰﾙ(ｵﾌﾞｼﾞｪｸﾄ)制御処理(無効化)
            '@=======================
            Call prvAnyObjectControl_Proc(False)


            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrTxtCarrierValidate)

            '@=======================
            '@ ﾛｯﾄ現在状態取得(1J：特殊流動)
            '@=======================
            lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                            CPstrCD1J, _
                                            txtCarrier.Text, _
                                            ptypLotprestate)

            '@ﾛｯﾄ現在状態取得結果が"True：取得成功"か
            If lblnAns = True Then
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrTxtCarrierValidate)
                
                '@=======================
                '@ 画面情報表示処理
                '@=======================
                Call prvFrmxxEN00Y0_Disp()
                
                '@取得したﾛｯﾄ現在状態情報をﾓｼﾞｭｰﾙ構造体へ退避
                mtypLotCurState = ptypLotprestate

            Else
                '@ﾛｯﾄ現在状態取得結果が"False：取得失敗"か

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽ保持
                e.Cancel = True
                Exit Sub
            End If

            '@=======================
            '@ 各種ｺﾝﾄﾛｰﾙ(ｵﾌﾞｼﾞｪｸﾄ)制御処理(有効化)
            '@=======================
            Call prvAnyObjectControl_Proc(True)


            '@★ 作業終了からの特殊流動ﾌﾗｸﾞの値により処理分岐 ★
            Select Case mstrSpecialRuteFlag
                
                '@〓 1：ﾘﾜｰｸ 〓
                Case CMstrRouteIDFlag1
                    
                    '@処理区分に"1J：特殊流動"をｾｯﾄ
                    lstrClassDivision = CPstrCD1J
                    
                    '@特殊流動ﾙｰﾄID(追加流動ﾙｰﾄID)がNULL以外か
                    If ptypLotprestate.strSpecialRouteID <> vbNullString Then
                        
                        '@ﾘﾜｰｸ/追加流動ｵﾌﾟｼｮﾝﾎﾞﾀﾝ選択可否ﾌﾗｸﾞに"0：ﾘﾜｰｸ/追加流動両方設定可"をｾｯﾄ
                        lstrSpecialRuteSelectFlag = CMstrRouteIDFlag0
                    Else
                        '@ﾘﾜｰｸ/追加流動ｵﾌﾟｼｮﾝﾎﾞﾀﾝ選択可否ﾌﾗｸﾞに"1：ﾘﾜｰｸのみ設定可"をｾｯﾄ
                        lstrSpecialRuteSelectFlag = CMstrRouteIDFlag1
                    End If


                '@〓 2：追加流動 〓
                Case CMstrRouteIDFlag2
                    
                    '@ﾘﾜｰｸﾙｰﾄIDがNULL以外か
                    If ptypLotprestate.strReworkRouteID <> vbNullString Then

                        '@ﾘﾜｰｸ/追加流動ｵﾌﾟｼｮﾝﾎﾞﾀﾝ選択可否ﾌﾗｸﾞに"0：ﾘﾜｰｸ/追加流動両方設定可"をｾｯﾄ
                        lstrSpecialRuteSelectFlag = CMstrRouteIDFlag0
                    Else
                        '@ﾘﾜｰｸ/追加流動ｵﾌﾟｼｮﾝﾎﾞﾀﾝ選択可否ﾌﾗｸﾞに"2：追加流動のみ設定可"をｾｯﾄ
                        lstrSpecialRuteSelectFlag = CMstrRouteIDFlag2
                    End If


                '@〓 その他：NULLを想定 〓
                '@mstrSpecialFlagがNullの場合(単独起動時)
                Case Else

                    '@ﾘﾜｰｸﾙｰﾄIDがNULL以外か
                    If ptypLotprestate.strReworkRouteID <> vbNullString Then
                        
                        '@特殊流動ﾙｰﾄID(追加流動ﾙｰﾄID)がNULL以外か
                        If ptypLotprestate.strSpecialRouteID <> vbNullString Then

                            '@ﾘﾜｰｸ/追加流動ｵﾌﾟｼｮﾝﾎﾞﾀﾝ選択可否ﾌﾗｸﾞに"0：ﾘﾜｰｸ/追加流動両方設定可"をｾｯﾄ
                            lstrSpecialRuteSelectFlag = CMstrRouteIDFlag0
                        Else
                            '@ﾘﾜｰｸ/追加流動ｵﾌﾟｼｮﾝﾎﾞﾀﾝ選択可否ﾌﾗｸﾞに"1：ﾘﾜｰｸのみ設定可"をｾｯﾄ
                            lstrSpecialRuteSelectFlag = CMstrRouteIDFlag1
                        End If
                    Else
                        '@ﾘﾜｰｸﾙｰﾄIDがNULLの場合

                        '@特殊流動ﾙｰﾄID(追加流動ﾙｰﾄID)がNULL以外か
                        If ptypLotprestate.strSpecialRouteID <> vbNullString Then

                            '@ﾘﾜｰｸ/追加流動ｵﾌﾟｼｮﾝﾎﾞﾀﾝ選択可否ﾌﾗｸﾞに"2：追加流動のみ設定可"をｾｯﾄ
                            lstrSpecialRuteSelectFlag = CMstrRouteIDFlag2
                        Else
                            '@ﾘﾜｰｸ/追加流動ｵﾌﾟｼｮﾝﾎﾞﾀﾝ選択可否ﾌﾗｸﾞに"0：ﾘﾜｰｸ/追加流動両方設定可"をｾｯﾄ
                            lstrSpecialRuteSelectFlag = CMstrRouteIDFlag0
                        End If
                    End If

            End Select


            '@★ ﾘﾜｰｸ/追加流動ｵﾌﾟｼｮﾝﾎﾞﾀﾝ選択可否ﾌﾗｸﾞにより処理分岐 ★
            Select Case lstrSpecialRuteSelectFlag
                
                '@〓 0：ﾘﾜｰｸ/追加流動両方設定可 〓
                Case CMstrRouteIDFlag0

                    '@両ｵﾌﾟｼｮﾝﾎﾞﾀﾝを有効にする
                    optSPFlow0.Enabled = True              'ﾘﾜｰｸ
                    optSPFlow1.Enabled = True              '追加流動
                    
                    '@-----------------------
                    '@ 作業終了で設定された方をﾁｪｯｸONにする
                    '@-----------------------
                    '@★★ 作業終了でのﾁｪｯｸ項目により処理分岐 ★★
                    Select Case mstrSpecialRuteFlag
                    
                        '@〓 1：ﾘﾜｰｸ 〓
                        Case CMstrRouteIDFlag1
                        
                            optSPFlow0.Checked = True      'ﾘﾜｰｸ：ﾁｪｯｸON
                        
                        '@〓 2：追加流動 〓
                        Case CMstrRouteIDFlag2
                        
                            optSPFlow1.Checked = True      '追加流動：ﾁｪｯｸON

                    End Select

                '@〓 1：ﾘﾜｰｸのみ設定可 〓
                Case CMstrRouteIDFlag1
                    
                    '@各種ｵﾌﾟｼｮﾝﾎﾞﾀﾝの有効/無効制御
                    optSPFlow0.Enabled = True              'ﾘﾜｰｸ
                    optSPFlow1.Enabled = False             '追加流動
                    
                    '@「ﾘﾜｰｸ」をﾁｪｯｸONにする
                    optSPFlow0.Checked = True
                
                
                '@〓 2：追加流動のみ設定可 〓
                Case CMstrRouteIDFlag2

                    '@各種ｵﾌﾟｼｮﾝﾎﾞﾀﾝの有効/無効制御
                    optSPFlow0.Enabled = False             'ﾘﾜｰｸ
                    optSPFlow1.Enabled = True              '追加流動
                    
                    '@「追加流動」をﾁｪｯｸONにする
                    optSPFlow1.Checked = True
            
            End Select


            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrTxtCarrierValidate)

            '@=======================
            '@ ﾛｯﾄWF情報取得
            '@=======================
            lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, _
                                             txtCarrier.Text, _
                                             CPstrCD0T, _
                                             ltypWaferList, , _
                                             pstrSBID)

            '@ﾛｯﾄWF情報取得結果が"True：取得成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrTxtCarrierValidate)

                '@=======================
                '@ ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ表示処理
                '@=======================
                Call prvVsfSlotMap_Disp(ltypWaferList)
                
                '@=======================
                '@ ｽﾛｯﾄﾏｯﾌﾟ初期表示位置設定
                '@=======================
                Call prvvsfSlotMap_Set()

            Else
                '@ﾛｯﾄWF情報取得結果が"False：取得失敗"か

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)

                '@確定ﾎﾞﾀﾝを有効
                cmdRegist.Enabled = False
                
                '@=======================
                '@ 各種ｺﾝﾄﾛｰﾙ(ｵﾌﾞｼﾞｪｸﾄ)制御処理(無効化)
                '@=======================
                Call prvAnyObjectControl_Proc(False)
                
                '@作業終了で選択された特殊流動設定の初期化
                mstrSpecialRuteFlag = vbNullString
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽ保持
                e.Cancel = True
                Exit Sub
            End If
            
            '@次回のｷｬﾘｱID比較用に現在のｷｬﾘｱIDを格納
            mstrCarrierID = txtCarrier.Text
            
            '@作業終了で選択された特殊流動設定の初期化
            mstrSpecialRuteFlag = vbNullString

            '@↓2020/01/15 (Wed) 11:19:53 Y.Yoneyama 「.Netへ反映未」 **************************************************
            '@GRB混在/流動票GRBあり/Rework場合
            '@全数ﾘﾜｰｸのみ
            If lblGRB.Text = CPstrGRB_MIX And _
                mtypLotCurState.strTrvGRBClass <> vbNullString And _
                optSPFlow0.Checked = True Then
        
                '@全数選択
                Call cmdAllSelect_Click(sender, e)
        
                '@WF選択変更不可
                vsfSlotMap.Enabled = False
                cmdAllSelect.Enabled = False
        
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM7VW>$$GRB設定が混在の場合は、全数リワークのみ可能です。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf007W)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
        
            End If
            '@↑2020/01/15 (Wed) 11:19:53 Y.Yoneyama 「.Netへ反映未」 **************************************************
            
			'kkw 蒸着2回対応
			Call prvDoubleJPd_Chk()

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtCarrier_Validate"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
                        
        End Try
    End Sub

    '関数名：optSPFlow_Click
    '機　能：ﾘﾜｰｸ/追加流動ｵﾌﾟｼｮﾝﾎﾞﾀﾝ　Click時処理
    '引　数：Index：0:ﾘﾜｰｸ、1:追加流動
    '戻り値：なし
    '作成日：2005/03/04 (Fri) 15:14:06 S.Deguchi
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2005/04/04 (Mon) 11:37:56 S.Deguchi    処理を見直し
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub optSPFlow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optSPFlow0.CheckedChanged, optSPFlow1.CheckedChanged

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypMasAltRouteListReq  As MasAltRouteListReq   '代替ﾙｰﾄ(ﾘﾜｰｸ/追加流動)一覧取得要求
        Dim ltypMasAltRouteListAns  As MasAltRouteListAns   '代替ﾙｰﾄ(ﾘﾜｰｸ/追加流動)一覧取得応答
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS チェックが付いていない場合処理を抜ける
            If sender.Checked = False Then
                Exit Sub
            End If
                
            '@特殊ﾙｰﾄｺﾝﾎﾞの初期化
            cmbRouteId.Clear
            
            '@-----------------------
            '@ ﾘﾜｰｸ/追加流動毎に情報をｾｯﾄ
            '@-----------------------
            '@SBは共通
            ltypMasAltRouteListReq.strSbID = pstrSBID
            
            '@★ 選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝにより処理分岐 ★
            Select Case True
            
                '@〓 0：ﾘﾜｰｸ 〓
                Case sender Is optSPFlow0

                    ltypMasAltRouteListReq.strFlowType = CPstrMasFlowTypeRework             'ﾌﾟﾛｾｽ流動ﾀｲﾌﾟ(M_PC.FLOW_TYPE)：1=ﾘﾜｰｸ
                    ltypMasAltRouteListReq.strRouteID = mtypLotCurState.strReworkRouteID    'ﾘﾜｰｸﾙｰﾄID
                
                '@〓 1：追加流動 〓
                Case sender Is optSPFlow1

                    ltypMasAltRouteListReq.strFlowType = CPstrMasFlowTypeTsuika             'ﾌﾟﾛｾｽ流動ﾀｲﾌﾟ(M_PC.FLOW_TYPE)：4=追加流動
                    ltypMasAltRouteListReq.strRouteID = mtypLotCurState.strSpecialRouteID   '特殊流動(追加流動)ﾙｰﾄID

            End Select


            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrOptSPFlowClick)

            '@=======================
            '@ 代替ﾙｰﾄ一覧取得
            '@=======================
            lblnAns = pubblnMasAltRouteList_Sel(CMstrmas_altroutelistVer, _
                                                ltypMasAltRouteListReq, _
                                                ltypMasAltRouteListAns)
            
            '@代替ﾙｰﾄ一覧取得結果が"True：取得成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrOptSPFlowClick)

                '@=======================
                '@ 代替ﾙｰﾄ(ﾘﾜｰｸ/追加流動)ｺﾝﾎﾞ作成
                '@=======================
                Call prvCmbRouteId_Disp(ltypMasAltRouteListAns)
                
                '@代替ﾙｰﾄ(ﾘﾜｰｸ/追加流動)が複数あるか
                If ltypMasAltRouteListAns.lngAltRouteListCnt > 1 Then
                
                    '@代替ﾙｰﾄ(ﾘﾜｰｸ/追加流動)ｺﾝﾎﾞを有効にする
                    cmbRouteId.Enabled = True
                Else
                    '@代替ﾙｰﾄ(ﾘﾜｰｸ/追加流動)ｺﾝﾎﾞを無効にする
                    cmbRouteId.Enabled = False
                End If

				'@=======================
				'@ 確定ﾎﾞﾀﾝ制御ﾁｪｯｸ
				'@=======================
				Call prvcmdRegist_Chk()
            
                
            Else
                '@代替ﾙｰﾄ一覧取得結果が"False：取得失敗"か

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrOptSPFlowClick)

                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
                
                '@=======================
                '@ 各種ｺﾝﾄﾛｰﾙ(ｵﾌﾞｼﾞｪｸﾄ)制御処理(無効化)
                '@=======================
                Call prvAnyObjectControl_Proc(False)
                
                '@選択対象ﾌﾚｰﾑを無効にする(ｽﾛｯﾄﾏｯﾌﾟを使用不可にしたい)
                fraSelectWF.Enabled = False
                
                Exit Sub
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "optSPFlow_Click"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：optDivFlag_Click
    '機　能：分割有/無ｵﾌﾟｼｮﾝﾎﾞﾀﾝ　Click時処理
    '引　数：Index：ｵﾌﾟｼｮﾝﾎﾞﾀﾝIndex(0：分割無、1：分割有)
    '戻り値：なし
    '作成日：2009/08/11 (Tue) 14:58:28 N.Kojima
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub optDivFlag_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optDivFlag0.Click, optDivFlag1.Click

        Try

            '@分割無がﾁｪｯｸONか
            If optDivFlag0.Checked = True Then

                '@移載工程ｽｷｯﾌﾟﾁｪｯｸﾎﾞｯｸｽを無効にする
                chkMoveSkip.Enabled = False
            Else
                '@移載工程ｽｷｯﾌﾟﾁｪｯｸﾎﾞｯｸｽを有効にする
                chkMoveSkip.Enabled = True
            End If
            
            '@=======================
            '@ 確定ﾎﾞﾀﾝ制御ﾁｪｯｸ
            '@=======================
            Call prvcmdRegist_Chk()

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "optDivFlag_Click"           '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbRouteId_Change
    '機　能：特殊ﾙｰﾄIDｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/04/01 (Tue) 13:33:00 S.Ochiai
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub cmbRouteId_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRouteId.Change

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrLotID               As String               'ﾛｯﾄID
        Dim lstrOpeID               As String               '大工程ID
        Dim lstrStepID              As String               '小工程ID
        Dim ltypLotNextStep         As LotNextStep          '次工程取得ﾃﾞｰﾀ格納
        Dim lstrClassDivision       As String               '処理区分格納用
        Dim lstrRouteID             As String               'ﾙｰﾄID
        
        Try

            '@ﾙｰﾄIDが未選択の場合は処理を抜ける
            If cmbRouteId.Value = vbNullString Then
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmbRouteIdChange)

            '@=======================
            '@ 特殊流動先次工程ｸﾞﾘｯﾄﾞ初期化処理
            '@=======================
            Call prvVsfNextStepInfo_Init()

            '@ﾃﾞｰﾀ取得条件を変数に格納
            lstrLotID = lblLotID.Text        'ﾛｯﾄID
            lstrOpeID = lblOpID.Text         '大工程
            lstrStepID = lblStepID.Text      '小工程
            lstrRouteID = cmbRouteId.Value   'ﾙｰﾄID
            
            '@ﾘﾜｰｸｵﾌﾟｼｮﾝﾎﾞﾀﾝが"True：ﾁｪｯｸON"か
            If optSPFlow0.Checked = True Then

                '@処理区分：1J(ﾘﾜｰｸ)をｾｯﾄ
                lstrClassDivision = CPstrCD1J
            Else
                '@処理区分：1J(追加流動)をｾｯﾄ
                lstrClassDivision = CPstrCD1V
            End If

            '@=======================
            '@ ﾛｯﾄ次工程取得
            '@=======================
            lblnAns = pubblnLotNextStepList_Sel(CMstrlot_nextsteplistVer, _
                                                lstrLotID, _
                                                lstrOpeID, _
                                                lstrStepID, _
                                                ltypLotNextStep, _
                                                lstrClassDivision, _
                                                lstrRouteID)

            '@ﾛｯﾄ次工程取得結果が"True：取得成功"か
            If lblnAns = True Then
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmbRouteIdChange)
                
                With ltypLotNextStep
                    
                    '@次大工程/小工程/工程ﾌﾗｸﾞがNULL以外か(最終工程の場合は大工程、小工程、工程ﾌﾗｸﾞが全て空白で返される)
                    If .strNextStepList(CMlngNextStepListIndex).strNextOpId <> vbNullString Or _
                        .strNextStepList(CMlngNextStepListIndex).strNextStepId <> vbNullString Or _
                        .strNextStepList(CMlngNextStepListIndex).strStepDivision <> vbNullString Then
                        
                        '@=======================
                        '@ 特殊流動先次工程ｸﾞﾘｯﾄﾞ初期化処理
                        '@=======================
                        Call prvVsfNextStepInfo_Init()
                        
                        '@=======================
                        '@ 特殊流動先工程ｸﾞﾘｯﾄﾞ表示処理
                        '@=======================
                        Call prvVsfNextStepInfo_Disp(ltypLotNextStep, _
                                                     ltypLotNextStep.lngNextStepListCnt)
                        
                        '@選択対象ﾌﾚｰﾑを無効にする(ｽﾛｯﾄﾏｯﾌﾟを使用不可にしたい)
                        fraSelectWF.Enabled = True
                        
                        '@=======================
                        '@ 各種ｺﾝﾄﾛｰﾙ(ｵﾌﾞｼﾞｪｸﾄ)制御処理(有効化)
                        '@=======================
                        Call prvAnyObjectControl_Proc(True)

                    End If
                End With
            Else
                '@ﾛｯﾄ次工程取得結果が"False：取得失敗"か

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmbRouteIdChange)

                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
                
                '@=======================
                '@ 各種ｺﾝﾄﾛｰﾙ(ｵﾌﾞｼﾞｪｸﾄ)制御処理(無効化)
                '@=======================
                Call prvAnyObjectControl_Proc(False)
                
                '@選択対象ﾌﾚｰﾑを無効にする(ｽﾛｯﾄﾏｯﾌﾟを使用不可にしたい)
                fraSelectWF.Enabled = False
                
                Exit Sub
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbRouteId_Change"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfSlotMap_Click
    '機　能：ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ　Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/23 (Mon) 19:46:55 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub vsfSlotMap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfSlotMap.Click
        
        Try
 
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfSlotMap.Rows.Count <= vsfSlotMap.Rows.Fixed Then
                Return
            End If
            
            With vsfSlotMap
                
                '@WFのﾁｪｯｸﾎﾞｯｸｽが有効(表示されている)か
                If .GetCellCheck(.Row, CMlngvsfSlotMapColCheck) <> CheckEnum.None Then
                    
                    '@WFのﾁｪｯｸがOFFか
                    If .GetCellCheck(.Row, CMlngvsfSlotMapColCheck) = CheckEnum.Unchecked Then
                        
                        '@ﾁｪｯｸOFF→ﾁｪｯｸON
                        .AllowEditing = True                                               'ｸﾞﾘｯﾄﾞ編集許可
                        .SetCellCheck(.Row, CMlngvsfSlotMapColCheck, CheckEnum.Checked)    'ﾁｪｯｸ
                        .AllowEditing = False                                              'ｸﾞﾘｯﾄﾞ編集禁止
                    Else
                        '@ﾁｪｯｸONの場合

                        '@ﾁｪｯｸON→ﾁｪｯｸOFF
                        .AllowEditing = True                                               'ｸﾞﾘｯﾄﾞ編集許可
                        .SetCellCheck(.Row, CMlngvsfSlotMapColCheck, CheckEnum.Unchecked)  'ﾁｪｯｸ解除
                        .AllowEditing = False                                              'ｸﾞﾘｯﾄﾞ編集禁止
                    End If
                End If
            End With

            '@=======================
            '@ 特殊流動対象全数選択ﾁｪｯｸ
            '@=======================
            Call prvProcAllSelect_Chk()

            '@=======================
            '@ 分割有/無選択可否ﾁｪｯｸ
            '@=======================
            Call prvDivideFlag_Chk()

            '@=======================
            '@ 確定ﾎﾞﾀﾝ制御ﾁｪｯｸ
            '@=======================
            Call prvcmdRegist_Chk()
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfSlotMap_Click"           '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 10:17:47 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
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
            '@ ｸﾞﾘｯﾄﾞ用上ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdUp(vsfSlotMap, cmdUP, cmdDown)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdUp_Click"                '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 10:18:28 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
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
            '@ ｸﾞﾘｯﾄﾞ用下ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdDown(vsfSlotMap, cmdUP, cmdDown, False)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdDown_Click"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfNextStepInfo_AfterUserResize
    '機　能：特殊流動先次工程ｸﾞﾘｯﾄﾞ　列幅変更後処理
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 20:47:51 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub vsfNextStepInfo_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfNextStepInfo.AfterResizeColumn, vsfNextStepInfo.AfterResizeRow

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfNextStepInfo.Rows.Count <= vsfNextStepInfo.Rows.Fixed Then
                Return
            End If
            
            '@=======================
            '@ 左右("<<",">>")ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
            '@=======================
            Call pubCmdLREnable_Set(vsfNextStepInfo, cmdLeft, cmdRight)
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                     '機能ID
                .strProcName = "vsfNextStepInfo_AfterUserResize"    '処理名
                .strErrMessage = vbNullString                       'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNextUp_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(特殊流動先次工程ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 10:19:20 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
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
            '@ ｸﾞﾘｯﾄﾞ用上ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdUp(vsfNextStepInfo, cmdNextUP, cmdNextDown)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdNextUP_Click"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNextDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(特殊流動先次工程ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 10:19:55 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
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
            '@ ｸﾞﾘｯﾄﾞ用下ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdDown(vsfNextStepInfo, cmdNextUP, cmdNextDown)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdNextDown_Click"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLeft_Click
    '機　能：左("<<")ｽｸﾛｰﾙﾎﾞﾀﾝ(特殊流動先次工程ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 10:40:44 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2007/07/05 (Thu) 14:15:14 N.Kasai      ｸﾞﾘｯﾄﾞ機能共通化
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
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
            '@ ｸﾞﾘｯﾄﾞ用左ｽｸﾛｰﾙﾎﾞﾀﾝｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdLeft(vsfNextStepInfo, cmdLeft, cmdRight)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdLeft_Click"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRight_Click
    '機　能：右(">>")ｽｸﾛｰﾙﾎﾞﾀﾝ(特殊流動先次工程ｸﾞﾘｯﾄﾞ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 10:41:25 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2007/07/05 (Thu) 14:14:29 N.Kasai      ｸﾞﾘｯﾄﾞ機能共通化
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
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
            '@ ｸﾞﾘｯﾄﾞ用右ｽｸﾛｰﾙﾎﾞﾀﾝｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)
            '@=======================
            Call pubVsfCmdRight(vsfNextStepInfo, cmdLeft, cmdRight)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdRight_Click"             '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_Change
    '機　能：作業ﾒﾓﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 10:15:14 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 10:35:06 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change
        
        Dim llngNowByte As Integer 'ﾊﾞｲﾄ数
        
        Try
            
            '@現在のﾊﾞｲﾄ数格納
            llngNowByte = txtWorkMemo.NowByte
            
            '@=======================
            '@ 現在のﾊﾞｲﾄ数表示処理(表示ﾒｯｾｰｼﾞ変換)
            '@=======================
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                          llngNowByte, _
                                                          CPlngLotCommentsMaxByte)
            
            '@=======================
            '@ ﾃｷｽﾄ変更時処理(ﾃｷｽﾄ共通仕様)
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
                                  
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtWorkMemo_Change"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
                                     
        End Try
    End Sub

    '関数名：txtWorkMemo_KeyUp
    '機　能：作業ﾒﾓﾃｷｽﾄ　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:15:19 N.Kasai
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub txtWorkMemo_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtWorkMemo.KeyUp

        Try
            
            '@=======================
            '@ ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作時処理(ﾃｷｽﾄ共通仕様)
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
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
    '機　能：作業ﾒﾓﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:52:24 N.Kasai
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub txtWorkMemo_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtWorkMemo.MouseUp

        Try

            '@=======================
            '@ ﾃｷｽﾄ変更時処理(ﾃｷｽﾄ共通仕様)
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

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoUp_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(作業ﾒﾓﾃｷｽﾄ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 10:15:57 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 10:33:07 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
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
            '@ ﾃｷｽﾄ用上ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ﾃｷｽﾄ共通仕様)
            '@=======================
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdMemoUp_Click"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(作業ﾒﾓﾃｷｽﾄ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 10:16:28 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 10:34:20 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
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
            '@ ﾃｷｽﾄ用下ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ﾃｷｽﾄ共通仕様)
            '@=======================
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdMemoDown_Click"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotCommnt_Change
    '機　能：ﾛｯﾄｺﾒﾝﾄﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:12:03 N.Kasai
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub txtLotCommnt_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLotCommnt.Change

        Try

            '@=======================
            '@ ﾃｷｽﾄ変更時処理(ﾃｷｽﾄ共通仕様)
            '@=======================
            Call pubtxtChange_Proc(txtLotCommnt, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
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
    '機　能：ﾛｯﾄｺﾒﾝﾄﾃｷｽﾄ　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 13:47:07 N.Kasai
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub txtLotCommnt_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtLotCommnt.KeyUp

        Try
            
            '@=======================
            '@ ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作時処理(ﾃｷｽﾄ共通仕様)
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtLotCommnt, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
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
    '機　能：ﾛｯﾄｺﾒﾝﾄﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 13:48:44 N.Kasai
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub txtLotCommnt_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtLotCommnt.MouseUp

        Try

            '@=======================
            '@ ﾃｷｽﾄ変更時処理(ﾃｷｽﾄ共通仕様)
            '@=======================
            Call pubtxtChange_Proc(txtLotCommnt, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
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
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(ﾛｯﾄｺﾒﾝﾄﾃｷｽﾄ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 10:16:48 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 10:37:27 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub cmdTxtUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtUp.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@=======================
            '@ ﾃｷｽﾄ用上ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ﾃｷｽﾄ共通仕様)
            '@=======================
            Call pubtxtCmdUp_Proc(txtLotCommnt, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdTxtUp_Click"             '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTxtDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(ﾛｯﾄｺﾒﾝﾄﾃｷｽﾄ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 10:17:21 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 10:38:26 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub cmdTxtDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtDown.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@ ﾃｷｽﾄ用下ｽｸﾛｰﾙﾎﾞﾀﾝ処理(ﾃｷｽﾄ共通仕様)
            '@=======================
            Call pubtxtCmdDown_Proc(txtLotCommnt, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdTxtDown_Click"           '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：chkMoveSkip_Click
    '機　能：移載工程ｽｷｯﾌﾟﾁｪｯｸﾎﾞｯｸｽ　Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/07/25 (Wed) 13:39:55 N.Kasai
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub chkMoveSkip_Click(ByVal sender As Object, ByVal e As EventArgs) Handles chkMoveSkip.CheckedChanged

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@移載工程ｽｷｯﾌﾟがﾁｪｯｸONか
            If chkMoveSkip.Checked = True Then

                '@全選択ﾌﾗｸﾞが"False：部分"か
                If mblnAllSelectFlag = False Then
                    
                    '@空きｷｬﾘｱ選択ﾎﾞﾀﾝを有効にする
                    cmdCarrierSelect.Enabled = True
                    
                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱﾃｷｽﾄの設定
                    With txtToCarrier
                        
                        .Enabled = True                         '有効
                        .GotBackColor = Color.White             'ﾌｫｰｶｽ取得時の背景色：白
                        .BackColor = Color.White                '背景色：白
                    End With
                End If
                
            Else
                '@移載工程ｽｷｯﾌﾟがﾁｪｯｸOFFの場合

                '@空きｷｬﾘｱ選択ﾎﾞﾀﾝを無効にする
                cmdCarrierSelect.Enabled = False
                
                '@ｱﾝﾛｰﾀﾞｷｬﾘｱﾃｷｽﾄの設定
                With txtToCarrier
                    
                    .Text = vbNullString                        'NULL
                    .Enabled = False                            '無効
                    .GotBackColor = SystemColors.ControlLight   'ﾌｫｰｶｽ取得時の背景色：ｸﾞﾚｰ
                    .BackColor = SystemColors.ControlLight      '背景色：ｸﾞﾚｰ
                End With
                
                '@=======================
                '@ 特殊流動対象全数選択ﾁｪｯｸ
                '@=======================
                Call prvProcAllSelect_Chk()
            
            End If
            
            '@=======================
            '@ 分割有/無選択可否ﾁｪｯｸ
            '@=======================
            Call prvDivideFlag_Chk()
            
            '@=======================
            '@ 確定ﾎﾞﾀﾝ制御ﾁｪｯｸ
            '@=======================
            Call prvcmdRegist_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "chkMoveSkip_Click"          'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtToCarrier_Change
    '機　能：ｱﾝﾛｰﾀﾞｷｬﾘｱIDﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/08/02 (Thu) 16:25:45 N.Kasai
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub txtToCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtToCarrier.Change

        Try
            
            '@=======================
            '@ 確定ﾎﾞﾀﾝ制御ﾁｪｯｸ
            '@=======================
            Call prvcmdRegist_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtToCarrier_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtToCarrier_Validate
    '機　能：ｱﾝﾛｰﾀﾞｷｬﾘｱIDﾃｷｽﾄ　入力確定(Validate)処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/07/25 (Wed) 13:36:39 N.Kasai
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub txtToCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtToCarrier.Validating

        Dim lblnAns                 As Boolean              '戻り値
        Dim ltypCarrCurstate        As CarrCurstate         'ｷｬﾘｱ状態確認要求構造体

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl Is cmdClose OrElse mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@-----------------------
            '@ ｱﾝﾛｰﾀﾞｷｬﾘｱIDﾁｪｯｸ
            '@-----------------------
            '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULLか
            If Trim(txtToCarrier.Text) = vbNullString Then
                Exit Sub
            End If
            
            '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDが6桁未満か
            If txtToCarrier.NowByte < txtToCarrier.ChrMaxByte Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM07W>$$キャリアIDは6桁で入力してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDにﾌｫｰｶｽをとどめる
                e.Cancel = True

                '@ｱﾝﾛｰﾀﾞｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = txtToCarrier.Name Then
                    Call pubSetFocus(txtToCarrier)
                End If
                Exit Sub
            End If

            '@***********************
            '@ ｷｬﾘｱ情報取得(要求)送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypCarrCurstate
                
                .strCarrierId = txtToCarrier.Text                       'ｱﾝﾛｰﾀﾞｷｬﾘｱID
                .strClassDivision = CPstrCD2D                           '処理区分2D：ｷｬﾘｱ一覧(空)
                .strMsgVer = CMstrcarrcurstateVer                       'ﾒｯｾｰｼﾞVer
                .strSbID = pstrSBID                                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strCarrierTypeID = mtypLotCurState.strCarrierTypeID    'ｷｬﾘｱﾀｲﾌﾟ
            End With

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrTxtToCarrierValidate)
            
            '@=======================
            '@ ｷｬﾘｱ状態確認
            '@=======================
            lblnAns = pubblnCarrcurstate_Sel(ltypCarrCurstate, True)
            
            '@ｷｬﾘｱ状態確認結果が"True：取得成功"か
            If lblnAns = True Then

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrTxtToCarrierValidate)
                
                '@確定ﾎﾞﾀﾝが有効か
                If cmdRegist.Enabled = True Then
                    
                    '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = txtToCarrier.Name Then
                        Call pubSetFocus(cmdRegist)
                    End If
                Else
                    '@ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = txtToCarrier.Name Then
                        Call pubSetFocus(cmdCommntInput)
                    End If
                End If

            Else
                '@ｷｬﾘｱ状態確認結果が"False：取得失敗"か
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrTxtToCarrierValidate)
                
                '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDにﾌｫｰｶｽを留める
                e.Cancel = True

                '@ｱﾝﾛｰﾀﾞｷｬﾘｱにﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = txtToCarrier.Name Then
                    Call pubSetFocus(txtToCarrier)
                End If
                Exit Sub
            End If
            	
			'@=======================
			'@ 確定ﾎﾞﾀﾝ制御ﾁｪｯｸ
			'@=======================
			Call prvcmdRegist_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtToCarrier_Validate"      'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCarrierSelect_Click
    '機　能：空きｷｬﾘｱ選択ﾎﾞﾀﾝ　Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/07/25 (Wed) 13:40:31 N.Kasai
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
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
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            pblnFormLoad = False
            
            '@***********************
            '@ ★起動条件(条件の確認(2007/07/23 落合様確認))
            '@ ①ｷｬﾘｱﾀｲﾌﾟはLOADER側と同じﾀｲﾌﾟであること。(同一ﾀｲﾌﾟ以外の分割はあり得ません！！)
            '@ ②洗浄ﾀｲﾌﾟは見る必要はありません。
            '@***********************
            pstrCarrierID = txtToCarrier.Text                       'ｱﾝﾛｰﾀﾞｷｬﾘｱID
            pstrCarrierTypeID = mtypLotCurState.strCarrierTypeID    'ｷｬﾘｱﾀｲﾌﾟ
            pstrCleanCondition = vbNullString                       '洗浄条件


            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 空きｷｬﾘｱ一覧画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00E0.Instance = New frmxxCM00E0()
            
            '@Form_Loadﾌﾗｸﾞが"False：起動失敗"か
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
                 
            '@ｱﾝﾛｰﾀﾞｷｬﾘｱがNULL以外(子画面でｷｬﾘｱが選択された)か
            If pstrCarrierID <> vbNullString Then
                
                '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDをｾｯﾄ
                txtToCarrier.Text = pstrCarrierID
            End If
            
            '@使用したﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrCarrierTypeID = vbNullString                'ｷｬﾘｱﾀｲﾌﾟ
            pstrCleanCondition = vbNullString               '洗浄条件
            pstrCarrierID = vbNullString                    'ｱﾝﾛｰﾀﾞｷｬﾘｱID
            
            '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtToCarrier)
            
            '@=======================
            '@ 確定ﾎﾞﾀﾝ制御ﾁｪｯｸ
            '@=======================
            Call prvcmdRegist_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
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

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 22:00:00 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2005/02/15 (Tue) 13:25:37 N.Kojima     戻り先画面の判定を追加(改善№512)
    '　　　：2005/03/02 (Wed) 09:36:13 S.Deguchi    引継構造体の初期化処理を追加
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim ltypCommonInfo      As CommonInfo       '引継ぎ構造体(共通)
        Dim ltypWorkEndInfo     As WorkEndInfo      '引継ぎ構造体(作業終了から)
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@作業終了から引き継がれた情報を初期化
            ptypWorkEndInfo = ltypWorkEndInfo
            
            '@引継ぎ情報のｷｬﾘｱIDがNULL以外(子画面起動)か
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                
                '@=======================
                '@ 親画面切り替え引継ぎ制御
                '@=======================
                Call pubChangeScreen_Set(Me)
            Else
                '@NULLの場合(単独起動)
                
                '@=======================
                '@ 終了関数実行
                '@=======================
                Call publngEnd_Proc(CPstrKeyEN00Y0, ltypCommonInfo)
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdClose_Click"             '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdAllSelect_Click
    '機　能：全数選択ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/18 (Mon) 15:54:39 S.Deguchi
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：????/??/?? (???) ??:??:?? ?.??????     全数選択ﾎﾞﾀﾝ処理に全選択/全解除の処理を追加する
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub cmdAllSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAllSelect.Click

        Dim llngCnt As Integer 'ｶｳﾝﾄ
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            With vsfSlotMap

                '@全数選択ﾌﾗｸﾞが"False：部分"か
                If mblnAllSelectFlag = False Then
                    
                    '@ｽﾛｯﾄﾏｯﾌﾟの先頭行～最終行までﾙｰﾌﾟ
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        
                        '@ﾁｪｯｸﾎﾞｯｸｽが有効か
                        If .GetCellCheck(llngCnt, CMlngvsfSlotMapColCheck) <> CheckEnum.None Then
                            
                            '@ﾁｪｯｸON
                            .SetCellCheck(llngCnt, CMlngvsfSlotMapColCheck, CheckEnum.Checked)
                        End If
                    Next llngCnt
                    
                    '@全選択ﾌﾗｸﾞを立てる
                    mblnAllSelectFlag = True
                Else
                    '@全数選択ﾌﾗｸﾞが"True：全数"か

                    '@ｽﾛｯﾄﾏｯﾌﾟの先頭行～最終行までﾙｰﾌﾟ
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1

                        '@ﾁｪｯｸﾎﾞｯｸｽが有効か
                        If .GetCellCheck(llngCnt, CMlngvsfSlotMapColCheck) <> CheckEnum.None Then
                            
                            '@ﾁｪｯｸOFF
                            .SetCellCheck(llngCnt, CMlngvsfSlotMapColCheck, CheckEnum.Unchecked)
                        End If
                    Next llngCnt
                    
                    '@全選択ﾌﾗｸﾞの初期化
                    mblnAllSelectFlag = False
                End If
            End With
            
            '@=======================
            '@ 分割有/無選択可否ﾁｪｯｸ
            '@=======================
            Call prvDivideFlag_Chk()
            
            '@=======================
            '@ 確定ﾎﾞﾀﾝ制御ﾁｪｯｸ
            '@=======================
            Call prvcmdRegist_Chk()
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdAllSelect_Click"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommntInput_Click
    '機　能：ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/24 (Tue) 17:23:55 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2005/10/26 (Wed) 08:46:12 S.Deguchi    不具合№2404の対応で,画面引継処理を修正
    '　　　：2008/06/11 (Wed) 14:12:16 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
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
            '@ 引継ぎﾃﾞｰﾀ作成
            '@ ※ptypLotprestateに格納してfrmxxCM0030を呼ぶ
            '@***********************
            With ptypLotprestate
                
                .strLotID = lblLotID.Text                       'ﾛｯﾄID
                .strFlowClass = lblFlowClass.Text               '種別
                .strWfNum = lblWFNo.Text                        '数量(WF)
                .strOpID = lblOpID.Text                         '大工程
                .strStartTime = lblStartDayTime.Text            '処理開始日時
                .strPdId = lblPdID.Text                         '機種ID
                .strSpecialFlg = lblS.Text                      '特殊特性
                .strNowST = lblStatus.Text                      'ﾛｯﾄ状態
                .strStepID = lblStepID.Text                     '小工程
                .strEngEmpName = lblLotManager.Text             'ﾛｯﾄ担当
                .strLimitTime = ptypLotprestate.strLimitTime    '制限時間
                .strWarnTime = ptypLotprestate.strWarnTime      '警告時間
                .strComments = txtLotCommnt.Text                'ﾛｯﾄｺﾒﾝﾄ
                .strLotLastUpdate = mstrLotLastUpdate           'ﾛｯﾄ最終更新日時
                '@↓2020/01/15 (Wed) 11:00:04 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .strGRBClass = lblGRB.Text                   'GRB
                '@↑2020/01/15 (Wed) 11:00:04 Y.Yoneyama 「.Netへ反映未」 **************************************************
                
                pstrCarrierID = txtCarrier.Text                 'ｷｬﾘｱID
                
                '@ﾌｫｰﾑ起動区分に"True：子画面起動"をｾｯﾄ
                pblnfrmxxCM0030Kbn = True
            
                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
                pblnFormLoad = False
                
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@ ﾛｯﾄｺﾒﾝﾄ画面　起動処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM0030.Instance = New frmxxCM0030()
                
                '@=======================
                '@ 機能関連情報取得処理
                '@=======================
                Call pubMenuItemCorrelation_Set(CPstrKeyEN0140, lstrTitle)

                '@ﾛｯﾄｺﾒﾝﾄ画面のﾀｲﾄﾙ設定
                frmxxCM0030.Instance.Text = lstrTitle
                
                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True：起動成功"か
                If pblnFormLoad = True Then

                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    '@ ﾛｯﾄｺﾒﾝﾄ画面　表示処理
                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    frmxxCM0030.Instance.ShowDialog(Me)
                    frmxxCM0030.Instance = Nothing
                    
                    '@ﾛｯﾄｺﾒﾝﾄをｾｯﾄ
                    txtLotCommnt.Text = .strComments
                    
                    '@最終更新日時を更新
                    mstrLotLastUpdate = ptypLotprestate.strLotLastUpdate
                Else
                    '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False：起動失敗"か

                    '@∇∇∇∇∇∇∇∇∇∇∇
                    '@ ｱﾝﾛｰﾄﾞ処理
                    '@∇∇∇∇∇∇∇∇∇∇∇
                    frmxxCM0030.Instance = Nothing
                
                    '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
                    pblnFormLoad = True
                    
                    Exit Sub
                End If
                
                '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
                SendKeys.SendWait(CPstrSendKeysTab)

            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdCommntInput_Click"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：確定ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 22:01:43 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2005/08/17 (Wed) 14:01:46 S.Deguchi    ﾘﾜｰｸ時ﾘﾜｰｸ理由設定画面起動処理追加
    '　　　：2008/10/08 (Wed) 12:03:00 M.Koni       追加流動時のｶﾞｲﾀﾞﾝｽ情報修正(CarrierID) <案件No.03137>
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    '　　　：2009/08/11 (Tue) 10:29:20 N.Kojima     試作実験ﾛｯﾄの場合、確定時に検査工数削減のMsgを表示する。(案件№03542)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean              '戻り値
        Dim lstrLotID               As String               '特殊流動ﾛｯﾄID
        Dim lstrMsg                 As String               '変換後ﾒｯｾｰｼﾞ
        Dim lstrMsg3                As String               'ﾒｯｾｰｼﾞ:%3
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim ltypWorkEndInfo         As WorkEndInfo          '初期化用構造体
        Dim ltypReworkInfoList      As ReworkInfoList       '初期化用構造体
        Dim ltypLotReWorkSet        As LotReWorkSet         'ﾛｯﾄ作業終了構造体
        Dim ltypLotReWorkSetInit    As LotReWorkSet         'ﾛｯﾄ作業終了構造体(ｸﾘｱ用)

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
            '@ ②ﾌｫｰﾑのﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then
                Exit Sub
            End If


            '@=======================
            '@ 特殊流動確定前ﾁｪｯｸ処理
            '@=======================
            lblnAns = prvblnLotReworkInput_Chk
            
            '@確定前ﾁｪｯｸ処理結果が"False：ﾁｪｯｸNG"か
            If lblnAns = False Then
                Exit Sub
            End If


            '@=======================
            '@ 特殊流動登録送信ﾃﾞｰﾀ作成処理
            '@=======================
            Call prvLotReworkDataSet_Proc(ltypLotReWorkSet)

            '@ﾘﾜｰｸがﾁｪｯｸOFFか
            If optSPFlow0.Checked = False Then
                
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@ 作業者ｺｰﾄﾞ入力画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM0010.Instance.ShowDialog(Me)
                frmxxCM0010.Instance = Nothing
            
                '@作業者ｺｰﾄﾞ入力画面にて"ｷｬﾝｾﾙ"ﾎﾞﾀﾝが押下されたか
                If pblnCancel = True Then
                    Exit Sub
                End If
            
                '@ﾛｸﾞｲﾝﾕｰｻﾞｰIDを作業者IDに格納
                ltypLotReWorkSet.strEmpID = pstrUserID
            End If


            '@-----------------------
            '@ ﾒｯｾｰｼﾞ用の引数(%3)を設定
            '@-----------------------
            '@「ﾘﾜｰｸ」がﾁｪｯｸONか
            If optSPFlow0.Checked = True Then
                
                '@「ﾘﾜｰｸ」をｾｯﾄ
                lstrMsg3 = optSPFlow0.Text
            End If
            
            '@「追加流動」がﾁｪｯｸONか
            If optSPFlow1.Checked = True Then
                
                '@「追加流動」をｾｯﾄ
                lstrMsg3 = optSPFlow1.Text
            End If


            '@★ Case条件がTrueになるかにより処理分岐 ★
            Select Case True

                '@〓 「ﾘﾜｰｸ」がﾁｪｯｸON 〓
                Case optSPFlow0.Checked

                    '@送信構造体の内容をﾊﾟﾌﾞﾘｯｸ変数へ退避
                    ptypLotReworkSet = ltypLotReWorkSet
                    
                    '@引継構造体を初期化
                    With ptypReworkInfoList
                        
                        .strExcpNo = vbNullString                   '異常処理№
                        .strLotID = vbNullString                    'ﾘﾜｰｸ流動用ﾛｯﾄID
                        .blnSelectFlag = mblnAllSelectFlag          '全選択ﾌﾗｸﾞ
                    End With

                    '@起動区分ﾌﾗｸﾞの初期化
                    pblnfrmxxEN00Y0Kbn = False
                    
                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    '@ ﾘﾜｰｸ原因設定画面　起動処理
                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    frmxxEN00Y1.Instance = New frmxxEN00Y1()
                    
                    '@起動区分ﾌﾗｸﾞが"False：起動失敗"か
                    If pblnfrmxxEN00Y0Kbn = False Then
                        
                        '@∇∇∇∇∇∇∇∇∇∇∇
                        '@ ｱﾝﾛｰﾄﾞ処理
                        '@∇∇∇∇∇∇∇∇∇∇∇
                        frmxxEN00Y1.Instance = Nothing
                        
                        Exit Sub
                    End If
                    
                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    '@ ﾘﾜｰｸ原因設定画面　表示処理
                    '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                    frmxxEN00Y1.Instance.ShowDialog(Me)
                    frmxxEN00Y1.Instance = Nothing
                    
                    '@ﾘﾜｰｸﾛｯﾄIDがNULLか
                    If ptypReworkInfoList.strLotID = vbNullString Then

                        '@子画面で確定されなかったので、処理終了
                        Exit Sub
                    Else
                        '@ﾘﾜｰｸﾛｯﾄIDがNULL以外の場合(子画面で確定された場合)

                        '@ｷｬﾘｱIDの初期化
                        txtCarrier.Text = vbNullString
                        
                        '@=======================
                        '@ 画面初期化処理
                        '@=======================
                        Call prvFrmxxEN00Y0_Init()
                        
                        '@=======================
                        '@ 各種ｺﾝﾄﾛｰﾙ(ｵﾌﾞｼﾞｪｸﾄ)制御処理(無効化)
                        '@=======================
                        Call prvAnyObjectControl_Proc(False)
                        
                        '@ﾘﾜｰｸﾛｯﾄIDを表示
                        lblSpecialLotID.Text = ptypReworkInfoList.strLotID
                        
                        '@不適合品処理票発行№を表示
                        lblExcpNo.Text = ptypReworkInfoList.strExcpNo
                        
                        '@各種引継構造体を初期化
                        ptypWorkEndInfo = ltypWorkEndInfo           '作業終了からの引継ぎ情報
                        ptypLotReworkSet = ltypLotReWorkSetInit     'ﾘﾜｰｸ登録情報
                        ptypReworkInfoList = ltypReworkInfoList     'ﾘﾜｰｸ情報
                        
                        '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtCarrier)
                    End If


                '@〓 「追加流動」がﾁｪｯｸON 〓
                Case optSPFlow1.Checked

                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)
                    
                    '@移載工程ｽｷｯﾌﾟが"0:移載あり"か
                    If ltypLotReWorkSet.strMoveSkip = CPstrZero Then
                        
                        '@=======================
                        '@ 特殊流動登録(移載工程あり)
                        '@=======================
                        lblnAns = pubblnLotReworkSet_Upd(ltypLotReWorkSet, _
                                                         lstrLotID, _
                                                         lstrGuidMsg, _
                                                         lstrGuidMsgCode)

                    Else
                        '@移載工程ｽｷｯﾌﾟが"1:移載なし"の場合

                        '@=======================
                        '@ 特殊流動登録(移載工程なし)
                        '@=======================
                        lblnAns = pubblnLotReworkSetDirect_Upd(ltypLotReWorkSet, _
                                                               lstrLotID, _
                                                               lstrGuidMsg, _
                                                               lstrGuidMsgCode)

                    End If   
                    
                    '@特殊流動登録結果が"True：登録成功"か
                    If lblnAns = True Then
                        
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
                        
                        '@=======================
                        '@ ｶﾞｲﾀﾞﾝｽﾒｯｾｰｼﾞ表示制御
                        '@=======================
                        Call pubGuidMsg_Set(lstrGuidMsgCode, lstrGuidMsg, Me)

                        '@分割有が"True：ﾁｪｯｸON"か
                        If optDivFlag1.Checked = True Then
                            
                            '@移載工程ｽｷｯﾌﾟが"0：ﾁｪｯｸOFF"か
                            If chkMoveSkip.Checked = False Then
                                
                                '@-----------------------
                                '@ 分割有り、移載工程ｽｷｯﾌﾟしない場合は、移載工程へ送出。
                                '@-----------------------
                                
                                '@  →　"<TRM1MI>$$%3工程に送出しました。移載が必要です。移載元キャリア[%1] ロット[%2]"
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001M, txtCarrier.Text, lstrLotID, lstrMsg3)
                            Else
                                '@-----------------------
                                '@ 分割有り、移載工程ｽｷｯﾌﾟの場合は指定したｱﾝﾛｰﾀﾞｷｬﾘｱに分割WFを自動で移載し、追加流動工程へ送出。
                                '@-----------------------
                                
                                '@　→　"<TRM1LI>$$%3工程に送出しました。キャリア[%1] ロット[%2]"
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001L, txtToCarrier.Text, lstrLotID, lstrMsg3)
                            End If

                        Else
                            '@-----------------------
                            '@ 分割無がﾁｪｯｸONの場合(移載も無いのでそのまま追加流動工程に送出)
                            '@-----------------------

                            '@　→　"<TRM1LI>$$%3工程に送出しました。キャリア[%1] ロット[%2]"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001L, txtCarrier.Text, lstrLotID, lstrMsg3)

                        End If

                        '@ﾒｯｾｰｼﾞ表示
                        Call pubVsfInfo_Disp(pstrDMsg)

        '@↓2009/08/10 (Mon) 17:28:41 N.Kojima **************************************************

                        '@起動SBが"1A0：基板"か
                        If pstrSBID = CPstrSBID1A0 Then
                
                            '@分割有、かつ移載工程ｽｷｯﾌﾟか(♪移載工程ｽｷｯﾌﾟの場合はこのﾀｲﾐﾝｸﾞで表示)
                            If optDivFlag1.Checked = True And chkMoveSkip.Checked = True Then
                
                                '@ﾛｯﾄの種別が"試作/実験品：GG,TS,WS,ZZ"か
                                If lblFlowClass.Text = CPstrFlowClassGG Or _
                                    lblFlowClass.Text = CPstrFlowClassTS Or _
                                    lblFlowClass.Text = CPstrFlowClassWS Or _
                                    lblFlowClass.Text = CPstrFlowClassZZ Then
                                    
                                    '@表示ﾒｯｾｰｼﾞを編集(追加流動ロット[XXX])
                                    lstrMsg = CPstrAdd & CPstrBrLeft & lstrLotID & CPstrBrRight
                                
                                    '@表示ﾒｯｾｰｼﾞ変換
                                    '@"<TRM1ZI>$$%1が[%2]されました。$検査工数削減の為、必要に応じて外観・現像検査工程の
                                    '@ 検査ウェハ枚数を見直して下さい。$%3 %4"のﾒｯｾｰｼﾞ表示
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0024, CPstrLot, CPstrDivide, lstrMsg, vbNullString)
                                    Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                                End If
                            End If
                        End If

        '@↑2009/08/10 (Mon) 17:28:41 N.Kojima **************************************************


                        '@ｷｬﾘｱIDの初期化
                        txtCarrier.Text = vbNullString
                        
                        '@=======================
                        '@ 画面初期化処理
                        '@=======================
                        Call prvFrmxxEN00Y0_Init()
                        
                        '@=======================
                        '@ 各種ｺﾝﾄﾛｰﾙ(ｵﾌﾞｼﾞｪｸﾄ)制御処理(無効化)
                        '@=======================
                        Call prvAnyObjectControl_Proc(False)
                        
                        '@追加流動ﾛｯﾄIDを表示
                        lblSpecialLotID.Text = lstrLotID
                        
                        '@不適合品処理票発行№にNULLを表示
                        lblExcpNo.Text = vbNullString
                        
                        '@引継構造体を初期化
                        ptypWorkEndInfo = ltypWorkEndInfo
                        
                        '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtCarrier)
                    Else
                        '@特殊流動登録結果が"False：登録失敗"か
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                    End If
                
            End Select

            Exit Sub
            
        Catch ex As Exception
            
            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
            Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdRegist_Click"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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

    '関数名：prvFrmxxEN00Y0_Init
    '機　能：画面初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 11:05:05 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 13:49:56 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2004/10/18 (Mon) 11:29:58 S.Deguchi    特殊流動分のﾗﾍﾞﾙ他の初期化処理を追加
    '　　　：2005/04/19 (Tue) 11:15:45 N.Kasai      不適合品処理発行№初期化追加
    '　　　：2008/03/28 (Fri) 16:25:45 S.Ochiai     No.02541対応(ﾘﾜｰｸ/追加流動ﾙｰﾄID選択)
    '　　　：2008/06/11 (Wed) 14:12:48 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub prvFrmxxEN00Y0_Init()
        
        Dim lstrFormTitle   As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        
        Try
            
            '@=======================
            '@ 機能関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00Y0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@-----------------------
            '@ 各種ｺﾝﾄﾛｰﾙの初期化
            '@-----------------------
            '@ﾗﾍﾞﾙ
            lblLotID.Text = vbNullString                    'ﾛｯﾄID
            lblFlowClass.Text = vbNullString                '流動区分
            lblWFNo.Text = vbNullString                     'FW枚数
            lblOpID.Text = vbNullString                     '大工程ID
            lblStartDayTime.Text = vbNullString             '開始日時
            lblPdID.Text = vbNullString                     '機種名
            lblS.Text = vbNullString                        '特殊特性
            lblStatus.Text = vbNullString                   '状態
            lblStepID.Text = vbNullString                   '小工程ID
            lblLotManager.Text = vbNullString               'ﾛｯﾄ担当
            lblTimeLimit.Text = vbNullString                '時間制約
            lblSpecialLotID.Text = vbNullString             '特殊流動ﾛｯﾄID
            lblExcpNo.Text = vbNullString                   '不適合品処理票発行№
            '@↓2020/01/15 (Wed) 11:00:25 Y.Yoneyama 「.Netへ反映未」 **************************************************
            lblGRB.Text = vbNullString                      'GRB
            '@GRB背景色
            lblGRB.BackColor = lblLotManager.BackColor
            '@↑2020/01/15 (Wed) 11:00:25 Y.Yoneyama 「.Netへ反映未」 **************************************************
            
            '@ﾓｼﾞｭｰﾙ変数の初期化
            mstrLotLastUpdate = vbNullString                'ﾛｯﾄ最終更新日時
            mstrCarrierID = vbNullString                    'ｷｬﾘｱID(ﾒｯｾｰｼﾞ成功時のｷｬﾘｱID)
            mblnAllSelectFlag = False                       '全選択ﾌﾗｸﾞ(True:全選択,False:それ以外)

            '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optSPFlow0.Checked = False                      'ﾘﾜｰｸ
            optSPFlow0.Enabled = False
            optSPFlow1.Checked = False                      '追加流動
            optSPFlow1.Enabled = False
            
            '@分割有無ﾎﾞﾀﾝ
            optDivFlag0.Checked = False                     '分割無
            optDivFlag0.Enabled = False
            optDivFlag1.Checked = False                     '分割有
            optDivFlag1.Enabled = False
                
            '@移載工程ｽｷｯﾌﾟﾁｪｯｸﾎﾞｯｸｽ
            With chkMoveSkip
                .Enabled = False                            '無効
                .Checked = False                            'ﾁｪｯｸOFF
            End With
            
            '@特殊ﾙｰﾄｺﾝﾎﾞﾎﾞｯｸｽ
            cmbRouteId.Clear                                '初期化
            cmbRouteId.Enabled = False                      '無効
            
            '@各種ﾎﾞﾀﾝ
            cmdCommntInput.Enabled = False                  'ﾛｯﾄｺﾒﾝﾄ
            cmdCarrierSelect.Enabled = False                '空きｷｬﾘｱ選択ﾎﾞﾀﾝ
            
            '@作業ﾒﾓの設定
            With txtWorkMemo
                
                .Text = vbNullString                        'NULL
                .ChrMaxByte = CPlngLotCommentsMaxByte       '最大ﾊﾞｲﾄ数
                
                '@=======================
                '@ 作業ﾒﾓﾃｷｽﾄ変更時処理
                '@=======================
                Call txtWorkMemo_Change(txtWorkMemo, New EventArgs())
            End With
            
            '@ﾛｯﾄｺﾒﾝﾄの設定
            With txtLotCommnt
                
                .Text = vbNullString                        'NULL
                .Locked = True                              'ﾛｯｸ
                .Enabled = True                             '無効
                .BackColor = SystemColors.ControlLight      '背景色(ｸﾞﾚｰ)
                .GotBackColor = SystemColors.ControlLight   'ﾌｫｰｶｽ取得時の背景色(ｸﾞﾚｰ)
            End With
            
            '@ｱﾝﾛｰﾀﾞｷｬﾘｱの設定
            With txtToCarrier
                
                .Text = vbNullString                        'NULL
                .Enabled = False                            '無効
                .BackColor = SystemColors.ControlLight      '背景色(ｸﾞﾚｰ)
                .GotBackColor = SystemColors.ControlLight   'ﾌｫｰｶｽ取得時の背景色(ｸﾞﾚｰ)
            End With
            
            '@=======================
            '@ 各種ｸﾞﾘｯﾄﾞの初期化
            '@=======================
            Call prvvsfSlotMap_init                         'ｽﾛｯﾄﾏｯﾌﾟ
            Call prvVsfNextStepInfo_Init                    '特殊流動先次工程一覧
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvFrmxxEN00Y0_Init"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvFrmxxEN00Y0_Disp
    '機　能：画面情報表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 11:16:50 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2004/09/09 (Thu) 20:58:40 Y.Yamagishi  時間制限表示変更(不具合改善№693)
    '　　　：2004/09/14 (Tue) 10:28:44 N.Kojima　   数量表示(CF,TPALﾛｯﾄ対応)修正(不具合改善№730)
    '　　　：2004/09/24 (Fri) 11:38:44 Y.Yamagishii 制限時間以上の場合文字色を青に変更(不具合改善№825)
    '　　　：2004/12/09 (Thu) 11:45:14 S.Deguchi    時間制限のﾌｫｰﾏｯﾄが日付になっていたのをｶﾝﾏ編集へ修正(不具合改善№279)
    '　　　：2005/05/26 (Thu) 15:10:37 N.Kasai      LP_FLAG判定追加
    '　　　：2006/06/08 (Thu) 15:07:12 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2008/06/11 (Wed) 14:13:08 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub prvFrmxxEN00Y0_Disp()
        
        Try

            With ptypLotprestate
            
                lblLotID.Text = .strLotID                                                   'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass                                           '流動区分
                lblOpID.Text = .strOpID                                                     '大工程ID
                If IsDate(.strStartTime) = True Then
                    lblStartDayTime.Text = Format$(CDate(.strStartTime), CPstrDateFormat)   '処理開始日時
                End If
                lblPdID.Text = .strPdId                                                     '機種ID
                lblS.Text = .strSpecialFlg                                                  '特殊特性
                lblStatus.Text = .strNowST                                                  '状態
                lblStepID.Text = .strStepID                                                 '小工程ID
                lblLotManager.Text = .strEngEmpName                                         'ﾛｯﾄ担当
                '@↓2020/01/15 (Wed) 11:00:50 Y.Yoneyama 「.Netへ反映未」 **************************************************
                lblGRB.Text = .strGRBClass                                                  'GRB
                '@GRB背景色
                lblGRB.BackColor = pubGRBBackColor(.strGRBClass, lblLotManager.BackColor)
                '@↑2020/01/15 (Wed) 11:00:50 Y.Yoneyama 「.Netへ反映未」 **************************************************
                 
                '@時間制約有無の表示
                If .strLimitTime <> vbNullString Then

                    '@時間制約がﾌﾟﾗｽの場合
                    If CLng(.strLimitTime) >= 0 Then

                        '@制限時間以下or処理時間制限以下の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@制限時間先大工程+制限時間先小工程+制限時間
                            '@ﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Format(CLng(.strLimitTime), CPstrCFKnmaFormat) & CPstrh
                            
                            '@右寄せ
                            lblTimeLimit.TextAlign = ContentAlignment.TopRight
                            
                            '@警告時間が設定されている場合
                            If .strWarnTime <> vbNullString Then
                                
                                '@時間制限が警告時間を過ぎている,且つ制限時間がｵｰﾊﾞｰしていない場合
                                If CLng(.strWarnTime) < 0 And CLng(.strLimitTime) >= 0 Then
                                    
                                    '@ﾌｫﾝﾄｶﾗｰを紫に変更
                                    lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple)  '紫色
                                Else
                                     '@ﾌｫﾝﾄｶﾗｰを黒に変更
                                    lblTimeLimit.ForeColor = Color.Black                                    '黒
                                End If
                            End If
                        End If

                    Else
                        '@制限時間がﾏｲﾅｽの場合

                        '@制限時間先大工程+制限時間先小工程+制限時間
                        '@右寄せ
                        lblTimeLimit.TextAlign = ContentAlignment.TopRight
                        
                        '@ForColorの変更
                        lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed)                 '赤色
                        
                        '@制限時間以下or処理時間制限以下の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@ﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Format$(CLng(.strLimitTime), CPstrCFKnmaFormat) & CPstrh
                        End If
                        
                        '@制限時間以上の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID2 Then
                            
                            '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Replace(Format$(CLng(.strLimitTime), CPstrCFKnmaFormat), _
                                                           CPstrReplaceMinus, _
                                                           vbNullString) & CPstrh
                        End If
                    End If
                End If
             
             
                '@★ CF_FLAGにより処理分岐(WF枚数とﾁｯﾌﾟ枚数の表示を切替) ★
                Select Case .strCfFlag
                    
                    '@〓 1：CFﾛｯﾄ 〓
                    Case CPstrCF
                        
                        '@LP_FLAGが"1：大板"か
                        If .strLpFlag = CPstrLP Then

                            lblWFNo.Text = .strWfNum                                                'WF枚数
                        Else
                            '@LP_FLAGが"1：大板"以外(小板)の場合
                        
                            lblWFNo.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)       'ﾁｯﾌﾟ枚数
                        End If


                    '@〓 その他：CFﾛｯﾄ以外 〓
                    Case Else
                        
                        '@TPALﾛｯﾄか
                        If Trim(Strings.Left(.strLotID, 2)) = CPstrTpalLot Then
                            
                            lblWFNo.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)       'ﾁｯﾌﾟ枚数
                        Else
                            '@TPALﾛｯﾄ以外(TFT基板ﾛｯﾄ)の場合

                            lblWFNo.Text = .strWfNum                                                'WF枚数
                        End If
                End Select
                
                txtLotCommnt.Text = .strComments                                                    'ﾛｯﾄｺﾒﾝﾄ
                mstrLotLastUpdate = .strLotLastUpdate                                               '最終更新日時
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvFrmxxEN00Y0_Disp"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvVsfSlotMap_Init
    '機　能：ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/23 (Mon) 10:25:36 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub prvvsfSlotMap_init()

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ
        
        Try
            
            '@-----------------------
            '@ ｽﾛｯﾄﾏｯﾌﾟの初期設定
            '@-----------------------
            With vsfSlotMap
                
                .Redraw = False                                                         'NSYS 描画ﾛｯｸ
                .Clear                                                                  '初期化
                '.AllowBigSelection = False                                             'ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '.AllowSelection = False                                                '複数選択不可

                .Rows.Count = .Rows.Fixed

                .Rows.Count = CMlngvsfSlotMapRows                                       '行数
                .Cols.Count = CMlngvsfSlotMapCols                                       '列数
                .Font = New Font(CMstrGridFontName,CType(9, Single),Font.Style)         'ﾌｫﾝﾄ
                .Cols(CMlngvsfSlotMapColSlot).DataType = GetType(System.Object)
                .Cols(CMlngvsfSlotMapColSlot).Style.Font = New Font(CMstrGridFontName,CMlngvsfSlotFontSize,.Font.Style)
                .Cols(CMlngvsfSlotMapColWFID).DataType = GetType(System.Object)
                .Cols(CMlngvsfSlotMapColWFID).Style.Font = New Font(CMstrGridFontName,CMlngvsfSlotFontSize,.Font.Style)
                '@↓2019/11/18 (Mon) 18:30:17 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .Cols(CMlngvsfSlotMapColGRB).DataType = GetType(System.Object)
                .Cols(CMlngvsfSlotMapColGRB).Style.Font = New Font(CMstrGridFontName,CMlngvsfSlotFontSize,.Font.Style)
                '@↑2019/11/18 (Mon) 18:30:17 Y.Yoneyama 「.Netへ反映未」 **************************************************

                .FocusRect = FocusRectEnum.None                                         'ｶﾚﾝﾄｾﾙの周囲に描画するﾌｫｰｶｽ枠のｽﾀｲﾙを設定(なし)
                .HighLight = HighLightEnum.WithFocus                                    'ｸﾞﾘｯﾄﾞにﾌｫｰｶｽがある時のみﾊｲﾗｲﾄ                

                '@文字表示位置設定
                .Cols(CMlngvsfSlotMapColSlot).TextAlign = TextAlignEnum.RightCenter           'ｽﾛｯﾄ№(右中央)
                .Cols(CMlngvsfSlotMapColCheck).ImageAlign = ImageAlignEnum.CenterCenter
                .Cols(CMlngvsfSlotMapColWFID).TextAlign = TextAlignEnum.LeftCenter            'WFID(左中央)
                '@↓2019/11/18 (Mon) 18:30:17 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .Cols(CMlngvsfSlotMapColGRB).TextAlign = TextAlignEnum.LeftCenter               'GRB(左中央)
                '@↑2019/11/18 (Mon) 18:30:17 Y.Yoneyama 「.Netへ反映未」 **************************************************

                '@一覧表の表題設定
                '@↓2019/11/18 (Mon) 18:30:40 Y.Yoneyama 「.Netへ反映未」 **************************************************
                'Dim cellRange As CellRange = .GetCellRange(CMlngGridRowTitle, CMlngvsfSlotMapColSlot, CMlngGridRowTitle, CMlngvsfSlotMapColWFID)
                Dim cellRange As CellRange = .GetCellRange(CMlngGridRowTitle, CMlngvsfSlotMapColSlot, CMlngGridRowTitle, CMlngvsfSlotMapColGRB)
                '@↑2019/11/18 (Mon) 18:30:40 Y.Yoneyama 「.Netへ反映未」 **************************************************
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                            '中央表示
                headerStyle.Font = New Font(CMstrGridFontName,CMlngvsfSlotFontSize,Font.Style)
                headerStyle.ForeColor = Color.Yellow                                          '文字色（黄色）
                headerStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)             '背景色（紺色）
                cellRange.Style = headerStyle
                .Rows(CMlngGridRowTitle).Height = CMlngvsfSlotMapHHeight                      '高さ
                
                '@一覧表のｽﾛｯﾄ№設定
                Dim slotNoStyle As CellStyle = .Styles.Add("slotNoStyle")
                slotNoStyle.TextAlign = TextAlignEnum.RightCenter
                slotNoStyle.BackColor = System.Drawing.SystemColors.ControlLight

                For llngCnt = .Rows.Fixed To .Rows.Count - 1
                    .Col = CMlngvsfSlotMapColSlot                   '列（ｽﾛｯﾄ№列）
                    .Row = llngCnt                                  '行
                    cellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapColSlot, llngCnt, CMlngvsfSlotMapColSlot)
                    cellRange.Style = slotNoStyle
                    .SetData(llngCnt, CMlngvsfSlotMapColSlot, _
                        CStr(Format$(CMlngvsfSlotMapRows - llngCnt, CPstrSlotNoFormat)))
                    .Rows(llngCnt).Height = CMlngvsfSlotMapHeight   '行の高さ
                Next llngCnt
                        
                '@列幅、ﾀｲﾄﾙ設定
                .Cols(CMlngvsfSlotMapColSlot).Width = CMlngvsfSlotMapColWSlot                   'ｽﾛｯﾄ№
                .SetData(CMlngGridRowTitle, CMlngvsfSlotMapColSlot, CMstrvsfSlotMapColTSlot)    'ｽﾛｯﾄ№
                
                .Cols(CMlngvsfSlotMapColCheck).Width = CMlngvsfSlotMapColWCheck                 'ﾁｪｯｸﾎﾞｯｸｽ
                .SetData(CMlngGridRowTitle, CMlngvsfSlotMapColCheck, CMstrvsfSlotMapColTCheck)  'ﾁｪｯｸﾎﾞｯｸｽ
                
                .Cols(CMlngvsfSlotMapColWFID).Width = CMlngvsfSlotMapColWWFID                   'WFID
                .SetData(CMlngGridRowTitle, CMlngvsfSlotMapColWFID, CMstrvsfSlotMapColTWFID)    'WFID

                '@↓2019/11/18 (Mon) 18:31:14 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .Cols(CMlngvsfSlotMapColGRB).Width = CMlngvsfSlotMapColWGRB                     'GRB
                .SetData(CMlngGridRowTitle, CMlngvsfSlotMapColGRB, CMstrvsfSlotMapColTGRB)      'GRB
                '@↑2019/11/18 (Mon) 18:31:14 Y.Yoneyama 「.Netへ反映未」 **************************************************
                
                'NSYS 描画ﾛｯｸ
                .Redraw = True

                '@ｽﾛｯﾄﾏｯﾌﾟを無効にする
                .Enabled = False
                
                '@初期表示行番号設定
                .TopRow = .Rows.Count - 1
                .Row = .Rows.Count - 1
                
                '@ｽｸﾛｰﾙﾎﾞﾀﾝを無効にする
                cmdUP.Enabled = False       '上(▲)
                cmdDown.Enabled = False     '下(▼)

            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvVsfSlotMap_Init"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvVsfSlotMap_Disp
    '機　能：ｽﾛｯﾄﾏｯﾌﾟｸﾞﾘｯﾄﾞ表示処理
    '引　数：ltypWaferList：ｷｬﾘｱWF情報構造体
    '戻り値：なし
    '作成日：2004/08/23 (Mon) 12:01:28 M.Miura
    '更新日：2009/08/12 (Wed) 10:00:34 N.Kojima
    '備　考：
    '　　　：2004/10/18 (Mon) 13:07:31 S.Deguchi    ｽﾛｯﾄﾏｯﾌﾟ作成時にﾁｪｯｸﾎﾞｯｸｽ設定処理を追加
    '　　　：2004/10/27 (Wed) 11:46:31 Y.Yamagishi  最大ｽﾛｯﾄ数を超えたｾﾙのﾊﾞｯｸｶﾗｰを薄い灰色に変更
    '　　　：                                       最大ｽﾛｯﾄ数以内のWFの存在しないｾﾙのﾊﾞｯｸｶﾗｰを濃い灰色に変更
    '　　　：                                       最大ｽﾛｯﾄ数分のみ表示
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub prvVsfSlotMap_Disp(ByRef ltypWaferList As Waferlist)

        Dim llngCnt         As Integer   'ｶｳﾝﾄ
        Dim llngListCnt     As Integer   'ﾘｽﾄｶｳﾝﾄ
        Dim llngRow         As Integer   '行番号
        Dim llngRows        As Integer   '行数
        Dim cellRange       As CellRange 'NSYS

        Try

            With vsfSlotMap
                
                'NSYS 描画ﾛｯｸ
                .Redraw = False

                '@ｽﾛｯﾄﾏｯﾌﾟの最大ｽﾛｯﾄ数をｷｬﾘｱに応じたｽﾛｯﾄ数に変更
                .Rows.Count = ltypWaferList.strSlotSize + 1
                
                '@ｽﾛｯﾄ№を設定
                llngCnt = 1
                Do While .Rows.Count > llngCnt
                    .SetData(.Rows.Count - llngCnt, CMlngvsfSlotMapColSlot, Format$(llngCnt, CPstrSlotNoFormat))
                    llngCnt = llngCnt + 1
                Loop
                
                '@行数格納
                llngRows = .Rows.Count

                '@ﾛｯﾄWF情報ﾘｽﾄ件数格納
                llngListCnt = ltypWaferList.lngListCnt

                For llngCnt = 0 To llngListCnt - 1
                    
                    '@ｽﾛｯﾄﾎﾟｼﾞｼｮﾝが数値か
                    If IsNumeric(ltypWaferList.typWfList(llngCnt).strSlotPosition) = True Then
                        
                        '@ｽﾛｯﾄ№格納
                        llngRow = ltypWaferList.typWfList(llngCnt).strSlotPosition
                        
                        '@ｽﾛｯﾄ№から行番号を取得
                        llngRow = llngRows - llngRow
                        
                        '@WFIDをｾｯﾄ
                        .SetData(llngRow, CMlngvsfSlotMapColWFID, ltypWaferList.typWfList(llngCnt).strWfId)         '@WFID

                        '@↓2019/11/18 (Mon) 18:37:47 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        .SetData(llngRow, CMlngvsfSlotMapColGRB, ltypWaferList.typWfList(llngCnt).strGRBClass)      'GRB
                        '@↑2019/11/18 (Mon) 18:37:47 Y.Yoneyama 「.Netへ反映未」 **************************************************
    
                        '@WFIDがNULL以外か
                        If .GetData(llngRow, CMlngvsfSlotMapColWFID) <> vbNullString Then
                            
                            '@-----------------------
                            '@ 部分ﾘﾜｰｸ/追加流動(分割無)の場合の対応
                            '@-----------------------
                            '@ﾘﾜｰｸﾌﾗｸﾞが"0：???"か
                            If ltypWaferList.typWfList(llngCnt).strReworkFlag = CMstrReworkFlagOff Then
                                
                                '@ﾁｪｯｸﾎﾞｯｸｽを表示
                                .SetCellCheck(llngRow, CMlngvsfSlotMapColCheck, CheckEnum.Unchecked)
                            Else
                                '@ﾘﾜｰｸﾌﾗｸﾞが"0：???"以外の場合
                                
                                '@ﾘﾜｰｸﾓｰﾄﾞがNULL以外か
                                If ltypWaferList.typWfList(llngCnt).strReworkMode <> vbNullString Then
                                    
                                    '@ﾁｪｯｸﾎﾞｯｸｽを表示
                                    .SetCellCheck(llngRow, CMlngvsfSlotMapColCheck, CheckEnum.Unchecked)
                                    .Cols(CMlngvsfSlotMapColCheck).TextAlign = TextAlignEnum.CenterCenter
                                Else
                                    '@ﾘﾜｰｸﾓｰﾄﾞがNULLの場合

                                    '@ﾁｪｯｸﾎﾞｯｸｽを非表示
                                    .SetCellCheck(llngRow, CMlngvsfSlotMapColCheck, CheckEnum.None)
                                End If
                            End If
                        Else
                            '@WFIDがNULLの場合

                            '@WFIDがない場合はﾁｪｯｸﾎﾞｯｸｽは非表示
                            .SetData(llngRow, CMlngvsfSlotMapColCheck, CheckEnum.None)
                        End If
                    End If
                Next llngCnt

                '@上下ｽｸﾛｰﾙﾎﾞﾀﾝの制御
                cmdUP.Enabled = True            '上(▲)：有効
                cmdDown.Enabled = False         '下(▼)：無効


                For llngCnt = 1 To llngRows - 1
                    
                    '@WFIDがNULLか
                    If .GetData(llngCnt, CMlngvsfSlotMapColWFID) = vbNullString Then
                        
                        '@ﾊﾞｯｸｶﾗｰを濃い灰色に変更
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                        '@↓2019/11/18 (Mon) 18:38:48 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        'cellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapColCheck, llngCnt, CMlngvsfSlotMapColWFID)
                        cellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapColCheck, llngCnt, CMlngvsfSlotMapColGRB)
                        '@↑2019/11/18 (Mon) 18:38:48 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        cellRange.Style = newStyle
                    Else
                        '@WFIDがNULL以外の場合

                        '@ﾁｪｯｸﾎﾞｯｸｽが非表示か
                        If .GetCellCheck(llngCnt, CMlngvsfSlotMapColCheck) = CheckEnum.None Then
                            
                            '@ﾊﾞｯｸｶﾗｰを薄い灰色に変更
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                            '@↓2019/11/18 (Mon) 18:39:20 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            'cellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapColCheck, llngCnt, CMlngvsfSlotMapColWFID)
                            cellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapColCheck, llngCnt, CMlngvsfSlotMapColGRB)
                            '@↑2019/11/18 (Mon) 18:39:20 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            cellRange.Style = newStyle
                        Else
                            '@ﾁｪｯｸﾎﾞｯｸｽが表示されている場合

                            '@ﾊﾞｯｸｶﾗｰを白に変更
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_Window")
                            newStyle.BackColor = SystemColors.Window
                            '@↓2019/11/18 (Mon) 18:39:39 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            'cellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapColCheck, llngCnt, CMlngvsfSlotMapColWFID)
                            cellRange = .GetCellRange(llngCnt, CMlngvsfSlotMapColCheck, llngCnt, CMlngvsfSlotMapColGRB)
                            '@↑2019/11/18 (Mon) 18:39:39 Y.Yoneyama 「.Netへ反映未」 **************************************************
                            cellRange.Style = newStyle
                        End If

                        '@↓2020/01/15 (Wed) 10:50:31 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        '@GRB背景色
                        Dim newStyleGRB As CellStyle = .Styles.Add("GRBColor" + llngCnt.ToString)
                        newStyleGRB.BackColor = pubGRBBackColor(.GetData(llngCnt, CMlngvsfSlotMapColGRB), .GetCellStyle(llngCnt, CMlngvsfSlotMapColWFID).BackColor)
                        Dim cellRangeGRB = .GetCellRange(llngCnt, CMlngvsfSlotMapColGRB)
                        cellRangeGRB.Style = newStyleGRB
                        '@↑2020/01/15 (Wed) 10:50:31 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    End If
                Next llngCnt

                'NSYS 描画ﾛｯｸ
                .Redraw = True
                
                '@ｽﾛｯﾄﾏｯﾌﾟを有効にする
                .Enabled = True

            End With
                
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvvsfSlotMap_Disp"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
                
        End Try
    End Sub

    '関数名：prvVsfSlotMap_Set
    '機　能：ｽﾛｯﾄﾏｯﾌﾟ初期表示位置設定
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/26 (Tue) 11:09:51 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub prvvsfSlotMap_Set()

        Dim llngCnt             As Integer      'ｶｳﾝﾄ
        Dim llngRows            As Integer      '行数
        Dim lblnExistWFFlag     As Boolean      'WF有無ﾌﾗｸﾞ(True：WF有り、False：初期値・WF無し)
          
        Try

            With vsfSlotMap
                
                '@ｽﾛｯﾄﾏｯﾌﾟの行数取得
                llngRows = .Rows.Count
                
                '@最大ｽﾛｯﾄが25より小さい場合
                If llngRows < CMlngvsfSlotMapRows Then
                    
                    '@ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行をﾀｲﾄﾙに設定
                    .Row = .Rows.Fixed - 1
                    
                    '@ｽﾛｯﾄｻｲｽﾞが1ﾍﾟｰｼﾞの最大表示行数より大きいか
                    If vsfSlotMap.Rows.Count > CMlngvsfSlotPageRows + 1 Then
                        
                        '@上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝを有効にする
                        cmdUP.Enabled = True
                    Else
                        '@下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝを無効にする
                        cmdUP.Enabled = False
                    End If

                    Exit Sub
                End If


                '@-----------------------
                '@ ｽﾛｯﾄ№01～10にWFがあるかﾁｪｯｸ
                '@-----------------------
                For llngCnt = CMlngvsfSlotMapRows - 1 To CMlngSlotNo10Row Step -1
                    
                    '@WFIDがNULL以外か
                    If .GetData(llngCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                        
                        '@WF有無ﾌﾗｸﾞに"True：WF有り"をｾｯﾄ
                        lblnExistWFFlag = True
                        Exit For
                    End If
                Next llngCnt
                
                '@WF有無ﾌﾗｸﾞが"False：WF無し"か
                If lblnExistWFFlag = False Then
                    
                    '@-----------------------
                    '@ ｽﾛｯﾄ№25～16にWFがあるかﾁｪｯｸ
                    '@-----------------------
                    For llngCnt = .Rows.Fixed To CMlngSlotNo16Row
                        
                        '@WFIDがNULL以外か
                        If .GetData(llngCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                            
                            '@WF有無ﾌﾗｸﾞに"True：WF有り"をｾｯﾄ
                            lblnExistWFFlag = True
                            Exit For
                        End If
                    Next llngCnt
                Else
                    '@WF有無ﾌﾗｸﾞが"True：WF有り"の場合

                    '@WF有無ﾌﾗｸﾞに"False：WF無し"をｾｯﾄ
                    lblnExistWFFlag = False
                End If

                '@WF有無ﾌﾗｸﾞが"True：WF有り"か
                If lblnExistWFFlag = True Then

                    .TopRow = .Rows.Fixed            '先頭行の設定
                    .Row = .Rows.Fixed - 1           '現在行の設定

                    cmdUP.Enabled = False            '上(▲)ﾎﾞﾀﾝ：無効
                    
                    '@ｽﾛｯﾄ数が1ﾍﾟｰｼﾞの表示行より多いか
                    If .Rows.Count > CMlngvsfSlotPageRows + 1 Then
                        
                        '@下(▼)ﾎﾞﾀﾝを有効にする
                        cmdDown.Enabled = True
                    Else
                        '@下(▼)ﾎﾞﾀﾝを無効にする
                        cmdDown.Enabled = False
                    End If
                Else
                    '@WF有無ﾌﾗｸﾞが"False：WF無し"の場合

                    .TopRow = CMlngSlotNo10Row       '先頭行の設定
                    .Row = .Rows.Fixed - 1           '現在行の設定
                    
                    '@ｽﾛｯﾄ数が1ﾍﾟｰｼﾞの表示行より多いか
                    If .Rows.Count > CMlngvsfSlotPageRows + 1 Then

                        '@上(▲)ﾎﾞﾀﾝを有効にする
                        cmdUP.Enabled = True
                    Else
                        '@上(▲)ﾎﾞﾀﾝを無効にする
                        cmdUP.Enabled = False
                    End If
                End If
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvVsfSlotMap_Set"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvVsfNextStepInfo_Init
    '機　能：特殊流動先次工程ｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 11:31:36 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub prvVsfNextStepInfo_Init()

        Try

            With vsfNextStepInfo
                
                '@ﾌﾟﾛﾊﾟﾃｨ初期設定
                .Redraw = False                                                             'NSYS 描画ﾛｯｸ
                .Clear                                                                      '初期化
                .Cols.Count = CMlngNextStepInfoColWpName + 1                                '列数
                .Rows.Count = CMlngGridFixedRows                                            '行数
                .Cols.Fixed = CMlngGridFixedCols                                            '固定列数
                .Rows.Fixed = CMlngGridFixedRows                                            '固定行数
                .SelectionMode = SelectionModeEnum.Default                                  '行選択
                '.FillStyle = flexFillRepeat                                                'ﾌﾟﾛﾊﾟﾃｨの設定対象(選択ｾﾙ)
                .FocusRect = FocusRectEnum.Light                                            'ｶﾚﾝﾄｾﾙのﾌｫｰｶｽ枠(細い枠)
                .HighLight = HighLightEnum.Never                                            'ﾊｲﾗｲﾄ表示しない
                .Font = New Font(CMstrGridFontName,CMlngNextStepInfoFontSize,Font.Style)    'ﾌｫﾝﾄ
                .ScrollBars = System.Windows.Forms.ScrollBars.None                          'ｽｸﾛｰﾙﾊﾞｰ(なし)
                '.AutoSizeMode = flexAutoSizeColWidth                                       'ｵｰﾄｻｲｽﾞ(列)
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter                  '文字列の最後に省略符号
                .AllowResizing = AllowResizingEnum.Columns                                  '列幅の変更許可
                .ExtendLastCol = True                                                       '右端の列をｸﾞﾘｯﾄﾞに合わせる
                
                '@表示位置の設定(ﾃﾞﾌｫﾙﾄ)
                .Cols(CMlngNextStepInfoColOpID).TextAlign = TextAlignEnum.LeftCenter        '大工程(左中央寄せ)
                .Cols(CMlngNextStepInfoColStepID).TextAlign = TextAlignEnum.LeftCenter      '小工程(左中央寄せ)
                .Cols(CMlngNextStepInfoColDefault).TextAlign = TextAlignEnum.LeftCenter     'ﾌｪﾌｫﾙﾄ(左中央寄せ)
                .Cols(CMlngNextStepInfoColWpName).TextAlign = TextAlignEnum.LeftCenter      '装置名(左中央寄せ)
                
                '@ｸﾞﾘｯﾄﾞの表題設定
                Dim cellRange As CellRange = .GetCellRange(CMlngGridRowTitle, CMlngNextStepInfoColOpID, CMlngGridRowTitle, CMlngNextStepInfoColWpName)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                                                    '文字色
                headerStyle.BackColor =  ColorTranslator.FromWin32(CPlngBlueColor)                                                      '背景色
                With .Styles.Normal.Font
                    headerStyle.Font = New Font(.FontFamily, CMlngNextStepInfoFontSize, .Style, .Unit, .GdiCharSet, .GdiVerticalFont)   'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                End With
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                                                      '文字位置
                cellRange.Style = headerStyle
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngGridRowTitle, CMlngNextStepInfoColOpID, CMstrNextStepInfoColTOpID)          '大工程
                .SetData(CMlngGridRowTitle, CMlngNextStepInfoColStepID, CMstrNextStepInfoColTStepID)      '小工程
                .SetData(CMlngGridRowTitle, CMlngNextStepInfoColDefault, CMstrNextStepInfoColTDefault)    'ﾃﾞﾌｫﾙﾄ
                .SetData(CMlngGridRowTitle, CMlngNextStepInfoColWpName, CMstrNextStepInfoColTWpName)      '装置名               
                
                '@結合ｾﾙの設定
                .AllowMerging = AllowMergingEnum.RestrictAll              '行と列
                .Cols(CMlngNextStepInfoColOpID).AllowMerging = True       '大工程
                .Cols(CMlngNextStepInfoColStepID).AllowMerging = True     '小工程
                .Cols(CMlngNextStepInfoColDefault).AllowMerging = True    'ﾃﾞﾌｫﾙﾄ

                '@列幅の設定(大工程～装置名)
                .AutoSizeCols(CMlngNextStepInfoColOpID, CMlngNextStepInfoColWpName, 6)
                .Cols(CMlngNextStepInfoColOpID).Width = CMlngGridColWidthOpID
                .Cols(CMlngNextStepInfoColStepID).Width = CMlngGridColWidthStepID
                .Cols(CMlngNextStepInfoColDefault).Width = CMlngGridColWidthDefault
                .Cols(CMlngNextStepInfoColWpName).Width = CMlngGridColWidthWpName

                '@ﾀｲﾄﾙの高さ
                .Rows(CMlngGridRowTitle).Height = CMlngGridTitleHeight

                'NSYS 描画ﾛｯｸ
                .Redraw = True

                '@無効
                .Enabled = False            '特殊流動先次工程一覧
                cmdLeft.Enabled = False     '左("<<")ﾎﾞﾀﾝ
                cmdRight.Enabled = False    '右(">>")ﾎﾞﾀﾝ
                
                '@=======================
                '@ ｸﾞﾘｯﾄﾞ表示後処理(ｸﾞﾘｯﾄﾞ共通仕様)
                '@=======================
                Call pubVsfDisp(vsfNextStepInfo, cmdNextUP, cmdNextDown)
            
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvVsfNextStepInfo_Init"    '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvVsfNextStepInfo_Disp
    '機　能：特殊流動先工程ｸﾞﾘｯﾄﾞ表示処理
    '引　数：ltypLotNextStep：特殊流動先工程構造体
    '　　　：llngCnt        ：特殊流動先工程件数
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 13:26:38 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2007/07/09 (Mon) 13:59:58 N.Kasai      ｸﾞﾘｯﾄﾞ共通
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub prvVsfNextStepInfo_Disp(ByRef ltypLotNextStep As LotNextStep, _
                                        ByVal llngCnt As Integer)

        Dim lllngWPListCnt  As Integer  '装置件数
        Dim llngLoopCnt     As Integer  'ｶｳﾝﾀ
        Dim llngRowCnt      As Integer  '行ｶｳﾝﾀ

        Try

            With vsfNextStepInfo
                
                '@描画ﾛｯｸ
                .Redraw = False
                
                '@ｶｳﾝﾀの初期化
                llngRowCnt = .Rows.Fixed
                
                '@特殊流動先次工程の装置総件数ﾙｰﾌﾟ
                For llngLoopCnt = 0 To llngCnt - 1
                    
                    '@特殊流動先次小工程の装置件数ﾙｰﾌﾟ
                    For lllngWPListCnt = 0 To ltypLotNextStep.strNextStepList(llngLoopCnt).lngWpListCnt - 1
                        
                        '@行数の設定
                        .Rows.Count = llngRowCnt + 1
                        
                        '@特殊流動先次大工程
                        .SetData(llngRowCnt, CMlngNextStepInfoColOpID, _
                            ltypLotNextStep.strNextStepList(llngLoopCnt).strNextOpId)
                        
                        '@特殊流動先次小工程
                        .SetData(llngRowCnt, CMlngNextStepInfoColStepID, _
                            ltypLotNextStep.strNextStepList(llngLoopCnt).strNextStepId)
                        
                        '@★ 工程ﾌﾗｸﾞにより処理分岐 ★
                        Select Case ltypLotNextStep.strNextStepList(llngLoopCnt).strStepDivision
                            
                            '@〓 0：代替工程 〓
                            Case CMstrStepDivision0
                                
                                '@ﾃﾞﾌｫﾙﾄに"　"をｾｯﾄ
                                .SetData(llngRowCnt, CMlngNextStepInfoColDefault, CMstrDaitaiStep)
                                
                            '@〓　1：ﾃﾞﾌｫﾙﾄ工程 〓
                            Case CMstrStepDivision1
                                
                                '@ﾃﾞﾌｫﾙﾄに"○"をｾｯﾄ
                                .SetData(llngRowCnt, CMlngNextStepInfoColDefault, CMstrDefaultStep)
                                
                            '@〓 その他 〓
                            Case Else
                                
                                '@ﾃﾞﾌｫﾙﾄにNULLをｾｯﾄ
                                .SetData(llngRowCnt, CMlngNextStepInfoColDefault, vbNullString)

                        End Select
                        
                        '@装置
                        .SetData(llngRowCnt, CMlngNextStepInfoColWpName, _
                            ltypLotNextStep.strNextStepList(llngLoopCnt).strWPList(lllngWPListCnt).strWpName)

                        '@明細の行の高さ
                        .Rows(llngRowCnt).Height = CMlngGridRowHeight
                        
                        '@ｶｳﾝﾀのｲﾝｸﾘﾒﾝﾄ
                        llngRowCnt = llngRowCnt + 1
                    
                    Next lllngWPListCnt

                Next llngLoopCnt
                
                '@ﾀｲﾄﾙの行の高さ
                .Rows(CMlngGridRowTitle).Height = CMlngGridTitleHeight
                
                '@ﾃﾞｰﾀに合わせて列幅設定(大工程～装置名)
                .AutoSizeCols(CMlngNextStepInfoColOpID, CMlngNextStepInfoColWpName, 6)

                '@=======================
                '@ ｸﾞﾘｯﾄﾞ表示後処理(ｸﾞﾘｯﾄﾞ共通仕様)
                '@=======================
                Call pubVsfDisp(vsfNextStepInfo, cmdNextUP, cmdNextDown)
                
                '@=======================
                '@ 左右("<<",">>")ｽｸﾛｰﾙﾎﾞﾀﾝ制御(ｸﾞﾘｯﾄﾞ共通化関数)
                '@=======================
                Call pubCmdLREnable_Set(vsfNextStepInfo, cmdLeft, cmdRight)
                
                '@描画の再開
                .Redraw = True
                
                '@2件以上ﾃﾞｰﾀがあるか
                If .Rows.Count > .Rows.Fixed Then
                    
                    '@特殊流動先工程一覧を有効にする
                    .Enabled = True
                    .Row = - 1
                End If

            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvVsfNextStepInfo_Disp"    '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvProcAllSelect_Chk
    '機　能：特殊流動対象全数選択ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 20:07:02 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2004/10/21 (Thu) 14:19:04 S.Deguchi    関数名称変更
    '　　　：2005/04/04 (Mon) 12:40:00 S.Deguchi    次工程が存在しない場合には,全選択ﾎﾞﾀﾝを使用不可にする処理を追加
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub prvProcAllSelect_Chk()
        
        Dim llngCnt         As Integer  'ｶｳﾝﾀ
        
        Try
            
            '@ﾌﾗｸﾞ(特殊流動対象選択変更)
            mblnAllSelectFlag = True

            With vsfSlotMap

                For llngCnt = 1 To .Rows.Count - 1
                    
                    '@WFIDがNULL以外、かつ対象WFのﾁｪｯｸOFF、かつﾁｪｯｸﾎﾞｯｸｽが表示されているか
                    If .GetData(llngCnt, CMlngvsfSlotMapColWFID) <> vbNullString And _
                        .GetCellCheck(llngCnt, CMlngvsfSlotMapColCheck) <> CheckEnum.Checked And _
                        .GetCellCheck(llngCnt, CMlngvsfSlotMapColCheck) <> CheckEnum.None Then
                        
                        '@全選択ﾌﾗｸﾞに"False：部分"をｾｯﾄ
                        mblnAllSelectFlag = False
                        Exit For
                    End If
                Next llngCnt

            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvProcAllSelect_Chk"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvDivideFlag_Chk
    '機　能：分割有/無選択可否ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 20:07:02 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2004/10/21 (Thu) 14:19:04 S.Deguchi    関数名称変更
    '　　　：2005/04/04 (Mon) 12:40:00 S.Deguchi    次工程が存在しない場合には,全選択ﾎﾞﾀﾝを使用不可にする処理を追加
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub prvDivideFlag_Chk()
        
        Dim llngCnt             As Integer      '汎用ｶｳﾝﾀ
        Dim lstrAllSelectFlag   As Boolean      '全選択ﾌﾗｸﾞ(True：全WF選択、False：未選択WF有)
        Dim lstrSelectFlag      As Boolean      '選択ﾌﾗｸﾞ  (True：選択WF有、False：選択WF無)
        
        Try
            
            
            '@各種ﾌﾗｸﾞの初期化(特殊流動対象選択変更)
            lstrAllSelectFlag = True        '全選択ﾌﾗｸﾞ
            lstrSelectFlag = False          '選択ﾌﾗｸﾞ

            With vsfSlotMap

                For llngCnt = 1 To .Rows.Count - 1
                    
                    '@WFIDがNULL以外か
                    If .GetData(llngCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then

                        '@ﾁｪｯｸOFFか
                        If .GetCellCheck(llngCnt, CMlngvsfSlotMapColCheck) <> CheckEnum.Checked Then
                            
                            '@全選択ﾌﾗｸﾞに"False：未選択WF有"をｾｯﾄ
                            lstrAllSelectFlag = False
                        Else
                            '選択ﾌﾗｸﾞに"True：選択WF有”をｾｯﾄ
                            lstrSelectFlag = True
                        End If
                    End If
                Next llngCnt


                '@-----------------------
                '@ 分割有/無ｵﾌﾟｼｮﾝﾎﾞﾀﾝ制御
                '@-----------------------
                '@全選択ﾌﾗｸﾞが"True：全WF選択"、または選択ﾌﾗｸﾞが"False：選択WF無"か
                If lstrAllSelectFlag = True Or lstrSelectFlag = False Then
                    
                    '@全WF選択時またはWFが選択されていない場合
                    optDivFlag0.Checked = False      '分割無
                    optDivFlag0.Enabled = False
                    optDivFlag1.Checked = False      '分割有
                    optDivFlag1.Enabled = False
                    
                    '@移載工程ｽｷｯﾌﾟﾁｪｯｸﾎﾞｯｸｽを無効にし、ﾁｪｯｸOFFにする
                    chkMoveSkip.Enabled = False
                    chkMoveSkip.Checked = False
                Else
                    '@全選択ﾌﾗｸﾞが"False：未選択WF有"、かつ選択ﾌﾗｸﾞが"True：選択WF有"か
                    
                    '@-----------------------
                    '@ 一部のWFのみ選択されている場合
                    '@-----------------------
                    '@移載工程ｽｷｯﾌﾟがﾁｪｯｸONか
                    If chkMoveSkip.Checked = True Then
                        
                        '@移載工程ｽｷｯﾌﾟ指定時は分割が前提である為, 分割有/無指定は不可(分割有を設定)
                        optDivFlag0.Checked = False      '分割無
                        optDivFlag0.Enabled = False
                        optDivFlag1.Checked = True       '分割有
                        optDivFlag1.Enabled = True

                        Exit Sub
                    End If

                    '@基板(1A0)起動か
                    If pstrSBID = CPstrSBID1A0 Then
                        
                        '@基板の場合は分割有/無選択可能
                        optDivFlag0.Enabled = True       '分割無
                        optDivFlag1.Enabled = True       '分割有
                    Else
                        '@組立(2A0)起動の場合

                        '@基板以外(組立他)の場合は分割有/無選択不可(分割有を強制選択)
                        optDivFlag0.Checked = False      '分割無
                        optDivFlag0.Enabled = False
                        optDivFlag1.Checked = True       '分割有
                        optDivFlag1.Enabled = True
                    End If
                    
                    '移載工程ｽｷｯﾌﾟを有効にする
                    chkMoveSkip.Enabled = True

                End If

            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvDivideFlag_Chk"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbRouteId_Disp
    '機　能：代替ﾙｰﾄ(ﾘﾜｰｸ/追加流動)ｺﾝﾎﾞ作成
    '引　数：なし
    '戻り値：なし
    '作成日：2008/03/31 (Mon) 11:40:00 S.Ochiai
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2008/03/31 (Mon) 11:40:00 S.Ochiai     No.02541対応(ﾘﾜｰｸ/追加流動ﾙｰﾄID選択)
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub prvCmbRouteId_Disp(ByRef ltypAltRouteListAns As MasAltRouteListAns)

        Dim llngCnt         As Integer          '汎用ｶｳﾝﾄ
        Dim lstrCmbText     As String           'ｺﾝﾎﾞﾎﾞｯｸｽ表示用

        Try
            
            '@-----------------------
            '@ ｺﾝﾎﾞﾎﾞｯｸｽ設定
            '@-----------------------
            With cmbRouteId
                
                .Clear                                                                          'ｸﾘｱ
                .DispCols = CMlngCmbDispCols                                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColRouteName                                              'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColRouteId                                              '値取得列
                .DirectInput = False                                                            'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Text = vbNullString                                                            '初期化
                .Font = New Font(CMstrGridFontName, CType(CMlngCmbFontSize, Single))            'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(CMstrGridFontName, CType(CMlngCmbGridFontSize, Single))    'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                                  '行の高さ
                .ColAlignment(CMlngCmbGridColRouteId) = TextAlignEnum.LeftCenter                '左寄中央揃え                
                        

                '@情報ｾｯﾄ(ﾙｰﾄID/ｺﾒﾝﾄ)
                For llngCnt = 0 To ltypAltRouteListAns.lngAltRouteListCnt - 1
                    
                    '@ﾙｰﾄIDが"-1：空ﾘﾜｰｸ(追加流動)"か
                    If ltypAltRouteListAns.typAltRouteList(llngCnt).strRouteID = CPstrRouteEmpty Then
                        
                        '@ﾘﾜｰｸがﾁｪｯｸONか
                        If optSPFlow0.Checked = True Then
                            
                            '@ｺﾝﾎﾞに"(空)ﾘﾜｰｸ"をｾｯﾄ
                            lstrCmbText = CPstrReworkEmpty
                        Else
                            '@ｺﾝﾎﾞに"(空)追加流動"をｾｯﾄ
                            lstrCmbText = CPstrTsuikaEmpty
                        End If
                    Else
                        '@ﾙｰﾄIDが"-1：空ﾘﾜｰｸ(追加流動)"以外の場合
                        
                        '@取得したﾙｰﾄIDを格納
                        lstrCmbText = ltypAltRouteListAns.typAltRouteList(llngCnt).strRouteID
                    End If
                    
                    '@ｺﾝﾎﾞ内容の設定(ﾙｰﾄID/ｺﾒﾝﾄ)
                    .AddItem(lstrCmbText _
                           & vbTab _
                           & ltypAltRouteListAns.typAltRouteList(llngCnt).strRouteID _
                           & vbTab _
                           & ltypAltRouteListAns.typAltRouteList(llngCnt).strComments)

                Next llngCnt

                '@ﾃﾞﾌｫﾙﾄﾙｰﾄ(ﾘﾜｰｸ/追加流動)を選択状態とする
                If .ListCount >= 1 Then
                    .ListIndex = 0
                End If
            
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvCmbRouteId_Disp"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvAnyObjectControl_Proc
    '機　能：各種ｺﾝﾄﾛｰﾙ(ｵﾌﾞｼﾞｪｸﾄ)制御処理
    '引　数：lblnEnable：True:有効,False:無効
    '戻り値：なし
    '作成日：2004/08/26 (Thu) 11:15:48 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 10:40:38 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub prvAnyObjectControl_Proc(Optional ByVal lblnEnable As Boolean = False)
            
        Try

            '@***********************
            '@ 引数で渡されたTrue or Falseにより有効/無効を制御
            '@***********************
            txtWorkMemo.Enabled = lblnEnable        '作業ﾒﾓ
            txtLotCommnt.Enabled = lblnEnable       'ﾛｯﾄｺﾒﾝﾄ
            cmdCommntInput.Enabled = lblnEnable     'ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ
            cmdAllSelect.Enabled = lblnEnable       '全数選択ﾎﾞﾀﾝ
            
            '@引数が"False：無効化"か
            If lblnEnable = False Then
                cmdRegist.Enabled = False           '確定ﾎﾞﾀﾝ
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvAnyObjectControl_Proc"   '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvblnLotReworkInput_Chk
    '機　能：特殊流動確定前ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：ﾁｪｯｸOK、False：ﾁｪｯｸNG
    '作成日：2004/08/24 (Tue) 20:31:13 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Function prvblnLotReworkInput_Chk() As Boolean

        Dim lblnFlag        As Boolean      '判定ﾌﾗｸﾞ(True：OK、False：NG)
        Dim llngCnt         As Integer      'ｶｳﾝﾀ
		Dim lblnAns			As Boolean
		Dim lstrResult		As String

        Try
            
            '@戻り値の初期化
            prvblnLotReworkInput_Chk = False
            
            '@-----------------------
            '@ ｷｬﾘｱ関連ﾁｪｯｸ
            '@-----------------------
            '@ｷｬﾘｱIDがNULLか
            If txtCarrier.Text = vbNullString Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM01W>$$キャリアIDが設定されていません。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If
            
            '@ｷｬﾘｱIDが6桁以外か
            If Len(txtCarrier.Text) <> CPlngCarrierMaxLength Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM07W>$$キャリアIDは6桁で入力してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If


            '@-----------------------
            '@ ﾛｯﾄ関連ﾁｪｯｸ
            '@-----------------------
            '@ﾛｯﾄIDがNULLか
            If lblLotID.Text = vbNullString Then

                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM22W>$$ロットIDが設定されていません。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0022)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If


            '@-----------------------
            '@ ｽﾛｯﾄﾏｯﾌﾟ関連ﾁｪｯｸ
            '@-----------------------
            '@判定ﾌﾗｸﾞ初期化
            lblnFlag = False

            With vsfSlotMap

                For llngCnt = 1 To .Rows.Count - 1
                    
                    '@ﾁｪｯｸが付いていて、かつWFIDがNULL以外か
                    If .GetCellCheck(llngCnt, CMlngvsfSlotMapColCheck) = CheckEnum.Checked And _
                        .GetData(llngCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                        
                        '@判定ﾌﾗｸﾞに"True：OK"をｾｯﾄ
                        lblnFlag = True
                        Exit For
                    End If
                Next llngCnt
            End With
            
            '@判定ﾌﾗｸﾞが"False：NG"か
            If lblnFlag = False Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM1RW>$$ウエハIDが設定されていません。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001R)
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@ｽﾛｯﾄﾏｯﾌﾟが有効か
                If vsfSlotMap.Enabled = True Then
                    
                    '@ｽﾛｯﾄﾏｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfSlotMap)
                End If

                Exit Function
            End If


            '@-----------------------
            '@ 移載工程ｽｷｯﾌﾟ関連ﾁｪｯｸ
            '@-----------------------
            '@移載工程ｽｷｯﾌﾟがﾁｪｯｸONか
            If chkMoveSkip.Checked = True Then
                
                '@全選択ﾌﾗｸﾞが"False：部分"か(True：全選択、False：部分)
                If mblnAllSelectFlag = False Then
                    
                    '@-----------------------
                    '@ ｱﾝﾛｰﾀﾞｷｬﾘｱ関連ﾁｪｯｸ
                    '@-----------------------
                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULLか
                    If txtToCarrier.Text = vbNullString Then
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM01W>$$キャリアIDが設定されていません。設定を見直してください。"のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtToCarrier)
                        Exit Function
                    End If
                    
                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDが6桁以外か
                    If Len(txtToCarrier.Text) <> CPlngCarrierMaxLength Then
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM07W>$$キャリアIDは6桁で入力してください。"のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtToCarrier)
                        Exit Function
                    End If
                Else
                    '@全選択ﾌﾗｸﾞが"True：全数"の場合

                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULL以外か
                    If txtToCarrier.Text <> vbNullString Then
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM0FW>$$全数WFが選択されています。移載先キャリアの設定はできません。"のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000F)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtToCarrier)
                        Exit Function
                    End If
                End If
            End If
            
            '@戻り値に"True：ﾁｪｯｸOK"をｾｯﾄ
            prvblnLotReworkInput_Chk = True
            
            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnLotReworkInput_Chk"   '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvCmdRegist_Chk
    '機　能：確定ﾎﾞﾀﾝ制御ﾁｪｯｸ
    '引　数：lblncmdRegist：確定ﾎﾞﾀﾝ制御ﾌﾗｸﾞ(True：制御する、False：制御しない)
    '戻り値：なし
    '作成日：2004/08/23 (Mon) 19:51:54 M.Miura
    '更新日：2009/08/11 (Tue) 15:25:11 N.Kojima
    '備　考：
    '　　　：2005/04/04 (Mon) 12:37:23 S.Deguchi    次工程が存在しない場合には,確定ﾎﾞﾀﾝは使用不可にする処理追加
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub prvcmdRegist_Chk()
        
        Dim llngCnt         As Integer  'ｶｳﾝﾀ
        Dim lblnFlag        As Boolean  '特殊流動可否ﾌﾗｸﾞ(True：特殊流動可、False：特殊流動不可)
        
        Try
            
            '@特殊流動ﾌﾗｸﾞの初期化(特殊流動不可)
            lblnFlag = False

            With vsfSlotMap

                For llngCnt = 1 To .Rows.Count - 1
                    
                    '@ﾁｪｯｸが付いていて、かつWFIDがNULL以外か
                    If .GetCellCheck(llngCnt, CMlngvsfSlotMapColCheck) = CheckEnum.Checked And _
                        .GetData(llngCnt, CMlngvsfSlotMapColWFID) <> vbNullString Then
                        
                        '@特殊流動可否ﾌﾗｸﾞに"True：可"をｾｯﾄ
                        lblnFlag = True
                        Exit For
                    End If
                Next llngCnt
            End With
           
            '@-----------------------
            '@ 移載工程ｽｷｯﾌﾟ制御
            '@-----------------------
            '@移載工程ｽｷｯﾌﾟがﾁｪｯｸONか
            If chkMoveSkip.Checked = True Then
                
                '@全数選択ﾌﾗｸﾞが"True：全数"か
                If mblnAllSelectFlag = True Then
                    
                    '@移載工程ｽｷｯﾌﾟﾁｪｯｸﾎﾞｯｸｽの状態変更
                    chkMoveSkip.Checked = False                     'ﾁｪｯｸOFF
                    chkMoveSkip.Enabled = False                     '無効
                    
                    '@空きｷｬﾘｱ選択ﾎﾞﾀﾝを無効にする
                    cmdCarrierSelect.Enabled = False
                    
                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱの設定
                    With txtToCarrier
                        
                        .Text = vbNullString                        'NULL
                        .Enabled = False                            '無効
                        .GotBackColor = SystemColors.ControlLight   'ﾌｫｰｶｽ取得時の背景色：ｸﾞﾚｰ
                        .BackColor = SystemColors.ControlLight      '背景色：ｸﾞﾚｰ
                    End With
                Else
                    '@全数選択ﾌﾗｸﾞが"False：部分"の場合
                    
                    '@移載工程ｽｷｯﾌﾟﾁｪｯｸﾎﾞｯｸｽの状態変更
                    chkMoveSkip.Enabled = True                      '有効

                    '@空きｷｬﾘｱ選択ﾎﾞﾀﾝを有効にする
                    cmdCarrierSelect.Enabled = True

                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱの設定
                    With txtToCarrier

                        .Enabled = True                             '有効
                        .GotBackColor = Color.White                 'ﾌｫｰｶｽ取得時の背景色：ｸﾞﾚｰ
                        .BackColor = Color.White                    '背景色：ｸﾞﾚｰ
                    End With
                    
                    '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDがNULLか
                    If txtToCarrier.Text = vbNullString Then

                        '@特殊流動可否ﾌﾗｸﾞに"False：不可"をｾｯﾄ
                        lblnFlag = False
                    End If
                End If
            End If
            
            
            '@次工程ﾃﾞｰﾀが無しか
            If vsfNextStepInfo.Rows.Count = 1 Then
                
                '@特殊流動可否ﾌﾗｸﾞに"False：不可"をｾｯﾄ
                lblnFlag = False
            End If

            '@分割有/無が有効、かつ分割有/無が選択されていないか
            If (optDivFlag0.Enabled = True Or _
                optDivFlag1.Enabled = True) And _
                optDivFlag0.Checked = False And _
                optDivFlag1.Checked = False Then
                
                '@特殊流動可否ﾌﾗｸﾞに"False：不可"をｾｯﾄ
                lblnFlag = False
            End If
          
            '@特殊流動可否ﾌﾗｸﾞが"True：可"か
            If lblnFlag = True Then
                
                '@確定ﾎﾞﾀﾝを有効にする
                cmdRegist.Enabled = True
            Else
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvCmdRegist_Chk"           '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvLotReworkDataSet_Proc
    '機　能：特殊流動登録送信ﾃﾞｰﾀ作成処理
    '引　数：ltypLotReWorkSet：特殊流動ﾛｯﾄ登録構造体
    '戻り値：なし
    '作成日：2004/08/25 (Wed) 09:15:02 M.Miura
    '更新日：2009/08/11 (Tue) 13:44:26 N.Kojima
    '備　考：
    '　　　：2004/10/20 (Wed) 11:47:17 S.Deguchi    ClassDivision追加対応
    '　　　：2005/09/20 (Tue) 09:17:44 S.Deguchi    運用障害№540の対応でｶﾗﾑstrReworkReason追加
    '　　　：2005/12/16 (Fri) 14:15:03 S.Deguchi    ﾕｰｻﾞｰ要望№0121対応
    '　　　：2007/05/01 (Tue) 12:43:34 N.Kasai      LPﾌﾗｸﾞ追加(№01884)
    '　　　：2009/08/11 (Tue) 13:44:26 N.Kojima     案件№03542のついでにｿｰｽ整備。
    Private Sub prvLotReworkDataSet_Proc(ByRef ltypLotReWorkSet As LotReWorkSet)
        
        Dim llngCnt     As Integer  'ｶｳﾝﾄ
        Dim llngWFcnt   As Integer  '特殊流動WF枚数
        Dim lstrWFID    As String   'WFID

        Try

            '@特殊流動WF枚数初期化
            llngWFcnt = 0
            
            '@***********************
            '@ 特殊流動ﾛｯﾄ登録送信ﾃﾞｰﾀ作成
            '@***********************
            With ltypLotReWorkSet
                
                '@移載工程ｽｷｯﾌﾟ有無
                If chkMoveSkip.Checked = False Then
                    .strMsgVer = CMstrlot_reworksetVer                      '移載工程あり
                    .strMoveSkip = CPstrZero
                Else
                    .strMsgVer = CMstrlot_reworksetdirectVer                '移載工程なし
                    .strMoveSkip = CPstrOne
                End If
                
                .strLotID = lblLotID.Text                                   'ﾛｯﾄID
                .strComments = txtWorkMemo.Text                             '作業ﾒﾓ
                .strLotLastUpdate = mstrLotLastUpdate                       '最終更新日時
                .strCarrierId = mtypLotCurState.strCarrierId                'ｷｬﾘｱID
                .strOpID = mtypLotCurState.strOpID                          '大工程
                .strStepID = mtypLotCurState.strStepID                      '小工程
                .strWpID = mtypLotCurState.strWpID                          '装置
                .strWpName = mtypLotCurState.strWpName                      '装置名
                .strWFQuantity = mtypLotCurState.strWfNum                   'WF枚数
                .strChipQuantity = mtypLotCurState.strChipQuantity          'ﾁｯﾌﾟ数
                .strCfFlag = mtypLotCurState.strCfFlag                      'CFﾌﾗｸﾞ
                .strLpFlag = mtypLotCurState.strLpFlag                      'LPﾌﾗｸﾞ
                .strPdId = mtypLotCurState.strPdId                          '機種
                .strReworkReason = vbNullString                             'ﾘﾜｰｸ原因
                .strFlowClass = lblFlowClass.Text                           '種別
                .strToCarrierId = txtToCarrier.Text                         '移載先ｷｬﾘｱID
                
                '@分割有無
                If optDivFlag0.Checked = True Then
                    .strDivFlag = CPstrZero                                 '分割無
                ElseIf optDivFlag1.Checked = True Then
                    .strDivFlag = CPstrOne                                  '分割有
                End If
                
                '@処理区分
                If optSPFlow0.Checked = True Then                           'ﾘﾜｰｸ
                    .strClassDivision = CPstrCD1J
                End If
                If optSPFlow1.Checked = True Then                           '追加流動
                    .strClassDivision = CPstrCD1V
                End If

                '@-----------------------
                '@ WFﾘｽﾄ作成
                '@-----------------------
                For llngCnt = 1 To vsfSlotMap.Rows.Count - 1
                    
                    '@WFIDを格納
                    lstrWFID = vsfSlotMap.GetData(llngCnt, CMlngvsfSlotMapColWFID)
                    
                    '@WFIDがNULL以外、かつﾁｪｯｸが付いているか
                    If lstrWFID <> vbNullString And _
                        vsfSlotMap.GetCellCheck(llngCnt, CMlngvsfSlotMapColCheck) = CheckEnum.Checked Then
                        
                        '@特殊流動WF枚数ｶｳﾝﾄｱｯﾌﾟ
                        llngWFcnt = llngWFcnt + 1
                        
                        '@領域確保
                        If llngWFcnt = 1 Then
                            If IsNothing(.typReWrkWFMapList) Then
                                .typReWrkWFMapList = New List(Of ReWrkWFMapList)
                            Else
                                .typReWrkWFMapList.Clear()
                            End If
                        End If

                        Dim typReWrkWFMapListTmp As ReWrkWFMapList = New ReWrkWFMapList
                        
                        '@WFIDｾｯﾄ
                        typReWrkWFMapListTmp.strWfId = lstrWFID
                        
                        .typReWrkWFMapList.Add(typReWrkWFMapListTmp)

                    End If
                Next llngCnt
                
                .lngWfMapListCnt = llngWFcnt                                '特殊流動WF枚数
                .strRouteID = cmbRouteId.Value                              'ﾙｰﾄID
            
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvLotReworkDataSet_Proc"   '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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


    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Frame2.Paint, Frame3.Paint, fraSelectWF.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfNextStepInfo.BeforeDoubleClick, vsfSlotMap.BeforeDoubleClick

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
            gridObj.AutoSizeCol(colindex, 6)

        End If

    End Sub


    '関数名：flexGrid_KeyDownEdit
    '機　能：←→キーの取り扱い
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/01/28 (Mon) 10:00:00 NSYS
    '更新日：2019/04/05 (Fri) 12:00:00 NSYS
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfNextStepInfo.KeyDownEdit, vsfSlotMap.KeyDownEdit

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
    Private Sub flex_SetupEditor(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfNextStepInfo.SetupEditor, vsfSlotMap.SetupEditor

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

	'関数名：prvDoubleJPd_Chk
    '機　能：蒸着2回対象機種ﾁｪｯｸ
    '引　数：
    '戻り値：なし
    '作成日：
    '更新日：
    '備　考：
    '　　　：
    Private Sub prvDoubleJPd_Chk()
        
        Dim llngCnt         As Integer  'ｶｳﾝﾀ
        Dim lblnAns			As Boolean  '結果
        Dim lstrResult		As String   '1:蒸着2回対象機種,0:対象外
        Try
            
            '@ﾌﾗｸﾞの初期化
            lblnAns = False

			'組立工程以外は対象外
			If pstrSBID <> CPstrSBID2A0 Then
				Exit Sub
			End If

			'AFOUP以外は対象外
			If txtCarrier.Text.Substring(0,1) <> "A" Then
				Exit Sub
			End If

			'kkw 蒸着2回対応対象機種か確認
			lblnAns = pubblnDoubleJPd_Chk(CMstrlot_chkdoublejpdVer, _
						lblLotID.Text, _
						lblPdID.Text, _
						lstrResult)

			'蒸着2回対応機種以外は対象外
			If lblnAns = False Or lstrResult <> CPstrFlagOn Then
				Exit Sub
			End If

			'@全数選択のみ可
            Call cmdAllSelect_Click(cmdAllSelect, New EventArgs())
			vsfSlotMap.Enabled = False

			'全数選択ボタン無効
			cmdAllSelect.Enabled = False

                
            '@全数選択ﾌﾗｸﾞが"True：全数"か
            mblnAllSelectFlag = True 
                    
			'@移載工程ｽｷｯﾌﾟﾁｪｯｸﾎﾞｯｸｽの状態変更
			chkMoveSkip.Checked = False                     'ﾁｪｯｸOFF
			chkMoveSkip.Enabled = False                     '無効
                    
            '@空きｷｬﾘｱ選択ﾎﾞﾀﾝを無効にする
            cmdCarrierSelect.Enabled = False
                    
            '@ｱﾝﾛｰﾀﾞｷｬﾘｱの設定
            With txtToCarrier
                        
                .Text = vbNullString                        'NULL
                .Enabled = False                            '無効
                .GotBackColor = SystemColors.ControlLight   'ﾌｫｰｶｽ取得時の背景色：ｸﾞﾚｰ
                .BackColor = SystemColors.ControlLight      '背景色：ｸﾞﾚｰ
            End With
      
            '@分割無固定
			'追加流動は分割無効
            optDivFlag0.Checked = False
            optDivFlag1.Checked = False
			optDivFlag0.Enabled = False
			optDivFlag1.Enabled = False
			
			'@=======================
            '@ 確定ﾎﾞﾀﾝ制御ﾁｪｯｸ
            '@=======================
            Call prvcmdRegist_Chk()
            

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvDoubleJPd_Chk"           '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub

End Class
