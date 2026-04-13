'ﾌｧｲﾙ名：xxEN0080.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：処理終了　ﾒｲﾝﾌｫｰﾑ
'作成日：2004/03/11 (Thu) 13:06:07 K.Takano
'更新日：2014/11/21 (Fri) 19:26:08 T.Oide
'備　考：
'　　　：2006/07/20 (Thu) 10:01:25 T.Kitagawa ｵﾌﾗｲﾝFTPは必ず同期型で処理させる(案件№00864対応)
'      ：2012/02/29 (Wed) 15:28:33 Y.Yoneyama PLCﾚｼﾋﾟ照合機能対応
'Copyright(C)2003-, SEIKO EPSON CORPORATION.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN0080
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN0080    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN0080
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN0080
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN0080)
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
    '@↓2012/02/29 (Wed) 15:33:10 Y.Yoneyama **************************************************
    '@↓2020/03/06 (Fri) 11:08:36 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion             As String = "08.01"
    Private Const CMstrLocalVersion             As String = "09.00"
    '@↑2020/03/06 (Fri) 11:08:36 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝの宣言
    '@↓2014/11/21 (Fri) 19:26:08 T.Oide **************************************************
    '@↓2020/01/15 (Wed) 14:04:23 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_curstateVer          As String = "03.04"                 'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer          As String = "04.00"                 'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 14:04:23 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CPstrlot_wplist__Ver          As String = "02.05"                 'ﾛｯﾄ装置情報取得
    Private Const CMstrlot_procend_Ver          As String = "04.00"                 'ﾛｯﾄ処理終了
    Private Const CMstreq__state___Ver          As String = "03.00"                 '装置状態取得

    '@ﾛｰｶﾙ機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN0080

    '@その他
    Private Const CMlngCarrierMaxLength         As Integer = 6                     'ｷｬﾘｱIDの最大桁数
    Private Const CMstrLoaderUnloaderFlg        As String = "1"                     'Loader/Unloaderﾌﾗｸﾞ(L/N装置)
    Private Const CMstrLoaderCarrierTitle       As String = "LoaderキャリアID"      'Loaderｷｬﾘｱ表示ﾀｲﾄﾙ
    Private Const CMstrLoaderPortTitle          As String = "Loaderポート№"        'Loaderﾎﾟｰﾄ表示ﾀｲﾄﾙ
    Private Const CMstrUnLoaderCarrierTitle     As String = "UnloaderキャリアID"   'Unloaderｷｬﾘｱ表示ﾀｲﾄﾙ
    Private Const CMstrUnLoaderPortTitle        As String = "Unloaderポート№"      'Unloaderﾎﾟｰﾄ表示ﾀｲﾄﾙ

    '@ｲﾝﾌｫﾒｰｼｮﾝ
    Private Const CMstrTFT                      As String = "TFT"                   'TFT
    Private Const CMstrELT                      As String = "電特"                  '電特
    Private Const CMstrInfomation               As String = "測定データ取得中です。"'ｲﾝﾌｫﾒｰｼｮﾝ

    '@ﾃｷｽﾄ
    Private Const CMlngMaxDispRow               As Integer = 4                      'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(ﾛｯﾄｺﾒﾝﾄ)
    Private Const CMlngMaxDispMemoRow           As Integer = 3                      'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(作業ﾒﾓ)

    '@↓2012/02/28 (Tue) 17:47:29 Y.Yoneyama **************************************************
    '@結果用
    Private Const CMstrOK                       As String = "OK"                    '結果OK
    Private Const CMstrNG                       As String = "NG"                    '結果NG
    '@↑2012/02/28 (Tue) 17:47:29 Y.Yoneyama **************************************************

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    Private mstrLotLastUpdate               As String               'ﾛｯﾄ最終更新日時
    Private mstrCarrier                     As String               'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mblnTakeOverDispFlg             As Boolean              '引継ぎ表示ﾌﾗｸﾞ
    Private mtypLotCurState                 As Lotprestate          'ﾛｯﾄ情報格納構造体
    Private mstrMesMode                     As String               '運用ﾓｰﾄﾞ退避用
    Private mstrFtpDataFlag                 As String               'ｵﾌﾗｲﾝFTPﾌﾗｸﾞ
    Private buttonProcessing                As Boolean              'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu        As Boolean              'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                 As Boolean              'NSYS WindowCloseフラグ

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
    '======================================Private==========================================

    '関数名：Form_Load
    '機　能：ACT初期設定および初期情報取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/11 (Thu) 13:26:55 K.Takano
    '更新日：2005/11/30 (Wed) 09:14:42 N.Kasai
    '備　考：
    '　　　：2005/11/30 (Wed) 09:14:42 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub Form_Load()
        
        Dim lblnAns         As Boolean  '戻り値

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN0080, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If

            '@ﾛｯﾄ情報の初期化
            Call prvfrmxxEN0080_Init()
            
            cmdTxtUp.Enabled = False                    'ｺﾒﾝﾄ ▲ﾎﾞﾀﾝ
            cmdTxtDown.Enabled = False                  'ｺﾒﾝﾄ ▼ﾎﾞﾀﾝ
            cmdMemoUp.Enabled = False                   '作業ﾒﾓ ▲ﾎﾞﾀﾝ
            cmdMemoDown.Enabled = False                 '作業ﾒﾓ ▼ﾎﾞﾀﾝ
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用不可)
            Call prvfrmxxEN0080_CmbInit(False)
            
            '@ｷｬﾘｱIDのｸﾘｱ
            txtCarrier.Text = vbNullString
            
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
    '作成日：2004/07/27 (Tue) 14:40:36 H.Wajima
    '更新日：2005/06/09 (Thu) 18:01:10 N.Kojima
    '備　考：
    '　　　：2004/09/26 (Sun) 13:32:42 N.Kasai　    ｱﾝﾛｰﾀﾞｷｬﾘｱID引継ぎ対応追加
    '　　　：2005/06/09 (Thu) 18:01:10 N.Kojima     Loader/Unloader対応(不具合№829)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            'NSYS 表示位置設定
            Me.Left = 0 - My.Settings.FormOffset
            Me.Top = 0
            
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
            
            With ptypCommonInfo
                '@引数のｷｬﾘｱIDが空白かどうか判定する
                If .strCarrierId <> vbNullString Then
                    '@空白でない場合
                    If .strToCarrierId <> vbNullString Then
                        '@EQﾀｲﾌﾟが"5=ｿｰﾀ"の場合
                        If .strEqType <> CPstrFive Then
                            '@ｱﾝﾛｰﾀﾞｷｬﾘｱIDで初期値を設定する
                            txtCarrier.Text = .strToCarrierId
                        Else
                        '@ｿｰﾀの場合
                            '@ﾛｰﾀﾞｷｬﾘｱIDで初期値を設定する
                            txtCarrier.Text = .strCarrierId
                        End If
                    Else
                        '@ｷｬﾘｱIDの初期値を設定する
                        txtCarrier.Text = .strCarrierId
                    End If
            
                    '@ｷｬﾘｱ情報を取得する
                    Call txtCarrier_Validate(sender,New CancelEventArgs(False))
            
                Else
                    '@ｷｬﾘｱID初期化
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

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑのKeyDown
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/03/16 (Tue) 15:46:08 K.Takano
    '更新日：2004/08/06 (Fri) 14:43:28 Y.Yamagishi
    '備　考：
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
                            RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate 'NSYS 不要なHandlerを抑止
                            Call txtCarrier_Validate(txtCarrier, New CancelEventArgs)
                            AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate 'NSYS 不要なHandlerを抑止解除
                            
                            '@確定ﾎﾞﾀﾝのﾌｫｰｶｽ制御
                            If cmdRegist.Enabled = True Then
                                '@ﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(cmdRegist)
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
                .strMenuKey = CMstrLocalMenuKey
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
    '更新日：2004/11/01 (Mon) 15:45:50 N.Kasai
    '備　考：2004/11/01 (Mon) 15:45:50 N.Kasai  閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender,e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
            pblnFormLoad = False
            
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
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_QueryUnload"
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
    '備　考：2004/09/07 (Tue) 19:02:12 N.Kasai ｺﾒﾝﾄ欄の使用可否判定追加
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
            
        '@↓2005/11/30 (Wed) 09:09:06 N.Kasai **************************************************
        '        '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '        Call pubSetFocus(txtLotCommnt)
        '        '@PageUpｷｰ
        '        SendKeys CPstrSendKeysPageUp, True

                '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
                Call pubtxtCmdUp_Proc(txtLotCommnt, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
        '@↑2005/11/30 (Wed) 09:09:06 N.Kasai **************************************************

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
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
    '備　考：2004/09/07 (Tue) 19:02:59 N.Kasai ｺﾒﾝﾄ欄の使用可否判定追加
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
            
        '@↓2005/11/30 (Wed) 09:09:54 N.Kasai **************************************************
        '        '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '        Call pubSetFocus(txtLotCommnt)
        '        '@PageDownｷｰ
        '        SendKeys CPstrSendKeysPageDown, True

                '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
                Call pubtxtCmdDown_Proc(txtLotCommnt, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
                
        '@↑2005/11/30 (Wed) 09:09:54 N.Kasai **************************************************

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdTxtDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Change
    '機　能：ｷｬﾘｱID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/18 (Thu) 12:46:24 M.Miura
    '更新日：2004/03/18 (Thu) 12:46:24
    '備　考：
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change

        Try
            
            '@ﾛｯﾄ情報の初期化
            Call prvfrmxxEN0080_Init()
            
            '@ﾎﾞﾀﾝ状態
            Call prvfrmxxEN0080_CmbInit(False)
            
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

    '関数名：cmdClose_Click
    '機　能：ﾌﾟﾛｸﾞﾗﾑ終了
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/11 (Thu) 13:18:33 K.Takano
    '更新日：2005/02/15 (Tue) 13:25:37 N.Kojima
    '備　考：2005/02/15 (Tue) 13:25:37 N.Kojima     戻り先画面の判定を追加(改善№512)
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
                Call publngEnd_Proc(CPstrKeyEN0080, ltypCommonInfo)
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

    '関数名：cmdWorkRecord_Click
    '機　能：作業記録入力ﾌｫｰﾑ表示
    '引　数：なし
    '戻り値：ないｓ
    '作成日：2004/06/02 (Wed) 12:42:05 S.Deguchi
    '更新日：2004/06/02 (Wed) 12:42:05
    '備　考：構造体　項目でﾃﾞｰﾀを渡し表示する
    Private Sub cmdWorkRecord_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdWorkRecord.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@現状機能なし
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdWorkRecord_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommntInput_Click
    '機　能：ｺﾒﾝﾄ入力ﾌｫｰﾑ呼出
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/16 (Tue) 16:56:02 K.Takano
    '更新日：2008/06/04 (Wed) 11:41:39 N.Kojima
    '備　考：
    '　　　：2005/06/06 (Mon) 17:09:19 N.Kojima     ﾛｯﾄ状態から引継ぎｷｬﾘｱを変更する処理を追加(不具合№829)
    '　　　：2005/08/26 (Fri) 11:52:42 N.Kojima     Loader/Unloader対応の仕様変更が変更となった為、上記№829の対応を削除。(不具合№3028)
    '　　　：2005/10/26 (Wed) 08:46:12 S.Deguchi    不具合№2404の対応で,画面引継処理を修正
    '　　　：2008/06/04 (Wed) 11:41:39 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
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
                '@↓2020/01/15 (Wed) 17:05:46 Y.Yoneyama 「.Netへ反映未」 **************************************************
                .strGRBClass = lblGRB.Text
                '@↑2020/01/15 (Wed) 17:05:46 Y.Yoneyama 「.Netへ反映未」 **************************************************                

                pstrCarrierID = txtCarrier.Text                         'ｷｬﾘｱID
                
                '@親ﾌｫｰﾑからの呼び出しを識別するためにTrueにする
                pblnfrmxxCM0030Kbn = True
            
                '@起動ﾌﾗｸﾞを設定
                pblnFormLoad = False
                
                '@ﾌｫｰﾑをﾛｰﾄﾞする
                frmxxCM0030.Instance = New frmxxCM0030()
                
                '@ﾒﾆｭｰｷｰから機能の関連情報を取得する
                Call pubMenuItemCorrelation_Set(CPstrKeyEN0140, lstrTitle)

                'NSYS @Form_Loadﾌﾗｸﾞが異常の場合
                If pblnFormLoad = False Then
                    '@ｱﾝﾛｰﾄﾞする
                    frmxxCM0030.Instance = Nothing
                
                    '@起動ﾌﾗｸﾞを戻す
                    pblnFormLoad = True
                    
                    Exit Sub
                End If

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
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCommntInput_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：処理終了確定
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/16 (Tue) 17:47:21 K.Takano
    '更新日：2007/06/19 (Tue) 13:32:32 N.Kasai
    '備　考：
    '　　　：2005/03/25 (Fri) 14:04:49 N.Kojima     FTPﾃﾞｰﾀ登録結果判定処理を追加(改善№625)
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2005/10/04 (Tue) 17:14:16 N.Kasai      TFT測定機、電特の場合はｲﾝﾌｫﾒｰｼｮﾝﾌｫｰﾑを起動する。
    '　　　：2005/11/24 (Thu) 10:36:07 S.Deguchi    ｵﾌﾗｲﾝFTPﾌﾗｸﾞ処理を追加
    '　　　：2005/12/20 (Tue) 10:36:07 S.Deguchi    ｵﾌﾗｲﾝFTPﾌﾗｸﾞ処理をｺﾒﾝﾄｱｳﾄ
    '　　　：2006/07/20 (Thu) 09:41:18 T.Kitagawa   ｵﾌﾗｲﾝFTPﾌﾗｸﾞ処理を復活(案件№00864)
    '　　　：2007/06/19 (Tue) 13:32:32 N.Kasai      ｵﾌﾗｲﾝFTPを廃止(№01975)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance        As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg
        Dim llngRtn                 As Integer              'ﾚｽﾎﾟﾝｽ関数ﾚｽﾎﾟﾝｽ時間戻り値
        Dim lblnCM00X0DispFlag      As Boolean              '処理中ﾌｫｰﾑ表示ﾌﾗｸﾞ(False:未表示、True:表示済)
        Dim lstrPlcResult           As String               'PLCﾚｼﾋﾟ照合結果
        
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
            lblnAns = prvblnInput_Chk
            If lblnAns = False Then
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
            
            '@処理中ﾌｫｰﾑ表示ﾌﾗｸﾞの初期化
            lblnCM00X0DispFlag = False          '処理中ﾌｫｰﾑ表示ﾌﾗｸﾞ(False:未表示、True:表示済)
            
            '@ｵﾌﾗｲﾝFTPﾃﾞｰﾀ登録処理を行わない場合
            '@TFT測定機 & 電特装置の場合のみﾌｫｰﾑ起動
            Select Case mtypLotCurState.strEqType
                '@TFT測定の場合
                Case CPstrEqTypeTFTS
                    '@ｲﾝﾌｫﾒｰｼｮﾝ画面起動
                    frmxxCM00X0.Instance = New frmxxCM00X0()
                    '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定
                    frmxxCM00X0.Instance.Text = CPstrSubFormCM00X0Proc
                    '@ｲﾝﾌｫﾒｰｼｮﾝ(TFT測定データ取得中です。)
                    frmxxCM00X0.Instance.lblInfomation1.Text = CMstrTFT & CMstrInfomation
                    '@処理中ﾌｫｰﾑ表示ﾌﾗｸﾞON
                    lblnCM00X0DispFlag = True      '処理中ﾌｫｰﾑ表示ﾌﾗｸﾞ(False:未表示、True:表示済)
                    '@ｲﾝﾌｫﾒｰｼｮﾝﾌｫｰﾑを先行して描画する為、記述しています。
                    frmxxCM00X0.Instance.Show(Me) 
                    frmxxCM00X0.Instance.Refresh()
                    
                '@電特の場合
                Case CPstrEqTypeElect
                    '@ｲﾝﾌｫﾒｰｼｮﾝ画面起動
                    frmxxCM00X0.Instance = New frmxxCM00X0()
                    '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定
                    frmxxCM00X0.Instance.Text = CPstrSubFormCM00X0Proc
                    '@ｲﾝﾌｫﾒｰｼｮﾝ(TFT測定データ取得中です。)
                    frmxxCM00X0.Instance.lblInfomation1.Text = CMstrELT & CMstrInfomation
                    '@処理中ﾌｫｰﾑ表示ﾌﾗｸﾞON
                    lblnCM00X0DispFlag = True      '処理中ﾌｫｰﾑ表示ﾌﾗｸﾞ(False:未表示、True:表示済)
                    '@ｲﾝﾌｫﾒｰｼｮﾝﾌｫｰﾑを先行して描画する為、記述しています。
                    frmxxCM00X0.Instance.Show(Me) 
                    frmxxCM00X0.Instance.Refresh()
            End Select
            
        '@↓2012/02/29 (Wed) 15:50:08 Y.Yoneyama **************************************************
            '@ﾛｯﾄ処理終了ﾒｯｾｰｼﾞ送信(最終更新日時は、確定時に返される値を使う。ﾒｯｾｰｼﾞ関数内で書き換えている。)
            lblnAns = pubblnLotProcend_Upd(CMstrlot_procend_Ver, _
                                           CPstrCD01, _
                                           lblLotID.Text, _
                                           pstrUserID, _
                                           txtWorkMemo.Text, _
                                           mstrLotLastUpdate, _
                                           lstrGuidMsg, _
                                           lstrGuidMsgCode, _
                                           lstrPlcResult)
        '@↑2012/02/29 (Wed) 15:50:08 Y.Yoneyama **************************************************

            '@結果判定
            If lblnAns = True Then
                
                '@処理中ﾌｫｰﾑを表示している場合は子ﾌｫｰﾑをUnloadする
                If lblnCM00X0DispFlag = True Then
                    '@ｲﾝﾌｫﾒｰｼｮﾝ画面終了
                    frmxxCM00X0.Instance = Nothing
                End If
                    
        '@↓2012/02/28 (Tue) 17:51:20 Y.Yoneyama **************************************************
                '@PLCﾚｼﾋﾟ照合の警告ﾒｯｾｰｼﾞ表示
                If lstrPlcResult <> CMstrOK Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0120)
                            
                    '@"<TRM120W>$$PLCレシピ照合に失敗しました。$$装置レシピが異なりますので流動表レシピと確認してください｡"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                End If
        '@↑2012/02/28 (Tue) 17:51:20 Y.Yoneyama **************************************************
                        
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
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0019, txtCarrier.Text, lblLotID.Text)
                
                '@pubVsfInfo_Disp("メッセージコード：C_I19%0$$処理を終了しました。キャリア[ %1 ] ロット[ %2 ]")
                Call pubVsfInfo_Disp(pstrDMsg)
                                 
                '@ｷｬﾘｱIDのｸﾘｱ
                txtCarrier.Text = vbNullString
                
                '@ﾛｯﾄ情報の初期化
                Call prvfrmxxEN0080_Init()
                
                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用不可)
                Call prvfrmxxEN0080_CmbInit(False)
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                llngRtn = publngResponseEnd(lstrFormName, lstrEventName)
                '@3秒以上経過した場合はﾌｫｰｶｽの設定は行わない。
                If IsNumeric(llngRtn) = True Then
                    If llngRtn < 3000 Then
                        '@ｷｬﾘｱIDにﾌｫｰｶｽをｾｯﾄ
                        Call pubSetFocus(txtCarrier)
                    End If
                End If
                
                Exit Sub
            Else
                '@処理中ﾌｫｰﾑを表示している場合は子ﾌｫｰﾑをUnloadする
                If lblnCM00X0DispFlag = True Then
                    '@ｲﾝﾌｫﾒｰｼｮﾝ画面終了
                    frmxxCM00X0.Instance = Nothing
                End If

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            End If
            
            '@ｷｬﾘｱIDにﾌｫｰｶｽをｾｯﾄ
            Call pubSetFocus(txtCarrier)
            
            Exit Sub

        Catch ex As Exception
            
            '@処理中ﾌｫｰﾑを表示している場合は子ﾌｫｰﾑをUnloadする
            If lblnCM00X0DispFlag = True Then
                '@ｲﾝﾌｫﾒｰｼｮﾝ画面終了
                frmxxCM00X0.Instance = Nothing
            End If
            
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
                .strMenuKey = CMstrLocalMenuKey
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
                .strMenuKey = CMstrLocalMenuKey
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
                .strMenuKey = CMstrLocalMenuKey
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
    '更新日：2005/11/30 (Wed) 09:07:22 N.Kasai
    '備　考：
    '　　　：2005/11/30 (Wed) 09:06:24 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change
        
        Dim llngNowByte As Integer 'ﾊﾞｲﾄ数

        Try
            
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtWorkMemo.NowByte
            
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
                         
        '@↓2005/11/30 (Wed) 09:05:35 N.Kasai **************************************************
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
        '@↑2005/11/30 (Wed) 09:05:35 N.Kasai **************************************************
                     
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
    '更新日：2005/11/30 (Wed) 09:07:16 N.Kasai
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
    '更新日：2005/11/30 (Wed) 09:07:06 N.Kasai
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
    '作成日：2004/04/27 (Tue) 14:52:32 M.Miura
    '更新日：2005/11/30 (Wed) 09:06:55 N.Kasai
    '備　考：
    '　　　：2005/11/30 (Wed) 09:06:24 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdMemoUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/11/30 (Wed) 09:03:38 N.Kasai **************************************************
        '    '@作業メモにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtWorkMemo)
        '
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
            
        '@↑2005/11/30 (Wed) 09:03:38 N.Kasai **************************************************

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
    '作成日：2004/04/27 (Tue) 14:53:27 M.Miura
    '更新日：2005/11/30 (Wed) 09:06:24 N.Kasai
    '備　考：
    '　　　：2005/11/30 (Wed) 09:06:24 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdMemoDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/11/30 (Wed) 09:04:14 N.Kasai **************************************************
        '    '@作業メモにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtWorkMemo)
        '
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)

        '@↑2005/11/30 (Wed) 09:04:14 N.Kasai **************************************************
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

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '======================================Public===========================================

    '関数名：txtCarrier_Validate
    '機　能：ｷｬﾘｱIDﾌｫｰｶｽ制御
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/03/16 (Tue) 14:15:35 K.Takano
    '更新日：2004/08/06 (Fri) 14:42:53 Y.Yamagishi
    '備　考：
    Public Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim lblnAns         As Boolean  '戻り値
        Dim lstrFormName    As String   'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName   As String   'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの空白ﾁｪｯｸ
            If Trim(txtCarrier.Text) = vbNullString Then
                '@空ENTERの場合はﾌｫｰｶｽ移動
                SendKeys.SendWait(CPstrSendKeysTab)
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

            '@ｷｬﾘｱID Enter処理
            lblnAns = txtCarrier_Enter(sender,e)
            '@結果判定
            If lblnAns = True Then
                
                '@正常時、ﾌｫｰｶｽ移動
                If cmdRegist.Enabled = True Then
                    '@確定ﾎﾞﾀﾝ押下可の場合
                    '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdRegist)
                Else
                    '@ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdCommntInput)
                End If

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                Exit Sub
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                Exit Sub
            End If
            
            '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(cmdRegist)
            
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

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：prvfrmxxEN0080_Init
    '機　能：ﾛｯﾄ情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/16 (Tue) 13:11:55 K.Takano
    '更新日：2008/06/04 (Wed) 11:42:24 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 11:43:51 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理追加
    '　　　：2005/11/24 (Thu) 10:37:23 S.Deguchi    不具合№3248の対応でｵﾌﾗｲﾝFTPﾌﾗｸﾞ処理を追加
    '　　　：2008/06/04 (Wed) 11:42:24 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxEN0080_Init()
        
        Dim lstrFormTitle       As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0080, lstrFormTitle)
            
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
            lblWP.Text = vbNullString                                '装置名(WPID)
            lblPort.Text = vbNullString                              '装置ﾎﾟｰﾄNo
            lblWpStatusName.Text = vbNullString                      '装置状態名
            '@↓2020/01/15 (Wed) 17:06:20 Y.Yoneyama 「.Netへ反映未」 **************************************************
            lblGRB.Text = vbNullString                               'GRB
            '@GRB背景色
            lblGRB.BackColor = lblLotManager.BackColor
            '@↑2020/01/15 (Wed) 17:06:20 Y.Yoneyama 「.Netへ反映未」 **************************************************

            mstrLotLastUpdate = vbNullString                         'ﾛｯﾄ最終更新日時
            mstrCarrier = vbNullString                               'ｷｬﾘｱID(ﾒｯｾｰｼﾞ成功時のｷｬﾘｱID)
            mstrFtpDataFlag = vbNullString                           'ｵﾌﾗｲﾝFTPﾌﾗｸﾞ
            
            '@作業ﾒﾓ初期化
            With txtWorkMemo
                .ChrMaxByte = CPlngLotCommentsMaxByte
                .Text = vbNullString
                Call txtWorkMemo_Change(txtWorkMemo, EventArgs.Empty)
            End With
            
            '@ﾛｯﾄｺﾒﾝﾄ設定・初期化
            With txtLotCommnt
                .ChrMaxByte = CPlngLotCommentsMaxByte
                .Text = vbNullString                            'ﾛｯﾄｺﾒﾝﾄ
                .MultiLineEx = True                             'ﾛｯﾄｺﾒﾝﾄ複数行表示
                '@背景色(ｸﾞﾚｰ)
                .BackColor = System.Drawing.SystemColors.ControlLight
                .GotBackColor = System.Drawing.SystemColors.ControlLight
                '@ﾛｯｸ
                .Locked = True
            End With
            
            '@LoaderｷｬﾘｱID
            lblLoaderCarrier.Text = vbNullString
            
            '@Loaderﾎﾟｰﾄ№
            lblLoaderPort.Text = vbNullString
            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN0080_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN0080_CmbInit
    '機　能：各ｺﾏﾝﾄﾞﾎﾞﾀﾝの制御
    '引　数：lblnEnable：True:使用可能,False:使用不可
    '戻り値：なし
    '作成日：2004/03/16 (Tue) 13:12:37 K.Takano
    '更新日：2005/11/30 (Wed) 09:13:01 N.Kasai
    '備　考：2004/09/24 (Fri) 13:03:44 H.Wajima 流動ﾀｲﾌﾟ判定追加
    '　　　：2005/11/30 (Wed) 09:13:01 N.Kasai  ｽｸﾛｰﾙ連動
    Private Sub prvfrmxxEN0080_CmbInit(Optional ByVal lblnEnable As Boolean = False)

        Try
            
            '@各ｺﾏﾝﾄﾞﾎﾞﾀﾝのｺﾝﾄﾛｰﾙ
            cmdRegist.Enabled = lblnEnable             '処理終了
            
            '@ｺﾒﾝﾄの制御
            txtLotCommnt.Enabled = lblnEnable           'ｺﾒﾝﾄ
                
            '@流動ﾀｲﾌﾟの判定
            If mtypLotCurState.strFlowType = CPstrLotCurstateFlowTypeMove Then
                '@移載工程の場合
                
                cmdCommntInput.Enabled = False          'ﾛｯﾄｺﾒﾝﾄ入力
                cmdWorkRecord.Enabled = False           '作業記録
                    
                '@作業ﾒﾓの制御
                txtWorkMemo.Enabled = False             '作業ﾒﾓ
                cmdMemoUp.Enabled = False               '作業ﾒﾓ頁UP
                cmdMemoDown.Enabled = False             '作業ﾒﾓ頁DOWN
                
            Else
                '@移載工程以外の場合
                cmdCommntInput.Enabled = lblnEnable     'ﾛｯﾄｺﾒﾝﾄ入力
                
                '@作業ﾒﾓの制御
                txtWorkMemo.Enabled = lblnEnable        '作業ﾒﾓ
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN0080_CmbInit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN0080_Disp
    '機　能：画面の表示
    '引　数：ltypLotprestate：格納ﾃﾞｰﾀ
    '戻り値：なし
    '作成日：2004/03/16 (Tue) 14:12:53 K.Takano
    '更新日：2008/06/04 (Wed) 11:43:05 N.Kojima
    '備　考：
    '　　　：2004/08/25 (Wed) 12:16:23 N.Kasai      CFﾌﾗｸﾞ判定追加、"mm/dd hh:mm:ss"を共通変数化
    '　　　：2004/09/09 (Thu) 19:25:33 Y.Yamagishi　時間制限表示変更(不具合改善№693)
    '　　　：2004/09/14 (Tue) 10:28:44 N.Kojima　   数量表示(TPALﾛｯﾄ対応)修正(不具合改善№730)
    '　　　：2004/09/24 (Fri) 10:47:35 Y.Yamagishi  制限時間以上の場合文字色を青に変更(不具合改善№825)
    '　　　：2005/08/29 (Mon) 11:19:40 N.Kojima     L/Uｷｬﾘｱの表示処理を追加。(不具合№3028)
    '　　　：2005/11/24 (Thu) 10:37:23 S.Deguchi    不具合№3248の対応でｵﾌﾗｲﾝFTPﾌﾗｸﾞ処理を追加
    '　　　：2006/06/08 (Thu) 14:49:38 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2008/06/04 (Wed) 11:43:05 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxEN0080_Disp(ByRef ltypLotprestate As Lotprestate)

        Try

            '@ﾛｯﾄ情報の表示
            With ltypLotprestate
                lblLotID.Text = .strLotID                                            'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass                                    '流動区分
                lblOpID.Text = .strOpID                                              '大工程ID
                If IsDate(.strStartTime) Then
                    lblStartDayTime.Text = Format$(CDate(.strStartTime), CPstrDateFormat)'開始日時"MM/dd HH:mm:ss"
                Else
                    lblStartDayTime.Text = .strStartTime
                End If
                lblPdID.Text = .strPdId                                              '機種名
                lblS.Text = .strSpecialFlg                                           '特殊特性
                lblStatus.Text = .strNowST                                           '状態
                lblStepID.Text = .strStepID                                          '小工程ID
                lblLotManager.Text = .strEngEmpName                                  'ﾛｯﾄ担当
                '@↓2020/01/15 (Wed) 17:07:26 Y.Yoneyama 「.Netへ反映未」 **************************************************
                lblGRB.Text = .strGRBClass                                           'GRB
                '@GRB背景色
                lblGRB.BackColor = pubGRBBackColor(.strGRBClass, lblLotManager.BackColor)
                '@↑2020/01/15 (Wed) 17:07:26 Y.Yoneyama 「.Netへ反映未」 **************************************************

                mstrFtpDataFlag = .strFtpDataFlag                                       'ｵﾌﾗｲﾝFTPﾌﾗｸﾞ
                
                '@時間制約有無の表示
                If .strLimitTime <> vbNullString Then
                    '@時間制約がﾌﾟﾗｽの場合
                    If CLng(.strLimitTime) >= 0 Then
                        
                        '@制限時間以下or処理時間制限以下の場合
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
                                    lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple) '紫色
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
                        lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed) '赤色
                        
                        '@制限時間以下or処理時間制限以下の場合
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
                
                txtLotCommnt.Text = .strComments                                        'ﾛｯﾄｺﾒﾝﾄ
                mstrLotLastUpdate = .strLotLastUpdate                                   'ﾛｯﾄ最終更新日時
                
                '@Loader_CarrierIDには、Loader入力の場合→Unloader、Unloader入力時→Loader　を表示します。
                ' 現仕様では、通常工程・L/U装置の場合のみ、「Loaderｷｬﾘｱ」ﾗﾍﾞﾙに表示します。
                '@上記対応に伴い、Unloaderｷｬﾘｱ表示時は、ｷｬﾘｱID・ﾎﾟｰﾄﾗﾍﾞﾙのcaptionを変更する。
                '@下記UnloaderCarrierは返され方がおかしいので注意！！
                ' 例：A00000(Loader),A00001(Unloader)で作業開始。
                ' 　　A00000は常にﾀｸﾞ「UNLOADER_CARRIER_ID」に返却され、A00001は常にﾀｸﾞ「CARRIER_ID」に返却される。
                
                '@入力ｷｬﾘｱIDがLoaderｷｬﾘｱか
                If txtCarrier.Text = .strUnloaderCarrierID Then
                    '@Unloaderｷｬﾘｱを格納
                    lblLoaderCarrier.Text = .strCarrierId                            'UnloaderｷｬﾘｱID
                    
                    '@ﾗﾍﾞﾙを「Unloader系」に変更
                    lblTtl14.Text = CMstrUnLoaderCarrierTitle                      '"UnloaderキャリアID"
                    lblTtl18.Text = CMstrUnLoaderPortTitle                         '"Unloaderポート№"
                Else
                    '@Loaderｷｬﾘｱを格納
                    lblLoaderCarrier.Text = .strUnloaderCarrierID                    'LoaderｷｬﾘｱID

                    '@ﾗﾍﾞﾙを「Loader系」に変更
                    lblTtl14.Text = CMstrLoaderCarrierTitle                        '"LoaderキャリアID"
                    lblTtl18.Text = CMstrLoaderPortTitle                           '"Loaderポート№"
                End If
                
        '        lblLoaderPort.Caption = .strPortName                                    'UnLoaderﾎﾟｰﾄ№
                
                '@枚数表示判定(CF_FLAGを判定し、WF枚数とﾁｯﾌﾟ枚数の表示を切替)
                Select Case .strCfFlag
                    '@CFﾛｯﾄ
                    Case CPstrCF
                        '@大判ﾌﾗｸﾞ判定(LP_FLAG)
                        If .strLpFlag = CPstrLP Then
                            '@大判の場合
                            lblWFNo.Text = .strWfNum                                         'WF枚数
                        Else
                            'NSYS 数値判定後設定
                            If IsNumeric(.strChipQuantity) Then
                                lblWFNo.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)      'ﾁｯﾌﾟ枚数
                            Else
                                lblWFNo.Text = .strChipQuantity
                            End If
                        End If
                    
                    '@CFﾛｯﾄ以外
                    Case Else
                        '@TPALﾛｯﾄ
                        If Trim(Strings.Left$(.strLotID, 2)) = CPstrTpalLot Then
                            lblWFNo.Text = Format$(.strChipQuantity, CPstrCFKnmaFormat)      'ﾁｯﾌﾟ枚数
                        Else
                            '@CF,TPALﾛｯﾄ以外
                            lblWFNo.Text = .strWfNum                                         'WF枚数
                        End If
                End Select
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN0080_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnInput_Chk
    '機　能：入力確認
    '引　数：なし
    '戻り値：True：成功、False：失敗
    '作成日：2004/03/18 (Thu) 10:29:00 K.Takano
    '更新日：2004/03/18 (Thu) 10:29:00
    '備　考：
    Private Function prvblnInput_Chk() As Boolean

        Try
            
            '@初期化
            prvblnInput_Chk = False
            
            '@ｷｬﾘｱIDの入力ﾁｪｯｸ
            If txtCarrier.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                
                '@"キャリアIDが設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Call pubSetFocus(txtCarrier)
                
                Exit Function
            End If
            
            '@ｷｬﾘｱIDが6桁であるかﾁｪｯｸ
            If Len(txtCarrier.Text) <> CMlngCarrierMaxLength Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Call pubSetFocus(txtCarrier)
                
                Exit Function
            End If
            
            '@状態ﾁｪｯｸ
            If lblStatus.Text <> CPstrProcessingSt Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0030)
                
                '@"「処理中」以外のロットは終了できません。”
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Call pubSetFocus(txtCarrier)
                
                Exit Function
            End If
            
            '@入力OK
            prvblnInput_Chk = True
            
            Exit Function

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
    End Function

    '関数名：txtCarrier_Enter
    '機　能：ｷｬﾘｱID Enter処理
    '引　数：なし
    '戻り値：True：正常、False：エラー
    '作成日：2004/03/18 (Thu) 16:21:30 M.Miura
    '更新日：2008/07/07 (Mon) 13:26:53 T.Inafune
    '備　考：
    '　　　：2005/03/25 (Fri) 14:18:49 N.Kojima     処理終了時FTPﾃﾞｰﾀ登録の判定に運用ﾓｰﾄﾞが必要な為、
    '　　　：                                       装置状態取得Msg追加(改善№625)
    '　　　：2008/07/07 (Mon) 13:26:53 T.Inafune    Loader/Unloader装置情報をeq_stateから情報取得する。lot_wplist送信中止(No:01193)
    Private Function txtCarrier_Enter(ByVal sender As Object, ByVal e As EventArgs) As Boolean

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrLotCarrierID        As String               'ｷｬﾘｱID
        Dim lstrCarrierIDWk         As String               'ｷｬﾘｱID比較用
        Dim ltypEqstate             As Eqstate              '装置状態ﾘｽﾄ格納
        
        Try
            
            '@初期化
            txtCarrier_Enter = False
                
            '@ｷｬﾘｱID取得
            lstrLotCarrierID = txtCarrier.Text
            
            '@ｷｬﾘｱIDが入力されている場合
            If lstrLotCarrierID <> vbNullString Then
                '@ｷｬﾘｱID比較用
                lstrCarrierIDWk = mstrCarrier
            
                '@【ﾛｯﾄ現在状態取得】ﾒｯｾｰｼﾞ送受信処理
                lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                                CPstrCD12, _
                                                lstrLotCarrierID, _
                                                mtypLotCurState)
                
                '@=======================
                '@　画面表示処理(ﾍｯﾀﾞｰ部)
                '@=======================
                Call prvfrmxxEN0080_Disp(mtypLotCurState)
                
                '@ﾛｯﾄ現在状態取得結果判定
                If lblnAns = True Then
                    '@ﾛｯﾄ現在状態取得結果：正常の場合
                
        '@↓2008/07/07 (Mon) 13:28:11 T.Inafune **************************************************
        '            '@装置情報取得
        '            lblnAns = pubblnLotWplist_Sel(CPstrlot_wplist__Ver, _
        '                                          CPstrCD12, _
        '                                          lblLotID.Caption, _
        '                                          lblOpID.Caption, _
        '                                          lblStepID.Caption, _
        '                                          mtypLotCurState.strAltNumber, _
        '                                          ltypLotWpList)
        '            '@結果判定
        '            If lblnAns = False Then
        '                Exit Function
        '            End If
        '
        '            '@装置、ﾎﾟｰﾄ表示
        '            Call prvlblWpInfo_Disp(ltypLotWpList)
        '
        '            '@装置状態取得
        '            lblnAns = pubblnEqState_Sel(CMstreq__state___Ver, _
        '                                        lblWP.Tag, _
        '                                        ltypEqstate)
        '@↑2008/07/07 (Mon) 13:28:11 T.Inafune **************************************************
                    
                    '@【装置状態取得】ﾒｯｾｰｼﾞ送受信処理
                    lblnAns = pubblnEqState_Sel(CMstreq__state___Ver, _
                                                mtypLotCurState.strWpID, _
                                                ltypEqstate)
                    '@装置状態取得結果判定
                    If lblnAns = False Then
                        '@装置状態取得結果：異常の場合
                    
                        Exit Function
                    End If
                    
                    '@=======================
                    '@　装置情報、ﾎﾟｰﾄ情報表示処理
                    '@=======================
                    Call prvlblWpInfo_Disp(ltypEqstate)
                    
                    '@使用装置の運用ﾓｰﾄﾞを格納
                    mstrMesMode = ltypEqstate.strMesModeId
                
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用可)
                    Call prvfrmxxEN0080_CmbInit(True)
                    
                    '@結果OKを返す
                    txtCarrier_Enter = True
                    
                    '@次回ｷｬﾘｱID比較用
                    mstrCarrier = txtCarrier.Text
                End If
            Else
                '@結果OKを返す
                txtCarrier_Enter = True
            End If

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrier_Enter"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '@↓2008/07/07 (Mon) 13:22:39 T.Inafune **************************************************
    ''関数名：prvlblWpInfo_Disp
    ''機　能：装置、ﾎﾟｰﾄ表示
    ''引　数：ltypLotWpList：装置情報構造体
    ''戻り値：なし
    ''作成日：2004/06/09 (Wed) 13:11:06 M.Miura
    ''更新日：2004/09/23 (Thu) 10:52:22 M.Miura
    ''備　考：2004/09/23 (Thu) 10:52:22 M.Miura Loader/Unloader装置判定でLoaderｷｬﾘｱ、ﾎﾟｰﾄの初期化を追加
    'Private Sub prvlblWpInfo_Disp(ByRef ltypLotWpList As LotWpList)
    '
    '    Dim llngCnt As Long 'ｶｳﾝﾄ
    '
    '    On Error GoTo Error_Handler
    '
    '    llngCnt = 1
    '
    '    '@装置が取得できた場合
    '    If ltypLotWpList.lngWPCnt > 0 Then
    '
    '        With ltypLotWpList.typWPList(llngCnt)
    '
    '            lblWP.Caption = .strWpName                                  '装置名
    '            lblWP.Tag = .strWpID                                        '装置ID
    '            lblWpStatusName.Caption = .strWpStatusName                  '装置状態
    '
    '            '@ﾎﾟｰﾄが取得できた場合
    '            If .lngPortCnt > 0 Then
    '                lblPort.Caption = .typPortList(llngCnt).strPortName     'ﾎﾟｰﾄ名
    '            End If
    '
    '            '@Loader/Unloader装置ではない場合
    '            If .strLoaderUnloaderFlag <> CMstrLoaderUnloaderFlg Then
    '                lblLoaderCarrier.Caption = vbNullString                 'LoaderｷｬﾘｱID
    '                lblLoaderPort.Caption = vbNullString                    'Loaderﾎﾟｰﾄ№
    '            End If
    '        End With
    '    End If
    '
    '    Exit Sub
    '
    'Error_Handler:
    '
    '    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '    With ptypOnErrorInfo
    '        .strMenuKey = CMstrLocalMenuKey
    '        .strProcName = "prvlblWpInfo_Disp"
    '        .strErrMessage = vbNullString
    '    End With
    '
    '    '@共通ｴﾗｰ処理
    '    Call pubOnError_Proc
    '
    'End Sub
    '@↑2008/07/07 (Mon) 13:22:39 T.Inafune **************************************************

    '関数名：prvlblWpInfo_Disp
    '機　能：装置、ﾎﾟｰﾄ表示
    '引　数：ltypEqstate：装置情報構造体
    '戻り値：なし
    '作成日：2004/06/09 (Wed) 13:11:06 M.Miura
    '更新日：2008/07/07 (Mon) 13:20:15 T.Inafune
    '備　考：
    '　　　：2004/09/23 (Thu) 10:52:22 M.Miura      Loader/Unloader装置判定でLoaderｷｬﾘｱ、ﾎﾟｰﾄの初期化を追加
    '　　　：2008/07/07 (Mon) 13:20:15 T.Inafune    Loader/Unloader装置情報をeq_stateから情報取得する。(No:01193)
    Private Sub prvlblWpInfo_Disp(ByRef ltypEqstate As Eqstate)
        
        Dim llngCnt As Integer 'ｶｳﾝﾄ

        Try

            llngCnt = 1

            With ltypEqstate
            
                '@装置のﾎﾟｰﾄ情報が存在するか
                If .lngPortListCnt > 0 Then
                    
                    '@各種ﾗﾍﾞﾙに情報ｾｯﾄ
                    lblWP.Text = mtypLotCurState.strWpName                   '装置名
                    lblWP.Tag = mtypLotCurState.strWpID                         '装置ID
                    lblWpStatusName.Text = .strWpStatusName                  '装置状態
                        
                    '@ﾎﾟｰﾄ情報を基に、ﾎﾟｰﾄﾗﾍﾞﾙの設定を行なう
                    For llngCnt = 0 To .lngPortListCnt - 1
                        
                        '@入力ｷｬﾘｱと装置情報(ﾎﾟｰﾄﾘｽﾄ)のｷｬﾘｱが同じか
                        If txtCarrier.Text = .typPortList(llngCnt).strCarrierId Then
                            
                            '@Loader側のﾎﾟｰﾄを設定("#"付きにﾌｫｰﾏｯﾄ　例：#1 etc..)
                            lblPort.Text = "#" & .typPortList(llngCnt).strPortID
                        End If
                        
                        If lblLoaderCarrier.Text = .typPortList(llngCnt).strCarrierId Then
                        
                            '@Unloader側のﾎﾟｰﾄを設定("#"付きにﾌｫｰﾏｯﾄ　例：#1 etc..)
                            lblLoaderPort.Text = "#" & .typPortList(llngCnt).strPortID
                        End If
                    Next llngCnt
                        
                    '@Loader/Unloader装置か(lot_.curstateの応答"UNLOADER_CARRIER_ID"がNULLで判断)
                    If mtypLotCurState.strUnloaderCarrierID = vbNullString Then
                    
                        '@Unloader情報表示ﾗﾍﾞﾙにNULLをｾｯﾄ
                        lblLoaderCarrier.Text = vbNullString                 'LoaderｷｬﾘｱID
                        lblLoaderPort.Text = vbNullString                    'Loaderﾎﾟｰﾄ№
                    End If
            
                End If
            
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvlblWpInfo_Disp"
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

End Class
