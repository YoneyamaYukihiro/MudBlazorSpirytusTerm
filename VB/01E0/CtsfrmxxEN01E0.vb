'ﾌｧｲﾙ名：xxEN01E0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：在庫移載　メインフォーム
'作成日：2004/09/30 (Thu) 12:14:26 M.Miura
'更新日：2008/06/24 (Tue) 16:06:00 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01E0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01E0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01E0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01E0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01E0)
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
    Private Const CMstrLocalVersion                     As String = "01.00"                         '機能ﾊﾞｰｼﾞｮﾝ

    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    Private Const CMstrinv_moveinfoVer                  As String = "01.00"                         '在庫ﾛｯﾄ移載情報取得
    Private Const CMstrinv_move____Ver                  As String = "01.00"                         '在庫ﾛｯﾄ移載

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN01E0                  'ﾛｰｶﾙﾒﾆｭｰKey

    Private Const CMlngMaxByte                          As Integer = 6                              'ｷｬﾘｱIDMAX桁数
    Private Const CMlngLeftLength                       As Integer = 7                              'ﾛｯﾄID左7桁比較文字数
    Private Const CMlngRightLength                      As Integer = 2                              'ﾛｯﾄID右2桁比較文字数

    '@ﾀﾌﾞｲﾝﾃﾞｯｸｽ
    Private Const CMlngtabLot0                          As Integer = 0                              '移載先ｷｬﾘｱ1
    Private Const CMlngtabLot1                          As Integer = 1                              '移載先ｷｬﾘｱ2

    '@ﾚｽﾎﾟﾝｽ用定数宣言
    Private Const CMstrReseponseFormName                As String = "frmxxEN01E0"                   'ﾚｽﾎﾟﾝｽ用ﾌｫｰﾑ名

    '@vsfSlotMapの定数宣言(ｶﾗﾑ)
    Private Const CMlngColSlot                          As Integer = 0                              'ｽﾛｯﾄ№
    Private Const CMlngColWFID                          As Integer = 1                              'WFID
    Private Const CMlngColToCarrySlotPosition           As Integer = 2                              '移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ(非表示)
    Private Const CMlngColDivideCombineLotID            As Integer = 3                              '分割/統合ﾛｯﾄID(非表示　組立在庫分割時に使用)

    '@vsfSlotMapの定数宣言(表示幅)
    Private Const CMlngColSlotWidth                     As Integer = 24                             'ｽﾛｯﾄWidth
    Private Const CMlngColWFIDWidth                     As Integer = 170                            'WFIDWidth
    Private Const CMlngColToCarrySlotPositionWidth      As Integer = 0                              '移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ(非表示)Width
    Private Const CMlngColDivideCombineLotIDWidth       As Integer = 0                              '分割/統合ﾛｯﾄID(非表示　組立在庫分割時に使用)Width
    Private Const CMlngSlotMapRowS                      As Integer = 26                             '行数
    Private Const CMlngSlotMapCols                      As Integer = 4                              '列数
    Private Const CMlngSlotMapHeight                    As Integer = 20                             '1ｽﾛｯﾄの高さ
    Private Const CMlngvsfSlotMapColWFID                As Integer = 0                              'WFID
    Private Const CMlngRowTop                           As Integer = 25                             '最上段行
    Private Const CMlngRowBottom                        As Integer = 1                              '最下段行

    '@vsfSlotMapの定数宣言(ﾀｲﾄﾙ)
    Private Const CMlngSlotMapRowTitle                  As Integer = 0                              'ｽﾛｯﾄﾏｯﾌﾟﾀｲﾄﾙ
    Private Const CMstrSlotMapColTSlot                  As String = vbNullString                    'ｽﾛｯﾄNO
    Private Const CMstrSlotMapColTWFID                  As String = "WFID"                          'WFID
    Private Const CMlngSlotHMaCellFontSize              As Integer = 12                             'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ

    '@ﾛｯﾄｲﾍﾞﾝﾄID
    Private Const CMlngLotEvent0                        As Integer = 0                              'ﾛｯﾄｲﾍﾞﾝﾄID(投入前)
    Private Const CMlngLotEvent6                        As Integer = 6                              'ﾛｯﾄｲﾍﾞﾝﾄID(作業終了)
    Private Const CMlngLotEvent99                       As Integer = 99                             'ﾛｯﾄｲﾍﾞﾝﾄID(ﾛｯﾄ終了)
    Private Const CMlngLotEventIDD                      As Integer = 10                             'ﾛｯﾄｲﾍﾞﾝﾄID(分割)
    Private Const CMlngLotEventIDC                      As Integer = 11                             'ﾛｯﾄｲﾍﾞﾝﾄID(統合)
    Private Const CMlngLotEventID                       As Integer = 12                             'ﾛｯﾄｲﾍﾞﾝﾄID(不良/保留/払出)

    '@移載ﾌﾗｸﾞ
    Private Const CMstrEQFlag                           As String = "0"                             '装置ﾌﾗｸﾞ(ｸﾗｲｱﾝﾄからは"0"固定)

    '@ｽﾃｰﾀｽ
    Private Const CMstrDivide                           As String = "分割"                          '分割
    Private Const CMstrCombine                          As String = "統合"                          '統合
    Private Const CMstrScrap                            As String = "不良/保留"                     '不良/保留/払出

    '@ﾌﾚｰﾑ見出し用
    Private Const CMstrFromMove                         As String = "移載元"
    Private Const CMstrToMove                           As String = "移載先"

    Private Const CMstrDivideCombineStatusD1            As String = "D1"                            '分割1
    Private Const CMstrDivideCombineStatusD2            As String = "D2"                            '分割2
    Private Const CMstrDivideCombineStatusC1            As String = "C1"                            '統合

    '@色定数
    Private Const CMlngDivideLot                        As Integer = &HE0E0E0                       '分割ﾛｯﾄ

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '====================================Private============================================
    Private mstrLotLastUpdate1                          As String                                   '移載元ﾛｯﾄ最終更新日時
    Private mstrLotLastUpdate2                          As String                                   '移載先ﾛｯﾄ1最終更新日時
    Private mblnTxtCarrierChange                        As Boolean                                  '移載元ｷｬﾘｱID変更ﾌﾗｸﾞ
    Private mstrTxtCarrierChange                        As String                                   '退避移載元ｷｬﾘｱID名

    Private mstrEventName                               As String                                   'ﾚｽﾎﾟﾝｽ用ｲﾍﾞﾝﾄ名
    Private mstrLotEventID                              As String                                   'ﾛｯﾄｲﾍﾞﾝﾄID格納
    Private mstrLotEventIDMove                          As String                                   'ﾛｯﾄｲﾍﾞﾝﾄID格納
    Private mblnCarrierMoveFlg                          As Boolean                                  '移載可能ﾌﾗｸﾞ
    Private mblnTakeOverDispFlg                         As Boolean                                  '引継ぎ表示ﾌﾗｸﾞ
    Private mstrDivideCombineLotID1                     As String                                   '分割先ﾛｯﾄID1退避用変数
    Private mlngWFListCnt                               As Integer                                  '分割元ﾛｯﾄﾏｯﾌﾟのWFList数
    Private mstrLotId                                   As String                                   '移載元ﾛｯﾄID
    Private mstrOrgDivideCombineLotID1                  As String                                   '編集元分割先ﾛｯﾄID1退避用変数
    Private mstrSlotSize1                               As String                                   '移載先１ｽﾛｯﾄｻｲｽﾞ
    Private mstrSlotSize2                               As String                                   '移載先２ｽﾛｯﾄｻｲｽﾞ

    Private buttonProcessing                            As Boolean              'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean              'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean              'NSYS WindowCloseフラグ

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
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ時ﾒｲﾝﾌｫｰﾑの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 16:13:29 Y.Yamagishi
    '更新日：2004/05/28 (Fri) 16:13:29
    '備　考：
    Private Sub Form_Load()
        
        Dim lblnAns         As Boolean      '開放結果格納

        Try
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = 0 - My.Settings.FormOffset

            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN01E0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
                '@異常終了の場合
                '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                Call pubMenuExpand_Disp()
                '@ﾌｫｰﾑを閉じる
                Call Form_QueryUnload(Me, New FormClosingEventArgs(CloseReason.UserClosing,  False))
                Exit Sub
            End If
            
            '@ﾒｲﾝﾌｫｰﾑの初期化
            Call prvMainForm_Init(True)
            
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
    '作成日：2004/07/27 (Tue) 17:24:09 H.Wajima
    '更新日：2004/07/27 (Tue) 17:24:09
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
    '機　能：終了処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 16:45:55 Y.Yamagishi
    '更新日：2004/11/01 (Mon) 15:41:04 T.Kitagawa
    '備　考：2004/11/01 (Mon) 15:41:04 T.Kitagawa　閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs())
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
            pblnFormLoad = False
            
            '@LotID画面間の引渡し用LotIDに初期値ｾｯﾄ
            pstrLotID = vbNullString

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
    '機　能：ﾌｫｰｶｽ制御
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｷｰｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/06/01 (Tue) 13:04:25 Y.Yamagishi
    '更新日：2004/06/01 (Tue) 13:04:25
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@Enterｷｰ処理
            Select Case e.KeyCode
                Case Keys.Return
                    '@ﾌｫｰｶｽがｷｬﾘｱIDにある場合
                    Select Case ActiveControl.Name
                        Case "txtCarrier"
                            '@移載元情報を取得する
                            RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                            Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                            '@ﾌｫｰｶｽがｷｬﾘｱIDにある場合且つ、退避移載元ｷｬﾘｱID名が現在の移載元ｷｬﾘｱID名と同じ場合
                            If ActiveControl.Name = txtCarrier.Name And mstrTxtCarrierChange = txtCarrier.Text Then
                                '@Tab動作を行う
                                SendKeys.SendWait(CPstrSendKeysTab)
                                e.Handled = True
                            End If
                            AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                            Exit Sub
                    End Select
                               
                    '@退避移載元ｷｬﾘｱID名ｾｯﾄ
                    mstrTxtCarrierChange = txtCarrier.Text
                    
                    '@Tab動作を行う
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

    '関数名：cmdClose_Click
    '機　能：ﾌｫｰﾑを閉じる
    '引　数：なし
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 16:46:44 Y.Yamagishi
    '更新日：2004/05/28 (Fri) 16:46:44
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim llngRet         As Integer      '戻り値
        Dim ltypCommonInfo  As CommonInfo   'ﾀﾞﾐｰ構造体

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
                '@装置別ﾛｯﾄ一覧を起動する
                Call pubMenuSelect_Proc(CPstrKeyEN0150)
            Else
                '@空白の場合
                '@終了関数を実行する
                llngRet = publngEnd_Proc(CPstrKeyEN01E0, ltypCommonInfo)
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
    '機　能：確定ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/02 (Wed) 13:52:49 Y.Yamagishi
    '更新日：2004/10/21 (Thu) 11:26:19 N.Kojima
    '備　考：
    '　　　：2004/10/21 (Thu) 11:26:19 N.Kojima　空ﾀｸﾞ挿入処理削除に伴う、ﾘｽﾄ0件ﾁｪｯｸ追加
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnAnsChk              As Boolean              '項目ﾁｪｯｸ(True:正常,False:異常)
        Dim ltypInvMove____         As InvMove____          '在庫ﾛｯﾄ移載情報構造体
        Dim llngCnt                 As Integer              '一覧表のSlot№ｶｳﾝﾄ
        Dim lblnAnsInvMove____      As Boolean              'ﾒｯｾｰｼﾞ処理結果
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名格納(ﾚｽﾎﾟﾝｽ用)
        Dim llngMoveCnt             As Integer              '移載先ﾛｯﾄ件数

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@画面項目ﾁｪｯｸ
            lblnAnsChk = prvblnRegist_Chk(llngMoveCnt)
            If lblnAnsChk = False Then
                '@不正項目あり
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
            lstrEventName = "cmdRegist_Click"
            Call pubResponseStart(CMstrReseponseFormName, lstrEventName)
            
            
            With ltypInvMove____
                '@移載区分のﾁｪｯｸ
                Select Case lblMoveClass.Text
                    '@分割の場合
                    Case CMstrDivide
                        .strCarrierId = txtCarrier.Text                 '移載元ｷｬﾘｱID
                        .llngMoveListCnt = llngMoveCnt                  '移載先ﾛｯﾄ件数
                        
                        '@構造体初期化
                        If IsNothing(.typMoveList) Then
                            .typMoveList = New List(Of MoveList)()
                        Else
                            .typMoveList.Clear()
                        End If

                        '@移載先ｷｬﾘｱﾏｯﾌﾟのﾙｰﾌﾟ
                        For llngCnt = 0 To llngMoveCnt - 1
                            Dim tmpMoveList As MoveList = New MoveList()
                            Select Case llngCnt
                                Case 0
                                    tmpMoveList.strLotLastUpdate = mstrLotLastUpdate1
                                    tmpMoveList.strCarrierId = lblCarrierMove1.Text
                                    tmpMoveList.strLotID = lblLotIDMove1.Text
                                Case 1
                                    tmpMoveList.strLotLastUpdate = mstrLotLastUpdate2
                                    tmpMoveList.strCarrierId = lblCarrierMove2.Text
                                    tmpMoveList.strLotID = lblLotIDMove2.Text
                            End Select
                            .typMoveList.Add(tmpMoveList)
                        Next llngCnt
                        
                End Select
                .strEmpID = pstrUserID                          '作業者ID
            End With
            
            '@ﾘｽﾄ件数が0件の場合
            If ltypInvMove____.llngMoveListCnt <= 0 Then
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrReseponseFormName, lstrEventName)
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar003Q)
                '@"移載先ロット情報が設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Exit Sub
            End If
            
            '@ﾒｯｾｰｼﾞ送信処理呼び出し
            lblnAnsInvMove____ = pubblnInvMove_____Ins(CMstrinv_move____Ver, ltypInvMove____)
            
            If lblnAnsInvMove____ = True Then
                '@移載区分の判定
                Select Case lblMoveClass.Text
                    Case CMstrDivide
                        '@分割の場合
                        '@成功ﾒｯｾｰｼﾞ表示
                        If llngMoveCnt = 1 Then
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002Y, lblCarrierMove1.Text, lblLotIDMove1.Text)
                            '@"<TRM2YI>$$移載しました。移載先キャリア[%1] 移載先ロット[%2]"
                            Call pubVsfInfo_Disp(pstrDMsg)
                        Else
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002Z, lblCarrierMove1.Text, lblLotIDMove1.Text, lblCarrierMove2.Text, lblLotIDMove2.Text)
                            '@"<TRM2ZI>$$移載しました。移載先１キャリア[%1] 移載先１ロット[%2]$移載先２キャリア[%3] 移載先２ロット[%4]"
                            Call pubVsfInfo_Disp(pstrDMsg)
                        End If
                        
                    Case CMstrCombine
                        '@統合の場合
                        '@成功ﾒｯｾｰｼﾞ表示
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0062, txtCarrier.Text, lblLotID.Text)
                        '@"メッセージコード：C_I62%0$$移載しました。移載先キャリア[ %1 ] 移載後ロット[ %2 ]"
                        Call pubVsfInfo_Disp(pstrDMsg)
                    Case CMstrScrap
                        '@不良/保留の場合
                        '@成功ﾒｯｾｰｼﾞ表示
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        '"メッセージコード：C_I63%0$$移載しました。移載先キャリア[ %1 ] "
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0063, lblCarrierMove1.Text)
                        '@ｽﾃｰﾀｽﾒｯｾｰｼﾞ表示
                        Call pubVsfInfo_Disp(pstrDMsg)
                End Select
                                     
                '@画面の初期化
                Call prvMainForm_Init(True)
            
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrReseponseFormName, lstrEventName)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrReseponseFormName, lstrEventName)
            End If
            
            '@ｷｬﾘｱIDが有効な場合
            If txtCarrier.Enabled = True Then
                '@ｷｬﾘｱIDにｾｯﾄﾌｫｰｶｽ
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

    '関数名：txtCarrier_Change
    '機　能：ｷｬﾘｱ変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/01 (Tue) 12:57:33 Y.Yamagishi
    '更新日：2004/06/01 (Tue) 12:57:33
    '備　考：
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change

        Try
            
            '@画面初期化
            Call prvMainForm_Init(False)
            
            '@変更ﾌﾗｸﾞｾｯﾄ
            mblnTxtCarrierChange = True
            
            '@退避移載元ｷｬﾘｱID名初期化
            mstrTxtCarrierChange = vbNullString
            
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
    '機　能：ｷｬﾘｱIDﾌｫｰｶｽﾛｽﾄ時,移載元WFﾏｯﾌﾟ表示処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/06/01 (Tue) 12:20:47 Y.Yamagishi
    '更新日：2004/09/22 (Wed) 20:02:42 M.Miura
    '備　考：2004/08/27 (Fri) 17:31:53 N.Kasai ｷｬﾘｱﾀｲﾌﾟ追加
    '　　　：2004/09/22 (Wed) 20:02:42 M.Miura WF移載ﾌﾗｸﾞ判定の位置変更(ｴﾗｰ時にﾛｯﾄ情報を表示しない)
    Public Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim lblnAns                         As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrCarriaName                  As String               'ｷｬﾘｱID欄名
        Dim ltypInvmoveinfo                 As InvMoveInfo          'ﾛｯﾄ移載情報格納構造体
        Dim llngCnt                         As Integer              'ｶｳﾝﾄ数
        Dim lblnNextCtrl                    As Boolean              'NSYS Focus設定フラグ

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            If ActiveControl.Name = txtCarrier.Name OrElse _
                (cmdRegist.Enabled = True And ActiveControl.Name = cmdRegist.Name) OrElse _
                (cmdRegist.Enabled = False And ActiveControl.Name = cmdClose.Name) Then
                lblnNextCtrl = True
            Else
                lblnNextCtrl = False
            End If
            
            '@ｷｬﾘｱIDの空白ﾁｪｯｸ
            If Trim(txtCarrier.Text) = vbNullString Then
                '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                If lblnNextCtrl Then
                    Call pubSetFocus(cmdClose)
                End If
                Exit Sub
            End If
            
            '@投入予定ｷｬﾘｱIDの桁ﾁｪｯｸ
            If LenB(txtCarrier.Text) < CMlngMaxByte And _
               txtCarrier.Text <> vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｽﾛｯﾄﾏｯﾌﾟの初期化
                e.Cancel = True
                If lblnNextCtrl Then
                    Call pubSetFocus(txtCarrier)
                End If 
                Exit Sub
            End If

            '@ｷｬﾘｱIDが無変更の場合
            If mblnTxtCarrierChange = False Then
            
                '@前移載元ｷｬﾘｱID名ｾｯﾄ
                mstrTxtCarrierChange = txtCarrier.Text

                '@何もしないで抜ける
                Exit Sub
            End If
            lstrCarriaName = txtCarrier.Text

            '@ｷｬﾘｱID情報の取得
            If Trim(lstrCarriaName) <> vbNullString And _
               Len(Trim(lstrCarriaName)) = txtCarrier.ChrMaxByte Then

                '@ﾚｽﾎﾟﾝｽ測定開始
                mstrEventName = "txtCarrier_Validate"
                Call pubResponseStart(CMstrReseponseFormName, mstrEventName)

                '@変更ﾌﾗｸﾞ初期化(変更)
                mblnTxtCarrierChange = True
                
                '@ﾛｯﾄｲﾍﾞﾝﾄを初期化
                mstrLotEventID = vbNullString
                
                '@DBからﾛｯﾄ情報の取得
                lblnAns = pubblnInvmoveinfo_Sel(CMstrinv_moveinfoVer, txtCarrier.Text, ltypInvmoveinfo)

                                    
                '@取得に成功したら表示
                If lblnAns = True Then
                
                    '@画面表示処理
                    With ltypInvmoveinfo
                        mlngWFListCnt = .lngWfListCnt               'WFLIST数
                        
                        '@WFﾘｽﾄがなくなるまで
                        For llngCnt = 0 To .lngWfListCnt - 1
                            '@ｽﾃｰﾀｽ判定
                            Select Case .typInvMoveInfoWFList(llngCnt).strDivideCombineStatus
                                '@分割１の場合
                                Case CMstrDivideCombineStatusD1
                                    '@ﾛｯﾄｲﾍﾞﾝﾄに分割をｾｯﾄ
                                    mstrLotEventID = CMlngLotEventIDD
                                    lblLotID.Text = .strLotID1               'ﾛｯﾄID
                                    lblFlowClass.Text = .strFlowClass        '流動区分
                                    Exit For
                                    
                                '@分割２の場合はなにもしない
                                Case CMstrDivideCombineStatusD2
                                
                                '@統合の場合
                                Case CMstrDivideCombineStatusC1
                                
                                    '@画面初期化(移載元ｷｬﾘｱID以外)
                                    Call prvMainForm_Init(False)
                                    '@変更ﾌﾗｸﾞｾｯﾄ
                                    mblnTxtCarrierChange = True
                                    '@ﾚｽﾎﾟﾝｽ測定中止
                                    Call pubResponseCancel(CMstrReseponseFormName, mstrEventName)
                                    Exit Sub
                                
                                Case Else
                                
                                    '@画面初期化(移載元ｷｬﾘｱID以外)
                                    Call prvMainForm_Init(False)
                                    '@変更ﾌﾗｸﾞｾｯﾄ
                                    mblnTxtCarrierChange = True
                                    '@ﾚｽﾎﾟﾝｽ測定中止
                                    Call pubResponseCancel(CMstrReseponseFormName, mstrEventName)
                                    Exit Sub
                                    
                            End Select
                        Next llngCnt
                        
                        '@ﾛｯﾄｲﾍﾞﾝﾄが空の場合
                        If mstrLotEventID = vbNullString Then
                            '@不良保留払出しをｾｯﾄ
                            mstrLotEventID = CMlngLotEventID
                        End If
                    
                    End With
                    
                    '@1(必要)の場合の処理
                    Call prvWfCarryFlag1_Proc(ltypInvmoveinfo)
                    
                    '@ﾚｽﾎﾟﾝｽ測定終了
                    Call publngResponseEnd(CMstrReseponseFormName, mstrEventName)
                    
                    '@変更ﾌﾗｸﾞｾｯﾄ
                    mblnTxtCarrierChange = False    '無変更
                Else
                    '@ﾚｽﾎﾟﾝｽ測定中止
                    Call pubResponseCancel(CMstrReseponseFormName, mstrEventName)
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    '@ﾊｲﾗｲﾄ
                    Call pubHighlight(txtCarrier)
                End If

            Else
                '@画面初期化
                Call prvMainForm_Init(True)
            End If
            
            '@確定ﾎﾞﾀﾝ有効/無効制御
            Call prvcmdRegist_Chk(lblnNextCtrl)
            
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

    '関数名：prvMainForm_Init
    '機　能：ﾒｲﾝﾌｫｰﾑ初期化
    '引　数：lblnAllClear：True:全ての項目を削除 False:lblnCarrier依存
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 16:48:33 Y.Yamagishi
    '更新日：2004/10/04 (Mon) 14:39:33 H.Wajima
    '備　考：2004/10/04 (Mon) 14:39:33 H.Wajima    ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    Private Sub prvMainForm_Init(ByVal lblnAllClear As Boolean)
        
        Dim lstrFormTitle       As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try

            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN01E0, lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@初期化
            If lblnAllClear = True Then
                txtCarrier.Text = vbNullString          '移載元ｷｬﾘｱID
            End If
            lblLotID.Text = vbNullString             '移載元ﾛｯﾄID
            lblFlowClass.Text = vbNullString         '移載元流動区分
            
            lblCarrierMove1.Text = vbNullString       '移載先ｷｬﾘｱID
            lblLotIDMove1.Text = vbNullString         '移載先ﾛｯﾄID
            lblFlowClassMove1.Text = vbNullString     '移載先流動区分
            lblCarrierMove2.Text = vbNullString       '移載先ｷｬﾘｱID
            lblLotIDMove2.Text = vbNullString         '移載先ﾛｯﾄID
            lblFlowClassMove2.Text = vbNullString     '移載先流動区分
            
            lblMoveClass.Text = vbNullString         '移載区分
            
            '@変数初期化
            mstrDivideCombineLotID1 = vbNullString      '分割先ﾛｯﾄID1退避用変数
            mlngWFListCnt = 0                           '分割元ﾛｯﾄﾏｯﾌﾟのWFList数
            mstrLotId = vbNullString                    '移載元ﾛｯﾄID
            
            '@ﾛｯｸ
            cmdRegist.Enabled = False                   '確定ﾎﾞﾀﾝ
           
            '@ｽﾛｯﾄﾏｯﾌﾟの初期化
            Call prvvsfSlotMap_init(vsfSlotMap)         'VSFlexGrid(移載元)
            Call prvvsfSlotMap_init(vsfSlotMapMove)     'VSFlexGrid(移載先1)
            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMainForm_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSlotMap_init
    '機　能：ｽﾛｯﾄﾏｯﾌﾟの初期化
    '引　数：lobjControl：VSFlexGridｵﾌﾞｼﾞｪｸﾄ
    '戻り値：なし
    '作成日：2004/05/28 (Fri) 16:57:14 Y.Yamagishi
    '更新日：2004/06/22 (Tue) 18:09:05 N.Kojima
    '備　考：
    Private Sub prvvsfSlotMap_init(ByRef lobjControl As C1FlexGrid)

        Dim llngCnt As Integer  '一覧表のSlot№ｶｳﾝﾄ

        Try
                
            If TypeOf lobjControl Is C1FlexGrid Then    'VSFlexGridのみ対象
            
                '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
                With lobjControl
                    .Redraw = False

                    '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                    .Clear(ClearFlags.Content)
                    
                    '@一覧表の表題設定
                    .Rows.Count = CMlngSlotMapRowS                                                                '行数
                    .Cols.Count = CMlngSlotMapCols                                                                '列数
                    Dim cellRange As CellRange = .GetCellRange(CMlngSlotMapRowTitle, CMlngColSlot, CMlngSlotMapRowTitle, CMlngColWFID) '表題
                    Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                    headerStyle.ForeColor = Color.Yellow                                                     '文字色
                    headerStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))       '背景色
                    headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMlngSlotHMaCellFontSize, _
                                                headerStyle.Font.Style, headerStyle.Font.Unit)               'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                    headerStyle.TextAlign = TextAlignEnum.CenterCenter                                       '文字位置
                    headerStyle.Trimming  = StringTrimming.None                                              'NSYS ﾍｯﾀﾞは省略表示なしに設定
                    cellRange.Style = headerStyle

                    
                    '@ﾊﾞｯｸｶﾗｰを白に変更
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite")
                    newStyle.BackColor = Color.White
                    newStyle.TextAlign = TextAlignEnum.LeftCenter                                             '@WFIDの左寄せ
                    cellRange = .GetCellRange(.Rows.Fixed, CMlngColWFID, CMlngSlotMapRowS - 1, CMlngColWFID)
                    cellRange.Style = newStyle
                    
                    '@列幅、ﾀｲﾄﾙ設定
                    .Cols(CMlngColSlot).Width = CMlngColSlotWidth                                             'ｽﾛｯﾄ№幅
                    .Cols(CMlngColWFID).Width = CMlngColWFIDWidth                                             'WFID列幅
                    .Cols(CMlngColToCarrySlotPosition).Width = CMlngColToCarrySlotPositionWidth               '移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ(非表示)列幅
                    .SetData(CMlngSlotMapRowTitle, CMlngColWFID, CMstrSlotMapColTWFID)            'WFID)
                    '@列の非表示化
                    .Cols(CMlngColToCarrySlotPosition).Visible = False                                        'ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ
                    .Cols(CMlngColDivideCombineLotID).Visible = False                                         '移載先ﾛｯﾄID
                    
                    '@一覧表のSlot№設定
                    For llngCnt = 1 To CMlngSlotMapRowS - 1
                        .Col = CMlngColSlot
                        .Row = llngCnt
                        .SetData(llngCnt, CMlngColSlot, CStr(Format$(CMlngSlotMapRowS - llngCnt, CPstrSlotNoFormat)))
                        .Rows(llngCnt).Height = CMlngSlotMapHeight
                    Next llngCnt

                    Dim fixedStyle As CellStyle = .Styles.Fixed
                    fixedStyle.TextAlign = TextAlignEnum.RightCenter                                           '@ｽﾛｯﾄ№の右寄せ
                    fixedStyle.Font = New Font(fixedStyle.Font.FontFamily, CMlngSlotHMaCellFontSize, _
                                               fixedStyle.Font.Style, fixedStyle.Font.Unit)

                    .Row = 0
                    .Redraw = True
                    '@ﾛｯｸ
                    .Enabled = False
                    
                End With
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMap_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSlotMapDivide_Disp
    '機　能：分割時WFﾏｯﾌﾟ表示
    '引　数：ltypInvmoveinfo：ﾛｯﾄ移載情報取得構造体
    '戻り値：なし
    '作成日：2004/06/01 (Tue) 12:37:00 Y.Yamagishi
    '更新日：2004/08/19 (Thu) 13:32:45 Y.Yamagishi
    '備　考：
    Private Sub prvVsfSlotMapDivide_Disp(ByRef ltypInvmoveinfo As InvMoveInfo)

        Dim llngCnt         As Integer      'ｶｳﾝﾄ数
        Dim llngWriteRow    As Integer      '書き込み行

        Try
            
            vsfSlotMap.Redraw = False
            vsfSlotMapMove.Redraw = False

            With vsfSlotMap
                '@ﾊﾞｯｸｶﾗｰを濃い灰色に変更
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                Dim cellRange As CellRange = .GetCellRange(.Rows.Fixed, CMlngColWFID, CMlngSlotMapRowS - 1, CMlngColWFID)
                cellRange.Style = newStyle
            End With
            
            With vsfSlotMapMove
                '@ﾊﾞｯｸｶﾗｰを濃い灰色に変更
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                Dim cellRange As CellRange = .GetCellRange(.Rows.Fixed, CMlngColWFID, CMlngSlotMapRowS - 1, CMlngColWFID)
                cellRange.Style = newStyle
            End With
            
            
            '@更新日時の初期化
            mstrLotLastUpdate1 = vbNullString       '移載先１最終更新日時
            mstrLotLastUpdate2 = vbNullString       '移載先２最終更新日時
            '@ｽﾛｯﾄｻｲｽﾞの初期化
            mstrSlotSize1 = vbNullString            '移載先１ｽﾛｯﾄｻｲｽﾞ
            mstrSlotSize2 = vbNullString            '移載先２ｽﾛｯﾄｻｲｽﾞ
            
            '@WF枚数分ﾙｰﾌﾟ
            llngCnt = 0
            Do While ltypInvmoveinfo.lngWfListCnt > llngCnt
            
                With ltypInvmoveinfo.typInvMoveInfoWFList(llngCnt)
                    '@書き込み行設定
                    llngWriteRow = CMlngSlotMapRowS - CInt(.strToCarrySlotPosition)
                    
                    '@分割ｽﾃｰﾀｽ判定
                    Select Case .strDivideCombineStatus
                        '@移載先１
                        Case CMstrDivideCombineStatusD1
                            '@移載元WFID表示設定
                            vsfSlotMap.SetData(llngWriteRow, CMlngColWFID, .strWfId)
                            '@移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ設定
                            vsfSlotMap.SetData(llngWriteRow, CMlngColToCarrySlotPosition, .strToCarrySlotPosition)
                            '@分割先ﾛｯﾄID設定
                            vsfSlotMap.SetData(llngWriteRow, CMlngColDivideCombineLotID, .strDivideCombineLotID)
                            
                            '@移載先１最終更新日時が空の場合
                            If mstrLotLastUpdate1 = vbNullString Then
                                mstrLotLastUpdate1 = .strLotLastUpdate     '移載先１最終更新日時
                            End If
                            
                            '@移載先１ｽﾛｯﾄｻｲｽﾞが空の場合
                            If mstrSlotSize1 = vbNullString Then
                                mstrSlotSize1 = .strSlotSize     '移載先１ｽﾛｯﾄｻｲｽﾞ
                            End If
                            
                            '@移載先ｷｬﾘｱIDがない場合
                            If lblCarrierMove1.Text = vbNullString Then
                                '@移載先ｷｬﾘｱIDをｾｯﾄ
                                lblCarrierMove1.Text = .strToCarrierId
                            End If
                            '@移載先ﾛｯﾄIDがない場合
                            If lblLotIDMove1.Text = vbNullString Then
                                '@移載先ﾛｯﾄIDをｾｯﾄ
                                lblLotIDMove1.Text = .strDivideCombineLotID
                            End If
                            '@移載先流動区分がない場合
                            If lblFlowClassMove1.Text = vbNullString Then
                                '@移載先流動区分をｾｯﾄ
                                lblFlowClassMove1.Text = .strToFlowClass
                            End If
                            
                            '@ﾊﾞｯｸｶﾗｰを白に変更
                            Dim newStyle As CellStyle = vsfSlotMap.Styles.Add("CustomStyle_BackColor_vbWhite")
                            newStyle.BackColor = Color.White
                            Dim cellRange As CellRange = vsfSlotMap.GetCellRange(llngWriteRow, CMlngColWFID)
                            cellRange.Style = newStyle
                            
                        '@移載先２
                        Case CMstrDivideCombineStatusD2
                            '@移載元WFID表示設定
                            vsfSlotMapMove.SetData(llngWriteRow, CMlngColWFID, .strWfId)
                            '@移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ設定
                            vsfSlotMapMove.SetData(llngWriteRow, CMlngColToCarrySlotPosition, .strToCarrySlotPosition)
                            '@分割先ﾛｯﾄID設定
                            vsfSlotMapMove.SetData(llngWriteRow, CMlngColDivideCombineLotID, .strDivideCombineLotID)
                            
                            '@移載先２最終更新日時が空の場合
                            If mstrLotLastUpdate2 = vbNullString Then
                                mstrLotLastUpdate2 = .strLotLastUpdate     '移載先２最終更新日時
                            End If
                            
                            '@移載先２ｽﾛｯﾄｻｲｽﾞが空の場合
                            If mstrSlotSize2 = vbNullString Then
                                mstrSlotSize2 = .strSlotSize     '移載先２ｽﾛｯﾄｻｲｽﾞ
                            End If
                            
                            '@移載先ｷｬﾘｱIDがない場合
                            If lblCarrierMove2.Text = vbNullString Then
                                '@移載先ｷｬﾘｱIDをｾｯﾄ
                                lblCarrierMove2.Text = .strToCarrierId
                            End If
                            '@移載先ﾛｯﾄIDがない場合
                            If lblLotIDMove2.Text = vbNullString Then
                                '@移載先ﾛｯﾄIDをｾｯﾄ
                                lblLotIDMove2.Text = .strDivideCombineLotID
                            End If
                            '@移載先流動区分がない場合
                            If lblFlowClassMove2.Text = vbNullString Then
                                '@移載先流動区分をｾｯﾄ
                                lblFlowClassMove2.Text = .strToFlowClass
                            End If
                            
                            '@ﾊﾞｯｸｶﾗｰを白に変更
                            Dim newStyle As CellStyle = vsfSlotMapMove.Styles.Add("CustomStyle_BackColor_vbWhite")
                            newStyle.BackColor = Color.White
                            Dim cellRange As CellRange = vsfSlotMapMove.GetCellRange(llngWriteRow, CMlngColWFID)
                            cellRange.Style = newStyle
                    End Select
                    
                '@ｶｳﾝﾄｱｯﾌﾟ
                llngCnt = llngCnt + 1
                End With
            Loop
            
            If IsNumeric(mstrSlotSize1) = True Then
                '@移載先１WF枚数分ﾙｰﾌﾟ
                For llngCnt = 1 To CMlngSlotMapRowS - 1
                    '@ｽﾛｯﾄｻｲｽﾞよりｽﾛｯﾄ№が大きい場合
                    If CInt(mstrSlotSize1) < CMlngSlotMapRowS - llngCnt Then
                        '@ｽﾛｯﾄ№は空白
                        vsfSlotMap.SetData(llngCnt, CMlngColSlot, vbNullString)
                        '@ｽﾛｯﾄにWFが存在しない場合はﾊﾞｯｸｶﾗｰを灰色(ﾎﾞﾀﾝの表面の色)に変更する
                        If vsfSlotMap.GetData(llngCnt, CMlngColWFID) = vbNullString Then
                            Dim newStyle As CellStyle = vsfSlotMap.Styles.Add("CustomStyle_BackColor_vbButtonFace")
                            newStyle.BackColor = SystemColors.ControlLight
                            Dim cellRange As CellRange = vsfSlotMap.GetCellRange(llngCnt, CMlngColWFID)
                            cellRange.Style = newStyle
                        End If
                    End If
                Next
            Else
                '@移載先１WF枚数分ﾙｰﾌﾟ
                For llngCnt = 1 To CMlngSlotMapRowS - 1
                    '@ｽﾛｯﾄｻｲｽﾞよりｽﾛｯﾄ№が大きい場合
                    If CMlngSlotMapRowS < CMlngSlotMapRowS - llngCnt Then
                        '@ｽﾛｯﾄ№は空白
                        vsfSlotMap.SetData(llngCnt, CMlngColSlot, vbNullString)
                        '@ｽﾛｯﾄにWFが存在しない場合はﾊﾞｯｸｶﾗｰを灰色(ﾎﾞﾀﾝの表面の色)に変更する
                        If vsfSlotMap.GetData(llngCnt, CMlngColWFID) = vbNullString Then
                            Dim newStyle As CellStyle = vsfSlotMap.Styles.Add("CustomStyle_BackColor_vbButtonFace")
                            newStyle.BackColor = SystemColors.ControlLight
                            Dim cellRange As CellRange = vsfSlotMap.GetCellRange(llngCnt, CMlngColWFID)
                            cellRange.Style = newStyle
                        End If
                    End If
                Next
            End If
            
            If IsNumeric(mstrSlotSize2) = True Then
                '@移載先２WF枚数分ﾙｰﾌﾟ
                For llngCnt = 1 To CMlngSlotMapRowS - 1
                    '@ｽﾛｯﾄｻｲｽﾞよりｽﾛｯﾄ№が大きい場合
                    If CInt(mstrSlotSize2) < CMlngSlotMapRowS - llngCnt Then
                        '@ｽﾛｯﾄ№は空白
                        vsfSlotMapMove.SetData(llngCnt, CMlngColSlot, vbNullString)
                        '@ｽﾛｯﾄにWFが存在しない場合はﾊﾞｯｸｶﾗｰを灰色(ﾎﾞﾀﾝの表面の色)に変更する
                        If vsfSlotMapMove.GetData(llngCnt, CMlngColWFID) = vbNullString Then
                            Dim newStyle As CellStyle = vsfSlotMapMove.Styles.Add("CustomStyle_BackColor_vbButtonFace")
                            newStyle.BackColor = SystemColors.ControlLight
                            Dim cellRange As CellRange = vsfSlotMapMove.GetCellRange(llngCnt, CMlngColWFID)
                            cellRange.Style = newStyle
                        End If
                    End If
                Next
            Else
                '@移載先２WF枚数分ﾙｰﾌﾟ
                For llngCnt = 1 To CMlngSlotMapRowS - 1
                    '@ｽﾛｯﾄｻｲｽﾞよりｽﾛｯﾄ№が大きい場合
                    If CMlngSlotMapRowS < CMlngSlotMapRowS - llngCnt Then
                        '@ｽﾛｯﾄ№は空白
                        vsfSlotMapMove.SetData(llngCnt, CMlngColSlot, vbNullString)
                        '@ｽﾛｯﾄにWFが存在しない場合はﾊﾞｯｸｶﾗｰを灰色(ﾎﾞﾀﾝの表面の色)に変更する
                        If vsfSlotMapMove.GetData(llngCnt, CMlngColWFID) = vbNullString Then
                            Dim newStyle As CellStyle = vsfSlotMapMove.Styles.Add("CustomStyle_BackColor_vbButtonFace")
                            newStyle.BackColor = SystemColors.ControlLight
                            Dim cellRange As CellRange = vsfSlotMapMove.GetCellRange(llngCnt, CMlngColWFID)
                            cellRange.Style = newStyle
                        End If
                    End If
                Next
            End If

            vsfSlotMap.Redraw = True
            vsfSlotMapMove.Redraw = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMapDivide_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSlotMapCombine_Disp
    '機　能：統合時移載元WFﾏｯﾌﾟ表示
    '引　数：ltypInvmoveinfo：ﾛｯﾄ移載情報取得構造体
    '戻り値：なし
    '作成日：2004/06/01 (Tue) 12:37:00 Y.Yamagishi
    '更新日：2004/06/01 (Tue) 12:37:00
    '備　考：
    Private Sub prvVsfSlotMapCombine_Disp(ByRef ltypInvmoveinfo As InvMoveInfo)

        Dim llngCnt         As Integer      'ｶｳﾝﾄ数
        Dim llngWriteRow    As Integer      '書き込み行

        Try
            vsfSlotMap.Redraw = False
            vsfSlotMapMove.Redraw = False

            With vsfSlotMap
                '@ﾊﾞｯｸｶﾗｰを濃い灰色に変更
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                Dim cellRange As CellRange = .GetCellRange(.Rows.Fixed, CMlngColWFID, CMlngSlotMapRowS - 1, CMlngColWFID)
                cellRange.Style = newStyle
            End With
            With vsfSlotMapMove
                '@ﾊﾞｯｸｶﾗｰを濃い灰色に変更
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                Dim cellRange As CellRange = .GetCellRange(.Rows.Fixed, CMlngColWFID, CMlngSlotMapRowS - 1, CMlngColWFID)
                cellRange.Style = newStyle
            End With
            
            '@移載先１WF枚数分ﾙｰﾌﾟ
            For llngCnt = 1 To CMlngSlotMapRowS - 1
                '@ｽﾛｯﾄｻｲｽﾞよりｽﾛｯﾄ№が大きい場合
                If CInt(mstrSlotSize1) < CMlngSlotMapRowS - llngCnt Then
                    '@ｽﾛｯﾄ№は空白
                    vsfSlotMap.SetData(llngCnt, CMlngColSlot, vbNullString)
                    '@ｽﾛｯﾄにｷｬﾘｱが存在しない場合はﾊﾞｯｸｶﾗｰを灰色(ﾎﾞﾀﾝの表面の色)に変更する
                    Dim newStyle As CellStyle = vsfSlotMap.Styles.Add("CustomStyle_BackColor_vbButtonFace")
                    newStyle.BackColor = SystemColors.ControlLight
                    Dim cellRange As CellRange = vsfSlotMap.GetCellRange(llngCnt, CMlngColWFID)
                    cellRange.Style = newStyle
                End If
            Next
            
            '@移載先２WF枚数分ﾙｰﾌﾟ
            For llngCnt = 1 To CMlngSlotMapRowS - 1
                '@ｽﾛｯﾄｻｲｽﾞよりｽﾛｯﾄ№が大きい場合
                If CInt(mstrSlotSize2) < CMlngSlotMapRowS - llngCnt Then
                    '@ｽﾛｯﾄ№は空白
                    vsfSlotMapMove.SetData(llngCnt, CMlngColSlot, vbNullString)
                    '@ｽﾛｯﾄにｷｬﾘｱが存在しない場合はﾊﾞｯｸｶﾗｰを灰色(ﾎﾞﾀﾝの表面の色)に変更する
                    Dim newStyle As CellStyle = vsfSlotMapMove.Styles.Add("CustomStyle_BackColor_vbButtonFace")
                    newStyle.BackColor = SystemColors.ControlLight
                    Dim cellRange As CellRange = vsfSlotMapMove.GetCellRange(llngCnt, CMlngColWFID)
                    cellRange.Style = newStyle
                End If
            Next
                
            '@WF枚数分ﾙｰﾌﾟ
            llngCnt = 0
            Do While ltypInvmoveinfo.lngWfListCnt > llngCnt
            
                With ltypInvmoveinfo.typInvMoveInfoWFList(llngCnt)
                    '@書き込み行設定
                    llngWriteRow = CMlngSlotMapRowS - CInt(.strSlotPosition)
                    
                    '@移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ確認
                    If .strToCarrySlotPosition = vbNullString Then
                        '@移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝが空の場合
                        '@移載元WFID表示設定
                        vsfSlotMap.SetData(llngWriteRow, CMlngColWFID, .strWfId)
                        '@移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ設定
                        vsfSlotMap.SetData(llngWriteRow, CMlngColToCarrySlotPosition, vbNullString)
                        '@ﾊﾞｯｸｶﾗｰを白に変更
                        Dim newStyle As CellStyle = vsfSlotMap.Styles.Add("CustomStyle_BackColor_vbWhite")
                        newStyle.BackColor = Color.White
                        Dim cellRange As CellRange = vsfSlotMap.GetCellRange(llngWriteRow, CMlngColWFID)
                        cellRange.Style = newStyle
                    Else
                        '@移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝが空以外の場合
                        '@移載元WFID表示設定
                        vsfSlotMapMove.SetData(llngWriteRow, CMlngColWFID, .strWfId)
                        '@移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ設定
                        vsfSlotMapMove.SetData(llngWriteRow, CMlngColToCarrySlotPosition, .strToCarrySlotPosition)
                        '@ﾊﾞｯｸｶﾗｰを白に変更
                        Dim newStyle As CellStyle = vsfSlotMapMove.Styles.Add("CustomStyle_BackColor_vbWhite")
                        newStyle.BackColor = Color.White
                        Dim cellRange As CellRange = vsfSlotMapMove.GetCellRange(llngWriteRow, CMlngColWFID)
                        cellRange.Style = newStyle
                        
                        '@移載先ｷｬﾘｱIDがない場合
                        If lblCarrierMove1.Text = vbNullString Then
                            '@移載先ｷｬﾘｱIDをｾｯﾄ
                            lblCarrierMove1.Text = .strToCarrierId
                        End If
                        '@移載先ﾛｯﾄIDがない場合
                        If lblLotID.Text = vbNullString Then
                            '@移載先ﾛｯﾄIDをｾｯﾄ
                            lblLotID.Text = .strDivideCombineLotID
                        End If
                        '@移載先流動区分がない場合
                        If lblFlowClass.Text = vbNullString Then
                            '@移載先流動区分をｾｯﾄ
                            lblFlowClass.Text = .strToFlowClass
                        End If
                        
                    End If
                '@ｶｳﾝﾄｱｯﾌﾟ
                llngCnt = llngCnt + 1
                End With
            Loop
            
            vsfSlotMap.Redraw = True
            vsfSlotMapMove.Redraw = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMapCombine_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSlotMapCombine_Disp
    '機　能：統合時移載先WFﾏｯﾌﾟ表示
    '引　数：ltypInvmoveinfo：ﾛｯﾄ移載情報取得構造体
    '戻り値：なし
    '作成日：2004/06/01 (Tue) 12:37:00 Y.Yamagishi
    '更新日：2004/06/01 (Tue) 12:37:00
    '備　考：
    Private Sub prvvsfSlotMapCombineMove_Disp(ByRef ltypInvmoveinfo As InvMoveInfo)

        Dim llngCnt         As Integer      'ｶｳﾝﾄ数
        Dim llngWriteRow    As Integer      '書き込み行

        Try
            
            vsfSlotMap.Redraw = False
            vsfSlotMapMove.Redraw = False

            '@ﾊﾞｯｸｶﾗｰを濃い灰色に変更
            Dim newStyle As CellStyle = vsfSlotMapMove.Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
            newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
            Dim cellRange As CellRange = vsfSlotMapMove.GetCellRange(vsfSlotMapMove.Rows.Fixed, CMlngColWFID, CMlngSlotMapRowS - 1, CMlngColWFID)
            cellRange.Style = newStyle
            
            '@WF枚数分ﾙｰﾌﾟ
            For llngCnt = 1 To CMlngSlotMapRowS - 1
                '@ｽﾛｯﾄｻｲｽﾞよりｽﾛｯﾄ№が大きい場合
                If CInt(mstrSlotSize2) < CMlngSlotMapRowS - llngCnt Then
                    '@ｽﾛｯﾄ№は空白
                    vsfSlotMapMove.SetData(llngCnt, CMlngColSlot, vbNullString)
                    '@ｽﾛｯﾄにｷｬﾘｱが存在しない場合はﾊﾞｯｸｶﾗｰを灰色(ﾎﾞﾀﾝの表面の色)に変更する
                    newStyle = vsfSlotMapMove.Styles.Add("CustomStyle_BackColor_vbButtonFace")
                    newStyle.BackColor = SystemColors.ControlLight
                    cellRange = vsfSlotMapMove.GetCellRange(llngCnt, CMlngColWFID)
                    cellRange.Style = newStyle
                End If
            Next
            
            '@WF枚数分ﾙｰﾌﾟ
            llngCnt = 0
            Do While ltypInvmoveinfo.lngWfListCnt > llngCnt
            
                With ltypInvmoveinfo.typInvMoveInfoWFList(llngCnt)
                    '@書き込み行設定
                    llngWriteRow = CMlngSlotMapRowS - CInt(.strSlotPosition)
                    
                    '@移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ確認
                    If .strToCarrySlotPosition = vbNullString Then
                        '@移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝが空の場合
                        '@移載元WFID表示設定
                        vsfSlotMapMove.SetData(llngWriteRow, CMlngColWFID, .strWfId)
                        '@移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ設定
                        vsfSlotMapMove.SetData(llngWriteRow, CMlngColToCarrySlotPosition, vbNullString)
                        '@ﾊﾞｯｸｶﾗｰを薄い灰色に変更
                        newStyle = vsfSlotMapMove.Styles.Add("CustomStyle_BackColor_CPlngGridGray")
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridGray)
                        cellRange = vsfSlotMapMove.GetCellRange(llngWriteRow, CMlngColWFID)
                        cellRange.Style = newStyle
                    End If
                '@ｶｳﾝﾄｱｯﾌﾟ
                llngCnt = llngCnt + 1
                End With
            Loop
            
            '@WF枚数分ﾙｰﾌﾟ
            For llngCnt = 1 To CMlngSlotMapRowS - 1
                '@移載元WFﾏｯﾌﾟのWFIDの判定
                If vsfSlotMap.GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                    '@WFIDが空白以外の場合
                    '@移載先WFﾏｯﾌﾟの同じ行のﾊﾞｯｸｶﾗｰを白に変更する
                    newStyle = vsfSlotMapMove.Styles.Add("CustomStyle_BackColor_vbWhite")
                    newStyle.BackColor = Color.White
                    cellRange = vsfSlotMapMove.GetCellRange(llngCnt, CMlngColWFID)
                    cellRange.Style = newStyle
                End If
            Next llngCnt

            vsfSlotMap.Redraw = True
            vsfSlotMapMove.Redraw = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMapCombineMove_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfSlotMap_Disp
    '機　能：不良/保留時WFﾏｯﾌﾟ表示
    '引　数：ltypInvmoveinfo：ﾛｯﾄ移載情報取得構造体
    '戻り値：なし
    '作成日：2004/06/01 (Tue) 12:37:00 Y.Yamagishi
    '更新日：2004/06/01 (Tue) 12:37:00
    '備　考：
    Private Sub prvVsfSlotMap_Disp(ByRef ltypInvmoveinfo As InvMoveInfo)

        Dim llngCnt         As Integer      'ｶｳﾝﾄ数
        Dim llngWriteRow    As Integer      '書き込み行

        Try
            
            vsfSlotMap.Redraw = False
            vsfSlotMapMove.Redraw = False

            With vsfSlotMap
                '@ﾊﾞｯｸｶﾗｰを濃い灰色に変更(移載元)
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                Dim cellRange As CellRange = .GetCellRange(.Rows.Fixed, CMlngColWFID, CMlngSlotMapRowS - 1, CMlngColWFID)
                cellRange.Style = newStyle
            End With
            
            With vsfSlotMapMove
                '@ﾊﾞｯｸｶﾗｰを濃い灰色に変更(移載先)
                Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                Dim cellRange As CellRange = .GetCellRange(.Rows.Fixed, CMlngColWFID, CMlngSlotMapRowS - 1, CMlngColWFID)
                cellRange.Style = newStyle
            End With
            
            '@移載先１WF枚数分ﾙｰﾌﾟ
            For llngCnt = 1 To CMlngSlotMapRowS - 1
                '@ｽﾛｯﾄｻｲｽﾞよりｽﾛｯﾄ№が大きい場合
                If CInt(mstrSlotSize1) < CMlngSlotMapRowS - llngCnt Then
                    '@ｽﾛｯﾄ№は空白
                    vsfSlotMap.SetData(llngCnt, CMlngColSlot, vbNullString)
                    '@ｽﾛｯﾄにｷｬﾘｱが存在しない場合はﾊﾞｯｸｶﾗｰを灰色(ﾎﾞﾀﾝの表面の色)に変更する
                    Dim newStyle As CellStyle = vsfSlotMap.Styles.Add("CustomStyle_BackColor_vbButtonFace")
                    newStyle.BackColor = SystemColors.ControlLight
                    Dim cellRange As CellRange = vsfSlotMap.GetCellRange(llngCnt, CMlngColWFID)
                    cellRange.Style = newStyle
                End If
            Next
            
            '@移載先２WF枚数分ﾙｰﾌﾟ
            For llngCnt = 1 To CMlngSlotMapRowS - 1
                '@ｽﾛｯﾄｻｲｽﾞよりｽﾛｯﾄ№が大きい場合
                If CInt(mstrSlotSize2) < CMlngSlotMapRowS - llngCnt Then
                    '@ｽﾛｯﾄ№は空白
                    vsfSlotMapMove.SetData(llngCnt, CMlngColSlot, vbNullString)
                    '@ｽﾛｯﾄにｷｬﾘｱが存在しない場合はﾊﾞｯｸｶﾗｰを灰色(ﾎﾞﾀﾝの表面の色)に変更する
                    Dim newStyle As CellStyle = vsfSlotMapMove.Styles.Add("CustomStyle_BackColor_vbButtonFace")
                    newStyle.BackColor = SystemColors.ControlLight
                    Dim cellRange As CellRange = vsfSlotMapMove.GetCellRange(llngCnt, CMlngColWFID)
                    cellRange.Style = newStyle
                End If
            Next
                
            '@WF枚数分ﾙｰﾌﾟ
            llngCnt = 0
            Do While ltypInvmoveinfo.lngWfListCnt > llngCnt
            
                With ltypInvmoveinfo.typInvMoveInfoWFList(llngCnt)
                    '@書き込み行設定
                    llngWriteRow = CMlngSlotMapRowS - CInt(.strSlotPosition)
                    
                    '@WFｽﾃｰﾀｽ確認
                    If .strWFStatus = CPstrClass1J Then
                        '@WFｽﾃｰﾀｽが"良品"の場合
                        '@移載元WFID表示設定
                        vsfSlotMap.SetData(llngWriteRow, CMlngColWFID, .strWfId)
                        '@移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝ設定
                        vsfSlotMap.SetData(llngWriteRow, CMlngColToCarrySlotPosition, vbNullString)
                        '@ﾊﾞｯｸｶﾗｰを薄い灰色に変更
                        Dim newStyle As CellStyle = vsfSlotMap.Styles.Add("CustomStyle_BackColor_vbWhite")
                        newStyle.BackColor = Color.White
                        Dim cellRange As CellRange = vsfSlotMap.GetCellRange(llngWriteRow, CMlngColWFID)
                        cellRange.Style = newStyle
                    Else
                        '@WFｽﾃｰﾀｽが"良品"以外の場合
                        '@移載元WFID表示設定
                        vsfSlotMapMove.SetData(llngWriteRow, CMlngColWFID, .strWfId)
                        '@移載先ｽﾛｯﾄﾎﾟｼﾞｼｮﾝにｽﾛｯﾄﾎﾟｼﾞｼｮﾝを設定する
                        vsfSlotMapMove.SetData(llngWriteRow, CMlngColToCarrySlotPosition, .strSlotPosition)
                        '@ﾊﾞｯｸｶﾗｰを白に変更
                        Dim newStyle As CellStyle = vsfSlotMapMove.Styles.Add("CustomStyle_BackColor_vbWhite")
                        newStyle.BackColor = Color.White
                        Dim cellRange As CellRange = vsfSlotMapMove.GetCellRange(llngWriteRow, CMlngColWFID)
                        cellRange.Style = newStyle
                        
                        '@移載先ｷｬﾘｱIDがない場合
                        If lblCarrierMove1.Text = vbNullString Then
                            '@移載先ｷｬﾘｱIDをｾｯﾄ
                            lblCarrierMove1.Text = .strToCarrierId
                        End If
                        
                    End If
                llngCnt = llngCnt + 1
                End With
            Loop

            vsfSlotMap.Redraw = True
            vsfSlotMapMove.Redraw = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfSlotMap_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCarrierMove_Init
    '機　能：移載先画面初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/03 (Thu) 10:37:40 H.Wajima
    '更新日：2004/08/11 (Wed) 17:23:48 Y.Yamagishi
    '備　考：
    Private Sub prvCarrierMove_Init()

        Try
            
            '@初期化
            lblLotIDMove1.Text = vbNullString         '移載先ﾛｯﾄID
            lblFlowClassMove1.Text = vbNullString     '移載先流動区分
            '@ｽﾛｯﾄﾏｯﾌﾟの初期化
            Call prvvsfSlotMap_init(vsfSlotMapMove)     'VSFlexGrid(移載先1)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCarrierMove_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnRegist_Chk
    '機　能：入力ﾁｪｯｸ
    '引　数：llngMoveCnt：移載先ﾛｯﾄ件数
    '戻り値：True：正常、False：異常
    '作成日：2004/09/24 (Fri) 20:06:34 M.Miura
    '更新日：2004/09/24 (Fri) 20:06:34
    '備　考：
    Private Function prvblnRegist_Chk(ByRef llngMoveCnt As Integer) As Boolean

        Dim lstrCaption     As String           'ﾒｯｾｰｼﾞﾎﾞｯｸｽﾀｲﾄﾙ格納
        Dim llngCnt         As Integer          'ｶｳﾝﾄ

        Try
            
            prvblnRegist_Chk = False
            
            '@ﾀｲﾄﾙ設定
            lstrCaption = Me.Text
            
            '@ｷｬﾘｱIDの入力ﾁｪｯｸ
            If txtCarrier.Text = vbNullString Then
            
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                
                '@失敗ﾒｯｾｰｼﾞ表示("キャリアIDが設定されていません。設定を見直してください。")
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, lstrCaption, True, 16)
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If
            
            '@ｷｬﾘｱIDが6桁であるかﾁｪｯｸ
            If Len(txtCarrier.Text) <> CMlngMaxByte Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, lstrCaption, True, 16)
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If
            
            '@移載先１ｷｬﾘｱIDの入力ﾁｪｯｸ
            If lblCarrierMove1.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                '@失敗ﾒｯｾｰｼﾞ表示("キャリアIDが設定されていません。設定を見直してください。")
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, lstrCaption, True, 16)
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If
            
            '@移載先１ﾛｯﾄIDの入力ﾁｪｯｸ
            If lblLotIDMove1.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0022)
                '@失敗ﾒｯｾｰｼﾞ表示("ロットIDが設定されていません。設定を見直してください。")
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, lstrCaption, True, 16)
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If
            
            '@移載先ﾛｯﾄ件数
            llngMoveCnt = 1
            
            With vsfSlotMap
                '@移載先１のｽﾛｯﾄﾏｯﾌﾟ最下段まで
                For llngCnt = .Rows.Fixed To .Rows.Count - 1
                    '@WFIDがある場合
                    If .GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                        Exit For
                    End If
                Next llngCnt
                '@WFが1枚もない場合
                If llngCnt >= .Rows.Count Then
                    Exit Function
                End If
            End With
            
            With vsfSlotMapMove
                '@移載先２のｽﾛｯﾄﾏｯﾌﾟ最下段まで
                For llngCnt = .Rows.Fixed To .Rows.Count - 1
                    '@WFIDがある場合
                    If .GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                        Exit For
                    End If
                Next llngCnt
            End With
            
            '@移載先２のWFが1枚もない場合
            If llngCnt >= vsfSlotMapMove.Rows.Count Then
                prvblnRegist_Chk = True
                Exit Function
            End If
            '@移載先２ｷｬﾘｱIDの入力ﾁｪｯｸ
            If lblCarrierMove2.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0001)
                '@失敗ﾒｯｾｰｼﾞ表示("キャリアIDが設定されていません。設定を見直してください。")
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, lstrCaption, True, 16)
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If
            
            '@移載先２ﾛｯﾄIDの入力ﾁｪｯｸ
            If lblLotIDMove2.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0022)
                '@失敗ﾒｯｾｰｼﾞ表示("ロットIDが設定されていません。設定を見直してください。")
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, lstrCaption, True, 16)
                Call pubSetFocus(txtCarrier)
                Exit Function
            End If
            
            '@移載先ﾛｯﾄ件数
            llngMoveCnt = 2
                    
            '@入力OK
            prvblnRegist_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnRegist_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvWfCarryFlag1_Proc
    '機　能：移載元ｷｬﾘｱIDﾌｫｰｶｽﾛｽﾄ時、WF移載ﾌﾗｸﾞが1(移載必要)の場合の処理
    '引　数：ltypInvmoveinfo：ﾛｯﾄ移載情報取得構造体
    '戻り値：なし
    '作成日：2004/06/08 (Tue) 12:48:57 Y.Yamagishi
    '更新日：2004/09/01 (Wed) 15:45:08 N.Kasai
    '備　考：2004/09/01 (Wed) 15:45:08 N.Kasai 移載の条件判定を削除(ｷｬﾘｱID入力時、ｻｰﾊﾞで行う為、ｸﾗｲｱﾝﾄでは必要なし)
    Private Sub prvWfCarryFlag1_Proc(ByRef ltypInvmoveinfo As InvMoveInfo)

        Dim llngCnt                         As Integer              'ｶｳﾝﾄ数

        Try
            
            '@ﾛｯﾄｲﾍﾞﾝﾄIDの確認
            Select Case mstrLotEventID
            
                '@分割
                Case CMlngLotEventIDD
                    '@ｽﾛｯﾄ情報表示(分割)
                    Call prvVsfSlotMapDivide_Disp(ltypInvmoveinfo)
                    '@移載区分を設定
                    lblMoveClass.Text = CMstrDivide
                    With ltypInvmoveinfo
                        '@WFﾘｽﾄのﾙｰﾌﾟ
                        For llngCnt = 0 To .lngWfListCnt - 1
                            '@分割/統合先ﾛｯﾄIDの判定
                            If .typInvMoveInfoWFList(llngCnt).strDivideCombineLotID <> vbNullString Then
                                Exit For
                            End If
                        Next llngCnt
                    End With
            
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvWfCarryFlag1_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvWfCarryFlag0_Proc
    '機　能：移載元ｷｬﾘｱIDﾌｫｰｶｽﾛｽﾄ時、WF移載ﾌﾗｸﾞが0(移載不要)の場合の処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/08 (Tue) 12:48:57 Y.Yamagishi
    '更新日：2004/06/08 (Tue) 12:49:12 Y.Yamagishi
    '備　考：
    Private Sub prvWfCarryFlag0_Proc()

        Try
            
            '@0(不要)の場合
            '@ﾚｽﾎﾟﾝｽ測定中止
            Call pubResponseCancel(CMstrReseponseFormName, mstrEventName)
            
            '@表示ﾒｯｾｰｼﾞ変換
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0066, txtCarrier.Text)
            '@"メッセージコード：C_I66%0$$このキャリア[ %1 ]は移載予約されていません。"
            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
            '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrier)
            '@ﾊｲﾗｲﾄ
            Call pubHighlight(txtCarrier)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvWfCarryFlag0_Proc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmdRegist_chk
    '機　能：確定ﾎﾞﾀﾝ押下可能ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/11 (Wed) 18:04:47 Y.Yamagishi
    '更新日：2004/08/11 (Wed) 18:04:47
    '備　考：
    Private Sub prvcmdRegist_Chk(Optional ByVal lblnFocus As Boolean = True)
        
        Dim lblnFlg                 As Boolean           'ｽﾛｯﾄﾏｯﾌﾟ値格納ﾌﾗｸﾞ
        Dim lblnSlot1Flg            As Boolean           'ｽﾛｯﾄﾏｯﾌﾟ値格納ﾌﾗｸﾞ
        Dim llngCnt                 As Integer           'ｶｳﾝﾄ

        Try
            
            lblnFlg = True
            
            '@ｷｬﾘｱIDの入力ﾁｪｯｸ
            If txtCarrier.Text = vbNullString Then
                lblnFlg = False
            End If
            
            '@ｷｬﾘｱIDが6桁であるかﾁｪｯｸ
            If Len(txtCarrier.Text) <> CMlngMaxByte Then
                lblnFlg = False
            End If
            
            '@移載先１ｷｬﾘｱIDの入力ﾁｪｯｸ
            If lblCarrierMove1.Text = vbNullString Then
                lblnFlg = False
            End If
            
            '@移載先１ﾛｯﾄIDの入力ﾁｪｯｸ
            If lblLotIDMove1.Text = vbNullString Then
                lblnFlg = False
            End If
            
            '@移載先1ﾌﾗｸﾞ(WFなし)
            lblnSlot1Flg = False
            If lblnFlg = True Then
                With vsfSlotMap
                    '@移載先１のｽﾛｯﾄﾏｯﾌﾟ最下段まで
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@WFIDがある場合
                        If .GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                            Exit For
                        End If
                    Next llngCnt
                    '@WFが1枚もない場合
                    If llngCnt >= .Rows.Count Then
                        lblnFlg = False
                    Else
                        '@移載先1ﾌﾗｸﾞ(WFあり)
                        lblnSlot1Flg = True

                    End If
                End With
            End If

            If lblnSlot1Flg = True And lblnFlg = True Then
                With vsfSlotMapMove
                    '@移載先２のｽﾛｯﾄﾏｯﾌﾟ最下段まで
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@WFIDがある場合
                        If .GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                            Exit For
                        End If
                    Next llngCnt
                End With
            
                '@移載先２のWFが1枚もない場合
                If llngCnt >= vsfSlotMapMove.Rows.Count Then
                Else
                    '@移載先２ｷｬﾘｱIDの入力ﾁｪｯｸ
                    If lblCarrierMove2.Text = vbNullString Then
                        lblnFlg = False
                    End If
                
                    '@移載先２ﾛｯﾄIDの入力ﾁｪｯｸ
                    If lblLotIDMove2.Text = vbNullString Then
                        lblnFlg = False
                    End If
                
                End If
            End If
            
            If lblnFlg = False Then
                '@確定ﾎﾞﾀﾝ無効
                cmdRegist.Enabled = False
                Exit Sub
            End If
            
            '@確定ﾎﾞﾀﾝ有効
            cmdRegist.Enabled = True
            If lblnFocus Then
                Call pubSetFocus(cmdRegist)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmdRegist_Chk"
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


    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Frame1.Paint, fraLot.Paint, fraLot2.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfSlotMap.BeforeDoubleClick, vsfSlotMapMove.BeforeDoubleClick

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
        End If

    End Sub

    '関数名：cursor_Enter
    '機　能 ： 項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考 ： Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles cmdClose.Enter, _
            cmdRegist.Enter, vsfSlotMap.Enter, vsfSlotMapMove.Enter, txtCarrier.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '自動Validate = OFF
            Case cmdClose.Name, cmdRegist.Name
                Me.AutoValidate = AutoValidate.Disable

            '自動Validate = ON
            Case Else
                Me.AutoValidate = AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

End Class
