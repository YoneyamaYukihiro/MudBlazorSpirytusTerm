'ﾌｧｲﾙ名：xxCM00Z0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：装置メンテナンス記録票　メインフォーム
'作成日：2007/01/29 (Mon) 15:39:03 N.Kojima
'更新日：2008/06/10 (Tue) 13:59:12 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Imports System.Text.RegularExpressions
Public Class frmxxCM00Z0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00Z0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00Z0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00Z0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00Z0)
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
    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyCM00Z0          'ﾛｰｶﾙ機能ID

    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ定数宣言
    Private Const CMstrrep_repairinfoVer            As String = "02.01"                 '故障修理記録票情報取得
    Private Const CMstrrep_chgrepairreportVer       As String = "03.00"                 '故障修理記録票登録/更新
    Private Const CMstrpre_preserveinfoVer          As String = "01.00"                 '保全記録票情報取得
    Private Const CMstrpre_chgpreservereportVer     As String = "01.00"                 '保全記録票登録/更新
    Private Const CMstrrep_registworkflowVer        As String = "01.00"                 '確認依頼登録

    '@担当者(依頼先)一覧
    Private Const CMlngvsfToEmpName                 As Integer = 0                      '確認依頼先名

    '@TabのIndex定数宣言
    Private Const CMlngRepairBaseInfoTabIndex       As Integer = 0                      '故障 基本情報/現象
    Private Const CMlngRepairCauseInfoTabIndex      As Integer = 1                      '故障 原因・対策/費用
    Private Const CMlngPreserveBaseInfoTabIndex     As Integer = 2                      '保全 基本情報
    Private Const CMlngPreserveItemInfoTabIndex     As Integer = 3                      '保全 項目・内容・目的/費用

    '@保全ｶﾃｺﾞﾘ定数宣言
    Private Const CMstrPreserveCategoryYobou        As String = "予防保全"              '保全ｶﾃｺﾞﾘ表示用
    Private Const CMstrPreserveCategoryKaizen       As String = "改良/改善保全"         '保全ｶﾃｺﾞﾘ表示用
    Private Const CMstrPreserveCategoryRMainte      As String = "ルーチンメンテ"        '保全ｶﾃｺﾞﾘ表示用

    '@その他の定数宣言
    Private Const CMlngTimeFormat16                 As Integer = 16                     '時間ﾌｫｰﾏｯﾄ用定数(YYYY/MM/DD HH:MM:16桁)

    '@ｶﾗｰ設定用定数宣言
    Private Const CMlngGlayColor                    As Integer = &H80000004             '灰色

    '@ﾃｷｽﾄ制御用定数宣言
    Private Const CMlngMaxDisp7Row                  As Integer = 7                      'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(ｺﾒﾝﾄ7行入力欄)
    Private Const CMlngMaxDisp5Row                  As Integer = 5                      'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(ｺﾒﾝﾄ5行入力欄)
    Private Const CMlngMaxRepairNameByte            As Integer = 128                    '故障現象名MaxByte

    '@ﾚｽﾎﾟﾝｽ,引継ぎ用ｲﾍﾞﾝﾄ定数
    Private Const CMstrFormName                     As String = "frmxxCM00Z0"           '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                     As String = "Form_Load"             'Form_Load処理
    Private Const CMstrCmdNowListClick              As String = "cmdNowList_Click"      '最新取得ﾎﾞﾀﾝ押下処理
    Private Const CMstrCmdMailClick                 As String = "cmdMail_Click"         '確認依頼ﾎﾞﾀﾝ押下処理
    Private Const CMstrCmdSaveClick                 As String = "cmdSave_Click"         '一時保存ﾎﾞﾀﾝ押下処理
    Private Const CMstrCmdDisposeClick              As String = "cmdDispose_Click"      '処置ﾎﾞﾀﾝ押下処理
    Private Const CMstrCmdApproveClick              As String = "cmdApprove_Click"      '承認ﾎﾞﾀﾝ押下処理
    Private Const CMstrCmbMcGroupValidate           As String = "cmbMcGroup_Validate"   '装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞValidate処理
    Private Const CMstrCmbWpValidate                As String = "cmbWp_Validate"        '装置名ｺﾝﾎﾞValidate処理
    Private Const CMstrPrvcmbWpDisp                 As String = "prvcmbWp_Disp"         '装置情報取得＆ｺﾝﾎﾞ設定処理

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '@各種判定用ﾓｼﾞｭｰﾙ変数
    Private mblnFormLoadFlag                        As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True:ｱｸﾃｨﾍﾞｲﾄ処理済み、False:ｱｸﾃｨﾍﾞｲﾄ未処理)
    Private mblnEditFlag                            As Boolean                          '編集ﾌﾗｸﾞ(True:編集あり、False:編集なし)
    Private mblnRepairNameEditFlag                  As Boolean                          '故障現象編集ﾌﾗｸﾞ(True:編集あり、False:編集なし)
    Private mblnRepairAnalysisEditFlag              As Boolean                          '調査/分析編集ﾌﾗｸﾞ(True:編集あり、False:編集なし)
    Private mblnRepairCauseEditFlag                 As Boolean                          '原因編集ﾌﾗｸﾞ(True:編集あり、False:編集なし)
    Private mblnRepairMeasureEditFlag               As Boolean                          '対策編集ﾌﾗｸﾞ(True:編集あり、False:編集なし)
    Private mstrOldRepairEndDate                    As String                           '変更前修理完了日時(年月日)
    Private mstrOldRepairEndTime                    As String                           '変更前修理完了日時(時刻)

    Private mblnOptionEditFlag                      As Boolean                          'ｵﾌﾟｼｮﾝﾎﾞﾀﾝ処理制御ﾌﾗｸﾞ(True:ｼｽﾃﾑでの変更、False:初期値)
    Private mblnEventSkipFlag                       As Boolean                          'ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞ(True:初期値/False:ｽｷｯﾌﾟ)
    Private mstrOldCopeDivision                     As String                           '変更前対応区分
    Private mstrOldWorkCost                         As String                           '変更前作業費用
    Private mstrOldPartCost                         As String                           '変更前部品費用

    Private mblnPreserveItemEditFlag                As Boolean                          '実施項目編集ﾌﾗｸﾞ(True:編集あり、False:編集なし)
    Private mblnPreserveContentsEditFlag            As Boolean                          '実施内容編集ﾌﾗｸﾞ(True:編集あり、False:編集なし)
    Private mblnPreservePurposeEditFlag             As Boolean                          '実施目的/理由編集ﾌﾗｸﾞ(True:編集あり、False:編集なし)
    Private mstrOldPreserveEndDate                  As String                           '変更前保全終了日時(年月日)
    Private mstrOldPreserveEndTime                  As String                           '変更前保全終了日時(時刻)

    '@通信情報格納用ﾓｼﾞｭｰﾙ変数/構造体
    Private mtypRepairInfoReq                       As RepairInfoReq                    '故障修理記録情報取得要求構造体
    Private mtypRepairInfoAns                       As RepairInfoAns                    '故障修理記録情報取得応答構造体
    Private mtypChgRepairInfoReq                    As RepairInfo                       '故障修理記録情報登録/更新要求構造体
    Private mtypPreserveInfoReq                     As PreserveInfoReq                  '保全記録情報取得要求構造体
    Private mtypPreserveInfoAns                     As PreserveInfoAns                  '保全記録情報取得応答構造体
    Private mtypChgPreserveInfoReq                  As PreserveInfo                     '保全記録情報登録/更新要求構造体

    Private buttonProcessing                        As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                          'NSYS WindowCloseフラグ
    Private mblnTabSelectEnabled                    As Boolean                          'NSYS TabControlの変更許可

    'NSYS 同名項目の配列定義
    Private cmdUpArray()           As Button                
    Private cmdCancelArray()       As Button                
    Private cmdDownArray()         As Button                
    Private cmdSignArray()         As Button                
    Private cmdNowDateArray()      As Button                
    Private optCopeDivisionArray() As RadioButton           
    Private txtWorkCostArray()     As SETextBoxEx.TextBoxEx 
    Private txtPartCostArray()     As SETextBoxEx.TextBoxEx 
    Private lblSignNameArray()     As Label                 
    Private lblSignDateArray()     As Label                 
    Private lblUpdateArray()       As Label                 
    Private lblUpdateNameArray()   As Label                 
    Private lblFromDateArray()     As Label                 
    Private lblFromEmpNameArray()  As Label
    Private lblLengthCountArray()  As Label
    Private vsfToEmpNameArray() As C1FlexGrid               

    'NSYS 白色定義
    Private ReadOnly vbWhite As Color = Color.white               

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

        'NSYS 配列に項目を格納
        cmdUpArray            = {cmdUp0,cmdUp1,cmdUp2,cmdUp3,cmdUp4,cmdUp5,cmdUp6,cmdUp7}
        cmdCancelArray        = {cmdCancel0,cmdCancel1,cmdCancel2,cmdCancel3,cmdCancel4,cmdCancel5,cmdCancel6,cmdCancel7,cmdCancel8,cmdCancel9}
        cmdDownArray          = {cmdDown0,cmdDown1,cmdDown2,cmdDown3,cmdDown4,cmdDown5,cmdDown6,cmdDown7}
        cmdSignArray          = {cmdSign0,cmdSign1,cmdSign2,cmdSign3,cmdSign4,cmdSign5,cmdSign6,cmdSign7,cmdSign8,cmdSign9}
        cmdNowDateArray       = {cmdNowDate0,cmdNowDate1}
        optCopeDivisionArray  = {optCopeDivision0,optCopeDivision1,optCopeDivision2,optCopeDivision3}
        txtWorkCostArray      = {txtWorkCost0,txtWorkCost1}
        txtPartCostArray      = {txtPartCost0,txtPartCost1}
        lblSignNameArray      = {lblSignName0,lblSignName1,lblSignName2,lblSignName3,lblSignName4,lblSignName5,lblSignName6,lblSignName7,lblSignName8,lblSignName9}
        lblSignDateArray      = {lblSignDate0,lblSignDate1,lblSignDate2,lblSignDate3,lblSignDate4,lblSignDate5,lblSignDate6,lblSignDate7,lblSignDate8,lblSignDate9}
        lblUpdateArray        = {lblUpdate0,lblUpdate1}
        lblUpdateNameArray    = {lblUpdateName0,lblUpdateName1}
        lblFromDateArray      = {lblFromDate0,lblFromDate1}
        lblFromEmpNameArray   = {lblFromEmpName0,lblFromEmpName1}
        lblLengthCountArray   = {lblLengthCount1,lblLengthCount2,lblLengthCount3,lblLengthCount4,lblLengthCount5,lblLengthCount6,lblLengthCount7,lblLengthCount8,lblLengthCount9}

        vsfToEmpNameArray     = {vsfToEmpName0,vsfToEmpName1}

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        medPreserveEndTime.Tag = New Hashtable() From {{"OnHighlight", False}, {"MouseDownStart", 0}}
        medRepairEndTime.Tag = New Hashtable() From {{"OnHighlight", False}, {"MouseDownStart", 0}}
        mblnTabSelectEnabled = True
        Form_Load()

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                                *イベントハンドラの記述*
    '****************************************************************************************
    '========================================Private=========================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑ　ﾛｰﾄﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/29 (Mon) 15:44:33 N.Kojima
    '更新日：2008/02/08 (Fri) 13:16:48 N.Kojima
    '備　考：
    '　　　：2007/03/23 (Fri) 10:27:58 N.Kojima     装置停止・ﾒﾝﾃ計画からの連携機能追加に伴い、処理追加。(案件№01830)
    '　　　：2008/02/08 (Fri) 13:16:48 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub Form_Load()

        Dim lblnAns As Boolean              '結果判定

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@ﾌｫｰﾑﾛｰﾄﾞ中のｲﾍﾞﾝﾄを制御する為、ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞを"False:ｽｷｯﾌﾟする"に設定
            mblnEventSkipFlag = False

            '@=======================
            '@　ﾒｲﾝﾌｫｰﾑの初期化処理
            '@=======================
            Call prvFrmxxCM00Z0_Init()

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)

            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            '@★ 起動区分により処理分岐 ★
            Select Case plngLoadClass

                '@〓 "1:故障修理記録" 〓
                Case CPlngNumOne

                    '@****************
                    '@　要求ﾃﾞｰﾀ作成
                    '@****************
                    With mtypRepairInfoReq
                        .strSbID = ptypRepairInfo.strSbID                   'ｼｽﾃﾑﾌﾞﾛｯｸID
                        .strMsgVer = CMstrrep_repairinfoVer                 'MsgVer
                        .strRepairNo = ptypRepairInfo.strRepairNo           '故障修理記録№
                        .strWpID = ptypRepairInfo.strWpID                   '装置ID
                        .strWpName = ptypRepairInfo.strWpName               '装置名(ErrMsg用)
                        .strEntryTime = ptypRepairInfo.strEntryTime         '登録日時(装置停止・ﾒﾝﾃ計画の起動の場合、"開始(予定)日時")
                    End With

                    '@【故障修理記録票情報取得】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnRepRepairInfo_Sel(mtypRepairInfoReq, mtypRepairInfoAns)


                '@〓 "2:保全記録" 〓
                Case CPlngNumTwo

                    '@****************
                    '@　要求ﾃﾞｰﾀ作成
                    '@****************
                    With mtypPreserveInfoReq
                        .strSbID = ptypPreserveInfo.strSbID                 'ｼｽﾃﾑﾌﾞﾛｯｸID
                        .strMsgVer = CMstrpre_preserveinfoVer               'MsgVer
                        .strPreserveNo = ptypPreserveInfo.strPreserveNo     '保全記録票№
                        .strWpID = ptypPreserveInfo.strWpID                 '装置ID
                        .strWpName = ptypPreserveInfo.strWpName             '装置名(ErrMsg用)
                        .strCategoryID = ptypPreserveInfo.strCategoryID     'ｶﾃｺﾞﾘID
                        .strCategoryName = ptypPreserveInfo.strCategoryName 'ｶﾃｺﾞﾘ名(ErrMsg用)
                        .strEntryTime = ptypPreserveInfo.strEntryTime       '登録日時(装置停止・ﾒﾝﾃ計画の起動の場合、"開始(予定)日時")
                    End With

                    '@【保全記録票情報取得】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnPrePreserveInfo_Sel(mtypPreserveInfoReq, mtypPreserveInfoAns)

            End Select

            '@通信結果判定
            If lblnAns = False Then
                '@結果：異常の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)

            '@ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞを初期化
            mblnEventSkipFlag = True

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False

            '@自動起票時のForm_Loadﾌﾗｸﾞに成功をｾｯﾄ
            '@　※EN00C0,EN0110からの自動起動時のﾌﾗｸﾞ
            pblnFormLoad = True

            Exit Sub

        Catch ex As Exception

            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：ﾌｫｰﾑ　ｱｸﾃｨﾌﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/02/01 (Thu) 17:17:51 N.Kojima
    '更新日：2008/02/08 (Fri) 13:16:48 N.Kojima
    '備　考：★★ Form_Activate処理は起動時に1度だけ処理されます
    '　　　：2008/02/08 (Fri) 13:16:48 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"False:ｱｸﾃｨﾍﾞｲﾄ未処理"か
            '@　※ﾒｯｾｰｼﾞBOX等の他ﾌｫｰﾑからﾌｫｰｶｽが戻った際に
            '@　　再度、Form_Activateが走るのを避ける為。
            If mblnFormLoadFlag = False Then

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞを"True:ｱｸﾃｨﾍﾞｲﾄ処理済み"に変更
                mblnFormLoadFlag = True

                '@ﾌｫｰﾑﾛｰﾄﾞ中のｲﾍﾞﾝﾄを制御する為、ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞを"False:ｽｷｯﾌﾟする"に設定
                mblnEventSkipFlag = False

                '@★ 起動区分により処理分岐 ★
                Select Case plngLoadClass

                    '@〓 "1:故障修理記録" 〓
                    Case CPlngNumOne

                        '@=======================
                        '@　故障修理記録票関連Tab表示処理
                        '@=======================
                        Call prvTabRepairBaseInfo_Disp      '故障　基本情報 / 現象Tab
                        Call prvTabRepairCauseInfo_Disp     '故障　原因・対策 / 費用Tab

                        '@=======================
                        '@　画面ｺﾝﾄﾛｰﾙ制御処理
                        '@=======================
                        Call prvTabRepairObjectControl_Proc()

                    '@〓 "2:保全記録" 〓
                    Case CPlngNumTwo

                        '@=======================
                        '@　保全記録票関連Tab表示処理
                        '@=======================
                        Call prvTabPreserveBaseInfo_Disp    '保全　基本情報 / 現象Tab
                        Call prvTabPreserveItemInfo_Disp    '保全　項目・内容・目的 / 費用Tab

                        '@=======================
                        '@　画面ｺﾝﾄﾛｰﾙ制御処理
                        '@=======================
                        Call prvTabPreserveObjectControl_Proc()

                End Select

                '@ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞを初期化
                mblnEventSkipFlag = True

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：ﾌｫｰﾑ　ｷｰﾀﾞｳﾝ時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ値
    '戻り値：なし
    '作成日：2007/02/01 (Thu) 17:25:43 N.Kojima
    '更新日：2008/02/08 (Fri) 13:58:25 N.Kojima
    '備　考：
    '　　　：2008/02/08 (Fri) 13:58:25 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@以下の条件の場合はｷｰを無効にし、処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                e.Handled = True
                Exit Sub
            End If

            '@★ ｱｸﾃｨﾌﾞなｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name

                '@〓 故障　基本情報 / 現象Tab 〓
                '@　故障現象詳細ﾃｷｽﾄ
                Case txtRepairContents.Name

                    '@改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub


                '@〓 故障　原因・対策 / 費用Tab 〓
                '@　調査/分析詳細、原因詳細、対策詳細ﾃｷｽﾄ　⇒共通
                Case txtAnalysisContents.Name, txtCause.Name, txtMeasure.Name

                    '@改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub


                '@〓 保全　基本情報Tab 〓
                '@　ｺﾒﾝﾄﾃｷｽﾄ
                Case txtPreserveComment.Name

                    '@改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub


                '@〓 保全　項目・内容・目的 / 費用Tab 〓
                '@　実施項目、実施内容、実施目的/理由ﾃｷｽﾄ　⇒共通
                Case txtPreserveItem.Name, txtPreserveContents.Name, txtPreservePurpose.Name

                    '@改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                'NSYS vsfToEmpName0 の場合
                Case vsfToEmpName0.Name
                    Select Case e.KeyCode
                        'NSYS上下ｷｰの場合
                        Case Keys.Up, Keys.Down
                            If vsfToEmpName0.Row < 0 Then
                                vsfToEmpName0.Row = 0
                                e.SuppressKeyPress = True
                            End If

                    End Select
               'NSYS vsfToEmpName1 の場合
               Case vsfToEmpName1.Name
                    Select Case e.KeyCode
                        'NSYS上下ｷｰの場合
                        Case Keys.Up, Keys.Down
                            If vsfToEmpName1.Row < 0 Then
                                vsfToEmpName1.Row = 0
                                e.SuppressKeyPress = True
                            End If
                    End Select

                    '@〓 全Tab共通 〓
                    '@　その他
                Case Else
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                    End Select
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：ﾌｫｰﾑ　ｱﾝﾛｰﾄﾞ時処理
    '引　数：Cancel     ：ｷｬﾝｾﾙ値
    '　　　：UnloadMode ：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 11:27:56 N.Kojima
    '更新日：2008/02/08 (Fri) 14:09:04 N.Kojima
    '備　考：
    '　　　：2007/03/23 (Fri) 13:26:29 N.Kojima     入力項目(ｻｲﾝ欄＆修理完了日時)追加に伴い、処理追加。(案件№01830)
    '　　　：2008/02/08 (Fri) 14:09:04 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        '@下記、全て初期化用
        Dim ltypDepartmentList As DepartmentInfo       '部署/所属格納構造体
        Dim ltypDeptEmpList As DeptEmpInfo          'ﾕｰｻﾞ格納構造体
        Dim ltypSendMailList As SendMailList         '宛先人格納構造体
        Dim ltypMailInfo As MailInfo             'ﾒｰﾙ送信画面引継ぎ構造体
        Dim ltypRepairInfoReq As RepairInfoReq        '故障修理記録票情報取得要求構造体
        Dim ltypRepairInfoAns As RepairInfoAns        '故障修理記録票情報取得応答構造体
        Dim ltypChgRepairInfoReq As RepairInfo           '故障修理記録票登録/更新要求構造体
        Dim ltypPreserveInfoReq As PreserveInfoReq      '保全記録票情報取得要求構造体
        Dim ltypPreserveInfoAns As PreserveInfoAns      '保全記録票情報取得応答構造体
        Dim ltypChgPreserveInfoReq As PreserveInfo         '保全記録票登録/更新要求構造体

        Dim llngAns As Integer  '戻り値判定用

        Try

            '@編集ﾌﾗｸﾞが"True:編集あり"か
            If mblnEditFlag = True Then

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001A)
                '@"編集中です。 内容を破棄してよろしいですか？"
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                '@要求確認
                If llngAns = vbNo Then
                    '@Tabが有効か
                    If tabMainteSheet.Enabled = True Then
                        '@Tabにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(tabMainteSheet)
                    End If
                    e.Cancel = True
                    Exit Sub
                End If
            End If

            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If

            '@ﾓｼﾞｭｰﾙ構造体をｸﾘｱ
            '@ﾒｰﾙ関連一式の構造体をｸﾘｱする。
            ptypDepartmentList = ltypDepartmentList
            ptypDeptEmpList = ltypDeptEmpList
            ptypSendMailList = ltypSendMailList
            ptypMailInfo = ltypMailInfo

            If Not IsNothing(ptypDepartmentList.typDepartmentList) Then
                ptypDepartmentList.typDepartmentList.Clear
                ptypDepartmentList.typDepartmentList = Nothing
            End If

            If Not IsNothing(ptypDeptEmpList.typDeptEmpList) Then
                ptypDeptEmpList.typDeptEmpList.Clear
                ptypDeptEmpList.typDeptEmpList = Nothing
            End If

            If Not IsNothing(ptypSendMailList.typSendMail) Then
                ptypSendMailList.typSendMail.Clear
                ptypSendMailList.typSendMail = Nothing
            End If

            '@ﾓｼﾞｭｰﾙ変数,構造体の初期化
            mtypRepairInfoReq = ltypRepairInfoReq               '故障修理記録票情報要求用
            mtypRepairInfoAns = ltypRepairInfoAns               '故障修理記録票情報応答用
            mtypChgRepairInfoReq = ltypChgRepairInfoReq         '故障修理記録票更新要求用
            mtypPreserveInfoReq = ltypPreserveInfoReq           '保全記録票情報要求用
            mtypPreserveInfoAns = ltypPreserveInfoAns           '保全記録票情報応答用
            mtypChgPreserveInfoReq = ltypChgPreserveInfoReq     '保全記録票更新要求用

            mblnRepairNameEditFlag = False                      '故障現象編集ﾌﾗｸﾞ
            mblnRepairAnalysisEditFlag = False                  '調査/分析編集ﾌﾗｸﾞ
            mblnRepairCauseEditFlag = False                     '原因編集ﾌﾗｸﾞ
            mblnRepairMeasureEditFlag = False                   '対策編集ﾌﾗｸﾞ
            mblnPreserveItemEditFlag = False                    '実施項目編集ﾌﾗｸﾞ
            mblnPreserveContentsEditFlag = False                '実施内容編集ﾌﾗｸﾞ
            mblnPreservePurposeEditFlag = False                 '実施目的/理由編集ﾌﾗｸﾞ
            mstrOldCopeDivision = vbNullString                  '変更前対応区分
            mstrOldWorkCost = vbNullString                      '変更前作業費用
            mstrOldPartCost = vbNullString                      '変更前部品費用

            '@子画面引継に使用した(かもしれない)構造体の初期化
            ptypRepairInfo = ltypChgRepairInfoReq               '故障修理記録用
            ptypPreserveInfo = ltypChgPreserveInfoReq           '保全記録用

            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_QueryUnload"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '★Tab：全Tab共通　########################################################################################

    '関数名：tabMainteSheet_Click
    '機　能：ﾀﾌﾞ　Click時処理
    '引　数：PreviousTab：ｱｸﾃｨﾌﾞTab(Tab1：故障 基本情報/現象、
    '　　　：                       Tab2：故障 原因・対策/費用、
    '　　　：                       Tab3：保全 基本情報、
    '　　　：                       Tab4：保全 項目・内容・目的/費用)
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 13:01:58 N.Kojima
    '更新日：2008/02/08 (Fri) 16:28:14 N.Kojima
    '備　考：★★ 全Tabに共通したｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    '　　　：2008/02/08 (Fri) 16:28:14 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub tabMainteSheet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tabMainteSheet.SelectedIndexChanged

        Try

            'NSYS .NET版ではコーディングしなくても選択タブ以外の項目は非活性になるため不要
            ''@★ 選択ﾀﾌﾞ別に処理分岐 ★
            'Select Case tabMainteSheet.SelectedIndex

            '    '@〓 故障 基本情報 / 現象Tab 〓
            '    Case CMlngRepairBaseInfoTabIndex

            '        '@表示Tab制御
            '        tabMainteSheet.SelectedIndex = CMlngRepairBaseInfoTabIndex    'TabIndex

            '        '@表示しているTab以外の項目以外はﾌｫｰｶｽを移動しないように制御する
            '        fraRepairBaseInfo.Enabled = True                    '故障 基本情報 / 現象Tabﾌﾚｰﾑ
            '        fraRepairCauseInfo.Enabled = False                  '故障 原因・対策 / 費用Tabﾌﾚｰﾑ
            '        fraPreserveBaseInfo.Enabled = False                 '保全 基本情報Tabﾌﾚｰﾑ
            '        fraPreserveItemInfo.Enabled = False                 '保全 項目・内容・目的 / 費用Tabﾌﾚｰﾑ


            '    '@〓 故障 原因・対策 / 費用Tab 〓
            '    Case CMlngRepairCauseInfoTabIndex

            '        '@表示Tab制御
            '        tabMainteSheet.SelectedIndex = CMlngRepairCauseInfoTabIndex   'TabIndex

            '        '@表示しているTab以外の項目以外はﾌｫｰｶｽを移動しないように制御する
            '        fraRepairBaseInfo.Enabled = False                   '故障 基本情報 / 現象Tabﾌﾚｰﾑ
            '        fraRepairCauseInfo.Enabled = True                   '故障 原因・対策 / 費用Tabﾌﾚｰﾑ
            '        fraPreserveBaseInfo.Enabled = False                 '保全 基本情報Tabﾌﾚｰﾑ
            '        fraPreserveItemInfo.Enabled = False                 '保全 項目・内容・目的 / 費用Tabﾌﾚｰﾑ


            '    '@〓 保全 基本情報Tab 〓
            '    Case CMlngPreserveBaseInfoTabIndex

            '        '@表示Tab制御
            '        tabMainteSheet.SelectedIndex = CMlngPreserveBaseInfoTabIndex  'TabIndex

            '        '@表示しているTab以外の項目以外はﾌｫｰｶｽを移動しないように制御する
            '        fraRepairBaseInfo.Enabled = False                   '故障 基本情報 / 現象Tabﾌﾚｰﾑ
            '        fraRepairCauseInfo.Enabled = False                  '故障 原因・対策 / 費用Tabﾌﾚｰﾑ
            '        fraPreserveBaseInfo.Enabled = True                  '保全 基本情報Tabﾌﾚｰﾑ
            '        fraPreserveItemInfo.Enabled = False                 '保全 項目・内容・目的 / 費用Tabﾌﾚｰﾑ


            '    '@〓 保全 項目・内容・目的 / 費用Tab 〓
            '    Case CMlngPreserveItemInfoTabIndex

            '        '@表示Tab制御
            '        tabMainteSheet.SelectedIndex = CMlngPreserveItemInfoTabIndex  'TabIndex

            '        '@表示しているTab以外の項目以外はﾌｫｰｶｽを移動しないように制御する
            '        fraRepairBaseInfo.Enabled = False                   '故障 基本情報 / 現象Tabﾌﾚｰﾑ
            '        fraRepairCauseInfo.Enabled = False                  '故障 原因・対策 / 費用Tabﾌﾚｰﾑ
            '        fraPreserveBaseInfo.Enabled = False                 '保全 基本情報Tabﾌﾚｰﾑ
            '        fraPreserveItemInfo.Enabled = True                  '保全 項目・内容・目的 / 費用Tabﾌﾚｰﾑ

            'End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "tabMainteSheet_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：Index  ：ｺﾝﾄﾛｰﾙ配列ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 12:46:59 N.Kojima
    '更新日：2007/02/02 (Fri) 12:46:59
    '備　考：★★ 全Tabに共通したｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub cmdUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUp0.Click,
                                                                                  cmdUp1.Click,
                                                                                  cmdUp2.Click,
                                                                                  cmdUp3.Click,
                                                                                  cmdUp4.Click,
                                                                                  cmdUp5.Click,
                                                                                  cmdUp6.Click,
                                                                                  cmdUp7.Click

        Dim lctlTxtName As Control      '対象ｺﾝﾄﾛｰﾙ格納用
        Dim llngMaxDispLine As Integer      '対象ｺﾝﾄﾛｰﾙの最大表示行数

        Dim Index As Integer
        Dim reg As New Regex("[^0-9]")
        Dim lstrIndex As String

        Try

            'NSYS 押された▲ボタンの番号部分を取得
            lstrIndex = reg.Replace(sender.Name, "")

            'NSYS 数値が取得できた場合のみ処理を続行する
            If IsNumeric(lstrIndex) = True Then
                Index = CInt(lstrIndex)
            Else
                Exit Sub
            End If

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@★ ｺﾝﾄﾛｰﾙ配列ｲﾝﾃﾞｯｸｽにより処理分岐 ★
            Select Case Index

                '@〓 故障現象詳細ﾃｷｽﾄ 〓
                Case CPlngNumZero

                    lctlTxtName = txtRepairContents     '対象ｺﾝﾄﾛｰﾙ：故障現象詳細ﾃｷｽﾄ
                    llngMaxDispLine = CMlngMaxDisp7Row      '対象ｺﾝﾄﾛｰﾙの最大表示行数：7行

                '@〓 調査/分析詳細ﾃｷｽﾄ 〓
                Case CPlngNumOne

                    lctlTxtName = txtAnalysisContents   '対象ｺﾝﾄﾛｰﾙ：調査/分析詳細ﾃｷｽﾄ
                    llngMaxDispLine = CMlngMaxDisp5Row      '対象ｺﾝﾄﾛｰﾙの最大表示行数：5行

                '@〓 原因詳細ﾃｷｽﾄ 〓
                Case CPlngNumTwo

                    lctlTxtName = txtCause              '対象ｺﾝﾄﾛｰﾙ：原因詳細ﾃｷｽﾄ
                    llngMaxDispLine = CMlngMaxDisp5Row      '対象ｺﾝﾄﾛｰﾙの最大表示行数：5行

                '@〓 対策詳細ﾃｷｽﾄ 〓
                Case CPlngNumThree

                    lctlTxtName = txtMeasure            '対象ｺﾝﾄﾛｰﾙ：対策詳細ﾃｷｽﾄ
                    llngMaxDispLine = CMlngMaxDisp5Row      '対象ｺﾝﾄﾛｰﾙの最大表示行数：5行

                '@〓 ｺﾒﾝﾄﾃｷｽﾄ 〓
                Case CPlngNumFour

                    lctlTxtName = txtPreserveComment    '対象ｺﾝﾄﾛｰﾙ：ｺﾒﾝﾄﾃｷｽﾄ
                    llngMaxDispLine = CMlngMaxDisp7Row      '対象ｺﾝﾄﾛｰﾙの最大表示行数：7行

                '@〓 実施項目ﾃｷｽﾄ 〓
                Case CPlngNumFive

                    lctlTxtName = txtPreserveItem       '対象ｺﾝﾄﾛｰﾙ：実施項目ﾃｷｽﾄ
                    llngMaxDispLine = CMlngMaxDisp5Row      '対象ｺﾝﾄﾛｰﾙの最大表示行数：5行

                '@〓 実施内容ﾃｷｽﾄ 〓
                Case CPlngNumSix

                    lctlTxtName = txtPreserveContents   '対象ｺﾝﾄﾛｰﾙ：実施内容ﾃｷｽﾄ
                    llngMaxDispLine = CMlngMaxDisp5Row      '対象ｺﾝﾄﾛｰﾙの最大表示行数：5行

                '@〓 実施目的/理由ﾃｷｽﾄ 〓
                Case CPlngNumSeven

                    lctlTxtName = txtPreservePurpose    '対象ｺﾝﾄﾛｰﾙ：実施目的/理由ﾃｷｽﾄ
                    llngMaxDispLine = CMlngMaxDisp5Row      '対象ｺﾝﾄﾛｰﾙの最大表示行数：5行

            End Select

            '@=======================
            '@　ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP処理
            '@=======================
            Call pubtxtCmdUp_Proc(lctlTxtName, llngMaxDispLine, cmdUPArray(Index), cmdDownArray(Index))

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown_Click
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：Index  ：ｺﾝﾄﾛｰﾙ配列ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 12:58:19 N.Kojima
    '更新日：2007/02/02 (Fri) 12:58:19
    '備　考：★★ 「故障　基本情報 / 現象」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub cmdDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown0.Click,
                                                                                    cmdDown1.Click,
                                                                                    cmdDown2.Click,
                                                                                    cmdDown3.Click,
                                                                                    cmdDown4.Click,
                                                                                    cmdDown5.Click,
                                                                                    cmdDown6.Click,
                                                                                    cmdDown7.Click

        Dim lctlTxtName As Control      '対象ｺﾝﾄﾛｰﾙ格納用
        Dim llngMaxDispLine As Integer      '対象ｺﾝﾄﾛｰﾙの最大表示行数

        Dim Index As Integer
        Dim reg As New Regex("[^0-9]")
        Dim lstrIndex As String

        Try

            'NSYS 押された▲ボタンの番号部分を取得
            lstrIndex = reg.Replace(sender.Name, "")

            'NSYS 数値が取得できた場合のみ処理を続行する
            If IsNumeric(lstrIndex) = True Then
                Index = CInt(lstrIndex)
            Else
                Exit Sub
            End If

            '@★ ｺﾝﾄﾛｰﾙ配列ｲﾝﾃﾞｯｸｽにより処理分岐 ★
            Select Case Index

                '@〓 故障現象詳細ﾃｷｽﾄ 〓
                Case CPlngNumZero

                    lctlTxtName = txtRepairContents     '対象ｺﾝﾄﾛｰﾙ：故障現象詳細ﾃｷｽﾄ
                    llngMaxDispLine = CMlngMaxDisp7Row      '対象ｺﾝﾄﾛｰﾙの最大表示行数：7行

                '@〓 調査/分析詳細ﾃｷｽﾄ 〓
                Case CPlngNumOne

                    lctlTxtName = txtAnalysisContents   '対象ｺﾝﾄﾛｰﾙ：調査/分析詳細ﾃｷｽﾄ
                    llngMaxDispLine = CMlngMaxDisp5Row      '対象ｺﾝﾄﾛｰﾙの最大表示行数：5行

                '@〓 原因詳細ﾃｷｽﾄ 〓
                Case CPlngNumTwo

                    lctlTxtName = txtCause              '対象ｺﾝﾄﾛｰﾙ：原因詳細ﾃｷｽﾄ
                    llngMaxDispLine = CMlngMaxDisp5Row      '対象ｺﾝﾄﾛｰﾙの最大表示行数：5行

                '@〓 対策詳細ﾃｷｽﾄ 〓
                Case CPlngNumThree

                    lctlTxtName = txtMeasure            '対象ｺﾝﾄﾛｰﾙ：対策詳細ﾃｷｽﾄ
                    llngMaxDispLine = CMlngMaxDisp5Row      '対象ｺﾝﾄﾛｰﾙの最大表示行数：5行

                '@〓 ｺﾒﾝﾄﾃｷｽﾄ 〓
                Case CPlngNumFour

                    lctlTxtName = txtPreserveComment    '対象ｺﾝﾄﾛｰﾙ：ｺﾒﾝﾄﾃｷｽﾄ
                    llngMaxDispLine = CMlngMaxDisp7Row      '対象ｺﾝﾄﾛｰﾙの最大表示行数：7行

                '@〓 実施項目ﾃｷｽﾄ 〓
                Case CPlngNumFive

                    lctlTxtName = txtPreserveItem       '対象ｺﾝﾄﾛｰﾙ：実施項目ﾃｷｽﾄ
                    llngMaxDispLine = CMlngMaxDisp5Row      '対象ｺﾝﾄﾛｰﾙの最大表示行数：5行

                '@〓 実施内容ﾃｷｽﾄ 〓
                Case CPlngNumSix

                    lctlTxtName = txtPreserveContents   '対象ｺﾝﾄﾛｰﾙ：実施内容ﾃｷｽﾄ
                    llngMaxDispLine = CMlngMaxDisp5Row      '対象ｺﾝﾄﾛｰﾙの最大表示行数：5行

                '@〓 実施目的/理由ﾃｷｽﾄ 〓
                Case CPlngNumSeven

                    lctlTxtName = txtPreservePurpose    '対象ｺﾝﾄﾛｰﾙ：実施目的/理由ﾃｷｽﾄ
                    llngMaxDispLine = CMlngMaxDisp5Row      '対象ｺﾝﾄﾛｰﾙの最大表示行数：5行

            End Select

            '@=======================
            '@　ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown処理
            '@=======================
            Call pubtxtCmdDown_Proc(lctlTxtName, llngMaxDispLine, cmdUPArray(Index), cmdDownArray(Index))

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '★Tab：「故障 基本情報/現象」、「保全 基本情報/現象」　共通　#############################################

    '関数名：cmdNowDate_Click
    '機　能：現在日時取得ﾎﾞﾀﾝ　Click＆押下時処理
    '引　数：Index  ：ｺﾝﾄﾛｰﾙ配列ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2007/03/23 (Fri) 19:28:55 N.Kojima
    '更新日：2008/02/12 (Tue) 09:29:42 N.Kojima
    '備　考：★★ 「故障 基本情報/現象」Tab、「保全 基本情報/現象」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    '　　　：
    '　　　：2008/02/12 (Tue) 09:29:42 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub cmdNowDate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowDate0.Click, cmdNowDate1.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の条件の場合は処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If

            '@★ 選択Tabにより処理分岐 ★
            Select Case tabMainteSheet.SelectedIndex

                '@〓 故障 基本情報/現象Tab 〓
                Case CMlngRepairBaseInfoTabIndex

                    '@現在日時を取得し、修理完了日時にｾｯﾄ
                    calRepairEndDate.Value = Format$(Now, CPstrDateTimeYMD)    '修理完了日時(年月日)
                    medRepairEndTime.Text = Format$(Now, CPstrTimeFormatHM)     '修理完了日時(時間)

                    '@変更判定用に変更前修理完了日時(年月日、時間)を退避
                    mstrOldRepairEndDate = calRepairEndDate.Value               '修理完了日時(年月日)
                    mstrOldRepairEndTime = medRepairEndTime.Text                '修理完了日時(時間)

                    '@故障現象名が有効か
                    If txtRepairName.Enabled = True Then
                        '@故障現象名にﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtRepairName)
                    Else
                        '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If

                    '@最新日時のValidationを制御(日付がｴﾗｰとなった場合に即使用できるように制御)
                    cmdNowDate0.CausesValidation = True


                '@〓 保全 基本情報Tab 〓
                Case CMlngPreserveBaseInfoTabIndex

                    '@現在日時を取得し、終了(予定)日時にｾｯﾄ
                    calPreserveEndDate.Value = Format$(Now, CPstrDateTimeYMD)  '終了(予定)日時(年月日)
                    medPreserveEndTime.Text = Format$(Now, CPstrTimeFormatHM)   '終了(予定)日時(時間)

                    '@変更判定用に変更前保全終了(予定)日時(年月日、時間)を退避
                    mstrOldPreserveEndDate = calPreserveEndDate.Value           '終了(予定)日時(年月日)
                    mstrOldPreserveEndTime = medPreserveEndTime.Text            '終了(予定)日時(時間)

                    '@ｺﾒﾝﾄが有効か
                    If txtPreserveComment.Enabled = True Then
                        '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtPreserveComment)
                    Else
                        '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If

                    '@最新日時のValidationを制御(日付がｴﾗｰとなった場合に即使用できるように制御)
                    cmdNowDate1.CausesValidation = True

            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNowDate_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '★Tab：「故障 基本情報/現象」　###########################################################################

    '関数名：calRepairEndDate_CalendarSelect
    '機　能：修理完了日ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/23 (Fri) 11:17:21 N.Kojima
    '更新日：2008/02/08 (Fri) 16:38:43 N.Kojima
    '備　考：★★ 「故障 基本情報/現象」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    '　　　：
    '　　　：2008/02/08 (Fri) 16:38:43 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub calRepairEndDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calRepairEndDate.CalendarSelect

        Try

            With calRepairEndDate

                '@日付が空の場合はﾌｫｰｶｽを留める
                If .Value = CPstrNullDate Then
                    Exit Sub
                End If

                '@=======================
                '@　修理完了日時ｶﾚﾝﾀﾞｰｺﾝﾎﾞのValidate処理
                '@=======================
                RemoveHandler calRepairEndDate.Validating, AddressOf calRepairEndDate_Validate
                Call calRepairEndDate_Validate(calRepairEndDate, New CancelEventArgs(True))
                AddHandler calRepairEndDate.Validating, AddressOf calRepairEndDate_Validate

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calRepairEndDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calRepairEndDate_Change
    '機　能：修理完了日時ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/28 (Wed) 10:18:44 N.Kojima
    '更新日：2008/02/08 (Fri) 16:38:43 N.Kojima
    '備　考：★★ 「故障 基本情報/現象」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    '　　　：
    '　　　：2008/02/08 (Fri) 16:38:43 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub calRepairEndDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calRepairEndDate.Change

        Try

            '@ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞが"False:ｽｷｯﾌﾟする"か
            If mblnEventSkipFlag = False Then
                Exit Sub
            End If

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True:ｱｸﾃｨﾍﾞｲﾄ処理済み"か
            If mblnFormLoadFlag = True Then

                '@修理完了日時(年月日)が変更されているか
                If mstrOldRepairEndDate <> calRepairEndDate.Value Then

                    '@変更があった場合は編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄする
                    mblnEditFlag = True

                    '@変更後の修理完了日時(年月日)を次の判定用に格納
                    mstrOldRepairEndDate = calRepairEndDate.Value
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calRepairEndDate_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calRepairEndDate_Validate
    '機　能：修理完了日時ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　Validate処理
    '引　数：Cancel ：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/03/23 (Fri) 11:16:47 N.Kojima
    '更新日：2008/02/08 (Fri) 16:38:43 N.Kojima
    '備　考：★★ 「故障 基本情報/現象」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    '　　　：
    '　　　：2008/02/08 (Fri) 16:38:43 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub calRepairEndDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calRepairEndDate.Validating

        Dim lstrNowDT As String       '修理完了日時格納用
        Dim lstrEndTime As String       '修理完了日時(時間)格納用

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@以下の条件の場合は処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If

            With calRepairEndDate

                '@修理完了日時が入力されているか
                If .Value = CPstrNullDate Then
                    Exit Sub
                End If

                '@日付の有効性ﾁｪｯｸ
                If pubblnYearRange_Chk(.Value) = False Then
                    '@無効日付の場合

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@"正しい日付を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@ﾌｫｰｶｽを保持
                    If Me.ActiveControl.Name = tabMainteSheet.Name Then
                        mblnTabSelectEnabled = False
                        sender.Focus()
                    Else
                        e.Cancel = True
                    End If
                    Exit Sub
                Else
                    '@有効日付の場合

                    '@現在日付取得
                    lstrNowDT = Format$(Now, CPstrDateTimeYMD)

                    '@未来日付の場合
                    If prvFormatDate(.Value, CPstrDateTimeYMD) > lstrNowDT Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
                        '@"未来日付は指定できません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@ﾌｫｰｶｽを保持
                        If Me.ActiveControl.Name = tabMainteSheet.Name Then
                            mblnTabSelectEnabled = False
                            sender.Focus()
                        Else
                            e.Cancel = True
                        End If
                        Exit Sub
                    End If

                    '@修理完了日時(時刻)が"__:__"か
                    If medRepairEndTime.Text = CPstrNullTime Then
                        '@"23:59"を格納する
                        lstrEndTime = CPstrDayEndTime
                    Else
                        '@入力値を格納する
                        lstrEndTime = medRepairEndTime.Text
                    End If

                    '@故障発生日時より未来が指定されているか
                    If lblRepairStartDate.Text > _
                        calRepairEndDate.Value & Space(1) & lstrEndTime Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002I, lblRepairEndDateTitle.Text)
                        '@"<TRM2IW>$$開始日より過去の日付は指定できません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@ﾌｫｰｶｽを保持
                        If Me.ActiveControl.Name = tabMainteSheet.Name Then
                            mblnTabSelectEnabled = False
                            sender.Focus()
                        Else
                            e.Cancel = True
                        End If
                        Exit Sub
                    End If
                End If

                '@修理完了日時(時間)へｾｯﾄﾌｫｰｶｽ
                If ActiveControl.Name = calRepairEndDate.Name Then
                    Call pubSetFocus(medRepairEndTime)
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calRepairEndDate_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medRepairEndTime_Change
    '機　能：修理完了日時(時刻)ﾏｽｸｴﾃﾞｨｯﾄﾎﾞｯｸｽ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/28 (Wed) 10:24:18 N.Kojima
    '更新日：2008/02/12 (Tue) 08:56:44 N.Kojima
    '備　考：★★ 「故障 基本情報/現象」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    '　　　：
    '　　　：2008/02/12 (Tue) 08:56:44 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub medRepairEndTime_Change(ByVal sender As Object, ByVal e As EventArgs) Handles medRepairEndTime.TextChanged

        Try

            '@ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞが"False:ｽｷｯﾌﾟする"か
            If mblnEventSkipFlag = False Then
                Exit Sub
            End If

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True:ｱｸﾃｨﾍﾞｲﾄ処理済み"か
            If mblnFormLoadFlag = True Then

                '@修理完了時刻が変更されているか
                If mstrOldRepairEndTime <> medRepairEndTime.Text Then

                    '@変更があった場合は編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄする
                    mblnEditFlag = True

                    '@変更後の修理完了日時(時刻)を次の判定用に格納
                    mstrOldRepairEndTime = medRepairEndTime.Text
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medRepairEndTime_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medRepairEndTime_GotFocus
    '機　能：修理完了日時(時刻)ﾏｽｸｴﾃﾞｨｯﾄﾎﾞｯｸｽ　ﾌｫｰｶｽ取得時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/23 (Fri) 11:29:36 N.Kojima
    '更新日：2008/02/12 (Tue) 09:01:56 N.Kojima
    '備　考：★★ 「故障 基本情報/現象」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    '　　　：
    '　　　：2008/02/12 (Tue) 09:01:56 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub medRepairEndTime_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles medRepairEndTime.Enter

        Try

            '@=======================
            '@　ﾊｲﾗｲﾄ処理
            '@=======================
            Call pubHighlight(medRepairEndTime)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medRepairEndTime_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medRepairEndTime_Validate
    '機　能：修理完了日時(時刻)ﾏｽｸｴﾃﾞｨｯﾄﾎﾞｯｸｽ　Validate処理
    '引　数：Cancel ：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2007/03/23 (Fri) 11:29:26 N.Kojima
    '更新日：2008/02/12 (Tue) 09:03:01 N.Kojima
    '備　考：★★ 「故障 基本情報/現象」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    '　　　：
    '　　　：2008/02/12 (Tue) 09:03:01 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub medRepairEndTime_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles medRepairEndTime.Validating

        Dim lstrNowDT As String       '現在日付格納用
        Dim lstrDate As String       '日付格納用

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@以下の条件の場合は処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If

            '@修理完了日時(時刻)の有効性ﾁｪｯｸ
            If IsDate(medRepairEndTime.Text) = False Then

                '@時間入力されていない(空欄)場合
                If medRepairEndTime.Text = CPstrNullTime Then

                    '@現在日時取得ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = medRepairEndTime.Name Then
                        Call pubSetFocus(cmdNowDate0)
                    End If
                    Exit Sub
                End If

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0098)
                '@"<TRM98W>$$故障発生日時の設定が正しくありません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@時間入力欄にｾｯﾄﾌｫｰｶｽ
                If Me.ActiveControl.Name = tabMainteSheet.Name Then
                    mblnTabSelectEnabled = False
                    sender.Focus()
                Else
                    e.Cancel = True
                End If
            Else
                '@修理完了日時(時刻)が有効な場合

                '@日付がNULLの場合は処理抜け
                If calRepairEndDate.Value = CPstrNullDate Then
                    Exit Sub
                End If

                '@現在日付取得
                lstrNowDT = Format$(Now, CPstrDateTimeYMDHM)
                lstrDate = calRepairEndDate.Value & CPstrSpace & medRepairEndTime.Text

                '@未来日付の場合
                If prvFormatDate(lstrDate, CPstrDateTimeYMDHM) > lstrNowDT Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001X)
                    '@"未来日付は指定できません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@ﾌｫｰｶｽを保持
                    If Me.ActiveControl.Name = tabMainteSheet.Name Then
                        mblnTabSelectEnabled = False
                        sender.Focus()
                    Else
                        e.Cancel = True
                    End If
                    Exit Sub
                End If

                '@開始(予定)日時より未来が指定されているか
                If lblRepairStartDate.Text > _
                    calRepairEndDate.Value & Space(1) & medRepairEndTime.Text Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002I, lblRepairEndDateTitle.Text)
                    '@"<TRM2IW>$$開始日より過去の日付は指定できません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@ﾌｫｰｶｽを保持
                    If Me.ActiveControl.Name = tabMainteSheet.Name Then
                        mblnTabSelectEnabled = False
                        sender.Focus()
                    Else
                        e.Cancel = True
                    End If
                    Exit Sub
                End If

                '        '@現在日時取得ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                '        Call pubSetFocus(cmdNowDate(0))
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medRepairEndTime_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRepairNameSelect_Click
    '機　能：現象名選択ﾎﾞﾀﾝ　Click＆押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/03/14 (Wed) 16:16:03 N.Kojima
    '更新日：2007/03/14 (Wed) 16:16:03
    '備　考：★★ 「故障　基本情報 / 現象」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub cmdRepairNameSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRepairNameSelect.Click

        Dim ltypRepairConnectInfo As RepairConnectInfo        '故障修理情報引継ぎ構造体初期化用

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の条件の場合は処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If

            '@引継ぎ構造体の初期化
            ptypRepairConnectInfo = ltypRepairConnectInfo

            '@引継ぎ情報をｾｯﾄ
            ptypRepairConnectInfo.strWpID = mtypRepairInfoReq.strWpID       '装置ID
            ptypRepairConnectInfo.strWpName = mtypRepairInfoAns.strWpName   '装置名

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　保全記録票選択画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00Z1.Instance = New frmxxCM00Z1()

            '@Form_LoadﾌﾗｸﾞがFalse(起動失敗)か
            If pblnFormLoad = False Then

                '@∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇
                frmxxCM00Z1.Instance = Nothing

                '@引継ぎ構造体の初期化
                ptypRepairConnectInfo = ltypRepairConnectInfo
                Exit Sub
            End If

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　故障現象名選択画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00Z1.Instance.ShowDialog(Me)
            frmxxCM00Z1.Instance = Nothing

            '@戻り値の故障現象名がNULLではないか
            If ptypRepairConnectInfo.strRepairName <> vbNullString Then

                '@子画面で選択した情報を格納する
                txtRepairName.Text = ptypRepairConnectInfo.strRepairName            '故障現象名
                txtRepairContents.Text = ptypRepairConnectInfo.strRepairContents    '故障現象詳細
            End If

            '@引継ぎ構造体の初期化
            ptypRepairConnectInfo = ltypRepairConnectInfo

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRepairNameSelect_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtRepairName_Change
    '機　能：故障現象名ﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 16:29:01 N.Kojima
    '更新日：2007/03/23 (Fri) 13:28:59 N.Kojima
    '備　考：★★ 「故障　基本情報 / 現象」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    '　　　：
    '　　　：2007/03/23 (Fri) 13:28:59 N.Kojima     故障現象名に変更があった場合、編集ﾌﾗｸﾞをTrueにする。(案件№01830)
    Private Sub txtRepairName_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtRepairName.Change

        Dim llngNowByte As Integer  'ﾊﾞｲﾄ数

        Try

            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtRepairName.NowByte

            '@=======================
            '@　現在のﾊﾞｲﾄ数表示処理(表示ﾒｯｾｰｼﾞ変換処理)
            '@=======================
            lblLengthCount1.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                            llngNowByte, _
                                                            CMlngMaxRepairNameByte)

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True:ｱｸﾃｨﾍﾞｲﾄ処理済み"、ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞが"False:ｽｷｯﾌﾟする"以外か
            If mblnFormLoadFlag = True And mblnEventSkipFlag = True Then

                '@故障現象名に変更があった場合は編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄ
                mblnEditFlag = True

                '@故障現象編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄ(自動ｻｲﾝ判定用)
                mblnRepairNameEditFlag = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtRepairName_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtRepairContents_Change
    '機　能：故障現象詳細ﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 13:08:39 N.Kojima
    '更新日：2007/03/23 (Fri) 13:30:15 N.Kojima
    '備　考：★★ 「故障　基本情報 / 現象」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    '　　　：
    '　　　：2007/03/23 (Fri) 13:30:15 N.Kojima     故障現象詳細に変更があった場合、編集ﾌﾗｸﾞをTrueにする。(案件№01830)
    Private Sub txtRepairContents_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtRepairContents.Change

        Dim llngNowByte As Integer  'ﾊﾞｲﾄ数

        Try

            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtRepairContents.NowByte

            '@=======================
            '@　現在のﾊﾞｲﾄ数表示処理(表示ﾒｯｾｰｼﾞ変換処理)
            '@=======================
            lblLengthCount2.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                            llngNowByte, _
                                                            CPlngLotCommentsMaxByte)

            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtRepairContents, CMlngMaxDisp7Row, cmdUP0, cmdDown0)

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True:ｱｸﾃｨﾍﾞｲﾄ処理済み"、ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞが"False:ｽｷｯﾌﾟする"以外か
            If mblnFormLoadFlag = True And mblnEventSkipFlag = True Then

                '@変更があった場合は編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄ
                mblnEditFlag = True

                '@故障現象編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄ(自動ｻｲﾝ判定用)
                mblnRepairNameEditFlag = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtRepairContents_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtRepairContents_KeyUp
    '機　能：故障現象詳細ﾃｷｽﾄ　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 13:09:29 N.Kojima
    '更新日：2007/02/02 (Fri) 13:09:29
    '備　考：★★ 「故障　基本情報 / 現象」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtRepairContents_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtRepairContents.KeyUp

        Try

            '@=======================
            '@　ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作処理
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtRepairContents, CMlngMaxDisp7Row, cmdUP0, cmdDown0)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtRepairContents_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtRepairContents_MouseUp
    '機　能：故障現象詳細ﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 13:10:27 N.Kojima
    '更新日：2007/02/02 (Fri) 13:10:27
    '備　考：★★ 「故障　基本情報 / 現象」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtRepairContents_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtRepairContents.MouseUp

        Try

            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtRepairContents, CMlngMaxDisp7Row, cmdUP0, cmdDown0, e.Button)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtRepairContents_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '★Tab：「故障 原因・対策/費用」、「保全 項目・内容・目的/費用」　共通　###################################

    '関数名：optCopeDivision_Click
    '機　能：対応区分ｵﾌﾟｼｮﾝﾎﾞﾀﾝ　Click時処理
    '引　数：Index  ：ｺﾝﾄﾛｰﾙ配列ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2008/02/12 (Tue) 09:50:55 N.Kojima
    '更新日：2008/02/12 (Tue) 09:50:55
    '備　考：★★ 「故障 原因・対策/費用」Tab、「保全 項目・内容・目的/費用」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub optCopeDivision_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optCopeDivision0.CheckedChanged,
                                                                                            optCopeDivision1.CheckedChanged,
                                                                                            optCopeDivision2.CheckedChanged,
                                                                                            optCopeDivision3.CheckedChanged


        Dim lstrIndex As String       'ｲﾝﾃﾞｯｸｽ退避用

        Dim Index As Integer
        Dim reg As New Regex("[^0-9]")

        Try

            'NSYS 押された▲ボタンの番号部分を取得
            lstrIndex = reg.Replace(sender.Name, "")

            'NSYS 数値が取得できた場合のみ処理を続行する
            If IsNumeric(lstrIndex) = True Then
                Index = CInt(lstrIndex)
            Else
                Exit Sub
            End If

            '@以下の条件の場合は処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            '@　③ｵﾌﾟｼｮﾝﾎﾞﾀﾝ処理制御が"True:ｼｽﾃﾑでの変更"の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                mblnOptionEditFlag = True Then

                Exit Sub
            End If

            '@★ ｺﾝﾄﾛｰﾙ配列ｲﾝﾃﾞｯｸｽにより処理分岐 ★
            Select Case Index

                '@〓 「故障 原因・対策/費用」Tab 〓
                Case CPlngNumZero, CPlngNumOne

                    '@作業費用にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtWorkCost0)

                '@〓 「保全 項目・内容・目的/費用」Tab 〓
                Case CPlngNumTwo, CPlngNumThree

                    '@作業費用にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtWorkCost1)

            End Select

            '@ｲﾝﾃﾞｯｸｽを退避
            lstrIndex = CStr(Index)

            '@変更前対応区分と現在の対応区分が異なるか
            If mstrOldCopeDivision <> Index Then

                '@変更があった場合は編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄする
                mblnEditFlag = True

                '@"自主保全"が選択されているか
                If lstrIndex = CPlngNumZero Or lstrIndex = CPlngNumTwo Then
                    '@"1:自主保全"を退避変数にｾｯﾄ
                    mstrOldCopeDivision = CPstrOne
                Else
                    '@"ﾒｰｶｰ保全"が選択されている場合、"2:ﾒｰｶｰ保全"を退避変数にｾｯﾄ
                    mstrOldCopeDivision = CPstrTwo
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optCopeDivision_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkCost_Change
    '機　能：作業費用ﾃｷｽﾄ　変更時処理
    '引　数：Index  ：ｺﾝﾄﾛｰﾙ配列ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2008/02/12 (Tue) 10:12:44 N.Kojima
    '更新日：2008/02/12 (Tue) 10:12:44
    '備　考：★★ 「故障 原因・対策/費用」Tab、「保全 項目・内容・目的/費用」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtWorkCost_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkCost0.Change, txtWorkCost1.Change

        Dim lstrIndex As String       'ｲﾝﾃﾞｯｸｽ退避用
        Dim Index As Integer
        Dim reg As New Regex("[^0-9]")

        Try

            'NSYS 押された▲ボタンの番号部分を取得
            lstrIndex = reg.Replace(sender.Name, "")

            'NSYS 数値が取得できた場合のみ処理を続行する
            If IsNumeric(lstrIndex) = True Then
                Index = CInt(lstrIndex)
            Else
                Exit Sub
            End If
            
            '@以下の条件の場合は処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True:ｱｸﾃｨﾍﾞｲﾄ処理済み"、ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞが"True:初期値"、
            '@かつ、変更前作業費用と現在の作業費用が異なるか
            If mblnFormLoadFlag = True And _
                mblnEventSkipFlag = True And _
                mstrOldWorkCost <> txtWorkCostArray(Index).Text Then

                '@変更があった場合は編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄする
                mblnEditFlag = True

                '@変更前作業費用にｾｯﾄする
                mstrOldWorkCost = txtWorkCostArray(Index).Text
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkCost_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkCost_Validate
    '機　能：作業費用ﾃｷｽﾄ　Validate処理
    '引　数：Cancel ：ｷｬﾝｾﾙ値
    '　　　：Index  ：ｺﾝﾄﾛｰﾙ配列ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2008/02/12 (Tue) 10:12:44 N.Kojima
    '更新日：2008/02/12 (Tue) 10:12:44
    '備　考：★★ 「故障 原因・対策/費用」Tab、「保全 項目・内容・目的/費用」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtWorkCost_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtWorkCost0.Validating, txtWorkCost1.Validating

        Dim lstrIndex As String       'ｲﾝﾃﾞｯｸｽ退避用

        Dim Index As Integer
        Dim reg As New Regex("[^0-9]")

        Try

            'NSYS 押された▲ボタンの番号部分を取得
            lstrIndex = reg.Replace(sender.Name, "")

            'NSYS 数値が取得できた場合のみ処理を続行する
            If IsNumeric(lstrIndex) = True Then
                Index = CInt(lstrIndex)
            Else
                Exit Sub
            End If

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@以下の条件の場合は処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If

            '@入力された値が数字以外か
            If IsNumeric(txtWorkCostArray(Index).Text) = False Then

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001F)
                '@"<TRM1FW>$$数字を入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@作業費用にﾌｫｰｶｽを留める
                e.Cancel = True
                Exit Sub
            End If

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True:ｱｸﾃｨﾍﾞｲﾄ処理済み"、ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞが"True:初期値"、
            '@かつ、変更前作業費用と現在の作業費用が異なるか
            If mblnFormLoadFlag = True And _
                mblnEventSkipFlag = True And _
                mstrOldWorkCost <> txtWorkCostArray(Index).Text Then

                '@変更があった場合は編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄする
                mblnEditFlag = True

                '@変更前作業費用にｾｯﾄする
                mstrOldWorkCost = txtWorkCostArray(Index).Text
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkCost_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtPartCost_Change
    '機　能：部品費用ﾃｷｽﾄ　変更時処理
    '引　数：Index  ：ｺﾝﾄﾛｰﾙ配列ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2008/02/12 (Tue) 10:12:44 N.Kojima
    '更新日：2008/02/12 (Tue) 10:12:44
    '備　考：★★ 「故障 原因・対策/費用」Tab、「保全 項目・内容・目的/費用」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtPartCost_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtPartCost0.Change, txtPartCost1.Change

        Dim lstrIndex As String       'ｲﾝﾃﾞｯｸｽ退避用

        Dim Index As Integer
        Dim reg As New Regex("[^0-9]")

        Try

            'NSYS 押された▲ボタンの番号部分を取得
            lstrIndex = reg.Replace(sender.Name, "")

            'NSYS 数値が取得できた場合のみ処理を続行する
            If IsNumeric(lstrIndex) = True Then
                Index = CInt(lstrIndex)
            Else
                Exit Sub
            End If
            
            '@以下の条件の場合は処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True:ｱｸﾃｨﾍﾞｲﾄ処理済み"、ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞが"True:初期値"、
            '@かつ、変更前部品費用と現在の部品費用が異なるか
            If mblnFormLoadFlag = True And _
                mblnEventSkipFlag = True And _
                mstrOldPartCost <> txtPartCostArray(Index).Text Then

                '@変更があった場合は編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄする
                mblnEditFlag = True

                '@変更前部品費用にｾｯﾄする
                mstrOldPartCost = txtPartCostArray(Index).Text
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPartCost_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtPartCost_Validate
    '機　能：部品費用ﾃｷｽﾄ　Validate処理
    '引　数：Cancel ：ｷｬﾝｾﾙ値
    '　　　：Index  ：ｺﾝﾄﾛｰﾙ配列ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2008/02/12 (Tue) 10:12:44 N.Kojima
    '更新日：2008/02/12 (Tue) 10:12:44
    '備　考：★★ 「故障 原因・対策/費用」Tab、「保全 項目・内容・目的/費用」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtPartCost_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtPartCost0.Validating, txtPartCost1.Validating

        Dim llngSingButtonIndex As Integer  'ｻｲﾝﾎﾞﾀﾝｲﾝﾃﾞｯｸｽ格納用

        Dim lstrIndex As String       'ｲﾝﾃﾞｯｸｽ退避用

        Dim Index As Integer
        Dim reg As New Regex("[^0-9]")

        Try

            'NSYS 押された▲ボタンの番号部分を取得
            lstrIndex = reg.Replace(sender.Name, "")

            'NSYS 数値が取得できた場合のみ処理を続行する
            If IsNumeric(lstrIndex) = True Then
                Index = CInt(lstrIndex)
            Else
                Exit Sub
            End If

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@以下の条件の場合は処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If

            '@入力された値が数字以外か
            If IsNumeric(txtPartCostArray(Index).Text) = False Then

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001F)
                '@"<TRM1FW>$$数字を入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@部品費用にﾌｫｰｶｽを留める
                e.Cancel = True
                Exit Sub
            Else
                '@数字の場合

                '@★ ｺﾝﾄﾛｰﾙ配列ｲﾝﾃﾞｯｸｽにより処理分岐 ★
                Select Case Index

                    '@〓 「故障 原因・対策/費用」Tab 〓
                    Case CPlngNumZero

                        '@「故障 原因・対策/費用」Tabの保全担当ｻｲﾝﾎﾞﾀﾝのｲﾝﾃﾞｯｸｽを格納
                        llngSingButtonIndex = CPlngNumFour

                    '@〓 「保全 項目・内容・目的/費用」Tab 〓
                    Case CPlngNumOne

                        '@「保全 項目・内容・目的/費用」Tabの保全担当ｻｲﾝﾎﾞﾀﾝのｲﾝﾃﾞｯｸｽを格納
                        llngSingButtonIndex = CPlngNumSeven

                End Select
            End If

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True:ｱｸﾃｨﾍﾞｲﾄ処理済み"、ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞが"True:初期値"、
            '@かつ、変更前部品費用と現在の部品費用が異なるか
            If mblnFormLoadFlag = True And _
                mblnEventSkipFlag = True And _
                mstrOldPartCost <> txtPartCostArray(Index).Text Then

                '@変更があった場合は編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄする
                mblnEditFlag = True

                '@変更前部品費用にｾｯﾄする
                mstrOldPartCost = txtPartCostArray(Index).Text
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPartCost_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '★Tab：「故障 原因・対策/費用」　#########################################################################

    '関数名：txtAnalysisContents_Change
    '機　能：調査/分析詳細ﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 13:08:39 N.Kojima
    '更新日：2007/03/23 (Fri) 13:31:51 N.Kojima
    '備　考：★★ 「故障　原因・対策 / 費用」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    '　　　：2007/03/23 (Fri) 13:31:51 N.Kojima     調査/分析に変更があった場合、編集ﾌﾗｸﾞをTrueにする。(案件№01830)
    Private Sub txtAnalysisContents_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtAnalysisContents.Change

        Dim llngNowByte As Integer  'ﾊﾞｲﾄ数

        Try
            
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtAnalysisContents.NowByte

            '@=======================
            '@　現在のﾊﾞｲﾄ数表示処理(表示ﾒｯｾｰｼﾞ変換処理)
            '@=======================
            lblLengthCount3.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                            llngNowByte, _
                                                            CPlngLotCommentsMaxByte)

            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtAnalysisContents, CMlngMaxDisp5Row, cmdUP1, cmdDown1)

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True:ｱｸﾃｨﾍﾞｲﾄ処理済み"、ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞが"False:ｽｷｯﾌﾟする"以外か
            If mblnFormLoadFlag = True And mblnEventSkipFlag = True Then

                '@変更があった場合は編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄする
                mblnEditFlag = True

                '@調査/分析編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄする(自動ｻｲﾝ判定用)
                mblnRepairAnalysisEditFlag = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtAnalysisContents_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtAnalysisContents_KeyUp
    '機　能：調査/分析詳細ﾃｷｽﾄ　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 13:09:29 N.Kojima
    '更新日：2007/02/02 (Fri) 13:09:29
    '備　考：★★ 「故障　原因・対策 / 費用」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtAnalysisContents_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtAnalysisContents.KeyUp

        Try
            
            '@=======================
            '@　ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作処理
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtAnalysisContents, CMlngMaxDisp5Row, cmdUP1, cmdDown1)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtAnalysisContents_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtAnalysisContents_MouseUp
    '機　能：調査/分析詳細ﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 13:10:27 N.Kojima
    '更新日：2007/02/02 (Fri) 13:10:27
    '備　考：★★ 「故障　原因・対策 / 費用」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtAnalysisContents_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtAnalysisContents.MouseUp

        Try
            
            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtAnalysisContents, CMlngMaxDisp5Row, cmdUP1, cmdDown1, e.Button)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtAnalysisContents_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCause_Change
    '機　能：原因詳細ﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 13:08:39 N.Kojima
    '更新日：2007/03/23 (Fri) 13:32:54 N.Kojima
    '備　考：★★ 「故障　原因・対策 / 費用」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    '　　　：2007/03/23 (Fri) 13:32:54 N.Kojima     原因に変更があった場合、編集ﾌﾗｸﾞをTrueにする。(案件№01830)
    Private Sub txtCause_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCause.Change

        Dim llngNowByte As Integer  'ﾊﾞｲﾄ数

        Try
            
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtCause.NowByte

            '@=======================
            '@　現在のﾊﾞｲﾄ数表示処理(表示ﾒｯｾｰｼﾞ変換処理)
            '@=======================
            lblLengthCount4.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                            llngNowByte, _
                                                            CPlngLotCommentsMaxByte)

            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtCause, CMlngMaxDisp5Row, cmdUP2, cmdDown2)

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True:ｱｸﾃｨﾍﾞｲﾄ処理済み"、ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞが"False:ｽｷｯﾌﾟする"以外か
            If mblnFormLoadFlag = True And mblnEventSkipFlag = True Then

                '@変更があった場合は編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄする
                mblnEditFlag = True

                '@原因編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄする(自動ｻｲﾝ判定用)
                mblnRepairCauseEditFlag = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCause_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCause_KeyUp
    '機　能：原因詳細ﾃｷｽﾄ　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 13:09:29 N.Kojima
    '更新日：2007/02/02 (Fri) 13:09:29
    '備　考：★★ 「故障　原因・対策 / 費用」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtCause_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtCause.KeyUp

        Try
            
            '@=======================
            '@　ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作処理
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtCause, CMlngMaxDisp5Row, cmdUP2, cmdDown2)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCause_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCause_MouseUp
    '機　能：原因詳細ﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 13:10:27 N.Kojima
    '更新日：2007/02/02 (Fri) 13:10:27
    '備　考：★★ 「故障　原因・対策 / 費用」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtCause_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtCause.MouseUp

        Try
            
            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtCause, CMlngMaxDisp5Row, cmdUP2, cmdDown2, e.Button)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCause_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtMeasure_Change
    '機　能：対策詳細ﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 13:08:39 N.Kojima
    '更新日：2007/03/23 (Fri) 13:33:59 N.Kojima
    '備　考：★★ 「故障　原因・対策 / 費用」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    '　　　：2007/03/23 (Fri) 13:33:59 N.Kojima     対策に変更があった場合、編集ﾌﾗｸﾞをTrueにする。(案件№01830)
    Private Sub txtMeasure_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtMeasure.Change

        Dim llngNowByte As Integer  'ﾊﾞｲﾄ数

        Try
            
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtMeasure.NowByte

            '@=======================
            '@　現在のﾊﾞｲﾄ数表示処理(表示ﾒｯｾｰｼﾞ変換処理)
            '@=======================
            lblLengthCount5.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                            llngNowByte, _
                                                            CPlngLotCommentsMaxByte)

            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtMeasure, CMlngMaxDisp5Row, cmdUP3, cmdDown3)

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True:ｱｸﾃｨﾍﾞｲﾄ処理済み"、ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞが"False:ｽｷｯﾌﾟする"以外か
            If mblnFormLoadFlag = True And mblnEventSkipFlag = True Then

                '@変更があった場合は編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄする
                mblnEditFlag = True

                '@対策編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄする(自動ｻｲﾝ判定用)
                mblnRepairMeasureEditFlag = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtMeasure_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtMeasure_KeyUp
    '機　能：対策詳細ﾃｷｽﾄ　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 13:09:29 N.Kojima
    '更新日：2007/02/02 (Fri) 13:09:29
    '備　考：★★ 「故障　原因・対策 / 費用」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtMeasure_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtMeasure.KeyUp

        Try

            '@=======================
            '@　ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作処理
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtMeasure, CMlngMaxDisp5Row, cmdUP3, cmdDown3)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtMeasure_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtMeasure_MouseUp
    '機　能：対策詳細ﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 13:10:27 N.Kojima
    '更新日：2007/02/02 (Fri) 13:10:27
    '備　考：★★ 「故障　原因・対策 / 費用」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtMeasure_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtMeasure.MouseUp

        Try
            
            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtMeasure, CMlngMaxDisp5Row, cmdUP3, cmdDown3, e.Button)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtMeasure_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '★Tab：「保全 基本情報」　#########################################################################

    '関数名：calPreserveEndDate_CalendarSelect
    '機　能：終了(予定)日時ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/02/08 (Fri) 16:38:43 N.Kojima
    '更新日：2008/02/08 (Fri) 16:38:43
    '備　考：★★ 「保全 基本情報」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub calPreserveEndDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calPreserveEndDate.CalendarSelect

        Try

            With calPreserveEndDate

                '@日付が空の場合はﾌｫｰｶｽを留める
                If .Value = CPstrNullDate Then
                    Exit Sub
                End If

                '@=======================
                '@　終了(予定)日時ｶﾚﾝﾀﾞｰｺﾝﾎﾞのValidate処理
                '@=======================
                RemoveHandler calPreserveEndDate.Validating, AddressOf calPreserveEndDate_Validate
                Call calPreserveEndDate_Validate(calPreserveEndDate, New CancelEventArgs(True))
                AddHandler calPreserveEndDate.Validating, AddressOf calPreserveEndDate_Validate

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calPreserveEndDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calPreserveEndDate_Change
    '機　能：終了(予定)日時ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/02/08 (Fri) 16:38:43 N.Kojima
    '更新日：2008/02/08 (Fri) 16:38:43
    '備　考：★★ 「保全 基本情報」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub calPreserveEndDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calPreserveEndDate.Change

        Try
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True:ｱｸﾃｨﾍﾞｲﾄ処理済み"、ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞが"False:ｽｷｯﾌﾟする"以外か
            If mblnFormLoadFlag = True And mblnEventSkipFlag = True Then

                '@終了(予定)日時(年月日)が変更されているか
                If mstrOldPreserveEndDate <> calPreserveEndDate.Value Then

                    '@変更があった場合は編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄする
                    mblnEditFlag = True

                    '@変更後の終了(予定)日時(年月日)を次の判定用に格納
                    mstrOldPreserveEndDate = calPreserveEndDate.Value
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calPreserveEndDate_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calPreserveEndDate_Validate
    '機　能：終了(予定)日時ｶﾚﾝﾀﾞｰｺﾝﾎﾞ　Validate処理
    '引　数：Cancel ：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2008/02/08 (Fri) 16:38:43 N.Kojima
    '更新日：2008/02/08 (Fri) 16:38:43
    '備　考：★★ 「保全 基本情報」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub calPreserveEndDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calPreserveEndDate.Validating

        Dim lstrEndTime As String       '終了(予定)日時(時間)格納用

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@以下の条件の場合は処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If

            With calPreserveEndDate

                '@終了(予定)日時が入力されているか
                If .Value = CPstrNullDate Then
                    Exit Sub
                End If

                '@日付の有効性ﾁｪｯｸ
                If pubblnYearRange_Chk(.Value) = False Then
                    '@無効日付の場合

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@"正しい日付を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@ﾌｫｰｶｽを保持
                    If Me.ActiveControl.Name = tabMainteSheet.Name Then
                        mblnTabSelectEnabled = False
                        sender.Focus()
                    Else
                        e.Cancel = True
                    End If
                    Exit Sub
                Else
                    '@有効日付の場合

                    '@終了(予定)日時(時刻)が"__:__"か
                    If medPreserveEndTime.Text = CPstrNullTime Then
                        '@"23:59"を格納する
                        lstrEndTime = CPstrDayEndTime
                    Else
                        '@入力値を格納する
                        lstrEndTime = medPreserveEndTime.Text
                    End If

                    '@開始(予定)日時より未来が指定されているか
                    If lblPreserveStartDate.Text > _
                        calPreserveEndDate.Value & Space(1) & lstrEndTime Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002I, lblPreserveEndDateTitle.Text)
                        '@"<TRM2IW>$$開始日より過去の日付は指定できません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@ﾌｫｰｶｽを保持
                        If Me.ActiveControl.Name = tabMainteSheet.Name Then
                            mblnTabSelectEnabled = False
                            sender.Focus()
                        Else
                            e.Cancel = True
                        End If
                        Exit Sub
                    End If
                End If

                If ActiveControl.Name = calPreserveEndDate.Name Then
                    '@終了(予定)日時(時間)へｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(medPreserveEndTime)
                End If
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calPreserveEndDate_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medPreserveEndTime_Change
    '機　能：終了(予定)時刻ﾏｽｸｴﾃﾞｨｯﾄﾎﾞｯｸｽ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/02/12 (Tue) 08:56:44 N.Kojima
    '更新日：2008/02/12 (Tue) 08:56:44
    '備　考：★★ 「保全 基本情報」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub medPreserveEndTime_Change(ByVal sender As Object, ByVal e As EventArgs) Handles medPreserveEndTime.TextChanged

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True:ｱｸﾃｨﾍﾞｲﾄ処理済み"、ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞが"False:ｽｷｯﾌﾟする"以外か
            If mblnFormLoadFlag = True And mblnEventSkipFlag = True Then

                '@終了(予定)時刻が変更されているか
                If mstrOldPreserveEndTime <> medPreserveEndTime.Text Then

                    '@変更があった場合は編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄする
                    mblnEditFlag = True

                    '@変更後の終了(予定)時刻を次の判定用に格納
                    mstrOldPreserveEndTime = medPreserveEndTime.Text
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medPreserveEndTime_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medPreserveEndTime_GotFocus
    '機　能：終了(予定)時刻ﾏｽｸｴﾃﾞｨｯﾄﾎﾞｯｸｽ　ﾌｫｰｶｽ取得時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/02/12 (Tue) 09:01:56 N.Kojima
    '更新日：2008/02/12 (Tue) 09:01:56
    '備　考：★★ 「保全 基本情報」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub medPreserveEndTime_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles medPreserveEndTime.Enter

        Try

            '@=======================
            '@　ﾊｲﾗｲﾄ処理
            '@=======================
            Call pubHighlight(medPreserveEndTime)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medPreserveEndTime_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medPreserveEndTime_Validate
    '機　能：終了(予定)時刻ﾏｽｸｴﾃﾞｨｯﾄﾎﾞｯｸｽ　Validate処理
    '引　数：Cancel ：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2008/02/12 (Tue) 09:03:01 N.Kojima
    '更新日：2008/02/12 (Tue) 09:03:01
    '備　考：★★ 「保全 基本情報」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub medPreserveEndTime_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles medPreserveEndTime.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@以下の条件の場合は処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If

            '@終了(予定)時刻の有効性ﾁｪｯｸ
            If IsDate(medPreserveEndTime.Text) = False Then

                '@時間入力されていない(空欄)場合
                
                If medPreserveEndTime.Text = CPstrNullTime Then
                    '@現在日時取得ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = medPreserveEndTime.Name Then
                        Call pubSetFocus(cmdNowDate1)
                    End If
                    Exit Sub
                End If

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009I, lblPreserveEndDateTitle.Text)
                '@"<TRM9IW>$$[終了(予定)日時]の設定が正しくありません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@時間入力欄にｾｯﾄﾌｫｰｶｽ
                If Me.ActiveControl.Name = tabMainteSheet.Name Then
                    mblnTabSelectEnabled = False
                    sender.Focus()
                Else
                    e.Cancel = True
                End If
            Else
                '@終了(予定)時刻が有効な場合

                '@日付がNULLの場合は処理抜け
                If calPreserveEndDate.Value = CPstrNullDate Then
                    Exit Sub
                End If

                '@開始(予定)日時より未来が指定されているか
                If lblPreserveStartDate.Text > _
                    calPreserveEndDate.Value & Space(1) & medPreserveEndTime.Text Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002I, lblPreserveEndDateTitle.Text)
                    '@"<TRM2IW>$$開始日より過去の日付は指定できません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@時間入力欄にｾｯﾄﾌｫｰｶｽ
                    If Me.ActiveControl.Name = tabMainteSheet.Name Then
                        mblnTabSelectEnabled = False
                        sender.Focus()
                    Else
                        e.Cancel = True
                    End If
                    Exit Sub
                End If

                '@現在日時取得ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = medPreserveEndTime.Name Then
                    Call pubSetFocus(cmdNowDate1)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medPreserveEndTime_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtPreserveComment_Change
    '機　能：停止ｺﾒﾝﾄﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/03/07 (Fri) 16:53:16 N.Kojima
    '更新日：2008/03/07 (Fri) 16:53:16
    '備　考：★★ 「保全 基本情報」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtPreserveComment_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtPreserveComment.Change

        Dim llngNowByte As Integer  'ﾊﾞｲﾄ数

        Try
            
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtPreserveComment.NowByte

            '@=======================
            '@　現在のﾊﾞｲﾄ数表示処理(表示ﾒｯｾｰｼﾞ変換処理)
            '@=======================
            lblLengthCount6.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                           llngNowByte, _
                                                           CPlngLotCommentsMaxByte)

            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtPreserveComment, CMlngMaxDisp7Row, cmdUP4, cmdDown4)

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True:ｱｸﾃｨﾍﾞｲﾄ処理済み"、ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞが"False:ｽｷｯﾌﾟする"以外か
            If mblnFormLoadFlag = True And mblnEventSkipFlag = True Then

                '@変更があった場合は編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄする
                mblnEditFlag = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPreserveComment_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtPreserveComment_KeyUp
    '機　能：停止ｺﾒﾝﾄﾃｷｽﾄ　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2008/03/07 (Fri) 16:53:16 N.Kojima
    '更新日：2008/03/07 (Fri) 16:53:16
    '備　考：★★ 「保全 基本情報」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtPreserveComment_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtPreserveComment.KeyUp

        Try
            
            '@=======================
            '@　ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作処理
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtPreserveComment, CMlngMaxDisp7Row, cmdUP4, cmdDown4)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPreserveComment_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtPreserveComment_MouseUp
    '機　能：停止ｺﾒﾝﾄﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2008/03/07 (Fri) 16:53:16 N.Kojima
    '更新日：2008/03/07 (Fri) 16:53:16
    '備　考：★★ 「保全 基本情報」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtPreserveComment_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtPreserveComment.MouseUp

        Try
            
            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtPreserveComment, CMlngMaxDisp7Row, cmdUP4, cmdDown4, e.Button)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPreserveComment_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '★Tab：「保全 項目・内容・目的/費用」　#########################################################################

    '関数名：txtPreserveItem_Change
    '機　能：実施項目ﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/03/07 (Fri) 16:53:16 N.Kojima
    '更新日：2008/03/07 (Fri) 16:53:16
    '備　考：★★ 「保全 項目・内容・目的/費用」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtPreserveItem_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtPreserveItem.Change

        Dim llngNowByte As Integer  'ﾊﾞｲﾄ数

        Try
            
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtPreserveItem.NowByte

            '@=======================
            '@　現在のﾊﾞｲﾄ数表示処理(表示ﾒｯｾｰｼﾞ変換処理)
            '@=======================
            lblLengthCount7.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                           llngNowByte, _
                                                           CPlngLotCommentsMaxByte)

            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtPreserveItem, CMlngMaxDisp5Row, cmdUP5, cmdDown5)

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True:ｱｸﾃｨﾍﾞｲﾄ処理済み"、ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞが"False:ｽｷｯﾌﾟする"以外か
            If mblnFormLoadFlag = True And mblnEventSkipFlag = True Then

                '@変更があった場合は編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄする
                mblnEditFlag = True

                '@実施項目編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄする
                mblnPreserveItemEditFlag = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPreserveItem_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtPreserveItem_KeyUp
    '機　能：実施項目ﾃｷｽﾄ　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2008/03/07 (Fri) 16:53:16 N.Kojima
    '更新日：2008/03/07 (Fri) 16:53:16
    '備　考：★★ 「保全 項目・内容・目的/費用」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtPreserveItem_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtPreserveItem.KeyUp

        Try
            
            '@=======================
            '@　ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作処理
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtPreserveItem, CMlngMaxDisp5Row, cmdUP5, cmdDown5)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPreserveItem_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtPreserveItem_MouseUp
    '機　能：実施項目ﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2008/03/07 (Fri) 16:53:16 N.Kojima
    '更新日：2008/03/07 (Fri) 16:53:16
    '備　考：★★ 「保全 項目・内容・目的/費用」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtPreserveItem_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtPreserveItem.MouseUp

        Try
            
            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtPreserveItem, CMlngMaxDisp5Row, cmdUP5, cmdDown5, e.Button)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPreserveItem_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtPreserveContents_Change
    '機　能：実施内容ﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/03/07 (Fri) 16:53:16 N.Kojima
    '更新日：2008/03/07 (Fri) 16:53:16
    '備　考：★★ 「保全 項目・内容・目的/費用」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtPreserveContents_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtPreserveContents.Change

        Dim llngNowByte As Integer  'ﾊﾞｲﾄ数

        Try
            
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtPreserveContents.NowByte

            '@=======================
            '@　現在のﾊﾞｲﾄ数表示処理(表示ﾒｯｾｰｼﾞ変換処理)
            '@=======================
            lblLengthCount8.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                           llngNowByte, _
                                                           CPlngLotCommentsMaxByte)

            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtPreserveContents, CMlngMaxDisp5Row, cmdUP6, cmdDown6)

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True:ｱｸﾃｨﾍﾞｲﾄ処理済み"、ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞが"False:ｽｷｯﾌﾟする"以外か
            If mblnFormLoadFlag = True And mblnEventSkipFlag = True Then

                '@変更があった場合は編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄする
                mblnEditFlag = True

                '@実施目的/理由編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄする
                mblnPreserveContentsEditFlag = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPreserveContents_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtPreserveContents_KeyUp
    '機　能：実施内容ﾃｷｽﾄ　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2008/03/07 (Fri) 16:53:16 N.Kojima
    '更新日：2008/03/07 (Fri) 16:53:16
    '備　考：★★ 「保全 項目・内容・目的/費用」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtPreserveContents_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtPreserveContents.KeyUp

        Try
            
            '@=======================
            '@　ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作処理
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtPreserveContents, CMlngMaxDisp5Row, cmdUP6, cmdDown6)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPreserveContents_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtPreserveContents_MouseUp
    '機　能：実施内容ﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2008/03/07 (Fri) 16:53:16 N.Kojima
    '更新日：2008/03/07 (Fri) 16:53:16
    '備　考：★★ 「保全 項目・内容・目的/費用」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtPreserveContents_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtPreserveContents.MouseUp

        Try
            
            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtPreserveContents, CMlngMaxDisp5Row, cmdUP6, cmdDown6, e.Button)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPreserveContents_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtPreservePurpose_Change
    '機　能：実施目的/理由ﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/03/07 (Fri) 16:53:16 N.Kojima
    '更新日：2008/03/07 (Fri) 16:53:16
    '備　考：★★ 「保全 項目・内容・目的/費用」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtPreservePurpose_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtPreservePurpose.Change

        Dim llngNowByte As Integer  'ﾊﾞｲﾄ数

        Try
            
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtPreservePurpose.NowByte

            '@=======================
            '@　現在のﾊﾞｲﾄ数表示処理(表示ﾒｯｾｰｼﾞ変換処理)
            '@=======================
            lblLengthCount9.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                           llngNowByte, _
                                                           CPlngLotCommentsMaxByte)

            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtPreservePurpose, CMlngMaxDisp5Row, cmdUP7, cmdDown7)

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞが"True:ｱｸﾃｨﾍﾞｲﾄ処理済み"、ｲﾍﾞﾝﾄｽｷｯﾌﾟﾌﾗｸﾞが"False:ｽｷｯﾌﾟする"以外か
            If mblnFormLoadFlag = True And mblnEventSkipFlag = True Then

                '@変更があった場合は編集ﾌﾗｸﾞに"True:編集あり"をｾｯﾄする
                mblnEditFlag = True

                '@実施目的/理由ﾌﾗｸﾞに"True:編集あり"をｾｯﾄする
                mblnPreservePurposeEditFlag = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPreservePurpose_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtPreservePurpose_KeyUp
    '機　能：実施目的/理由ﾃｷｽﾄ　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2008/03/07 (Fri) 16:53:16 N.Kojima
    '更新日：2008/03/07 (Fri) 16:53:16
    '備　考：★★ 「保全 項目・内容・目的/費用」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtPreservePurpose_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtPreservePurpose.KeyUp

        Try
            
            '@=======================
            '@　ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作処理
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtPreservePurpose, CMlngMaxDisp5Row, cmdUP7, cmdDown7)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPreservePurpose_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtPreservePurpose_MouseUp
    '機　能：実施目的/理由ﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2008/03/07 (Fri) 16:53:16 N.Kojima
    '更新日：2008/03/07 (Fri) 16:53:16
    '備　考：★★ 「保全 項目・内容・目的/費用」Tabのｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub txtPreservePurpose_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtPreservePurpose.MouseUp

        Try
            
            '@=======================
            '@　ﾃｷｽﾄ変更処理
            '@=======================
            Call pubtxtChange_Proc(txtPreservePurpose, CMlngMaxDisp5Row, cmdUP7, cmdDown7, e.Button)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPreservePurpose_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '★Tab：全Tab共通　########################################################################################

    '関数名：cmdSign_Click
    '機　能：ｻｲﾝﾎﾞﾀﾝ　Click＆押下時処理
    '引　数：Index  ：ｺﾝﾄﾛｰﾙ配列ｲﾝﾃﾞｯｸｽ
    '戻り値：
    '作成日：2007/03/15 (Thu) 11:44:59 N.Kojima
    '更新日：2008/02/12 (Tue) 11:15:30 N.Kojima
    '備　考：★★ 全Tabで共通のｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    '　　　：
    '　　　：2008/02/12 (Tue) 11:15:30 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub cmdSign_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSign0.Click,
                                                                                    cmdSign1.Click,
                                                                                    cmdSign2.Click,
                                                                                    cmdSign3.Click,
                                                                                    cmdSign4.Click,
                                                                                    cmdSign5.Click,
                                                                                    cmdSign6.Click,
                                                                                    cmdSign7.Click,
                                                                                    cmdSign8.Click,
                                                                                    cmdSign9.Click

        Dim lstrDateTime As String           '時間取得
        Dim lstrIndex As String       'ｲﾝﾃﾞｯｸｽ退避用
        Dim Index As Integer
        Dim reg As New Regex("[^0-9]")

        Try

            'NSYS 押された▲ボタンの番号部分を取得
            lstrIndex = reg.Replace(sender.Name, "")

            'NSYS 数値が取得できた場合のみ処理を続行する
            If IsNumeric(lstrIndex) = True Then
                Index = CInt(lstrIndex)
            Else
                Exit Sub
            End If
            
            '@以下の条件の場合は処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.Text = CPstrSubDispTitleSign
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@取消ﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            Else
                '@時間取得
                lstrDateTime = prvFormatDate(Now, CPstrDateTimeYMD)
            End If

            '@ﾗﾍﾞﾙに情報ｾｯﾄ(年月日、ﾕｰｻﾞｰ名)
            lblSignDateArray(Index).Text = lstrDateTime
            lblSignNameArray(Index).Text = pstrUserName

            '@★ 選択ﾀﾌﾞにより処理分岐 ★
            Select Case tabMainteSheet.SelectedIndex

                '@〓 「故障 基本情報/現象」Tab or 「故障 原因・対策/費用」Tab 〓
                Case CMlngRepairBaseInfoTabIndex, CMlngRepairCauseInfoTabIndex

                    '@故障修理記録情報格納構造体に入力情報をｾｯﾄ
                    With mtypRepairInfoAns

                        '@★★ ｺﾝﾄﾛｰﾙ配列ｲﾝﾃﾞｯｸｽにより処理分岐 ★★
                        Select Case Index

                            '@〓〓 故障現象ｻｲﾝ欄 〓〓
                            Case CPlngNumZero

                                .strRepairNameSignEmpID = pstrUserID                                '故障現象ｻｲﾝ者ID
                                .strRepairNameSignEmpName = lblSignNameArray(Index).Text              '故障現象ｻｲﾝ者氏名
                                .strRepairNameSignDate = lblSignDateArray(Index).Text                 '故障現象ｻｲﾝ日

                            '@〓〓 故障原因調査/分析ｻｲﾝ欄 〓〓
                            Case CPlngNumOne

                                .strRepairAnalysisSignEmpID = pstrUserID                            '故障原因調査/分析ｻｲﾝ者ID
                                .strRepairAnalysisSignEmpName = lblSignNameArray(Index).Text          '故障原因調査/分析ｻｲﾝ者氏名
                                .strRepairAnalysisSignDate = lblSignDateArray(Index).Text             '故障原因調査/分析ｻｲﾝ日

                            '@〓〓 故障原因ｻｲﾝ欄 〓〓
                            Case CPlngNumTwo

                                .strRepairCauseSignEmpID = pstrUserID                               '故障原因ｻｲﾝ者ID
                                .strRepairCauseSignEmpName = lblSignNameArray(Index).Text             '故障原因ｻｲﾝ者氏名
                                .strRepairCauseSignDate = lblSignDateArray(Index).Text                '故障原因ｻｲﾝ日

                            '@〓〓 故障対策ｻｲﾝ欄 〓〓
                            Case CPlngNumThree

                                .strRepairMeasureSignEmpID = pstrUserID                             '故障対策ｻｲﾝ者ID
                                .strRepairMeasureSignEmpName = lblSignNameArray(Index).Text           '故障対策ｻｲﾝ者氏名
                                .strRepairMeasureSignDate = lblSignDateArray(Index).Text              '故障対策ｻｲﾝ日

                            '@〓〓 保全担当ｻｲﾝ欄 〓〓
                            Case CPlngNumFour

                                .strPreserveSignEmpID = pstrUserID                                  '保全担当ｻｲﾝ者ID
                                .strPreserveSignEmpName = lblSignNameArray(Index).Text                '保全担当ｻｲﾝ者氏名
                                .strPreserveSignDate = lblSignDateArray(Index).Text                   '保全担当ｻｲﾝ日

                            '@〓〓 保全ﾘｰﾀﾞｰｻｲﾝ欄 〓〓
                            Case CPlngNumFive

                                .strPreserveLeaderSignEmpID = pstrUserID                            '保全ﾘｰﾀﾞｰｻｲﾝ者ID
                                .strPreserveLeaderSignEmpName = lblSignNameArray(Index).Text          '保全ﾘｰﾀﾞｰｻｲﾝ者氏名
                                .strPreserveLeaderSignDate = lblSignDateArray(Index).Text             '保全ﾘｰﾀﾞｰｻｲﾝ日

                            '@〓〓 作業長ｻｲﾝ欄 〓〓
                            Case CPlngNumSix

                                .strProductLeaderSignEmpID = pstrUserID                             '作業長ｻｲﾝ者ID
                                .strProductLeaderSignEmpName = lblSignNameArray(Index).Text           '作業長ｻｲﾝ者氏名
                                .strProductLeaderSignDate = lblSignDateArray(Index).Text              '作業長ｻｲﾝ日

                        End Select
                    End With


                '@〓 「保全 基本情報」Tab or 「保全 項目・内容・目的/費用」Tab 〓
                Case CMlngPreserveBaseInfoTabIndex, CMlngPreserveItemInfoTabIndex

                    '@保全記録情報格納構造体に入力情報をｾｯﾄ
                    With mtypPreserveInfoAns

                        '@★★ ｺﾝﾄﾛｰﾙ配列ｲﾝﾃﾞｯｸｽにより処理分岐 ★★
                        Select Case Index

                            '@〓〓 保全担当ｻｲﾝ欄 〓〓
                            Case CPlngNumSeven

                                .strPreserveSignEmpID = pstrUserID                                  '保全担当ｻｲﾝ者ID
                                .strPreserveSignEmpName = lblSignNameArray(Index).Text                '保全担当ｻｲﾝ者氏名
                                .strPreserveSignDate = lblSignDateArray(Index).Text                   '保全担当ｻｲﾝ日

                            '@〓〓 保全ﾘｰﾀﾞｰｻｲﾝ欄 〓〓
                            Case CPlngNumEight

                                .strPreserveLeaderSignEmpID = pstrUserID                            '保全ﾘｰﾀﾞｰｻｲﾝ者ID
                                .strPreserveLeaderSignEmpName = lblSignNameArray(Index).Text          '保全ﾘｰﾀﾞｰｻｲﾝ者氏名
                                .strPreserveLeaderSignDate = lblSignDateArray(Index).Text             '保全ﾘｰﾀﾞｰｻｲﾝ日

                            '@〓〓 作業長ｻｲﾝ欄 〓〓
                            Case CPlngNumNine

                                .strProductLeaderSignEmpID = pstrUserID                             '作業長ｻｲﾝ者ID
                                .strProductLeaderSignEmpName = lblSignNameArray(Index).Text           '作業長ｻｲﾝ者氏名
                                .strProductLeaderSignDate = lblSignDateArray(Index).Text              '作業長ｻｲﾝ日

                        End Select
                    End With

            End Select

            '@取消ﾎﾞﾀﾝを有効にし、ﾌｫｰｶｽｾｯﾄ
            cmdCancelArray(Index).Enabled = True

            Call pubSetFocus(cmdCancelArray(Index))

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSign_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCancel_Click
    '機　能：ｻｲﾝ取消ﾎﾞﾀﾝ　Click＆押下時処理
    '引　数：Index  ：ｺﾝﾄﾛｰﾙ配列ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2007/03/15 (Thu) 12:19:43 N.Kojima
    '更新日：2008/02/12 (Tue) 11:15:30 N.Kojima
    '備　考：★★ 全Tabで共通のｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    '　　　：
    '　　　：2008/02/12 (Tue) 11:15:30 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel0.Click,
                                                                                      cmdCancel1.Click,
                                                                                      cmdCancel2.Click,
                                                                                      cmdCancel3.Click,
                                                                                      cmdCancel4.Click,
                                                                                      cmdCancel5.Click,
                                                                                      cmdCancel6.Click,
                                                                                      cmdCancel7.Click,
                                                                                      cmdCancel8.Click,
                                                                                      cmdCancel9.Click


        Dim lstrIndex As String       'ｲﾝﾃﾞｯｸｽ退避用

        Dim Index As Integer
        Dim reg As New Regex("[^0-9]")

        Try

            'NSYS 押された▲ボタンの番号部分を取得
            lstrIndex = reg.Replace(sender.Name, "")

            'NSYS 数値が取得できた場合のみ処理を続行する
            If IsNumeric(lstrIndex) = True Then
                Index = CInt(lstrIndex)
            Else
                Exit Sub
            End If

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の条件の場合は処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If

            '@ﾗﾍﾞﾙを空欄にする
            lblSignDateArray(Index).Text = vbNullString
            lblSignNameArray(Index).Text = vbNullString

            '@★ 選択ﾀﾌﾞにより処理分岐 ★
            Select Case tabMainteSheet.SelectedIndex

                '@〓 「故障 基本情報/現象」Tab or 「故障 原因・対策/費用」Tab 〓
                Case CMlngRepairBaseInfoTabIndex, CMlngRepairCauseInfoTabIndex

                    '@故障修理記録情報格納構造体に入力情報をｾｯﾄ
                    With mtypRepairInfoAns

                        '@★★ ｺﾝﾄﾛｰﾙ配列ｲﾝﾃﾞｯｸｽにより処理分岐 ★★
                        Select Case Index

                            '@〓〓 故障現象ｻｲﾝ欄 〓〓
                            Case CPlngNumZero

                                .strRepairNameSignEmpID = vbNullString                  '故障現象ｻｲﾝ者ID
                                .strRepairNameSignEmpName = vbNullString                '故障現象ｻｲﾝ者氏名
                                .strRepairNameSignDate = vbNullString                   '故障現象ｻｲﾝ日

                            '@〓〓 故障原因調査/分析ｻｲﾝ欄 〓〓
                            Case CPlngNumOne

                                .strRepairAnalysisSignEmpID = vbNullString              '故障原因調査/分析ｻｲﾝ者ID
                                .strRepairAnalysisSignEmpName = vbNullString            '故障原因調査/分析ｻｲﾝ者氏名
                                .strRepairAnalysisSignDate = vbNullString               '故障原因調査/分析ｻｲﾝ日

                            '@〓〓 故障原因ｻｲﾝ欄 〓〓
                            Case CPlngNumTwo

                                .strRepairCauseSignEmpID = vbNullString                 '故障原因ｻｲﾝ者ID
                                .strRepairCauseSignEmpName = vbNullString               '故障原因ｻｲﾝ者氏名
                                .strRepairCauseSignDate = vbNullString                  '故障原因ｻｲﾝ日

                            '@〓〓 故障対策ｻｲﾝ欄 〓〓
                            Case CPlngNumThree

                                .strRepairMeasureSignEmpID = vbNullString               '故障対策ｻｲﾝ者ID
                                .strRepairMeasureSignEmpName = vbNullString             '故障対策ｻｲﾝ者氏名
                                .strRepairMeasureSignDate = vbNullString                '故障対策ｻｲﾝ日

                            '@〓〓 保全担当ｻｲﾝ欄 〓〓
                            Case CPlngNumFour

                                .strPreserveSignEmpID = vbNullString                    '保全担当ｻｲﾝ者ID
                                .strPreserveSignEmpName = vbNullString                  '保全担当ｻｲﾝ者氏名
                                .strPreserveSignDate = vbNullString                     '保全担当ｻｲﾝ日

                            '@〓〓 保全ﾘｰﾀﾞｰｻｲﾝ欄 〓〓
                            Case CPlngNumFive

                                .strPreserveLeaderSignEmpID = vbNullString              '保全ﾘｰﾀﾞｰｻｲﾝ者ID
                                .strPreserveLeaderSignEmpName = vbNullString            '保全ﾘｰﾀﾞｰｻｲﾝ者氏名
                                .strPreserveLeaderSignDate = vbNullString               '保全ﾘｰﾀﾞｰｻｲﾝ日

                            '@〓〓 作業長ｻｲﾝ欄 〓〓
                            Case CPlngNumSix

                                .strProductLeaderSignEmpID = vbNullString               '作業長ｻｲﾝ者ID
                                .strProductLeaderSignEmpName = vbNullString             '作業長ｻｲﾝ者氏名
                                .strProductLeaderSignDate = vbNullString                '作業長ｻｲﾝ日

                        End Select
                    End With


                '@〓 「保全 基本情報」Tab or 「保全 項目・内容・目的/費用」Tab 〓
                Case CMlngPreserveBaseInfoTabIndex, CMlngPreserveItemInfoTabIndex

                    '@保全記録情報格納構造体に入力情報をｾｯﾄ
                    With mtypPreserveInfoAns

                        '@★★ ｺﾝﾄﾛｰﾙ配列ｲﾝﾃﾞｯｸｽにより処理分岐 ★★
                        Select Case Index

                            '@〓〓 保全担当ｻｲﾝ欄 〓〓
                            Case CPlngNumSeven

                                .strPreserveSignEmpID = vbNullString                    '保全担当ｻｲﾝ者ID
                                .strPreserveSignEmpName = vbNullString                  '保全担当ｻｲﾝ者氏名
                                .strPreserveSignDate = vbNullString                     '保全担当ｻｲﾝ日

                            '@〓〓 保全ﾘｰﾀﾞｰｻｲﾝ欄 〓〓
                            Case CPlngNumEight

                                .strPreserveLeaderSignEmpID = vbNullString              '保全ﾘｰﾀﾞｰｻｲﾝ者ID
                                .strPreserveLeaderSignEmpName = vbNullString            '保全ﾘｰﾀﾞｰｻｲﾝ者氏名
                                .strPreserveLeaderSignDate = vbNullString               '保全ﾘｰﾀﾞｰｻｲﾝ日

                            '@〓〓 作業長ｻｲﾝ欄 〓〓
                            Case CPlngNumNine

                                .strProductLeaderSignEmpID = vbNullString               '作業長ｻｲﾝ者ID
                                .strProductLeaderSignEmpName = vbNullString             '作業長ｻｲﾝ者氏名
                                .strProductLeaderSignDate = vbNullString                '作業長ｻｲﾝ日

                        End Select
                    End With

            End Select

            '@取消ﾎﾞﾀﾝを無効にし、ｻｲﾝﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(cmdSignArray(Index))
            cmdCancelArray(Index).Enabled = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCancel_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ　Click＆押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 11:28:39 N.Kojima
    '更新日：2007/02/02 (Fri) 11:28:39
    '備　考：★★ 全Tabで共通のｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾌｫｰﾑを閉じる
            Me.Close()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClose_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDispose_Click
    '機　能：処置ﾎﾞﾀﾝ　Click＆押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 10:34:03 N.Kojima
    '更新日：2008/02/12 (Tue) 11:15:30 N.Kojima
    '備　考：★★ 全Tabで共通のｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    '　　　：
    '　　　：2007/03/23 (Fri) 12:40:39 N.Kojima     入力項目(ｻｲﾝ欄＆修理完了日時)追加に伴い、処理追加。(案件№01830)
    '　　　：2008/02/12 (Tue) 11:15:30 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub cmdDispose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDispose.Click

        Dim lblnAns As Boolean          '結果格納
        Dim lstrEditTime As String           '更新日時
        Dim lblnDateChkAns As Boolean          '日付ﾁｪｯｸ結果格納用

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の条件の場合は処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If


            '@★ 起動区分により処理分岐 ★
            Select Case plngLoadClass

                '@〓 "1:故障修理記録" 〓
                Case CPlngNumOne

                    '@=======================
                    '@　故障修理記録関連　必須項目入力ﾁｪｯｸ処理
                    '@=======================
                    lblnDateChkAns = prvRepairInputDataChk_Proc(CMstrCmdDisposeClick)

                '@〓 "2:保全記録" 〓
                Case CPlngNumTwo

                    '@=======================
                    '@　保全記録関連　必須項目入力ﾁｪｯｸ処理
                    '@=======================
                    lblnDateChkAns = prvPreserveInputDataChk_Proc(CMstrCmdDisposeClick)

            End Select

            '@ﾁｪｯｸNGの場合は処理終了
            If lblnDateChkAns = False Then
                Exit Sub
            End If


            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@取消ﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdDisposeClick)


            '@★ 起動区分により処理分岐 ★
            Select Case plngLoadClass

                '@〓 "1:故障修理記録" 〓
                Case CPlngNumOne

                    '@=======================
                    '@　故障修理記録関連　送信ﾃﾞｰﾀ作成処理
                    '@=======================
                    Call prvRepairRequestDataSet_Proc(CMstrCmdDisposeClick)

                    '@画面の使用禁止
                    Me.KeyPreview = False

                    '@【故障修理記録票情報更新】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnRepChgRepairReport_Upd(mtypChgRepairInfoReq, lstrEditTime)

                    '@画面の使用禁止解除
                    Me.KeyPreview = True


                '@〓 "2:保全記録" 〓
                Case CPlngNumTwo

                    '@=======================
                    '@　保全記録関連　送信ﾃﾞｰﾀ作成処理
                    '@=======================
                    Call prvPreserveRequestDataSet_Proc(CMstrCmdDisposeClick)

                    '@画面の使用禁止
                    Me.KeyPreview = False

                    '@【保全記録票情報更新】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnPreChgPreserveReport_Upd(mtypChgPreserveInfoReq, lstrEditTime)

                    '@画面の使用禁止解除
                    Me.KeyPreview = True

            End Select

            '@通信結果判定
            If lblnAns = False Then
                '@結果：異常の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdDisposeClick)
                Exit Sub
            End If


            '@********************
            '@　通信後の共通処理
            '@********************
            '@編集ﾌﾗｸﾞの初期化する
            mblnEditFlag = False

            '@各種ﾎﾞﾀﾝの制御
            cmdDispose.Enabled = False      '処置ﾎﾞﾀﾝ
            cmdApprove.Enabled = True       '承認ﾎﾞﾀﾝ

            '@=======================
            '@　装置ﾒﾝﾃﾅﾝｽ記録票更新後処理
            '@=======================
            Call prvAfterReportUpdate_Proc(CMstrCmdDisposeClick)


            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrCmdDisposeClick)

            Exit Sub

        Catch ex As Exception

            '@画面の使用禁止解除
            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDispose_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSave_Click
    '機　能：一時保存ﾎﾞﾀﾝ　Click＆押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 10:33:48 N.Kojima
    '更新日：2007/03/23 (Fri) 12:40:39 N.Kojima
    '備　考：★★ 全Tabで共通のｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    '　　　：
    '　　　：2007/03/23 (Fri) 12:40:39 N.Kojima     入力項目(ｻｲﾝ欄＆修理完了日時)追加に伴い、処理追加。(案件№01830)
    '　　　：2008/02/12 (Tue) 11:15:30 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSave.Click

        Dim lblnAns As Boolean      '通信結果格納
        Dim lstrEditTime As String       '更新日時
        Dim lblnDateChkAns As Boolean      '日付ﾁｪｯｸ結果格納用

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の条件の場合は処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If


            '@★ 起動区分により処理分岐 ★
            Select Case plngLoadClass

                '@〓 "1:故障修理記録" 〓
                Case CPlngNumOne

                    '@=======================
                    '@　故障修理記録関連　必須項目入力ﾁｪｯｸ処理
                    '@=======================
                    lblnDateChkAns = prvRepairInputDataChk_Proc(CMstrCmdSaveClick)


                '@〓 "2:保全記録" 〓
                Case CPlngNumTwo

                    '@=======================
                    '@　保全記録関連　必須項目入力ﾁｪｯｸ処理
                    '@=======================
                    lblnDateChkAns = prvPreserveInputDataChk_Proc(CMstrCmdSaveClick)

            End Select

            '@ﾁｪｯｸNGの場合は処理終了
            If lblnDateChkAns = False Then
                Exit Sub
            End If


            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@取消ﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdSaveClick)


            '@★ 起動区分により処理分岐 ★
            Select Case plngLoadClass

                '@〓 "1:故障修理記録" 〓
                Case CPlngNumOne

                    '@=======================
                    '@　故障修理記録関連　送信ﾃﾞｰﾀ作成処理
                    '@=======================
                    Call prvRepairRequestDataSet_Proc(CMstrCmdSaveClick)

                    '@画面の使用禁止
                    Me.KeyPreview = False

                    '@【故障修理記録票情報更新】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnRepChgRepairReport_Upd(mtypChgRepairInfoReq, lstrEditTime)

                    '@画面の使用禁止解除
                    Me.KeyPreview = True


                '@〓 "2:保全記録" 〓
                Case CPlngNumTwo

                    '@=======================
                    '@　保全記録関連　送信ﾃﾞｰﾀ作成処理
                    '@=======================
                    Call prvPreserveRequestDataSet_Proc(CMstrCmdSaveClick)

                    '@画面の使用禁止
                    Me.KeyPreview = False

                    '@【保全記録票情報更新】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnPreChgPreserveReport_Upd(mtypChgPreserveInfoReq, lstrEditTime)

                    '@画面の使用禁止解除
                    Me.KeyPreview = True

            End Select

            '@通信結果判定
            If lblnAns = False Then
                '@結果：異常の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdSaveClick)
                Exit Sub
            End If

            '@********************
            '@　通信後の共通処理
            '@********************
            '@編集ﾌﾗｸﾞの初期化する
            mblnEditFlag = False


            '@=======================
            '@　装置ﾒﾝﾃﾅﾝｽ記録票更新後処理
            '@=======================
            Call prvAfterReportUpdate_Proc(CMstrCmdSaveClick)


            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrCmdSaveClick)

            Exit Sub

        Catch ex As Exception

            '@画面の使用禁止解除
            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSave_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMail_Click
    '機　能：確認依頼ﾎﾞﾀﾝ　Click＆押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 10:37:06 N.Kojima
    '更新日：2008/02/12 (Tue) 11:15:30 N.Kojima
    '備　考：★★ 全Tabで共通のｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    '　　　：
    '　　　：2008/02/12 (Tue) 11:15:30 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub cmdMail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMail.Click

        Dim lstrMsg As String               'ﾒｯｾｰｼﾞ内容格納
        Dim lblnAns As Boolean              '結果取得(True:正常,False:異常)
        Dim llngCnt As Integer              '汎用ｶｳﾝﾄ
        Dim ltypWorkFlow As WorkFlow             '初期化用構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の条件の場合は処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If

            '@確認依頼用情報格納構造体の初期化
            ptypWorkFlow = ltypWorkFlow

            '@ﾒｰﾙ送信要求格納構造体の初期化
            With ptypMailInfo
                .strMailContents = vbNullString         'ﾒｰﾙ本文
                .strMailSubject = vbNullString          'ﾒｰﾙｻﾌﾞｼﾞｪｸﾄ
            End With

            '@宛先人格納構造体の初期化
            '配列の初期化
            If Not IsNothing(ptypSendMailList.typSendMail) Then
                ptypSendMailList.typSendMail.Clear
                ptypSendMailList.typSendMail = Nothing
            End If

            ptypSendMailList.lngSendMailCnt = 0     '配列ｶｳﾝﾄの初期化


            '@★ 起動区分により処理分岐 ★
            Select Case plngLoadClass

                '@〓 "1:故障修理記録" 〓
                Case CPlngNumOne

                    '@故障修理記録票確認依頼情報を格納
                    With ptypWorkFlow
                        .strReportNo = mtypRepairInfoAns.strRepairNo        '処理票№
                        .strWpID = mtypRepairInfoAns.strWpID                '装置ID
                        .strSbID = pstrSBID                                 '起案ｼｽﾃﾑﾌﾞﾛｯｸ
                    End With

                    '@***********************
                    '@　ﾒｰﾙ送信要求ﾃﾞｰﾀ作成
                    '@***********************
                    With ptypMailInfo

                        '@ﾒｰﾙ内容格納
                        '@件名文字列作成
                        .strMailSubject = CPstrMailSendTitleRepair & _
                                            Replace(CPstrMailSubjectReport, "%1", lblRepairNo.Text)

                        '@########## ﾒｰﾙ本文固定表記 ##########
                        '@送信者    ：XXXXXXXXXX
                        '@発行№    ：XXXXXXXXXX
                        '@故障現象名：XXXXXXXXXX
                        '@対象装置  ：XXXXXXXXXX
                        '@########## ﾒｰﾙ本文固定表記 ##########
                        '@本文文字列作成
                        .strMailContents = CPstrMailReportNo & lblRepairNo.Text & vbCrLf & _
                                           CPstrMailRepairName & txtRepairName.Text & vbCrLf & _
                                           CPstrMailWP & lblRepairWpName.Text
                    End With


                '@〓 "2:保全記録" 〓
                Case CPlngNumTwo

                    '@保全記録票確認依頼情報を格納
                    With ptypWorkFlow
                        .strReportNo = mtypPreserveInfoAns.strPreserveNo    '処理票№
                        .strWpID = mtypPreserveInfoAns.strWpID              '装置ID
                        .strSbID = pstrSBID                                 '起案ｼｽﾃﾑﾌﾞﾛｯｸ
                    End With

                    '@***********************
                    '@　ﾒｰﾙ送信要求ﾃﾞｰﾀ作成
                    '@***********************
                    With ptypMailInfo

                        '@ﾒｰﾙ内容格納
                        '@件名文字列作成
                        .strMailSubject = CPstrMailSendTitlePreserve & _
                                            Replace(CPstrMailSubjectReport, "%1", lblPreserveNo.Text)

                        '@########## ﾒｰﾙ本文固定表記 ##########
                        '@送信者    ：XXXXXXXXXX
                        '@発行№    ：XXXXXXXXXX
                        '@実施項目  ：XXXXXXXXXX
                        '@対象装置  ：XXXXXXXXXX
                        '@########## ﾒｰﾙ本文固定表記 ##########
                        '@本文文字列作成
                        .strMailContents = CPstrMailReportNo & lblPreserveNo.Text & vbCrLf & _
                                           CPstrMailPreserveItemName & txtPreserveItem.Text & vbCrLf & _
                                           CPstrMailWP & lblPreserveWpName.Text
                    End With

            End Select


            '@引継起動ﾌﾗｸﾞの設定
            pblnfrmxxCM00Z0kbn = True               '故障修理記録票/保全記録票 確認依頼
            pblnfrmxxEN01Z0kbn = False
            pblnfrmxxEN0050kbn = False
            pblnfrmxxEN00V0kbn = False

            '@引継処理ﾌﾗｸﾞの初期化
            plngfrmxxCM00S0Kbn = 0

            '@起動ﾌﾗｸﾞの初期化
            pblnFormLoad = False

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　ﾒｰﾙ送信画面　起動処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM00S0.Instance = New frmxxCM00S0()

            '@起動結果判定
            If pblnFormLoad = True Then
                '@結果：正常の場合

                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@　ﾒｰﾙ送信画面　起動処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                frmxxCM00S0.Instance.ShowDialog(Me)
                frmxxCM00S0.Instance = Nothing
            Else
                '@結果：異常の場合

                '@∇∇∇∇∇∇∇∇∇
                '@　ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇
                frmxxCM00S0.Instance = Nothing

                '@引継起動ﾌﾗｸﾞの初期化
                pblnfrmxxCM00Z0kbn = False
                pblnfrmxxEN01Z0kbn = False
                pblnfrmxxEN0050kbn = False
                pblnfrmxxEN00V0kbn = False

                '@引継処理ﾌﾗｸﾞの初期化
                plngfrmxxCM00S0Kbn = 0

                '@起動ﾌﾗｸﾞを戻す
                pblnFormLoad = True

                Exit Sub
            End If


            '@★ 引継処理ﾌﾗｸﾞの戻り値により処理分岐 ★
            Select Case plngfrmxxCM00S0Kbn

                '@〓 起動成功＆ﾒｰﾙ送信成功 〓
                Case CPlngNumTwo

                    '@*********************
                    '@　ﾜｰｸﾌﾛｰ要求ﾃﾞｰﾀ作成
                    '@*********************
                    ptypWorkFlow.strMsgVer = CMstrrep_registworkflowVer         'ﾒｯｾｰｼﾞVer

                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(CMstrFormName, CMstrCmdMailClick)

                    '@画面の使用禁止
                    Me.KeyPreview = False

                    '@【ﾜｰｸﾌﾛｰ登録】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnRepRegistWorkFlow_Ins(ptypWorkFlow)

                    '@画面の使用禁止解除
                    Me.KeyPreview = True

                    '@通信結果判定
                    If lblnAns = False Then
                        '@結果：異常の場合

                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmdMailClick)
                        Exit Sub
                    End If

                    '@画面の使用禁止
                    Me.KeyPreview = False

                    '@【ﾒｰﾙ送信】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnGuidSendMessage_Sel(ptypSendMessageList)

                    '@画面の使用禁止解除
                    Me.KeyPreview = True

                    '@通信結果判定
                    If lblnAns = True Then
                        '@結果：正常の場合

                        '@表示ﾒｯｾｰｼﾞ変換
                        lstrMsg = pubstrMsgReplace_Set(CPstrMsgInf004S)
                        '@"<TRM4SI>$$メールの送信を受け付けました。"
                        Call pubVsfInfo_Disp(lstrMsg)

                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrCmdMailClick)

                        '@★ 起動区分により処理分岐 ★
                        Select Case plngLoadClass

                            '@〓 "1:故障修理記録" 〓
                            Case CPlngNumOne

                                '@画面の再描画
                                lblFromDate0.Text = Format$(Now, CPstrDateTimeYMDHM)  '確認依頼日(現在日時をｾｯﾄ)
                                lblFromEmpName0.Text = ptypWorkFlow.strFromEmpName    '確認依頼元作業者名

                                '@確認依頼先ｸﾞﾘｯﾄﾞの設定
                                '@確認依頼先作業者が1件以上存在するか
                                If ptypWorkFlow.lngEmpListCnt > 0 Then

                                    vsfToEmpName0.Visible = True                     'ｸﾞﾘｯﾄﾞを表示
                                    vsfToEmpName0.Rows.Count = ptypWorkFlow.lngEmpListCnt  '行数を設定
                                    vsfToEmpName0.Cols.Count = 1                           '列数を設定

                                    '@確認依頼先名称をｾｯﾄ
                                    For llngCnt = 0 To ptypWorkFlow.lngEmpListCnt -1
                                        vsfToEmpName0.SetData(llngCnt, CMlngvsfToEmpName, ptypWorkFlow.typEmpList(llngCnt).strToEmpName)
                                    Next llngCnt
                                End If

                            '@〓 "2:保全記録" 〓
                            Case CPlngNumTwo

                                '@画面の再描画
                                lblFromDate1.Text = Format$(Now, CPstrDateTimeYMDHM)  '確認依頼日(現在日時をｾｯﾄ)
                                lblFromEmpName1.Text = ptypWorkFlow.strFromEmpName    '確認依頼元作業者名

                                '@確認依頼先ｸﾞﾘｯﾄﾞの設定
                                '@確認依頼先作業者が1件以上存在するか
                                If ptypWorkFlow.lngEmpListCnt > 0 Then

                                    vsfToEmpName1.Visible = True                     'ｸﾞﾘｯﾄﾞを表示
                                    vsfToEmpName1.Rows.Count = ptypWorkFlow.lngEmpListCnt  '行数を設定
                                    vsfToEmpName1.Cols.Count = 1                           '列数を設定

                                    '@確認依頼先名称をｾｯﾄ
                                    For llngCnt = 0 To ptypWorkFlow.lngEmpListCnt -1
                                        vsfToEmpName1.SetData(llngCnt, CMlngvsfToEmpName, ptypWorkFlow.typEmpList(llngCnt).strToEmpName)
                                    Next llngCnt
                                End If

                        End Select
                    End If


                    '@〓 以下の場合 〓
                    '@ ①ﾒｰﾙ送信画面起動失敗
                    '@ ②画面起動成功だがﾒｰﾙ送信画面で確定せずに閉じた
                    '@ ③その他
                Case Else

                    '@処理なし

            End Select

            '@引継起動ﾌﾗｸﾞの初期化
            pblnfrmxxCM00Z0kbn = False
            pblnfrmxxEN01Z0kbn = False
            pblnfrmxxEN0050kbn = False
            pblnfrmxxEN00V0kbn = False

            '@引継処理ﾌﾗｸﾞの初期化
            plngfrmxxCM00S0Kbn = 0

            '@起動ﾌﾗｸﾞを戻す
            pblnFormLoad = True

            Exit Sub

        Catch ex As Exception

            '@画面の使用禁止解除
            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMail_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdApprove_Click
    '機　能：承認ﾎﾞﾀﾝ　Click＆押下時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/02/06 (Tue) 20:10:37 N.Kojima
    '更新日：2008/02/12 (Tue) 11:15:30 N.Kojima
    '備　考：★★ 全Tabで共通のｺﾝﾄﾛｰﾙｲﾍﾞﾝﾄ
    '　　　：2007/03/23 (Fri) 12:40:39 N.Kojima     入力項目(ｻｲﾝ欄＆修理完了日時)追加に伴い、処理追加。(案件№01830)
    '　　　：2008/02/12 (Tue) 11:15:30 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub cmdApprove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdApprove.Click

        Dim lblnAns As Boolean      '結果格納
        Dim lstrEditTime As String       '更新日時
        Dim lstrFunctionID As String       '機能ID
        Dim lstrActionID As String       'ｱｸｼｮﾝID
        Dim lstrEmpID As String       '作業者ID
        Dim lstrEmpName As String       '作業者名
        Dim lstrSBID As String       'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim lblnDateChkAns As Boolean      '日付ﾁｪｯｸ結果格納用

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の条件の場合は処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If


            '@★ 起動区分により処理分岐 ★
            Select Case plngLoadClass

                '@〓 "1:故障修理記録" 〓
                Case CPlngNumOne

                    '@=======================
                    '@　故障修理記録関連　必須項目入力ﾁｪｯｸ処理
                    '@=======================
                    lblnDateChkAns = prvRepairInputDataChk_Proc(CMstrCmdApproveClick)


                '@〓 "2:保全記録" 〓
                Case CPlngNumTwo

                    '@=======================
                    '@　保全記録関連　必須項目入力ﾁｪｯｸ処理
                    '@=======================
                    lblnDateChkAns = prvPreserveInputDataChk_Proc(CMstrCmdApproveClick)

            End Select

            '@ﾁｪｯｸNGの場合は処理終了
            If lblnDateChkAns = False Then
                Exit Sub
            End If


            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　作業者ｺｰﾄﾞ入力(ﾊﾟｽﾜｰﾄﾞ付き)画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0020.Instance.ShowDialog(Me)
            frmxxCM0020.Instance = Nothing

            '@取消ﾎﾞﾀﾝによる戻りなら処理終了
            If pblnCancel = True Then
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdApproveClick)


            '@実行権限ﾁｪｯｸ用ﾃﾞｰﾀを格納
            lstrFunctionID = CPstrKeyEN01Z0             '機能ID: EN01Z0
            lstrActionID = CPstrApply                   'ｱｸｼｮﾝID：装置メンテナンス記録票承認
            lstrEmpID = pstrUserID                      'ﾕｰｻﾞｰID
            lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名
            lstrSBID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ

            '@画面の使用禁止
            Me.KeyPreview = False

            '@=======================
            '@　実行権限ﾁｪｯｸ処理
            '@=======================
            lblnAns = pubAuthority_Chk(lstrFunctionID, _
                                       lstrActionID, _
                                       lstrEmpID, _
                                       lstrEmpName, _
                                       lstrSBID)

            '@画面の使用禁止解除
            Me.KeyPreview = True

            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdApproveClick)

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, CPstrApply)
                '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                Exit Sub
            End If


            '@★ 起動区分により処理分岐 ★
            Select Case plngLoadClass

                '@〓 "1:故障修理記録" 〓
                Case CPlngNumOne

                    '@=======================
                    '@　故障修理記録関連　送信ﾃﾞｰﾀ作成処理
                    '@=======================
                    Call prvRepairRequestDataSet_Proc(CMstrCmdApproveClick)

                    '@画面の使用禁止
                    Me.KeyPreview = False

                    '@【故障修理記録票情報更新】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnRepChgRepairReport_Upd(mtypChgRepairInfoReq, _
                                                           lstrEditTime, _
                                                           vbNullString, _
                                                           CPstrTwo)

                    '@画面の使用禁止解除
                    Me.KeyPreview = True


                '@〓 "2:保全記録" 〓
                Case CPlngNumTwo

                    '@=======================
                    '@　保全記録関連　送信ﾃﾞｰﾀ作成処理
                    '@=======================
                    Call prvPreserveRequestDataSet_Proc(CMstrCmdApproveClick)

                    '@画面の使用禁止
                    Me.KeyPreview = False

                    '@【保全記録票情報更新】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnPreChgPreserveReport_Upd(mtypChgPreserveInfoReq, _
                                                             lstrEditTime, _
                                                             vbNullString, _
                                                             CPstrTwo)

                    '@画面の使用禁止解除
                    Me.KeyPreview = True

            End Select

            '@通信結果判定
            If lblnAns = False Then
                '@結果：異常の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdApproveClick)
                Exit Sub
            End If

            '@********************
            '@　通信後の共通処理
            '@********************
            '@編集ﾌﾗｸﾞの初期化する
            mblnEditFlag = False

            '@=======================
            '@　装置ﾒﾝﾃﾅﾝｽ記録票更新後処理
            '@=======================
            Call prvAfterReportUpdate_Proc(CMstrCmdApproveClick)


            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrCmdApproveClick)

            Exit Sub

        Catch ex As Exception

            '@画面の使用禁止解除
            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdApprove_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '関数名：prvFrmxxCM00Z0_Init
    '機　能：ﾒｲﾝﾌｫｰﾑ＆変数等の初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/01/29 (Mon) 15:46:40 N.Kojima
    '更新日：2008/02/12 (Tue) 16:15:51 N.Kojima
    '備　考：
    '　　　：2007/03/23 (Fri) 13:23:32 N.Kojima     入力項目(ｻｲﾝ欄＆修理完了日時)追加に伴い、処理追加。(案件№01830)
    '　　　：2008/02/12 (Tue) 16:15:51 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub prvFrmxxCM00Z0_Init()

        Dim ltypRepairInfoReq As RepairInfoReq        '故障修理記録票情報取得送信用構造体初期化用
        Dim ltypRepairInfoAns As RepairInfoAns        '故障修理記録票情報取得受信用構造体初期化用
        Dim ltypChgRepairInfoReq As RepairInfo           '故障修理記録票登録/更新送信用構造体初期化用
        Dim ltypPreserveInfoReq As PreserveInfoReq      '保全記録票情報取得送信用構造体初期化用
        Dim ltypPreserveInfoAns As PreserveInfoAns      '保全記録票情報取得受信用構造体初期化用
        Dim ltypChgPreserveInfoReq As PreserveInfo         '保全記録票登録/更新送信用構造体初期化用
        Dim llngCnt As Integer              '汎用ｶｳﾝﾀ

        Try

            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = CPstrSubFormCM00Z0

            '@*************************************
            '@　「故障 基本情報/現象」Tabの初期化
            '@*************************************

            '@ﾌﾚｰﾑを有効にする
            fraRepairBaseInfo.Enabled = True

            '@ﾗﾍﾞﾙの初期化
            lblRepairNo.Text = vbNullString                      '故障修理記録票№
            lblFindEmpName.Text = vbNullString                   '発見者名(起案者名)
            lblFindDeptName.Text = vbNullString                  '発見職場名
            lblRepairPreserver.Text = vbNullString               '保全実施者名
            lblRepairWpName.Text = vbNullString                  '装置名
            lblRepairStartDate.Text = vbNullString               '故障発生日時

            '@修理完了日時ｶﾚﾝﾀﾞｰｺﾝﾎﾞ&ﾏｽｸｴﾃﾞｨｯﾄﾎﾞｯｸｽの初期化
            calRepairEndDate.Value = CPstrNullDate                  '"____/__/__"
            medRepairEndTime.Text = CPstrNullTime                   '"__:__"

            With calRepairEndDate
                .CalendarHeight = CPlngMClHeight                    '高さ
                .CalendarWidth = CPlngMClWidth                      '幅
                .DayFont = New Font(.DayFont.FontFamily, CPlngMClFontSize, .DayFont.Style, .DayFont.Unit)           'ﾌｫﾝﾄｻｲｽﾞ
                .TitleFont = New Font(.TitleFont.FontFamily, CPlngMClTlFontSize, .TitleFont.Style, .TitleFont.Unit) 'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CPlngMClGridFontSize, .GridFont.Style, .GridFont.Unit)   'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
            End With

            '@ﾃｷｽﾄﾎﾞｯｸｽの初期化
            txtRepairName.Text = vbNullString                       '故障現象名
            txtRepairContents.Text = vbNullString                   '故障現象詳細


            '@*************************************
            '@　「故障 原因・対策/費用」Tabの初期化
            '@*************************************

            '@ﾌﾚｰﾑを活性化する
            fraRepairCauseInfo.Enabled = True

            '@ﾃｷｽﾄﾎﾞｯｸｽの初期化
            txtAnalysisContents.Text = vbNullString                 '調査/分析詳細
            txtCause.Text = vbNullString                            '原因詳細
            txtMeasure.Text = vbNullString                          '対策詳細


            '@*************************************
            '@　「保全 基本情報」Tabの初期化
            '@*************************************

            '@ﾌﾚｰﾑを有効にする
            fraPreserveBaseInfo.Enabled = True

            '@ﾗﾍﾞﾙの初期化
            lblPreserveNo.Text = vbNullString                    '保全記録票№
            lblPreserver.Text = vbNullString                     '保全実施者名
            lblPreserveWpName.Text = vbNullString                '装置名
            lblPreserveCategory.Text = vbNullString              '保全ｶﾃｺﾞﾘ
            lblPreserveStartDate.Text = vbNullString             '保全開始(予定)日時

            '@終了(予定)日時ｶﾚﾝﾀﾞｰｺﾝﾎﾞ&ﾏｽｸｴﾃﾞｨｯﾄﾎﾞｯｸｽの初期化
            calPreserveEndDate.Value = CPstrNullDate                '"____/__/__"
            medPreserveEndTime.Text = CPstrNullTime                 '"__:__"

            With calPreserveEndDate
                .CalendarHeight = CPlngMClHeight                    '高さ
                .CalendarWidth = CPlngMClWidth                      '幅
                .DayFont = New Font(.DayFont.FontFamily, CPlngMClFontSize, .DayFont.Style, .DayFont.Unit)           'ﾌｫﾝﾄｻｲｽﾞ
                .TitleFont = New Font(.TitleFont.FontFamily, CPlngMClTlFontSize, .TitleFont.Style, .TitleFont.Unit) 'ﾀｲﾄﾙﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CPlngMClGridFontSize, .GridFont.Style, .GridFont.Unit)   'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
            End With

            '@ﾃｷｽﾄﾎﾞｯｸｽの初期化
            txtPreserveComment.Text = vbNullString                  'ｺﾒﾝﾄ


            '@*************************************
            '@　「保全 項目・内容・目的/費用」Tabの初期化
            '@*************************************

            '@ﾌﾚｰﾑを有効にする
            fraPreserveItemInfo.Enabled = True

            '@ﾗﾍﾞﾙの初期化
            lblPreserveCategory2.Text = vbNullString             '保全ｶﾃｺﾞﾘ

            '@ﾃｷｽﾄﾎﾞｯｸｽの初期化
            txtPreserveItem.Text = vbNullString                     '実施項目
            txtPreserveContents.Text = vbNullString                 '実施内容
            txtPreservePurpose.Text = vbNullString                  '実施目的/理由


            '@*************************************
            '@　　　　各Tab共通項目の初期化
            '@*************************************

            For llngCnt = 0 To 1

                '@ﾍｯﾀﾞｰ情報ﾗﾍﾞﾙの初期化
                lblUpdateArray(llngCnt).Text = vbNullString           '更新日
                lblUpdateNameArray(llngCnt).Text = vbNullString       '更新者
                lblFromDateArray(llngCnt).Text = vbNullString         '確認依頼日
                lblFromEmpNameArray(llngCnt).Text = vbNullString      '確認依頼元

                '@担当者(確認依頼先)ｸﾞﾘｯﾄﾞの初期化
                With vsfToEmpNameArray(llngCnt)
                    .Clear                                          '内容ｸﾘｱ
                    .Rows.Count = 0                                       '行=0
                    .Cols.Count = 0                                       '列=0
                    .Visible = False                                '非表示
                End With

                '@現在日時取得ﾎﾞﾀﾝの初期化
                cmdNowDateArray(llngCnt).Enabled = False                 '現在日時取得ﾎﾞﾀﾝ

                '@ｵﾌﾟｼｮﾝﾎﾞﾀﾝの初期化
                optCopeDivisionArray(llngCnt).Checked = False              '自主保全/ﾒｰｶｰ保全

                txtWorkCostArray(llngCnt).Text = 0                       '作業費用
                txtWorkCostArray(llngCnt).NumFormat = CPstrDateFormatKanma
                txtPartCostArray(llngCnt).Text = 0                       '部品費用
                txtPartCostArray(llngCnt).NumFormat = CPstrDateFormatKanma
            Next llngCnt

            '@ｻｲﾝ欄の初期化
            For llngCnt = 0 To 9
                lblSignDateArray(llngCnt).Text = vbNullString         '表示ﾗﾍﾞﾙ
                lblSignNameArray(llngCnt).Text = vbNullString
                cmdCancelArray(llngCnt).Enabled = False                  '取消ﾎﾞﾀﾝ
            Next llngCnt

            '@上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ、下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝの初期化
            For llngCnt = 0 To 7
                cmdUPArray(llngCnt).Enabled = False                      '▲ｽｸﾛｰﾙﾎﾞﾀﾝ
                cmdDownArray(llngCnt).Enabled = False                    '▼ｽｸﾛｰﾙﾎﾞﾀﾝ
            Next llngCnt

            'NSYS コメント欄の初期化
            For llngCnt = 0 To 8
                If llngCnt  = 0 Then
                    lblLengthCountArray(llngCnt).Text = pubstrMsgReplace_Set(CPstrCommentLength, 0, CMlngMaxRepairNameByte)
                Else
                    lblLengthCountArray(llngCnt).Text = pubstrMsgReplace_Set(CPstrCommentLength, 0, CPlngLotCommentsMaxByte)
                End If
            Next

            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(共通)
            cmdApprove.Enabled = False                              '承認ﾎﾞﾀﾝ
            cmdMail.Enabled = False                                 '確認依頼ﾎﾞﾀﾝ
            cmdDispose.Enabled = False                              '処置ﾎﾞﾀﾝ
            cmdSave.Enabled = False                                 '一時保存ﾎﾞﾀﾝ

            '@変更判定用に変更前の修理完了日時/保全終了(予定)日時(年月日、時間)を退避
            mstrOldRepairEndDate = calRepairEndDate.Value           '修理完了日時(年月日)
            mstrOldRepairEndTime = medRepairEndTime.Text            '修理完了日時(時間)
            mstrOldPreserveEndDate = calPreserveEndDate.Value       '終了(予定)日時(年月日)
            mstrOldPreserveEndTime = medPreserveEndTime.Text        '終了(予定)日時(時間)

            '@構造体の初期化
            mtypRepairInfoReq = ltypRepairInfoReq                   '故障修理記録票情報取得要求構造体
            mtypRepairInfoAns = ltypRepairInfoAns                   '故障修理記録票情報取得応答構造体
            mtypChgRepairInfoReq = ltypChgRepairInfoReq             '故障修理記録票登録/更新要求構造体
            mtypPreserveInfoReq = ltypPreserveInfoReq               '保全記録票情報取得要求構造体
            mtypPreserveInfoAns = ltypPreserveInfoAns               '保全記録票情報取得応答構造体
            mtypChgPreserveInfoReq = ltypChgPreserveInfoReq         '保全記録票登録/更新要求構造体

            '@ﾓｼﾞｭｰﾙ変数の初期化
            mblnEditFlag = False                                    '編集ﾌﾗｸﾞ
            mblnOptionEditFlag = False                              'ｵﾌﾟｼｮﾝﾎﾞﾀﾝ処理制御ﾌﾗｸﾞ
            mblnRepairNameEditFlag = False                          '故障現象編集ﾌﾗｸﾞ
            mblnRepairAnalysisEditFlag = False                      '調査/分析編集ﾌﾗｸﾞ
            mblnRepairCauseEditFlag = False                         '原因編集ﾌﾗｸﾞ
            mblnRepairMeasureEditFlag = False                       '対策編集ﾌﾗｸﾞ
            mblnPreserveItemEditFlag = False                        '実施項目編集ﾌﾗｸﾞ
            mblnPreserveContentsEditFlag = False                    '実施内容編集ﾌﾗｸﾞ
            mblnPreservePurposeEditFlag = False                     '実施目的/理由編集ﾌﾗｸﾞ
            mstrOldCopeDivision = vbNullString                      '変更前対応区分
            mstrOldWorkCost = vbNullString                          '変更前作業費用
            mstrOldPartCost = vbNullString                          '変更前部品費用

            '@「閉じる」ﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxCM00Z0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvTabRepairBaseInfo_Disp
    '機　能：「故障 基本情報/現象」Tab　情報ｾｯﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/02/01 (Thu) 17:23:08 N.Kojima
    '更新日：2008/02/12 (Tue) 16:17:01 N.Kojima
    '備　考：
    '　　　：2007/03/23 (Fri) 13:54:14 N.Kojima     手動起票機能＆ｻｲﾝ機能追加に伴い、処理追加。(案件№01830)
    '　　　：2008/02/12 (Tue) 16:17:01 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub prvTabRepairBaseInfo_Disp()

        Dim llngCnt As Integer          '汎用ｶｳﾝﾀ

        Try

            '@本Tabのﾌﾚｰﾑを活性化する
            fraRepairBaseInfo.Enabled = True

            '@取得情報をｺﾝﾄﾛｰﾙへｾｯﾄする
            With mtypRepairInfoAns

                '@*********************
                '@　ﾍｯﾀﾞｰ情報
                '@*********************
                '@更新日(㍉秒を削除、年月日時分ﾌｫｰﾏｯﾄで)
                lblUpdate0.Text = prvFormatDate(Strings.Left(.strEditTime, CMlngTimeFormat16), CPstrDateTimeYMDHM)
                '@更新者
                lblUpdateName0.Text = .strEmpName
                '@確認依頼日(㍉秒を削除、年月日時分ﾌｫｰﾏｯﾄで)
                lblFromDate0.Text = prvFormatDate(Strings.Left(.strEntryTime, CMlngTimeFormat16), CPstrDateTimeYMDHM)
                '@確認依頼元
                lblFromEmpName0.Text = .strFromEmpName

                'NSYS 行未選択状態にする
                vsfToEmpName0.Row = -1

                '@確認依頼先
                '@確認依頼先作業者ﾃﾞｰﾀが1件以上存在するか
                If .lngEmpListCnt > 0 Then

                    vsfToEmpName0.Visible = True          '表示
                    vsfToEmpName0.Rows.Count = .lngEmpListCnt   '行数設定
                    vsfToEmpName0.Cols.Count = 1                '列数設定

                    '@確認依頼先名称をｾｯﾄ
                    For llngCnt = 0 To .lngEmpListCnt -1
                        vsfToEmpName0.SetData(llngCnt, CMlngvsfToEmpName, .typEmpList(llngCnt).strEmpName)
                    Next llngCnt
                Else
                    '@0件の場合

                    vsfToEmpName0.Clear               '内容ｸﾘｱ
                    vsfToEmpName0.Rows.Count = 0            '行=0
                    vsfToEmpName0.Cols.Count = 0            '列=0
                    vsfToEmpName0.Visible = False     '非表示
                End If


                '@*********************
                '@　基本情報
                '@*********************
                lblRepairNo.Text = .strRepairNo                  '発行№
                lblFindEmpName.Text = .strFindEmpName            '発見者名
                lblFindDeptName.Text = .strFindDeptName          '発見職場
                lblRepairPreserver.Text = .strPreserveEmpName    '保全実施者
                lblRepairWpName.Text = .strWpName                '装置名

                '@故障発生日時
                lblRepairStartDate.Text = prvFormatDate(.strRepairStartDate, CPstrDateTimeYMDHM)

                '@修理完了日時がNULL以外か
                If .strRepairEndDate <> vbNullString Then

                    calRepairEndDate.Value = prvFormatDate(.strRepairEndDate, CPstrDateTimeYMD)   '修理完了日時(年月日)
                    medRepairEndTime.Text = prvFormatDate(.strRepairEndDate, CPstrTimeFormatHM)   '修理完了日時(時間)

                    '@変更判定用に変更前修理完了日時(年月日、時間)を退避
                    mstrOldRepairEndDate = calRepairEndDate.Value   '修理完了日時(年月日)
                    mstrOldRepairEndTime = medRepairEndTime.Text    '修理完了日時(時間)
                End If

                '@起票区分が"0:手動起票"か
                If .strEntryClass = CPstrZero Then
                    '@"0:手動起票"の場合

                    calRepairEndDate.Enabled = True                 '修理完了日時(年月日)を有効にする
                    calRepairEndDate.BackColor = vbWhite            'ﾊﾞｯｸｶﾗｰは白
                    medRepairEndTime.Enabled = True                 '修理完了日時(時間)を有効にする
                    medRepairEndTime.BackColor = vbWhite            'ﾊﾞｯｸｶﾗｰは白

                    '@現在日時取得ﾎﾞﾀﾝを有効にする
                    cmdNowDate0.Enabled = True
                Else
                    '@"1:自動起票orNULL"の場合

                    pic1.Enabled = False
                    calRepairEndDate.BackColor = ColorTranslator.FromWin32(CMlngGlayColor)    'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    medRepairEndTime.BackColor = ColorTranslator.FromWin32(CMlngGlayColor)    'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ

                    '@現在日時取得ﾎﾞﾀﾝを無効にする
                    cmdNowDate0.Enabled = False
                End If

                '@*********************
                '@　故障内容/現象
                '@*********************
                txtRepairName.Text = .strRepairName             '故障現象名
                txtRepairContents.Text = .strRepairContents     '故障現象詳細

                '@故障現象ｻｲﾝ欄
                lblSignDate0.Text = prvFormatDate(.strRepairNameSignDate, CPstrDateTimeYMD)     'ｻｲﾝ日
                lblSignName0.Text = prvFormatDate(.strRepairNameSignEmpName, CPstrDateTimeYMD)  'ｻｲﾝ者氏名
                '@ｻｲﾝされているか
                If lblSignDate0.Text <> vbNullString Then
                    '@故障内容/現象ｻｲﾝ欄の取消ﾎﾞﾀﾝを有効にする
                    cmdCancel0.Enabled = True
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvTabRepairBaseInfo_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvTabRepairCauseInfo_Disp
    '機　能：「故障 原因・対策/費用」Tab　情報ｾｯﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 10:26:40 N.Kojima
    '更新日：2008/02/12 (Tue) 16:29:48 N.Kojima
    '備　考：
    '　　　：2007/03/23 (Fri) 13:54:14 N.Kojima     手動起票機能＆ｻｲﾝ機能追加に伴い、処理追加。(案件№01830)
    '　　　：2008/02/12 (Tue) 16:29:48 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub prvTabRepairCauseInfo_Disp()

        Try

            '@本Tabのﾌﾚｰﾑを活性化する
            fraRepairCauseInfo.Enabled = True

            '@取得情報をｺﾝﾄﾛｰﾙへｾｯﾄする
            With mtypRepairInfoAns

                '@*********************
                '@　調査/分析詳細
                '@*********************
                txtAnalysisContents.Text = .strRepairAnalysisContents       '調査/分析詳細

                '@調査/分析詳細ｻｲﾝ欄
                lblSignDate1.Text = prvFormatDate(.strRepairAnalysisSignDate, CPstrDateTimeYMD)      'ｻｲﾝ日
                lblSignName1.Text = prvFormatDate(.strRepairAnalysisSignEmpName, CPstrDateTimeYMD)   'ｻｲﾝ者氏名
                '@ｻｲﾝされているか
                If lblSignDate1.Text <> vbNullString Then
                    '@調査/分析詳細ｻｲﾝ欄の取消ﾎﾞﾀﾝを有効にする
                    cmdCancel1.Enabled = True
                End If


                '@*********************
                '@　原因詳細
                '@*********************
                txtCause.Text = .strRepairCauseContents                     '原因詳細

                '@原因詳細ｻｲﾝ欄
                lblSignDate2.Text = prvFormatDate(.strRepairCauseSignDate, CPstrDateTimeYMD)         'ｻｲﾝ日
                lblSignName2.Text = prvFormatDate(.strRepairCauseSignEmpName, CPstrDateTimeYMD)      'ｻｲﾝ者氏名
                '@ｻｲﾝされているか
                If lblSignDate2.Text <> vbNullString Then
                    '@原因詳細ｻｲﾝ欄の取消ﾎﾞﾀﾝを有効にする
                    cmdCancel2.Enabled = True
                End If


                '@*********************
                '@　対策詳細
                '@*********************
                txtMeasure.Text = .strRepairMeasureContents                 '対策詳細

                '@対策詳細ｻｲﾝ欄
                lblSignDate3.Text = prvFormatDate(.strRepairMeasureSignDate, CPstrDateTimeYMD)       'ｻｲﾝ日
                lblSignName3.Text = prvFormatDate(.strRepairMeasureSignEmpName, CPstrDateTimeYMD)    'ｻｲﾝ者氏名
                '@ｻｲﾝされているか
                If lblSignDate3.Text <> vbNullString Then
                    '@対策詳細ｻｲﾝ欄の取消ﾎﾞﾀﾝを有効にする
                    cmdCancel3.Enabled = True
                End If


                '@*********************
                '@　費用実績
                '@*********************
                '@対応区分が"1:自主保全"か
                If .strCopeDivision = CPstrOne Or .strCopeDivision = vbNullString Then

                    '@"1:自主保全"の場合
                    mblnOptionEditFlag = True               '"True:ｼｽﾃﾑでの変更"を設定
                    optCopeDivision0.Checked = True         '自主保全にﾁｪｯｸを付ける
                    optCopeDivision1.Checked = False        'ﾒｰｶｰ保全はﾁｪｯｸなし
                    mblnOptionEditFlag = False              '初期化
                    mstrOldCopeDivision = CPstrOne          '"1:自主保全"をｾｯﾄ
                Else
                    '@"2:ﾒｰｶｰ保全"の場合
                    mblnOptionEditFlag = True               '"True:ｼｽﾃﾑでの変更"を設定
                    optCopeDivision0.Checked = False        '自主保全はﾁｪｯｸなし
                    optCopeDivision1.Checked = True         'ﾒｰｶｰ保全にﾁｪｯｸを付ける
                    mblnOptionEditFlag = False              '初期化
                    mstrOldCopeDivision = CPstrTwo          '"2:ﾒｰｶｰ保全"をｾｯﾄ
                End If

                '@作業費用がNULLか
                If .strWorkCost = vbNullString Then
                    txtWorkCost0.Text = CPlngNumZero                                          '作業費用
                Else
                    txtWorkCost0.Text = .strWorkCost                                          '作業費用
                    txtWorkCost0.Text = prvFormatNum(txtWorkCost0.Text, CPstrDateFormatKanma)
                End If
                '@作業費用退避変数に退避
                mstrOldWorkCost = txtWorkCost0.Text

                '@部品費用がNULLか
                If .strPartCost = vbNullString Then
                    txtPartCost0.Text = CPlngNumZero                                          '部品費用
                Else
                    txtPartCost0.Text = .strPartCost                                          '部品費用
                    txtPartCost0.Text = prvFormatNum(txtPartCost0.Text, CPstrDateFormatKanma)
                End If
                '@部品費用退避変数に退避
                mstrOldPartCost = txtPartCost0.Text

                '@*********************
                '@　確認
                '@*********************
                '@保全担当ｻｲﾝ欄
                lblSignDate4.Text = prvFormatDate(.strPreserveSignDate, CPstrDateTimeYMD)            'ｻｲﾝ日
                lblSignName4.Text = prvFormatDate(.strPreserveSignEmpName, CPstrDateTimeYMD)         'ｻｲﾝ者氏名
                '@ｻｲﾝされているか
                If lblSignDate4.Text <> vbNullString Then
                    '@保全担当ｻｲﾝ欄の取消ﾎﾞﾀﾝを有効にする
                    cmdCancel4.Enabled = True
                End If

                '@保全ﾘｰﾀﾞｰｻｲﾝ欄
                lblSignDate5.Text = prvFormatDate(.strPreserveLeaderSignDate, CPstrDateTimeYMD)      'ｻｲﾝ日
                lblSignName5.Text = prvFormatDate(.strPreserveLeaderSignEmpName, CPstrDateTimeYMD)   'ｻｲﾝ者氏名
                '@ｻｲﾝされているか
                If lblSignDate5.Text <> vbNullString Then
                    '@保全ﾘｰﾀﾞｰｻｲﾝ欄の取消ﾎﾞﾀﾝを有効にする
                    cmdCancel5.Enabled = True
                End If

                '@作業長ｻｲﾝ欄
                lblSignDate6.Text = prvFormatDate(.strProductLeaderSignDate, CPstrDateTimeYMD)       'ｻｲﾝ日
                lblSignName6.Text = prvFormatDate(.strProductLeaderSignEmpName, CPstrDateTimeYMD)    'ｻｲﾝ者氏名
                '@ｻｲﾝされているか
                If lblSignDate6.Text <> vbNullString Then
                    '@作業長ｻｲﾝ欄の取消ﾎﾞﾀﾝを有効にする
                    cmdCancel6.Enabled = True
                End If

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvTabRepairCauseInfo_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2008/02/12 (Tue) 16:47:53 N.Kojima **************************************************
    '関数名：prvTabPreserveBaseInfo_Disp
    '機　能：「保全 基本情報」Tab　情報ｾｯﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/02/12 (Tue) 16:48:33 N.Kojima
    '更新日：2008/02/12 (Tue) 16:48:33
    '備　考：
    Private Sub prvTabPreserveBaseInfo_Disp()

        Dim llngCnt As Integer          '汎用ｶｳﾝﾀ

        Try

            '@本Tabのﾌﾚｰﾑを活性化する
            fraPreserveBaseInfo.Enabled = True

            '@取得情報をｺﾝﾄﾛｰﾙへｾｯﾄする
            With mtypPreserveInfoAns

                '@*********************
                '@　ﾍｯﾀﾞｰ情報
                '@*********************
                '@更新日(㍉秒を削除、年月日時分ﾌｫｰﾏｯﾄで)
                lblUpdate1.Text = prvFormatDate(Strings.Left(.strEditTime, CMlngTimeFormat16), CPstrDateTimeYMDHM)
                '@更新者
                lblUpdateName1.Text = .strEmpName
                '@確認依頼日(㍉秒を削除、年月日時分ﾌｫｰﾏｯﾄで)
                lblFromDate1.Text = prvFormatDate(Strings.Left(.strEntryTime, CMlngTimeFormat16), CPstrDateTimeYMDHM)
                '@確認依頼元
                lblFromEmpName1.Text = .strFromEmpName

                'NSYS 行未選択状態にする
                vsfToEmpName1.Row = -1

                '@確認依頼先
                '@確認依頼先作業者ﾃﾞｰﾀが1件以上存在するか
                If .lngEmpListCnt > 0 Then

                    vsfToEmpName1.Visible = True          '表示
                    vsfToEmpName1.Rows.Count = .lngEmpListCnt   '行数設定
                    vsfToEmpName1.Cols.Count = 1                '列数設定

                    '@確認依頼先名称をｾｯﾄ
                    For llngCnt = 0 To .lngEmpListCnt -1
                        vsfToEmpName1.SetData(llngCnt, CMlngvsfToEmpName, .typEmpList(llngCnt).strEmpName)
                    Next llngCnt
                Else
                    '@0件の場合

                    vsfToEmpName1.Clear                   '内容ｸﾘｱ
                    vsfToEmpName1.Rows.Count = 0                '行=0
                    vsfToEmpName1.Cols.Count = 0                '列=0
                    vsfToEmpName1.Visible = False         '非表示
                End If


                '@*********************
                '@　保全　基本情報
                '@*********************
                lblPreserveNo.Text = .strPreserveNo          '発行№
                lblPreserver.Text = .strPreserveEmpName      '保全実施者
                lblPreserveWpName.Text = .strWpName          '装置名

                '@保全ｶﾃｺﾞﾘ
                '@★ 保全ｶﾃｺﾞﾘにより処理分岐 ★
                Select Case .strPreserveCategory

                    '@〓 "1:予防保全" 〓
                    Case CPstrOne

                        lblPreserveCategory.Text = CMstrPreserveCategoryYobou       '予防保全

                    '@〓 "2:改良/改善保全" 〓
                    Case CPstrTwo

                        lblPreserveCategory.Text = CMstrPreserveCategoryKaizen      '改良/改善保全

                    '@〓 "3:ﾙｰﾁﾝﾒﾝﾃ" 〓
                    Case CPstrThree

                        lblPreserveCategory.Text = CMstrPreserveCategoryRMainte     'ﾙｰﾁﾝﾒﾝﾃ

                End Select

                '@開始(予定)日時
                lblPreserveStartDate.Text = prvFormatDate(.strPreserveStartDate, CPstrDateTimeYMDHM)

                '@終了(予定)日時がNULL以外か
                If .strPreserveEndDate <> vbNullString Then

                    calPreserveEndDate.Value = prvFormatDate(.strPreserveEndDate, CPstrDateTimeYMD)   '終了(予定)日時(年月日)
                    medPreserveEndTime.Text = prvFormatDate(.strPreserveEndDate, CPstrTimeFormatHM)   '終了(予定)日時(時間)

                    '@変更判定用に変更前終了(予定)日時(年月日、時間)を退避
                    mstrOldPreserveEndDate = calPreserveEndDate.Value   '終了(予定)日時(年月日)
                    mstrOldPreserveEndTime = medPreserveEndTime.Text    '終了(予定)日時(時間)
                End If

                '@起票区分が"0:手動起票"か
                If .strEntryClass = CPstrZero Then
                    '@"0:手動起票"の場合

                    calPreserveEndDate.Enabled = True                   '終了(予定)日時(年月日)を有効にする
                    calPreserveEndDate.BackColor = vbWhite              'ﾊﾞｯｸｶﾗｰは白
                    medPreserveEndTime.Enabled = True                   '終了(予定)日時(時間)を有効にする
                    medPreserveEndTime.BackColor = vbWhite              'ﾊﾞｯｸｶﾗｰは白

                    '@現在日時取得ﾎﾞﾀﾝを有効にする
                    cmdNowDate1.Enabled = True
                Else
                    '@"1:自動起票orNULL"の場合

                    pic4.Enabled = False
                    calPreserveEndDate.BackColor = ColorTranslator.FromWin32(CMlngGlayColor)       'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    medPreserveEndTime.BackColor = ColorTranslator.FromWin32(CMlngGlayColor)       'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ

                    '@現在日時取得ﾎﾞﾀﾝを無効にする
                    cmdNowDate1.Enabled = False
                End If

                '@*********************
                '@　ｺﾒﾝﾄ
                '@*********************
                txtPreserveComment.Text = .strPreserveComments  'ｺﾒﾝﾄ

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvTabPreserveBaseInfo_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/02/12 (Tue) 16:47:53 N.Kojima **************************************************

    '@↓2008/02/12 (Tue) 16:47:46 N.Kojima **************************************************
    '関数名：prvTabPreserveItemInfo_Disp
    '機　能：「保全 項目・内容・目的/費用」Tab　情報ｾｯﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/02/12 (Tue) 16:49:10 N.Kojima
    '更新日：2008/02/12 (Tue) 16:49:10
    '備　考：
    Private Sub prvTabPreserveItemInfo_Disp()

        Try

            '@本Tabのﾌﾚｰﾑを活性化する
            fraPreserveItemInfo.Enabled = True

            '@取得情報をｺﾝﾄﾛｰﾙへｾｯﾄする
            With mtypPreserveInfoAns

                '@保全ｶﾃｺﾞﾘ
                '@★ 保全ｶﾃｺﾞﾘにより処理分岐 ★
                Select Case .strPreserveCategory

                    '@〓 "1:予防保全" 〓
                    Case CPstrOne

                        lblPreserveCategory2.Text = CMstrPreserveCategoryYobou       '予防保全

                    '@〓 "2:改良/改善保全" 〓
                    Case CPstrTwo

                        lblPreserveCategory2.Text = CMstrPreserveCategoryKaizen      '改良/改善保全

                    '@〓 "3:ﾙｰﾁﾝﾒﾝﾃ" 〓
                    Case CPstrThree

                        lblPreserveCategory2.Text = CMstrPreserveCategoryRMainte     'ﾙｰﾁﾝﾒﾝﾃ

                End Select

                '@*********************
                '@　実施項目
                '@*********************
                txtPreserveItem.Text = .strPreserveItem             '実施項目

                '@*********************
                '@　実施内容
                '@*********************
                txtPreserveContents.Text = .strPreserveContents     '実施内容

                '@*********************
                '@　実施目的/理由
                '@*********************
                txtPreservePurpose.Text = .strPreservePurpose       '実施目的/理由

                '@*********************
                '@　費用実績
                '@*********************
                '@対応区分が"1:自主保全"か
                If .strCopeDivision = CPstrOne Or .strCopeDivision = vbNullString Then
                    '@"1:自主保全"の場合
                    mblnOptionEditFlag = True               '"True:ｼｽﾃﾑでの変更"を設定
                    optCopeDivision2.Checked = True         '自主保全にﾁｪｯｸを付ける
                    optCopeDivision3.Checked = False        'ﾒｰｶｰ保全はﾁｪｯｸなし
                    mblnOptionEditFlag = False              '初期化
                    mstrOldCopeDivision = CPstrOne          '"1:自主保全"をｾｯﾄ
                Else
                    '@"2:ﾒｰｶｰ保全"の場合
                    mblnOptionEditFlag = True               '"True:ｼｽﾃﾑでの変更"を設定
                    optCopeDivision2.Checked = False        '自主保全はﾁｪｯｸなし
                    optCopeDivision3.Checked = True         'ﾒｰｶｰ保全にﾁｪｯｸを付ける
                    mblnOptionEditFlag = False              '初期化
                    mstrOldCopeDivision = CPstrTwo          '"2:ﾒｰｶｰ保全"をｾｯﾄ
                End If

                '@作業費用がNULLか
                If .strWorkCost = vbNullString Then
                    txtWorkCost1.Text = CPlngNumZero                                          '作業費用
                Else
                    txtWorkCost1.Text = .strWorkCost                                          '作業費用
                    txtWorkCost1.Text = prvFormatNum(txtWorkCost1.Text, CPstrDateFormatKanma)
                End If
                '@作業費用退避変数に退避
                mstrOldWorkCost = txtWorkCost1.Text

                '@部品費用がNULLか
                If .strPartCost = vbNullString Then
                    txtPartCost1.Text = CPlngNumZero                                          '部品費用
                Else
                    txtPartCost1.Text = .strPartCost                                          '部品費用
                    txtPartCost1.Text = prvFormatNum(txtPartCost1.Text, CPstrDateFormatKanma)
                End If
                '@部品費用退避変数に退避
                mstrOldPartCost = txtPartCost1.Text


                '@*********************
                '@　確認
                '@*********************
                '@保全担当ｻｲﾝ欄
                lblSignDate7.Text = prvFormatDate(.strPreserveSignDate, CPstrDateTimeYMD)            'ｻｲﾝ日
                lblSignName7.Text = prvFormatDate(.strPreserveSignEmpName, CPstrDateTimeYMD)         'ｻｲﾝ者氏名
                '@ｻｲﾝされているか
                If lblSignDate7.Text <> vbNullString Then
                    '@保全担当ｻｲﾝ欄の取消ﾎﾞﾀﾝを有効にする
                    cmdCancel7.Enabled = True
                End If

                '@保全ﾘｰﾀﾞｰｻｲﾝ欄
                lblSignDate8.Text = prvFormatDate(.strPreserveLeaderSignDate, CPstrDateTimeYMD)      'ｻｲﾝ日
                lblSignName8.Text = prvFormatDate(.strPreserveLeaderSignEmpName, CPstrDateTimeYMD)   'ｻｲﾝ者氏名
                '@ｻｲﾝされているか
                If lblSignDate8.Text <> vbNullString Then
                    '@保全ﾘｰﾀﾞｰｻｲﾝ欄の取消ﾎﾞﾀﾝを有効にする
                    cmdCancel8.Enabled = True
                End If

                '@作業長ｻｲﾝ欄
                lblSignDate9.Text = prvFormatDate(.strProductLeaderSignDate, CPstrDateTimeYMD)       'ｻｲﾝ日
                lblSignName9.Text = prvFormatDate(.strProductLeaderSignEmpName, CPstrDateTimeYMD)    'ｻｲﾝ者氏名
                '@ｻｲﾝされているか
                If lblSignDate9.Text <> vbNullString Then
                    '@作業長ｻｲﾝ欄の取消ﾎﾞﾀﾝを有効にする
                    cmdCancel9.Enabled = True
                End If

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvTabPreserveItemInfo_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/02/12 (Tue) 16:47:46 N.Kojima **************************************************

    '関数名：prvTabRepairObjectControl_Proc
    '機　能：故障修理記録関連ｺﾝﾄﾛｰﾙ制御処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/02/02 (Fri) 14:29:34 N.Kojima
    '更新日：2008/02/12 (Tue) 13:35:53 N.Kojima
    '備　考：
    '　　　：2007/03/23 (Fri) 17:08:02 N.Kojima     現象名選択ﾎﾞﾀﾝ、ｻｲﾝ関連ﾎﾞﾀﾝ、修理完了/保全終了(予定)日時ｶﾚﾝﾀﾞｰｺﾝﾎﾞの制御を追加。(案件№01830)
    '　　　：2008/02/12 (Tue) 13:35:53 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Sub prvTabRepairObjectControl_Proc()

        Dim llngCnt As Integer      '汎用ｶｳﾝﾀ

        Try

            '@保全系のTabをﾛｯｸする
            tab2.Enabled = False        '保全 基本情報
            tab3.Enabled = False        '保全 項目・内容・目的/費用

            '@ｺﾝﾄﾛｰﾙのﾛｯｸ処理
            '@★ 故障修理記録票の状態によって処理を分岐 ★
            Select Case mtypRepairInfoAns.strRepairStatus

                '@〓 "0:未処置" or "1:処置済み" 〓
                Case CPstrZero, CPstrOne

                    '@各種ﾃｷｽﾄ制御
                    txtRepairName.Enabled = True                '故障現象名
                    txtRepairContents.Enabled = True            '故障現象詳細
                    txtAnalysisContents.Enabled = True          '調査/分析詳細
                    txtCause.Enabled = True                     '原因詳細
                    txtMeasure.Enabled = True                   '対策詳細

                    '@表示Tab制御
                    tabMainteSheet.SelectedIndex = CMlngRepairBaseInfoTabIndex

                    'NSYS .NET版ではコーディングしなくても選択タブ以外の項目は非活性になるため不要
                    ''@表示しているTab以外はﾌｫｰｶｽを移動しないように制御する
                    'fraRepairBaseInfo.Enabled = True            '故障 基本情報/現象Tabﾌﾚｰﾑ
                    'fraRepairCauseInfo.Enabled = False          '故障 原因・対策/費用Tabﾌﾚｰﾑ
                    'fraPreserveBaseInfo.Enabled = False         '保全 基本情報Tabﾌﾚｰﾑ
                    'fraPreserveItemInfo.Enabled = False         '保全 項目・内容・目的/費用Tabﾌﾚｰﾑ

                    '@各種ﾎﾞﾀﾝ制御
                    cmdMail.Enabled = True                      '確認依頼ﾎﾞﾀﾝ
                    cmdSave.Enabled = True                      '一時保存ﾎﾞﾀﾝ
                    cmdDispose.Enabled = True                   '処置ﾎﾞﾀﾝ

                    '@故障修理記録票状態が"0:未処置"or"2:承認済"か
                    If mtypRepairInfoAns.strRepairStatus = CPstrZero Or _
                        mtypRepairInfoAns.strRepairStatus = CPstrTwo Then

                        '@"0:未処置"or"2:承認済"の場合は、承認ﾎﾞﾀﾝを無効にする
                        cmdApprove.Enabled = False
                    Else
                        '@"1:処置済み"の場合は、承認ﾎﾞﾀﾝを有効にする
                        cmdApprove.Enabled = True
                    End If

                    '@初期ﾌｫｰｶｽｾｯﾄ
                    '@修理完了日時ｶﾚﾝﾀﾞｰとﾋﾟｸﾁｬｰﾎﾞｯｸｽが有効か
                    If calRepairEndDate.Enabled = True And pic1.Enabled = True Then
                        Call pubSetFocus(calRepairEndDate)      '修理完了日時(年月日)
                    Else
                        Call pubSetFocus(txtRepairName)         '故障現象名
                    End If


                '@〓 2：承認済み、3：廃棄 〓
                Case CPstrTwo, CPstrThree
                    '@各種ｺﾝﾄﾛｰﾙの制御を行なう

                    '@故障現象名
                    txtRepairName.Locked = True
                    txtRepairName.BackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)             'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    txtRepairName.GotBackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)          'ﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    txtRepairName.TabStop = False                           'Tabでﾌｫｰｶｽを取得しない

                    '@故障現象詳細
                    txtRepairContents.Locked = True
                    txtRepairContents.BackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)         'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    txtRepairContents.GotBackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)      'ﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    txtRepairContents.TabStop = False                       'Tabでﾌｫｰｶｽを取得しない

                    '@調査/分析詳細
                    txtAnalysisContents.Locked = True
                    txtAnalysisContents.BackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)       'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    txtAnalysisContents.GotBackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)    'ﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    txtAnalysisContents.TabStop = False                     'Tabでﾌｫｰｶｽを取得しない

                    '@原因詳細
                    txtCause.Locked = True
                    txtCause.BackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)                  'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    txtCause.GotBackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)               'ﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    txtCause.TabStop = False                                'Tabでﾌｫｰｶｽを取得しない

                    '@対策詳細
                    txtMeasure.Locked = True
                    txtMeasure.BackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)                'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    txtMeasure.GotBackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)             'ﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    txtMeasure.TabStop = False                              'Tabでﾌｫｰｶｽを取得しない

                    '@修理完了日時ｶﾚﾝﾀﾞｰ＆時刻ﾏｽｸｴﾃﾞｨｯﾄﾎﾞｯｸｽ
                    pic1.Enabled = False
                    calRepairEndDate.BackColor = ColorTranslator.FromWin32(CMlngGlayColor)             'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    medRepairEndTime.BackColor = ColorTranslator.FromWin32(CMlngGlayColor)             'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ

                    '@現在日時取得ﾎﾞﾀﾝ
                    cmdNowDate0.Enabled = False                           '無効

                    '@対応区分、作業費用、部品費用制御
                    pic2.Enabled = False                                    '自主保全、ﾒｰｶｰ保全は無効
                    'optCopeDivision0.BackColor = ColorTranslator.FromWin32(CMlngGlayColor)           'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    'optCopeDivision1.BackColor =ColorTranslator.FromWin32(CMlngGlayColor)            'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    pic3.Enabled = False                                    '作業費用、部品費用は無効
                    txtWorkCost0.BackColor = ColorTranslator.FromWin32(CMlngGlayColor)               'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    txtPartCost0.BackColor = ColorTranslator.FromWin32(CMlngGlayColor)               'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ

                    '@ｻｲﾝ欄(故障修理記録票関連Tab)
                    For llngCnt = 0 To 6
                        cmdSignArray(llngCnt).Enabled = False                    'ｻｲﾝﾎﾞﾀﾝ
                        cmdCancelArray(llngCnt).Enabled = False                  '取消ﾎﾞﾀﾝ
                    Next llngCnt

                    '@各種ﾎﾞﾀﾝ制御
                    cmdRepairNameSelect.Enabled = False                     '現象名選択ﾎﾞﾀﾝ
                    cmdApprove.Enabled = False                              '承認ﾎﾞﾀﾝ
                    cmdMail.Enabled = True                                  '確認依頼ﾎﾞﾀﾝ
                    cmdSave.Enabled = False                                 '一時保存ﾎﾞﾀﾝ
                    cmdDispose.Enabled = False                              '処置ﾎﾞﾀﾝ

                    '@表示Tab制御
                    tabMainteSheet.SelectedIndex = CMlngRepairBaseInfoTabIndex

                    'NSYS .NET版ではコーディングしなくても選択タブ以外の項目は非活性になるため不要
                    ''@表示しているTab以外はﾌｫｰｶｽを移動しないように制御する
                    'fraRepairBaseInfo.Enabled = True                        '故障 基本情報/現象Tabﾌﾚｰﾑ
                    'fraRepairCauseInfo.Enabled = False                      '故障 原因・対策/費用
                    'fraPreserveBaseInfo.Enabled = False                     '保全 基本情報Tabﾌﾚｰﾑ
                    'fraPreserveItemInfo.Enabled = False                     '保全 項目・内容・目的/費用Tabﾌﾚｰﾑ

                    '@初期ﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(tabMainteSheet)                        'Tab

            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvTabRepairObjectControl_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2008/02/12 (Tue) 17:12:00 N.Kojima **************************************************
    '関数名：prvTabPreserveObjectControl_Proc
    '機　能：保全記録関連ｺﾝﾄﾛｰﾙ制御処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/02/12 (Tue) 13:35:53 N.Kojima
    '更新日：2008/02/12 (Tue) 13:35:53
    '備　考：
    Private Sub prvTabPreserveObjectControl_Proc()

        Dim llngCnt As Integer      '汎用ｶｳﾝﾀ

        Try

            '@故障修理系のTabをﾛｯｸする
            tab0.Enabled = False          '故障 基本情報/現象
            tab1.Enabled = False         '故障 原因・対策/費用

            '@ｺﾝﾄﾛｰﾙのﾛｯｸ処理
            '@★ 保全記録票の状態によって処理を分岐 ★
            Select Case mtypPreserveInfoAns.strPreserveStatus

                '@〓 "0:未処置" or "1:処置済み" 〓
                Case CPstrZero, CPstrOne

                    '@各種ﾃｷｽﾄ制御
                    txtPreserveComment.Enabled = True           'ｺﾒﾝﾄ
                    txtPreserveItem.Enabled = True              '実施項目
                    txtPreserveContents.Enabled = True          '実施内容
                    txtPreservePurpose.Enabled = True           '実施目的/理由

                    '@表示Tab制御
                    tabMainteSheet.SelectedIndex = CMlngPreserveBaseInfoTabIndex

                    'NSYS .NET版ではコーディングしなくても選択タブ以外の項目は非活性になるため不要
                    ''@表示しているTab以外はﾌｫｰｶｽを移動しないように制御する
                    'fraRepairBaseInfo.Enabled = False           '故障 基本情報/現象Tabﾌﾚｰﾑ
                    'fraRepairCauseInfo.Enabled = False          '故障 原因・対策/費用Tabﾌﾚｰﾑ
                    'fraPreserveBaseInfo.Enabled = True          '保全 基本情報Tabﾌﾚｰﾑ
                    'fraPreserveItemInfo.Enabled = False         '保全 項目・内容・目的/費用Tabﾌﾚｰﾑ

                    '@各種ﾎﾞﾀﾝ制御
                    cmdMail.Enabled = True                      '確認依頼ﾎﾞﾀﾝ
                    cmdSave.Enabled = True                      '一時保存ﾎﾞﾀﾝ
                    cmdDispose.Enabled = True                   '処置ﾎﾞﾀﾝ

                    '@保全記録票状態が"0:未処置"or"2:承認済"か
                    If mtypPreserveInfoAns.strPreserveStatus = CPstrZero Or _
                        mtypPreserveInfoAns.strPreserveStatus = CPstrTwo Then

                        '@"0:未処置"or"2:承認済"の場合は、承認ﾎﾞﾀﾝを無効にする
                        cmdApprove.Enabled = False
                    Else
                        '@"1:処置済み"の場合は、処置ﾎﾞﾀﾝを無効にし、承認ﾎﾞﾀﾝを有効にする
                        cmdDispose.Enabled = False
                        cmdApprove.Enabled = True
                    End If

                    '@初期ﾌｫｰｶｽｾｯﾄ
                    '@終了(予定)日時ｶﾚﾝﾀﾞｰとﾋﾟｸﾁｬｰﾎﾞｯｸｽが有効か
                    If calPreserveEndDate.Enabled = True And pic4.Enabled = True Then
                        Call pubSetFocus(calPreserveEndDate)    '終了(予定)日時(年月日)
                    Else
                        Call pubSetFocus(txtPreserveComment)    'ｺﾒﾝﾄ
                    End If


                '@〓 2：承認済み、3：廃棄 〓
                Case CPstrTwo, CPstrThree
                    '@各種ｺﾝﾄﾛｰﾙの制御を行なう

                    '@ｺﾒﾝﾄ
                    txtPreserveComment.Locked = True
                    txtPreserveComment.BackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)        'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    txtPreserveComment.GotBackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)     'ﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    txtPreserveComment.TabStop = False                      'Tabでﾌｫｰｶｽを取得しない

                    '@実施項目
                    txtPreserveItem.Locked = True
                    txtPreserveItem.BackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)           'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    txtPreserveItem.GotBackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)        'ﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    txtPreserveItem.TabStop = False                         'Tabでﾌｫｰｶｽを取得しない

                    '@実施内容
                    txtPreserveContents.Locked = True
                    txtPreserveContents.BackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)       'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    txtPreserveContents.GotBackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)    'ﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    txtPreserveContents.TabStop = False                     'Tabでﾌｫｰｶｽを取得しない

                    '@実施目的/理由
                    txtPreservePurpose.Locked = True
                    txtPreservePurpose.BackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)        'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    txtPreservePurpose.GotBackColor = ColorTranslator.FromWin32(CPlngTxtLockColor)     'ﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    txtPreservePurpose.TabStop = False                      'Tabでﾌｫｰｶｽを取得しない

                    '@終了(予定)日時ｶﾚﾝﾀﾞｰ＆時刻ﾏｽｸｴﾃﾞｨｯﾄﾎﾞｯｸｽ
                    pic4.Enabled = False
                    calPreserveEndDate.BackColor = ColorTranslator.FromWin32(CMlngGlayColor)           'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    medPreserveEndTime.BackColor = ColorTranslator.FromWin32(CMlngGlayColor)           'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ

                    '@現在日時取得ﾎﾞﾀﾝ
                    cmdNowDate1.Enabled = False                           '無効

                    '@対応区分、作業費用、部品費用制御
                    pic5.Enabled = False                                    '自主保全、ﾒｰｶｰ保全は無効
                    'optCopeDivision2.BackColor = ColorTranslator.FromWin32(CMlngGlayColor)           'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    'optCopeDivision3.BackColor = ColorTranslator.FromWin32(CMlngGlayColor)           'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    pic6.Enabled = False                                    '作業費用、部品費用は無効
                    txtWorkCost1.BackColor = ColorTranslator.FromWin32(CMlngGlayColor)               'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ
                    txtPartCost1.BackColor = ColorTranslator.FromWin32(CMlngGlayColor)               'ﾊﾞｯｸｶﾗｰはｸﾞﾚｰ

                    '@ｻｲﾝ欄(保全記録票関連Tab)
                    For llngCnt = 7 To 9
                        cmdSignArray(llngCnt).Enabled = False                    'ｻｲﾝﾎﾞﾀﾝ
                        cmdCancelArray(llngCnt).Enabled = False                  '取消ﾎﾞﾀﾝ
                    Next llngCnt

                    '@各種ﾎﾞﾀﾝ制御
                    cmdApprove.Enabled = False                              '承認ﾎﾞﾀﾝ
                    cmdMail.Enabled = True                                  '確認依頼ﾎﾞﾀﾝ
                    cmdSave.Enabled = False                                 '一時保存ﾎﾞﾀﾝ
                    cmdDispose.Enabled = False                              '処置ﾎﾞﾀﾝ

                    '@表示Tab制御
                    tabMainteSheet.SelectedIndex = CMlngPreserveBaseInfoTabIndex

                    'NSYS .NET版ではコーディングしなくても選択タブ以外の項目は非活性になるため不要
                    ''@表示しているTab以外はﾌｫｰｶｽを移動しないように制御する
                    'fraRepairBaseInfo.Enabled = False                       '故障 基本情報/現象Tabﾌﾚｰﾑ
                    'fraRepairCauseInfo.Enabled = False                      '故障 原因・対策/費用Tabﾌﾚｰﾑ
                    'fraPreserveBaseInfo.Enabled = True                      '保全 基本情報Tabﾌﾚｰﾑ
                    'fraPreserveItemInfo.Enabled = False                     '保全 項目・内容・目的/費用Tabﾌﾚｰﾑ

                    '@初期ﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(tabMainteSheet)                        'Tab

            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvTabPreserveObjectControl_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/02/12 (Tue) 17:12:00 N.Kojima **************************************************

    '関数名：prvRepairInputDataChk_Proc
    '機　能：故障修理記録関連　入力ﾃﾞｰﾀﾁｪｯｸ処理
    '引　数：lstrCallEvent  ：呼び元のｲﾍﾞﾝﾄ
    '戻り値：True：ﾁｪｯｸOK、False：ﾁｪｯｸNG
    '作成日：2007/03/23 (Fri) 17:08:02 N.Kojima
    '更新日：2008/02/12 (Tue) 12:40:23 N.Kojima
    '備　考：
    '　　　：2008/02/12 (Tue) 12:40:23 N.Kojima     計画保全対応&ｿｰｽ整備。(案件№02332)
    Private Function prvRepairInputDataChk_Proc(ByVal lstrCallEvent As String) As Boolean

        Dim lblnErrFlag As Boolean          'ｴﾗｰ判定ﾌﾗｸﾞ(True:ｴﾗｰあり、False:ｴﾗｰなし)
        Dim lstrErrItem As String           'ｴﾗｰ項目格納用
        Dim lctlErrItem As Control          'ｴﾗｰｺﾝﾄﾛｰﾙ格納用

        Try

            '@戻り値の初期化
            prvRepairInputDataChk_Proc = False

            '@呼び元の処理が"一時保存:cmdSave_Click"以外か
            If lstrCallEvent <> CMstrCmdSaveClick Then

                '@故障現象名がNULLか
                If txtRepairName.Text = vbNullString Then

                    '@各種ｴﾗｰ判定ｱｲﾃﾑをｾｯﾄ
                    lstrErrItem = lblRepairNameTitle.Text        'ｴﾗｰ項目    ："故障現象名"
                    lctlErrItem = txtRepairName                 'ｴﾗｰｺﾝﾄﾛｰﾙ  ：txtRepairName
                    lblnErrFlag = True                              'ｴﾗｰ判定ﾌﾗｸﾞ："True:ｴﾗｰあり"
                End If

                '@原因詳細がNULLか
                If txtCause.Text = vbNullString And lblnErrFlag = False Then

                    '@各種ｴﾗｰ判定ｱｲﾃﾑをｾｯﾄ
                    lstrErrItem = lblCauseTitle.Text             'ｴﾗｰ項目    ："原因詳細"
                    lctlErrItem = txtCause                      'ｴﾗｰｺﾝﾄﾛｰﾙ  ：txtCause
                    lblnErrFlag = True                              'ｴﾗｰ判定ﾌﾗｸﾞ："True:ｴﾗｰあり"
                End If

                '@対策詳細がNULLか
                If txtMeasure.Text = vbNullString And lblnErrFlag = False Then

                    '@各種ｴﾗｰ判定ｱｲﾃﾑをｾｯﾄ
                    lstrErrItem = lblMeasureTitle.Text           'ｴﾗｰ項目    ："対策詳細"
                    lctlErrItem = txtMeasure                    'ｴﾗｰｺﾝﾄﾛｰﾙ  ：txtMeasure
                    lblnErrFlag = True                              'ｴﾗｰ判定ﾌﾗｸﾞ："True:ｴﾗｰあり"
                End If

                '@ｴﾗｰ項目があったか
                If lblnErrFlag = True Then

                    '@ﾒｯｾｰｼﾞを表示して空欄をｾｯﾄする
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0099, lstrErrItem)
                    '@"<TRM99W>$$%1が入力されていません。%1を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@ｴﾗｰ項目が故障現象名か
                    If lstrErrItem = lblRepairNameTitle.Text Then
                        '@Tabを選択し、ﾌﾚｰﾑを有効にする
                        tabMainteSheet.SelectedIndex = CMlngRepairBaseInfoTabIndex        '故障 基本情報/現象Tab
                        'NSYS .NET版ではコーディングしなくても選択タブ以外の項目は非活性になるため不要
                        'fraRepairBaseInfo.Enabled = True                        '故障 基本情報/現象ﾌﾚｰﾑ
                    Else
                        '@Tabを選択し、ﾌﾚｰﾑを有効にする
                        tabMainteSheet.SelectedIndex = CMlngRepairCauseInfoTabIndex     '故障 原因・対策/費用Tab
                        'NSYS .NET版ではコーディングしなくても選択タブ以外の項目は非活性になるため不要
                        'fraRepairCauseInfo.Enabled = True                     '故障 原因・対策/費用ﾌﾚｰﾑ
                    End If

                    '@ｴﾗｰｺﾝﾄﾛｰﾙが有効か
                    If lctlErrItem.Enabled = True Then
                        '@ｴﾗｰｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(lctlErrItem)
                    End If

                    Exit Function
                End If

            End If

            '@修理完了日時(年月日、時間)がNULL(____/__/__、__:__)か
            If calRepairEndDate.Value = CPstrNullDate And _
                medRepairEndTime.Text = CPstrNullTime Then
                '@両方NULLの場合はﾁｪｯｸしない

                '@戻り値に"True:ﾁｪｯｸOK"をｾｯﾄ
                prvRepairInputDataChk_Proc = True
                Exit Function
            End If

            '@起票区分が"0:手動起票"か
            If mtypRepairInfoAns.strEntryClass = CPstrZero Then

                '@修理完了日時(年月日)がNULL(____/__/__)で、時間が入力されているか
                If calRepairEndDate.Value = CPstrNullDate And _
                    medRepairEndTime.Text <> CPstrNullTime Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0095, lblRepairEndDateTitle.Text)
                    '@"<TRM95W>$$[%1]を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@修理完了日時(年月日)へﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(calRepairEndDate)
                    Exit Function
                Else
                    '@修理完了日時(年月日)がNULL(____/__/__)以外、または時間がNULL(__:__)の場合

                    '@修理完了日時(年月日)が正しい日付かﾁｪｯｸ
                    If pubblnYearRange_Chk(calRepairEndDate.Value) = False Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0095, lblRepairEndDateTitle.Text)
                        '@"<TRM95W>$$[%1]を入力してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@修理完了日時(年月日)へﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(calRepairEndDate)
                        Exit Function
                    End If
                End If

                '@修理完了日時(時間)がNULL(__:__)で、かつ日付が入力されているか
                If calRepairEndDate.Value <> CPstrNullDate And _
                    medRepairEndTime.Text = CPstrNullTime Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0095, lblRepairEndDateTitle.Text)
                    '@"<TRM95W>$$[%1]を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@修理完了日時(時間)へﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(medRepairEndTime)
                    Exit Function
                Else
                    '@修理完了日時(時間)がNULL(__:__)以外、または日付がNULL(____/__/__)の場合

                    '@修理完了日時(時間)が正しい日付かﾁｪｯｸ
                    If IsDate(medRepairEndTime.Text) = False Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0095, lblRepairEndDateTitle.Text)
                        '@"<TRM95W>$$[%1]を入力してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@修理完了日時(時間)へﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(medRepairEndTime)
                        Exit Function
                    End If
                End If
            End If

            '@戻り値に"True:ﾁｪｯｸOK"をｾｯﾄ
            prvRepairInputDataChk_Proc = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvRepairInputDataChk_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '@↓2008/03/06 (Thu) 11:32:41 N.Kojima **************************************************
    '関数名：prvPreserveInputDataChk_Proc
    '機　能：保全記録関連　入力ﾃﾞｰﾀﾁｪｯｸ処理
    '引　数：lstrCallEvent  ：呼び元のｲﾍﾞﾝﾄ
    '戻り値：True：ﾁｪｯｸOK、False：ﾁｪｯｸNG
    '作成日：2008/03/06 (Thu) 11:33:43 N.Kojima
    '更新日：2008/03/06 (Thu) 11:33:43
    '備　考：
    Private Function prvPreserveInputDataChk_Proc(ByVal lstrCallEvent As String) As Boolean

        Dim lblnErrFlag As Boolean          'ｴﾗｰ判定ﾌﾗｸﾞ(True:ｴﾗｰあり、False:ｴﾗｰなし)
        Dim lstrErrItem As String           'ｴﾗｰ項目格納用
        Dim lctlErrItem As Control          'ｴﾗｰｺﾝﾄﾛｰﾙ格納用

        Try

            '@戻り値の初期化
            prvPreserveInputDataChk_Proc = False

            '@ｴﾗｰ判定ﾌﾗｸﾞの初期化
            lblnErrFlag = False

            '@呼び元の処理が"一時保存:cmdSave_Click"以外か
            If lstrCallEvent <> CMstrCmdSaveClick Then

                '@実施項目がNULLか
                If txtPreserveItem.Text = vbNullString Then

                    '@各種ｴﾗｰ判定ｱｲﾃﾑをｾｯﾄ
                    lstrErrItem = lblPreserveItemTitle.Text      'ｴﾗｰ項目    ："実施項目"
                    lctlErrItem = txtPreserveItem               'ｴﾗｰｺﾝﾄﾛｰﾙ  ：txtPreserveItem
                    lblnErrFlag = True                              'ｴﾗｰ判定ﾌﾗｸﾞ："True:ｴﾗｰあり"
                End If

                '@保全ｶﾃｺﾞﾘが"3:ﾙｰﾁﾝﾒﾝﾃ"以外か
                If mtypPreserveInfoAns.strPreserveCategory <> CPstrThree Then

                    '@実施内容がNULLか
                    If txtPreserveContents.Text = vbNullString And _
                        lblnErrFlag = False Then

                        '@各種ｴﾗｰ判定ｱｲﾃﾑをｾｯﾄ
                        lstrErrItem = lblPreserveContentsTitle.Text      'ｴﾗｰ項目    ："実施内容"
                        lctlErrItem = txtPreserveContents               'ｴﾗｰｺﾝﾄﾛｰﾙ  ：txtPreserveContents
                        lblnErrFlag = True                                  'ｴﾗｰ判定ﾌﾗｸﾞ："True:ｴﾗｰあり"
                    End If

                    '@実施目的/理由がNULLか
                    If txtPreservePurpose.Text = vbNullString And _
                        lblnErrFlag = False Then

                        '@各種ｴﾗｰ判定ｱｲﾃﾑをｾｯﾄ
                        lstrErrItem = lblPreservePurposeTitle.Text       'ｴﾗｰ項目    ："実施目的/理由"
                        lctlErrItem = txtPreservePurpose                'ｴﾗｰｺﾝﾄﾛｰﾙ  ：txtPreservePurpose
                        lblnErrFlag = True                                  'ｴﾗｰ判定ﾌﾗｸﾞ："True:ｴﾗｰあり"
                    End If

                    '@呼び元の処理が"承認:cmdApprove_Click"か
                    If lstrCallEvent = CMstrCmdApproveClick Then

                        '@保全担当ｻｲﾝがNULLか
                        If lblSignName7.Text = vbNullString And _
                            lblnErrFlag = False Then

                            '@各種ｴﾗｰ判定ｱｲﾃﾑをｾｯﾄ
                            lstrErrItem = lblPreserverSignTitle.Text & cmdSign7.Text    'ｴﾗｰ項目    ："保全担当ｻｲﾝ"
                            lctlErrItem = cmdSign7                                        'ｴﾗｰｺﾝﾄﾛｰﾙ  ：cmdSign(7)
                            lblnErrFlag = True                                                  'ｴﾗｰ判定ﾌﾗｸﾞ："True:ｴﾗｰあり"
                        End If

                        '@保全ﾘｰﾀﾞｰｻｲﾝがNULLか
                        If lblSignName8.Text = vbNullString And _
                            lblnErrFlag = False Then

                            '@各種ｴﾗｰ判定ｱｲﾃﾑをｾｯﾄ
                            lstrErrItem = lblPreserveLeaderSignTitle.Text & cmdSign8.Text   'ｴﾗｰ項目    ："保全ﾘｰﾀﾞｰｻｲﾝ"
                            lctlErrItem = cmdSign8                                            'ｴﾗｰｺﾝﾄﾛｰﾙ  ：cmdSign(8)
                            lblnErrFlag = True                                                      'ｴﾗｰ判定ﾌﾗｸﾞ："True:ｴﾗｰあり"
                        End If

                        '@作業長ｻｲﾝがNULLか
                        If lblSignName9.Text = vbNullString And _
                            lblnErrFlag = False Then

                            '@各種ｴﾗｰ判定ｱｲﾃﾑをｾｯﾄ
                            lstrErrItem = lblProductLeaderSignTitle.Text & cmdSign9.Text    'ｴﾗｰ項目    ："作業長ｻｲﾝ"
                            lctlErrItem = cmdSign9                                            'ｴﾗｰｺﾝﾄﾛｰﾙ  ：cmdSign(9)
                            lblnErrFlag = True                                                      'ｴﾗｰ判定ﾌﾗｸﾞ："True:ｴﾗｰあり"
                        End If
                    End If
                End If

                '@ｴﾗｰ項目があったか
                If lblnErrFlag = True Then

                    '@ﾒｯｾｰｼﾞを表示して空欄をｾｯﾄする
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0099, lstrErrItem)
                    '@"<TRM99W>$$%1が入力されていません。%1を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@Tabを選択し、ﾌﾚｰﾑを有効にする
                    tabMainteSheet.SelectedIndex = CMlngPreserveItemInfoTabIndex      '保全 項目・内容・目的/費用Tab
                    fraPreserveItemInfo.Enabled = True                      '保全 項目・内容・目的/費用ﾌﾚｰﾑ

                    '@ｴﾗｰｺﾝﾄﾛｰﾙが有効か
                    If lctlErrItem.Enabled = True Then
                        '@ｴﾗｰｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(lctlErrItem)
                    End If

                    Exit Function
                End If

            End If

            '@終了(予定)日時(年月日、時間)がNULL(____/__/__、__:__)か
            If calPreserveEndDate.Value = CPstrNullDate And _
                medPreserveEndTime.Text = CPstrNullTime Then
                '@両方NULLの場合はﾁｪｯｸしない

                '@戻り値に"True:ﾁｪｯｸOK"をｾｯﾄ
                prvPreserveInputDataChk_Proc = True
                Exit Function
            End If

            '@起票区分が"0:手動起票"か
            If mtypPreserveInfoAns.strEntryClass = CPstrZero Then

                '@終了(予定)日時(年月日)がNULL(____/__/__)で、時間が入力されているか
                If calPreserveEndDate.Value = CPstrNullDate And _
                    medPreserveEndTime.Text <> CPstrNullTime Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0095, lblPreserveEndDateTitle.Text)
                    '@"<TRM95W>$$[%1]を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@終了(予定)日時(年月日)へﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(calPreserveEndDate)
                    Exit Function
                Else
                    '@終了(予定)日時(年月日)がNULL(____/__/__)以外、または時間がNULL(__:__)の場合

                    '@終了(予定)日時(年月日)が正しい日付かﾁｪｯｸ
                    If pubblnYearRange_Chk(calPreserveEndDate.Value) = False Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0095, lblPreserveEndDateTitle.Text)
                        '@"<TRM95W>$$[%1]を入力してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@終了(予定)日時(年月日)へﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(calPreserveEndDate)
                        Exit Function
                    End If
                End If

                '@終了(予定)日時(時間)がNULL(__:__)で、かつ日付が入力されているか
                If calPreserveEndDate.Value <> CPstrNullDate And _
                    medPreserveEndTime.Text = CPstrNullTime Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0095, lblPreserveEndDateTitle.Text)
                    '@"<TRM95W>$$[%1]を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@終了(予定)日時(時間)へﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(medPreserveEndTime)
                    Exit Function
                Else
                    '@終了(予定)日時(時間)がNULL(__:__)以外、または日付がNULL(____/__/__)の場合

                    '@終了(予定)日時(時間)が正しい日付かﾁｪｯｸ
                    If IsDate(medPreserveEndTime.Text) = False Then

                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0095, lblPreserveEndDateTitle.Text)
                        '@"<TRM95W>$$[%1]を入力してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                        '@終了(予定)日時(時間)へﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(medPreserveEndTime)
                        Exit Function
                    End If
                End If
            End If

            '@戻り値に"True:ﾁｪｯｸOK"をｾｯﾄ
            prvPreserveInputDataChk_Proc = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvPreserveInputDataChk_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function
    '@↑2008/03/06 (Thu) 11:32:41 N.Kojima **************************************************

    '@↓2008/03/06 (Thu) 11:32:41 N.Kojima **************************************************
    '関数名：prvRepairRequestDataSet_Proc
    '機　能：故障修理記録関連　送信ﾃﾞｰﾀｾｯﾄ処理
    '引　数：lstrCallEvent  ：呼び元のｲﾍﾞﾝﾄ
    '戻り値：なし
    '作成日：2008/03/06 (Thu) 11:33:43 N.Kojima
    '更新日：2008/03/06 (Thu) 11:33:43
    '備　考：
    Private Sub prvRepairRequestDataSet_Proc(ByVal lstrCallEvent As String)

        Dim ltypChgRepairInfoReq As RepairInfo               '故障修理記録関連送信用構造体初期化用

        Try

            '@****************
            '@　要求ﾃﾞｰﾀ作成
            '@****************
            '@構造体の初期化
            mtypChgRepairInfoReq = ltypChgRepairInfoReq

            With mtypChgRepairInfoReq

                .strSbID = pstrSBID                                     'ｼｽﾃﾑﾌﾞﾛｯｸID
                .strMsgVer = CMstrrep_chgrepairreportVer                'ﾒｯｾｰｼﾞVer
                .strEmpID = pstrUserID                                  '作業者ID(更新者ID)
                .strEmpName = pstrUserName                              '作業者名(更新者名)
                .strActionID = CPstrTwo                                 'ｱｸｼｮﾝID(2:更新)
                .strRepairNo = mtypRepairInfoAns.strRepairNo            '故障修理記録票№
                .strWpID = ptypRepairInfo.strWpID                       '装置ID
                .strRepairName = txtRepairName.Text                     '故障現象名
                .strRepairContents = txtRepairContents.Text             '故障現象詳細
                .strRepairAnalysisContents = txtAnalysisContents.Text   '調査/分析詳細
                .strRepairCauseContents = txtCause.Text                 '原因詳細
                .strRepairMeasureContents = txtMeasure.Text             '対策詳細

                '@★ 呼び元ｲﾍﾞﾝﾄにより処理分岐 ★
                Select Case lstrCallEvent

                    '@〓 "一時保存" 〓
                    Case CMstrCmdSaveClick

                        .strPreserveEmpID = mtypRepairInfoAns.strPreserveEmpID      '保全実施者ID
                        .strPreserveEmpName = mtypRepairInfoAns.strPreserveEmpName  '保全実施者名
                        .strApprovalEmpID = mtypRepairInfoAns.strApprovalEmpID      '承認者ID
                        .strApprovalEmpName = mtypRepairInfoAns.strApprovalEmpName  '承認者名
                        .strRepairStatus = mtypRepairInfoAns.strRepairStatus        '故障修理記録票状態(取得値を送信)

                    '@〓 "処置" 〓
                    Case CMstrCmdDisposeClick

                        .strPreserveEmpID = pstrUserID                              '保全実施者ID
                        .strPreserveEmpName = pstrUserName                          '保全実施者名
                        .strApprovalEmpID = vbNullString                            '承認者ID
                        .strApprovalEmpName = vbNullString                          '承認者名
                        .strRepairStatus = CPstrOne                                 '故障修理記録票状態(1:処置済みを送信)

                    '@〓 "承認" 〓
                    Case CMstrCmdApproveClick

                        .strPreserveEmpID = mtypRepairInfoAns.strPreserveEmpID      '保全実施者ID
                        .strPreserveEmpName = mtypRepairInfoAns.strPreserveEmpName  '保全実施者名
                        .strApprovalEmpID = pstrUserID                              '承認者ID
                        .strApprovalEmpName = pstrUserName                          '承認者名
                        .strRepairStatus = CPstrTwo                                 '故障修理記録票状態(2:承認済みを送信)

                End Select

                .strEditTime = mtypRepairInfoAns.strEditTime                        '更新日時

                .strRepairNameSignEmpID = mtypRepairInfoAns.strRepairNameSignEmpID                  '故障現象ｻｲﾝ者ID
                .strRepairNameSignEmpName = mtypRepairInfoAns.strRepairNameSignEmpName              '故障現象ｻｲﾝ者氏名
                .strRepairNameSignDate = mtypRepairInfoAns.strRepairNameSignDate                    '故障現象ｻｲﾝ日
                '@故障現象編集ﾌﾗｸﾞがTrue(変更あり)で、ｻｲﾝされていない場合
                If mblnRepairNameEditFlag = True And .strRepairNameSignEmpID = vbNullString Then
                    '@処置確定作業者情報で自動ｻｲﾝする
                    .strRepairNameSignEmpID = pstrUserID                            '故障現象ｻｲﾝ者ID
                    .strRepairNameSignEmpName = pstrUserName                        '故障現象ｻｲﾝ者氏名
                    .strRepairNameSignDate = Format$(Now, CPstrDateTimeYMD)         '故障現象ｻｲﾝ日
                End If

                .strRepairAnalysisSignEmpID = mtypRepairInfoAns.strRepairAnalysisSignEmpID          '故障原因調査/分析ｻｲﾝ者ID
                .strRepairAnalysisSignEmpName = mtypRepairInfoAns.strRepairAnalysisSignEmpName      '故障原因調査/分析ｻｲﾝ者氏名
                .strRepairAnalysisSignDate = mtypRepairInfoAns.strRepairAnalysisSignDate            '故障原因調査/分析ｻｲﾝ日
                '@調査/分析編集ﾌﾗｸﾞがTrue(変更あり)で、ｻｲﾝされていない場合
                If mblnRepairAnalysisEditFlag = True And .strRepairAnalysisSignEmpID = vbNullString Then
                    '@処置確定作業者情報で自動ｻｲﾝする
                    .strRepairAnalysisSignEmpID = pstrUserID                        '故障原因調査/分析ｻｲﾝ者ID
                    .strRepairAnalysisSignEmpName = pstrUserName                    '故障原因調査/分析ｻｲﾝ者氏名
                    .strRepairAnalysisSignDate = Format$(Now, CPstrDateTimeYMD)     '故障原因調査/分析ｻｲﾝ日
                End If

                .strRepairCauseSignEmpID = mtypRepairInfoAns.strRepairCauseSignEmpID                '故障原因ｻｲﾝ者ID
                .strRepairCauseSignEmpName = mtypRepairInfoAns.strRepairCauseSignEmpName            '故障原因ｻｲﾝ者氏名
                .strRepairCauseSignDate = mtypRepairInfoAns.strRepairCauseSignDate                  '故障原因ｻｲﾝ日
                '@原因編集ﾌﾗｸﾞがTrue(変更あり)で、ｻｲﾝされていない場合
                If mblnRepairCauseEditFlag = True And .strRepairCauseSignEmpID = vbNullString Then
                    '@処置確定作業者情報で自動ｻｲﾝする
                    .strRepairCauseSignEmpID = pstrUserID                           '故障原因ｻｲﾝ者ID
                    .strRepairCauseSignEmpName = pstrUserName                       '故障原因ｻｲﾝ者氏名
                    .strRepairCauseSignDate = Format$(Now, CPstrDateTimeYMD)        '故障原因ｻｲﾝ日
                End If

                .strRepairMeasureSignEmpID = mtypRepairInfoAns.strRepairMeasureSignEmpID            '故障対策ｻｲﾝ者ID
                .strRepairMeasureSignEmpName = mtypRepairInfoAns.strRepairMeasureSignEmpName        '故障対策ｻｲﾝ者氏名
                .strRepairMeasureSignDate = mtypRepairInfoAns.strRepairMeasureSignDate              '故障対策ｻｲﾝ日
                '@対策編集ﾌﾗｸﾞがTrue(変更あり)で、ｻｲﾝされていない場合
                If mblnRepairMeasureEditFlag = True And .strRepairMeasureSignEmpID = vbNullString Then
                    '@処置確定作業者情報で自動ｻｲﾝする
                    .strRepairMeasureSignEmpID = pstrUserID                         '故障対策ｻｲﾝ者ID
                    .strRepairMeasureSignEmpName = pstrUserName                     '故障対策ｻｲﾝ者氏名
                    .strRepairMeasureSignDate = Format$(Now, CPstrDateTimeYMD)      '故障対策ｻｲﾝ日
                End If

                '@"自主保全"にﾁｪｯｸされているか
                If optCopeDivision0.Checked = True Then
                    .strCopeDivision = CPstrOne             '1:自主保全
                Else
                    .strCopeDivision = CPstrTwo             '2:ﾒｰｶｰ保全
                End If
                .strWorkCost = prvFormatNum(txtWorkCost0.Text, CPstrNoKanmaFormat)     '作業費用
                .strPartCost = prvFormatNum(txtPartCost0.Text, CPstrNoKanmaFormat)     '部品費用

                .strPreserveSignEmpID = mtypRepairInfoAns.strPreserveSignEmpID                      '保全担当ｻｲﾝ者ID
                .strPreserveSignEmpName = mtypRepairInfoAns.strPreserveSignEmpName                  '保全担当ｻｲﾝ者氏名
                .strPreserveSignDate = mtypRepairInfoAns.strPreserveSignDate                        '保全担当ｻｲﾝ日
                .strPreserveLeaderSignEmpID = mtypRepairInfoAns.strPreserveLeaderSignEmpID          '保全ﾘｰﾀﾞｰｻｲﾝ者ID
                .strPreserveLeaderSignEmpName = mtypRepairInfoAns.strPreserveLeaderSignEmpName      '保全ﾘｰﾀﾞｰｻｲﾝ者氏名
                .strPreserveLeaderSignDate = mtypRepairInfoAns.strPreserveLeaderSignDate            '保全ﾘｰﾀﾞｰｻｲﾝ日
                .strProductLeaderSignEmpID = mtypRepairInfoAns.strProductLeaderSignEmpID            '作業長ｻｲﾝ者ID
                .strProductLeaderSignEmpName = mtypRepairInfoAns.strProductLeaderSignEmpName        '作業長ｻｲﾝ者氏名
                .strProductLeaderSignDate = mtypRepairInfoAns.strProductLeaderSignDate              '作業長ｻｲﾝ日

                '@起票区分が"0:手動起票"で、修理完了日時がNULL(____/__/__ and __:__)ではない場合
                If mtypRepairInfoAns.strEntryClass = CPstrZero And _
                    calRepairEndDate.Value <> CPstrNullDate And _
                    medRepairEndTime.Text <> CPstrNullTime Then

                    '@修理完了日時を格納
                    .strRepairEndDate = calRepairEndDate.Value & CPstrSpace & medRepairEndTime.Text
                End If
            End With


            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvRepairRequestDataSet_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/03/06 (Thu) 11:32:41 N.Kojima **************************************************

    '@↓2008/03/06 (Thu) 11:32:41 N.Kojima **************************************************
    '関数名：prvPreserveRequestDataSet_Proc
    '機　能：保全記録関連　送信ﾃﾞｰﾀｾｯﾄ処理
    '引　数：lstrCallEvent  ：呼び元のｲﾍﾞﾝﾄ
    '戻り値：なし
    '作成日：2008/03/06 (Thu) 11:33:43 N.Kojima
    '更新日：2008/03/06 (Thu) 11:33:43
    '備　考：
    Private Sub prvPreserveRequestDataSet_Proc(ByVal lstrCallEvent As String)

        Dim ltypChgPreserveInfoReq As PreserveInfo           '保全記録関連送信用構造体初期化用

        Try

            '@****************
            '@　要求ﾃﾞｰﾀ作成
            '@****************
            '@構造体の初期化
            mtypChgPreserveInfoReq = ltypChgPreserveInfoReq

            With mtypChgPreserveInfoReq

                .strSbID = pstrSBID                                     'ｼｽﾃﾑﾌﾞﾛｯｸID
                .strMsgVer = CMstrpre_chgpreservereportVer              'ﾒｯｾｰｼﾞVer
                .strEmpID = pstrUserID                                  '作業者ID(更新者ID)
                .strEmpName = pstrUserName                              '作業者名(更新者名)
                .strActionID = CPstrTwo                                 'ｱｸｼｮﾝID(2:更新)
                .strPreserveNo = mtypPreserveInfoAns.strPreserveNo      '保全記録票№
                .strWpID = ptypPreserveInfo.strWpID                     '装置ID
                .strCategoryID = mtypPreserveInfoAns.strCategoryID      'ｶﾃｺﾞﾘID
                .strUseId = mtypPreserveInfoAns.strCategoryID           'ｶﾃｺﾞﾘID
                .strPreserveCategory = mtypPreserveInfoAns.strPreserveCategory  '保全ｶﾃｺﾞﾘID
                .strPreserveComments = txtPreserveComment.Text          '停止ｺﾒﾝﾄ
                .strPreserveItem = txtPreserveItem.Text                 '実施項目
                .strPreserveContents = txtPreserveContents.Text         '実施内容
                .strPreservePurpose = txtPreservePurpose.Text           '実施目的/理由

                '@★ 呼び元ｲﾍﾞﾝﾄにより処理分岐 ★
                Select Case lstrCallEvent

                    '@〓 "一時保存" 〓
                    Case CMstrCmdSaveClick

                        .strPreserveEmpID = mtypPreserveInfoAns.strPreserveEmpID        '保全実施者ID
                        .strPreserveEmpName = mtypPreserveInfoAns.strPreserveEmpName    '保全実施者名
                        .strApprovalEmpID = mtypPreserveInfoAns.strApprovalEmpID        '承認者ID
                        .strApprovalEmpName = mtypPreserveInfoAns.strApprovalEmpName    '承認者名
                        .strPreserveStatus = mtypPreserveInfoAns.strPreserveStatus      '保全記録票状態(取得値を送信)

                    '@〓 "処置" 〓
                    Case CMstrCmdDisposeClick

                        .strPreserveEmpID = pstrUserID                                  '保全実施者ID
                        .strPreserveEmpName = pstrUserName                              '保全実施者名
                        .strApprovalEmpID = vbNullString                                '承認者ID
                        .strApprovalEmpName = vbNullString                              '承認者名
                        .strPreserveStatus = CPstrOne                                   '保全記録票状態(1:処置済みを送信)

                    '@〓 "承認" 〓
                    Case CMstrCmdApproveClick

                        .strPreserveEmpID = mtypPreserveInfoAns.strPreserveStatus       '保全実施者ID
                        .strPreserveEmpName = mtypPreserveInfoAns.strPreserveStatus     '保全実施者名
                        .strApprovalEmpID = pstrUserID                                  '承認者ID
                        .strApprovalEmpName = pstrUserName                              '承認者名
                        .strPreserveStatus = CPstrTwo                                   '保全記録票状態(2:承認済みを送信)

                End Select

                .strEditTime = mtypPreserveInfoAns.strEditTime          '更新日時

                '@"自主保全"にﾁｪｯｸされているか
                If optCopeDivision2.Checked = True Then
                    .strCopeDivision = CPstrOne             '1:自主保全
                Else
                    .strCopeDivision = CPstrTwo             '2:ﾒｰｶｰ保全
                End If
                .strWorkCost = prvFormatNum(txtWorkCost1.Text, CPstrNoKanmaFormat)     '作業費用
                .strPartCost = prvFormatNum(txtPartCost1.Text, CPstrNoKanmaFormat)     '部品費用

                .strPreserveSignEmpID = mtypPreserveInfoAns.strPreserveSignEmpID                    '保全担当ｻｲﾝ者ID
                .strPreserveSignEmpName = mtypPreserveInfoAns.strPreserveSignEmpName                '保全担当ｻｲﾝ者氏名
                .strPreserveSignDate = mtypPreserveInfoAns.strPreserveSignDate                      '保全担当ｻｲﾝ日
                .strPreserveLeaderSignEmpID = mtypPreserveInfoAns.strPreserveLeaderSignEmpID        '保全ﾘｰﾀﾞｰｻｲﾝ者ID
                .strPreserveLeaderSignEmpName = mtypPreserveInfoAns.strPreserveLeaderSignEmpName    '保全ﾘｰﾀﾞｰｻｲﾝ者氏名
                .strPreserveLeaderSignDate = mtypPreserveInfoAns.strPreserveLeaderSignDate          '保全ﾘｰﾀﾞｰｻｲﾝ日
                .strProductLeaderSignEmpID = mtypPreserveInfoAns.strProductLeaderSignEmpID          '作業長ｻｲﾝ者ID
                .strProductLeaderSignEmpName = mtypPreserveInfoAns.strProductLeaderSignEmpName      '作業長ｻｲﾝ者氏名
                .strProductLeaderSignDate = mtypPreserveInfoAns.strProductLeaderSignDate            '作業長ｻｲﾝ日

                '@起票区分が"0:手動起票"で、終了(予定)日時がNULL(____/__/__ and __:__)ではない場合
                If mtypPreserveInfoAns.strEntryClass = CPstrZero And _
                    calPreserveEndDate.Value <> CPstrNullDate And _
                    medPreserveEndTime.Text <> CPstrNullTime Then

                    '@終了(予定)日時を格納
                    .strPreserveEndDate = calPreserveEndDate.Value & CPstrSpace & medPreserveEndTime.Text
                End If
            End With


            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvPreserveRequestDataSet_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/03/06 (Thu) 11:32:41 N.Kojima **************************************************

    '@↓2008/03/06 (Thu) 11:32:41 N.Kojima **************************************************
    '関数名：prvAfterReportUpdate_Proc
    '機　能：装置ﾒﾝﾃﾅﾝｽ記録票更新後処理(情報の再取得、再設定)
    '引　数：lstrCallEvent  ：呼び元のｲﾍﾞﾝﾄ
    '戻り値：なし
    '作成日：2008/03/06 (Thu) 11:33:43 N.Kojima
    '更新日：2008/03/06 (Thu) 11:33:43
    '備　考：
    Private Sub prvAfterReportUpdate_Proc(ByVal lstrCallEvent As String)

        Dim ltypRepairInfoReq As RepairInfoReq        '故障修理記録情報取得要求格納構造体初期化用
        Dim ltypRepairInfoAns As RepairInfoAns        '故障修理記録情報取得応答格納構造体初期化用
        Dim ltypPreserveInfoReq As PreserveInfoReq      '保全記録情報取得要求格納構造体初期化用
        Dim ltypPreserveInfoAns As PreserveInfoAns      '保全記録情報取得応答格納構造体初期化用
        Dim lblnAns As Boolean              '通信結果格納用
        Dim llngCnt As Integer              '汎用ｶｳﾝﾀ

        Try


            '@★ 起動区分により処理分岐 ★
            Select Case plngLoadClass

                '@〓 "1:故障修理記録" 〓
                Case CPlngNumOne

                    '@"<TRM6PI>$$[故障修理記録票]を更新しました。発行№[%1] 装置名[%2]"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006P, _
                                                    CPstrMailSendTitleRepair, _
                                                    mtypChgRepairInfoReq.strRepairNo, _
                                                    lblRepairWpName.Text)
                    '@成功ﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)


                    '@*****************************
                    '@　情報の再取得(要求ﾃﾞｰﾀ作成)
                    '@*****************************
                    '@要求・応答構造体の初期化
                    mtypRepairInfoReq = ltypRepairInfoReq
                    mtypRepairInfoAns = ltypRepairInfoAns

                    With mtypRepairInfoReq
                        .strSbID = ptypRepairInfo.strSbID                   'ｼｽﾃﾑﾌﾞﾛｯｸID
                        .strMsgVer = CMstrrep_repairinfoVer                 'MsgVer
                        .strRepairNo = ptypRepairInfo.strRepairNo           '故障修理記録№
                        .strWpID = ptypRepairInfo.strWpID                   '装置ID
                        .strWpName = ptypRepairInfo.strWpName               '装置名(ErrMsg用)
                        .strEntryTime = ptypRepairInfo.strEntryTime         '登録日時(装置停止・ﾒﾝﾃ計画の起動の場合、"開始(予定)日時")
                    End With

                    '@画面の使用禁止
                    Me.KeyPreview = False

                    '@【故障修理記録票情報取得】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnRepRepairInfo_Sel(mtypRepairInfoReq, mtypRepairInfoAns)

                    '@画面の使用禁止解除
                    Me.KeyPreview = True

                    '@通信結果判定
                    If lblnAns = False Then
                        '@結果：異常の場合

                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, lstrCallEvent)
                        Exit Sub
                    End If

                    '@情報の再設定
                    lblUpdate0.Text = _
                        prvFormatDate(Strings.Left(mtypRepairInfoAns.strEditTime, CMlngTimeFormat16), CPstrDateTimeYMDHM)    '更新日
                    lblUpdateName0.Text = pstrUserName                             '更新者名
                    lblRepairPreserver.Text = mtypRepairInfoAns.strPreserveEmpName   '保全実施者

                    '@自動ｻｲﾝが行なわれていることを考慮し、各種ｻｲﾝ欄にﾃﾞｰﾀをｾｯﾄ
                    With mtypRepairInfoAns
                        lblSignName0.Text = .strRepairNameSignEmpName                              '故障現象ｻｲﾝ者氏名
                        lblSignDate0.Text = prvFormatDate(.strRepairNameSignDate, CPstrDateTimeYMD)      '故障現象ｻｲﾝ日
                        lblSignName1.Text = .strRepairAnalysisSignEmpName                          '故障原因調査/分析ｻｲﾝ者氏名
                        lblSignDate1.Text = prvFormatDate(.strRepairAnalysisSignDate, CPstrDateTimeYMD)  '故障原因調査/分析ｻｲﾝ日
                        lblSignName2.Text = .strRepairCauseSignEmpName                             '故障原因ｻｲﾝ者氏名
                        lblSignDate2.Text = prvFormatDate(.strRepairCauseSignDate, CPstrDateTimeYMD)     '故障原因ｻｲﾝ日
                        lblSignName3.Text = .strRepairMeasureSignEmpName                           '故障対策ｻｲﾝ者氏名
                        lblSignDate3.Text = prvFormatDate(.strRepairMeasureSignDate, CPstrDateTimeYMD)   '故障対策ｻｲﾝ日

                        '@ｻｲﾝされているか
                        For llngCnt = 0 To 3
                            If lblSignNameArray(llngCnt).Text <> vbNullString Or _
                                lblSignDateArray(llngCnt).Text <> vbNullString Then

                                '@取消ﾎﾞﾀﾝを有効にする
                                cmdCancelArray(llngCnt).Enabled = True
                            Else
                                '@取消ﾎﾞﾀﾝを無効にする
                                cmdCancelArray(llngCnt).Enabled = False
                            End If
                        Next llngCnt
                    End With

                    '@呼び元機能が"処置"or"承認"か
                    If lstrCallEvent = CMstrCmdDisposeClick Or _
                        lstrCallEvent = CMstrCmdApproveClick Then

                        '@=======================
                        '@　各種ｺﾝﾄﾛｰﾙの制御処理
                        '@=======================
                        Call prvTabRepairObjectControl_Proc()
                    End If


                '@〓 "2:保全記録" 〓
                Case CPlngNumTwo

                    '@"<TRM6PI>$$[保全記録票]を更新しました。発行№[%1] 装置名[%2]"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006P, _
                                                    CPstrMailSendTitlePreserve, _
                                                    mtypChgPreserveInfoReq.strPreserveNo, _
                                                    mtypPreserveInfoAns.strWpName)
                    '@成功ﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)

                    '@*****************************
                    '@　情報の再取得(要求ﾃﾞｰﾀ作成)
                    '@*****************************
                    '@要求・応答構造体の初期化
                    mtypPreserveInfoReq = ltypPreserveInfoReq
                    mtypPreserveInfoAns = ltypPreserveInfoAns

                    With mtypPreserveInfoReq
                        .strSbID = ptypPreserveInfo.strSbID                 'ｼｽﾃﾑﾌﾞﾛｯｸID
                        .strMsgVer = CMstrpre_preserveinfoVer               'MsgVer
                        .strPreserveNo = ptypPreserveInfo.strPreserveNo     '保全記録票№
                        .strWpID = ptypPreserveInfo.strWpID                 '装置ID
                        .strWpName = ptypPreserveInfo.strWpName             '装置名(ErrMsg用)
                        .strCategoryID = ptypPreserveInfo.strCategoryID     'ｶﾃｺﾞﾘID
                        .strCategoryName = ptypPreserveInfo.strCategoryName 'ｶﾃｺﾞﾘ名(ErrMsg用)
                        .strEntryTime = ptypPreserveInfo.strEntryTime       '登録日時(装置停止・ﾒﾝﾃ計画の起動の場合、"開始(予定)日時")
                    End With

                    '@画面の使用禁止
                    Me.KeyPreview = False

                    '@【保全記録票情報取得】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnPrePreserveInfo_Sel(mtypPreserveInfoReq, mtypPreserveInfoAns)

                    '@画面の使用禁止解除
                    Me.KeyPreview = True

                    '@通信結果判定
                    If lblnAns = False Then
                        '@結果：異常の場合

                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, lstrCallEvent)
                        Exit Sub
                    End If

                    '@情報の再設定
                    lblUpdate1.Text = _
                        prvFormatDate(Strings.Left(mtypPreserveInfoAns.strEditTime, CMlngTimeFormat16), CPstrDateTimeYMDHM)    '更新日
                    lblUpdateName1.Text = pstrUserName                         '更新者名
                    lblPreserver.Text = mtypPreserveInfoAns.strPreserveEmpName   '保全実施者

                    '@呼び元機能が"処置"or"承認"か
                    If lstrCallEvent = CMstrCmdDisposeClick Or _
                        lstrCallEvent = CMstrCmdApproveClick Then

                        '@=======================
                        '@　各種ｺﾝﾄﾛｰﾙの制御処理
                        '@=======================
                        Call prvTabPreserveObjectControl_Proc()
                    End If

            End Select


            Exit Sub

        Catch ex As Exception

            '@画面の使用禁止解除
            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvAfterReportUpdate_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2008/03/06 (Thu) 11:32:41 N.Kojima **************************************************



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
        Const WM_SYSCOMMAND As Integer = &H0112
        Const WM_CLOSE As Integer = &H0010
        Const WM_ENDSESSION As Integer = &H0016
        Const SC_MOVE As Long = &HF010L
        Const SC_CLOSE As Long = &HF060L
        Dim lblnSysCommandScClose As Boolean = False  'NSYS コントロールメニュー SC_CLOSE処理時 True
        Dim lblnWMClose As Boolean = False  'NSYS WM_CLOSE処理時 True

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

    '関数名：textbox_Enter
    '機　能：ハイライト処理用 フォーカス取得イベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub textbox_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles medPreserveEndTime.Enter, medRepairEndTime.Enter
        'NSYS フォーカスインでハイライト処理 開始
        sender.ScrollToCaret()
        If (sender.MouseButtons And MouseButtons.Left) = MouseButtons.Left Then
            sender.Tag("OnHighlight") = True
        Else
            sender.Tag("OnHighlight") = False
        End If
    End Sub

    '関数名：textbox_Leave
    '機　能：ハイライト処理用 フォーカス喪失イベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考
    Private Sub textbox_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles medPreserveEndTime.Leave, medRepairEndTime.Leave
        'NSYS マウス選択でのハイライトをキャンセルする
        sender.Tag("OnHighlight") = False
    End Sub

    '関数名：textbox_KeyUp
    '機　能：ハイライト処理用 キーアップイベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考
    Private Sub textbox_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles medPreserveEndTime.KeyUp, medRepairEndTime.KeyUp
        'NSYS Tabキー押下の場合
        If e.KeyCode = Keys.Tab Then
            'NSYS マウス選択でのハイライトをキャンセルする
            sender.Tag("OnHighlight") = False
        End If
    End Sub

    '関数名：textbox_MouseDown
    '機　能：ハイライト処理用 マウスダウンイベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub textbox_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles medPreserveEndTime.MouseDown, medRepairEndTime.MouseDown
        'NSYS MouseDown時のカーソル位置を保持
        sender.Tag("MouseDownStart") = sender.SelectionStart
    End Sub

    '関数名：textbox_MouseUp
    '機　能：ハイライト処理用 マウスアップイベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub textbox_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles medPreserveEndTime.MouseUp, medRepairEndTime.MouseUp
        Dim curpos As Integer   'NSYS ｶｰｿﾙ位置

        '@ﾊｲﾗｲﾄするになっている場合
        If CBool(sender.Tag("OnHighlight")) = True Then
            ''@ｶｰｿﾙ位置までﾊｲﾗｲﾄ表示
            curpos = sender.SelectionStart
            sender.SelectionStart = 0
            If curpos < CInt(sender.Tag("MouseDownStart")) Then
                'NSYS 左ドラッグ時
                sender.SelectionLength = curpos
            Else
                sender.SelectionLength = curpos + sender.SelectedText.Length
            End If
            sender.ScrollToCaret()
            sender.Tag("OnHighlight") = False
        End If
    End Sub

    '関数名：TabControl_Selecting
    '機　能：Tabページ切替キャンセル
    '作成日：2019/09/24 (Thu) 20:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub TabControl_Selecting(ByVal sender As Object, ByVal e As TabControlCancelEventArgs) Handles tabMainteSheet.Selecting
        
        Select Case tabMainteSheet.SelectedTab.Name
            Case Tab0.Name
                If Tab0.Enabled = False Then
                    e.Cancel = True
                End If

            Case Tab1.Name
                If Tab1.Enabled = False Then
                    e.Cancel = True
                End If

            Case Tab2.Name
                If Tab2.Enabled = False Then
                    e.Cancel = True
                End If

            Case Tab3.Name
                If Tab3.Enabled = False Then
                    e.Cancel = True
                End If
        End Select
    End Sub

    '関数名：prvFormatNum
    '機　能：数値のフォーマット編集処理
    '作成日：2020/05/12 NSYS
    '更新日：
    '備　考：editStr:変換する文字列 formatStr
    Private Function prvFormatNum(ByVal editStr As String, ByVal formatStr As String) As String

        Try
            '数値として妥当な場合、フォーマットを実行する
            If IsNumeric(editStr) = True Then
                prvFormatNum = Format$(CDec(editStr), formatStr)
            Else
                prvFormatNum = editStr
            End If

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFormatNum"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try

    End Function
    
    '関数名：prvFormatDate
    '機　能：日付のフォーマット編集処理
    '作成日：2020/05/12 NSYS
    '更新日：
    '備　考：editStr:変換する文字列 formatStr
    Private Function prvFormatDate(ByVal editStr As String, ByVal formatStr As String) As String

        Try
            '日付として妥当な場合、フォーマットを実行する
            If IsDate(editStr) = True Then
                prvFormatDate = Format$(CDate(editStr), formatStr)
            Else
                prvFormatDate = editStr
            End If

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFormatDate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try

    End Function

    '関数名：txtRepairName_KeyPress
    '機　能：txtRepairNameでEnterが押された場合の制御
    '作成日：2020/05/16 NSYS
    '更新日：
    '備　考：
    Private Sub txtRepairName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRepairName.KeyPress

        Try
            'Enterキーが押された場合
            If e.KeyChar = vbCr Then
                '入力を無効かする
                e.Handled = True
            End If

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFormatDate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try

    End Sub

    '関数名：cursor_Enter
    '機　能 ： 項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考 ： Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles calPreserveEndDate.Enter,calRepairEndDate.Enter,
        cmdApprove.Enter,
        cmdCancel0.Enter,cmdCancel1.Enter,cmdCancel2.Enter,cmdCancel3.Enter,cmdCancel4.Enter,cmdCancel5.Enter,cmdCancel6.Enter,cmdCancel7.Enter,cmdCancel8.Enter,cmdCancel9.Enter,
        cmdClose.Enter,
        cmdDispose.Enter,
        cmdDown0.Enter,cmdDown1.Enter,cmdDown2.Enter,cmdDown3.Enter,cmdDown4.Enter,cmdDown5.Enter,cmdDown6.Enter,cmdDown7.Enter,
        cmdMail.Enter,
        cmdNowDate0.Enter,cmdNowDate1.Enter,
        cmdRepairNameSelect.Enter,
        cmdSave.Enter,
        cmdSign0.Enter,cmdSign1.Enter,cmdSign2.Enter,cmdSign3.Enter,cmdSign4.Enter,cmdSign5.Enter,cmdSign6.Enter,cmdSign7.Enter,cmdSign8.Enter,cmdSign9.Enter,
        cmdUp0.Enter,cmdUp1.Enter,cmdUp2.Enter,cmdUp3.Enter,cmdUp4.Enter,cmdUp5.Enter,cmdUp6.Enter,cmdUp7.Enter,
        medPreserveEndTime.Enter,
        medRepairEndTime.Enter,
        optCopeDivision0.Enter,optCopeDivision1.Enter,optCopeDivision2.Enter,optCopeDivision3.Enter,
        txtAnalysisContents.Enter,
        txtCause.Enter,
        txtMeasure.Enter,
        txtPartCost0.Enter,txtPartCost1.Enter,
        txtPreserveComment.Enter,
        txtPreserveContents.Enter,
        txtPreserveItem.Enter,
        txtPreservePurpose.Enter,
        txtRepairContents.Enter,
        txtRepairName.Enter,
        txtWorkCost0.Enter,txtWorkCost1.Enter,
        vsfToEmpName0.Enter,vsfToEmpName1.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '自動Validate = OFF
            Case cmdClose.Name
                Me.AutoValidate = AutoValidate.Disable

            '自動Validate = ON
            Case Else
                Me.AutoValidate = AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

    '関数名：tabList_Deselecting
    '機　能：タブの選択が解除される前に発生するイベント処理
    '引　数：sender：イベント発生源のオブジェクト
    '        e     ：イベント情報
    '戻り値：なし
    '作成日：2018/10/12 (Fri) NSYS
    '更新日：
    '備　考：
    Private Sub tabList_Deselecting(ByVal sender As Object, ByVal e As TabControlCancelEventArgs) Handles tabMainteSheet.Deselecting

        '処理中の場合またはタブ切り替えが無効の場合はタブ選択をキャンセルする
        If Me.buttonProcessing = True OrElse mblnTabSelectEnabled = False Then
            e.Cancel = True
            mblnTabSelectEnabled = True
        End If

    End Sub

End Class
