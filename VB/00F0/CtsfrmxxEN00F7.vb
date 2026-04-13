'ﾌｧｲﾙ名：xxEN00F7.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：CF在庫処置(在庫管理サブフォーム)
'作成日：2004/12/06 (Mon) 15:55:34 S.Deguchi
'更新日：2011/12/21 (Wed) 16:55:22 T.Oide
'備　考：2011/12/21 (Wed) 16:55:22 T.Oide　REQ-1115の対応で[CF在庫払出]→[CF在庫処置]に名称変更
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00F7
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00F7    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00F7
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00F7
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00F7)
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
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN00F7          'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_reasoncodeVer        As String = "02.00"                 '理由ｺｰﾄﾞ取得
    '@↓2012/01/12 (Thu) 15:15:02 T.Oide **************************************************
    '@Private Const CMstrinv_cfforwardVer         As String = "01.00"                 'CF在庫払出
    Private Const CMstrinv_cfforwardVer         As String = "02.00"                 'CF在庫処置
    '@↑2012/01/12 (Thu) 15:15:02 T.Oide **************************************************

    '@保留理由ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize              As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize          As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridColHoldName       As Integer = 0                      '保留理由列番
    Private Const CMlngCmbGridColHoldID         As Integer = 1                      '保留理由ID列番(非表示項目)
    Private Const CMlngCmbDispCols              As Integer = 1                      'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbValueCols             As Integer = 1                      'ｺﾝﾎﾞﾎﾞｯｸｽ値取得列数
    Private Const CMlngCmbRowHeight             As Integer = 18                     'ﾘｽﾄ行の高さ

    '@定数宣言
    Private Const CMstrFormat0                  As String = "0"                     '(=0)定数宣言

    '@↓2012/01/12 (Thu) 15:09:17 T.Oide **************************************************
    '@ｲﾍﾞﾝﾄ区分
    Private Const CMstrEventIssue               As String = "37"                    '37：CF在庫払出
    Private Const CMstrEventScrap               As String = "97"                    '97：CF在庫不良
    '@↑2012/01/12 (Thu) 15:09:17 T.Oide **************************************************

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    Private mtypMasItemList                     As MasItemList                      '払出理由構造体
    '@↓2012/01/06 (Fri) 15:04:21 T.Oide **************************************************
    Private mtypMasScrapItemList                As MasItemList                      '在庫不良理由構造体
    '@↑2012/01/06 (Fri) 15:04:21 T.Oide **************************************************
    Private mstrLastUpdate                      As String                           '最終更新日時
    Private mstrScrapItemID                     As String                           '払出理由ｺｰﾄﾞ
    Private mstrScrapItemName                   As String                           '払出理由名
    Private mstrChipQuantity                    As String                           'ﾁｯﾌﾟ現在数量
    Private mblnFormLoadFlag                    As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True：起動時以外/False：起動時のみ)
    '@↓2012/01/06 (Fri) 15:25:01 T.Oide **************************************************
    Private mblnEventCancelFlag                 As Boolean                          'ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞ
    '@↑2012/01/06 (Fri) 15:25:01 T.Oide **************************************************
    Private buttonProcessing                    As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                          'NSYS WindowCloseフラグ
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
    '作成日：2004/12/06 (Mon) 15:56:01 S.Deguchi
    '更新日：2012/01/06 (Fri) 15:02:13 T.Oide
    '備　考：
    Private Sub Form_Load()

        Dim lstrFormName        As String           'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lblnAns             As Boolean          'ﾛｯﾄ保留理由取得戻り値(True/False)

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "Form_Load"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@画面初期化
            Call prvfrmxxEN00F7_Init()
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False
            
            '@払出理由取得結果
            lblnAns = pubblnMasResonCode_Sel(CMstrmas_reasoncodeVer, _
                                             CPstrCD2V, _
                                             mtypMasItemList)
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            
        '@↓2012/01/06 (Fri) 15:02:38 T.Oide **************************************************
            '@払出理由取得結果
            lblnAns = pubblnMasResonCode_Sel(CMstrmas_reasoncodeVer, _
                                             CPstrCD4Q, _
                                             mtypMasScrapItemList)
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
        '@↑2012/01/06 (Fri) 15:02:38 T.Oide **************************************************
            

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
    '機　能：ﾌｫｰﾑｱｸﾃｨﾍﾞｲﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/07 (Thu) 08:32:38 S.Deguchi
    '更新日：2005/07/07 (Thu) 08:32:38
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理分岐
            If mblnFormLoadFlag = False Then
                '@ﾌﾗｸﾞを戻す
                mblnFormLoadFlag = True
                    
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                    
                '@理由Combo設定
                Call prvcmbMasPutList_Disp()
                
                '@画面表示処理
                Call prvfrmxxEN00F7_Disp()
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
    '作成日：2004/12/06 (Mon) 15:56:17 S.Deguchi
    '更新日：2004/12/06 (Mon) 15:56:17
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If

            '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙによる処理分岐
            Select Case ActiveControl.Name
                Case cmbMasPut.Name
                '@払出理由の場合
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler cmbMasPut.Validating, AddressOf cmbMasPut_Validate
                            Call cmbMasPut_Validate(cmbMasPut,New CancelEventArgs(True))
                            AddHandler cmbMasPut.Validating, AddressOf cmbMasPut_Validate
                    End Select
                
                Case txtScrapNum.Name
                '@払出数量の場合
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler txtScrapNum.Validating, AddressOf txtScrapNum_Validate
                            Call txtScrapNum_Validate(txtScrapNum,New CancelEventArgs(True))
                            AddHandler txtScrapNum.Validating, AddressOf txtScrapNum_Validate
                    End Select
                    
                Case Else
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@次項目へﾌｫｰｶｽｾｯﾄ
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
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

    '関数名：Form_QueryUnload
    '機　能：ﾌｫｰﾑ終了前処理
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 15:57:01 S.Deguchi
    '更新日：2004/12/06 (Mon) 15:57:01
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            '@ﾓｼﾞｭｰﾙ変数構造体の初期化
            If mtypMasItemList.typeMasItem Is Nothing Then
                mtypMasItemList.typeMasItem = New List(Of MasItem)
            Else
                mtypMasItemList.typeMasItem.Clear
            End If
            If mtypMasScrapItemList.typeMasItem Is Nothing Then
                mtypMasScrapItemList.typeMasItem = New List(Of MasItem)
            Else
                mtypMasScrapItemList.typeMasItem.Clear
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

    '関数名：cmbMasPut_Change
    '機　能：払出理由ｺﾝﾎﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 15:56:37 S.Deguchi
    '更新日：2012/01/06 (Fri) 15:22:55 T.Oide
    '備　考：
    Private Sub cmbMasPut_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMasPut.Change
        
        Dim lblnAns As Boolean      '汎用戻り値

        Try

        '@↓2012/01/06 (Fri) 15:23:28 T.Oide **************************************************
            '@ｺﾝﾎﾞのﾘｽﾄをｸﾘｱする場合は処理しない
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
        '@↑2012/01/06 (Fri) 15:23:28 T.Oide **************************************************

            '@画面項目ﾁｪｯｸ
            lblnAns = prvblnInput_Chk
            '@結果判定
            If lblnAns = False Then
                '@確定ﾎﾞﾀﾝを非活性化
                cmdRegist.Enabled = False
            Else
                '@確定ﾎﾞﾀﾝを活性化
                cmdRegist.Enabled = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMasPut_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMasPut_CloseUp
    '機　能：払出理由ｺﾝﾎﾞCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 15:56:50 S.Deguchi
    '更新日：2004/12/06 (Mon) 15:56:50
    '備　考：
    Private Sub cmbMasPut_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbMasPut.CloseUp

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

             '@Validate処理へ
            RemoveHandler cmbMasPut.Validating,AddressOf cmbMasPut_Validate
            Call cmbMasPut_Validate(cmbMasPut,New CancelEventArgs(True))
            AddHandler cmbMasPut.Validating,AddressOf cmbMasPut_Validate

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMasPut_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbMasPut_Validate
    '機　能：払出理由ｺﾝﾎﾞValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/12/07 (Tue) 16:41:09 S.Deguchi
    '更新日：2004/12/07 (Tue) 16:41:09
    '備　考：
    Private Sub cmbMasPut_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbMasPut.Validating

        Dim lblnAns As Boolean  '汎用結果格納

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            With cmbMasPut
                If .Text = vbNullString Then
                    '@空欄の場合には空欄をｾｯﾄ
                    mstrScrapItemID = vbNullString
                    mstrScrapItemName = vbNullString
                Else
                    '@払出理由IDを格納
                    .ValueCol = CMlngCmbValueCols
                    mstrScrapItemID = .Value
                    mstrScrapItemName = .Text
                End If
            End With
            
            '@ﾌｫｰｶｽ処理
            If ActiveControl.Name = cmbMasPut.Name Then
                Call pubSetFocus(txtScrapNum)
            End If
            
            '@画面項目ﾁｪｯｸ
            lblnAns = prvblnInput_Chk
            '@結果判定
            If lblnAns = False Then
                '@確定ﾎﾞﾀﾝを非活性化
                cmdRegist.Enabled = False
            Else
                '@確定ﾎﾞﾀﾝを活性化
                cmdRegist.Enabled = True
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbMasPut_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtScrapNum_Change
    '機　能：払出数量変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/07 (Tue) 16:46:27 S.Deguchi
    '更新日：2004/12/07 (Tue) 16:46:27
    '備　考：
    Private Sub txtScrapNum_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtScrapNum.Change

        Dim lblnAns As Boolean  '汎用結果格納

        Try
            
            '@空欄以外の場合は画面項目ﾁｪｯｸ
            If txtScrapNum.Text <> vbNullString Then
                '@画面項目ﾁｪｯｸ
                lblnAns = prvblnInput_Chk
                '@結果判定
                If lblnAns = False Then
                    '@確定ﾎﾞﾀﾝを非活性化
                    cmdRegist.Enabled = False
                Else
                    '@確定ﾎﾞﾀﾝを活性化
                    cmdRegist.Enabled = True
                End If
            Else
                cmdRegist.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtScrapNum_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtScrapNum_Validate
    '機　能：払出数量入力Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/12/07 (Tue) 16:46:01 S.Deguchi
    '更新日：2004/12/07 (Tue) 16:46:01
    '備　考：
    Private Sub txtScrapNum_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtScrapNum.Validating

        Dim lblnAns As Boolean  '汎用結果格納
        Dim llngNum As Integer  '数値

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@空欄以外の場合は画面項目ﾁｪｯｸ
            If txtScrapNum.Text <> vbNullString Then
            '@現在数量と計算
                '@入力した値が数値の場合
                If IsNumeric(txtScrapNum.Text) = True Then
                    llngNum = CLng(mstrChipQuantity) - CLng(txtScrapNum.Text)
                    '@計算値がﾏｲﾅｽの場合には,ﾌｫｰｶｽを動かさない
                    If llngNum < 0 Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar004K)
                    
                        '@"現在数量より小さい値を入力してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ﾌｫｰｶｽそのまま
                        e.Cancel = True
                        
                        '@引継いだ現在数量を表示
                        lblNowNum.Text = Format(CLng(mstrChipQuantity), CPstrDateFormatKanma)
                        
                        '@ﾊｲﾗｲﾄ表示
                        Call pubHighlight(txtScrapNum)
                        
                        '@確定ﾎﾞﾀﾝを非活性化
                        cmdRegist.Enabled = False
                        
                        Exit Sub
                    Else
                        '@ﾗﾍﾞﾙに値をｾｯﾄ
                        lblNowNum.Text = Format(CLng(llngNum), CPstrDateFormatKanma)
                    End If
                End If
            Else
                '@"0"をｾｯﾄ
                txtScrapNum.Text = CMstrFormat0
            End If

            '@画面項目ﾁｪｯｸ
            lblnAns = prvblnInput_Chk
            '@結果判定
            If lblnAns = False Then
                '@確定ﾎﾞﾀﾝを非活性化
                cmdRegist.Enabled = False
                If ActiveControl.Name = txtScrapNum.Name Then
                    '@閉じるﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdClose)
                End If
            Else
                '@確定ﾎﾞﾀﾝを活性化
                cmdRegist.Enabled = True
                If ActiveControl.Name = txtScrapNum.Name Then
                    '@確定ﾎﾞﾀﾝへﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(cmdRegist)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtScrapNum_Validate"
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
    '作成日：2004/12/06 (Mon) 15:57:19 S.Deguchi
    '更新日：2004/12/06 (Mon) 15:57:19
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

    '関数名：cmdRegist_Click
    '機　能：確定処理
    '引　数：なし
    '戻り値：なり
    '作成日：2004/12/06 (Mon) 15:57:30 S.Deguchi
    '更新日：2004/12/27 (Mon) 13:15:44 S.Deguchi
    '備　考：
    '　　　：2005/01/11 (Tue) 15:55:11 S.Deguchi    完了ﾒｯｾｰｼﾞ表示
    '　　　：2012/01/12 (Thu) 15:00:45 T.Oide       REQ-1115 不良と払出の区分
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnAns                 As Boolean          '登録戻り値(True/False)
        Dim lstrFormName            As String           'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypInvCFForward        As InvCFForward     '要求構造体

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
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
                '@未入力の場合、処理中止
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "cmdRegist_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@送信ﾒｯｾｰｼﾞを構造体にｾｯﾄする
            With ltypInvCFForward
                .strSbID = pstrSBID                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strMsgVer = CMstrinv_cfforwardVer      'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                .strLotID = lblLotID.Text            'ﾛｯﾄID
                .strReasonCode = mstrScrapItemID        '理由ｺｰﾄﾞ
                .strReasonName = mstrScrapItemName      '理由名
                .strChipNum = txtScrapNum.Text          '払出数量
                .strEmpID = pstrUserID                  '作業者ID
                
        '@↓2012/01/12 (Thu) 15:03:58 T.Oide **************************************************
                '@処理区分設定
                If optKubun0.Checked = True Then
                    .strEventClass = CMstrEventScrap                   'CF在庫不良
                Else
                    .strEventClass = CMstrEventIssue                   'CF在庫払出
                End If
        '@↑2012/01/12 (Thu) 15:03:58 T.Oide **************************************************
                
            End With
            
            '@送信ﾒｯｾｰｼﾞを送る
            lblnAns = pubblnInvCFForward_Upd(ltypInvCFForward)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@異常の場合終了
                Exit Sub
            End If
            
            '@完了ﾒｯｾｰｼﾞを表示
            If lblNowNum.Text = CMstrFormat0 Then
            '@全数払出の場合
                '@ﾒｯｾｰｼﾞ表示"<TRM3SI>$$在庫払出を行い、ロット終了しました。キャリア[%1] ロット[%2]"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003S, lblCarrier.Text, lblLotID.Text)
                
                '@成功ﾒｯｾｰｼﾞ表示
                Call pubVsfInfo_Disp(pstrDMsg)
            Else
            '@全数以外の場合
                '@ﾒｯｾｰｼﾞ表示"<TRM70I>$$ 在庫払出をしました。キャリア[%1] ロット[%2]"
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf003X, lblCarrier.Text, lblLotID.Text)
                
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

    '@↓2012/01/06 (Fri) 13:34:48 T.Oide **************************************************
    '関数名：optKubun_Click
    '機　能：オプションボタンチェック時に処置理由のリストを切り替える
    '引　数：Index：0：不良、1：払出
    '戻り値：なし
    '作成日：2012/01/06 (Fri) 13:33:18 T.Oide
    '更新日：2012/01/06 (Fri) 13:33:18
    '備　考：
    Private Sub optKubun_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optKubun0.CheckedChanged,optKubun1.CheckedChanged
        
        Try
            
            If sender.Checked = False Then
                Exit Sub
            End If

            '@理由コード設定
            Call prvsubReasonSet()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optKubun_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub
    '@↑2012/01/06 (Fri) 13:34:48 T.Oide **************************************************

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================

    '関数名：prvfrmxxEN00F7_Init
    '機　能：ﾒｲﾝﾌｫｰﾑ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/12/06 (Mon) 15:59:26 S.Deguchi
    '更新日：2012/01/06 (Fri) 15:11:21 T.Oide
    '備　考：
    Private Sub prvfrmxxEN00F7_Init()

        Try
            
            '@内部変数を初期化
            mstrScrapItemID = vbNullString
            mstrScrapItemName = vbNullString
            mstrChipQuantity = vbNullString
        '@↓2012/01/06 (Fri) 15:26:26 T.Oide **************************************************
            mblnEventCancelFlag = False
        '@↑2012/01/06 (Fri) 15:26:26 T.Oide **************************************************

            '@初期値設定
            cmdRegist.Enabled = False
            
            '@ﾗﾍﾞﾙの初期化
            lblCarrier.Text = vbNullString               'ｷｬﾘｱID
            lblLotID.Text = vbNullString                 'ﾛｯﾄID
            lblFlowClass.Text = vbNullString             '流動区分
            
            '@ﾃｷｽﾄﾎﾞｯｸｽの初期表示
            txtScrapNum.Text = CMstrFormat0
            
        '@↓2012/01/06 (Fri) 15:11:14 T.Oide **************************************************
            '@オプションボタン初期化
            optKubun0.Checked = True
            optKubun1.Checked = False
        '@↑2012/01/06 (Fri) 15:11:14 T.Oide **************************************************
            
            '@終了時にValidateｲﾍﾞﾝﾄを実行しない
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN00F7_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN00F7_Disp
    '機　能：引継ぎ情報表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/02 (Fri) 17:20:55 N.Kasai
    '更新日：2012/01/19 (Thu) 14:55:05 T.Oide
    '備　考：
    Private Sub prvfrmxxEN00F7_Disp()

        Dim llngLenCount    As Integer      'ﾁｯﾌﾟ桁数

        Try
            
            '@引継ぎ情報の表示
            With ptypHoldConnect
                lblCarrier.Text = .strCarrierId                                          'ｷｬﾘｱID
                lblLotID.Text = .strLotID                                                'ﾛｯﾄID
                lblFlowClass.Text = .strFlowClass                                        '流動区分
                mstrLastUpdate = .strLastUpdate                                          '最終更新日時
                lblNowNum.Text = Format(CLng(.strChipQuantity), CPstrDateFormatKanma)    'ﾁｯﾌﾟ数量
                mstrChipQuantity = .strChipQuantity                                      'ﾁｯﾌﾟ数量(内部変数)
                 
                 
                '@Max桁数の設定
                llngLenCount = Len(.strChipQuantity)
                txtScrapNum.ChrMaxByte = llngLenCount
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN00F7_Disp"
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
    '作成日：2004/06/30 (Wed) 13:35:43 N.Kasai
    '更新日：2004/06/30 (Wed) 13:35:43
    '備　考：
    Private Function prvblnInput_Chk() As Boolean

        Try
            
            '@初期化
            prvblnInput_Chk = False
            
            '@払出理由のﾁｪｯｸ
            If cmbMasPut.Text = vbNullString Then
                Exit Function
            End If
            
            '@払出数量の入力ﾁｪｯｸ
            If txtScrapNum.Text = vbNullString Then
                Exit Function
            Else
                '@払出数量の数値ﾁｪｯｸ
                If IsNumeric(txtScrapNum.Text) = False Then
                    Exit Function
                Else
                    '@「0」はNG
                    If txtScrapNum.Text = CMstrFormat0 Then
                        Exit Function
                    End If
                End If
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

    '関数名：prvcmbMasPutList_Disp
    '機　能：払出理由Combo表示
    '引　数：なし
    '戻り値：なし
    '作成日：2005/07/07 (Thu) 10:05:27 S.Deguchi
    '更新日：2012/01/06 (Fri) 13:39:30 T.Oide
    '備　考：
    Private Sub prvcmbMasPutList_Disp()
                
        Try
                    
            '@払出理由ｾｯﾄ
            With cmbMasPut
                .Clear
                .DispCols = CMlngCmbDispCols                                        'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridColHoldName                                   'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbValueCols                                       '値取得列
                .DirectInput = False                                                '直接入力不可
                .Text = vbNullString                                                '初期化
                With .Font                                                          'ﾌｫﾝﾄｻｲｽﾞ
                    cmbMasPut.Font = New Font(.FontFamily, CMlngCmbFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                With .GridFont                                                      'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    cmbMasPut.GridFont = New Font(.FontFamily, CMlngCmbGridFontSize, .Style, _
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                .RowHeight = CMlngCmbRowHeight                                      '行の高さ
                .ColAlignment(CMlngCmbGridColHoldName) = TextAlignEnum.LeftCenter   '左寄中央揃え
            
        '@↓2012/01/06 (Fri) 13:39:12 T.Oide **************************************************
                '@理由のﾘｽﾄ設定
                Call prvsubReasonSet()
                
        '@        For llngCnt = 1 To mtypMasItemList.lngListCnt
        '@            .AddItem mtypMasItemList.typeMasItem(llngCnt).strItemName & _
        '@                     vbTab & _
        '@                     mtypMasItemList.typeMasItem(llngCnt).strItemID         '払出名称&払出ID
        '@        Next llngCnt
        '@↑2012/01/06 (Fri) 13:39:12 T.Oide **************************************************
                
                '@理由が1件の場合デフォルトで表示
                If .ListCount = 1 Then
                    '@1件目表示
                    .ListIndex = 0
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbMasPutList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2012/01/06 (Fri) 13:41:45 T.Oide **************************************************
    '関数名：prvsubReasonSet
    '機　能：理由のリストを設定する
    '引　数：
    '戻り値：
    '作成日：2012/01/06 (Fri) 13:41:21 T.Oide
    '更新日：2012/01/06 (Fri) 13:41:21
    '備　考：
    Private Sub prvsubReasonSet()

        Dim llngCnt             As Integer
        Dim ltypMasItemList     As MasItemList


        Try
            
            '@不良のチェックがONか
            If optKubun0.Checked = True Then
            
                '@不良のリストを設定
                ltypMasItemList = mtypMasScrapItemList
            
            Else
            
                '@払出のリストを設定
                ltypMasItemList = mtypMasItemList
            
            End If
            
            
            '@一旦コンボのリストをクリア
            mblnEventCancelFlag = True
            cmbMasPut.Clear
            mblnEventCancelFlag = False
            
            '@コンボにリストを設定
            With ltypMasItemList
            
                For llngCnt = 0 To .lngListCnt -1
                
                    With .typeMasItem(llngCnt)
                    
                        cmbMasPut.AddItem(.strItemName & vbTab & .strItemID)     '「名称」と「ID」を設定
                        
                    End With
                    
                Next llngCnt

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvsubReasonSet"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2012/01/06 (Fri) 13:41:45 T.Oide **************************************************


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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraFrame.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub

    '関数名：cursor_Enter
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考：Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles _
                                                                        optKubun1.Enter,
                                                                        optKubun1.Enter,
                                                                        cmdClose.Enter,
                                                                        cmdRegist.Enter,
                                                                        txtScrapNum.Enter,
                                                                        cmbMasPut.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '閉じるボタンの場合は自動Validate = OFF
            Case cmdClose.Name
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
            '上記以外は自動Validate = ON
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

End Class
