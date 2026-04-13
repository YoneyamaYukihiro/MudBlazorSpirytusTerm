'ﾌｧｲﾙ名：xxEN01V1.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：装置使用部材登録/分割
'作成日：2006/04/12 (Wed) 15:23:14 N.Kojima
'更新日：2018/06/28 (Thu) 13:20:59 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2003-2018, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01V1
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01V1    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01V1
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01V1
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01V1)
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
    Private Const CMstrLocalMenuKey                 As String = CPstrKeyEN01V1              'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmat_ordermaterialVer         As String = "02.00"                     '装置使用部材発注
    Private Const CMstrmat_regmaterialVer           As String = "02.00"                     '装置使用部材登録
    Private Const CMstrmat_chgmaterialdateVer       As String = "01.00"                     '装置使用部材日付変更

    '@Msg用定数
    Private Const CMstrRegist                       As String = "登録"                      '登録用定数
    Private Const CMstrDivide                       As String = "分割"                      '分割用定数
    Private Const CMstrProductDate                  As String = "製造日"                    '日付ﾁｪｯｸ時Msg用定数(未来ﾁｪｯｸ)
    Private Const CMstrAcceptDate                   As String = "受入日"                    '日付ﾁｪｯｸ時Msg用定数(過去ﾁｪｯｸ)
    Private Const CMstrStartUseDate                 As String = "使用開始日時"              '日付ﾁｪｯｸ時Msg用定数(未来ﾁｪｯｸ)
    Private Const CMstrFutureDays                   As String = "未来"                      '日付ﾁｪｯｸ時Msg用定数(未来ﾁｪｯｸ)
    Private Const CMstrPastDays                     As String = "過去"                      '日付ﾁｪｯｸ時Msg用定数(過去ﾁｪｯｸ)
    Private Const CMstrSameDay                      As String = "同日"                      '日付ﾁｪｯｸ時Msg用定数(同日ﾁｪｯｸ)

    '@ﾗﾍﾞﾙﾀｲﾄﾙ用
    Private Const CMstrAcceptPlanDate               As String = "受入予定日"                'ｷｬﾌﾟｼｮﾝ

    '@ｶﾗｰ
    Private Const CMlngGlayColor                    As Integer = &H80000004                 '灰色

    '@↓2018/06/28 (Thu) 14:53:59 T.Oide **************************************************
    '@一覧ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCMbSelectMode                As Integer = 1                          '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
    Private Const CMstrCmbAddedComment              As String = " 項目選択"                 '表示 文字列
    Private Const CMstrCmbAddedCommentNone          As String = "0 項目選択"                '未選択表示
    Private Const CMlngCmbGridCol0                  As Integer = 0                          '選択列数
    Private Const CMstrCmbCheckOff                  As String = "0"                         'ﾁｪｯｸOFF
    Private Const CMstrCmbCheckOn                   As String = "1"                         'ﾁｪｯｸON
    Private Const CMlngCmbDispCols                  As Integer = 1                          'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbFontSize                  As Integer = 14                         'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 14                         'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbRowHeight                 As Integer = 30                         'ﾘｽﾄ行の高さ
    '@↑2018/06/28 (Thu) 14:53:59 T.Oide **************************************************

    '@ﾚｽﾎﾟﾝｽ計測用
    Private Const CMstrFormName                     As String = "frmxxEN01V1"               '自ﾌｫｰﾑ名
    Private Const CMstrFormLoad                     As String = "Form_Load"                 'ｲﾍﾞﾝﾄ名定数(ﾌｫｰﾑﾛｰﾄﾞ)
    Private Const CMstrCmdRegistClick               As String = "cmdRegist_Click"           'ｲﾍﾞﾝﾄ名定数(確定)
    Private Const CMstrPrvblnAuthorityChk           As String = "prvblnAuthority_Chk"       'ｲﾍﾞﾝﾄ名定数(権限ﾁｪｯｸ)

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Public===========================================
    Private mstrLastUpdate                          As String                           '最終更新日時
    Private mstrStartKbn                            As String                           '起動区分(1=受入,2=分割,3=部材日時変更,4=発注)
    Private mblnFormLoadFlag                        As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True：起動時以外/False：起動時のみ)

    Private buttonProcessing                        As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                          'NSYS WindowCloseフラグ

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
        medTime.Tag = New Hashtable() From {{"OnHighlight", False}, {"MouseDownStart", 0}}
        Form_Load()
        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '***************************************************************************************
    '                              *イベントハンドラの記述*
    '***************************************************************************************
    '====================================Private============================================

    '関数名：Form_Load
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 15:41:50 N.Kojima
    '更新日：2006/10/24 (Tue) 11:45:46 N.Kojima
    '備　考：
    '　　　：2006/10/24 (Tue) 11:45:46 N.Kojima     部材の在庫ﾁｪｯｸ・発注管理機能追加に伴い、処理追加&修正。(案件№01095)
    Private Sub Form_Load()

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
             Me.CancelButton = Nothing
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            mblnFormLoadFlag = False
            
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
    '機　能：ﾌｫｰﾑｱｸﾃｨﾌﾞ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/18 (Tue) 09:10:28 N.Kojima
    '更新日：2006/10/24 (Tue) 11:30:19 N.Kojima
    '備　考：
    '　　　：2006/06/22 (Thu) 19:21:42 N.Kojima     起動区分処理修正。(ﾕｰｻﾞｰ要望№0189)
    '　　　：2006/10/24 (Tue) 11:30:19 N.Kojima     部材の在庫ﾁｪｯｸ・発注管理機能追加に伴い、処理追加&修正。(案件№01095)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理分岐
            If mblnFormLoadFlag = False Then
                '@ﾌﾗｸﾞを戻す
                mblnFormLoadFlag = True
                    
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                                
                '@起動区分の設定
                Select Case Me.Text
                    
                    '@分割での起動の場合
                    Case CPstrSubFormDivid
                        '@分割起動区分="2"を設定
                        mstrStartKbn = CPstrTwo
                        
                    '@受入での起動の場合
                    Case CPstrSubFormRegist
                        '@受入区分="1"を設定
                        mstrStartKbn = CPstrOne
                    
                    '@日付変更での起動の場合
                    Case CPstrSubFormDateChg
                        '@日付変更区分="3"を設定
                        mstrStartKbn = CPstrThree
                        
                    '@発注での起動の場合
                    Case CPstrSubFormOrder
                        '@発注区分="4"を設定
                        mstrStartKbn = CPstrFour
                
                End Select
                        
                '@画面初期化
                Call prvfrmxxEN01V1_Init()
                
                '@画面表示処理
                Call prvfrmxxEN01V1_Disp()
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
    '機　能：ｷｰ制御処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2006/04/18 (Tue) 09:13:54 N.Kojima
    '更新日：2018/06/28 (Thu) 13:25:02 T.Oide
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
                   
        '@↓2018/06/28 (Thu) 13:24:32 T.Oide **************************************************
        '@        Case txtOrderID.Name
        '@            '@発注IDの場合
        '@            Select Case KeyCode
        '@                '@Enterｷｰの場合
        '@                Case vbKeyReturn
        '@                    '@Validate処理へ
        '@                    Call txtOrderID_Validate(False)
        '@                    KeyCode = 0
        '@            End Select
        '@------------------------------------------------------------------------------------

                 Case cmbOrderID.Name
                    '@発注IDの場合
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler cmbOrderID.Validating, AddressOf cmbOrderID_Validate
                            Call cmbOrderID_Validate(cmbOrderID, New CancelEventArgs(False))
                            AddHandler cmbOrderID.Validating, AddressOf cmbOrderID_Validate
                            e.Handled = True
                    End Select
        '@↑2018/06/28 (Thu) 13:24:32 T.Oide **************************************************
                 
                Case txtMaterialLotID.Name
                    '@部材管理IDの場合
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler txtMaterialLotID.Validating, AddressOf txtMaterialLotID_Validate
                            Call txtMaterialLotID_Validate(txtMaterialLotID, New CancelEventArgs(False))
                            AddHandler txtMaterialLotID.Validating, AddressOf txtMaterialLotID_Validate
                            e.Handled = True
                    End Select
                    
                Case txtConsecutiveNum.Name
                    '@連番の場合
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler txtConsecutiveNum.Validating, AddressOf txtConsecutiveNum_Validate
                            Call txtConsecutiveNum_Validate(txtConsecutiveNum, New CancelEventArgs(False))
                            AddHandler txtConsecutiveNum.Validating, AddressOf txtConsecutiveNum_Validate
                            e.Handled = True
                    End Select
                    
                Case calProductDate.Name
                    '@製造日の場合
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler calProductDate.Validating, AddressOf calProductDate_Validate
                            Call calProductDate_Validate(calProductDate, New CancelEventArgs(False))
                            AddHandler calProductDate.Validating, AddressOf calProductDate_Validate
                            e.Handled = True
                    End Select
                    
                Case calAcceptDate.Name
                    '@受入日の場合
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler calAcceptDate.Validating, AddressOf calAcceptDate_Validate
                            Call calAcceptDate_Validate(calAcceptDate, New CancelEventArgs(False))
                            AddHandler calAcceptDate.Validating, AddressOf calAcceptDate_Validate
                            e.Handled = True
                    End Select
                        
                Case calStartUseDate.Name
                    '@使用開始日時(年月日)の場合
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler calStartUseDate.Validating, AddressOf calStartUseDate_Validate
                            Call calStartUseDate_Validate(calStartUseDate, New CancelEventArgs(False))
                            AddHandler calStartUseDate.Validating, AddressOf calStartUseDate_Validate
                            e.Handled = True
                    End Select
                
                Case medTime.Name
                    '@使用開始日時(時間)の場合
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@Validate処理へ
                            RemoveHandler medTime.Validating, AddressOf medTime_Validate
                            Call medTime_Validate(medTime, New CancelEventArgs(False))
                            AddHandler medTime.Validating, AddressOf medTime_Validate
                            e.Handled = True
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
    '作成日：2006/04/18 (Tue) 09:19:25 N.Kojima
    '更新日：2006/04/18 (Tue) 09:19:25
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try
            
            '@ﾓｼﾞｭｰﾙ変数構造体の初期化
            mstrStartKbn = vbNullString
            
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

    '@↓2018/06/28 (Thu) 13:49:15 T.Oide **************************************************
    '@'関数名：txtOrderID_Change
    '@'機　能：発注ID変更処理
    '@'引　数：なし
    '@'戻り値：なし
    '@'作成日：2006/10/24 (Tue) 12:10:04 N.Kojima
    '@'更新日：2006/10/24 (Tue) 12:10:04
    '@'備　考：
    '@Private Sub txtOrderID_Change()
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    '@発注での起動の場合
    '@    If mstrStartKbn = CPstrFour Then
    '@        '@受入日,発注IDが入力されているか
    '@        If txtOrderID.Text <> vbNullString And calAcceptDate.Value <> CPstrNullDate Then
    '@
    '@            '@確定ﾎﾞﾀﾝを有効にする
    '@            cmdRegist.Enabled = True
    '@        Else
    '@            '@確定ﾎﾞﾀﾝを無効にする
    '@            cmdRegist.Enabled = False
    '@        End If
    '@    End If
    '@
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey
    '@        .strProcName = "txtOrderID_Change"
    '@        .strErrMessage = vbNullString
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Sub
    '@↑2018/06/28 (Thu) 13:49:15 T.Oide **************************************************

    '関数名：cmbOrderID_Change
    '機　能：発注ID変更処理
    '引　数：なし
    '戻り値：
    '作成日：2018/06/28 (Thu) 13:26:41 T.Oide
    '更新日：2018/06/28 (Thu) 13:26:41
    '備　考：
    Private Sub cmbOrderID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbOrderID.Change

        Try
            
            '@発注での起動の場合
            If mstrStartKbn = CPstrFour Then
                '@受入日,発注IDが入力されているか
                If cmbOrderID.Text <> vbNullString And calAcceptDate.Value <> CPstrNullDate Then
                    
                    '@確定ﾎﾞﾀﾝを有効にする
                    cmdRegist.Enabled = True
                Else
                    '@確定ﾎﾞﾀﾝを無効にする
                    cmdRegist.Enabled = False
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbOrderID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2018/06/28 (Thu) 13:49:39 T.Oide **************************************************
    '@'関数名：txtOrderID_KeyUp
    '@'機　能：発注IDﾃｷｽﾄのｷｰUP時処理
    '@'引　数：KeyCode：ｷｰｺｰﾄﾞ
    '@'　　　：Shift  ：ｼﾌﾄｺｰﾄﾞ
    '@'戻り値：なし
    '@'作成日：2006/10/24 (Tue) 13:16:24 N.Kojima
    '@'更新日：2006/10/24 (Tue) 13:16:24
    '@'備　考：
    '@Private Sub txtOrderID_KeyUp(KeyCode As Integer, Shift As Integer)
    '@
    '@    Dim llngCount               As Long         'ｶｳﾝﾀ
    '@    Dim llngPlusMoji            As Long         'ﾌﾟﾗｽ文字数ｶｳﾝﾀ
    '@    Dim lstrSearchString        As String       '検索文字格納用
    '@    Dim lstrChangeString        As String       '変換前の文字列格納用
    '@    Dim lstrNewChangeString     As String       '変換後の文字列格納用
    '@    Dim lstrNextString          As String       '次文字格納用
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    '@Enterｷｰ押下か
    '@    If KeyCode = vbKeyReturn Then
    '@
    '@        '@初期化
    '@        llngPlusMoji = 0
    '@
    '@        '@全角文字を半角文字に変換
    '@        lstrChangeString = StrConv(txtOrderID.Text, vbNarrow)     '[半角]
    '@
    '@        '@文字数分、以下の処理を繰り返す
    '@        For llngCount = 1 To Len(lstrChangeString)
    '@
    '@            '@1文字ずつ検査する
    '@            lstrSearchString = Mid(lstrChangeString, llngCount, 1)
    '@
    '@            '@次の文字がある場合は、次の文字を取得
    '@            If llngCount + 1 <= Len(lstrChangeString) Then
    '@                lstrNextString = Mid(lstrChangeString, llngCount + 1, 1)
    '@            End If
    '@
    '@            '@ｶﾀｶﾅは全角にする
    '@            If Asc(lstrSearchString) >= CPlngKeyAsciiNarStr And Asc(lstrSearchString) <= CPlngKeyAsciiNarEnd Then
    '@
    '@                '@次の文字がある場合は、次の文字の文字コードを検索
    '@                If llngCount + 1 <= Len(lstrChangeString) Then
    '@                    '@「ﾟ」「ﾞ」の場合は前の文字と2文字を1文字として変換
    '@                    If Asc(lstrNextString) = CPlngKeyAsciiNarEnd Or Asc(lstrNextString) = CPlngKeyAsciiSnntMrk Then
    '@                        lstrNewChangeString = lstrNewChangeString & StrConv(lstrSearchString & lstrNextString, vbWide)
    '@                        llngCount = llngCount + 1
    '@                        llngPlusMoji = llngPlusMoji + 1
    '@                    Else
    '@                        '@それ以外の場合、1文字を変換
    '@                        lstrNewChangeString = lstrNewChangeString & StrConv(lstrSearchString, vbWide)
    '@                    End If
    '@                Else
    '@                    '@それ以外の場合、1文字を変換
    '@                    lstrNewChangeString = lstrNewChangeString & StrConv(lstrSearchString, vbWide)
    '@                End If
    '@            Else
    '@                '@それ以外の場合はそのまま
    '@                lstrNewChangeString = lstrNewChangeString & lstrSearchString
    '@            End If
    '@        Next
    '@
    '@        '@変換後の文字列をｾｯﾄ
    '@        txtOrderID.Text = lstrNewChangeString
    '@        '@ｶｰｿﾙ位置を後ろにもっていく
    '@        txtOrderID.SelStart = Len(txtOrderID.Text) + 1
    '@    End If
    '@
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey
    '@        .strProcName = "txtOrderID_KeyUp"
    '@        .strErrMessage = vbNullString
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Sub
    '@↑2018/06/28 (Thu) 13:49:39 T.Oide **************************************************

    '関数名：cmbOrderID_KeyUp
    '機　能：発注IDﾃｷｽﾄのｷｰUP時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2018/06/28 (Thu) 13:28:28 T.Oide
    '更新日：2018/06/28 (Thu) 13:28:28
    '備　考：
    Private Sub cmbOrderID_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles cmbOrderID.KeyUp
        
        Dim llngCount               As Integer      'ｶｳﾝﾀ
        Dim llngPlusMoji            As Integer      'ﾌﾟﾗｽ文字数ｶｳﾝﾀ
        Dim lstrSearchString        As String       '検索文字格納用
        Dim lstrChangeString        As String       '変換前の文字列格納用
        Dim lstrNewChangeString     As String       '変換後の文字列格納用
        Dim lstrNextString          As String       '次文字格納用

        Try
            
            '@Enterｷｰ押下か
            If e.KeyCode = Keys.Return Then
            
                '@初期化
                llngPlusMoji = 0
                
                '@全角文字を半角文字に変換
                lstrChangeString = StrConv(cmbOrderID.Text, vbNarrow)     '[半角]
                
                '@文字数分、以下の処理を繰り返す
                For llngCount = 1 To Len(lstrChangeString)
                    
                    '@1文字ずつ検査する
                    lstrSearchString = Mid(lstrChangeString, llngCount, 1)
                    
                    '@次の文字がある場合は、次の文字を取得
                    If llngCount + 1 <= Len(lstrChangeString) Then
                        lstrNextString = Mid(lstrChangeString, llngCount + 1, 1)
                    End If
                    
                    '@ｶﾀｶﾅは全角にする
                    If Asc(lstrSearchString) >= CPlngKeyAsciiNarStr And Asc(lstrSearchString) <= CPlngKeyAsciiNarEnd Then
                        
                        '@次の文字がある場合は、次の文字の文字コードを検索
                        If llngCount + 1 <= Len(lstrChangeString) Then
                            '@「ﾟ」「ﾞ」の場合は前の文字と2文字を1文字として変換
                            If Asc(lstrNextString) = CPlngKeyAsciiNarEnd Or Asc(lstrNextString) = CPlngKeyAsciiSnntMrk Then
                                lstrNewChangeString = lstrNewChangeString & StrConv(lstrSearchString & lstrNextString, vbWide)
                                llngCount = llngCount + 1
                                llngPlusMoji = llngPlusMoji + 1
                            Else
                                '@それ以外の場合、1文字を変換
                                lstrNewChangeString = lstrNewChangeString & StrConv(lstrSearchString, vbWide)
                            End If
                        Else
                            '@それ以外の場合、1文字を変換
                            lstrNewChangeString = lstrNewChangeString & StrConv(lstrSearchString, vbWide)
                        End If
                    Else
                        '@それ以外の場合はそのまま
                        lstrNewChangeString = lstrNewChangeString & lstrSearchString
                    End If
                Next
                
                '@変換後の文字列をｾｯﾄ
                cmbOrderID.Text = lstrNewChangeString
        '@        '@ｶｰｿﾙ位置を後ろにもっていく
        '@        cmbOrderID.SelStart = Len(cmbOrderID.Text) + 1
                
            End If
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbOrderID_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2018/06/28 (Thu) 13:49:52 T.Oide **************************************************
    '@'関数名：txtOrderID_Validate
    '@'機　能：発注IDのValidate処理
    '@'引　数：Cancel：ｷｬﾝｾﾙ値
    '@'戻り値：なし
    '@'作成日：2006/10/24 (Tue) 13:16:59 N.Kojima
    '@'更新日：2006/10/24 (Tue) 13:16:59
    '@'備　考：
    '@Private Sub txtOrderID_Validate(Cancel As Boolean)
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    '@ﾌｫｰｶｽ制御
    '@    '@発注での起動の場合
    '@    If mstrStartKbn = CPstrFour Then
    '@        '@受入予定日が有効な場合
    '@        If calAcceptDate.Enabled = True Then
    '@            '@受入予定日にﾌｫｰｶｽｾｯﾄ
    '@            Call pubSetFocus(calAcceptDate)
    '@        Else
    '@            '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
    '@            Call pubSetFocus(cmdClose)
    '@        End If
    '@    End If
    '@
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey
    '@        .strProcName = "txtOrderID_Validate"
    '@        .strErrMessage = vbNullString
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Sub
    '@↑2018/06/28 (Thu) 13:49:52 T.Oide **************************************************

    '関数名：cmbOrderID_Validate
    '機　能：発注IDのValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/10/24 (Tue) 13:16:59 N.Kojima
    '更新日：2006/10/24 (Tue) 13:16:59
    '備　考：
    Private Sub cmbOrderID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbOrderID.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ﾌｫｰｶｽ制御
            '@発注での起動の場合
            If mstrStartKbn = CPstrFour Then
                If ActiveControl.Name = cmbOrderID.Name Then
                    '@受入予定日が有効な場合
                    If calAcceptDate.Enabled = True Then
                        '@受入予定日にﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(calAcceptDate)
                    Else
                        '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbOrderID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtOrderNum_Change
    '機　能：発注番号変更
    '引　数：なし
    '戻り値：なし
    '作成日：2007/06/14 (Thu) 10:41:31 N.Kasai
    '更新日：2018/06/28 (Thu) 13:50:34 T.Oide
    '備　考：
    Private Sub txtOrderNum_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtOrderNum.Change

        Try

        '@↓2018/06/28 (Thu) 13:30:02 T.Oide **************************************************
        '@    '@受入日,発注IDにNULLがあるか(発注数も条件に追加)
        '@    If txtOrderID.Text = vbNullString Or calAcceptDate.Value = CPstrNullDate Or _
        '@        txtOrderNum.Text = vbNullString Or txtOrderNum.Text = "0" Then
        '@        '@確定ﾎﾞﾀﾝを無効にする
        '@        cmdRegist.Enabled = False
        '@    Else
        '@        '@確定ﾎﾞﾀﾝを有効にする
        '@        cmdRegist.Enabled = True
        '@    End If
        '@------------------------------------------------------------------------------------

            '@受入日,発注IDにNULLがあるか(発注数も条件に追加)
            If cmbOrderID.Text = vbNullString Or calAcceptDate.Value = CPstrNullDate Or _
                txtOrderNum.Text = vbNullString Or txtOrderNum.Text = "0" Then
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            Else
                '@確定ﾎﾞﾀﾝを有効にする
                cmdRegist.Enabled = True
            End If
        '@↑2018/06/28 (Thu) 13:30:02 T.Oide **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtOrderNum_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtMaterialLotID_Change
    '機　能：部材管理ID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/18 (Tue) 09:21:45 N.Kojima
    '更新日：2006/10/24 (Tue) 13:56:33 N.Kojima
    '備　考：
    '　　　：2006/06/23 (Fri) 10:18:57 N.Kojima     部材日付変更機能追加に伴い、処理修正。(ﾕｰｻﾞｰ要望№0189)
    '　　　：2006/10/24 (Tue) 13:56:33 N.Kojima     部材の在庫ﾁｪｯｸ・発注管理機能追加に伴い、処理追加&修正。(案件№01095)
    Private Sub txtMaterialLotID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtMaterialLotID.Change

        Try
                
            '@起動区分により処理を分岐
            Select Case mstrStartKbn
            
                '@分割で起動の場合
                Case CPstrTwo
                    '@製造日,受入日,部材管理ID,連番が入力されているか
                    If txtMaterialLotID.Text <> vbNullString And txtConsecutiveNum.Text <> vbNullString And _
                        calProductDate.Value <> CPstrNullDate And calAcceptDate.Value <> CPstrNullDate Then
                        
                        '@確定ﾎﾞﾀﾝを有効にする
                        cmdRegist.Enabled = True
                    Else
                        '@確定ﾎﾞﾀﾝを無効にする
                        cmdRegist.Enabled = False
                    End If
            
                '@登録(=受入)で起動の場合
                Case CPstrOne
                    '@製造日,受入日,部材管理IDが入力されているか
                    If txtMaterialLotID.Text <> vbNullString And _
                        calProductDate.Value <> CPstrNullDate And calAcceptDate.Value <> CPstrNullDate Then
                        
                        '@確定ﾎﾞﾀﾝを有効にする
                        cmdRegist.Enabled = True
                    Else
                        '@確定ﾎﾞﾀﾝを無効にする
                        cmdRegist.Enabled = False
                    End If

            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtMaterialLotID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtMaterialLotID_KeyUp
    '機　能：部材管理IDﾃｷｽﾄのｷｰUP時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2006/04/20 (Thu) 16:59:06 N.Kojima
    '更新日：2006/04/20 (Thu) 16:59:06
    '備　考：
    Private Sub txtMaterialLotID_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtMaterialLotID.KeyUp
        
        Dim llngCount               As Integer      'ｶｳﾝﾀ
        Dim llngPlusMoji            As Integer      'ﾌﾟﾗｽ文字数ｶｳﾝﾀ
        Dim lstrSearchString        As String       '検索文字格納用
        Dim lstrChangeString        As String       '変換前の文字列格納用
        Dim lstrNewChangeString     As String       '変換後の文字列格納用
        Dim lstrNextString          As String       '次文字格納用

        Try
            
            '@Enterｷｰ押下か
            If e.KeyCode = Keys.Return Then
            
                '@初期化
                llngPlusMoji = 0
                
                '@全角文字を半角文字に変換
                lstrChangeString = StrConv(txtMaterialLotID.Text, vbNarrow)     '[半角]
                
                '@文字数分、以下の処理を繰り返す
                For llngCount = 1 To Len(lstrChangeString)
                    
                    '@1文字ずつ検査する
                    lstrSearchString = Mid(lstrChangeString, llngCount, 1)
                    
                    '@次の文字がある場合は、次の文字を取得
                    If llngCount + 1 <= Len(lstrChangeString) Then
                        lstrNextString = Mid(lstrChangeString, llngCount + 1, 1)
                    End If
                    
                    '@ｶﾀｶﾅは全角にする
                    If Asc(lstrSearchString) >= CPlngKeyAsciiNarStr And Asc(lstrSearchString) <= CPlngKeyAsciiNarEnd Then
                        
                        '@次の文字がある場合は、次の文字の文字コードを検索
                        If llngCount + 1 <= Len(lstrChangeString) Then
                            '@「ﾟ」「ﾞ」の場合は前の文字と2文字を1文字として変換
                            If Asc(lstrNextString) = CPlngKeyAsciiNarEnd Or Asc(lstrNextString) = CPlngKeyAsciiSnntMrk Then
                                lstrNewChangeString = lstrNewChangeString & StrConv(lstrSearchString & lstrNextString, vbWide)
                                llngCount = llngCount + 1
                                llngPlusMoji = llngPlusMoji + 1
                            Else
                                '@それ以外の場合、1文字を変換
                                lstrNewChangeString = lstrNewChangeString & StrConv(lstrSearchString, vbWide)
                            End If
                        Else
                            '@それ以外の場合、1文字を変換
                            lstrNewChangeString = lstrNewChangeString & StrConv(lstrSearchString, vbWide)
                        End If
                    Else
                        '@それ以外の場合はそのまま
                        lstrNewChangeString = lstrNewChangeString & lstrSearchString
                    End If
                Next
                
                '@変換後の文字列をｾｯﾄ
                txtMaterialLotID.Text = lstrNewChangeString
                '@ｶｰｿﾙ位置を後ろにもっていく
                txtMaterialLotID.SelectionStart = Len(txtMaterialLotID.Text) + 1
            End If
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtMaterialLotID_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtMaterialLotID_Validate
    '機　能：部材管理IDのValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/04/18 (Tue) 09:23:57 N.Kojima
    '更新日：2006/10/24 (Tue) 13:59:46 N.Kojima
    '備　考：
    '　　　：2006/06/23 (Fri) 10:20:52 N.Kojima     部材日付変更機能追加に伴い、処理修正。(ﾕｰｻﾞｰ要望№0189)
    '　　　：2006/10/24 (Tue) 13:59:46 N.Kojima     部材の在庫ﾁｪｯｸ・発注管理機能追加に伴い、処理追加&修正。(案件№01095)
    Private Sub txtMaterialLotID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtMaterialLotID.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@起動区分により処理を分岐(ﾌｫｰｶｽ制御)
            Select Case mstrStartKbn
            
                '@分割で起動の場合(mstrStartKbn=2)
                Case CPstrTwo
                    If ActiveControl.Name = txtMaterialLotID.Name Then
                        '@連番が有効な場合
                        If txtConsecutiveNum.Enabled = True Then
                            '@連番にﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(txtConsecutiveNum)
                        Else
                            '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdClose)
                        End If
                    End If

                '@登録(=受入)で起動の場合(mstrStartKbn=1)
                Case CPstrOne
                    If ActiveControl.Name = txtMaterialLotID.Name Then
                        '@製造日が有効な場合
                        If calProductDate.Enabled = True Then
                            '@製造日にﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(calProductDate)
                        Else
                            '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdClose)
                        End If
                    End If

            End Select
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtMaterialLotID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtConsecutiveNum_Change
    '機　能：連番変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/18 (Tue) 09:42:10 N.Kojima
    '更新日：2006/04/18 (Tue) 09:42:10
    '備　考：
    Private Sub txtConsecutiveNum_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtConsecutiveNum.Change
        
        Dim lstrCombMatrialLotID    As String       '「部材管理ID + "-" + 連番」格納用
        
        Try

            lstrCombMatrialLotID = txtMaterialLotID.Text & CPstrHiphen & txtConsecutiveNum.Text

            '@連番がNULLではない場合
            If txtConsecutiveNum.Text <> vbNullString And _
                LenB(lstrCombMatrialLotID) <= 20 Then
                '@確定ﾎﾞﾀﾝを有効に
                cmdRegist.Enabled = True
            Else
                '@確定ﾎﾞﾀﾝを無効に
                cmdRegist.Enabled = False
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtConsecutiveNum_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtConsecutiveNum_KeyUp
    '機　能：連番ﾃｷｽﾄのｷｰUP時処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift  ：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2006/04/20 (Thu) 16:59:06 N.Kojima
    '更新日：2006/04/20 (Thu) 16:59:06
    '備　考：
    Private Sub txtConsecutiveNum_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtConsecutiveNum.KeyUp
        
        Dim llngCount               As Integer      'ｶｳﾝﾀ
        Dim llngPlusMoji            As Integer      'ﾌﾟﾗｽ文字数ｶｳﾝﾀ
        Dim lstrSearchString        As String       '検索文字格納用
        Dim lstrChangeString        As String       '変換前の文字列格納用
        Dim lstrNewChangeString     As String       '変換後の文字列格納用
        Dim lstrNextString          As String       '次文字格納用

        Try
            
            '@Enterｷｰ押下か
            If e.KeyCode = Keys.Return Then
            
                '@初期化
                llngPlusMoji = 0
                
                '@全角文字を半角文字に変換
                lstrChangeString = StrConv(txtConsecutiveNum.Text, vbNarrow)     '[半角]
                
                '@文字数分、以下の処理を繰り返す
                For llngCount = 1 To Len(lstrChangeString)
                    
                    '@1文字ずつ検査する
                    lstrSearchString = Mid(lstrChangeString, llngCount, 1)
                    
                    '@次の文字がある場合は、次の文字を取得
                    If llngCount + 1 <= Len(lstrChangeString) Then
                        lstrNextString = Mid(lstrChangeString, llngCount + 1, 1)
                    End If
                    
                    '@ｶﾀｶﾅは全角にする
                    If Asc(lstrSearchString) >= CPlngKeyAsciiNarStr And Asc(lstrSearchString) <= CPlngKeyAsciiNarEnd Then
                        
                        '@次の文字がある場合は、次の文字の文字コードを検索
                        If llngCount + 1 <= Len(lstrChangeString) Then
                            '@「ﾟ」「ﾞ」の場合は前の文字と2文字を1文字として変換
                            If Asc(lstrNextString) = CPlngKeyAsciiNarEnd Or Asc(lstrNextString) = CPlngKeyAsciiSnntMrk Then
                                lstrNewChangeString = lstrNewChangeString & StrConv(lstrSearchString & lstrNextString, vbWide)
                                llngCount = llngCount + 1
                                llngPlusMoji = llngPlusMoji + 1
                            Else
                                '@それ以外の場合、1文字を変換
                                lstrNewChangeString = lstrNewChangeString & StrConv(lstrSearchString, vbWide)
                            End If
                        Else
                            '@それ以外の場合、1文字を変換
                            lstrNewChangeString = lstrNewChangeString & StrConv(lstrSearchString, vbWide)
                        End If
                    Else
                        '@それ以外の場合はそのまま
                        lstrNewChangeString = lstrNewChangeString & lstrSearchString
                    End If
                Next
                
                '@変換後の文字列をｾｯﾄ
                txtConsecutiveNum.Text = lstrNewChangeString
                '@ｶｰｿﾙ位置を後ろにもっていく
                txtConsecutiveNum.SelectionStart = Len(txtConsecutiveNum.Text) + 1
            End If
            
            Exit Sub
            
        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtConsecutiveNum_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtConsecutiveNum_Validate
    '機　能：連番入力Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/04/18 (Tue) 09:42:56 N.Kojima
    '更新日：2006/04/18 (Tue) 09:42:56
    '備　考：
    Private Sub txtConsecutiveNum_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtConsecutiveNum.Validating

        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ﾌｫｰｶｽ制御
            '@分割での起動の場合(mstrStartKbn=2)
            If mstrStartKbn = CPstrTwo Then
                If ActiveControl.Name = txtConsecutiveNum.Name Then
                    '@確定ﾎﾞﾀﾝが有効な場合
                    If cmdRegist.Enabled = True Then
                        '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdRegist)
                    Else
                        '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtConsecutiveNum_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calProductDate_CalendarSelect
    '機　能：製造日選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/19 (Wed) 11:28:54 N.Kojima
    '更新日：2006/04/19 (Wed) 11:28:54
    '備　考：
    Private Sub calProductDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calProductDate.CalendarSelect

        Try

            '@日付が空の場合はﾌｫｰｶｽを留める
            If calProductDate.Value = CPstrNullDate Then
                Exit Sub
            End If
            
            '@Validate処理へ
            RemoveHandler calProductDate.Validating, AddressOf calProductDate_Validate
            Call calProductDate_Validate(calProductDate, New CancelEventArgs(True))
            AddHandler calProductDate.Validating, AddressOf calProductDate_Validate
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calProductDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calProductDate_Change
    '機　能：製造日変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/19 (Wed) 11:29:34 N.Kojima
    '更新日：2018/06/28 (Thu) 13:31:17 T.Oide
    '備　考：
    Private Sub calProductDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calProductDate.Change

        Try
                
            '@起動区分により処理を分岐
            Select Case mstrStartKbn

                '@分割で起動の場合
                Case CPstrTwo
                    '@製造日,受入日,部材管理ID,連番にNULLがあるか
                    If txtMaterialLotID.Text = vbNullString Or txtConsecutiveNum.Text = vbNullString Or _
                        calProductDate.Value = CPstrNullDate Or calAcceptDate.Value = CPstrNullDate Then
                        
                        '@確定ﾎﾞﾀﾝを無効にする
                        cmdRegist.Enabled = False
                    Else
                        '@確定ﾎﾞﾀﾝを有効にする
                        cmdRegist.Enabled = True
                    End If
            
                '@受入で起動の場合
                Case CPstrOne
                    '@製造日,受入日,部材管理IDにNULLがあるか
                    If txtMaterialLotID.Text = vbNullString Or _
                        calProductDate.Value = CPstrNullDate Or calAcceptDate.Value = CPstrNullDate Then
                        
                        '@確定ﾎﾞﾀﾝを無効にする
                        cmdRegist.Enabled = False
                    Else
                        '@確定ﾎﾞﾀﾝを有効にする
                        cmdRegist.Enabled = True
                    End If
                    
                '@日付変更で起動の場合
                Case CPstrThree
                    '@製造日,受入日,使用開始日時にNULLがあるか
                    If calProductDate.Value = CPstrNullDate Or calAcceptDate.Value = CPstrNullDate Or _
                        calStartUseDate.Value = CPstrNullDate Or medTime.Text = CPstrNullTime Then
                        
                        '@確定ﾎﾞﾀﾝを無効にする
                        cmdRegist.Enabled = False
                    Else
                        '@確定ﾎﾞﾀﾝを有効にする
                        cmdRegist.Enabled = True
                    End If
                    
                '@発注で起動の場合
                Case CPstrFour
                
        '@↓2018/06/28 (Thu) 13:30:58 T.Oide **************************************************
        '@            '@受入日,発注IDにNULLがあるか
        '@            If txtOrderID.Text = vbNullString Or calAcceptDate.Value = CPstrNullDate Then
        '@
        '@                '@確定ﾎﾞﾀﾝを無効にする
        '@                cmdRegist.Enabled = False
        '@            Else
        '@                '@確定ﾎﾞﾀﾝを有効にする
        '@                cmdRegist.Enabled = True
        '@            End If
        '@-------------------------------------------------------------------------------------

                    '@受入日,発注IDにNULLがあるか
                    If cmbOrderID.Text = vbNullString Or calAcceptDate.Value = CPstrNullDate Then
                        
                        '@確定ﾎﾞﾀﾝを無効にする
                        cmdRegist.Enabled = False
                    Else
                        '@確定ﾎﾞﾀﾝを有効にする
                        cmdRegist.Enabled = True
                    End If
        '@↑2018/06/28 (Thu) 13:30:58 T.Oide **************************************************
            
            End Select

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calProductDate_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calProductDate_Validate
    '機　能：製造日Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/04/19 (Wed) 11:30:05 N.Kojima
    '更新日：2007/01/24 (Wed) 15:47:12 N.Kojima
    '備　考：
    '　　　：2006/06/23 (Fri) 10:49:29 N.Kojima     部材日付変更機能追加に伴い、処理修正。(ﾕｰｻﾞｰ要望№0189)
    '　　　：2007/01/24 (Wed) 15:47:12 N.Kojima     日付ﾁｪｯｸ処理等を大幅見直し。(案件№01264)
    Private Sub calProductDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calProductDate.Validating
        
        Dim lstrErrMsg      As String       'ｴﾗｰMsg格納用
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@製造日が入力されているか
            If calProductDate.Value <> CPstrNullDate Then
                '@製造日が入力されている場合
                
                '@製造日の有効性ﾁｪｯｸ
                If pubblnYearRange_Chk(calProductDate.Value) = False Then
                    '@製造日が無効な日付の場合
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@"<TRM08W>$$正しい日付を入力してください。$1900年～2100年以外の日付は入力できません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@確定ﾎﾞﾀﾝを無効に
                    cmdRegist.Enabled = False

                    '@製造日にﾌｫｰｶｽを保持
                    e.Cancel = True
                    Exit Sub
                Else
                    '@製造日が入力されていて、かつ日付が有効な場合
                        
                    '@受入日が入力されているか
                    If calAcceptDate.Value <> CPstrNullDate Then
                        
                        '@受入日が入力されている場合、日付妥当性ﾁｪｯｸ(製造日 <= 受入日)を行なう
                        If Format$(CDate(calProductDate.Value), CPstrDateTimeYMD) >= _
                            Format$(CDate(calAcceptDate.Value), CPstrDateTimeYMD) Then
                            
                            '@表示用ｴﾗｰMsgの[%2]用の引数を作成。⇒[同日,未来]
                            lstrErrMsg = CMstrSameDay & CPstrComma & CMstrFutureDays
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007V, CMstrAcceptDate, lstrErrMsg)
                            '@"<TRM7VW>$$[受入日]に対し[同日,未来]の日付は指定できません。設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@確定ﾎﾞﾀﾝを無効に
                            cmdRegist.Enabled = False
                            
                            '@製造日にﾌｫｰｶｽを保持
                            e.Cancel = True
                            Exit Sub
                        End If
                    Else
                        '@受入日が入力されていない場合
                    
                        '@確定ﾎﾞﾀﾝを無効に
                        cmdRegist.Enabled = False
                    End If
                    
                    '@部材日時変更での起動か
                    If mstrStartKbn = CPstrThree Then
                        
                        '@使用開始日時が入力されているか
                        If calStartUseDate.Value <> CPstrNullDate Then
                            
                            '@日付の妥当性ﾁｪｯｸ(製造日 < 使用開始日時)を行なう
                            If Format$(CDate(calProductDate.Value), CPstrDateTimeYMD) >= _
                                Format$(CDate(calStartUseDate.Value), CPstrDateTimeYMD) Then
                                
                                '@表示用ｴﾗｰMsgの[%2]用の引数を作成。⇒[同日,未来]
                                lstrErrMsg = CMstrSameDay & CPstrComma & CMstrFutureDays
                                
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007V, CMstrStartUseDate, lstrErrMsg)
                                '@"<TRM7VW>$$[使用開始日時]に対し[同日,未来]の日付は指定できません。設定を見直してください。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                '@確定ﾎﾞﾀﾝを無効に
                                cmdRegist.Enabled = False
                                
                                '@製造日にﾌｫｰｶｽを保持
                                e.Cancel = True
                                Exit Sub
                            End If
                        Else
                            '@使用開始日時が入力されていない場合
                        
                            '@確定ﾎﾞﾀﾝを無効に
                            cmdRegist.Enabled = False
                        End If
                        
                        '@時間が有効で、NULLではないか
                        If IsDate(medTime.Text) = False Or _
                            medTime.Text = CPstrNullTime Then
                            '@時間が無効 or 時間入力されていない(空欄)場合
                            '@確定ﾎﾞﾀﾝを無効に
                            cmdRegist.Enabled = False
                        End If
                    End If
                End If
            Else
                '@製造日が入力されていない場合
            
                '@確定ﾎﾞﾀﾝを無効に
                cmdRegist.Enabled = False
            End If

            If ActiveControl.Name = calProductDate.Name Then
                '@受入日にﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(calAcceptDate)
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "calProductDate_Validate"    '処理名
                .strErrMessage = ""                         'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：calAcceptDate_CalendarSelect
    '機　能：受入日選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/19 (Wed) 11:37:36 N.Kojima
    '更新日：2006/04/19 (Wed) 11:37:36
    '備　考：
    Private Sub calAcceptDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calAcceptDate.CalendarSelect

        Try

            '@日付が空の場合はﾌｫｰｶｽを留める
            If calAcceptDate.Value = CPstrNullDate Then
                Exit Sub
            End If
            
            '@Validate処理へ
            RemoveHandler calAcceptDate.Validating, AddressOf calAcceptDate_Validate
            Call calAcceptDate_Validate(calAcceptDate, New CancelEventArgs(True))
            AddHandler calAcceptDate.Validating, AddressOf calAcceptDate_Validate
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calAcceptDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calAcceptDate_Change
    '機　能：受入日変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/19 (Wed) 11:38:29 N.Kojima
    '更新日：2018/06/28 (Thu) 13:32:13 T.Oide
    '備　考：
    Private Sub calAcceptDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calAcceptDate.Change

        Try
                
            '@起動区分により処理を判定
            Select Case mstrStartKbn
            
                '@分割で起動の場合
                Case CPstrTwo
                    '@製造日,受入日,部材管理ID,連番にNULLがあるか
                    If txtMaterialLotID.Text = vbNullString Or txtConsecutiveNum.Text = vbNullString Or _
                        calProductDate.Value = CPstrNullDate Or calAcceptDate.Value = CPstrNullDate Then
                        
                        '@確定ﾎﾞﾀﾝを無効にする
                        cmdRegist.Enabled = False
                    Else
                        '@確定ﾎﾞﾀﾝを有効にする
                        cmdRegist.Enabled = True
                    End If
            
                '@受入で起動の場合
                Case CPstrOne
                    '@製造日,受入日,部材管理IDにNULLがあるか
                    If txtMaterialLotID.Text = vbNullString Or _
                        calProductDate.Value = CPstrNullDate Or calAcceptDate.Value = CPstrNullDate Then
                        
                        '@確定ﾎﾞﾀﾝを無効にする
                        cmdRegist.Enabled = False
                    Else
                        '@確定ﾎﾞﾀﾝを有効にする
                        cmdRegist.Enabled = True
                    End If
                
                '@変更で起動の場合
                Case CPstrThree
                    '@製造日,受入日,使用開始日時にNULLがあるか
                    If calProductDate.Value = CPstrNullDate Or calAcceptDate.Value = CPstrNullDate Or _
                        calStartUseDate.Value = CPstrNullDate Or medTime.Text = CPstrNullTime Then
                        
                        '@確定ﾎﾞﾀﾝを無効にする
                        cmdRegist.Enabled = False
                    Else
                        '@確定ﾎﾞﾀﾝを有効にする
                        cmdRegist.Enabled = True
                    End If
                
                '@発注で起動の場合
                Case CPstrFour
                
        '@↓2018/06/28 (Thu) 13:31:50 T.Oide **************************************************
        '@            '@受入日,発注IDにNULLがあるか(発注数も条件に追加)
        '@            If txtOrderID.Text = vbNullString Or calAcceptDate.Value = CPstrNullDate Or _
        '@                txtOrderNum.Text = vbNullString Or txtOrderNum.Text = "0" Then
        '@                '@確定ﾎﾞﾀﾝを無効にする
        '@                cmdRegist.Enabled = False
        '@            Else
        '@                '@確定ﾎﾞﾀﾝを有効にする
        '@                cmdRegist.Enabled = True
        '@            End If
        '@-------------------------------------------------------------------------------------

                    '@受入日,発注IDにNULLがあるか(発注数も条件に追加)
                    If cmbOrderID.Text = vbNullString Or calAcceptDate.Value = CPstrNullDate Or _
                        txtOrderNum.Text = vbNullString Or txtOrderNum.Text = "0" Then
                        '@確定ﾎﾞﾀﾝを無効にする
                        cmdRegist.Enabled = False
                    Else
                        '@確定ﾎﾞﾀﾝを有効にする
                        cmdRegist.Enabled = True
                    End If
        '@↑2018/06/28 (Thu) 13:31:50 T.Oide **************************************************

            End Select
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calAcceptDate_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calAcceptDate_Validate
    '機　能：受入日ｺﾝﾎﾞValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/04/19 (Wed) 11:38:48 N.Kojima
    '更新日：2007/01/24 (Wed) 12:47:44 N.Kojima
    '備　考：
    '　　　：2006/06/23 (Fri) 11:27:38 N.Kojima     部材日付変更機能追加に伴い、処理修正。(ﾕｰｻﾞｰ要望№0189)
    '　　　：2006/10/24 (Tue) 14:34:27 N.Kojima     部材の在庫ﾁｪｯｸ・発注管理機能追加に伴い、処理追加&修正。(案件№01095)
    '　　　：2007/01/24 (Wed) 12:47:44 N.Kojima     確定ﾎﾞﾀﾝが無効な場合は、閉じるﾎﾞﾀﾝにﾌｫｰｶｽをｾｯﾄするように修正。(案件№01264)
    Private Sub calAcceptDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calAcceptDate.Validating
        
        Dim lstrErrMsg      As String       'ｴﾗｰMsg表示用
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@受入日が入力されているか
            If calAcceptDate.Value <> CPstrNullDate Then
                '@入力されている場合
                
                '@受入日の有効性ﾁｪｯｸ
                If pubblnYearRange_Chk(calAcceptDate.Value) = False Then
                    '@無効な日付の場合
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@"<TRM08W>$$正しい日付を入力してください。$1900年～2100年以外の日付は入力できません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@確定ﾎﾞﾀﾝを無効に
                    cmdRegist.Enabled = False

                    '@受入日にﾌｫｰｶｽ保持
                    e.Cancel = True
                    Exit Sub
                Else
                    '@受入日が入力されていて、かつ日付が有効な場合
                                
                    Select Case mstrStartKbn
                    
                        '@① 発注での起動の場合
                        '@② 製造日はﾁｪｯｸしない、受入予定日に過去日の指定は不可
                        Case CPstrFour
                            
                            '@「受入日 < 現在日時」は指定不可
                            If Format$(CDate(calAcceptDate.Value), CPstrDateTimeYMD) < _
                                Format$(Now, CPstrDateTimeYMD) Then
                                
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                                '@"<TRM10W>$$過去の日付は指定できません。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                                '@確定ﾎﾞﾀﾝを無効に
                                cmdRegist.Enabled = False
                    
                                '@受入日にﾌｫｰｶｽ保持
                                e.Cancel = True
                                Exit Sub
                            End If
            
                            If ActiveControl.Name = calAcceptDate.Name Then
                                '@確定ﾎﾞﾀﾝが有効な場合
                                If cmdRegist.Enabled = True Then
                                    '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                                    Call pubSetFocus(cmdRegist)
                                Else
                                    '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                                    Call pubSetFocus(cmdClose)
                                End If
                            End If

                            Exit Sub

                        '@受入・部材日時変更での起動
                        Case CPstrOne, CPstrThree
                            
                            '@製造日が入力されているか
                            If calProductDate.Value <> CPstrNullDate Then
                                '@製造日が入力(選択)されている場合
                                
                                '@日付妥当性ﾁｪｯｸ(製造日 <= 受入日)を行なう
                                If Format$(CDate(calProductDate.Value), CPstrDateTimeYMD) >= _
                                    Format$(CDate(calAcceptDate.Value), CPstrDateTimeYMD) Then
                                    
                                    '@表示用ｴﾗｰMsgの[%2]用の引数を作成。⇒[同日,過去]
                                    lstrErrMsg = CMstrSameDay & CPstrComma & CMstrPastDays
                                    
                                    '@表示ﾒｯｾｰｼﾞ変換
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007V, CMstrProductDate, lstrErrMsg)
                                    '@"<TRM7VW>$$[製造日]に対し[同日,過去]の日付は指定できません。設定を見直してください。"
                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                    
                                    '@確定ﾎﾞﾀﾝを無効に
                                    cmdRegist.Enabled = False
                                    
                                    '@受入日にﾌｫｰｶｽを保持
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            Else
                                '@製造日が入力されていない場合
                            
                                '@確定ﾎﾞﾀﾝを無効に
                                cmdRegist.Enabled = False
                            End If
                                        
                            '@部材日時変更での起動の場合は、使用開始日時もﾁｪｯｸする
                            If mstrStartKbn = CPstrThree Then
                            
                                '@使用開始日時が入力されているか
                                If calStartUseDate.Value <> CPstrNullDate Then
                                    '@使用開始日時が入力されている場合
                                    
                                    '@使用開始日時が入力されている場合、日付妥当性ﾁｪｯｸ(受入日 <= 使用開始日時はOK)を行なう
                                    If Format$(CDate(calAcceptDate.Value), CPstrDateTimeYMD) > _
                                        Format$(CDate(calStartUseDate.Value), CPstrDateTimeYMD) Then
                                        
                                        '@表示用ｴﾗｰMsgの[%2]用の引数を作成。⇒[未来]
                                        lstrErrMsg = CMstrFutureDays
                                        
                                        '@表示ﾒｯｾｰｼﾞ変換
                                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007V, CMstrStartUseDate, lstrErrMsg)
                                        '@"<TRM7VW>$$[使用開始日]に対し[未来]の日付は指定できません。設定を見直してください。"
                                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                        
                                        '@確定ﾎﾞﾀﾝを無効に
                                        cmdRegist.Enabled = False
                                        
                                        '@受入日にﾌｫｰｶｽを保持
                                        e.Cancel = True
                                        Exit Sub
                                    End If
                                    
                                    '@時間が入力されているか
                                    If medTime.Text = CPstrNullTime Then
                                        '@入力されていない場合
                                    
                                        '@確定ﾎﾞﾀﾝを無効に
                                        cmdRegist.Enabled = False
                                    End If
                                Else
                                    '@使用開始日時が入力されていない場合
                                
                                    '@確定ﾎﾞﾀﾝを無効に
                                    cmdRegist.Enabled = False
                                End If
                                
                                '@時間が有効で、NULLではないか
                                If IsDate(medTime.Text) = False Or _
                                    medTime.Text = CPstrNullTime Then
                                    '@時間が無効 or 時間入力されていない(空欄)場合
                                    '@確定ﾎﾞﾀﾝを無効に
                                    cmdRegist.Enabled = False
                                End If
                                
                                If ActiveControl.Name = calAcceptDate.Name Then
                                    '@使用開始日時ｶﾚﾝﾀﾞｰｺﾝﾎﾞが有効か
                                    If calStartUseDate.Enabled = True Then
                                        '@使用開始日時にﾌｫｰｶｽｾｯﾄ
                                        Call pubSetFocus(calStartUseDate)
                                    Else
                                        '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                                        Call pubSetFocus(cmdClose)
                                    End If
                                End If
                            Else
                                '@受入での起動の場合
                            
                                If ActiveControl.Name = calAcceptDate.Name Then
                                    '@確定ﾎﾞﾀﾝが有効か
                                    If cmdRegist.Enabled = True Then
                                        '@確定ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                                        Call pubSetFocus(cmdRegist)
                                    Else
                                        '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                                        Call pubSetFocus(cmdClose)
                                    End If
                                End If
                            End If
                    End Select
                    
                End If
            Else
                '@受入日が入力されていない場合
            
                '@確定ﾎﾞﾀﾝを無効に
                cmdRegist.Enabled = False
                
                Select Case mstrStartKbn
                    '@発注・受入での起動
                    Case CPstrOne, CPstrFour
                        If ActiveControl.Name = calAcceptDate.Name Then
                            '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdClose)
                        End If
                        
                    '@部材日時変更での起動
                    Case CPstrThree
                        If ActiveControl.Name = calAcceptDate.Name Then
                            '@使用開始日時ｶﾚﾝﾀﾞｰｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(calStartUseDate)
                        End If
                End Select
            End If
                
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "calAcceptDate_Validate" '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：calStartUseDate_CalendarSelect
    '機　能：使用開始日時選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/22 (Thu) 19:18:45 N.Kojima
    '更新日：2006/06/22 (Thu) 19:18:45
    '備　考：
    Private Sub calStartUseDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles calStartUseDate.CalendarSelect

        Try

            '@日付が空の場合はﾌｫｰｶｽを留める
            If calStartUseDate.Value = CPstrNullDate Then
                Exit Sub
            End If
            
            '@Validate処理へ
            RemoveHandler calStartUseDate.Validating, AddressOf calStartUseDate_Validate
            Call calStartUseDate_Validate(calStartUseDate, New CancelEventArgs(True))
            AddHandler calStartUseDate.Validating, AddressOf calStartUseDate_Validate
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calStartUseDate_CalendarSelect"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calStartUseDate_Change
    '機　能：使用開始日時変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/23 (Fri) 10:34:00 N.Kojima
    '更新日：2007/01/24 (Wed) 13:52:59 N.Kojima
    '備　考：
    '　　　：2007/01/24 (Wed) 13:52:59 N.Kojima     入力ﾁｪｯｸ処理を修正。(案件№01264)
    Private Sub calStartUseDate_Change(ByVal sender As Object, ByVal e As EventArgs) Handles calStartUseDate.Change

        Try
                       
            '@製造日,受入日,使用開始日時にNULLがあるか
            If calProductDate.Value = CPstrNullDate Or calStartUseDate.Value = CPstrNullDate Or _
                calStartUseDate.Value = CPstrNullDate Or medTime.Text = CPstrNullTime Then
                
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            Else
                '@確定ﾎﾞﾀﾝを有効にする
                cmdRegist.Enabled = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "calStartUseDate_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：calStartUseDate_Validate
    '機　能：使用開始日時Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/06/23 (Fri) 10:51:54 N.Kojima
    '更新日：2007/01/24 (Wed) 13:11:40 N.Kojima
    '備　考：
    '　　　：2007/01/24 (Wed) 13:11:40 N.Kojima     製造日のNULLﾁｪｯｸを追加。(案件№01264)
    Private Sub calStartUseDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles calStartUseDate.Validating
        
        Dim lstrErrMsg      As String       'ｴﾗｰMsg表示用
        
        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@使用開始日時が入力されているか
            If calStartUseDate.Value <> CPstrNullDate Then
                
                '@使用開始日時の有効性ﾁｪｯｸ
                If pubblnYearRange_Chk(calStartUseDate.Value) = False Then
                    '@使用開始日時が無効な日付の場合
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    '@"<TRM08W>$$正しい日付を入力してください。$1900年～2100年以外の日付は入力できません。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    '@確定ﾎﾞﾀﾝを無効に
                    cmdRegist.Enabled = False

                    '@使用開始日時にﾌｫｰｶｽ保持
                    e.Cancel = True
                    Exit Sub
                Else
                    '@使用開始日時が入力されていて、かつ日付が有効な場合
                        
                    '@製造日が入力されているか
                    If calProductDate.Value <> CPstrNullDate Then
                        
                        '@製造日が入力されている場合、日付妥当性ﾁｪｯｸ(製造日 < 使用開始日時)を行なう
                        If Format$(CDate(calProductDate.Value), CPstrDateTimeYMD) >= _
                            Format$(CDate(calStartUseDate.Value), CPstrDateTimeYMD) Then
                            
                            '@表示用ｴﾗｰMsgの[%2]用の引数を作成。⇒[過去,同日]
                            lstrErrMsg = CMstrPastDays & CPstrComma & CMstrSameDay
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007V, CMstrProductDate, lstrErrMsg)
                            '@"<TRM7VW>$$[製造日]に対し[過去,同日]の日付は指定できません。設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@確定ﾎﾞﾀﾝを無効に
                            cmdRegist.Enabled = False
                            
                            '@製造日にﾌｫｰｶｽを保持
                            e.Cancel = True
                            Exit Sub
                        Else
                            '@確定ﾎﾞﾀﾝを有効に
                            cmdRegist.Enabled = True
                        End If
                        
                        '@受入日が入力されているか
                        If calAcceptDate.Value <> CPstrNullDate Then
                            
                            '@受入日が入力されている場合、日付妥当性ﾁｪｯｸ(受入日 < 使用開始日時)を行なう
                            If Format$(CDate(calAcceptDate.Value), CPstrDateTimeYMD) > _
                                Format$(CDate(calStartUseDate.Value), CPstrDateTimeYMD) Then
                                
                                '@表示ﾒｯｾｰｼﾞ変換
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007V, CMstrAcceptDate, CMstrPastDays)
                                '@"<TRM7VW>$$[受入日]に対し[過去]の日付は指定できません。設定を見直してください。"
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                '@確定ﾎﾞﾀﾝを無効に
                                cmdRegist.Enabled = False
                                
                                '@製造日にﾌｫｰｶｽを保持
                                e.Cancel = True
                                Exit Sub
                            Else
                                '@確定ﾎﾞﾀﾝを有効に
                                cmdRegist.Enabled = True
                            End If
                        Else
                            '@受入日が入力されていない場合
                        
                            '@確定ﾎﾞﾀﾝを無効に
                            cmdRegist.Enabled = False
                        End If
                        
                        '@時間が有効で、NULLではないか
                        If IsDate(medTime.Text) = False Or _
                            medTime.Text = CPstrNullTime Then
                            '@時間が無効 or 時間入力されていない(空欄)場合
                            '@確定ﾎﾞﾀﾝを無効に
                            cmdRegist.Enabled = False
                        End If
                    Else
                        '@製造日が入力されていない場合
                    
                        '@確定ﾎﾞﾀﾝを無効に
                        cmdRegist.Enabled = False
                    End If
                End If
            Else
                '@確定ﾎﾞﾀﾝを無効に
                cmdRegist.Enabled = False
            End If

            If ActiveControl.Name = calStartUseDate.Name Then
                '@使用開始時間へｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(medTime)
            End If

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey         '機能ID
                .strProcName = "calStartUseDate_Validate" '処理名
                .strErrMessage = vbNullString           'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：medTime_GotFocus
    '機　能：使用開始日時ﾌｫｰｶｽ時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/22 (Thu) 18:16:29 N.Kojima
    '更新日：2006/06/22 (Thu) 18:16:29
    '備　考：MaskEdBox使用のためﾊｲﾗｲﾄ処理
    Private Sub medTime_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles medTime.Enter

        Try

            '@ﾊｲﾗｲﾄ処理
            Call pubHighlight(medTime)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medTime_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medTime_Change
    '機　能：使用開始日時変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/22 (Thu) 18:16:53 N.Kojima
    '更新日：2007/01/24 (Wed) 13:27:56 N.Kojima
    '備　考：
    '　　　：2007/01/24 (Wed) 13:27:56 N.Kojima     入力ﾁｪｯｸの判定処理を変更。(案件№01264)
    Private Sub medTime_Change(ByVal sender As Object, ByVal e As EventArgs) Handles medTime.TextChanged

        Try
            
            '@入力ﾁｪｯｸ(製造日、受入日、使用開始日時にNULLがあるか)
            If calProductDate.Value = CPstrNullDate Or calAcceptDate.Value = CPstrNullDate _
                Or calStartUseDate.Value = CPstrNullDate Or medTime.Text = CPstrNullTime Then
                
                '@確定ﾎﾞﾀﾝを無効に
                cmdRegist.Enabled = False
            Else
                '@確定ﾎﾞﾀﾝを有効に
                cmdRegist.Enabled = True
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medTime_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：medTime_Validate
    '機　能：使用開始日時Validate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/06/22 (Thu) 18:17:45 N.Kojima
    '更新日：2007/01/24 (Wed) 13:02:47 N.Kojima
    '備　考：
    '　　　：2007/01/24 (Wed) 13:02:47 N.Kojima     有効な時間の場合は現在日時取得ﾎﾞﾀﾝにﾌｫｰｶｽをｾｯﾄするように修正。(案件№01264)
    Private Sub medTime_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles medTime.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@時間の有効性ﾁｪｯｸ
            If IsDate(medTime.Text) = False Then
                '@時間入力されていない(空欄)場合
                If medTime.Text = CPstrNullTime Then
                    '@確定ﾎﾞﾀﾝを無効に
                    cmdRegist.Enabled = False
                    
                    If ActiveControl.Name = medTime.Name Then
                        '@現在日時取得ﾎﾞﾀﾝが有効な場合
                        If cmdNowDate.Enabled = True Then
                            '@現在日時取得ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdNowDate)
                        Else
                            '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(cmdClose)
                        End If
                    End If

                    Exit Sub
                End If
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0098)
                '@"<TRM98W>$$使用開始日時の設定が正しくありません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@使用開始時間入力欄にｾｯﾄﾌｫｰｶｽ
                e.Cancel = True
                
                '@確定ﾎﾞﾀﾝを無効に
                cmdRegist.Enabled = False
            
            Else
                '@時間が有効な場合
            
                '@入力ﾁｪｯｸ(製造日、受入日、使用開始日時にNULLがあるか)
                If calProductDate.Value = CPstrNullDate Or calAcceptDate.Value = CPstrNullDate _
                    Or calStartUseDate.Value = CPstrNullDate Then
                    
                    '@確定ﾎﾞﾀﾝを無効に
                    cmdRegist.Enabled = False
                Else
                    '@確定ﾎﾞﾀﾝを有効に
                    cmdRegist.Enabled = True
                End If
                
                If ActiveControl.Name = medTime.Name Then
                    '@現在日時取得ﾎﾞﾀﾝが有効な場合
                    If cmdNowDate.Enabled = True Then
                        '@現在日時取得ﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdNowDate)
                    Else
                        '@閉じるﾎﾞﾀﾝにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(cmdClose)
                    End If
                End If

            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "medTime_Validate"
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
    '作成日：2006/04/18 (Tue) 09:43:35 N.Kojima
    '更新日：2006/04/18 (Tue) 09:43:35
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

    '関数名：cmdNowDate_Click
    '機　能：現在日時取得処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/22 (Thu) 18:15:13 N.Kojima
    '更新日：2006/06/22 (Thu) 18:15:13
    '備　考：
    Private Sub cmdNowDate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowDate.Click

        Try
            
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@現在日時取得
            calStartUseDate.Value = Format$(Now, CPstrDateTimeYMD)     '受入日時(年月日)
            medTime.Text = Format$(Now, CPstrTimeFormatHM)              '受入日時(時間)

            '@入力ﾁｪｯｸ
            If calProductDate.Value <> CPstrNullDate And calAcceptDate.Value <> CPstrNullDate And _
                calStartUseDate.Value <> CPstrNullDate Then
                
                '@確定ﾎﾞﾀﾝを有効に
                cmdRegist.Enabled = True
            Else
                '@確定ﾎﾞﾀﾝを無効に
                cmdRegist.Enabled = False
            End If
            
            '@最新日時のValidationを制御(日付がｴﾗｰとなった場合に即使用できるように制御)
            cmdNowDate.CausesValidation = True

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNowDate_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：確定(装置使用部材発注/登録/分割)処理
    '引　数：なし
    '戻り値：なり
    '作成日：2006/04/18 (Tue) 09:43:52 N.Kojima
    '更新日：2018/06/28 (Thu) 13:33:14 T.Oide
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnAns                 As Boolean          '登録戻り値(True/False)
        Dim llngCnt                 As Integer          'ｶｳﾝﾄ
        Dim lstrEditTime            As String           '最終更新日時退避用
        Dim ltypRegMaterial         As RegMaterial      '送信ﾃﾞｰﾀ構造体格納用
        Dim lstrMaterialOrderID     As String           '発注ID(採番後の開始発注ID)
        Dim lstrMsgString           As String           'ﾒｯｾｰｼﾞ内容格納
        Dim llngOrderNum            As Integer          '計算用発注ID枝番
    '@↓2018/06/28 (Thu) 15:47:46 T.Oide **************************************************
        Dim lvarTemp                As Object            '選択した発注IDを格納
    '@↑2018/06/28 (Thu) 15:47:46 T.Oide **************************************************
        
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
            '@起動区分によって処理を分岐
            If mstrStartKbn = CPstrThree Then
                '@変更の場合
                '@作業者ｺｰﾄﾞ/ﾊﾟｽﾜｰﾄﾞ入力
                frmxxCM0020.Instance.ShowDialog(Me)
                frmxxCM0020.Instance = Nothing
            Else
                '@作業者ｺｰﾄﾞ入力
                frmxxCM0010.Instance.ShowDialog(Me)
                frmxxCM0010.Instance = Nothing
            End If

            '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
            If pstrUserID = vbNullString Then
                '@未入力の場合、処理中止
                Exit Sub
            End If
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrCmdRegistClick)
                
            '@送信ﾒｯｾｰｼﾞを構造体にｾｯﾄする
            With ltypRegMaterial
                .strSbID = pstrSBID                                 'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strMsgVer = CMstrmat_regmaterialVer                'Msgﾊﾞｰｼﾞｮﾝ
                .strMaterialTypeID = lblMaterialTypeID.Text      '部材種別ID
                .strMaterialID = lblMaterialID.Text              '部材ID
                .strEmpID = pstrUserID                              '作業者ID
                .strEditTime = ptypRegMaterial.strEditTime          '最終更新日時
                .strProductionDate = calProductDate.Value           '製造日
                .strAcceptanceDate = calAcceptDate.Value            '受入日

                .strWpID = ptypRegMaterial.strWpID                  '装置ID
                .strUseTime = calStartUseDate.Value & _
                              CPstrSpace & _
                              medTime.Text                          '使用開始日時
                        
                '@起動区分によりClassDivision,部材管理IDの設定を行なう
                Select Case mstrStartKbn
         
                    '@受入の場合
                    Case CPstrOne
                        .strClassDivision = CPstrCD39
        '@↓2018/06/28 (Thu) 13:33:01 T.Oide **************************************************
        '@                .strMaterialLotID = txtMaterialLotID.Text       '新規部材管理ID
        '@↑2018/06/28 (Thu) 13:33:01 T.Oide **************************************************
                        .strSrcMaterialLotID = vbNullString             '分割元部材管理ID
        '@↓2018/06/28 (Thu) 13:33:01 T.Oide **************************************************
        '@                .strMaterialOrderID = txtOrderID.Text           '発注ID
        '@↑2018/06/28 (Thu) 13:33:01 T.Oide **************************************************
                    
                    '@分割の場合
                    Case CPstrTwo
                        .strClassDivision = CPstrCD44
                        .strMaterialLotID = txtMaterialLotID.Text & CPstrHiphen & txtConsecutiveNum.Text      '部材管理ID+"-"+連番(分割後部材管理ID)
                        .strSrcMaterialLotID = txtMaterialLotID.Text    '分割元部材管理ID
                    
                    '@日付変更の場合
                    Case CPstrThree
                        .strClassDivision = vbNullString                '処理区分
                        .strMaterialLotID = txtMaterialLotID.Text       '新規部材管理ID
                        .strSrcMaterialLotID = vbNullString             '分割元部材管理ID
                        .strMsgVer = CMstrmat_chgmaterialdateVer        'Msgﾊﾞｰｼﾞｮﾝ

                    '@発注の場合
                    Case CPstrFour
                        .strMsgVer = CMstrmat_ordermaterialVer              'Msgﾊﾞｰｼﾞｮﾝ
        '@↓2018/06/28 (Thu) 13:34:18 T.Oide **************************************************
        '@                .strMaterialOrderID = Left$(txtOrderID.Text, 10)    '発注ID(-xxは送信の対象外)
                        .strMaterialOrderID = Strings.Left$(cmbOrderID.Text, 10)    '発注ID(-xxは送信の対象外)
        '@↑2018/06/28 (Thu) 13:34:18 T.Oide **************************************************
                        .strMaterialOrderNum = txtOrderNum.Text             '発注数
                End Select
                
            End With
            
            '@起動区分によって処理を分岐
            Select Case mstrStartKbn
                
        '@↓2018/06/28 (Thu) 15:21:38 T.Oide **************************************************
        '@        '@受入、分割の場合
        '@        Case CPstrOne, CPstrTwo
        '@
        '@            '@装置使用部材登録/分割
        '@            lblnAns = pubblnMatRegMaterial_Upd(ltypRegMaterial, lstrEditTime)
        '@-----------------------------------------------------------------------------------
                    
                '@受入
                Case CPstrOne
                    
                    '@選択した発注ID分回す
                    ''NSYS ToDo???
                    lvarTemp = Split(cmbOrderID.Value, vbTab)
                    For llngCnt = LBound(lvarTemp) To UBound(lvarTemp)
                        
                        '@処理対象は1つか
                        If cmbOrderID.ValueCount = 1 Then
                            '@1つの場合は、入力された部材管理IDをそのままｾｯﾄ
                            ltypRegMaterial.strMaterialLotID = txtMaterialLotID.Text    '新規部材管理ID
                        Else
                            '@複数の場合は、入力された部材管理IDに枝番を付けてｾｯﾄ
                            '2020/11/16 一括受入の際は連番開始を01からにする為+1する
                            ltypRegMaterial.strMaterialLotID = _
                                txtMaterialLotID.Text & CPstrHiphen & Format(llngCnt+1, "0#")          '新規部材管理ID-xx
                        End If
                
                        ltypRegMaterial.strMaterialOrderID = lvarTemp(llngCnt)          '発注ID
                        
                        '@装置使用部材登録/分割
                        lblnAns = pubblnMatRegMaterial_Upd(ltypRegMaterial, lstrEditTime)
                    
                    Next
                    
                '@分割の場合
                Case CPstrTwo
                    
                    '@装置使用部材登録/分割
                    lblnAns = pubblnMatRegMaterial_Upd(ltypRegMaterial, lstrEditTime)
        '@↑2018/06/28 (Thu) 15:21:38 T.Oide **************************************************
            
                '@変更の場合
                Case CPstrThree
                
                    '@権限ﾁｪｯｸ
                    lblnAns = prvblnAuthority_Chk()
                        
                    '@権限判定結果
                    If lblnAns = False Then
                        '@"権限なし"の場合
                    
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)
                    
                        '@処理中断
                        Exit Sub
                    End If
                
                    '@装置部材日付変更
                    lblnAns = pubblnMatChgMaterialDate_Upd(ltypRegMaterial, lstrEditTime)
                    
                '@発注の場合
                Case CPstrFour
                    
                    '@装置使用部材発注
                    lblnAns = pubblnMatOrderMaterial_Ins(ltypRegMaterial, lstrMaterialOrderID)
                    
            End Select
                    
            '@結果判定
            If lblnAns = False Then
                '@登録失敗の場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrCmdRegistClick)

                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(CMstrFormName, CMstrCmdRegistClick)
            
            '@最終更新日時を更新する(発注/登録/分割/日付変更共通)
            ptypRegMaterial.strEditTime = lstrEditTime
            
            '@部材登録/分割/日付変更判定ﾌﾗｸﾞをTrueに(True:登録、False:未登録)
            pblnMaterialRegistFlag = True
                
            '@メイン画面へ引継ぎ(ﾌｫｰｶｽの制御用)
            pstrMakeMaterialLotID = ltypRegMaterial.strMaterialLotID
            
            '@処理によってﾒｯｾｰｼﾞ表示&処理を選択
            Select Case mstrStartKbn
         
                '@受入の場合
                Case CPstrOne
                    '@ﾒｯｾｰｼﾞ表示"<TRM6FI>$$部材管理IDを[登録]しました。部材管理ID[%2]"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006F, CMstrRegist, txtMaterialLotID.Text)
                    '@成功ﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)
                    
                    '@画面を閉じる
                    Call cmdClose_Click(cmdClose, New EventArgs())

                '@分割の場合
                Case CPstrTwo
                    '@ﾒｯｾｰｼﾞ表示"<TRM6FI>$$部材管理IDを[分割]しました。部材管理ID[%2]"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006F, CMstrDivide, ltypRegMaterial.strMaterialLotID)
                    '@成功ﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)

                '@変更の場合
                Case CPstrThree
                    '@ﾒｯｾｰｼﾞ表示"<TRM6II>$$部材の日付を変更しました。部材管理ID[%1]"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006I, ltypRegMaterial.strMaterialLotID)
                    '@成功ﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)

                '@発注の場合
                Case CPstrFour
                    
                    '@ﾒｯｾｰｼﾞ内容編集
                    If ltypRegMaterial.strMaterialOrderNum = "1" Then
                        '@採番発注ID
                        lstrMsgString = lstrMaterialOrderID
                    Else
                        '@複数発注した場合
                        llngOrderNum = CLng(Strings.Right$(lstrMaterialOrderID, 2) - 1) + CLng(ltypRegMaterial.strMaterialOrderNum)
                        lstrMsgString = lstrMaterialOrderID & "～" & Strings.Left$(lstrMaterialOrderID, 11) & Format$(llngOrderNum, "00")
                    End If
                    
                    '@ﾒｯｾｰｼﾞ表示"<TRM6KI>$$発注IDを登録しました。発注ID[%1] 発注数[%2]"
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf006K, lstrMsgString, ltypRegMaterial.strMaterialOrderNum)
                    '@成功ﾒｯｾｰｼﾞ表示
                    Call pubVsfInfo_Disp(pstrDMsg)
                       
                    
                    '@メイン画面へ引継ぎ(ﾌｫｰｶｽの制御用)
                    pstrMakeMaterialOrderID = lstrMaterialOrderID
                    '@画面終了
                    Call cmdClose_Click(cmdClose, New EventArgs())
                    
            End Select
                  
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

    '****************************************************************************************
    '                                      *関数の記述*
    '****************************************************************************************
    '========================================Private=========================================

    '関数名：prvfrmxxEN01V1_Init
    '機　能：ﾒｲﾝﾌｫｰﾑ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 15:49:14 N.Kojima
    '更新日：2018/06/28 (Thu) 13:34:50 T.Oide
    '備　考：
    Private Sub prvfrmxxEN01V1_Init()

        Try
            
            '@ﾗﾍﾞﾙの初期化
            lblMaterialTypeID.Text = vbNullString        '部材種別ID
            lblMaterialID.Text = vbNullString            '部材ID
                
            '@ﾃｷｽﾄの初期化
        '@↓2018/06/28 (Thu) 13:34:45 T.Oide **************************************************
        '@    txtOrderID.Text = vbNullString                  '発注ID
            cmbOrderID.Text = vbNullString                  '発注ID
        '@↑2018/06/28 (Thu) 13:34:45 T.Oide **************************************************
            txtMaterialLotID.Text = vbNullString            '部材管理ID
                
            '@起動区分の判定(共通項目初期化)
            Select Case mstrStartKbn
                
                '@分割or変更
                Case CPstrTwo, CPstrThree
                    
                    '@発注IDﾃｷｽﾄを無効にする
        '@↓2018/06/28 (Thu) 13:35:40 T.Oide **************************************************
        '@            txtOrderID.Locked = True                            'ﾛｯｸ
        '@            txtOrderID.BackColor = CMlngGlayColor               'ﾊﾞｯｸｶﾗｰ
        '@            txtOrderID.GotBackColor = CMlngGlayColor            'ﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰ
        '@            txtOrderID.TabStop = False                          'Tabでﾌｫｰｶｽを取得しない
        '@-------------------------------------------------------------------------------------
                    cmbOrderID.Enabled = False                          'ﾛｯｸ
                    cmbOrderID.BackColor = SystemColors.ControlLight    'ﾊﾞｯｸｶﾗｰ
        '            cmbOrderID.GotBackColor = CMlngGlayColor           'ﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰ
                    cmbOrderID.TabStop = False                          'Tabでﾌｫｰｶｽを取得しない
        '@↑2018/06/28 (Thu) 13:35:40 T.Oide **************************************************
                    
                    '@発注数ﾃｷｽﾄを無効にする
                    txtOrderNum.Locked = True                            'ﾛｯｸ
                    txtOrderNum.BackColor = SystemColors.ControlLight    'ﾊﾞｯｸｶﾗｰ
                    txtOrderNum.GotBackColor = SystemColors.ControlLight 'ﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰ
                    txtOrderNum.TabStop = False                          'Tabでﾌｫｰｶｽを取得しない
                    
                    
                    '@連番関連ｺﾝﾄﾛｰﾙを表示&初期化
                    lblTitleTxtConsecutiveNum.Visible = True            '連番ﾀｲﾄﾙﾗﾍﾞﾙ表示
                    lblHiphen.Visible = True                            '"-"ﾊｲﾌﾝﾗﾍﾞﾙ表示
                    txtConsecutiveNum.Visible = True                    '連番ﾃｷｽﾄ表示
                    txtConsecutiveNum.Text = vbNullString
                        
                    '@分割起動の場合は、使用開始日時の無効化も行なう
                    If mstrStartKbn = CPstrTwo Then
                        
                        '@連番関連ｺﾝﾄﾛｰﾙを有効化
                        txtConsecutiveNum.Enabled = True
                        
                        '@製造日の初期化
                        calProductDate.Enabled = False                  'ﾛｯｸ
                        calProductDate.BackColor = SystemColors.ControlLight 'ﾊﾞｯｸｶﾗｰ
                        
                        '@受入日の初期化
                        calAcceptDate.Enabled = False                   'ﾛｯｸ
                        calAcceptDate.BackColor = SystemColors.ControlLight 'ﾊﾞｯｸｶﾗｰ
                    
                        '@使用開始日時の無効化
                        calStartUseDate.Enabled = False                 'ﾛｯｸ
                        calStartUseDate.BackColor = SystemColors.ControlLight 'ﾊﾞｯｸｶﾗｰ
                        medTime.Enabled = False
                        medTime.BackColor = SystemColors.ControlLight 
                        
                        '@現在日時取得ﾎﾞﾀﾝの無効化
                        cmdNowDate.Enabled = False
                    Else
                        '@変更での起動の場合(mstrStartKbn=3)
            
                        '@連番ﾃｷｽﾄの初期化
                        txtConsecutiveNum.Locked = True                             'ﾛｯｸ
                        txtConsecutiveNum.BackColor = SystemColors.ControlLight     'ﾊﾞｯｸｶﾗｰ
                        txtConsecutiveNum.GotBackColor = SystemColors.ControlLight  'ﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰ
                        txtConsecutiveNum.TabStop = False                           'Tabでﾌｫｰｶｽを取得しない

                    End If
                    
                    '@部材管理IDﾃｷｽﾄの初期化
                    txtMaterialLotID.Locked = True                              'ﾛｯｸ
                    txtMaterialLotID.BackColor = SystemColors.ControlLight      'ﾊﾞｯｸｶﾗｰ
                    txtMaterialLotID.GotBackColor = SystemColors.ControlLight   'ﾌｫｰｶｽ取得時ﾊﾞｯｸｶﾗｰ
                    txtMaterialLotID.TabStop = False                            'Tabでﾌｫｰｶｽを取得しない
                
                '@受入
                Case CPstrOne
            
                    '@発注IDﾃｷｽﾄを無効にする
        '@↓2018/06/28 (Thu) 13:37:10 T.Oide **************************************************
        '@            txtOrderID.Enabled = False
                    cmbOrderID.Enabled = False
        '@↑2018/06/28 (Thu) 13:37:10 T.Oide **************************************************
                    txtOrderNum.Enabled = False
                    txtOrderNum.BackColor = SystemColors.ControlLight 
                    txtOrderNum.GotBackColor = SystemColors.ControlLight 

                    '@連番関連ｺﾝﾄﾛｰﾙを非表示&無効化&初期化
                    lblTitleTxtConsecutiveNum.Visible = False   '連番ﾀｲﾄﾙﾗﾍﾞﾙ
                    lblHiphen.Visible = False                   '"-"ﾊｲﾌﾝﾗﾍﾞﾙ
                    txtConsecutiveNum.Visible = False           '連番ﾃｷｽﾄ
                    txtConsecutiveNum.Enabled = False
                    txtConsecutiveNum.Text = vbNullString
                
                    '@使用開始日時の無効化
                    calStartUseDate.Enabled = False                           'ﾛｯｸ
                    calStartUseDate.BackColor = SystemColors.ControlLight     'ﾊﾞｯｸｶﾗｰ
                    medTime.Enabled = False                                   '時刻
                    medTime.BackColor = SystemColors.ControlLight 
                    
                    '@現在日時取得ﾎﾞﾀﾝの無効化
                    cmdNowDate.Enabled = False
                
                '@発注
                Case CPstrFour
                
                    '@発注IDﾃｷｽﾄを無効にする
        '@↓2018/06/28 (Thu) 13:37:42 T.Oide **************************************************
        '@            txtOrderID.Enabled = False
                    cmbOrderID.Enabled = False
        '@↑2018/06/28 (Thu) 13:37:42 T.Oide **************************************************
                    txtOrderNum.Enabled = True
                    
                    '@部材管理IDﾃｷｽﾄを無効にする
                    txtMaterialLotID.Enabled = False
                    txtMaterialLotID.BackColor = SystemColors.ControlLight ' ColorTranslator.FromWin32(CMlngGlayColor)
                    
                    '@連番関連ｺﾝﾄﾛｰﾙを非表示&無効化&初期化
                    lblTitleTxtConsecutiveNum.Visible = False   '連番ﾀｲﾄﾙﾗﾍﾞﾙ
                    lblHiphen.Visible = False                   '"-"ﾊｲﾌﾝﾗﾍﾞﾙ
                    txtConsecutiveNum.Visible = False           '連番ﾃｷｽﾄ
                    txtConsecutiveNum.Enabled = False
                    txtConsecutiveNum.Text = vbNullString
                
                    '@製造日の初期化
                    calProductDate.Enabled = False                        'ﾛｯｸ
                    calProductDate.BackColor = SystemColors.ControlLight  'ﾊﾞｯｸｶﾗｰ
                
                    '@使用開始日時の無効化
                    calStartUseDate.Enabled = False                       'ﾛｯｸ
                    calStartUseDate.BackColor = SystemColors.ControlLight 'ﾊﾞｯｸｶﾗｰ
                    medTime.Enabled = False                               '時刻
                    medTime.BackColor = SystemColors.ControlLight 
                    
                    '@現在日時取得ﾎﾞﾀﾝの無効化
                    cmdNowDate.Enabled = False
                    
                    '@受入日のﾀｲﾄﾙを「受入予定日」にする
                    lblTitleAccept.Text = CMstrAcceptPlanDate
                    
            End Select
                
            '@ｶﾚﾝﾀﾞｰの初期化
            calProductDate.Value = CPstrNullDate             '製造日
            calAcceptDate.Value = CPstrNullDate              '受入日
            calStartUseDate.Value = CPstrNullDate            '使用開始日時
            
            '@使用開始日時(時間ﾏｽｸｴﾃﾞｨｯﾄﾎﾞｯｸｽ)の初期化
            medTime.Text = CPstrNullTime
                
            '@ﾎﾞﾀﾝの初期化
            cmdRegist.Enabled = False
            
            '@終了時にValidateｲﾍﾞﾝﾄを実行しない
            cmdClose.CausesValidation = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01V1_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfrmxxEN01V1_Disp
    '機　能：引継ぎ情報表示
    '引　数：なし
    '戻り値：なし
    '作成日：2006/04/14 (Fri) 17:01:56 N.Kojima
    '更新日：2018/06/28 (Thu) 14:55:01 T.Oide
    '備　考：
    Private Sub prvfrmxxEN01V1_Disp()

    '@↓2018/06/28 (Thu) 14:54:54 T.Oide **************************************************
        Dim llngCnt     As Integer
        Dim llngChk     As Integer
    '@↑2018/06/28 (Thu) 14:54:54 T.Oide **************************************************

        Try
                
            '@引継ぎ情報の表示
            With ptypRegMaterial
                
                lblMaterialTypeID.Text = .strMaterialTypeID      '部材種別ID
                lblMaterialID.Text = .strMaterialID              '部材ID
                        
                Select Case mstrStartKbn
                    
                    '@分割、変更で起動(mstrStartKbn=2、mstrStartKbn=3)
                    Case CPstrTwo, CPstrThree
                    
                        txtMaterialLotID.Text = .strMaterialLotID       '部材管理ID
                        If IsDate(.strProductionDate) Then
                            calProductDate.Value = Format$(CDate(.strProductionDate), CPstrDateTimeYMD)    '製造日
                        Else
                            calProductDate.Value = .strProductionDate
                        End If
                        If IsDate(.strAcceptanceDate) Then
                            calAcceptDate.Value = Format$(CDate(.strAcceptanceDate), CPstrDateTimeYMD)     '受入日
                        Else
                            calAcceptDate.Value = .strAcceptanceDate
                        End If
                            
                        '@使用開始日時がNULLじゃない場合、値をｾｯﾄ
                        If .strUseTime <> vbNullString Then
                            calStartUseDate.Value = Format$(CDate(Mid$(.strUseTime, 1, 10)), CPstrDateTimeYMD)
                            medTime.Text = Format$(CDate(Mid$(.strUseTime, 12, 5)), CPstrTimeFormatHM)
                        End If
                        
                        '@連番ﾃｷｽﾄが有効な場合(mstrStartKbn=2)はﾌｫｰｶｽをｾｯﾄする
                        If txtConsecutiveNum.Enabled = True And mstrStartKbn = CPstrTwo Then
                            '@連番にﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(txtConsecutiveNum)
                        Else
                            '@連番ﾃｷｽﾄが無効な場合(mstrStartKbn=3)
                            
                            '@各種ｺﾝﾄﾛｰﾙの表示/有効化
                            calStartUseDate.Enabled = True      '使用開始日時(年月日)
                            medTime.Enabled = True              '使用開始日時(時刻)
                            cmdNowDate.Enabled = True           '現在日時取得
                        
                            '@使用開始日時にﾌｫｰｶｽｾｯﾄ
                            Call pubSetFocus(calStartUseDate)
                        End If
                        
                    '@受入での起動の場合(mstrStartKbn=1)
                    Case CPstrOne
                        '@受入日をｾｯﾄ
                        calAcceptDate.Value = .strAcceptanceDate
                        '@発注IDをｾｯﾄ
        '@↓2018/06/28 (Thu) 13:38:11 T.Oide **************************************************
        '@                txtOrderID.Text = .strMaterialOrderID
        '@-------------------------------------------------------------------------------------
                        '@選択ﾘｽﾄに発注IDを入れる
                        With cmbOrderID
                    
                            .Clear                                                      'ｸﾘｱ
                            .Enabled = True                                             '有効
                            .DirectInput = False                                        '直接入力不可(False)
                            .SelectMode = CMlngCMbSelectMode                            '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                            .AllSelectButton = True                                     '全選択ﾎﾞﾀﾝ表示
                            .DispCols = CMlngCmbDispCols                                'ｸﾞﾘｯﾄﾞ表示列数
                            .GroupCols = CMlngCmbDispCols                               '列方向のﾚｺｰﾄﾞ数
        '                    .GroupRows = mlngProductListCnt                             '行方向のﾚｺｰﾄﾞ数
                            .AddedComment = CMstrCmbAddedComment                        '"選択"文字列
                            .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, _
                                             .Font.Style, .Font.Unit)                   'ﾌｫﾝﾄｻｲｽﾞ
                            .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _
                                                 .GridFont.Style, .GridFont.Unit)        'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                            .RowHeight = CMlngCmbRowHeight                              '行の高さ
                            .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter  '左寄中央揃え
                    
                            '@親画面のｸﾞﾘｯﾄﾞを回す
                            For llngCnt = 1 To frmxxEN01V0.Instance.vsfMaterialList.Rows.Count - 1
                    
                                '@選択ﾃﾞｰﾀと同じか(該当のみﾁｪｯｸのみOnするため）
                                If ptypRegMaterial.strMaterialOrderID = _
                                   frmxxEN01V0.Instance.vsfMaterialList.GetData(llngCnt, 1) Then
                                    llngChk = CMstrCmbCheckOn
                                Else
                                    llngChk = CMstrCmbCheckOff
                                End If
                                
                                '@状態が「未」をﾘｽﾄに入れる
                                If frmxxEN01V0.Instance.vsfMaterialList.GetData(llngCnt, 2) = "未" Then
                    
                                    '@機種ｺﾝﾎﾞ内容の設定(機種ID/機種名/ﾘｽﾄIndex/NULL/ﾁｪｯｸBOXのﾃﾞﾌｫﾙﾄﾁｪｯｸ(1：ON))
                                    .AddItem(frmxxEN01V0.Instance.vsfMaterialList.GetData(llngCnt, 1) & vbTab & _
                                             frmxxEN01V0.Instance.vsfMaterialList.GetData(llngCnt, 1) & vbTab & _
                                             llngCnt & vbTab & _
                                             vbNullString & vbTab & _
                                             llngChk)
                                End If
                    
                            Next llngCnt
                        End With
                        
                        '@ﾃｷｽﾄ部分に情報をｾｯﾄ
                        cmbOrderID.Text = .strMaterialOrderID
                            
        '@               cmbOrderID.AddedComment = CMstrCmbAddedComment        '" 項目選択"
        '@               cmbOrderID.Text = .ListCount & CMstrCmbAddedComment   '"N項目選択"(Nは選択数)
                        
        '@↑2018/06/28 (Thu) 13:38:11 T.Oide **************************************************

                    '@発注での起動の場合(mstrStartKbn=4)
                    Case CPstrFour
                        '@発注IDをｾｯﾄ
        '@↓2018/06/28 (Thu) 13:38:55 T.Oide **************************************************
        '@                txtOrderID.Text = "発注済-" & Format$(Now, "YYMMDD") & "-xx"
                        cmbOrderID.Text = "発注済-" & Format$(Now, "yyMMdd") & "-xx"
        '@↑2018/06/28 (Thu) 13:38:55 T.Oide **************************************************

                End Select
                        
                '@どの機能の起動時も、初回は確定ﾎﾞﾀﾝ無効
                cmdRegist.Enabled = False
                        
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01V1_Disp"
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
    '作成日：2006/04/14 (Fri) 17:05:24 N.Kojima
    '更新日：2018/06/28 (Thu) 16:59:22 T.Oide
    '備　考：
    Private Function prvblnInput_Chk() As Boolean
        
        Dim lstrErrMsg              As String       'ｴﾗｰMsg表示用
        Dim lstrCombMatrialLotID    As String       '「部材管理ID + "-" + 連番」格納用
        
        Try
            
            '@初期化
            prvblnInput_Chk = False
                
            '@部材管理ID(受入、分割、変更時)、発注IDのﾁｪｯｸ
            '@起動区分により処理を分岐
            Select Case mstrStartKbn
                
                '@受入、分割、変更の場合
                Case CPstrOne, CPstrTwo, CPstrThree
            
                    '@部材管理IDがNULLの場合はNG
                    If txtMaterialLotID.Text = vbNullString Then
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007X, lblTitleMaterialLotID.Text)
                        '@"<TRM7XW>$$[%1]が入力されていません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        Exit Function
                    Else
                        '@部材管理IDがNULLではない場合
                    
                        '@部材管理IDが20桁以上ある場合はNG
                        If LenB(txtMaterialLotID.Text) > txtMaterialLotID.ChrMaxByte Then
                        
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007W, lblTitleMaterialLotID.Text, _
                                                            txtMaterialLotID.ChrMaxByte)
                            '@"<TRM7WW>$$[%1]は半角[%2]文字以内で入力してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit Function
                        End If
                        
                        '@部材管理IDの前後にｽﾍﾟｰｽ(半角、全角)が存在する場合はNG
                        If Strings.Left$(txtMaterialLotID.Text, 1) = CPstrSpace Or _
                            Strings.Right$(txtMaterialLotID.Text, 1) = CPstrSpace Or _
                            Strings.Left$(txtMaterialLotID.Text, 1) = CPstrZenkakuSpace Or _
                            Strings.Right$(txtMaterialLotID.Text, 1) = CPstrZenkakuSpace Then
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0094, lblTitleMaterialLotID.Text)
                            '@"<TRM94W>$$[%1]の前後にスペースが存在します。削除して下さい。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit Function
                        End If
                    End If
                    
        '@↓2018/06/28 (Thu) 16:43:32 T.Oide **************************************************
                    '@受入れで、発注IDが0個選択か
                    If mstrStartKbn = CPstrOne And _
                       cmbOrderID.Text = CMstrCmbAddedCommentNone Then
                        
                        '@"<TRM150W>$$発注IDが未選択です。設定を見直してください。"
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0150)
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        Exit Function
                        
                    End If
        '@↑2018/06/28 (Thu) 16:43:32 T.Oide **************************************************
                    
                
                '@発注の場合
                Case CPstrFour
                    
        '@↓2018/06/28 (Thu) 13:40:18 T.Oide **************************************************
        '@            '@発注IDがNULLの場合はNG
        '@            If txtOrderID.Text = vbNullString Then
        '@
        '@                '@表示ﾒｯｾｰｼﾞ変換
        '@                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007X, lblOrderIDTitle.Caption)
        '@                '@"<TRM7XW>$$[%1]が入力されていません。設定を見直してください。"
        '@                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxEN01V1.Caption, True, 16)
        '@
        '@                Exit Function
        '@            Else
        '@                '@発注IDがNULLではない場合
        '@
        '@                '@発注IDが20桁以上ある場合はNG
        '@                If LenB(StrConv(txtOrderID.Text, vbFromUnicode)) > txtOrderID.ChrMaxByte Then
        '@
        '@                    '@表示ﾒｯｾｰｼﾞ変換
        '@                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007W, lblOrderIDTitle.Caption, _
        '@                                                    txtOrderID.ChrMaxByte)
        '@                    '@"<TRM7WW>$$[%1]は半角[%2]文字以内で入力してください。"
        '@                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxEN01V1.Caption, True, 16)
        '@
        '@                    Exit Function
        '@                End If
        '@
        '@                '@発注IDの前後にｽﾍﾟｰｽ(半角、全角)が存在する場合はNG
        '@                If Left$(txtOrderID.Text, 1) = CPstrSpace Or _
        '@                    Right$(txtOrderID.Text, 1) = CPstrSpace Or _
        '@                    Left$(txtOrderID.Text, 1) = CPstrZenkakuSpace Or _
        '@                    Right$(txtOrderID.Text, 1) = CPstrZenkakuSpace Then
        '@
        '@                    '@表示ﾒｯｾｰｼﾞ変換
        '@                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0094, lblOrderIDTitle.Caption)
        '@                    '@"<TRM94W>$$[%1]の前後にスペースが存在します。削除して下さい。"
        '@                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxEN01V1.Caption, True, 16)
        '@
        '@                    Exit Function
        '@                End If
        '@            End If
        '@-----------------------------------------------------------------------------------------------

                    '@発注IDがNULLの場合はNG
                    If cmbOrderID.Text = vbNullString Then
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007X, lblOrderIDTitle.Text)
                        '@"<TRM7XW>$$[%1]が入力されていません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        Exit Function
                    Else
                        '@発注IDがNULLではない場合
                    
                        '@発注IDが20桁以上ある場合はNG
                        If LenB(cmbOrderID.Text) > 20 Then
                        
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007W, lblOrderIDTitle.Text, _
                                                            "20")
                            '@"<TRM7WW>$$[%1]は半角[%2]文字以内で入力してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit Function
                        End If
                        
                        '@発注IDの前後にｽﾍﾟｰｽ(半角、全角)が存在する場合はNG
                        If Strings.Left$(cmbOrderID.Text, 1) = CPstrSpace Or _
                            Strings.Right$(cmbOrderID.Text, 1) = CPstrSpace Or _
                            Strings.Left$(cmbOrderID.Text, 1) = CPstrZenkakuSpace Or _
                            Strings.Right$(cmbOrderID.Text, 1) = CPstrZenkakuSpace Then
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0094, lblOrderIDTitle.Text)
                            '@"<TRM94W>$$[%1]の前後にスペースが存在します。削除して下さい。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit Function
                        End If
                    End If
        '@↑2018/06/28 (Thu) 13:40:18 T.Oide **************************************************
                    
                    '@発注IDがNULLの場合はNG
                    If txtOrderNum.Text = vbNullString Or _
                            txtOrderNum.Text = "0" Then
                            
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007X, lblOrderNumTitle.Text)
                        '@"<TRM7XW>$$[%1]が入力されていません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        Exit Function
                    End If
                    
            End Select
                
            '@分割での起動の場合は「連番」もﾁｪｯｸ
            If mstrStartKbn = CPstrTwo Then
                '@連番がNULLの場合もNG
                If txtConsecutiveNum.Text = vbNullString Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007X, lblTitleTxtConsecutiveNum.Text)
                    '@"<TRM7XW>$$[%1]が入力されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                    Exit Function
                Else
                    '@連番がNULLではない場合
                
                    '@連番が2桁以上ある場合もNG
                    If LenB(txtConsecutiveNum.Text) > txtConsecutiveNum.ChrMaxByte Then
                    
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007W, lblTitleTxtConsecutiveNum.Text, _
                                                        txtConsecutiveNum.ChrMaxByte)
                        '@"<TRM7WW>$$[%1]は半角[%2]文字以内で入力してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                        Exit Function
                    Else
                        '@「部材管理ID + "-" + 連番」を変数に格納。※長いから。
                        lstrCombMatrialLotID = txtMaterialLotID.Text & CPstrHiphen & txtConsecutiveNum.Text
                    
                        '@「部材管理ID + "-" + 連番」が20桁を超えている場合もNG
                        If LenB(lstrCombMatrialLotID) > txtMaterialLotID.ChrMaxByte Then
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007Z, lstrCombMatrialLotID)
                            '@"<TRM7ZW>$$分割登録される部材管理ID[%1]が20桁を超えるため、$分割登録を行なうことができません。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                            Exit Function
                        End If
                        
                        '@連番の前後にｽﾍﾟｰｽ(半角、全角)が存在する場合はNG
                        If Strings.Left$(txtConsecutiveNum.Text, 1) = CPstrSpace Or _
                            Strings.Right$(txtConsecutiveNum.Text, 1) = CPstrSpace Or _
                            Strings.Left$(txtConsecutiveNum.Text, 1) = CPstrZenkakuSpace Or _
                            Strings.Right$(txtConsecutiveNum.Text, 1) = CPstrZenkakuSpace Then
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0094, lblTitleTxtConsecutiveNum.Text)
                            '@"<TRM94W>$$[%1]の前後にスペースが存在します。削除して下さい。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            Exit Function
                        End If
                    End If
                End If
            End If
                
            '@部材管理ID(受入、分割、変更時)、製造日/受入日(受入予定日)のﾁｪｯｸ
            '@起動区分により処理を分岐
            Select Case mstrStartKbn
                
                '@受入、分割、変更の場合
                Case CPstrOne, CPstrTwo, CPstrThree

                    '@製造日,受入日がNULLの場合はNG
                    If calProductDate.Value = CPstrNullDate Or _
                        calAcceptDate.Value = CPstrNullDate Then
                        
                        '@両方ともNULLか
                        If calProductDate.Value = CPstrNullDate And calAcceptDate.Value = CPstrNullDate Then
                            lstrErrMsg = lblTitleProduct.Text & CPstrComma & lblTitleAccept.Text
                        Else
                            '@製造日のみNULLか
                            If calProductDate.Value = CPstrNullDate Then
                                lstrErrMsg = lblTitleProduct.Text
                            Else
                                '@受入日のみNULL
                                lstrErrMsg = lblTitleAccept.Text
                            End If
                        End If
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007X, lstrErrMsg)
                        '@"<TRM7XW>$$[%1]が入力されていません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        Exit Function
                    Else
                        '@製造日,受入日がNULLではない場合
                    
                        '@「製造日 >= 受入日」の場合はNG
                        If calProductDate.Value >= calAcceptDate.Value Then
                            
                            '@「同日,未来」の文字列作成
                            lstrErrMsg = CMstrSameDay & CPstrComma & CMstrFutureDays
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007Y, lblTitleProduct.Text, _
                                                            lblTitleAccept.Text, lstrErrMsg)
                            '@"<TRM7YW>$$[%1]は[%2]より[%3]の日付は指定できません。設定を見直してください。"
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                            Exit Function
                        End If
                    End If
                
                '@発注で起動の場合
                Case CPstrFour
                    '@受入予定日がNULLの場合はNG
                    If calAcceptDate.Value = CPstrNullDate Then
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007X, lblTitleAccept.Text)
                        '@"<TRM7XW>$$[%1]が入力されていません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        Exit Function
                    End If
                
            End Select
                    
            '@使用開始日時がNULLの場合はNG
            If mstrStartKbn = CPstrThree Then
            
                If calStartUseDate.Value = CPstrNullDate Or _
                    medTime.Text = CPstrNullTime Then
            
                    '@ｴﾗｰMsg作成
                    lstrErrMsg = lblTitleStartUseTime.Text
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007X, lstrErrMsg)
                    '@"<TRM7XW>$$[%1]が入力されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    Exit Function
                Else
                    '@使用開始日時がNULLではない場合
                
                    '@「(製造日 >=)受入日 > 使用開始日時」の場合はNG
                    If calAcceptDate.Value > calStartUseDate.Value Then
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007Y, lblTitleAccept.Text, _
                                                        lblTitleStartUseTime.Text, CMstrFutureDays)
                        '@"<TRM7YW>$$[%1]は[%2]より[%3]の日付は指定できません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                        Exit Function
                    End If
                End If
            End If
            
            '@成功(ﾁｪｯｸOK)を返す
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

    '関数名：prvblnAuthority_Chk
    '機　能：装置部材日付変更権限ﾁｪｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/23 (Fri) 16:21:46 N.Kojima
    '更新日：2006/06/23 (Fri) 16:21:46
    '備　考：
    Private Function prvblnAuthority_Chk() As Boolean

        Dim lblnAns                 As Boolean              '戻り値判定用
        Dim lstrFunctionID          As String               '機能ID
        Dim lstrActionID            As String               'ｱｸｼｮﾝID
        Dim lstrEmpID               As String               '作業者ID
        Dim lstrEmpName             As String               '作業者名
        Dim lstrSBID                As String               'ｼｽﾃﾑﾌﾞﾛｯｸ

        Try
                    
            '@戻り値の初期化
            prvblnAuthority_Chk = False
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(CMstrFormName, CMstrPrvblnAuthorityChk)
            
            Me.KeyPreview = False
            
            '@実行権限の処理を追加
            lstrFunctionID = CPstrKeyEN01V0             '機能ID：EN01V0
            lstrActionID = CPstrUsePeriodOverMaterial   'ｱｸｼｮﾝID：期限超過部材使用
            lstrEmpID = pstrUserID                      'ﾕｰｻﾞｰID
            lstrEmpName = vbNullString                  'ﾕｰｻﾞｰ名
            lstrSBID = pstrSBID                         'ｼｽﾃﾑﾌﾞﾛｯｸ

            '@実行権限ﾁｪｯｸ
            lblnAns = pubAuthority_Chk(lstrFunctionID, lstrActionID, lstrEmpID, lstrEmpName, lstrSBID)
            
            Me.KeyPreview = True
            
            '@結果判定
            If lblnAns = False Then
                '@権限が"なし"の場合
            
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(CMstrFormName, CMstrPrvblnAuthorityChk)

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005D, lstrEmpName, CPstrUsePeriodOverMaterial)
                '@"<TRM5DW>$$ユーザー[%1]には、[%2]を行う権限がありません。処理を中断します。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@戻り値を"False=権限なし"で設定
                prvblnAuthority_Chk = False
            Else
                '@権限が"あり"の場合
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(CMstrFormName, CMstrPrvblnAuthorityChk)
                
                '@戻り値を"True=権限あり"で設定
                prvblnAuthority_Chk = True
            End If

            Exit Function

        Catch ex As Exception

            Me.KeyPreview = True

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnAuthority_Chk"
                .strErrMessage = vbNullString
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

    '関数名：textbox_Enter
    '機　能：ハイライト処理用 フォーカス取得イベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub textbox_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles medTime.Enter
        'NSYS フォーカスインでハイライト処理 開始
        sender.ScrollToCaret()
        If (sender.MouseButtons And MouseButtons.Left) = MouseButtons.Left Then
            sender.Tag("OnHighlight") = True
        Else
            sender.Tag("OnHighlight") = False
        End If
    End Sub

    '関数名：textbox_Leave
    '機　能：ハイライト処理用 フォーカス喪失イベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考
    Private Sub textbox_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles medTime.Leave
        'NSYS マウス選択でのハイライトをキャンセルする
        sender.Tag("OnHighlight") = False
    End Sub

    '関数名：textbox_KeyUp
    '機　能：ハイライト処理用 キーアップイベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考
    Private Sub textbox_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles medTime.KeyUp
        'NSYS Tabキー押下の場合
        If e.KeyCode = Keys.Tab Then
            'NSYS マウス選択でのハイライトをキャンセルする
            sender.Tag("OnHighlight") = False
        End If
    End Sub

    '関数名：textbox_MouseDown
    '機　能：ハイライト処理用 マウスダウンイベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub textbox_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles medTime.MouseDown
        'NSYS MouseDown時のカーソル位置を保持
        sender.Tag("MouseDownStart") = sender.SelectionStart
    End Sub

    '関数名：textbox_MouseUp
    '機　能：ハイライト処理用 マウスアップイベント処理
    '作成日：2018/11/23 (Fri) 13:00:00 NSYS
    '更新日：
    '備　考：
    Private Sub textbox_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles medTime.MouseUp
        Dim curpos As Integer   'NSYS ｶｰｿﾙ位置

        '@ﾊｲﾗｲﾄするになっている場合
        If CBool(sender.Tag("OnHighlight")) = True Then
            ''@ｶｰｿﾙ位置までﾊｲﾗｲﾄ表示
            curpos = sender.SelectionStart
            sender.SelectionStart = 0 
            If curpos < CInt(sender.Tag("MouseDownStart")) Then
                'NSYS 左ドラッグ時
                sender.SelectionLength = curpos
            Else
                sender.SelectionLength = curpos + sender.SelectedText.Length
            End If
            sender.ScrollToCaret()
            sender.Tag("OnHighlight") = False
        End If
    End Sub

    '関数名：cursor_Enter
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考：Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles cmbOrderID.Enter,
                                                                       cmdNowDate.Enter,
                                                                       cmdClose.Enter,
                                                                       cmdRegist.Enter,
                                                                       txtMaterialLotID.Enter,
                                                                       calProductDate.Enter,
                                                                       calAcceptDate.Enter,
                                                                       txtConsecutiveNum.Enter,
                                                                       calStartUseDate.Enter,
                                                                       medTime.Enter,
                                                                       txtOrderNum.Enter                

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
