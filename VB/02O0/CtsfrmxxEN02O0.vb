'ﾌｧｲﾙ名：xxEN02O0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：時間制限流動管理メインフォーム
'作成日：2018/01/05 (Fri) 16:24:08 Y.Yoneyama
'更新日：2018/01/05 (Fri) 16:24:08 Y.Yoneyama
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2016, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02O0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02O0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02O0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02O0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02O0)
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
    Private Const CMstrtimeRestrictstatusVer        As String = "01.00"                     '時間制限流動設定取得
    Private Const CMstrtimeRestrictregistVer        As String = "01.00"                     '時間制限流動設定登録

    '@機能ID
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN02O0              'ﾛｰｶﾙ機能ID

    '@ﾌﾚｯｸｽｸﾞﾘｯﾄﾞのｶﾗﾑ定数
    Private Const CMlngGridTitleRowHeight           As Integer = 20                            'ﾀｲﾄﾙの高さ
    Private Const CMlngGridTitleColWidth            As Integer = 200                           'ﾀｲﾄﾙの高さ
    Private Const CMlngGridRowHeight                As Integer = 33                            '1明細の高さ

    '@工程列定義
    Private Const CMlngvsfFlowSeqNum                As Integer = 0                             'No
    Private Const CMlngvsfFlowLotStopOn             As Integer = 1                             'ﾛｯﾄ停止ON
    Private Const CMlngvsfFlowFromOpId              As Integer = 2                             '開始工程(大)
    Private Const CMlngvsfFlowFromStepId            As Integer = 3                             '開始工程(小)
    Private Const CMlngvsfFlowToOpId                As Integer = 4                             '終了工程(大)
    Private Const CMlngvsfFlowToStepId              As Integer = 5                             '終了工程(小)
    Private Const CMlngvsfFlowEditTime              As Integer = 6                             '最終更新日時
    Private Const CMlngvsfFlowEmpName               As Integer = 7                             '最終更新者

    '@工程ﾀｲﾄﾙ定義
    Private Const CMstrvsfFlowSeqNumT               As String = "№"
    Private Const CMstrvsfFlowLotStopOnT            As String = "ﾛｯﾄ保留"
    Private Const CMstrvsfFlowFromOpIdT             As String = "大工程"
    Private Const CMstrvsfFlowFromStepIdT           As String = "小工程"
    Private Const CMstrvsfFlowToOpIdT               As String = "大工程"
    Private Const CMstrvsfFlowToStepIdT             As String = "小工程"
    Private Const CMstrvsfFlowEditTimeT             As String = "最終更新日時"
    Private Const CMstrvsfFlowEmpNameT              As String = "最終更新者"

    '@装置列定義
    Private Const CMlngvsfWpSeqNum                  As Integer = 0                             'No
    Private Const CMlngvsfWpID                      As Integer = 1                             '装置ID
    Private Const CMlngvsfWpName                    As Integer = 2                             '装置名
    Private Const CMlngvsfWpProcessingId            As Integer = 3                             '処理部ID
    Private Const CMlngvsfWpProcessingName          As Integer = 4                             '処理部名
    Private Const CMlngvsfWpLotStopOff              As Integer = 5                             'ﾛｯﾄ停止OFF
    Private Const CMlngvsfWpWaitLotNum              As Integer = 6                             '時間制限ﾛｯﾄ処理待ち在庫
    Private Const CMlngvsfWpEditTime                As Integer = 7                             '最終更新日時
    Private Const CMlngvsfWpEmpName                 As Integer = 8                             '最終更新者

    '@装置ﾀｲﾄﾙ定義
    Private Const CMstrvsfWpSeqNumT                 As String = "№"
    Private Const CMstrvsfWpIdT                     As String = "装置ID"
    Private Const CMstrvsfWpNameT                   As String = "装置名"
    Private Const CMstrvsfWpProcessingIdT           As String = "処理部ID"
    Private Const CMstrvsfWpProcessingNameT         As String = "処理部"
    Private Const CMstrvsfWpLotStopOffT             As String = "ﾛｯﾄ保留解除"
    Private Const CMstrvsfWpWiatLotNumT             As String = "時間制限 在庫数"
    Private Const CMstrvsfWpWiatLotNumBatchT        As String = "作業待数"
    Private Const CMstrvsfWpEditTimeT               As String = "最終更新日時"
    Private Const CMstrvsfWpEmpNameT                As String = "最終更新者"

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbRestrictTypeName          As Integer = 0                             '装置名ｺﾝﾎﾞの名前列
    Private Const CMlngCmbRestrictType              As Integer = 1                             '装置名ｺﾝﾎﾞの名前列
    Private Const CMstrValueZeroName                As String = "手動"                         '無効
    Private Const CMstrValueOneName                 As String = "自動"                         '有効
    Private Const CMlngWaitLotNumLength             As Integer = 1                             '時間制限処理待在庫ﾛｯﾄ(入力桁)
    Private Const CMlngWaitLotNumMin                As Integer = 1                             '時間制限処理待在庫ﾛｯﾄ(最小値)
    Private Const CMlngWaitLotNumMax                As Integer = 9                             '時間制限処理待在庫ﾛｯﾄ(最大値)

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                  As Integer = 14                            'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 14                            'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColName               As Integer = 0                             '名称列番
    Private Const CMlngCmbGridColID                 As Integer = 1                             'ID列番(非表示項目)
    Private Const CMlngCmbDispCols                  As Integer = 1                             'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbRowHeight                 As Integer = 43                            'ﾘｽﾄ行の高さ

    '@色宣言
    Private Const CPlngWhiteColor                   As Integer = &H80000005                    '白色
    Private Const CPlngPinkColor                    As Integer = &HC0C0FF                      '桃色

    '@その他
    Private Const CMstrLotStopOffFoBatch            As String = "バッチ編成設定に従う"
    Private Const CMstrWaitLotNumFoBatch            As String = "装置最大処理数に従う"

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mstrPreviousRestrictType                As String
    Private mlngOldcmbRestrictTypeIndex             As Integer
    Private mstrCmbLotStop                          As String
    Private mtypPreviousRestrictStatus              As TimeRestrict
    Private mblnFirstActivateFlag                   As Boolean                              '初回ﾌｫｰﾑｱｸﾃｨﾌﾞ判定ﾌﾗｸﾞ(True：初回、False：2回目以降)
    Private buttonProcessing                        As Boolean                              'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                              'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                              'NSYS WindowCloseフラグ
    Private mstrOldGridEditorText                   As String                               'NSYS グリッドの編集前文字列
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
    '作成日：2018/01/05 (Fri) 16:24:08 Y.Yoneyama
    '更新日：2018/01/05 (Fri) 16:24:08 Y.Yoneyama
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns             As Boolean          '結果格納

        Try

            '@=======================
            '@ 機能ﾊﾞｰｼﾞｮﾝ判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN02O0, CMstrLocalVersion)

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
                Call Form_QueryUnload(False, New FormClosingEventArgs(New CloseReason,  False))

                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart("frmxxEN02O0", "Form_Load")

            '@=======================
            '@ ﾌｫｰﾑ初期化処理
            '@=======================
            Call prvFrmxxEN02O0_Init()

            '@=======================
            '@ 時間制限ﾀｲﾌﾟｺﾝﾎﾞの設定
            '@=======================
            Call prvcmbRestrictType_Disp()

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd("frmxxEN02O0", "Form_Load")


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
    '作成日：2018/01/05 (Fri) 16:24:08 Y.Yoneyama
    '更新日：2018/01/05 (Fri) 16:24:08 Y.Yoneyama
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@初回ﾌｫｰﾑｱｸﾃｨﾌﾞ判定ﾌﾗｸﾞが"True：初回"か
            If mblnFirstActivateFlag = True Then
                '@初回の場合

                '@2回目以降は処理させない為にﾌﾗｸﾞに"False：2回目以降"をｾｯﾄ
                mblnFirstActivateFlag = False

                '@装置ｸﾞﾙｰﾌﾟｺﾝﾎﾞのﾘｽﾄ内容が1件か
                If cmbRestrictType.ListCount = 1 Then

                    '@1件の場合は自動表示する
                    cmbRestrictType.ListIndex = 0

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
    '作成日：2018/01/05 (Fri) 16:24:08 Y.Yoneyama
    '更新日：2018/01/05 (Fri) 16:24:08 Y.Yoneyama
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name

                '@〓 [時間制限ﾀｲﾌﾟ]ｺﾝﾎﾞ 〓
                Case cmbRestrictType.Name

                    '@Enterｷｰか
                    If e.KeyCode = Keys.Return Then

                        '@=======================
                        '@ 時間制限ﾀｲﾌﾟｺﾝﾎﾞのValidate処理
                        '@=======================
                        RemoveHandler cmbRestrictType.Validating,AddressOf cmbRestrictType_Validate
                        Call cmbRestrictType_Validate(cmbRestrictType,New CancelEventArgs(True))
                        AddHandler cmbRestrictType.Validating,AddressOf cmbRestrictType_Validate

                    End If

                '@〓 その他 〓
                Case Else

                    '@Enterの場合
                    If e.KeyCode = Keys.Return Then
                        If ActiveControl IsNot vsfFlow.Editor And ActiveControl IsNot vsfWp.Editor Then
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
    '作成日：2018/01/05 (Fri) 16:24:08 Y.Yoneyama
    '更新日：2018/01/05 (Fri) 16:24:08 Y.Yoneyama
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm                 As Boolean              'ACT開放結果格納用
        Dim ltypPreviousRestrictStatus  As TimeRestrict

        Try

            '@Windowの"×"にて閉じたか
            If mblnCloseFromControlMenu Then

                '@=======================
                '@ 閉じるﾎﾞﾀﾝ処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose,New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload

            End If

            '@ﾓｼﾞｭｰﾙ変数/構造体の初期化
            mtypPreviousRestrictStatus = ltypPreviousRestrictStatus
            
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

    '関数名：cmbRestrictType_Change
    '機　能：[時間制限ﾀｲﾌﾟ]ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/01/11 (Thu) 13:45:26 Y.Yoneyama
    '更新日：2018/01/11 (Thu) 13:45:26 Y.Yoneyama
    '備　考：
    Private Sub cmbRestrictType_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRestrictType.Change

        Dim llngAns                 As Integer      'ﾒｯｾｰｼﾞBOX戻り値格納

        Try 
            
            '@編集中ﾁｪｯｸ
            If (vsfFlow.Rows.Count > vsfFlow.Rows.Fixed Or vsfWp.Rows.Count > vsfWp.Rows.Fixed) _
                And cmdKakutei.Enabled = True Then
                '@編集中の場合

                '@時間制ﾀｲﾌﾟ変更確認
                If mstrPreviousRestrictType <> cmbRestrictType.Value Then

                    '@表示ﾒｯｾｰｼﾞ変換
                    '@"<TRM1AW>$$編集中です。 内容を破棄してよろしいですか？"のﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001A)
                    llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)

                    '@ﾒｯｾｰｼﾞBoxにて「いいえ」が選択されたか
                    If llngAns = vbNo Then

                        '@選択後の設定
                        cmbRestrictType.ListIndex = mlngOldcmbRestrictTypeIndex
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End If
            
            '@選択ｲﾝﾃﾞｯｸｽ保存
            mlngOldcmbRestrictTypeIndex = cmbRestrictType.ListIndex
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbRestrictType_Change"     'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbRestrictType_CloseUp
    '機　能：[時間制限ﾀｲﾌﾟ]ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/01/11 (Thu) 13:46:53 Y.Yoneyama
    '更新日：2018/01/11 (Thu) 13:46:53 Y.Yoneyama
    '備　考：
    Private Sub cmbRestrictType_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRestrictType.CloseUp

        Try


            '@時間制限ﾀｲﾌﾟが選択されているか
            If cmbRestrictType.Text <> vbNullString Then

                '@=======================
                '@ 時間制限ﾀｲﾌﾟｺﾝﾎﾞのValidate処理
                '@=======================
                RemoveHandler cmbRestrictType.Validating,AddressOf cmbRestrictType_Validate
                Call cmbRestrictType_Validate(cmbRestrictType,New CancelEventArgs(True))
                AddHandler cmbRestrictType.Validating,AddressOf cmbRestrictType_Validate

                '@次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
                SendKeys.SendWait(CPstrSendKeysTab)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbRestrictType_CloseUp"    'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbRestrictType_Validate
    '機　能：時間制限ﾀｲﾌﾟｺﾝﾎﾞ　選択確定時処理(Validate処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2018/01/10 (Wed) 15:29:00 Y.Yoneyama
    '更新日：2018/01/10 (Wed) 15:29:00 Y.Yoneyama
    '備　考：
    Private Sub cmbRestrictType_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbRestrictType.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@時間制限ﾀｲﾌﾟが未選択
            If cmbRestrictType.Text = vbNullString Or _
                cmbRestrictType.Value = mstrPreviousRestrictType Then
                
                Exit Sub
            End If

            '@ﾃﾞｰﾀ待避
            mstrPreviousRestrictType = cmbRestrictType.Value

            '@=======================
            '@ 最新取得
            '@=======================
            Call cmdSearch_Click(cmdSearch,New EventArgs)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbRestrictType_Validate"       'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFlow_AfterEdit
    '機　能：ｶﾚﾝﾄ行列変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/01/12 (Fri) 13:41:48 Y.Yoneyama
    '更新日：2018/01/12 (Fri) 13:41:48 Y.Yoneyama
    '備　考：
    Private Sub vsfFlow_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfFlow.AfterEdit

        Try
            With vsfFlow
            
                '@★ 対象列により処理分岐 ★
                Select Case e.Col

                    '@ﾛｯﾄ停止
                    Case CMlngvsfFlowLotStopOn
                        If .GetData(e.Row, e.Col) = CMstrValueOneName Then
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngPinkColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngPinkColor)
                            Dim cellRange As CellRange = .GetCellRange(e.Row, e.Col)
                            cellRange.Style = newStyle
                        Else
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngWhiteColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngWhiteColor)
                            Dim cellRange As CellRange = .GetCellRange(e.Row, e.Col)
                            cellRange.Style = newStyle
                        End If
                End Select
            End With

            '@=======================
            '@ 前回ﾃﾞｰﾀ比較
            '@=======================
            Call prvPreviousData_Chk()
        
            If cmdKakutei.Enabled = True Then
                Call pubSetFocus(cmdKakutei)
            End If
        
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfFlow_AfterEdit"          'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfFlow_EnterCell
    '機　能：ｶﾚﾝﾄ行列変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/01/12 (Fri) 13:12:51 Y.Yoneyama
    '更新日：2018/01/12 (Fri) 13:12:51 Y.Yoneyama
    '備　考：
    Private Sub vsfFlow_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfFlow.EnterCell

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfFlow.Rows.Count <= vsfFlow.Rows.Fixed Then
                Return
            End If

            With vsfFlow

                '@対象行がﾍｯﾀﾞ以外の場合
                If .Row < .Rows.Fixed Then
                    Exit Sub
                End If
         
                '@★ 対象列により処理分岐 ★
                Select Case .Col

                    '@ﾛｯﾄ停止
                    Case CMlngvsfFlowLotStopOn
                        
                        .Cols(CMlngvsfFlowLotStopOn).ComboList = mstrCmbLotStop
                        
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
                .strProcName = "vsfFlow_EnterCell"          'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfWp_AfterEdit
    '機　能：ｶﾚﾝﾄ行列変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/01/12 (Fri) 13:40:40 Y.Yoneyama
    '更新日：2018/01/12 (Fri) 13:40:40 Y.Yoneyama
    '備　考：
    Private Sub vsfWp_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfWp.AfterEdit
        
        Try
            With vsfWp
            
                '@★ 対象列により処理分岐 ★
                Select Case e.Col

                    '@ﾛｯﾄ停止解除
                    Case CMlngvsfWpLotStopOff
                        If .GetData(e.Row, e.Col) = CMstrValueOneName Then
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngPinkColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngPinkColor)
                            Dim cellRange As CellRange = .GetCellRange(e.Row, e.Col)
                            cellRange.Style = newStyle
                        Else
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngWhiteColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngWhiteColor)
                            Dim cellRange As CellRange = .GetCellRange(e.Row, e.Col)
                            cellRange.Style = newStyle
                        End If
                    
                    '@時間制限処理待ﾛｯﾄ在庫数
                    Case CMlngvsfWpWaitLotNum
                        If .GetData(e.Row, e.Col) = vbNullString Or _
                           .GetData(e.Row, e.Col) = CPstrZero Then
                            .SetData(e.Row, e.Col, CMlngWaitLotNumMin)
                        Else
                            .SetData(e.Row, e.Col, CLng(.GetData(e.Row, e.Col)))
                        End If
                End Select
            End With
        
            '@=======================
            '@ 前回ﾃﾞｰﾀ比較
            '@=======================
            Call prvPreviousData_Chk()
        
            If cmdKakutei.Enabled = True Then
                Call pubSetFocus(cmdKakutei)
            End If
        
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfWp_AfterEdit"            'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()
        End Try
    End Sub

    '関数名：vsfWp_EnterCell
    '機　能：ｶﾚﾝﾄ行列変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/01/12 (Fri) 13:20:48 Y.Yoneyama
    '更新日：2018/01/12 (Fri) 13:20:48 Y.Yoneyama
    '備　考：
    Private Sub vsfWP_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfWP.EnterCell

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfWP.Rows.Count <= vsfWP.Rows.Fixed Then
                Return
            End If

            With vsfWp

                '@対象行がﾍｯﾀﾞ以外の場合
                If .Row < .Rows.Fixed Then
                    Exit Sub
                End If
                 
                '@★ 対象列により処理分岐 ★
                Select Case .Col

                    '@ﾛｯﾄ停止解除
                    Case CMlngvsfWpLotStopOff
                        
                        'ﾊﾞｯﾁ装置以外の場合
                        If .GetData(.Row, .Col).ToString <> CMstrLotStopOffFoBatch Then
                            
                            .Cols(CMlngvsfWpLotStopOff).ComboList = mstrCmbLotStop
                        
                            '@ｸﾞﾘｯﾄﾞを編集可能にする
                            .AllowEditing = True
                        Else
                            '@編集不可
                            .AllowEditing = False
                        End If
                                        
                    '@時間制限処理待ﾛｯﾄ在庫数
                    Case CMlngvsfWpWaitLotNum
                        'ﾊﾞｯﾁ装置以外の場合
                        If .GetData(.Row, .Col).ToString <> CMstrWaitLotNumFoBatch Then
                        
                            '@ｸﾞﾘｯﾄﾞを編集可能にする
                            .AllowEditing = True
                        Else
                            '@編集不可
                            .AllowEditing = False
                        End If

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
                .strProcName = "vsfWp_EnterCell"            'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfWp_KeyPressEdit
    '機　能：[装置一覧]ｸﾞﾘｯﾄﾞ　ｷｰ押下時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：未使用
    '戻り値：なし
    '作成日：2018/01/12 (Fri) 13:38:05 Y.Yoneyama
    '更新日：2018/01/12 (Fri) 13:38:05 Y.Yoneyama
    Private Sub vsfWp_KeyPressEdit(ByVal sender As Object, ByVal e As KeyPressEditEventArgs) Handles vsfWp.KeyPressEdit
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfWp.Rows.Count <= vsfWp.Rows.Fixed Then
                Return
            End If

            With vsfWp

                '@対象行がﾍｯﾀﾞ以外の場合
                If .Row < .Rows.Fixed Then
                    Exit Sub
                End If

                Select Case .Col

                    Case CMlngvsfWpWaitLotNum

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
                End Select
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfWp_KeyPressEdit"         'ﾌﾟﾛｼｰｼﾞｬ名
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
    '作成日：2018/01/11 (Thu) 13:11:21 Y.Yoneyama
    '更新日：2018/01/11 (Thu) 13:11:21 Y.Yoneyama
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

            '@時間制限ﾀｲﾌﾟが未選択の場合
            If cmbRestrictType.Text = vbNullString Then
                Exit Sub
            End If
             
            '@取得日時を表示
            lblNowDate.Text = Format$(Now, CPstrDateFormat)
            
            '@ﾎﾞﾀﾝ制御
            cmdKakutei.Enabled = False
                
            '@=======================
            '@ 時間制限流動設定検索
            '@=======================
            Call prvRestrictStatus_Sel()

            '@時間制限ﾀｲﾌﾟを退避する
            mstrPreviousRestrictType = cmbRestrictType.Value
            
            '@閉じるにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(cmdClose)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdSearch_Click"            'ﾌﾟﾛｼｰｼﾞｬ名
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
    '作成日：2018/01/11 (Thu) 15:09:04 Y.Yoneyama
    '更新日：2018/01/11 (Thu) 15:09:04 Y.Yoneyama
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
            llngRet = publngEnd_Proc(CPstrKeyEN02O0, ltypCommonInfo)

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
    '作成日：2018/01/15 (Mon) 10:49:09 Y.Yoneyama
    '更新日：2018/01/15 (Mon) 10:49:09 Y.Yoneyama
    '備　考：
    Private Sub cmdKakutei_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdKakutei.Click

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim llngCnt                 As Integer              'ｶｳﾝﾀ(汎用)
        Dim ltypRestrictStatus      As TimeRestrict         '時間制限流動設定
        Dim llngRow                 As Integer
        
        
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
            '@SBID
            ltypRestrictStatus.strSbID = pstrSBID
            '@制限ﾀｲﾌﾟ
            cmbRestrictType.ValueCol = CMlngCmbRestrictType
            ltypRestrictStatus.strRestrictType = cmbRestrictType.Value
            
            '@構造体初期化
            ltypRestrictStatus.lngFlowListCnt = vsfFlow.Rows.Count - vsfFlow.Rows.Fixed
            ltypRestrictStatus.lngWpListCnt = vsfWp.Rows.Count - vsfWp.Rows.Fixed
            

            If ltypRestrictStatus.typRestrictFlowList Is Nothing Then
                ltypRestrictStatus.typRestrictFlowList = New List(Of typRestrictFlow)
            Else
                ltypRestrictStatus.typRestrictFlowList.Clear
            End If
            If ltypRestrictStatus.typRestrictWpList Is Nothing Then
                ltypRestrictStatus.typRestrictWpList = New List(Of typRestrictWp)
            Else
                ltypRestrictStatus.typRestrictWpList.Clear
            End If
            
            
            '@時間制限流動設定(工程)
            For llngCnt = 0 To ltypRestrictStatus.lngFlowListCnt -1

                Dim typRestrictFlowListTmp As New typRestrictFlow

                llngRow = llngCnt + vsfFlow.Rows.Fixed
            
                typRestrictFlowListTmp.strFromOpId = vsfFlow.GetData(llngRow, CMlngvsfFlowFromOpId)
                typRestrictFlowListTmp.strFromStepId = vsfFlow.GetData(llngRow, CMlngvsfFlowFromStepId)
                typRestrictFlowListTmp.strToOpId = vsfFlow.GetData(llngRow, CMlngvsfFlowToOpId)
                typRestrictFlowListTmp.strToStepId = vsfFlow.GetData(llngRow, CMlngvsfFlowToStepId)
                
                '@ﾛｯﾄ停止
                Select Case vsfFlow.GetData(llngRow, CMlngvsfFlowLotStopOn)
                    '@有効
                    Case CMstrValueOneName
                        typRestrictFlowListTmp.strLotStopOn = CPstrOne
                    
                    '@有効以外
                    Case Else
                        typRestrictFlowListTmp.strLotStopOn = CPstrZero

                End Select

                ltypRestrictStatus.typRestrictFlowList.Add(typRestrictFlowListTmp)
            Next
            
            '@時間制限流動設定(装置)
            For llngCnt = 0 To ltypRestrictStatus.lngWpListCnt -1

                Dim typRestrictWpListTmp As New typRestrictWp

                llngRow = llngCnt + vsfWp.Rows.Fixed
            
                typRestrictWpListTmp.strWpID = vsfWp.GetData(llngRow, CMlngvsfWpID)
                typRestrictWpListTmp.strSeqNum = vsfWp.GetData(llngRow, CMlngvsfWpProcessingId)
                
                '@ﾛｯﾄ停止解除
                Select Case vsfWp.GetData(llngRow, CMlngvsfWpLotStopOff)
                    '@有効
                    Case CMstrValueOneName
                        typRestrictWpListTmp.strLotStopOff = CPstrOne
                    
                    '@有効以外
                    Case Else
                        typRestrictWpListTmp.strLotStopOff = CPstrZero

                End Select
                
                '時間制限処理待在庫数
                If IsNumeric(vsfWp.GetData(llngRow, CMlngvsfWpWaitLotNum)) Then
                    typRestrictWpListTmp.strWaitLotNum = vsfWp.GetData(llngRow, CMlngvsfWpWaitLotNum)
                Else
                    typRestrictWpListTmp.strWaitLotNum = CMlngWaitLotNumMin
                End If

                ltypRestrictStatus.typRestrictWpList.Add(typRestrictWpListTmp)

            Next
            
            '@=======================
            '@編集済み確認
            '@=======================
            '@制限ﾀｲﾌﾟは同じであること
            If ltypRestrictStatus.strRestrictType <> mtypPreviousRestrictStatus.strRestrictType Then
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar00Y0)
                '@"「<TRMY0E>$$システムエラーが発生しました。システム担当者に連絡してください。」"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Exit Sub
            End If
            
            '@時間制限流動設定(工程)は同じであること
            If ltypRestrictStatus.lngFlowListCnt <> mtypPreviousRestrictStatus.lngFlowListCnt Then
                
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar00Y0)
                '@"「<TRMY0E>$$システムエラーが発生しました。システム担当者に連絡してください。」"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Exit Sub
            End If
            
            '@時間制限流動設定(装置)は同じであること
            If ltypRestrictStatus.lngWpListCnt <> mtypPreviousRestrictStatus.lngWpListCnt Then
                
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar00Y0)
                '@"「<TRMY0E>$$システムエラーが発生しました。システム担当者に連絡してください。」"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Exit Sub
            End If
            
            '@時間制限流動設定(工程)
            For llngCnt = 0 To ltypRestrictStatus.lngFlowListCnt -1
                
                'FROM_OP_ID(不変項目)
                If ltypRestrictStatus.typRestrictFlowList(llngCnt).strFromOpId <> mtypPreviousRestrictStatus.typRestrictFlowList(llngCnt).strFromOpId Then
                
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar00Y0)
                    '@"「<TRMY0E>$$システムエラーが発生しました。システム担当者に連絡してください。」"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    Exit Sub
                End If
                
                'FROM_STEP_ID(不変項目)
                If ltypRestrictStatus.typRestrictFlowList(llngCnt).strFromStepId <> mtypPreviousRestrictStatus.typRestrictFlowList(llngCnt).strFromStepId Then
                
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar00Y0)
                    '@"「<TRMY0E>$$システムエラーが発生しました。システム担当者に連絡してください。」"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    Exit Sub
                End If
                
                'TO_OP_ID(不変項目)
                If ltypRestrictStatus.typRestrictFlowList(llngCnt).strToOpId <> mtypPreviousRestrictStatus.typRestrictFlowList(llngCnt).strToOpId Then
                
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar00Y0)
                    '@"「<TRMY0E>$$システムエラーが発生しました。システム担当者に連絡してください。」"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    Exit Sub
                End If
                
                'TO_STEP_ID(不変項目)
                If ltypRestrictStatus.typRestrictFlowList(llngCnt).strToStepId <> mtypPreviousRestrictStatus.typRestrictFlowList(llngCnt).strToStepId Then
                
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar00Y0)
                    '@"「<TRMY0E>$$システムエラーが発生しました。システム担当者に連絡してください。」"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    Exit Sub
                End If
                
                Dim typRestrictFlowListTmp2 As typRestrictFlow = ltypRestrictStatus.typRestrictFlowList(llngCnt)

                '編集ﾌﾗｸﾞ初期化
                typRestrictFlowListTmp2.strEditFlag = CPstrZero
                
                'ﾛｯﾄ停止
                If ltypRestrictStatus.typRestrictFlowList(llngCnt).strLotStopOn <> mtypPreviousRestrictStatus.typRestrictFlowList(llngCnt).strLotStopOn Then
                    typRestrictFlowListTmp2.strEditFlag = CPstrOne
                End If
                            
                ltypRestrictStatus.typRestrictFlowList(llngCnt) = typRestrictFlowListTmp2
            Next
            
            '@時間制限流動設定(装置)
            For llngCnt = 0 To ltypRestrictStatus.lngWpListCnt -1
                
                'WP_ID(不変項目)
                If ltypRestrictStatus.typRestrictWpList(llngCnt).strWpID <> mtypPreviousRestrictStatus.typRestrictWpList(llngCnt).strWpID Then
                
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar00Y0)
                    '@"「<TRMY0E>$$システムエラーが発生しました。システム担当者に連絡してください。」"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    Exit Sub
                End If
                
                'SEQ_NUM(不変項目)
                If ltypRestrictStatus.typRestrictWpList(llngCnt).strSeqNum <> mtypPreviousRestrictStatus.typRestrictWpList(llngCnt).strSeqNum Then
                
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar00Y0)
                    '@"「<TRMY0E>$$システムエラーが発生しました。システム担当者に連絡してください。」"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    Exit Sub
                End If
                        
                Dim typRestrictWpListTmp2 As typRestrictWp = ltypRestrictStatus.typRestrictWpList(llngCnt)

                '編集ﾌﾗｸﾞ初期化
                typRestrictWpListTmp2.strEditFlag = CPstrZero
                
                'ﾛｯﾄ停止解除
                If ltypRestrictStatus.typRestrictWpList(llngCnt).strLotStopOff <> mtypPreviousRestrictStatus.typRestrictWpList(llngCnt).strLotStopOff Then
                    typRestrictWpListTmp2.strEditFlag = CPstrOne
                End If
                            
                If ltypRestrictStatus.typRestrictWpList(llngCnt).strWaitLotNum <> mtypPreviousRestrictStatus.typRestrictWpList(llngCnt).strWaitLotNum Then
                    typRestrictWpListTmp2.strEditFlag = CPstrOne
                End If
                
                ltypRestrictStatus.typRestrictWpList(llngCnt) = typRestrictWpListTmp2
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
                Call pubResponseStart("frmxxEN02O0", "cmdKakutei_Click")


            '@=======================
            '@ 時間制限流動設定登録
            '@=======================
            lblnAns = pubblnRestrictRegist_Upd(CMstrtimeRestrictregistVer, _
                                               pstrSBID, _
                                               pstrUserID, _
                                               ltypRestrictStatus)

            '@通信結果の判定
            If lblnAns = True Then
                '@通信成功の場合

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd("frmxxEN02O0", "cmdKakutei_Click")

                '@=======================
                '@ 最新情報の取得
                '@=======================
                Call cmdSearch_Click(cmdSearch,New EventArgs)

            Else
                '@通信失敗の場合

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel("frmxxEN02O0", "cmdKakutei_Click")
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

    '関数名：prvFrmxxEN02O0_Init
    '機　能：ﾌｫｰﾑ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/01/11 (Thu) 10:40:05 Y.Yoneyama
    '更新日：2018/01/11 (Thu) 10:40:05 Y.Yoneyama
    '備　考：
    Private Sub prvFrmxxEN02O0_Init()

        Dim lstrFormTitle               As String               'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
            
        Try

            '@=======================
            '@ ﾒﾆｭｰ関連付け処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN02O0, lstrFormTitle)

            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@=======================
            '@ ｺﾝﾎﾞﾎﾞｯｸｽ初期化処理
            '@=======================
            Call prvComboBox_Init()

            '@=======================
            '@ 情報表示ｴﾘｱ初期化
            '@=======================
            Call prvDisplay_Init()

            '@=======================
            '@ 変数の初期化
            '@=======================
            mstrPreviousRestrictType = vbNullString              '前回時間制限ﾀｲﾌﾟ退避用変数

            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvFrmxxEN02O0_Init"        'ﾌﾟﾛｼｰｼﾞｬ名
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
    '作成日：2018/01/11 (Thu) 15:04:57 Y.Yoneyama
    '更新日：2018/01/11 (Thu) 15:04:57 Y.Yoneyama
    '備　考：
    Private Sub prvComboBox_Init()

        Try

            '@時間制限ﾀｲﾌﾟｺﾝﾎﾞの初期化
            With cmbRestrictType
                .Clear                                                              'ｺﾝﾎﾞ情報初期化
                .DispCols = CMlngCmbDispCols                                        'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColName                                       'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColID                                       '値取得列
                .DirectInput = False                                                'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)        'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.Font.FontFamily, CMlngCmbGridFontSize, .Font.Style,.Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                      '行の高さ
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter          '左寄中央揃え
                .BackColor = SystemColors.Window
            End With
            
            'ﾛｯﾄ停止用ｺﾝﾎﾞ文字
            mstrCmbLotStop = CMstrValueZeroName & "|" & CMstrValueOneName

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
    '作成日：2018/01/11 (Thu) 15:05:45 Y.Yoneyama
    '更新日：2018/01/11 (Thu) 15:05:45 Y.Yoneyama
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
    '作成日：2018/01/10 (Wed) 15:45:02 Y.Yoneyama
    '更新日：2018/01/10 (Wed) 15:45:02 Y.Yoneyama
    '備　考：
    Private Sub prvLabel_Init()

        Try
            
            lblNowDate.Text = vbNullString
            lblInfo.Text = CMstrvsfWpWiatLotNumT + " 設定：" + CStr(CMlngWaitLotNumMin) + "-" + CStr(CMlngWaitLotNumMax)
            
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
    '作成日：2018/01/05 (Fri) 16:24:08 Y.Yoneyama
    '更新日：2018/01/05 (Fri) 16:24:08 Y.Yoneyama
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
            Call prvvsfFlow_Init()
            Call prvvsfWP_init()
            
            '@各種ﾓｼﾞｭｰﾙ変数の初期化
            mlngOldcmbRestrictTypeIndex = -1                '前回装置名ｺﾝﾎﾞのINDEX退避用変数の初期化

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

    '関数名：prvvsfFlow_Init
    '機　能：時間制限工程ｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/01/10 (Wed) 16:06:48 Y.Yoneyama
    '更新日：2018/01/10 (Wed) 16:06:48 Y.Yoneyama
    '備　考：
    Private Sub prvvsfFlow_Init()

        Try

            '@=======================
            '@ ｸﾞﾘｯﾄﾞの初期化
            '@=======================
            With vsfFlow

                '@内容初期化
                .Clear(ClearFlags.Content)
                
                .Styles.Focus.Clear()

                '@行数、列数の初期設定
                .Rows.Fixed = 2
                .Rows.Count = 2
                .Cols.Count = 8
                .AllowMerging = AllowMergingEnum.FixedOnly

                '@行ﾏｰｼﾞﾍｯﾀﾞ作成(1段目)
                .Rows(0).AllowMerging = True
                .SetData(0, CMlngvsfFlowLotStopOn, "時間制限・開始工程")
                .SetData(0, CMlngvsfFlowFromOpId, "時間制限・開始工程")
                .SetData(0, CMlngvsfFlowFromStepId, "時間制限・開始工程")

                .SetData(0, CMlngvsfFlowToOpId, "時間制限・終了工程")
                .SetData(0, CMlngvsfFlowToStepId, "時間制限・終了工程")

                '@行ﾏｰｼﾞﾍｯﾀﾞ作成(2段目)
                .SetData(1, CMlngvsfFlowLotStopOn, CMstrvsfFlowLotStopOnT)
                .SetData(1, CMlngvsfFlowFromOpId, CMstrvsfFlowFromOpIdT)
                .SetData(1, CMlngvsfFlowFromStepId, CMstrvsfFlowFromStepIdT)
                .SetData(1, CMlngvsfFlowToOpId, CMstrvsfFlowToOpIdT)
                .SetData(1, CMlngvsfFlowToStepId, CMstrvsfFlowToStepIdT)

                '@列ﾏｰｼﾞﾍｯﾀﾞ作成
                .Cols(CMlngvsfFlowSeqNum).AllowMerging = True
                .Cols(CMlngvsfFlowEditTime).AllowMerging = True
                .Cols(CMlngvsfFlowEmpName).AllowMerging = True
                .SetData(0, CMlngvsfFlowSeqNum, CMstrvsfFlowSeqNumT)
                .SetData(0, CMlngvsfFlowEditTime,  CMstrvsfFlowEditTimeT)
                .SetData(0, CMlngvsfFlowEmpName,  CMstrvsfFlowEmpNameT)
                .SetData(1, CMlngvsfFlowSeqNum, CMstrvsfFlowSeqNumT)
                .SetData(1, CMlngvsfFlowEditTime,  CMstrvsfFlowEditTimeT)
                .SetData(1, CMlngvsfFlowEmpName,  CMstrvsfFlowEmpNameT)

                '@非表示列の設定

                '@ﾀｲﾄﾙの設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_vsfFlow_Headerstyle")
                Dim cellRange As CellRange = .GetCellRange(0, 0, 1, .Cols.Count - 1)
                newStyle.ForeColor = Color.Yellow
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
                newStyle.TextAlign = TextAlignEnum.CenterCenter
                cellRange.Style = newStyle

                '@使用不可設定
                .Enabled = False

                '@ﾘﾌﾚｯｼｭする
                .Refresh

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvvsfFlow_Init"            'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfWp_Init
    '機　能：ﾛｯﾄｸﾞﾘｯﾄﾞ初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/01/05 (Fri) 16:24:08 Y.Yoneyama
    '更新日：2018/01/05 (Fri) 16:24:08 Y.Yoneyama
    '備　考：
    Private Sub prvvsfWP_init()

        Try

            '@=======================
            '@ ｸﾞﾘｯﾄﾞの初期化
            '@=======================
            With vsfWp

                '@内容初期化
                .Clear(ClearFlags.Content)
                        
                .Styles.Focus.Clear()

                '@行数、列数の初期設定
                .Rows.Fixed = 2
                .Rows.Count = 2
                .Cols.Count = 9
                .AllowMerging = AllowMergingEnum.FixedOnly

                '@行ﾏｰｼﾞﾍｯﾀﾞ作成(1段目)
                .Rows(0).AllowMerging = True
                .SetData(0, CMlngvsfWpID, "時間制限・終了工程")
                .SetData(0, CMlngvsfWpName, "時間制限・終了工程")
                .SetData(0, CMlngvsfWpProcessingId, "時間制限・終了工程")
                .SetData(0, CMlngvsfWpProcessingName, "時間制限・終了工程")
                .SetData(0, CMlngvsfWpLotStopOff, "時間制限・終了工程")
                .SetData(0, CMlngvsfWpWaitLotNum, "時間制限・終了工程")

                '@行ﾏｰｼﾞﾍｯﾀﾞ作成(2段目)
                .SetData(1, CMlngvsfWpID, CMstrvsfWpIdT)
                .SetData(1, CMlngvsfWpName, CMstrvsfWpNameT)
                .SetData(1, CMlngvsfWpProcessingId, CMstrvsfWpProcessingIdT)
                .SetData(1, CMlngvsfWpProcessingName, CMstrvsfWpProcessingNameT)
                .SetData(1, CMlngvsfWpLotStopOff, CMstrvsfWpLotStopOffT)
                .SetData(1, CMlngvsfWpWaitLotNum, CMstrvsfWpWiatLotNumT)
                
                '@列ﾏｰｼﾞﾍｯﾀﾞ作成
                .Cols(CMlngvsfWpSeqNum).AllowMerging = True
                .Cols(CMlngvsfWpEditTime).AllowMerging = True
                .Cols(CMlngvsfWpEmpName).AllowMerging = True
                .SetData(0, CMlngvsfWpSeqNum, CMstrvsfWpSeqNumT)
                .SetData(0, CMlngvsfWpEditTime, CMstrvsfWpEditTimeT)
                .SetData(0, CMlngvsfWpEmpName, CMstrvsfWpEmpNameT)
                .SetData(1, CMlngvsfWpSeqNum, CMstrvsfWpSeqNumT)
                .SetData(1, CMlngvsfWpEditTime, CMstrvsfWpEditTimeT)
                .SetData(1, CMlngvsfWpEmpName, CMstrvsfWpEmpNameT)

                '@非表示列の設定
                .Cols(CMlngvsfWpID).Visible = False
                .Cols(CMlngvsfWpProcessingId).Visible = False
                
                '@ﾀｲﾄﾙの設定
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_vsfWp_HeaderStyle")
                Dim cellRange As CellRange = .GetCellRange(0, 0, 1, .Cols.Count - 1)
                newStyle.ForeColor = Color.Yellow
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)
                newStyle.TextAlign = TextAlignEnum.CenterCenter
                cellRange.Style = newStyle

                '@使用不可設定
                .Enabled = False

                '@ﾘﾌﾚｯｼｭする
                .Refresh

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvvsfFlow_Init"            'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbRestrictType_Disp
    '機　能：時間制限ﾀｲﾌﾟｺﾝﾎﾞの設定
    '引　数：なし
    '戻り値：なし
    '作成日：2018/01/10 (Wed) 15:22:49 Y.Yoneyama
    '更新日：2018/01/10 (Wed) 15:22:49 Y.Yoneyama
    '備　考：
    Private Sub prvcmbRestrictType_Disp()

        Try
            
            '@ｺﾝﾎﾞ設定
            cmbRestrictType.AddItem(CPstrRestrictTypeName_1 & vbTab & CPlngRestrictType_1)
            cmbRestrictType.AddItem(CPstrRestrictTypeName_2 & vbTab & CPlngRestrictType_2)
            
            '@1件目表示
            cmbRestrictType.ListIndex = -1
                    
            '@=======================
            '@Validate処理
            '@=======================
            RemoveHandler cmbRestrictType.Validating,AddressOf cmbRestrictType_Validate
            Call cmbRestrictType_Validate(cmbRestrictType,NEw CancelEventArgs(True))
            AddHandler cmbRestrictType.Validating,AddressOf cmbRestrictType_Validate
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmbRestrictType_Disp"    'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvRestrictStatus_Sel
    '機　能：時間制限流動設定取得
    '引　数：なし
    '戻り値：なし
    '作成日：2018/01/05 (Fri) 16:24:08 Y.Yoneyama
    '更新日：2018/01/05 (Fri) 16:24:08 Y.Yoneyama
    '備　考：
    Private Sub prvRestrictStatus_Sel()

        Dim lblnAns                     As Boolean
        Dim ltypRestrictStatus          As TimeRestrict
        
        
        Try

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart("frmxxEN02O0", "prvRestrictStatus_Sel")
            
            '@=======================
            '@ 選択項目の無効化
            '@=======================
            cmdSearch.Enabled = False
            cmbRestrictType.Enabled = False
            vsfFlow.Enabled = False
            vsfWp.Enabled = False
            
            '@時間制限ﾀｲﾌﾟｺﾝﾎﾞの値取変更
            cmbRestrictType.ValueCol = CMlngCmbRestrictType

            '@=======================
            '@ 時間制限流動設定取得
            '@=======================
            lblnAns = pubblnRestrictStatus_Sel(CMstrtimeRestrictstatusVer, _
                                              pstrSBID, _
                                              cmbRestrictType.Value, _
                                              ltypRestrictStatus)
            
            '@通信失敗の場合
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽ取得中止
                Call pubResponseCancel("frmxxEN02O0", "prvRestrictStatus_Sel")
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd("frmxxEN02O0", "prvRestrictStatus_Sel")
            
            '編集箇所の比較用でﾃﾞｰﾀ保持
            mtypPreviousRestrictStatus = ltypRestrictStatus
            
            '@=======================
            '@ 時間制限流動設定(工程)表示
            '@=======================
            Call prvRestrictFlow_Disp(ltypRestrictStatus)
            
            '@=======================
            '@ 時間制限流動設定(装置)表示
            '@=======================
            Call prvRestrictWp_Disp(ltypRestrictStatus)
            
            '@=======================
            '@ 選択項目の有効化
            '@=======================
            cmdSearch.Enabled = True
            cmbRestrictType.Enabled = True

            '@時間制限工程にﾃﾞｰﾀが1件以上ある場合
            If vsfFlow.Rows.Count > vsfFlow.Rows.Fixed Then
                vsfFlow.Enabled = True
            End If
            
            '@時間制限装置にﾃﾞｰﾀが1件以上ある場合
            If vsfWp.Rows.Count > vsfWp.Rows.Fixed Then
                vsfWp.Enabled = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvRestrictStatus_Sel"         'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvRestrictFlow_Disp
    '機　能：時間制限流動設定(工程)表示
    '引　数：ltypRestrictStatus
    '戻り値：なし
    '作成日：2018/01/11 (Thu) 13:16:33 Y.Yoneyama
    '更新日：2018/01/11 (Thu) 13:16:33 Y.Yoneyama
    '備　考：
    Private Sub prvRestrictFlow_Disp(ByRef ltypRestrictStatus As TimeRestrict)

        Dim llngCnt                     As Integer
        Dim llngRow                     As Integer
        
        Try
                    
            '@=======================
            '@ 工程表示
            '@=======================
            With vsfFlow
            
                .Redraw = False

                '@行数の設定
                .Rows.Count = ltypRestrictStatus.lngFlowListCnt + .Rows.Fixed
                
                '@時間制限流動設定(工程)表示
                For llngCnt = 0 To ltypRestrictStatus.lngFlowListCnt -1
                
                    llngRow = llngCnt + .Rows.Fixed
                    
                    '@高さ設定
                    .Rows(llngRow).Height = CMlngGridRowHeight
                
                    .SetData(llngRow, CMlngvsfFlowSeqNum, CStr(llngRow -1))
                    .SetData(llngRow, CMlngvsfFlowFromOpId, ltypRestrictStatus.typRestrictFlowList(llngCnt).strFromOpId)
                    .SetData(llngRow, CMlngvsfFlowFromStepId, ltypRestrictStatus.typRestrictFlowList(llngCnt).strFromStepId)
                    .SetData(llngRow, CMlngvsfFlowToOpId, ltypRestrictStatus.typRestrictFlowList(llngCnt).strToOpId)
                    .SetData(llngRow, CMlngvsfFlowToStepId, ltypRestrictStatus.typRestrictFlowList(llngCnt).strToStepId)
                    Select Case ltypRestrictStatus.typRestrictFlowList(llngCnt).strLotStopOn
                        Case CPstrOne
                            .SetData(llngRow, CMlngvsfFlowLotStopOn, CMstrValueOneName)
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngPinkColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngPinkColor)
                            Dim cellRange As CellRange = .GetCellRange(llngRow, CMlngvsfFlowLotStopOn)
                            cellRange.Style = newStyle
                        Case Else
                            .SetData(llngRow, CMlngvsfFlowLotStopOn, CMstrValueZeroName)
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngWhiteColor")
                            newStyle.BackColor = ColorTranslator.FromWin32(CPlngWhiteColor)
                            Dim cellRange As CellRange = .GetCellRange(llngRow, CMlngvsfFlowLotStopOn)
                            cellRange.Style = newStyle
                    End Select
                    .SetData(llngRow, CMlngvsfFlowEditTime, ltypRestrictStatus.typRestrictFlowList(llngCnt).strEditTime)
                    .SetData(llngRow, CMlngvsfFlowEmpName, ltypRestrictStatus.typRestrictFlowList(llngCnt).strEditEmpName)
                
                Next llngCnt
                
                '@自動列幅設定=自動調整する
                .AutoSizeCols(CMlngvsfFlowSeqNum, .Cols.Count - 1, 6)
            
                .Row = 0

                .Redraw = True

            End With
             
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvRestrictFlow_Disp"       'ﾌﾟﾛｼｰｼﾞｬ名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvRestrictWp_Disp
    '機　能：時間制限流動設定(装置)表示
    '引　数：ltypRestrictStatus
    '戻り値：なし
    '作成日：2018/01/11 (Thu) 13:35:01 Y.Yoneyama
    '更新日：2018/01/11 (Thu) 13:35:01 Y.Yoneyama
    '備　考：
    Private Sub prvRestrictWp_Disp(ByRef ltypRestrictStatus As TimeRestrict)

        Dim llngCnt                     As Integer
        Dim llngRow                     As Integer
        Dim llngRestrictType            As Integer
            
        Try
            
            
            '@制限ﾀｲﾌﾟ
            cmbRestrictType.ValueCol = CMlngCmbRestrictType
            llngRestrictType = cmbRestrictType.Value
            
            '@=======================
            '@ 装置表示
            '@=======================
            With vsfWp
                
                .Redraw = True

                'ﾊﾞｯﾁ装置の場合
                If llngRestrictType = CPlngRestrictType_2 Then
                    '@ﾗﾍﾞﾙ変更
                    lblInfo.Text = CMstrvsfWpLotStopOffT + "「ﾊﾞｯﾁ編成方式：自動」の場合有効"
                    '@ﾀｲﾄﾙ変更
                    .SetData(1, CMlngvsfWpWaitLotNum, CMstrvsfWpWiatLotNumBatchT)
                Else
                    '@ﾗﾍﾞﾙ変更
                    lblInfo.Text = CMstrvsfWpWiatLotNumT + " 設定：" + CStr(CMlngWaitLotNumMin) + "-" + CStr(CMlngWaitLotNumMax)
                    '@ﾀｲﾄﾙ変更
                    .SetData(1, CMlngvsfWpWaitLotNum, CMstrvsfWpWiatLotNumT)
                End If
                
                '@行数の設定
                .Rows.Count = ltypRestrictStatus.lngWpListCnt + .Rows.Fixed
                
                '@時間制限流動設定(装置)表示
                For llngCnt = 0 To ltypRestrictStatus.lngWpListCnt -1
                    
                    llngRow = llngCnt + .Rows.Fixed
                            
                    '@高さ設定
                    .Rows(llngRow).Height = CMlngGridRowHeight
                                        
                    .SetData(llngRow, CMlngvsfWpSeqNum, CStr(llngRow -1))
                    .SetData(llngRow, CMlngvsfWpID, ltypRestrictStatus.typRestrictWpList(llngCnt).strWpID)
                    .SetData(llngRow, CMlngvsfWpName, ltypRestrictStatus.typRestrictWpList(llngCnt).strWpName)
                    .SetData(llngRow, CMlngvsfWpProcessingId, ltypRestrictStatus.typRestrictWpList(llngCnt).strSeqNum)
                    .SetData(llngRow, CMlngvsfWpProcessingName, ltypRestrictStatus.typRestrictWpList(llngCnt).strProcessingName)
                    '制限ﾀｲﾌﾟにより内容変更
                    'ﾊﾞｯﾁ装置の場合は設定なし
                    If llngRestrictType = CPlngRestrictType_2 Then
                        '@時間制限処理待ち在庫数
                        .SetData(llngRow, CMlngvsfWpWaitLotNum, CMstrWaitLotNumFoBatch)
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_TextAlign_LeftCenter")
                        newStyle.TextAlign = TextAlignEnum.LeftCenter
                        Dim cellRange As CellRange = .GetCellRange(llngRow, CMlngvsfWpWaitLotNum)
                        cellRange.Style = newStyle

                        '@ﾛｯﾄ保留解除
                        .SetData(llngRow, CMlngvsfWpLotStopOff, CMstrLotStopOffFoBatch)
                        Dim newStyle2 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngWhiteColor")
                        newStyle2.BackColor = ColorTranslator.FromWin32(CPlngWhiteColor)
                        Dim cellRange2 As CellRange = .GetCellRange(llngRow, CMlngvsfWpLotStopOff)
                        cellRange2.Style = newStyle2
                                       
                    Else
                        '@時間制限処理待ち在庫数
                        .SetData(llngRow, CMlngvsfWpWaitLotNum, ltypRestrictStatus.typRestrictWpList(llngCnt).strWaitLotNum)
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_TextAlign_RightCenter")
                        newStyle.TextAlign = TextAlignEnum.RightCenter
                        Dim cellRange As CellRange = .GetCellRange(llngRow, CMlngvsfWpWaitLotNum)
                        cellRange.Style = newStyle

                        '@ﾛｯﾄ保留解除
                        Select Case ltypRestrictStatus.typRestrictWpList(llngCnt).strLotStopOff
                            Case CPstrOne
                                .SetData(llngRow, CMlngvsfWpLotStopOff, CMstrValueOneName)
                                Dim newStyle2 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngPinkColor")
                                newStyle2.BackColor = ColorTranslator.FromWin32(CPlngPinkColor)
                                Dim cellRange2 As CellRange = .GetCellRange(llngRow, CMlngvsfWpLotStopOff)
                                cellRange2.Style = newStyle2
                            Case Else
                                .SetData(llngRow, CMlngvsfWpLotStopOff, CMstrValueZeroName)
                                Dim newStyle2 As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngWhiteColor")
                                newStyle2.BackColor = ColorTranslator.FromWin32(CPlngWhiteColor)
                                Dim cellRange2 As CellRange = .GetCellRange(llngRow, CMlngvsfWpLotStopOff)
                                cellRange2.Style = newStyle2
                        End Select
                    End If
                    .SetData(llngRow, CMlngvsfWpEditTime, ltypRestrictStatus.typRestrictWpList(llngCnt).strEditTime)
                    .SetData(llngRow, CMlngvsfWpEmpName, ltypRestrictStatus.typRestrictWpList(llngCnt).strEditEmpName)
                Next llngCnt
                
                '@自動列幅設定=自動調整する
                .AutoSizeCols(CMlngvsfWpSeqNum, .Cols.Count - 1, 6)
                 
                .Row = 0

                .Redraw = True

            End With
             
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvRestrictWp_Disp"         'ﾌﾟﾛｼｰｼﾞｬ名
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
    '作成日：2018/01/12 (Fri) 14:11:35 Y.Yoneyama
    '更新日：2018/01/12 (Fri) 14:11:35 Y.Yoneyama
    '備　考：
    Private Sub prvPreviousData_Chk()

        Dim llngCnt                 As Integer      'ｶｳﾝﾀ(汎用)
        Dim llngRow                 As Integer


        Try
            
            
            '@確定ﾎﾞﾀﾝ無効
            cmdKakutei.Enabled = False
            
            '@装置ｸﾞﾘｯﾄﾞ入力ﾁｪｯｸ
            With vsfWp
                For llngCnt = 0 To .Rows.Count - .Rows.Fixed -1
                
                    llngRow = llngCnt + .Rows.Fixed
                
                    '@処理待在庫数
                    '@数値ﾁｪｯｸ
                    If IsNumeric(.GetData(llngRow, CMlngvsfWpWaitLotNum)) Then
                        '@設定範囲ﾁｪｯｸ
                        If CLng(.GetData(llngRow, CMlngvsfWpWaitLotNum)) > CMlngWaitLotNumMax Or _
                            CLng(.GetData(llngRow, CMlngvsfWpWaitLotNum)) < CMlngWaitLotNumMin Then
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            '@"<TRM147W>$$<TRM147W>$$[%1]が[%2]の為、確定できません。"のﾒｯｾｰｼﾞ表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0147, CMstrvsfWpWiatLotNumT, "設定範囲外")
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit Sub
                        End If
                    End If
                Next llngCnt
            End With
            
            '変更箇所ﾁｪｯｸ
            '@工程
            For llngCnt = 0 To mtypPreviousRestrictStatus.lngFlowListCnt -1
                '@工程ｸﾞﾘｯﾄﾞ
                With vsfFlow
                
                    llngRow = llngCnt + .Rows.Fixed
                
                    '@ﾛｯﾄ停止(有効)
                    If .GetData(llngRow, CMlngvsfFlowLotStopOn) = CMstrValueOneName Then
                        If mtypPreviousRestrictStatus.typRestrictFlowList(llngCnt).strLotStopOn <> CPstrOne Then
                            '@確定ﾎﾞﾀﾝ有効
                            cmdKakutei.Enabled = True
                            Exit Sub
                        End If
                    Else
                        If mtypPreviousRestrictStatus.typRestrictFlowList(llngCnt).strLotStopOn <> CPstrZero Then
                            '@確定ﾎﾞﾀﾝ有効
                            cmdKakutei.Enabled = True
                            Exit Sub
                        End If
                    End If
            
                End With
            Next
            
            '@装置
            For llngCnt = 0 To mtypPreviousRestrictStatus.lngWpListCnt -1
                '@装置ｸﾞﾘｯﾄﾞ
                With vsfWp
                
                    llngRow = llngCnt + .Rows.Fixed
                
                    '@ﾛｯﾄ停止解除(有効)
                    If .GetData(llngRow, CMlngvsfWpLotStopOff) = CMstrValueOneName Then
                        If mtypPreviousRestrictStatus.typRestrictWpList(llngCnt).strLotStopOff <> CPstrOne Then
                            '@確定ﾎﾞﾀﾝ有効
                            cmdKakutei.Enabled = True
                            Exit Sub
                        End If
                    Else
                        If mtypPreviousRestrictStatus.typRestrictWpList(llngCnt).strLotStopOff <> CPstrZero Then
                            '@確定ﾎﾞﾀﾝ有効
                            cmdKakutei.Enabled = True
                            Exit Sub
                        End If
                    End If
                    
                    '数値入力の場合
                    If IsNumeric(.GetData(llngRow, CMlngvsfWpWaitLotNum)) Then
                        '@処理待在庫数
                        If CLng(.GetData(llngRow, CMlngvsfWpWaitLotNum)) <> _
                            CLng(mtypPreviousRestrictStatus.typRestrictWpList(llngCnt).strWaitLotNum) Then
                            '@確定ﾎﾞﾀﾝ有効
                            cmdKakutei.Enabled = True
                            Exit Sub
                        End If
                    End If
                End With
            Next
            
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraRestrictFlow.Paint, fraRestrictWp.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfFlow.BeforeDoubleClick, vsfWp.BeforeDoubleClick

        ' ObjectをGridに変換
        Dim gridObj As C1FlexGrid
        gridObj = CType(sender, C1FlexGrid)

        'ダブルクリックした箇所が列の境界線かを判断する
        If gridObj.HitTest(e.X,e.Y).Type = HitTestTypeEnum.ColumnResize Then

            '列の境界線の場合、本来の処理をキャンセル
            e.Cancel = True

        End If

        If gridObj.Name = vsfWp.Name Then
            If gridObj.Col <> CMlngvsfWpWaitLotNum Then
                If gridObj.HitTest(e.X,e.Y).Type = HitTestTypeEnum.Cell Then
                    '本来の処理をキャンセル
                    e.Cancel = True
                ElseIf gridObj.HitTest(e.X,e.Y).Type = HitTestTypeEnum.EditButton Then
                    '本来の処理をキャンセル
                    e.Cancel = True
                End If
            End If
        Else
            If gridObj.HitTest(e.X,e.Y).Type = HitTestTypeEnum.Cell Then
                '本来の処理をキャンセル
                e.Cancel = True
            ElseIf gridObj.HitTest(e.X,e.Y).Type = HitTestTypeEnum.EditButton Then
                '本来の処理をキャンセル
                e.Cancel = True
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
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfFlow.KeyDownEdit, vsfWp.KeyDownEdit

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
    Private Sub flex_SetupEditor(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfFlow.SetupEditor,vsfWp.SetupEditor

        Try

            If TypeOf sender.Editor Is TextBox
                With vsfWp
                    Select  Case .Col
                        '@時間制限処理待ﾛｯﾄ在庫数
                        Case CMlngvsfWpWaitLotNum
                            'ﾊﾞｯﾁ装置以外の場合
                            If .GetData(.Row, .Col) <> CMstrWaitLotNumFoBatch Then
                            
                                '入力数3桁
                                CType(.Editor, Object).MaxLength = CMlngWaitLotNumLength
                            
                            End If
                    End Select

                    mstrOldGridEditorText = .GetData(e.Row, e.Col) 

                End With
            End If 

        Catch ex As Exception
            '異常終了した場合は何もしない

        End Try

    End Sub
        '関数名：vsfWp_ChangeEdit			
    '機　能：ﾊﾟﾗﾒｰﾀﾘｽﾄ 編集変更時			
    '引　数：sender ：イベント発生元			
    '　　　：e      ：イベントオブジェクト			
    '戻り値：なし			
    '作成日：2019/03/08 (Fri) 12:00:00 NSYS			
    '更新日：			
    '備　考：			
    Private Sub vsfWp_ChangeEdit(ByVal sender As Object, ByVal e As EventArgs) Handles vsfWp.ChangeEdit			
        Try			
			
            With vsfWp			
            			
                Select Case .Col			
                    Case CMlngvsfWpWaitLotNum		
			            'ﾊﾞｯﾁ装置以外の場合
                        If .GetData(.Row, .Col).ToString <> CMstrWaitLotNumFoBatch Then
                            'テキスト長を文字数でなくバイト数で切り詰める			
                            '内部で .Editor.Text への代入処理があるので、イベント再帰を回避する			
                            RemoveHandler vsfWp.ChangeEdit, AddressOf vsfWp_ChangeEdit			
                            pubTextBoxLimit_Set(CType(.Editor, TextBox), mstrOldGridEditorText)			
                            AddHandler vsfWp.ChangeEdit, AddressOf vsfWp_ChangeEdit			
			
                            '@編集前文字列の設定			
                            mstrOldGridEditorText = vsfWp.Editor.Text	
                        End If
                End Select			
                    			
            End With			
			
            Exit Sub			
        Catch ex As Exception			
            '@共通ｴﾗｰ処理			
            Call pubCommonOnError_Proc(CPstrKeyMST, Me.Name, "vsfWp_ChangeEdit", vbNullString)			
        End Try			
			
    End Sub			
    Private Sub flexGrid_Leave(sender As Object, e As EventArgs) Handles vsfFlow.Leave,vsfWp.Leave
        
        Dim CMlngTopRow As Integer

        Try

            with sender
                CMlngTopRow = .TopRow
                .Col = 0
                .AllowEditing = False
                .TopRow = CMlngTopRow
            End With

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID　strProcName：関数名　strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "flexGrid_Leave"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try

    End Sub
End Class
