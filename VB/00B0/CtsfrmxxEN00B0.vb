'ﾌｧｲﾙ名：xxEN00B0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：CFロット編成　メインフォーム
'作成日：2004/06/14 (Mon) 12:34:15 S.Deguchi
'更新日：2012/02/06 (Mon) 10:37:32 T.Oide
'備　考：ｼｽﾃﾑﾌﾞﾛｯｸは、「2AO」を使用する
'　　　：2004/11/24 (Wed) 13:41:41 S.Deguchi    画面に技術担当者選択ｺﾝﾎﾞを追加(不具合改善№237)
'　　　：2005/11/18 (Fri) 13:59:05 S.Deguchi    不具合№3257の対応でﾘﾜｰｸの表示形式を変更
'　　　：2011/04/26 (Tue) 11:12:37 T.Oide       CHR0001319 QUを組立に送品可能にする
'　　　：2012/01/20 (Fri) 09:32:34 T.Oide       REQ-1115 不良と払出の区分け
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Imports SETextBoxEx
Imports SEComboBoxEx
Public Class frmxxEN00B0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN00B0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN00B0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN00B0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN00B0)
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
    '@機能ﾊﾞｰｼﾞｮﾝ
    '@↓2012/01/24 (Tue) 11:48:56 T.Oide **************************************************
    'Private Const CMstrLocalVersion                     As String = "13.01"
    Private Const CMstrLocalVersion                     As String = "13.02"
    '@↑2012/01/24 (Tue) 11:48:56 T.Oide **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN00B0          'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrcarrcurstateVer                  As String = "05.02"                 'ｷｬﾘｱ状態確認
    Private Const CMstrlot_cfthrowinVer                 As String = "05.00"                 'CFﾛｯﾄ編成
    Private Const CMstrinv_partlistVer                  As String = "02.00"                 '部材一覧取得
    Private Const CMstrmas_partlistVer                  As String = "03.00"                 '部材ﾘｽﾄ
    '@↓2011/05/09 (Mon) 10:14:02 T.Oide **************************************************
    'Private Const CMstrmas_pdlist__Ver              As String = "02.02"                     '機種区分一覧取得
    Private Const CMstrmas_pdlist__Ver              As String = "03.00"                     '機種区分一覧取得
    '@↑2011/05/09 (Mon) 10:14:02 T.Oide **************************************************
    Private Const CMstrmas_pdentrylistVer               As String = "03.00"                 'ﾏｽﾀ工順一覧
    Private Const CMstrmas_screenlistVer                As String = "02.00"                 '画面ｻｲｽﾞﾏｽﾀ取得
    Private Const CMstrmas_thicklistVer                 As String = "01.00"                 '板厚区分取得
    Private Const CMstrmas_vendclasslistVer             As String = "02.00"                 'ﾍﾞﾝﾀﾞｰｸﾗｽﾘｽﾄ取得
    Private Const CMstrmas_emplist_Ver                  As String = "02.00"                 '作業者ﾘｽﾄ取得
    Private Const CMstrmas_wplist__Ver                  As String = "05.01"                 '装置一覧取得

    '@その他
    Private Const CMstrThrowineq_type                   As String = "13"                    'EQ_TYPE(投入装置=13)

    '@vsfPartLotListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfPartLLColNo                   As Integer = 0                      '№
    Private Const CMlngvsfPartLLColCFLotID              As Integer = 1                      '出荷ID
    Private Const CMlngvsfPartLLColPrLotID              As Integer = 2                      '製造ﾛｯﾄID
    Private Const CMlngvsfPartLLColBoardThickness       As Integer = 3                      '板厚
    Private Const CMlngvsfPartLLColRegeneration         As Integer = 4                      'ﾘﾜｰｸ回数
    Private Const CMlngvsfPartLLColNum                  As Integer = 5                      '枚数
    Private Const CMlngvsfPartLLColStockID              As Integer = 6                      '在庫ID

    '@vsfPartLotListの定数宣言(幅)
    Private Const CMlngvsfPartLLWColNo                  As Integer = 33                     '№
    Private Const CMlngvsfPartLLWColCFLotID             As Integer = 110                    '出荷ID
    Private Const CMlngvsfPartLLWColPrLotID             As Integer = 110                    '製造ﾛｯﾄID
    Private Const CMlngvsfPartLLWColBoardThickness      As Integer = 33                     '板厚
    Private Const CMlngvsfPartLLWColRegeneration        As Integer = 47                     'ﾘﾜｰｸ回数
    Private Const CMlngvsfPartLLWColNum                 As Integer = 87                     '枚数
    Private Const CMlngvsfPartLLWColStockID             As Integer = 65                     '在庫ID

    '@vsfPartLotListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfPartLLColNo                   As String = "№"                    '№
    Private Const CMstrvsfPartLLColCFLotID              As String = "出荷ロットID"          '出荷ID
    Private Const CMstrvsfPartLLColPrLotID              As String = "製造ロットID"          '製造ﾛｯﾄID
    Private Const CMstrvsfPartLLColBoardThickness       As String = "厚"                    '板厚
    Private Const CMstrvsfPartLLColRegeneration         As String = "ﾘﾜｰｸ"                  'ﾘﾜｰｸ回数
    Private Const CMstrvsfPartLLColNum                  As String = "枚数"                  '枚数
    Private Const CMstrvsfPartLLColStockID              As String = "在庫ID"                '在庫ID

    '@vsfPaletteListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfPaletteLColNo                 As Integer = 0                      'ｽﾛｯﾄ
    Private Const CMlngvsfPaletteLColPaletteID          As Integer = 1                      'ﾊﾟﾚｯﾄID
    Private Const CMlngvsfPaletteLColCFLotID            As Integer = 2                      '出荷ID
    Private Const CMlngvsfPaletteLColPrLotID            As Integer = 3                      '製造ﾛｯﾄID
    Private Const CMlngvsfPaletteLColBoardThickness     As Integer = 4                      '板厚
    Private Const CMlngvsfPaletteLColRegeneration       As Integer = 5                      'ﾘﾜｰｸ回数
    Private Const CMlngvsfPaletteLColNum                As Integer = 6                      '枚数
    Private Const CMlngvsfPaletteLColStockID            As Integer = 7                      '在庫ID

    '@vsfPaletteListの定数宣言(幅)
    Private Const CMlngvsfPaletteLWColNo                As Integer = 33                     'ｽﾛｯﾄ
    Private Const CMlngvsfPaletteLWColPaletteID         As Integer = 67                     'ﾊﾟﾚｯﾄID
    Private Const CMlngvsfPaletteLWColCFLotID           As Integer = 110                    '出荷ID
    Private Const CMlngvsfPaletteLWColPrLotID           As Integer = 110                    '製造ﾛｯﾄID
    Private Const CMlngvsfPaletteLWColBoardThickness    As Integer = 33                     '板厚
    Private Const CMlngvsfPaletteLWColRegeneration      As Integer = 46                     'ﾘﾜｰｸ回数
    Private Const CMlngvsfPaletteLWColNum               As Integer = 46                     '枚数
    Private Const CMlngvsfPaletteLWColStockID           As Integer = 65                     '在庫ID

    '@vsfPaletteListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfPaletteLColNo                 As String = "№"                    'ｽﾛｯﾄ
    Private Const CMstrvsfPaletteLColPaletteID          As String = "パレットID"            'ﾊﾟﾚｯﾄID
    Private Const CMstrvsfPaletteLColCFLotID            As String = "出荷ロットID"          '出荷ID
    Private Const CMstrvsfPaletteLColPrLotID            As String = "製造ロットID"          '製造ﾛｯﾄID
    Private Const CMstrvsfPaletteLColBoardThickness     As String = "厚"                    '板厚
    Private Const CMstrvsfPaletteLColRegeneration       As String = "ﾘﾜｰｸ"                  'ﾘﾜｰｸ回数
    Private Const CMstrvsfPaletteLColNum                As String = "枚数"                  '枚数
    Private Const CMstrvsfPaletteLColStockID            As String = "在庫ID"                '在庫ID

    '@vsf共通の定数宣言
    Private Const CMlngVsfRowTitle                      As Integer = 0                      'ﾀｲﾄﾙ行(行)
    Private Const CMlngVsfColTitle                      As Integer = 0                      'ﾀｲﾄﾙ行(列)
    Private Const CMlngVsfHFontSize                     As Integer = 11                     'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                       As Integer = 20                     'ﾍｯﾀﾞｰの高さ
    Private Const CMlngVsfHeight                        As Integer = 24                     '1ｽﾛｯﾄの高さ
    Private Const CMlngvsfPartMaxRow                    As Integer = 16                     '部材一覧最大行(ﾀｲﾄﾙ含む)

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                      As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Integer = 11                     'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols1                     As Integer = 1                      'ｸﾞﾘｯﾄﾞ表示列数=1
    Private Const CMlngCmbDispCols2                     As Integer = 2                      'ｸﾞﾘｯﾄﾞ表示列数=2
    Private Const CMlngCmbValueCol1                     As Integer = 1                      '値取得個数=1
    Private Const CMlngCmbValueCol2                     As Integer = 2                      '値取得個数=2
    Private Const CMlngCmbValueCol3                     As Integer = 3                      '値取得個数=3
    Private Const CMlngCmbRowHeight                     As Integer = 18                     'ﾘｽﾄ行の高さ
    Private Const CMlngCmbGridCol0                      As Integer = 0                      '名称列番=0
    Private Const CMlngCmbGridCol1                      As Integer = 1                      '名称列番=1
    Private Const CMlngCmbGroupCol                      As Integer = 2                      'ｸﾞﾙｰﾌﾟCol
    Private Const CMlngCmbGroupRow                      As Integer = 0                      'ｸﾞﾙｰﾌﾟRow
    Private Const CMlngCmbGetCol5                       As Integer = 5                      'ﾊﾞｯｸｶﾗｰ格納Col

    '@投入装置ｺﾝﾎﾞﾎﾞｯｸｽの初期値
    'Private Const CMstrcmbThrowinWPListIndex            As String = 1                       'ﾘｽﾄｲﾝﾃﾞｯｸｽ

    '@CF編成引数
    Private Const CMlngvsfClickFlg                      As Integer = 1                      'ｸﾘｯｸｲﾍﾞﾝﾄから
    Private Const CMlngcmdClearFlg                      As Integer = 3                      '取消ﾎﾞﾀﾝから

    '@詰数ｽﾗｯｼｭ
    Private Const CMstrlblSrash                         As String = "/"                     '詰数表記用
    Private Const CMstrDefaultNum                       As String = "0"                     'ﾃﾞﾌｫﾙﾄ詰数

    '@画面ｻｲｽﾞ取得時用
    Private Const CMstrCfFlag1                          As String = "1"                     'CFﾌﾗｸﾞ(1：CFの時)

    Private Const CMlngtxtPaletteS                      As Integer = 0                      'Index
    Private Const CMlngtxtPaletteE                      As Integer = 17                     'Index

    '@定数宣言
    Private Const CMlngDisp0                            As Integer = 0                      '0件表示用

    '@起動区分の定数宣言
    Private Const CMlngPDEntry                          As Integer = 1                      '機種ｴﾝﾄﾘ表示用(全件取得)

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    Private mtypScreenSizeList                          As ScreenSizeList                   'ｽｸﾘｰﾝｻｲｽﾞ格納変数
    Private mtypProductList                             As List(Of ProductList)             '機種格納変数
    Private mlngProductListCnt                          As Integer                          '機種格納数
    Private mtypSeqList()                               As EntryList                        '工順Ver.格納変数
    Private mlngOrderListCnt                            As Integer                          '工順Ver.格納数
    Private mtyppartlist                                As List(Of PartClassList)           '部品格納変数
    Private mlngpartlistcnt                             As Integer                          '部品格納数
    Private mtypThicknessClassList                      As List(Of ThicknessClassList)      '板厚区分ﾘｽﾄ
    Private mlngThicknessCnt                            As Integer                          '板厚区分数
    Private mtypLotManagerList                          As List(Of TechManList)             'ﾛｯﾄ担当者ﾘｽﾄ格納用
    Private mlngLotManagerListCnt                       As Integer                          'ﾛｯﾄ担当者ﾘｽﾄ格納数
    Private mstrTaihiPartID                             As String                           '部品ID
    Private mstrTaihiVenderID                           As String                           'ﾍﾞﾝﾀﾞｰ種別ID
    Private mstrTaihiNumber                             As String                           '詰め数格納
    Private mblnErrFlag                                 As Boolean                          '詰数ｴﾗｰ判定ﾌﾗｸﾞTrue:ｴﾗｰ　false:ｴﾗｰなし(Err時はﾌｫｰｶｽの移動しない)
    Private mstrCarrierID                               As String                           'ｷｬﾘｱID退避
    Private mtypChgSort                                 As ChgSort                          'ｿｰﾄ保持用
    Private mblnFormLoadFlag                            As Boolean                          'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ(True:処理なし/False:処理実行)
    Private mstrLotManagerID                            As String                           'ﾛｯﾄ担当者ID格納
    Private mtypWpList()                                As WpList                           '装置一覧格納用
    Private mlngWpListCnt                               As Integer                          '装置一覧件数
    Private mstrUsePart                                 As String                           '利用部材

    Private buttonProcessing                            As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                          'NSYS WindowCloseフラグ
    Private mintvsfPartLotListRowBeforeSort             As Integer                          'NSYS vsfPartLotListのソート前選択行
    Private txtPalette()                                As TextBoxEx                        'NSYS パレットIDコントロール配列
    Private mblnOnValidate                              As Boolean                          'NSYS Validate中フラグ

    'キーイベント処理用の定義
    Private Declare Function GetKeyState Lib "user32" (ByVal nVirtKey As Integer) As Short
    Private Const VK_SHIFT = &H10       '[Shift]
    Private Const VK_CONTROL = &H11     '[Ctrl]
    Private Const VK_MENU = &H12        '[Alt]
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
        mintvsfPartLotListRowBeforeSort = 0
        Form_Load()
        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle
    End Sub

    '****************************************************************************************
    '                                *イベントハンドラの記述*
    '****************************************************************************************
    '========================================Private=========================================
    '関数名：Form_Load
    '機　能：初期情報取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/14 (Mon) 13:19:44 S.Deguchi
    '更新日：2005/03/15 (Tue) 12:38:41 N.Kojima
    '備　考：
    '　　　：2004/11/24 (Wed) 13:42:43 S.Deguchi    技術担当者の情報取得処理を追加
    '　　　：2005/03/15 (Tue) 12:38:41 N.Kojima     投入装置追加に伴う修正(改善№577)
    Private Sub Form_Load()

        Dim lblnAns             As Boolean              '結果格納
        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypVenderlist      As VenderList           'ﾍﾞﾝﾀﾞｰﾘｽﾄ格納

        Try
            'NSYS 表示位置設定
            StartPosition = FormStartPosition.Manual
            Top = 0
            Left = 0 - My.Settings.FormOffset

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN00B0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
            '@異常終了の場合
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "Form_Load"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            txtPalette = New TextBoxEx() _
                { txtPalette00, txtPalette01, txtPalette02, txtPalette03, txtPalette04, txtPalette05, _
                txtPalette06, txtPalette07, txtPalette08, txtPalette09, txtPalette10, txtPalette11, _
                txtPalette12, txtPalette13, txtPalette14, txtPalette15, txtPalette16, txtPalette17 }

            '@Private変数等の初期化
            Call prvfrmxxEN00B0_Minit()
            
            '@画面情報の初期化
            Call prvfrmxxEN00B0_Init()
             
            '@構造体の初期化(ｿｰﾄ)
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                If IsNothing(.typChgSortList) Then
                    .typChgSortList = New List(Of ChgSortList)()
                Else
                    .typChgSortList.Clear()
                End If
                
                '@列幅変更ﾌﾗｸﾞ(未変更)
                .blnChgWidth = False
                
                '@ｶﾚﾝﾄ行検索ｷｰを初期化
                .strKey = vbNullString
            End With
                
            '@ｽｸﾘｰﾝｻｲｽﾞ取得
            lblnAns = pubblnMasScreenList_Sel(CMstrmas_screenlistVer, _
                                              CMstrCfFlag1, _
                                              mtypScreenSizeList)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@板厚区分(ﾘｽﾄ)情報の取得
            lblnAns = pubblnThicknessClass_Sel(CMstrmas_thicklistVer, _
                                               mtypThicknessClassList, _
                                               mlngThicknessCnt)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@部材情報取得
            lblnAns = pubblnVendClassList_Sel(CMstrmas_vendclasslistVer, _
                                              CPstrCD31, _
                                              ltypVenderlist)
            '@結果格納
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                            
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                            
                Exit Sub
            End If
            
            '@装置一覧取得、結果ﾁｪｯｸ
            lblnAns = pubblnWpList_Sel(CMstrmas_wplist__Ver, _
                                       mlngWpListCnt, _
                                       pstrSBID, _
                                       CPstrCD3U, _
                                       , , , , CMstrThrowineq_type)
            '@結果格納
            If lblnAns = True Then
                '配列の件数ﾁｪｯｸ
                If mlngWpListCnt = 0 Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    '@Escﾎﾞﾀﾝを有効
                    Me.CancelButton = cmdClose
                    
                    Exit Sub
                End If
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@【作業者ﾘｽﾄ(ﾛｯﾄ担当者ﾘｽﾄ)取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnMasEmplist_Sel(CMstrmas_emplist_Ver, _
                                           mtypLotManagerList, _
                                           mlngLotManagerListCnt)
            '@結果格納
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                            
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                            
                Exit Sub
            End If
            
            'CFのみ取得(ﾃﾞｰﾀは必ず１件)
            If ltypVenderlist.lngVenderClassListCnt = 1 Then
                '@部品IDを取得
                mstrTaihiVenderID = ltypVenderlist.typVenderClassList(0).strVenderClassId
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
    '機　能：ﾌｫｰﾑｱｸﾃｨﾍﾞｲﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/17 (Wed) 15:02:53 S.Deguchi
    '更新日：2008/06/11 (Wed) 11:04:52 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 11:04:52 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try

            '@ﾌｫｰﾑﾛｰﾄﾞ時のみ行う処理
            If mblnFormLoadFlag = False Then
                '@ﾌﾗｸﾞ変更
                mblnFormLoadFlag = True
                
                '@ｽｸﾘｰﾝｻｲｽﾞCombo作成
                Call prvcmbScreenSize_Disp()
                    
                '@投入装置をｺﾝﾎﾞへｾｯﾄ
                Call prvcmbThrowinWP_Disp()
                
                '@ﾛｯﾄ担当ｺﾝﾎﾞ作成
                Call prvCmbLotManager_Disp()
                
                With cmbScreenSize
                    '@取得した情報が1件のみの場合の処理
                    If .ListCount = 1 Then
                        '@ﾃｷｽﾄ部に表示
                        .ListIndex = 0
                        
                        '@情報取得
                        RemoveHandler cmbScreenSize.Validating, AddressOf cmbScreenSize_Validate
                        cmbScreenSize_Validate(cmbScreenSize, New CancelEventArgs(False))
                        AddHandler cmbScreenSize.Validating, AddressOf cmbScreenSize_Validate
                    End If
                End With
            
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                If Me.ActiveControl Is cmbScreenSize Then
                    ' NSYS フォーカスがある場合
                    Me.ActiveControl = Nothing '一旦フォーカスを外す
                    
                    Me.ActiveControl = cmbScreenSize 'フォーカスを戻す
                    pubSetFocus(cmbScreenSize)
                End If
                
                'NSYS Activate中にpublngMsgBox等で別ウィンドウを表示するとActivateがキャンセルされるため、再Activateする
                'NSYS Activateイベント中にActivate()を呼び出しても作用しないため、遅延で実行する。ラムダ式使用
                Dim lfuncActivate As Action = Sub()
                    Me.Activate()
                    End Sub
                Me.BeginInvoke(lfuncActivate)

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
    '機　能：ﾌｫｰﾑのKeyDown
    '引　数：KeyCode：入力ｷｰｺｰﾄﾞ
    '　　　：Shift：ｼﾌﾄｺｰﾄﾞ
    '戻り値：なし
    '作成日：2004/06/14 (Mon) 13:29:44 S.Deguchi
    '更新日：2008/06/11 (Wed) 11:05:33 N.Kojima
    '備　考：
    '　　　：2004/11/24 (Wed) 14:55:53 S.Deguchi    技術担当者処理を追加
    '　　　：2005/03/15 (Tue) 13:14:46 N.Kojima     投入装置追加に伴う修正(改善№577)
    '　　　：2008/06/11 (Wed) 11:05:33 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
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

            '@ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙによる処理分岐
            Select Case ActiveControl.Name
                Case cmbScreenSize.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@画面ｻｲｽﾞValidate処理へ
                            RemoveHandler cmbScreenSize.Validating, AddressOf cmbScreenSize_Validate
                            Call cmbScreenSize_Validate(cmbScreenSize, New CancelEventArgs(False))
                            AddHandler cmbScreenSize.Validating, AddressOf cmbScreenSize_Validate
                            e.Handled = True
                    End Select
                    
                Case cmbPD.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@機種Validate処理へ
                            RemoveHandler cmbPd.Validating, AddressOf cmbPd_Validate
                            Call cmbPd_Validate(cmbPd, New CancelEventArgs(False))
                            AddHandler cmbPd.Validating, AddressOf cmbPd_Validate
                            e.Handled = True
                    End Select
                
                Case cmbPart.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@部品Validate処理へ
                            RemoveHandler cmbPart.Validating, AddressOf cmbPart_Validate
                            Call cmbPart_Validate(cmbPart, New CancelEventArgs(False))
                            AddHandler cmbPart.Validating, AddressOf cmbPart_Validate
                            e.Handled = True
                    End Select
                    
                Case cmbLotManager.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@ﾛｯﾄ担当Validate処理へ
                            RemoveHandler cmbLotManager.Validating, AddressOf cmbLotManager_Validate
                            Call cmbLotManager_Validate(cmbLotManager, New CancelEventArgs(False))
                            AddHandler cmbLotManager.Validating, AddressOf cmbLotManager_Validate
                            e.Handled = True
                    End Select
                
                Case cmbThrowinWP.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@投入装置Validate処理へ
                            RemoveHandler cmbThrowinWP.Validating, AddressOf cmbThrowinWP_Validate
                            Call cmbThrowinWP_Validate(cmbThrowinWP, New CancelEventArgs(False))
                            AddHandler cmbThrowinWP.Validating, AddressOf cmbThrowinWP_Validate
                            e.Handled = True
                    End Select
                    
                Case txtNumber.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '詰数Validate処理へ
                            RemoveHandler txtNumber.Validating, AddressOf txtNumber_Validate
                            Call txtNumber_Validate(txtNumber, New CancelEventArgs(False))
                            AddHandler txtNumber.Validating, AddressOf txtNumber_Validate
                            
                            '@詰数のｴﾗｰの場合ﾌｫｰｶｽ移動しない
                            If mblnErrFlag = False Then
                                '@ﾌｫｰｶｽの移動
                                Call pubSetFocus(txtPalette(CMlngtxtPaletteS))
                            End If
                            
                            e.Handled = True
                    End Select
                
                Case Else
                    Select Case e.KeyCode
                        '@Enterｷｰの場合
                        Case Keys.Return
                            '@次項目へｾｯﾄﾌｫｰｶｽ
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
    '機　能：ﾌｫｰﾑｱﾝﾛｰﾄﾞ
    '引　数：Cancel：未使用
    '　　　：UnloadMode：未使用
    '戻り値：なし
    '作成日：2004/06/14 (Mon) 13:39:44 S.Deguchi
    '更新日：2004/11/01 (Mon) 15:48:44 N.Kasai
    '備　考：
    '　　　：2004/10/19 (Tue) 09:00:13 N.Kasai      ｿｰﾄ構造体ｸﾘｱ追加
    '　　　：2004/11/01 (Mon) 15:48:44 N.Kasai      閉じるﾎﾞﾀﾝ統合
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose, New EventArgs())
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@Private変数等の初期化
            Call prvfrmxxEN00B0_Minit()
            
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

    '関数名：cmdSearch_Click
    '機　能：検索開始
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/15 (Tue) 09:10:02 S.Deguchi
    '更新日：2008/06/11 (Wed) 11:06:03 N.Kojima
    '備　考：
    '　　　：2004/09/26 (Sun) 18:51:02 S.Deguchi    処理区分追加
    '　　　：2004/10/19 (Tue) 09:09:29 N.Kasai      0件ﾒｯｾｰｼﾞ削除
    '　　　：2004/11/17 (Wed) 14:02:51 S.Deguchi    取得件数0件の場合の処理を修正(該当件数/取得に日時を更新)
    '　　　：2004/11/24 (Wed) 14:57:28 S.Deguchi    技術担当者欄の活性化処理を追加
    '　　　：2005/03/15 (Tue) 13:12:39 N.Kojima     投入装置追加に伴う修正(改善№577)
    '　　　：2008/06/11 (Wed) 11:06:03 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch.Click

        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypPartLotList         As List(Of PartLotList) '部材一覧取得情報格納
        Dim llngPartLotListCnt      As Integer              '部材一覧取得件数格納
        Dim lstrTempRework          As String               'ﾘﾜｰｸ回数
        Dim lstrTempBT              As String               '板厚
        Dim lstrClassDivision       As String               'ClassDivision
        Dim llngCnt                 As Integer              'ｶｳﾝﾄ

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
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "cmdSearch_Click"
            
            '@利用部材・入力ﾁｪｯｸ
            If cmbPart.Text = vbNullString Then
                Exit Sub
            End If
            
            '@ClassDivisionの初期化
            lstrClassDivision = vbNullString
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ﾘﾜｰｸ/板厚の値を取得
            If cmbRework.Text = CPstrComboAppointNo Then
            '@指定なしの場合
                lstrTempRework = vbNullString               'Nullをｾｯﾄ
            Else
            '@指定なし以外の場合
                lstrTempRework = Trim(cmbRework.Text)       '選択した板厚をｾｯﾄ
            End If
            If cmbBoardThickness.Text = CPstrComboAppointNo Then
            '@指定なしの場合
                lstrTempBT = vbNullString                   'Nullをｾｯﾄ
            Else
            '@指定なし以外の場合
                lstrTempBT = Trim(cmbBoardThickness.Text)   '選択した板厚をｾｯﾄ
            End If
            
            '@処理区分設定
            lstrClassDivision = CPstrCD0A & CPstrCD0G & CPstrCD3F   '処理区分(0A；PARTCORD/0G;VENDER_CLASS_ID/3F;完成在庫以外)
            
            '@板厚を含めるかﾁｪｯｸ
            If lstrTempBT = vbNullString Then
            '@指定なしの場合
                lstrClassDivision = lstrClassDivision
            Else
            '@指定なし以外の場合
                lstrClassDivision = lstrClassDivision & CPstrCD0I   '処理区分(0I；THICKNESS_CODE)
            End If
            
            '@ﾘﾜｰｸ回数を含めるかﾁｪｯｸ
            If lstrTempRework = vbNullString Then
            '@指定なしの場合
                lstrClassDivision = lstrClassDivision
            Else
            '@指定なし以外の場合
                lstrClassDivision = lstrClassDivision & CPstrCD0J   '処理区分(0J；REWORK_COUNT)
            End If
            
            '@部材一覧情報の取得
            lblnAns = pubblnInvPartList_Sel(CMstrinv_partlistVer, lstrClassDivision, _
                                            mstrTaihiPartID, _
                                            mstrTaihiVenderID, _
                                            ltypPartLotList, _
                                            llngPartLotListCnt, lstrTempBT, lstrTempRework)
            '@結果判定
            If lblnAns = True Then
                '@取得結果を一覧表示
                Call prvvsfPartLotList_Disp(ltypPartLotList, llngPartLotListCnt)
            Else
                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@部品Comboへｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(cmbPart)
                
                Exit Sub
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)

            '@部材一覧情報の結果が0件以外の場合には検索条件(投入予定)の確定処理/CF編成ﾌﾚｰﾑを使用可能にする
            If llngPartLotListCnt <> 0 Then
                '@投入予定確定前の場合のみ処理
                If cmbScreenSize.Enabled = True Then
                    '@CF編成ﾌﾚｰﾑの初期化
                    Call prvfraCF_Init()
                    
                    '@ﾊﾟﾚｯﾄID一覧のｽﾛｯﾄ入力欄設定
                    Call prvvsfPaletteList_Disp()
                    
                    '@詰数をTextﾎﾞｯｸｽに格納
                    txtNumber.Text = mstrTaihiNumber
                    
                    '@詰数をﾗﾍﾞﾙに格納
                    lblMaxNum.Text = CMstrlblSrash & mstrTaihiNumber
                    
                    '@ﾊﾟﾚｯﾄID有効処理
                    For llngCnt = CMlngtxtPaletteS To CMlngtxtPaletteE
                        txtPalette(llngCnt).Enabled = True
                    Next
                    
                    '@投入装置を活性化
                    cmbThrowinWP.Enabled = True
                    
                    '@ﾛｯﾄ担当を活性化
                    cmbLotManager.Enabled = True
                    
                End If
                
                '@投入予約項目を確定(選択不可状態に移行)
                cmbScreenSize.Enabled = False
                cmbPD.Enabled = False
                cmdEntry.Enabled = False
            
                '@ｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(vsfPartLotList)
            Else
                '@該当件数0件の場合の処理を追加(日時/件数をﾗﾍﾞﾙにｾｯﾄ)
                lblLotCnt.Text = CMlngDisp0
                lblNowDate.Text = Format$(Now, CPstrDateFormat)
                
        '        '@該当件数0件時ﾒｯｾｰｼﾞ表示："該当データがありません。"
        '        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0004)
        '        Call publngMsgBoxInfo(pstrDMsg, vbInformation, frmxxEN00B0.Caption, True, 16)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdSearch_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdClear_Click
    '機　能：取消処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/21 (Mon) 15:12:47 S.Deguchi
    '更新日：2004/09/23 (Thu) 15:56:50 N.Kasai
    '備　考：復活の可能性ありの為、残しています。
    Private Sub cmdClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClear.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
            
            '@ｽﾛｯﾄﾏｯﾌﾟ反映/取消処理へ
            Call prvvsfPaletteList_Set(CMlngcmdClearFlg)
            
            '@投入確定ﾎﾞﾀﾝEnabled処理へ
            Call prvcmdRegist_Chk()
            
            '@取消ﾎﾞﾀﾝEnabled処理へ
            Call prvCmdClear_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdClear_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdPdChange_Click
    '機　能：機種変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/18 (Fri) 15:26:21 S.Deguchi
    '更新日：2004/06/18 (Fri) 15:26:21
    '備　考：
    Private Sub cmdPdChange_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdPdChange.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@現在、機能なし
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdPdChange_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdAllClear_Click
    '機　能：全取消
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/15 (Tue) 10:19:29 S.Deguchi
    '更新日：2008/06/11 (Wed) 11:06:27 N.Kojima
    '備　考：
    '　　　：2004/11/24 (Wed) 14:58:52 S.Deguchi    技術担当者のｸﾘｱ後,再描写処理を追加
    '　　　：2005/03/15 (Tue) 13:16:13 N.Kojima     投入装置追加に伴う修正(改善№577)
    '　　　：2008/06/11 (Wed) 11:06:27 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub cmdAllClear_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAllClear.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@初期化
            Call prvfrmxxEN00B0_Init()
            
            '@ﾊﾟﾚｯﾄID一覧のｽﾛｯﾄ入力欄設定
            Call prvvsfPaletteList_Disp()

            '@投入装置のCombo設定
            Call prvcmbThrowinWP_Disp()

            '@ﾛｯﾄ担当のCombo設定
            Call prvCmbLotManager_Disp()
            
            '@ｽｸﾘｰﾝｻｲｽﾞのCombo設定
            Call prvcmbScreenSize_Disp()
            
            '@ｽｸﾘｰﾝｻｲｽﾞへｾｯﾄﾌｫｰｶｽ
            Call pubSetFocus(cmbScreenSize)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdAllClear_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdCarrierSelect_Click
    '機　能：空きｷｬﾘｱ選択
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/23 (Thu) 14:07:21 N.Kasai
    '更新日：2004/09/23 (Thu) 14:07:21
    '備　考：
    '　　　：2005/10/06 (Thu) 16:34:39 S.Deguchi    ｷｬﾘｱの洗浄条件設定処理を追加
    Private Sub cmdCarrierSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdCarrierSelect.Click

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
            
            '@ｷｬﾘｱﾀｲﾌﾟID引渡し
            pstrCarrierTypeID = CPstrCarrTypeCF  '(CFカセット限定)
            
            '@ｷｬﾘｱの洗浄条件：未洗浄可
            pstrCleanCondition = CPstrCarrierClean1
            
            '@空きｷｬﾘｱ一覧表示
            frmxxCM00K0.Instance = New frmxxCM00K0()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM00K0.Instance = Nothing
                Exit Sub
            End If
            
            '@空きｷｬﾘｱ一覧表示
            frmxxCM00K0.Instance.ShowDialog(Me)
            frmxxCM00K0.Instance = Nothing
                 
            '@空きｷｬﾘｱが選択されている場合
            If pstrCarrierID <> vbNullString Then
                '@ｷｬﾘｱIDをｾｯﾄ
                txtCarrierID.Text = pstrCarrierID
            End If
            
            '@使用したﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrCarrierTypeID = vbNullString                'ｷｬﾘｱﾀｲﾌﾟ
            pstrCleanCondition = vbNullString               '洗浄条件
            pstrCarrierID = vbNullString                    'ｷｬﾘｱID
            
            '@ｷｬﾘｱIDにﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtCarrierID)
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdCarrierSelect_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdEntry_Click
    '機　能：機種ｴﾝﾄﾘﾎﾞﾀﾝ押下処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/23 (Thu) 15:44:02 N.Kasai
    '更新日：2005/12/21 (Wed) 10:34:22 N.Kojima
    '備　考：
    '　　　：2005/12/21 (Wed) 10:34:22 N.Kojima     Public変数ｴﾝﾄﾘID、ｴﾝﾄﾘ名の初期化追加。(運用障害№657)
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
            
            '@機種IDの退避(ﾏｽﾀ工順取得用)
            pstrPDID = cmbPD.Text
            
            '@引継ﾊﾟﾌﾞﾘｯｸ変数を初期化
            pstrEntryID = vbNullString          '機種ｴﾝﾄﾘID
            pstrEntryName = vbNullString        '機種ｴﾝﾄﾘ名
            
            '@起動区分指定
            plngfrmxxCM00L0Kbn = CMlngPDEntry
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@機種ｴﾝﾄﾘ一覧表示(ﾂｰﾙｻｲｽﾞ)
            frmxxCM00L0.Instance = New frmxxCM00L0()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM00L0.Instance = Nothing
                Exit Sub
            End If
            
            '@ｻﾌﾞﾌｫｰﾑの名称設定
            frmxxCM00L0.Instance.Text = CPstrSubDispTitlePDEntryList
            
            '@機種ｴﾝﾄﾘ一覧表示(ﾂｰﾙｻｲｽﾞ)
            frmxxCM00L0.Instance.ShowDialog(Me)
            frmxxCM00L0.Instance = Nothing
            '@機種ｴﾝﾄﾘが選択されている場合
            If pstrEntryID <> vbNullString Then
                '@ｴﾝﾄﾘIDをｾｯﾄ
                lblEntryID.Text = pstrEntryID
            End If
            
            '@ﾌｫｰｶｽの制御
            If cmbPart.Enabled = True Then
                Call pubSetFocus(cmbPart)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdEntry_Click"
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
    '作成日：2004/06/14 (Mon) 14:19:44 S.Deguchi
    '更新日：2004/06/14 (Mon) 14:19:44
    '備　考：
    Private Sub cmdClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdClose.Click
        
        Dim ltypCommonInfo  As CommonInfo

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@終了関数を実行する
            Call publngEnd_Proc(CPstrKeyEN00B0, ltypCommonInfo)
            
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
    '機　能：確定ﾎﾞﾀﾝ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/15 (Tue) 16:52:39 S.Deguchi
    '更新日：2008/06/11 (Wed) 11:06:54 N.Kojima
    '備　考：
    '　　　：2004/11/24 (Wed) 15:00:52 S.Deguchi    技術担当者の再描写処理と登録構造体への格納処理を追加
    '　　　：2005/03/15 (Tue) 13:17:21 N.Kojima     投入装置追加に伴う修正(改善№577)
    '　　　：2005/03/31 (Thu) 14:10:06 N.Kojima     ｶﾞｲﾀﾞﾝｽMsg表示対応
    '　　　：2007/06/13 (Wed) 10:35:13 N.Kojima     ﾌｫｰｶｽ処理をｺﾒﾝﾄｱｳﾄし、確定前ﾁｪｯｸ処理内に移動。(案件№01992)
    '　　　：2008/06/11 (Wed) 11:06:54 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean              '結果格納
        Dim ltypLotCfThrowin        As LotCfThrowin         'CF編成構造体
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngCnt                 As Integer              'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance        As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg

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
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "cmdRegist_Click"
            
            '@投入装置ﾁｪｯｸ
            If cmbThrowinWP.Text = vbNullString Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005F)
                
                '@"投入装置が選択されていません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@投入装置ｺﾝﾎﾞにﾌｫｰｶｽｾｯﾄ
                Call pubSetFocus(cmbThrowinWP)
                
                Exit Sub
            End If
            
        '@↓2007/06/13 (Wed) 10:35:40 N.Kojima **************************************************

            '@ｽﾛｯﾄﾏｯﾌﾟ&ﾊﾟﾚｯﾄIDの入力ﾁｪｯｸ、詰数合計と投入数の合致ﾁｪｯｸ、RW回数のﾁｪｯｸを行なう
            lblnAns = prvblnRegist_Chk()
            If lblnAns = False Then
                '@合致しない場合、投入中止
        '        Call pubSetFocus(vsfPaletteList)
                Exit Sub
            End If
            
        '@↑2007/06/13 (Wed) 10:35:40 N.Kojima **************************************************
            
            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing
            
            '@作業者ｺｰﾄﾞ入力ﾁｪｯｸ
            If pstrUserID = vbNullString Then
                '@未入力の場合、投入中止
                Exit Sub
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@CF編成構造体へ設定
            With ltypLotCfThrowin
                .strSbID = pstrSBID                                 'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strCarrierId = txtCarrierID.Text                   'ｷｬﾘｱID
                .strEmpID = pstrUserID                              '作業者ID
                .strNum = lblThrowNum.Text                          '投入数
                .strPdId = cmbPD.Text                               'PD_ID
                .strEntryID = lblEntryID.Text                       'ｴﾝﾄﾘID
                .strTechManID = Trim(mstrLotManagerID)              'ﾛｯﾄ担当者ID(ｽﾍﾟｰｽ1個ｱﾘ)
                .lngPaletteMapListCnt = CInt(CPlngPaletteSlot)      'ｽﾛｯﾄｶｳﾝﾄ
                .strWpID = cmbThrowinWP.Value                       '投入装置
                
                '@ﾊﾟﾚｯﾄｽﾛｯﾄ情報の設定
                .typPaletteMapList = New List(Of PaletteMapList)()
                
                For llngCnt = 0 To CPlngPaletteSlot - 1
                    Dim tmpPaletteMapList As PaletteMapList = New PaletteMapList()
                    tmpPaletteMapList.strSlotPositon _
                        = vsfPaletteList.GetData(llngCnt+1, CMlngvsfPaletteLColNo)                   'ｽﾛｯﾄ№
                        
                    tmpPaletteMapList.strPaletteID _
                        = vsfPaletteList.GetData(llngCnt+1, CMlngvsfPaletteLColPaletteID)            'ﾊﾟﾚｯﾄID
                        
                    tmpPaletteMapList.strChipCount _
                        = vsfPaletteList.GetData(llngCnt+1, CMlngvsfPaletteLColNum)                  '詰数
                        
                    tmpPaletteMapList.strLotID _
                        = vsfPaletteList.GetData(llngCnt+1, CMlngvsfPaletteLColStockID)              '在庫ID

                    .typPaletteMapList.Add(tmpPaletteMapList)
                Next llngCnt
                
                .strMsgVer = CMstrlot_cfthrowinVer
            
                '@ﾒｯｾｰｼﾞ送信処理呼び出し
                lblnAns = pubblnLotCfThrowin_Upd(CMstrlot_cfthrowinVer, _
                                                 ltypLotCfThrowin, _
                                                 lstrGuidMsg, _
                                                 lstrGuidMsgCode)
                '@結果判定
                If lblnAns = True Then
                    
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
                
                    '@ﾒｯｾｰｼﾞ表示
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0007, .strCarrierId, .strRetrunLotID)
                    
                    '@"<TRM07I>$$ロット[%2]を投入しました。キャリア[%1]"
                    Call pubVsfInfo_Disp(pstrDMsg)

                    '@画面の初期化
                    Call prvfrmxxEN00B0_Init()
                    
                    '@ｽｸﾘｰﾝｻｲｽﾞｺﾝﾎﾞ作成
                    Call prvcmbScreenSize_Disp()
                    
                    '@投入装置のCombo設定
                    Call prvcmbThrowinWP_Disp()
                    
                    '@ﾛｯﾄ担当のCombo設定
                    Call prvCmbLotManager_Disp()

                    '@CFﾛｯﾄID表記
                    lblCfLotID.Text = .strRetrunLotID
                    
                    '@ｽｸﾘｰﾝｻｲｽﾞへｾｯﾄﾌｫｰｶｽ
                    Call pubSetFocus(cmbScreenSize)
                Else

                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                    
                    Exit Sub
                End If
                
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
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

    '関数名：cmbScreenSize_Change
    '機　能：ｽｸﾘｰﾝｻｲｽﾞ変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/14 (Mon) 15:19:44 S.Deguchi
    '更新日：2005/07/22 (Fri) 09:20:27 N.Kasai
    '備　考：
    '　　　：2005/07/22 (Fri) 09:20:27 N.Kasai      機種ｺﾝﾎﾞ初期化追加
    Private Sub cmbScreenSize_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbScreenSize.Change

        Dim lblnChkAns  As Boolean      '入力ﾁｪｯｸ結果格納(True:OK/False:NG)

        Try
            
            '@ﾛｯﾄIDの初期化
            lblCfLotID.Text = vbNullString
            
            '@機種の初期化
            With cmbPD
                .Clear()
                .BackColor = SystemColors.Control
                .Enabled = False
            End With
            
            '@工順Ver.の初期化
            lblEntryID.Text = vbNullString
            cmdEntry.Enabled = False
            
            '@ｽｸﾘｰﾝｻｲｽﾞが空欄の以外場合,入力ﾁｪｯｸ
            If cmbScreenSize.Text <> vbNullString Then
                '@全取消ﾎﾞﾀﾝ活性化
                cmdAllClear.Enabled = True
                
                '@入力ﾁｪｯｸ
                lblnChkAns = prvblnThrowInfo_Chk()
                If lblnChkAns = True Then
                    '@利用部材ﾌﾚｰﾑの設定
                    Call prvfraPart_Set()
                Else
                    '@利用部材ﾌﾚｰﾑ初期化
                    Call prvfraPart_Init()
                End If
            Else
                '@全取消ﾎﾞﾀﾝ活性化
                cmdAllClear.Enabled = False
                
                '@利用部材ﾌﾚｰﾑ初期化
                Call prvfraPart_Init()
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbScreenSize_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbScreenSize_CloseUp
    '機　能：ｽｸﾘｰﾝｻｲｽﾞCloseUp
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/14 (Mon) 15:21:16 S.Deguchi
    '更新日：2004/06/14 (Mon) 15:21:16
    '備　考：
    Private Sub cmbScreenSize_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbScreenSize.CloseUp

        Try

            '@空欄ではない場合
            If cmbScreenSize.Text <> vbNullString Then
                '@validate処理へ
                RemoveHandler cmbScreenSize.Validating, AddressOf cmbScreenSize_Validate
                Call cmbScreenSize_Validate(cmbScreenSize, New CancelEventArgs(False))
                AddHandler cmbScreenSize.Validating, AddressOf cmbScreenSize_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbScreenSize_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbScreenSize_Validate
    '機　能：ｽｸﾘｰﾝｻｲｽﾞValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/06/14 (Mon) 15:22:05 S.Deguchi
    '更新日：2004/06/14 (Mon) 15:22:05
    '備　考：
    '　　　：2005/12/12 (Mon) 16:31:26 S.Deguchi    機種取得件数が0件の場合の処理を追加
    Private Sub cmbScreenSize_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbScreenSize.Validating

        Dim lblnPdAns           As Boolean              '機種情報取得処理結果
        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrClassDivision   As String               'ClassDivision置換
        Dim lblnNextCtrl        As Boolean              'NSYS Focus設定フラグ

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If ActiveControl Is cmbScreenSize Then
                lblnNextCtrl = True
            Else
                lblnNextCtrl = False
            End If

            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "cmbScreenSize_Validate"
            
            '@選択されていない場合
            If cmbScreenSize.Text = vbNullString Then
                '@閉じるへｾｯﾄﾌｫｰｶｽ
                If lblnNextCtrl Then
                    Call pubSetFocus(cmdClose)
                End If
                
                Exit Sub
            Else
                '@詰め数を退避領域に格納
                cmbScreenSize.ValueCol = 1
                mstrTaihiNumber = cmbScreenSize.Value
                
                '@機種ｺﾝﾎﾞﾎﾞｯｸｽ使用可能
                cmbPD.Enabled = True
            End If
            
            '@情報取得前に初期化
            If Not IsNothing(mtypProductList) Then
                mtypProductList.Clear()
            End If
            
            '@機種ﾘｽﾄ取得
            If cmbPD.Text = vbNullString Then
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(lstrFormName, lstrEventName)
                
                '@機種情報取得処理
        '@↓2009/05/14 (Thu) 17:08:37 T.Oide **************************************************
                'lstrClassDivision = CPstrCD2B & CPstrCD31
                lstrClassDivision = CPstrCD2B & CPstrCD4K
        '@↑2009/05/14 (Thu) 17:08:37 T.Oide **************************************************
                
                lblnPdAns = pubblnMasPdlist_Sel(CMstrmas_pdlist__Ver, _
                                                lstrClassDivision, _
                                                mtypProductList, _
                                                mlngProductListCnt, _
                                                pstrSBID, _
                                                cmbScreenSize.Text)
                '@結果判定
                If lblnPdAns = False Then
                    '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                    Call pubResponseCancel(lstrFormName, lstrEventName)
                                
                    Exit Sub
                Else
                    '@機種情報表示
                    Call prvcmbPd_Disp()
                
                    '@ﾚｽﾎﾟﾝｽ取得終了
                    Call publngResponseEnd(lstrFormName, lstrEventName)
                    
                    '@機種情報の件数ﾁｪｯｸ(件数によって処理を分岐)
                    Select Case mlngProductListCnt
                        Case 0
                        '@取得件数が0件
                            '@機種をｸﾘｱして非活性化
                            cmbPD.Text = vbNullString
                            cmbPD.Enabled = False
                            
                        Case 1
                        '@取得件数が1件
                            cmbPD.ListIndex = mlngProductListCnt - 1        '取得した1件を表示
                            
                            mblnOnValidate = lblnNextCtrl
                            RemoveHandler cmbPd.Validating, AddressOf cmbPd_Validate
                            Call cmbPd_Validate(cmbPd, New CancelEventArgs(False))                      '機種のValidateｲﾍﾞﾝﾄを呼び出す
                            AddHandler cmbPd.Validating, AddressOf cmbPd_Validate
                        
                        Case Else
                        '@取得件数が1件以上
                            '@機種Comboへｾｯﾄﾌｫｰｶｽ
                            If lblnNextCtrl Then
                                Call pubSetFocus(cmbPD)
                            End If
                    End Select
                End If
            Else
                '@機種Comboへｾｯﾄﾌｫｰｶｽ
                If lblnNextCtrl Then
                    Call pubSetFocus(cmbPD)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbScreenSize_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        Finally
            mblnOnValidate = False
        End Try
    End Sub

    '関数名：cmbPd_Change
    '機　能：機種変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/14 (Mon) 15:52:18 S.Deguchi
    '更新日：2004/06/14 (Mon) 15:52:18
    '備　考：
    Private Sub cmbPd_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPd.Change

        Dim lblnChkAns  As Boolean      '入力ﾁｪｯｸ結果格納(True:OK/False:NG)

        Try
            
            '@工順Ver.の初期化
            lblEntryID.Text = vbNullString
            cmdEntry.Enabled = False
            
            '@機種が空欄の場合,初期化
            If cmbPD.Text <> vbNullString Then
                '@入力ﾁｪｯｸ
                lblnChkAns = prvblnThrowInfo_Chk()
                '@結果判定
                If lblnChkAns = True Then
                    '@利用部材ﾌﾚｰﾑの設定
                    Call prvfraPart_Set()
                Else
                    '@利用部材ﾌﾚｰﾑ初期化
                    Call prvfraPart_Init()
                End If
            Else
                '@利用部材ﾌﾚｰﾑ初期化
                Call prvfraPart_Init()
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPd_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPd_CloseUp
    '機　能：機種CloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/14 (Mon) 15:52:48 S.Deguchi
    '更新日：2004/06/14 (Mon) 15:52:48
    '備　考：
    Private Sub cmbPd_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPd.CloseUp

        Try

            '@空欄ではない場合
            If cmbPD.Text <> vbNullString Then
                '@Validate処理へ
                RemoveHandler cmbPd.Validating, AddressOf cmbPd_Validate
                Call cmbPd_Validate(cmbPd, New CancelEventArgs(False))
                AddHandler cmbPd.Validating, AddressOf cmbPd_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPd_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPd_Validate
    '機　能：機種Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/06/14 (Mon) 15:52:51 S.Deguchi
    '更新日：2005/07/22 (Fri) 08:55:45 N.Kasai
    '備　考：
    '　　　：2004/09/23 (Thu) 15:46:15 N.Kasai      機種ｴﾝﾄﾘﾎﾞﾀﾝ追加に伴う修正
    '　　　：2005/07/22 (Fri) 08:55:45 N.Kasai      ｺﾝﾎﾞL/R表示
    Private Sub cmbPd_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPd.Validating

        Dim lblnAns             As Boolean              '汎用戻り値
        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lblnNextCtrl        As Boolean              'NSYS Focus設定フラグ

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            If ActiveControl.Name = cmbPd.Name OrElse mblnOnValidate Then
                lblnNextCtrl = True
            Else
                lblnNextCtrl = False
            End If
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "cmbPd_Validate"
            
            '@選択されていない場合
            If cmbPD.Text = vbNullString Then
                '@閉じるへｾｯﾄﾌｫｰｶｽ
                If lblnNextCtrl Then
                    Call pubSetFocus(cmdClose)
                End If
                
                Exit Sub
            Else
                '@工順ｺﾝﾎﾞﾎﾞｯｸｽ使用可能
                cmdEntry.Enabled = True
            End If
            
            '@値取得(ﾊﾞｯｸｶﾗｰ値)
            cmbPD.ValueCol = CMlngCmbGetCol5
            
            If Me.ActiveControl Is cmbPD Then
                ' NSYS フォーカスがある場合
                Me.ActiveControl = Nothing '一旦フォーカスを外す
                If cmbPD.Value <> vbNullString Then
                    '@ﾊﾞｯｸｶﾗｰ反映
                    cmbPD.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(cmbPD.Value))
                Else
                    cmbPD.BackColor = Color.White
                End If
                Me.ActiveControl = cmbPD 'フォーカスを戻す
                pubSetFocus(cmbPD)
            Else
                If cmbPD.Value <> vbNullString Then
                    '@ﾊﾞｯｸｶﾗｰ反映
                    cmbPD.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(cmbPD.Value))
                Else
                    cmbPD.BackColor = Color.White
                End If
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@機種ｴﾝﾄﾘ、部材取得
            lblnAns = prvMasEntryList_Sel(lblnNextCtrl)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@ﾌｫｰｶｽそのまま
                e.Cancel = True
            Else
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPd_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPart_Change
    '機　能：部品の変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/15 (Tue) 08:48:01 S.Deguchi
    '更新日：2004/11/17 (Wed) 14:54:19 S.Deguchi
    '備　考：
    '　　　：2004/11/17 (Wed) 14:54:19 S.Deguchi    初期化処理に情報取得日時/該当件数も追加
    Private Sub cmbPart_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPart.Change

        Try
            
            '@部品一覧のｸﾘｱ
            Call prvvsfPartLotList_Init()
            
            '@情報取得日時/該当件数欄の初期化
            lblNowDate.Text = vbNullString
            lblLotCnt.Text = vbNullString
            
            '@部品Comboが空欄か否かで処理分岐
            If cmbPart.Text = vbNullString Then
                '@検索ﾎﾞﾀﾝを使用不可
                cmdSearch.Enabled = False
                
                '@板厚/ﾘﾜｰｸ回数を初期化
                cmbBoardThickness.Clear()
                cmbBoardThickness.Enabled = False
                cmbRework.Clear()
                cmbRework.Enabled = False
                
                '@一覧を使用不可
                Call prvvsfPartLotList_Init()
                vsfPartLotList.Enabled = False
            Else
                '@検索ﾎﾞﾀﾝの活性化
                cmdSearch.Enabled = True
            End If
            
            '@ｶﾚﾝﾄ行検索ｷｰを初期化
            mtypChgSort.strKey = vbNullString
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPart_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPart_CloseUp
    '機　能：部品のCloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/14 (Mon) 17:55:58 S.Deguchi
    '更新日：2004/06/14 (Mon) 17:55:58
    '備　考：
    Private Sub cmbPart_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPart.CloseUp

        Try

            '@空欄以外の場合
            If cmbPart.Text <> vbNullString Then
                '@Validate処理へ
                RemoveHandler cmbPart.Validating, AddressOf cmbPart_Validate
                Call cmbPart_Validate(cmbPart, New CancelEventArgs(False))
                AddHandler cmbPart.Validating, AddressOf cmbPart_Validate
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPart_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPart_Validate
    '機　能：部品のValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/06/14 (Mon) 17:56:20 S.Deguchi
    '更新日：2005/03/15 (Tue) 14:03:39 N.Kojima
    '備　考：
    '　　　：2005/03/15 (Tue) 14:03:39 N.Kojima     利用部材を選び直していない場合は初期化しない
    Private Sub cmbPart_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPart.Validating

        Dim llngCnt                     As Integer      'ｶｳﾝﾀ変数
        Dim llngIndex                   As Integer      'ComboのIndex
        Dim llngRCnt                    As Integer      'ﾘﾜｰｸｶｳﾝﾄ
        Dim lstrThicknessClass          As String       '板厚区分
        Dim llngCnt1                    As Integer      'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngCnt2                    As Integer      'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngTempCnt                 As Integer      '一時保管用ｶｳﾝﾄ格納変数
        Dim lblnNextCtrl                As Boolean      'NSYS Focus設定フラグ

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            If ActiveControl.Name = cmbPart.Name OrElse mblnOnValidate Then
                lblnNextCtrl = True
            Else
                lblnNextCtrl = False
            End If

            '@前回と同じ場合は処理しない
            If cmbPart.Text = mstrUsePart Then
                '@板厚が有効か
                If cmbBoardThickness.Enabled = True Then
                    '@板厚にﾌｫｰｶｽｾｯﾄ
                    If lblnNextCtrl Then
                        Call pubSetFocus(cmbBoardThickness)
                    End If
                End If
                
                Exit Sub
            End If
            
            '@次回比較用に部材を格納
            mstrUsePart = cmbPart.Text
            
            '@選択されたIndexを取得
            llngIndex = cmbPart.ListIndex
            
            '@処理分岐
            If cmbPart.Text <> vbNullString Then
                '@ﾍﾞﾝﾀﾞｰ名称を設定
                lblVenderName.Text = mtyppartlist(llngIndex).strVenderName
                
                '@退避領域へ部品IDを格納
                cmbPart.ValueCol = 0
                mstrTaihiPartID = cmbPart.Value
                
                '@板厚区分Combo作成
                lstrThicknessClass = mtyppartlist(llngIndex).strThicknessClass

                With cmbBoardThickness
                    '@活性化
                    .Enabled = True
                    
                    '@板厚情報初期化
                    .Clear()
                    .DirectInput = False
                    .Height = CMlngCmbRowHeight                                     '高さ
                    .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                    .ValueCol = CMlngCmbValueCol1                                   '値取得列
                    .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄せ中央揃え
                    .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, _
                                        .Font.Style, .Font.Unit)                    'ﾌｫﾝﾄｻｲｽﾞ
                    .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _
                                            .GridFont.Style, .GridFont.Unit)        'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ

                    
                    '@板厚情報ｾｯﾄ
                    For llngCnt1 = 0 To mlngThicknessCnt - 1
                        If mtypThicknessClassList(llngCnt1).strThicknessClass = lstrThicknessClass Then
                            llngTempCnt = CLng(mtypThicknessClassList(llngCnt1).strThicknessCount)+1
                            For llngCnt2 = 0 To llngTempCnt - 1
                                If llngCnt2 = 0 Then
                                    .AddItem(CPstrComboAppointNo & vbTab & llngCnt2+1)
                                Else
                                    .AddItem(mtypThicknessClassList(llngCnt1).typThicknessList(llngCnt2 - 1).strThicknessCode & _
                                     vbTab & _
                                     llngCnt2+1)                                            '板厚&Index
                                End If
                            Next llngCnt2
                        End If
                    Next llngCnt1
                    
                    '@「指定なし」を表示
                    .ListIndex = 0
                End With
                
                '@ﾘﾜｰｸ回数Combo作成
                With cmbRework
                    '@活性化
                    .Enabled = True
                
                    '@ﾘﾜｰｸ回数初期化
                    .Clear()
                    .DirectInput = False
                    .Height = CMlngCmbRowHeight                                     '高さ
                    .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                    .ValueCol = CMlngCmbValueCol1                                   '値取得列
                    .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄せ中央揃え
                    .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, _
                                        .Font.Style, .Font.Unit)                    'ﾌｫﾝﾄｻｲｽﾞ
                    .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _
                                            .GridFont.Style, .GridFont.Unit)        'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                    .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                    
                    '@ﾘﾜｰｸ回数が数字ではない場合
                    If IsNumeric(mtyppartlist(llngIndex).strRegenerationCount) = False Then
                        llngRCnt = 0
                    Else
                        llngRCnt = mtyppartlist(llngIndex).strRegenerationCount
                    End If
                    
                    '@ﾘﾜｰｸ回数情報ｾｯﾄ
                    .AddItem(CPstrComboAppointNo)
                    For llngCnt = 0 To llngRCnt
                        .AddItem(llngCnt)                                            'Index(回数)
                    Next llngCnt
                    
                    '@「指定なし」を表示
                    .ListIndex = 0
                End With
                
                '@板厚へｾｯﾄﾌｫｰｶｽ
                If lblnNextCtrl Then
                    Call pubSetFocus(cmbBoardThickness)
                End If
            Else
                If cmdAllClear.Enabled = True Then
                    '@全取消ﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                    If lblnNextCtrl Then
                        Call pubSetFocus(cmdAllClear)
                    End If
                Else
                    '@閉じるﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                    If lblnNextCtrl Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPart_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbBoardThickness_Change
    '機　能：板厚Change処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/01 (Fri) 14:20:56 T.Kitagawa
    '更新日：2004/10/01 (Fri) 14:20:56
    '備　考：
    '　　　：2004/11/17 (Wed) 14:54:19 S.Deguchi    初期化処理に情報取得日時/該当件数も追加
    Private Sub cmbBoardThickness_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBoardThickness.Change

        Try

            '@部品一覧のｸﾘｱ
            Call prvvsfPartLotList_Init()
            vsfPartLotList.Enabled = False

            '@情報取得日時/該当件数欄の初期化
            lblNowDate.Text = vbNullString
            lblLotCnt.Text = vbNullString

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbBoardThickness_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbBoardThickness_CloseUp
    '機　能：板厚CloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/15 (Tue) 09:00:55 S.Deguchi
    '更新日：2004/06/15 (Tue) 09:00:55
    '備　考：
    Private Sub cmbBoardThickness_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBoardThickness.CloseUp

        Try

            '@Validate処理へ
            RemoveHandler cmbBoardThickness.Validating, AddressOf cmbBoardThickness_Validate
            Call cmbBoardThickness_Validate(cmbBoardThickness, New CancelEventArgs(False))
            AddHandler cmbBoardThickness.Validating, AddressOf cmbBoardThickness_Validate
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbBoardThickness_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbBoardThickness_Validate
    '機　能：板厚Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/06/15 (Tue) 09:00:59 S.Deguchi
    '更新日：2004/06/15 (Tue) 09:00:59
    '備　考：
    Private Sub cmbBoardThickness_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbBoardThickness.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@処理分岐
            If cmbBoardThickness.Text <> vbNullString Then
                '@ﾘﾜｰｸ回数へｾｯﾄﾌｫｰｶｽ
                If ActiveControl Is cmbBoardThickness Then
                    Call pubSetFocus(cmbRework)
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbBoardThickness_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbRework_Change
    '機　能：ﾘﾜｰｸ回数Change
    '引　数：なし
    '戻り値：なし
    '作成日：2004/10/01 (Fri) 14:23:10 T.Kitagawa
    '更新日：2004/10/01 (Fri) 14:23:10
    '備　考：
    '　　　：2004/11/17 (Wed) 14:54:19 S.Deguchi    初期化処理に情報取得日時/該当件数も追加
    Private Sub cmbRework_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRework.Change

        Try

            '@部品一覧のｸﾘｱ
            Call prvvsfPartLotList_Init()
            vsfPartLotList.Enabled = False
            
            '@情報取得日時/該当件数欄の初期化
            lblNowDate.Text = vbNullString
            lblLotCnt.Text = vbNullString

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbRework_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbRework_CloseUp
    '機　能：ﾘﾜｰｸ回数CloseUp処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/15 (Tue) 09:02:19 S.Deguchi
    '更新日：2004/06/15 (Tue) 09:02:19
    '備　考：
    Private Sub cmbRework_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRework.CloseUp

        Try
            '@Validate処理へ
            RemoveHandler cmbRework.Validating, AddressOf cmbRework_Validate
            Call cmbRework_Validate(cmbRework, New CancelEventArgs(False))
            AddHandler cmbRework.Validating, AddressOf cmbRework_Validate
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbRework_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbRework_Validate
    '機　能：ﾘﾜｰｸ回数Validate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/06/15 (Tue) 09:02:21 S.Deguchi
    '更新日：2004/06/15 (Tue) 09:02:21
    '備　考：
    Private Sub cmbRework_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbRework.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@処理分岐
            If cmbRework.Text <> vbNullString Then
                '@検索ﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                If ActiveControl Is cmbRework Then
                    Call pubSetFocus(cmdSearch)
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbRework_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbLotManager_CloseUp
    '機　能：ﾛｯﾄ担当ｺﾝﾎﾞ　選択時処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/24 (Wed) 14:03:18 S.Deguchi
    '更新日：2008/06/11 (Wed) 11:07:13 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 11:07:13 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub cmbLotManager_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLotManager.CloseUp

        Try

            '@Validate処理へ
            RemoveHandler cmbLotManager.Validating, AddressOf cmbLotManager_Validate
            Call cmbLotManager_Validate(cmbLotManager, New CancelEventArgs(False))
            AddHandler cmbLotManager.Validating, AddressOf cmbLotManager_Validate
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbLotManager_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbLotManager_Validate
    '機　能：ﾛｯﾄ担当ｺﾝﾎﾞ　Validate処理(選択確定時処理)
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/11/24 (Wed) 14:03:22 S.Deguchi
    '更新日：2008/06/11 (Wed) 11:08:11 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 11:08:11 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub cmbLotManager_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbLotManager.Validating

        Try
            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ﾛｯﾄ担当者IDを格納する
            With cmbLotManager
                .ValueCol = CMlngCmbDispCols1
                mstrLotManagerID = .Value
            End With
            
            '@ｷｬﾘｱID入力欄へｾｯﾄﾌｫｰｶｽ
            If ActiveControl Is cmbLotManager Then
                Call pubSetFocus(txtCarrierID)
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbLotManager_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbThrowinWP_CloseUp
    '機　能：投入装置選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/14 (Mon) 16:21:25 N.Kojima
    '更新日：2005/03/14 (Mon) 16:21:25
    '備　考：
    Private Sub cmbThrowinWP_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbThrowinWP.CloseUp

        Try
            
            '@Validate処理を呼ぶ
            RemoveHandler cmbThrowinWP.Validating, AddressOf cmbThrowinWP_Validate
            Call cmbThrowinWP_Validate(cmbThrowinWP, New CancelEventArgs(False))
            AddHandler cmbThrowinWP.Validating, AddressOf cmbThrowinWP_Validate
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbThrowinWP_CloseUp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbThrowinWP_Validate
    '機　能：投入装置Validate処理
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/15 (Tue) 14:09:04 N.Kojima
    '更新日：2008/06/11 (Wed) 11:08:42 N.Kojima
    '備　考：
    '　　　：2005/03/31 (Thu) 10:58:58 N.Kojima     確定ﾎﾞﾀﾝﾁｪｯｸ処理を追加(不具合№699)
    '　　　：2005/04/12 (Tue) 19:22:35 N.Kojima     確定ﾎﾞﾀﾝﾁｪｯｸ処理を修正(不具合№699)
    '　　　：2007/06/13 (Wed) 11:09:44 N.Kojima     確定ﾎﾞﾀﾝﾁｪｯｸ処理を修正。共通Function化。(案件№01992)
    '　　　：2008/06/11 (Wed) 11:08:42 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub cmbThrowinWP_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbThrowinWP.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@投入装置が選択されている場合
            If cmbThrowinWP.Text <> vbNullString Then
                '@ﾛｯﾄ担当にﾌｫｰｶｽｾｯﾄ
                If ActiveControl Is cmbThrowinWP Then
                    Call pubSetFocus(cmbLotManager)
                End If
            End If
                
            '@確定ﾎﾞﾀﾝの制御処理を行なう
            Call prvcmdRegist_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbThrowinWP_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierID_Change
    '機　能：ｷｬﾘｱID変更処理
    '引　数：なし
    '戻り値：
    '作成日：2004/06/16 (Wed) 13:00:50 S.Deguchi
    '更新日：2007/06/13 (Wed) 09:49:42 N.Kojima
    '備　考：
    '　　　：2005/03/31 (Thu) 13:04:18 N.Kojima     確定ﾎﾞﾀﾝﾁｪｯｸ処理を追加(不具合№699)
    '　　　：2005/04/12 (Tue) 19:07:33 N.Kojima     ｷｬﾘｱ変更時にｽﾛｯﾄﾏｯﾌﾟをﾁｪｯｸする処理追加(不具合№699)
    '　　　：2007/06/13 (Wed) 09:49:42 N.Kojima     確定ﾎﾞﾀﾝﾁｪｯｸ処理を修正。共通Function化。(案件№01992)
    Private Sub txtCarrierID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrierID.Change

        Try

        '@↓2007/06/13 (Wed) 14:21:50 N.Kojima **************************************************

            '@確定ﾎﾞﾀﾝの制御処理を行なう
            Call prvcmdRegist_Chk()
            
        '@↑2007/06/13 (Wed) 14:21:50 N.Kojima **************************************************

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrierID_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtCarrierID_Validate
    '機　能：ｷｬﾘｱIDValidate処理
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/06/15 (Tue) 12:59:36 S.Deguchi
    '更新日：2005/03/31 (Thu) 10:58:58 N.Kojima
    '備　考：
    '　　　：2005/03/31 (Thu) 10:58:58 N.Kojima     確定ﾎﾞﾀﾝﾁｪｯｸ処理を追加(不具合№699)
    '　　　：2005/10/07 (Fri) 12:04:12 S.Deguchi    不具合№2995の対応で,ｷｬﾘｱの状態取得の処理区分を3Zへ変更
    Private Sub txtCarrierID_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtCarrierID.Validating

        Dim ltypCarrCurstate    As CarrCurstate     'ｷｬﾘｱ状態確認構造体
        Dim lstrFormName        As String           'ﾌｫｰﾑ名
        Dim lstrEventName       As String           'ｲﾍﾞﾝﾄ名
        Dim lblnAns             As Boolean          '戻り値

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ｷｬﾘｱIDの空白ﾁｪｯｸ
            If Trim(txtCarrierID.Text) = vbNullString Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの桁ﾁｪｯｸ
            If txtCarrierID.NowByte < txtCarrierID.ChrMaxByte Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0007)
                '@"キャリアIDは6桁で入力してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                e.Cancel = True
                Exit Sub
            End If
            
            '@前回ｷｬﾘｱIDのﾁｪｯｸ
            If mstrCarrierID = txtCarrierID.Text Then
                '@前回ｷｬﾘｱIDと同じ場合
                Exit Sub
            End If
            
            '@投入装置が選択されていない場合
            If cmbThrowinWP.Text = vbNullString Then
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            lstrFormName = Me.Name
            lstrEventName = "txtCarrierID_Validate"
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@ｷｬﾘｱ情報(要求)格納
            With ltypCarrCurstate
                .strCarrierId = txtCarrierID.Text       'ｷｬﾘｱID
                .strClassDivision = CPstrCD3Z           '空ｷｬﾘｱﾁｪｯｸ
                .strMsgVer = CMstrcarrcurstateVer       'MSGVER
                .strSbID = pstrSBID                     '処理区分
                .strCarrierTypeID = CPstrCarrTypeCF     'ｷｬﾘｱﾀｲﾌﾟ(CFｶｾｯﾄ限定)
                .strLotID = vbNullString                'ﾛｯﾄID
            End With

            '@ｷｬﾘｱ状態取得
            lblnAns = pubblnCarrcurstate_Sel(ltypCarrCurstate, True)

            '@取得結果確認
            If lblnAns = True Then
                '@ﾚｽﾎﾟﾝｽ取得終了
                Call publngResponseEnd(lstrFormName, lstrEventName)
                
                '@ｷｬﾘｱIDの退避
                mstrCarrierID = txtCarrierID.Text
            Else
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@TPALｷｬﾘｱIDのｸﾘｱ
                mstrCarrierID = vbNullString
                
                '@ﾌｫｰｶｽそのまま
                e.Cancel = True
                
                Exit Sub
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtCarrierID_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtNumber_Validate
    '機　能：詰数ﾁｪｯｸ
    '引　数：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/06/15 (Tue) 16:08:41 S.Deguchi
    '更新日：2005/03/22 (Tue) 14:24:55 N.Kojima
    '備　考：2005/03/22 (Tue) 14:24:55 N.Kojima     「詰数」が"0","空白"の場合の、ｴﾗｰﾌﾗｸﾞ処理追加(不具合№669)
    Private Sub txtNumber_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtNumber.Validating
        
        Dim llngIndex       As Integer          'ｶｳﾝﾄ

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ｴﾗｰﾌﾗｸﾞ初期化
            mblnErrFlag = False
            
            '@空欄の場合
            If txtNumber.Text = vbNullString Then
                '@ｴﾗｰﾌﾗｸﾞON
                mblnErrFlag = True
                
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005I)
                '@"<TRM5IW>$$詰数の設定が正しくありません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@ﾊﾟﾚｯﾄIDを無効に
                For llngIndex = CMlngtxtPaletteS To CMlngtxtPaletteE
                    txtPalette(llngIndex).Enabled = False
                Next
                
                '@ｽﾛｯﾄﾏｯﾌﾟを無効に
                vsfPaletteList.Enabled = False
                
                '@ﾌｫｰｶｽを「詰数」に留める
                e.Cancel = True
                
                Exit Sub
            Else
                '@詰数が"0"ではない場合
                If CLng(txtNumber.Text) <> 0 Then
                    '@最大詰数を越えていないかﾁｪｯｸ
                    If CLng(txtNumber.Text) > CLng(mstrTaihiNumber) Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0078, mstrTaihiNumber)
                        
                        '@"最大詰数[ %1 ]を越えています。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ｴﾗｰﾌﾗｸﾞON
                        mblnErrFlag = True
                        
                        '@ﾌｫｰｶｽを「詰数」に留める
                        e.Cancel = True
                        
                        Exit Sub
                    Else
                        '@ｴﾗｰﾌﾗｸﾞ正常
                        mblnErrFlag = False
                        
                        '@ｽﾛｯﾄﾏｯﾌﾟを有効に
                        For llngIndex = CMlngtxtPaletteS To CMlngtxtPaletteE
                            txtPalette(llngIndex).Enabled = True
                        Next
                        
                        '@ｽﾛｯﾄﾏｯﾌﾟを有効に
                        vsfPaletteList.Enabled = True
                    End If
                Else
                    '@ｴﾗｰﾌﾗｸﾞON
                    mblnErrFlag = True
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005I)
                    '@"<TRM5IW>$$詰数の設定が正しくありません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@ﾊﾟﾚｯﾄIDを無効に
                    For llngIndex = CMlngtxtPaletteS To CMlngtxtPaletteE
                        txtPalette(llngIndex).Enabled = False
                    Next
                    
                    '@ｽﾛｯﾄﾏｯﾌﾟを無効に
                    vsfPaletteList.Enabled = False
                    
                    '@ﾌｫｰｶｽを「詰数」に留める
                    e.Cancel = True
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtNumber_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    Private Sub txtPalette_Click(ByVal sender As Object, ByVal e As EventArgs) Handles txtPalette00.Click, _
            txtPalette01.Click, txtPalette02.Click, txtPalette03.Click, txtPalette04.Click, txtPalette05.Click, txtPalette06.Click, _
            txtPalette07.Click, txtPalette08.Click, txtPalette09.Click, txtPalette10.Click, txtPalette11.Click, txtPalette12.Click, _
            txtPalette13.Click, txtPalette14.Click, txtPalette15.Click, txtPalette16.Click, txtPalette17.Click

        Dim llngIndex               As Integer
        Dim pstrDBLinkOption        As String
        Dim lstrCommand()           As String
        Dim Index As Integer

        Try
            'ｺﾝﾄﾛｰﾙのIndexを取得する
            Index = Integer.Parse(Strings.Right(CType(sender, Control).Name, 2))
        
            '先頭以外は処理しない
            If Index <> 0 Then
                Exit Sub
            End If
        
            'Ctrlが押されていない場合は処理しない
            If GetKeyState(VK_CONTROL) >= 0 Then
                Exit Sub
            End If
        
            'Altが押されていない場合は処理しない
            If GetKeyState(VK_MENU) >= 0 Then
                Exit Sub
            End If
        
            'ｺﾏﾝﾄﾞﾗｲﾝ引数を分解して変数に格納
            lstrCommand = Split(Command$(), CPstrComma)
            'ﾚｽﾎﾟﾝｽ表示設定(D：開発用環境 (MST01T)、R：公開用環境 (MST01))
            pstrDBLinkOption = lstrCommand(1)
            '接続先が開発機の場合のみ有効
            If pstrDBLinkOption <> "D" Then
                Exit Sub
            End If
        
            '全部のデータを自動設定
            For llngIndex = CMlngtxtPaletteS To CMlngtxtPaletteE
                '一旦、クリア
                txtPalette(llngIndex).Text = vbNullString
                '値を設定
                txtPalette(llngIndex).Text = llngIndex + 1
            Next

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPalette_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
 
    End Sub

    '関数名：txtPalette_LostFocus
    '機　能：LostFocus処理
    '引　数：Index：ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2004/11/17 (Wed) 15:08:55 S.Deguchi
    '更新日：2004/11/17 (Wed) 15:08:55
    '備　考：
    Private Sub txtPalette_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtPalette00.Leave, _
             txtPalette01.Leave,  txtPalette02.Leave,  txtPalette03.Leave,  txtPalette04.Leave,  txtPalette05.Leave,  txtPalette06.Leave, _
             txtPalette07.Leave,  txtPalette08.Leave,  txtPalette09.Leave,  txtPalette10.Leave,  txtPalette11.Leave,  txtPalette12.Leave, _
             txtPalette13.Leave,  txtPalette14.Leave,  txtPalette15.Leave,  txtPalette16.Leave,  txtPalette17.Leave

        Try

            '@ﾌｫｰｶｽ移動の場合にﾀｲﾄﾙ行へﾌｫｰｶｽ移動
            'vsfPaletteList.Row = -1

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPalette_LostFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfPaletteList_Click
    '機　能：ｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/15 (Tue) 19:28:24 S.Deguchi
    '更新日：2004/06/15 (Tue) 19:28:24
    '備　考：
    Private Sub vsfPaletteList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfPaletteList.Click

        Try
            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            'NSYS データ行がない場合は処理を抜ける
            If vsfPaletteList.Rows.Count <= vsfPaletteList.Rows.Fixed OrElse _
                vsfPaletteList.MouseRow < vsfPaletteList.Rows.Fixed Then
                Return
            End If
            
            '@ｽﾛｯﾄﾏｯﾌﾟ反映/取消処理へ
            Call prvvsfPaletteList_Set(CMlngvsfClickFlg)
            
            '@投入確定ﾎﾞﾀﾝEnabled処理へ
            Call prvcmdRegist_Chk()
            
            '@取消ﾎﾞﾀﾝEnabled処理へ
            Call prvCmdClear_Chk()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfPaletteList_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfPartLotList_BeforeSort
    '機　能：ｸﾞﾘｯﾄﾞｿｰﾄ
    '引　数：Col：列
    '　　　：Order：並び順
    '戻り値：
    '備　考：
    Private Sub vsfPartLotList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfPartLotList.BeforeSort

        Try
            'NSYS ソート時はBeforeRowColChange/EnterCellを抑制する
            RemoveHandler vsfPartLotList.BeforeRowColChange, AddressOf vsfPartLotList_BeforeRowColChange
            RemoveHandler vsfPartLotList.EnterCell, AddressOf vsfPartLotList_EnterCell
            mintvsfPartLotListRowBeforeSort = vsfPartLotList.Row 'NSYS ソート前の選択行を保持
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfPartLotList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfPartLotList_AfterSort
    '機　能：ｸﾞﾘｯﾄﾞｿｰﾄ
    '引　数：Col：列
    '　　　：Order：並び順
    '戻り値：
    '作成日：2004/10/19 (Tue) 08:56:07 N.Kasai
    '更新日：2004/10/19 (Tue) 08:56:07
    '備　考：
    Private Sub vsfPartLotList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfPartLotList.AfterSort

        Try
           'NSYS ソート前の選択行が有効行でない場合、ヘッダを選択行とする
            If mintvsfPartLotListRowBeforeSort <  vsfPartLotList.Rows.Fixed Then
                vsfPartLotList.Row = 0
            End If
            'NSYS ソート時のBeforeRowColChange/EnterCellイベントの抑制を解除する
            RemoveHandler vsfPartLotList.BeforeRowColChange, AddressOf vsfPartLotList_BeforeRowColChange
            RemoveHandler vsfPartLotList.EnterCell, AddressOf vsfPartLotList_EnterCell
            AddHandler vsfPartLotList.BeforeRowColChange, AddressOf vsfPartLotList_BeforeRowColChange
            AddHandler vsfPartLotList.EnterCell, AddressOf vsfPartLotList_EnterCell
            'NSYS データ行がない場合は処理を抜ける
            If vsfPartLotList.Rows.Count <= vsfPartLotList.Rows.Fixed Then
                Return
            End If
            
            '@ｿｰﾄ順を格納
            With mtypChgSort
                Dim lChgSortList As ChgSortList = New ChgSortList()
                
                '@ｿｰﾄ列番号を格納
                lChgSortList.lngCol = e.Col
                
                '@並び替え方法を格納(昇順/降順)
                lChgSortList.lngOrder = e.Order
                If IsNothing(.typChgSortList) Then
                    .typChgSortList = New List(Of ChgSortList)()
                End If
                .typChgSortList.Add(lChgSortList)
                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1

            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfPartLotList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfPartLotList_BeforeRowColChange
    '機　能：ｸﾞﾘｯﾄﾞﾌｫｰｶｽ移動
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/10/19 (Tue) 08:58:04 N.Kasai
    '更新日：2004/10/19 (Tue) 08:58:04
    '備　考：
    Private Sub vsfPartLotList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfPartLotList.BeforeRowColChange
        
        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfPartLotList.Rows.Count <= vsfPartLotList.Rows.Fixed Then
                Return
            End If
            
            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(在庫ID)
                mtypChgSort.strKey = vsfPartLotList.GetData(e.NewRange.r1, CMlngvsfPartLLColStockID)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfPartLotList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfPartLotList_EnterCell
    '機　能：利用部材選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/16 (Wed) 12:48:32 S.Deguchi
    '更新日：2012/01/23 (Mon) 10:31:00 T.Oide
    '備　考：
    '　　　：2006/07/24 (Mon) 14:29:01 N.Kojima     ﾃﾞｰﾀ行かの判定処理を改善。元の処理だと、万が一.Row="-1"が返って来た場合に
    '　　　：                                       ｼｽﾃﾑｴﾗｰになることが有り得る。(Err_logにて発覚)
    '　　　：2012/01/23 (Mon) 10:26:41 T.Oide       REQ-1115 不良と払出の区分け対応
    Private Sub vsfPartLotList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfPartLotList.EnterCell

        Dim lblnAns         As Boolean          '入力ﾁｪｯｸ結果格納(True:OK/False:NG)
        Dim llngIndex       As Integer          'ｶｳﾝﾄ

        Try
            
            'NSYS データ行がない場合は処理を抜ける
            If vsfPartLotList.Rows.Count <= vsfPartLotList.Rows.Fixed Then
                Return
            End If
            
            '選択行がﾀｲﾄﾙ以外の場合
            If vsfPartLotList.Row > 0 Then
                
                '@CF編成ﾁｪｯｸ
                lblnAns = prvblnCFInput_Chk()
                '@結果判定
                If lblnAns = True Then
                '@結果：OKの場合
                    '@ﾛｯｸ解除
                    vsfPaletteList.Enabled = True
                    
                    '@ﾊﾟﾚｯﾄID欄の活性化
                    For llngIndex = CMlngtxtPaletteS To CMlngtxtPaletteE
                        txtPalette(llngIndex).Enabled = True
                    Next
                    
                    '@取消ﾎﾞﾀﾝﾁｪｯｸ
                    Call prvCmdClear_Chk()
                Else
                '@結果：NGの場合
                    '@ﾛｯｸ
                    cmdClear.Enabled = False
                    vsfPaletteList.Enabled = False
                    
                    '@ﾊﾟﾚｯﾄID欄の非活性化
                    For llngIndex = CMlngtxtPaletteS To CMlngtxtPaletteE
                        txtPalette(llngIndex).Enabled = False
                    Next
                End If
                
        '@↓2012/01/23 (Mon) 10:27:37 T.Oide **************************************************
                '@在庫不良入力ﾎﾞﾀﾝ有効/無効ﾁｪｯｸ
                Call cmdScrap_Chk()
        '@↑2012/01/23 (Mon) 10:27:37 T.Oide **************************************************
                
            Else
                '@取消ﾎﾞﾀﾝﾁｪｯｸ
                Call prvCmdClear_Chk()
                
                '@投入確定ﾎﾞﾀﾝﾁｪｯｸ処理へ
                Call prvcmdRegist_Chk()
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfPartLotList_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtPalette_Change
    '機　能：ﾊﾟﾚｯﾄID変更時処理
    '引　数：Index：ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2004/09/02 (Thu) 14:51:57 Y.Yamagishi
    '更新日：2006/07/24 (Mon) 14:26:11 N.Kojima
    '備　考：
    '　　　：2006/07/24 (Mon) 14:26:11 N.Kojima     ﾃﾞｰﾀ行かの判定処理を改善。元の処理だと"-1"が返ってくることを想定していない為、
    '　　　：                                       ｼｽﾃﾑｴﾗｰが発生するｹｰｽも有り得る。(Err_logにて発見)
    Private Sub txtPalette_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtPalette00.Change, _
            txtPalette01.Change, txtPalette02.Change, txtPalette03.Change, txtPalette04.Change, txtPalette05.Change, txtPalette06.Change, _
            txtPalette07.Change, txtPalette08.Change, txtPalette09.Change, txtPalette10.Change, txtPalette11.Change, txtPalette12.Change, _
            txtPalette13.Change, txtPalette14.Change, txtPalette15.Change, txtPalette16.Change, txtPalette17.Change

        Dim lstrPrLotID         As String           '製造ﾛｯﾄID退避変数
        Dim lstrCFLotID         As String           '出荷ﾛｯﾄID退避変数
        Dim lstrBT              As String           '板厚退避変数
        Dim lstrRework          As String           'ﾘﾜｰｸ回数退避変数
        Dim lstrStockID         As String           '在庫ﾛｯﾄID退避変数
        Dim Index As Integer

        Try
            'ｺﾝﾄﾛｰﾙのIndexを取得する
            Index = Integer.Parse(Strings.Right(CType(sender, Control).Name, 2))
            
            '@ﾊﾟﾚｯﾄIDが空白以外の場合
            If txtPalette(Index).Text <> vbNullString Then
                '@CFﾛｯﾄ編成ﾘｽﾄの退避領域にﾊﾟﾚｯﾄIDをｾｯﾄ
                vsfPaletteList.SetData(Index + 1, CMlngvsfPaletteLColPaletteID, txtPalette(Index).Text)
                
                '@利用部材一覧の選択された値を取得
                With vsfPartLotList
                    
                    '@ﾀｲﾄﾙ行以外を選択している場合
                    If .Row > CMlngVsfRowTitle Then
                        
                        lstrCFLotID = .GetData(.Row, CMlngvsfPartLLColCFLotID)                                     '出荷ﾛｯﾄID
                        lstrPrLotID = .GetData(.Row, CMlngvsfPartLLColPrLotID)                                     '製造ﾛｯﾄID
                        lstrBT = .GetData(.Row, CMlngvsfPartLLColBoardThickness)                                   '板厚
                        lstrRework = .GetDataDisplay(.Row, CMlngvsfPartLLColRegeneration)                          'ﾘﾜｰｸ回数
                        lstrStockID = .GetData(.Row, CMlngvsfPartLLColStockID)                                     '在庫ﾛｯﾄID
                        
                        '@ｽﾛｯﾄﾏｯﾌﾟへ値を反映
                        vsfPaletteList.SetData(Index + 1, CMlngvsfPaletteLColCFLotID, lstrCFLotID)                '出荷ﾛｯﾄID
                        vsfPaletteList.SetData(Index + 1, CMlngvsfPaletteLColPrLotID, lstrPrLotID)                '製造ﾛｯﾄID
                        vsfPaletteList.SetData(Index + 1, CMlngvsfPaletteLColBoardThickness, lstrBT)              '板厚
                        vsfPaletteList.SetData(Index + 1, CMlngvsfPaletteLColRegeneration, lstrRework)            'ﾘﾜｰｸ回数
                    
                        '@詰数のﾁｪｯｸ(空白の場合投入数の計算でｴﾗｰとなる可能性がある為)
                        If txtNumber.Text <> vbNullString Then
                            vsfPaletteList.SetData(Index + 1, CMlngvsfPaletteLColNum, txtNumber.Text)             '詰数
                        Else
                            vsfPaletteList.SetData(Index + 1, CMlngvsfPaletteLColNum, CMstrDefaultNum)
                        End If
                        
                        vsfPaletteList.SetData(Index + 1, CMlngvsfPaletteLColStockID, lstrStockID)                '在庫ID
                    End If
                End With
            Else
            '@ﾊﾟﾚｯﾄIDが空白の場合
                vsfPaletteList.SetData(Index + 1, CMlngvsfPaletteLColPaletteID, vbNullString)
            
                '@ｽﾛｯﾄﾏｯﾌﾟへ値を反映
                vsfPaletteList.SetData(Index + 1, CMlngvsfPaletteLColCFLotID, vbNullString)                       '出荷ﾛｯﾄID
                vsfPaletteList.SetData(Index + 1, CMlngvsfPaletteLColPrLotID, vbNullString)                       '製造ﾛｯﾄID
                vsfPaletteList.SetData(Index + 1, CMlngvsfPaletteLColBoardThickness, vbNullString)                '板厚
                vsfPaletteList.SetData(Index + 1, CMlngvsfPaletteLColRegeneration, vbNullString)                  'ﾘﾜｰｸ回数
                vsfPaletteList.SetData(Index + 1, CMlngvsfPaletteLColNum, vbNullString)                           '詰数
                vsfPaletteList.SetData(Index + 1, CMlngvsfPaletteLColStockID, vbNullString)                       '在庫ID
            End If
            
            '@投入数合計計算処理へ
            Call prvThrowNum_Set()
            
            '@投入確定ﾎﾞﾀﾝEnabled処理へ
            Call prvcmdRegist_Chk()
            
            '@取消ﾎﾞﾀﾝEnabled処理へ
            Call prvCmdClear_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPalette_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtPalette_Validate
    '機　能：ﾊﾟﾚｯﾄID確定処理
    '引　数：Index：ｲﾝﾃﾞｯｸｽ
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2004/09/02 (Thu) 13:57:49 Y.Yamagishi
    '更新日：2004/09/02 (Thu) 13:57:49
    '備　考：
    Private Sub txtPalette_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtPalette00.Validating, _
            txtPalette01.Validating, txtPalette02.Validating, txtPalette03.Validating, txtPalette04.Validating, txtPalette05.Validating, txtPalette06.Validating, 
            txtPalette07.Validating, txtPalette08.Validating, txtPalette09.Validating, txtPalette10.Validating, txtPalette11.Validating, txtPalette12.Validating, 
            txtPalette13.Validating, txtPalette14.Validating, txtPalette15.Validating, txtPalette16.Validating, txtPalette17.Validating

        Dim lblnAns             As Integer          '結果
        Dim Index As Integer

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@投入数合計計算処理へ
            Call prvThrowNum_Set()
            
            'ｺﾝﾄﾛｰﾙのIndexを取得する
            Index = Integer.Parse(Strings.Right(CType(sender, Control).Name, 2))

            '@ﾊﾟﾚｯﾄIDが空白以外の場合
            If txtPalette(Index).Text <> vbNullString Then
                '@ﾊﾟﾚｯﾄID重複ﾁｪｯｸ
                lblnAns = prvblnPaletteID_Chk(Index)
                If lblnAns = False Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0081, mstrTaihiNumber)
                    '@"ﾊﾟﾚｯﾄIDが重複しています。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    e.Cancel = True

                    Exit Sub
                End If
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPalette_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtPalette_GotFocus
    '機　能：ﾊﾟﾚｯﾄIDﾌｫｰｶｽ取得時処理
    '引　数：Index：ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2004/09/02 (Thu) 17:30:48 Y.Yamagishi
    '更新日：2004/09/02 (Thu) 17:30:48
    '備　考：
    Private Sub txtPalette_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtPalette00.Enter, _
            txtPalette01.Enter, txtPalette02.Enter, txtPalette03.Enter, txtPalette04.Enter, txtPalette05.Enter, txtPalette06.Enter, 
            txtPalette07.Enter, txtPalette08.Enter, txtPalette09.Enter, txtPalette10.Enter, txtPalette11.Enter, txtPalette12.Enter, 
            txtPalette13.Enter, txtPalette14.Enter, txtPalette15.Enter, txtPalette16.Enter, txtPalette17.Enter

        Dim Index As Integer

        Try
            If Not mblnErrFlag Then
	            'ｺﾝﾄﾛｰﾙのIndexを取得する
	            Index = Integer.Parse(Strings.Right(CType(sender, Control).Name, 2))
	
	            '@ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行変更
	            vsfPaletteList.Row = Index + 1
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtPalette_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdScrap_Click
    '機　能：不良入力をするために部材管理画面を呼び出す
    '引　数：なし
    '戻り値：
    '作成日：2012/01/19 (Thu) 15:41:50 T.Oide
    '更新日：2012/01/24 (Tue) 13:38:26 T.Oide
    '備　考：
    Private Sub cmdScrap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdScrap.Click

        Dim lstrKeyID           As String           'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow          As Integer          '現在行を格納
        Dim ltypInvPart         As typInvPartClass  '在庫管理引継ぎ構造体初期化用

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
            
            '@引継ぎ構造体に格納
            ptypInvPart = ltypInvPart     '一旦初期化
            With vsfPartLotList
            
                '@ﾀｲﾄﾙ以外か
                If .Row > CMlngVsfRowTitle Then
                    ptypInvPart.strPartID = cmbPart.Value                                  '部品ID
                    ptypInvPart.strInvLotId = .GetData(.Row, CMlngvsfPartLLColStockID)     '在庫ID
                    ptypInvPart.strParentForm = Me.Text                                    '親ﾌｫｰﾑ
                End If
                
            End With
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfPartLotList
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfPartLLColStockID)
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@在庫管理画面ﾛｰﾄﾞ
            frmxxEN0230.Instance = New frmxxEN0230()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxEN0230.Instance = Nothing
                Exit Sub
            End If
            
            '@在庫管理画面起動
            frmxxEN0230.Instance.ShowDialog(Me)
            frmxxEN0230.Instance = Nothing

            '@最新取得処理
            Call cmdSearch_Click(cmdSearch, New EventArgs())

            '@ﾌｫｰｶｽ戻り位置を設定
        '@↓2012/01/24 (Tue) 13:16:52 T.Oide **************************************************
        '    Call prvFocus_Set(vsfPartLotList, lstrKeyID, CMlngvsfPartLLColCFLotID, llngTopRow)
            Call pubGridFocus_Set(vsfPartLotList, lstrKeyID, CMlngvsfPartLLColCFLotID, cmdClose)
        '@↑2012/01/24 (Tue) 13:16:52 T.Oide **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdScrap_Click"
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
    '関数名：prvfrmxxEN00B0_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/14 (Mon) 13:08:33 S.Deguchi
    '更新日：2012/01/23 (Mon) 10:13:09 T.Oide
    '備　考：
    '　　　：2004/10/04 (Mon) 11:49:02 H.Wajima     ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ設定処理追加
    '　　　：2004/11/24 (Wed) 13:49:21 S.Deguchi    技術担当者の初期化処理を追加
    '　　　：2005/03/15 (Tue) 13:07:31 N.Kojima     投入装置追加に伴う修正(改善№577)
    '　　　：2008/06/11 (Wed) 11:09:35 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2012/01/23 (Mon) 10:13:09 T.Oide       REQ-1115 不良と払出ぬ区分け対応
    Private Sub prvfrmxxEN00B0_Init()

        Dim lctlControl     As Control          'ｺﾝﾄﾛｰﾙ名称取得用変数
        Dim llngIndex       As Integer          'ｶｳﾝﾄ
        Dim lstrFormTitle   As String           'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN00B0, lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@退避領域の初期化
            mstrTaihiPartID = vbNullString
            mstrTaihiNumber = vbNullString
            mstrLotManagerID = vbNullString
            mstrUsePart = vbNullString
            
            '@各Comboﾎﾞｯｸｽの初期化
            cmbScreenSize.Clear()                                   '画面ｻｲｽﾞ
            cmbPD.Clear()                                           '機種
            cmbPart.Clear()                                         '部材
            cmbRework.Clear()                                       'ﾘﾜｰｸ回数
            cmbBoardThickness.Clear()                               '板厚
            cmbLotManager.Clear()                                   'ﾛｯﾄ担当
            cmbThrowinWP.Clear()                                    '投入装置

            cmbScreenSize.Enabled = True                            '画面ｻｲｽﾞ

            '@Comboﾎﾞｯｸｽ設定(外枠設定のみ)
            For Each lctlControl In Me.Controls
                If TypeOf lctlControl Is GroupBox Then
                    For Each lctlobj As Control In lctlControl.Controls
                        If TypeOf lctlobj Is ComboBoxEx Then
                            With CType(lctlobj, ComboBoxEx)
                                '@初期化
                                .DirectInput = False                                   '直接入力(Flase)
                                .DispCols = CMlngCmbDispCols1                          'ｸﾞﾘｯﾄﾞ表示列数
                                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, _
                                                 .Font.Style, .Font.Unit)              'ﾌｫﾝﾄｻｲｽﾞ
                                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _
                                                     .GridFont.Style, .GridFont.Unit)  'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                                .RowHeight = CMlngCmbRowHeight                         'ﾘｽﾄ行の高さ
                                .BackColor = Color.White                               'ﾊﾞｯｸｶﾗｰの初期化
                            End With
                        End If
                    Next
                End If
            Next
            
            '@各Comboﾎﾞｯｸｽの初期化
            cmbScreenSize.Enabled = True                            '画面ｻｲｽﾞ
            cmbPD.Enabled = False                                   '機種
            cmbPart.Enabled = False                                 '部材
            cmbRework.Enabled = False                               'ﾘﾜｰｸ回数
            cmbBoardThickness.Enabled = False                       '板厚
            cmbLotManager.Enabled = False                           'ﾛｯﾄ担当
            cmbThrowinWP.Enabled = False                            '投入装置
            
            '@Textﾎﾞｯｸｽの初期化
            txtCarrierID.Text = vbNullString                        'ｷｬﾘｱID
            txtNumber.Text = vbNullString                           '詰数
            mstrCarrierID = vbNullString                            'ｷｬﾘｱID退避ｸﾘｱ
            
            '@ﾊﾟﾚｯﾄID
            For llngIndex = CMlngtxtPaletteS To CMlngtxtPaletteE
                txtPalette(llngIndex).Text = vbNullString
            Next
            
            '@ﾃｷｽﾄﾎﾞｯｸｽの活性化
            txtCarrierID.Enabled = False                            'ｷｬﾘｱID
            cmdCarrierSelect.Enabled = False                        '空きｷｬﾘｱﾎﾞﾀﾝ
            txtNumber.Enabled = False                               '詰数
            '@ﾊﾟﾚｯﾄID
            For llngIndex = CMlngtxtPaletteS To CMlngtxtPaletteE
                txtPalette(llngIndex).Enabled = False
            Next
            
            '@ﾗﾍﾞﾙの初期化
            lblVenderName.Text = vbNullString                    'ﾍﾞﾝﾀﾞｰ名称
            lblNowDate.Text = vbNullString                       '情報取得時間
            lblLotCnt.Text = vbNullString                        '該当件数
            lblCfLotID.Text = vbNullString                       '作成CFﾛｯﾄID
            lblMaxNum.Text = vbNullString                        '最大詰数
            lblThrowNum.Text = vbNullString                      '投入数
            lblEntryID.Text = vbNullString                       'ｴﾝﾄﾘ
            
            
            '@vsfPartLotListの初期化
            Call prvvsfPartLotList_Init()
            
            Call prvvsfPaletteList_Disp()
            
            '@Commandﾎﾞﾀﾝの初期化
            cmdAllClear.Enabled = False                             '全取消
            cmdPdChange.Enabled = False                             '機種変更
            cmdRegist.Enabled = False                               '確定
            cmdSearch.Enabled = False                               '検索
            cmdClear.Enabled = False                                '取消
            cmdEntry.Enabled = False                                'ｴﾝﾄﾘﾎﾞﾀﾝ
        '@↓2012/01/23 (Mon) 10:14:25 T.Oide **************************************************
            cmdScrap.Enabled = False                                '在庫不良入力
        '@↑2012/01/23 (Mon) 10:14:25 T.Oide **************************************************

            '@閉じるﾎﾞﾀﾝのCausesValidationを設定する
            cmdClose.CausesValidation = False
            '@空きｷｬﾘｱ一覧のCausesValidationを設定する
            cmdCarrierSelect.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN00B0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfPartLotList_Init
    '機　能：利用部材一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/14 (Mon) 13:23:56 S.Deguchi
    '更新日：2012/01/23 (Mon) 10:41:34 T.Oide
    '備　考：
    Private Sub prvvsfPartLotList_Init()

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfPartLotList
                .Redraw = False
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear(ClearFlags.Content)
                
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                .AllowSorting = AllowSortingEnum.SingleColumn
                        
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                '.Ellipsis = flexEllipsisEnd
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                
                '@一覧表の表題設定
                Dim cellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngvsfPartLLColNo, CMlngVsfRowTitle, CMlngvsfPartLLColStockID)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                                                       '文字色
                headerStyle.BackColor =  ColorTranslator.FromWin32(CPlngBlueColor)                                                         '背景色
                headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMlngVsfHFontSize, headerStyle.Font.Style, headerStyle.Font.Unit) 'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                                                         '文字位置
                headerStyle.Trimming = StringTrimming.None                                                                                 'NSYS ﾍｯﾀﾞは省略表示なしに設定
                cellRange.Style = headerStyle

                '@列幅、ﾀｲﾄﾙ設定
                .Cols(CMlngvsfPartLLColNo).Width = CMlngvsfPartLLWColNo
                .SetData(CMlngVsfRowTitle, CMlngvsfPartLLColNo, CMstrvsfPartLLColNo)                          'No.

                .Cols(CMlngvsfPartLLColCFLotID).Width = CMlngvsfPartLLWColCFLotID
                .SetData(CMlngVsfRowTitle, CMlngvsfPartLLColCFLotID, CMstrvsfPartLLColCFLotID)                '出荷ﾛｯﾄID

                .Cols(CMlngvsfPartLLColPrLotID).Width = CMlngvsfPartLLWColPrLotID
                .SetData(CMlngVsfRowTitle, CMlngvsfPartLLColPrLotID, CMstrvsfPartLLColPrLotID)                '製造ﾛｯﾄID

                .Cols(CMlngvsfPartLLColRegeneration).Width = CMlngvsfPartLLWColRegeneration
                .SetData(CMlngVsfRowTitle, CMlngvsfPartLLColRegeneration, CMstrvsfPartLLColRegeneration)      'ﾘﾜｰｸ回数

                .Cols(CMlngvsfPartLLColBoardThickness).Width = CMlngvsfPartLLWColBoardThickness
                .SetData(CMlngVsfRowTitle, CMlngvsfPartLLColBoardThickness, CMstrvsfPartLLColBoardThickness)  '板厚

                .Cols(CMlngvsfPartLLColNum).Width = CMlngvsfPartLLWColNum
                .SetData(CMlngVsfRowTitle, CMlngvsfPartLLColNum, CMstrvsfPartLLColNum)                        '枚数

                .Cols(CMlngvsfPartLLColStockID).Width = CMlngvsfPartLLWColStockID
                .SetData(CMlngVsfRowTitle, CMlngvsfPartLLColStockID, CMstrvsfPartLLColStockID)                '在庫ID

                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight    '高さ
                
                '@在庫IDを非表示にする
                .Cols(CMlngvsfPartLLColStockID).Visible = False
                
                .Redraw = True

                '@ﾛｯｸ
                .Enabled = False
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.None

            End With
             
        '@↓2012/01/23 (Mon) 10:27:37 T.Oide **************************************************
            '@在庫不良入力ﾎﾞﾀﾝ有効/無効ﾁｪｯｸ
            Call cmdScrap_Chk()
        '@↑2012/01/23 (Mon) 10:27:37 T.Oide **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfPartLotList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfPartLotList_Disp
    '機　能：取得した利用部材を一覧表示
    '引　数：ltypPartLotList()：部材ﾛｯﾄﾘｽﾄ格納ﾃﾞｰﾀ
    '　　　：llngpartlotlistcnt：部材ﾛｯﾄﾘｽﾄｶｳﾝﾄ数
    '戻り値：なし
    '作成日：2004/06/15 (Tue) 11:13:42 S.Deguchi
    '更新日：2004/10/21 (Thu) 13:02:48 Y.Yamagishi
    '備　考：
    '　　　：2004/10/21 (Thu) 13:02:48 Y.Yamagishi  保留の場合は表示しない(不具合改善№147)
    Private Sub prvvsfPartLotList_Disp(ByRef ltypPartLotList As List(Of PartLotList), _
                                       ByVal llngPartLotListCnt As Integer)

        Dim lstrFormatNum           As String               '該当件数ﾌｫｰﾏｯﾄ変更
        Dim llngDoCnt               As Integer              'ｶｳﾝﾄ
        Dim llngCnt                 As Integer              'ｶｳﾝﾄ
        Dim llngRow                 As Integer              '行ｶｳﾝﾄ

        Try
            
            With vsfPartLotList
                If llngPartLotListCnt = 0 Then
                '@格納ﾃﾞｰﾀがない場合
                    '@部材一覧表示情報初期化
                    Call prvvsfPartLotList_Init()
                    
                    Exit Sub
                Else
                '@格納ﾃﾞｰﾀがある場合
                    '@部材一覧表示情報初期化
                    Call prvvsfPartLotList_Init()
                    
                    'NSYS 不要イベント発生抑止
                    RemoveHandler vsfPartLotList.BeforeRowColChange, AddressOf vsfPartLotList_BeforeRowColChange
                    RemoveHandler vsfPartLotList.EnterCell, AddressOf vsfPartLotList_EnterCell

                    '@描画ﾛｯｸ
                    .Redraw = False
                    
                    Dim newStyle As CellStyle = .Styles.Add("CustomStyle__ForeColor_vbBlack_BackColor_vbWhite")
                    newStyle.ForeColor = Color.Black
                    newStyle.BackColor = Color.White
                    Dim cellRange As CellRange
                    '@行ｶｳﾝﾀの初期化
                    llngRow = 0
                    For llngDoCnt = 0 To llngPartLotListCnt - 1
                        '@現在状態が保留以外の場合
                        If ltypPartLotList(llngDoCnt).strCurrentStatus <> CPstrClass4J Then
                            '@行ｶｳﾝﾀｶｳﾝﾄｱｯﾌﾟ
                            llngRow = llngRow + 1
                            
                            '@行数設定
                            .Rows.Count = llngRow + 1
                            
                            .SetData(llngRow, CMlngvsfPartLLColCFLotID, ltypPartLotList(llngDoCnt).strShippingLotID)                   '出荷ﾛｯﾄID
                                
                            .SetData(llngRow, CMlngvsfPartLLColPrLotID, ltypPartLotList(llngDoCnt).strProductionLotId)                 '製造ﾛｯﾄID
                                
                            .SetData(llngRow, CMlngvsfPartLLColBoardThickness, ltypPartLotList(llngDoCnt).strThicknessCode)            '板厚
                                
                            .SetData(llngRow, CMlngvsfPartLLColRegeneration,ltypPartLotList(llngDoCnt).strReworkCount)                 'ﾘﾜｰｸ回数
                            
                            If IsNumeric(ltypPartLotList(llngDoCnt).strNum) Then
                                .SetData(llngRow, CMlngvsfPartLLColNum, _
                                         Format$(CInt(ltypPartLotList(llngDoCnt).strNum), CPstrDateFormatKanma))                       '受入数
                            Else
                                .SetData(llngRow, CMlngvsfPartLLColNum, ltypPartLotList(llngDoCnt).strNum)                             '受入数
                            End If
                                
                            .SetData(llngRow, CMlngvsfPartLLColStockID, ltypPartLotList(llngDoCnt).strLotID)                           '在庫ID
                                            
                            '@ｾﾙ色変更 '白色
                            '@ﾌｫﾝﾄ色変更'黒色
                            cellRange = .GetCellRange(llngRow, CMlngVsfColTitle, llngRow, .Cols.Count - 2)
                            cellRange.Style = newStyle
                                                            
                            '@ｽﾛｯﾄの高さの設定
                            .Rows(llngRow).Height = CMlngVsfHeight
                        End If
                    Next
                    
                    '@表示位置設定
                    .Cols(CMlngvsfPartLLColCFLotID).TextAlign = TextAlignEnum.LeftCenter               '左中央
                    .Cols(CMlngvsfPartLLColPrLotID).TextAlign = TextAlignEnum.LeftCenter               '左中央
                    .Cols(CMlngvsfPartLLColBoardThickness).TextAlign = TextAlignEnum.LeftCenter        '左中央
                    .Cols(CMlngvsfPartLLColRegeneration).TextAlign = TextAlignEnum.RightCenter         '右中央
                    .Cols(CMlngvsfPartLLColNum).TextAlign = TextAlignEnum.RightCenter                  '右中央
                    .Cols(CMlngvsfPartLLColStockID).TextAlign = TextAlignEnum.RightCenter              '右中央
                    
                    '@行表示
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        .Rows(llngCnt).Visible = True
                    Next llngCnt
                    
                    '@№設定
                    For llngDoCnt = 1 To .Rows.Count - 1
                        .SetData(llngDoCnt, CMlngvsfPartLLColNo, llngDoCnt)
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngDoCnt).Height = CMlngVsfHeight
                    Next llngDoCnt

                    '@ｽﾛｯﾄ№のｾﾝﾀﾘﾝｸﾞ
                    .Cols(CMlngvsfPartLLColNo).TextAlign = TextAlignEnum.RightCenter      '右中央
                    
                    '@件数ﾒｯｾｰｼﾞ表示
                    lstrFormatNum = Format$(llngDoCnt - 1, CPstrDateFormatKanma)
                    lblLotCnt.Text = lstrFormatNum
                    
                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort.lngCnt - 1
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSort.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort.typChgSortList(llngCnt).lngOrder
                            .Sort(SortFlags.UseColSort,mtypChgSort.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If

                    'NSYS 不要イベント発生抑止解除
                    AddHandler vsfPartLotList.BeforeRowColChange, AddressOf vsfPartLotList_BeforeRowColChange
                    AddHandler vsfPartLotList.EnterCell, AddressOf vsfPartLotList_EnterCell
                    
                    '@ｿｰﾄ検索用ｷｰ(ｷｬﾘｱID)がある場合
                    If mtypChgSort.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@在庫IDが同じ場合
                            If .GetData(llngCnt, CMlngvsfPartLLColStockID) = mtypChgSort.strKey Then
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                                Call pubVsfBeforeSort(vsfPartLotList, CMlngVsfColTitle)
                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
                                Call pubVsfAfterSort(vsfPartLotList, CMlngVsfColTitle)
                                Exit For
                            End If
                        Next llngCnt
                    Else
                        '@先頭ﾍﾟｰｼﾞ設定
                        .TopRow = CMlngVsfRowTitle

                        '@ﾀｲﾄﾙ行に行設定
                        .Row = CMlngVsfRowTitle
                    End If
                    
                    '@描画ﾛｯｸ解除
                    .Redraw = True
                    
                    '@ﾛｯｸ解除
                    .Enabled = True
                End If
            End With
            
            '@情報取得日時を表示
            lblNowDate.Text = Format$(Now, CPstrDateFormat)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfPartLotList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfPaletteList_Init
    '機　能：編成ﾛｯﾄ一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/14 (Mon) 13:24:45 S.Deguchi
    '更新日：2006/10/18 (Wed) 10:57:54 M.Miura
    '備　考：
    '　　　：2006/10/18 (Wed) 10:57:54 M.Miura    ｽﾛｯﾄ№のﾀｲﾄﾙをNULLに変更(案件№01288)
    Public Sub prvvsfPaletteList_Init()

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfPaletteList
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear(ClearFlags.Content)

                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                
                '@一覧表の表題設定
                Dim cellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngvsfPaletteLColNo, CMlngVsfRowTitle, CMlngvsfPaletteLColStockID)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                                                       '文字色
                headerStyle.BackColor =  ColorTranslator.FromWin32(CPlngBlueColor)                                                         '背景色
                headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMlngVsfHFontSize, headerStyle.Font.Style, headerStyle.Font.Unit) 'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                                                         '文字位置
                headerStyle.Trimming = StringTrimming.None                                                                                 'NSYS ﾍｯﾀﾞは省略表示なしに設定
                cellRange.Style = headerStyle

                '@列幅、ﾀｲﾄﾙ設定
                .Cols(CMlngvsfPaletteLColNo).Width = CMlngvsfPaletteLWColNo

                .Cols(CMlngvsfPaletteLColPaletteID).Width = CMlngvsfPaletteLWColPaletteID
                .SetData(CMlngVsfRowTitle, CMlngvsfPaletteLColPaletteID, CMstrvsfPaletteLColPaletteID)            'ﾊﾟﾚｯﾄID

                .Cols(CMlngvsfPaletteLColCFLotID).Width = CMlngvsfPaletteLWColCFLotID
                .SetData(CMlngVsfRowTitle, CMlngvsfPaletteLColCFLotID, CMstrvsfPaletteLColCFLotID)                '出荷ﾛｯﾄID

                .Cols(CMlngvsfPaletteLColPrLotID).Width = CMlngvsfPaletteLWColPrLotID
                .SetData(CMlngVsfRowTitle, CMlngvsfPaletteLColPrLotID, CMstrvsfPaletteLColPrLotID)                '製造ﾛｯﾄID

                .Cols(CMlngvsfPaletteLColRegeneration).Width = CMlngvsfPaletteLWColRegeneration
                .SetData(CMlngVsfRowTitle, CMlngvsfPaletteLColRegeneration, CMstrvsfPaletteLColRegeneration)      'ﾘﾜｰｸ回数

                .Cols(CMlngvsfPaletteLColBoardThickness).Width = CMlngvsfPaletteLWColBoardThickness
                .SetData(CMlngVsfRowTitle, CMlngvsfPaletteLColBoardThickness, CMstrvsfPaletteLColBoardThickness)  '板厚

                .Cols(CMlngvsfPaletteLColNum).Width = CMlngvsfPaletteLWColNum
                .SetData(CMlngVsfRowTitle, CMlngvsfPaletteLColNum, CMstrvsfPaletteLColNum)                        '枚数
                
                .Cols(CMlngvsfPaletteLColStockID).Width = CMlngvsfPaletteLWColStockID
                .SetData(CMlngVsfRowTitle, CMlngvsfPaletteLColStockID, CMstrvsfPaletteLColStockID)                '在庫ID

                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight    '高さ

                '@在庫IDを非表示にする
                .Cols(CMlngvsfPaletteLColStockID).Visible = False
                
                '@ﾊﾟﾚｯﾄIDを非表示にする
                .Cols(CMlngvsfPaletteLColPaletteID).Visible = False
                
                '@ﾛｯｸ
                .Enabled = False

                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.None

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfPaletteList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfPaletteList_Disp
    '機　能：ﾊﾟﾚｯﾄ一覧表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/15 (Tue) 13:10:27 S.Deguchi
    '更新日：2012/01/23 (Mon) 10:36:46 T.Oide
    '備　考：
    '　　　：2004/09/29 (Wed) 21:31:08 N.Kasai      出荷ﾛｯﾄID表示左寄せ
    '　　　：2006/10/18 (Wed) 10:57:54 M.Miura      ｽﾛｯﾄ順を18→01に変更(案件№01288)
    '　　　：2012/01/23 (Mon) 10:26:41 T.Oide       REQ-1115 不良と払出の区分け対応
    Private Sub prvvsfPaletteList_Disp()

        Dim llngCnt As Integer

        Try
            
            With vsfPaletteList
                '@ﾊﾟﾚｯﾄ一覧表示情報初期化
                Call prvvsfPaletteList_Init()
                
                '@描画ﾛｯｸ
                .Redraw = False
                
                '@行数設定
                .Rows.Count = CPlngPaletteSlot + 1
                            
                '@表示位置設定
                .Cols(CMlngvsfPaletteLColPaletteID).TextAlign = TextAlignEnum.LeftCenter               '左中央
                .Cols(CMlngvsfPaletteLColCFLotID).TextAlign = TextAlignEnum.LeftCenter                 '左中央
                .Cols(CMlngvsfPaletteLColPrLotID).TextAlign = TextAlignEnum.LeftCenter                 '左中央
                .Cols(CMlngvsfPaletteLColBoardThickness).TextAlign = TextAlignEnum.LeftCenter          '左中央
                .Cols(CMlngvsfPaletteLColRegeneration).TextAlign = TextAlignEnum.RightCenter           '右中央
                .Cols(CMlngvsfPaletteLColNum).TextAlign = TextAlignEnum.RightCenter                    '右中央
                .Cols(CMlngvsfPaletteLColStockID).TextAlign = TextAlignEnum.RightCenter                '右中央
                
                '@行表示
                For llngCnt = .Rows.Fixed To .Rows.Count - 1
                    .Rows(llngCnt).Visible = True
                Next llngCnt
                
                '@№設定
                For llngCnt = 1 To .Rows.Count - 1
                    .SetData(.Rows.Count - llngCnt, CMlngvsfPartLLColNo, Format$(llngCnt, CPstrSlotNoFormat))
                    '@ｽﾛｯﾄの高さの設定
                    .Rows(llngCnt).Height = CMlngVsfHeight
                Next llngCnt
                '@ｽﾛｯﾄ№のｾﾝﾀﾘﾝｸﾞ
                .Cols(CMlngvsfPartLLColNo).TextAlign = TextAlignEnum.RightCenter    '右中央
                
                '@描画ﾛｯｸ解除
                .Redraw = True
                
                '@ｽﾌﾟﾚｯﾄﾞを初期値へ移動
                .LeftCol = CMlngVsfColTitle   '列
                .TopRow = CMlngVsfRowTitle    '行
                .Row = CMlngVsfRowTitle       'ｶﾚﾝﾄ行の移動
            End With
            
        '@↓2012/01/23 (Mon) 10:27:37 T.Oide **************************************************
                '@在庫不良入力ﾎﾞﾀﾝ有効/無効ﾁｪｯｸ
                Call cmdScrap_Chk()
        '@↑2012/01/23 (Mon) 10:27:37 T.Oide **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfPaletteList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbScreenSize_Disp
    '機　能：画面ｻｲｽﾞCombo作成
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/14 (Mon) 14:22:57 S.Deguchi
    '更新日：2004/06/14 (Mon) 14:22:57
    '備　考：
    Private Sub prvcmbScreenSize_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbScreenSize
                '@ｽｸﾘｰﾝｻｲｽﾞ初期化
                .Clear()
                .DirectInput = False
                .Height = CMlngCmbRowHeight                                                 '高さ
                .DispCols = CMlngCmbDispCols1                                               'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol1                                               '値取得列
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter                  '左寄中央揃え
                .ColAlignment(CMlngCmbGridCol1) = TextAlignEnum.LeftCenter                  '左寄中央揃え
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, _
                                    .Font.Style, .Font.Unit)                                'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _
                                        .GridFont.Style, .GridFont.Unit)                    'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                              'ﾘｽﾄ行の高さ
                
                '@画面ｻｲｽﾞ情報ｾｯﾄ
                For llngCnt = 0 To mtypScreenSizeList.lngScreenSizeListCnt - 1
                    .AddItem(mtypScreenSizeList.typScreenList(llngCnt).strScreenSizeID & _
                             vbTab & _
                             mtypScreenSizeList.typScreenList(llngCnt).strChipCount)         '画面ｻｲｽﾞID&詰数
                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbScreenSize_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbPd_Disp
    '機　能：機種Combo作成
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/14 (Mon) 14:23:00 S.Deguchi
    '更新日：2005/07/22 (Fri) 09:01:42 N.Kasai
    '備　考：
    '　　　：2005/07/22 (Fri) 09:01:42 N.Kasai  L/R対応
    Private Sub prvcmbPd_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbPD
                '@ｽｸﾘｰﾝｻｲｽﾞ初期化
                .Clear()
                .DirectInput = False
                .Height = CMlngCmbRowHeight                                     '高さ
                .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol1                                   '値取得列
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .ColAlignment(CMlngCmbGridCol1) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .BackColor = Color.White                                        'ﾊﾞｯｸｶﾗｰ(白)
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, _
                                    .Font.Style, .Font.Unit)                    'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _
                                        .GridFont.Style, .GridFont.Unit)        'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                
                '@機種情報ｾｯﾄ('機種ID&機種ID名称 & PDﾊﾞｰｼﾞｮﾝ & Null & ForeColor & BackColor
                For llngCnt = 0 To mlngProductListCnt - 1
                    .AddItem(mtypProductList(llngCnt).strProductID & _
                            vbTab & _
                            mtypProductList(llngCnt).strProductName & _
                            vbTab & _
                            mtypProductList(llngCnt).strMasPdVersion & _
                            vbTab & _
                            vbNullString & _
                            vbTab & _
                            mtypProductList(llngCnt).strForeColor & _
                            vbTab & _
                            mtypProductList(llngCnt).strBackColor)
                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbPd_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbPart_Disp
    '機　能：部材Combo作成
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/14 (Mon) 17:25:41 S.Deguchi
    '更新日：2004/06/14 (Mon) 17:25:41
    '備　考：
    Private Sub prvcmbPart_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbPart
                '@ｽｸﾘｰﾝｻｲｽﾞ初期化
                .Clear()
                .Height = CMlngCmbRowHeight                                         '高さ
                .DispCols = CMlngCmbDispCols2                                       'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol3                                       '値取得列
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter          '左寄中央揃え
                .ColAlignment(CMlngCmbGridCol1) = TextAlignEnum.LeftCenter          '左寄中央揃え
                .GroupCols = CMlngCmbGroupCol                                       '表示Col数
                .GroupRows = CMlngCmbGroupRow                                       '表示Row数
                .DirectInput = False                                                '直接入力不可
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, _
                                    .Font.Style, .Font.Unit)                        'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _
                                        .GridFont.Style, .GridFont.Unit)            'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                      'ﾘｽﾄ行の高さ
                
                '@部材情報ｾｯﾄ
                If mlngpartlistcnt > 0 Then
                    For llngCnt = 0 To mlngpartlistcnt - 1
                        .AddItem(mtyppartlist(llngCnt).strPartCode & _
                                 vbTab & _
                                 mtyppartlist(llngCnt).strPartName & _
                                 vbTab & _
                                 mtyppartlist(llngCnt).strPartCode & CPstrComboBrank & mtyppartlist(llngCnt).strPartName & _
                                 vbTab & _
                                 llngCnt)                                            'ID&名称&ID+名称&Index
                    Next llngCnt
                End If
                .GetCol = CMlngCmbDispCols2                                         '取得列
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbPart_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbLotManager_Disp
    '機　能：ﾛｯﾄ担当ｺﾝﾎﾞ作成処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/11/24 (Wed) 13:52:49 S.Deguchi
    '更新日：2008/06/11 (Wed) 11:10:11 N.Kojima
    '備　考：
    '　　　：2008/06/11 (Wed) 11:10:11 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    Private Sub prvCmbLotManager_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbLotManager

                .Clear()
                .DirectInput = False
                .Height = CMlngCmbRowHeight                                                 '高さ
                .DispCols = CMlngCmbDispCols1                                               'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol1                                               '値取得列
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter                  '左寄中央揃え
                .ColAlignment(CMlngCmbGridCol1) = TextAlignEnum.LeftCenter                  '左寄中央揃え
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, _
                                    .Font.Style, .Font.Unit)                                'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _
                                        .GridFont.Style, .GridFont.Unit)                    'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                              'ﾘｽﾄ行の高さ
                
                '@ﾛｯﾄ担当者情報ｾｯﾄ
                '@空欄ありの為,最初の1行は空欄をｾｯﾄ
                .AddItem(CPstrSpace & vbTab & CPstrSpace)
                
                '@取得した情報を書き込む
                For llngCnt = 0 To mlngLotManagerListCnt - 1
                    
                    '@ｺﾝﾎﾞ内容設定：ﾛｯﾄ担当名&ﾛｯﾄ担当者ID
                    .AddItem(mtypLotManagerList(llngCnt).strTechManName & _
                             vbTab & _
                             mtypLotManagerList(llngCnt).strTechManID)
                Next llngCnt
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbLotManager_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfraCF_Init
    '機　能：CF編成ﾌﾚｰﾑを初期化する
    '引　数：なし
    '戻り値：
    '作成日：2004/06/15 (Tue) 11:19:02 S.Deguchi
    '更新日：2012/01/23 (Mon) 10:35:56 T.Oide
    '備　考：
    Private Sub prvfraCF_Init()

        Try

            '@Textﾎﾞｯｸｽの活性化
            txtCarrierID.Enabled = True
            txtNumber.Enabled = True
            
            '@空きｷｬﾘｱﾎﾞﾀﾝ
            cmdCarrierSelect.Enabled = True
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfraCF_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfraPart_Init
    '機　能：利用部材ﾌﾚｰﾑを初期化する
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/14 (Mon) 17:35:15 S.Deguchi
    '更新日：2004/06/14 (Mon) 17:35:15
    '備　考：
    Private Sub prvfraPart_Init()

        Try

            '@Comboのｸﾘｱ
            cmbPart.Clear()
            cmbBoardThickness.Clear()
            cmbRework.Clear()
            
            cmbPart.Enabled = False
            cmbBoardThickness.Enabled = False
            cmbRework.Enabled = False
            
            '@ﾗﾍﾞﾙの初期化
            lblVenderName.Text = vbNullString
            
            '@利用部材一覧の初期化
            Call prvvsfPartLotList_Init()
            
            '@検索ﾎﾞﾀﾝの非活性化
            cmdSearch.Enabled = False
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfraPart_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvfraPart_Set
    '機　能：部材を取得する
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/14 (Mon) 17:04:48 S.Deguchi
    '更新日：2004/06/14 (Mon) 17:04:48
    '備　考：
    Private Sub prvfraPart_Set(Optional lblnFocus As Boolean = True)

        Try
            
            '@利用部材ﾌﾚｰﾑ/部品Comboを利用可能状態にする
            cmbPart.Enabled = True
                
            '@部品情報表示
            Call prvcmbPart_Disp()

            '@部品情報の件数ﾁｪｯｸ(件数によって処理を分岐)
            If mlngpartlistcnt = 1 Then
                '@取得件数が1件
                cmbPart.ListIndex = mlngpartlistcnt - 1                         '取得した1件を表示
                
                mblnOnValidate = lblnFocus
                RemoveHandler cmbPart.Validating, AddressOf cmbPart_Validate
                Call cmbPart_Validate(cmbPart, New CancelEventArgs(False))      '部品のValidateｲﾍﾞﾝﾄを呼び出す
                AddHandler cmbPart.Validating, AddressOf cmbPart_Validate
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfraPart_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
        
        Finally
            mblnOnValidate = False
        End Try
    End Sub

    '関数名：prvvsfPaletteList_Set
    '機　能：ﾊﾟﾚｯﾄﾘｽﾄ反映/取消処理
    '引　数：llngEventFlg:ｲﾍﾞﾝﾄﾌﾗｸﾞ　1:ｸﾘｯｸｲﾍﾞﾝﾄ<CMlngvsfClickFlg>
    '　　　：　　　　　　　　　　　　　2:反映ﾎﾞﾀﾝ<CMlngcmdReflectFlg>
    '　　　：　　　　　　　　　　　　　3:取消ﾎﾞﾀﾝ<CMlngcmdClearFlg>
    '戻り値：なし
    '作成日：2004/06/21 (Mon) 14:46:52 S.Deguchi
    '更新日：2006/07/24 (Mon) 14:22:23 N.Kojima
    '備　考：
    '　　　：2006/07/24 (Mon) 14:22:23 N.Kojima     ｲﾍﾞﾝﾄLogより発見。元の処理だとﾍｯﾀﾞｰ行(№)が選択された時にｼｽﾃﾑｴﾗｰになる。
    Private Sub prvvsfPaletteList_Set(ByVal llngEventFlg As Integer)

        Dim lstrPrLotID As String           '製造ﾛｯﾄID退避変数
        Dim lstrCFLotID As String           '出荷ﾛｯﾄID退避変数
        Dim lstrBT      As String           '板厚退避変数
        Dim lstrRework  As String           'ﾘﾜｰｸ回数退避変数
        Dim lstrStockID As String           '在庫ﾛｯﾄID退避変数

        Try
            
            '@利用部材一覧の選択された値を取得
            With vsfPartLotList
                    
                '@CF編成一覧が選択されている場合に処理を行う
                If vsfPaletteList.Row > 0 Then
                    
                    '@選択箇所が空欄の場合
                    If vsfPaletteList.GetData(vsfPaletteList.Row, CMlngvsfPaletteLColCFLotID) = vbNullString Then
                        '@取消ﾎﾞﾀﾝの場合は反映しない
                        If llngEventFlg = CMlngcmdClearFlg Then
                            Exit Sub
                        End If
                        
                        '@ﾀｲﾄﾙ以外
                        If .Row > 0 Then
                        
                            lstrCFLotID = .GetData(.Row, CMlngvsfPartLLColCFLotID)                         '出荷ﾛｯﾄID
                            lstrPrLotID = .GetData(.Row, CMlngvsfPartLLColPrLotID)                         '製造ﾛｯﾄID
                            lstrBT = .GetData(.Row, CMlngvsfPartLLColBoardThickness)                       '板厚
                            lstrRework = .GetDataDisplay(.Row, CMlngvsfPartLLColRegeneration)              'ﾘﾜｰｸ回数
                            lstrStockID = .GetData(.Row, CMlngvsfPartLLColStockID)                         '在庫ﾛｯﾄID
                        
                            '@ｽﾛｯﾄﾏｯﾌﾟへ値を反映
                            vsfPaletteList.SetData(vsfPaletteList.Row, CMlngvsfPaletteLColCFLotID, lstrCFLotID)     '出荷ﾛｯﾄID
                                
                            vsfPaletteList.SetData(vsfPaletteList.Row, CMlngvsfPaletteLColPrLotID, lstrPrLotID)     '製造ﾛｯﾄID
                                
                            vsfPaletteList.SetData(vsfPaletteList.Row, CMlngvsfPaletteLColBoardThickness, lstrBT)   '板厚
                                
                            vsfPaletteList.SetData(vsfPaletteList.Row, CMlngvsfPaletteLColRegeneration, lstrRework) 'ﾘﾜｰｸ回数
                            
                            '@詰数が空欄ではない場合
                            If txtNumber.Text <> vbNullString Then
                                vsfPaletteList.SetData(vsfPaletteList.Row, CMlngvsfPaletteLColNum, txtNumber.Text)  '詰数
                            Else
                                vsfPaletteList.SetData(vsfPaletteList.Row, CMlngvsfPaletteLColNum, CMlngDisp0)      '詰数:0
                            End If
                            
                            vsfPaletteList.SetData(vsfPaletteList.Row, CMlngvsfPaletteLColStockID, lstrStockID)     '在庫ID
                        End If
                    Else
                    '@選択箇所が空欄ではない場合
                        '@ｽﾛｯﾄﾏｯﾌﾟへ空欄を反映
                        vsfPaletteList.SetData(vsfPaletteList.Row, CMlngvsfPaletteLColPaletteID, vbNullString)      'ﾊﾟﾚｯﾄID
                            
                        vsfPaletteList.SetData(vsfPaletteList.Row, CMlngvsfPaletteLColCFLotID, vbNullString)        '出荷ﾛｯﾄID
                            
                        vsfPaletteList.SetData(vsfPaletteList.Row, CMlngvsfPaletteLColPrLotID, vbNullString)        '製造ﾛｯﾄID
                            
                        vsfPaletteList.SetData(vsfPaletteList.Row, CMlngvsfPaletteLColBoardThickness, vbNullString) '板厚
                            
                        vsfPaletteList.SetData(vsfPaletteList.Row, CMlngvsfPaletteLColRegeneration, vbNullString)   'ﾘﾜｰｸ回数
                        
                        vsfPaletteList.SetData(vsfPaletteList.Row, CMlngvsfPaletteLColNum, vbNullString)            '詰数
                            
                        vsfPaletteList.SetData(vsfPaletteList.Row, CMlngvsfPaletteLColStockID, vbNullString)        '在庫ID
                            
                        '@ﾊﾟﾚｯﾄID取消
                        txtPalette(vsfPaletteList.Row - 1).Text = vbNullString
                    End If
                End If
            End With
            
            '@投入数計算処理
           Call prvThrowNum_Set()
           
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfPaletteList_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvThrowNum_Set
    '機　能：投入数計算
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/02 (Thu) 17:53:08 Y.Yamagishi
    '更新日：2004/09/02 (Thu) 17:53:08
    '備　考：
    Private Sub prvThrowNum_Set()

        Dim llngCnt                 As Integer  'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngTotalNumber         As Integer  '詰数合計

        Try
            
            '@初期化
            llngTotalNumber = 0
            
            '@投入数計算
            With vsfPaletteList
                For llngCnt = 1 To .Rows.Count - 1
                    If .GetData(llngCnt, CMlngvsfPartLLColNum) <> vbNullString Then
                        '@数値ﾁｪｯｸ
                        If IsNumeric(.GetData(llngCnt, CMlngvsfPaletteLColNum)) = True Then
                            llngTotalNumber = llngTotalNumber + CLng(.GetData(llngCnt, CMlngvsfPaletteLColNum))
                        End If
                    End If
                Next llngCnt
                
                '@投入数表示
                lblThrowNum.Text = llngTotalNumber
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvThrowNum_Set"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmdRegist_Chk
    '機　能：投入確定ﾎﾞﾀﾝﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/21 (Mon) 15:15:09 S.Deguchi
    '更新日：2007/06/13 (Wed) 14:13:47 N.Kojima
    '備　考：
    '　　　：2005/03/16 (Wed) 14:54:43 N.Kojima     投入装置追加に伴う修正(改善№577)
    '　　　：2007/06/13 (Wed) 14:13:47 N.Kojima     確定ﾎﾞﾀﾝの制御処理の共通化に伴い、処理修正。(案件№01992)
    '　　　：2011/06/27 (Mon) 09:42:00 M.Sakka      確定ボタンの制御を全面改訂
    Private Sub prvcmdRegist_Chk()

        Dim llngCnt          As Integer  'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngSkipCount    As Integer  'スキップカウント

        'エラーハンドラの設定
        Try
            
            '確定ボタンを無効に設定
            cmdRegist.Enabled = False
            
            '@投入装置が未選択の場合
            If cmbThrowinWP.Text = vbNullString Then
                Exit Sub
            End If
            
            '@ｷｬﾘｱIDの入力桁数が6桁未満、または未入力か
            If txtCarrierID.NowByte <> txtCarrierID.ChrMaxByte Or _
                txtCarrierID.Text = vbNullString Then
                Exit Sub
            End If
            
            '@投入数のﾁｪｯｸ
            If IsNumeric(lblThrowNum.Text) = True Then
                If CLng(lblThrowNum.Text) = 0 Then
                    Exit Sub
                End If
            End If

            '@確定ﾎﾞﾀﾝの制御ﾁｪｯｸ
            With vsfPaletteList
                'スキップカウントを初期化
                llngSkipCount = 0
            
                '登録可能なスロット数全数チェック
                For llngCnt = 1 To CPlngPaletteSlot
                    '@ｽﾛｯﾄﾏｯﾌﾟに情報が反映されていているか
                    If .GetData(llngCnt, CMlngvsfPaletteLColCFLotID) = vbNullString Then
                        '@ﾊﾟﾚｯﾄIDが入力されているか
                        If txtPalette(llngCnt - 1).Text = vbNullString Then
                            'パレットIDもスロットマップも未入力のケース(処理は継続)
                            llngSkipCount = llngSkipCount + 1
                        Else
                            'パレットIDは設定されているが、スロットマップが未入力のケース(以降処理不要)
                            Exit Sub
                        End If
                    Else
                        '@ﾊﾟﾚｯﾄIDが入力されているか
                        If txtPalette(llngCnt - 1).Text = vbNullString Then
                            'スロットマップは設定されているが、パレットIDが未入力のケース(以降処理不要)
                            Exit Sub
                        End If
                    End If
                Next llngCnt
            End With
            
            '全スキップ以外は確定ボタンを有効に設定
            If llngSkipCount <> CPlngPaletteSlot Then
                cmdRegist.Enabled = True
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmdRegist_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvCmdClear_Chk
    '機　能：取消ﾎﾞﾀﾝﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/21 (Mon) 16:43:11 S.Deguchi
    '更新日：2004/09/02 (Thu) 14:41:26 Y.Yamagishi
    '備　考：
    Private Sub prvCmdClear_Chk()

        Dim llngRoopCnt         As Integer  'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngInputFlg        As Integer  '入力ﾌﾗｸﾞ(1:入力無,2:入力有)

        Try
            
            '@初期化
            llngRoopCnt = 1
            llngInputFlg = 1
            
            '@反映/取消ﾎﾞﾀﾝの活性化ﾁｪｯｸ
            With vsfPaletteList
                For llngRoopCnt = 1 To .Rows.Count - 1
                    If .GetData(llngRoopCnt, CMlngvsfPaletteLColCFLotID) <> vbNullString Then
                    '@出荷IDに値が存在する場合
                        llngInputFlg = 2
                        
                        Exit For
                    End If
                Next llngRoopCnt

                '@ﾌﾗｸﾞから取消ﾎﾞﾀﾝの判別
                If llngInputFlg = 2 Then
                    cmdClear.Enabled = True
                Else
                    cmdClear.Enabled = False
                End If
            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvCmdClear_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdScrap_Chk
    '機　能：在庫不良入力ﾎﾞﾀﾝの有効/無効ﾁｪｯｸ
    '引　数：なし
    '戻り値：
    '作成日：2012/01/23 (Mon) 10:20:54 T.Oide
    '更新日：2012/01/23 (Mon) 10:20:54
    '備　考：
    Private Sub cmdScrap_Chk()

        'エラーハンドラの設定
        Try
            
            '@部材一覧のｸﾞﾘｯﾄﾞのﾃﾞｰﾀを選択中か
            If vsfPartLotList.Row > 0 Then
            
                '在庫不良入力ﾎﾞﾀﾝを有効に設定
                cmdScrap.Enabled = True
            Else
            
                '在庫不良入力ﾎﾞﾀﾝを無効に設定
                cmdScrap.Enabled = False
            
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdScrap_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvblnThrowInfo_Chk
    '機　能：投入予定項目ﾁｪｯｸ
    '引　数：なし
    '戻り値：True:入力OK/False:入力NG
    '作成日：2004/06/14 (Mon) 16:32:27 S.Deguchi
    '更新日：2004/06/14 (Mon) 16:32:27
    '備　考：
    Private Function prvblnThrowInfo_Chk() As Boolean

        Try

            prvblnThrowInfo_Chk = False
            
            '@画面ｻｲｽﾞﾁｪｯｸ
            If cmbScreenSize.Text = vbNullString Then
                Exit Function
            End If
            
            '@機種ﾁｪｯｸ
            If cmbPD.Text = vbNullString Then
                Exit Function
            End If
            
            '@工順Ver.ﾁｪｯｸ
            If lblEntryID.Text = vbNullString Then
                Exit Function
            End If
            
            prvblnThrowInfo_Chk = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnThrowInfo_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnCFInput_Chk
    '機　能：CF編成項目ﾁｪｯｸ
    '引　数：なし
    '戻り値：True:入力OK/False:入力NG
    '作成日：2004/06/15 (Tue) 18:08:47 S.Deguchi
    '更新日：2006/07/24 (Mon) 14:32:36 N.Kojima
    '備　考：
    '　　　：2006/07/24 (Mon) 14:32:36 N.Kojima     ﾃﾞｰﾀ行かの判定処理を改善。元の処理だと、万が一.Row="-1"が返って来た場合に
    '　　　：                                       ｼｽﾃﾑｴﾗｰが発生することも有り得る。(Err_logにて発覚)
    Private Function prvblnCFInput_Chk() As Boolean
        
        Try

            prvblnCFInput_Chk = False
            
            '@利用部材選択ﾁｪｯｸ
            If vsfPartLotList.Row <= 0 Then
                Exit Function
            End If
            
            '@詰数入力ﾁｪｯｸ
            If txtNumber.Text = vbNullString Then
                '@空白の場合
                Exit Function
            Else
                If CLng(txtNumber.Text) = 0 Then
                    '0の場合
                    Exit Function
                End If
                If CLng(txtNumber.Text) > CLng(mstrTaihiNumber) Then

                    Exit Function
                End If
            End If
            
            prvblnCFInput_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnCFInput_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnPaletteID_Chk
    '機　能：ﾊﾟﾚｯﾄID重複ﾁｪｯｸ
    '引　数：llngIndex:ｲﾝﾃﾞｯｸｽ
    '戻り値：True:入力OK/False:入力NG
    '作成日：2004/06/21 (Mon) 10:18:21 S.Deguchi
    '更新日：2004/09/02 (Thu) 14:10:35 Y.Yamagishi
    '備　考：
    Private Function prvblnPaletteID_Chk(ByVal llngIndex As Integer) As Boolean

        Dim llngCnt As Integer  'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            prvblnPaletteID_Chk = True

            '@重複ﾁｪｯｸ実行
            '@index0～17まで
            For llngCnt = CMlngtxtPaletteS To CMlngtxtPaletteE
                '@indexが違う場合
                If llngIndex <> llngCnt Then
                    '@ﾊﾟﾚｯﾄIDが重複している場合
                    If txtPalette(llngIndex).Text = txtPalette(llngCnt).Text Then
                        prvblnPaletteID_Chk = False
            
                        Exit For
                    End If
                End If
            Next llngCnt

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnPaletteID_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvblnRegist_Chk
    '機　能：投入確定ﾁｪｯｸ(投入数と詰数、ﾊﾟﾚｯﾄﾏｯﾌﾟ、ﾊﾟﾚｯﾄID)
    '引　数：なし
    '戻り値：True:入力OK/False:入力NG
    '作成日：2004/06/28 (Mon) 09:30:31 S.Deguchi
    '更新日：2007/06/13 (Wed) 09:54:31 N.Kojima
    '備　考：
    '　　　：2007/06/13 (Wed) 09:54:31 N.Kojima     ｽﾛｯﾄﾏｯﾌﾟ&ﾊﾟﾚｯﾄIDの確定前入力ﾁｪｯｸを追加。(案件№01992)
    Private Function prvblnRegist_Chk() As Boolean

        Dim llngCnt                 As Integer  'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngCnt2                As Integer  'ﾙｰﾌﾟｶｳﾝﾄ2
        Dim llngTotalNumber         As Integer  '詰数合計
        Dim lstrRegeneration        As String   'ﾘﾜｰｸ回数

        Try
            
            '@ﾁｪｯｸ処理初期化
            prvblnRegist_Chk = False
            
            '@初期化
            llngTotalNumber = 0
            
        '@↓2007/06/13 (Wed) 09:56:48 N.Kojima **************************************************
            
        '    '@詰数の合計
            '@ｽﾛｯﾄﾏｯﾌﾟ&ﾊﾟﾚｯﾄIDのﾁｪｯｸ、詰数の合計数の格納
            With vsfPaletteList
                For llngCnt = 1 To .Rows.Count - 1
                
                    '@ｽﾛｯﾄﾏｯﾌﾟにﾃﾞｰﾀが反映されているか
                    If .GetData(llngCnt, CMlngvsfPaletteLColCFLotID) = vbNullString And _
                        txtPalette(llngCnt - 1).Text <> vbNullString Then
                        
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000W, fraPart.Text)
                        '@"<TRM0WW>$$[利用部材]が設定されていません。設定を見直してください。"を表示する
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ﾌｫｰｶｽの移動
                        Call pubSetFocus(vsfPaletteList)
                        .Row = llngCnt
                        
                        Exit Function
                    Else
                        '@ﾊﾟﾚｯﾄIDが入力されているか
                        If .GetData(llngCnt, CMlngvsfPaletteLColCFLotID) <> vbNullString And _
                            txtPalette(llngCnt - 1).Text = vbNullString Then
                            
                            '@表示ﾒｯｾｰｼﾞ変換
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000W, lblPaletteIDTitle.Text)
                            '@"<TRM0WW>$$[パレットID]が設定されていません。設定を見直してください。"を表示する
                            Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            
                            '@ﾌｫｰｶｽの移動
                            Call pubSetFocus(txtPalette(llngCnt - 1))
                            Exit Function
                        End If
                    End If
                    
                    '@枚数がNULL以外か
                    If .GetData(llngCnt, CMlngvsfPaletteLColNum) <> vbNullString Then
                        llngTotalNumber = llngTotalNumber + CLng(.GetData(llngCnt, CMlngvsfPaletteLColNum))
                    End If
                Next llngCnt
            End With
            
        '@↑2007/06/13 (Wed) 09:56:48 N.Kojima **************************************************
            
            '@詰数合計と投入数の比較
            If llngTotalNumber <> CLng(lblThrowNum.Text) Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar0088)
                '@"投入数と詰数の合計が一致しません。設定を見直してください。"
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                
                '@合致しない場合、投入中止
                '@ﾌｫｰｶｽの移動
                Call pubSetFocus(vsfPaletteList)
                Exit Function
            End If
            
            '@RW回数のﾁｪｯｸ
            With vsfPaletteList
                For llngCnt = 1 To .Rows.Count - 1
                    '@ﾃﾞｰﾀがある初めの行をﾁｪｯｸ
                    If .GetData(llngCnt, CMlngvsfPaletteLColRegeneration) <> vbNullString Then
                        '@ﾃﾞｰﾀがある初めの行のRW回数を退避
                        lstrRegeneration = .GetData(llngCnt, CMlngvsfPaletteLColRegeneration)
                        Exit For
                    End If
                Next llngCnt
                
                '@ﾘﾜｰｸ回数のﾁｪｯｸ
                For llngCnt2 = llngCnt To .Rows.Count - 1
                    '@一行目のRW回数と異なる場合ｴﾗｰﾒｯｾｰｼﾞを表示する
                    If .GetData(llngCnt2, CMlngvsfPaletteLColRegeneration) <> vbNullString And _
                        .GetData(llngCnt2, CMlngvsfPaletteLColRegeneration) <> lstrRegeneration Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000V)
                        '@"リワーク回数は混載できません。設定を見直してください。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ﾌｫｰｶｽの移動
                        Call pubSetFocus(vsfPaletteList)
                        .Row = 1
                        Exit Function
                    End If
                Next llngCnt2
            End With
            
            '@ﾁｪｯｸOK
            prvblnRegist_Chk = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvblnRegist_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvfrmxxEN00B0_Minit
    '機　能：Private変数等の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2004/09/08 (Wed) 08:55:24 M.Miura
    '更新日：2012/01/19 (Thu) 16:08:41 T.Oide
    '備　考：
    '　　　：2004/11/17 (Wed) 15:06:33 S.Deguchi    ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ初期化処理を追加
    '　　　：2004/11/24 (Wed) 16:19:48 S.Deguchi    技術担当者構造体のｸﾘｱ処理を追加
    '　　　：2008/06/11 (Wed) 11:12:37 N.Kojima     技術担当をﾛｯﾄ担当に変更。(案件№02884)
    '　　　：2012/01/19 (Thu) 16:08:41 T.Oide       REQ-1115 不良と払出の区別対応
    Private Sub prvfrmxxEN00B0_Minit()

        Dim mtypScreenSizeListInit  As ScreenSizeList   '初期化用ｽｸﾘｰﾝｻｲｽﾞ格納変数
        Dim ltypInvPart             As typInvPartClass  '初期化用

        Try
            
            '@ｿｰﾄ保持用構造体のｸﾘｱ
            If IsNothing(mtypChgSort.typChgSortList) Then
                mtypChgSort.typChgSortList = New List(Of ChgSortList)()
            Else
                mtypChgSort.typChgSortList.Clear()
            End If
            
            '@使用構造体の初期化
            'ｽｸﾘｰﾝｻｲｽﾞ
            If IsNothing(mtypScreenSizeList.typScreenList) Then
                mtypScreenSizeList.typScreenList = New List(Of ScreenList)()
            Else
                mtypScreenSizeList.typScreenList.Clear()
            End If
            mtypScreenSizeList = mtypScreenSizeListInit     'ｽｸﾘｰﾝｻｲｽﾞｶｳﾝﾄ数
            '機種
            If IsNothing(mtypProductList) Then
                mtypProductList = New List(Of ProductList)()
            Else
                mtypProductList.Clear()
            End If
            Erase mtypSeqList                             '工順
            '部品
            If IsNothing(mtyppartlist) Then
                mtyppartlist = New List(Of PartClassList)()
            Else
                mtyppartlist.Clear()
            End If
            'Erase mtypThicknessClassList()                  '板厚
            'Erase mtypLotManagerList()                      'ﾛｯﾄ担当
        '@↓2012/01/19 (Thu) 16:08:29 T.Oide **************************************************
            ptypInvPart = ltypInvPart                       '画面情報引継ぎ用構造体初期化
        '@↑2012/01/19 (Thu) 16:08:29 T.Oide **************************************************
            
            '@仕様変数初期化
            mlngProductListCnt = 0                          '機種格納数
            mlngOrderListCnt = 0                            '工順Ver.格納数'
            mlngpartlistcnt = 0                             '部品格納数
            mlngThicknessCnt = 0                            '板厚区分数
            mstrTaihiPartID = vbNullString                  '部品ID
            mstrTaihiVenderID = vbNullString                'ﾍﾞﾝﾀﾞｰ種別ID
            mstrTaihiNumber = vbNullString                  '詰め数格納
            mblnFormLoadFlag = False                        'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN00B0_Minit"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvMasEntryList_Sel
    '機　能：ﾛｯﾄ工順情報取得処理
    '引　数：なし
    '戻り値：なし
    '作成日：2004/08/19 (Thu) 20:09:17 N.Kasai
    '更新日：2004/09/02 (Thu) 10:02:05 Y.Yamagishi
    '備　考：
    '　　　：2004/09/02 (Thu) 10:02:05 Y.Yamagishi  WF枚数取得
    Private Function prvMasEntryList_Sel(Optional ByVal lblnFocus As Boolean = True) As Boolean

        Dim lblnAns                     As Boolean          '戻り値(True/False)
        Dim ltypEntryList               As List(Of EntryList)        'ﾏｽﾀ工順取得構造体
        Dim llngEntryListCnt            As Integer          'ﾏｽﾀ工順取得件数
        Dim lstrProductID               As String           'ﾛｰｶﾙ機種変数格納
        Dim lstrClassDivision           As String           '処理区分
        Dim ltypMasPartlist             As MasPartlist      '部材ｺｰﾄﾞﾘｽﾄ要求構造体

        Try
            
            '@初期化
            prvMasEntryList_Sel = False
            
            '@機種設定
            lstrProductID = cmbPD.Text
            
            '@機種指定確認
            If lstrProductID = vbNullString Then
                Exit Function
            Else
                '@機種ｴﾝﾄﾘ取得
                lstrClassDivision = CPstrCD07   'ClassDivision 07:ｴﾝﾄﾘIDの適用日が最新のものを検索する
                lblnAns = pubblnmasPdEntryList_Sel(CMstrmas_pdentrylistVer, _
                                                   lstrProductID, _
                                                   ltypEntryList, _
                                                   llngEntryListCnt, _
                                                   pstrSBID, lstrClassDivision)
                '@結果判定
                If lblnAns = False Then
                    Exit Function
                End If
            End If
                    
            '@機種ｴﾝﾄﾘが取得できた場合のみ(最新の機種ｴﾝﾄﾘ情報が１件返ってくる)
            If llngEntryListCnt > 0 Then
                '@ｴﾝﾄﾘID表示処理
                lblEntryID.Text = ltypEntryList(0).strEntryID

                 '@部材ｺｰﾄﾞﾘｽﾄ要求構造体へ格納
                With ltypMasPartlist
                    .strSbID = pstrSBID                     '処理区分
                    .strMsgVer = CMstrmas_partlistVer       'ﾒｯｾｰｼﾞVersion
                    .strPdId = cmbPD.Text                   '機種ID
                    
                    '@PDﾊﾞｰｼﾞｮﾝ取得
                    cmbPD.ValueCol = CMlngCmbValueCol2
                    .strMasPdVersion = cmbPD.Value          'PDVersion
                    .strVenderClassId = mstrTaihiVenderID   '部品ID(部材ID)
                End With
                                
                '@部材ｺｰﾄﾞ、ﾍﾞﾝﾀﾞｰ取得
                lblnAns = pubblnMasPartList_Sel(ltypMasPartlist, _
                                                mlngpartlistcnt, _
                                                mtyppartlist)
                '@結果判定
                If lblnAns = False Then
                        
                    Exit Function
                End If
            
                '@利用部材ﾌﾚｰﾑの設定
                Call prvfraPart_Set(lblnFocus)

                If cmbPart.Enabled = True Then
                    '@部材Comboへｾｯﾄﾌｫｰｶｽ
                    If lblnFocus Then
                        Call pubSetFocus(cmbPart)
                    End If
                Else
                    '@閉じるへｾｯﾄﾌｫｰｶｽ
                    If lblnFocus Then
                        Call pubSetFocus(cmdClose)
                    End If
                End If
            End If
            
            '@成功を返す
            prvMasEntryList_Sel = True
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvMasEntryList_Sel"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvcmbThrowinWP_Disp
    '機　能：投入装置をｺﾝﾎﾞへｾｯﾄ
    '引　数：なし
    '戻り値：なし
    '作成日：2005/03/14 (Mon) 16:15:36 N.Kojima
    '更新日：2005/03/14 (Mon) 16:15:36
    '備　考：
    Private Sub prvcmbThrowinWP_Disp()

        Dim llngCnt                 As Integer  'ｶｳﾝﾄ

        Try
                
            '@投入装置ｾｯﾄ
            With cmbThrowinWP
                .Clear()                                                    '初期化
                .DispCols = CMlngCmbDispCols1                               'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridCol0                                  'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridCol1                                '値取得列
                .DirectInput = False                                        'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, _
                                 .Font.Style, .Font.Unit)                   'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, _
                                     .GridFont.Style, .GridFont.Unit)       'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                              '行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter  '左中央
                
                For llngCnt = 0 To mlngWpListCnt - 1
                    .AddItem(ptypWPList(llngCnt).strWpName & vbTab & ptypWPList(llngCnt).strWpID)
                Next llngCnt
                
                '@装置が1件の場合、ﾃﾞﾌｫﾙﾄ表示
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
                .strProcName = "prvcmbThrowinWP_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2012/01/24 (Tue) 13:17:09 T.Oide **************************************************共通関数pubGridFocus_Setに変更
    '@'関数名：prvFocus_Set
    '@'機　能：ﾌｫｰｶｽの戻り位置を設定
    '@'引　数：lobjControl: VSFlexGridオブジェクト
    '@'　　　：lstrKeyID：KeyID
    '@'　　　：llngKeyColNo：KeyIDのCol位置
    '@'　　　：llngTopRow：先頭行
    '@'戻り値：なし
    '@'作成日：2004/07/28 (Wed) 11:04:48 N.Kasai
    '@'更新日：2004/07/28 (Wed) 19:21:36 N.Kasai
    '@'備　考：ﾛｯﾄNoを検索してHitした場合は該当行にﾌｫｰｶｽｾｯﾄする。ない場合はｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
    '@Private Sub prvFocus_Set(ByVal lobjControl As VSFlexGrid, _
    '@                         ByVal lstrKeyID As String, _
    '@                         ByVal llngKeyColNo As Long, _
    '@                         ByVal llngTopRow As Long)
    '@
    '@    Dim llngRowCnt     As Long         'ｶｳﾝﾄ
    '@
    '@    On Error GoTo Error_Handler
    '@
    '@    With lobjControl
    '@        '@確定ﾎﾞﾀﾝ押下前のﾌｫｰｶｽ位置を検索
    '@        For llngRowCnt = 0 To .Rows - 1
    '@            '@ﾛｯﾄNo検索
    '@            If .Cell(flexcpText, llngRowCnt, llngKeyColNo) = lstrKeyID Then
    '@
    '@                '@行の選択範囲を設定
    '@                .Row = llngRowCnt
    '@
    '@                '@選択行を表示
    '@                .ShowCell llngRowCnt, llngKeyColNo
    '@                Exit Sub
    '@            End If
    '@        Next llngRowCnt
    '@
    '@        '@ﾌｫｰｶｽｾｯﾄ
    '@        '@明細行が１件もない場合ﾌｫｰｶｽの戻り位置を制御
    '@        If .Enabled = False Then
    '@            Call pubSetFocus(cmdClose)
    '@        Else
    '@            Call pubSetFocus(lobjControl)
    '@        End If
    '@    End With
    '@
    '@    Exit Sub
    '@
    '@Error_Handler:
    '@
    '@    '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
    '@    With ptypOnErrorInfo
    '@        .strMenuKey = CMstrLocalMenuKey
    '@        .strProcName = "prvFocus_Set"
    '@        .strErrMessage = vbNullString
    '@    End With
    '@
    '@    '@共通ｴﾗｰ処理
    '@    Call pubOnError_Proc
    '@
    '@End Sub
    '@↑2012/01/24 (Tue) 13:17:09 T.Oide **************************************************


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
    Private Sub groupBox_paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles fraCF.Paint, fraPart.Paint, fraThrow.Paint, fraThrowinWP.Paint

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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfPaletteList.BeforeDoubleClick, vsfPartLotList.BeforeDoubleClick

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
            'gridObj.AutoSizeCol(colindex,6)
        End If

    End Sub
    
    '関数名：cursor_Enter
    '機　能 ： 項目選択時、自動Validateを実行するか否かを設定する。
    '作成日：2019/07/02 NSYS
    '更新日：
    '備　考 ： Handlesは画面で入力できるすべての項目が対象
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles cmdClose.Enter, _
            cmdEntry.Enter, cmdSearch.Enter, cmdCarrierSelect.Enter, cmdScrap.Enter, cmdAllClear.Enter, cmdRegist.Enter, _
            cmbScreenSize.Enter, cmbPd.Enter, cmbPart.Enter, cmbBoardThickness.Enter, cmbRework.Enter, cmbThrowinWP.Enter, cmbLotManager.Enter, _
            vsfPartLotList.Enter, vsfPaletteList.Enter, txtCarrierID.Enter, txtNumber.Enter, _
            txtPalette00.Enter, txtPalette01.Enter, txtPalette02.Enter, txtPalette03.Enter, txtPalette04.Enter, txtPalette05.Enter, _
            txtPalette06.Enter, txtPalette07.Enter, txtPalette08.Enter, txtPalette09.Enter, txtPalette10.Enter, txtPalette11.Enter, _
            txtPalette12.Enter, txtPalette13.Enter, txtPalette14.Enter, txtPalette15.Enter, txtPalette16.Enter, txtPalette17.Enter

        '選択されている項目の名前で判定
        Select sender.Name
            '自動Validate = OFF
            Case cmdClose.Name, cmdCarrierSelect.Name
                Me.AutoValidate = AutoValidate.Disable

            '自動Validate = ON
            Case Else
                Me.AutoValidate = AutoValidate.EnablePreventFocusChange
        End Select

    End Sub

End Class
