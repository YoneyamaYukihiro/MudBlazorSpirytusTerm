'ﾌｧｲﾙ名：xxEM02D1.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：治具登録
'作成日：2009/05/28 (Thr) 19:55:51 K.Nishizawa
'更新日：2009/05/28 (Thr) 19:55:51
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02D1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02D1    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02D1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02D1
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02D1)
            Dim old_inst As Form
            old_inst = _instance
            _instance = value
            If old_inst IsNot Nothing AndAlso Not old_inst.IsDisposed Then
                old_inst.Close()
                old_inst.Dispose()
            End If
        End Set
    End Property
        
    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN02D1

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrjig_jycadd___Ver                 As String = "01.01"         '蒸着治具情報一覧取得MsgVer

    '***************************************************************************************
    '                                   * 定数の記述 *
    '***************************************************************************************
    '======================================Public===========================================
    '======================================Private==========================================
	
	'@蒸着治具ｶﾃｺﾞﾘｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbGridColName                   As Integer = 0                 '名称列番
    Private Const CMlngCmbGridColID                     As Integer = 1                 'ID列番(非表示項目)
    Private Const CMlngCmbDispCols                      As Integer = 1                 'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbListIndex                     As Integer = 0                 'ﾘｽﾄｲﾝﾃﾞｯｸｽ
    Private Const CMlngCmbRowHeight                     As Integer = 18					'ﾘｽﾄ行の高さ
    Private Const CMlngCmbFontSize                      As Integer = 11                'ﾌｫﾝﾄｻｲｽﾞ


	'蒸着治具カテゴリコンボ
	Private Const CMstrCmbJJigCategoryGuideId			As String = "G"
	Private Const CMstrCmbJJigCategoryGuideNm			As String = "ガイドリング"
	Private Const CMstrCmbJJigCategoryMaskId			As String = "M"
	Private Const CMstrCmbJJigCategoryMaskNm			As String = "マスク"
	Private Const CMstrCmbJJigCategoryHolderId			As String = "H"
	Private Const CMstrCmbJJigCategoryHolderNm			As String = "ホルダ"
	Private Const CMstrCmbJJigCategoryDummyId			As String = "D"
	Private Const CMstrCmbJJigCategoryDummyNm			As String = "ダミープレート"

	Private mblnEventCancelFlag                         As Boolean                          'ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞ
	Private mstrcmbJJigCategory                          As String                           '蒸着治具ｶﾃｺﾞﾘ退避用
    '***************************************************************************************
    '                                   * 変数の記述 *
    '***************************************************************************************
    '======================================Public===========================================
    '======================================Private==========================================
    Private buttonProcessing                             As Boolean              'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                     As Boolean              'NSYS システムコマンドでの画面クローズ
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
    '作成日：2004/09/27 (Mon) 19:13:29 N.Kasai
    '更新日：2004/09/27 (Mon) 19:13:29
    '備　考：
    Private Sub Form_Load()

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@画面初期化
            Call prvfrmxxEN02D1_Init()

			'@コンボ設定
			'@蒸着治具カテゴリコンボ設定
			If pstrJJigCategoryId <> vbNullString Then
				cmbJJigCategory.Enabled = True
				With cmbJJigCategory
					.Clear
					.BackColor = SystemColors.Window
					.DirectInput = False
					.DispCols = CMlngCmbDispCols
					.GetCol = CMlngCmbGridColName
					.ValueCol = CMlngCmbGridColID
                
					'@選択ﾘｽﾄ設定
					.AddItem(CMstrCmbJJigCategoryGuideNm & vbTab & CMstrCmbJJigCategoryGuideId)         'ガイドリング
					.AddItem(CMstrCmbJJigCategoryMaskNm & vbTab & CMstrCmbJJigCategoryMaskId)			'マスク
					.AddItem(CMstrCmbJJigCategoryHolderNm & vbTab & CMstrCmbJJigCategoryHolderId)		'ホルダ
					.AddItem(CMstrCmbJJigCategoryDummyNm & vbTab & CMstrCmbJJigCategoryDummyId)			'ダミープレート
                
					'@ﾌｫﾝﾄｻｲｽﾞ設定、初期値設定
					.GridFont = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)
					.ListIndex = CMlngCmbListIndex

				End With
			Else
				cmbJJigCategory.Enabled = False
			End If


            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose

			pblnFormLoad = True

            Exit Sub

        Catch ex As Exception

			pblnFormLoad = False
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
    '作成日：2004/09/27 (Mon) 19:13:29 N.Kasai
    '更新日：2004/09/27 (Mon) 19:13:29
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
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
    '作成日：2004/09/27 (Mon) 19:21:12 N.Kasai
    '更新日：2004/09/27 (Mon) 19:21:12
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
                                   
            Call frmxxEN02D0.Instance.cmdNowList_Click(frmxxEN02D0.Instance.cmdNowList,New EventArgs)

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
    '作成日：2004/09/27 (Mon) 19:15:28 N.Kasai
    '更新日：2009/07/23 (Thu) 09:15:21 T.Oide
    '備　考：
    Private Sub cmdSet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSet.Click

        Dim lblnAns                 As Boolean              '結果取得(True:正常,False:異常)
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
            
            'ﾃﾞｰﾀｾｯﾄ
            pstrJigID = txtJigID.Text
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "cmdSet_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '蒸着治具登録Msg実行
            lblnAns = pubblnJycJigData_Add(CMstrjig_jycadd___Ver, cmbJJigCategory.value)
            '@ﾒｯｾｰｼﾞ送信処理呼び出し
            If lblnAns = True Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006Y, txtJigID.Text)
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
                '@ｷｬﾘｱID格納（親画面に引継ぎ）
                pstrJigID = txtJigID.Text

                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@画面を閉じる
                Me.Close()
            
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                '@ｷｬﾘｱﾀｲﾌﾟにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(txtJigID)
                '@画面を閉じる
                Me.Close()
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
    '作成日：2004/09/27 (Mon) 19:03:08 N.Kasai
    '更新日：2004/09/27 (Mon) 19:03:08
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

    '関数名：txtJigID_Change
    '機　能：ｷｬﾘｱID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/27 (Mon) 21:32:43 N.Kasai
    '更新日：2004/09/27 (Mon) 21:32:43
    '備　考：
    Private Sub txtJigID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtJigID.Change

        Try
            
            '@確定ﾎﾞﾀﾝ使用可否判定
            If txtJigID.Text <> vbNullString Then
                cmdSet.Enabled = True
            Else
                cmdSet.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtJigID_Change"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtJigID_KeyPress
    '機　能：ｷｬﾘｱIDのKeyPress処理
    '引　数：KeyAscii：ｱｽｷｰｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/10/04 (Mon) 10:27:59 S.Deguchi
    '更新日：2004/10/04 (Mon) 10:27:59
    '備　考：
    Private Sub txtJigID_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtJigID.KeyPress

        Try

            '@ｴﾝﾀｰｷｰかﾁｪｯｸ
            If Asc(e.KeyChar) = Keys.Return Then
                '@確定処理実行
                Call cmdSet_Click(cmdSet,New EventArgs)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtJigID_KeyPress"
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

    '関数名：prvfrmxxCM00C1_Init
    '機　能：画面初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/27 (Mon) 19:05:51 N.Kasai
    '更新日：2004/09/27 (Mon) 19:05:51
    '備　考：
    Private Sub prvfrmxxEN02D1_Init()

        Try

            '@ｷｬﾘｱIDの初期化
            txtJigID.Text = vbNullString

            '@確定ﾎﾞﾀﾝの使用不可
            cmdSet.Enabled = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxEN02D1_Init"
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
    '作成日：2004/09/27 (Mon) 19:30:06 N.Kasai
    '更新日：2004/09/27 (Mon) 19:30:06
    '備　考：
    Private Function prvblnInput_Chk() As Boolean

        Try
            
            prvblnInput_Chk = False
            
            '@ｷｬﾘｱIDﾁｪｯｸ
            If Trim(txtJigID.Text) = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009N)
               '@"治具IDが設定されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                Call pubSetFocus(txtJigID)
                Exit Function
            Else
                '@ｷｬﾘｱIDの桁ﾁｪｯｸ
                If txtJigID.NowByte < txtJigID.ChrMaxByte Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009O)
                    '@"治具IDは6桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Call pubSetFocus(txtJigID)
                    Exit Function
                End If
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
                lblnWMClose = True

        End Select

        MyBase.WndProc(m)

        If lblnSysCommandScClose = True Then
            'NSYS SC_CLOSE 処理後 WM_CLOSE が発生しないでキャンセルされることもあるため、フラグを戻す
            'NSYS WM_CLOSE が発生していれば、すでにこの時点では画面は閉じている
            mblnCloseFromControlMenu = False
        End If
    End Sub

End Class