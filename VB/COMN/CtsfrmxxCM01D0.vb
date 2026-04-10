'ﾌｧｲﾙ名：xxCM01D0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：現品票ﾗﾍﾞﾙ読込
'作成日：2018/12/26 (Wed) 14:25:51 Y.Yoneyama
'更新日：2019/08/07 (Wed) 11:52:21 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2019, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM01D0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM01D0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM01D0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM01D0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM01D0)
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
    '                                   * 定数の記述 *
    '***************************************************************************************
    '======================================Public===========================================
    '======================================Private==========================================
    Private Const CPstrlot_workaldlotlistVer    As String = "01.00"         '防湿ALD作業作業ﾛｯﾄ一覧

    '@ﾛｰｶﾙ機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyCM01D0  'ﾛｰｶﾙ機能ID

    Private Const CMlngLotIdLength              As Integer = 10

    '***************************************************************************************
    '                                   * 変数の記述 *
    '***************************************************************************************
    '======================================Public===========================================
    '======================================Private==========================================
    Private mstrLotId                           As String

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
    '                              * イベントハンドラの記述 *
    '***************************************************************************************
    '======================================Private==========================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/12/26 (Wed) 14:25:51 Y.Yoneyama
    '更新日：2018/12/26 (Wed) 14:25:51 Y.Yoneyama
    '備　考：
    Private Sub Form_Load()

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@画面初期化
            Call prvfrmxxCM01D0_Init()

            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose

            pblnFormLoad = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Load"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ﾌｫｰﾑｷｰﾀﾞｳﾝ制御
    '引　数：KeyCode    ：ｷｰﾀﾞｳﾝ
    '　　　：Shift      ：Shift/Ctrl/Altﾎﾞﾀﾝ有無
    '戻り値：なし
    '作成日：2018/12/26 (Wed) 14:25:51 Y.Yoneyama
    '更新日：2018/12/26 (Wed) 14:25:51 Y.Yoneyama
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

        '    '@ｷｰｺｰﾄﾞ判定
        '    Select Case KeyCode
        '        Case vbKeyReturn    '[ENTER]押下
        '            '@ﾌｫｰｶｽの移動
        '            SendKeys CPstrSendKeysTab, True
        '            KeyCode = 0
        '    End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_KeyDown"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑの初期化
    '引　数：Cancel    ：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2018/12/26 (Wed) 14:25:51 Y.Yoneyama
    '更新日：2018/12/26 (Wed) 14:25:51 Y.Yoneyama
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If

            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_QueryUnload"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSet_Click
    '機　能：確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/12/26 (Wed) 14:25:51 Y.Yoneyama
    '更新日：2018/12/26 (Wed) 14:25:51 Y.Yoneyama
    '備　考：
    Private Sub cmdSet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSet.Click

        Dim lblnAns             As Boolean              '結果取得(True:正常,False:異常)
        Dim lstrFormName        As String               'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim ltypWorkALDLotList  As WorkALDLotList


        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@画面入力ﾁｪｯｸ
            lblnAns = prvblnInput_Chk
            If lblnAns = False Then
                Exit Sub
            End If
            
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "cmdSet_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@ﾒｯｾｰｼﾞ送信処理呼び出し
            lblnAns = pubblnWorkLotList_Sel(CPstrlot_workaldlotlistVer, _
                                            mstrLotId, _
                                            vbNullString, _
                                            pstrSBID, _
                                            ltypWorkALDLotList)
                                            
            If lblnAns = True Then
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002K, mstrLotId, ltypWorkALDLotList.strCarrierId)
                '@成功ﾒｯｾｰｼﾞ表示
                '@「<TRM2KI>$$バーコードを読取ました。ロット[%2] キャリア[%1]」
                Call pubVsfInfo_Disp(pstrDMsg)
                
                '@ﾊﾞｰｺｰﾄﾞ格納（親画面に引継ぎ）
                pstrCarrierID = ltypWorkALDLotList.strCarrierId
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@画面を閉じる
                Me.Close()
            
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                '@ｷｬﾘｱﾀｲﾌﾟにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtBarcode)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdSet_Click"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClose_Click
    '機　能：閉じるﾎﾞﾀﾝ押下
    '引　数：なし
    '戻り値：なし
    '作成日：2018/12/26 (Wed) 14:25:51 Y.Yoneyama
    '更新日：2018/12/26 (Wed) 14:25:51 Y.Yoneyama
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@画面を閉じる
            Me.Close()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdClose_Click"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtBarcode_Change
    '機　能：ﾊﾞｰｺｰﾄﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/12/26 (Wed) 14:25:51 Y.Yoneyama
    '更新日：2018/12/26 (Wed) 14:25:51 Y.Yoneyama
    '備　考：
    Private Sub txtBarcode_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtBarcode.Change

        Try
            
            '@確定ﾎﾞﾀﾝ使用可否判定
            If txtBarcode.Text <> vbNullString Then
                cmdSet.Enabled = True
            Else
                cmdSet.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtBarcode_Change"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtBarcode_KeyPress
    '機　能：ﾊﾞｰｺｰﾄﾞのKeyPress処理
    '引　数：KeyAscii：ｱｽｷｰｺｰﾄﾞ
    '戻り値：なし
    '作成日：2018/12/26 (Wed) 14:25:51 Y.Yoneyama
    '更新日：2018/12/26 (Wed) 14:25:51 Y.Yoneyama
    '備　考：
    Private Sub txtBarcode_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtBarcode.KeyPress

        Try

            '@ｴﾝﾀｰｷｰかﾁｪｯｸ
            If Asc(e.KeyChar) = Keys.Return Then
                '@確定処理実行
                Call cmdSet_Click(cmdSet, New EventArgs)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtBarcode_KeyPress"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：prvfrmxxCM01D0_Init
    '機　能：画面初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2018/12/26 (Wed) 14:25:51 Y.Yoneyama
    '更新日：2018/12/26 (Wed) 14:25:51 Y.Yoneyama
    '備　考：
    Private Sub prvfrmxxCM01D0_Init()

        Try
            
            '@変数初期化
            mstrLotId = vbNullString

            '@ﾊﾞｰｺｰﾄﾞの初期化
            txtBarcode.Text = vbNullString

            '@確定ﾎﾞﾀﾝの使用不可
            cmdSet.Enabled = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxCM01D0_Init"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnInput_Chk
    '機　能：確定ﾎﾞﾀﾝﾁｪｯｸ
    '引　数：なし
    '戻り値：True:成功　False:失敗
    '作成日：2018/12/26 (Wed) 14:25:51 Y.Yoneyama
    '更新日：2019/08/02 (Fri) 10:16:12 Y.Yoneyama
    '備　考：
    Private Function prvblnInput_Chk() As Boolean

        Try
            
            prvblnInput_Chk = False
            
            '@ﾊﾞｰｺｰﾄﾞﾁｪｯｸ
            If Trim(txtBarcode.Text) = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002J)
                '@「"<TRM2JI>$$現品票ラベルのバーコード読取に失敗しました。」
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Call pubSetFocus(txtBarcode)
                Exit Function
            End If
            
        '@↓2019/08/02 (Fri) 10:16:35 Y.Yoneyama **************************************************
            '@ﾊﾞｰｺｰﾄﾞ仕様(千歳)(2019/08確認、諏訪南も千歳仕様と同じ)
            '@例「*BGJLLBGJA107S031147*」→「BGJLLBGJA107S031147」
            '@先頭:機種:5桁、ﾛｯﾄID:10桁、ﾁｯﾌﾟ数:4桁
            '@CODE39:前後に「*」が付くが読取結果には「*」なし
            
            '@ﾊﾞｰｺｰﾄﾞの桁ﾁｪｯｸ
            '@ﾛｯﾄID抽出、先頭から5桁～15桁まで(MAX桁は問わない)
            mstrLotId = Mid(Trim(txtBarcode.Text), 6, 10)
        '@↑2019/08/02 (Fri) 10:16:35 Y.Yoneyama **************************************************
            
            '@ﾛｯﾄID桁ﾁｪｯｸ
            If Len(mstrLotId) <> CMlngLotIdLength Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0012)
                '@「<TRM12W>$$ロットIDは10桁で入力してください。」
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Call pubSetFocus(txtBarcode)
                Exit Function
            End If
            
            prvblnInput_Chk = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnInput_Chk"
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
