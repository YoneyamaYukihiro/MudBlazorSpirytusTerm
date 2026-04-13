'ﾌｧｲﾙ名：xxEN0161.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ロット統合　メインフォーム
'作成日：2004/04/14 (Wed) 15:23:09 K.Takano
'更新日：2017/06/06 (Tue) 10:08:40 T.Oide
'備　考：
'　　　：2007/07/26 (Thu) 11:00:48 N.Kasai  ｿｰｽ整備
'Copyright(C)2003-2017, SEIKO EPSON CORPORATION.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN0161
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN0161    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN0161
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN0161
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN0161)
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
    Private Const CMstrLocalVersion             As String = "10.00"


    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN0220

    '@Msgﾊﾞｰｼﾞｮﾝ
    '@↓2020/01/15 (Wed) 14:09:29 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_curstateVer          As String = "03.04"         'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer          As String = "04.00"         'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 14:09:29 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrlot_combine_Ver          As String = "02.00"         'ﾛｯﾄ統合
    Private Const CMstrlot_waferlistVer         As String = "02.05"         'ﾛｯﾄWF情報取得(新)
    Private Const CMstrlot_combinedirectVer     As String = "02.00"         'ﾛｯﾄ統合(一括移載)
    Private Const CMstrlot_chkcombinerecipeVer  As String = "01.00"         'ﾛｯﾄ統合ﾚｼﾋﾟ状態ﾁｪｯｸ
    Private Const CMstrlot_chkcombineLotInVer   As String = "01.00"         'ﾛｯﾄ統合元ﾛｯﾄﾁｪｯｸ

    '@vsfSlotMapの定数宣言(ｶﾗﾑ)
    Private Const CMlngColSlot                  As Integer = 0              'ｽﾛｯﾄ
    Private Const CMlngColWFID                  As Integer = 1              'WFID
    Private Const CMlngColClass                 As Integer = 2              'WF状態
    '@↓2019/12/18 (Wed) 12:43:53 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngColGRB                   As Integer = 3              'GRB
    '@↑2019/12/18 (Wed) 12:43:53 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@vsfSlotMapの定数宣言(表示幅)
    Private Const CMlngColSlotWidth             As Integer = 19             'ｽﾛｯﾄ
    Private Const CMlngColWFIDWidth             As Integer = 80             'WFID
    Private Const CMlngColClassWidth            As Integer = 40             'WF状態
    '@↓2019/12/18 (Wed) 12:43:18 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMlngColGRBWidth              As Integer = 30             'GRB
    '@↑2019/12/18 (Wed) 12:43:18 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@vsfSlotMapの定数宣言(ﾀｲﾄﾙ)
    Private Const CMlngSlotMapRowTitle          As Integer = 0              'ｽﾛｯﾄﾏｯﾌﾟﾀｲﾄﾙ
    Private Const CMstrSlotMapColTSlot          As String = vbNullString    'ｽﾛｯﾄNO 
    Private Const CMstrSlotMapColTWFID          As String = "WFID"          'WFID
    Private Const CMstrSlotMapColTClass         As String = "状態"          'WF状態
    '@↓2019/12/18 (Wed) 12:42:35 Y.Yoneyama 「.Netへ反映未」 **************************************************
    Private Const CMstrSlotMapColTGRB           As String = "GRB"           'GRB
    '@↑2019/12/18 (Wed) 12:42:35 Y.Yoneyama 「.Netへ反映未」 **************************************************

    Private Const CMlngSlotHMaCellFontSize      As Integer = 9                 'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngSlotMapRowS              As Integer = 26                '行数
    Private Const CMlngSlotMapHeight            As Integer = 17                '1ｽﾛｯﾄの高さ
    Private Const CMlngLeftLength               As Integer = 7                 'ﾛｯﾄID比較文字数

    '@ﾃｷｽﾄ
    Private Const CMlngMaxDispMemoRow           As Integer = 3                 'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(作業ﾒﾓ)

    '@仮想ｷｬﾘｱ判断条件
    Private Const CMlngCarrierIDLeftStr         As Integer = 1                 'ｷｬﾘｱIDの左1文字
    Private Const CMstrDummyCarrierIDChk        As String = "I"             '仮想ｷｬﾘｱID識別文字列

    '@↓2017/06/06 (Tue) 10:49:37 T.Oide **************************************************
    Private Const CMstrResultOK                 As String = "OK"            '結果OK
    '@↑2017/06/06 (Tue) 10:49:37 T.Oide **************************************************

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mstrLotLastUpdate1                  As String                   '最終更新日時ﾛｯﾄ1
    Private mstrLotLastUpdate2                  As String                   '最終更新日時ﾛｯﾄ2
    Private mstrEventName                       As String                   'ﾚｽﾎﾟﾝｽ用ｲﾍﾞﾝﾄ名
    Private mblnTxtCarrierChange                As Boolean                  '編成元ｷｬﾘｱID変更ﾌﾗｸﾞ
    Private mblnTakeOverDispFlg                 As Boolean                  '引継ぎ表示ﾌﾗｸﾞ
    Private mstrPdID1                           As String                   '機種1格納用
    Private mstrPdID2                           As String                   '機種2格納用
    Private mblnEasyComb                        As Boolean                  '簡易統合ﾁｪｯｸ

    Private buttonProcessing                    As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                  'NSYS システムコマンドでの画面クローズ
    Private blnKeepNonRedraw                    As Boolean                  'NSYS validateによる画面ちらつき回避ﾌﾗｸﾞ
    Private mblnWindowClose                     As Boolean                  'NSYS WindowCloseフラグ

    Private ReadOnly vbButtonFace As Color = SystemColors.ControlLight      'NSYS ボタンの背景色
    Private ReadOnly vbWhite                    As Color = Color.White      'NSYS vbWhite定義
    Private ReadOnly vbYellow                   As Color = Color.Yellow     'NSYS vbYellow定義

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
    '機　能：ACT初期設定および初期情報設定
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 15:28:15 K.Takano
    '更新日：2004/04/14 (Wed) 15:28:15
    '備　考：
    Private Sub Form_Load()
        
        Dim lblnAns                 As Boolean          '戻り値

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN0220, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                Call pubMenuExpand_Disp()
                '@ﾌｫｰﾑを閉じる
                Me.Close
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                Exit Sub
            End If
            
            '@ﾌｫｰﾑの初期化
            Call prvfrmxxEN0161_Init(True)
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
            
            '@引継ぎ情報表示済みﾌﾗｸﾞ
            mblnTakeOverDispFlg = False

            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

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
    '作成日：2004/07/27 (Tue) 16:27:20 H.Wajima
    '更新日：2004/07/27 (Tue) 16:27:20
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

            '@簡易統合識別ﾌﾗｸﾞを初期化
            mblnEasyComb = False

            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose

            '@引数のｷｬﾘｱIDが空白かどうか判定する
            If ptypCommonInfo.strCarrierId <> vbNullString Then
            '@空白でない場合
                '@ｷｬﾘｱIDの初期値を設定する
                txtCarrier.Text = ptypCommonInfo.strCarrierId
                mblnEasyComb = pblnfrmxxEN0100kbn
                '@ｷｬﾘｱIDの情報表示
                RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(False))
                AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
            Else
            '@空白の場合
                '@装置別ﾛｯﾄ一覧用  ｷｬﾘｱID初期化
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
    '機　能：ﾌｫｰｶｽ制御
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｷｰｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 18:15:27 K.Takano
    '更新日：2004/04/14 (Wed) 18:15:27
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

            '@Enterｷｰ処理
            Select Case e.KeyCode
                '@Enterｷｰの場合
                Case Keys.Return
                    
                    '@ｺﾒﾝﾄ制御
                    If ActiveControl.Name = "txtWorkMemo" Then
                        '@改行処理はしない
                        Exit Sub
                    End If
                    
                    '@ｷｬﾘｱID
                    If ActiveControl.Name = "txtCarrier" Then
                        '@ｷｬﾘｱID処理
                        RemoveHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                        Call txtCarrier_Validate(txtCarrier, New CancelEventArgs(True))
                        AddHandler txtCarrier.Validating, AddressOf txtCarrier_Validate
                        Exit Sub
                    End If
                    
                    '@その他ｺﾝﾄﾛｰﾙ
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

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/04/28 (Wed) 10:34:52 K.Takano
    '更新日：2004/11/01 (Mon) 16:16:24 T.Kitagawa
    '備　考：2004/11/01 (Mon) 16:16:24 T.Kitagawa　閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender,e)
				AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            'NSYS 不要なﾊﾞﾘﾃﾞｰﾄ回避ﾌﾗｸﾞ
            mblnWindowClose = True
            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
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
        '↓ '09/07/01（Wed） 10:46:44 K.Nishizawa ***********************************
                If Not mblnEasyComb Then
                    '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                    Call pubMenuExpand_Disp()
                End If
            End If
            mblnEasyComb = False
        '↑ '09/07/01（Wed） 10:46:44 K.Nishizawa ***********************************
            
            '@ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄとの関連付けを解除

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
    '機　能：ﾌｫｰﾑを閉じる
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 15:35:17 K.Takano
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

            'NSYS 不要なﾊﾞﾘﾃﾞｰﾄ回避ﾌﾗｸﾞ
            mblnWindowClose = True

            
            '@引継ぎ情報のｷｬﾘｱIDが空白かどうか判定する
            If ptypCommonInfo.strCarrierId <> vbNullString Then
            '@空白でない場合
                '@親ﾌｫｰﾑから呼ばれた場合
                '@親画面切り替え引継ぎ制御
                If mblnEasyComb Then
                    Me.Close()
                Else
                    Call pubChangeScreen_Set(Me)
                End If
            Else
            '@空白の場合
                '@終了関数を実行する
                Call publngEnd_Proc(CPstrKeyEN0220, ltypCommonInfo)
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
    '機　能：統合予約処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/15 (Thu) 11:43:46 K.Takano
    '更新日：2017/06/06 (Tue) 10:08:24 T.Oide
    '備　考：
    '　　　：2005/04/01 (Fri) 08:58:01 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2005/06/07 (Tue) 18:39:32 N.Kojima     機種のﾁｪｯｸ処理追加(運用不具合№395)
    '　　　：2009/08/10 (Mon) 17:57:44 N.Kojima     試作実験ﾛｯﾄの場合、確定時に検査工数削減のMsgを表示する。(案件№03542)
    '　　　：2010/06/21 (Mon) 15:33:52 T.Oide       No.04022対応、分割前の枚葉ﾚｼﾋﾟなしﾁｪｯｸ追加
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnAns                 As Boolean              '戻り値(True:正常,False:異常)
        Dim ltyplotcombine          As Lotcombine           'Lot統合(要求)
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrCarrierID           As String               'ﾒｯｾｰｼﾞ用ｷｬﾘｱID格納
        Dim lstrMsg                 As String               '成功ﾒｯｾｰｼﾞ文字
        Dim ltypChkCombineRecipe    As typChkCombineRecipe  '送受信ﾒｯｾｰｼﾞ格納
        Dim llngMsgAns              As String               'ﾒｯｾｰｼﾞﾎﾞｯｸｽ結果格納
        Dim ltypChkCombineLotIn     As typChkCombineLotIn   'ﾛｯﾄ統合時ﾁｪｯｸの送受信ﾒｯｾｰｼﾞ格納

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
            
            '@画面項目ﾁｪｯｸ
            lblnAns = prvblnInput_Chk()
            If lblnAns = False Then
                '@不正項目あり
                Exit Sub
            End If

            '@↓2019/12/24 (Tue) 13:12:10 Y.Yoneyama 「.Netへ反映未」 **************************************************
            '@=======================
            '@ WF.GRBﾁｪｯｸ
            '@=======================
            lblnAns = prvblnGRB_Chk()
    
            If lblnAns = False Then
                Exit Sub
            End If
            '@↑2019/12/24 (Tue) 13:12:10 Y.Yoneyama 「.Netへ反映未」 **************************************************

            '構造体に値をｾｯﾄ
            With ltypChkCombineRecipe
                .strSbID = pstrSBID
                .strLotID = lblLotID.Text
                .strDivLotID = lblLotID2.Text
            End With
            
            '@***********************
            '@ 分割前に枚葉ﾚｼﾋﾟが全て空になる工程が無いかﾁｪｯｸ
            '@***********************
            lblnAns = prvblnCombineRecipeNull_Chk(CMstrlot_chkcombinerecipeVer, ltypChkCombineRecipe)
            
            '@確定時ﾁｪｯｸ処理結果が"False：ﾁｪｯｸNG"か
            If lblnAns = False Then
                Exit Sub
            End If
            
            '@ﾒｯｾｰｼﾞがある場合継続or中断のﾒｯｾｰｼﾞ表示
            If ltypChkCombineRecipe.strMsgCode <> vbNullString Then
            
                '@"<MESI0001>$$レシピが未設定な工程が存在しますが、[ロット分割]を実行しますか....
                pstrDMsg = pubstrMsgReplace_Set(CPstrStartMsgCode & ltypChkCombineRecipe.strMsgCode & _
                                                CPstrEndMsgCode & CPstrMsgCrCode & ltypChkCombineRecipe.strMsg)
                llngMsgAns = publngMsgBoxInfo(pstrDMsg, vbNo, Me.Text, True, 16)
            
                '@結果確認
                If llngMsgAns = vbNo Then
                    '@いいえの場合は処理中止
                    Exit Sub
                End If
                
            End If

        '@↓2017/06/06 (Tue) 10:08:12 T.Oide **************************************************
            '@ 組立工程の場合、組立投入時のﾛｯﾄが同一ﾛｯﾄか確認
            If pstrSBID = CPstrSBID2A0 Then
                
                '@構造体に値をｾｯﾄ
                With ltypChkCombineLotIn
                    .strSbID = pstrSBID
                    '@画面上のの2ﾛｯﾄのｳｪﾊｰﾘｽﾄをltypChkCombineLotInに格納
                    Call prvWaferListSet(vsfSlotMap, ltypChkCombineLotIn)   '画面左のﾛｯﾄのｳｪﾊｰﾘｽﾄｾｯﾄ
                    Call prvWaferListSet(vsfSlotMap2, ltypChkCombineLotIn)  '画面右のﾛｯﾄのｳｪﾊｰﾘｽﾄｾｯﾄ
                    
                    '@再利用WFか否かの判定ﾌﾗｸﾞｾｯﾄ(ﾛｯﾄとWFの先頭7文字が同一か
                    If Mid$(.strWfList(1), 1, 7) = Mid$(lblLotID.Text, 1, 7) Then
                        '@再利用ﾛｯﾄじゃない
                        .strRecyclFlag = "0"
                    Else
                        '@再利用ﾛｯﾄである
                        .strRecyclFlag = "1"
                    End If
                    
                End With
                
                '@ 投入時のﾛｯﾄが共通か確認
                lblnAns = prvblnCombineInLot_Chk(CMstrlot_chkcombineLotInVer, ltypChkCombineLotIn)
                
                '@確定時ﾁｪｯｸ処理結果が"False：ﾁｪｯｸNG"か(関数自体の失敗成功ﾁｪｯｸ)
                If lblnAns = False Then
                    Exit Sub
                End If
                
                '@投入元ﾛｯﾄは同じかの確認結果は、OK以外か(統合OK/NGのﾁｪｯｸ)
                If ltypChkCombineLotIn.strResult <> CMstrResultOK Then
                    
                    '@"<TRM146W>$$[%1]投入時のロットが異なるため統合できません。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0146, CPstrSBID2A0Name)
                    '@警告ﾒｯｾｰｼﾞ
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@確定ﾎﾞﾀﾝ無効変更
                    cmdRegist.Enabled = False
                    
                    Exit Sub
                    
                End If
            End If
        '@↑2017/06/06 (Tue) 10:08:12 T.Oide **************************************************

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
            If pstrUserID = vbNullString Then
                '@未入力の場合中止
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            mstrEventName = "cmdRegist_Click"
            Call pubResponseStart(Me.Name, mstrEventName)
            
            '@ﾌｫｰﾑﾛｯｸ
            'Me.Enabled = False
            
            '@ﾛｯﾄ統合ﾃﾞｰﾀ作成
            With ltyplotcombine
                
                '@移載工程ｽｷｯﾌﾟの場合
                If chkMoveSkip.Checked = False Then
                    .strMsgVer = CMstrlot_combine_Ver           '移載工程あり
                Else
                    .strMsgVer = CMstrlot_combinedirectVer      '移載工程なし
                End If
                
                .strLotID1 = lblLotID.Text                   'ﾛｯﾄID(1)
                .strLotID2 = lblLotID2.Text                  'ﾛｯﾄID(2)
                .strLotLastUpdate1 = mstrLotLastUpdate1         '最終更新日時(1)
                .strLotLastUpdate2 = mstrLotLastUpdate2         '最終更新日時(2)
                .strComments = txtWorkMemo.Text                 'ﾛｯﾄ統合ﾒﾓ(作業ﾒﾓ)
                .strEmpID = pstrUserID                          '作業者ID
            End With
            
            '@移載工程ｽｷｯﾌﾟの場合
            If chkMoveSkip.Checked = False Then
                '@ﾒｯｾｰｼﾞ送信【ﾛｯﾄ統合】
                lblnAns = pubblnLotCombine_Upd(ltyplotcombine, lstrGuidMsg, lstrGuidMsgCode)
                lstrMsg = "ロット統合予約"
            Else
                '@ﾒｯｾｰｼﾞ送信【ﾛｯﾄ統合(一括移載)】
                lblnAns = pubblnLotCombineDirect_Upd(ltyplotcombine, lstrGuidMsg, lstrGuidMsgCode)
                lstrMsg = "ロット統合"
            End If
            
            '@結果判定
            If lblnAns = True Then
                '@ﾌｫｰﾑﾛｯｸ解除
                'Me.Enabled = True
                 '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(Me.Name, mstrEventName)
                
                '@ｶﾞｲﾀﾞﾝｽﾒｯｾｰｼﾞ表示制御
                Call pubGuidMsg_Set(lstrGuidMsgCode, lstrGuidMsg, Me)
            
                '@成功ﾒｯｾｰｼﾞ用ｷｬﾘｱID取得処理(応答Msgのﾛｯﾄと紐付くｷｬﾘｱを取得)
                If ltyplotcombine.strCombineLotID = lblLotID.Text Then
                    lstrCarrierID = txtCarrier.Text
                Else
                    lstrCarrierID = txtCarrier2.Text
                End If
                
                '@"<TRM55I>$$[%1]しました。統合先キャリア[%2] 統合先ロット[%3]"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0055, lstrMsg, lstrCarrierID, ltyplotcombine.strCombineLotID)
                '@成功ﾒｯｾｰｼﾞ
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@起動SBが"1A0：基板"、かつ移載工程ｽｷｯﾌﾟか(♪移載工程ｽｷｯﾌﾟの場合はこのﾀｲﾐﾝｸﾞで表示)
                If pstrSBID = CPstrSBID1A0 And chkMoveSkip.Checked = True Then
            
                    '@ﾛｯﾄの種別が"試作/実験品：GG,TS,WS,ZZ"か
                    If lblFlowClass.Text = CPstrFlowClassGG Or _
                        lblFlowClass.Text = CPstrFlowClassTS Or _
                        lblFlowClass.Text = CPstrFlowClassWS Or _
                        lblFlowClass.Text = CPstrFlowClassZZ Then
                        
                        '@表示ﾒｯｾｰｼﾞを編集(統合先ロット[XXX])
                        lstrMsg = CPstrCombineTo & CPstrBrLeft & lblLotID.Text & CPstrBrRight
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        '@"<TRM1ZI>$$%1が[%2]されました。$必要に応じて外観・現像検査工程の
                        '@ 検査ウェハ枚数を見直して下さい。$%3 %4"のﾒｯｾｰｼﾞ表示
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0025, CPstrLot, CPstrCombine, lstrMsg, vbNullString)
                        Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                    End If
                End If

                '@画面の初期化
                Call prvfrmxxEN0161_Init(True)
                
                '@簡易統合の場合、ﾌｫｰﾑを戻す
                If mblnEasyComb Then
                    Me.Close()
                End If

            Else
                '@ﾌｫｰﾑﾛｯｸ解除
                'Me.Enabled = True
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, mstrEventName)
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
    '機　能：ｷｬﾘｱ変更時処理(1)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 18:32:45 K.Takano
    '更新日：2004/04/14 (Wed) 18:32:45
    '備　考：
    Private Sub txtCarrier_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier.Change

        Try
            
            '@画面初期化
            Call prvfrmxxEN0161_Init(False, True, False)
            
            '@変更ﾌﾗｸﾞｾｯﾄ
            mblnTxtCarrierChange = True
            
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

    '関数名：txtCarrier2_Change
    '機　能：ｷｬﾘｱ変更時処理(2)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/15 (Thu) 11:05:46 K.Takano
    '更新日：2004/04/15 (Thu) 11:05:46
    '備　考：
    Private Sub txtCarrier2_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrier2.Change

        Try
            
            '@画面初期化
            Call prvfrmxxEN0161_Init(False, False, True)
            
            '@変更ﾌﾗｸﾞｾｯﾄ
            mblnTxtCarrierChange = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrier2_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoUp_Click
    '機　能：ｺﾒﾝﾄの前頁切替処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/15 (Thu) 14:15:45 K.Takano
    '更新日：2005/12/02 (Fri) 13:16:24 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 13:16:24 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdMemoUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)

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
    '機　能：ｺﾒﾝﾄの次頁切替処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/15 (Thu) 14:15:49 K.Takano
    '更新日：2005/12/02 (Fri) 13:17:27 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 13:17:27 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdMemoDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)

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
    '機　能：ｷｬﾘｱIDﾌｫｰｶｽﾛｽﾄ時処理(1)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/04/14 (Wed) 18:34:12 K.Takano
    '更新日：2005/06/07 (Tue) 18:35:37 N.Kojima
    '備　考：
    '　　　：2004/09/24 (Fri) 14:49:01 Y.Yamagishi  変更ﾌﾗｸﾞｾｯﾄの位置変更
    '　　　：2005/06/07 (Tue) 18:35:37 N.Kojima     機種退避処理追加(運用不具合№395)
    Public Sub txtCarrier_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier.Validating

        Dim lblnAns                         As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrCarriaName                  As String               'ｷｬﾘｱID欄名
        Dim ltypLotCurState                 As Lotprestate          'ﾛｯﾄ現在状態格納構造体
        Dim ltypWaferList                   As Waferlist            'WF情報格納用構造体

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@投入予定ｷｬﾘｱIDの桁ﾁｪｯｸ
            If LenB(txtCarrier.Text) < CPlngCarrierMaxLength And _
               txtCarrier.Text <> vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                
                '@"C_WAR0007　ｷｬﾘｱIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽそのまま
                e.Cancel = True
                
                '@ｷｬﾘｱIDのﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtCarrier)
                
                Exit Sub
            End If

            '@ｷｬﾘｱIDが無変更の場合
            If mblnTxtCarrierChange = False Then

                If ActiveControl.Name = txtCarrier.Name Then
                    '@統合ﾛｯﾄ2のｷｬﾘｱIDが有効の場合
                    If chkMoveSkip.Enabled = True Then
                        '@移載工程ｽｷｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(chkMoveSkip)
                    Else
                        '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
                End If

                Exit Sub
            End If



			lstrCarriaName = txtCarrier.Text

            '@ｽﾛｯﾄﾏｯﾌﾟの初期化
            Call prvvsfSlotMap_init(vsfSlotMap)     'VSFlexGrid(1)

            '@ｷｬﾘｱID情報の取得
            If Trim(lstrCarriaName) <> vbNullString And _
               Len(Trim(lstrCarriaName)) = txtCarrier.ChrMaxByte Then
                '@ﾚｽﾎﾟﾝｽ測定開始
                mstrEventName = "txtCarrier_Validate"
                Call pubResponseStart(Me.Name, mstrEventName)

                '@DBからﾛｯﾄ情報の取得
                lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, CPstrCD1B, lstrCarriaName, ltypLotCurState)
                '@結果判定
                If lblnAns = True Then
                    '@画面表示処理(1)
                    With ltypLotCurState
                        lblLotID.Text = .strLotID               'ﾛｯﾄID
                        lblFlowClass.Text = .strFlowClass       '流動区分
                        lblOpID.Text = .strOpID                 '大工程
                        lblStepID.Text = .strStepID             '小工程
                        lblStatus.Text = .strNowST              '状態
                        mstrLotLastUpdate1 = .strLotLastUpdate  '最終更新日時ﾛｯﾄ1(1)
                        mstrPdID1 = .strPdId                    '機種
                        '@↓2019/12/18 (Wed) 13:42:42 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        lblGRB.Text = .strGRBClass              'GRB
                        '@GRB背景色
                        lblGRB.BackColor = pubGRBBackColor(.strGRBClass, lblLotID.BackColor)
                        '@↑2019/12/18 (Wed) 13:42:42 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    End With

                    '@ﾛｯﾄWF情報取得
                    lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, txtCarrier.Text, CPstrCD0T, ltypWaferList)
                    '@結果確認
                    If lblnAns = True Then
                        '@取得OKなら結果表示
                        Call prvVsfSlotMap_Disp(ltypWaferList, vsfSlotMap)

                        '@↓2020/02/21 (Fri) 17:06:33 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        '@防湿ALD
                        If pstrSBID = CPstrSBID3A0 Then
                            chkMoveSkip.Checked = True
                            chkMoveSkip.Enabled = False
                        Else
                            '@移載工程ｽｷｯﾌﾟﾁｪｯｸ使用可
                            chkMoveSkip.Enabled = True
                        End If
                        '@↑2020/02/21 (Fri) 17:06:33 Y.Yoneyama 「.Netへ反映未」 **************************************************

                        '@移載工程ｽｷｯﾌﾟﾁｪｯｸ使用可
                        chkMoveSkip.Enabled = True
                        
                        '@作業ﾒﾓ使用可
                        txtWorkMemo.Enabled = True
                        
                        '@変更ﾌﾗｸﾞｾｯﾄ
                        mblnTxtCarrierChange = False    '無変更

                        '@ﾚｽﾎﾟﾝｽ測定終了
                        Call publngResponseEnd(Me.Name, mstrEventName)
                        
                        If ActiveControl.Name = txtCarrier.Name Then
                            '@統合ﾛｯﾄ2のｷｬﾘｱIDが有効の場合
                            If chkMoveSkip.Enabled = True Then
                                '@移載工程ｽｷｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(chkMoveSkip)
                            Else
                                '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                                Call pubSetFocus(cmdClose)
                            End If
                        End If
                        
                    Else
                        '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                        e.Cancel = True
                    End If

                Else
                    '@ﾚｽﾎﾟﾝｽ測定中止
                    Call pubResponseCancel(Me.Name, mstrEventName)
                    
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                End If
            Else
               
                '@画面初期化
                Call prvfrmxxEN0161_Init(False, True, False)
                
                If ActiveControl.Name = txtCarrier.Name Then
                    '@統合ﾛｯﾄ2のｷｬﾘｱIDが有効の場合
                    If chkMoveSkip.Enabled = True Then
                        '@移載工程ｽｷｯﾌﾟにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(chkMoveSkip)
                    Else
                        '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
                End If
                
            End If
            
            '簡易統合の場合は分割ﾛｯﾄも呼び出す
            If mblnEasyComb Then
                txtCarrier2.Text = pstrToCarrierID
                RemoveHandler txtCarrier2.Validating, AddressOf txtCarrier2_Validate
                Call txtCarrier2_Validate(txtCarrier2, New CancelEventArgs(False))
                AddHandler txtCarrier2.Validating, AddressOf txtCarrier2_Validate
                If Strings.Left$(pstrToCarrierID, CMlngCarrierIDLeftStr) = CMstrDummyCarrierIDChk Then
                    chkMoveSkip.Checked = True
                    chkMoveSkip.Enabled = False
                End If
            End If

			If Strings.Left$(txtCarrier.Text, CMlngCarrierIDLeftStr) = CMstrDummyCarrierIDChk Then
				'@ｷｬﾘｱが"仮想ｷｬﾘｱ(左1桁が"I")"の場合は移載工程スキップにチェックを入れる
				chkMoveSkip.Checked = True
                chkMoveSkip.Enabled = False

			End If

            '@確定ﾎﾞﾀﾝﾁｪｯｸ
            Call prvcmdRegistEnabled_Chk()

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

    '関数名：txtCarrier2_Validate
    '機　能：ｷｬﾘｱIDﾌｫｰｶｽﾛｽﾄ時処理(2)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/04/15 (Thu) 11:29:58 K.Takano
    '更新日：2005/06/07 (Tue) 18:38:23 N.Kojima
    '備　考：
    '　　　：2004/09/24 (Fri) 14:46:41 Y.Yamagishi  変更ﾌﾗｸﾞｾｯﾄの位置を変更
    '　　　：2004/12/10 (Fri) 09:05:08 N.Kasai      ｴﾗｰ判定でﾌｫｰｶｽの制御を追加
    '　　　：2005/06/07 (Tue) 18:38:23 N.Kojima     機種退避処理追加(運用不具合№395)
    Public Sub txtCarrier2_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrier2.Validating
        
        Dim lblnAns                         As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrCarriaName                  As String               'ｷｬﾘｱID欄名
        Dim ltypLotCurState                 As Lotprestate          'ﾛｯﾄ現在状態格納構造体
        Dim ltypWaferList                   As Waferlist            'WF情報格納用構造体

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@空白の場合はﾁｪｯｸしない
            If txtCarrier2.Text = vbNullString Then
                Exit Sub
            End If
            
            '@投入予定ｷｬﾘｱIDの桁ﾁｪｯｸ
            If LenB(txtCarrier2.Text) < CPlngCarrierMaxLength _
               And txtCarrier2.Text <> vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                
                '@"C_WAR0007　ｷｬﾘｱIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ｽﾛｯﾄﾏｯﾌﾟの初期化
                e.Cancel = True
                
                Call pubSetFocus(txtCarrier2)
                
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDが無変更の場合
            If mblnTxtCarrierChange = False Then
                '@何もしないで抜ける
                Exit Sub
            End If
            lstrCarriaName = txtCarrier2.Text
            
            '@ｽﾛｯﾄﾏｯﾌﾟの初期化
            Call prvvsfSlotMap_init(vsfSlotMap2)     'VSFlexGrid(1)
            
            '@ｷｬﾘｱID情報の取得
            If Trim$(lstrCarriaName) <> vbNullString And _
               Len(Trim(lstrCarriaName)) = txtCarrier2.ChrMaxByte Then
                '@ﾚｽﾎﾟﾝｽ測定開始
                mstrEventName = "txtCarrier2_Validate"
                Call pubResponseStart(Me.Name, mstrEventName)
                
                '@DBからﾛｯﾄ情報の取得
                lblnAns = pubblnLotCurstate_Sel(CMstrlot_curstateVer, CPstrCD1B, lstrCarriaName, ltypLotCurState)
                '@結果判定
                If lblnAns = True Then
                    
                    '@画面表示処理(2)
                    With ltypLotCurState
                        lblLotID2.Text = .strLotID              'ﾛｯﾄID
                        lblFlowClass2.Text = .strFlowClass      '流動区分
                        lblOpID2.Text = .strOpID                '大工程
                        lblStepID2.Text = .strStepID            '小工程
                        lblStatus2.Text = .strNowST             '状態
                        mstrLotLastUpdate2 = .strLotLastUpdate  '最終更新日時ﾛｯﾄ2(2)
                        mstrPdID2 = .strPdId                    '機種
                        '@↓2019/12/18 (Wed) 13:43:12 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        lblGRB2.Text = .strGRBClass             'GRB
                        '@GRB背景色
                        lblGRB2.BackColor = pubGRBBackColor(.strGRBClass, lblLotID2.BackColor)
                        '@↑2019/12/18 (Wed) 13:43:12 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    End With
                    
                    '@ﾛｯﾄWF情報取得
                    lblnAns = pubblnLotWaferList_Sel(CMstrlot_waferlistVer, txtCarrier2.Text, CPstrCD0T, ltypWaferList)
                    '@結果確認
                    If lblnAns = True Then
                        '@取得OKなら結果表示
                        Call prvVsfSlotMap_Disp(ltypWaferList, vsfSlotMap2)
                        
                        '@変更ﾌﾗｸﾞｾｯﾄ
                        mblnTxtCarrierChange = False    '無変更
            
                        '@ﾚｽﾎﾟﾝｽ測定終了
                        Call publngResponseEnd(Me.Name, mstrEventName)
                    Else
                        '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                        e.Cancel = True
                        If mblnEasyComb Then
                            Me.Close()
                            Exit Sub
                        End If
                    End If
                    
                    '@状態ﾁｪｯｸ→ｽﾃｰﾀｽﾊﾞｰへ表示
                    If lblStatus2.Text <> CPstrWaitWorkSt And _
                       lblStatus2.Text <> CPstrEndWorkSt Then
                        '@警告ﾒｯｾｰｼﾞ
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0056, txtCarrier2.Text, lblLotID2.Text)
                        '@pubVsfInfo_Disp("「作業待ち」、「作業終了」以外のﾛｯﾄ[ %2 ]は統合できません。$キャリア[ %1 ]")
                        Call pubVsfInfo_Disp(pstrDMsg)
                        
                        '@ﾚｽﾎﾟﾝｽ測定中止
                        Call pubResponseCancel(Me.Name, mstrEventName)
                        If mblnEasyComb Then
                            Me.Close()
                            Exit Sub
                        End If
                    End If
                Else
                    '@ﾚｽﾎﾟﾝｽ測定中止
                    Call pubResponseCancel(Me.Name, mstrEventName)
                    
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    
        '@↓ '09/07/01（Wed） K.Nishizawa ************************************************
                    If mblnEasyComb Then
                        Me.Close()
                        Exit Sub
                    End If
        '@↑ '09/07/01（Wed） K.Nishizawa ************************************************
                End If
            Else
                '@画面初期化
                Call prvfrmxxEN0161_Init(False, False, True)
            End If

			If Strings.Left$(txtCarrier2.Text, CMlngCarrierIDLeftStr) = CMstrDummyCarrierIDChk Then
				'@ｷｬﾘｱが"仮想ｷｬﾘｱ(左1桁が"I")"の場合は移載工程スキップにチェックを入れる
				chkMoveSkip.Checked = True
                chkMoveSkip.Enabled = False
			End If
            
            '@確定ﾎﾞﾀﾝﾁｪｯｸ
            lblnAns = prvcmdRegistEnabled_Chk
            '@結果判定
            If lblnAns = False Then
                '@変更ﾌﾗｸﾞｾｯﾄ
                mblnTxtCarrierChange = True    '変更あり
                '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                e.Cancel = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrier2_Validate"
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
    '関数名：prvfrmxxEN0161_Init
    '機　能：ﾌｫｰﾑの初期化
    '引　数：lblnAllClear：True:全ての項目を削除 False:lblnCarrier、lblnCarrier2依存
    '　　　：lblnCarrier ：True:統合ﾛｯﾄ1情報をｷｬﾘｱIDを残して削除 False:統合ﾛｯﾄ1情報保持
    '　　　：lblnCarrier2：True:統合ﾛｯﾄ2情報をｷｬﾘｱIDを残して削除 False:統合ﾛｯﾄ2情報保持
    '戻り値：なし
    '作成日：2004/04/19 (Mon) 16:48:13 K.Takano
    '更新日：2004/11/24 (Wed) 10:02:14 N.Kasai
    '備　考：2004/10/04 (Mon) 14:14:52 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2004/11/24 (Wed) 10:02:14 N.Kasai      ｴﾝﾄﾘIDの初期化を追加
    Private Sub prvfrmxxEN0161_Init(ByVal lblnAllClear As Boolean, _
                                    Optional ByVal lblnCarrier As Boolean = True, _
                                    Optional ByVal lblnCarrier2 As Boolean = True)
        
        Dim lstrFormTitle       As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try

            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN0220, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@各ｺﾝﾄﾛｰﾙの初期化
            
            '@全情報の初期化確認
            If lblnAllClear = True Then
                '@初期値設定
                txtCarrier.Text = vbNullString                      'ｷｬﾘｱID(1)
                txtCarrier2.Text = vbNullString                     'ｷｬﾘｱID(2)
                lblnCarrier = True
                lblnCarrier2 = True
                
                '@作業ﾒﾓ初期化
                With txtWorkMemo
                    .ChrMaxByte = CPlngLotCommentsMaxByte
                    .Text = vbNullString
                    .Enabled = False
                    '@作業ﾒﾓﾊﾞｲﾄ数初期化
                    Call txtWorkMemo_Change(txtWorkMemo, New EventArgs)
                End With
                
                '@ﾁｪｯｸﾎﾞｯｸｽの初期化
                With chkMoveSkip
                    .Enabled = False
                    .Checked = False
                End With
            End If
            
            '@一部の項目を初期化する場合
            Select Case lblnCarrier
                '@ｷｬﾘｱID(1)だけ残して削除
                Case True
                    '@
                    lblLotID.Text = vbNullString            'ﾛｯﾄID(1)
                    lblFlowClass.Text = vbNullString        '流動区分(1)
                    lblOpID.Text = vbNullString             '大工程(1)
                    lblStepID.Text = vbNullString           '小工程(1)
                    lblStatus.Text = vbNullString           '状態(1)
                    mstrLotLastUpdate1 = vbNullString       '最終更新日時ﾛｯﾄ1(1)
                    '@↓2019/12/18 (Wed) 13:44:14 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    lblGRB.Text = vbNullString              'GRB
                    lblGRB.BackColor = lblLotID.BackColor
                    '@↑2019/12/18 (Wed) 13:44:14 Y.Yoneyama 「.Netへ反映未」 **************************************************

                    '@ｽﾛｯﾄﾏｯﾌﾟの初期化
                    Call prvvsfSlotMap_init(vsfSlotMap)     'VSFlexGrid(左)
                    
                '@全ての項目を残す
                Case False
                    '@(1)側の情報は全て保持
            End Select
                    
            Select Case lblnCarrier2
                '@ｷｬﾘｱID(2)だけ残して削除
                Case True
                    '@
                    lblLotID2.Text = vbNullString           'ﾛｯﾄID(2)
                    lblFlowClass2.Text = vbNullString       '流動区分(2)
                    lblOpID2.Text = vbNullString            '大工程(2)
                    lblStepID2.Text = vbNullString          '小工程(2)
                    lblStatus2.Text = vbNullString          '状態(2)
                    mstrLotLastUpdate2 = vbNullString       '最終更新日時ﾛｯﾄ2(2)
                    '@↓2019/12/18 (Wed) 13:44:35 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    lblGRB2.Text = vbNullString
                    lblGRB2.BackColor = lblLotID2.BackColor 'GRB
                    '@↑2019/12/18 (Wed) 13:44:35 Y.Yoneyama 「.Netへ反映未」 **************************************************

                    '@ｽﾛｯﾄﾏｯﾌﾟの初期化
                    Call prvvsfSlotMap_init(vsfSlotMap2)    'VSFlexGrid(右)
                    
                '@全ての項目を残す
                Case False
                    '@(2)側の情報は全て保持
            End Select
            
            '@確定ﾎﾞﾀﾝ有効確認
            Call prvcmdRegistEnabled_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN0161_Init"
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
    '作成日：2004/04/14 (Wed) 17:21:58 K.Takano
    '更新日：2004/04/14 (Wed) 17:21:58
    '備　考：
    Private Sub prvvsfSlotMap_init(ByRef lobjControl As C1FlexGrid)

        Dim llngCnt As Integer  'ｶｳﾝﾄ

        Dim cellRange   As CellRange            'NSYS 追加Sytle設定範囲
        Dim headerStyle As CellStyle            'NSYS ヘッダー用追加Style
        Dim slotNoStyle As CellStyle            'NSYS スロットNo.用追加Style

        Try
            
            '@VSFlexGridの場合にのみ初期化
            If TypeOf lobjControl Is C1FlexGrid Then

                '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
                With lobjControl
    
                    'NSYS @設定中の画面描画はしない
                    .Redraw = False

                    '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                    .Clear

                    '@一覧表設定
                    .Rows.Count = CMlngSlotMapRowS                                                      '行数
                    .BackColor = vbWhite
                    '@↓2019/12/18 (Wed) 13:31:29 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    '.Select(CMlngSlotMapRowTitle, CMlngColSlot, CMlngSlotMapRowTitle, CMlngColClass)    '表題
                    .Select(CMlngSlotMapRowTitle, CMlngColSlot, CMlngSlotMapRowTitle, CMlngColGRB)      '表題
                    '@↑2019/12/18 (Wed) 13:31:29 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    '.CellForeColor = vbYellow                                                          '文字色
                    '.CellBackColor = CPlngBlueColor                                                    '背景色
                    '.CellFontSize = CMlngSlotHMaCellFontSize                                           'ﾌｫﾝﾄｻｲｽﾞ
                    .Rows(CMlngSlotMapRowTitle).Height = CMlngSlotMapHeight                             '高さ
                    headerStyle = .Styles.Add("headerStyle")
                    headerStyle.ForeColor = Color.Yellow                                                '文字色
                    headerStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))  '背景色
                    '@WFIDのｾﾝﾀﾘﾝｸﾞ
                    headerStyle.TextAlign = TextAlignEnum.CenterCenter
                    With .Styles.Normal.Font
                        headerStyle.Font = New Font(.FontFamily, CMlngSlotHMaCellFontSize, .Style, .Unit, .GdiCharSet, .GdiVerticalFont)    'ﾌｫﾝﾄｻｲｽﾞ
                    End With
                    'cellRange = .GetCellRange(CMlngSlotMapRowTitle, CMlngColSlot, CMlngSlotMapRowTitle, CMlngColClass)
                    cellRange = .GetCellRange(CMlngSlotMapRowTitle, CMlngColSlot, CMlngSlotMapRowTitle, CMlngColGRB)
                    cellRange.Style = headerStyle
                    
                    '.Select(CMlngSlotMapRowTitle, CMlngColSlot, CMlngSlotMapRowTitle, CMlngColClass) '表題
                    
                    '@一覧表のSlot№設定
                    slotNoStyle = .Styles.Add("slotNoStyle")
                    For llngCnt = 1 To CMlngSlotMapRowS - 1
                        .Col = CMlngColSlot
                        .Row = llngCnt
                        .SetData(llngCnt, CMlngColSlot, CStr(Format$(CMlngSlotMapRowS - llngCnt, CPstrSlotNoFormat)))
                        .Rows(llngCnt).Height = CMlngSlotMapHeight
                        cellRange = .GetCellRange(llngCnt, CMlngColSlot, llngCnt, CMlngColSlot)
                        cellRange.Style = slotNoStyle
                    Next llngCnt

                    '@列幅、ﾀｲﾄﾙ設定
                    '@ｽﾛｯﾄID
                    .Cols(CMlngColSlot).Width = CMlngColSlotWidth
                    .SetData(CMlngSlotMapRowTitle, CMlngColSlot, CMstrSlotMapColTSlot)
                    '@WFID
                    .Cols(CMlngColWFID).Width = CMlngColWFIDWidth
                    .SetData(CMlngSlotMapRowTitle, CMlngColWFID, CMstrSlotMapColTWFID)
                    '@状態
                    .Cols(CMlngColClass).Width = CMlngColClassWidth
                    .SetData(CMlngSlotMapRowTitle, CMlngColClass, CMstrSlotMapColTClass)
                    '@↓2019/12/18 (Wed) 12:44:39 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    '@GRB
                    .Cols(CMlngColGRB).Width = CMlngColGRBWidth
                    .SetData(CMlngSlotMapRowTitle, CMlngColGRB, CMstrSlotMapColTGRB)
                    '@↑2019/12/18 (Wed) 12:44:39 Y.Yoneyama 「.Netへ反映未」 **************************************************

                    '@ｽﾛｯﾄ№のｾﾝﾀﾘﾝｸﾞ
                    .Cols(CMlngColSlot).TextAlign = TextAlignEnum.RightCenter

                    '@ﾛｯｸ
                    .Enabled = False

                    .Redraw = True

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

    '関数名：prvvsfSlotMap_Disp
    '機　能：WFﾏｯﾌﾟ表示
    '引　数：ltypWaferList：ﾛｯﾄ現在状態取得構造体
    '　　　：lobjControl  ：VSFlexGridｵﾌﾞｼﾞｪｸﾄ名
    '戻り値：なし
    '作成日：2004/04/15 (Thu) 09:34:27 K.Takano
    '更新日：2004/07/29 (Thu) 09:44:24 Y.Yamagishi
    '備　考：
    Private Sub prvVsfSlotMap_Disp(ByRef ltypWaferList As Waferlist, ByRef lobjControl As C1FlexGrid)

        Dim llngCnt         As Integer      'ｷｬﾘｱのｶｳﾝﾄ数
        Dim llngWriteRow    As Integer      '書き込み行

        Try
            
            '@ｵﾌﾞｼﾞｪｸﾄがVSFlexGridの場合にのみ設定
            If TypeOf lobjControl Is C1FlexGrid Then
                '@全てのｽﾛｯﾄ背景色を灰色に変更(初期化)
                For llngCnt = 1 To CMlngSlotMapRowS - 1
                    Dim newStyle As CellStyle = lobjControl.Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                    Dim cellRange As CellRange = lobjControl.GetCellRange(llngCnt, CMlngColWFID)
                    cellRange.Style = newStyle
                    Dim newStyle2 As CellStyle = lobjControl.Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                    newStyle2.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                    Dim cellRange2 As CellRange = lobjControl.GetCellRange(llngCnt, CMlngColClass)
                    cellRange2.Style = newStyle2
                    '@↓2019/12/18 (Wed) 13:28:05 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    Dim newStyle3 As CellStyle = lobjControl.Styles.Add("CustomStyle_BackColor_CPlngGridDarkGray")
                    newStyle3.BackColor = ColorTranslator.FromWin32(CPlngGridDarkGray)
                    Dim cellRange3 As CellRange = lobjControl.GetCellRange(llngCnt, CMlngColGRB)
                    cellRange3.Style = newStyle3
                    '@↑2019/12/18 (Wed) 13:28:05 Y.Yoneyama 「.Netへ反映未」 **************************************************
                Next
                
                '@WF枚数分ﾙｰﾌﾟ
                For llngCnt = 1 To CMlngSlotMapRowS - 1
                    '@ｽﾛｯﾄｻｲｽﾞよりｽﾛｯﾄ№が大きい場合
                    If ltypWaferList.strSlotSize < CMlngSlotMapRowS - llngCnt Then
                        '@ｽﾛｯﾄ№は空白
                        lobjControl.SetData(llngCnt, CMlngColSlot, vbNullString)
                        
                        '@ｽﾛｯﾄにｷｬﾘｱが存在しない場合はﾊﾞｯｸｶﾗｰを灰色(ﾎﾞﾀﾝの表面の色)に変更する
                        Dim newStyle As CellStyle = lobjControl.Styles.Add("CustomStyle_BackColor_vbButtonFace")
                        newStyle.BackColor = vbButtonFace
                        Dim cellRange As CellRange = lobjControl.GetCellRange(llngCnt, CMlngColWFID)
                        cellRange.Style = newStyle
                        Dim newStyle2 As CellStyle = lobjControl.Styles.Add("CustomStyle_BackColor_vbButtonFace")
                        newStyle2.BackColor = vbButtonFace
                        Dim cellRange2 As CellRange = lobjControl.GetCellRange(llngCnt, CMlngColClass)
                        cellRange2.Style = newStyle2
                        '@↓2019/12/18 (Wed) 13:28:23 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        Dim newStyle3 As CellStyle = lobjControl.Styles.Add("CustomStyle_BackColor_vbButtonFace")
                        newStyle3.BackColor = vbButtonFace
                        Dim cellRange3 As CellRange = lobjControl.GetCellRange(llngCnt, CMlngColGRB)
                        cellRange3.Style = newStyle3
                        '@↑2019/12/18 (Wed) 13:28:23 Y.Yoneyama 「.Netへ反映未」 **************************************************
                    End If
                Next
                
                '@WF枚数分ﾙｰﾌﾟ
                llngCnt = 0
                Do While ltypWaferList.lngListCnt -1 >= llngCnt
                    With ltypWaferList.typWfList(llngCnt)
                        '@書き込み行設定
                        llngWriteRow = CMlngSlotMapRowS - CLng(.strSlotPosition)

                        '@WFID表示設定
                        lobjControl.SetData(llngWriteRow, CMlngColWFID, .strWfId)
                        Dim newStyle As CellStyle = lobjControl.Styles.Add("CustomStyle_BackColor_vbWhite")
                        newStyle.BackColor = vbWhite
                        Dim cellRange As CellRange = lobjControl.GetCellRange(llngWriteRow, CMlngColWFID)
                        cellRange.Style = newStyle

                        '@表示位置：左寄せ中央揃え
                        'lobjControl.Col(llngWriteRow, CMlngColWFID).TextAlign = TextAlignEnum.LeftCenter

                        '@WF状態表示設定
                        Select Case .strClass
                            Case CPstrClass1
                                '@1(良品)の場合
                                lobjControl.SetData(llngWriteRow, CMlngColClass, CPstrClass1J)
                                Dim newStyle2 As CellStyle = lobjControl.Styles.Add("CustomStyle_BackColor_vbWhite")
                                newStyle2.BackColor = vbWhite
                                Dim cellRange2 As CellRange = lobjControl.GetCellRange(llngWriteRow, CMlngColClass)
                                cellRange2.Style = newStyle2
                            Case CPstrClass2
                                '@2(不良)の場合
                                lobjControl.SetData(llngWriteRow, CMlngColClass, CPstrClass2J)
                            Case CPstrClass3
                                '@3(払出)の場合
                                lobjControl.SetData(llngWriteRow, CMlngColClass, CPstrClass3J)
                            Case CPstrClass4
                                '@4(保留)の場合
                                lobjControl.SetData(llngWriteRow, CMlngColClass, CPstrClass4J)
                            Case CPstrClass5
                                '@5(傾向)の場合
                                lobjControl.SetData(llngWriteRow, CMlngColClass, CPstrClass5J)
                        End Select
                        
                        '@表示位置：左寄せ中央揃え
                        'lobjControl.Col(llngWriteRow, CMlngColClass).TextAlign = TextAlignEnum.LeftCenter

                        '@↓2019/12/18 (Wed) 13:29:04 Y.Yoneyama 「.Netへ反映未」 **************************************************
                        '@GRB
                        lobjControl.SetData(llngWriteRow, CMlngColGRB, .strGRBClass)
                        '@GRB背景色
                        Dim styleGRB As CellStyle = lobjControl.Styles.Add("GRBColor" + llngWriteRow.ToString)
                        styleGRB.BackColor = pubGRBBackColor(.strGRBClass)
                        Dim cellGRB As CellRange = lobjControl.GetCellRange(llngWriteRow, CMlngColGRB)
                        cellGRB.Style = styleGRB
                        '@↑2019/12/18 (Wed) 13:29:04 Y.Yoneyama 「.Netへ反映未」 **************************************************

                        '@ｶｳﾝﾄｱｯﾌﾟ
                        llngCnt = llngCnt + 1
                    End With
                Loop
            End If
            
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

    '関数名：prvcmdRegistEnabled_Chk
    '機　能：確定ﾎﾞﾀﾝ有効確認
    '引　数：なし
    '戻り値：TRUE:OK FALSE:NG
    '作成日：2004/04/15 (Thu) 11:19:53 K.Takano
    '更新日：2004/12/09 (Thu) 18:27:51 N.Kasai
    '備　考：
    '　　　：2004/11/25 (Thu) 11:01:23 N.Kasai  同一ｴﾝﾄﾘ判定追加(@ｴﾝﾄﾘID確認)
    '　　　：2004/11/30 (Tue) 11:31:02 N.Kasai  仕様変更(№266)同一ｴﾝﾄﾘ統合可ｺﾒﾝﾄｱｳﾄ
    '　　　：2004/12/09 (Thu) 18:27:51 N.Kasai  ﾛｯﾄ状態が相違している場合は統合不可
    Private Function prvcmdRegistEnabled_Chk() As Boolean
        
        Dim lstrStatus1         As String           'ﾛｯﾄ状態(1)
        Dim lstrStatus2         As String           'ﾛｯﾄ状態(2)
        Dim lstrLot1            As String           'ﾛｯﾄID(1)
        Dim lstrLot2            As String           'ﾛｯﾄID(2)

        Try
            
            '@初期化
            prvcmdRegistEnabled_Chk = False
            
            '@ﾛｯﾄ状態取得
            lstrStatus1 = lblStatus.Text
            lstrStatus2 = lblStatus2.Text
            
            '@ﾛｯﾄID取得
            lstrLot1 = lblLotID.Text
            lstrLot2 = lblLotID2.Text
            
            '@統合ﾛｯﾄID有効確認
            If lstrLot1 <> vbNullString And lstrLot2 <> vbNullString Then
            
                '@派生元ﾛｯﾄ確認
                If Strings.Left$(lstrLot1, CMlngLeftLength) <> Strings.Left$(lstrLot2, CMlngLeftLength) Then
                    '@"<TRM0AW>$$分割元ロットが異なります。同一ロットから分割されたロットを統合してください。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000A)
                    '@警告ﾒｯｾｰｼﾞ
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@確定ﾎﾞﾀﾝ無効変更
                    cmdRegist.Enabled = False
                    Exit Function
                End If
                
                '@統合ﾛｯﾄ状態確認(1,2共に作業待ちOr作業終了か確認)
                If (lstrStatus1 <> CPstrWaitWorkSt And lstrStatus1 <> CPstrEndWorkSt) Or _
                   (lstrStatus2 <> CPstrWaitWorkSt And lstrStatus2 <> CPstrEndWorkSt) Then
                    '@"<TRM0DW>$$「作業待ち」、「作業終了」以外のロットは統合できません。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000D)
                    '@警告ﾒｯｾｰｼﾞ
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@確定ﾎﾞﾀﾝ無効変更
                    cmdRegist.Enabled = False
                    Exit Function
                End If
                
                '@ﾛｯﾄ状態の確認
                If lstrStatus1 <> lstrStatus2 Then
                    '@"<TRM4NW>$$ロット状態が異なります。同一状態でロットを統合してください。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004N)
                    '@警告ﾒｯｾｰｼﾞ
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@確定ﾎﾞﾀﾝ無効変更
                    cmdRegist.Enabled = False
                    Exit Function
                End If
                
                '@小工程確認
                If lblStepID.Text <> lblStepID2.Text Then
                    '@"<TRM0EW>$$小工程が異なります。同一小工程でロットを統合してください。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000E)
                    '@警告ﾒｯｾｰｼﾞ
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@確定ﾎﾞﾀﾝ無効変更
                    cmdRegist.Enabled = False
                    Exit Function
                End If
                
                '@同一ｷｬﾘｱﾁｪｯｸ
                If txtCarrier.Text = txtCarrier2.Text Then
                    '@"<TRM0CW>$$キャリアIDが重複しています。設定を見直してください。"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000C)
                    '@警告ﾒｯｾｰｼﾞ
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@確定ﾎﾞﾀﾝ無効変更
                    cmdRegist.Enabled = False
                    Exit Function
                End If
            Else
                '@確定ﾎﾞﾀﾝ無効変更
                cmdRegist.Enabled = False
                '@ﾁｪｯｸOK(どちらか一方が空白の場合はﾁｪｯｸなし)
                prvcmdRegistEnabled_Chk = True
                Exit Function
            End If
            
            '@確定ﾎﾞﾀﾝ有効変更
            cmdRegist.Enabled = True
            '@ﾁｪｯｸOK
            prvcmdRegistEnabled_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmdRegistEnabled_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：txtWorkMemo_Change
    '機　能：ｺﾒﾝﾄ文字数確認
    '引　数：なし
    '戻り値：なし
    '作成日：2004/04/15 (Thu) 14:03:34 K.Takano
    '更新日：2005/12/02 (Fri) 13:18:32 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 13:18:32 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change

        Dim llngNowByte      As Integer  '現在のﾊﾞｲﾄ数

        Try

            '@現状のﾊﾞｲﾄ数を格納
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
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

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

    '関数名：prvblnInput_Chk
    '機　能：入力ﾁｪｯｸ
    '引　数：なし
    '戻り値：True：OK、False：NG
    '作成日：2004/04/15 (Thu) 14:51:04 K.Takano
    '更新日：2005/06/07 (Tue) 18:41:06 N.Kojima
    '備　考：(仕様変更(ｴﾝﾄﾘIDが相違しても統合可)
    '　　　：2004/11/22 (Mon) 17:18:39 N.Kasai      ｴﾝﾄﾘIDのﾁｪｯｸを追加
    '　　　：2004/11/30 (Tue) 11:22:10 N.Kasai      仕様変更ｴﾝﾄﾘが相違しても統合可(№266)ｺﾒﾝﾄｱｳﾄ
    '　　　：2004/12/09 (Thu) 18:27:51 N.Kasai      ﾛｯﾄ状態が相違している場合は統合不可
    '　　　：2005/06/07 (Tue) 18:41:06 N.Kojima     機種確認処理を追加(運用不具合№395)
    Private Function prvblnInput_Chk() As Boolean

        Dim llngCnt         As Integer          'ｶｳﾝﾄ変数

        Try
            
            '@初期化
            prvblnInput_Chk = False
            
            '@機種確認
            If mstrPdID1 <> mstrPdID2 Then
                '@"<TRM5YW>$$機種が異なります。同一機種でロットを統合してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005Y)
                '@警告ﾒｯｾｰｼﾞ
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@統合ﾛｯﾄｷｬﾘｱへ
                Call pubSetFocus(txtCarrier2)
                Exit Function
            End If
            
            '@派生元ﾛｯﾄ確認
            If Strings.Left$(lblLotID.Text, CMlngLeftLength) <> Strings.Left$(lblLotID2.Text, CMlngLeftLength) Then
                '@"<TRM59W>$$分割元ロットが異なります。同一ロットから分割されたロットを統合してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0059)
                '@警告ﾒｯｾｰｼﾞ
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@統合ﾛｯﾄｷｬﾘｱへ
                Call pubSetFocus(txtCarrier2)
                Exit Function
            End If
            
            '@小工程確認
            If lblStepID.Text <> lblStepID2.Text Then
                '@"<TRM60W>$$小工程が異なります。同一小工程でロットを統合してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0060)
                '@警告ﾒｯｾｰｼﾞ
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@統合ﾛｯﾄｷｬﾘｱへ
                Call pubSetFocus(txtCarrier2)
                Exit Function
            End If
            
            '@ﾛｯﾄ状態の確認
            If lblStatus.Text <> lblStatus2.Text Then
                '@"<TRM4NW>$$ロット状態が異なります。同一状態でロットを統合してください。"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004N)
                '@警告ﾒｯｾｰｼﾞ
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@統合ﾛｯﾄｷｬﾘｱへ
                Call pubSetFocus(txtCarrier2)
                Exit Function
            End If
         
            '@ｽﾛｯﾄﾏｯﾌﾟ確認
            For llngCnt = 1 To CMlngSlotMapRowS - 1
                '@同ｽﾛｯﾄNoにWFが設定されている場合
                If vsfSlotMap.GetData(llngCnt, CMlngColWFID) <> vbNullString And _
                   vsfSlotMap2.GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                    '@"<TRM61W>$$同一スロットにウェハが存在する為、統合できません。$キャリア管理画面よりスロット情報変更後、統合して下さい"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0061)
                    '@警告ﾒｯｾｰｼﾞ
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@統合ﾛｯﾄｷｬﾘｱへ
                    Call pubSetFocus(txtCarrier2)
                    Exit Function
                End If
            Next llngCnt
            
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

    '関数名：prvWaferListSet
    '機　能：ｸﾞﾘｯﾄﾞ上のｳｪﾊｰﾘｽﾄをltypChkCombineLotInに格納する
    '引　数：vsfGrid：ｸﾞﾘｯﾄﾞ
    '　　　：ltypChkCombineLotIn：ｳｪﾊｰﾘｽﾄ格納用構造体
    '戻り値：
    '作成日：2017/06/06 (Tue) 11:11:44 T.Oide
    '更新日：2017/06/06 (Tue) 11:11:44
    '備　考：
    Private Sub prvWaferListSet(ByRef vsfGrid As Object, ByRef ltypChkCombineLotIn As typChkCombineLotIn)

        Dim llngRowCnt     As Integer
        Dim llngWaferCnt   As Integer
            
        Try

            llngRowCnt = 1      'ﾀｲﾄﾙ行は除くため1から開始
            llngWaferCnt = 0

            With ltypChkCombineLotIn

                If .strWfList Is Nothing Then
                    .strWfList = New List(Of String)
                End If

                '@ｸﾞﾘｯﾄﾞの行分Loop
                Do While vsfGrid.Rows.Count > llngRowCnt
                
                    '@行は空以外か
                    If vsfGrid.GetData(llngRowCnt, CMlngColWFID) <> vbNullString Then
                    
                        Dim strWfListTmp As String 

                        strWfListTmp = vsfGrid.GetData(llngRowCnt, CMlngColWFID)
                        .strWfList.Add(strWfListTmp)

                        '@要素追加
                        llngWaferCnt = llngWaferCnt + 1
                    
                    End If
                    
                    llngRowCnt = llngRowCnt + 1
                Loop
                
                '@ｳｪﾊｰﾘｽﾄ数を格納(元々入っている分もあるのでﾌﾟﾗｽする)
                .lngWfListCnt = .lngWfListCnt + llngWaferCnt
            
            End With
               
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvWaferListSet"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2020/02/18 (Tue) 11:40:59 Y.Yoneyama 「.Netへ反映未」 **************************************************
    '関数名：prvblnGRB_Chk
    '機　能：GRBﾁｪｯｸ処理
    '引　数：なし
    '戻り値：True：ﾁｪｯｸOK、False：ﾁｪｯｸNG
    '作成日：2019/12/19 (Thu) 19:22:24 Y.Yoneyama 「.Netへ反映未」
    '更新日：
    '備　考：
    Private Function prvblnGRB_Chk() As Boolean

        Dim llngCnt         As Integer
    
        Dim llngWFCnt1      As Integer
        Dim llngGRBNullCnt1 As Integer
        Dim lstrFirstGRB1   As String
        Dim lblnGRBMix1     As Boolean
    
        Dim llngWFCnt2      As Integer
        Dim llngGRBNullCnt2 As Integer
        Dim lstrFirstGRB2   As String
        Dim lblnGRBMix2     As Boolean
            
        Try

            '@戻り値の初期化
            prvblnGRB_Chk = False
    
            '@基板専用
            If pstrSBID <> CPstrSBID1A0 Then
                prvblnGRB_Chk = True
            End If
        
            '@初期化
            llngWFCnt1 = 0
            llngGRBNullCnt1 = 0
            lstrFirstGRB1 = vbNullString
            lblnGRBMix1 = False
    
            llngWFCnt2 = 0
            llngGRBNullCnt2 = 0
            lstrFirstGRB2 = vbNullString
            lblnGRBMix2 = False
    
    
            '@-----------------------
            '@ 統合ﾛｯﾄ1のWF.GRBﾁｪｯｸ
            '@-----------------------
            With vsfSlotMap
                For llngCnt = 1 To .Rows.Count - 1
                    '@WFIDあり
                    If .GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                        '@WF数
                        llngWFCnt1 = llngWFCnt1 + 1
                
                        '@WF.GRB=NULL
                        If .GetData(llngCnt, CMlngColGRB) = vbNullString Then
                            llngGRBNullCnt1 = llngGRBNullCnt1 + 1
                        Else
                            '@最初のWF.GRBをSET
                            If lstrFirstGRB1 = vbNullString Then
                                lstrFirstGRB1 = .GetData(llngCnt, CMlngColGRB)
                            Else
                                '@WF.GRBが異なる場合は混在とする
                                If lstrFirstGRB1 <> .GetData(llngCnt, CMlngColGRB) Then
                                    lblnGRBMix1 = True
                                End If
                            End If
                        End If
                    End If
                Next
            End With
    
            '@-----------------------
            '@ 統合ﾛｯﾄ2のWF.GRBﾁｪｯｸ
            '@-----------------------
            With vsfSlotMap2
                For llngCnt = 1 To .Rows.Count - 1
                    '@WFIDあり
                    If .GetData(llngCnt, CMlngColWFID) <> vbNullString Then
                        '@WF数
                        llngWFCnt2 = llngWFCnt2 + 1
                
                        '@WF.GRB=NULL
                        If .GetData(llngCnt, CMlngColGRB) = vbNullString Then
                            llngGRBNullCnt2 = llngGRBNullCnt2 + 1
                        Else
                            '@最初のWF.GRBをSET
                            If lstrFirstGRB2 = vbNullString Then
                                lstrFirstGRB2 = .GetData(llngCnt, CMlngColGRB)
                            Else
                                '@WF.GRBが異なる場合は混在とする
                                If lstrFirstGRB2 <> .GetData(llngCnt, CMlngColGRB) Then
                                    lblnGRBMix2 = True
                                End If
                            End If
                        End If
                    End If
                Next
            End With
    
            '@-----------------------
            '@OK条件
            '@-----------------------
    
            '@-----------------------
            '@統合ﾛｯﾄ1
            '@統合ﾛｯﾄ2
            '@全WF.GRB=NULL
            '@-----------------------
            If llngWFCnt1 = llngGRBNullCnt1 And llngWFCnt2 = llngGRBNullCnt2 Then
                prvblnGRB_Chk = True
                Exit Function
            End If
    
            '@-----------------------
            '@統合ﾛｯﾄ1
            '@統合ﾛｯﾄ2
            '@WF.GRBあり (統合後MixでもOK)
            '@-----------------------
            If lstrFirstGRB1 <> vbNullString And llngGRBNullCnt1 = 0 And _
                lstrFirstGRB2 <> vbNullString And llngGRBNullCnt2 = 0 Then
                prvblnGRB_Chk = True
                Exit Function
            End If
    
    
            '@-----------------------
            '@以降は全てNG
            '@-----------------------
    
            '@表示ﾒｯｾｰｼﾞ変換
            '@"<TRM169W>$$GRB設定あり/なしのウエハが混在しています。$設定を見直してください。"
            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0169)
            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
        
            '@ｷｬﾘｱ1にﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrier)
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnGRB_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function
    '@↑2020/02/18 (Tue) 11:40:59 Y.Yoneyama 「.Netへ反映未」 **************************************************


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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraLot.Paint, fraLot2.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub   

End Class
