'ﾌｧｲﾙ名：xxCM00V0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：コメント表示(ロット投入(組立)、チップ状態変更登録)
'　　　：時間制限表示(ロット処理順変更)
'作成日：2004/08/03 (Tue) 14:34:29 S.Deguchi
'更新日：2010/01/27 (Wed) 11:34:45 N.Kojima
'備　考：共通ﾌｫｰﾑへ移動
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00V0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00V0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00V0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00V0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00V0)
            Dim old_inst As Form
            old_inst = _instance
            _instance = value
            If old_inst IsNot Nothing AndAlso Not old_inst.IsDisposed Then
                old_inst.Close()
                old_inst.Dispose()
            End If
        End Set
    End Property


    '****************************************************************************************
    '                                      *定数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyCM00V0          'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrlot_chgcmmentVer                 As String = "01.00"                 'ﾛｯﾄｺﾒﾝﾄ登録
    Private Const CMstrlot_comntinfo_Ver                As String = "01.00"                 'ﾛｯﾄｺﾒﾝﾄ取得

    '@ｺﾒﾝﾄｽｸﾛｰﾙ制御用
    Private Const CMlngMaxDispRow                       As Integer = 9                      'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '@ﾚｽﾎﾟﾝｽ用定数
    Private Const CMstrFormName                         As String = "frmxxCM00V0"           '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                         As String = "Form_Load"             'ｲﾍﾞﾝﾄ名称(ﾌｫｰﾑﾛｰﾄﾞ)
    Private Const CMstrCmdRegistClick                   As String = "cmdRegist_Click"       'ｲﾍﾞﾝﾄ名称(確定)
    Private ReadOnly vbButtonFace                       As Color = SystemColors.ControlLight    ' NSYS vbButtonFace定義
    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    Private mtypLotComntInfo                            As LotComntInfo                     'ﾛｯﾄｺﾒﾝﾄ格納構造体
    
    Private buttonProcessing                            As Boolean              'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean              'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean              'NSYS WindowCloseフラグ
    '****************************************************************************************
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
    '                                *イベントハンドラの記述*
    '****************************************************************************************
    '========================================Private=========================================

    '関数名：Form_Load
    '機　能：[ﾌｫｰﾑ]　起動時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/03 (Tue) 14:34:29 S.Deguchi
    '更新日：2010/01/27 (Wed) 13:32:34 N.Kojima
    '備　考：
    '　　　：2005/11/18 (Fri) 15:09:06 N.Kojima     ﾛｯﾄｺﾒﾝﾄ取得処理、Escﾎﾞﾀﾝ対応等のｿｰｽ整備対応追加。(ﾕｰｻﾞｰ要望№0119)
    '　　　：2005/12/02 (Fri) 11:35:40 N.Kojima     ｽｸﾛｰﾙﾎﾞﾀﾝ対応。(ﾕｰｻﾞｰ要望№0081)
    '　　　：2010/01/27 (Wed) 13:32:34 N.Kojima     ﾛｯﾄ処理順変更からも呼ばれるようになったことに伴う修正。(案件№03510)
    Private Sub Form_Load()

        Dim lblnAns     As Boolean      '結果取得(True:正常,False:異常)

        Try

            '@[Esc]ﾎﾞﾀﾝを無効にする
            '@ ※ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない為の対応
            Me.CancelButton = Nothing

            '@以下の条件の場合、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑのﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If

            '@起動区分が"1：ﾁｯﾌﾟ状態変更"か
            If plngfrmxxCM00V0Kbn = CPlngNumOne Then

                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(CMstrFormName, CMstrFormLoad)

                '@ﾌｫｰﾑをﾛｯｸ

                '@=======================
                '@ ﾛｯﾄｺﾒﾝﾄ取得
                '@=======================
                lblnAns = pubblnlotComntInfo_Sel(pstrCarrierID, _
                                                 CMstrlot_comntinfo_Ver, _
                                                 mtypLotComntInfo)

                '@ﾛｯﾄｺﾒﾝﾄ取得結果が"True：取得成功"か
                If lblnAns = True Then

                    '@[Esc]ﾎﾞﾀﾝを有効にする
                    Me.CancelButton = cmdClose

                    '@ﾌｫｰﾑﾛｯｸ解除

                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(CMstrFormName, CMstrFormLoad)

                    '@=======================
                    '@ 画面情報初期化処理
                    '@=======================
                    Call prvFrmxxCM00V0_Init()

                    '@各種ﾎﾞﾀﾝを無効にする
                    cmdUP.Enabled = False        '[▲]
                    cmdDown.Enabled = False      '[▼]

                    '@=======================
                    '@ 画面情報初期化処理
                    '@=======================
                    Call prvFrmxxCM00V0_Disp()

                Else
                    '@ﾛｯﾄｺﾒﾝﾄ取得結果が"False：取得失敗"の場合

                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = cmdClose

                    '@ﾌｫｰﾑﾛｯｸ解除

                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(CMstrFormName, CMstrFormLoad)
                End If
            Else
                '@ﾁｯﾌﾟ状態変更登録以外からの起動の場合(ﾛｯﾄ投入(組立)、ﾛｯﾄ処理順変更)

                '@[Esc]ﾎﾞﾀﾝを有効にする
                Me.CancelButton = cmdClose

                '@=======================
                '@ 画面情報初期化処理
                '@=======================
                Call prvFrmxxCM00V0_Init()

                '@各種ﾎﾞﾀﾝを無効にする
                cmdUP.Enabled = False                   '[▲]
                cmdDown.Enabled = False                 '[▼]

                '@=======================
                '@ 画面情報初期化処理
                '@=======================
                Call prvFrmxxCM00V0_Disp()
                
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_Load"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：[ﾌｫｰﾑ]　終了時処理
    '引　数：Cancel     ：ｷｬﾝｾﾙ値
    '　　　：UnloadMode ：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/08/03 (Tue) 14:34:29 S.Deguchi
    '更新日：2010/01/27 (Wed) 13:32:34 N.Kojima
    '備　考：
    '　　　：2005/11/18 (Fri) 15:50:28 N.Kojima     ｿｰｽ整備対応で、ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合等の処理追加。
    '　　　：2010/01/27 (Wed) 13:32:34 N.Kojima     ﾛｯﾄ処理順変更からも呼ばれるようになったことに伴う修正。(案件№03510)
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合は、終了処理をｷｬﾝｾﾙする
            If Cursor.Current = Cursors.WaitCursor Then

                e.Cancel = True
                Exit Sub
            End If

            '@ﾌｫｰﾑの"×"ﾎﾞﾀﾝ押下でのCallか
            If mblnCloseFromControlMenu Then

                '@=======================
                '@ [閉じる]ﾎﾞﾀﾝ押下処理
                '@=======================
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload           '@NSYS 閉じる処理抜け
                Call cmdClose_Click(cmdClose, New EventArgs)       
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
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

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComment_Change
    '機　能：[ｺﾒﾝﾄ/時間制限]ﾃｷｽﾄ　変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/18 (Fri) 15:20:42 N.Kojima
    '更新日：2010/01/27 (Wed) 13:32:34 N.Kojima
    '備　考：
    '　　　：2010/01/27 (Wed) 13:32:34 N.Kojima     ﾛｯﾄ処理順変更からも呼ばれるようになったことに伴う修正。(案件№03510)
    Private Sub txtComment_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtComment.Change

        Dim llngNowByte      As Integer  '現在のﾊﾞｲﾄ数

        Try

            '@現状のﾊﾞｲﾄ数を格納
            llngNowByte = txtComment.NowByte

            '@=======================
            '@ 表示文字列変換処理
            '@=======================
            '@現在の入力ﾊﾞｲﾄ数を表示する
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)

            '@=======================
            '@ ﾃｷｽﾄ変更処理((ｺﾒﾝﾄ系)ﾃｷｽﾄﾎﾞｯｸｽ共通仕様)
            '@=======================
            Call pubtxtChange_Proc(txtComment, CMlngMaxDispRow, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComment_Change"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComment_KeyUp
    '機　能：[ｺﾒﾝﾄ/時間制限]ﾃｷｽﾄ　ｷｰﾎﾞｰﾄﾞ操作時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2005/11/25 (Fri) 10:19:35 N.Kojima
    '更新日：2010/01/27 (Wed) 13:32:34 N.Kojima
    '備　考：
    '　　　：2010/01/27 (Wed) 13:32:34 N.Kojima     ﾛｯﾄ処理順変更からも呼ばれるようになったことに伴う修正。(案件№03510)
    Private Sub txtComment_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtComment.KeyUp

        Try

            '@=======================
            '@ ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作時処理((ｺﾒﾝﾄ系)ﾃｷｽﾄﾎﾞｯｸｽ共通仕様)
            '@=======================
            Call pubtxtKeyUp_Proc(e.KeyCode, txtComment, CMlngMaxDispRow, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComment_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComment_MouseUp
    '機　能：[ｺﾒﾝﾄ/時間制限]ﾃｷｽﾄ　ﾏｳｽ操作時処理
    '引　数：Button ：ﾎﾞﾀﾝ
    '　　　：Shift  ：ｼﾌﾄ
    '　　　：X      ：x座標
    '　　　：Y      ：y座標
    '戻り値：なし
    '作成日：2005/11/25 (Fri) 10:21:55 N.Kojima
    '更新日：2010/01/27 (Wed) 13:32:34 N.Kojima
    '備　考：
    '　　　：2010/01/27 (Wed) 13:32:34 N.Kojima     ﾛｯﾄ処理順変更からも呼ばれるようになったことに伴う修正。(案件№03510)
    Private Sub txtComment_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtComment.MouseUp

        Try

            '@=======================
            '@ ﾃｷｽﾄ変更処理((ｺﾒﾝﾄ系)ﾃｷｽﾄﾎﾞｯｸｽ共通仕様)
            '@=======================
            Call pubtxtChange_Proc(txtComment, CMlngMaxDispRow, cmdUP, cmdDown, e.Button)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComment_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：[▲]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/03 (Tue) 14:34:29 S.Deguchi
    '更新日：2010/01/27 (Wed) 13:32:34 N.Kojima
    '備　考：
    '　　　：2005/11/25 (Fri) 10:24:21 N.Kojima     ｽｸﾛｰﾙﾎﾞﾀﾝ対応。(ﾕｰｻﾞｰ要望№0081)
    '　　　：2010/01/27 (Wed) 13:32:34 N.Kojima     ﾛｯﾄ処理順変更からも呼ばれるようになったことに伴う修正。(案件№03510)
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
            '@ ﾃｷｽﾄﾎﾞｯｸｽ用上(▲)ｽｸﾛｰﾙﾎﾞﾀﾝ処理(共通仕様)
            '@=======================
            Call pubtxtCmdUp_Proc(txtComment, CMlngMaxDispRow, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUp_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown_Click
    '機　能：[▼]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/03 (Tue) 14:34:29 S.Deguchi
    '更新日：2010/01/27 (Wed) 13:32:34 N.Kojima
    '備　考：
    '　　　：2005/11/25 (Fri) 10:31:00 N.Kojima     ｽｸﾛｰﾙﾎﾞﾀﾝ対応。(ﾕｰｻﾞｰ要望№0081)
    '　　　：2010/01/27 (Wed) 13:32:34 N.Kojima     ﾛｯﾄ処理順変更からも呼ばれるようになったことに伴う修正。(案件№03510)
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
            '@ ﾃｷｽﾄﾎﾞｯｸｽ用下(▼)ｽｸﾛｰﾙﾎﾞﾀﾝ処理(共通仕様)
            '@=======================
            Call pubtxtCmdDown_Proc(txtComment, CMlngMaxDispRow, cmdUP, cmdDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDown_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：[確定]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/11/18 (Fri) 09:54:08 N.Kojima
    '更新日：2010/01/27 (Wed) 13:32:34 N.Kojima
    '備　考：
    '　　　：2006/01/25 (Wed) 13:44:32 N.Kasai      最終更新日時を親画面に引渡し(ﾁｯﾌﾟ状態変更画面)
    '　　　：2010/01/27 (Wed) 13:32:34 N.Kojima     ﾛｯﾄ処理順変更からも呼ばれるようになったことに伴う修正。(案件№03510)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns     As Boolean      '戻り値格納用(True:正常,False:異常)

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@以下の条件の場合、処理終了
            '@ ①ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合
            '@ ②ﾌｫｰﾑのﾛｯｸ中の場合
            If Cursor.Current = Cursors.WaitCursor Or _
                Me.Enabled = False Then

                Exit Sub
            End If

            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            '@ 作業者ｺｰﾄﾞ入力画面　表示処理
            '@∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞∞
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@作業者ｺｰﾄﾞ入力画面で[閉じる]ﾎﾞﾀﾝが押されたか
            If pblnCancel = True Then
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)

            '@ﾌｫｰﾑをﾛｯｸ

            '@=======================
            '@ ﾛｯﾄｺﾒﾝﾄ登録
            '@ ※最終更新日時は、確定時に返される値を使う。ﾒｯｾｰｼﾞ関数内で書き換えている。
            '@=======================
            lblnAns = pubblnLotChgComm_Upd(CMstrlot_chgcmmentVer, _
                                           pstrLotID, _
                                           pstrUserID, _
                                           txtComment.Text, _
                                           mtypLotComntInfo.strLotLastUpdate)

            '@ﾛｯﾄｺﾒﾝﾄ登録結果が"登録/更新成功"か
            If lblnAns = True Then

                '@ﾌｫｰﾑﾛｯｸ解除

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)

                '@表示ﾒｯｾｰｼﾞ変換
                '@「"<TRM16I>$$ロットコメントを登録しました。キャリア[%1] ロット[%2]"」のﾒｯｾｰｼﾞ表示
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0016, pstrCarrierID, pstrLotID)
                Call pubVsfInfo_Disp(pstrDMsg)

                '@[確定]ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False

                '@ﾛｯﾄの最終更新日時を引き継ぎ用変数に格納
                pstrLotLastUpdate = mtypLotComntInfo.strLotLastUpdate

                '@∇∇∇∇∇∇∇∇∇∇∇
                '@ ｱﾝﾛｰﾄﾞ処理
                '@∇∇∇∇∇∇∇∇∇∇∇
                Me.Close()

            Else
                '@ﾛｯﾄｺﾒﾝﾄ登録結果が"登録/更新失敗"の場合

                '@ﾌｫｰﾑﾛｯｸ解除

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRegist_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：[閉じる]ﾎﾞﾀﾝ　押下＆Click時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/03 (Tue) 14:34:29 S.Deguchi
    '更新日：2010/01/27 (Wed) 13:32:34 N.Kojima
    '備　考：
    '　　　：2010/01/27 (Wed) 13:32:34 N.Kojima     ﾛｯﾄ処理順変更からも呼ばれるようになったことに伴う修正。(案件№03510)
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@∇∇∇∇∇∇∇∇∇∇∇
            '@ ｱﾝﾛｰﾄﾞ処理
            '@∇∇∇∇∇∇∇∇∇∇∇
            Me.Close()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClose_Click"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================

    '関数名：prvFrmxxCM00V0_Init
    '機　能：画面情報初期化処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/03 (Tue) 14:34:29 S.Deguchi
    '更新日：2010/01/27 (Wed) 13:32:34 N.Kojima
    '備　考：
    '　　　：2005/11/18 (Fri) 14:01:51 N.Kojima     ﾁｯﾌﾟ状態変更登録からの起動区分を参照し、初期化処理を行なうように修正。(ﾕｰｻﾞｰ要望№0119)
    '　　　：2010/01/27 (Wed) 13:32:34 N.Kojima     ﾛｯﾄ処理順変更からも呼ばれるようになったことに伴う修正。(案件№03510)
    Private Sub prvFrmxxCM00V0_Init()

        Dim llngNowByte     As Integer  'ﾊﾞｲﾄ数格納

        Try

            '@起動区分が"1：ﾁｯﾌﾟ状態変更"か
            If plngfrmxxCM00V0Kbn = CPlngNumOne Then

                '@[ｺﾒﾝﾄ/時間制限]ﾃｷｽﾄの初期化
                With txtComment

                    .ChrMaxByte = CPlngLotCommentsMaxByte       'ｺﾒﾝﾄ最大入力ﾊﾞｲﾄ数：2048Byte
                    .Text = vbNullString                        'ﾃｷｽﾄ：NULL

                    '@=======================
                    '@ 現状のﾊﾞｲﾄ数を格納し、現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                    '@=======================
                    llngNowByte = .NowByte
                    lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)

                End With
            Else
                '@起動機能がﾁｯﾌﾟ状態変更以外の場合

                '@[ｺﾒﾝﾄ/時間制限]ﾃｷｽﾄの初期化
                With txtComment

                    .Text = vbNullString            'ﾃｷｽﾄ：NULL
                    .BackColor = vbButtonFace       '背景色：ｸﾞﾚｰ
                    .GotBackColor = vbButtonFace    'ﾌｫｰｶｽ取得時背景色：ｸﾞﾚｰ
                End With

                '@[確定]ﾎﾞﾀﾝを非表示＆無効にする
                cmdRegist.Visible = False
                cmdRegist.Enabled = False

        '@↓2010/01/27 (Wed) 17:05:43 N.Kojima **************************************************

                '@起動区分が"3：ﾛｯﾄ処理順変更"か
                If plngfrmxxCM00V0Kbn = CPlngNumThree Then

                    '@ﾃｷｽﾄのﾀｲﾄﾙを"時間制限"に変更
                    lblTextTitle.Text = CPstrSubFormCM00V0Restrict

                    '@[ｺﾒﾝﾄ/時間制限]ﾃｷｽﾄの初期化
                    With txtComment

                        .BackColor = Color.White                                            '背景色：白
                        .GotBackColor = Color.White                                         'ﾌｫｰｶｽ取得時背景色：白
                        .GotForeColor = ColorTranslator.FromWin32(plngRestrictForeColor)    'ﾌｫｰｶｽ取得時文字色：引継ぎ元情報による(赤or紫or黒)
                    End With
                End If

        '@↑2010/01/27 (Wed) 17:05:43 N.Kojima **************************************************

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxCM00V0_Init"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2010/01/28 (Thu) 11:09:13 N.Kojima **************************************************
    '関数名：prvFrmxxCM00V0_Disp
    '機　能：画面情報表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/03 (Tue) 14:34:29 S.Deguchi
    '更新日：2010/01/27 (Wed) 13:32:34 N.Kojima
    '備　考：
    '　　　：2005/11/18 (Fri) 14:04:40 N.Kojima     ﾁｯﾌﾟ状態変更登録からの起動区分を参照し、Lock処理を行なうように修正。(ﾕｰｻﾞｰ要望№0119)
    '　　　：2005/11/25 (Fri) 10:34:33 N.Kojima     ｽｸﾛｰﾙﾎﾞﾀﾝ対応。(ﾕｰｻﾞｰ要望№0081)
    '　　　：2010/01/27 (Wed) 13:32:34 N.Kojima     ﾛｯﾄ処理順変更からも呼ばれるようになったことに伴う修正。(案件№03510)
    Private Sub prvFrmxxCM00V0_Disp()

        Try

            '@★ 起動区分により処理分岐 ★
            Select Case plngfrmxxCM00V0Kbn

                '@〓 1：ﾁｯﾌﾟ状態変更 〓
                Case CPlngNumOne

                    '@ｺﾒﾝﾄを表示する(当機能で取得したｺﾒﾝﾄ)
                    txtComment.Text = mtypLotComntInfo.strComments

                    '@子画面のﾌｫｰﾑ名称設定(ﾛｯﾄｺﾒﾝﾄ)
                    Me.Text = CPstrSubFormCM00V1

                '@〓 2：ﾛｯﾄ投入(組立) 〓
                Case CPlngNumTwo

                    '@ｺﾒﾝﾄを表示(親画面からの引継ぎ情報)
                    txtComment.Text = ptypHoldConnect.strCommnents

                    '@子画面のﾌｫｰﾑ名称設定(ｺﾒﾝﾄ)
                    Me.Text = CPstrSubFormCM00V0Comments

                '@〓 3：ﾛｯﾄ処理順変更 〓
                Case CPlngNumThree

                    '@時間制限内容/文字色をｾｯﾄ(親画面からの引継ぎ情報)
                    txtComment.Text = pstrRestrictMessage

                    '@子画面のﾌｫｰﾑ名称設定(時間制限)
                    Me.Text = CPstrSubFormCM00V0Restrict

            End Select

            '@起動区分が"2以上：ﾛｯﾄ投入(組立)orﾛｯﾄ処理順変更"か
            If plngfrmxxCM00V0Kbn > 1 Then

                '@[ｺﾒﾝﾄ/時間制限]ﾃｷｽﾄをﾛｯｸする
                txtComment.Locked = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvFrmxxCM00V0_Disp"
                .strErrMessage = vbNullString
            End With

            '@=======================
            '@ 共通ｴﾗｰ処理
            '@=======================
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2010/01/28 (Thu) 11:09:13 N.Kojima **************************************************


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
