'ﾌｧｲﾙ名：xxEN00R0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ダミーLoad/Unload/再投入　メインフォーム
'作成日：2004/08/03 (Tue) 15:52:22 T.Kitagawa
'更新日：2014/11/21 (Fri) 19:10:16
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00R0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00R0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00R0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00R0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00R0)
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
    '@↓2020/03/06 (Fri) 11:15:05 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion         As String = "05.01"
    Private Const CMstrLocalVersion         As String = "05.02"
    '@↑2020/03/06 (Fri) 11:15:05 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey         As String = CPstrKeyEN00R0          'ﾛｰｶﾙ機能ID

    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝの宣言
    '@↓2020/01/15 (Wed) 14:05:03 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_curstateVer      As String = "03.04"                 'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer      As String = "04.00"                 'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 14:05:03 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrlot_wplist__Ver      As String = "02.05"                 'ﾛｯﾄ装置情報取得
    Private Const CMstrdumychgstateVer      As String = "01.00"                 'ﾀﾞﾐｰｶｾｯﾄﾛｰﾄﾞ/ｱﾝﾛｰﾄﾞ

    Private Const CMlngCarrierMaxLength     As Integer = 6                      'ｷｬﾘｱIDの最大桁数

    Private Const CMlngcmbPortID            As Integer = 2                      'ﾎﾟｰﾄID列
    Private Const CMlngcmdLoadIndex         As Integer = 0                      'Load処理
    Private Const CMlngcmdUnloadIndex       As Integer = 1                      'Unload処理
    Private Const CMlngcmdRethrowin         As Integer = 2                      '再投入処理

    '@ｺﾝﾎﾞの設定
    Private Const CMlngDispCols             As Integer = 2                      'ｺﾝﾎﾞ表示列数
    Private Const CMlngRowHeight            As Integer = 43                     'ｺﾝﾎﾞの幅

    '@ｲﾍﾞﾝﾄ名
    Private Const CMstrcmdLoad_Click        As String = "cmdLoad_Click"         'LoadﾎﾞﾀﾝClick処理
    Private Const CMstrcmdUnLoad_Click      As String = "cmdUnload_Click"       'UnLoadﾎﾞﾀﾝClick処理
    Private Const CMstrcmdRethrowin_Click   As String = "cmdRethrowin_Click"    '再投入ﾎﾞﾀﾝClick処理

    '@CARRIER_STATE_FLAG用定数
    Private Const CMstrRethrowin            As String = "2"                     '再投入

    '@ﾃｷｽﾄ
    Private Const CMlngMaxDispRow           As Integer = 4                      'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(ﾛｯﾄｺﾒﾝﾄ)
    Private Const CMlngMaxDispMemoRow       As Integer = 3                      'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(作業ﾒﾓ)

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mtypLotprestate                 As Lotprestate          'ﾛｯﾄ情報格納構造体
    Private mstrCarrier                     As String               'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mblnTakeOverDispFlg             As Boolean              '引継ぎ表示ﾌﾗｸﾞ
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
    '====================================Private============================================

    '関数名：Form_Load
    '機　能：ACT初期設定および初期情報取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/03 (Tue) 15:58:12 T.Kitagawa
    '更新日：2005/12/02 (Fri) 10:06:16 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 10:06:16 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub Form_Load()

        Dim lblnAns         As Boolean      '戻り値

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN00R0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            '@ﾛｯﾄ情報の初期化
            Call prvfrmxxEN00R0_Init()
            
        '@↓2005/12/02 (Fri) 10:06:05 N.Kasai **************************************************
            cmdTxtUp.Enabled = False                    'ｺﾒﾝﾄ頁UP
            cmdTxtDown.Enabled = False                  'ｺﾒﾝﾄ頁DOWN
            cmdMemoUp.Enabled = False                   '作業ﾒﾓ頁UP
            cmdMemoDown.Enabled = False                 '作業ﾒﾓ頁DOWN
        '@↑2005/12/02 (Fri) 10:06:05 N.Kasai **************************************************
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化（使用不可）
            Call prvfrmxxEN00R0_CmbInit(False)

            '@ｷｬﾘｱIDのｸﾘｱ
            txtCarrier.Text = vbNullString

            '@閉じるボタンへCausesValidationを設定する
            cmdClose.CausesValidation = False

            '@ｺﾝﾎﾞ設定
            cmbPort.RowHeight = CMlngRowHeight
            cmbPort.ColAlignment(0) = TextAlignEnum.LeftCenter

            '@Form_Loadﾌﾗｸﾞ（正常）
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
    '作成日：2004/08/03 (Tue) 15:59:09 T.Kitagawa
    '更新日：2004/08/03 (Tue) 15:59:09
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

            '@引継ぎ情報表示済みﾌﾗｸﾞにTrueを設定する
            mblnTakeOverDispFlg = True

            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose

            '@引数のキャリアIDが空白かどうか判定する
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@空白でない場合
                '@ｷｬﾘｱIDの初期値を設定する
                txtCarrier.Text = ptypCommonInfo.strCarrierId

                '@ｷｬﾘｱ情報を取得する
                RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
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

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑのKeyDown
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/08/03 (Tue) 16:01:43 T.Kitagawa
    '更新日：2004/08/03 (Tue) 16:01:43
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
                            RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                            Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                            AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                            
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
    '作成日：2004/08/03 (Tue) 16:53:38 T.Kitagawa
    '更新日：2004/11/01 (Mon) 16:19:50 N.Kasai
    '備　考：
    '　　　：2004/11/01 (Mon) 16:19:50 N.Kasai      閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs())
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If

            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化（装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要）
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

    '関数名：cmdClose_Click
    '機　能：ﾌﾟﾛｸﾞﾗﾑ終了
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/03 (Tue) 16:02:39 T.Kitagawa
    '更新日：2005/02/15 (Tue) 13:25:37 N.Kojima
    '備　考：
    '　　　：2005/02/15 (Tue) 13:25:37 N.Kojima     戻り先画面の判定を追加(改善№512)
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
                Call publngEnd_Proc(CPstrKeyEN00R0, ltypCommonInfo)
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

    '関数名：cmdCommntInput_Click
    '機　能：ﾛｯﾄｺﾒﾝﾄ入力ﾌｫｰﾑ表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/03 (Tue) 16:05:46 T.Kitagawa
    '更新日：2008/06/11 (Wed) 13:10:05 N.Kojima
    '備　考：
    '　　　：2005/10/26 (Wed) 08:46:12 S.Deguchi    不具合№2404の対応で,画面引継処理を修正
    '　　　：2008/06/11 (Wed) 13:10:05 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
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
                .strLotID = mtypLotprestate.strLotID                        'ﾛｯﾄID
                .strFlowClass = mtypLotprestate.strFlowClass                '種別
                .strWfNum = mtypLotprestate.strWfNum                        'WF枚数
                .strOpID = mtypLotprestate.strOpID                          '大工程
                .strStartTime = mtypLotprestate.strStartTime                '処理開始日時
                .strPdId = mtypLotprestate.strPdId                          '機種
                .strSpecialFlg = mtypLotprestate.strSpecialFlg              '特殊特性
                .strNowST = mtypLotprestate.strNowST                        '現在状態
                .strStepID = mtypLotprestate.strStepID                      '小工程
                .strEngEmpName = mtypLotprestate.strEngEmpName              'ﾛｯﾄ担当者
                .strLimitTime = mtypLotprestate.strLimitTime                '時間制限
                .strComments = txtLotCommnt.Text                            'ﾛｯﾄｺﾒﾝﾄ
                .strLotLastUpdate = mtypLotprestate.strLotLastUpdate        '最終更新日時

                pstrCarrierID = txtCarrier.Text                             'ｷｬﾘｱID

        '@↓2005/10/25 (Tue) 17:34:04 S.Deguchi **************************************************
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
                    mtypLotprestate.strLotLastUpdate = ptypLotprestate.strLotLastUpdate
                Else
                    '@ｱﾝﾛｰﾄﾞする
                    frmxxCM0030.Instance = Nothing
                
                    '@起動ﾌﾗｸﾞを戻す
                    pblnFormLoad = True
                    
                    Exit Sub
                End If
        '@↑2005/10/25 (Tue) 17:34:04 S.Deguchi **************************************************

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

    '関数名：cmdLoad_Click
    '機　能：Load/Unload処理
    '引　数：Index：0(Load処理)、1(Unload処理）
    '戻り値：なし
    '作成日：2004/08/03 (Tue) 16:09:17 T.Kitagawa
    '更新日：2005/04/19 (Tue) 13:11:53 N.Kojima
    '備　考：
    '　　　：2005/04/19 (Tue) 13:11:53 N.Kojima     関数名称修正
    Private Sub cmdLoad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLoad0.Click, cmdLoad1.Click

        Dim lblnInputCheck          As Boolean              '画面入力ﾁｪｯｸ(True:正常,False:異常)
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypDumyChgState        As DumyChgState         'ﾀﾞﾐｰｶｾｯﾄﾛｰﾄﾞ/ｱﾝﾛｰﾄﾞ構造体
        Dim lstrFormName            As String               'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim Index                   As Integer              'NSYS クリックしたボタンのインデックスを取得

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

            If sender Is cmdLoad0 Then
                Index = 0
            Else
                Index = 1
            End If

            '@画面入力ﾁｪｯｸ
            lblnInputCheck = prvblnInput_Check(Index)
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
            Select Case Index
                '@Load（0）
                Case CMlngcmdLoadIndex
                    lstrEventName = CMstrcmdLoad_Click
                    
                '@Unload（1）
                Case CMlngcmdUnloadIndex
                    lstrEventName = CMstrcmdUnLoad_Click
            End Select
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@Load/Unload開始ﾃﾞｰﾀ格納
            With ltypDumyChgState
                .strCarrierId = txtCarrier.Text                         'ｷｬﾘｱID
                
                '@ｷｬﾘｱ状態ﾌﾗｸﾞ
                Select Case Index
                    '@Load（0）
                    Case CMlngcmdLoadIndex
                        .strCarrierStateFlg = Trim$(str$(CMlngcmdLoadIndex))
                    '@Unload（1）
                    Case CMlngcmdUnloadIndex
                        .strCarrierStateFlg = Trim$(str$(CMlngcmdUnloadIndex))
                End Select
                
                .strOpID = lblOpID.Text                                 '大工程ID
                .strStepID = lblStepID.Text                             '小工程ID
                .strWpID = mtypLotprestate.strWpID                      'WPID
                
                '@ﾎﾟｰﾄIDの未選択対応
                If cmbPort.Value <> vbNullString Then
                    .strPortID = cmbPort.Value
                Else
                    .strPortID = vbNullString
                End If
                
                .strEmpID = pstrUserID                                  '作業者ID
                
                '@作業ﾒﾓ
                If txtWorkMemo.Text <> vbNullString Then
                    .strComment = txtWorkMemo.Text
                Else
                    .strComment = vbNullString
                End If
                
                .strLotLastUpdate = mtypLotprestate.strLotLastUpdate    'LOT最終更新日時
            End With

            '@ﾒｯｾｰｼﾞ送信処理呼び出し
            lblnAns = pubblnDumyChgState_Upd(CMstrdumychgstateVer, _
                                             pstrSBID, _
                                             CPstrCD01, _
                                             ltypDumyChgState)
            '@結果判定
            If lblnAns = True Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf000Q, txtCarrier.Text, lblLotID.Text, sender.Text)
                '@pubVsfInfo_Disp("メッセージコード：<TRM0QI>$$%3しました。キャリア[ %1 ] ロット[ %2 ]")
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@ｷｬﾘｱIDのｸﾘｱ
                txtCarrier.Text = vbNullString
                
                '@ﾛｯﾄ情報の初期化
                Call prvfrmxxEN00R0_Init()
                
                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化（使用不可）
                Call prvfrmxxEN00R0_CmbInit(False)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)

            '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrier)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdLoad_Click"
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
    '作成日：2004/08/03 (Tue) 16:54:46 T.Kitagawa
    '更新日：2004/08/03 (Tue) 16:54:46
    '備　考：
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change

        Try
            '@ﾛｯﾄ情報の初期化
            Call prvfrmxxEN00R0_Init()

            '@ﾎﾞﾀﾝ状態
            Call prvfrmxxEN00R0_CmbInit(False)

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
    '作成日：2004/08/03 (Tue) 16:55:43 T.Kitagawa
    '更新日：2005/12/02 (Fri) 09:51:43 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 09:51:43 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change
        
        Dim llngNowByte As Integer 'ﾊﾞｲﾄ数

        Try
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtWorkMemo.NowByte

            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            
        '@↓2005/12/02 (Fri) 09:52:34 N.Kasai **************************************************
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
        '@↑2005/12/02 (Fri) 09:52:34 N.Kasai **************************************************

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
    '作成日：2004/08/03 (Tue) 16:56:13 T.Kitagawa
    '更新日：2005/12/02 (Fri) 09:50:11 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 09:50:11 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdMemoUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/02 (Fri) 09:50:08 N.Kasai **************************************************
        '    '@作業メモにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtWorkMemo)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
        '@↑2005/12/02 (Fri) 09:50:08 N.Kasai **************************************************

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
    '作成日：2004/08/03 (Tue) 16:56:40 T.Kitagawa
    '更新日：2005/12/02 (Fri) 09:51:05 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 09:51:05 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdMemoDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/02 (Fri) 09:51:00 N.Kasai **************************************************
        '    '@作業メモにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtWorkMemo)
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
        '@↑2005/12/02 (Fri) 09:51:00 N.Kasai **************************************************

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

    '関数名：cmbPort_CloseUp
    '機　能：ポート№選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/03 (Tue) 16:57:08 T.Kitagawa
    '更新日：2004/08/03 (Tue) 16:57:08
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
                .strMenuKey = CMstrLocalMenuKey
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
    '作成日：2004/08/03 (Tue) 16:58:01 T.Kitagawa
    '更新日：2004/08/03 (Tue) 16:58:01
    '備　考：
    Private Sub cmbPort_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPort.Change

        Try
            With cmbPort
                '@ﾎﾟｰﾄIDが選択されている場合
                If cmbPort.Text <> vbNullString Then
                    '@Loadﾎﾞﾀﾝ有効
                    cmdLoad0.Enabled = True
                Else
                    '@Loadﾎﾞﾀﾝ無効
                    cmdLoad0.Enabled = False
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPort_Change"
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
    '作成日：2004/08/03 (Tue) 16:59:53 T.Kitagawa
    '更新日：2004/08/03 (Tue) 16:59:53
    '備　考：
    Private Sub cmdTxtUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/02 (Fri) 09:55:04 N.Kasai **************************************************
        '    '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtLotCommnt)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtLotCommnt, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
        '@↑2005/12/02 (Fri) 09:55:04 N.Kasai **************************************************

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
    '作成日：2004/08/03 (Tue) 17:00:31 T.Kitagawa
    '更新日：2004/08/03 (Tue) 17:00:31
    '備　考：
    Private Sub cmdTxtDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/12/02 (Fri) 09:55:40 N.Kasai **************************************************
        '    '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtLotCommnt)
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtLotCommnt, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
        '@↑2005/12/02 (Fri) 09:55:40 N.Kasai **************************************************

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

    '関数名：txtCarrier_Validate
    '機　能：ｷｬﾘｱ情報取得
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/03 (Tue) 17:01:24 T.Kitagawa
    '更新日：2005/04/21 (Thu) 11:29:40 N.Kojima
    '備　考：
    '　　　：2005/04/21 (Thu) 11:29:40 N.Kojima     ﾊﾞｯﾁS1運用対応(再投入ﾎﾞﾀﾝの制御追加、Unloadﾎﾞﾀﾝの制御修正)
    Public Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim ltypLotWpList           As LotWpList            'ﾛｯﾄ装置情報構造体
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrFormName            As String               'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｷｬﾘｱIDの空白ﾁｪｯｸ
            If Trim(txtCarrier.Text) = vbNullString Then
                If ActiveControl.Name = txtCarrier.Name Then
                    '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
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
                
                '@ﾌｫｰｶｽそのまま
                e.Cancel = True
                
                If ActiveControl.Name = txtCarrier.Name Then
                    '@ﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(txtCarrier)
                End If
                
                Exit Sub
            End If

            '@ｷｬﾘｱID情報の取得(入力ｷｬﾘｱIDと前回のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功)と違う場合のみ実行）
            If Trim(txtCarrier.Text) <> vbNullString And _
                Len(Trim(txtCarrier.Text)) = CMlngCarrierMaxLength And _
                txtCarrier.Text <> mstrCarrier Then
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                lstrFormName = Me.Name
                lstrEventName = "txtCarrier_Validate"
                Call pubResponseStart(lstrFormName, lstrEventName)
                
                '@ﾛｯﾄ情報の初期化
                Call prvfrmxxEN00R0_Init()
                
                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化（使用不可）
                Call prvfrmxxEN00R0_CmbInit(False)
                
                '@ﾛｯﾄ現在情報取得
                lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, CPstrCD1I, txtCarrier.Text, mtypLotprestate)
                '@結果判定
                If lblnAns = True Then
                    '@画面表示処理
                    Call prvfrmxxEN00R0_Disp()
                Else
                    '@ﾌｫｰｶｽそのまま
                    e.Cancel = True
                    
                    '@失敗の場合ﾚｽﾎﾟﾝｽ測定中止
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    Exit Sub
                End If

                With mtypLotprestate
                    '@ﾛｯﾄ状態が「後処理」ではない場合
                    If .strNowST <> CPstrAfterProgressSt Then
                        '@ﾛｯﾄ装置情報取得
                        lblnAns = pubblnLotWplist_Sel(CMstrlot_wplist__Ver, _
                                                      CPstrCD1I, _
                                                      lblLotID.Text, _
                                                      .strOpID, _
                                                      .strStepID, _
                                                      .strAltNumber, _
                                                      ltypLotWpList)
                    End If
                End With
                
                '@結果判定
                If lblnAns = True Then
                    '@装置&ﾎﾟｰﾄ情報設定処理
                    Call prvWPPort_Set(ltypLotWpList)
                Else
                    '@失敗の場合ﾚｽﾎﾟﾝｽ測定中止
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化（使用不可）
                    Call prvfrmxxEN00R0_CmbInit(False)
                    
                    '@ﾌｫｰｶｽそのまま
                    e.Cancel = True
                    
                    Exit Sub
                End If

                '@ｷｬﾘｱID退避
                mstrCarrier = txtCarrier.Text
                
                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化（使用可）
                Call prvfrmxxEN00R0_CmbInit(True)
                
                '@ﾎﾟｰﾄｺﾝﾎﾞBOXとLOAD/UNLOADﾎﾞﾀﾝの制御
                cmbPort.Enabled = False                                     'ﾎﾟｰﾄｺﾝﾎﾞBOX無効（初期）
                cmdLoad0.Enabled = False                                    'LOADﾎﾞﾀﾝ無効（初期）
                cmdLoad1.Enabled = False                                    'UNLOADﾎﾞﾀﾝ無効（初期）
                cmdRethrowin.Enabled = False                                '再投入ﾎﾞﾀﾝ無効（初期）

                '@現在状態からｺﾝﾄﾛｰﾙの活性・非活性を設定する
                Select Case mtypLotprestate.strNowST
                    '@前処理の場合
                    Case CPstrBeforeProgressSt
                        '@ﾎﾟｰﾄｺﾝﾎﾞﾎﾞｯｸｽ設定：有効
                        cmbPort.Enabled = True
                        
                        '@ﾎﾟｰﾄが1件か否かで処理分岐
                        If cmbPort.ListCount = 1 Then
                        '@ﾎﾟｰﾄが1件の場合
                            '@Loadﾎﾞﾀﾝ有効
                            cmdLoad0.Enabled = True
                        Else
                        '@ﾎﾟｰﾄが複数の場合
                            If ActiveControl.Name = txtCarrier.Name Then
                                '@ﾎﾟｰﾄｺﾝﾎﾞﾎﾞｯｸｽへﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(cmbPort)
                            End If
                        End If
                        
                    '@LOAD中の場合
                    Case CPstrLoadSt
                        '@UNLOADﾎﾞﾀﾝ有効
                        cmdLoad1.Enabled = True
                    
                    '@後処理の場合
                    Case CPstrAfterProgressSt
                        '@Load,Unloadﾎﾞﾀﾝ無効
                        cmdLoad0.Enabled = False
                        cmdLoad1.Enabled = False
                        
                        '@再投入ﾎﾞﾀﾝを有効に
                        cmdRethrowin.Enabled = True
                End Select
                
                '@ﾚｽﾎﾟﾝｽ測定終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            End If
            
            '@ﾌｫｰｶｽ制御
            Select Case lblStatus.Text
                '@前処理の場合
                Case CPstrBeforeProgressSt
                    If cmbPort.ListCount = 1 Then
                        '@ﾎﾟｰﾄが１件の場合
                        If cmdLoad0.Enabled = True Then
                            If ActiveControl.Name = txtCarrier.Name Then
                                '@Loadﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(cmdLoad0)
                            End If
                        End If
                    Else
                        '@ﾎﾟｰﾄが複数の場合
                        If cmbPort.Enabled = True Then
                            If ActiveControl.Name = txtCarrier.Name Then
                                '@ﾎﾟｰﾄｺﾝﾎﾞﾎﾞｯｸｽへﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(cmbPort)
                            End If
                        End If
                    End If
                    
                '@LOAD中の場合
                Case CPstrLoadSt
                    '@ﾎﾟｰﾄが１件の場合
                    If cmdLoad1.Enabled = True Then
                        If ActiveControl.Name = txtCarrier.Name Then
                            '@Unloadﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdLoad1)
                        End If
                    End If

                '@後処理の場合
                Case CPstrAfterProgressSt
                    '@再投入ﾎﾞﾀﾝが有効か
                    If cmdRethrowin.Enabled = True Then
                        If ActiveControl.Name = txtCarrier.Name Then
                            '@再投入ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdRethrowin)
                        End If
                    End If
            End Select

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

    '関数名：cmdRethrowin_Click
    '機　能：再投入処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/04/18 (Mon) 19:15:34 N.Kojima
    '更新日：2005/04/18 (Mon) 19:15:34
    '備　考：
    Private Sub cmdRethrowin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRethrowin.Click

        Dim lblnInputCheck          As Boolean              '画面入力ﾁｪｯｸ(True:正常,False:異常)
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypDumyChgState        As DumyChgState         'ﾀﾞﾐｰｶｾｯﾄﾛｰﾄﾞ/ｱﾝﾛｰﾄﾞ構造体
        Dim lstrFormName            As String               'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）

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
            
            '@画面入力ﾁｪｯｸ(引数はLoad/Unloadﾎﾞﾀﾝ以外=2)
            lblnInputCheck = prvblnInput_Check(CMlngcmdRethrowin)
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
            lstrEventName = CMstrcmdRethrowin_Click
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@Load/Unload開始ﾃﾞｰﾀ格納
            With ltypDumyChgState
                .strCarrierId = txtCarrier.Text                         'ｷｬﾘｱID
                .strCarrierStateFlg = CMstrRethrowin                    'ｷｬﾘｱ状態ﾌﾗｸﾞ
                .strOpID = lblOpID.Text                                 '大工程ID
                .strStepID = lblStepID.Text                             '小工程ID
                .strWpID = mtypLotprestate.strWpID                      'WPID
                
                '@ﾎﾟｰﾄIDの未選択対応
                If cmbPort.Value <> vbNullString Then
                    .strPortID = cmbPort.Value
                Else
                    .strPortID = vbNullString
                End If
                
                .strEmpID = pstrUserID                                  '作業者ID
                .strLotLastUpdate = mtypLotprestate.strLotLastUpdate    'LOT最終更新日時
                
                '@作業ﾒﾓ
                If txtWorkMemo.Text <> vbNullString Then
                    .strComment = txtWorkMemo.Text
                Else
                    .strComment = vbNullString
                End If
            End With

            '@ﾒｯｾｰｼﾞ送信処理呼び出し
            lblnAns = pubblnDumyChgState_Upd(CMstrdumychgstateVer, _
                                             pstrSBID, _
                                             CPstrCD01, _
                                             ltypDumyChgState)
            '@結果判定
            If lblnAns = True Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf004O, txtCarrier.Text)
                '@pubVsfInfo_Disp("ﾒｯｾｰｼﾞｺｰﾄﾞ：<TRM4OI>再投入しました。ダミーキャリア[%1]")
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@ｷｬﾘｱIDのｸﾘｱ
                txtCarrier.Text = vbNullString
                
                '@ﾛｯﾄ情報の初期化
                Call prvfrmxxEN00R0_Init()
                
                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化（使用不可）
                Call prvfrmxxEN00R0_CmbInit(False)
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
            End If

            '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrier)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRethrowin_Click"
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
    '関数名：prvfrmxxEN00R0_Init
    '機　能：ｷｬﾘｱ情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/03 (Tue) 17:37:00 T.Kitagawa
    '更新日：2004/10/04 (Mon) 13:35:05 H.Wajima
    '備　考：
    '　　　：2004/10/04 (Mon) 13:35:05 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    Private Sub prvfrmxxEN00R0_Init()
        
        Dim lstrFormTitle   As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00R0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@各ｺﾝﾄﾛｰﾙの初期化
            lblLotID.Text = vbNullString                                'ﾛｯﾄID
            lblFlowClass.Text = vbNullString                            '流動区分
            lblWFNo.Text = vbNullString                                 'WF枚数
            lblStatus.Text = vbNullString                               '状態
            lblOpID.Text = vbNullString                                 '大工程ID
            lblStepID.Text = vbNullString                               '小工程ID
            lblWP.Text = vbNullString                                   'WP名
            txtOpeCond.Text = vbNullString                              '作業条件
            txtOpeCond.MultiLineEx = True                               '作業条件複数行表示
            txtLotCommnt.Text = vbNullString                            'ﾛｯﾄｺﾒﾝﾄ
            txtLotCommnt.MultiLineEx = True                             'ﾛｯﾄｺﾒﾝﾄ複数行表示
            
            mstrCarrier = vbNullString                                  'ｷｬﾘｱID(ﾒｯｾｰｼﾞ成功時のｷｬﾘｱID)
            
            '@ﾛｯﾄ情報格納構造体の初期化
            With mtypLotprestate
                .strLotID = vbNullString                                'ﾛｯﾄID
                .strFlowClass = vbNullString                            '流動区分
                .strWfNum = vbNullString                                'WF枚数
                .strNowST = vbNullString                                '状態
                .strOpID = vbNullString                                 '大工程ID
                .strStepID = vbNullString                               '小工程ID
                .strWpID = vbNullString                                 'WPID
                .strWpName = vbNullString                               'WP名
                .strWorkCondition = vbNullString                        '作業条件
                .strComments = vbNullString                             'ﾛｯﾄｺﾒﾝﾄ
                .strStartTime = vbNullString                            '作業開始日時
                .strSpecialFlg = vbNullString                           '特殊特性
                .strEngEmpName = vbNullString                           '作業者名
                .strLimitTime = vbNullString                            '時間制限
                .strLotLastUpdate = vbNullString                        'ﾛｯﾄ最終更新日時
                .strAltNumber = vbNullString                            '代替工程番号
            End With
            
            '@ﾎﾟｰﾄ№ｺﾝﾎﾞ設定
            With cmbPort
                .Clear
                '@ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄに設定
                .DirectInput = False
                '@ﾘｽﾄの高さ設定
                .RowHeight = CPlngCmbRowHeight
                '@Value列設定（ﾎﾟｰﾄID）
                .ValueCol = CMlngcmbPortID
                '@表示列数
                .DispCols = CMlngDispCols
            End With

            '@作業ﾒﾓﾊﾞｲﾄ数初期化
            With txtWorkMemo
                .ChrMaxByte = CPlngLotCommentsMaxByte
                .Text = vbNullString
                Call txtWorkMemo_Change(txtWorkMemo, New EventArgs())
            End With

            '@ﾛｯﾄｺﾒﾝﾄﾊﾞｲﾄ数初期化
            With txtLotCommnt
                .ChrMaxByte = CPlngLotCommentsMaxByte
                .Text = vbNullString
            End With

            '@作業条件設定
            With txtOpeCond
                '@背景色（ｸﾞﾚｰ）
                .BackColor = SystemColors.ControlLight
                .GotBackColor = SystemColors.ControlLight
                '@ﾛｯｸ
                .Locked = True
            End With

            '@ﾛｯﾄｺﾒﾝﾄ設定
            With txtLotCommnt
                '@背景色（ｸﾞﾚｰ）
                .BackColor = SystemColors.ControlLight
                .GotBackColor = SystemColors.ControlLight
                '@ﾛｯｸ
                .Locked = True
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN00R0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN00R0_CmbInit
    '機　能：各ｺﾏﾝﾄﾞﾎﾞﾀﾝの制御
    '引　数：lblnEnable：True:使用可能,False:使用不可
    '戻り値：なし
    '作成日：2004/08/03 (Tue) 17:38:48 T.Kitagawa
    '更新日：2005/12/02 (Fri) 10:04:18 N.Kasai
    '備　考：
    '　　　：2005/04/18 (Mon) 19:39:12 N.Kojima     ﾊﾞｯﾁS1運用対応(再投入ﾎﾞﾀﾝの制御追加)
    '　　　：2005/12/02 (Fri) 10:04:18 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub prvfrmxxEN00R0_CmbInit(Optional ByVal lblnEnable As Boolean = False)

        Try

            '@各ｺﾏﾝﾄﾞﾎﾞﾀﾝのｺﾝﾄﾛｰﾙ
            cmbPort.Enabled = lblnEnable                        'ﾎﾟｰﾄNo
            cmdCommntInput.Enabled = lblnEnable                 'ﾛｯﾄｺﾒﾝﾄ入力
            txtOpeCond.Enabled = lblnEnable                     '作業条件
            txtLotCommnt.Enabled = lblnEnable                   'ｺﾒﾝﾄ
            txtWorkMemo.Enabled = lblnEnable                    '作業ﾒﾓ

        '@↓2005/12/02 (Fri) 10:04:15 N.Kasai **************************************************
        '    cmdTxtUp.Enabled = lblnEnable                       'ｺﾒﾝﾄ頁UP
        '    cmdTxtDown.Enabled = lblnEnable                     'ｺﾒﾝﾄ頁DOWN
        '    cmdMemoUp.Enabled = lblnEnable                      '作業ﾒﾓ頁UP
        '    cmdMemoDown.Enabled = lblnEnable                    '作業ﾒﾓ頁DOWN
        '@↑2005/12/02 (Fri) 10:04:15 N.Kasai **************************************************

            cmdLoad0.Enabled = lblnEnable                       'LOADﾎﾞﾀﾝ
            cmdLoad1.Enabled = lblnEnable                       'UNLOADﾎﾞﾀﾝ
            cmdRethrowin.Enabled = lblnEnable                   '再投入ﾎﾞﾀﾝ

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN00R0_CmbInit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN00R0_Disp
    '機　能：画面の表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/03 (Tue) 17:40:56 T.Kitagawa
    '更新日：2005/05/26 (Thu) 15:09:10 N.Kasai
    '備　考：
    '　　　：2004/08/25 (Wed) 14:10:28 N.Kasai      CFﾌﾗｸﾞの判定追加
    '　　　：2004/09/14 (Tue) 10:28:44 N.Kojima　   数量表示(TPALﾛｯﾄ対応)修正(不具合改善№730)
    '　　　：2005/04/21 (Thu) 11:21:16 N.Kojima     ﾊﾞｯﾁS1運用対応(ﾛｯﾄ状態が「後処理」の場合、ﾛｯﾄ現在状態取得Msgで取得した装置名を入れる)
    '　　　：2005/05/26 (Thu) 15:09:10 N.Kasai      LP_FLAG判定追加
    Private Sub prvfrmxxEN00R0_Disp()
        
        Try

            '@ﾛｯﾄ情報の表示
            With mtypLotprestate
                lblLotID.Text = .strLotID                                        'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass                                '流動区分
                lblStatus.Text = .strNowST                                       '状態
                lblOpID.Text = .strOpID                                          '大工程ID
                lblStepID.Text = .strStepID                                      '小工程ID
                txtOpeCond.Text = .strWorkCondition                              '作業条件
                txtLotCommnt.Text = .strComments                                 'ﾛｯﾄｺﾒﾝﾄ
                
                '@ﾛｯﾄ状態が「後処理」の場合
                If .strNowST = CPstrAfterProgressSt Then
                    '@装置名を格納
                    lblWP.Text = .strWpName
                End If
                
                '@枚数表示判定（CF_FLAGを判定し、WF枚数とﾁｯﾌﾟ枚数の表示を切替）
                Select Case .strCfFlag
                    '@CFﾛｯﾄ
                    Case CPstrCF
                        '@大判ﾌﾗｸﾞ判定(LP_FLAG)
                        If .strLpFlag = CPstrLP Then
                            '@大判の場合
                            lblWFNo.Text = .strWfNum                                                'WF枚数
                        Else
                            If IsNumeric(.strChipQuantity) Then
                                lblWFNo.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)   'ﾁｯﾌﾟ枚数
                            Else
                                lblWFNo.Text = .strChipQuantity
                            End If
                        End If

                    '@CFﾛｯﾄ以外
                    Case Else
                        '@TPALﾛｯﾄ
                        If Trim(Strings.Left(.strLotID, 2)) = CPstrTpalLot Then
                            If IsNumeric(.strChipQuantity) Then
                                lblWFNo.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)   'ﾁｯﾌﾟ枚数
                            Else
                                lblWFNo.Text = .strChipQuantity
                            End If
                        Else
                            '@CF,TPALﾛｯﾄ以外
                            lblWFNo.Text = .strWfNum                                                'WF枚数
                        End If
                End Select
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN00R0_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvWPPort_Set
    '機　能：装置&ﾎﾟｰﾄ情報設定処理
    '引　数：ltypLotWpList：ﾛｯﾄ装置情報構造体
    '戻り値：なし
    '作成日：2004/08/04 (Wed) 11:13:14 T.Kitagawa
    '更新日：2004/08/04 (Wed) 11:13:14
    '備　考：
    Private Sub prvWPPort_Set(ByRef ltypLotWpList As LotWpList)

        Dim llngCnt             As Integer      'ｶｳﾝﾀ変数
        Dim llngWPIndex         As Integer      '装置情報ｲﾝﾃﾞｯｸｽ

        Try

            '@装置件数の確認（必ず１件）
            If ltypLotWpList.lngWPCnt <= 0 Then
                Exit Sub
            End If
            
            '@装置名設定（必ず１件）
            llngWPIndex = 0
            With ltypLotWpList.typWpList(llngWPIndex)
                lblWP.Text = .strWpName           'WP名
                pstrWPID = .strWpID               'WPID
                pstrWPName = .strWpName           'WP名
            End With
            
            '@ﾎﾟｰﾄｺﾝﾎﾞBOXへｾｯﾄ
            cmbPort.Clear
            With ltypLotWpList.typWpList(llngWPIndex)
                For llngCnt = 0 To .lngPortCnt - 1
                    With .typPortList(llngCnt)
                        cmbPort.AddItem(.strPortName & vbTab & .strPortStatus & vbTab & .strPortID)
                    End With
                Next llngCnt
            End With

            '@ﾎﾟｰﾄが1個の場合は初期表示し、複数の場合はﾃﾞﾌｫﾙﾄ表示しない
            If cmbPort.ListCount = 1 Then
                cmbPort.ListIndex = 0
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvWPPort_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnInput_Check
    '機　能：LOAD/UNLOADﾎﾞﾀﾝの入力ﾁｪｯｸ
    '引　数：lintCmdLoadIndex：LOAD時(0)、UNLOAD時(1)
    '戻り値：True：項目正常、False：不正項目あり
    '作成日：2004/08/04 (Wed) 12:07:33 T.Kitagawa
    '更新日：2004/08/04 (Wed) 12:07:33
    '備　考：
    Private Function prvblnInput_Check(ByRef lintCmdLoadIndex As Short) As Boolean

        Try

            '@初期化
            prvblnInput_Check = False

            '@ｷｬﾘｱIDの入力ﾁｪｯｸ
            If txtCarrier.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                '@失敗ﾒｯｾｰｼﾞ表示("キャリアIDが設定されていません。設定を見直してください。")
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@ｷｬﾘｱID欄にﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                
                Exit Function
            End If
            
            '@ｷｬﾘｱIDの桁数ﾁｪｯｸ
            If Len(txtCarrier.Text) <> CMlngCarrierMaxLength Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱID欄にﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                
                Exit Function
            End If

            '@LOADの場合はﾎﾟｰﾄ入力ﾁｪｯｸ
            If lintCmdLoadIndex = CMlngcmdLoadIndex Then
                '@ﾎﾟｰﾄがある場合
                If cmbPort.Enabled = True Then
                    If cmbPort.Value = vbNullString Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0029)
                        
                        '@"ポート№が設定されていません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ﾎﾟｰﾄにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmbPort)
                        
                        Exit Function
                    End If
                End If
            End If
            
            '@入力OK
            prvblnInput_Check = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnInput_Check"
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
