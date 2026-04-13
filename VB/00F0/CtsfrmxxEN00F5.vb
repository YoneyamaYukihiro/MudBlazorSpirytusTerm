'ﾌｧｲﾙ名：xxEN00F5.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：送品伝票印刷(在庫管理サブフォーム)
'作成日：2004/11/29 (Mon) 13:59:20 H.Wajima
'更新日：2008/06/24 (Tue) 16:00:56 N.Kojima
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00F5
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00F5    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00F5
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00F5
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00F5)
            Dim old_inst As Form
            old_inst = _instance
            _instance = value
            If old_inst IsNot Nothing AndAlso Not old_inst.IsDisposed Then
                old_inst.Close()
                old_inst.Dispose()
            End If
        End Set
    End Property

    '*******************************************************************************
    '　　　　　　　　　　　　　　 　　* 型の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 定数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN00F5          'ﾛｰｶﾙ機能ID
    Private buttonProcessing                    As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                          'NSYS WindowCloseフラグ
    '*******************************************************************************
    '　　　　　　　　　　　　　　　　* 変数の記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================
    '*******************************************************************************
    '　　　　　　　　　　　　　      * ＡＰＩの記述 *
    '*******************************************************************************
    '================================== Public =====================================
    '================================== Private ====================================

    '*******************************************************************************
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
        'Form_Load()
        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '　　　　　　　　　　　　　* イベントハンドラの記述 *
    '*******************************************************************************
    '関数名：cmdCancel_Click
    '機　能：ｷｬﾝｾﾙﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/29 (Mon) 14:00:36 H.Wajima
    '更新日：2004/12/27 (Mon) 09:46:59 H.Wajima
    '備　考：2004/12/27 (Mon) 09:46:59 H.Wajima     ﾌﾟﾚﾋﾞｭｰ画面のLoad中にｷｬﾝｾﾙﾎﾞﾀﾝを押した場合の不具合対応
    '　　　：2005/02/23 (Wed) 11:26:04 S.Deguchi    検定票の印刷処理Subﾙｰﾁﾝ組み直しにより呼出修正
    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｷｬﾌﾟｼｮﾝの判定
            Select Case Me.Text
                Case CPstrSendOrderListPrintFormCaption
					'@送品伝票
					'@送品ﾌﾗｸﾞの判定
					If pblnLotSendFlag = True Then
						'@送品処理で印刷された場合
						'@ﾎﾞﾀﾝを連打できないように無効化する
						Me.Visible = False

						'@ﾛｯﾄ検定表の印刷処理を実行する
						Call frmxxEN00F0.pubLotExamInfoPrint_Proc

					End If

                    '@ﾌﾟﾚﾋﾞｭｰ画面をUnloadする
                    rptxxEN00F0.Instance.Close
                    rptxxEN00F0.Instance = Nothing

                Case CPstrLotExamInfoPrintFormCaption
                    '@ﾛｯﾄ検定表
                    '@送品ﾌﾗｸﾞの判定
                    If pblnLotSendFlag = True Then
                        '@送品処理で印刷された場合
                        '@ﾎﾞﾀﾝを連打できないように無効化する
                        cmdPrint.Enabled = False
                        cmdCancel.Enabled = False

                        '@完成在庫一覧の最新状態取得処理を実行する
                        Call frmxxEN00F0.instance.pubLotListSendRefresh_Proc

                        '@送品ﾌﾗｸﾞにFalseを設定する
                        pblnLotSendFlag = False
                    End If

                    '@ﾌﾟﾚﾋﾞｭｰ画面をUnloadする
                    rptxxEN00F1.Instance.Close
                    rptxxEN00F1.Instance = Nothing
                    Me.Close()
            End Select          
            '@ﾌｫｰﾑを閉じる(frmxxEN00F5以外の名前でLoadされるのでmeを使用)
            'Me.Close()
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCancel_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdPrint_Click
    '機　能：印刷ﾎﾞﾀﾝｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/29 (Mon) 14:00:51 H.Wajima
    '更新日：2004/12/27 (Mon) 09:47:34 H.Wajima
    '備　考：2004/12/27 (Mon) 09:47:34 H.Wajima     ﾌﾟﾚﾋﾞｭｰ画面のLoad中にｷｬﾝｾﾙﾎﾞﾀﾝを押した場合の不具合対応
    '　　　：2005/02/23 (Wed) 11:26:04 S.Deguchi    検定票の印刷処理Subﾙｰﾁﾝ組み直しにより呼出修正
    Private Sub cmdPrint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdPrint.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｷｬﾌﾟｼｮﾝの判定
            Select Case Me.Text
                Case CPstrSendOrderListPrintFormCaption
					'@送品伝票
					'@送品ﾌﾗｸﾞの判定
					If pblnLotSendFlag = True Then
						'@送品処理で印刷された場合
						'@ﾎﾞﾀﾝを連打できないように無効化する
						Me.Visible = False
						rptxxEN00F0.Visible = False

						'@ﾛｯﾄ検定表の印刷処理を実行する
						Call frmxxEN00F0.pubLotExamInfoPrint_Proc
					End If

                    '@ﾌﾟﾚﾋﾞｭｰで表示中の帳票を印刷する
                    rptxxEN00F0.Instance.pubPrintReport()
                    
                    '@ﾌﾟﾚﾋﾞｭｰ画面をUnloadする
                    rptxxEN00F0.Instance.Close
                    rptxxEN00F0.Instance = Nothing
                Case CPstrLotExamInfoPrintFormCaption
                    '@ﾛｯﾄ検定表
                    '@送品ﾌﾗｸﾞの判定
                    If pblnLotSendFlag = True Then
                        '@送品処理で印刷された場合
                        '@ﾎﾞﾀﾝを連打できないように無効化する
                        Me.Visible = False
                        rptxxEN00F1.Instance.Visible = False

                        '@完成在庫一覧の最新状態取得処理を実行する
                        Call frmxxEN00F0.Instance.pubLotListSendRefresh_Proc
                        '@送品ﾌﾗｸﾞにFalseを設定する
                        pblnLotSendFlag = False
                    End If

                    '@ﾌﾟﾚﾋﾞｭｰで表示中の帳票を印刷する
                    rptxxEN00F1.Instance.pubPrintReport()

                    '@ﾌﾟﾚﾋﾞｭｰ画面をUnloadする
                    rptxxEN00F1.Instance.Close
                    rptxxEN00F1.Instance = Nothing
                    Me.Close()
            End Select            

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdPrint_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑ ｸｴﾘｱﾝﾛｰﾄﾞ処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/11/29 (Mon) 14:04:07 H.Wajima
    '更新日：2004/12/27 (Mon) 09:48:02 H.Wajima
    '備　考：2004/12/27 (Mon) 09:48:02 H.Wajima  ﾌﾟﾚﾋﾞｭｰ画面のLoad中にｷｬﾝｾﾙﾎﾞﾀﾝを押した場合の不具合対応
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If

            'NSYS [Alt + F4]キーを押下した場合
            If mblnCloseFromControlMenu = True Then
                'NSYS 画面を終了しない
                e.Cancel = True
                Exit Sub
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
        If lblnWMClose = True Then
            'NSYS WM_CLOSE 処理後 終了がキャンセルされることもあるため、フラグを戻す
            'NSYS 終了処理されれば、すでにこの時点では画面は閉じている
            mblnWindowClose = False
        End If
    End Sub

End Class
