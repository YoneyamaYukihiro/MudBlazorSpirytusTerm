'ﾌｧｲﾙ名：xxEN02N0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：バッチ編成設定メインフォーム
'作成日：2017/06/20 (Tue) 14:48:24 Y.Yoneyama
'更新日：2017/06/20 (Tue) 14:48:24 Y.Yoneyama
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2016, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02N0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02N0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02N0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02N0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02N0)
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
    Private Const CMstrLocalVersion                 As String = "01.00"

    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_McGrouplistVer           As String = "01.00"                     '装置ｸﾞﾙｰﾌﾟ取得
    Private Const CMstrmas_wplist__Ver              As String = "05.01"                     '装置一覧取得
    Private Const CMstrbat_composestatusVer         As String = "01.00"                     'ﾊﾞｯﾁ編成設定取得
    Private Const CMstrbat_recipelistVer            As String = "01.00"                     'ﾊﾞｯﾁﾚｼﾋﾟ一覧取得
    Private Const CMstrbat_composeregistVer         As String = "01.00"                     'ﾊﾞｯﾁ編成設定
    Private Const CMstrbat_waitinglotlistVer        As String = "01.00"                     'ﾊﾞｯﾁ装置待ちﾛｯﾄ一覧
    Private Const CMstreq__state___Ver              As String = "03.00"                     '装置状態取得

    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN02N0              'ﾛｰｶﾙ機能ID

    '@ﾌﾚｯｸｽｸﾞﾘｯﾄﾞのｶﾗﾑ定数
    Private Const CMlngGridTitleHeight              As Integer = 67                         'ﾀｲﾄﾙの高さ
    Private Const CMlngGridRowHeight                As Integer = 40                         '1明細の高さ
    Private Const CMlngGridTitleCol                 As Integer = 0                          'ﾀｲﾄﾙ列
    Private Const CMlngGridRowHeightLot             As Integer = 20                         '1明細の高さ

    '@ﾚｼﾋﾟ列定義
    Private Const CMlngvsfRecipeSeqNum              As Integer = 0                          '処理順
    Private Const CMlngvsfRecipeType                As Integer = 1                          '種別
    Private Const CMlngvsfRecipeId                  As Integer = 2                          'ﾊﾞｯﾁ自動編成ﾚｼﾋﾟ
    Private Const CMlngvsfRecipeWfNum               As Integer = 3                          '枚数設定 WF枚数
    Private Const CMlngvsfRecipeTimeNum             As Integer = 4                          '時間設定 時間(H)
    Private Const CMlngvsfRecipeTimeWfNum           As Integer = 5                          '時間設定 WF枚数
    Private Const CMlngvsfRecipeEditTime            As Integer = 6                          '最終更新日時
    Private Const CMlngvsfRecipeEmpName             As Integer = 7                          '最終更新者

    '@ﾚｼﾋﾟﾀｲﾄﾙ定義
    Private Const CMstrvsfRecipeSeqNumT             As String = "順"
    Private Const CMstrvsfRecipeTypeT               As String = "種別"
    Private Const CMstrvsfRecipeIdT                 As String = "バッチ自動編成" + vbCrLf + "レシピ"
    Private Const CMstrvsfRecipeWfNumT              As String = "枚数設定" + vbCrLf + "WF[枚]≧"
    Private Const CMstrvsfRecipeTimeNumT            As String = "時間設定" + vbCrLf + "時間[H]≧"
    Private Const CMstrvsfRecipeTimeWfNumT          As String = "時間設定" + vbCrLf + "WF[枚]≧"
    Private Const CMstrvsfReicpeEditTimeT           As String = "最終更新日時"
    Private Const CMstrvsfRecipeEmpNameT            As String = "最終更新者"

    '@ﾛｯﾄ列定義
    Private Const CMlngvsfLotNo                     As Integer = 0                          'No
    Private Const CMlngvsfLotPriority               As Integer = 1                          '優先度
    Private Const CMlngvsfLotID                     As Integer = 2                          'ﾛｯﾄID
    Private Const CMlngvsfRecipeIdB                 As Integer = 3                          'ﾚｼﾋﾟID
    Private Const CMlngvsfFlowClass                 As Integer = 4                          '種別
    Private Const CMlngvsfWfQty                     As Integer = 5                          'WF枚数
    Private Const CMlngvsfWaitTimeH                 As Integer = 6                          '待ち時間(H)
    Private Const CMlngvsfCarrierId                 As Integer = 7                          'ｷｬﾘｱID
    Private Const CMlngvsfCarrierPos                As Integer = 8                          'ｷｬﾘｱ位置
    Private Const CMlngvsfOpId                      As Integer = 9                          '大工程
    Private Const CMlngvsfStepId                    As Integer = 10                         '小工程

    '@ﾛｯﾄﾀｲﾄﾙ定義
    Private Const CMstrvsfLotNoT                    As String = "№"                        'No
    Private Const CMstrvsfLotPriorityT              As String = "優"                        '優先度
    Private Const CMstrvsfLotIdT                    As String = "ﾛｯﾄID"                     'ﾛｯﾄID
    Private Const CMstrvsfRecipeIdBT                As String = "ﾚｼﾋﾟ"                      'ﾚｼﾋﾟID
    Private Const CMstrvsfFlowClassT                As String = "種"                        '種別
    Private Const CMstrvsfWfQtyT                    As String = "WF"                        'WF枚数
    Private Const CMstrvsfWaitTimeHT                As String = "待時間[H]"                 '待ち時間(H)
    Private Const CMstrvsfCarrierIdT                As String = "ｷｬﾘｱID"                    'ｷｬﾘｱID
    Private Const CMstrvsfCarrierPosT               As String = "ｷｬﾘｱ位置"                  'ｷｬﾘｱ位置
    Private Const CMstrvsfOpIdT                     As String = "大工程"                    '大工程
    Private Const CMstrvsfStepIdT                   As String = "小工程"                    '小工程

    '@その他
    Private Const CMstrRecipeNone                   As String = "未設定"                    '未設定
    Private Const CMstrRecipeProduct                As String = "製品"                      '製品ﾚｼﾋﾟ
    Private Const CMstrRecipeGasClean               As String = "ｶﾞｽｸﾘｰﾆﾝｸﾞ"                'ｶﾞｽｸﾘｰﾆﾝｸﾞﾚｼﾋﾟ
    Private Const CMstrRecipePreCort                As String = "ﾌﾟﾘｺｰﾄ"                    'ﾌﾟﾘｺｰﾄﾚｼﾋﾟ

    Private Const CMstrRecipeNoneNum                As String = "0"                         '未設定
    Private Const CMstrRecipeProductNum             As String = "1"                         '製品ﾚｼﾋﾟ"
    Private Const CMstrRecipeGasCleanNum            As String = "2"                         'ｶﾞｽｸﾘｰﾆﾝｸﾞﾚｼﾋﾟ"
    Private Const CMstrRecipePreCortNum             As String = "3"                         'ﾌﾟﾘｺｰﾄﾚｼﾋﾟ
            
    Private Const CMlngRecipeNoneNum                As Integer = 0                          '未設定
    Private Const CMlngRecipeProductNum             As Integer = 1                          '製品ﾚｼﾋﾟ"
    Private Const CMlngRecipeGasCleanNum            As Integer = 2                          'ｶﾞｽｸﾘｰﾆﾝｸﾞﾚｼﾋﾟ"
    Private Const CMlngRecipePreCortNum             As Integer = 3                          'ﾌﾟﾘｺｰﾄﾚｼﾋﾟ

    Private Const CMstrColon                        As String = ":"                         'ｺﾛﾝ

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                  As Integer = 14                         'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 14                         'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColName               As Integer = 0                          '名称列番
    Private Const CMlngCmbGridColID                 As Integer = 1                          'ID列番(非表示項目)
    Private Const CMlngCmbDispCols                  As Integer = 1                          'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbRowHeight                 As Integer = 43                         'ﾘｽﾄ行の高さ
    Private Const CMlngCmbWpNameName                As Integer = 0                          '装置名ｺﾝﾎﾞの名前列
    Private Const CMlngCmbWpNameId                  As Integer = 1                          '装置名ｺﾝﾎﾞのID列
    Private Const CMlngCmbWpNameMaxProcessBox       As Integer = 2                          '装置名ｺﾝﾎﾞの最大処理単位ﾎﾞｯｸｽ数列
    Private Const CMlngCmbWpNameMesModeID           As Integer = 3                          '装置名ｺﾝﾎﾞの運用ﾓｰﾄﾞ列
    Private Const CMlngCmbWpNameEqType              As Integer = 4                          '装置名ｺﾝﾎﾞの装置ﾀｲﾌﾟ(EqType)列

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mstrRecipeCmbStr(3)                     As String                               '製品、ｶﾞｽｸﾘｰﾆﾝｸﾞ、ﾌﾟﾘｺｰﾄ
    Private mtypPreviousBatchComposeStatus          As BatComposeStatus
    Private mstrTimeNumItem                         As String
    Private mlngMaxProcessQuantity                  As Integer

    '@装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄ構造体
    Private mtypMcGpLotInfo                         As McGpLotInfo                          '装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄ構造体

    '@配列定義
    Private mtypWpList()                            As WpList                               'WPﾘｽﾄ
    Private mlngWpListCnt                           As Integer                              'WPﾘｽﾄ数

    '@その他
    Private mstrOldMcGroupID                        As String                               '前回ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟID格納
    Private mlngOldcmbWpNameIndex                   As Integer                              '前回装置名ｺﾝﾎﾞINDEX
    Private mblnInEditKbn                           As Boolean                              '編集中区分(True:編集中、False:未編集)
    Private mblnFirstActivateFlag                   As Boolean                              '初回ﾌｫｰﾑｱｸﾃｨﾌﾞ判定ﾌﾗｸﾞ(True：初回、False：2回目以降)

    Private buttonProcessing                        As Boolean                              'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                              'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                              'NSYS WindowCloseフラグ
    Private mintvsfLotBeforeSortRow                 As Integer                              'NSYS ロット一覧グリッドのソート前行保持

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
    '作成日：2017/06/19 (Mon) 14:41:51 Y.Yoneyama
    '更新日：2017/06/19 (Mon) 14:41:51 Y.Yoneyama
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns             As Boolean          '結果格納
        Dim ltypMcGroupList     As McGroupList      '装置ｸﾞﾙｰﾌﾟ格納構造体

        Try

            '@=======================
            '@ 機能ﾊﾞｰｼﾞｮﾝ判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN02N0, CMstrLocalVersion)

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
                Call Form_QueryUnload(Me, New FormClosingEventArgs(CloseReason.UserClosing,  False))

                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart("frmxxEN02N0", "Form_Load")

            '@=======================
            '@ ﾌｫｰﾑ初期化処理
            '@=======================
            Call prvFrmxxEN02N0_Init()

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
                Call pubResponseCancel("frmxxEN02N0", "Form_Load")
                Exit Sub
            End If

            '@=======================
            '@ 装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞの設定
            '@=======================
            Call prvCmbMcGroup_Disp(ltypMcGroupList)

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd("frmxxEN02N0", "Form_Load")


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
    '作成日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '更新日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@初回ﾌｫｰﾑｱｸﾃｨﾌﾞ判定ﾌﾗｸﾞが"True：初回"か
            If mblnFirstActivateFlag = True Then
                '@初回の場合

                '@2回目以降は処理させない為にﾌﾗｸﾞに"False：2回目以降"をｾｯﾄ
                mblnFirstActivateFlag = False

                '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞのﾘｽﾄ内容が1件か
                If cmbMcGroup.ListCount = 1 Then

                    '@1件の場合は自動表示する
                    cmbMcGroup.ListIndex = 0

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
    '作成日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '更新日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name

                '@〓 [ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ 〓
                Case cmbMcGroup.Name

                    '@Enterｷｰか
                    If e.KeyCode = Keys.Return Then

                        '@=======================
                        '@ ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞのValidate処理
                        '@=======================
                        RemoveHandler cmbMcGroup.Validating, AddressOf cmbMcGroup_Validate
                        Call cmbMcGroup_Validate(cmbMcGroup, New CancelEventArgs(True))
                        AddHandler cmbMcGroup.Validating, AddressOf cmbMcGroup_Validate

                    End If

                '@〓 その他 〓
                Case Else

                    '@Enterの場合
                    If e.KeyCode = Keys.Return Then

                        If ActiveControl IsNot vsfRecipe.Editor Then
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
    '作成日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '更新日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm                 As Boolean              'ACT開放結果格納用
        Dim ltypMcGpLotInfo             As McGpLotInfo          '装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄ構造体

        Try            

            '@Windowの"×"にて閉じたか
            If mblnCloseFromControlMenu Then

                '@=======================
                '@ 閉じるﾎﾞﾀﾝ処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs())
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload

            End If

            '@ﾓｼﾞｭｰﾙ変数/構造体の初期化
            Erase mtypWpList
            mlngWpListCnt = 0
            mtypMcGpLotInfo = ltypMcGpLotInfo                   '装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄ構造体

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

    '関数名：cmbBatchCompse_CloseUp
    '機　能：[ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '更新日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '備　考：
    Private Sub cmbBatchCompse_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBatchCompse.CloseUp
        
        
        Try

            '@=======================
            '@ ﾊﾞｯﾁ装置ｺﾝﾎﾞのValidate処理
            '@=======================
            RemoveHandler cmbBatchCompse.Validating, AddressOf cmbBatchCompse_Validate
            Call cmbBatchCompse_Validate(cmbBatchCompse, New CancelEventArgs(True))
            AddHandler cmbBatchCompse.Validating, AddressOf cmbBatchCompse_Validate

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbBatchCompse_CloseUp"     'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbBatchCompse_Validate
    '機　能：[ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ　選択確定時処理(Validate処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '更新日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '備　考：
    Private Sub cmbBatchCompse_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbBatchCompse.Validating

        'NSYS 画面を閉じる場合は処理を抜ける
        If mblnWindowClose = True Then
            Exit Sub
        End If

        '@=======================
        '@ 前回ﾃﾞｰﾀ比較
        '@=======================
        Call prvPreviousData_Chk()
        
        If cmdKakutei.Enabled = True AndAlso _
            ActiveControl Is cmbBatchCompse Then
            Call pubSetFocus(cmdKakutei)
        End If
        
        Exit Sub

    Error_Handler:

        '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
        With ptypOnErrorInfo
            .strMenuKey = CMstrLocalMenuKey             '機能ID
            .strProcName = "cmbBatchCompse_Validate"    'ﾌﾟﾛｼｰｼﾞｬ名
            .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
        End With

        '@=======================
        '@ 共通ｴﾗｰ処理
        '@=======================
        Call pubOnError_Proc()

    End Sub

    '関数名：cmbMcGroup_Change
    '機　能：[ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '更新日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '備　考：
    Private Sub cmbMcGroup_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGroup.Change

        Try

            '@=======================
            '@ ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ内容の初期化
            '@=======================
            Call prvDisplay_Init()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbMcGroup_Change"          'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGroup_CloseUp
    '機　能：[ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '更新日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '備　考：
    Private Sub cmbMcGroup_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMcGroup.CloseUp

        Try

            '@=======================
            '@ ﾊﾞｯﾁ装置ｺﾝﾎﾞのValidate処理
            '@=======================
            RemoveHandler cmbMcGroup.Validating, AddressOf cmbMcGroup_Validate
            Call cmbMcGroup_Validate(cmbMcGroup, New CancelEventArgs(True))
            AddHandler cmbMcGroup.Validating, AddressOf cmbMcGroup_Validate

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbMcGroup_CloseUp"        'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMcGroup_Validate
    '機　能：[ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞ　選択確定時処理(Validate処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '更新日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '備　考：
    Private Sub cmbMcGroup_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbMcGroup.Validating

        Dim lblnNextCtrl As Boolean 'NSYS Focus設定フラグ

        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If ActiveControl Is cmbMcGroup Then
                lblnNextCtrl = True
            Else
                lblnNextCtrl = False
            End If

            '@[ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ]ｺﾝﾎﾞが未選択か
            If cmbMcGroup.Text = vbNullString Then

                '@ﾊﾞｯﾁ編成ﾌﾚｰﾑの[装置名]ｺﾝﾎﾞが有効か
                If cmbWpName.Enabled = True Then

                    '@[装置名]ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    If lblnNextCtrl Then
                        Call pubSetFocus(cmbWpName)
                    End If
                Else
                    '@[閉じる]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    If lblnNextCtrl Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If

                Exit Sub
            End If


            '@前回選択のﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟIDと今回選択IDが同じか
            If cmbMcGroup.Value = mstrOldMcGroupID Then
                '@同じ場合

                '@[装置名]ｺﾝﾎﾞが有効か
                If cmbWpName.Enabled = True Then

                    '@[装置名]ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                    If lblnNextCtrl Then
                        Call pubSetFocus(cmbWpName)
                    End If
                Else

                    '@[閉じる]ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    If lblnNextCtrl Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If

                Exit Sub
            End If

            '@=======================
            '@ 装置一覧取得
            '@=======================
            Call prvWpList_Sel()
            
            '@ﾃﾞｰﾀ待避
            mstrOldMcGroupID = cmbMcGroup.Value
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbMcGroup_Validate"       'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRecipe_AfterEdit
    '機　能：ｶﾚﾝﾄ行列変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '更新日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '備　考：
    Private Sub vsfRecipe_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfRecipe.AfterEdit
        
        'NSYS 画面を閉じる場合は処理を抜ける
        If mblnWindowClose = True Then
            Exit Sub
        End If

        '@=======================
        '@ 前回ﾃﾞｰﾀ比較
        '@=======================
        Call prvPreviousData_Chk()
        
        If cmdKakutei.Enabled = True Then
            Call pubSetFocus(cmdKakutei)
        End If
        
        Exit Sub

    Error_Handler:

        '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
        With ptypOnErrorInfo
            .strMenuKey = CMstrLocalMenuKey             '機能ID
            .strProcName = "vsfRecipe_AfterEdit"        'ﾌﾟﾛｼｰｼﾞｬ名
            .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
        End With

        '@=======================
        '@ 共通ｴﾗｰ処理
        '@=======================
        Call pubOnError_Proc()

    End Sub

    '関数名：vsfRecipe_EnterCell
    '機　能：ｶﾚﾝﾄ行列変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '更新日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '備　考：
    Private Sub vsfRecipe_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfRecipe.EnterCell

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfRecipe.Rows.Count <= vsfRecipe.Rows.Fixed Then
                Return
            End If

            With vsfRecipe

                '@対象行がﾍｯﾀﾞ以外の場合
                If .Row < .Rows.Fixed Then
                    Exit Sub
                End If
         
                '@ﾚｼﾋﾟﾀｲﾌﾟが未設定の場合は編集不可
                If vsfRecipe.GetData(.Row, CMlngvsfRecipeType) = CMstrRecipeNone Then
                    '@編集不可
                    .AllowEditing = False
                    Exit Sub
                End If
                
                '@★ 対象列により処理分岐 ★
                Select Case .Col

                    '@ﾚｼﾋﾟ
                    Case CMlngvsfRecipeId
                        
                        Select Case vsfRecipe.GetData(.Row, CMlngvsfRecipeType)
                        
                            Case CMstrRecipeProduct
                                '@ｸﾞﾘｯﾄﾞｺﾝﾎﾞ作成
                                .Cols(CMlngvsfRecipeId).ComboList = mstrRecipeCmbStr(CMlngRecipeProductNum)
                            
                            Case CMstrRecipeGasClean
                                '@ｸﾞﾘｯﾄﾞｺﾝﾎﾞ作成
                                .Cols(CMlngvsfRecipeId).ComboList = mstrRecipeCmbStr(CMlngRecipeGasCleanNum)
                            
                            Case CMstrRecipePreCort
                                '@ｸﾞﾘｯﾄﾞｺﾝﾎﾞ作成
                                .Cols(CMlngvsfRecipeId).ComboList = mstrRecipeCmbStr(CMlngRecipePreCortNum)
                            
                            Case Else
                                Exit Sub
                        End Select
                        
                        '@ｸﾞﾘｯﾄﾞを編集可能にする
                        .AllowEditing = True
                        
                    '@WF枚数設定
                    Case CMlngvsfRecipeWfNum
                        
                        '@ｸﾞﾘｯﾄﾞを編集可能にする
                        .AllowEditing = True
                        
                    '@時間設定
                    Case CMlngvsfRecipeTimeNum
                        
                        '@ｸﾞﾘｯﾄﾞｺﾝﾎﾞ作成
                        .Cols(CMlngvsfRecipeTimeNum).ComboList = mstrTimeNumItem
                    
                        '@ｸﾞﾘｯﾄﾞを編集可能にする
                        .AllowEditing = True
                        
                    '@時間WF枚数設定
                    Case CMlngvsfRecipeTimeWfNum
                        
                        '@ｸﾞﾘｯﾄﾞを編集可能にする
                        .AllowEditing = True

                    '@その他
                    Case Else

                        '@編集不可
                        .AllowEditing = False

                End Select

            End With


            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfRecipe_EnterCell"        'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRecipe_KeyPressEdit
    '機　能：[ﾚｼﾋﾟ一覧]ｸﾞﾘｯﾄﾞ　ｷｰ押下時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：未使用
    '戻り値：なし
    '作成日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '更新日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    Private Sub vsfRecipe_KeyPressEdit(ByVal sender As Object, ByVal e As KeyPressEditEventArgs) Handles vsfRecipe.KeyPressEdit
        
        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfRecipe.Rows.Count <= vsfRecipe.Rows.Fixed Then
                Return
            End If

            With vsfRecipe

                '@選択行がﾀｲﾄﾙ行以外か
                If .Row > 0 Then

                    Select Case .Col

                        Case CMlngvsfRecipeWfNum, CMlngvsfRecipeTimeWfNum

                            '@★★ 入力文字のAsciiｺｰﾄﾞにより処理分岐 ★★
                            Select Case Asc(e.KeyChar)

                                '@〓〓 半角数字(左記の種類のみ入力可) 〓〓
                                Case CPlngKeyAsciiNum0 To CPlngKeyAsciiNum9, CPlngKeyBackSpace, CPlngKeyReturn

                                    '@処理なし

                                '@〓〓 その他 〓〓
                                Case Else

                                    '@ｷｰを無効にする
                                    e.Handled = True

                            End Select

                        Case Else

                            '@★★ ｷｰｺｰﾄﾞにより処理分岐 ★★
                            Select Case Asc(e.KeyChar)

                                '@〓〓 ｽﾍﾟｰｽ 〓〓
                                Case Keys.Space

                                    '@ｷｰを無効にする
                                    e.Handled = True

                                    '@対象ｾﾙを編集状態にする
                                    .Select(.Row, .Col)
                                    .StartEditing()

                                '@〓〓 [↑]、[↓]、[←]、[→]、[Shift]、[Ctrl] 〓〓
                                Case Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.Shift, Keys.Control

                                    '@処理なし

                                Case Else

                                    '@対象ｾﾙを編集状態にする
                                    .Select(.Row, .Col)
                                    .StartEditing()

                            End Select

                    End Select
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfRecipe_KeyPressEdit"     'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRecipe_Leave
    '機　能：ﾚｼﾋﾟｸﾞﾘｯﾄﾞﾌｫｰｶｽｱｳﾄ処理
    '引　数：sender：ｲﾍﾞﾝﾄ発生元
    '　　　：e     ：ｲﾍﾞﾝﾄｵﾌﾞｼﾞｪｸﾄ
    '戻り値：なし
    '作成日：2020/05/20 (Wed) NSYS
    '備　考：
    Private Sub vsfRecipe_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles vsfRecipe.Leave

        Try
            'フォーカスアウト時に編集モードを抜ける
            With CType(sender, C1FlexGrid)
                .AllowEditing = False
            End With

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfRecipe_Leave"            'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try

    End Sub

    '関数名：vsfRecipe_KeyDown
    '機　能：ﾚｼﾋﾟｸﾞﾘｯﾄﾞｷｰﾀﾞｳﾝ処理
    '引　数：sender：ｲﾍﾞﾝﾄ発生元
    '　　　：e     ：ｲﾍﾞﾝﾄｵﾌﾞｼﾞｪｸﾄ
    '戻り値：なし
    '作成日：2020/05/20 (Wed) NSYS
    '備　考：
    Private Sub vsfRecipe_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles vsfRecipe.KeyDown
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfRecipe.Rows.Count <= vsfRecipe.Rows.Fixed Then
                Return
            End If

            With vsfRecipe
                '@ﾚｼﾋﾟﾀｲﾌﾟが未設定以外の場合
                If .Row >= .Rows.Fixed AndAlso .GetData(.Row, CMlngvsfRecipeType) <> CMstrRecipeNone Then
                    '@ﾚｼﾋﾟ、時間設定
                    If .Col = CMlngvsfRecipeId OrElse _
                        .Col = CMlngvsfRecipeTimeNum Then
                        '@Enter、矢印Keyは制御外
                        Select Case e.KeyCode
                            Case Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.Return, Keys.ShiftKey, Keys.ControlKey
                                Exit Sub
                            Case Keys.F2, Keys.Space
                                e.SuppressKeyPress = True
                                .StartEditing()
                                Try
                                    CType(.Editor, ComboBox).DroppedDown = True
                                Catch ex As Exception
                                End Try
                            Case Else
                                e.SuppressKeyPress = True
                                .StartEditing()
                        End Select
                    End If
                Else
                    .FinishEditing()
                    '@Enter、矢印Keyは制御外
                    Select Case e.KeyCode
                        Case Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.Return
                            Exit Sub
                        Case Else
                            e.SuppressKeyPress = True
                    End Select
                    .AllowEditing = False
                End If
            End With

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfRecipe_KeyDown"          'ﾌﾟﾛｼｰｼﾞｬ名
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
    '作成日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '更新日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '備　考：
    Private Sub cmbWpName_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbWpName.CloseUp

        Try

            '@装置名が選択されているか
            If cmbWpName.Text <> vbNullString Then

                '@=======================
                '@ 装置名ｺﾝﾎﾞのValidate処理
                '@=======================
                RemoveHandler cmbWpName.Validating, AddressOf cmbWpName_Validate
                Call cmbWpName_Validate(cmbWpName, New CancelEventArgs(True))
                AddHandler cmbWpName.Validating, AddressOf cmbWpName_Validate

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
    '作成日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '更新日：2018/01/15 (Mon) 14:52:26 Y.Yoneyama
    '備　考：
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
            
            '@最新情報取得
            Call cmdSearch_Click(cmdSearch, New EventArgs())
            
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

    '関数名：cmdSearch_Click
    '機　能：[最新取得]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '更新日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '備　考：
    Private Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If


            '@ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟが未選択の場合
            If cmbMcGroup.Text = vbNullString Then
                Exit Sub
            End If
            
            '@装置名が未選択の場合
            If cmbWpName.Text = vbNullString Then
                Exit Sub
            End If
            
            
            '@取得日時を表示
            lblNowDate.Text = Format$(Now, CPstrDateFormat)
            
            '@ﾎﾞﾀﾝ制御
            cmdKakutei.Enabled = False
            
            '@=======================
            '@ 装置状態情報の取得処理
            '@=======================
            Call prvEqState_Sel(cmbWpName.Value)
            
            '@=======================
            '@ ﾊﾞｯﾁ編成設定検索
            '@=======================
            Call prvBatcCompose_Sel()

            '@ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟIDを退避する
            mstrOldMcGroupID = cmbMcGroup.Value
            
            
            If cmbBatchCompse.Enabled = True Then
                '@ﾊﾞｯﾁ編成方式にﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmbBatchCompse)
            Else
                '@閉じるにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdClose)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdSearch_Click"           'ﾌﾟﾛｼｰｼﾞｬ名
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
    '作成日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '更新日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '備　考：
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
            llngRet = publngEnd_Proc(CPstrKeyEN02N0, ltypCommonInfo)

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

    '関数名：cmdKakutei_Click
    '機　能：[確定]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '更新日：2018/01/15 (Mon) 14:53:26 Y.Yoneyama
    '備　考：
    Private Sub cmdKakutei_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdKakutei.Click

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim llngCnt                 As Integer              'ｶｳﾝﾀ(汎用)
        Dim ltypBatchComposeStatus  As BatComposeStatus     'ﾊﾞｯﾁ編成構造体
        
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@=======================
            '@入力項目ｾｯﾄ
            '@=======================
            
            '@ﾊﾞｯﾁ編成方式
            cmbWpName.ValueCol = CMlngCmbWpNameId
            ltypBatchComposeStatus.strWpID = cmbWpName.Value

            '@ﾊﾞｯﾁ編成方式
            ltypBatchComposeStatus.strBatchComposeType = cmbBatchCompse.Value
            
            '@ﾊﾞｯﾁﾚｼﾋﾟ設定数
            ltypBatchComposeStatus.lngRecipeListCnt = vsfRecipe.Rows.Count - 1
            
            '@構造体初期化
            ltypBatchComposeStatus.typRecipeList = New List(Of typBatchControlRecipe)()
            
            Dim tmptypBatchControlRecipe As typBatchControlRecipe = New typBatchControlRecipe()
            '@ﾚｼﾋﾟ設定
            For llngCnt = 1 To vsfRecipe.Rows.Count - 1
                
                tmptypBatchControlRecipe.strSeqNum = vsfRecipe.GetData(llngCnt, CMlngvsfRecipeSeqNum)
                tmptypBatchControlRecipe.strRecipeId = vsfRecipe.GetData(llngCnt, CMlngvsfRecipeId)
                tmptypBatchControlRecipe.strWfNum = vsfRecipe.GetData(llngCnt, CMlngvsfRecipeWfNum)
                tmptypBatchControlRecipe.strTimeNum = vsfRecipe.GetData(llngCnt, CMlngvsfRecipeTimeNum)
                tmptypBatchControlRecipe.strTimeWfNum = vsfRecipe.GetData(llngCnt, CMlngvsfRecipeTimeWfNum)
                
                '@ﾚｼﾋﾟﾀｲﾌﾟ
                Select Case vsfRecipe.GetData(llngCnt, CMlngvsfRecipeType)
                    '@製品
                    Case CMstrRecipeProduct
                        tmptypBatchControlRecipe.strRecipeType = CMstrRecipeProductNum
                    
                    '@ｶﾞｽｸﾘｰﾆﾝｸﾞ
                    Case CMstrRecipeGasClean
                        tmptypBatchControlRecipe.strRecipeType = CMstrRecipeGasCleanNum
                    
                    '@ﾌﾟﾘｺｰﾄ
                    Case CMstrRecipePreCort
                        tmptypBatchControlRecipe.strRecipeType = CMstrRecipePreCortNum
                    
                    '@未設定
                    Case Else
                        tmptypBatchControlRecipe.strRecipeType = CMstrRecipeNoneNum
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM147W>$$<TRM147W>$$[%1]が[%2]の為、確定できません。"のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0147, CMstrvsfRecipeTypeT, CMstrRecipeNone)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@未設定の場合は終了する
                        Exit Sub
                End Select
                ltypBatchComposeStatus.typRecipeList.Add(tmptypBatchControlRecipe)
            Next
            
            '@=======================
            '@編集済み確認
            '@=======================

            '@ﾊﾞｯﾁ編成方式
            If ltypBatchComposeStatus.strBatchComposeType <> mtypPreviousBatchComposeStatus.strBatchComposeType Then
                ltypBatchComposeStatus.strEditFlag = CPstrOne
            Else
                ltypBatchComposeStatus.strEditFlag = CPstrZero
            End If
            
            '@ﾊﾞｯﾁﾚｼﾋﾟ設定数は同じこと
            If ltypBatchComposeStatus.lngRecipeListCnt <> mtypPreviousBatchComposeStatus.lngRecipeListCnt Then
                
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar00Y0)
                '@"「<TRMY0E>$$システムエラーが発生しました。システム担当者に連絡してください。」"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Exit Sub
            End If
            
            '@ﾚｼﾋﾟ設定
            For llngCnt = 0 To ltypBatchComposeStatus.lngRecipeListCnt - 1
                
                'SEQ_NUM(不変項目)
                If ltypBatchComposeStatus.typRecipeList(llngCnt).strSeqNum <> mtypPreviousBatchComposeStatus.typRecipeList(llngCnt).strSeqNum Then
                
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar00Y0)
                    '@"「<TRMY0E>$$システムエラーが発生しました。システム担当者に連絡してください。」"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    Exit Sub
                End If
                
                'ﾚｼﾋﾟﾀｲﾌﾟ(不変項目)
                If ltypBatchComposeStatus.typRecipeList(llngCnt).strRecipeType <> mtypPreviousBatchComposeStatus.typRecipeList(llngCnt).strRecipeType Then
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar00Y0)
                    '@"「<TRMY0E>$$システムエラーが発生しました。システム担当者に連絡してください。」"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    Exit Sub
                End If
                tmptypBatchControlRecipe = ltypBatchComposeStatus.typRecipeList(llngCnt)
                '編集ﾌﾗｸﾞ初期化
                tmptypBatchControlRecipe.strEditFlag = CPstrZero
                
                'ﾚｼﾋﾟID
                If ltypBatchComposeStatus.typRecipeList(llngCnt).strRecipeId <> mtypPreviousBatchComposeStatus.typRecipeList(llngCnt).strRecipeId Then
                    tmptypBatchControlRecipe.strEditFlag = CPstrOne
                End If
                
                'WF数
                If ltypBatchComposeStatus.typRecipeList(llngCnt).strWfNum <> mtypPreviousBatchComposeStatus.typRecipeList(llngCnt).strWfNum Then
                    tmptypBatchControlRecipe.strEditFlag = CPstrOne
                End If
                
                '時間
                If ltypBatchComposeStatus.typRecipeList(llngCnt).strTimeNum <> mtypPreviousBatchComposeStatus.typRecipeList(llngCnt).strTimeNum Then
                    tmptypBatchControlRecipe.strEditFlag = CPstrOne
                End If
                
                '時間WF数
                If ltypBatchComposeStatus.typRecipeList(llngCnt).strTimeWfNum <> mtypPreviousBatchComposeStatus.typRecipeList(llngCnt).strTimeWfNum Then
                    tmptypBatchControlRecipe.strEditFlag = CPstrOne
                End If
                ltypBatchComposeStatus.typRecipeList(llngCnt) = tmptypBatchControlRecipe
            Next
            
            
            '@=======================
            '@ 作業者ｺｰﾄﾞ入力画面　表示
            '@=======================
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@作業者ｺｰﾄﾞ入力がｷｬﾝｾﾙされたか
            If pblnCancel = True Then

                '@確定処理ｷｬﾝｾﾙ
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart("frmxxEN02N0", "cmdKakutei_Click")


            '@=======================
            '@ ﾊﾞｯﾁ編成設定
            '@=======================
            lblnAns = pubblnBatComposeRegist_Upd(CMstrbat_composeregistVer, _
                                                 pstrSBID, _
                                                 pstrUserID, _
                                                 ltypBatchComposeStatus)

            '@通信結果の判定
            If lblnAns = True Then
                '@通信成功の場合

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd("frmxxEN02N0", "cmdKakutei_Click")

                '@=======================
                '@ 最新情報の取得
                '@=======================
                Call cmdSearch_Click(cmdSearch, New EventArgs())

            Else
                '@通信失敗の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel("frmxxEN02N0", "cmdKakutei_Click")
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

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：prvFrmxxEN02N0_Init
    '機　能：ﾌｫｰﾑ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '更新日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '備　考：
    Private Sub prvFrmxxEN02N0_Init()

        Dim lstrFormTitle               As String               'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        Dim ltypMcGpLotInfo             As McGpLotInfo          '装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄ構造体

        Try

            '@=======================
            '@ ﾒﾆｭｰ関連付け処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN02N0, lstrFormTitle)

            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@=======================
            '@ ｺﾝﾎﾞﾎﾞｯｸｽ初期化処理
            '@=======================
            Call prvComboBox_Init()

            '@=======================
            '@ ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟ内容の初期化
            '@=======================
            Call prvDisplay_Init()

            '@=======================
            '@ 変数の初期化
            '@=======================
            mstrOldMcGroupID = vbNullString                 '前回ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟID退避用変数
            mtypMcGpLotInfo = ltypMcGpLotInfo               '装置ｸﾞﾙｰﾌﾟ仕掛ﾛｯﾄ構造体

            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvFrmxxEN02N0_Init"        'ﾌﾟﾛｼｰｼﾞｬ名
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
    '作成日：2017/06/23 (Fri) 15:02:38 Y.Yoneyama
    '更新日：2017/06/23 (Fri) 15:02:38 Y.Yoneyama
    '備　考：
    Private Sub prvComboBox_Init()

        Try

            '@ﾊﾞｯﾁ装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞの初期化
            With cmbMcGroup
                .Clear()                                                        'ｺﾝﾎﾞ情報初期化
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColName                                   'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColID                                   '値取得列
                .DirectInput = False                                            'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, _
                                        .Font.Style, .Font.Unit)                'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _
                                        .GridFont.Style, .GridFont.Unit)        'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .BackColor = SystemColors.Window                                '背景色
                .RowHeight = CMlngCmbRowHeight                                  '行の高さ
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter   '左寄中央揃え
            End With

            '@装置名ｺﾝﾎﾞの初期化
            With cmbWpName
                .Clear()                                                        'ｺﾝﾎﾞ情報初期化
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColName                                   'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColID                                   '値取得列
                .DirectInput = False                                            'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, _
                                        .Font.Style, .Font.Unit)                'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _
                                        .GridFont.Style, .GridFont.Unit)        'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .BackColor = SystemColors.Window                                '背景色
                .RowHeight = CMlngCmbRowHeight                                  '行の高さ
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter   '左寄中央揃え
                .Enabled = False                                                '使用不可
            End With
            
            '@ﾊﾞｯﾁ編成方式
            With cmbBatchCompse
                .Clear()                                                        'ｺﾝﾎﾞ情報初期化
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColName                                   'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColID                                   '値取得列
                .DirectInput = False                                            'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, _
                                        .Font.Style, .Font.Unit)                'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _
                                        .GridFont.Style, .GridFont.Unit)        'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .BackColor = SystemColors.Window                                '背景色
                .RowHeight = CMlngCmbRowHeight                                  '行の高さ
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter   '左寄中央揃え
                .Enabled = False                                                '使用不可
                '@選択項目設定
                .AddItem(CPstrManual & vbTab & CPstrZero)
                .AddItem(CPstrAuto & vbTab & CPstrOne)
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

    '関数名：prvButton_Init
    '機　能：ﾎﾞﾀﾝ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2017/06/23 (Fri) 15:02:38 Y.Yoneyama
    '更新日：2017/06/23 (Fri) 15:02:38 Y.Yoneyama
    '備　考：
    Private Sub prvButton_Init()

        Try

            cmdSearch.Enabled = False
            cmdKakutei.Enabled = False
            cmdClose.Enabled = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvButton_Init"             'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvLabel_Init
    '機　能：ﾗﾍﾞﾙ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2017/06/23 (Fri) 15:02:38 Y.Yoneyama
    '更新日：2017/06/23 (Fri) 15:02:38 Y.Yoneyama
    '備　考：
    Private Sub prvLabel_Init()

        Try
            
            lblNowDate.Text = vbNullString
            lblBatchComposeDate.Text = vbNullString
            lblBatchComposeEmp.Text = vbNullString
            lblMesMode.Text = vbNullString
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvLabel_Init"              'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvDisplay_Init
    '機　能：画面情報初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2017/06/22 (Thu) 13:14:51 Y.Yoneyama
    '更新日：2017/06/22 (Thu) 13:14:51 Y.Yoneyama
    '備　考：
    Private Sub prvDisplay_Init()

        Try

            '@=======================
            '@ ﾎﾞﾀﾝ初期化処理
            '@=======================
            Call prvButton_Init()
            
            '@=======================
            '@ ﾗﾍﾞﾙ初期化処理
            '@=======================
            Call prvLabel_Init()
            
            '@=======================
            '@ ｸﾞﾘｯﾄﾞの初期化
            '@=======================
            Call prvvsfRecipe_Init()
            Call prvvsfLot_Init()
            
            '@装置ｺﾝﾎﾞ
            cmbWpName.Clear()
            cmbWpName.Enabled = False
            
            'ﾊﾞｯﾁ編成方式ｺﾝﾎﾞ
            cmbBatchCompse.ListIndex = -1
            cmbBatchCompse.Enabled = False

            '@WPﾘｽﾄの初期化
            Erase mtypWpList
            mlngWpListCnt = 0

            '@各種ﾓｼﾞｭｰﾙ変数の初期化
            mlngOldcmbWpNameIndex = -1                          '前回装置名ｺﾝﾎﾞのINDEX退避用変数の初期化

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvDisplay_Init"            'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfRecipe_Init
    '機　能：ﾚｼﾋﾟｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2017/06/22 (Thu) 10:25:13 Y.Yoneyama
    '更新日：2017/06/22 (Thu) 10:25:13 Y.Yoneyama
    '備　考：
    Private Sub prvvsfRecipe_Init()

        Try

            '@=======================
            '@ ｸﾞﾘｯﾄﾞの初期化
            '@=======================
            With vsfRecipe

                .Redraw = False
                '@内容初期化
                .Clear()
                
                '@行数、列数の初期設定
                .Rows.Count = 1
                .Cols.Count = 8

                '@列幅、ﾀｲﾄﾙ設定
                .SetData(CMlngGridTitleCol, CMlngvsfRecipeSeqNum, CMstrvsfRecipeSeqNumT)
                .SetData(CMlngGridTitleCol, CMlngvsfRecipeType, CMstrvsfRecipeTypeT)
                .SetData(CMlngGridTitleCol, CMlngvsfRecipeId, CMstrvsfRecipeIdT)
                .SetData(CMlngGridTitleCol, CMlngvsfRecipeWfNum, CMstrvsfRecipeWfNumT)
                .SetData(CMlngGridTitleCol, CMlngvsfRecipeTimeNum, CMstrvsfRecipeTimeNumT)
                .SetData(CMlngGridTitleCol, CMlngvsfRecipeTimeWfNum, CMstrvsfRecipeTimeWfNumT)
                .SetData(CMlngGridTitleCol, CMlngvsfRecipeEditTime, CMstrvsfReicpeEditTimeT)
                .SetData(CMlngGridTitleCol, CMlngvsfRecipeEmpName, CMstrvsfRecipeEmpNameT)
                '@列文字表示位置
                .Cols(CMlngvsfRecipeSeqNum).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngvsfRecipeType).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfRecipeId).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfRecipeWfNum).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngvsfRecipeTimeNum).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngvsfRecipeTimeWfNum).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngvsfRecipeEditTime).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfRecipeEmpName).TextAlign = TextAlignEnum.LeftCenter

                '@非表示列の設定

                '@ﾀｲﾄﾙの設定
                Dim cellRange As CellRange = .GetCellRange(CMlngGridTitleCol, CMlngGridTitleCol, CMlngGridTitleCol, .Cols.Count - 1) '表題
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                     '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))       '背景色
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                       '文字位置
                headerStyle.Trimming  = StringTrimming.None                                              'NSYS ﾍｯﾀﾞは省略表示なしに設定
                cellRange.Style = headerStyle

                '@行幅設定
                .Rows(CMlngGridTitleCol).Height = CMlngGridTitleHeight

                '@自動列幅設定=自動調整する
                '.AutoSizeMode = flexAutoSizeColWidth
                .AutoSizeCols(CMlngvsfRecipeSeqNum, .Cols.Count - 1, 6)
                
                .Redraw = True

                '@使用不可設定
                .Enabled = False

                '@ﾘﾌﾚｯｼｭする
                '.Refresh()

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvvsfRecipe_Init"          'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfLot_Init
    '機　能：ﾛｯﾄｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2017/06/22 (Thu) 10:25:13 Y.Yoneyama
    '更新日：2017/06/22 (Thu) 10:25:13 Y.Yoneyama
    '備　考：
    Private Sub prvvsfLot_Init()

        Try

            '@=======================
            '@ ｸﾞﾘｯﾄﾞの初期化
            '@=======================
            With vsfLot

                .Redraw = False

                '@内容初期化
                .Clear()
                
                '@行数、列数の初期設定
                .Rows.Count = 1
                .Cols.Count = 11

                '@列幅、ﾀｲﾄﾙ設定
                .SetData(CMlngGridTitleCol, CMlngvsfLotNo, CMstrvsfLotNoT)
                .SetData(CMlngGridTitleCol, CMlngvsfLotPriority, CMstrvsfLotPriorityT)
                .SetData(CMlngGridTitleCol, CMlngvsfLotID, CMstrvsfLotIdT)
                .SetData(CMlngGridTitleCol, CMlngvsfRecipeIdB, CMstrvsfRecipeIdBT)
                .SetData(CMlngGridTitleCol, CMlngvsfFlowClass, CMstrvsfFlowClassT)
                .SetData(CMlngGridTitleCol, CMlngvsfWfQty, CMstrvsfWfQtyT)
                .SetData(CMlngGridTitleCol, CMlngvsfWaitTimeH, CMstrvsfWaitTimeHT)
                .SetData(CMlngGridTitleCol, CMlngvsfCarrierId, CMstrvsfCarrierIdT)
                .SetData(CMlngGridTitleCol, CMlngvsfCarrierPos, CMstrvsfCarrierPosT)
                .SetData(CMlngGridTitleCol, CMlngvsfOpId, CMstrvsfOpIdT)
                .SetData(CMlngGridTitleCol, CMlngvsfStepId, CMstrvsfStepIdT)
                '@列文字表示位置
                .Cols(CMlngvsfLotNo).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngvsfLotPriority).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngvsfLotID).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfRecipeIdB).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfFlowClass).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfWfQty).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngvsfWaitTimeH).TextAlign = TextAlignEnum.RightCenter
                .Cols(CMlngvsfCarrierId).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfCarrierPos).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfOpId).TextAlign = TextAlignEnum.LeftCenter
                .Cols(CMlngvsfStepId).TextAlign = TextAlignEnum.LeftCenter
                '@列データ型
                .Cols(CMlngvsfLotNo).DataType = GetType(Int32)
                .Cols(CMlngvsfWfQty).DataType = GetType(Int32)
                .Cols(CMlngvsfWaitTimeH).DataType = GetType(Int64)
                
                '@ﾀｲﾄﾙの設定
                Dim cellRange As CellRange = .GetCellRange(CMlngGridTitleCol, CMlngGridTitleCol, CMlngGridTitleCol, .Cols.Count - 1) '表題
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                     '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))       '背景色
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                       '文字位置
                headerStyle.Trimming  = StringTrimming.None                                              'NSYS ﾍｯﾀﾞは省略表示なしに設定
                cellRange.Style = headerStyle

                'NSYS フォーカス時背景色なし
                .Styles.Focus.Clear()
                .Styles.Highlight.Clear()

                '@行幅設定
                .Rows(CMlngGridTitleCol).Height = CMlngGridRowHeightLot

                '@自動列幅設定=自動調整する
                '.AutoSizeMode = flexAutoSizeColWidth
                .AutoSizeCols(CMlngvsfLotNo, .Cols.Count - 1, 6)

                .Redraw = True

                '@使用不可設定
                .Enabled = False

                '@ﾘﾌﾚｯｼｭする
                '.Refresh()

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvvsfRecipe_Init"          'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbMcGroup_Disp
    '機　能：装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞの設定
    '引　数：ltypMcGroupList：装置ｸﾞﾙｰﾌﾟ構造体
    '戻り値：なし
    '作成日：2017/06/23 (Fri) 15:40:29 Y.Yoneyama
    '更新日：2017/06/23 (Fri) 15:40:29 Y.Yoneyama
    '備　考：
    Private Sub prvCmbMcGroup_Disp(ByRef ltypMcGroupList As McGroupList)

        Dim llngCnt     As Integer  'ｶｳﾝﾀ

        Try

            With ltypMcGroupList

                '@装置ｸﾞﾙｰﾌﾟ情報ｾｯﾄ
                For llngCnt = 0 To .lngMcGroupListCnt - 1

                    '@装置ｸﾞﾙｰﾌﾟ名/装置ｸﾞﾙｰﾌﾟID
                    cmbMcGroup.AddItem(ltypMcGroupList.typMcGroupList(llngCnt).strMcGroupName _
                    & vbTab & _
                    ltypMcGroupList.typMcGroupList(llngCnt).strMcGroupID)

                Next llngCnt

                '@装置ｸﾞﾙｰﾌﾟが1件の場合、ﾃﾞﾌｫﾙﾄ表示
                If .lngMcGroupListCnt = 1 Then
                    '@1件目表示
                    cmbMcGroup.ListIndex = 0
                    
                    '@=======================
                    '@ ﾊﾞｯﾁ装置ｺﾝﾎﾞのValidate処理
                    '@=======================
                    RemoveHandler cmbMcGroup.Validating, AddressOf cmbMcGroup_Validate
                    Call cmbMcGroup_Validate(cmbMcGroup, New CancelEventArgs(True))
                    AddHandler cmbMcGroup.Validating, AddressOf cmbMcGroup_Validate
                End If

            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvCmbMcGroup_Disp"         'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvBatcCompose_Sel
    '機　能：ﾊﾞｯﾁ管理画面情報取得
    '引　数：なし
    '戻り値：なし
    '作成日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '更新日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '備　考：
    Private Sub prvBatcCompose_Sel()

        Dim lblnAns                     As Boolean
        Dim ltypBatchComposeStatus      As BatComposeStatus
        Dim ltypBatchRecipeList         As BatRecipeList
        Dim ltypBatWatingLotList        As BatWaitingLotList
        
        
        Try

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart("frmxxEN02N0", "prvBatcCompose_Sel")
            
            '@=======================
            '@ 選択項目の無効化
            '@=======================
            cmdSearch.Enabled = False
            cmbMcGroup.Enabled = False
            cmbWpName.Enabled = False
            cmbBatchCompse.Enabled = False
            vsfRecipe.Enabled = False
            
            
            '@装置ｺﾝﾎﾞの値取得列を「運用ﾓｰﾄﾞ」列に変更
            cmbWpName.ValueCol = CMlngCmbWpNameId

            '@=======================
            '@ ﾊﾞｯﾁﾚｼﾋﾟ一覧取得
            '@=======================
            lblnAns = pubblnBatRecipeList_Sel(CMstrbat_recipelistVer, _
                                              pstrSBID, _
                                              cmbWpName.Value, _
                                              ltypBatchRecipeList)
            
            
            '@通信失敗の場合
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽ取得中止
                Call pubResponseCancel("frmxxEN02N0", "prvBatcCompose_Sel")
                Exit Sub
            End If
            
            
            '@=======================
            '@ ﾊﾞｯﾁ編成方式の現在設定値取得
            '@=======================
            lblnAns = pubblnBatComposeStatus_Sel(CMstrbat_composestatusVer, _
                                                 pstrSBID, _
                                                 cmbWpName.Value, _
                                                 ltypBatchComposeStatus)
            
            
            '@通信失敗の場合
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽ取得中止
                Call pubResponseCancel("frmxxEN02N0", "prvBatcCompose_Sel")
                Exit Sub
            End If
            
            
            
            '@=======================
            '@ ﾊﾞｯﾁ装置ﾛｯﾄ待ち一覧取得
            '@=======================
            lblnAns = pubblnBatWaitingLotList_Sel(CMstrbat_waitinglotlistVer, _
                                                  cmbWpName.Value, _
                                                  ltypBatWatingLotList)
            
                
            '@通信失敗の場合
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽ取得中止
                Call pubResponseCancel("frmxxEN02N0", "prvBatcCompose_Sel")
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd("frmxxEN02N0", "prvBatcCompose_Sel")
            
            
            'ﾊﾞｯﾁ編成方式を保存(編集箇所の比較用)
            mtypPreviousBatchComposeStatus = ltypBatchComposeStatus
            
            '@=======================
            '@ ﾊﾞｯﾁ編成方式の表示
            '@=======================
            Call prvBatchCompose_Disp(ltypBatchComposeStatus, ltypBatchRecipeList)
            
            '@=======================
            '@ ﾊﾞｯﾁ装置待ちﾛｯﾄ一覧の表示
            '@=======================
            Call prvBatchWaitingLotList_Disp(ltypBatWatingLotList)
            
            '@=======================
            '@ 選択項目の有効化
            '@=======================
            cmdSearch.Enabled = True
            cmbMcGroup.Enabled = True
            cmbWpName.Enabled = True
            cmbBatchCompse.Enabled = True

            '@ﾚｼﾋﾟ一覧にﾃﾞｰﾀが1件以上ある場合
            If vsfRecipe.Rows.Count > 1 Then
                vsfRecipe.Enabled = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvBatcCompose_Sel"         'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvBatchCompose_Disp
    '機　能：ﾊﾞｯﾁ編成設定表示
    '引　数：ltypBatchComposeStatus
    '      ：ltypBatchRecipeList
    '戻り値：なし
    '作成日：2017/06/22 (Thu) 17:11:18 Y.Yoneyama
    '更新日：2017/06/22 (Thu) 17:11:18 Y.Yoneyama
    '備　考：
    Private Sub prvBatchCompose_Disp(ByRef ltypBatchComposeStatus As BatComposeStatus, _
                                     ByRef ltypBatchRecipeList As BatRecipeList)

        Dim llngCnt                     As Integer
        Dim lstrTimNumItem()            As String
        
        Try

            '@=======================
            '@ ﾚｼﾋﾟｺﾝﾎﾞ設定
            '@=======================
            '@ｺﾝﾎﾞ文字の初期化
            mstrRecipeCmbStr(CMlngRecipeProductNum) = vbNullString
            mstrRecipeCmbStr(CMlngRecipeGasCleanNum) = vbNullString
            mstrRecipeCmbStr(CMlngRecipePreCortNum) = vbNullString
            mstrTimeNumItem = vbNullString
            mlngMaxProcessQuantity = 0
            
            '@ﾚｼﾋﾟｺﾝﾎﾞ文字作成
            '@ﾊﾞｯﾁﾚｼﾋﾟ一覧ﾃﾞｰﾀよﾚｼﾋﾟﾀｲﾌﾟによってｺﾝﾎﾞ文字を設定する
            For llngCnt = 0 To ltypBatchRecipeList.lngRecipeListCnt - 1
                    
                Select Case ltypBatchRecipeList.typRecipeList(llngCnt).strRecipeType
                        
                    '@製品ﾚｼﾋﾟ
                    Case CMstrRecipeProductNum
                        If mstrRecipeCmbStr(CMlngRecipeProductNum) <> vbNullString Then
                            mstrRecipeCmbStr(CMlngRecipeProductNum) = mstrRecipeCmbStr(CMlngRecipeProductNum) & "|"
                        End If
                        mstrRecipeCmbStr(CMlngRecipeProductNum) = mstrRecipeCmbStr(CMlngRecipeProductNum) & ltypBatchRecipeList.typRecipeList(llngCnt).strRecipeId
                            
                    '@ｶﾞｽｸﾘｰﾆﾝｸﾞﾚｼﾋﾟ
                    Case CMstrRecipeGasCleanNum
                        If mstrRecipeCmbStr(CMlngRecipeGasCleanNum) <> vbNullString Then
                            mstrRecipeCmbStr(CMlngRecipeGasCleanNum) = mstrRecipeCmbStr(CMlngRecipeGasCleanNum) & "|"
                        End If
                        mstrRecipeCmbStr(CMlngRecipeGasCleanNum) = mstrRecipeCmbStr(CMlngRecipeGasCleanNum) & ltypBatchRecipeList.typRecipeList(llngCnt).strRecipeId
                            
                    '@ﾌﾟﾘｺｰﾄﾚｼﾋﾟ
                    Case CMstrRecipePreCortNum
                        If mstrRecipeCmbStr(CMlngRecipePreCortNum) <> vbNullString Then
                            mstrRecipeCmbStr(CMlngRecipePreCortNum) = mstrRecipeCmbStr(CMlngRecipePreCortNum) & "|"
                        End If
                        mstrRecipeCmbStr(CMlngRecipePreCortNum) = mstrRecipeCmbStr(CMlngRecipePreCortNum) & ltypBatchRecipeList.typRecipeList(llngCnt).strRecipeId
                    
                End Select
                    
            Next llngCnt

            '@時間設定ﾘｽﾄ取得
            lstrTimNumItem = Split(ltypBatchRecipeList.strTimeNumItem, ",")
            For llngCnt = 0 To UBound(lstrTimNumItem)
                If mstrTimeNumItem <> vbNullString Then
                    mstrTimeNumItem = mstrTimeNumItem & "|"
                End If
                mstrTimeNumItem = mstrTimeNumItem & lstrTimNumItem(llngCnt)
            Next
            
            '@最大WF枚数
            If ltypBatchRecipeList.strMaxProcessQuantity <> vbNullString Then
                mlngMaxProcessQuantity = CLng(ltypBatchRecipeList.strMaxProcessQuantity)
            End If
            
            '@=======================
            '@ 装置設定
            '@=======================
            '@ﾊﾞｯﾁ編成方式の表示
            If ltypBatchComposeStatus.strBatchComposeType = CPstrOne Then
                '@自動
                cmbBatchCompse.Text = CPstrAuto
            Else
                '@手動
                cmbBatchCompse.Text = CPstrManual
            End If
                
            '@最終更新者、日時の表示
            lblBatchComposeDate.Text = ltypBatchComposeStatus.strEditTime
            lblBatchComposeEmp.Text = ltypBatchComposeStatus.strEditEmpName
            
            '運用ﾓｰﾄﾞ表示
            'cmbWpName.ValueCol = CMlngCmbWpNameMesModeID
            'lblMesMode.Caption = cmbWpName.Value

            '@=======================
            '@ ﾚｼﾋﾟ設定
            '@=======================
            With vsfRecipe
            
                .Redraw = False

                RemoveHandler vsfRecipe.EnterCell, AddressOf vsfRecipe_EnterCell
                '@行数の設定
                .Rows.Count = ltypBatchComposeStatus.lngRecipeListCnt + 1
                
                '@自動ﾊﾞｯﾁ編成ﾚｼﾋﾟ設定の表示
                For llngCnt = 1 To ltypBatchComposeStatus.lngRecipeListCnt
                
                    '@高さ設定
                    .Rows(llngCnt).Height = CMlngGridRowHeight
                
                    .SetData(llngCnt, CMlngvsfRecipeSeqNum, ltypBatchComposeStatus.typRecipeList(llngCnt-1).strSeqNum)
                    
                    Select Case ltypBatchComposeStatus.typRecipeList(llngCnt-1).strRecipeType
                        Case CMstrRecipeProductNum
                            .SetData(llngCnt, CMlngvsfRecipeType, CMstrRecipeProduct)
                        Case CMstrRecipeGasCleanNum
                            .SetData(llngCnt, CMlngvsfRecipeType, CMstrRecipeGasClean)
                        Case CMstrRecipePreCortNum
                            .SetData(llngCnt, CMlngvsfRecipeType, CMstrRecipePreCort)
                        Case Else
                            .SetData(llngCnt, CMlngvsfRecipeType, CMstrRecipeNone)
                    End Select
                    
                    .SetData(llngCnt, CMlngvsfRecipeId, ltypBatchComposeStatus.typRecipeList(llngCnt-1).strRecipeId)
                    .SetData(llngCnt, CMlngvsfRecipeWfNum, ltypBatchComposeStatus.typRecipeList(llngCnt-1).strWfNum)
                    .SetData(llngCnt, CMlngvsfRecipeTimeNum, ltypBatchComposeStatus.typRecipeList(llngCnt-1).strTimeNum)
                    .SetData(llngCnt, CMlngvsfRecipeTimeWfNum, ltypBatchComposeStatus.typRecipeList(llngCnt-1).strTimeWfNum)
                    .SetData(llngCnt, CMlngvsfRecipeEditTime, ltypBatchComposeStatus.typRecipeList(llngCnt-1).strEditTime)
                    .SetData(llngCnt, CMlngvsfRecipeEmpName, ltypBatchComposeStatus.typRecipeList(llngCnt-1).strEditEmpName)
                
                Next llngCnt
                
                '@自動列幅設定=自動調整する
                '.AutoSizeMode = flexAutoSizeColWidth
                .AutoSizeCols(CMlngvsfRecipeSeqNum, .Cols.Count - 1, 6)

                AddHandler vsfRecipe.EnterCell, AddressOf vsfRecipe_EnterCell
                .Row = 0

                .Redraw = True
            
            End With
             
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvBatchCompose_Disp"       'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvBatchWaitingLotList_Disp
    '機　能：ﾊﾞｯﾁ装置ﾛｯﾄ待ち一覧表示
    '引　数：ltypBatWatingLotList
    '戻り値：なし
    '作成日：2017/06/22 (Thu) 17:11:18 Y.Yoneyama
    '更新日：2018/01/15 (Mon) 14:56:26 Y.Yoneyama
    '備　考：
    Private Sub prvBatchWaitingLotList_Disp(ByRef ltypBatWatingLotList As BatWaitingLotList)

        Dim llngCnt                     As Integer
        Dim lstrWpReciep                As String
        Dim llngLotCnt                  As Integer
        Dim llngLotTotal                As Integer
        Dim newStyle As CellStyle
        Dim cellRange As CellRange

        Try

            '@ﾚｼﾋﾟIDが設定順序1と同じであること(今後複数ﾚｼﾋﾟ時には対応方法を検討)
            If vsfRecipe.Rows.Count > 1 Then
                lstrWpReciep = vsfRecipe.GetData(1, CMlngvsfRecipeId)
            Else
                Exit Sub
            End If
            
            '@自動ﾊﾞｯﾁ編成ﾚｼﾋﾟと待ちﾛｯﾄのﾚｼﾋﾟ整合ﾁｪｯｸ
            llngLotTotal = 0
            For llngCnt = 0 To ltypBatWatingLotList.lngBatLotCnt - 1
                If lstrWpReciep = ltypBatWatingLotList.typBatLotList(llngCnt).strRecipeId Then
                    llngLotTotal = llngLotTotal + 1
                End If
            Next
            
            '@=======================
            '@ ﾛｯﾄ設定
            '@=======================
            With vsfLot
                
                .Enabled = True

                .Redraw = False
                
                '@行数の設定
                .Rows.Count = llngLotTotal + 1
                
                llngLotCnt = 0
                
                '@自動ﾊﾞｯﾁ編成ﾚｼﾋﾟ設定の表示
                For llngCnt = 0 To ltypBatWatingLotList.lngBatLotCnt - 1
                    
                    If lstrWpReciep = ltypBatWatingLotList.typBatLotList(llngCnt).strRecipeId Then
                        
                        llngLotCnt = llngLotCnt + 1
                        
                        '@高さ設定
                        .Rows(llngLotCnt).Height = CMlngGridRowHeightLot
                        
                        '@保留・停止ﾁｪｯｸ
                        If ltypBatWatingLotList.typBatLotList(llngCnt).strLotStopFlag = CPstrOne Or _
                            ltypBatWatingLotList.typBatLotList(llngCnt).strLotHoldFlag = CPstrOne Then
                            '@黄色
                            newStyle = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)
                            cellRange = .GetCellRange(llngLotCnt, CMlngvsfLotNo, llngLotCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        Else
                            '@白色
                            newStyle = .Styles.Add("CustomStyle_BackColor_CPlngEnableTrueColor")
                            newStyle.BackColor =  ColorTranslator.FromWin32(CPlngEnableTrueColor)
                            cellRange = .GetCellRange(llngLotCnt, CMlngvsfLotNo, llngLotCnt, .Cols.Count - 1)
                            cellRange.Style = newStyle
                        End If
                        
                        .SetData(llngLotCnt, CMlngvsfLotNo, CStr(llngLotCnt))
                        .SetData(llngLotCnt, CMlngvsfLotPriority, ltypBatWatingLotList.typBatLotList(llngCnt).strLotPriority)
                        .SetData(llngLotCnt, CMlngvsfLotID, ltypBatWatingLotList.typBatLotList(llngCnt).strLotID)
                        .SetData(llngLotCnt, CMlngvsfRecipeIdB, ltypBatWatingLotList.typBatLotList(llngCnt).strRecipeId)
                        .SetData(llngLotCnt, CMlngvsfFlowClass, ltypBatWatingLotList.typBatLotList(llngCnt).strFlowClass)
                        .SetData(llngLotCnt, CMlngvsfWfQty, ltypBatWatingLotList.typBatLotList(llngCnt).strWfQty)
                        .SetData(llngLotCnt, CMlngvsfWaitTimeH, ltypBatWatingLotList.typBatLotList(llngCnt).strWaitTimeH)
                        .SetData(llngLotCnt, CMlngvsfCarrierId, ltypBatWatingLotList.typBatLotList(llngCnt).strCarrierId)
                        .SetData(llngLotCnt, CMlngvsfCarrierPos, ltypBatWatingLotList.typBatLotList(llngCnt).strCurrentPositionName)
                        '@ｷｬﾘｱ位置ﾁｪｯｸ
                        If ltypBatWatingLotList.typBatLotList(llngCnt).strStockerId = vbNullString Then
                            '@保留・停止ﾁｪｯｸ
                            If ltypBatWatingLotList.typBatLotList(llngCnt).strLotStopFlag = CPstrZero And _
                                ltypBatWatingLotList.typBatLotList(llngCnt).strLotHoldFlag = CPstrZero Then
                                '@薄ｸﾞﾚｰ色
                                newStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                                newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                                cellRange = .GetCellRange(llngLotCnt, CMlngvsfLotNo, llngLotCnt, .Cols.Count - 1)
                                cellRange.Style = newStyle
                            End If
                    
                            '@赤色
                            newStyle = .Styles.Add("CustomStyle_BackColor_CPlngVbColorRed")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngVbColorRed)
                            cellRange = .GetCellRange(llngLotCnt, CMlngvsfCarrierPos, llngLotCnt, CMlngvsfCarrierPos)
                            cellRange.Style = newStyle
                        End If
                        .SetData(llngLotCnt, CMlngvsfOpId, ltypBatWatingLotList.typBatLotList(llngCnt).strOpID)
                        .SetData(llngLotCnt, CMlngvsfStepId, ltypBatWatingLotList.typBatLotList(llngCnt).strStepID)
                    
                    End If
                Next llngCnt
                
                .Row = 0

                '@行数の設定
                '.Rows = llngLotCnt + 1
                
                '@自動列幅設定=自動調整する
                '.AutoSizeMode = flexAutoSizeColWidth
                .AutoSizeCols(CMlngvsfLotNo, .Cols.Count - 1, 6)
                
                .Redraw = True

            End With
             
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvBatchWaitingLotList_Disp" 'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvPreviousData_Chk
    '機　能：取得ﾃﾞｰﾀと現在値の比較
    '引　数：なし
    '戻り値：なし
    '作成日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '更新日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '備　考：
    Private Sub prvPreviousData_Chk()

        Dim llngCnt                 As Integer      'ｶｳﾝﾀ(汎用)


        Try
            
            '@確定ﾎﾞﾀﾝ無効
            cmdKakutei.Enabled = False
            
            '@WF枚数入力ﾁｪｯｸ
            With vsfRecipe
                    
                '@ﾚｼﾋﾟ設定現在値検索
                For llngCnt = 1 To .Rows.Count - 1
                    
                    '@WF枚数
                    '@数値ﾁｪｯｸ
                    If IsNumeric(.GetData(llngCnt, CMlngvsfRecipeWfNum)) Then
                        '@最大WF数以内の設定であること
                        If CLng(.GetData(llngCnt, CMlngvsfRecipeWfNum)) > mlngMaxProcessQuantity Or _
                            CLng(.GetData(llngCnt, CMlngvsfRecipeWfNum)) < 0 Then
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            '@"<TRM147W>$$<TRM147W>$$[%1]が[%2]の為、確定できません。"のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0147, "枚数設定WF", "設定範囲外")
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit Sub
                        End If
                    Else
                        Exit Sub
                    End If
                    
                    '@時間設定
                    '@数値ﾁｪｯｸ
                    If IsNumeric(.GetData(llngCnt, CMlngvsfRecipeTimeNum)) Then
                        '@0以下はNG
                        If CLng(.GetData(llngCnt, CMlngvsfRecipeTimeNum)) < 0 Then
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            '@"<TRM147W>$$<TRM147W>$$[%1]が[%2]の為、確定できません。"のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0147, "時間設定", "設定範囲外")
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit Sub
                        End If
                    Else
                        Exit Sub
                    End If
                    
                    '@時間設定WF枚数
                    '@数値ﾁｪｯｸ
                    If IsNumeric(.GetData(llngCnt, CMlngvsfRecipeTimeWfNum)) Then
                        '@最大WF数以内の設定であること
                        If CLng(.GetData(llngCnt, CMlngvsfRecipeTimeWfNum)) > mlngMaxProcessQuantity Or _
                            CLng(.GetData(llngCnt, CMlngvsfRecipeTimeWfNum)) < 0 Then
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            '@"<TRM147W>$$<TRM147W>$$[%1]が[%2]の為、確定できません。"のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0147, "時間設定WF", "設定範囲外")
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit Sub
                        End If
                    Else
                        Exit Sub
                    End If

                Next llngCnt
            
            End With
            
            '@ﾊﾞｯﾁ編成方式の比較
            If cmbBatchCompse.Value <> mtypPreviousBatchComposeStatus.strBatchComposeType Then
                
                '@確定ﾎﾞﾀﾝ有効
                cmdKakutei.Enabled = True
                
                Exit Sub
                
            End If

            '@ﾚｼﾋﾟの比較
            With vsfRecipe
                    
                '@ﾚｼﾋﾟ設定現在値検索
                For llngCnt = 1 To .Rows.Count - 1
                    
                    '@ﾚｼﾋﾟ
                    If .GetData(llngCnt, CMlngvsfRecipeId) <> mtypPreviousBatchComposeStatus.typRecipeList(llngCnt-1).strRecipeId Then
                        '@確定ﾎﾞﾀﾝ有効
                        cmdKakutei.Enabled = True
                        Exit Sub
                    End If
                    
                    '@WF枚数
                    If .GetData(llngCnt, CMlngvsfRecipeWfNum) <> mtypPreviousBatchComposeStatus.typRecipeList(llngCnt-1).strWfNum Then
                        '@確定ﾎﾞﾀﾝ有効
                        cmdKakutei.Enabled = True
                        Exit Sub
                    End If
                    
                    '@時間設定
                    If .GetData(llngCnt, CMlngvsfRecipeTimeNum) <> mtypPreviousBatchComposeStatus.typRecipeList(llngCnt-1).strTimeNum Then
                        '@確定ﾎﾞﾀﾝ有効
                        cmdKakutei.Enabled = True
                        Exit Sub
                    End If
                    
                    '@時間設定WF枚数
                    If .GetData(llngCnt, CMlngvsfRecipeTimeWfNum) <> mtypPreviousBatchComposeStatus.typRecipeList(llngCnt-1).strTimeWfNum Then
                        '@確定ﾎﾞﾀﾝ有効
                        cmdKakutei.Enabled = True
                        Exit Sub
                    End If
                Next llngCnt
            
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvPreviousData_Chk"        'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvWpList_Sel
    '機　能：ﾊﾞｯﾁ管理画面情報取得
    '引　数：なし
    '戻り値：なし
    '作成日：2017/06/23 (Fri) 16:15:23 Y.Yoneyama
    '更新日：2018/01/15 (Mon) 14:55:35 Y.Yoneyama
    '備　考：
    Private Sub prvWpList_Sel()

        Dim lblnAns                     As Boolean              '結果格納
        Dim llngCnt                     As Integer              'ｶｳﾝﾀ(汎用)
        Dim lstrBefWpName               As String               '装置名格納
        Dim lstrWpNameList              As String               '装置名ﾘｽﾄ

        Try

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart("frmxxEN02N0", "prvWpList_Sel")
            
            '@=======================
            '@ 装置一覧取得
            '@=======================
            '@処理区分：20⇒装置ｸﾞﾙｰﾌﾟ別
            lblnAns = pubblnWpList_Sel(CMstrmas_wplist__Ver, _
                                        mlngWpListCnt, _
                                        pstrSBID, _
                                        CPstrCD20, _
                                        cmbMcGroup.Value)

            '@結果判定
            If lblnAns = True Then
                '@通信成功の場合

                '@装置名ｺﾝﾎﾞの初期化
                cmbWpName.Clear()

                For llngCnt = 0 To mlngWpListCnt - 1

                    With ptypWPList(llngCnt)

                        '@装置名 & 装置ID & 最大処理単位ﾎﾞｯｸｽ数 & 運用ﾓｰﾄﾞ & 装置ﾀｲﾌﾟ(Eqtype)
                        cmbWpName.AddItem(.strWpName & vbTab & _
                                        .strWpID & vbTab & _
                                        .strMaxProcessBox & vbTab & _
                                        .strMesModeId & vbTab & _
                                        .strEqType)

                        '@WPﾘｽﾄの設定
                        ReDim Preserve mtypWpList(llngCnt)

                        mtypWpList(llngCnt).strWpID = .strWpID                          '装置ID
                        mtypWpList(llngCnt).strWpName = .strWpName                      '装置名
                        mtypWpList(llngCnt).strMaxProcessBox = .strMaxProcessBox        '最大処理数
                        mtypWpList(llngCnt).strMesModeId = .strMesModeId                '運用ﾓｰﾄﾞ
                        mtypWpList(llngCnt).strEqType = .strEqType                      '装置ﾀｲﾌﾟ(Eqtype)
                        mtypWpList(llngCnt).strBatchComposeType = .strBatchComposeType  'ﾊﾞｯﾁ自動編成ﾀｲﾌﾟ
                    End With

                Next llngCnt

                '@装置名ｺﾝﾎﾞが1個の場合は該当装置名を自動表示する
                If cmbWpName.ListCount = 1 Then
                    cmbWpName.ListIndex = 0
                End If


                lstrBefWpName = "ダミー初期値"                  '下記For文のﾙｰﾌﾟ一回目でｴﾗｰにしないため
                For llngCnt = 0 To mlngWpListCnt - 1
                
                    '@装置ﾘｽﾄを表示する(同じ装置名の号機違いは「#n」だけ表示)
                    If Mid$(lstrBefWpName, 1, Len(lstrBefWpName) - 2) = _
                       Mid$(mtypWpList(llngCnt).strWpName, 1, Len(mtypWpList(llngCnt).strWpName) - 2) Then
                       
                        '@号機だけ違う場合
                        lstrWpNameList = lstrWpNameList & _
                                         str$(llngCnt) & _
                                         CMstrColon & _
                                         Mid$(mtypWpList(llngCnt).strWpName, Len(mtypWpList(llngCnt).strWpName) - 1) & _
                                         Space$(1)
                    
                    Else
                    
                        '@まったく別装置の場合
                        lstrWpNameList = lstrWpNameList & _
                                         str$(llngCnt) & _
                                         CMstrColon & _
                                         mtypWpList(llngCnt).strWpName & _
                                         Space$(1)
                    End If
                    
                    '@前回値として退避
                    lstrBefWpName = mtypWpList(llngCnt).strWpName
                    
                Next llngCnt
                
                cmbWpName.Enabled = True

            Else
                '@通信失敗の場合

                '@ﾚｽﾎﾟﾝｽ取得中止
                Call pubResponseCancel("frmxxEN02N0", "prvWpList_Sel")
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd("frmxxEN02N0", "prvWpList_Sel")

            '@ﾎﾞﾀﾝ制御
            cmdSearch.Enabled = False
            cmdKakutei.Enabled = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvWpList_Sel"              'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvEqState_Sel
    '機　能：装置状態取得処理
    '引　数：lstrWpID：装置ID
    '戻り値：なし
    '作成日：2004/06/22 (Tue) 11:48:01 S.Deguchi
    '更新日：2004/06/22 (Tue) 11:48:01
    '備　考：
    Private Sub prvEqState_Sel(ByVal lstrWpId As String)

        Dim lblnAns     As Boolean      '結果格納
        Dim ltypEqstate As Eqstate      '装置状態ﾘｽﾄ格納


        Try

            '@構造体初期化
            ltypEqstate.typPortList = New List(Of eqPortList)()

            '@【装置状態取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnEqState_Sel(CMstreq__state___Ver, _
                                        lstrWpId, ltypEqstate)

            '@通信結果判定
            If lblnAns = True Then
                lblMesMode.Text = ltypEqstate.strMesModeId
            Else
                lblMesMode.Text = vbNullString
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvEqState_Sel"
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraWaitingLotList.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfLot.BeforeDoubleClick, vsfRecipe.BeforeDoubleClick

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
            'gridObj.AutoSizeCol(colindex,6)

        ElseIf gridObj Is vsfRecipe AndAlso gridObj.HitTest(e.X,e.Y).Type = HitTestTypeEnum.Cell Then
            'ダブルクリックした列番号を格納
            colindex = gridObj.HitTest(e.X,e.Y).Column
            If colindex = CMlngvsfRecipeId OrElse colindex = CMlngvsfRecipeTimeNum Then
                '本来の処理をキャンセル
                e.Cancel = True

                If gridObj.Cols(gridObj.Col).ComboList Is Nothing OrElse _
                    gridObj.Cols(gridObj.Col).ComboList = vbNullString Then
                    Exit Sub
                End If

                'NSYS VB6互換で編集を開始し、ドロップダウンを展開する
                gridObj.StartEditing()
                Try
                    CType(gridObj.Editor, ComboBox).DroppedDown = True
                Catch ex As Exception
                End Try
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
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfLot.KeyDownEdit, vsfRecipe.KeyDownEdit

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

    '関数名：cursor_Enter
    '機　能 ： 項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考 ： Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Enter, _
            cmdSearch.Enter, cmdKakutei.Enter, cmbMcGroup.Enter, cmbWpName.Enter,  cmbBatchCompse.Enter,  _
            vsfRecipe.Enter, vsfLot.Enter

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

    '関数名：vsfRecipe_Enter
    '機　能：vsfRecipeグリッドフォーカス時処理
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2020/05/20 (Wed)  NSYS
    '更新日：
    '備　考 ：
    Private Sub vsfRecipe_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles vsfRecipe.Enter
        vsfRecipe_EnterCell(sender, New EventArgs)
    End Sub


    '関数名：vsfLot_BeforeSort
    '機　能：vsfLotグリッドソート前処理
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2020/05/20 (Wed)  NSYS
    '更新日：
    '備　考 ：
    Private Sub vsfLot_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLot.BeforeSort
        Try
            'ソート前の選択行を保持
            mintvsfLotBeforeSortRow = vsfLot.Row
        Catch ex As Exception
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLot_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：vsfLot_AfterSort
    '機　能：vsfLotグリッドソート後処理
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2020/05/20 (Wed)  NSYS
    '更新日：
    '備　考 ：
    Private Sub vsfLot_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLot.AfterSort
        Try
            'ソート前の選択行を復元
             vsfLot.Row = mintvsfLotBeforeSortRow
        Catch ex As Exception
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfLot_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
        End Try
    End Sub

End Class
