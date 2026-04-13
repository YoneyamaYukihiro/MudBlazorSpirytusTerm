'ﾌｧｲﾙ名：xxEN01B0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ロット再測定　メインフォーム
'作成日：2004/09/07 (Tue) 09:16:34 H.Wajima
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2004-2018, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01B0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01B0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01B0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01B0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01B0)
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
    '@↓2020/03/06 (Fri) 11:37:08 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion         As String = "05.01"
    Private Const CMstrLocalVersion         As String = "06.00"
    '@↑2020/03/06 (Fri) 11:37:08 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@Msgﾊﾞｰｼﾞｮﾝ
    '@↓2020/01/15 (Wed) 14:14:03 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_curstateVer      As String = "03.04"             'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer      As String = "04.00"             'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 14:14:03 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrlot_steprestartVer   As String = "02.00"             'ﾛｯﾄ再測定
    Private Const CMstrlot_wplist__Ver      As String = "02.05"             'ﾛｯﾄ装置情報取得

    '@機能ID
    Private Const CMstrLocalMenuKey         As String = CPstrKeyEN01B0      'ﾛｰｶﾙﾒﾆｭｰKey

    Private Const CMstrAri                  As String = "あり"
    Private Const CMstrNasi                 As String = "なし"
    Private Const CMlngCarrierMaxLength     As Integer = 6                  'ｷｬﾘｱIDの最大桁数
    Private Const CMlngEqFlag               As Integer = 0                  '装置ﾌﾗｸﾞ

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '@退避情報
    Private mstrTaihiCarrierID              As String                       'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mstrTaihiWPID                   As String                       'ﾛｯﾄ情報取得時のWPID
    Private mstrTaihiLotLastUpdate          As String                       'ﾛｯﾄ情報取得時の最終更新日時
    Private mstrAltNumber                   As String                       '代替番号
    Private mblnTakeOverDispFlg             As Boolean                      '引継ぎ表示ﾌﾗｸﾞ
    Private buttonProcessing                As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu        As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                 As Boolean                      'NSYS WindowCloseフラグ

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
    '作成日：2004/09/07 (Tue) 09:25:41 H.Wajima
    '更新日：2004/09/07 (Tue) 09:25:41
    '備　考：
    Private Sub Form_Load()
        
        Dim lblnAns         As Boolean      '戻り値

        Try
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset
          
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN01B0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
                '@異常終了の場合
                '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                Call pubMenuExpand_Disp()
                '@ﾌｫｰﾑを閉じる
                Call Form_QueryUnload(Me, New FormClosingEventArgs(CloseReason.UserClosing, False))
                Exit Sub
            End If
            
            '@ﾛｯﾄ情報の初期化
            Call prvfrmxxEN01B0_Init()
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用不可)
            Call prvfrmxxEN01B0_CmbInit(False)
            
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
    '作成日：2004/09/07 (Tue) 09:26:34 H.Wajima
    '更新日：2004/09/07 (Tue) 09:26:34
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

            '@引数のキャリアIDが空白かどうか判定する
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@空白でない場合

                '@キャリアIDの初期値を設定する
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

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｸｴﾘｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/09/07 (Tue) 09:27:08 H.Wajima
    '更新日：2004/11/01 (Mon) 15:48:44 T.Kitagawa
    '備　考：2004/11/01 (Mon) 15:48:44 T.Kitagawa　閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs())
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
    '機　能：ﾌｫｰﾑKeyDown処理
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/09/07 (Tue) 09:28:09 H.Wajima
    '更新日：2004/09/07 (Tue) 09:28:09
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            
            Select Case ActiveControl.Name
                '@ｷｬﾘｱIDの場合はﾛｯﾄ状態を取得する
                Case txtCarrier.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                            Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(True))
                            AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                            e.Handled = True
                    End Select
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
    '機　能：閉じるﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/07 (Tue) 09:29:06 H.Wajima
    '更新日：2018/11/16 (Fri) 09:47:55 Y.Yoneyama
    '備　考：2005/02/15 (Tue) 13:25:37 N.Kojima     戻り先画面の判定を追加(改善№512)
    '      ：2018/11/16 (Fri) 09:47:55 Y.Yoneyama   防湿ALD対応
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
                llngRet = publngEnd_Proc(CPstrKeyEN01B0, ltypCommonInfo)
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
    '機　能：確定ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/07 (Tue) 09:29:46 H.Wajima
    '更新日：2005/04/01 (Fri) 11:02:23 N.Kojima
    '備　考：
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    Private Sub cmdKakutei_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdKakutei.Click
        
        Dim lblnInputCheck          As Boolean              '画面入力ﾁｪｯｸ(True:正常,False:異常)
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim ltypLotStepRestart      As LotStepRestart       'ﾛｯﾄ再測定構造体
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance        As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg

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
            lstrEventName = "cmdKakutei_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@作業開始取消ﾃﾞｰﾀ格納
            With ltypLotStepRestart
                .strLotID = lblLotID.Text                               'ﾛｯﾄID
                .strEmpID = pstrUserID                                  '作業者ID
                .strLotLastUpdate = mstrTaihiLotLastUpdate              'LOT最終更新日時
            End With
            
        '@↓2005/04/01 (Fri) 09:00:32 N.Kojima **************************************************
            '@ﾒｯｾｰｼﾞ送信処理呼び出し
        '    lblnAns = pubblnLotStepRestart_Ins(CMstrlot_steprestartVer, ltypLotStepRestart)
            lblnAns = pubblnLotStepRestart_Upd(CMstrlot_steprestartVer, _
                                               ltypLotStepRestart, _
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
        '@↑2005/04/01 (Fri) 09:00:32 N.Kojima **************************************************
            
                '@成功ﾒｯｾｰｼﾞ表示
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002G, txtCarrier.Text, lblLotID.Text)
                
                '@pubVsfInfo_Disp("<TRM2GI>$$ロット再測定を登録しました。キャリア[%1] ロット[%2]")
                Call pubVsfInfo_Disp(pstrDMsg)
                                                      
                '@ｷｬﾘｱIDのｸﾘｱ
                txtCarrier.Text = vbNullString
                
                '@ﾛｯﾄ情報の初期化
                Call prvfrmxxEN01B0_Init()
                
                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用不可)
                Call prvfrmxxEN01B0_CmbInit(False)
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
    '作成日：2004/09/07 (Tue) 10:11:03 H.Wajima
    '更新日：2004/09/07 (Tue) 10:11:03
    '備　考：
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change

        Try
            
          '@ｷｬﾘｱIDを修正する場合はﾛｯﾄ情報をｸﾘｱする
            '@ﾛｯﾄ情報の初期化
            Call prvfrmxxEN01B0_Init()
            
            '@ﾎﾞﾀﾝ状態
            Call prvfrmxxEN01B0_CmbInit(False)
            
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

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '======================================Public===========================================
    '関数名：txtCarrier_Validate
    '機　能：ｷｬﾘｱ情報取得
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/09/07 (Tue) 10:11:27 H.Wajima
    '更新日：2004/09/07 (Tue) 10:11:27
    '備　考：
    Public Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim ltypLotprestate         As Lotprestate          'ﾛｯﾄ情報格納構造体
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypLotWpList           As LotWpList            '装置情報構造体
        Dim llngCnt                 As Integer              'ｶｳﾝﾄ

        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl Is cmdClose OrElse mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@空ENTERの場合はﾌｫｰｶｽ移動のみ
            If Trim(txtCarrier.Text) = vbNullString Then
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
            If Trim(txtCarrier.Text) <> vbNullString And _
                Len(Trim(txtCarrier.Text)) = CMlngCarrierMaxLength And _
                txtCarrier.Text <> mstrTaihiCarrierID Then
                
                '@ﾚｽﾎﾟﾝｽ取得開始
                lstrFormName = Me.Name
                lstrEventName = "txtCarrier_Validate"
                Call pubResponseStart(lstrFormName, lstrEventName)
                
                '@ﾛｯﾄ情報の初期化
                Call prvfrmxxEN01B0_Init()
                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用不可)
                Call prvfrmxxEN01B0_CmbInit(False)
                '@ﾛｯﾄ情報の取得(処理区分：1R(ﾛｯﾄ再測定))
                lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, CPstrCD1R, txtCarrier.Text, ltypLotprestate)
                '@結果判定
                If lblnAns = True Then
                    '@画面表示処理
                    Call prvfrmxxEN01B0_Disp(ltypLotprestate)
                Else
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    Exit Sub
                End If
         
                
                '@装置情報取得
                lblnAns = pubblnLotWplist_Sel(CMstrlot_wplist__Ver, CPstrCD11, lblLotID.Text, lblOpID.Text, lblStepID.Text, mstrAltNumber, ltypLotWpList)
                If lblnAns = False Then
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    Exit Sub
                End If
                
                With ltypLotWpList
                    '@装置が取得できた場合
                    If .lngWPCnt > 0 Then
                        llngCnt = 0
                        lblWP.Text = .typWpList(llngCnt).strWpName          '装置名
                        mstrTaihiWPID = .typWpList(llngCnt).strWpID         '装置ID
                    Else
                        lblWP.Text = vbNullString           '装置名
                        mstrTaihiWPID = vbNullString        '装置ID
                    End If
                End With
                
                '@ｷｬﾘｱID退避(ﾒｯｾｰｼﾞ成功時)
                mstrTaihiCarrierID = txtCarrier.Text
                '@ｺﾏﾝﾄﾞﾎﾞﾀﾝの初期化(使用可)
                Call prvfrmxxEN01B0_CmbInit(True)
                '@確定ﾎﾞﾀﾝへﾌｫｰｶｽ設定
                Call pubSetFocus(cmdKakutei)
                    
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            Else
                '@上記以外の場合
                '@入力ｷｬﾘｱIDと前回のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功)と同じか判定する
                If txtCarrier.Text = mstrTaihiCarrierID Then
                    '@入力ｷｬﾘｱIDと前回のｷｬﾘｱIDが同じ場合
                    If cmdKakutei.Enabled = True Then
                        '@確定ﾎﾞﾀﾝへﾌｫｰｶｽ設定
                        Call pubSetFocus(cmdKakutei)
                    Else
                        '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽ設定
                        Call pubSetFocus(cmdClose)
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

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：prvfrmxxEN01B0_Init
    '機　能：ｷｬﾘｱ情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/07 (Tue) 10:24:58 H.Wajima
    '更新日：2008/06/11 (Wed) 14:38:49 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 14:33:08 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2008/06/11 (Wed) 14:38:49 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxEN01B0_Init()
        
        Dim lstrFormTitle       As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try

            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN01B0, lstrFormTitle)
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
            lblNewStatus.Text = vbNullString                         '取消後状態
            '@↓2020/02/19 (Wed) 13:58:40 Y.Yoneyama 「.Netへ反映未」 **************************************************
            lblGRB.Text = vbNullString                               'GRB
            '@GRB背景色
            lblGRB.BackColor = lblLotManager.BackColor
            '@↑2020/02/19 (Wed) 13:58:40 Y.Yoneyama 「.Netへ反映未」 **************************************************

            '@退避情報の初期化
            mstrTaihiCarrierID = vbNullString                        'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
            mstrTaihiWPID = vbNullString                             'ﾛｯﾄ情報取得時のWPID
            mstrTaihiLotLastUpdate = vbNullString                    'ﾛｯﾄ情報取得時の最終更新日時
            mstrAltNumber = vbNullString                             '代替番号
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01B0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN01B0_CmbInit
    '機　能：各ｺﾏﾝﾄﾞﾎﾞﾀﾝの制御
    '引　数：lblnEnable：True:使用可能,False:使用不可
    '戻り値：なし
    '作成日：2004/09/07 (Tue) 10:25:46 H.Wajima
    '更新日：2004/09/07 (Tue) 10:25:46
    '備　考：
    Private Sub prvfrmxxEN01B0_CmbInit(Optional ByVal lblnEnable As Boolean = False)

        Try
            
            '@各ｺﾏﾝﾄﾞﾎﾞﾀﾝのｺﾝﾄﾛｰﾙ
            cmdKakutei.Enabled = lblnEnable               '確定
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01B0_CmbInit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN01B0_Disp
    '機　能：画面の表示
    '引　数：ltypLotprestate：ﾛｯﾄ情報を格納する構造体
    '戻り値：なし
    '作成日：2004/09/07 (Tue) 10:26:19 H.Wajima
    '更新日：2008/06/11 (Wed) 14:40:13 N.Kojima
    '備　考：
    '　　　：2004/09/24 (Fri) 11:42:25 Y.Yamagishi  制限時間以上の場合文字色を青に変更(不具合改善№825)
    '　　　：2006/06/08 (Thu) 15:20:44 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2008/06/11 (Wed) 14:40:13 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxEN01B0_Disp(ByRef ltypLotprestate As Lotprestate)
        
        Dim llngCnt     As Integer  'ｶｳﾝﾄ

        Try

            '@ﾛｯﾄ情報の表示
            With ltypLotprestate
            
                lblLotID.Text = .strLotID                                                'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass                                        '流動区分
                lblOpID.Text = .strOpID                                                  '大工程ID

                'NSYS 処理開始日時が日付型の場合のみフォーマット
                If IsDate(.strStartTime) = True Then
                    lblStartDayTime.Text = Format$(CDate(.strStartTime), CPstrDateFormat)'処理開始日時"MM/dd HH:mm:ss"
                Else
                    lblStartDayTime.Text = .strStartTime
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
                                    lblTimeLimit.ForeColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngVbColorPurple))    '紫色
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
                        lblTimeLimit.ForeColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngVbColorRed))    '赤色
                        
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
                        
                '@枚数表示判定(CF_FLAGを判定し、WF枚数とﾁｯﾌﾟ枚数の表示を切替)
                Select Case .strCfFlag
                
                    '@CFﾛｯﾄ
                    Case CPstrCF
                        
                        '@大判ﾌﾗｸﾞ判定(LP_FLAG)
                        If .strLpFlag = CPstrLP Then
                            '@大判の場合
                            lblWFNo.Text = .strWfNum                                                'WF枚数
                        Else
                            'NSYS チップが数値の場合のみフォーマット
                            If IsNumeric(.strChipQuantity) = True Then
                                lblWFNo.Text = Format$(CLng(.strChipQuantity), CPstrCFKnmaFormat)   'ﾁｯﾌﾟ枚数
                            Else
                                lblWFNo.Text = .strChipQuantity                                     'ﾁｯﾌﾟ枚数
                            End If
                        End If
                        
                    Case Else
                    ''@CFﾛｯﾄ以外
                        lblWFNo.Text = .strWfNum                                      'WF枚数
                End Select
                
                '@退避情報
                mstrTaihiLotLastUpdate = .strLotLastUpdate                            'ﾛｯﾄ最終更新日時
                llngCnt = 1
                mstrAltNumber = .strAltNumber                                         '代替番号
            
            End With
                
            '@取消前後状態
            lblOldStatus.Text = lblStatus.Text                                        '取消前状態(「前処理」)
            lblNewStatus.Text = CPstrWaitWorkSt                                       '取消後状態(「作業待ち」)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01B0_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnStartInput_Check
    '機　能：確定時の入力ﾁｪｯｸ
    '引　数：なし
    '戻り値：True：項目正常、False：不正項目あり
    '作成日：2004/09/07 (Tue) 10:27:17 H.Wajima
    '更新日：2004/09/07 (Tue) 10:27:17
    '備　考：
    Private Function prvblnStartInput_Check() As Boolean

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
                
            '@状態ﾁｪｯｸ
            Select Case lblStatus.Text
                Case CPstrAfterProgressSt, CPstrEndWorkSt
                    '@後処理、作業終了の場合
                    '@何もしない
                Case Else
                    '@上記以外の場合
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002U)
                    '@"<TRM2UW>$$「後処理」「作業終了」以外のロットは再測定できません。”
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Call pubSetFocus(txtCarrier)
                    Exit Function
            End Select
            
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

    '関数名：cursor_Enter	
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。	
    '作成日：2019/07/02 NSYS	
    '更新日：	
    '備　考：Handlesは画面で入力できるすべての項目が対象	
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles txtCarrier.Enter, cmdClose.Enter, cmdKakutei.Enter 

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
