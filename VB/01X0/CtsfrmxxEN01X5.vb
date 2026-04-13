'ﾌｧｲﾙ名：xxEN01X5.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：時間制限
'作成日：2006/06/14 (Wed) 10:35:29 N.Kasai
'更新日：2006/06/14 (Wed) 10:35:29
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01X5
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01X5    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01X5
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01X5
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01X5)
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
    '@機能ID
    Private Const CMstrLocalMenuKey     As String = CPstrKeyEN01X5      'ﾛｰｶﾙ機能ID

    Private Const CMstrRestrict1        As String = "1"                 '制約ﾀｲﾌﾟ：制限時間以下
    Private Const CMstrRestrict2        As String = "2"                 '制約ﾀｲﾌﾟ：制限時間以上
    Private Const CMstrRestrict3        As String = "3"                 '制約ﾀｲﾌﾟ：処理時間以内

    '@時間制限番号のﾌｫｰﾏｯﾄ
    Private Const CMstrNoFormat         As String = "000"              '時間制限の表示ﾌｫｰﾏｯﾄ

    '@時間制限記号設定用
    Private Const CMstrTimeLimitMark    As String = "制"               '時間制限 頭文字
    Private Const CMstrStartMark        As String = "S"                '時間制限 開始文字
    Private Const CMstrEndMark          As String = "E"                '時間制限 終了文字
    Private Const CMstrHyphen           As String = "-"                'ﾊｲﾌﾝ
    Private Const CMstrComma            As String = ","                'ｶﾝﾏ
    '@ｴﾗｰﾒｯｾｰｼﾞ用
    Private Const CMstrMsgUnder         As String = "以下/"
    Private Const CMstrMsgOrver         As String = "以上/"

    '@初期化文字列
    Private Const CstrDefaultZero       As String = "0"


    '***************************************************************************************
    '                                   * 変数の記述 *
    '***************************************************************************************
    '======================================Public===========================================
    '======================================Private==========================================
    Private mstrTimeLimitNo             As String                       '時間制限番号
    Private mblnNewEdit                 As Boolean                      '新規ﾃﾞｰﾀ編集ﾌﾗｸﾞ（true:確定済み、false:未確定）
    Private mblnFormLoadFlag            As Boolean                      'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ
    Private mstrEditString              As String                       '編集内容
    Private buttonProcessing            As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu    As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose             As Boolean                      'NSYS WindowCloseフラグ
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
    '作成日：2006/06/05 (Mon) 10:24:16 N.Kasai
    '更新日：2006/06/05 (Mon) 10:24:16
    '備　考：
    Private Sub Form_Load()

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False
            
            '@画面表示の初期処理
            Call prvfrmxxEN01X5_Init()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Load"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑｱｸﾃｨﾍﾞｲﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/16 (Fri) 15:50:12 N.Kasai
    '更新日：2006/06/16 (Fri) 15:50:12
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            
            '@初回のみ走行
            If mblnFormLoadFlag = True Then
                Exit Sub
            End If
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞON
            mblnFormLoadFlag = True
            
            '@時間制限番号ﾛｯｸ
            If pblnEN01X5LockOn = True Then
                fraTimeLimit.Enabled = False
                cmbNo.BackColor = SystemColors.ControlLight
            Else
                fraTimeLimit.Enabled = True
                cmbNo.BackColor = Color.White
            End If
            
            '@新規ﾃﾞｰﾀの判別
            If pblnEN01X5NewData = True Then
                
                '@新規ﾃﾞｰﾀ表示（必ず1件）
                With ptypLTSelectList.typLTSelectList(0)
                    
                    '@時間制限番号を表示
                    cmbNo.Text = Format$(CInt(.strListOrder), CMstrNoFormat)   '制限番号
                    
                    lblFromOpId.Text = .strFromOpId                  '元大工程ID
                    lblFromStepId.Text = .strFromStepId              '元小工程ID
                    lblToOpId.Text = .strToOpId                      '先大工程ID
                    lblToStepId.Text = .strToStepId                  '先大工程ID
                    
                    '@制約ﾀｲﾌﾟ判定
                    Select Case .strRestrictTypeID
                    
                        Case CMstrRestrict1
                            OptTimeLimit1.Checked = True
                            '@制約ﾀｲﾌﾟ使用不可
                            OptTimeLimit3.Enabled = False
                        
                        Case CMstrRestrict2
                            OptTimeLimit2.Checked = True
                            '@制約ﾀｲﾌﾟ使用不可
                            OptTimeLimit3.Enabled = False
                        
                        Case CMstrRestrict3
                            OptTimeLimit3.Checked = True
                            '@制約ﾀｲﾌﾟ使用不可
                            OptTimeLimit1.Enabled = False
                            OptTimeLimit2.Enabled = False
                            
                        Case Else
                            '@初期値
                            OptTimeLimit1.Checked = True
                    End Select
                    
                    txtWarning.Text = CstrDefaultZero   '警告時間
                    txtLimit.Text = CstrDefaultZero     '制限時間
                
                End With
                
            Else
                '@既存ﾃﾞｰﾀ表示
                
                '@時間制限番号ｺﾝﾎﾞの設定
                Call prvCmbTimeLimitNo_Set()
                
                '@時間制限№処理を動作
                Call cmbNo_Validate(sender,New CancelEventArgs(True))
            
            End If

            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose

            'NSYS カーソルをハイライト
            Call pubSetFocus(cmbNo)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Activate"
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
    '作成日：2006/06/14 (Wed) 10:36:36 N.Kasai
    '更新日：2006/06/14 (Wed) 10:36:36
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If
            
            '@ｷｰｺｰﾄﾞ判定
            Select Case e.KeyCode
                Case Keys.Return    '[ENTER]押下
                    '@時間制限番号の場合
                    If ActiveControl.Name = cmbNo.Name Then
                        '@ﾌｫｰｶｽの移動/ﾊﾞﾘﾃﾞｨﾄ処理へ
                        If cmbNo.Text <> vbNullString Then
                            Call cmbNo_Validate(sender,New CancelEventArgs(True))
                        End If
                    Else
                        '@ﾌｫｰｶｽの移動
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                    End If
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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
    '引　数：Cancel    ：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2006/06/14 (Wed) 10:38:08 N.Kasai
    '更新日：2006/06/14 (Wed) 10:38:08
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim llngMsgAns  As Integer  'ﾒｯｾｰｼﾞ戻り値
        Dim lblnAns     As Boolean  '汎用戻り値
        
        
        Try
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If

            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose,New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@新規登録&未設定のまま画面を終了した場合
            '@新規ﾃﾞｰﾀの判別
            If pblnEN01X5NewData = True Then
                '@未設定のまま
                If mblnNewEdit = False Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf005O)
                    
                    '@"<TRM5OI>$$未確定のまま画面を終了するとデータは破棄されます。$よろしいですか？"
                    llngMsgAns = publngMsgBox(pstrDMsg & vbCrLf, vbNo, Me.Text, True, 16, False)
            
                    '@ﾒｯｾｰｼﾞﾎﾞｯｸｽの戻り値判定
                    Select Case llngMsgAns
                        Case vbYes      '「はい」を選択
                            
                            '@時間制限表示ｸﾘｱ
                            Call frmxxEN01X2.Instance.pubTimeLimitDisp_Del(cmbNo.Text)
                            
                            '@全くの初回の場合は減算なし
                            If plngTimeLimitCnt <> 1 Then
                                '@時間制限番号を減算
                                plngTimeLimitCnt = plngTimeLimitCnt - 1
                            End If
                            
                        Case vbNo       '「いいえ」を選択
                            e.Cancel = True
                            Exit Sub
                    End Select
                End If
            
            Else
                '@既存ﾃﾞｰﾀ&未設定のまま画面を終了した場合
                '@既存ﾃﾞｰﾀ編集ﾁｪｯｸ
                '@編集ﾁｪｯｸ
                lblnAns = prvblnEditString_Chk
                 
                If lblnAns = False Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001W)
                    '@"<TRM1WI>$$編集中のデータは破棄されます。終了してもよろしいですか？"
                    llngMsgAns = publngMsgBox(pstrDMsg & vbCrLf, vbNo, Me.Text, True, 16, False)

                    '@ﾒｯｾｰｼﾞﾎﾞｯｸｽの戻り値判定
                    Select Case llngMsgAns
                        Case vbYes      '「はい」を選択
                        
                        Case vbNo       '「いいえ」を選択
                            e.Cancel = True
                            Exit Sub
                    End Select
                
                End If
            
            End If
            
            '@初期化
            ptypLTSelectList.typLTSelectList = Nothing
            ptypLTSelectList.lngLTSelectListCnt = 0
            
            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_QueryUnload"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbNo_Change
    '機　能：時間制限番号の変更時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/15 (Thu) 13:11:35 N.Kasai
    '更新日：2006/06/15 (Thu) 13:11:35
    '備　考：
    Private Sub cmbNo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbNo.Change

        Dim llngMsgAns      As Integer  'ﾒｯｾｰｼﾞ戻り値
        Dim lblnAns         As Boolean  '汎用戻り値
        
        Try
            
            '@新規作成の場合は処理しない
            If pblnEN01X5NewData = True Then
                Exit Sub
            End If
            
            '@表示内容ｸﾘｱ
            Call prvfrmxxEN01X5_Init()
            
            '@画面が表示されていてる かつ 時間制限番号が変更されている かつ 編集ﾌﾗｸﾞが設定されている かつ 変更可能な時間制限の場合
            If cmbNo.Text <> mstrTimeLimitNo Then
                
                lblnAns = prvblnEditString_Chk
                
                If lblnAns = False Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf002H)
                    '@"<TRM2HI>$$編集中のデータは破棄されます。クリアしてもよろしいですか？"
                    llngMsgAns = publngMsgBox(pstrDMsg & vbCrLf, vbNo, Me.Text, True, 16, False)
                    '@ﾒｯｾｰｼﾞﾎﾞｯｸｽの戻り値判定
                    Select Case llngMsgAns
                        Case vbYes      '「はい」を選択
                            '@画面の初期化
                            Call prvfrmxxEN01X5_Init()
                        Case vbNo       '「いいえ」を選択
                            '@時間制限番号を元に戻す
                            cmbNo.Text = mstrTimeLimitNo
                            Exit Sub
                    End Select
                
                End If
                
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbNo_Change"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbNo_CloseUp
    '機　能：時間制限番号 ｸﾛｰｽﾞｱｯﾌﾟ時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:13:45 N.Kasai
    '更新日：2006/07/12 (Wed) 12:13:45
    '備　考：
    Private Sub cmbNo_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbNo.CloseUp

        Try
            
            '@ﾌｫｰｶｽの移動/ﾊﾞﾘﾃﾞｨﾄ処理へ
            If cmbNo.Text <> vbNullString Then
                Call cmbNo_Validate(sender,New CancelEventArgs(True))
                SendKeys.SendWait(CPstrSendKeysTab)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbNo_CloseUp"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbNo_Validate
    '機　能：時間制限番号　ﾊﾞﾘﾃﾞｨﾄ時
    '引　数：Cancel：未使用
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:14:00 N.Kasai
    '更新日：2006/07/12 (Wed) 12:14:00
    '備　考：
    Private Sub cmbNo_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbNo.Validating

        Dim lstrSearchString    As String   '検索用文字列
        Dim llngCnt             As Integer  'ｶｳﾝﾀ
        Dim llngIndex           As Integer  '対象ｲﾝﾃﾞｯｸｽ
        
        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@時間制限番号が空白の場合
            If cmbNo.Text = vbNullString Then
                Exit Sub
            End If
            
            If mstrTimeLimitNo = cmbNo.Text Then
                '@番号に変更なし
                Exit Sub
            End If
               
            '@時間制限番号の取得
            mstrTimeLimitNo = cmbNo.Text
            
            llngIndex = -1
            
            '@時間制限配列が存在する場合
            If ptypProcTimeLimitInfo.lngProcTimeLimitCnt > 0 Then
                For llngCnt = 0 To ptypProcTimeLimitInfo.lngProcTimeLimitCnt - 1
                    If Format$(CInt(ptypProcTimeLimitInfo.typProcTimeLimit(llngCnt).strListOrder), CMstrNoFormat) = _
                            Format$(CInt(cmbNo.Text), CMstrNoFormat) Then
                        '@対象ｲﾝﾃﾞｯｸｽを退避
                        llngIndex = llngCnt
                    End If
                Next
            End If
            
            '@対象ﾃﾞｰﾀ存在ﾁｪｯｸ
            If llngIndex = -1 Then
                '@ﾃﾞｰﾀ例外
                Exit Sub
            End If
            
            With ptypProcTimeLimitInfo.typProcTimeLimit(llngIndex)
                lblFromOpId.Text = .strFromOpId                      '元大工程ID
                lblFromStepId.Text = .strFromStepId                  '元小工程ID
                lblToOpId.Text = .strToOpId                          '先大工程ID
                lblToStepId.Text = .strToStepId                      '先大工程ID
                
                '@制限ﾀｲﾌﾟIDの判定
                Select Case .strRestrictTypeID                       '制限ﾀｲﾌﾟID
                    '@制限時間以下の場合
                    Case CMstrRestrict1
                        OptTimeLimit1.checked = True        'ﾁｪｯｸON
                        OptTimeLimit2.checked = False       'ﾁｪｯｸOFF
                        OptTimeLimit3.checked = False       'ﾁｪｯｸOFF
                        
                        '@制約ﾀｲﾌﾟ
                        OptTimeLimit1.Enabled = True
                        OptTimeLimit2.Enabled = True
                        OptTimeLimit3.Enabled = False
                        
                    '@制限時間以上の場合
                    Case CMstrRestrict2
                        OptTimeLimit1.checked = False       'ﾁｪｯｸOFF
                        OptTimeLimit2.checked = True        'ﾁｪｯｸON
                        OptTimeLimit3.checked = False       'ﾁｪｯｸOFF
                        
                        '@制約ﾀｲﾌﾟ
                        OptTimeLimit1.Enabled = True
                        OptTimeLimit2.Enabled = True
                        OptTimeLimit3.Enabled = False
                        
                    '@制限時間以下の場合
                    Case CMstrRestrict3
                        OptTimeLimit1.checked = False       'ﾁｪｯｸOFF
                        OptTimeLimit2.checked = False       'ﾁｪｯｸOFF
                        OptTimeLimit3.checked = True        'ﾁｪｯｸOFF
                        
                        '@制約ﾀｲﾌﾟ
                        OptTimeLimit1.Enabled = False
                        OptTimeLimit2.Enabled = False
                        OptTimeLimit3.Enabled = True
                End Select
                
                txtWarning.Text = .strWarnTime   '警告時間
                txtLimit.Text = .strLimitTime    '制限時間
                
                '@元大工程/小工程が空欄の場合
                If lblFromOpId.Text = vbNullString Or lblFromStepId.Text = vbNullString Then
                    '@ﾌﾚｰﾑﾛｯｸ
                    fraLimitType.Enabled = False

                    '@非活性化
                    OptTimeLimit1.Enabled = False
                    OptTimeLimit2.Enabled = False
                    OptTimeLimit3.Enabled = False
                End If
            
                '制限ﾀｲﾌﾟ判定
                If .strRestrictTypeID = CMstrRestrict3 Then
                    '@検索文字列を作成
                    lstrSearchString = cmbNo.Text
                Else
                    '@検索文字列を作成[終了]
                    lstrSearchString = cmbNo.Text & CMstrHyphen & CMstrEndMark
                End If
            
            End With
            
            '@現工程以前の場合
            If frmxxEN01X2.Instance.pubblnTimeLimitBeforeCur_Chk(lstrSearchString) = True Then
                
                '@編集不可能
                'fraLimitTime.Enabled = False
                txtWarning.Enabled = False
                txtLimit.Enabled = False
                fraLimitType.Enabled = False
                '@ﾎﾞﾀﾝの使用許可
                cmdSet.Enabled = False '設定
                cmdDel.Enabled = False '削除
            Else
            
                '@検索文字列を作成[開始]
                lstrSearchString = cmbNo.Text & CMstrHyphen & CMstrStartMark
                '@現工程以前の場合
                If frmxxEN01X2.Instance.pubblnTimeLimitBeforeCur_Chk(lstrSearchString) = True Then
                    '@編集可能
                    'fraLimitTime.Enabled = True
                    '@制限時間以上の場合
                    If OptTimeLimit2.checked = True Then
                        txtWarning.Enabled = False
                    Else
                        txtWarning.Enabled = True
                    End If
                    txtLimit.Enabled = True
                    fraLimitType.Enabled = False
                Else
                    '@編集可能
                    'fraLimitTime.Enabled = True
                    '@制限時間以上の場合
                    If OptTimeLimit2.checked = True Then
                        txtWarning.Enabled = False
                    Else
                        txtWarning.Enabled = True
                    End If
                    txtLimit.Enabled = True
                    fraLimitType.Enabled = True
                End If
            
                '@ﾎﾞﾀﾝの使用許可
                cmdSet.Enabled = False '設定ﾎﾞﾀﾝ
                '@制限時間が入力されている場合
                If txtLimit.Text <> vbNullString Then
                    If txtLimit.Text <> 0 Then
                        cmdSet.Enabled = True '設定ﾎﾞﾀﾝ
                    End If
                End If
                cmdDel.Enabled = True '削除
            
            End If
            
            '@表示内容格納
            Call prvEditString_Set()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbNo_Validate"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：OptTimeLimit_Click
    '機　能：制約ﾀｲﾌﾟｸﾘｯｸ時
    '引　数：Index：ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2006/06/14 (Wed) 10:49:03 N.Kasai
    '更新日：2006/06/14 (Wed) 10:49:03
    '備　考：
    Private Sub OptTimeLimit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OptTimeLimit1.CheckedChanged, OptTimeLimit2.CheckedChanged, OptTimeLimit3.CheckedChanged
        
        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@変更内容格納
            Call prvEditString_Set()
            
            '@「制限時間以上」が選択された場合
            Select Case sender.Name
            
            '@制限時間以下
            Case OptTimeLimit1.Name
                '@警告時間は有効
                txtWarning.Enabled = True
                txtWarning.BackColor = Color.White
            
            '@制限時間以上
            Case OptTimeLimit2.Name
                '@警告時間は無効
                txtWarning.Enabled = False
                txtWarning.BackColor = SystemColors.ControlLight
                '@ﾃﾞﾌｫﾙﾄ表示
                txtWarning.Text = CstrDefaultZero
                
            '@処理時間制限以下
            Case OptTimeLimit3.Name
                '@警告時間は有効
                txtWarning.Enabled = True
                txtWarning.BackColor = Color.White
            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "OptTimeLimit_Click"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWarning_Change
    '機　能：警告時間変更時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:14:36 N.Kasai
    '更新日：2006/07/12 (Wed) 12:14:36
    '備　考：
    Private Sub txtWarning_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWarning.Change

        Try
            
            '@変更内容格納
            Call prvEditString_Set()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtWarning_Change"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLimit_Change
    '機　能：制限時間変更時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:14:51 N.Kasai
    '更新日：2006/07/12 (Wed) 12:14:51
    '備　考：
    Private Sub txtLimit_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLimit.Change

        Try
            
            '@変更内容格納
            Call prvEditString_Set()
            
            '@ｺﾏﾝﾄﾞﾎﾞﾀﾝ制御
            Call prvcmdEnabled_Set()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtLimit_Change"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDel_Click
    '機　能：削除ﾎﾞﾀﾝ押下時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/19 (Mon) 15:10:09 N.Kasai
    '更新日：2006/06/19 (Mon) 15:10:09
    '備　考：
    Private Sub cmdDel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDel.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@時間制限表示ｸﾘｱ
            Call frmxxEN01X2.Instance.pubTimeLimitDisp_Del(cmbNo.Text)
            
            '@時間制限番号を判定
            '@1件のみor制限番号を指定して起動した場合は画面を終了する。
            If fraTimeLimit.Enabled = False Then
                '@画面を閉じる（構造体にｾｯﾄ終了後）
                Me.Close()
                Exit Sub
            Else
                '@ﾌｫｰﾑのｸﾘｱ
                Call prvfrmxxEN01X5_Init()
                
                '@時間制限番号ｺﾝﾎﾞの設定
                Call prvCmbTimeLimitNo_Set()
                
                '@時間制限ｺﾝﾎﾞが1件の場合は初期表示
                If cmbNo.ListCount = 1 Then
                    Call cmbNo_Validate(sender,New CancelEventArgs(True))
                End If
                
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdDel_Click"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSet_Click
    '機　能：変更した情報を設定する
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/16 (Fri) 15:11:06 N.Kasai
    '更新日：2006/06/16 (Fri) 15:11:06
    '備　考：
    Private Sub cmdSet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSet.Click

        Dim llngCnt         As Integer  'ｶｳﾝﾀ
        Dim llngIndex       As Integer  '対象ｲﾝﾃﾞｯｸｽ
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@設定時ﾁｪｯｸ
            If prvErrChkSet_Chk = False Then
                Exit Sub
            End If
            
            '@構造体に値を格納する。
            
            '@格納構造体定義
            With ptypProcTimeLimitInfo
                '@新規ﾃﾞｰﾀの判別
                If pblnEN01X5NewData = True Then
                    If .lngProcTimeLimitCnt = 0 Then
                        .lngProcTimeLimitCnt = 1
                        '@配列の定義
                        'ﾊﾟﾌﾞﾘｯｸ変数配列
                        .typProcTimeLimit = New List(Of ProcTimeLimit)
                        For Cnt = 0 To .lngProcTimeLimitCnt - 1
                            .typProcTimeLimit.Add(New ProcTimeLimit)
                        Next

                    Else
                        '@配列の定義
                        .lngProcTimeLimitCnt = .lngProcTimeLimitCnt + 1
                        'ﾊﾟﾌﾞﾘｯｸ変数配列
                        For Cnt = .typProcTimeLimit.Count To .lngProcTimeLimitCnt - 1
                            .typProcTimeLimit.Add(New ProcTimeLimit)
                        Next
                    End If
                    llngIndex = .lngProcTimeLimitCnt - 1
                    
                    '@新規ﾃﾞｰﾀ確定
                    mblnNewEdit = True
                    
                Else
                    llngIndex = -1
                    For llngCnt = 0 To .lngProcTimeLimitCnt - 1
                        '@ｵｰﾀﾞ番号比較
                        If Format$(CInt(.typProcTimeLimit(llngCnt).strListOrder), CMstrNoFormat) = cmbNo.Text Then
                            '@格納ｲﾝﾃﾞｯｸｽ取得
                            llngIndex = llngCnt
                            Exit For
                        End If
                    Next
                End If
            End With

            Dim typProcTimeLimitTmp As ProcTimeLimit = New ProcTimeLimit
            
            '@構造体に値をｾｯﾄ
            With typProcTimeLimitTmp

                .strListOrder = CLng(cmbNo.Text)
                .strFromOpId = lblFromOpId.Text
                .strFromStepId = lblFromStepId.Text
                .strToOpId = lblToOpId.Text
                .strToStepId = lblToStepId.Text
                
                '@制限時間ﾀｲﾌﾟ
                Select Case True
                    '@制限時間以下
                    Case OptTimeLimit1.Checked
                        .strRestrictTypeID = CMstrRestrict1
                    '@制限時間以上
                    Case OptTimeLimit2.Checked
                        .strRestrictTypeID = CMstrRestrict2
                    '@処理制限以下
                    Case OptTimeLimit3.Checked
                        .strRestrictTypeID = CMstrRestrict3
                End Select
                .strWarnTime = txtWarning.Text      '警告時間
                .strLimitTime = txtLimit.Text       '制限時間
                .blnEnableFlag = True               '有効ﾃﾞｰﾀ
                
                '@時間制限表示設定
                Call frmxxEN01X2.Instance.pubTimeLimitDisp_Set(cmbNo.Text, .strRestrictTypeID)

                ptypProcTimeLimitInfo.typProcTimeLimit(llngIndex) = typProcTimeLimitTmp
            
            End With
            
            '@ﾌﾟﾛｾｽ編集変更ﾌﾗｸﾞｵﾝ
            pblnEN01X2Edit = True
            
            '@画面を閉じる（構造体にｾｯﾄ終了後）
            Me.Close()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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
    '作成日：2006/06/15 (Thu) 14:32:02 N.Kasai
    '更新日：2006/06/15 (Thu) 14:32:02
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        '@画面を閉じる
        Me.Close()

        Exit Sub
        
    Error_Handler:

        '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
        With ptypOnErrorInfo
            .strMenuKey = CMstrLocalMenuKey             '機能ID
            .strProcName = "cmdClose_Click"
            .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
        End With

        '@共通ｴﾗｰ処理
        Call pubOnError_Proc()

    End Sub

    '関数名：prvfrmxxEN01X5_Init
    '機　能：初期処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/05 (Mon) 10:23:44 N.Kasai
    '更新日：2006/06/05 (Mon) 10:23:44
    '備　考：
    Private Sub prvfrmxxEN01X5_Init()

        Try

            '@制約工程の初期化
            lblFromOpId.Text = vbNullString      '元大工程
            lblToOpId.Text = vbNullString        '先大工程
            lblFromStepId.Text = vbNullString    '元小工程
            lblToStepId.Text = vbNullString      '先小工程

            '@制約ﾀｲﾌﾟの初期化
            OptTimeLimit1.Checked = True         '制限時間以下
            
            OptTimeLimit1.Enabled = True        '制限時間以下
            OptTimeLimit2.Enabled = True        '制限時間以上
            OptTimeLimit3.Enabled = True        '処理制限以下
            
            '@制約内容の初期化
            txtWarning.Text = CstrDefaultZero   '警告時間
            txtLimit.Text = CstrDefaultZero     '制限時間

            '@ﾎﾞﾀﾝの使用不可
            cmdSet.Enabled = False '設定
            cmdDel.Enabled = False '削除
            
            '@新規ﾃﾞｰﾀ判定ﾌﾗｸﾞ初期化
            mblnNewEdit = False
            
            '@編集文字格納初期化
            mstrEditString = vbNullString
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxEN01X5_Init"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbTimeLimitNo_Set
    '機　能：時間制限ｺﾝﾎﾞの設定
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/14 (Wed) 12:46:21 N.Kasai
    '更新日：2006/06/14 (Wed) 12:46:21
    '備　考：
    Private Sub prvCmbTimeLimitNo_Set()
        
        Dim llngCount   As Integer  'ｶｳﾝﾀ
        Dim llngCnt     As Integer  'ｶｳﾝﾀ
        Dim lstrTemp    As String   'ｵｰﾀﾞｰ番号退避

        Try
            
            '@時間制限ｺﾝﾎﾞ設定
            With cmbNo
                .Clear  '初期化
                .ColAlignment(0) = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
                
                '@時間制限配列から時間制限番号を取得
                For llngCount = 0 To ptypProcTimeLimitInfo.lngProcTimeLimitCnt - 1
                
                    '@時間制限番号が設定されていたら
                    If ptypProcTimeLimitInfo.typProcTimeLimit(llngCount).blnEnableFlag = True Then
                    
                        '@番号を退避してﾌｫｰﾏｯﾄ変更をかける
                        lstrTemp = Format$(CInt(ptypProcTimeLimitInfo.typProcTimeLimit(llngCount).strListOrder), CMstrNoFormat)
                        
                        '@時間制限を指定して画面を起動した場合
                        If pblnEN00X5SelectOn = True Then
                            
                            '@選択済みの内容のみ表示
                            For llngCnt = 0 To ptypLTSelectList.lngLTSelectListCnt - 1
                            
                                '@選択行に存在する時間制限番号と比較して存在した場合表示
                                If lstrTemp = Format$(CInt(ptypLTSelectList.typLTSelectList(llngCnt).strListOrder), CMstrNoFormat) Then
                                    '@時間制限番号ｺﾝﾎﾞのﾘｽﾄに追加
                                    .AddItem(lstrTemp)
                                    '@ﾙｰﾌﾟ抜け
                                    Exit For
                                End If
                                
                            Next llngCnt
                        Else
                            '@時間制限番号ｺﾝﾎﾞのﾘｽﾄに全件追加
                            .AddItem(lstrTemp)
                        End If
                    End If
                Next
            
                '@時間制限番号ﾛｯｸ
                Select Case .ListCount
                    Case 0
                        '@ｽﾀｰﾄのみ設定の場合
                        '@そんなことするなよ(例外処理）
                        fraTimeLimit.Enabled = False
                        .BackColor = SystemColors.ControlLight
                        
                        '@1件のみ
                        If ptypLTSelectList.lngLTSelectListCnt = 1 Then
                            '@画面表示
                            cmbNo.Text = Format$(CInt(ptypLTSelectList.typLTSelectList(0).strListOrder), CMstrNoFormat)
                            lblFromOpId.Text = ptypLTSelectList.typLTSelectList(0).strFromOpId
                            lblFromStepId.Text = ptypLTSelectList.typLTSelectList(0).strFromStepId
                            
                        End If
                        
                    Case 1
                        '@1件のみ表示
                        fraTimeLimit.Enabled = False
                        .BackColor = SystemColors.ControlLight
                        .ListIndex = 0  '初期表示
                        
                    Case Else
                        '@複数件存在
                        fraTimeLimit.Enabled = True
                        .BackColor = Color.White
                End Select
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvCmbTimeLimitNo_Set"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvErrChkSet_Chk
    '機　能：設定ﾁｪkｯｸ
    '引　数：なし
    '戻り値：True:ｴﾗｰなし　False：ｴﾗｰあり
    '作成日：2006/06/14 (Wed) 12:39:49 N.Kasai
    '更新日：2006/06/14 (Wed) 12:39:49
    '備　考：
    Private Function prvErrChkSet_Chk() As Boolean

        Dim llngCount       As Integer  'ｶｳﾝﾀ
        Dim llngLimitType   As Integer  '制限ﾀｲﾌﾟ
        Dim llngIndex       As Integer  '格納ｲﾝﾃﾞｯｸｽ
        Dim lstrMsgWord     As String   'ﾒｯｾｰｼﾞ格納
        
        Try

            '@初期化
            prvErrChkSet_Chk = False

            '@「制限時間以下」又は「処理制限以下」が選択され、
            If OptTimeLimit1.Checked = True Or OptTimeLimit3.Checked = True Then
                '@警告時間に値が設定されている場合
                If txtWarning.Text <> vbNullString Then
                    If txtWarning.Text <> 0 Then
                        '@警告時間>=制限時間となっている場合
                        If CDec(txtWarning.Text) >= CDec(txtLimit.Text) Then
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001Z)

                            '@"<TRM1ZW>$$制限時間＞警告時間となるように入力してください。"
                            Call publngMsgBox(pstrDMsg & vbCrLf, vbExclamation, _
                                              Me.Text, True, 16, False)
                            '@ﾌｫｰｶｽの移動
                            Call pubSetFocus(txtLimit)
                            Exit Function
                        End If
                    End If
                End If
            End If
            
            
            With ptypProcTimeLimitInfo
            
                llngIndex = -1
                
                For llngCount = 0 To .lngProcTimeLimitCnt - 1
                    '@ｵｰﾀﾞ番号比較
                    If Format$(CInt(.typProcTimeLimit(llngCount).strListOrder), CMstrNoFormat) = cmbNo.Text Then
                        '@格納ｲﾝﾃﾞｯｸｽ取得
                        llngIndex = llngCount
                        Exit For
                    End If
                Next
            
                If .lngProcTimeLimitCnt = 0 Then
                    '@1件の場合はﾁｪｯｸの必要なし
                    '@成功
                    prvErrChkSet_Chk = True
                    Exit Function
                End If
            
            End With
            
            '@制約ﾀｲﾌﾟ判定
            Select Case True
                Case OptTimeLimit1.Checked
                    llngLimitType = 1
                Case OptTimeLimit2.Checked
                    llngLimitType = 2
                Case OptTimeLimit3.Checked
                    llngLimitType = 3
            End Select
            
            '@格納ｲﾝﾃﾞｯｸｽ判定
            If llngIndex = -1 Then
                
                '@新規作成の場合
                For llngCount = 0 To ptypProcTimeLimitInfo.lngProcTimeLimitCnt - 1
                    
                    '@有効ﾃﾞｰﾀのみﾁｪｯｸ
                    If ptypProcTimeLimitInfo.typProcTimeLimit(llngCount).blnEnableFlag = True Then
                    
                        '@違う時間制限配列に同一工程・同一制約ﾀｲﾌﾟの時間制限が設定されているかﾁｪｯｸ
                        If lblFromOpId.Text = ptypProcTimeLimitInfo.typProcTimeLimit(llngCount).strFromOpId And _
                           lblFromStepId.Text = ptypProcTimeLimitInfo.typProcTimeLimit(llngCount).strFromStepId And _
                           lblToOpId.Text = ptypProcTimeLimitInfo.typProcTimeLimit(llngCount).strToOpId And _
                           lblToStepId.Text = ptypProcTimeLimitInfo.typProcTimeLimit(llngCount).strToStepId Then
                           
                            '@制約ﾀｲﾌﾟ判定
                            If llngLimitType = ptypProcTimeLimitInfo.typProcTimeLimit(llngCount).strRestrictTypeID Then
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002A)
                                '@"<TRM2AW>$$同一工程に同じ制約タイプの時間制約が設定されているため、設定できません。"
                                Call publngMsgBox(pstrDMsg & vbCrLf, vbExclamation, Me.Text, True, 16, False)
                                Exit Function
                            Else
                                Select Case llngLimitType
                                    '@以下の場合
                                    Case 1
                                        '@制約時間の判定(以上＜以下)
                                         If CLng(txtLimit.Text) <= CLng(ptypProcTimeLimitInfo.typProcTimeLimit(llngCount).strLimitTime) Then
                                         
                                            lstrMsgWord = CMstrMsgOrver & ptypProcTimeLimitInfo.typProcTimeLimit(llngCount).strLimitTime
                                         
                                            '@表示ﾒｯｾｰｼﾞ変換
                                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008B, lstrMsgWord)
                                            '@"<TRM8BW>$$同一工程に制限時間%1分が設定済みです。$矛盾する時間制限は設定できません。"
                                            Call publngMsgBox(pstrDMsg & vbCrLf, vbExclamation, Me.Text, True, 16, False)
                                            Exit Function
                                         End If
                                    '@以上の場合
                                    Case 2
                                        '@制約時間の判定(以上＜以下)
                                         If CLng(txtLimit.Text) >= CLng(ptypProcTimeLimitInfo.typProcTimeLimit(llngCount).strLimitTime) Then
                                         
                                            lstrMsgWord = CMstrMsgUnder & ptypProcTimeLimitInfo.typProcTimeLimit(llngCount).strLimitTime
                                         
                                            '@表示ﾒｯｾｰｼﾞ変換
                                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008B, lstrMsgWord)
                                            '@"<TRM8BW>$$同一工程に制限時間%1分が設定済みです。$矛盾する時間制限は設定できません。"
                                            Call publngMsgBox(pstrDMsg & vbCrLf, vbExclamation, Me.Text, True, 16, False)
                                            Exit Function
                                         End If
                                End Select
                            End If
                        End If
                    End If
                Next
            Else

                '@時間制限配列を検索
                With ptypProcTimeLimitInfo.typProcTimeLimit(llngIndex)
                    For llngCount = 0 To ptypProcTimeLimitInfo.lngProcTimeLimitCnt - 1

                        '@有効ﾃﾞｰﾀのみﾁｪｯｸ
                        If ptypProcTimeLimitInfo.typProcTimeLimit(llngCount).blnEnableFlag = True Then

                            '@違う時間制限配列に同一工程・同一制約ﾀｲﾌﾟの時間制限が設定されているかﾁｪｯｸ
                            If llngCount <> llngIndex Then
                                If .strFromOpId = ptypProcTimeLimitInfo.typProcTimeLimit(llngCount).strFromOpId And _
                                   .strFromStepId = ptypProcTimeLimitInfo.typProcTimeLimit(llngCount).strFromStepId And _
                                   .strToOpId = ptypProcTimeLimitInfo.typProcTimeLimit(llngCount).strToOpId And _
                                   .strToStepId = ptypProcTimeLimitInfo.typProcTimeLimit(llngCount).strToStepId Then

                                   '@制約ﾀｲﾌﾟ判定
                                   If llngLimitType = ptypProcTimeLimitInfo.typProcTimeLimit(llngCount).strRestrictTypeID Then

                                        '@表示ﾒｯｾｰｼﾞ変換
                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar002A)
                                        '@"<TRM2AW>$$同一工程に同じ制約タイプの時間制約が設定されているため、設定できません。"
                                        Call publngMsgBox(pstrDMsg & vbCrLf, vbExclamation, Me.Text, True, 16, False)
                                        Exit Function
                                    Else

                                        Select Case llngLimitType
                                            '@以下の場合
                                            Case 1
                                                '@制約時間の判定(以上＜以下)
                                                 If CLng(txtLimit.Text) <= CLng(ptypProcTimeLimitInfo.typProcTimeLimit(llngCount).strLimitTime) Then

                                                    lstrMsgWord = CMstrMsgOrver & ptypProcTimeLimitInfo.typProcTimeLimit(llngCount).strLimitTime
                                                    '@表示ﾒｯｾｰｼﾞ変換
                                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008B, lstrMsgWord)
                                                    '@"<TRM8BW>$$同一工程に制限時間%1分が設定済みです。$矛盾する時間制限は設定できません。"
                                                    Call publngMsgBox(pstrDMsg & vbCrLf, vbExclamation, Me.Text, True, 16, False)
                                                    Exit Function
                                                 End If
                                            '@以上の場合
                                            Case 2
                                                '@制約時間の判定(以上＜以下)
                                                 If CLng(txtLimit.Text) >= CLng(ptypProcTimeLimitInfo.typProcTimeLimit(llngCount).strLimitTime) Then

                                                    lstrMsgWord = CMstrMsgUnder & ptypProcTimeLimitInfo.typProcTimeLimit(llngCount).strLimitTime
                                                    '@表示ﾒｯｾｰｼﾞ変換
                                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar008B, lstrMsgWord)
                                                    '@"<TRM8BW>$$同一工程に制限時間%1分が設定済みです。$矛盾する時間制限は設定できません。"
                                                    Call publngMsgBox(pstrDMsg & vbCrLf, vbExclamation, Me.Text, True, 16, False)
                                                    Exit Function
                                                 End If
                                        End Select

                                    End If
                                End If
                            End If
                        End If
                    Next
                End With

            End If

            '@成功
            prvErrChkSet_Chk = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvErrChkSet_Chk"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvCmdEnabled_Set
    '機　能：設定ﾎﾞﾀﾝ使用制限
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/14 (Wed) 10:54:59 N.Kasai
    '更新日：2006/06/14 (Wed) 10:54:59
    '備　考：
    Private Sub prvcmdEnabled_Set()

        Try
            
            cmdSet.Enabled = False '設定ﾎﾞﾀﾝ使用不可
            
            '@番号が未選択の場合
            If cmbNo.Text = vbNullString Then
                Exit Sub
            End If
            
            '@制限時間が未入力の場合
            If txtLimit.Text = vbNullString Then
                Exit Sub
            End If
            
            '@制限時間が0分の場合
            If txtLimit.Text = "0" Then
                Exit Sub
            End If
            
            '@元大工程
            If lblFromOpId.Text = vbNullString Then
                Exit Sub
            End If
            
            '@元小工程
            If lblFromStepId.Text = vbNullString Then
                Exit Sub
            End If
            
            '@先大工程
            If lblToOpId.Text = vbNullString Then
                Exit Sub
            End If
            
            '@先小工程
            If lblToStepId.Text = vbNullString Then
                Exit Sub
            End If
            
            cmdSet.Enabled = True '設定ﾎﾞﾀﾝ使用可

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvCmdEnabled_Set"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：prvEditString_Set
    '機　能：時間制限編集内容格納
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/19 (Mon) 18:10:32 N.Kasai
    '更新日：2006/06/19 (Mon) 18:10:32
    '備　考：
    Private Sub prvEditString_Set()

        Try
            
            '@起動判定
            If mblnFormLoadFlag = False Then
                '@画面起動中は処理しない
                Exit Sub
            End If
            
            
            '@格納変数初期化
            mstrEditString = vbNullString
            
            '@編集内容格納
            
            '@時間制限番号
            mstrEditString = cmbNo.Text
            
            '@制約ﾀｲﾌﾟ
            Select Case True
                Case OptTimeLimit1.Checked
                    mstrEditString = mstrEditString & CMstrRestrict1
                Case OptTimeLimit2.Checked
                    mstrEditString = mstrEditString & CMstrRestrict2
                Case OptTimeLimit3.Checked
                    mstrEditString = mstrEditString & CMstrRestrict3
            End Select
            
            '@警告時間
            mstrEditString = mstrEditString & txtWarning.Text
            '@制限時間
            mstrEditString = mstrEditString & txtLimit.Text

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvEditString_Set"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnEditString_Chk
    '機　能：時間制限変更内容ﾁｪｯｸ
    '引　数：なし
    '戻り値：True:変更なし、Flase：変更あり
    '作成日：2006/06/19 (Mon) 18:18:05 N.Kasai
    '更新日：2006/06/19 (Mon) 18:18:05
    '備　考：
    Private Function prvblnEditString_Chk() As Boolean
        
        Dim lstrEditString  As String   '編集内容格納
        Dim llngIndex       As Integer  '格納ｲﾝﾃﾞｯｸｽ
        Dim llngCnt         As Integer  'ｶｳﾝﾀ
        
        Try
            
            '@初期化
            lstrEditString = vbNullString   '編集内容
            
            prvblnEditString_Chk = False    '戻り値
            
            '@時間制限ｺﾝﾎﾞが未設定の場合はﾁｪｯｸなし
            If cmbNo.Text = vbNullString Then
                prvblnEditString_Chk = True
                Exit Function
            End If

            '@格納変数がNullの場合（初回起動）ﾁｪｯｸなし
            If mstrEditString = vbNullString Then
                prvblnEditString_Chk = True
                Exit Function
            End If
          
            '@ｲﾝﾃﾞｯｸｽ初期化
            llngIndex = -1
            
            '@格納構造体にﾃﾞｰﾀがある場合
            If ptypProcTimeLimitInfo.lngProcTimeLimitCnt > 0 Then
                For llngCnt = 0 To ptypProcTimeLimitInfo.lngProcTimeLimitCnt - 1
                    If Format$(CInt(ptypProcTimeLimitInfo.typProcTimeLimit(llngCnt).strListOrder), CMstrNoFormat) = Format$(CInt(mstrTimeLimitNo), CMstrNoFormat) Then
                        '@対象ｲﾝﾃﾞｯｸｽを退避
                        llngIndex = llngCnt
                    End If
                Next
            End If

            '@対象ﾃﾞｰﾀ存在ﾁｪｯｸ
            If llngIndex = -1 Then
                '@ﾃﾞｰﾀ例外
                Exit Function
            End If
            
            '@構造体より設定内容を取得
            With ptypProcTimeLimitInfo.typProcTimeLimit(llngIndex)
                lstrEditString = Format$(CInt(mstrTimeLimitNo), CMstrNoFormat)    '時間制限番号
                lstrEditString = lstrEditString & ptypProcTimeLimitInfo.typProcTimeLimit(llngIndex).strRestrictTypeID '制約ﾀｲﾌﾟ
                lstrEditString = lstrEditString & ptypProcTimeLimitInfo.typProcTimeLimit(llngIndex).strWarnTime       '警告時間
                lstrEditString = lstrEditString & ptypProcTimeLimitInfo.typProcTimeLimit(llngIndex).strLimitTime      '制限時間
            End With
            
            '@変更内容比較
            If mstrEditString = lstrEditString Then
                '@変更内容一致
                prvblnEditString_Chk = True
            End If

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnEditString_Chk"
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraLimitProcess.Paint, fraTitle0.Paint, fraTitle1.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub

End Class
