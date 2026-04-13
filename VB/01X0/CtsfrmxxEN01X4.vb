'ﾌｧｲﾙ名：xxEN01X4.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ｺﾋﾟｰ元ﾏｽﾀ工順選択
'作成日：2006/05/09 (Tue) 10:15:41 N.Kasai
'更新日：2011/05/09 (Mon) 09:48:10 T.Oide
'備　考：
'　　　：2011/04/26 (Tue) 11:12:37 T.Oide       CHR0001319 QUを組立に送品可能にする
'Copyright(C)2003-, SEIKO EPSON CORPORATION.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01X4
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01X4    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01X4
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01X4
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01X4)
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
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN01X4  'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_pdentrylistVer       As String = "03.00"         'ﾏｽﾀ工順一覧
    '@↓2011/05/09 (Mon) 10:14:02 T.Oide **************************************************
    'Private Const CMstrmas_pdlist__Ver          As String = "02.02"         '機種区分一覧取得
    Private Const CMstrmas_pdlist__Ver          As String = "03.00"         '機種区分一覧取得
    '@↑2011/05/09 (Mon) 10:14:02 T.Oide **************************************************

    '@vsfEntryListの定数宣言（ｶﾗﾑ）
    Private Const CMlngvsfEntryApplyTime        As Integer = 0              '適用日時
    Private Const CMlngvsfEntryID               As Integer = 1              'ｴﾝﾄﾘID
    Private Const CMlngvsfEntryName             As Integer = 2              'ｴﾝﾄﾘ名
    Private Const CMlngvsfEntryComment          As Integer = 3              'ｴﾝﾄﾘｺﾒﾝﾄ

    '@vsfEntryListの定数宣言（表示幅）
    Private Const CMlngvsfwEntryApplyTime       As Integer = 163            '適用日時
    Private Const CMlngvsfwEntryID              As Integer = 145            'ｴﾝﾄﾘID
    Private Const CMlngvsfwEntryName            As Integer = 160            'ｴﾝﾄﾘ名
    Private Const CMlngvsfwEntryComment         As Integer = 200            'ｴﾝﾄﾘｺﾒﾝﾄ

    '@vsfEntryListの定数宣言（ﾀｲﾄﾙ）
    Private Const CMstrvsftEntryApplyTime       As String = "適用日時"
    Private Const CMstrvsftEntryID              As String = "エントリ"
    Private Const CMstrvsftEntryName            As String = "エントリ名"
    Private Const CMstrvsftEntryComment         As String = "コメント"

    '@その他ｸﾞﾘｯﾄの定数
    Private Const CMlngMaxCols                  As Integer = 4              '最大ｶﾗﾑ数
    Private Const CMlngTRow                     As Integer = 0              'ﾀｲﾄﾙ行
    Private Const CMlngHdHeight                 As Integer = 20             '行の高さ(ﾍｯﾀﾞ）
    Private Const CMlngBdHeight                 As Integer = 18             '行の高さ(ﾎﾞﾃﾞｨ）

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbRowHeight             As Integer = 18             'ﾘｽﾄ行の高さ
    Private Const CMlngCmbCol0                  As Integer = 0              'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=0(機種ID）
    Private Const CMlngCmbCol1                  As Integer = 1              'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=1(機種名）
    Private Const CMlngCmbCol2                  As Integer = 2              'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=2(未使用）
    Private Const CMlngCmbCol3                  As Integer = 3              'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=3(未使用）
    Private Const CMlngCmbCol4                  As Integer = 4              'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=4(ForColor）
    Private Const CMlngCmbCol5                  As Integer = 5              'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=5(BackColor）

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mtypChgSort                         As ChgSort                  'ｿｰﾄ保持用
    Private mblnFormLoadFlag                    As Boolean                  'ﾌｫｰﾑﾛｰﾄﾞ中ﾌﾗｸﾞ（Ture:ﾌｫｰﾑﾛｰﾄﾞ中、False:ﾌｫｰﾑﾛｰﾄﾞ完了）

    Private buttonProcessing                    As Boolean                  'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                  'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                  'NSYS WindowCloseフラグ
    Private vsfEntryListRowBeforeRow            As Integer                  'NSYS ｿｰﾄ時の選択行退避
    Private nowActiveControl                    As Control                  'NSYS ActiveControl保持用

    Private ReadOnly flexRDNone                 As Boolean = False          'NSYS ReDraw用
    Private ReadOnly flexRDDirect               As Boolean = True           'NSYS ReDraw用

    Private ReadOnly vbWhite                    As Color = Color.White      'NSYS vbWhite定義
    Private ReadOnly vbYellow                   As Color = Color.Yellow     'NSYS vbYellow定義

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
    '作成日：2006/07/12 (Wed) 12:08:04 N.Kasai
    '更新日：2006/07/12 (Wed) 12:08:04
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns             As Boolean              '戻り値
        Dim ltypProductList     As List(Of ProductList) '機種格納用の構造体
        Dim llngProductCnt      As Integer              '機種ﾘｽﾄのｶｳﾝﾄ
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            mblnFormLoadFlag = False
            
            '@画面初期化
            Call prvfrmxxEN01X4_Init()
               
            '@ｲﾍﾞﾝﾄ名格納
            lstrEventName = "Form_Load"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, lstrEventName)

           
            '@機種区分一覧取得（'画面ｻｲｽﾞ指定なし-すべて）
            lblnAns = pubblnMasPdlist_Sel(CMstrmas_pdlist__Ver, _
                                          CPstrCD2A & CPstrCD02, _
                                          ltypProductList, _
                                          llngProductCnt, _
                                          pstrSBID)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@機種ｺﾝﾎﾞ格納
            Call prvcmbPd_Disp(llngProductCnt, ltypProductList)
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)
           
            '@Form_Loadﾌﾗｸﾞ（正常）
            pblnFormLoad = True
             
            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = cmdClose
            
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
    '機　能：ﾌｫｰﾑActivate
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:04:54 N.Kasai
    '更新日：2006/07/12 (Wed) 12:04:54
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
            
        Try
            
            '@初回のみ処理
            If mblnFormLoadFlag = True Then
                Exit Sub
            End If
            mblnFormLoadFlag = True
            
            If pstrEN01X0PdId <> vbNullString Then
                '@引継ぎ構造体より機種IDをｾｯﾄ
                cmbPD.Text = pstrEN01X0PdId
                '@ｺﾝﾎﾞ表示
                RemoveHandler cmbPd.Validating, AddressOf cmbPd_Validate
                Call cmbPd_Validate(True, New CancelEventArgs)
                AddHandler cmbPd.Validating, AddressOf cmbPd_Validate
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
    '機　能：ｷｰﾀﾞｳﾝ処理
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ値
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:08:19 N.Kasai
    '更新日：2006/07/12 (Wed) 12:08:19
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
            
            '@Enterｷｰの場合
            Select Case e.KeyCode
                Case Keys.Return
                    '@一覧にﾌｫｰｶｽがある場合
                    Select Case ActiveControl.Name
                       
                        '@機種ｺﾝﾎﾞ
                        Case cmbPD.Name
                            
                            '@機種ｺﾝﾎﾞ処理
                            RemoveHandler cmbPd.Validating, AddressOf cmbPd_Validate
                            Call cmbPd_Validate(cmbPd, New CancelEventArgs)
                            AddHandler cmbPd.Validating, AddressOf cmbPd_Validate
                        
                        Case Else
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
            If mtypChgSort.typChgSortList Is Nothing Then
                mtypChgSort.typChgSortList = New List(Of ChgSortList)
            Else
                mtypChgSort.typChgSortList.Clear
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

    '関数名：cmdClose_Click
    '機　能：ﾌｫｰﾑを閉じる
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:08:33 N.Kasai
    '更新日：2006/07/12 (Wed) 12:08:33
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


    '関数名：cmbPD_Change
    '機　能：機種ｺﾝﾎﾞ変更
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/19 (Wed) 13:44:12 N.Kasai
    '更新日：2006/07/19 (Wed) 13:44:12
    '備　考：
    Private Sub cmbPd_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPd.Change

        Try
            
            '@画面情報初期化
            
            '@構造体の初期化
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                End If
                '@列幅変更ﾌﾗｸﾞ（未変更）
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            '@ｸﾞﾘｯﾄﾞ表示の初期化
            Call prvvsfEntryList_init()

            '@情報取得日時初期化
            lblNowDate.Text = vbNullString
                
            '@該当件数ｸﾘｱ
            lblLotCnt.Text = vbNullString
            
            cmdRegist.Enabled = False   '確定
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPD_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub


    '関数名：cmbPD_CloseUp
    '機　能：機種ｺﾝﾎﾞ選択
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:02:47 N.Kasai
    '更新日：2006/07/12 (Wed) 12:02:47
    '備　考：
    Private Sub cmbPd_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPd.CloseUp

        Try
            
            RemoveHandler cmbPd.Validating, AddressOf cmbPd_Validate
            Call cmbPd_Validate(cmbPd, New CancelEventArgs)
            AddHandler cmbPd.Validating, AddressOf cmbPd_Validate
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPD_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPD_Validate
    '機　能：機種ｺﾝﾎﾞ処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:06:37 N.Kasai
    '更新日：2006/07/12 (Wed) 12:06:37
    '備　考：
    Private Sub cmbPd_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPd.Validating

        Try
            
            'NSYS 画面を閉じる場合は処理を抜ける
            If Me.ActiveControl Is cmdClose OrElse mblnWindowClose = True Then
                Exit Sub
            End If

            'NSYS 現在のActiveControlを保持する
            nowActiveControl = Me.ActiveControl
            
            '@機種ｺﾝﾎﾞが選択済み
            If cmbPD.ListIndex = -1 Then
                cmdNowList.Enabled = False
            Else
                cmdNowList.Enabled = True
                
                '@最新取得
                Call cmdNowList_Click(cmdNowList, New EventArgs)
                
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPD_Validate"
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
    '作成日：2006/07/12 (Wed) 12:08:54 N.Kasai
    '更新日：2006/07/12 (Wed) 12:08:54
    '備　考：
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

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
                
                With ptypEN01X4
                    .strPdId = cmbPD.Text
                    .strEntryID = vsfEntryList.GetData(vsfEntryList.Row, CMlngvsfEntryID)
                    .strEntryTime = vsfEntryList.GetData(vsfEntryList.Row, CMlngvsfEntryApplyTime)
                End With
                
                '@ﾌｫｰﾑを閉じる
                Me.Close()
            End If

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
    '作成日：2006/07/12 (Wed) 12:09:19 N.Kasai
    '更新日：2006/07/12 (Wed) 12:09:19
    '備　考：
    Private Sub cmdNowList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowList.Click
        
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名（ﾚｽﾎﾟﾝｽ用）
        Dim lblnAns             As Boolean              '種別一覧取得戻り値(True/False)
        Dim lstrPdID            As String               '機種ID
        Dim ltypEntryList       As List(Of EntryList)   'ﾏｽﾀ工順一覧格納用
        Dim llngEntryListCnt    As Integer              'ﾏｽﾀ工順ﾘｽﾄｶｳﾝﾄ

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

            '@ﾌｫｰﾑのﾛｯｸ中は処理を行わない
            If Me.Enabled = False Then
                Exit Sub
            End If
            
            '@ｲﾍﾞﾝﾄ名称の取得
            lstrEventName = "cmdNowList_Click"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, lstrEventName)
            
            '@機種ID取得
            With cmbPD
                .ValueCol = CMlngCmbCol0
                lstrPdID = .Value
            End With
            
            
            '@【ﾏｽﾀ工順取得】(処理区分："02"の全件取得)
            lblnAns = pubblnmasPdEntryList_Sel(CMstrmas_pdentrylistVer, _
                                               lstrPdID, _
                                               ltypEntryList, _
                                               llngEntryListCnt, _
                                               pstrSBID, CPstrCD02)
            
            '@結果判定
            If lblnAns = True Then
                '@一覧表示
                Call prvvsfEntryList_Disp(ltypEntryList, llngEntryListCnt)
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
                
                '@各種ｺﾝﾄﾛｰﾙのﾛｯｸ
                vsfEntryList.Enabled = False
                cmdRegist.Enabled = False
                
                Exit Sub
            End If
            
            '@件数の判定
            If vsfEntryList.Rows.Count > 1 Then
                '@Form_Loadﾌﾗｸﾞ（正常）
                pblnFormLoad = True
            Else
            '@件数が0件の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)

                '@各種ｺﾝﾄﾛｰﾙのﾛｯｸ
                vsfEntryList.Enabled = False
                cmdRegist.Enabled = False
                
                '@Form_Loadﾌﾗｸﾞ
                pblnFormLoad = False
                
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)
            
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
    '作成日：2006/07/12 (Wed) 12:09:59 N.Kasai
    '更新日：2006/07/12 (Wed) 12:09:59
    '備　考：
    Private Sub vsfEntryList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfEntryList.AfterSort

        Try

            'BeforeSortで除外していたRowColChangeイベントを復帰
            AddHandler vsfEntryList.BeforeRowColChange, AddressOf vsfEntryList_BeforeRowColChange
            AddHandler vsfEntryList.RowColChange, AddressOf vsfEntryList_RowColChange
            
            'NSYS ソート前の選択行が有効行でない場合、ヘッダを選択行とする
            If vsfEntryListRowBeforeRow <  vsfEntryList.Rows.Fixed Then
                vsfEntryList.Row = 0
            End If
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfEntryList.Rows.Count <= vsfEntryList.Rows.Fixed Then
                Return
            End If

            '@ｿｰﾄ順を格納
            With mtypChgSort
                'NSYS リストを初期化

                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                Else
                    .typChgSortList.Clear
                End If
                
                'NSYS リスト格納用変数定義
                Dim typChgSortListTmp As ChgSortList = New ChgSortList

                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = 1
                
                '@ｿｰﾄ列番号を格納
                typChgSortListTmp.lngCol = e.Col
                
                '@並び替え方法を格納（昇順/降順）
                typChgSortListTmp.lngOrder = e.Order

                .typChgSortList.Add(typChgSortListTmp)
            End With
            
            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列 [ｴﾝﾄﾘID ] ）
            Call pubVsfAfterSort(vsfEntryList, CMlngvsfEntryID, Nothing, Nothing, True, True, True, True, False)

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

    '関数名：vsfEntryList_AfterUserResize
    '機　能：ｸﾞﾘｯﾄﾞﾕｰｻﾞﾘｻｲｽﾞ
    '引　数：Row：行
    '　　　：Col：列
    '戻り値：なし
    '作成日：2006/07/26 (Wed) 09:57:04 N.Kasai
    '更新日：2006/07/26 (Wed) 09:57:04
    '備　考：
    Private Sub vsfEntryList_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfEntryList.AfterResizeColumn, vsfEntryList.AfterResizeRow

        Try
            
            '@列幅変更ﾌﾗｸﾞ（変更）
            mtypChgSort.blnChgWidth = True

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                     '機能ID
                .strProcName = "vsfEntryList_AfterUserResize"       '処理名
                .strErrMessage = vbNullString                       'ｴﾗｰﾒｯｾｰｼﾞ
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
    '作成日：2006/07/12 (Wed) 12:10:20 N.Kasai
    '更新日：2006/07/12 (Wed) 12:10:20
    '備　考：
    Private Sub vsfEntryList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfEntryList.BeforeSort

        Try
            
            'ソートでRowColChangeを発生しないようにする
            RemoveHandler vsfEntryList.BeforeRowColChange, AddressOf vsfEntryList_BeforeRowColChange
            RemoveHandler vsfEntryList.RowColChange, AddressOf vsfEntryList_RowColChange

            'NSYS ソート前の選択行を保持
            vsfEntryListRowBeforeRow = vsfEntryList.Row

            'NSYS データ行がない場合は処理を抜ける
            If vsfEntryList.Rows.Count <= vsfEntryList.Rows.Fixed Then
                Return
            End If

            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列 [ｴﾝﾄﾘID ] ）
            Call pubVsfBeforeSort(vsfEntryList, CMlngvsfEntryID)
            
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
    '作成日：2006/07/12 (Wed) 12:10:41 N.Kasai
    '更新日：2006/07/12 (Wed) 12:10:41
    '備　考：
    Private Sub vsfEntryList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfEntryList.BeforeRowColChange
        
        Dim OldRow              As Integer          'NSYS 
        Dim NewRow              As Integer          'NSYS 

        Try
            
            'NSYS ヘッダ行クリック時処理を抜ける
            If vsfEntryList.MouseRow <= 0 Then
                Exit Sub
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfEntryList.Rows.Count <= vsfEntryList.Rows.Fixed Then
                Return
            End If

            '選択値を設定
            OldRow = e.OldRange.r1
            NewRow = e.NewRange.r1

            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If OldRow <> NewRow And NewRow > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納（ｴﾝﾄﾘID）
                mtypChgSort.strKey = vsfEntryList.GetData(NewRow, CMlngvsfEntryID)
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
    '作成日：2006/07/12 (Wed) 12:10:53 N.Kasai
    '更新日：2006/07/12 (Wed) 12:10:53
    '備　考：
    Private Sub vsfEntryList_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfEntryList.DoubleClick

        Try
            
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
    '作成日：2006/07/12 (Wed) 12:11:10 N.Kasai
    '更新日：2006/07/12 (Wed) 12:11:10
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
                cmdRegist.Enabled = True
            Else
                cmdRegist.Enabled = False
            End If

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


    '***************************************************************************************
    '                              　　*関数の記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：prvfrmxxEN01X4_Init
    '機　能：画面初期設定
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/09 (Tue) 10:39:27 N.Kasai
    '更新日：2006/05/09 (Tue) 10:39:27
    '備　考：
    Private Sub prvfrmxxEN01X4_Init()
        
        Dim ltypEN01X4 As EN01X4    '引継ぎ構造体
        
        Try
            
            '@引継ぎ構造体の初期化
            ptypEN01X4 = ltypEN01X4
            
            '@構造体の初期化
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                End If
                '@列幅変更ﾌﾗｸﾞ（未変更）
                .blnChgWidth = False
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
            
            '@ｸﾞﾘｯﾄﾞ表示の初期化
            Call prvvsfEntryList_init()

            '@情報取得日時初期化
            lblNowDate.Text = vbNullString
                
            '@該当件数ｸﾘｱ
            lblLotCnt.Text = vbNullString
            
            cmdRegist.Enabled = False   '確定
            
            cmdNowList.Enabled = False  '最新取得
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN01X4_Init"
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
    '作成日：2006/05/09 (Tue) 10:40:12 N.Kasai
    '更新日：2006/05/09 (Tue) 10:40:12
    '備　考：
    Private Sub prvvsfEntryList_init()

        Dim lFixedlStyle As CellStyle 'NSYS スタイル定義

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfEntryList
            
                'NSYS スタイルを変数に設定
                lFixedlStyle = .Styles.Fixed

                '@描画ﾛｯｸ
                .Redraw = flexRDNone

                '@ｸﾞﾘｯﾄﾞの行設定
                .Rows.Count = CMlngTRow + 1
                
                '@ｸﾞﾘｯﾄﾞの列設定
                .Cols.Count = CMlngMaxCols
                
                '@ｶﾚﾝﾄｾﾙの周囲に描画するﾌｫｰｶｽ枠のｽﾀｲﾙを設定（なし）
                .FocusRect = FocusRectEnum.None
                
                '@一覧表の表題設定
                .Select(CMlngTRow, CMlngvsfEntryApplyTime, CMlngTRow, CMlngvsfEntryComment)
                lFixedlStyle.ForeColor = vbYellow                                   '文字色
                lFixedlStyle.BackColor = ColorTranslator.FromWin32(CPlngBlueColor)  '背景色
                lFixedlStyle.TextAlign = TextAlignEnum.CenterCenter                 '配置
            
                '@文章を折り返しなし
                lFixedlStyle.WordWrap = False
                '@列の調整を可能にする
                '.AutoSizeMode = flexAutoSizeColWidth
                
                '@ﾏｳｽによる列ｻｲｽﾞ変更の可
                .AllowResizing = AllowResizingEnum.Columns

                '@表示位置設定
                .Cols(CMlngvsfEntryApplyTime).TextAlign = TextAlignEnum.LeftTop '適用日時
                .Cols(CMlngvsfEntryID).TextAlign = TextAlignEnum.LeftTop        'ｴﾝﾄﾘID
                .Cols(CMlngvsfEntryName).TextAlign = TextAlignEnum.LeftTop      'ｴﾝﾄﾘ名
                .Cols(CMlngvsfEntryComment).TextAlign = TextAlignEnum.LeftTop   'ｴﾝﾄﾘｺﾒﾝﾄ

                '@列幅設定
                .Cols(CMlngvsfEntryComment).Width = CMlngvsfwEntryComment       'ｴﾝﾄﾘｺﾒﾝﾄ
                
                '@ﾍｯﾀﾞｰの高さ設定
                .Rows(CMlngTRow).Height = CMlngHdHeight

                '@描画ﾛｯｸ解除
                .Redraw = flexRDDirect
                
                '@ﾛｯｸ
                .Enabled = False
                
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
    '作成日：2006/05/09 (Tue) 11:41:06 N.Kasai
    '更新日：2006/05/09 (Tue) 11:41:06
    '備　考：
    Private Sub prvvsfEntryList_Disp(ByRef ltypEntryList As List(Of EntryList), _
                                     ByVal llngEntryListCnt As Integer)

        Dim llngCnt         As Integer  'ｶｳﾝﾄ
        Dim beforePosition  As Point    'NSYS
        Dim beforeSelectRow As Integer  'NSYS

        Try

            With vsfEntryList
                '@ｸﾞﾘｯﾄﾞのﾛｯｸ解除
                .Enabled = True
                
                'NSYS 前回の表示位置退避
                beforePosition  = .ScrollPosition
                beforeSelectRow = .Row
                
                '@描画ﾛｯｸ
                .Redraw = flexRDNone
                
                '@ﾘｽﾄ行数格納
                RemoveHandler vsfEntryList.BeforeRowColChange, AddressOf vsfEntryList_BeforeRowColChange
                '.Rows.Count = .Rows.Fixed
                .Rows.Count = llngEntryListCnt + 1
                AddHandler vsfEntryList.BeforeRowColChange, AddressOf vsfEntryList_BeforeRowColChange
                
                '@行選択
                .Select(CMlngTRow, CMlngvsfEntryApplyTime, CMlngTRow, CMlngvsfEntryComment)
                    
                '@ｴﾝﾄﾘ一覧表示
                llngCnt = 0
                Do While .Rows.Count - 1 > llngCnt

                    'NSYS 正しい日付形式のデータかを確認する。
                    Dim lstrEntryApplyTime As String
                    If IsDate(ltypEntryList(llngCnt).strEntryApplyTime) Then
                        lstrEntryApplyTime = Format$(CDate(ltypEntryList(llngCnt).strEntryApplyTime), "yy/MM/dd HH:mm")
                    Else
                        lstrEntryApplyTime = ltypEntryList(llngCnt).strEntryApplyTime
                    End If
                    .SetData(llngCnt + 1, CMlngvsfEntryApplyTime, lstrEntryApplyTime)                        '適用日時
                    .SetData(llngCnt + 1, CMlngvsfEntryID, ltypEntryList(llngCnt).strEntryID)                'ｴﾝﾄﾘID
                    .SetData(llngCnt + 1, CMlngvsfEntryName, ltypEntryList(llngCnt).strEntryName)            'ｴﾝﾄﾘ名
                    .SetData(llngCnt + 1, CMlngvsfEntryComment, ltypEntryList(llngCnt).strEntryComments)     'ｴﾝﾄﾘ時ｺﾒﾝﾄ
                    llngCnt = llngCnt + 1
                Loop
                
                 '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    '@ｵｰﾄｻｲｽﾞ設定
                    .AutoSizeCols(CMlngvsfEntryApplyTime, CMlngvsfEntryComment, 6)
                End If
                        
                '@ﾍｯﾀﾞｰの高さ設定
                .Rows(CMlngTRow).Height = CMlngHdHeight
                
                '@情報取得日時設定
                lblNowDate.Text = Format$(Now, CPstrDateFormat)
                
                '@該当件数設定
                lblLotCnt.Text = Format$(.Rows.Count - 1, CPstrDateFormatKanma)
                
                '@ﾕｰｻﾞによりｿｰﾄされている場合
                If mtypChgSort.lngCnt > 0 Then
                    '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                    For llngCnt = 0 To mtypChgSort.lngCnt - 1
                        '@該当行をｿｰﾄ
                        '.Cell(flexcpSort, .Rows.Fixed, mtypChgSort.typChgSortList(llngCnt).lngCol, .Rows.Count - 1) = mtypChgSort.typChgSortList(llngCnt).lngOrder
                        RemoveHandler vsfEntryList.BeforeRowColChange, AddressOf vsfEntryList_BeforeRowColChange
                        .Sort(mtypChgSort.typChgSortList(llngCnt).lngOrder, mtypChgSort.typChgSortList(llngCnt).lngCol)
                        AddHandler vsfEntryList.BeforeRowColChange, AddressOf vsfEntryList_BeforeRowColChange
                    Next llngCnt
                End If
                
                '@ｿｰﾄ検索用ｷｰ（ｴﾝﾄﾘID）がある場合
                If mtypChgSort.strKey <> vbNullString Then
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@ｴﾝﾄﾘIDが同じ場合
                        If .GetData(llngCnt, CMlngvsfEntryID) = mtypChgSort.strKey Then
                            If beforeSelectRow > 0 Then
                                .Row = llngCnt
                            End If
                            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列）
                            RemoveHandler vsfEntryList.BeforeRowColChange, AddressOf vsfEntryList_BeforeRowColChange
                            Call pubVsfBeforeSort(vsfEntryList, CMlngvsfEntryID)
                            AddHandler vsfEntryList.BeforeRowColChange, AddressOf vsfEntryList_BeforeRowColChange
                            '@ｶﾚﾝﾄ行の保持（ｸﾞﾘｯﾄﾞ、保持列 [ｴﾝﾄﾘID ] ）
                            Call pubVsfAfterSort(vsfEntryList, CMlngvsfEntryID, Nothing, Nothing, True, True, True, True, False)
                            Exit For
                        End If
                    Next llngCnt
                End If
                
                '@ﾌｫｰｶｽ制御
                If .Enabled = True Then
                    'NSYS 確定ボタン押下の場合
                    If nowActiveControl Is cmdRegist Then
                        'NSYS 選択確定処理へ
                        Call cmdRegist_Click(cmdRegist, New EventArgs)
                    Else
                        '@ｸﾞﾘｯﾄにﾌｫｰｶｽｾｯﾄ
                        Call pubSetFocus(vsfEntryList)
                    End If
                    
                    'NSYS 前回の表示位置復元
                    RemoveHandler vsfEntryList.BeforeRowColChange, AddressOf vsfEntryList_BeforeRowColChange
                    .ScrollPosition = New Point(beforePosition.X, .ScrollPosition.Y)
                    If beforeSelectRow <= 0 Then
                        .TopRow = 0
                        .Row = 0
                    End If
                    AddHandler vsfEntryList.BeforeRowColChange, AddressOf vsfEntryList_BeforeRowColChange
                End If
                
                '@描画ﾛｯｸ解除
                .Redraw = flexRDDirect
                
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

    '関数名：prvcmbPd_Disp
    '機　能：機種Combo設定
    '引　数：llngProductCnt：機種ﾃﾞｰﾀ件数
    '　　　：ltypProductList()：機種ﾃﾞｰﾀ格納
    '戻り値：なし
    '作成日：2006/05/09 (Tue) 11:39:23 N.Kasai
    '更新日：2006/05/09 (Tue) 11:39:23
    '備　考：
    Private Sub prvcmbPd_Disp(ByVal llngProductCnt As Integer, ByRef ltypProductList As List(Of ProductList))

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbPD
                '@機種初期化
                .Clear
                .BackColor = vbWhite                                        'ﾊﾞｯｸｶﾗｰ(白)
                .Height = CMlngCmbRowHeight                                 '高さ
                .DispCols = CMlngCmbCol1                                    'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbCol0                                    '値取得列
                .ColAlignment(CMlngCmbCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .ColAlignment(CMlngCmbCol1) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .DirectInput = False                                        '手入力不可
                
                '@機種情報ｾｯﾄ
                For llngCnt = 0 To llngProductCnt - 1
                
                    '@機種ｺﾝﾎﾞ格納('機種ID&機種名称)
                    .AddItem(ltypProductList(llngCnt).strProductID _
                                        & vbTab _
                                        & ltypProductList(llngCnt).strProductName _
                                        & vbTab _
                                        & vbNullString _
                                        & vbTab _
                                        & vbNullString _
                                        & vbTab _
                                        & ltypProductList(llngCnt).strForeColor _
                                        & vbTab _
                                        & ltypProductList(llngCnt).strBackColor)

                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmbPd_Disp"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

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
            
        End If

    End Sub
    
End Class
