'ﾌｧｲﾙ名：xxCM00H1.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：対象ﾛｯﾄ処置 ﾒｲﾝﾌｫｰﾑ
'作成日：2005/08/10 (Wed) 16:00:56 S.Deguchi
'更新日：2005/08/10 (Wed) 16:00:56
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00H1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00H1    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00H1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00H1
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00H1)
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
    Private Const CMstrLocalMenuKey             As String = CPstrKeyCM00H1              'ﾛｰｶﾙ機能ID

    '@ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
    Private Const CMstrexcplotcheckVer          As String = "01.00"                     'ﾛｯﾄ情報ﾁｪｯｸ

    '@定数宣言
    Private Const CMstrWkNo                         As String = "0"                     '未処置
    Private Const CMstrWk                           As String = "1"                     '処置済
    Private Const CMstrWkNoJ                        As String = "未処置"                '未処置
    Private Const CMstrWkJ                          As String = "処置済"                '処置済
    Private Const CMlngIndex0                       As Integer = 0                      'Index=0
    Private Const CMlngIndex1                       As Integer = 1                      'Index=1
    Private Const CMlngIndex2                       As Integer = 2                      'Index=2
    Private Const CMlngIndex3                       As Integer = 3                      'Index=3
    Private Const CMlngIndex4                       As Integer = 4                      'Index=4
    Private Const CMlngIndex5                       As Integer = 5                      'Index=5
    Private Const CMlngIndex6                       As Integer = 6                      'Index=6
    Private Const cmlngMaxByte10                    As Integer = 10                     'ﾛｯﾄIDMaxByte=10
    Private Const CMstrCFFlag_WF                    As String = "0"                     'CFﾌﾗｸﾞ：WF(0)
    Private Const CMstrCFFlag_CF                    As String = "1"                     'CFﾌﾗｸﾞ：CF(1)
    Private Const CMstrIncongFlag0                  As String = "0"                     '不適合品発生有無：無
    Private Const CMstrIncongFlag1                  As String = "1"                     '不適合品発生有無：有

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    '@ﾛｯﾄﾘｽﾄ構造体
    Private Structure LocalLotList
        Dim strLotID                                As String                           'ﾛｯﾄID
        Dim strCFLotFlag                            As String                           'CFﾛｯﾄﾌﾗｸﾞ(0:CFﾛｯﾄ以外 1:CFﾛｯﾄ)
        Dim strWFQuantity                           As String                           'WF枚数
        Dim strChipQuantity                         As String                           'ﾁｯﾌﾟ数
        Dim strPdId                                 As String                           '機種
        Dim strOpID                                 As String                           '大工程
        Dim strStepID                               As String                           '小工程
        Dim strWpID                                 As String                           '装置ID
        Dim strWpName                               As String                           '装置名
        Dim strDispose                              As String                           '処置状態
    End Structure
    Private mtypLotList                         As LocalLotList                         '比較基準ﾛｯﾄ格納構造体

    Private mstrLotId                           As String                               'ﾛｯﾄID退避領域
    Private mstrLastUpdate                      As String                               '最終更新日時
    Private mstrHoldFlag                        As String                               '保留ﾌﾗｸﾞ
    Private mblnEditFlag                        As Boolean                              '編集ﾌﾗｸﾞ
    Private buttonProcessing                    As Boolean                              'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                              'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                              'NSYS WindowCloseフラグ

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
    '機　能：起動処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/10 (Wed) 16:02:23 S.Deguchi
    '更新日：2005/08/10 (Wed) 16:02:23
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns                 As Boolean              '結果判定
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim ltypLotList             As LocalLotList         'ﾛｯﾄ情報格納構造体

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrEventName = "Form_Load"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, lstrEventName)

            '@画面情報の初期化
            Call prvfrmxxCM00H1_Init()
            
            '@引継情報が存在する場合
            If ptypExcpReport.lngExcpReportLotListCnt > 0 Then
                '@ﾛｯﾄが存在する場合,比較対象ﾛｯﾄ情報を取得する
                If pstrLotID <> vbNullString Then
                    With ltypLotList
                        .strLotID = pstrLotID
                    End With
                Else
                    With ltypLotList
                        .strLotID = ptypExcpReport.typExcpLotList(0).strLotID
                    End With
                End If
                
                '@ﾛｯﾄの状態ﾁｪｯｸ
                lblnAns = prvblnExcpLotCheck_Sel(ltypLotList)
                '@結果判定
                If lblnAns = False Then
                    '@失敗した場合には処理抜け
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(Me.Name, lstrEventName)
                    
                    pblnfrmxxCM00H1Kbn = False
                    
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = Me.cmdClose
                    
                    Exit Sub
                Else
                    '@比較対象構造体へｾｯﾄ
                    mtypLotList = ltypLotList
                End If
            End If
            
            '@引継情報の設定
            Call prvfrmxxCM00H1_Disp()
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)
            
            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = Me.cmdClose
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "Form_Load"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_KeyDown
    '機　能：ｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ値
    '戻り値：なし
    '作成日：2005/08/10 (Wed) 16:03:03 S.Deguchi
    '更新日：2005/08/10 (Wed) 16:03:03
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

            '@Enterｷｰで次ﾌｫｰｶｽｾｯﾄ
            Select Case ActiveControl.Name
                Case txtLotID.Name
                '@ﾛｯﾄID欄
                    Select Case e.KeyCode
                        '@Enterの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler txtLotID.Validating,AddressOf txtLotID_Validate
                            Call txtLotID_Validate(sender,New CancelEventArgs(False))
                            AddHandler txtLotID.Validating,AddressOf txtLotID_Validate
                            
                    End Select
                
                Case txtTotalNum.Name
                '@現在数量
                    Select Case e.KeyCode
                        '@Enterの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler txtTotalNum.Validating,AddressOf txtTotalNum_Validate
                            Call txtTotalNum_Validate(sender,New CancelEventArgs(False))
                            AddHandler txtTotalNum.Validating,AddressOf txtTotalNum_Validate

                    End Select
                
                Case Else
                '@その他
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                    End Select
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：ﾌｫｰﾑｱﾝﾛｰﾄﾞ機能
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2005/08/10 (Wed) 16:03:06 S.Deguchi
    '更新日：2005/08/10 (Wed) 16:03:06
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Try
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender,e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If
            
            '@ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄとの関連付けを解除
            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：閉じるﾎﾞﾀﾝ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/10 (Wed) 16:03:36 S.Deguchi
    '更新日：2005/08/10 (Wed) 16:03:36
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

            '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞ
            Me.Close()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClose_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdSave_Click
    '機　能：処置確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/10 (Wed) 17:18:41 S.Deguchi
    '更新日：2005/08/10 (Wed) 17:18:41
    '備　考：
    Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSave.Click

        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance        As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg
        Dim lblnFlag                As Boolean              '処置ﾌﾗｸﾞ
        Dim lblnEnableFlag          As Boolean              '存在ﾌﾗｸﾞ
        Dim llngTargetNum           As Integer              '対象数量

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
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrEventName = "cmdSave_Click"
            
            '@存在ﾌﾗｸﾞを初期化
            lblnEnableFlag = False
            
            '@確定ﾁｪｯｸ
            lblnAns = prvblncmdRegist_Chk()
            '@結果判定
            If lblnAns = False Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, lstrEventName)
            
            '@処置確定処理で,既に存在するﾛｯﾄだった場合
            With ptypExcpReport
                For llngCnt = 0 To .lngExcpReportLotListCnt - 1
                    '@同じﾛｯﾄが存在する場合
                    If txtLotID.Text = .typExcpLotList(llngCnt).strLotID Then
                        '@存在ﾌﾗｸﾞを立てる
                        lblnEnableFlag = True

                        'NSYS 更新用レコード読込
                        Dim typExcpLotListTmp As ExcpLot = .typExcpLotList(llngCnt)
                        
                        '@表記内容を構造体の内容として更新する
                        typExcpLotListTmp.strLotID = txtLotID.Text                                               'ﾛｯﾄID
                        typExcpLotListTmp.strReserveQuantity = txtHoldNum.Text                                   '保留
                        typExcpLotListTmp.strAbandonQuantity = txtAbandonNum.Text                                '廃却
                        typExcpLotListTmp.strAmendQuantity = txtAmendNum.Text                                    '手直
                        typExcpLotListTmp.strCorrectQuantity = txtCorrectNum.Text                                '修正
                        typExcpLotListTmp.strUsualQuantity = txtUsualNum.Text                                    '通常
                        typExcpLotListTmp.strEvalQuantity = txtEvalNum.Text                                      '評価
                        typExcpLotListTmp.strTakeQuantity = txtTakeNum.Text                                      '特採
                        'NSYS 数値変換
                        Dim lstrTotalNumTmp As String = lblTotalNum.Text
                        If IsNumeric(lstrTotalNumTmp) Then
                            lstrTotalNumTmp = Format$(CLng(lblTotalNum.Text), CPstrNoKanmaFormat)
                        End If
                        typExcpLotListTmp.strTargetQuantity = lstrTotalNumTmp                                    '対象数量
                        typExcpLotListTmp.strTotalQuantity = txtTotalNum.Text                                    '合計
                        
                        '@処置
                        typExcpLotListTmp.strDisposalFlag = CMstrWkNo
                        
                        '@追加
                        typExcpLotListTmp.strAppendFlag = CMlngIndex0
                        
                        '@最終更新日時
                        typExcpLotListTmp.strEditTime = mstrLastUpdate

                        'NSYS 更新済みレコードと入れ替え
                        .typExcpLotList(llngCnt) = typExcpLotListTmp
                    End If
                Next llngCnt
                
                '@ﾌﾗｸﾞにより構造体にｾｯﾄするか否か判別
                If lblnEnableFlag = False Then
                    '@ｶｳﾝﾄｱｯﾌﾟ
                    .lngExcpReportLotListCnt = .lngExcpReportLotListCnt + 1
                    '@領域確保
                    'ReDim Preserve .typExcpLotList(.lngExcpReportLotListCnt)
                    Dim typExcpLotListTmp As ExcpLot = New ExcpLot
                        
                    typExcpLotListTmp.strLotID = txtLotID.Text                   'ﾛｯﾄID
                    typExcpLotListTmp.strReserveQuantity = txtHoldNum.Text       '保留
                    typExcpLotListTmp.strAbandonQuantity = txtAbandonNum.Text    '廃却
                    typExcpLotListTmp.strAmendQuantity = txtAmendNum.Text        '手直
                    typExcpLotListTmp.strCorrectQuantity = txtCorrectNum.Text    '修正
                    typExcpLotListTmp.strUsualQuantity = txtUsualNum.Text        '通常
                    typExcpLotListTmp.strEvalQuantity = txtEvalNum.Text          '評価
                    typExcpLotListTmp.strTakeQuantity = txtTakeNum.Text          '特採
                    'NSYS 数値変換
                    Dim lstrTotalNumTmp As String = lblTotalNum.Text
                    If IsNumeric(lstrTotalNumTmp) Then
                        lstrTotalNumTmp = Format$(CLng(lblTotalNum.Text), CPstrNoKanmaFormat)
                    End If
                    typExcpLotListTmp.strTargetQuantity = lstrTotalNumTmp        '対象数量
                    typExcpLotListTmp.strTotalQuantity = txtTotalNum.Text        '合計
                    typExcpLotListTmp.strDisposalFlag = CMstrWkNo                '@処置
                    typExcpLotListTmp.strAppendFlag = CMlngIndex1                '@追加
                    typExcpLotListTmp.strEditTime = mstrLastUpdate               '@最終更新日時

                    'NSYS 編集済み構造体追加
                    .typExcpLotList.Add(typExcpLotListTmp)
                End If
                
                '@対象数量の計算
                For llngCnt = 0 To .lngExcpReportLotListCnt - 1
                    'NSYS 数値の場合のみ加算
                    If IsNumeric(.typExcpLotList(llngCnt).strTotalQuantity) Then
                        llngTargetNum = llngTargetNum + CLng(.typExcpLotList(llngCnt).strTotalQuantity)
                    End If
                Next llngCnt
                
                '@@対象数量の設定
                .strTargetQuantity = llngTargetNum
                
                '@全処置ﾌﾗｸﾞの初期化
                lblnFlag = True
                
                '@全処置ﾌﾗｸﾞの設定
                For llngCnt = 0 To .lngExcpReportLotListCnt - 1
                    '@未処置のﾛｯﾄが存在する場合
                    If .typExcpLotList(llngCnt).strDisposalFlag = CMstrWkNo Then
                        lblnFlag = False
                    
                        Exit For
                    End If
                Next llngCnt
                
                '@ﾌﾗｸﾞ設定
                If lblnFlag = True Then
                    .strAllDisposalFlag = CMstrWk               '処置済
                Else
                    .strAllDisposalFlag = CMstrWkNo             '未処置
                End If
            End With
            
            '@工程異常/不適合品処理票情報登録
            lblnAns = pubblnExcpChgReport_Upd(ptypExcpReport, lstrGuidMsg, lstrGuidMsgCode)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)

                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)

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
            
            '@画面を閉じる
            Call cmdClose_Click(cmdClose,e)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSave_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：処置確定
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/11 (Thu) 15:13:04 S.Deguchi
    '更新日：2006/12/01 (Fri) 11:35:58 T.Kitagawa
    '備　考：
    '　　　：2006/12/01 (Fri) 11:35:58 T.Kitagawa　ﾊﾟｽﾜｰﾄﾞ確認機能追加（案件№01581）
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrFunctionID          As String
        Dim lstrActionID            As String               'ｱｸｼｮﾝID
        Dim lstrEmpID               As String               '作業者ID
        Dim lstrEmpName             As String               '作業者名
        Dim lstrSBID                As String               'ｼｽﾃﾑﾌﾞﾛｯｸ
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance        As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg
        Dim lblnFlag                As Boolean              '処置ﾌﾗｸﾞ
        Dim lblnEnableFlag          As Boolean              '存在ﾌﾗｸﾞ
        Dim llngTargetNum           As Integer              '対象数量

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
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrEventName = "cmdRegist_Click"
            
            '@存在ﾌﾗｸﾞを初期化
            lblnEnableFlag = False
            
            '@確定ﾁｪｯｸ
            lblnAns = prvblncmdRegist_Chk
            '@結果判定
            If lblnAns = False Then
                Exit Sub
            End If

            '@処置終了処理で,既に存在するﾛｯﾄだった場合
            With ptypExcpReport
                For llngCnt = 0 To .lngExcpReportLotListCnt - 1
                    '@同じﾛｯﾄが存在する場合
                    If txtLotID.Text = .typExcpLotList(llngCnt).strLotID Then
                        '@存在ﾌﾗｸﾞを立てる
                        lblnEnableFlag = True

                        'NSYS 更新用レコード読込
                        Dim typExcpLotListTmp As ExcpLot = .typExcpLotList(llngCnt)
                        
                        '@表記内容を構造体の内容として更新する
                        typExcpLotListTmp.strLotID = txtLotID.Text                                                'ﾛｯﾄID
                        '保留
                        Dim strReserveQuantityTmp As String = txtHoldNum.Text
                        If IsNumeric(strReserveQuantityTmp) Then
                            strReserveQuantityTmp = Format$(CLng(txtHoldNum.Text), CPstrNoKanmaFormat)
                        End If
                        typExcpLotListTmp.strReserveQuantity = strReserveQuantityTmp
                        '廃却
                        Dim strAbandonQuantityTmp As String = txtAbandonNum.Text
                        If IsNumeric(strAbandonQuantityTmp) Then
                            strAbandonQuantityTmp = Format$(CLng(txtAbandonNum.Text), CPstrNoKanmaFormat)
                        End If
                        typExcpLotListTmp.strAbandonQuantity = strAbandonQuantityTmp
                        '手直
                        Dim strAmendQuantityTmp As String = txtAmendNum.Text
                        If IsNumeric(strAmendQuantityTmp) Then
                            strAmendQuantityTmp = Format$(CLng(txtAmendNum.Text), CPstrNoKanmaFormat)
                        End If
                        typExcpLotListTmp.strAmendQuantity = strAmendQuantityTmp
                        '修正
                        Dim strCorrectQuantityTmp As String =  txtCorrectNum.Text
                        If IsNumeric(strCorrectQuantityTmp) Then
                            strCorrectQuantityTmp = Format$(CLng(txtCorrectNum.Text), CPstrNoKanmaFormat)
                        End If
                        typExcpLotListTmp.strCorrectQuantity = strCorrectQuantityTmp
                        '通常
                        Dim strUsualQuantityTmp As String = txtUsualNum.Text
                        If IsNumeric(strUsualQuantityTmp) Then
                            strUsualQuantityTmp = Format$(CLng(txtUsualNum.Text), CPstrNoKanmaFormat)
                        End If
                        typExcpLotListTmp.strUsualQuantity = strUsualQuantityTmp
                        '評価
                        Dim strEvalQuantityTmp As String = txtEvalNum.Text
                        If IsNumeric(strEvalQuantityTmp) Then
                            strEvalQuantityTmp = Format$(CLng(txtEvalNum.Text), CPstrNoKanmaFormat)
                        End If
                        typExcpLotListTmp.strEvalQuantity = strEvalQuantityTmp
                        '特採
                        Dim strTakeQuantityTmp As String = txtTakeNum.Text
                        If IsNumeric(strTakeQuantityTmp) Then
                            strTakeQuantityTmp = Format$(CLng(txtTakeNum.Text), CPstrNoKanmaFormat)
                        End If
                        typExcpLotListTmp.strTakeQuantity = strTakeQuantityTmp
                        'NSYS 対象数量数値変換
                        Dim lstrTotalNumTmp As String = lblTotalNum.Text
                        If IsNumeric(lstrTotalNumTmp) Then
                            lstrTotalNumTmp = Format$(CLng(lblTotalNum.Text), CPstrNoKanmaFormat)
                        End If
                        typExcpLotListTmp.strTargetQuantity = lstrTotalNumTmp                                     '対象数量
                        'NSYS 合計数値変換
                        Dim lstrTotalNumTmp2 As String = txtTotalNum.Text
                        If IsNumeric(lstrTotalNumTmp2) Then
                            lstrTotalNumTmp2 = Format$(CLng(txtTotalNum.Text), CPstrNoKanmaFormat)
                        End If
                        typExcpLotListTmp.strTotalQuantity = lstrTotalNumTmp2                                     '合計
                        
                        '@処置
                        typExcpLotListTmp.strDisposalFlag = CMstrWk
                        
                        '@追加
                        typExcpLotListTmp.strAppendFlag = CMlngIndex0
                        
                        '@最終更新日時
                        typExcpLotListTmp.strEditTime = mstrLastUpdate

                        'NSYS 更新済みレコードと入れ替え
                        .typExcpLotList(llngCnt) = typExcpLotListTmp
                    End If
                Next llngCnt
                
                '@ﾌﾗｸﾞにより構造体にｾｯﾄするか否か判別
                If lblnEnableFlag = False Then
                    '@ｶｳﾝﾄｱｯﾌﾟ
                    .lngExcpReportLotListCnt = .lngExcpReportLotListCnt + 1
                    
                    '@領域確保
                    'ReDim Preserve .typExcpLotList(.lngExcpReportLotListCnt)
                    Dim typExcpLotListTmp As ExcpLot = New ExcpLot
                        
                    typExcpLotListTmp.strLotID = txtLotID.Text                    'ﾛｯﾄID
                    typExcpLotListTmp.strReserveQuantity = txtHoldNum.Text        '保留
                    typExcpLotListTmp.strAbandonQuantity = txtAbandonNum.Text     '廃却
                    typExcpLotListTmp.strAmendQuantity = txtAmendNum.Text         '手直
                    typExcpLotListTmp.strCorrectQuantity = txtCorrectNum.Text     '修正
                    typExcpLotListTmp.strUsualQuantity = txtUsualNum.Text         '通常
                    typExcpLotListTmp.strEvalQuantity = txtEvalNum.Text           '評価
                    typExcpLotListTmp.strTakeQuantity = txtTakeNum.Text           '特採
                    'NSYS 対象数量数値変換
                    Dim strTargetQuantityTmp As String = lblTotalNum.Text
                    If IsNumeric(strTargetQuantityTmp) Then
                        strTargetQuantityTmp = Format$(CLng(lblTotalNum.Text), CPstrNoKanmaFormat)
                    End If
                    typExcpLotListTmp.strTargetQuantity = strTargetQuantityTmp    '対象数量
                    typExcpLotListTmp.strTotalQuantity = txtTotalNum.Text         '合計
                    typExcpLotListTmp.strDisposalFlag = CMstrWk                   '@処置
                    typExcpLotListTmp.strAppendFlag = CMlngIndex1                 '@追加
                    typExcpLotListTmp.strEditTime = mstrLastUpdate                '@最終更新日時

                    'NSYS 編集済み構造体追加
                    .typExcpLotList.Add(typExcpLotListTmp)
                End If
                
                '@対象数量の計算
                For llngCnt = 0 To .lngExcpReportLotListCnt - 1
                    If IsNumeric(.typExcpLotList(llngCnt).strTotalQuantity) Then
                        llngTargetNum = llngTargetNum + CLng(.typExcpLotList(llngCnt).strTotalQuantity)
                    End If
                Next llngCnt
                
                '@@対象数量の設定
                .strTargetQuantity = llngTargetNum
                
                '@全処置ﾌﾗｸﾞの初期化
                lblnFlag = True
                
                '@全処置ﾌﾗｸﾞの設定
                For llngCnt = 0 To .lngExcpReportLotListCnt - 1
                    '@未処置のﾛｯﾄが存在する場合
                    If .typExcpLotList(llngCnt).strDisposalFlag = CMstrWkNo Then
                        lblnFlag = False
                    
                        Exit For
                    End If
                Next llngCnt
                
                '@ﾌﾗｸﾞ設定
                If lblnFlag = True Then
                    .strAllDisposalFlag = CMstrWk               '処置済
                Else
                    .strAllDisposalFlag = CMstrWkNo             '未処置
                End If
            End With
            
            '@作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力
            frmxxCM0020.Instance.ShowDialog(Me)
            frmxxCM0020.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, lstrEventName)

            '@実行権限の処理を追加
            lstrFunctionID = CPstrKeyEN00U0             '機能ID: EN00U0
            lstrActionID = CPstrAuthority               'ｱｸｼｮﾝID：処置登録
            lstrEmpID = pstrUserID                      'ﾕｰｻﾞｰID
            lstrEmpName = pstrUserName                  'ﾕｰｻﾞｰ名
            lstrSBID = ptypExcpReport.strSbID           'ｼｽﾃﾑﾌﾞﾛｯｸ

            '@実行権限ﾁｪｯｸ
            lblnAns = pubAuthority_Chk(lstrFunctionID, lstrActionID, lstrEmpID, lstrEmpName, lstrSBID)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, CPstrAuthority)
                '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxCM00H0.Instance.Text, True, 16)

                Exit Sub
            End If

            '@工程異常/不適合品処理票情報登録
            lblnAns = pubblnExcpChgReport_Upd(ptypExcpReport, lstrGuidMsg, lstrGuidMsgCode)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)

                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)

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
            
            '@登録完了ﾒｯｾｰｼﾞを表示する
            If ptypExcpReport.strIncongFlag = CMstrIncongFlag0 Then
            '@工程異常処理票の場合
                '@表示ﾒｯｾｰｼﾞ変換：<TRM1GI>$$工程異常処理票を登録しました。異常処理№[%1]
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001G, ptypExcpReport.strExcpNo)
            Else
            '@不適合品処理票の場合
                '@表示ﾒｯｾｰｼﾞ変換：<TRM1UI>$$不適合品処理票を登録しました。異常処理№[%1]
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001U, ptypExcpReport.strExcpNo)
            End If
            
            '@成功ﾒｯｾｰｼﾞ表示
            Call pubVsfInfo_Disp(pstrDMsg)
            
            '@画面を閉じる
            Call cmdClose_Click(sender,e)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdRegist_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtHoldNum_Change
    '機　能：保留
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/30 (Tue) 18:34:45 S.Deguchi
    '更新日：2005/08/30 (Tue) 18:34:45
    '備　考：
    Private Sub txtHoldNum_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtHoldNum.Change

        Dim llngNum     As Integer      '合計戻り値

        Try
            '@数量計算(数量と合計の大小関係を比較)
            Call prvtxtWkNum_Cal(llngNum)
            
            '@計算値を表示
            lblTotalNum.Text = Format$(llngNum, CPstrDateFormatKanma)
            
            If mblnEditFlag = True Then
                'NSYS 数値変換
                Dim lstrHoldNumTmp As String = txtHoldNum.Text
                If IsNumeric(lstrHoldNumTmp) Then
                    lstrHoldNumTmp = Format$(CLng(txtHoldNum.Text), CPstrDateFormatKanma)
                End If
                '@ﾌｫｰﾏｯﾄ変換
                txtHoldNum.Text = lstrHoldNumTmp
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtHoldNum_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtHoldNum_Validate
    '機　能：保留Validate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/08/30 (Tue) 18:39:22 S.Deguchi
    '更新日：2008/04/07 (Mon) 10:06:49 M.Koni
    '備　考：
    '　　　：2008/04/07 (Mon) 09:56:35 M.Koni 合計,数量の判断処理を移動<案件No.02755>
    Private Sub txtHoldNum_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtHoldNum.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@数量が空欄もしくは,"0"の場合には,ﾒｯｾｰｼﾞを表示する
            If txtTotalNum.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0063)
                
                '@"<TRM63W>$$数量が入力されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽを数量欄に
                If ActiveControl.Name = txtHoldNum.Name Then
                    Call pubSetFocus(txtTotalNum)
                End If
                
                Exit Sub
            End If
            
        '@↓2008/04/07 (Mon) 09:56:05 M.Koni **************************************************
        '   '@計算値と数量を比較
        '   If CLng(txtTotalNum.Text) < CLng(lblTotalNum.Caption) Then
        '   '@"数量"以上の場合
        '       '@表示ﾒｯｾｰｼﾞ変換
        '       pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006N)
        '
        '       '@"ロット処置の合計が、数量を超えています。設定を見直してください。"
        '       Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxCM00H1.Caption, True, 16)
        '
        '       '@ﾌｫｰｶｽそのまま
        '       Cancel = True
        '
        '       Exit Sub
        '   End If
        '@↑2008/04/07 (Mon) 09:56:05 M.Koni **************************************************
            
            '@処置欄が空欄の場合,"0"をｾｯﾄする
            If txtHoldNum.Text = vbNullString Then
                txtHoldNum.Text = CMlngIndex0
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtHoldNum_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtAbandonNum_Change
    '機　能：廃却Change
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/30 (Tue) 18:35:01 S.Deguchi
    '更新日：2005/08/30 (Tue) 18:35:01
    '備　考：
    Private Sub txtAbandonNum_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtAbandonNum.Change

        Dim llngNum     As Integer      '合計戻り値

        Try
            '@数量計算(数量と合計の大小関係を比較)
            Call prvtxtWkNum_Cal(llngNum)
            
            '@計算値を表示
            lblTotalNum.Text = Format$(llngNum, CPstrDateFormatKanma)

            If mblnEditFlag = True Then
                'NSYS 数値変換
                Dim lstrAbandonNumTmp As String = txtAbandonNum.Text
                If IsNumeric(lstrAbandonNumTmp) Then
                    lstrAbandonNumTmp = Format$(CLng(txtAbandonNum.Text), CPstrDateFormatKanma)
                End If
                '@ﾌｫｰﾏｯﾄ変換
                txtAbandonNum.Text = lstrAbandonNumTmp
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtAbandonNum_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtAbandonNum_Validate
    '機　能：廃却Validate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/08/30 (Tue) 18:40:24 S.Deguchi
    '更新日：2008/04/07 (Mon) 09:56:14 M.Koni
    '備　考：
    '　　　：2008/04/07 (Mon) 09:56:35 M.Koni 合計,数量の判断処理を移動<案件No.02755>
    Private Sub txtAbandonNum_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtAbandonNum.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@数量が空欄もしくは,"0"の場合には,ﾒｯｾｰｼﾞを表示する
            If txtTotalNum.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0063)
                
                '@"<TRM63W>$$数量が入力されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽを数量欄に
                If ActiveControl.Name = txtAbandonNum.Name Then
                    Call pubSetFocus(txtTotalNum)
                End If
                
                Exit Sub
            End If
            
        '@↓2008/04/07 (Mon) 09:56:05 M.Koni **************************************************
        '   '@計算値と数量を比較
        '   If CLng(txtTotalNum.Text) < CLng(lblTotalNum.Caption) Then
        '   '@"数量"以上の場合
        '       '@表示ﾒｯｾｰｼﾞ変換
        '       pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006N)
        '
        '       '@"ロット処置の合計が、数量を超えています。設定を見直してください。"
        '       Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxCM00H1.Caption, True, 16)
        '
        '       '@ﾌｫｰｶｽそのまま
        '       Cancel = True
        '
        '       Exit Sub
        '   End If
        '@↑2008/04/07 (Mon) 09:56:05 M.Koni **************************************************
            
            '@処置欄が空欄の場合,"0"をｾｯﾄする
            If txtAbandonNum.Text = vbNullString Then
                txtAbandonNum.Text = CMlngIndex0
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtAbandonNum_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtAmendNum_Change
    '機　能：手直し
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/30 (Tue) 18:35:20 S.Deguchi
    '更新日：2005/08/30 (Tue) 18:35:20
    '備　考：
    Private Sub txtAmendNum_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtAmendNum.Change

        Dim llngNum     As Integer      '合計戻り値

        Try
            '@数量計算(数量と合計の大小関係を比較)
            Call prvtxtWkNum_Cal(llngNum)
            
            '@計算値を表示
            lblTotalNum.Text = Format$(llngNum, CPstrDateFormatKanma)

            If mblnEditFlag = True Then
                'NSYS 数値変換
                Dim lstrAmendNumTmp As String = txtAmendNum.Text
                If IsNumeric(lstrAmendNumTmp) Then
                    lstrAmendNumTmp = Format$(CLng(txtAmendNum.Text), CPstrDateFormatKanma)
                End If
                '@ﾌｫｰﾏｯﾄ変換
                txtAmendNum.Text = lstrAmendNumTmp
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtAmendNum_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtAmendNum_Validate
    '機　能：手直しValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/08/30 (Tue) 18:39:22 S.Deguchi
    '更新日：2008/04/07 (Mon) 10:00:39 M.Koni
    '備　考：
    '　　　：2008/04/07 (Mon) 09:56:35 M.Koni 合計,数量の判断処理を移動<案件No.02755>
    Private Sub txtAmendNum_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtAmendNum.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@数量が空欄もしくは,"0"の場合には,ﾒｯｾｰｼﾞを表示する
            If txtTotalNum.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0063)
                
                '@"<TRM63W>$$数量が入力されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽを数量欄に
                If ActiveControl.Name = txtAmendNum.Name Then
                    Call pubSetFocus(txtTotalNum)
                End if
                
                Exit Sub
            End If
            
        '@↓2008/04/07 (Mon) 09:56:05 M.Koni **************************************************
        '   '@計算値と数量を比較
        '   If CLng(txtTotalNum.Text) < CLng(lblTotalNum.Caption) Then
        '   '@"数量"以上の場合
        '       '@表示ﾒｯｾｰｼﾞ変換
        '       pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006N)
        '
        '       '@"ロット処置の合計が、数量を超えています。設定を見直してください。"
        '       Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxCM00H1.Caption, True, 16)
        '
        '       '@ﾌｫｰｶｽそのまま
        '       Cancel = True
        '
        '       Exit Sub
        '   End If
        '@↑2008/04/07 (Mon) 09:56:05 M.Koni **************************************************
            
            '@処置欄が空欄の場合,"0"をｾｯﾄする
            If txtAmendNum.Text = vbNullString Then
                txtAmendNum.Text = CMlngIndex0
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtAmendNum_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCorrectNum_Change
    '機　能：修正
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/30 (Tue) 18:35:44 S.Deguchi
    '更新日：2005/08/30 (Tue) 18:35:44
    '備　考：
    Private Sub txtCorrectNum_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCorrectNum.Change

        Dim llngNum     As Integer      '合計戻り値

        Try
            '@数量計算(数量と合計の大小関係を比較)
            Call prvtxtWkNum_Cal(llngNum)
            
            '@計算値を表示
            lblTotalNum.Text = Format$(llngNum, CPstrDateFormatKanma)

            If mblnEditFlag = True Then
                'NSYS 数値変換
                Dim lstrCorrectNumTmp As String = txtCorrectNum.Text
                If IsNumeric(lstrCorrectNumTmp) Then
                    lstrCorrectNumTmp = Format$(CLng(txtCorrectNum.Text), CPstrDateFormatKanma)
                End If
                '@ﾌｫｰﾏｯﾄ変換
                txtCorrectNum.Text = lstrCorrectNumTmp
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCorrectNum_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCorrectNum_Validate
    '機　能：保修正Validate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/08/30 (Tue) 18:39:22 S.Deguchi
    '更新日：2008/04/07 (Mon) 10:01:14 M.Koni
    '備　考：
    '　　　：2008/04/07 (Mon) 09:56:35 M.Koni 合計,数量の判断処理を移動<案件No.02755>
    Private Sub txtCorrectNum_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCorrectNum.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@数量が空欄もしくは,"0"の場合には,ﾒｯｾｰｼﾞを表示する
            If txtTotalNum.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0063)
                
                '@"<TRM63W>$$数量が入力されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽを数量欄に
                If ActiveControl.Name = txtCorrectNum.Name then
                    Call pubSetFocus(txtTotalNum)
                End If
                
                Exit Sub
            End If
            
        '@↓2008/04/07 (Mon) 09:56:05 M.Koni **************************************************
        '   '@計算値と数量を比較
        '   If CLng(txtTotalNum.Text) < CLng(lblTotalNum.Caption) Then
        '   '@"数量"以上の場合
        '       '@表示ﾒｯｾｰｼﾞ変換
        '       pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006N)
        '
        '       '@"ロット処置の合計が、数量を超えています。設定を見直してください。"
        '       Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxCM00H1.Caption, True, 16)
        '
        '       '@ﾌｫｰｶｽそのまま
        '       Cancel = True
        '
        '       Exit Sub
        '   End If
        '@↑2008/04/07 (Mon) 09:56:05 M.Koni **************************************************

            '@処置欄が空欄の場合,"0"をｾｯﾄする
            If txtCorrectNum.Text = vbNullString Then
                txtCorrectNum.Text = CMlngIndex0
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCorrectNum_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtUsualNum_Change
    '機　能：通常
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/30 (Tue) 18:36:17 S.Deguchi
    '更新日：2005/08/30 (Tue) 18:36:17
    '備　考：
    Private Sub txtUsualNum_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtUsualNum.Change

        Dim llngNum     As Integer      '合計戻り値

        Try
            '@数量計算(数量と合計の大小関係を比較)
            Call prvtxtWkNum_Cal(llngNum)
            
            '@計算値を表示
            lblTotalNum.Text = Format$(llngNum, CPstrDateFormatKanma)

            If mblnEditFlag = True Then
                'NSYS 数値変換
                Dim lstrUsualnumTmp As String = txtUsualNum.Text
                If IsNumeric(lstrUsualnumTmp) Then
                    lstrUsualnumTmp = Format$(CLng(txtUsualNum.Text), CPstrDateFormatKanma)
                End If
                '@ﾌｫｰﾏｯﾄ変換
                txtUsualNum.Text = lstrUsualnumTmp
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtUsualNum_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtUsualNum_Validate
    '機　能：通常Validate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/08/30 (Tue) 18:39:22 S.Deguchi
    '更新日：2008/04/07 (Mon) 10:02:29 M.Koni
    '備　考：
    '　　　：2008/04/07 (Mon) 09:56:35 M.Koni 合計,数量の判断処理を移動<案件No.02755>
    Private Sub txtUsualNum_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtUsualNum.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@数量が空欄もしくは,"0"の場合には,ﾒｯｾｰｼﾞを表示する
            If txtTotalNum.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0063)
                
                '@"<TRM63W>$$数量が入力されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽを数量欄に
                If ActiveControl.Name = txtUsualNum.Name Then
                    Call pubSetFocus(txtTotalNum)
                End If
                
                Exit Sub
            End If
            
        '@↓2008/04/07 (Mon) 09:56:05 M.Koni **************************************************
        '   '@計算値と数量を比較
        '   If CLng(txtTotalNum.Text) < CLng(lblTotalNum.Caption) Then
        '   '@"数量"以上の場合
        '       '@表示ﾒｯｾｰｼﾞ変換
        '       pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006N)
        '
        '       '@"ロット処置の合計が、数量を超えています。設定を見直してください。"
        '       Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxCM00H1.Caption, True, 16)
        '
        '       '@ﾌｫｰｶｽそのまま
        '       Cancel = True
        '
        '       Exit Sub
        '   End If
        '@↑2008/04/07 (Mon) 09:56:05 M.Koni **************************************************

            '@処置欄が空欄の場合,"0"をｾｯﾄする
            If txtUsualNum.Text = vbNullString Then
                txtUsualNum.Text = CMlngIndex0
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtUsualNum_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtEvalNum_Change
    '機　能：評価
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/30 (Tue) 18:36:38 S.Deguchi
    '更新日：2005/08/30 (Tue) 18:36:38
    '備　考：
    Private Sub txtEvalNum_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtEvalNum.Change

        Dim llngNum     As Integer      '合計戻り値

        Try
            '@数量計算(数量と合計の大小関係を比較)
            Call prvtxtWkNum_Cal(llngNum)
            
            '@計算値を表示
            lblTotalNum.Text = Format$(llngNum, CPstrDateFormatKanma)

            If mblnEditFlag = True Then
                'NSYS 数値変換
                Dim lstrEvalNumTmp As String = txtEvalNum.Text
                If IsNumeric(lstrEvalNumTmp) Then
                    lstrEvalNumTmp = Format$(CLng(txtEvalNum.Text), CPstrDateFormatKanma)
                End If
                '@ﾌｫｰﾏｯﾄ変換
                txtEvalNum.Text = lstrEvalNumTmp
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtEvalNum_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtEvalNum_Validate
    '機　能：評価Validate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/08/30 (Tue) 18:39:22 S.Deguchi
    '更新日：2008/04/07 (Mon) 10:02:49 M.Koni
    '備　考：
    '　　　：2008/04/07 (Mon) 09:56:35 M.Koni 合計,数量の判断処理を移動<案件No.02755>
    Private Sub txtEvalNum_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtEvalNum.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@数量が空欄もしくは,"0"の場合には,ﾒｯｾｰｼﾞを表示する
            If txtTotalNum.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0063)
                
                '@"<TRM63W>$$数量が入力されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽを数量欄に
                If ActiveControl.Name = txtEvalNum.Name Then
                    Call pubSetFocus(txtTotalNum)
                End If
                
                Exit Sub
            End If
            
        '@↓2008/04/07 (Mon) 09:56:05 M.Koni **************************************************
        '   '@計算値と数量を比較
        '   If CLng(txtTotalNum.Text) < CLng(lblTotalNum.Caption) Then
        '   '@"数量"以上の場合
        '       '@表示ﾒｯｾｰｼﾞ変換
        '       pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006N)
        '
        '       '@"ロット処置の合計が、数量を超えています。設定を見直してください。"
        '       Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxCM00H1.Caption, True, 16)
        '
        '       '@ﾌｫｰｶｽそのまま
        '       Cancel = True
        '
        '       Exit Sub
        '   End If
        '@↑2008/04/07 (Mon) 09:56:05 M.Koni **************************************************

            '@処置欄が空欄の場合,"0"をｾｯﾄする
            If txtEvalNum.Text = vbNullString Then
                txtEvalNum.Text = CMlngIndex0
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtEvalNum_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtTakeNum_Change
    '機　能：特採
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/30 (Tue) 18:36:56 S.Deguchi
    '更新日：2005/08/30 (Tue) 18:36:56
    '備　考：
    Private Sub txtTakeNum_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtTakeNum.Change

        Dim llngNum     As Integer      '合計戻り値

        Try
            '@数量計算(数量と合計の大小関係を比較)
            Call prvtxtWkNum_Cal(llngNum)
            
            '@計算値を表示
            lblTotalNum.Text = Format$(llngNum, CPstrDateFormatKanma)

            If mblnEditFlag = True Then
                'NSYS 数値変換
                Dim lstrTakeNumTmp As String = txtTakeNum.Text
                If IsNumeric(lstrTakeNumTmp) Then
                    lstrTakeNumTmp = Format$(CLng(txtTakeNum.Text), CPstrDateFormatKanma)
                End If
                '@ﾌｫｰﾏｯﾄ変換
                txtTakeNum.Text = lstrTakeNumTmp
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtTakeNum_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtTakeNum_Validate
    '機　能：特採Validate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/08/30 (Tue) 18:39:22 S.Deguchi
    '更新日：2008/04/07 (Mon) 10:03:44 M.Koni
    '備　考：
    '　　　：2008/04/07 (Mon) 09:56:35 M.Koni 合計,数量の判断処理を移動<案件No.02755>
    Private Sub txtTakeNum_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtTakeNum.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@数量が空欄もしくは,"0"の場合には,ﾒｯｾｰｼﾞを表示する
            If txtTotalNum.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0063)
                
                '@"<TRM63W>$$数量が入力されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽを数量欄に
                If ActiveControl.Name = txtTakeNum.Name Then
                    Call pubSetFocus(txtTotalNum)
                End If
                
                Exit Sub
            End If
            
        '@↓2008/04/07 (Mon) 09:56:05 M.Koni **************************************************
        '   '@計算値と数量を比較
        '   If CLng(txtTotalNum.Text) < CLng(lblTotalNum.Caption) Then
        '   '@"数量"以上の場合
        '       '@表示ﾒｯｾｰｼﾞ変換
        '       pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006N)
        '
        '       '@"ロット処置の合計が、数量を超えています。設定を見直してください。"
        '       Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxCM00H1.Caption, True, 16)
        '
        '       '@ﾌｫｰｶｽそのまま
        '       Cancel = True
        '
        '       Exit Sub
        '   End If
        '@↑2008/04/07 (Mon) 09:56:05 M.Koni **************************************************

            '@処置欄が空欄の場合,"0"をｾｯﾄする
            If txtTakeNum.Text = vbNullString Then
                txtTakeNum.Text = CMlngIndex0
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtTakeNum_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotID_Change
    '機　能：ﾛｯﾄID欄変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/10 (Wed) 17:21:29 S.Deguchi
    '更新日：2005/08/10 (Wed) 17:21:29
    '備　考：
    Private Sub txtLotID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLotID.Change

        Try
            '@初期化
            txtTotalNum.Text = vbNullString             '数量：空欄
            txtTotalNum.Enabled = False                 '数量：非活性化

            lblStatus.Text = vbNullString            '状態：空欄

            '@ﾃｷｽﾄﾎﾞｯｸｽの初期化
            txtHoldNum.Text = vbNullString          'ﾛｯﾄ処置欄：空欄
            txtAbandonNum.Text = vbNullString       'ﾛｯﾄ処置欄：空欄
            txtAmendNum.Text = vbNullString         'ﾛｯﾄ処置欄：空欄
            txtCorrectNum.Text = vbNullString       'ﾛｯﾄ処置欄：空欄
            txtUsualNum.Text = vbNullString         'ﾛｯﾄ処置欄：空欄
            txtEvalNum.Text = vbNullString          'ﾛｯﾄ処置欄：空欄
            txtTakeNum.Text = vbNullString          'ﾛｯﾄ処置欄：空欄

            txtHoldNum.Enabled = False              'ﾛｯﾄ処置欄：非活性化
            txtAbandonNum.Enabled = False           'ﾛｯﾄ処置欄：非活性化
            txtAmendNum.Enabled = False             'ﾛｯﾄ処置欄：非活性化
            txtCorrectNum.Enabled = False           'ﾛｯﾄ処置欄：非活性化
            txtUsualNum.Enabled = False             'ﾛｯﾄ処置欄：非活性化
            txtEvalNum.Enabled = False              'ﾛｯﾄ処置欄：非活性化
            txtTakeNum.Enabled = False              'ﾛｯﾄ処置欄：非活性化

            lblTotalNum.Text = vbNullString          '合計：空欄

            '@確定ﾎﾞﾀﾝの非活性化
            cmdRegist.Enabled = False

            '@処置確定ﾎﾞﾀﾝの非活性化
            cmdSave.Enabled = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtLotID_Validate
    '機　能：ﾛｯﾄID欄Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/08/10 (Wed) 17:21:32 S.Deguchi
    '更新日：2005/08/10 (Wed) 17:21:32
    '備　考：
    Private Sub txtLotID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtLotID.Validating

        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        Dim lblnAns                 As Boolean              '戻り値
        Dim ltypLotList             As LocalLotList         'ﾛｯﾄ情報格納構造体
        Dim lblnConFlag             As Boolean              '引継ﾌﾗｸﾞ

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ﾛｯﾄID欄ﾁｪｯｸ
            If txtLotID.Text = vbNullString Then
            '@ﾛｯﾄID欄が空欄の場合
                '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = txtLotID.Name then
                    Call pubSetFocus(cmdClose)
                End If

                Exit Sub
            Else
                '@桁ﾁｪｯｸ
                If txtLotID.NowByte <> cmlngMaxByte10 Then
                '@入力されたﾛｯﾄIDが10桁未満の場合
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0012)
                    
                    '@"ロットIDは10桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@追加ﾛｯﾄIDにﾌｫｰｶｽｾｯﾄ
                    e.Cancel = True
                    
                    Exit Sub
                Else
                    '@引継構造体の中に入力したﾛｯﾄの情報が存在する場合か否かで判別
                    With ptypExcpReport
                        '@ﾌﾗｸﾞ初期化
                        lblnConFlag = False
                        
                        '@引継構造体にﾛｯﾄが存在する場合
                        If .lngExcpReportLotListCnt > 0 Then
                            For llngCnt = 0 To .lngExcpReportLotListCnt - 1
                                If txtLotID.Text = .typExcpLotList(llngCnt).strLotID Then
                                    lblnConFlag = True
                                    
                                    Exit For
                                End If
                            Next llngCnt
                        Else
                            lblnConFlag = False
                        End If
                    End With
                    
                    If lblnConFlag = True Then
                    '@引継情報にﾛｯﾄが存在した場合
                        With ptypExcpReport
                            For llngCnt = 0 To .lngExcpReportLotListCnt - 1
                                '@一致するﾛｯﾄIDを検索,情報を画面にｾｯﾄ
                                If txtLotID.Text = .typExcpLotList(llngCnt).strLotID Then
                                    '@情報を画面にｾｯﾄ
                                    txtTotalNum.Text = .typExcpLotList(llngCnt).strTotalQuantity        '数量
                                    
                                    txtHoldNum.Text = .typExcpLotList(llngCnt).strReserveQuantity       '保留
                                    txtAbandonNum.Text = .typExcpLotList(llngCnt).strAbandonQuantity    '廃却
                                    txtAmendNum.Text = .typExcpLotList(llngCnt).strAmendQuantity        '手直し
                                    txtCorrectNum.Text = .typExcpLotList(llngCnt).strCorrectQuantity    '修正
                                    txtUsualNum.Text = .typExcpLotList(llngCnt).strUsualQuantity        '通常
                                    txtEvalNum.Text = .typExcpLotList(llngCnt).strEvalQuantity          '評価
                                    txtTakeNum.Text = .typExcpLotList(llngCnt).strTakeQuantity          '特採
                                    '合計
                                    Dim strTargetQuantityTmp As String = .typExcpLotList(llngCnt).strTargetQuantity
                                    If IsNumeric(strTargetQuantityTmp) Then
                                        strTargetQuantityTmp = Format$(CLng(.typExcpLotList(llngCnt).strTargetQuantity), CPstrDateFormatKanma)
                                    End If
                                    lblTotalNum.Text = strTargetQuantityTmp
                                    
                                    '@状態設定
                                    Select Case .typExcpLotList(llngCnt).strDisposalFlag
                                        Case CMstrWk            '処置済
                                            lblStatus.Text = CMstrWkJ
                                            
                                        Case Else               '未処置
                                            lblStatus.Text = CMstrWkNoJ
                                    End Select
                                End If
                            Next llngCnt
                            
                            '@状態によるｺﾝﾄﾛｰﾙの活性化処理
                            If lblStatus.Text = CMstrWkJ Then
                                '@各ｺﾝﾄﾛｰﾙを非活性化する
                                txtTotalNum.Enabled = False             '数量

                                txtHoldNum.Enabled = False              'ﾛｯﾄ処置欄：非活性化
                                txtAbandonNum.Enabled = False           'ﾛｯﾄ処置欄：非活性化
                                txtAmendNum.Enabled = False             'ﾛｯﾄ処置欄：非活性化
                                txtCorrectNum.Enabled = False           'ﾛｯﾄ処置欄：非活性化
                                txtUsualNum.Enabled = False             'ﾛｯﾄ処置欄：非活性化
                                txtEvalNum.Enabled = False              'ﾛｯﾄ処置欄：非活性化
                                txtTakeNum.Enabled = False              'ﾛｯﾄ処置欄：非活性化
                            Else
                                '@各ｺﾝﾄﾛｰﾙを活性化する
                                txtTotalNum.Enabled = True              '数量

                                txtHoldNum.Enabled = True               'ﾛｯﾄ処置欄：活性化
                                txtAbandonNum.Enabled = True            'ﾛｯﾄ処置欄：活性化
                                txtAmendNum.Enabled = True              'ﾛｯﾄ処置欄：活性化
                                txtCorrectNum.Enabled = True            'ﾛｯﾄ処置欄：活性化
                                txtUsualNum.Enabled = True              'ﾛｯﾄ処置欄：活性化
                                txtEvalNum.Enabled = True               'ﾛｯﾄ処置欄：活性化
                                txtTakeNum.Enabled = True               'ﾛｯﾄ処置欄：活性化
                            End If
                        End With
                    Else
                    '@引継情報にﾛｯﾄが存在しない場合
                        '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
                        lstrEventName = "txtLotID_Validate"
                    
                        '@ﾚｽﾎﾟﾝｽ取得開始
                        Call pubResponseStart(Me.Name, lstrEventName)
                
                        '@ﾛｯﾄ状態取得
                        With ltypLotList
                            .strLotID = txtLotID.Text
                        End With
                    
                        lblnAns = prvblnExcpLotCheck_Sel(ltypLotList)
                        '@結果判定
                        If lblnAns = False Then
                            '@失敗した場合には処理抜け
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(Me.Name, lstrEventName)
                            
                            '@追加ﾛｯﾄIDにﾌｫｰｶｽｾｯﾄ
                            e.Cancel = True
                            
                            Exit Sub
                        Else
                            '@比較用ﾛｯﾄが空欄の場合には取得した情報をｾｯﾄ
                            If mtypLotList.strLotID = vbNullString Then
                                '@取得情報をｾｯﾄ
                                mtypLotList = ltypLotList
                            End If
                        End If
                    
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(Me.Name, lstrEventName)
                
                        '@比較対象ﾛｯﾄと比較する
                        lblnAns = prvblnLotCFWFStatus_Chk(ltypLotList)
                        '@結果判定
                        If lblnAns = True Then
                        '@成功の場合
                            With ltypLotList
                                If .strCFLotFlag = CMstrCFFlag_WF Then
                                    txtTotalNum.Text = .strWFQuantity       '数量(WF)
                                Else
                                    txtTotalNum.Text = .strChipQuantity     '数量(Chip)
                                End If
                                '@ｺﾝﾄﾛｰﾙを活性化する
                                txtTotalNum.Enabled = True                  '数量
                                
                                lblStatus.Text = CMstrWkNoJ              '状態設定
            
                                txtHoldNum.Text = "0"                       'ﾛｯﾄ処置欄：0
                                txtAbandonNum.Text = "0"                    'ﾛｯﾄ処置欄：0
                                txtAmendNum.Text = "0"                      'ﾛｯﾄ処置欄：0
                                txtCorrectNum.Text = "0"                    'ﾛｯﾄ処置欄：0
                                txtUsualNum.Text = "0"                      'ﾛｯﾄ処置欄：0
                                txtEvalNum.Text = "0"                       'ﾛｯﾄ処置欄：0
                                txtTakeNum.Text = "0"                       'ﾛｯﾄ処置欄：0
                                
                                txtHoldNum.Enabled = True                   'ﾛｯﾄ処置欄：非活性化
                                txtAbandonNum.Enabled = True                'ﾛｯﾄ処置欄：非活性化
                                txtAmendNum.Enabled = True                  'ﾛｯﾄ処置欄：非活性化
                                txtCorrectNum.Enabled = True                'ﾛｯﾄ処置欄：非活性化
                                txtUsualNum.Enabled = True                  'ﾛｯﾄ処置欄：非活性化
                                txtEvalNum.Enabled = True                   'ﾛｯﾄ処置欄：非活性化
                                txtTakeNum.Enabled = True                   'ﾛｯﾄ処置欄：非活性化
                            End With
                        Else
                        '@失敗の場合
                            Exit Sub
                        End If
                    End If
                End If
            End If

            If lblStatus.Text = CMstrWkJ Then
                '@確定ﾎﾞﾀﾝの非活性化
                cmdRegist.Enabled = False
                
                '@処置確定ﾎﾞﾀﾝの非活性化
                cmdSave.Enabled = False
            Else
                '@確定ﾎﾞﾀﾝの活性化
                cmdRegist.Enabled = True
                
                '@処置確定ﾎﾞﾀﾝの活性化
                cmdSave.Enabled = True
            End If
            
            '@ﾌｫｰｶｽｾｯﾄ
            If txtTotalNum.Enabled = True Then
                If ActiveControl.Name = txtLotID.Name then
                    Call pubSetFocus(txtTotalNum)
                End If
            Else
                If ActiveControl.Name = txtLotID.Name then
                    Call pubSetFocus(cmdClose)
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtTotalNum_Change
    '機　能：合計数量のChange処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/31 (Wed) 09:08:10 S.Deguchi
    '更新日：2005/08/31 (Wed) 09:08:10
    '備　考：
    Private Sub txtTotalNum_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtTotalNum.Change

        Try
            If mblnEditFlag = True Then
                'NSYS 数値変換
                Dim lstrTotalNumTmp As String = txtTotalNum.Text
                If IsNumeric(lstrTotalNumTmp) Then
                    lstrTotalNumTmp = Format$(CLng(txtTotalNum.Text), CPstrDateFormatKanma)
                End If
                '@ﾌｫｰﾏｯﾄ変換
                txtTotalNum.Text = lstrTotalNumTmp
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtTotalNum_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtTotalNum_Validate
    '機　能：合計数量Valdate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2005/08/26 (Fri) 15:38:34 S.Deguchi
    '更新日：2005/08/26 (Fri) 15:38:34
    '備　考：
    Private Sub txtTotalNum_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtTotalNum.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@数量が空欄もしくは,"0"の場合には,ﾒｯｾｰｼﾞを表示する
            If txtTotalNum.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0063)
                
                '@"<TRM63W>$$数量が入力されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽを数量欄に
                e.Cancel = True
                
                Exit Sub
            Else
                '@ﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = txtTotalNum.Name Then
                    Call pubSetFocus(txtHoldNum)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtTotalNum_Validate"
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
    '関数名：prvfrmxxCM00H1_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/10 (Wed) 16:06:02 S.Deguchi
    '更新日：2005/08/10 (Wed) 16:06:02
    '備　考：
    Private Sub prvfrmxxCM00H1_Init()
        
        Try

            '@ﾌｫｰﾑのﾀｲﾄﾙを設定
            Me.Text = CPstrSubFormCM00H1
            
            '@内部変数の初期化
            mstrLotId = vbNullString                    'ﾛｯﾄID
            mstrHoldFlag = vbNullString                 '保留ﾌﾗｸﾞ
            mstrLastUpdate = vbNullString               '最終更新日時
            
            '@ｺﾝﾄﾛｰﾙの初期化
            txtLotID.Text = vbNullString                'ﾛｯﾄID
            txtTotalNum.Text = vbNullString             '数量
            
            lblStatus.Text = vbNullString            '状態
            
            '@ﾃｷｽﾄﾎﾞｯｸｽの初期化
            txtHoldNum.Text = vbNullString          'ﾛｯﾄ処置欄：空欄
            txtAbandonNum.Text = vbNullString       'ﾛｯﾄ処置欄：空欄
            txtAmendNum.Text = vbNullString         'ﾛｯﾄ処置欄：空欄
            txtCorrectNum.Text = vbNullString       'ﾛｯﾄ処置欄：空欄
            txtUsualNum.Text = vbNullString         'ﾛｯﾄ処置欄：空欄
            txtEvalNum.Text = vbNullString          'ﾛｯﾄ処置欄：空欄
            txtTakeNum.Text = vbNullString          'ﾛｯﾄ処置欄：空欄
            
            lblTotalNum.Text = vbNullString          '合計
            
            '@確定ﾎﾞﾀﾝの非活性化
            cmdRegist.Enabled = False
            
            '@処置確定ﾎﾞﾀﾝの非活性化
            cmdSave.Enabled = False
            
            '@閉じるボタンへCausesValidationを設定する
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00H1_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxCM00H1_Disp
    '機　能：引継情報の画面設定
    '引　数：なし
    '戻り値：なし
    '作成日：2005/08/10 (Wed) 16:40:18 S.Deguchi
    '更新日：2005/08/10 (Wed) 16:40:18
    '備　考：
    Private Sub prvfrmxxCM00H1_Disp()
        
        Dim llngCnt     As Integer      '汎用ｶｳﾝﾀ

        Try
            
            '@編集ﾌﾗｸﾞを立てる
            mblnEditFlag = True
            
            '@引継いだ情報が存在するか否かで,表示処理を分岐
            If pstrLotID = vbNullString Then
            '@引継情報が存在しない場合
                txtLotID.Text = vbNullString                    'ﾛｯﾄID

                txtTotalNum.Text = vbNullString                 '数量欄にNull
                txtTotalNum.Enabled = False                     '数量欄を非活性化

                lblTotalNum.Text = vbNullString              '合計欄にNull

                '@ﾃｷｽﾄﾎﾞｯｸｽの初期化
                txtHoldNum.Text = vbNullString                  'ﾛｯﾄ処置欄：空欄
                txtAbandonNum.Text = vbNullString               'ﾛｯﾄ処置欄：空欄
                txtAmendNum.Text = vbNullString                 'ﾛｯﾄ処置欄：空欄
                txtCorrectNum.Text = vbNullString               'ﾛｯﾄ処置欄：空欄
                txtUsualNum.Text = vbNullString                 'ﾛｯﾄ処置欄：空欄
                txtEvalNum.Text = vbNullString                  'ﾛｯﾄ処置欄：空欄
                txtTakeNum.Text = vbNullString                  'ﾛｯﾄ処置欄：空欄

                txtHoldNum.Enabled = False                      'ﾛｯﾄ処置欄：非活性化
                txtAbandonNum.Enabled = False                   'ﾛｯﾄ処置欄：非活性化
                txtAmendNum.Enabled = False                     'ﾛｯﾄ処置欄：非活性化
                txtCorrectNum.Enabled = False                   'ﾛｯﾄ処置欄：非活性化
                txtUsualNum.Enabled = False                     'ﾛｯﾄ処置欄：非活性化
                txtEvalNum.Enabled = False                      'ﾛｯﾄ処置欄：非活性化
                txtTakeNum.Enabled = False                      'ﾛｯﾄ処置欄：非活性化

                lblStatus.Text = vbNullString                '状態欄を空欄
            Else
            '@引継情報が存在する場合
                With ptypExcpReport
                    For llngCnt = 0 To .lngExcpReportLotListCnt - 1
                        '@一致するﾛｯﾄIDを検索,情報を画面にｾｯﾄ
                        If pstrLotID = .typExcpLotList(llngCnt).strLotID Then
                            '@編集ﾌﾗｸﾞを立てる
                            mblnEditFlag = True
                                            
                            '@情報を画面にｾｯﾄ
                            txtLotID.Text = .typExcpLotList(llngCnt).strLotID                               'ﾛｯﾄID
                            
                            txtTotalNum.Text = .typExcpLotList(llngCnt).strTotalQuantity                    '数量
                            
                            txtHoldNum.Text = .typExcpLotList(llngCnt).strReserveQuantity                   '保留
                            txtAbandonNum.Text = .typExcpLotList(llngCnt).strAbandonQuantity                '廃却
                            txtAmendNum.Text = .typExcpLotList(llngCnt).strAmendQuantity                    '手直し
                            txtCorrectNum.Text = .typExcpLotList(llngCnt).strCorrectQuantity                '修正
                            txtUsualNum.Text = .typExcpLotList(llngCnt).strUsualQuantity                    '通常
                            txtEvalNum.Text = .typExcpLotList(llngCnt).strEvalQuantity                      '評価
                            txtTakeNum.Text = .typExcpLotList(llngCnt).strTakeQuantity                      '特採
                            '合計
                            Dim strTargetQuantityTmp As String = .typExcpLotList(llngCnt).strTargetQuantity
                            If IsNumeric(strTargetQuantityTmp) Then
                                strTargetQuantityTmp = Format$(CLng(.typExcpLotList(llngCnt).strTargetQuantity), CPstrDateFormatKanma)
                            End If
                            lblTotalNum.Text = strTargetQuantityTmp
                            
                            '@状態設定
                            Select Case .typExcpLotList(llngCnt).strDisposalFlag
                                Case CMstrWk            '処置済
                                    lblStatus.Text = CMstrWkJ
                                    
                                Case Else               '未処置
                                    lblStatus.Text = CMstrWkNoJ
                            End Select
                            
                            '@最終更新日時
                            mstrLastUpdate = .typExcpLotList(llngCnt).strEditTime
                            
                            '@編集ﾌﾗｸﾞを初期化
                            mblnEditFlag = False
                            
                            '@処理抜け
                            Exit For
                        End If
                    Next
                    
                    '@状態によるｺﾝﾄﾛｰﾙの活性化処理
                    If lblStatus.Text = CMstrWkJ Then
                        '@各ｺﾝﾄﾛｰﾙを非活性化する
                        txtTotalNum.Enabled = True                         '数量
        '               txtTotalNum.Enabled = False                         '数量

                        '@ﾃｷｽﾄﾎﾞｯｸｽの初期化
        '                txtHoldNum.Enabled = False              'ﾛｯﾄ処置欄：非活性化
        '                txtAbandonNum.Enabled = False           'ﾛｯﾄ処置欄：非活性化
        '                txtAmendNum.Enabled = False             'ﾛｯﾄ処置欄：非活性化
        '                txtCorrectNum.Enabled = False           'ﾛｯﾄ処置欄：非活性化
        '                txtUsualNum.Enabled = False             'ﾛｯﾄ処置欄：非活性化
        '                txtEvalNum.Enabled = False              'ﾛｯﾄ処置欄：非活性化
        '                txtTakeNum.Enabled = False              'ﾛｯﾄ処置欄：非活性化
                        
                        txtLotID.Enabled = False
                        
                        txtHoldNum.Enabled = True               'ﾛｯﾄ処置欄：非活性化
                        txtAbandonNum.Enabled = True            'ﾛｯﾄ処置欄：非活性化
                        txtAmendNum.Enabled = True              'ﾛｯﾄ処置欄：非活性化
                        txtCorrectNum.Enabled = True            'ﾛｯﾄ処置欄：非活性化
                        txtUsualNum.Enabled = True              'ﾛｯﾄ処置欄：非活性化
                        txtEvalNum.Enabled = True               'ﾛｯﾄ処置欄：非活性化
                        txtTakeNum.Enabled = True               'ﾛｯﾄ処置欄：非活性化




                    Else
                        txtLotID.Enabled = True
                        '@各ｺﾝﾄﾛｰﾙを活性化する
                        txtTotalNum.Enabled = True                          '数量

                        '@ﾃｷｽﾄﾎﾞｯｸｽの初期化
                        txtHoldNum.Enabled = True               'ﾛｯﾄ処置欄：非活性化
                        txtAbandonNum.Enabled = True            'ﾛｯﾄ処置欄：非活性化
                        txtAmendNum.Enabled = True              'ﾛｯﾄ処置欄：非活性化
                        txtCorrectNum.Enabled = True            'ﾛｯﾄ処置欄：非活性化
                        txtUsualNum.Enabled = True              'ﾛｯﾄ処置欄：非活性化
                        txtEvalNum.Enabled = True               'ﾛｯﾄ処置欄：非活性化
                        txtTakeNum.Enabled = True               'ﾛｯﾄ処置欄：非活性化
                    End If
                End With
            End If
            
            '@ﾎﾞﾀﾝ制御
            If txtLotID.Text = vbNullString Then
                cmdSave.Enabled = False             '一時保存
                cmdRegist.Enabled = False           '確定
            Else
                '@処置済みの場合
                If lblStatus.Text = CMstrWkJ Then
                    cmdSave.Enabled = False             '入力確定
                    cmdRegist.Enabled = True            '処置決定
                Else
                    cmdSave.Enabled = True              '入力確定
                    cmdRegist.Enabled = True            '処置決定
                End If
            End If
            
            '@編集ﾌﾗｸﾞを初期化
            mblnEditFlag = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00H1_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnExcpLotCheck_Sel
    '機　能：ﾛｯﾄ情報取得
    '引　数：ltypLotList：ﾛｯﾄ情報取得構造体
    '戻り値：True：成功/False：失敗
    '作成日：2005/08/04 (Thu) 17:02:56 S.Deguchi
    '更新日：2005/08/04 (Thu) 17:02:56
    '備　考：
    Private Function prvblnExcpLotCheck_Sel(ByRef ltypLotList As LocalLotList) As Boolean

        Dim lblnAns                 As Boolean              '汎用戻り値
        Dim ltypExcpLotCheckReq     As ExcpCheckLotReq      '要求構造体
        Dim ltypExcpLotCheckAns     As ExcpCheckLotAns      '応答構造体
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ

        Try

            '@初期化
            prvblnExcpLotCheck_Sel = False

            '@要求構造体へ情報をｾｯﾄ
            With ltypExcpLotCheckReq
                .strSbID = ptypExcpReport.strSbID           'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strMsgVer = CMstrexcplotcheckVer           'Msgﾊﾞｰｼﾞｮﾝ
                .strLotID = ltypLotList.strLotID            'ﾛｯﾄID
            End With

            '@情報取得
            lblnAns = pubblnExcpLotCheck_Sel(ltypExcpLotCheckReq, _
                                             ltypExcpLotCheckAns)
            '@結果判定
            If lblnAns = True Then
            '@成功の場合
                '@応答構造体の内容をﾛｰｶﾙ変数へ退避
                With ltypLotList
                    .strCFLotFlag = ltypExcpLotCheckAns.strCFLotFlag            'CFﾛｯﾄﾌﾗｸﾞ
                    .strWFQuantity = ltypExcpLotCheckAns.strWfNum               'WF良品数
                    .strChipQuantity = ltypExcpLotCheckAns.strChipNum           'ﾁｯﾌﾟ良品数
                    .strPdId = ltypExcpLotCheckAns.strPdId                      '機種
                    .strOpID = ltypExcpLotCheckAns.strOpID                      '大工程
                    .strStepID = ltypExcpLotCheckAns.strStepID                  '小工程
                    .strWpID = ltypExcpLotCheckAns.strWpID                      '装置ID
                    .strWpName = ltypExcpLotCheckAns.strWpName                  '装置名
                End With
                
                '@異常処理票の内容から確認
                With ptypExcpReport
                    If .lngExcpReportLotListCnt > 0 Then
                        For llngCnt = 0 To .lngExcpReportLotListCnt - 1
                            '@ﾛｯﾄが存在する場合：処置ﾌﾗｸﾞを取得
                            If .typExcpLotList(llngCnt).strLotID = ltypLotList.strLotID Then
                                ltypLotList.strDispose = .typExcpLotList(llngCnt).strDisposalFlag
                                
                                '@処理抜け
                                Exit For
                            Else
                                ltypLotList.strDispose = CMstrWkNo
                            End If
                        Next llngCnt
                    Else
                        ltypLotList.strDispose = CMstrWkNo
                    End If
                End With
            Else
            '@失敗の場合
                Exit Function
            End If

            '@成功を返す
            prvblnExcpLotCheck_Sel = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnExcpLotCheck_Sel"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnLotCFWFStatus_Chk
    '機　能：比較対象ﾛｯﾄと比較する
    '引　数：ltypLotList：ﾛｯﾄ情報構造体
    '戻り値：True：OK/False：NG
    '作成日：2005/08/04 (Thu) 17:43:02 S.Deguchi
    '更新日：2005/08/04 (Thu) 17:43:02
    '備　考：
    Private Function prvblnLotCFWFStatus_Chk(ByRef ltypLotList As LocalLotList) As Boolean
        
        Try

            '@初期化
            prvblnLotCFWFStatus_Chk = False
            
            '@比較対象ﾛｯﾄと比較
            If mtypLotList.strCFLotFlag <> ltypLotList.strCFLotFlag Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006K)
                
                '@"基板ロットとCFロットを混在して登録することはできません。$設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                Exit Function
            End If
            
            '@成功を返す
            prvblnLotCFWFStatus_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(MenuKey:機能ID/ProcName:ｻﾌﾞﾙｰﾁﾝ・関数名/ErrMessage:ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnLotCFWFStatus_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblncmdRegist_Chk
    '機　能：確定ﾁｪｯｸ
    '引　数：なし
    '戻り値：True：OK/False：NG
    '作成日：2005/08/26 (Fri) 15:07:54 S.Deguchi
    '更新日：2005/08/26 (Fri) 15:07:54
    '備　考：
    Private Function prvblncmdRegist_Chk() As Boolean

        Dim llngNum     As Integer      '対象数量合計

        Try

            '@初期化
            prvblncmdRegist_Chk = False
            
            '@数量が空欄もしくは,"0"の場合には,ﾒｯｾｰｼﾞを表示する
            If txtTotalNum.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0063)
                
                '@"<TRM63W>$$数量が入力されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽを数量欄に
                Call pubSetFocus(txtTotalNum)
                
                Exit Function
            End If
            
            '@数量ﾁｪｯｸ(数量と合計の大小関係を比較)
            '@数量ﾁｪｯｸ：保留
            If IsNumeric(txtHoldNum.Text) = False Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0063)
                
                '@"<TRM63W>$$数量が入力されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽを数量欄に
                Call pubSetFocus(txtHoldNum)
                
                Exit Function
            End If
            
            '@数量ﾁｪｯｸ：廃却
            If IsNumeric(txtAbandonNum.Text) = False Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0063)
                
                '@"<TRM63W>$$数量が入力されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽを数量欄に
                Call pubSetFocus(txtAbandonNum)
                
                Exit Function
            End If
            
            '@数量ﾁｪｯｸ：手直し
            If IsNumeric(txtAmendNum.Text) = False Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0063)
                
                '@"<TRM63W>$$数量が入力されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽを数量欄に
                Call pubSetFocus(txtAmendNum)
                
                Exit Function
            End If
            
            '@数量ﾁｪｯｸ：修正
            If IsNumeric(txtCorrectNum.Text) = False Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0063)
                
                '@"<TRM63W>$$数量が入力されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽを数量欄に
                Call pubSetFocus(txtCorrectNum)
                
                Exit Function
            End If
            
            '@数量ﾁｪｯｸ：通常
            If IsNumeric(txtUsualNum.Text) = False Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0063)
                
                '@"<TRM63W>$$数量が入力されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽを数量欄に
                Call pubSetFocus(txtUsualNum)
                
                Exit Function
            End If
            
            '@数量ﾁｪｯｸ：評価
            If IsNumeric(txtEvalNum.Text) = False Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0063)
                
                '@"<TRM63W>$$数量が入力されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽを数量欄に
                Call pubSetFocus(txtEvalNum)
                
                Exit Function
            End If
            
            '@数量ﾁｪｯｸ：特採
            If IsNumeric(txtTakeNum.Text) = False Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0063)
                
                '@"<TRM63W>$$数量が入力されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾌｫｰｶｽを数量欄に
                Call pubSetFocus(txtTakeNum)
                
                Exit Function
            End If
            
            '@数量計算(数量と合計の大小関係を比較)
            '@初期化
            llngNum = 0
            
            '@数値以外の場合には計算しない：保留
            If IsNumeric(txtHoldNum.Text) = True Then
                llngNum = llngNum + CLng(txtHoldNum.Text)
            Else
                llngNum = llngNum
            End If
            
            '@数値以外の場合には計算しない：廃却
            If IsNumeric(txtAbandonNum.Text) = True Then
                llngNum = llngNum + CLng(txtAbandonNum.Text)
            Else
                llngNum = llngNum
            End If
            
            '@数値以外の場合には計算しない：手直し
            If IsNumeric(txtAmendNum.Text) = True Then
                llngNum = llngNum + CLng(txtAmendNum.Text)
            Else
                llngNum = llngNum
            End If
            
            '@数値以外の場合には計算しない：修正
            If IsNumeric(txtCorrectNum.Text) = True Then
                llngNum = llngNum + CLng(txtCorrectNum.Text)
            Else
                llngNum = llngNum
            End If
            
            '@数値以外の場合には計算しない：通常
            If IsNumeric(txtUsualNum.Text) = True Then
                llngNum = llngNum + CLng(txtUsualNum.Text)
            Else
                llngNum = llngNum
            End If
            
            '@数値以外の場合には計算しない：評価
            If IsNumeric(txtEvalNum.Text) = True Then
                llngNum = llngNum + CLng(txtEvalNum.Text)
            Else
                llngNum = llngNum
            End If
            
            '@数値以外の場合には計算しない：特採
            If IsNumeric(txtTakeNum.Text) = True Then
                llngNum = llngNum + CLng(txtTakeNum.Text)
            Else
                llngNum = llngNum
            End If
            
        '@↓2008/04/07 (Mon) 09:56:05 M.Koni **************************************************
            '@合計値と数量値を比較
            If CLng(txtTotalNum.Text) <> llngNum Then
            '@"数量"と"合計"が一致しない場合
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000X)
                '@"数量と合計の値が一致しません。入力を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@ﾌｫｰｶｽを数量欄に
                Call pubSetFocus(txtTotalNum)

                Exit Function
            End If

        '    '@計算値と数量を比較
        '    If CLng(txtTotalNum.Text) < llngNum Then
        '    '@"数量"以上の場合
        '        '@表示ﾒｯｾｰｼﾞ変換
        '        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar006N)
        '
        '        '@"ロット処置の合計が、数量を超えています。設定を見直してください。"
        '        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxCM00H1.Caption, True, 16)
        '
        '        '@ﾌｫｰｶｽを数量欄に
        '        Call pubSetFocus(txtTotalNum)
        '
        '        Exit Function
        '    End If
        '@↑2008/04/07 (Mon) 09:56:05 M.Koni **************************************************
            
            '@成功を返す
            prvblncmdRegist_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblncmdRegist_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvtxtWkNum_Cal
    '機　能：計算
    '引　数：llngNum：合計戻り値
    '戻り値：なし
    '作成日：2005/08/30 (Tue) 18:26:40 S.Deguchi
    '更新日：2005/08/30 (Tue) 18:26:40
    '備　考：
    Private Sub prvtxtWkNum_Cal(ByRef llngNum As Integer)

        Try

            '@初期化
            llngNum = 0
            
            '@空欄の場合には計算に含めない：保留
            If IsNumeric(txtHoldNum.Text) = True Then
                llngNum = llngNum + CLng(txtHoldNum.Text)
            Else
                llngNum = llngNum
            End If
            
            '@空欄の場合には計算に含めない：廃却
            If IsNumeric(txtAbandonNum.Text) = True Then
                llngNum = llngNum + CLng(txtAbandonNum.Text)
            Else
                llngNum = llngNum
            End If
            
            '@空欄の場合には計算に含めない：手直し
            If IsNumeric(txtAmendNum.Text) = True Then
                llngNum = llngNum + CLng(txtAmendNum.Text)
            Else
                llngNum = llngNum
            End If
            
            '@空欄の場合には計算に含めない：修正
            If IsNumeric(txtCorrectNum.Text) = True Then
                llngNum = llngNum + CLng(txtCorrectNum.Text)
            Else
                llngNum = llngNum
            End If
            
            '@空欄の場合には計算に含めない：通常
            If IsNumeric(txtUsualNum.Text) = True Then
                llngNum = llngNum + CLng(txtUsualNum.Text)
            Else
                llngNum = llngNum
            End If
            
            '@空欄の場合には計算に含めない：評価
            If IsNumeric(txtEvalNum.Text) = True Then
                llngNum = llngNum + CLng(txtEvalNum.Text)
            Else
                llngNum = llngNum
            End If
            
            '@空欄の場合には計算に含めない：特採
            If IsNumeric(txtTakeNum.Text) = True Then
                llngNum = llngNum + CLng(txtTakeNum.Text)
            Else
                llngNum = llngNum
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvtxtWkNum_Cal"
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraWk.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub

End Class
