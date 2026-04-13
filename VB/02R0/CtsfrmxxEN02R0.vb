'ﾌｧｲﾙ名：xxEN02R0.frm ＜2019/12/25 マイグレ依頼ソース＞
'説　明：ロット投入(ALD)　メインフォーム
'作成日：2018/08/02 (Thu) 15:16:58 T.Oide
'更新日：2019/03/22 (Fri) 09:42:51 T.Oide
'備　考：
'Copyright(C) SEIKO EPSON CORPORATION 2018-2019, all rights reserved.
Option Explicit On
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Security.Permissions
Public Class frmxxEN02R0
    '***************************************************************************************
    '                              * Shared変数の記述 *
    '***************************************************************************************
    '======================================Private==========================================
    ' NSYS 追加
    Private Shared _instance        As frmxxEN02R0    ' ただ一つのフォームのインスタンスを保持する変数

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
    Public Shared Property Instance() As frmxxEN02R0
        Get
            '_instanceがNothingまたは破棄されているときは、
            '新しくインスタンスを作成する
            If _instance Is Nothing OrElse _instance.IsDisposed Then
                _instance = New frmxxEN02R0
            End If
            Return _instance
        End Get
        Set(ByVal value As frmxxEN02R0)
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
    '@↓2019/02/27 (Wed) 13:32:00 T.Oide **************************************************
    'Private Const CMstrLocalVersion                     As String = "01.00"
    Private Const CMstrLocalVersion                     As String = "01.01"
    '@↑2019/02/27 (Wed) 13:32:00 T.Oide **************************************************

    '@機能ID
    Private Const CMstrLocalMenuKey                     As String = CPstrKeyEN02R0          'ﾛｰｶﾙ機能ID

    '@Msgﾊﾞｰｼﾞｮﾝ
    Private Const CMstrmas_tapeStickGrListVer           As String = "01.00"                 'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟﾘｽﾄ取得
    Private Const CMstrmas_pdlist__Ver                  As String = "03.00"                 '機種区分一覧取得
    Private Const CMstrmas_flowlistVer                  As String = "04.00"                 '種別区分一覧取得
    Private Const CMstrbataldbatchlistVer               As String = "01.00"                 'ALDﾊﾞｯﾁﾘｽﾄ取得
    Private Const CMstrlot_throwinAldVer                As String = "01.00"                 'ﾛｯﾄ投入(ALD)
    Private Const CMstrinv_acptlotlistVer               As String = "05.00"                 '在庫ﾛｯﾄﾘｽﾄ
    Private Const CMstrmas_aldbatchrecipeVer            As String = "01.00"                 '防湿膜ALDﾊﾞｯﾁﾚｼﾋﾟ取得
    Private Const CMstrmas_aldbatchRegistVer            As String = "01.00"                 '防湿膜ALDﾊﾞｯﾁ情報登録
    Private Const CMstrmas_priolistVer                  As String = "01.00"                 '優先度情報取得
    Private Const CMstrmas_emplist_Ver                  As String = "02.00"                 '作業者ﾘｽﾄ取得


    '@vsfAldBatch設定
    ' 列定義
    Private Const CMlngvsfAldBatchColNo                 As Integer = 0                        '№
    Private Const CMlngvsfAldBatchColThrowinStatus      As Integer = 1                        '投入状態
    Private Const CMlngvsfAldBatchColLotId              As Integer = 2                        'ﾛｯﾄID
    Private Const CMlngvsfAldBatchColPd                 As Integer = 3                        '機種
    Private Const CMlngvsfAldBatchColWfNum              As Integer = 4                        'ｳｪﾊｰ数
    Private Const CMlngvsfAldBatchColChipNum            As Integer = 5                        'ﾁｯﾌﾟ数
    Private Const CMlngvsfAldBatchColACarrierGr         As Integer = 6                        'Aｷｬﾘｱｸﾞﾙｰﾌﾟ
    Private Const CMlngvsfAldBatchColTapeStickGr        As Integer = 7                        'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
    Private Const CMlngvsfAldBatchColACarrierNum        As Integer = 8                        'Aｷｬﾘｱ収容数
    Private Const CMlngvsfAldBatchColACarrierChipNum    As Integer = 9                        'Aｷｬﾘｱﾁｯﾌﾟ収容数(隠)
    Private Const CMlngvsfAldBatchColACarrierEmptNum    As Integer = 10                       'Aｷｬﾘｱ空きﾁｯﾌﾟ数
    Private Const CMlngvsfAldBatchColFlowClass          As Integer = 11                       '種別
    Private Const CMlngvsfAldBatchColTapeStickBatch     As Integer = 12                       'ﾃｰﾌﾟ貼りﾊﾞｯﾁID
    Private Const CMlngvsfAldBatchColTapeStickRecp      As Integer = 13                       'ﾃｰﾌﾟ貼りﾚｼﾋﾟ
    Private Const CMlngvsfAldBatchColOvenBatch          As Integer = 14                       'ｵｰﾌﾞﾝﾊﾞｯﾁID
    Private Const CMlngvsfAldBatchColOvenRecp           As Integer = 15                       'ｵｰﾌﾞﾝﾚｼﾋﾟ
    Private Const CMlngvsfAldBatchColAldBatch           As Integer = 16                       'ALDﾊﾞｯﾁID
    Private Const CMlngvsfAldBatchColAldBRecp           As Integer = 17                       'ALDﾚｼﾋﾟ

    ' 幅定義
    Private Const CMlngvsfAldBatchColWNo                As Integer = 37                       '№
    Private Const CMlngvsfAldBatchColWThrowinStatus     As Integer = 43                       '投入状態
    Private Const CMlngvsfAldBatchColWLotId             As Integer = 96                       'ﾛｯﾄID
    Private Const CMlngvsfAldBatchColWPd                As Integer = 60                       '機種
    Private Const CMlngvsfAldBatchColWWfNum             As Integer = 50                       'ｳｪﾊｰ数
    Private Const CMlngvsfAldBatchColWChipNum           As Integer = 60                       'ﾁｯﾌﾟ数
    Private Const CMlngvsfAldBatchColWTapeStickGr       As Integer = 98                       'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
    Private Const CMlngvsfAldBatchColWACarrierGr        As Integer = 84                       'Aｷｬﾘｱｸﾞﾙｰﾌﾟ
    Private Const CMlngvsfAldBatchColWACarrierNum       As Integer = 99                       'Aｷｬﾘｱ収容数(ｸﾞﾙｰﾌﾟ-ｳｪﾊｰ数(ﾁｯﾌﾟ数))
    Private Const CMlngvsfAldBatchColWACarrierChipNum   As Integer = 91                       'Aｷｬﾘｱﾁｯﾌﾟ収容数(隠)
    Private Const CMlngvsfAldBatchColWACarrierEmptNum   As Integer = 84                       'Aｷｬﾘｱ空ﾁｯﾌﾟ数
    Private Const CMlngvsfAldBatchColWFlowClass         As Integer = 47                       '種別
    Private Const CMlngvsfAldBatchColWTapeStickBatch    As Integer = 92                       'ﾃｰﾌﾟ貼りﾊﾞｯﾁID
    Private Const CMlngvsfAldBatchColWTapeStickRecp     As Integer = 88                       'ﾃｰﾌﾟ貼りﾚｼﾋﾟ
    Private Const CMlngvsfAldBatchColWOvenBatch         As Integer = 92                       'ｵｰﾌﾞﾝﾊﾞｯﾁID
    Private Const CMlngvsfAldBatchColWOvenRecp          As Integer = 87                       'ｵｰﾌﾞﾝﾚｼﾋﾟ
    Private Const CMlngvsfAldBatchColWAldBatch          As Integer = 92                       'ALDﾊﾞｯﾁID
    Private Const CMlngvsfAldBatchColWAldBRecp          As Integer = 87                       'ALDﾚｼﾋﾟ

    ' ﾀｲﾄﾙ表示
    Private Const CMstrvsfAldBatchColTNo                As String = "№"
    Private Const CMstrvsfAldBatchColThrowinStatus      As String = "投入"
    Private Const CMstrvsfAldBatchColTLotId             As String = "ロットID"
    Private Const CMstrvsfAldBatchColTPd                As String = "機種"
    Private Const CMstrvsfAldBatchColTWfNum             As String = "WF数"
    Private Const CMstrvsfAldBatchColTChipNum           As String = "CHIP数"
    Private Const CMstrvsfAldBatchColTTapeStickGr       As String = "テープ貼り" & vbCrLf & "グループ"
    Private Const CMstrvsfAldBatchColTACarrierGr        As String = "Aｷｬﾘｱ" & vbCrLf & "ｸﾞﾙｰﾌﾟ"         '隠し列
    Private Const CMstrvsfAldBatchColTACarrierNum       As String = "Aキャリア" & vbCrLf & "収容数"     '(ｸﾞﾙｰﾌﾟ-ｳｪﾊｰ数(ﾁｯﾌﾟ数))
    Private Const CMstrvsfAldBatchColTACarrierChipNum   As String = "AｷｬﾘｱCHIP" & vbCrLf & "収容数(隠)" '隠し列(Aﾄﾚｰ収容数xｳｪﾊｰ数)
    Private Const CMstrvsfAldBatchColTACarrierEmptNum   As String = "Aキャリア" & vbCrLf & "空CHIP数"
    Private Const CMstrvsfAldBatchColTFlowClass         As String = "種別"
    Private Const CMstrvsfAldBatchColTTapeStickBatch    As String = "テープ貼り" & vbCrLf & "バッチID"
    Private Const CMstrvsfAldBatchColTTapeStickRecp     As String = "テープ貼り" & vbCrLf & "レシピ"
    Private Const CMstrvsfAldBatchColTOvenBatch         As String = "オーブン" & vbCrLf & "バッチID"
    Private Const CMstrvsfAldBatchColTOvenRecp          As String = "オーブン" & vbCrLf & "レシピ"
    Private Const CMstrvsfAldBatchColTAldBatch          As String = "ALD" & vbCrLf & "バッチID"
    Private Const CMstrvsfAldBatchColTAldBRecp          As String = "ALD" & vbCrLf & "レシピ"

    '@ｸﾞﾘｯﾄﾞ共通の定数宣言
    Private Const CMlngVsfRowTitle                  As Integer = 0                         'ﾀｲﾄﾙ行(行)
    Private Const CMlngVsfColTitle                  As Integer = 0                         'ﾀｲﾄﾙ行(列)
    Private Const CMlngVsfHFontSize                 As Integer = 11                        'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngVsfHHeight                   As Integer = 35                        'ﾍｯﾀﾞｰの高さ
    Private Const CMlngVsfHeight                    As Integer = 24                        '1ｽﾛｯﾄの高さ
    Private Const CMstrLotHoldFlgOn                 As String = "1"                        '保留ﾛｯﾄﾌﾗｸﾞON
    Private Const CMlngFrozenColsBatch              As Integer = 8                         '固定列(ﾊﾞｯﾁ)
    Private Const CMlngFrozenColsInv                As Integer = 8                         '固定列(受入在庫)
    Private Const CMlngvsfColNo                     As Integer = 0                         '№
    Private Const CMlngNotFind                      As Integer = -1                        'FindRowして見つからない場合の値

    '@ﾓﾆﾀｵﾌﾟｼｮﾝ
    Private Const CMlngMoniterAri                   As Integer = 0                         '有
    Private Const CMlngMoniterNasi                  As Integer = 1                         '無

    '@ｺﾝﾎﾞﾎﾞｯｸｽ
    Private Const CMlngCmbFontSize                  As Integer = 11                        'ｺﾝﾎﾞﾎﾞｯｸｽﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbGridFontSize              As Integer = 11                        'ｺﾝﾎﾞﾎﾞｯｸｽｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ
    Private Const CMlngCmbDispCols                  As Integer = 1                         'ｸﾞﾘｯﾄﾞ表示列数
    Private Const CMlngCmbDispCol4                  As Integer = 4                         'ｸﾞﾘｯﾄﾞ表示列数=4
    Private Const CMlngCMbSelectMode                As Integer = 0                         '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=0)
    Private Const CMlngCmbRowHeight                 As Integer = 18                        'ﾘｽﾄ行の高さ
    Private Const CMstrCmbAddedComment              As String = " 項目選択"                '表示 文字列
    Private Const CMstrCmbAddedCommentNone          As String = "0 項目選択"               '表示 文字列「選択なし」
    Private Const CMlngCmbGridCol0                  As Integer = 0                         '選択列数
    Private Const CMlngCmbValueCol0                 As Integer = 0                         '値取得列=0
    Private Const CMlngCmbValueCol1                 As Integer = 1                         '値取得列=1
    Private Const CMlngCmbValueCol2                 As Integer = 2                         '値取得列=2
    Private Const CMlngCmbFirstIndex                As Integer = 0                         'ﾘｽﾄの先頭表示用
    Private Const CMstrCmbCheckOn                   As String = "1"                        'ﾁｪｯｸON
    Private Const CMstrCmbCheckOff                  As String = "0"                        'ﾁｪｯｸOff
    Private Const CMstrcmbPrioSel                   As Integer = 1                         'ﾘｽﾄｲﾝﾃﾞｯｸｽ
    Private Const CMlngCmbGroupCols                 As Integer = 1                         '列方向ｸﾞﾙｰﾌﾟ数
    Private Const CMlngCmbNotSelect                 As Integer = -1                        'ｺﾝﾎﾞ未選択状態

    '@ﾌｫｰﾏｯﾄ定数宣言
    Private Const CMlngFormatStart                  As Integer = 1                         'Mid取得先頭数(=1)
    Private Const CMlngFormatMid9                   As Integer = 9                         'Mid取得=9文字

    '@ﾁｪｯｸON/OFF
    Private Const CMlngChkOFF                       As Integer = 0                         'ﾁｪｯｸOFF
    Private Const CMlngChkON                        As Integer = 1                         'ﾁｪｯｸON

    '@その他
    Private Const CMlngMoniUsesWfNum                As Integer = 12                        'ﾓﾆﾀ使用時のｳｪﾊｰ数
    Private Const CMlngMoniUnUsesWfNum              As Integer = 13                        'ﾓﾆﾀ未使用時のｳｪﾊｰ数
    Private Const CMstrMoniter                      As String = "モニタ:"                  'モニタ有無表示用
    Private Const CMstrMoniterAri                   As String = "有"                       'モニタ有無表示用
    Private Const CMstrMoniterNasi                  As String = "無"                       'モニタ有無表示用
    Private Const CMstrProduct                      As String = "PRODUCT"                  'ﾊﾞｯﾁ流動区分判定用
    Private Const CMstrQuality                      As String = "QUALITY"                  'ﾊﾞｯﾁ流動区分判定用
    Private Const CMstrBatchFlowClassPR             As String = "製品"                     'ﾊﾞｯﾁ流動区分表示用
    Private Const CMstrBatchFlowClassQU             As String = "品確"                     'ﾊﾞｯﾁ流動区分表示用
    Private Const CMstrBatchSelect                  As String = "[バッチID]"               'ﾊﾞｯﾁｺﾝﾎﾞ表示用
    Private Const CMstrThrowInDate                  As String = "[投入予定日]"             'ﾊﾞｯﾁｺﾝﾎﾞ表示用
    Private Const CMstrMoniBatchClass               As String = "[モニタ バッチ区分]"      'ﾊﾞｯﾁｺﾝﾎﾞ表示用
    Private Const CMstrMoniBatchStatus              As String = "[バッチ状態]"             'ﾊﾞｯﾁｺﾝﾎﾞ表示用
    Private Const CMstrACarrier                     As String = "Aキャリア"                'グリッド表示用
    Private Const CmlngACrrierGr01                  As String = "01"                       'Aｷｬﾘｱｸﾞﾙｰﾌﾟ初期値
    Private Const CmlngACrrierGrFormat              As String = "0#"                       'Aｷｬﾘｱｸﾞﾙｰﾌﾟﾌｫｰﾏｯﾄ
    Private Const CmstrBatchString                  As String = "バッチ情報"               'ﾒｯｾｰｼﾞ表示用
    Private Const CmstrBatchStatusEdit              As String = "0"                        'ﾊﾞｯﾁｽﾃｰﾀｽ編集中
    Private Const CmstrBatchStatusThrowInWaite      As String = "1"                        'ﾊﾞｯﾁｽﾃｰﾀｽ投入待ち
    Private Const CmstrBatchStatusThrowIn           As String = "2"                        'ﾊﾞｯﾁｽﾃｰﾀｽ投入済
    Private Const CmstrBatchStatusThrowInEdit       As String = "3"                        'ﾊﾞｯﾁｽﾃｰﾀｽ再編集
    Private Const CmstrBatchStatusBatchOut          As String = "9"                        'ﾊﾞｯﾁｽﾃｰﾀｽ終了
    Private Const CmstrLotStatusThrowinWait         As String = "0"                        'ﾛｯﾄ投入待ちｽﾃｰﾀｽ
    Private Const CmstrBatchStatusHensyu            As String = "編集中"                   'DBﾃﾞｰﾀの編集中(画面の編集中はmblnEditFlagでみること)
    Private Const CmstrBatchStatusTonyuMachi        As String = "投入待ち"
    Private Const CmstrBatchStatusTonyu             As String = "投入済"
    Private Const CmstrBatchStatusSaihensyu         As String = "再編集"
    Private Const CmstrBatchStatusSyuryou           As String = "終了"
    Private Const CmstrBatchDelString               As String = "バッチ削除"               'ﾒｯｾｰｼﾞ表示用
    Private Const CmstrBatchEditString              As String = "バッチ編集"               'ﾒｯｾｰｼﾞ表示用
    Private Const CmstrThlowinStatusMi              As String = "未"                       '投入状態
    Private Const CmstrThlowinStatusSumi            As String = "済"                       '投入状態

    '****************************************************************************************
    '                                      *変数の記述*
    '****************************************************************************************
    '========================================Private=========================================
    Private mtypTapeStickList                       As TapeStickGrList                   'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟﾘｽﾄ
    Private mtypAldBatchList                        As typAldBatchList                   'ALDﾊﾞｯﾁﾘｽﾄ
    Private mtypeAldBatchRecipe                     As typAldBatchRecipeList             '防湿膜ALDの「ﾃｰﾌﾟ貼り」「ｵｰﾌﾞﾝ」「ALD」ﾚｼﾋﾟを格納
    Private mblnEventCancelFlag                     As Boolean                           'ｲﾍﾞﾝﾄｷｬﾝｾﾙﾌﾗｸﾞ
    Private mstrBefBatchId                          As String                            'ﾊﾞｯﾁID退避
    Private mtypPriorityReasonList                  As List(Of typPriorityReasonList)    '優先度格納構造体
    Private mlngPriorityReasonListCnt               As Integer                           '優先度格納数
    Private mtypLotManagerList                      As List(Of TechManList)              'ﾛｯﾄ担当一覧格納用
    Private mlngLotManagerListCnt                   As Integer                           'ﾛｯﾄ担当一覧格納数
    Private buttonProcessing                        As Boolean                           'NSYS ボタン2度押し対策
    Private mblnCloseFromControlMenu                As Boolean                           'NSYS システムコマンドでの画面クローズ
    Private mblnWindowClose                         As Boolean                           'NSYS WindowCloseフラグ
    Private mblnRedrawFlag                          As Boolean                           'NSYS Redrawフラグ
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
    '機　能：ﾌｫｰﾑﾛｰﾄﾞ処理
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/27 (Mon) 13:29:12 T.Oide
    '更新日：2018/08/27 (Mon)
    '備　考：
    Private Sub Form_Load()

        Dim lblnAns             As Boolean              '結果格納
        Dim lstrFormName        As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName       As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)

        Try
            
            '@Escﾎﾞﾀﾝを無効
            '@ﾌｫｰﾑﾛｰﾄﾞ中にEscﾎﾞﾀﾝを押させない
            Me.CancelButton = Nothing
            
            '@機能ﾊﾞｰｼﾞｮﾝの判定
            lblnAns = pubblnFuncVer_Chk(CPstrKeyEN02R0, CMstrLocalVersion)
            '@戻り値の判定
            If lblnAns = False Then
                
                '@異常終了の場合、Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose
                
                Exit Sub
            End If
            
            '@ﾌｫｰﾑ･ｲﾍﾞﾝﾄ名称取得
            lstrFormName = Me.Name
            lstrEventName = "Form_Load"
            
            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@画面情報の初期化
            Call prvfrmxxEN02R0_Init()

            '@ﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞ初期化
            Call prvvGrid_Init()

            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞの初期化
            pblnFormLoad = False

            '@初期化時のデータ取得表示
            If prvInitDataSelDisp = False Then
                Exit Sub
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
    '作成日：2005/07/08 (Fri) 13:28:37 S.Deguchi
    '更新日：2005/07/08 (Fri) 13:28:37
    '備　考：
    Private Sub Form_Activate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        Try
                        
            '@ﾌｫｰﾑﾛｰﾄﾞﾌﾗｸﾞによる処理分岐
            If pblnFormLoad = True Then

                '@ﾌﾗｸﾞを戻す
                pblnFormLoad = False

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                '@優先度の表示処理
                Call prvcmbPrioList_Disp()
            
                '@ﾛｯﾄ担当の表示処理
                Call prvCmbLotManagerList_Disp()

            End If
            
            '@ﾎﾞﾀﾝの有効/無効制御
            Call prvBtnCtl()
            
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

    '関数名：cmbAldBatch_Change
    '機　能：選択したﾊﾞｯﾁの情報をﾊﾞｯﾁｸﾞﾘｯﾄﾞに表示する
    '引　数：なし
    '戻り値：
    '作成日：2018/08/07 (Tue) 13:34:39 T.Oide
    '更新日：2018/08/07 (Tue) 13:34:39
    '備　考：
    Private Sub cmbAldBatch_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbAldBatch.Change

        Try
            
            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙ中は処理しない
            If mblnEventCancelFlag = True Then
                Exit Sub
            End If
               
            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙ設定
            mblnEventCancelFlag = True
            
            If cmbAldBatch.Text = CMstrBatchSelect Then
                
                '@新規作成の場合､ｸﾞﾘｯﾄﾞ初期化
                Call prvvGrid_Init()
                
                '@投入予定日初期化
                labThrowInDate.Text = vbNullString
                
                '@モニタ初期化
                labMoniter.Text = vbNullString
                
                '@バッチ流動区分初期化
                labBatchFlowClass.Text = vbNullString
                
                '@状態初期化
                labStatus.Text = vbNullString
                        
                '@範囲選択可
                vsfAldBatch.SelectionMode = SelectionModeEnum.ListBox
                
                '@ﾊｲﾗｲﾄする
                vsfAldBatch.HighLight = HighLightEnum.WithFocus
                
                '@優先度(2：普通に設定)
                cmbPriority.Text = vbNullString
                
                '@ﾛｯﾄ担当者ｸﾘｱ
                cmbLotManager.Text = vbNullString

            Else
                '@既存ﾊﾞｯﾁ情報の場合
                ' ﾊﾞｯﾁの情報をﾊﾞｯﾁｸﾞﾘｯﾄﾞに表示する
                Call prvvsfAldBatch_Disp()
                
                '@範囲選択不可
                vsfAldBatch.SelectionMode = SelectionModeEnum.Row
                
                '@ﾊｲﾗｲﾄしない(ﾏｰｼﾞしたｾﾙをﾊｲﾗｲﾄすると見栄えが悪いので)
                vsfAldBatch.HighLight = HighLightEnum.Never
            
            End If

            '@ｲﾍﾞﾝﾄｷｬﾝｾﾙ戻し
            mblnEventCancelFlag = False
            
            '@ﾎﾞﾀﾝ有効/無効制御
            Call prvBtnCtl()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbAldBatch_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbLotManager_Change
    '機　能：ﾛｯﾄ担当者変更時にﾎﾞﾀﾝ有効/無効
    '引　数：なし
    '戻り値：
    '作成日：2018/09/03 (Mon) 16:29:58 T.Oide
    '更新日：2018/09/03 (Mon) 16:29:58
    '備　考：
    Private Sub cmbLotManager_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbLotManager.Change

        Try
            
            '@ﾎﾞﾀﾝ有効/無効制御
            Call prvBtnCtl()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbLotManager_Change"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：cmbPriority_Change
    '機　能：優先度変更時にﾎﾞﾀﾝ有効/無効
    '引　数：なし
    '戻り値：
    '作成日：2018/09/03 (Mon) 16:30:02 T.Oide
    '更新日：2018/09/03 (Mon) 16:30:02
    '備　考：
    Private Sub cmbPriority_Change(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPriority.Change

        Try
            
            '@ﾎﾞﾀﾝ有効/無効制御
            Call prvBtnCtl()
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmbPriority_Change"
                .strErrMessage = vbNullString
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
    '作成日：2018/08/07 (Tue) 11:47:43 T.Oide
    '更新日：2018/08/07 (Tue) 11:47:43
    '備　考：
    Private Sub Form_QueryUnload(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim lblnAnsTerm             As Boolean              '開放結果格納

        Try

            '@×にて閉じた場合は閉じるﾎﾞﾀﾝをCALLする
            If mblnCloseFromControlMenu Then
                RemoveHandler MyBase.FormClosing, AddressOf Form_QueryUnload
                Call cmdClose_Click(cmdClose,New EventArgs)
                AddHandler MyBase.FormClosing, AddressOf Form_QueryUnload
            End If

            '@ActInitﾌﾗｸﾞの判定
            If pblnActInitFlg = True Then
                '@Actを自前で初期化した場合

                '@ACTｵﾌﾞｼﾞｪｸﾄの開放
                lblnAnsTerm = pubblnAct_Term
                
                '@ACTｵﾌﾞｼﾞｪｸﾄ開放処理が正常に行われたか
                If lblnAnsTerm = True Then
                    '@処理なし(ﾌｫｰﾑをｱﾝﾛｰﾄﾞして終了)
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

    '関数名：cmdNowList_Click
    '機　能：受入在庫-最新取得
    '引　数：なし
    '戻り値：なし
    '作成日：2004/06/28 (Mon) 17:31:46 S.Deguchi
    '更新日：2004/10/18 (Mon) 17:18:55 Y.Yamagishi
    '備　考：
    '　　　：2004/10/18 (Mon) 17:18:55 Y.Yamagishi  0件表示のﾒｯｾｰｼﾞﾎﾞｯｸｽを表示しない(ｺﾒﾝﾄｱｳﾄ)不具合改善№1093
    '　　　：2008/07/07 (Mon) 12:00:00 S.Ochiai     欠損ﾁｯﾌﾟ表示対応(No.03046)及びSource整備
    Private Sub cmdNowList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdNowList.Click

        Dim lblnAns                 As Boolean              '結果格納
        Dim lstrFormName            As String               'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String               'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrBatchID             As String

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If

            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称の取得設定
            lstrFormName = Me.Name
            lstrEventName = "cmdNowList_Click"

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)
            
            '@ﾊﾞｯﾁID選択中か
            If cmbAldBatch.Value <> CMstrBatchSelect Then
                '@バッチID退避
                lstrBatchID = cmbAldBatch.Value
            End If
                        
            '@画面初期化
            Call prvfrmxxEN02R0_Init()

            '================
            '@貼りｸﾞﾙｰﾌﾟ取得
            '================
            lblnAns = pubblnMasTapeStickGrList_Sel(CMstrmas_tapeStickGrListVer, _
                                                   mtypTapeStickList, _
                                                   pstrSBID)
            '@結果判定
            If lblnAns = False Then
                '@ﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞ初期化
                Call prvvGrid_Init()

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                Exit Sub
            End If

            '================
            '@ALDﾊﾞｯﾁ一覧取得
            ' 最新を取得して表示
            '================
            lblnAns = pubblnAldBatchList_Sel(CMstrbataldbatchlistVer, _
                                             mtypAldBatchList)
            '@結果判定
            If lblnAns = False Then
                '@ﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞ初期化
                Call prvvGrid_Init()

                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                Exit Sub
            End If

            '@ﾊﾞｯﾁｺﾝﾎﾞ設定
            Call prvcmbAldBatch_Disp()

            '@取得時刻表示
            lblNowDate.Text = Format$(Now, CPstrDateFormat)
            
            '@退避したﾊﾞｯﾁIDがある場合は再表示
            If lstrBatchID <> vbNullString Then
                '@退避バッチIDを再表示
                cmbAldBatch.Text = lstrBatchID
            Else
                '@新規作成を初期表示
                cmbAldBatch.ListIndex = CMlngCmbFirstIndex
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

    '関数名：cmdThrowin_Click
    '機　能：ﾛｯﾄ投入実行
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/15 (Wed) 09:01:07 T.Oide
    '更新日：2018/08/15 (Wed) 09:01:07
    '備　考：
    Private Sub cmdThrowin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdThrowin.Click

        Try

            'NSYS クリック処理中は処理を抜ける
            If Me.ActiveControl Is sender Then
                If Me.buttonProcessing = True Then
                    Return
                End If
                Me.buttonProcessing = True
            End If
               
            '@ﾛｯﾄ投入(ALD)
            Call prvAldBatchThrowin()

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "cmdThrowin_Click"
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
    '作成日：2018/08/02 (Thu) 17:08:43 T.Oide
    '更新日：2018/08/02 (Thu) 17:08:43
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
            Call publngEnd_Proc(CPstrKeyEN02R0, ltypCommonInfo)

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

    '@'****************************************************************************************
    '@'                                      *関数の記述*
    '@'****************************************************************************************
    '@'========================================Private=========================================

    '関数名：prvfrmxxEN02R0_Init
    '機　能：画面情報の初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/07 (Tue) 13:29:06 T.Oide
    '更新日：2018/08/07 (Tue) 13:29:06
    '備　考：
    Private Sub prvfrmxxEN02R0_Init()

        Dim lstrFormTitle       As String           'ﾌｫｰﾑのｷｬﾌﾟｼｮﾝ

        Try

            '@ﾒﾆｭｰｷｰから機能毎の関連情報を取得する。
            Call pubMenuItemCorrelation_Set(CPstrKeyEN02R0, lstrFormTitle)

            '@ﾌｫｰﾑのｷｬﾌﾟｼｮﾝを設定
            Me.Text = lstrFormTitle
                        
            '@情報取得日時ｸﾘｱ
            lblNowDate.Text = vbNullString

            '@ﾃﾞｰﾀ格納変数初期化
            'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟﾘｽﾄ
            If mtypTapeStickList.typTapeStickGr Is Nothing Then
                mtypTapeStickList.typTapeStickGr = New List(Of TapeStickGr)
            Else
                mtypTapeStickList.typTapeStickGr.Clear
            End If
            mtypTapeStickList.lngTapeStickGrCnt = 0
               
            With mtypAldBatchList                       'ALDﾊﾞｯﾁﾘｽﾄ
                .strSbID = vbNullString
                .lngAldBatchListCnt = 0
                If .typAldBatchList Is Nothing Then
                    .typAldBatchList = New List(Of typAldBatch)
                Else
                    .typAldBatchList.Clear
                End If
            End With
            
            mtypeAldBatchRecipe.lngAldBatchRecipeCnt = 0
            '防湿膜ALDの「ﾃｰﾌﾟ貼り」「ｵｰﾌﾞﾝ」「ALD」ﾚｼﾋﾟを格納
            If mtypeAldBatchRecipe.typeAldBatchRecipe Is Nothing Then
                mtypeAldBatchRecipe.typeAldBatchRecipe = New List(Of AldBatchRecipe)
            Else
                mtypeAldBatchRecipe.typeAldBatchRecipe.Clear
            End If

            '@モニター
            labMoniter.Text = vbNullString
            
            '@閉じるﾎﾞﾀﾝへCausesValidationを設定する
            cmdClose.CausesValidation = False

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvfrmxxEN02R0_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvGrid_Init
    '機　能：ｸﾞﾘｯﾄﾞ初期化
    '引　数：なし
    '戻り値：なし
    '作成日：2018/08/07 (Tue) 11:51:04 T.Oide
    '更新日：2018/08/07 (Tue) 11:51:04
    '備　考：
    Private Sub prvvGrid_Init()

        Try

            With vsfAldBatch

                'NSYS ちらつき対策
                If mblnRedrawFlag = False Then
                    .Redraw = False
                End If

                '@初期行数設定
                .Rows.Count = .Rows.Fixed
                
                '@ﾌｫｰｶｽ枠のｽﾀｲﾙを設定
                .FocusRect = FocusRectEnum.Light
                
                '@行列のﾏｳｽでの幅変更を可にする
                .AllowResizing = AllowResizingEnum.Columns

                .SelectionMode = SelectionModeEnum.ListBox       'これじゃないと「.SelectedRows」で選択行数が取得できない

                .Styles.Focus.Clear

                '@一覧表のﾀｲﾄﾙ設定
                Dim cellRange As CellRange = .GetCellRange(CMlngVsfRowTitle, CMlngvsfColNo, CMlngVsfRowTitle, .Cols.Count - 1)
                Dim headerStyle As CellStyle = .Styles.Add("headerStyle")
                headerStyle.ForeColor = Color.Yellow                                                                                             '文字色
                headerStyle.BackColor =  ColorTranslator.FromWin32(Convert.ToInt32(CPlngBlueColor))                                              '背景色
                headerStyle.Font = New Font(headerStyle.Font.FontFamily, CMlngvsfHFontSize, headerStyle.Font.Style, headerStyle.Font.Unit)       'ﾍｯﾀﾞｰﾌｫﾝﾄｻｲｽﾞ
                headerStyle.TextAlign = TextAlignEnum.CenterCenter                                                                               '@表示位置の設定(ﾀｲﾄﾙ:中央寄せ中央揃え)
                cellRange.Style = headerStyle

                '@ﾍｯﾀﾞｰの高さを設定
                .Rows(CMlngVsfRowTitle).Height = CMlngVsfHHeight      '高さ
                        
                '@Aｷｬﾘｱｸﾞﾙｰﾌﾟ非表示
                .Cols(CMlngvsfAldBatchColACarrierGr).Visible = False
            
                '@ｿｰﾄﾌ(ﾍｯﾀﾞｰｸﾘｯｸでｿｰﾄしない)
                .AllowSorting = AllowSortingEnum.None
                
                '@ﾊｲﾗｲﾄする
                .HighLight = HighLightEnum.WithFocus
                .Cols(CMlngvsfAldBatchColACarrierChipNum).Visible = False   'AｷｬﾘｱCHIP収容数(隠)

                '@ﾀｲﾄﾙ設定
                .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColNo, CMstrvsfAldBatchColTNo)
                .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColLotId, CMstrvsfAldBatchColTLotId)
                .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColThrowinStatus, CMstrvsfAldBatchColThrowinStatus)
                .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColPd, CMstrvsfAldBatchColTPd)
                .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColWfNum, CMstrvsfAldBatchColTWfNum)
                .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColChipNum, CMstrvsfAldBatchColTChipNum)
                .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColTapeStickGr, CMstrvsfAldBatchColTTapeStickGr)
                .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColACarrierGr, CMstrvsfAldBatchColTACarrierGr)
                .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColACarrierNum, CMstrvsfAldBatchColTACarrierNum)
                .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColACarrierChipNum, CMstrvsfAldBatchColTACarrierChipNum)
                .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColACarrierEmptNum, CMstrvsfAldBatchColTACarrierEmptNum)
                .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColFlowClass, CMstrvsfAldBatchColTFlowClass)
                .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColTapeStickBatch, CMstrvsfAldBatchColTTapeStickBatch)
                .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColTapeStickRecp, CMstrvsfAldBatchColTTapeStickRecp)
                .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColOvenBatch, CMstrvsfAldBatchColTOvenBatch)
                .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColOvenRecp, CMstrvsfAldBatchColTOvenRecp)
                .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColAldBatch, CMstrvsfAldBatchColTAldBatch)
                .SetData(CMlngVsfRowTitle, CMlngvsfAldBatchColAldBRecp, CMstrvsfAldBatchColTAldBRecp)
                
                '@幅設定
                .Cols(CMlngvsfAldBatchColNo).Width = CMlngvsfAldBatchColWNo
                .Cols(CMlngvsfAldBatchColLotId).Width = CMlngvsfAldBatchColWLotId
                .Cols(CMlngvsfAldBatchColThrowinStatus).Width = CMlngvsfAldBatchColWThrowinStatus
                .Cols(CMlngvsfAldBatchColPd).Width = CMlngvsfAldBatchColWPd
                .Cols(CMlngvsfAldBatchColWfNum).Width = CMlngvsfAldBatchColWWfNum
                .Cols(CMlngvsfAldBatchColChipNum).Width = CMlngvsfAldBatchColWChipNum
                .Cols(CMlngvsfAldBatchColTapeStickGr).Width = CMlngvsfAldBatchColWTapeStickGr
                .Cols(CMlngvsfAldBatchColACarrierGr).Width = CMlngvsfAldBatchColWACarrierGr
                .Cols(CMlngvsfAldBatchColACarrierNum).Width = CMlngvsfAldBatchColWACarrierNum
                .Cols(CMlngvsfAldBatchColACarrierChipNum).Width = CMlngvsfAldBatchColWACarrierChipNum
                .Cols(CMlngvsfAldBatchColACarrierEmptNum).Width = CMlngvsfAldBatchColWACarrierEmptNum
                .Cols(CMlngvsfAldBatchColFlowClass).Width = CMlngvsfAldBatchColWFlowClass
                .Cols(CMlngvsfAldBatchColTapeStickBatch).Width = CMlngvsfAldBatchColWTapeStickBatch
                .Cols(CMlngvsfAldBatchColTapeStickRecp).Width = CMlngvsfAldBatchColWTapeStickRecp
                .Cols(CMlngvsfAldBatchColOvenBatch).Width = CMlngvsfAldBatchColWOvenBatch
                .Cols(CMlngvsfAldBatchColOvenRecp).Width = CMlngvsfAldBatchColWOvenRecp
                .Cols(CMlngvsfAldBatchColAldBatch).Width = CMlngvsfAldBatchColWAldBatch
                .Cols(CMlngvsfAldBatchColAldBRecp).Width = CMlngvsfAldBatchColWAldBRecp

                '@ｾﾙのﾏｰｼﾞ設定(解除)
                Call prvVsfGridMergeCol(False)

                '@折り返し表示(「Aｷｬﾘｱ数(収容数)」を折返し表示したい)
                '.WordWrap = True

                '@固定列の設定
                .Cols.Frozen = CMlngFrozenColsBatch
                  
                If mblnRedrawFlag = False Then
                    .Redraw = True
                    
                    '@ﾛｯｸ
                    .Enabled = False
                End If

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvGrid_Init"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbAldBatch_Disp
    '機　能：ﾊﾞｯﾁｺﾝﾎﾞ設定処理
    '引　数：なし
    '戻り値：
    '作成日：2018/08/07 (Tue) 10:09:46 T.Oide
    '更新日：2018/08/07 (Tue) 10:09:46
    '備　考：
    Private Sub prvcmbAldBatch_Disp()
        
        Dim llngCnt             As Integer          'ﾙｰﾌﾟｶｳﾝﾄ
        Dim lstrMoniter         As String
        Dim lstrBatchFlowClass  As String
        Dim lstrBatchStatus     As String
        
        Try
            
            With cmbAldBatch
            
                '@初期化
                RemoveHandler cmbAldBatch.Change,AddressOf cmbAldBatch_Change
                .Clear
                AddHandler cmbAldBatch.Change,AddressOf cmbAldBatch_Change
                .Height = CMlngCmbRowHeight             '高さ
                .DispCols = CMlngCmbDispCol4            '表示列(ﾊﾞｯﾁｽﾃｰﾀｽまで）
                .GetCol = CMlngCmbGridCol0              'Text値表示列
                .ValueCol = CMlngCmbValueCol0           '値取得列
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize,.GridFont.Style, .GridFont.Unit)    'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ  
            End With
            
                '@新規作成を追加
            With mtypAldBatchList
                
                cmbAldBatch.AddItem(CMstrBatchSelect _
                            & vbTab _
                            & CMstrThrowInDate _
                            & vbTab _
                            & CMstrMoniBatchClass _
                            & vbTab _
                            & CMstrMoniBatchStatus)
                            
                
                '@ﾊﾞｯﾁ情報ｾｯﾄ
                For llngCnt = 0 To .lngAldBatchListCnt -1
                    
                    '@ﾓﾆﾀ有無表示文字列作成
                    If .typAldBatchList(llngCnt).steMonitorUseFlag = 0 Then
                        lstrMoniter = CMstrMoniter & CMstrMoniterNasi
                    Else
                        lstrMoniter = CMstrMoniter & CMstrMoniterAri
                    End If
                    
                    '@ﾊﾞｯﾁ流動区分表示文字列作成
                    If .typAldBatchList(llngCnt).strBatchFlowClass = CMstrProduct Then
                        lstrBatchFlowClass = CMstrBatchFlowClassPR
                    Else
                        lstrBatchFlowClass = CMstrBatchFlowClassQU
                    End If
                
                    '@ﾊﾞｯﾁ状態表示設定
                    Select Case .typAldBatchList(llngCnt).strBatchStatus
                        
                        '@編集中
                        Case CmstrBatchStatusEdit
                            lstrBatchStatus = CmstrBatchStatusHensyu
                        
                        '@投入待ち
                        Case CmstrBatchStatusThrowInWaite
                            lstrBatchStatus = CmstrBatchStatusTonyuMachi
                        
                        '@投入済
                        Case CmstrBatchStatusThrowIn
                            lstrBatchStatus = CmstrBatchStatusTonyu
                        
                        '@再編集
                        Case CmstrBatchStatusThrowInEdit
                            lstrBatchStatus = CmstrBatchStatusSaihensyu
                        
                    End Select
                    
                
                
                    '@'「ﾊﾞｯﾁID」&「投入予定日」&「ﾓﾆﾀ ﾊﾞｯﾁ流動区分」&「ﾊﾞｯﾁｽﾃｰﾀｽ」
                    cmbAldBatch.AddItem(.typAldBatchList(llngCnt).strBatchId _
                            & vbTab _
                            & .typAldBatchList(llngCnt).strPlanThrowinDate _
                            & vbTab _
                            & lstrMoniter & CPstrSpace & lstrBatchFlowClass _
                            & vbTab _
                            & lstrBatchStatus)
                            
                Next llngCnt

            End With

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvcmbAldBatch_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvvsfAldBatch_Disp
    '機　能：ﾊﾞｯﾁの情報をﾊﾞｯﾁｸﾞﾘｯﾄﾞに表示する
    '引　数：なし
    '戻り値：
    '作成日：2018/08/07 (Tue) 14:58:36 T.Oide
    '更新日：2018/08/07 (Tue) 14:58:36
    '備　考：
    Private Sub prvvsfAldBatch_Disp()
        
        Dim llngCnt             As Integer
        Dim llngLotCnt          As Integer
        Dim llngWFNum           As Integer      'ｳｪﾊｰ数
        
        Try
            
            With mtypAldBatchList
                
                vsfAldBatch.Redraw = False

                'NSYS ちらつき対策
                mblnRedrawFlag = True

                '@ﾊﾞｯﾁ編成ｸﾞﾘｯﾄﾞ初期化
                Call prvvGrid_Init()  

                'NSYS ちらつき対策
                mblnRedrawFlag = False

                '@ﾊﾞｯﾁ情報を格納している構造体から該当情報を探す
                For llngCnt = 0 To .lngAldBatchListCnt -1
                    
                    '@該当ﾊﾞｯﾁIDか
                    If .typAldBatchList(llngCnt).strBatchId = cmbAldBatch.Value Then
                        
                        '@ｸﾞﾘｯﾄﾞ行設定
                        vsfAldBatch.Rows.Count = .typAldBatchList(llngCnt).lngBatchDetailCnt + 1
                        
                        
                        '@ﾓﾆﾀ使用ﾌﾗｸﾞを参照してｳｪﾊｰ枚数を決める
                        If .typAldBatchList(llngCnt).steMonitorUseFlag = 0 Then

                            '@ﾓﾆﾀｰ無(ｳｪﾊｰ:13枚)
                            llngWFNum = CMlngMoniUnUsesWfNum
                        Else

                            '@ﾓﾆﾀｰ有(ｳｪﾊｰ:12枚)
                            llngWFNum = CMlngMoniUsesWfNum
                        End If

                        '@ﾛｯﾄ数ぶん繰返し
                        For llngLotCnt = 1 To .typAldBatchList(llngCnt).lngBatchDetailCnt

                            With .typAldBatchList(llngCnt).typBatchDetail(llngLotCnt -1)

                                '@ｸﾞﾘｯﾄﾞに表示する
                                vsfAldBatch.SetData(llngLotCnt, CMlngvsfAldBatchColNo, .strSeqNum)                                       '№
                                vsfAldBatch.SetData(llngLotCnt, CMlngvsfAldBatchColLotId, .strLotID)                                     'ﾛｯﾄID
                                vsfAldBatch.SetData(llngLotCnt, CMlngvsfAldBatchColPd, pubParentPdToAldPd(.strPdId, mtypTapeStickList))  '機種(3A0機種に変換)
                                vsfAldBatch.SetData(llngLotCnt, CMlngvsfAldBatchColWfNum, .strWfQty)                                     'ｳｪﾊｰ数
                                vsfAldBatch.SetData(llngLotCnt, CMlngvsfAldBatchColChipNum, .strChipQty)                                 'ﾁｯﾌﾟ数
                                vsfAldBatch.SetData(llngLotCnt, CMlngvsfAldBatchColTapeStickGr, prvPdToTapeStickGr(.strPdId))            'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
                                vsfAldBatch.SetData(llngLotCnt, CMlngvsfAldBatchColACarrierGr, .strACrrierGroup)                         'Aｷｬﾘｱｸﾞﾙｰﾌﾟ
                                
                                '@QUかMOか
                                If .strFlowClass = CPstrFlowClassMO Or _
                                   .strFlowClass = CPstrFlowClassQU Then
                                    vsfAldBatch.SetData(llngLotCnt, CMlngvsfAldBatchColACarrierChipNum, .strAtrayChipNum)                 'ﾓﾆﾀｰのAｷｬﾘｱﾁｯﾌﾟ収容数
                                Else
                                    vsfAldBatch.SetData(llngLotCnt, CMlngvsfAldBatchColACarrierChipNum, .strAtrayChipNum * llngWFNum)     'Aｷｬﾘｱﾁｯﾌﾟ収容数(Aﾄﾚｰﾁｯﾌﾟ収容数 * ｳｪﾊｰ数)
                                End If
                                                                                                                                          'Aｷｬﾘｱ空きﾁｯﾌﾟ数(後で表示)
                                vsfAldBatch.SetData(llngLotCnt, CMlngvsfAldBatchColFlowClass, .strFlowClass)                              '種別
                                vsfAldBatch.SetData(llngLotCnt, CMlngvsfAldBatchColTapeStickBatch, .strTapeStickBatchId)                  'ﾃｰﾌﾟ貼りﾊﾞｯﾁID
                                vsfAldBatch.SetData(llngLotCnt, CMlngvsfAldBatchColTapeStickRecp, .strTapeStickRrecipeId)                 'ﾃｰﾌﾟ貼りﾚｼﾋﾟ
                                vsfAldBatch.SetData(llngLotCnt, CMlngvsfAldBatchColOvenBatch, .strOvenBatchId)                            'ｵｰﾌﾞﾝﾊﾞｯﾁID
                                vsfAldBatch.SetData(llngLotCnt, CMlngvsfAldBatchColOvenRecp, .strOvenRecipeId)                            'ｵｰﾌﾞﾝﾚｼﾋﾟ
                                vsfAldBatch.SetData(llngLotCnt, CMlngvsfAldBatchColAldBatch, .strAldBatchId)                              'ALDﾊﾞｯﾁID
                                vsfAldBatch.SetData(llngLotCnt, CMlngvsfAldBatchColAldBRecp, .strAldRecipeId)                             'ALDﾚｼﾋﾟ
            
                                '@投入待ちﾛｯﾄか
                                If .strLotEventId = CmstrLotStatusThrowinWait Then
                                    '@投入待ちは背景色白設定、隠し列に"未"設定
                                    Dim newStyle As CellStyle = vsfAldBatch.Styles.Add("CustomStyle_BackColor_vbWhite")
                                    newStyle.BackColor = SystemColors.Window
                                    Dim cellRange As CellRange = vsfAldBatch.GetCellRange(llngLotCnt, CMlngvsfAldBatchColNo, llngLotCnt, vsfAldBatch.Cols.Count - 1)
                                    cellRange.Style = newStyle
                                    vsfAldBatch.SetData(llngLotCnt, CMlngvsfAldBatchColThrowinStatus, _
                                                    CmstrThlowinStatusMi)
                                Else
                                
                                    '@投入待ち以外は№～Chipまで背景色灰色、隠し列に"済"設定
                                    Dim newStyle As CellStyle = vsfAldBatch.Styles.Add("CustomStyle_BackColor_CPlngNotInputColor")
                                    newStyle.BackColor = ColorTranslator.FromWin32(CPlngNotInputColor)
                                    Dim cellRange As CellRange = vsfAldBatch.GetCellRange(llngLotCnt, CMlngvsfAldBatchColNo, llngLotCnt, CMlngvsfAldBatchColChipNum)
                                    cellRange.Style = newStyle

                                    Dim newStyle2 As CellStyle = vsfAldBatch.Styles.Add("CustomStyle_BackColor_vbWhite")
                                    newStyle2.BackColor = SystemColors.Window
                                    Dim cellRange2 As CellRange = vsfAldBatch.GetCellRange(llngLotCnt, CMlngvsfAldBatchColACarrierGr,llngLotCnt, vsfAldBatch.Cols.Count - 1)                                                           
                                    cellRange2.Style = newStyle2
                                    vsfAldBatch.SetData(llngLotCnt, CMlngvsfAldBatchColThrowinStatus, _
                                                    CmstrThlowinStatusSumi)
                                End If

                            End With

                            '@行の高さの設定
                            vsfAldBatch.Rows(llngLotCnt).Height = CMlngVsfHeight
                            
                        Next
                                                
                        '@投入予定日を表示
                        labThrowInDate.Text = .typAldBatchList(llngCnt).strPlanThrowinDate

                        '@ﾓﾆﾀｰ有無を表示
                        If .typAldBatchList(llngCnt).steMonitorUseFlag = CMlngChkON Then
                            '@ﾓﾆﾀｰ有の場合
                            labMoniter.Text = CMstrMoniterAri
                        Else
                            '@ﾓﾆﾀｰ無の場合
                            labMoniter.Text = CMstrMoniterNasi
                        End If

                        '@バッチ流動区分表示
                        If .typAldBatchList(llngCnt).strBatchFlowClass = CMstrProduct Then
                            '@製品
                            labBatchFlowClass.Text = CMstrBatchFlowClassPR
                        Else
                            '@品確
                            labBatchFlowClass.Text = CMstrBatchFlowClassQU
                        End If

                        '@状態表示
                        Select Case .typAldBatchList(llngCnt).strBatchStatus
                        
                            '@編集中
                            Case CmstrBatchStatusEdit
                                
                                '@編集中表示
                                labStatus.Text = CmstrBatchStatusHensyu
                                
                                '@優先度(非表示)
                                cmbPriority.ListIndex = CMlngCmbNotSelect
                        
                                '@ﾛｯﾄ担当者(非表示)
                                cmbLotManager.ListIndex = CMlngCmbNotSelect
                                
                            '@投入待ち
                            Case CmstrBatchStatusThrowInWaite
                                
                                '@投入待表示
                                labStatus.Text = CmstrBatchStatusTonyuMachi
                                
                                '@優先度(ﾃﾞﾌｫﾙﾄ普通)
                                cmbPriority.ListIndex = CMstrcmbPrioSel
                        
                                '@ﾛｯﾄ担当者(非表示)
                                cmbLotManager.ListIndex = CMlngCmbNotSelect
                                
                            '@投入済
                            Case CmstrBatchStatusThrowIn
                            
                                '@投入済表示
                                labStatus.Text = CmstrBatchStatusTonyu
                                
                                '@優先度(非表示)
                                cmbPriority.ListIndex = CMlngCmbNotSelect
                        
                                '@ﾛｯﾄ担当者(非表示)
                                cmbLotManager.ListIndex = CMlngCmbNotSelect
                                
                            '@再編集
                            Case CmstrBatchStatusThrowInEdit
                            
                                '@再編集表示
                                labStatus.Text = CmstrBatchStatusSaihensyu
                                
                                '@優先度(ﾃﾞﾌｫﾙﾄ普通)
                                cmbPriority.ListIndex = CMstrcmbPrioSel
                        
                                '@ﾛｯﾄ担当者(非表示)
                                cmbLotManager.ListIndex = CMlngCmbNotSelect
                                
                            '@終了(この画面ではありえないけど念のため)
                            Case CmstrBatchStatusBatchOut
                            
                                '@終了表示
                                labStatus.Text = CmstrBatchStatusSyuryou
                                
                                '@優先度(非表示)
                                cmbPriority.ListIndex = CMlngCmbNotSelect
                        
                                '@ﾛｯﾄ担当者(非表示)
                                cmbLotManager.ListIndex = CMlngCmbNotSelect
                                
                        End Select
                        
                        Exit For
                        
                    End If
                    
                Next
                
                vsfAldBatch.Row = 0

                vsfAldBatch.Redraw = True

            End With

            '@「Aｷｬﾘｱｸﾞﾙｰﾌﾟ」を見てｾﾙのﾏｰｼﾞと「Aｷｬﾘｱ空きﾁｯﾌﾟ数」を表示する
            Call prvACarrieEmptNum_Disp(llngWFNum)
            
            '@Aｷｬﾘｱを跨るﾛｯﾄがある場合は黄色表示する
            Call prvACarrieDivideBackColor()
            
            '@表示行があればロック解除
            If vsfAldBatch.Rows.Count > 1 Then
                vsfAldBatch.Enabled = True
            End If

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfAldBatch_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvACarrieEmptNum_Disp
    '機　能：「Aｷｬﾘｱｸﾞﾙｰﾌﾟ」を見てｾﾙのﾏｰｼﾞと「Aｷｬﾘｱ空きﾁｯﾌﾟ数」を表示する
    '引　数：lngWFNum:ﾓﾆﾀｰ有無によるAｶｾｯﾄ1つのｳｴﾊｰ数
    '戻り値：なし
    '作成日：2018/08/07 (Tue) 15:30:29 T.Oide
    '更新日：2018/08/07 (Tue) 15:30:29
    '備　考：
    Private Sub prvACarrieEmptNum_Disp(ByVal lngWFNum As Integer)
        
        Dim llngCnt             As Integer
        Dim lstrACarrierGr      As String
        Dim lngAStartRow        As Integer  '同一Aｶｾｯﾄｽﾀｰﾄ行
        Dim lngAEndRow          As Integer  '同一Aｶｾｯﾄｴﾝﾄﾞ行
        
        Try
            
            With vsfAldBatch
                
                '@ﾍｯﾀﾞｰ行のみの場合、処理不要
                If .Rows.Count <= 1 Then
                    Exit Sub
                End If
                
                '@変数初期化
                lngAStartRow = 1
                lngAEndRow = 1
                
                '@1行目のAｷｬﾘｱｸﾞﾙｰﾌﾟを格納
                lstrACarrierGr = .GetData(lngAStartRow, CMlngvsfAldBatchColACarrierGr)
                
                '@ﾊﾞｯﾁ編成の行ぶん繰返す
                For llngCnt = 2 To vsfAldBatch.Rows.Count - 1

                    '@Aｶｾｯﾄｸﾞﾙｰﾌﾟは同一か
                    If lstrACarrierGr = .GetData(llngCnt, CMlngvsfAldBatchColACarrierGr) Then
                        
                        '@ｴﾝﾄﾞ行を更新
                        lngAEndRow = lngAEndRow + 1
                    
                    Else
                        
                        '@ｸﾞﾙｰﾌﾟが変わった場合
                        ' そこまでの同一Aｷｬﾘｱのﾁｯﾌﾟ数を合計して空き数を計算・表示
                        Call prvACarrieCalc(lngAStartRow, lngAEndRow, lngWFNum)
                        
                        
                        '@開始行、終了行を現在行で初期化
                        lngAStartRow = llngCnt
                        lngAEndRow = llngCnt
                        
                        '@Aｶｾｯﾄｸﾞﾙｰﾌﾟを退避する
                        lstrACarrierGr = .GetData(llngCnt, CMlngvsfAldBatchColACarrierGr)
                        
                    End If
                    
                Next
                
                '@最終ｸﾞﾙｰﾌﾟの同一Aｷｬﾘｱのﾁｯﾌﾟ数を合計して空き数を計算・表示
                Call prvACarrieCalc(lngAStartRow, lngAEndRow, lngWFNum)
                
                '@ｾﾙをﾏｰｼﾞする
                Call prvVsfGridMergeCol(True)
            
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvvsfAldBatch_Disp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvACarrieCalc
    '機　能：同一Aｷｬﾘｱのﾁｯﾌﾟ数を合計して空き数を計算して表示
    '引　数：lngAStartRow：同一Aｶｾｯﾄｽﾀｰﾄ行
    '　　　：lngAEndRow：同一Aｶｾｯﾄｴﾝﾄﾞ行
    '　　　：lngWFNum:ﾓﾆﾀｰ有無によるAｷｬﾘｱ内のｳｪﾊｰ数
    '戻り値：
    '作成日：2018/08/07 (Tue) 16:51:31 T.Oide
    '更新日：2018/08/07 (Tue) 16:51:31
    '備　考：
    Private Sub prvACarrieCalc(ByVal lngAStartRow As Integer, ByVal lngAEndRow As Integer, ByVal lngWFNum As Integer)
        
        Dim llngCalc            As Integer  '計算用ｶｳﾝﾀ
        Dim llngChipNum         As Integer  'Aｶｾｯﾄ搭載ﾁｯﾌﾟ数
        
        Try
            
            With vsfAldBatch
            
                '@①ﾁｯﾌﾟ数合計を計算する
                For llngCalc = lngAStartRow To lngAEndRow
                    llngChipNum = llngChipNum + .GetData(llngCalc, CMlngvsfAldBatchColChipNum)
                Next
                
                '@②「Aｷｬﾘｱ収容数」と「Aｷｬﾘｱ空CHIP数」を表示(各行同じ値)
                For llngCalc = lngAStartRow To lngAEndRow
                    
                    '@「Aｷｬﾘｱ収容数」を表示（「ｸﾞﾙｰﾌﾟ-ｳｪﾊｰ数(ﾁｯﾌﾟ数)」、例「Aキャリア01 12(1040)」）
                    .SetData(llngCalc, CMlngvsfAldBatchColACarrierNum, _
                        CMstrACarrier & _
                        .GetData(lngAStartRow, CMlngvsfAldBatchColACarrierGr) & CPstrSpace & _
                        CStr(lngWFNum) & _
                        CPstrParenthesisLeft & _
                        .GetData(lngAStartRow, CMlngvsfAldBatchColACarrierChipNum) & _
                        CPstrParenthesisRight)
                    
                    '@「Aｷｬﾘｱ空CHIP数」を計算(②-①)して表示
                    .SetData(llngCalc, CMlngvsfAldBatchColACarrierEmptNum, _
                        .GetData(lngAStartRow, CMlngvsfAldBatchColACarrierChipNum) - llngChipNum)
                    
                Next
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvACarrieCalc"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvPdToTapeStickGr
    '機　能：機種からﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟを返す
    '引　数：strPdId：機種
    '戻り値：ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
    '作成日：2018/08/14 (Tue) 10:35:21 T.Oide
    '更新日：2018/08/14 (Tue) 10:35:21
    '備　考：
    Private Function prvPdToTapeStickGr(ByVal strPdId As String) As String

        Dim llngCnt         As Integer
        Dim llngCnt2        As Integer
        Dim lblnFindFlag    As Boolean

        Try
            
            '@結果を初期化
            prvPdToTapeStickGr = vbNullString
            lblnFindFlag = False
            
            With mtypTapeStickList
                
                '@mtypTapeStickListで回す
                For llngCnt = 0 To .lngTapeStickGrCnt -1
                
                    '@.lngPdListCntで回す
                    For llngCnt2 = 0 To .typTapeStickGr(llngCnt).lngPdListCnt -1
                    
                        With .typTapeStickGr(llngCnt)
                        
                            '@機種は一致したか
                            If strPdId = .typPdList(llngCnt2).strParentPdId Then
                                
                                '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟを格納
                                prvPdToTapeStickGr = .strTapeStickGr
                                lblnFindFlag = True
                                Exit For
                            End If
                            
                        End With
                    Next
                    
                    '@見つかったらﾙｰﾌﾟ終了
                    If lblnFindFlag = True Then
                        Exit For
                    End If
                Next
            
                '@============================
                '@見つからなかった場合(投入済の場合、機種IDが3A0になっているのでﾋｯﾄしない)
                ' もう一度3A0の機種で探してみる
                '@============================
                If lblnFindFlag = False Then
                
                    '@mtypTapeStickListで回す
                    For llngCnt = 0 To .lngTapeStickGrCnt -1
                    
                        '@.lngPdListCntで回す
                        For llngCnt2 = 0 To .typTapeStickGr(llngCnt).lngPdListCnt -1
                        
                            With .typTapeStickGr(llngCnt)
                            
                                '@3A0の機種と一致したか
                                If strPdId = .typPdList(llngCnt2).strPdId Then
                                    
                                    '@ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟを格納
                                    prvPdToTapeStickGr = .strTapeStickGr
                                    lblnFindFlag = True
                                    Exit For
                                End If
                                
                            End With
                        Next
                        
                        '@見つかったらﾙｰﾌﾟ終了
                        If lblnFindFlag = True Then
                            Exit For
                        End If
                    Next
            
                End If
            
            End With
            
            
            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvPdToTapeStickGr"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvVsfGridMergeCol
    '機　能：ｾﾙのﾏｰｼﾞを設定する
    '引　数：blnMerge：True:ﾏｰｼﾞする、Flase:ﾏｰｼﾞしない
    '戻り値：
    '作成日：2018/08/18 (Sat) 15:35:59 T.Oide
    '更新日：2018/08/18 (Sat) 15:35:59
    '備　考：
    Private Sub prvVsfGridMergeCol(ByVal blnMerge As Boolean)

        Try
                        
            With vsfAldBatch
            
                'ｾﾙをﾏｰｼﾞ設定(行方向)
                .AllowMerging = AllowMergingEnum.RestrictRows
                
                '一旦ﾏｰｼﾞ解除(新規はﾏｰｼﾞが不要なので)
                .Cols(CMlngvsfAldBatchColTapeStickGr).AllowMerging = blnMerge       'ﾃｰﾌﾟ貼りｸﾞﾙｰﾌﾟ
                .Cols(CMlngvsfAldBatchColACarrierGr).AllowMerging = blnMerge        'Aｷｬﾘｱｸﾞﾙｰﾌﾟ
                .Cols(CMlngvsfAldBatchColACarrierNum).AllowMerging = blnMerge       'Aｷｬﾘｱ収容数
                .Cols(CMlngvsfAldBatchColACarrierChipNum).AllowMerging = blnMerge   'Aｷｬﾘｱﾁｯﾌﾟ収容数(隠)
                .Cols(CMlngvsfAldBatchColACarrierEmptNum).AllowMerging = blnMerge   'Aｷｬﾘｱ空ﾁｯﾌﾟ数
                .Cols(CMlngvsfAldBatchColFlowClass).AllowMerging = blnMerge         '機種
                .Cols(CMlngvsfAldBatchColTapeStickBatch).AllowMerging = blnMerge    'ﾃｰﾌﾟ貼りﾊﾞｯﾁID
                .Cols(CMlngvsfAldBatchColTapeStickRecp).AllowMerging = blnMerge     'ﾃｰﾌﾟ貼りﾚｼﾋﾟ
                .Cols(CMlngvsfAldBatchColOvenBatch).AllowMerging = blnMerge         'ｵｰﾌﾞﾝﾊﾞｯﾁID
                .Cols(CMlngvsfAldBatchColOvenRecp).AllowMerging = blnMerge          'ｵｰﾌﾞﾝﾚｼﾋﾟ
                .Cols(CMlngvsfAldBatchColAldBatch).AllowMerging = blnMerge          'ALDﾊﾞｯﾁID
                .Cols(CMlngvsfAldBatchColAldBRecp).AllowMerging = blnMerge          'ALDﾚｼﾋﾟ

            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvVsfGridMergeCol"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvAldBatchThrowin
    '機　能：ﾛｯﾄを投入する
    '引　数：なし
    '戻り値：
    '作成日：2018/08/24 (Fri) 17:07:24 T.Oide
    '更新日：2018/08/24 (Fri) 17:07:24
    '備　考：
    Private Sub prvAldBatchThrowin()

        Dim lstrFormName            As String           'ﾌｫｰﾑ名(ﾚｽﾎﾟﾝｽ用)
        Dim lstrEventName           As String           'ｲﾍﾞﾝﾄ名(ﾚｽﾎﾟﾝｽ用)
        Dim lblnAns                 As Boolean
        Dim lstrBatchID             As String
        Dim llngLotCnt              As Integer
        Dim ltypLotThrowin          As LotAsmThrowIn
        Dim lstrBefLotId            As String

        Try
               
            '@ｲﾍﾞﾝﾄ,ﾌｫｰﾑ名称を設定
            lstrFormName = Me.Name
            lstrEventName = "cmdThrowin_Click"

            '@作業者ｺｰﾄﾞ入力
            frmxxCM0010.Instance.ShowDialog(Me)
            frmxxCM0010.Instance = Nothing

            '@ｷｬﾝｾﾙﾎﾞﾀﾝによる戻りなら処理中止
            If pblnCancel = True Then
                Exit Sub
            End If

            '@ﾊﾞｯﾁID退避(再表示用)
            lstrBatchID = cmbAldBatch.Value

            '@ﾚｽﾎﾟﾝｽ取得開始
            Call pubResponseStart(lstrFormName, lstrEventName)

            '@ﾛｯﾄ数繰返し
            For llngLotCnt = 1 To vsfAldBatch.Rows.Count - 1

                With ltypLotThrowin
                
                    '@ｽﾃｰﾀｽが未投入のﾛｯﾄで、1つ前のﾛｯﾄIDと異なる場合(Aｷｬﾘｱ跨ぎで同じﾛｯﾄIDが来た場合は飛ばしたい)実行
                    If vsfAldBatch.GetData(llngLotCnt, CMlngvsfAldBatchColThrowinStatus) = CmstrThlowinStatusMi And _
                       vsfAldBatch.GetData(llngLotCnt, CMlngvsfAldBatchColLotId) <> lstrBefLotId Then
                    
                        '@構造体に情報格納
                        .strMsgVer = CMstrlot_throwinAldVer                                                     'ﾒｯｾｰｼﾞﾊﾞｰｼﾞｮﾝ
                        .strSbID = pstrSBID                                                                     'ｼｽﾃﾑﾌﾞﾛｯｸ
                        .strBatchId = cmbAldBatch.Value                                                         'ﾊﾞｯﾁID
                        .strLotID = vsfAldBatch.GetData(llngLotCnt, CMlngvsfAldBatchColLotId)          'ﾛｯﾄID
                        .strPdId = vsfAldBatch.GetData(llngLotCnt, CMlngvsfAldBatchColPd)              '投入機種
                        .strLotPriority = cmbPriority.Value                                                     '優先度
                        .strComments = vbNullString                                                             'ｺﾒﾝﾄ
                        .strEmpID = pstrUserID                                                                  '作業者ID
                        .strFlowClass = vsfAldBatch.GetData(llngLotCnt, CMlngvsfAldBatchColFlowClass)  '種別
                        .strEntryFlag = vbNullString                                                            'ｴﾝﾄﾘﾌﾗｸﾞ
                        
                        '@TS、WS、ZZか
                        If .strFlowClass = "TS" Or .strFlowClass = "WS" Or .strFlowClass = "ZZ" Then
                            .strEngEmpId = cmbLotManager.Value                                                  'ﾛｯﾄ担当者ID
                        Else
                            .strEngEmpId = vbNullString
                        End If
                        
                        .strClassDivision = CPstrCD3X                                                           '処理区分：3X(ﾏｽﾀｰの最新ｴﾝﾄﾘIDで投入)
                        .strOrderNum = vbNullString                                                             'ｵｰﾀﾞ№
                        .strEntryID = vbNullString                                                              'ｴﾝﾄﾘID
                    
                        '@ﾛｯﾄ投入(ALD)
                        If prvblnAldLotThlowin(ltypLotThrowin) = True Then
                            
                            '@"<TRM07I>$$ロット[%2]を投入しました。キャリア[%1]"をﾒｯｾｰｼﾞｳｨﾝﾄﾞに表示
                            pstrDMsg = pubstrMsgReplace_Set(CPstrMsgInf0007, vbNullString, .strLotID)
                            Call pubVsfInfo_Disp(pstrDMsg)
                    
                        Else
                    
                            '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                            Call pubResponseCancel(lstrFormName, lstrEventName)
                            Exit For
                            
                        End If
                
                    End If
                    
                    '@前回値としてﾛｯﾄIDを退避
                    lstrBefLotId = vsfAldBatch.GetData(llngLotCnt, CMlngvsfAldBatchColLotId)
                    
                End With
                
            Next
            
            '================
            '@ALDﾊﾞｯﾁ一覧取得
            ' 最新を取得して表示
            '================
            lblnAns = pubblnAldBatchList_Sel(CMstrbataldbatchlistVer, _
                                             mtypAldBatchList)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                Exit Sub
            End If

            '@ﾊﾞｯﾁｺﾝﾎﾞ設定
            Call prvcmbAldBatch_Disp()

            '@退避したバッチIDを再表示
            If lstrBatchID <> vbNullString Then
                '@退避バッチIDを再表示
                cmbAldBatch.Text = lstrBatchID
            Else
                '@一番最後のﾊﾞｯﾁ(登録したﾊﾞｯﾁ)を表示
                ' ﾁｪﾝｼﾞｲﾍﾞﾝﾄが走って表示する
                cmbAldBatch.ListIndex = cmbAldBatch.ListCount - 1
            End If

            '@ﾚｽﾎﾟﾝｽ取得終了
            Call publngResponseEnd(lstrFormName, lstrEventName)

            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvAldBatchThrowin"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Sub

    '関数名：prvInitDataSelDisp
    '機　能：初期化ﾃﾞｰﾀ取得&表示
    '引　数：なし
    '戻り値：
    '作成日：2018/08/28 (Tue) 13:26:26 T.Oide
    '更新日：2018/08/28 (Tue) 13:26:26
    '備　考：
    Private Function prvInitDataSelDisp() As Boolean

        Dim lblnAns             As Boolean
        Dim lstrFormName        As String
        Dim lstrEventName       As String

        Try
            
            '@初期化
            prvInitDataSelDisp = False
            lstrFormName = Me.Text
            lstrEventName = "prvInitDataSelDisp()"
            
            '================
            '@貼りｸﾞﾙｰﾌﾟ取得
            '================
            lblnAns = pubblnMasTapeStickGrList_Sel(CMstrmas_tapeStickGrListVer, _
                                                   mtypTapeStickList, _
                                                   pstrSBID)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                Exit Function
            End If

            '@優先度情報の取得
            lblnAns = pubblnMasPriolist_Sel(CMstrmas_priolistVer, _
                                            mlngPriorityReasonListCnt, _
                                            mtypPriorityReasonList)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                Exit Function
            End If
            
            '@【作業者ﾘｽﾄ(ﾛｯﾄ担当者ﾘｽﾄ)取得】ﾒｯｾｰｼﾞ送受信処理
            lblnAns = pubblnMasEmplist_Sel(CMstrmas_emplist_Ver, _
                                           mtypLotManagerList, _
                                           mlngLotManagerListCnt)

            '@結果格納
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(Me.Name, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                Exit Function
            End If

            '================
            '@ALDﾊﾞｯﾁ一覧取得
            '================
            lblnAns = pubblnAldBatchList_Sel(CMstrbataldbatchlistVer, _
                                             mtypAldBatchList)
            '@結果判定
            If lblnAns = False Then
                '@ﾚｽﾎﾟﾝｽｷｬﾝｾﾙ
                Call pubResponseCancel(lstrFormName, lstrEventName)

                '@Escﾎﾞﾀﾝを有効
                Me.CancelButton = cmdClose

                Exit Function
            End If
                
            '@ﾊﾞｯﾁｺﾝﾎﾞ設定
            Call prvcmbAldBatch_Disp()
            
            '@新規作成を初期表示
            cmbAldBatch.ListIndex = CMlngCmbFirstIndex

            '@取得時刻表示
            lblNowDate.Text = Format$(Now, CPstrDateFormat)
            
            '@結果成功
            prvInitDataSelDisp = True

            Exit Function

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvInitDataSelDisp"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()
            
        End Try
    End Function

    '関数名：prvACarrieDivideBackColor
    '機　能：Aｷｬﾘｱを跨るﾛｯﾄが存在する場合背景を黄色表示する
    '引　数：なし
    '戻り値：
    '作成日：2018/08/29 (Wed) 16:11:55 T.Oide
    '更新日：2018/08/29 (Wed) 16:11:55
    '備　考：
    Private Sub prvACarrieDivideBackColor()

        Dim llngRow         As Integer

        Try
            
            With vsfAldBatch
            
                '@ｸﾞﾘｯﾄﾞで回す(2行目からﾁｪｯｸ)
                For llngRow = 2 To .Rows.Count - 1
            
                    '@上の行とﾛｯﾄIDが同じか
                    If .GetData(llngRow - 1, CMlngvsfAldBatchColLotId) = _
                       .GetData(llngRow, CMlngvsfAldBatchColLotId) Then
                       
                       '@背景色をオレンジにする
                        Dim newStyle As CellStyle = .Styles.Add("CustomStyle_BackColor_CPlngVbColorOrange")
                        newStyle.BackColor = ColorTranslator.FromWin32(CPlngVbColorOrange)
                        Dim cellRange As CellRange = .GetCellRange(llngRow - 1, CMlngvsfAldBatchColLotId, _
                                               llngRow, CMlngvsfAldBatchColChipNum)
                        cellRange.Style = newStyle
                    End If
                Next
                
            End With
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvACarrieDivideBackColor"
                .strErrMessage = vbNullString
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Sub

    '関数名：prvcmbPrioList_Disp
    '機　能：優先度Comboﾘｽﾄ作成
    '引　数：なし
    '戻り値：なし
    '作成日：2018/09/03 (Mon) 16:05:52 T.Oide
    '更新日：2018/09/03 (Mon) 16:05:52
    '備　考：
    Private Sub prvcmbPrioList_Disp()

        Dim llngCnt             As Integer                                  'ﾙｰﾌﾟｶｳﾝﾄ
        
        Try
            
            '@ｺﾝﾎﾞ制御(ﾘｽﾄｸﾘｱ&ﾘｽﾄ設定)-優先度
            With cmbPriority
            
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽの初期化
                .Clear
                .Enabled = True
                .DirectInput = False                                            '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=0)
                .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = CMlngCmbGroupCols                                  '列方向のﾚｺｰﾄﾞ数
                .GroupRows = mlngPriorityReasonListCnt                          '行方向のﾚｺｰﾄﾞ数
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)                       'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize,.GridFont.Style, .GridFont.Unit)    'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ    
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .ValueCol = CMlngCmbValueCol1                                   'Val値は1
                
                '@ｺﾝﾎﾞﾘｽﾄﾎﾞｯｸｽのﾘｽﾄ作成
                For llngCnt = 0 To mlngPriorityReasonListCnt -1
                    .AddItem(mtypPriorityReasonList(llngCnt).strMasPriorityId _
                           & CPstrSpace _
                           & mtypPriorityReasonList(llngCnt).strMasPriorityName _
                           & vbTab _
                           & mtypPriorityReasonList(llngCnt).strMasPriorityId)
                Next llngCnt                                                    '[ID 和名] & ID
                
                '@優先順位ｺﾝﾎﾞﾎﾞｯｸｽ初期値ｾｯﾄ
                .ListIndex = CMstrcmbPrioSel
            End With

            Exit Sub
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey             '機能ID
                .strProcName = "prvcmbPrioList_Disp"        '処理名
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
    '作成日：2018/09/03 (Mon) 16:06:23 T.Oide
    '更新日：2019/02/27 (Wed) 11:23:09 T.Oide
    '備　考：
    Private Sub prvCmbLotManagerList_Disp()

        Dim llngCnt             As Integer                                  'ﾙｰﾌﾟｶｳﾝﾄ
        
        Try

            With cmbLotManager
            
                .Clear                                                          'ｸﾘｱ
                .DirectInput = False                                            '直接入力(False)
                .SelectMode = CMlngCMbSelectMode                                '選択ﾓｰﾄﾞ(複数選択ﾓｰﾄﾞ=0)
                .AllSelectButton = True                                         '全選択ﾎﾞﾀﾝ表示
                .DispCols = CMlngCmbDispCols                                    'ｸﾞﾘｯﾄﾞ表示列数
                .GroupCols = CMlngCmbGroupCols                                  '列方向のﾚｺｰﾄﾞ数
        '@↓2019/02/27 (Wed) 11:22:59 T.Oide **************************************************
                '.GroupRows = mlngPriorityReasonListCnt                          '行方向のﾚｺｰﾄﾞ数
        '@↑2019/02/27 (Wed) 11:22:59 T.Oide **************************************************
                .Font = New Font(.Font.FontFamily, CMlngCmbFontSize, .Font.Style, .Font.Unit)                       'ﾌｫﾝﾄｻｲｽﾞ
                .GridFont = New Font(.GridFont.FontFamily, CMlngCmbGridFontSize,.GridFont.Style, .GridFont.Unit)    'ｸﾞﾘｯﾄﾞﾌｫﾝﾄｻｲｽﾞ    
                .RowHeight = CMlngCmbRowHeight                                  'ﾘｽﾄ行の高さ
                .ColAlignment(CMlngCmbGridCol0) = TextAlignEnum.LeftCenter      '左寄中央揃え
                .ValueCol = CMlngCmbValueCol1                                   'IDがVal値
                
                
                '@空欄ありの為,最初の1行は空欄をｾｯﾄ
                .AddItem(CPstrSpace & vbTab & CPstrSpace)
                
                For llngCnt = 0 To mlngLotManagerListCnt -1
                    
                    '@ｺﾝﾎﾞ内容設定：ﾛｯﾄ担当者名/ﾛｯﾄ担当者ID
                    .AddItem(mtypLotManagerList(llngCnt).strTechManName _
                           & vbTab _
                           & mtypLotManagerList(llngCnt).strTechManID)
                Next llngCnt
                
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

    '関数名：prvThrowinChk
    '機　能：未投入ありかﾁｪｯｸする
    '引　数：なし
    '戻り値：True：未投入有、False：全ﾛｯﾄ投入済
    '作成日：2018/09/04 (Tue) 16:43:50 T.Oide
    '更新日：2018/09/04 (Tue) 16:43:50
    '備　考：
    Private Function prvThrowinChk() As Boolean

        Dim llngCnt             As Integer

        Try
            
            '@結果初期化
            prvThrowinChk = False
            
            With vsfAldBatch
            
                '@ﾊﾞｯﾁｸﾞﾘｯﾄﾞを回して確認
                For llngCnt = 1 To .Rows.Count - 1
            
                    '@未投入か
                    If .GetData(llngCnt, CMlngvsfAldBatchColThrowinStatus) = _
                       CmstrThlowinStatusMi Then
                    
                        '@未投入有
                        prvThrowinChk = True
                        Exit For
                    End If
                    
                Next
                
            End With
            
            Exit Function
            
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
    End Function

    '関数名：chkLotManager
    '機　能：ﾛｯﾄ担当者ﾁｪｯｸ
    '引　数：なし
    '戻り値：True:OK、Flase:NG
    '作成日：2019/02/27 (Wed) 11:37:53 T.Oide
    '更新日：2019/02/27 (Wed) 11:37:53
    '備　考：
    Private Function chkLotManager()
        
        Dim llngRow             As Integer
        Dim lblnWithOutProduct  As Boolean      '量産品以外があったかﾌﾗｸﾞ
        
        '@ﾛｯﾄ担当者の入力ﾁｪｯｸを行う
        '実験品がﾊﾞｯﾁ内にある場合、ﾛｯﾄ担当者を設定しないとダメ
        '全て量産品(PR、ES)の場合、ﾛｯﾄ担当者は未入力でもOK
        
        Try
            
            '@戻りを初期化
            chkLotManager = False
            
            With vsfAldBatch

                '@ﾊﾞｯﾁ内に量産以外はあるか
                lblnWithOutProduct = False
                For llngRow = 1 To .Rows.Count - 1
            
                    '@量産(PR,ES)以外か
                    If .GetData(llngRow, CMlngvsfAldBatchColFlowClass) <> CPstrFlowClassPR And _
                       .GetData(llngRow, CMlngvsfAldBatchColFlowClass) <> CPstrFlowClassES Then
            
                        '@量産以外ﾌﾗｸﾞｾｯﾄ
                        lblnWithOutProduct = True
                        Exit For
                    End If
                Next
            
                '@量産以外のﾛｯﾄが存在するか
                If lblnWithOutProduct = True Then
                
                    '@ﾛｯﾄ担当者入力済か
                    If cmbLotManager.Text <> vbNullString Then
                        '@結果OK
                        chkLotManager = True
                    End If
                Else
                   '@全て量産品の場合、未入力でもOK
                   chkLotManager = True
                End If
                
            End With
            
            Exit Function
            
        Catch ex As Exception
            
            '@ｴﾗｰ情報設定
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey     '機能ID
                .strProcName = "chkLotManager"      '処理名
                .strErrMessage = vbNullString       'ｴﾗｰﾒｯｾｰｼﾞ
            End With

            '@共通ｴﾗｰ処理
            Call pubOnError_Proc()

        End Try
    End Function

    '関数名：prvBtnCtl
    '機　能：ﾎﾞﾀﾝ有効/無効制御
    '引　数：なし
    '戻り値：
    '作成日：2018/08/17 (Fri) 15:07:20 T.Oide
    '更新日：2019/02/27 (Wed) 13:26:57 T.Oide
    '備　考：
    Private Sub prvBtnCtl()

    '@↓2019/02/27 (Wed) 13:27:45 T.Oide **************************************************
        Dim llngRow             As Integer
        Dim lblnWithOutProduct  As Boolean
    '@↑2019/02/27 (Wed) 13:27:45 T.Oide **************************************************

        Try
            
            '@================
            '@「ロット投入(ALD)」ﾎﾞﾀﾝ
            '@ 「状態が“投入待ち”」か「“投入済”or “再編集”で未投入ﾛｯﾄあり」で、
            '@ 優先度設定済､ロット担当設定済(全ﾛｯﾄ量産品の場合は未設定でもOK)
            '@================
        '@↓2019/02/27 (Wed) 11:36:41 T.Oide **************************************************
        '@    If (labStatus.Caption = CmstrBatchStatusTonyuMachi Or _
        '@        ((labStatus.Caption = CmstrBatchStatusTonyu Or labStatus.Caption = CmstrBatchStatusSaihensyu) And prvThrowinChk = True)) And _
        '@       cmbPriority.Text <> vbNullString And cmbLotManager.Text <> vbNullString Then
        '@--------------------------------------------------------------------------------------
            If (labStatus.Text = CmstrBatchStatusTonyuMachi Or _
                ((labStatus.Text = CmstrBatchStatusTonyu Or labStatus.Text = CmstrBatchStatusSaihensyu) And prvThrowinChk = True)) And _
               cmbPriority.Text <> vbNullString And chkLotManager = True Then
        '@↑2019/02/27 (Wed) 11:36:41 T.Oide **************************************************
                cmdThrowin.Enabled = True
            Else
                cmdThrowin.Enabled = False
            End If
            
            '@================
            '@「閉じる」ﾎﾞﾀﾝ
            '@================
            cmdClose.Enabled = True
            
            '@================
            '@「優先度」
            '@「状態が“投入待ち”」か「“投入済”or “再編集”で未投入ﾛｯﾄあり」
            '@================
            If (labStatus.Text = CmstrBatchStatusTonyuMachi Or _
               ((labStatus.Text = CmstrBatchStatusTonyu Or labStatus.Text = CmstrBatchStatusSaihensyu) And prvThrowinChk = True)) Then
                cmbPriority.Enabled = True
            Else
                cmbPriority.Enabled = False
            End If
            
            '@================
            '@「ﾛｯﾄ担当者」
            '@「状態が“投入待ち”」か「“投入済”or “再編集”で未投入ﾛｯﾄあり」で有効
            '@ 但し、全て量産品の場合は設定不要なので無効化
            '@================
            If (labStatus.Text = CmstrBatchStatusTonyuMachi Or _
                ((labStatus.Text = CmstrBatchStatusTonyu Or labStatus.Text = CmstrBatchStatusSaihensyu) And prvThrowinChk = True)) Then
                
                '@量産品以外のﾛｯﾄがあるか確認
                lblnWithOutProduct = False
                For llngRow = 1 To vsfAldBatch.Rows.Count - 1
            
                    '@量産(PR,ES)以外か
                    If vsfAldBatch.GetData(llngRow, CMlngvsfAldBatchColFlowClass) <> CPstrFlowClassPR And _
                       vsfAldBatch.GetData(llngRow, CMlngvsfAldBatchColFlowClass) <> CPstrFlowClassES Then
            
                        '@量産以外ﾌﾗｸﾞｾｯﾄ
                        lblnWithOutProduct = True
                        Exit For
                    End If
                Next
            
                '@量産品以外のﾛｯﾄありか
                If lblnWithOutProduct = True Then
                    cmbLotManager.Enabled = True
                Else
                    cmbLotManager.Enabled = False
                End If
            Else
                cmbLotManager.Enabled = False
            End If
            
            
            Exit Sub

        Catch ex As Exception

            '@ｴﾗｰ情報設定(strMenuKey：機能ID/strProcName：関数名/strErrMessage：ｴﾗｰﾒｯｾｰｼﾞ)
            With ptypOnErrorInfo
                .strMenuKey = CMstrLocalMenuKey
                .strProcName = "prvBtnCtl"
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


    '関数名 list_BeforeDoubleClick
    '機　能：グリッドダブルクリック前処理
    '引　数：なし
    '戻り値：なし
    '作成日：2019/01/14 (Mon) 17:00:00 NSYS
    '備　考：
    Private Sub list_BeforeDoubleClick(sender As Object, e As BeforeMouseDownEventArgs) Handles vsfAldBatch.BeforeDoubleClick

        ' ObjectをGridに変換
        Dim gridObj As C1FlexGrid
        gridObj = CType(sender, C1FlexGrid)

        'ダブルクリックした箇所が列の境界線かを判断する
        If gridObj.HitTest(e.X,e.Y).Type = HitTestTypeEnum.ColumnResize Then

            '列の境界線の場合、本来の処理をキャンセル
            e.Cancel = True

        End If

    End Sub

    '関数名 cmbAldBatch_CloseUp
    '機　能：バッチコンボ 閉じる
    '引　数：なし
    '戻り値：なし
    '作成日：2020/05/04 (Mon) 17:00:00 NSYS
    '備　考：
    Private Sub cmbAldBatch_CloseUp(ByVal sender As Object, ByVal e As EventArgs) Handles cmbAldBatch.CloseUp

        Call pubSetFocus(cmbAldBatch)

    End Sub
End Class
