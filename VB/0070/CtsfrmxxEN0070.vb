'ﾌｧｲﾙ名：xxEN0070.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：処理開始　メインフォーム
'作成日：2004/03/16 (Tue) 14:12:51 T.Oide
'更新日：2015/11/15 (Sun) 18:01:32 H.Hayashi
'備　考：2004/10/22 (Fri) 12:03:39 T.Kitagawa WAIST検査機対応
'      ：2012/02/29 (Wed) 15:28:33 Y.Yoneyama PLCﾚｼﾋﾟ照合機能対応
'      ：2015/11/09 (Mon) 10:15:33 H.Hayashi    千歳Spirytus_Prism処理チャンバー選択機能(H31096937)
'Copyright(C) SEIKO EPSON CORPORATION 2003-2015, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN0070
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN0070    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN0070
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN0070
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN0070)
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
    '@↓2020/03/06 (Fri) 11:06:51 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion         As String = "08.02"
    Private Const CMstrLocalVersion         As String = "09.00"
    '@↑2020/03/06 (Fri) 11:06:51 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝの宣言
    '@↓2020/01/15 (Wed) 14:10:45 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_curstateVer      As String = "03.04"         'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer      As String = "04.00"         'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 14:10:45 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CPstrlot_wplist__Ver      As String = "02.05"         'ﾛｯﾄ装置情報取得
    '@↓2020/07/01 (Wed) 11:42:19 T.Oide 「.Netへ反映未」 **************************************************
    '@Private Const CMstrlot_recplistVer      As String = "02.04"         'ﾛｯﾄﾚｼﾋﾟﾘｽﾄ取得
    Private Const CMstrlot_recplistVer      As String = "02.05"         'ﾛｯﾄﾚｼﾋﾟﾘｽﾄ取得
    '@↑2020/07/01 (Wed) 11:42:19 T.Oide 「.Netへ反映未」 **************************************************
    Private Const CMstrlot_prcstartVer      As String = "07.00"         'ﾛｯﾄ処理開始
    Private Const CMstrlot_chkwaistVer      As String = "01.00"         'WAITﾃﾞｰﾀ状態確認
    Private Const CMstreqchkintervalVer     As String = "01.00"         '装置経過時間ﾁｪｯｸ
    Private Const CMstrlot_chkfrtimerecipeVer   As String = "01.00"         'FR処理可能範囲ﾚｼﾋﾟ確認

    Private Const CMstrMaiyouRecpName       As String = "枚葉レシピ"
    Private Const CMstrLotRecpName          As String = "ロットレシピ"
    Private Const CMlngCarrierMaxLength     As Integer = 6              'ｷｬﾘｱIDの最大桁数

    Private Const CMlngEqFlag               As Integer = 0              '装置ﾌﾗｸﾞ
    Private Const CMlngcmbPortID            As Integer = 2              'ﾎﾟｰﾄID列

    Private Const CMstrDefault              As String = "○"            '小工程ﾃﾞﾌｫﾙﾄﾏｰｸ
    Private Const CMstrStepdivisionDefault  As String = "1"             '工程ﾌﾗｸﾞ(1：ﾃﾞﾌｫﾙﾄ工程)
    Private Const CMlngIndex                As Integer = 0                 '装置構造体ｲﾝﾃﾞｯｸｽ
    Private Const CMstrNoneRecipe           As String = "レシピ無し"    'ﾚｼﾋﾟ設定ﾎﾞﾀﾝ制御用
    Private Const CMstrLoaderUnloaderFlg    As String = "1"             'Loader/Unloaderﾌﾗｸﾞ(L/N装置)
    Private Const CMstrEN0070Title          As String = "処理開始"
 
    '@制限ﾀｲﾌﾟ
    Private Const CMstrRestrictTypeID1      As String = "1"             '以下
    Private Const CMstrRestrictTypeID2      As String = "2"             '以上

    Private Const CMlngDispCols             As Integer = 2              'ｺﾝﾎﾞ表示列数
    Private Const CMlngRecpCrLen            As Integer = 16             'ﾚｼﾋﾟ折り返し文字数

    '@WAISTﾃﾞｰﾀ状態
    Private Const CMstrWaistStatus0         As String = "0"             '正常
    Private Const CMstrWaistStatus1         As String = "1"             '入力ﾌｧｲﾙ作成中
    Private Const CMstrWaistStatus2         As String = "2"             '入力ﾌｧｲﾙ作成異常
    Private Const CMstrWaistStatus3         As String = "3"             'DB更新中
    Private Const CMstrWaistStatus4         As String = "4"             'DB更新異常

    '@↓2015/11/13 (Fri) 13:15:53 H.Hayashi **************************************************
    '@FR処理可能ﾚｼﾋﾟ有無状態
    Private Const CMstrFrRecipeStatus0      As String = "0"             '表示不要
    Private Const CMstrFrRecipeStatus1      As String = "1"             '正常表示
    Private Const CMstrFrRecipeStatus2      As String = "2"             '異常表示(FR累積範囲以外)
    Private Const CMstrFrRecipeStatus3      As String = "3"             '異常表示(処理部状態に一致しないﾚｼﾋﾟ)
    '@↑2015/11/13 (Fri) 13:15:53 H.Hayashi **************************************************

    '@ﾃｷｽﾄ
    Private Const CMlngMaxDispRow           As Integer = 4              'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(ﾛｯﾄｺﾒﾝﾄ)
    Private Const CMlngMaxDispMemoRow       As Integer = 3              'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(作業ﾒﾓ)

    '@↓2012/02/28 (Tue) 17:47:29 Y.Yoneyama **************************************************
    '@結果用
    Private Const CMstrOK                   As String = "OK"            '結果OK
    Private Const CMstrNG                   As String = "NG"            '結果NG
    '@↑2012/02/28 (Tue) 17:47:29 Y.Yoneyama **************************************************

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mstrLotLastUpdate               As String                   'ﾛｯﾄ最終更新日時
    Private mstrCarrier                     As String                   'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mlngLotRecpListCnt              As Integer                  'ﾚｼﾋﾟﾘｽﾄ件数
    Private mstrAltNumber                   As String                   '代替番号
    Private mblnTakeOverDispFlg             As Boolean                  '引継ぎ表示ﾌﾗｸﾞ
    Private mblnBacthFlg                    As Boolean                  'ﾊﾞｯﾁ編成ﾌﾗｸﾞ(True：ﾊﾞｯﾁ編成、False：通常)
    Private mtypLotCurState                 As Lotprestate              'ﾛｯﾄ情報格納構造体
    Private mblnRecipeChkFlg                As Boolean                  'ﾚｼﾋﾟﾁｪｯｸﾌﾗｸﾞ(True：ﾚｼﾋﾟなし、False：ﾚｼﾋﾟあり)
    
    Private buttonProcessing                    As Boolean              'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean              'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean              'NSYS WindowCloseフラグ
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
    '機　能：ﾌｫｰﾑ　起動時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/02/27 (Fri) 16:32:23 T.Oide
    '更新日：2005/11/29 (Tue) 16:50:22 N.Kasai
    '備　考：
    '　　　：2005/11/29 (Tue) 16:50:22 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub Form_Load()
        
        Dim lblnAns         As Boolean      '戻り値

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@=======================
            '@　機能ﾊﾞｰｼﾞｮﾝの判定
            '@=======================
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN0070, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@ﾛｯﾄ情報の初期化
            Call prvfrmxxEN0070_Init()
            
        '@↓2005/11/29 (Tue) 16:24:21 N.Kasai **************************************************
            cmdTxtUp.Enabled = False                    'ｺﾒﾝﾄ ▲ﾎﾞﾀﾝ
            cmdTxtDown.Enabled = False                  'ｺﾒﾝﾄ ▼ﾎﾞﾀﾝ
            cmdMemoUp.Enabled = False                   '作業ﾒﾓ ▲ﾎﾞﾀﾝ
            cmdMemoDown.Enabled = False                 '作業ﾒﾓ ▼ﾎﾞﾀﾝ
        '@↑2005/11/29 (Tue) 16:24:21 N.Kasai **************************************************

            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用不可)
            Call prvfrmxxEN0070_CmbInit(False)
            
            '@ｷｬﾘｱIDのｸﾘｱ
            txtCarrier.Text = vbNullString
            
            '@閉じるボタンへCausesValidationを設定する
            cmdClose.CausesValidation = False
            
            '@ｺﾝﾎﾞ設定
            cmbPort.RowHeight = 43
            cmbPort.ColAlignment(0) = TextAlignEnum.LeftCenter
            
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = 0 

            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
            
            '@引継ぎ情報表示済みﾌﾗｸﾞ
            mblnTakeOverDispFlg = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
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
    '作成日：2004/07/27 (Tue) 14:33:25 H.Wajima
    '更新日：2004/07/27 (Tue) 14:33:25
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            
            '@引継ぎ情報表示済みﾌﾗｸﾞの判定
            '@FormLoad後、最初の1回しか処理しない
            If mblnTakeOverDispFlg = True Then
            '@引継ぎ情報が表示済みの場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose
            
            '@引継ぎ情報表示済みﾌﾗｸﾞにTrueを設定する
            mblnTakeOverDispFlg = True
            
            '@引数のキャリアIDが空白かどうか判定する
            If ptypCommonInfo.strCarrierId <> vbNullString Then
            '@空白でない場合
                '@キャリアIDの初期値を設定する
                txtCarrier.Text = ptypCommonInfo.strCarrierId
                
                '@ｷｬﾘｱ情報を取得する
                RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                
                '@作業ﾒﾓが有効の場合ﾌｫｰｶｽを次に移動させる
                If txtWorkMemo.Enabled = True Then
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If
            Else
            '@空白の場合
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
                .strMenuKey = CPstrKeyEN0070
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
    '作成日：2004/03/03 (Wed) 12:31:54 T.Kitagawa
    '更新日：2004/08/06 (Fri) 14:41:48 Y.Yamagishi
    '備　考：
    '　　　：2004/09/24 (Fri) 15:14:41 S.Deguchi    ActiveControlがｷｬﾘｱIDの場合の判別式を修正しました。(作業ﾒﾓ⇒ﾎﾟｰﾄ№)
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

             Select Case e.KeyCode
                '@Enterｷｰの場合
                Case Keys.Return
                    Select Case ActiveControl.Name
                        '@ｷｬﾘｱID
                        Case txtCarrier.Name
                            '@ｷｬﾘｱID入力ﾁｪｯｸ
                            RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                            Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                            AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                            '@ﾎﾟｰﾄ№が有効の場合ﾌｫｰｶｽを次に移動させる
                            If cmbPort.Enabled = True Then
                                SendKeys.SendWait(CPstrSendKeysTab)
                                e.Handled = True
                            End If

                            Exit Sub
                            
                        '@作業ﾒﾓ
                        Case txtWorkMemo.Name
                            Exit Sub
                            
                    End Select
                    
                    SendKeys.SendWait(CPstrSendKeysTab)
                    e.Handled = True
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
                .strProcName = "Form_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel    ：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/03/16 (Tue) 13:22:21 K.Takano
    '更新日：2004/04/13 (Tue) 16:32:50 N.Kasai
    '備　考：
    '　　　：2004/04/13 (Tue) 16:32:50 N.Kasai  閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try

            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload           '@NSYS 閉じる処理抜け
                Call cmdClose_Click(sender, e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
            pblnFormLoad = False
            
            '@ﾚｼﾋﾟﾘｽﾄ構造体のｸﾘｱ
            ptypLotrecpList = Nothing
            
            '@WFﾄﾗﾝﾚｼﾋﾟ初期化
            ptypWFrecpList = Nothing
            
            '@ActInitﾌﾗｸﾞの判定
            If pblnActInitFlg = True Then
            '@Actを自前で初期化した場合
                '@ACTｵﾌﾞｼﾞｪｸﾄの開放
                lblnAnsTerm = pubblnAct_Term
                '@結果判定
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
                .strMenuKey = CPstrKeyEN0070
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
    '戻り値：
    '作成日：2004/03/16 (Tue) 15:51:58 T.Oide
    '更新日：2005/02/15 (Tue) 13:25:37 N.Kojima
    '備　考：
    '　　　：2005/02/15 (Tue) 13:25:37 N.Kojima 戻り先画面の判定を追加(改善№512)
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
            
            '@引継ぎ情報のキャリアIDが空白かどうか判定する
            If ptypCommonInfo.strCarrierId <> vbNullString Then
            '@空白でない場合
                '@装置別ﾛｯﾄ一覧から引き継いで起動された場合
                If pblnfrmxxEN0150Kbn = True Then
                    '@装置別ﾛｯﾄ一覧を起動する
                    Call pubMenuSelect_Proc(CPstrKeyEN0150)
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
                Call publngEnd_Proc(CPstrKeyEN0070, ltypCommonInfo)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
                .strProcName = "cmdClose_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdWFRecp_Click
    '機　能：ﾚｼﾋﾟ詳細表示画面を表示する
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/16 (Tue) 16:39:56 T.Oide
    '更新日：2005/08/12 (Fri) 13:31:32 N.Kasai
    '備　考：
    '　　　：2004/09/27 (Mon) 19:32:02 M.Miura　    ﾚｼﾋﾟ変更確定後のｱﾝﾛｰﾀﾞｰﾎﾟｰﾄ設定、ﾛｯﾄ最終更新日時設定追加
    '　　　：2005/08/12 (Fri) 13:31:32 N.Kasai      ﾚﾁｸﾙが装置にない場合の２重ｴﾗｰ表示を抑止(№2418)
    '　　　：2005/10/25 (Tue) 17:08:44 S.Deguchi    引継起動処理を修正
    Private Sub cmdWFRecp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWFRecp.Click
        
        Dim llngIndex           As Integer          'ﾎﾟｰﾄIndex格納
        Dim llngUnLoaderIndex   As Integer          'ｱﾝﾛｰﾀﾞｰﾎﾟｰﾄIndex格納
        Dim lstrWorkMemo        As String           '作業ﾒﾓ格納

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
            
            '@ﾎﾟｰﾄIndex退避
            llngIndex = cmbPort.ListIndex
            '@ｱﾝﾛｰﾀﾞｰﾎﾟｰﾄIndex退避
            llngUnLoaderIndex = cmbLoaderPort.ListIndex
            
            '@作業ﾒﾓ退避
            lstrWorkMemo = txtWorkMemo.Text

            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@起動ﾌﾗｸﾞ(親から起動)
            pblnfrmxxCM0050Kbn = True
            
            '@ﾚｼﾋﾟ設定変更画面起動
            frmxxCM0050.Instance = New frmxxCM0050()
            
            '@ﾚｼﾋﾟ詳細画面名称設定
            frmxxCM0050.Instance.Text = CPstrSubDispTitleRepSet
            
        '@↓2005/10/25 (Tue) 17:09:09 S.Deguchi **************************************************
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@特殊処理：起動失敗の場合には,明示的にﾌﾗｸﾞを立てる
                pblnfrmxxCM0050CVFlag = True
                
                '@異常の場合は子画面終了
                frmxxCM0050.Instance = Nothing
                
                '@ﾌﾗｸﾞを戻す
                pblnfrmxxCM0050CVFlag = False
                
                Exit Sub
            End If
        '@↑2005/10/25 (Tue) 17:09:09 S.Deguchi **************************************************
            
            '@レシピ詳細表示画面を表示(ｴﾗｰ時に画面を表示しない為、下記3行必要)
            frmxxCM0050.Instance.ShowDialog(Me)
            frmxxCM0050.Instance = Nothing
            
            '@ｻﾌﾞ画面で確定の場合
            If pblnSubDecision = True Then
                '@ﾛｯﾄ最終更新日時を取得する為
                '@ｷｬﾘｱID変更処理
                RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                Call txtCarrier_Change(txtCarrier, New EventArgs)
                txtCarrier.Text = pstrCarrierID
                
                '@ｷｬﾘｱID入力ﾁｪｯｸ
                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                
                '@ﾎﾟｰﾄIndex反映
                cmbPort.ListIndex = llngIndex
                '@ｱﾝﾛｰﾀﾞｰﾎﾟｰﾄIndex反映
                cmbLoaderPort.ListIndex = llngUnLoaderIndex
                
                '@作業ﾒﾓ反映
                txtWorkMemo.Text = lstrWorkMemo
                '@最終更新日時を格納
                mstrLotLastUpdate = ptypLotprestate.strLotLastUpdate
            End If
                    
            
        '@↓2005/08/12 (Fri) 13:02:01 N.Kasai **************************************************
            '@------------------------------------------------------
            '@ﾚｼﾋﾟIDが無い場合はﾚｼﾋﾟ取得は行わない。(№2418)
            '@ 連動して起動し場合、ﾚﾁｸﾙが未設定の場合処理開始させない。
            '@------------------------------------------------------
            If lblRecpType.Text <> vbNullString Then
                '@ﾚｼﾋﾟ表示
                Call prvRecp_Disp()
            End If
        '@↑2005/08/12 (Fri) 13:02:01 N.Kasai **************************************************
            
            
            '@Unloaderﾎﾟｰﾄがﾛｯｸ解除の場合
            If cmbLoaderPort.Enabled = True Then
                Call pubSetFocus(cmbLoaderPort)
                Exit Sub
            End If
            
            '@確定ﾎﾞﾀﾝがﾛｯｸ解除の場合
            If cmdRegist.Enabled = True Then
                '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdRegist)
            End If
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
                .strProcName = "cmdWFRecp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTxtUp_Click
    '機　能：ｺﾒﾝﾄの前頁切替処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 10:34:21 Y.Yamagishi
    '更新日：2004/09/07 (Tue) 19:02:12 N.Kasai
    '備　考：
    '　　　：2004/09/07 (Tue) 19:02:12 N.Kasai      ｺﾒﾝﾄ欄の使用可否判定追加
    Private Sub cmdTxtUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｺﾒﾝﾄ欄の使用可否判定
            If txtLotCommnt.Enabled = True Then
        '        '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '        Call pubSetFocus(txtLotCommnt)
        '        '@PageUpｷｰ
        '        SendKeys CPstrSendKeysPageUp, True

        '@↓2005/11/29 (Tue) 16:45:24 N.Kasai **************************************************
                '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
                Call pubtxtCmdUp_Proc(txtLotCommnt, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
        '@↑2005/11/29 (Tue) 16:45:24 N.Kasai **************************************************
                
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
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
    '更新日：2004/09/07 (Tue) 19:02:59 N.Kasai
    '備　考：
    '　　　：2004/09/07 (Tue) 19:02:59 N.Kasai      ｺﾒﾝﾄ欄の使用可否判定追加
    Private Sub cmdTxtDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｺﾒﾝﾄ欄の使用可否判定
            If txtLotCommnt.Enabled = True Then
        '        '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '        Call pubSetFocus(txtLotCommnt)
        '        '@PageDownｷｰ
        '        SendKeys CPstrSendKeysPageDown, True

        '@↓2005/11/29 (Tue) 16:45:55 N.Kasai **************************************************
                '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
                Call pubtxtCmdDown_Proc(txtLotCommnt, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
        '@↑2005/11/29 (Tue) 16:45:55 N.Kasai **************************************************
                
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
                .strProcName = "cmdTxtDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbLoaderPort_CloseUp
    '機　能：Unloaderﾎﾟｰﾄ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/12 (Thu) 12:07:27 N.Kasai
    '更新日：2004/08/12 (Thu) 12:07:27
    '備　考：
    Private Sub cmbLoaderPort_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLoaderPort.CloseUp

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            With cmbLoaderPort
                '@取得列をﾎﾟｰﾄIDに設定
                .ValueCol = CMlngcmbPortID
                '@ﾎﾟｰﾄIDが選択されている場合
                If .Value <> vbNullString Then
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
                .strProcName = "cmbLoaderPort_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommntInput_Click
    '機　能：ﾛｯﾄｺﾒﾝﾄ入力ﾌｫｰﾑ表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/16 (Tue) 16:51:52 T.Oide
    '更新日：2008/06/04 (Wed) 11:38:33 N.Kojima
    '備　考：
    '　　　：2008/06/04 (Wed) 11:38:33 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
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

            'ptypLotprestateに格納してfrmxxCM0030を呼ぶ
            '@渡すﾃﾞｰﾀを格納
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
                '@↓2020/01/15 (Wed) 17:00:57 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .strGRBClass = lblGRB.Text
                '@↑2020/01/15 (Wed) 17:00:57 Y.Yoneyama 「.Netへ反映未」 **************************************************
                
                pstrCarrierID = txtCarrier.Text                         'ｷｬﾘｱID
                
                '@親ﾌｫｰﾑからの呼び出しを識別するためにTrueにする
                pblnfrmxxCM0030Kbn = True
            
                '@起動ﾌﾗｸﾞを設定
                pblnFormLoad = False
                
                '@ﾌｫｰﾑをﾛｰﾄﾞする
                frmxxCM0030.Instance = New frmxxCM0030()
                
                '@ﾒﾆｭｰｷｰから機能の関連情報を取得する
                Call pubMenuItemCorrelation_Set(CPstrKeyEN0140, lstrTitle)

                '@ｺﾒﾝﾄ画面の名称設定
                frmxxCM0030.Instance.Text = lstrTitle
                
                '@ﾌｫｰﾑの呼出識別から判別
                If pblnFormLoad = True Then
                    '@ｺﾒﾝﾄ入力・表示画面を表示
                    frmxxCM0030.Instance.ShowDialog(Me)
                    frmxxCM0030.Instance = Nothing
                    
                    '@ｺﾒﾝﾄｾｯﾄ
                    txtLotCommnt.Text = .strComments
                    
                    '@最終更新日時ｾｯﾄ
                    mstrLotLastUpdate = ptypLotprestate.strLotLastUpdate
                Else
                    '@ｱﾝﾛｰﾄﾞする
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

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
                .strProcName = "cmdCommntInput_Click"
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
    '作成日：2004/03/17 (Wed) 16:25:17 T.Kitagawa
    '更新日：2015/12/01 (Tue) 13:51:10 H.Hayashi
    '備　考：
    '　　　：2004/09/17 (Fri) 12:55:09 Y.Yamagishi  時間制限対応(不具合改善№701)
    '　　　：2004/09/23 (Thu) 17:08:03 Y.Yamagishi　時間制限対応(不具合改善№871)
    '　　　：2004/10/05 (Tue) 13:35:23 M.Miura　    構造体のﾚｼﾋﾟIDを削除(未使用の為)
    '　　　：2004/10/22 (Fri) 12:13:56 T.Kitagawa　 WAIST検査機対応
    '　　　：2005/02/03 (Thu) 20:04:20 N.Kojima　   処理終了から戻った際にｶﾚﾝﾄ行が保持されるように修正(不具合№506)
    '　　　：2005/02/09 (Wed) 14:13:56 S.Deguchi    不具合№521対応 引継構造体のToCarrierIDへ情報ｾｯﾄ処理を追加
    '　　　：2005/04/21 (Thu) 17:32:49 N.Kojima     CMP関連追加対応。
    '　　　：2005/09/26 (Mon) 09:56:17 S.Deguchi    不具合№2389の対応でﾚｽﾎﾟﾝｽ処理を見直し。
    '　　　：2012/02/28 (Tue) 17:10:13 Y.Yoneyama   PLCﾚｼﾋﾟ照合機能追加
    '      ：2015/11/20 (Fri) 16:29:27 H.Hayashi    千歳Spirytus_Prism処理チャンバー選択機能(H31096937)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnInputCheck          As Boolean              '画面入力ﾁｪｯｸ(True:正常,False:異常)
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypLotprcstart         As Lotprcstart          'ﾛｯﾄ処理開始構造体
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrToOpID              As String               '制限時間先大工程
        Dim lstrToStepID            As String               '制限時間先小工程
        Dim lstrLimitTime           As String               '制限時間
        Dim lstrWarnTime            As String               '警告時間
        Dim llngAns                 As String               '警告時間ﾁｪｯｸ結果
        Dim lstrWaistStatus         As String               'WAISTﾃﾞｰﾀ状態
        Dim llngWaistAns            As Integer              'WAISTﾃﾞｰﾀ状態確認MsgBox戻り値
        Dim lstrRecipID             As String               'ﾚｼﾋﾟID(lot_.prcstartの応答)
        Dim lstrPolTime             As String               '研磨時間(lot_.prcstartの応答)
        Dim lstrPlcResult           As String               'PLCﾚｼﾋﾟ照合結果
        Dim lblnPlcWarning          As Boolean              'PLC警告
        Dim lstrFrRecipeStatus      As String               'FR処理可能ﾚｼﾋﾟ有無状態
                                                            '(0:表示不要/1:正常表示/2:異常表示)
        Dim lstrNgChamberId         As String               'FrNG結果の処理部
        Dim lstrNgProcessTime       As String               'FrNG結果のFR累積時間
        Dim lstrNgRecipeId          As String               'FrNG結果のﾚｼﾋﾟ
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim llngFrAns               As Integer              'FR処理可能ﾚｼﾋﾟ有無状態確認MsgBox戻り値

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

            '@ﾌｫｰﾑのﾛｯｸ中は処理を行わない
            If Me.Enabled = False Then
                Exit Sub
            End If
            
            '@画面入力ﾁｪｯｸ
            lblnInputCheck = prvblnStartInput_Check
            If lblnInputCheck = False Then
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
            lstrFormName = Me.Name
            lstrEventName = "cmdRegist_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ﾌｫｰﾑﾛｯｸ
            
            '@WAIST検査機の場合はWAIST結果が格納されているか確認する(※装置ﾀｲﾌﾟがWAIST検査機の場合のみ)
            If mtypLotCurState.strEqType = CPstrEqTypeWAIST Then
                '@WAISTﾃﾞｰﾀ状態の取得
                lblnAns = pubblnLotChkWaist_Sel(CMstrlot_chkwaistVer, _
                                                pstrSBID, _
                                                lblLotID.Text, _
                                                lstrWaistStatus)
                '@結果判定
                If lblnAns = False Then
                    '@ﾌｫｰﾑﾛｯｸ解除
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    Exit Sub
                End If
                
                '@WAISTﾃﾞｰﾀ状態の判定(正常以外の場合,ﾚｽﾎﾟﾝｽをｷｬﾝｾﾙする)
                If lstrWaistStatus <> CMstrWaistStatus0 Then
                    '@ﾌｫｰﾑﾛｯｸ解除
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    Select Case lstrWaistStatus
                        '@入力ﾌｧｲﾙ作成中
                        Case CMstrWaistStatus1
                            '@"<TRM3UW>$$現在、WAIST検査機用のデータを作成中ですが、強制実行しますか？"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003U)
                            
                            llngWaistAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                            '@返答判定
                            If llngWaistAns = vbYes Then
                            '@「はい」の場合：処理続行
                                '@ﾌｫｰﾑﾛｯｸ
                                
                                '@再度,ﾚｽﾎﾟﾝｽ測定を開始する
                                Call pubResponseStart(lstrFormName, lstrEventName)
                            Else
                            '@「いいえ」の場合
                                Exit Sub
                            End If
                        
                        '@入力ﾌｧｲﾙ作成異常
                        Case CMstrWaistStatus2
                            '@"<TRM3VW>$$WAIST検査機用のデータ作成中にエラーが発生しました。$強制実行しますか？"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003V)
                            
                            llngWaistAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                            '@返答判定
                            If llngWaistAns = vbYes Then
                            '@「はい」の場合：処理続行
                                '@ﾌｫｰﾑﾛｯｸ
                                
                                '@再度,ﾚｽﾎﾟﾝｽ測定を開始する
                                Call pubResponseStart(lstrFormName, lstrEventName)
                            Else
                            '@「いいえ」の場合
                                Exit Sub
                            End If
                        
                        '@その他の異常
                        Case Else
                            '@"<TRM0GE>$$WAIST検査機の状態エラーが発生しました。$システム担当者に連絡してください。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000G)
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit Sub
                    End Select
                End If
            End If

            '@処理開始ﾃﾞｰﾀ格納
            With ltypLotprcstart
                .strLotID = lblLotID.Text                            'ﾛｯﾄID
                .strOpID = lblOpID.Text                              '大工程ID
                .strStepID = lblStepID.Text                          '小工程ID
                .strWpID = lblWP.Tag                                    'WPID
                .strEngEmpId = pstrUserID                               '作業者ID
                .strLotLastUpdate = mstrLotLastUpdate                   'LOT最終更新日時
                .strEQFlag = CMlngEqFlag                                '装置ﾌﾗｸﾞ
                
                '@ﾎﾟｰﾄIDの未選択対応
                If cmbPort.Value <> vbNullString Then
                    .strPortID = cmbPort.Value                          'ﾎﾟｰﾄID
                Else
                    .strPortID = vbNullString                           'ﾎﾟｰﾄID
                End If
                
                If txtWorkMemo.Text <> vbNullString Then
                    .strComment = txtWorkMemo.Text                      '作業ﾒﾓ
                Else
                    .strComment = vbNullString                          '作業ﾒﾓ
                End If
                
                '@UnloaderﾎﾟｰﾄIDの未選択対応
                If cmbLoaderPort.Value <> vbNullString Then
                    .strToPortID = cmbLoaderPort.Value                  'UnloaderﾎﾟｰﾄID
                Else
                    .strToPortID = vbNullString
                End If
            End With

        '@↓2015/11/13 (Fri) 09:22:13 H.Hayashi **************************************************
            '@CONTｴｯﾁｬｰの場合はFR処理可能範囲のﾚｼﾋﾟが存在するか確認する(※処理開始はM1の場合のみ実施)
            If mtypLotCurState.strEqType = CPstrEqTypeContEt Then
            

                '@CONTｴｯﾁｬｰの場合はFR処理可能範囲のﾚｼﾋﾟが存在するか確認
                lblnAns = pubblnLotChkFrTimeRecipe_Chk(CMstrlot_chkfrtimerecipeVer, _
                                                pstrSBID, _
                                                lblLotID.Text, _
                                                lblOpID.Text, _
                                                lblStepID.Text, _
                                                lblWP.Tag, _
                                                lblRecpType.Text, _
                                                CPstrlot_prcstart, _
                                                lstrFrRecipeStatus, _
                                                lstrNgChamberId, _
                                                lstrNgProcessTime, _
                                                lstrNgRecipeId, _
                                                lstrGuidMsg, _
                                                lstrGuidMsgCode)

                '@結果判定
                If lblnAns = False Then
                    '@ﾌｫｰﾑﾛｯｸ解除
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    Exit Sub
                End If
                
                '@CONTｴｯﾁｬｰの判定(表示対象外以外の場合,ﾚｽﾎﾟﾝｽをｷｬﾝｾﾙする)
                If lstrFrRecipeStatus <> vbNullString And lstrFrRecipeStatus <> CMstrFrRecipeStatus0 Then
                    '@ﾌｫｰﾑﾛｯｸ解除
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    Select Case lstrFrRecipeStatus
                        '@正常表示
                        Case CMstrFrRecipeStatus1
                        
                            '@"<TRM135W>$$レシピ[%1]が選択されました。$装置パネルにて､本レシピを指定して下さい｡"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0135, Replace(lblRecpType.Text, vbCrLf, vbNullString))
                            Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                                               
                        '@異常表示(FR累積範囲以外)
                        Case CMstrFrRecipeStatus2
                            
                            '@"<TRM136W>$$処理部[%1]のFR累積時間は[%2]です。範囲以外のレシピ[%3]が$選択されていますが[%4]を実施いたしますか｡"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0136, lstrNgChamberId, lstrNgProcessTime, lstrNgRecipeId, CMstrEN0070Title)
                            llngFrAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                            '@返答判定
                            If llngFrAns = vbYes Then
                            '@「はい」の場合：処理続行
        '@↓2015/12/01 (Tue) 13:50:36 H.Hayashi **************************************************
        '@                        '@ﾌｫｰﾑﾛｯｸ
        '@                        frmxxEN0070.Enabled = False
                                '@処理を継続する
        '@↑2015/12/01 (Tue) 13:50:36 H.Hayashi **************************************************
                            Else
                            '@「いいえ」の場合
                                Exit Sub
                            End If
                            
                            
                        '@異常表示(処理部状態に一致しないﾚｼﾋﾟ)
                        Case CMstrFrRecipeStatus3
                            
                            '@"<TRM137W>$$処理部[%1]の状態に一致しないレシピ$[%2]が選択されていますが$[%3]を実施いたしますか。"
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0137, lstrNgChamberId, lstrNgRecipeId, CMstrEN0070Title)
                            llngFrAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                            '@返答判定
                            If llngFrAns = vbYes Then
                            '@「はい」の場合：処理続行
        '@↓2015/12/01 (Tue) 13:50:55 H.Hayashi **************************************************
        '@                        '@ﾌｫｰﾑﾛｯｸ
        '@                        frmxxEN0070.Enabled = False
                                '@処理を継続する
        '@↑2015/12/01 (Tue) 13:50:55 H.Hayashi **************************************************
                            Else
                            '@「いいえ」の場合
                                Exit Sub
                            End If
                            
                                        
                    End Select
                    
                    '@再度,ﾚｽﾎﾟﾝｽ測定を開始する
                    Call pubResponseStart(lstrFormName, lstrEventName)
                End If

            End If
        '@↑2015/11/13 (Fri) 09:22:13 H.Hayashi **************************************************

        '@↓2012/02/28 (Tue) 17:28:16 Y.Yoneyama **************************************************
            '@ﾒｯｾｰｼﾞ送信処理呼び出し:処理開始要求(処理区分：013B)
            lblnAns = pubblnLotPrcstart_Ins(CMstrlot_prcstartVer, _
                                            CPstrCD01 & CPstrCD3B, _
                                            ltypLotprcstart, _
                                            lstrToOpID, _
                                            lstrToStepID, _
                                            lstrLimitTime, _
                                            lstrWarnTime, _
                                            lstrRecipID, _
                                            lstrPolTime, _
                                            lstrPlcResult)
        '@↑2012/02/28 (Tue) 17:28:16 Y.Yoneyama **************************************************
            '@結果判定
            If lblnAns = True Then
                
        '@↓2012/02/28 (Tue) 17:50:09 Y.Yoneyama **************************************************
                '@PLCﾚｼﾋﾟ照合結果確認
                '@照合OKの場合
                If lstrPlcResult = CMstrOK Then
                    lblnPlcWarning = False      '警告未表示
                '@その他はNG
                Else
                    lblnPlcWarning = True       '警告表示
                End If
        '@↑2012/02/28 (Tue) 17:50:09 Y.Yoneyama **************************************************
                
                '@制限時間超過の警告が発生している場合
                If lstrToOpID <> vbNullString Or lstrToStepID <> vbNullString Or lstrLimitTime <> vbNullString Then
                    '@ﾌｫｰﾑﾛｯｸ解除
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                    
                    '@制限時間以下の場合
                    If mtypLotCurState.strRestrictTypeID = CMstrRestrictTypeID1 Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003F, lblLotID.Text, lstrToOpID, lstrToStepID)
                        
                        '@"<TRM3BW>$$ロット[xxx]は[xxx xxx]までの工程において制限時間を経過しています。処理を継続しますか？"
                        llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                        '@要求確認
                        If llngAns = vbNo Then
                            '@ｷｬﾝｾﾙする
                        Else
                        '@「はい」が選択された場合
                            '@ﾌｫｰﾑﾛｯｸ
                            
                            '@ﾚｽﾎﾟﾝｽ取得開始
                            Call pubResponseStart(lstrFormName, lstrEventName)
            
        '@↓2012/02/28 (Tue) 17:28:25 Y.Yoneyama **************************************************
                            '@ﾒｯｾｰｼﾞ送信処理呼び出し(処理区分：0102)
                            lblnAns = pubblnLotPrcstart_Ins(CMstrlot_prcstartVer, _
                                                            CPstrCD01 & CPstrCD02, _
                                                            ltypLotprcstart, _
                                                            lstrToOpID, _
                                                            lstrToStepID, _
                                                            lstrLimitTime, _
                                                            lstrWarnTime, _
                                                            lstrRecipID, _
                                                            lstrPolTime, _
                                                            lstrPlcResult)
        '@↑2012/02/28 (Tue) 17:28:25 Y.Yoneyama **************************************************
                            '@結果判定
                            If lblnAns = True Then
                                '@ﾌｫｰﾑﾛｯｸ解除
                                
                                '@Unloaderﾎﾟｰﾄの入力判定(Unloaderﾎﾟｰﾄの入力可否にて表示ﾒｯｾｰｼﾞを切替)
                                If cmbLoaderPort.Value = vbNullString Then
                                    '@表示ﾒｯｾｰｼﾞ変換(UNI装置用)"<TRM18I>$$処理を開始しました。キャリア[ %1 ] ロット[ %2 ]"
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0018, txtCarrier.Text, lblLotID.Text)
                                Else
                                    '@表示ﾒｯｾｰｼﾞ変換(L/N装置用)"<TRM0UI>$$処理を開始しました。キャリア[ %1 ] ロット[ %2 ] Loaderポート[ %3 ] Unloaderポート[ %4 ]"
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000U, txtCarrier.Text, lblLotID.Text, cmbPort.Text, cmbLoaderPort.Text)
                                End If
                                
                                '@ﾚｽﾎﾟﾝｽ取得終了
                                Call publngResponseEnd(lstrFormName, lstrEventName)
                                
                                '@成功ﾒｯｾｰｼﾞ表示
                                Call pubVsfInfo_Disp(pstrDMsg)
                                
                                '@ﾚｼﾋﾟIDが入っているか
                                If lstrRecipID <> vbNullString Then
                                    '@研磨時間が入っていか
                                    If lstrPolTime <> vbNullString Then
                                        '@2ndCMPの場合
                                        '@表示ﾒｯｾｰｼﾞ変換
                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005M, lstrRecipID, lstrPolTime)
                                        '@"<TRM5MW>$$レシピ[%1]、研磨時間[%2]が選択されました。$装置パネルにて、本レシピを指定して下さい。"
                                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                    Else
                                        '@CMPの場合
                                        '@表示ﾒｯｾｰｼﾞ変換
                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005L, lstrRecipID)
                                        '@"<TRM5LW>$$レシピ[%1]が選択されました。$装置パネルにて、本レシピを指定して下さい。"
                                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                    End If
                                End If

                                '@流動ﾀｲﾌﾟによる処理判別(移載中か否か)
                                If mtypLotCurState.strFlowType = CPstrLotCurstateFlowTypeMove Then
                                    '@移載工程の場合
                                    ptypCommonInfo.strToCarrierId = txtCarrier.Text
                                Else
                                    '@Loader/Unloaderの場合
                                    ptypCommonInfo.strToCarrierId = lblLoaderCarrier.Text
                                End If
                            
                                '@ｷｬﾘｱIDのｸﾘｱ
                                txtCarrier.Text = vbNullString
                                
                                '@ﾛｯﾄ情報の初期化
                                Call prvfrmxxEN0070_Init()
                                
                                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用不可)
                                Call prvfrmxxEN0070_CmbInit(False)
                            Else
                                '@ﾌｫｰﾑﾛｯｸ解除
                                
                                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                Call pubResponseCancel(lstrFormName, lstrEventName)
                            End If
                        End If
                    End If
                    
                    '@制限時間以下の場合
                    If mtypLotCurState.strRestrictTypeID = CMstrRestrictTypeID2 Then
                        '@表示ﾒｯｾｰｼﾞ変換
                         pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003I, lblLotID.Text, lstrToOpID, lstrToStepID)
                         '@"<TRM3IW>$$ロット[xxx]は[xxx xxx]までの工程において制限時間を経過していません。処理を継続しますか？"
                         llngAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
                        
                        '@要求確認
                        If llngAns = vbNo Then
                            '@ｷｬﾝｾﾙする
                        Else
                        '@「はい」が選択された場合
                            '@ﾌｫｰﾑﾛｯｸ
                            
                            '@ﾚｽﾎﾟﾝｽ取得開始
                            Call pubResponseStart(lstrFormName, lstrEventName)
                            
        '@↓2012/02/28 (Tue) 17:28:45 Y.Yoneyama **************************************************
                            '@ﾒｯｾｰｼﾞ送信処理呼び出し(処理区分：0102)
                            lblnAns = pubblnLotPrcstart_Ins(CMstrlot_prcstartVer, _
                                                            CPstrCD01 & CPstrCD02, _
                                                            ltypLotprcstart, _
                                                            lstrToOpID, _
                                                            lstrToStepID, _
                                                            lstrLimitTime, _
                                                            lstrWarnTime, _
                                                            lstrRecipID, _
                                                            lstrPolTime, _
                                                            lstrPlcResult)
        '@↑2012/02/28 (Tue) 17:28:45 Y.Yoneyama **************************************************
                            '@結果判定
                            If lblnAns = True Then
                                '@ﾌｫｰﾑﾛｯｸ解除
                                
                                '@Unloaderﾎﾟｰﾄの入力判定(Unloaderﾎﾟｰﾄの入力可否にて表示ﾒｯｾｰｼﾞを切替)
                                If cmbLoaderPort.Value = vbNullString Then
                                    '@表示ﾒｯｾｰｼﾞ変換(UNI装置用)"<TRM18I>$$処理を開始しました。キャリア[ %1 ] ロット[ %2 ]"
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0018, txtCarrier.Text, lblLotID.Text)
                                Else
                                    '@表示ﾒｯｾｰｼﾞ変換(L/N装置用)"<TRM0UI>$$処理を開始しました。キャリア[ %1 ] ロット[ %2 ] Loaderポート[ %3 ] Unloaderポート[ %4 ]"
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000U, txtCarrier.Text, lblLotID.Text, cmbPort.Text, cmbLoaderPort.Text)
                                End If
                                
                                '@ﾚｽﾎﾟﾝｽ取得終了
                                Call publngResponseEnd(lstrFormName, lstrEventName)
                                
                                '@成功ﾒｯｾｰｼﾞ表示
                                Call pubVsfInfo_Disp(pstrDMsg)
                                
                                '@ﾚｼﾋﾟIDが入っているか
                                If lstrRecipID <> vbNullString Then
                                    '@研磨時間が入っていか
                                    If lstrPolTime <> vbNullString Then
                                    '@2ndCMPの場合
                                        '@表示ﾒｯｾｰｼﾞ変換
                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005M, lstrRecipID, lstrPolTime)
                                        
                                        '@"<TRM5MW>$$レシピ[%1]、研磨時間[%2]が選択されました。$装置パネルにて、本レシピを指定して下さい。"
                                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                    Else
                                    '@CMPの場合
                                        '@表示ﾒｯｾｰｼﾞ変換
                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005L, lstrRecipID)
                                        
                                        '@"<TRM5LW>$$レシピ[%1]が選択されました。$装置パネルにて、本レシピを指定して下さい。"
                                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                    End If
                                End If
                            
                                '@流動ﾀｲﾌﾟによる処理判別(移載中か否か)
                                If mtypLotCurState.strFlowType = CPstrLotCurstateFlowTypeMove Then
                                    '@移載工程の場合
                                    ptypCommonInfo.strToCarrierId = txtCarrier.Text
                                Else
                                    '@Loader/Unloaderの場合
                                    ptypCommonInfo.strToCarrierId = lblLoaderCarrier.Text
                                End If
                            
                                '@ｷｬﾘｱIDのｸﾘｱ
                                txtCarrier.Text = vbNullString
                                
                                '@ﾛｯﾄ情報の初期化
                                Call prvfrmxxEN0070_Init()
                                
                                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用不可)
                                Call prvfrmxxEN0070_CmbInit(False)
                            Else
                                '@ﾌｫｰﾑﾛｯｸ解除
                                
                                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                                Call pubResponseCancel(lstrFormName, lstrEventName)
                            End If
                        End If
                    End If
                Else
                '@制限時間が超過していない場合
                    '@ﾌｫｰﾑﾛｯｸ解除
                    
                    '@Unloaderﾎﾟｰﾄの入力判定(Unloaderﾎﾟｰﾄの入力可否にて表示ﾒｯｾｰｼﾞを切替)
                    If cmbLoaderPort.Value = vbNullString Then
                        '@表示ﾒｯｾｰｼﾞ変換(UNI装置用)"<TRM18I>$$処理を開始しました。キャリア[ %1 ] ロット[ %2 ]"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0018, txtCarrier.Text, lblLotID.Text)
                    Else
                        '@表示ﾒｯｾｰｼﾞ変換(L/N装置用)"<TRM0UI>$$処理を開始しました。キャリア[ %1 ] ロット[ %2 ] Loaderポート[ %3 ] Unloaderポート[ %4 ]"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000U, txtCarrier.Text, lblLotID.Text, cmbPort.Text, cmbLoaderPort.Text)
                    End If
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                    
                    '@成功ﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)
                    
                    '@ﾚｼﾋﾟIDが入っているか
                    If lstrRecipID <> vbNullString Then
                        '@研磨時間が入っていか
                        If lstrPolTime <> vbNullString Then
                        '@2ndCMPの場合
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005M, lstrRecipID, lstrPolTime)
                            
                            '@"<TRM5MW>$$レシピ[%1]、研磨時間[%2]が選択されました。$装置パネルにて、本レシピを指定して下さい。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        Else
                        '@CMPの場合
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005L, lstrRecipID)
                            
                            '@"<TRM5LW>$$レシピ[%1]が選択されました。$装置パネルにて、本レシピを指定して下さい。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        End If
                    End If

                    '@流動ﾀｲﾌﾟによる処理判別(移載中か否か)
                    If mtypLotCurState.strFlowType = CPstrLotCurstateFlowTypeMove Then
                        '@移載工程の場合
                        ptypCommonInfo.strToCarrierId = txtCarrier.Text
                    Else
                        '@Loader/Unloaderの場合
                        ptypCommonInfo.strToCarrierId = lblLoaderCarrier.Text
                    End If
                
                    '@ｷｬﾘｱIDのｸﾘｱ
                    txtCarrier.Text = vbNullString
                    
                    '@ﾛｯﾄ情報の初期化
                    Call prvfrmxxEN0070_Init()
                    
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用不可)
                    Call prvfrmxxEN0070_CmbInit(False)
                End If
            Else
                '@ﾌｫｰﾑﾛｯｸ解除
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            End If
            
        '@↓2012/02/28 (Tue) 17:51:20 Y.Yoneyama **************************************************
            '@PLCﾚｼﾋﾟ照合の警告ﾒｯｾｰｼﾞ表示
            If lblnPlcWarning Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0120)
                            
                '@"<TRM5LW>$$レシピ[%1]が選択されました。$装置パネルにて、本レシピを指定して下さい。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            End If
        '@↑2012/02/28 (Tue) 17:51:20 Y.Yoneyama **************************************************
            
            '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrier)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
                .strProcName = "cmdRegist_Click"
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
    '作成日：2004/04/15 (Thu) 18:06:10 N.Kasai
    '更新日：2004/04/15 (Thu) 18:06:10
    '備　考：
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change

        Try
            
            '@ｷｬﾘｱIDを修正する場合はﾛｯﾄ情報をｸﾘｱする
            '@ﾛｯﾄ情報の初期化
            Call prvfrmxxEN0070_Init()
            
            '@ﾎﾞﾀﾝ状態
            Call prvfrmxxEN0070_CmbInit(False)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
                .strProcName = "txtCarrier_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotCommnt_Change
    '機　能：ﾛｯﾄｺﾒﾝﾄ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:12:03 N.Kasai
    '更新日：2005/11/29 (Tue) 14:12:03
    '備　考：
    Private Sub txtLotCommnt_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLotCommnt.Change

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtLotCommnt, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
                .strProcName = "txtLotCommnt_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotCommnt_KeyUp
    '機　能：ﾛｯﾄｺﾒﾝﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 13:47:07 N.Kasai
    '更新日：2005/11/29 (Tue) 13:47:07
    '備　考：
    Private Sub txtLotCommnt_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtLotCommnt.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtLotCommnt, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
                .strProcName = "txtLotCommnt_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
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
    '更新日：2005/11/29 (Tue) 13:48:44
    '備　考：
    Private Sub txtLotCommnt_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtLotCommnt.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtLotCommnt, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
                .strProcName = "txtLotCommnt_MouseUp"
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
    '作成日：2004/04/27 (Tue) 14:39:17 M.Miura
    '更新日：2004/04/27 (Tue) 14:39:17
    '備　考：
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change
        
        Dim llngNowByte As Integer 'ﾊﾞｲﾄ数

        Try
            
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtWorkMemo.NowByte
            
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            
        '@↓2005/11/29 (Tue) 16:41:24 N.Kasai **************************************************
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
        '@↑2005/11/29 (Tue) 16:41:24 N.Kasai **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
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
                .strMenuKey = CPstrKeyEN0070
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
                .strMenuKey = CPstrKeyEN0070
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
    '作成日：2004/04/27 (Tue) 14:52:32 M.Miura
    '更新日：2005/11/29 (Tue) 16:42:33 N.Kasai
    '備　考：
    '　　　：2005/11/29 (Tue) 16:42:33 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdMemoUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/11/29 (Tue) 16:40:15 N.Kasai **************************************************
        '    '@作業メモにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtWorkMemo)
        '
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)

        '@↑2005/11/29 (Tue) 16:40:15 N.Kasai **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
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
    '作成日：2004/04/27 (Tue) 14:53:27 M.Miura
    '更新日：2005/11/29 (Tue) 16:42:52 N.Kasai
    '備　考：
    '　　　：2005/11/29 (Tue) 16:42:52 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdMemoDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/11/29 (Tue) 16:40:44 N.Kasai **************************************************
        '    '@作業メモにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtWorkMemo)
        '
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)

        '@↑2005/11/29 (Tue) 16:40:44 N.Kasai **************************************************
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
                .strProcName = "cmdMemoDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPort_CloseUp
    '機　能：ポート№選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/14 (Fri) 15:39:10 M.Miura
    '更新日：2004/05/14 (Fri) 15:39:10
    '備　考：
    Private Sub cmbPort_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPort.CloseUp

        Try

            With cmbPort
                '@取得列をﾎﾟｰﾄIDに設定
                .ValueCol = CMlngcmbPortID
                '@ﾎﾟｰﾄIDが選択されている場合
                If .Value <> vbNullString Then
                    '@次項目にﾌｫｰｶｽｾｯﾄ
                    SendKeys.SendWait(CPstrSendKeysTab)
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
                .strProcName = "cmbPort_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPort_Change
    '機　能：ﾎﾟｰﾄ№変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 17:05:37 M.Miura
    '更新日：2004/06/02 (Wed) 17:05:37
    '備　考：
    Private Sub cmbPort_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPort.Change

        Try
            
            With cmbPort
                '@ﾎﾟｰﾄIDが選択されている場合
                If .Value <> vbNullString Then
                    '@ﾛｯｸ解除
                    cmdRegist.Enabled = True
                Else
                    '@ﾛｯｸ
                    cmdRegist.Enabled = False
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
                .strProcName = "cmbPort_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '======================================Public===========================================

    '関数名：txtCarrier_Validate
    '機　能：ｷｬﾘｱ情報取得
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/03/16 (Tue) 15:03:48 T.Oide
    '更新日：2005/10/04 (Tue) 17:43:54 N.Kojima
    '備　考：
    '　　　：2005/10/04 (Tue) 17:43:54 N.Kojima     Loader/Unloaderﾌﾗｸﾞ格納処理追加(ﾚｼﾋﾟ設定変更画面に引継ぎ)。(不具合№3163)
    Public Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim lblnAns         As Boolean      '結果取得(True:正常,False:異常)
        Dim lstrFormName    As String       'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName   As String       'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypLotWpList   As LotWpList    '装置情報構造体
        Dim lstrErrMessage  As String       '装置の処理間隔ﾜｰﾆﾝｸﾞ時間をﾁｪｯｸした場合のｴﾗｰﾒｯｾｰｼﾞ格納
        Dim strEqchk_Result As String       '装置の処理間隔ﾜｰﾆﾝｸﾞ時間をﾁｪｯｸした場合の結果格納
        Dim llngMsgAns      As Integer      'ﾒｯｾｰｼﾞﾎﾞｯｸｽの戻り値格納
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｷｬﾘｱIDの空白ﾁｪｯｸ
            If Trim(txtCarrier.Text) = vbNullString Then
                '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmdClose)
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
            If txtCarrier.Text = mstrCarrier Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "txtCarrier_Validate"
            Call pubResponseStart(lstrFormName, lstrEventName)
            '@ﾛｯﾄ情報の初期化
            Call prvfrmxxEN0070_Init()
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用不可)
            Call prvfrmxxEN0070_CmbInit(False)
            '@ﾛｯﾄ情報の取得
            lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, CPstrCD11, txtCarrier.Text, mtypLotCurState)
            '@結果判定
            If lblnAns = True Then
                '@画面表示処理
                Call prvfrmxxEN0070_Disp(mtypLotCurState)
            Else
                '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                e.Cancel = True
                '@失敗の場合ﾚｽﾎﾟﾝｽ測定中止
                Call pubResponseCancel(lstrFormName, lstrEventName)
                '@ﾊｲﾗｲﾄ
                Call pubHighlight(txtCarrier)
                Exit Sub
            End If
            
            With mtypLotCurState
                '@装置情報取得
                lblnAns = pubblnLotWplist_Sel(CPstrlot_wplist__Ver, CPstrCD11, lblLotID.Text, .strOpID, .strStepID, mstrAltNumber, ltypLotWpList)
            End With
            '@結果判定
            If lblnAns = True Then
                '@装置名取得(必ず１件)
                With ltypLotWpList.typWpList(CMlngIndex)
                    lblWP.Text = .strWpName                          'WP名
                    pstrWPID = .strWpID                                 'WPID
                    pstrWPName = .strWpName                             'WP名
                    lblWpStatusName.Text = .strWpStatusName          '装置状態
                    
                    pstrLotRecipeFlag = .strLotRecipeFlag               'ﾛｯﾄﾚｼﾋﾟﾌﾗｸﾞ
        '@↓2005/10/04 (Tue) 17:43:21 N.Kojima **************************************************
                    pstrLoaderUnloaderFlag = .strLoaderUnloaderFlag     'Loader/Unloaderﾌﾗｸﾞ
        '@↑2005/10/04 (Tue) 17:43:21 N.Kojima **************************************************
                    
                    '@ﾎﾟｰﾄ№ｺﾝﾎﾞBOXの設定
                    Call prvPortIDCmb_Set(ltypLotWpList)
                    '@ﾚｼﾋﾟ情報取得
                    Call prvRecp_Disp()
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用可)
                    Call prvfrmxxEN0070_CmbInit(True)
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                    
                    '@↓2008/12/01 (Mon) 16:39:00 T.Oide **************************************************
                    '@=======================
                    '@　装置処理経過時間ﾁｪｯｸ
                    '@=======================
                    Call pubEqWarning_Chk(CMstreqchkintervalVer, pstrWPID, lstrErrMessage, strEqchk_Result)
                    
                    '@装置処理経過時間ﾁｪｯｸの結果ｵｰﾊﾞありの場合ﾜｰﾆﾝｸﾞﾒｯｾｰｼﾞ表示
                    If strEqchk_Result = CPstrchkResultNG Then
                        '@ﾒｯｾｰｼﾞ表示
                        llngMsgAns = publngMsgBox(lstrErrMessage, vbExclamation, Me.Text, True, 16, False)
                        
                    End If
                    '@↑2008/12/01 (Mon) 16:39:00 T.Oide **************************************************
                    
                 End With
            Else
                '@失敗の場合ﾚｽﾎﾟﾝｽ測定中止
                Call pubResponseCancel(lstrFormName, lstrEventName)
                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用不可)
                Call prvfrmxxEN0070_CmbInit(False)
                
                e.Cancel = True
                '@ﾊｲﾗｲﾄ
                Call pubHighlight(txtCarrier)
                Exit Sub
            End If
                
            '@ｷｬﾘｱID退避
            mstrCarrier = txtCarrier.Text
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
                .strProcName = "txtCarrier_Validate"
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

    '関数名：prvfrmxxEN0070_Init
    '機　能：ｷｬﾘｱ情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/16 (Tue) 15:08:12 T.Oide
    '更新日：2008/06/04 (Wed) 11:39:13 N.Kojima
    '備　考：
    '　　　：2004/09/03 (Fri) 10:24:44 M.Miura　    ﾎﾟｰﾄ№ｺﾝﾎﾞに背景色設定追加(不具合№134)
    '　　　：2004/10/04 (Mon) 11:41:35 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理追加
    '　　　：2007/02/15 (Thu) 10:29:34 N.Kasai      ﾚｼﾋﾟ画面引継ぎ不具合対応
    '　　　：2008/06/04 (Wed) 11:39:13 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxEN0070_Init()
        
        Dim lstrFormTitle       As String           'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        Dim ltypLotprestate     As Lotprestate      '引継ぎ構造体ｸﾘｱ用

        Try

            '@引継ぎ構造体ｸﾘｱ
            ptypLotprestate = ltypLotprestate
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0070, lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
              
            '@各ｺﾝﾄﾛｰﾙの初期化
            lblLotID.Text = vbNullString                                'ﾛｯﾄID
            lblFlowClass.Text = vbNullString                            '流動区分
            lblWFNo.Text = vbNullString                                 'FW枚数
            lblOpID.Text = vbNullString                                 '大工程ID
            lblStartDayTime.Text = vbNullString                         '開始日時
            lblPdID.Text = vbNullString                                 '機種名
            lblS.Text = vbNullString                                    '特殊特性
            lblStatus.Text = vbNullString                               '状態
            lblStepID.Text = vbNullString                               '小工程ID
            lblLotManager.Text = vbNullString                           'ﾛｯﾄ担当
            lblTimeLimit.Text = vbNullString                            '時間制約
            lblWP.Text = vbNullString                                   'WP名
            lblWP.Tag = vbNullString                                    'WPID
            lblWpStatusName.Text = vbNullString                         '装置状態名
            lblRecpType.Text = vbNullString                             'ﾚｼﾋﾟﾀｲﾌﾟ
            '@↓2020/01/15 (Wed) 17:01:31 Y.Yoneyama 「.Netへ反映未」 **************************************************
            lblGRB.Text = vbNullString                                  'GRB
            '@GRB背景色
            lblGRB.BackColor = lblLotManager.BackColor
            '@↑2020/01/15 (Wed) 17:01:31 Y.Yoneyama 「.Netへ反映未」 **************************************************

            txtOpeCond.Text = vbNullString                              '作業条件
            txtOpeCond.MultiLineEx = True                               '作業条件複数行表示
            txtLotCommnt.Text = vbNullString                            'ﾛｯﾄｺﾒﾝﾄ
            txtLotCommnt.MultiLineEx = True                             'ﾛｯﾄｺﾒﾝﾄ複数行表示
            mstrLotLastUpdate = vbNullString                            'ﾛｯﾄ最終更新日時
            mstrCarrier = vbNullString                                  'ｷｬﾘｱID(ﾒｯｾｰｼﾞ成功時のｷｬﾘｱID)
            mstrAltNumber = vbNullString                                '代替番号
            mblnBacthFlg = False                                        'ﾊﾞｯﾁ編成ﾌﾗｸﾞ(通常)
            
            '@ﾎﾟｰﾄ№ｺﾝﾎﾞ設定
            With cmbPort
                .Clear
                '@ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄに設定
                .DirectInput = False
                '@ﾘｽﾄの高さ設定
                .RowHeight = CPlngCmbRowHeight
                '@Value列設定(ﾎﾟｰﾄID)
                .ValueCol = CMlngcmbPortID
                '@表示列数
                .DispCols = CMlngDispCols
                '@ﾎﾟｰﾄｺﾝﾎﾞ表示
                .Visible = True
                '@背景色(白)
                .BackColor = SystemColors.Window
            End With
            '@ﾎﾟｰﾄﾀｲﾄﾙ表示
            lblPort.Visible = True
            
            '@作業ﾒﾓﾊﾞｲﾄ数初期化
            With txtWorkMemo
                .ChrMaxByte = CPlngLotCommentsMaxByte
                .Text = vbNullString
                Call txtWorkMemo_Change(txtWorkMemo, New EventArgs)
            End With
            
            '@ﾛｯﾄｺﾒﾝﾄﾊﾞｲﾄ数初期化
            With txtLotCommnt
                .ChrMaxByte = CPlngLotCommentsMaxByte
                .Text = vbNullString
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
                '@背景色(ｸﾞﾚｰ)
                .BackColor = SystemColors.ControlLight
                .GotBackColor = SystemColors.ControlLight
                '@ﾛｯｸ
                .Locked = True
            End With
                  
            '@Unloaderの初期化
            lblLoaderCarrier.Text = vbNullString
            '@Unloaderﾎﾟｰﾄ№ｺﾝﾎﾞ設定
            With cmbLoaderPort
                .Clear
                .BackColor = SystemColors.ControlLight
                '@ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄに設定
                .DirectInput = False
                '@ﾘｽﾄの高さ設定
                .RowHeight = CPlngCmbRowHeight
                '@Value列設定(ﾎﾟｰﾄID)
                .ValueCol = CMlngcmbPortID
                '@表示列数
                .DispCols = CMlngDispCols
                .Enabled = False
            End With
                  
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
                .strProcName = "prvfrmxxEN0070_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN0070_CmbInit
    '機　能：各ｺﾏﾝﾄﾞﾎﾞﾀﾝの制御
    '引　数：lblnEnable：True:使用可能,False:使用不可
    '戻り値：なし
    '作成日：2004/03/16 (Tue) 15:09:24 T.Oide
    '更新日：2005/12/19 (Mon) 10:16:21 N.Kojima
    '備　考：
    '　　　：2004/09/22 (Wed) 20:50:03 H.Wajima     流動ﾀｲﾌﾟ判定追加
    '　　　：2005/12/19 (Mon) 10:16:21 N.Kojima     ﾚｼﾋﾟ取得失敗ﾌﾗｸﾞがTrue(取得失敗)の場合は、ﾎﾟｰﾄｺﾝﾎﾞを無効にする。(不具合№3334)
    Private Sub prvfrmxxEN0070_CmbInit(Optional ByVal lblnEnable As Boolean = False)

        Try
            
            '@各ｺﾏﾝﾄﾞﾎﾞﾀﾝのｺﾝﾄﾛｰﾙ
            
            '@流動ﾀｲﾌﾟの判定
            If mtypLotCurState.strFlowType = CPstrLotCurstateFlowTypeMove Then
                
                '@移載工程の場合
                cmdCommntInput.Enabled = False          'ﾛｯﾄｺﾒﾝﾄ入力
                txtOpeCond.Enabled = False              '作業条件
                txtWorkMemo.Enabled = False             '作業ﾒﾓ
                cmdMemoUp.Enabled = False               '作業ﾒﾓ頁UP
                cmdMemoDown.Enabled = False             '作業ﾒﾓ頁DOWN
                    
                cmdWFRecp.Enabled = False               'ﾚｼﾋﾟ詳細表示
                
            Else
                '@移載工程以外の場合
                
                cmdCommntInput.Enabled = lblnEnable     'ﾛｯﾄｺﾒﾝﾄ入力
                txtOpeCond.Enabled = lblnEnable         '作業条件
                txtWorkMemo.Enabled = lblnEnable        '作業ﾒﾓ
                
        '@↓2005/11/29 (Tue) 16:49:03 N.Kasai **************************************************
        '        cmdMemoUp.Enabled = lblnEnable          '作業ﾒﾓ頁UP
        '        cmdMemoDown.Enabled = lblnEnable        '作業ﾒﾓ頁DOWN
        '@↑2005/11/29 (Tue) 16:49:03 N.Kasai **************************************************

                '@ﾛｯｸの場合
                If lblnEnable = False Then
                    cmdWFRecp.Enabled = lblnEnable      'ﾚｼﾋﾟ詳細表示
                End If
            End If
            
            txtLotCommnt.Enabled = lblnEnable           'ｺﾒﾝﾄ
            
        '@↓2005/11/29 (Tue) 16:49:19 N.Kasai **************************************************
        '    cmdTxtUp.Enabled = lblnEnable               'ｺﾒﾝﾄ頁UP
        '    cmdTxtDown.Enabled = lblnEnable             'ｺﾒﾝﾄ頁DOWN
        '@↑2005/11/29 (Tue) 16:49:19 N.Kasai **************************************************

            '@ﾛｯｸの場合
            If lblnEnable = False Then
                cmdRegist.Enabled = lblnEnable           '処理開始確定
                cmbPort.Enabled = lblnEnable            'ﾎﾟｰﾄNo
            Else
            
        '@↓2005/12/19 (Mon) 10:14:56 N.Kojima **************************************************
        '@ﾎﾟｰﾄｺﾝﾎﾞの有効無効は、ﾚｼﾋﾟ取得失敗ﾌﾗｸﾞも加味して判定する。
                With cmbPort
                    '@ﾎﾟｰﾄがある場合
        '            If .ListCount > 0  Then
                    If .ListCount > 0 And mblnRecipeChkFlg = False Then
                        .Enabled = lblnEnable           'ﾎﾟｰﾄNo
                    Else
                        .Enabled = False                'ﾎﾟｰﾄNo
                    End If
                End With
        '@↑2005/12/19 (Mon) 10:14:56 N.Kojima **************************************************
                
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
                .strProcName = "prvfrmxxEN0070_CmbInit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN0070_Disp
    '機　能：画面の表示
    '引　数：ltypLotprestate：ﾛｯﾄ情報を格納する構造体
    '戻り値：なし
    '作成日：2004/03/16 (Tue) 15:28:24 T.Oide
    '更新日：2008/06/04 (Wed) 11:39:45 N.Kojima
    '備　考：
    '　　　：2004/08/25 (Wed) 12:10:41 N.Kasai      CFﾌﾗｸﾞ判定追加、"mm/dd hh:mm:ss"を共通変数化
    '　　　：2004/09/09 (Thu) 19:22:18 Y.Yamagishi　時間制限表示変更(不具合改善№693)
    '　　　：2004/09/14 (Tue) 10:28:44 N.Kojima　   数量表示(TPALﾛｯﾄ対応)修正(不具合改善№730)
    '　　　：2004/09/24 (Fri) 10:42:29 Y.Yamagishi  制限時間以上の場合文字色を青に変更(不具合改善№825)
    '　　　：2005/05/26 (Thu) 14:13:08 N.Kasai      LP_FLAG追加
    '　　　：2006/06/08 (Thu) 14:46:26 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2008/06/04 (Wed) 11:39:45 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxEN0070_Disp(ByRef ltypLotprestate As Lotprestate)
        
        Dim llngCnt As Integer 'ｶｳﾝﾄ

        Try
            
            '@ﾛｯﾄ情報の表示
            With ltypLotprestate
                lblLotID.Text = .strLotID                                                       'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass                                               '流動区分
                lblOpID.Text = .strOpID                                                         '大工程ID
                If IsDate(.strDispatchStartTime) = True Then
                    lblStartDayTime.Text = Format$(CDate(.strDispatchStartTime), CPstrDateFormat)      '投入予定日時"mm/dd hh:mm:ss"
                Else
                    lblStartDayTime.Text = .strDispatchStartTime
                End If
                lblPdID.Text = .strPdId                                                         '機種名
                lblS.Text = .strSpecialFlg                                                      '特殊特性
                lblStatus.Text = .strNowST                                                      '状態
                lblStepID.Text = .strStepID                                                     '小工程ID
                lblWP.Tag = .strWpID                                                            'WPID
                lblLotManager.Text = .strEngEmpName                                             'ﾛｯﾄ担当
                '@↓2020/01/15 (Wed) 17:02:32 Y.Yoneyama 「.Netへ反映未」 **************************************************
                lblGRB.Text = .strGRBClass                                                      'GRB
                '@GRB背景色
                lblGRB.BackColor = pubGRBBackColor(.strGRBClass, lblLotManager.BackColor)
                '@↑2020/01/15 (Wed) 17:02:32 Y.Yoneyama 「.Netへ反映未」 **************************************************
                
                '@時間制約有無の表示
                If .strLimitTime <> vbNullString Then

                    '@時間制約がﾌﾟﾗｽの場合
                    If CLng(.strLimitTime) >= 0 Then

                        '@制限時間以下or処理時間制限以下の場合
                        '@処理時間制限以下設定の場合、基本的に処理中で処理出来る機能しか関係ないが例外処理として挿入
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
        '                If .strRestrictTypeID = CPstrRestrictTypeID1 Then
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@ﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Format(CLng(.strLimitTime), CPstrDateFormatKanma) & CPstrh
                        End If
                        
                        '@制限時間以上の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID2 Then
                            '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Replace(Format(CLng(.strLimitTime), CPstrDateFormatKanma), CPstrReplaceMinus, vbNullString) & CPstrh
                        End If
                    End If
                End If
                        
                txtOpeCond.Text = .strWorkCondition                                         '作業条件
                txtLotCommnt.Text = .strComments                                            'ﾛｯﾄｺﾒﾝﾄ
                mstrLotLastUpdate = .strLotLastUpdate                                       'ﾛｯﾄ最終更新日時
                mstrAltNumber = .strAltNumber
                llngCnt = 0
                '@ﾃﾞﾌｫﾙﾄ工程の場合
                If .strSteplist(llngCnt).strStepDivision = CMstrStepdivisionDefault Then
                    '@「○」を格納(ﾚｼﾋﾟ設定変更画面で使用)
                    pstrDefaultStep = CMstrDefault
                End If
                
                '@UnloaderｷｬﾘｱIDを取得しﾃﾞｰﾀがあり、ﾎﾟｰﾄが取得できた(H/Wではない)場合はUnloaderﾎﾟｰﾄ№の使用を可とする。
                If .strCarrierId <> vbNullString Then
                    '@Unloaderの活性化
                    lblLoaderCarrier.Text = .strCarrierId
        ''            cmbLoaderPort.Enabled = True
        ''            cmbLoaderPort.BackColor = Color.White
                Else
                    '@Unloaderの非活性化
                    lblLoaderCarrier.Text = vbNullString
        ''            cmbLoaderPort.Enabled = False
        ''            cmbLoaderPort.BackColor = SystemColors.ControlLight
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
                                lblWFNo.Text = Format$(CLng(.strChipQuantity), CPstrCFKnmaFormat)   'ﾁｯﾌﾟ枚数
                            Else
                                lblWFNo.Text = .strChipQuantity
                            End If
                        End If
        '@↑2005/05/26 (Thu) 13:42:28 N.Kasai **************************************************

                        
                    '@CFﾛｯﾄ以外
                    Case Else
                        '@TPALﾛｯﾄ
                        If Trim(Strings.Left(.strLotID, 2)) = CPstrTpalLot Then
                            If IsNumeric(.strChipQuantity) Then
                                lblWFNo.Text = Format$(CLng(.strChipQuantity), CPstrCFKnmaFormat)      'ﾁｯﾌﾟ枚数
                            Else
                                lblWFNo.Text = .strChipQuantity
                            End If
                        Else
                            '@CF,TPALﾛｯﾄ以外
                            lblWFNo.Text = .strWfNum                                         'WF枚数
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
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
                .strProcName = "prvfrmxxEN0070_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvRecpIDCmb_Set
    '機　能：ﾚｼﾋﾟﾀｲﾌﾟ名とﾚｼﾋﾟIDｺﾝﾎﾞの設定
    '引　数：llngLotRecpListCnt：ﾚｼﾋﾟﾘｽﾄ件数
    '戻り値：なし
    '作成日：2004/03/17 (Wed) 15:13:00 T.Kitagawa
    '更新日：2004/03/17 (Wed) 15:13:00
    '備　考：
    Private Sub prvRecpIDCmb_Set(Optional ByRef llngLotRecpListCnt As Integer = 0)
        
        Dim llngCnt                 As Integer              'ｶｳﾝﾀ変数
        Dim lblnAllSameFlg          As Boolean              '全WF同一ﾚｼﾋﾟﾌﾗｸﾞ(True:同一,False:違う)
        Dim lstrRecpID              As String               'ﾚｼﾋﾟID

        Try
            
            '@ﾚｼﾋﾟﾘｽﾄ構造体がﾃﾞｰﾀが存在する場合にｾｯﾄする
            If llngLotRecpListCnt > 0 Then
                '@全WFのﾚｼﾋﾟIDが同一の場合はﾚｼﾋﾟIDを表示し、違う場合は「レシピ個別設定」を表示する
                lblnAllSameFlg = True
                For llngCnt = 0 To ptypLotrecpList.Count - 2
                    If ptypLotrecpList(llngCnt).strRecipeId <> ptypLotrecpList(llngCnt + 1).strRecipeId Then
                        '@全WF同一ﾚｼﾋﾟﾌﾗｸﾞの違う設定
                        lblnAllSameFlg = False
                        Exit For
                    End If
                Next llngCnt
                If lblnAllSameFlg = True Then
                    '@折り返し後のﾚｼﾋﾟIDを取得
                    lstrRecpID = prvstrRecpIDCr_Get(ptypLotrecpList(0).strRecipeId)
                    '@ﾛｯﾄﾚｼﾋﾟの場合ﾚｼﾋﾟID設定)
                    lblRecpType.Text = lstrRecpID
                Else
                    '@ﾚｼﾋﾟﾀｲﾌﾟﾞの設定(「枚葉レシピ」)
                    lblRecpType.Text = CPstrRecpMaiyou
                End If
                        
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
                .strProcName = "prvRecpIDCmb_Set"
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
    '作成日：2004/03/04 (Thu) 18:09:41 T.Kitagawa
    '更新日：2004/03/04 (Thu) 18:09:41
    '備　考：
    Private Function prvblnStartInput_Check() As Boolean

        Dim lstrLoadPort            As String       'LoadﾎﾟｰﾄID退避
        Dim lstrUnloadPort          As String       'UnloadﾎﾟｰﾄID退避
        
        Try

            prvblnStartInput_Check = False
            
            '@ｷｬﾘｱIDの入力ﾁｪｯｸ
            If txtCarrier.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                '@失敗ﾒｯｾｰｼﾞ表示("キャリアIDが設定されていません。設定を見直してください。")
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
                
            '@ﾎﾟｰﾄ№の入力ﾁｪｯｸ
            '@ﾎﾟｰﾄがある場合
            If cmbPort.Enabled = True Then
                '@ﾎﾟｰﾄID列に設定
                cmbPort.ValueCol = CMlngcmbPortID
                If cmbPort.Value = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0029)
                    '@"ポート№が設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Call pubSetFocus(cmbPort)
                    Exit Function
                End If
            End If
            
            '@Unloaderﾎﾟｰﾄ№の入力ﾁｪｯｸ
            '@UnloaderｷｬﾘｱIDが設定されている場合は必須
            If lblLoaderCarrier.Text <> vbNullString Then
                '@Unloaderﾎﾟｰﾄがあり選択されていない場合
                If cmbLoaderPort.Value = vbNullString And cmbLoaderPort.ListCount <> 0 Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0029)
                    '@"ポート№が設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@ｱﾝﾛｰﾀﾞｰﾎﾟｰﾄが有効の場合
                    If cmbLoaderPort.Enabled = True Then
                        '@ｱﾝﾛｰﾀﾞｰﾎﾟｰﾄにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmbLoaderPort)
                    Else
                        '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(txtCarrier)
                    End If
                    Exit Function
                Else
                    '@ﾎﾟｰﾄ№のﾁｪｯｸ(LOADER/UNLOADERﾎﾟｰﾄが相違していることをﾁｪｯｸ)
                    '@LoaderﾎﾟｰﾄIDを取得する。
                    With cmbPort
                        .ValueCol = CMlngcmbPortID
                        lstrLoadPort = .Value
                    End With
                    
                    '@UnloaderﾎﾟｰﾄIDを取得する
                    With cmbLoaderPort
                        .ValueCol = CMlngcmbPortID
                        lstrUnloadPort = .Value
                    End With
                    
                    '@ﾎﾟｰﾄIDの判定(同じ場合はｴﾗｰ)
                    If lstrLoadPort = lstrUnloadPort And lstrLoadPort <> vbNullString Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001D)
                        '@"<TRM1DW>$$同じポート№が設定されています。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        Call pubSetFocus(cmbLoaderPort)
                        Exit Function
                    End If
                End If
            End If
            
            '@状態ﾁｪｯｸ
            If lblStatus.Text <> CPstrBeforeProgressSt Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0015)
                
                '@publngMsgBoxInfo("メッセージコード：C_I15%0$$「前処理」以外のロット[ %2 ]は処理を開始できません。$キャリア[ %1 ]")
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If
            
            '@入力ＯＫ
            prvblnStartInput_Check = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
                .strProcName = "prvblnStartInput_Check"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvRecp_Disp
    '機　能：ﾚｼﾋﾟ表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/19 (Wed) 10:17:01 M.Miura
    '更新日：2007/02/15 (Thu) 10:28:38 N.Kasai
    '備　考：
    '　　　：2004/09/23 (Thu) 10:11:06 M.Miura　    ﾚｽﾎﾟﾝｽがtxtCarrier_Validateとかぶっていたので削除
    '　　　：2005/01/26 (Wed) 17:32:26 N.Kasai      WF_IDがなく、ﾚｼﾋﾟIDが複数件ある場合はﾃﾞﾌｫﾙﾄﾚｼﾋﾟを表示(不具合№451)
    '　　　：2005/01/26 (Wed) 17:32:26 N.Kasai      枚葉ﾚｼﾋﾟ判定条件を変更
    '　　　：2005/12/19 (Mon) 10:03:42 N.Kojima     ﾚｼﾋﾟ取得失敗の場合は、ﾎﾟｰﾄ選択を不可にする為のﾌﾗｸﾞを立てる処理追加。(不具合№3334)
    '　　　：2007/02/15 (Thu) 10:28:38 N.Kasai      ﾚｼﾋﾟ画面引継ぎ不具合対応
    Private Sub prvRecp_Disp()
        
        Dim llngAnsCnt              As Integer              'ﾚｼﾋﾟｶｳﾝﾄ
        Dim llngCnt                 As Integer              'ｶｳﾝﾄ
        Dim lblnAnsRecp             As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrRecpID              As String               'ﾚｼﾋﾟID
        Dim lblnMaiyou              As Boolean              '枚葉ﾚｼﾋﾟ判定ﾌﾗｸﾞ(True:枚葉、False：ﾛｯﾄ)

        Try
               
        '@↓2005/12/19 (Mon) 10:03:28 N.Kojima **************************************************
            '@ﾚｼﾋﾟ取得失敗(使用可能ﾚｼﾋﾟ無し)判定ﾌﾗｸﾞを初期化
            mblnRecipeChkFlg = False
        '@↑2005/12/19 (Mon) 10:03:28 N.Kojima **************************************************
                   
            '@WFﾄﾗﾝﾚｼﾋﾟ初期化
            If IsNothing(ptypWFrecpList) Then 
                ptypWFrecpList = New List(Of Lotrecplist)
            Else 
                ptypWFrecpList.Clear
            End If
            
            '@WF別ﾚｼﾋﾟ情報の取得
            lblnAnsRecp = pubblnLotrecplist_Sel(CMstrlot_recplistVer, lblLotID.Text, _
                                                lblOpID.Text, _
                                                lblStepID.Text, _
                                                lblWP.Tag, _
                                                CPstrCD23, _
                                                CMlngEqFlag, _
                                                mstrAltNumber, _
                                                llngAnsCnt)
        '@↓：2005/01/26 (Wed) 17:32:26 N.Kasai  WF_IDがなく、ﾚｼﾋﾟIDが複数件ある場合はﾃﾞﾌｫﾙﾄﾚｼﾋﾟを表示(不具合№451)
        '@ｺﾒﾝﾄｱｳﾄ
        ''    '@結果判定
        ''    If lblnAnsRecp = True Then
        ''        '@WFがある場合
        ''        If llngAnsCnt > 0 Then
        ''            ReDim Preserve ptypWFrecpList(llngAnsCnt)
        ''            '@WF別ﾄﾗﾝﾚｼﾋﾟ格納
        ''            ptypWFrecpList = ptypLotrecpList
        ''
        ''            llngCnt = 1
        ''            With ptypLotrecpList(llngCnt)
        ''                If .strWFID = vbNullString Then
        ''                    '@折り返し後のﾚｼﾋﾟIDを取得
        ''                    lstrRecpID = prvstrRecpIDCr_Get(.strRecipeID)
        ''                    '@ﾚｼﾋﾟIDｾｯﾄ
        ''                    lblRecpType.Caption = lstrRecpID
        ''                Else
        ''                    '@「枚葉レシピ」ｾｯﾄ
        ''                    lblRecpType.Caption = CPstrRecpMaiyou
        ''                End If
        ''            End With
        ''        End If
        ''
        ''    Else
        ''        '@ﾛｯｸ
        ''        cmdWFRecp.Enabled = False
        ''    End If
        '@ｺﾒﾝﾄｱｳﾄ
        '@↑：2005/01/26 (Wed) 17:32:26 N.Kasai  WF_IDがなく、ﾚｼﾋﾟIDが複数件ある場合はﾃﾞﾌｫﾙﾄﾚｼﾋﾟを表示(不具合№451)


        '@↓：2005/01/26 (Wed) 17:32:26 N.Kasai  WF_IDがなく、ﾚｼﾋﾟIDが複数件ある場合はﾃﾞﾌｫﾙﾄﾚｼﾋﾟを表示(不具合№451)
                                                    
                '@結果判定
                If lblnAnsRecp = True Then
                    
                    '@ﾚｼﾋﾟがある場合
                    If llngAnsCnt > 0 Then
                        '@WF別ﾄﾗﾝﾚｼﾋﾟ格納
                        ptypWFrecpList = ptypLotrecpList
                    Else
                        '@ﾛｯｸ
                        cmdWFRecp.Enabled = False
                    End If
                    
                    '@ﾚｼﾋﾟが1件の場合
                    If llngAnsCnt = 1 Then
                        With ptypLotrecpList(llngAnsCnt - 1)
                            If .strWfId = vbNullString Then
                                
                                '@折り返し後のﾚｼﾋﾟIDを取得
                                lstrRecpID = prvstrRecpIDCr_Get(.strRecipeId)
                                
                                '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟをｾｯﾄ
                                lblRecpType.Text = lstrRecpID
                            
                            Else
                                lblRecpType.Text = CPstrRecpMaiyou
                            End If
                        End With
                    Else
                        '@ﾚｼﾋﾟが複数ある場合
                        If llngAnsCnt > 1 Then
                            '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟｸﾘｱ
                            lblRecpType.Text = vbNullString
                            llngCnt = 0
                            
        '@↓：2005/01/26 (Wed) 17:32:26 N.Kasai  枚葉ﾚｼﾋﾟ判定条件を変更

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
                            
                            
                            '@枚葉ﾚｼﾋﾟの場合
        '                    If ptypLotrecpList(llngCnt).strWFID <> vbNullString Then
        '@↑：2005/01/26 (Wed) 17:32:26 N.Kasai  枚葉ﾚｼﾋﾟ判定条件を変更

                            If lblnMaiyou = True Then
                                '@「枚葉レシピ」をｾｯﾄ
                                lblRecpType.Text = CPstrRecpMaiyou
                            Else
                            
                                For llngCnt = 0 To llngAnsCnt - 1
                                    With ptypLotrecpList(llngCnt)
                                        If .strDefaultFlag = CPstrDefaultRecpFlag Then
                                            '@折り返し後のﾚｼﾋﾟIDを取得
                                            lstrRecpID = prvstrRecpIDCr_Get(.strRecipeId)
                                            '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟをｾｯﾄ
                                            lblRecpType.Text = lstrRecpID
                                            Exit For
                                        End If
                                    End With
                                Next llngCnt
                                '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟがない場合は1件目のﾚｼﾋﾟをｾｯﾄ
                                If lblRecpType.Text = vbNullString Then
                                    llngCnt = 0
                                    With ptypLotrecpList(llngCnt)
                                        '@折り返し後のﾚｼﾋﾟIDを取得
                                        lstrRecpID = prvstrRecpIDCr_Get(.strRecipeId)
                                        '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟをｾｯﾄ
                                        lblRecpType.Text = lstrRecpID
                                    End With
                                End If
                            End If
                        End If
                    End If
                Else
                    '@ﾛｯｸ
                    cmdWFRecp.Enabled = False
                    
        '@↓2005/12/19 (Mon) 10:14:05 N.Kojima **************************************************
                    '@ﾚｼﾋﾟ取得失敗(使用可能ﾚｼﾋﾟ無し)判定ﾌﾗｸﾞをTrueに
                    mblnRecipeChkFlg = True
        '@↑2005/12/19 (Mon) 10:14:05 N.Kojima **************************************************
                End If

        '@↑：2005/01/26 (Wed) 17:32:26 N.Kasai  WF_IDがなく、ﾚｼﾋﾟIDが複数件ある場合はﾃﾞﾌｫﾙﾄﾚｼﾋﾟを表示(不具合№451)


            '@渡すﾃﾞｰﾀを格納
            ptypLotprestate = mtypLotCurState
            ptypLotprestate.strLotLastUpdate = mstrLotLastUpdate       '最終更新日時
            pstrCarrierID = txtCarrier.Text                 'ｷｬﾘｱID
            pstrWPID = lblWP.Tag                            'WPID
            pstrWPName = lblWP.Text                      '装置名
            'ptypWFRecp 'WF毎のﾚｼﾋﾟ現在ﾚｼﾋﾟが取得できないので未実装　T.Oide
            
            '@ﾚｼﾋﾟがない場合
            If llngAnsCnt = 0 Or lblRecpType.Text = CMstrNoneRecipe Then
                '@ﾚｼﾋﾟがない場合
                If llngAnsCnt = 0 Then
                    '@ﾚｼﾋﾟｸﾘｱ
                    lblRecpType.Text = vbNullString
                End If
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
            

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
                .strProcName = "prvRecp_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvPortIDCmb_Set
    '機　能：ﾎﾟｰﾄ№ｺﾝﾎﾞの設定
    '引　数：ltypLotWpList：ﾎﾟｰﾄﾘｽﾄ格納構造体
    '戻り値：なし
    '作成日：2004/09/08 (Wed) 13:21:39 M.Miura
    '更新日：2005/06/09 (Thu) 10:56:16 N.Kojima
    '備　考：
    '　　　：2004/09/22 (Wed) 15:21:21 M.Miura　    ﾛｰﾀﾞｰ/ｱﾝﾛｰﾀﾞｰ時はﾛｰﾀﾞｰｷｬﾘｱは表示しないように変更
    '　　　：2005/06/09 (Thu) 10:56:16 N.Kojima     ﾎﾟｰﾄが選択不可(ｸﾞﾚｰ)の場合は、確定ﾎﾞﾀﾝを無効にする。
    Private Sub prvPortIDCmb_Set(ByRef ltypLotWpList As LotWpList)
        
        Dim llngCnt             As Integer      'ｶｳﾝﾀ変数

        Try
            
            '@ﾎﾟｰﾄ一覧格納用からﾎﾟｰﾄ№ｺﾝﾎﾞBOXへｾｯﾄ
            cmbPort.Clear
            cmbLoaderPort.Clear
            
            '@ﾛｰﾀﾞｰ/ｱﾝﾛｰﾀﾞｰ装置ではない場合
            If ltypLotWpList.typWpList(CMlngIndex).strLoaderUnloaderFlag <> CMstrLoaderUnloaderFlg Then
                '@ﾛｰﾀﾞｰｷｬﾘｱを初期化
                lblLoaderCarrier.Text = vbNullString
            End If
                
            '@UnloaderｷｬﾘｱIDを取得しﾃﾞｰﾀがある場合はUnloaderﾎﾟｰﾄ№の使用を可とする。
            If lblLoaderCarrier.Text <> vbNullString Then
                '@Unloaderの活性化
                cmbLoaderPort.Enabled = True
                cmbLoaderPort.BackColor = Color.White
            Else
                '@Unloaderの非活性化
                cmbLoaderPort.Enabled = False
                cmbLoaderPort.BackColor = SystemColors.ControlLight
            End If
            
            With ltypLotWpList.typWpList(CMlngIndex)
            
            
                '@L/N判定を行う(Unloader装置の場合「lblLoaderCarrier」にIDがｾｯﾄされる為)
                
        '@↓2009/06/23 (Tue) 17:43:25 Y.Yoneyama **************************************************
                '@無機IPA洗浄、無機CFK装置の場合は特殊処理
                If .strEqType = CPstrEqTypeIPA Or _
                   .strEqType = CPstrEqTypeCFKI Then
                
                    '@ﾎﾟｰﾄﾘｽﾄ格納構造体がﾃﾞｰﾀが存在する場合にｾｯﾄする
                    If .lngPortCnt > 0 Then
                        For llngCnt = 0 To .lngPortCnt - 1
                            '@ﾎﾟｰﾄﾀｲﾌﾟがLoaderの場合のみﾘｽﾄに追加
                            If .typPortList(llngCnt).strPortType = CPstrPortTypeLoader Then
                            
                                cmbPort.AddItem(.typPortList(llngCnt).strPortName & vbTab & _
                                                .typPortList(llngCnt).strPortStatus & vbTab & _
                                                .typPortList(llngCnt).strPortID)
                            End If
                        Next llngCnt
                    Else
                        cmbPort.Clear
                    End If
        '@↑2009/06/23 (Tue) 17:43:25 Y.Yoneyama **************************************************
                
                '@Uni装置の場合
                ElseIf lblLoaderCarrier.Text = vbNullString Then
                        
                    '@ﾎﾟｰﾄﾘｽﾄ格納構造体がﾃﾞｰﾀが存在する場合にｾｯﾄする
                    If .lngPortCnt > 0 Then
                        For llngCnt = 0 To .lngPortCnt - 1
                            cmbPort.AddItem(.typPortList(llngCnt).strPortName & vbTab & _
                                            .typPortList(llngCnt).strPortStatus & vbTab & _
                                            .typPortList(llngCnt).strPortID)
                        Next llngCnt
                    Else
                        cmbPort.Clear
                    End If
                
                '@L/N装置の場合
                Else
                    '@ﾎﾟｰﾄﾘｽﾄ格納構造体がﾃﾞｰﾀが存在する場合にｾｯﾄする
                    If .lngPortCnt > 0 Then
                        For llngCnt = 0 To .lngPortCnt - 1
                            With ltypLotWpList.typWpList(CMlngIndex).typPortList(llngCnt)
                                Select Case .strPortType
                                    Case "UNI"
                                        '@Loaderﾎﾟｰﾄ
                                        cmbPort.AddItem(.strPortName & vbTab & .strPortStatus & vbTab & .strPortID)
                                        '@UnLoaderﾎﾟｰﾄ
                                        cmbLoaderPort.AddItem(.strPortName & vbTab & .strPortStatus & vbTab & .strPortID)
                                    Case "LOADER"
                                         '@Loaderﾎﾟｰﾄ
                                        cmbPort.AddItem(.strPortName & vbTab & .strPortStatus & vbTab & .strPortID)
                                    Case "UNLOADER"
                                         '@UnLoaderﾎﾟｰﾄ
                                        cmbLoaderPort.AddItem(.strPortName & vbTab & .strPortStatus & vbTab & .strPortID)
                                End Select
                            End With
                        Next llngCnt
                    End If
                
                    '@Unloaderﾎﾟｰﾄ№が１個の場合は表示し、複数の場合は表示しない
                    With cmbLoaderPort
                    
                        Select Case True
                            Case .ListCount = 0
                                .BackColor = SystemColors.ControlLight   '背景色(灰)
                                .Enabled = False
                                '@ﾛｯｸ解除
                                cmdRegist.Enabled = True
                            Case .ListCount = 1
                                .ListIndex = 0
                                '@ﾛｯｸ解除
                                .Enabled = True
                                cmdRegist.Enabled = True
                            Case .ListCount > 1
                                .ListIndex = -1
                                '@ﾛｯｸ
                                cmdRegist.Enabled = False
                                '@ﾛｯｸ解除
                                .Enabled = True
                            Case Else
                                '@ﾛｯｸ
                                .Enabled = False
                                '@ﾛｯｸ解除
                                cmdRegist.Enabled = True
                        End Select
                    End With
                End If
            End With
            
            '@Loaderﾎﾟｰﾄ№が１個の場合は表示し、複数の場合は表示しない
            With cmbPort
                If .ListCount = 1 Then
                    .ListIndex = 0
                    '@ﾛｯｸ解除
                    cmdRegist.Enabled = True
                    .Enabled = True
                    .BackColor = SystemColors.Window         '背景色(白)
                Else
                    If .ListCount > 1 Then
                        .ListIndex = -1
                        '@ﾛｯｸ
                        cmdRegist.Enabled = False
                        '@ﾛｯｸ解除
                        .Enabled = True
                        .BackColor = SystemColors.Window     '背景色(白)
                    Else
                        '@ﾛｯｸ
                        .Enabled = False
                        .BackColor = SystemColors.ControlLight           '背景色(灰)
        '@↓2005/06/09 (Thu) 10:54:48 N.Kojima **************************************************
        ''                '@ﾛｯｸ解除
        ''                cmdRegist.Enabled = True
        '@↑2005/06/09 (Thu) 10:54:48 N.Kojima **************************************************
                    End If
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
                .strProcName = "prvPortIDCmb_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvstrRecpIDCr_Get
    '機　能：ﾚｼﾋﾟIDを折り返す
    '引　数：lstrRecpID：ﾚｼﾋﾟID
    '戻り値：折り返し後のﾚｼﾋﾟID
    '作成日：2004/10/01 (Fri) 17:23:40 M.Miura
    '更新日：2004/10/01 (Fri) 17:23:40
    '備　考：
    Private Function prvstrRecpIDCr_Get(ByVal lstrRecpID As String) As String

        Dim llngMaxLen              As Integer              'ﾚｼﾋﾟ文字数
        Dim llngLenCnt              As Integer              '文字ｶｳﾝﾄ
        Dim lstrRecpIDWk            As String               'ﾚｼﾋﾟID

        Try

            '@ﾚｼﾋﾟIDの文字数
            llngMaxLen = Len(lstrRecpID)
            '@ﾚｼﾋﾟID文字数が折り返し文字数以下の場合
            If llngMaxLen <= CMlngRecpCrLen Then
                '@ﾃﾞﾌｫﾙﾄﾚｼﾋﾟをｾｯﾄ
                prvstrRecpIDCr_Get = lstrRecpID
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
                prvstrRecpIDCr_Get = lstrRecpIDWk
            End If

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CPstrKeyEN0070
                .strProcName = "prvstrRecpIDCr_Get"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
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

End Class
