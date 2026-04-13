'ﾌｧｲﾙ名：xxEN00X0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：投入予定工順登録(組立)　メインフォーム
'作成日：2004/08/17 (Tue) 17:02:24 N.Kasai
'更新日：2014/11/21 (Fri) 19:32:30 T.Oide
'備　考：2005/06/28 (Tue) 08:35:52 S.Deguchi    処理全面見直し
'　　　：2006/08/07 (Mon) 12:00:31 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(案件№01362)
'　　　：2008/09/05 (Fri) 10:29:24 T.Sawaguchi  異機種間ｺﾋﾟｰをﾕｰｻﾞｰﾌﾟﾛｾｽ設定時を除き禁止,　(案件03141)
'　　　：2008/09/24 (Wed) 17:34:01 T.Sawaguchi 　新規登録の場合は工順無しは設定不可とする(案件03133)
'　　　：2011/04/26 (Tue) 11:12:37 T.Oide       CHR0001319 QUを組立に送品可能にする
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN00X0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00X0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00X0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00X0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00X0)
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
    '======================================Private===========================================
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2020/03/06 (Fri) 11:17:57 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrLocalVersion             As String = "08.00"             '機能ﾊﾞｰｼﾞｮﾝ
    Private Const CMstrLocalVersion             As String = "08.01"             '機能ﾊﾞｰｼﾞｮﾝ
    '@↑2020/03/06 (Fri) 11:17:57 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey             As String = CPstrKeyEN00X0      'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_emplist_Ver          As String = "02.00"             '作業者ﾘｽﾄ取得
    '@↓2011/05/09 (Mon) 10:14:02 T.Oide **************************************************
    'Private Const CMstrmas_pdlist__Ver          As String = "02.02"             '機種区分一覧取得
    Private Const CMstrmas_pdlist__Ver          As String = "03.00"             '機種区分一覧取得
    '@↑2011/05/09 (Mon) 10:14:02 T.Oide **************************************************
    Private Const CMstrmas_pdentrylistVer       As String = "03.00"             'ﾏｽﾀ工順一覧
    Private Const CMstrlot_throwrsvVer          As String = "03.00"             '投入予約登録
    Private Const CMstrlot_assythrowrsvVer      As String = "01.00"             '投入予定工順組立登録
    Private Const CMstrlot_approveVer           As String = "01.04"             'ﾛｯﾄ予約承認
    Private Const CMstrpr__orderlistVer         As String = "01.00"             'P/Rｵｰﾀﾞｰﾘｽﾄ取得
    '@↓2020/01/15 (Wed) 14:05:47 Y.Yoneyama 「.Netへ反映未」 **************************************************
    'Private Const CMstrlot_curstateVer          As String = "03.04"             'ﾛｯﾄ現在状態取得
    Private Const CMstrlot_curstateVer          As String = "04.00"             'ﾛｯﾄ現在状態取得
    '@↑2020/01/15 (Wed) 14:05:47 Y.Yoneyama 「.Netへ反映未」 **************************************************

    '@ｺﾝﾎﾞﾎﾞｯｸｽ定数宣言
    Private Const CMlngComboDispCols1           As Integer = 1                     '表示列数
    Private Const CMlngComboDispCols2           As Integer = 2                     '表示列数
    Private Const CMlngComboGetCol              As Integer = 0                     '値取得列
    Private Const CMlngComboFontSize            As Integer = 16                    'ﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngComboGridFontSize        As Integer = 16                    'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngComboRowHeight           As Integer = 42                    '行高さ
    Private Const CMlngComboAlignLeftCenter     As Integer = 1                     '左中央
    Private Const CMlngCmbEntryDispCols         As Integer = 2                     '表示列数
    Private Const CMlngCmbGetCol5               As Integer = 5                     'ﾊﾞｯｸｶﾗｰ格納Col


    '@処理ﾌﾗｸﾞ
    Private Const CMlngCreateInfo               As Integer = 1                     '入力ﾁｪｯｸﾌﾗｸﾞ(1:工順作成基礎情報)
    Private Const CMlngOrderInfo                As Integer = 2                     '入力ﾁｪｯｸﾌﾗｸﾞ(2:ﾛｯﾄ詳細情報)
    Private Const CMstrWFDefault                As String = "0"                    'WF枚数ｾﾞﾛ入力時比較用定数

    '@起動区分の定数宣言
    Private Const CMlngPDEntry                  As Integer = 1                     '機種ｴﾝﾄﾘ表示用(全件取得)

    '@P/R区分の定数宣言
    Private Const CMlngOptPrClassP              As Integer = 0                     'P/R区分(Pｵｰﾀﾞｰ)
    Private Const CMlngOptPrClassR              As Integer = 1                     'P/R区分(Rｵｰﾀﾞｰ)

    '@その他
    Private Const CMlngLotIDByte                As Integer = 10                    'ﾛｯﾄIDﾊﾞｲﾄ数
    Private Const CMlngMaxWfCount               As Integer = 25                    'MAXWF枚数

    '@ﾕｰｻﾞｰﾌﾟﾛｾｽ定数宣言
    Private Const CMstrUserProcess              As String = "@"                    'ﾕｰｻﾞｰﾌﾟﾛｾｽ("@" & 任意9桁)
    Private Const CMstrUserProcessFlagON        As String = "ON"                   'ﾕｰｻﾞｰﾌﾟﾛｾｽ("@" & 任意9桁)

    '@ﾃｷｽﾄ
    Private Const CMlngMaxDispMemoRow           As Integer = 3                     'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(作業ﾒﾓ)
    Private Const CMlngMaxDispPrOrderRow        As Integer = 3                     'ﾃｷｽﾄ1ﾍﾟｰｼﾞ最大表示数(P/Rｵｰﾀﾞｰｺﾒﾝﾄ)

    '***************************************************************************************
    '                                    *変数の記述*
    '***************************************************************************************
    '======================================Private===========================================
    Private mtypProductList                     As List(Of ProductList)         '機種一覧格納用
    Private mlngProductCnt                      As Integer                      '機種一覧ｶｳﾝﾄ
    Private mtypLotManagerList                  As List(Of TechManList)         'ﾛｯﾄ担当者ﾘｽﾄ格納用
    Private mlngLotManagerListCnt               As Integer                      'ﾛｯﾄ担当者ﾘｽﾄｶｳﾝﾄ
    Private mstrProductID                       As String                       '退避用機種ID
    Private mlngPdEntryMaxWFCount               As Integer                      '現在選択されている機種ｴﾝﾄﾘの最大WF枚数
    Private mtypLotReserve                      As LotReserve                   '投入予約応答格納
    Private mtypAssythrowrsv                    As Assythrowrsv                 '投入予定工順登録応答格納
    Private mtypPrOrderListAns                  As PrOrderListAns               'P/Rｵｰﾀﾞｰ一覧格納用
    Private mblnFormLoadFlag                    As Boolean                      'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ
    '@↓2008/09/05 (Fri) 10:15:02 T.Sawaguchi 案件03141 **************************
    Private mtypLotCurState                     As Lotprestate                  'ﾛｯﾄ情報格納構造体
    '@↑2008/09/05 (Fri) 10:15:02 T.Sawaguchi 案件03141 **************************
    Private buttonProcessing                    As Boolean                      'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu            As Boolean                      'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                     As Boolean                      'NSYS WindowCloseフラグ
    Private mblnOptNewStat                      As Boolean                      'NSYS optNewクリック前チェック状態
    Private mblnOptProcessStat                  As Boolean                      'NSYS optProcessクリック前チェック状態
    Private mlngOptPrClassStat                  As Integer = 2                  'NSYS 前回押下optPrClass種別(0:P 1:R 2:画面初回表示時の初期値）


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
    '                            *イベントハンドラの記述*
    '***************************************************************************************
    '====================================Private============================================
    '関数名：Form_Load
    '機　能：初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/17 (Tue) 17:16:41 N.Kasai
    '更新日：2006/11/01 (Wed) 13:07:24 N.Kasai
    '備　考：2004/08/26 (Thu) 17:12:11 N.Kasai WF枚数判定修正
    '　　　：2006/08/07 (Mon) 12:04:31 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(案件№01362)
    '　　　：2006/11/01 (Wed) 13:07:24 N.Kasai      送品ｺﾝﾎﾞ追加(№01500)
    Private Sub Form_Load()

        Dim lblnAns             As Boolean      '戻り値
        Dim lstrFormName        As String       'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String       'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrClassDivision   As String       '作成処理区分
    '@↓2006/08/07 (Mon) 12:06:22 T.Kitagawa **************************************************
        Dim lblnAnsPrOrder      As Boolean      'P/Rｵｰﾀﾞｰ一覧取得戻り値(True/False)
    '@↑2006/08/07 (Mon) 12:06:22 T.Kitagawa **************************************************
        
        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN00X0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = Me.cmdClose
                
                Exit Sub
            End If

            '@ﾌｫｰﾑ,ｲﾍﾞﾝﾄ名称の取得
            lstrFormName = Me.Name
            lstrEventName = "Form_Load"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@画面初期化
            Call prvfrmxxEN00X0_Init()
            
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化
            mblnFormLoadFlag = False
            
            '@機種区分一覧取得
            lstrClassDivision = CPstrCD2A & CPstrCD30                   'ClassDivison設定：2A30
            lblnAns = pubblnMasPdlist_Sel(CMstrmas_pdlist__Ver, _
                                          lstrClassDivision, _
                                          mtypProductList, _
                                          mlngProductCnt, _
                                          pstrSBID)
            '@結果判定
            If lblnAns = False Then
            '@失敗の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = Me.cmdClose
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@異常の場合終了
                Exit Sub
            End If
                
            '@【作業者ﾘｽﾄ(ﾛｯﾄ担当者ﾘｽﾄ)取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnMasEmplist_Sel(CMstrmas_emplist_Ver, _
                                           mtypLotManagerList, _
                                           mlngLotManagerListCnt)
            '@結果判定
            If lblnAns = False Then
            '@失敗の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = Me.cmdClose
                
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@異常の場合終了
                Exit Sub
            End If

        '@↓2006/08/07 (Mon) 12:07:52 T.Kitagawa **************************************************
            '@P/Rｵｰﾀﾞｰ一覧取得結果
            lblnAnsPrOrder = pubblnPrOrderList_Sel(CMstrpr__orderlistVer, mtypPrOrderListAns)
            '@結果判定
            If lblnAnsPrOrder = False Then
            '@失敗の場合
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                '@異常の場合終了
                Exit Sub
            End If
        '@↑2006/08/07 (Mon) 12:07:52 T.Kitagawa **************************************************
            
        '@↓2006/11/01 (Wed) 13:07:18 N.Kasai **************************************************
            '@送品設定
            Call prvCmbLotSend_Set()
        '@↑2006/11/01 (Wed) 13:07:18 N.Kasai **************************************************
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            '@Form_Loadﾌﾗｸﾞ(正常)
            pblnFormLoad = True
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Load"                  '処理名
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
    '作成日：2005/06/20 (Mon) 14:01:28 S.Deguchi
    '更新日：2008/06/11 (Wed) 13:30:24 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 13:30:24 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理判別
            If mblnFormLoadFlag = False Then
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = Me.cmdClose
                
                '@ﾌﾗｸﾞを戻す
                mblnFormLoadFlag = True
                
                '@各Combo表示処理
                Call prvcmbProductList_Disp()           '機種
                Call prvCmbLotManagerList_Disp()        'ﾛｯﾄ担当
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "Form_Activate"              '処理名
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
    '作成日：2004/08/19 (Thu) 18:54:43 N.Kasai
    '更新日：2008/06/11 (Wed) 13:31:08 N.Kojima
    '備　考：
    '　　　：2006/08/07 (Mon) 12:13:56 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(案件№01362)
    '　　　：2008/06/11 (Wed) 13:31:08 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
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
                Case cmbProduct.Name
                    '@機種
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            RemoveHandler cmbProduct.Validating,AddressOf cmbProduct_Validate
                            Call cmbProduct_Validate(cmbProduct,new CancelEventArgs(True))
                            AddHandler cmbProduct.Validating,AddressOf cmbProduct_Validate
                            e.Handled = True
                    End Select
                
                Case cmbDivision.Name
                    '@種別
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            RemoveHandler cmbDivision.Validating,AddressOf cmbDivision_Validate
                            Call cmbDivision_Validate(cmbDivision,new CancelEventArgs(True))
                            AddHandler cmbDivision.Validating,AddressOf cmbDivision_Validate
                            e.Handled = True
                    End Select
                
                Case cmbLotManager.Name
                    '@ﾛｯﾄ担当
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            RemoveHandler cmbLotManager.Validating,AddressOf cmbLotManager_Validate
                            Call cmbLotManager_Validate(cmbLotManager,new CancelEventArgs(True))
                            AddHandler cmbLotManager.Validating,AddressOf cmbLotManager_Validate
                            e.Handled = True
                    End Select
                
                Case cmbPrOrder.Name
                '@P/Rｵｰﾀﾞｰ
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            RemoveHandler cmbPrOrder.Validating,AddressOf cmbPrOrder_Validate
                            Call cmbPrOrder_Validate(cmbPrOrder,new CancelEventArgs(True))
                            AddHandler cmbPrOrder.Validating,AddressOf cmbPrOrder_Validate
                            e.Handled = True
                    End Select
                
                Case cmbUserProduct.Name
                    '@機種(user)
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            RemoveHandler cmbUserProduct.Validating,AddressOf cmbUserProduct_Validate
                            Call cmbUserProduct_Validate(cmbUserProduct,new CancelEventArgs(True))
                            AddHandler cmbUserProduct.Validating,AddressOf cmbUserProduct_Validate
                            e.Handled = True
                    End Select
                
                Case cmbUserLotManager.Name
                    '@ﾛｯﾄ担当(ﾕｰｻﾞｰﾌﾟﾛｾｽ)
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            RemoveHandler cmbUserLotManager.Validating,AddressOf cmbUserLotManager_Validate
                            Call cmbUserLotManager_Validate(cmbUserLotManager,new CancelEventArgs(True))
                            AddHandler cmbUserLotManager.Validating,AddressOf cmbUserLotManager_Validate
                            e.Handled = True
                    End Select
                
                Case txtWorkMemo.Name
                    '@作業ﾒﾓ
                    '@ｺﾒﾝﾄは改行できるようにEnterｷｰでﾌｫｰｶｽ移動しない
                    Exit Sub
                
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
            
            '@ｴﾗｰ情報設定
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
    '引　数：Cancel：ｷｬﾝｾﾙ
    '　　　：UnloadMode：ｱﾝﾛｰﾄﾞﾓｰﾄﾞ
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:01:42 N.Kasai
    '更新日：2006/08/07 (Mon) 13:06:01 T.Kitagawa
    '備　考：2004/11/01 (Mon) 16:34:44 M.Miura 閉じるﾎﾞﾀﾝ統合
    '　　　：2006/08/07 (Mon) 13:06:01 T.Kitagawa   Rｵｰﾀﾞｰ一覧格納構造体ｸﾘｱ追加
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        
        Dim lblnAnsTerm     As Boolean      '開放結果格納
        
        Try
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(sender,e)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@構造体のｸﾘｱ
            mtypProductList = New List(Of ProductList)
            mtypLotManagerList = New List(Of TechManList)
            mtypPrOrderListAns.typPrOrderList = New List(Of PrOrderList)

            '@ActInitﾌﾗｸﾞの判定
            If pblnActInitFlg = True Then
                '@Actを自前で初期化した場合
                
                '@ACTｵﾌﾞｼﾞｪｸﾄの開放
                lblnAnsTerm = pubblnAct_Term
                If lblnAnsTerm = True Then
                    '@ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了
                End If
            Else
                '@ﾒｲﾝﾒﾆｭｰ画面を広げる
                Call pubMenuExpand_Disp()
            End If

            '@ﾌｫｰﾑｵﾌﾞｼﾞｪｸﾄとの関連付けを解除
            'NSYS 静的イベントハンドラ解除
            RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
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
    '作成日：2004/08/19 (Thu) 19:02:11 N.Kasai
    '更新日：2004/08/19 (Thu) 19:02:11 N.Kasai
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click

        Dim ltypcomoninfo   As CommonInfo
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@終了関数を実行する
            Call publngEnd_Proc(CPstrKeyEN00X0, ltypcomoninfo)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdClose_Click"             '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdRegist_Click
    '機　能：確定処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/18 (Wed) 21:12:39 N.Kasai
    '更新日：2008/06/11 (Wed) 13:31:45 N.Kojima
    '備　考：
    '　　　：2005/06/27 (Mon) 13:19:54 S.Deguchi    ﾕｰｻﾞｰﾌﾟﾛｾｽID設定方法変更による修正を追加
    '　　　：2006/08/07 (Mon) 14:10:02 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(案件№01362)
    '　　　：2008/06/11 (Wed) 13:31:45 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click
        
        Dim lblnAns                 As Boolean      '汎用戻り値(True/False)
        Dim lblnAnsLotThrowrsv      As Boolean      '投入予約登録戻り値(True/False)
        Dim lblnLotApprove          As Boolean      '投入承認戻り値(True/False)
        Dim lstrFormName            As String       'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String       'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        
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
            
            '@画面項目ﾁｪｯｸ
            lblnAns = prvblnLotReserve_Chk
            If lblnAns = False Then
                '@不正項目あり
                Exit Sub
            End If
            
            '@作業者ID入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "cmdRegist_Click"
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ﾌｫｰﾑﾛｯｸ
            
            Select Case True
                '@基礎情報選択し確定する場合
                Case optNew.Checked
                    '@構造体に登録内容格納
                    With mtypLotReserve
                        .strPdId = cmbProduct.Text                              '機種ID
                        .strFlowClass = cmbDivision.Text                        '流動区分
                        .strEngEmpId = cmbLotManager.Value                      'ﾛｯﾄ担当者ID
                        .strWfNum = txtWFNum.Text                               'WF枚数
                        .strPlanThrowinDate = dtpStartDate.Value                '投入予定日
                        .strDivideLotID = vbNullString                          '分割元LotID
                        .strComment = txtWorkMemo.Text                          'ｺﾒﾝﾄ
                        .strSbID = pstrSBID                                     'SB
                        .strClassDivision = prvstrClassDivision_Cal             '処理区分計算
                        .strEmpID = pstrUserID                                  '作業者ID
                        .strPROrderID = cmbPrOrder.Text                         'P/Rｵｰﾀﾞｰ
                        
                        '@ﾛｯﾄ詳細情報選択を判定
                        Select Case True
                            '@ﾏｽﾀ工順が選択された場合
                            Case optMster.Checked
                                .strMasVer = lblEntryID.Text                 '工順Version
                                .strCopySeqLotID = vbNullString                 'ｺﾋﾟｰ元LotID
                            '@工順ｺﾋﾟｰが選択された場合
                            Case optCopy.Checked
                                .strCopySeqLotID = txtCopyLotID.Text            'ｺﾋﾟｰ元LotID
                                .strMasVer = vbNullString                       '工順Version
                            '@工順なしが選択された場合
                            Case optNon.Checked
                                .strMasVer = vbNullString                       '工順Version
                                .strCopySeqLotID = vbNullString                 'ｺﾋﾟｰ元LotID
                        End Select
                        
                        If cmbLotSend.Value = -1 Then
                            '@ﾕｰｻﾞｰﾌﾟﾛｾｽの場合
                            .strLotSendFlag = vbNullString
                        Else
                            .strLotSendFlag = cmbLotSend.Value                  '送品
                        End If
                    End With
                
                    '@生成ﾛｯﾄIDｸﾘｱ
                    lblLotID.Text = vbNullString
                    
                    '@投入予約登録
                    lblnAnsLotThrowrsv = pubblnLotThrowrsv_Ins(CMstrlot_throwrsvVer, mtypLotReserve)
                    '@結果判定
                    If lblnAnsLotThrowrsv = True Then
                        '@生成ﾛｯﾄIDｾｯﾄ
                        lblLotID.Text = mtypLotReserve.strLotID
                                
                        '@承認ﾒｯｾｰｼﾞ送信
        '@↓2006/11/09 (Thu) 15:34:20 T.Kitagawa **************************************************
        '                lblnLotApprove = pubblnLotApprove_Ins(CMstrlot_approve_Ver, mtypLotReserve)
                        lblnLotApprove = pubblnLotApprove_Ins(CMstrlot_approveVer, mtypLotReserve)
        '@↑2006/11/09 (Thu) 15:34:20 T.Kitagawa **************************************************
                        '@結果判定
                        If lblnAnsLotThrowrsv = True Then
                            '@ﾌｫｰﾑﾛｯｸ解除
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0003, lblLotID.Text)
                            
                            '@成功ﾒｯｾｰｼﾞ表示
                            '@pubVsfInfo_Disp("メッセージコード：C_I03%0$$投入予定ロット[ %1 ]を登録しました。")
                            Call pubVsfInfo_Disp(pstrDMsg)
                            
                            '@ﾚｽﾎﾟﾝｽ取得終了
                            Call publngResponseEnd(lstrFormName, lstrEventName)
                            
                            '@作業ﾒﾓｸﾘｱ
                            txtWorkMemo.Text = vbNullString
                            
                            Exit Sub
                        Else
                            '@ﾌｫｰﾑﾛｯｸ解除
                        
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(lstrFormName, lstrEventName)
                            
                            Exit Sub
                        End If
                    Else
                        '@ﾌｫｰﾑﾛｯｸ解除
                    
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        
                        Exit Sub
                    End If
                
                '@工順作成ID採番を選択して確定する場合
                Case optProcess.Checked
                    '@構造体に登録内容格納
                    With mtypAssythrowrsv
                        .strSbID = pstrSBID                                     'SBID
                        .strMsgVer = CMstrlot_assythrowrsvVer                   'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                        .strClassDivision = prvstrClassDivision_Cal             '処理区分
                        .strPdId = cmbUserProduct.Text                          '機種ID
                        '@新規作成ｴﾝﾄﾘID
                        .strEntryID = CMstrUserProcess & txtUserEntry.Text
                        .strEntryName = txtUserEntryName.Text                   '新規作成ｴﾝﾄﾘ名
                        .strEngEmpId = cmbUserLotManager.Value                  'ﾛｯﾄ担当(ﾕｰｻﾞｰﾌﾟﾛｾｽ)
                        .strComment = txtWorkMemo.Text                          '作業ﾒﾓ
                        .strEmpID = pstrUserID                                  '作業者ID
                       
                       '@ﾛｯﾄ詳細情報選択を判定
                        Select Case True
                            '@ﾏｽﾀ工順が選択された場合
                            Case optMster.Checked
                                .strCopySeqLotID = vbNullString                 'ｺﾋﾟｰ元LotID
                                .strCopySeqEntryID = lblEntryID.Text         'ｺﾋﾟｰ元ｴﾝﾄﾘID
                            
                            '@工順ｺﾋﾟｰが選択された場合
                            Case optCopy.Checked
                                .strCopySeqLotID = txtCopyLotID.Text            'ｺﾋﾟｰ元LotID
                                .strCopySeqEntryID = vbNullString               'ｺﾋﾟｰ元ｴﾝﾄﾘID
                            
                            '@工順なしが選択された場合
                            Case optNon.Checked
                                .strCopySeqLotID = vbNullString                 'ｺﾋﾟｰ元LotID
                                .strCopySeqEntryID = vbNullString               'ｺﾋﾟｰ元ｴﾝﾄﾘID
                        End Select
                    End With
                    
                     '@生成ﾛｯﾄIDｸﾘｱ
                    lblLotID.Text = vbNullString
                    
                    '@投入予約登録
                    lblnAns = pubblnLotAssythrowrsv_Ins(mtypAssythrowrsv)
                    '@結果判定
                    If lblnAns = True Then
                    '@生成ﾛｯﾄIDは非表示
                        '@ﾌｫｰﾑﾛｯｸ解除
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf001C, mtypAssythrowrsv.strLotID)
                        
                        '@成功ﾒｯｾｰｼﾞ表示
                        '@"<TRM1CI>$$工順を登録しました。ユーザプロセスID[ %1 ]"
                        Call pubVsfInfo_Disp(pstrDMsg)
                        
                        '@ﾚｽﾎﾟﾝｽ取得終了
                        Call publngResponseEnd(lstrFormName, lstrEventName)
                        
                        '@作業ﾒﾓｸﾘｱ
                        txtWorkMemo.Text = vbNullString
                        
                        Exit Sub
                    Else
                        '@ﾌｫｰﾑﾛｯｸ解除
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        
                        Exit Sub
                    End If

                '@不正項目あり
                Case Else
                    '@ﾌｫｰﾑﾛｯｸ解除
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    Exit Sub
                End Select
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdRegist_Click"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdPlanList_Click
    '機　能：投入予定一覧表示
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:41:46 N.Kasai
    '更新日：2004/08/19 (Thu) 19:41:46
    '備　考：
    Private Sub cmdPlanList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdPlanList.Click

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

            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@取得区分に値ｾｯﾄ(0M:新規)
            pstrfrmxxCM0090Kbn = CPstrCD0M
            
            '@投入予定ﾛｯﾄ一覧画面をﾛｰﾄﾞ
            frmxxCM0090.Instance = New frmxxCM0090()
            
            '@ｻﾌﾞﾌｫｰﾑの名称設定
            frmxxCM0090.Instance.Text = CPstrSubDispTitleLotThrwList
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM0090.Instance = Nothing
                Exit Sub
            End If
            
            With frmxxCM0090.Instance
                '@投入予定一覧の確定ﾎﾞﾀﾝ非表示
                .cmdChoice.Visible = False
                '@投入予定一覧表示
                Call .ShowDialog(Me)
            End With
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdPlanList_Click"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：optNew_Click
    '機　能：基礎情報選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:23:29 N.Kasai
    '更新日：2008/06/11 (Wed) 13:32:14 N.Kojima
    '備　考：
    '　　　：2006/08/07 (Mon) 13:46:32 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(案件№01362)
    '　　　：2006/11/01 (Wed) 13:49:10 N.Kasai      送品ｺﾝﾎﾞ追加(№01500)
    '　　　：2008/06/11 (Wed) 13:32:14 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub optNew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optNew.Click

        Dim lblnAns             As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try
            'NSYS チェック状態が変わらない場合は処理を抜ける
            If mblnOptNewStat = optNew.Checked Then
                Exit Sub
            Else
                mblnOptNewStat = optNew.Checked
                mblnOptProcessStat = optProcess.Checked
            End If

            '@新規ﾛｯﾄID採番(有効)
            '@機種
            With cmbProduct
                .Enabled = True
                .BackColor = SystemColors.Window
            End With
            '@種別
            With cmbDivision
                .Enabled = False
                .BackColor = SystemColors.Window
            End With
            '@WF枚数
            With txtWFNum
                .Enabled = False
                .BackColor = SystemColors.Window
            End With
            '@投入予定日
            With dtpStartDate
                .Enabled = False
                .BackColor = SystemColors.Window
            End With
            '@ﾛｯﾄ担当
            With cmbLotManager
                .Enabled = False
                .BackColor = SystemColors.Window
            End With
            
            '@P/R区分
            With fraPrClass
                .Enabled = False
            End With
            optPrClass0.Enabled = False
            optPrClass1.Enabled = False
            optPrClass0.Checked = False
            optPrClass1.Checked = False
            '@P/Rｵｰﾀﾞｰ
            With cmbPrOrder
                .Enabled = False
                .BackColor = SystemColors.Window
            End With
            '@P/Rｵｰﾀﾞｰｺﾒﾝﾄ欄の制御
            txtOrderComment.Text = vbNullString
            txtOrderComment.Enabled = False
            txtOrderComment.Locked = True
            
            '@送品ｺﾝﾎﾞ(初期値：あり)
            cmbLotSend.ListIndex = 1
            cmbLotSend.Enabled = False
            
            '@工順作成ID採番(無効)
            '@機種(user)
            With cmbUserProduct
                .Enabled = False
                .BackColor = SystemColors.ControlLight
            End With
            '@ﾛｯﾄ担当(ﾕｰｻﾞｰﾌﾟﾛｾｽ)
            With cmbUserLotManager
                .Enabled = False
                .BackColor = SystemColors.ControlLight
            End With
            '@ﾕｰｻﾞﾌﾟﾛｾｽID
            With txtUserEntry
                .Enabled = False
                .BackColor = SystemColors.ControlLight
            End With
            '@ﾕｰｻﾞﾌﾟﾛｾｽ名
            With txtUserEntryName
                .Enabled = False
                .BackColor = SystemColors.ControlLight
            End With
               
            '@機種(user)ｸﾘｱ
            RemoveHandler cmbUserProduct.Change,AddressOf cmbUserProduct_Change
            cmbUserProduct.ListIndex = -1
            AddHandler cmbUserProduct.Change,AddressOf cmbUserProduct_Change
            
            '@ﾛｯﾄ担当(ﾕｰｻﾞｰﾌﾟﾛｾｽ)ｸﾘｱ
            cmbUserLotManager.ListIndex = -1
            
            '@ﾕｰｻﾞｴﾝﾄﾘｰID
            txtUserEntry.Text = vbNullString
            
            '@ﾕｰｻﾞｴﾝﾄﾘｰ名
            txtUserEntryName.Text = vbNullString
            
            '@ｴﾝﾄﾘIDｸﾘｱ
            lblEntryID.Text = vbNullString
            
            '@ｴﾝﾄﾘ名ｸﾘｱ
            lblEntryName.Text = vbNullString
            
            '@投入予定日ｾｯﾄ
            dtpStartDate.Value = Format$(Now(), CPstrDateTimeYMD)
            
            '@WF枚数ｸﾘｱ
            txtWFNum.Text = vbNullString
            
            '@機種退避領域をｸﾘｱ
            mstrProductID = vbNullString
            
            '@入力ﾁｪｯｸ
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            '@結果判定
            If lblnAns = True Then
                '@ﾏｽﾀ工順選択時
                If optMster.Checked = True Then
                    '@ｴﾝﾄﾘID空白の場合確定ﾎﾞﾀﾝ押下不可
                    If lblEntryID.Text = vbNullString Then
                        '@確定ﾎﾞﾀﾝ押下不可
                        cmdRegist.Enabled = False
                        Exit Sub
                    End If
                End If
                '@投入予約ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
            Else
                '@投入予約ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "optNew_Click"               '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：optProcess_Click
    '機　能：工順作成ID採番選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:27:29 N.Kasai
    '更新日：2008/06/11 (Wed) 13:33:02 N.Kojima
    '備　考：
    '　　　：2006/08/07 (Mon) 13:49:02 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(案件№01362)
    '　　　：2008/06/11 (Wed) 13:33:02 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub optProcess_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optProcess.Click

        Dim lblnAns             As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try
            'NSYS チェック状態が変わらない場合は処理を抜ける
            If mblnOptProcessStat = optProcess.Checked Then
                Exit Sub
            Else
                mblnOptNewStat = optNew.Checked
                mblnOptProcessStat = optProcess.Checked
            End If

            '@新規ﾛｯﾄID採番(無効)
            '@機種
            With cmbProduct
                .Enabled = False
                .BackColor = SystemColors.ControlLight
            End With
            '@種別
            With cmbDivision
                .Enabled = False
                .BackColor = SystemColors.ControlLight
            End With
            '@WF枚数
            With txtWFNum
                .Enabled = False
                .BackColor = SystemColors.ControlLight
            End With
            '@投入予定日
            With dtpStartDate
                .Enabled = False
                .BackColor = SystemColors.ControlLight
            End With
            '@ﾛｯﾄ担当
            With cmbLotManager
                .Enabled = False
                .BackColor = SystemColors.ControlLight
            End With
            
            '@P/R区分
            With fraPrClass
                .Enabled = False
            End With
            optPrClass0.Enabled = False
            optPrClass1.Enabled = False
            optPrClass0.Checked = False
            optPrClass1.Checked = False
            '@P/Rｵｰﾀﾞｰ
            With cmbPrOrder
                .Enabled = False
                .BackColor = SystemColors.ControlLight
            End With
            '@P/Rｵｰﾀﾞｰｺﾒﾝﾄ欄,ｽｸﾛｰﾙﾎﾞﾀﾝの制御
            txtOrderComment.Text = vbNullString
            txtOrderComment.Enabled = False
            txtOrderComment.Locked = True
            
            '@工順作成ID採番(有効)
            '@機種(user)
            With cmbUserProduct
                .Enabled = True
                .BackColor = SystemColors.Window
            End With
            '@ﾛｯﾄ担当(ﾕｰｻﾞｰﾌﾟﾛｾｽ)
            With cmbUserLotManager
                .Enabled = True
                .BackColor = SystemColors.Window
            End With
            '@ﾕｰｻﾞﾌﾟﾛｾｽID
            With txtUserEntry
                .Enabled = True
                .BackColor = SystemColors.Window
            End With
            '@ﾕｰｻﾞﾌﾟﾛｾｽ名
            With txtUserEntryName
                .Enabled = True
                .BackColor = SystemColors.Window
            End With
            
            '@ｴﾝﾄﾘIDｸﾘｱ
            lblEntryID.Text = vbNullString
            
            '@ｴﾝﾄﾘ名ｸﾘｱ
            lblEntryName.Text = vbNullString
            
            '@工順ｺﾋﾟｰｸﾘｯｸ
            optCopy.Checked = True
            Call optCopy_Click(optCopy,e) 'NSYS True代入してもClickイベント発生しないため手動実行
            
            '@機種ｸﾘｱ
            RemoveHandler cmbProduct.Change,AddressOf cmbProduct_Change
            cmbProduct.ListIndex = -1
            AddHandler cmbProduct.Change,AddressOf cmbProduct_Change
            
            '@種別ｸﾘｱ
            RemoveHandler cmbDivision.Change,AddressOf cmbDivision_Change
            cmbDivision.ListIndex = -1
            AddHandler cmbDivision.Change,AddressOf cmbDivision_Change
            
            '@WF枚数ｸﾘｱ
            txtWFNum.Text = vbNullString
            
            '@投入予定日ｾｯﾄ
            dtpStartDate.Value = Format$(Now(), CPstrDateTimeYMD)
            
            '@ﾛｯﾄ担当ｸﾘｱ
            cmbLotManager.ListIndex = -1
            
            '@P/Rｵｰﾀﾞｰｸﾘｱ
            RemoveHandler cmbPrOrder.Change,AddressOf cmbPrOrder_Change
            cmbPrOrder.ListIndex = -1
            AddHandler cmbPrOrder.Change,AddressOf cmbPrOrder_Change
            
            '@送品ｺﾝﾎﾞ(初期値：空白)
            cmbLotSend.ListIndex = -1
            cmbLotSend.Enabled = False
            
            
            '@機種退避領域をｸﾘｱ
            mstrProductID = vbNullString
            
            '@入力ﾁｪｯｸ
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            '@結果判定
            If lblnAns = True Then
                '@ﾏｽﾀ工順選択時
                If optMster.Checked = True Then
                    '@ｴﾝﾄﾘID空白の場合確定ﾎﾞﾀﾝ押下不可
                    If lblEntryID.Text = vbNullString Then
                        '@確定ﾎﾞﾀﾝ押下不可
                        cmdRegist.Enabled = False
                        Exit Sub
                    End If
                End If
                
                '@投入予約ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
            Else
                '@投入予約ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "optProcess_Click"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbProduct_Change
    '機　能：機種変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/06/27 (Mon) 16:18:01 S.Deguchi
    '更新日：2008/06/11 (Wed) 13:33:41 N.Kojima
    '備　考：
    '　　　：2006/08/07 (Mon) 13:09:47 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(案件№01362)
    '　　　：2006/11/13 (Mon) 16:19:59 N.Kasai      送品ｺﾝﾎﾞ初期化
    '　　　：2008/06/11 (Wed) 13:33:41 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub cmbProduct_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProduct.Change

        Try
            '@退避領域と異なる場合は初期化する
            If mstrProductID <> cmbProduct.Text Then
                
                '@種別ｺﾝﾎﾞ、ﾛｯﾄ担当ｺﾝﾎﾞの初期化
                cmbDivision.Clear
                cmbLotManager.ListIndex = -1
                
                '@投入予定日ｾｯﾄ
                dtpStartDate.Value = Format$(Now(), CPstrDateTimeYMD)
                
                '@WF枚数初期化
                txtWFNum.Text = vbNullString
                
                '@ｴﾝﾄﾘID/名
                lblEntryID.Text = vbNullString
                lblEntryName.Text = vbNullString
                
                '@送品ｺﾝﾎﾞ初期化(あり)
                cmbLotSend.ListIndex = 1
                cmbLotSend.Enabled = False
            End If
            
            '@P/Rｵｰﾀﾞｰを使用不可とする
            fraPrClass.Enabled = False
            optPrClass0.Enabled = False
            optPrClass1.Enabled = False
            optPrClass0.Checked = False
            optPrClass1.Checked = False
            cmbPrOrder.Enabled = False
            RemoveHandler cmbPrOrder.Change,AddressOf cmbPrOrder_Change
            cmbPrOrder.ListIndex = -1
            AddHandler cmbPrOrder.Change,AddressOf cmbPrOrder_Change
            
            '@P/Rｵｰﾀﾞｰｺﾒﾝﾄ欄の制御
            txtOrderComment.Text = vbNullString             'P/Rｵｰﾀﾞｰｺﾒﾝﾄ
            txtOrderComment.Enabled = True                  'P/Rｵｰﾀﾞｰｺﾒﾝﾄ
            txtOrderComment.Locked = True                   'P/Rｵｰﾀﾞｰｺﾒﾝﾄ
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbProduct_Change"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub
    '@↑2005/06/27 (Mon) 16:18:14 S.Deguchi **************************************************

    '関数名：cmbProduct_CloseUp
    '機　能：機種選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:02:53 N.Kasai
    '更新日：2004/09/30 (Thu) 19:49:16 N.Kojima
    '備　考：
    Private Sub cmbProduct_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbProduct.CloseUp
        
        Try
            '@ｺﾝﾎﾞが空でない場合
            If cmbProduct.Text <> vbNullString Then
                '@Validate処理へ
                RemoveHandler cmbProduct.Validating,AddressOf cmbProduct_Validate
                Call cmbProduct_Validate(sender,new CancelEventArgs(True))
                AddHandler cmbProduct.Validating,AddressOf cmbProduct_Validate
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbProduct_CloseUp"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbProduct_Validate
    '機　能：機種選択Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:03:17 N.Kasai
    '更新日：2008/06/11 (Wed) 13:34:42 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 14:54:49 Y.Yamagishi　"ZZ"を固定で表示する(不具合改善№991)
    '　　　：2004/10/06 (Wed) 11:39:22 Y.Yamagishi　"ZZ"を固定で表示する(不具合改善№991)
    '　　　：2005/07/26 (Tue) 10:13:46 N.Kasai      L/R色表示
    '　　　：2006/08/07 (Mon) 13:14:26 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(案件№01362)
    '　　　：2008/06/11 (Wed) 13:34:42 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub cmbProduct_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbProduct.Validating

        Dim lblnAns                 As Boolean              '入力ﾁｪｯｸ結果格納(True:OK,False:NG)
        Dim llngTxtWfNum            As Integer              'WF枚数ﾃｷｽﾄﾎﾞｯｸｽ値
        Dim llngMstWfNum            As Integer              'ﾏｽﾀWF枚数
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        
        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@空欄の場合には,次ﾌｫｰｶｽへ
            If cmbProduct.Text = vbNullString Then
                '@投入予定ﾛｯﾄ一覧活性化時
                If cmdPlanList.Enabled = True Then
                    '@ﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbProduct.Name Then
                        Call pubSetFocus(cmdPlanList)
                    End If
                Else
                    '@閉じるﾎﾞﾀﾝへ
                    If ActiveControl.Name = cmbProduct.Name Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
                
                Exit Sub
            End If
            
            
            '@値取得(ﾊﾞｯｸｶﾗｰ値)
            cmbProduct.ValueCol = CMlngCmbGetCol5
            
            If cmbProduct.Value <> vbNullString Then
                '@ﾊﾞｯｸｶﾗｰ反映
                cmbProduct.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(cmbProduct.Value))
            Else
                cmbProduct.BackColor = SystemColors.Window
            End If
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "cmbProduct_Validate"

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
                
            '@退避領域と同じ場合には,処理を行わない
            If mstrProductID <> cmbProduct.Text Then
                '@機種による工順を取得
                Call prvMasEntryList_Sel()
            
                '@最大WF枚数ﾃﾞｰﾀ番号取得
                cmbProduct.ValueCol = CMlngComboDispCols1
                llngMstWfNum = Val(cmbProduct.Value)
                llngTxtWfNum = Val(txtWFNum.Text)
                
                '@機種名退避
                mstrProductID = Trim(cmbProduct.Text)

                '@種別"ZZ"を固定で表示する
                cmbDivision.AddItem(CPstrFlowClassZZ)
                cmbDivision.ListIndex = 0
                
                '@種別を無効にする
                cmbDivision.Enabled = False
                
                '@送品ｺﾝﾎﾞ(初期値：送品あり)
                cmbLotSend.ListIndex = 1
                cmbLotSend.Enabled = True

                
                If llngMstWfNum = 0 Then
                    
                    '@新規ﾛｯﾄID採番部のｺﾝﾄﾛｰﾙを無効にする
                    cmbDivision.Enabled = False             '種別
                    txtWFNum.Enabled = False                'WF枚数
                    dtpStartDate.Enabled = False            '投入予定日
                    cmbLotManager.Enabled = False           'ﾛｯﾄ担当
                    
                    '@P/Rｵｰﾀﾞｰの制御
                    optPrClass0.Enabled = False
                    optPrClass1.Enabled = False
                    optPrClass0.Checked = False
                    optPrClass1.Checked = False
                    fraPrClass.Enabled = False
                    cmbPrOrder.Enabled = False
                    RemoveHandler cmbPrOrder.Change,AddressOf cmbPrOrder_Change
                    cmbPrOrder.ListIndex = -1
                    AddHandler cmbPrOrder.Change,AddressOf cmbPrOrder_Change
                    
                    '@P/Rｵｰﾀﾞｰｺﾒﾝﾄ欄の制御
                    txtOrderComment.Text = vbNullString
                    txtOrderComment.Enabled = False
                    txtOrderComment.Locked = True
                    
                    '@ｸﾘｱ
                    RemoveHandler cmbDivision.Change,AddressOf cmbDivision_Change
                    cmbDivision.ListIndex = -1              '種別
                    AddHandler cmbDivision.Change,AddressOf cmbDivision_Change
                    cmbLotManager.ListIndex = -1            'ﾛｯﾄ担当

                    '@工順作成ID採番ｵﾌﾟｼｮﾝﾎﾞﾀﾝのCausesValidationをFalse
                    optProcess.CausesValidation = False
                    
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    Exit Sub
                End If
            End If
            
            '@新規ﾛｯﾄID採番部のｺﾝﾄﾛｰﾙを有効にする
            txtWFNum.Enabled = True                 'WF枚数
            dtpStartDate.Enabled = True             '投入予定日
            cmbLotManager.Enabled = True            'ﾛｯﾄ担当
            
            '@入力ﾁｪｯｸ
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            '@結果判定
            If lblnAns = True Then
                '@ﾏｽﾀ工順選択時
                If optMster.Checked = True Then
                    '@ｴﾝﾄﾘID空白の場合確定ﾎﾞﾀﾝ押下不可
                    If lblEntryID.Text = vbNullString Then
                        '@確定ﾎﾞﾀﾝ押下不可
                        cmdRegist.Enabled = False
                        
                        '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                        Call pubResponseCancel(lstrFormName, lstrEventName)
                        
                        Exit Sub
                    End If
                End If
                
                '@投入予約ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
            Else
                '@投入予約ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False
            End If
            
            If txtWFNum.Enabled = True Then
                '@WF枚数へｾｯﾄﾌｫｰｶｽ
                If ActiveControl.Name = cmbProduct.Name Then
                    Call pubSetFocus(txtWFNum)
                End If
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbProduct_Validate"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbDivision_Change
    '機　能：種別変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/07 (Mon) 13:20:11 T.Kitagawa
    '更新日：2006/08/07 (Mon) 13:20:11
    '備　考：処理を行っていない(現在,"ZZ"：試作品で固定)
    Private Sub cmbDivision_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbDivision.Change

        Dim lblnAns             As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try
            '@種別によりP/Rｵｰﾀﾞｰ必須入力を制御
            Select Case cmbDivision.Text
                '@ES、WS、TS、ZZ(実験)、GG(TEG品)
                Case CPstrFlowClassES, CPstrFlowClassWS, CPstrFlowClassTS, CPstrFlowClassZZ, CPstrFlowClassGG
                    '@P/Rｵｰﾀﾞｰ必須とする
                    fraPrClass.Enabled = True
                    optPrClass0.Enabled = True
                    optPrClass1.Enabled = True
                    optPrClass0.Checked = True           'Pｵｰﾀﾞｰを初期値設定とする
                    Call optPrClass_Click(optPrClass0,e) 'NSYS TrueセットのみではClickイベント発生しないため手動実行
                    cmbPrOrder.Enabled = True
                    
                    '@P/Rｵｰﾀﾞｰが1件の場合は表示
                    If cmbPrOrder.ListCount = 1 Then
                        cmbPrOrder.ListIndex = 0
                        
                        '@値取得列をｺﾒﾝﾄに変更
                        cmbPrOrder.ValueCol = 1
                        '@P/Rｵｰﾀﾞｰｺﾒﾝﾄを表示
                        txtOrderComment.Text = cmbPrOrder.Value
                        txtOrderComment.Enabled = True
                        '@値取得列を戻す
                        cmbPrOrder.ValueCol = 0
                    End If
                    
                    '@P/Rｵｰﾀﾞｰｺﾒﾝﾄ欄の制御
                    txtOrderComment.Enabled = True
                    
                Case Else
                    '@P/Rｵｰﾀﾞｰを使用不可とする
                    fraPrClass.Enabled = False
                    optPrClass0.Enabled = False
                    optPrClass1.Enabled = False
                    optPrClass0.Checked = False
                    optPrClass1.Checked = False
                    cmbPrOrder.Enabled = False
                    RemoveHandler cmbPrOrder.Change,AddressOf cmbPrOrder_Change
                    cmbPrOrder.ListIndex = -1
                    AddHandler cmbPrOrder.Change,AddressOf cmbPrOrder_Change
                    
                    '@P/Rｵｰﾀﾞｰｺﾒﾝﾄ欄,ｽｸﾛｰﾙﾎﾞﾀﾝの制御
                    txtOrderComment.Text = vbNullString
                    txtOrderComment.Enabled = False
                    txtOrderComment.Locked = True
            End Select
                
            '@入力ﾁｪｯｸ
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            '@結果判定
            If lblnAns = True Then
                '@ﾏｽﾀ工順選択時
                If optMster.Checked = True Then
                    '@ｴﾝﾄﾘID空白の場合確定ﾎﾞﾀﾝ押下不可
                    If lblEntryID.Text = vbNullString Then
                        '@確定ﾎﾞﾀﾝ押下不可
                        cmdRegist.Enabled = False
                        Exit Sub
                    End If
                End If
                
                '@投入予約ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
            Else
                '@投入予約ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbDivision_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbDivision_CloseUp
    '機　能：種別選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:11:53 N.Kasai
    '更新日：2004/09/30 (Thu) 19:49:26 N.Kojima
    '備　考：処理を行っていない(現在,"ZZ"：試作品で固定)
    Private Sub cmbDivision_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbDivision.CloseUp
        
        Try
            '@ｺﾝﾎﾞが空でない場合
            If cmbDivision.Text <> vbNullString Then
                '@Validate処理へ
                RemoveHandler cmbDivision.Validating,AddressOf cmbDivision_Validate
                Call cmbDivision_Validate(sender,new CancelEventArgs(True))
                AddHandler cmbDivision.Validating,AddressOf cmbDivision_Validate
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbDivision_CloseUp"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbDivision_Validate
    '機　能：種別選択Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:12:13 N.Kasai
    '更新日：2004/08/19 (Thu) 19:12:13
    '備　考：処理を行っていない(現在,"ZZ"：試作品で固定)
    Private Sub cmbDivision_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbDivision.Validating
        
        Dim lblnAns             As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@入力ﾁｪｯｸ
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            '@結果判定
            If lblnAns = True Then
                '@ﾏｽﾀ工順選択時
                If optMster.Checked = True Then
                    '@ｴﾝﾄﾘID空白の場合確定ﾎﾞﾀﾝ押下不可
                    If lblEntryID.Text = vbNullString Then
                        '@確定ﾎﾞﾀﾝ押下不可
                        cmdRegist.Enabled = False
                        Exit Sub
                    End If
                End If
                
                '@投入予約ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
            Else
                '@投入予約ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False
            End If
            
            If txtWFNum.Enabled = True Then
                '@WF枚数へｾｯﾄﾌｫｰｶｽ
                If ActiveControl.Name = cmbDivision.Name Then
                    Call pubSetFocus(txtWFNum)
                End If
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbDivision_Validate"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtWFNum_Change
    '機　能：WF項目変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/20 (Fri) 19:55:16 N.Kasai
    '更新日：2004/08/20 (Fri) 19:55:16
    '備　考：
    Private Sub txtWFNum_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWFNum.Change

        Try
            '@WF項目Validate処理
            RemoveHandler txtWFNum.Validating,AddressOf txtWFNum_Validate
            Call txtWFNum_Validate(sender,new CancelEventArgs(True))
            AddHandler txtWFNum.Validating,AddressOf txtWFNum_Validate
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtWFNum_Change"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtWFNum_Validate
    '機　能：WF項目Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:16:12 N.Kasai
    '更新日：2004/09/02 (Thu) 10:32:58 Y.Yamagishi
    '      :2008/09/11 (Wed) 07:32:28 T.Sawaguch 案件03044
    '備　考：
    Private Sub txtWFNum_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtWFNum.Validating

        Dim lblnAns             As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)
        Dim llngTxtWfNum        As Integer      'WF枚数ﾃｷｽﾄﾎﾞｯｸｽ値
        
        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            llngTxtWfNum = Val(txtWFNum.Text)
            
            If lblEntryID.Text <> vbNullString Then
            '@ﾛｯﾄ工順情報で機種ｴﾝﾄﾘが設定されている場合
                    
        '@↓2008/09/11 (Wed) 13:32:28 T.Sawaguchi 案件03044 **************************
                '@[WF枚数が機種の最大WF枚数より大きいか] から
                '@｢WF枚数が最大WF枚数25より大きいか」　に変更
                If llngTxtWfNum > CMlngMaxWfCount Then

                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0086, txtWFNum.Text, CMlngMaxWfCount)
                    '@ﾒｯｾｰｼﾞ："<TRM86W>$$ウエハ枚数[%1]が最大WF枚数の設定値[%2]を超えています。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxCM00M0.Instance.Text, True, 16)
        '@↑2008/09/11 (Wed) 13:32:28 T.Sawaguchi 案件03044 **************************
                    
                    '@ﾌｫｰｶｽそのまま
                    e.Cancel = True
                    
                    '@確定ﾎﾞﾀﾝ押下不可
                    cmdRegist.Enabled = False
                    
                    Exit Sub
                End If
            Else
            '@ﾛｯﾄ工順情報で機種ｴﾝﾄﾘ以外が設定されている場合
                '@現在選択されている機種の最大WF枚数
                
        '@↓2008/09/11 (Wed) 13:32:28 T.Sawaguchi 案件03044 **************************
                '@[WF枚数が機種の最大WF枚数より大きいか] から
                '@｢WF枚数が最大WF枚数25より大きいか」　に変更
                If llngTxtWfNum > CMlngMaxWfCount Then

                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0086, txtWFNum.Text, CMlngMaxWfCount)
                    '@ﾒｯｾｰｼﾞ："<TRM86W>$$ウエハ枚数[%1]が最大WF枚数の設定値[%2]を超えています。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxCM00M0.Instance.Text, True, 16)
        '@↑2008/09/11 (Wed) 13:32:28 T.Sawaguchi 案件03044 **************************
                    
                    '@ﾌｫｰｶｽそのまま
                    e.Cancel = True
                    
                    '@確定ﾎﾞﾀﾝ押下不可
                    cmdRegist.Enabled = False
                    
                    Exit Sub
                End If
            End If
            
            '@入力ﾁｪｯｸ
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            '@結果判定
            If lblnAns = True Then
                '@ﾏｽﾀ工順選択時
                If optMster.Checked = True Then
                    '@ｴﾝﾄﾘID空白の場合確定ﾎﾞﾀﾝ押下不可
                    If lblEntryID.Text = vbNullString Then
                        '@確定ﾎﾞﾀﾝ押下不可
                        cmdRegist.Enabled = False
                        
                        Exit Sub
                    End If
                End If
                
                '@投入予約ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
            Else
                '@投入予約ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtWFNum_Validate"          '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：dtpStartDate_CalendarSelect
    '機　能：投入予定日選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:19:07 N.Kasai
    '更新日：2004/08/19 (Thu) 19:19:07
    '備　考：
    Private Sub dtpStartDate_CalendarSelect(ByVal sender As Object, ByVal e As EventArgs) Handles dtpStartDate.CalendarSelect
        
        Try
            '@日付が選択されている場合
            If dtpStartDate.Value <> CPstrNullDate Then
                '@Validate処理へ
                Call dtpStartDate_Validate(sender,new CancelEventArgs(True))
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey                 '機能ID
                .strProcName = "dtpStartDate_CalendarSelect"    '処理名
                .strErrMessage = vbNullString                   'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：dtpStartDate_Validate
    '機　能：投入予定日選択Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:19:25 N.Kasai
    '更新日：2008/06/11 (Wed) 13:36:35 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 13:36:35 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub dtpStartDate_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles dtpStartDate.Validating

        Dim lblnAns             As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)
        Dim lstrNowDT           As String       '現在日付取得

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@日付が入力されていいる場合
            If dtpStartDate.Value <> CPstrNullDate Then
                '@日付の有効性ﾁｪｯｸ
                If pubblnYearRange_Chk(dtpStartDate.Value) = False Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0008)
                    
                    '@"正しい日付を入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ﾌｫｰｶｽを移さない
                    e.Cancel = True
                    
                    Exit Sub
                Else
                    '@現在日付取得
                    lstrNowDT = Format$(Now, CPstrDateTimeYMD)
                    
                    '@日付比較判定
                    If Format(CDate(dtpStartDate.Value), CPstrDateTimeYMD) < lstrNowDT Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                        
                        '@"過去日付は指定できません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ﾌｫｰｶｽを移さない
                        e.Cancel = True
                        
                        Exit Sub
                    End If
                End If
            End If
            
            '@入力ﾁｪｯｸ
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            '@結果判定
            If lblnAns = True Then
                '@ﾏｽﾀ工順選択時
                If optMster.Checked = True Then
                    '@ｴﾝﾄﾘID空白の場合確定ﾎﾞﾀﾝ押下不可
                    If lblEntryID.Text = vbNullString Then
                        
                        '@確定ﾎﾞﾀﾝ押下不可
                        cmdRegist.Enabled = False
                        
                        Exit Sub
                    End If
                End If
                
                '@投入予約ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
            Else
                '@投入予約ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False
            End If
            
            '@ﾛｯﾄ担当が有効か
            If cmbLotManager.Enabled = True Then
                '@ﾛｯﾄ担当へﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = dtpStartDate.Name Then
                    Call pubSetFocus(cmbLotManager)
                End If
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "dtpStartDate_Validate"      '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbLotManager_CloseUp
    '機　能：ﾛｯﾄ担当ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:21:27 N.Kasai
    '更新日：2008/06/11 (Wed) 13:37:00 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 13:37:00 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub cmbLotManager_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLotManager.CloseUp
        
        Try
            '@ﾛｯﾄ担当がNULL以外か
            If cmbLotManager.Text <> vbNullString Then
                '@Validate処理へ
                RemoveHandler cmbLotManager.Validating,AddressOf cmbLotManager_Validate
                Call cmbLotManager_Validate(sender,new CancelEventArgs(True))
                AddHandler cmbLotManager.Validating,AddressOf cmbLotManager_Validate
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbLotManager_CloseUp"      '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbLotManager_Validate
    '機　能：ﾛｯﾄ担当ｺﾝﾎﾞ　Validate処理(選択確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:21:43 N.Kasai
    '更新日：2008/06/11 (Wed) 13:37:59 N.Kojima
    '備　考：
    '　　　：2006/08/07 (Mon) 13:30:58 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(案件№01362)
    '　　　：2008/06/11 (Wed) 13:37:59 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub cmbLotManager_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbLotManager.Validating

        Dim lblnAns         As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@入力ﾁｪｯｸ
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            
            '@結果判定
            If lblnAns = True Then
                
                '@投入予約ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
                
                '@ﾏｽﾀ工順選択時
                If optMster.Checked = True Then
                    
                    '@ｴﾝﾄﾘID空白の場合確定ﾎﾞﾀﾝ押下不可
                    If lblEntryID.Text = vbNullString Then
                        
                        '@確定ﾎﾞﾀﾝ押下不可
                        cmdRegist.Enabled = False
                        Exit Sub
                    End If
                End If
                
                '@ﾌｫｰｶｽの移動
                If optPrClass0.Enabled = True And optPrClass1.Enabled = True Then
                    Select Case True
                        Case optPrClass0.Checked
                            '@Pｵｰﾀﾞｰへｾｯﾄﾌｫｰｶｽ
                            If ActiveControl.Name = cmbLotManager.Name Then
                                Call pubSetFocus(optPrClass0)
                            End If
                        Case optPrClass1.Checked
                            '@Pｵｰﾀﾞｰへｾｯﾄﾌｫｰｶｽ
                            If ActiveControl.Name = cmbLotManager.Name Then
                                Call pubSetFocus(optPrClass1)
                            End If
                    End Select
                Else
                    If optMster.Enabled = True Then
                        If ActiveControl.Name = cmbLotManager.Name Then
                            Call pubSetFocus(optMster)
                        End If
                    End If
                End If
            
            Else
                '@投入予約ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False

                '@ﾌｫｰｶｽの移動
                If optPrClass0.Enabled = True And optPrClass1.Enabled = True Then
                    Select Case True
                        Case optPrClass0.Checked
                            '@Pｵｰﾀﾞｰへｾｯﾄﾌｫｰｶｽ
                            If ActiveControl.Name = cmbLotManager.Name Then
                                Call pubSetFocus(optPrClass0)
                            End If
                        Case optPrClass1.Checked
                            '@Pｵｰﾀﾞｰへｾｯﾄﾌｫｰｶｽ
                            If ActiveControl.Name = cmbLotManager.Name Then
                                Call pubSetFocus(optPrClass1)
                            End If
                    End Select
                Else
                    '@作業ﾒﾓへｾｯﾄﾌｫｰｶｽ
                    If ActiveControl.Name = cmbLotManager.Name Then
                        Call pubSetFocus(txtWorkMemo)
                    End If
                End If
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbLotManager_Validate"     '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：optPrClass_Click
    '機　能：P/R区分の選択
    '引　数：Index：　0：Pｵｰﾀﾞｰ、1:Rｵｰﾀﾞｰ
    '戻り値：なし
    '作成日：2006/08/07 (Mon) 13:37:14 T.Kitagawa
    '更新日：2006/08/07 (Mon) 13:37:14
    '備　考：
    Private Sub optPrClass_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optPrClass0.Click,optPrClass1.Click

        Dim llngCnt As Integer      '汎用ｶｳﾝﾀ
        Dim Index   As Integer      '押下コントロール種別
        
        Try
            'NSYS クリックしたコントロール名の最後尾1文字を取得
            If IsNumeric(Strings.Right$(sender.Name,1)) Then
                Index = CInt(Strings.Right$(sender.Name,1))
            Else
                Exit Sub
            End If

            'NSYS 前回選択と同じ場合は処理を抜ける
            If mlngOptPrClassStat = Index Then
                Exit Sub
            Else
                mlngOptPrClassStat = Index
            End If

            '@P/R区分によりP/Rｵｰﾀﾞｰｺﾝﾎﾞに設定する
            With cmbPrOrder
                .Clear
                '@P/R区分にて設定内容を変更する
                Select Case Index
                    Case CMlngOptPrClassP
                    '@Pｵｰﾀﾞｰ
                        For llngCnt = 0 To mtypPrOrderListAns.lngPrOrderListCnt - 1
                            '@Pｵｰﾀﾞｰ判定(ｵｰﾀﾞｰID＋ｵｰﾀﾞｰｺﾒﾝﾄ)
                            If Strings.Left$(mtypPrOrderListAns.typPrOrderList(llngCnt).strPROrderID, 1) = CPstrPrOrderClassP Then
                                .AddItem(mtypPrOrderListAns.typPrOrderList(llngCnt).strPROrderID _
                                        & vbTab _
                                        & mtypPrOrderListAns.typPrOrderList(llngCnt).strOrderComments)
                            End If
                        Next
                    Case CMlngOptPrClassR
                    '@Rｵｰﾀﾞｰ
                        For llngCnt = 0 To mtypPrOrderListAns.lngPrOrderListCnt - 1
                            '@Pｵｰﾀﾞｰ判定(ｵｰﾀﾞｰID＋ｵｰﾀﾞｰｺﾒﾝﾄ)
                            If Strings.Left$(mtypPrOrderListAns.typPrOrderList(llngCnt).strPROrderID, 1) = CPstrPrOrderClassR Then
                                .AddItem(mtypPrOrderListAns.typPrOrderList(llngCnt).strPROrderID _
                                        & vbTab _
                                        & mtypPrOrderListAns.typPrOrderList(llngCnt).strOrderComments)
                            End If
                        Next
                End Select
                
                '@P/Rｵｰﾀﾞｰｺﾒﾝﾄもｸﾘｱ
                txtOrderComment.Text = vbNullString
                
                '@P/Rｵｰﾀﾞｰが1件の場合は表示
                If .ListCount = 1 Then
                    .ListIndex = 0
                    '@値取得列をｺﾒﾝﾄに変更
                    .ValueCol = 1
                    '@P/Rｵｰﾀﾞｰｺﾒﾝﾄを表示
                    txtOrderComment.Text = .Value
                    txtOrderComment.Enabled = True
                    '@値取得列を戻す
                    .ValueCol = 0
                End If
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "optPrClass_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPrOrder_CloseUp
    '機　能：P/Rｵｰﾀﾞｰ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/07 (Mon) 13:39:26 T.Kitagawa
    '更新日：2006/08/07 (Mon) 13:39:26
    '備　考：
    Private Sub cmbPrOrder_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPrOrder.CloseUp

        Try
            '@空選択の場合はﾌｫｰｶｽの移動はしない
            If cmbPrOrder.Text <> vbNullString Then
                '@Validate処理へ
                RemoveHandler cmbPrOrder.Validating,AddressOf cmbPrOrder_Validate
                Call cmbPrOrder_Validate(sender,new CancelEventArgs(True))
                AddHandler cmbPrOrder.Validating,AddressOf cmbPrOrder_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPrOrder_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPrOrder_Change
    '機　能：P/Rｵｰﾀﾞｰ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/07 (Mon) 13:39:56 T.Kitagawa
    '更新日：2006/08/07 (Mon) 13:39:56
    '備　考：
    Private Sub cmbPrOrder_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPrOrder.Change
        
        Dim lblnAns As Boolean  '戻り値

        Try
            '@P/Rｵｰﾀﾞｰｺﾒﾝﾄを表示
            '@値取得列をｺﾒﾝﾄに変更
            cmbPrOrder.ValueCol = 1
            txtOrderComment.Text = cmbPrOrder.Value
            txtOrderComment.Enabled = True
            '@値取得列を戻す
            cmbPrOrder.ValueCol = 0
             
             '@入力ﾁｪｯｸ
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            
            '@結果判定
            If lblnAns = True Then
                '@ﾏｽﾀ工順選択時
                If optMster.Checked = True Then
                    '@ｴﾝﾄﾘID空白の場合確定ﾎﾞﾀﾝ押下不可
                    If lblEntryID.Text = vbNullString Then
                        '@確定ﾎﾞﾀﾝ押下不可
                        cmdRegist.Enabled = False
                        Exit Sub
                    End If
                End If
                
                '@投入予約ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
            Else
                '@投入予約ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False
                '@P/Rｵｰﾀﾞｰが有効な場合
                If cmbPrOrder.Enabled = True Then
                    Call pubSetFocus(cmbPrOrder)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPrOrder_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPrOrder_Validate
    '機　能：P/RｵｰﾀﾞｰValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2006/08/07 (Mon) 13:41:46 T.Kitagawa
    '更新日：2006/11/02 (Thu) 16:11:05 N.Kasai
    '備　考：
    '　　　：2006/11/02 (Thu) 16:11:05 N.Kasai  送品ｺﾝﾎﾞ対応(№01500)
    Private Sub cmbPrOrder_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPrOrder.Validating

        Dim lblnAns             As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@入力ﾁｪｯｸ
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            
            '@結果判定
            If lblnAns = True Then
                '@ﾏｽﾀ工順選択時
                If optMster.Checked = True Then
                    '@ｴﾝﾄﾘID空白の場合確定ﾎﾞﾀﾝ押下不可
                    If lblEntryID.Text = vbNullString Then
                        '@確定ﾎﾞﾀﾝ押下不可
                        cmdRegist.Enabled = False
                        Exit Sub
                    End If
                End If
                
        '@↓2006/11/02 (Thu) 16:11:42 N.Kasai **************************************************
        '        '@ﾌｫｰｶｽの移動
        '        If optMster.Enabled = True Then
        '            Call pubSetFocus(optMster)
        '        End If
                
                '@投入予約ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
            Else
                '@投入予約ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False
            
        '        '@作業ﾒﾓへｾｯﾄﾌｫｰｶｽ
        '        Call pubSetFocus(txtWorkMemo)
            End If

            '@送品へｾｯﾄﾌｫｰｶｽ
            If ActiveControl.Name = cmbPrOrder.Name Then
                Call pubSetFocus(cmbLotSend)
            End If
        '@↑2006/11/02 (Thu) 16:11:42 N.Kasai **************************************************


            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPrOrder_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2005/06/27 (Mon) 16:53:21 S.Deguchi **************************************************
    '関数名：cmbUserProduct_Change
    '機　能：機種変更処理(user)
    '引　数：なし
    '戻り値：なし
    '作成日：2005/06/27 (Mon) 16:53:03 S.Deguchi
    '更新日：2005/06/27 (Mon) 16:53:03
    '備　考：
    Private Sub cmbUserProduct_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbUserProduct.Change

        Try
            '@退避領域と異なる場合は初期化する
            If mstrProductID <> cmbUserProduct.Text Then
                '@ｴﾝﾄﾘID/名
                lblEntryID.Text = vbNullString
                lblEntryName.Text = vbNullString
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbUserProduct_Change"      '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub
    '@↑2005/06/27 (Mon) 16:53:21 S.Deguchi **************************************************

    '関数名：cmbUserProduct_CloseUp
    '機　能：機種選択処理(user)
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/17 (Tue) 18:09:40 N.Kasai
    '更新日：2004/09/30 (Thu) 19:49:40 N.Kojima
    '備　考：
    Private Sub cmbUserProduct_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbUserProduct.CloseUp
        
        Try
            '@ｺﾝﾎﾞが空でない場合
            If cmbUserProduct.Text <> vbNullString Then
                '@Validate処理へ
                RemoveHandler cmbUserProduct.Validating,AddressOf cmbUserProduct_Validate
                Call cmbUserProduct_Validate(sender,new CancelEventArgs(True))
                AddHandler cmbUserProduct.Validating,AddressOf cmbUserProduct_Validate
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbUserProduct_CloseUp"     '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbUserProduct_Validate
    '機　能：機種選択(user)Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/17 (Tue) 18:09:40 N.Kasai
    '更新日：2005/07/26 (Tue) 10:15:24 N.Kasai
    '備　考：
    '　　　：2005/07/26 (Tue) 10:15:24 N.Kasai      L/R色追加
    Private Sub cmbUserProduct_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbUserProduct.Validating
        
        Dim lblnAns                 As Boolean          '入力ﾁｪｯｸ結果格納(True:OK,False:NG)
        Dim lstrFormName            As String           'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        
        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@空欄の場合には,次ﾌｫｰｶｽへ
            If cmbUserProduct.Text = vbNullString Then
                '@ﾕｰｻﾞｰﾌﾟﾛｾｽID欄活性化時
                If txtUserEntry.Enabled = True Then
                    '@ﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbUserProduct.Name Then
                        Call pubSetFocus(txtUserEntry)
                    End If
                Else
                    '@閉じるﾎﾞﾀﾝへ
                    If ActiveControl.Name = cmbUserProduct.Name Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
                
                Exit Sub
            End If

            '@退避領域と同じ場合には,処理を行わない
            If mstrProductID <> cmbUserProduct.Text Then
                
                
                
        '@↓2005/07/26 (Tue) 10:13:39 N.Kasai **************************************************
                '@値取得(ﾊﾞｯｸｶﾗｰ値)
                cmbUserProduct.ValueCol = CMlngCmbGetCol5
                
                If cmbUserProduct.Value <> vbNullString Then
                    '@ﾊﾞｯｸｶﾗｰ反映
                    cmbUserProduct.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(cmbUserProduct.Value))
                Else
                    cmbUserProduct.BackColor = SystemColors.Window
                End If
        '@↑2005/07/26 (Tue) 10:13:39 N.Kasai **************************************************
         
                '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
                lstrFormName = Me.Name
                lstrEventName = "cmbUserProduct_Validate"
            
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(lstrFormName, lstrEventName)
            
                '@機種による工順を取得
                Call prvMasEntryList_Sel()
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            
                '@入力ﾁｪｯｸ
                lblnAns = prvblnInput_Chk(CMlngCreateInfo)
                '@結果判定
                If lblnAns = True Then
                    '@ﾏｽﾀ工順選択時
                    If optMster.Checked = True Then
                        '@ｴﾝﾄﾘID空白の場合確定ﾎﾞﾀﾝ押下不可
                        If lblEntryID.Text = vbNullString Then
                            '@確定ﾎﾞﾀﾝ押下不可
                            cmdRegist.Enabled = False
                            
                            Exit Sub
                        End If
                    End If
                    
                    '@投入予約ﾎﾞﾀﾝ活性化
                    cmdRegist.Enabled = True
                Else
                    '@投入予約ﾎﾞﾀﾝ非活性化
                    cmdRegist.Enabled = False
                End If
            End If
            
            '@ﾌｫｰｶｽの設定
            If txtUserEntry.Enabled = True Then
                If ActiveControl.Name = cmbUserProduct.Name Then
                    Call pubSetFocus(txtUserEntry)
                End If
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbUserProduct_Validate"    '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtUserEntry_Change
    '機　能：ﾕｰｻﾞﾌﾟﾛｾｽIDValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:13:04 N.Kasai
    '更新日：2004/08/19 (Thu) 19:13:04
    '備　考：
    Private Sub txtUserEntry_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtUserEntry.Change

        Dim lblnAns             As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try
            '@入力ﾁｪｯｸ
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            '@結果判定
            If lblnAns = True Then
                '@ﾏｽﾀ工順選択時
                If optMster.Checked = True Then
                    '@ｴﾝﾄﾘID空白の場合確定ﾎﾞﾀﾝ押下不可
                    If lblEntryID.Text = vbNullString Then
                        '@確定ﾎﾞﾀﾝ押下不可
                        cmdRegist.Enabled = False
                        
                        Exit Sub
                    End If
                End If
                
                '@投入予約ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
            Else
                '@投入予約ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtUserEntry_Change"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtUserEntryName_Change
    '機　能：ﾕｰｻﾞﾌﾟﾛｾｽ名Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:14:38 N.Kasai
    '更新日：2004/08/19 (Thu) 19:14:38
    '備　考：
    Private Sub txtUserEntryName_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtUserEntryName.Change
        
        Dim lblnAns             As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try
            '@入力ﾁｪｯｸ
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            '@結果判定
            If lblnAns = True Then
                '@ﾏｽﾀ工順選択時
                If optMster.Checked = True Then
                    '@ｴﾝﾄﾘID空白の場合確定ﾎﾞﾀﾝ押下不可
                    If lblEntryID.Text = vbNullString Then
                        '@確定ﾎﾞﾀﾝ押下不可
                        cmdRegist.Enabled = False
                        
                        Exit Sub
                    End If
                End If
                
                '@投入予約ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
            Else
                '@投入予約ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtUserEntryName_Change"    '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbUserLotManager_CloseUp
    '機　能：ﾛｯﾄ担当(ﾕｰｻﾞｰﾌﾟﾛｾｽ)選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 18:42:31 N.Kasai
    '更新日：2008/06/11 (Wed) 13:47:48 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 13:47:48 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub cmbUserLotManager_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbUserLotManager.CloseUp
        
        Try
            '@ﾛｯﾄ担当(ﾕｰｻﾞｰﾌﾟﾛｾｽ)がNULL以外か
            If cmbUserLotManager.Text <> vbNullString Then
                '@Validate処理へ
                RemoveHandler cmbUserLotManager.Validating,AddressOf cmbUserLotManager_Validate
                Call cmbUserLotManager_Validate(sender,new CancelEventArgs(True))
                AddHandler cmbUserLotManager.Validating,AddressOf cmbUserLotManager_Validate
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbUserLotManager_CloseUp"  '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbUserLotManager_Validate
    '機　能：ﾛｯﾄ担当(ﾕｰｻﾞｰﾌﾟﾛｾｽ)Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 18:42:34 N.Kasai
    '更新日：2008/06/11 (Wed) 13:48:40 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 13:48:40 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub cmbUserLotManager_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbUserLotManager.Validating

        Dim lblnAns         As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@入力ﾁｪｯｸ
            lblnAns = prvblnInput_Chk(CMlngCreateInfo)
            '@結果判定
            If lblnAns = True Then
                '@投入予約ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
                            
                '@ﾏｽﾀ工順選択時
                If optMster.Checked = True Then
                    '@ﾏｽﾀ工順へﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbUserLotManager.Name Then
                        Call pubSetFocus(optMster)
                    End If
                
                    '@ｴﾝﾄﾘID空白の場合確定ﾎﾞﾀﾝ押下不可
                    If lblEntryID.Text = vbNullString Then
                        '@確定ﾎﾞﾀﾝ押下不可
                        cmdRegist.Enabled = False
                        Exit Sub
                    End If
                End If
                
            Else
                '@投入予約ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False
            
                '@作業ﾒﾓへｾｯﾄﾌｫｰｶｽ
                If ActiveControl.Name = cmbUserLotManager.Name Then
                    Call pubSetFocus(txtWorkMemo)
                End If
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbUserLotManager_Validate" '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmbLotSend_CloseUp
    '機　能：送品ｺﾝﾎﾞ選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/11/02 (Thu) 16:20:17 N.Kasai
    '更新日：2006/11/02 (Thu) 16:20:17
    '備　考：
    Private Sub cmbLotSend_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLotSend.CloseUp

        Try
            '@ﾌｫｰｶｽ移動
            SendKeys.SendWait(CPstrSendKeysTab)
         
         Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmbLotSend_CloseUp"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
         
        End Try
    End Sub


    '関数名：optMster_Click
    '機　能：ﾏｽﾀ工順選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:33:31 N.Kasai
    '更新日：2004/08/19 (Thu) 19:33:31
    '備　考：
    Private Sub optMster_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optMster.Click

        Dim lblnAns         As Boolean          '入力ﾁｪｯｸ結果格納(True:OK,False:NG)
            
        Try
            '@工順ｺﾋﾟｰ制御(無効)
            With txtCopyLotID
                .Enabled = False
                .BackColor = SystemColors.ControlLight
            End With
            
            '@工順ｺﾋﾟｰﾛｯﾄIDﾎﾞﾀﾝ制御(無効)
            With cmdCopyLotID
                .Enabled = False
            End With
            
            '@機種ｴﾝﾄﾘﾎﾞﾀﾝ使用可
            cmdEntry.Enabled = True
            
            '@ｴﾝﾄﾘID使用可
            lblEntryID.Enabled = True
            
            '@ｴﾝﾄﾘ名使用可
            lblEntryName.Enabled = True
            
            '@入力ﾁｪｯｸ
            lblnAns = prvblnInput_Chk(CMlngOrderInfo)
            '@結果判定
            If lblnAns = True Then
                '@ﾏｽﾀ工順選択時
                If optMster.Checked = True Then
                    '@ｴﾝﾄﾘID空白の場合確定ﾎﾞﾀﾝ押下不可
                    If lblEntryID.Text = vbNullString Then
                        '@確定ﾎﾞﾀﾝ押下不可
                        cmdRegist.Enabled = False
                        Exit Sub
                    End If
                End If
                
                '@投入予約ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
            Else
                '@投入予約ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False
            End If
                
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "optMster_Click"             '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
                
        End Try
    End Sub

    '関数名：cmdEntry_Click
    '機　能：機種ｴﾝﾄﾘﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 10:27:32 N.Kasai
    '更新日：2004/08/19 (Thu) 10:27:32
    '備　考：
    '　　　：2005/06/27 (Mon) 09:23:03 S.Deguchi    引継ﾊﾟﾌﾞﾘｯｸ変数の初期化処理を追加
    Private Sub cmdEntry_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdEntry.Click
        
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
            
            '@新規ﾛｯﾄID採番にﾁｪｯｸがある場合
            If optNew.Checked = True Then
                '@機種IDの退避(ﾏｽﾀ工順取得用)
                pstrPDID = cmbProduct.Text
            Else
                '@機種IDの退避(ﾏｽﾀ工順取得用)
                pstrPDID = cmbUserProduct.Text
            End If
            
            '@起動区分指定
            plngfrmxxCM00F0Kbn = CMlngPDEntry
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@引継ﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrEntryID = vbNullString          '機種ｴﾝﾄﾘID
            pstrEntryName = vbNullString        '機種ｴﾝﾄﾘ名
            
            '@機種ｴﾝﾄﾘ一覧表示
            frmxxCM00F0.Instance = New frmxxCM00F0()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM00F0.Instance = Nothing
                
                Exit Sub
            End If
            
            '@ｻﾌﾞﾌｫｰﾑの名称設定
            frmxxCM00F0.Instance.Text = CPstrSubDispTitlePDEntryList
            
            '@機種ｴﾝﾄﾘ一覧表示
            frmxxCM00F0.Instance.ShowDialog(Me)
            frmxxCM00F0.Instance = Nothing
            
            '@機種ｴﾝﾄﾘが選択されている場合
            If pstrEntryName <> vbNullString Then
                '@ｴﾝﾄﾘIDをｾｯﾄ
                lblEntryID.Text = pstrEntryID
                '@ｴﾝﾄﾘ名をｾｯﾄ
                lblEntryName.Text = pstrEntryName
                
                '@基礎情報にﾁｪｯｸがある場合
                If optNew.Checked = True Then
                    '@ｴﾝﾄﾘに紐付く最大WF枚数を退避
                    mlngPdEntryMaxWFCount = pstrMaxWFCount
                    '@WF枚数をｾｯﾄ
                    txtWFNum.Text = pstrMaxWFCount
                End If
                
                '@投入予約ﾎﾞﾀﾝのﾛｯｸ解除
                cmdRegist.Enabled = True
                
                '@投入予約ﾎﾞﾀﾝにｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(cmdRegist)
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdEntry_Click"             '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：optCopy_Click
    '機　能：工順ｺﾋﾟｰ選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:31:38 N.Kasai
    '更新日：2004/08/19 (Thu) 19:31:38
    '備　考：
    Private Sub optCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optCopy.Click
        
        Dim lblnAns         As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)
        
        Try
            '@工順ｺﾋﾟｰ制御(有効)
            With txtCopyLotID
                .Enabled = True
                .BackColor = SystemColors.Window
            End With
            
            '@工順ｺﾋﾟｰﾛｯﾄIDﾎﾞﾀﾝ制御(有効)
            With cmdCopyLotID
                .Enabled = True
            End With
            
            '@機種ｴﾝﾄﾘﾎﾞﾀﾝ使用不可
            cmdEntry.Enabled = False
            
            '@ｴﾝﾄﾘID使用不可
            lblEntryID.Enabled = False
            
            '@ｴﾝﾄﾘ名使用不可
            lblEntryName.Enabled = False
            
            '@入力ﾁｪｯｸ
            lblnAns = prvblnInput_Chk(CMlngOrderInfo)
            '@結果判定
            If lblnAns = True Then
                '@ﾏｽﾀ工順選択時
                If optMster.Checked = True Then
                    '@ｴﾝﾄﾘID空白の場合確定ﾎﾞﾀﾝ押下不可
                    If lblEntryID.Text = vbNullString Then
                        '@確定ﾎﾞﾀﾝ押下不可
                        cmdRegist.Enabled = False
                        Exit Sub
                    End If
                End If
                
                '@投入予約ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
            Else
                '@投入予約ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "optCopy_Click"              '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtCopyLotID_Change
    '機　能：工順コピーﾛｯﾄID変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:36:04 N.Kasai
    '更新日：2004/08/19 (Thu) 19:36:04
    '備　考：
    Private Sub txtCopyLotID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCopyLotID.Change

        Dim lblnAns         As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try
            '@入力ﾁｪｯｸ
            lblnAns = prvblnInput_Chk(CMlngOrderInfo)
            '@結果判定
            If lblnAns = True Then
                '@ﾏｽﾀ工順選択時
                If optMster.Checked = True Then
                    '@ｴﾝﾄﾘID空白の場合確定ﾎﾞﾀﾝ押下不可
                    If lblEntryID.Text = vbNullString Then
                        '@確定ﾎﾞﾀﾝ押下不可
                        cmdRegist.Enabled = False
                        Exit Sub
                    End If
                End If
                '@投入予約ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
            Else
                '@投入予約ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtCopyLotID_Change"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtCopyLotID_Validate
    '機　能：工順コピーﾛｯﾄIDValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:36:56 N.Kasai
    '更新日：2004/08/19 (Thu) 19:36:56
    '　　　：2008/09/05 (Fri) 10:29:24 T.Sawaguchi  異機種間ｺﾋﾟｰをﾕｰｻﾞｰﾌﾟﾛｾｽ設定時を除き禁止,　(案件03141)
    '備　考：
    Private Sub txtCopyLotID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCopyLotID.Validating
        
        Dim lblnAns         As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)
        Dim lblnAnsLot      As Boolean      '結果取得(True:正常,False:異常)
        
        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ｺﾋﾟｰ元ﾛｯﾄID入力ﾁｪｯｸ
            If optCopy.Checked = True Then
                '@ｺﾋﾟｰ元ﾛｯﾄID10桁以外で空欄ではない場合
                If Len(txtCopyLotID.Text) <> CMlngLotIDByte And txtCopyLotID.Text <> vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0012)
                    '@"ロットIDは10桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    '@再入力
                    e.Cancel = True
                Else
                
        '@↓2008/09/05 (Fri) 10:29:24 T.Sawaguchi 案件03141 **************************
                    '@工順ｺﾋﾟｰﾛｯﾄIDが10桁、またはNULLの場合
                    '@工順ｺﾋﾟｰﾛｯﾄIDがNULL以外か
                    If txtCopyLotID.Text <> vbNullString Then
                                    
                        '@【ﾛｯﾄ現在状態取得】ﾒｯｾｰｼﾞ送受信処理   ※処理区分：0Q(ﾛｯﾄ工順)
                        lblnAnsLot = pubblnLotCurstate_Sel(CMstrlot_curstateVer, _
                                                           CPstrCD0Q, _
                                                           vbNullString, _
                                                           mtypLotCurState, _
                                                           txtCopyLotID.Text)

                        '@ﾛｯﾄ現在状態取得結果判定
                        If lblnAnsLot = True Then
                            '@ﾛｯﾄ現在状態取得結果：正常の場合
                            '@工順作成ID採番が選択されている場合はﾁｪｯｸはしない
                            If optProcess.Checked = False Then
                                '@工順ｺﾋﾟｰﾛｯﾄIDの機種が違う場合は、ｴﾗｰとして投入予約不可とする。
                                '@選択された機種と親機種をﾁｪｯｸする。
                                If mtypLotCurState.strPdId <> cmbProduct.Text Then
                                    '@表示ﾒｯｾｰｼﾞ変換
                                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005J)
                                    '@ﾒｯｾｰｼﾞ： "<TRM5JW>$$機種が異なります。同一機種のロットを設定してください。"
                                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, frmxxCM00M0.Instance.Text, True, 16)
                
                                    '@ﾌｫｰｶｽ保持
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            End If

        '@↑2008/09/05 (Fri) 10:29:24 T.Sawaguchi 案件03141 **************************
                        
                            '@入力ﾁｪｯｸ
                            lblnAns = prvblnInput_Chk(CMlngOrderInfo)
                            '@結果判定
                            If lblnAns = True Then
                                '@ﾏｽﾀ工順選択時
                                If optMster.Checked = True Then
                                    '@ｴﾝﾄﾘID空白の場合確定ﾎﾞﾀﾝ押下不可
                                    If lblEntryID.Text = vbNullString Then
                                        '@確定ﾎﾞﾀﾝ押下不可
                                        cmdRegist.Enabled = False
                                        Exit Sub
                                    End If
                                End If
                                '@投入予約ﾎﾞﾀﾝ活性化
                                cmdRegist.Enabled = True
                            Else
                                '@投入予約ﾎﾞﾀﾝ非活性化
                                cmdRegist.Enabled = False
                            End If
                            '@ｺﾋﾟｰ元ﾛｯﾄID取得ﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                            If ActiveControl.Name = txtCopyLotID.Name Then
                                Call pubSetFocus(cmdCopyLotID)
                            End If
                        
                        Else
                            '@ﾛｯﾄ現在状態取得結果：異常の場合
                        
                            '@ﾌｫｰｶｽ保持
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If
                End If
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtCopyLotID_Validate"      '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCopyLotID_Click
    '機　能：工順ｺﾋﾟｰﾛｯﾄID検索
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:38:24 N.Kasai
    '更新日：2004/08/19 (Thu) 19:38:24
    '　　　：2008/09/04 (Thu) 15:01:55T.Sawaguchi  異機種間ｺﾋﾟｰ禁止対応　(案件03141)
    '備　考：流動中のﾛｯﾄを検索
    Private Sub cmdCopyLotID_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCopyLotID.Click
        
        Dim lblnAns         As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)
        
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

            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            Select Case True
                Case optNew.Checked
                    '@引渡し構造体に値を格納
                    With ptypCM00J0
                        .lngListIndex = cmbProduct.ListIndex
                        .strClassDivisionPdlist = CPstrCD2A & CPstrCD30
                        .strClassDivisionTravlist = CPstrCD02
                        .strPdId = vbNullString
                        .strLotID = vbNullString
        '@↓2008/09/04 (Thu) 15:00:25 T.Sawaguchi 案件03005 **************************
                        '工順作成ID採番がﾁｪｯｸされた場合はﾌﾗｸﾞをONにする
                        If optProcess.Checked = True Then
                            .strUserProcessFlag = CMstrUserProcessFlagON
                        Else
                            .strUserProcessFlag = vbNullString
                        End If
        '@↑2008/09/04 (Thu) 15:00:25 T.Sawaguchi 案件03141 **************************
                    End With
                    
                Case optProcess.Checked
                    '@引渡し構造体に値を格納
                    With ptypCM00J0
                        .lngListIndex = cmbUserProduct.ListIndex
                        .strClassDivisionPdlist = CPstrCD2A & CPstrCD30
                        .strClassDivisionTravlist = CPstrCD02
                        .strPdId = vbNullString
                        .strLotID = vbNullString
        '@↓2008/09/04 (Thu) 15:00:25 T.Sawaguchi 案件03141 **************************
                        '工順作成ID採番がﾁｪｯｸされた場合はﾌﾗｸﾞをONにする
                        If optProcess.Checked = True Then
                            .strUserProcessFlag = CMstrUserProcessFlagON
                        Else
                            .strUserProcessFlag = vbNullString
                        End If
        '@↑2008/09/04 (Thu) 15:00:25 T.Sawaguchi 案件03141 **************************

                    End With
                Case Else
                    '@引渡し構造体に値を格納
                    With ptypCM00J0
                        .lngListIndex = -1
                        .strClassDivisionPdlist = CPstrCD2A & CPstrCD30
                        .strClassDivisionTravlist = CPstrCD02
                        .strPdId = vbNullString
                        .strLotID = vbNullString
        '@↓2008/09/04 (Thu) 15:00:25 T.Sawaguchi 案件03141 **************************
                        '工順作成ID採番がﾁｪｯｸされた場合はﾌﾗｸﾞをONにする
                        If optProcess.Checked = True Then
                            .strUserProcessFlag = CMstrUserProcessFlagON
                        Else
                            .strUserProcessFlag = vbNullString
                        End If
        '@↑2008/09/04 (Thu) 15:00:25 T.Sawaguchi 案件03141 **************************
                    End With
            End Select
            
            '@投入予定ﾛｯﾄ一覧画面をﾛｰﾄﾞ
            frmxxCM00J0.Instance = New frmxxCM00J0()

            '@サブﾌｫｰﾑ名称の設定
            frmxxCM00J0.Instance.Text = CPstrSubDispTitleCopyLotSel

            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM00J0.Instance = Nothing
                Exit Sub
            End If

            frmxxCM00J0.Instance.ShowDialog(Me)
            frmxxCM00J0.Instance = Nothing
            
            '@戻り値を反映
            If ptypCM00J0.strLotID <> vbNullString Then
                txtCopyLotID.Text = ptypCM00J0.strLotID
            End If

            '@入力ﾁｪｯｸ
            lblnAns = prvblnInput_Chk(CMlngOrderInfo)
            '@結果判定
            If lblnAns = True Then
                '@ﾏｽﾀ工順選択時
                If optMster.Checked = True Then
                    '@ｴﾝﾄﾘID空白の場合確定ﾎﾞﾀﾝ押下不可
                    If lblEntryID.Text = vbNullString Then
                        '@確定ﾎﾞﾀﾝ押下不可
                        cmdRegist.Enabled = False
                        Exit Sub
                    End If
                End If
                '@投入予約ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
            Else
                '@投入予約ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False
            End If

            '@工順ｺﾋﾟｰﾛｯﾄIDが設定されている場合
            If txtCopyLotID.Text <> vbNullString Then
                '@次項目にﾌｫｰｶｽｾｯﾄ
                SendKeys.SendWait(CPstrSendKeysTab)
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdCopyLotID_Click"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：optNon_Click
    '機　能：工順なし選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:35:07 N.Kasai
    '更新日：2004/08/19 (Thu) 19:35:07
    '備　考：
    Private Sub optNon_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optNon.Click

        Dim lblnAns         As Boolean      '入力ﾁｪｯｸ結果格納(True:OK,False:NG)

        Try
            '@工順ｺﾋﾟｰ制御(無効)
            With txtCopyLotID
                .Enabled = False
                .BackColor = SystemColors.ControlLight
            End With
            
            '@工順ｺﾋﾟｰﾛｯﾄIDﾎﾞﾀﾝ制御(無効)
            With cmdCopyLotID
                .Enabled = False
            End With
            
            '@機種ｴﾝﾄﾘﾎﾞﾀﾝ使用不可
            cmdEntry.Enabled = False
            '@ｴﾝﾄﾘID使用不可
            
            lblEntryID.Enabled = False
            '@ｴﾝﾄﾘ名使用不可
            
            lblEntryName.Enabled = False
            
            '@入力ﾁｪｯｸ
            lblnAns = prvblnInput_Chk(CMlngOrderInfo)
            '@結果判定
            If lblnAns = True Then
                '@ﾏｽﾀ工順選択時
                If optMster.Checked = True Then
                    '@ｴﾝﾄﾘID空白の場合確定ﾎﾞﾀﾝ押下不可
                    If lblEntryID.Text = vbNullString Then
                        '@確定ﾎﾞﾀﾝ押下不可
                        cmdRegist.Enabled = False
                        Exit Sub
                    End If
                End If
                
                '@投入予約ﾎﾞﾀﾝ活性化
                cmdRegist.Enabled = True
            Else
                '@投入予約ﾎﾞﾀﾝ非活性化
                cmdRegist.Enabled = False
            End If
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "optNon_Click"               '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtOrderComment_Change
    '機　能：P/Rｵｰﾀﾞｰｺﾒﾝﾄ欄変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/07 (Mon) 13:58:23 T.Kitagawa
    '更新日：2006/08/07 (Mon) 13:58:23
    '備　考：
    Private Sub txtOrderComment_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtOrderComment.Change

        Try
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtOrderComment, CMlngMaxDispPrOrderRow, cmdCommentUp, cmdCommentDown)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtOrderComment_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtOrderComment_KeyUp
    '機　能：P/Rｵｰﾀﾞｰｺﾒﾝﾄﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｷｰ
    '戻り値：なし
    '作成日：2006/08/07 (Mon) 14:00:08 T.Kitagawa
    '更新日：2006/08/07 (Mon) 14:00:08
    '備　考：
    Private Sub txtOrderComment_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtOrderComment.KeyUp
        
        Try
            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtOrderComment, CMlngMaxDispPrOrderRow, cmdCommentUp, cmdCommentDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtOrderComment_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtOrderComment_MouseUp
    '機　能：P/Rｵｰﾀﾞｰｺﾒﾝﾄﾃｷｽﾄﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2006/08/07 (Mon) 14:06:49 T.Kitagawa
    '更新日：2006/08/07 (Mon) 14:06:49
    '備　考：
    Private Sub txtOrderComment_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtOrderComment.MouseUp

        Try
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtOrderComment, CMlngMaxDispPrOrderRow, cmdCommentUp, cmdCommentDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtOrderComment_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：cmdCommentUp_Click
    '機　能：P/Rｵｰﾀﾞｰｺﾒﾝﾄの前頁切替(▲ﾎﾞﾀﾝ)
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/07 (Mon) 14:07:33 T.Kitagawa
    '更新日：2006/08/07 (Mon) 14:07:33
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
            Call pubtxtCmdUp_Proc(txtOrderComment, CMlngMaxDispPrOrderRow, cmdCommentUp, cmdCommentDown)
            
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
    '機　能：P/Rｵｰﾀﾞｰｺﾒﾝﾄの次頁切替(▼ﾎﾞﾀﾝ)
    '引　数：なし
    '戻り値：なし
    '作成日：2006/08/07 (Mon) 14:08:26 T.Kitagawa
    '更新日：2006/08/07 (Mon) 14:08:26
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
            Call pubtxtCmdDown_Proc(txtOrderComment, CMlngMaxDispPrOrderRow, cmdCommentUp, cmdCommentDown)

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

    '関数名：txtWorkMemo_Change
    '機　能：ｺﾒﾝﾄ欄変更
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:41:04 N.Kasai
    '更新日：2005/12/02 (Fri) 10:16:55 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 10:16:55 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub txtWorkMemo_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtWorkMemo.Change

        Dim llngNowByte         As Integer      'ﾊﾞｲﾄ数
        
        Try
            '@ﾊﾞｲﾄ数格納
            llngNowByte = txtWorkMemo.NowByte
            
            '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
            lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            
        '@↓2005/12/02 (Fri) 10:16:52 N.Kasai **************************************************
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
        '@↑2005/12/02 (Fri) 10:16:52 N.Kasai **************************************************

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "txtWorkMemo_Change"         '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：txtWorkMemo_KeyUp
    '機　能：作業ﾒﾓｷｰﾎﾞｰﾄﾞ操作
    '引　数：KeyCode：ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄ
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:15:19 N.Kasai
    '更新日：2005/11/29 (Tue) 14:15:19
    '備　考：
    Private Sub txtWorkMemo_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtWorkMemo.KeyUp

        Try
            '@ﾃｷｽﾄｷｰﾎﾞｰﾄﾞ操作
            Call pubtxtKeyUp_Proc(e.KeyCode, txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
         
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtLotCommnt_KeyUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtWorkMemo_MouseUp
    '機　能：作業ﾒﾓﾏｳｽ操作
    '引　数：Button：ﾎﾞﾀﾝ
    '　　　：Shift：ｼﾌﾄ
    '　　　：X：x座標
    '　　　：Y：y座標
    '戻り値：なし
    '作成日：2005/11/29 (Tue) 14:52:24 N.Kasai
    '更新日：2005/11/29 (Tue) 14:52:24
    '備　考：
    Private Sub txtWorkMemo_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles txtWorkMemo.MouseUp

        Try
            '@ﾃｷｽﾄ変更処理
            Call pubtxtChange_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown, e.Button)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtWorkMemo_MouseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoUp_Click
    '機　能：作業メモの前頁切替
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:41:20 N.Kasai
    '更新日：2005/12/02 (Fri) 10:14:54 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 10:14:54 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdMemoUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoUp.Click
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/12/02 (Fri) 10:16:10 N.Kasai **************************************************
        '    '@作業ﾒﾓにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtWorkMemo)
        '    '@PageUpｷｰ
        '    SendKeys CPstrSendKeysPageUp, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝUP
            Call pubtxtCmdUp_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)
        '@↑2005/12/02 (Fri) 10:16:10 N.Kasai **************************************************

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdMemoUp_Click"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdMemoDown_Click
    '機　能：作業メモの次頁切替
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 19:41:33 N.Kasai
    '更新日：2005/12/02 (Fri) 10:15:33 N.Kasai
    '備　考：
    '　　　：2005/12/02 (Fri) 10:15:33 N.Kasai      ｽｸﾛｰﾙ連動
    Private Sub cmdMemoDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMemoDown.Click
        
        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
        '@↓2005/12/02 (Fri) 10:16:30 N.Kasai **************************************************
        '    '@作業ﾒﾓにﾌｫｰｶｽｾｯﾄ
        '    Call pubSetFocus(txtWorkMemo)
        '    '@PageDownｷｰ
        '    SendKeys CPstrSendKeysPageDown, True
            '@ﾃｷｽﾄｽｸﾛｰﾙﾎﾞﾀﾝDown
            Call pubtxtCmdDown_Proc(txtWorkMemo, CMlngMaxDispMemoRow, cmdMemoUp, cmdMemoDown)

        '@↑2005/12/02 (Fri) 10:16:30 N.Kasai **************************************************
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "cmdMemoDown_Click"          '処理名
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
    '関数名：prvfrmxxEN00X0_Init
    '機　能：画面初期値設定
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/17 (Tue) 17:17:50 N.Kasai
    '更新日：2008/06/11 (Wed) 13:44:43 N.Kojima
    '備　考：
    '　　　：2004/10/04 (Mon) 13:48:02 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理を追加
    '　　　：2005/06/28 (Tue) 09:09:58 S.Deguchi    重複設定＆不要設定見直し
    '　　　：2005/12/02 (Fri) 10:21:19 N.Kasai      ｽｸﾛｰﾙ連動
    '　　　：2006/08/07 (Mon) 14:19:29 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(案件№01362)
    '　　　：2006/11/01 (Wed) 14:56:42 N.Kasai      送品ｺﾝﾎﾞ追加(№01500)
    '　　　：2008/06/11 (Wed) 13:44:43 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvfrmxxEN00X0_Init()
        
        Dim lctlControl     As Control      'ｺﾝﾄﾛｰﾙ名称
        Dim llngNowByte     As Integer      'ﾊﾞｲﾄ数を格納
        Dim lstrFormTitle   As String       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        
        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00X0, lstrFormTitle)
            
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@初期値設定
            With Me
                .Height = CPlngAppliHeight
                .Width = CPlngAppliWideWidth
            End With
            
            '@退避用変数の初期化
            mstrProductID = vbNullString
            
            '@ｺﾝﾎﾞﾎﾞｯｸｽの初期化
            Dim all As Control() = GetAllControls(Me)
            For Each lctlControl In all
                '@ﾌｫｰﾑ上のｺﾝﾄﾛｰﾙに対して処理を行う
                If TypeOf lctlControl Is SEComboBoxEx.ComboBoxEx Then
                    '@ｺﾝﾄﾛｰﾙがComboBoxExの場合
                    With CType(lctlcontrol, SEComboBoxEx.ComboBoxEx)
                        '@ｺﾝﾎﾞﾎﾞｯｸｽ初期化
                        .BackColor = SystemColors.Window                    'ﾊﾞｯｸｶﾗｰ白
                        .DirectInput = False                                'ﾃｷｽﾄ直接入力
                        .DispCols = CMlngComboDispCols1                     '表示列数
                        .GetCol = CMlngComboGetCol                          '値取得列
                        With .Font                                          'ﾌｫﾝﾄｻｲｽﾞ
                             CType(lctlcontrol, SEComboBoxEx.ComboBoxEx).Font = New Font(.FontFamily, CMlngComboFontSize, .Style)
                        End With
                        With .GridFont                                      'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                             CType(lctlcontrol, SEComboBoxEx.ComboBoxEx).GridFont = New Font(.FontFamily, CMlngComboGridFontSize, .Style)
                        End With
                        .RowHeight = CMlngComboRowHeight                    '行高さ
                    End With
                End If
            Next
            
            '@基礎情報初期値設定
            '@新規ﾛｯﾄID採番
            optNew.Enabled = True                                               '新規ﾛｯﾄID採番ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optNew.Checked = True
            Call optNew_Click(optNew,New EventArgs())                           'NSYS 手動実行
            
            '@機種
            With cmbProduct
                RemoveHandler cmbProduct.Change,AddressOf cmbProduct_Change
                .ListIndex = -1                                                 '機種
                AddHandler cmbProduct.Change,AddressOf cmbProduct_Change
                .ColAlignment(CMlngComboGetCol) = CMlngComboAlignLeftCenter     '文字表示位置設定(左中央)
            End With
            
            '@種別
            With cmbDivision
                RemoveHandler cmbDivision.Change,AddressOf cmbDivision_Change
                .ListIndex = -1                                                 '種別
                AddHandler cmbDivision.Change,AddressOf cmbDivision_Change
                .ColAlignment(CMlngComboGetCol) = CMlngComboAlignLeftCenter     '文字表示位置設定(左中央)
            End With
            
            '@WF枚数欄
            txtWFNum.Text = vbNullString
            
            '@ｶﾚﾝﾀﾞｰ設定
            Call pubblnCalendar_Init(dtpStartDate, CPlngCalModeFlow)
            
            '@ﾛｯﾄ担当
            With cmbLotManager
                .ListIndex = -1                                                 'ｸﾘｱ
                .ColAlignment(CMlngComboGetCol) = CMlngComboAlignLeftCenter     '文字表示位置設定(左中央)
            End With
            
            '@P/Rｵｰﾀﾞｰ
            With cmbPrOrder
                RemoveHandler cmbPrOrder.Change,AddressOf cmbPrOrder_Change
                .ListIndex = -1                                                     'P/Rｵｰﾀﾞｰ
                AddHandler cmbPrOrder.Change,AddressOf cmbPrOrder_Change
                .ColAlignment(CMlngComboGetCol) = CMlngComboAlignLeftCenter         '文字表示位置設定(左中央)
            End With
            fraPrClass.Enabled = False                                              'P/R区分ﾌﾚｰﾑ
            optPrClass0.Enabled = False
            optPrClass1.Enabled = False
            optPrClass0.Checked = False                                             'P/R区分(未選択)
            optPrClass1.Checked = False                                             'P/R区分(未選択)
                    
            '@P/Rｵｰﾀﾞｰｺﾒﾝﾄ欄,ｽｸﾛｰﾙﾎﾞﾀﾝの初期化
            txtOrderComment.Text = vbNullString
            txtOrderComment.Enabled = False
            txtOrderComment.Locked = True
            cmdCommentUp.Enabled = False                                            'P/Rｵｰﾀﾞｰｺﾒﾝﾄ上ｽｸﾛｰﾙﾎﾞﾀﾝ
            cmdCommentDown.Enabled = False                                          'P/Rｵｰﾀﾞｰｺﾒﾝﾄ下ｽｸﾛｰﾙﾎﾞﾀﾝ
            
            '@工順作成ID採番
            optProcess.Enabled = True                                           '工順作成ID採番ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optProcess.Checked = False
            
            '@機種(User)
            With cmbUserProduct
                RemoveHandler cmbUserProduct.Change,AddressOf cmbUserProduct_Change
                .ListIndex = -1                                             '機種(user)
                AddHandler cmbUserProduct.Change,AddressOf cmbUserProduct_Change
                .ColAlignment(CMlngComboGetCol) = CMlngComboAlignLeftCenter '文字表示位置設定(左中央)
                .BackColor = SystemColors.ControlLight
                .Enabled = False
            End With
            
            '@ﾕｰｻﾞｰﾌﾟﾛｾｽID(User)
            With txtUserEntry                                                  'ﾕｰｻﾞﾌﾟﾛｾｽID
                .ChrMaxByte = 9                                                'Max入力：9文字
                .Text = vbNullString                                           'Null
                .BackColor = SystemColors.ControlLight                         '背景色：ｸﾞﾚｰ
                .Enabled = False                                               '非活性化
                .FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num '入力ﾓｰﾄﾞ：半角
                .IMEMode = ImeMode.Off                                         '入力ﾓｰﾄﾞ：全角変換なし
                .ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper  '入力ﾓｰﾄﾞ：大文字小文字設定なし
            End With
            
            '@ﾕｰｻﾞｰﾌﾟﾛｾｽ名(User)
            With txtUserEntryName                                           'ﾕｰｻﾞﾌﾟﾛｾｽ名
                .ChrMaxByte = 30
                .Text = vbNullString
                .BackColor = SystemColors.ControlLight
                .Enabled = False
            End With
            
            '@ﾛｯﾄ担当(ﾕｰｻﾞｰﾌﾟﾛｾｽ)
            With cmbUserLotManager
                .ListIndex = -1                                             'ｸﾘｱ
                .ColAlignment(CMlngComboGetCol) = CMlngComboAlignLeftCenter '文字表示位置設定(左中央)
                .BackColor = SystemColors.ControlLight
                .Enabled = False
            End With
                
            '@送品
            With cmbLotSend
                .ListIndex = -1                                                 '送品
                .ColAlignment(CMlngComboGetCol) = CMlngComboAlignLeftCenter     '文字表示位置設定(左中央)
            End With
            
            '@ﾛｯﾄ詳細情報
            optMster.Enabled = False                                            '機種ｴﾝﾄﾘｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optCopy.Enabled = False                                             '工順ｺﾋﾟｰｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optNon.Enabled = False                                              '工順なしｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            
            '@機種ｴﾝﾄﾘﾎﾞﾀﾝ使用不可
            cmdEntry.Enabled = False
            
            '@ｴﾝﾄﾘID使用不可
            lblEntryID.Enabled = False
            
            '@ｴﾝﾄﾘ名使用不可
            lblEntryName.Enabled = False
            
            '@工順ｺﾋﾟｰﾛｯﾄID
            With txtCopyLotID
                .Enabled = False                                                '非活性化
                .BackColor = SystemColors.ControlLight                          '背景色：ｸﾞﾚｰ
                .FormatMode = SETextBoxEx.TextBoxEx.typFormatMode.CP_Alpha_Num  '入力ﾓｰﾄﾞ：半角
                .ChrLowerUpper = SETextBoxEx.TextBoxEx.typLowerUpper.CP_Upper   '入力ﾓｰﾄﾞ：大文字
            End With
            
            '@工順ｺﾋﾟｰﾛｯﾄIDﾎﾞﾀﾝ
            cmdCopyLotID.Enabled = False
            
            '@ｺﾒﾝﾄ
            With txtWorkMemo
                .ChrMaxByte = CPlngLotCommentsMaxByte
                .Text = vbNullString
                '@現状のﾊﾞｲﾄ数を格納
                llngNowByte = .NowByte
                '@現在のﾊﾞｲﾄ数を表示(表示ﾒｯｾｰｼﾞ変換)
                lblLengthCount.Text = pubstrMsgReplace_Set(CPstrCommentLength, llngNowByte, CPlngLotCommentsMaxByte)
            End With
            
        '@↓2005/12/02 (Fri) 10:21:05 N.Kasai **************************************************
            cmdMemoUp.Enabled = False                   '作業ﾒﾓ頁UP
            cmdMemoDown.Enabled = False                 '作業ﾒﾓ頁DOWN
        '@↑2005/12/02 (Fri) 10:21:05 N.Kasai **************************************************
            
            '@登録ﾛｯﾄID
            lblLotID.Text = vbNullString
            
            '@投入予約のEnabled=False
            cmdRegist.Enabled = False
            
            '@閉じるﾎﾞﾀﾝのCausesValidationをFalse
            cmdClose.CausesValidation = False
            
            '@投入予定一覧ﾎﾞﾀﾝのCausesValidationをFalse
            cmdPlanList.CausesValidation = False

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvfrmxxEN00X0_Init"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvstrClassDivision_Cal
    '機　能：処理区分設定
    '引　数：なし
    '戻り値：処理区分設定値
    '作成日：2004/08/19 (Thu) 09:39:06 N.Kasai
    '更新日：2004/08/19 (Thu) 09:39:06
    '備　考：
    Private Function prvstrClassDivision_Cal() As String
        
        Dim lstrKbn         As String       '処理区分 0M0Q:新規/ﾛｯﾄ工順、0MOR:新規/ﾏｽﾀ工順、0MOS:新規/工順なし

        Try

            '@変数初期化
            lstrKbn = vbNullString
            
            '@工順作成基礎情報判定
            Select Case True
                '@基礎情報指定の場合
                Case optNew.Checked
                    lstrKbn = CPstrCD0M
                '@工順作成ID採番の場合
                Case optProcess.Checked
                    '@付加情報なし
            End Select
            
            '@ﾛｯﾄ詳細情報指定の場合
            Select Case True
                '@工順ｺﾋﾟｰ
                Case optCopy.Checked
                    lstrKbn = lstrKbn & CPstrCD0Q
                '@ﾏｽﾀ工順
                Case optMster.Checked
                    lstrKbn = lstrKbn & CPstrCD0R
                '@工順なし
                Case optNon.Checked
                    lstrKbn = lstrKbn & CPstrCD0S
            End Select
            
            '@編集結果
            prvstrClassDivision_Cal = Trim(lstrKbn)
            
            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvstrClassDivision_Cal"    '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvblnInput_Chk
    '機　能：入力状況ﾁｪｯｸ(ﾛｯﾄ作成基礎情報)
    '引　数：llngCheckFlg：ﾁｪｯｸﾌﾗｸﾞ(1:基礎情報,2:工順作成採番)
    '戻り値：True:OK/False:NG
    '作成日：2004/08/19 (Thu) 19:50:34 N.Kasai
    '更新日：2008/06/11 (Wed) 13:39:39 N.Kojima
    '備　考：
    '　　　：2006/08/07 (Mon) 14:32:39 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(案件№01362)
    '　　　：2008/06/11 (Wed) 13:39:39 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Function prvblnInput_Chk(ByVal llngCheckFlg As Integer) As Boolean

        Dim lstrStartDT             As String       '投入予定日
        Dim lstrNowDT               As String       'ｼｽﾃﾑ日付
        
        Try
            
            '@初期化
            prvblnInput_Chk = True
            
            '@生成ﾛｯﾄID表示のｸﾘｱ
            lblLotID.Text = vbNullString
            
            Select Case llngCheckFlg
                '@工順作成基礎情報の入力ﾁｪｯｸ
                Case CMlngCreateInfo
                    Select Case True
                        '@新規ﾛｯﾄ採番ﾁｪｯｸ
                        Case optNew.Checked
                            '@機種ﾁｪｯｸ
                            If cmbProduct.Value = vbNullString Then
                                '@入力ﾁｪｯｸ=False
                                prvblnInput_Chk = False
                                '@ﾛｯﾄ工順情報使用不可処理へ
                                Call prvLotOrderListFalse_Set()
                                Exit Function
                            End If
                
                            '@種別ﾁｪｯｸ
                            If cmbDivision.Value = vbNullString Then
                                '@入力ﾁｪｯｸ=False
                                prvblnInput_Chk = False
                                '@ﾛｯﾄ工順情報使用不可処理へ
                                Call prvLotOrderListFalse_Set()
                                Exit Function
                            End If
                
                            '@WF枚数ﾁｪｯｸ
                            If txtWFNum.Text = vbNullString Or txtWFNum.Text = CMstrWFDefault Then
                                '@入力ﾁｪｯｸ=False
                                prvblnInput_Chk = False
                                '@ﾛｯﾄ工順情報使用不可処理へ
                                Call prvLotOrderListFalse_Set()
                                Exit Function
                            End If
                
                            '@本日日付を取得
                            lstrNowDT = Format$(Now(), CPstrDateTimeYMD)
                            '@日付ﾁｪｯｸ
                            If IsDate(dtpStartDate.Value) = True Then
                                '@投入予定日ﾁｪｯｸ
                                lstrStartDT = Format$(CDate(dtpStartDate.Value), CPstrDateTimeYMD)

                                '@過去日付ﾁｪｯｸ
                                If lstrStartDT < lstrNowDT Then
                                    '@入力ﾁｪｯｸ=False
                                    prvblnInput_Chk = False
                                    '@ﾛｯﾄ工順情報使用不可処理へ
                                    Call prvLotOrderListFalse_Set()
                                    Exit Function
                                End If
                            Else
                                '@入力ﾁｪｯｸ=False
                                prvblnInput_Chk = False
                                '@ﾛｯﾄ工順情報使用不可処理へ
                                Call prvLotOrderListFalse_Set()
                                Exit Function
                            End If
                
                            '@ﾛｯﾄ担当がNULLか
                            If cmbLotManager.Value = vbNullString Then
                                '@入力ﾁｪｯｸ=False
                                prvblnInput_Chk = False
                                '@ﾛｯﾄ工順情報使用不可処理へ
                                Call prvLotOrderListFalse_Set()
                                Exit Function
                            End If
                        
                            '@P/Rｵｰﾀﾞｰﾁｪｯｸ
                            If cmbPrOrder.Enabled = True And cmbPrOrder.Value = vbNullString Then
                                '@入力ﾁｪｯｸ=False
                                prvblnInput_Chk = False
                                '@ﾛｯﾄ工順情報使用不可処理へ
                                Call prvLotOrderListFalse_Set()
                                Exit Function
                            End If
                        
                        '@工順作成採番ﾁｪｯｸ
                        Case optProcess.Checked
                            '@機種(user)ﾁｪｯｸ
                            cmbUserProduct.ValueCol = CMlngComboGetCol
                            If cmbUserProduct.Value = vbNullString Then
                                '@入力ﾁｪｯｸ=False
                                prvblnInput_Chk = False
                                '@ﾛｯﾄ工順情報使用不可処理へ
                                Call prvLotOrderListFalse_Set()
                                Exit Function
                            End If
                        
                            '@ﾕｰｻﾞﾌﾟﾛｾｽID入力ﾁｪｯｸ
                            If txtUserEntry.Text = vbNullString Then
                                '@入力ﾁｪｯｸ=False
                                prvblnInput_Chk = False
                                '@ﾛｯﾄ工順情報使用不可処理へ
                                Call prvLotOrderListFalse_Set()
                                Exit Function
                            End If

                            '@ﾕｰｻﾞﾌﾟﾛｾｽ名入力ﾁｪｯｸ
                            If txtUserEntryName.Text = vbNullString Then
                                '@入力ﾁｪｯｸ=False
                                prvblnInput_Chk = False
                                '@ﾛｯﾄ工順情報使用不可処理へ
                                Call prvLotOrderListFalse_Set()
                                Exit Function
                            End If

                            '@ﾛｯﾄ担当(ﾕｰｻﾞｰﾌﾟﾛｾｽ)ﾁｪｯｸ
                            If cmbUserLotManager.Value = vbNullString Then
                                '@入力ﾁｪｯｸ=False
                                prvblnInput_Chk = False
                                '@ﾛｯﾄ工順情報使用不可処理へ
                                Call prvLotOrderListFalse_Set()
                                Exit Function
                            End If
                            
                        Case Else
                            '@入力ﾁｪｯｸ=False
                             prvblnInput_Chk = False
                            '@ﾛｯﾄ工順情報使用不可処理へ
                            Call prvLotOrderListFalse_Set()
                            Exit Function
                    End Select
                    
                    '@ﾛｯﾄ工順情報使用処理へ
                    Call prvLotOrderListTrue_Set()
                    
                '@ﾛｯﾄ詳細情報の入力ﾁｪｯｸ
                Case CMlngOrderInfo
                    '@ｺﾋﾟｰﾛｯﾄIDﾁｪｯｸ
                    If optCopy.Checked = True Then
                        '@ｺﾋﾟｰﾛｯﾄIDの入力ﾁｪｯｸ
                        If txtCopyLotID.Text = vbNullString Then
                            '@入力ﾁｪｯｸ=False
                            prvblnInput_Chk = False
                            Exit Function
                        End If
                    
                        '@ｺﾋﾟｰﾛｯﾄID桁数ﾁｪｯｸ
                        If Len(txtCopyLotID.Text) = 0 Then
                            '@入力ﾁｪｯｸ=False
                            prvblnInput_Chk = False
                            Exit Function
                        End If
                    End If

                    '@ﾏｽﾀ工順ﾁｪｯｸ
                    If optMster.Checked = True Then
                        '@ﾊﾞｰｼﾞｮﾝ手動変更対応
                        If lblEntryID.Text = vbNullString Then
                            '@入力ﾁｪｯｸ=False
                            prvblnInput_Chk = False
                            Exit Function
                        End If
                    End If

                    '@工順なしﾁｪｯｸ
                    If optNon.Checked = True Then
                        '@入力ﾁｪｯｸ=False
                        prvblnInput_Chk = True
                        Exit Function
                    End If
            End Select

            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnInput_Chk"            '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnLotReserve_Chk
    '機　能：投入予約時の画面項目ﾁｪｯｸ(確定ﾎﾞﾀﾝﾁｪｯｸ)
    '引　数：なし
    '戻り値：True：項目正常、False：不正項目あり
    '作成日：2004/08/19 (Thu) 19:54:19 N.Kasai
    '更新日：2008/06/11 (Wed) 13:39:59 N.Kojima
    '備　考：
    '　　　：2006/08/07 (Mon) 14:37:27 T.Kitagawa   P/Rｵｰﾀﾞｰ必須選択処理を追加(案件№01362)
    '　　　：2008/06/11 (Wed) 13:39:59 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Function prvblnLotReserve_Chk() As Boolean

        Dim lstrStartDT             As String       '投入予定日
        Dim lstrNowDT               As String       'システム日付
        
        Try
            
            prvblnLotReserve_Chk = False
                
            '@新規ﾛｯﾄ採番ﾁｪｯｸ
            If optNew.Checked = True Then
                '@機種ﾁｪｯｸ
                If cmbProduct.Value = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0013)
                    '@"機種が指定されていません。機種を指定してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Call pubSetFocus(cmbProduct)
                    Exit Function
                End If
                
                '@種別ﾁｪｯｸ
                If cmbDivision.Value = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0014)
                    '@"種別が指定されていません。種別を指定してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Call pubSetFocus(cmbDivision)
                    Exit Function
                End If
                
                '@WF枚数ﾁｪｯｸ
                If txtWFNum.Text = vbNullString Or _
                   txtWFNum.Text = CMstrWFDefault Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0015)
                    '@"WF枚数を指定して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Call pubSetFocus(txtWFNum)
                    Exit Function
                End If
                
                '@本日日付を取得
                lstrNowDT = Format$(Now(), CPstrDateTimeYMD)
                '@日付ﾁｪｯｸ
                If IsDate(dtpStartDate.Value) = True Then
                    '@投入予定日ﾁｪｯｸ
                    lstrStartDT = Format$(CDate(dtpStartDate.Value), CPstrDateTimeYMD)
                    '@過去日付ﾁｪｯｸ
                    If lstrStartDT < lstrNowDT Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0010)
                        '@"過去日付は指定できません。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        Call pubSetFocus(dtpStartDate)
                        Exit Function
                    End If
                Else
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0016)
                    '@"設定されていない項目があります。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Call pubSetFocus(dtpStartDate)
                End If
                
                '@ﾛｯﾄ担当がNULLか
                If cmbLotManager.Value = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0017)
                    '@"ﾛｯﾄ担当を指定して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Call pubSetFocus(cmbLotManager)
                    Exit Function
                End If
            
                '@P/Rｵｰﾀﾞｰﾁｪｯｸ
                If cmbPrOrder.Enabled = True And cmbPrOrder.Value = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar007L)
                    '@"<TRM7LW>$$P/Rオーダーが設定されていません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Call pubSetFocus(cmbPrOrder)
                    Exit Function
                End If
            
            End If
            
            '@工順作成ﾛｯﾄ採番ﾁｪｯｸ
            If optProcess.Checked = True Then
                '@機種ﾁｪｯｸ(user)
                cmbUserProduct.ValueCol = CMlngComboGetCol
                If cmbUserProduct.Value = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0013)
                    '@"機種が指定されていません。機種を指定してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Call pubSetFocus(cmbUserProduct)
                    Exit Function
                End If
                '@ﾛｯﾄ担当(ﾕｰｻﾞｰﾌﾟﾛｾｽ)ﾁｪｯｸ
                If cmbUserLotManager.Value = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0017)
                    '@"ﾛｯﾄ担当を指定して下さい。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Call pubSetFocus(cmbUserLotManager)
                    Exit Function
                End If
                '@ﾕｰｻﾞﾌﾟﾛｾｽID
                If txtUserEntry.Text = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0016)
                    '@"設定されていない項目があります。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Call pubSetFocus(txtUserEntry)
                    Exit Function
                End If
                '@ﾕｰｻﾞﾌﾟﾛｾｽ名
                If txtUserEntryName.Text = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0016)
                    '@"設定されていない項目があります。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Call pubSetFocus(txtUserEntryName)
                    Exit Function
                End If
            End If
            
            '@ｺﾋﾟｰﾛｯﾄIDﾁｪｯｸ
            If optCopy.Checked = True Then
                If txtCopyLotID.Text = vbNullString Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0016)
                    '@"設定されていない項目があります。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Call pubSetFocus(txtCopyLotID)
                    Exit Function
                End If
                '@桁数ﾁｪｯｸ
                If Len(txtCopyLotID.Text) <> CMlngLotIDByte Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0012)
                    '"ﾛｯﾄIDは10桁で入力してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    Call pubSetFocus(txtCopyLotID)
                    Exit Function
                End If
                
                '@ﾏｽﾀ工順削除
                mtypLotReserve.strMasVer = vbNullString

                '@ｺﾋﾟｰ元ﾛｯﾄｾｯﾄ
                mtypLotReserve.strCopySeqLotID = txtCopyLotID.Text
                
            End If
            
            '@ﾏｽﾀ工順ﾁｪｯｸ
            If optMster.Checked = True Then
                '@ﾊﾞｰｼﾞｮﾝ手動変更対応
                mtypLotReserve.strMasVer = lblEntryID.Text
                If mtypLotReserve.strMasVer = vbNullString Then
                
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0016)
                
                    '@"設定されていない項目があります。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    Exit Function
                End If
                '@ｺﾋﾟｰﾛｯﾄID削除
                mtypLotReserve.strCopySeqLotID = vbNullString
            End If
            
            prvblnLotReserve_Chk = True
            
            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvblnLotReserve_Chk"       '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvLotOrderListTrue_Set
    '機　能：ﾛｯﾄ詳細情報使用処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 20:04:34 N.Kasai
    '更新日：2004/08/19 (Thu) 20:04:34
    '　　　：2008/09/24 (Wed) 17:34:01 T.Sawaguchi 　新規登録の場合は工順無しは設定不可とする(案件03133)
    '備　考：
    Private Sub prvLotOrderListTrue_Set()
        
        Try
            
            '@ﾛｯﾄ工順情報はﾛｯﾄ作成基礎情報が選択、入力されるまで全て無効
            
            '@工順ｺﾋﾟｰ
            optCopy.Enabled = True                      '工順ｺﾋﾟｰｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            With txtCopyLotID                           'ﾛｯﾄID
                .Enabled = False
                .BackColor = SystemColors.ControlLight
            End With
            cmdCopyLotID.Enabled = False                '工順ｺﾋﾟｰﾛｯﾄIDﾎﾞﾀﾝ
            
            '@ﾏｽﾀ工順
            optMster.Enabled = True                     'ﾏｽﾀ工順ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optMster.Checked = True
            Call optMster_Click(optMster,New EventArgs()) 'NSYS 手動実行
            cmdEntry.Enabled = True                     '機種ｴﾝﾄﾘﾎﾞﾀﾝ
            '@ｴﾝﾄﾘID使用可
            lblEntryID.Enabled = True
            '@ｴﾝﾄﾘ名使用可
            lblEntryName.Enabled = True
            
        '@↓2008/09/24 (Wed) 17:34:01 T.Sawaguchi 案件03133 **************************
            '@新規登録の場合は工順無しは設定できない様にする。
            '@工順なし
            If optProcess.Checked = True Then
                optNon.Enabled = True                       '工順なしｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            End If
        '@↑2008/09/24 (Wed) 17:34:01 T.Sawaguchi 案件03133 **************************

            '@登録ﾛｯﾄID
            lblLotID.Text = vbNullString
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvLotOrderListTrue_Set"    '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvLotOrderListFalse_Set
    '機　能：ﾛｯﾄ詳細情報使用不可処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 20:06:57 N.Kasai
    '更新日：2004/08/19 (Thu) 20:06:57
    '備　考：
    Private Sub prvLotOrderListFalse_Set()
        
        Try
            
            '@ﾛｯﾄ工順情報無効
            '@工順ｺﾋﾟｰ
            optCopy.Enabled = False                             '工順ｺﾋﾟｰｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optCopy.Checked = False
            With txtCopyLotID                                   'ﾛｯﾄID
                .Text = vbNullString
                .Enabled = False
                .BackColor = SystemColors.ControlLight
            End With
            cmdCopyLotID.Enabled = False                        '工順ｺﾋﾟｰﾛｯﾄIDﾎﾞﾀﾝ
            
            '@ﾏｽﾀ工順
            optMster.Enabled = False                            'ﾏｽﾀ工順ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            optMster.Checked = False
            '@機種ｴﾝﾄﾘﾎﾞﾀﾝ使用不可
            cmdEntry.Enabled = False
            '@ｴﾝﾄﾘID使用不可
            lblEntryID.Enabled = False
            '@ｴﾝﾄﾘ名使用不可
            lblEntryName.Enabled = False
            
            '@工順なし
            optNon.Enabled = False                              '工順なしｵﾌﾟｼｮﾝﾎﾞﾀﾝ
            
            '@登録ﾛｯﾄID
            lblLotID.Text = vbNullString
            
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvLotOrderListFalse_Set"   '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvmasEntryList_Sel
    '機　能：ﾛｯﾄ工順情報取得処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 20:09:17 N.Kasai
    '更新日：2004/09/02 (Thu) 10:02:05 Y.Yamagishi
    '備　考：2004/09/02 (Thu) 10:02:05 Y.Yamagishi  WF枚数取得
    Private Sub prvMasEntryList_Sel()

        Dim lblnAns                     As Boolean            '戻り値(True/False)
        Dim ltypEntryList               As List(Of EntryList) 'ﾏｽﾀ工順取得構造体
        Dim llngEntryListCnt            As Integer            'ﾏｽﾀ工順取得件数
        Dim lstrProductID               As String             'ﾛｰｶﾙ機種変数格納
        Dim lstrClassDivision           As String             '処理区分

        Try
            
            '@機種設定
            Select Case True
                '@基礎情報
                Case optNew.Checked
                    lstrProductID = cmbProduct.Text
                
                '@工順作成ID
                Case optProcess.Checked
                    lstrProductID = cmbUserProduct.Text
            End Select
            
            '@機種指定確認
            If lstrProductID = vbNullString Then
                Exit Sub
            Else
                '@機種が退避領域と同じでｴﾝﾄﾘIDが空白以外の場合
                If lstrProductID = mstrProductID And lblEntryID.Text <> vbNullString Then
                    '@処理を抜ける
                    Exit Sub
                Else
                    '@機種ｴﾝﾄﾘ取得
                    lstrClassDivision = CPstrCD07   'ClassDivision 07:ｴﾝﾄﾘIDの適用日が最新のものを検索する
                    lblnAns = pubblnmasPdEntryList_Sel(CMstrmas_pdentrylistVer, _
                                                       lstrProductID, _
                                                       ltypEntryList, _
                                                       llngEntryListCnt, _
                                                       pstrSBID, _
                                                       lstrClassDivision)
                    '@結果判定
                    If lblnAns = False Then
                        Exit Sub
                    End If
                End If
            End If
                    
            '@機種ｴﾝﾄﾘが取得できた場合のみ(最新の機種ｴﾝﾄﾘ情報が１件返ってくる)
            If llngEntryListCnt <> 0 Then
                '@ｴﾝﾄﾘID表示処理
                lblEntryID.Text = ltypEntryList(llngEntryListCnt - 1).strEntryID
                
                '@ﾏｽﾀ工順表示処理(最新の機種ｴﾝﾄﾘ情報が１件返ってくる)
                lblEntryName.Text = ltypEntryList(llngEntryListCnt - 1).strEntryName
                
                If optNew.Checked = True Then
                '@基礎情報が選択されている場合
                    '@ｴﾝﾄﾘに紐付く最大WF枚数を退避
                    mlngPdEntryMaxWFCount = ltypEntryList(llngEntryListCnt - 1).strMaxWFCount
                    
                    '@WF枚数に値をｾｯﾄする
                    txtWFNum.Text = ltypEntryList(llngEntryListCnt - 1).strMaxWFCount
                Else
                '@工順作成ID採番が選択されている場合
                    '@機種名退避
                    mstrProductID = cmbUserProduct.Text
                End If
            End If
                    
            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvmasEntryList_Sel"        '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
                    
        End Try
    End Sub

    '関数名：prvcmbProductList_Disp
    '機　能：機種ｺﾝﾎﾞ表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/06/20 (Mon) 13:56:17 S.Deguchi
    '更新日：2005/07/26 (Tue) 10:08:56 N.Kasai
    '備　考：
    '　　　：2005/07/26 (Tue) 10:08:56 N.Kasai      L/R色表示追加
    Private Sub prvcmbProductList_Disp()

        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ
        
        Try
            
            '@機種名設定
            If mlngProductCnt > 0 Then
                '@配列要素数設定
                For llngCnt = 0 To mlngProductCnt - 1
                '@ｺﾝﾎﾞﾎﾞｯｸｽ設定
                    '@取得した値が数値であるか判定
                    If IsNumeric(mtypProductList(llngCnt).strMaxWFCount) = True Then
                        '@MaxWF枚数を比較する。
                        If CLng(mtypProductList(llngCnt).strMaxWFCount) > CMlngMaxWfCount Then
                            '@最大WF枚数が25枚以上の場合、最大WF枚数にNullStringを入れる
                            Dim mtypProductListTmp As ProductList = mtypProductList(llngCnt)
                            mtypProductListTmp.strMaxWFCount = vbNullString 
                            mtypProductList(llngCnt) = mtypProductListTmp

                        End If
                    End If
                    
        '@↓2005/07/26 (Tue) 10:08:43 N.Kasai **************************************************
        '            '@機種ｺﾝﾎﾞ格納
        '            cmbProduct.AddItem mtypProductList(llngCnt).strProductID _
        '                             & vbTab _
        '                             & mtypProductList(llngCnt).strMaxWFCount
        '
        '            '@機種(user)ｺﾝﾎﾞ格納
        '            cmbUserProduct.AddItem mtypProductList(llngCnt).strProductID _
        '                                 & vbTab _
        '                                 & mtypProductList(llngCnt).strMaxWFCount
                
                    '@機種ｺﾝﾎﾞ格納
                    cmbProduct.AddItem(mtypProductList(llngCnt).strProductID _
                                        & vbTab _
                                        & mtypProductList(llngCnt).strMaxWFCount _
                                        & vbTab _
                                        & vbNullString _
                                        & vbTab _
                                        & vbNullString _
                                        & vbTab _
                                        & mtypProductList(llngCnt).strForeColor _
                                        & vbTab _
                                        & mtypProductList(llngCnt).strBackColor)
                    
                    '@機種(user)ｺﾝﾎﾞ格納
                    cmbUserProduct.AddItem(mtypProductList(llngCnt).strProductID _
                                        & vbTab _
                                        & mtypProductList(llngCnt).strMaxWFCount _
                                        & vbTab _
                                        & vbNullString _
                                        & vbTab _
                                        & vbNullString _
                                        & vbTab _
                                        & mtypProductList(llngCnt).strForeColor _
                                        & vbTab _
                                        & mtypProductList(llngCnt).strBackColor)
        '@↑2005/07/26 (Tue) 10:08:43 N.Kasai **************************************************

                
                Next

                '@機種が１件の場合は表示
                With cmbProduct
                    If .ListCount = 1 Then
                        .ListIndex = 0
                    End If
                End With
            End If

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmbProductList_Disp"     '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmbLotManagerList_Disp
    '機　能：ﾛｯﾄ担当ｺﾝﾎﾞ作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/06/20 (Mon) 14:05:47 S.Deguchi
    '更新日：2008/06/11 (Wed) 13:40:57 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 13:40:57 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvCmbLotManagerList_Disp()

        Dim llngCnt         As Integer      '汎用ｶｳﾝﾀ
        
        Try
            
            With cmbLotManager
            
                '取得件数判定
                If mlngLotManagerListCnt > 0 Then
                    
                    For llngCnt = 0 To mlngLotManagerListCnt - 1
                        
                        '@ﾛｯﾄ担当ｺﾝﾎﾞ格納
                        .AddItem(mtypLotManagerList(llngCnt).strTechManName _
                                & vbTab _
                                & mtypLotManagerList(llngCnt).strTechManID)
                        
                        '@ﾛｯﾄ担当(ﾕｰｻﾞｰﾌﾟﾛｾｽ)ｺﾝﾎﾞ格納
                        cmbUserLotManager.AddItem(mtypLotManagerList(llngCnt).strTechManName _
                                             & vbTab _
                                             & mtypLotManagerList(llngCnt).strTechManID)
                    Next
                    
                    '@ﾛｯﾄ担当が1件の場合は表示
                    If .ListCount = 1 Then
                        .ListIndex = 0
                    End If
                End If
            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvCmbLotManagerList_Disp"  '処理名
                .strErrMessage = vbNullString               'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbLotSend_Set
    '機　能：送品ｺﾝﾎﾞ設定
    '引　数：なし
    '戻り値：なし
    '作成日：2006/10/31 (Tue) 13:28:23 N.Kasai
    '更新日：2006/10/31 (Tue) 13:28:23
    '備　考：
    Private Sub prvCmbLotSend_Set()

        Try

            '@ｺﾝﾎﾞ作成
            With cmbLotSend
                .ValueCol = 1
                .AddItem(CPstrNasiFlg & vbTab & CPlngLotSendNasi)
                .AddItem(CPstrAriFlg & vbTab & CPlngLotSendAri)
                .ListIndex = 1  '送品あり(初期値)
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbLotSend_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbLotSend_Disp
    '機　能：送品ｺﾝﾎﾞ強制設定
    '引　数：lstrFlowClass：種別
    '戻り値：なし
    '作成日：2006/10/31 (Tue) 14:51:33 N.Kasai
    '更新日：2006/10/31 (Tue) 14:51:33
    '備　考：
    Private Sub prvCmbLotSend_Disp(ByVal lstrFlowClass As String)

        Try
            
            If lstrFlowClass = vbNullString Then
                Exit Sub
            End If
            
            Select Case lstrFlowClass
                
                '@ﾀﾞﾐｰ、ﾓﾆﾀ、品格
                Case CPstrFillerDummy, CPstrSideDummy, CPstrExtraDummy, CPstrFlowClassMO, CPstrFlowClassQU
                    '@送品なし固定
                    With cmbLotSend
                        .Enabled = False
                        .ListIndex = 0
                    End With
                
                '@量産
                Case CPstrFlowClassPR
                    '@送品あり固定
                    With cmbLotSend
                        .Enabled = False
                         .ListIndex = 1
                    End With
                
                '@その他大勢
                Case Else
                    '@ｺﾝﾎﾞ使用可能
                    cmbLotSend.Enabled = True
            End Select
                
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbLotSend_Disp"
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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraCopy.Paint, fraMster.Paint, fraNew.Paint, fraNon.Paint, fraUserEntry.Paint

        ' ObjectをGroupBoxに変換
        Dim groupboxObj As GroupBox
        groupboxObj = CType(sender, GroupBox)
        ' GroupBoxの枠線を描画
        groupBoxLinePrint(groupboxObj, e, SystemColors.ControlDark, Me)
    End Sub

End Class
