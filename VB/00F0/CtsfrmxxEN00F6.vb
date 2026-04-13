'ﾌｧｲﾙ名：xxEN00F6.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：CF在庫リワーク(在庫管理サブフォーム)
'作成日：2004/12/06 (Mon) 16:14:39 S.Deguchi
'更新日：2008/06/24 (Tue) 16:01:19 N.Kojima
'備　考：
'　　　：2005/01/12 (Wed) 08:40:51 S.Deguchi    CF在庫ﾘﾜｰｸ処理保留
'　　　：2005/04/01 (Fri) 15:15:51 S.Deguchi    確定処理で数量入力にｶﾝﾏ編集解除処理を追加
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00F6
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00F6    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00F6
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00F6
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00F6)
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
    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN00F6             'ﾛｰｶﾙ機能ID
                                                                                     
    '@Msgﾊﾞｰｼﾞｮﾝ                                                                     
    Private Const CMstrinv_cflotinfoVer         As String = "01.00"                    'CFﾛｯﾄ情報取得
    Private Const CMstrinv_cfreworkVer          As String = "01.00"                    'CFﾘﾜｰｸ

    '@vsfReworkの定数宣言(ｶﾗﾑ)
    Private Const CMlngColBoardThickness        As Integer = 0                         '板厚
    Private Const CMlngColReworkNum             As Integer = 1                         'ﾘﾜｰｸ数量

    '@vsfReworkの定数宣言(表示幅)
    Private Const CMlngColWBoardThickness       As Integer = 72                       '板厚
    Private Const CMlngColWReworkNum            As Integer = 144                      'ﾘﾜｰｸ数量

    '@vsfReworkの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrColBoardThickness        As String = "板厚"                    '板厚
    Private Const CMstrColReworkNum             As String = "リワーク数量"            'ﾘﾜｰｸ数量

    '@ｸﾞﾘｯﾄﾞの初期値定数宣言
    Private Const CMlngReworkRowTitle           As Integer = 0                         'ﾀｲﾄﾙ
    Private Const CMlngReworkColTitle           As Integer = 0                         'ﾀｲﾄﾙ
    Private Const CMlngGridFixedCols            As Integer = 0                         'ｸﾞﾘｯﾄﾞのFixedCol
    Private Const CMlngGridFixedRows            As Integer = 1                         'ｸﾞﾘｯﾄﾞのFixedRow
    Private Const CMlngReworkCellFontSize       As Integer = 11                        'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngReworkHHeight            As Integer = 20                        'ﾍｯﾀﾞｰの高さ
    Private Const CMlngReworkHeight             As Integer = 24                        '1ｽﾛｯﾄの高さ
    Private Const CMlngInitRows                 As Integer = 1                         '初期表示行(=1)
    Private Const CMlngCalLastRow               As Integer = 10                        '最終行計算用定数(=10)

    '@その他
    Private Const CMstrNum0                     As String = "0"
    Private Const CMstrReworkMaxDefault         As String = "3"                        'ﾘﾜｰｸｶｳﾝﾄ

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    Private mstrLastUpdate                      As String                           '最終更新日時
    Private mstrMaxReworkCount                  As String                           '最大ﾘﾜｰｸ回数
    Private mblnFormLoad                        As Boolean                          '起動ﾌﾗｸﾞ
    Private mstrNowNum                          As String                           '現在数量退避
    Private mtypInvCFLotInfoList                As InvCFLotInfoList                 'CFﾛｯﾄ情報取得構造体
    Private buttonProcessing                    As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                          'NSYS WindowCloseフラグ
    Private mstrOldGridEditorText               As String                           'NSYS グリッドの編集前文字列
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
    '機　能：画面起動
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 18:02:32 S.Deguchi
    '更新日：2004/12/06 (Mon) 18:02:32
    '備　考：
    Private Sub Form_Load()

        Dim lstrFormName            As String           'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lblnAns                 As Boolean          'ﾛｯﾄ保留理由取得戻り値(True/False)
        Dim ltypInvCFLotInfo        As InvCFLotInfo     '要求構造体

        Try

            '@Escﾎﾞﾀﾝを無効
            Me.CancelButton = Nothing

            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "Form_Load"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@画面初期化
            Call prvfrmxxEN00F6_Init()
            
            '@起動ﾌﾗｸﾞの初期化
            mblnFormLoad = False
            
            '@情報要求構造体に情報をｾｯﾄ
            With ltypInvCFLotInfo
                .strCarrierId = ptypHoldConnect.strCarrierId    'ｷｬﾘｱID
                .strMsgVer = CMstrinv_cflotinfoVer              'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strSbID = pstrSBID                             'ｼｽﾃﾑﾌﾞﾛｯｸ
            End With
            
            '@情報取得ﾒｯｾｰｼﾞ
            lblnAns = pubblnInvCFLotInfo_Sel(ltypInvCFLotInfo, _
                                             mtypInvCFLotInfoList)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)

            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
            
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
    '機　能：ﾌｫｰﾑの起動処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/27 (Mon) 16:04:43 S.Deguchi
    '更新日：2004/12/27 (Mon) 16:04:43
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@起動ﾌﾗｸﾞによる処理
            If mblnFormLoad = False Then
                '@初回のみ処理を行う為
                mblnFormLoad = True
            
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
            
                '@画面表示処理
                Call prvfrmxxEN00F6_Disp()
                
                '@成功時ｸﾞﾘｯﾄﾞへ表示
                Call prvvsfRework_Disp(mtypInvCFLotInfoList)
            
                '@ｸﾞﾘｯﾄﾞの状態による処理
                With vsfRework
                    '@ﾀｲﾄﾙ以上存在する
                    If .Rows.Count > 1 Then
                        .Select(CMlngInitRows, CMlngColReworkNum)
                    End If
                End With
            End If
            
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
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 18:02:44 S.Deguchi
    '更新日：2004/12/06 (Mon) 18:02:44
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            Select Case ActiveControl.Name
                Case vsfRework.Name
                    With vsfRework

                        If ActiveControl IsNot vsfRework.Editor THen 

                            '@ｸﾞﾘｯﾄﾞにﾌｫｰｶｽがある場合
                            If .Row = .Rows.Count - 1 And .Col = .Cols.Count - 1 Then
                            '@最終行最終列の場合
                                Select Case e.KeyCode
                                    '@Enterｷｰの場合
                                    Case Keys.Return
                                        '@次項目へｾｯﾄﾌｫｰｶｽ
                                        SendKeys.SendWait(CPstrSendKeysTab)
                                        e.Handled = True
                                    'NSYS Enterｷｰ以外
                                    Case Else
                                        If .Col = CMlngColReworkNum Then
                                            .AllowEditing = True
                                        End If
                                End Select
                            Else
                            '@最終行最終列以外
                                Select Case .Col
                                    Case CMlngColBoardThickness
                                    '@Colが板厚の場合
                                        Select Case e.KeyCode
                                            '@Enterｷｰの場合
                                            Case Keys.Return
                                                '@同行次列へｾｯﾄﾌｫｰｶｽ
                                                .Row = .Row
                                                .Col = CMlngColReworkNum
                                                e.Handled = True
                                                .AllowEditing = False
                                        End Select
                                    
                                    Case CMlngColReworkNum
                                    '@Colがﾘﾜｰｸ数量の場合
                                        Select Case e.KeyCode
                                            '@Enterｷｰの場合
                                            Case Keys.Return
                                                '@次行同列へｾｯﾄﾌｫｰｶｽ
                                                .Row = .Row + 1
                                                .Col = CMlngColReworkNum
                                                e.Handled = True
                                                .AllowEditing = False
                                            'NSYS Enterｷｰ以外
                                            Case Else
                                                .AllowEditing = True
                                        End Select
                                End Select
                            End If
                        End If
                    End With

                Case Else
                '@ｸﾞﾘｯﾄﾞ以外
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            If ActiveControl IsNot vsfRework.Editor THen 
                                '@次項目へｾｯﾄﾌｫｰｶｽ
                                SendKeys.SendWait(CPstrSendKeysTab)
                                e.Handled = True
                            End If
                        Case Keys.Escape
                            If ActiveControl Is vsfRework.Editor THen 
                                vsfRework.HighLight = HighLightEnum.WithFocus
                            End If
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

    '関数名：Form_KeyPress
    '機　能：ｷｰ入力の制限
    '引　数：KeyAscii：ｱｽｷｰｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/12/27 (Mon) 16:04:43 S.Deguchi
    '更新日：2004/12/27 (Mon) 16:04:43
    '備　考：
    Private Sub Form_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles MyBase.KeyPress

        Try

            Select Case Asc(e.KeyChar)
                '@ｶﾝﾏ(44),ﾏｲﾅｽ(45),ﾋﾟﾘｵﾄﾞ(46)の場合
                Case 44, 45, 46
                   e.Handled = True
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_KeyPress"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑ終了前処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/12/27 (Mon) 16:04:43 S.Deguchi
    '更新日：2004/12/27 (Mon) 16:04:43
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try


            '@変数の初期化
            If mtypInvCFLotInfoList.typThicknessList Is Nothing Then
                mtypInvCFLotInfoList.typThicknessList = New List(Of ThicknessList)
            Else
                mtypInvCFLotInfoList.typThicknessList.Clear
            End If
            
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
    '機　能：ﾌﾟﾛｸﾞﾗﾑ終了
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/27 (Mon) 16:04:43 S.Deguchi
    '更新日：2004/12/27 (Mon) 16:04:43
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is cmdClose Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

           
            '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞしてﾌﾟﾛｸﾞﾗﾑ終了
            Me.Close()
                
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

    '関数名：cmdCancel_Click
    '機　能：取消処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/27 (Mon) 15:57:05 S.Deguchi
    '更新日：2004/12/27 (Mon) 15:57:05
    '備　考：
    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCancel.Click
        
        Dim llngCnt     As Integer      '汎用ｶｳﾝﾄ

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｸﾞﾘｯﾄﾞのﾘﾜｰｸ数量をすべてｸﾘｱする
            With vsfRework
                For llngCnt = 1 To .Rows.Count - 1
                    .SetData(llngCnt, CMlngColReworkNum, vbNullString)
                Next llngCnt
            End With
            
            '@現在数量を元の値に設定
            lblNowNum.Text = Format(CInt(mstrNowNum), CPstrDateFormatKanma)
            
            '@取消ﾎﾞﾀﾝ非活性化
            cmdCancel.Enabled = False
            
            '@確定ﾎﾞﾀﾝ非活性化
            cmdRegist.Enabled = False
            
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

    '関数名：cmdRegist_Click
    '機　能：確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 18:06:33 S.Deguchi
    '更新日：2004/12/06 (Mon) 18:06:33
    '備　考：
    '　　　：2005/01/11 (Tue) 15:55:11 S.Deguchi    完了ﾒｯｾｰｼﾞ表示
    '　　　：2005/04/01 (Fri) 15:15:51 S.Deguchi    確定処理で数量入力にｶﾝﾏ編集解除処理を追加
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean          '登録戻り値(True/False)
        Dim llngCnt                 As Integer          'ｶｳﾝﾄ
        Dim lstrFormName            As String           'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypInvRework           As InvRework        '要求構造体
        Dim lstrTemp                As String           '汎用変数

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
                
            '@画面項目ﾁｪｯｸ
            lblnAns = prvblnInput_Chk
            If lblnAns = False Then
                '@不正項目あり
                Exit Sub
            End If

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
            If pstrUserID = vbNullString Then
                '@未入力の場合、投入中止
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "cmdRegist_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@送信ﾒｯｾｰｼﾞを構造体にｾｯﾄする
            With ltypInvRework
                .strSbID = pstrSBID                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strMsgVer = CMstrinv_cfreworkVer       'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strLotID = lblLotID.Text            'ﾛｯﾄID
                .strEmpID = pstrUserID                  '作業者ID
                
                '@板厚＆ﾘﾜｰｸ数量をｾｯﾄする
                For llngCnt = 1 To vsfRework.Rows.Count - 1
                    '@変数置換
                    lstrTemp = vsfRework.GetData(llngCnt, CMlngColReworkNum)
                    '@ﾘﾜｰｸ数量が設定されている場合のみ領域にｾｯﾄする
                    If lstrTemp = vbNullString Or lstrTemp = CMstrNum0 Then
                        .lngThicknessCnt = .lngThicknessCnt                                 'ｶｳﾝﾄ
                    Else
                        .lngThicknessCnt = .lngThicknessCnt + 1                             'ｶｳﾝﾄ
                        '@領域確保
                        Dim typCFReowrkThicknessTmp As New CFThicknessList

                        If .typCFReowrkThickness Is Nothing Then
                            .typCFReowrkThickness = New List(Of CFThicknessList)
                        End If
                        
                        typCFReowrkThicknessTmp.strThicknessCode = _
                            vsfRework.GetData(llngCnt, CMlngColBoardThickness)     '板厚ｺｰﾄﾞ
                            
                        typCFReowrkThicknessTmp.strChipNum = _
                            Format$(CInt(vsfRework.GetData(llngCnt, CMlngColReworkNum)), CPstrNoKanmaFormat)          'ﾘﾜｰｸ回数

                        .typCFReowrkThickness.Add(typCFReowrkThicknessTmp)

                    End If
                Next llngCnt
            End With
            
            '@送信ﾒｯｾｰｼﾞを送る
            lblnAns = pubblnInvCFRework_Upd(ltypInvRework)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@異常の場合終了
                Exit Sub
            End If
            
            '@完了ﾒｯｾｰｼﾞを表示
            If lblNowNum.Text = CMstrNum0 Then
            '@全数払出の場合
                '@ﾒｯｾｰｼﾞ表示"<TRM3SI>$$在庫リワークを行い、ロット終了しました。キャリア[%1] ロット[%2]"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003Z, lblCarrier.Text, lblLotID.Text)
                
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
            Else
            '@全数以外の場合
                '@ﾒｯｾｰｼﾞ表示"<TRM70I>$$在庫リワークを行いました。キャリア[%1] ロット[%2]"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003Y, lblCarrier.Text, lblLotID.Text)
                
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            '@ｻﾌﾞ画面を閉じる
            Call cmdClose_Click(cmdClose,New EventArgs)

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

    '関数名：vsfRework_AfterEdit
    '機　能：編集後処理
    '引　数：Row：行
    '　　　：Col：列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/12/27 (Mon) 15:30:34 S.Deguchi
    '更新日：2004/12/27 (Mon) 15:30:34
    '備　考：
    Private Sub vsfRework_AfterEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfRework.AfterEdit

        Dim lblnAns         As Boolean      '汎用結果判定

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfRework.Rows.Count <= vsfRework.Rows.Fixed Then
                Return
            End If

            '@数量計算処理へ
            Call prvvsfRework_Cal()
            
            '@確定ﾎﾞﾀﾝﾁｪｯｸ処理へ
            lblnAns = prvblnInput_Chk
            '@結果判定
            If lblnAns = True Then
                '@確定ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
                
                '@取消ﾎﾞﾀﾝ活性化
                cmdCancel.Enabled = True
            Else
                '@確定ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False
                
                '@取消ﾎﾞﾀﾝ非活性化
                cmdCancel.Enabled = False
            End If

            '@選択行のﾊｲﾗｲﾄ表示
            vsfRework.HighLight = HighLightEnum.WithFocus
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRework_AfterEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRework_BeforeEdit
    '機　能：編集前処理
    '引　数：Row：行
    '　　　：Col：列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/12/07 (Tue) 17:34:28 S.Deguchi
    '更新日：2004/12/07 (Tue) 17:34:28
    '備　考：
    Private Sub vsfRework_BeforeEdit(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfRework.SetupEditor

        Dim llngLength  As Integer  'ﾁｪｯｸ用変数
        Dim llngNowNum  As Integer  '現在数量退避領域

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfRework.Rows.Count <= vsfRework.Rows.Fixed Then
                Return
            End If

            With vsfRework
                '@ﾀｲﾄﾙの場合はｽｷｯﾌﾟ
                If e.Row < .Rows.Fixed Then
                    e.Cancel = True
                    Exit Sub
                End If
                
                '@情報を設定
                llngNowNum = CLng(lblNowNum.Text)
                llngLength = Len(llngNowNum)
                
                '@編集項目以外はｽｷｯﾌﾟ
                Select Case e.Col
                    Case CMlngColBoardThickness
                    '@板厚の場合
                        e.Cancel = True
                        
                        Exit Sub
                    
                    Case CMlngColReworkNum
                    '@ﾘﾜｰｸ数量の場合(入力Len設定)
                        CType(.Editor, Textbox).MaxLength = llngLength
                        cmdClose.CausesValidation = True
                End Select

                mstrOldGridEditorText = .GetData(e.Row, e.Col)

                '@選択行のﾊｲﾗｲﾄ表示
                .HighLight = HighLightEnum.Never

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRework_BeforeEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRework_BeforeRowColChange
    '機　能：ﾘﾜｰｸ行変更処理
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/05/07 (Sat) 09:20:47 S.Deguchi
    '更新日：2005/05/07 (Sat) 09:20:47
    '備　考：
    Private Sub vsfRework_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfRework.BeforeRowColChange

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfRework.Rows.Count <= vsfRework.Rows.Fixed Then
                Return
            End If

            '@ｸﾞﾘｯﾄ編集処理
            If e.NewRange.r1 <> 0 Then
                If e.NewRange.c1 = CMlngColReworkNum Then
                    vsfRework.AllowEditing = True
                Else
                    vsfRework.AllowEditing = False
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRework_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRework_Click
    '機　能：ﾘﾜｰｸｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 18:04:17 S.Deguchi
    '更新日：2004/12/06 (Mon) 18:04:17
    '備　考：
    Private Sub vsfRework_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfRework.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfRework.Rows.Count <= vsfRework.Rows.Fixed Then
                Return
            End If

            '@ｸﾞﾘｯﾄ編集処理
            Call prvvsfRework_Edit()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRework_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRework_EnterCell
    '機　能：ﾘﾜｰｸEnter処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/07 (Tue) 17:32:25 S.Deguchi
    '更新日：2004/12/07 (Tue) 17:32:25
    '備　考：
    Private Sub vsfRework_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfRework.EnterCell

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfRework.Rows.Count <= vsfRework.Rows.Fixed Then
                Return
            End If
            
            '@ｸﾞﾘｯﾄ編集処理
            Call prvvsfRework_Edit()

            '@ｽｸﾛｰﾙ機能(Enter処理:自作)
            With vsfRework
                '@列がﾘﾜｰｸ数量の場合
                If .Col = CMlngColReworkNum Then
                    '@行がﾀｲﾄﾙ以外
                    If .Row >= 1 Then
                        '@行が最終行の場合
                        If .TopRow + CMlngCalLastRow = .Row Then
                            '@ﾄｯﾌﾟﾛｳを1つ下げる
                            .TopRow = .TopRow + 1
                        End If
                    End If
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRework_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRework_KeyDown
    '機　能：ｷｰﾀﾞｳﾝｲﾍﾞﾝﾄ
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2005/05/11 (Wed) 10:43:33 S.Deguchi
    '更新日：2005/05/11 (Wed) 10:43:33
    '備　考：
    Private Sub vsfRework_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles vsfRework.KeyDown

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfRework.Rows.Count <= vsfRework.Rows.Fixed Then
                Return
            End If

            With vsfRework
                Select Case e.KeyCode
                    '@Delete/BackSpaceｷｰの場合
                    Case Keys.Delete, Keys.Back
                        '@Nullにする
                        .SetData(.Row, .Col, vbNullString)
                        
                        '@編集処理
                        .AllowEditing = True
                End Select

            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRework_KeyDown"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfRework_ValidateEdit
    '機　能：ｸﾞﾘｯﾄの変更処理
    '引　数：Row：変更行
    '　　　：Col：変更列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/12/27 (Mon) 15:19:19 S.Deguchi
    '更新日：2004/12/27 (Mon) 15:19:19
    '備　考：
    Private Sub vsfRework_ValidateEdit(ByVal sender As Object, ByVal e As ValidateEditEventArgs) Handles vsfRework.ValidateEdit

        Dim llngCnt         As Integer  'ｶｳﾝﾀ
        Dim llngToTal       As Integer  '合計値

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfRework.Rows.Count <= vsfRework.Rows.Fixed Then
                Return
            End If
            
            '@固定行の場合はｽｷｯﾌﾟ
            If e.Row < vsfRework.Rows.Fixed Then
                Exit Sub
            End If
            
            '@入力ﾁｪｯｸ
            With vsfRework
                '@数値か否かのﾁｪｯｸ
                If IsNumeric(.Editor.Text) = True Then
                    '@Long型へ変換
                    If CLng(.Editor.Text) >= 0 Then
                        '@ﾘﾜｰｸ数量の計算
                        llngToTal = 0               '初期化
                        
                        For llngCnt = 1 To .Rows.Count - 1
                            '@ｸﾞﾘｯﾄﾞに表示されている情報から合計数量を計算する
                            If llngCnt = e.Row Then
                                '@合計数量の加算
                                llngToTal = llngToTal + CLng(.Editor.Text)
                            Else
                                If IsNumeric(.GetData(llngCnt, CMlngColReworkNum)) = True Then
                                    '@合計数量の加算
                                    llngToTal = llngToTal + CLng(.GetData(llngCnt, CMlngColReworkNum))
                                End If
                            End If
                        Next llngCnt
                    
                        '@計算結果と現在数量を比較する
                        If llngToTal > CLng(mstrNowNum) Then
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0062)
                            '@"数量には現在数量より小さい値を入力してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                            '@入力した情報を反映させない
                            e.Cancel = True
                            Dim tb As TextBox = .Editor
                            tb.Text = .GetData(e.Row, e.Col)
                            tb.SelectAll()
                        Else
                            '@入力した情報を反映させる
                            e.Cancel = False
                        End If
                    Else
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0063)
                        '@"数量が入力されていません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@入力した情報を反映させない
                        e.Cancel = True
                        Dim tb As TextBox = .Editor
                        tb.Text = .GetData(e.Row, e.Col)
                        tb.SelectAll()
                        Exit Sub
                    End If
                Else
                    '@入力欄が空欄以外の場合
                    If Trim(.Editor.Text) <> vbNullString Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0063)
                        '@"数量が入力されていません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@入力した情報を反映させない
                        e.Cancel = True
                        Dim tb As TextBox = .Editor
                        tb.Text = .GetData(e.Row, e.Col)
                        tb.SelectAll()
                        Exit Sub
                    End If
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRework_ValidateEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '関数名：prvfrmxxEN00F6_Init
    '機　能：ﾒｲﾝﾌｫｰﾑ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 18:08:16 S.Deguchi
    '更新日：2004/12/06 (Mon) 18:08:16
    '備　考：
    Private Sub prvfrmxxEN00F6_Init()

        Try
            
            '@内部変数の初期化
            mstrMaxReworkCount = vbNullString
            mstrNowNum = vbNullString

            '@ﾗﾍﾞﾙの初期化
            lblCarrier.Text = vbNullString               'ｷｬﾘｱID
            lblLotID.Text = vbNullString                 'ﾛｯﾄID
            lblFlowClass.Text = vbNullString             '流動区分
            lblNowNum.Text = vbNullString                '現在数量
            lblReworkCount.Text = vbNullString           'ﾘﾜｰｸ数量
            
            '@ﾎﾞﾀﾝの初期化
            cmdRegist.Enabled = False                       '確定
            cmdCancel.Enabled = False                       '取消
            
            '@ﾘﾜｰｸ数入力ｸﾞﾘｯﾄﾞの初期化
            Call prvvsfRework_Init()
            
            '@終了時にValidateｲﾍﾞﾝﾄを実行しない
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN00F6_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN00F6_Disp
    '機　能：引継ぎ情報表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 18:08:16 S.Deguchi
    '更新日：2004/12/06 (Mon) 18:08:16
    '備　考：
    Private Sub prvfrmxxEN00F6_Disp()

        Try

            '@引継ぎ情報の表示
            With ptypHoldConnect
                lblCarrier.Text = .strCarrierId                                             'ｷｬﾘｱID
                lblLotID.Text = .strLotID                                                   'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass                                           '流動区分
                lblNowNum.Text = Format(CInt(.strChipQuantity), CPstrDateFormatKanma)       'ﾁｯﾌﾟ数量
            
                mstrLastUpdate = .strLastUpdate                                             '最終更新日時
                mstrNowNum = .strChipQuantity                                               'ﾁｯﾌﾟ数量(現在数量)
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN00F6_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfRework_init
    '機　能：ｸﾞﾘｯﾄﾞの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 18:08:16 S.Deguchi
    '更新日：2004/12/06 (Mon) 18:08:16
    '備　考：
    Private Sub prvvsfRework_Init()

        Dim llngCnt As Integer  'ｶｳﾝﾄ

        Try
            
            With vsfRework
                '@ｸﾘｱ
                .Clear(ClearFlags.Content)
                
                '@初期行数設定
                .Rows.Count = CMlngInitRows
                
                .SelectionMode = SelectionModeEnum.Row
                
                '@ﾌｫｰｶｽのあり方
                .FocusRect = FocusRectEnum.Light
                
                '@選択行のﾊｲﾗｲﾄ表示
                .HighLight = HighLightEnum.WithFocus
                
                '@一覧表の表題設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.ForeColor = Color.Yellow                   '文字色
                lFixedStyle.BackColor = Color.Navy                     '背景色
                With .Font                                             'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                    lFixedStyle.Font = New Font(.FontFamily, CMlngReworkCellFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngReworkRowTitle, CMlngColBoardThickness, CMstrColBoardThickness)         '板厚
                .SetData(CMlngReworkRowTitle, CMlngColReworkNum, CMstrColReworkNum)                   'ﾘﾜｰｸ数量
            
                '@表示位置の設定
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter
                
                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngReworkRowTitle).Height = CMlngReworkHHeight                                            '高さ
                
                '@残りの行設定
                For llngCnt = 1 To CMlngInitRows - 1
                    .Rows(llngCnt).Height = CMlngReworkHeight                                                     '高さ
                Next llngCnt
                        
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfRework_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfRework_Disp
    '機　能：板厚/ﾘﾜｰｸの表示
    '引　数：ltypInvCFLotInfoList：板厚情報格納構造体
    '戻り値：なし
    '作成日：2004/12/27 (Mon) 13:55:38 S.Deguchi
    '更新日：2004/12/27 (Mon) 13:55:38
    '備　考：
    Private Sub prvvsfRework_Disp(ByRef ltypInvCFLotInfoList As InvCFLotInfoList)
        
        Dim llngDoCnt       As Integer  '汎用ｶｳﾝﾄ

        Try
            
            With vsfRework
                If ltypInvCFLotInfoList.lngThicknessCnt <> 0 Then
                '@格納ﾃﾞｰﾀがあるの場合
                
                    '@最大ﾘﾜｰｸ回数を内部変数へ格納
                    If ltypInvCFLotInfoList.strRegenerationCount = vbNullString Then
                        '@Max初期値設定
                        mstrMaxReworkCount = CMstrReworkMaxDefault
                    Else
                        '@取得値を設定
                        mstrMaxReworkCount = ltypInvCFLotInfoList.strRegenerationCount
                    End If
                    
                    '@ﾘﾜｰｸ回数をﾗﾍﾞﾙにｾｯﾄ
                    lblReworkCount.Text = Format(CInt(ltypInvCFLotInfoList.strReworkCount), CPstrDateFormatKanma)
                    
                    '@描画ﾛｯｸ
                    .Redraw = False
                    
                    '@行数設定
                    .Rows.Count = ltypInvCFLotInfoList.lngThicknessCnt + 1
                    
                    '@ｶｳﾝﾀの初期化
                    llngDoCnt = 0
                    
                    '@ﾛｯﾄ一覧表示情報設定
                    Do While .Rows.Count -1 > llngDoCnt
                        .SetData(llngDoCnt +1, CMlngColBoardThickness, _
                            ltypInvCFLotInfoList.typThicknessList(llngDoCnt).strThicknessCode)       '板厚
                        
                        '@ｶｳﾝﾄのｶｳﾝﾄｱｯﾌﾟ
                        llngDoCnt = llngDoCnt + 1
                    Loop
                    
                    '@書式設定
                    .Cols(CMlngColBoardThickness).TextAlign = TextAlignEnum.LeftCenter                     '表示(左寄せ中央揃え)
                    .Cols(CMlngColReworkNum).TextAlign = TextAlignEnum.RightCenter                         '表示(右寄せ中央揃え)
                    
                    '@再描画
                    .Redraw = True
                    
                    '@ﾛｯｸ解除
                    .Enabled = True
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfRework_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfRework_Edit
    '機　能：ｸﾞﾘｯﾄﾞ編集を許可する制御
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 18:08:56 S.Deguchi
    '更新日：2004/12/06 (Mon) 18:08:56
    '備　考：
    Private Sub prvvsfRework_Edit()

        Try

            With vsfRework
                '@固定行の場合はｽｷｯﾌﾟ
                If .Row < .Rows.Fixed Then
                    Exit Sub
                End If
            
                '@編集ﾓｰﾄﾞの設定
                Select Case .Col
                    '@ﾘﾜｰｸ数量の場合
                    Case CMlngColReworkNum
                        '@編集を許可
                        .AllowEditing = True
                        
                    Case Else
                        '@編集を非許可
                        .AllowEditing = False
                End Select
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfRework_Edit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnInput_Chk
    '機　能：確定ﾎﾞﾀﾝﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 18:10:12 S.Deguchi
    '更新日：2004/12/06 (Mon) 18:10:12
    '備　考：
    Private Function prvblnInput_Chk() As Boolean

        Dim llngCnt         As Integer  '汎用ｶｳﾝﾀ
        Dim lstrTemp        As String   '汎用格納変数
        Dim llngToTal       As Integer  '合計値

        Try
            
            '@初期化
            prvblnInput_Chk = False
            
            '@ﾘﾜｰｸ回数が最大ﾘﾜｰｸ回数以上の場合
            If CLng(lblReworkCount.Text) >= CLng(mstrMaxReworkCount) Then
                Exit Function
            End If
            
            '@板厚に対するﾘﾜｰｸ数量の合計が"0"orNull以外の場合にはOK
            llngToTal = 0
            With vsfRework
                For llngCnt = 1 To .Rows.Count - 1
                    '変数置換
                    lstrTemp = .GetData(llngCnt, CMlngColReworkNum)
                    
                    '@ﾘﾜｰｸ数量がNull or "0" の場合
                    If lstrTemp = vbNullString Or lstrTemp = CMstrNum0 Then
                        '@数量そのまま
                        llngToTal = llngToTal
                    Else
                    '@それ以外
                        '@合計計算する
                        llngToTal = llngToTal + CLng(lstrTemp)
                    End If
                Next llngCnt
            End With
            '@最終判定
            If llngToTal = 0 Then
                Exit Function
            End If
            
            '@成功を返す
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

    '関数名：prvvsfRework_Cal
    '機　能：数量計算処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/01/08 (Sat) 16:30:23 S.Deguchi
    '更新日：2005/01/08 (Sat) 16:30:23
    '備　考：
    Private Sub prvvsfRework_Cal()

        Dim llngCnt         As Integer  'ｶｳﾝﾀ
        Dim llngToTal       As Integer  '合計値
        Dim llngNowNum      As Integer  '現在数量

        Try
            
            '@入力計算
            With vsfRework
                llngToTal = 0               '初期化
                        
                For llngCnt = 1 To .Rows.Count - 1
                    '@ｸﾞﾘｯﾄﾞに表示されている情報から合計数量を計算する
                    If .GetData(llngCnt, CMlngColReworkNum) = vbNullString Then
                        '@合計数量そのまま
                        llngToTal = llngToTal
                    Else
                        '@合計数量の加算
                        llngToTal = llngToTal + CLng(.GetData(llngCnt, CMlngColReworkNum))
                    End If
                Next llngCnt
                    
                '@現在数量から計算結果を減算する
                llngNowNum = CLng(mstrNowNum) - llngToTal
                
                '@現在数量を表示する
                lblNowNum.Text = Format(llngNowNum, CPstrDateFormatKanma)
            
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfRework_Cal"
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraFrame.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfRework.BeforeDoubleClick

        ' ObjectをGridに変換
        Dim gridObj As C1FlexGrid
        gridObj = CType(sender, C1FlexGrid)

        'ダブルクリックした箇所が列の境界線かを判断する
        If gridObj.HitTest(e.X,e.Y).Type = HitTestTypeEnum.ColumnResize Then

            '列の境界線の場合、本来の処理をキャンセル
            e.Cancel = True

        End If

    End Sub


    '関数名：flexGrid_KeyDownEdit
    '機　能：←→キーの取り扱い
    '引　数：sender ：イベント元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/01/28 (Mon) 10:00:00 NSYS
    '更新日：2019/04/05 (Fri) 12:00:00 NSYS
    Private Sub flexGrid_KeyDownEdit(ByVal sender As Object, ByVal e As KeyEditEventArgs) Handles vsfRework.KeyDownEdit

        With CType(sender, C1FlexGrid)
            '@'ｶﾚﾝﾄｾﾙがﾍｯﾀﾞｰ行でない場合
            If e.Row >= .Rows.Fixed Then
                Select Case e.KeyCode
                    Case Keys.Left  '[←]ｷｰ押下
                        Dim editor As Object = CType(.Editor, Object)
                        ' 編集不可のコンボボックスの場合
                        ' または、
                        ' テキストボックスまたは編集可のコンボボックスで、かつ、カーソルが先頭の場合は、
                        '   左隣へ
                        If (TypeOf editor Is ComboBox AndAlso _
                                    CType(editor, ComboBox).DropDownStyle = ComboBoxStyle.DropDownList) _
                            OrElse _
                            ((TypeOf editor Is TextBox OrElse TypeOf editor Is ComboBox) AndAlso _
                                (editor.SelectionStart = 0 AndAlso editor.SelectionLength = 0)) Then
                            If .FinishEditing() = True Then
                                ' 左側で固定行直前まで移動可能なセルを探す
                                For lintCnt As Integer = .Col - 1 To .Cols.Fixed Step -1
                                    If .Cols(lintCnt).Visible Then
                                        .Col = lintCnt
                                        Exit For
                                    End If
                                Next lintCnt
                            End If
                            e.Handled = True
                        End If
                    Case Keys.Right '[→]ｷｰ押下
                        Dim editor As Object = CType(.Editor, Object)
                        ' 編集不可のコンボボックスの場合
                        ' または、
                        ' テキストボックスまたは編集可のコンボボックスで、かつ、カーソルが末尾の場合は、
                        '   右隣へ
                        If (TypeOf editor Is ComboBox AndAlso _
                                CType(editor, ComboBox).DropDownStyle = ComboBoxStyle.DropDownList) _
                            OrElse _
                            ((TypeOf editor Is TextBox OrElse TypeOf editor Is ComboBox) AndAlso _
                                (editor.SelectionStart = editor.Text.Length)) Then
                            If .FinishEditing() = True Then
                                ' 右側でグリッドの最後まで移動可能なセルを探す
                                For lintCnt As Integer = .Col + 1 To .Cols.Count - 1 Step 1
                                    If .Cols(lintCnt).Visible Then
                                        .Col = lintCnt
                                        Exit For
                                    End If
                                Next lintCnt
                            End If
                            e.Handled = True
                        End If
                End Select
            End If
        End With

    End Sub

    '関数名：vsfRework_ChangeEdit
    '機　能：ﾊﾟﾗﾒｰﾀﾘｽﾄ 編集変更時
    '引　数：sender ：イベント発生元
    '　　　：e      ：イベントオブジェクト
    '戻り値：なし
    '作成日：2019/03/08 (Fri) 12:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub vsfRework_ChangeEdit(ByVal sender As Object, ByVal e As EventArgs) Handles vsfRework.ChangeEdit
        Try

            With vsfRework
            
                'テキスト長を文字数でなくバイト数で切り詰める
                '内部で .Editor.Text への代入処理があるので、イベント再帰を回避する
                RemoveHandler vsfRework.ChangeEdit, AddressOf vsfRework_ChangeEdit
                pubTextBoxLimit_Set(CType(.Editor, TextBox), mstrOldGridEditorText)
                AddHandler vsfRework.ChangeEdit, AddressOf vsfRework_ChangeEdit

                '@編集前文字列の設定
                mstrOldGridEditorText = vsfRework.Editor.Text
                    
            End With

           Exit Sub
        Catch ex As Exception
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfRework_ChangeEdit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        End Try
    End Sub
        
End Class
