'ﾌｧｲﾙ名：xxEN01V0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：装置使用部材管理ﾒｲﾝﾌｫｰﾑ
'作成日：2006/04/04 (Tue) 15:26:27 N.Kojima
'更新日：2018/06/28 (Thu) 16:30:36 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2018, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Imports SEComboBoxEx
Public Class frmxxEN01V0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01V0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01V0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01V0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01V0)
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
    '========================================Public==========================================
    '========================================Private=========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    'Private Const CMstrLocalVersion                                 As String = "08.02"                 '機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion                                 As String = "08.03"                 '機能ﾊﾞｰｼﾞｮﾝ

    '@機能ID
    Private Const CMstrLocalMenuKey                                 As String = CPstrKeyEN01V0          'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_materialtypeVer                          As String = "01.01"                 '部材種別取得
    Private Const CMstrmas_materialVer                              As String = "02.00"                 '部材取得
    Private Const CMstrmas_materialwpVer                            As String = "01.00"                 '部材使用装置一覧取得
    Private Const CMstrmat_alllist_Ver                              As String = "03.01"                 '装置使用部材一覧取得 03.01
    Private Const CMstrmat_chgmaterialstatVer                       As String = "03.00"                 '装置使用部材状態変更
    Private Const CMstrmat_chkwpmaterialVer                         As String = "03.00"                 '装置使用部材判定
    Private Const CMstrmat_chkmaterialstockVer                      As String = "01.00"                 '装置使用部材在庫ﾁｪｯｸ
    Private Const CMstrmat_materialstocknumVer                      As String = "01.00"                 '装置使用部材在庫数量取得
    Private Const CMstrmat_ordermaterialVer                         As String = "01.00"                 '装置使用部材発注

    '@vsfMaterialListの定数宣言（ｶﾗﾑ）
    Private Const CMlngvsfMaterialListColNo                         As Integer = 0                         '№
    Private Const CMlngvsfMaterialListColMaterialLotID              As Integer = 1                         '部材管理ID
    Private Const CMlngvsfMaterialListColStatus                     As Integer = 2                         '状態
    Private Const CMlngvsfMaterialListColWPName                     As Integer = 3                         '使用装置名
    Private Const CMlngvsfMaterialListColProductionDate             As Integer = 4                         '製造日
    Private Const CMlngvsfMaterialListColAcceptanceDate             As Integer = 5                         '受入日
    Private Const CMlngvsfMaterialListColWPID                       As Integer = 6                         '使用装置ID
    Private Const CMlngvsfMaterialListColUseTime                    As Integer = 7                         '使用開始日時
    Private Const CMlngvsfMaterialListColVenderWarrantDays          As Integer = 8                         'ﾒｰｶｰ保証期間
    Private Const CMlngvsfMaterialListColAcceptWarrantDays          As Integer = 9                         '受入制限期間
    Private Const CMlngvsfMaterialListColUseValidPeriod             As Integer = 10                        '使用可能時間
    Private Const CMlngvsfMaterialListColUseInvalidPeriod           As Integer = 11                        '使用禁止(不可)時間
    Private Const CMlngvsfMaterialListColWarningPeriod              As Integer = 12                        'ﾜｰﾆﾝｸﾞ表示時間
    Private Const CMlngvsfMaterialListColUseInvalidPeriodJudge      As Integer = 13                        '使用禁止(不可)時間判定ﾌﾗｸﾞ
    Private Const CMlngvsfMaterialListColLastUpdate                 As Integer = 14                        '最終更新日時
    Private Const CMlngvsfMaterialListColMaterialStatus             As Integer = 15                        '部材状態

    '@vsfMaterialListの定数宣言（幅）
    Private Const CMlngvsfMaterialListColWNo                        As Integer = 50                        '№
    Private Const CMlngvsfMaterialListColWMaterialLotID             As Integer = 274                       '部材管理ID
    Private Const CMlngvsfMaterialListColWStatus                    As Integer = 49                        '状態
    Private Const CMlngvsfMaterialListColWWPName                    As Integer = 179                       '使用装置名
    Private Const CMlngvsfMaterialListColWProductionDate            As Integer = 179                       '製造日
    Private Const CMlngvsfMaterialListColWAcceptanceDate            As Integer = 179                       '受入日
    Private Const CMlngvsfMaterialListColWUseTime                   As Integer = 179                       '使用開始日時
    Private Const CMlngvsfMaterialListColWWPID                      As Integer = 0                         '使用装置ID
    Private Const CMlngvsfMaterialListColWVenderWarrantDays         As Integer = 0                         'ﾒｰｶｰ保証期間
    Private Const CMlngvsfMaterialListColWAcceptWarrantDays         As Integer = 0                         '受入制限期間
    Private Const CMlngvsfMaterialListColWUseValidPeriod            As Integer = 0                         '使用可能時間
    Private Const CMlngvsfMaterialListColWUseInvalidPeriod          As Integer = 0                         '使用禁止(不可)時間
    Private Const CMlngvsfMaterialListColWWarningPeriod             As Integer = 0                         'ﾜｰﾆﾝｸﾞ表示時間
    Private Const CMlngvsfMaterialListColWUseInvalidPeriodJudge     As Integer = 0                         '使用禁止(不可)時間判定ﾌﾗｸﾞ
    Private Const CMlngvsfMaterialListColWLastUpdate                As Integer = 10                        '最終更新日時
    Private Const CMlngvsfMaterialListColWMaterialStatus            As Integer = 10                        '部材状態

    '@vsfMaterialListの定数宣言（ﾀｲﾄﾙ）
    Private Const CMstrvsfMaterialListColTNo                        As String = "№"                    '№
    Private Const CMstrvsfMaterialListColTMaterialLotID             As String = "部材管理ID"            '部材管理ID
    Private Const CMstrvsfMaterialListColTStatus                    As String = "状態"                  '状態
    Private Const CMstrvsfMaterialListColTWPName                    As String = "使用装置"              '使用装置名
    Private Const CMstrvsfMaterialListColTProductionDate            As String = "製造日"                '製造日
    Private Const CMstrvsfMaterialListColTAcceptanceDate            As String = "受入日"                '受入日
    Private Const CMstrvsfMaterialListColTUseTime                   As String = "使用開始日時"          '使用開始日時
    Private Const CMstrvsfMaterialListColTWPID                      As String = "使用装置ID"            '使用装置ID
    Private Const CMstrvsfMaterialListColTVenderWarrantDays         As String = "ﾒｰｶｰ保証期間"          'ﾒｰｶｰ保証期間
    Private Const CMstrvsfMaterialListColTAcceptWarrantDays         As String = "受入制限期間"          '受入制限期間
    Private Const CMstrvsfMaterialListColTUseValidPeriod            As String = "使用可能時間"          '使用可能時間
    Private Const CMstrvsfMaterialListColTUseInvalidPeriod          As String = "使用禁止時間"          '使用禁止(不可)時間
    Private Const CMstrvsfMaterialListColTWarningPeriod             As String = "ﾜｰﾆﾝｸﾞ表示時間"        'ﾜｰﾆﾝｸﾞ表示時間
    Private Const CMstrvsfMaterialListColTUseInvalidPeriodJudge     As String = "使用禁止(不可)時間判定ﾌﾗｸﾞ"  '使用禁止(不可)時間判定ﾌﾗｸﾞ
    Private Const CMstrvsfMaterialListColTLastUpdate                As String = "最終更新日時"          '最終更新日時
    Private Const CMstrvsfMaterialListColTMaterialStatus            As String = "部材状態"              '部材状態

    '@ｸﾞﾘｯﾄﾞの定数宣言
    Private Const CMlngvsfMaterialListLRowTitle                     As Integer = 0                         'ﾀｲﾄﾙ行（行）
    Private Const CMlngvsfMaterialListLColTitle                     As Integer = 0                         'ﾀｲﾄﾙ行（列）
    Private Const CMlngvsfmlngSortCol                               As Integer = 0                         'ｿｰﾄ列初期値
    Private Const CMlngvsfmlngOrderCol                              As Integer = 0                         'ｿｰﾄ方法初期値
    Private Const CMlngvsfMaterialListRowFrezon                     As Integer = 1                         '固定列(=1)
    Private Const CMlngvsfMaterialListLHFontSize                    As Integer = 12                        'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfMaterialListows                           As Integer = 8                         '1ﾍﾟｰｼﾞ最大表示行数
    Private Const CMlngvsfRowTop                                    As Integer = 0                         '選択最上段行
    Private Const CMlngvsfMaterialListLHHeight                      As Integer = 24                        'ﾍｯﾀﾞｰの高さ
    Private Const CMlngvsfMaterialListLHeight                       As Integer = 39                        '1ｽﾛｯﾄの高さ

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                                  As Integer = 16                        'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                              As Integer = 16                        'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColName                               As Integer = 0                         'ﾃｷｽﾄ(名称)列番
    Private Const CMlngCmbGridColID                                 As Integer = 1                         'ID列番（非表示項目）
    Private Const CMlngCmbDispCols                                  As Integer = 1                         'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbAlignLeftCenter                           As Integer = 1                         'ｸﾞﾘｯﾄﾞ文字表示位置（左中央）
    Private Const CMlngCmbHeight                                    As Integer = 42                        'ﾘｽﾄの高さ
    Private Const CMlngCmbValueCol                                  As Integer = 0                         '値取得列
    Private Const CMlngCmbGetCol                                    As Integer = 2                         '値表示列
    Private Const CMlngCmbClearListIndex                            As Integer = -1                        'ﾃｷｽﾄ値初期化

    '@ﾚｽﾎﾟﾝｽ計測用
    Private Const CMstrFormName                                     As String = "frmxxEN01V0"               '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                                     As String = "Form_Load"                 'ｲﾍﾞﾝﾄ名定数(ﾌｫｰﾑﾛｰﾄﾞ)
    Private Const CMstrCmbMaterialTypeValidate                      As String = "cmbMaterialType_Validate"  'ｲﾍﾞﾝﾄ名定数(部材種別Validate)
    Private Const CMstrCmbMaterialValidate                          As String = "cmbMaterial_Validate"      'ｲﾍﾞﾝﾄ名定数(部材Validate)
    Private Const CMstrCmdNowListClick                              As String = "cmdNowList_Click"          'ｲﾍﾞﾝﾄ名定数(最新取得)
    Private Const CMstrCmdStartUseClick                             As String = "cmdStartUse_Click"         'ｲﾍﾞﾝﾄ名定数(使用開始)
    Private Const CMstrCmdUseWPClick                                As String = "cmdUseWP_Click"            'ｲﾍﾞﾝﾄ名定数(装置使用開始)
    Private Const CMstrCmdUseWPCancelClick                          As String = "cmdUseWPCancel_Click"      'ｲﾍﾞﾝﾄ名定数(装置使用解除)
    Private Const CMstrCmdHoldClick                                 As String = "cmdHold_Click"             'ｲﾍﾞﾝﾄ名定数(保留)
    Private Const CMstrCmdHoldCancelClick                           As String = "cmdHoldCancel_Click"       'ｲﾍﾞﾝﾄ名定数(保留解除)
    Private Const CMstrCmdScrapClick                                As String = "cmdScrap_Click"            'ｲﾍﾞﾝﾄ名定数(廃棄)
    Private Const CMstrCmdInvalidClick                              As String = "cmdInvalid_Click"          'ｲﾍﾞﾝﾄ名定数(無効)
    Private Const CMstrPrvblnMaterialChk                            As String = "prvblnMaterialPeriod_Chk"  'ｲﾍﾞﾝﾄ名定数(使用部材ﾁｪｯｸ)
    Private Const CMstrPrvblnAuthorityChk                           As String = "prvblnAuthority_Chk"       'ｲﾍﾞﾝﾄ名定数(権限ﾁｪｯｸ)
    Private Const CMstrPrvblnMaterialStockChk                       As String = "prvblnMaterialStock_Chk"   'ｲﾍﾞﾝﾄ名定数(使用部材の在庫ﾁｪｯｸ)
    Private Const CMstrPrvblnMaterialStockDisp                      As String = "prvblnMaterialStock_Disp"  'ｲﾍﾞﾝﾄ名定数(使用部材の在庫ﾁｪｯｸ結果表示)

    '@部材状態ﾁｪｯｸ用
    Private Const CMstrStatusOrd                                    As String = "0"     '@発注済
    Private Const CMstrStatusAcc                                    As String = "1"     '@受入済
    Private Const CMstrStatusUse                                    As String = "2"     '@使用中
    Private Const CMstrStatusSet                                    As String = "3"     '@装置使用
    Private Const CMstrStatusCan                                    As String = "8"     '@廃棄(発注取消)
    Private Const CMstrStatusOut                                    As String = "9"     '@廃棄

    '@その他
    Private Const CMstrNoWP                                         As String = "装置なし"              'ｺﾝﾎﾞ表示用
    Private Const CMstrPeriodOver                                   As String = "×"                    '状態表示用(使用可能時間ｵｰﾊﾞｰ時表示)
    Private Const CMstrDeliverStatus                                As String = "未"                    '状態表示用(発注済み、未受入状態)
    Private Const CMstrHoldStatus                                   As String = "保"
    Private Const CMstrUnitClassM                                   As String = "M"
    Private Const CMstrUnitM                                        As String = "ヶ月"
    Private Const CMstrUnitClassD                                   As String = "D"
    Private Const CMstrUnitD                                        As String = "日"
    Private Const CMstrUnitClassH                                   As String = "H"
    Private Const CMstrUnitH                                        As String = "時間"

    '@部材在庫ﾁｪｯｸﾒｯｾｰｼﾞ表示用
    Private Const CMstrLackInventoryMsg1                            As String = "部材在庫数が発注ポイントに達しました。発注を行なってください｡ "  'Msg表示用
    Private Const CMstrLackInventoryMsg2                            As String = "発注済 － 受入予定日："    'Msg表示用
    Private Const CMstrNoDeliverMsg                                 As String = "納入予定なし"              'Msg表示用
    Private Const CMstrMaterialOrderRemainNumNULL                   As String = "未設定"                    '発注ﾎﾟｲﾝﾄ未設定
    Private Const CMstrScrap                                        As String = "廃棄"
    Private Const CMstrInvalid                                      As String = "無効化"

    '@ｽｸﾛｰﾙ制御
    Private Const CMlngSideScrollOnFlag                             As Integer = 1                         '横ｽｸﾛｰﾙ活性化
    Private Const CMlngSideScrollOffFlag                            As Integer = 2                         '横ｽｸﾛｰﾙ非活性化
    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Public==========================================
    '========================================Private=========================================
    Private mtypMaterialType                                        As MaterialWPList                   '部材種別格納用
    Private mtypMaterial                                            As MaterialTypeList                 '部材格納用
    Private mtypMaterialWP                                          As MaterialWP                       '使用装置格納用
    Private mtypMaterialAll                                         As MaterialAll                      '部材一覧格納用
    Private mstrMaterialType                                        As String                           '部材種別退避領域
    Private mstrMaterial                                            As String                           '部材退避領域
    Private mstrMaterialWP                                          As String                           '使用装置退避領域
    Private mstrPdErrMsg                                            As String                           '機種限定ｴﾗｰMsg格納用
    Private mstrLimitErrMsg                                         As String                           '部材期限判定ｴﾗｰMsg格納用
    Private mstrStockErrMsg                                         As String                           '部材在庫判定ｴﾗｰMsg格納用
    Private mstrAction                                              As String                           '処理格納用(0=使用開始、1=装置使用開始、2=発注、3=受入、4=分割、5=廃棄、6=保留、7=保留解除)
    Private mblnValidateFlag                                        As Boolean                          'Validate処理済み判定ﾌﾗｸﾞ(false:未処理、true:処理済み)
    Private mblnMaterialStockChkFlag                                As Boolean                          '在庫ﾁｪｯｸ中判定ﾌﾗｸﾞ(false:ﾁｪｯｸ外、true:ﾁｪｯｸ中)

    Private mlngSideScrollFlag                                      As Integer                          '横ｽｸﾛｰﾙの使用ﾌﾗｸﾞ(1:発生/2:不要)

    Private mtypChgSort                                             As ChgSort                          'ｿｰﾄ保持用
    Private mlngSortCol                                             As Integer                          'ｿｰﾄ列格納
    Private mlngSortOrder                                           As Integer                          'ｿｰﾄ方法格納
    Private mblnFormActivateFlag                                    As Boolean                          'ﾌｫｰﾑのｱｸﾃｨﾍﾞｨﾄﾌﾗｸﾞ
    Private buttonProcessing                                        As Boolean                          'NSYS ボタン2度押し対策   
    Private mblnCloseFromControlMenu                                As Boolean                          'NSYS システムコマンドでの画面クローズ    
    Private mblnWindowClose                                         As Boolean                          'NSYS WindowCloseフラグ

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
        
        'NSYS スクロールバーなしグリッドのマウスホイール対応
        pubVsfMouseWheelManager_Set(vsfMaterialList, cmdUp, cmdDown, cmdLeft, cmdRight)
        

        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                                *イベントハンドラの記述*
    '****************************************************************************************
    '========================================Private=========================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ時処理：ACT初期設定および初期情報取得
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/13 (Thu) 17:15:06 N.Kojima
    '更新日：2006/04/13 (Thu) 17:15:06
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns             As Boolean              '結果格納

        Try
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing 
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN01V0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
                '@異常終了の場合
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose 
                Exit Sub
            End If
            
            '@全てのｺﾝﾎﾞﾎﾞｯｸｽの初期化(部材種別,部材,使用装置)
            Call prvAllCombo_Init()
            
            '@ﾒｲﾝﾌｫｰﾑの初期化
            Call prvfrmxxEN01V0_Init()
            
            '@部材一覧(vsfMaterialList)の初期化
            Call prvvsfMaterialList_Init()
            
            '@構造体初期化（ｿｰﾄ順保持）
             With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList) 
                Else 
                    .typChgSortList.Clear()
                End If
                
                '@列幅変更ﾌﾗｸﾞ（未変更）
                .blnChgWidth = False
                
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)
            
            '@部材種別情報の取得
            lblnAns = pubblnMasMaterialType_Sel(CMstrmas_materialtypeVer, _
                                                mtypMaterialType)
            
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            Else
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrFormLoad)
            End If

            '@Form_Loadﾌﾗｸﾞ（正常）
            pblnFormLoad = True

            'NSYS グリッドロック
            vsfMaterialList.Enabled = False 

            Exit Sub

        Catch ex As Exception

            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose

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
    '機　能：ﾌｫｰﾑのｱｸﾃｨﾍﾞｨﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/13 (Thu) 17:15:19 N.Kojima
    '更新日：2006/10/26 (Thu) 19:04:05 N.Kojima
    '備　考：
    '　　　：2006/10/26 (Thu) 19:04:05 N.Kojima     在庫ﾁｪｯｸ中のﾚｽﾎﾟﾝｽ処理でｱｸﾃｨﾍﾞｲﾄ処理が走行するのを防止。(案件№01095)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            
            '@在庫ﾁｪｯｸ中はｽﾙｰ
            If mblnMaterialStockChkFlag = True Then
                Exit Sub
            End If
            
            '@起動時処理
            If mblnFormActivateFlag = False Then
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                '@部材種別の件数ﾁｪｯｸ（件数によって処理を分岐）
                With cmbMaterialType
                    '@取得件数が0件の場合
                    If mtypMaterialType.lngMaterialTypeCnt = 0 Then
                        '@ﾒｯｾｰｼﾞを表示する
                        '@ﾌﾗｸﾞ変更
                        mblnFormActivateFlag = True
                        
                        '@部材種別ｺﾝﾎﾞを無効に
                        cmbMaterialType.Enabled = True
                    Else
                        '@部材種別ｺﾝﾎﾞ設定
                        Call prvCmbMaterialType_Disp()
                    
                        '@取得件数が1件の場合
                        If mtypMaterialType.lngMaterialTypeCnt = 1 Then
                        
                            '@部材種別ｺﾝﾎﾞを有効に
                            cmbMaterialType.Enabled = True
                            
                            '@ｺﾝﾎﾞに表示
                            .ListIndex = 0
                            
                            '@部材種別のValidateｲﾍﾞﾝﾄを呼び出す
                            RemoveHandler cmbMaterialType.Validating  , AddressOf cmbMaterialType_Validate
                            Call cmbMaterialType_Validate(cmbMaterialType, New CancelEventArgs (False))
                            AddHandler cmbMaterialType.Validating  , AddressOf cmbMaterialType_Validate
                        Else
                            '@部材種別ｺﾝﾎﾞを有効に
                            cmbMaterialType.Enabled = True
                            '@部材へﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmbMaterialType)
                        End If
                    End If
                End With
                
                '@ﾌﾗｸﾞ変更
                mblnFormActivateFlag = True
            
            End If
            
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
    '機　能：ﾌｫｰﾑのKeyDown
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 09:12:45 N.Kojima
    '更新日：2007/07/06 (Fri) 14:53:17 N.Kasai
    '備　考：
    '　　　：2007/07/06 (Fri) 14:53:17 N.Kasai  ｸﾞﾘｯﾄﾞ共通
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

            'NSYS キーボード操作時のちらつき対策
            vsfMaterialList.Redraw = False
            '@ｸﾞﾘｯﾄﾞｷｰ制御（ｸﾞﾘｯﾄﾞ共通仕様）
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfMaterialList, cmdUP, cmdDown)
            
            '@ｸﾞﾘｯﾄﾞｷｰ制御（ｷｰｺｰﾄﾞ、ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名、ｸﾞﾘｯﾄﾞ、左ﾎﾞﾀﾝ、右ﾎﾞﾀﾝ）
            Call pubvsfSideKeyDown(e, ActiveControl.Name, vsfMaterialList, cmdLeft, cmdRight)
            vsfMaterialList.Redraw = True 

            '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理判別
            Select Case ActiveControl.Name
                '@部材種別の場合
                Case cmbMaterialType.Name
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@部材種別Validate処理へ
                            RemoveHandler cmbMaterialType.Validating , AddressOf cmbMaterialType_Validate 
                            Call cmbMaterialType_Validate(cmbMaterialType, New CancelEventArgs(True))
                            AddHandler cmbMaterialType.Validating , AddressOf cmbMaterialType_Validate
                            e.Handled = True
                        Case Else
                    End Select

                '@部材の場合
                Case cmbMaterial.Name
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@部材Validate処理へ
                            RemoveHandler cmbMaterial.Validating , AddressOf cmbMaterial_Validate 
                            Call cmbMaterial_Validate(cmbMaterial, New CancelEventArgs(True))
                            AddHandler cmbMaterial.Validating , AddressOf cmbMaterial_Validate
                            e.Handled = True
                        Case Else
                    End Select
                    
                '@使用装置の場合
                Case cmbWp.Name
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@使用装置Validate処理へ
                            RemoveHandler cmbWP.Validating, AddressOf cmbWp_Validate 
                            Call cmbWp_Validate(cmbWp, New CancelEventArgs(True))
                            AddHandler cmbWP.Validating, AddressOf cmbWp_Validate 
                            e.Handled = True
                        Case Else
                    End Select

                '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙがｽﾌﾟﾚｯﾄﾞの場合
                Case vsfMaterialList.Name

                    '@ｸﾞﾘｯﾄﾞｷｰ制御（[→]ｷｰﾎﾞﾀﾝ,[←]ｷｰﾎﾞﾀﾝ）
                    With vsfMaterialList
                        Select Case e.KeyCode
                            '@Enterｷｰの場合
                            Case Keys.Return
                                '@次項目へｾｯﾄﾌｫｰｶｽ
                                SendKeys.SendWait(CPstrSendKeysTab)
                                e.Handled = True

                            Case Else
                                '@その他の場合はｽﾙｰ
                        End Select
                    End With
                        
                '@その他の場合
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
    '引　数：Cancel     ：ｷｬﾝｾﾙ値
    '　　　：UnloadMode ：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 09:13:38 N.Kojima
    '更新日：2006/10/03 (Tue) 15:39:55 N.Kojima
    '備　考：
    '　　　：2006/10/03 (Tue) 15:39:55 N.Kojima     機種限定・部材期限判定ｴﾗｰMsg格納用変数の初期化処理追加。(案件№01472)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
                       
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload 
                Call cmdClose_Click(sender, new EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload 
            End If
            
            '@ﾌﾟﾗｲﾍﾞｰﾄ変数のｸﾘｱ

            '部材種別格納用
            If mtypMaterialType.typMaterialTypeList Is Nothing
                mtypMaterialType.typMaterialTypeList = New List(Of MaterialTypeList) 
            Else 
                mtypMaterialType.typMaterialTypeList.Clear()
            End If

            '部材管理ID格納用
            If mtypMaterial.typMaterialIDList Is Nothing
                mtypMaterial.typMaterialIDList = New List(Of MaterialIDList)  
            Else 
                mtypMaterial.typMaterialIDList.Clear()
            End If

            '使用装置格納用
            If mtypMaterialWP.typMaterialWPList Is Nothing                
                mtypMaterialWP.typMaterialWPList =  New List(Of MaterialWPList) 
            Else   
                mtypMaterialWP.typMaterialWPList.Clear()
            End If

            '部材一覧格納用
            If mtypMaterialAll.typMaterialAllList Is Nothing
                mtypMaterialAll.typMaterialAllList = New List(Of MaterialAllList) 
            Else   
                mtypMaterialAll.typMaterialAllList.Clear()
            End If
            
            'ｿｰﾄ保持用
            If mtypChgSort.typChgSortList Is Nothing
                mtypChgSort.typChgSortList = New List(Of ChgSortList)  
            Else   
                mtypChgSort.typChgSortList.Clear()
            End If
                                        
            '@ﾓｼﾞｭｰﾙ変数のｸﾘｱ・初期化
            mstrMaterialType = vbNullString                         '部材種別退避領域
            mstrMaterial = vbNullString                             '部材退避領域
            mstrMaterialWP = vbNullString                           '使用装置退避領域
            mstrAction = vbNullString                               '処理格納用
            
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

    '関数名：cmbMaterialType_Change
    '機　能：部材種別変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 09:15:27 N.Kojima
    '更新日：2006/10/24 (Tue) 10:26:30 N.Kojima
    '備　考：
    '　　　：2006/10/24 (Tue) 10:26:30 N.Kojima     部材の在庫ﾁｪｯｸ・発注管理機能追加に伴い、処理追加&修正。(案件№01095)
    Private Sub cmbMaterialType_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMaterialType.Change

        Try
                       
            '@退避領域と比較して同じかつ部材ｺﾝﾎﾞが有効な場合には処理抜け
            If mstrMaterialType <> cmbMaterialType.Text Then
                '@異なる場合
                
                '@起動時の初期化時には処理を飛ばす
                If mblnFormActivateFlag = True Then
            
                    '@ｶﾚﾝﾄ行検索ｷｰを初期化
                    mtypChgSort.strKey = vbNullString
            
                    '@部材一覧初期化処理
                    Call prvvsfMaterialList_Init()
                    
                    '@各種ﾗﾍﾞﾙの初期化
                    lblStockNum.Text = vbNullString              '未使用部材数
                    lblOrderNum.Text = vbNullString              '発注済数
                    lblOrderRemeinNum.Text = vbNullString        '発注ﾎﾟｲﾝﾄ
                    lblMessage.Text = vbNullString               'ﾒｯｾｰｼﾞ
                    
                    '@発注ﾎﾞﾀﾝの無効化
                    cmdOrder.Enabled = False
                    
                    '@ｺﾝﾎﾞﾎﾞｯｸｽの初期化&無効化(部材,使用装置)
                    cmbMaterial.Clear
                    cmbMaterial.Enabled = False
                    cmbWp.Clear
                    cmbWp.Enabled = False
                    
                    '@退避用変数の初期化
                    mstrMaterialType = vbNullString     '部材種別ID
                    mstrMaterial = vbNullString         '部材
                    mstrMaterialWP = vbNullString       '使用装置ID
                    '@Validate処理判定ﾌﾗｸﾞをFalse(未処理)に初期化
                    mblnValidateFlag = False
                    
                    '@最新取得ﾎﾞﾀﾝを無効に
                    cmdNowList.Enabled = False
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMaterialType_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMaterialType_CloseUp
    '機　能：部材種別ｺﾝﾎﾞのCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 10:29:57 N.Kojima
    '更新日：2006/04/14 (Fri) 10:29:57
    '備　考：
    Private Sub cmbMaterialType_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMaterialType.CloseUp

        Try
                       
            '@部材種別が空欄でない場合
            If cmbMaterialType.Text <> vbNullString Then
                '@部材種別_Validate処理
                RemoveHandler cmbMaterialType.Validating  , AddressOf cmbMaterialType_Validate
                Call cmbMaterialType_Validate(cmbMaterialType, New CancelEventArgs (False))
                AddHandler cmbMaterialType.Validating  , AddressOf cmbMaterialType_Validate

            End If
          
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMaterialType_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMaterialType_LostFocus
    '機　能：部材種別ｺﾝﾎﾞのLostFocus時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/27 (Thu) 16:09:40 N.Kojima
    '更新日：2006/04/27 (Thu) 16:09:40
    '備　考：
    Private Sub cmbMaterialType_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMaterialType.Leave

        Try
                        
            '@LostFocusを使用している為、MsgBoxが出た際の対応
            If mblnValidateFlag = True Then
                '@Valdate処理済みﾌﾗｸﾞを初期化し終了
                mblnValidateFlag = False
                Exit Sub
            End If
            
            '@退避領域と比較して同じ場合には処理抜け
            If mstrMaterialType <> cmbMaterialType.Text Then
                
                '@起動時の初期化時には処理を飛ばす
                If mblnFormActivateFlag = True Then
            
                    '@部材一覧初期化処理
                    Call prvvsfMaterialList_Init()
                    
                    '@部材種別が空欄でない場合
                    If cmbMaterialType.Text <> vbNullString Then
                        '@部材種別_Validate処理
                        RemoveHandler cmbMaterialType.Validating  , AddressOf cmbMaterialType_Validate
                        Call cmbMaterialType_Validate(cmbMaterialType, New CancelEventArgs (False))
                        AddHandler cmbMaterialType.Validating  , AddressOf cmbMaterialType_Validate

                    End If
                    
                End If
            End If
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMaterialType_LostFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMaterialType_Validate
    '機　能：部材種別ｺﾝﾎﾞValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 09:10:07 N.Kojima
    '更新日：2006/04/14 (Fri) 09:10:07
    '備　考：
    Private Sub cmbMaterialType_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbMaterialType.Validating
        
        Dim lblnAns             As Boolean              '部材取得の戻り値格納用

        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@LostFocusを使用している為、MsgBoxが出た際の対応
            If mblnValidateFlag = True Then
                '@Valdate処理済みﾌﾗｸﾞを初期化し終了
                mblnValidateFlag = False
                Exit Sub
            End If
            
            '@部材ｺﾝﾎﾞが選択されていない場合には処理抜け
            If cmbMaterialType.Text = vbNullString Then
               
                If ActiveControl.Name = cmbMaterialType.name

                    '@部材ｺﾝﾎﾞが有効か
                    If cmbMaterial.Enabled = True Then
                        '@部材ｺﾝﾎﾞへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmbMaterial)
                    Else
                        '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If

                End If

                Exit Sub
            Else
                '@退避領域と比較して同じかつ部材ｺﾝﾎﾞが有効な場合には処理抜け
                If mstrMaterialType = cmbMaterialType.Text Then

                    If ActiveControl.Name = cmbMaterialType.name
                        '@部材ｺﾝﾎﾞが有効か
                        If cmbMaterial.Enabled = True Then
                            '@部材にﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmbMaterial)
                        Else
                            '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                    
                    Exit Sub
                Else
                    '@退避領域と異なる場合
                
                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(CMstrFormName, CMstrCmbMaterialTypeValidate)
                                        
                                                            
                    '@部材取得
                    lblnAns = pubblnMasMaterial_Sel(CMstrmas_materialVer, _
                                                    cmbMaterialType.Text, _
                                                    mtypMaterial)
                    
                    '@結果判定
                    If lblnAns = False Then
                        '@取得失敗の場合
                    
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmbMaterialTypeValidate)
                                    
                        '@部材ｺﾝﾎﾞを無効に
                        cmbMaterial.Enabled = False
                        '@最新取得ﾎﾞﾀﾝを無効に
                        cmdNowList.Enabled = False
                        
                        '@今回選択された部材種別を退避する
                        mstrMaterialType = vbNullString
                        
                        Exit Sub
                    Else
                        '@部材取得成功の場合
                        
                        '@部材が0件か
                        If mtypMaterial.lngMaterialCnt = 0 Then
                            
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(CMstrFormName, CMstrCmbMaterialTypeValidate)
                            
                            '@MsgBox表示前にValidate処理判定ﾌﾗｸﾞをTrue(処理済み)に
                            mblnValidateFlag = True
                        
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006D, cmbMaterialType.Text)
                            '@publngMsgBoxInfo("<TRM6DI>$$部材種別[%1]に紐付く部材が存在しません。")
                            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                        
                            '@部材ｺﾝﾎﾞを無効に
                            cmbMaterial.Enabled = False
                            '@最新取得ﾎﾞﾀﾝを無効に
                            cmdNowList.Enabled = False
                            
                            '@今回選択された部材種別を退避する
                            mstrMaterialType = cmbMaterialType.Text
                                
                            '@MsgBox表示後にValidate処理判定ﾌﾗｸﾞをFalse(未処理)に初期化
                            mblnValidateFlag = False
                                
                            Exit Sub
                        Else
                            '@部材が1件以上存在する場合
                        
                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(CMstrFormName, CMstrCmbMaterialTypeValidate)
                        
                            '@部材ｺﾝﾎﾞを有効に
                            cmbMaterial.Enabled = True
                        
                            '@部材ｺﾝﾎﾞ設定
                            Call prvCmbMaterial_Disp()
                            
                            '@今回選択された部材種別を退避する
                            mstrMaterialType = cmbMaterialType.Text
                    
                            '@部材の件数ﾁｪｯｸ（件数によって処理を分岐）
                            If mtypMaterial.lngMaterialCnt = 1 Then
                                '@取得件数が1件の場合は、表示する
                                cmbMaterial.ListIndex = 0
                                
                                '@部材ｺﾝﾎﾞValidate処理へ
                                RemoveHandler cmbMaterial.Validating , AddressOf cmbMaterial_Validate 
                                Call cmbMaterial_Validate(cmbMaterial, New CancelEventArgs(True))
                                AddHandler cmbMaterial.Validating , AddressOf cmbMaterial_Validate

                            Else
                                If ActiveControl.Name = cmbMaterialType.Name 
                                    '@部材ｺﾝﾎﾞが有効か
                                    If cmbMaterial.Enabled = True Then
                                        '@部材ｺﾝﾎﾞへﾌｫｰｶｽｾｯﾄ
                                        Call pubSetFocus(cmbMaterial)
                                    End If
                                End if
                            End If
                        End If
                    End If
                End If
            End If

            '@Validate処理判定ﾌﾗｸﾞをTrue(処理済み)に
            mblnValidateFlag = True
            
            Exit Sub

        Catch ex As Exception


            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMaterialType_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMaterial_Change
    '機　能：部材ｺﾝﾎﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 10:31:22 N.Kojima
    '更新日：2006/10/24 (Tue) 10:29:34 N.Kojima
    '備　考：
    '　　　：2006/10/24 (Tue) 10:29:34 N.Kojima     部材の在庫ﾁｪｯｸ・発注管理機能追加に伴い、処理追加&修正。(案件№01095)
    Private Sub cmbMaterial_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMaterial.Change

        Try
                        
            '@退避領域と比較して同じかつ使用装置ｺﾝﾎﾞが有効な場合には処理抜け
            If mstrMaterial <> cmbMaterial.Text Then
                '@異なる場合
                
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                mtypChgSort.strKey = vbNullString
                
                '@部材一覧初期化処理
                Call prvvsfMaterialList_Init()
                
                '@各種ﾗﾍﾞﾙの初期化
                lblStockNum.Text = vbNullString              '未使用部材数
                lblOrderNum.Text = vbNullString              '発注済数
                lblOrderRemeinNum.Text = vbNullString        '発注ﾎﾟｲﾝﾄ
                lblMessage.Text = vbNullString               'ﾒｯｾｰｼﾞ
                
                '@発注ﾎﾞﾀﾝの無効化
                cmdOrder.Enabled = False
                
                '@ｺﾝﾎﾞﾎﾞｯｸｽの初期化&無効化(使用装置)
                cmbWp.Clear
                'cmbWp.Enabled = False
                
                '@退避用変数の初期化
                mstrMaterial = vbNullString         '部材
                mstrMaterialWP = vbNullString       '使用装置ID
                '@Validate処理判定ﾌﾗｸﾞをFalse(未処理)に初期化
                mblnValidateFlag = False
                
                '@最新取得ﾎﾞﾀﾝを無効に
                cmdNowList.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMaterial_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMaterial_CloseUp
    '機　能：部材ｺﾝﾎﾞのCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 10:32:32 N.Kojima
    '更新日：2006/04/14 (Fri) 10:32:32
    '備　考：
    Private Sub cmbMaterial_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMaterial.CloseUp

        Try
            
            '@空白以外の場合
            If cmbMaterial.Text <> vbNullString Then
                '@部材Validate処理呼び出し
                RemoveHandler cmbMaterial.Validating , AddressOf cmbMaterial_Validate 
                Call cmbMaterial_Validate(cmbMaterial, New CancelEventArgs(True))
                AddHandler cmbMaterial.Validating , AddressOf cmbMaterial_Validate

            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMaterial_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMaterial_LostFocus
    '機　能：部材ｺﾝﾎﾞのLostFocus時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/27 (Thu) 16:15:35 N.Kojima
    '更新日：2006/04/27 (Thu) 16:15:35
    '備　考：
    Private Sub cmbMaterial_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMaterial.Leave

        Try
            
            '@LostFocusを使用している為、MsgBoxが出た際の対応
            If mblnValidateFlag = True Then
                '@Valdate処理済みﾌﾗｸﾞを初期化し終了
                mblnValidateFlag = False
                Exit Sub
            End If

            '@退避領域と比較して同じ場合には処理抜け
            If mstrMaterial <> cmbMaterial.Text Then
                
                '@起動時の初期化時には処理を飛ばす
                If mblnFormActivateFlag = True Then
            
                    '@部材一覧初期化処理
                    Call prvvsfMaterialList_Init()
                    
                    '@部材IDが空欄でない場合
                    If cmbMaterial.Text <> vbNullString Then
                        '@部材ID_Validate処理
                        RemoveHandler cmbMaterial.Validating , AddressOf cmbMaterial_Validate 
                        Call cmbMaterial_Validate(cmbMaterial, New CancelEventArgs(True))
                        AddHandler cmbMaterial.Validating , AddressOf cmbMaterial_Validate
                    End If
                    
                End If
            End If
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMaterial_LostFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMaterial_Validate
    '機　能：部材Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 10:33:31 N.Kojima
    '更新日：2006/10/30 (Mon) 11:14:59 N.Kojima
    '備　考：
    '　　　：2006/07/04 (Tue) 14:09:40 N.Kojima     使用装置ｺﾝﾎﾞに「装置なし」追加に伴い、処理修正。(ﾕｰｻﾞｰ要望№0189)
    '　　　：2006/10/30 (Mon) 11:14:59 N.Kojima     部材の在庫ﾁｪｯｸ・発注管理機能追加に伴い、処理追加&修正。(案件№01095)
    Private Sub cmbMaterial_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbMaterial.Validating

        Dim lblnAns                 As Boolean              '使用装置取得の戻り値格納用

        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
                        
            '@LostFocusを使用している為、MsgBoxが出た際の対応
            If mblnValidateFlag = True Then
                '@Valdate処理済みﾌﾗｸﾞを初期化し終了
                mblnValidateFlag = False
                Exit Sub
            End If
            
            '@部材ｺﾝﾎﾞが選択されていない場合には処理抜け
            If cmbMaterial.Text = vbNullString Then
              
             If ActiveControl.Name = cmbMaterial.Name    

                '@使用装置ｺﾝﾎﾞが有効か
                If cmbWp.Enabled = True Then
                    '@使用装置ｺﾝﾎﾞへﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbWp)
                Else
                    '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If

             End if                
                Exit Sub
            Else
                '@退避領域と比較
                If mstrMaterial = cmbMaterial.Text Then
                  If ActiveControl.Name = cmbMaterial.Name

                        '@使用装置ｺﾝﾎﾞが有効か
                        If cmbWp.Enabled = True Then
                            '@使用装置ｺﾝﾎﾞへﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmbWp)
                        Else
                            '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdClose)
                        End If

                  End if  
                    Exit Sub
                Else
                    '@退避領域と異なる場合
                              
                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(CMstrFormName, CMstrCmbMaterialValidate)
                                        
                    
                    
                    '@使用装置取得
                    lblnAns = pubblnMasMaterialWP_Sel(CMstrmas_materialwpVer, _
                                                      cmbMaterialType.Text, _
                                                      cmbMaterial.Text, _
                                                      mtypMaterialWP)
                                    
                    '@結果判定
                    If lblnAns = False Then
                        '@取得失敗の場合
                    
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmbMaterialValidate)
                                    
                        '@使用装置ｺﾝﾎﾞを無効に
                        'cmbWp.Enabled = False
                        
                        '@今回選択された内容を退避する
                        mstrMaterialType = cmbMaterialType.Text         '部材種別
                        mstrMaterial = cmbMaterial.Text                 '部材
                        
                        Exit Sub
                    Else
                        '@使用装置取得成功＆使用装置が存在する場合
                    
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(CMstrFormName, CMstrCmbMaterialValidate)
                        
                        '@使用装置ｺﾝﾎﾞ設定
                        Call prvCmbMaterialWP_Disp()
                        
                        '@使用装置ｺﾝﾎﾞを有効に
                        cmbWp.Enabled = True
                        
                        '@今回選択された内容を退避する
                        mstrMaterialType = cmbMaterialType.Text         '部材種別
                        mstrMaterial = cmbMaterial.Text                 '部材
            
                        '@使用装置の件数ﾁｪｯｸ（件数によって処理を分岐）
                        If mtypMaterialWP.lngMaterialWPCnt = 0 Or _
                            mtypMaterialWP.lngMaterialWPCnt = 1 Then
                            
                            '@取得件数が1件の場合、直接表示
                            cmbWp.ListIndex = 0
                            
                            '@使用装置ｺﾝﾎﾞへﾌｫｰｶｽｾｯﾄ
                            'Call pubSetFocus(cmbWp)
                            
                            '@使用装置ｺﾝﾎﾞValidate処理へ
                            RemoveHandler cmbWP.Validating, AddressOf cmbWp_Validate 
                            Call cmbWp_Validate(cmbWp, New CancelEventArgs(false))
                            AddHandler cmbWP.Validating, AddressOf cmbWp_Validate 
                        Else
                            '@使用装置が複数存在する場合
                            
                           If ActiveControl.Name = cmbMaterial.name 
                                '@使用装置ｺﾝﾎﾞが有効か
                                If cmbWp.Enabled = True Then
                                    '@使用装置ｺﾝﾎﾞへﾌｫｰｶｽｾｯﾄ
                                    Call pubSetFocus(cmbWp)
                                End If
                           End if
                        End If
                    End If
                End If
            End If
            
            '@Validate処理判定ﾌﾗｸﾞをTrue(処理済み)に
            mblnValidateFlag = True
            
            Exit Sub

        Catch ex As Exception


            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMaterial_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWP_Change
    '機　能：使用装置ｺﾝﾎﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 11:27:48 N.Kojima
    '更新日：2006/10/24 (Tue) 10:29:11 N.Kojima
    '備　考：
    '　　　：2006/06/26 (Mon) 17:14:46 N.Kojima     ｺﾝﾎﾞに"装置なし"追加に伴い、ﾎﾞﾀﾝの制御を追加。(ﾕｰｻﾞｰ要望№0189)
    '　　　：2006/10/24 (Tue) 10:29:11 N.Kojima     部材の在庫ﾁｪｯｸ・発注管理機能追加に伴い、処理追加&修正。(案件№01095)
    Private Sub cmbWp_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWp.Change

        Try
                        
            '@使用装置がNULLの場合は「発注」ﾎﾞﾀﾝを無効に
            If cmbWp.Value = vbNullString Then
                '@「発注」ﾎﾞﾀﾝを無効に
                cmdOrder.Enabled = False
            End If
            
            '@退避領域と比較して同じ場合には処理抜け
            If mstrMaterialWP <> cmbWp.Value Then
                '@異なる場合
                
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                mtypChgSort.strKey = vbNullString
                
                '@部材一覧初期化処理
                Call prvvsfMaterialList_Init()
                               
                '@各種ﾗﾍﾞﾙの初期化
                lblStockNum.Text = vbNullString              '未使用部材数
                lblOrderNum.Text = vbNullString              '発注済数
                lblOrderRemeinNum.Text = vbNullString        '発注ﾎﾟｲﾝﾄ
                lblMessage.Text = vbNullString               'ﾒｯｾｰｼﾞ
                        
                '@"装置なし"が選択された場合
                If cmbWp.Text = CMstrNoWP Then
                    '@各種ﾎﾞﾀﾝの表示/非表示を再設定する
                    cmdUseWPMain.Visible = True         '表示　:装置使用開始/解除
                    cmdUseWP.Visible = False            '非表示:装置使用開始
                    cmdUseWPCancel.Visible = False      '非表示:装置使用解除
                End If
                        
                '@退避用変数の初期化
                mstrMaterialWP = vbNullString       '使用装置ID
                '@Validate処理判定ﾌﾗｸﾞをFalse(未処理)に初期化
                mblnValidateFlag = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWP_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWP_CloseUp
    '機　能：使用装置ｺﾝﾎﾞのCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 11:28:54 N.Kojima
    '更新日：2006/10/24 (Tue) 15:09:08 N.Kojima
    '備　考：
    '　　　：2006/10/24 (Tue) 15:09:08 N.Kojima     部材の在庫ﾁｪｯｸ・発注管理機能追加に伴い、処理追加&修正。(案件№01095)
    Private Sub cmbWp_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWp.CloseUp

        Try
            
            '@空白以外の場合
            If cmbWp.Text <> vbNullString Then
                '@使用装置Validate処理呼び出し                
                RemoveHandler cmbWP.Validating, AddressOf cmbWp_Validate 
                Call cmbWp_Validate(cmbWp, New CancelEventArgs(True))
                AddHandler cmbWP.Validating, AddressOf cmbWp_Validate 
                
                '@部材種別と部材が選択されている場合
                If cmbMaterialType.Text <> vbNullString And _
                    cmbMaterial.Text <> vbNullString Then
                    
                    '@発注ﾎﾞﾀﾝを有効にする
                    cmdOrder.Enabled = True
                Else
                    '@発注ﾎﾞﾀﾝを無効にする
                    cmdOrder.Enabled = False
                End If
            
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWP_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWP_LostFocus
    '機　能：使用装置ｺﾝﾎﾞのLostFocus時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/27 (Thu) 16:17:22 N.Kojima
    '更新日：2006/04/27 (Thu) 16:17:22
    '備　考：
    Private Sub cmbWP_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWP.Leave

        Try

            '@LostFocusを使用している為、MsgBoxが出た際の対応
            If mblnValidateFlag = True Then
                '@Valdate処理済みﾌﾗｸﾞを初期化し終了
                mblnValidateFlag = False
                Exit Sub
            End If

            '@退避領域と比較して同じ場合には処理抜け
            If mstrMaterialWP <> cmbWp.Value Then
                
                '@起動時の初期化時には処理を飛ばす
                If mblnFormActivateFlag = True Then
            
                    '@部材一覧初期化処理
                    Call prvvsfMaterialList_Init()
                    
                    '@使用装置が空欄でない場合
                    If cmbWp.Text <> vbNullString Then
                        '@使用装置_Validate処理
                        RemoveHandler cmbWP.Validating, AddressOf cmbWp_Validate 
                        Call cmbWp_Validate(cmbWp, New CancelEventArgs(True))
                        AddHandler cmbWP.Validating, AddressOf cmbWp_Validate 
                    End If
                    
                End If
            End If
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWP_LostFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbWP_Validate
    '機　能：使用装置Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 11:31:29 N.Kojima
    '更新日：2006/10/23 (Mon) 16:57:33 N.Kojima
    '備　考：
    '　　　：2006/06/26 (Mon) 17:21:47 N.Kojima     "装置なし"が選択された場合の処理を追加。(ﾕｰｻﾞｰ要望№0189)
    '　　　：2006/10/23 (Mon) 16:57:33 N.Kojima     部材の在庫ﾁｪｯｸ・発注管理機能追加に伴い、処理追加&修正。(案件№01095)
    Private Sub cmbWp_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbWp.Validating

        Dim lblnAns             As Boolean              '使用装置取得の戻り値格納用

        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            
            '@LostFocusを使用している為、MsgBoxが出た際の対応
            If mblnValidateFlag = True Then
                '@Valdate処理済みﾌﾗｸﾞを初期化し終了
                mblnValidateFlag = False
                Exit Sub
            End If
            
            '@使用装置ｺﾝﾎﾞが選択されていない場合には処理抜け
            If cmbWp.Text = vbNullString Then
               If ActiveControl.Name = cmbWP.Name 
                    '@部材一覧が有効か
                    If vsfMaterialList.Enabled = True Then
                        '@部材一覧へﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfMaterialList)
                    Else
                        '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
               End if
                
                '@無条件で「発注」ﾎﾞﾀﾝを無効にする
                cmdOrder.Enabled = False
                
                Exit Sub
            
            Else
                
                '@退避領域と比較
                If mstrMaterialWP = cmbWp.Value And cmbWp.Value <> vbNullString Then
                   If ActiveControl.Name = cmbWP.Name 
                        '@部材一覧が有効か
                        If vsfMaterialList.Enabled = True Then
                            '@部材一覧へﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(vsfMaterialList)
                        Else
                            '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdClose)
                        End If
                   End if 

                    Exit Sub
                Else
                    '@退避領域と異なる場合
                    
                    '@ﾚｽﾎﾟﾝｽ取得開始
                    Call pubResponseStart(CMstrFormName, CMstrCmbMaterialValidate)
                                                            
                    Me.KeyPreview = False
                    
                    '@部材一覧取得
                    lblnAns = pubblnMatAllList_Sel(CMstrmat_alllist_Ver, _
                                                   cmbMaterialType.Text, _
                                                   cmbMaterial.Text, _
                                                   cmbWp.Value, _
                                                   mtypMaterialAll)
                                                   
                    Me.KeyPreview = True
                    
                    '@結果判定
                    If lblnAns = False Then
                        '@取得失敗の場合
                    
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmbMaterialValidate)
                        
                        '@ﾓｼﾞｭｰﾙ変数へ退避
                        mstrMaterialType = cmbMaterialType.Text     '部材種別
                        mstrMaterial = cmbMaterial.Text             '部材
                        mstrMaterialWP = cmbWp.Value                '使用装置ID
                        
                        Exit Sub
                    Else
                        '@部材一覧取得成功の場合
                        
                        '@最新取得ﾎﾞﾀﾝを有効に
                        cmdNowList.Enabled = True
                        
                        '@無条件で発注ﾎﾞﾀﾝを有効にする
                        cmdOrder.Enabled = True
                        
                        '@最新情報取得日時の時間設定
                        lblNowDate.Text = Format$(Now, CPstrDateFormat)
                        '@表示件数の初期化
                        If mtypMaterialAll.lngMaterialAllCnt = 0 Then
                            '@"0"を表示
                            lblMaterialCnt.Text = CPstrZero
                        Else
                            '@ﾌｫｰﾏｯﾄして表示
                            lblMaterialCnt.Text = Format$(mtypMaterialAll.lngMaterialAllCnt, CPstrCFKnmaFormat)
                        End If
                        
                        '@部材一覧が0件か
                        If mtypMaterialAll.lngMaterialAllCnt = 0 Then
                            
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(CMstrFormName, CMstrCmbMaterialValidate)
                        
                            '@装置使用部材在庫ﾁｪｯｸ&表示処理
                            Call prvblnMaterialStock_Disp()
                        
                            '@各種ﾗﾍﾞﾙに情報表示
                            '@ﾒｰｶｰ保証期間
                            If IsNumeric(mtypMaterialAll.strVenderWarrantDays)
                                lblVenderWarrantDays.Text = _
                                    Format$(Double.Parse(mtypMaterialAll.strVenderWarrantDays), CPstrCFKnmaFormat)
                            End if
                            '@受入制限期間
                            If IsNumeric(mtypMaterialAll.strAcceptWarrantDays)
                                lblAcceptWarrantDays.Text = _
                                    Format$(Double.Parse(mtypMaterialAll.strAcceptWarrantDays), CPstrCFKnmaFormat)
                            End if
        '@↓2009/09/28 (Mon) 13:33:36 T.Oide **************************************************
                            '@単位(ﾒｰｶｰ保証期間)
                            If mtypMaterialAll.strUnitClassVwd = CMstrUnitClassM Then
                                lblDay1.Text = CMstrUnitM
                            Else
                                lblDay1.Text = CMstrUnitD
                            End If
                            '@単位(受入制限期間)
                            If mtypMaterialAll.strUnitClassAwd = CMstrUnitClassM Then
                                lblDay2.Text = CMstrUnitM
                            Else
                                lblDay2.Text = CMstrUnitD
                            End If
        '@↑2009/09/28 (Mon) 13:33:36 T.Oide **************************************************
                            '@使用可能時間
                            If IsNumeric(mtypMaterialAll.strUseValidPeriod)
                                lblUseValidPeriod.Text = _
                                    Format$(Double.Parse(mtypMaterialAll.strUseValidPeriod), CPstrCFKnmaFormat)
                            End if
                            '@使用禁止(不可)時間
                            If IsNumeric(mtypMaterialAll.strUseInvalidPeriod)
                                lblUseInvalidPeriod.Text = _
                                    Format$(Double.Parse(mtypMaterialAll.strUseInvalidPeriod), CPstrCFKnmaFormat)
                            End if
                            '@ﾜｰﾆﾝｸﾞ表示時間
                            If IsNumeric(mtypMaterialAll.strWarningPeriod)
                                lblWarningPeriod.Text = _
                                    Format$(Double.Parse(mtypMaterialAll.strWarningPeriod), CPstrCFKnmaFormat)
                            End if
                            'NSYS 
                            vsfMaterialList.Row = 0
                            '@部材一覧を無効に
                            vsfMaterialList.Enabled = False
                           
                            '@今回選択された内容を退避する
                            mstrMaterialType = cmbMaterialType.Text     '部材種別
                            mstrMaterial = cmbMaterial.Text             '部材
                            mstrMaterialWP = cmbWp.Value                '使用装置ID
                            
                            '@発注ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdOrder)
                            
                            Exit Sub
                        Else
                            '@部材一覧が存在する場合
                        
                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(CMstrFormName, CMstrCmbMaterialValidate)
                        
                            '@装置使用部材在庫ﾁｪｯｸ&表示処理
                            Call prvblnMaterialStock_Disp()
                        
                            '@部材一覧設定
                            Call prvvsfMaterialList_Disp()
                            
                            '@今回選択された内容を退避する
                            mstrMaterialType = cmbMaterialType.Text     '部材種別
                            mstrMaterial = cmbMaterial.Text             '部材
                            mstrMaterialWP = cmbWp.Value                '使用装置ID
                           
                            If ActiveControl.Name = cmbWP.Name 
                               '@部材一覧が有効か
                                If vsfMaterialList.Enabled = True Then
                                    '@部材一覧へﾌｫｰｶｽｾｯﾄ
                                    Call pubSetFocus(vsfMaterialList)
                                Else
                                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                                    Call pubSetFocus(cmdClose)
                                End If
                            End if
                        End If
                    End If
                End If
            End If
            
            '@Validate処理判定ﾌﾗｸﾞをTrue(処理済み)に
            mblnValidateFlag = True
            
            Exit Sub

        Catch ex As Exception

            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbWP_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMaterialList_AfterSort
    '機　能：部材一覧Sort後処理
    '引　数：Col    ：ｿｰﾄ列
    '　　　：Order  ：ｿｰﾄ方法
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 13:56:37 N.Kojima
    '更新日：2006/04/14 (Fri) 13:56:37
    '備　考：
    Private Sub vsfMaterialList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfMaterialList.AfterSort

        Try
            AddHandler vsfMaterialList.BeforeRowColChange, AddressOf vsfMaterialList_BeforeRowColChange
                        
            'NSYS データ行がない場合は処理を抜ける
            If vsfMaterialList.Rows.Count <= vsfMaterialList.Rows.Fixed Then
                Return
            End If
            

             '@ｿｰﾄ順を格納
            With mtypChgSort
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                Dim typChgSortListTmp As ChgSortList = New ChgSortList
                '@ｿｰﾄ列番号を格納
                typChgSortListTmp.lngCol = e.Col
                '@並び替え方法を格納（昇順/降順）
                typChgSortListTmp.lngOrder = e.Order
                .typChgSortList.Add(typChgSortListTmp)
            End With
            
            '@ｿｰﾄ後のｶﾚﾝﾄ行設定（ｸﾞﾘｯﾄﾞ、保持列）
            Call pubVsfAfterSort(vsfMaterialList, CMlngvsfMaterialListLRowTitle, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMaterialList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMaterialList_AfterUserResize
    '機　能：ｸﾞﾘｯﾄﾞｻｲｽﾞ変更処理
    '引　数：Row：変更行
    '　　　：Col：変更列
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 13:58:12 N.Kojima
    '更新日：2007/07/09 (Mon) 15:43:10 N.Kasai
    '備　考：
    '　　　：2007/07/09 (Mon) 15:43:10 N.Kasai  ｸﾞﾘｯﾄﾞ共通
    Private Sub vsfMaterialList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfMaterialList.AfterResizeColumn, vsfMaterialList.AfterResizeRow
        
    '    Dim llngCnt         As Long         'ｶｳﾝﾄ
    '    Dim llngWidthAll    As Long         'ｸﾞﾘｯﾄﾞ幅
        
        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfMaterialList.Rows.Count <= vsfMaterialList.Rows.Fixed Then
                Return
            End If
            
            
            '@列幅変更フラグ（変更）
            mtypChgSort.blnChgWidth = True
            
            '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御（ｸﾞﾘｯﾄﾞ共通化関数）
            Call pubCmdLREnable_Set(vsfMaterialList, cmdLeft, cmdRight)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMaterialList_AfterUserResize"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMaterialList_BeforeRowColChange
    '機　能：ｸﾞﾘｯﾄﾞColﾌｫｰｶｽ移動前処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 13:58:58 N.Kojima
    '更新日：2006/04/14 (Fri) 13:58:58
    '備　考：
    Private Sub vsfMaterialList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfMaterialList.BeforeRowColChange

        Try
                        
            'NSYS データ行がない場合は処理を抜ける
            If vsfMaterialList.Rows.Count <= vsfMaterialList.Rows.Fixed Then
                Return
            End If
            
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納（№）
                mtypChgSort.strKey = vsfMaterialList.GetData(e.NewRange.r1, CMlngvsfMaterialListColMaterialLotID)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMaterialList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMaterialList_BeforeSort
    '機　能：部材一覧Sort前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ順
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 14:00:20 N.Kojima
    '更新日：2006/04/14 (Fri) 14:00:20
    '備　考：
    Private Sub vsfMaterialList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfMaterialList.BeforeSort

        Try
            RemoveHandler vsfMaterialList.BeforeRowColChange, AddressOf vsfMaterialList_BeforeRowColChange 

            'NSYS データ行がない場合は処理を抜ける
            If vsfMaterialList.Rows.Count <= vsfMaterialList.Rows.Fixed Then
                Return
            End If
            

            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列）
            Call pubVsfBeforeSort(vsfMaterialList, CMlngvsfMaterialListLRowTitle)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMaterialList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfMaterialList_RowColChange
    '機　能：ｸﾞﾘｯﾄﾞの行変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 14:01:29 N.Kojima
    '更新日：2006/10/24 (Tue) 10:57:34 N.Kojima
    '備　考：
    '　　　：2006/06/23 (Fri) 15:08:58 N.Kojima     部材日付変更機能追加に伴い、処理修正。(ﾕｰｻﾞｰ要望№0189)
    '　　　：2006/09/14 (Thu) 09:27:21 N.Kojima     使用不可部材選択時でも「部材日付変更」ﾎﾞﾀﾝを有効にする。(案件№01503)
    '　　　：2006/10/24 (Tue) 10:57:34 N.Kojima     部材の在庫ﾁｪｯｸ・発注管理機能追加に伴い、処理追加&修正。(案件№01095)
    '　　　：2008/01/17 (Thu) 18:17:00 S.Ochiai     保留処理追加(案件№02463)及びﾛｼﾞｯｸ見直し実施。
    Private Sub vsfMaterialList_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfMaterialList.RowColChange

        Try
                                 
            '@各種ﾎﾞﾀﾝの使用可否ﾁｪｯｸ
            With vsfMaterialList
                
                '@ﾃﾞｰﾀが存在しない場合及びﾃﾞｰﾀ行以外が選択された場合
                '@(ﾃﾞｰﾀ行以外が選択された場合は本ｲﾍﾞﾝﾄは発生しないが念の為)
                If .Rows.Count <= 1 Or _
                   .Row = 0 Then
                    
                    '@各種ﾎﾞﾀﾝを無効化(発注/閉じるﾎﾞﾀﾝは除く)
                    cmdAccept.Enabled = False                   '無効　:受入
                    cmdStartUse.Enabled = False                 '無効　:使用開始
                    cmdUseWPMain.Visible = True                 '表示　:装置使用開始/解除
                    cmdUseWP.Visible = False                    '非表示:装置使用開始
                    cmdUseWPCancel.Visible = False              '非表示:装置使用解除
                    cmdHoldMain.Visible = True                  '表示　:保留/保留解除
                    cmdHold.Visible = False                     '非表示:保留
                    cmdHoldCancel.Visible = False               '非表示:保留解除
                    cmdDivide.Enabled = False                   '無効　:分割
                    cmdScrap.Enabled = False                    '無効　:廃棄
                    cmdInvalid.Enabled = False                  '無効　:間違え
                    cmdMaterialDateChg.Enabled = False          '無効　:部材日時変更
                    Exit Sub
                End If
                
                '@保留中の場合
                If .GetData(.Row, CMlngvsfMaterialListColStatus) = CMstrHoldStatus Then
                    cmdAccept.Enabled = False                   '無効　:受入
                    cmdStartUse.Enabled = False                 '無効　:使用開始
                    cmdUseWPMain.Visible = True                 '表示　:装置使用開始/解除
                    cmdUseWP.Visible = False                    '非表示:装置使用開始
                    cmdUseWPCancel.Visible = False              '非表示:装置使用解除
                    cmdHoldMain.Visible = False                 '非表示:保留/保留解除
                    cmdHold.Visible = False                     '非表示:保留
                    cmdHoldCancel.Visible = True                '表示　:保留解除
                    cmdDivide.Enabled = False                   '無効　:分割
                    cmdScrap.Enabled = True                     '有効　:廃棄
                    cmdInvalid.Enabled = False                  '無効　:間違え
                    cmdMaterialDateChg.Enabled = False          '無効　:部材日時変更
                Else
                    '@部材の状態に応じて各種ﾎﾞﾀﾝを有効/無効を切替
                    Select Case .GetData(.Row, CMlngvsfMaterialListColMaterialStatus)
                    
                        '@発注済の場合
                        Case CMstrStatusOrd
                            cmdAccept.Enabled = True                    '有効　:受入
                            cmdStartUse.Enabled = False                 '無効　:使用開始
                            cmdUseWPMain.Visible = True                 '表示　:装置使用開始/解除
                            cmdUseWP.Visible = False                    '非表示:装置使用開始/解除
                            cmdUseWPCancel.Visible = False              '非表示:装置使用開始/解除
                            cmdHoldMain.Visible = True                  '表示　:保留/保留解除
                            cmdHold.Visible = False                     '非表示:保留
                            cmdHoldCancel.Visible = False               '非表示:保留解除
                            cmdDivide.Enabled = False                   '無効　:分割
                            cmdScrap.Enabled = True                     '有効　:廃棄
                            cmdInvalid.Enabled = True                   '有効　:間違え
                            cmdMaterialDateChg.Enabled = False          '無効　:部材日時変更
                    
                        '@受入済の場合
                        Case CMstrStatusAcc
                            cmdAccept.Enabled = False                   '無効　:受入
                            cmdStartUse.Enabled = True                  '有効　:使用開始
                            cmdUseWPMain.Visible = True                 '表示　:装置使用開始/解除
                            cmdUseWP.Visible = False                    '非表示:装置使用開始/解除
                            cmdUseWPCancel.Visible = False              '非表示:装置使用開始/解除
                            cmdHoldMain.Visible = False                 '非表示:保留/保留解除
                            cmdHold.Visible = True                      '表示　:保留
                            cmdHoldCancel.Visible = False               '非表示:保留解除
                            cmdDivide.Enabled = True                    '有効　:分割
                            cmdScrap.Enabled = True                     '有効　:廃棄
                            cmdInvalid.Enabled = True                   '有効　:間違え
                            cmdMaterialDateChg.Enabled = False          '無効　:部材日時変更
                    
                        '@使用中の場合
                        Case CMstrStatusUse
                            cmdAccept.Enabled = False                   '無効　:受入
                            cmdStartUse.Enabled = False                 '無効　:使用開始
                            '@"装置なし"の場合または使用禁止期間の場合
                            If cmbWp.Text = CMstrNoWP Or _
                               .Getdata(.Row, CMlngvsfMaterialListColUseInvalidPeriodJudge) = 1 Then
                                cmdUseWPMain.Visible = True             '表示　:装置使用開始/解除
                                cmdUseWP.Visible = False                '非表示:装置使用開始
                                cmdUseWPCancel.Visible = False          '非表示:装置使用解除
                            Else
                                cmdUseWPMain.Visible = False            '非表示:装置使用開始/解除
                                cmdUseWP.Visible = True                 '表示　:装置使用開始
                                cmdUseWPCancel.Visible = False          '非表示:装置使用解除
                            End If
                            cmdHoldMain.Visible = False                 '非表示:保留/保留解除
                            cmdHold.Visible = True                      '表示　:保留
                            cmdHoldCancel.Visible = False               '非表示:保留解除
                            cmdDivide.Enabled = True                    '有効　:分割
                            cmdScrap.Enabled = True                     '有効　:廃棄
                            cmdInvalid.Enabled = False                  '無効　:間違え
                            cmdMaterialDateChg.Enabled = True           '有効　:部材日時変更
                            
                        '@装置使用中の場合
                        Case CMstrStatusSet
                            cmdAccept.Enabled = False                   '無効　:受入
                            cmdStartUse.Enabled = False                 '無効　:使用開始
                            cmdUseWPMain.Visible = False                '非表示:装置使用開始/解除
                            cmdUseWP.Visible = False                    '非表示:装置使用開始
                            cmdUseWPCancel.Visible = True               '表示　:装置使用解除
                            cmdHoldMain.Visible = True                  '表示　:保留/保留解除
                            cmdHold.Visible = False                     '非表示:保留解除
                            cmdHold.Visible = False                     '非表示:保留解除
                            cmdDivide.Enabled = True                    '有効　:分割
                            cmdScrap.Enabled = True                     '有効　:廃棄
                            cmdInvalid.Enabled = False                  '無効　:間違え
                            cmdMaterialDateChg.Enabled = True           '有効　:部材日時変更
                    
                        '@その他の場合 (現状このﾊﾟﾀｰﾝはありえない)
                        Case Else
                            cmdAccept.Enabled = False                   '無効:受入
                            cmdStartUse.Enabled = False                 '無効:使用開始
                            cmdUseWPMain.Visible = True                 '表示　:装置使用開始/解除
                            cmdUseWP.Visible = False                    '非表示:装置使用開始
                            cmdUseWPCancel.Visible = False              '非表示:装置使用解除
                            cmdHoldMain.Visible = False                 '非表示:保留/保留解除
                            cmdHold.Visible = False                     '非表示:保留解除
                            cmdHold.Visible = False                     '非表示:保留解除
                            cmdDivide.Enabled = False                   '無効:分割
                            cmdScrap.Enabled = False                    '無効:廃棄
                            cmdInvalid.Enabled = False                  '無効　:間違え
                            cmdMaterialDateChg.Enabled = False          '無効:部材日時変更
                    
                    End Select
                End If
                
                '@各種ﾗﾍﾞﾙに情報表示
                '@ﾒｰｶｰ保証期間
                If IsNumeric(.GetData(.Row, CMlngvsfMaterialListColVenderWarrantDays))
                    lblVenderWarrantDays.Text = _
                        Format$(Double.Parse(.GetData(.Row, CMlngvsfMaterialListColVenderWarrantDays)), CPstrCFKnmaFormat)
                End If
                

                '@受入制限期間
                If IsNumeric(.GetData(.Row, CMlngvsfMaterialListColAcceptWarrantDays))
                    lblAcceptWarrantDays.Text = _
                        Format$(Double.Parse(.GetData(.Row, CMlngvsfMaterialListColAcceptWarrantDays)), CPstrCFKnmaFormat)
                End if

                If IsNumeric(.GetData(.Row, CMlngvsfMaterialListColUseValidPeriod))
                    '@使用可能時間
                    lblUseValidPeriod.Text = _
                        Format$(Double.Parse(.GetData(.Row, CMlngvsfMaterialListColUseValidPeriod)), CPstrCFKnmaFormat)
                End if

                If IsNumeric(.GetData(.Row, CMlngvsfMaterialListColUseInvalidPeriod))
                    '@使用禁止(不可)時間
                    lblUseInvalidPeriod.Text = _
                        Format$(Double.Parse(.GetData(.Row, CMlngvsfMaterialListColUseInvalidPeriod)), CPstrCFKnmaFormat)
                End if

                '@ﾜｰﾆﾝｸﾞ表示時間
                If IsNumeric(.GetData(.Row, CMlngvsfMaterialListColWarningPeriod))
                    lblWarningPeriod.Text = _
                        Format$(Double.Parse(.GetData(.Row, CMlngvsfMaterialListColWarningPeriod)), CPstrCFKnmaFormat)
                End if

            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfMaterialList_RowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNowList_Click
    '機　能：最新取得
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 13:48:06 N.Kojima
    '更新日：2006/10/24 (Tue) 15:54:21 N.Kojima
    '備　考：
    '　　　：2006/10/24 (Tue) 15:54:21 N.Kojima     部材の在庫ﾁｪｯｸ・発注管理機能追加に伴い、処理追加&修正。(案件№01095)
    Private Sub cmdNowList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowList.Click

        Dim lblnAns                 As Boolean              '戻り値判定用

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

            '@ﾌｫｰﾑﾛｯｸ中の場合は処理を受け付けない
            If Me.Enabled = False Then
                Exit Sub
            End If
            
            '@初期化(部材一覧格納構造体)
            If mtypMaterialAll.typMaterialAllList Is Nothing 
               mtypMaterialAll.typMaterialAllList = New List(Of MaterialAllList) 
            Else 
                mtypMaterialAll.typMaterialAllList.Clear()
            End If
            mtypMaterialAll.lngMaterialAllCnt = 0
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdNowListClick)
            
            
            Me.KeyPreview = False
            
            '@部材一覧取得
            lblnAns = pubblnMatAllList_Sel(CMstrmat_alllist_Ver, _
                                           cmbMaterialType.Text, _
                                           cmbMaterial.Text, _
                                           cmbWp.Value, _
                                           mtypMaterialAll)
                                                    

            Me.KeyPreview = True
                                           
            '@結果判定
            If lblnAns = False Then
                '@部材一覧取得に失敗
                
                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdNowListClick)
                
                '@部材一覧の初期化
                Call prvvsfMaterialList_Init()
                
                '@最新情報取得日時の時間設定
                lblNowDate.Text = Format$(Now, CPstrDateFormat)
                '@表示件数の初期化
                lblMaterialCnt.Text = CPstrZero
                
                Exit Sub
            End If
                        
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrCmdNowListClick)
                        
            '@部材在庫状態(発注ﾎﾟｲﾝﾄとの数量関係)の再表示
            Call prvblnMaterialStock_Disp()
            
            '@部材一覧表示情報
            Call prvvsfMaterialList_Disp()
            
            '@最新情報取得日時の時間設定
            lblNowDate.Text = Format$(Now, CPstrDateFormat)
            '@表示件数の初期化
            If mtypMaterialAll.lngMaterialAllCnt = 0 Then
                '@"0"を表示
                lblMaterialCnt.Text = CPstrZero
            Else
                '@ﾌｫｰﾏｯﾄして表示
                lblMaterialCnt.Text = Format$(mtypMaterialAll.lngMaterialAllCnt, CPstrCFKnmaFormat)
            End If
                    
            Exit Sub

        Catch ex As Exception

            Me.KeyPreview = True

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

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ押下でのﾌﾟﾛｸﾞﾗﾑ終了
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 14:03:10 N.Kojima
    '更新日：2006/04/14 (Fri) 14:03:10
    '備　考：なし
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
            Call publngEnd_Proc(CPstrKeyEN01V0, ltypCommonInfo)
            
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

    '関数名：cmdOrder_Click
    '機　能：装置使用部材発注画面起動処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/10/24 (Tue) 11:27:43 N.Kojima
    '更新日：2007/06/14 (Thu) 12:33:57 N.Kasai
    '備　考：
    '　　　：2007/06/14 (Thu) 12:33:57 N.Kasai  発注方法変更（№01941）
    Private Sub cmdOrder_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdOrder.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
                
            '@引継ぎ用構造体に引継ぎ情報を格納
            With vsfMaterialList
                ptypRegMaterial.strMaterialTypeID = cmbMaterialType.Text        '部材種別ID
                ptypRegMaterial.strMaterialID = cmbMaterial.Text                '部材ID
                ptypRegMaterial.strEditTime = vbNullString                      '最終更新日時
            End With

            '@子画面名称設定(装置使用部材発注)
            frmxxEN01V1.Instance.Text = CPstrSubFormOrder
            
            '@引継ぎ変数初期化
            pstrMakeMaterialOrderID = vbNullString
            
            '@装置使用部材登録画面起動
            frmxxEN01V1.Instance.ShowDialog(Me)
            frmxxEN01V1.Instance = Nothing
            
            '@引継ぎ用構造体を初期化する
            With ptypRegMaterial
                .strMaterialTypeID = vbNullString       '部材種別ID
                .strMaterialID = vbNullString           '部材ID
                .strEditTime = vbNullString             '最終更新日時
            End With
            
            '@部材発注/登録/分割判定ﾌﾗｸﾞにより処理を分岐(True:登録、False:未登録)
            If pblnMaterialRegistFlag = True Then
                
                '@引継ぎが存在する場合
                If pstrMakeMaterialOrderID <> vbNullString Then
                    mtypChgSort.strKey = pstrMakeMaterialOrderID
                End If
                
                '@最新情報を取得し直す
                Call cmdNowList_Click(sender,New EventArgs)
            End If
            
            '@部材発注/登録/分割判定ﾌﾗｸﾞを初期化
            pblnMaterialRegistFlag = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdOrder_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdAccept_Click
    '機　能：装置使用部材登録画面起動処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 14:09:14 N.Kojima
    '更新日：2006/10/24 (Tue) 15:12:30 N.Kojima
    '備　考：
    '　　　：2006/06/27 (Tue) 21:10:36 N.Kojima     構造体に装置ID追加。(ﾕｰｻﾞｰ要望№0189)
    '　　　：2006/10/24 (Tue) 15:12:30 N.Kojima     部材の在庫ﾁｪｯｸ・発注管理機能追加に伴い、処理追加&修正。(案件№01095)
    '　　　：2008/01/18 (Fri) 13:48:00 S.Ochiai     処理後のﾃﾞﾌｫﾙﾄﾌｫｰｶｽ(pstrMakeMaterialLotID)
    Private Sub cmdAccept_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAccept.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
                
            '@引継ぎ用構造体に引継ぎ情報を格納
            With vsfMaterialList
                ptypRegMaterial.strMaterialTypeID = cmbMaterialType.Text            '部材種別ID
                ptypRegMaterial.strMaterialID = cmbMaterial.Text                    '部材ID
                ptypRegMaterial.strMaterialOrderID = _
                    .GetData(.Row, CMlngvsfMaterialListColMaterialLotID)   '発注ID
                ptypRegMaterial.strProductionDate = vbNullString                    '製造日
                ptypRegMaterial.strAcceptanceDate = Format$(Now, CPstrDateTimeYMD)  '受入日
                ptypRegMaterial.strEditTime = vbNullString                          '最終更新日時
                ptypRegMaterial.strWpID = cmbWp.Value                               '装置ID
            End With

            '@子画面名称設定(装置使用部材登録)
            frmxxEN01V1.Instance.Text = CPstrSubFormRegist
            
            '@装置使用部材登録画面起動
            frmxxEN01V1.Instance.ShowDialog(Me)
            frmxxEN01V1.Instance = Nothing
            
            '@引継ぎ用構造体を初期化する
            With ptypRegMaterial
                .strMaterialTypeID = vbNullString       '部材種別ID
                .strMaterialID = vbNullString           '部材ID
                .strMaterialOrderID = vbNullString      '発注ID
                .strProductionDate = vbNullString       '製造日
                .strAcceptanceDate = vbNullString       '受入日
                .strEditTime = vbNullString             '最終更新日時
                .strWpID = vbNullString                 '装置ID
            End With
            
            '@部材登録/分割判定ﾌﾗｸﾞにより処理を分岐(True:登録、False:未登録)
            If pblnMaterialRegistFlag = True Then
            
                '@引継ぎが存在する場合
                If pstrMakeMaterialLotID <> vbNullString Then
                    mtypChgSort.strKey = pstrMakeMaterialLotID
                End If
                
                '@最新情報を取得し直す
                Call cmdNowList_Click(sender, New EventArgs)
            End If
            
            '@部材登録/分割判定ﾌﾗｸﾞを初期化
            pblnMaterialRegistFlag = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdAccept_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDivide_Click
    '機　能：装置使用部材分割画面起動処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 15:02:37 N.Kojima
    '更新日：2006/10/24 (Tue) 17:23:39 N.Kojima
    '備　考：
    '　　　：2006/06/27 (Tue) 21:11:52 N.Kojima     構造体に装置ID,使用開始日時を追加。(ﾕｰｻﾞｰ要望№0189)
    '　　　：2006/10/24 (Tue) 17:23:39 N.Kojima     部材の在庫ﾁｪｯｸ・発注管理機能追加に伴い、処理追加&修正。(案件№01095)
    Private Sub cmdDivide_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDivide.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
                
            '@引継ぎ用構造体に引継ぎ情報を格納
            With vsfMaterialList
                ptypRegMaterial.strMaterialTypeID = cmbMaterialType.Text                                            '部材種別ID
                ptypRegMaterial.strMaterialID = cmbMaterial.Text                                                    '部材ID
                ptypRegMaterial.strMaterialLotID = .GetData(.Row, CMlngvsfMaterialListColMaterialLotID)    '部材管理ID
                ptypRegMaterial.strProductionDate = .GetData(.Row, CMlngvsfMaterialListColProductionDate)  '製造日
                ptypRegMaterial.strAcceptanceDate = .GetData(.Row, CMlngvsfMaterialListColAcceptanceDate)  '受入日
                ptypRegMaterial.strEditTime = .GetData(.Row, CMlngvsfMaterialListColLastUpdate)            '最終更新日時
                ptypRegMaterial.strWpID = cmbWp.Value                                                               '装置ID
                ptypRegMaterial.strUseTime = .GetData(.Row, CMlngvsfMaterialListColUseTime)                '使用開始日時
            End With

            '@子画面名称設定(装置使用部材分割)
            frmxxEN01V1.Instance.Text = CPstrSubFormDivid
            
            '@装置使用部材分割画面起動
            frmxxEN01V1.Instance.ShowDialog(Me)
            frmxxEN01V1.Instance = Nothing
            
            '@引継ぎ用構造体を初期化する
            With ptypRegMaterial
                .strMaterialTypeID = vbNullString       '部材種別ID
                .strMaterialID = vbNullString           '部材ID
                .strMaterialLotID = vbNullString        '部材管理ID
                .strProductionDate = vbNullString       '製造日
                .strAcceptanceDate = vbNullString       '受入日
                .strEditTime = vbNullString             '最終更新日時
                .strWpID = vbNullString                 '装置ID
                .strUseTime = vbNullString              '使用開始日時
            End With
            
            '@部材登録/分割判定ﾌﾗｸﾞにより処理を分岐(True:登録、False:未登録)
            If pblnMaterialRegistFlag = True Then
                
                '@引継ぎが存在する場合
                If pstrMakeMaterialLotID <> vbNullString Then
                    mtypChgSort.strKey = pstrMakeMaterialLotID
                End If
                
                '@最新情報を取得し直す
                Call cmdNowList_Click(sender, new EventArgs)
            End If
            
            '@部材登録/分割判定ﾌﾗｸﾞを初期化
            pblnMaterialRegistFlag = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDivide_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdStartUse_Click
    '機　能：部材使用開始処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 15:05:46 N.Kojima
    '更新日：2006/06/26 (Mon) 17:32:17 N.Kojima
    '備　考：
    '　　　：2006/06/26 (Mon) 17:32:17 N.Kojima     装置処理実行中ﾌﾗｸﾞを引数に追加。(ﾕｰｻﾞｰ要望№0189)
    Private Sub cmdStartUse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdStartUse.Click

        Dim lblnAns                 As Boolean              '戻り値判定用(true or false)
        Dim ltypChgMaterial         As ChgMaterial          '装置使用部材状態変更要求格納用
        Dim lstrWpExcutingFlag      As String               '装置処理実行中ﾌﾗｸﾞ

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
            
            '@ﾌｫｰﾑﾛｯｸ中の場合は処理を受け付けない
            If Me.Enabled = False Then
                Exit Sub
            End If
            
            '@使用部材判定での処理区分設定、ﾒｯｾｰｼﾞ表示の際に使用
            '@"0"=使用開始ﾎﾞﾀﾝ押下
            mstrAction = CPstrZero
            
            '@使用部材判定＆権限ﾁｪｯｸ処理
            lblnAns = prvblnChgMaterial_Chk
            
            '@使用部材判定＆権限ﾁｪｯｸ処理の戻り値を判定
            '@処理中断 or 権限なしの場合
            If lblnAns = False Then
                Exit Sub
            End If
                    
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdStartUseClick)
            
            Me.KeyPreview = False
                
            '@送信ﾃﾞｰﾀ格納
            With ltypChgMaterial
                .strSbID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strMsgVer = CMstrmat_chgmaterialstatVer        'MsgVer
                .strClassDivision = CPstrCD47                   '処理区分(47:使用開始)
                .strMaterialTypeID = cmbMaterialType.Text       '部材種別ID
                .strMaterialID = cmbMaterial.Text               '部材ID
                .strWpID = cmbWp.Value                          '装置ID
                .strEmpID = pstrUserID                          '作業者ID
                .strMaterialLotID = vsfMaterialList.GetData(vsfMaterialList.Row, CMlngvsfMaterialListColMaterialLotID)     '部材管理ID                          '
                .strEditTime = vsfMaterialList.GetData(vsfMaterialList.Row, CMlngvsfMaterialListColLastUpdate)             '最終更新日時
            End With
            
            '@装置使用部材状態変更ﾒｯｾｰｼﾞ送信
            lblnAns = pubblnMatChgMaterialState_Upd(ltypChgMaterial, lstrWpExcutingFlag)
            
            Me.KeyPreview = True

            '@ｱｸｼｮﾝﾄﾘｶﾞの初期化
            mstrAction = vbNullString
            
            '@戻り値判定
            If lblnAns = True Then
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdStartUseClick)
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@<TRM6AI>$$部材管理ID[%1]の使用開始日時を設定しました。
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006A, ltypChgMaterial.strMaterialLotID)
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@最新情報を取得し直す
                Call cmdNowList_Click(sender,New EventArgs)
                
                '@部材一覧が有効か
                If vsfMaterialList.Enabled = True Then
                    '@部材一覧にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfMaterialList)
                End If
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdStartUseClick)
                
                '@使用開始ﾎﾞﾀﾝが有効か
                If cmdStartUse.Enabled = True Then
                    '@ﾎﾞﾀﾝにﾌｫｰｶｽ保持
                    Call pubSetFocus(cmdStartUse)
                End If
                
                Exit Sub
            End If

            Exit Sub

        Catch ex As Exception

            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdStartUse_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUseWP_Click
    '機　能：装置使用開始処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/18 (Tue) 10:32:38 N.Kojima
    '更新日：2006/06/26 (Mon) 17:33:29 N.Kojima
    '備　考：
    '　　　：2006/06/26 (Mon) 17:33:29 N.Kojima     装置処理実行中ﾌﾗｸﾞを引数に追加。(ﾕｰｻﾞｰ要望№0189)
    Private Sub cmdUseWP_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUseWP.Click

        Dim lblnAns                 As Boolean              '戻り値判定用(true or false)
        Dim ltypChgMaterial         As ChgMaterial          '装置使用部材状態変更要求格納用
        Dim lstrWpExcutingFlag      As String               '装置処理実行中ﾌﾗｸﾞ

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
            
            '@ﾌｫｰﾑﾛｯｸ中の場合は処理を受け付けない
            If Me.Enabled = False Then
                Exit Sub
            End If
            
            '@使用部材判定での処理区分設定、ﾒｯｾｰｼﾞ表示の際に使用
            '@"1"=装置使用開始ﾎﾞﾀﾝ押下
            mstrAction = CPstrOne
            
            '@使用部材判定＆権限ﾁｪｯｸ処理
            lblnAns = prvblnChgMaterial_Chk
            
            '@使用部材判定＆権限ﾁｪｯｸ処理の戻り値を判定
            '@処理中断 or 権限なしの場合
            If lblnAns = False Then
                Exit Sub
            End If
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdUseWPClick)
            

            Me.KeyPreview = False
                
            '@送信ﾃﾞｰﾀ格納
            With ltypChgMaterial
                .strSbID = pstrSBID                             'SBID
                .strMsgVer = CMstrmat_chgmaterialstatVer        'MsgVer
                .strClassDivision = CPstrCD46                   '処理区分(46:装置使用開始)
                .strMaterialTypeID = cmbMaterialType.Text       '部材種別ID
                .strMaterialID = cmbMaterial.Text               '部材ID
                .strWpID = cmbWp.Value                          '装置ID
                .strEmpID = pstrUserID                          '作業者ID
                .strMaterialLotID = vsfMaterialList.GetData(vsfMaterialList.Row, CMlngvsfMaterialListColMaterialLotID)     '部材管理ID                          '
                .strEditTime = vsfMaterialList.GetData(vsfMaterialList.Row, CMlngvsfMaterialListColLastUpdate)             '最終更新日時
            End With
            
            '@装置使用部材状態変更ﾒｯｾｰｼﾞ送信
            lblnAns = pubblnMatChgMaterialState_Upd(ltypChgMaterial, lstrWpExcutingFlag)
            
            Me.KeyPreview = True
            
            '@ｱｸｼｮﾝﾄﾘｶﾞの初期化
            mstrAction = vbNullString

            '@戻り値判定
            If lblnAns = True Then
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdUseWPClick)
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@<TRM6BI>$$部材管理ID[%1]の使用装置を設定しました。
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006B, ltypChgMaterial.strMaterialLotID)
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@最新情報を取得し直す
                Call cmdNowList_Click(sender, New EventArgs)
                
                '@部材一覧が有効か
                If vsfMaterialList.Enabled = True Then
                    '@部材一覧にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfMaterialList)
                End If
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdUseWPClick)
                
                '@装置使用開始ﾎﾞﾀﾝが表示されているか
                If cmdUseWP.Visible = True Then
                    '@ﾎﾞﾀﾝにﾌｫｰｶｽ保持
                    Call pubSetFocus(cmdUseWP)
                End If
                
                Exit Sub
            End If

            Exit Sub

        Catch ex As Exception

            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUseWP_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUseWPCancel_Click
    '機　能：装置使用解除処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/18 (Tue) 10:50:02 N.Kojima
    '更新日：2006/06/26 (Mon) 17:34:49 N.Kojima
    '備　考：
    '　　　：2006/05/24 (Wed) 17:54:47 N.Kojima     WPIDはｸﾞﾘｯﾄﾞの装置IDを設定して送信するように修正。
    '　　　：2006/06/26 (Mon) 17:34:49 N.Kojima     装置処理実行中ﾌﾗｸﾞを引数に追加。(ﾕｰｻﾞｰ要望№0189)
    Private Sub cmdUseWPCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUseWPCancel.Click

        Dim lblnAns                 As Boolean              '戻り値判定用
        Dim ltypChgMaterial         As ChgMaterial          '装置使用部材状態変更要求格納用
        Dim lstrWpExcutingFlag      As String               '装置処理実行中ﾌﾗｸﾞ

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
            
            '@ﾌｫｰﾑﾛｯｸ中の場合は処理を受け付けない
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
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdUseWPCancelClick)
            
            Me.KeyPreview = False
                
            '@送信ﾃﾞｰﾀ格納
            With ltypChgMaterial
                .strSbID = pstrSBID                             'SBID
                .strMsgVer = CMstrmat_chgmaterialstatVer        'MsgVer
                .strClassDivision = CPstrCD48                   '処理区分(48:装置使用解除)
                .strMaterialTypeID = cmbMaterialType.Text       '部材種別ID
                .strMaterialID = cmbMaterial.Text               '部材ID
        '        .strForcedAction = CPstrZero                    '強制実行ﾌﾗｸﾞ(0=通常実行、1=強制実行)
                .strEmpID = pstrUserID                          '作業者ID
                .strMaterialLotID = vsfMaterialList.GetData(vsfMaterialList.Row, CMlngvsfMaterialListColMaterialLotID)     '部材管理ID                          '
                .strEditTime = vsfMaterialList.GetData(vsfMaterialList.Row, CMlngvsfMaterialListColLastUpdate)             '最終更新日時
                .strWpID = vsfMaterialList.GetData(vsfMaterialList.Row, CMlngvsfMaterialListColWPID)     '装置ID
            
            End With
            
            '@装置使用部材状態変更ﾒｯｾｰｼﾞ送信
            lblnAns = pubblnMatChgMaterialState_Upd(ltypChgMaterial, lstrWpExcutingFlag)
            
            Me.KeyPreview = True
            
            '@戻り値判定
            If lblnAns = True Then
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdUseWPCancelClick)
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@<TRM6CI>$$部材管理ID[%1]の使用装置を解除しました。
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006C, ltypChgMaterial.strMaterialLotID)
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@装置処理実行中ﾌﾗｸﾞが"1"(=処理中)の場合
                If lstrWpExcutingFlag = CPstrOne Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006J, ltypChgMaterial.strMaterialLotID)
                    '@"<TRM6JI>$$部材管理ID[%1]の使用装置を解除しました。$必要に応じ、新しい部材を装置にセットしてください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                End If
                
                '@最新情報を取得し直す
                Call cmdNowList_Click(sender, new Eventargs)
                
                '@部材一覧が有効か
                If vsfMaterialList.Enabled = True Then
                    '@部材一覧にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfMaterialList)
                End If
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdUseWPCancelClick)
                
                '@装置使用解除ﾎﾞﾀﾝが表示されているか
                If cmdUseWPCancel.Visible = True Then
                    '@ﾎﾞﾀﾝにﾌｫｰｶｽ保持
                    Call pubSetFocus(cmdUseWPCancel)
                End If
                
                Exit Sub
            End If

            Exit Sub

        Catch ex As Exception

            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUseWPCancel_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMaterialDateChg_Click
    '機　能：装置使用部材分割画面起動処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/23 (Fri) 15:00:32 N.Kojima
    '更新日：2006/06/23 (Fri) 15:00:32
    '備　考：
    Private Sub cmdMaterialDateChg_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMaterialDateChg.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
                
            '@引継ぎ用構造体に引継ぎ情報を格納
            With vsfMaterialList
                ptypRegMaterial.strMaterialTypeID = cmbMaterialType.Text        '部材種別ID
                ptypRegMaterial.strMaterialID = cmbMaterial.Text                '部材ID
                ptypRegMaterial.strMaterialLotID = .GetData(.Row, CMlngvsfMaterialListColMaterialLotID)    '部材管理ID
                ptypRegMaterial.strProductionDate = .GetData(.Row, CMlngvsfMaterialListColProductionDate)  '製造日
                ptypRegMaterial.strAcceptanceDate = .GetData(.Row, CMlngvsfMaterialListColAcceptanceDate)  '受入日
                ptypRegMaterial.strUseTime = .GetData(.Row, CMlngvsfMaterialListColUseTime)                '使用開始日時
                ptypRegMaterial.strEditTime = .GetData(.Row, CMlngvsfMaterialListColLastUpdate)            '最終更新日時
                ptypRegMaterial.strWpID = cmbWp.Value                           '装置ID
            End With

            '@子画面名称設定(装置使用部材日付変更)
            frmxxEN01V1.Instance.Text = CPstrSubFormDateChg
            
            '@装置使用部材日付変更画面起動
            frmxxEN01V1.Instance.ShowDialog(Me)
            frmxxEN01V1.Instance = Nothing
            
            '@引継ぎ用構造体を初期化する
            With ptypRegMaterial
                .strMaterialTypeID = vbNullString       '部材種別ID
                .strMaterialID = vbNullString           '部材ID
                .strMaterialLotID = vbNullString        '部材管理ID
                .strProductionDate = vbNullString       '製造日
                .strAcceptanceDate = vbNullString       '受入日
                .strUseTime = vbNullString              '使用開始日時
                .strEditTime = vbNullString             '最終更新日時
                .strWpID = vbNullString                 '装置ID
            End With
            
            '@部材登録/分割/日付変更判定ﾌﾗｸﾞにより処理を分岐(True:登録、False:未登録)
            If pblnMaterialRegistFlag = True Then
                '@最新情報を取得し直す
                Call cmdNowList_Click(sender, New EventArgs)
            End If
            
            '@部材登録/分割/日付変更判定ﾌﾗｸﾞを初期化
            pblnMaterialRegistFlag = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMaterialDateChg_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdScrap_Click
    '機　能：部材廃棄処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/18 (Tue) 11:20:31 N.Kojima
    '更新日：2006/10/24 (Tue) 17:15:04 N.Kojima
    '備　考：
    '　　　：2006/05/24 (Wed) 17:53:53 N.Kojima     WPIDはｸﾞﾘｯﾄﾞの装置IDを設定して送信するように修正。
    '　　　：2006/06/26 (Mon) 17:36:03 N.Kojima     装置処理実行中ﾌﾗｸﾞを引数に追加。(ﾕｰｻﾞｰ要望№0189)
    '　　　：2006/10/24 (Tue) 17:15:04 N.Kojima     部材の在庫ﾁｪｯｸ・発注管理機能追加に伴い、処理追加&修正。(案件№01095)
    Private Sub cmdScrap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdScrap.Click

        Dim lblnAns                 As Boolean              '戻り値判定用
        Dim llngAns                 As Integer              '戻り値判定用2
        Dim ltypChgMaterial         As ChgMaterial          '装置使用部材状態変更要求格納用
        Dim lstrWpExcutingFlag      As String               '装置処理実行中ﾌﾗｸﾞ

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
            
            '@ﾌｫｰﾑﾛｯｸ中の場合は処理を受け付けない
            If Me.Enabled = False Then
                Exit Sub
            End If
            
            With vsfMaterialList
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006G, .GetData(.Row, CMlngvsfMaterialListColMaterialLotID), CMstrScrap)
                '@"<TRM6GI>$$部材管理ID[%1]を[%2]します。よろしいですか？"
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                
                '@要求確認
                If llngAns = vbNo Then
                    '@処理中断
                    Exit Sub
                End If
            End With
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
                
            '@在庫ﾁｪｯｸ判定でのﾎﾟｯﾌﾟｱｯﾌﾟﾒｯｾｰｼﾞ表示の際に使用
            '@"5"=廃棄ﾎﾞﾀﾝ押下
            mstrAction = CPstrFive
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdScrapClick)
            
            Me.KeyPreview = False

            '@送信ﾃﾞｰﾀ格納
            With ltypChgMaterial
                .strSbID = pstrSBID                             'SBID
                .strMsgVer = CMstrmat_chgmaterialstatVer        'MsgVer
                .strClassDivision = CPstrCD45                   '処理区分(45:廃棄)
                .strMaterialTypeID = cmbMaterialType.Text       '部材種別ID
                .strMaterialID = cmbMaterial.Text               '部材ID
        '        .strForcedAction = CPstrZero                    '強制実行ﾌﾗｸﾞ(0=通常実行、1=強制実行)
                .strEmpID = pstrUserID                          '作業者ID
                .strMaterialLotID = vsfMaterialList.GetData(vsfMaterialList.Row, CMlngvsfMaterialListColMaterialLotID)     '部材管理ID                          '
                .strEditTime = vsfMaterialList.GetData(vsfMaterialList.Row, CMlngvsfMaterialListColLastUpdate)  '最終更新日時                
                .strWpID = vsfMaterialList.GetData(vsfMaterialList.Row, CMlngvsfMaterialListColWPID)     '装置ID
            End With
            
            '@装置使用部材状態変更ﾒｯｾｰｼﾞ送信
            lblnAns = pubblnMatChgMaterialState_Upd(ltypChgMaterial, lstrWpExcutingFlag)
           

            Me.KeyPreview = True
            
            '@ｱｸｼｮﾝﾄﾘｶﾞの初期化
            mstrAction = vbNullString
            
            '@戻り値判定
            If lblnAns = True Then
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdScrapClick)
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM6HI>$$部材管理ID[%1]を[%2]しました。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006H, ltypChgMaterial.strMaterialLotID, CMstrScrap)
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@最新情報を取得し直す
                Call cmdNowList_Click(sender, New EventArgs)
                
                '@部材一覧が有効か
                If vsfMaterialList.Enabled = True Then
                    '@部材一覧にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfMaterialList)
                End If
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdScrapClick)
                
                '@廃棄ﾎﾞﾀﾝが有効か
                If cmdScrap.Enabled = True Then
                    '@ﾎﾞﾀﾝにﾌｫｰｶｽ保持
                    Call pubSetFocus(cmdScrap)
                End If
                
                Exit Sub
            End If

            Exit Sub

        Catch ex As Exception

            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdScrap_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdHold_Click
    '機　能：保留処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/18 (Fri) 10:20:00 S.Ochiai
    '更新日：2008/01/18 (Fri) 10:20:00 S.Ochiai
    '備　考：
    '　　　：2008/01/18 (Fri) 10:20:00 S.Ochiai     新規作成。(ﾕｰｻﾞｰ要望№02463)
    Private Sub cmdHold_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdHold.Click

        Dim lblnAns                 As Boolean              '戻り値判定用(true or false)
        Dim ltypChgMaterial         As ChgMaterial          '装置使用部材状態変更要求格納用
        Dim lstrWpExcutingFlag      As String               '装置処理実行中ﾌﾗｸﾞ

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
            
            '@ﾌｫｰﾑﾛｯｸ中の場合は処理を受け付けない
            If Me.Enabled = False Then
                Exit Sub
            End If
            
            '@使用部材判定での処理区分設定、ﾒｯｾｰｼﾞ表示の際に使用
            '@"6"=保留ﾎﾞﾀﾝ押下
            mstrAction = CPstrSix
            
            '@使用部材判定＆権限ﾁｪｯｸ処理
            lblnAns = prvblnChgMaterial_Chk
            
            '@使用部材判定＆権限ﾁｪｯｸ処理の戻り値を判定
            '@処理中断 or 権限なしの場合
            If lblnAns = False Then
                Exit Sub
            End If
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdHoldClick)
            
            Me.KeyPreview = False
                
            '@送信ﾃﾞｰﾀ格納
            With ltypChgMaterial
                .strSbID = pstrSBID                             'SBID
                .strMsgVer = CMstrmat_chgmaterialstatVer        'MsgVer
                .strClassDivision = CPstrCD14                   '処理区分(14:保留)
                .strMaterialTypeID = cmbMaterialType.Text       '部材種別ID
                .strMaterialID = cmbMaterial.Text               '部材ID
                .strWpID = cmbWp.Value                          '装置ID
                .strEmpID = pstrUserID                          '作業者ID
                .strMaterialLotID = vsfMaterialList.GetData(vsfMaterialList.Row, CMlngvsfMaterialListColMaterialLotID)     '部材管理ID                          '
                .strEditTime = vsfMaterialList.GetData(vsfMaterialList.Row, CMlngvsfMaterialListColLastUpdate)             '最終更新日時
            End With
            
            '@装置使用部材状態変更ﾒｯｾｰｼﾞ送信
            lblnAns = pubblnMatChgMaterialState_Upd(ltypChgMaterial, lstrWpExcutingFlag)
            
            Me.KeyPreview = True
            
            '@ｱｸｼｮﾝﾄﾘｶﾞの初期化
            mstrAction = vbNullString
            
            '@戻り値判定
            If lblnAns = True Then
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdHoldClick)
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@<TRM60I>$$部材管理ID[%1]を保留しました。
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0060, ltypChgMaterial.strMaterialLotID)
                
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@最新情報を取得し直す
                Call cmdNowList_Click(sender, New EventArgs)
                
                '@部材一覧が有効か
                If vsfMaterialList.Enabled = True Then
                    '@部材一覧にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfMaterialList)
                End If
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdHoldClick)
                
                '@保留ﾎﾞﾀﾝが表示されているか
                If cmdHoldCancel.Visible = True Then
                    '@ﾎﾞﾀﾝにﾌｫｰｶｽ保持
                    Call pubSetFocus(cmdUseWP)
                End If
                
                Exit Sub
            End If

            Exit Sub

        Catch ex As Exception

            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUseWP_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '機　能：保留解除処理
    '引　数：なし
    '戻り値：なし
    '作成日：2008/01/21 (Mon) 12:44:00 S.Ochiai
    '更新日：2008/01/21 (Mon) 12:44:00 S.Ochiai
    '備　考：
    '　　　：2008/01/21 (Mon) 12:44:00 S.Ochiai     新規作成。(ﾕｰｻﾞｰ要望№02463)
    Private Sub cmdHoldCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdHoldCancel.Click

        Dim lblnAns                 As Boolean              '戻り値判定用(true or false)
        Dim ltypChgMaterial         As ChgMaterial          '装置使用部材状態変更要求格納用
        Dim lstrWpExcutingFlag      As String               '装置処理実行中ﾌﾗｸﾞ

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
            
            '@ﾌｫｰﾑﾛｯｸ中の場合は処理を受け付けない
            If Me.Enabled = False Then
                Exit Sub
            End If
            
            '@使用部材判定での処理区分設定、ﾒｯｾｰｼﾞ表示の際に使用
            '@"7"=保留ﾎﾞﾀﾝ押下
            mstrAction = CPstrSeven
            
            '@使用部材判定＆権限ﾁｪｯｸ処理
            lblnAns = prvblnChgMaterial_Chk
            
            '@使用部材判定＆権限ﾁｪｯｸ処理の戻り値を判定
            '@処理中断 or 権限なしの場合
            If lblnAns = False Then
                Exit Sub
            End If
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdHoldCancelClick)
            
            Me.KeyPreview = False
                
            '@送信ﾃﾞｰﾀ格納
            With ltypChgMaterial
                .strSbID = pstrSBID                             'SBID
                .strMsgVer = CMstrmat_chgmaterialstatVer        'MsgVer
                .strClassDivision = CPstrCD15                   '処理区分(15:保留解除)
                .strMaterialTypeID = cmbMaterialType.Text       '部材種別ID
                .strMaterialID = cmbMaterial.Text               '部材ID
                .strWpID = cmbWp.Value                          '装置ID
                .strEmpID = pstrUserID                          '作業者ID
                .strMaterialLotID = vsfMaterialList.GetData(vsfMaterialList.Row, CMlngvsfMaterialListColMaterialLotID)     '部材管理ID                          '
                .strEditTime = vsfMaterialList.GetData(vsfMaterialList.Row, CMlngvsfMaterialListColLastUpdate)             '最終更新日時
            End With
            
            '@装置使用部材状態変更ﾒｯｾｰｼﾞ送信
            lblnAns = pubblnMatChgMaterialState_Upd(ltypChgMaterial, lstrWpExcutingFlag)
            
            Me.KeyPreview = True
            
            '@ｱｸｼｮﾝﾄﾘｶﾞの初期化
            mstrAction = vbNullString
            
            '@戻り値判定
            If lblnAns = True Then
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdHoldCancelClick)
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@<TRM61I>$$部材管理ID[%1]を保留解除しました。
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0061, ltypChgMaterial.strMaterialLotID)
                
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@最新情報を取得し直す
                Call cmdNowList_Click(sender, New EventArgs)
                
                '@部材一覧が有効か
                If vsfMaterialList.Enabled = True Then
                    '@部材一覧にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfMaterialList)
                End If
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdHoldCancelClick)
                
                '@保留ﾎﾞﾀﾝが表示されているか
                If cmdHold.Visible = True Then
                    '@ﾎﾞﾀﾝにﾌｫｰｶｽ保持
                    Call pubSetFocus(cmdUseWP)
                End If
                
                Exit Sub
            End If

            Exit Sub

        Catch ex As Exception

            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUseWP_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    ''' <summary>
    ''' 無効（部材の登録間違えに対応、廃棄や取消とは異なる状態で管理する）
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cmdInvalid_Click(sender As Object, e As EventArgs) Handles cmdInvalid.Click

        Dim lblnAns                 As Boolean              '戻り値判定用
        Dim llngAns                 As Integer              '戻り値判定用2
        Dim ltypChgMaterial         As New ChgMaterial      '装置使用部材状態変更要求格納用
        Dim lstrWpExcutingFlag      As String = vbNullString  '装置処理実行中ﾌﾗｸﾞ

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
            
            '@ﾌｫｰﾑﾛｯｸ中の場合は処理を受け付けない
            If Me.Enabled = False Then
                Exit Sub
            End If
            
            With vsfMaterialList
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006G, .GetData(.Row, CMlngvsfMaterialListColMaterialLotID), CMstrInvalid)
                '@"<TRM6GI>$$部材管理ID[%1]を[%2]します。よろしいですか？"
                llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                
                '@要求確認
                If llngAns = vbNo Then
                    '@処理中断
                    Exit Sub
                End If
            End With
            
            '権限確認
            mstrAction = CPstrEight
            lblnAns = prvblnChgMaterial_Chk
            If lblnAns = False Then
                Exit Sub
            End If
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdInvalidClick)
            
            Me.KeyPreview = False

            '@送信ﾃﾞｰﾀ格納
            With ltypChgMaterial
                .strSbID = pstrSBID                             'SBID
                .strMsgVer = CMstrmat_chgmaterialstatVer        'MsgVer
                .strClassDivision = CPstrCD4R                   '処理区分(4R:無効化)
                .strMaterialTypeID = cmbMaterialType.Text       '部材種別ID
                .strMaterialID = cmbMaterial.Text               '部材ID
        '        .strForcedAction = CPstrZero                    '強制実行ﾌﾗｸﾞ(0=通常実行、1=強制実行)
                .strEmpID = pstrUserID                          '作業者ID
                .strMaterialLotID = vsfMaterialList.GetData(vsfMaterialList.Row, CMlngvsfMaterialListColMaterialLotID)     '部材管理ID                          '
                .strEditTime = vsfMaterialList.GetData(vsfMaterialList.Row, CMlngvsfMaterialListColLastUpdate)  '最終更新日時                
                .strWpID = vsfMaterialList.GetData(vsfMaterialList.Row, CMlngvsfMaterialListColWPID)     '装置ID
            End With
            
            '@装置使用部材状態変更ﾒｯｾｰｼﾞ送信
            lblnAns = pubblnMatChgMaterialState_Upd(ltypChgMaterial, lstrWpExcutingFlag)
           
            Me.KeyPreview = True
            
            '@ｱｸｼｮﾝﾄﾘｶﾞの初期化
            mstrAction = vbNullString
            
            '@戻り値判定
            If lblnAns = True Then
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdInvalidClick)
                
                '@表示ﾒｯｾｰｼﾞ変換
                '@"<TRM6HI>$$部材管理ID[%1]を[%2]しました。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006H, ltypChgMaterial.strMaterialLotID, CMstrInvalid)
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@最新情報を取得し直す
                Call cmdNowList_Click(sender, New EventArgs)
                
                '@部材一覧が有効か
                If vsfMaterialList.Enabled = True Then
                    '@部材一覧にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfMaterialList)
                End If
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdInvalidClick)
                
                'ﾎﾞﾀﾝが有効か
                If cmdInvalid.Enabled = True Then
                    '@ﾎﾞﾀﾝにﾌｫｰｶｽ保持
                    Call pubSetFocus(cmdInvalid)
                End If
                
                Exit Sub
            End If

            Exit Sub

        Catch ex As Exception

            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdInvalid_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try

    End Sub

    '関数名：cmdRight_Click
    '機　能：右一項目移動
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/18 (Tue) 11:25:44 N.Kojima
    '更新日：2007/07/06 (Fri) 14:50:56 N.Kasai
    '備　考：
    '　　　：2007/07/06 (Fri) 14:50:56 N.Kasai  ｸﾞﾘｯﾄﾞ共通
    Private Sub cmdRight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRight.Click
            
        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            
            '@右ｽｸﾛｰﾙﾎﾞﾀﾝ処理
            Call pubVsfCmdRight(vsfMaterialList, cmdLeft, cmdRight)

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdRight_Click"         '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdLeft_Click
    '機　能：左一項目移動
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/18 (Tue) 11:28:15 N.Kojima
    '更新日：2007/07/06 (Fri) 14:51:38 N.Kasai
    '備　考：
    '　　　：2007/07/06 (Fri) 14:51:38 N.Kasai  ｸﾞﾘｯﾄﾞ共通
    Private Sub cmdLeft_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLeft.Click
        
        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
                
            '@左ｽｸﾛｰﾙﾎﾞﾀﾝ制御
            Call pubVsfCmdLeft(vsfMaterialList, cmdLeft, cmdRight)

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "cmdLeft_Click"          '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：前頁ｽｸﾛｰﾙ
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/18 (Tue) 11:29:40 N.Kojima
    '更新日：2006/04/18 (Tue) 11:29:40
    '備　考：
    Private Sub cmdUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUp.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@前頁処理（ｸﾞﾘｯﾄﾞ、前頁、次頁）
            Call pubVsfCmdUp(vsfMaterialList, cmdUP, cmdDown)
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：次頁ｽｸﾛｰﾙ
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/18 (Tue) 11:30:17 N.Kojima
    '更新日：2006/04/18 (Tue) 11:30:17
    '備　考：
    Private Sub cmdDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@次頁処理（ｸﾞﾘｯﾄﾞ、前頁、次頁）
            Call pubVsfCmdDown(vsfMaterialList, cmdUP, cmdDown)
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@後日の機能追加に備え残しておきます。
    '関数名：cmdCopy_Click
    '機　能：ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰ
    '引　数：なし
    '戻り値：
    '作成日：2006/04/14 (Fri) 14:04:45 N.Kojima
    '更新日：2006/04/14 (Fri) 14:04:45
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
            
                '@Clipboardの内容を削除
                Clipboard.Clear
            
                With vsfMaterialList
                    '@一覧をｺﾋﾟｰする
                    For llngRowCnt = 0 To .Rows.Count - 1
                        For llngColCnt = 0 To .Cols.Count - 1
                            '@列が非表示でない場合
                            If .Cols(llngColCnt).Visible = True Then
                            
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
                                If llngColCnt = CMlngvsfMaterialListColWLastUpdate Then
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
                
            
            '@Clipboard にﾃｷｽﾄ文字列を挿入
            Clipboard.SetText(lstrRET)
            
            End With
            
            '@表示ﾒｯｾｰｼﾞ変換
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0041)
            
            '@publngMsgBoxInfo("メッセージコード：C_I41%0$$クリップボードにコピーしました。
            '@(Excel等に Ctrl＋Vキー で貼り付けてください)")
            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCopy_Click"
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

    '関数名：prvfrmxxEN01V0_Init
    '機　能：ﾒｲﾝﾌｫｰﾑの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/04 (Tue) 16:12:57 N.Kojima
    '更新日：2006/10/20 (Fri) 13:21:02 N.Kojima
    '備　考：
    '　　　：2006/06/23 (Fri) 15:06:03 N.Kojima     部材日付変更機能追加に伴い、処理修正。(ﾕｰｻﾞｰ要望№0189)
    '　　　：2006/10/03 (Tue) 15:41:48 N.Kojima     機種限定・部材期限判定ｴﾗｰMsg格納用変数の初期化処理追加。(案件№01472)
    '　　　：2006/10/20 (Fri) 13:21:02 N.Kojima     部材の在庫ﾁｪｯｸ・発注管理機能追加に伴い、処理追加&修正。(案件№01095)
    Private Sub prvfrmxxEN01V0_Init()

        Dim lstrFormTitle       As String               'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try

            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN01V0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@ﾗﾍﾞﾙの初期化
            lblNowDate.Text = vbNullString               '情報取得日時
            lblMaterialCnt.Text = vbNullString           '該当件数
            lblVenderWarrantDays.Text = vbNullString     'ﾒｰｶ保証期間
            lblAcceptWarrantDays.Text = vbNullString     '受入制限期間
            lblUseValidPeriod.Text = vbNullString        '使用可能時間
            lblUseInvalidPeriod.Text = vbNullString      '使用禁止時間
            lblWarningPeriod.Text = vbNullString         'ﾜｰﾆﾝｸﾞ時間
            lblStockNum.Text = vbNullString              '未使用部材数
            lblOrderNum.Text = vbNullString              '発注済数
            lblOrderRemeinNum.Text = vbNullString        '発注ﾎﾟｲﾝﾄ
            lblMessage.Text = vbNullString               'ﾒｯｾｰｼﾞ
            
            '@ﾎﾞﾀﾝの初期化(無効化)
            cmdNowList.Enabled = False                      '無効　:最新取得
            cmdOrder.Enabled = False                        '無効　:発注
            cmdAccept.Enabled = False                       '無効　:受入
            cmdStartUse.Enabled = False                     '無効　:使用開始
            cmdUseWPMain.Visible = True                     '表示　:装置使用開始/解除
            cmdUseWPMain.Enabled = False                    '無効　:装置使用開始/解除
            cmdUseWP.Visible = False                        '非表示:装置使用開始
            cmdUseWP.Enabled = True                         '有効　:装置使用開始
            cmdUseWPCancel.Visible = False                  '非表示:装置使用解除
            cmdUseWPCancel.Enabled = True                   '有効　:装置使用解除
            cmdHoldMain.Visible = True                      '表示　:保留/保留解除
            cmdHoldMain.Enabled = False                     '無効　:保留/保留解除
            cmdHold.Visible = False                         '非表示:保留
            cmdHold.Enabled = True                          '有効　:保留
            cmdHoldCancel.Visible = False                   '非表示:保留解除
            cmdHoldCancel.Enabled = True                    '無効　:保留解除
            cmdDivide.Enabled = False                       '無効　:分割
            cmdScrap.Enabled = False                        '無効　:廃棄
            cmdInvalid.Enabled = False                      '無効　:間違え
            cmdMaterialDateChg.Enabled = False              '無効　:部材日時変更
            
            cmdUP.Enabled = False                           '上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ
            cmdDown.Enabled = False                         '下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ
            cmdRight.Enabled = False                        '右(>>)ｽｸﾛｰﾙﾎﾞﾀﾝ
            cmdLeft.Enabled = False                         '左(<<)ｽｸﾛｰﾙﾎﾞﾀﾝ
            
            '@ｸﾘｯﾌﾟﾎﾞｰﾄﾞｺﾋﾟｰﾎﾞﾀﾝ(現在未使用)
            cmdCopy.Visible = False
            cmdCopy.Enabled = False
            
            '@ﾓｼﾞｭｰﾙ変数の初期化
            mstrMaterialType = vbNullString                 '部材種別退避領域
            mstrMaterial = vbNullString                     '部材退避領域
            mstrMaterialWP = vbNullString                   '使用装置退避領域
            mstrPdErrMsg = vbNullString                     '機種限定判定ｴﾗｰMsg格納用
            mstrLimitErrMsg = vbNullString                  '部材期限判定ｴﾗｰMsg格納用
            mstrStockErrMsg = vbNullString                  '部材在庫判定ｴﾗｰMsg格納用
            mstrAction = vbNullString                       '処理格納用
            
            mblnValidateFlag = False                        'Valadate処理済みﾌﾗｸﾞの設定
            mblnMaterialStockChkFlag = False                '在庫ﾁｪｯｸ処理中ﾌﾗｸﾞの初期化
                            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01V0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvAllCombo_Init
    '機　能：ｺﾝﾎﾞﾎﾞｯｸｽの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/04 (Tue) 15:48:11 N.Kojima
    '更新日：2006/04/19 (Wed) 10:36:57 N.Kojima
    '備　考：
    Private Sub prvAllCombo_Init()

        Dim lctlControl     As Control      'ｺﾝﾄﾛｰﾙ名称取得用変数

        Try

            '@ComboBox設定(初期化)
            For Each lctlControl In GetAllControls(me)  
                If TypeOf lctlControl Is ComboBoxEx Then
                    With CType(lctlControl, SEComboBoxEx.ComboBoxEx)
                        '@初期化
                        .Enabled = True
                        .Clear
                        .DispCols = CMlngCmbDispCols                                       'ｸﾞﾘｯﾄﾞ表示列数
                        .GetCol = CMlngCmbGridColName                                      'ﾃｷｽﾄ表示列
                        .ValueCol = CMlngCmbGridColID                                      '値取得列
                        .DirectInput = False                                               'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                        .Font = New Font(.Font.Name, CMlngCmbFontSize,.Font.Style)         'ﾌｫﾝﾄｻｲｽﾞ
                        .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _ 
                                                    .Font.Style, .Font.Unit)               'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ                      
                        .RowHeight = CMlngCmbHeight                                        'ｸﾞﾘｯﾄﾞの高さ
                        .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter 'CMlngCmbAlignLeftCenter       'ｸﾞﾘｯﾄﾞ表示位置（左中央）
                    End With
                End If
            Next
            
            '@全てのｺﾝﾎﾞの無効化
            cmbMaterialType.Enabled = False                 '部材種別
            cmbMaterial.Enabled = False                     '部材
            cmbWp.Enabled = False                           '使用装置

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvAllCombo_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfMaterialList_Init
    '機　能：部材一覧表示情報初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/04 (Tue) 16:32:02 N.Kojima
    '更新日：2006/04/04 (Tue) 16:32:02
    '備　考：
    Private Sub prvvsfMaterialList_Init()
        Dim headerStyle As CellStyle    'NSYS ヘッダー用追加Style

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfMaterialList
                '@ｸﾘｱ
                .Clear(ClearFlags.Content, .Rows.Fixed, 0, .Rows.Count - 1, .Cols.Count - 1)
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                .AllowSorting = AllowSortingEnum.SingleColumn 
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                
                '@ｸﾞﾘｯﾄﾞ設定
                '.AllowBigSelection = False                                   'ﾍｯﾀﾞｸﾘｯｸで全選択不可
                .AllowDragging  = False                                       'ﾏｳｽでｾﾙ範囲選択不可
                .SelectionMode =  SelectionModeEnum.Row                       '行選択
                '.FillStyle = flexFillRepeat                                  'ﾌﾟﾛﾊﾟﾃｨの設定対象（選択ｾﾙ）
                .FocusRect = FocusRectEnum.Light                              'ｶﾚﾝﾄｾﾙのﾌｫｰｶｽ枠（細い枠）
                .ScrollBars = ScrollBars.None                                 'ｽｸﾛｰﾙﾊﾞｰ（なし）
                '.AutoSizeMode = flexAutoSizeColWidth                         'ｵｰﾄｻｲｽﾞ（列）
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter    '文字列の最後に省略符号
                '.AllowUserResizing = flexResizeColumns                       '列幅の変更許可
                .ExtendLastCol = True                                         '右端の列をｸﾞﾘｯﾄﾞに合わせる
                
                '@一覧表のﾀｲﾄﾙ設定
                headerStyle = .Styles.Fixed
                headerStyle.ForeColor = Color.Yellow            '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
                headerStyle.Font =  New Font(headerStyle.Font.FontFamily, CMlngvsfMaterialListLHFontSize, headerStyle.Font.Style, headerStyle.Font.Unit)
                headerStyle.Trimming = StringTrimming.None  

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfMaterialListLRowTitle, CMlngvsfMaterialListColNo, CMstrvsfMaterialListColTNo)                                        'No.
                .SetData(CMlngvsfMaterialListLRowTitle, CMlngvsfMaterialListColMaterialLotID, CMstrvsfMaterialListColTMaterialLotID)                  '部材管理ID
                .SetData(CMlngvsfMaterialListLRowTitle, CMlngvsfMaterialListColStatus, CMstrvsfMaterialListColTStatus)                                '状態
                .SetData(CMlngvsfMaterialListLRowTitle, CMlngvsfMaterialListColWPName, CMstrvsfMaterialListColTWPName)                                '使用装置
                .SetData(CMlngvsfMaterialListLRowTitle, CMlngvsfMaterialListColProductionDate, CMstrvsfMaterialListColTProductionDate)                '製造日
                .SetData(CMlngvsfMaterialListLRowTitle, CMlngvsfMaterialListColAcceptanceDate, CMstrvsfMaterialListColTAcceptanceDate)                '受入日
                .SetData(CMlngvsfMaterialListLRowTitle, CMlngvsfMaterialListColUseTime, CMstrvsfMaterialListColTUseTime)                              '使用開始日時
                .SetData(CMlngvsfMaterialListLRowTitle, CMlngvsfMaterialListColWPID, CMstrvsfMaterialListColTWPID)                                    '装置ID
                .SetData(CMlngvsfMaterialListLRowTitle, CMlngvsfMaterialListColVenderWarrantDays, CMstrvsfMaterialListColTVenderWarrantDays)          'ﾒｰｶｰ保証期間
                .SetData(CMlngvsfMaterialListLRowTitle, CMlngvsfMaterialListColAcceptWarrantDays, CMstrvsfMaterialListColTAcceptWarrantDays)          '受入制限期間
                .SetData(CMlngvsfMaterialListLRowTitle, CMlngvsfMaterialListColUseValidPeriod, CMstrvsfMaterialListColTUseValidPeriod)                '使用可能時間
                .SetData(CMlngvsfMaterialListLRowTitle, CMlngvsfMaterialListColUseInvalidPeriod, CMstrvsfMaterialListColTUseInvalidPeriod)            '使用禁止(不可)時間
                .SetData(CMlngvsfMaterialListLRowTitle, CMlngvsfMaterialListColWarningPeriod, CMstrvsfMaterialListColTWarningPeriod)                  'ﾜｰﾆﾝｸﾞ表示時間
                .SetData(CMlngvsfMaterialListLRowTitle, CMlngvsfMaterialListColUseInvalidPeriodJudge, CMstrvsfMaterialListColTUseInvalidPeriodJudge)  '使用禁止(不可)時間判定ﾌﾗｸﾞ
                .SetData(CMlngvsfMaterialListLRowTitle, CMlngvsfMaterialListColLastUpdate, CMstrvsfMaterialListColTLastUpdate)                        '最終更新日時
                .SetData(CMlngvsfMaterialListLRowTitle, CMlngvsfMaterialListColMaterialStatus, CMstrvsfMaterialListColTMaterialStatus)                '部材状態
                        
                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    '@列幅設定
                    .Cols(CMlngvsfMaterialListColNo).Width = CMlngvsfMaterialListColWNo                                       'No.
                    .Cols(CMlngvsfMaterialListColMaterialLotID).Width = CMlngvsfMaterialListColWMaterialLotID                 '部材管理ID
                    .Cols(CMlngvsfMaterialListColStatus).Width = CMlngvsfMaterialListColWStatus                               '状態
                    .Cols(CMlngvsfMaterialListColWPName).Width = CMlngvsfMaterialListColWWPName                               '使用装置
                    .Cols(CMlngvsfMaterialListColProductionDate).Width = CMlngvsfMaterialListColWProductionDate               '製造日
                    .Cols(CMlngvsfMaterialListColAcceptanceDate).Width = CMlngvsfMaterialListColWAcceptanceDate               '受入日
                    .Cols(CMlngvsfMaterialListColUseTime).Width = CMlngvsfMaterialListColWUseTime                             '使用開始日時
                    .Cols(CMlngvsfMaterialListColWPID).Width = CMlngvsfMaterialListColWWPID                                   '装置ID
                    .Cols(CMlngvsfMaterialListColVenderWarrantDays).Width = CMlngvsfMaterialListColWVenderWarrantDays         'ﾒｰｶｰ保証期間
                    .Cols(CMlngvsfMaterialListColAcceptWarrantDays).Width = CMlngvsfMaterialListColWAcceptWarrantDays         '受入制限期間
                    .Cols(CMlngvsfMaterialListColUseValidPeriod).Width = CMlngvsfMaterialListColWUseValidPeriod               '使用可能時間
                    .Cols(CMlngvsfMaterialListColUseInvalidPeriod).Width = CMlngvsfMaterialListColWUseInvalidPeriod           '使用禁止(不可)時間
                    .Cols(CMlngvsfMaterialListColWarningPeriod).Width = CMlngvsfMaterialListColWWarningPeriod                 'ﾜｰﾆﾝｸﾞ表示時間
                    .Cols(CMlngvsfMaterialListColUseInvalidPeriodJudge).Width = CMlngvsfMaterialListColWUseInvalidPeriodJudge '使用禁止(不可)時間判定ﾌﾗｸﾞ
                    .Cols(CMlngvsfMaterialListColLastUpdate).Width = CMlngvsfMaterialListColWLastUpdate                       '最終更新日時
                    .Cols(CMlngvsfMaterialListColMaterialStatus).Width = CMlngvsfMaterialListColWMaterialStatus               '部材状態
                End If
                
                '@非表示列設定
                .Cols(CMlngvsfMaterialListColWPID).Visible = false                      '装置ID
                .Cols(CMlngvsfMaterialListColVenderWarrantDays).Visible = false         'ﾒｰｶｰ保証期間
                .Cols(CMlngvsfMaterialListColAcceptWarrantDays).Visible = false         '受入制限期間
                .Cols(CMlngvsfMaterialListColUseValidPeriod).Visible = false            '使用可能時間
                .Cols(CMlngvsfMaterialListColUseInvalidPeriod).Visible = false          '使用禁止(不可).Visible時間
                .Cols(CMlngvsfMaterialListColWarningPeriod).Visible = false             'ﾜｰﾆﾝｸﾞ表示時間
                .Cols(CMlngvsfMaterialListColUseInvalidPeriodJudge).Visible = false     '使用禁止(不可).Visible時間判定ﾌﾗｸﾞ
                .Cols(CMlngvsfMaterialListColLastUpdate).Visible = false                '最終更新日時
                .Cols(CMlngvsfMaterialListColMaterialStatus).Visible = false            '部材状態
                
                '@表示位置の設定  
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                      'ｾﾙ表示位置：中央中央                             
               
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngvsfMaterialListLRowTitle).Height = CMlngvsfMaterialListLHHeight          '高さ
                
                '@ﾌｫｰｶｽ位置
                .LeftCol = CMlngvsfMaterialListColNo
                
                '@ﾛｯｸ
                '.Enabled = False
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light
                
                '@幅の変更を許可
                .AllowResizing = AllowResizingEnum.Both  
                
                '@ｽｸﾛｰﾙﾎﾞﾀﾝの初期化
                cmdLeft.Enabled = False         '左(<<)ｽｸﾛｰﾙﾎﾞﾀﾝ
                cmdRight.Enabled = False        '右(>>)ｽｸﾛｰﾙﾎﾞﾀﾝ
                cmdUP.Enabled = False           '上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ
                cmdDown.Enabled = False         '下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ
                
                '@各種ﾗﾍﾞﾙの初期化
                lblNowDate.Text = vbNullString               '情報取得日時
                lblMaterialCnt.Text = vbNullString           '該当件数
                lblVenderWarrantDays.Text = vbNullString     'ﾒｰｶ保証期間
                lblAcceptWarrantDays.Text = vbNullString     '受入制限期間
                lblUseValidPeriod.Text = vbNullString        '使用可能時間
                lblUseInvalidPeriod.Text = vbNullString      '使用禁止時間
                lblWarningPeriod.Text = vbNullString         'ﾜｰﾆﾝｸﾞ時間
            
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfMaterialList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfMaterialList_Disp
    '機　能：部材一覧表示
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 11:40:51 N.Kojima
    '更新日：2006/11/29 (Wed) 15:59:06 N.Kojima
    '備　考：
    '　　　：2006/10/24 (Tue) 14:58:07 N.Kojima     部材の在庫ﾁｪｯｸ・発注管理機能追加に伴い、処理追加&修正。(案件№01095)
    '　　　：2006/11/29 (Wed) 15:59:06 N.Kojima     制約期限警告追加に伴い、各種背景色設定の判定処理を追加＆修正。(案件№01586)
    '　　　：2009/09/28 (Mon) 13:34:08 T.Oide       ヶ月設定対応
    Private Sub prvvsfMaterialList_Disp()

        Dim llngCnt                 As Integer      'ｶｳﾝﾄ
        Dim lblnlblDispFlag         As Boolean      '表示判定ﾌﾗｸﾞ

        Try
            '@表示ﾌﾗｸﾞの初期化
            lblnlblDispFlag = False
            
            With vsfMaterialList
                
                .Redraw = false

                '@部材一覧表示情報初期化
                Call prvvsfMaterialList_Init()

                'NSYS 部材コンボ選択時の無限ループ対策
                RemoveHandler vsfMaterialList.RowColChange , AddressOf vsfMaterialList_RowColChange 
                RemoveHandler vsfMaterialList.BeforeRowColChange , AddressOf vsfMaterialList_BeforeRowColChange
            
                        
                '@部材一覧が0件か
                If mtypMaterialAll.lngMaterialAllCnt <> 0 Then
                    '@格納ﾃﾞｰﾀがある場合
                    
                    '@描画ﾛｯｸ
                    '.Redraw = false
                    
                    '@行数設定
                    .Rows.Count = mtypMaterialAll.lngMaterialAllCnt + 1
                    
                    '@部材一覧表示情報設定
                    For llngCnt = 0 To mtypMaterialAll.lngMaterialAllCnt-1
                        '@№
                        .SetData(llngCnt+1, CMlngvsfMaterialListColNo, llngCnt+1)
                        '@部材管理ID
                        .SetData(llngCnt+1, CMlngvsfMaterialListColMaterialLotID, _
                            mtypMaterialAll.typMaterialAllList(llngCnt).strMaterialLotID)
                        
                        '@保留中の場合
                        If mtypMaterialAll.typMaterialAllList(llngCnt).strHoldFlag = CPstrHold1 Then
                            '@背景色を赤色にする
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngVbColorRed")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngVbColorRed)
                            Dim cellRange As CellRange = .GetCellRange(llngCnt+1, CMlngvsfMaterialListLColTitle, llngCnt+1, .Cols.Count - 1)
                            cellRange.Style = newStyle
                            '@「状態」に"保"を表示する
                            .SetData(llngCnt+1, CMlngvsfMaterialListColStatus, CMstrHoldStatus)
                        
                        '@状態ID=0(発注済・未受入)の場合
                        ElseIf mtypMaterialAll.typMaterialAllList(llngCnt).strMaterialStatus = CMstrStatusOrd Then
                            '@背景色を水色にする
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngLColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngLColor)
                            Dim cellRange As CellRange = .GetCellRange(llngCnt+1, CMlngvsfMaterialListLColTitle, llngCnt+1, .Cols.Count - 1)
                            cellRange.Style = newStyle
                            '@「状態」に"未"を表示する
                            .SetData(llngCnt+1, CMlngvsfMaterialListColStatus, CMstrDeliverStatus)
                        
                        '@使用禁止(不可)時間が超過していない場合(0=超過(OK)、1=未超過(NG))
                        ElseIf mtypMaterialAll.typMaterialAllList(llngCnt).strUseInvalidPeriodJudge = CPstrOne Then
                            '@背景色を薄いｸﾞﾚｰにする
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                            Dim cellRange As CellRange = .GetCellRange(llngCnt+1, CMlngvsfMaterialListLColTitle, llngCnt+1, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        
                        '@ﾒｰｶｰ保証期間、受入制限期間、使用可能時間が超過している場合(0=未超過(OK)、1=超過(NG))
                        ElseIf mtypMaterialAll.typMaterialAllList(llngCnt).strVenderWarrantDaysJudge = CPstrOne Or _
                               mtypMaterialAll.typMaterialAllList(llngCnt).strAcceptWarrantDaysJudge = CPstrOne Or _
                               mtypMaterialAll.typMaterialAllList(llngCnt).strUseValidPeriodJudge = CPstrOne Then
                            '@背景色をﾋﾟﾝｸにする
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngStopLotColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngStopLotColor)
                            Dim cellRange As CellRange = .GetCellRange(llngCnt+1, CMlngvsfMaterialListLColTitle, llngCnt+1, .Cols.Count - 1)
                            cellRange.Style = newStyle
                            '@「状態」に"×"を表示する
                            .SetData(llngCnt+1, CMlngvsfMaterialListColStatus, CMstrPeriodOver)
                        
                        '@ﾒｰｶｰ保証ﾜｰﾆﾝｸﾞ期間、受入制限ﾜｰﾆﾝｸﾞ期間、ﾜｰﾆﾝｸﾞ表示時間が超過している場合(0=未超過(OK)、1=超過(NG))
                        ElseIf mtypMaterialAll.typMaterialAllList(llngCnt).strVenderWarrantWarningDaysJudge = CPstrOne Or _
                               mtypMaterialAll.typMaterialAllList(llngCnt).strAcceptWarrantWarningDaysJudge = CPstrOne Or _
                               mtypMaterialAll.typMaterialAllList(llngCnt).strWarningPeriodJudge = CPstrOne Then
                            '@背景色を黄色にする
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                            Dim cellRange As CellRange = .GetCellRange(llngCnt+1, CMlngvsfMaterialListLColTitle, llngCnt+1, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        Else
                            '@NULLを表示
                            .SetData(llngCnt+1, CMlngvsfMaterialListColStatus, vbNullString)
                        End If
                        
                        '@使用装置名
                        .SetData(llngCnt+1, CMlngvsfMaterialListColWPName, _
                            mtypMaterialAll.typMaterialAllList(llngCnt).strWpName)
                        '@製造日
                        If IsDate(mtypMaterialAll.typMaterialAllList(llngCnt).strProductionDate)
                            .SetData(llngCnt+1, CMlngvsfMaterialListColProductionDate, _
                                Format$(cdate(mtypMaterialAll.typMaterialAllList(llngCnt).strProductionDate), CPstrDateTimeYMD))
                        End if

                        If IsDate(mtypMaterialAll.typMaterialAllList(llngCnt).strAcceptanceDate)
                            '@受入日
                            .SetData(llngCnt+1, CMlngvsfMaterialListColAcceptanceDate, _
                                Format$(cdate(mtypMaterialAll.typMaterialAllList(llngCnt).strAcceptanceDate), CPstrDateTimeYMD))
                        End if

                        If IsDate(mtypMaterialAll.typMaterialAllList(llngCnt).strUseTime)
                            '@使用開始日時
                            .SetData(llngCnt+1, CMlngvsfMaterialListColUseTime, _
                                Format$(cdate(mtypMaterialAll.typMaterialAllList(llngCnt).strUseTime), CPstrDateTimeYMDHMS))
                        End if

                        '@使用装置ID
                        .SetData(llngCnt+1, CMlngvsfMaterialListColWPID, _
                            mtypMaterialAll.typMaterialAllList(llngCnt).strWpID)
                        '@ﾒｰｶｰ保証期間
                        .SetData(llngCnt+1, CMlngvsfMaterialListColVenderWarrantDays, _
                            mtypMaterialAll.typMaterialAllList(llngCnt).strVenderWarrantDays)
                        '@受入制限期間
                        .SetData(llngCnt+1, CMlngvsfMaterialListColAcceptWarrantDays, _
                            mtypMaterialAll.typMaterialAllList(llngCnt).strAcceptWarrantDays)
                        '@使用可能時間
                        .SetData(llngCnt+1, CMlngvsfMaterialListColUseValidPeriod, _
                            mtypMaterialAll.typMaterialAllList(llngCnt).strUseValidPeriod)
                        '@使用禁止(不可)時間
                        .SetData(llngCnt+1, CMlngvsfMaterialListColUseInvalidPeriod, _
                            mtypMaterialAll.typMaterialAllList(llngCnt).strUseInvalidPeriod)
                        '@ﾜｰﾆﾝｸﾞ表示時間
                        .SetData(llngCnt+1, CMlngvsfMaterialListColWarningPeriod, _
                            mtypMaterialAll.typMaterialAllList(llngCnt).strWarningPeriod)
                        '@使用禁止(不可)時間判定ﾌﾗｸﾞ
                        .SetData(llngCnt+1, CMlngvsfMaterialListColUseInvalidPeriodJudge, _
                            mtypMaterialAll.typMaterialAllList(llngCnt).strUseInvalidPeriodJudge)

                        If IsDate(mtypMaterialAll.typMaterialAllList(llngCnt).strEditTime)
                            '@最終更新日時
                            .SetData(llngCnt+1, CMlngvsfMaterialListColLastUpdate, _
                                Format$(cdate(mtypMaterialAll.typMaterialAllList(llngCnt).strEditTime), CPstrDateTimeYMDHMS + ".fff"))
                        End if

                        '@部材状態
                        .SetData(llngCnt+1, CMlngvsfMaterialListColMaterialStatus, _
                            mtypMaterialAll.typMaterialAllList(llngCnt).strMaterialStatus)

                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngCnt+1).Height = CMlngvsfMaterialListLHeight
                    Next llngCnt
                                
                    '@ﾕｰｻﾞによる列幅変更されていない場合
                    If mtypChgSort.blnChgWidth = False Then
                        '@列幅設定(固定列は元に戻す)
                        '.AutoSizeMode = flexAutoSizeColWidth
                        .AutoSizeCols(CMlngvsfMaterialListColNo, CMlngvsfMaterialListColLastUpdate, 6)
                    End If
                    
                    '@表示位置設定
                    .cols(CMlngvsfMaterialListColNo).TextAlign =  TextAlignEnum.RightCenter                     '№(右中央).TextAlign
                    .cols(CMlngvsfMaterialListColMaterialLotID).TextAlign  = TextAlignEnum.LeftCenter           '部材管理ID(左中央).TextAlign
                    .cols(CMlngvsfMaterialListColStatus).TextAlign  = TextAlignEnum.LeftCenter                  '状態(左中央).TextAlign
                    .cols(CMlngvsfMaterialListColWPName).TextAlign  = TextAlignEnum.LeftCenter                  '装置名(左中央).TextAlign
                    .cols(CMlngvsfMaterialListColProductionDate).TextAlign = TextAlignEnum.LeftCenter           '製造日(左中央).TextAlign
                    .cols(CMlngvsfMaterialListColAcceptanceDate).TextAlign = TextAlignEnum.LeftCenter           '受入日(左中央).TextAlign
                    .cols(CMlngvsfMaterialListColUseTime).TextAlign = TextAlignEnum.LeftCenter                  '使用開始日時(左中央).TextAlign
                    .cols(CMlngvsfMaterialListColWPID).TextAlign =  TextAlignEnum.LeftCenter                    '装置ID(左中央).TextAlign
                    .cols(CMlngvsfMaterialListColVenderWarrantDays).TextAlign  = TextAlignEnum.RightCenter      'ﾒｰｶｰ保証期間(右中央).TextAlign
                    .cols(CMlngvsfMaterialListColAcceptWarrantDays).TextAlign  = TextAlignEnum.RightCenter      '受入制限期間(右中央).TextAlign
                    .cols(CMlngvsfMaterialListColUseValidPeriod).TextAlign =  TextAlignEnum.RightCenter         '使用可能時間(右中央).TextAlign
                    .cols(CMlngvsfMaterialListColUseInvalidPeriod).TextAlign =  TextAlignEnum.RightCenter       '使用禁止(不可).TextAlign時間(右中央).TextAlign
                    .cols(CMlngvsfMaterialListColWarningPeriod).TextAlign =  TextAlignEnum.RightCenter          'ﾜｰﾆﾝｸﾞ時間(右中央).TextAlign
                    .cols(CMlngvsfMaterialListColUseInvalidPeriodJudge).TextAlign =  TextAlignEnum.RightCenter  '使用禁止(不可).TextAlign時間判定ﾌﾗｸﾞ(右中央).TextAlign
                    .cols(CMlngvsfMaterialListColLastUpdate).TextAlign =  TextAlignEnum.LeftCenter              '最終更新日時(左中央).TextAlign
                    .cols(CMlngvsfMaterialListColMaterialStatus).TextAlign =  TextAlignEnum.LeftCenter          '部材状態(左中央).TextAlign
                            
                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort.lngCnt-1
                            '@該当行をｿｰﾄ
                            .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder, mtypChgSort.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If
                                         
                    '@ｸﾞﾘｯﾄﾞを初期値へ移動
        '            .LeftCol = CMlngvsfMaterialListLColTitle       '列
                    .TopRow = CMlngvsfMaterialListLRowTitle        '行
                    .Row = CMlngvsfMaterialListLRowTitle           'ｶﾚﾝﾄ行の移動                    
                            
                    '@左右ｽｸﾛｰﾙ制御の記述
                    '@ｶﾚﾝﾄ列初期化
                    .Col = .Cols.Fixed
                    .LeftCol = .Cols.Fixed
                                       
                    '@左右ｽｸﾛｰﾙﾎﾞﾀﾝ制御（ｸﾞﾘｯﾄﾞ共通化関数）
                    Call pubCmdLREnable_Set(vsfMaterialList, cmdLeft, cmdRight)

                    '@前頁、次頁、ｽｸﾛｰﾙﾗﾍﾞﾙ表示設定
                    If .Rows.Count > CMlngvsfMaterialListows Then
                        cmdUP.Enabled = True
                        cmdDown.Enabled = True
                    Else
                        cmdUP.Enabled = False
                        cmdDown.Enabled = False
                    End If
                    
                    '@ｿｰﾄ検索用ｷｰがある場合
                    If mtypChgSort.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@ｿｰﾄｷｰが同じ場合
                            If .GetData(llngCnt, CMlngvsfMaterialListColMaterialLotID) = mtypChgSort.strKey Then
                                'NSYS ボタン制御対策
                                AddHandler vsfMaterialList.RowColChange , AddressOf vsfMaterialList_RowColChange
                                AddHandler vsfMaterialList.BeforeRowColChange , AddressOf vsfMaterialList_BeforeRowColChange
                                .Row = llngCnt
                                RemoveHandler vsfMaterialList.RowColChange , AddressOf vsfMaterialList_RowColChange 
                                RemoveHandler vsfMaterialList.BeforeRowColChange , AddressOf vsfMaterialList_BeforeRowColChange
                                '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列）
                                Call pubVsfBeforeSort(vsfMaterialList, CMlngvsfMaterialListColMaterialLotID)

                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定（ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁）
                                Call pubVsfAfterSort(vsfMaterialList, CMlngvsfMaterialListColMaterialLotID, cmdUP, cmdDown)

                                Exit For
                            End If
                        Next llngCnt
                    End If
                    
                    '@↑ｽｸﾛｰﾙﾎﾞﾀﾝの制御
                    If .TopRow = .Rows.Fixed Then
                        '@ﾛｯｸ
                        cmdUP.Enabled = False
                    Else
                        '@ﾛｯｸ解除
                        cmdUP.Enabled = True
                    End If
                    '@↓ｽｸﾛｰﾙﾎﾞﾀﾝの制御
                    If .TopRow + CMlngvsfMaterialListows >= .Rows.Count Then
                        '@ﾛｯｸ
                        cmdDown.Enabled = False
                    Else
                        '@ﾛｯｸ解除
                        cmdDown.Enabled = True
                    End If
                    
                    '@文字が表示しきれない場合の処理
                    .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter  
                    
                    '@描画ﾛｯｸ解除
                    '.Redraw = True
                    
                    '@ﾛｯｸ解除
                    '.Enabled = True
                    
                    'LostFocusイベントと中のValidateイベントの無限ループ防止策
                    RemoveHandler cmbMaterial.Leave, AddressOf cmbMaterial_LostFocus
                    RemoveHandler cmbWP.Leave, AddressOf cmbWP_LostFocus
                    '@表にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfMaterialList)
                    AddHandler cmbMaterial.Leave, AddressOf cmbMaterial_LostFocus
                    AddHandler cmbWP.Leave, AddressOf cmbWP_LostFocus
                
                End If
                
                '@各種ﾗﾍﾞﾙに情報表示
                '@ﾒｰｶｰ保証期間
                If IsNumeric(mtypMaterialAll.strVenderWarrantDays)
                    lblVenderWarrantDays.Text = _
                        Format$(Double.Parse(mtypMaterialAll.strVenderWarrantDays), CPstrCFKnmaFormat)
                End if
                '@受入制限期間
                If IsNumeric(mtypMaterialAll.strAcceptWarrantDays)
                    lblAcceptWarrantDays.Text = _
                        Format$(Double.parse(mtypMaterialAll.strAcceptWarrantDays), CPstrCFKnmaFormat)
                End if
        '@↓2009/09/28 (Mon) 13:33:36 T.Oide **************************************************
                '@単位(ﾒｰｶｰ保証期間)
                If mtypMaterialAll.strUnitClassVwd = CMstrUnitClassM Then
                    lblDay1.Text = CMstrUnitM
                Else
                    lblDay1.Text = CMstrUnitD
                End If
                '@単位(受入制限期間)
                If mtypMaterialAll.strUnitClassAwd = CMstrUnitClassM Then
                    lblDay2.Text = CMstrUnitM
                Else
                    lblDay2.Text = CMstrUnitD
                End If
        '@↑2009/09/28 (Mon) 13:33:36 T.Oide **************************************************
                '@使用可能時間
                If IsNumeric(mtypMaterialAll.strUseValidPeriod)
                    lblUseValidPeriod.Text = _
                        Format$(Double.parse(mtypMaterialAll.strUseValidPeriod), CPstrCFKnmaFormat)
                End if    
        '@↓2009/11/17 (Tue) 16:57:32 T.Oide **************************************************
                '@単位(受入制限期間)
                Select Case mtypMaterialAll.strUnitClassUvp
                
                    '@｢ヶ月｣の場合
                    Case CMstrUnitClassM
                        lblTime1.Text = CMstrUnitM
                    
                    '@｢日｣の場合
                    Case CMstrUnitClassD
                        lblTime1.Text = CMstrUnitD
                    
                    '@｢時間｣の場合
                    Case CMstrUnitClassH
                        lblTime1.Text = CMstrUnitH
                        
                End Select
        '@↑2009/11/17 (Tue) 16:57:32 T.Oide **************************************************
                
                    
                '@使用禁止(不可)時間
                If IsNumeric(mtypMaterialAll.strUseInvalidPeriod)
                    lblUseInvalidPeriod.Text = _
                        Format$(Double.Parse(mtypMaterialAll.strUseInvalidPeriod), CPstrCFKnmaFormat)
                End if

                '@ﾜｰﾆﾝｸﾞ表示時間
                If IsNumeric(mtypMaterialAll.strWarningPeriod)
                    lblWarningPeriod.Text = _
                        Format$(Double.Parse(mtypMaterialAll.strWarningPeriod), CPstrCFKnmaFormat)
                End if
                
            End With
            
            '@情報取得日時表示
            lblNowDate.Text = Format$(Now, CPstrDateFormat)
            
            '@該当件数ﾗﾍﾞﾙに取得件数を表示
            If mtypMaterialAll.lngMaterialAllCnt = 0 Then
                '@"0"を表示
                lblMaterialCnt.Text = CPstrZero
            Else
                '@ﾌｫｰﾏｯﾄして表示
                lblMaterialCnt.Text = Format$(integer.Parse(mtypMaterialAll.lngMaterialAllCnt), CPstrCFKnmaFormat)
            End If

            'NSYS 描画ロット解除
            vsfMaterialList.Redraw = True 

            'NSYS グリッドロック解除
            vsfMaterialList.Enabled = True

            AddHandler vsfMaterialList.RowColChange , AddressOf vsfMaterialList_RowColChange
            AddHandler vsfMaterialList.BeforeRowColChange , AddressOf vsfMaterialList_BeforeRowColChange

            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfMaterialList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbMaterialType_Disp
    '機　能：部材種別情報表示
    '引　数：mtypVenderlist：取得情報格納ﾃﾞｰﾀ
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 09:08:08 N.Kojima
    '更新日：2006/04/14 (Fri) 09:08:08
    '備　考：
    Private Sub prvCmbMaterialType_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbMaterialType
                '@部材種別情報初期化
                .Clear
                .Height = CMlngCmbHeight                                        '高さ
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbGridColID                                   '値取得列
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter   '左寄中央揃え
                
                '@部材種別情報ｾｯﾄ
                For llngCnt = 0 To mtypMaterialType.lngMaterialTypeCnt-1
                    '@「部材種別ID」
                    .AddItem(mtypMaterialType.typMaterialTypeList(llngCnt).strMaterialTypeID)
                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbMaterialType_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbMaterial_Disp
    '機　能：部材ｺﾝﾎﾞに取得情報をｾｯﾄ
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 10:07:28 N.Kojima
    '更新日：2006/10/23 (Mon) 14:12:47 N.Kojima
    '備　考：
    '　　　：2006/10/23 (Mon) 14:12:47 N.Kojima     発注ﾎﾟｲﾝﾄ数も格納。(案件№01095)
    Private Sub prvCmbMaterial_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbMaterial
                '@部材ｺﾝﾎﾞ初期化
                .Clear
                .Height = CMlngCmbHeight                                        '高さ
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbGridColID                                   '値取得列
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter      '左寄中央揃え
                
                '@部品情報ｾｯﾄ
                For llngCnt = 0 To mtypMaterial.lngMaterialCnt-1
                    '@「部材ID/発注ﾎﾟｲﾝﾄ」
                    .AddItem(mtypMaterial.typMaterialIDList(llngCnt).strMaterialID & vbTab & _
                             mtypMaterial.typMaterialIDList(llngCnt).strOrderRemainNum)
                Next llngCnt
            
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbMaterial_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbMaterialWP_Disp
    '機　能：使用装置ｺﾝﾎﾞに取得情報をｾｯﾄ
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 10:53:44 N.Kojima
    '更新日：2006/06/26 (Mon) 17:07:20 N.Kojima
    '備　考：
    '　　　：2006/06/26 (Mon) 17:07:20 N.Kojima     ｺﾝﾎﾞに"装置なし"を追加。(ﾕｰｻﾞｰ要望№0189)
    Private Sub prvCmbMaterialWP_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbWp
                '@使用装置ｺﾝﾎﾞ初期化
                .Clear
                .Height = CMlngCmbHeight                                        '高さ
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbGridColID                                   '値取得列
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter      '左寄中央揃え
                
                '@選択部材に紐付く装置が存在しない場合
                If mtypMaterialWP.lngMaterialWPCnt = 0 Then
                    '@先頭に"装置なし"をｾｯﾄ
                    .AddItem(CMstrNoWP)
                End If
                
                '@使用装置情報ｾｯﾄ
                For llngCnt = 0 To mtypMaterialWP.lngMaterialWPCnt-1
                    '@「使用装置名」,「使用装置ID」
                    .AddItem(mtypMaterialWP.typMaterialWPList(llngCnt).strWpName _
                            & vbTab _
                            & mtypMaterialWP.typMaterialWPList(llngCnt).strWpID)
                Next llngCnt
            
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmbMaterialWP_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnMaterialPeriod_Chk
    '機　能：使用部材ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/19 (Wed) 14:38:28 N.Kojima
    '更新日：2006/10/03 (Tue) 15:36:17 N.Kojima
    '備　考：
    '　　　：2006/06/29 (Thu) 10:26:42 N.Kojima     機種限定ﾁｪｯｸﾌﾗｸﾞ追加に伴い、処理修正。(ﾕｰｻﾞｰ要望№0189)
    '　　　：2006/10/03 (Tue) 15:36:17 N.Kojima     部材判定Msgの変更に伴い、通信処理への引数を変更。(案件№01472)
    Private Function prvblnMaterialPeriod_Chk() As Boolean

        Dim lblnAns                 As Boolean              '戻り値判定用
        Dim ltypChkMaterial         As ChkMaterial          '装置使用部材判定要求格納用

        Try
                    
            '@戻り値の初期化
            prvblnMaterialPeriod_Chk = False
            
            Me.KeyPreview = False
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvblnMaterialChk)
            
            '@送信ﾃﾞｰﾀ格納
            With ltypChkMaterial
                .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strMsgVer = CMstrmat_chkwpmaterialVer      'Msgﾊﾞｰｼﾞｮﾝ
                .strMaterialTypeID = cmbMaterialType.Text   '部材種別ID
                .strMaterialID = cmbMaterial.Text           '部材ID
                .strWpID = cmbWp.Value                      '装置ID
                .strMaterialLotID = vsfMaterialList.GetData(vsfMaterialList.Row, CMlngvsfMaterialListColMaterialLotID)     '部材管理ID
            
                '@呼び出しﾄﾘｶﾞにより設定値を変更
                Select Case mstrAction
                    '@使用開始ﾎﾞﾀﾝからのﾄﾘｶﾞ
                    Case CPstrZero
                        .strClassDivision = CPstrCD47
                        
                    '@装置使用開始ﾎﾞﾀﾝからのﾄﾘｶﾞ
                    Case CPstrOne
                        .strClassDivision = CPstrCD46
                End Select
            End With
                
            '@装置使用部材判定ﾒｯｾｰｼﾞ送信
            lblnAns = pubblnMatChkWPMaterial_Chk(ltypChkMaterial, _
                                                 mstrPdErrMsg, _
                                                 mstrLimitErrMsg)
                                                     
           
            Me.KeyPreview = True
            
            '@戻り値判定
            If lblnAns = True Then
                '@取得成功
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrPrvblnMaterialChk)
         
                '@戻り値の設定
                prvblnMaterialPeriod_Chk = True
            Else
                '@取得失敗場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvblnMaterialChk)
            End If

            Exit Function

        Catch ex As Exception

            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnMaterialPeriod_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnMaterialStock_Chk
    '機　能：使用部材の在庫ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/10/20 (Fri) 13:15:49 N.Kojima
    '更新日：2006/10/20 (Fri) 13:15:49
    '備　考：
    Private Function prvblnMaterialStock_Chk() As Boolean

        Dim lblnAns                     As Boolean              '戻り値判定用
        Dim ltypChkMaterialStock        As ChkMaterial          '装置使用部材判定要求格納用

        Try
                    
            '@戻り値の初期化
            prvblnMaterialStock_Chk = False
            
            
            Me.KeyPreview = False
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvblnMaterialStockChk)
            
            '@送信ﾃﾞｰﾀ格納
            With ltypChkMaterialStock
                .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strMsgVer = CMstrmat_chkmaterialstockVer   'Msgﾊﾞｰｼﾞｮﾝ
                .strMaterialTypeID = cmbMaterialType.Text   '部材種別ID
                .strMaterialID = cmbMaterial.Text           '部材ID
                .strMaterialLotID = vsfMaterialList.GetData(vsfMaterialList.Row, CMlngvsfMaterialListColMaterialLotID)     '部材管理ID
            End With
            
            '@装置使用部材在庫ﾁｪｯｸﾒｯｾｰｼﾞ送信
            lblnAns = pubblnMatChkMaterialStock_Chk(ltypChkMaterialStock, _
                                                    mstrStockErrMsg)
                                                     

            Me.KeyPreview = True
            
            '@戻り値判定
            If lblnAns = True Then
                '@取得成功
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrPrvblnMaterialStockChk)
         
                '@戻り値の設定
                prvblnMaterialStock_Chk = True
            Else
                '@取得失敗
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvblnMaterialStockChk)
            
            
            End If

            Exit Function

        Catch ex As Exception

            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnMaterialStock_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnAuthority_Chk
    '機　能：期限超過部材使用権限ﾁｪｯｸ処理
    '引　数：lstrForcedAction   :強制実行判定ﾌﾗｸﾞ
    '戻り値：なし
    '作成日：2006/04/19 (Wed) 15:33:03 N.Kojima
    '更新日：2006/10/20 (Fri) 14:34:41 N.Kojima
    '備　考：
    '　　　：2006/10/20 (Fri) 14:34:41 N.Kojima     部材の在庫ﾁｪｯｸ・発注管理機能追加に伴い、処理追加&修正。(案件№01095)
    '　　　：2008/01/18 (Fri) 16:52:00 S.Ochiai     保留/保留解除対応(案件№02463)に伴い、処理見直し。
    Private Function prvblnAuthority_Chk(ByVal lstrPrivCheck As String) As Boolean

        Dim lblnAns                 As Boolean              '戻り値判定用
        Dim lstrFunctionID          As String               '機能ID
        Dim lstrActionID            As String               'ｱｸｼｮﾝID
    '    Dim lstrActionID2           As String               'ｱｸｼｮﾝID2
    '    Dim llngAuthorityChkTimes   As Long                 '権限ﾁｪｯｸ回数格納用
    '    Dim llngCnt                 As Long                 '汎用ｶｳﾝﾀ
        Dim lstrEmpID               As String               '作業者ID
        Dim lstrEmpName             As String               '作業者名
        Dim lstrSBID                As String               'ｼｽﾃﾑﾌﾞﾛｯｸ

        Try
                    
            '@各種初期化
            prvblnAuthority_Chk = False
        '    llngAuthorityChkTimes = 1       '権限ﾁｪｯｸ回数
                    
            '@権限ﾁｪｯｸ無の場合
            If lstrPrivCheck = CPstrZero Then
                prvblnAuthority_Chk = True
                Exit Function
            End If
                    
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合処理を受付けない。
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Function
            End If
            
            '@ﾌｫｰﾑﾛｯｸ中の場合は処理を受け付けない
            If Me.Enabled = False Then
                Exit Function
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvblnAuthorityChk)
            
           
            Me.KeyPreview = False
            
            '@強制実行判定ﾌﾗｸﾞの値によって処理
            Select Case lstrPrivCheck
                
                '@「1:在庫ﾁｪｯｸ」
                Case CPstrOne
                    '@実行権限の処理を追加
                    lstrFunctionID = CPstrKeyEN01V0             '機能ID：EN01V0
                    lstrActionID = CPstrUseNewMaterial          'ｱｸｼｮﾝID：新部材使用
                    lstrEmpID = pstrUserID                      'ﾕｰｻﾞｰID
                    lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名
                    lstrSBID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                    
                '@「2:期限超過ﾁｪｯｸ」
                Case CPstrTwo
                    '@実行権限の処理を追加
                    lstrFunctionID = CPstrKeyEN01V0             '機能ID：EN01V0
                    lstrActionID = CPstrUsePeriodOverMaterial   'ｱｸｼｮﾝID：期限超過部材使用
                    lstrEmpID = pstrUserID                      'ﾕｰｻﾞｰID
                    lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名
                    lstrSBID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                
                '@「4:保留/保留解除ﾁｪｯｸ」
                Case CPstrFour
                    lstrFunctionID = CPstrKeyEN01V0             '機能ID：EN01V0
                    lstrActionID = CPstrHoldRelease             'ｱｸｼｮﾝID ：保留/保留解除
                    lstrEmpID = pstrUserID                      'ﾕｰｻﾞｰID
                    lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名
                    lstrSBID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ

                '無効化
                Case CPstrEight
                    lstrFunctionID = CPstrKeyEN01V0             '機能ID：EN01V0
                    lstrActionID = CPstrInvalid                 'ｱｸｼｮﾝID ：無効化
                    lstrEmpID = pstrUserID                      'ﾕｰｻﾞｰID
                    lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名
                    lstrSBID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ

                '@その他の場合は権限ﾁｪｯｸを行わない(基本的にはありえない)
                Case Else
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrPrvblnAuthorityChk)
                    prvblnAuthority_Chk = True
                    Exit Function
            
            End Select

            '@実行権限ﾁｪｯｸ
            lblnAns = pubAuthority_Chk(lstrFunctionID, lstrActionID, lstrEmpID, lstrEmpName, lstrSBID)
                
          
            Me.KeyPreview = True
                
            '@結果判定
            If lblnAns = False Then
                '@権限が"なし"の場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvblnAuthorityChk)
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, lstrActionID)
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

            Exit Function

        Catch ex As Exception

            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnAuthority_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnChgMaterial_Chk
    '機　能：使用部材判定＆権限ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True   ：権限あり or 通常実行
    '　　　：False  ：権限なし or 処理中断
    '作成日：2006/04/19 (Wed) 16:26:10 N.Kojima
    '更新日：2006/11/29 (Wed) 19:40:46 T.Kitagawa
    '備　考：
    '　　　：2006/10/03 (Tue) 15:46:50 N.Kojima     部材期限判定処理を修正(変数変更)。(案件№01472)
    '　　　：2006/10/20 (Fri) 14:43:48 N.Kojima     部材の在庫ﾁｪｯｸ・発注管理機能追加に伴い、処理追加&修正。(案件№01095)
    '　　　：2006/11/29 (Wed) 19:40:46 T.Kitagawa　 ﾊﾟｽﾜｰﾄﾞ確認機能追加（案件№01581）
    '　　　：2008/01/18 (Fri) 16:18:00 S.Ochiai  　 保留/保留解除処理追加。(案件№02463)
    Private Function prvblnChgMaterial_Chk() As Boolean

        Dim lblnAns                 As Boolean      '戻り値判定用(true or false)
        Dim llngAns                 As Integer      '戻り値判定用(ﾒｯｾｰｼﾞﾎﾞｯｸｽからのﾘﾀｰﾝ値参照)
        Dim lstrPrivCheck           As String       '権限確認判定用
                                                    '0:権限ﾁｪｯｸ無
                                                    '1:在庫ﾁｪｯｸ(指定部材より製造日/受入日の古い部材の有無)
                                                    '2:期限超過ﾁｪｯｸ
                                                    '3:在庫ﾁｪｯｸ/期限超過ﾁｪｯｸ両方
                                                    '4:保留/保留解除ﾁｪｯｸ

        Try
            
            '@各種初期化
            prvblnChgMaterial_Chk = False
            lstrPrivCheck = CPstrZero           '権限判定用ﾌﾗｸﾞ
            
            '@"0"=使用開始ﾎﾞﾀﾝ押下の場合
            If mstrAction = CPstrZero Then
            
                '@---- 使用部材在庫ﾁｪｯｸ ----
                '@装置使用部材の在庫判定処理を行なう
                lblnAns = prvblnMaterialStock_Chk
                
                '@ｴﾗｰMsg判定,当機能では在庫ﾁｪｯｸのみ(製造日or受入日のどちらかが古い部材が他にある場合、"Msgあり")
                If lblnAns = True Then
                    '@ﾁｪｯｸOK
            
                    '@ｴﾗｰMsg判定(Msg有り=製造日or受入日のどちらかが古い部材が他にある、Msg無し=製造日or受入日のどちらかが古い部材が他にない)
                    If mstrStockErrMsg <> vbNullString Then
                        '@ｴﾗｰMsgが格納されている場合
            
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM7UW>$$%1"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007U, mstrStockErrMsg)
                        '@確認ﾒｯｾｰｼﾞBOXを表示する
                        llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
            
                        '@要求確認
                        If llngAns = vbNo Then
                            '@戻り値を"false=処理中断"を設定
                            prvblnChgMaterial_Chk = False
                            '@処理中断
                            Exit Function
                        Else
                            '@権限確認用変数に「1:在庫ﾁｪｯｸ」をｾｯﾄ
                            lstrPrivCheck = CPstrOne
                        End If
                    End If
                Else
                    '@ﾁｪｯｸNG(=ﾁｪｯｸ処理失敗)
                    Exit Function
                End If
            End If
            
            '@"0"=使用開始ﾎﾞﾀﾝまたは"1"=装置使用開始ﾎﾞﾀﾝ押下の場合
            If mstrAction = CPstrZero Or _
               mstrAction = CPstrOne Then
                '@---- 使用部材期限関連ﾁｪｯｸ ----
                '@装置使用部材の判定処理(期限関連)を行なう
                lblnAns = prvblnMaterialPeriod_Chk
                
                '@ｴﾗｰMsg判定,当機能では部材期限ﾁｪｯｸのみ(何らかの期限制約に引っ掛かっている場合は、"Msgあり")
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
                            '@処理中断
                            Exit Function
                        Else
                            '@権限確認用変数に「1:在庫ﾁｪｯｸ」がｾｯﾄされている場合
                            If lstrPrivCheck = CPstrOne Then
                                '@権限確認用変数に「3:両方ﾁｪｯｸ」をｾｯﾄ
                                lstrPrivCheck = CPstrThree
                            Else
                                '@権限確認用変数に「2:期限超過ﾁｪｯｸ」をｾｯﾄ
                                lstrPrivCheck = CPstrTwo
                            End If
                            
                        End If
                    End If
                Else
                    '@ﾁｪｯｸNG
                    Exit Function
                End If
            End If

            '@"6"=保留ﾎﾞﾀﾝまたは"7"=保留解除ﾎﾞﾀﾝの場合
            If mstrAction = CPstrSix Or _
               mstrAction = CPstrSeven Then
                '@権限確認用変数に「4:保留/保留解除ﾁｪｯｸ」をｾｯﾄ
                lstrPrivCheck = CPstrFour
            End If

            '無効化(8)
            If mstrAction = CPstrEight Then
                lstrPrivCheck = CPstrEight
            End If

            '@作業者ｺｰﾄﾞ入力
            '@権限確認有の場合は、権限ﾁｪｯｸを行う為、ﾊﾟｽﾜｰﾄﾞ入力とする
            If lstrPrivCheck <> CPstrZero Then
                '@作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力
                frmxxCM0020.Instance.ShowDialog(Me)
                frmxxCM0020.Instance = Nothing
            Else
                '@作業者ｺｰﾄﾞ入力
                frmxxCM0010.Instance.ShowDialog(Me)
                frmxxCM0010.Instance = Nothing
            End If
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                '@戻り値を"false=処理中断"を設定
                prvblnChgMaterial_Chk = False
                Exit Function
            End If
            
            '@権限ﾁｪｯｸ実行
            '@「3:両方ﾁｪｯｸ」の場合は、「1:在庫ﾁｪｯｸ」及び「2:権限超過ﾁｪｯｸ」の両方の権限ﾁｪｯｸを実行
            If mstrAction <> CPstrThree Then
                lblnAns = prvblnAuthority_Chk(lstrPrivCheck)
            Else
                lblnAns = prvblnAuthority_Chk(CPstrOne)
                If lblnAns = True Then
                    lblnAns = prvblnAuthority_Chk(CPstrTwo)
                End If
            End If

            prvblnChgMaterial_Chk = lblnAns
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnChgMaterial_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvVsfCmdLeft
    '機　能：ｸﾞﾘｯﾄﾞの左へﾌｫｰｶｽ移動処理
    '引　数：lobjvsfGrid：ｸﾞﾘｯﾄﾞ
    '　　　：lobjcmdLeft：左ﾎﾞﾀﾝ
    '　　　：lobjcmdRight：右ﾎﾞﾀﾝ
    '戻り値：なし
    '作成日：2006/03/13 (Mon) 11:17:22 N.Kasai
    '更新日：2006/05/08 (Mon) 09:21:05 N.Kojima
    '備　考：
    Public Sub prvVsfCmdLeft(ByVal lobjvsfGrid As Object, Optional ByVal lobjcmdLeft As Object = Nothing, _
                           Optional ByVal lobjcmdRight As Object = Nothing)

        Dim llngLeftCol         As Integer  '画面表示最左Col番号
        Dim llngLeftColCal      As Integer  '計算後の最左Col番号
        Dim llngRightCol        As Integer  '画面表示最右Col番号
        Dim llngMinCol          As Integer  '固定Col数
        Dim llngMaxCol          As Integer  'Col総数
        Dim llngHideStartCol    As Integer  '表示変動開始Col番号
        Dim llngRow             As Integer  '取得Row番号
        Dim llngloopcount       As Integer  'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngWidthAll        As Integer  'Col全体の幅
        Dim llngWidthHide       As Integer  'ｽｸﾛｰﾙで隠れたColの幅
        Dim llngWidth           As Integer  'Colの幅

        Try
            
            '@初期設定
            llngLeftCol = 0
            llngLeftColCal = 0
            llngRightCol = 0
            llngMinCol = 0
            llngMaxCol = 0
            llngHideStartCol = 0
            llngloopcount = 0
            llngWidthAll = 0
            llngWidthHide = 0
            llngWidth = 0
            
            '@横ｽｸﾛｰﾙ発生ﾌﾗｸﾞによる処理分岐
            If mlngSideScrollFlag = CMlngSideScrollOffFlag Then
                Exit Sub
            End If

            With lobjvsfGrid
            
                '@画面表示最左Col番号取得
                llngLeftCol = .LeftCol
                
                '@画面表示最右Col番号取得
                llngRightCol = .RightCol
                
                '@固定Col番号取得(=.FrozenCols:固定列数 -1)
                llngMinCol = .FrozenCols - 1
                
                '@ｽｸﾛｰﾙで隠れるCol番号取得
                llngHideStartCol = llngMinCol + 1
                
                '@一覧ｽｸﾛｰﾙ制御
                '@ｸﾞﾘｯﾄﾞの固定列より,可動する列(最左)が小さい場合
                If llngLeftCol > llngMinCol Then
                    llngLeftColCal = llngLeftCol - 1
                    .ShowCell(llngRow, llngLeftColCal)
                Else
                    '@ｸﾞﾘｯﾄﾞの固定列と,可動する列(最左)が同じ場合
                    If llngLeftCol = llngMinCol Then
                        llngLeftColCal = llngLeftCol
                        .ShowCell(llngRow, llngLeftColCal)
                    End If
                End If
                
                '@最大Col番号取得(非表示項目含まない)
                For llngloopcount = 0 To .Cols.Count - 1
                    If .ColHidden(llngloopcount) <> True Then
                        llngMaxCol = llngMaxCol + 1
                    End If
                Next llngloopcount

                '@全列数の幅取得(非表示項目は含めない)
                For llngloopcount = 0 To .Cols.Count - 1
                    If .ColHidden(llngloopcount) <> True Then
                        llngWidthAll = llngWidthAll + .Cols(llngloopcount).Width
                    End If
                Next llngloopcount
                
                '@ｽｸﾛｰﾙで隠れた列の幅を取得
                For llngloopcount = llngHideStartCol To llngLeftColCal - 1
                    llngWidthHide = llngWidthHide + .Cols(llngloopcount).Width
                Next llngloopcount
                
                '@ｽｸﾛｰﾙﾎﾞﾀﾝ制御(右側)
                llngWidth = llngWidthAll - llngWidthHide
                '@ｸﾞﾘｯﾄﾞの全体幅より、表示使用としている全列幅が大きい場合
                If .Width - llngWidth <= 0 Then
                    lobjcmdRight.Enabled = True
                Else
                    lobjcmdRight.Enabled = False
                End If
                
                '@ｽｸﾛｰﾙﾎﾞﾀﾝ制御(左側)
                '@可動する列(最左)と,隠れている列が同じ場合
                If llngLeftColCal = llngHideStartCol Then
                    lobjcmdLeft.Enabled = False
                Else
                    lobjcmdLeft.Enabled = True
                End If
                
                '@ﾌｫｰｶｽをｾｯﾄ
                Call pubSetFocus(lobjvsfGrid)
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCmdLeft"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvVsfCmdRight
    '機　能：ｸﾞﾘｯﾄﾞの右へﾌｫｰｶｽ移動
    '引　数：lobjvsfGrid：ｸﾞﾘｯﾄﾞ
    '　　　：lobjcmdLeft：左ﾎﾞﾀﾝ
    '　　　：lobjcmdRight：右ﾎﾞﾀﾝ
    '戻り値：なし
    '作成日：2006/03/13 (Mon) 11:17:06 N.Kasai
    '更新日：2006/05/08 (Mon) 09:21:57 N.Kojima
    '備　考：
    Public Sub prvVsfCmdRight(ByVal lobjvsfGrid As Object, Optional ByVal lobjcmdLeft As Object = Nothing, _
                           Optional ByVal lobjcmdRight As Object = Nothing)

        Dim llngLeftCol         As Integer  '画面表示最左Col番号
        Dim llngLeftColCal      As Integer  '計算後の最左Col番号
        Dim llngMinCol          As Integer  '固定Col数
        Dim llngMaxCol          As Integer  'Col総数
        Dim llngHideStartCol    As Integer  '表示変動開始Col番号
        Dim llngloopcount       As Integer  'ループカウント
        Dim llngWidthAll        As Integer  'Col全体の幅
        Dim llngWidthHide       As Integer  'ｽｸﾛｰﾙで隠れたColの幅
        Dim llngWidth           As Integer  'Colの幅

        Try
            
            '@初期設定
            llngLeftCol = 0
            llngLeftColCal = 0
            llngMinCol = 0
            llngMaxCol = 0
            llngHideStartCol = 0
            llngloopcount = 0
            llngWidthAll = 0
            llngWidthHide = 0
            llngWidth = 0
            
            '@横ｽｸﾛｰﾙ発生ﾌﾗｸﾞによる処理分岐
            If mlngSideScrollFlag = CMlngSideScrollOffFlag Then
                Exit Sub
            End If
            
            With lobjvsfGrid
            
                '@ｽｸﾛｰﾙ制御(最終列直前まで)
                llngLeftCol = .LeftCol
                llngLeftColCal = llngLeftCol + 1
                .LeftCol = llngLeftColCal
                
                '@固定Col番号取得(=.FrozenCols:固定列数 -1)
                llngMinCol = .FrozenCols - 1
                
                '@ｽｸﾛｰﾙで隠れるCol番号取得
                llngHideStartCol = llngMinCol + 1
             
                '@最大Col番号取得(非表示項目含まない)
                For llngloopcount = 0 To .Cols.Count - 1
                    If .ColHidden(llngloopcount) <> True Then
                        llngMaxCol = llngMaxCol + 1
                    End If
                Next llngloopcount

                '@全列数の幅取得(非表示項目は含めない)
                For llngloopcount = 0 To .Cols.Count - 1
                    If .ColHidden(llngloopcount) <> True Then
                        llngWidthAll = llngWidthAll + .Cols(llngloopcount).Width
                    End If
                Next llngloopcount
                
                '@ｽｸﾛｰﾙで隠れた列の幅を取得
                For llngloopcount = llngHideStartCol To llngLeftCol
                    llngWidthHide = llngWidthHide + .Cols(llngloopcount).Width
                Next llngloopcount
                
                '@ｽｸﾛｰﾙﾎﾞﾀﾝ制御(右側)
                llngWidth = llngWidthAll - llngWidthHide + 75
                '@ｸﾞﾘｯﾄﾞの全体幅より、表示使用としている全列幅が大きい場合
                If .Width - llngWidth <= 0 Then
                    lobjcmdRight.Enabled = True
                Else
                    lobjcmdRight.Enabled = False
                End If
                
                '@ｽｸﾛｰﾙﾎﾞﾀﾝ制御(左側)
                '@可動する列(最左)と,隠れている列が同じ場合
                If llngLeftColCal = llngHideStartCol Then
                    lobjcmdLeft.Enabled = False
                Else
                    lobjcmdLeft.Enabled = True
                End If
            
                '@ﾌｫｰｶｽをｾｯﾄ
                Call pubSetFocus(lobjvsfGrid)
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfCmdRight"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSideKeyDown
    '機　能：ｸﾞﾘｯﾄﾞｷｰ制御
    '引　数：lintKeyCode：ｷｰｺｰﾄﾞ
    '　　　：lstrActiveCtlNm：ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ名
    '　　　：lobjvsfGrid：ｸﾞﾘｯﾄﾞ
    '　　　：lobjcmdLeft：左ﾎﾞﾀﾝ
    '　　　：lobjcmdRight：右ﾎﾞﾀﾝ
    '戻り値：なし
    '作成日：2006/03/13 (Mon) 11:16:47 N.Kasai
    '更新日：2006/03/13 (Mon) 11:16:47
    '備　考：※FrozenColsを使用していないこと
    Public Sub prvvsfSideKeyDown(ByRef lintKeyCode As Short, _
                                  ByVal lstrActiveCtlNm As String, _
                                  ByVal lobjvsfGrid As Object, _
                                  Optional ByVal lobjcmdLeft As Object = Nothing, _
                                  Optional ByVal lobjcmdRight As Object = Nothing, _
                                  Optional ByVal lblnCmdButton As Boolean = True)
                                  
        Dim llngRow             As Integer  'ｶｳﾝﾄ
        Dim llngActiveCol       As Integer  'ﾌｫｰｶｽがあたっているCol番号
        Dim llngLeftCol         As Integer  '画面表示最左Col番号
        Dim llngLeftColCal      As Integer  '計算後の最左Col番号
        Dim llngMinCol          As Integer  '固定Col数(最小Col数)
        Dim llngMaxCol          As Integer  'Col総数
        Dim llngHideStartCol    As Integer  '表示変動開始Col番号
        Dim llngLoopCol         As Integer  'ﾙｰﾌﾟｶｳﾝﾄ用Col番号
        Dim llngloopcount       As Integer  'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngWidthAll        As Integer  'Col全体の幅
        Dim llngWidthHide       As Integer  'ｽｸﾛｰﾙで隠れるColの幅
        Dim llngWidth           As Integer  'Colの幅(計算結果)

        Try

            '@初期設定
            llngLeftCol = 0
            llngLeftColCal = 0
            llngMinCol = 0
            llngMaxCol = 0
            llngHideStartCol = 0
            llngLoopCol = 0
            llngloopcount = 0
            llngWidthAll = 0
            llngWidthHide = 0
            llngWidth = 0
            
            '@横ｽｸﾛｰﾙ発生ﾌﾗｸﾞによる処理分岐
            If mlngSideScrollFlag = CMlngSideScrollOffFlag Then
                Exit Sub
            End If

            With lobjvsfGrid
                '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ判定
                Select Case lstrActiveCtlNm
                    '@ｸﾞﾘｯﾄﾞﾌｫｰｶｽがある場合
                    Case .Name
                        '@ｷｰｺｰﾄﾞ判定
                        Select Case lintKeyCode
                           '@ｸﾞﾘｯﾄﾞｷｰ制御（[←]ｷｰﾎﾞﾀﾝ）
                            Case Keys.Left

                                '@画面表示最左Col番号取得
                                llngLeftCol = .LeftCol

                                '@ﾌｫｰｶｽがあたっているCol番号取得
                                llngActiveCol = .Col

                                '@固定Col番号取得(.FrozenCols:固定列数 -1)
                                llngMinCol = .FrozenCols - 1
                                
                                '@ｽｸﾛｰﾙで隠れるCol番号取得
                                llngHideStartCol = llngMinCol + 1

                                '@最大Col番号取得(非表示項目含まない)
                                For llngloopcount = 0 To .Cols.Count - 1
                                    '@非表示列ではない場合
                                    If .ColHidden(llngloopcount) <> True Then
                                        llngMaxCol = llngMaxCol + 1
                                    End If
                                Next llngloopcount

                                '@全列数の幅取得(非表示項目は含めない)
                                For llngloopcount = 0 To llngMaxCol - 1
                                    If .ColHidden(llngloopcount) <> True Then
                                        llngWidthAll = llngWidthAll + .Cols(llngloopcount).Width
                                    End If
                                Next llngloopcount
                                
                                '@ｽｸﾛｰﾙで隠れた列の幅を取得
                                For llngloopcount = llngHideStartCol To llngLeftCol - 1
                                    llngWidthHide = llngWidthHide + .Cols(llngloopcount).Width
                                Next llngloopcount

                                '@表示されている列の幅を取得
                                llngWidth = llngWidthAll - llngWidthHide

                                '@ｽｸﾛｰﾙ制御
                                '@ﾌｫｰｶｽｾﾙの列場所による処理分岐
                                If llngActiveCol = llngLeftCol Then
                                    '@現在の列より固定列が小さい場合
                                    If llngLeftCol > llngMinCol Then
                                        llngLeftColCal = llngLeftCol - 1
                                        '@ﾌｫｰｶｽｾﾙがﾏｲﾅｽの場合は0をｾｯﾄ
                                        If llngLeftColCal < 0 Then
                                            llngLeftColCal = 0
                                        End If
                                        '@表示列を設定
                                        .ShowCell(llngRow, llngLeftColCal)
                                    Else
                                        '@現在の列と固定列が同じ場合
                                        If llngLeftCol = llngMinCol Then
                                            llngLeftColCal = llngLeftCol
                                            '@表示列を設定
                                            .ShowCell(llngRow, llngLeftColCal)
                                        End If
                                    End If
                                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ使用の場合
                                    If lblnCmdButton = True Then
                                        '@>>、<<ﾎﾞﾀﾝを有効
                                        lobjcmdRight.Enabled = True
                                        lobjcmdLeft.Enabled = True
                                    End If
                                End If
                                
                                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ使用の場合
                                If lblnCmdButton = True Then
                                    '@ｽｸﾛｰﾙﾎﾞﾀﾝ制御
                                    '@ﾌｫｰｶｽｾﾙの列場所による処理分岐
                                    If llngActiveCol <= llngMinCol + 2 Then
                                        '@<<ﾎﾞﾀﾝを無効
                                        lobjcmdLeft.Enabled = False
                                        '@>>ﾎﾞﾀﾝを有効
                                        lobjcmdRight.Enabled = True
                                    Else
                                        '@現在の列と最大列が同じ場合
                                        If llngActiveCol = llngMaxCol Then
                                            '@<<ﾎﾞﾀﾝを有効
                                            lobjcmdLeft.Enabled = True
                                            '@>>ﾎﾞﾀﾝを無効
                                            lobjcmdRight.Enabled = False
                                        End If
                                    End If
                                End If
                                
                           '@ｸﾞﾘｯﾄﾞｷｰ制御（[→]ｷｰﾎﾞﾀﾝ）
                            Case Keys.Right
                                
                                '@画面表示最左Col番号取得
                                llngLeftCol = .LeftCol

                                '@ﾌｫｰｶｽがあたっているCol番号取得
                                llngActiveCol = .Col
                                
                                '@固定Col番号取得(.FrozenCols:固定列数 -1)
                                llngMinCol = .FrozenCols - 1
                                
                                '@最大Col番号取得(非表示項目含まない)
                                For llngloopcount = 0 To .Cols.Count - 1
                                    '@非表示列ではない場合
                                    If .ColHidden(llngloopcount) <> True Then
                                        llngMaxCol = llngMaxCol + 1
                                    End If
                                Next llngloopcount

                                '@全列数の幅取得(非表示項目は含めない)
                                For llngloopcount = 0 To llngMaxCol - 1
                                    '@非表示列ではない場合
                                    If .ColHidden(llngloopcount) <> True Then
                                        llngWidthAll = llngWidthAll + .Cols(llngloopcount).Width
                                    End If
                                Next llngloopcount
                                
                                '@ｽｸﾛｰﾙ制御用幅計算
                                '@現在の右隣列が最大列以上の場合
                                If llngActiveCol + 1 >= llngMaxCol Then
                                    llngLoopCol = llngMaxCol
                                Else
                                    llngLoopCol = llngActiveCol + 1
                                End If
                                
                                '@ｽｸﾛｰﾙ制御
                                If .Width <= llngWidthAll Then
                                    '@ﾌｫｰｶｽがあたっているｾﾙが固定列以下の場合には左右ﾎﾞﾀﾝ活性化
                                    If llngActiveCol <= llngMinCol Then
                                        llngLeftCol = .LeftCol
                                        .LeftCol = llngLeftCol
                                    Else
                                        llngLeftCol = .LeftCol
                                        llngLeftColCal = llngLeftCol + 1
                                        .LeftCol = llngLeftColCal
                                    End If
                                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ使用の場合
                                    If lblnCmdButton = True Then
                                        '@>>、<<ﾎﾞﾀﾝを有効
                                        lobjcmdRight.Enabled = True
                                        lobjcmdLeft.Enabled = True
                                    End If
                                End If
                                
                                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ使用の場合
                                If lblnCmdButton = True Then
                                
                                    '@ｽｸﾛｰﾙﾎﾞﾀﾝ制御
                                    '@現在の行と固定列が同じ場合
                                    If llngActiveCol = llngMinCol Then
                                        lobjcmdLeft.Enabled = False
                                        lobjcmdRight.Enabled = True
                                    Else
                                        '@現在の列が最大列数の左隣以上の場合
                                        If llngActiveCol >= llngMaxCol - 2 Then
                                            '@<<ﾎﾞﾀﾝを有効
                                            lobjcmdLeft.Enabled = True
                                            '@>>ﾎﾞﾀﾝを無効
                                            lobjcmdRight.Enabled = False
                                        End If
                                        '@最終行-1Colからのﾌｫｰｶｽ移動の場合
                                        If llngActiveCol = .Cols.Count - 2 Then
                                            '@最終colへﾌｫｰｶｽ移動
                                            .ShowCell(llngRow, .Cols.Count - 1)
                                            '@ﾌｫｰｶｽをｾｯﾄ
                                            Exit Sub
                                        End If
                                        '@最終colからのﾌｫｰｶｽ移動
                                        If llngActiveCol = .Cols.Count - 1 Then
                                            '@最終colへﾌｫｰｶｽ移動
                                            .ShowCell(llngRow, .Cols.Count - 1)
                                            '@ﾌｫｰｶｽをｾｯﾄ
                                            Exit Sub
                                        End If
                                    End If
                                End If
                                
                                '@ﾌｫｰｶｽをｾｯﾄ
                                Call pubSetFocus(lobjvsfGrid)
                                
                        End Select
                End Select
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSideKeyDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnMaterialStock_Disp
    '機　能：装置使用部材在庫ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/10/24 (Tue) 15:27:53 N.Kojima
    '更新日：2007/06/13 (Wed) 10:16:18 N.Kasai  №01941
    '　　　：2008/09/17 (Wed) 11:37:00 T.Oide   №03163 発注ﾎﾟｲﾝﾄ0/NULLの設定を可能とした
    '備　考：
    Private Sub prvblnMaterialStock_Disp()

        Dim lblnAns                 As Boolean              '戻り値判定用
        Dim ltypMaterialStockNum    As ChkMaterial          '装置使用部材在庫数量取得送信用構造体
        Dim lstrStockNum            As String               '部材在庫数格納用
        Dim lstrOrderNum            As String               '発注ﾎﾟｲﾝﾄ格納用
        Dim lstrDeliverDate         As String               '受入予定日格納用
        Dim lngMaterialInventory    As Integer              '未使用部材数 + 発注済数
        
        Try
                                          
            '@在庫ﾁｪｯｸ中ﾌﾗｸﾞをTrueに設定
            mblnMaterialStockChkFlag = True
                                          
            '@各種ﾗﾍﾞﾙの初期化
        '    lblMaterialInventory.Caption = vbNullString     '部材在庫数
            
            lblStockNum.Text = vbNullString              '未使用部材数
            lblOrderNum.Text = vbNullString              '発注済数
            lblOrderRemeinNum.Text = vbNullString        '発注ﾎﾟｲﾝﾄ
            lblMessage.Text = vbNullString               'ﾒｯｾｰｼﾞ
                                          
            '@装置使用部材在庫数量取得送信用構造体にﾃﾞｰﾀ格納
            With ltypMaterialStockNum
                .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strMsgVer = CMstrmat_materialstocknumVer   'MsgVer
                .strMaterialTypeID = cmbMaterialType.Text   '部材種別ID
                .strMaterialID = cmbMaterial.Text           '部材ID
            End With
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvblnMaterialStockDisp)
                                
                                
            '@装置使用部材在庫数量取得
            lblnAns = pubblnMatMaterialStockNum_Sel(ltypMaterialStockNum, _
                                                    lstrStockNum, _
                                                    lstrOrderNum, _
                                                    lstrDeliverDate)
                                                    
            
            '@結果判定
            If lblnAns = False Then
                '@取得失敗の場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvblnMaterialStockDisp)
                
                '@在庫ﾁｪｯｸ中ﾌﾗｸﾞを初期化
                mblnMaterialStockChkFlag = False
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrPrvblnMaterialStockDisp)
                            
            
            '@部材在庫数格納
            lngMaterialInventory = CLng(lstrStockNum) + CLng(lstrOrderNum)
            
            '@発注ﾎﾟｲﾝﾄ、部材在庫数、ﾒｯｾｰｼﾞのﾗﾍﾞﾙに表示
            If IsNumeric(lstrStockNum)
                lblStockNum.Text = Format$(Integer.Parse(lstrStockNum), CPstrDateFormatKanma)
            End If
            
            If IsNumeric(lstrOrderNum)
                lblOrderNum.Text = Format$(Integer.Parse(lstrOrderNum), CPstrDateFormatKanma)
            End If
                        
            '@発注ﾎﾟｲﾝﾄ｢未設定｣(NULL)の場合の対応
            If cmbMaterial.Value = vbNullString Then
                lblOrderRemeinNum.Text = CMstrMaterialOrderRemainNumNULL
            Else
                lblOrderRemeinNum.Text = Format$(CLng(cmbMaterial.Value), CPstrDateFormatKanma)
            End If
            
            lblStockNum.ForeColor = Color.Black         '黒
            lblOrderNum.ForeColor = Color.Black         '黒
            lblOrderRemeinNum.ForeColor = Color.Black   '黒
            lblMessage.ForeColor = Color.Red            '赤
            
            '@#####部材実在庫数、発注済予約在庫数、発注ﾎﾟｲﾝﾄの関係により表示ﾒｯｾｰｼﾞを変更#####
            
            '@発注ﾎﾟｲﾝﾄが「未設定」の場合
            If lblOrderRemeinNum.Text = CMstrMaterialOrderRemainNumNULL Then
                    
                    '@部材納入予定がある場合
                    If lstrDeliverDate <> vbNullString Then
                        lblMessage.Text = CMstrLackInventoryMsg2 & Format$(cdate(lstrDeliverDate), CPstrDateTimeYMD)
                    Else
                        '@納入予定なし
                        lblMessage.Text = vbNullString
                    End If
                    
            '@発注ﾎﾟｲﾝﾄが「設定」されている場合
            Else
                
                '在庫 = < 発注ﾎﾟｲﾝﾄの場合
                If lngMaterialInventory <= CLng(lblOrderRemeinNum.Text) Then
            
                    '@ﾒｯｾｰｼﾞを表示
                    lblMessage.Text = CMstrLackInventoryMsg1     'ﾒｯｾｰｼﾞ
                    lblStockNum.ForeColor = Color.Red            '赤
                    lblOrderNum.ForeColor = Color.Red            '赤
                    
                    '@ｱｸｼｮﾝﾄﾘｶﾞ(使用開始、廃棄)はﾒｯｾｰｼﾞを表示する
                    If mstrAction = CPstrZero Or mstrAction = CPstrFive Then
                        '@"0"=使用開始ﾎﾞﾀﾝ押下、"5"=廃棄ﾎﾞﾀﾝ押下の場合
                            
                        '@ﾎﾟｯﾌﾟｱｯﾌﾟﾒｯｾｰｼﾞ表示
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008V, _
                                                        cmbMaterial.Text, _
                                                        cmbMaterial.Value)
                        '@"<TRM8VW>$$使用部材[%1]の未使用の在庫が、$発注ポイント[%2]に達していません。発注処理を行ってください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ｱｸｼｮﾝﾄﾘｶﾞの初期化
                        mstrAction = vbNullString
                    End If
                    
                Else
                    '@部材在庫数 > 発注ﾎﾟｲﾝﾄの場合
                    
                    '@部材納入予定がある場合
                    If lstrDeliverDate <> vbNullString Then
                        '@部材実在庫数が発注ﾎﾟｲﾝﾄと同数か下回っている場合
                        If CLng(lstrStockNum) <= CLng(cmbMaterial.Value) Then
                            '@ﾒｯｾｰｼﾞを表示する
                            lblMessage.Text = CMstrLackInventoryMsg2 & Format$(cdate(lstrDeliverDate), CPstrDateTimeYMD)      'ﾒｯｾｰｼﾞ
                        Else
                            lblMessage.Text = vbNullString   'ﾒｯｾｰｼﾞなし
                        End If
                    Else
                        '@納入予定なし
                        lblMessage.Text = vbNullString       'ﾒｯｾｰｼﾞなし
                    End If
                End If
            End If
            
            '@在庫ﾁｪｯｸ中ﾌﾗｸﾞを初期化
            mblnMaterialStockChkFlag = False
            
            Exit Sub

        Catch ex As Exception

            

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnMaterialStock_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
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

    '関数名 list_BeforeDoubleClick
    '機　能：グリッドダブルクリック前処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/01/14 (Mon) 17:00:00 NSYS
    '備　考：
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfMaterialList.BeforeDoubleClick

        ' ObjectをGridに変換
        Dim gridObj As C1FlexGrid
        gridObj = CType(sender, C1FlexGrid)

        'ダブルクリックした箇所が列の境界線かを判断する
        If gridObj.HitTest(e.X,e.Y).Type = HitTestTypeEnum.ColumnResize Then

            '列の境界線の場合、本来の処理をキャンセル
            e.Cancel = True

           
        End If

    End Sub

End Class
