'ﾌｧｲﾙ名：xxCM00R0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ロット詳細情報表示のメインフォーム
'作成日：2004/09/15 (Wed) 17:56:46 T.Kitagawa
'更新日：2018/12/14 (Fri) 14:00:00 T.Oide
'備　考：
'　　　：
'Copyright(C) SEIKO EPSON CORPORATION 2004-2018, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00R0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00R0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00R0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00R0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00R0)
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
    '@↓2020/03/06 (Fri) 10:54:00 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion                 As String = "04.05"
    Private Const CMstrLocalVersion                 As String = "04.06"
    '@↑2020/03/06 (Fri) 10:54:00 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@Msgﾊﾞｰｼﾞｮﾝ
    '@↓2016/01/16 (Sat) 12:00:41 H.Hayashi **************************************************
    'Private Const CMstrlot_detail__Ver              As String = "02.05"                     'ﾛｯﾄ詳細情報
    Private Const CMstrlot_detail__Ver              As String = "03.00"                     'ﾛｯﾄ詳細情報
    '@↑2016/01/16 (Sat) 12:00:41 H.Hayashi **************************************************

    '@ｺﾝﾄﾛｰﾙ名
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN01C0

    Private Const CMstrControlNameCarrierID         As String = "txtCarrierID"              'ｷｬﾘｱIDのｺﾝﾄﾛｰﾙ名
    Private Const CMstrControlNameLotID             As String = "txtLotID"                  'ﾛｯﾄIDのｺﾝﾄﾛｰﾙ名

    '@その他宣言
    Private Const CMlngCarrierIdMaxLength           As Integer = 6                          'ｷｬﾘｱIDの最大桁数
    Private Const CMlngLotIdMaxLength               As Integer = 10                         'ﾛｯﾄIDの最大桁数
    Private Const CMlngCmdLotInfoEnableLength       As Integer = 1                          '最新取得ﾎﾞﾀﾝの使用可能文字数
    Private Const CMstrAriFlag1                     As String = "1"                         'あり
    Private Const CMstrAriFlag                      As String = "○"                        'あり
    Private Const CMstrLotHoldName                  As String = "保留"                      '保留
    Private Const CMstrLotStopName                  As String = "停止"                      '停止
    Private Const CMstrZero                         As String = "0"                         '汎用定数(=0)
    Private Const CMstrOne                          As String = "1"                         '汎用定数(=1)
    Private Const CMstrTwo                          As String = "2"                         '汎用定数(=2)
    Private Const CMlngMaxDispRow                   As Integer = 4                          'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示行数

    '@色宣言
    Private Const CMlngGlayColor                    As Integer = &H80000004                 '灰色

    '@ﾚｽﾎﾟﾝｽ測定用
    Private Const CMstrFormName                     As String = "frmxxCM00R0"               '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                     As String = "Form_Load"                 'ｲﾍﾞﾝﾄ名称(ﾌｫｰﾑﾛｰﾄﾞ)
    Private Const CMstrTxtCarrierIdValidate         As String = "txtCarrierID_Validate"     'ｲﾍﾞﾝﾄ名称(ｷｬﾘｱID取得)
    Private Const CMstrTxtLotIdValidate             As String = "txtLotID_Validate"         'ｲﾍﾞﾝﾄ名称(ﾛｯﾄID取得)
    Private Const CMstrCmdLotInfoClick              As String = "cmdLotInfo_Click"          'ｲﾍﾞﾝﾄ名称(最新取得)
    
    '@ｽﾃｰﾀｽ画面色設定用
    Private ReadOnly vbButtonFace                       As Color = SystemColors.ControlLight    ' NSYS vbButtonFace定義
    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mstrTaihiCarrierID                      As String                               'ﾛｯﾄ情報取得時のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功取得時)
    Private mstrTaihiLotID                          As String                               'ﾛｯﾄ情報取得時のﾛｯﾄID(ﾒｯｾｰｼﾞ成功取得時)
    Private mstrTaihiLimitTime                      As String                               'ﾛｯﾄ情報取得時の制限時間(退避用)
    Private mstrTaihiWarnTime                       As String                               'ﾛｯﾄ情報取得時の警告時間(退避用)
    Private mstrRestrictTypeID                      As String                               'ﾛｯﾄ情報取得時の時間制限区分(退避用)
    Private mstrLotLastUpdate                       As String                               'ﾛｯﾄ最終更新日時
    Private mblnTakeOverDispFlg                     As Boolean                              '引継ぎ表示ﾌﾗｸﾞ
    Private mblnLotInfoFlag                         As Boolean                              'ﾛｯﾄ情報取得ﾌﾗｸﾞ(True:取得中/False:以外)
    
    Private buttonProcessing                        As Boolean                              'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                              'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                              'NSYS WindowCloseフラグ
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
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/15 (Wed) 18:40:08 T.Kitagawa
    '更新日：2005/10/05 (Wed) 10:17:50 N.Kojima
    '備　考：
    '　　　：2004/11/15 (Mon) 13:05:54 N.Kojima　   ｷｬﾘｱ引継ぎがある場合は、入力不可(背景=ｸﾞﾚｰ)にする処理を追加。
    '　　　：2005/10/05 (Wed) 10:17:50 N.Kojima     ﾛｯﾄ引継ぎがある場合は、入力不可(背景=ｸﾞﾚｰ)にする処理を追加。(ﾕｰｻﾞｰ要望№0088)
    Private Sub Form_Load()
        
        Dim lblnAns         As Boolean      '戻り値

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN01C0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                Exit Sub
            End If
            
            '@ﾃｷｽﾄﾎﾞｯｸｽの初期化
            txtLotID.Text = vbNullString                        'ﾛｯﾄID
            txtCarrierID.Text = vbNullString                    'ｷｬﾘｱID
            
            '@画面初期化
            Call prvfrmxxCM00R0_Init()

            '@ﾌｫｰﾑ起動区分処理
            '@親ﾌｫｰﾑから呼ばれた場合
            If pblnfrmxxCM00R0Kbn = True Then
                '@ｷｬﾘｱID引継ぎ
                If ptypCommonInfo.strCarrierId <> vbNullString Then
                    '@ｷｬﾘｱID
                    With txtCarrierID
                        '@ｷｬﾘｱIDﾛｯｸ
                        .Locked = True
                        '@ｷｬﾘｱIDﾊﾞｯｸｶﾗｰ
                        .BackColor = SystemColors.ControlLight
                        '@ｷｬﾘｱIDﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰ
                        .GotBackColor = SystemColors.ControlLight
                    End With
                    
                    '@ﾛｯﾄID
                    With txtLotID
                        '@ﾛｯﾄIDﾛｯｸ
                        .Locked = True
                        '@ﾛｯﾄIDﾊﾞｯｸｶﾗｰ
                        .BackColor = SystemColors.ControlLight
                        '@ﾛｯﾄIDﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰ
                        .GotBackColor = SystemColors.ControlLight
                    End With
                    
                    '@ﾀﾌﾞでﾌｫｰｶｽがあたらないようにする
                    txtCarrierID.TabStop = False
                    txtLotID.TabStop = False
                Else
                
        '@↓2005/10/05 (Wed) 10:17:42 N.Kojima **************************************************
                    '@ﾛｯﾄID引継ぎ
                    If ptypCommonInfo.strLotID <> vbNullString Then
                        '@ｷｬﾘｱID
                        With txtCarrierID
                            '@ｷｬﾘｱIDﾛｯｸ
                            .Locked = True
                            '@ｷｬﾘｱIDﾊﾞｯｸｶﾗｰ
                            .BackColor = ColorTranslator.FromWin32(CMlngGlayColor)
                            '@ｷｬﾘｱIDﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰ
                            .GotBackColor = ColorTranslator.FromWin32(CMlngGlayColor)
                        End With
                        
                        '@ﾛｯﾄID
                        With txtLotID
                            '@ﾛｯﾄIDﾛｯｸ
                            .Locked = True
                            '@ﾛｯﾄIDﾊﾞｯｸｶﾗｰ
                            .BackColor = ColorTranslator.FromWin32(CMlngGlayColor)
                            '@ﾛｯﾄIDﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰ
                            .GotBackColor = ColorTranslator.FromWin32(CMlngGlayColor)
                        End With
                    End If
        '@↑2005/10/05 (Wed) 10:17:42 N.Kojima **************************************************
                    
                    '@ﾀﾌﾞでﾌｫｰｶｽにあたるようにする
                    txtCarrierID.TabStop = True
                    txtLotID.TabStop = True
                End If
            End If
            
            '@引継ぎ情報表示済みﾌﾗｸﾞ
            mblnTakeOverDispFlg = False
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
            
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = -My.Settings.FormOffset

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Load"                  '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑｱｸﾃｨﾌﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/15 (Wed) 18:46:27 T.Kitagawa
    '更新日：2005/10/05 (Wed) 11:35:02 N.Kojima
    '備　考：
    '　　　：2004/11/15 (Mon) 13:12:25 N.Kojima　   ﾌｫｰｶｽｾｯﾄ処理追加
    '　　　：2005/03/24 (Thu) 12:36:49 S.Deguchi    ﾌｫｰｶｽ処理修正
    '　　　：2005/10/05 (Wed) 11:35:02 N.Kojima     引継ぎのﾛｯﾄIDがNULLかの判定処理を追加。(ﾕｰｻﾞｰ要望№0088)
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

            'NSYS追加
            Me.Refresh

        '@↓2005/10/05 (Wed) 10:56:19 N.Kojima **************************************************
            '@引数のｷｬﾘｱIDが空白かどうか判定する
            If ptypCommonInfo.strCarrierId <> vbNullString Then
                '@空白でない場合

                '@ｷｬﾘｱIDの初期値を設定する
                txtCarrierID.Text = ptypCommonInfo.strCarrierId

                '@ｷｬﾘｱ情報を取得する
                RemoveHandler txtCarrierID.Validating,AddressOf txtCarrierID_Validate
                Call txtCarrierID_Validate(txtCarrierID, New CancelEventArgs(False))
                AddHandler txtCarrierID.Validating,AddressOf txtCarrierID_Validate
            Else
                '@ｷｬﾘｱID初期化
                ptypCommonInfo.strCarrierId = vbNullString
                
                '@引数のﾛｯﾄIDが空白かどうか判定する
                If ptypCommonInfo.strLotID <> vbNullString Then
                    '@空白でない場合
            
                    '@ﾛｯﾄIDの初期値を設定する
                    txtLotID.Text = ptypCommonInfo.strLotID
            
                    '@ﾛｯﾄ情報(ｷｬﾘｱ情報)を取得する
                    RemoveHandler txtLotID.Validating,AddressOf txtLotID_Validate
                    Call txtLotID_Validate(txtCarrierID, New CancelEventArgs(False))
                    AddHandler txtLotID.Validating,AddressOf txtLotID_Validate
                Else
                    '@LotID初期化
                    ptypCommonInfo.strLotID = vbNullString
                End If
            End If
        '@↑2005/10/05 (Wed) 10:56:19 N.Kojima **************************************************

            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Activate"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
    '作成日：2004/09/15 (Wed) 19:08:16 T.Kitagawa
    '更新日：2004/10/13 (Wed) 15:58:16 N.Kojima
    '備　考：
    '　　　：2004/10/13 (Wed) 15:58:16 N.Kojima　   ﾊﾟﾚｯﾄ情報ﾎﾞﾀﾝ有効の場合追加(不具合№792対応)
    '　　　：2005/03/24 (Thu) 12:37:15 S.Deguchi    ｷｬﾘｱID処理追加＆ﾌｫｰｶｽｾｯﾄ処理修正
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

            Select Case ActiveControl.Name
                Case txtCarrierID.Name
                '@ｷｬﾘｱIDにﾌｫｰｶｽがある場合
                    Select Case e.KeyCode
                        '@Enterｷｰ
                        Case Keys.Return
                            '@Validate処理を呼出す
                            RemoveHandler txtCarrierID.Validating,AddressOf txtCarrierID_Validate
                            Call txtCarrierID_Validate(txtCarrierID, New CancelEventArgs(False))
                            AddHandler txtCarrierID.Validating,AddressOf txtCarrierID_Validate
                            e.Handled = True
                    End Select

                Case txtLotID.Name
                '@ﾛｯﾄIDにﾌｫｰｶｽがある場合
                    Select Case e.KeyCode
                        '@Enterｷｰ
                        Case Keys.Return
                            '@Validate処理を呼出す
                            RemoveHandler txtLotID.Validating,AddressOf txtLotID_Validate
                            Call txtLotID_Validate(txtCarrierID, New CancelEventArgs(False))
                            AddHandler txtLotID.Validating,AddressOf txtLotID_Validate
                            e.Handled = True
                    End Select

                Case Else
                '@その他
                    Select Case e.KeyCode
                        '@Enterｷｰ
                        Case Keys.Return
                            '@次ﾌｫｰｶｽへ
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                    End Select
            End Select
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_KeyDown"               '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
    '作成日：2004/09/15 (Wed) 18:49:05 T.Kitagawa
    '更新日：2004/11/11 (Thu) 09:02:11 N.Kojima
    '備　考：2004/11/01 (Mon) 15:46:53 T.Kitagawa　 閉じるﾎﾞﾀﾝ統合
    '　　　：2004/11/11 (Thu) 09:02:11 N.Kojima　   装置別ﾛｯﾄ一覧からの引継ぎ機能追加に伴い、DoEvents対応追加。
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try

            
            
            '@DoEventsﾌﾗｸﾞが立っている場合
            If pblnTrnFlag = True Then
                e.Cancel = True
                Exit Sub
            End If
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload           '@NSYS 閉じる処理抜け
                Call cmdClose_Click(cmdClose, New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@装置別ﾛｯﾄ一覧用 ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化
            '@(装置別ﾛｯﾄ一覧の戻り引継ぎ表示の為、Form_QueryUnloadに必要)
            pblnFormLoad = False
            
            '@ﾌｫｰﾑ起動区分の確認
            If pblnfrmxxCM00R0Kbn = True Then
                '@ﾌｫｰﾑ起動区分を初期化
                pblnfrmxxCM00R0Kbn = False
            Else
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
            End If

            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_QueryUnload"           '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：ﾌｫｰﾑを閉じる
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/15 (Wed) 19:06:22 T.Kitagawa
    '更新日：2018/11/19 (Mon) 10:11:33 Y.Yoneyama
    '備　考：
    '　　　：2004/11/11 (Thu) 09:00:20 N.Kojima　   装置別ﾛｯﾄ一覧からの引継ぎ機能追加に伴い、DoEvents対応追加。
    '　　　：2004/11/25 (Thu) 21:23:20 N.Kojima　   引継ぎ起動の際、ﾒﾆｭｰﾊﾞｰの表示の不備修正(ﾒﾆｭｰが微妙に見え、押すこともできてしまう)。
    '　　　：2005/01/06 (Thu) 10:26:38 H.Wajima     ﾃｽﾄ不具合№395(運用障害№176) 以下の問題を修正
    '　　　：                                       ①装置別ﾛｯﾄ一覧からﾒﾆｭｰ経由で起動した場合→装置別ﾛｯﾄ一覧に戻らない
    '　　　：                                       ②装置別ﾛｯﾄ一覧のﾎﾞﾀﾝから起動した場合→ﾒﾆｭｰのﾎﾞﾀﾝが微妙に見えてしまう
    '　　　：2005/02/15 (Tue) 13:25:37 N.Kojima　   戻り先画面の判定を追加(改善№512)
    '　　　：2005/10/05 (Wed) 10:58:51 N.Kojima     引継ぎ構造体の判定処理にﾛｯﾄIDも判定するように修正。(ﾕｰｻﾞｰ要望№0088)
    '　　　：2007/04/24 (Tue) 13:55:00 N.Kasai      引継ぎ機能修正(№01897)
    '　　　：2018/11/19 (Mon) 10:11:33 Y.Yoneyama   防湿ALD対応
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

            '@DoEventsﾌﾗｸﾞが立っている場合
            If pblnTrnFlag = True Then
                Exit Sub
            End If
            
            '@引継ぎ情報のｷｬﾘｱID or ﾛｯﾄIDが空白かどうか判定する
            If ptypCommonInfo.strCarrierId <> vbNullString Or _
                ptypCommonInfo.strLotID <> vbNullString Then
                
                '@空白でない場合
                '@ﾌｫｰﾑ起動区分の判定
                '@ﾌｫｰﾑのUnloadでpblnfrmxxCM00R0Kbnがｸﾘｱされるので注意！！
                If pblnfrmxxCM00R0Kbn = True Then
                    '@親ﾌｫｰﾑから起動された場合
                    '@ｱﾝﾛｰﾄﾞ
                    Me.Close()
                Else
                    '@ﾒﾆｭｰ経由で起動された場合
                    '@ｱﾝﾛｰﾄﾞ
                    Me.Close()
                                
                    '@画面引継ぎ制御
                    Select Case True
                        Case pblnfrmxxEN0150Kbn
                            '@装置別ﾛｯﾄ一覧を起動する
                            Call pubMenuSelect_Proc(CPstrKeyEN0150)
        '@↓2018/11/19 (Mon) 10:11:33 Y.Yoneyama **************************************************
                        Case pblnfrmxxEN0151Kbn
                            '@装置別ﾛｯﾄ一覧(防湿ALD)を起動する
                            Call pubMenuSelect_Proc(CPstrKeyEN0151)
        '@↑2018/11/19 (Mon) 10:11:33 Y.Yoneyama **************************************************
                        
                        Case pblnfrmxxEN00J0Kbn
                            '@装置ｸﾞﾙｰﾌﾟ別ﾛｯﾄ一覧を起動する
                            Call pubMenuSelect_Proc(CPstrKeyEN00J0)
                        Case pblnfrmxxEN0200Kbn
                            '@工程別ﾛｯﾄ一覧を起動する
                            Call pubMenuSelect_Proc(CPstrKeyEN0200)
                        Case Else
                            '@引継ぎ構造体ｸﾘｱ
                            '@投入予定一覧から引き継いだ場合があります。
                            '@この場合親画面(一覧)に戻る必要がないのでｸﾘｱします。
                            '@終了関数を実行する
                            Call publngEnd_Proc(CPstrKeyEN01C0, ltypCommonInfo)
                    End Select
                    
                End If
            Else
                '@終了関数を実行する
                Call publngEnd_Proc(CPstrKeyEN01C0, ltypCommonInfo)
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdClose_Click"             '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub


    '関数名：txtCarrierID_Change
    '機　能：ｷｬﾘｱID変更
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/15 (Wed) 19:17:27 T.Kitagawa
    '更新日：2004/09/15 (Wed) 19:17:27
    '備　考：
    Private Sub txtCarrierID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrierID.Change
        
        Try

            '@ﾛｯﾄ情報取得ﾌﾗｸﾞにより判別
            If mblnLotInfoFlag = False Then
                '@画面の初期化
                Call prvfrmxxCM00R0_Init()
                
                '@ﾌｫｰｶｽ/初期化処理の為,一時的にﾌﾗｸﾞを戻す
                mblnLotInfoFlag = True
                
                '@ﾛｯﾄID欄の初期化
                txtLotID.Text = vbNullString
            
                '@ﾌｫｰｶｽ/初期化処理の為,戻したﾌﾗｸﾞをさらに戻す
                mblnLotInfoFlag = False
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtCarrierID_Change"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierID_Validate
    '機　能：ｷｬﾘｱ情報取得
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/09/15 (Wed) 19:22:02 T.Kitagawa
    '更新日：2004/12/14 (Tue) 18:16:12 H.Wajima
    '備　考：
    '　　　：2005/06/15 (Wed) 15:22:09 S.Deguchi    ｷｬﾘｱID/ﾛｯﾄID/最新取得で処理統一
    Public Sub txtCarrierID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrierID.Validating
        
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        
        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose Then
                Exit Sub
            End If

            '@ｷｬﾘｱIDの空白ﾁｪｯｸ
            If txtCarrierID.Text = vbNullString Then
                '@ﾌｫｰｶｽ設定
                If Not IsNothing(Me.ActiveControl) AndAlso Me.ActiveControl.Name = txtCarrierID.Name Then
                    Call prvcontrolSetFocus_Set(vbNullString)
                End If
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtCarrierID.NowByte < txtCarrierID.ChrMaxByte Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                e.Cancel = True
                
                Exit Sub
            End If

            '@ｷｬﾘｱID情報の取得(入力ｷｬﾘｱIDと前回のｷｬﾘｱID(ﾒｯｾｰｼﾞ成功)と違う場合のみ実行)
            If txtCarrierID.Text <> mstrTaihiCarrierID Then
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrTxtCarrierIdValidate)
                
                '@情報取得ﾌﾗｸﾞ立て
                mblnLotInfoFlag = True
                
                '@ﾛｯﾄ詳細情報の取得
                lblnAns = prvblnlotdetail_Get(CPstrCD0K)
                '@結果判定
                If lblnAns = True Then
                    '@最新取得ﾎﾞﾀﾝ
                    cmdLotInfo.Enabled = True
                
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrTxtCarrierIdValidate)
                    
                    '@ﾌｫｰｶｽ設定
                    Call prvcontrolSetFocus_Set(CMstrControlNameCarrierID)
                Else
                    '@ｷｬﾘｱIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrTxtCarrierIdValidate)
                End If
            
                '@情報取得ﾌﾗｸﾞ戻し
                mblnLotInfoFlag = False
            Else
                '@ﾌｫｰｶｽ設定
                If Not IsNothing(Me.ActiveControl) AndAlso Me.ActiveControl.Name = txtCarrierID.Name Then
                    Call prvcontrolSetFocus_Set(vbNullString)
                End If
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtCarrierID_Validate"      '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComments_Change
    '機　能：ﾃｷｽﾄ変更
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/17 (Thu) 12:00:24 N.Kasai
    '更新日：2005/11/17 (Thu) 12:00:24
    '備　考：
    Private Sub txtComments_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtComments.Change

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComments_KeyUp
    '機　能：ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/17 (Thu) 12:01:35 N.Kasai
    '更新日：2005/11/17 (Thu) 12:01:35
    '備　考：
    Private Sub txtComments_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtComments.KeyUp

        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtComments, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComments_MouseUp
    '機　能：ﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾏｳｽﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：ｙ座標
    '戻り値：なし
    '作成日：2005/11/17 (Thu) 12:02:05 N.Kasai
    '更新日：2005/11/17 (Thu) 12:02:05
    '備　考：
    Private Sub txtComments_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtComments.MouseUp

        Try
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComments, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComments_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotID_Change
    '機　能：ﾛｯﾄID変更
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/15 (Wed) 19:21:27 T.Kitagawa
    '更新日：2004/09/15 (Wed) 19:21:27
    '備　考：
    Private Sub txtLotID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLotID.Change
        
        Try

            '@ﾛｯﾄ情報取得ﾌﾗｸﾞにより判別
            If mblnLotInfoFlag = False Then
                '@画面の初期化
                Call prvfrmxxCM00R0_Init()
                
                '@ﾌｫｰｶｽ/初期化処理の為,一時的にﾌﾗｸﾞを戻す
                mblnLotInfoFlag = True
                
                '@ｷｬﾘｱID欄の初期化
                txtCarrierID.Text = vbNullString
            
                '@ﾌｫｰｶｽ/初期化処理の為,戻したﾌﾗｸﾞをさらに戻す
                mblnLotInfoFlag = False
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtLotID_Change"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotID_Validate
    '機　能：ﾛｯﾄ情報取得
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/09/15 (Wed) 19:35:20 T.Kitagawa
    '更新日：2004/12/14 (Tue) 18:14:19 H.Wajima
    '備　考：
    '　　　：2004/10/06 (Wed) 14:15:48 N.Kojima　   ﾊﾟﾚｯﾄ情報ﾎﾞﾀﾝ使用可否処理追加(不具合№792)
    '　　　：2004/11/24 (Wed) 10:43:33 S.Deguchi    CFﾌﾗｸﾞの判定処理を修正(ﾊﾟﾀｰﾝ分け=0/1/2)
    '　　　：2004/12/14 (Tue) 18:14:19 H.Wajima     CFﾌﾗｸﾞの判定処理をprvfrmxxCM00R0_Dispに移動
    '　　　：2005/03/24 (Thu) 10:12:42 S.Deguchi    不具合改善№667対応でValidate処理見直し
    '　　　：2005/06/15 (Wed) 15:22:09 S.Deguchi    ｷｬﾘｱID/ﾛｯﾄID/最新取得で処理統一
    Public Sub txtLotID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtLotID.Validating

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        
        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl Is cmdClose Or mblnWindowClose Then
                Exit Sub
            End If

            '@ﾛｯﾄIDの空白ﾁｪｯｸ
            If txtLotID.Text = vbNullString Then
                '@ﾌｫｰｶｽ設定
                If ActiveControl.Name = txtLotID.Name Then
                    Call prvcontrolSetFocus_Set(vbNullString)
                End If
                Exit Sub
            End If
            
            '@ﾛｯﾄIDの桁ﾁｪｯｸ
            If txtLotID.NowByte < txtLotID.ChrMaxByte Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0012)
                '@"ロットIDは10桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                e.Cancel = True
                
                Exit Sub
            End If

            '@ﾛｯﾄID情報の取得(入力ﾛｯﾄIDと前回のﾛｯﾄID(ﾒｯｾｰｼﾞ成功)と違う場合のみ実行)
            If txtLotID.Text <> mstrTaihiLotID Then
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrTxtLotIdValidate)
                
                '@情報取得ﾌﾗｸﾞ立て
                mblnLotInfoFlag = True
                
                '@ﾛｯﾄ詳細情報の取得
                lblnAns = prvblnlotdetail_Get(CPstrCD0L)
                '@結果判定
                If lblnAns = True Then
                    '@最新取得ﾎﾞﾀﾝ
                    cmdLotInfo.Enabled = True
                    
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrTxtLotIdValidate)
                    
                    '@ﾌｫｰｶｽ設定
                    If ActiveControl.Name = txtLotID.Name Then
                        Call prvcontrolSetFocus_Set(CMstrControlNameLotID)
                    End If
                Else
                    '@ﾛｯﾄIDへﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrTxtLotIdValidate)
                    
                End If
            
                '@情報取得ﾌﾗｸﾞ戻し
                mblnLotInfoFlag = False
            Else
                '@ﾌｫｰｶｽ設定
                If ActiveControl.Name = txtLotID.Name Then
                    Call prvcontrolSetFocus_Set(vbNullString)
                End If
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtLotID_Validate"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdLotInfo_Click
    '機　能：最新情報ﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/15 (Wed) 19:43:13 T.Kitagawa
    '更新日：2004/12/14 (Tue) 18:15:23 H.Wajima
    '備　考：
    '　　　：2004/10/13 (Wed) 17:49:23 N.Kojima　   ﾊﾟﾚｯﾄ情報ﾎﾞﾀﾝ追加に伴う処理の追加(不具合№792)
    '　　　：2004/11/24 (Wed) 10:43:33 S.Deguchi    CFﾌﾗｸﾞの判定処理を修正(ﾊﾟﾀｰﾝ分け=0/1/2)
    '　　　：2004/12/14 (Tue) 18:15:23 H.Wajima     CFﾌﾗｸﾞの判定処理をprvfrmxxCM00R0_Dispに移動
    '　　　：2005/03/24 (Thu) 12:55:22 S.Deguchi    処理見直し
    '　　　：2005/06/15 (Wed) 15:22:09 S.Deguchi    ｷｬﾘｱID/ﾛｯﾄID/最新取得で処理統一
    Public Sub cmdLotInfo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLotInfo.Click

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)

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

            '@情報取得ﾌﾗｸﾞ立て
            mblnLotInfoFlag = True

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdLotInfoClick)
                
            '@ﾛｯﾄ詳細情報の取得
            Select Case True
                Case Trim(txtCarrierID.Text) <> vbNullString
                '@ｷｬﾘｱIDが空欄でない場合
                    lblnAns = prvblnlotdetail_Get(CPstrCD0K)
                
                Case Trim(txtLotID.Text) <> vbNullString
                '@ﾛｯﾄIDが空欄でない場合
                    lblnAns = prvblnlotdetail_Get(CPstrCD0L)
            End Select
            '@結果判定
            If lblnAns = True Then
                '@最新取得ﾎﾞﾀﾝ
                cmdLotInfo.Enabled = True
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdLotInfoClick)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdLotInfoClick)
                    
                '@ｷｬﾘｱID又は、ﾛｯﾄIDへﾌｫｰｶｽへ移動させる
                Select Case True
                    Case Trim(txtCarrierID.Text) <> vbNullString
                    '@ｷｬﾘｱIDが空欄でない場合
                        Call pubSetFocus(txtCarrierID)
                        
                    Case Trim(txtLotID.Text) <> vbNullString
                    '@ﾛｯﾄIDが空欄でない場合
                        Call pubSetFocus(txtLotID)
                End Select
            End If

            '@情報取得ﾌﾗｸﾞ立て
            mblnLotInfoFlag = False

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdLotInfo_Click"           '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTxtUp_Click
    '機　能：ｺﾒﾝﾄの前頁切替処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/15 (Wed) 20:17:16 T.Kitagawa
    '更新日：2005/11/17 (Thu) 11:54:40 N.Kasai
    '備　考：
    '　　　：2005/11/17 (Thu) 11:54:40 N.Kasai      ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdTxtUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/11/17 (Thu) 11:55:10 N.Kasai **************************************************
        '    '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtComments)
        '
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtComments, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
            
        '@↑2005/11/17 (Thu) 11:55:10 N.Kasai **************************************************


            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdTxtUp_Click"             '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdTxtDown_Click
    '機　能：ｺﾒﾝﾄの次頁切替処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/15 (Wed) 20:18:00 T.Kitagawa
    '更新日：2005/11/17 (Thu) 11:57:21 N.Kasai
    '備　考：
    '　　　：2005/11/17 (Thu) 11:57:21 N.Kasai      ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    Private Sub cmdTxtDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTxtDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

        '@↓2005/11/17 (Thu) 11:57:12 N.Kasai **************************************************
        '    '@ｺﾒﾝﾄにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtComments)
        '
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True

            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝdown
            Call pubtxtCmdDown_Proc(txtComments, CMlngMaxDispRow, cmdTxtUp, cmdTxtDown)
            
        '@↑2005/11/17 (Thu) 11:57:12 N.Kasai **************************************************

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdTxtDown_Click"           '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommntInput_Click
    '機　能：ﾛｯﾄｺﾒﾝﾄ入力ﾌｫｰﾑを呼ぶ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/15 (Wed) 20:29:59 T.Kitagawa
    '更新日：2008/06/11 (Wed) 09:17:19 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 09:17:19 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
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
                .strLotID = txtLotID.Text
                .strFlowClass = lblFlowClass.Text
                .strWfNum = lblWfNum.Text
                .strOpID = lblOpID.Text
                .strStartTime = lblDispatchStartTime.Text
                .strPdId = lblPdID.Text
                .strSpecialFlg = lblSpecialFlg.Text
                .strNowST = lblNowSt.Text
                .strStepID = lblStepID.Text
                .strEngEmpName = lblLotManager.Text
                .strLimitTime = mstrTaihiLimitTime
                .strWarnTime = mstrTaihiWarnTime
                .strRestrictTypeID = mstrRestrictTypeID
                .strComments = txtComments.Text
                .strLotLastUpdate = mstrLotLastUpdate
                
                pstrCarrierID = txtCarrierID.Text                         'ｷｬﾘｱID
                
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
                Else
                    '@ｱﾝﾛｰﾄﾞする
                    frmxxCM0030.Instance = Nothing
                
                    '@起動ﾌﾗｸﾞを戻す
                    pblnFormLoad = True
                    
                    Exit Sub
                End If
        '@↑2005/10/25 (Tue) 17:34:04 S.Deguchi **************************************************
                
                '@画面をﾘﾌﾚｯｼｭする
                Call cmdLotInfo_Click(cmdLotInfo, New EventArgs)
            
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdCommntInput_Click"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdTreatChip_Click
    '機　能：ﾁｯﾌﾟの不良/保留/払出し画面表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/15 (Wed) 20:45:51 T.Kitagawa
    '更新日：2005/08/05 (Fri) 16:24:08 N.Kasai
    '備　考：
    '　　　：2004/10/13 (Wed) 18:17:43 N.Kojima　   ｷｬﾘｱ引継ぎ変数の初期化追加
    '　　　：2004/11/04 (Thu) 16:59:22 T.Kitagawa　 引継ぎ構造体を共通で使用している為、ｴﾗｰ時はｷｬﾘｱIDが
    '　　　：                                       最終的に引継ぎ構造体にｾｯﾄされてしまう件を修正
    '　　　：2005/08/05 (Fri) 16:24:08 N.Kasai      引数を判定してﾁｯﾌﾟ状態変更のｷｬﾌﾟｼｮﾝを変更する。
    Private Sub cmdTreatChip_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdTreatChip.Click
        
        Dim lstrTitle           As String       'ﾀｲﾄﾙ
        Dim ltypOldCommonInfo   As CommonInfo   '引継ぎ構造体の退避領域

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

            '@引継ぎ構造体の退避
            ltypOldCommonInfo = ptypCommonInfo

            '@子ﾌｫｰﾑの表示情報を変数に格納
            With ptypCommonInfo
                .strCarrierId = txtCarrierID.Text
                .strDivision = vbNullString
                .strLotID = vbNullString
                .strOpID = vbNullString
                .strStepID = vbNullString
                .strWpID = vbNullString
                .strWpName = vbNullString
            End With
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@ﾁｯﾌﾟ保留/不良/払出しﾌｫｰﾑを表示
            pblnfrmxxCM0080Kbn = True
            
            '@子画面をﾛｰﾄﾞ
            frmxxCM0080.Instance = New frmxxCM0080()
            
            '@引数によりｷｬﾌﾟｼｮﾝ&機能を変更する。
            Select Case pstrTerminalMode
                '@工程管理で起動
                Case CPstrManufactureStatus
                    '@ﾒﾆｭｰｷｰから機能の関連情報を取得する
                    Call pubMenuItemCorrelation_Set(CPstrKeyEN0190, lstrTitle)
                Case Else
                    '@ﾒﾆｭｰｷｰから機能の関連情報を取得する
                    Call pubMenuItemCorrelation_Set(CPstrKeyEN01Q0, lstrTitle)
            End Select
            
            '@ﾁｯﾌﾟ処理登録名称設定
            frmxxCM0080.Instance.Text = lstrTitle
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM0080.Instance = Nothing
                '@引継ぎｷｬﾘｱ情報の復元
                ptypCommonInfo = ltypOldCommonInfo
                pblnfrmxxCM0080Kbn = False
                Exit Sub
            End If
            
            frmxxCM0080.Instance.ShowDialog(Me)
            frmxxCM0080.Instance = Nothing
            
            '@引継ぎｷｬﾘｱ情報の復元
            ptypCommonInfo = ltypOldCommonInfo
            pblnfrmxxCM0080Kbn = False

            '@画面をﾘﾌﾚｯｼｭする
            Call cmdLotInfo_Click(cmdLotInfo, New EventArgs)

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdTreatChip_Click"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdCfPaletteInfo_Click
    '機　能：CFﾛｯﾄﾊﾟﾚｯﾄ情報表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/06 (Wed) 10:57:26 N.Kojima
    '更新日：2004/10/06 (Wed) 10:57:26
    '備　考：
    Private Sub cmdCfPaletteInfo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCfPaletteInfo.Click
        
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
            
            '@ｷｬﾘｱID退避
            pstrCarrierID = txtCarrierID.Text

            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@ﾊﾟﾚｯﾄ情報表示
            frmxxCM00O0.Instance = New frmxxCM00O0()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM00O0.Instance = Nothing
                Exit Sub
            End If
            
            '@ﾊﾟﾚｯﾄ情報画面表示B
            frmxxCM00O0.Instance.ShowDialog(Me)
            frmxxCM00O0.Instance = Nothing

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdCfPaletteInfo_Click"     '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '***************************************************************************************
    '                                   *関数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    '関数名：prvfrmxxCM00R0_Init
    '機　能：画面の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/15 (Wed) 20:19:11 T.Kitagawa
    '更新日：2016/02/08 (Mon) 22:54:20 H.Hayashi
    '備　考：
    '　　　：2004/10/04 (Mon) 14:36:10 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2004/10/13 (Wed) 15:24:05 N.Kojima　   ﾊﾟﾚｯﾄﾎﾞﾀﾝ初期設定追加(不具合№792)
    '　　　：2004/10/18 (Mon) 11:53:07 T.Kitagawa   分割子ﾛｯﾄIDが1件の場合は使用不可にする(不具合№1104)
    '　　　：2004/10/20 (Wed) 13:17:54 T.Kitagawa　 分割子ﾛｯﾄは初期値をﾗﾍﾞﾙ表示にする(不具合№96)
    '　　　：2005/05/18 (Wed) 16:47:58 N.Kasai      貼り合せﾛｯﾄID、ｷｬﾘｱID追加
    '　　　：2006/10/31 (Tue) 16:25:48 N.Kasai      送品ﾌﾗｸﾞ対応
    '　　　：2008/06/11 (Wed) 09:18:00 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '      ：2016/02/05 (Fri) 14:15:43 H.Hayashi    GRB対応(R12-04)
    Private Sub prvfrmxxCM00R0_Init()
        
        Dim lstrFormTitle       As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try

            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN01C0, lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@ﾛｯﾄ情報取得時のｷｬﾘｱID、ﾛｯﾄID退避情報を初期化
            mstrTaihiCarrierID = vbNullString
            mstrTaihiLotID = vbNullString
            mstrTaihiLimitTime = vbNullString
            mstrTaihiWarnTime = vbNullString
            mstrLotLastUpdate = vbNullString                            'ﾛｯﾄ最終更新日時
            
            '@各ﾎﾞﾀﾝの初期化
            cmdLotInfo.Enabled = False                                  '最新取得ﾎﾞﾀﾝ
            cmdCommntInput.Enabled = False                              'ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ
            cmdTreatChip.Enabled = False                                'ﾁｯﾌﾟ処置登録ﾎﾞﾀﾝ
            cmdTxtUp.Enabled = False                                    '▲ﾎﾞﾀﾝ
            cmdTxtDown.Enabled = False                                  '▼ﾎﾞﾀﾝ
            
            '@ﾊﾟﾚｯﾄ情報ﾎﾞﾀﾝの表示・非表示
            If pstrSBID = CPstrSBID1A0 Then
                cmdCfPaletteInfo.Visible = False                        'ﾊﾟﾚｯﾄ情報ﾎﾞﾀﾝ非表示
                cmdCfPaletteInfo.Enabled = False
            Else
                cmdCfPaletteInfo.Visible = True                         'ﾊﾟﾚｯﾄ情報ﾎﾞﾀﾝ表示
                cmdCfPaletteInfo.Enabled = False
            End If

            '@各ｺﾝﾄﾛｰﾙを初期化
            lblNowDate.Text = vbNullString                          '最新取得日時
            lblPdID.Text = vbNullString                             '機種ID
            lblFlowClass.Text = vbNullString                        '流動区分
            lblLotPriority.Text = vbNullString                      '優先度
            lblWfNum.Text = vbNullString                            'WF枚数
            lblChipQuantity.Text = vbNullString                     '良品ﾁｯﾌﾟ数
            lblLotManager.Text = vbNullString                       'ﾛｯﾄ担当者名
            lblCurrentPositionName.Text = vbNullString              'ﾛｯﾄ位置(和名)
            lblLastEventName.Text = vbNullString                    '最終ｲﾍﾞﾝﾄ名
            lblEntryTime.Text = vbNullString                        '最終ｲﾍﾞﾝﾄ日時
            lblEmpName.Text = vbNullString                          '最終更新者
            txtComments.Text = vbNullString                         'ｺﾒﾝﾄ
            txtComments.Enabled = False                             'ｺﾒﾝﾄ
            lblSpecialFlg.Text = vbNullString                       '特殊特性
            lblLotHoldStopFlag.Text = vbNullString                  'ﾛｯﾄ保留停止ﾌﾗｸﾞ
            lblNowSt.Text = vbNullString                            'LOT状態
            lblDispatchStartTime.Text = vbNullString                '投入予定時刻
            lblOpID.Text = vbNullString                             '大工程ID
            lblStepID.Text = vbNullString                           '小工程ID
            lblAltSwapFlag.Text = vbNullString                      '代替・入替工程有無ﾌﾗｸﾞ
            lblReworkFlag.Text = vbNullString                       'ﾘﾜｰｸﾌﾗｸﾞ
            lblBatchID.Text = vbNullString                          'ﾊﾞｯﾁID
            lblLimitTime.Text = vbNullString                        '制限時間(時間制約)
            lblWpName.Text = vbNullString                           'WP名
            lblPortName.Text = vbNullString                         'ﾎﾟｰﾄ名
            lblRecipeID.Text = vbNullString                         'ﾚｼﾋﾟID
            lblLoadUnloadCarrierID.Text = vbNullString              'ﾛｰﾀﾞｰ/ｱﾝﾛｰﾀﾞｰｷｬﾘｱID
            lblNextOpID.Text = vbNullString                         '次大工程
            lblNextStepID.Text = vbNullString                       '次小工程
            lblNextAltSwapFlag.Text = vbNullString                  '代替・入替次工程有無ﾌﾗｸﾞ
            lblDivideLotID.Text = vbNullString                      '分割親ﾛｯﾄID
            lblDivideLotID2.Text = vbNullString                     '分割子ﾛｯﾄID
            cmbDivideLotID2.Clear                                   '分割子ﾛｯﾄIDｺﾝﾎﾞ
            cmbDivideLotID2.Enabled = False                         '分割子ﾛｯﾄIDｺﾝﾎﾞ
            cmbDivideLotID2.BackColor = vbButtonFace                '分割子ﾛｯﾄIDｺﾝﾎﾞ色ｸﾞﾚｰ
            cmbDivideLotID2.Visible = False                         '分割子ﾛｯﾄIDｺﾝﾎﾞ
            lblDivideLotID2.Visible = True                          '分割子ﾛｯﾄIDﾗﾍﾞﾙ
            '@↓2020/02/19 (Wed) 14:14:55 Y.Yoneyama 「.Netへ反映未」 **************************************************
            lblGRB.Text = vbNullString                              'GRB
            '@GRB背景色
            lblGRB.BackColor = lblLotManager.BackColor
            '@↑2020/02/19 (Wed) 14:14:55 Y.Yoneyama 「.Netへ反映未」 **************************************************

            '@基板の場合は非表示
            If pstrSBID = CPstrSBID2A0 Then
            
        '@↓2016/01/16 (Sat) 04:36:11 H.Hayashi **************************************************
                lblTtlGrbClass.Visible = False                          'GRB区分
                lblGRB.Visible = False
                lblTtlGrbClass.Text = vbNullString
        '@↑2016/01/16 (Sat) 04:36:11 H.Hayashi **************************************************
                
                lblTtlODFCarrier.Visible = True
                lblTtlODFLot.Visible = True
                lblODFCarrierID.Visible = True
                lblOdfLotID.Visible = True
                lblODFCarrierID.Text = vbNullString                  '貼り合せｷｬﾘｱID
                lblOdfLotID.Text = vbNullString                      '貼り合せﾛｯﾄID
            Else
            
        '@↓2016/01/16 (Sat) 04:37:12 H.Hayashi **************************************************
                lblTtlGrbClass.Visible = True                           'GRB区分
                lblGRB.Visible = True
        '@↑2016/01/16 (Sat) 04:37:12 H.Hayashi **************************************************

                lblTtlODFCarrier.Visible = False
                lblTtlODFLot.Visible = False
                lblODFCarrierID.Visible = False
                lblOdfLotID.Visible = False
                lblODFCarrierID.Text = vbNullString                  '貼り合せｷｬﾘｱID
                lblOdfLotID.Text = vbNullString                      '貼り合せﾛｯﾄID
            End If
            
        '@↓2006/10/31 (Tue) 16:25:43 N.Kasai **************************************************
            lblLotSendFlag.Text = vbNullString                       '送品ﾌﾗｸﾞ
        '@↑2006/10/31 (Tue) 16:25:43 N.Kasai **************************************************
            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxCM00R0_Init"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxCM00R0_Disp
    '機　能：ﾛｯﾄ情報の画面表示処理
    '引　数：ltypLotDetailInfo：ﾛｯﾄ詳細情報構造体
    '戻り値：なし
    '作成日：2004/09/15 (Wed) 21:29:41 T.Kitagawa
    '更新日：2016/02/08 (Mon) 22:59:42 H.Hayashi
    '備　考：
    '　　　：2004/10/06 (Wed) 15:54:19 Y.Yamagishi  状態が「終了」のときはﾎﾞﾀﾝを無効にする(不具合改善№863)
    '　　　：2004/10/13 (Wed) 18:40:06 N.Kojima　   CFﾛｯﾄの場合ﾁｯﾌﾟ処置ﾎﾞﾀﾝを無効に
    '　　　：2004/10/18 (Mon) 11:41:04 T.Kitagawa   分割子ﾛｯﾄIDが1件の場合は無効にする(不具合№1104)
    '　　　：2004/10/18 (Mon) 13:09:12 T.Kitagawa　 ｷｬﾘｱIDが存在しない場合はﾛｯﾄｺﾒﾝﾄ、ﾁｯﾌﾟ状態変更ﾎﾞﾀﾝは無効にする(不具合№1086)
    '　　　：2004/10/20 (Wed) 13:16:20 T.Kitagawa　 分割子ﾛｯﾄは1件以下の場合はﾗﾍﾞﾙ表示にし、2件以上はｺﾝﾎﾞBOXにする(不具合№96)
    '　　　：2004/10/25 (Mon) 09:00:40 S.Deguchi    ﾘﾜｰｸ表記を「特殊流動」へ変更で取得したﾒｯｾｰｼﾞを表記する処理に修正
    '　　　：2005/04/27 (Wed) 14:03:16 S.Deguchi    不具合№750の対応で,数量の表示ﾌｫｰﾏｯﾄを修正
    '　　　：2005/05/19 (Thu) 17:15:30 N.Kasai      ODF関連表示追加(貼り合せｷｬﾘｱID,ﾛｯﾄID)
    '　　　：2005/05/26 (Thu) 15:18:23 N.Kasai      ODF判定追加(CFﾌﾗｸﾞ)
    '　　　：2005/06/30 (Thu) 15:47:39 N.Kasai      ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ制御追加
    '　　　：2005/11/17 (Thu) 11:59:35 N.Kasai      ｽｸﾛｰﾙﾎﾞﾀﾝ連動
    '　　　：2006/05/12 (Fri) 10:56:05 T.Kitagawa   制限時間の表示を分合計から時間と分で分割表示する(#,##0時間 #0分)(ﾕｰｻﾞ要望№0186)
    '　　　：2006/06/08 (Thu) 14:30:22 N.Kojima     処理時間制限以下対応に伴い、処理修正。(ﾕｰｻﾞｰ要望№0169)
    '　　　：2006/10/31 (Tue) 16:22:45 N.Kasai      送品ﾌﾗｸﾞ対応(№01500)
    '　　　：2008/06/11 (Wed) 09:18:42 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '      ：2016/02/08 (Mon) 22:54:20 H.Hayashi    GRB対応(R12-04)
    Private Sub prvfrmxxCM00R0_Disp(ByRef ltypLotDetailInfo As LotDetailInfo)

        Dim llngCnt                 As Integer              'ﾙｰﾌﾟｶｳﾝﾀ
        Dim lstrLimitTime           As String               '制限時間ﾌｫｰﾏｯﾄ用変数
        Dim lstrLimitTimeAns        As String               '時間制限変換用変数(#,##0時間 #0分)

        Try

            '@情報取得日時表示
            lblNowDate.Text = Format$(Now, CPstrDateFormat)
            
            '@ﾛｯﾄ情報の表示
            With ltypLotDetailInfo
                txtCarrierID.Text = .strCarrierId                                           'ｷｬﾘｱID
                txtLotID.Text = .strLotID                                                   'ﾛｯﾄID
            
                '@各情報設定
                lblPdID.Text = .strPdId                                                     '機種ID
                lblFlowClass.Text = .strFlowClass                                           '流動区分
                lblLotPriority.Text = .strLotPriority & Space(1) & .strLotPriorityName      '優先度
                '@↓2019/12/27 (Fri) 14:38:05 Y.Yoneyama 「.Netへ反映未」 **************************************************
                lblGRB.Text = .strGRBClass                                                  'GRB
                '@GRB背景色
                lblGRB.BackColor = pubGRBBackColor(.strGRBClass, lblLotManager.BackColor)
                '@↑2019/12/27 (Fri) 14:38:05 Y.Yoneyama 「.Netへ反映未」 **************************************************

                '@ﾌｫｰﾏｯﾄ変換(WF)
                If IsNumeric(.strWfNum) Then
                    lblWfNum.Text = Format$(CLng(.strWfNum), CPstrDateFormatKanma)                      'WF枚数
                Else
                    lblWfNum.Text = .strWfNum
                End If
                
                '@ﾌｫｰﾏｯﾄ変換(ﾁｯﾌﾟ)
                If IsNumeric(.strChipQuantity) Then
                    lblChipQuantity.Text = Format$(CLng(.strChipQuantity), CPstrDateFormatKanma)        'ﾁｯﾌﾟ数
                Else
                    lblChipQuantity.Text = .strChipQuantity
                End If
                
                lblLotManager.Text = .strEngEmpName                                                     'ﾛｯﾄ担当者名
                lblCurrentPositionName.Text = .strCurrentPositionName                                   'ﾛｯﾄ位置(和名)
                lblLastEventName.Text = .strLastEventName                                               '最終ｲﾍﾞﾝﾄ名
                IF IsDate(.strEntryTime) Then
                    lblEntryTime.Text = Format(CDate(.strEntryTime), CPstrDateFormat)                   '最終ｲﾍﾞﾝﾄ日時
                Else
                    lblEntryTime.Text = .strEntryTime
                End if
                lblEmpName.Text = .strEmpName                                                           '最終更新者
                
                '@ｺﾒﾝﾄ欄
                txtComments.Text = .strComments
                txtComments.Enabled = True
                txtComments.Locked = True
                
                lblSpecialFlg.Text = .strSpecialFlg                                                     '特殊特性
                
                '@ﾛｯﾄ保留停止ﾌﾗｸﾞ
                If .strLotHoldFlag = CMstrAriFlag1 Then
                    lblLotHoldStopFlag.Text = CMstrLotHoldName & Space(1)
                End If
                If .strLotStopFlag = CMstrAriFlag1 Then
                    lblLotHoldStopFlag.Text = lblLotHoldStopFlag.Text & CMstrLotStopName
                End If
                
                lblNowSt.Text = .strNowST                                                               'LOT状態
                IF IsDate(.strDispatchStartTime) Then
                    lblDispatchStartTime.Text = Format$(CDate(.strDispatchStartTime), CPstrDateFormat)  '投入予定時刻
                Else
                    lblDispatchStartTime.Text = .strDispatchStartTime
                End If
                lblOpID.Text = .strOpID                                                                 '大工程ID
                lblStepID.Text = .strStepID                                                             '小工程ID
                
                '@代替・入替工程有無ﾌﾗｸﾞ
                If .strAltFlag = CMstrAriFlag1 Or .strSwapFlag = CMstrAriFlag1 Then
                    lblAltSwapFlag.Text = CPstrAriFlg                                                   '代替・入替工程有無ﾌﾗｸﾞ
                End If
                
                '@特殊流動
                lblReworkFlag.Text = .strReworkFlag
                
                lblBatchID.Text = .strBatchId                                                           'ﾊﾞｯﾁID
                mstrTaihiLimitTime = .strLimitTime                                                      '時間制限退避
                mstrTaihiWarnTime = .strWarnTime                                                        '警告時間退避
                mstrRestrictTypeID = .strRestrictTypeID                                                 '時間制限区分
                
                '@時間制約有無の表示
                If .strLimitTime <> vbNullString Then
                    '@時間制約がﾌﾟﾗｽの場合
                    If CLng(.strLimitTime) >= 0 Then
                        
        '@↓2006/06/08 (Thu) 14:28:41 N.Kojima **************************************************
                        '@制限時間以下or処理時間制限以下の場合
        '                If .strRestrictTypeID = CPstrRestrictTypeID1 Then
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@ﾌｫｰﾏｯﾄ変換(##,##0)
                            lstrLimitTime = Format(CLng(.strLimitTime), CPstrDateFormatKanma)
                            
                            '@制限時間先大工程+制限時間先小工程+制限時間+「以内」
        '@↓2006/05/12 (Fri) 10:58:17 T.Kitagawa **************************************************
        '                    lblLimitTime.Caption = .strToOpID _
        '                                         & CPstrSpace _
        '                                         & .strToStepID _
        '                                         & CPstrMade _
        '                                         & lstrLimitTime _
        '                                         & CPstrh _
        '                                         & CPstrinai
                            '@制限時間を時間と分で分割表示する
                            lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)
                            lblLimitTime.Text = .strToOpId _
                                                 & CPstrSpace _
                                                 & .strToStepId _
                                                 & CPstrMade _
                                                 & lstrLimitTimeAns _
                                                 & CPstrinai
        '@↑2006/05/12 (Fri) 10:58:17 T.Kitagawa **************************************************
                            
                            '@警告時間が設定されている場合
                            If .strWarnTime <> vbNullString Then
                                '@時間制限が警告時間を過ぎている,且つ制限時間がｵｰﾊﾞｰしていない場合
                                If CLng(.strWarnTime) < 0 And CLng(.strLimitTime) >= 0 Then
                                    '@ﾌｫﾝﾄｶﾗｰを紫に変更
                                    lblLimitTime.ForeColor = ColorTranslator.FromWin32(CPlngVbColorPurple)         '紫色
                                Else
                                    '@ﾌｫﾝﾄｶﾗｰを黒に変更
                                    lblLimitTime.ForeColor = Color.Black                    '黒
                                End If
                            End If
                        End If
        '@↑2006/06/08 (Thu) 14:28:41 N.Kojima **************************************************
                        
                    Else
                    '@制限時間がﾏｲﾅｽの場合
                        '@ForColorの変更
                        lblLimitTime.ForeColor = ColorTranslator.FromWin32(CPlngVbColorRed)    '赤色
                        
        '@↓2006/06/08 (Thu) 14:29:36 N.Kojima **************************************************
                        '@制限時間以下or処理時間制限以下の場合
        '                If .strRestrictTypeID = CPstrRestrictTypeID1 Then
                        If .strRestrictTypeID = CPstrRestrictTypeID1 Or _
                            .strRestrictTypeID = CPstrRestrictTypeID3 Then
                            
                            '@ﾌｫｰﾏｯﾄ変換(##,##0)
                            lstrLimitTime = Format(CLng(.strLimitTime), CPstrDateFormatKanma)
                            
                            
                            '@制限時間先大工程+制限時間先小工程+制限時間+「以内」
        '@↓2006/05/12 (Fri) 11:00:08 T.Kitagawa **************************************************
        '                    lblLimitTime.Caption = .strToOpID _
        '                                         & CPstrSpace _
        '                                         & .strToStepID _
        '                                         & CPstrMade _
        '                                         & lstrLimitTime _
        '                                         & CPstrh _
        '                                         & CPstrinai
                            '@制限時間を時間と分で分割表示する
                            lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)
                            lblLimitTime.Text = .strToOpId _
                                                 & CPstrSpace _
                                                 & .strToStepId _
                                                 & CPstrMade _
                                                 & lstrLimitTimeAns _
                                                 & CPstrinai
        '@↑2006/05/12 (Fri) 11:00:08 T.Kitagawa **************************************************
                        End If
        '@↑2006/06/08 (Thu) 14:29:36 N.Kojima **************************************************
                        
                        '@制限時間以上の場合
                        If .strRestrictTypeID = CPstrRestrictTypeID2 Then
                            '@ﾏｲﾅｽ記号を取ってﾌｫｰﾏｯﾄ変換(##,##0)+"分"
                            lstrLimitTime = Replace(Format(CLng(.strLimitTime), CPstrDateFormatKanma), _
                                                    CPstrReplaceMinus, _
                                                    vbNullString)
                            
                            '@制限時間先大工程+制限時間先小工程+制限時間+「以上」
        '@↓2006/05/12 (Fri) 11:01:18 T.Kitagawa **************************************************
        '                    lblLimitTime.Caption = .strToOpID _
        '                                         & CPstrSpace _
        '                                         & .strToStepID _
        '                                         & CPstrMade _
        '                                         & lstrLimitTime _
        '                                         & CPstrh _
        '                                         & CPstrijyou
                            '@制限時間を時間と分で分割表示する
                            lstrLimitTimeAns = pubstrLimitTime_Set(lstrLimitTime)
                            lblLimitTime.Text = .strToOpId _
                                                 & CPstrSpace _
                                                 & .strToStepId _
                                                 & CPstrMade _
                                                 & lstrLimitTimeAns _
                                                 & CPstrijyou
        '@↑2006/05/12 (Fri) 11:01:18 T.Kitagawa **************************************************
                        End If
                    End If
                End If
                
                lblWpName.Text = .strWpName                                                  'WP名
                lblPortName.Text = .strPortName                                              'ﾎﾟｰﾄ名
                lblRecipeID.Text = .strRecipeId                                              'ﾚｼﾋﾟID
                
                '@ﾛｰﾀﾞｰ/ｱﾝﾛｰﾀﾞｰｷｬﾘｱID
                If .strLoaderCarrierID <> vbNullString Then
                    lblLoadUnloadCarrierID.Text = .strLoaderCarrierID _
                                                   & Space(1)
                End If
                If .strUnloaderCarrierID <> vbNullString Then
                    lblLoadUnloadCarrierID.Text = lblLoadUnloadCarrierID.Text _
                                                   & .strUnloaderCarrierID
                End If
                
                lblNextOpID.Text = .strNextOpId                                              '次大工程
                lblNextStepID.Text = .strNextStepId                                          '次小工程
                
                '@代替・入替次工程有無ﾌﾗｸﾞ
                If .strNextAltFlag = CMstrAriFlag1 _
                    Or .strNextSwapFlag = CMstrAriFlag1 Then
                    
                    lblNextAltSwapFlag.Text = CPstrAriFlg                                    '代替・入替次工程有無ﾌﾗｸﾞ
                End If
                
                lblDivideLotID.Text = .strDivideLotID                                        '分割親ﾛｯﾄID
                
                '@分割子ﾛｯﾄIDｺﾝﾎﾞと分割子ﾛｯﾄIDﾗﾍﾞﾙ
                cmbDivideLotID2.Clear
                lblDivideLotID2.Text = vbNullString                                          '分割子ﾛｯﾄID
                
                If .lngDivideLot2Cnt > 1 Then
                    '@2件以上の場合は1件目を初期表示し、有効にする
                    For llngCnt = 0 To .lngDivideLot2Cnt - 1
                        cmbDivideLotID2.AddItem(.typDivideLot2(llngCnt).strDivideLotID2)
                    Next llngCnt
                    
                    cmbDivideLotID2.ListIndex = 0
                    cmbDivideLotID2.Enabled = True
                    cmbDivideLotID2.Visible = True
                    lblDivideLotID2.Visible = False
                Else
                    If .lngDivideLot2Cnt = 0 Then
                        cmbDivideLotID2.Visible = False
                        lblDivideLotID2.Visible = True
                    Else
                        lblDivideLotID2.Text = .typDivideLot2(0).strDivideLotID2             '分割子ﾛｯﾄID
                        cmbDivideLotID2.Visible = False
                        lblDivideLotID2.Visible = True
                    End If
                End If
                
                '@ﾛｯﾄ最終更新日時
                mstrLotLastUpdate = .strLotLastUpdate
                
                '@状態が空白(＝流動外)の場合
                If .strNowST = vbNullString _
                    Or txtCarrierID.Text = vbNullString _
                    Or txtLotID.Text = vbNullString Then
                    
                    '@ｺﾏﾝﾄﾞﾎﾞﾀﾝを無効にする
                    cmdCommntInput.Enabled = False                              'ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ
                    cmdTreatChip.Enabled = False                                'ﾁｯﾌﾟ処置登録ﾎﾞﾀﾝ
                Else
                '@状態が空白以外の場合
                    '@ﾛｯﾄｺﾒﾝﾄの制御
                    Select Case .strNowST
                    
                        '@「投入待ち」、「送品待ち」の場合
                        Case CPstrWaitThrowSt, CPstrSendBeforeST
                            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝを有効にする
                            cmdCommntInput.Enabled = False                              'ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ使用不可
                        Case Else
                            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝを有効にする
                            cmdCommntInput.Enabled = True                               'ﾛｯﾄｺﾒﾝﾄﾎﾞﾀﾝ使用可
                    End Select
                    
                    '@CFﾌﾗｸﾞが立っている場合
                    Select Case ltypLotDetailInfo.strCfFlag
                        Case CMstrZero
                        '@CFﾌﾗｸﾞが"0"の場合
                            '@ﾊﾟﾚｯﾄ情報ﾎﾞﾀﾝのﾛｯｸ
                            cmdCfPaletteInfo.Enabled = False
                            '@ﾁｯﾌﾟ処置ﾎﾞﾀﾝの活性化
                            cmdTreatChip.Enabled = True
                        
                        Case CMstrOne
                        '@CFﾌﾗｸﾞが"1"の場合
                            '@ﾊﾟﾚｯﾄ情報ﾎﾞﾀﾝの活性化
                            cmdCfPaletteInfo.Enabled = True
                            '@ﾁｯﾌﾟ処置ﾎﾞﾀﾝの活性化
                            cmdTreatChip.Enabled = False
                            
                            '@大板ﾌﾗｸﾞ判定
                            If ltypLotDetailInfo.strLpFlag = CPstrLP Then
                                '@ﾊﾟﾚｯﾄ情報ﾎﾞﾀﾝのﾛｯｸ
                                cmdCfPaletteInfo.Enabled = False
                                '@ﾁｯﾌﾟ処置ﾎﾞﾀﾝのﾛｯｸ
                                cmdTreatChip.Enabled = True
                            End If
                        
                        Case CMstrTwo
                        '@CFﾌﾗｸﾞが"2"の場合
                            '@ﾊﾟﾚｯﾄ情報ﾎﾞﾀﾝのﾛｯｸ
                            cmdCfPaletteInfo.Enabled = False
                            '@ﾁｯﾌﾟ処置ﾎﾞﾀﾝのﾛｯｸ
                            cmdTreatChip.Enabled = False
                            
                        Case Else
                        '@CFﾌﾗｸﾞが""の場合
                            '@ﾊﾟﾚｯﾄ情報ﾎﾞﾀﾝのﾛｯｸ
                            cmdCfPaletteInfo.Enabled = False
                            '@ﾁｯﾌﾟ処置ﾎﾞﾀﾝの活性化
                            cmdTreatChip.Enabled = True
                    End Select
                End If

                '@ODF関連表示
                lblODFCarrierID.Text = .strODFCarrierID                  '貼り合せｷｬﾘｱID
                lblOdfLotID.Text = .strODFLotID                          '貼り合せﾛｯﾄID
                
                
        '@↓2006/10/31 (Tue) 16:22:36 N.Kasai **************************************************
                Select Case .strLotSendFlag
                    '@送品なしの場合
                    Case CPlngLotSendNasi
                        lblLotSendFlag.Text = CPstrNasiFlg
                    '@送品ありの場合
                    Case CPlngLotSendAri
                        lblLotSendFlag.Text = CPstrAriFlg
                    Case Else
                        lblLotSendFlag.Text = vbNullString
                End Select
        '@↑2006/10/31 (Tue) 16:22:36 N.Kasai **************************************************
            
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxCM00R0_Disp"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcontrolSetFocus_Set
    '機　能：ｾｯﾄﾌｫｰｶｽ処理
    '引　数：lstrControlName：ｺﾝﾄﾛｰﾙ名(ｷｬﾘｱ/ﾛｯﾄ/Null)
    '戻り値：なし
    '作成日：2005/06/15 (Wed) 11:42:39 S.Deguchi
    '更新日：2005/06/15 (Wed) 11:42:39
    '備　考：
    Private Sub prvcontrolSetFocus_Set(ByVal lstrControlName As String)

        Try
            
            '@引数による処理判別
            Select Case lstrControlName
                '@ｷｬﾘｱID,ﾛｯﾄID 処理成功時
                Case CMstrControlNameCarrierID, CMstrControlNameLotID
                    '@ﾌｫｰｶｽ位置設定
                    '@CFﾊﾟﾚｯﾄﾎﾞﾀﾝが画面上に存在する場合
                    If cmdCfPaletteInfo.Visible = True Then
                        '@CFﾊﾟﾚｯﾄﾎﾞﾀﾝが使用可能な場合
                        If cmdCfPaletteInfo.Enabled = True Then
                            '@CFﾊﾟﾚｯﾄ情報ﾎﾞﾀﾝ
                            Call pubSetFocus(cmdCfPaletteInfo)
                        
                            Exit Sub
                        End If
                    End If
                    
                    If cmdCommntInput.Enabled = True Then
                        '@ｺﾒﾝﾄﾎﾞﾀﾝ
                        Call pubSetFocus(cmdCommntInput)
                        
                        Exit Sub
                    End If
                    
                    If cmdTreatChip.Enabled = True Then
                        '@ﾁｯﾌﾟ状態変更ﾎﾞﾀﾝ
                        Call pubSetFocus(cmdTreatChip)
                        
                        Exit Sub
                    End If
                    
                    If cmdLotInfo.Enabled = True Then
                        '@最新取得ﾎﾞﾀﾝ
                        Call pubSetFocus(cmdLotInfo)
                        
                        Exit Sub
                    End If
                    
                    '@閉じるﾎﾞﾀﾝ
                    Call pubSetFocus(cmdLotInfo)

                '@ｷｬﾘｱID,ﾛｯﾄID 情報取得済時
                Case Else
                    Select Case ActiveControl.Name
                        Case txtCarrierID.Name
                        '@ｷｬﾘｱIDの場合
                            '@ﾛｯﾄID欄へﾌｫｰｶｽ
                            Call pubSetFocus(txtLotID)
                            
                        Case txtLotID.Name
                        '@ﾛｯﾄIDの場合
                            '@最新取得ﾎﾞﾀﾝへﾌｫｰｶｽ
                            If cmdLotInfo.Enabled = True Then
                                Call pubSetFocus(cmdLotInfo)
                            Else
                                Call pubSetFocus(cmdClose)
                            End If
                    End Select
            End Select
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcontrolSetFocus_Set"     '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnlotdetail_Get
    '機　能：ﾛｯﾄ詳細情報取得処理
    '引　数：lstrClassDivision：処理区分(OK：ｷｬﾘｱ指定/0L：ﾛｯﾄ指定)
    '戻り値：True：成功/False：失敗
    '作成日：2005/06/15 (Wed) 11:42:43 S.Deguchi
    '更新日：2005/06/15 (Wed) 11:42:43
    '備　考：
    Private Function prvblnlotdetail_Get(ByVal lstrClassDivision As String) As Boolean

        Dim ltypLotDetailInfo       As LotDetailInfo        'ﾛｯﾄ詳細情報構造体
        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrCarrierID           As String               'ｷｬﾘｱID退避
        Dim lstrLotID               As String               'ﾛｯﾄID退避
        
        Try

            '@初期化
            prvblnlotdetail_Get = False
            
            '@引数：ClassDivisionによる処理判別
            Select Case lstrClassDivision
                '@ｷｬﾘｱIDで取得
                Case CPstrCD0K
                    '@情報取得準備の為,内部変数へ退避
                    lstrCarrierID = txtCarrierID.Text
                    lstrLotID = vbNullString
                    
                '@ﾛｯﾄID出取得
                Case CPstrCD0L
                    '@情報取得準備の為,内部変数へ退避
                    lstrCarrierID = vbNullString
                    lstrLotID = txtLotID.Text
            End Select
            
            '@ﾛｯﾄ情報詳細取得処理
            lblnAns = pubblnLotDetail_Sel(CMstrlot_detail__Ver, _
                                          pstrSBID, _
                                          lstrClassDivision, _
                                          lstrLotID, _
                                          lstrCarrierID, _
                                          ltypLotDetailInfo)
            '@結果判定
            If lblnAns = True Then
            '@取得成功の場合
                '@ﾛｯﾄ情報欄の初期化
                Call prvfrmxxCM00R0_Init()
                
                '@ﾛｯﾄ詳細情報の画面表示処理
                Call prvfrmxxCM00R0_Disp(ltypLotDetailInfo)
                
                '@ｷｬﾘｱID、ﾛｯﾄIDの退避
                mstrTaihiCarrierID = txtCarrierID.Text
                mstrTaihiLotID = txtLotID.Text
            
                '@成功を返す
                prvblnlotdetail_Get = True
            Else
                '@失敗を返す
                prvblnlotdetail_Get = False
            End If
            
            Exit Function
            

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnlotdetail_Get"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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


    '関数名：groupBox_paint
    '機　能：GroupBoxの枠線表示処理
    '作成日：2018/11/06 (Tue) 10:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraHosokuInfo.Paint, fraKisoInfo.Paint, fraKouteiInfo.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub

End Class
