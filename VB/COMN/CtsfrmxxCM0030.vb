'ﾌｧｲﾙ名：CtsfrmxxCM0030.vb
'説　明：ロットコメント　メインフォーム
'作成日：2004/03/10 (Wed) 21:01:19 T.Oide
'更新日：2026/03/12 (Thu) 15:42:00 T.Oide
'備　考：メニュー起動：xxCM0070.bas 　　　　　　　が必要。
'　　　：単独起動　　：xxCM0070.bas xxEN0140.bas が必要。
'Copyright(C) SEIKO EPSON CORPORATION 2003-2026, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM0030
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM0030    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM0030
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM0030
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM0030)
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
    'Private Const CMstrLocalVersion             As String = "05.00"             '機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion             As String = "05.01"             '機能ﾊﾞｰｼﾞｮﾝ


    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN0140      'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrlot_curstateVer          As String = "04.00"             'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_chgcmmentVer         As String = "01.00"             'ﾛｯﾄｺﾒﾝﾄ登録

    '@定数宣言
    Private Const CMlngMaxDispRow               As Integer = 19                 'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mstrCarrier                         As String                       'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mstrLotLastUpdate                   As String                       'ﾛｯﾄ最終更新日時
    Private mblnTakeOverDispFlg                 As Boolean                      '引継ぎ表示ﾌﾗｸﾞ
    Private buttonProcessing                    As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                      'NSYS WindowCloseフラグ
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
    '機　能：メイン画面から引き継いだ情報を表示する
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/10 (Wed) 21:01:59 T.Oide
    '更新日：2007/07/12 (Thu) 10:24:10 N.Kasai
    '備　考：
    '　　　：2005/10/25 (Tue) 09:44:16 S.Deguchi    不具合№2404の対応で機能ﾊﾞｰｼﾞｮﾝ判定処理修正
    '　　　：2005/11/17 (Thu) 11:27:42 N.Kasai      ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    '　　　：2007/07/12 (Thu) 10:24:10 N.Kasai      ｿｰｽ整備
    Private Sub Form_Load()

        Dim lblnAns         As Boolean      '戻り値

        Try
                
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
                
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN0140, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ位置を設定
            Me.Top = 0
            Me.Left = 0 - My.Settings.FormOffset
            
            '@画面の初期化
            Call prvfrmxxCM0030_Init()
            
            '@ﾎﾞﾀﾝ状態(使用不可)
            cmdRegist.Enabled = False
                
            '@ﾌｫｰﾑ起動区分処理
            If pblnfrmxxCM0030Kbn = True Then
                '@親ﾌｫｰﾑから呼ばれた場合
                '@基本情報表示
                Call prvfrmxxCM0030_Set()
                
                '@ｷｬﾘｱIDの設定
                With txtCarrier
                    .Locked = True                            'ｷｬﾘｱIDﾛｯｸ
                    .BackColor = SystemColors.ControlLight    'ｷｬﾘｱIDﾊﾞｯｸｶﾗｰ
                    .GotBackColor = SystemColors.ControlLight 'ｷｬﾘｱIDﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰ
                End With
                
                '@ﾛｯﾄｺﾒﾝﾄ使用可
                txtLotCommnt.Enabled = True
                
                '@ﾎﾞﾀﾝ状態(使用可)
                cmdRegist.Enabled = True
                
                '@Form_Loadﾌﾗｸﾞ(正常)
                pblnFormLoad = True
                
                '@引継ぎ情報表示済みﾌﾗｸﾞ
                mblnTakeOverDispFlg = True
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            Else
                '@単独起動の場合
                '@ｷｬﾘｱ入力可能処理
                Call prvtxtCarrier_Init()
            
                '@Form_Loadﾌﾗｸﾞ(正常)
                pblnFormLoad = True
                
                '@引継ぎ情報表示済みﾌﾗｸﾞ
                mblnTakeOverDispFlg = False
            
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
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
    '作成日：2004/07/27 (Tue) 16:18:36 H.Wajima
    '更新日：2004/07/27 (Tue) 16:18:36
    '備　考：
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

            '@引数のｷｬﾘｱIDが空白かどうか判定する
            If ptypCommonInfo.strCarrierId <> vbNullString Then
            '@空白でない場合
                '@ｷｬﾘｱIDの初期値を設定する
                txtCarrier.Text = ptypCommonInfo.strCarrierId
                
                '@ｷｬﾘｱ情報を取得する
                Call Form_KeyDown(Me, New KeyEventArgs(Keys.Return))

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
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_Activate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｸｴﾘｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel    ：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 15:51:05 Y.Yamagishi
    '更新日：2004/11/01 (Mon) 14:55:30 N.Kasai
    '備　考：2004/11/01 (Mon) 14:55:30 N.Kasai  閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs())
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@ﾌｫｰﾑ起動区分の確認
            If pblnfrmxxCM0030Kbn = True Then
                '@ﾌｫｰﾑ起動区分を初期化
                pblnfrmxxCM0030Kbn = False
            Else
                '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
                pblnFormLoad = False
                
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
    '機　能：閉じる
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 15:51:05 Y.Yamagishi
    '更新日：2007/07/12 (Thu) 11:16:51 N.Kasai
    '備　考：2005/02/15 (Tue) 13:25:37 N.Kojima 戻り先画面の判定を追加(改善№512)
    '　　　：2007/07/12 (Thu) 11:16:51 N.Kasai  親画面引継ぎ機能
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

            '@起動判定
            If pblnfrmxxCM0030Kbn = True Then
                '@ｱﾝﾛｰﾄﾞ
                Me.Close()
            Else
                '@引継ぎ情報のｷｬﾘｱIDが空白かどうか判定する
                If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@空白でない場合
                    '@親ﾌｫｰﾑから呼ばれた場合
                    '@親画面切り替え引継ぎ制御
                    Call pubChangeScreen_Set(Me)
                Else
                '@空白の場合
                    '@終了関数を実行する
                    Call publngEnd_Proc(CPstrKeyEN0140, ltypCommonInfoDummy)
                End If
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
    '機　能：確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 10:58:09 Y.Yamagishi
    '更新日：2004/05/26 (Wed) 18:20:17 S.Deguchi
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnInputCheck          As Boolean              '画面入力ﾁｪｯｸ(True:正常,False:異常)
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)

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
            lblnInputCheck = prvblnInput_Chk()
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
            
            '@ﾌｫｰﾑ起動区分処理
            If pblnfrmxxCM0030Kbn = True Then
                '@最終更新日時を設定
                mstrLotLastUpdate = ptypLotprestate.strLotLastUpdate
            End If
            
            '@Lotｺﾒﾝﾄ登録ﾒｯｾｰｼﾞ送信(最終更新日時は、確定時に返される値を使う。ﾒｯｾｰｼﾞ関数内で書き換えている。)
            lblnAns = pubblnLotChgComm_Upd(CMstrlot_chgcmmentVer, _
                                           lblLotID.Text, _
                                           pstrUserID, _
                                           txtLotCommnt.Text, _
                                           mstrLotLastUpdate)
            '@結果判定
            If lblnAns = True Then
            '@結果が正常の場合
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0016, txtCarrier.Text, lblLotID.Text)
                
                '@ｽﾃｰﾀｽﾊﾞｰ表示
                '@pubVsfInfo_Disp("メッセージコード：C_I16%0$$ロットコメントを登録しました。ｷｬﾘｱ[ %1 ] ロット[ %2 ]")
                Call pubVsfInfo_Disp(pstrDMsg)
                                     
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                    
                '@ﾌｫｰﾑ起動区分処理
                If pblnfrmxxCM0030Kbn = True Then
                    '@親ﾌｫｰﾑのｺﾒﾝﾄを書き換える
                    ptypLotprestate.strComments = txtLotCommnt.Text
                    
                    '@親ﾌｫｰﾑの最終更新日時を書き換える
                    ptypLotprestate.strLotLastUpdate = mstrLotLastUpdate
                    
                    '@ｷｬﾘｱIDのｸﾘｱ
                    txtCarrier.Text = vbNullString
                    '@ﾛｯﾄ情報の初期化
                    Call prvfrmxxCM0030_Del()
                    
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用不可)
                    cmdRegist.Enabled = False

                    '@ﾌｫｰﾑを閉じる終了
                    Me.Close()
                Else
                    '@ｷｬﾘｱIDのｸﾘｱ
                    txtCarrier.Text = vbNullString
                    
                    '@ﾛｯﾄ情報の初期化
                    Call prvfrmxxCM0030_Del()
                    
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用不可)
                    cmdRegist.Enabled = False
                    
                    '@ｷｬﾘｱIDにﾌｫｰｶｽ移動
                    Call pubSetFocus(txtCarrier)
                End If
            
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
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
            Call prvfrmxxCM0030_Del()
            
            '@ﾎﾞﾀﾝ状態
            cmdRegist.Enabled = False
            
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
    '機　能：ｷｬﾘｱIDﾌｫｰｶｽ制御
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/04/08 (Thu) 13:48:22 Y.Yamagishi
    '更新日：2004/04/08 (Thu) 13:48:22
    '備　考：
    Private Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@削除しないで下さい！！
            '@ｷｬﾘｱIDからﾌｫｰｶｽを移動しない場合に使用しています。
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

    '関数名：txtLotCommnt_Change
    '機　能：コメントのMax値をﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/19 (Fri) 09:47:50 T.Oide
    '更新日：2026/03/12 (Thu) 15:42:00 T.Oide
    '備　考：
    Private Sub txtLotCommnt_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLotCommnt.Change

        Dim llngNowByte      As Integer  '現在のﾊﾞｲﾄ数

        Try

            '@現状のﾊﾞｲﾄ数を格納
            llngNowByte = txtLotCommnt.NowByte

            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte4000)
            
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
    '機　能：ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/11/17 (Thu) 11:41:43 N.Kasai
    '更新日：2005/11/17 (Thu) 11:41:43
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
    '機　能：ﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/21 (Mon) 17:17:29 N.Kasai
    '更新日：2005/11/21 (Mon) 17:17:29
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


    '関数名：cmdTxtUp_Click
    '機　能：ｺﾒﾝﾄの前頁切替処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/12 (Mon) 10:34:21 Y.Yamagishi
    '更新日：2005/11/17 (Thu) 11:29:43 N.Kasai
    '備　考：
    '　　　：2005/11/17 (Thu) 11:29:43 N.Kasai      ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdTxtUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtLotCommnt, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
            
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
    '更新日：2005/11/17 (Thu) 11:32:00 N.Kasai
    '備　考：
    '　　　：2005/11/17 (Thu) 11:32:00 N.Kasai      ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdTxtDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtLotCommnt, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
            
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

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '======================================Public===========================================
    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑのKeyDown処理
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：
    '作成日：2004/04/12 (Mon) 09:10:38 Y.Yamagishi
    '更新日：2004/04/12 (Mon) 09:10:38
    '備　考：
    '　　　：2005/01/11 (Tue) 09:50:43 S.Deguchi    不要ﾁｪｯｸ・判定部分を削除
    Public Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Dim lblnAns         As Boolean  '戻り値
        Dim lstrFormName    As String   'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName   As String   'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)

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
            
            '@ｺﾒﾝﾄ欄入力時は改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
            If ActiveControl.Name = txtLotCommnt.Name Then
                Exit Sub
            End If

            Select Case e.KeyCode
                '@Enterｷｰの場合
                Case Keys.Return
                    '@ﾌｫｰｶｽ取得ｺﾝﾄﾛｰﾙ確認
                    If ActiveControl.Name = txtCarrier.Name Then
                        '@ｷｬﾘｱIDﾁｪｯｸ
                        If prvblnInput_Chk() = False Then
                            Exit Sub
                        End If
                    
                        '@ﾚｽﾎﾟﾝｽ取得開始
                        lstrFormName = Me.Name
                        lstrEventName = "txtCarrier_Enter"
                        Call pubResponseStart(lstrFormName, lstrEventName)
                           
                        '@ｷｬﾘｱID Enter処理
                        lblnAns = txtCarrier_Enter()
                        If lblnAns = True Then
                            '@正常時、ﾌｫｰｶｽ移動
                            If txtLotCommnt.Enabled = True Then
                            '@確定ﾎﾞﾀﾝ押下可の場合
                                '@ﾛｯﾄｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(txtLotCommnt)
                            Else
                                '@Tabｷｰ同様の動作
                                SendKeys.SendWait(CPstrSendKeysTab)
                            End If
                                                
                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(lstrFormName, lstrEventName)
                            
                            e.Handled = True
                            
                            Exit Sub
                        Else
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(lstrFormName, lstrEventName)
                            
                            e.Handled = True
                            
                            Exit Sub
                        End If
                    Else
                        '@Tabｷｰ同様の動作
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                    End If
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

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：prvfrmxxCM0030_Init
    '機　能：初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/10 (Wed) 21:05:35 T.Oide
    '更新日：2026/03/12 (Thu) 15:42:00 T.Oide
    '備　考：
    Private Sub prvfrmxxCM0030_Init()
            
        Dim llngNowByte             As Integer  'ﾊﾞｲﾄ数格納
        Dim lstrFormTitle           As String   'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0140, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
                
            '@各ｺﾝﾄﾛｰﾙを初期化
            txtCarrier.Text = vbNullString          'ｷｬﾘｱｸﾘｱ
            lblLotID.Text = vbNullString            'ﾛｯﾄID
            lblFlowClass.Text = vbNullString        '流動区分
            lblWFNo.Text = vbNullString             'FW枚数
            lblOpID.Text = vbNullString             '大工程ID
            lblStartDayTime.Text = vbNullString     '開始日時
            lblPdID.Text = vbNullString             '機種名
            lblS.Text = vbNullString                '特殊特性
            lblStatus.Text = vbNullString           '状態
            lblStepID.Text = vbNullString           '小工程ID
            lblLotManager.Text = vbNullString       'ﾛｯﾄ担当者名
            lblTimeLimit.Text = vbNullString        '時間制約
            txtLotCommnt.MultiLineEx = True         'ﾛｯﾄｺﾒﾝﾄ複数行表示
            lblGRB.Text = vbNullString              'GRB

            '@GRB背景色
            lblGRB.BackColor = lblLotManager.BackColor
            
            '@日付ﾀｲﾄﾙ設定「処理開始予定」
            lblStartTime.Text = CPstrDispatchTime
            
            '@ﾛｯﾄｺﾒﾝﾄ初期化
            With txtLotCommnt
                .ChrMaxByte = CPlngLotCommentsMaxByte4000       'ﾛｯﾄｺﾒﾝﾄ最大入力ﾊﾞｲﾄ数
                .Text = vbNullString                            'ﾛｯﾄｺﾒﾝﾄ
                
                '@現状のﾊﾞｲﾄ数を格納
                llngNowByte = .NowByte
                
                '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte4000)
            End With
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ
            cmdTxtUp.Enabled = False
            cmdTxtDown.Enabled = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM0030_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxCM0030_Del
    '機　能：画面情報の削除
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/10 (Wed) 21:05:35 T.Oide
    '更新日：2008/06/10 (Tue) 16:29:44 N.Kojima
    '備　考：
    '　　　：2008/06/10 (Tue) 16:29:44 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxCM0030_Del()

        Try
                
            '@各ｺﾝﾄﾛｰﾙを初期化
            lblLotID.Text = vbNullString            'ﾛｯﾄID
            lblFlowClass.Text = vbNullString        '流動区分
            lblWFNo.Text = vbNullString             'FW枚数
            lblOpID.Text = vbNullString             '大工程ID
            lblStartDayTime.Text = vbNullString     '開始日時
            lblPdID.Text = vbNullString             '機種名
            lblS.Text = vbNullString                '特殊特性
            lblStatus.Text = vbNullString           '状態
            lblStepID.Text = vbNullString           '小工程ID
            lblLotManager.Text = vbNullString       'ﾛｯﾄ担当者名
            lblTimeLimit.Text = vbNullString        '時間制約
            '@↓2020/02/19 (Wed) 13:58:40 Y.Yoneyama 「.Netへ反映未」 **************************************************
            lblGRB.Text = vbNullString              'GRB
            '@GRB背景色
            lblGRB.BackColor = lblLotManager.BackColor
            '@↑2020/02/19 (Wed) 13:58:40 Y.Yoneyama 「.Netへ反映未」 **************************************************

            
            '@日付ﾀｲﾄﾙ設定「処理開始予定」
            lblStartTime.Text = CPstrDispatchTime
            
            With txtLotCommnt
                '@ﾛｯﾄｺﾒﾝﾄ
                .Text = vbNullString
                '@ｺﾒﾝﾄﾛｯｸ
                .Enabled = False
            End With
            
            cmdTxtUp.Enabled = False                    'ｺﾒﾝﾄ前頁ﾎﾞﾀﾝﾛｯｸ
            cmdTxtDown.Enabled = False                  'ｺﾒﾝﾄ次頁ﾎﾞﾀﾝﾛｯｸ
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM0030_Del"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxCM0030_Set
    '機　能：基本情報表示(親ﾌｫｰﾑから呼ばれた場合)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/03/10 (Wed) 21:06:10 T.Oide
    '更新日：2008/06/10 (Tue) 16:30:18 N.Kojima
    '備　考：
    '　　　：2004/08/25 (Wed) 親ﾌｫｰﾑから呼ばれて値をｾｯﾄする。
    '　　　：2004/09/09 (Thu) 18:47:57 Y.Yamagishi  時間制限表示変更(不具合改善№693)
    '　　　：2006/06/08 (Thu) 14:12:15 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2008/06/10 (Tue) 16:30:18 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxCM0030_Set()

        Try
            
            '@情報表示
            txtCarrier.Text = pstrCarrierID                                 'ｷｬﾘｱID
            With ptypLotprestate
                lblLotID.Text = .strLotID                                   'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass                           '流動区分
                lblOpID.Text = .strOpID                                     '大工程ID
                If IsDate(.strStartTime) Then
                    lblStartDayTime.Text = Format$(CDate(.strStartTime), CPstrDateFormat) '開始日時(作業開始から呼ばれた場合、投入予定日)"MM/dd HH:mm:ss"
                Else
                    lblStartDayTime.Text = .strStartTime					'開始日時（作業開始から呼ばれた場合、投入予定日）"MM/dd HH:mm:ss"
                End If
                lblPdID.Text = .strPdId                                     '機種名
                lblS.Text = .strSpecialFlg                                  '特殊特性
                lblStatus.Text = .strNowST                                  '状態
                lblStepID.Text = .strStepID                                 '小工程ID
                lblLotManager.Text = .strEngEmpName                         'ﾛｯﾄ担当者名
                '@↓2020/02/19 (Wed) 13:49:33 Y.Yoneyama 「.Netへ反映未」 **************************************************
                lblGRB.Text = .strGRBClass                                  'GRB
                '@GRB背景色
                lblGRB.BackColor = pubGRBBackColor(.strGRBClass, lblLotManager.BackColor)
                '@↑2020/02/19 (Wed) 13:49:33 Y.Yoneyama 「.Netへ反映未」 **************************************************

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
                                    lblTimeLimit.ForeColor =ColorTranslator.FromWin32(CPlngVbColorPurple)    '紫色
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
                
                txtLotCommnt.Text = .strComments                                    'コメント
                '@枚数表示判定(親ﾌｫｰﾑから呼ばれて値をｾｯﾄする為、CFの判定は親画面で行なう)
                lblWFNo.Text = Format$(CInt(.strWfNum), CPstrCFKnmaFormat)             'WF枚数
                
                '@ﾛｯﾄ状態
                Select Case .strNowST
                    '@「作業待ち」「前処理」の場合
                    Case CPstrWaitWorkSt, CPstrBeforeProgressSt
                        '@日付ﾀｲﾄﾙ設定「処理開始予定」
                        lblStartTime.Text = CPstrDispatchTime
                        
                    '@その他
                    Case Else
                        '@日付ﾀｲﾄﾙ設定「処理開始日時」
                        lblStartTime.Text = CPstrStartTime
                End Select
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM0030_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvtxtCarrier_Init
    '機　能：単独起動時の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/08 (Thu) 13:40:51 Y.Yamagishi
    '更新日：2004/04/08 (Thu) 13:40:51
    '備　考：
    Private Sub prvtxtCarrier_Init()

        Try
            
            '@ｷｬﾘｱIDを初期化
            With txtCarrier
                .BackColor = Color.White          'ｷｬﾘｱIDﾊﾞｯｸｶﾗｰ(白)
                .GotBackColor = Color.White       'ｷｬﾘｱIDﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰ(白)
                .Locked = False                   'ｷｬﾘｱIDﾛｯｸ解除
                .TabStop = True
            End With
            
            '@ﾌｫｰﾑを初期化
            Me.KeyPreview = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtxtCarrier_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrier_Enter
    '機　能：ｷｬﾘｱID Enter処理
    '引　数：なし
    '戻り値：True：正常、False：エラー
    '作成日：2004/04/08 (Thu) 13:40:51 Y.Yamagishi
    '更新日：2004/12/07 (Tue) 09:15:06 N.Kojima
    '備　考：2004/12/07 (Tue) 09:15:06 N.Kojima　処理区分を"3L"で送信するように修正(不具合№157)
    Private Function txtCarrier_Enter() As Boolean

        Dim ltypLotprestate         As Lotprestate          'ﾛｯﾄ情報格納構造体
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrLotCarrierID        As String               'ｷｬﾘｱID
        Dim lstrCarrierIDWk         As String               'ｷｬﾘｱID比較用
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)

        Try
            
            '@初期値ｾｯﾄ
            txtCarrier_Enter = False
            
            '@ｷｬﾘｱID取得
            lstrLotCarrierID = txtCarrier.Text
            
            '@ｷｬﾘｱIDが入力されている場合
            If lstrLotCarrierID <> vbNullString Then
                '@ｷｬﾘｱID比較用
                lstrCarrierIDWk = mstrCarrier
            
                '@次回ｷｬﾘｱID比較用
                mstrCarrier = txtCarrier.Text
            
                '@ﾛｯﾄ情報の取得
                lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                                CPstrCD3L, _
                                                lstrLotCarrierID, _
                                                ltypLotprestate)
                '@結果判定
                If lblnAns = True Then
                    '@画面表示処理
                    Call prvfrmxxCM0030_Disp(ltypLotprestate)
                    
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用可)
                    cmdRegist.Enabled = True
                    
                    '@正常
                    txtCarrier_Enter = True
                Else
                    '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(異常)(単独起動用)
                    pblnFormLoad = False
                    
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                    Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(True))
                    AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                End If
            Else
                '@ﾚｽﾎﾟﾝｽ用情報格納
                lstrFormName = Me.Name
                lstrEventName = "txtCarrier_Enter"
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@正常
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

    '関数名：prvfrmxxCM0030_Disp
    '機　能：画面の表示
    '引　数：ltypLotprestate：格納ﾃﾞｰﾀ
    '戻り値：なし
    '作成日：2004/04/08 (Thu) 13:40:51 Y.Yamagishi
    '更新日：2008/06/10 (Tue) 16:31:07 N.Kojima
    '備　考：
    '　　　：2004/08/25 (Wed) ???????? ???????????  CFﾌﾗｸﾞ判定を追加
    '　　　：2004/09/09 (Thu) 18:33:45 Y.Yamagishi  時間制限表示変更(不具合改善№693)
    '　　　：2004/09/14 (Tue) 10:28:44 N.Kojima     数量表示(TPALﾛｯﾄ対応)修正(不具合改善№730)
    '　　　：2005/05/16 (Mon) 17:40:48 N.Kojima     前処理状態の処理開始予定の表示処理を修正。(不具合№808)
    '　　　：2005/05/26 (Thu) 13:49:57 N.Kasai      LP_FLAG判定追加
    '　　　：2005/11/17 (Thu) 11:40:20 N.Kasai      ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    '　　　：2006/06/08 (Thu) 14:17:02 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2008/06/10 (Tue) 16:31:07 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxCM0030_Disp(ByRef ltypLotprestate As Lotprestate)
        
        Try
            
            '@ﾛｯﾄ情報の表示
            With ltypLotprestate
                lblLotID.Text = .strLotID                                                    'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass                                            '流動区分
                lblOpID.Text = .strOpID                                                      '大工程ID
                
                '@ﾛｯﾄ状態
                Select Case .strNowST
                    '@「作業待ち」「前処理」の場合
                    Case CPstrWaitWorkSt, CPstrBeforeProgressSt
                        '@日付ﾀｲﾄﾙ設定「処理開始予定」
                        lblStartTime.Text = CPstrDispatchTime
                        
                        If IsDate(.strDispatchStartTime) Then
                            lblStartDayTime.Text _
                                = Format$(CDate(.strDispatchStartTime), CPstrDateFormat)     '投入予定日"MM/dd HH:mm:ss"
                        Else
                            lblStartDayTime.Text = .strDispatchStartTime                     '投入予定日"MM/dd HH:mm:ss"
                        End If
                        
                    '@その他
                    Case Else
                        '@日付ﾀｲﾄﾙ設定「処理開始日時」
                        lblStartTime.Text = CPstrStartTime
                        
                        If IsDate(.strStartTime) Then
                            lblStartDayTime.Text _
                                = Format$(CDate(.strStartTime), CPstrDateFormat)             '開始日時"MM/dd HH:mm:ss"
                        Else
                            lblStartDayTime.Text = .strStartTime                             '開始日時"MM/dd HH:mm:ss"
                        End If
                        
                End Select
                
                lblPdID.Text = .strPdId                                                      '作業指示
                lblS.Text = .strSpecialFlg                                                   '特殊特性
                lblStatus.Text = .strNowST                                                   '状態
                lblStepID.Text = .strStepID                                                  '小工程ID
                lblLotManager.Text = .strEngEmpName                                          'ﾛｯﾄ担当者名
                '@↓2020/02/19 (Wed) 13:49:33 Y.Yoneyama 「.Netへ反映未」 **************************************************
                lblGRB.Text = .strGRBClass                                                   'GRB
                '@GRB背景色
                lblGRB.BackColor = pubGRBBackColor(.strGRBClass, lblLotManager.BackColor)
                '@↑2020/02/19 (Wed) 13:49:33 Y.Yoneyama 「.Netへ反映未」 **************************************************

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
                                    lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple)   '紫
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
                        lblTimeLimit.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed)                  '赤
                        
                        '@制限時間以下or処理時間制限以下の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@ﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Format(CLng(.strLimitTime), CPstrDateFormatKanma) & CPstrh
                        End If
                        
                        '@制限時間以上の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID2 Then
                            '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,###)+"分"
                            lblTimeLimit.Text = Replace(Format(CLng(.strLimitTime), CPstrDateFormatKanma), _
                                                                  CPstrReplaceMinus, _
                                                                  vbNullString) & CPstrh
                        End If
                    End If
                End If
                
                txtLotCommnt.Text = .strComments                                                'ﾛｯﾄｺﾒﾝﾄ
                mstrLotLastUpdate = .strLotLastUpdate                                           'ﾛｯﾄ最終更新日時
               
                '@枚数表示判定(CF_FLAGを判定し、WF枚数とﾁｯﾌﾟ枚数の表示を切替)
                Select Case .strCfFlag
                    '@CFﾛｯﾄ
                    Case CPstrCF
                        '@大判ﾌﾗｸﾞ判定(LP_FLAG)
                        If .strLpFlag = CPstrLP Then
                            '@大判の場合
                            lblWFNo.Text = .strWfNum                                            'WF枚数
                        Else
                            lblWFNo.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)   'ﾁｯﾌﾟ枚数
                        End If
                        
                    '@CFﾛｯﾄ以外
                    Case Else
                        '@TPALﾛｯﾄ
                        If Trim(Strings.Left(.strLotID, 2)) = CPstrTpalLot Then
                            lblWFNo.Text = Format$(CInt(.strChipQuantity), CPstrCFKnmaFormat)   'ﾁｯﾌﾟ枚数
                        Else
                            '@CF,TPALﾛｯﾄ以外
                            lblWFNo.Text = .strWfNum                                            'WF枚数
                        End If
                End Select
                
                '@ﾛｯﾄ状態
                Select Case .strNowST
                    '@「作業待ち」「前処理」の場合
                    Case CPstrWaitWorkSt, CPstrBeforeProgressSt
                        '@日付ﾀｲﾄﾙ設定「処理開始予定」
                        lblStartTime.Text = CPstrDispatchTime
                        
                    '@その他
                    Case Else
                        '@日付ﾀｲﾄﾙ設定「処理開始日時」
                        lblStartTime.Text = CPstrStartTime
                    
                End Select
                
            End With
            
            '@ﾛｯｸ解除
            txtLotCommnt.Enabled = True     'ｺﾒﾝﾄ
           
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM0030_Disp"
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
    '作成日：2004/04/12 (Mon) 10:03:02 Y.Yamagishi
    '更新日：2004/04/22 (Thu) 11:32:34 Y.Yamagishi
    '備　考：
    Private Function prvblnInput_Chk() As Boolean

        Try
            
            '@初期化
            prvblnInput_Chk = False
            
            '@ｷｬﾘｱIDが空の場合は抜ける
            If txtCarrier.Text = vbNullString Then
                prvblnInput_Chk = False
                
                '@Tabｷｰ同様の動作
                SendKeys.SendWait(CPstrSendKeysTab)
                
                Exit Function
            End If
            
            '@ｷｬﾘｱIDが6桁であるかﾁｪｯｸ
            If Len(txtCarrier.Text) <> CPlngCarrierMaxLength Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                
                '@"ｷｬﾘｱIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｷｬﾘｱIDﾌｫｰｶｽ取得
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
