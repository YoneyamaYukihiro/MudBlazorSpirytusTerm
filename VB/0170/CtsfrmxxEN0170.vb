'ﾌｧｲﾙ名：xxEN0170.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ロット終了(ロットアウト)
'作成日：2004/04/19 (Mon) 16:40:26 S.Deguchi
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2018, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN0170
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN0170    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN0170
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN0170
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN0170)
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
    '======================================Private==========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2011/10/31 (Mon) 14:45:06 T.Oide **************************************************
    '@↓2020/03/06 (Fri) 11:34:13 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion                     As String = "08.02"
    Private Const CMstrLocalVersion                     As String = "09.00"
    '@↑2020/03/06 (Fri) 11:34:13 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN0170      'ﾛｰｶﾙﾒﾆｭｰKey

    '@Msgﾊﾞｰｼﾞｮﾝ
    '@↓2020/01/15 (Wed) 14:13:07 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_curstateVer          As String = "03.04"         'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer          As String = "04.00"         'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 14:13:07 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrlot_terminateVer                 As String = "03.01"             'ﾛｯﾄ終了
    Private Const CMstrmas_scplist_Ver                  As String = "03.00"             '不良項目入力項目取得
    Private Const CMstrmas_reasoncodeVer                As String = "02.00"             '理由ｺｰﾄﾞ取得
    Private Const CMstrmas_empname_Ver                  As String = "02.01"             '作業者名取得

    Private Const CMlngCarrierMaxLength                 As Integer = 6                     'ｷｬﾘｱIDの最大桁数(6桁)
    Private Const CMlngScrapIndex                       As Integer = 0                     '終了理由:不良(optScrapHoldTake:Index=0)
    Private Const CMlngHoldIndex                        As Integer = 1                     '終了理由:保留(optScrapHoldTake:Index=1)
    Private Const CMlngTakeIndex                        As Integer = 2                     '終了理由:払出(optScrapHoldTake:Index=2)

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                      As Integer = 16                    'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Integer = 16                    'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColName                   As Integer = 0                     '名称列番
    Private Const CMlngCmbGridColID                     As Integer = 1                     'ID列番(非表示項目)
    Private Const CMlngCmbSortAsc                       As Integer = 1                     '昇順(ｿｰﾄ)
    Private Const CMlngCmbDispCols                      As Integer = 1                     'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbRowHeight                     As Integer = 43                    'ﾘｽﾄ行の高さ
    Private Const CMlngCmbClearListIndex                As Integer = -1                    'ﾃｷｽﾄ値初期化
    Private Const CMstrCmbFontName                      As String  = "ＭＳ ゴシック"       'NSYS FontName

    '@ｺﾝﾎﾞ取得Col
    Private Const CMlngGetValueCol                      As Integer = 1                     '取得Col数

    '@表示ﾒｯｾｰｼﾞ
    Private Const CMstrEmpIDTitle                       As String = "終了責任者ID"      '終了責任者ID

    '@ﾃｷｽﾄ表示制御用
    Private Const CMlngMaxDispMemoRow                   As Integer = 3                     'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(作業ﾒﾓ)

    '@ﾚｽﾎﾟﾝｽ,引継ぎ用ｲﾍﾞﾝﾄ定数
    Private Const CMstrFormName                         As String = "frmxxEN0170"           '自ﾌｫｰﾑ名
    Private Const CMstrTxtCarrierValidate               As String = "txtCarrier_Validate"   'ｷｬﾘｱ確定時処理
    Private Const CMstrCmdRegistClick                   As String = "cmdRegist_Click"       '確定ﾎﾞﾀﾝ押下時処理
    Private Const CMstrPrvblnReasonCodeSel              As String = "prvblnReasonCode_Sel"  '終了理由取得処理

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '@退避情報
    Private mstrTaihiCarrierID                          As String                       'ﾛｯﾄ情報取得時のｷｬﾘｱID
    Private mstrTaihiOpID                               As String                       'ﾛｯﾄ情報取得時の大工程ID
    Private mstrTaihiStepID                             As String                       'ﾛｯﾄ情報取得時の小工程ID
    Private mstrTaihiLotScrapSetID                      As String                       'ﾛｯﾄ情報取得時の不良項目ｾｯﾄID
    Private mstrTaihiEndReason                          As String                       'ﾛｯﾄの終了理由(ClassID)
    Private mstrTaihiEndCode                            As String                       'ﾛｯﾄの終了理由ｺｰﾄﾞID
    Private mstrTaihiEndReasonName                      As String                       'ﾛｯﾄの終了理由名称
    Private mblnTakeOverDispFlg                         As Boolean                      '引継ぎ表示ﾌﾗｸﾞ
    Private mstrLotLastUpdate                           As String                       '最終更新日時退避

    '@終了要因ｺｰﾄﾞ
    Private mtypScrapList                               As MasItemList                  '不良要因ｺｰﾄﾞ
    Private mtypHoldList                                As MasItemList                  '保留要因ｺｰﾄﾞ
    Private mtypTakeList                                As MasItemList                  '払出要因ｺｰﾄﾞ
    
    Private buttonProcessing                            As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                      'NSYS WindowCloseフラグ

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
    '機　能：ﾌｫｰﾑ　Load時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/19 (Mon) 10:36:36 S.Deguchi
    '更新日：2008/04/24 (Thu) 11:32:22 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 15:08:53 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2008/04/24 (Thu) 11:32:22 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub Form_Load()
        
        Dim lblnAns         As Boolean      '戻り値

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@=======================
            '@　機能ﾊﾞｰｼﾞｮﾝ判定処理
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN0170, CMstrLocalVersion)
            
            '@処理結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                
                '@=======================
                '@　ﾒｲﾝﾒﾆｭｰ画面拡張処理
                '@=======================
                Call pubMenuExpand_Disp()
                
                '@=======================
                '@　ﾌｫｰﾑ終了時処理
                '@=======================
                Call Form_QueryUnload(False, New FormClosingEventArgs(CloseReason.UserClosing,  False))
                
                '@Escﾎﾞﾀﾝを有効にする
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@=======================
            '@　画面情報初期化処理
            '@=======================
            Call prvfrmxxEN0170_Init()
            
            '@各種ﾎﾞﾀﾝの制御
            cmdUP.Enabled = False           '上ｽｸﾛｰﾙﾎﾞﾀﾝ
            cmdDown.Enabled = False         '下ｽｸﾛｰﾙﾎﾞﾀﾝ
            cmdRegist.Enabled = False       '確定ﾎﾞﾀﾝ
            
            '@ｷｬﾘｱIDの初期化
            txtCarrier.Text = vbNullString
            
            '@閉じるﾎﾞﾀﾝ押下時にValidate処理が走行しないようにする
            cmdClose.CausesValidation = False
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
            
            '@引継ぎ情報表示済みﾌﾗｸﾞに"False：未完"をｾｯﾄ
            mblnTakeOverDispFlg = False
            
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = 0

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
    '機　能：ﾌｫｰﾑ　ｱｸﾃｨﾌﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 15:53:59 H.Wajima
    '更新日：2008/04/24 (Thu) 11:36:37 N.Kojima
    '備　考：
    '　　　：2008/04/24 (Thu) 11:36:37 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            '@FormLoad後、最初の1回しか処理しない為、
            '@引継ぎ情報表示済みﾌﾗｸﾞが"True：表示済"か判定する
            If mblnTakeOverDispFlg = True Then
                '@引継ぎ情報が表示済みの場合
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose
            
            '@引継ぎ情報表示済みﾌﾗｸﾞに"True：表示済み"をｾｯﾄ
            mblnTakeOverDispFlg = True

            '@引数のｷｬﾘｱIDが空白(NULL)か
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@空白(NULL)以外の場合
                
                '@ｷｬﾘｱIDの初期値を設定する
                txtCarrier.Text = ptypCommonInfo.strCarrierId
                
                '@=======================
                '@　ｷｬﾘｱIDﾃｷｽﾄのValidate処理
                '@=======================
                RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
            Else
                '@空白(NULL)の場合
            
                '@ｷｬﾘｱIDの初期化
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
    '機　能：ﾌｫｰﾑ　KeyDown処理
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/04/19 (Mon) 13:31:48 S.Deguchi
    '更新日：2008/04/24 (Thu) 11:43:04 N.Kojima
    '備　考：
    '　　　：2008/04/24 (Thu) 11:43:04 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            
            '@以下の条件の場合、ｷｰｺｰﾄﾞを無効にし処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                e.Handled = True
                Exit Sub
            End If
            
            '@★ ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙにより処理分岐 ★
            Select Case ActiveControl.Name
            
                '@〓 ｷｬﾘｱID 〓
                Case txtCarrier.Name
                
                    Select Case e.KeyCode
                        '@Enterｷｰか
                        Case Keys.Return
                        
                            '@=======================
                            '@　ｷｬﾘｱIDﾃｷｽﾄのValidate処理(ｷｬﾘｱIDの場合はﾛｯﾄ状態を取得する)
                            '@=======================
                            RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                            Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(True))
                            AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                            e.Handled = True
                    End Select
                    
                '@〓 作業ﾒﾓ 〓
                Case txtWorkMemo.Name
                    
                    '@作業ﾒﾓの場合には処理抜け
                    Exit Sub
                
                '@〓 その他 〓
                Case Else
                    
                    Select Case e.KeyCode
                        '@Enterｷｰか
                        Case Keys.Return
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
    '機　能：ﾌｫｰﾑ　終了時処理
    '引　数：Cancel     ：未使用
    '　　　：UnloadMode ：未使用
    '戻り値：なし
    '作成日：2004/04/19 (Mon) 13:31:31 S.Deguchi
    '更新日：2008/04/24 (Thu) 11:39:12 N.Kojima
    '備　考：
    '　　　：2004/11/01 (Mon) 16:00:35 S.Deguchi    閉じるﾎﾞﾀﾝ統合
    '　　　：2008/04/24 (Thu) 11:39:12 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try

            
            '@ﾌｫｰﾑの"×"ﾎﾞﾀﾝにて閉じたか
            If mblnCloseFromControlMenu Then
            
                '@=======================
                '@　閉じるﾎﾞﾀﾝ押下&ClicK処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload           '@NSYS 閉じる処理抜け
                Call cmdClose_Click(sender, New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
            pblnFormLoad = False
            
            '@構造体の初期化
            If mtypScrapList.typeMasItem Is Nothing Then
                mtypScrapList.typeMasItem = New List(Of MasItem)
            Else
                mtypScrapList.typeMasItem.Clear
            End If

            If mtypHoldList.typeMasItem Is Nothing Then
                mtypHoldList.typeMasItem = New List(Of MasItem)
            Else
                mtypHoldList.typeMasItem.Clear
            End If

            If mtypTakeList.typeMasItem Is Nothing Then
                mtypTakeList.typeMasItem = New List(Of MasItem)
            Else
                mtypTakeList.typeMasItem.Clear
            End If
            
            '@ActInitﾌﾗｸﾞが"True：自前で初期化"か
            If pblnActInitFlg = True Then
                '@Actを自前で初期化した場合
                
                '@=======================
                '@　ACTｵﾌﾞｼﾞｪｸﾄの開放処理
                '@=======================
                lblnAnsTerm = pubblnAct_Term
                
                '@処理結果判定
                If lblnAnsTerm = True Then'@結果：正常の場合
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                End If
            Else
                '@Actを自前で初期化していない場合
            
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
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_QueryUnload"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Change
    '機　能：ｷｬﾘｱIDﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/19 (Mon) 13:30:57 S.Deguchi
    '更新日：2008/04/24 (Thu) 12:20:42 N.Kojima
    '備　考：
    '　　　：2008/04/24 (Thu) 12:20:42 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change

        Try
            '@=======================
            '@　画面情報初期化処理
            '@=======================
            Call prvfrmxxEN0170_Init()
            
            '@=======================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvblnInput_Chk()

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

    '関数名：txtCarrier_Validate
    '機　能：ｷｬﾘｱIDﾃｷｽﾄ　Validate処理(入力確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/04/19 (Mon) 13:32:42 S.Deguchi
    '更新日：2008/04/24 (Thu) 13:39:43 N.Kojima
    '備　考：
    '　　　：2004/09/21 (Tue) 22:19:14 H.Wajima     不良ｺｰﾄﾞが0件の場合、ｵﾌﾟｼｮﾝﾎﾞﾀﾝが使用不可能になるよう変更。(№653,759)
    '　　　：2008/04/24 (Thu) 13:39:43 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim ltypLotprestate         As Lotprestate          'ﾛｯﾄ情報格納構造体
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl Is cmdClose Or mblnWindowClose Then
                Exit Sub
            End If

            '@ｷｬﾘｱIDがNULLか
            If txtCarrier.Text = vbNullString Then
                '@ｷｬﾘｱIDがNULLの場合は、次有効ｺﾝﾄﾛｰﾙにﾌｫｰｶｽｾｯﾄ
                SendKeys.SendWait(CPstrSendKeysTab)
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDが6桁以外か
            If txtCarrier.NowByte < txtCarrier.ChrMaxByte Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"<TRM07W>$$キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDにﾌｫｰｶｽ保持
                e.Cancel = True
                Exit Sub
            End If

            '@入力ｷｬﾘｱIDと前回のｷｬﾘｱIDが異なるか
            If txtCarrier.Text <> mstrTaihiCarrierID Then
                '@異なる場合
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrTxtCarrierValidate)
                
                '@【ﾛｯﾄ現在状態取得】ﾒｯｾｰｼﾞ送受信処理
                lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                                CPstrCD1E, _
                                                txtCarrier.Text, _
                                                ltypLotprestate)

                '@通信結果判定
                If lblnAns = True Then
                    '@結果：正常の場合
                    
                    '@=======================
                    '@　画面表示処理
                    '@=======================
                    Call prvfrmxxEN0170_Disp(ltypLotprestate)
                Else
                    '@結果：異常の場合
                
                    '@=======================
                    '@　画面情報初期化処理
                    '@=======================
                    Call prvfrmxxEN0170_Init()
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)
                    Exit Sub
                End If
                
                '@=======================
                '@　終了理由ｺｰﾄﾞ取得処理
                '@=======================
                lblnAns = prvblnReasonCode_Sel
                
                '@通信結果判定
                If lblnAns = True Then
                    '@結果：正常の場合
                    
                    '@=======================
                    '@　各ｺﾝﾄﾛｰﾙ制御処理(有効)
                    '@=======================
                    Call prvInputObjectControl_Proc(True, True)
                    
                    '@=======================
                    '@　終了理由ｺﾝﾎﾞ作成処理
                    '@=======================
                    Call prvblncmbEndReason_Disp(mtypScrapList)
                    
                    '@不良ｺｰﾄﾞが0件か
                    If mtypScrapList.lngListCnt = 0 Then
                        '@不良ｵﾌﾟｼｮﾝﾎﾞﾀﾝを無効にする
                        optScrapHoldTake0.Enabled = False
                    End If
                    
                    '@保留ｺｰﾄﾞが0件か
                    If mtypHoldList.lngListCnt = 0 Then
                        '@保留ｵﾌﾟｼｮﾝﾎﾞﾀﾝを無効にする
                        optScrapHoldTake1.Enabled = False
                    End If
                    
                    '@払出ｺｰﾄﾞが0件か
                    If mtypTakeList.lngListCnt = 0 Then
                        '@払出ｵﾌﾟｼｮﾝﾎﾞﾀﾝを無効にする
                        optScrapHoldTake2.Enabled = False
                    End If
                Else
                    '@結果：異常の場合
                
                    '@=======================
                    '@　画面情報初期化処理
                    '@=======================
                    Call prvfrmxxEN0170_Init()
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierValidate)
                    Exit Sub
                End If

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrTxtCarrierValidate)
                
                '@★ ｵﾌﾟｼｮﾝﾎﾞﾀﾝの状態により処理分岐 ★
                Select Case True
                
                    '@〓 不良ｵﾌﾟｼｮﾝﾎﾞﾀﾝ有効 〓
                    Case optScrapHoldTake0.Enabled

                        '@不良ｵﾌﾟｼｮﾝﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(optScrapHoldTake0)
                        'NSYS @不良 Classのｾｯﾄ(Class=2)
                        mstrTaihiEndReason = CPstrClass2
                        
                    '@〓 保留ｵﾌﾟｼｮﾝﾎﾞﾀﾝ有効 〓
                    Case optScrapHoldTake1.Enabled

                        '@保留ｵﾌﾟｼｮﾝﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(optScrapHoldTake1)
                        'NSYS @保留 Classのｾｯﾄ(Class=4)
                        mstrTaihiEndReason = CPstrClass4
                        
                    '@〓 払出ｵﾌﾟｼｮﾝﾎﾞﾀﾝ有効 〓
                    Case optScrapHoldTake2.Enabled

                        '@払出ｵﾌﾟｼｮﾝﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(optScrapHoldTake2)
                        'NSYS @払出 Classのｾｯﾄ(Class=3)
                        mstrTaihiEndReason = CPstrClass3
                    
                    '@〓 その他 〓
                    Case Else

                        '@終了責任者IDへﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtEmpID)

                End Select

            Else
                '@前回入力ｷｬﾘｱIDと同じ場合
                
                'For llngCnt = 0 To 2
                '
                '    '@選択されているか(ﾁｪｯｸが付いているか)
                '    If optScrapHoldTake(llngCnt).Value = True Then
                '        '@選択されているｵﾌﾟｼｮﾝﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                '        Call pubSetFocus(optScrapHoldTake(llngCnt))
                '    End If
                'Next llngCnt
                
                '@選択されている「終了理由」,又は「閉じる」ﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                Select Case True
                    '@不良
                    Case optScrapHoldTake0.Checked = True
                        Call pubSetFocus(optScrapHoldTake0)
                        'NSYS @不良 Classのｾｯﾄ(Class=2)
                        mstrTaihiEndReason = CPstrClass2
                    '@保留
                    Case optScrapHoldTake1.Checked = True
                        Call pubSetFocus(optScrapHoldTake1)
                        'NSYS @保留 Classのｾｯﾄ(Class=4)
                        mstrTaihiEndReason = CPstrClass4
                    '@払出
                    Case optScrapHoldTake2.Checked = True
                        Call pubSetFocus(optScrapHoldTake2)
                        'NSYS @払出 Classのｾｯﾄ(Class=3)
                        mstrTaihiEndReason = CPstrClass3
                    '@その他(作業終了,作業待ち状態の場合)
                    Case Else
                        e.Cancel = True
                End Select

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrier_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：optScrapHoldTake_Click
    '機　能：終了区分ｵﾌﾟｼｮﾝﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：Index：0/不良(Scrap)、1/保留(Hold)、2/払出(Take)
    '戻り値：なし
    '作成日：2004/04/19 (Mon) 15:37:42 S.Deguchi
    '更新日：2008/04/24 (Thu) 16:51:31 N.Kojima
    '備　考：
    '　　　：2008/04/24 (Thu) 16:51:31 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub optScrapHoldTake_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optScrapHoldTake0.Click, optScrapHoldTake1.Click, optScrapHoldTake2.Click

        Try
            'NSYS CheckedがTrueになる方とFalseになる方の両方のRadioButtonでCheckedChangedイベントが同時に発生するため、Trueの方のみ拾う
            If sender.Checked = False Then
                Exit Sub
            End If

            'NSYS ラジオボタン名optScrapHoldTakeまでは固定なので末尾取得用のIndexは16
            Dim intCheckedNum As Integer
            intCheckedNum = sender.Name.ToString.Substring(16)
            
            '@引数の"Index(選択ｵﾌﾟｼｮﾝﾎﾞﾀﾝ)"により処理分岐
            Select Case intCheckedNum
            
                '@〓 不良 〓
                Case CMlngScrapIndex
                
                    '@Classに"2:不良"をｾｯﾄ
                    mstrTaihiEndReason = CPstrClass2
                    
                    '@=======================
                    '@　終了理由ｺﾝﾎﾞ作成処理(不良ｺｰﾄﾞVer)
                    '@=======================
                    Call prvblncmbEndReason_Disp(mtypScrapList)
                    
                    
                '@〓 保留 〓
                Case CMlngHoldIndex
                    
                    '@Classに"4:保留"をｾｯﾄ
                    mstrTaihiEndReason = CPstrClass4
                    
                    '@=======================
                    '@　終了理由ｺﾝﾎﾞ作成処理(保留ｺｰﾄﾞVer)
                    '@=======================
                    Call prvblncmbEndReason_Disp(mtypHoldList)
                    
                    
                '@〓 払出 〓
                Case CMlngTakeIndex
                
                    '@Classに"3:払出"をｾｯﾄ
                    mstrTaihiEndReason = CPstrClass3
            
                    '@=======================
                    '@　終了理由ｺﾝﾎﾞ作成処理(払出ｺｰﾄﾞVer)
                    '@=======================
                    Call prvblncmbEndReason_Disp(mtypTakeList)
            End Select
            
            '@=======================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvblnInput_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optScrapHoldTake_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbEndReason_Change
    '機　能：終了要因ｺﾝﾎﾞ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/19 (Mon) 12:57:45 S.Deguchi
    '更新日：2008/04/24 (Thu) 17:32:42 N.Kojima
    '備　考：
    '　　　：2008/04/24 (Thu) 17:32:42 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub cmbEndReason_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbEndReason.Change

        Try
                
            '@=======================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvblnInput_Chk()

            '@選択した終了理由ｺｰﾄﾞを退避情報へ
            mstrTaihiEndCode = cmbEndReason.Value
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbEndReason_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbEndReason_CloseUp
    '機　能：終了理由ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/26 (Mon) 14:45:45 S.Deguchi
    '更新日：2008/04/24 (Thu) 17:35:07 N.Kojima
    '備　考：
    '　　　：2008/04/24 (Thu) 17:35:07 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub cmbEndReason_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbEndReason.CloseUp

        Try
            
            '@選択終了理由の理由IDがあるか
            If cmbEndReason.Value <> vbNullString Then
                '@次項目にﾌｫｰｶｽｾｯﾄ
                SendKeys.SendWait(CPstrSendKeysTab)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbEndReason_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtEmpID_Change
    '機　能：終了責任者IDﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/29 (Thu) 09:54:01 M.Miura
    '更新日：2008/04/24 (Thu) 17:39:47 N.Kojima
    '備　考：
    '　　　：2008/04/24 (Thu) 17:39:47 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub txtEmpID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtEmpID.Change

        Try
            
            '@終了責任者名を初期化
            lblEmpName.Text = vbNullString
            
            '@=======================
            '@　確定ﾎﾞﾀﾝ制御処理
            '@=======================
            Call prvblnInput_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtEmpID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtEmpID_Validate
    '機　能：終了責任者IDﾃｷｽﾄ　Validate処理(入力確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ
    '戻り値：なし
    '作成日：2004/07/29 (Thu) 09:54:30 M.Miura
    '更新日：2008/04/24 (Thu) 17:41:29 N.Kojima
    '備　考：
    '　　　：2004/09/23 (Thu) 11:42:34 N.Kojima　   作業者検索ｴﾗｰMsgをSVで表示するように修正。(不具合№895)
    '　　　：2008/04/24 (Thu) 17:41:29 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub txtEmpID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtEmpID.Validating
        
        Dim lstrEmpName             As String               '終了責任者名
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl Is cmdClose Or mblnWindowClose Then
                Exit Sub
            End If

            '@終了責任者IDが入力されているか
            If txtEmpID.Text <> vbNullString Then

                '@【作業者名取得】ﾒｯｾｰｼﾞ送受信処理
                lblnAns = pubblnMasEmpName_Sel(CMstrmas_empname_Ver, txtEmpID.Text, lstrEmpName)
                
                '@通信結果判定
                If lblnAns = True Then
                    '@結果：正常の場合
                
                    '@終了責任者名設定
                    lblEmpName.Text = lstrEmpName
                Else
                    '@結果：異常の場合
                
                    '@終了責任者IDにﾌｫｰｶｽ保持
                    e.Cancel = True
                    Exit Sub
                End If
            Else
                '@終了責任者IDがNULLの場合
            
                '@終了責任者名設定
                lblEmpName.Text = vbNullString
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtEmpID_Validate"
                .strErrMessage = vbNullString
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
    '更新日：2008/04/24 (Thu) 18:20:40 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 15:03:35 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2008/04/24 (Thu) 18:20:40 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change

        Dim llngNowByte     As Integer  'ﾊﾞｲﾄ数

        Try
            
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtWorkMemo.NowByte
            
            '@=======================
            '@　現在ﾊﾞｲﾄ数表示処理(表示ﾒｯｾｰｼﾞ変換)
            '@=======================
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
                           
            '@=======================
            '@　ﾃｷｽﾄ変更時処理
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdUP, cmdDown)
                       
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_Change"
                .strErrMessage = vbNullString
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
    '更新日：2008/04/24 (Thu) 18:22:46 N.Kojima
    '備　考：
    '　　　：2008/04/24 (Thu) 18:22:46 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub txtWorkMemo_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtWorkMemo.KeyUp

        Try
            '@=======================
            '@　ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作処理
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtWorkMemo, CMlngMaxDispMemoRow, cmdUP, cmdDown)
            
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
    '更新日：2008/04/24 (Thu) 18:24:52 N.Kojima
    '備　考：
    '　　　：2008/04/24 (Thu) 18:24:52 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub txtWorkMemo_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtWorkMemo.MouseUp

        Try
            
            '@=======================
            '@　ﾃｷｽﾄ変更時処理
            '@=======================
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdUP, cmdDown, e.Button)
            
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

    '関数名：cmdUp_Click
    '機　能：上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ(作業ﾒﾓ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 14:52:32 M.Miura
    '更新日：2008/04/24 (Thu) 18:25:50 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 15:01:40 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2008/04/24 (Thu) 18:25:50 N.Kojima     ｿｰｽ整備。(案件№02786)
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
            '@　ﾃｷｽﾄ用上ｽｸﾛｰﾙﾎﾞﾀﾝ押下時処理
            '@=======================
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdUP, cmdDown)

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
    '機　能：下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ(作業ﾒﾓ用)　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/27 (Tue) 14:53:27 M.Miura
    '更新日：2008/04/24 (Thu) 18:27:04 N.Kojima
    '備　考：
    '　　　：2005/12/02 (Fri) 15:02:55 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2008/04/24 (Thu) 18:27:04 N.Kojima     ｿｰｽ整備。(案件№02786)
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
            '@　ﾃｷｽﾄ用下ｽｸﾛｰﾙﾎﾞﾀﾝ押下時処理
            '@=======================
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdUP, cmdDown)

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

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/19 (Mon) 13:32:08 S.Deguchi
    '更新日：2018/11/16 (Fri) 09:47:55 Y.Yoneyama
    '備　考：
    '　　　：2005/02/15 (Tue) 13:25:37 N.Kojima     戻り先画面の判定を追加。(改善№512)
    '　　　：2008/04/24 (Thu) 18:28:08 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2018/11/16 (Fri) 09:47:55 Y.Yoneyama   防湿ALD対応
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

            '@引継ぎ情報のｷｬﾘｱIDが空白(NULL)か
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@空白(NULL)以外の場合
                
                '@装置別ﾛｯﾄ一覧から引き継いで起動されたか
                If pblnfrmxxEN0150Kbn = True Then
                
                    '@=======================
                    '@　装置別ﾛｯﾄ一覧に戻る処理
                    '@=======================
                    Call pubMenuSelect_Proc(CPstrKeyEN0150)
                    
        '@↓2018/11/16 (Fri) 09:47:55 Y.Yoneyama **************************************************
                '@装置別ﾛｯﾄ(防湿ALD)一覧から引き継いで起動された場合
                ElseIf pblnfrmxxEN0151Kbn = True Then
                    '@装置別ﾛｯﾄ(防湿ALD)一覧を起動する
                    Call pubMenuSelect_Proc(CPstrKeyEN0151)
        '@↑2018/11/16 (Fri) 09:47:55 Y.Yoneyama **************************************************

                Else
                    '@装置別ﾛｯﾄ一覧から以外
                
                    '@装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧から引き継いで起動されたか
                    If pblnfrmxxEN00J0Kbn = True Then
                    
                        '@=======================
                        '@　装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧に戻る処理
                        '@=======================
                        Call pubMenuSelect_Proc(CPstrKeyEN00J0)
                    Else
                        '@工程別ﾛｯﾄ一覧から引き継いで起動された場合
                        
                        '@=======================
                        '@　工程別ﾛｯﾄ一覧に戻る処理
                        '@=======================
                        Call pubMenuSelect_Proc(CPstrKeyEN0200)
                    End If
                End If
            Else
                '@空白の場合
            
                '@=======================
                '@　終了関数を実行処理
                '@=======================
                Call publngEnd_Proc(CPstrKeyEN0170, ltypCommonInfo)
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

    '関数名：cmdRegist_Click
    '機　能：確定ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/19 (Mon) 13:32:21 S.Deguchi
    '更新日：2008/04/24 (Thu) 18:31:47 N.Kojima
    '備　考：
    '　　　：2005/10/05 (Wed) 15:51:51 S.Deguchi    不具合№2259の対応で最終更新日時を追加
    '　　　：2008/04/24 (Thu) 18:31:47 N.Kojima     ｿｰｽ整備、ﾛｯﾄｱｳﾄの権限ﾁｪｯｸ追加。(案件№02786)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim ltypLotEnd              As LotEnd       'ﾛｯﾄ終了構造体
        Dim lstrFunctionID          As String       '機能ID
        Dim lstrActionID            As String       'ｱｸｼｮﾝID
        Dim lstrEmpName             As String       '作業者名
        Dim lstrWkEmpID             As String       '作業者ID(退避用)
        Dim lblnInputCheck          As Boolean      '画面入力ﾁｪｯｸ(True:正常,False:異常)
        Dim lblnAns                 As Boolean      '結果取得(True:正常,False:異常)
        Dim lblnAuthorityCheckFlag  As Boolean      '権限ﾁｪｯｸ制御ﾌﾗｸﾞ(True：権限ﾁｪｯｸを行なう、Flase：権限ﾁｪｯｸを行なわない)


        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@以下の条件の場合、処理終了
            '@　①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@　②ﾌｫｰﾑのﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or Me.Enabled = False Then
                Exit Sub
            End If
            
            '@=======================
            '@　確定前入力ﾁｪｯｸ処理
            '@=======================
            lblnInputCheck = prvblnRegistInput_Chk
            
            '@処理結果判定
            If lblnInputCheck = False Then
                '@結果：異常の場合
                Exit Sub
            End If
            
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@　作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@作業者IDを退避
            lstrWkEmpID = pstrUserID
            
            '@***************************
            '@　権限ﾁｪｯｸが必要か判定する
            '@***************************
            '@★ 所属ｸﾞﾙｰﾌﾟIDにより処理分岐 ★
            Select Case pstrGroupID
            
                '@〓 STAFF(技術) 〓
                Case CPstrDeptIDStaff
                
                    '@職場IDが"STAFF"で、かつ終了区分が"2:不良"か
                    If mstrTaihiEndReason = CPstrClass2 Then
                        '@権限ﾁｪｯｸ制御ﾌﾗｸﾞに"True：権限ﾁｪｯｸを行なう"をｾｯﾄ
                        lblnAuthorityCheckFlag = True
                    End If
            
                '@〓 LINE(製造) 〓
                Case CPstrDeptIDLine
                
                    '@職場IDが"LINE"で、かつ終了区分が"3:払出"か
                    If mstrTaihiEndReason = CPstrClass3 Then
                        '@権限ﾁｪｯｸ制御ﾌﾗｸﾞに"True：権限ﾁｪｯｸを行なう"をｾｯﾄ
                        lblnAuthorityCheckFlag = True
                    End If
                    
                '@〓 その他(現在はSYSTEMのみ) 〓
                Case Else

                    '@職場IDが"STAFF"or"LINE"以外で、かつ終了区分が"2:不良"or"3:払出"か
                    If mstrTaihiEndReason = CPstrClass2 Or mstrTaihiEndReason = CPstrClass3 Then
                        '@権限ﾁｪｯｸ制御ﾌﾗｸﾞに"True：権限ﾁｪｯｸを行なう"をｾｯﾄ
                        lblnAuthorityCheckFlag = True
                    End If
                    
            End Select
                    
            '@権限ﾁｪｯｸ制御ﾌﾗｸﾞに"True：権限ﾁｪｯｸを行なう"をｾｯﾄ
            If lblnAuthorityCheckFlag = True Then
                
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                '@　ﾊﾟｽﾜｰﾄﾞ付き作業者ｺｰﾄﾞ入力画面　表示処理
                '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
                With frmxxCM0020.Instance
                    .txtUserID.Text = lstrWkEmpID
                    .txtUserID.Enabled = False
                End With
                frmxxCM0020.Instance.ShowDialog(Me)
                frmxxCM0020.Instance = Nothing

                '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
                If pblnCancel = True Then
                    Exit Sub
                End If
                
                '@実行権限の処理を追加
                lstrFunctionID = CPstrKeyEN0170             '機能ID：EN0170(ﾛｯﾄ終了)
                lstrActionID = CPstrWFStatusChange          'ｱｸｼｮﾝID：不良/払出
                lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名：NULL
                
                '@=======================
                '@　実行権限ﾁｪｯｸ処理
                '@=======================
                lblnAns = pubAuthority_Chk(lstrFunctionID, _
                                           lstrActionID, _
                                           pstrUserID, _
                                           lstrEmpName, _
                                           pstrSBID)

                '@通信結果判定
                If lblnAns = False Then
                    '@結果：異常の場合

                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
            
                    '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, lstrActionID)
                    '@警告ﾒｯｾｰｼﾞ
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                    Exit Sub
                End If
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)
            
            '@ﾛｯﾄ終了送信ﾃﾞｰﾀ格納
            With ltypLotEnd
                .strLotID = lblLotID.Text                    'ﾛｯﾄID
                .strClass = mstrTaihiEndReason                  '終了区分(2:不良、3:払出、4:保留)
                .strReasonCode = mstrTaihiEndCode               '終了理由ID
                .strResponsble_Emp_ID = txtEmpID.Text           '終了責任者ID
                .strComments = txtWorkMemo.Text                 '作業ﾒﾓ
                .strEmpID = pstrUserID                          '作業者ID
                .strLotLastUpdate = mstrLotLastUpdate           '最終更新日時
            End With

            '@【ﾛｯﾄ終了】ﾒｯｾｰｼﾞ送受信処理
            '@ ※処理区分=1E：ﾛｯﾄ終了
            lblnAns = pubblnLotTerminate_Upd(CMstrlot_terminateVer, _
                                            CPstrCD1E, _
                                            ltypLotEnd)
                                             
            
            '@通信結果取得
            If lblnAns = True Then
                '@結果：正常の場合

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0032, txtCarrier.Text, lblLotID.Text)
                '@成功ﾒｯｾｰｼﾞ表示("<TRM32I>$$ロット[%2]終了しました。キャリア[%1]")
                Call pubVsfInfo_Disp(pstrDMsg)

                '@ｷｬﾘｱIDのｸﾘｱ
                txtCarrier.Text = vbNullString
                
                '@=======================
                '@　画面情報初期化処理
                '@=======================
                Call prvfrmxxEN0170_Init()
                
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
            End If
            
            '@ｷｬﾘｱIDが有効か
            If txtCarrier.Enabled = True Then
                '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
            End If
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRegist_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：prvfrmxxEN0170_Init
    '機　能：画面情報初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/19 (Mon) 12:48:28 S.Deguchi
    '更新日：2008/06/11 (Wed) 14:32:10 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 14:18:47 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2008/04/24 (Thu) 18:49:50 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2008/06/11 (Wed) 14:32:10 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxEN0170_Init()
        
        Dim llngNowByte         As Integer      '現在のﾊﾞｲﾄ数格納
        Dim lstrFormTitle       As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@=======================
            '@　機能毎関連情報取得処理
            '@=======================
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0170, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@各ｺﾝﾄﾛｰﾙの初期化
            lblLotID.Text = vbNullString                                'ﾛｯﾄID
            lblFlowClass.Text = vbNullString                            '流動区分
            lblWFNo.Text = vbNullString                                 'FW枚数
            lblOpName.Text = vbNullString                               '大工程名
            lblStartDayTime.Text = vbNullString                         '開始日時
            lblPdID.Text = vbNullString                                 '機種名
            lblS.Text = vbNullString                                    '特殊特性
            lblStatus.Text = vbNullString                               '状態
            lblStepName.Text = vbNullString                             '小工程名
            lblLotManager.Text = vbNullString                           'ﾛｯﾄ担当
            lblTimeLimit.Text = vbNullString                            '時間制約
            '@↓2020/02/19 (Wed) 13:58:40 Y.Yoneyama 「.Netへ反映未」 **************************************************
            lblGRB.Text = vbNullString                               'GRB
            '@GRB背景色
            lblGRB.BackColor = lblLotManager.BackColor
            '@↑2020/02/19 (Wed) 13:58:40 Y.Yoneyama 「.Netへ反映未」 **************************************************
            lblEmpName.Text = vbNullString                              'NSYS 終了責任者名
            
            optScrapHoldTake0.Checked = False                           '不良ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optScrapHoldTake1.Checked = False                           '保留ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optScrapHoldTake2.Checked = False                           '払出ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            cmbEndReason.Text = vbNullString                            '終了要因ｺｰﾄﾞ
            txtEmpID.Text = vbNullString                                '終了責任者ID
            
            '@終了責任者ID桁数設定
            txtEmpID.ChrMaxByte = CPlngEmpIDLength

            '@日付ﾀｲﾄﾙ設定「処理開始予定」
            lblStartTime.Text = CPstrDispatchTime
            
            '@作業ﾒﾓ初期化
            With txtWorkMemo
                
                .ChrMaxByte = CPlngLotCommentsMaxByte   '最大文字数設定(2048文字)
                .Text = vbNullString                    '初期化
                llngNowByte = .NowByte                  '現状のﾊﾞｲﾄ数格納
                
                '@=======================
                '@　現在ﾊﾞｲﾄ数表示処理(表示ﾒｯｾｰｼﾞ変換)
                '@=======================
                lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            End With
            
            '@=======================
            '@　各ｺﾝﾄﾛｰﾙ制御処理(無効)
            '@=======================
            Call prvInputObjectControl_Proc(False)
            
            '@退避情報の初期化
            mstrTaihiCarrierID = vbNullString                           'ﾛｯﾄ情報取得時のｷｬﾘｱID
            mstrTaihiOpID = vbNullString                                'ﾛｯﾄ情報取得時の大工程ID
            mstrTaihiStepID = vbNullString                              'ﾛｯﾄ情報取得時の小工程ID
            mstrTaihiLotScrapSetID = vbNullString                       'ﾛｯﾄ情報取得時の不良項目ｾｯﾄID
            mstrTaihiEndReason = vbNullString                           'ﾛｯﾄの終了理由(ClassID)
            mstrTaihiEndCode = vbNullString                             'ﾛｯﾄの終了理由ｺｰﾄﾞID
            mstrTaihiEndReasonName = vbNullString                       'ﾛｯﾄの終了理由名称
            mstrLotLastUpdate = vbNullString                            '最終更新日時

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN0170_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvInputObjectControl_Proc
    '機　能：各ｺﾝﾄﾛｰﾙの設定
    '引　数：lblnEnable ：True:使用可能、False:使用不可
    '　　　：lblnFlag   ：True:終了理由ｺｰﾄﾞのｺﾝﾄﾛｰﾙの設定をとばす、False:終了理由ｺｰﾄﾞのｺﾝﾄﾛｰﾙの設定
    '戻り値：なし
    '作成日：2004/04/26 (Mon) 14:29:55 S.Deguchi
    '更新日：2008/04/24 (Thu) 13:38:32 N.Kojima
    '備　考：
    '　　　：2004/09/14 (Tue) 21:35:31 Y.Yamagishi　終了要因ｺｰﾄﾞが空の場合無効にする(不具合改善№653)
    '　　　：2005/12/02 (Fri) 15:07:42 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2008/04/24 (Thu) 13:38:32 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub prvInputObjectControl_Proc(Optional ByVal lblnEnable As Boolean = False, _
                                Optional ByVal lblnFlag As Boolean = False)

        Try

            '@各ｺﾝﾄﾛｰﾙの設定
            optScrapHoldTake0.Enabled = lblnEnable                      '不良ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optScrapHoldTake1.Enabled = lblnEnable                      '保留ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optScrapHoldTake2.Enabled = lblnEnable                      '払出ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            txtEmpID.Enabled = lblnEnable                               '終了責任者ID
            txtWorkMemo.Enabled = lblnEnable                            '作業ﾒﾓ
                
            '@lblnFlagがTrueの場合は処理をとばす
            If lblnFlag = False Then
                cmbEndReason.Enabled = lblnEnable                       '終了要因ｺｰﾄﾞ
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvInputObjectControl_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN0170_Disp
    '機　能：画面表示処理
    '引　数：ltypLotprestate    ：ﾛｯﾄ現在状態情報格納構造体
    '戻り値：なし
    '作成日：2004/04/19 (Mon) 16:46:43 S.Deguchi
    '更新日：2008/06/11 (Wed) 14:32:32 N.Kojima
    '備　考：
    '　　　：2004/08/25 (Wed) 15:27:16 N.Kasai      CFﾌﾗｸﾞ判定追加、"mm/dd hh:mm:ss"を共通変数化
    '　　　：2004/09/09 (Thu) 20:46:29 Y.Yamagishi　時間制限表示変更(不具合改善№693)
    '　　　：2004/09/14 (Tue) 10:28:44 N.Kojima　   数量表示(TPALﾛｯﾄ対応)修正(不具合改善№730)
    '　　　：2004/09/24 (Fri) 11:33:48 Y.Yamagishi  制限時間以上の場合文字色を青に変更(不具合改善№825)
    '　　　：2006/06/08 (Thu) 15:16:04 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2008/04/24 (Thu) 18:57:26 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2008/06/11 (Wed) 14:32:32 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxEN0170_Disp(ByRef ltypLotprestate As Lotprestate)

        Try
            
            '@ﾛｯﾄ情報の表示
            With ltypLotprestate

                lblLotID.Text = .strLotID                'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass        '流動区分
                lblOpName.Text = .strOpID                '大工程ID
                lblPdID.Text = .strPdId                  '機種名
                lblS.Text = .strSpecialFlg               '特殊特性
                lblStatus.Text = .strNowST               '状態
                lblStepName.Text = .strStepID            '小工程ID
                lblLotManager.Text = .strEngEmpName      'ﾛｯﾄ担当
                '@↓2020/02/19 (Wed) 13:59:52 Y.Yoneyama 「.Netへ反映未」 **************************************************
                lblGRB.Text = .strGRBClass               'GRB
                '@GRB背景色
                lblGRB.BackColor = pubGRBBackColor(.strGRBClass, lblLotManager.BackColor)
                '@↑2020/02/19 (Wed) 13:59:52 Y.Yoneyama 「.Netへ反映未」 **************************************************
                 
                '@最終更新日時を退避
                mstrLotLastUpdate = .strLotLastUpdate       '最終更新日時
                
                '@時間制約有無の表示
                If .strLimitTime <> vbNullString Then

                    '@時間制約がﾌﾟﾗｽの場合
                    If CLng(.strLimitTime) >= 0 Then
                        
                        '@制限時間以下or処理時間制限以下の場合
                        '@　※処理時間制限以下設定の場合、基本的に処理中で処理出来る機能しか関係ないが例外処理として挿入
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                        
                            '@制限時間先大工程+制限時間先小工程+制限時間
                            '@ﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            If IsNumeric(.strLimitTime) = True Then
                                lblTimeLimit.Text = Format(CLng(.strLimitTime), CPstrDateFormatKanma) & CPstrh
                            Else
                                lblTimeLimit.Text = .strLimitTime
                            End If
                            '@右寄せ
                            lblTimeLimit.TextAlign = ContentAlignment.MiddleRight
                            
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
                        lblTimeLimit.TextAlign = ContentAlignment.MiddleRight
                        '@ForColorの変更
                        lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed)    '赤色
                        
                        '@制限時間以下or処理時間制限以下の場合
                        '@　※処理時間制限以下設定の場合、基本的に処理中で処理出来る機能しか関係ないが例外処理として挿入
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@ﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            If IsNumeric(.strLimitTime) = True Then
                                lblTimeLimit.Text = Format(CLng(.strLimitTime), CPstrDateFormatKanma) & CPstrh
                            Else
                                lblTimeLimit.Text = .strLimitTime
                            End If
                        End If
                        
                        '@制限時間以上の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID2 Then
                            '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            If IsNumeric(.strLimitTime) = True Then
                                lblTimeLimit.Text = Replace(Format(CLng(.strLimitTime), CPstrDateFormatKanma), CPstrReplaceMinus, vbNullString) & CPstrh
                            Else
                                lblTimeLimit.Text = .strLimitTime
                            End If
                        End If
                    End If
                End If
                        
                '@★ CF_FLAGにより処理分岐(WF枚数とﾁｯﾌﾟ枚数の表示を切替) ★
                Select Case .strCfFlag
                
                    '@〓 1：CFﾛｯﾄ 〓
                    Case CPstrCF
                    
                        '@ODFﾛｯﾄか(LP_FLAG=1か)
                        If .strLpFlag = CPstrLP Then
                            '@ODFﾛｯﾄの場合
                            lblWFNo.Text = .strWfNum                                         'WF枚数
                        Else
                            '@対向基板(小判)ﾛｯﾄの場合
                            If IsNumeric(.strChipQuantity) = True Then
                                lblWFNo.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)  'ﾁｯﾌﾟ枚数
                            Else
                                lblWFNo.Text = .strChipQuantity
                            End If
                        End If
                        
                    '@〓 1：CFﾛｯﾄ 以外 〓
                    Case Else
                    
                        '@TPALﾛｯﾄか
                        If Trim(Strings.Left(.strLotID, 2)) = CPstrTpalLot Then
                            '@TPALﾛｯﾄの場合
                            If IsNumeric(.strChipQuantity) = True Then
                                lblWFNo.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)  'ﾁｯﾌﾟ枚数
                            Else
                                lblWFNo.Text = .strChipQuantity
                            End If
                        Else
                            '@TFT基板ﾛｯﾄの場合
                            lblWFNo.Text = .strWfNum                                         'WF枚数
                        End If
                End Select
                
                '@★ ﾛｯﾄ状態により処理分岐 ★
                Select Case .strNowST
                
                    '@〓 "作業待ち" or "前処理" 〓
                    Case CPstrWaitWorkSt, CPstrBeforeProgressSt
                    
                        '@日付ﾀｲﾄﾙを"処理開始予定"に設定し、日付をﾌｫｰﾏｯﾄする
                        lblStartTime.Text = CPstrDispatchTime
                        If IsDate(.strDispatchStartTime) = True Then
                            lblStartDayTime.Text = Format$(CDate(.strDispatchStartTime), CPstrDateFormat)  '開始日時"mm/dd hh:mm:ss"
                        Else
                            lblStartDayTime.Text = .strDispatchStartTime
                        End If
                        
                    '@〓 "処理中" or "後処理" or "作業終了" 〓
                    Case Else
                    
                        '@日付ﾀｲﾄﾙを"処理開始日時"に設定し、日付をﾌｫｰﾏｯﾄする
                        lblStartTime.Text = CPstrStartTime
                        If IsDate(.strStartTime) = True Then
                            lblStartDayTime.Text = Format$(CDate(.strStartTime), CPstrDateFormat)          '開始日時"mm/dd hh:mm:ss"
                        Else
                            lblStartDayTime.Text = .strStartTime
                        End If
                End Select
                
                '@ﾛｯﾄ状態が作業待ち、作業終了か
                If .strNowST = CPstrWaitWorkSt Or .strNowST = CPstrEndWorkSt Then
                    
                    '@退避情報
                    mstrTaihiCarrierID = txtCarrier.Text            'ｷｬﾘｱID
                    mstrTaihiOpID = .strOpID                        '大工程ID
                    mstrTaihiStepID = .strStepID                    '小工程ID
                    mstrTaihiLotScrapSetID = .strLotScrapSetID      '不良項目ｾｯﾄID
                End If
            End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN0170_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnRegistInput_Chk
    '機　能：確定時の入力ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：項目正常、False：不正項目あり
    '作成日：2004/04/19 (Mon) 13:45:22 S.Deguchi
    '更新日：2011/10/20 (Thu) 11:10:17 T.Oide
    '備　考：
    '　　　：2008/04/24 (Thu) 19:23:11 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2011/10/20 (Thu) 11:10:17 T.Oide       払出/保留でのﾛｯﾄｱｳﾄ時のﾒｯｾｰｼﾞ表示対応
    Private Function prvblnRegistInput_Chk() As Boolean

    '@↓2011/10/20 (Thu) 11:10:07 T.Oide **************************************************
        Dim llngAns     As Integer
    '@↑2011/10/20 (Thu) 11:10:07 T.Oide **************************************************

        Try
            
            '@戻り値の初期化
            prvblnRegistInput_Chk = False
            
            '@***************
            '@　ｷｬﾘｱID関連
            '@***************
            '@ｷｬﾘｱIDがNULLか
            If txtCarrier.Text = vbNullString Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                '@"<TRM01W>$$キャリアIDが設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If
            
            '@ｷｬﾘｱIDが6桁以外か
            If Len(txtCarrier.Text) <> CMlngCarrierMaxLength Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"<TRM07W>$$キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If
            
            
            '@***************
            '@　ﾛｯﾄ情報関連
            '@***************
            '@ﾛｯﾄ状態が"作業待ち" or "作業終了"以外、またはﾛｯﾄ状態がNULLか
            If (lblStatus.Text <> CPstrWaitWorkSt And lblStatus.Text <> CPstrEndWorkSt) _
                Or lblStatus.Text = vbNullString Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0040)
                '@"<TRM40W>$$「作業待ち」、「作業終了」以外のロットは終了できません。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If
            

            '@***************
            '@　終了区分
            '@***************
            '@終了区分が未選択か
            If mstrTaihiEndReason = vbNullString Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000Y, lblEndClassTitle.Text)
                '@"<TRM0YW>$$[%1]が選択されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@終了区分(不良)が有効か
                If optScrapHoldTake0.Enabled = True Then
                    '@終了区分(不良)へﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(optScrapHoldTake0)
                End If
                Exit Function
            End If
            
            
            '@***************
            '@　終了理由
            '@***************
            '@終了理由が未選択か
            If cmbEndReason.Value = vbNullString Or cmbEndReason.Text = vbNullString Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000Y, lblEndReasonTitle.Text)
                '@"<TRM0YW>$$[%1]が選択されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@終了理由にﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmbEndReason)
                Exit Function
            End If


            '@***************
            '@　終了責任者ID
            '@***************
            '@終了責任者IDがNULLか
            If txtEmpID.Text = vbNullString Then

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007X, lblEmpIDTitle.Text)
                '@"<TRM7XW>$$[%1]が入力されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@終了責任者IDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtEmpID)
                Exit Function
            End If

            '@終了責任者IDが7桁以外か
            If txtEmpID.NowByte < txtEmpID.ChrMaxByte Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003K, lblEmpIDTitle.Text)
                '@"<TRM3KW>$$[%1]は7桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@終了責任者IDにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtEmpID)
                Exit Function
            End If
            
        '@↓2011/10/20 (Thu) 11:08:53 T.Oide **************************************************
            '@PR Or ESで且つ払出 Or 保留の理由か
            If (lblFlowClass.Text = CPstrFlowClassPR Or lblFlowClass.Text = CPstrFlowClassES) And _
               (optScrapHoldTake1.Checked = True Or optScrapHoldTake2.Checked = True) Then
                
                '@ﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0114, Me.Text)
                '@<TRM114W>$$PR/ES品を$[払出/保留]の理由で[%1]する場合、$別途伝票の発行が必要です。
                '　　　　　$$生産管理部門と調整のうえ伝票の発行を行ってください｡
                llngAns = publngMsgBox(pstrDMsg, vbNo, Me.Text, True, 16)
                     
                '@いいえの場合は処理を中止
                If llngAns = vbNo Then
                    Exit Function
                End If
                
            End If
        '@↑2011/10/20 (Thu) 11:08:53 T.Oide **************************************************
            
            '@戻り値に"True:ﾁｪｯｸOK"をｾｯﾄ
            prvblnRegistInput_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnRegistInput_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblncmbEndReason_Disp
    '機　能：終了理由ｺﾝﾎﾞ作成処理
    '引　数：strMasItemList()   :不良/保留/払出のｺｰﾄﾞ一覧
    '戻り値：なし
    '作成日：2004/04/19 (Mon) 17:08:25 S.Deguchi
    '更新日：2009/05/12 (Tue) 19:44:19 N.Kojima
    '備　考：
    '　　　：2004/09/14 (Tue) 21:28:02 Y.Yamagishi　終了要因ｺｰﾄﾞが0件の場合無効にする
    '　　　：2004/09/21 (Tue) 21:54:32 H.Wajima     終了要因ｺｰﾄﾞが0件の場合、ｵﾌﾟｼｮﾝﾎﾞﾀﾝを非活性にするため、ｺﾝﾎﾞの無効処理を削除
    '　　　：2008/04/24 (Thu) 19:37:43 N.Kojima     ｿｰｽ整備。(案件№02786)
    '　　　：2009/05/12 (Tue) 19:44:19 N.Kojima     ﾁｯﾌﾟ払出対応。不良選択時の払出ｺｰﾄﾞは終了理由ｺﾝﾎﾞにｾｯﾄしない。(案件№03434)
    Private Sub prvblncmbEndReason_Disp(ByRef ltypMasItemList As MasItemList)

        Dim llngListCnt       As Integer    'ﾘｽﾄｶｳﾝﾄ

        Try
            
            '@終了理由ｺﾝﾎﾞの初期設定
            With cmbEndReason
                .Clear
                .DispCols = CMlngCmbDispCols                                                'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColName                                               'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridColID                                               '値取得列
                .DirectInput = False                                                        'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font= New Font(CMstrCmbFontName, CType(CMlngCmbFontSize, Single))          'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(CMstrCmbFontName, CType(CMlngCmbGridFontSize, Single)) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                              '行の高さ
                .ColAlignment(CMlngCmbGridColName) = TextAlignEnum.LeftCenter               '左寄中央揃え
            End With
            
            With ltypMasItemList
                
                '@理由ｺｰﾄﾞが1件以上存在するか
                If .lngListCnt > 0 Then

                    cmbEndReason.Enabled = True     '有効
                    
        '@↓2009/05/12 (Tue) 19:42:56 N.Kojima **************************************************

                    For llngListCnt = 0 To .lngListCnt - 1
                    
                        '@払出ｺｰﾄﾞか
                        If .typeMasItem(llngListCnt).strItemID = CPstrForwardCode Then
                        
                            '@払出ｺｰﾄﾞは表示しない
                        Else
                            '@払出ｺｰﾄﾞ以外
                    
                            '@ｺﾝﾎﾞ内容設定(0:名称/1:ID/2:Index(番号))
                            cmbEndReason.AddItem(.typeMasItem(llngListCnt).strItemName & vbTab & _
                                                 .typeMasItem(llngListCnt).strItemID & vbTab & _
                                                 llngListCnt)
                        End If
                    Next llngListCnt

        '@↑2009/05/12 (Tue) 19:42:56 N.Kojima **************************************************
                    
                    '@ｺﾝﾎﾞが1件の場合
                    If cmbEndReason.ListCount = 1 Then
                    
                        '@1件目をﾃﾞﾌｫﾙﾄ表示する
                        cmbEndReason.ListIndex = 0
                    End If
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblncmbEndReason_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnReasonCode_Sel
    '機　能：終了理由ｺｰﾄﾞ取得処理
    '引　数：なし
    '戻り値：True:成功、False:失敗
    '作成日：2004/06/11 (Fri) 19:55:14 S.Deguchi
    '更新日：2008/04/24 (Thu) 19:40:48 N.Kojima
    '備　考：
    '　　　：2004/09/21 (Tue) 22:23:08 H.Wajima     不良項目ｾｯﾄIDが空白の場合は、不良要因ｺｰﾄﾞを取得しないよう修正。(№653,759)
    '　　　：2004/10/20 (Wed) 15:32:05 T.Kitagawa   不良項目取得Msg変更
    '　　　：2008/04/24 (Thu) 19:40:48 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Function prvblnReasonCode_Sel() As Boolean
        
        Dim lblnAns     As Boolean      '結果取得(True:正常、False:異常)

        Try
            
            '@戻り値の初期化
            prvblnReasonCode_Sel = False
            
            '@不良/保留/払出の終了理由ｺｰﾄﾞ格納構造体の初期化
            If mtypScrapList.typeMasItem Is Nothing Then
                mtypScrapList.typeMasItem = New List(Of MasItem)
            Else
                mtypScrapList.typeMasItem.Clear
            End If

            If mtypHoldList.typeMasItem Is Nothing Then
                mtypHoldList.typeMasItem = New List(Of MasItem)
            Else
                mtypHoldList.typeMasItem.Clear
            End If

            If mtypTakeList.typeMasItem Is Nothing Then
                mtypTakeList.typeMasItem = New List(Of MasItem)
            Else
                mtypTakeList.typeMasItem.Clear
            End If
            
            '@不良項目ｾｯﾄIDがNULL以外か
            If mstrTaihiLotScrapSetID <> vbNullString Then
                '@不良要因ｺｰﾄﾞがNULL以外の場合
                
                '@【不良入力項目取得】ﾒｯｾｰｼﾞ送受信処理
                lblnAns = pubblnMasScpList_Sel(pstrSBID, _
                                               CMstrmas_scplist_Ver, _
                                               CPstrCD3I, _
                                               mstrTaihiLotScrapSetID, _
                                               mtypScrapList)

                '@通信結果判定
                If lblnAns = False Then
                    '@結果：異常の場合
                    Exit Function
                End If
            Else
                '@不良項目ｾｯﾄIDがNULLの場合
            
                '@不良要因ｺｰﾄﾞ構造体に0件、NULLを設定
                mtypScrapList.lngListCnt = 0
                mtypScrapList.strLotEventId = vbNullString
            End If
                            
                            
            '@【理由ｺｰﾄﾞ取得(保留)】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnMasResonCode_Sel(CMstrmas_reasoncodeVer, _
                                             CPstrCD2U, _
                                             mtypHoldList)

            '@通信結果判定
            If lblnAns = False Then
                '@結果：異常の場合

                Exit Function
            End If
                                        
                                        
            '@【理由ｺｰﾄﾞ取得(払出)】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnMasResonCode_Sel(CMstrmas_reasoncodeVer, _
                                             CPstrCD2V, _
                                             mtypTakeList)

            '@通信結果判定
            If lblnAns = False Then
                '@結果：異常の場合
                Exit Function
            End If

            '@戻り値に"True:取得成功"をｾｯﾄ
            prvblnReasonCode_Sel = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnReasonCode_Sel"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnInput_Chk
    '機　能：確定ﾎﾞﾀﾝ制御処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/29 (Thu) 09:58:37 M.Miura
    '更新日：2008/04/24 (Thu) 17:33:26 N.Kojima
    '備　考：
    '　　　：2008/04/24 (Thu) 17:33:26 N.Kojima     ｿｰｽ整備。(案件№02786)
    Private Sub prvblnInput_Chk()

        Dim lblnControlFlag     As Boolean      '確定ﾎﾞﾀﾝ制御判定用ﾌﾗｸﾞ(True:確定ﾎﾞﾀﾝ有効、False:確定ﾎﾞﾀﾝ無効)

        Try
            
            '@終了区分が選択されているか
            If mstrTaihiEndReason <> vbNullString Then
            
                '@確定ﾎﾞﾀﾝ制御判定用ﾌﾗｸﾞに"True:有効"をｾｯﾄ
                lblnControlFlag = True
            Else
                '@確定ﾎﾞﾀﾝ制御判定用ﾌﾗｸﾞに"False:無効"をｾｯﾄ
                lblnControlFlag = False
            End If
            
            '@終了理由が選択されているか
            If lblnControlFlag = True And cmbEndReason.Value <> vbNullString Then
            
                '@確定ﾎﾞﾀﾝ制御判定用ﾌﾗｸﾞに"True:有効"をｾｯﾄ
                lblnControlFlag = True
            Else
                '@確定ﾎﾞﾀﾝ制御判定用ﾌﾗｸﾞに"False:無効"をｾｯﾄ
                lblnControlFlag = False
            End If

            '@終了責任者IDが入力されているか
            If lblnControlFlag = True And txtEmpID.Text <> vbNullString Then
            
                '@確定ﾎﾞﾀﾝ制御判定用ﾌﾗｸﾞに"True:有効"をｾｯﾄ
                lblnControlFlag = True
            Else
                '@確定ﾎﾞﾀﾝ制御判定用ﾌﾗｸﾞに"False:無効"をｾｯﾄ
                lblnControlFlag = False
            End If

            '@終了責任者IDの桁ﾁｪｯｸ
            If lblnControlFlag = True And txtEmpID.NowByte = txtEmpID.ChrMaxByte Then
            
                '@確定ﾎﾞﾀﾝ制御判定用ﾌﾗｸﾞに"True:有効"をｾｯﾄ
                lblnControlFlag = True
            Else
                '@確定ﾎﾞﾀﾝ制御判定用ﾌﾗｸﾞに"False:無効"をｾｯﾄ
                lblnControlFlag = False
            End If
                
                
            '@確定ﾎﾞﾀﾝ制御判定用ﾌﾗｸﾞが"True:有効"か
            If lblnControlFlag = True Then
                '@確定ﾎﾞﾀﾝ有効
                cmdRegist.Enabled = True
            Else
                '@確定ﾎﾞﾀﾝ無効
                cmdRegist.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnInput_Chk"
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

End Class
