'ﾌｧｲﾙ名：xxEN01X7.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：コピー元ロット工順選択　メインフォーム
'作成日：2006/05/09 (Tue) 12:26:58 N.Kasai
'更新日：2011/05/09 (Mon) 09:48:33 T.Oide
'備　考：
'　　　：2011/04/26 (Tue) 11:12:37 T.Oide       CHR0001319 QUを組立に送品可能にする
'Copyright(C)2003-, SEIKO EPSON CORPORATION.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN01X7
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN01X7    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN01X7
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN01X7
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN01X7)
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
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN01X7  'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrproclist____Ver                  As String = "03.01"         'ﾛｯﾄ一覧
    '@↓2011/05/09 (Mon) 10:14:02 T.Oide **************************************************
    'Private Const CMstrmas_pdlist__Ver                  As String = "02.02"         '機種区分一覧取得
    Private Const CMstrmas_pdlist__Ver                  As String = "03.00"         '機種区分一覧取得
    '@↑2011/05/09 (Mon) 10:14:02 T.Oide **************************************************
    '@↓2011/05/09 (Mon) 10:45:39 T.Oide **************************************************
    'Private Const CMstrmas_flowlistVer                  As String = "03.00"         '種別区分一覧取得
    Private Const CMstrmas_flowlistVer                  As String = "04.00"         '種別区分一覧取得
    '@↑2011/05/09 (Mon) 10:45:39 T.Oide **************************************************

    '@vsfLotListCpの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfNo                            As Integer = 0                 '№
    Private Const CMlngvsfKb                            As Integer = 1                 '保/停
    Private Const CMlngvsfLotID                         As Integer = 2                 'ﾛｯﾄID
    Private Const CMlngvsfPdID                          As Integer = 3                 '機種ID
    Private Const CMlngvsfFlowClass                     As Integer = 4                 '種別
    Private Const CMlngvsfNowSt                         As Integer = 5                 '状態
    Private Const CMlngvsfLotManagerName                As Integer = 6                 'ﾛｯﾄ担当
    Private Const CMlngvsfEditTime                      As Integer = 7                 '最終更新日時
    Private Const CMlngvsfProcFlag                      As Integer = 8                 'ﾛｯﾄ種別ﾌﾗｸﾞ(0:通常ﾛｯﾄ、1:特殊ﾛｯﾄ)

    '@vsfLotListCpの定数宣言(表示幅)
    Private Const CMlngvsfwNo                           As Integer = 53               '№
    Private Const CMlngvsfWKb                           As Integer = 23               '保/停
    Private Const CMlngvsfWLotID                        As Integer = 108              'ﾛｯﾄID
    Private Const CMlngvsfWNowSt                        As Integer = 67               '状態
    Private Const CMlngvsfWPdID                         As Integer = 67               '機種ID
    Private Const CMlngvsfWFlowClass                    As Integer = 67               '種別
    Private Const CMlngvsfWLotManagerName               As Integer = 145              'ﾛｯﾄ担当
    Private Const CMlngvsfWEditTime                     As Integer = 163              '最終更新日時
    Private Const CMlngvsfWProcFlag                     As Integer = 163              'ﾛｯﾄ種別ﾌﾗｸﾞ(0:通常ﾛｯﾄ、1:特殊ﾛｯﾄ)

    '@vsfLotListCpの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsftNo                           As String = " № "
    Private Const CMstrvsfTKb                           As String = "　"
    Private Const CMstrvsfTLotID                        As String = "ロットID"
    Private Const CMstrvsfTNowSt                        As String = "状態"
    Private Const CMstrvsfTPdID                         As String = "機種ID"
    Private Const CMstrvsfTFlowClass                    As String = "種別"
    Private Const CMstrvsfTLotManagerName               As String = "ロット担当"
    Private Const CMstrvsfTEditTime                     As String = "最終更新日時"
    Private Const CMstrvsfTProcFlag                     As String = "ロット種別フラグ"

    '@その他ｸﾞﾘｯﾄの定数
    Private Const CMlngvsfMaxCols                       As Integer = 9                 '最大ｶﾗﾑ数
    Private Const CMlngvsfTRow                          As Integer = 0                 'ﾀｲﾄﾙ行
    Private Const CMingvsfHFontSize                     As Integer = 11                'ﾍｯﾀﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngvsfHdHeight                      As Integer = 20                '行の高さ(ﾍｯﾀﾞｰのみ)
    Private Const CMlngvsfBdHeight                      As Integer = 18                '行の高さ

    '@その他
    Private Const CMstrLotHoldFlgOn                     As String = "1"             '保留ﾛｯﾄﾌﾗｸﾞON
    Private Const CMstrLotStopFlgOn                     As String = "1"             '停止ﾛｯﾄﾌﾗｸﾞON
    Private Const CMstrReworkFlgOn                      As String = "1"             'ﾘﾜｰｸﾌﾗｸﾞON
    Private Const CMstrLotReworkFlgOn2                  As String = "2"             '追加ﾌﾗｸﾞON
    Private Const CMlngSearch0                          As Integer = 0                 '検索条件(機種/種別/流動区分)
    Private Const CMlngSearch1                          As Integer = 1                 '検索条件(ﾛｯﾄID)
    Private Const CMlngFlowClass0                       As Integer = 0                 '流動区分(流動前)
    Private Const CMlngFlowClass1                       As Integer = 1                 '流動区分(流動中)
    Private Const CMlngFlowClass2                       As Integer = 2                 '流動区分(流動終了)

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbRowHeight                     As Integer = 18                'ﾘｽﾄ行の高さ
    Private Const CMlngCmbCol0                          As Integer = 0                 'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=0(機種ID)
    Private Const CMlngCmbCol1                          As Integer = 1                 'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=1(機種名)
    Private Const CMlngCmbCol2                          As Integer = 2                 'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=2(未使用)
    Private Const CMlngCmbCol3                          As Integer = 3                 'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=3(未使用)
    Private Const CMlngCmbCol4                          As Integer = 4                 'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=4(ForColor)
    Private Const CMlngCmbCol5                          As Integer = 5                 'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=5(BackColor)

    '@文字制限
    Private Const CMlngKeyBackSpace                     As Integer = 8                 'ﾊﾞｯｸｽﾍﾟｰｽのｱｽｷｰｺｰﾄﾞ
    Private Const CMlngKeyReturn                        As Integer = 13                'ｴﾝﾀｰｷｰのｱｽｷｰｺｰﾄﾞ
    Private Const CMlngKeyAsciiAster                    As Integer = 42                'ｱｽｷｰｺｰﾄﾞ-*
    Private Const CMlngKeyAsciiNum0                     As Integer = 48                'ｱｽｷｰｺｰﾄﾞ-0
    Private Const CMlngKeyAsciiNum9                     As Integer = 57                'ｱｽｷｰｺｰﾄﾞ-9
    Private Const CMlngKeyAsciiUppA                     As Integer = 65                'ｱｽｷｰｺｰﾄﾞ-A
    Private Const CMlngKeyAsciiUppZ                     As Integer = 90                'ｱｽｷｰｺｰﾄﾞ-Z
    Private Const CMlngKeyAsciiUnderBar                 As Integer = 95                'ｱｽｷｰｺｰﾄﾞ-_
    Private Const CMlngKeyAsciiLowA                     As Integer = 97                'ｱｽｷｰｺｰﾄﾞ-a
    Private Const CMlngKeyAsciiLowZ                     As Integer = 122               'ｱｽｷｰｺｰﾄﾞ-z

    Private Const CMstrUnderBar                         As String = "_"
    Private Const CMstrAsciiAster                       As String = "*"


    Private Const CMlngvsfTitle                         As Integer = 0
    Private Const CMstrHo                               As String = "保"            '保留表示
    Private Const CMstrTei                              As String = "停"            '停止表示
    Private Const CMstrRi                               As String = "リ"            'ﾘﾜｰｸ表示
    Private Const CMstrTsui                             As String = "追"            '追加表示
    Private Const CMstrSen                              As String = "先"            '先行表示
    Private Const CMstrIsai                             As String = "移"            '移載表示

    '@ｺﾝﾎﾞﾎﾞｯｸｽ(一覧)
    Private Const CMlngCmbDispCols1                     As Integer = 1                 'ｸﾞﾘｯﾄﾞ表示列数=1
    Private Const CMlngCmbDispCols2                     As Integer = 2                 'ｸﾞﾘｯﾄﾞ表示列数=2
    Private Const CMlngCmbValueCol0                     As Integer = 0                 '値取得個数=0
    Private Const CMlngCmbGroupCols                     As Integer = 1                 '列方向ｸﾞﾙｰﾌﾟ数
    Private Const CMlngCmbGridCol0                      As Integer = 0                 '名称列番=0
    Private Const CMlngCmbGridCol1                      As Integer = 1                 '名称列番=1
    Private Const CMlngCmbFontSize                      As Integer = 11                'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Integer = 11                'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCMbSelectMode                    As Integer = 1                 '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
    Private Const CMstrCmbAddedComment                  As String = " 項目選択"
    Private Const CMstrCmbAddedCommentNone              As String = "0 項目選択"
    Private Const CMlngCmbGetCol5                       As Integer = 5                 'ｺﾝﾎﾞﾎﾞｯｸｽ表示列=5(ﾊﾞｯｸｶﾗｰ)


    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private==========================================
    Private mtypChgSort                                 As ChgSort                          'ｿｰﾄ保持用
    Private mtypProductList                             As List(Of ProductList)             '機種ﾘｽﾄ構造体
    Private mlngProductCnt                              As Integer                          '機種ﾘｽﾄ数
    Private mtypFlowClassList                           As List(Of DivisionList)            '種別ﾘｽﾄ構造体
    Private mlngFlowClassCnt                            As Integer                          '種別ﾘｽﾄ数
    Private mblncmbPdValidateEvent                      As Boolean                          '機種Validate発生ﾌﾗｸﾞ(Ture:発生、False:発生なし)
    Private buttonProcessing                            As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                          'NSYS WindowCloseフラグ
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
    '作成日：2006/07/12 (Wed) 12:21:19 N.Kasai
    '更新日：2006/07/12 (Wed) 12:21:19
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns             As Boolean              '戻り値
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrClassDivision   As String               '処理区分
        
        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@画面初期化
            Call prvfrmxxEN01X7_Init()
            
            '@ｲﾍﾞﾝﾄ名格納
            lstrEventName = "Form_Load"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(Me.Name, lstrEventName)
            
            '@MSG【機種区分一覧取得】(CPstrCD2A & CPstrCD02：画面ｻｲｽﾞ指定なし-すべて)
            lblnAns = pubblnMasPdlist_Sel(CMstrmas_pdlist__Ver, _
                                          CPstrCD2A & CPstrCD02, _
                                          mtypProductList, _
                                          mlngProductCnt, _
                                          pstrSBID)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = CmdClose
                Exit Sub
            End If
            
            '@機種ｺﾝﾎﾞ格納
            Call prvcmbPd_Disp()
            
            '@流動区分一覧取得【全て】
            lstrClassDivision = CPstrCD02
            lblnAns = pubblnMasFlowlist_Sel(CMstrmas_flowlistVer, _
                                            mtypFlowClassList, _
                                            mlngFlowClassCnt, _
                                            pstrSBID, _
                                            lstrClassDivision)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = CmdClose
                Exit Sub
            End If
            
            '@種別情報ｾｯﾄ
            Call prvcmbFlowClass_Disp()
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)

            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
            
            '@Escﾎﾞﾀﾝを有効
            Me.CancelButton = CmdClose
            
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
    '機　能：ﾌｫｰﾑ　ｷｰ押下時
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift　：ｼﾌﾄ
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:21:33 N.Kasai
    '更新日：2006/07/12 (Wed) 12:21:33
    '備　考：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
                e.Handled = True
                Exit Sub
            End If

            Select Case e.KeyCode
                '@Enterの場合
                Case Keys.Return
                    Select Case ActiveControl.Name
                        Case vsfLotListCp.Name
                        '@一覧にﾌｫｰｶｽがある場合
                            With vsfLotListCp
                                '@ﾃﾞｰﾀ行の場合
                                If .Row >= .Rows.Fixed Then
                                    '@確定ﾎﾞﾀﾝの押下
                                    If cmdRegist.Enabled = True Then
                                        Call cmdRegist_Click(cmdRegist,New EventArgs)
                                    End If
                                End If
                            End With
                            
                        Case cmbPD.Name
                        '@機種にﾌｫｰｶｽがある場合
                            '@Validate処理へ
                            RemoveHandler cmbPd.Validating, AddressOf cmbPd_Validate
                            Call cmbPd_Validate(cmbPd,New CancelEventArgs(False))
                            AddHandler cmbPd.Validating, AddressOf cmbPd_Validate
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                        
                        Case txtLotID.Name
                        '@LotID欄にﾌｫｰｶｽがある場合
                            '@Validate処理へ
                            RemoveHandler txtLotID.Validating, AddressOf txtLotID_Validate
                            Call txtLotID_Validate(txtLotID,New CancelEventArgs(False))
                            AddHandler txtLotID.Validating, AddressOf txtLotID_Validate
                            '@ﾌｫｰｶｽ処理
                            If vsfLotListCp.Enabled = True Then
                                Call pubSetFocus(vsfLotListCp)
                            End If
                        
                        Case Else
                        '@その他
                            SendKeys.SendWait(CPstrSendKeysTab)
                            e.Handled = True
                    End Select
            End Select

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_KeyDown"               '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：Form_QueryUnload
    '機　能：終了処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '　　　：UnloadMode：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:21:50 N.Kasai
    '更新日：2006/07/12 (Wed) 12:21:50
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            '@構造体のｸﾘｱ
            'ｿｰﾄ保持用
            If mtypChgSort.typChgSortList Is Nothing Then
                mtypChgSort.typChgSortList = New List(Of ChgSortList)
            Else
                mtypChgSort.typChgSortList.Clear
            End If
            '機種ﾘｽﾄ構造体
            If mtypProductList Is Nothing Then
                mtypProductList = New List(Of ProductList)
            Else
                mtypProductList.Clear
            End If
            '種別ﾘｽﾄ構造体
            If mtypFlowClassList Is Nothing Then
                mtypFlowClassList = New List(Of DivisionList)
            Else
                mtypFlowClassList.Clear
            End If

            '@変数のｸﾘｱ
            mlngProductCnt = 0
            mlngFlowClassCnt = 0

            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
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
    '機　能：ﾌﾟﾛｸﾞﾗﾑ終了
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:55:59 N.Kasai
    '更新日：2006/07/12 (Wed) 12:55:59
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
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdClose_Click"             '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：optFlowClass_GotFocus
    '機　能：流動区分のﾌｫｰｶｽ取得時
    '引　数：Index：ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:56:20 N.Kasai
    '更新日：2006/07/12 (Wed) 12:56:20
    '備　考：機種ｺﾝﾎﾞのValideteにて種別にﾌｫｰｶｽがあたらない為、強引にﾌｫｰｶｽ設定する
    Private Sub optFlowClass_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles optFlowClass0.Enter,optFlowClass1.Enter,optFlowClass2.Enter

        Try

            Select Case sender.Name
                '@流動前
                Case optFlowClass0.Name
                    '@機種Validate発生ﾌﾗｸﾞの場合
                    If mblncmbPdValidateEvent = True Then
                        If cmbFlowClass.Enabled = True Then
                            '@種別へﾌｫｰｶｽ設定
                            Call pubSetFocus(cmbFlowClass)
                            mblncmbPdValidateEvent = False
                        End If
                    End If
            End Select
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "optFlowClass_GotFocus"      '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：optFlowClass_Click
    '機　能：種別　ｸﾘｯｸ時
    '引　数：Index：ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:56:35 N.Kasai
    '更新日：2006/07/12 (Wed) 12:56:35
    '備　考：
    Private Sub optFlowClass_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optFlowClass0.CheckedChanged, optFlowClass1.CheckedChanged, optFlowClass2.CheckedChanged

        Try

            '@検索結果ﾘｽﾄの初期化
            Call prvvsfLotListCp_Init()
            
            '@ﾎﾞﾀﾝの使用許可
            cmdRegist.Enabled = False      '確定ﾎﾞﾀﾝ
            
            '@最新取得ﾎﾞﾀﾝの使用許可
            Call prvcmdSearch_Set()

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "optFlowClass_Click"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：optSearch_Click
    '機　能：検索条件１選択　ｸﾘｯｸ時
    '引　数：Index：ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:56:52 N.Kasai
    '更新日：2006/07/12 (Wed) 12:56:52
    '備　考：
    Private Sub optSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optSearch0.CheckedChanged, optSearch1.CheckedChanged

        Try

            If sender.Checked = False Then
                Return
            End If

            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@検索結果ﾘｽﾄの初期化
            Call prvvsfLotListCp_Init()
            
            '@ﾎﾞﾀﾝの使用許可
            cmdRegist.Enabled = False      '確定ﾎﾞﾀﾝ
            
            '@検索ﾎﾞﾀﾝの使用許可
            Call prvcmdSearch_Set()
            
            Select Case sender.Name
                '@機種・種別が選択された場合
                Case optSearch0.Name
                    '@機種・種別使用可
                    cmbPD.Enabled = True
                    cmbFlowClass.Enabled = False
                    cmbPD.BackColor = Color.White
                    cmbFlowClass.BackColor = SystemColors.ControlLight
                    optFlowClass0.Enabled = True
                    optFlowClass1.Enabled = True
                    optFlowClass2.Enabled = True
                    
                    optFlowClass0.Checked = True
                    
                    fraKisyu.Enabled = True
                    
                    '@ﾛｯﾄID使用不可
                    txtLotID.Text = vbNullString
                    txtLotID.Enabled = False
                    txtLotID.BackColor = SystemColors.ControlLight
                    
                '@ﾛｯﾄIDが選択された場合
                Case optSearch1.Name
                    '@機種・種別使用不可
                    cmbPD.ListIndex = -1
                    cmbPD.Enabled = False
                    cmbPD.BackColor = SystemColors.ControlLight
                    cmbFlowClass.Text = vbNullString
                    cmbFlowClass.Enabled = False
                    cmbFlowClass.BackColor = SystemColors.ControlLight
                    optFlowClass0.Checked = False
                    optFlowClass1.Checked = False
                    optFlowClass2.Checked = False

                    optFlowClass0.Enabled = False
                    optFlowClass1.Enabled = False
                    optFlowClass2.Enabled = False

                    fraKisyu.Enabled = False
                    
                    '@ﾛｯﾄID使用可
                    txtLotID.Enabled = True
                    txtLotID.BackColor = Color.White
            End Select

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "optSearch_Click"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbPD_Change
    '機　能：機種 変更時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:57:18 N.Kasai
    '更新日：2006/07/12 (Wed) 12:57:18
    '備　考：
    Private Sub cmbPd_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPd.Change
        
        Try
            
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@検索結果ﾘｽﾄの初期化
            Call prvvsfLotListCp_Init()
            
            '@ﾎﾞﾀﾝの使用許可
            cmdRegist.Enabled = False           '確定ﾎﾞﾀﾝ
            cmdNowList.Enabled = False          '最新取得ﾎﾞﾀﾝ

            '@種別の初期化
            cmbFlowClass.Clear
            cmbFlowClass.Text = vbNullString    '種別の初期化
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbPd_Change"               '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbPD_CloseUp
    '機　能：機種 選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:57:30 N.Kasai
    '更新日：2006/07/12 (Wed) 12:57:30
    '備　考：
    Private Sub cmbPd_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPd.CloseUp

        Try

            '@空欄 or 0項目以外の場合
            If cmbPD.Text <> vbNullString And _
                cmbPD.Text <> CMstrCmbAddedCommentNone Then
                '@Validate処理
                RemoveHandler cmbPd.Validating,AddressOf cmbPd_Validate
                Call cmbPd_Validate(cmbPd,New CancelEventArgs(True))
                AddHandler cmbPd.Validating,AddressOf cmbPd_Validate
            Else
                cmbFlowClass.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbPd_CloseUp"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbPD_Validate
    '機　能：機種 Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:57:45 N.Kasai
    '更新日：2006/07/12 (Wed) 12:57:45
    '備　考：
    Private Sub cmbPd_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPd.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@機種ｺﾝﾎﾞ選択可否
            If cmbPD.Text = vbNullString Or _
                cmbPD.Text = CMstrCmbAddedCommentNone Then
                '@空欄 or 0項目の場合
                Exit Sub
            End If
            
            '@取得情報を種別一覧へｾｯﾄ
            Call prvcmbFlowClass_Disp()
            
            '@最新取得ﾎﾞﾀﾝの使用許可
            Call prvcmdSearch_Set()

            '@種別を有効にする
            cmbFlowClass.Enabled = True
            cmbFlowClass.BackColor = Color.White

            If ActiveControl.Name = cmbPd.Name Then
                Call pubSetFocus(cmbFlowClass)
            End If
            
            '@種別へ強制ﾌｫｰｶｽ設定
            mblncmbPdValidateEvent = True
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbPd_Validate"             '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbFlowClass_Change
    '機　能：種別ｺﾝﾎﾞ　変更時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:58:19 N.Kasai
    '更新日：2006/07/12 (Wed) 12:58:19
    '備　考：
    Private Sub cmbFlowClass_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbFlowClass.Change
        
        Try

            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@検索結果ﾘｽﾄの初期化
            Call prvvsfLotListCp_Init()
            
            '@ﾎﾞﾀﾝの使用許可
            cmdRegist.Enabled = False      '確定ﾎﾞﾀﾝ
            
            '@最新取得ﾎﾞﾀﾝの使用許可
            Call prvcmdSearch_Set()

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbFlowClass_Change"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbFlowClass_CloseUp
    '機　能：種別の選択
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:58:36 N.Kasai
    '更新日：2006/07/12 (Wed) 12:58:36
    '備　考：
    Private Sub cmbFlowClass_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbFlowClass.CloseUp

        Try

            '@Validate処理へ
            If cmbFlowClass.Text <> vbNullString Then
                RemoveHandler cmbFlowClass.Validating,AddressOf cmbFlowClass_Validate
                Call cmbFlowClass_Validate(cmbFlowClass,New CancelEventArgs(True))
                AddHandler cmbFlowClass.Validating,AddressOf cmbFlowClass_Validate
                SendKeys.SendWait(CPstrSendKeysTab)
            End If

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbFlowClass_CloseUp"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbFlowClass_Validate
    '機　能：種別のValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:58:48 N.Kasai
    '更新日：2006/07/12 (Wed) 12:58:48
    '備　考：
    Private Sub cmbFlowClass_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbFlowClass.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@最新取得ﾎﾞﾀﾝの使用許可
            Call prvcmdSearch_Set()

            '@種別退避
        '    mstrFlowClass = Trim$(cmbFlowClass.Text)

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbFlowClass_Validate"      '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtLotID_Change
    '機　能：ﾛｯﾄID　変更時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:59:04 N.Kasai
    '更新日：2006/07/12 (Wed) 12:59:04
    '備　考：
    Private Sub txtLotID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtLotID.Change

        Try

            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            '@検索結果ﾘｽﾄの初期化
            Call prvvsfLotListCp_Init()
            
            '@ﾎﾞﾀﾝの使用許可
            cmdRegist.Enabled = False      '確定ﾎﾞﾀﾝ
            
            '@最新取得ﾎﾞﾀﾝの使用許可
            Call prvcmdSearch_Set()

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtLotID_Change"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtLotID_KeyPress
    '機　能：ﾛｯﾄID　ｷｰ押下時
    '引　数：KeyAscii：ｱｽｷｰｺｰﾄﾞ
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:59:22 N.Kasai
    '更新日：2006/07/12 (Wed) 12:59:22
    '備　考：
    Private Sub txtLotID_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtLotID.KeyPress
        
        Try
            
            '@全角の入力を制御(記号可)
            Select Case Asc(e.KeyChar)
                '@0～9、A～Z、ﾊﾞｯｸｽﾍﾟｰｽ、ｴﾝﾀｰ、*、_　入力可
                Case CMlngKeyAsciiNum0 To CMlngKeyAsciiNum9, _
                     CMlngKeyAsciiUppA To CMlngKeyAsciiUppZ, _
                     CMlngKeyAsciiLowA To CMlngKeyAsciiLowZ, _
                     CMlngKeyBackSpace, CMlngKeyReturn, _
                     CMlngKeyAsciiAster, CMlngKeyAsciiUnderBar
                '@それ以外は入力不可
                Case Else
                    e.Handled = True 'ｷｰ無効
                    
            End Select
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtLotID_KeyPress"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtLotID_Validate
    '機　能：ﾛｯﾄIDのValidate
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 12:59:40 N.Kasai
    '更新日：2006/07/12 (Wed) 12:59:40
    '備　考：
    Private Sub txtLotID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtLotID.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If txtLotID.Text <> vbNullString Then
                If Len(txtLotID.Text) < 2 Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001H)
                    '@「ロットIDは2桁以上入力してください。」
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    e.Cancel = True
                    Exit Sub
                End If
                
                '@最新取得
                Call cmdNowList_Click(cmdNowList,New EventArgs)
                
                If vsfLotListCp.Enabled = True Then
                    If ActiveControl.Name = txtLotID.Name Then
                        Call pubSetFocus(vsfLotListCp)
                    End If
                End If
            End If

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtLotID_Validate"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdNowList_Click
    '機　能：最新取得ﾎﾞﾀﾝ　押下時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/30 (Fri) 11:46:14 N.Kasai
    '更新日：2006/06/30 (Fri) 11:46:14
    '備　考：
    Private Sub cmdNowList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowList.Click
        
        Dim lblnAns                 As Boolean              '結果格納
        Dim ltypProcLotListReq      As ProcLotListReq       'ﾛｯﾄ一覧要求情報構造体
        Dim ltypProcLotListAns      As ProcLotListAns       'ﾛｯﾄ一覧取得情報格納
        Dim lstrLotFlowStatusID     As String               '流動区分(0:流動中,1:流動前 2:流動外)
        Dim lstrLotID               As String               'ﾛｯﾄID
        Dim lstrTemp                As Object               '一時取得
        Dim llngCnt                 As Integer              '汎用ｶｳﾝﾀ
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名格納(ﾚｽﾎﾟﾝｽ用)

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

            '@検索ﾁｪｯｸ
            If prvblnSearchClick_Chk = False Then
                Exit Sub
            End If
            
            '@MSG実行
            Select Case True
            
                Case optSearch0.Checked = True
                    '@流動区分(種別ID)
                    Select Case True
                        Case optFlowClass0.Checked = True
                            lstrLotFlowStatusID = Trim$(str(CMlngFlowClass0))   '流動前
                        
                        Case optFlowClass1.Checked = True
                            lstrLotFlowStatusID = Trim$(str(CMlngFlowClass1))   '流動中
                        
                        Case optFlowClass2.Checked = True
                            lstrLotFlowStatusID = Trim$(str(CMlngFlowClass2))   '流動終了
                    End Select
                    
                    
                    '@要求構造体へ情報を格納    '流動区分(0:流動中,1:流動前 2:流動外)
                    With ltypProcLotListReq
                        .strSbID = pstrSBID                                                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                        .strAction = "1"                                                        'ｱｸｼｮﾝ(工順変更中ﾛｯﾄを含む)
                        .strMsgVer = CMstrproclist____Ver                                       'Msgﾊﾞｰｼﾞｮﾝ
                        .strLotFlowStatusID = lstrLotFlowStatusID                               '流動区分
                        
                        '@機種指定
                        .lngPdCnt = cmbPD.ValueCount                                            'ｶｳﾝﾄ数
                        '@種別区分構造体作成
                        If .typPdList Is Nothing Then
                            .typPdList = New List(Of PDList)
                        Else
                            .typPdList.Clear
                        End If
                        Dim typPdListTmp As New PDList

                        lstrTemp = Split(cmbPD.Value, vbTab)
                        For llngCnt = LBound(lstrTemp) To UBound(lstrTemp)
                            typPdListTmp.strPdId = lstrTemp(llngCnt)                 '機種ID
                            .typPdList.Add(typPdListTmp)
                        Next llngCnt
                        
                        '@種別区分構造体作成
                        .lngFlowClassListCnt = cmbFlowClass.ValueCount                          'ｶｳﾝﾄ数

                        If .typFlowClassList Is Nothing Then
                            .typFlowClassList = New List(Of FlowClassList)
                        Else
                            .typFlowClassList.Clear
                        End If
                        Dim typFlowClassListTmp As New FlowClassList

                        lstrTemp = Split(cmbFlowClass.Value, vbTab)
                        For llngCnt = LBound(lstrTemp) To UBound(lstrTemp)
                            typFlowClassListTmp.strFlowClass = lstrTemp(llngCnt)     '種別ID
                            .typFlowClassList.Add(typFlowClassListTmp)
                        Next llngCnt

                        .strLotID = vbNullString                                                'ﾛｯﾄID
                        .strCarrierId = vbNullString                                            'ｷｬﾘｱID
                    End With

                Case optSearch1.Checked = True
                    '@ﾛｯﾄIDが10桁ない場合
                    If Len(txtLotID.Text) < 10 Then
                        '@ﾛｯﾄID + "*"
                        lstrLotID = txtLotID.Text & CMstrAsciiAster
                    Else
                        lstrLotID = txtLotID.Text
                    End If
                    
                    '@要求構造体へ情報を格納    '流動区分(0:流動中,1:流動前 2:流動外)
                    With ltypProcLotListReq
                        .strSbID = pstrSBID                                                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                        .strAction = "1"                                                        'ｱｸｼｮﾝ(工順変更中ﾛｯﾄを含む)
                        .strMsgVer = CMstrproclist____Ver                                       'Msgﾊﾞｰｼﾞｮﾝ
                        .strLotFlowStatusID = vbNullString                                      '流動区分
                        
                        '@種別区分構造体作成
                        .lngPdCnt = 0                                                           '種別ｶｳﾝﾄ
                        If .typPdList Is Nothing Then
                            .typPdList = New List(Of PDList)
                        Else
                            .typPdList.Clear
                        End If

                        '@種別区分構造体作成
                        .lngFlowClassListCnt = 0                                                '種別ｶｳﾝﾄ
                        If .typFlowClassList Is Nothing Then
                            .typFlowClassList = New List(Of FlowClassList)
                        Else
                            .typFlowClassList.Clear
                        End If

                        .strLotID = lstrLotID                                                   'ﾛｯﾄID
                        .strCarrierId = vbNullString                                            'ｷｬﾘｱID
                    End With
                    
            End Select
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrEventName = "cmdSearch_Click"
            Call pubResponseStart(Me.Name, lstrEventName)
            
            '@=======================
            '@ MSG【ﾛｯﾄ一覧】を実行
            '@=======================
            lblnAns = pubblnProcList_Sel(ltypProcLotListReq, ltypProcLotListAns)

            '@結果判定
            If lblnAns = True Then
                '@ﾛｯﾄ一覧取得に成功

                '@検索結果表示
                If ltypProcLotListAns.lngProcLotListCnt > 0 Then
                    '@一覧表示
                    Call prvvsfLotListCp_Disp(ltypProcLotListAns)
                    '@ﾌｫｰｶｽ設定
                    Call pubSetFocus(vsfLotListCp)
                Else
                    '@検索結果ﾘｽﾄの初期化
                    Call prvvsfLotListCp_Init()
                End If

                '@情報取得日時表示
                lblNowDate.Text = Format$(Now, CPstrDateFormat)

                '@該当件数ﾗﾍﾞﾙに取得件数を表示
                lblLotCnt.Text = Format$(CInt(ltypProcLotListAns.lngProcLotListCnt), CPstrDateFormatKanma)

            Else
                '@ﾛｯﾄ一覧取得に失敗

                '@検索結果ﾘｽﾄの初期化
                Call prvvsfLotListCp_Init()

                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)

                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(Me.Name, lstrEventName)
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdSearch_Click"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With
          
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：確定ﾎﾞﾀﾝ　ｸﾘｯｸ時
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/30 (Fri) 19:05:05 N.Kasai
    '更新日：2006/06/30 (Fri) 19:05:05
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
            
            '@引継ぎ構造体に値を格納
            With ptypEN01X7
                .strLotID = vsfLotListCp.GetData(vsfLotListCp.Row, CMlngvsfLotID)
                .strNowDate = lblNowDate.Text
                .strProcFlag = vsfLotListCp.GetData(vsfLotListCp.Row, CMlngvsfProcFlag)
            End With
            
            '@ﾛｯﾄ一覧画面を閉じる
            Call cmdClose_Click(cmdClose,New EventArgs)
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdRegist_Click"           '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfLotListCp_AfterSort
    '機　能：検索結果ﾘｽﾄ ｿｰﾄ後処理
    '引　数：Col：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 13:00:26 N.Kasai
    '更新日：2006/07/12 (Wed) 13:00:26
    '備　考：
    Private Sub vsfLotListCp_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotListCp.AfterSort

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListCp.Rows.Count <= vsfLotListCp.Rows.Fixed Then
                Return
            End If

            AddHandler vsfLotListCp.BeforeRowColChange,AddressOf vsfLotListCp_BeforeRowColChange

            '@ｿｰﾄ順を格納
            With mtypChgSort
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                End If

                Dim typChgSortListTmp As New ChgSortList

                '@ｿｰﾄ列番号を格納
                typChgSortListTmp.lngCol =e. Col
                '@並び替え方法を格納(昇順/降順)
                typChgSortListTmp.lngOrder = e.Order

                .typChgSortList.Add(typChgSortListTmp)

                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1

            End With
            
            '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列)
            Call pubVsfAfterSort(vsfLotListCp, CMlngvsfLotID)
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfLotListCp_AfterSort"     '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfLotListCp_AfterUserResize
    '機　能：列幅変更後処理
    '引　数：Row：行番号
    '　　　：Col：列番号
    '戻り値：
    '作成日：2006/07/12 (Wed) 13:00:51 N.Kasai
    '更新日：2006/07/12 (Wed) 13:00:51
    '備　考：
    Private Sub vsfLotListCp_AfterUserResize(ByVal sender As Object, ByVal e As RowColEventArgs) Handles vsfLotListCp.AfterResizeColumn, vsfLotListCp.AfterResizeRow
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListCp.Rows.Count <= vsfLotListCp.Rows.Fixed Then
                Return
            End If
            
            '@列幅変更ﾌﾗｸﾞ(変更)
            mtypChgSort.blnChgWidth = True

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                     '機能ID
                .strProcName = "vsfLotListCp_AfterUserResize"    '処理名
                .strErrMessage = vbNullString                       'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfLotListCp_BeforeRowColChange
    '機　能：行列変更前処理
    '引　数：OldRow：旧行番号
    '　　　：OldCol：旧列番号
    '　　　：NewRow：新行番号
    '　　　：NewCol：新列番号
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 13:01:06 N.Kasai
    '更新日：2006/07/12 (Wed) 13:01:06
    '備　考：
    Private Sub vsfLotListCp_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfLotListCp.BeforeRowColChange
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListCp.Rows.Count <= vsfLotListCp.Rows.Fixed Then
                Return
            End If
            
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(ﾛｯﾄID)
                mtypChgSort.strKey = vsfLotListCp.GetData(e.NewRange.r1, CMlngvsfLotID)
            End If

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                         '機能ID
                .strProcName = "vsfLotListCp_BeforeRowColChange"     '処理名
                .strErrMessage = vbNullString                           'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfLotListCp_BeforeSort
    '機　能：検索結果ﾘｽﾄ ｿｰﾄ前処理
    '引　数：Col　：列番号
    '　　　：Order：ｿｰﾄ値
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 13:01:19 N.Kasai
    '更新日：2006/07/12 (Wed) 13:01:19
    '備　考：
    Private Sub vsfLotListCp_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfLotListCp.BeforeSort

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListCp.Rows.Count <= vsfLotListCp.Rows.Fixed Then
                Return
            End If

            RemoveHandler vsfLotListCp.BeforeRowColChange,AddressOf vsfLotListCp_BeforeRowColChange

            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
            Call pubVsfBeforeSort(vsfLotListCp, CMlngvsfLotID)

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfLotListCp_BeforeSort" '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfLotListCp_DblClick
    '機　能：検索結果ｸﾞﾘｯﾄのﾀﾞﾌﾞﾙｸﾘｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 13:01:34 N.Kasai
    '更新日：2006/07/12 (Wed) 13:01:34
    '備　考：
    Private Sub vsfLotListCp_DblClick(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotListCp.DoubleClick

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListCp.Rows.Count <= vsfLotListCp.Rows.Fixed Then
                Return
            End If

            '@ﾍｯﾀﾞｰﾀﾞﾌﾞﾙｸﾘｯｸの場合
            If vsfLotListCp.MouseRow <= 0 Then
                Exit Sub
            End If
            
            '@確定ﾎﾞﾀﾝの押下
            If cmdRegist.Enabled = True Then
                Call cmdRegist_Click(cmdRegist,New EventArgs)
            End If

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfLotListCp_DblClick"   '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：vsfLotListCp_EnterCell
    '機　能：検索結果ｸﾞﾘｯﾄ ｶﾚﾝﾄ選択
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 13:01:58 N.Kasai
    '更新日：2006/07/12 (Wed) 13:01:58
    '備　考：
    Private Sub vsfLotListCp_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfLotListCp.EnterCell

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfLotListCp.Rows.Count <= vsfLotListCp.Rows.Fixed Then
                Return
            End If

            '@固定行判定
            If vsfLotListCp.Row < 1 Then
                Exit Sub
            End If
            
            '@確定ﾎﾞﾀﾝの有効
            cmdRegist.Enabled = True
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "vsfLotListCp_EnterCell"  '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvfrmxxEN01X7_Init
    '機　能：ﾌｫｰﾑのｸﾘｱ
    '引　数：なし
    '戻り値：なし
    '作成日：2006/07/12 (Wed) 13:02:11 N.Kasai
    '更新日：2009/02/25 (Wed) 19:33:56 N.Kojima
    '備　考：
    '　　　：2009/02/25 (Wed) 19:33:56 N.Kojima     ﾁｯﾌﾟ品判別説明ﾗﾍﾞﾙの制御処理追加。(案件№03402)
    Private Sub prvfrmxxEN01X7_Init()
        
        Dim ltypEN01X7 As EN01X7    '引継ぎ構造体
        
        Try
            
            '@引継ぎ構造体のｸﾘｱ
            ptypEN01X7 = ltypEN01X7
            
        '@↓2009/03/02 (Mon) 14:47:38 N.Kojima **************************************************
            
            '@-----------------------
            '@ ﾗﾍﾞﾙﾊﾞｯｸｶﾗｰ設定
            '@-----------------------
            '@起動SBが"2A0：組立"か
            If pstrSBID = CPstrSBID2A0 Then
                '@2A0：組立の場合
            
                lblTitleL.BackColor = ColorTranslator.FromWin32(CPlngLColor)           '機種L
                lblTitleR.BackColor = ColorTranslator.FromWin32(CPlngRColor)           '機種R
                lblTitleL.Visible = True
                lblTitleR.Visible = True
                lblTitleChip.Visible = True                 'ﾁｯﾌﾟ品説明
            Else
                '@1A0：基板の場合
            
                lblTitleL.Visible = False
                lblTitleR.Visible = False
                lblTitleChip.Visible = False                'ﾁｯﾌﾟ品説明
            End If

        '@↑2009/03/02 (Mon) 14:47:38 N.Kojima **************************************************
            
            lblTitleHT.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)    '保留/停止
            
            '@内容のｸﾘｱ
            optSearch0.checked = True
            optFlowClass0.checked = True
            txtLotID.Text = vbNullString
            lblNowDate.Text = vbNullString
            lblLotCnt.Text = vbNullString

            '@機種・種別使用可
            cmbPD.Enabled = True
            cmbFlowClass.Enabled = False
            cmbPD.BackColor = Color.White
            cmbFlowClass.BackColor = SystemColors.ControlLight
            fraKisyu.Enabled = True
            
            '@ﾛｯﾄID使用不可
            txtLotID.Enabled = False
            txtLotID.BackColor = SystemColors.ControlLight
            
            '@検索結果ﾘｽﾄの初期化
            Call prvvsfLotListCp_Init()
            
            '@ﾎﾞﾀﾝの使用許可
            cmdRegist.Enabled = False           '確定ﾎﾞﾀﾝ
            cmdNowList.Enabled = False          '最新取得ﾎﾞﾀﾝ
            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxEN01X7_Init"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvcmdSearch_Chk
    '機　能：最新取得ﾁｪｯｸ
    '引　数：なし
    '戻り値：True：成功　False：失敗
    '作成日：2006/07/12 (Wed) 13:02:35 N.Kasai
    '更新日：2006/07/12 (Wed) 13:02:35
    '備　考：
    Private Function prvcmdSearch_Chk() As Boolean
        
        Try

            '@初期化
            prvcmdSearch_Chk = False
            
            Select Case True
                '@機種・種別の場合
                Case optSearch0.checked
                
                    '@機種ﾁｪｯｸ
                    cmbPD.ValueCol = CMlngCmbCol0
                    
                    If cmbPD.Value = vbNullString Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0013)
                        '@"機種が指定されていません。機種を指定してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        Call pubSetFocus(cmbPD)
                        
                        Exit Function
                    End If
                    
                    '@種別ﾁｪｯｸ
                    cmbFlowClass.ValueCol = CMlngCmbCol0
                    If cmbFlowClass.Value = vbNullString Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0014)
                        '@"種別が指定されていません。種別を指定してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        Call pubSetFocus(cmbFlowClass)
                        
                        Exit Function
                    End If
                    
                '@ﾛｯﾄIDの場合
                Case optSearch1.checked
                    If Len(txtLotID.Text) < 2 Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001H)
                        '@「ロットIDは2桁以上入力してください。」
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        Call pubSetFocus(txtLotID)
                        
                        Exit Function
                    End If
               
            End Select
            
            '@成功
            prvcmdSearch_Chk = True
            
            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmdSearch_Chk"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvvsfLotListCp_Init
    '機　能：ｺﾋﾟｰ元ﾛｯﾄ一覧ｸﾞﾘｯﾄﾞ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/30 (Fri) 14:01:50 N.Kasai
    '更新日：2008/06/11 (Wed) 16:05:22 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 16:05:22 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvvsfLotListCp_Init()

        Try

            '@一覧表示の各ｶﾗﾑの幅,ﾀｲﾄﾙを設定
            With vsfLotListCp
                
                '@ｸﾘｱ
                .Clear(ClearFlags.Content)
                
                '@初期行数設定
                .Rows.Count = 1
                .Cols.Count = CMlngvsfMaxCols
                '@一覧表の表題設定
                Dim lFixedStyle As CellStyle
                lFixedStyle = .Styles.Fixed
                lFixedStyle.ForeColor = Color.Yellow                   '文字色
                lFixedStyle.BackColor = Color.Navy                     '背景色
                
                '@ﾀｲﾄﾙ設定
                .SetData(CMlngvsfTRow, CMlngvsfNo, CMstrvsftNo)                           '№                                                                     '保/停
                .SetData(CMlngvsfTRow, CMlngvsfKb, CMstrvsfTKb)                           '保/停                                                                     '保/停
                .SetData(CMlngvsfTRow, CMlngvsfLotID, CMstrvsfTLotID)                     'ﾛｯﾄID
                .SetData(CMlngvsfTRow, CMlngvsfPdID, CMstrvsfTPdID)                       '機種ID
                .SetData(CMlngvsfTRow, CMlngvsfFlowClass, CMstrvsfTFlowClass)             '種別
                .SetData(CMlngvsfTRow, CMlngvsfNowSt, CMstrvsfTNowSt)                     '状態
                .SetData(CMlngvsfTRow, CMlngvsfLotManagerName, CMstrvsfTLotManagerName)   'ﾛｯﾄ担当
                .SetData(CMlngvsfTRow, CMlngvsfEditTime, CMstrvsfTEditTime)               '最終更新日時
                .SetData(CMlngvsfTRow, CMlngvsfProcFlag, CMstrvsfTProcFlag)               'ﾘﾜｰｸﾌﾗｸﾞ

                
                '@表示位置の設定(中央寄せ中央揃え)
                lFixedStyle.TextAlign = TextAlignEnum.CenterCenter

                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngvsfTRow).Height = CMlngvsfHdHeight     '高さ
                
                '@表示位置設定
                .Cols(CMlngvsfNo).TextAlign = TextAlignEnum.RightCenter                    '№

                
                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                
                    '@列幅設定
                    .Cols(CMlngvsfNo).Width = CMlngvsfwNo                             '№
                    .Cols(CMlngvsfKb).Width = CMlngvsfWKb                             '保/停
                    .Cols(CMlngvsfLotID).Width = CMlngvsfWLotID                       'ﾛｯﾄID
                    .Cols(CMlngvsfNowSt).Width = CMlngvsfWNowSt                       '状態
                    .Cols(CMlngvsfPdID).Width = CMlngvsfWPdID                         '機種
                    .Cols(CMlngvsfFlowClass).Width = CMlngvsfWFlowClass               '種別
                    .Cols(CMlngvsfLotManagerName).Width = CMlngvsfWLotManagerName     'ﾛｯﾄ担当
                    .Cols(CMlngvsfEditTime).Width = CMlngvsfWEditTime                 '最終更新日時
                    .Cols(CMlngvsfProcFlag).Width = CMlngvsfWProcFlag                 'ﾘﾜｰｸﾌﾗｸﾞ
                End If
                
                '@ﾏｳｽによる列ｻｲｽﾞ変更の可／不可設定
                .AllowResizing = AllowResizingEnum.Columns
                
                '@非表示列
                .Cols(CMlngvsfProcFlag).Visible = False
                .Cols(CMlngvsfEditTime).Visible = False
                
                '@情報取得日時初期化
                lblNowDate.Text = vbNullString

                '@該当件数ﾗﾍﾞﾙの初期化
                lblLotCnt.Text = vbNullString
                
                '@使用不可
                .Enabled = False
            End With

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvvsfLotListCp_Init"    '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvvsfLotListCp_Disp
    '機　能：ｺﾋﾟｰ元ﾛｯﾄ一覧表示
    '引　数：ltypProcLotListAns：ﾃﾞｰﾀ格納構造体
    '戻り値：なし
    '作成日：2006/06/30 (Fri) 13:45:48 N.Kasai
    '更新日：2009/12/02 (Wed) 10:43:06 H.Hayashi
    '備　考：
    '　　　：2006/10/20 (Fri) 12:01:28 M.Miura      保/停区分の結合表示(案件№01565)
    '　　　：2008/06/11 (Wed) 16:07:06 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2009/02/25 (Wed) 11:52:25 N.Kojima     起動SBが組立、かつ送品先が"7x0：ﾁｯﾌﾟ品"だったらﾌｫﾝﾄの色を青にする。(案件№03402)
    '　　　：2009/12/02 (Wed) 10:43:06 H.Hayashi    ﾁｯﾌﾟ品判定ﾛｼﾞｯｸ部変更。(案件No.03810)
    Private Sub prvvsfLotListCp_Disp(ByRef ltypProcLotListAns As ProcLotListAns)

        Dim llngCnt                     As Integer      'ｶｳﾝﾄ
        Dim newStyle_white              As CellStyle    'NSYS追加 背景色 白
        Dim newStyle_yellow             As CellStyle    'NSYS追加 背景色 黄
        Dim newStyle_blue               As CellStyle    'NSYS追加 背景色 水
        Dim newStyle_pink               As CellStyle    'NSYS追加 背景色 ﾋﾟﾝｸ
        Dim newStyle_Bule               As CellStyle    'NSYS追加 背景色 青

        Try

            With vsfLotListCp
            
                '@描画ﾛｯｸ
                .Redraw = False

                RemoveHandler vsfLotListCp.BeforeRowColChange,AddressOf vsfLotListCp_BeforeRowColChange

                'NSYS クリア
                .Row = -1
                '@行数設定
                .Rows.Count = .Rows.Fixed
                .Rows.Count = ltypProcLotListAns.lngProcLotListCnt + 1

                '@ｴﾘｱ装置用途情報設定
                newStyle_white = .Styles.Add("CustomStyle_BackColor_vbWhite")
                newStyle_white.BackColor = Color.White                                       '白色
                newStyle_white.ForeColor =  Color.Black                                      '黒色
                newStyle_yellow = .Styles.Add("CustomStyle_BackColor_CPlngHoldLotColor")
                newStyle_yellow.BackColor = ColorTranslator.FromWin32(CPlngHoldLotColor)　   '黄
                newStyle_yellow.ForeColor =  Color.Black                                     '黒色
                newStyle_blue = .Styles.Add("CustomStyle_BackColor_CPlngLColor")
                newStyle_blue.BackColor= ColorTranslator.FromWin32(CPlngLColor)　            '水
                newStyle_blue.ForeColor =  Color.Black                                       '黒色
                newStyle_pink = .Styles.Add("CustomStyle_BackColor_CPlngRColor")
                newStyle_pink.BackColor= ColorTranslator.FromWin32(CPlngRColor)　            'ピンク
                newStyle_pink.ForeColor =  Color.Black                                       '黒色
                newStyle_Bule = .Styles.Add("CustomStyle_BackColor_vbBlue")
                newStyle_Bule.ForeColor =  Color.Blue                                        '青

                For llngCnt = 1 To ltypProcLotListAns.lngProcLotListCnt
                    
                    '@ｾﾙ色変更
                    Dim cellRange As CellRange = .GetCellRange(llngCnt, CMlngvsfTitle, llngCnt, .Cols.Count - 1)
                    cellRange.Style = newStyle_white                                    
                    
                    .SetData(llngCnt, CMlngvsfNo, llngCnt)                                                             '№
                    
                    .SetData(llngCnt, CMlngvsfLotID, _
                         ltypProcLotListAns.typProcLotList(llngCnt -1).strLotID)                                       'ﾛｯﾄID

                    .SetData(llngCnt, CMlngvsfPdID, _
                         ltypProcLotListAns.typProcLotList(llngCnt -1).strPdId)                                        '機種
                    
                    .SetData(llngCnt, CMlngvsfFlowClass, _
                         ltypProcLotListAns.typProcLotList(llngCnt -1).strFlowClass)                                   '種別
                    
                    .SetData(llngCnt, CMlngvsfNowSt, _
                         ltypProcLotListAns.typProcLotList(llngCnt -1).strNowST)                                       'ﾛｯﾄ現在状態
                                
                    .SetData(llngCnt, CMlngvsfLotManagerName, _
                         ltypProcLotListAns.typProcLotList(llngCnt -1).strEngEmpName)                                  'ﾛｯﾄ担当
                    
                    .SetData(llngCnt, CMlngvsfEditTime, _
                         Format$(CDate(ltypProcLotListAns.typProcLotList(llngCnt -1).strLotLastUpdate), CPstrDateTimeYMDHMS)) '最終更新日時
                    
                    .SetData(llngCnt, CMlngvsfProcFlag, _
                         ltypProcLotListAns.typProcLotList(llngCnt -1).strProcFlag)                                    'ﾛｯﾄ種別ﾌﾗｸﾞ(0:通常ﾛｯﾄ、1:特殊ﾛｯﾄ)
                    
                    '@------------------------------------
                    '@ 背景色の優先順位　保留/停止>L/R色
                    '@------------------------------------
                    '@L/Rによる文字色変更
                    Select Case ltypProcLotListAns.typProcLotList(llngCnt -1).strLcDirection
                        Case CPstrPDIDL
                             '@ｾﾙ背景色変更
                            cellRange.Style = newStyle_blue                                                                 　'Lｶﾗｰ(水色)
                        Case CPstrPDIDR
                             '@ｾﾙ背景色変更
                            cellRange.Style = newStyle_pink                                                                   'Rｶﾗｰ(ﾋﾟﾝｸ)
                        Case Else
                            '@ｾﾙ背景色変更
                            cellRange.Style = newStyle_white                                                                  '初期(白)
                    End Select

                    
                    '@ﾌﾗｸﾞ判定(ﾛｯﾄ保留)
                    If ltypProcLotListAns.typProcLotList(llngCnt -1).strLotHoldFlag = CMstrLotHoldFlgOn Then
                        '@ｾﾙの色変更
                        cellRange.Style = newStyle_yellow    '黄色
                                               
                        '@保/停列に表示
                        .SetData(llngCnt, CMlngvsfKb, _
                        pubstrColKbn_Set(.GetData(llngCnt, CMlngvsfKb), CMstrHo))                   '保
                    End If

                    '@ﾌﾗｸﾞ判定(ﾛｯﾄ停止)
                    If ltypProcLotListAns.typProcLotList(llngCnt -1).strLotStopFlag = CMstrLotStopFlgOn Then
                    
                        
                        '@ｾﾙ色変更
                        cellRange.Style = newStyle_yellow    '黄色     
                                               
                        '@保/停列に表示
                        .SetData(llngCnt, CMlngvsfKb, _
                        pubstrColKbn_Set(.GetData(llngCnt, CMlngvsfKb), CMstrTei))                  '停
                    End If
                    
                    '@ﾌﾗｸﾞ判定(ﾘﾜｰｸ/追加)
                    Select Case ltypProcLotListAns.typProcLotList(llngCnt -1).strReworkFlag
                        Case CMstrReworkFlgOn
                            '@保/停列に表示
                            .SetData(llngCnt, CMlngvsfKb, _
                            pubstrColKbn_Set(.GetData(llngCnt, CMlngvsfKb), CMstrRi))               'リ
                        Case CMstrLotReworkFlgOn2
                            '@保/停列に表示
                            .SetData(llngCnt, CMlngvsfKb, _
                            pubstrColKbn_Set(.GetData(llngCnt, CMlngvsfKb), CMstrTsui))             'リ
                    End Select
                    
                    '@WF移載予約中の場合
                    If ltypProcLotListAns.typProcLotList(llngCnt -1).strWfCarryFlag = "1" Then
                        '@保/停列に表示
                        .SetData(llngCnt, CMlngvsfKb, _
                        pubstrColKbn_Set(.GetData(llngCnt, CMlngvsfKb), CMstrIsai))                 '移
                    End If
                    
        '@↓2009/02/24 (Tue) 15:48:35 N.Kojima **************************************************

                    '@-----------------------------------------------
                    '@ ﾌｫﾝﾄ色の設定(組立限定機能)
                    '@　①ﾁｯﾌﾟ品LOT：青色
                    '@-----------------------------------------------
        '@↓2009/12/02 (Wed) 10:44:11 H.Hayashi **************************************************
                    '@起動SBが組立、かつｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"か
        '            If pstrSBID = CPstrSBID2A0 And _
        '                Left$(ltypProcLotListAns.typProcLotList(llngCnt).strSendSBID, 1) = CPstrProductChip Then
                    
                    If pstrSBID = CPstrSBID2A0 And _
                        ltypProcLotListAns.typProcLotList(llngCnt -1).strSbArea = CPstrProductChip Then
                        
                        '@起動SBが組立、かつｼｽﾃﾑﾌﾞﾛｯｸｴﾘｱが"7：ﾁｯﾌﾟ品"の場合
        '@↑2009/12/02 (Wed) 10:44:11 H.Hayashi **************************************************
                        
                        '@文字色を青色に変更
                        newStyle_Bule.BackColor = cellRange.Style.BackColor
                        cellRange.Style = newStyle_Bule
                    
                    End If

        '@↑2009/02/24 (Tue) 15:48:35 N.Kojima **************************************************
                    
                    '@高さの設定
                    .Rows(llngCnt).Height = CMlngvsfBdHeight

                Next llngCnt

                '@ﾕｰｻﾞによる列幅変更されていない場合
                If mtypChgSort.blnChgWidth = False Then
                    '@ｵｰﾄ幅設定
                    '.AutoSizeMode = flexAutoSizeColWidth
                    .AutoSizeCols(CMlngvsfNo, .Cols.Count - 1, 6)
                End If
                
                '@ﾕｰｻﾞによりｿｰﾄされている場合
                If mtypChgSort.lngCnt > 0 Then
                    '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                    For llngCnt = 0 To mtypChgSort.lngCnt -1
                        '@該当行をｿｰﾄ
                        .Cols(mtypChgSort.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort.typChgSortList(llngCnt).lngOrder
                        .Sort(SortFlags.UseColSort,mtypChgSort.typChgSortList(llngCnt).lngCol)
                    Next llngCnt
                End If
                
                AddHandler vsfLotListCp.BeforeRowColChange,AddressOf vsfLotListCp_BeforeRowColChange

                '@ｿｰﾄ検索用ｷｰ(ﾛｯﾄID)がある場合
                If mtypChgSort.strKey <> vbNullString Then
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        '@ﾛｯﾄIDが同じ場合
                        If .GetData(llngCnt, CMlngvsfLotID) = mtypChgSort.strKey Then
                            .Row = llngCnt
                            '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                            Call pubVsfBeforeSort(vsfLotListCp, CMlngvsfLotID)
                            
                            '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
                            Call pubVsfAfterSort(vsfLotListCp, CMlngvsfLotID)
                            
                            Exit For
                        End If
                    Next llngCnt
                Else
                    .Row = 0           'ｶﾚﾝﾄ行の移動
                    .TopRow = 0        '行
                End If

                '@ｸﾞﾘｯﾄﾞを初期値へ移動
                .LeftCol = CMlngvsfTitle           '列

                '@描画ﾛｯｸ解除
                .Redraw = True

                '@ﾛｯｸ解除
                .Enabled = True
            End With

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvvsfLotListCp_Disp"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvcmbPd_Disp
    '機　能：機種Combo設定
    '引　数：なし
    '戻り値：なし
    '作成日：2006/05/09 (Tue) 11:39:23 N.Kasai
    '更新日：2006/05/09 (Tue) 11:39:23
    '備　考：
    Private Sub prvcmbPd_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbPD
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear
                .DirectInput = False                                        '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                            '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                     '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols1                               'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = CMlngCmbGroupCols                              '列方向のﾚｺｰﾄﾞ数
                .GroupRows = mlngProductCnt                                 '行方向のﾚｺｰﾄﾞ数
                .AddedComment = CMstrCmbAddedComment                        '"選択"文字列
                 .Font = New Font(.Font.FontFamily, _ 
                       CMlngCmbFontSize, .Font.Style, .Font.Unit)           'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, _
                       CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit)'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                              'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter  '左寄中央揃え
                    
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                For llngCnt = 0 To mlngProductCnt -1
                    .AddItem(mtypProductList(llngCnt).strProductID & vbTab & llngCnt)     'ID/Index
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
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvcmbFlowClass_Disp
    '機　能：種別ｺﾝﾎﾞﾘｽﾄ作成
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/30 (Fri) 14:03:27 N.Kasai
    '更新日：2006/06/30 (Fri) 14:03:27
    '備　考：
    Private Sub prvcmbFlowClass_Disp()
        
        Try

            Dim llngCnt     As Integer      '汎用ｶｳﾝﾀ

            '@ｺﾝﾎﾞ制御(ﾘｽﾄｸﾘｱ&ﾘｽﾄ設定)
            With cmbFlowClass
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear
                .DirectInput = False                                            '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=1)
                .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = CMlngCmbGroupCols                                  '列方向のﾚｺｰﾄﾞ数
                .GroupRows = mlngFlowClassCnt                                   '行方向のﾚｺｰﾄﾞ数
                .AddedComment = CMstrCmbAddedComment                            '"選択"文字列
                .Font = New Font(.Font.FontFamily, _ 
                       CMlngCmbFontSize, .Font.Style, .Font.Unit)               'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, _
                       CMlngCmbGridFontSize, .GridFont.Style, .GridFont.Unit)   'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                For llngCnt = 0 To mlngFlowClassCnt -1
                    .AddItem(mtypFlowClassList(llngCnt).strDivisionID & _
                             vbTab & _
                             llngCnt)                                            'ID/Index
                Next llngCnt
            
            End With
            
            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmbFlowClass_Disp"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvcmdSearch_Set
    '機　能：最新取得ﾎﾞﾀﾝ　使用許可
    '引　数：なし
    '戻り値：なし
    '作成日：2006/06/30 (Fri) 14:15:01 N.Kasai
    '更新日：2006/06/30 (Fri) 14:15:01
    '備　考：
    Private Sub prvcmdSearch_Set()
        
        Try       
            
            Select Case True
                '@機種・種別
                Case optSearch0.Checked
                    
                    '@機種
                    If cmbPD.Text = CMstrCmbAddedCommentNone _
                        Or cmbPD.Text = vbNullString Then
                        '@初期化
                        cmdNowList.Enabled = False
                        Exit Sub
                    End If
                    
                    '@種別
                    If cmbFlowClass.Text = CMstrCmbAddedCommentNone _
                        Or cmbFlowClass.Text = vbNullString Then
                        '@初期化
                        cmdNowList.Enabled = False
                        Exit Sub
                    End If
                
                '@ﾛｯﾄID
                Case optSearch1.Checked
                    '@ﾛｯﾄID2桁以上
                    If Len(txtLotID.Text) < 2 Then
                        '@初期化
                        cmdNowList.Enabled = False
                        Exit Sub
                    End If
                    
                    '@「_」でないこと
                    '@ﾛｯﾄID1桁目
                    If Strings.Left(txtLotID.Text, 1) = CMstrUnderBar Then
                        '@初期化
                        cmdNowList.Enabled = False
                        Exit Sub
                    End If
                    
                    '@ﾛｯﾄID2桁目
                    If Mid(txtLotID.Text, 2, 1) = CMstrUnderBar Then
                        '@初期化
                        cmdNowList.Enabled = False
                        Exit Sub
                    End If
            End Select
               
            '@最新取得ﾎﾞﾀﾝ使用可
            cmdNowList.Enabled = True

            Exit Sub

        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmdSearch_Set"           '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With
            
            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvblnSearchClick_Chk
    '機　能：最新取得ﾁｪｯｸ
    '引　数：なし
    '戻り値：True：成功　False：失敗
    '作成日：2006/05/15 (Mon) 16:14:13 N.Kasai
    '更新日：2006/05/15 (Mon) 16:14:13
    '備　考：
    Private Function prvblnSearchClick_Chk() As Boolean
        
        Try

            '@初期化
            prvblnSearchClick_Chk = False
            
            Select Case True
                '@機種・種別の場合
                Case optSearch0.Checked
                
                    '@機種ﾁｪｯｸ
                    cmbPD.ValueCol = CMlngCmbValueCol0
                    
                    If cmbPD.Value = vbNullString Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0013)
                        '@"機種が指定されていません。機種を指定してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        Call pubSetFocus(cmbPD)
                        
                        Exit Function
                    End If
                    
                    '@種別ﾁｪｯｸ
                    cmbFlowClass.ValueCol = CMlngCmbValueCol0
                    If cmbFlowClass.Value = vbNullString Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0014)
                        '@"種別が指定されていません。種別を指定してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        Call pubSetFocus(cmbFlowClass)
                        
                        Exit Function
                    End If
                    
                '@ﾛｯﾄIDの場合
                Case optSearch1.Checked
                    If Len(txtLotID.Text) < 2 Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar001H)
                        '@「ロットIDは2桁以上入力してください。」
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        Call pubSetFocus(txtLotID)
                        
                        Exit Function
                    End If
               
            End Select
            
            '@成功
            prvblnSearchClick_Chk = True
            
            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnSearchClick_Chk"
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

    '関数名 list_BeforeDoubleClick
    '機　能：グリッドダブルクリック前処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/01/14 (Mon) 17:00:00 NSYS
    '備　考：
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfLotListCp.BeforeDoubleClick

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

    '関数名：cursor_Enter
    '機　能：項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考：Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles cmdClose.Enter,
                                                                       cmdNowList.Enter,
                                                                       optSearch1.Enter,
                                                                       optSearch0.Enter,
                                                                       optFlowClass2.Enter,
                                                                       optFlowClass0.Enter,
                                                                       optFlowClass1.Enter,
                                                                       cmbFlowClass.Enter,
                                                                       txtLotID.Enter,
                                                                       cmbPD.Enter,
                                                                       cmdRegist.Enter,
                                                                       vsfLotListCp.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            'バッチ作業終了ボタン、ロット情報詳細表示ボタン、ロット流動票表示ボタン、閉じるボタン、頁切替ボタンの場合は自動Validate = OFF
            Case cmdClose.Name
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
            '上記以外は自動Validate = ON
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

End Class
