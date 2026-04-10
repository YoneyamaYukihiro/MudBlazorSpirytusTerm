'ﾌｧｲﾙ名：xxCM00L0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：機種ｴﾝﾄﾘ一覧(ﾂｰﾙｻｲｽﾞ）
'作成日：2004/09/24 (Fri) 12:14:23 N.Kasai
'更新日：2009/02/25 (Wed) 18:57:04 N.Kojima
'備　考：親ﾌｫｰﾑへの値渡しは Public で宣言(ptypLotRlst)
'　　　：2005/06/16 (Thu) 13:43:32 S.Deguchi    SetFocus対応でOnError処理追加＆ｸﾞﾘｯﾄﾞﾌｫｰｶｽ初期位置をﾀｲﾄﾙへ
'Copyright(C)2003-, SEIKO EPSON CORPORATION.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00L0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00L0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00L0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00L0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00L0)
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
    '======================================Private==========================================
    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = "CM00L0"            'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    '@↓2009/02/25 (Wed) 18:57:12 N.Kojima **************************************************
    'Private Const CMstrmas_pdentrylistVer               As String = "02.02"            'ﾏｽﾀ工順一覧
    Private Const CMstrmas_pdentrylistVer               As String = "03.00"             'ﾏｽﾀ工順一覧
    '@↑2009/02/25 (Wed) 18:57:12 N.Kojima **************************************************
    Private Const CMstrlot_sppdentrylistVer             As String = "01.00"             '特殊工順取得

    '@vsfEntryListの定数宣言（ｶﾗﾑ）
    Private Const CMvsfEntryListColEntryApplyTime       As Integer = 0                  '適用日時
    Private Const CMvsfEntryListColEntryID              As Integer = 1                  'ｴﾝﾄﾘID
    Private Const CMvsfEntryListColEntryName            As Integer = 2                  'ｴﾝﾄﾘ名
    Private Const CMvsfEntryListColEntryComment         As Integer = 3                  'ｴﾝﾄﾘｺﾒﾝﾄ
    Private Const CMvsfEntryListColMaxWfCount           As Integer = 4                  '最大WF枚数

    '@vsfEntryListの定数宣言（表示幅）
    Private Const CMvsfEntryListColWEntryApplyTime      As Integer = 133                '適用日時
    Private Const CMvsfEntryListColWEntryID             As Integer = 133                'ｴﾝﾄﾘID
    Private Const CMvsfEntryListColWEntryName           As Integer = 133                'ｴﾝﾄﾘ名
    Private Const CMvsfEntryListColWEntryComment        As Integer = 133                'ｴﾝﾄﾘｺﾒﾝﾄ
    Private Const CMvsfEntryListColWMaxWfCount          As Integer = 33                 '最大WF枚数

    '@vsfEntryListの定数宣言（ﾀｲﾄﾙ）
    Private Const CMvsfEntryListColTEntryApplyTime      As String = "適用日時"          '適用日時
    Private Const CMvsfEntryListColTEntryID             As String = "エントリID"        'ｴﾝﾄﾘID
    Private Const CMvsfEntryListColTEntryName           As String = "エントリ名"        'ｴﾝﾄﾘ名
    Private Const CMvsfEntryListColTEntryComment        As String = "コメント"          'ｴﾝﾄﾘｺﾒﾝﾄ

    '@その他ｸﾞﾘｯﾄの定数
    Private Const CMvsfEntryListCol                     As Integer = 5                  'ｶﾗﾑ数
    Private Const CMvsfEntryListTRow                    As Integer = 0                  'ﾀｲﾄﾙ行
    Private Const CMvsfEntryListHFontSize               As Integer = 11                 'ﾍｯﾀﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMvsfEntryListHdHeight                As Integer = 20                 '行の高さ（ﾍｯﾀﾞｰのみ）
    Private Const CMvsfEntryListHeight                  As Integer = 24                 '行の高さ
    Private Const CMvsfEntryListAll                     As Integer = -1                 '表全体

    '@起動区分の定数宣言
    Private Const CMlngPDEntry                          As Integer = 0                  '機種ｴﾝﾄﾘ表示
    Private Const CMlngPDEntryALL                       As Integer = 1                  '機種ｴﾝﾄﾘ全件表示
    Private Const CMlngUserEntry                        As Integer = 2                  'ﾕｰｻﾞｰｴﾝﾄﾘ表示

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mblnCheckFlg                                As Boolean                  'ﾁｪｯｸﾌﾗｸﾞ
    Private mstrEntryName                               As String                   'ｴﾝﾄﾘ名退避領域
    Private mlngSideScrollFlag                          As Integer                  '横ｽｸﾛｰﾙの使用ﾌﾗｸﾞ(1:発生/2:不要)
    Private mtypEntryList                               As List(Of EntryList)       'ﾏｽﾀ工順一覧格納用
    Private mlngEntryListCnt                            As Integer                  'ﾏｽﾀ工順ﾘｽﾄｶｳﾝﾄ
    Private mtypChgSort                                 As ChgSort                  'ｿｰﾄ保持用
    Private mblnFormLoadFlag                            As Boolean                  'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ

    Private buttonProcessing                            As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                  'NSYS システムコマンドでの画面クローズ
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
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/15 (Fri) 15:03:39 N.Kasai
    '更新日：2004/10/19 (Tue) 09:19:24 N.Kasai
    '備　考：2004/10/19 (Tue) 09:19:24 N.Kasai  0件表示追加
    Private Sub Form_Load()

        Dim lstrFormName        As String               'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim lblnAns             As Boolean              '汎用戻り値(True/False)

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            ''@暗黙でFormが表示されたかどうかを判定する
            'If Not Me Is Me Then
            ''@暗黙で表示されていない場合
            '    '@暗黙でFormをLoad
            '    Load Me
            '    
            '    '@Escﾎﾞﾀﾝを有効
            '    Me.CancelButton = cmdClose
            '    
            '    Exit Sub
            'End If
            
            '@ﾌﾗｸﾞ初期化(ﾃﾞﾌｫﾙﾄTrueで確定ﾎﾞﾀﾝが押下された時のみFalse)
            pblnCancel = True
            
            '@画面初期化
            Call prvfrmxxCM00L0_Init()
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化
            mblnFormLoadFlag = False
            
            '@構造体初期化
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                .typChgSortList = New List(Of ChgSortList)
                
                '@列幅変更ﾌﾗｸﾞ（未変更）
                .blnChgWidth = False
                
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            '@ﾌｫｰﾑ,ｲﾍﾞﾝﾄ名称の取得
            lstrFormName = Me.Name
            lstrEventName = "Form_Load"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ｴﾝﾄﾘ情報取得
            lblnAns = prvblnLotEntryList_Sel
            '@結果判定
            If lblnAns = True Then
                '@件数の判定
                If mlngEntryListCnt = 0 Then
                '@件数が0件の場合
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = cmdClose
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                        
                    '@Form_Loadﾌﾗｸﾞ（異常）
                    pblnFormLoad = False
                
                    '@該当件数が0件の場合ﾀﾞｲｱﾛｸﾞでｲﾝﾌｫﾒｰｼｮﾝ表示する
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0029, mlngEntryListCnt)
                    
                    '@publngMsgBoxInfo("メッセージコード：C_I29%0$$該当件数 ： 0 件")
                    Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
                Else
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                    
                    '@Form_Loadﾌﾗｸﾞ（正常）
                    pblnFormLoad = True
                End If
            Else
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@Form_Loadﾌﾗｸﾞ（異常）
                pblnFormLoad = False
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Load"                  '処理名"
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
    '作成日：2005/06/16 (Thu) 14:13:33 S.Deguchi
    '更新日：2005/06/16 (Thu) 14:13:33
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理判別
            If mblnFormLoadFlag = False Then
                '@ﾌﾗｸﾞ戻し
                mblnFormLoadFlag = True
            
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
            
                '@一覧表示
                Call prvvsfEntryList_Disp()
                
                '@ﾌｫｰｶｽ処理
                If vsfEntryList.Enabled = True Then
                    If vsfEntryList.Rows.Count > 1 Then
                        '@一覧へﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfEntryList)
                    Else
                        '@閉じるﾎﾞﾀﾝへ
                        Call pubSetFocus(cmdClose)
                    End If
                Else
                    '@閉じるﾎﾞﾀﾝへ
                    Call pubSetFocus(cmdClose)
                End If
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Activate"              '処理名"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
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
    '作成日：2004/07/27 (Tue) 10:20:24 N.Kojima
    '更新日：2004/07/29 (Thu) 19:37:42 N.Kojima
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

            '@選択確定ﾎﾞﾀﾝが非表示の場合
            If cmdChoice.Visible = False Then
                '@Enterｷｰの場合
                Select Case e.KeyCode
                    Case Keys.Return
                        SendKeys.SendWait(CPstrSendKeysTab)
                        e.Handled = True
                End Select
            Else
                '@Enterｷｰの場合
                Select Case e.KeyCode
                    Case Keys.Return
                        '@一覧にﾌｫｰｶｽがある場合
                        If ActiveControl.Name = vsfEntryList.Name Then
                            '@ﾃﾞｰﾀ行の場合
                            If vsfEntryList.Row >= vsfEntryList.Rows.Fixed Then
                                '@選択確定処理
                                Call cmdChoice_Click(cmdChoice, New EventArgs)
                            End If
                        Else
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                        End If
                End Select
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_KeyDown"               '処理名"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：画面終了処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：終了方法
    '戻り値：なし
    '作成日：2004/10/15 (Fri) 15:11:01 N.Kasai
    '更新日：2004/10/15 (Fri) 15:11:01
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If

             '@ｿｰﾄ保持用構造体のｸﾘｱ
            mtypChgSort.typChgSortList =  Nothing
            
            '@構造体のｸﾘｱ
            mtypEntryList = Nothing

            '@ﾌｫｰﾑを閉じる
            'Me.Close()

            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定f
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
    '作成日：2004/07/28 (Wed) 08:57:21 N.Kojima
    '更新日：2004/07/28 (Wed) 08:57:21
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
            
            '@ﾌｫｰﾑを閉じる
            Me.Close()

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdClose_Click"             '処理名"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdChoice_Click
    '機　能：選択確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 08:57:34 N.Kojima
    '更新日：2004/07/28 (Wed) 08:57:34
    '備　考：
    Private Sub cmdChoice_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdChoice.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@行が選択されていない場合は格納しない
            If vsfEntryList.Row >= 1 Then
                '@ｴﾝﾄﾘ名・ｴﾝﾄﾘIDを格納
                pstrEntryName = vsfEntryList.GetData(vsfEntryList.Row, CMvsfEntryListColEntryName)
                pstrEntryID = vsfEntryList.GetData(vsfEntryList.Row, CMvsfEntryListColEntryID)
                pstrMaxWFCount = vsfEntryList.GetData(vsfEntryList.Row, CMvsfEntryListColMaxWfCount)
                
                '@ﾌｫｰﾑを閉じる
                Me.Close()
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdChoice_Click"            '処理名"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNowList_Click
    '機　能：最新取得ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 10:01:49 N.Kojima
    '更新日：2004/07/29 (Thu) 10:56:30 N.Kojima
    '備　考：
    Private Sub cmdNowList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowList.Click
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            Dim lstrFormName        As String               'ﾌｫｰﾑ名（ﾚｽﾎﾟﾝｽ用）
            Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
            Dim lblnAns             As Boolean              '汎用戻り値(True/False)
            
            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                Exit Sub
            End If
            
            '@ﾌｫｰﾑのﾛｯｸ中は処理を行わない
            If Me.Enabled = False Then
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ,ｲﾍﾞﾝﾄ名称の取得
            lstrFormName = Me.Name
            lstrEventName = "cmdNowList_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ﾌｫｰﾑﾛｯｸ
            
            '@ｴﾝﾄﾘ情報取得
            lblnAns = prvblnLotEntryList_Sel
            '@結果判定
            If lblnAns = True Then
                '@ﾌｫｰﾑﾛｯｸ解除
                
                '@件数の判定
                If mlngEntryListCnt = 0 Then
                '@件数が0件の場合
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
            
                    '@各種ｺﾝﾄﾛｰﾙのﾛｯｸ
                    vsfEntryList.Enabled = False
                    cmdChoice.Enabled = False
                    
                    Exit Sub
                Else
                    '@一覧表示
                    Call prvvsfEntryList_Disp()
                End If
            Else
                '@ﾌｫｰﾑﾛｯｸ解除
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@各種ｺﾝﾄﾛｰﾙのﾛｯｸ
                vsfEntryList.Enabled = False
                cmdChoice.Enabled = False
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdNowList_Click"           '処理名"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfEntryList_AfterSort
    '機　能：ソート後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 10:23:33 N.Kojima
    '更新日：2004/10/15 (Fri) 15:04:58 N.Kasai  ｿｰﾄ保持機能追加
    '備　考：
    Private Sub vsfEntryList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfEntryList.AfterSort
        
        Dim lobjChgSortList As ChgSortList

        Try

            lobjChgSortList = New ChgSortList

            '@ｿｰﾄ順を格納
            With mtypChgSort
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                
                With lobjChgSortList
                    '@ｿｰﾄ列番号を格納
                    .lngCol = e.Col
                
                    '@並び替え方法を格納（昇順/降順）
                    .lngOrder = e.Order
                End With

                .typChgSortList.Add(lobjChgSortList)

            End With

            '@ｶﾚﾝﾄ行の設定（ｸﾞﾘｯﾄﾞ、保持列 [ 適用日時、ｴﾝﾄﾘID ]、前頁、次頁 ）
            Call pubVsfAfterSort(vsfEntryList, _
                                 CMvsfEntryListColEntryApplyTime & _
                                 vbTab & _
                                 CMvsfEntryListColEntryID)

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfEntryList_AfterSort"     '処理名"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfEntryList_BeforeRowColChange
    '機　能：ｸﾞﾘｯﾄﾞﾌｫｰｶｽ移動
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/10/15 (Fri) 15:08:42 N.Kasai
    '更新日：2004/10/15 (Fri) 15:08:42
    '備　考：
    Private Sub vsfEntryList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfEntryList.BeforeRowColChange
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfEntryList.Rows.Count <= vsfEntryList.Rows.Fixed Then
                Return
            End If
            
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納（ｴﾝﾄﾘID）
                mtypChgSort.strKey _
                    = vsfEntryList.GetData(e.NewRange.r1, CMvsfEntryListColEntryID)
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                     '機能ID
                .strProcName = "vsfEntryList_BeforeRowColChange"    '処理名
                .strErrMessage = vbNullString                       'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfEntryList_BeforeSort
    '機　能：ソート前処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 10:20:48 N.Kojima
    '更新日：2004/07/27 (Tue) 10:20:48
    '備　考：
    Private Sub vsfEntryList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfEntryList.BeforeSort
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfEntryList.Rows.Count <= vsfEntryList.Rows.Fixed Then
                Return
            End If

            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列 [適用日時、ｴﾝﾄﾘID ] ）
            Call pubVsfBeforeSort(vsfEntryList, _
                                  CMvsfEntryListColEntryApplyTime & _
                                  vbTab & _
                                  CMvsfEntryListColEntryID)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfEntryList_BeforeSort"    '処理名"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfEntryList_DblClick
    '機　能：機種ｴﾝﾄﾘ選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 10:17:33 N.Kojima
    '更新日：2004/07/27 (Tue) 10:17:33
    '備　考：
    Private Sub vsfEntryList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfEntryList.DoubleClick

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfEntryList.Rows.Count <= vsfEntryList.Rows.Fixed Then
                Return
            End If

            '@確定ﾎﾞﾀﾝが表示されている場合
            If cmdChoice.Visible = True Then
                '@ﾍｯﾀﾞｰﾀﾞﾌﾞﾙｸﾘｯｸの場合
                If vsfEntryList.MouseRow = 0 Then
                    Exit Sub
                End If
                
                '@選択確定処理へ
                Me.CancelButton = Nothing

                'NSYS ダブルクリックで確定処理をします
                Call cmdChoice_Click(cmdChoice, New EventArgs)
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfEntryList_DblClick"      '処理名"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfEntryList_RowColChange
    '機　能：ｽﾛｯﾄ変更時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/29 (Fri) 17:44:48 N.Kojima
    '更新日：2004/07/29 (Fri) 17:44:48
    '備　考：
    Private Sub vsfEntryList_RowColChange(ByVal sender As Object, ByVal e As EventArgs) Handles vsfEntryList.RowColChange
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfEntryList.Rows.Count <= vsfEntryList.Rows.Fixed Then
                Return
            End If
            
            '@ｶﾚﾝﾄ行がﾍｯﾀﾞｰ以外か
            If vsfEntryList.Row <> 0 Then
                '@選択確定ﾎﾞﾀﾝのﾛｯｸ解除
                cmdChoice.Enabled = True
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfEntryList_RowColChange"  '処理名"
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
    '関数名：prvfrmxxCM00L0_Init
    '機　能：画面初期設定
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 09:56:38 N.Kojima
    '更新日：2004/07/27 (Tue) 09:56:38
    '備　考：
    Private Sub prvfrmxxCM00L0_Init()

        Try
            
            With Me
                .Left = 1290
                .Top = 195
            End With
                
            '@情報取得日時初期化
            lblNowDate.Text = vbNullString
                
            '@該当件数ｸﾘｱ
            lblLotCnt.Text = vbNullString

            '@ｸﾞﾘｯﾄﾞ表示の初期化
            Call prvvsfEntryList_init()
            
            cmdChoice.Enabled = False   '選択確定
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxCM00L0_Init"        '処理名"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvvsfEntryList_init
    '機　能：vsfEntryListの初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 09:55:42 N.Kojima
    '更新日：2004/07/27 (Tue) 09:55:42
    '備　考：
    Private Sub prvvsfEntryList_init()

        Dim lNormalStyle    As CellStyle
        Dim lFixedStyle     As CellStyle

        Try
            RemoveHandler vsfEntryList.RowColChange, AddressOf vsfEntryList_RowColChange
            RemoveHandler vsfEntryList.BeforeRowColChange, AddressOf vsfEntryList_BeforeRowColChange
            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfEntryList
                '@描画ﾛｯｸ
                .Redraw = False

                'NSYS フォーカ位置設定
                .Clear(ClearFlags.UserData)
                .Row = 0
                .Col = 0
                .TopRow = 0

                '@ｸﾞﾘｯﾄﾞの行設定
                .Rows.Count = CMvsfEntryListTRow + 1
                .Cols.Frozen = CMvsfEntryListColEntryApplyTime + 1                  'NSYS 適用日時の固定表示設定
                
                '@ｸﾞﾘｯﾄﾞの列設定
                .Cols.Count = CMvsfEntryListCol
                
                '@ｶﾚﾝﾄｾﾙの周囲に描画するﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light
                
                '@一覧表の表題設定
                .Select(CMvsfEntryListTRow, CMvsfEntryListColEntryApplyTime, _
                        CMvsfEntryListTRow, CMvsfEntryListColEntryComment)
                
                '@ﾀｲﾄﾙ行の文字色、背景色の設定
                lFixedStyle = .Styles.Fixed 
                lFixedStyle.ForeColor = Color.Yellow                                                  '文字色
                lFixedStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)                     '背景色
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter                                    '配置
                With .Font                                                                            'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                    lFixedStyle.Font = New Font(.FontFamily, CMvsfEntryListHFontSize, .Style,
                                                .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                
                '@文章を折り返しなし
                lNormalStyle = .Styles.Normal
                lNormalStyle.WordWrap = False
                
                '@表示位置設定
                .Cols(CMvsfEntryListColEntryApplyTime).TextAlign = TextAlignEnum.LeftCenter             '適用日時
                .Cols(CMvsfEntryListColEntryID).TextAlign = TextAlignEnum.LeftCenter                    'ｴﾝﾄﾘID
                .Cols(CMvsfEntryListColEntryName).TextAlign = TextAlignEnum.LeftCenter                  'ｴﾝﾄﾘ名
                .Cols(CMvsfEntryListColEntryComment).TextAlign = TextAlignEnum.LeftCenter               'ｴﾝﾄﾘｺﾒﾝﾄ

                '@列幅設定
                .Cols(CMvsfEntryListColEntryApplyTime).Width = CMvsfEntryListColWEntryApplyTime         '適用日時
                .Cols(CMvsfEntryListColEntryID).Width = CMvsfEntryListColWEntryID                       'ｴﾝﾄﾘID
                .Cols(CMvsfEntryListColEntryName).Width = CMvsfEntryListColWEntryName                   'ｴﾝﾄﾘ名
                .Cols(CMvsfEntryListColEntryComment).Width = CMvsfEntryListColWEntryComment             'ｴﾝﾄﾘｺﾒﾝﾄ
                .Cols(CMvsfEntryListColMaxWfCount).Width = CMvsfEntryListColWMaxWfCount                 '最大WF枚数
                
                'ﾀｲﾄﾙ設定
                .SetData(CMvsfEntryListTRow, CMvsfEntryListColEntryApplyTime, _
                     CMvsfEntryListColTEntryApplyTime)                                                  '適用日時
                
                .SetData(CMvsfEntryListTRow, CMvsfEntryListColEntryID, _
                     CMvsfEntryListColTEntryID)                                                         'ｴﾝﾄﾘID
                
                .SetData(CMvsfEntryListTRow, CMvsfEntryListColEntryName, _
                     CMvsfEntryListColTEntryName)                                                       'ｴﾝﾄﾘ名
                    
                .SetData(CMvsfEntryListTRow, CMvsfEntryListColEntryComment, _
                     CMvsfEntryListColTEntryComment)                                                    'ｴﾝﾄﾘｺﾒﾝﾄ
                
                '@ﾍｯﾀﾞｰの高さ設定
                .Rows(CMvsfEntryListTRow).Height = CMvsfEntryListHdHeight
                
                '@非表示設定
                .Cols(CMvsfEntryListColMaxWfCount).Visible = False                                      '最大WF枚数

                '@描画ﾛｯｸ解除
                .Redraw = True
                
                '@ﾛｯｸ
                .Enabled = False
            End With
            AddHandler vsfEntryList.RowColChange, AddressOf vsfEntryList_RowColChange
            AddHandler vsfEntryList.BeforeRowColChange, AddressOf vsfEntryList_BeforeRowColChange

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvvsfEntryList_init"       '処理名"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfEntryList_Disp
    '機　能：取得した機種ｴﾝﾄﾘ一覧表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 10:38:11 N.Kojima
    '更新日：2004/10/15 (Fri) 15:15:34 N.Kasai
    '備　考：2004/10/15 (Fri) 15:15:34 N.Kasai      ｿｰﾄ順保持機能追加
    '　　　：2005/06/16 (Thu) 14:41:06 S.Deguchi    起動時選択状態処理修正：ﾀｲﾄﾙ行選択状態とする
    Private Sub prvvsfEntryList_Disp()

        Dim llngCnt         As Integer  'ｶｳﾝﾄ
        Dim llngRowCnt      As Integer  'ｶｳﾝﾄ
        Dim lstrDate        As String   '適用日時文字列

        Try
            'NSYS 移動行の処理を抜け
            RemoveHandler vsfEntryList.RowColChange, AddressOf vsfEntryList_RowColChange
            RemoveHandler vsfEntryList.BeforeRowColChange, AddressOf vsfEntryList_BeforeRowColChange
            With vsfEntryList
                '@ｸﾞﾘｯﾄﾞのﾛｯｸ解除
                .Enabled = True
                
                '@描画ﾛｯｸ
                .Redraw = False
                
                '@ﾘｽﾄ行数格納
                .Rows.Count = .Rows.Fixed
                .Rows.Count = mlngEntryListCnt + 1
                
                '@ｴﾝﾄﾘ一覧表示
                llngCnt = 0
                llngRowCnt =  1
                Do While mlngEntryListCnt > llngCnt
                    
                    If IsDate(mtypEntryList(llngCnt).strEntryApplyTime) = True Then
                         lstrDate = Format$(CDate(mtypEntryList(llngCnt).strEntryApplyTime), "yy/MM/dd HH:mm")             '適用日時
                    Else
                         lstrDate = mtypEntryList(llngCnt).strEntryApplyTime
                    End If
                    .SetData(llngRowCnt, CMvsfEntryListColEntryApplyTime, lstrDate)                                 '適用日時
                        
                    .SetData(llngRowCnt, CMvsfEntryListColEntryID, mtypEntryList(llngCnt).strEntryID)               'ｴﾝﾄﾘID
                    
                    .SetData(llngRowCnt, CMvsfEntryListColEntryName, mtypEntryList(llngCnt).strEntryName)           'ｴﾝﾄﾘ名

                    .SetData(llngRowCnt, CMvsfEntryListColEntryComment, mtypEntryList(llngCnt).strEntryComments)    'ｴﾝﾄﾘ時ｺﾒﾝﾄ

                    .SetData(llngRowCnt, CMvsfEntryListColMaxWfCount,  mtypEntryList(llngCnt).strMaxWFCount)        '最大WF枚数
                    
                    '@行高さ設定
                    .Rows(llngRowCnt).Height = CMvsfEntryListHeight
                    
                    '@ｶｳﾝﾄｱｯﾌﾟ
                    llngCnt = llngCnt + 1
                    llngRowCnt =  llngCnt + 1
                Loop
                
                '@行ｻｲｽﾞを調整
                '.AutoSizeMode = flexAutoSizeColWidth
                .AutoSizeCol(CMvsfEntryListColEntryApplyTime, 6)
                .AutoSizeCol(CMvsfEntryListColEntryID, 6)
                .AutoSizeCol(CMvsfEntryListColEntryName, 6)
                .AutoSizeCol(CMvsfEntryListColEntryComment, 6)
                
                '@ﾍｯﾀﾞｰの高さ設定
                .Rows(CMvsfEntryListTRow).Height = CMvsfEntryListHdHeight
                
                '@情報取得日時設定
                lblNowDate.Text = Format$(Now, CPstrDateFormat)
                
                '@該当件数設定
                lblLotCnt.Text = Format$(.Rows.Count - 1, CPstrDateFormatKanma)
                
                '@ﾕｰｻﾞによりｿｰﾄされている場合
                If mtypChgSort.lngCnt > 0 Then
                    '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                    For llngCnt = 0 To mtypChgSort.lngCnt - 1
                        '@該当行をｿｰﾄ
                        .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder, mtypChgSort.typChgSortList(llngCnt).lngCol)
                    Next llngCnt
                End If
                
                '@ｿｰﾄ検索用ｷｰ（ｴﾝﾄﾘID）がある場合
                If mtypChgSort.strKey <> vbNullString Then
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@ｴﾝﾄﾘIDが同じ場合
                        If .GetData(llngCnt, CMvsfEntryListColEntryID) = mtypChgSort.strKey Then
                            .Row = llngCnt
                            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列）
                            Call pubVsfBeforeSort(vsfEntryList, CMvsfEntryListColEntryApplyTime)
                            
                            '@ｿｰﾄ後のｶﾚﾝﾄ行設定（ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁）
                            Call pubVsfAfterSort(vsfEntryList, CMvsfEntryListColEntryApplyTime)
                            
                            Exit For
                        End If
                    Next llngCnt
                Else
                    '@ﾀｲﾄﾙ行選択状態とする
                    .Row = CMvsfEntryListTRow
                    .TopRow = 1
                End If
                
                '@描画ﾛｯｸ解除
                .Redraw = True
            End With
            AddHandler vsfEntryList.RowColChange, AddressOf vsfEntryList_RowColChange
            AddHandler vsfEntryList.BeforeRowColChange, AddressOf vsfEntryList_BeforeRowColChange
            
            'NSYS フォーカ位置設定
            vsfEntryList.LeftCol = 1
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvvsfEntryList_Disp"       '処理名"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvblnLotEntryList_Sel
    '機　能：機種/特殊工順取得処理
    '引　数：なし
    '戻り値：True：成功/False：失敗
    '作成日：2005/06/16 (Thu) 14:25:11 S.Deguchi
    '更新日：2005/06/16 (Thu) 14:25:11
    '備　考：
    Private Function prvblnLotEntryList_Sel() As Boolean

        Dim lblnAns             As Boolean              '種別一覧取得戻り値(True/False)
        Dim lstrClassDivision   As String               '処理区分

        Try

            '@初期化
            prvblnLotEntryList_Sel = False
            
            '@起動区分による処理分岐
            Select Case plngfrmxxCM00L0Kbn
                '@機種最新１件取得
                Case CMlngPDEntry
                    '@処理区分設定
                    lstrClassDivision = CPstrCD07   '処理区分："07"の最新取得
                    
                    '@ﾏｽﾀ工順取得結果
                    lblnAns = pubblnmasPdEntryList_Sel(CMstrmas_pdentrylistVer, _
                                                       pstrPDID, _
                                                       mtypEntryList, _
                                                       mlngEntryListCnt, _
                                                       pstrSBID, lstrClassDivision)
                '@機種全件取得
                Case CMlngPDEntryALL
                    '@処理区分設定
                    lstrClassDivision = CPstrCD02   '処理区分："02"の全件取得
                    
                    '@ﾏｽﾀ工順取得結果
                    lblnAns = pubblnmasPdEntryList_Sel(CMstrmas_pdentrylistVer, _
                                                       pstrPDID, _
                                                       mtypEntryList, _
                                                       mlngEntryListCnt, _
                                                       pstrSBID, lstrClassDivision)
                '@特殊工順取得
                Case CMlngUserEntry
                    '@特殊工順取得結果
                    lblnAns = pubblnLotSppdentrylist_Sel(CMstrlot_sppdentrylistVer, _
                                                         pstrSBID, _
                                                         mtypEntryList, _
                                                         mlngEntryListCnt)
            End Select
            
            '@結果判定
            If lblnAns = False Then
            '@失敗の場合
                '@処理強制終了
                Exit Function
            End If

            '@成功を返す
            prvblnLotEntryList_Sel = True

            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnLotEntryList_Sel"     '処理名"
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
#Disable Warning BC42353 ' 関数 'prvblnLotEntryList_Sel' には値を返さないコード パスがあります。'Return' ステートメントが不足していないかどうかを確認してください。
    End Function
#Enable Warning BC42353 ' 関数 'prvblnLotEntryList_Sel' には値を返さないコード パスがあります。'Return' ステートメントが不足していないかどうかを確認してください。


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


    '関数名 list_BeforeDoubleClick
    '機　能：グリッドダブルクリック前処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/01/14 (Mon) 17:00:00 NSYS
    '備　考：
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfEntryList.BeforeDoubleClick 
        
        ' ObjectをGridに変換
        Dim gridObj As C1FlexGrid
        gridObj = CType(sender, C1FlexGrid)

        Dim colindex As Integer 'ダブルクリックした列番号

        'ダブルクリックした箇所が列の境界線かを判断する
        If gridObj.HitTest(e.X,e.Y).Type = HitTestTypeEnum.ColumnResize Then

            '列の境界線の場合、本来の処理をキャンセル
            e.Cancel = True

            'ダブルクリックした列番号を格納
            colindex = gridObj.HitTest(e.X,e.Y).Column

            'サイズを自動調整
            gridObj.AutoSizeCol(colindex,6)
        End If

    End Sub
End Class
