'ﾌｧｲﾙ名：xxEN0130.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：作業開始取消/処理開始取消　メインフォーム
'作成日：2004/04/05 (Mon) 16:40:26 T.Kitagawa
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2018, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN0130
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN0130    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN0130
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN0130
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN0130)
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
    '@↓2020/03/06 (Fri) 11:25:48 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion             As String = "08.00"
    Private Const CMstrLocalVersion             As String = "09.00"
    '@↑2020/03/06 (Fri) 11:25:48 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@Msgﾊﾞｰｼﾞｮﾝ
    '@↓2020/01/15 (Wed) 14:12:19 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_curstateVer          As String = "03.04"         'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer          As String = "04.00"         'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 14:12:19 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrlot_cnclwrkstartVer      As String = "03.00"         '作業開始取消
    '@↓2014/11/26 (Wed) 10:00:02 H.Hayashi **************************************************
    Private Const CMstrlot_chkovertakecancel    As String = "01.00"         '無機ODF追越制限取消違反確認
    '@↑2014/11/26 (Wed) 10:00:02 H.Hayashi **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN0130  'ﾛｰｶﾙﾒﾆｭｰkey

    '@その他
    Private Const CMstrAri                      As String = "あり"
    Private Const CMstrNasi                     As String = "なし"
    Private Const CMlngCarrierMaxLength         As Integer = 6                 'ｷｬﾘｱIDの最大桁数
    Private Const CMlngEqFlag                   As Integer = 0                 '装置ﾌﾗｸﾞ

    Private Const CMstrSagyou                   As String = "作業"
    Private Const CMstrSyori                    As String = "処理"

    '@CANCEL_MODE(0:作業待ち、1:前処理)
    Private Const CMstrstrWaitWorkMode          As String = "0"
    Private Const CMstrBeforeProgressMode       As String = "1"

    '@取消後ﾛｯﾄ状態選択ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize              As Integer = 14                'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize          As Integer = 16                'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngComboRowHeight           As Integer = 43 '640        '行の高さ
    Private Const CMlngCmbStName                As Integer = 0                 'ﾛｯﾄ状態(和名)
    Private Const CMlngCmbCancelMode            As Integer = 1                 '優先順位項目ID列番(非表示項目)
    Private Const CMlngCmbDispCols              As Integer = 1                 'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbAlignLeftCenter       As Integer = 1                 'ｸﾞﾘｯﾄﾞ文字表示位置(左中央)

    '@ｺﾒﾝﾄ定数宣言
    Private Const CMlngLotCommentsMaxByte       As Integer = 2048              'ﾛｯﾄｺﾒﾝﾄの最大入力ﾊﾞｲﾄ数
    Private Const CMlngMemoDefault              As Integer = 0                 '作業ﾒﾓの初期値(=0)
    Private Const CMstrHandWork                 As String = "0"             'ﾊﾝﾄﾞﾜｰｸ

    '@ﾃｷｽﾄ
    Private Const CMlngMaxDispMemoRow           As Integer = 3                 'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(作業ﾒﾓ)

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '@退避情報
    Private mstrTaihiCarrierID              As String                       'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mstrTaihiLotLastUpdate          As String                       'ﾛｯﾄ情報取得時の最終更新日時
    Private mstrAltNumber                   As String                       '代替番号
    Private mblnTakeOverDispFlg             As Boolean                      '引継ぎ表示ﾌﾗｸﾞ
    Private mstrWPTYPE                      As String                       'WP_TYPE(0:ﾊﾝﾄﾞﾜｰｸ工程)
    Private mblnFormLoadTakeOverFlag        As Boolean                      '一覧系画面から引継かを判別するﾌﾗｸﾞ(False:単独起動/True:引継起動)
    '@↓2014/11/26 (Wed) 15:50:28 H.Hayashi **************************************************
    Private mstrOvertakeWpId                As String                       '追越制限装置ID
    '@↑2014/11/26 (Wed) 15:50:28 H.Hayashi **************************************************

    Private buttonProcessing                As Boolean              'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu        As Boolean              'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                 As Boolean              'NSYS WindowCloseフラグ
    Private ReadOnly vbBlack                As Color = Color.Black  'NSYS vbBlack定義
    Private ReadOnly vbRed                  As Integer = &HFF       'NSYS 赤色

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
    '機　能：ACT初期設定および初期情報取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/05 (Mon) 16:44:21 T.Kitagawa
    '更新日：2005/12/02 (Fri) 12:15:07 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 12:15:07 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub Form_Load()
        
        Dim lblnAns         As Boolean      '戻り値

        Try
          
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN0130, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
                '@異常終了の場合
                '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                Call pubMenuExpand_Disp()
                '@ﾌｫｰﾑを閉じる
                    Call Form_QueryUnload(False, New FormClosingEventArgs(New CloseReason,  False))
                Exit Sub
            End If
            
            '@ﾛｯﾄ情報の初期化
            Call prvfrmxxEN0130_Init()
            
        '@↓2005/12/02 (Fri) 12:15:00 N.Kasai **************************************************
            cmdMemoUp.Enabled = False
            cmdMemoDown.Enabled = False
        '@↑2005/12/02 (Fri) 12:15:00 N.Kasai **************************************************
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用不可)
            Call prvfrmxxEN0130_CmbInit(False)
            
            '@ｷｬﾘｱIDのｸﾘｱ
            txtCarrier.Text = vbNullString
            
            '@閉じるボタンへCausesValidationを設定する
            cmdClose.CausesValidation = False
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True

            '@引継ぎ情報表示済みﾌﾗｸﾞ
            mblnTakeOverDispFlg = False
            
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
    '機　能：ﾌｫｰﾑｱｸﾃｨﾌﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 15:32:39 H.Wajima
    '更新日：2004/07/27 (Tue) 15:32:39
    '備　考：
    '　　　：2005/03/09 (Wed) 13:54:03 S.Deguchi    引継ﾌﾗｸﾞを設定する処理追加
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            
            '@引継ぎ情報表示済みﾌﾗｸﾞの判定
            '@FormLoad後、最初の1回しか処理しない
            If mblnTakeOverDispFlg = True Then
                '@引継ぎ情報が表示済みの場合
                Exit Sub
            End If
            
            '@引継ぎ情報表示済みﾌﾗｸﾞにTrueを設定する
            mblnTakeOverDispFlg = True

            '@引数のキャリアIDが空白かどうか判定する
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@空白でない場合
                
                '@引継起動ﾌﾗｸﾞを立てる
                mblnFormLoadTakeOverFlag = True

                '@キャリアIDの初期値を設定する
                txtCarrier.Text = ptypCommonInfo.strCarrierId

                '@ｷｬﾘｱ情報を取得する
                Call txtCarrier_Validate(False, New CancelEventArgs)
                
                '@ﾌｫｰｶｽの設定
                If cmbNewStatus.Enabled = True Then
                    Call pubSetFocus(cmbNewStatus)
                End If
                
            Else
                '@ｷｬﾘｱID初期化
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

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｱﾝﾛｰﾄﾞ
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 14:47:14 T.Kitagawa
    '更新日：2004/11/01 (Mon) 16:23:48 T.Kitagawa
    '備　考：2004/11/01 (Mon) 16:23:48 T.Kitagawa　閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender, New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
            pblnFormLoad = False
            
            '@ActInitフラグの判定
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

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑのKeyDown
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/04/05 (Mon) 16:46:43 T.Kitagawa
    '更新日：2004/04/05 (Mon) 16:46:43
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            
            Select Case ActiveControl.Name
                '@ｷｬﾘｱIDの場合はﾛｯﾄ状態を取得する
                Case txtCarrier.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            Call txtCarrier_Validate(True, New CancelEventArgs)
                            e.Handled = True
                    End Select
                '@ﾌｫｰｶｽが作業ﾒﾓにある場合
                Case txtWorkMemo.Name
                    '@Enterで改行
                    Exit Sub
                    
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

    '関数名：cmdClose_Click
    '機　能：ﾌﾟﾛｸﾞﾗﾑ終了
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/05 (Mon) 16:47:28 T.Kitagawa
    '更新日：2018/11/16 (Fri) 09:47:55 Y.Yoneyam
    '備　考：2005/02/15 (Tue) 13:25:37 N.Kojima     戻り先画面の判定を追加(改善№512)
    '      ：2018/11/16 (Fri) 09:47:55 Y.Yoneyam    防湿ALD対応
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim llngRet As Integer
        Dim ltypCommonInfo  As CommonInfo

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
                '@終了関数を実行する
                llngRet = publngEnd_Proc(CPstrKeyEN0130, ltypCommonInfo)
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

    '関数名：cmdKakutei_Click
    '機　能：確定
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/05 (Mon) 16:46:43 T.Kitagawa
    '更新日：2014/12/02 (Tue) 13:54:47 H.Hayashi
    '備　考：
    '　　　：2005/02/02 (Wed) 13:05:42 N.Kasai      取消ﾓｰﾄﾞを判定して成功Msgを変更(№468)
    '　　　：2005/03/08 (Tue) 11:31:08 N.Kojima     戻り行判定用に引継ぎ構造体のｷｬﾘｱIDを書き換える(改善№512)
    '　　　：2005/03/09 (Wed) 13:54:49 S.Deguchi    引継ﾌﾗｸﾞがあるか否かでﾊﾟﾌﾞﾘｯｸ構造体へｾｯﾄする情報を変更する処理を追加
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2007/02/13 (Tue) 13:08:38 N.Kasai      処理開始取消権限ﾁｪｯｸ追加(№01761)
    '　　　：2014/12/02 (Tue) 13:31:10 H.Hayashi    組立無機ODF環境のｼｽﾃﾑ環境整備
    Private Sub cmdKakutei_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdKakutei.Click
        
        Dim lblnInputCheck          As Boolean              '画面入力ﾁｪｯｸ(True:正常,False:異常)
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypLotCnclWrkStart     As LotCnclWrkStart      'ﾛｯﾄ作業開始取消構造体
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrAfterStName         As String               '変更後ﾛｯﾄ状態
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance        As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrEmpName             As String               '権限ﾁｪｯｸ用ﾕｰｻﾞ名
        Dim lstrOvertakeLotId       As String               '追越制限違反ﾛｯﾄ
        Dim lstrOvertakeStatus      As String               '追越制限違反状態(0:追越制限違反無し、1:追越制限違反有り)
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@画面入力ﾁｪｯｸ
            lblnInputCheck = prvblnStartInput_Check
            '@結果判定
            If lblnInputCheck = False Then
                Exit Sub
            End If
            
        '@↓2007/02/13 (Tue) 14:19:25 N.Kasai **************************************************
            '@ﾚｽﾎﾟﾝｽｲﾍﾞﾝﾄ名設定
            lstrEventName = "cmdKakutei_Click"
            
            '@処理開始取消の場合は変更後が作業待ち、前処理でも権限ﾁｪｯｸを行なう。
            If lblOldStatus.Text = CPstrProcessingSt Then
                
                '@作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞあり
                frmxxCM0020.Instance.ShowDialog(Me)
                frmxxCM0020.Instance = Nothing
                
                '@作業者IDが空白又は、ｷｬﾝｾﾙの場合
                If pstrUserID = vbNullString Then
                    Exit Sub
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(Me.Name, lstrEventName)
                        
                '@変数初期化(ﾕｰｻﾞｰ名)
                lstrEmpName = vbNullString
                '@実行権限ﾁｪｯｸ(機能ID：EN0130、ｱｸｼｮﾝID:処理開始取消、ﾕｰｻﾞｰID、ﾕｰｻﾞｰ名、処理区分)
                lblnAns = pubAuthority_Chk(CPstrKeyEN0130, CPstrProcessingStCancel, pstrUserID, lstrEmpName, pstrSBID)
                
                '@結果判定
                If lblnAns = False Then
                
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, lstrEventName)
            
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, CPstrProcessingStCancel)
                    '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Exit Sub
                End If
            Else
                '@作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞなし
                frmxxCM0010.Instance.ShowDialog(Me)
                frmxxCM0010.Instance = Nothing
                
                '@作業者IDが空白又は、ｷｬﾝｾﾙの場合
                If pstrUserID = vbNullString Then
                    Exit Sub
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(Me.Name, lstrEventName)
            End If
                
            
        '    '@作業者ｺｰﾄﾞ入力
        '    frmxxCM0010.Show vbModal
        '
        '    '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
        '    If pblnCancel = True Then
        '        Exit Sub
        '    End If
        '@↑2007/02/13 (Tue) 14:19:25 N.Kasai **************************************************
            
        '@↓2014/11/26 (Wed) 15:34:04 H.Hayashi **************************************************

            '@起動SBが組立か
            If pstrSBID = CPstrSBID2A0 Then
                '@2A0：組立の場合
                       
                '@=======================
                '@ 無機ODF追越制限違反確認
                '@=======================
                lblnAns = pubblnOvertakeCancel_Sel(CMstrlot_chkovertakecancel, _
                                         lblLotID.Text, _
                                         mstrOvertakeWpId, _
                                         lstrOvertakeLotId, _
                                         lstrOvertakeStatus)
                       
                '@結果判定
                If lblnAns = False Then

                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, lstrEventName)
                    Exit Sub
                Else
                
                    '@追越制限取消違反が存在するか確認
                    If lstrOvertakeStatus = CPstrOvertakeNg Then
                                       
                        '@表示ﾒｯｾｰｼﾞ
                        '@「"<TRM134W>$$ロット[%1]は既に作業開始されているため、$本ロットを[%2]出来ません。"」のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0134, lstrOvertakeLotId, "作業開始取消/処理開始取消")
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(Me.Name, lstrEventName)
                    
                        Exit Sub

                    End If
                End If
            End If
        '@↑2014/11/26 (Wed) 15:34:04 H.Hayashi **************************************************
            
            
            '@作業開始取消ﾃﾞｰﾀ格納
            With ltypLotCnclWrkStart
                .strLotID = lblLotID.Text                            'ﾛｯﾄID
                .strEngEmpId = pstrUserID                               '作業者ID
                .strLotLastUpdate = mstrTaihiLotLastUpdate              'LOT最終更新日時
                .strCancelMode = cmbNewStatus.Value                     '取消ﾓｰﾄﾞ(0：作業待ちに戻す 1:前処理に戻す)
                .strComments = txtWorkMemo.Text                         '作業ﾒﾓ
            End With

            '@ﾒｯｾｰｼﾞ送信処理呼び出し
            lblnAns = pubblnCancelStart_Upd(CMstrlot_cnclwrkstartVer, _
                                            ltypLotCnclWrkStart, _
                                            lstrGuidMsg, _
                                            lstrGuidMsgCode)
            
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

                '取消ﾓｰﾄﾞ判定
                If ltypLotCnclWrkStart.strCancelMode = CMstrBeforeProgressMode Then
                    lstrAfterStName = CPstrBeforeProgressSt     '前処理へ
                Else
                    lstrAfterStName = CPstrWaitWorkSt           '作業待ちへ
                End If
                
                '取消前の状態を判別
                Select Case lblOldStatus.Text
                
                    '@前処理→作業待ちの場合
                    Case CPstrBeforeProgressSt
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0027, CMstrSagyou, CPstrBeforeProgressSt, _
                                    lstrAfterStName, txtCarrier.Text, lblLotID.Text)
                        
                     '@処理中→作業待ち/前処理の場合
                    Case CPstrProcessingSt
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0027, CMstrSyori, CPstrProcessingSt, _
                                    lstrAfterStName, txtCarrier.Text, lblLotID.Text)
                
                End Select
                
                '@"<TRM27I>$$%1開始を取消しました。状態(%2 → %3)キャリア[%4] ロット[%5]"
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                                        
                
                '@引継ﾌﾗｸﾞがあるか否かでﾊﾟﾌﾞﾘｯｸ構造体へｾｯﾄする情報を変更する
                If mblnFormLoadTakeOverFlag = True Then
                    '@戻り行判定用に引継ぎ構造体のｷｬﾘｱIDを書き換える
                    ptypCommonInfo.strCarrierId = txtCarrier.Text
                End If
                                        
                '@ｷｬﾘｱIDのｸﾘｱ
                txtCarrier.Text = vbNullString
                
                '@ﾛｯﾄ情報の初期化
                Call prvfrmxxEN0130_Init()
                
                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用不可)
                Call prvfrmxxEN0130_CmbInit(False)
                
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)
            
            '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrier)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdKakutei_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Change
    '機　能：ｷｬﾘｱIDを消した場合の表示ｸﾘｱ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 17:16:57 N.Kasai
    '更新日：2004/04/14 (Wed) 17:16:57
    '備　考：
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change

        Try
            
          '@ｷｬﾘｱIDを修正する場合はﾛｯﾄ情報をｸﾘｱする
            '@ﾛｯﾄ情報の初期化
            Call prvfrmxxEN0130_Init()
            
            '@ﾎﾞﾀﾝ状態
            Call prvfrmxxEN0130_CmbInit(False)
            
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
    '機　能：ｷｬﾘｱ情報取得
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/04/05 (Mon) 16:46:43 T.Kitagawa
    '更新日：2005/02/03 (Thu) 08:58:57 N.Kasai
    '備　考：
    '　　　：2005/02/03 (Thu) 08:58:57 N.Kasai  確定ﾎﾞﾀﾝの使用可否制御追加(№468)
    Public Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim ltypLotprestate         As Lotprestate          'ﾛｯﾄ情報格納構造体
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl Is cmdClose OrElse mblnWindowClose Then
                Exit Sub
            End If
            
            '@空ENTERの場合はﾌｫｰｶｽ移動のみ
            If Trim(txtCarrier.Text) = vbNullString Then
                '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽ設定
                 If ActiveControl.Name = txtCarrier.Name Then
                 Call pubSetFocus(cmdClose)
                 End If
                 Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtCarrier.NowByte < txtCarrier.ChrMaxByte Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                e.Cancel = True
                Call pubSetFocus(txtCarrier)
                Exit Sub
            End If

            '@ｷｬﾘｱID情報の取得(入力ｷｬﾘｱIDと前回のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功)と違う場合のみ実行)
            If Trim(txtCarrier.Text) <> vbNullString And _
                Len(Trim(txtCarrier.Text)) = CMlngCarrierMaxLength And _
                txtCarrier.Text <> mstrTaihiCarrierID Then
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                lstrFormName = Me.Name
                lstrEventName = "txtCarrier_Validate"
                Call pubResponseStart(lstrFormName, lstrEventName)
                
                '@ﾛｯﾄ情報の初期化
                Call prvfrmxxEN0130_Init()
                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用不可)
                Call prvfrmxxEN0130_CmbInit(False)
                '@ﾛｯﾄ情報の取得
                lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, CPstrCD19, txtCarrier.Text, ltypLotprestate)
                '@結果判定
                If lblnAns = True Then
                    '@画面表示処理
                    Call prvfrmxxEN0130_Disp(ltypLotprestate)
                Else
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    '@ﾊｲﾗｲﾄ表示
                    Call pubHighlight(txtCarrier)
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    Exit Sub
                End If
                 
                '@ｷｬﾘｱID退避(ﾒｯｾｰｼﾞ成功時)
                mstrTaihiCarrierID = txtCarrier.Text

        '@↓：2005/02/03 (Thu) 08:58:57 N.Kasai  確定ﾎﾞﾀﾝの使用可否制御追加(№468)

                '@取消後ｺﾝﾎﾞ内容の判定
                If cmbNewStatus.Text <> vbNullString Then
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用可)
                    Call prvfrmxxEN0130_CmbInit(True)
                    '@確定ﾎﾞﾀﾝへﾌｫｰｶｽ設定
                    If ActiveControl.Name = txtCarrier.Name Then
                    	Call pubSetFocus(cmdKakutei)
                    End If
                Else
                    '@取消後ｺﾝﾎﾞへﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = txtCarrier.Name Then
	                    If cmbNewStatus.Enabled = True Then
	                        Call pubSetFocus(cmbNewStatus)
	                    End If
	                End If
                End If
                
        '@↑：2005/02/03 (Thu) 08:58:57 N.Kasai  確定ﾎﾞﾀﾝの使用可否制御追加(№468)
             
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            Else
                '@上記以外の場合
                '@入力ｷｬﾘｱIDと前回のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功)と同じか判定する
                If txtCarrier.Text = mstrTaihiCarrierID Then
                    '@入力ｷｬﾘｱIDと前回のｷｬﾘｱIDが同じ場合
                    If cmdKakutei.Enabled = True Then
                        '@確定ﾎﾞﾀﾝへﾌｫｰｶｽ設定
                        If ActiveControl.Name = txtCarrier.Name Then
                        	Call pubSetFocus(cmdKakutei)
                        End If
                    Else
                        '@取消後ｺﾝﾎﾞが使用可能な場合
                        If cmbNewStatus.Enabled = True Then
                            If ActiveControl.Name = txtCarrier.Name Then
                            	Call pubSetFocus(cmbNewStatus)
                            End If
                        Else
                            '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽ設定
                            If ActiveControl.Name = txtCarrier.Name Then
                            	Call pubSetFocus(cmdClose)
                            End If
                        End If
                    End If
                End If
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

    '関数名：txtWorkMemo_Change
    '機　能：作業メモ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/04 (Fri) 12:42:01 N.Kasai
    '更新日：2005/12/02 (Fri) 12:09:30 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 12:09:30 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change
        
        Dim llngNowByte As Integer 'ﾊﾞｲﾄ数

        Try
            
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtWorkMemo.NowByte
            
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
                          
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
    '機　能：作業ﾒﾓｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:15:19 N.Kasai
    '更新日：2005/11/29 (Tue) 14:15:19
    '備　考：
    Private Sub txtWorkMemo_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtWorkMemo.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
         
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
    '機　能：作業ﾒﾓﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:52:24 N.Kasai
    '更新日：2005/11/29 (Tue) 14:52:24
    '備　考：
    Private Sub txtWorkMemo_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtWorkMemo.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
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
    '機　能：作業メモの前頁切替
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/04 (Fri) 12:39:37 N.Kasai
    '更新日：2005/12/02 (Fri) 12:07:43 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 12:07:43 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdMemoUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/12/02 (Fri) 12:07:40 N.Kasai **************************************************
        '    '@作業メモにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtWorkMemo)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
        '@↑2005/12/02 (Fri) 12:07:40 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMemoUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoDown_Click
    '機　能：作業メモの次頁切替
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/04 (Fri) 12:39:41 N.Kasai
    '更新日：2005/12/02 (Fri) 12:08:43 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 12:08:43 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdMemoDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/12/02 (Fri) 12:08:40 N.Kasai **************************************************
        '    '@作業メモにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtWorkMemo)
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
        '@↑2005/12/02 (Fri) 12:08:40 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdMemoDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbNewStatus_Change
    '機　能：取消後ｺﾝﾎﾞﾎﾞｯｸｽ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/03 (Thu) 09:18:52 N.Kasai
    '更新日：2005/02/03 (Thu) 09:18:52
    '備　考：
    Private Sub cmbNewStatus_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbNewStatus.Change

        Try
            
                '@取消後ｺﾝﾎﾞ内容の判定
                If cmbNewStatus.Text <> vbNullString Then
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用可)
                    Call prvfrmxxEN0130_CmbInit(True)
                    '@確定ﾎﾞﾀﾝへﾌｫｰｶｽ設定
                	RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                    Call pubSetFocus(cmdKakutei)
                	AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                End If
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbNewStatus_Change"
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

    '関数名：prvfrmxxEN0130_Init
    '機　能：ｷｬﾘｱ情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/05 (Mon) 16:46:43 T.Kitagawa
    '更新日：2014/12/02 (Tue) 13:55:27 H.Hayashi
    '備　考：
    '　　　：2004/08/26 (Thu) 09:15:26 N.Kasai      UNLADERｷｬﾘｱID追加
    '　　　：2004/10/04 (Mon) 14:05:16 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2005/02/02 (Wed) 11:39:19 N.Kasai      取消後ﾛｯﾄ状態表示をｺﾝﾎﾞﾎﾞｯｸｽへ変更(№468)
    '　　　：2005/03/01 (Tue) 16:58:50 S.Deguchi    不具合№261の対応で,WP_TYPEの退避領域の初期化処理を追加
    '　　　：2005/12/02 (Fri) 12:14:10 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2008/06/11 (Wed) 14:21:14 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2014/12/02 (Tue) 13:31:10 H.Hayashi    組立無機ODF環境のｼｽﾃﾑ環境整備
    Private Sub prvfrmxxEN0130_Init()
        
        Dim lstrFormTitle           As String           'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0130, lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@各ｺﾝﾄﾛｰﾙの初期化
            lblLotID.Text = vbNullString                             'ﾛｯﾄID
            lblFlowClass.Text = vbNullString                         '流動区分
            lblWFNo.Text = vbNullString                              'FW枚数
            lblOpID.Text = vbNullString                              '大工程ID
            lblStartDayTime.Text = vbNullString                      '開始日時
            lblPdID.Text = vbNullString                              '機種名
            lblS.Text = vbNullString                                 '特殊特性
            lblStatus.Text = vbNullString                            '状態
            lblStepID.Text = vbNullString                            '小工程ID
            lblLotManager.Text = vbNullString                        'ﾛｯﾄ担当
            lblTimeLimit.Text = vbNullString                         '時間制約
            lblWP.Text = vbNullString                                'WP名
            lblOldStatus.Text = vbNullString                         '取消前状態
            lblLoaderCarrier.Text = vbNullString                     'UNLOADERｷｬﾘｱID
            '@↓2020/02/19 (Wed) 13:48:44 Y.Yoneyama 「.Netへ反映未」 **************************************************
            lblGRB.Text = vbNullString                               'GRB
            '@GRB背景色
            lblGRB.BackColor = lblLotManager.BackColor
            '@↑2020/02/19 (Wed) 13:48:44 Y.Yoneyama 「.Netへ反映未」 **************************************************

            '@退避情報の初期化
            mstrTaihiCarrierID = vbNullString                           'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
            mstrTaihiLotLastUpdate = vbNullString                       'ﾛｯﾄ情報取得時の最終更新日時
            mstrAltNumber = vbNullString                                '代替番号
            mstrWPTYPE = vbNullString                                   'WP_TYPE
            mblnFormLoadTakeOverFlag = False                            '引継起動判別ﾌﾗｸﾞ
        '@↓2014/11/26 (Wed) 15:51:55 H.Hayashi **************************************************
            mstrOvertakeWpId = vbNullString                             '追越制限装置ID
        '@↑2014/11/26 (Wed) 15:51:55 H.Hayashi **************************************************
            
            '@取消後ﾛｯﾄ状態ｺﾝﾎﾞﾎﾞｯｸｽの初期化
            Call prvNewStatus_Init()
            
            '@作業ﾒﾓの初期化
            With txtWorkMemo
                .Enabled = False
                .ChrMaxByte = CPlngLotCommentsMaxByte
                .Text = vbNullString
                '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, CMlngMemoDefault, CPlngLotCommentsMaxByte)
            End With
            
        '@↓2005/12/02 (Fri) 12:14:37 N.Kasai **************************************************
        '    cmdMemoUp.Enabled = False
        '    cmdMemoDown.Enabled = False
        '@↑2005/12/02 (Fri) 12:14:37 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN0130_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN0130_CmbInit
    '機　能：各ｺﾏﾝﾄﾞﾎﾞﾀﾝの制御
    '引　数：lblnEnable：True:使用可能,False:使用不可
    '戻り値：なし
    '作成日：2004/04/05 (Mon) 16:46:43 T.Kitagawa
    '更新日：2004/04/05 (Mon) 16:46:43
    '備　考：
    Private Sub prvfrmxxEN0130_CmbInit(Optional ByVal lblnEnable As Boolean = False)

        Try
            
            '@各ｺﾏﾝﾄﾞﾎﾞﾀﾝのｺﾝﾄﾛｰﾙ
            cmdKakutei.Enabled = lblnEnable               '確定
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN0130_CmbInit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN0130_Disp
    '機　能：画面の表示
    '引　数：ltypLotprestate：ﾛｯﾄ情報を格納する構造体
    '戻り値：なし
    '作成日：2004/04/05 (Mon) 16:46:43 T.Kitagawa
    '更新日：2008/06/11 (Wed) 14:21:44 N.Kojima
    '備　考：
    '　　　：2004/08/25 (Wed) 14:24:53 N.Kasai      CFﾌﾗｸﾞ判定追加、"mm/dd hh:mm:ss"を共通変数化
    '　　　：2004/08/26 (Thu) 09:15:49 N.Kasai      UNLOADERｷｬﾘｱID追加
    '　　　：2004/09/09 (Thu) 19:12:07 Y.Yamagishi　時間制限表示変更(不具合改善№693)
    '　　　：2004/09/14 (Tue) 10:28:44 N.Kojima　   数量表示(TPALﾛｯﾄ対応)修正(不具合改善№730)
    '　　　：2004/09/24 (Fri) 11:31:13 Y.Yamagishi  制限時間以上の場合文字色を青に変更(不具合改善№825)
    '　　　：2005/02/02 (Wed) 11:41:42 N.Kasai      取消後ﾛｯﾄ状態表示をﾗﾍﾞﾙからｺﾝﾎﾞへ変更(№468)
    '　　　：2005/03/01 (Tue) 17:01:11 S.Deguchi    不具合№261の対応で退避領域へ情報を格納する処理を追加
    '　　　：2005/05/26 (Thu) 15:07:32 N.Kasai      LP_FLAG判定追加
    '　　　：2006/06/08 (Thu) 15:10:52 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2008/06/11 (Wed) 14:21:44 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxEN0130_Disp(ByRef ltypLotprestate As Lotprestate)
        
        Dim llngCnt As Integer 'ｶｳﾝﾄ

        Try

            '@ﾛｯﾄ情報の表示
            With ltypLotprestate
                lblLotID.Text = .strLotID                                                'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass                                        '流動区分
                lblOpID.Text = .strOpID                                                  '大工程ID
                '投入予定日時"mm/dd hh:mm:ss"
                If IsDate(.strDispatchStartTime) = True Then
                    lblStartDayTime.Text = Format$(CDate(.strDispatchStartTime), CPstrDateFormat)
                Else
                    lblStartDayTime.Text = .strDispatchStartTime
                End If
                lblPdID.Text = .strPdId                                                  '機種名
                lblS.Text = .strSpecialFlg                                               '特殊特性
                lblStatus.Text = .strNowST                                               '状態
                lblStepID.Text = .strStepID                                              '小工程ID
                lblLotManager.Text = .strEngEmpName                                      'ﾛｯﾄ担当
                '@↓2020/02/19 (Wed) 13:49:33 Y.Yoneyama 「.Netへ反映未」 **************************************************
                lblGRB.Text = .strGRBClass                                               'GRB
                '@GRB背景色
                lblGRB.BackColor = pubGRBBackColor(.strGRBClass, lblLotManager.BackColor)
                '@↑2020/02/19 (Wed) 13:49:33 Y.Yoneyama 「.Netへ反映未」 **************************************************
                
                '@時間制約有無の表示
                If .strLimitTime <> vbNullString Then

                    '@時間制約がﾌﾟﾗｽの場合
                    If CLng(.strLimitTime) >= 0 Then

        '@↓2006/06/08 (Thu) 15:10:42 N.Kojima **************************************************
                        '@制限時間以下or処理時間制限以下の場合
        '                If .strRestrictTypeID = CPstrRestrictTypeID1 Then
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@制限時間先大工程+制限時間先小工程+制限時間
                            '@ﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Format(CLng(.strLimitTime), CPstrDateFormatKanma) & CPstrh
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
                                    lblTimeLimit.ForeColor = vbBlack    '黒
                                End If
                            End If
                        End If
        '@↑2006/06/08 (Thu) 15:10:42 N.Kojima **************************************************
                    
                    Else
                    '@制限時間がﾏｲﾅｽの場合
                        '@制限時間先大工程+制限時間先小工程+制限時間
                        '@右寄せ
                        lblTimeLimit.TextAlign = ContentAlignment.TopRight
                        '@ForColorの変更
                        lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed)    '赤色
                        
        '@↓2006/06/08 (Thu) 15:11:56 N.Kojima **************************************************
                        '@制限時間以下or処理時間制限以下の場合
                        '@処理時間制限以下設定の場合、基本的に処理中で処理出来る機能しか関係ないが例外処理として挿入
        '                If .strRestrictTypeID = CPstrRestrictTypeID1 Then
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@ﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Format(CLng(.strLimitTime), CPstrDateFormatKanma) & CPstrh
                        End If
        '@↑2006/06/08 (Thu) 15:11:56 N.Kojima **************************************************
                        
                        '@制限時間以上の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID2 Then
                            '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Replace(Format(CLng(.strLimitTime), CPstrDateFormatKanma), CPstrReplaceMinus, vbNullString) & CPstrh
                        End If
                    End If
                End If
                        
                '@枚数表示判定(CF_FLAGを判定し、WF枚数とﾁｯﾌﾟ枚数の表示を切替)
                Select Case .strCfFlag
                    '@CFﾛｯﾄ
                    Case CPstrCF
                        
        '@↓2005/05/26 (Thu) 13:42:28 N.Kasai **************************************************
                        '@大判ﾌﾗｸﾞ判定(LP_FLAG)
                        If .strLpFlag = CPstrLP Then
                            '@大判の場合
                            lblWFNo.Text = .strWfNum                                         'WF枚数
                        Else
                            If IsNumeric(.strChipQuantity) Then
                                lblWFNo.Text = Format$(CLng(.strChipQuantity), CPstrCFKnmaFormat) 'ﾁｯﾌﾟ枚数
                            Else
                                lblWFNo.Text = .strChipQuantity
                            End If
                        End If
        '@↑2005/05/26 (Thu) 13:42:28 N.Kasai **************************************************
                        
                        
                    Case Else
                    '@CFﾛｯﾄ以外
                        '@TPALﾛｯﾄ
                        If Trim(Strings.Left(.strLotID, 2)) = CPstrTpalLot Then
                            lblWFNo.Text = Format$(CLng(.strChipQuantity), CPstrCFKnmaFormat)      'ﾁｯﾌﾟ枚数
                        Else
                            '@CF,TPALﾛｯﾄ以外
                            lblWFNo.Text = .strWfNum                                         'WF枚数
                        End If
                End Select
                
                lblLoaderCarrier.Text = .strCarrierId                                    'UNLOADERｷｬﾘｱID
                
                '@退避情報
                mstrTaihiLotLastUpdate = .strLotLastUpdate                                  'ﾛｯﾄ最終更新日時
                llngCnt = 1
                mstrAltNumber = .strAltNumber                                               '代替番号
                
                lblWP.Text = .strWpName                                                  '装置名
            
        '@↓2005/03/01 (Tue) 17:00:56 S.Deguchi **************************************************追加
                mstrWPTYPE = .strWpTypeFlag                                                 'WP_TYPE
        '@↑2005/03/01 (Tue) 17:00:56 S.Deguchi **************************************************追加

        '@↓2014/11/26 (Wed) 15:53:24 H.Hayashi **************************************************
                mstrOvertakeWpId = .strWpID                                                 'WP_ID
        '@↑2014/11/26 (Wed) 15:53:24 H.Hayashi **************************************************
            
            End With
                
            '@取消前後状態
            lblOldStatus.Text = lblStatus.Text                                        '取消前状態(「前処理/処理中」)
            
        '@↓：2005/02/02 (Wed) 11:41:42 N.Kasai      取消後ﾛｯﾄ状態表示をﾗﾍﾞﾙからｺﾝﾎﾞへ変更(№468)
        ''    lblNewStatus.Caption = CPstrWaitWorkSt                                          '取消後状態(「作業待ち」)
                
            '@ｺﾝﾎﾞﾎﾞｯｸｽに値を設定
            Call prvNewStatus_Disp()
            
            txtWorkMemo.Enabled = True
            
        '@↓2005/12/02 (Fri) 12:13:29 N.Kasai **************************************************
        '    cmdMemoUp.Enabled = True
        '    cmdMemoDown.Enabled = True
        '@↑2005/12/02 (Fri) 12:13:29 N.Kasai **************************************************
            
        '@↑：2005/02/02 (Wed) 11:41:42 N.Kasai      取消後ﾛｯﾄ状態表示をﾗﾍﾞﾙからｺﾝﾎﾞへ変更(№468)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN0130_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnStartInput_Check
    '機　能：確定時の入力チェック
    '引　数：なし
    '戻り値：True：項目正常、False：不正項目あり
    '作成日：2004/04/05 (Mon) 16:46:43 T.Kitagawa
    '更新日：2005/02/02 (Wed) 13:11:48 N.Kasai
    '備　考：
    '　　　：2005/02/02 (Wed) 13:11:48 N.Kasai      前処理、処理中ででも処理可(№468)
    '　　　：2005/03/04 (Fri) 08:53:59 S.Deguchi    ﾊﾝﾄﾞﾜｰｸ対応で処理中に出すﾒｯｾｰｼﾞは出さないように修正
    Private Function prvblnStartInput_Check() As Boolean
        
        Dim llngAns As Integer  '汎用戻り値

        Try
            
            prvblnStartInput_Check = False
            
            '@ｷｬﾘｱIDの入力ﾁｪｯｸ
            If txtCarrier.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                '@"キャリアIDが設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If
            If Len(txtCarrier.Text) <> CMlngCarrierMaxLength Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If

        '@↓：2005/02/02 (Wed) 13:11:48 N.Kasai      前処理、処理中ででも処理可(№468)
        '    '@状態ﾁｪｯｸ
        '    If lblStatus.Caption <> CPstrBeforeProgressSt Then
        '        '@表示ﾒｯｾｰｼﾞ変換
        '        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0037)
        '        '@"「前処理」以外のロットは取消しできません。”
        '        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxEN0130.Caption, True, 16)
        '        txtCarrier.SetFocus
        '        Exit Function
        '    End If
        '@↑：2005/02/02 (Wed) 13:11:48 N.Kasai      前処理、処理中ででも処理可(№468)
            
        '@↓2005/03/04 (Fri) 08:56:03 S.Deguchi **************************************************修正(H/W対応)
            '@ﾛｯﾄ状態の判定(工程がﾊﾝﾄﾞﾜｰｸ以外の場合)
            If mstrWPTYPE <> CMstrHandWork Then
                '@ﾛｯﾄ状態が「処理中」の場合=処理取消実行時のみ確認ﾒｯｾｰｼﾞを表示する。
                If lblStatus.Text = CPstrProcessingSt Then
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004U)
                    '@"<TRM4UW>$$処理開始の取消を行います。$$ウエハの処理が実行されていない事、$ロードポートにキャリアが積載されていない事を確認の上、 実行して下さい。"
                    llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                    '@要求確認
                    If llngAns = vbNo Then
                        '@処理しない
                        Exit Function
                    End If
                End If
            End If
        '@↑2005/03/04 (Fri) 08:56:03 S.Deguchi **************************************************修正(H/W対応)

            '@入力ＯＫ
            prvblnStartInput_Check = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnStartInput_Check"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvNewStatus_Init
    '機　能：取消後ﾛｯﾄ状態ｺﾝﾎﾞﾎﾞｯｸｽ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/02 (Wed) 10:53:25 N.Kasai
    '更新日：2005/02/02 (Wed) 10:53:25
    '備　考：
    Private Sub prvNewStatus_Init()

        Try
            
            '@ｺﾝﾎﾞﾎﾞｯｸｽ使用不可
            cmbNewStatus.Enabled = False

            '@ｺﾝﾎﾞﾎﾞｯｸｽ設定
            With cmbNewStatus
                .Clear
                .DispCols = CMlngCmbDispCols                                'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbStName                                    'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbCancelMode                              '値取得列
                .DirectInput = False                                        'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Text = vbNullString                                        '初期化
                .Font = New Font(.Font.FontFamily, _ 
                                 CMlngCmbFontSize, .Font.Style, .Font.Unit)                 'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, _
                                     CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit) 'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngComboRowHeight                            'ｸﾞﾘｯﾄﾞの高さ
                .ColAlignment(CMlngCmbStName) = CMlngCmbAlignLeftCenter                     'ｸﾞﾘｯﾄﾞ表示位置（左中央）
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvNewStatus_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvNewStatus_Disp
    '機　能：取消後ﾛｯﾄ状態をｺﾝﾎﾞへｾｯﾄ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/02/02 (Wed) 10:22:41 N.Kasai
    '更新日：2005/02/02 (Wed) 10:22:41
    '備　考：
    '　　　：2005/03/01 (Tue) 17:02:25 S.Deguchi    不具合№261の対応でﾊﾝﾄﾞﾜｰｸ工程の判別処理を追加
    Private Sub prvNewStatus_Disp()

        Try
                
                '@ｺﾝﾎﾞﾎﾞｯｸｽ使用可
                cmbNewStatus.Enabled = True
                
                '@取消後ﾛｯﾄ状態ｾｯﾄ
                '@ComboBoxEx並び【0:名称/1:CANCEL_MODE(0:作業待ち、1:前処理)】
                With cmbNewStatus
                    .Clear
                    .AddItem(CPstrWaitWorkSt & vbTab & CMstrstrWaitWorkMode)                     '作業待ち
                    
                    '@前処理→前処理の変更は不可
                    '@取消前=取消後の状態を判定して同一の場合はｺﾝﾎﾞ表示なし
                    If lblOldStatus.Text <> CPstrBeforeProgressSt Then
        '@↓2005/03/01 (Tue) 17:04:57 S.Deguchi **************************************************処理修正
                        '@ﾊﾝﾄﾞﾜｰｸ工程の場合
                        If mstrWPTYPE = CMstrHandWork Then
                            '@情報をｾｯﾄしない
                        Else
                            '@前処理をｾｯﾄ
                            .AddItem(CPstrBeforeProgressSt & vbTab & CMstrBeforeProgressMode)    '前処理
                        End If
        '@↑2005/03/01 (Tue) 17:04:57 S.Deguchi **************************************************処理修正
                    End If
                    
                    '@優先順位が１件の場合
                    If .ListCount = 1 Then
                        '@１件目表示
                        .ListIndex = 0
                    End If
                    
                End With
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvNewStatus_Disp"
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
