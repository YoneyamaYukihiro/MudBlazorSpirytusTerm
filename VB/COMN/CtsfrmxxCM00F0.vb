'ﾌｧｲﾙ名：xxCM00F0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：機種ｴﾝﾄﾘ一覧
'作成日：2004/07/26 (Mon) 16:14:18 N.Kojima
'更新日：2009/02/25 (Wed) 18:56:35 N.Kojima
'備　考：
'Copyright(C)2003-, SEIKO EPSON CORPORATION.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxCM00F0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxCM00F0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxCM00F0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxCM00F0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxCM00F0)
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
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyCM00F0  'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    '@↓2009/02/25 (Wed) 18:56:42 N.Kojima **************************************************
    'Private Const CMstrmas_pdentrylistVer               As String = "02.02"         'ﾏｽﾀ工順一覧
    Private Const CMstrmas_pdentrylistVer               As String = "03.00"         'ﾏｽﾀ工順一覧
    '@↑2009/02/25 (Wed) 18:56:42 N.Kojima **************************************************
    Private Const CMstrlot_sppdentrylistVer             As String = "01.00"         '特殊工順取得

    '@vsfEntryListの定数宣言(ｶﾗﾑ)
    Private Const CMvsfEntryListColEntryApplyTime       As Integer = 0              '適用日時
    Private Const CMvsfEntryListColEntryID              As Integer = 1              'ｴﾝﾄﾘID
    Private Const CMvsfEntryListColEntryName            As Integer = 2              'ｴﾝﾄﾘ名
    Private Const CMvsfEntryListColEntryComment         As Integer = 3              'ｴﾝﾄﾘｺﾒﾝﾄ
    Private Const CMvsfEntryListColMaxWfCount           As Integer = 4              '最大WF枚数
    '@↓2009/02/23 (Mon) 14:51:30 N.Kojima **************************************************
    '@案件№03402の対応により、ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連の処理はｺﾒﾝﾄｱｳﾄ。復活の可能性もあるので残しておく。
    'Private Const CMvsfEntryListColCdenFlag             As Long = 5                 'ﾁｯﾌﾟ電特ﾌﾗｸﾞ
    '@↑2009/02/23 (Mon) 14:51:30 N.Kojima **************************************************

    '@vsfEntryListの定数宣言(表示幅)
    Private Const CMvsfEntryListColWEntryApplyTime      As Integer = 150            '適用日時
    Private Const CMvsfEntryListColWEntryID             As Integer = 146            'ｴﾝﾄﾘID
    Private Const CMvsfEntryListColWEntryName           As Integer = 215            'ｴﾝﾄﾘ名
    Private Const CMvsfEntryListColWEntryComment        As Integer = 88             'ｴﾝﾄﾘｺﾒﾝﾄ
    Private Const CMvsfEntryListColWMaxWfCount          As Integer = 33             '最大WF枚数
    '@↓2009/02/23 (Mon) 14:51:42 N.Kojima **************************************************
    '@案件№03402の対応により、ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連の処理はｺﾒﾝﾄｱｳﾄ。復活の可能性もあるので残しておく。
    'Private Const CMvsfEntryListColWCdenFlag            As Long = 0                 'ﾁｯﾌﾟ電特ﾌﾗｸﾞ
    '@↑2009/02/23 (Mon) 14:51:42 N.Kojima **************************************************

    '@vsfEntryListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMvsfEntryListColTEntryApplyTime      As String = "適用日時"       '適用日時
    Private Const CMvsfEntryListColTEntryID             As String = "エントリID"     'ｴﾝﾄﾘID
    Private Const CMvsfEntryListColTEntryName           As String = "エントリ名"     'ｴﾝﾄﾘ名
    Private Const CMvsfEntryListColTEntryComment        As String = "コメント"       'ｴﾝﾄﾘｺﾒﾝﾄ
    '@↓2009/02/23 (Mon) 14:51:52 N.Kojima **************************************************
    '@案件№03402の対応により、ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連の処理はｺﾒﾝﾄｱｳﾄ。復活の可能性もあるので残しておく。
    'Private Const CMvsfEntryListColTCdenFlag            As String = "チップ電特フラグ"  'ﾁｯﾌﾟ電特ﾌﾗｸﾞ
    '@↑2009/02/23 (Mon) 14:51:52 N.Kojima **************************************************

    '@その他ｸﾞﾘｯﾄの定数
    Private Const CMvsfEntryListCol                     As Integer = 5              'ｶﾗﾑ数
    Private Const CMvsfEntryListTRow                    As Integer = 0              'ﾀｲﾄﾙ行
    Private Const CMvsfEntryListHFontSize               As Integer = 12             'ﾍｯﾀﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMvsfEntryListHdHeight                As Integer = 27             '行の高さ(ﾍｯﾀﾞｰのみ)
    Private Const CMvsfEntryListHeight                  As Integer = 43             '行の高さ
    Private Const CMvsfEntryListAll                     As Integer = -1             '表全体

    '@横ｽｸﾛｰﾙのFlag定数
    Private Const CMlngSideScrollOnFlag                 As Integer = 1              '横ｽｸﾛｰﾙ活性化
    Private Const CMlngSideScrollOffFlag                As Integer = 2              '横ｽｸﾛｰﾙ非活性化

    '@起動区分の定数宣言
    Private Const CMlngPDEntry                          As Integer = 0              '機種ｴﾝﾄﾘ表示
    Private Const CMlngPDEntryALL                       As Integer = 1              '機種ｴﾝﾄﾘ全件表示
    Private Const CMlngUserEntry                        As Integer = 2              'ﾕｰｻﾞｰｴﾝﾄﾘ表示

    '@ｺﾒﾝﾄｽｸﾛｰﾙ制御用
    Private Const CMlngMaxDispRow                       As Integer = 3              'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mblnCheckFlg                                As Boolean                  'ﾁｪｯｸﾌﾗｸﾞ
    Private mstrEntryName                               As String                   'ｴﾝﾄﾘ名退避領域
    Private mlngSideScrollFlag                          As Integer                  '横ｽｸﾛｰﾙの使用ﾌﾗｸﾞ(1:発生/2:不要)
    Private mtypEntryList                               As List(Of EntryList)       'ﾏｽﾀ工順一覧格納用
    Private mtypChgSort                                 As ChgSort                  'ｿｰﾄ保持用
    Private buttonProcessing                            As Boolean                  'NSYS ボタン2度押し対策
    Private RegistbuttonFlag                            As Boolean                  'NSYS 確定ボタンフラグ

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

        'NSYS スクロールバーなしグリッドのマウスホイール対応
        pubVsfMouseWheelManager_Set(vsfEntryList, cmdUp, cmdDown)

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
    '作成日：2004/07/26 (Mon) 16:28:42 N.Kojima
    '更新日：2004/07/29 (Thu) 10:56:34 N.Kojima
    '備　考：
    Private Sub Form_Load()

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            'cmdClose.Cancel = False

            '@暗黙でFormが表示されたかどうかを判定する
            'If Not Me Is Me Then
            ''@暗黙で表示されていない場合
            '    '@暗黙でFormをLoad
            '    Load Me
                
            '    '@Escﾎﾞﾀﾝを有効
            '    cmdClose.Cancel = True
                
            '    Exit Sub
            'End If
            
            '@ﾌﾗｸﾞ初期化(ﾃﾞﾌｫﾙﾄTrueで確定ﾎﾞﾀﾝが押下された時のみFalse)
            pblnCancel = True
            RegistbuttonFlag = False
            
            '@構造体の初期化
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                .typChgSortList = New List(Of ChgSortList)
                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            '@画面初期化
            Call prvfrmxxCM00F0_Init()

            '@ｸﾞﾘｯﾄﾞ表示の初期化
            Call prvvsfEntryList_init()
            
            '@一覧表示
            Call cmdNowList_Click(cmdNowList, New EventArgs)
            
            '@行選択
            vsfEntryList.Select(CMvsfEntryListTRow, CMvsfEntryListColEntryApplyTime, CMvsfEntryListTRow, CMvsfEntryListColEntryComment)

            '@一覧表示で0件の場合には,処理を終了してﾒｲﾝ画面に戻る
            If vsfEntryList.Rows.Count > 1 Then
                '@Form_Loadﾌﾗｸﾞ(正常)
                pblnFormLoad = True
            Else
                '@Form_Loadﾌﾗｸﾞ(異常)
                pblnFormLoad = False
                
                '@該当件数が0件の場合ﾀﾞｲｱﾛｸﾞでｲﾝﾌｫﾒｰｼｮﾝ表示する
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0029, lblLotCnt.Text)
                
                '@publngMsgBoxInfo("メッセージコード：C_I29%0$$該当件数 ： 0 件")
                Call publngMsgBoxInfo(pstrDMsg, vbInformation, Me.Text, True, 16)
            End If
            
            '@Escﾎﾞﾀﾝを有効
            'cmdClose.Cancel = True
            
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
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If

            '@ｸﾞﾘｯﾄﾞｷｰ制御(ｸﾞﾘｯﾄﾞ共通仕様)
            Call pubVsf_KeyDown(e, ActiveControl.Name, vsfEntryList, cmdUP, cmdDown)
            
            '@選択確定ﾎﾞﾀﾝが非表示の場合
            If cmdRegist.Visible = False Then
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
                        If ActiveControl.Name = vsfEntryList.Name _
                            AndAlso ActiveControl IsNot vsfEntryList.Editor Then
                            '@ﾃﾞｰﾀ行の場合
                            If vsfEntryList.Row >= vsfEntryList.Rows.Fixed Then
                                '@選択確定処理
                                Call cmdRegist_Click(cmdRegist, New EventArgs)
                            End If
                        Else
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                        End If
                End Select
            End If
            
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
    '機　能：画面終了
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：終了方法
    '戻り値：なし
    '作成日：2004/10/15 (Fri) 14:56:29 N.Kasai
    '更新日：2004/10/15 (Fri) 14:56:29
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Cancel = True
                Exit Sub
            End If

             '@ｿｰﾄ保持用構造体のｸﾘｱ
            mtypChgSort.typChgSortList = Nothing
            
            '@構造体のｸﾘｱ
            mtypEntryList = Nothing
            
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
    '機　能：選択確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 08:57:34 N.Kojima
    '更新日：2009/02/23 (Mon) 14:14:23 N.Kojima
    '備　考：
    '　　　：2008/01/22 (Tue) 15:08:07 N.Kojima     ﾁｯﾌﾟ電特対応。(案件№02263)
    '　　　：2009/02/23 (Mon) 14:14:23 N.Kojima     ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連処理削除、ﾁｯﾌﾟ電特区分(限定工程設定)関連処理追加。(案件№3402)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            With vsfEntryList
                '@行が選択されていない場合は格納しない
                If .Row >= 1 Then
                    
                    '@ｴﾝﾄﾘ名・ｴﾝﾄﾘID・最大WF枚数を格納
                    pstrEntryName = .GetData(.Row, CMvsfEntryListColEntryName)
                    pstrEntryID = .GetData(.Row, CMvsfEntryListColEntryID)
                    pstrMaxWFCount = .GetData(.Row, CMvsfEntryListColMaxWfCount)
                    
        '@↓2009/02/23 (Mon) 14:50:06 N.Kojima **************************************************
        '@案件№03402の対応により、ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連の処理はｺﾒﾝﾄｱｳﾄ。復活の可能性もあるので残しておく。

        '            '@ﾁｯﾌﾟ電特ﾌﾗｸﾞが"1"か
        '            If .Cell(flexcpText, .Row, CMvsfEntryListColCdenFlag) = CPstrOne Then
        '                '@ﾁｯﾌﾟ電特工程有無判定ﾌﾗｸﾞを"True:ﾁｯﾌﾟ電特工程あり"に設定
        '                pblnCdenProcJudgeFlag = True
        '            Else
        '                '@ﾁｯﾌﾟ電特工程有無判定ﾌﾗｸﾞを"False:ﾁｯﾌﾟ電特工程あり"に設定
        '                pblnCdenProcJudgeFlag = False
        '            End If

        '@↑2009/02/23 (Mon) 14:50:06 N.Kojima **************************************************
                    
                    '@ﾌｫｰﾑを閉じる
                    Me.Close()
                End If
            End With

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

    '関数名：cmdNowList_Click
    '機　能：最新取得ﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 10:01:49 N.Kojima
    '更新日：2004/07/29 (Thu) 10:56:30 N.Kojima
    '備　考：
    Private Sub cmdNowList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowList.Click
        
        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lblnAns             As Boolean              '種別一覧取得戻り値(True/False)
        Dim llngEntryListCnt    As Integer              'ﾏｽﾀ工順ﾘｽﾄｶｳﾝﾄ
        Dim lstrClassDivision   As String               '処理区分

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
            
            '@ﾌｫｰﾑ,ｲﾍﾞﾝﾄ名称の取得
            lstrFormName = Me.Name
            lstrEventName = "cmdNowList_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@起動区分による処理分岐
            Select Case plngfrmxxCM00F0Kbn
                Case CMlngPDEntry
                '@機種最新１件取得
                    '@処理区分設定
                    lstrClassDivision = CPstrCD07   '処理区分："07"の最新取得
                    '@ﾏｽﾀ工順取得結果
                    lblnAns = pubblnmasPdEntryList_Sel(CMstrmas_pdentrylistVer, _
                                                       pstrPDID, _
                                                       mtypEntryList, _
                                                       llngEntryListCnt, _
                                                       pstrSBID, lstrClassDivision)
                Case CMlngPDEntryALL
                '@機種全件取得
                    '@処理区分設定
                    lstrClassDivision = CPstrCD02   '処理区分："02"の全件取得
                    '@ﾏｽﾀ工順取得結果
                    lblnAns = pubblnmasPdEntryList_Sel(CMstrmas_pdentrylistVer, _
                                                       pstrPDID, _
                                                       mtypEntryList, _
                                                       llngEntryListCnt, _
                                                       pstrSBID, lstrClassDivision)
                Case CMlngUserEntry
                '@特殊工順取得
                    '@特殊工順取得結果
                    lblnAns = pubblnLotSppdentrylist_Sel(CMstrlot_sppdentrylistVer, _
                                                       pstrSBID, _
                                                       mtypEntryList, _
                                                       llngEntryListCnt)
            End Select
            
            '@結果判定
            If lblnAns = True Then
                
                '@一覧表示
                Call prvvsfEntryList_Disp(mtypEntryList, llngEntryListCnt)
            Else
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@各種ｺﾝﾄﾛｰﾙのﾛｯｸ
                vsfEntryList.Enabled = False
                cmdRegist.Enabled = False
                
                Exit Sub
            End If
            
            '@件数の判定
            If vsfEntryList.Rows.Count > 1 Then
                '@Form_Loadﾌﾗｸﾞ(正常)
                pblnFormLoad = True
            Else
            '@件数が0件の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@各種ｺﾝﾄﾛｰﾙのﾛｯｸ
                vsfEntryList.Enabled = False
                cmdRegist.Enabled = False
                
                '@Form_Loadﾌﾗｸﾞ
                pblnFormLoad = False
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdNowList_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfEntryList_AfterSort
    '機　能：ｿｰﾄ後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 10:23:33 N.Kojima
    '更新日：2004/10/15 (Fri) 14:52:58 N.Kasai
    '備　考：2004/10/15 (Fri) 14:52:58 N.Kasai  ｿｰﾄ順保持機能追加
    Private Sub vsfEntryList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfEntryList.AfterSort

        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfEntryList.Rows.Count <= vsfEntryList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ順を格納
            With mtypChgSort
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
                Dim ltypChgSortListTmp As ChgSortList
                
                '@ｿｰﾄ列番号を格納
                ltypChgSortListTmp.lngCol = e.Col
                
                '@並び替え方法を格納(昇順/降順)
                ltypChgSortListTmp.lngOrder = e.Order
                .typChgSortList.Add(ltypChgSortListTmp)
            End With

            '@ｶﾚﾝﾄ行の設定(ｸﾞﾘｯﾄﾞ、保持列 [ 適用日時、ｴﾝﾄﾘID ]、前頁、次頁 )
            Call pubVsfAfterSort(vsfEntryList, CMvsfEntryListColEntryApplyTime & vbTab & CMvsfEntryListColEntryID, cmdUP, cmdDown)
            
            AddHandler vsfEntryList.BeforeRowColChange, AddressOf vsfEntryList_BeforeRowColChange
            AddHandler vsfEntryList.RowColChange, AddressOf vsfEntryList_RowColChange

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfEntryList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfEntryList_BeforeSort
    '機　能：ｿｰﾄ前処理
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

            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列 [適用日時、ｴﾝﾄﾘID ] )
            Call pubVsfBeforeSort(vsfEntryList, CMvsfEntryListColEntryApplyTime & vbTab & CMvsfEntryListColEntryID)
            
            RemoveHandler vsfEntryList.BeforeRowColChange, AddressOf vsfEntryList_BeforeRowColChange
            RemoveHandler vsfEntryList.RowColChange, AddressOf vsfEntryList_RowColChange

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfEntryList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfEntryList_BeforeRowColChange
    '機　能：ｸﾞﾘｯﾄﾞのﾌｫｰｶｽ移動
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/10/15 (Fri) 14:54:21 N.Kasai
    '更新日：2004/10/15 (Fri) 14:54:21
    '備　考：
    Private Sub vsfEntryList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfEntryList.BeforeRowColChange
        
        Try
            'NSYS データ行がない場合は処理を抜ける
            If vsfEntryList.Rows.Count <= vsfEntryList.Rows.Fixed Then
                Return
            End If

            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ｴﾝﾄﾘID)
                mtypChgSort.strKey = vsfEntryList.GetData(e.NewRange.r1, CMvsfEntryListColEntryID)
            End If


            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfEntryList_BeforeRowColChange"
                .strErrMessage = vbNullString
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
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfEntryList.Rows.Count <= vsfEntryList.Rows.Fixed Then
                Return
            End If

            '@確定ﾎﾞﾀﾝが表示されている場合
            If cmdRegist.Visible = True Then
                '@ﾍｯﾀﾞｰﾀﾞﾌﾞﾙｸﾘｯｸの場合
                If vsfEntryList.MouseRow = 0 Then
                    Exit Sub
                End If
                
                '@選択確定処理へ
                Call cmdRegist_Click(cmdRegist, New EventArgs)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfEntryList_DblClick"
                .strErrMessage = vbNullString
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
            With vsfEntryList
                If .Row <> 0 And RegistbuttonFlag = True Then
                    '@選択確定ﾎﾞﾀﾝのﾛｯｸ解除
                    cmdRegist.Enabled = True
                    
        '@↓2007/06/15 (Fri) 16:21:24 N.Kasai **************************************************
                    '@ｺﾒﾝﾄ内容を反映する。
                    txtComment.Text = .GetData(.Row, CMvsfEntryListColEntryComment)
        '@↑2007/06/15 (Fri) 16:21:24 N.Kasai **************************************************
                    
                End If
                RegistbuttonFlag = True 
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfEntryList_RowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdUp_Click
    '機　能：前ﾍﾟｰｼﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 10:18:54 N.Kojima
    '更新日：2004/07/29 (Thu) 16:21:56 N.Kojima
    '備　考：
    Private Sub cmdUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdUp.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｸﾞﾘｯﾄﾞの前頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdUp(vsfEntryList, cmdUP, cmdDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdDown_Click
    '機　能：次ﾍﾟｰｼﾞ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 10:19:05 N.Kojima
    '更新日：2004/07/29 (Thu) 16:21:59 N.Kojima
    '備　考：
    Private Sub cmdDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｸﾞﾘｯﾄﾞの次頁ｸﾘｯｸ処理(ｸﾞﾘｯﾄﾞ共通仕様)を実行する
            Call pubVsfCmdDown(vsfEntryList, cmdUP, cmdDown)
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComment_Change
    '機　能：ｺﾒﾝﾄ欄変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2007/06/15 (Fri) 16:15:46 N.Kasai
    '更新日：2007/06/15 (Fri) 16:15:46 N.Kasai
    '備　考：
    Private Sub txtComment_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtComment.Change

        Try
            
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComment, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComment_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComment_KeyUp
    '機　能：ｺﾒﾝﾄﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2007/06/15 (Fri) 16:16:06 N.Kasai
    '更新日：2007/06/15 (Fri) 16:16:06 N.Kasai
    '備　考：
    Private Sub txtComment_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtComment.KeyUp
        
        Try

            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtComment, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComment_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtComment_MouseUp
    '機　能：ｺﾒﾝﾄﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2007/06/15 (Fri) 16:16:18 N.Kasai
    '更新日：2007/06/15 (Fri) 16:16:18
    '備　考：
    Private Sub txtComment_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtComment.MouseUp

        Try

            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtComment, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtComment_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdCommentUp_Click
    '機　能：ｺﾒﾝﾄの前頁切替(▲ﾎﾞﾀﾝ)
    '引　数：なし
    '戻り値：なし
    '作成日：2007/06/15 (Fri) 16:16:46 N.Kasai
    '更新日：2007/06/15 (Fri) 16:16:46 N.Kasai
    '備　考：
    Private Sub cmdCommentUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCommentUp.Click
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
                
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtComment, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCommentUp_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCommentDown_Click
    '機　能ｺﾒﾝﾄの次頁切替(▼ﾎﾞﾀﾝ)
    '引　数：なし
    '戻り値：なし
    '作成日：2007/06/15 (Fri) 16:16:58 N.Kasai
    '更新日：2007/06/15 (Fri) 16:16:58 N.Kasai
    '備　考：
    Private Sub cmdCommentDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCommentDown.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
                
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtComment, CMlngMaxDispRow, cmdCommentUp, cmdCommentDown)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCommentDown_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：prvfrmxxCM00F0_Init
    '機　能：画面初期設定
    '引　数：なし
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 09:56:38 N.Kojima
    '更新日：2004/07/27 (Tue) 09:56:38
    '備　考：
    Private Sub prvfrmxxCM00F0_Init()

        Try
            
            With Me
                .Left = 86
                .Top = 13
            End With
                
            '@情報取得日時初期化
            lblNowDate.Text = vbNullString
                
            '@該当件数ｸﾘｱ
            lblLotCnt.Text = vbNullString
            
            '@使用不可
            cmdUP.Enabled = False           '前ﾍﾟｰｼﾞ
            cmdDown.Enabled = False         '次ﾍﾟｰｼﾞ
            cmdRegist.Enabled = False       '選択確定
            cmdCommentUp.Enabled = False    'ｺﾒﾝﾄ▲ﾎﾞﾀﾝ
            cmdCommentDown.Enabled = False  'ｺﾒﾝﾄ▼ﾎﾞﾀﾝ
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxCM00F0_Init"
                .strErrMessage = vbNullString
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
    '更新日：2009/02/23 (Mon) 14:14:23 N.Kojima
    '備　考：
    '　　　：2008/01/22 (Tue) 15:08:07 N.Kojima     ﾁｯﾌﾟ電特対応。(案件№02263)
    '　　　：2009/02/23 (Mon) 14:14:23 N.Kojima     ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連処理削除、ﾁｯﾌﾟ電特区分(限定工程設定)関連処理追加。(案件№3402)
    Private Sub prvvsfEntryList_init()

        Dim lNormalStyle    As CellStyle
        Dim lFixedStyle     As CellStyle

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfEntryList
                '@描画ﾛｯｸ
                .Redraw = False

                '@ｸﾞﾘｯﾄﾞの行設定
                .Rows.Count = CMvsfEntryListTRow + 1
                
                '@ｸﾞﾘｯﾄﾞの列設定
                .Cols.Count = CMvsfEntryListCol
                
                '@ｶﾚﾝﾄｾﾙの周囲に描画するﾌｫｰｶｽ枠のｽﾀｲﾙを設定(なし)
                .FocusRect = FocusRectEnum.None
                
                '@一覧表の表題設定
                .Select(CMvsfEntryListTRow, CMvsfEntryListColEntryApplyTime, CMvsfEntryListTRow, CMvsfEntryListColEntryComment)
                lFixedStyle = .Styles.Fixed
                With .Font                                   'ﾌｫﾝﾄｻｲｽﾞ
                    lFixedStyle.Font = New Font(.FontFamily, CMvsfEntryListHFontSize, .Style, _
                                        .Unit, .GdiCharSet, .GdiVerticalFont)
                End With
                lFixedStyle.ForeColor = Color.Yellow         '文字色
                lFixedStyle.BackColor = Color.Navy           '背景色
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter  '配置
            
                '@文章を折り返して表示する
                lNormalStyle = .Styles.Normal
                lNormalStyle.WordWrap = True
                
                '@列の調整を可能にする
                '.AutoSizeMode = flexAutoSizeRowHeight
                
                '@表示位置設定
                .Cols(CMvsfEntryListColEntryApplyTime).TextAlign = TextAlignEnum.LeftCenter       '適用日時
                .Cols(CMvsfEntryListColEntryID).TextAlign = TextAlignEnum.LeftCenter              'ｴﾝﾄﾘID
                .Cols(CMvsfEntryListColEntryName).TextAlign = TextAlignEnum.LeftCenter            'ｴﾝﾄﾘ名
                .Cols(CMvsfEntryListColEntryComment).TextAlign = TextAlignEnum.LeftCenter         'ｴﾝﾄﾘｺﾒﾝﾄ

                '@列幅設定
                .Cols(CMvsfEntryListColEntryApplyTime).Width = CMvsfEntryListColWEntryApplyTime   '適用日時
                .Cols(CMvsfEntryListColEntryID).Width = CMvsfEntryListColWEntryID                 'ｴﾝﾄﾘID
                .Cols(CMvsfEntryListColEntryName).Width = CMvsfEntryListColWEntryName             'ｴﾝﾄﾘ名
                .Cols(CMvsfEntryListColEntryComment).Width = CMvsfEntryListColWEntryComment       'ｴﾝﾄﾘｺﾒﾝﾄ
                .Cols(CMvsfEntryListColMaxWfCount).Width = CMvsfEntryListColWMaxWfCount           '最大WF枚数
        '@↓2009/02/23 (Mon) 14:50:21 N.Kojima **************************************************
        '@案件№03402の対応により、ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連の処理はｺﾒﾝﾄｱｳﾄ。復活の可能性もあるので残しておく。

        '        .ColWidth(CMvsfEntryListColCdenFlag) = CMvsfEntryListColWCdenFlag               'ﾁｯﾌﾟ電特ﾌﾗｸﾞ

        '@↑2009/02/23 (Mon) 14:50:21 N.Kojima **************************************************
                
                'ﾀｲﾄﾙ設定
                .SetData(CMvsfEntryListTRow, CMvsfEntryListColEntryApplyTime, CMvsfEntryListColTEntryApplyTime)   '適用日時
                .SetData(CMvsfEntryListTRow, CMvsfEntryListColEntryID, CMvsfEntryListColTEntryID)                 'ｴﾝﾄﾘID
                .SetData(CMvsfEntryListTRow, CMvsfEntryListColEntryName, CMvsfEntryListColTEntryName)             'ｴﾝﾄﾘ名
                .SetData(CMvsfEntryListTRow, CMvsfEntryListColEntryComment, CMvsfEntryListColTEntryComment)       'ｴﾝﾄﾘｺﾒﾝﾄ
                
        '@↓2009/02/23 (Mon) 14:50:37 N.Kojima **************************************************
        '@案件№03402の対応により、ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連の処理はｺﾒﾝﾄｱｳﾄ。復活の可能性もあるので残しておく。

        '        .Cell(flexcpText, CMvsfEntryListTRow, CMvsfEntryListColCdenFlag) = CMvsfEntryListColTCdenFlag               'ﾁｯﾌﾟ電特ﾌﾗｸﾞ

        '@↑2009/02/23 (Mon) 14:50:37 N.Kojima **************************************************
                
                '@ﾍｯﾀﾞｰの高さ設定
                .Rows(CMvsfEntryListTRow).Height = CMvsfEntryListHdHeight
                
                '@非表示設定
                .Cols(CMvsfEntryListColMaxWfCount).Visible = False          '最大WF枚数
                
        '@↓2009/02/23 (Mon) 14:50:55 N.Kojima **************************************************
        '@案件№03402の対応により、ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連の処理はｺﾒﾝﾄｱｳﾄ。復活の可能性もあるので残しておく。

        '        .ColHidden(CMvsfEntryListColCdenFlag) = True            'ﾁｯﾌﾟ電特ﾌﾗｸﾞ

        '@↑2009/02/23 (Mon) 14:50:55 N.Kojima **************************************************

                '@描画ﾛｯｸ解除
                .Redraw = True
                
                '@ﾛｯｸ
                .Enabled = False
                
                .Rows.DefaultSize = CMvsfEntryListHeight

                cmdUP.Enabled = False                   'ｽｸﾛｰﾙ上
                cmdDown.Enabled = False                 'ｽｸﾛｰﾙ下
                
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfEntryList_init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfEntryList_Disp
    '機　能：取得した機種ｴﾝﾄﾘ一覧表示
    '引　数：ltypEntryList()：機種ｴﾝﾄﾘ一覧が格納された構造体
    '　　　：llngEntryListCnt：構造体の配列の数
    '戻り値：なし
    '作成日：2004/07/27 (Tue) 10:38:11 N.Kojima
    '更新日：2009/02/23 (Mon) 14:14:23 N.Kojima
    '備　考：
    '　　　：2007/06/15 (Fri) 16:10:03 N.Kasai      見直し(№01985)
    '　　　：2008/01/22 (Tue) 15:08:07 N.Kojima     ﾁｯﾌﾟ電特対応。(案件№02263)
    '　　　：2009/02/23 (Mon) 14:14:23 N.Kojima     ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連処理削除、ﾁｯﾌﾟ電特区分(限定工程設定)関連処理追加。(案件№3402)
    Private Sub prvvsfEntryList_Disp(ByRef ltypEntryList As List(Of EntryList), _
                                     ByVal llngEntryListCnt As Integer)

        Dim llngCnt         As Integer  'ｶｳﾝﾄ
        Dim llngHeight      As Integer  '高さ

        Try

            With vsfEntryList
                '@ｸﾞﾘｯﾄﾞのﾛｯｸ解除
                .Enabled = True
                
                '@描画ﾛｯｸ
                .Redraw = False
                
                '@ﾘｽﾄ行数格納
                RemoveHandler vsfEntryList.RowColChange, AddressOf vsfEntryList_RowColChange
                RemoveHandler vsfEntryList.BeforeRowColChange, AddressOf vsfEntryList_BeforeRowColChange
                .Rows.Count = .Rows.Fixed
                .Rows.Count = llngEntryListCnt + 1
                AddHandler vsfEntryList.BeforeRowColChange, AddressOf vsfEntryList_BeforeRowColChange
                AddHandler vsfEntryList.RowColChange, AddressOf vsfEntryList_RowColChange
                
                '@ｴﾝﾄﾘ一覧表示
                llngCnt = 1
                Do While .Rows.Count > llngCnt
                    .SetData(llngCnt, CMvsfEntryListColEntryApplyTime, Format$(CDate(ltypEntryList(llngCnt-1).strEntryApplyTime), CPstrDateTimeY2MDHM)) '適用日時
                    .SetData(llngCnt, CMvsfEntryListColEntryID, ltypEntryList(llngCnt-1).strEntryID)                'ｴﾝﾄﾘID
                    .SetData(llngCnt, CMvsfEntryListColEntryName, ltypEntryList(llngCnt-1).strEntryName)            'ｴﾝﾄﾘ名
                    .SetData(llngCnt, CMvsfEntryListColEntryComment, ltypEntryList(llngCnt-1).strEntryComments)     'ｴﾝﾄﾘ時ｺﾒﾝﾄ
                    .SetData(llngCnt, CMvsfEntryListColMaxWfCount, ltypEntryList(llngCnt-1).strMaxWFCount)          '最大WF枚数
                    
        '@↓2009/02/23 (Mon) 14:51:11 N.Kojima **************************************************
        '@案件№03402の対応により、ﾁｯﾌﾟ電特ﾌﾗｸﾞ関連の処理はｺﾒﾝﾄｱｳﾄ。復活の可能性もあるので残しておく。
                    
        '            .Cell(flexcpText, llngCnt, CMvsfEntryListColCdenFlag) = ltypEntryList(llngCnt).strCdenFlag              'ﾁｯﾌﾟ電特ﾌﾗｸﾞ

        '@↑2009/02/23 (Mon) 14:51:11 N.Kojima **************************************************
                    
                    llngCnt = llngCnt + 1
                Loop
                
        '@↓2007/06/15 (Fri) 16:09:52 N.Kasai **************************************************
        ''        '@折り返し表示対応に伴い、行ｻｲｽﾞを調整
        ''        .AutoSize (CMvsfEntryListColEntryComment)
        ''        '@ﾍｯﾀﾞｰの高さ設定
        ''        .RowHeight(CMvsfEntryListTRow) = CMvsfEntryListHdHeight
        ''        '@行の高さ設定
        ''        llngCnt = llngCnt - 1
        ''        Do While llngCnt >= 1
        ''            '@AutoSize後のﾘｽﾄの高さが規定より小さい場合、規定に合わせる
        ''            If .RowHeight(llngCnt) < CMvsfEntryListHeight Then
        ''                '@RowHeightを640に設定
        ''                .RowHeight(llngCnt) = CMvsfEntryListHeight
        ''            End If
        ''            '@ﾘｽﾄ1ﾍﾟｰｼﾞ分の全ｽﾛｯﾄの高さを足した高さ
        ''            llngHeight = llngHeight + .RowHeight(llngCnt)
        ''            llngCnt = llngCnt - 1
        ''        Loop
                
                '@ﾍｯﾀﾞｰの高さ設定
                .Rows(CMvsfEntryListTRow).Height = CMvsfEntryListHdHeight

                '行の高さを計算
                llngCnt = llngCnt - 1
                Do While llngCnt >= 1
                    '@AutoSize後のﾘｽﾄの高さが規定より小さい場合、規定に合わせる
                    If .Rows(llngCnt).Height < CMvsfEntryListHeight Then
                        '@RowHeightを640に設定 → NSYS 43 ピクセル
                        .Rows(llngCnt).Height = CMvsfEntryListHeight
                    End If
                    '@ﾘｽﾄ1ﾍﾟｰｼﾞ分の全ｽﾛｯﾄの高さを足した高さ
                    llngHeight = llngHeight + .Rows(llngCnt).Height
                    llngCnt = llngCnt - 1
                Loop
                
        '@↑2007/06/15 (Fri) 16:09:52 N.Kasai **************************************************
                
                '@前ﾍﾟｰｼﾞ、次ﾍﾟｰｼﾞ、ｽｸﾛｰﾙﾗﾍﾞﾙ表示設定
                '@可変ﾘｽﾄの為、Rowsでは判断出来ず、ｸﾞﾘｯﾄﾞの高さで上下ｷｰのﾛｯｸを行う
                If llngHeight > .Height Then
                    '@上下ﾎﾞﾀﾝの有効無効設定
                    cmdUP.Enabled = False
                    cmdDown.Enabled = True
                Else
                    '@上下ﾎﾞﾀﾝの有効無効設定
                    cmdUP.Enabled = False
                    cmdDown.Enabled = False
                End If
                
                '@情報取得日時設定
                lblNowDate.Text = Format$(Now, CPstrDateFormat)
                
                '@該当件数設定
                lblLotCnt.Text = Format$(.Rows.Count - 1, CPstrDateFormatKanma)
                
                '@ﾕｰｻﾞによりｿｰﾄされている場合
                If mtypChgSort.lngCnt > 0 Then
                    '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                    For llngCnt = 0 To mtypChgSort.lngCnt - 1
                        '@該当行をｿｰﾄ
                        RemoveHandler vsfEntryList.RowColChange, AddressOf vsfEntryList_RowColChange
                        RemoveHandler vsfEntryList.BeforeRowColChange,AddressOf vsfEntryList_BeforeRowColChange
                        .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder, mtypChgSort.typChgSortList(llngCnt).lngCol)
                        AddHandler vsfEntryList.BeforeRowColChange, AddressOf vsfEntryList_BeforeRowColChange
                        AddHandler vsfEntryList.RowColChange, AddressOf vsfEntryList_RowColChange
                    Next llngCnt
                End If
                
                '@行選択
                .Select(CMvsfEntryListTRow, CMvsfEntryListColEntryApplyTime, CMvsfEntryListTRow, CMvsfEntryListColEntryComment)

                '@ｿｰﾄ検索用ｷｰ(ｴﾝﾄﾘID)がある場合
                If mtypChgSort.strKey <> vbNullString Then
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@ｴﾝﾄﾘIDが同じ場合
                        If .GetData(llngCnt, CMvsfEntryListColEntryID) = mtypChgSort.strKey Then
                            .Row = llngCnt
                            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                            Call pubVsfBeforeSort(vsfEntryList, CMvsfEntryListColEntryApplyTime)
                            '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
                            Call pubVsfAfterSort(vsfEntryList, CMvsfEntryListColEntryApplyTime, cmdUP, cmdDown)
                            Exit For
                        End If
                    Next llngCnt
                End If
                
                '@描画ﾛｯｸ解除
                .Redraw = True
                    
                '@ﾌｫｰﾑが表示されている場合
                If .Visible = True Then
                    '@ｸﾞﾘｯﾄにﾌｫｰｶｽｾｯﾄ
                    Call pubSetFocus(vsfEntryList)
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfEntryList_Disp"
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

End Class
