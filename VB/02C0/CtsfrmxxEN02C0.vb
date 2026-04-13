'ﾌｧｲﾙ名：xxEN02C0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：MKロット編成　メインフォーム
'作成日：2009/05/19 (Tue) 17:22:00 T.Oide
'更新日：2012/01/24 (Tue) 11:51:40 T.Oide
'備　考：ｼｽﾃﾑﾌﾞﾛｯｸは、「2AO」を使用する
'　　　：2009/05/19　CFロット編成をベースに作成
'　　　：2011/04/26 (Tue) 11:12:37 T.Oide       CHR0001319 QUを組立に送品可能にする
'　　　：2012/01/13 (Fri) 17:13:57 T.Oide       REQ-1115 不良と払出の区分け対応
'Copyright(C) SEIKO EPSON CORPORATION 2003-, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02C0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02C0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02C0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02C0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02C0)
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
    '@↓2012/01/24 (Tue) 11:51:40 T.Oide **************************************************
    'Private Const CMstrLocalVersion                     As String = "03.00"
    Private Const CMstrLocalVersion                     As String = "03.01"
    '@↑2012/01/24 (Tue) 11:51:40 T.Oide **************************************************


    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN02C0          'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrcarrcurstateVer                  As String = "05.02"                 'ｷｬﾘｱ状態確認
    Private Const CMstrlot_mkthrowinVer                 As String = "02.00"                 'MKﾛｯﾄ編成
    '@↓2012/01/13 (Fri) 17:13:57 T.Oide **************************************************
    'Private Const CMstrinv_mktocfpartlistVer            As String = "01.00"                 'MK用部材一覧取得
    Private Const CMstrinv_mktocfpartlistVer            As String = "02.00"                 'MK用部材一覧取得
    Private Const CMstrmas_jigfillnumVer                As String = "01.00"                 'jigの詰め数取得
    '@↑2012/01/13 (Fri) 17:13:57 T.Oide **************************************************
    Private Const CMstrmas_mktocfpartlistVer            As String = "01.00"                 '部材ﾘｽﾄ取得2
    '@↓2011/05/09 (Mon) 10:14:02 T.Oide **************************************************
    'Private Const CMstrmas_pdlist__Ver                  As String = "02.02"                 '機種区分一覧取得
    Private Const CMstrmas_pdlist__Ver                  As String = "03.00"                 '機種区分一覧取得
    '@↑2011/05/09 (Mon) 10:14:02 T.Oide **************************************************
    Private Const CMstrmas_pdentrylistVer               As String = "03.00"                 'ﾏｽﾀ工順一覧
    Private Const CMstrmas_screenlistVer                As String = "02.00"                 '画面ｻｲｽﾞﾏｽﾀ取得
    Private Const CMstrmas_thicklistVer                 As String = "01.00"                 '板厚区分取得
    Private Const CMstrmas_vendclasslistVer             As String = "02.00"                 'ﾍﾞﾝﾀﾞｰｸﾗｽﾘｽﾄ取得
    Private Const CMstrmas_emplist_Ver                  As String = "02.00"                 '作業者ﾘｽﾄ取得
    Private Const CMstrmas_wplist__Ver                  As String = "05.01"                 '装置一覧取得
    Private Const CMstrjig_usechkVer                    As String = "01.00"                 '治具使用可否判定
    '@↓2011/05/09 (Mon) 10:45:39 T.Oide **************************************************
    'Private Const CMstrmas_flowlistVer                  As String = "03.00"                 '種別区分一覧取得
    Private Const CMstrmas_flowlistVer                  As String = "04.00"                 '種別区分一覧取得
    '@↑2011/05/09 (Mon) 10:45:39 T.Oide **************************************************

    '@その他
    Private Const CMstrMkThrowineq_type                 As String = "21"                    'EQ_TYPE(MK投入装置=21)

    '@vsfInvLotListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfInvLLColNo                    As Integer = 0                          '№
    Private Const CMlngvsfInvLLColCFLotID               As Integer = 1                          'CFﾛｯﾄID
    Private Const CMlngvsfInvLLColPassedTime            As Integer = 2                          '時間制限
    Private Const CMlngvsfInvLLColBoardThickness        As Integer = 3                          '厚
    Private Const CMlngvsfInvLLColRegeneration          As Integer = 4                          'ﾘﾜｰｸ
    Private Const CMlngvsfInvLLColNum                   As Integer = 5                          '在庫枚数
    Private Const CMlngvsfInvLLColEditTime              As Integer = 6                          '更新日時
    '@↓2012/01/16 (Mon) 16:00:53 T.Oide **************************************************
    Private Const CMlngvsfInvLLColCarrierID             As Integer = 7                          'ｷｬﾘｱID(非表示)
    Private Const CMlngvsfInvLLColFlowClass             As Integer = 8                          '流動区分(非表示)
    '@↑2012/01/16 (Mon) 16:00:53 T.Oide **************************************************


    '@vsfInvLotListの定数宣言(幅)
    Private Const CMlngvsfInvLLWColNo                   As Integer = 33                        '№
    Private Const CMlngvsfInvLLWColCFLotID              As Integer = 97                        'CFロットID
    Private Const CMlngvsfInvLLWColPassedTime           As Integer = 130                       '時間制限
    Private Const CMlngvsfInvLLWColBoardThickness       As Integer = 33                        '厚
    Private Const CMlngvsfInvLLWColRegeneration         As Integer = 47                        'ﾘﾜｰｸ
    Private Const CMlngvsfInvLLWColNum                  As Integer = 80                        '在庫枚数
    Private Const CMlngvsfInvLLWColEditTime             As Integer = 65                        '更新日時
    '@↓2012/01/16 (Mon) 16:04:32 T.Oide **************************************************
    Private Const CMlngvsfInvLLWColCarrierID            As Integer = 65                        'ｷｬﾘｱID(非表示)
    Private Const CMlngvsfInvLLWColFlowClass            As Integer = 65                        '流動区分(非表示)
    '@↑2012/01/16 (Mon) 16:04:32 T.Oide **************************************************


    '@vsfInvLotListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfInvLLColNo                    As String = "№"                     '№
    Private Const CMstrvsfInvLLColCFLotID               As String = "CFロットID"             'CFロットID
    Private Const CMstrvsfInvLLColPassedTime            As String = "時間制限"               '時間制限
    Private Const CMstrvsfInvLLColBoardThickness        As String = "厚"                     '厚
    Private Const CMstrvsfInvLLColRegeneration          As String = "ﾘﾜｰｸ"                   'ﾘﾜｰｸ
    Private Const CMstrvsfInvLLColNum                   As String = "在庫枚数"               '在庫枚数
    Private Const CMlstrvsfInvLLColEditTime             As String = "更新日時"               '更新日時
    '@↓2012/01/16 (Mon) 16:05:17 T.Oide **************************************************
    Private Const CMlstrvsfInvLLColCarrierID            As String = "キャリアID"             'ｷｬﾘｱID(非表示)
    Private Const CMlstrvsfInvLLColFlowClass            As String = "流動区分"               '流動区分(非表示)
    '@↑2012/01/16 (Mon) 16:05:17 T.Oide **************************************************


    '@vsfJigListの定数宣言(ｶﾗﾑ)
    Private Const CMlngvsfJigListColNo                  As Integer = 0                         '№
    Private Const CMlngvsfJigListColCFLotID             As Integer = 1                         'CFﾛｯﾄID
    Private Const CMlngvsfJigListColPassedTime          As Integer = 2                         '経過時間
    Private Const CMlngvsfJigListColBoardThickness      As Integer = 3                         '厚
    Private Const CMlngvsfJigListColRegeneration        As Integer = 4                         'ﾘﾜｰｸ
    Private Const CMlngvsfJigListColNum                 As Integer = 5                         '詰数
    Private Const CMlngvsfJigListColEditTime            As Integer = 6                         '更新日時
    Private Const CMlngvsfJigListColJigID               As Integer = 7                         '治具ID

    '@vsfJigListの定数宣言(幅)
    Private Const CMlngvsfJigListWColNo                 As Integer = 33                       '№
    Private Const CMlngvsfJigListWColCFLotID            As Integer = 97                       'CFﾛｯﾄID
    Private Const CMlngvsfJigListWColPassedTime         As Integer = 122                      '経過時間
    Private Const CMlngvsfJigListWColBoardThickness     As Integer = 33                       '厚
    Private Const CMlngvsfJigListWColRegeneration       As Integer = 47                       'ﾘﾜｰｸ
    Private Const CMlngvsfJigListWColNum                As Integer = 47                       '詰数
    Private Const CMlngvsfJigListWColEditTime           As Integer = 110                      '更新日時
    Private Const CMlngvsfJigListWColJigID              As Integer = 110                      '治具ID

    '@vsfJigListの定数宣言(ﾀｲﾄﾙ)
    Private Const CMstrvsfJigListColNo                  As String = "№"                    '№
    Private Const CMstrvsfJigListColCFLotID             As String = "CFﾛｯﾄID"               'CFﾛｯﾄID
    Private Const CMstrvsfJigListColPassedTime          As String = "経過時間"              '経過時間
    Private Const CMstrvsfJigListColBoardThickness      As String = "厚"                    '厚
    Private Const CMstrvsfJigListColRegeneration        As String = "ﾘﾜｰｸ"                  'ﾘﾜｰｸ
    Private Const CMstrvsfJigListColNum                 As String = "詰数"                  '詰数
    Private Const CMstrvsfJigListColEditTime            As String = "更新日時"              '更新日時
    Private Const CMstrvsfJigListColJigID               As String = "治具ID"                '治具ID

    '@vsf共通の定数宣言
    Private Const CMlngVsfRowTitle                      As Integer = 0                         'ﾀｲﾄﾙ行(行)
    Private Const CMlngVsfColTitle                      As Integer = 0                         'ﾀｲﾄﾙ行(列)
    Private Const CMlngVsfHFontSize                     As Integer = 11                        'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                       As Integer = 20                        'ﾍｯﾀﾞｰの高さ
    Private Const CMlngVsfHeight                        As Integer = 24                        '1ｽﾛｯﾄの高さ
    Private Const CMlngvsfPartMaxRow                    As Integer = 16                        '部材一覧最大行(ﾀｲﾄﾙ含む)

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                      As Integer = 11                        'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize                  As Integer = 11                        'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols1                     As Integer = 1                         'ｸﾞﾘｯﾄﾞ表示列数=1
    Private Const CMlngCmbDispCols2                     As Integer = 2                         'ｸﾞﾘｯﾄﾞ表示列数=2
    Private Const CMlngCmbValueCol1                     As Integer = 1                         '値取得個数=1
    Private Const CMlngCmbValueCol2                     As Integer = 2                         '値取得個数=2
    Private Const CMlngCmbValueCol3                     As Integer = 3                         '値取得個数=3
    Private Const CMlngCmbRowHeight                     As Integer = 22                       'ﾘｽﾄ行の高さ
    Private Const CMlngCmbGridCol0                      As Integer = 0                         '名称列番=0
    Private Const CMlngCmbGridCol1                      As Integer = 1                         '名称列番=1
    Private Const CMlngCmbGroupCol                      As Integer = 2                         'ｸﾞﾙｰﾌﾟCol
    Private Const CMlngCmbGroupRow                      As Integer = 0                         'ｸﾞﾙｰﾌﾟRow
    Private Const CMlngCmbGetCol5                       As Integer = 5                         'ﾊﾞｯｸｶﾗｰ格納Col

    '@投入装置ｺﾝﾎﾞﾎﾞｯｸｽの初期値
    Private Const CMstrcmbThrowinWPListIndex            As String = "1"                       'ﾘｽﾄｲﾝﾃﾞｯｸｽ

    '@制限時間設定用
    Private Const CMlngLimitTimeInai                    As Integer = 3600                      '1h時間以内

    '@CF編成引数
    Private Const CMlngvsfClickFlg                      As Integer = 1                         'ｸﾘｯｸｲﾍﾞﾝﾄから
    Private Const CMlngcmdClearFlg                      As Integer = 3                         '取消ﾎﾞﾀﾝから

    '@詰数ｽﾗｯｼｭ
    Private Const CMstrlblSrash                         As String = "/"                     '詰数表記用
    Private Const CMstrDefaultNum                       As String = "0"                     'ﾃﾞﾌｫﾙﾄ詰数

    '@画面ｻｲｽﾞ取得時用
    Private Const CMstrCfFlag1                          As String = "1"                     'CFﾌﾗｸﾞ(1：CFの時)

    Private Const CMlngtxtJigS                          As Integer = 0                         'Index
    Private Const CMlngtxtJigE                          As Integer = 4                         'Index

    '@定数宣言
    Private Const CMlngDisp0                            As Integer = 0                         '0件表示用

    '@起動区分の定数宣言
    Private Const CMlngPDEntry                          As Integer = 1                         '機種ｴﾝﾄﾘ表示用(全件取得)
        
    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    Private mtypScreenSizeList                          As ScreenSizeList                   'ｽｸﾘｰﾝｻｲｽﾞ格納変数
    Private mtypProductList                             As List(Of ProductList)             '機種格納変数
    Private mlngProductListCnt                          As Integer                          '機種格納数
    Private mtypSeqList                                 As List(Of EntryList)               '工順Ver.格納変数
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
    Private mtypWpList                                  As List(Of WpList)                  '装置一覧格納用
    Private mlngWpListCnt                               As Integer                          '装置一覧件数
    Private mstrUsePart                                 As String                           '利用部材
    Private mlngTxtJigIndex                             As Integer                          'txtJigのIndex保持用
    '@↓2009/07/21 (Tue) 10:30:08 T.Oide **************************************************
    Private mtypDivisionList                            As List(Of DivisionList)            '種別一覧格納用
    Private mlngDivisionCnt                             As Integer                          '種別一覧ｶｳﾝﾄ
    '@↑2009/07/21 (Tue) 10:30:08 T.Oide **************************************************
    '@↓2009/08/05 (Wed) 16:31:33 T.Oide **************************************************
    Private mblnvsfInitStop                             As Boolean                          'ｸﾞﾘｯﾄﾞの初期化抑制
    Private mblnCmbChngeStop                            As Boolean                          'ｺﾝﾎﾞのｲﾍﾞﾝﾄを抑制
    '@↑2009/08/05 (Wed) 16:31:33 T.Oide **************************************************
    Private buttonProcessing                            As Boolean                          'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                    As Boolean                          'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                             As Boolean                          'NSYS WindowCloseフラグ
    Public  txtJigID()                                  As Control                          'NSYS 蒸着治具ID
    Private mlngRowCnt                                  As Integer                          'NSYS 選択行格納

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
    '機　能：初期情報取得
    '引　数：なし
    '戻り値：なし
    '作成日：20042009/05/19 (Tue) T.Oide
    '更新日：
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns             As Boolean              '結果格納
        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypVenderlist      As VenderList           'ﾍﾞﾝﾀﾞｰﾘｽﾄ格納

        Try

            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing

            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN02C0, CMstrLocalVersion)
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
            
            '@Private変数等の初期化
            Call prvfrmxxEN02C0_Minit()
            
            '@画面情報の初期化
            pbinJigchg = True           '余計なｲﾍﾞﾝﾄ発生による処理抑止
            Call prvfrmxxEN02C0_Init()
            pbinJigchg = False
            
            '@構造体の初期化(ｿｰﾄ)
            With mtypChgSort
                '@ｿｰﾄ保持構造体初期化
                .lngCnt = 0
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                Else
                    .typChgSortList.Clear
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
                                       , , , , CMstrMkThrowineq_type)
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

    '@↓2009/08/05 (Wed) 13:36:03 T.Oide **************************************************
    '関数名：cmbFlowClass_Change
    '機　能：確定ﾎﾞﾀﾝの有効/無効ﾁｪｯｸを行う
    '引　数：なし
    '戻り値：
    '作成日：2009/08/05 (Wed) 13:35:10 T.Oide
    '更新日：2009/08/05 (Wed) 13:35:10
    '備　考：
    Private Sub cmbFlowClass_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbFlowClass.Change

        Try
            
            '@投入確定ﾎﾞﾀﾝEnabled処理へ
            Call prvcmdRegist_Chk()
            
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbFlowClass_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
    '@↑2009/08/05 (Wed) 13:36:03 T.Oide **************************************************

    '関数名：Form_Activate
    '機　能：ﾌｫｰﾑｱｸﾃｨﾍﾞｲﾄ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:25:21 T.Oide
    '更新日：
    '備　考：
    '　　　：
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
                        RemoveHandler cmbScreenSize.Validating ,AddressOf cmbScreenSize_Validate
                        cmbScreenSize_Validate (cmbScreenSize,New CancelEventArgs(False))
                        AddHandler cmbScreenSize.Validating ,AddressOf cmbScreenSize_Validate
                    Else
                        pubSetFocus(cmbScreenSize)
                    End If
                End With
            
                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
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
    '作成日：2009/05/19 (Tue) 17:26:11 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Sub Form_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        
        Try

            '@ﾏｳｽﾎﾟｲﾝﾀｰが砂時計の場合はKey入力を受け付けない
            If Cursor.Current = Cursors.WaitCursor Then
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
                            Call cmbScreenSize_Validate(cmbScreenSize,New CancelEventArgs(False))
                            AddHandler cmbScreenSize.Validating, AddressOf cmbScreenSize_Validate
                            e.Handled = True
                    End Select
                    
                Case cmbPD.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@機種Validate処理へ
                            RemoveHandler cmbPD.Validating, AddressOf cmbPd_Validate
                            Call cmbPd_Validate(cmbPD,New CancelEventArgs(False))
                            AddHandler cmbPD.Validating, AddressOf cmbPd_Validate
                            e.Handled = True
                    End Select
                
                Case cmbPart.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@部品Validate処理へ
                            RemoveHandler cmbPart.Validating, AddressOf cmbPart_Validate
                            Call cmbPart_Validate(cmbPart,New CancelEventArgs(False))
                            AddHandler cmbPart.Validating, AddressOf cmbPart_Validate
                            e.Handled = True
                    End Select
                    
                Case cmbLotManager.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@ﾛｯﾄ担当Validate処理へ
                            RemoveHandler cmbLotManager.Validating, AddressOf cmbLotManager_Validate
                            Call cmbLotManager_Validate(cmbLotManager,New CancelEventArgs(False))
                            AddHandler cmbLotManager.Validating, AddressOf cmbLotManager_Validate
                            e.Handled = True
                    End Select
                
                Case cmbThrowinWP.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '@投入装置Validate処理へ
                            RemoveHandler cmbThrowinWP.Validating, AddressOf cmbThrowinWP_Validate
                            Call cmbThrowinWP_Validate(cmbThrowinWP,New CancelEventArgs(False))
                            AddHandler cmbThrowinWP.Validating, AddressOf cmbThrowinWP_Validate
                            e.Handled = True
                    End Select
                    
                Case txtNumber.Name
                    Select Case e.KeyCode
                        Case Keys.Return
                            '詰数Validate処理へ
                            RemoveHandler txtNumber.Validating, AddressOf txtNumber_Validate
                            Call txtNumber_Validate(txtNumber,New CancelEventArgs(False))
                            AddHandler txtNumber.Validating, AddressOf txtNumber_Validate

                            '@詰数のｴﾗｰの場合ﾌｫｰｶｽ移動しない
                            If mblnErrFlag = False Then
                                '@ﾌｫｰｶｽの移動
                                Call pubSetFocus(txtJig0)
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
    '作成日：2009/05/19 (Tue) 17:26:53 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm     As Boolean      '開放結果格納

        Try
            
            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose,New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If
            
            '@Private変数等の初期化
            Call prvfrmxxEN02C0_Minit()
            
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
    '作成日：2009/05/19 (Tue) 17:27:44 T.Oide
    '更新日：2012/01/17 (Tue) 16:25:55 T.Oide
    '備　考：
    '　　　：
    Private Sub cmdSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdSearch.Click

        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim ltypPartLotList         As List(Of PartLotList) '部材一覧取得情報格納
        Dim llngPartLotListCnt      As Integer              '部材一覧取得件数格納
        Dim lstrTempRework          As String               'ﾘﾜｰｸ回数
        Dim lstrTempBT              As String               '板厚
        Dim lblnAnsTume             As Boolean              '蒸着治具の詰め数取得結果
        Dim ltypJigFillNum          As List(Of JigFillNum)  '治具ﾀｲﾌﾟの取得結果格納

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
            lstrFormName = Me.Name
            lstrEventName = "cmdSearch_Click"
            
            '@利用部材・入力ﾁｪｯｸ
            If cmbPart.Text = vbNullString Then
                Exit Sub
            End If
                
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ﾘﾜｰｸ条件をｾｯﾄ
            If cmbRework.Text = CPstrComboAppointNo Then
            '@指定なしの場合
                lstrTempRework = vbNullString               'Nullをｾｯﾄ
            Else
            '@指定なし以外の場合
                lstrTempRework = Trim(cmbRework.Text)       '選択した板厚をｾｯﾄ
            End If
            '@板厚条件をセット
            If cmbBoardThickness.Text = CPstrComboAppointNo Then
            '@指定なしの場合
                lstrTempBT = vbNullString                   'Nullをｾｯﾄ
            Else
            '@指定なし以外の場合
                lstrTempBT = Trim(cmbBoardThickness.Text)   '選択した板厚をｾｯﾄ
            End If
            
            
            '@部材一覧情報の取得
            lblnAns = pubblnInvMKToCFPartList_Sel(CMstrinv_mktocfpartlistVer, _
                                                  cmbPD.Text, _
                                                  mstrTaihiPartID, _
                                                  lstrTempBT, _
                                                  lstrTempRework, _
                                                  ltypPartLotList, _
                                                  llngPartLotListCnt)
            '@結果判定
            If lblnAns = True Then
                '@取得結果を一覧表示
                Call prvvsfInvLotList_Disp(ltypPartLotList, llngPartLotListCnt)
            Else
                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@部品Comboへｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(cmbPart)
                
                Exit Sub
            End If
            
            '@蒸着治具への詰数取得
        '@↓2012/01/17 (Tue) 17:29:06 T.Oide 元々あった不具合発見のため修正********************
        '@    lblnAnsTume = pubblnJJigFillNum_Sel(CMstrinv_mktocfpartlistVer, _
        '@                                        cmbPd.Text, _
        '@                                        "JC", _
        '@                                        ltypJigFillNum())
                                                
            lblnAnsTume = pubblnJJigFillNum_Sel(CMstrmas_jigfillnumVer, _
                                                cmbPD.Text, _
                                                "JC", _
                                                ltypJigFillNum)
        '@↑2012/01/17 (Tue) 17:29:06 T.Oide **************************************************
                                                
                                                
            '@結果判定
            If lblnAnsTume = True Then
                '1つ目の要素を返す
                mstrTaihiNumber = ltypJigFillNum(0).lngStuffCount
            Else
                '@ﾚｽﾎﾟﾝｽ取得ｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)
                
                '@部品Comboへｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(cmbPart)
                
                Exit Sub
            End If
            
            
            '@部材一覧情報の結果が0件以外の場合には検索条件(投入予定)の確定処理/CF編成ﾌﾚｰﾑを使用可能にする
            If llngPartLotListCnt <> 0 Then
                '@投入予定確定前の場合のみ処理
                If cmbScreenSize.Enabled = True Then
                    '@CF編成ﾌﾚｰﾑの初期化
                    Call prvfraCF_Init()
                    
                    '@治具ID一覧のｽﾛｯﾄ入力欄設定
                    Call prvvsfJigList_Disp()
                    
                    '@詰数をTextﾎﾞｯｸｽに格納
                    txtNumber.Text = mstrTaihiNumber
                    
                    '@詰数をﾗﾍﾞﾙに格納
                    lblMaxNum.Text = CMstrlblSrash & mstrTaihiNumber
                    
                    '@治具ID有効処理
                    For llngIndex = CMlngtxtJigS To CMlngtxtJigE
                        txtJigID(llngIndex).Enabled = True
                    Next
                    
                    '@↓2009/07/23 (Thu) 16:59:23 T.Oide **************************************************
                    '@空治具選択ボタンを有効にする
                    cmdJigSelect.Enabled = True
                    '@↑2009/07/23 (Thu) 16:59:23 T.Oide **************************************************
                    
                    '@投入装置を有効にする
                    cmbThrowinWP.Enabled = True
                    
                    '@ﾛｯﾄ担当を有効にする
                    cmbLotManager.Enabled = True
                    
                End If
                
                '@投入予約項目を確定(選択不可状態に移行)
                cmbScreenSize.Enabled = False
                cmbPD.Enabled = False
                cmdEntry.Enabled = False
                
                '@ｾｯﾄﾌｫｰｶｽ
                Call pubSetFocus(vsfInvLotList)
            Else
                '@該当件数0件の場合の処理を追加(日時/件数をﾗﾍﾞﾙにｾｯﾄ)
                lblLotCnt.Text = CMlngDisp0
                lblNowDate.Text = Format$(Now, CPstrDateFormat)
                
                '@↓2009/07/23 (Thu) 16:59:38 T.Oide **************************************************
                '@空治具選択ボタンを無効にする
                cmdJigSelect.Enabled = False
                '@↑2009/07/23 (Thu) 16:59:38 T.Oide **************************************************
                
            End If
            
        '@↓2012/01/17 (Tue) 16:25:36 T.Oide **************************************************
            '@在庫不良入力ボタン有効/無効制御
            Call cmdScrap_Chk(cmdScrap,New EventArgs)
        '@↑2012/01/17 (Tue) 16:25:36 T.Oide **************************************************
            
            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)

            
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
    '作成日：2009/05/19 (Tue) 17:28:23 T.Oide
    '更新日：
    '備　考：
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
            Call prvvsfJigList_Set(CMlngcmdClearFlg)

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


    '関数名：cmdAllClear_Click
    '機　能：全取消
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:29:39 T.Oide
    '更新日：
    '備　考：
    '　　　：
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
            Call prvfrmxxEN02C0_Init()
            
            '@治具ID一覧のｽﾛｯﾄ入力欄設定
            Call prvvsfJigList_Disp()

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
    '作成日：2009/05/19 (Tue) 17:30:06 T.Oide
    '更新日：
    '備　考：
    '　　　：
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
            pstrCarrierTypeID = CPstrCarrTypeJyo  '(蒸着治具ｶｾｯﾄ)
            
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
    '作成日：2009/05/19 (Tue) 17:32:05 T.Oide
    '更新日：
    '備　考：
    '　　　：
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
    '作成日：2009/05/19 (Tue) 17:32:21 T.Oide
    '更新日：
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
            Call publngEnd_Proc(CPstrKeyEN02C0, ltypCommonInfo)
            
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
    '作成日：2009/05/19 (Tue) 17:32:42 T.Oide
    '更新日：
    '備　考：

    Private Sub cmdRegist_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdRegist.Click

        Dim lblnAns                 As Boolean              '結果格納
        Dim ltypLotMkThrowin        As LotMkThrowin         'MK編成構造体
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim llngCnt                 As Integer              'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngCnt2                As Integer              '配列のカウンタ
        Dim lstrGuidMsg             As String               'ｶﾞｲﾀﾞﾝｽMsg
        Dim lstrGuidMsgCode         As String               'ｶﾞｲﾀﾞﾝｽMsgｺｰﾄﾞ
        Dim lstrEditGuidance        As String               '文字結合編集済み表示ｶﾞｲﾀﾞﾝｽMsg
        Dim lngSlotNo               As Integer              'ｽﾛｯﾄ№

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
            

            '@ｽﾛｯﾄﾏｯﾌﾟ&治具IDの入力ﾁｪｯｸ、詰数合計と投入数の合致ﾁｪｯｸ、RW回数のﾁｪｯｸを行なう
            lblnAns = prvblnRegist_Chk
            If lblnAns = False Then
                '@合致しない場合、投入中止
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
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@CF編成構造体へ設定
            With ltypLotMkThrowin
                .strSbID = pstrSBID                                 'ｼｽﾃﾑﾌﾞﾛｯｸ
                .strCarrierId = txtCarrierID.Text                   'ｷｬﾘｱID
                .strEmpID = pstrUserID                              '作業者ID
                .strNum = lblThrowNum.Text                          '投入数
                .strPdId = cmbPD.Text                               'PD_ID
                '@↓2009/07/21 (Tue) 11:42:35 T.Oide **************************************************
                .strFlowClass = cmbFlowClass.Text                   '流動区分
                '@↑2009/07/21 (Tue) 11:42:35 T.Oide **************************************************
                .strEntryID = lblEntryID.Text                       'ｴﾝﾄﾘID
                .strTechManID = Trim(mstrLotManagerID)              'ﾛｯﾄ担当者ID(ｽﾍﾟｰｽ1個ｱﾘ)
                .strWpID = cmbThrowinWP.Value                       '投入装置
                
                If .typJigMapList Is Nothing Then
                    .typJigMapList = New List(Of JigMapList)
                Else
                    .typJigMapList.Clear()
                End If

                '@治具ｽﾛｯﾄ情報の設定
                llngCnt2 = 0
                For llngCnt = 1 To CPlngJPaletteSlot
                    'ｸﾞﾘｯﾄﾞが空でなければ配列にｾｯﾄ
                    If vsfJigList.GetData(llngCnt, CMlngvsfJigListColJigID) <> vbNullString Then
                        '構造体要素数追加
                        Dim typJigMapListTmp As New JigMapList

                        'ﾃﾞｰﾀｾｯﾄ
                        typJigMapListTmp.strSlotPositon _
                            = vsfJigList.GetData(llngCnt, CMlngvsfJigListColNo)                'ｽﾛｯﾄ№
                        lngSlotNo = Format(CInt(vsfJigList.GetData(llngCnt, CMlngvsfJigListColNo)), "#")
                        typJigMapListTmp.strjigId _
                            = vsfJigList.GetData(llngCnt, CMlngvsfJigListColJigID)             '治具ID
                        typJigMapListTmp.strChipCount _
                            = vsfJigList.GetData(llngCnt, CMlngvsfJigListColNum)               '投入数量
                        typJigMapListTmp.strLotID _
                            = vsfJigList.GetData(llngCnt, CMlngvsfJigListColCFLotID)           'CFﾛｯﾄID
                        typJigMapListTmp.strBodyThickness _
                            = vsfJigList.GetData(llngCnt, CMlngvsfJigListColBoardThickness)    '厚
                        typJigMapListTmp.strReworkCount _
                            = vsfJigList.GetData(llngCnt, CMlngvsfJigListColRegeneration)      'ﾘﾜｰｸｶｳﾝﾄ
                        llngCnt2 = llngCnt2 + 1
                        .lngJigMapListCnt = llngCnt2                                                    '冶具ﾏｯﾌﾟｶｳﾝﾄ
                        
                        'ここで混成のListがあれば構造体にｺﾋﾟｰする
                        ReDim Preserve ptypKonsei(4)
                        If ptypKonsei(lngSlotNo -1).strSlotNo <> vbNullString Then
                            If typJigMapListTmp.typKonseiList Is Nothing Then
                                typJigMapListTmp.typKonseiList = New List(Of KonseiList)
                            End If
                            typJigMapListTmp.typKonseiList = _
                                ptypKonsei(lngSlotNo -1).typKonseiList
                        End If

                        .typJigMapList.Add(typJigMapListTmp)
                        
                    End If
                Next llngCnt
                
                .strMsgVer = CMstrlot_mkthrowinVer
            
                '@ﾒｯｾｰｼﾞ送信(MKﾛｯﾄ編成)
                lblnAns = pubblnLotMkThrowin_Upd(CMstrlot_mkthrowinVer, _
                                                 ltypLotMkThrowin, _
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
                    Call prvfrmxxEN02C0_Init()
                    
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
    '作成日：2009/05/19 (Tue) 17:33:27 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Sub cmbScreenSize_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbScreenSize.Change

        Dim lblnChkAns  As Boolean      '入力ﾁｪｯｸ結果格納(True:OK/False:NG)

        Try
            
            '@ﾛｯﾄIDの初期化
            lblCfLotID.Text = vbNullString
            
            '@機種の初期化
            With cmbPD
                .Clear
                .Enabled = False
                .BackColor = SystemColors.Window
            End With
            
            '@工順Ver.の初期化
            lblEntryID.Text = vbNullString
            cmdEntry.Enabled = False
            
            '@ｽｸﾘｰﾝｻｲｽﾞが空欄の以外場合,入力ﾁｪｯｸ
            If cmbScreenSize.Text <> vbNullString Then
                '@全取消ﾎﾞﾀﾝ活性化
                cmdAllClear.Enabled = True
                
                '@入力ﾁｪｯｸ
                lblnChkAns = prvblnThrowInfo_Chk
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
    '作成日：2009/05/19 (Tue) 17:33:44 T.Oide
    '更新日：
    '備　考：
    Private Sub cmbScreenSize_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbScreenSize.CloseUp

        Try

            '@空欄ではない場合
            If cmbScreenSize.Text <> vbNullString Then
                '@validate処理へ
                RemoveHandler cmbScreenSize.Validating,AddressOf cmbScreenSize_Validate
                Call cmbScreenSize_Validate(cmbScreenSize,New CancelEventArgs(False))
                AddHandler cmbScreenSize.Validating,AddressOf cmbScreenSize_Validate
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
    '作成日：2009/05/19 (Tue) 17:34:08 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Sub cmbScreenSize_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbScreenSize.Validating

        Dim lblnPdAns           As Boolean              '機種情報取得処理結果
        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrClassDivision   As String               'ClassDivision置換

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "cmbScreenSize_Validate"
            
            '@選択されていない場合
            If cmbScreenSize.Text = vbNullString Then
                '@閉じるへｾｯﾄﾌｫｰｶｽ
                If ActiveControl.Name = cmbScreenSize.Name Then
                    Call pubSetFocus(cmdClose)
                End If

                Exit Sub
            Else
                '@詰め数を退避領域に格納
                cmbScreenSize.ValueCol = 1
                'mstrTaihiNumber = cmbScreenSize.Value
                
                '@機種ｺﾝﾎﾞﾎﾞｯｸｽ使用可能
                cmbPD.Enabled = True
            End If
            
            '@情報取得前に初期化
            If mtypProductList Is Nothing Then
                mtypProductList = New List(Of ProductList)
            Else
                mtypProductList.Clear()
            End If
            
            '@機種ﾘｽﾄ取得
            If cmbPD.Text = vbNullString Then
                '@ﾚｽﾎﾟﾝｽ取得開始
                Call pubResponseStart(lstrFormName, lstrEventName)
                
                '@機種情報取得処理
                lstrClassDivision = CPstrCD2B & CPstrCD4J
                
                
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

                            '@'NSYS 機種Comboへｾｯﾄﾌｫｰｶｽ
                            If ActiveControl.Name = cmbScreenSize.Name Then
                                Call pubSetFocus(cmbPD)
                            End If

                            RemoveHandler cmbPD.Validating, AddressOf cmbPd_Validate
                            Call cmbPd_Validate(cmbPD,New CancelEventArgs(False))                      '機種のValidateｲﾍﾞﾝﾄを呼び出す
                            AddHandler cmbPD.Validating, AddressOf cmbPd_Validate

                        Case Else
                        '@取得件数が1件以上
                            '@機種Comboへｾｯﾄﾌｫｰｶｽ
                            If ActiveControl.Name = cmbScreenSize.Name Then
                                Call pubSetFocus(cmbPD)
                            End If
                    End Select
                End If
            Else
                '@機種Comboへｾｯﾄﾌｫｰｶｽ
                If ActiveControl.Name = cmbScreenSize.Name Then
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

        End Try
    End Sub

    '関数名：cmbPd_Change
    '機　能：機種変更処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:37:07 T.Oide
    '更新日：2009/08/06 (Thu) 10:07:45 T.Oide
    '備　考：
    Private Sub cmbPd_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPD.Change

        Dim lblnChkAns  As Boolean      '入力ﾁｪｯｸ結果格納(True:OK/False:NG)

        Try
            
        '@↓2009/08/06 (Thu) 10:07:41 T.Oide **************************************************
            '@前回取得の使用ﾊﾟｰﾂｺｰﾄﾞの初期化
            mstrUsePart = vbNullString
        '@↑2009/08/06 (Thu) 10:07:41 T.Oide **************************************************
            
            '@工順Ver.の初期化
            lblEntryID.Text = vbNullString
            cmdEntry.Enabled = False
            
            '@機種が空欄の場合,初期化
            If cmbPD.Text <> vbNullString Then
                '@入力ﾁｪｯｸ
                lblnChkAns = prvblnThrowInfo_Chk
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
    '作成日：2009/05/19 (Tue) 17:37:33 T.Oide
    '更新日：
    '備　考：
    Private Sub cmbPd_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPD.CloseUp

        Try

            '@空欄ではない場合
            If cmbPD.Text <> vbNullString Then
                '@Validate処理へ
                RemoveHandler cmbPD.Validating,AddressOf cmbPd_Validate
                Call cmbPd_Validate(cmbPD,New CancelEventArgs(False))
                AddHandler cmbPD.Validating,AddressOf cmbPd_Validate
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
    '作成日：2009/05/19 (Tue) 17:37:53 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Sub cmbPd_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPD.Validating

        Dim lblnAns             As Boolean              '汎用戻り値
        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "cmbPd_Validate"
            
            '@選択されていない場合
            If cmbPD.Text = vbNullString Then
                '@閉じるへｾｯﾄﾌｫｰｶｽ
                If ActiveControl.Name = cmbPD.Name Then
                    Call pubSetFocus(cmdClose)
                End If
                Exit Sub
            Else
                '@工順ｺﾝﾎﾞﾎﾞｯｸｽ使用可能
                cmdEntry.Enabled = True
            End If
            
            '@値取得(ﾊﾞｯｸｶﾗｰ値)
            cmbPD.ValueCol = CMlngCmbGetCol5
            
            If cmbPD.Value <> vbNullString Then
                '@ﾊﾞｯｸｶﾗｰ反映
                cmbPD.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(cmbPD.Value))
            Else
                cmbPD.BackColor = Color.White
            End If
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@機種ｴﾝﾄﾘ、部材取得
            lblnAns = prvMasEntryList_Sel
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
    '作成日：2009/05/19 (Tue) 17:38:13 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Sub cmbPart_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPart.Change

        Try
            
        '@↓2009/08/05 (Wed) 17:50:25 T.Oide **************************************************
            '@ｷｬﾝｾﾙﾌﾗｸﾞがTrueなら処理中止
            If mblnCmbChngeStop = True Then
                Exit Sub
            End If
        '@↑2009/08/05 (Wed) 17:50:25 T.Oide **************************************************
            
            
            '@部品一覧のｸﾘｱ
            Call prvvsfInvLotList_Init()
            
            '@情報取得日時/該当件数欄の初期化
            lblNowDate.Text = vbNullString
            lblLotCnt.Text = vbNullString
            
            '@部品Comboが空欄か否かで処理分岐
            If cmbPart.Text = vbNullString Then
                '@検索ﾎﾞﾀﾝを使用不可
                cmdSearch.Enabled = False
                
                '@板厚/ﾘﾜｰｸ回数を初期化
        '@↓2009/08/05 (Wed) 16:32:06 T.Oide **************************************************
                mblnvsfInitStop = True              'グリッドの初期化が走らないようにする
                cmbBoardThickness.Clear
                cmbBoardThickness.Enabled = False
                cmbRework.Clear
                cmbRework.Enabled = False
                mblnvsfInitStop = False              'グリッドの初期化OKに戻し
        '@↑2009/08/05 (Wed) 16:32:06 T.Oide **************************************************
                
                '@一覧を使用不可
                'Call prvvsfInvLotList_Init
                
                vsfInvLotList.Enabled = False
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
    '作成日：2009/05/19 (Tue) 17:38:35 T.Oide
    '更新日：
    '備　考：
    Private Sub cmbPart_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPart.CloseUp

        Try

            '@空欄以外の場合
            If cmbPart.Text <> vbNullString Then
                '@Validate処理へ
                RemoveHandler cmbPart.Validating,AddressOf cmbPart_Validate
                Call cmbPart_Validate(cmbPart,New CancelEventArgs(False))
                AddHandler cmbPart.Validating,AddressOf cmbPart_Validate
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
    '作成日：2009/05/19 (Tue) 17:39:01 T.Oide
    '更新日：
    '備　考：
    Private Sub cmbPart_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbPart.Validating

        Dim llngCnt                     As Integer      'ｶｳﾝﾀ変数
        Dim llngIndex                   As Integer      'ComboのIndex
        Dim llngRCnt                    As Integer      'ﾘﾜｰｸｶｳﾝﾄ
        Dim lstrThicknessClass          As String       '板厚区分
        Dim llngCnt1                    As Integer      'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngCnt2                    As Integer      'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngTempCnt                 As Integer      '一時保管用ｶｳﾝﾄ格納変数

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If
            
            '@前回と同じ場合は処理しない
            If cmbPart.Text = mstrUsePart Then
                '@板厚が有効か
                If cmbBoardThickness.Enabled = True Then
                    '@板厚にﾌｫｰｶｽｾｯﾄ
                    If ActiveControl.Name = cmbPart.Name Then
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
        '@↓2009/08/05 (Wed) 17:51:02 T.Oide **************************************************
                    mblnvsfInitStop = True              'グリッドの初期化が走らないようにする
                    .Clear
                    mblnvsfInitStop = False             'グリッドの初期化が走らないようにする終了
                    '.Clear
        '@↑2009/08/05 (Wed) 17:51:02 T.Oide **************************************************
                    .Height = CMlngCmbRowHeight                                     '高さ
                    .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                    .ValueCol = CMlngCmbValueCol1                                   '値取得列
                    .DirectInput = False    
                    .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄せ中央揃え
                    
                    '@板厚情報ｾｯﾄ
                    For llngCnt1 = 0 To mlngThicknessCnt -1
                        If mtypThicknessClassList(llngCnt1).strThicknessClass = lstrThicknessClass Then
                            llngTempCnt = CLng(mtypThicknessClassList(llngCnt1).strThicknessCount) + 1
                            For llngCnt2 = 0 To llngTempCnt -1
                                If llngCnt2 = 0 Then
                                    .AddItem(CPstrComboAppointNo & vbTab & llngCnt2)
                                Else
                                    .AddItem(mtypThicknessClassList(llngCnt1).typThicknessList(llngCnt2 - 1).strThicknessCode & _
                                     vbTab & _
                                     llngCnt2)                                            '板厚&Index
                                End If
                            Next llngCnt2
                        End If
                    Next llngCnt1
                    
                    '@「指定なし」を表示
        '@↓2009/08/05 (Wed) 17:51:22 T.Oide **************************************************
                    mblnvsfInitStop = True              'グリッドの初期化が走らないようにする
                    .ListIndex = 0
                    mblnvsfInitStop = False             'グリッドの初期化が走らないようにする終了
                    '.ListIndex = 0
        '@↑2009/08/05 (Wed) 17:51:22 T.Oide **************************************************
                End With
                
                '@ﾘﾜｰｸ回数Combo作成
                With cmbRework
                    '@活性化
                    .Enabled = True
                
                    '@ﾘﾜｰｸ回数初期化
        '@↓2009/08/05 (Wed) 17:51:41 T.Oide **************************************************
                    mblnvsfInitStop = True              'グリッドの初期化が走らないようにする
                    .Clear
                    mblnvsfInitStop = False              'グリッドの初期化が走らないようにする終了
                    '.ListIndex = 0
        '@↑2009/08/05 (Wed) 17:51:41 T.Oide **************************************************
                    .Height = CMlngCmbRowHeight                                     '高さ
                    .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                    .ValueCol = CMlngCmbValueCol1                                   '値取得列
                    .DirectInput = False    
                    .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄せ中央揃え
                    
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
        '@↓2009/08/05 (Wed) 17:52:02 T.Oide **************************************************
                    mblnvsfInitStop = True              'グリッドの初期化が走らないようにする
                    .ListIndex = 0
                    mblnvsfInitStop = False             'グリッドの初期化が走らないようにする終了
                    '.ListIndex = 0
        '@↑2009/08/05 (Wed) 17:52:02 T.Oide **************************************************
                End With
                
                '@板厚へｾｯﾄﾌｫｰｶｽ
                If ActiveControl.Name = cmbPart.Name Then
                    Call pubSetFocus(cmbBoardThickness)
                End If
            Else
                If ActiveControl.Name = cmbPart.Name Then
                    If cmdAllClear.Enabled = True Then
                        '@全取消ﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(cmdAllClear)
                    Else
                        '@閉じるﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
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
    '作成日：2009/05/19 (Tue) 17:39:34 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Sub cmbBoardThickness_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBoardThickness.Change

        Try

        '@↓2009/08/05 (Wed) 17:52:12 T.Oide **************************************************
            '@ｷｬﾝｾﾙﾌﾗｸﾞがTrueのときは処理中止
            If mblnCmbChngeStop = True Then
                Exit Sub
            End If
        '@↑2009/08/05 (Wed) 17:52:12 T.Oide **************************************************


            '@部品一覧のｸﾘｱ
            Call prvvsfInvLotList_Init()
            vsfInvLotList.Enabled = False

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
    '作成日：2009/05/19 (Tue) 17:39:51 T.Oide
    '更新日：
    '備　考：
    Private Sub cmbBoardThickness_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbBoardThickness.CloseUp

        Try

            '@Validate処理へ
            RemoveHandler cmbBoardThickness.Validating,AddressOf cmbBoardThickness_Validate
            Call cmbBoardThickness_Validate(cmbBoardThickness,New CancelEventArgs(False))
            AddHandler cmbBoardThickness.Validating,AddressOf cmbBoardThickness_Validate

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
    '作成日：2009/05/19 (Tue) 17:40:07 T.Oide
    '更新日：
    '備　考：
    Private Sub cmbBoardThickness_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbBoardThickness.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@処理分岐
            If cmbBoardThickness.Text <> vbNullString Then
                If ActiveControl.Name = cmbBoardThickness.Name Then
                    '@ﾘﾜｰｸ回数へｾｯﾄﾌｫｰｶｽ
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
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Sub cmbRework_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRework.Change

        Try

        '@↓2009/08/05 (Wed) 17:52:26 T.Oide **************************************************
            '@ｷｬﾝｾﾙﾌﾗｸﾞがTrueの時は処理中止
            If mblnCmbChngeStop = True Then
                Exit Sub
            End If
        '@↑2009/08/05 (Wed) 17:52:26 T.Oide **************************************************

            '@部品一覧のｸﾘｱ
            Call prvvsfInvLotList_Init()
            vsfInvLotList.Enabled = False
            
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
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    Private Sub cmbRework_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbRework.CloseUp

        Try

            '@Validate処理へ
            RemoveHandler cmbRework.Validating,AddressOf cmbRework_Validate
            Call cmbRework_Validate(cmbRework,New CancelEventArgs(False))
            AddHandler cmbRework.Validating,AddressOf cmbRework_Validate

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
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    Private Sub cmbRework_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbRework.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@処理分岐
            If cmbRework.Text <> vbNullString Then
                If ActiveControl.Name = cmbRework.Name Then
                    '@検索ﾎﾞﾀﾝへｾｯﾄﾌｫｰｶｽ
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
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Sub cmbLotManager_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLotManager.CloseUp

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@Validate処理へ
            RemoveHandler cmbLotManager.Validating,AddressOf cmbLotManager_Validate
            Call cmbLotManager_Validate(cmbLotManager,New CancelEventArgs(False))
            AddHandler cmbLotManager.Validating,AddressOf cmbLotManager_Validate

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
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    '　　　：
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
            If ActiveControl.Name = cmbLotManager.Name Then
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
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    Private Sub cmbThrowinWP_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbThrowinWP.CloseUp

        Try

            '@Validate処理を呼ぶ
            RemoveHandler cmbThrowinWP.Validating,AddressOf cmbThrowinWP_Validate
            Call cmbThrowinWP_Validate(cmbThrowinWP,New CancelEventArgs(False))
            AddHandler cmbThrowinWP.Validating,AddressOf cmbThrowinWP_Validate

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
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    Private Sub cmbThrowinWP_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles cmbThrowinWP.Validating

        Try

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@投入装置が選択されている場合
            If cmbThrowinWP.Text <> vbNullString Then
                '@ﾛｯﾄ担当にﾌｫｰｶｽｾｯﾄ
                If ActiveControl.Name = cmbThrowinWP.Name Then
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
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Sub txtCarrierID_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtCarrierID.Change

        Try

            '@確定ﾎﾞﾀﾝの制御処理を行なう
            Call prvcmdRegist_Chk()
            
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
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    '　　　：
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
                .strCarrierTypeID = CPstrCarrTypeJyo    'ｷｬﾘｱﾀｲﾌﾟ(蒸着ｷｬﾘｱ)
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
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
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
                
                '@治具IDを無効に
                For llngIndex = CMlngtxtJigS To CMlngtxtJigE
                    txtJigID(llngIndex).Enabled = False
                Next
                
                '@ｽﾛｯﾄﾏｯﾌﾟを無効に
                vsfJigList.Enabled = False
                
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
                        For llngIndex = CMlngtxtJigS To CMlngtxtJigE
                            txtJigID(llngIndex).Enabled = True
                        Next
                        
                        '@ｽﾛｯﾄﾏｯﾌﾟを有効に
                        vsfJigList.Enabled = True
                    End If
                Else
                    '@ｴﾗｰﾌﾗｸﾞON
                    mblnErrFlag = True
                    
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar005I)
                    '@"<TRM5IW>$$詰数の設定が正しくありません。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                    
                    '@治具IDを無効に
                    For llngIndex = CMlngtxtJigS To CMlngtxtJigE
                        txtJigID(llngIndex).Enabled = False
                    Next

                    '@ｽﾛｯﾄﾏｯﾌﾟを無効に
                    vsfJigList.Enabled = False
                    
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

    '関数名：txtJig_LostFocus
    '機　能：LostFocus処理
    '引　数：Index：ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    Private Sub txtJig_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtJig0.Leave, _
                                                                                       txtJig1.Leave, _
                                                                                       txtJig2.Leave, _
                                                                                       txtJig3.Leave, _
                                                                                       txtJig4.Leave
        Try

            '@ﾌｫｰｶｽ移動の場合にﾀｲﾄﾙ行へﾌｫｰｶｽ移動
            'NSYS 現行システムで機能していないためコメントアウト
            'vsfJigList.Row = -1

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtJig_LostFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfJigList_Click
    '機　能：ｸﾘｯｸ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    Private Sub vsfJigList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles vsfJigList.Click

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfJigList.Rows.Count <= vsfJigList.Rows.Fixed Then
                Return
            End If
                
            '@ｽﾛｯﾄﾏｯﾌﾟ反映/取消処理へ
            Call prvvsfJigList_Set(CMlngvsfClickFlg)
            
            '@投入確定ﾎﾞﾀﾝEnabled処理へ
            Call prvcmdRegist_Chk()
            
            '@取消ﾎﾞﾀﾝEnabled処理へ
            Call prvCmdClear_Chk()
            
            '混成ﾎﾞﾀﾝEnabled処理へ
            Call prvcmdKonsei_Chk()
            
            '編集行を退避
            plngvsfJigListRow = vsfJigList.Row
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfJigList_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfInvLotList_AfterSort
    '機　能：ｸﾞﾘｯﾄﾞｿｰﾄ
    '引　数：Col：列
    '　　　：Order：並び順
    '戻り値：
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    Private Sub vsfInvLotList_AfterSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfInvLotList.AfterSort

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfInvLotList.Rows.Count <= vsfInvLotList.Rows.Fixed Then
                Return
            End If
            
            '@ｿｰﾄ順を格納
            With mtypChgSort
                
                If .typChgSortList Is Nothing Then
                    .typChgSortList = New List(Of ChgSortList)
                End If
                Do While (.typChgSortList.Count -1 < .lngCnt)
                    .typChgSortList.Add(New ChgSortList)
                Loop
                Dim typChgSortListTmp As ChgSortList = New ChgSortList

                '@ｿｰﾄ列番号を格納
                typChgSortListTmp.lngCol = e.Col
                
                '@並び替え方法を格納(昇順/降順)
                typChgSortListTmp.lngOrder = e.Order

                .typChgSortList(.lngCnt) = typChgSortListTmp

                '@ｿｰﾄﾘｽﾄ数をｶｳﾝﾄｱｯﾌﾟ
                .lngCnt = .lngCnt + 1
            End With
            
            'NSYS 選択行設定
            vsfInvLotList.Row = mlngRowCnt

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfInvLotList_AfterSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfInvLotList_BeforeRowColChange
    '機　能：ｸﾞﾘｯﾄﾞﾌｫｰｶｽ移動
    '引　数：OldRow：旧行
    '　　　：OldCol：旧列
    '　　　：NewRow：新行
    '　　　：NewCol：新列
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    Private Sub vsfInvLotList_BeforeRowColChange(ByVal sender As Object, ByVal e As RangeEventArgs) Handles vsfInvLotList.BeforeRowColChange
        
        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfInvLotList.Rows.Count <= vsfInvLotList.Rows.Fixed Then
                Return
            End If

            '@旧行と新行が違っていて、新行がﾃﾞｰﾀ行の場合
            If e.OldRange.r1 <> e.NewRange.r1 And e.NewRange.r1 > 0 Then
                '@ｶﾚﾝﾄ行検索用のｷｰを格納(更新日時)
                mtypChgSort.strKey = vsfInvLotList.GetData(e.NewRange.r1, CMlngvsfInvLLColEditTime)
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfInvLotList_BeforeRowColChange"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：vsfInvLotList_EnterCell
    '機　能：利用部材選択処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：2012/01/17 (Tue) 16:36:02 T.Oide
    '備　考：
    '　　　：
    Private Sub vsfInvLotList_EnterCell(ByVal sender As Object, ByVal e As EventArgs) Handles vsfInvLotList.EnterCell

        Dim lblnAns         As Boolean          '入力ﾁｪｯｸ結果格納(True:OK/False:NG)
        Dim llngIndex       As Integer          'ｶｳﾝﾄ

        Try
            
            '選択行がﾀｲﾄﾙ以外の場合
            If vsfInvLotList.Row > 0 Then
                
                '@CF編成ﾁｪｯｸ
                lblnAns = prvblnCFInput_Chk
                '@結果判定
                If lblnAns = True Then
                '@結果：OKの場合
                    '@ﾛｯｸ解除
                    vsfJigList.Enabled = True
                    
                    '@治具ID欄の活性化
                    For llngIndex = CMlngtxtJigS To CMlngtxtJigE
                        txtJigID(llngIndex).Enabled = True
                    Next
                    
                    '@取消ﾎﾞﾀﾝﾁｪｯｸ
                    Call prvCmdClear_Chk()
                Else
                '@結果：NGの場合
                    '@ﾛｯｸ
                    cmdClear.Enabled = False
                    vsfJigList.Enabled = False
                    
                    '@治具ID欄の非活性化
                    For llngIndex = CMlngtxtJigS To CMlngtxtJigE
                        txtJigID(llngIndex).Enabled = False
                    Next
                End If
            Else
                '@取消ﾎﾞﾀﾝﾁｪｯｸ
                Call prvCmdClear_Chk()
                
                '@投入確定ﾎﾞﾀﾝﾁｪｯｸ処理へ
                Call prvcmdRegist_Chk()
            End If
            
        '@↓2012/01/17 (Tue) 16:35:55 T.Oide **************************************************
            '@在庫不良ﾎﾞﾀﾝ有効/無効制御
            Call cmdScrap_Chk(cmdScrap,New EventArgs)
        '@↑2012/01/17 (Tue) 16:35:55 T.Oide **************************************************
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfInvLotList_EnterCell"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtJig_Change
    '機　能：治具ID変更時処理
    '引　数：Index：ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Sub txtJig_Change(ByVal sender As Object, ByVal e As EventArgs) Handles txtJig0.Change, _
                                                                                    txtJig1.Change, _
                                                                                    txtJig2.Change, _
                                                                                    txtJig3.Change, _
                                                                                    txtJig4.Change

        Dim lstrPassedTime      As String           '経過時間退避変数
        Dim lstrCFLotID         As String           '出荷ﾛｯﾄID退避変数
        Dim lstrBT              As String           '板厚退避変数
        Dim lstrRework          As String           'ﾘﾜｰｸ回数退避変数
        Dim lstrEditTime        As String           '更新日時
        Dim Index               As Integer          'NSYS 蒸着治具ID

        Try
            If sender.Name = txtJig0.Name Then
                Index = 0
            Else If sender.Name = txtJig1.Name
                Index = 1
            Else If sender.Name = txtJig2.Name
                Index = 2
            Else If sender.Name = txtJig3.Name
                Index = 3
            Else If sender.Name = txtJig4.Name
                Index = 4
            End If

            '起動中のｲﾍﾞﾝﾄは処理しない
            If pbinJigchg = True Then
                Exit Sub
            End If
            
            txtJigID(Index).Text  = sender.Text

            '@治具IDが空白以外の場合
            If txtJigID(Index).Text <> vbNullString Then
                '@MKロット編成ﾘｽﾄの退避領域に蒸着治具IDをｾｯﾄ
                vsfJigList.SetData(Index + 1, CMlngvsfJigListColJigID, txtJigID(Index).Text)
                
                '@利用部材一覧の選択された値を取得
                With vsfInvLotList
                    
                    '@ﾀｲﾄﾙ行以外を選択している場合
                    If .Row > CMlngVsfRowTitle Then
                        '@時間制限切れ確認
                        Select Case .GetCellRange(.Row, .Col, .Row, .Col).StyleDisplay.BackColor
                            Case Color.red
                                '時間制限きれエラーﾒｯｾｰｼﾞ表示
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000N)
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                Exit Sub
                            Case Color.Yellow
                                '時間制限きれエラーﾒｯｾｰｼﾞ表示
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000O)
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                
                                Exit Sub
                            Case Else
                                '@変数へ格納
                                lstrCFLotID = .GetData(.Row, CMlngvsfInvLLColCFLotID)                              'CFﾛｯﾄID
                                lstrPassedTime = .GetData(.Row, CMlngvsfInvLLColPassedTime)                        '制限時間
                                lstrBT = .GetData(.Row, CMlngvsfInvLLColBoardThickness)                            '厚
                                lstrRework = .GetData(.Row, CMlngvsfInvLLColRegeneration)                          'ﾘﾜｰｸ
                                lstrEditTime = .GetData(.Row, CMlngvsfInvLLColEditTime)                            '更新日時
                            
                                '@ｸﾞﾘｯﾄﾞへ表示
                                vsfJigList.SetData(Index + 1, CMlngvsfJigListColCFLotID, lstrCFLotID)             'CFﾛｯﾄID
                                vsfJigList.SetData(Index + 1, CMlngvsfJigListColPassedTime, lstrPassedTime)       '経過時間
                                vsfJigList.SetData(Index + 1, CMlngvsfJigListColBoardThickness, lstrBT)           '厚
                                vsfJigList.SetData(Index + 1, CMlngvsfJigListColRegeneration, lstrRework)         'ﾘﾜｰｸ
                                plngvsfJigListRow = Index + 1                                                               '編集中の行退避
                        
                                '@詰数のﾁｪｯｸ(空白の場合投入数の計算でｴﾗｰとなる可能性がある為)
                                If txtNumber.Text <> vbNullString Then
                                    vsfJigList.SetData(Index + 1, CMlngvsfJigListColNum, txtNumber.Text)          '在庫枚数
                                Else
                                    vsfJigList.SetData(Index + 1, CMlngvsfJigListColNum, CMstrDefaultNum)
                                End If
                            
                                vsfJigList.SetData(Index + 1, CMlngvsfJigListColEditTime, lstrEditTime)           '更新時刻
                        End Select
                    End If
                End With
            Else
                '@CFﾛｯﾄIDが空白の場合
                vsfJigList.SetData(Index + 1, CMlngvsfJigListColCFLotID, vbNullString)                    'CFﾛｯﾄID
                vsfJigList.SetData(Index + 1, CMlngvsfJigListColPassedTime, vbNullString)                 '経過時間
                vsfJigList.SetData(Index + 1, CMlngvsfJigListColBoardThickness, vbNullString)             '厚
                vsfJigList.SetData(Index + 1, CMlngvsfJigListColRegeneration, vbNullString)               'ﾘﾜｰｸ
                vsfJigList.SetData(Index + 1, CMlngvsfJigListColNum, vbNullString)                        '在庫枚数
                vsfJigList.SetData(Index + 1, CMlngvsfJigListColEditTime, vbNullString)                   '更新日時
                vsfJigList.SetData(Index + 1, CMlngvsfJigListColJigID, vbNullString)                      '治具ID

            End If
            
            '@投入数合計計算処理へ
            Call prvThrowNum_Set()
            
            '@投入確定ﾎﾞﾀﾝEnabled処理へ
            Call prvcmdRegist_Chk()
            
            '@取消ﾎﾞﾀﾝEnabled処理へ
            Call prvCmdClear_Chk()
            
            '混成ﾎﾞﾀﾝﾁｪｯｸ処理へ
            Call prvcmdKonsei_Chk()
            
            'KONSEIの設定がある場合は配列を削除する
            ReDim Preserve ptypKonsei(4)
            If ptypKonsei(4 - Index).strjigId <> vbNullString Then
                If ptypKonsei(4 - Index).typKonseiList Is Nothing Then
                    ptypKonsei(4 - Index).typKonseiList = New List(Of KonseiList)
                Else
                    ptypKonsei(4 - Index).typKonseiList.Clear
                End If
                ptypKonsei(4 - Index).lngKonseiListCnt = 0
                ptypKonsei(4 - Index).strjigId = vbNullString
                ptypKonsei(4 - Index).strSlotNo = vbNullString
            End If
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtJig_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtJig_Validate
    '機　能：治具ID確定処理
    '引　数：Index：ｲﾝﾃﾞｯｸｽ
    '　　　：Cancel：ｷｬﾝｾﾙ値
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    Private Sub txtJig_Validate(ByVal sender As Object, ByVal e As CancelEventArgs) Handles txtJig0.Validating, _
                                                                                            txtJig1.Validating, _
                                                                                            txtJig2.Validating, _
                                                                                            txtJig3.Validating, _
                                                                                            txtJig4.Validating

        Dim lblnAns             As Integer          '結果
        Dim ltypJigChk          As JigCheck         '治具使用可否判定確認Msg
        Dim lstrGuideMsgCode    As String           '返信ﾒｯｾｰｼﾞｺｰﾄﾞ
        Dim lstrGuideMsg        As String           '返信ﾒｯｾｰｼﾞ
        Dim lblnAns2            As Boolean          '結果
        Dim lstrEditGuidance    As String
        Dim Index               As Integer          'NSYS 蒸着治具ID

        Try
            If sender.Name = txtJig0.Name Then
                Index = 0
            Else If sender.Name = txtJig1.Name
                Index = 1
            Else If sender.Name = txtJig2.Name
                Index = 2
            Else If sender.Name = txtJig3.Name
                Index = 3
            Else If sender.Name = txtJig4.Name
                Index = 4
            End If

            'NSYS 画面を閉じる場合は処理を抜ける
            If mblnWindowClose = True Then
                Exit Sub
            End If

            '@投入数合計計算処理へ
            Call prvThrowNum_Set()
            
            '@治具IDが空白以外の場合
            If txtJigID(Index).Text <> vbNullString Then
                '@治具ID重複ﾁｪｯｸ
                lblnAns = prvblnPaletteID_Chk(Index)
                If lblnAns = False Then
                    '@表示ﾒｯｾｰｼﾞ変換
                    pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar009M, mstrTaihiNumber)
                    '@"治具IDが重複しています。設定を見直してください。"
                    Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                    e.Cancel = True

                    Exit Sub
                End If
                
                '@使用する治具のﾏｽﾀｰﾁｪｯｸ(ﾏｽﾀｰに登録済みか使用可能か、適切な治具かをﾁｪｯｸ)
                ltypJigChk.strSbID = pstrSBID
                ltypJigChk.strjigId = txtJigID(Index).Text
                ltypJigChk.strLotID = vbNullString
                ltypJigChk.strOpID = vbNullString
                ltypJigChk.strStepID = vbNullString
                ltypJigChk.strScreenSizeID = cmbScreenSize.Text
                
                lblnAns2 = pubblnJycJigUse_Check(CPstrCD4M, CMstrjig_usechkVer, ltypJigChk, _
                                                lstrGuideMsgCode, lstrGuideMsg)
                If lblnAns2 = True Then
                    If lstrGuideMsg <> vbNullString Then
                        
                        '@ﾒｯｾｰｼﾞがあった場合は、ｴﾗｰMsgを表示
                        lstrEditGuidance = lstrGuideMsgCode & _
                                           CPstrMsgCrCode & lstrGuideMsg
                        
                        '@ﾒｯｾｰｼﾞ表示"編集済みｶﾞｲﾀﾞﾝｽMsg"
                        pstrDMsg = pubstrMsgReplace_Set(lstrEditGuidance)
                        
                        '@ﾒｯｾｰｼﾞ表示
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                                        
                        '元の治具IDにﾌｫｰｶｽを戻す
                        'SendKeys.Send(CPstrSendKeysPulasTab)
                        pubSetFocus(sender)
                        Exit Sub
                    End If
                Else
                    '元の治具IDにﾌｫｰｶｽを戻す
                    'SendKeys.Send(CPstrSendKeysPulasTab)
                    pubSetFocus(sender)
                End If
            
            
            End If
            
            plngvsfJigListRow = Index + 1
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtJig_Validate"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：txtJig_GotFocus
    '機　能：治具IDﾌｫｰｶｽ取得時処理
    '引　数：Index：ｲﾝﾃﾞｯｸｽ
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    Private Sub txtJig_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtJig0.Enter, _
                                                                                      txtJig1.Enter, _
                                                                                      txtJig2.Enter, _
                                                                                      txtJig3.Enter, _
                                                                                      txtJig4.Enter

        Dim Index               As Integer          'NSYS 蒸着治具ID

        Try
            If sender.Name = txtJig0.Name Then
                Index = 0
            Else If sender.Name = txtJig1.Name
                Index = 1
            Else If sender.Name = txtJig2.Name
                Index = 2
            Else If sender.Name = txtJig3.Name
                Index = 3
            Else If sender.Name = txtJig4.Name
                Index = 4
            End If

            '@ｽﾛｯﾄﾏｯﾌﾟのｶﾚﾝﾄ行変更
            vsfJigList.Row = Index + 1
            '@編集中のIndex保持
            mlngTxtJigIndex = Index
            
            '混成ﾎﾞﾀﾝﾁｪｯｸ処理へ
            Call prvcmdKonsei_Chk()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "txtJig_GotFocus"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdJigSelect_Click
    '機　能：空き治具選択
    '引　数：なし
    '戻り値：なし
    '作成日：2009/07/23 (Thu) 09:30:01 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Sub cmdJigSelect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdJigSelect.Click

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
            
            '@治具ﾀｲﾌﾟID引渡し
            pstrJigTypeID = CPstrJigTypeJC              '蒸着CF治具
            pstrJigStatus = CPstrJigStatusCanUse        '使用可能
            pstrScreenSizeID = cmbScreenSize.Text       'ｽｸﾘｰﾝｻｲｽﾞ指定
            pstrJigCategoryID = vbNullString            'ｶﾃｺﾞﾘ指定なし
            
            '@空き治具一覧表示
            frmxxCM0130.Instance = New frmxxCM0130()
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxCM0130.Instance = Nothing
                Exit Sub
            End If
            
            '@空き治具一覧表示
            frmxxCM0130.Instance.ShowDialog(Me)
            frmxxCM0130.Instance = Nothing
                 
            '@空きｷｬﾘｱが選択されている場合
            If pstrJigID <> vbNullString Then
                '@治具IDをｾｯﾄ
                If mlngTxtJigIndex = 0 Then
                    txtJig0.Text = pstrJigID
                    txtJigID(0) = txtJig0
                Else If mlngTxtJigIndex = 1
                    txtJig1.Text = pstrJigID
                    txtJigID(1) = txtJig1
                Else If mlngTxtJigIndex = 2
                    txtJig2.Text = pstrJigID
                    txtJigID(2) = txtJig2
                Else If mlngTxtJigIndex = 3
                    txtJig3.Text = pstrJigID
                    txtJigID(3) = txtJig3
                Else If mlngTxtJigIndex = 4
                    txtJig4.Text = pstrJigID
                    txtJigID(4) = txtJig4
                End If
            End If
            
            '@治具ID格納変数初期化
            pstrJigID = vbNullString
            
            '@治具にﾌｫｰｶｽｾｯﾄ
            Call pubSetFocus(txtJigID(mlngTxtJigIndex))
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdJigSelect_Click"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmdScrap_Click
    '機　能：在庫不良を入力するためにCF在庫処置画面を表示する
    '引　数：なし
    '戻り値：
    '作成日：2012/01/13 (Fri) 15:41:24 T.Oide
    '更新日：2012/01/13 (Fri) 15:41:24
    '備　考：
    Private Sub cmdScrap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdScrap.Click

        Dim lstrKeyID           As String       'ﾛｯﾄIDﾌｫｰｶｽ戻り位置用
        Dim llngTopRow          As Integer      '現在行を格納
        Dim ltypHoldConnect     As HoldConnect  '在庫管理引継ぎ構造体初期化用

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
            ptypHoldConnect = ltypHoldConnect     '一旦初期化
            With vsfInvLotList
            
                '@ﾀｲﾄﾙ以外か
                If .Row <> CMlngVsfRowTitle Then
                    ptypHoldConnect.strCarrierId = .GetData(.Row, CMlngvsfInvLLColCarrierID)           'ｷｬﾘｱID
                    ptypHoldConnect.strLotID = .GetData(.Row, CMlngvsfInvLLColCFLotID)                 'ﾛｯﾄID
                    cmbFlowClass.ValueCol = CMlngCmbGridCol0
                    ptypHoldConnect.strFlowClass = .GetData(.Row, CMlngvsfInvLLColFlowClass)           '流動区分
                    cmbFlowClass.ValueCol = CMlngCmbGridCol1
                    ptypHoldConnect.strLastUpdate = .GetData(.Row, CMlngvsfInvLLColEditTime)           '最終更新日時
                    ptypHoldConnect.strChipQuantity = .GetData(.Row, CMlngvsfInvLLColNum)              'ﾁｯﾌﾟ数量
                    ptypHoldConnect.strParentForm = Me.Text                                            '起動親ﾌｫｰﾑ
                End If
                
            End With
            
            '@ﾌｫｰｶｽ戻り位置を取得
            With vsfInvLotList
                '@ﾌｫｰｶｽを取得しているﾛｯﾄIDを格納
                lstrKeyID = .GetData(.Row, CMlngvsfInvLLColCFLotID)
                '@ﾌｫｰｶｽを取得している行番号を格納(ROW)
                llngTopRow = .Row
            End With
            
            '@Form_Loadﾌﾗｸﾞ(異常)
            pblnFormLoad = False
            
            '@CF処置画ﾛｰﾄﾞ
            frmxxEN00F7.Instance = New frmxxEN00F7()
            
            '@CF処置画名称設定
            frmxxEN00F7.Instance.Text = CPstrSubFormEN00F7
            
            '@Form_Loadﾌﾗｸﾞが異常の場合
            If pblnFormLoad = False Then
                '@異常の場合は子画面終了
                frmxxEN00F7.Instance = Nothing
                Exit Sub
            End If
            
            '@CF処置画面起動
            frmxxEN00F7.Instance.ShowDialog(Me)
            frmxxEN00F7.Instance = Nothing

            '@最新取得処理
            Call cmdSearch_Click(cmdSearch,New EventArgs)

            '@ﾌｫｰｶｽ戻り位置を設定
            Call pubGridFocus_Set(vsfInvLotList, lstrKeyID, CMlngvsfInvLLColCFLotID, cmdClose)
            
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
    '関数名：prvfrmxxEN02C0_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：2012/01/17 (Tue) 15:25:19 T.Oide
    '備　考：
    '　　　：
    Private Sub prvfrmxxEN02C0_Init()

        Dim lctlControl     As Control                      'ｺﾝﾄﾛｰﾙ名称取得用変数
        Dim llngIndex       As Integer                      'ｶｳﾝﾄ
        Dim lstrFormTitle   As String                       'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ
        Dim lcmbComboBoxEx  As SEComboBoxEx.ComboBoxEx      'NSYS ComboBox設定用変数
        Try
            
            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN02C0, lstrFormTitle)
            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
            
            '@退避領域の初期化
            mstrTaihiPartID = vbNullString
            mstrTaihiNumber = vbNullString
            mstrLotManagerID = vbNullString
            mstrUsePart = vbNullString
            
            '@各Comboﾎﾞｯｸｽの初期化
            cmbScreenSize.Clear                                     '画面ｻｲｽﾞ
            cmbPD.Clear                                             '機種
            cmbFlowClass.Clear                                      '流動区分
            cmbPart.Clear                                           '部材
            cmbRework.Clear                                         'ﾘﾜｰｸ回数
            cmbBoardThickness.Clear                                 '板厚
            cmbLotManager.Clear                                     'ﾛｯﾄ担当
            cmbThrowinWP.Clear                                      '投入装置
            
            '@Comboﾎﾞｯｸｽ設定(外枠設定のみ)
            For Each lctlControl In Me.Controls
                If TypeOf lctlControl Is SEComboBoxEx.ComboBoxEx Then
                    lcmbComboBoxEx = CType(lctlControl, SEComboBoxEx.ComboBoxEx)
                    With lcmbComboBoxEx
                        '@初期化
                        .DirectInput = False                        '直接入力(Flase)
                        .DispCols = CMlngCmbDispCols1               'ｸﾞﾘｯﾄﾞ表示列数
                        .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, _
                                      .Font.Unit, .Font.GdiCharSet, .Font.GdiVerticalFont)                      'ﾌｫﾝﾄｻｲｽﾞ   
                        .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize, .GridFont.Style, _  
                                      .GridFont.Unit, .GridFont.GdiCharSet, .GridFont.GdiVerticalFont)          'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                        .RowHeight = CMlngCmbRowHeight              'ﾘｽﾄ行の高さ
                        .BackColor = Color.White                    'ﾊﾞｯｸｶﾗｰの初期化
                    End With
                End If
            Next
            
            '@各Comboﾎﾞｯｸｽの初期化
            cmbScreenSize.Enabled = True                            '画面ｻｲｽﾞ
            cmbPD.Enabled = False                                   '機種
            cmbFlowClass.Enabled = False                            '流動区分
            cmbPart.Enabled = False                                 '部材
            cmbRework.Enabled = False                               'ﾘﾜｰｸ回数
            cmbBoardThickness.Enabled = False                       '板厚
            cmbLotManager.Enabled = False                           'ﾛｯﾄ担当
            cmbThrowinWP.Enabled = False                            '投入装置
            
            '@Textﾎﾞｯｸｽの初期化
            txtCarrierID.Text = vbNullString                        'ｷｬﾘｱID
            txtNumber.Text = vbNullString                           '詰数
            mstrCarrierID = vbNullString                            'ｷｬﾘｱID退避ｸﾘｱ
            
            '@治具ID
            txtJig0.Text = vbNullString
            txtJigID(0) = txtJig0
            txtJig1.Text = vbNullString
            txtJigID(1) = txtJig1
            txtJig2.Text = vbNullString
            txtJigID(2) = txtJig2
            txtJig3.Text = vbNullString
            txtJigID(3) = txtJig3
            txtJig4.Text = vbNullString
            txtJigID(4) = txtJig4

            '@ﾃｷｽﾄﾎﾞｯｸｽの活性化
            txtCarrierID.Enabled = False                            'ｷｬﾘｱID
            cmdCarrierSelect.Enabled = False                        '空きｷｬﾘｱﾎﾞﾀﾝ
            txtNumber.Enabled = False                               '詰数

            '@治具ID
            For llngIndex = CMlngtxtJigS To CMlngtxtJigE
                txtJigID(llngIndex).Enabled = False
            Next

            '@ﾗﾍﾞﾙの初期化
            lblVenderName.Text = vbNullString                    'ﾍﾞﾝﾀﾞｰ名称
            lblNowDate.Text = vbNullString                       '情報取得時間
            lblLotCnt.Text = vbNullString                        '該当件数
            lblCfLotID.Text = vbNullString                       '作成CFﾛｯﾄID
            lblMaxNum.Text = vbNullString                        '最大詰数
            lblThrowNum.Text = vbNullString                      '投入数
            lblEntryID.Text = vbNullString                       'ｴﾝﾄﾘ
            
            
            '@vsfInvLotListの初期化
            Call prvvsfInvLotList_Init()
            
            Call prvvsfJigList_Disp()
            '@Commandﾎﾞﾀﾝの初期化
            cmdAllClear.Enabled = False                             '全取消
            cmdRegist.Enabled = False                               '確定
            cmdSearch.Enabled = False                               '検索
            cmdClear.Enabled = False                                '取消
            cmdEntry.Enabled = False                                'ｴﾝﾄﾘﾎﾞﾀﾝ
            cmdKonsei.Enabled = False                               '混成ﾎﾞﾀﾝ
            cmdJigSelect.Enabled = False                            '空治具選択
        '@↓2012/01/17 (Tue) 15:24:37 T.Oide **************************************************
            cmdScrap.Enabled = False                                '在庫不良入力
        '@↑2012/01/17 (Tue) 15:24:37 T.Oide **************************************************
            
            
            '@閉じるﾎﾞﾀﾝのCausesValidationを設定する
            cmdClose.CausesValidation = False
            '@空きｷｬﾘｱ一覧のCausesValidationを設定する
            cmdCarrierSelect.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN02C0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfInvLotList_Init
    '機　能：利用部材一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：2012/01/16 (Mon) 16:09:23 T.Oide
    '備　考：
    Private Sub prvvsfInvLotList_Init()

        Try

            '@ﾌﾗｸﾞがTrueの場合は処理を中止
            If mblnvsfInitStop = True Then
                Exit Sub
            End If


            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfInvLotList

                .Redraw = False

                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear(ClearFlags.Content)
                
                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                .AllowSorting = AllowSortingEnum.SingleColumn
                        
                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                
                '@ﾌﾟﾛﾊﾟﾃｨの設定対象を選択されたｾﾙに設定
                
                '@ﾍｯﾀﾞｸﾘｯｸで全選択不可
                
                '@ﾏｳｽでｾﾙ範囲選択不可
                
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                .Styles.Normal.Trimming = StringTrimming.EllipsisCharacter
                
                '@一覧表の表題設定
        '@↓2012/01/16 (Mon) 16:08:55 T.Oide **************************************************
        '@        .Select CMlngVsfRowTitle, CMlngvsfInvLLColNo, CMlngVsfRowTitle, CMlngvsfInvLLColEditTime
        '@↑2012/01/16 (Mon) 16:08:55 T.Oide **************************************************
                Dim cellRange As CellRange = .GetCellRange(CMlngvsfRowTitle, CMlngvsfInvLLColNo, CMlngvsfRowTitle, CMlngvsfInvLLColFlowClass - 1)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                                '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))                  '背景色
                headerStyle.Font = New Font(.Font.FontFamily,CMlngvsfHFontSize,.Font.Style,.Font.Unit)              'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                 
                cellRange.Style = headerStyle

                '@列幅、ﾀｲﾄﾙ設定
                .Cols(CMlngvsfInvLLColNo).Width = CMlngvsfInvLLWColNo
                .SetData(CMlngVsfRowTitle, CMlngvsfInvLLColNo, CMstrvsfInvLLColNo)                            'No.

                .Cols(CMlngvsfInvLLColCFLotID).Width = CMlngvsfInvLLWColCFLotID
                .SetData(CMlngVsfRowTitle, CMlngvsfInvLLColCFLotID, CMstrvsfInvLLColCFLotID)                  'CFﾛｯﾄID

                .Cols(CMlngvsfInvLLColPassedTime).Width = CMlngvsfInvLLWColPassedTime
                .SetData(CMlngVsfRowTitle, CMlngvsfInvLLColPassedTime, CMstrvsfInvLLColPassedTime)            '経過時間

                .Cols(CMlngvsfInvLLColRegeneration).Width = CMlngvsfInvLLWColRegeneration
                .SetData(CMlngVsfRowTitle, CMlngvsfInvLLColRegeneration, CMstrvsfInvLLColRegeneration)        'ﾘﾜｰｸ

                .Cols(CMlngvsfInvLLColBoardThickness).Width = CMlngvsfInvLLWColBoardThickness
                .SetData(CMlngVsfRowTitle, CMlngvsfInvLLColBoardThickness, CMstrvsfInvLLColBoardThickness)    '厚

                .Cols(CMlngvsfInvLLColNum).Width = CMlngvsfInvLLWColNum
                .SetData(CMlngVsfRowTitle, CMlngvsfInvLLColNum, CMstrvsfInvLLColNum)                          '在庫枚数

                .Cols(CMlngvsfInvLLColEditTime).Width = CMlngvsfInvLLWColEditTime
                .SetData(CMlngVsfRowTitle, CMlngvsfInvLLColEditTime, CMlstrvsfInvLLColEditTime)               '更新日時

        '@↓2012/01/16 (Mon) 16:09:48 T.Oide **************************************************
                .Cols(CMlngvsfInvLLColCarrierID).Width = CMlngvsfInvLLWColCarrierID
                .SetData(CMlngVsfRowTitle, CMlngvsfInvLLColCarrierID, CMlstrvsfInvLLColCarrierID)             'ｷｬﾘｱID

                .Cols(CMlngvsfInvLLColFlowClass).Width = CMlngvsfInvLLWColFlowClass
                .SetData(CMlngVsfRowTitle, CMlngvsfInvLLColFlowClass, CMlstrvsfInvLLColFlowClass)             '流動区分
        '@↑2012/01/16 (Mon) 16:09:48 T.Oide **************************************************

                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight    '高さ
                
                '@更新日時を非表示にする
                .Cols(CMlngvsfInvLLColEditTime).Visible = False
        '@↓2012/01/17 (Tue) 10:13:23 T.Oide **************************************************
                .Cols(CMlngvsfInvLLColCarrierID).Visible = False
                .Cols(CMlngvsfInvLLColFlowClass).Visible = False
        '@↑2012/01/17 (Tue) 10:13:23 T.Oide **************************************************
                
                .Redraw = True

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
                .strProcName = "prvvsfInvLotList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfInvLotList_Disp
    '機　能：取得した利用部材を一覧表示
    '引　数：ltypPartLotList()：部材ﾛｯﾄﾘｽﾄ格納ﾃﾞｰﾀ
    '　　　：llngpartlotlistcnt：部材ﾛｯﾄﾘｽﾄｶｳﾝﾄ数
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：2012/01/16 (Mon) 15:58:03 T.Oide
    '備　考：
    '　　　：
    Private Sub prvvsfInvLotList_Disp(ByRef ltypPartLotList As List(Of PartLotList), _
                                       ByVal llngPartLotListCnt As Integer)

        Dim lstrFormatNum           As String               '該当件数ﾌｫｰﾏｯﾄ変更
        Dim llngDoCnt               As Integer              'ｶｳﾝﾄ
        Dim llngCnt                 As Integer              'ｶｳﾝﾄ
        Dim llngRow                 As Integer              '行ｶｳﾝﾄ
        Dim llngRowCnt              As Integer              'NSYS 行格納

        Try
            
            With vsfInvLotList
                If llngPartLotListCnt = 0 Then
                '@格納ﾃﾞｰﾀがない場合
                    '@部材一覧表示情報初期化
                    Call prvvsfInvLotList_Init()
                    
                    Exit Sub
                Else
                '@格納ﾃﾞｰﾀがある場合
                    'NSYS 選択行格納
                    llngRowCnt = .Row                
                    
                    '@描画ﾛｯｸ
                    .Redraw = False
                    
                    '@行ｶｳﾝﾀの初期化
                    llngRow = 0
                    For llngDoCnt = 0 To llngPartLotListCnt -1
                        '@現在状態が保留以外の場合
                        If ltypPartLotList(llngDoCnt).strCurrentStatus <> CPstrClass4J Then
                            '@行ｶｳﾝﾀｶｳﾝﾄｱｯﾌﾟ
                            llngRow = llngRow + 1
                            
                            '@行数設定
                            .Rows.Count = llngRow + 1
                            
                            '@ｾﾙ色変更
                            '@ﾌｫﾝﾄ色変更
                            Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_vbWhite" + .Row.ToString)
                            newStyle.BackColor = Color.White     '白色
                            newStyle.ForeColor = Color.Black     '黒色
                            Dim cellRange As CellRange = .GetCellRange(llngRow, CMlngVsfColTitle, llngRow, .Cols.Count - 2)
                            cellRange.Style = newStyle
                                        
                            '@ｽﾛｯﾄの高さの設定
                            .Rows(llngRow).Height = CMlngVsfHeight
                            
                            .SetData(llngRow, CMlngvsfInvLLColCFLotID, ltypPartLotList(llngDoCnt).strLotID)                         'CFﾛｯﾄID
                                
                            .SetData(llngRow, CMlngvsfInvLLColPassedTime,Mid$(ltypPartLotList(llngDoCnt).strLimitTime, 3, 14))      '制限時間
                                                  
                            '時間制限を越えている場合はﾊﾞｯｸｶﾗｰを赤に変更して使えないことをあらわす
                            If ltypPartLotList(llngDoCnt).strLimitTime < Format(Now, "yyyy/MM/dd HH:mm:ss") Then
        '@↓2012/01/17 (Tue) 15:16:06 T.Oide **************************************************
                                '.Cell(flexcpBackColor, llngRow, CMlngvsfInvLLColNo, llngRow, CMlngvsfInvLLColEditTime) = vbRed
                                Dim newStyle2 As CellStyle = .Styles.Add("CustomStyle_BackColor_vbRed" + .Row.ToString)
                                newStyle2.BackColor = Color.Red
                                Dim cellRange2 As CellRange = .GetCellRange(llngRow, CMlngvsfInvLLColNo, llngRow, CMlngvsfInvLLColFlowClass)
                                cellRange2.Style = newStyle2
        '@↑2012/01/17 (Tue) 15:16:06 T.Oide **************************************************
                            End If
                            
        '@↓2009/12/14 (Mon) 16:05:31 T.Oide **************************************************
        '@                    '在庫に入って1ｈ未満の部材はﾊﾞｯｸからを黄色表示(まだ使えない)
        '@                    ldateCreateTim = (Format(ltypPartLotList(llngDoCnt).strCreateTime, "YYYY/MM/DD HH:MM:SS"))
        '@                    ldateNow = (Format(Now, "YYYY/MM/DD HH:MM:SS"))
        '@
        '@                    If DateDiff("s", ldateCreateTim, ldateNow) <= CMlngLimitTimeInai Then
        '@                        .Cell(flexcpBackColor, llngRow, CMlngvsfInvLLColNo, llngRow, CMlngvsfInvLLColEditTime) = vbYellow
        '@                    End If
        '@↑2009/12/14 (Mon) 16:05:31 T.Oide **************************************************
                            
                            
                            .SetData(llngRow, CMlngvsfInvLLColBoardThickness, _
                                 ltypPartLotList(llngDoCnt).strThicknessCode)                               '厚
                                
                            .SetData(llngRow, CMlngvsfInvLLColRegeneration, _
                                 ltypPartLotList(llngDoCnt).strReworkCount)                                 'ﾘﾜｰｸ
                                
                            .SetData(llngRow, CMlngvsfInvLLColNum, _
                                 Format$(CInt(ltypPartLotList(llngDoCnt).strNum), CPstrDateFormatKanma))    '在庫枚数
                                
                            .SetData(llngRow, CMlngvsfInvLLColEditTime, _
                                                             ltypPartLotList(llngDoCnt).strLotLastUpdate)   '更新日時

        '@↓2012/01/16 (Mon) 15:58:44 T.Oide **************************************************
                            .SetData(llngRow, CMlngvsfInvLLColCarrierID, _
                                 ltypPartLotList(llngDoCnt).strCarrierId)                                   'ｷｬﾘｱID
                            
                            .SetData(llngRow, CMlngvsfInvLLColFlowClass, _
                                 ltypPartLotList(llngDoCnt).strFlowClass)                                   '流動区分
        '@↑2012/01/16 (Mon) 15:58:44 T.Oide **************************************************
                            
                        End If
                    Next
                    
                    '@表示位置設定
                    .Cols(CMlngvsfInvLLColCFLotID).TextAlign = TextAlignEnum.LeftCenter               '左中央　CFﾛｯﾄID
                    .Cols(CMlngvsfInvLLColPassedTime).TextAlign = TextAlignEnum.LeftCenter            '左中央　経過時間
                    .Cols(CMlngvsfInvLLColBoardThickness).TextAlign = TextAlignEnum.LeftCenter        '左中央　厚
                    .Cols(CMlngvsfInvLLColRegeneration).TextAlign = TextAlignEnum.RightCenter         '右中央　ﾘﾜｰｸ
                    .Cols(CMlngvsfInvLLColNum).TextAlign = TextAlignEnum.RightCenter                  '右中央　在庫枚数
                    .Cols(CMlngvsfInvLLColEditTime).TextAlign = TextAlignEnum.RightCenter             '右中央　更新日時
        '@↓2012/01/17 (Tue) 10:11:17 T.Oide **************************************************
                    .Cols(CMlngvsfInvLLColCarrierID).TextAlign = TextAlignEnum.LeftCenter             '左中央　ｷｬﾘｱID
                    .Cols(CMlngvsfInvLLColFlowClass).TextAlign = TextAlignEnum.LeftCenter             '左中央　流動区分
        '@↑2012/01/17 (Tue) 10:11:17 T.Oide **************************************************
                    
                    
                    '@行表示
                    For llngCnt = .Rows.Fixed To .Rows.Count - 1
                        .Rows(llngCnt).Visible = True
                    Next llngCnt
                    
                    '@№設定
                    For llngDoCnt = 1 To .Rows.Count - 1
                        .SetData(llngDoCnt, CMlngvsfInvLLColNo, llngDoCnt)
                        '@ｽﾛｯﾄの高さの設定
                        .Rows(llngDoCnt).Height = CMlngVsfHeight
                        
                        '@ｽﾛｯﾄ№のｾﾝﾀﾘﾝｸﾞ
                        .Cols(CMlngvsfInvLLColNo).TextAlign = TextAlignEnum.RightCenter      '右中央
                    Next llngDoCnt
                    
                    '@件数ﾒｯｾｰｼﾞ表示
                    lstrFormatNum = Format$(llngDoCnt - 1, CPstrDateFormatKanma)
                    lblLotCnt.Text = lstrFormatNum
                    
                    '@ﾕｰｻﾞによりｿｰﾄされている場合
                    If mtypChgSort.lngCnt > 0 Then
                        '@ｿｰﾄ保持ﾘｽﾄがなくなるまで
                        For llngCnt = 0 To mtypChgSort.lngCnt -1
                            '@該当行をｿｰﾄ
                            .Cols(mtypChgSort.typChgSortList(llngCnt).lngCol).Sort = mtypChgSort.typChgSortList(llngCnt).lngOrder
                            .Sort(SortFlags.UseColSort, mtypChgSort.typChgSortList(llngCnt).lngCol)
                        Next llngCnt
                    End If
                    
                    '@ｿｰﾄ検索用ｷｰ(ｷｬﾘｱID)がある場合
                    If mtypChgSort.strKey <> vbNullString Then
                        For llngCnt = .Rows.Fixed To .Rows.Count - 1
                            '@更新日時が同じ場合
                            If .GetData(llngCnt, CMlngvsfInvLLColEditTime) = mtypChgSort.strKey Then
                                .Row = llngCnt
                                '@ｶﾚﾝﾄ行の保持(ｸﾞﾘｯﾄﾞ、保持列)
                                Call pubVsfBeforeSort(vsfInvLotList, CMlngVsfColTitle)
                                '@ｿｰﾄ後のｶﾚﾝﾄ行設定(ｸﾞﾘｯﾄﾞ、保持列、前頁、次頁)
                                Call pubVsfAfterSort(vsfInvLotList, CMlngVsfColTitle,Nothing ,Nothing ,False, False, False, False)
                                Exit For
                            End If
                        Next llngCnt
                    End If
                    
                    .Row = llngRowCnt

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
                .strProcName = "prvvsfInvLotList_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfJigList_Init
    '機　能：編成ﾛｯﾄ一覧の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Public Sub prvvsfJigList_Init()

        Try

            '@一覧表示の各ｶﾗﾑの幅、ﾀｲﾄﾙを設定
            With vsfJigList
                '@ｽﾛｯﾄﾏｯﾌﾟｸﾘｱ
                .Clear(ClearFlags.Content)

                '@ｿｰﾄﾌﾟﾛﾊﾟﾃｨ初期化
                .AllowSorting = AllowSortingEnum.None

                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                
                '@ﾌﾟﾛﾊﾟﾃｨの設定対象を選択されたｾﾙに設定
                
                '@ﾍｯﾀﾞｸﾘｯｸで全選択不可
                
                '@ﾏｳｽでｾﾙ範囲選択不可
                
                '@ｾﾙ内の文字列がすべて表示できないときに、省略符号(...)を文字列の最後に表示
                
                '@一覧表の表題設定
                Dim cellRange As CellRange = .GetCellRange(CMlngvsfRowTitle, CMlngvsfJigListColNo, CMlngVsfRowTitle, CMlngvsfJigListColJigID - 1)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                                '文字色
                headerStyle.BackColor = ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))                  '背景色
                headerStyle.Font = New Font(.Font.FontFamily,CMlngvsfHFontSize,.Font.Style,.Font.Unit)              'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                 
                cellRange.Style = headerStyle

                '@列幅、ﾀｲﾄﾙ設定
                .Cols(CMlngvsfJigListColNo).Width = CMlngvsfJigListWColNo                                                   '№

                .Cols(CMlngvsfJigListColCFLotID).Width = CMlngvsfJigListWColCFLotID
                .SetData(CMlngVsfRowTitle, CMlngvsfJigListColCFLotID, CMstrvsfJigListColCFLotID)                'CFﾛｯﾄID

                .Cols(CMlngvsfJigListColPassedTime).Width = CMlngvsfJigListWColPassedTime
                .SetData(CMlngVsfRowTitle, CMlngvsfJigListColPassedTime, CMstrvsfJigListColPassedTime)          '経過時間

                .Cols(CMlngvsfJigListColBoardThickness).Width = CMlngvsfJigListWColBoardThickness
                .SetData(CMlngVsfRowTitle, CMlngvsfJigListColBoardThickness, CMstrvsfJigListColBoardThickness)  '厚

                .Cols(CMlngvsfJigListColNum).Width = CMlngvsfJigListWColNum
                .SetData(CMlngVsfRowTitle, CMlngvsfJigListColNum, CMstrvsfJigListColNum)                        '在庫枚数

                .Cols(CMlngvsfJigListColRegeneration).Width = CMlngvsfJigListWColRegeneration
                .SetData(CMlngVsfRowTitle, CMlngvsfJigListColRegeneration, CMstrvsfJigListColRegeneration)      'ﾘﾜｰｸ

                .Cols(CMlngvsfJigListColEditTime).Width = CMlngvsfJigListWColEditTime
                .SetData(CMlngVsfRowTitle, CMlngvsfJigListColEditTime, CMstrvsfJigListColEditTime)              '更新日時
                
                .Cols(CMlngvsfJigListColJigID).Width = CMlngvsfJigListWColJigID
                .SetData(CMlngVsfRowTitle, CMlngvsfJigListColJigID, CMstrvsfJigListColJigID)                    '治具ID

                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight    '高さ

                '@治具IDを非表示にする
                .Cols(CMlngvsfJigListColJigID).Visible = False
                
                '@更新日時を非表示にする
                .Cols(CMlngvsfJigListColEditTime).Visible = False
                
                '@ﾛｯｸ
                .Enabled = False

                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = False

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfJigList_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfJigList_Disp
    '機　能：治具一覧表示処理
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Sub prvvsfJigList_Disp()

        Dim llngCnt As Integer

        Try
            
            With vsfJigList
                '@治具一覧表示情報初期化
                Call prvvsfJigList_Init()
                
                '@描画ﾛｯｸ
                .Redraw = False
                
                '@行数設定
                .Rows.Count = CPlngJPaletteSlot + 1
                            
                '@表示位置設定
                .Cols(CMlngvsfJigListColCFLotID).TextAlign = TextAlignEnum.LeftCenter          '左中央　CFﾛｯﾄID
                .Cols(CMlngvsfJigListColPassedTime).TextAlign = TextAlignEnum.LeftCenter       '左中央　経過時間
                .Cols(CMlngvsfJigListColBoardThickness).TextAlign = TextAlignEnum.LeftCenter   '左中央　厚
                .Cols(CMlngvsfJigListColRegeneration).TextAlign = TextAlignEnum.LeftCenter     '左中央　ﾘﾜｰｸ
                .Cols(CMlngvsfJigListColNum).TextAlign = TextAlignEnum.RightCenter             '右中央　在庫枚数
                .Cols(CMlngvsfJigListColEditTime).TextAlign = TextAlignEnum.RightCenter        '右中央　更新日時
                .Cols(CMlngvsfJigListColJigID).TextAlign = TextAlignEnum.RightCenter           '右中央　治具ID
                
                '@行表示
                For llngCnt = .Rows.Fixed To .Rows.Count - 1
                    .Rows(llngCnt).Visible = True
                Next llngCnt
                
                '@№設定
                For llngCnt = 1 To .Rows.Count - 1
                    .SetData(.Rows.Count - llngCnt, CMlngvsfInvLLColNo, Format$(llngCnt, CPstrSlotNoFormat))
                    '@ｽﾛｯﾄの高さの設定
                    .Rows(llngCnt).Height = CMlngVsfHeight
                    '@ｽﾛｯﾄ№のｾﾝﾀﾘﾝｸﾞ
                    .Cols(CMlngvsfInvLLColNo).TextAlign = TextAlignEnum.RightCenter      '右中央
                Next llngCnt
                
                '@描画ﾛｯｸ解除
                .Redraw = True
                
                '@ｽﾌﾟﾚｯﾄﾞを初期値へ移動
                .LeftCol = CMlngVsfColTitle   '列
                .TopRow = CMlngVsfRowTitle    '行
                .Row = CMlngVsfRowTitle       'ｶﾚﾝﾄ行の移動
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfJigList_Disp"
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
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    Private Sub prvcmbScreenSize_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbScreenSize
                '@ｽｸﾘｰﾝｻｲｽﾞ初期化
                .Clear
                .Height = CMlngCmbRowHeight                                                 '高さ
                .DispCols = CMlngCmbDispCols1                                               'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol1                                               '値取得列
                .DirectInput = False    
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter                  '左寄中央揃え
                .ColAlignment(CMlngCmbGridCol1) = TextAlignEnum.LeftCenter                  '左寄中央揃え
                
                '@画面ｻｲｽﾞ情報ｾｯﾄ
                For llngCnt = 0 To mtypScreenSizeList.lngScreenSizeListCnt -1
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


    '関数名：prvcmbFlowClass_Disp
    '機　能：取得した機種をｺﾝﾎﾞにｾｯﾄ
    '引　数：なし
    '戻り値：
    '作成日：2009/07/21 (Tue) 10:45:38 T.Oide
    '更新日：2009/07/21 (Tue) 10:45:38
    '備　考：
    Private Sub prvcmbFlowClass_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lblnPR      As Boolean      'PRあり

        Try

            lblnPR = False
            
            With cmbFlowClass
                '@ｺﾝﾎﾞ初期化
                .Clear
                .Height = CMlngCmbRowHeight                                                 '高さ
                .DispCols = CMlngCmbDispCols2                                               'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol1                                               '値取得列
                .DirectInput = False    
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter                  '左寄中央揃え
                .ColAlignment(CMlngCmbGridCol1) = TextAlignEnum.LeftCenter                  '左寄中央揃え
                
                
                '@流動区分情報ｾｯﾄ
                For llngCnt = 0 To mlngDivisionCnt -1
                    .AddItem(mtypDivisionList(llngCnt).strDivisionID & _
                             vbTab & _
                             mtypDivisionList(llngCnt).strDivisionName)
                    
                    If mtypDivisionList(llngCnt).strDivisionID = CPstrFlowClassPR Then
                        lblnPR = True
                    End If
                             
                Next llngCnt
            End With
            
            '@ﾘｽﾄ内に"PR"がある場合は表示を"PR"にしてｺﾝﾎﾞを無効化
            If lblnPR = True Then
                cmbFlowClass.Text = CPstrFlowClassPR
                cmbFlowClass.Enabled = False
            Else
                cmbFlowClass.Enabled = True
            End If
            
            '@ﾘｽﾄが1つだけの時はデフォルト表示する
            If cmbFlowClass.ListCount = CPlngNumOne Then
                cmbFlowClass.ListIndex = CPlngNumZero
            End If
            
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbFlowClass_Disp"
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
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Sub prvcmbPd_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbPD
                '@ｽｸﾘｰﾝｻｲｽﾞ初期化
                .Clear
                .Height = CMlngCmbRowHeight                                     '高さ
                .DispCols = CMlngCmbDispCols1                                   'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol1                                   '値取得列
                .DirectInput = False
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .ColAlignment(CMlngCmbGridCol1) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .BackColor = SystemColors.Window                                'ﾊﾞｯｸｶﾗｰ(白)
                
                '@機種情報ｾｯﾄ('機種ID&機種ID名称 & PDﾊﾞｰｼﾞｮﾝ & Null & ForeColor & BackColor
                For llngCnt = 0 To mlngProductListCnt -1
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
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    Private Sub prvcmbPart_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbPart
                '@部品ｺﾝﾎﾞ初期化
                .Clear
                .Height = CMlngCmbRowHeight                                         '高さ
                .DispCols = CMlngCmbDispCols2                                       '表示列
                .ValueCol = CMlngCmbValueCol3                                       '値列
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter          '左寄中央揃え
                .ColAlignment(CMlngCmbGridCol1) = TextAlignEnum.LeftCenter          '左寄中央揃え
                .GroupCols = CMlngCmbGroupCol                                       '表示Col数
                .GroupRows = CMlngCmbGroupRow                                       '表示Row数
                .DirectInput = False                                                '直接入力不可
                
                '@部材情報ｾｯﾄ
                If mlngpartlistcnt > 0 Then
                    For llngCnt = 0 To mlngpartlistcnt -1
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
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Sub prvCmbLotManager_Disp()

        Dim llngCnt     As Integer      'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            With cmbLotManager

                .Clear
                .Height = CMlngCmbRowHeight                                                 '高さ
                .DispCols = CMlngCmbDispCols1                                               'ｸﾞﾘｯﾄﾞ表示列数
                .ValueCol = CMlngCmbValueCol1                                               '値取得列
                .DirectInput = False    
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter                  '左寄中央揃え
                .ColAlignment(CMlngCmbGridCol1) = TextAlignEnum.LeftCenter                  '左寄中央揃え
                
                '@ﾛｯﾄ担当者情報ｾｯﾄ
                '@空欄ありの為,最初の1行は空欄をｾｯﾄ
                .AddItem(CPstrSpace & vbTab & CPstrSpace)
                
                '@取得した情報を書き込む
                For llngCnt = 0 To mlngLotManagerListCnt -1
                    
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
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
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
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    Private Sub prvfraPart_Init()

        Try

            '@Comboのｸﾘｱ
        '@↓2009/08/05 (Wed) 17:49:57 T.Oide **************************************************
            mblnCmbChngeStop = True
        '@↑2009/08/05 (Wed) 17:49:57 T.Oide **************************************************
            cmbPart.Clear
            cmbBoardThickness.Clear
            cmbRework.Clear
        '@↓2009/08/05 (Wed) 17:50:07 T.Oide **************************************************
            mblnCmbChngeStop = False
        '@↑2009/08/05 (Wed) 17:50:07 T.Oide **************************************************
            
            
            cmbPart.Enabled = False
            cmbBoardThickness.Enabled = False
            cmbRework.Enabled = False
            
            '@ﾗﾍﾞﾙの初期化
            lblVenderName.Text = vbNullString
            
            '@利用部材一覧の初期化
            Call prvvsfInvLotList_Init()
            
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
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    Private Sub prvfraPart_Set()

        Try
            
            '@利用部材ﾌﾚｰﾑ/部品Comboを利用可能状態にする
            cmbPart.Enabled = True
                
            '@部品情報表示
            Call prvcmbPart_Disp()

            '@部品情報の件数ﾁｪｯｸ(件数によって処理を分岐)
            If mlngpartlistcnt = 1 Then
                '@取得件数が1件
                cmbPart.ListIndex = mlngpartlistcnt - 1
                
                '部品のValidateｲﾍﾞﾝﾄを呼び出す
                RemoveHandler cmbPart.Validating,AddressOf cmbPart_Validate
                Call cmbPart_Validate(cmbPart,New CancelEventArgs(False))
                AddHandler cmbPart.Validating,AddressOf cmbPart_Validate
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

        End Try
    End Sub

    '関数名：prvvsfJigList_Set
    '機　能：治具ﾘｽﾄ反映/取消処理
    '引　数：llngEventFlg:ｲﾍﾞﾝﾄﾌﾗｸﾞ　1:ｸﾘｯｸｲﾍﾞﾝﾄ<CMlngvsfClickFlg>
    '　　　：　　　　　　　　　　　　　2:反映ﾎﾞﾀﾝ<CMlngcmdReflectFlg>
    '　　　：　　　　　　　　　　　　　3:取消ﾎﾞﾀﾝ<CMlngcmdClearFlg>
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Sub prvvsfJigList_Set(ByVal llngEventFlg As Integer)

        Dim lstrPassedTime  As String           '経過時間退避変数
        Dim lstrCFLotID     As String           '出荷ﾛｯﾄID退避変数
        Dim lstrBT          As String           '板厚退避変数
        Dim lstrRework      As String           'ﾘﾜｰｸ回数退避変数
        Dim lstrEditTime    As String           '更新日時退避変数

        Try
            
            '@利用部材一覧の選択された値を取得
            With vsfInvLotList
                    
                '@CF編成一覧が選択されている場合に処理を行う
                If vsfJigList.Row > 0 Then
                    
                    '@選択箇所が空欄の場合
                    If vsfJigList.GetData(vsfJigList.Row, CMlngvsfJigListColPassedTime) = vbNullString Then
                        '@取消ﾎﾞﾀﾝの場合は反映しない
                        If llngEventFlg = CMlngcmdClearFlg Then
                            Exit Sub
                        End If
                        
                        '@ﾀｲﾄﾙ以外
                        If .Row > 0 Then
                            '@時間制限切れ確認
                            If .GetCellRange(.Row, .Col, .Row, .Col).StyleDisplay.BackColor = Color.Red Then
                                '時間制限きれエラーﾒｯｾｰｼﾞ表示
                                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgErr000N)
                                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                            Else
                                lstrCFLotID = .GetData(.Row, CMlngvsfInvLLColCFLotID)                          'CFﾛｯﾄID
                                lstrPassedTime = .GetData(.Row, CMlngvsfInvLLColPassedTime)                    '経過時間
                                lstrBT = .GetData(.Row, CMlngvsfInvLLColBoardThickness)                        '厚
                                lstrRework = .GetData(.Row, CMlngvsfInvLLColRegeneration)                      'ﾘﾜｰｸ
                                lstrEditTime = .GetData(.Row, CMlngvsfInvLLColEditTime)                        '更新日時
                        
                                '@ｽﾛｯﾄﾏｯﾌﾟへ値を反映
                                vsfJigList.SetData(vsfJigList.Row, CMlngvsfJigListColCFLotID,lstrCFLotID)          'CFﾛｯﾄID                                                                      
                                
                                vsfJigList.SetData(vsfJigList.Row, CMlngvsfJigListColPassedTime,lstrPassedTime)    '経過時間        
                                
                                vsfJigList.SetData(vsfJigList.Row, CMlngvsfJigListColBoardThickness,lstrBT)        '厚                              
                                
                                vsfJigList.SetData(vsfJigList.Row, CMlngvsfJigListColRegeneration,lstrRework)      'ﾘﾜｰｸ
                            
                                vsfJigList.SetData(vsfJigList.Row, CMlngvsfJigListColEditTime,lstrEditTime)                                                             '更新日時
                            
                                '@詰数設定
                                If txtNumber.Text <> vbNullString Then
                                    '@詰数が空欄ではない場合
                                    vsfJigList.SetData(vsfJigList.Row, CMlngvsfJigListColNum, txtNumber.Text)                   '在庫枚数
                                Else
                                    '@詰数が空欄の場合
                                    vsfJigList.SetData(vsfJigList.Row, CMlngvsfJigListColNum, CMlngDisp0)                       '在庫枚数     
                                End If
                            
                                vsfJigList.SetData(vsfJigList.Row, CMlngvsfJigListColJigID, txtJigID(vsfJigList.Row - 1).Text)  '治具ID                                                   
                            End If
                        End If
                    Else
                    '@選択箇所が空欄ではない場合、空を設定
                        vsfJigList.SetData(vsfJigList.Row, CMlngvsfJigListColCFLotID, vbNullString)                     'CFﾛｯﾄID
                            
                        vsfJigList.SetData(vsfJigList.Row, CMlngvsfJigListColPassedTime, vbNullString)                  '経過時間
                            
                        vsfJigList.SetData(vsfJigList.Row, CMlngvsfJigListColBoardThickness, vbNullString)              '厚
                            
                        vsfJigList.SetData(vsfJigList.Row, CMlngvsfJigListColRegeneration, vbNullString)                'ﾘﾜｰｸ
                            
                        vsfJigList.SetData(vsfJigList.Row, CMlngvsfJigListColNum, vbNullString)                         '在庫枚数
                        
                        vsfJigList.SetData(vsfJigList.Row, CMlngvsfJigListColEditTime, vbNullString)                    '更新日時
                            
                        vsfJigList.SetData(vsfJigList.Row, CMlngvsfJigListColJigID, vbNullString)

                        '@治具ID取消
                        If vsfJigList.Row - 1 = 0 Then
                            txtJig0.Text = vbNullString
                            txtJigID(0) = txtJig0
                        Else If vsfJigList.Row - 1 = 1
                            txtJig1.Text = vbNullString
                            txtJigID(1) = txtJig1
                        Else If vsfJigList.Row - 1 = 2
                            txtJig2.Text = vbNullString
                            txtJigID(2) = txtJig2
                        Else If vsfJigList.Row - 1 = 3
                            txtJig3.Text = vbNullString
                            txtJigID(3) = txtJig3
                        Else If vsfJigList.Row - 1 = 4
                            txtJig4.Text = vbNullString
                            txtJigID(4) = txtJig4
                        End If
                        
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
                .strProcName = "prvvsfJigList_Set"
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
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    Private Sub prvThrowNum_Set()

        Dim llngCnt                 As Integer  'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngTotalNumber         As Integer  '詰数合計

        Try
            
            '@初期化
            llngTotalNumber = 0
            
            '@投入数計算
            With vsfJigList
                For llngCnt = 1 To .Rows.Count - 1
                    If .GetData(llngCnt, CMlngvsfInvLLColNum) <> vbNullString Then
                        '@数値ﾁｪｯｸ
                        If IsNumeric(.GetData(llngCnt, CMlngvsfJigListColNum)) = True Then
                            llngTotalNumber = llngTotalNumber + CLng(.GetData(llngCnt, CMlngvsfJigListColNum))
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

    '関数名：prvcmdRegist_Chk
    '機　能：投入確定ﾎﾞﾀﾝﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：2009/08/05 (Wed) 13:31:50 T.Oide
    '備　考：
    '　　　：
    Private Sub prvcmdRegist_Chk()

        Dim llngCnt                 As Integer          'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lblnJudgeFlag           As Boolean          '確定ﾎﾞﾀﾝ有効/無効制御ﾌﾗｸﾞ(True:有効　False:無効)

        Try
                
            '@確定ﾎﾞﾀﾝ有効/無効制御ﾌﾗｸﾞの初期化
            lblnJudgeFlag = True
            
        '@↓2009/08/05 (Wed) 13:31:13 T.Oide **************************************************
            '@流動区分が未選択の場合
            If cmbFlowClass.Text = vbNullString Then
                '@確定ﾎﾞﾀﾝ無効
                lblnJudgeFlag = False
            End If
        '@↑2009/08/05 (Wed) 13:31:13 T.Oide **************************************************
            
            '@投入装置が未選択の場合
            If cmbThrowinWP.Text = vbNullString Then
                '@確定ﾎﾞﾀﾝ無効
                lblnJudgeFlag = False
            End If
            
            '@ｷｬﾘｱIDの入力桁数が6桁未満、または未入力か
            If txtCarrierID.NowByte <> txtCarrierID.ChrMaxByte Or _
                txtCarrierID.Text = vbNullString Then
                
                '@確定ﾎﾞﾀﾝ無効
                lblnJudgeFlag = False
            End If
            
            '@投入数のﾁｪｯｸ
            If IsNumeric(lblThrowNum.Text) = True Then
                If CLng(lblThrowNum.Text) = 0 Then
                    '@確定ﾎﾞﾀﾝ無効
                    lblnJudgeFlag = False
                End If
            End If

            '@ｸﾞﾘｯﾄﾞの入力ﾁｪｯｸ
            With vsfJigList
                
                '@確定ﾎﾞﾀﾝ有効/無効制御ﾌﾗｸﾞがTrueの場合
                If lblnJudgeFlag = True Then
                
                    For llngCnt = 1 To CPlngJPaletteSlot
                        
                        '@ｽﾛｯﾄﾏｯﾌﾟに情報が反映されていているか
                        If .GetData(llngCnt, CMlngvsfJigListColPassedTime) <> vbNullString Then
                            '@治具IDが入力されているか
                            If txtJigID(llngCnt - 1).Text <> vbNullString Then
                                '@確定ﾎﾞﾀﾝ制御ﾌﾗｸﾞをTrueにする
                                lblnJudgeFlag = True
                            Else
                                '@確定ﾎﾞﾀﾝ制御ﾌﾗｸﾞをFalseにする
                                lblnJudgeFlag = False
                            End If
                        Else
                            If txtJigID(llngCnt - 1).Text <> vbNullString Then
                                '@確定ﾎﾞﾀﾝ制御ﾌﾗｸﾞをFalseにする
                                lblnJudgeFlag = False
                            End If
                        End If
            
                    Next llngCnt
                End If
            End With

            '@確定ﾎﾞﾀﾝ制御ﾌﾗｸﾞをﾁｪｯｸする
            If lblnJudgeFlag = True Then
                '@確定ﾎﾞﾀﾝを有効にする
                cmdRegist.Enabled = True
            Else
                '@確定ﾎﾞﾀﾝを無効にする
                cmdRegist.Enabled = False
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
            With vsfJigList
                For llngRoopCnt = 1 To .Rows.Count - 1
                    If .GetData(llngRoopCnt, CMlngvsfJigListColPassedTime) <> vbNullString Then
                    '@経過時間に値が存在する場合
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
    '機　能：在庫不良入力の有効/無効ﾁｪｯｸ
    '引　数：なし
    '戻り値：
    '作成日：2012/01/17 (Tue) 16:20:31 T.Oide
    '更新日：2012/01/17 (Tue) 16:20:31
    '備　考：
    Private Sub cmdScrap_Chk(ByVal sender As Object, ByVal e As EventArgs)

        Try
            
            With vsfInvLotList
                
                '@ﾍｯﾀﾞｰ以外か
                If .Row > 0 Then
                    '@在庫不良入力ﾎﾞﾀﾝを有効にする
                    cmdScrap.Enabled = True
                Else
                    '@在庫不良入力ﾎﾞﾀﾝを無効にする
                    cmdScrap.Enabled = False
                End If
                
            End With
            
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
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
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
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Function prvblnCFInput_Chk() As Boolean
        
        Try

            prvblnCFInput_Chk = False
            
            '@利用部材選択ﾁｪｯｸ
            If vsfInvLotList.Row <= 0 Then
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
    '機　能：治具ID重複ﾁｪｯｸ
    '引　数：llngIndex:ｲﾝﾃﾞｯｸｽ
    '戻り値：True:入力OK/False:入力NG
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    Private Function prvblnPaletteID_Chk(ByVal llngIndex As Integer) As Boolean

        Dim llngCnt As Integer  'ﾙｰﾌﾟｶｳﾝﾄ

        Try

            prvblnPaletteID_Chk = True

            '@重複ﾁｪｯｸ実行
            '@index0～17まで
            For llngCnt = CMlngtxtJigS To CMlngtxtJigE
                '@indexが違う場合
                If llngIndex <> llngCnt Then
                    '@治具IDが重複している場合
                    If txtJigID(llngIndex).Text = txtJigID(llngCnt).Text Then
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
    '機　能：投入確定ﾁｪｯｸ(投入数と詰数、治具ﾏｯﾌﾟ、治具ID)
    '引　数：なし
    '戻り値：True:入力OK/False:入力NG
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Function prvblnRegist_Chk() As Boolean

        Dim llngCnt                 As Integer  'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngCnt2                As Integer  'ﾙｰﾌﾟｶｳﾝﾄ2
        Dim llngTotalNumber         As Integer  '詰数合計
        Dim lstrRegeneration        As String   'ﾘﾜｰｸ回数
        Dim blnSetDate              As Boolean  'vsfJigListに1行でも設定があればTrue
        Dim blnSetJig               As Boolean  'ｼﾞｸﾞがｾｯﾄされていればTrue


        Try
            
            '@ﾁｪｯｸ処理初期化
            prvblnRegist_Chk = False
            
            '@初期化
            llngTotalNumber = 0
            blnSetDate = False
            blnSetJig = False
            
            '@ｽﾛｯﾄﾏｯﾌﾟ&治具IDのﾁｪｯｸ、詰数の合計数の格納
            With vsfJigList
                For llngCnt = 1 To .Rows.Count - 1
                    
                    '@ｽﾛｯﾄﾏｯﾌﾟにﾃﾞｰﾀが反映されているか
                    If .GetData(llngCnt, CMlngvsfJigListColCFLotID) <> vbNullString Then
                    
                        'ﾃﾞｰﾀｾｯﾄOK
                        blnSetDate = True
                    
                        '@蒸着治具IDが入力されているか
                        If .GetData(llngCnt, CMlngvsfJigListColJigID) <> vbNullString And _
                            txtJigID(llngCnt - 1).Text <> vbNullString Then
                            
                                'ﾃﾞｰﾀｾｯﾄOK
                                blnSetJig = True
                        End If
                    End If
                    
                Next llngCnt
            End With
            
            'ﾃﾞｰﾀが無い場合はメッセージ表示
            If blnSetDate = False Then
                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000W, fraPart.Text)
                '@"<TRM0WW>$$[利用部材]が設定されていません。設定を見直してください。"を表示する
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                '@ﾌｫｰｶｽの移動
                Call pubSetFocus(vsfJigList)
                
                Exit Function
            End If
            
            '@蒸着治具IDが入力されているか
             If blnSetJig = False Then

                '@表示ﾒｯｾｰｼﾞ変換
                pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000W, lblJigIDTitle.Text)
                '@"<TRM0WW>$$[蒸着治具ID]が設定されていません。設定を見直してください。"を表示する
                Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)

                '@ﾌｫｰｶｽの移動
                Call pubSetFocus(txtJigID(llngCnt - 1))
                Exit Function
            End If
            
            
            
            '@枚数のﾁｪｯｸ
            With vsfJigList
                For llngCnt = 1 To .Rows.Count - 1
                    '@ﾃﾞｰﾀがある初めの行をﾁｪｯｸ
                    If .GetData(llngCnt, CMlngvsfJigListColRegeneration) <> vbNullString Then
                        '@ﾃﾞｰﾀがある初めの行の在庫枚数を退避
                        lstrRegeneration = .GetData(llngCnt, CMlngvsfJigListColRegeneration)
                        Exit For
                    End If
                Next llngCnt
                
                '@枚数のﾁｪｯｸ
                For llngCnt2 = llngCnt To .Rows.Count - 1
                    '@ﾘﾜｰｸ回数が異なる部材を混載下場合ｴﾗｰﾒｯｾｰｼﾞを表示する
                    If .GetData(llngCnt2, CMlngvsfJigListColRegeneration) <> vbNullString And _
                        .GetData(llngCnt2, CMlngvsfJigListColRegeneration) <> lstrRegeneration Then
                        '@表示ﾒｯｾｰｼﾞ変換
                        pstrDMsg = pubstrMsgReplace_Set(CPstrMsgWar000V)
                        '@"リワーク回数が異なる対向基板を混載する事はできません｡。"
                        Call publngMsgBoxInfo(pstrDMsg, vbExclamation, Me.Text, True, 16)
                        
                        '@ﾌｫｰｶｽの移動
                        Call pubSetFocus(vsfJigList)
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

    '関数名：prvfrmxxEN02C0_Minit
    '機　能：Private変数等の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：2012/01/13 (Fri) 16:04:15 T.Oide
    '備　考：
    '　　　：
    Private Sub prvfrmxxEN02C0_Minit()

        Dim mtypScreenSizeListInit  As ScreenSizeList   '初期化用ｽｸﾘｰﾝｻｲｽﾞ格納変数
    '@↓2012/01/13 (Fri) 16:05:15 T.Oide **************************************************
        Dim ltypHoldConnect         As HoldConnect      '在庫管理引継ぎ構造体初期化用
    '@↑2012/01/13 (Fri) 16:05:15 T.Oide **************************************************

        Try
            
            '@ｿｰﾄ保持用構造体のｸﾘｱ
            If mtypChgSort.typChgSortList Is Nothing Then
                mtypChgSort.typChgSortList = New List(Of ChgSortList) 
            Else
                mtypChgSort.typChgSortList.Clear
            End If
            '@使用構造体の初期化
            If mtypScreenSizeList.typScreenList Is Nothing Then     'ｽｸﾘｰﾝｻｲｽﾞ
                mtypScreenSizeList.typScreenList = New List(Of ScreenList)
            Else
                mtypScreenSizeList.typScreenList.Clear
            End If
            mtypScreenSizeList = mtypScreenSizeListInit     'ｽｸﾘｰﾝｻｲｽﾞｶｳﾝﾄ数
            
        '@↓2012/01/13 (Fri) 16:04:11 T.Oide **************************************************
            '@引継ぎ用構造体の初期化
            ptypHoldConnect = ltypHoldConnect
        '@↑2012/01/13 (Fri) 16:04:11 T.Oide **************************************************
                                 
            '機種
            If mtypProductList Is Nothing Then
                mtypProductList = New List(Of ProductList)
            Else
                mtypProductList.Clear
            End If
            '工順
            If mtypSeqList Is Nothing Then
                mtypSeqList = New List(Of EntryList)
            Else
                mtypSeqList.Clear
            End If
            '部品
            If mtyppartlist Is Nothing Then
                mtyppartlist = New List(Of PartClassList)
            Else
                mtyppartlist.Clear
            End If
            '板厚
            If mtypThicknessClassList Is Nothing Then
                mtypThicknessClassList = New List(Of ThicknessClassList)
            Else
                mtypThicknessClassList.Clear
            End If
            'ﾛｯﾄ担当
            If mtypLotManagerList Is Nothing Then
                mtypLotManagerList = New List(Of TechManList)
            Else
                mtypLotManagerList.Clear
            End If

            '@仕様変数初期化
            mlngProductListCnt = 0                          '機種格納数
            mlngOrderListCnt = 0                            '工順Ver.格納数'
            mlngpartlistcnt = 0                             '部品格納数
            mlngThicknessCnt = 0                            '板厚区分数
            mstrTaihiPartID = vbNullString                  '部品ID
            mstrTaihiVenderID = vbNullString                'ﾍﾞﾝﾀﾞｰ種別ID
            mstrTaihiNumber = vbNullString                  '詰め数格納
            mblnFormLoadFlag = False                        'ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞ

            'NSYS NSYS 蒸着治具ID
            ReDim txtJigID(4)
            txtJigID(0) = txtJig0
            txtJigID(1) = txtJig1
            txtJigID(2) = txtJig2
            txtJigID(3) = txtJig3
            txtJigID(4) = txtJig4

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN02C0_Minit"
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
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    '　　　：
    Private Function prvMasEntryList_Sel() As Boolean

        Dim lblnAns                     As Boolean              '戻り値(True/False)
        Dim lblnAns2                    As Boolean              '戻り値(True/False)
        Dim ltypEntryList               As List(Of EntryList)   'ﾏｽﾀ工順取得構造体
        Dim llngEntryListCnt            As Integer              'ﾏｽﾀ工順取得件数
        Dim lstrProductID               As String               'ﾛｰｶﾙ機種変数格納
        Dim lstrClassDivision           As String               '処理区分
        Dim ltypMasPartlist             As MasPartlist          '部材ｺｰﾄﾞﾘｽﾄ要求構造体

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
                    .strMsgVer = CMstrmas_mktocfpartlistVer 'ﾒｯｾｰｼﾞVersion
                    .strPdId = cmbPD.Text                   '機種ID
                    
                    '@PDﾊﾞｰｼﾞｮﾝ取得
                    cmbPD.ValueCol = CMlngCmbValueCol2
                    .strMasPdVersion = cmbPD.Value          'PDVersion
                    .strVenderClassID = mstrTaihiVenderID   '部品ID(部材ID)
                End With
                                
                '@部材ｺｰﾄﾞ、ﾍﾞﾝﾀﾞｰ取得
                lblnAns = pubblnMasMKtoCFPartList_Sel(ltypMasPartlist, _
                                                      mlngpartlistcnt, _
                                                      mtyppartlist)
                '@結果判定
                If lblnAns = False Then
                        
                    Exit Function
                End If
                
                '@利用部材ﾌﾚｰﾑの設定
                Call prvfraPart_Set()

                If ActiveControl.Name = cmbPD.Name Then
                    If cmbPart.Enabled = True Then
                        '@部材Comboへｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(cmbPart)
                    Else
                        '@閉じるへｾｯﾄﾌｫｰｶｽ
                        Call pubSetFocus(cmdClose)
                    End If
                End If

                '@↓2009/07/21 (Tue) 10:26:45 T.Oide **************************************************
                '@流動区分一覧取得
                lblnAns2 = pubblnMasFlowlist_Sel(CMstrmas_flowlistVer, _
                                                mtypDivisionList, _
                                                mlngDivisionCnt, _
                                                pstrSBID, _
                                                CPstrCD04, _
                                                cmbPD.Text)
                '@結果判定
                If lblnAns2 = False Then
                        
                    Exit Function
                End If
                
                '@流動区分をｺﾝﾎﾞにｾｯﾄ
                Call prvcmbFlowClass_Disp()
                
                '@↑2009/07/21 (Tue) 10:26:45 T.Oide **************************************************
                
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
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    Private Sub prvcmbThrowinWP_Disp()

        Dim llngCnt         As Integer  'ｶｳﾝﾄ

        Try
                
            '@投入装置ｾｯﾄ
            With cmbThrowinWP
                .Clear                                                                                  '初期化
                .DispCols = CMlngCmbDispCols1                                                           'ｸﾞﾘｯﾄﾞ表示列数
                .GetCol = CMlngCmbGridCol0                                                              'ﾃｷｽﾄ表示列
                .ValueCol = CMlngCmbGridCol1                                                            '値取得列
                .DirectInput = False                                                                    'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝﾘｽﾄ
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)           'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize,.Font.Style, .Font.Unit)'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
                .RowHeight = CMlngCmbRowHeight                                                          '行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter                              '左中央
                
                For llngCnt = 0 To mlngWpListCnt -1
                    .AddItem(ptypWPList(llngCnt).strWpName & vbTab & ptypWPList(llngCnt).strWpID)
                Next llngCnt
                
                '@装置が1件の場合、ﾃﾞﾌｫﾙﾄ表示
                If .ListCount = CPlngNumOne Then
                    '@1件目表示
                    .ListIndex = CPlngNumZero
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


    '関数名：cmdKonsei_Click
    '機　能：
    '引　数：なし
    '戻り値：
    '作成日：2009/05/20 (Wed) 16:52:35 T.Oide
    '更新日：2015/12/15 (Tue) 09:51:32 Y.Tanaka
    '備　考：
    Private Sub cmdKonsei_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdKonsei.Click
        
        Dim lngCnt      As Integer      'カウンタ
        Dim lngCnt2     As Integer
        
        lngCnt2 = 1
        
        '構造体にﾃﾞｰﾀｾｯﾄ
        With ptypeKonseiPartList
            .strSbID = pstrSBID
            .strPdId = cmbPD.Text
            .typePartList = mtyppartlist
            .lngPartListSize = mlngpartlistcnt
            
            '@指定なしの場合
            If cmbBoardThickness.Text = CPstrComboAppointNo Then
                .strBodyThickness = vbNullString
            
            '@指定なし以外の場合
            Else
                .strBodyThickness = Trim(cmbBoardThickness.Text)
            End If
            
            '@指定なしの場合
            If cmbRework.Text = CPstrComboAppointNo Then
                .strReworkCount = vbNullString
            
            '@指定なし以外の場合
            Else
                .strReworkCount = Trim(cmbRework.Text)
            End If
        End With
            
        
        '構造体にﾃﾞｰﾀｾｯﾄ
        With ptypeCfInvInfo
            .strjigId = txtJigID(plngvsfJigListRow - 1).Text        '冶具ID
            .strSlotNo = Format(5 - plngvsfJigListRow + 1, "0#")    'ｽﾛｯﾄ№
            .lngStuffCount = txtNumber.Text                         '詰数

            If .typeCfInvList Is Nothing Then
                .typeCfInvList = New List(Of CfInvList)
            Else
                .typeCfInvList.Clear
            End If

            '要素に画面ﾃﾞｰﾀ設定
            For lngCnt = 1 To vsfInvLotList.Rows.Count -1

                Dim typeCfInvListTmp As New CfInvList

                '制限時間がOKな物だけ入れる
                 If vsfInvLotList.GetCellRange(lngCnt, CMlngvsfInvLLColCFLotID).StyleDisplay.BackColor <> Color.Red Then
                
                    With typeCfInvListTmp
                        '要素の数設定
                        .strLotID = vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColCFLotID)             'ﾛｯﾄID
                        .strLimitTime = vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColPassedTime)      '制限時間
                        .strThickness = vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColBoardThickness)  '板厚
                        .lngReworkCnt = vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColRegeneration)    'ﾘﾜｰｸ
                        .lngQuantity = vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColNum)              'Chip数量
                        .strEditTime = vsfInvLotList.GetData(lngCnt, CMlngvsfInvLLColEditTime)         '更新日時
                        lngCnt2 = lngCnt2 + 1
                        ptypeCfInvInfo.lngListCnt = lngCnt2
                    End With
                    .typeCfInvList.Add(typeCfInvListTmp)
                End If
            Next
        End With
        
        frmxxEN02C1.Instance.ShowDialog(Me)
        frmxxEN02C1.Instance = Nothing

    End Sub

    '関数名：prvcmdKonsei_Chk
    '機　能：混成ﾎﾞﾀﾝの有効/無効ﾁｪｯｸ
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/21 (Mon) 16:43:11 S.Deguchi
    '更新日：2009/07/23 (Thu) 16:51:14 T.Oide
    '備　考：txtJigまたはvsfJigListが有効でﾀｲﾄﾙ以外が選択されている&治具IDが入力されている場合ﾎﾞﾀﾝを有効にする
    Private Sub prvcmdKonsei_Chk()

        Dim llngRoopCnt         As Integer  'ﾙｰﾌﾟｶｳﾝﾄ
        Dim llngInputFlg        As Integer  '入力ﾌﾗｸﾞ(1:入力無,2:入力有)

        Try
            
            '@初期化
            llngRoopCnt = 1
            llngInputFlg = 1
            
            cmdKonsei.Enabled = False
             
            
            '@CF完成在庫ｸﾞﾘｯﾄﾞはﾀｲﾄﾙ以外か
            If vsfInvLotList.Row > 0 Then
                '@ｼﾞｸﾞﾘｽﾄはﾀｲﾄﾙ以外か
                If vsfJigList.Row > 0 Then
                    '@ｼﾞｸﾞIDは入力済みか
                    If vsfJigList.GetData(vsfJigList.Row, CMlngvsfJigListColJigID) <> vbNullString Then
                    
                        cmdKonsei.Enabled = True

                    End If
                End If
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmdKonsei_Chk"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '@↓2012/01/24 (Tue) 12:09:28 T.Oide **************************************************共通関数pubGridFocus_Setに変更
    '関数名：prvFocus_Set
    '機　能：ﾌｫｰｶｽの戻り位置を設定
    '引　数：lobjControl: VSFlexGridオブジェクト
    '　　　：lstrKeyID：KeyID
    '　　　：llngKeyColNo：KeyIDのCol位置
    '　　　：llngTopRow：先頭行
    '戻り値：なし
    '作成日：2004/07/28 (Wed) 11:04:48 N.Kasai
    '更新日：2004/07/28 (Wed) 19:21:36 N.Kasai
    '備　考：ﾛｯﾄNoを検索してHitした場合は該当行にﾌｫｰｶｽｾｯﾄする。ない場合はｸﾞﾘｯﾄﾞにﾌｫｰｶｽｾｯﾄ
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
    '@↑2012/01/24 (Tue) 12:09:28 T.Oide **************************************************


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
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfInvLotList.BeforeDoubleClick, vsfJigList.BeforeDoubleClick

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
    Private Sub cursor_Enter(sender As Object, e As EventArgs) Handles _
                                                                       cmdScrap.Enter, 
                                                                       cmdKonsei.Enter, 
                                                                       cmbThrowinWP.Enter, 
                                                                       cmdClear.Enter, 
                                                                       cmdAllClear.Enter, 
                                                                       cmdEntry.Enter, 
                                                                       cmbScreenSize.Enter, 
                                                                       cmbPD.Enter, 
                                                                       cmbFlowClass.Enter, 
                                                                       cmdJigSelect.Enter, 
                                                                       cmdCarrierSelect.Enter, 
                                                                       txtCarrierID.Enter, 
                                                                       txtNumber.Enter, 
                                                                       vsfJigList.Enter, 
                                                                       txtJig0.Enter, 
                                                                       txtJig1.Enter, 
                                                                       txtJig2.Enter, 
                                                                       txtJig3.Enter, 
                                                                       txtJig4.Enter,
                                                                       cmbLotManager.Enter, 
                                                                       cmbPart.Enter, 
                                                                       cmdSearch.Enter, 
                                                                       cmbBoardThickness.Enter, 
                                                                       cmbRework.Enter, 
                                                                       vsfInvLotList.Enter, 
                                                                       cmdRegist.Enter, 
                                                                       cmdClose.Enter

                                            
        '選択されている項目の名前で判定
        Select sender.Name
            '投入予定一覧ボタン、閉じるボタンの場合は自動Validate = OFF
            Case cmdClose.Name, cmdCarrierSelect.Name
                Me.AutoValidate = Windows.Forms.AutoValidate.Disable
            '上記以外は自動Validate = ON
            Case Else
                Me.AutoValidate = Windows.Forms.AutoValidate.EnablePreventFocusChange
        End Select

    End Sub
    '関数名：vsfInvLotList_BeforeSort
    '機　能：ｸﾞﾘｯﾄﾞｿｰﾄ
    '引　数：Col：列
    '　　　：Order：並び順
    '戻り値：
    '作成日：2009/05/19 (Tue) 17:40:33 T.Oide
    '更新日：
    '備　考：
    Private Sub vsfInvLotList_BeforeSort(ByVal sender As Object, ByVal e As SortColEventArgs) Handles vsfInvLotList.BeforeSort

        Try

            'NSYS データ行がない場合は処理を抜ける
            If vsfInvLotList.Rows.Count <= vsfInvLotList.Rows.Fixed Then
                Return
            End If
            
            'NSYS 選択行格納
            mlngRowCnt = vsfInvLotList.Row

            Exit Sub

        Catch ex As Exception

            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "vsfInvLotList_BeforeSort"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub
End Class
