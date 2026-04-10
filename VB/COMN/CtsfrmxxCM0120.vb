'ﾌｧｲﾙ名：xxCM0120.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ロット保留/ロット保留解除　メインフォーム
'作成日：2004/03/08 (Mon) 11:25:47 M.Miura
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2018, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM0120
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM0120    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM0120
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM0120
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM0120)
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
    '====================================Private============================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2009/07/23 (Thu) 10:34:47 N.Kojima **************************************************
    '@↓2020/03/06 (Fri) 11:01:00 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion                         As String = "08.01"
    Private Const CMstrLocalVersion                         As String = "09.00"
    '@↑2020/03/06 (Fri) 11:01:00 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@機能ID-ﾌｫｰﾑ名可変の為,変数定義

    '@Msgﾊﾞｰｼﾞｮﾝ
    '@↓2020/01/15 (Wed) 14:17:55 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_curstateVer                      As String = "03.04"             'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer                      As String = "04.00"             'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 14:17:55 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrlot_holdinfoVer                      As String = "03.00"             'ﾛｯﾄ保留情報
    Private Const CMstrlot_hold____Ver                      As String = "02.01"             'ﾛｯﾄ保留設定
    Private Const CMstrlot_holdreleaseVer                   As String = "03.00"             'ﾛｯﾄ保留解除
    Private Const CMstrmas_reasoncodeVer                    As String = "02.00"             '理由ｺｰﾄﾞ取得
    Private Const CMstrmas_emplist_Ver                      As String = "02.00"             '保留責任者ﾘｽﾄ取得
    Private Const CMstrmas_roleemplistVer                   As String = "01.00"             '職制社員ﾘｽﾄ取得

    Private Const CMlngHold                                 As Integer = 0                  '保留起動
    Private Const CMlngHoldRelease                          As Integer = 1                  '保留解除
    Private Const CMlngIndex                                As Integer = 1                  'ｽﾃｰﾀｽﾊﾞｰﾒｯｾｰｼﾞｲﾝﾃﾞｯｸｽ
    Private Const CMlngFraHoldBoderStyle                    As Integer = 0                  'ﾌﾚｰﾑ実線なし
    Private Const CMlngChrMaxByteHold                       As Integer = 1500               'ｺﾒﾝﾄﾊﾞｲﾄ数制限(保留)
    Private Const CMlngChrMaxByteCancel                     As Integer = 2048               'ｺﾒﾝﾄﾊﾞｲﾄ数制限(保留解除)
    Private Const CMlngCal0                                 As Integer = 0                  'ｶﾚﾝﾀﾞｰ定数(0:工程端末)
    Private Const CMstrRestrictFlag0                        As String = "0"                 '制限ﾌﾗｸﾞ(=0)
    Private Const CMstrRestrictFlag1                        As String = "1"                 '制限ﾌﾗｸﾞ(=1)
    Private Const CMstrRestrictFlag2                        As String = "2"                 '制限ﾌﾗｸﾞ(=2)
    Private Const CMlngMaxDispRow                           As Integer = 3                  'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '@保留理由ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                          As Integer = 16                 'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                      As Integer = 16                 'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColHoldName                   As Integer = 0                  '保留理由列番
    Private Const CMlngCmbGridColHoldID                     As Integer = 1                  '保留理由ID列番(非表示項目)
    Private Const CMlngCmbSortAsc                           As Integer = 1                  '昇順(ｿｰﾄ)
    Private Const CMlngCmbDispCols                          As Integer = 1                  'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbRowHeight                         As Integer = 43                 'ﾘｽﾄ行の高さ
    Private Const CMlngCmbFirstListIndex                    As Integer = 0                  '1件目のﾃﾞｰﾀ表示用

    '@表示ﾒｯｾｰｼﾞ
    Private Const CMstrHold                                 As String = "保留責任者"
    Private Const CMstrLotManager                           As String = "ロット担当者"
    Private Const CMstrEmp                                  As String = "作業者"

    '@ﾌｫｰﾏｯﾄ定数宣言
    Private Const CMlngFormatStart                          As Integer = 1                  'Mid取得先頭数(=1)
    Private Const CMlngFormatMid9                           As Integer = 9                  'Mid取得=9文字

    '@有効ｺﾝﾄﾛｰﾙ名
    Private Const CMstrActiveControlNameCarrierID           As String = "txtCarrierID"      'ｷｬﾘｱIDのｺﾝﾄﾛｰﾙ名
    Private Const CMstrActiveControlNameLotID               As String = "txtLotID"          'ﾛｯﾄIDのｺﾝﾄﾛｰﾙ名

    '@ﾚｽﾎﾟﾝｽ測定用
    Private Const CMstrFormName                             As String = "frmxxCM0120"               '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                             As String = "Form_Load"                 'ｲﾍﾞﾝﾄ名称(ﾌｫｰﾑﾛｰﾄﾞ)
    Private Const CMstrTxtCarrierIdValidate                 As String = "txtCarrierID_Validate"     'ｲﾍﾞﾝﾄ名称(ｷｬﾘｱID_Validate処理)
    Private Const CMstrTxtLotIdValidate                     As String = "txtLotID_Validate"         'ｲﾍﾞﾝﾄ名称(ﾛｯﾄID_Validate処理)
    Private Const CMstrCmdRegistClick                       As String = "cmdRegist_Click"           'ｲﾍﾞﾝﾄ名称(確定押下処理)

    '@vsfLotHoldListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfLotHoldListColNo                  As Integer = 0                  '№
    Private Const CMlngvsfLotHoldListColHoldSDate           As Integer = 1                  '保留開始日
    Private Const CMlngvsfLotHoldListColEntryTime           As Integer = 2                  '保留日(詳細表記用)
    Private Const CMlngvsfLotHoldListColHoldEDate           As Integer = 3                  '保留期限
    Private Const CMlngvsfLotHoldListColHoldEDateL          As Integer = 4                  '保留期限(西暦表示)
    Private Const CMlngvsfLotHoldListColHoldTerm            As Integer = 5                  '保留期間
    Private Const CMlngvsfLotHoldListColHoldReasonID        As Integer = 6                  '保留理由ID
    Private Const CMlngvsfLotHoldListColHoldReason          As Integer = 7                  '保留理由
    Private Const CMlngvsfLotHoldListColHoldEmpID           As Integer = 8                  '保留責任者ID
    Private Const CMlngvsfLotHoldListColHoldEmpName         As Integer = 9                  '保留責任者名
    Private Const CMlngvsfLotHoldListColHoldComments        As Integer = 10                 '保留ｺﾒﾝﾄ内容
    Private Const CMlngvsfLotHoldListColRestrictFlag        As Integer = 11                 '制限ﾌﾗｸﾞ

    '@vsfLotHoldListの定数宣言(表示幅)
    Private Const CMlngvsfLotHoldListColWNo                 As Integer = 47                 '№
    Private Const CMlngvsfLotHoldListColWHoldSDate          As Integer = 187                '保留開始日
    Private Const CMlngvsfLotHoldListColWEntryTime          As Integer = 187                '保留日(詳細表記用)
    Private Const CMlngvsfLotHoldListColWHoldEDate          As Integer = 187                '保留期限
    Private Const CMlngvsfLotHoldListColWHoldEDateL         As Integer = 187                '保留期限(西暦表示)
    Private Const CMlngvsfLotHoldListColWHoldTerm           As Integer = 187                '保留期間
    Private Const CMlngvsfLotHoldListColWHoldReasonID       As Integer = 140                '保留理由ID
    Private Const CMlngvsfLotHoldListColWHoldReason         As Integer = 140                '保留理由
    Private Const CMlngvsfLotHoldListColWHoldEmpID          As Integer = 133                '保留責任者ID
    Private Const CMlngvsfLotHoldListColWHoldEmpName        As Integer = 140                '保留責任者名
    Private Const CMlngvsfLotHoldListColWHoldComments       As Integer = 140                '保留ｺﾒﾝﾄ内容
    Private Const CMlngvsfLotHoldListColWRestrictFlag       As Integer = 140                '制限ﾌﾗｸﾞ

    '@vsfLotHoldListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfLotHoldListColNo                  As String = "№"                '№
    Private Const CMstrvsfLotHoldListColHoldSDate           As String = "保留開始日"        '保留開始日
    Private Const CMstrvsfLotHoldListColEntryTime           As String = "EntryTime"         '保留日(詳細表記用)
    Private Const CMstrvsfLotHoldListColHoldEDate           As String = "保留期限"          '保留期限
    Private Const CMstrvsfLotHoldListColHoldEDateL          As String = "期限西暦"          '保留期限(西暦表示)
    Private Const CMstrvsfLotHoldListColHoldTerm            As String = "保留期間"          '保留期間
    Private Const CMstrvsfLotHoldListColHoldReasonID        As String = "保留理由ID"        '保留理由ID
    Private Const CMstrvsfLotHoldListColHoldReason          As String = "保留理由"          '保留理由
    Private Const CMstrvsfLotHoldListColHoldEmpID           As String = "保留責任者ID"      '保留責任者ID
    Private Const CMstrvsfLotHoldListColHoldEmpName         As String = "保留責任者"        '保留責任者名
    Private Const CMstrvsfLotHoldListColHoldComments        As String = "保留内容"          '保留ｺﾒﾝﾄ内容
    Private Const CMstrvsfLotHoldListColRestrictFlag        As String = "制限フラグ"        '制限ﾌﾗｸﾞ

    '@vsfLotHoldListのその他定数宣言
    Private Const CMlngvsfLotHoldListRowTitle               As Integer = 0
    Private Const CMlngvsfLotHoldListColTitle               As Integer = 0
    Private Const CMlngvsfLotHoldListHHeight                As Integer = 21
    Private Const CMlngvsfLotHoldListHeight                 As Integer = 43
    Private Const CMlngvsfLotHoldListHFontSize              As Integer = 12
    Private Const CMlngvsfLotHoldListFontSize               As Integer = 16

    '@画面ﾀｲﾄﾙ表示定数宣言
    Private Const CMstrHoldLabelTitle                       As String = "      保留コメント"
    Private Const CMstrHoldReleaseLabelTitle                As String = "      保留解除コメント"
    Private Const CMstrHoldFrameTitle                       As String = "保留設定"
    Private Const CMstrHoldReleaseFrameTitle                As String = "保留解除設定"
    Private ReadOnly vbButtonFace                           As Color = SystemColors.ControlLight 'NSYS ボタンの背景色
    Private ReadOnly vbWindowBackground                     As Color = SystemColors.Window       'NSYS Windowsの背景色
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    Private mstrLocalMenuKey                                As String                       'ﾛｰｶﾙ機能ID格納領域
    Private mstrClassDivision                               As String                       '処理区分(14：保留設定、15：保留解除)
    Private mstrLotLastUpdate                               As String                       'ﾛｯﾄ最終更新日時
    Private mstrCarrier                                     As String                       'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mstrLot                                         As String                       'ﾛｯﾄ情報取得時のﾛｯﾄID(ﾒｯｾｰｼﾞ成功取得時)
    Private mstrEmpID                                       As String                       '退避用受入担当者名
    Private mtypMasItemList                                 As MasItemList                  '保留理由構造体
    Private mblnTakeOverDispFlg                             As Boolean                      '引継ぎﾌﾗｸﾞ表示ﾌﾗｸﾞ
    Private mstrActiveControlName                           As String                       '有効ｺﾝﾄﾛｰﾙ(ｷｬﾘｱID or ﾛｯﾄID)
    Private mstrSelectControlName                           As String                       '抽出Keyｺﾝﾄﾛｰﾙ(ｷｬﾘｱID or ﾛｯﾄID)
    Private mtypEmpList                                     As List(Of TechManList)         '保留責任者格納用構造体
    Private mlngEmpListCnt                                  As Integer                      '保留責任者ﾃﾞｰﾀ数格納用
    Private mstrLotManagerID                                As String                       'ﾛｯﾄ担当者ID格納領域
    Private mstrHoldEmpID                                   As String                       '保留責任者ID退避領域

    Private buttonProcessing                                As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                        As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                                 As Boolean                      'NSYS WindowCloseフラグ

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
        pubVsfMouseWheelManager_Set(vsfLotHoldList, cmdVsfUP, cmdVsfDown)

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
    '作成日：2004/03/08 (Mon) 11:43:34 M.Miura
    '更新日：2008/06/10 (Tue) 14:19:40 N.Kojima
    '備　考：
    '　　　：2005/02/14 (Mon) 15:54:44 N.Kojima     有効ｺﾝﾄﾛｰﾙの初期化処理等追加(改善№511)
    '　　　：2005/03/29 (Mon) 08:34:19 S.Deguchi    保留と保留解除で処理分岐(保留解除の時には,REASON_CODEは取得しない)
    '　　　：2005/11/17 (Thu) 13:15:34 S.Deguchi    保留責任者ﾘｽﾄ取得処理追加
    '　　　：2008/06/10 (Tue) 14:19:40 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub Form_Load()
        
        Dim lblnAns                 As Boolean      'ﾛｯﾄ保留理由取得戻り値(True/False)

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@★ 起動区分により処理分岐 ★
            Select Case plngfrmxxCM0120Kbn
            
                '@〓 0：ﾛｯﾄ保留 〓
                Case CMlngHold
                    
                    mstrLocalMenuKey = CPstrKeyEN0050   'ﾒﾆｭｰｷｰ：EN0050(ﾛｯﾄ保留)
                    mstrClassDivision = CPstrCD14       '処理区分：14(ﾛｯﾄ保留)
                    
                '@〓 1：ﾛｯﾄ保留解除 〓
                Case CMlngHoldRelease

                    mstrLocalMenuKey = CPstrKeyEN00A0   'ﾒﾆｭｰｷｰ：EN00A0(ﾛｯﾄ保留解除)
                    mstrClassDivision = CPstrCD15       '処理区分：15(ﾛｯﾄ保留解除)

            End Select
            
            '@=======================
            '@　機能ﾊﾞｰｼﾞｮﾝの判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(mstrLocalMenuKey, CMstrLocalVersion)
            
            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                
                '@Escﾎﾞﾀﾝを有効にする
                Me.CancelButton = cmdClose
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrFormLoad)
            
            '@有効ｺﾝﾄﾛｰﾙ名退避領域をｸﾘｱする
            mstrActiveControlName = vbNullString
            
            '@=======================
            '@　画面情報、変数、ｺﾝﾄﾛｰﾙの初期化処理
            '@=======================
            Call prvfrmxxCM0120_Init()
            
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            '@起動区分が"0：ﾛｯﾄ保留"か
            If plngfrmxxCM0120Kbn = CMlngHold Then
                '@0：ﾛｯﾄ保留の場合
            
                '@【理由ｺｰﾄﾞ取得】ﾒｯｾｰｼﾞ送受信処理      ※処理区分：2U(保留)
                lblnAns = pubblnMasResonCode_Sel(CMstrmas_reasoncodeVer, _
                                                 CPstrCD2U, _
                                                 mtypMasItemList)

                '@理由ｺｰﾄﾞ取得結果判定
                If lblnAns = False Then
                    '@理由ｺｰﾄﾞ取得結果：異常の場合
                    
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = cmdClose
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                    Exit Sub
                End If
            
                '@【保留責任者取得(作業者ﾘｽﾄ取得)】ﾒｯｾｰｼﾞ送受信処理
                lblnAns = pubblnMasEmplist_Sel(CMstrmas_emplist_Ver, _
                                               mtypEmpList, _
                                               mlngEmpListCnt)

                '@保留責任者取得結果判定
                If lblnAns = False Then
                    '@保留責任者取得結果：異常の場合
                    
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = cmdClose
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                    Exit Sub
                End If
            End If
            
            '@Form_Loadﾌﾗｸﾞに"True：起動処理正常"をｾｯﾄ
            pblnFormLoad = True

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrFormLoad)
            
            '@引継ぎ情報表示済みﾌﾗｸﾞにFalseを設定する
            mblnTakeOverDispFlg = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
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
    '作成日：2004/07/27 (Tue) 14:02:25 H.Wajima
    '更新日：2008/06/10 (Tue) 14:32:28 N.Kojima
    '備　考：
    '　　　：2008/06/10 (Tue) 14:32:28 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@*************************************
            '@　FormLoad後、最初の1回しか処理しない
            '@*************************************
            
            '@引継ぎ情報表示済みﾌﾗｸﾞが"True：表示済"か
            If mblnTakeOverDispFlg = True Then
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose
            
            '@引継ぎ情報表示済みﾌﾗｸﾞに"True：表示済"を設定する
            mblnTakeOverDispFlg = True
                
            '@引継ぎｷｬﾘｱIDがNULL以外か
            If ptypCommonInfo.strCarrierId <> vbNullString Then

                '@ｷｬﾘｱIDに引継ぎｷｬﾘｱIDを設定する
                txtCarrierID.Text = ptypCommonInfo.strCarrierId
                
                '@=======================
                '@　ｷｬﾘｱIDﾃｷｽﾄのValidate処理
                '@=======================
                Call txtCarrierID_Validate(False, New CancelEventArgs)
            Else

                '@ｷｬﾘｱIDを初期化する
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
                .strMenuKey = mstrLocalMenuKey
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
    '　　　：Shift  ：ｼﾌﾄ
    '戻り値：なし
    '作成日：2004/03/09 (Tue) 16:35:41 M.Miura
    '更新日：2008/06/10 (Tue) 14:35:48 N.Kojima
    '備　考：
    '　　　：2005/02/14 (Mon) 16:07:27 N.Kojima     ﾛｯﾄID入力時のKeyDownEvent追加(改善№511)
    '　　　：2008/06/10 (Tue) 14:35:48 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            
            '@以下の条件の場合はｷｰｺｰﾄﾞを無効にして、処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If
            
            '@=======================
            '@　ｸﾞﾘｯﾄﾞ用上下ｽｸﾛｰﾙﾎﾞﾀﾝ制御(共通処理)
            '@=======================
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfLotHoldList, cmdVsfUP, cmdVsfDown)
            
            '@★ ｷｰｺｰﾄﾞにより処理分岐 ★
            Select Case e.KeyCode
            
                '@〓 Enterｷｰ 〓
                Case Keys.Return
                
                    '@★★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★★
                    Select Case ActiveControl.Name
                    
                        '@〓〓 保留/保留解除ｺﾒﾝﾄ 〓〓
                        Case txtHoldComment.Name
                        
                            '@保留/保留解除ｺﾒﾝﾄは改行がある為、Enterでﾌｫｰｶｽ移動しない
                            Exit Sub
                        
                        '@〓〓 ｷｬﾘｱID 〓〓
                        Case txtCarrierID.Name
                            
                            '@=======================
                            '@　ｷｬﾘｱIDﾃｷｽﾄのValidate処理
                            '@=======================
                            Call txtCarrierID_Validate(False, New CancelEventArgs)
                            Exit Sub
                            
                        '@〓〓 ﾛｯﾄID 〓〓
                        Case txtLotID.Name
                        
                            '@=======================
                            '@　ﾛｯﾄIDﾃｷｽﾄのValidate処理
                            '@=======================
                            Call txtLotID_Validate(False, New CancelEventArgs)
                            Exit Sub
                    End Select
                    
                    '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
                    SendKeys.SendWait(CPstrSendKeysTab)
                    e.Handled = True
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "Form_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑ　終了時処理
    '引　数：Cancel     ：未使用
    '　　　：UnloadMode ：未使用
    '戻り値：
    '作成日：2004/04/13 (Tue) 16:39:17 N.Kasai
    '更新日：2008/06/10 (Tue) 14:44:59 N.Kojima
    '備　考：
    '　　　：2004/11/01 (Mon) 15:37:26 N.Kasai      閉じるﾎﾞﾀﾝ統合
    '　　　：2008/06/10 (Tue) 14:44:59 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm             As Boolean              '開放結果格納
        Dim ltypDepartmentList      As DepartmentInfo       '部署/所属格納構造体
        Dim ltypDeptEmpList         As DeptEmpInfo          'ﾕｰｻﾞ格納構造体
        Dim ltypSendMailList        As SendMailList         '宛先人格納構造体
        Dim ltypMailInfo            As MailInfo             'ﾒｰﾙ送信画面引継ぎ構造体

        Try
            
            '@ﾓｼﾞｭｰﾙ変数の解放
            If Not mtypMasItemList.typeMasItem Is Nothing Then  '理由ｺｰﾄﾞ格納用構造体
                mtypMasItemList.typeMasItem.Clear()
            End If
            If Not mtypEmpList Is Nothing Then                  '保留責任者格納構造体
                mtypEmpList.Clear()
            End If
            
            '@ﾒｰﾙ関連一式の構造体をｸﾘｱする。
            ptypDepartmentList = ltypDepartmentList
            ptypDeptEmpList = ltypDeptEmpList
            ptypSendMailList = ltypSendMailList
            ptypMailInfo = ltypMailInfo

            If Not ptypDepartmentList.typDepartmentList Is Nothing Then
                ptypDepartmentList.typDepartmentList.Clear()
            End If
            If Not ptypDeptEmpList.typDeptEmpList Is Nothing Then
                ptypDeptEmpList.typDeptEmpList.Clear()
            End If
            If Not ptypSendMailList.typSendMail Is Nothing Then
                ptypSendMailList.typSendMail.Clear()
            End If
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender, e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
            pblnFormLoad = False
            
            '@Act初期化ﾌﾗｸﾞが"True:初期化済"か
            If pblnActInitFlg = True Then
                '@Actを自前で初期化した場合
                
                '@=======================
                '@　ACTｵﾌﾞｼﾞｪｸﾄの開放処理
                '@=======================
                lblnAnsTerm = pubblnAct_Term
                
                '@処理結果判定
                If lblnAnsTerm = True Then
                    '@結果：正常の場合、ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
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

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
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
    '作成日：2004/03/08 (Mon) 14:43:09 M.Miura
    '更新日：2018/11/16 (Fri) 09:49:36 Y.Yoneyama
    '備　考：2005/03/07 (Mon) 09:24:12 N.Kojima     戻り先画面の判定を追加(改善№512)
    '      ：2018/11/16 (Fri) 09:49:36 Y.Yoneyama   防湿ALD対応
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        
        Dim ltypCommonInfoDummy     As CommonInfo   'ﾀﾞﾐｰ構造体

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@引継ぎ情報のキャリアIDが空白かどうか判定する
            If ptypCommonInfo.strCarrierId <> vbNullString Then
            '@空白でない場合
                '@装置別ﾛｯﾄ一覧から引き継いで起動された場合
                If pblnfrmxxEN0150Kbn = True Then
                    '@装置別ﾛｯﾄ一覧を起動する
                    Call pubMenuSelect_Proc(CPstrKeyEN0150)
        '@↓2018/11/16 (Fri) 09:47:55 Y.Yoneyama **************************************************
                '@装置別ﾛｯﾄ(防湿ALD)一覧から引き継いで起動された場合
                ElseIf pblnfrmxxEN0151Kbn = True Then
                    '@装置別ﾛｯﾄ(防湿ALD)一覧を起動する
                    Call pubMenuSelect_Proc(CPstrKeyEN0151)
        '@↑2018/11/16 (Fri) 09:47:55 Y.Yoneyama **************************************************
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
                '@同一ﾌｫｰﾑを複数機能として利用するため、ｽﾍﾟｼｬﾙ対応
                Select Case plngfrmxxCM0120Kbn
                    Case CMlngHold
                    '@保留起動
                        '@終了関数を実行する
                        Call publngEnd_Proc(CPstrKeyEN0050, ltypCommonInfoDummy)
                        
                    Case CMlngHoldRelease
                    '@保留解除起動
                        '@終了関数を実行する
                        Call publngEnd_Proc(CPstrKeyEN00A0, ltypCommonInfoDummy)
                End Select
            End If
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "cmdClose_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：確定
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/10 (Wed) 18:40:45 M.Miura
    '更新日：2006/11/29 (Wed) 17:09:13 T.Kitagawa
    '備　考：2005/02/14 (Mon) 17:18:03 N.Kojima     ﾚｽﾎﾟﾝｽ取得・終了・ｷｬﾝｾﾙ処理の引数を修正(改善№511)
    '　　　：2005/03/31 (Thu) 14:10:06 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2005/04/18 (Mon) 09:56:03 S.Deguchi    不具合№688対応で起動区分処理対応を修正
    '　　　：2005/08/17 (Wed) 16:27:12 S.Deguchi    実行権限ﾁｪｯｸを追加
    '　　　：2005/11/22 (Tue) 08:57:44 S.Deguchi    処理が煩雑になってきた為,保留処理,保留解除処理を分割,Subﾙｰﾁﾝ化して整理
    '　　　：2006/11/29 (Wed) 17:09:13 T.Kitagawa　 ﾊﾟｽﾜｰﾄﾞ確認機能追加(案件№01581)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean              '登録戻り値(True/False)
        
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

            '@画面項目ﾁｪｯｸ
            lblnAns = prvblnInput_Chk
            If lblnAns = False Then
                '@不正項目あり
                Exit Sub
            End If
            
            '@保留/保留解除で処理分岐
            If plngfrmxxCM0120Kbn = CMlngHold Then
            '@保留設定する場合
        '@↓2005/11/22 (Tue) 09:56:05 S.Deguchi **************************************************
                
                '@ﾒｰﾙ引継情報格納処理
                lblnAns = prvblnMailConnectInfo_Set
                '@結果判定
                If lblnAns = False Then
                '@失敗の場合
                    
                    Exit Sub
                End If

                '@引継起動ﾌﾗｸﾞの設定
                pblnfrmxxEN0050kbn = True                                   '保留画面からﾒｰﾙ送信画面を起動
                pblnfrmxxEN00V0kbn = False

                '@引継処理ﾌﾗｸﾞの初期化
                plngfrmxxCM00S0Kbn = 0

                '@起動ﾌﾗｸﾞの初期化
                pblnFormLoad = False

                '@ﾒｰﾙ送信画面起動
                frmxxCM00S0.Instance = New frmxxCM00S0()

                '@起動ﾌﾗｸﾞから表示判別
                If pblnFormLoad = True Then
                '@成功の場合
                    frmxxCM00S0.Instance.ShowDialog(Me)
                    frmxxCM00S0.Instance = Nothing
                Else
                '@失敗の場合
                    '@ｱﾝﾛｰﾄﾞ処理
                    frmxxCM00S0.Instance = Nothing

                    '@引継起動ﾌﾗｸﾞの初期化
                    pblnfrmxxEN0050kbn = False
                    pblnfrmxxEN00V0kbn = False

                    '@引継処理ﾌﾗｸﾞの初期化
                    plngfrmxxCM00S0Kbn = 0

                    '@起動ﾌﾗｸﾞを戻す
                    pblnFormLoad = True

                    Exit Sub
                End If

                '@引継処理ﾌﾗｸﾞから処理分岐
                Select Case plngfrmxxCM00S0Kbn
                    Case 2
                    '@起動成功＆ﾒｰﾙ送信
                        '@保留確定処理実行
                        lblnAns = prvblnLotHold_Proc
                        '@結果判定
                        If lblnAns = True Then
                        '@成功の場合
                            '@画面初期化
                            Call prvfrmxxCM0120_Init()
                        End If

                    Case Else
                    '@起動失敗,起動成功＆閉じる,他
                End Select
            
                '@引継起動ﾌﾗｸﾞの初期化
                pblnfrmxxEN0050kbn = False
                pblnfrmxxEN00V0kbn = False
            
                '@引継処理ﾌﾗｸﾞの初期化
                plngfrmxxCM00S0Kbn = 0
            
                '@起動ﾌﾗｸﾞを戻す
                pblnFormLoad = True
            Else
            '@保留解除する場合
        '@↓2006/11/29 (Wed) 17:08:01 T.Kitagawa **************************************************
        '        '@作業者ｺｰﾄﾞ入力
        '        frmxxCM0010.Show (vbModal)
                '@作業者ｺｰﾄﾞ入力
                With vsfLotHoldList
                    '@保留理由により，実行権限のﾁｪｯｸを行う(リワーク)
                    If .GetData(.Row, CMlngvsfLotHoldListColHoldReasonID) = CPstrReworkReasonCode Then
                        '@作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力
                        frmxxCM0020.Instance.ShowDialog(Me)
                        frmxxCM0020.Instance = Nothing
                    Else
                        '@作業者ｺｰﾄﾞ入力
                        frmxxCM0010.Instance.ShowDialog(Me)
                        frmxxCM0010.Instance = Nothing
                    End If
                End With
        '@↑2006/11/29 (Wed) 17:08:01 T.Kitagawa **************************************************
            
                '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
                If pstrUserID = vbNullString Then
                    '@未入力の場合、投入中止
                    Exit Sub
                End If
                
                '@保留解除確定処理
                lblnAns = prvblnLotHoldCancel_Proc
                '@結果判定
                If lblnAns = True Then
                '@成功の場合
                    '@画面初期化
                    Call prvfrmxxCM0120_Init()
                Else
                '@失敗の場合
                    '@処理なし
                End If

            End If
        '@↑2005/11/22 (Tue) 09:56:05 S.Deguchi **************************************************
            
            '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrierID)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "cmdRegist_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierID_Change
    '機　能：ｷｬﾘｱ変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/10 (Wed) 18:40:13 M.Miura
    '更新日：2005/02/22 (Tue) 13:43:34 N.Kojima
    '備　考：2005/02/22 (Tue) 13:43:34 N.Kojima　抽出ｺﾝﾄﾛｰﾙがｷｬﾘｱIDではない場合は初期化しない(改善№511)
    Private Sub txtCarrierID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrierID.Change

        Try

            '@有効ｺﾝﾄﾛｰﾙの判定
            If mstrActiveControlName <> CMstrActiveControlNameCarrierID Then
                Exit Sub
            End If

            '@画面初期化
            Call prvfrmxxCM0120_Init(False)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "txtCarrierID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierID_GotFocus
    '機　能：ｷｬﾘｱIDのﾌｫｰｶｽ取得
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/14 (Mon) 16:27:32 N.Kojima
    '更新日：2005/02/14 (Mon) 16:27:32
    '備　考：
    Private Sub txtCarrierID_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrierID.Enter

        Try

            '@有効ｺﾝﾄﾛｰﾙ名の設定
            mstrActiveControlName = CMstrActiveControlNameCarrierID

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "txtCarrierID_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierID_Validate
    '機　能：ｷｬﾘｱIDのLOST
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/03/08 (Mon) 14:47:30 M.Miura
    '更新日：2005/02/14 (Mon) 16:18:59 N.Kojima
    '備　考：2004/09/15 (Wed) 09:23:19 S.Deguchi    保留責任者名称を保留情報と一緒に取得する方法に変更
    '　　　：2005/02/14 (Mon) 16:18:59 N.Kojima　   有効ｺﾝﾄﾛｰﾙの退避処理等追加(改善№511)
    '　　　：2005/03/15 (Tue) 17:40:34 S.Deguchi    不具合№592の対応で状態ﾁｪｯｸをｺﾒﾝﾄｱｳﾄ
    '　　　：2005/04/18 (Mon) 09:56:03 S.Deguchi    不具合№688対応で処理見直し(常にlot_.holdinfoを取得するように修正)
    Private Sub txtCarrierID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrierID.Validating
        
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypLotCurState         As Lotprestate          'ﾛｯﾄ現在状態格納構造体
        Dim ltypLotHoldInfoList     As LotHoldInfoList      'ﾛｯﾄ情報格納構造体

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの空白ﾁｪｯｸ
            If Trim(txtCarrierID.Text) = vbNullString Then
                '@有効ｺﾝﾄﾛｰﾙ名のｸﾘｱ
                mstrActiveControlName = vbNullString
                
                '@ﾌｫｰｶｽ移動
                If txtLotID.Enabled = True Then
                    '@ﾛｯﾄID欄へ
                    Call pubSetFocus(txtLotID)
                Else
                    '@閉じるﾎﾞﾀﾝへ
                    Call pubSetFocus(cmdClose)
                End If
                
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtCarrierID.NowByte < txtCarrierID.ChrMaxByte Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                e.Cancel = True
                Exit Sub
            End If
            
            '@ｷｬﾘｱID情報の取得(入力ｷｬﾘｱIDと前回のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功)と違う場合のみ実行)
            If txtCarrierID.Text <> mstrCarrier Then
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrTxtCarrierIdValidate)
                
                '@ﾛｯﾄ情報の取得
                lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                                mstrClassDivision, _
                                                txtCarrierID.Text, _
                                                ltypLotCurState, _
                                                vbNullString)
                '@結果判定
                If lblnAns = True Then
                    '@抽出ｺﾝﾄﾛｰﾙ名設定(ｷｬﾘｱID)
                    mstrSelectControlName = CMstrActiveControlNameCarrierID
                    
                    '@ﾛｯﾄIDｾｯﾄ
                    txtLotID.Text = ltypLotCurState.strLotID
                    
                    '@ｷｬﾘｱID、ﾛｯﾄIDの退避
                    mstrCarrier = txtCarrierID.Text
                    mstrLot = txtLotID.Text
                    
                    '@保留情報の設定
                    Call prvLotHoldinfo_Disp()
                    
                    '@ﾛｯﾄ保留情報の取得
                    lblnAns = pubblnLotHoldinfo_Sel(CMstrlot_holdinfoVer, txtLotID.Text, ltypLotHoldInfoList)
                    '@結果判定
                    If lblnAns = True Then
                        '@画面表示処理
                        Call prvfrmxxCM0120_Disp(ltypLotCurState)
                        
                        '@保留ﾘｽﾄ設定
                        Call prvvsfLotHoldList_Disp(ltypLotHoldInfoList)
                    Else
                        '@画面初期化
                        Call prvfrmxxCM0120_Init(False)
                        
                        '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                        e.Cancel = True
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierIdValidate)
                        
                        Exit Sub
                    End If
                    
                    '@ｷｬﾘｱID退避(ﾒｯｾｰｼﾞ成功時)
                    mstrCarrier = txtCarrierID.Text
                    
                Else
                    '@画面初期化
                    Call prvfrmxxCM0120_Init(False)
                    
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierIdValidate)
                    
                    Exit Sub
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrTxtCarrierIdValidate)
            End If
            
            '@ﾌｫｰｶｽの制御
            If ActiveControl.Name = txtCarrierID.Name Then
                If cmbMasHold.Enabled = True Then
                    '@保留理由にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbMasHold)
                Else
                    '@ｸﾞﾘｯﾄﾞが使用可能か
                    If vsfLotHoldList.Enabled = True Then
                        '@一覧にﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfLotHoldList)
                    Else
                        '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If

            '@有効ｺﾝﾄﾛｰﾙ名のｸﾘｱ
            mstrActiveControlName = vbNullString
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "txtCarrierID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotID_Change
    '機　能：ﾛｯﾄIDChange処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/14 (Mon) 15:19:57 N.Kojima
    '更新日：2005/02/14 (Mon) 15:19:57
    '備　考：
    Private Sub txtLotID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLotID.Change

        Try

            '@有効ｺﾝﾄﾛｰﾙの判定
            If mstrActiveControlName <> CMstrActiveControlNameLotID Then
                Exit Sub
            End If
            
            '@初期化
            Call prvfrmxxCM0120_Init(False)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "txtLotID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotID_GotFocus
    '機　能：ﾛｯﾄIDGotFocus処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/14 (Mon) 15:20:13 N.Kojima
    '更新日：2005/02/14 (Mon) 15:20:13
    '備　考：
    Private Sub txtLotID_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtLotID.Enter

        Try

            '@有効ｺﾝﾄﾛｰﾙ名の設定
            mstrActiveControlName = CMstrActiveControlNameLotID

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "txtLotID_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotID_Validate
    '機　能：ﾛｯﾄIDValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/02/14 (Mon) 15:20:26 N.Kojima
    '更新日：2005/02/14 (Mon) 15:20:26
    '備　考：
    '　　　：2005/03/15 (Tue) 17:40:34 S.Deguchi    不具合№592の対応で状態ﾁｪｯｸをｺﾒﾝﾄｱｳﾄ
    '　　　：2005/04/18 (Mon) 09:56:03 S.Deguchi    不具合№688対応で処理見直し(常にlot_.holdinfoを取得するように修正)
    Private Sub txtLotID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtLotID.Validating

        Dim lblnAns                 As Boolean          '結果取得(True:正常,False:異常)
        Dim ltypLotCurState         As Lotprestate      'ﾛｯﾄ現在状態格納構造体
        Dim ltypLotHoldInfoList     As LotHoldInfoList  'ﾛｯﾄ情報格納構造体

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ﾛｯﾄIDの空白ﾁｪｯｸ
            If txtLotID.Text = vbNullString Then
                '@有効ｺﾝﾄﾛｰﾙ名のｸﾘｱ
                mstrActiveControlName = vbNullString
                
                If ActiveControl.Name = txtLotID.Name Then
                    '@ﾌｫｰｶｽ移動
                    If cmdRegist.Enabled = False Then
                        '@閉じるﾎﾞﾀﾝﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    Else
                        '@保留理由が有効な場合
                        If cmbMasHold.Enabled = True Then
                            '@保留理由にﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmbMasHold)
                        Else
                            '@閉じるﾎﾞﾀﾝﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdClose)
                        End If
                    End If
                End If
                Exit Sub
            End If
            
            '@ﾛｯﾄIDの桁ﾁｪｯｸ
            If txtLotID.NowByte < txtLotID.ChrMaxByte Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0012)
                '@"ロットIDは10桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                e.Cancel = True
                Exit Sub
            End If
            
            '@ﾛｯﾄID情報の取得(入力ﾛｯﾄIDと前回のﾛｯﾄID(ﾒｯｾｰｼﾞ成功)と違う場合のみ実行)
            If txtLotID.Text <> mstrLot Then
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrTxtLotIdValidate)
                
                '@ﾛｯﾄ情報の取得
                lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                                mstrClassDivision, _
                                                vbNullString, _
                                                ltypLotCurState, _
                                                txtLotID.Text)
                '@結果判定
                If lblnAns = True Then
                    
                    '@抽出ｺﾝﾄﾛｰﾙ名設定(ﾛｯﾄID)
                    mstrSelectControlName = CMstrActiveControlNameLotID
                    
                    '@ｷｬﾘｱIDを格納
                    txtCarrierID.Text = ltypLotCurState.strCarrierId
                    
                    
                    '@ｷｬﾘｱID、ﾛｯﾄIDの退避
                    mstrCarrier = txtCarrierID.Text
                    mstrLot = txtLotID.Text
                    
                    '@保留情報の設定
                    Call prvLotHoldinfo_Disp()
                    
                    '@ﾛｯﾄ保留情報の取得
                    lblnAns = pubblnLotHoldinfo_Sel(CMstrlot_holdinfoVer, txtLotID.Text, ltypLotHoldInfoList)
                    '@結果判定
                    If lblnAns = True Then
                        '@画面表示処理
                        Call prvfrmxxCM0120_Disp(ltypLotCurState)
                        
                        '@保留ﾘｽﾄ設定
                        Call prvvsfLotHoldList_Disp(ltypLotHoldInfoList)
                    Else
                        '@画面初期化
                        Call prvfrmxxCM0120_Init(False)
                        
                        '@ﾛｯﾄIDへﾌｫｰｶｽｾｯﾄ
                        e.Cancel = True
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrTxtLotIdValidate)
                        
                        Exit Sub
                    End If
                    
                    '@ﾛｯﾄID退避(ﾒｯｾｰｼﾞ成功時)
                    mstrLot = txtLotID.Text
                    
                Else
                    '@画面初期化
                    Call prvfrmxxCM0120_Init(False)
                    
                    '@ﾛｯﾄIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrTxtLotIdValidate)
                    
                    Exit Sub
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrTxtLotIdValidate)
            End If
            
            '@ﾌｫｰｶｽの制御
            If ActiveControl.Name = txtLotID.Name Then
                If cmbMasHold.Enabled = True Then
                    '@保留理由にﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmbMasHold)
                Else
                    '@ｸﾞﾘｯﾄﾞが使用可能か
                    If vsfLotHoldList.Enabled = True Then
                        '@一覧にﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfLotHoldList)
                    Else
                        '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If
            
            
            '@有効ｺﾝﾄﾛｰﾙ名のｸﾘｱ
            mstrActiveControlName = vbNullString
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "txtLotID_Validate"
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
    '作成日：2004/03/11 (Thu) 13:26:41 M.Miura
    '更新日：2004/03/11 (Thu) 13:26:41
    '備　考：
    Private Sub cmbMasHold_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMasHold.Change

        Try

            '@確定ﾎﾞﾀﾝ使用可否制御
            Call prvcmdRegistEnabled_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
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
    '作成日：2004/05/14 (Fri) 13:26:39 M.Miura
    '更新日：2004/05/14 (Fri) 13:26:39
    '備　考：
    Private Sub cmbMasHold_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMasHold.CloseUp

        Try

            With cmbMasHold
                '@取得列を保留理由IDに設定
                .ValueCol = 1
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
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "cmbMasHold_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：dtpHoldTermDate_Change
    '機　能：保留日付変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/15 (Tue) 15:29:44 M.Miura
    '更新日：2004/06/15 (Tue) 15:29:44
    '備　考：
    Private Sub dtpHoldTermDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles dtpHoldTermDate.Change

        Try

            '@確定ﾎﾞﾀﾝ使用可否制御
            Call prvcmdRegistEnabled_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "dtpHoldTermDate_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：dtpHoldTermDate_CalendarSelect
    '機　能：保留期限選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/14 (Fri) 13:23:20 M.Miura
    '更新日：2004/05/14 (Fri) 13:23:20
    '備　考：
    Private Sub dtpHoldTermDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles dtpHoldTermDate.CalendarSelect

        Try

            '@日付の場合
            If IsDate(dtpHoldTermDate.Value) = True Then
                '@次項目にﾌｫｰｶｽｾｯﾄ
                SendKeys.SendWait(CPstrSendKeysTab)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "dtpHoldTermDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：dtpHoldTermDate_Validate
    '機　能：保留期限の入力ﾁｪｯｸ
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/05/25 (Tue) 17:00:40 M.Miura
    '更新日：2004/05/25 (Tue) 17:00:40
    '備　考：
    '　　　：2005/11/17 (Thu) 11:44:21 S.Deguchi    ﾕｰｻﾞｰ要望№0121の対応で､保留期限の最大値を1ヶ月に設定
    Private Sub dtpHoldTermDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles dtpHoldTermDate.Validating

        Dim lstrLimitDate       As String       '保留期限(現在日+1ヶ月)計算値
        Dim lstrNowDT           As String       '現在日付取得
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@日付が入力されていない(空欄)場合
            If dtpHoldTermDate.Value <> CPstrNullDate Then
                '@日付の有効性ﾁｪｯｸ
                If pubblnYearRange_Chk(dtpHoldTermDate.Value) = False Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    
                    '@"正しい日付を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@保留期限にｾｯﾄﾌｫｰｶｽ
                    e.Cancel = True
                Else
                    If plngfrmxxCM0120Kbn = CMlngHold Then
                        lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                        If Format$(CDate(dtpHoldTermDate.Value), CPstrDateTimeYMD) < lstrNowDT Then
                        '@過去日付の場合
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                            
                            '@"過去日付は指定できません。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@保留期限にｾｯﾄﾌｫｰｶｽ
                            e.Cancel = True
                        Else
        '@↓2005/11/17 (Thu) 11:50:07 S.Deguchi **************************************************
                        '@未来日付の場合
                            '@1ヵ月後の日付を計算
                            lstrLimitDate = Format$(DateAdd("m", 1, lstrNowDT), CPstrDateTimeYMD)
                            
                            '@比較
                            If Format$(CDate(dtpHoldTermDate.Value), CPstrDateTimeYMD) > lstrLimitDate Then
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000H)
                                
                                '@"保留期限を1ヶ月以上設定することはできません。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                '@保留期限にｾｯﾄﾌｫｰｶｽ
                                e.Cancel = True
                            End If
        '@↑2005/11/17 (Thu) 11:50:07 S.Deguchi **************************************************
                        End If
                    End If
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "dtpHoldTermDate_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2005/11/17 (Thu) 15:29:40 S.Deguchi **************************************************
    '関数名：cmbHoldEmpName_Change
    '機　能：保留責任者Change処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/17 (Thu) 15:04:45 S.Deguchi
    '更新日：2005/11/17 (Thu) 15:04:45
    '備　考：
    Private Sub cmbHoldEmpName_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbHoldEmpName.Change
        
        Try

            '@保留責任者退避領域を初期化
            mstrHoldEmpID = vbNullString
            
            '@確定ﾎﾞﾀﾝ使用可否制御
            Call prvcmdRegistEnabled_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "cmbHoldEmpName_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbHoldEmpName_CloseUp
    '機　能：保留責任者CloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/17 (Thu) 15:04:48 S.Deguchi
    '更新日：2005/11/17 (Thu) 15:04:48
    '備　考：
    Private Sub cmbHoldEmpName_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbHoldEmpName.CloseUp

        Try

            '@Validate処理へ
            Call cmbHoldEmpName_Validate(True, New CancelEventArgs)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "cmbHoldEmpName_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbHoldEmpName_Validate
    '機　能：保留責任者Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/11/17 (Thu) 15:04:50 S.Deguchi
    '更新日：2005/11/17 (Thu) 15:04:50
    '備　考：
    Private Sub cmbHoldEmpName_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbHoldEmpName.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            With cmbHoldEmpName
                If .Text <> vbNullString Then
                '@空欄以外の場合
                    .ValueCol = 1
                    '@保留責任者退避領域へｾｯﾄ
                    mstrHoldEmpID = .Value
                Else
                '@空欄の場合
                    '@初期化
                    mstrHoldEmpID = vbNullString
                End If
            End With
            
            '@ｾｯﾄﾌｫｰｶｽ処理
            If ActiveControl.Name = cmbHoldEmpName.Name Then
                If cmdRegist.Enabled = True Then
                    '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdRegist)
                Else
                    '@保留一覧が使用可能な場合か否かで処理分岐
                    If vsfLotHoldList.Enabled = True Then
                        '@保留一覧にﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfLotHoldList)
                    Else
                        '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "cmbHoldEmpName_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2005/11/17 (Thu) 15:29:40 S.Deguchi **************************************************

    '関数名：txtHoldComment_Change
    '機　能：保留ｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/28 (Wed) 12:59:46 M.Miura
    '更新日：2004/04/28 (Wed) 12:59:46
    '備　考：
    '　　　：2005/11/22 (Tue) 13:15:34 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub txtHoldComment_Change() Handles txtHoldComment.Change
        
        Dim llngNowByte         As Integer  '現在のﾊﾞｲﾄ数

        Try

            '@現状のﾊﾞｲﾄ数を格納
            llngNowByte = txtHoldComment.NowByte
            
        '@↓2005/11/18 (Fri) 16:09:07 S.Deguchi **************************************************
            '@保留(保留解除)ｺﾒﾝﾄ初期化
            With txtHoldComment
                Select Case plngfrmxxCM0120Kbn
                    Case CMlngHold
                    '@保留起動
                        '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                        llngNowByte = .NowByte                                  '現状のﾊﾞｲﾄ数を格納
                        lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                                      llngNowByte, _
                                                                      CMlngChrMaxByteHold)
                        
                    Case CMlngHoldRelease
                    '@保留解除起動
                        '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                        llngNowByte = .NowByte                                  '現状のﾊﾞｲﾄ数を格納
                        lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                                      llngNowByte, _
                                                                      CMlngChrMaxByteCancel)
                End Select
            End With

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtHoldComment, CMlngMaxDispRow, cmdHoldTxtUp, cmdHoldTxtDown)
        '@↑2005/11/18 (Fri) 16:09:07 S.Deguchi **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "txtHoldComment_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtHoldComment_KeyUp
    '機　能：ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 13:18:37 S.Deguchi
    '更新日：2005/11/22 (Tue) 13:18:37
    '備　考：
    Private Sub txtHoldComment_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtHoldComment.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtHoldComment, CMlngMaxDispRow, cmdHoldTxtUp, cmdHoldTxtDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "txtHoldComment_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtHoldComment_MouseUp
    '機　能：ﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 13:19:54 S.Deguchi
    '更新日：2005/11/22 (Tue) 13:19:54
    '備　考：
    Private Sub txtHoldComment_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtHoldComment.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtHoldComment, CMlngMaxDispRow, cmdHoldTxtUp, cmdHoldTxtDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "txtLotCommnt_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdHoldTxtUp_Click
    '機　能：ｺﾒﾝﾄの前頁切替処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 10:34:21 Y.Yamagishi
    '更新日：2004/04/14 (Wed) 10:18:17 N.Kasai
    '備　考：
    '　　　：2005/11/22 (Tue) 13:15:34 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdHoldTxtUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdHoldTxtUp.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/11/22 (Tue) 13:15:26 S.Deguchi **************************************************
        '    '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtHoldComment)
        '
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtHoldComment, CMlngMaxDispRow, cmdHoldTxtUp, cmdHoldTxtDown)
        '@↑2005/11/22 (Tue) 13:15:26 S.Deguchi **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "cmdHoldTxtUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdHoldTxtDown_Click
    '機　能：ｺﾒﾝﾄの次頁切替処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 10:34:36 Y.Yamagishi
    '更新日：2004/04/14 (Wed) 10:18:23 N.Kasai
    '備　考：
    '　　　：2005/11/22 (Tue) 13:15:34 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdHoldTxtDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdHoldTxtDown.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/11/22 (Tue) 13:16:40 S.Deguchi **************************************************
        '    '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtHoldComment)
        '
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtHoldComment, CMlngMaxDispRow, cmdHoldTxtUp, cmdHoldTxtDown)
        '@↑2005/11/22 (Tue) 13:16:40 S.Deguchi **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "cmdHoldTxtDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2005/11/22 (Tue) 13:28:46 S.Deguchi **************************************************
    '関数名：txtHoldCommentView_Change
    '機　能：保留ｺﾒﾝﾄﾋﾞｭｰ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 13:26:29 S.Deguchi
    '更新日：2005/11/22 (Tue) 13:26:29
    '備　考：
    Private Sub txtHoldCommentView_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtHoldCommentView.Change

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtHoldCommentView, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "txtHoldCommentView_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtHoldCommentView_KeyUp
    '機　能：ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 13:27:19 S.Deguchi
    '更新日：2005/11/22 (Tue) 13:27:19
    '備　考：
    Private Sub txtHoldCommentView_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtHoldCommentView.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtHoldCommentView, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "txtHoldCommentView_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtHoldCommentView_MouseUp
    '機　能：ﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/22 (Tue) 13:19:54 S.Deguchi
    '更新日：2005/11/22 (Tue) 13:19:54
    '備　考：
    Private Sub txtHoldCommentView_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtHoldCommentView.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtHoldCommentView, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "txtHoldCommentView_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2005/11/22 (Tue) 13:28:46 S.Deguchi **************************************************

    '関数名：cmdTxtUp_Click
    '機　能：ｺﾒﾝﾄの前頁切替処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 10:34:21 Y.Yamagishi
    '更新日：2004/04/14 (Wed) 10:18:17 N.Kasai
    '備　考：
    '　　　：2005/11/22 (Tue) 13:15:34 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdTxtUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtUp.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/11/22 (Tue) 13:23:52 S.Deguchi **************************************************
        '    '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtHoldCommentView)
        '
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtHoldCommentView, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
        '@↑2005/11/22 (Tue) 13:23:52 S.Deguchi **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "cmdTxtUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTxtDown_Click
    '機　能：ｺﾒﾝﾄの次頁切替処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 10:34:36 Y.Yamagishi
    '更新日：2004/04/14 (Wed) 10:18:23 N.Kasai
    '備　考：
    '　　　：2005/11/22 (Tue) 13:15:34 S.Deguchi    ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdTxtDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtDown.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/11/22 (Tue) 13:24:40 S.Deguchi **************************************************
        '    '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtHoldCommentView)
        '
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtHoldCommentView, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
        '@↑2005/11/22 (Tue) 13:24:40 S.Deguchi **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "cmdTxtDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfLotHoldList_EnterCell
    '機　能：一覧選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/04/13 (Wed) 16:37:01 S.Deguchi
    '更新日：2005/04/13 (Wed) 16:37:01
    '備　考：
    Private Sub vsfLotHoldList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotHoldList.EnterCell

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotHoldList.Rows.Count <= vsfLotHoldList.Rows.Fixed Then
                Return
            End If

            '@ｺﾒﾝﾄが存在する場合(保留/保留解除で処理分岐なし)
            With vsfLotHoldList
                '@ﾀｲﾄﾙ以外
                If .Row <> 0 Then
                    '@保留ｺﾒﾝﾄ列がNullでない場合
                    If .GetData(.Row, CMlngvsfLotHoldListColHoldComments) <> vbNullString Then
                        '@ｺﾒﾝﾄ反映
                        txtHoldCommentView.Text = .GetData(.Row, CMlngvsfLotHoldListColHoldComments)
                        txtHoldCommentView.Enabled = True
                    Else
                        '@ｺﾒﾝﾄ反映
                        txtHoldCommentView.Text = vbNullString
                        txtHoldCommentView.Enabled = False
                    End If
            
                    '@起動区分による処理対応
                    Select Case plngfrmxxCM0120Kbn
                        '@保留設定
                        Case CMlngHold
                        '@処理なし
                            
                        '@保留解除
                        Case CMlngHoldRelease
                        '@選択した内容を設定ﾌﾚｰﾑへ反映
                            '@保留理由
                            With cmbMasHold
                                '@ｸﾘｱ
                                .Clear
                                '@ﾘｽﾄに追加
                                .AddItem(vsfLotHoldList.GetData(vsfLotHoldList.Row, CMlngvsfLotHoldListColHoldReason) _
                                       & vbTab _
                                       & vsfLotHoldList.GetData(vsfLotHoldList.Row, CMlngvsfLotHoldListColHoldReasonID))
                                '@ﾃｷｽﾄ部分へ表示
                                .ListIndex = CMlngCmbFirstListIndex
                            End With
                            
                            '@保留期限
                            If IsDate(vsfLotHoldList.GetData(vsfLotHoldList.Row,CMlngvsfLotHoldListColHoldEDateL)) Then   
                                dtpHoldTermDate.Value = Format$(CDate(vsfLotHoldList.GetData(vsfLotHoldList.Row, _
                                                                                CMlngvsfLotHoldListColHoldEDateL)), CPstrDateTimeYMD)
                            Else
                                dtpHoldTermDate.Value = vsfLotHoldList.GetData(vsfLotHoldList.Row, _
                                                                                CMlngvsfLotHoldListColHoldEDateL)
                            End If
                            
                            '@保留責任者
                            cmbHoldEmpName.Text = vsfLotHoldList.GetData(vsfLotHoldList.Row, CMlngvsfLotHoldListColHoldEmpName)
                            mstrHoldEmpID = vsfLotHoldList.GetData(vsfLotHoldList.Row, CMlngvsfLotHoldListColHoldEmpID)
                    End Select
                End If
            End With

            '@確定ﾎﾞﾀﾝ使用可否制御
            Call prvcmdRegistEnabled_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "vsfLotHoldList_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdVsfUP_Click
    '機　能：前頁ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/04/14 (Thu) 09:29:12 S.Deguchi
    '更新日：2005/04/14 (Thu) 09:29:12
    '備　考：
    Private Sub cmdVsfUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdVsfUp.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@前頁処理▲
            Call pubVsfCmdUp(vsfLotHoldList, cmdVsfUP, cmdVsfDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "cmdVsfUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdVsfDown_Click
    '機　能：次頁ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/04/14 (Thu) 09:29:15 S.Deguchi
    '更新日：2005/04/14 (Thu) 09:29:15
    '備　考：
    Private Sub cmdVsfDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdVsfDown.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@次頁処理▼
            Call pubVsfCmdDown(vsfLotHoldList, cmdVsfUP, cmdVsfDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "cmdVsfDown_Click"
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
    '関数名：prvfrmxxCM0120_Init
    '機　能：画面情報、変数、ｺﾝﾄﾛｰﾙの初期化処理
    '引　数：lblnCarrier：True：ｷｬﾘｱ項目削除、False：ｷｬﾘｱ項目未削除
    '戻り値：なし
    '作成日：2004/03/09 (Tue) 15:44:09 M.Miura
    '更新日：2008/06/10 (Tue) 14:08:10 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 11:22:43 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理追加
    '　　　：2005/02/14 (Mon) 15:40:32 N.Kojima     ﾛｯﾄIDの初期化等追加(改善№511)
    '　　　：2005/03/29 (Tue) 09:11:26 S.Deguchi    制限ﾌﾗｸﾞの初期化処理を追加
    '　　　：2005/04/12 (Tue) 12:36:04 S.Deguchi    初期化処理を修正
    '　　　：2005/11/17 (Thu) 13:11:09 S.Deguchi    ﾕｰｻﾞｰ要望№0121の対応で,保留責任者をComboへ変更
    '　　　：2008/06/10 (Tue) 14:08:10 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxCM0120_Init(Optional ByVal lblnCarrier As Boolean = True)

        Dim llngNowByte         As Integer      'ﾊﾞｲﾄ数格納
        Dim lstrFormTitle       As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try

            '@初期値設定
            If lblnCarrier = True Then
                '@ｷｬﾘｱID
                txtCarrierID.Text = vbNullString                            'ｷｬﾘｱID
            End If

            '@LotCurstate情報ﾗﾍﾞﾙの初期化
            lblFlowClass.Text = vbNullString                                '種別ｺｰﾄﾞ
            lblWFNo.Text = vbNullString                                     'WF枚数
            lblStatus.Text = vbNullString                                   '状態
            lblOpID.Text = vbNullString                                     '大工程ID
            lblStepID.Text = vbNullString                                   '小工程ID
            lblStartDayTime.Text = vbNullString                             '開始日時
            lblLotManager.Text = vbNullString                               'ﾛｯﾄ担当
            lblPdID.Text = vbNullString                                     '機種名
            lblTimeLimit.Text = vbNullString                                '時間制約
            lblS.Text = vbNullString                                        '特殊特性
            '@↓2020/02/19 (Wed) 13:58:40 Y.Yoneyama 「.Netへ反映未」 **************************************************
            lblGRB.Text = vbNullString                                      'GRB
            '@GRB背景色
            lblGRB.BackColor = lblLotManager.BackColor
            '@↑2020/02/19 (Wed) 13:58:40 Y.Yoneyama 「.Netへ反映未」 **************************************************
            
            '@処理開始予定ﾀｲﾄﾙ設定
            lblStartTime.Text = CPstrDispatchTime
            
            '@ﾛｯﾄ保留設定情報の初期化
            '@ｺﾝﾎﾞﾎﾞｯｸｽ設定
            With cmbMasHold
                .Clear                                                          'ｸﾘｱ
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColHoldName                               'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColHoldID                               '値取得列
                .DirectInput = False                                            'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Text = vbNullString                                            '初期化
                .Font = New Font(.Font.Name, CType(CMlngCmbFontSize, Single))   'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.Font.Name, CType(CMlngCmbGridFontSize, Single)) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  '行の高さ
                .ColAlignment(CMlngCmbGridColHoldName) = TextAlignEnum.LeftCenter    '左寄中央揃え
                .Enabled = False                                                '非活性化
            End With
            
            '@保留期限ｶﾚﾝﾀﾞｰ設定
            Call pubblnCalendar_Init(dtpHoldTermDate, CMlngCal0)
            With dtpHoldTermDate
                .Value = vbNullString                                           'Null設定
                .Enabled = False                                                '非活性化
            End With
            
            '@保留責任者設定
            '@ｺﾝﾎﾞﾎﾞｯｸｽ設定
            With cmbHoldEmpName
                .Clear                                                          'ｸﾘｱ
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColHoldName                               'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColHoldID                               '値取得列
                .DirectInput = False                                            'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Text = vbNullString                                            '初期化
                .Font = New Font(.Font.Name, CType(CMlngCmbFontSize, Single))   'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.Font.Name, CType(CMlngCmbGridFontSize, Single)) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  '行の高さ
                .ColAlignment(CMlngCmbGridColHoldName) = TextAlignEnum.LeftCenter    '左寄中央揃え
                .Enabled = False                                                '非活性化
            End With
            
            '@保留(保留解除)ｺﾒﾝﾄ初期化
            With txtHoldComment
                .Text = vbNullString                                            'Null表示
                .MultiLineEx = True                                             '複数行表示可能制御
                .Enabled = False                                                '非活性化
                
                Select Case plngfrmxxCM0120Kbn
                    Case CMlngHold
                    '@保留起動
                        .ChrMaxByte = CMlngChrMaxByteHold
                        
                        '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                        llngNowByte = .NowByte                                  '現状のﾊﾞｲﾄ数を格納
                        lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                                      llngNowByte, _
                                                                      CMlngChrMaxByteHold)
                        
                    Case CMlngHoldRelease
                    '@保留解除起動
                        .ChrMaxByte = CMlngChrMaxByteCancel
                        
                        '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                        llngNowByte = .NowByte                                  '現状のﾊﾞｲﾄ数を格納
                        lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, _
                                                                      llngNowByte, _
                                                                      CMlngChrMaxByteCancel)
                End Select
                
                '@ﾊﾞｲﾄ数非表示
                lblLengthCount.Visible = False
            End With

            cmdHoldTxtUp.Enabled = False                                        'ｱｯﾌﾟﾎﾞﾀﾝ
            cmdHoldTxtDown.Enabled = False                                      'ﾀﾞｳﾝﾎﾞﾀﾝ
            
            '@保留情報一覧の初期化
            Call prvvsfLotHoldList_Init()
            cmdVsfUP.Enabled = False                                            'ｱｯﾌﾟﾎﾞﾀﾝ
            cmdVsfDown.Enabled = False                                          'ﾀﾞｳﾝﾎﾞﾀﾝ
            
            '@保留ｺﾒﾝﾄ(表示のみ)初期化
            With txtHoldCommentView
                .Locked = True                                                  'ﾛｯｸ
                .Text = vbNullString                                            'Null表示
                .MultiLineEx = True                                             '複数行表示可能制御
                .Enabled = False                                                '非活性化
                .BackColor = vbButtonFace                                       'ﾊﾞｯｸｶﾗｰ設定
                .GotBackColor = vbButtonFace                                    'ﾊﾞｯｸｶﾗｰ設定
            End With
            
            cmdTxtUp.Enabled = False                                            'ｱｯﾌﾟﾎﾞﾀﾝ
            cmdTxtDown.Enabled = False                                          'ﾀﾞｳﾝﾎﾞﾀﾝ
            
            '@起動区分による処理対応
            Select Case plngfrmxxCM0120Kbn
                '@保留設定
                Case CMlngHold
                    '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
                    Call pubMenuItemCorrelation_Set(CPstrKeyEN0050, lstrFormTitle)
                    
                    '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
                    Me.Text = lstrFormTitle
                    
                    '@保留設定(各ｺﾝﾄﾛｰﾙの背景色を白へ変更する)
                    cmbMasHold.BackColor = Color.White
                    dtpHoldTermDate.BackColor = Color.White
                    cmbHoldEmpName.BackColor = Color.White
                    txtHoldComment.BackColor = Color.White
                    
                    '@画面ﾀｲﾄﾙ類の表示設定
                    lblTitleHoldComment.Text = CMstrHoldLabelTitle
                    fraHoldSet.Text = CMstrHoldFrameTitle
                
                '@保留解除
                Case CMlngHoldRelease
                    '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
                    Call pubMenuItemCorrelation_Set(CPstrKeyEN00A0, lstrFormTitle)
                    
                    '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
                    Me.Text = lstrFormTitle
                    
                    '@保留解除設定(各ｺﾝﾄﾛｰﾙの背景色をｸﾞﾚｰへ変更する)
                    cmbMasHold.BackColor = vbButtonFace
                    dtpHoldTermDate.BackColor = vbButtonFace
                    cmbHoldEmpName.BackColor = vbButtonFace
                    txtHoldComment.BackColor = Color.White
            
                    '@画面ﾀｲﾄﾙ類の表示設定
                    lblTitleHoldComment.Text = CMstrHoldReleaseLabelTitle
                    fraHoldSet.Text = CMstrHoldReleaseFrameTitle
            End Select
            
            '@保留/保留解除の確定ﾎﾞﾀﾝの初期化
            cmdRegist.Enabled = False
            
            '@退避領域の初期化
            mstrCarrier = vbNullString                                          'ｷｬﾘｱID(ﾒｯｾｰｼﾞ成功時のｷｬﾘｱID)
            mstrLot = vbNullString                                              'ﾛｯﾄID(ﾒｯｾｰｼﾞ成功時のﾛｯﾄID)
            mstrEmpID = vbNullString                                            '退避用保留責任者ID
            mstrLotLastUpdate = vbNullString                                    'ﾛｯﾄ最終更新日時
            mstrSelectControlName = vbNullString                                '抽出ｺﾝﾄﾛｰﾙ名の初期化
            mstrHoldEmpID = vbNullString                                        '保留責任者ID
            mstrLotManagerID = vbNullString                                     'ﾛｯﾄ担当者ID
            
            '@有効ｺﾝﾄﾛｰﾙ名の判定
            Select Case mstrActiveControlName
                '@ｷｬﾘｱID
                Case CMstrActiveControlNameCarrierID
                    txtLotID.Text = vbNullString                                'ﾛｯﾄID
                '@ﾛｯﾄID
                Case CMstrActiveControlNameLotID
                    txtCarrierID.Text = vbNullString                            'ｷｬﾘｱID
                Case Else
                    txtCarrierID.Text = vbNullString                            'ｷｬﾘｱID
                    txtLotID.Text = vbNullString                                'ﾛｯﾄID
            End Select
            
            '@終了時にValidateｲﾍﾞﾝﾄを実行しない
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvfrmxxCM0120_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxCM0120_Disp
    '機　能：ﾛｯﾄ情報の表示
    '引　数：ltypLotprestate：ﾛｯﾄ現在状態格納構造体
    '戻り値：なし
    '作成日：2004/03/12 (Fri) 16:21:34 M.Miura
    '更新日：2008/06/10 (Tue) 14:09:11 N.Kojima
    '備　考：
    '　　　：2004/08/25 (Wed) CFﾌﾗｸﾞ判定追加
    '　　　：2004/09/09 (Thu) 19:03:16 Y.Yamagishi　時間制限表示変更(不具合改善№693)
    '　　　：2004/09/14 (Tue) 10:28:44 N.Kojima　   数量表示(TPALﾛｯﾄ対応)修正(不具合改善№730)
    '　　　：2004/09/29 (Wed) 16:43:49 N.Kasai　    保留期限の初期値をｻｰﾊﾞｰより表示(№833)
    '　　　：2005/02/14 (Mon) 16:31:51 N.Kojima 　　有効ｺﾝﾄﾛｰﾙ名の判定処理追加(改善№511)
    '　　　：2005/04/18 (Mon) 09:56:03 S.Deguchi    不具合№688対応で起動区分処理対応を修正
    '　　　：2005/05/26 (Thu) 14:01:04 N.Kasai      LP_FLAG判定追加
    '　　　：2005/11/17 (Thu) 14:49:20 S.Deguchi    ﾕｰｻﾞｰ要望№0121の対応で,保留責任者txtをComboへ変更
    '　　　：2005/11/21 (Mon) 14:49:40 S.Deguchi    ﾕｰｻﾞｰ要望№0121の対応で,技術担当者IDを内部変数へ退避
    '　　　：2006/06/08 (Thu) 14:34:59 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2008/06/10 (Tue) 14:09:11 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxCM0120_Disp(ByRef ltypLotprestate As Lotprestate)

        Try

            '@ﾛｯﾄ情報の表示
            With ltypLotprestate
            
                '@有効ｺﾝﾄﾛｰﾙ名の判定
                Select Case mstrActiveControlName
                    
                    '@ｷｬﾘｱID
                    Case CMstrActiveControlNameCarrierID
                        
                        txtLotID.Text = .strLotID                                           'ﾛｯﾄID
                    
                    '@ﾛｯﾄID
                    Case CMstrActiveControlNameLotID
                        
                        txtCarrierID.Text = .strCarrierId                                   'ｷｬﾘｱID
                    
                    '@どちらか判断不正
                    Case Else
                        
                        txtCarrierID.Text = .strCarrierId                                   'ｷｬﾘｱID
                        txtLotID.Text = .strLotID                                           'ﾛｯﾄID
                End Select
            
                txtLotID.Text = .strLotID                                                   'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass                                           '流動区分
                lblOpID.Text = .strOpID                                                     '大工程ID
                lblPdID.Text = .strPdId                                                     '機種名
                lblS.Text = .strSpecialFlg                                                  '特殊特性
                lblStatus.Text = .strNowST                                                  '状態
                lblStepID.Text = .strStepID                                                 '小工程ID
                lblLotManager.Text = .strEngEmpName                                         'ﾛｯﾄ担当          
                '@↓2020/02/19 (Wed) 13:49:33 Y.Yoneyama 「.Netへ反映未」 **************************************************
                lblGRB.Text = .strGRBClass                                                  'GRB
                '@GRB背景色
                lblGRB.BackColor = pubGRBBackColor(.strGRBClass, lblLotManager.BackColor)
                '@↑2020/02/19 (Wed) 13:49:33 Y.Yoneyama 「.Netへ反映未」 **************************************************
                mstrLotManagerID = .strEngEmpId                                             'ﾛｯﾄ担当者ID
                
                '@時間制約有無の表示
                If .strLimitTime <> vbNullString Then
                    
                    '@時間制約がﾌﾟﾗｽの場合
                    If CLng(.strLimitTime) >= 0 Then

                        '@制限時間以下or処理時間制限以下の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@制限時間先大工程+制限時間先小工程+制限時間
                            '@ﾌｫｰﾏｯﾄ変換(#,##0)+"分"
                            If IsNumeric(.strLimitTime) Then
                                lblTimeLimit.Text = Format$(CInt(.strLimitTime), CPstrDateFormatKanma) & CPstrh
                            Else
                                lblTimeLimit.Text = .strLimitTime & CPstrh
                            End If
                            '@右寄せ
                            lblTimeLimit.TextAlign = ContentAlignment.TopRight
                            
                            '@警告時間が設定されている場合
                            If .strWarnTime <> vbNullString Then
                                '@時間制限が警告時間を過ぎている,且つ制限時間がｵｰﾊﾞｰしていない場合
                                If CInt(.strWarnTime) < 0 And CInt(.strLimitTime) >= 0 Then
                                    '@ﾌｫﾝﾄｶﾗｰを紫に変更
                                    lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple)  '紫
                                Else
                                     '@ﾌｫﾝﾄｶﾗｰを黒に変更
                                    lblTimeLimit.ForeColor = Color.Black                            '黒
                                End If
                            End If
                        End If

                    Else
                        '@制限時間がﾏｲﾅｽの場合
                        '@制限時間先大工程+制限時間先小工程+制限時間
                        
                        '@右寄せ
                        lblTimeLimit.TextAlign = ContentAlignment.TopRight
                        '@ForColorの変更
                        lblTimeLimit.ForeColor = Color.Red                                          '赤
                        
                        '@制限時間以下or処理時間制限以下の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@ﾌｫｰﾏｯﾄ変換(#,##0)+"分"
                            If IsNumeric(.strLimitTime) Then
                                lblTimeLimit.Text = Format$(CInt(.strLimitTime), CPstrDateFormatKanma) & CPstrh
                            Else
                                lblTimeLimit.Text = .strLimitTime & CPstrh
                            End If
                        End If
                        
                        '@制限時間以上の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID2 Then
                            '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(#,##0)+"分"
                            If IsNumeric(.strLimitTime) Then
                                lblTimeLimit.Text = Replace(Format$(CInt(.strLimitTime), CPstrDateFormatKanma), _
                                                           CPstrReplaceMinus, vbNullString) & CPstrh
                            Else
                                lblTimeLimit.Text = Replace(.strLimitTime, _
                                                           CPstrReplaceMinus, vbNullString) & CPstrh
                            End If
                        End If
                    End If
                End If
                
                mstrLotLastUpdate = .strLotLastUpdate                                               'ﾛｯﾄ最終更新日時
                
                '@枚数表示判定(CF_FLAGを判定し、WF枚数とﾁｯﾌﾟ枚数の表示を切替)
                Select Case .strCfFlag
                    '@CFﾛｯﾄ
                    Case CPstrCF
                        '@大判ﾌﾗｸﾞ判定(LP_FLAG)
                        If .strLpFlag = CPstrLP Then
                            '@大判の場合
                            lblWFNo.Text = .strWfNum                                             'WF枚数
                        Else
                            If IsNumeric(.strChipQuantity) Then
                                lblWFNo.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)    'ﾁｯﾌﾟ枚数
                            Else
                                lblWFNo.Text = .strChipQuantity                                      'ﾁｯﾌﾟ枚数
                            End If
                        End If
                        
                    '@CFﾛｯﾄ以外
                    Case Else
                        '@TPALﾛｯﾄ
                        If Trim(Strings.Left(.strLotID, 2)) = CPstrTpalLot Then
                            If IsNumeric(.strChipQuantity) Then
                                lblWFNo.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)    'ﾁｯﾌﾟ枚数
                            Else
                                lblWFNo.Text = .strChipQuantity                                      'ﾁｯﾌﾟ枚数
                            End If
                        Else
                            '@CF,TPALﾛｯﾄ以外
                            lblWFNo.Text = .strWfNum                                             'WF枚数
                        End If
                End Select
                
                '@ﾛｯﾄ状態
                Select Case .strNowST
                    '@「作業待ち」「前処理」の場合
                    Case CPstrWaitWorkSt, CPstrBeforeProgressSt
                        '@日付ﾀｲﾄﾙ設定「処理開始予定」
                        lblStartTime.Text = CPstrDispatchTime
                        If IsDate(.strDispatchStartTime) Then
                            lblStartDayTime.Text = Format$(CDate(.strDispatchStartTime), CPstrDateFormat)   '投入予定日"mm/dd hh:mm:ss"
                        Else
                            lblStartDayTime.Text = .strDispatchStartTime                                    '投入予定日
                        End If
                    '@その他
                    Case Else
                        '@日付ﾀｲﾄﾙ設定「処理開始日時」
                        lblStartTime.Text = CPstrStartTime
                        If IsDate(.strStartTime) Then
                            lblStartDayTime.Text = Format$(CDate(.strStartTime), CPstrDateFormat)           '開始日時"mm/dd hh:mm:ss"
                        Else
                            lblStartDayTime.Text = .strStartTime                                            '開始日時
                        End If
                End Select
                
                '@起動区分による処理対応
                Select Case plngfrmxxCM0120Kbn
                    
                    '@保留設定
                    Case CMlngHold
                        
                        '@保留期限ｾｯﾄ
                        If IsDate(.strHoldTermDate) Then
                            dtpHoldTermDate.Value = Format$(CDate(.strHoldTermDate), CPstrDateTimeYMD)
                        Else
                            dtpHoldTermDate.Value = .strHoldTermDate
                        End If
                        dtpHoldTermDate.Enabled = True
                        
                        '@保留責任者ｾｯﾄ
                        cmbHoldEmpName.BackColor = Color.White
                    
                    '@保留解除
                    Case CMlngHoldRelease
                        
                        '@保留期限ｾｯﾄ(Null)
                        dtpHoldTermDate.Value = vbNullString
                        dtpHoldTermDate.Enabled = False
                
                        '@保留責任者ｾｯﾄ
                        cmbHoldEmpName.BackColor = vbButtonFace
                End Select
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvfrmxxCM0120_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvLotHoldinfo_Disp
    '機　能：保留情報処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/10 (Wed) 16:26:08 M.Miura
    '更新日：2004/09/29 (Wed) 16:42:01 N.Kasai
    '備　考：2004/09/29 (Wed) 16:42:01 N.Kasai      保留期限をlot_curstateより取得
    '　　　：2005/03/29 (Tue) 09:09:03 S.Deguchi    保留解除時の処理を修正
    '　　　：2005/04/18 (Mon) 09:56:03 S.Deguchi    不具合№688対応で起動区分処理対応を修正&保留ﾘｽﾄ化により画面制御のみとする
    Private Sub prvLotHoldinfo_Disp()
        
        Dim llngCnt             As Integer  'ｶｳﾝﾄ

        Try
            
            If plngfrmxxCM0120Kbn = CMlngHold Then
            '@保留起動の場合
                '@保留理由ｾｯﾄ
                With cmbMasHold
                    .Clear      'ｸﾘｱ
                    
                    '@情報ｾｯﾄ
                    For llngCnt = 0 To mtypMasItemList.lngListCnt - 1
                        .AddItem(mtypMasItemList.typeMasItem(llngCnt).strItemName _
                               & vbTab _
                               & mtypMasItemList.typeMasItem(llngCnt).strItemID)
                    Next llngCnt
                    
                    '@理由が1件の場合
                    If .ListCount = 1 Then
                        '@1件目表示
                        .ListIndex = CMlngCmbFirstListIndex
                    End If
                End With
                
                '@保留責任者ｸﾘｱ
                cmbHoldEmpName.Text = vbNullString
                Call prvCmbHoldEmpName_Disp()
                
                '@保留ｺﾒﾝﾄ設定
                With txtHoldComment
                    .BackColor = vbWindowBackground
                    .GotBackColor = vbWindowBackground
                    .Locked = False
                    .Enabled = True
                End With
                
                '@保留ｺﾒﾝﾄﾊﾞｲﾄ数表示
                lblLengthCount.Visible = True
                
                '@保留ｺﾒﾝﾄﾊﾞｲﾄ数設定
                Call txtHoldComment_Change()
                
                '@ﾛｯｸ解除
                cmbMasHold.Enabled = True                               '保留理由
                dtpHoldTermDate.Enabled = True                          '保留期限
                cmbHoldEmpName.Enabled = True                           '保留責任者
            Else
                '@保留ｺﾒﾝﾄ設定
                With txtHoldComment
                    .BackColor = vbWindowBackground
                    .GotBackColor = vbWindowBackground
                    .Locked = False
                    .Enabled = True
                End With
                
                '@保留ｺﾒﾝﾄﾊﾞｲﾄ数表示
                lblLengthCount.Visible = True
                
                '@保留ｺﾒﾝﾄﾊﾞｲﾄ数設定
                Call txtHoldComment_Change()
                
                '@ﾛｯｸ
                cmbMasHold.Enabled = False                              '保留理由
                dtpHoldTermDate.Enabled = False                         '保留期限
                cmbHoldEmpName.Enabled = False                          '保留責任者
                
                '@背景色設定
                cmbMasHold.BackColor = vbButtonFace                     '保留理由
                dtpHoldTermDate.BackColor = vbButtonFace                '保留期限
                cmbHoldEmpName.BackColor = vbButtonFace                 '保留責任者
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvLotHoldinfo_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnInput_Chk
    '機　能：入力情報ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/10 (Wed) 19:03:15 M.Miura
    '更新日：2005/02/14 (Mon) 17:32:15 N.Kojima
    '備　考：2005/02/14 (Mon) 17:32:15 N.Kojima　   ﾛｯﾄID入力機能追加に伴う修正(改善№511)
    '　　　：2005/03/29 (Tue) 09:17:31 S.Deguchi    制限ﾌﾗｸﾞでのﾁｪｯｸを追加
    '　　　：2005/04/11 (Mon) 17:11:16 S.Deguchi    制限ﾌﾗｸﾞのﾁｪｯｸで2の場合には,許可する処理に修正
    '　　　：2005/04/14 (Thu) 10:11:42 S.Deguchi    複数保留対応で処理全面見直し
    Private Function prvblnInput_Chk() As Boolean
        
        Dim lstrNowDT       As String   '現在日付取得

        Try
            
            '@初期化
            prvblnInput_Chk = False
            
            '@ﾛｯﾄIDﾁｪｯｸ
            If txtLotID.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0022)
                
                '@"ロットIDが設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Call pubSetFocus(txtCarrierID)
                
                Exit Function
            End If
            
            '@保留理由ﾁｪｯｸ
            If cmbMasHold.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0025)
                
                '@"保留理由が設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@保留理由にﾌｫｰｶｽｾｯﾄ
                If cmbMasHold.Enabled = True Then
                    Call pubSetFocus(cmbMasHold)
                End If
                
                Exit Function
            End If
            
            '@保留にする場合
            If plngfrmxxCM0120Kbn = CMlngHold Then
            '@保留期限ﾁｪｯｸ
                lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                '@保留設定する場合
                If Format$(CDate(dtpHoldTermDate.Value), CPstrDateTimeYMD) < lstrNowDT Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                    
                    '@"過去日付は指定できません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@保留理由にﾌｫｰｶｽｾｯﾄ
                    If dtpHoldTermDate.Enabled = True Then
                        Call pubSetFocus(dtpHoldTermDate)
                    End If
                    
                    Exit Function
                End If

                '@保留責任者IDﾁｪｯｸ
                If cmbHoldEmpName.Text = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000B)
                    
                    '@"保留責任者が設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@保留責任者にﾌｫｰｶｽｾｯﾄ
                    If cmbHoldEmpName.Enabled = True Then
                        Call pubSetFocus(cmbHoldEmpName)
                    End If
                    
                    Exit Function
                End If
            End If
            
            '@結果OKを返す
            prvblnInput_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvblnInput_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvcmdRegistEnabled_Chk
    '機　能：確定ﾎﾞﾀﾝ活性化ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/23 (Wed) 09:08:51 M.Miura
    '更新日：2004/06/23 (Wed) 09:08:51
    '備　考：
    Private Sub prvcmdRegistEnabled_Chk()

        Try

            '@保留解除の場合
            If plngfrmxxCM0120Kbn = CMlngHoldRelease Then
                With vsfLotHoldList
                    '@ﾀｲﾄﾙ以外
                    If .Row <> 0 Then
                        '@制限ﾌﾗｸﾞが"1"以外の場合
                        If .GetData(.Row, CMlngvsfLotHoldListColRestrictFlag) <> CMstrRestrictFlag1 Then
                            '@確定ﾎﾞﾀﾝ使用可
                            cmdRegist.Enabled = True
                            Exit Sub
                        Else
                            '@確定ﾎﾞﾀﾝ使用不可
                            cmdRegist.Enabled = False
                            Exit Sub
                        End If
                    End If
                End With
            Else
                '@保留理由、保留日付ﾁｪｯｸ
                If cmbMasHold.Text <> vbNullString And _
                   IsDate(dtpHoldTermDate.Value) = True And _
                   cmbHoldEmpName.Text <> vbNullString Then
                    '@確定ﾎﾞﾀﾝ使用可
                    cmdRegist.Enabled = True
                Else
                    '@確定ﾎﾞﾀﾝ使用不可
                    cmdRegist.Enabled = False
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvcmdRegistEnabled_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotHoldList_Init
    '機　能：保留情報一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/04/12 (Tue) 11:16:22 S.Deguchi
    '更新日：2005/04/12 (Tue) 11:16:22
    '備　考：
    Private Sub prvvsfLotHoldList_Init()

        Try
            
            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfLotHoldList
                '@ｸﾘｱ
                .Clear
                .Redraw = False
                '@ﾌﾟﾛﾊﾟﾃｨの設定対象を選択されたｾﾙに設定
                '.FillStyle = flexFillRepeat
                
                '@ﾍｯﾀﾞｸﾘｯｸで全選択不可
                '.AllowBigSelection = False
                
                '@ﾏｳｽでｾﾙ範囲選択不可
                '.AllowSelection = False
                
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                
                '@行数設定
                .Rows.Count = .Rows.Fixed
                
                '@ｶﾚﾝﾄｾﾙの周囲に描画するﾌｫｰｶｽ枠のｽﾀｲﾙを設定(なし)
                .FocusRect = FocusRectEnum.None
                
                '@一覧表の表題設定
                .Select(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColTitle, .Rows.Count - 1, .Cols.Count - 1)
                .Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter                                 '中央表示
                .Styles.Fixed.ForeColor = Color.Yellow                                               '文字色
                .Styles.Fixed.BackColor = Color.Navy                                                 '背景色
                .Styles.Fixed.Font = New Font(.Font.FontFamily, CType(CMlngvsfLotHoldListHFontSize, Single), .Font.Style, .Font.Unit) 'ﾌｫﾝﾄｻｲｽﾞ
                .Rows(CMlngvsfLotHoldListRowTitle).Height = CMlngvsfLotHoldListHHeight               '高さ
                        
                'ﾀｲﾄﾙ,列幅設定
                '@№
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColNo, CMstrvsfLotHoldListColNo)
                .Cols(CMlngvsfLotHoldListColNo).Width = CMlngvsfLotHoldListColWNo
                
                '@保留開始日
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColHoldSDate, CMstrvsfLotHoldListColHoldSDate)
                .Cols(CMlngvsfLotHoldListColHoldSDate).Width = CMlngvsfLotHoldListColWHoldSDate
                
                '@保留日(EntryTime)
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColEntryTime, CMstrvsfLotHoldListColEntryTime)
                .Cols(CMlngvsfLotHoldListColEntryTime).Width = CMlngvsfLotHoldListColWEntryTime
                
                '@保留期限
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColHoldEDate, CMstrvsfLotHoldListColHoldEDate)
                .Cols(CMlngvsfLotHoldListColHoldEDate).Width = CMlngvsfLotHoldListColWHoldEDate
                
                '@保留期限(西暦表記)
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColHoldEDateL, CMstrvsfLotHoldListColHoldEDateL)
                .Cols(CMlngvsfLotHoldListColHoldEDateL).Width = CMlngvsfLotHoldListColWHoldEDateL
                
                '@保留期間
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColHoldTerm, CMstrvsfLotHoldListColHoldTerm)
                .Cols(CMlngvsfLotHoldListColHoldTerm).Width = CMlngvsfLotHoldListColWHoldTerm
                
                '@保留理由ID
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColHoldReasonID, CMstrvsfLotHoldListColHoldReasonID)
                .Cols(CMlngvsfLotHoldListColHoldReasonID).Width = CMlngvsfLotHoldListColWHoldReasonID
                
                '@保留理由
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColHoldReason, CMstrvsfLotHoldListColHoldReason)
                .Cols(CMlngvsfLotHoldListColHoldReason).Width = CMlngvsfLotHoldListColWHoldReason
                
                '@保留責任者ID
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColHoldEmpID, CMstrvsfLotHoldListColHoldEmpID)
                .Cols(CMlngvsfLotHoldListColHoldEmpID).Width = CMlngvsfLotHoldListColWHoldEmpID
                
                '@保留責任者名
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColHoldEmpName, CMstrvsfLotHoldListColHoldEmpName)
                .Cols(CMlngvsfLotHoldListColHoldEmpName).Width = CMlngvsfLotHoldListColWHoldEmpName
                
                '@保留内容
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColHoldComments, CMstrvsfLotHoldListColHoldComments)
                .Cols(CMlngvsfLotHoldListColHoldComments).Width = CMlngvsfLotHoldListColWHoldComments
                
                '@制限ﾌﾗｸﾞ
                .SetData(CMlngvsfLotHoldListRowTitle, CMlngvsfLotHoldListColRestrictFlag, CMstrvsfLotHoldListColRestrictFlag)
                .Cols(CMlngvsfLotHoldListColRestrictFlag).Width = CMlngvsfLotHoldListColWRestrictFlag
                
                '@列位置の設定
                .Cols(CMlngvsfLotHoldListColNo).TextAlign = TextAlignEnum.RightCenter               '№
                .Cols(CMlngvsfLotHoldListColHoldSDate).TextAlign = TextAlignEnum.LeftCenter         '保留開始日
                .Cols(CMlngvsfLotHoldListColEntryTime).TextAlign = TextAlignEnum.LeftCenter         '保留日(EntryTime)
                .Cols(CMlngvsfLotHoldListColHoldEDate).TextAlign = TextAlignEnum.LeftCenter         '保留期限
                .Cols(CMlngvsfLotHoldListColHoldEDateL).TextAlign = TextAlignEnum.LeftCenter        '保留期限(西暦表記)
                .Cols(CMlngvsfLotHoldListColHoldReasonID).TextAlign = TextAlignEnum.LeftCenter      '保留理由ID
                .Cols(CMlngvsfLotHoldListColHoldReason).TextAlign = TextAlignEnum.LeftCenter        '保留理由
                .Cols(CMlngvsfLotHoldListColHoldEmpID).TextAlign = TextAlignEnum.LeftCenter         '保留責任者ID
                .Cols(CMlngvsfLotHoldListColHoldEmpName).TextAlign = TextAlignEnum.LeftCenter       '保留責任者
                .Cols(CMlngvsfLotHoldListColHoldComments).TextAlign = TextAlignEnum.LeftCenter      'ｺﾒﾝﾄ内容
                .Cols(CMlngvsfLotHoldListColRestrictFlag).TextAlign = TextAlignEnum.LeftCenter      '制限ﾌﾗｸﾞ
                
                '@非表示列設定
                .Cols(CMlngvsfLotHoldListColEntryTime).Visible = False                              '保留日(EntryTime)
                .Cols(CMlngvsfLotHoldListColHoldEDateL).Visible = False                             '保留期限(西暦表記)
                .Cols(CMlngvsfLotHoldListColHoldReasonID).Visible = False                           '保留理由ID
                .Cols(CMlngvsfLotHoldListColHoldEmpID).Visible = False                              '保留責任者ID
                .Cols(CMlngvsfLotHoldListColHoldComments).Visible = False                           'ｺﾒﾝﾄ内容
                .Cols(CMlngvsfLotHoldListColRestrictFlag).Visible = False                           '制限ﾌﾗｸﾞ
                        
                '@描画
                .Redraw = True
                '@ﾛｯｸ
                .Enabled = False
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvvsfLotHoldList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLotHoldList_Disp
    '機　能：保留情報一覧の表示
    '引　数：ltypLotHoldInfoList：保留ﾘｽﾄ構造体
    '戻り値：なし
    '作成日：2005/04/13 (Wed) 17:52:38 S.Deguchi
    '更新日：2005/04/13 (Wed) 17:52:38
    '備　考：
    Private Sub prvvsfLotHoldList_Disp(ByRef ltypLotHoldInfoList As LotHoldInfoList)
        
        Dim llngDoCnt       As Integer      'ﾙｰﾌﾟｶｳﾝﾀ

        Try

            With vsfLotHoldList
                '@ﾘｽﾄが0件の場合には,処理を行わない
                If ltypLotHoldInfoList.lngHoldInfoListCnt = 0 Then
                    '@一覧内容を初期化
                    .Rows.Count = .Rows.Fixed
                    
                    '@ﾛｯｸ
                    .Enabled = False
                    
                    '@保留情報一覧初期ﾎﾞﾀﾝ設定
                    cmdVsfUP.Enabled = False                                     'ﾘｽﾄのｽｸﾛｰﾙﾎﾞﾀﾝ(ｱｯﾌﾟ)
                    cmdVsfDown.Enabled = False                                   'ﾘｽﾄのｽｸﾛｰﾙﾎﾞﾀﾝ(ﾀﾞｳﾝ)
                    cmdTxtUp.Enabled = False                                     'ﾘｽﾄのｺﾒﾝﾄ表示ｽｸﾛｰﾙﾎﾞﾀﾝ(ｱｯﾌﾟ)
                    cmdTxtDown.Enabled = False                                   'ﾘｽﾄのｺﾒﾝﾄ表示ｽｸﾛｰﾙﾎﾞﾀﾝ(ﾀﾞｳﾝ)
                    
                    '@処理抜け
                    Exit Sub
                End If
                
                '@表示をとめる
                .Redraw = False
                
                'NSYS クリア
                .Row = -1

                '@表示列を固定列のみ(初期化処理)
                .Rows.Count = .Rows.Fixed
                
                '@行数設定
                RemoveHandler vsfLotHoldList.EnterCell, AddressOf vsfLotHoldList_EnterCell
                .Rows.Count = ltypLotHoldInfoList.lngHoldInfoListCnt + 1
                AddHandler vsfLotHoldList.EnterCell, AddressOf vsfLotHoldList_EnterCell
                
                '@ｶｳﾝﾀの初期化
                llngDoCnt = 1
                
                '@ﾛｯﾄ一覧表示情報設定
                Do While .Rows.Count > llngDoCnt
                    '@№
                    .SetData(llngDoCnt, CMlngvsfLotHoldListColNo, llngDoCnt)
                
                    '@保留開始日
                    If IsDate(ltypLotHoldInfoList.typHoldInfoList(llngDoCnt - 1).strHoldTime) Then
                        .SetData(llngDoCnt, CMlngvsfLotHoldListColHoldSDate, _
                        Format$(CDate(ltypLotHoldInfoList.typHoldInfoList(llngDoCnt - 1).strHoldTime), CPstrDateFormatMDHM))
                    Else
                        .SetData(llngDoCnt, CMlngvsfLotHoldListColHoldSDate, _
                       ltypLotHoldInfoList.typHoldInfoList(llngDoCnt - 1).strHoldTime)
                    End If
                    
                    '@保留日(EntryTime)
                    .SetData(llngDoCnt, CMlngvsfLotHoldListColEntryTime, _
                        ltypLotHoldInfoList.typHoldInfoList(llngDoCnt- 1).strEntryTime)
                    
                    '@保留期限
                    If IsDate(ltypLotHoldInfoList.typHoldInfoList(llngDoCnt - 1).strHoldTermDate) Then
                        .SetData(llngDoCnt, CMlngvsfLotHoldListColHoldEDate, _
                        Format$(CDate(ltypLotHoldInfoList.typHoldInfoList(llngDoCnt - 1).strHoldTermDate), CPstrDateTimeMD))
                    Else
                        .SetData(llngDoCnt, CMlngvsfLotHoldListColHoldEDate, _
                        ltypLotHoldInfoList.typHoldInfoList(llngDoCnt - 1).strHoldTermDate)
                    End If

                    '@保留期限(西暦表記)
                    .SetData(llngDoCnt, CMlngvsfLotHoldListColHoldEDateL, _
                        ltypLotHoldInfoList.typHoldInfoList(llngDoCnt - 1).strHoldTermDate)

                    '@保留期間
                    .SetData(llngDoCnt, CMlngvsfLotHoldListColHoldTerm, _
                        Mid(ltypLotHoldInfoList.typHoldInfoList(llngDoCnt - 1).strHoldStayDate, CMlngFormatStart, CMlngFormatMid9))

                    '@保留理由ID
                    .SetData(llngDoCnt, CMlngvsfLotHoldListColHoldReasonID, _
                        ltypLotHoldInfoList.typHoldInfoList(llngDoCnt - 1).strHoldReasonID)

                    '@保留理由名
                    .SetData(llngDoCnt, CMlngvsfLotHoldListColHoldReason, _
                        ltypLotHoldInfoList.typHoldInfoList(llngDoCnt - 1).strHoldReasonName)

                    '@保留責任者ID
                    .SetData(llngDoCnt, CMlngvsfLotHoldListColHoldEmpID, _
                        ltypLotHoldInfoList.typHoldInfoList(llngDoCnt - 1).strHoldEmpID)

                    '@保留責任者名
                    .SetData(llngDoCnt, CMlngvsfLotHoldListColHoldEmpName, _
                        ltypLotHoldInfoList.typHoldInfoList(llngDoCnt - 1).strHoldEmpName)

                    '@保留ｺﾒﾝﾄ
                    .SetData(llngDoCnt, CMlngvsfLotHoldListColHoldComments, _
                        ltypLotHoldInfoList.typHoldInfoList(llngDoCnt - 1).strHoldComment)

                    '@制限ﾌﾗｸﾞ
                    .SetData(llngDoCnt, CMlngvsfLotHoldListColRestrictFlag, _
                        ltypLotHoldInfoList.typHoldInfoList(llngDoCnt - 1).strRestrictFlag)

                    '@ｽﾛｯﾄの高さの設定
                    .Rows(llngDoCnt).Height = CMlngvsfLotHoldListHeight
                    
                    '@起動区分が保留解除の場合
                    If plngfrmxxCM0120Kbn = CMlngHoldRelease Then
                        '@制限ﾌﾗｸﾞが"1"の場合
                        If .GetData(llngDoCnt, CMlngvsfLotHoldListColRestrictFlag) = CMstrRestrictFlag1 Then
                            '@背景色を薄いｸﾞﾚｰ表記へ変更
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                            Dim cellRange As CellRange = .GetCellRange(llngDoCnt, CMlngvsfLotHoldListColNo, _
                                                   llngDoCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        End If
                    End If
                    
                    '@ｶｳﾝﾄのｶｳﾝﾄｱｯﾌﾟ
                    llngDoCnt = llngDoCnt + 1
                Loop
            
                '@ﾌｫﾝﾄ設定
                .Styles.Normal.Font = New Font(.Font.FontFamily, CType(CMlngvsfLotHoldListFontSize, Single), .Font.Style, .Font.Unit) 

                '@列位置の設定
                .Cols(CMlngvsfLotHoldListColNo).TextAlign = TextAlignEnum.RightCenter              '№
                .Cols(CMlngvsfLotHoldListColHoldSDate).TextAlign = TextAlignEnum.LeftCenter        '保留開始日
                .Cols(CMlngvsfLotHoldListColEntryTime).TextAlign = TextAlignEnum.LeftCenter        '保留日(EntryTime)
                .Cols(CMlngvsfLotHoldListColHoldEDate).TextAlign = TextAlignEnum.LeftCenter        '保留期限
                .Cols(CMlngvsfLotHoldListColHoldTerm).TextAlign = TextAlignEnum.LeftCenter         '保留期間
                .Cols(CMlngvsfLotHoldListColHoldReasonID).TextAlign = TextAlignEnum.LeftCenter     '保留理由ID
                .Cols(CMlngvsfLotHoldListColHoldReason).TextAlign = TextAlignEnum.LeftCenter       '保留理由
                .Cols(CMlngvsfLotHoldListColHoldEmpID).TextAlign = TextAlignEnum.LeftCenter        '保留責任者ID
                .Cols(CMlngvsfLotHoldListColHoldEmpName).TextAlign = TextAlignEnum.LeftCenter      '保留責任者
                .Cols(CMlngvsfLotHoldListColHoldComments).TextAlign = TextAlignEnum.LeftCenter     'ｺﾒﾝﾄ内容
                .Cols(CMlngvsfLotHoldListColRestrictFlag).TextAlign = TextAlignEnum.LeftCenter     '制限ﾌﾗｸﾞ
                
                '@列のｵｰﾄｻｲｽﾞ設定
                '.AutoSizeMode = flexAutoSizeColWidth
                .AutoSizeCol(CMlngvsfLotHoldListColNo, 8)                                          '№
                .AutoSizeCol(CMlngvsfLotHoldListColHoldSDate, 6)                                   '保留開始日
                .AutoSizeCol(CMlngvsfLotHoldListColEntryTime, 6)                                   '保留日(EntryTime)
                .AutoSizeCol(CMlngvsfLotHoldListColHoldEDate, 8)                                   '保留期限
                .AutoSizeCol(CMlngvsfLotHoldListColHoldTerm, 6)                                    '保留期間
                .AutoSizeCol(CMlngvsfLotHoldListColHoldReasonID, 6)                                '保留理由ID
                .AutoSizeCol(CMlngvsfLotHoldListColHoldReason, 6)                                  '保留理由
                .AutoSizeCol(CMlngvsfLotHoldListColHoldEmpID, 6)                                   '保留責任者ID
                '.AutoSizeCol(CMlngvsfLotHoldListColHoldEmpName, 6)                                 '保留責任者
                .AutoSizeCol(CMlngvsfLotHoldListColHoldComments, 6)                                'ｺﾒﾝﾄ内容
                .AutoSizeCol(CMlngvsfLotHoldListColRestrictFlag, 6)                                '制限ﾌﾗｸﾞ
                
                '@再描画
                .Redraw = True
                .Row = 0
            
                '@ﾛｯｸ解除
                .Enabled = True
            End With
                
            '@保留情報一覧初期ﾎﾞﾀﾝ設定
            Call pubVsfDisp(vsfLotHoldList, cmdVsfUP, cmdVsfDown)                           'ﾘｽﾄのｽｸﾛｰﾙﾎﾞﾀﾝ
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvvsfLotHoldList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbHoldEmpName_Disp
    '機　能：保留責任者ｺﾝﾎﾞ作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/17 (Thu) 13:19:11 S.Deguchi
    '更新日：2008/06/10 (Tue) 14:16:08 N.Kojima
    '備　考：
    '　　　：2008/06/10 (Tue) 14:16:08 N.Kojima     ｿｰｽ整備。(案件№02884)
    Private Sub prvCmbHoldEmpName_Disp()

        Dim llngCnt     As Integer  '汎用ｶｳﾝﾀ

        Try

            With cmbHoldEmpName
            
                For llngCnt = 0 To mlngEmpListCnt - 1
                    
                    '@ｺﾝﾎﾞ内容設定：保留責任者名/保留責任者ID
                    .AddItem(mtypEmpList(llngCnt).strTechManName _
                           & vbTab _
                           & mtypEmpList(llngCnt).strTechManID)
                Next
                
                '@保留責任者が1件か
                If .ListCount = 1 Then
                
                    '@ﾃﾞﾌｫﾙﾄで表示する
                    .ListIndex = 0
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvCmbHoldEmpName_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnMailConnectInfo_Set
    '機　能：ﾒｰﾙ引継情報の格納処理
    '引　数：なし
    '戻り値：True：成功/False：失敗
    '作成日：2005/11/22 (Tue) 09:00:00 S.Deguchi
    '更新日：2008/06/10 (Tue) 14:11:22 N.Kojima
    '備　考：
    '　　　：2005/12/14 (Wed) 13:16:30 S.Deguchi    技術担当者が空欄の場合にはｱﾄﾞﾚｽ取得処理を行わないように修正
    '　　　：2008/06/10 (Tue) 14:11:22 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Function prvblnMailConnectInfo_Set() As Boolean

        Dim lblnAns                 As Boolean              '登録戻り値(True/False)
        Dim llngCnt                 As Integer              'ｶｳﾝﾄ
        Dim ltypMasRoleEmpListReq   As MasRoleEmpListReq    '職制社員ﾘｽﾄ要求構造体
        Dim ltypMasRoleEmpListAns   As MasRoleEmpListAns    '職制社員ﾘｽﾄ応答構造体
        Dim lblnMailAddressChk      As Boolean              'ﾒｰﾙｱﾄﾞﾚｽﾁｪｯｸ(True：ｱﾄﾞﾚｽ有/False：ｱﾄﾞﾚｽ無)
        Dim llngGetAdoress          As Integer              '取得ｱﾄﾞﾚｽ件数
        Dim lstrAns                 As String               'ｱﾄﾞﾚｽ返却値
        Dim lblnDChkFlag            As Boolean              '重複ﾁｪｯｸﾌﾗｸﾞ
        
        Try

            '@関数初期化
            prvblnMailConnectInfo_Set = False

            '@ﾒｰﾙ引継内容格納
            With ptypMailInfo
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)
                
                '@初期化
                .strMailContents = vbNullString
                .strMailSubject = vbNullString

                '@ﾒｰﾙｱﾄﾞﾚｽﾘｽﾄの初期化
                If ptypSendMailList.typSendMail Is Nothing Then
                    ptypSendMailList.typSendMail = New List(Of SendMail)
                Else
                    ptypSendMailList.typSendMail.Clear()
                End If
                ptypSendMailList.lngSendMailCnt = 0

                '@件名格納：ロット保留(%1)
                .strMailSubject = Replace(CPstrMailSubjectHold, "%1", txtLotID.Text)

                '@本文格納：ロット保留コメント内容
                .strMailContents = txtHoldComment.Text

                '@ｱﾄﾞﾚｽ格納
                '@作業長情報取得引数ｾｯﾄ
                With ltypMasRoleEmpListReq
                    .strMsgVer = CMstrmas_roleemplistVer        'MsgVer
                    .strRole = CPstrRoleForeman                 '職制：作業長
                    .strSbID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ
                End With

                '@作業長情報取得処理
                lblnAns = pubblnMasRoleEmpList_Sel(ltypMasRoleEmpListReq, ltypMasRoleEmpListAns)
                '@結果判定
                If lblnAns = True Then
                '@成功の場合
                    '@初期化
                    lblnMailAddressChk = False
                    
                    '@取得件数でﾙｰﾌﾟを廻し,1件でもｱﾄﾞﾚｽが存在すれば続行
                    For llngCnt = 0 To ltypMasRoleEmpListAns.lngRoleEmpListCnt - 1
                        If ltypMasRoleEmpListAns.typRoleEmpList(llngCnt).strMailAddress <> vbNullString Then
                            '@存在ﾁｪｯｸﾌﾗｸﾞを立てる
                            lblnMailAddressChk = True
                            
                            '@処理抜け
                            Exit For
                        End If
                    Next llngCnt
                    
                    '@存在ﾁｪｯｸから処理分岐
                    If lblnMailAddressChk = False Then
                    '@ｱﾄﾞﾚｽが存在しない場合
                        '@ﾒｯｾｰｼﾞを表示する
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007G, CPstrRoleForeman)
                    
                        '@pubVsfInfo_Disp("[作業長]のメールアドレスが取得できませんでした。")
                        Call pubVsfInfo_Disp(pstrDMsg)
                    Else
                    '@ｱﾄﾞﾚｽが存在する場合
                        '@初期化
                        llngGetAdoress = 0
                        
                        '@ﾙｰﾌﾟを廻してｱﾄﾞﾚｽがある場合のみ領域を確保,情報を格納
                        For llngCnt = 0 To ltypMasRoleEmpListAns.lngRoleEmpListCnt - 1
                            '@ｱﾄﾞﾚｽ存在ﾁｪｯｸ
                            If ltypMasRoleEmpListAns.typRoleEmpList(llngCnt).strMailAddress <> vbNullString Then
                                '@取得件数を格納
                                ptypSendMailList.lngSendMailCnt = ptypSendMailList.lngSendMailCnt + 1
                                llngGetAdoress = ptypSendMailList.lngSendMailCnt
                    
                                '@取得件数分領域を確保
                                Dim typSendMailTmp = New SendMail

                                '@作業長ID
                                typSendMailTmp.strId _
                                    = ltypMasRoleEmpListAns.typRoleEmpList(llngCnt).strEmpID
                
                                '@作業長名
                                typSendMailTmp.strName _
                                    = ltypMasRoleEmpListAns.typRoleEmpList(llngCnt).strEmpName
                
                                '@ﾒｰﾙｱﾄﾞﾚｽ
                                typSendMailTmp.strMail1 _
                                    = ltypMasRoleEmpListAns.typRoleEmpList(llngCnt).strMailAddress
                                ptypSendMailList.typSendMail.Add(typSendMailTmp)
                            End If
                        Next llngCnt
                    End If
                Else
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                    
                    Exit Function
                End If
                
                '@ﾛｯﾄ担当がNULLか
                If mstrLotManagerID = vbNullString Then
                    
                    '@処理なし
                    
                Else
                
                    '@ﾛｯﾄ担当ｱﾄﾞﾚｽ取得
                    lstrAns = pubstrMailAddress_Sel(mstrLotManagerID)
                    
                    '@結果判定
                    If lstrAns = vbNullString Then
                        '@成功の場合
                        
                        '@ｱﾄﾞﾚｽが存在していない場合
                        '@ﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000Z, CMstrLotManager, lblLotManager.Text)
            
                        '@pubVsfInfo_Disp("[△△ ○○]のメールアドレスが取得できませんでした。")
                        Call pubVsfInfo_Disp(pstrDMsg)
                    Else
                    '@ｱﾄﾞﾚｽ取得できた場合
                        '@既に格納されたｱﾄﾞﾚｽでない場合のみ格納
                        lblnDChkFlag = False
                        For llngCnt = 0 To ptypSendMailList.lngSendMailCnt - 1
                            If lstrAns = ptypSendMailList.typSendMail(llngCnt).strMail1 Then
                                lblnDChkFlag = True
                                
                                Exit For
                            End If
                        Next llngCnt
                        
                        If lblnDChkFlag = False Then
                            '@領域の件数を増やす
                            ptypSendMailList.lngSendMailCnt = ptypSendMailList.lngSendMailCnt + 1
                
                            '@領域確保
                            Dim typSendMailTmp = New SendMail
                
                            '@ﾛｯﾄ担当者ID
                            typSendMailTmp.strId = mstrLotManagerID
                
                            '@ﾛｯﾄ担当
                            typSendMailTmp.strName = lblLotManager.Text
                
                            '@ﾒｰﾙｱﾄﾞﾚｽ
                            typSendMailTmp.strMail1 = lstrAns
                            ptypSendMailList.typSendMail.Add(typSendMailTmp)
                        End If
                    End If
                End If
                
                If mstrHoldEmpID = vbNullString Then
                    '@保留責任者IDがNullの場合には処理ｽｷｯﾌﾟ：本来ありえない
                    
                Else
                    '@保留責任者ｱﾄﾞﾚｽ取得
                    lstrAns = pubstrMailAddress_Sel(mstrHoldEmpID)
                    '@結果判定
                    If lstrAns = vbNullString Then
                    '@成功の場合
                        '@ｱﾄﾞﾚｽが存在していない場合
                        '@ﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000Z, CMstrHold, cmbHoldEmpName.Text)
            
                        '@pubVsfInfo_Disp("[△△ ○○]のメールアドレスが取得できませんでした。")
                        Call pubVsfInfo_Disp(pstrDMsg)
                    Else
                    '@ｱﾄﾞﾚｽ取得できた場合
                        '@既に格納されたｱﾄﾞﾚｽでない場合のみ格納
                        lblnDChkFlag = False
                        For llngCnt = 0 To ptypSendMailList.lngSendMailCnt - 1
                            If lstrAns = ptypSendMailList.typSendMail(llngCnt).strMail1 Then
                                lblnDChkFlag = True
                                
                                Exit For
                            End If
                        Next llngCnt
                        
                        If lblnDChkFlag = False Then
                            '@領域の件数を増やす
                            ptypSendMailList.lngSendMailCnt = ptypSendMailList.lngSendMailCnt + 1
                
                            '@領域確保
                            Dim typSendMailTmp = New SendMail
                
                            '@作業者ID
                            typSendMailTmp.strId = mstrHoldEmpID
                
                            '@作業者名
                            typSendMailTmp.strName = cmbHoldEmpName.Text
                
                            '@ﾒｰﾙｱﾄﾞﾚｽ
                            typSendMailTmp.strMail1 = lstrAns
                            ptypSendMailList.typSendMail.Add(typSendMailTmp)
                        End If
                    End If
                End If
            End With

            '@成功を返す
            prvblnMailConnectInfo_Set = True

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvblnMailConnectInfo_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnLotHold_Proc
    '機　能：保留処理
    '引　数：なし
    '戻り値：True：成功/False：失敗
    '作成日：2005/11/22 (Tue) 09:23:12 S.Deguchi
    '更新日：2005/11/22 (Tue) 09:23:12
    '備　考：
    Private Function prvblnLotHold_Proc() As Boolean

        Dim lblnAns                 As Boolean              '登録戻り値(True/False)
        Dim ltypLotHoldset          As LotHoldset           'ﾛｯﾄ保留設定要求格納用
        Dim lstrMailTemp            As String               'ﾒｰﾙ本文作成用退避領域
        Dim lstrAns                 As String               'ﾒｰﾙｱﾄﾞﾚｽ取得
        
        Try

            '@初期化
            prvblnLotHold_Proc = False
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)

            '@作業者IDからﾒｰﾙｱﾄﾞﾚｽ取得処理
            lstrAns = pubstrMailAddress_Sel(ptypSendMessageList.strSendEmpID)
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
                Dim typMailListTmp = New MailList

                '@ﾒｰﾙｱﾄﾞﾚｽ
                typMailListTmp.strMailAddress = lstrAns
                ptypSendMessageList.typMailList.Add(typMailListTmp)
            End If

            '@ﾛｯﾄ保留設定ﾃﾞｰﾀ作成
            With ltypLotHoldset
                .strLotID = txtLotID.Text                               'ﾛｯﾄID
                .strHoldReasonID = cmbMasHold.Value                     '保留理由ID
                .strHoldComment = txtHoldComment.Text                   '保留ｺﾒﾝﾄ
                
                If dtpHoldTermDate.Value <> CPstrNullDate Then          '保留期限
                    .strHoldTermDate = dtpHoldTermDate.Value
                Else
                    .strHoldTermDate = vbNullString
                End If
                
                .strHoldEmpID = mstrHoldEmpID                           '保留責任者ID
                .strEmpID = ptypSendMessageList.strSendEmpID            '作業者ID
                .strLotLastUpdate = mstrLotLastUpdate                   'ﾛｯﾄ最終更新日時
            End With

            '@保留処理実行
            lblnAns = pubblnLotHold_Ins(CMstrlot_hold____Ver, ltypLotHoldset)
            '@結果判定
            If lblnAns = True Then
            '@成功の場合
                '@成功ﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0008, txtCarrierID.Text, txtLotID.Text)

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
                lstrMailTemp = CPstrMailSENDER & ptypSendMessageList.strSendEmpName & vbCrLf & _
                               CPstrMailLOT & txtLotID.Text & vbCrLf & _
                               CPstrMailPDID & lblPdID.Text & vbCrLf & _
                               CPstrMailOPID & lblOpID.Text & vbCrLf & _
                               CPstrMailSTEPID & lblStepID.Text & vbCrLf & _
                               CPstrMailHOLDREASON & cmbMasHold.Text & vbCrLf & _
                               CPstrMailSENDDATE & Format(CDate(ltypLotHoldset.strHoldEditTime), CPstrDateTimeYMDHMS) & vbCrLf & _
                               CPstrMailHOLDTERMDATE & Format(CDate(dtpHoldTermDate.Value), CPstrDateTimeYMD) & vbCrLf & _
                               CPstrMailHOLDComments & vbCrLf & _
                               ptypSendMessageList.strMailContents

                '@ﾒｰﾙ本文差換
                ptypSendMessageList.strMailContents = lstrMailTemp

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
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvblnLotHold_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnLotHoldCancel_Proc
    '機　能：保留解除処理
    '引　数：なし
    '戻り値：True：成功/False：失敗
    '作成日：2005/11/22 (Tue) 09:56:05 S.Deguchi
    '更新日：2005/11/22 (Tue) 09:56:05
    '備　考：
    Private Function prvblnLotHoldCancel_Proc() As Boolean

        Dim lblnAns                 As Boolean              '登録戻り値(True/False)
        Dim lstrFunctionID          As String               '機能ID
        Dim lstrActionID            As String               'ｱｸｼｮﾝID
        Dim lstrEmpID               As String               '作業者ID
        Dim lstrEmpName             As String               '作業者名
        Dim lstrSBID                As String               'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim ltypLotHoldRelesset     As LotHoldRelesset      'ﾛｯﾄ保留解除要求格納用
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance        As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg

        Try

            '@初期化
            prvblnLotHoldCancel_Proc = False
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)
            
            '@保留理由により，実行権限のﾁｪｯｸを行う(リワーク)
            With vsfLotHoldList
                If .GetData(.Row, CMlngvsfLotHoldListColHoldReasonID) = CPstrReworkReasonCode Then
                    '@実行権限の処理
                    lstrFunctionID = CPstrKeyEN00A0                 '機能ID：EN00A0
                    lstrActionID = CPstrReworkHoldCancel            'ｱｸｼｮﾝID：ﾘﾜｰｸ保留解除
                    lstrEmpID = pstrUserID                          'ﾕｰｻﾞｰID
                    lstrEmpName = pstrUserName                      'ﾕｰｻﾞｰ名
                    lstrSBID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸ
            
                    '@実行権限ﾁｪｯｸ
                    lblnAns = pubAuthority_Chk(lstrFunctionID, lstrActionID, lstrEmpID, lstrEmpName, lstrSBID)
                    '@結果判定
                    If lblnAns = False Then
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
            
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, CPstrReworkHoldCancel)
                        
                        '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            
                        Exit Function
                    End If
                End If
            End With

            '@ﾛｯﾄ保留解除ﾃﾞｰﾀ作成
            With ltypLotHoldRelesset
                .strLotID = txtLotID.Text                               'ﾛｯﾄID
                .strHoldReleseComment = txtHoldComment.Text             '保留解除ｺﾒﾝﾄ
                .strEmpID = pstrUserID                                  '作業者ID
                .strLotLastUpdate = mstrLotLastUpdate                   'ﾛｯﾄ最終更新日時
                
                '@登録日時
                .strEntryTime = vsfLotHoldList.GetData(vsfLotHoldList.Row, _
                                                    CMlngvsfLotHoldListColEntryTime)
            End With
                
            '@ﾒｯｾｰｼﾞ送信処理呼び出し(保留解除)
            lblnAns = pubblnLotReleaseHold_Upd(CMstrlot_holdreleaseVer, _
                                               ltypLotHoldRelesset, _
                                               lstrGuidMsg, _
                                               lstrGuidMsgCode)
            '@結果判定
            If lblnAns = True Then
                '@ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞに値が入っている場合
                If lstrGuidMsgCode <> vbNullString Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                    
                    '@表示ｶﾞｲﾀﾞﾝｽMsgの編集("【警告】" & "$$" & "ｶﾞｲﾀﾞﾝｽｺｰﾄﾞ[CODE]">" & "$$" & ｶﾞｲﾀﾞﾝｽMsg)
                    lstrEditGuidance = CPstrWarMsgCode & CPstrGuidanceMsg & CPstrMsgCrCode & _
                                       CPstrGuidanceCode & CPstrBracketLeft & lstrGuidMsgCode & CPstrBracketRight & _
                                       CPstrMsgCrCode & lstrGuidMsg

                    '@ﾒｯｾｰｼﾞ表示"編集済みｶﾞｲﾀﾞﾝｽMsg"
                    pstrDMsg = pubstrMsgReplace_Set(lstrEditGuidance)
                    
                    '@ﾒｯｾｰｼﾞ表示
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                End If
            
                '@成功ﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0009, txtCarrierID.Text, txtLotID.Text)

                '@pubVsfInfo_Disp("メッセージコード：C_I09%0$$ロット[ %2 ]を保留解除しました。キャリア[ %1 ]")
                Call pubVsfInfo_Disp(pstrDMsg)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                
                Exit Function
            End If

            '@成功を返す
            prvblnLotHoldCancel_Proc = True

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = mstrLocalMenuKey
                .strProcName = "prvblnLotHoldCancel_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function
    '@↑2005/11/22 (Tue) 09:56:05 S.Deguchi **************************************************



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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraHoldList.Paint, fraHoldSet.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub

    '関数名：cursor_Enter
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考：Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles cmdHoldTxtUp.Enter,
                                                                       cmdHoldTxtDown.Enter,
                                                                       cmbMasHold.Enter,
                                                                       cmbHoldEmpName.Enter,
                                                                       txtHoldComment.Enter,
                                                                       txtCarrierID.Enter,
                                                                       cmdClose.Enter,
                                                                       cmdRegist.Enter,
                                                                       txtLotID.Enter,
                                                                       cmdVsfUP.Enter,
                                                                       cmdVsfDown.Enter,
                                                                       cmdTxtDown.Enter,
                                                                       cmdTxtUp.Enter,
                                                                       txtHoldCommentView.Enter,
                                                                       dtpHoldTermDate.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '閉じるボタンの場合は自動Validate = OFF
            Case "cmdClose"
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
            '上記以外は自動Validate = ON
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

End Class
